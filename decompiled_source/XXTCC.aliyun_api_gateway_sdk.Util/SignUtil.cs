using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace XXTCC.aliyun_api_gateway_sdk.Util;

public class SignUtil
{
	public SignUtil()
	{
		Class14.QwnfEIbzxvDCI();
		base._002Ector();
	}

	public static string Sign(string path, string method, string secret, Dictionary<string, string> headers, Dictionary<string, string> querys, Dictionary<string, string> bodys, List<string> signHeaderPrefixList)
	{
		using KeyedHashAlgorithm keyedHashAlgorithm = KeyedHashAlgorithm.Create("HMACSHA256");
		keyedHashAlgorithm.Key = Encoding.UTF8.GetBytes(secret.ToCharArray());
		string text = smethod_0(path, method, headers, querys, bodys, signHeaderPrefixList);
		return Convert.ToBase64String(keyedHashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(text.ToCharArray())));
	}

	private static string smethod_0(string string_0, string string_1, Dictionary<string, string> dictionary_0, Dictionary<string, string> dictionary_1, Dictionary<string, string> dictionary_2, List<string> list_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(string_1.ToUpper()).Append("\n");
		if (dictionary_0.ContainsKey("Accept") && dictionary_0["Accept"] != null)
		{
			stringBuilder.Append(dictionary_0["Accept"]);
		}
		stringBuilder.Append("\n");
		if (dictionary_0.ContainsKey("Content-MD5") && dictionary_0["Content-MD5"] != null)
		{
			stringBuilder.Append(dictionary_0["Content-MD5"]);
		}
		stringBuilder.Append("\n");
		if (dictionary_0.ContainsKey("Content-Type") && dictionary_0["Content-Type"] != null)
		{
			stringBuilder.Append(dictionary_0["Content-Type"]);
		}
		stringBuilder.Append("\n");
		if (dictionary_0.ContainsKey("Date") && dictionary_0["Date"] != null)
		{
			stringBuilder.Append(dictionary_0["Date"]);
		}
		stringBuilder.Append("\n");
		stringBuilder.Append(YgjXuJgq0(dictionary_0, list_0));
		stringBuilder.Append(smethod_1(string_0, dictionary_1, dictionary_2));
		return stringBuilder.ToString();
	}

	private static string smethod_1(string string_0, Dictionary<string, string> dictionary_0, Dictionary<string, string> dictionary_1)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (string_0 != null)
		{
			stringBuilder.Append(string_0);
		}
		StringBuilder stringBuilder2 = new StringBuilder();
		IDictionary<string, string> dictionary = new SortedDictionary<string, string>(StringComparer.Ordinal);
		if (dictionary_0 != null && dictionary_0.Count > 0)
		{
			foreach (KeyValuePair<string, string> item in dictionary_0)
			{
				if (0 < item.Key.Length)
				{
					dictionary.Add(item.Key, item.Value);
				}
			}
		}
		if (dictionary_1 != null && dictionary_1.Count > 0)
		{
			foreach (KeyValuePair<string, string> item2 in dictionary_1)
			{
				if (0 < item2.Key.Length)
				{
					dictionary.Add(item2.Key, item2.Value);
				}
			}
		}
		foreach (KeyValuePair<string, string> item3 in dictionary)
		{
			if (0 < item3.Key.Length)
			{
				if (0 < stringBuilder2.Length)
				{
					stringBuilder2.Append("&");
				}
				stringBuilder2.Append(item3.Key);
				if (!string.IsNullOrEmpty(item3.Value))
				{
					stringBuilder2.Append("=").Append(item3.Value);
				}
			}
		}
		if (0 < stringBuilder2.Length)
		{
			stringBuilder.Append("?").Append(stringBuilder2);
		}
		return stringBuilder.ToString();
	}

	private static string YgjXuJgq0(Dictionary<string, string> dictionary_0, List<string> list_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (list_0 != null)
		{
			list_0.Remove("X-Ca-Signature");
			list_0.Remove("X-Ca-Signature-Headers");
			list_0.Remove("Accept");
			list_0.Remove("Content-MD5");
			list_0.Remove("Content-Type");
			list_0.Remove("Date");
			list_0.Sort(StringComparer.Ordinal);
		}
		if (dictionary_0 != null)
		{
			IDictionary<string, string> dictionary = new SortedDictionary<string, string>(dictionary_0, StringComparer.Ordinal);
			StringBuilder stringBuilder2 = new StringBuilder();
			foreach (KeyValuePair<string, string> item in dictionary)
			{
				if (smethod_2(item.Key, list_0))
				{
					stringBuilder.Append(item.Key).Append(":");
					if (item.Value != null)
					{
						stringBuilder.Append(item.Value);
					}
					stringBuilder.Append("\n");
					if (0 < stringBuilder2.Length)
					{
						stringBuilder2.Append(",");
					}
					stringBuilder2.Append(item.Key);
				}
			}
			dictionary_0.Add("X-Ca-Signature-Headers", stringBuilder2.ToString());
		}
		return stringBuilder.ToString();
	}

	private static bool smethod_2(string string_0, List<string> list_0)
	{
		if (string.IsNullOrEmpty(string_0))
		{
			return false;
		}
		if (string_0.StartsWith("X-Ca-"))
		{
			return true;
		}
		if (list_0 != null)
		{
			foreach (string item in list_0)
			{
				if (string_0.StartsWith(item))
				{
					return true;
				}
			}
		}
		return false;
	}
}
