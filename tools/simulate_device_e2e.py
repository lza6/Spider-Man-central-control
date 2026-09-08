#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
蜘蛛侠中控 · 模拟设备上线 E2E 回归测试
=====================================
模拟 iPhone(XXTouch) 端 CC 库的行为, 验证中控端控制面全部可用:
  1. Nancy HTTP 服务存活 (GET /)
  2. getui 任务轮询 (GET /getui)
  3. 账号表/登录账号/本地账号储存 读取 (POST /db/list)
  4. 日志上报 (POST /log)
  5. 文件行读取 (POST /file/take_line)

用法:
    python simulate_device_e2e.py [host] [port]
    (默认 127.0.0.1:27010, 需先启动 蜘蛛侠中控.exe)

退出码: 0=全部通过, 1=存在失败
"""
import sys, json, urllib.request, socket

def http(url, method='GET', data=None, ctype='application/json', timeout=4):
    req = urllib.request.Request(url, method=method, data=data)
    req.add_header('Content-Type', ctype)
    try:
        r = urllib.request.urlopen(req, timeout=timeout)
        return r.status, r.read()
    except urllib.error.HTTPError as e:
        return e.code, e.read()
    except Exception as e:
        return -1, str(e).encode()

def db_list(base, table):
    body = json.dumps({'db': table, 'data': {}}).encode()
    return http(base + '/db/list', 'POST', body)

def main():
    host = sys.argv[1] if len(sys.argv) > 1 else '127.0.0.1'
    port = int(sys.argv[2]) if len(sys.argv) > 2 else 27010
    base = f'http://{host}:{port}'
    results = []
    def t(name, ok, detail=''):
        results.append((name, 'PASS' if ok else 'FAIL', detail))
        print(f'  [{"PASS" if ok else "FAIL"}] {name}  {detail}')

    print(f'=== 蜘蛛侠中控 模拟设备 E2E @ {host}:{port} ===\n')

    # 1. 端口探活 (TCP connect)
    try:
        s = socket.create_connection((host, port), timeout=3)
        s.close()
        t('TCP 端口存活', True)
    except Exception as e:
        t('TCP 端口存活', False, str(e))

    # 2. Nancy HTTP 存活
    code, body = http(base + '/')
    t('Nancy HTTP 存活', code == 200 and b'Hello Nancy' in body, body[:40].decode('utf8','replace'))

    # 3. getui 任务轮询
    code, body = http(base + '/getui')
    t('getui 任务轮询', code == 200, body[:60].decode('utf8','replace'))

    # 4. 账号表
    code, body = db_list(base, '账号表')
    try:
        j = json.loads(body)
        ok = j.get('state') == 0 and isinstance(j.get('data'), list)
        t('账号表读取', code == 200 and ok, f'state={j.get("state")} 行数={len(j.get("data", []))}')
    except Exception:
        t('账号表读取', False, body[:80].decode('utf8','replace'))

    # 5. 登录账号表
    code, body = db_list(base, '登录账号')
    try:
        j = json.loads(body)
        ok = j.get('state') == 0
        t('登录账号读取', code == 200 and ok, f'state={j.get("state")} 行数={len(j.get("data", []))}')
    except Exception:
        t('登录账号读取', False, body[:80].decode('utf8','replace'))

    # 6. 本地账号储存
    code, body = db_list(base, '本地账号储存')
    try:
        j = json.loads(body)
        ok = j.get('state') == 0
        t('本地账号读取', code == 200 and ok, f'state={j.get("state")} 行数={len(j.get("data", []))}')
    except Exception:
        t('本地账号读取', False, body[:80].decode('utf8','replace'))

    # 7. 日志上报
    code, body = http(base + '/log', 'POST', b'{"m":"e2e-test"}')
    t('日志上报', code == 200 and body == b'ok', body.decode('utf8','replace'))

    # 8. 文件读取
    code, body = http(base + '/file/take_line', 'POST', json.dumps({'path': 'data/千粉.txt'}).encode())
    t('文件读取', code == 200, body[:60].decode('utf8','replace'))

    # 9. 目录列表
    code, body = http(base + '/directory/list', 'POST', json.dumps({'path': '.'}).encode())
    t('目录列表', code == 200, body[:60].decode('utf8','replace'))

    print('\n' + '=' * 50)
    passed = sum(1 for _, s, _ in results if s == 'PASS')
    print(f'结果: {passed}/{len(results)} 通过')
    print('=' * 50)
    sys.exit(0 if passed == len(results) else 1)

if __name__ == '__main__':
    main()
