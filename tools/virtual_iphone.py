#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
蜘蛛侠中控 · 虚拟 iPhone 设备模拟器 (无真机 E2E)
=================================================
模拟 XXTouch 手机端 CC.lua 的完整行为:
  - 连接中控 27010 (探活)
  - 每 N 秒轮询 GET /getui 取任务
  - 收到任务 → 模拟执行 → POST /log 上报结果
  - 同时模拟 Set_device_name / snapshot 等设备行为

用 lupa(LuaJIT) 实际加载还原的 CC.lua 验证语法并与中控联动。
用法:
  python virtual_iphone.py [中控IP] [端口] [--lua-check]
"""
import sys, json, time, urllib.request, urllib.error, argparse

def http(url, method='GET', data=None, ctype='application/json', timeout=5):
    req = urllib.request.Request(url, method=method, data=data)
    req.add_header('Content-Type', ctype)
    try:
        r = urllib.request.urlopen(req, timeout=timeout)
        return r.status, r.read()
    except urllib.error.HTTPError as e:
        return e.code, e.read()
    except Exception as e:
        return -1, str(e).encode()

class VirtualiPhone:
    def __init__(self, host, port, device_id='00008010-000629163031803A', name='iPhoneD14'):
        self.host, self.port = host, port
        self.device_id, self.name = device_id, name
        self.base = f'http://{host}:{port}'
        self.running = True

    def connect(self):
        """CC.connect 探活"""
        try:
            import socket
            s = socket.create_connection((self.host, self.port), timeout=3)
            code, _ = http(self.base + '/', timeout=3)
            s.close()
            print(f'[connect] 中控可达: HTTP {code}')
            return True
        except Exception as e:
            print(f'[connect] 失败: {e}')
            return False

    def getui(self):
        """CC.getui 轮询任务"""
        code, body = http(self.base + '/getui')
        try:
            return json.loads(body) if code == 200 else {}
        except Exception:
            return {}

    def log(self, payload):
        """CC.log 上报"""
        code, body = http(self.base + '/log', 'POST', json.dumps(payload).encode())
        return code == 200

    def execute_task(self, task):
        """执行一个任务 (简化模拟)"""
        print(f'  [执行] 任务: {json.dumps(task, ensure_ascii=False)[:120]}')
        result = {'mode': task.get('mode', '?'), 'device': self.device_id, 'result': 'ok'}
        self.log(result)
        return result

    def handle_db(self, task):
        """模拟 db 操作"""
        db = task.get('db', '账号表')
        code, body = http(self.base + '/db/list', 'POST', json.dumps({'db': db, 'data': {}}).encode())
        try:
            data = json.loads(body).get('data', [])
            print(f'  [db] {db}: {len(data)} 行')
        except Exception:
            print(f'  [db] {db}: {body[:60]}')

    def run(self, cycles=3, interval=2):
        if not self.connect():
            print('无法连接中控, 退出'); return False
        print(f'[online] 设备上线: {self.name} ({self.device_id})\n')
        for i in range(cycles):
            print(f'== 轮询 #{i+1} ==')
            task = self.getui()
            if task:
                print(f'  收到任务: {task}')
                if 'db' in str(task):
                    self.handle_db(task)
                else:
                    self.execute_task(task)
            else:
                print('  无任务 (设备未绑定/无运行策略)')
            # 心跳上报
            self.log({'device': self.device_id, 'heartbeat': True, 'tick': i+1})
            time.sleep(interval)
        print('\n[offline] 模拟结束')
        return True

def lua_syntax_check():
    """用 lupa 验证还原的 CC.lua 语法"""
    try:
        from lupa import LuaRuntime
        lua = LuaRuntime(unpack_returned_tuples=True)
        lua.execute('http={post=function(...) return 200,"{}" end,get=function(...) return 200,"{}" end}')
        lua.execute('json={encode=function(t) return tostring(t) end,decode=function(s) return {} end}')
        lua.execute('sys={toast=function() end,alert=function() end}')
        lua.execute('socket={tcp=function() return {connect=function() return 1 end,settimeout=function() end} end}')
        # 加载 CC.lua
        with open(r'C:\Users\Administrator.DESKTOP-EGNE9ND\Desktop\公益服务网关\逆向\CC_library.lua','r',encoding='utf-8',errors='replace') as f:
            src = f.read()
        src = src.replace('\r\n','\n')
        lua.execute(src)
        print('[lua] CC.lua 语法验证: ✓ 通过 (LuaJIT)')
        return True
    except Exception as e:
        print(f'[lua] CC.lua 语法验证: ✗ {str(e)[:120]}')
        return False

def main():
    ap = argparse.ArgumentParser()
    ap.add_argument('host', nargs='?', default='127.0.0.1')
    ap.add_argument('port', nargs='?', type=int, default=27010)
    ap.add_argument('--lua-check', action='store_true')
    ap.add_argument('--cycles', type=int, default=3)
    args = ap.parse_args()
    if args.lua_check:
        lua_syntax_check()
    v = VirtualiPhone(args.host, args.port)
    v.run(cycles=args.cycles)

if __name__ == '__main__':
    main()
