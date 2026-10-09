using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using ICSharpCode.SharpZipLib.BZip2;
using ICSharpCode.SharpZipLib.Checksum;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Encryption;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace ICSharpCode.SharpZipLib.Zip;

public class ZipFile : IEnumerable<ZipEntry>, IEnumerable, IDisposable
{
	public delegate void KeysRequiredEventHandler(object sender, KeysRequiredEventArgs e);

	[Flags]
	private enum Enum14
	{
		None = 0,
		Header = 2
	}

	private enum Enum15
	{
		Add = 2
	}

	private class Class33 : IComparer<Class34>
	{
		public int Compare(Class34 x, Class34 y)
		{
			int num;
			if (x == null)
			{
				num = ((y != null) ? (-1) : 0);
			}
			else if (y == null)
			{
				num = 1;
			}
			else
			{
				int num2 = ((x.Command != 0 && x.Command != (Enum15)1) ? 1 : 0);
				int num3 = ((y.Command != 0 && y.Command != (Enum15)1) ? 1 : 0);
				num = num2 - num3;
				if (num == 0)
				{
					long num4 = x.method_0().Offset - y.method_0().Offset;
					num = ((num4 < 0L) ? (-1) : ((num4 != 0L) ? 1 : 0));
				}
			}
			return num;
		}

		static Class33()
		{
			Class72.smethod_20();
		}
	}

	private class Class34
	{
		private ZipEntry zipEntry_0;

		private ZipEntry zipEntry_1;

		private readonly Enum15 enum15_0;

		private IStaticDataSource istaticDataSource_0;

		private readonly string string_0;

		private long long_0 = -1L;

		private long long_1 = -1L;

		private long long_2 = -1L;

		public Enum15 Command => enum15_0;

		public Class34(string string_1, ZipEntry zipEntry_2)
		{
			enum15_0 = Enum15.Add;
			zipEntry_0 = zipEntry_2;
			string_0 = string_1;
		}

		[Obsolete]
		public Class34(string string_1, string string_2, CompressionMethod compressionMethod_0)
		{
			enum15_0 = Enum15.Add;
			zipEntry_0 = new ZipEntry(string_2)
			{
				CompressionMethod = compressionMethod_0
			};
			string_0 = string_1;
		}

		[Obsolete]
		public Class34(string string_1, string string_2)
			: this(string_1, string_2, CompressionMethod.Deflated)
		{
		}

		[Obsolete]
		public Class34(IStaticDataSource istaticDataSource_1, string string_1, CompressionMethod compressionMethod_0)
		{
			enum15_0 = Enum15.Add;
			zipEntry_0 = new ZipEntry(string_1)
			{
				CompressionMethod = compressionMethod_0
			};
			istaticDataSource_0 = istaticDataSource_1;
		}

		public Class34(IStaticDataSource istaticDataSource_1, ZipEntry zipEntry_2)
		{
			enum15_0 = Enum15.Add;
			zipEntry_0 = zipEntry_2;
			istaticDataSource_0 = istaticDataSource_1;
		}

		public Class34(ZipEntry zipEntry_2, ZipEntry zipEntry_3)
		{
			throw new ZipException("Modify not currently supported");
		}

		public Class34(Enum15 enum15_1, ZipEntry zipEntry_2)
		{
			enum15_0 = enum15_1;
			zipEntry_0 = (ZipEntry)zipEntry_2.Clone();
		}

		public Class34(ZipEntry zipEntry_2)
			: this((Enum15)0, zipEntry_2)
		{
		}

		[SpecialName]
		public ZipEntry method_0()
		{
			return zipEntry_0;
		}

		[SpecialName]
		public ZipEntry method_1()
		{
			if (zipEntry_1 == null)
			{
				zipEntry_1 = (ZipEntry)zipEntry_0.Clone();
			}
			return zipEntry_1;
		}

		[SpecialName]
		public string method_2()
		{
			return string_0;
		}

		[SpecialName]
		public long method_3()
		{
			return long_0;
		}

		[SpecialName]
		public void method_4(long long_3)
		{
			long_0 = long_3;
		}

		[SpecialName]
		public long method_5()
		{
			return long_1;
		}

		[SpecialName]
		public void method_6(long long_3)
		{
			long_1 = long_3;
		}

		[SpecialName]
		public long method_7()
		{
			return long_2;
		}

		[SpecialName]
		public void method_8(long long_3)
		{
			long_2 = long_3;
		}

		public Stream method_9()
		{
			Stream result = null;
			if (istaticDataSource_0 != null)
			{
				result = istaticDataSource_0.GetSource();
			}
			return result;
		}

		static Class34()
		{
			Class72.smethod_20();
		}
	}

	private class Class35
	{
		private string string_0;

		private object object_0;

		private readonly bool bool_0;

		private readonly Encoding encoding_0;

		public int RawLength
		{
			get
			{
				method_3();
				return ((Array)object_0).Length;
			}
		}

		public Class35(string string_1, Encoding encoding_1)
		{
			string_0 = string_1;
			bool_0 = true;
			encoding_0 = encoding_1;
		}

		public Class35(byte[] byte_0, Encoding encoding_1)
		{
			object_0 = byte_0;
			encoding_0 = encoding_1;
		}

		[SpecialName]
		public bool method_0()
		{
			return bool_0;
		}

		[SpecialName]
		public byte[] method_1()
		{
			method_3();
			return (byte[])((Array)object_0).Clone();
		}

		public void Reset()
		{
			if (!bool_0)
			{
				string_0 = null;
			}
			else
			{
				object_0 = null;
			}
		}

		private void method_2()
		{
			if (string_0 == null)
			{
				string_0 = encoding_0.GetString((byte[])object_0);
			}
		}

		private void method_3()
		{
			if (object_0 == null)
			{
				object_0 = encoding_0.GetBytes(string_0);
			}
		}

		public static implicit operator string(object object_1)
		{
			((Class35)object_1).method_2();
			return ((Class35)object_1).string_0;
		}

		static Class35()
		{
			Class72.smethod_20();
		}
	}

	public struct ZipEntryEnumerator : IEnumerator<ZipEntry>, IDisposable, IEnumerator
	{
		private ZipEntry[] zipEntry_0;

		private int int_0;

		public ZipEntry Current => zipEntry_0[int_0];

		object IEnumerator.Current => Current;

		public ZipEntryEnumerator(ZipEntry[] entries)
		{
			zipEntry_0 = entries;
			int_0 = -1;
		}

		public void Reset()
		{
			int_0 = -1;
		}

		public bool MoveNext()
		{
			return ++int_0 < zipEntry_0.Length;
		}

		public void Dispose()
		{
		}

		static ZipEntryEnumerator()
		{
			Class72.smethod_20();
		}
	}

	private class Stream0 : Stream
	{
		private readonly Stream stream_0;

		public override bool CanRead => false;

		public override bool CanWrite => stream_0.CanWrite;

		public override bool CanSeek => false;

		public override long Length => 0L;

		public override long Position
		{
			get
			{
				return stream_0.Position;
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public Stream0(Stream stream_1)
		{
			stream_0 = stream_1;
		}

		public override void Flush()
		{
			stream_0.Flush();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return 0L;
		}

		public override void SetLength(long value)
		{
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			stream_0.Write(buffer, offset, count);
		}

		static Stream0()
		{
			Class72.smethod_20();
		}
	}

	private class Stream1 : Stream
	{
		private ZipFile zipFile_0;

		private Stream stream_0;

		private readonly long long_0;

		private readonly long long_1;

		private long long_2;

		private readonly long long_3;

		public override long Position
		{
			get
			{
				return long_2 - long_0;
			}
			set
			{
				long num = long_0 + value;
				if (num < long_0)
				{
					throw new ArgumentException("Negative position is invalid");
				}
				if (num > long_3)
				{
					throw new InvalidOperationException("Cannot seek past end");
				}
				long_2 = num;
			}
		}

		public override long Length => long_1;

		public override bool CanWrite => false;

		public override bool CanSeek => true;

		public override bool CanRead => true;

		public override bool CanTimeout => stream_0.CanTimeout;

		public Stream1(ZipFile zipFile_1, long long_4, long long_5)
		{
			long_0 = long_4;
			long_1 = long_5;
			zipFile_0 = zipFile_1;
			stream_0 = zipFile_0.stream_0;
			long_2 = long_4;
			long_3 = long_4 + long_5;
		}

		public override int ReadByte()
		{
			if (long_2 >= long_3)
			{
				return -1;
			}
			lock (stream_0)
			{
				stream_0.Seek(long_2++, SeekOrigin.Begin);
				return stream_0.ReadByte();
			}
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			lock (stream_0)
			{
				if (count > long_3 - long_2)
				{
					count = (int)(long_3 - long_2);
					if (count == 0)
					{
						return 0;
					}
				}
				if (stream_0.Position != long_2)
				{
					stream_0.Seek(long_2, SeekOrigin.Begin);
				}
				int num = stream_0.Read(buffer, offset, count);
				if (num > 0)
				{
					long_2 += num;
				}
				return num;
			}
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException();
		}

		public override void SetLength(long value)
		{
			throw new NotSupportedException();
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			long num = long_2;
			switch (origin)
			{
			case SeekOrigin.Begin:
				num = long_0 + offset;
				break;
			case SeekOrigin.Current:
				num = long_2 + offset;
				break;
			case SeekOrigin.End:
				num = long_3 + offset;
				break;
			}
			if (num < long_0)
			{
				throw new ArgumentException("Negative position is invalid");
			}
			if (num > long_3)
			{
				throw new IOException("Cannot seek past end");
			}
			long_2 = num;
			return long_2;
		}

		public override void Flush()
		{
		}

		static Stream1()
		{
			Class72.smethod_20();
		}
	}

	public KeysRequiredEventHandler KeysRequired;

	[CompilerGenerated]
	private bool bool_0;

	private bool bool_1;

	private string string_0;

	private string string_1 = string.Empty;

	private string string_2;

	private Stream stream_0;

	private bool bool_2;

	private long long_0;

	private ZipEntry[] zipEntry_0;

	private byte[] byte_0;

	private bool bool_3;

	private StringCodec stringCodec_0 = ZipStrings.GetStringCodec();

	private UseZip64 useZip64_0 = UseZip64.Dynamic;

	private List<Class34> list_0;

	private long long_1;

	private Dictionary<string, int> dictionary_0;

	private IArchiveStorage iarchiveStorage_0;

	private GInterface2 ginterface2_0;

	private bool bool_4;

	private int int_0 = 4096;

	private byte[] byte_1;

	private Class35 class35_0;

	private bool bool_5;

	private IEntryFactory ientryFactory_0 = new ZipEntryFactory();

	private byte[] Key
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
		}
	}

