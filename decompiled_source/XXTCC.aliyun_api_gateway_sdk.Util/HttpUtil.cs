using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using Microsoft.VisualBasic.CompilerServices;

namespace XXTCC.aliyun_api_gateway_sdk.Util;

public class HttpUtil
{
	public HttpUtil()
	{
		Class14.QwnfEIbzxvDCI();
		base._002Ector();
	}

	public static HttpWebResponse HttpPost(string host, string path, string appKey, string appSecret, int timeout, Dictionary<string, string> headers, Dictionary<string, string> querys, Dictionary<string, string> bodys, List<string> signHeaderPrefixList)
	{
		return smethod_0(host, path, "POST", appKey, appSecret, timeout, headers, querys, bodys, signHeaderPrefixList);
	}

	public static HttpWebResponse HttpPut(string host, string path, string appKey, string appSecret, int timeout, Dictionary<string, string> headers, Dictionary<string, string> querys, Dictionary<string, string> bodys, List<string> signHeaderPrefixList)
	{
		return smethod_0(host, path, "PUT", appKey, appSecret, timeout, headers, querys, bodys, signHeaderPrefixList);
	}

	public static HttpWebResponse HttpGet(string host, string path, string appKey, string appSecret, int timeout, Dictionary<string, string> headers, Dictionary<string, string> querys, List<string> signHeaderPrefixList)
	{
		return smethod_0(host, path, "GET", appKey, appSecret, timeout, headers, querys, null, signHeaderPrefixList);
	}

	public static HttpWebResponse HttpHead(string host, string path, string appKey, string appSecret, int timeout, Dictionary<string, string> headers, Dictionary<string, string> querys, List<string> signHeaderPrefixList)
	{
		return smethod_0(host, path, "HEAD", appKey, appSecret, timeout, headers, querys, null, signHeaderPrefixList);
	}

	public static HttpWebResponse HttpDelete(string host, string path, string appKey, string appSecret, int timeout, Dictionary<string, string> headers, Dictionary<string, string> querys, List<string> signHeaderPrefixList)
	{
		return smethod_0(host, path, "DELETE", appKey, appSecret, timeout, headers, querys, null, signHeaderPrefixList);
	}

	private static HttpWebResponse smethod_0(string string_0, string string_1, string string_2, string string_3, string string_4, int int_0, Dictionary<string, string> dictionary_0, Dictionary<string, string> dictionary_1, Dictionary<string, string> dictionary_2, List<string> list_0)
	{
		dictionary_0 = aiijJdkHl(string_1, string_3, string_4, string_2, dictionary_0, dictionary_1, dictionary_2, list_0);
		HttpWebRequest httpWebRequest = smethod_2(string_0, string_1, string_2, int_0, dictionary_0, dictionary_1);
		if (dictionary_2 != null && 0 < dictionary_2.Count)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (KeyValuePair<string, string> item in dictionary_2)
			{
				if (0 < stringBuilder.Length)
				{
					stringBuilder.Append("&");
				}
				if (item.Value != null && item.Key.Length == 0)
				{
					stringBuilder.Append(item.Value);
				}
				if (0 < item.Key.Length)
				{
					stringBuilder.Append(item.Key).Append("=");
					if (item.Value != null)
					{
						stringBuilder.Append(HttpUtility.UrlEncode(item.Value, Encoding.UTF8));
					}
				}
			}
			byte[] bytes = Encoding.UTF8.GetBytes(stringBuilder.ToString());
			using Stream stream = httpWebRequest.GetRequestStream();
			stream.Write(bytes, 0, bytes.Length);
		}
		return smethod_1(httpWebRequest);
	}

	private static HttpWebResponse smethod_1(HttpWebRequest httpWebRequest_0)
	{
		HttpWebResponse httpWebResponse = null;
		try
		{
			httpWebResponse = (HttpWebResponse)httpWebRequest_0.GetResponse();
		}
		catch (WebException ex)
		{
			ProjectData.SetProjectError(ex);
			WebException ex2 = ex;
			httpWebResponse = (HttpWebResponse)ex2.Response;
			ProjectData.ClearProjectError();
		}
		return httpWebResponse;
	}

	private static HttpWebRequest smethod_2(string string_0, string string_1, string string_2, int int_0, Dictionary<string, string> dictionary_0, Dictionary<string, string> dictionary_1)
	{
		HttpWebRequest httpWebRequest = null;
		string text = string_0;
		if (string_1 != null)
		{
			text += string_1;
		}
		if (dictionary_1 != null && 0 < dictionary_1.Count)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (KeyValuePair<string, string> item in dictionary_1)
			{
				if (0 < stringBuilder.Length)
				{
					stringBuilder.Append("&");
				}
				if (item.Value != null && item.Key == null)
				{
					stringBuilder.Append(item.Value);
				}
				if (item.Key != null)
				{
					stringBuilder.Append(item.Key).Append("=");
					if (item.Value != null)
					{
						stringBuilder.Append(HttpUtility.UrlEncode(item.Value, Encoding.UTF8));
					}
				}
			}
			if (0 < stringBuilder.Length)
			{
				text = text + "?" + stringBuilder.ToString();
			}
		}
		if (string_0.Contains("https://"))
		{
			ServicePointManager.ServerCertificateValidationCallback = CheckValidationResult;
			httpWebRequest = (HttpWebRequest)WebRequest.CreateDefault(new Uri(text));
		}
		else
		{
			httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
		}
		httpWebRequest.ServicePoint.Expect100Continue = false;
		httpWebRequest.Method = string_2;
		httpWebRequest.KeepAlive = true;
		httpWebRequest.Timeout = int_0;
		if (dictionary_0.ContainsKey("Accept"))
		{
			httpWebRequest.Accept = DictionaryUtil.Pop(dictionary_0, "Accept");
		}
		if (dictionary_0.ContainsKey("Date"))
		{
			httpWebRequest.Date = Convert.ToDateTime(DictionaryUtil.Pop(dictionary_0, "Date"));
		}
		if (dictionary_0.ContainsKey("Content-Type"))
		{
			httpWebRequest.ContentType = DictionaryUtil.Pop(dictionary_0, "Content-Type");
		}
		foreach (KeyValuePair<string, string> item2 in dictionary_0)
		{
			httpWebRequest.Headers.Add(item2.Key, item2.Value);
		}
		return httpWebRequest;
	}

	private static Dictionary<string, string> aiijJdkHl(string string_0, string string_1, string string_2, string string_3, Dictionary<string, string> dictionary_0, Dictionary<string, string> dictionary_1, Dictionary<string, string> dictionary_2, List<string> list_0)
	{
		if (dictionary_0 == null)
		{
			dictionary_0 = new Dictionary<string, string>();
		}
		new StringBuilder();
		dictionary_0.Add("X-Ca-Timestamp", DateUtil.ConvertDateTimeInt(DateTime.Now).ToString());
		dictionary_0.Add("X-Ca-Nonce", Guid.NewGuid().ToString());
		dictionary_0.Add("X-Ca-Key", string_1);
		dictionary_0.Add("X-Ca-Signature", SignUtil.Sign(string_0, string_3, string_2, dictionary_0, dictionary_1, dictionary_2, list_0));
		return dictionary_0;
	}

	public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
	{
		return true;
	}
}
