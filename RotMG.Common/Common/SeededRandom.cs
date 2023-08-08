using System;

namespace RotMG.Common
{
	// Token: 0x0200003F RID: 63
	public class SeededRandom
	{
		// Token: 0x060001E7 RID: 487 RVA: 0x00006E91 File Offset: 0x00005091
		public SeededRandom(uint seed)
		{
			this.state = seed;
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x00006EA0 File Offset: 0x000050A0
		private uint NextState()
		{
			uint num3;
			lock (this)
			{
				uint num = 16807U * (this.state >> 16);
				uint num2 = 16807U * (this.state & 65535U);
				num2 += (num & 32767U) << 16;
				num2 += num >> 15;
				if ((num2 & 2147483648U) != 0U)
				{
					num2 = (num2 + 1U) & 2147483647U;
				}
				this.state = num2;
				num3 = this.state;
			}
			return num3;
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x00006F30 File Offset: 0x00005130
		public uint NextUInt32(uint loBound, uint hiBound)
		{
			if (hiBound == loBound)
			{
				return loBound;
			}
			return loBound + this.NextState() % (hiBound - loBound);
		}

		// Token: 0x0400018B RID: 395
		private uint state;
	}
}
