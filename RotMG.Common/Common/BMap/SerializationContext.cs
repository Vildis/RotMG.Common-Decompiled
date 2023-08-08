using System;
using System.Collections.Generic;
using RotMG.Common.IO;

namespace RotMG.Common.BMap
{
	// Token: 0x02000015 RID: 21
	internal class SerializationContext
	{
		// Token: 0x06000096 RID: 150 RVA: 0x00003708 File Offset: 0x00001908
		public uint GetTileKey(uint tileId)
		{
			return this.TileIdMap.GetValueOrCreate(tileId, (uint _) => (uint)this.TileIdMap.Count);
		}

		// Token: 0x06000097 RID: 151 RVA: 0x0000372F File Offset: 0x0000192F
		public uint GetObjectKey(uint objId)
		{
			return this.ObjectIdMap.GetValueOrCreate(objId, (uint _) => (uint)this.ObjectIdMap.Count);
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00003758 File Offset: 0x00001958
		public uint GetRegionKey(string region)
		{
			if (region == null)
			{
				return 0U;
			}
			return this.RegionMap.GetValueOrCreate(region, (string _) => (uint)(this.RegionMap.Count + 1));
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00003778 File Offset: 0x00001978
		public void WriteTo(VarLenBinaryWriter writer)
		{
			writer.WriteVarLen32((uint)this.TileIdMap.Count);
			foreach (KeyValuePair<uint, uint> keyValuePair in this.TileIdMap)
			{
				writer.WriteVarLen32(keyValuePair.Value);
				writer.WriteVarLen32(keyValuePair.Key);
			}
			writer.WriteVarLen32((uint)this.ObjectIdMap.Count);
			foreach (KeyValuePair<uint, uint> keyValuePair2 in this.ObjectIdMap)
			{
				writer.WriteVarLen32(keyValuePair2.Value);
				writer.WriteVarLen32(keyValuePair2.Key);
			}
			writer.WriteVarLen32((uint)this.RegionMap.Count);
			foreach (KeyValuePair<string, uint> keyValuePair3 in this.RegionMap)
			{
				writer.WriteVarLen32(keyValuePair3.Value);
				writer.Write(keyValuePair3.Key);
			}
		}

		// Token: 0x04000043 RID: 67
		public readonly Dictionary<uint, uint> TileIdMap = new Dictionary<uint, uint>();

		// Token: 0x04000044 RID: 68
		public readonly Dictionary<uint, uint> ObjectIdMap = new Dictionary<uint, uint>();

		// Token: 0x04000045 RID: 69
		public readonly Dictionary<string, uint> RegionMap = new Dictionary<string, uint>();
	}
}
