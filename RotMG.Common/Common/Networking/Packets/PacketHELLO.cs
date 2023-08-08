using System;
using RotMG.Common.Networking.IO;

namespace RotMG.Common.Networking.Packets
{
	// Token: 0x0200000F RID: 15
	public class PacketHELLO : Packet
	{
		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000049 RID: 73 RVA: 0x00002B5F File Offset: 0x00000D5F
		public override PacketId Id
		{
			get
			{
				return PacketId.HELLO;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600004A RID: 74 RVA: 0x00002B62 File Offset: 0x00000D62
		// (set) Token: 0x0600004B RID: 75 RVA: 0x00002B6A File Offset: 0x00000D6A
		public string BuildVersion { get; set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600004C RID: 76 RVA: 0x00002B73 File Offset: 0x00000D73
		// (set) Token: 0x0600004D RID: 77 RVA: 0x00002B7B File Offset: 0x00000D7B
		public int GameId { get; set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600004E RID: 78 RVA: 0x00002B84 File Offset: 0x00000D84
		// (set) Token: 0x0600004F RID: 79 RVA: 0x00002B8C File Offset: 0x00000D8C
		public string GUID { get; set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000050 RID: 80 RVA: 0x00002B95 File Offset: 0x00000D95
		// (set) Token: 0x06000051 RID: 81 RVA: 0x00002B9D File Offset: 0x00000D9D
		public int Random1 { get; set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000052 RID: 82 RVA: 0x00002BA6 File Offset: 0x00000DA6
		// (set) Token: 0x06000053 RID: 83 RVA: 0x00002BAE File Offset: 0x00000DAE
		public string Password { get; set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000054 RID: 84 RVA: 0x00002BB7 File Offset: 0x00000DB7
		// (set) Token: 0x06000055 RID: 85 RVA: 0x00002BBF File Offset: 0x00000DBF
		public int Random2 { get; set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000056 RID: 86 RVA: 0x00002BC8 File Offset: 0x00000DC8
		// (set) Token: 0x06000057 RID: 87 RVA: 0x00002BD0 File Offset: 0x00000DD0
		public string Secret { get; set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000058 RID: 88 RVA: 0x00002BD9 File Offset: 0x00000DD9
		// (set) Token: 0x06000059 RID: 89 RVA: 0x00002BE1 File Offset: 0x00000DE1
		public int KeyTime { get; set; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600005A RID: 90 RVA: 0x00002BEA File Offset: 0x00000DEA
		// (set) Token: 0x0600005B RID: 91 RVA: 0x00002BF2 File Offset: 0x00000DF2
		public ArraySegment<byte> Key { get; set; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600005C RID: 92 RVA: 0x00002BFB File Offset: 0x00000DFB
		// (set) Token: 0x0600005D RID: 93 RVA: 0x00002C03 File Offset: 0x00000E03
		public string MapInfo { get; set; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600005E RID: 94 RVA: 0x00002C0C File Offset: 0x00000E0C
		// (set) Token: 0x0600005F RID: 95 RVA: 0x00002C14 File Offset: 0x00000E14
		public string EntryTag { get; set; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000060 RID: 96 RVA: 0x00002C1D File Offset: 0x00000E1D
		// (set) Token: 0x06000061 RID: 97 RVA: 0x00002C25 File Offset: 0x00000E25
		public string Constant1 { get; set; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000062 RID: 98 RVA: 0x00002C2E File Offset: 0x00000E2E
		// (set) Token: 0x06000063 RID: 99 RVA: 0x00002C36 File Offset: 0x00000E36
		public string Constant2 { get; set; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000064 RID: 100 RVA: 0x00002C3F File Offset: 0x00000E3F
		// (set) Token: 0x06000065 RID: 101 RVA: 0x00002C47 File Offset: 0x00000E47
		public string Constant3 { get; set; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000066 RID: 102 RVA: 0x00002C50 File Offset: 0x00000E50
		// (set) Token: 0x06000067 RID: 103 RVA: 0x00002C58 File Offset: 0x00000E58
		public string PlayPlatform { get; set; }

		// Token: 0x06000068 RID: 104 RVA: 0x00003095 File Offset: 0x00001295
		public static void InitIO()
		{
			DataTypeIO.Init<PacketHELLO>(delegate(InitDataTypeIO<PacketHELLO> init)
			{
				init.Field<string>((PacketHELLO p) => p.BuildVersion, FieldType.UTF).Field<int>((PacketHELLO p) => p.GameId, FieldType.Int32).Field<string>((PacketHELLO p) => p.GUID, FieldType.UTF)
					.Field<int>((PacketHELLO p) => p.Random1, FieldType.Int32)
					.Field<string>((PacketHELLO p) => p.Password, FieldType.UTF)
					.Field<int>((PacketHELLO p) => p.Random2, FieldType.Int32)
					.Field<string>((PacketHELLO p) => p.Secret, FieldType.UTF)
					.Field<int>((PacketHELLO p) => p.KeyTime, FieldType.Int32)
					.Field<ArraySegment<byte>>((PacketHELLO p) => p.Key, FieldType.Buffer16)
					.Field<string>((PacketHELLO p) => p.MapInfo, FieldType.UTF32)
					.Field<string>((PacketHELLO p) => p.EntryTag, FieldType.UTF)
					.Field<string>((PacketHELLO p) => p.Constant1, FieldType.UTF)
					.Field<string>((PacketHELLO p) => p.Constant2, FieldType.UTF)
					.Field<string>((PacketHELLO p) => p.Constant3, FieldType.UTF)
					.Field<string>((PacketHELLO p) => p.PlayPlatform, FieldType.UTF)
					.End();
			});
		}
	}
}
