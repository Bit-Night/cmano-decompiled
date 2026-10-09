using System;
using System.Buffers;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Core;

namespace ICSharpCode.SharpZipLib.Tar;

public class TarInputStream : Stream
{
	public interface IEntryFactory
	{
		TarEntry CreateEntry(string name);

		TarEntry CreateEntryFromFile(string fileName);

		TarEntry CreateEntry(byte[] headerBuffer);
	}

	public class EntryFactoryAdapter : IEntryFactory
	{
		private Encoding encoding_0;

		[Obsolete("No Encoding for Name field is specified, any non-ASCII bytes will be discarded")]
		public EntryFactoryAdapter()
		{
		}

		public EntryFactoryAdapter(Encoding nameEncoding)
		{
			encoding_0 = nameEncoding;
		}

		public TarEntry CreateEntry(string name)
		{
			return TarEntry.CreateTarEntry(name);
		}

		public TarEntry CreateEntryFromFile(string fileName)
		{
			return TarEntry.CreateEntryFromFile(fileName);
		}

		public TarEntry CreateEntry(byte[] headerBuffer)
		{
			return new TarEntry(headerBuffer, encoding_0);
		}

		static EntryFactoryAdapter()
		{
			Class72.smethod_20();
		}
	}

	protected bool bool_0;

	protected long entrySize;

	protected long entryOffset;

	protected IMemoryOwner<byte> readBuffer;

	protected TarBuffer tarBuffer;

	private TarEntry tarEntry_0;

	protected IEntryFactory entryFactory;

	private readonly Stream stream_0;

	private readonly Encoding encoding_0;

	public bool IsStreamOwner
	{
		get
		{
			return tarBuffer.IsStreamOwner;
		}
		set
		{
			tarBuffer.IsStreamOwner = value;
		}
	}

	public override bool CanRead => stream_0.CanRead;

	public override bool CanSeek => false;

	public override bool CanWrite => false;

	public override long Length => stream_0.Length;

	public override long Position
	{
		get
		{
			return stream_0.Position;
		}
		set
		{
			throw new NotSupportedException("TarInputStream Seek not supported");
		}
	}

	public int RecordSize => tarBuffer.RecordSize;

	public long Available => entrySize - entryOffset;

	public bool IsMarkSupported => false;

	[Obsolete("No Encoding for Name field is specified, any non-ASCII bytes will be discarded")]
	public TarInputStream(Stream inputStream)
		: this(inputStream, 20, null)
	{
	}

	public TarInputStream(Stream inputStream, Encoding nameEncoding)
		: this(inputStream, 20, nameEncoding)
	{
	}

	[Obsolete("No Encoding for Name field is specified, any non-ASCII bytes will be discarded")]
	public TarInputStream(Stream inputStream, int blockFactor)
	{
		stream_0 = inputStream;
		tarBuffer = TarBuffer.CreateInputTarBuffer(inputStream, blockFactor);
		encoding_0 = null;
	}

	public TarInputStream(Stream inputStream, int blockFactor, Encoding nameEncoding)
	{
		stream_0 = inputStream;
		tarBuffer = TarBuffer.CreateInputTarBuffer(inputStream, blockFactor);
		encoding_0 = nameEncoding;
	}

	public override void Flush()
	{
		stream_0.Flush();
	}

	public override async Task FlushAsync(CancellationToken cancellationToken)
	{
		await stream_0.FlushAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new NotSupportedException("TarInputStream Seek not supported");
	}

	public override void SetLength(long value)
	{
		throw new NotSupportedException("TarInputStream SetLength not supported");
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		throw new NotSupportedException("TarInputStream Write not supported");
	}

	public override void WriteByte(byte value)
	{
		throw new NotSupportedException("TarInputStream WriteByte not supported");
	}

	public override int ReadByte()
	{
		byte[] array = ArrayPool<byte>.Shared.Rent(1);
		if (Read(array, 0, 1) > 0)
		{
			byte result = array[0];
			ArrayPool<byte>.Shared.Return(array);
			return result;
		}
		return -1;
	}

