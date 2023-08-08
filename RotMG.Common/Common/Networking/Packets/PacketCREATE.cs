using System;
using RotMG.Common.Networking.IO;

namespace RotMG.Common.Networking.Packets
{
	// Token: 0x02000008 RID: 8
	public class PacketCREATE : Packet
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000015 RID: 21 RVA: 0x000022E5 File Offset: 0x000004E5
		public override PacketId Id
		{
			get
			{
				return PacketId.CREATE;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000016 RID: 22 RVA: 0x000022E8 File Offset: 0x000004E8
		// (set) Token: 0x06000017 RID: 23 RVA: 0x000022F0 File Offset: 0x000004F0
		public ushort ClassType { get; set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000018 RID: 24 RVA: 0x000022F9 File Offset: 0x000004F9
		// (set) Token: 0x06000019 RID: 25 RVA: 0x00002301 File Offset: 0x00000501
		public ushort SkinType { get; set; }

		// Token: 0x0600001A RID: 26 RVA: 0x000023A1 File Offset: 0x000005A1
		public static void InitIO()
		{
			DataTypeIO.Init<PacketCREATE>(delegate(InitDataTypeIO<PacketCREATE> init)
			{
				init.Field<ushort>((PacketCREATE p) => p.ClassType, FieldType.Int16).Field<ushort>((PacketCREATE p) => p.SkinType, FieldType.Int16).End();
			});
		}
	}
}
