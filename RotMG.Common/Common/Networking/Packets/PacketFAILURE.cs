using System;
using RotMG.Common.Networking.IO;

namespace RotMG.Common.Networking.Packets
{
	// Token: 0x02000028 RID: 40
	public class PacketFAILURE : Packet
	{
		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000154 RID: 340 RVA: 0x000057D0 File Offset: 0x000039D0
		public override PacketId Id
		{
			get
			{
				return PacketId.FAILURE;
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000155 RID: 341 RVA: 0x000057D3 File Offset: 0x000039D3
		// (set) Token: 0x06000156 RID: 342 RVA: 0x000057DB File Offset: 0x000039DB
		public int ErrorId { get; set; }

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x06000157 RID: 343 RVA: 0x000057E4 File Offset: 0x000039E4
		// (set) Token: 0x06000158 RID: 344 RVA: 0x000057EC File Offset: 0x000039EC
		public string ErrorDescription { get; set; }

		// Token: 0x06000159 RID: 345 RVA: 0x0000588D File Offset: 0x00003A8D
		public static void InitIO()
		{
			DataTypeIO.Init<PacketFAILURE>(delegate(InitDataTypeIO<PacketFAILURE> init)
			{
				init.Field<int>((PacketFAILURE p) => p.ErrorId, FieldType.Int32).Field<string>((PacketFAILURE p) => p.ErrorDescription, FieldType.UTF).End();
			});
		}

		// Token: 0x04000129 RID: 297
		public const int Type1 = 4;

		// Token: 0x0400012A RID: 298
		public const int Type2 = 5;

		// Token: 0x0400012B RID: 299
		public const int Type3 = 6;

		// Token: 0x0400012C RID: 300
		public const int Type4 = 7;
	}
}
