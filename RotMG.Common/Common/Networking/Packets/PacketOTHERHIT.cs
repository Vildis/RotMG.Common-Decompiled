using System;
using RotMG.Common.Networking.IO;

namespace RotMG.Common.Networking.Packets
{
	// Token: 0x02000045 RID: 69
	public class PacketOTHERHIT : Packet
	{
		// Token: 0x1700008D RID: 141
		// (get) Token: 0x0600020F RID: 527 RVA: 0x00007530 File Offset: 0x00005730
		public override PacketId Id
		{
			get
			{
				return PacketId.OTHERHIT;
			}
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x06000210 RID: 528 RVA: 0x00007534 File Offset: 0x00005734
		// (set) Token: 0x06000211 RID: 529 RVA: 0x0000753C File Offset: 0x0000573C
		public int Time { get; set; }

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x06000212 RID: 530 RVA: 0x00007545 File Offset: 0x00005745
		// (set) Token: 0x06000213 RID: 531 RVA: 0x0000754D File Offset: 0x0000574D
		public byte BulletId { get; set; }

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x06000214 RID: 532 RVA: 0x00007556 File Offset: 0x00005756
		// (set) Token: 0x06000215 RID: 533 RVA: 0x0000755E File Offset: 0x0000575E
		public int ObjectId { get; set; }

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x06000216 RID: 534 RVA: 0x00007567 File Offset: 0x00005767
		// (set) Token: 0x06000217 RID: 535 RVA: 0x0000756F File Offset: 0x0000576F
		public int TargetId { get; set; }

		// Token: 0x06000218 RID: 536 RVA: 0x0000769B File Offset: 0x0000589B
		public static void InitIO()
		{
			DataTypeIO.Init<PacketOTHERHIT>(delegate(InitDataTypeIO<PacketOTHERHIT> init)
			{
				init.Field<int>((PacketOTHERHIT p) => p.Time, FieldType.Int32).Field<byte>((PacketOTHERHIT p) => p.BulletId, FieldType.Byte).Field<int>((PacketOTHERHIT p) => p.ObjectId, FieldType.Int32)
					.Field<int>((PacketOTHERHIT p) => p.TargetId, FieldType.Int32)
					.End();
			});
		}
	}
}
