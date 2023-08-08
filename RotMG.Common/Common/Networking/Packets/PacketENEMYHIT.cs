using System;
using RotMG.Common.Networking.IO;

namespace RotMG.Common.Networking.Packets
{
	// Token: 0x02000009 RID: 9
	public class PacketENEMYHIT : Packet
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600001D RID: 29 RVA: 0x000023CD File Offset: 0x000005CD
		public override PacketId Id
		{
			get
			{
				return PacketId.ENEMYHIT;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600001E RID: 30 RVA: 0x000023D1 File Offset: 0x000005D1
		// (set) Token: 0x0600001F RID: 31 RVA: 0x000023D9 File Offset: 0x000005D9
		public int Time { get; set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000020 RID: 32 RVA: 0x000023E2 File Offset: 0x000005E2
		// (set) Token: 0x06000021 RID: 33 RVA: 0x000023EA File Offset: 0x000005EA
		public byte BulletId { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000022 RID: 34 RVA: 0x000023F3 File Offset: 0x000005F3
		// (set) Token: 0x06000023 RID: 35 RVA: 0x000023FB File Offset: 0x000005FB
		public int TargetId { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000024 RID: 36 RVA: 0x00002404 File Offset: 0x00000604
		// (set) Token: 0x06000025 RID: 37 RVA: 0x0000240C File Offset: 0x0000060C
		public bool Killed { get; set; }

		// Token: 0x06000026 RID: 38 RVA: 0x0000253B File Offset: 0x0000073B
		public static void InitIO()
		{
			DataTypeIO.Init<PacketENEMYHIT>(delegate(InitDataTypeIO<PacketENEMYHIT> init)
			{
				init.Field<int>((PacketENEMYHIT p) => p.Time, FieldType.Int32).Field<byte>((PacketENEMYHIT p) => p.BulletId, FieldType.Byte).Field<int>((PacketENEMYHIT p) => p.TargetId, FieldType.Int32)
					.Field<bool>((PacketENEMYHIT p) => p.Killed, FieldType.Bool)
					.End();
			});
		}
	}
}
