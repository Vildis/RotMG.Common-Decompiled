using System;
using RotMG.Common.IO;

namespace RotMG.Common.BMap
{
	// Token: 0x02000035 RID: 53
	public struct MapTile
	{
		// Token: 0x060001A7 RID: 423 RVA: 0x00006218 File Offset: 0x00004418
		internal void WriteTo(VarLenBinaryWriter writer, SerializationContext ctx)
		{
			writer.WriteVarLen32(ctx.GetTileKey(this.TileType));
			writer.WriteVarLen32((uint)this.Biome);
			writer.Write(this.Elevation);
			writer.Write(this.Moisture);
			writer.WriteVarLen32((uint)this.Objects.Length);
			foreach (MapObject mapObject in this.Objects)
			{
				mapObject.WriteTo(writer, ctx);
			}
			writer.WriteVarLen32(ctx.GetRegionKey(this.Region));
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x0000629C File Offset: 0x0000449C
		internal static void ReadFrom(ref MapTile tile, VarLenBinaryReader reader, DeserializationContext ctx)
		{
			tile.TileType = ctx.GetTileId(reader.ReadVarLen32());
			tile.Biome = (MapBiome)reader.ReadVarLen32();
			tile.Elevation = reader.ReadSingle();
			tile.Moisture = reader.ReadSingle();
			uint num = reader.ReadVarLen32();
			tile.Objects = ((num == 0U) ? Empty<MapObject>.Array : new MapObject[num]);
			for (int i = 0; i < tile.Objects.Length; i++)
			{
				tile.Objects[i] = new MapObject().ReadFrom(reader, ctx);
			}
			tile.Region = ctx.GetRegionId(reader.ReadVarLen32());
		}

		// Token: 0x04000168 RID: 360
		public uint TileType;

		// Token: 0x04000169 RID: 361
		public MapBiome Biome;

		// Token: 0x0400016A RID: 362
		public float Elevation;

		// Token: 0x0400016B RID: 363
		public float Moisture;

		// Token: 0x0400016C RID: 364
		public MapObject[] Objects;

		// Token: 0x0400016D RID: 365
		public string Region;
	}
}
