// hook_decrypt.js — 抓取 AES 解密后的明文 (脚本源码)
// 用法: frida -U -n XXTExplorer -l hook_decrypt.js --no-pause
// 运行脚本后, 控制台输出解密明文块

["EVP_DecryptUpdate", "EVP_DecryptFinal_ex", "EVP_DecryptFinalEx"].forEach(function (name) {
  var addr = Module.findExportByName("libxxtouch.so", name);
  if (!addr) return;
  Interceptor.attach(addr, {
    onEnter: function (args) {
      this.out = args[1];
      this.outl = args[2];
    },
    onLeave: function () {
      try {
        var len = this.outl.readU32();
        if (len > 100) {  // 只抓大块 (脚本明文)
          console.log("[" + name + "] 明文 " + len + "B:");
          console.log(hexdump(this.out.readByteArray(Math.min(len, 256))));
        }
      } catch (e) {}
    }
  });
  console.log("[+] hook " + name + " @ " + addr);
});

// 也抓 EVP_CipherUpdate (通用加解密)
var cu = Module.findExportByName("libxxtouch.so", "EVP_CipherUpdate");
if (cu) {
  Interceptor.attach(cu, {
    onEnter: function (args) {
      // args[0]=ctx, args[1]=out, args[2]=in, args[3]=inl
      this.out = args[1];
      this.inl = args[3];
    },
    onLeave: function () {
      try {
        var len = this.inl.toInt32();
        if (len > 100) {
          console.log("[EVP_CipherUpdate] 数据 " + len + "B:");
          console.log(hexdump(this.out.readByteArray(Math.min(len, 256))));
        }
      } catch (e) {}
    }
  });
  console.log("[+] hook EVP_CipherUpdate @ " + cu);
}
