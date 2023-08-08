using System;
using RotMG.Common.Networking.Data;
using RotMG.Common.Networking.IO;

namespace RotMG.Common.Networking.Packets
{
	// Token: 0x02000039 RID: 57
	public class PacketUPDATE : Packet
	{
		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060001C2 RID: 450 RVA: 0x0000680C File Offset: 0x00004A0C
		public override PacketId Id
		{
			get
			{
				return PacketId.UPDATE;
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060001C3 RID: 451 RVA: 0x0000680F File Offset: 0x00004A0F
		// (set) Token: 0x060001C4 RID: 452 RVA: 0x00006817 File Offset: 0x00004A17
		public TileData[] Tiles { get; set; }

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x060001C5 RID: 453 RVA: 0x00006820 File Offset: 0x00004A20
		// (set) Token: 0x060001C6 RID: 454 RVA: 0x00006828 File Offset: 0x00004A28
		public ObjectDef[] NewObjects { get; set; }

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x060001C7 RID: 455 RVA: 0x00006831 File Offset: 0x00004A31
		// (set) Token: 0x060001C8 RID: 456 RVA: 0x00006839 File Offset: 0x00004A39
		public int[] RemovedObjectIds { get; set; }

		// Token: 0x060001C9 RID: 457 RVA: 0x00006923 File Offset: 0x00004B23
		public static void InitIO()
		{
			DataTypeIO.Init<PacketUPDATE>(delegate(InitDataTypeIO<PacketUPDATE> init)
			{
				init.Field<TileData[]>((PacketUPDATE p) => p.Tiles, FieldType.DataArray).Field<ObjectDef[]>((PacketUPDATE p) => p.NewObjects, FieldType.DataArray).Field<int[]>((PacketUPDATE p) => p.RemovedObjectIds, FieldType.IntArray)
					.End();
			});
		}
	}
}
