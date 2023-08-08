using System;
using RotMG.Common.Networking.IO;

namespace RotMG.Common.Networking.Packets
{
	// Token: 0x0200002F RID: 47
	public class PacketQUESTOBJID : Packet
	{
		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000186 RID: 390 RVA: 0x00005E0B File Offset: 0x0000400B
		public override PacketId Id
		{
			get
			{
				return PacketId.QUESTOBJID;
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06000187 RID: 391 RVA: 0x00005E0F File Offset: 0x0000400F
		// (set) Token: 0x06000188 RID: 392 RVA: 0x00005E17 File Offset: 0x00004017
		public int ObjectId { get; set; }

		// Token: 0x06000189 RID: 393 RVA: 0x00005E74 File Offset: 0x00004074
		public static void InitIO()
		{
			DataTypeIO.Init<PacketQUESTOBJID>(delegate(InitDataTypeIO<PacketQUESTOBJID> init)
			{
				init.Field<int>((PacketQUESTOBJID p) => p.ObjectId, FieldType.Int32).End();
			});
		}
	}
}
