using System;
using System.IO;
using System.Text;

namespace MapReduce.NET.Collections.System.IO;

[Serializable]
public class StreamReaderAdvanced : TextReader
{
	private class Stream2 : StreamReaderAdvanced
	{
		public override Stream BaseStream => Stream.Null;

		public override Encoding CurrentEncoding => Encoding.Unicode;

		public override int Peek()
		{
			return -1;
		}

		public override int Read()
		{
			return -1;
		}

		public override int Read(char[] buffer, int index, int count)
		{
			return 0;
		}

		public override string ReadLine()
		{
			return null;
		}

		public override string ReadToEnd()
		{
			return string.Empty;
		}

		static Stream2()
		{
			Class72.smethod_20();
		}
	}

	private byte[] YtxeQgqHpaQ;

	private static byte[] byte_0;

	private static object object_0;

	private char[] char_0;

	private static char[] char_1;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private Encoding encoding_0;

	private Decoder decoder_0;

	private Stream stream_0;

	private bool bool_0;

	private StringBuilder stringBuilder_0;

	public new static readonly StreamReaderAdvanced Null;

	private bool bool_1;

	public virtual long Position => int_2 + int_1;

	public virtual Stream BaseStream => stream_0;

	public virtual Encoding CurrentEncoding
	{
		get
		{
			if (encoding_0 == null)
			{
				throw new Exception();
			}
			return encoding_0;
		}
	}

	public bool EndOfStream => Peek() < 0;

	internal StreamReaderAdvanced()
	{
	}

	public StreamReaderAdvanced(Stream stream)
		: this(stream, Encoding.UTF8, detectEncodingFromByteOrderMarks: true, 1024)
	{
	}

	public StreamReaderAdvanced(Stream stream, bool detectEncodingFromByteOrderMarks)
		: this(stream, Encoding.UTF8, detectEncodingFromByteOrderMarks, 1024)
	{
	}

	public StreamReaderAdvanced(Stream stream, Encoding encoding)
		: this(stream, encoding, detectEncodingFromByteOrderMarks: true, 1024)
	{
	}

	public StreamReaderAdvanced(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks)
		: this(stream, encoding, detectEncodingFromByteOrderMarks, 1024)
	{
	}

	public StreamReaderAdvanced(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize)
	{
		Initialize(stream, encoding, detectEncodingFromByteOrderMarks, bufferSize);
	}

	public StreamReaderAdvanced(string path)
		: this(path, Encoding.UTF8, detectEncodingFromByteOrderMarks: true, 4096)
	{
	}

	public StreamReaderAdvanced(string path, bool detectEncodingFromByteOrderMarks)
		: this(path, Encoding.UTF8, detectEncodingFromByteOrderMarks, 4096)
	{
	}

	public StreamReaderAdvanced(string path, Encoding encoding)
		: this(path, encoding, detectEncodingFromByteOrderMarks: true, 4096)
	{
	}

	public StreamReaderAdvanced(string path, Encoding encoding, bool detectEncodingFromByteOrderMarks)
		: this(path, encoding, detectEncodingFromByteOrderMarks, 4096)
	{
	}

	public StreamReaderAdvanced(string path, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize)
	{
		if (path != null)
		{
			if (string.Empty == path)
			{
				throw new ArgumentException("Empty path not allowed");
			}
			if (path.IndexOfAny(Path.GetInvalidPathChars()) != -1)
			{
				throw new ArgumentException("path contains invalid characters");
			}
			if (encoding == null)
			{
				throw new ArgumentNullException("encoding");
			}
			if (bufferSize <= 0)
			{
				throw new ArgumentOutOfRangeException("bufferSize", "The minimum size of the buffer must be positive");
			}
			Stream stream = File.OpenRead(path);
			Initialize(stream, encoding, detectEncodingFromByteOrderMarks, bufferSize);
			return;
		}
		throw new ArgumentNullException("path");
	}

	internal void Initialize(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize)
	{
		if (stream != null)
		{
			if (encoding == null)
			{
				throw new ArgumentNullException("encoding");
			}
			if (!stream.CanRead)
			{
				throw new ArgumentException("Cannot read stream");
			}
			if (bufferSize > 0)
			{
				if (bufferSize < 128)
				{
					bufferSize = 128;
				}
				int num = encoding.GetMaxCharCount(bufferSize) + 1;
				if (bufferSize <= 1024 && byte_0 != null)
				{
					lock (object_0)
					{
						if (byte_0 != null)
						{
							YtxeQgqHpaQ = byte_0;
							byte_0 = null;
						}
						if (char_1 != null && num <= char_1.Length)
						{
							char_0 = char_1;
							char_1 = null;
						}
					}
				}
				if (YtxeQgqHpaQ == null)
				{
					YtxeQgqHpaQ = new byte[bufferSize];
				}
				else
				{
					Array.Clear(YtxeQgqHpaQ, 0, bufferSize);
				}
				if (char_0 == null)
				{
					char_0 = new char[num];
				}
				else
				{
					Array.Clear(char_0, 0, num);
				}
				stream_0 = stream;
				int_3 = bufferSize;
				encoding_0 = encoding;
				decoder_0 = encoding.GetDecoder();
				byte[] preamble = encoding.GetPreamble();
				int_4 = (detectEncodingFromByteOrderMarks ? 1 : 0);
				int_4 += ((preamble.Length != 0) ? 2 : 0);
				int_0 = 0;
				int_1 = 0;
				return;
			}
			throw new ArgumentOutOfRangeException("bufferSize", "The minimum size of the buffer must be positive");
		}
		throw new ArgumentNullException("stream");
	}

