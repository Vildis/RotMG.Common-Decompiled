using System;
using RotMG.Common.Networking.IO;

namespace RotMG.Common.Networking.Packets
{
	// Token: 0x02000021 RID: 33
	public class PacketINVRESULT : Packet
	{
		// Token: 0x1700004E RID: 78
		// (get) Token: 0x06000138 RID: 312 RVA: 0x00005191 File Offset: 0x00003391
		public override PacketId Id
		{
			get
			{
				return PacketId.INVRESULT;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x06000139 RID: 313 RVA: 0x00005195 File Offset: 0x00003395
		// (set) Token: 0x0600013A RID: 314 RVA: 0x0000519D File Offset: 0x0000339D
		public int Result { get; set; }

		// Token: 0x0600013B RID: 315 RVA: 0x000051FC File Offset: 0x000033FC
		public static void InitIO()
		{
			DataTypeIO.Init<PacketINVRESULT>(delegate(InitDataTypeIO<PacketINVRESULT> init)
			{
				init.Field<int>((PacketINVRESULT p) => p.Result, FieldType.Int32).End();
			});
		}
	}
}
