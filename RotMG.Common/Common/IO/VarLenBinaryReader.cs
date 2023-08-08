using System;
using System.IO;
using System.Text;

namespace RotMG.Common.IO
{
	// Token: 0x02000024 RID: 36
	public class VarLenBinaryReader : BinaryReader
	{
		// Token: 0x06000142 RID: 322 RVA: 0x00005453 File Offset: 0x00003653
		public VarLenBinaryReader(Stream stream)
			: base(stream)
		{
		}

		// Token: 0x06000143 RID: 323 RVA: 0x0000545C File Offset: 0x0000365C
		public VarLenBinaryReader(Stream stream, Encoding encoding)
			: base(stream, encoding)
		{
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00005468 File Offset: 0x00003668
		public uint ReadVarLen32()
		{
			byte b = this.ReadByte();
			uint num = (uint)(b & 127);
			int num2 = 7;
			while ((b & 128) != 0)
			{
				b = this.ReadByte();
				num |= (uint)((uint)(b & 127) << num2);
				num2 += 7;
			}
			return num;
		}
	}
}
