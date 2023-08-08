using System;

namespace RotMG.Common.Networking
{
	// Token: 0x02000017 RID: 23
	public enum PacketId
	{
		// Token: 0x0400004A RID: 74
		INVALID,
		// Token: 0x0400004B RID: 75
		FAILURE,
		// Token: 0x0400004C RID: 76
		HELLO,
		// Token: 0x0400004D RID: 77
		MAPINFO,
		// Token: 0x0400004E RID: 78
		CREATE,
		// Token: 0x0400004F RID: 79
		LOAD,
		// Token: 0x04000050 RID: 80
		CREATE_SUCCESS,
		// Token: 0x04000051 RID: 81
		UPDATE,
		// Token: 0x04000052 RID: 82
		NEW_TICK,
		// Token: 0x04000053 RID: 83
		MOVE,
		// Token: 0x04000054 RID: 84
		UPDATEACK,
		// Token: 0x04000055 RID: 85
		INVDROP,
		// Token: 0x04000056 RID: 86
		INVSWAP,
		// Token: 0x04000057 RID: 87
		INVRESULT,
		// Token: 0x04000058 RID: 88
		PLAYERSHOOT,
		// Token: 0x04000059 RID: 89
		ALLYSHOOT,
		// Token: 0x0400005A RID: 90
		SHOOT,
		// Token: 0x0400005B RID: 91
		MULTISHOOT,
		// Token: 0x0400005C RID: 92
		SHOOTACK,
		// Token: 0x0400005D RID: 93
		ENEMYHIT,
		// Token: 0x0400005E RID: 94
		OTHERHIT,
		// Token: 0x0400005F RID: 95
		PLAYERHIT,
		// Token: 0x04000060 RID: 96
		SQUAREHIT,
		// Token: 0x04000061 RID: 97
		DAMAGE,
		// Token: 0x04000062 RID: 98
		TEXT,
		// Token: 0x04000063 RID: 99
		NOTIFICATION,
		// Token: 0x04000064 RID: 100
		QUESTOBJID
	}
}
