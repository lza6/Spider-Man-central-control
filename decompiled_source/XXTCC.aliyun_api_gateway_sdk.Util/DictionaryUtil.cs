using System.Collections.Generic;

namespace XXTCC.aliyun_api_gateway_sdk.Util;

public class DictionaryUtil
{
	public DictionaryUtil()
	{
		Class14.QwnfEIbzxvDCI();
		base._002Ector();
	}

	public static void Add<T>(Dictionary<string, string> dic, string key, T value)
	{
		if (value != null)
		{
			if (dic == null)
			{
				dic = new Dictionary<string, string>();
			}
			else if (dic.ContainsKey(key))
			{
				dic.Remove(key);
			}
			dic.Add(key, value.ToString());
		}
	}

	public static string Get(Dictionary<string, string> dic, string key)
	{
		if (dic.ContainsKey(key))
		{
			return dic[key];
		}
		return null;
	}

	public static string Pop(Dictionary<string, string> dic, string key)
	{
		string result = null;
		if (dic.ContainsKey(key))
		{
			result = dic[key];
			dic.Remove(key);
		}
		return result;
	}
}
