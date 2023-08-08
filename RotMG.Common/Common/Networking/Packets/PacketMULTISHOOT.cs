using System;
using RotMG.Common.Networking.Data;
using RotMG.Common.Networking.IO;

namespace RotMG.Common.Networking.Packets
{
	// Token: 0x02000012 RID: 18
	public class PacketMULTISHOOT : Packet
	{
		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600007D RID: 125 RVA: 0x000032EB File Offset: 0x000014EB
		public override PacketId Id
		{
			get
			{
				return PacketId.MULTISHOOT;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600007E RID: 126 RVA: 0x000032EF File Offset: 0x000014EF
		// (set) Token: 0x0600007F RID: 127 RVA: 0x000032F7 File Offset: 0x000014F7
		public byte BulletId { get; set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000080 RID: 128 RVA: 0x00003300 File Offset: 0x00001500
		// (set) Token: 0x06000081 RID: 129 RVA: 0x00003308 File Offset: 0x00001508
		public int OwnerId { get; set; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000082 RID: 130 RVA: 0x00003311 File Offset: 0x00001511
		// (set) Token: 0x06000083 RID: 131 RVA: 0x00003319 File Offset: 0x00001519
		public byte BulletType { get; set; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000084 RID: 132 RVA: 0x00003322 File Offset: 0x00001522
		// (set) Token: 0x06000085 RID: 133 RVA: 0x0000332A File Offset: 0x0000152A
		public Position Position { get; set; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000086 RID: 134 RVA: 0x00003333 File Offset: 0x00001533
		// (set) Token: 0x06000087 RID: 135 RVA: 0x0000333B File Offset: 0x0000153B
		public float Angle { get; set; }

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000088 RID: 136 RVA: 0x00003344 File Offset: 0x00001544
		// (set) Token: 0x06000089 RID: 137 RVA: 0x0000334C File Offset: 0x0000154C
		public short Damage { get; set; }

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600008A RID: 138 RVA: 0x00003355 File Offset: 0x00001555
		// (set) Token: 0x0600008B RID: 139 RVA: 0x0000335D File Offset: 0x0000155D
		public byte NumShots { get; set; }

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x0600008C RID: 140 RVA: 0x00003366 File Offset: 0x00001566
		// (set) Token: 0x0600008D RID: 141 RVA: 0x0000336E File Offset: 0x0000156E
		public float AngleIncrement { get; set; }

		// Token: 0x0600008E RID: 142 RVA: 0x000035B8 File Offset: 0x000017B8
		public static void InitIO()
		{
			DataTypeIO.Init<PacketMULTISHOOT>(delegate(InitDataTypeIO<PacketMULTISHOOT> init)
			{
				init.Field<byte>((PacketMULTISHOOT p) => p.BulletId, FieldType.Byte).Field<int>((PacketMULTISHOOT p) => p.OwnerId, FieldType.Int32).Field<byte>((PacketMULTISHOOT p) => p.BulletType, FieldType.Byte)
					.Field<Position>((PacketMULTISHOOT p) => p.Position, FieldType.DataType)
					.Field<float>((PacketMULTISHOOT p) => p.Angle, FieldType.Float32)
					.Field<short>((PacketMULTISHOOT p) => p.Damage, FieldType.Int16)
					.Field<byte>((PacketMULTISHOOT p) => p.NumShots, FieldType.Byte)
					.Field<float>((PacketMULTISHOOT p) => p.AngleIncrement, FieldType.Float32)
					.End();
			});
		}
	}
}
