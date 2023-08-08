using System;

namespace RotMG.Common
{
	// Token: 0x0200000D RID: 13
	public class SpatialNode<T> where T : class
	{
		// Token: 0x06000036 RID: 54 RVA: 0x000028C9 File Offset: 0x00000AC9
		internal SpatialNode()
		{
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000037 RID: 55 RVA: 0x000028D1 File Offset: 0x00000AD1
		// (set) Token: 0x06000038 RID: 56 RVA: 0x000028D9 File Offset: 0x00000AD9
		public T Item { get; internal set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000039 RID: 57 RVA: 0x000028E2 File Offset: 0x00000AE2
		// (set) Token: 0x0600003A RID: 58 RVA: 0x000028EA File Offset: 0x00000AEA
		public uint Hash { get; internal set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600003B RID: 59 RVA: 0x000028F3 File Offset: 0x00000AF3
		// (set) Token: 0x0600003C RID: 60 RVA: 0x000028FB File Offset: 0x00000AFB
		public SpatialStorage<T> Storage { get; internal set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600003D RID: 61 RVA: 0x00002904 File Offset: 0x00000B04
		// (set) Token: 0x0600003E RID: 62 RVA: 0x0000290C File Offset: 0x00000B0C
		public SpatialNode<T> Next { get; internal set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600003F RID: 63 RVA: 0x00002915 File Offset: 0x00000B15
		// (set) Token: 0x06000040 RID: 64 RVA: 0x0000291D File Offset: 0x00000B1D
		public SpatialNode<T> Previous { get; internal set; }

		// Token: 0x06000041 RID: 65 RVA: 0x00002926 File Offset: 0x00000B26
		internal static uint HashCoordinates(float x, float y)
		{
			return ((uint)x << 16) | (uint)y;
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00002930 File Offset: 0x00000B30
		internal void AddToBucket(float x, float y)
		{
			this.Hash = SpatialNode<T>.HashCoordinates(x, y);
			SpatialNode<T> spatialNode;
			if (this.Storage.nodes.TryGetValue(this.Hash, out spatialNode))
			{
				SpatialNode<T> next = spatialNode.Next;
				spatialNode.Next = this;
				next.Previous = this;
				this.Next = next;
				this.Previous = spatialNode;
				return;
			}
			this.Next = this;
			this.Previous = this;
			this.Storage.nodes[this.Hash] = this;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x000029B0 File Offset: 0x00000BB0
		private void RemoveFromBucket()
		{
			if (this.Storage.nodes[this.Hash] != this)
			{
				this.Next.Previous = this.Previous;
				this.Previous.Next = this.Next;
				return;
			}
			if (this.Next != this)
			{
				this.Next.Previous = this.Previous;
				this.Previous.Next = this.Next;
				this.Storage.nodes[this.Hash] = this.Next;
				return;
			}
			this.Storage.nodes.Remove(this.Hash);
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00002A58 File Offset: 0x00000C58
		public void Remove()
		{
			if (this.Item == null)
			{
				throw new InvalidOperationException("Node is already released.");
			}
			this.RemoveFromBucket();
			this.Storage.items.Remove(this.Item);
			this.Storage.pool.Release(this);
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00002AAB File Offset: 0x00000CAB
		public void Move(float x, float y)
		{
			if (this.Item == null)
			{
				throw new InvalidOperationException("Node is already released.");
			}
			if (this.Hash == SpatialNode<T>.HashCoordinates(x, y))
			{
				return;
			}
			this.RemoveFromBucket();
			this.AddToBucket(x, y);
		}
	}
}
