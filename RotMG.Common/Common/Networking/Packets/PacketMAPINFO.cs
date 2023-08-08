using System;
using RotMG.Common.Networking.IO;

namespace RotMG.Common.Networking.Packets
{
	// Token: 0x02000049 RID: 73
	public class PacketMAPINFO : Packet
	{
		// Token: 0x17000095 RID: 149
		// (get) Token: 0x0600022F RID: 559 RVA: 0x000084ED File Offset: 0x000066ED
		public override PacketId Id
		{
			get
			{
				return PacketId.MAPINFO;
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x06000230 RID: 560 RVA: 0x000084F0 File Offset: 0x000066F0
		// (set) Token: 0x06000231 RID: 561 RVA: 0x000084F8 File Offset: 0x000066F8
		public uint Width { get; set; }

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x06000232 RID: 562 RVA: 0x00008501 File Offset: 0x00006701
		// (set) Token: 0x06000233 RID: 563 RVA: 0x00008509 File Offset: 0x00006709
		public uint Height { get; set; }

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x06000234 RID: 564 RVA: 0x00008512 File Offset: 0x00006712
		// (set) Token: 0x06000235 RID: 565 RVA: 0x0000851A File Offset: 0x0000671A
		public string Name { get; set; }

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x06000236 RID: 566 RVA: 0x00008523 File Offset: 0x00006723
		// (set) Token: 0x06000237 RID: 567 RVA: 0x0000852B File Offset: 0x0000672B
		public string DisplayName { get; set; }

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x06000238 RID: 568 RVA: 0x00008534 File Offset: 0x00006734
		// (set) Token: 0x06000239 RID: 569 RVA: 0x0000853C File Offset: 0x0000673C
		public uint Seed { get; set; }

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x0600023A RID: 570 RVA: 0x00008545 File Offset: 0x00006745
		// (set) Token: 0x0600023B RID: 571 RVA: 0x0000854D File Offset: 0x0000674D
		public int Background { get; set; }

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x0600023C RID: 572 RVA: 0x00008556 File Offset: 0x00006756
		// (set) Token: 0x0600023D RID: 573 RVA: 0x0000855E File Offset: 0x0000675E
		public int Difficulty { get; set; }

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x0600023E RID: 574 RVA: 0x00008567 File Offset: 0x00006767
		// (set) Token: 0x0600023F RID: 575 RVA: 0x0000856F File Offset: 0x0000676F
		public bool AllowTeleport { get; set; }

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x06000240 RID: 576 RVA: 0x00008578 File Offset: 0x00006778
		// (set) Token: 0x06000241 RID: 577 RVA: 0x00008580 File Offset: 0x00006780
		public bool ShowDisplays { get; set; }

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x06000242 RID: 578 RVA: 0x00008589 File Offset: 0x00006789
		// (set) Token: 0x06000243 RID: 579 RVA: 0x00008591 File Offset: 0x00006791
		public string[] ClientXML { get; set; }

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x06000244 RID: 580 RVA: 0x0000859A File Offset: 0x0000679A
		// (set) Token: 0x06000245 RID: 581 RVA: 0x000085A2 File Offset: 0x000067A2
		public string[] ExtraXML { get; set; }

		// Token: 0x06000246 RID: 582 RVA: 0x000088C2 File Offset: 0x00006AC2
		public static void InitIO()
		{
			DataTypeIO.Init<PacketMAPINFO>(delegate(InitDataTypeIO<PacketMAPINFO> init)
			{
				init.Field<uint>((PacketMAPINFO p) => p.Width, FieldType.Int32).Field<uint>((PacketMAPINFO p) => p.Height, FieldType.Int32).Field<string>((PacketMAPINFO p) => p.Name, FieldType.UTF)
					.Field<string>((PacketMAPINFO p) => p.DisplayName, FieldType.UTF)
					.Field<uint>((PacketMAPINFO p) => p.Seed, FieldType.Int32)
					.Field<int>((PacketMAPINFO p) => p.Background, FieldType.Int32)
					.Field<int>((PacketMAPINFO p) => p.Difficulty, FieldType.Int32)
					.Field<bool>((PacketMAPINFO p) => p.AllowTeleport, FieldType.Bool)
					.Field<bool>((PacketMAPINFO p) => p.ShowDisplays, FieldType.Bool)
					.Field<string[]>((PacketMAPINFO p) => p.ClientXML, FieldType.UTF32Array)
					.Field<string[]>((PacketMAPINFO p) => p.ExtraXML, FieldType.UTF32Array)
					.End();
			});
		}
	}
}
