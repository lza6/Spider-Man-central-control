using System;
using System.Globalization;

namespace XXTCC.aliyun_api_gateway_sdk.Util;

public class DateUtil
{
	public DateUtil()
	{
		Class14.QwnfEIbzxvDCI();
		base._002Ector();
	}

	public static string FormatIso8601Date(DateTime date)
	{
		return date.ToUniversalTime().ToString("yyyy-MM-dd'T'HH:mm:ss'Z'", CultureInfo.CreateSpecificCulture("en-US"));
	}

	public static string ConvertDateTimeInt(DateTime time)
	{
		DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
		return Convert.ToInt64((time - dateTime).TotalMilliseconds).ToString();
	}
}
