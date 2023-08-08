using System;
using RotMG.Common.Networking.IO;

namespace RotMG.Common.Networking.Packets
{
	// Token: 0x02000030 RID: 48
	public class PacketNOTIFICATION : Packet
	{
		// Token: 0x17000067 RID: 103
		// (get) Token: 0x0600018C RID: 396 RVA: 0x00005EA0 File Offset: 0x000040A0
		public override PacketId Id
		{
			get
			{
				return PacketId.NOTIFICATION;
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x0600018D RID: 397 RVA: 0x00005EA4 File Offset: 0x000040A4
		// (set) Token: 0x0600018E RID: 398 RVA: 0x00005EAC File Offset: 0x000040AC
		public int ObjectId { get; set; }

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x0600018F RID: 399 RVA: 0x00005EB5 File Offset: 0x000040B5
		// (set) Token: 0x06000190 RID: 400 RVA: 0x00005EBD File Offset: 0x000040BD
		public string Message { get; set; }

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06000191 RID: 401 RVA: 0x00005EC6 File Offset: 0x000040C6
		// (set) Token: 0x06000192 RID: 402 RVA: 0x00005ECE File Offset: 0x000040CE
		public uint Color { get; set; }

		// Token: 0x06000193 RID: 403 RVA: 0x00005FB4 File Offset: 0x000041B4
		public static void InitIO()
		{
			DataTypeIO.Init<PacketNOTIFICATION>(delegate(InitDataTypeIO<PacketNOTIFICATION> init)
			{
				init.Field<int>((PacketNOTIFICATION p) => p.ObjectId, FieldType.Int32).Field<string>((PacketNOTIFICATION p) => p.Message, FieldType.UTF).Field<uint>((PacketNOTIFICATION p) => p.Color, FieldType.Int32)
					.End();
			});
		}
	}
}
