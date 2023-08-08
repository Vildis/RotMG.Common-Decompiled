using System;
using RotMG.Common.Networking.IO;

namespace RotMG.Common.Networking.Packets
{
	// Token: 0x02000010 RID: 16
	public class PacketUPDATEACK : Packet
	{
		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600006B RID: 107 RVA: 0x000030C1 File Offset: 0x000012C1
		public override PacketId Id
		{
			get
			{
				return PacketId.UPDATEACK;
			}
		}

		// Token: 0x0600006C RID: 108 RVA: 0x000030CD File Offset: 0x000012CD
		public static void InitIO()
		{
			DataTypeIO.Init<PacketUPDATEACK>(delegate(InitDataTypeIO<PacketUPDATEACK> init)
			{
				init.End();
			});
		}
	}
}
