using System;
using System.Buffers;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ICSharpCode.SharpZipLib.Tar;

public class TarOutputStream : Stream
{
	private long long_0;

	private int int_0;

	private bool abAyryhkeSg;

	protected long currSize;

	protected byte[] blockBuffer;

	protected byte[] assemblyBuffer;

	protected TarBuffer buffer;

	protected Stream outputStream;

	protected Encoding nameEncoding;

	public bool IsStreamOwner
	{
		get
		{
			return buffer.IsStreamOwner;
		}
		set
		{
			buffer.IsStreamOwner = value;
		}
	}

	public override bool CanRead => outputStream.CanRead;

	public override bool CanSeek => outputStream.CanSeek;

	public override bool CanWrite => outputStream.CanWrite;

	public override long Length => outputStream.Length;

	public override long Position
	{
		get
		{
			return outputStream.Position;
		}
		set
		{
			outputStream.Position = value;
		}
	}

	public int RecordSize => buffer.RecordSize;

	[Obsolete("No Encoding for Name field is specified, any non-ASCII bytes will be discarded")]
	public TarOutputStream(Stream outputStream)
		: this(outputStream, 20)
	{
	}

	public TarOutputStream(Stream outputStream, Encoding nameEncoding)
		: this(outputStream, 20, nameEncoding)
	{
	}

	[Obsolete("No Encoding for Name field is specified, any non-ASCII bytes will be discarded")]
	public TarOutputStream(Stream outputStream, int blockFactor)
	{
		if (outputStream == null)
		{
			throw new ArgumentNullException("outputStream");
		}
		this.outputStream = outputStream;
		buffer = TarBuffer.CreateOutputTarBuffer(outputStream, blockFactor);
		assemblyBuffer = ArrayPool<byte>.Shared.Rent(512);
		blockBuffer = ArrayPool<byte>.Shared.Rent(512);
	}

	public TarOutputStream(Stream outputStream, int blockFactor, Encoding nameEncoding)
	{
		if (outputStream == null)
		{
			throw new ArgumentNullException("outputStream");
		}
		this.outputStream = outputStream;
		buffer = TarBuffer.CreateOutputTarBuffer(outputStream, blockFactor);
		assemblyBuffer = ArrayPool<byte>.Shared.Rent(512);
		blockBuffer = ArrayPool<byte>.Shared.Rent(512);
		this.nameEncoding = nameEncoding;
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		return outputStream.Seek(offset, origin);
	}

	public override void SetLength(long value)
	{
		outputStream.SetLength(value);
	}

	public override int ReadByte()
	{
		return outputStream.ReadByte();
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		return outputStream.Read(buffer, offset, count);
	}

