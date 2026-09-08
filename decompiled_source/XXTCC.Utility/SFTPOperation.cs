using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Renci.SshNet;
using Renci.SshNet.Sftp;

namespace XXTCC.Utility;

public class SFTPOperation
{
	private SftpClient sftpClient_0;

	private SshClient sshClient_0;

	public bool Connected => ((BaseClient)sftpClient_0).IsConnected;

	public string Execute(string command)
	{
		string result;
		try
		{
			if (!((BaseClient)sshClient_0).IsConnected)
			{
				((BaseClient)sshClient_0).Connect();
			}
			string text = sshClient_0.CreateCommand(command).Execute();
			if (sshClient_0 != null && ((BaseClient)sshClient_0).IsConnected)
			{
				((BaseClient)sshClient_0).Disconnect();
			}
			result = text;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public SFTPOperation(string ip, string port, string user, string pwd)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		Class14.QwnfEIbzxvDCI();
		base._002Ector();
		sftpClient_0 = new SftpClient(ip, int.Parse(port), user, pwd);
		sshClient_0 = new SshClient(ip, int.Parse(port), user, pwd);
		sftpClient_0.OperationTimeout = new TimeSpan(0, 1, 0);
	}

	public string Connect()
	{
		string result;
		try
		{
			if (!Connected)
			{
				((BaseClient)sftpClient_0).Connect();
			}
			result = null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			result = ex2.Message;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void Disconnect()
	{
		try
		{
			if (sftpClient_0 != null && Connected)
			{
				((BaseClient)sftpClient_0).Disconnect();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new Exception($"断开SFTP失败，原因：{ex2.Message}");
		}
	}

	public string Put(string localPath, string remotePath)
	{
		try
		{
			Connect();
			using (FileStream fileStream = File.OpenRead(localPath))
			{
				sftpClient_0.UploadFile((Stream)fileStream, remotePath, true, (Action<ulong>)null);
			}
			Disconnect();
			return null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new Exception($"SFTP文件上传失败，原因：{ex2.Message}");
		}
	}

	public string Put(FileStream localfile, string remotePath)
	{
		try
		{
			Connect();
			sftpClient_0.UploadFile((Stream)localfile, remotePath, (Action<ulong>)null);
			Disconnect();
			return null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new Exception($"SFTP文件上传失败，原因：{ex2.Message}");
		}
	}

	public string Put(byte[] localbyte, string remotePath)
	{
		try
		{
			Connect();
			using (Stream stream = new MemoryStream(localbyte))
			{
				sftpClient_0.BeginUploadFile(stream, remotePath);
			}
			Disconnect();
			return null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new Exception($"SFTP文件上传失败，原因：{ex2.Message}");
		}
	}

	public string Write(byte[] localbyte, string remotePath)
	{
		try
		{
			Connect();
			using (new MemoryStream(localbyte))
			{
				sftpClient_0.WriteAllBytes(remotePath, localbyte);
			}
			Disconnect();
			return null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new Exception($"SFTP文件上传失败，原因：{ex2.Message}");
		}
	}

	public string EditAuthority(string remotePath)
	{
		string result;
		try
		{
			Connect();
			List<SftpFile> list = (List<SftpFile>)sftpClient_0.ListDirectory(remotePath, (Action<int>)null);
			Disconnect();
			foreach (SftpFile item in list)
			{
				if (DateAndTime.DateDiff("s", item.LastAccessTime, DateAndTime.Now) < 30L)
				{
					Execute("chown -R mobile:mobile /var/mobile/Applications/" + item.Name + ";chmod -R 755 /var/mobile/Applications/" + item.Name);
					item.SetPermissions((short)755);
				}
			}
			result = null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			result = ex2.Message;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void Get(string remotePath, string localPath)
	{
		try
		{
			Connect();
			byte[] bytes = sftpClient_0.ReadAllBytes(remotePath);
			Disconnect();
			File.WriteAllBytes(localPath, bytes);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new Exception($"SFTP文件获取失败，原因：{ex2.Message}");
		}
	}

	public object Delete(string remoteFile)
	{
		try
		{
			Connect();
			if (sftpClient_0.Exists(remoteFile))
			{
				sftpClient_0.Delete(remoteFile);
			}
			Disconnect();
			return null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new Exception($"SFTP文件删除失败，原因：{ex2.Message}");
		}
	}

	public ArrayList GetFileList(string remotePath, string fileSuffix)
	{
		checked
		{
			try
			{
				Connect();
				SftpFile[] obj = (SftpFile[])sftpClient_0.ListDirectory(remotePath, (Action<int>)null);
				Disconnect();
				ArrayList arrayList = new ArrayList();
				SftpFile[] array = obj;
				for (int i = 0; i < array.Length; i++)
				{
					string name = array[i].Name;
					if (name.Length > fileSuffix.Length + 1 && Operators.CompareString(fileSuffix, name.Substring(name.Length - fileSuffix.Length), TextCompare: false) == 0)
					{
						arrayList.Add(name);
					}
				}
				return arrayList;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				throw new Exception($"SFTP文件列表获取失败，原因：{ex2.Message}");
			}
		}
	}

	public void Move(string oldRemotePath, string newRemotePath)
	{
		try
		{
			Connect();
			sftpClient_0.RenameFile(oldRemotePath, newRemotePath);
			Disconnect();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new Exception($"SFTP文件移动失败，原因：{ex2.Message}");
		}
	}
}
