using System;
using RotMG.Common.IO;
using RotMG.Common.Networking.IO;
using RotMG.Data;

namespace RotMG.Common.Networking.Data
{
	// Token: 0x02000043 RID: 67
	[DataType]
	public struct StatEntry
	{
		// Token: 0x06000203 RID: 515 RVA: 0x0000738A File Offset: 0x0000558A
		public StatEntry(StatData stat, int value)
		{
			this.StatType = stat;
			this.ValueInt = value;
			this.ValueString = null;
		}

		// Token: 0x06000204 RID: 516 RVA: 0x000073A1 File Offset: 0x000055A1
		public StatEntry(StatData stat, string value)
		{
			this.StatType = stat;
			this.ValueInt = 0;
			this.ValueString = value;
		}

		// Token: 0x06000205 RID: 517 RVA: 0x000073B8 File Offset: 0x000055B8
		public static bool IsString(StatData stat)
		{
			if (stat <= StatData.AccountId)
			{
				if (stat != StatData.Name && stat != StatData.AccountId)
				{
					return false;
				}
			}
			else if (stat != StatData.OwnerAccountId && stat != StatData.Guild && stat != StatData.PetName)
			{
				return false;
			}
			return true;
		}

		// Token: 0x06000206 RID: 518 RVA: 0x000073EC File Offset: 0x000055EC
		public static StatEntry Load(ref ByteBuffer buffer)
		{
			StatEntry statEntry = default(StatEntry);
			statEntry.StatType = (StatData)buffer.ReadByte();
			if (StatEntry.IsString(statEntry.StatType))
			{
				statEntry.ValueString = buffer.ReadUTF();
			}
			else
			{
				statEntry.ValueInt = (int)buffer.ReadUInt32();
			}
			return statEntry;
		}

		// Token: 0x06000207 RID: 519 RVA: 0x00007439 File Offset: 0x00005639
		public static void Save(ref ByteBuffer buffer, StatEntry entry)
		{
			buffer.WriteByte((byte)entry.StatType);
			if (entry.ValueString != null)
			{
				buffer.WriteUTF(entry.ValueString);
				return;
			}
			buffer.WriteUInt32((uint)entry.ValueInt);
		}

		// Token: 0x06000208 RID: 520 RVA: 0x00007470 File Offset: 0x00005670
		public static int SizeOf(StatEntry entry)
		{
			if (entry.ValueString != null)
			{
				int num = 1;
				IOHelper.NextUTF(ref num, entry.ValueString);
				return num;
			}
			return 5;
		}

		// Token: 0x0400019B RID: 411
		public StatData StatType;

		// Token: 0x0400019C RID: 412
		public int ValueInt;

		// Token: 0x0400019D RID: 413
		public string ValueString;
	}
}
