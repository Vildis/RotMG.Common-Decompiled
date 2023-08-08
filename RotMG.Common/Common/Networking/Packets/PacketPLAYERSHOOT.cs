using System;
using RotMG.Common.Networking.Data;
using RotMG.Common.Networking.IO;

namespace RotMG.Common.Networking.Packets
{
	// Token: 0x02000011 RID: 17
	public class PacketPLAYERSHOOT : Packet
	{
		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600006F RID: 111 RVA: 0x000030F9 File Offset: 0x000012F9
		public override PacketId Id
		{
			get
			{
				return PacketId.PLAYERSHOOT;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000070 RID: 112 RVA: 0x000030FD File Offset: 0x000012FD
		// (set) Token: 0x06000071 RID: 113 RVA: 0x00003105 File Offset: 0x00001305
		public int Time { get; set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000072 RID: 114 RVA: 0x0000310E File Offset: 0x0000130E
		// (set) Token: 0x06000073 RID: 115 RVA: 0x00003116 File Offset: 0x00001316
		public byte BulletId { get; set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000074 RID: 116 RVA: 0x0000311F File Offset: 0x0000131F
		// (set) Token: 0x06000075 RID: 117 RVA: 0x00003127 File Offset: 0x00001327
		public ushort ContainerType { get; set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000076 RID: 118 RVA: 0x00003130 File Offset: 0x00001330
		// (set) Token: 0x06000077 RID: 119 RVA: 0x00003138 File Offset: 0x00001338
		public Position Position { get; set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000078 RID: 120 RVA: 0x00003141 File Offset: 0x00001341
		// (set) Token: 0x06000079 RID: 121 RVA: 0x00003149 File Offset: 0x00001349
		public float Angle { get; set; }

		// Token: 0x0600007A RID: 122 RVA: 0x000032BF File Offset: 0x000014BF
		public static void InitIO()
		{
			DataTypeIO.Init<PacketPLAYERSHOOT>(delegate(InitDataTypeIO<PacketPLAYERSHOOT> init)
			{
				init.Field<int>((PacketPLAYERSHOOT p) => p.Time, FieldType.Int32).Field<byte>((PacketPLAYERSHOOT p) => p.BulletId, FieldType.Byte).Field<ushort>((PacketPLAYERSHOOT p) => p.ContainerType, FieldType.Int16)
					.Field<Position>((PacketPLAYERSHOOT p) => p.Position, FieldType.DataType)
					.Field<float>((PacketPLAYERSHOOT p) => p.Angle, FieldType.Float32)
					.End();
			});
		}
	}
}