	public override void Close()
	{
		Dispose(disposing: true);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && stream_0 != null)
		{
			stream_0.Close();
		}
		if (YtxeQgqHpaQ != null && YtxeQgqHpaQ.Length == 1024 && byte_0 == null)
		{
			lock (object_0)
			{
				if (byte_0 == null)
				{
					byte_0 = YtxeQgqHpaQ;
				}
				if (char_1 == null)
				{
					char_1 = char_0;
				}
			}
		}
		YtxeQgqHpaQ = null;
		char_0 = null;
		encoding_0 = null;
		decoder_0 = null;
		stream_0 = null;
		base.Dispose(disposing);
	}

	private int SyreQpvmQoX(int int_5)
	{
		if ((int_4 & 2) == 2)
		{
			byte[] preamble = encoding_0.GetPreamble();
			int num = preamble.Length;
			if (int_5 >= num)
			{
				int i;
				for (i = 0; i < num && YtxeQgqHpaQ[i] == preamble[i]; i++)
				{
				}
				if (i == num)
				{
					return i;
				}
			}
		}
		if ((int_4 & 1) == 1)
		{
			if (int_5 < 2)
			{
				return 0;
			}
			if (YtxeQgqHpaQ[0] == 254 && YtxeQgqHpaQ[1] == byte.MaxValue)
			{
				encoding_0 = Encoding.BigEndianUnicode;
				return 2;
			}
			if (YtxeQgqHpaQ[0] == byte.MaxValue && YtxeQgqHpaQ[1] == 254 && int_5 < 4)
			{
				encoding_0 = Encoding.Unicode;
				return 2;
			}
			if (int_5 < 3)
			{
				return 0;
			}
			if (YtxeQgqHpaQ[0] == 239 && YtxeQgqHpaQ[1] == 187 && YtxeQgqHpaQ[2] == 191)
			{
				encoding_0 = Encoding.UTF8;
				return 3;
			}
			if (int_5 < 4)
			{
				int result;
				if (YtxeQgqHpaQ[0] == byte.MaxValue && YtxeQgqHpaQ[1] == 254)
				{
					if (YtxeQgqHpaQ[2] != 0)
					{
						encoding_0 = Encoding.Unicode;
						return 2;
					}
					result = 0;
				}
				else
				{
					result = 0;
				}
				return result;
			}
			if (YtxeQgqHpaQ[0] == 0 && YtxeQgqHpaQ[1] == 0 && YtxeQgqHpaQ[2] == 254 && YtxeQgqHpaQ[3] == byte.MaxValue)
			{
				encoding_0 = Encoding.BigEndianUnicode;
				return 4;
			}
			if (YtxeQgqHpaQ[0] == byte.MaxValue && YtxeQgqHpaQ[1] == 254)
			{
				if (YtxeQgqHpaQ[2] == 0 && YtxeQgqHpaQ[3] == 0)
				{
					encoding_0 = Encoding.UTF32;
					return 4;
				}
				encoding_0 = Encoding.Unicode;
				return 2;
			}
		}
		return 0;
	}

	public void DiscardBufferedData()
	{
		int_0 = 0;
		int_1 = 0;
		bool_0 = false;
		decoder_0 = encoding_0.GetDecoder();
	}

	private int method_0()
	{
		int_2 += int_1;
		int_1 = 0;
		int num = 0;
		int_0 = 0;
		int num2 = 0;
		do
		{
			num = stream_0.Read(YtxeQgqHpaQ, 0, int_3);
			if (num > 0)
			{
				bool_0 = num < int_3;
				if (int_4 > 0)
				{
					Encoding encoding = encoding_0;
					num2 = SyreQpvmQoX(num);
					if (encoding != encoding_0)
					{
						int num3 = encoding.GetMaxCharCount(int_3) + 1;
						int num4 = encoding_0.GetMaxCharCount(int_3) + 1;
						if (num3 != num4)
						{
							char_0 = new char[num4];
						}
						decoder_0 = encoding_0.GetDecoder();
					}
					int_4 = 0;
					num -= num2;
				}
				int_0 += decoder_0.GetChars(YtxeQgqHpaQ, num2, num, char_0, 0);
				num2 = 0;
				continue;
			}
			return 0;
		}
		while (int_0 == 0);
		return int_0;
	}

	public override int Peek()
	{
		if (stream_0 != null)
		{
			if (int_1 >= int_0 && method_0() == 0)
			{
				return -1;
			}
			return char_0[int_1];
		}
		throw new ObjectDisposedException("StreamReader", "Cannot read from a closed StreamReader");
	}

	internal bool DataAvailable()
	{
		return int_1 < int_0;
	}

	public override int Read()
	{
		if (stream_0 != null)
		{
			if (int_1 >= int_0 && method_0() == 0)
			{
				return -1;
			}
			return char_0[int_1++];
		}
		throw new ObjectDisposedException("StreamReader", "Cannot read from a closed StreamReader");
	}

	public override int Read(char[] buffer, int index, int count)
	{
		if (stream_0 != null)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (index >= 0)
			{
				if (count < 0)
				{
					throw new ArgumentOutOfRangeException("count", "< 0");
				}
				if (index <= buffer.Length - count)
				{
					int num = 0;
					while (count > 0)
					{
						if (int_1 < int_0 || method_0() != 0)
						{
							int num2 = Math.Min(int_0 - int_1, count);
							Array.Copy(char_0, int_1, buffer, index, num2);
							int_1 += num2;
							index += num2;
							count -= num2;
							num += num2;
							if (bool_0)
							{
								break;
							}
							continue;
						}
						if (num <= 0)
						{
							return 0;
						}
						return num;
					}
					return num;
				}
				throw new ArgumentException("index + count > buffer.Length");
			}
			throw new ArgumentOutOfRangeException("index", "< 0");
		}
		throw new ObjectDisposedException("StreamReader", "Cannot read from a closed StreamReader");
	}

	private int method_1()
	{
		char c = '\0';
		while (true)
		{
			if (int_1 < int_0)
			{
				c = char_0[int_1];
				if (c != '\n')
				{
					if (bool_1)
					{
						break;
					}
					bool_1 = c == '\r';
					int_1++;
					continue;
				}
				int_1++;
				int num = (bool_1 ? (int_1 - 2) : (int_1 - 1));
				if (num < 0)
				{
					num = 0;
				}
				bool_1 = false;
				return num;
			}
			return -1;
		}
		bool_1 = false;
		if (int_1 != 0)
		{
			return int_1 - 1;
		}
		return -2;
	}

	public override string ReadLine()
	{
		if (stream_0 == null)
		{
			throw new ObjectDisposedException("StreamReader", "Cannot read from a closed StreamReader");
		}
		if (int_1 >= int_0 && method_0() == 0)
		{
			return null;
		}
		int num = int_1;
		int num2 = method_1();
		if (num2 < int_0 && num2 >= num)
		{
			return new string(char_0, num, num2 - num);
		}
		if (num2 == -2)
		{
			return stringBuilder_0.ToString(0, stringBuilder_0.Length);
		}
		if (stringBuilder_0 != null)
		{
			stringBuilder_0.Length = 0;
		}
		else
		{
			stringBuilder_0 = new StringBuilder();
		}
		while (true)
		{
			if (bool_1)
			{
				int_0--;
			}
			stringBuilder_0.Append(char_0, num, int_0 - num);
			if (method_0() == 0)
			{
				break;
			}
			num = int_1;
			num2 = method_1();
			if (num2 >= int_0 || num2 < num)
			{
				if (num2 == -2)
				{
					return stringBuilder_0.ToString(0, stringBuilder_0.Length);
				}
				continue;
			}
			stringBuilder_0.Append(char_0, num, num2 - num);
			if (stringBuilder_0.Capacity > 32768)
			{
				StringBuilder stringBuilder = stringBuilder_0;
				stringBuilder_0 = null;
				return stringBuilder.ToString(0, stringBuilder.Length);
			}
			return stringBuilder_0.ToString(0, stringBuilder_0.Length);
		}
		if (stringBuilder_0.Capacity > 32768)
		{
			StringBuilder stringBuilder2 = stringBuilder_0;
			stringBuilder_0 = null;
			return stringBuilder2.ToString(0, stringBuilder2.Length);
		}
		return stringBuilder_0.ToString(0, stringBuilder_0.Length);
	}

	public override string ReadToEnd()
	{
		if (stream_0 == null)
		{
			throw new ObjectDisposedException("StreamReader", "Cannot read from a closed StreamReader");
		}
		StringBuilder stringBuilder = new StringBuilder();
		int num = char_0.Length;
		char[] array = new char[num];
		int charCount;
		while ((charCount = Read(array, 0, num)) > 0)
		{
			stringBuilder.Append(array, 0, charCount);
		}
		return stringBuilder.ToString();
	}

	static StreamReaderAdvanced()
	{
		Class72.smethod_20();
		object_0 = new object();
		Null = new Stream2();
	}
}
