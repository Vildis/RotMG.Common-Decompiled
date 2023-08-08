using System;
using RotMG.Common.Networking.IO;

namespace RotMG.Common.Networking.Data
{
	// Token: 0x02000023 RID: 35
	[DataType]
	public struct ObjectStats
	{
		// Token: 0x06000140 RID: 320 RVA: 0x0000542F File Offset: 0x0000362F
		public static void InitIO()
		{
			DataTypeIO.Init<ObjectStats>(delegate(InitDataTypeIO<ObjectStats> init)
			{
				init.Field<int>((ObjectStats p) => p.Id, FieldType.Int32).Field<Position>((ObjectStats p) => p.Position, FieldType.DataType).Field<StatEntry[]>((ObjectStats p) => p.StatsEntries, FieldType.DataArray)
					.End();
			});
		}

		// Token: 0x0400011F RID: 287
		public int Id;

		// Token: 0x04000120 RID: 288
		public Position Position;

		// Token: 0x04000121 RID: 289
		public StatEntry[] StatsEntries;
	}
}