	public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
	{
		return ipRyVvRtydC(MemoryExtensions.AsMemory(buffer).Slice(offset, count), cancellationToken, bool_1: true).AsTask();
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		if (buffer == null)
		{
			throw new ArgumentNullException("buffer");
		}
		return ipRyVvRtydC(MemoryExtensions.AsMemory(buffer).Slice(offset, count), CancellationToken.None, bool_1: false).GetAwaiter().GetResult();
	}

	private async ValueTask<int> ipRyVvRtydC(Memory<byte> memory_0, CancellationToken cancellationToken_0, bool bool_1)
	{
		int offset = 0;
		int totalRead = 0;
		if (entryOffset < entrySize)
		{
			long numToRead = memory_0.Length;
			if (numToRead + entryOffset > entrySize)
			{
				numToRead = entrySize - entryOffset;
			}
			if (readBuffer != null)
			{
				int num = (int)((numToRead > readBuffer.Memory.Length) ? readBuffer.Memory.Length : numToRead);
				readBuffer.Memory.Slice(0, num).CopyTo(memory_0.Slice(offset, num));
				if (num < readBuffer.Memory.Length)
				{
					int num2 = readBuffer.Memory.Length - num;
					IMemoryOwner<byte> memoryOwner = ExactMemoryPool<byte>.Shared.Rent(num2);
					readBuffer.Memory.Slice(num, num2).CopyTo(memoryOwner.Memory);
					readBuffer.Dispose();
					readBuffer = memoryOwner;
				}
				else
				{
					readBuffer.Dispose();
					readBuffer = null;
				}
				totalRead += num;
				numToRead -= num;
				offset += num;
			}
			int recLen = 512;
			byte[] recBuf = ArrayPool<byte>.Shared.Rent(recLen);
			while (numToRead > 0L)
			{
				await tarBuffer.ReadBlockIntAsync(recBuf, cancellationToken_0, bool_1).ConfigureAwait(continueOnCapturedContext: false);
				int num3 = (int)numToRead;
				Span<byte> span;
				if (recLen > num3)
				{
					span = MemoryExtensions.AsSpan(recBuf);
					span = span.Slice(0, num3);
					span.CopyTo(memory_0.Slice(offset, num3).Span);
					readBuffer?.Dispose();
					readBuffer = ExactMemoryPool<byte>.Shared.Rent(recLen - num3);
					span = MemoryExtensions.AsSpan(recBuf);
					span = span.Slice(num3, recLen - num3);
					span.CopyTo(readBuffer.Memory.Span);
				}
				else
				{
					num3 = recLen;
					span = MemoryExtensions.AsSpan(recBuf);
					span.CopyTo(memory_0.Slice(offset, recLen).Span);
				}
				totalRead += num3;
				numToRead -= num3;
				offset += num3;
			}
			ArrayPool<byte>.Shared.Return(recBuf);
			entryOffset += totalRead;
			return totalRead;
		}
		return 0;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			tarBuffer.Close();
		}
	}

	public void SetEntryFactory(IEntryFactory factory)
	{
		entryFactory = factory;
	}

	[Obsolete("Use RecordSize property instead")]
	public int GetRecordSize()
	{
		return tarBuffer.RecordSize;
	}

	private Task method_0(long long_0, CancellationToken cancellationToken_0)
	{
		return method_1(long_0, cancellationToken_0, bool_1: true).AsTask();
	}

	private void Skip(long skipCount)
	{
		method_1(skipCount, CancellationToken.None, bool_1: false).GetAwaiter().GetResult();
	}

	private async ValueTask method_1(long long_0, CancellationToken cancellationToken_0, bool bool_1)
	{
		int length = 8192;
		using IMemoryOwner<byte> skipBuf = ExactMemoryPool<byte>.Shared.Rent(length);
		long num = long_0;
		while (num > 0L)
		{
			int length2 = (int)((num <= length) ? num : length);
			int num2 = await ipRyVvRtydC(skipBuf.Memory.Slice(0, length2), cancellationToken_0, bool_1).ConfigureAwait(continueOnCapturedContext: false);
			if (num2 != -1)
			{
				num -= num2;
				continue;
			}
			break;
		}
	}

	public void Mark(int markLimit)
	{
	}

	public void Reset()
	{
	}

	public Task<TarEntry> GetNextEntryAsync(CancellationToken ct)
	{
		return method_2(ct, bool_1: true).AsTask();
	}

	public TarEntry GetNextEntry()
	{
		return method_2(CancellationToken.None, bool_1: false).GetAwaiter().GetResult();
	}

	private async ValueTask<TarEntry> method_2(CancellationToken cancellationToken_0, bool bool_1)
	{
		if (bool_0)
		{
			return null;
		}
		if (tarEntry_0 != null)
		{
			await method_4(cancellationToken_0, bool_1).ConfigureAwait(continueOnCapturedContext: false);
		}
		byte[] headerBuf = ArrayPool<byte>.Shared.Rent(512);
		await tarBuffer.ReadBlockIntAsync(headerBuf, cancellationToken_0, bool_1).ConfigureAwait(continueOnCapturedContext: false);
		if (!TarBuffer.IsEndOfArchiveBlock(headerBuf))
		{
			bool_0 = false;
		}
		else
		{
			bool_0 = true;
			await tarBuffer.ReadBlockIntAsync(headerBuf, cancellationToken_0, bool_1).ConfigureAwait(continueOnCapturedContext: false);
		}
		if (bool_0)
		{
			tarEntry_0 = null;
			readBuffer?.Dispose();
		}
		else
		{
			try
			{
				TarHeader tarHeader = new TarHeader();
				tarHeader.ParseBuffer(headerBuf, encoding_0);
				if (!tarHeader.IsChecksumValid)
				{
					throw new TarException("Header checksum is invalid");
				}
				entryOffset = 0L;
				entrySize = tarHeader.Size;
				string longName = null;
				if (tarHeader.TypeFlag == 76)
				{
					using IMemoryOwner<byte> nameBuffer = ExactMemoryPool<byte>.Shared.Rent(512);
					long numToRead = entrySize;
					StringBuilder longNameBuilder = StringBuilderPool.Instance.Rent();
					while (numToRead > 0L)
					{
						int length = (int)((numToRead > 512L) ? 512 : numToRead);
						int num = await ipRyVvRtydC(nameBuffer.Memory.Slice(0, length), cancellationToken_0, bool_1).ConfigureAwait(continueOnCapturedContext: false);
						if (num != -1)
						{
							longNameBuilder.Append(TarHeader.ParseName(nameBuffer.Memory.Slice(0, num).Span, encoding_0));
							numToRead -= num;
							continue;
						}
						throw new InvalidHeaderException("Failed to read long name entry");
					}
					longName = longNameBuilder.ToString();
					StringBuilderPool.Instance.Return(longNameBuilder);
					await method_4(cancellationToken_0, bool_1).ConfigureAwait(continueOnCapturedContext: false);
					await tarBuffer.ReadBlockIntAsync(headerBuf, cancellationToken_0, bool_1).ConfigureAwait(continueOnCapturedContext: false);
				}
				else if (tarHeader.TypeFlag == 103)
				{
					await method_4(cancellationToken_0, bool_1).ConfigureAwait(continueOnCapturedContext: false);
					await tarBuffer.ReadBlockIntAsync(headerBuf, cancellationToken_0, bool_1).ConfigureAwait(continueOnCapturedContext: false);
				}
				else if (tarHeader.TypeFlag == 120)
				{
					byte[] nameBuffer2 = ArrayPool<byte>.Shared.Rent(512);
					long numToRead = entrySize;
					TarExtendedHeaderReader xhr = new TarExtendedHeaderReader();
					while (numToRead > 0L)
					{
						int length2 = (int)((numToRead <= nameBuffer2.Length) ? numToRead : nameBuffer2.Length);
						int num2 = await ipRyVvRtydC(MemoryExtensions.AsMemory(nameBuffer2).Slice(0, length2), cancellationToken_0, bool_1).ConfigureAwait(continueOnCapturedContext: false);
						if (num2 != -1)
						{
							xhr.Read(nameBuffer2, num2);
							numToRead -= num2;
							continue;
						}
						throw new InvalidHeaderException("Failed to read long name entry");
					}
					ArrayPool<byte>.Shared.Return(nameBuffer2);
					if (xhr.Headers.TryGetValue("path", out var value))
					{
						longName = value;
					}
					await method_4(cancellationToken_0, bool_1).ConfigureAwait(continueOnCapturedContext: false);
					await tarBuffer.ReadBlockIntAsync(headerBuf, cancellationToken_0, bool_1).ConfigureAwait(continueOnCapturedContext: false);
				}
				else if (tarHeader.TypeFlag == 86)
				{
					await method_4(cancellationToken_0, bool_1).ConfigureAwait(continueOnCapturedContext: false);
					await tarBuffer.ReadBlockIntAsync(headerBuf, cancellationToken_0, bool_1).ConfigureAwait(continueOnCapturedContext: false);
				}
				else if (tarHeader.TypeFlag != 48 && tarHeader.TypeFlag != 0 && tarHeader.TypeFlag != 49 && tarHeader.TypeFlag != 50 && tarHeader.TypeFlag != 53)
				{
					await method_4(cancellationToken_0, bool_1).ConfigureAwait(continueOnCapturedContext: false);
					await tarBuffer.ReadBlockIntAsync(headerBuf, cancellationToken_0, bool_1).ConfigureAwait(continueOnCapturedContext: false);
				}
				if (entryFactory == null)
				{
					tarEntry_0 = new TarEntry(headerBuf, encoding_0);
					readBuffer?.Dispose();
					if (longName != null)
					{
						tarEntry_0.Name = longName;
					}
				}
				else
				{
					tarEntry_0 = entryFactory.CreateEntry(headerBuf);
					readBuffer?.Dispose();
				}
				entryOffset = 0L;
				entrySize = tarEntry_0.Size;
			}
			catch (InvalidHeaderException ex)
			{
				entrySize = 0L;
				entryOffset = 0L;
				tarEntry_0 = null;
				readBuffer?.Dispose();
				throw new InvalidHeaderException($"Bad header in record {tarBuffer.CurrentRecord} block {tarBuffer.CurrentBlock} {ex.Message}");
			}
		}
		ArrayPool<byte>.Shared.Return(headerBuf);
		return tarEntry_0;
	}

	public Task CopyEntryContentsAsync(Stream outputStream, CancellationToken ct)
	{
		return method_3(outputStream, ct, bool_1: true).AsTask();
	}

	public void CopyEntryContents(Stream outputStream)
	{
		method_3(outputStream, CancellationToken.None, bool_1: false).GetAwaiter().GetResult();
	}

	private async ValueTask method_3(Stream stream_1, CancellationToken cancellationToken_0, bool bool_1)
	{
		byte[] tempBuffer = ArrayPool<byte>.Shared.Rent(32768);
		while (true)
		{
			int num = await ipRyVvRtydC(tempBuffer, cancellationToken_0, bool_1).ConfigureAwait(continueOnCapturedContext: false);
			if (num <= 0)
			{
				break;
			}
			if (!bool_1)
			{
				stream_1.Write(tempBuffer, 0, num);
			}
			else
			{
				await stream_1.WriteAsync(tempBuffer, 0, num, cancellationToken_0).ConfigureAwait(continueOnCapturedContext: false);
			}
		}
		ArrayPool<byte>.Shared.Return(tempBuffer);
	}

	private async ValueTask method_4(CancellationToken cancellationToken_0, bool bool_1)
	{
		long num = entrySize - entryOffset;
		if (num > 0L)
		{
			await method_1(num, cancellationToken_0, bool_1).ConfigureAwait(continueOnCapturedContext: false);
		}
		readBuffer?.Dispose();
		readBuffer = null;
	}

	static TarInputStream()
	{
		Class72.smethod_20();
	}
}
