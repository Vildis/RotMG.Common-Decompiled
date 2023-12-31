﻿using System;

namespace RotMG.Common
{
	// Token: 0x02000040 RID: 64
	public class NormDist
	{
		// Token: 0x060001EA RID: 490 RVA: 0x00006F44 File Offset: 0x00005144
		public NormDist(float stdev, float mean, float min, float max, int? seed = null)
		{
			this.stdev = stdev;
			this.mean = mean;
			this.min = min;
			this.max = max;
			if (seed != null)
			{
				this.random = new Random(seed.Value);
				return;
			}
			this.random = new Random();
		}

		// Token: 0x060001EB RID: 491 RVA: 0x00006F9C File Offset: 0x0000519C
		private double NextValueInternal()
		{
			if (this.nextNum != null)
			{
				double value = this.nextNum.Value;
				this.nextNum = null;
				return value;
			}
			double num;
			double num2;
			double num3;
			do
			{
				num = this.random.NextDouble() * 2.0 - 1.0;
				num2 = this.random.NextDouble() * 2.0 - 1.0;
				num3 = num * num + num2 * num2;
			}
			while (num3 >= 1.0);
			this.nextNum = new double?(num * Math.Sqrt(-2.0 * Math.Log(num3) / num3));
			return num2 * Math.Sqrt(-2.0 * Math.Log(num3) / num3);
		}

		// Token: 0x060001EC RID: 492 RVA: 0x00007064 File Offset: 0x00005264
		public double NextValue()
		{
			double num = this.NextValueInternal() * (double)this.stdev + (double)this.mean;
			if (num < (double)this.min)
			{
				num = (double)this.min;
			}
			if (num > (double)this.max)
			{
				num = (double)this.max;
			}
			return num;
		}

		// Token: 0x0400018C RID: 396
		private readonly float stdev;

		// Token: 0x0400018D RID: 397
		private readonly float mean;

		// Token: 0x0400018E RID: 398
		private readonly float max;

		// Token: 0x0400018F RID: 399
		private readonly float min;

		// Token: 0x04000190 RID: 400
		private readonly Random random;

		// Token: 0x04000191 RID: 401
		private double? nextNum;
	}
}
