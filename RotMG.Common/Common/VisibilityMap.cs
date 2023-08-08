using System;
using System.Collections;

namespace RotMG.Common
{
	// Token: 0x02000003 RID: 3
	public class VisibilityMap
	{
		// Token: 0x06000004 RID: 4 RVA: 0x00002088 File Offset: 0x00000288
		public VisibilityMap(int w, int h)
		{
			this.bitmap = new BitArray(w * h);
			this.w = w;
			this.h = h;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000020AC File Offset: 0x000002AC
		public bool IsSet(int x, int y)
		{
			return this.bitmap[y * this.w + x];
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000020C3 File Offset: 0x000002C3
		public void Set(int x, int y, bool value)
		{
			this.bitmap[y * this.w + x] = value;
		}

		// Token: 0x04000001 RID: 1
		private readonly BitArray bitmap;

		// Token: 0x04000002 RID: 2
		private readonly int w;

		// Token: 0x04000003 RID: 3
		private readonly int h;
	}
}
