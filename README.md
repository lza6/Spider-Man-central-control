# Spider-Man-central-control · 蜘蛛侠中控逆向

本项目为 **蜘蛛侠中控（XXTCC 1.0.1.0）** Windows 端 .NET 程序的完整逆向分析：

- 程序集结构、类型/方法全解析
- DNGuard 混淆还原（#US 字符串堆移位混淆破解）
- TikTok 批量养号 Lua 脚本（TKZK.xxt）完整还原
- CC.mdb 数据库（账号表/登录账号/本地账号储存）完整解析
- 内置 Nancy HTTP 中控服务（27010）接口还原与实测
- 功能"不可用"根因诊断

> ⚠️ 合规声明：本仓库仅用于**安全研究与逆向分析**。批量养号、刷粉等行为违反 TikTok 社区规则，使用方自行承担全部法律与账号风险。仓库内文件包含示例账号凭证，请勿用于非法用途。

## 文档
- 📄 [逆向分析报告](docs/逆向分析报告.md)

## 目录
```
├── TKZK_deobfuscated.lua   # 完整还原的 Lua 脚本（918行）
├── docs/
│   └── 逆向分析报告.md
└── tools/
    ├── CC_library.lua      # CC 通信库
    ├── US_strings_full.txt # 还原用户字符串
    └── TKZK_lua_deobf.lua  # Lua 混合解码版
```

## 快速结论
控制端 7/7 接口实测通过；功能"用不了"根因 = **无 iPhone 设备上线**（设备列表为空），非功能缺失或授权故障。
