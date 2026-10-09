using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace DiskQueue.Implementation;

public sealed class PersistentQueueSession : IPersistentQueueSession, IDisposable
{
	private readonly List<Operation> list_0 = new List<Operation>();

	private readonly IList<Exception> ilist_0 = new List<Exception>();

	private readonly IList<WaitHandle> ilist_1 = new List<WaitHandle>();

	private Stream stream_0;

	private readonly int int_0;

	private readonly GInterface4 ginterface4_0;

	private readonly List<Stream> list_1 = new List<Stream>();

	private static readonly object object_0;

	private volatile bool bool_0;

	private readonly List<byte[]> list_2 = new List<byte[]>();

	private int int_1;

	public PersistentQueueSession(GInterface4 queue, Stream currentStream, int writeBufferSize)
	{
		lock (object_0)
		{
			ginterface4_0 = queue;
			stream_0 = currentStream;
			if (writeBufferSize < 65536)
			{
				writeBufferSize = 65536;
			}
			int_0 = writeBufferSize;
			bool_0 = false;
		}
	}

	public void Enqueue(byte[] data)
	{
		list_2.Add(data);
		int_1 += data.Length;
		if (int_1 > int_0)
		{
			method_0();
		}
	}

	private void method_0()
	{
		ginterface4_0.AcquireWriter(stream_0, pluyUqywon2, method_3);
	}

	private void method_1()
	{
		ginterface4_0.AcquireWriter(stream_0, delegate(Stream stream_1)
		{
			byte[] array = method_2(stream_1);
			stream_1.Write(array, 0, array.Length);
			return stream_1.Position;
		}, method_3);
	}

	private long pluyUqywon2(Stream stream_1)
	{
		byte[] array = method_2(stream_1);
		ManualResetEvent manualResetEvent_0 = new ManualResetEvent(initialState: false);
		ilist_1.Add(manualResetEvent_0);
		long result = stream_1.Position + array.Length;
		stream_1.BeginWrite(array, 0, array.Length, delegate(IAsyncResult ar)
		{
			try
			{
				stream_1.EndWrite(ar);
			}
			catch (Exception item)
			{
				lock (ilist_0)
				{
					ilist_0.Add(item);
				}
			}
			finally
			{
				manualResetEvent_0.Set();
			}
		}, null);
		return result;
	}

	private byte[] method_2(Stream stream_1)
	{
		byte[] array = new byte[int_1];
		int num = (int)stream_1.Position;
		int num2 = 0;
		foreach (byte[] item in list_2)
		{
			list_0.Add(new Operation(OperationType.Enqueue, ginterface4_0.CurrentFileNumber, num, item.Length));
			Buffer.BlockCopy(item, 0, array, num2, item.Length);
			num += item.Length;
			num2 += item.Length;
		}
		int_1 = 0;
		list_2.Clear();
		return array;
	}

	private void method_3(Stream stream_1)
	{
		list_1.Add(stream_0);
		stream_0 = stream_1;
	}

	public byte[] Dequeue()
	{
		Entry entry = ginterface4_0.Dequeue();
		if (!(entry == null))
		{
			list_0.Add(new Operation(OperationType.Dequeue, entry.FileNumber, entry.Start, entry.Length));
			return entry.Data;
		}
		return null;
	}

	public void Flush()
	{
		try
		{
			method_4();
			method_1();
		}
		finally
		{
			foreach (Stream item in list_1)
			{
				item.Flush();
				item.Dispose();
			}
			list_1.Clear();
		}
		stream_0.Flush();
		ginterface4_0.CommitTransaction(list_0);
		list_0.Clear();
	}

	private void method_4()
	{
		while (ilist_1.Count != 0)
		{
			WaitHandle[] array = ilist_1.Take(64).ToArray();
			WaitHandle[] array2 = array;
			foreach (WaitHandle item in array2)
			{
				ilist_1.Remove(item);
			}
			WaitHandle.WaitAll(array);
			array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].Close();
			}
			method_5();
		}
	}

	private void method_5()
	{
		lock (ilist_0)
		{
			if (ilist_0.Count != 0)
			{
				Exception[] pendingWritesExceptions = ilist_0.ToArray();
				ilist_0.Clear();
				throw new PendingWriteException(pendingWritesExceptions);
			}
		}
	}

	public void Dispose()
	{
		lock (object_0)
		{
			if (bool_0)
			{
				return;
			}
			bool_0 = true;
			ginterface4_0.Reinstate(list_0);
			list_0.Clear();
			foreach (Stream item in list_1)
			{
				item.Dispose();
			}
			stream_0.Dispose();
			GC.SuppressFinalize(this);
		}
		Thread.Sleep(0);
	}

	~PersistentQueueSession()
	{
		if (!bool_0)
		{
			Dispose();
		}
	}

	static PersistentQueueSession()
	{
		Class72.smethod_20();
		object_0 = new object();
	}

	[CompilerGenerated]
	private long method_6(Stream stream_1)
	{
		byte[] array = method_2(stream_1);
		stream_1.Write(array, 0, array.Length);
		return stream_1.Position;
	}
}
