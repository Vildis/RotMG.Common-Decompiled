using System;
using System.Xml.Linq;

namespace RotMG.Common
{
	// Token: 0x02000002 RID: 2
	public static class XLinqExtensions
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static bool Exists(this XElement elem, string elemName)
		{
			return elem.Element(elemName) != null;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002064 File Offset: 0x00000264
		public static T ValueOrDefault<T>(this XElement elem, T defValue)
		{
			if (elem == null)
			{
				return defValue;
			}
			return elem.Value.Convert<T>();
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002076 File Offset: 0x00000276
		public static T ValueOrDefault<T>(this XAttribute attr, T defValue)
		{
			if (attr == null)
			{
				return defValue;
			}
			return attr.Value.Convert<T>();
		}
	}
}
