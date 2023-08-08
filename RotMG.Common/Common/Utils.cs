using System;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;

namespace RotMG.Common
{
	// Token: 0x02000004 RID: 4
	public static class Utils
	{
		// Token: 0x06000007 RID: 7 RVA: 0x000020DC File Offset: 0x000002DC
		public static void Swap<T>(ref T a, ref T b)
		{
			T t = a;
			a = b;
			b = t;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002104 File Offset: 0x00000304
		public static int ToUnixTimestamp(this DateTime dt)
		{
			return (int)(dt.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002138 File Offset: 0x00000338
		public static bool IsValidEmail(string email)
		{
			bool flag;
			try
			{
				MailAddress mailAddress = new MailAddress(email);
				flag = mailAddress.Address == email;
			}
			catch
			{
				flag = false;
			}
			return flag;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002174 File Offset: 0x00000374
		public static T Convert<T>(this string value)
		{
			return (T)((object)TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(value));
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000021A0 File Offset: 0x000003A0
		public static T[] FromCSV<T>(this string csv)
		{
			return (from value in csv.Split(new char[] { ',' })
				select value.Trim().Convert<T>()).ToArray<T>();
		}
	}
}
