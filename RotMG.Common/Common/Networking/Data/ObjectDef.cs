using System;
using RotMG.Common.Networking.IO;

namespace RotMG.Common.Networking.Data
{
	// Token: 0x02000005 RID: 5
	[DataType]
	public struct ObjectDef
	{
		// Token: 0x0600000D RID: 13 RVA: 0x00002264 File Offset: 0x00000464
		public static void InitIO()
		{
			DataTypeIO.Init<ObjectDef>(delegate(InitDataTypeIO<ObjectDef> init)
			{
				init.Field<ushort>((ObjectDef p) => p.ObjectType, FieldType.Int16).Field<ObjectStats>((ObjectDef p) => p.Stats, FieldType.DataType).End();
			});
		}

		// Token: 0x04000004 RID: 4
		public ushort ObjectType;

		// Token: 0x04000005 RID: 5
		public ObjectStats Stats;
	}
}
