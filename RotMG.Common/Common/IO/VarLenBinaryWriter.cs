using System;
using System.IO;
using System.Text;

namespace RotMG.Common.IO
{
	// Token: 0x02000025 RID: 37
	internal class VarLenBinaryWriter : BinaryWriter
	{
		// Token: 0x06000145 RID: 325 RVA: 0x000054A6 File Offset: 0x000036A6
		public VarLenBinaryWriter(Stream stream)
			: base(stream)
		{
		}

		// Token: 0x06000146 RID: 326 RVA: 0x000054AF File Offset: 0x000036AF
		public VarLenBinaryWriter(Stream stream, Encoding encoding)
			: base(stream, encoding)
		{
		}

		// Token: 0x06000147 RID: 327 RVA: 0x000054BC File Offset: 0x000036BC
		public void WriteVarLen32(uint value)
		{
			uint num = value & 127U;
			for (value >>= 7; value != 0U; value >>= 7)
			{
				num |= 128U;
				this.Write((byte)num);
				num = value & 127U;
			}
			this.Write((byte)num);
		}
	}
}
