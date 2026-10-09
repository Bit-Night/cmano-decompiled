using System;
using System.Buffers;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace ICSharpCode.SharpZipLib.Tar;

public class TarBuffer
{
	public const int BlockSize = 512;

	public const int DefaultBlockFactor = 20;

	public const int DefaultRecordSize = 10240;

	[CompilerGenerated]
	private bool bool_0 = true;

	private Stream stream_0;

	private Stream stream_1;

	private byte[] byte_0;

	private int int_0;

	private int int_1;

	private int int_2 = 10240;

	private int int_3 = 20;

	public int RecordSize => int_2;

	public int BlockFactor => int_3;

	public int CurrentBlock => int_0;

	public bool IsStreamOwner
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

	public int CurrentRecord => int_1;

	[Obsolete("Use RecordSize property instead")]
	public int GetRecordSize()
	{
		return int_2;
	}

	[Obsolete("Use BlockFactor property instead")]
	public int GetBlockFactor()
	{
		return int_3;
	}

	protected TarBuffer()
	{
	}

	public static TarBuffer CreateInputTarBuffer(Stream inputStream)
	{
		if (inputStream == null)
		{
			throw new ArgumentNullException("inputStream");
		}
		return CreateInputTarBuffer(inputStream, 20);
	}

	public static TarBuffer CreateInputTarBuffer(Stream inputStream, int blockFactor)
	{
		if (inputStream != null)
		{
			if (blockFactor <= 0)
			{
				throw new ArgumentOutOfRangeException("blockFactor", "Factor cannot be negative");
			}
			TarBuffer tarBuffer = new TarBuffer();
			tarBuffer.stream_0 = inputStream;
			tarBuffer.stream_1 = null;
			tarBuffer.method_0(blockFactor);
			return tarBuffer;
		}
		throw new ArgumentNullException("inputStream");
	}

	public static TarBuffer CreateOutputTarBuffer(Stream outputStream)
	{
		if (outputStream == null)
		{
			throw new ArgumentNullException("outputStream");
		}
		return CreateOutputTarBuffer(outputStream, 20);
	}

	public static TarBuffer CreateOutputTarBuffer(Stream outputStream, int blockFactor)
	{
		if (outputStream != null)
		{
			if (blockFactor <= 0)
			{
				throw new ArgumentOutOfRangeException("blockFactor", "Factor cannot be negative");
			}
			TarBuffer tarBuffer = new TarBuffer();
			tarBuffer.stream_0 = null;
			tarBuffer.stream_1 = outputStream;
			tarBuffer.method_0(blockFactor);
			return tarBuffer;
		}
		throw new ArgumentNullException("outputStream");
	}

	private void method_0(int int_4)
	{
		int_3 = int_4;
		int_2 = int_4 * 512;
		byte_0 = ArrayPool<byte>.Shared.Rent(RecordSize);
		if (stream_0 != null)
		{
			int_1 = -1;
			int_0 = BlockFactor;
		}
		else
		{
			int_1 = 0;
			int_0 = 0;
		}
	}

	[Obsolete("Use IsEndOfArchiveBlock instead")]
	public bool method_1(byte[] block)
	{
		if (block == null)
		{
			throw new ArgumentNullException("block");
		}
		if (block.Length != 512)
		{
			throw new ArgumentException("block length is invalid");
		}
		for (int i = 0; i < 512; i++)
		{
			if (block[i] != 0)
			{
				return false;
			}
		}
		return true;
	}

	public static bool IsEndOfArchiveBlock(byte[] block)
	{
		if (block == null)
		{
			throw new ArgumentNullException("block");
		}
		if (block.Length != 512)
		{
			throw new ArgumentException("block length is invalid");
		}
		for (int i = 0; i < 512; i++)
		{
			if (block[i] != 0)
			{
				return false;
			}
		}
		return true;
	}

	public void SkipBlock()
	{
		method_2(CancellationToken.None, bool_1: false).GetAwaiter().GetResult();
	}

	public Task SkipBlockAsync(CancellationToken ct)
	{
		return method_2(ct, bool_1: true).AsTask();
	}

	private async ValueTask method_2(CancellationToken cancellationToken_0, bool bool_1)
	{
		if (stream_0 == null)
		{
			throw new TarException("no input stream defined");
		}
		if (int_0 >= BlockFactor && !(await method_3(cancellationToken_0, bool_1).ConfigureAwait(continueOnCapturedContext: false)))
		{
			throw new TarException("Failed to read a record");
		}
		int_0++;
	}

	public byte[] ReadBlock()
	{
		if (stream_0 != null)
		{
			int num;
			if (int_0 < BlockFactor)
			{
				num = 512;
			}
			else
			{
				if (!method_3(CancellationToken.None, bool_1: false).GetAwaiter().GetResult())
				{
					throw new TarException("Failed to read a record");
				}
				num = 512;
			}
			byte[] array = new byte[num];
			Array.Copy(byte_0, int_0 * 512, array, 0, 512);
			int_0++;
			return array;
		}
		throw new TarException("TarBuffer.ReadBlock - no input stream defined");
	}

	internal async ValueTask ReadBlockIntAsync(byte[] buffer, CancellationToken ct, bool isAsync)
	{
		if (buffer.Length != 512)
		{
			throw new ArgumentException("BUG: buffer must have length BlockSize");
		}
		if (stream_0 == null)
		{
			throw new TarException("TarBuffer.ReadBlock - no input stream defined");
		}
		if (int_0 >= BlockFactor && !(await method_3(ct, isAsync).ConfigureAwait(continueOnCapturedContext: false)))
		{
			throw new TarException("Failed to read a record");
		}
		Span<byte> span = MemoryExtensions.AsSpan(byte_0);
		span = span.Slice(int_0 * 512, 512);
		span.CopyTo(buffer);
		int_0++;
	}

