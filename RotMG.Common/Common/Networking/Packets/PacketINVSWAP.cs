using System;
using RotMG.Common.Networking.Data;
using RotMG.Common.Networking.IO;

namespace RotMG.Common.Networking.Packets
{
	// Token: 0x02000042 RID: 66
	public class PacketINVSWAP : Packet
	{
		// Token: 0x17000086 RID: 134
		// (get) Token: 0x060001F7 RID: 503 RVA: 0x000071ED File Offset: 0x000053ED
		public override PacketId Id
		{
			get
			{
				return PacketId.INVSWAP;
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x060001F8 RID: 504 RVA: 0x000071F1 File Offset: 0x000053F1
		// (set) Token: 0x060001F9 RID: 505 RVA: 0x000071F9 File Offset: 0x000053F9
		public int Time { get; set; }

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x060001FA RID: 506 RVA: 0x00007202 File Offset: 0x00005402
		// (set) Token: 0x060001FB RID: 507 RVA: 0x0000720A File Offset: 0x0000540A
		public Position Position { get; set; }

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060001FC RID: 508 RVA: 0x00007213 File Offset: 0x00005413
		// (set) Token: 0x060001FD RID: 509 RVA: 0x0000721B File Offset: 0x0000541B
		public InventorySlot SlotA { get; set; }

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x060001FE RID: 510 RVA: 0x00007224 File Offset: 0x00005424
		// (set) Token: 0x060001FF RID: 511 RVA: 0x0000722C File Offset: 0x0000542C
		public InventorySlot SlotB { get; set; }

		// Token: 0x06000200 RID: 512 RVA: 0x0000735E File Offset: 0x0000555E
		public static void InitIO()
		{
			DataTypeIO.Init<PacketINVSWAP>(delegate(InitDataTypeIO<PacketINVSWAP> init)
			{
				init.Field<int>((PacketINVSWAP p) => p.Time, FieldType.Int32).Field<Position>((PacketINVSWAP p) => p.Position, FieldType.DataType).Field<InventorySlot>((PacketINVSWAP p) => p.SlotA, FieldType.DataType)
					.Field<InventorySlot>((PacketINVSWAP p) => p.SlotB, FieldType.DataType)
					.End();
			});
		}
	}
}
