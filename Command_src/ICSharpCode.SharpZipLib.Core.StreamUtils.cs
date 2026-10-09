using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ICSharpCode.SharpZipLib.Core;

public static class StreamUtils
{
	public static void ReadFully(Stream stream, byte[] buffer)
	{
		ReadFully(stream, buffer, 0, buffer.Length);
	}

	public static void ReadFully(Stream stream, byte[] buffer, int offset, int count)
	{
		if (stream != null)
		{
			if (buffer != null)
			{
				if (offset >= 0 && offset <= buffer.Length)
				{
					if (count >= 0 && offset + count <= buffer.Length)
					{
						while (count > 0)
						{
							int num = stream.Read(buffer, offset, count);
							if (num > 0)
							{
								offset += num;
								count -= num;
								continue;
							}
							throw new EndOfStreamException();
						}
						return;
					}
					throw new ArgumentOutOfRangeException("count");
				}
				throw new ArgumentOutOfRangeException("offset");
			}
			throw new ArgumentNullException("buffer");
		}
		throw new ArgumentNullException("stream");
	}

	public static int ReadRequestedBytes(Stream stream, byte[] buffer, int offset, int count)
	{
		if (stream != null)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (offset >= 0 && offset <= buffer.Length)
			{
				if (count >= 0 && offset + count <= buffer.Length)
				{
					int num = 0;
					while (count > 0)
					{
						int num2 = stream.Read(buffer, offset, count);
						if (num2 <= 0)
						{
							break;
						}
						offset += num2;
						count -= num2;
						num += num2;
					}
					return num;
				}
				throw new ArgumentOutOfRangeException("count");
			}
			throw new ArgumentOutOfRangeException("offset");
		}
		throw new ArgumentNullException("stream");
	}

	public static void Copy(Stream source, Stream destination, byte[] buffer)
	{
		if (source != null)
		{
			if (destination != null)
			{
				if (buffer != null)
				{
					if (buffer.Length >= 128)
					{
						bool flag = true;
						while (flag)
						{
							int num = source.Read(buffer, 0, buffer.Length);
							if (num <= 0)
							{
								destination.Flush();
								flag = false;
							}
							else
							{
								destination.Write(buffer, 0, num);
							}
						}
						return;
					}
					throw new ArgumentException("Buffer is too small", "buffer");
				}
				throw new ArgumentNullException("buffer");
			}
			throw new ArgumentNullException("destination");
		}
		throw new ArgumentNullException("source");
	}

	public static void Copy(Stream source, Stream destination, byte[] buffer, ProgressHandler progressHandler, TimeSpan updateInterval, object sender, string name)
	{
		Copy(source, destination, buffer, progressHandler, updateInterval, sender, name, -1L);
	}

	public static void Copy(Stream source, Stream destination, byte[] buffer, ProgressHandler progressHandler, TimeSpan updateInterval, object sender, string name, long fixedTarget)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (destination != null)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (buffer.Length >= 128)
			{
				if (progressHandler == null)
				{
					throw new ArgumentNullException("progressHandler");
				}
				bool flag = true;
				DateTime now = DateTime.Now;
				long num = 0L;
				long target = 0L;
				if (fixedTarget >= 0L)
				{
					target = fixedTarget;
				}
				else if (source.CanSeek)
				{
					target = source.Length - source.Position;
				}
				ProgressEventArgs e = new ProgressEventArgs(name, num, target);
				progressHandler(sender, e);
				bool flag2 = true;
				while (flag)
				{
					int num2 = source.Read(buffer, 0, buffer.Length);
					if (num2 > 0)
					{
						num += num2;
						flag2 = false;
						destination.Write(buffer, 0, num2);
					}
					else
					{
						destination.Flush();
						flag = false;
					}
					if (DateTime.Now - now > updateInterval)
					{
						flag2 = true;
						now = DateTime.Now;
						e = new ProgressEventArgs(name, num, target);
						progressHandler(sender, e);
						flag = e.ContinueRunning;
					}
				}
				if (!flag2)
				{
					e = new ProgressEventArgs(name, num, target);
					progressHandler(sender, e);
				}
				return;
			}
			throw new ArgumentException("Buffer is too small", "buffer");
		}
		throw new ArgumentNullException("destination");
	}

	internal static async Task WriteProcToStreamAsync(this Stream targetStream, MemoryStream bufferStream, Action<Stream> writeProc, CancellationToken ct)
	{
		bufferStream.SetLength(0L);
		writeProc(bufferStream);
		bufferStream.Position = 0L;
		await bufferStream.CopyToAsync(targetStream, 81920, ct).ConfigureAwait(continueOnCapturedContext: false);
		bufferStream.SetLength(0L);
	}

	internal static async Task WriteProcToStreamAsync(this Stream targetStream, Action<Stream> writeProc, CancellationToken ct)
	{
		using MemoryStream ms = new MemoryStream();
		await WriteProcToStreamAsync(targetStream, ms, writeProc, ct).ConfigureAwait(continueOnCapturedContext: false);
	}

	static StreamUtils()
	{
		Class72.smethod_20();
	}
}
