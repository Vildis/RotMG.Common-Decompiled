using System;
using System.Globalization;

namespace RotMG.Common.Crypto
{
	// Token: 0x02000036 RID: 54
	public class RC4
	{
		// Token: 0x060001A9 RID: 425 RVA: 0x00006337 File Offset: 0x00004537
		public RC4(byte[] key)
		{
			this.Initialize(key);
		}

		// Token: 0x060001AA RID: 426 RVA: 0x00006348 File Offset: 0x00004548
		public RC4(string key)
		{
			byte[] array = new byte[key.Length >> 1];
			for (int i = 0; i < key.Length; i += 2)
			{
				array[i >> 1] = byte.Parse(key.Substring(i, 2), NumberStyles.HexNumber);
			}
			this.Initialize(array);
		}

		// Token: 0x060001AB RID: 427 RVA: 0x00006398 File Offset: 0x00004598
		private void Initialize(byte[] key)
		{
			this.state = new byte[256];
			for (int i = 0; i < 256; i++)
			{
				this.state[i] = (byte)i;
			}
			byte b = 0;
			for (int j = 0; j < 256; j++)
			{
				b += this.state[j] + key[j % key.Length];
				Utils.Swap<byte>(ref this.state[j], ref this.state[(int)b]);
			}
			this.I = 0;
			this.J = 0;
		}

		// Token: 0x060001AC RID: 428 RVA: 0x00006424 File Offset: 0x00004624
		public void Process(byte[] buffer, int offset, int length)
		{
			int num = offset + length;
			for (int i = offset; i < num; i++)
			{
				this.I += 1;
				this.J += this.state[(int)this.I];
				Utils.Swap<byte>(ref this.state[(int)this.I], ref this.state[(int)this.J]);
				byte b = this.state[(int)(this.state[(int)this.I] + this.state[(int)this.J])];
				int num2 = i;
				buffer[num2] ^= b;
			}
		}

		// Token: 0x0400016E RID: 366
		private byte I;

		// Token: 0x0400016F RID: 367
		private byte J;

		// Token: 0x04000170 RID: 368
		private byte[] state;
	}
}
