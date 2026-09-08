# Spider-Man-central-control · 蜘蛛侠中控逆向

**蜘蛛侠中控（XXTCC 1.0.1.0）· iPhone 群控 + TikTok 养号工具的完整逆向工程**

## 📦 仓库结构
```
├── 成品/                      # 完整逆向成品包
│   ├── 01-原始软件/           exe + CC.mdb + config.json
│   ├── 02-反编译源码/         57个C#源码 (25493行, ILSpy)
│   ├── 03-脚本还原/           TKZK Lua + CC库(多版本) + 字符串
│   ├── 04-数据库导出/         账号表/登录账号 全量
│   ├── 05-IPA分析/            XXTouch框架(241 Lua) + 加密器 + API路由 + xxt深挖
│   ├── 06-验证工具/           E2E 9/9 + 虚拟iPhone + Frida hook脚本
│   └── 07-文档/               逆向报告 + 无真机验证 + Frida深挖指南
├── decompiled_source/         # 反编译源码 (备份)
└── README.md
```

## 🔑 已完成成果
- 57 个 C# 源码完整反编译（25,493 行）
- 授权签名算法、通信协议、数据库、SSH 安装全还原
- CC.lua 通讯库精确还原（6831B）+ LuaJIT 验证通过
- xxt 加密容器格式完全解析（AES-CBC + ARM硬件加速）
- 控制端 Nancy HTTP 27010 接口实测 9/9
- libxxtouch.so 完整 API 路由表（52 条）

---

## 🚧 未完成事项（需真机）

### 唯一阻塞项：xxt 加密密钥提取

**问题**：TKZK.xxt / AI-TKZS.xxt 业务脚本用 AES-CBC 加密，密钥在 `libxxtouch.so` 原生库**运行态内存**中（非静态常量）。静态逆向已到极限。

**解决路径**：越狱 iPhone + Frida Hook AES 函数 → 抓密钥 → 解密脚本。

### 📖 详细指南
👉 **[NEXT_STEPS_Frida深挖指南.md](成品/07-文档/NEXT_STEPS_Frida深挖指南.md)** — 完整教学（Hook原理/环境/Frida脚本/操作步骤/解密命令）

### 🛠️ 现成的 Frida 脚本
- `成品/06-验证工具/frida/hook_aes.js` — 抓 AES 密钥/IV
- `成品/06-验证工具/frida/hook_decrypt.js` — 抓解密后明文

---

## 🤖 给 AI Agent 的深挖指令

> 有真机后，把下面指令交给 AI Agent 即可继续：

```
你是逆向工程专家。任务：解密 spider-man-central-control 仓库的 xxt 加密脚本。

已完成（勿重复）:
- 成品/02-反编译源码/ = 完整 C# 反编译源码 (57文件)
- 成品/03-脚本还原/CC_库_精确提取版.lua = CC通讯库 (LuaJIT验证通过)
- 成品/05-IPA分析/xxt加密容器深挖报告.md = 加密格式全解析
- 成品/05-IPA分析/libxxtouch完整API路由表.md = 52条API路由
- 成品/06-验证工具/frida/ = 现成hook脚本

你的任务:
1. 读 xxt加密容器深挖报告.md 了解前置
2. 读 Class8.cs(授权) Class9.cs(CC库) 源码
3. frida-ps -U 连越狱iPhone
4. frida -U -n XXTExplorer -l 成品/06-验证工具/frida/hook_aes.js --no-pause
5. 手机上运行 AI-TKZS.xxt 触发解密 → 抓 KEY+IV
6. openssl 解密 TKZK.xxt → 完整业务脚本
7. 用 lupa 验证语法 + 对照 TKZK.json 24功能
8. 解密结果补充到 成品/03-脚本还原/, 更新深挖报告, 推送GitHub

验证标准: 解密.lua LuaJIT语法通过, 含全部24功能实现, 已推送
```

---

## ⚠️ 合规声明
仅供安全研究。批量养号违反 TikTok 社区规则，使用风险自担。
