using System;
using System.Collections;
using System.Collections.Generic;

namespace RotMG.Common
{
	// Token: 0x0200000C RID: 12
	public class SpatialStorage<T> : IEnumerable<T>, IEnumerable where T : class
	{
		// Token: 0x06000030 RID: 48 RVA: 0x000027D8 File Offset: 0x000009D8
		public SpatialStorage(SpatialNodePool<T> pool)
		{
			this.pool = pool;
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00002800 File Offset: 0x00000A00
		public SpatialNode<T> New(T item, float x, float y)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			SpatialNode<T> spatialNode = this.pool.Allocate();
			spatialNode.Storage = this;
			spatialNode.Item = item;
			spatialNode.AddToBucket(x, y);
			this.items.Add(item);
			return spatialNode;
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002850 File Offset: 0x00000A50
		public SpatialNode<T> Query(float x, float y)
		{
			uint num = SpatialNode<T>.HashCoordinates(x, y);
			SpatialNode<T> spatialNode;
			if (this.nodes.TryGetValue(num, out spatialNode))
			{
				return spatialNode;
			}
			return null;
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002878 File Offset: 0x00000A78
		public void HitTest(float x, float y, Action<SpatialNode<T>> onHit)
		{
			SpatialNode<T> spatialNode = this.Query(x, y);
			if (spatialNode != null)
			{
				SpatialNode<T> spatialNode2 = spatialNode;
				do
				{
					onHit(spatialNode2);
					spatialNode2 = spatialNode2.Next;
				}
				while (spatialNode2 != spatialNode);
			}
		}

		// Token: 0x06000034 RID: 52 RVA: 0x000028A5 File Offset: 0x00000AA5
		public IEnumerator<T> GetEnumerator()
		{
			return this.items.GetEnumerator();
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000028B7 File Offset: 0x00000AB7
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.items.GetEnumerator();
		}

		// Token: 0x04000015 RID: 21
		internal SpatialNodePool<T> pool;

		// Token: 0x04000016 RID: 22
		internal HashSet<T> items = new HashSet<T>();

		// Token: 0x04000017 RID: 23
		internal Dictionary<uint, SpatialNode<T>> nodes = new Dictionary<uint, SpatialNode<T>>();
	}
}