	public string Password
	{
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				byte_0 = null;
			}
			else
			{
				byte_0 = PkzipClassic.GenerateKeys(ZipCryptoEncoding.GetBytes(value));
			}
			string_2 = value;
		}
	}

	public bool IsStreamOwner
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public bool IsEmbeddedArchive => long_0 > 0L;

	public bool IsNewArchive => bool_3;

	public string ZipFileComment => string_1;

	public string Name => string_0;

	[Obsolete("Use the Count property instead")]
	public int Size => zipEntry_0.Length;

	public long Count => zipEntry_0.Length;

	[IndexerName("EntryByIndex")]
	public ZipEntry this[int index] => (ZipEntry)zipEntry_0[index].Clone();

	public Encoding ZipCryptoEncoding
	{
		get
		{
			return stringCodec_0.ZipCryptoEncoding;
		}
		set
		{
			stringCodec_0 = stringCodec_0.WithZipCryptoEncoding(value);
		}
	}

	public StringCodec StringCodec
	{
		set
		{
			stringCodec_0 = value;
			if (!bool_3)
			{
				method_36();
			}
		}
	}

	public INameTransform NameTransform
	{
		get
		{
			return ientryFactory_0.NameTransform;
		}
		set
		{
			ientryFactory_0.NameTransform = value;
		}
	}

	public IEntryFactory EntryFactory
	{
		get
		{
			return ientryFactory_0;
		}
		set
		{
			if (value == null)
			{
				ientryFactory_0 = new ZipEntryFactory();
			}
			else
			{
				ientryFactory_0 = value;
			}
		}
	}

	public int BufferSize
	{
		get
		{
			return int_0;
		}
		set
		{
			if (value >= 1024)
			{
				if (int_0 != value)
				{
					int_0 = value;
					byte_1 = null;
				}
				return;
			}
			throw new ArgumentOutOfRangeException("value", "cannot be below 1024");
		}
	}

	public bool IsUpdating => list_0 != null;

	public UseZip64 UseZip64
	{
		get
		{
			return useZip64_0;
		}
		set
		{
			useZip64_0 = value;
		}
	}

	public bool SkipLocalEntryTestsOnLocate
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	private void method_0(string string_3)
	{
		if (KeysRequired != null)
		{
			KeysRequiredEventArgs e = new KeysRequiredEventArgs(string_3, byte_0);
			KeysRequired(this, e);
			byte_0 = e.Key;
		}
	}

	[SpecialName]
	private bool method_1()
	{
		return byte_0 != null;
	}

	public ZipFile(string name)
		: this(name, null)
	{
	}

	public ZipFile(string name, StringCodec stringCodec)
	{
		if (name != null)
		{
			string_0 = name;
			stream_0 = File.Open(name, FileMode.Open, FileAccess.Read, FileShare.Read);
			bool_2 = true;
			if (stringCodec != null)
			{
				stringCodec_0 = stringCodec;
			}
			try
			{
				method_36();
				return;
			}
			catch
			{
				method_31(bool_6: true);
				throw;
			}
		}
		throw new ArgumentNullException("name");
	}

	public ZipFile(FileStream file)
		: this(file, leaveOpen: false)
	{
	}

	public ZipFile(FileStream file, bool leaveOpen)
	{
		if (file == null)
		{
			throw new ArgumentNullException("file");
		}
		if (file.CanSeek)
		{
			stream_0 = file;
			string_0 = file.Name;
			bool_2 = !leaveOpen;
			try
			{
				method_36();
				return;
			}
			catch
			{
				method_31(bool_6: true);
				throw;
			}
		}
		throw new ArgumentException("Stream is not seekable", "file");
	}

	public ZipFile(Stream stream)
		: this(stream, leaveOpen: false)
	{
	}

	public ZipFile(Stream stream, bool leaveOpen)
		: this(stream, leaveOpen, null)
	{
	}

	public ZipFile(Stream stream, bool leaveOpen, StringCodec stringCodec)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		if (stream.CanSeek)
		{
			stream_0 = stream;
			bool_2 = !leaveOpen;
			if (stringCodec != null)
			{
				stringCodec_0 = stringCodec;
			}
			if (stream_0.Length > 0L)
			{
				try
				{
					method_36();
					return;
				}
				catch
				{
					method_31(bool_6: true);
					throw;
				}
			}
			zipEntry_0 = Empty.Array<ZipEntry>();
			bool_3 = true;
			return;
		}
		throw new ArgumentException("Stream is not seekable", "stream");
	}

	internal ZipFile()
	{
		zipEntry_0 = Empty.Array<ZipEntry>();
		bool_3 = true;
	}

	~ZipFile()
	{
		Dispose(disposing: false);
	}

	public void Close()
	{
		method_31(bool_6: true);
		GC.SuppressFinalize(this);
	}

	public static ZipFile Create(string fileName)
	{
		if (fileName == null)
		{
			throw new ArgumentNullException("fileName");
		}
		FileStream fileStream = File.Create(fileName);
		return new ZipFile
		{
			string_0 = fileName,
			stream_0 = fileStream,
			bool_2 = true
		};
	}

	public static ZipFile Create(Stream outStream)
	{
		if (outStream != null)
		{
			if (!outStream.CanWrite)
			{
				throw new ArgumentException("Stream is not writeable", "outStream");
			}
			if (!outStream.CanSeek)
			{
				throw new ArgumentException("Stream is not seekable", "outStream");
			}
			return new ZipFile
			{
				stream_0 = outStream
			};
		}
		throw new ArgumentNullException("outStream");
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	IEnumerator<ZipEntry> IEnumerable<ZipEntry>.GetEnumerator()
	{
		return GetEnumerator();
	}

	public ZipEntryEnumerator GetEnumerator()
	{
		if (bool_1)
		{
			throw new ObjectDisposedException("ZipFile");
		}
		return new ZipEntryEnumerator(zipEntry_0);
	}

	public int FindEntry(string name, bool ignoreCase)
	{
		if (!bool_1)
		{
			for (int i = 0; i < zipEntry_0.Length; i++)
			{
				if (string.Compare(name, zipEntry_0[i].Name, (!ignoreCase) ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase) == 0)
				{
					return i;
				}
			}
			return -1;
		}
		throw new ObjectDisposedException("ZipFile");
	}

	public ZipEntry GetEntry(string name)
	{
		if (bool_1)
		{
			throw new ObjectDisposedException("ZipFile");
		}
		int num = FindEntry(name, ignoreCase: true);
		if (num < 0)
		{
			return null;
		}
		return (ZipEntry)zipEntry_0[num].Clone();
	}

	public Stream GetInputStream(ZipEntry entry)
	{
		if (entry != null)
		{
			if (bool_1)
			{
				throw new ObjectDisposedException("ZipFile");
			}
			long num = entry.ZipFileIndex;
			if (num < 0L || num >= zipEntry_0.Length || zipEntry_0[num].Name != entry.Name)
			{
				num = FindEntry(entry.Name, ignoreCase: true);
				if (num < 0L)
				{
					throw new ZipException("Entry cannot be found");
				}
			}
			return GetInputStream(num);
		}
		throw new ArgumentNullException("entry");
	}

	public Stream GetInputStream(long entryIndex)
	{
		if (bool_1)
		{
			throw new ObjectDisposedException("ZipFile");
		}
		long long_ = method_37(zipEntry_0[entryIndex]);
		CompressionMethod compressionMethod = zipEntry_0[entryIndex].CompressionMethod;
		Stream stream = new Stream1(this, long_, zipEntry_0[entryIndex].CompressedSize);
		if (zipEntry_0[entryIndex].IsCrypted)
		{
			stream = method_38(stream, zipEntry_0[entryIndex]);
			if (stream == null)
			{
				throw new ZipException("Unable to decrypt this entry");
			}
		}
		switch (compressionMethod)
		{
		default:
			throw new ZipException("Unsupported compression method " + compressionMethod);
		case CompressionMethod.BZip2:
			stream = new BZip2InputStream(stream);
			break;
		case CompressionMethod.Deflated:
			stream = new InflaterInputStream(stream, InflaterPool.Instance.Rent(noHeader: true));
			break;
		case CompressionMethod.Stored:
			break;
		}
		return stream;
	}

	public bool TestArchive(bool testData)
	{
		return TestArchive(testData, TestStrategy.FindFirstError, null);
	}

	public bool TestArchive(bool testData, TestStrategy strategy, ZipTestResultHandler resultHandler)
	{
		if (!bool_1)
		{
			TestStatus testStatus = new TestStatus(this);
			resultHandler?.Invoke(testStatus, null);
			Enum14 enum14_ = ((!testData) ? Enum14.Header : ((Enum14)3));
			bool flag = true;
			try
			{
				int num = 0;
				while (flag && num < Count)
				{
					if (resultHandler != null)
					{
						testStatus.SetEntry(this[num]);
						testStatus.SetOperation(TestOperation.EntryHeader);
						resultHandler(testStatus, null);
					}
					try
					{
						method_2(this[num], enum14_);
					}
					catch (ZipException ex)
					{
						testStatus.AddError();
						resultHandler?.Invoke(testStatus, "Exception during test - '" + ex.Message + "'");
						flag = flag && strategy != TestStrategy.FindFirstError;
					}
					if (flag && testData && this[num].IsFile)
					{
						bool flag2 = this[num].AESKeySize == 0;
						if (resultHandler != null)
						{
							testStatus.SetOperation(TestOperation.EntryData);
							resultHandler(testStatus, null);
						}
						Crc32 crc = new Crc32();
						using (Stream stream = GetInputStream(this[num]))
						{
							byte[] array = new byte[4096];
							long num2 = 0L;
							int num3;
							while ((num3 = stream.Read(array, 0, array.Length)) > 0)
							{
								if (flag2)
								{
									crc.Update(new ArraySegment<byte>(array, 0, num3));
								}
								if (resultHandler != null)
								{
									num2 += num3;
									testStatus.SetBytesTested(num2);
									resultHandler(testStatus, null);
								}
							}
						}
						if (flag2 && this[num].Crc != crc.Value)
						{
							testStatus.AddError();
							resultHandler?.Invoke(testStatus, "CRC mismatch");
							flag = flag && strategy != TestStrategy.FindFirstError;
						}
						if ((this[num].Flags & 8) != 0)
						{
							DescriptorData descriptorData = new DescriptorData();
							ZipFormat.ReadDataDescriptor(stream_0, this[num].LocalHeaderRequiresZip64, descriptorData);
							if (flag2 && this[num].Crc != descriptorData.Crc)
							{
								testStatus.AddError();
								resultHandler?.Invoke(testStatus, "Descriptor CRC mismatch");
							}
							if (this[num].CompressedSize != descriptorData.CompressedSize)
							{
								testStatus.AddError();
								resultHandler?.Invoke(testStatus, "Descriptor compressed size mismatch");
							}
							if (this[num].Size != descriptorData.Size)
							{
								testStatus.AddError();
								resultHandler?.Invoke(testStatus, "Descriptor size mismatch");
							}
						}
					}
					if (resultHandler != null)
					{
						testStatus.SetOperation(TestOperation.EntryComplete);
						resultHandler(testStatus, null);
					}
					num++;
				}
				if (resultHandler != null)
				{
					testStatus.SetOperation(TestOperation.MiscellaneousTests);
					resultHandler(testStatus, null);
				}
			}
			catch (Exception ex2)
			{
				testStatus.AddError();
				resultHandler?.Invoke(testStatus, "Exception during test - '" + ex2.Message + "'");
			}
			if (resultHandler != null)
			{
				testStatus.SetOperation(TestOperation.Complete);
				testStatus.SetEntry(null);
				resultHandler(testStatus, null);
			}
			return testStatus.ErrorCount == 0;
		}
		throw new ObjectDisposedException("ZipFile");
	}

	private long method_2(ZipEntry zipEntry_1, Enum14 enum14_0)
	{
		lock (stream_0)
		{
			bool num = (enum14_0 & Enum14.Header) != 0;
			bool num2 = (enum14_0 & (Enum14)1) != 0;
			long num3 = long_0 + zipEntry_1.Offset;
			stream_0.Seek(num3, SeekOrigin.Begin);
			int num4 = (int)method_33();
			if (num4 != 67324752)
			{
				throw new ZipException($"Wrong local header signature at 0x{num3:x}, expected 0x{67324752:x8}, actual 0x{num4:x8}");
			}
			short num5 = (short)(method_32() & 0xFF);
			GeneralBitFlags generalBitFlags = (GeneralBitFlags)method_32();
			CompressionMethod compressionMethod = (CompressionMethod)method_32();
			short num6 = (short)method_32();
			short num7 = (short)method_32();
			uint num8 = method_33();
			long num9 = method_33();
			long num10 = method_33();
			int num11 = method_32();
			int num12 = method_32();
			byte[] array = new byte[num11];
			StreamUtils.ReadFully(stream_0, array);
			byte[] array2 = new byte[num12];
			StreamUtils.ReadFully(stream_0, array2);
			ZipExtraData zipExtraData = new ZipExtraData(array2);
			if (!zipExtraData.Find(1))
			{
				if (num5 >= 45 && ((int)num10 == -1 || (int)num9 == -1))
				{
					throw new ZipException("Required Zip64 extended information missing");
				}
			}
			else
			{
				num10 = zipExtraData.ReadLong();
				num9 = zipExtraData.ReadLong();
				if (generalBitFlags.HasAny(GeneralBitFlags.Descriptor))
				{
					if (num10 != 0L && num10 != zipEntry_1.Size)
					{
						throw new ZipException("Size invalid for descriptor");
					}
					if (num9 != 0L && num9 != zipEntry_1.CompressedSize)
					{
						throw new ZipException("Compressed size invalid for descriptor");
					}
				}
			}
			if (num2 && zipEntry_1.IsFile)
			{
				if (!zipEntry_1.IsCompressionMethodSupported())
				{
					throw new ZipException("Compression method not supported");
				}
				if (num5 > 51 || (num5 > 20 && num5 < 45))
				{
					throw new ZipException($"Version required to extract this entry not supported ({num5})");
				}
				if (generalBitFlags.HasAny(GeneralBitFlags.Patched | GeneralBitFlags.StrongEncryption | GeneralBitFlags.EnhancedCompress | GeneralBitFlags.HeaderMasked))
				{
					throw new ZipException($"The library does not support the zip features required to extract this entry ({generalBitFlags & (GeneralBitFlags.Patched | GeneralBitFlags.StrongEncryption | GeneralBitFlags.EnhancedCompress | GeneralBitFlags.HeaderMasked):F})");
				}
			}
			if (num)
			{
				if (num5 <= 63 && num5 != 10 && num5 != 11 && num5 != 20 && num5 != 21 && num5 != 25 && num5 != 27 && num5 != 45 && num5 != 46 && num5 != 50 && num5 != 51 && num5 != 52 && num5 != 61 && num5 != 62 && num5 != 63)
				{
					throw new ZipException($"Version required to extract this entry is invalid ({num5})");
				}
				Encoding encoding = stringCodec_0.ZipInputEncoding(generalBitFlags);
				if (generalBitFlags.HasAny(GeneralBitFlags.ReservedPKware4 | GeneralBitFlags.ReservedPkware14 | GeneralBitFlags.ReservedPkware15))
				{
					throw new ZipException("Reserved bit flags cannot be set.");
				}
				if (generalBitFlags.HasAny(GeneralBitFlags.Encrypted) && num5 < 20)
				{
					throw new ZipException($"Version required to extract this entry is too low for encryption ({num5})");
				}
				if (generalBitFlags.HasAny(GeneralBitFlags.StrongEncryption))
				{
					if (!generalBitFlags.HasAny(GeneralBitFlags.Encrypted))
					{
						throw new ZipException("Strong encryption flag set but encryption flag is not set");
					}
					if (num5 < 50)
					{
						throw new ZipException($"Version required to extract this entry is too low for encryption ({num5})");
					}
				}
				if (generalBitFlags.HasAny(GeneralBitFlags.Patched) && num5 < 27)
				{
					throw new ZipException($"Patched data requires higher version than ({num5})");
				}
				if (generalBitFlags != (GeneralBitFlags)zipEntry_1.Flags)
				{
					throw new ZipException($"Central header/local header flags mismatch ({(GeneralBitFlags)zipEntry_1.Flags:F} vs {generalBitFlags:F})");
				}
				if (zipEntry_1.CompressionMethodForHeader != compressionMethod)
				{
					throw new ZipException($"Central header/local header compression method mismatch ({zipEntry_1.CompressionMethodForHeader:G} vs {compressionMethod:G})");
				}
				if (zipEntry_1.Version != num5)
				{
					throw new ZipException("Extract version mismatch");
				}
				if (generalBitFlags.HasAny(GeneralBitFlags.StrongEncryption) && num5 < 62)
				{
					throw new ZipException("Strong encryption flag set but version not high enough");
				}
				if (generalBitFlags.HasAny(GeneralBitFlags.HeaderMasked) && (num6 != 0 || num7 != 0))
				{
					throw new ZipException("Header masked set but date/time values non-zero");
				}
				if (!generalBitFlags.HasAny(GeneralBitFlags.Descriptor) && num8 != (uint)zipEntry_1.Crc)
				{
					throw new ZipException("Central header/local header crc mismatch");
				}
				if (num10 == 0L && num9 == 0L && num8 != 0)
				{
					throw new ZipException("Invalid CRC for empty entry");
				}
				if (zipEntry_1.Name.Length > num11)
				{
					throw new ZipException("File name length mismatch");
				}
				string text = encoding.GetString(array);
				if (text != zipEntry_1.Name)
				{
					throw new ZipException("Central header and local header file name mismatch");
				}
				if (zipEntry_1.IsDirectory)
				{
					if (num10 > 0L)
					{
						throw new ZipException("Directory cannot have size");
					}
					if (zipEntry_1.IsCrypted)
					{
						if (num9 > zipEntry_1.EncryptionOverheadSize + 2)
						{
							throw new ZipException("Directory compressed size invalid");
						}
					}
					else if (num9 > 2L)
					{
						throw new ZipException("Directory compressed size invalid");
					}
				}
				if (!ZipNameTransform.IsValidName(text, relaxed: true))
				{
					throw new ZipException("Name is invalid");
				}
			}
			if (!generalBitFlags.HasAny(GeneralBitFlags.Descriptor) || ((num10 > 0L || num9 > 0L) && zipEntry_1.Size > 0L))
			{
				if (num10 != 0L && num10 != zipEntry_1.Size)
				{
					throw new ZipException($"Size mismatch between central header ({zipEntry_1.Size}) and local header ({num10})");
				}
				if (num9 != 0L && num9 != zipEntry_1.CompressedSize && num9 != 4294967295L && num9 != -1L)
				{
					throw new ZipException($"Compressed size mismatch between central header({zipEntry_1.CompressedSize}) and local header({num9})");
				}
			}
			int num13 = num11 + num12;
			return long_0 + zipEntry_1.Offset + 30L + num13;
		}
	}

	public void BeginUpdate(IArchiveStorage archiveStorage, GInterface2 dataSource)
	{
		if (!bool_1)
		{
			if (IsEmbeddedArchive)
			{
				throw new ZipException("Cannot update embedded/SFX archives");
			}
			iarchiveStorage_0 = archiveStorage ?? throw new ArgumentNullException("archiveStorage");
			ginterface2_0 = dataSource ?? throw new ArgumentNullException("dataSource");
			dictionary_0 = new Dictionary<string, int>();
			list_0 = new List<Class34>(zipEntry_0.Length);
			ZipEntry[] array = zipEntry_0;
			foreach (ZipEntry zipEntry in array)
			{
				int count = list_0.Count;
				list_0.Add(new Class34(zipEntry));
				dictionary_0.Add(zipEntry.Name, count);
			}
			list_0.Sort(new Class33());
			int num = 0;
			foreach (Class34 item in list_0)
			{
				if (num == list_0.Count - 1)
				{
					break;
				}
				item.method_8(list_0[num + 1].method_0().Offset - item.method_0().Offset);
				num++;
			}
			long_1 = list_0.Count;
			bool_4 = false;
			bool_5 = false;
			class35_0 = null;
			return;
		}
		throw new ObjectDisposedException("ZipFile");
	}

	public void BeginUpdate(IArchiveStorage archiveStorage)
	{
		BeginUpdate(archiveStorage, new DynamicDiskDataSource());
	}

	public void BeginUpdate()
	{
		if (Name != null)
		{
			BeginUpdate(new DiskArchiveStorage(this), new DynamicDiskDataSource());
		}
		else
		{
			BeginUpdate(new MemoryArchiveStorage(), new DynamicDiskDataSource());
		}
	}

	public void CommitUpdate()
	{
		if (bool_1)
		{
			throw new ObjectDisposedException("ZipFile");
		}
		method_30();
		try
		{
			dictionary_0.Clear();
			dictionary_0 = null;
			if (!bool_4)
			{
				if (bool_5 && !bool_3)
				{
					method_28();
				}
				else if (zipEntry_0.Length == 0)
				{
					byte[] comment = ((class35_0 == null) ? stringCodec_0.ZipArchiveCommentEncoding.GetBytes(string_1) : class35_0.method_1());
					ZipFormat.WriteEndOfCentralDirectory(stream_0, 0L, 0L, 0L, comment);
				}
			}
			else
			{
				method_29();
			}
		}
		finally
		{
			method_12();
		}
	}

	public void AbortUpdate()
	{
		method_12();
	}

	public void SetComment(string comment)
	{
		if (bool_1)
		{
			throw new ObjectDisposedException("ZipFile");
		}
		method_30();
		class35_0 = new Class35(comment, stringCodec_0.ZipArchiveCommentEncoding);
		if (class35_0.RawLength > 65535)
		{
			class35_0 = null;
			throw new ZipException("Comment length exceeds maximum - 65535");
		}
		bool_5 = true;
	}

	private void method_3(Class34 class34_0)
	{
		bool_4 = true;
		int num = method_20(class34_0.method_0().Name, bool_6: true);
		if (num < 0)
		{
			num = list_0.Count;
			list_0.Add(class34_0);
			long_1++;
			dictionary_0.Add(class34_0.method_0().Name, num);
		}
		else
		{
			if (list_0[num] == null)
			{
				long_1++;
			}
			list_0[num] = class34_0;
		}
	}

	public void Add(string fileName, CompressionMethod compressionMethod, bool useUnicodeText)
	{
		if (fileName != null)
		{
			if (bool_1)
			{
				throw new ObjectDisposedException("ZipFile");
			}
			smethod_0(compressionMethod);
			method_30();
			bool_4 = true;
			ZipEntry zipEntry = EntryFactory.MakeFileEntry(fileName);
			zipEntry.IsUnicodeText = useUnicodeText;
			zipEntry.CompressionMethod = compressionMethod;
			method_3(new Class34(fileName, zipEntry));
			return;
		}
		throw new ArgumentNullException("fileName");
	}

	public void Add(string fileName, CompressionMethod compressionMethod)
	{
		if (fileName == null)
		{
			throw new ArgumentNullException("fileName");
		}
		smethod_0(compressionMethod);
		method_30();
		bool_4 = true;
		ZipEntry zipEntry = EntryFactory.MakeFileEntry(fileName);
		zipEntry.CompressionMethod = compressionMethod;
		method_3(new Class34(fileName, zipEntry));
	}

	public void Add(string fileName)
	{
		if (fileName == null)
		{
			throw new ArgumentNullException("fileName");
		}
		method_30();
		method_3(new Class34(fileName, EntryFactory.MakeFileEntry(fileName)));
	}

	public void Add(string fileName, string entryName)
	{
		if (fileName != null)
		{
			if (entryName == null)
			{
				throw new ArgumentNullException("entryName");
			}
			method_30();
			method_3(new Class34(fileName, EntryFactory.MakeFileEntry(fileName, entryName, useFileSystem: true)));
			return;
		}
		throw new ArgumentNullException("fileName");
	}

	public void Add(IStaticDataSource dataSource, string entryName)
	{
		if (dataSource != null)
		{
			if (entryName == null)
			{
				throw new ArgumentNullException("entryName");
			}
			method_30();
			method_3(new Class34(dataSource, EntryFactory.MakeFileEntry(entryName, useFileSystem: false)));
			return;
		}
		throw new ArgumentNullException("dataSource");
	}

	public void Add(IStaticDataSource dataSource, string entryName, CompressionMethod compressionMethod)
	{
		if (dataSource == null)
		{
			throw new ArgumentNullException("dataSource");
		}
		if (entryName == null)
		{
			throw new ArgumentNullException("entryName");
		}
		smethod_0(compressionMethod);
		method_30();
		ZipEntry zipEntry = EntryFactory.MakeFileEntry(entryName, useFileSystem: false);
		zipEntry.CompressionMethod = compressionMethod;
		method_3(new Class34(dataSource, zipEntry));
	}

	public void Add(IStaticDataSource dataSource, string entryName, CompressionMethod compressionMethod, bool useUnicodeText)
	{
		if (dataSource == null)
		{
			throw new ArgumentNullException("dataSource");
		}
		if (entryName == null)
		{
			throw new ArgumentNullException("entryName");
		}
		smethod_0(compressionMethod);
		method_30();
		ZipEntry zipEntry = EntryFactory.MakeFileEntry(entryName, useFileSystem: false);
		zipEntry.IsUnicodeText = useUnicodeText;
		zipEntry.CompressionMethod = compressionMethod;
		method_3(new Class34(dataSource, zipEntry));
	}

	public void Add(ZipEntry entry)
	{
		if (entry == null)
		{
			throw new ArgumentNullException("entry");
		}
		method_30();
		if (entry.Size != 0L || entry.CompressedSize != 0L)
		{
			throw new ZipException("Entry cannot have any data");
		}
		method_3(new Class34(Enum15.Add, entry));
	}

	public void Add(IStaticDataSource dataSource, ZipEntry entry)
	{
		if (entry == null)
		{
			throw new ArgumentNullException("entry");
		}
		if (dataSource != null)
		{
			if (entry.AESKeySize > 0)
			{
				throw new NotSupportedException("Creation of AES encrypted entries is not supported");
			}
			smethod_0(entry.CompressionMethod);
			method_30();
			method_3(new Class34(dataSource, entry));
			return;
		}
		throw new ArgumentNullException("dataSource");
	}

	public void AddDirectory(string directoryName)
	{
		if (directoryName == null)
		{
			throw new ArgumentNullException("directoryName");
		}
		method_30();
		ZipEntry zipEntry_ = EntryFactory.MakeDirectoryEntry(directoryName);
		method_3(new Class34(Enum15.Add, zipEntry_));
	}

	private static void smethod_0(CompressionMethod compressionMethod_0)
	{
		if (compressionMethod_0 != CompressionMethod.Deflated && compressionMethod_0 != CompressionMethod.Stored && compressionMethod_0 != CompressionMethod.BZip2)
		{
			throw new NotImplementedException("Compression method not supported");
		}
	}

	public bool Delete(string fileName)
	{
		if (fileName != null)
		{
			method_30();
			int num = method_20(fileName);
			if (num < 0 || list_0[num] == null)
			{
				throw new ZipException("Cannot find entry to delete");
			}
			bool_4 = true;
			list_0[num] = null;
			long_1--;
			return true;
		}
		throw new ArgumentNullException("fileName");
	}

	public void Delete(ZipEntry entry)
	{
		if (entry == null)
		{
			throw new ArgumentNullException("entry");
		}
		method_30();
		int num = method_19(entry);
		if (num < 0)
		{
			throw new ZipException("Cannot find entry to delete");
		}
		bool_4 = true;
		list_0[num] = null;
		long_1--;
	}

	private void method_4(int int_1)
	{
		stream_0.WriteByte((byte)(int_1 & 0xFF));
		stream_0.WriteByte((byte)((int_1 >> 8) & 0xFF));
	}

	private void method_5(ushort ushort_0)
	{
		stream_0.WriteByte((byte)(ushort_0 & 0xFF));
		stream_0.WriteByte((byte)(ushort_0 >> 8));
	}

	private void method_6(int int_1)
	{
		method_4(int_1 & 0xFFFF);
		method_4(int_1 >> 16);
	}

	private void method_7(uint uint_0)
	{
		method_5((ushort)(uint_0 & 0xFFFF));
		method_5((ushort)(uint_0 >> 16));
	}

	private void method_8(long long_2)
	{
		method_6((int)(long_2 & 0xFFFFFFFFL));
		method_6((int)(long_2 >> 32));
	}

	private void method_9(ulong ulong_0)
	{
		method_7((uint)(ulong_0 & 0xFFFFFFFFL));
		method_7((uint)(ulong_0 >> 32));
	}

	private void method_10(Class34 class34_0)
	{
		ZipEntry zipEntry = class34_0.method_1();
		zipEntry.Offset = stream_0.Position;
		if (class34_0.Command != 0)
		{
			if (zipEntry.CompressionMethod == CompressionMethod.Deflated)
			{
				if (zipEntry.Size == 0L)
				{
					zipEntry.CompressedSize = zipEntry.Size;
					zipEntry.Crc = 0L;
					zipEntry.CompressionMethod = CompressionMethod.Stored;
				}
			}
			else if (zipEntry.CompressionMethod == CompressionMethod.Stored)
			{
				zipEntry.Flags &= -9;
			}
			if (!method_1())
			{
				zipEntry.IsCrypted = false;
			}
			else
			{
				zipEntry.IsCrypted = true;
				if (zipEntry.Crc < 0L)
				{
					zipEntry.Flags |= 8;
				}
			}
			switch (useZip64_0)
			{
			case UseZip64.On:
				zipEntry.method_1();
				break;
			case UseZip64.Dynamic:
				if (zipEntry.Size < 0L)
				{
					zipEntry.method_1();
				}
				break;
			}
		}
		method_6(67324752);
		method_4(zipEntry.Version);
		method_4(zipEntry.Flags);
		method_4((byte)zipEntry.CompressionMethodForHeader);
		method_6((int)zipEntry.DosTime);
		if (!zipEntry.HasCrc)
		{
			class34_0.method_6(stream_0.Position);
			method_6(0);
		}
		else
		{
			method_6((int)zipEntry.Crc);
		}
		if (!zipEntry.LocalHeaderRequiresZip64)
		{
			if (zipEntry.CompressedSize < 0L || zipEntry.Size < 0L)
			{
				class34_0.method_4(stream_0.Position);
			}
			method_6((int)zipEntry.CompressedSize);
			method_6((int)zipEntry.Size);
		}
		else
		{
			method_6(-1);
			method_6(-1);
		}
		byte[] bytes = stringCodec_0.ZipInputEncoding(zipEntry.Flags).GetBytes(zipEntry.Name);
		if (bytes.Length <= 65535)
		{
			ZipExtraData zipExtraData = new ZipExtraData(zipEntry.ExtraData);
			if (!zipEntry.LocalHeaderRequiresZip64)
			{
				zipExtraData.Delete(1);
			}
			else
			{
				zipExtraData.StartNewEntry();
				zipExtraData.AddLeLong(zipEntry.Size);
				zipExtraData.AddLeLong(zipEntry.CompressedSize);
				zipExtraData.AddNewEntry(1);
			}
			zipEntry.ExtraData = zipExtraData.GetEntryData();
			method_4(bytes.Length);
			method_4(zipEntry.ExtraData.Length);
			if (bytes.Length != 0)
			{
				stream_0.Write(bytes, 0, bytes.Length);
			}
			if (zipEntry.LocalHeaderRequiresZip64)
			{
				if (!zipExtraData.Find(1))
				{
					throw new ZipException("Internal error cannot find extra data");
				}
				class34_0.method_4(stream_0.Position + zipExtraData.CurrentReadIndex);
			}
			if (zipEntry.ExtraData.Length != 0)
			{
				stream_0.Write(zipEntry.ExtraData, 0, zipEntry.ExtraData.Length);
			}
			return;
		}
		throw new ZipException("Entry name too long.");
	}

	private int method_11(ZipEntry zipEntry_1)
	{
		bool flag;
		int num2;
		if (zipEntry_1.CompressedSize >= 0L)
		{
			if (zipEntry_1.Size < 0L)
			{
				throw new ZipException("Attempt to write central directory entry with unknown size");
			}
			if (zipEntry_1.Crc < 0L)
			{
				throw new ZipException("Attempt to write central directory entry with unknown crc");
			}
			method_6(33639248);
			method_4((zipEntry_1.HostSystem << 8) | zipEntry_1.VersionMadeBy);
			method_4(zipEntry_1.Version);
			method_4(zipEntry_1.Flags);
			method_4((byte)zipEntry_1.CompressionMethodForHeader);
			method_6((int)zipEntry_1.DosTime);
			method_6((int)zipEntry_1.Crc);
			flag = false;
			int num;
			if (zipEntry_1.IsZip64Forced())
			{
				num = 1;
			}
			else
			{
				if (zipEntry_1.CompressedSize < 4294967295L)
				{
					method_6((int)(zipEntry_1.CompressedSize & 0xFFFFFFFFL));
					num2 = 0;
					goto IL_00ed;
				}
				num = 1;
			}
			flag = (byte)num != 0;
			method_6(-1);
			num2 = 0;
			goto IL_00ed;
		}
		throw new ZipException("Attempt to write central directory entry with unknown csize");
		IL_00ed:
		bool flag2 = (byte)num2 != 0;
		int num3;
		if (zipEntry_1.IsZip64Forced())
		{
			num3 = 1;
		}
		else
		{
			if (zipEntry_1.Size < 4294967295L)
			{
				method_6((int)zipEntry_1.Size);
				goto IL_0122;
			}
			num3 = 1;
		}
		flag2 = (byte)num3 != 0;
		method_6(-1);
		goto IL_0122;
		IL_0122:
		byte[] bytes = stringCodec_0.ZipInputEncoding(zipEntry_1.Flags).GetBytes(zipEntry_1.Name);
		if (bytes.Length > 65535)
		{
			throw new ZipException("Entry name is too long.");
		}
		method_4(bytes.Length);
		ZipExtraData zipExtraData = new ZipExtraData(zipEntry_1.ExtraData);
		if (!zipEntry_1.CentralHeaderRequiresZip64)
		{
			zipExtraData.Delete(1);
		}
		else
		{
			zipExtraData.StartNewEntry();
			if (flag2)
			{
				zipExtraData.AddLeLong(zipEntry_1.Size);
			}
			if (flag)
			{
				zipExtraData.AddLeLong(zipEntry_1.CompressedSize);
			}
			if (zipEntry_1.Offset >= 4294967295L)
			{
				zipExtraData.AddLeLong(zipEntry_1.Offset);
			}
			zipExtraData.AddNewEntry(1);
		}
		byte[] entryData = zipExtraData.GetEntryData();
		method_4(entryData.Length);
		method_4((zipEntry_1.Comment != null) ? zipEntry_1.Comment.Length : 0);
		method_4(0);
		method_4(0);
		if (zipEntry_1.ExternalFileAttributes != -1)
		{
			method_6(zipEntry_1.ExternalFileAttributes);
		}
		else if (zipEntry_1.IsDirectory)
		{
			method_7(16u);
		}
		else
		{
			method_7(0u);
		}
		if (zipEntry_1.Offset < 4294967295L)
		{
			method_7((uint)zipEntry_1.Offset);
		}
		else
		{
			method_7(uint.MaxValue);
		}
		if (bytes.Length != 0)
		{
			stream_0.Write(bytes, 0, bytes.Length);
		}
		if (entryData.Length != 0)
		{
			stream_0.Write(entryData, 0, entryData.Length);
		}
		byte[] array = ((zipEntry_1.Comment == null) ? Empty.Array<byte>() : Encoding.ASCII.GetBytes(zipEntry_1.Comment));
		int num4;
		if (array.Length == 0)
		{
			num4 = 46;
		}
		else
		{
			stream_0.Write(array, 0, array.Length);
			num4 = 46;
		}
		return num4 + bytes.Length + entryData.Length + array.Length;
	}

	private void method_12()
	{
		ginterface2_0 = null;
		list_0 = null;
		dictionary_0 = null;
		if (iarchiveStorage_0 != null)
		{
			iarchiveStorage_0.Dispose();
			iarchiveStorage_0 = null;
		}
	}

	private string fBgyhrbFfv0(string string_3)
	{
		INameTransform nameTransform = NameTransform;
		if (nameTransform != null)
		{
			return nameTransform.TransformFile(string_3);
		}
		return string_3;
	}

	private string method_13(string string_3)
	{
		INameTransform nameTransform = NameTransform;
		if (nameTransform == null)
		{
			return string_3;
		}
		return nameTransform.TransformDirectory(string_3);
	}

	private byte[] method_14()
	{
		if (byte_1 == null)
		{
			byte_1 = new byte[int_0];
		}
		return byte_1;
	}

	private void method_15(Class34 class34_0, Stream stream_1, Stream stream_2)
	{
		int num = smethod_1(class34_0, bool_6: false);
		if (num == 0)
		{
			return;
		}
		byte[] array = method_14();
		stream_2.Read(array, 0, 4);
		stream_1.Write(array, 0, 4);
		if (BitConverter.ToUInt32(array, 0) != 134695760)
		{
			num -= array.Length;
		}
		while (true)
		{
			if (num > 0)
			{
				int count = Math.Min(array.Length, num);
				int num2 = stream_2.Read(array, 0, count);
				if (num2 <= 0)
				{
					break;
				}
				stream_1.Write(array, 0, num2);
				num -= num2;
				continue;
			}
			return;
		}
		throw new ZipException("Unxpected end of stream");
	}

	private void method_16(Class34 class34_0, Stream stream_1, Stream stream_2, long long_2, bool bool_6)
	{
		if (stream_1 == stream_2)
		{
			throw new InvalidOperationException("Destination and source are the same");
		}
		Crc32 crc = new Crc32();
		byte[] array = method_14();
		long num = long_2;
		long num2 = 0L;
		int num4;
		do
		{
			int num3 = array.Length;
			if (long_2 < num3)
			{
				num3 = (int)long_2;
			}
			num4 = stream_2.Read(array, 0, num3);
			if (num4 > 0)
			{
				if (bool_6)
				{
					crc.Update(new ArraySegment<byte>(array, 0, num4));
				}
				stream_1.Write(array, 0, num4);
				long_2 -= num4;
				num2 += num4;
			}
		}
		while (num4 > 0 && long_2 > 0L);
		if (num2 != num)
		{
			throw new ZipException($"Failed to copy bytes expected {num} read {num2}");
		}
		if (bool_6)
		{
			class34_0.method_1().Crc = crc.Value;
		}
	}

	private static int smethod_1(Class34 class34_0, bool bool_6)
	{
		if (!((GeneralBitFlags)class34_0.method_0().Flags).HasAny(GeneralBitFlags.Descriptor))
		{
			return 0;
		}
		int num = (class34_0.method_0().LocalHeaderRequiresZip64 ? 24 : 16);
		if (bool_6)
		{
			return num;
		}
		return num - 4;
	}

	private void method_17(Class34 class34_0, Stream stream_1, ref long long_2, long long_3)
	{
		byte[] array = method_14();
		stream_1.Position = long_3;
		stream_1.Read(array, 0, 4);
		bool bool_ = BitConverter.ToUInt32(array, 0) == 134695760;
		int num = smethod_1(class34_0, bool_);
		while (num > 0)
		{
			stream_1.Position = long_3;
			int num2 = stream_1.Read(array, 0, num);
			if (num2 > 0)
			{
				stream_1.Position = long_2;
				stream_1.Write(array, 0, num2);
				num -= num2;
				long_2 += num2;
				long_3 += num2;
				continue;
			}
			throw new ZipException("Unexpected end of stream");
		}
	}

	private void method_18(Class34 class34_0, Stream stream_1, bool bool_6, ref long long_2, ref long long_3)
	{
		long num = class34_0.method_0().CompressedSize;
		Crc32 crc = new Crc32();
		byte[] array = method_14();
		long num2 = num;
		long num3 = 0L;
		int num5;
		do
		{
			int num4 = array.Length;
			if (num < num4)
			{
				num4 = (int)num;
			}
			stream_1.Position = long_3;
			num5 = stream_1.Read(array, 0, num4);
			if (num5 > 0)
			{
				if (bool_6)
				{
					crc.Update(new ArraySegment<byte>(array, 0, num5));
				}
				stream_1.Position = long_2;
				stream_1.Write(array, 0, num5);
				long_2 += num5;
				long_3 += num5;
				num -= num5;
				num3 += num5;
			}
		}
		while (num5 > 0 && num > 0L);
		if (num3 != num2)
		{
			throw new ZipException($"Failed to copy bytes expected {num2} read {num3}");
		}
		if (bool_6)
		{
			class34_0.method_1().Crc = crc.Value;
		}
	}

	private int method_19(ZipEntry zipEntry_1)
	{
		int result = -1;
		if (dictionary_0.ContainsKey(zipEntry_1.Name))
		{
			result = dictionary_0[zipEntry_1.Name];
		}
		return result;
	}

	private int method_20(string string_3, bool bool_6 = false)
	{
		int result = -1;
		string key = ((!bool_6) ? fBgyhrbFfv0(string_3) : string_3);
		if (dictionary_0.ContainsKey(key))
		{
			result = dictionary_0[key];
		}
		return result;
	}

	private Stream method_21(ZipEntry zipEntry_1)
	{
		Stream stream = stream_0;
		if (zipEntry_1.IsCrypted)
		{
			stream = method_39(stream, zipEntry_1);
		}
		switch (zipEntry_1.CompressionMethod)
		{
		default:
			throw new ZipException("Unknown compression method " + zipEntry_1.CompressionMethod);
		case CompressionMethod.BZip2:
			stream = new BZip2OutputStream(stream)
			{
				IsStreamOwner = zipEntry_1.IsCrypted
			};
			break;
		case CompressionMethod.Deflated:
			stream = new DeflaterOutputStream(stream, new Deflater(9, noZlibHeaderOrFooter: true))
			{
				IsStreamOwner = zipEntry_1.IsCrypted
			};
			break;
		case CompressionMethod.Stored:
			if (!zipEntry_1.IsCrypted)
			{
				stream = new Stream0(stream);
			}
			break;
		}
		return stream;
	}

	private void method_22(ZipFile zipFile_0, Class34 class34_0)
	{
		Stream stream = null;
		if (class34_0.method_0().IsFile)
		{
			stream = class34_0.method_9();
			if (stream == null)
			{
				stream = ginterface2_0.GetSource(class34_0.method_0(), class34_0.method_2());
			}
		}
		bool bool_ = class34_0.method_0().AESKeySize == 0;
		if (stream == null)
		{
			zipFile_0.method_10(class34_0);
			class34_0.method_1().CompressedSize = 0L;
			return;
		}
		using (stream)
		{
			long length = stream.Length;
			if (class34_0.method_1().Size >= 0L)
			{
				if (class34_0.method_1().Size != length)
				{
					throw new ZipException("Entry size/stream size mismatch");
				}
			}
			else
			{
				class34_0.method_1().Size = length;
			}
			zipFile_0.method_10(class34_0);
			long position = zipFile_0.stream_0.Position;
			using (Stream stream_ = zipFile_0.method_21(class34_0.method_1()))
			{
				method_16(class34_0, stream_, stream, length, bool_);
			}
			long position2 = zipFile_0.stream_0.Position;
			class34_0.method_1().CompressedSize = position2 - position;
			if ((class34_0.method_1().Flags & 8) == 8)
			{
				ZipFormat.WriteDataDescriptor(zipFile_0.stream_0, class34_0.method_1());
			}
		}
	}

	private void method_23(ZipFile zipFile_0, Class34 class34_0)
	{
		zipFile_0.method_10(class34_0);
		long position = zipFile_0.stream_0.Position;
		if (class34_0.method_0().IsFile && class34_0.method_2() != null)
		{
			using Stream stream_ = zipFile_0.method_21(class34_0.method_1());
			using Stream stream = GetInputStream(class34_0.method_0());
			method_16(class34_0, stream_, stream, stream.Length, bool_6: true);
		}
		long position2 = zipFile_0.stream_0.Position;
		class34_0.method_0().CompressedSize = position2 - position;
	}

	private void method_24(ZipFile zipFile_0, Class34 class34_0, ref long long_2)
	{
		bool num = class34_0.method_0().Offset == long_2;
		if (!num)
		{
			stream_0.Position = long_2;
			zipFile_0.method_10(class34_0);
			long_2 = stream_0.Position;
		}
		long num2 = 0L;
		long num3 = class34_0.method_0().Offset + 26L;
		stream_0.Seek(num3, SeekOrigin.Begin);
		uint num4 = method_32();
		uint num5 = method_32();
		num2 = stream_0.Position + num4 + num5;
		if (num)
		{
			if (class34_0.method_7() != -1L)
			{
				long_2 += class34_0.method_7();
				return;
			}
			long_2 += num2 - num3 + 26L;
			long_2 += class34_0.method_0().CompressedSize;
			stream_0.Seek(long_2, SeekOrigin.Begin);
			bool bool_ = method_33() == 134695760;
			long_2 += smethod_1(class34_0, bool_);
		}
		else
		{
			if (class34_0.method_0().CompressedSize > 0L)
			{
				method_18(class34_0, stream_0, bool_6: false, ref long_2, ref num2);
			}
			method_17(class34_0, stream_0, ref long_2, num2);
		}
	}

	private void method_25(ZipFile zipFile_0, Class34 class34_0)
	{
		zipFile_0.method_10(class34_0);
		if (class34_0.method_0().CompressedSize > 0L)
		{
			long offset = class34_0.method_0().Offset + 26L;
			stream_0.Seek(offset, SeekOrigin.Begin);
			uint num = method_32();
			uint num2 = method_32();
			stream_0.Seek(num + num2, SeekOrigin.Current);
			method_16(class34_0, zipFile_0.stream_0, stream_0, class34_0.method_0().CompressedSize, bool_6: false);
		}
		method_15(class34_0, zipFile_0.stream_0, stream_0);
	}

	private void method_26(Stream stream_1)
	{
		bool_3 = false;
		stream_0 = stream_1 ?? throw new ZipException("Failed to reopen archive - no source");
		method_36();
	}

	private void method_27()
	{
		if (Name == null)
		{
			throw new InvalidOperationException("Name is not known cannot Reopen");
		}
		method_26(File.Open(Name, FileMode.Open, FileAccess.Read, FileShare.Read));
	}

	private void method_28()
	{
		long length = stream_0.Length;
		Stream stream;
		if (iarchiveStorage_0.UpdateMode != FileUpdateMode.Safe)
		{
			if (iarchiveStorage_0.UpdateMode == FileUpdateMode.Direct)
			{
				stream_0 = iarchiveStorage_0.OpenForDirectUpdate(stream_0);
				stream = stream_0;
			}
			else
			{
				stream_0.Dispose();
				stream_0 = null;
				stream = new FileStream(Name, FileMode.Open, FileAccess.ReadWrite);
			}
		}
		else
		{
			stream = iarchiveStorage_0.MakeTemporaryCopy(stream_0);
			stream_0.Dispose();
			stream_0 = null;
		}
		try
		{
			if (ZipFormat.LocateBlockWithSignature(stream, 101010256, length, 22, 65535) < 0L)
			{
				throw new ZipException("Cannot find central directory");
			}
			stream.Position += 16L;
			byte[] array = class35_0.method_1();
			ByteOrderStreamExtensions.WriteLEShort(stream, array.Length);
			stream.Write(array, 0, array.Length);
			stream.SetLength(stream.Position);
		}
		finally
		{
			if (stream != stream_0)
			{
				stream.Dispose();
			}
		}
		if (iarchiveStorage_0.UpdateMode != FileUpdateMode.Safe)
		{
			method_36();
		}
		else
		{
			method_26(iarchiveStorage_0.ConvertTemporaryToFinal());
		}
	}

	private void method_29()
	{
		long num = 0L;
		long num2 = 0L;
		bool flag = false;
		long long_ = 0L;
		ZipFile zipFile;
		if (!IsNewArchive)
		{
			if (iarchiveStorage_0.UpdateMode == FileUpdateMode.Direct)
			{
				zipFile = this;
				zipFile.stream_0.Position = 0L;
				flag = true;
				list_0.Sort(new Class33());
			}
			else
			{
				zipFile = Create(iarchiveStorage_0.GetTemporaryOutput());
				zipFile.UseZip64 = UseZip64;
				if (byte_0 != null)
				{
					zipFile.byte_0 = (byte[])byte_0.Clone();
				}
			}
		}
		else
		{
			zipFile = this;
			zipFile.stream_0.Position = 0L;
			flag = true;
		}
		try
		{
			foreach (Class34 item in list_0)
			{
				if (item == null)
				{
					continue;
				}
				switch (item.Command)
				{
				case (Enum15)0:
					if (flag)
					{
						method_24(zipFile, item, ref long_);
					}
					else
					{
						method_25(zipFile, item);
					}
					break;
				case (Enum15)1:
					method_23(zipFile, item);
					break;
				case Enum15.Add:
					if (!IsNewArchive && flag)
					{
						zipFile.stream_0.Position = long_;
					}
					method_22(zipFile, item);
					if (flag)
					{
						long_ = zipFile.stream_0.Position;
					}
					break;
				}
			}
			if (!IsNewArchive && flag)
			{
				zipFile.stream_0.Position = long_;
			}
			long position = zipFile.stream_0.Position;
			foreach (Class34 item2 in list_0)
			{
				if (item2 != null)
				{
					num += zipFile.method_11(item2.method_1());
				}
			}
			Class35 @class = class35_0;
			object obj;
			if (@class != null)
			{
				obj = @class.method_1();
				if (obj != null)
				{
					goto IL_0223;
				}
			}
			else
			{
				obj = null;
			}
			obj = stringCodec_0.ZipArchiveCommentEncoding.GetBytes(string_1);
			goto IL_0223;
			IL_0223:
			byte[] comment = (byte[])obj;
			ZipFormat.WriteEndOfCentralDirectory(zipFile.stream_0, long_1, num, position, comment);
			num2 = zipFile.stream_0.Position;
			foreach (Class34 item3 in list_0)
			{
				if (item3 == null)
				{
					continue;
				}
				if (item3.method_5() > 0L && item3.method_1().CompressedSize > 0L)
				{
					zipFile.stream_0.Position = item3.method_5();
					zipFile.method_6((int)item3.method_1().Crc);
				}
				if (item3.method_3() > 0L)
				{
					zipFile.stream_0.Position = item3.method_3();
					if (!item3.method_1().LocalHeaderRequiresZip64)
					{
						zipFile.method_6((int)item3.method_1().CompressedSize);
						zipFile.method_6((int)item3.method_1().Size);
					}
					else
					{
						zipFile.method_8(item3.method_1().Size);
						zipFile.method_8(item3.method_1().CompressedSize);
					}
				}
			}
		}
		catch
		{
			zipFile.Close();
			if (!flag && zipFile.Name != null)
			{
				File.Delete(zipFile.Name);
			}
			throw;
		}
		if (flag)
		{
			zipFile.stream_0.SetLength(num2);
			zipFile.stream_0.Flush();
			bool_3 = false;
			method_36();
		}
		else
		{
			stream_0.Dispose();
			method_26(iarchiveStorage_0.ConvertTemporaryToFinal());
		}
	}

	private void method_30()
	{
		if (list_0 == null)
		{
			throw new InvalidOperationException("BeginUpdate has not been called");
		}
	}

	void IDisposable.Dispose()
	{
		Close();
	}

	private void method_31(bool bool_6)
	{
		if (bool_1)
		{
			return;
		}
		bool_1 = true;
		zipEntry_0 = Empty.Array<ZipEntry>();
		if (IsStreamOwner && stream_0 != null)
		{
			lock (stream_0)
			{
				stream_0.Dispose();
			}
		}
		method_12();
	}

	protected virtual void Dispose(bool disposing)
	{
		method_31(disposing);
	}

	private ushort method_32()
	{
		int num = stream_0.ReadByte();
		if (num < 0)
		{
			throw new EndOfStreamException("End of stream");
		}
		int num2 = stream_0.ReadByte();
		if (num2 < 0)
		{
			throw new EndOfStreamException("End of stream");
		}
		return (ushort)((ushort)num | (ushort)(num2 << 8));
	}

	private uint method_33()
	{
		return (uint)(method_32() | (method_32() << 16));
	}

	private ulong method_34()
	{
		return method_33() | ((ulong)method_33() << 32);
	}

	private long method_35(int int_1, long long_2, int int_2, int int_3)
	{
		return ZipFormat.LocateBlockWithSignature(stream_0, int_1, long_2, int_2, int_3);
	}

	private void method_36()
	{
		if (stream_0.CanSeek)
		{
			long num = method_35(101010256, stream_0.Length, 22, 65535);
			if (num >= 0L)
			{
				ushort num2 = method_32();
				ushort num3 = method_32();
				ulong num4 = method_32();
				ulong num5 = method_32();
				ulong num6 = method_33();
				long num7 = method_33();
				uint num8 = method_32();
				if (num8 == 0)
				{
					string_1 = string.Empty;
				}
				else
				{
					byte[] array = new byte[num8];
					StreamUtils.ReadFully(stream_0, array);
					string_1 = stringCodec_0.ZipArchiveCommentEncoding.GetString(array);
				}
				bool flag = false;
				bool flag2 = num2 == ushort.MaxValue || num3 == ushort.MaxValue || num4 == 65535L || num5 == 65535L || num6 == 4294967295L || num7 == 4294967295L;
				if (method_35(117853008, num - 4L, 20, 0) >= 0L)
				{
					flag = true;
					method_33();
					ulong num9 = method_34();
					method_33();
					stream_0.Position = (long)num9;
					if ((long)method_33() != 101075792L)
					{
						throw new ZipException($"Invalid Zip64 Central directory signature at {num9:X}");
					}
					method_34();
					method_32();
					method_32();
					method_33();
					method_33();
					num4 = method_34();
					num5 = method_34();
					num6 = method_34();
					num7 = (long)method_34();
				}
				else if (flag2)
				{
					throw new ZipException("Cannot find Zip64 locator");
				}
				zipEntry_0 = new ZipEntry[num4];
				if (!flag && num7 < num - (long)(4L + num6))
				{
					long_0 = num - ((long)(4L + num6) + num7);
					if (long_0 <= 0L)
					{
						throw new ZipException("Invalid embedded zip archive");
					}
				}
				stream_0.Seek(long_0 + num7, SeekOrigin.Begin);
				ulong num10 = 0uL;
				while (true)
				{
					if (num10 < num4)
					{
						if (method_33() != 33639248)
						{
							break;
						}
						int madeByInfo = method_32();
						int versionRequiredToExtract = method_32();
						int flags = method_32();
						int method = method_32();
						uint num11 = method_33();
						uint num12 = method_33();
						long num13 = method_33();
						long num14 = method_33();
						int num15 = method_32();
						int num16 = method_32();
						int num17 = method_32();
						method_32();
						method_32();
						uint externalFileAttributes = method_33();
						long offset = method_33();
						byte[] array2 = new byte[Math.Max(num15, num17)];
						Encoding encoding = stringCodec_0.ZipInputEncoding(flags);
						StreamUtils.ReadFully(stream_0, array2, 0, num15);
						string name = encoding.GetString(array2, 0, num15);
						bool unicode = EncodingExtensions.IsZipUnicode(encoding);
						ZipEntry zipEntry = new ZipEntry(name, versionRequiredToExtract, madeByInfo, (CompressionMethod)method, unicode)
						{
							Crc = ((long)num12 & 0xFFFFFFFFL),
							Size = (num14 & 0xFFFFFFFFL),
							CompressedSize = (num13 & 0xFFFFFFFFL),
							Flags = flags,
							DosTime = num11,
							ZipFileIndex = (long)num10,
							Offset = offset,
							ExternalFileAttributes = (int)externalFileAttributes
						};
						if (zipEntry.HasFlag(GeneralBitFlags.Descriptor))
						{
							zipEntry.CryptoCheckValue = (byte)((num11 >> 8) & 0xFF);
						}
						else
						{
							zipEntry.CryptoCheckValue = (byte)(num12 >> 24);
						}
						if (num16 > 0)
						{
							byte[] array3 = new byte[num16];
							StreamUtils.ReadFully(stream_0, array3);
							zipEntry.ExtraData = array3;
						}
						zipEntry.ProcessExtraData(localHeader: false);
						if (num17 > 0)
						{
							StreamUtils.ReadFully(stream_0, array2, 0, num17);
							zipEntry.Comment = encoding.GetString(array2, 0, num17);
						}
						zipEntry_0[num10] = zipEntry;
						num10++;
						continue;
					}
					return;
				}
				throw new ZipException("Wrong Central Directory signature");
			}
			throw new ZipException("Cannot find central directory");
		}
		throw new ZipException("ZipFile stream must be seekable");
	}

	private long method_37(ZipEntry zipEntry_1)
	{
		return method_2(zipEntry_1, (!SkipLocalEntryTestsOnLocate) ? ((Enum14)1) : Enum14.None);
	}

	private Stream method_38(Stream stream_1, ZipEntry zipEntry_1)
	{
		CryptoStream cryptoStream = null;
		if (zipEntry_1.CompressionMethodForHeader == CompressionMethod.const_6)
		{
			if (zipEntry_1.Version < 51)
			{
				throw new ZipException("Decryption method not supported");
			}
			method_0(zipEntry_1.Name);
			if (string_2 == null)
			{
				throw new ZipException("No password available for AES encrypted stream");
			}
			int int32_ = zipEntry_1.AESSaltLen;
			byte[] array = new byte[int32_];
			int num = StreamUtils.ReadRequestedBytes(stream_1, array, 0, int32_);
			if (num != int32_)
			{
				throw new ZipException($"AES Salt expected {int32_} git {num}");
			}
			byte[] array2 = new byte[2];
			StreamUtils.ReadFully(stream_1, array2);
			int blockSize = zipEntry_1.AESKeySize / 8;
			ICSharpCode.SharpZipLib.Encryption.ZipAESTransform zipAESTransform = new ICSharpCode.SharpZipLib.Encryption.ZipAESTransform(string_2, array, blockSize, writeMode: false);
			byte[] pwdVerifier = zipAESTransform.PwdVerifier;
			if (pwdVerifier[0] != array2[0] || pwdVerifier[1] != array2[1])
			{
				throw new ZipException("Invalid password for AES");
			}
			cryptoStream = new ICSharpCode.SharpZipLib.Encryption.ZipAESStream(stream_1, zipAESTransform, CryptoStreamMode.Read);
		}
		else
		{
			if (zipEntry_1.Version >= 50 && zipEntry_1.HasFlag(GeneralBitFlags.StrongEncryption))
			{
				throw new ZipException("Decryption method not supported");
			}
			PkzipClassicManaged pkzipClassicManaged = new PkzipClassicManaged();
			method_0(zipEntry_1.Name);
			if (!method_1())
			{
				throw new ZipException("No password available for encrypted stream");
			}
			cryptoStream = new CryptoStream(stream_1, pkzipClassicManaged.CreateDecryptor(byte_0, null), CryptoStreamMode.Read);
			smethod_2(cryptoStream, zipEntry_1);
		}
		return cryptoStream;
	}

	private Stream method_39(Stream stream_1, ZipEntry zipEntry_1)
	{
		if (zipEntry_1.Version >= 50 && zipEntry_1.HasFlag(GeneralBitFlags.StrongEncryption))
		{
			return null;
		}
		PkzipClassicManaged pkzipClassicManaged = new PkzipClassicManaged();
		method_0(zipEntry_1.Name);
		if (!method_1())
		{
			throw new ZipException("No password available for encrypted stream");
		}
		CryptoStream cryptoStream = new CryptoStream(new Stream0(stream_1), pkzipClassicManaged.CreateEncryptor(byte_0, null), CryptoStreamMode.Write);
		if (zipEntry_1.Crc >= 0L && !zipEntry_1.HasFlag(GeneralBitFlags.Descriptor))
		{
			smethod_3(cryptoStream, zipEntry_1.Crc);
		}
		else
		{
			smethod_3(cryptoStream, zipEntry_1.DosTime << 16);
		}
		return cryptoStream;
	}

	private static void smethod_2(Stream stream_1, ZipEntry zipEntry_1)
	{
		byte[] array = new byte[12];
		StreamUtils.ReadFully(stream_1, array);
		if (array[11] != zipEntry_1.CryptoCheckValue)
		{
			throw new ZipException("Invalid password");
		}
	}

	private static void smethod_3(Stream stream_1, long long_2)
	{
		byte[] array = new byte[12];
		using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
		{
			randomNumberGenerator.GetBytes(array);
		}
		array[11] = (byte)(long_2 >> 24);
		stream_1.Write(array, 0, array.Length);
	}

	static ZipFile()
	{
		Class72.smethod_20();
	}
}
