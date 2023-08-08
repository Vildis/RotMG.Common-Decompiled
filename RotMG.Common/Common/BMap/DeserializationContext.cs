using System;
using System.Collections.Generic;
using RotMG.Common.IO;

namespace RotMG.Common.BMap
{
	// Token: 0x02000016 RID: 22
	internal class DeserializationContext
	{
		// Token: 0x0600009E RID: 158 RVA: 0x000038E9 File Offset: 0x00001AE9
		public uint GetTileId(uint tileKey)
		{
			return this.TileIdMap[tileKey];
		}

		// Token: 0x0600009F RID: 159 RVA: 0x000038F7 File Offset: 0x00001AF7
		public uint GetObjectId(uint objKey)
		{
			return this.ObjectIdMap[objKey];
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00003905 File Offset: 0x00001B05
		public string GetRegionId(uint regionKey)
		{
			if (regionKey == 0U)
			{
				return null;
			}
			return this.RegionMap[regionKey];
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00003918 File Offset: 0x00001B18
		public void ReadFrom(VarLenBinaryReader reader)
		{
			uint num = reader.ReadVarLen32();
			int num2 = 0;
			while ((long)num2 < (long)((ulong)num))
			{
				this.TileIdMap.Add(reader.ReadVarLen32(), reader.ReadVarLen32());
				num2++;
			}
			num = reader.ReadVarLen32();
			int num3 = 0;
			while ((long)num3 < (long)((ulong)num))
			{
				this.ObjectIdMap.Add(reader.ReadVarLen32(), reader.ReadVarLen32());
				num3++;
			}
			num = reader.ReadVarLen32();
			int num4 = 0;
			while ((long)num4 < (long)((ulong)num))
			{
				this.RegionMap.Add(reader.ReadVarLen32(), reader.ReadString());
				num4++;
			}
		}

		// Token: 0x04000046 RID: 70
		public readonly Dictionary<uint, uint> TileIdMap = new Dictionary<uint, uint>();

		// Token: 0x04000047 RID: 71
		public readonly Dictionary<uint, uint> ObjectIdMap = new Dictionary<uint, uint>();

		// Token: 0x04000048 RID: 72
		public readonly Dictionary<uint, string> RegionMap = new Dictionary<uint, string>();
	}
}
