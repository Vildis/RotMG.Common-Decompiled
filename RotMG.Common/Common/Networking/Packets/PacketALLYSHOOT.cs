using System;
using RotMG.Common.Networking.IO;

namespace RotMG.Common.Networking.Packets
{
	// Token: 0x0200002A RID: 42
	public class PacketALLYSHOOT : Packet
	{
		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000164 RID: 356 RVA: 0x000059A1 File Offset: 0x00003BA1
		public override PacketId Id
		{
			get
			{
				return PacketId.ALLYSHOOT;
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000165 RID: 357 RVA: 0x000059A5 File Offset: 0x00003BA5
		// (set) Token: 0x06000166 RID: 358 RVA: 0x000059AD File Offset: 0x00003BAD
		public byte BulletId { get; set; }

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x06000167 RID: 359 RVA: 0x000059B6 File Offset: 0x00003BB6
		// (set) Token: 0x06000168 RID: 360 RVA: 0x000059BE File Offset: 0x00003BBE
		public int OwnerId { get; set; }

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x06000169 RID: 361 RVA: 0x000059C7 File Offset: 0x00003BC7
		// (set) Token: 0x0600016A RID: 362 RVA: 0x000059CF File Offset: 0x00003BCF
		public ushort ContainerType { get; set; }

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x0600016B RID: 363 RVA: 0x000059D8 File Offset: 0x00003BD8
		// (set) Token: 0x0600016C RID: 364 RVA: 0x000059E0 File Offset: 0x00003BE0
		public float Angle { get; set; }

		// Token: 0x0600016D RID: 365 RVA: 0x00005B0F File Offset: 0x00003D0F
		public static void InitIO()
		{
			DataTypeIO.Init<PacketALLYSHOOT>(delegate(InitDataTypeIO<PacketALLYSHOOT> init)
			{
				init.Field<byte>((PacketALLYSHOOT p) => p.BulletId, FieldType.Byte).Field<int>((PacketALLYSHOOT p) => p.OwnerId, FieldType.Int32).Field<ushort>((PacketALLYSHOOT p) => p.ContainerType, FieldType.Int16)
					.Field<float>((PacketALLYSHOOT p) => p.Angle, FieldType.Float32)
					.End();
			});
		}
	}
}
