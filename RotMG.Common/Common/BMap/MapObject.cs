using System;
using System.Collections.Generic;
using RotMG.Common.IO;

namespace RotMG.Common.BMap
{
	// Token: 0x02000026 RID: 38
	public class MapObject
	{
		// Token: 0x06000148 RID: 328 RVA: 0x000054FC File Offset: 0x000036FC
		internal void WriteTo(VarLenBinaryWriter writer, SerializationContext ctx)
		{
			writer.WriteVarLen32(ctx.GetObjectKey(this.ObjectType));
			writer.WriteVarLen32((uint)this.Attributes.Length);
			foreach (KeyValuePair<string, string> keyValuePair in this.Attributes)
			{
				writer.Write(keyValuePair.Key);
				writer.Write(keyValuePair.Value);
			}
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00005568 File Offset: 0x00003768
		internal MapObject ReadFrom(VarLenBinaryReader reader, DeserializationContext ctx)
		{
			this.ObjectType = ctx.GetObjectId(reader.ReadVarLen32());
			uint num = reader.ReadVarLen32();
			this.Attributes = ((num == 0U) ? Empty<KeyValuePair<string, string>>.Array : new KeyValuePair<string, string>[num]);
			for (int i = 0; i < this.Attributes.Length; i++)
			{
				this.Attributes[i] = new KeyValuePair<string, string>(reader.ReadString(), reader.ReadString());
			}
			return this;
		}

		// Token: 0x04000123 RID: 291
		public KeyValuePair<string, string>[] Attributes;

		// Token: 0x04000124 RID: 292
		public uint ObjectType;
	}
}
