using System;
using System.Configuration;

namespace RotMG.Common
{
	// Token: 0x02000032 RID: 50
	public class RotMGConfig : ConfigurationSection
	{
		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000196 RID: 406 RVA: 0x00005FE0 File Offset: 0x000041E0
		public static RotMGConfig Config
		{
			get
			{
				return RotMGConfig.config;
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000197 RID: 407 RVA: 0x00005FE7 File Offset: 0x000041E7
		[ConfigurationProperty("resourcesLocation", IsRequired = true)]
		public string ResourcesLocation
		{
			get
			{
				return (string)base["resourcesLocation"];
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000198 RID: 408 RVA: 0x00005FF9 File Offset: 0x000041F9
		[ConfigurationProperty("dbConnectionString", IsRequired = true)]
		public string DatabaseConnectionString
		{
			get
			{
				return (string)base["dbConnectionString"];
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06000199 RID: 409 RVA: 0x0000600B File Offset: 0x0000420B
		[ConfigurationProperty("redisConfig", IsRequired = true)]
		public string RedisConfig
		{
			get
			{
				return (string)base["redisConfig"];
			}
		}

		// Token: 0x04000167 RID: 359
		private static readonly RotMGConfig config = (RotMGConfig)ConfigurationManager.GetSection("RotMG");
	}
}
