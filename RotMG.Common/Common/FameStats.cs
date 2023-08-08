using System;
using System.Collections.Generic;
using RotMG.Common.IO;

namespace RotMG.Common
{
	// Token: 0x0200001D RID: 29
	public class FameStats
	{
		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000B5 RID: 181 RVA: 0x00003BD9 File Offset: 0x00001DD9
		// (set) Token: 0x060000B6 RID: 182 RVA: 0x00003BE1 File Offset: 0x00001DE1
		public int Shots { get; set; }

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000B7 RID: 183 RVA: 0x00003BEA File Offset: 0x00001DEA
		// (set) Token: 0x060000B8 RID: 184 RVA: 0x00003BF2 File Offset: 0x00001DF2
		public int ShotsThatDamage { get; set; }

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060000B9 RID: 185 RVA: 0x00003BFB File Offset: 0x00001DFB
		// (set) Token: 0x060000BA RID: 186 RVA: 0x00003C03 File Offset: 0x00001E03
		public int SpecialAbilityUses { get; set; }

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060000BB RID: 187 RVA: 0x00003C0C File Offset: 0x00001E0C
		// (set) Token: 0x060000BC RID: 188 RVA: 0x00003C14 File Offset: 0x00001E14
		public int TilesUncovered { get; set; }

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060000BD RID: 189 RVA: 0x00003C1D File Offset: 0x00001E1D
		// (set) Token: 0x060000BE RID: 190 RVA: 0x00003C25 File Offset: 0x00001E25
		public int Teleports { get; set; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060000BF RID: 191 RVA: 0x00003C2E File Offset: 0x00001E2E
		// (set) Token: 0x060000C0 RID: 192 RVA: 0x00003C36 File Offset: 0x00001E36
		public int PotionsDrunk { get; set; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060000C1 RID: 193 RVA: 0x00003C3F File Offset: 0x00001E3F
		// (set) Token: 0x060000C2 RID: 194 RVA: 0x00003C47 File Offset: 0x00001E47
		public int MonsterKills { get; set; }

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060000C3 RID: 195 RVA: 0x00003C50 File Offset: 0x00001E50
		// (set) Token: 0x060000C4 RID: 196 RVA: 0x00003C58 File Offset: 0x00001E58
		public int MonsterAssists { get; set; }

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060000C5 RID: 197 RVA: 0x00003C61 File Offset: 0x00001E61
		// (set) Token: 0x060000C6 RID: 198 RVA: 0x00003C69 File Offset: 0x00001E69
		public int GodKills { get; set; }

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000C7 RID: 199 RVA: 0x00003C72 File Offset: 0x00001E72
		// (set) Token: 0x060000C8 RID: 200 RVA: 0x00003C7A File Offset: 0x00001E7A
		public int GodAssists { get; set; }

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000C9 RID: 201 RVA: 0x00003C83 File Offset: 0x00001E83
		// (set) Token: 0x060000CA RID: 202 RVA: 0x00003C8B File Offset: 0x00001E8B
		public int CubeKills { get; set; }

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000CB RID: 203 RVA: 0x00003C94 File Offset: 0x00001E94
		// (set) Token: 0x060000CC RID: 204 RVA: 0x00003C9C File Offset: 0x00001E9C
		public int OryxKills { get; set; }

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000CD RID: 205 RVA: 0x00003CA5 File Offset: 0x00001EA5
		// (set) Token: 0x060000CE RID: 206 RVA: 0x00003CAD File Offset: 0x00001EAD
		public int QuestsCompleted { get; set; }

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000CF RID: 207 RVA: 0x00003CB6 File Offset: 0x00001EB6
		// (set) Token: 0x060000D0 RID: 208 RVA: 0x00003CBE File Offset: 0x00001EBE
		public int PirateCavesCompleted { get; set; }

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000D1 RID: 209 RVA: 0x00003CC7 File Offset: 0x00001EC7
		// (set) Token: 0x060000D2 RID: 210 RVA: 0x00003CCF File Offset: 0x00001ECF
		public int UndeadLairsCompleted { get; set; }

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060000D3 RID: 211 RVA: 0x00003CD8 File Offset: 0x00001ED8
		// (set) Token: 0x060000D4 RID: 212 RVA: 0x00003CE0 File Offset: 0x00001EE0
		public int AbyssOfDemonsCompleted { get; set; }

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060000D5 RID: 213 RVA: 0x00003CE9 File Offset: 0x00001EE9
		// (set) Token: 0x060000D6 RID: 214 RVA: 0x00003CF1 File Offset: 0x00001EF1
		public int SnakePitsCompleted { get; set; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060000D7 RID: 215 RVA: 0x00003CFA File Offset: 0x00001EFA
		// (set) Token: 0x060000D8 RID: 216 RVA: 0x00003D02 File Offset: 0x00001F02
		public int SpiderDensCompleted { get; set; }

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060000D9 RID: 217 RVA: 0x00003D0B File Offset: 0x00001F0B
		// (set) Token: 0x060000DA RID: 218 RVA: 0x00003D13 File Offset: 0x00001F13
		public int SpriteWorldsCompleted { get; set; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060000DB RID: 219 RVA: 0x00003D1C File Offset: 0x00001F1C
		// (set) Token: 0x060000DC RID: 220 RVA: 0x00003D24 File Offset: 0x00001F24
		public int LevelUpAssists { get; set; }

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060000DD RID: 221 RVA: 0x00003D2D File Offset: 0x00001F2D
		// (set) Token: 0x060000DE RID: 222 RVA: 0x00003D35 File Offset: 0x00001F35
		public int MinutesActive { get; set; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060000DF RID: 223 RVA: 0x00003D3E File Offset: 0x00001F3E
		// (set) Token: 0x060000E0 RID: 224 RVA: 0x00003D46 File Offset: 0x00001F46
		public int TombsCompleted { get; set; }

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060000E1 RID: 225 RVA: 0x00003D4F File Offset: 0x00001F4F
		// (set) Token: 0x060000E2 RID: 226 RVA: 0x00003D57 File Offset: 0x00001F57
		public int TrenchesCompleted { get; set; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060000E3 RID: 227 RVA: 0x00003D60 File Offset: 0x00001F60
		// (set) Token: 0x060000E4 RID: 228 RVA: 0x00003D68 File Offset: 0x00001F68
		public int JunglesCompleted { get; set; }

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060000E5 RID: 229 RVA: 0x00003D71 File Offset: 0x00001F71
		// (set) Token: 0x060000E6 RID: 230 RVA: 0x00003D79 File Offset: 0x00001F79
		public int ManorsCompleted { get; set; }

		// Token: 0x060000E7 RID: 231 RVA: 0x00003D82 File Offset: 0x00001F82
		private static Tuple<Func<FameStats, int>, Action<FameStats, int>> Entry(Func<FameStats, int> getter, Action<FameStats, int> setter)
		{
			return Tuple.Create<Func<FameStats, int>, Action<FameStats, int>>(getter, setter);
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00003D8C File Offset: 0x00001F8C
		public static FameStats Read(byte[] statsData)
		{
			FameStats fameStats = new FameStats();
			ByteBuffer byteBuffer = new ByteBuffer(statsData, 0, statsData.Length);
			while (!byteBuffer.IsEnd)
			{
				byte b = byteBuffer.ReadByte();
				FameStats.statList[b].Item2(fameStats, (int)byteBuffer.ReadUInt32());
			}
			return fameStats;
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00003DDC File Offset: 0x00001FDC
		public byte[] Write()
		{
			int num = 0;
			foreach (KeyValuePair<byte, Tuple<Func<FameStats, int>, Action<FameStats, int>>> keyValuePair in FameStats.statList)
			{
				if (keyValuePair.Value.Item1(this) != 0)
				{
					num += 5;
				}
			}
			byte[] array = new byte[num];
			ByteBuffer byteBuffer = new ByteBuffer(array, 0, array.Length);
			foreach (KeyValuePair<byte, Tuple<Func<FameStats, int>, Action<FameStats, int>>> keyValuePair2 in FameStats.statList)
			{
				int num2 = keyValuePair2.Value.Item1(this);
				if (num2 != 0)
				{
					byteBuffer.WriteByte(keyValuePair2.Key);
					byteBuffer.WriteUInt32((uint)num2);
				}
			}
			return array;
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00004070 File Offset: 0x00002270
		// Note: this type is marked as 'beforefieldinit'.
		static FameStats()
		{
			Dictionary<byte, Tuple<Func<FameStats, int>, Action<FameStats, int>>> dictionary = new Dictionary<byte, Tuple<Func<FameStats, int>, Action<FameStats, int>>>();
			dictionary.Add(0, FameStats.Entry((FameStats s) => s.Shots, delegate(FameStats s, int val)
			{
				s.Shots = val;
			}));
			dictionary.Add(1, FameStats.Entry((FameStats s) => s.ShotsThatDamage, delegate(FameStats s, int val)
			{
				s.ShotsThatDamage = val;
			}));
			dictionary.Add(2, FameStats.Entry((FameStats s) => s.SpecialAbilityUses, delegate(FameStats s, int val)
			{
				s.SpecialAbilityUses = val;
			}));
			dictionary.Add(3, FameStats.Entry((FameStats s) => s.TilesUncovered, delegate(FameStats s, int val)
			{
				s.TilesUncovered = val;
			}));
			dictionary.Add(4, FameStats.Entry((FameStats s) => s.Teleports, delegate(FameStats s, int val)
			{
				s.Teleports = val;
			}));
			dictionary.Add(5, FameStats.Entry((FameStats s) => s.PotionsDrunk, delegate(FameStats s, int val)
			{
				s.PotionsDrunk = val;
			}));
			dictionary.Add(6, FameStats.Entry((FameStats s) => s.MonsterKills, delegate(FameStats s, int val)
			{
				s.MonsterKills = val;
			}));
			dictionary.Add(7, FameStats.Entry((FameStats s) => s.MonsterAssists, delegate(FameStats s, int val)
			{
				s.MonsterAssists = val;
			}));
			dictionary.Add(8, FameStats.Entry((FameStats s) => s.GodKills, delegate(FameStats s, int val)
			{
				s.GodKills = val;
			}));
			dictionary.Add(9, FameStats.Entry((FameStats s) => s.GodAssists, delegate(FameStats s, int val)
			{
				s.GodAssists = val;
			}));
			dictionary.Add(10, FameStats.Entry((FameStats s) => s.CubeKills, delegate(FameStats s, int val)
			{
				s.CubeKills = val;
			}));
			dictionary.Add(11, FameStats.Entry((FameStats s) => s.OryxKills, delegate(FameStats s, int val)
			{
				s.OryxKills = val;
			}));
			dictionary.Add(12, FameStats.Entry((FameStats s) => s.QuestsCompleted, delegate(FameStats s, int val)
			{
				s.QuestsCompleted = val;
			}));
			dictionary.Add(13, FameStats.Entry((FameStats s) => s.PirateCavesCompleted, delegate(FameStats s, int val)
			{
				s.PirateCavesCompleted = val;
			}));
			dictionary.Add(14, FameStats.Entry((FameStats s) => s.UndeadLairsCompleted, delegate(FameStats s, int val)
			{
				s.UndeadLairsCompleted = val;
			}));
			dictionary.Add(15, FameStats.Entry((FameStats s) => s.AbyssOfDemonsCompleted, delegate(FameStats s, int val)
			{
				s.AbyssOfDemonsCompleted = val;
			}));
			dictionary.Add(16, FameStats.Entry((FameStats s) => s.SnakePitsCompleted, delegate(FameStats s, int val)
			{
				s.SnakePitsCompleted = val;
			}));
			dictionary.Add(17, FameStats.Entry((FameStats s) => s.SpiderDensCompleted, delegate(FameStats s, int val)
			{
				s.SpiderDensCompleted = val;
			}));
			dictionary.Add(18, FameStats.Entry((FameStats s) => s.SpriteWorldsCompleted, delegate(FameStats s, int val)
			{
				s.SpriteWorldsCompleted = val;
			}));
			dictionary.Add(19, FameStats.Entry((FameStats s) => s.LevelUpAssists, delegate(FameStats s, int val)
			{
				s.LevelUpAssists = val;
			}));
			dictionary.Add(20, FameStats.Entry((FameStats s) => s.MinutesActive, delegate(FameStats s, int val)
			{
				s.MinutesActive = val;
			}));
			dictionary.Add(21, FameStats.Entry((FameStats s) => s.TombsCompleted, delegate(FameStats s, int val)
			{
				s.TombsCompleted = val;
			}));
			dictionary.Add(22, FameStats.Entry((FameStats s) => s.TrenchesCompleted, delegate(FameStats s, int val)
			{
				s.TrenchesCompleted = val;
			}));
			dictionary.Add(23, FameStats.Entry((FameStats s) => s.JunglesCompleted, delegate(FameStats s, int val)
			{
				s.JunglesCompleted = val;
			}));
			dictionary.Add(24, FameStats.Entry((FameStats s) => s.ManorsCompleted, delegate(FameStats s, int val)
			{
				s.ManorsCompleted = val;
			}));
			FameStats.statList = dictionary;
		}

		// Token: 0x04000069 RID: 105
		private static readonly Dictionary<byte, Tuple<Func<FameStats, int>, Action<FameStats, int>>> statList;
	}
}
