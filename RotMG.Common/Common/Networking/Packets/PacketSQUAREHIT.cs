using System;
using RotMG.Common.Networking.IO;

namespace RotMG.Common.Networking.Packets
{
	// Token: 0x0200004C RID: 76
	public class PacketSQUAREHIT : Packet
	{
		// Token: 0x170000AB RID: 171
		// (get) Token: 0x06000261 RID: 609 RVA: 0x00008C1E File Offset: 0x00006E1E
		public override PacketId Id
		{
			get
			{
				return PacketId.SQUAREHIT;
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000262 RID: 610 RVA: 0x00008C22 File Offset: 0x00006E22
		// (set) Token: 0x06000263 RID: 611 RVA: 0x00008C2A File Offset: 0x00006E2A
		public int Time { get; set; }

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x06000264 RID: 612 RVA: 0x00008C33 File Offset: 0x00006E33
		// (set) Token: 0x06000265 RID: 613 RVA: 0x00008C3B File Offset: 0x00006E3B
		public byte BulletId { get; set; }

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x06000266 RID: 614 RVA: 0x00008C44 File Offset: 0x00006E44
		// (set) Token: 0x06000267 RID: 615 RVA: 0x00008C4C File Offset: 0x00006E4C
		public int ObjectId { get; set; }

		// Token: 0x06000268 RID: 616 RVA: 0x00008D34 File Offset: 0x00006F34
		public static void InitIO()
		{
			DataTypeIO.Init<PacketSQUAREHIT>(delegate(InitDataTypeIO<PacketSQUAREHIT> init)
			{
				init.Field<int>((PacketSQUAREHIT p) => p.Time, FieldType.Int32).Field<byte>((PacketSQUAREHIT p) => p.BulletId, FieldType.Byte).Field<int>((PacketSQUAREHIT p) => p.ObjectId, FieldType.Int32)
					.End();
			});
		}
	}
}
