using System;
using RotMG.Common.Networking.Data;
using RotMG.Common.Networking.IO;

namespace RotMG.Common.Networking.Packets
{
	// Token: 0x02000037 RID: 55
	public class PacketMOVE : Packet
	{
		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060001AD RID: 429 RVA: 0x000064D1 File Offset: 0x000046D1
		public override PacketId Id
		{
			get
			{
				return PacketId.MOVE;
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060001AE RID: 430 RVA: 0x000064D5 File Offset: 0x000046D5
		// (set) Token: 0x060001AF RID: 431 RVA: 0x000064DD File Offset: 0x000046DD
		public int TickId { get; set; }

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060001B0 RID: 432 RVA: 0x000064E6 File Offset: 0x000046E6
		// (set) Token: 0x060001B1 RID: 433 RVA: 0x000064EE File Offset: 0x000046EE
		public int TickTime { get; set; }

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060001B2 RID: 434 RVA: 0x000064F7 File Offset: 0x000046F7
		// (set) Token: 0x060001B3 RID: 435 RVA: 0x000064FF File Offset: 0x000046FF
		public Position NewPosition { get; set; }

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060001B4 RID: 436 RVA: 0x00006508 File Offset: 0x00004708
		// (set) Token: 0x060001B5 RID: 437 RVA: 0x00006510 File Offset: 0x00004710
		public TimedPosition[] PositionRecords { get; set; }

		// Token: 0x060001B6 RID: 438 RVA: 0x00006641 File Offset: 0x00004841
		public static void InitIO()
		{
			DataTypeIO.Init<PacketMOVE>(delegate(InitDataTypeIO<PacketMOVE> init)
			{
				init.Field<int>((PacketMOVE p) => p.TickId, FieldType.Int32).Field<int>((PacketMOVE p) => p.TickTime, FieldType.Int32).Field<Position>((PacketMOVE p) => p.NewPosition, FieldType.DataType)
					.Field<TimedPosition[]>((PacketMOVE p) => p.PositionRecords, FieldType.DataArray)
					.End();
			});
		}
	}
}
