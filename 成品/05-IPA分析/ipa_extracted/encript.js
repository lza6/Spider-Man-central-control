function strturn(a) {
  var b, c;
  if ("" != a) {
    for (b = "", c = a.length - 1; c >= 0; c--) b += a.charAt(c);
    return b
  }
}
function GetFileExt(a) {
  if ("" != a) {
    var b = "." + a.replace(/.+\./, "");
    return b
  }
}
function GetFileNameNoExt(a) {
  var b = strturn(GetFileExt(a)),
    c = strturn(a),
    d = strturn(c.replace(b, "")),
    e = GetFileName(d);
  return e
}
function GetFileName(a) {
  if ("" != a) {
    var b = a.split("\\");
    return b[b.length - 1]
  }
}
$(document).ready(function () {
  function parseBlobJson(blob, callback) {
    var reader = new FileReader;
    reader.readAsText(blob),
      reader.onload = function () {
        var json = null;
        try {
          json = JSON.parse(this.result)
        } catch (e) { }
        callback(json)
      }
  }
  function getEncryptErrorMessage(json) {
    if (!json) return "出现一个错误";
    if ("string" == typeof json.detail && "" !== json.detail) return json.detail;
    if ("string" == typeof json.message && "" !== json.message) return json.message;
    return "出现一个错误"
  }
  function arrayBufferToBase64(a) {
    var e, b = "",
      c = new Uint8Array(a),
      d = c.byteLength;
    for (e = 0; d > e; e++) b += String.fromCharCode(c[e]);
    return window.btoa(b)
  }
  function base64ToArrayBuffer(a) {
    var e, b = window.atob(a),
      c = b.length,
      d = new Uint8Array(c);
    for (e = 0; c > e; e++) d[e] = b.charCodeAt(e);
    return d.buffer
  }
  function timeoutrun() {
    $.post("/deviceinfo", "",
      function (a) {
        0 == a.code ? $("#zeversion").html(a.data.zeversion) : mdui.snackbar({
          message: a.message
        }),
          $("#bform").show(),
          $("#display-message").hide()
      },
      "json").error(function () {
        setTimeout(timeoutrun, 3e3)
      })
  }
  function up_file(files) {
    var fileloaded, reader, _file = files[0];
    _file.size > 31457280 ? mdui.alert("脚本大于30M不允许加密") : ($("#display-message").show(), $("#bform").hide(), fileloaded = 0, reader = new FileReader, reader.readAsBinaryString(_file), reader.onload = function () {
      XMLHttpRequest.prototype.sendAsBinary || (XMLHttpRequest.prototype.sendAsBinary = function (a) {
        function b(a) {
          return 255 & a.charCodeAt(0)
        }
        var c = Array.prototype.map.call(a, b),
          d = new Uint8Array(c);
        this.send(d.buffer)
      });
      var xhr = new XMLHttpRequest;
      xhr.open("POST", "encript"),
        xhr.overrideMimeType("application/octet-stream"),
        ".xui" == _file.name.match(/\.\w+$/) ? xhr.setRequestHeader("args", JSON.stringify({
          xuic: !0,
          filename: encodeURI(_file.name.replace(/(.*\/)*([^.]+).*/gi, "$2"))
        })) : xhr.setRequestHeader("args", JSON.stringify({
          no_strip: $("#no_strip").is(":checked"),
          filename: encodeURI(GetFileNameNoExt(_file.name)),
          entitlements: {
            "allow-external-require": $("#allow_external_require").is(":checked")
          }
        })),
        xhr.responseType = "blob",
        xhr.sendAsBinary(reader.result),
        xhr.onreadystatechange = function () {
          4 == xhr.readyState && (200 == xhr.status ? (parseBlobJson(xhr.response, function (json) {
            json && json.data && json.data.download_uri ? location.href = json.data.download_uri : mdui.snackbar({
              message: "出现一个错误"
            })
          }),
            $("#display-message").hide(), $("#bform").show()) : (parseBlobJson(xhr.response, function (json) {
              mdui.alert(getEncryptErrorMessage(json)),
                $("#display-message").hide(),
                $("#bform").show()
            })))
        }
    })
  }
  $("#main-drawer a[href='./encript.html']").addClass("mdui-list-item-active"),
    $("#choose_file_upgrade").click(function () {
      var a = $('<input type="file" style="display:none" name="upload"/>');
      a.change(function (a) {
        up_file(a.target.files)
      }),
        a.click()
    });
  var dropbox = document.getElementById("dropbox");
  document.addEventListener("dragenter",
    function () {
      dropbox.style.borderColor = "gray"
    },
    !1),
    document.addEventListener("dragleave",
      function () {
        dropbox.style.borderColor = "silver"
      },
      !1),
    dropbox.addEventListener("dragenter",
      function () {
        dropbox.style.borderColor = "gray",
          dropbox.style.backgroundColor = "white"
      },
      !1),
    dropbox.addEventListener("dragleave",
      function () {
        dropbox.style.backgroundColor = "transparent"
      },
      !1),
    dropbox.addEventListener("dragenter",
      function (a) {
        a.stopPropagation(),
          a.preventDefault()
      },
      !1),
    dropbox.addEventListener("dragover",
      function (a) {
        a.stopPropagation(),
          a.preventDefault()
      },
      !1),
    dropbox.addEventListener("drop",
      function (a) {
        a.stopPropagation(),
          a.preventDefault(),
          handleFiles(a.dataTransfer.files)
      },
      !1),
    $("#no_strip").on("click",
      function () {
        switch (this.checked) {
          case !0: $(".xxtouch-tip").css("color", "#FF0000");
            break;
          case !1: $(".xxtouch-tip").css("color", "rgba(0,0,0,.54)")
        }
      }),
    handleFiles = function (a) {
      up_file(a)
    }
});
