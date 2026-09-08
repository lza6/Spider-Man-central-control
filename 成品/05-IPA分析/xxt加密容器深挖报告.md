# xxt 加密容器深挖报告 (最终)

## 加密格式解析
```
[1b585854]  magic
[03000100]  版本
[8B]        盐
[4B]        密文长度 (129958)
[4B]×8      4个区段大小: 256/316/288/854 (头区, 高熵)
[16B IV]    d95bd08b8a13bc89af8fb94bd35ab943 (密文首16B)
[N B]       AES-CBC 密文 (129942B, 块对齐+6B尾部)
```

## 加密实现
- 算法: AES-CBC (ARMv8 Crypto Extension 硬件加速: aese/aesd/aesmc 指令)
- 库: BoringSSL (libxxtouch.so 内嵌)
- 密钥: 运行态内存加载, 非静态硬编码常量 (已穷举全部可推断密钥)

## 静态破解尝试记录 (全部未命中)
| 方法 | 结果 |
|------|------|
| 已知密钥 (8d4d305a..., KkBofxSU..., ALIYUN) | ✗ |
| 头区材料哈希 (sha1/256/md5 of 区1-4) | ✗ |
| 常见 key (xxtouch/XXTouch/1ferver 的 hash) | ✗ |
| 密文块关系分析 (流密码检测) | ✗ (确认AES-CBC) |
| 头部区段 zlib/lzma/bz2 解压 | ✗ |
| AES S-box / 常量搜索 | ✗ (用硬件指令无S-box) |

## 深挖成果 (有效产出)
1. **libxxtouch.so 完整 HTTP API 路由表** (52条): /encript /encript_file /download_encript /command_spawn /daemon_spawn 等
2. **CC.lua 精确还原** (6831字节, 从exe内嵌, LuaJIT语法验证通过)
3. **TKZK.json 业务功能全定义** (24功能+8多选+全部参数)
4. **加密格式完全解析** (头结构/IV/密文边界)
5. **AES 实现确认** (ARM Crypto 硬件加速 + BoringSSL)

## 密钥提取唯一路径
真机 (越狱 iPhone) + Frida hook libxxtouch.so 的 AES 函数
或 hook /encript_file 处理器 → 捕获解密后明文
需真机环境, 已提供完整前置分析。
