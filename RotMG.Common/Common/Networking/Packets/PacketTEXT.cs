using System;
using RotMG.Common.Networking.IO;

namespace RotMG.Common.Networking.Packets
{
	// Token: 0x0200003D RID: 61
	public class PacketTEXT : Packet
	{
		// Token: 0x1700007A RID: 122
		// (get) Token: 0x060001D3 RID: 467 RVA: 0x00006BDB File Offset: 0x00004DDB
		public override PacketId Id
		{
			get
			{
				return PacketId.TEXT;
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x060001D4 RID: 468 RVA: 0x00006BDF File Offset: 0x00004DDF
		// (set) Token: 0x060001D5 RID: 469 RVA: 0x00006BE7 File Offset: 0x00004DE7
		public string Name { get; set; }

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x060001D6 RID: 470 RVA: 0x00006BF0 File Offset: 0x00004DF0
		// (set) Token: 0x060001D7 RID: 471 RVA: 0x00006BF8 File Offset: 0x00004DF8
		public int ObjectId { get; set; }

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x060001D8 RID: 472 RVA: 0x00006C01 File Offset: 0x00004E01
		// (set) Token: 0x060001D9 RID: 473 RVA: 0x00006C09 File Offset: 0x00004E09
		public int Stars { get; set; }

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x060001DA RID: 474 RVA: 0x00006C12 File Offset: 0x00004E12
		// (set) Token: 0x060001DB RID: 475 RVA: 0x00006C1A File Offset: 0x00004E1A
		public byte BubbleTime { get; set; }

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x060001DC RID: 476 RVA: 0x00006C23 File Offset: 0x00004E23
		// (set) Token: 0x060001DD RID: 477 RVA: 0x00006C2B File Offset: 0x00004E2B
		public string Recipient { get; set; }

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x060001DE RID: 478 RVA: 0x00006C34 File Offset: 0x00004E34
		// (set) Token: 0x060001DF RID: 479 RVA: 0x00006C3C File Offset: 0x00004E3C
		public string Text { get; set; }

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x060001E0 RID: 480 RVA: 0x00006C45 File Offset: 0x00004E45
		// (set) Token: 0x060001E1 RID: 481 RVA: 0x00006C4D File Offset: 0x00004E4D
		public string CleanText { get; set; }

		// Token: 0x060001E2 RID: 482 RVA: 0x00006E50 File Offset: 0x00005050
		public static void InitIO()
		{
			DataTypeIO.Init<PacketTEXT>(delegate(InitDataTypeIO<PacketTEXT> init)
			{
				init.Field<string>((PacketTEXT p) => p.Name, FieldType.UTF).Field<int>((PacketTEXT p) => p.ObjectId, FieldType.Int32).Field<int>((PacketTEXT p) => p.Stars, FieldType.Int32)
					.Field<byte>((PacketTEXT p) => p.BubbleTime, FieldType.Byte)
					.Field<string>((PacketTEXT p) => p.Recipient, FieldType.UTF)
					.Field<string>((PacketTEXT p) => p.Text, FieldType.UTF)
					.Field<string>((PacketTEXT p) => p.CleanText, FieldType.UTF)
					.End();
			});
		}
	}
}
