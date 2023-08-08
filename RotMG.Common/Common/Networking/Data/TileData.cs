using System;
using RotMG.Common.Networking.IO;

namespace RotMG.Common.Networking.Data
{
	// Token: 0x02000048 RID: 72
	[DataType]
	public struct TileData
	{
		// Token: 0x0600022D RID: 557 RVA: 0x000084C9 File Offset: 0x000066C9
		public static void InitIO()
		{
			DataTypeIO.Init<TileData>(delegate(InitDataTypeIO<TileData> init)
			{
				init.Field<short>((TileData p) => p.X, FieldType.Int16).Field<short>((TileData p) => p.Y, FieldType.Int16).Field<ushort>((TileData p) => p.TileType, FieldType.Int16)
					.End();
			});
		}

		// Token: 0x040001B1 RID: 433
		public short X;

		// Token: 0x040001B2 RID: 434
		public short Y;

		// Token: 0x040001B3 RID: 435
		public ushort TileType;
	}
}
