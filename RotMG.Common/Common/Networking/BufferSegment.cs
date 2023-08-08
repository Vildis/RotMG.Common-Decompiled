using System;

namespace RotMG.Common.Networking
{
	// Token: 0x0200004E RID: 78
	public struct BufferSegment
	{
		// Token: 0x0600026C RID: 620 RVA: 0x00008DA8 File Offset: 0x00006FA8
		public BufferSegment(byte[] buffer, int offset)
		{
			this.Buffer = buffer;
			this.Offset = offset;
		}

		// Token: 0x040001CF RID: 463
		public readonly byte[] Buffer;

		// Token: 0x040001D0 RID: 464
		public readonly int Offset;
	}
}
