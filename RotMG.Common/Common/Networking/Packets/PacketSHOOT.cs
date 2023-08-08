using System;
using RotMG.Common.Networking.Data;
using RotMG.Common.Networking.IO;

namespace RotMG.Common.Networking.Packets
{
	// Token: 0x0200004B RID: 75
	public class PacketSHOOT : Packet
	{
		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06000251 RID: 593 RVA: 0x000089D5 File Offset: 0x00006BD5
		public override PacketId Id
		{
			get
			{
				return PacketId.SHOOT;
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x06000252 RID: 594 RVA: 0x000089D9 File Offset: 0x00006BD9
		// (set) Token: 0x06000253 RID: 595 RVA: 0x000089E1 File Offset: 0x00006BE1
		public byte BulletId { get; set; }

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x06000254 RID: 596 RVA: 0x000089EA File Offset: 0x00006BEA
		// (set) Token: 0x06000255 RID: 597 RVA: 0x000089F2 File Offset: 0x00006BF2
		public int OwnerId { get; set; }

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06000256 RID: 598 RVA: 0x000089FB File Offset: 0x00006BFB
		// (set) Token: 0x06000257 RID: 599 RVA: 0x00008A03 File Offset: 0x00006C03
		public ushort ContainerType { get; set; }

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x06000258 RID: 600 RVA: 0x00008A0C File Offset: 0x00006C0C
		// (set) Token: 0x06000259 RID: 601 RVA: 0x00008A14 File Offset: 0x00006C14
		public Position Position { get; set; }

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x0600025A RID: 602 RVA: 0x00008A1D File Offset: 0x00006C1D
		// (set) Token: 0x0600025B RID: 603 RVA: 0x00008A25 File Offset: 0x00006C25
		public float Angle { get; set; }

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x0600025C RID: 604 RVA: 0x00008A2E File Offset: 0x00006C2E
		// (set) Token: 0x0600025D RID: 605 RVA: 0x00008A36 File Offset: 0x00006C36
		public short Damage { get; set; }

		// Token: 0x0600025E RID: 606 RVA: 0x00008BF2 File Offset: 0x00006DF2
		public static void InitIO()
		{
			DataTypeIO.Init<PacketSHOOT>(delegate(InitDataTypeIO<PacketSHOOT> init)
			{
				init.Field<byte>((PacketSHOOT p) => p.BulletId, FieldType.Byte).Field<int>((PacketSHOOT p) => p.OwnerId, FieldType.Int32).Field<ushort>((PacketSHOOT p) => p.ContainerType, FieldType.Int16)
					.Field<Position>((PacketSHOOT p) => p.Position, FieldType.DataType)
					.Field<float>((PacketSHOOT p) => p.Angle, FieldType.Float32)
					.Field<short>((PacketSHOOT p) => p.Damage, FieldType.Int16)
					.End();
			});
		}
	}
}
