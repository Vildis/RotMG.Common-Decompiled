using System;
using RotMG.Common.Networking.IO;

namespace RotMG.Common.Networking
{
	// Token: 0x02000007 RID: 7
	[DataType]
	public abstract class Packet
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000013 RID: 19
		public abstract PacketId Id { get; }
	}
}
