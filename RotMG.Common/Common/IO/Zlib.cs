using System;
using System.IO;
using System.IO.Compression;

namespace RotMG.Common.IO
{
	// Token: 0x0200000B RID: 11
	public static class Zlib
	{
		// Token: 0x0600002E RID: 46 RVA: 0x0000267C File Offset: 0x0000087C
		private static uint ADLER32(byte[] data)
		{
			uint num = 1U;
			uint num2 = 0U;
			for (int i = 0; i < data.Length; i++)
			{
				num = (num + (uint)data[i]) % 65521U;
				num2 = (num2 + num) % 65521U;
			}
			return (num2 << 16) | num;
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000026B8 File Offset: 0x000008B8
		public static byte[] Decompress(byte[] buffer)
		{
			if (buffer.Length < 6)
			{
				throw new ArgumentException("Invalid ZLIB buffer.");
			}
			byte b = buffer[0];
			byte b2 = buffer[1];
			byte b3 = b & 15;
			byte b4 = (byte)(b >> 4);
			if (b3 != 8)
			{
				throw new NotSupportedException("Invalid compression method.");
			}
			if (b4 != 7)
			{
				throw new NotSupportedException("Unsupported window size.");
			}
			bool flag = (b2 & 32) != 0;
			if (flag)
			{
				throw new NotSupportedException("Preset dictionary not supported.");
			}
			if ((((int)b << 8) + (int)b2) % 31 != 0)
			{
				throw new InvalidDataException("Invalid header checksum");
			}
			MemoryStream memoryStream = new MemoryStream(buffer, 2, buffer.Length - 6);
			MemoryStream memoryStream2 = new MemoryStream();
			using (DeflateStream deflateStream = new DeflateStream(memoryStream, CompressionMode.Decompress))
			{
				deflateStream.CopyTo(memoryStream2);
			}
			byte[] array = memoryStream2.ToArray();
			int num = buffer.Length - 4;
			uint num2 = (uint)(((int)buffer[num++] << 24) | ((int)buffer[num++] << 16) | ((int)buffer[num++] << 8) | (int)buffer[num++]);
			if (num2 != Zlib.ADLER32(array))
			{
				throw new InvalidDataException("Invalid data checksum");
			}
			return array;
		}
	}
}
