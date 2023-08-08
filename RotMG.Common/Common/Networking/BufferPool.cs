using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace RotMG.Common.Networking
{
	// Token: 0x0200004F RID: 79
	public class BufferPool
	{
		// Token: 0x0600026D RID: 621 RVA: 0x00008DB8 File Offset: 0x00006FB8
		public BufferPool(int bufferLen, int segmentCount)
		{
			this.bufferLen = bufferLen;
			this.blockSize = segmentCount * bufferLen;
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x0600026E RID: 622 RVA: 0x00008DE6 File Offset: 0x00006FE6
		public int BlockCount
		{
			get
			{
				return this.segments.Count;
			}
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x0600026F RID: 623 RVA: 0x00008DF3 File Offset: 0x00006FF3
		public int SegmentCount
		{
			get
			{
				return this.segments.Count;
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x06000270 RID: 624 RVA: 0x00008E00 File Offset: 0x00007000
		public int BufferLength
		{
			get
			{
				return this.bufferLen;
			}
		}

		// Token: 0x06000271 RID: 625 RVA: 0x00008E08 File Offset: 0x00007008
		private BufferSegment NewBlock()
		{
			BufferSegment bufferSegment3;
			lock (this.blocks)
			{
				byte[] array = new byte[this.blockSize];
				this.blocks.Push(array);
				BufferSegment bufferSegment = default(BufferSegment);
				for (int i = 0; i < this.blockSize; i += this.bufferLen)
				{
					BufferSegment bufferSegment2 = new BufferSegment(array, i);
					if (i == 0)
					{
						bufferSegment = bufferSegment2;
					}
					else
					{
						this.segments.Add(bufferSegment2);
					}
				}
				bufferSegment3 = bufferSegment;
			}
			return bufferSegment3;
		}

		// Token: 0x06000272 RID: 626 RVA: 0x00008EA0 File Offset: 0x000070A0
		public BufferSegment Allocate()
		{
			BufferSegment bufferSegment;
			if (!this.segments.TryTake(out bufferSegment))
			{
				bufferSegment = this.NewBlock();
			}
			return bufferSegment;
		}

		// Token: 0x06000273 RID: 627 RVA: 0x00008EC4 File Offset: 0x000070C4
		public void Release(BufferSegment segment)
		{
			this.segments.Add(segment);
		}

		// Token: 0x06000274 RID: 628 RVA: 0x00008ED2 File Offset: 0x000070D2
		public bool ContainsBlock(byte[] bufferBlock)
		{
			return this.blocks.Contains(bufferBlock);
		}

		// Token: 0x040001D1 RID: 465
		private readonly int blockSize;

		// Token: 0x040001D2 RID: 466
		private readonly Stack<byte[]> blocks = new Stack<byte[]>();

		// Token: 0x040001D3 RID: 467
		private readonly int bufferLen;

		// Token: 0x040001D4 RID: 468
		private readonly ConcurrentBag<BufferSegment> segments = new ConcurrentBag<BufferSegment>();
	}
}
