using System;
using System.Collections.Generic;

namespace RotMG.Common
{
	// Token: 0x02000014 RID: 20
	public struct DictionaryAccessor<TKey, TValue>
	{
		// Token: 0x06000093 RID: 147 RVA: 0x000036D5 File Offset: 0x000018D5
		public DictionaryAccessor(Dictionary<TKey, TValue> dictionary)
		{
			this.dictionary = dictionary;
		}

		// Token: 0x1700002F RID: 47
		public TValue this[TKey key]
		{
			get
			{
				return this.dictionary[key];
			}
		}

		// Token: 0x06000095 RID: 149 RVA: 0x000036EC File Offset: 0x000018EC
		public bool TryGetValue(TKey key, out TValue value)
		{
			return this.dictionary.TryGetValue(key, out value);
		}

		// Token: 0x04000042 RID: 66
		private readonly Dictionary<TKey, TValue> dictionary;
	}
}
