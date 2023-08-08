using System;
using RotMG.Common.Networking.IO;

namespace RotMG.Common.Networking.Packets
{
	// Token: 0x0200004A RID: 74
	public class PacketCREATE_SUCCESS : Packet
	{
		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x06000249 RID: 585 RVA: 0x000088EE File Offset: 0x00006AEE
		public override PacketId Id
		{
			get
			{
				return PacketId.CREATE_SUCCESS;
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x0600024A RID: 586 RVA: 0x000088F1 File Offset: 0x00006AF1
		// (set) Token: 0x0600024B RID: 587 RVA: 0x000088F9 File Offset: 0x00006AF9
		public int ObjectId { get; set; }

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x0600024C RID: 588 RVA: 0x00008902 File Offset: 0x00006B02
		// (set) Token: 0x0600024D RID: 589 RVA: 0x0000890A File Offset: 0x00006B0A
		public int CharId { get; set; }

		// Token: 0x0600024E RID: 590 RVA: 0x000089A9 File Offset: 0x00006BA9
		public static void InitIO()
		{
			DataTypeIO.Init<PacketCREATE_SUCCESS>(delegate(InitDataTypeIO<PacketCREATE_SUCCESS> init)
			{
				init.Field<int>((PacketCREATE_SUCCESS p) => p.ObjectId, FieldType.Int32).Field<int>((PacketCREATE_SUCCESS p) => p.CharId, FieldType.Int32).End();
			});
		}
	}
}
