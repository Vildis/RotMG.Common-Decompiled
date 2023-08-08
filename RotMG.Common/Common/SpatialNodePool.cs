using System;
using System.Collections.Concurrent;

namespace RotMG.Common
{
	// Token: 0x0200000E RID: 14
	public class SpatialNodePool<T> where T : class
	{
		// Token: 0x06000046 RID: 70 RVA: 0x00002AE4 File Offset: 0x00000CE4
		internal SpatialNode<T> Allocate()
		{
			SpatialNode<T> spatialNode;
			if (!this.pool.TryTake(out spatialNode))
			{
				spatialNode = new SpatialNode<T>();
			}
			return spatialNode;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00002B08 File Offset: 0x00000D08
		internal void Release(SpatialNode<T> node)
		{
			node.Item = default(T);
			node.Hash = 0U;
			node.Storage = null;
			node.Next = null;
			node.Previous = null;
			this.pool.Add(node);
		}

		// Token: 0x0400001D RID: 29
		private readonly ConcurrentBag<SpatialNode<T>> pool = new ConcurrentBag<SpatialNode<T>>();
	}
}
