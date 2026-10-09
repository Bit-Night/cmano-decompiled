using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using DiskQueue.Implementation;

namespace DiskQueue;

public sealed class PersistentQueue : IPersistentQueue, IDisposable
{
	private PersistentQueueImpl persistentQueueImpl_0;

	public int EstimatedCountOfItemsInQueue => persistentQueueImpl_0.EstimatedCountOfItemsInQueue;

	public GInterface4 Internals => persistentQueueImpl_0;

	public int MaxFileSize => persistentQueueImpl_0.MaxFileSize;

	public long SuggestedMaxTransactionLogSize
	{
		get
		{
			return persistentQueueImpl_0.SuggestedMaxTransactionLogSize;
		}
		set
		{
			persistentQueueImpl_0.SuggestedMaxTransactionLogSize = value;
		}
	}

	public bool TrimTransactionLogOnDispose
	{
		get
		{
			return persistentQueueImpl_0.TrimTransactionLogOnDispose;
		}
		set
		{
			persistentQueueImpl_0.TrimTransactionLogOnDispose = value;
		}
	}

	public static IPersistentQueue WaitFor(string storagePath, TimeSpan maxWait)
	{
		Stopwatch stopwatch = new Stopwatch();
		try
		{
			stopwatch.Start();
			do
			{
				try
				{
					return new PersistentQueue(storagePath);
				}
				catch (DirectoryNotFoundException)
				{
					throw new Exception("Target storagePath does not exist or is not accessible");
				}
				catch (PlatformNotSupportedException ex2)
				{
					Console.WriteLine("Blocked by " + ex2.GetType().Name + "; " + ex2.Message + "\r\n\r\n" + ex2.StackTrace);
					throw;
				}
				catch
				{
					Thread.Sleep(50);
				}
			}
			while (stopwatch.Elapsed < maxWait);
		}
		finally
		{
			stopwatch.Stop();
		}
		throw new TimeoutException("Could not aquire a lock in the time specified");
	}

	public PersistentQueue(string storagePath)
	{
		persistentQueueImpl_0 = new PersistentQueueImpl(storagePath);
	}

	public PersistentQueue(string storagePath, int maxSize)
	{
		persistentQueueImpl_0 = new PersistentQueueImpl(storagePath, maxSize);
	}

	public void Dispose()
	{
		PersistentQueueImpl persistentQueueImpl = Interlocked.Exchange(ref persistentQueueImpl_0, null);
		if (persistentQueueImpl != null)
		{
			persistentQueueImpl.Dispose();
			GC.SuppressFinalize(this);
		}
	}

	~PersistentQueue()
	{
		if (persistentQueueImpl_0 != null)
		{
			Dispose();
		}
	}

	public IPersistentQueueSession OpenSession()
	{
		if (persistentQueueImpl_0 == null)
		{
			throw new Exception("This queue has been disposed");
		}
		return persistentQueueImpl_0.OpenSession();
	}

	static PersistentQueue()
	{
		Class72.smethod_20();
	}
}
