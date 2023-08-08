using System;
using RotMG.Common.Networking.IO;

namespace RotMG.Common.Networking.Packets
{
	// Token: 0x02000046 RID: 70
	public class PacketPLAYERHIT : Packet
	{
		// Token: 0x17000092 RID: 146
		// (get) Token: 0x0600021B RID: 539 RVA: 0x000076C7 File Offset: 0x000058C7
		public override PacketId Id
		{
			get
			{
				return PacketId.PLAYERHIT;
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x0600021C RID: 540 RVA: 0x000076CB File Offset: 0x000058CB
		// (set) Token: 0x0600021D RID: 541 RVA: 0x000076D3 File Offset: 0x000058D3
		public byte BulletId { get; set; }

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x0600021E RID: 542 RVA: 0x000076DC File Offset: 0x000058DC
		// (set) Token: 0x0600021F RID: 543 RVA: 0x000076E4 File Offset: 0x000058E4
		public int ObjectId { get; set; }

		// Token: 0x06000220 RID: 544 RVA: 0x00007785 File Offset: 0x00005985
		public static void InitIO()
		{
			DataTypeIO.Init<PacketPLAYERHIT>(delegate(InitDataTypeIO<PacketPLAYERHIT> init)
			{
				init.Field<byte>((PacketPLAYERHIT p) => p.BulletId, FieldType.Byte).Field<int>((PacketPLAYERHIT p) => p.ObjectId, FieldType.Int32).End();
			});
		}
	}
}
