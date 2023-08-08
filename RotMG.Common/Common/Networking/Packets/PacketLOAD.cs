using System;
using RotMG.Common.Networking.IO;

namespace RotMG.Common.Networking.Packets
{
	// Token: 0x02000029 RID: 41
	public class PacketLOAD : Packet
	{
		// Token: 0x17000056 RID: 86
		// (get) Token: 0x0600015C RID: 348 RVA: 0x000058B9 File Offset: 0x00003AB9
		public override PacketId Id
		{
			get
			{
				return PacketId.LOAD;
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x0600015D RID: 349 RVA: 0x000058BC File Offset: 0x00003ABC
		// (set) Token: 0x0600015E RID: 350 RVA: 0x000058C4 File Offset: 0x00003AC4
		public int CharId { get; set; }

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x0600015F RID: 351 RVA: 0x000058CD File Offset: 0x00003ACD
		// (set) Token: 0x06000160 RID: 352 RVA: 0x000058D5 File Offset: 0x00003AD5
		public bool IsFromArena { get; set; }

		// Token: 0x06000161 RID: 353 RVA: 0x00005975 File Offset: 0x00003B75
		public static void InitIO()
		{
			DataTypeIO.Init<PacketLOAD>(delegate(InitDataTypeIO<PacketLOAD> init)
			{
				init.Field<int>((PacketLOAD p) => p.CharId, FieldType.Int32).Field<bool>((PacketLOAD p) => p.IsFromArena, FieldType.Bool).End();
			});
		}
	}
}
