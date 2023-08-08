using System;
using System.Collections.Generic;

namespace RotMG.Common
{
	// Token: 0x0200004D RID: 77
	public static class RandomExtensions
	{
		// Token: 0x0600026B RID: 619 RVA: 0x00008D60 File Offset: 0x00006F60
		public static void Shuffle<T>(this Random random, IList<T> items)
		{
			for (int i = items.Count - 1; i > 0; i--)
			{
				int num = random.Next(i + 1);
				T t = items[i];
				items[i] = items[num];
				items[num] = t;
			}
		}
	}
}
