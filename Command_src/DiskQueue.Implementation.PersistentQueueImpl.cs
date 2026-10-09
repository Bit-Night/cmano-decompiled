using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace DiskQueue.Implementation;

internal class PersistentQueueImpl : GInterface4, IDisposable
{
	[Serializable]
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>c_0;

		public static Func<Operation, bool> func_0;

		public static Func<Operation, Operation> func_1;

		public static Action action_0;

		public static Func<KeyValuePair<int, int>, bool> func_2;

		public static Func<KeyValuePair<int, int>, int> func_3;

		static <>c()
		{
			Class72.smethod_20();
			<>c_0 = new <>c();
		}

		internal bool method_0(Operation entry)
		{
			return entry.Type == OperationType.Dequeue;
		}

		internal Operation method_1(Operation entry)
		{
			return new Operation(OperationType.Reinstate, entry.FileNumber, entry.Start, entry.Length);
		}

		internal void method_2()
		{
		}

		internal bool method_3(KeyValuePair<int, int> pair)
		{
			KeyValuePair<int, int> keyValuePair = pair;
			return keyValuePair.Value < 1;
		}

		internal int method_4(KeyValuePair<int, int> pair)
		{
			KeyValuePair<int, int> keyValuePair = pair;
			return keyValuePair.Key;
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass65_1
	{
		public bool EhfevjrLyCa;

		public Action action_0;

		internal void method_0()
		{
			EhfevjrLyCa = true;
		}

		static <>c__DisplayClass65_1()
		{
			Class72.smethod_20();
		}
	}

	private readonly HashSet<Entry> hashSet_0 = new HashSet<Entry>();

	private readonly Dictionary<int, int> dictionary_0 = new Dictionary<int, int>();

	private readonly LinkedList<Entry> linkedList_0 = new LinkedList<Entry>();

	private readonly string path;

	private readonly object object_0 = new object();

	private readonly object object_1 = new object();

	private static readonly object object_2;

	private volatile bool bool_0;

	private FileStream fileStream_0;

	[CompilerGenerated]
	private bool bool_1;

	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private int int_1;

	[CompilerGenerated]
	private long long_0;

	[CompilerGenerated]
	private bool bool_2;

	[CompilerGenerated]
	private int int_2;

	[CompilerGenerated]
	private long long_1;

	[CompilerGenerated]
	private int int_3;

	public bool TrimTransactionLogOnDispose
	{
		[CompilerGenerated]
		get
		{
			return bool_1;
		}
		[CompilerGenerated]
		set
		{
			bool_1 = value;
		}
	}

	public int SuggestedReadBuffer
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public int SuggestedWriteBuffer
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	public long SuggestedMaxTransactionLogSize
	{
		[CompilerGenerated]
		get
		{
			return long_0;
		}
		[CompilerGenerated]
		set
		{
			long_0 = value;
		}
	}

	public int EstimatedCountOfItemsInQueue => linkedList_0.Count + hashSet_0.Count;

	public bool ParanoidFlushing
	{
		[CompilerGenerated]
		get
		{
			return bool_2;
		}
		[CompilerGenerated]
		set
		{
			bool_2 = value;
		}
	}

	public int MaxFileSize
	{
		[CompilerGenerated]
		get
		{
			return int_2;
		}
		[CompilerGenerated]
		private set
		{
			int_2 = value;
		}
	}

	public long CurrentFilePosition
	{
		[CompilerGenerated]
		get
		{
			return long_1;
		}
		[CompilerGenerated]
		private set
		{
			long_1 = value;
		}
	}

	public int CurrentFileNumber
	{
		[CompilerGenerated]
		get
		{
			return int_3;
		}
		[CompilerGenerated]
		private set
		{
			int_3 = value;
		}
	}

	public PersistentQueueImpl(string path, int maxFileSize)
	{
		lock (object_2)
		{
			bool_0 = true;
			TrimTransactionLogOnDispose = true;
			ParanoidFlushing = true;
			SuggestedMaxTransactionLogSize = 67108864L;
			SuggestedReadBuffer = 1048576;
			SuggestedWriteBuffer = 1048576;
			MaxFileSize = maxFileSize;
			try
			{
				this.path = Path.GetFullPath(path);
				if (!Directory.Exists(this.path))
				{
					method_2(this.path);
				}
				method_1();
			}
			catch (UnauthorizedAccessException)
			{
				throw new UnauthorizedAccessException("Directory \"" + path + "\" does not exist or is missing write permissions");
			}
			catch (IOException innerException)
			{
				GC.SuppressFinalize(this);
				throw new InvalidOperationException("Another instance of the queue is already in action, or directory does not exists", innerException);
			}
			try
			{
				method_12();
				method_10();
			}
			catch (Exception)
			{
				GC.SuppressFinalize(this);
				method_0();
				throw;
			}
			bool_0 = false;
		}
	}

	private void method_0()
	{
		if (path != null)
		{
			string text = Path.Combine(path, "lock");
			if (fileStream_0 != null)
			{
				fileStream_0.Dispose();
				File.Delete(text);
			}
			fileStream_0 = null;
		}
	}

	private void method_1()
	{
		string text = Path.Combine(path, "lock");
		fileStream_0 = new FileStream(text, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
	}

	private void method_2(string string_0)
	{
		Directory.CreateDirectory(string_0);
		SetPermissions.TryAllowReadWriteForAll(string_0);
	}

	public PersistentQueueImpl(string path)
		: this(path, 67108864)
	{
	}

	[SpecialName]
	private int method_3()
	{
		lock (linkedList_0)
		{
			return linkedList_0.Count + hashSet_0.Count;
		}
	}

	[SpecialName]
	private string method_4()
	{
		return Path.Combine(path, "transaction.log");
	}

	[SpecialName]
	private string method_5()
	{
		return Path.Combine(path, "meta.state");
	}

	~PersistentQueueImpl()
	{
		if (!bool_0)
		{
			Dispose();
		}
	}

	public void Dispose()
	{
		lock (object_2)
		{
			if (bool_0)
			{
				return;
			}
			try
			{
				bool_0 = true;
				lock (object_0)
				{
					if (TrimTransactionLogOnDispose)
					{
						method_11();
					}
				}
				GC.SuppressFinalize(this);
			}
			finally
			{
				method_0();
			}
		}
	}

	public void AcquireWriter(Stream stream, Func<Stream, long> action, Action<Stream> onReplaceStream)
	{
		lock (object_1)
		{
			if (stream.Position != CurrentFilePosition)
			{
				stream.Position = CurrentFilePosition;
			}
			CurrentFilePosition = action(stream);
			if (CurrentFilePosition >= MaxFileSize)
			{
				CurrentFileNumber++;
				FileStream fileStream = method_15();
				fileStream.SetLength(CurrentFilePosition);
				CurrentFilePosition = 0L;
				onReplaceStream(fileStream);
			}
		}
	}

	public void CommitTransaction(ICollection<Operation> operations)
	{
		if (operations.Count == 0)
		{
			return;
		}
		byte[] array = smethod_3(operations);
		lock (object_0)
		{
			long position;
			using (FileStream fileStream = method_7(array))
			{
				fileStream.Write(array, 0, array.Length);
				position = fileStream.Position;
				fileStream.Flush();
			}
			method_14(operations);
			method_13(position);
			Atomic.Write(method_5(), delegate(Stream stream_0)
			{
				byte[] bytes = BitConverter.GetBytes(CurrentFileNumber);
				stream_0.Write(bytes, 0, bytes.Length);
				bytes = BitConverter.GetBytes(CurrentFilePosition);
				stream_0.Write(bytes, 0, bytes.Length);
			});
			if (ParanoidFlushing)
			{
				method_11();
			}
		}
	}

	private FileStream method_7(byte[] byte_0)
	{
		for (int i = 0; i < 10; i++)
		{
			try
			{
				return new FileStream(method_4(), FileMode.Append, FileAccess.Write, FileShare.None, byte_0.Length, FileOptions.WriteThrough | FileOptions.SequentialScan);
			}
			catch (Exception)
			{
				Thread.Sleep(250);
			}
		}
		throw new TimeoutException("Could not aquire transaction log lock");
	}

	public Entry Dequeue()
	{
		lock (linkedList_0)
		{
			LinkedListNode<Entry> first = linkedList_0.First;
			if (first != null)
			{
				Entry value = first.Value;
				if (value.Data == null)
				{
					method_8();
				}
				linkedList_0.RemoveFirst();
				hashSet_0.Add(new Entry(value.FileNumber, value.Start, value.Length));
				return value;
			}
			return null;
		}
	}

	private void method_8()
	{
		long num = 0L;
		Entry value = linkedList_0.First.Value;
		Entry entry = value;
		foreach (Entry item in linkedList_0)
		{
			if ((!(item != entry) || (item.FileNumber == entry.FileNumber && item.Start == entry.Start + entry.Length)) && num + item.Length <= SuggestedReadBuffer)
			{
				entry = item;
				num += item.Length;
				continue;
			}
			break;
		}
		if (entry == value)
		{
			num = entry.Length;
		}
		byte[] src = method_9(value, num);
		int num2 = 0;
		foreach (Entry item2 in linkedList_0)
		{
			item2.Data = new byte[item2.Length];
			Buffer.BlockCopy(src, num2, item2.Data, 0, item2.Length);
			num2 += item2.Length;
			if (item2 == entry)
			{
				break;
			}
		}
	}

	private byte[] method_9(Entry entry_0, long long_2)
	{
		byte[] array = new byte[long_2];
		using FileStream fileStream = new FileStream(GetDataPath(entry_0.FileNumber), FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite);
		fileStream.Position = entry_0.Start;
		int num = 0;
		do
		{
			int num2 = fileStream.Read(array, num, array.Length - num);
			if (num2 != 0)
			{
				num += num2;
				continue;
			}
			throw new InvalidOperationException("End of file reached while trying to read queue item");
		}
		while (num < array.Length);
		return array;
	}

	public IPersistentQueueSession OpenSession()
	{
		return new PersistentQueueSession(this, method_15(), SuggestedWriteBuffer);
	}

	public void Reinstate(IEnumerable<Operation> reinstatedOperations)
	{
		lock (linkedList_0)
		{
			method_14(from entry in reinstatedOperations
				where entry.Type == OperationType.Dequeue
				select new Operation(OperationType.Reinstate, entry.FileNumber, entry.Start, entry.Length));
		}
	}

	private void method_10()
	{
		bool bool_0 = false;
		Atomic.Read(method_4(), delegate(Stream stream)
		{
			using BinaryReader binaryReader = new BinaryReader(stream);
			<>c__DisplayClass65_1 <>c__DisplayClass65_ = new <>c__DisplayClass65_1();
			<>c__DisplayClass65_.EhfevjrLyCa = false;
			try
			{
				int num = 0;
				while (true)
				{
					num++;
					smethod_2(binaryReader, num, Constants.StartTransactionSeparatorGuid, <>c__DisplayClass65_.method_0);
					int num2 = binaryReader.ReadInt32();
					List<Operation> list = new List<Operation>(num2);
					for (int i = 0; i < num2; i++)
					{
						smethod_1(binaryReader);
						Operation operation = new Operation((OperationType)binaryReader.ReadByte(), binaryReader.ReadInt32(), binaryReader.ReadInt32(), binaryReader.ReadInt32());
						list.Add(operation);
						if (operation.Type != OperationType.Enqueue)
						{
							bool_0 = true;
						}
					}
					smethod_2(binaryReader, num, Constants.EndTransactionSeparatorGuid, <>c.<>c_0.method_2);
					<>c__DisplayClass65_.EhfevjrLyCa = false;
					method_14(list);
				}
			}
			catch (EndOfStreamException)
			{
				if (<>c__DisplayClass65_.EhfevjrLyCa)
				{
					bool_0 = true;
				}
			}
		});
		if (bool_0)
		{
			method_11();
		}
	}

	private void method_11()
	{
		byte[] byte_0;
		using (MemoryStream memoryStream = RCMS.recyclableMemoryStreamManager_0.GetStream())
		{
			memoryStream.Write(Constants.StartTransactionSeparator, 0, Constants.StartTransactionSeparator.Length);
			byte[] bytes = BitConverter.GetBytes(EstimatedCountOfItemsInQueue);
			memoryStream.Write(bytes, 0, bytes.Length);
			Entry[] array = hashSet_0.ToArray();
			foreach (Entry entry_ in array)
			{
				smethod_0(memoryStream, entry_, OperationType.Enqueue);
			}
			array = linkedList_0.ToArray();
			foreach (Entry entry_2 in array)
			{
				smethod_0(memoryStream, entry_2, OperationType.Enqueue);
			}
			memoryStream.Write(Constants.EndTransactionSeparator, 0, Constants.EndTransactionSeparator.Length);
			memoryStream.Flush();
			byte_0 = memoryStream.ToArray();
		}
		Atomic.Write(method_4(), delegate(Stream stream)
		{
			stream.SetLength(byte_0.Length);
			stream.Write(byte_0, 0, byte_0.Length);
		});
	}

	private static void smethod_0(Stream stream_0, Entry entry_0, OperationType operationType_0)
	{
		stream_0.Write(Constants.OperationSeparatorBytes, 0, Constants.OperationSeparatorBytes.Length);
		stream_0.WriteByte((byte)operationType_0);
		byte[] bytes = BitConverter.GetBytes(entry_0.FileNumber);
		stream_0.Write(bytes, 0, bytes.Length);
		byte[] bytes2 = BitConverter.GetBytes(entry_0.Start);
		stream_0.Write(bytes2, 0, bytes2.Length);
		byte[] bytes3 = BitConverter.GetBytes(entry_0.Length);
		stream_0.Write(bytes3, 0, bytes3.Length);
	}

	private static void smethod_1(BinaryReader binaryReader_0)
	{
		if (binaryReader_0.ReadInt32() != Constants.OperationSeparator)
		{
			throw new InvalidOperationException("Unexpected data in transaction log. Expected to get transaction separator but got unknonwn data");
		}
	}

	public int[] ApplyTransactionOperationsInMemory(IEnumerable<Operation> operations)
	{
		foreach (Operation operation in operations)
		{
			switch (operation.Type)
			{
			case OperationType.Enqueue:
			{
				Entry entry3 = new Entry(operation);
				linkedList_0.AddLast(entry3);
				int valueOrDefault2 = Extensions.GetValueOrDefault(dictionary_0, entry3.FileNumber);
				dictionary_0[entry3.FileNumber] = valueOrDefault2 + 1;
				break;
			}
			case OperationType.Dequeue:
			{
				Entry entry2 = new Entry(operation);
				hashSet_0.Remove(entry2);
				int valueOrDefault = Extensions.GetValueOrDefault(dictionary_0, entry2.FileNumber);
				dictionary_0[entry2.FileNumber] = valueOrDefault - 1;
				break;
			}
			case OperationType.Reinstate:
			{
				Entry entry = new Entry(operation);
				linkedList_0.AddFirst(entry);
				hashSet_0.Remove(entry);
				break;
			}
			}
		}
		HashSet<int> hashSet = new HashSet<int>(dictionary_0.Where(delegate(KeyValuePair<int, int> pair)
		{
			KeyValuePair<int, int> keyValuePair = pair;
			return keyValuePair.Value < 1;
		}).Select(delegate(KeyValuePair<int, int> pair)
		{
			KeyValuePair<int, int> keyValuePair = pair;
			return keyValuePair.Key;
		}));
		foreach (int item in hashSet)
		{
			dictionary_0.Remove(item);
		}
		return hashSet.ToArray();
	}

	private static void smethod_2(BinaryReader binaryReader_0, int int_4, Guid guid_0, Action action_0)
	{
		byte[] array = binaryReader_0.ReadBytes(16);
		if (array.Length != 0)
		{
			action_0();
			if (array.Length != 16)
			{
				if (binaryReader_0.BaseStream.Length == binaryReader_0.BaseStream.Position)
				{
					throw new EndOfStreamException();
				}
				throw new InvalidOperationException("Unexpected data in transaction log. Expected to get transaction separator but got truncated data. Tx #" + int_4);
			}
			if (new Guid(array) != guid_0)
			{
				throw new InvalidOperationException("Unexpected data in transaction log. Expected to get transaction separator but got unknown data. Tx #" + int_4);
			}
			return;
		}
		throw new EndOfStreamException();
	}

	private void method_12()
	{
		Atomic.Read(method_5(), delegate(Stream stream_0)
		{
			using BinaryReader binaryReader = new BinaryReader(stream_0);
			try
			{
				CurrentFileNumber = binaryReader.ReadInt32();
				CurrentFilePosition = binaryReader.ReadInt64();
			}
			catch (EndOfStreamException)
			{
			}
		});
	}

	private void method_13(long long_2)
	{
		if (long_2 >= SuggestedMaxTransactionLogSize)
		{
			long num = method_16();
			if (long_2 >= num * 2L)
			{
				method_11();
			}
		}
	}

	private void method_14(IEnumerable<Operation> ienumerable_0)
	{
		int[] array;
		lock (linkedList_0)
		{
			array = ApplyTransactionOperationsInMemory(ienumerable_0);
		}
		int[] array2 = array;
		foreach (int num in array2)
		{
			if (CurrentFileNumber != num)
			{
				File.Delete(GetDataPath(num));
			}
		}
	}

	private static byte[] smethod_3(ICollection<Operation> icollection_0)
	{
		using MemoryStream memoryStream = RCMS.recyclableMemoryStreamManager_0.GetStream();
		memoryStream.Write(Constants.StartTransactionSeparator, 0, Constants.StartTransactionSeparator.Length);
		byte[] bytes = BitConverter.GetBytes(icollection_0.Count);
		memoryStream.Write(bytes, 0, bytes.Length);
		foreach (Operation item in icollection_0)
		{
			smethod_0(memoryStream, new Entry(item), item.Type);
		}
		memoryStream.Write(Constants.EndTransactionSeparator, 0, Constants.EndTransactionSeparator.Length);
		memoryStream.Flush();
		return memoryStream.ToArray();
	}

	private FileStream method_15()
	{
		string dataPath = GetDataPath(CurrentFileNumber);
		FileStream result = new FileStream(dataPath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite, 65536, FileOptions.WriteThrough | FileOptions.Asynchronous | FileOptions.SequentialScan);
		SetPermissions.TryAllowReadWriteForAll(dataPath);
		return result;
	}

	public string GetDataPath(int index)
	{
		return Path.Combine(path, "data." + index);
	}

	private long method_16()
	{
		return 20L + 16 * method_3();
	}

	static PersistentQueueImpl()
	{
		Class72.smethod_20();
		object_2 = new object();
	}

	[CompilerGenerated]
	private void method_17(Stream stream_0)
	{
		byte[] bytes = BitConverter.GetBytes(CurrentFileNumber);
		stream_0.Write(bytes, 0, bytes.Length);
		bytes = BitConverter.GetBytes(CurrentFilePosition);
		stream_0.Write(bytes, 0, bytes.Length);
	}

	[CompilerGenerated]
	private void method_18(Stream stream_0)
	{
		using BinaryReader binaryReader = new BinaryReader(stream_0);
		try
		{
			CurrentFileNumber = binaryReader.ReadInt32();
			CurrentFilePosition = binaryReader.ReadInt64();
		}
		catch (EndOfStreamException)
		{
		}
	}
}
