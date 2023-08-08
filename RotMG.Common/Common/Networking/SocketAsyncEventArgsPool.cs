using System;
using System.Collections.Concurrent;
using System.Net.Sockets;

namespace RotMG.Common.Networking
{
	// Token: 0x0200003C RID: 60
	public class SocketAsyncEventArgsPool
	{
		// Token: 0x060001CF RID: 463 RVA: 0x00006B44 File Offset: 0x00004D44
		public SocketAsyncEventArgsPool(int initialCount, Func<SocketAsyncEventArgs> allocateNewFunc)
		{
			this.allocateNewFunc = allocateNewFunc;
			for (int i = 0; i < initialCount; i++)
			{
				this.pool.Add(allocateNewFunc());
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x060001D0 RID: 464 RVA: 0x00006B86 File Offset: 0x00004D86
		public int Count
		{
			get
			{
				return this.pool.Count;
			}
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x00006B94 File Offset: 0x00004D94
		public SocketAsyncEventArgs Allocate()
		{
			SocketAsyncEventArgs socketAsyncEventArgs;
			if (!this.pool.TryTake(out socketAsyncEventArgs))
			{
				socketAsyncEventArgs = this.allocateNewFunc();
			}
			return socketAsyncEventArgs;
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x00006BBD File Offset: 0x00004DBD
		public void Release(SocketAsyncEventArgs args)
		{
			args.SetBuffer(null, 0, 0);
			args.UserToken = null;
			this.pool.Add(args);
		}

		// Token: 0x04000180 RID: 384
		private readonly ConcurrentBag<SocketAsyncEventArgs> pool = new ConcurrentBag<SocketAsyncEventArgs>();

		// Token: 0x04000181 RID: 385
		private Func<SocketAsyncEventArgs> allocateNewFunc;
	}
}
