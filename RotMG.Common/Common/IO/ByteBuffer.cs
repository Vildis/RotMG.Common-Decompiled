using System;
using System.Runtime.InteropServices;
using System.Text;

namespace RotMG.Common.IO
{
	// Token: 0x02000052 RID: 82
	public struct ByteBuffer
	{
		// Token: 0x0600027F RID: 639 RVA: 0x00009124 File Offset: 0x00007324
		public ByteBuffer(byte[] buffer, int index, int length)
		{
			this.buffer = buffer;
			this.index = index;
			this.length = length;
			this.dataEnd = index + length;
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x06000280 RID: 640 RVA: 0x00009144 File Offset: 0x00007344
		public byte[] Buffer
		{
			get
			{
				return this.buffer;
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x06000281 RID: 641 RVA: 0x0000914C File Offset: 0x0000734C
		public int Index
		{
			get
			{
				return this.index;
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x06000282 RID: 642 RVA: 0x00009154 File Offset: 0x00007354
		public int Length
		{
			get
			{
				return this.length;
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06000283 RID: 643 RVA: 0x0000915C File Offset: 0x0000735C
		public bool IsEnd
		{
			get
			{
				return this.index == this.dataEnd;
			}
		}

		// Token: 0x06000284 RID: 644 RVA: 0x0000916C File Offset: 0x0000736C
		internal static IndexOutOfRangeException Overflow()
		{
			throw new IndexOutOfRangeException("Buffer overflow.");
		}

		// Token: 0x06000285 RID: 645 RVA: 0x00009178 File Offset: 0x00007378
		public byte ReadByte()
		{
			if (this.index + 1 > this.dataEnd)
			{
				throw ByteBuffer.Overflow();
			}
			return this.buffer[this.index++];
		}

		// Token: 0x06000286 RID: 646 RVA: 0x000091B3 File Offset: 0x000073B3
		public bool ReadBool()
		{
			return this.ReadByte() != 0;
		}

		// Token: 0x06000287 RID: 647 RVA: 0x000091C4 File Offset: 0x000073C4
		public ushort ReadUInt16()
		{
			if (this.index + 2 > this.dataEnd)
			{
				throw ByteBuffer.Overflow();
			}
			return (ushort)(((int)this.buffer[this.index++] << 8) | (int)this.buffer[this.index++]);
		}

		// Token: 0x06000288 RID: 648 RVA: 0x0000921C File Offset: 0x0000741C
		public uint ReadUInt32()
		{
			if (this.index + 4 > this.dataEnd)
			{
				throw ByteBuffer.Overflow();
			}
			return (uint)(((int)this.buffer[this.index++] << 24) | ((int)this.buffer[this.index++] << 16) | ((int)this.buffer[this.index++] << 8) | (int)this.buffer[this.index++]);
		}

		// Token: 0x06000289 RID: 649 RVA: 0x000092AC File Offset: 0x000074AC
		public ulong ReadUInt64()
		{
			if (this.index + 8 > this.dataEnd)
			{
				throw ByteBuffer.Overflow();
			}
			return (ulong)((long)(((int)this.buffer[this.index++] << 24) | ((int)this.buffer[this.index++] << 16) | ((int)this.buffer[this.index++] << 8) | (int)this.buffer[this.index++] | ((int)this.buffer[this.index++] << 24) | ((int)this.buffer[this.index++] << 16) | ((int)this.buffer[this.index++] << 8) | (int)this.buffer[this.index++]));
		}

		// Token: 0x0600028A RID: 650 RVA: 0x000093B0 File Offset: 0x000075B0
		public float ReadFloat32()
		{
			ByteBuffer.ConversionUnion conversionUnion = default(ByteBuffer.ConversionUnion);
			conversionUnion.UInt32 = this.ReadUInt32();
			return conversionUnion.Float32;
		}

		// Token: 0x0600028B RID: 651 RVA: 0x000093DC File Offset: 0x000075DC
		public double ReadFloat64()
		{
			ByteBuffer.ConversionUnion conversionUnion = default(ByteBuffer.ConversionUnion);
			conversionUnion.UInt64 = (ulong)this.ReadUInt32();
			return conversionUnion.Float64;
		}

		// Token: 0x0600028C RID: 652 RVA: 0x00009408 File Offset: 0x00007608
		public string ReadUTF()
		{
			ushort num = this.ReadUInt16();
			if (this.index + (int)num > this.dataEnd)
			{
				throw ByteBuffer.Overflow();
			}
			string @string = Encoding.UTF8.GetString(this.buffer, this.index, (int)num);
			this.index += (int)num;
			return @string;
		}

		// Token: 0x0600028D RID: 653 RVA: 0x0000945C File Offset: 0x0000765C
		public string ReadUTF32()
		{
			uint num = this.ReadUInt32();
			if ((long)this.index + (long)((ulong)num) > (long)this.dataEnd)
			{
				throw ByteBuffer.Overflow();
			}
			string @string = Encoding.UTF8.GetString(this.buffer, this.index, (int)num);
			this.index += (int)num;
			return @string;
		}

		// Token: 0x0600028E RID: 654 RVA: 0x000094B0 File Offset: 0x000076B0
		public string[] ReadUTF32Array()
		{
			string[] array = new string[(int)this.ReadUInt16()];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = this.ReadUTF32();
			}
			return array;
		}

		// Token: 0x0600028F RID: 655 RVA: 0x000094E4 File Offset: 0x000076E4
		public ArraySegment<byte> ReadBuffer16()
		{
			ushort num = this.ReadUInt16();
			if (this.index + (int)num > this.dataEnd)
			{
				throw ByteBuffer.Overflow();
			}
			ArraySegment<byte> arraySegment = new ArraySegment<byte>(this.buffer, this.index, (int)num);
			this.index += (int)num;
			return arraySegment;
		}

		// Token: 0x06000290 RID: 656 RVA: 0x00009534 File Offset: 0x00007734
		public int[] ReadIntArray()
		{
			ushort num = this.ReadUInt16();
			int[] array = new int[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				array[i] = (int)this.ReadUInt32();
			}
			return array;
		}

		// Token: 0x06000291 RID: 657 RVA: 0x00009568 File Offset: 0x00007768
		public void WriteByte(byte value)
		{
			if (this.index + 1 > this.dataEnd)
			{
				throw ByteBuffer.Overflow();
			}
			this.buffer[this.index++] = value;
		}

		// Token: 0x06000292 RID: 658 RVA: 0x000095A4 File Offset: 0x000077A4
		public void WriteBool(bool value)
		{
			this.WriteByte(value ? 1 : 0);
		}

		// Token: 0x06000293 RID: 659 RVA: 0x000095B4 File Offset: 0x000077B4
		public void WriteUInt16(ushort value)
		{
			if (this.index + 2 > this.dataEnd)
			{
				throw ByteBuffer.Overflow();
			}
			this.buffer[this.index++] = (byte)(value >> 8);
			this.buffer[this.index++] = (byte)value;
		}

		// Token: 0x06000294 RID: 660 RVA: 0x00009610 File Offset: 0x00007810
		public void WriteUInt32(uint value)
		{
			if (this.index + 4 > this.dataEnd)
			{
				throw ByteBuffer.Overflow();
			}
			this.buffer[this.index++] = (byte)(value >> 24);
			this.buffer[this.index++] = (byte)(value >> 16);
			this.buffer[this.index++] = (byte)(value >> 8);
			this.buffer[this.index++] = (byte)value;
		}

		// Token: 0x06000295 RID: 661 RVA: 0x000096A4 File Offset: 0x000078A4
		public void WriteUInt64(ulong value)
		{
			if (this.index + 8 > this.dataEnd)
			{
				throw ByteBuffer.Overflow();
			}
			this.buffer[this.index++] = (byte)(value >> 56);
			this.buffer[this.index++] = (byte)(value >> 48);
			this.buffer[this.index++] = (byte)(value >> 40);
			this.buffer[this.index++] = (byte)(value >> 32);
			this.buffer[this.index++] = (byte)(value >> 24);
			this.buffer[this.index++] = (byte)(value >> 16);
			this.buffer[this.index++] = (byte)(value >> 8);
			this.buffer[this.index++] = (byte)value;
		}

		// Token: 0x06000296 RID: 662 RVA: 0x000097B4 File Offset: 0x000079B4
		public void WriteFloat32(float value)
		{
			ByteBuffer.ConversionUnion conversionUnion = default(ByteBuffer.ConversionUnion);
			conversionUnion.Float32 = value;
			this.WriteUInt32(conversionUnion.UInt32);
		}

		// Token: 0x06000297 RID: 663 RVA: 0x000097E0 File Offset: 0x000079E0
		public void WriteFloat64(float value)
		{
			ByteBuffer.ConversionUnion conversionUnion = default(ByteBuffer.ConversionUnion);
			conversionUnion.Float64 = (double)value;
			this.WriteUInt64(conversionUnion.UInt64);
		}

		// Token: 0x06000298 RID: 664 RVA: 0x0000980C File Offset: 0x00007A0C
		public void WriteUTF(string value)
		{
			int byteCount = Encoding.UTF8.GetByteCount(value);
			if (this.index + 2 + byteCount > this.dataEnd || byteCount > 65535)
			{
				throw ByteBuffer.Overflow();
			}
			this.WriteUInt16((ushort)byteCount);
			Encoding.UTF8.GetBytes(value, 0, value.Length, this.buffer, this.index);
			this.index += byteCount;
		}

		// Token: 0x06000299 RID: 665 RVA: 0x0000987C File Offset: 0x00007A7C
		public void WriteUTF32(string value)
		{
			int byteCount = Encoding.UTF8.GetByteCount(value);
			if (this.index + 4 + byteCount > this.dataEnd)
			{
				throw ByteBuffer.Overflow();
			}
			this.WriteUInt32((uint)((ushort)byteCount));
			Encoding.UTF8.GetBytes(value, 0, value.Length, this.buffer, this.index);
			this.index += byteCount;
		}

		// Token: 0x0600029A RID: 666 RVA: 0x000098E4 File Offset: 0x00007AE4
		public void WriteUTF32Array(string[] array)
		{
			if (array.Length > 65535)
			{
				throw ByteBuffer.Overflow();
			}
			this.WriteUInt16((ushort)array.Length);
			for (int i = 0; i < array.Length; i++)
			{
				this.WriteUTF32(array[i]);
			}
		}

		// Token: 0x0600029B RID: 667 RVA: 0x00009924 File Offset: 0x00007B24
		public void WriteBuffer16(ArraySegment<byte> segment)
		{
			if (segment.Count > 65535)
			{
				throw ByteBuffer.Overflow();
			}
			this.WriteUInt16((ushort)segment.Count);
			System.Buffer.BlockCopy(segment.Array, segment.Offset, this.buffer, this.index, segment.Count);
			this.index += segment.Count;
		}

		// Token: 0x0600029C RID: 668 RVA: 0x00009990 File Offset: 0x00007B90
		public void WriteIntArray(int[] array)
		{
			if (array.Length > 65535)
			{
				throw ByteBuffer.Overflow();
			}
			this.WriteUInt16((ushort)array.Length);
			for (int i = 0; i < array.Length; i++)
			{
				this.WriteUInt32((uint)array[i]);
			}
		}

		// Token: 0x0600029D RID: 669 RVA: 0x000099D0 File Offset: 0x00007BD0
		public byte[] ToByteBuffer()
		{
			byte[] array = new byte[this.dataEnd - this.index];
			System.Buffer.BlockCopy(this.buffer, this.index, array, 0, array.Length);
			return array;
		}

		// Token: 0x040001DA RID: 474
		private readonly byte[] buffer;

		// Token: 0x040001DB RID: 475
		private readonly int dataEnd;

		// Token: 0x040001DC RID: 476
		private readonly int length;

		// Token: 0x040001DD RID: 477
		private int index;

		// Token: 0x02000053 RID: 83
		[StructLayout(LayoutKind.Explicit)]
		private struct ConversionUnion
		{
			// Token: 0x040001DE RID: 478
			[FieldOffset(0)]
			public uint UInt32;

			// Token: 0x040001DF RID: 479
			[FieldOffset(0)]
			public ulong UInt64;

			// Token: 0x040001E0 RID: 480
			[FieldOffset(0)]
			public float Float32;

			// Token: 0x040001E1 RID: 481
			[FieldOffset(0)]
			public double Float64;
		}
	}
}
