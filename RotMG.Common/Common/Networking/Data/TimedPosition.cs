using System;
using RotMG.Common.Networking.IO;

namespace RotMG.Common.Networking.Data
{
	// Token: 0x02000050 RID: 80
	[DataType]
	public struct TimedPosition
	{
		// Token: 0x06000275 RID: 629 RVA: 0x00008EE0 File Offset: 0x000070E0
		public TimedPosition(int time, float x, float y)
		{
			this.Time = time;
			this.X = x;
			this.Y = y;
		}

		// Token: 0x06000276 RID: 630 RVA: 0x00008EF7 File Offset: 0x000070F7
		public TimedPosition(int time, Position pos)
		{
			this.Time = time;
			this.X = pos.X;
			this.Y = pos.Y;
		}

		// Token: 0x06000277 RID: 631 RVA: 0x00008FE9 File Offset: 0x000071E9
		public static void InitIO()
		{
			DataTypeIO.Init<TimedPosition>(delegate(InitDataTypeIO<TimedPosition> init)
			{
				init.Field<int>((TimedPosition p) => p.Time, FieldType.Int32).Field<float>((TimedPosition p) => p.X, FieldType.Float32).Field<float>((TimedPosition p) => p.Y, FieldType.Float32)
					.End();
			});
		}

		// Token: 0x06000278 RID: 632 RVA: 0x0000900D File Offset: 0x0000720D
		public override string ToString()
		{
			return string.Format("({0}: {1},{2})", this.Time, this.X, this.Y);
		}

		// Token: 0x040001D5 RID: 469
		public int Time;

		// Token: 0x040001D6 RID: 470
		public float X;

		// Token: 0x040001D7 RID: 471
		public float Y;
	}
}
