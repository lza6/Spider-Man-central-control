using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace XXTCC.aliyun_api_gateway_sdk.Util;

public class MessageDigestUtil
{
	public MessageDigestUtil()
	{
		Class14.QwnfEIbzxvDCI();
		base._002Ector();
	}

	public static string Base64AndMD5(string input)
	{
		if (input == null || input.Length == 0)
		{
			throw new Exception("input can not be null");
		}
		return Base64AndMD5(Encoding.UTF8.GetBytes(input));
	}

	public static string Base64AndMD5(byte[] bytes)
	{
		return Convert.ToBase64String(new MD5CryptoServiceProvider().ComputeHash(bytes));
	}

	public static string Utf8ToIso88591(string input)
	{
		string result;
		if (input == null)
		{
			result = input;
		}
		else
		{
			try
			{
				result = Encoding.Default.GetString(Encoding.Convert(Encoding.UTF8, Encoding.GetEncoding("ISO-8859-1"), Encoding.UTF8.GetBytes(input)));
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				result = input;
				ProjectData.ClearProjectError();
			}
		}
		return result;
	}
}
