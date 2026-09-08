# 🎯 下一步待做：用 Frida Hook 深挖 xxt 加密密钥

> 本文档面向：**拥有越狱 iPhone 真机的研究者 / AI Agent**
> 目标：通过动态 Hook 提取 libxxtouch.so 的 AES 密钥，解密 TKZK.xxt / AI-TKZS.xxt 完整业务脚本源码

---

## 一、Hook 是什么？能解决什么问题？

**Hook（钩子）** = 在程序运行时，拦截并修改函数调用的技术。它允许我们在程序执行到某个函数时：
- 查看函数的**参数**（比如 AES 加密时传入的密钥）
- 查看函数的**返回值**（比如解密后的明文）
- 修改函数行为（绕过检查、替换密钥等）

**对本项目的作用**：
我们已通过静态逆向确认 TKZK.xxt 是 **AES-CBC 加密**，但密钥不在静态常量中（在 `libxxtouch.so` 原生库运行态内存中）。**静态分析到此为止**——唯一能拿到密钥的路径就是：让程序在手机上真正解密脚本时，用 Hook 截获 AES 调用，把密钥和明文抓出来。

```
静态分析极限:  [1b585854][头][IV][AES-CBC密文] → 密钥❓
动态Hook:      libxxtouch.so 执行 AES解密 → 抓到 key + 明文 ✅
```

---

## 二、环境准备

### 2.1 需要什么
| 项 | 要求 |
|----|------|
| iPhone | 越狱（或 TrollStore 可注入 Frida） |
| 系统 | iOS 12.0+ |
| 软件 | XXTouch Explorer（本项目 IPA 已含，可安装） |
| 电脑 | 装好 Frida（`pip install frida frida-tools`） |
| 网络 | iPhone 与电脑同一局域网 |

### 2.2 安装 Frida
```bash
# 电脑端
pip install frida frida-tools
# iPhone 端 (越狱商店装 frida 服务)
# 或: 下载 frida-gadget 注入
```

### 2.3 确认连接
```bash
frida-ps -U   # 列出 iPhone 进程, 应看到 XXTExplorer
```

---

## 三、Hook 哪个函数？（看什么源码）

### 3.1 关键线索（已逆向确认）

**加密 API 路由**（见 `成品/05-IPA分析/libxxtouch完整API路由表.md`）：
- `/encript` → API#8
- `/encript_file` → API#13  ← **核心：脚本文件加密入口**
- `/download_encript` → API#17

**加密实现**：`libxxtouch.so` 使用 **BoringSSL + ARMv8 AES 硬件指令**（`aese/aesd/aesmc/aesimc` 共 223 处，见 xxt 深挖报告）

### 3.2 优先 Hook 目标
| Hook 目标 | 说明 |
|-----------|------|
| `EVP_EncryptInit_ex` / `EVP_DecryptInit_ex` | BoringSSL 通用加解密入口，参数含 key/iv |
| `AES_set_encrypt_key` / `AES_set_decrypt_key` | AES 密钥设置函数，直接拿 key |
| `/encript_file` 对应 C++ 处理函数 | 脚本加密入口，解密逻辑附近 |
| `CC_PutKey` 或自定义包装函数 | XXTouch 可能在 AES 外加包装 |

---

## 四、Frida Hook 脚本（可直接运行）

### 4.1 抓 AES 密钥（BoringSSL EVP 层）
```js
// hook_aes.js — 抓取 AES 加解密密钥
Interceptor.attach(Module.findExportByName("libxxtouch.so", "EVP_EncryptInit_ex"), {
    onEnter(args) {
        var ctx = args[0];
        var cipher = args[1];
        var key = args[3];
        var iv = args[4];
        // 读 key (EVP_CIPHER 里查 key 长度)
        console.log("[EVP_EncryptInit] ctx=" + ctx + " cipher=" + cipher);
        if (!key.isNull()) {
            // 尝试读 16/24/32 字节
            for (var len of [16, 24, 32]) {
                try {
                    console.log("  KEY(" + len + ") = " + hexdump(key.readByteArray(len)));
                } catch(e) {}
            }
        }
        if (!iv.isNull()) {
            console.log("  IV = " + hexdump(iv.readByteArray(16)));
        }
    }
});
Interceptor.attach(Module.findExportByName("libxxtouch.so", "EVP_DecryptInit_ex"), {
    onEnter(args) {
        var key = args[3], iv = args[4];
        console.log("[EVP_DecryptInit]");
        if (!key.isNull()) {
            for (var len of [16, 24, 32]) {
                try { console.log("  KEY(" + len + ") = " + hexdump(key.readByteArray(len))); } catch(e) {}
            }
        }
        if (!iv.isNull()) {
            console.log("  IV = " + hexdump(iv.readByteArray(16)));
        }
    }
});
```

