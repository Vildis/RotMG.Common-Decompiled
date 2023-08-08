using System;

namespace RotMG.Common
{
	// Token: 0x0200002C RID: 44
	public static class MathUtils
	{
		// Token: 0x06000180 RID: 384 RVA: 0x00005D86 File Offset: 0x00003F86
		public static float Lerp(float a, float b, float t)
		{
			return (1f - t) * a + t * b;
		}

		// Token: 0x06000181 RID: 385 RVA: 0x00005D98 File Offset: 0x00003F98
		public static double Distance(double x1, double y1, double x2, double y2)
		{
			double num = x1 - x2;
			double num2 = y1 - y2;
			return Math.Sqrt(num * num + num2 * num2);
		}

		// Token: 0x06000182 RID: 386 RVA: 0x00005DBC File Offset: 0x00003FBC
		public static double DistanceSquared(double x1, double y1, double x2, double y2)
		{
			double num = x1 - x2;
			double num2 = y1 - y2;
			return num * num + num2 * num2;
		}
	}
}
