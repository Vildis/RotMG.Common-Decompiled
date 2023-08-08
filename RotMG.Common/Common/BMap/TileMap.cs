using System;
using System.IO;
using System.IO.Compression;
using RotMG.Common.IO;

namespace RotMG.Common.BMap
{
	// Token: 0x02000027 RID: 39
	public class TileMap
	{
		// Token: 0x0600014B RID: 331 RVA: 0x000055E3 File Offset: 0x000037E3
		public TileMap(uint w, uint h)
		{
			this.Tiles = new MapTile[(int)((UIntPtr)w), (int)((UIntPtr)h)];
			this.Width = w;
			this.Height = h;
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x0600014C RID: 332 RVA: 0x00005608 File Offset: 0x00003808
		// (set) Token: 0x0600014D RID: 333 RVA: 0x00005610 File Offset: 0x00003810
		public uint Width { get; private set; }

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x0600014E RID: 334 RVA: 0x00005619 File Offset: 0x00003819
		// (set) Token: 0x0600014F RID: 335 RVA: 0x00005621 File Offset: 0x00003821
		public uint Height { get; private set; }

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000150 RID: 336 RVA: 0x0000562A File Offset: 0x0000382A
		// (set) Token: 0x06000151 RID: 337 RVA: 0x00005632 File Offset: 0x00003832
		public MapTile[,] Tiles { get; private set; }

		// Token: 0x06000152 RID: 338 RVA: 0x0000563C File Offset: 0x0000383C
		public void Save(Stream stream)
		{
			using (DeflateStream deflateStream = new DeflateStream(stream, CompressionMode.Compress, true))
			{
				SerializationContext serializationContext = new SerializationContext();
				MemoryStream memoryStream = new MemoryStream();
				VarLenBinaryWriter varLenBinaryWriter = new VarLenBinaryWriter(memoryStream);
				uint width = this.Width;
				uint height = this.Height;
				int num = 0;
				while ((long)num < (long)((ulong)height))
				{
					int num2 = 0;
					while ((long)num2 < (long)((ulong)width))
					{
						this.Tiles[num2, num].WriteTo(varLenBinaryWriter, serializationContext);
						num2++;
					}
					num++;
				}
				varLenBinaryWriter = new VarLenBinaryWriter(deflateStream);
				varLenBinaryWriter.Write(1);
				varLenBinaryWriter.WriteVarLen32(this.Width);
				varLenBinaryWriter.WriteVarLen32(this.Height);
				serializationContext.WriteTo(varLenBinaryWriter);
				memoryStream.Position = 0L;
				memoryStream.CopyTo(deflateStream);
			}
		}

		// Token: 0x06000153 RID: 339 RVA: 0x0000570C File Offset: 0x0000390C
		public static TileMap Load(Stream stream)
		{
			TileMap tileMap2;
			using (DeflateStream deflateStream = new DeflateStream(stream, CompressionMode.Decompress, true))
			{
				VarLenBinaryReader varLenBinaryReader = new VarLenBinaryReader(deflateStream);
				if (varLenBinaryReader.ReadByte() != 1)
				{
					throw new InvalidDataException("Invalid BMap version.");
				}
				TileMap tileMap = new TileMap(varLenBinaryReader.ReadVarLen32(), varLenBinaryReader.ReadVarLen32());
				DeserializationContext deserializationContext = new DeserializationContext();
				deserializationContext.ReadFrom(varLenBinaryReader);
				uint width = tileMap.Width;
				uint height = tileMap.Height;
				MapTile[,] tiles = tileMap.Tiles;
				int num = 0;
				while ((long)num < (long)((ulong)height))
				{
					int num2 = 0;
					while ((long)num2 < (long)((ulong)width))
					{
						MapTile.ReadFrom(ref tiles[num2, num], varLenBinaryReader, deserializationContext);
						num2++;
					}
					num++;
				}
				tileMap2 = tileMap;
			}
			return tileMap2;
		}

		// Token: 0x04000125 RID: 293
		public const byte VERSION = 1;
	}
}
