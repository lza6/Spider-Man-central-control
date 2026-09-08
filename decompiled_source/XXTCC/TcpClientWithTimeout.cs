using System;
using System.Net.Sockets;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;

namespace XXTCC;

public class TcpClientWithTimeout
{
	protected string _hostname;

	protected int _port;

	protected int _timeout_milliseconds;

	protected TcpClient connection;

	protected bool connected;

	protected Exception exception;

	public TcpClientWithTimeout(string hostname, int port, int timeout_milliseconds)
	{
		Class14.QwnfEIbzxvDCI();
		base._002Ector();
		_hostname = hostname;
		_port = port;
		_timeout_milliseconds = timeout_milliseconds;
	}

	public TcpClient Connect()
	{
		connected = false;
		exception = null;
		Thread thread = new Thread(BeginConnect);
		thread.IsBackground = true;
		thread.Start();
		thread.Join(_timeout_milliseconds);
		if (!connected)
		{
			if (exception != null)
			{
				thread.Abort();
				throw exception;
			}
			thread.Abort();
			throw new TimeoutException($"TcpClient connection to {_hostname}:{_port} timed out");
		}
		thread.Abort();
		return connection;
	}

	protected void BeginConnect()
	{
		try
		{
			connection = new TcpClient(_hostname, _port);
			connected = true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			exception = ex2;
			ProjectData.ClearProjectError();
		}
	}
}
