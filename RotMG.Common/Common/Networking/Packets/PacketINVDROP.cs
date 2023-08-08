using System;
using RotMG.Common.Networking.Data;
using RotMG.Common.Networking.IO;

namespace RotMG.Common.Networking.Packets
{
	// Token: 0x02000020 RID: 32
	public class PacketINVDROP : Packet
	{
		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000132 RID: 306 RVA: 0x000050F9 File Offset: 0x000032F9
		public override PacketId Id
		{
			get
			{
				return PacketId.INVDROP;
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000133 RID: 307 RVA: 0x000050FD File Offset: 0x000032FD
		// (set) Token: 0x06000134 RID: 308 RVA: 0x00005105 File Offset: 0x00003305
		public InventorySlot Slot { get; set; }

		// Token: 0x06000135 RID: 309 RVA: 0x00005165 File Offset: 0x00003365
		public static void InitIO()
		{
			DataTypeIO.Init<PacketINVDROP>(delegate(InitDataTypeIO<PacketINVDROP> init)
			{
				init.Field<InventorySlot>((PacketINVDROP p) => p.Slot, FieldType.DataType).End();
			});
		}
	}
}
