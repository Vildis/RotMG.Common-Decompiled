using System;
using RotMG.Common.Networking.IO;

namespace RotMG.Common.Networking.Packets
{
	// Token: 0x02000044 RID: 68
	public class PacketSHOOTACK : Packet
	{
		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000209 RID: 521 RVA: 0x00007499 File Offset: 0x00005699
		public override PacketId Id
		{
			get
			{
				return PacketId.SHOOTACK;
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x0600020A RID: 522 RVA: 0x0000749D File Offset: 0x0000569D
		// (set) Token: 0x0600020B RID: 523 RVA: 0x000074A5 File Offset: 0x000056A5
		public int Time { get; set; }

		// Token: 0x0600020C RID: 524 RVA: 0x00007504 File Offset: 0x00005704
		public static void InitIO()
		{
			DataTypeIO.Init<PacketSHOOTACK>(delegate(InitDataTypeIO<PacketSHOOTACK> init)
			{
				init.Field<int>((PacketSHOOTACK p) => p.Time, FieldType.Int32).End();
			});
		}
	}
}
