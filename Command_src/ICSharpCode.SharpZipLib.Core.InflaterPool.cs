using System;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using ICSharpCode.SharpZipLib.Zip.Compression;

namespace ICSharpCode.SharpZipLib.Core;

internal sealed class InflaterPool
{
	private readonly ConcurrentQueue<PooledInflater> concurrentQueue_0 = new ConcurrentQueue<PooledInflater>();

	private readonly ConcurrentQueue<PooledInflater> concurrentQueue_1 = new ConcurrentQueue<PooledInflater>();

	[CompilerGenerated]
	private static readonly InflaterPool inflaterPool_0;

	internal static InflaterPool Instance
	{
		[CompilerGenerated]
		get
		{
			return inflaterPool_0;
		}
	}

	private InflaterPool()
	{
	}

	internal Inflater Rent(bool noHeader = false)
	{
		if (SharpZipLibOptions.InflaterPoolSize > 0)
		{
			PooledInflater pooledInflater;
			if (method_0(noHeader).TryDequeue(out var result))
			{
				pooledInflater = result;
				pooledInflater.Reset();
			}
			else
			{
				pooledInflater = new PooledInflater(noHeader);
			}
			return pooledInflater;
		}
		return new Inflater(noHeader);
	}

	internal void Return(Inflater inflater)
	{
		if (SharpZipLibOptions.InflaterPoolSize > 0)
		{
			if (!(inflater is PooledInflater pooledInflater))
			{
				throw new ArgumentException("Returned inflater was not a pooled one");
			}
			ConcurrentQueue<PooledInflater> concurrentQueue = method_0(inflater.noHeader);
			if (concurrentQueue.Count < SharpZipLibOptions.InflaterPoolSize)
			{
				pooledInflater.Reset();
				concurrentQueue.Enqueue(pooledInflater);
			}
		}
	}

	private ConcurrentQueue<PooledInflater> method_0(bool bool_0)
	{
		if (bool_0)
		{
			return concurrentQueue_0;
		}
		return concurrentQueue_1;
	}

	static InflaterPool()
	{
		Class72.smethod_20();
		inflaterPool_0 = new InflaterPool();
	}
}