	public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
	{
		return await outputStream.ReadAsync(buffer, offset, count, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
	}

	public override void Flush()
	{
		outputStream.Flush();
	}

	public override async Task FlushAsync(CancellationToken cancellationToken)
	{
		await outputStream.FlushAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
	}

	public void Finish()
	{
		method_0(CancellationToken.None, bool_0: false).GetAwaiter().GetResult();
	}

	public Task FinishAsync(CancellationToken cancellationToken)
	{
		return method_0(cancellationToken, bool_0: true);
	}

	private async Task method_0(CancellationToken cancellationToken_0, bool bool_0)
	{
		if (method_1())
		{
			await method_3(cancellationToken_0, bool_0).ConfigureAwait(continueOnCapturedContext: false);
		}
		await method_5(cancellationToken_0, bool_0).ConfigureAwait(continueOnCapturedContext: false);
	}

	protected override void Dispose(bool disposing)
	{
		if (!abAyryhkeSg)
		{
			abAyryhkeSg = true;
			Finish();
			buffer.Close();
			ArrayPool<byte>.Shared.Return(assemblyBuffer);
			ArrayPool<byte>.Shared.Return(blockBuffer);
		}
	}

	[Obsolete("Use RecordSize property instead")]
	public int GetRecordSize()
	{
		return buffer.RecordSize;
	}

	[SpecialName]
	private bool method_1()
	{
		return long_0 < currSize;
	}

	public Task PutNextEntryAsync(TarEntry entry, CancellationToken cancellationToken)
	{
		return method_2(entry, cancellationToken, bool_0: true);
	}

	public void PutNextEntry(TarEntry entry)
	{
		method_2(entry, CancellationToken.None, bool_0: false).GetAwaiter().GetResult();
	}

	private async Task method_2(TarEntry tarEntry_0, CancellationToken cancellationToken_0, bool bool_0)
	{
		if (tarEntry_0 == null)
		{
			throw new ArgumentNullException("entry");
		}
		int namelen = ((nameEncoding == null) ? tarEntry_0.TarHeader.Name.Length : nameEncoding.GetByteCount(tarEntry_0.TarHeader.Name));
		if (namelen > 100)
		{
			TarHeader obj = new TarHeader
			{
				TypeFlag = 76
			};
			obj.Name += "././@LongLink";
			obj.Mode = 420;
			obj.UserId = tarEntry_0.UserId;
			obj.GroupId = tarEntry_0.GroupId;
			obj.GroupName = tarEntry_0.GroupName;
			obj.UserName = tarEntry_0.UserName;
			obj.LinkName = "";
			obj.Size = namelen + 1;
			obj.WriteHeader(blockBuffer, nameEncoding);
			await buffer.WriteBlockAsync(blockBuffer, 0, cancellationToken_0, bool_0).ConfigureAwait(continueOnCapturedContext: false);
			int nameCharIndex = 0;
			while (nameCharIndex < namelen + 1)
			{
				Array.Clear(blockBuffer, 0, blockBuffer.Length);
				TarHeader.GetAsciiBytes(tarEntry_0.TarHeader.Name, nameCharIndex, blockBuffer, 0, 512, nameEncoding);
				nameCharIndex += 512;
				await buffer.WriteBlockAsync(blockBuffer, 0, cancellationToken_0, bool_0).ConfigureAwait(continueOnCapturedContext: false);
			}
		}
		tarEntry_0.WriteEntryHeader(blockBuffer, nameEncoding);
		await buffer.WriteBlockAsync(blockBuffer, 0, cancellationToken_0, bool_0).ConfigureAwait(continueOnCapturedContext: false);
		long_0 = 0L;
		currSize = (tarEntry_0.IsDirectory ? 0L : tarEntry_0.Size);
	}

	public Task CloseEntryAsync(CancellationToken cancellationToken)
	{
		return method_3(cancellationToken, bool_0: true);
	}

	public void CloseEntry()
	{
		method_3(CancellationToken.None, bool_0: false).GetAwaiter().GetResult();
	}

	private async Task method_3(CancellationToken cancellationToken_0, bool bool_0)
	{
		if (int_0 > 0)
		{
			Array.Clear(assemblyBuffer, int_0, assemblyBuffer.Length - int_0);
			await buffer.WriteBlockAsync(assemblyBuffer, 0, cancellationToken_0, bool_0).ConfigureAwait(continueOnCapturedContext: false);
			long_0 += int_0;
			int_0 = 0;
		}
		if (long_0 < currSize)
		{
			throw new TarException($"Entry closed at '{long_0}' before the '{currSize}' bytes specified in the header were written");
		}
	}

	public override void WriteByte(byte value)
	{
		byte[] array = ArrayPool<byte>.Shared.Rent(1);
		array[0] = value;
		Write(array, 0, 1);
		ArrayPool<byte>.Shared.Return(array);
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		method_4(buffer, offset, count, CancellationToken.None, bool_0: false).GetAwaiter().GetResult();
	}

	public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
	{
		return method_4(buffer, offset, count, cancellationToken, bool_0: true);
	}

	private async Task method_4(byte[] byte_0, int int_1, int int_2, CancellationToken cancellationToken_0, bool bool_0)
	{
		if (byte_0 == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (int_1 >= 0)
		{
			if (byte_0.Length - int_1 >= int_2)
			{
				if (int_2 < 0)
				{
					throw new ArgumentOutOfRangeException("count", "Cannot be negative");
				}
				if (long_0 + int_2 > currSize)
				{
					string message = $"request to write '{int_2}' bytes exceeds size in header of '{currSize}' bytes";
					throw new ArgumentOutOfRangeException("count", message);
				}
				if (int_0 > 0)
				{
					if (int_0 + int_2 >= blockBuffer.Length)
					{
						int aLen = blockBuffer.Length - int_0;
						Array.Copy(assemblyBuffer, 0, blockBuffer, 0, int_0);
						Array.Copy(byte_0, int_1, blockBuffer, int_0, aLen);
						await buffer.WriteBlockAsync(blockBuffer, 0, cancellationToken_0, bool_0).ConfigureAwait(continueOnCapturedContext: false);
						long_0 += blockBuffer.Length;
						int_1 += aLen;
						int_2 -= aLen;
						int_0 = 0;
					}
					else
					{
						Array.Copy(byte_0, int_1, assemblyBuffer, int_0, int_2);
						int_1 += int_2;
						int_0 += int_2;
						int_2 -= int_2;
					}
				}
				while (true)
				{
					if (int_2 > 0)
					{
						if (int_2 < blockBuffer.Length)
						{
							break;
						}
						await buffer.WriteBlockAsync(byte_0, int_1, cancellationToken_0, bool_0).ConfigureAwait(continueOnCapturedContext: false);
						int num = blockBuffer.Length;
						long_0 += num;
						int_2 -= num;
						int_1 += num;
						continue;
					}
					return;
				}
				Array.Copy(byte_0, int_1, assemblyBuffer, int_0, int_2);
				int_0 += int_2;
				return;
			}
			throw new ArgumentException("offset and count combination is invalid");
		}
		throw new ArgumentOutOfRangeException("offset", "Cannot be negative");
	}

	private async Task method_5(CancellationToken cancellationToken_0, bool bool_0)
	{
		Array.Clear(blockBuffer, 0, blockBuffer.Length);
		await buffer.WriteBlockAsync(blockBuffer, 0, cancellationToken_0, bool_0).ConfigureAwait(continueOnCapturedContext: false);
		await buffer.WriteBlockAsync(blockBuffer, 0, cancellationToken_0, bool_0).ConfigureAwait(continueOnCapturedContext: false);
	}

	static TarOutputStream()
	{
		Class72.smethod_20();
	}
}
