using System;
using System.Text;
using RotMG.Common.IO;

namespace RotMG.Common.Networking.IO
{
	// Token: 0x02000033 RID: 51
	internal static class IOHelper
	{
		// Token: 0x0600019C RID: 412 RVA: 0x0000603C File Offset: 0x0000423C
		public static void NextUTF(ref int index, string value)
		{
			int byteCount = Encoding.UTF8.GetByteCount(value);
			index += byteCount + 2;
		}

		// Token: 0x0600019D RID: 413 RVA: 0x00006060 File Offset: 0x00004260
		public static void NextUTF32(ref int index, string value)
		{
			int byteCount = Encoding.UTF8.GetByteCount(value);
			index += byteCount + 4;
		}

		// Token: 0x0600019E RID: 414 RVA: 0x00006084 File Offset: 0x00004284
		public static void NextUTF32Array(ref int index, string[] array)
		{
			index += 2;
			for (int i = 0; i < array.Length; i++)
			{
				int byteCount = Encoding.UTF8.GetByteCount(array[i]);
				index += byteCount + 4;
			}
		}

		// Token: 0x0600019F RID: 415 RVA: 0x000060BB File Offset: 0x000042BB
		public static void NextIntArray(ref int index, int[] array)
		{
			index += 2 + (array.Length << 2);
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x000060C9 File Offset: 0x000042C9
		public static void NextBuffer16(ref int index, ArraySegment<byte> segment)
		{
			index += 2 + segment.Count;
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x000060DC File Offset: 0x000042DC
		public static T[] ReadDataArray<T>(ref ByteBuffer buffer)
		{
			T[] array = new T[(int)buffer.ReadUInt16()];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = DataTypeIO.Load<T>(ref buffer);
			}
			return array;
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x00006114 File Offset: 0x00004314
		public static void WriteDataArray<T>(ref ByteBuffer buffer, T[] array)
		{
			if (array.Length > 65535)
			{
				throw ByteBuffer.Overflow();
			}
			buffer.WriteUInt16((ushort)array.Length);
			for (int i = 0; i < array.Length; i++)
			{
				DataTypeIO.Save<T>(ref buffer, array[i]);
			}
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x00006158 File Offset: 0x00004358
		public static int SizeOfDataArray<T>(T[] array)
		{
			int num = 2;
			for (int i = 0; i < array.Length; i++)
			{
				num += DataTypeIO.SizeOf<T>(array[i]);
			}
			return num;
		}
	}
}
