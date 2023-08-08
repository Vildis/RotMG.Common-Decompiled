using System;
using RotMG.Common.Networking.Data;
using RotMG.Common.Networking.IO;

namespace RotMG.Common.Networking.Packets
{
	// Token: 0x02000041 RID: 65
	public class PacketNEW_TICK : Packet
	{
		// Token: 0x17000082 RID: 130
		// (get) Token: 0x060001ED RID: 493 RVA: 0x000070AD File Offset: 0x000052AD
		public override PacketId Id
		{
			get
			{
				return PacketId.NEW_TICK;
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x060001EE RID: 494 RVA: 0x000070B0 File Offset: 0x000052B0
		// (set) Token: 0x060001EF RID: 495 RVA: 0x000070B8 File Offset: 0x000052B8
		public int TickId { get; set; }

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x060001F0 RID: 496 RVA: 0x000070C1 File Offset: 0x000052C1
		// (set) Token: 0x060001F1 RID: 497 RVA: 0x000070C9 File Offset: 0x000052C9
		public int TickTime { get; set; }

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x060001F2 RID: 498 RVA: 0x000070D2 File Offset: 0x000052D2
		// (set) Token: 0x060001F3 RID: 499 RVA: 0x000070DA File Offset: 0x000052DA
		public ObjectStats[] Statuses { get; set; }

		// Token: 0x060001F4 RID: 500 RVA: 0x000071C1 File Offset: 0x000053C1
		public static void InitIO()
		{
			DataTypeIO.Init<PacketNEW_TICK>(delegate(InitDataTypeIO<PacketNEW_TICK> init)
			{
				init.Field<int>((PacketNEW_TICK p) => p.TickId, FieldType.Int32).Field<int>((PacketNEW_TICK p) => p.TickTime, FieldType.Int32).Field<ObjectStats[]>((PacketNEW_TICK p) => p.Statuses, FieldType.DataArray)
					.End();
			});
		}
	}
}
