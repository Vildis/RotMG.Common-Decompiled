using System;

namespace RotMG.Common.Networking
{
	// Token: 0x02000022 RID: 34
	public static class PacketIdMap
	{
		// Token: 0x0600013E RID: 318 RVA: 0x00005228 File Offset: 0x00003428
		static PacketIdMap()
		{
			PacketIdMap.RegisterMap(0, PacketId.FAILURE);
			PacketIdMap.RegisterMap(91, PacketId.HELLO);
			PacketIdMap.RegisterMap(7, PacketId.MAPINFO);
			PacketIdMap.RegisterMap(41, PacketId.CREATE);
			PacketIdMap.RegisterMap(63, PacketId.LOAD);
			PacketIdMap.RegisterMap(84, PacketId.CREATE_SUCCESS);
			PacketIdMap.RegisterMap(67, PacketId.UPDATE);
			PacketIdMap.RegisterMap(34, PacketId.NEW_TICK);
			PacketIdMap.RegisterMap(92, PacketId.MOVE);
			PacketIdMap.RegisterMap(17, PacketId.UPDATEACK);
			PacketIdMap.RegisterMap(74, PacketId.INVDROP);
			PacketIdMap.RegisterMap(5, PacketId.INVSWAP);
			PacketIdMap.RegisterMap(89, PacketId.INVRESULT);
			PacketIdMap.RegisterMap(11, PacketId.PLAYERSHOOT);
			PacketIdMap.RegisterMap(94, PacketId.ALLYSHOOT);
			PacketIdMap.RegisterMap(37, PacketId.SHOOT);
			PacketIdMap.RegisterMap(93, PacketId.MULTISHOOT);
			PacketIdMap.RegisterMap(88, PacketId.SHOOTACK);
			PacketIdMap.RegisterMap(15, PacketId.ENEMYHIT);
			PacketIdMap.RegisterMap(69, PacketId.OTHERHIT);
			PacketIdMap.RegisterMap(86, PacketId.PLAYERHIT);
			PacketIdMap.RegisterMap(14, PacketId.SQUAREHIT);
			PacketIdMap.RegisterMap(19, PacketId.DAMAGE);
			PacketIdMap.RegisterMap(38, PacketId.TEXT);
			PacketIdMap.RegisterMap(36, PacketId.NOTIFICATION);
			PacketIdMap.RegisterMap(6, PacketId.QUESTOBJID);
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00005331 File Offset: 0x00003531
		private static void RegisterMap(byte rawId, PacketId id)
		{
			PacketIdMap.Map[(int)rawId] = new PacketId?(id);
			PacketIdMap.ReverseMap[(int)((byte)id)] = new byte?(rawId);
		}

		// Token: 0x0400011D RID: 285
		public static readonly PacketId?[] Map = new PacketId?[256];

		// Token: 0x0400011E RID: 286
		public static readonly byte?[] ReverseMap = new byte?[256];
	}
}