### 4.2 抓解密后的明文（EVP_DecryptUpdate 输出）
```js
// hook_decrypt.js — 抓脚本明文
var exportNames = ["EVP_DecryptUpdate", "EVP_DecryptFinal_ex"];
exportNames.forEach(function(name) {
    Interceptor.attach(Module.findExportByName("libxxtouch.so", name), {
        onEnter(args) {
            this.out = args[1];
            this.outlen = args[2];
        },
        onLeave(retval) {
            try {
                var len = this.outlen.readU32();
                if (len > 100) {  // 只抓大块明文(脚本)
                    console.log("[" + name + "] 明文 " + len + "B:");
                    console.log(hexdump(this.out.readByteArray(Math.min(len, 128))));
                }
            } catch(e) {}
        }
    });
});
```

### 4.3 抓 /encript_file 处理函数
```js
// hook_encript.js — 在脚本加密处理时抓数据
// 找到 /encript_file 的 C++ handler (API#13)
// 用 Frida stalker 或找函数: 先 trace 所有含 AES 指令的函数
var aes_fns = ["0x251cc"];  // 已定位的 AES 硬件实现(见深挖报告)
aes_fns.forEach(function(addr) {
    Interceptor.attach(ptr(addr), {
        onEnter(args) {
            console.log("[AES-CBC @ " + addr + "] 调用, 前16B参数: " + hexdump(args[0].readByteArray(16)));
        }
    });
});
```

---

## 五、操作步骤（完整流程）

```bash
# 1. iPhone 连接电脑
frida-ps -U

# 2. 找到 XXTExplorer 进程名 (通常是 "XXTExplorer" 或 "xxt")
frida-ps -U | grep -i xxt

# 3. 启动 hook 脚本
frida -U -n XXTExplorer -l hook_aes.js --no-pause

# 4. 在手机上运行 AI-TKZS.xxt 脚本 (XXTouch Explorer 里运行)
#    → 触发解密 → hook 抓到 key/iv/明文

# 5. 把抓到的 key + 已知 IV(密文首16B) 保存
#    用 OpenSSL 解密:
#    openssl enc -d -aes-256-cbc -K <KEY_HEX> -iv <IV_HEX> -in TKZK.xxt -out TKZK_decrypted.lua

# 6. 若抓到的是解密后明文(4.2), 直接保存为 .lua
```

---

## 六、拿到明文后做什么

1. **解密 TKZK.xxt / AI-TKZS.xxt** → 得到完整养号业务源码（关注/点赞/上传/登录等执行逻辑）
2. **补充到仓库**：`成品/03-脚本还原/` 添加完整业务脚本
3. **对照 TKZK.json 功能清单**：24 功能逐项核对
4. **更新 xxt 深挖报告**：记录实际密钥与解密验证

---

## 七、给 AI Agent 的指令（复制即用）

> 如果你把这个仓库交给 AI Agent 继续深挖，直接复制以下指令：

```
你是逆向工程专家。你的任务是解密 spider-man-central-control 仓库中的 xxt 加密脚本。

背景（已完成）:
- 仓库 成品/02-反编译源码/ 有完整 C# 反编译源码 (57文件)
- 成品/03-脚本还原/ 有 CC.lua 通讯库精确还原版
- 成品/05-IPA分析/ 有 libxxtouch完整API路由表.md 和 xxt加密容器深挖报告.md
- 加密格式已确认: AES-CBC, IV=密文首16B, 密钥在 libxxtouch.so 运行态

你的任务:
1. 阅读 成品/05-IPA分析/xxt加密容器深挖报告.md 了解全部前置分析
2. 阅读 成品/02-反编译源码/Class8.cs (授权签名) 和 Class9.cs (CC库)
3. 连接越狱 iPhone (frida-ps -U 确认)
4. 用 frida 运行 hook_aes.js 抓取 libxxtouch.so 的 AES 密钥
5. 用抓到的密钥解密 TKZK.xxt, 得到完整业务脚本
6. 把解密结果与 成品/03-脚本还原/ 对照, 补充缺失的业务逻辑
7. 更新 xxt加密容器深挖报告.md 记录实际密钥与解密结果

验证标准:
- 解密后的 .lua 能用 lupa(LuaJIT) 加载且语法通过
- 解密脚本包含 TKZK.json 中全部 24 个功能对应的实现
- 更新后的文档与解密产物已推送到 GitHub
```

---

## 八、为什么还没做（当前状态）

| 状态 | 说明 |
|------|------|
| ✅ 已完成 | 静态逆向全部：格式解析、反编译、CC库还原、API路由、协议实测 |
| 🔒 待完成 | xxt 密钥提取 → 需要**真机 Frida**（当前无越狱 iPhone 环境） |
| 阻塞原因 | AES 密钥在原生库运行态内存，静态无法获取 |

> ⚠️ **合规提醒**：本仓库及脚本仅用于安全研究。批量养号、刷粉等行为违反 TikTok 社区规则，请勿用于非法用途。
