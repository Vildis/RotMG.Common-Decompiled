using System;
using RotMG.Common.Networking.IO;

namespace RotMG.Common.Networking.Data
{
	// Token: 0x02000013 RID: 19
	[DataType]
	public struct InventorySlot
	{
		// Token: 0x06000091 RID: 145 RVA: 0x000036B1 File Offset: 0x000018B1
		public static void InitIO()
		{
			DataTypeIO.Init<InventorySlot>(delegate(InitDataTypeIO<InventorySlot> init)
			{
				init.Field<int>((InventorySlot p) => p.ObjectId, FieldType.Int32).Field<byte>((InventorySlot p) => p.SlotId, FieldType.Byte).Field<short>((InventorySlot p) => p.ItemType, FieldType.Int16)
					.End();
			});
		}

		// Token: 0x0400003E RID: 62
		public int ObjectId;

		// Token: 0x0400003F RID: 63
		public byte SlotId;

		// Token: 0x04000040 RID: 64
		public short ItemType;
	}
}