	private async ValueTask<bool> method_3(CancellationToken cancellationToken_0, bool bool_1)
	{
		if (stream_0 != null)
		{
			int_0 = 0;
			int offset = 0;
			int bytesNeeded = RecordSize;
			while (bytesNeeded > 0)
			{
				int num = ((!bool_1) ? stream_0.Read(byte_0, offset, bytesNeeded) : (await stream_0.ReadAsync(byte_0, offset, bytesNeeded, cancellationToken_0).ConfigureAwait(continueOnCapturedContext: false)));
				long num2 = num;
				if (num2 > 0L)
				{
					offset += (int)num2;
					bytesNeeded -= (int)num2;
					continue;
				}
				for (; offset < RecordSize; offset++)
				{
					byte_0[offset] = 0;
				}
				break;
			}
			int_1++;
			return true;
		}
		throw new TarException("no input stream defined");
	}

	[Obsolete("Use CurrentBlock property instead")]
	public int GetCurrentBlockNum()
	{
		return int_0;
	}

	[Obsolete("Use CurrentRecord property instead")]
	public int GetCurrentRecordNum()
	{
		return int_1;
	}

	public ValueTask WriteBlockAsync(byte[] block, CancellationToken ct)
	{
		return WriteBlockAsync(block, 0, ct);
	}

	public void WriteBlock(byte[] block)
	{
		WriteBlock(block, 0);
	}

	public ValueTask WriteBlockAsync(byte[] buffer, int offset, CancellationToken ct)
	{
		return WriteBlockAsync(buffer, offset, ct, isAsync: true);
	}

	public void WriteBlock(byte[] buffer, int offset)
	{
		WriteBlockAsync(buffer, offset, CancellationToken.None, isAsync: false).GetAwaiter().GetResult();
	}

	internal async ValueTask WriteBlockAsync(byte[] buffer, int offset, CancellationToken ct, bool isAsync)
	{
		if (buffer != null)
		{
			if (stream_1 != null)
			{
				if (offset >= 0 && offset < buffer.Length)
				{
					if (offset + 512 <= buffer.Length)
					{
						if (int_0 >= BlockFactor)
						{
							await method_4(CancellationToken.None, isAsync).ConfigureAwait(continueOnCapturedContext: false);
						}
						Array.Copy(buffer, offset, byte_0, int_0 * 512, 512);
						int_0++;
						return;
					}
					throw new TarException($"TarBuffer.WriteBlock - record has length '{buffer.Length}' with offset '{offset}' which is less than the record size of '{int_2}'");
				}
				throw new ArgumentOutOfRangeException("offset");
			}
			throw new TarException("TarBuffer.WriteBlock - no output stream defined");
		}
		throw new ArgumentNullException("buffer");
	}

	private async ValueTask method_4(CancellationToken cancellationToken_0, bool bool_1)
	{
		if (stream_1 == null)
		{
			throw new TarException("TarBuffer.WriteRecord no output stream defined");
		}
		if (bool_1)
		{
			await stream_1.WriteAsync(byte_0, 0, RecordSize, cancellationToken_0).ConfigureAwait(continueOnCapturedContext: false);
			await stream_1.FlushAsync(cancellationToken_0).ConfigureAwait(continueOnCapturedContext: false);
		}
		else
		{
			stream_1.Write(byte_0, 0, RecordSize);
			stream_1.Flush();
		}
		int_0 = 0;
		int_1++;
	}

	private async ValueTask method_5(CancellationToken cancellationToken_0, bool bool_1)
	{
		if (stream_1 == null)
		{
			throw new TarException("TarBuffer.WriteFinalRecord no output stream defined");
		}
		if (int_0 > 0)
		{
			int num = int_0 * 512;
			Array.Clear(byte_0, num, RecordSize - num);
			await method_4(cancellationToken_0, bool_1).ConfigureAwait(continueOnCapturedContext: false);
		}
		if (!bool_1)
		{
			stream_1.Flush();
		}
		else
		{
			await stream_1.FlushAsync(cancellationToken_0).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public void Close()
	{
		method_6(CancellationToken.None, bool_1: false).GetAwaiter().GetResult();
	}

	public Task CloseAsync(CancellationToken ct)
	{
		return method_6(ct, bool_1: true).AsTask();
	}

	private async ValueTask method_6(CancellationToken cancellationToken_0, bool bool_1)
	{
		if (stream_1 == null)
		{
			if (stream_0 != null)
			{
				if (IsStreamOwner)
				{
					if (bool_1)
					{
						stream_0.Dispose();
					}
					else
					{
						stream_0.Dispose();
					}
				}
				stream_0 = null;
			}
		}
		else
		{
			await method_5(cancellationToken_0, bool_1).ConfigureAwait(continueOnCapturedContext: false);
			if (IsStreamOwner)
			{
				if (!bool_1)
				{
					stream_1.Dispose();
				}
				else
				{
					stream_1.Dispose();
				}
			}
			stream_1 = null;
		}
		ArrayPool<byte>.Shared.Return(byte_0);
	}

	static TarBuffer()
	{
		Class72.smethod_20();
	}
}
