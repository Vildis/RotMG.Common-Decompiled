using System;

namespace RotMG.Common
{
	// Token: 0x0200003B RID: 59
	public static class GuestNames
	{
		// Token: 0x060001CD RID: 461 RVA: 0x00006958 File Offset: 0x00004B58
		public static string GetName(string uuid)
		{
			uint num = 21U;
			foreach (char c in uuid)
			{
				num = num * 7U + (uint)c;
			}
			checked
			{
				return GuestNames.guestNames[(int)((IntPtr)(unchecked((ulong)num % (ulong)((long)GuestNames.guestNames.Length))))];
			}
		}

		// Token: 0x0400017F RID: 383
		private static readonly string[] guestNames = new string[]
		{
			"Darq", "Deyst", "Drac", "Drol", "Eango", "Eashy", "Eati", "Eendi", "Ehoni", "Gharr",
			"Iatho", "Iawa", "Idrae", "Iri", "Issz", "Itani", "Laen", "Lauk", "Lorz", "Oalei",
			"Odaru", "Oeti", "Orothi", "Oshyu", "Queq", "Radph", "Rayr", "Ril", "Rilr", "Risrr",
			"Saylt", "Scheev", "Sek", "Serl", "Seus", "Tal", "Tiar", "Uoro", "Urake", "Utanu",
			"Vorck", "Vorv", "Yangu", "Yimi", "Zhiar"
		};
	}
}
