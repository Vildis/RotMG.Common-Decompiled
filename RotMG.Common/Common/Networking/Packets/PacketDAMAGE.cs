using System;
using RotMG.Common.Networking.Data;
using RotMG.Common.Networking.IO;

namespace RotMG.Common.Networking.Packets
{
	// Token: 0x0200002B RID: 43
	public class PacketDAMAGE : Packet
	{
		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000170 RID: 368 RVA: 0x00005B3B File Offset: 0x00003D3B
		public override PacketId Id
		{
			get
			{
				return PacketId.DAMAGE;
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000171 RID: 369 RVA: 0x00005B3F File Offset: 0x00003D3F
		// (set) Token: 0x06000172 RID: 370 RVA: 0x00005B47 File Offset: 0x00003D47
		public int TargetId { get; set; }

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000173 RID: 371 RVA: 0x00005B50 File Offset: 0x00003D50
		// (set) Token: 0x06000174 RID: 372 RVA: 0x00005B58 File Offset: 0x00003D58
		public ConditionEffect Effects { get; set; }

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000175 RID: 373 RVA: 0x00005B61 File Offset: 0x00003D61
		// (set) Token: 0x06000176 RID: 374 RVA: 0x00005B69 File Offset: 0x00003D69
		public ushort Amount { get; set; }

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000177 RID: 375 RVA: 0x00005B72 File Offset: 0x00003D72
		// (set) Token: 0x06000178 RID: 376 RVA: 0x00005B7A File Offset: 0x00003D7A
		public bool Killed { get; set; }

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000179 RID: 377 RVA: 0x00005B83 File Offset: 0x00003D83
		// (set) Token: 0x0600017A RID: 378 RVA: 0x00005B8B File Offset: 0x00003D8B
		public byte BulletId { get; set; }

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x0600017B RID: 379 RVA: 0x00005B94 File Offset: 0x00003D94
		// (set) Token: 0x0600017C RID: 380 RVA: 0x00005B9C File Offset: 0x00003D9C
		public int OwnerId { get; set; }

		// Token: 0x0600017D RID: 381 RVA: 0x00005D5A File Offset: 0x00003F5A
		public static void InitIO()
		{
			DataTypeIO.Init<PacketDAMAGE>(delegate(InitDataTypeIO<PacketDAMAGE> init)
			{
				init.Field<int>((PacketDAMAGE p) => p.TargetId, FieldType.Int32).Field<ConditionEffect>((PacketDAMAGE p) => p.Effects, FieldType.DataType).Field<ushort>((PacketDAMAGE p) => p.Amount, FieldType.Int16)
					.Field<bool>((PacketDAMAGE p) => p.Killed, FieldType.Bool)
					.Field<byte>((PacketDAMAGE p) => p.BulletId, FieldType.Byte)
					.Field<int>((PacketDAMAGE p) => p.OwnerId, FieldType.Int32)
					.End();
			});
		}
	}
}
