# Spider-Man-central-control · 蜘蛛侠中控逆向

**蜘蛛侠中控（XXTCC 1.0.1.0）· iPhone 群控 + TikTok 养号工具的完整逆向工程**

## 📦 仓库结构
```
├── 成品/                      # 完整逆向成品包
│   ├── 01-原始软件/           exe + CC.mdb + config.json
│   ├── 02-反编译源码/         57个C#源码 (25493行, ILSpy)
│   ├── 03-脚本还原/           TKZK Lua + CC库(多版本) + 字符串
│   ├── 04-数据库导出/         账号表/登录账号 全量
│   ├── 05-IPA分析/            XXTouch框架(241 Lua) + 加密器 + API路由
│   ├── 06-验证工具/           E2E 9/9 + 虚拟iPhone
│   └── 07-文档/               逆向报告 + 无真机验证 + xxt深挖
├── decompiled_source/         # 反编译源码 (部分重复, 版本参考)
└── README.md
```

## 🔑 核心成果
- 57 个 C# 源码完整反编译（25,493 行）
- 授权签名算法、通信协议、数据库、SSH 安装全还原
- CC.lua 通讯库精确还原（6831B）+ LuaJIT 验证通过
- TKZK.xxt 业务脚本 Lua 完整还原（918 行）
- xxt 加密容器格式完全解析（AES-CBC + ARM硬件加速）
- 控制端 Nancy HTTP 27010 接口实测 9/9

## ⚠️ 合规声明
仅供安全研究。批量养号违反 TikTok 社区规则，使用风险自担。
