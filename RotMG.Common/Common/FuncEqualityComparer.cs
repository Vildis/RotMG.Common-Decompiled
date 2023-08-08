using System;
using System.Collections.Generic;

namespace RotMG.Common
{
	// Token: 0x0200002D RID: 45
	public class FuncEqualityComparer<T> : IEqualityComparer<T>
	{
		// Token: 0x06000183 RID: 387 RVA: 0x00005DD8 File Offset: 0x00003FD8
		public FuncEqualityComparer(Func<T, T, bool> comparison, Func<T, int> hashCode)
		{
			this.comparison = comparison;
			this.hashCode = hashCode;
		}

		// Token: 0x06000184 RID: 388 RVA: 0x00005DEE File Offset: 0x00003FEE
		public bool Equals(T x, T y)
		{
			return this.comparison(x, y);
		}

		// Token: 0x06000185 RID: 389 RVA: 0x00005DFD File Offset: 0x00003FFD
		public int GetHashCode(T obj)
		{
			return this.hashCode(obj);
		}

		// Token: 0x0400013F RID: 319
		private readonly Func<T, T, bool> comparison;

		// Token: 0x04000140 RID: 320
		private readonly Func<T, int> hashCode;
	}
}
