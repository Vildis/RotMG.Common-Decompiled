using System;
using System.Collections.Generic;

namespace RotMG.Common
{
	// Token: 0x02000034 RID: 52
	public static class DictionaryExtensions
	{
		// Token: 0x060001A4 RID: 420 RVA: 0x00006188 File Offset: 0x00004388
		public static TValue GetValueOrCreate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> creationFunc)
		{
			TValue tvalue;
			if (!dictionary.TryGetValue(key, out tvalue))
			{
				tvalue = creationFunc(key);
				dictionary.Add(key, tvalue);
			}
			return tvalue;
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x000061C4 File Offset: 0x000043C4
		public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
		{
			return dictionary.GetValueOrDefault(key, (TKey _) => defaultValue);
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x000061F4 File Offset: 0x000043F4
		public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> defaultFunc)
		{
			TValue tvalue;
			if (!dictionary.TryGetValue(key, out tvalue))
			{
				return defaultFunc(key);
			}
			return tvalue;
		}
	}
}
