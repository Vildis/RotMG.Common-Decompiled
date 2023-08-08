using System;
using RotMG.Common.Networking.IO;

namespace RotMG.Common.Networking.Data
{
	// Token: 0x0200000A RID: 10
	[DataType]
	public struct Position
	{
		// Token: 0x06000029 RID: 41 RVA: 0x00002567 File Offset: 0x00000767
		public Position(float x, float y)
		{
			this.X = x;
			this.Y = y;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002578 File Offset: 0x00000778
		public bool CanInteract(float x, float y)
		{
			float num = this.X - x;
			float num2 = this.Y - y;
			return num * num + num2 * num2 < 1f;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002633 File Offset: 0x00000833
		public static void InitIO()
		{
			DataTypeIO.Init<Position>(delegate(InitDataTypeIO<Position> init)
			{
				init.Field<float>((Position p) => p.X, FieldType.Float32).Field<float>((Position p) => p.Y, FieldType.Float32).End();
			});
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002657 File Offset: 0x00000857
		public override string ToString()
		{
			return string.Format("({0},{1})", this.X, this.Y);
		}

		// Token: 0x04000012 RID: 18
		public float X;

		// Token: 0x04000013 RID: 19
		public float Y;
	}
}
