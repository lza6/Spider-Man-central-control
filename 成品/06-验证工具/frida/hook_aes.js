// hook_aes.js — 抓取 libxxtouch.so 的 AES 加解密密钥 (BoringSSL EVP 层)
// 用法: frida -U -n XXTExplorer -l hook_aes.js --no-pause
// 在手机上运行 AI-TKZS.xxt 脚本 → 触发解密 → 控制台输出 KEY 和 IV

function dumpKeys(kind, key, iv) {
  console.log("[" + kind + "]");
  if (!key.isNull()) {
    [16, 24, 32].forEach(function (len) {
      try {
        console.log("  KEY(" + len + "B) = " + hexdump(key.readByteArray(len)));
      } catch (e) {}
    });
  }
  if (!iv.isNull()) {
    try { console.log("  IV(16B) = " + hexdump(iv.readByteArray(16))); } catch (e) {}
  }
}

["EVP_EncryptInit_ex", "EVP_DecryptInit_ex"].forEach(function (name) {
  var addr = Module.findExportByName("libxxtouch.so", name);
  if (!addr) { console.log("[!] " + name + " 未导出, 尝试 BoringSSL 内部符号"); return; }
  Interceptor.attach(addr, {
    onEnter: function (args) {
      dumpKeys(name, args[3], args[4]);
    }
  });
  console.log("[+] hook " + name + " @ " + addr);
});

// AES 密钥设置函数 (旧 OpenSSL API, 部分库仍用)
["AES_set_encrypt_key", "AES_set_decrypt_key", "aes_nohw_set_encrypt_key", "aes_nohw_set_decrypt_key"].forEach(function (name) {
  var addr = Module.findExportByName("libxxtouch.so", name);
  if (addr) {
    Interceptor.attach(addr, {
      onEnter: function (args) {
        // args[0] = key bytes, args[1] = keybits (192/256/128)
        var bits = args[1].toInt32();
        console.log("[AES_set_key " + name + "] bits=" + bits);
        try {
          console.log("  KEY = " + hexdump(args[0].readByteArray(bits / 8)));
        } catch (e) {}
      }
    });
    console.log("[+] hook " + name + " @ " + addr);
  }
});
