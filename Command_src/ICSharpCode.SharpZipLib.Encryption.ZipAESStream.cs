using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;

namespace ICSharpCode.SharpZipLib.Encryption;

internal class ZipAESStream : CryptoStream
{
	public const int AUTH_CODE_LENGTH = 10;

	private Stream stream_0;

	private ICSharpCode.SharpZipLib.Encryption.ZipAESTransform zipAESTransform_0;

	private byte[] byte_0;

	private int int_0;

	private int int_1;

	private byte[] byte_1;

	private int int_2;

	private int int_3;

	public ZipAESStream(Stream stream, ICSharpCode.SharpZipLib.Encryption.ZipAESTransform transform, CryptoStreamMode mode)
		: base(stream, transform, mode)
	{
		stream_0 = stream;
		zipAESTransform_0 = transform;
		byte_0 = new byte[1024];
		if (mode != CryptoStreamMode.Read)
		{
			throw new Exception("ZipAESStream only for read");
		}
	}

	[SpecialName]
	private bool method_0()
	{
		if (byte_1 == null)
		{
			return false;
		}
		return int_3 < int_2;
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		if (count == 0)
		{
			return 0;
		}
		int num = 0;
		if (method_0())
		{
			num = method_2(buffer, offset, count);
			if (num == count)
			{
				return num;
			}
			offset += num;
			count -= num;
		}
		if (byte_0 != null)
		{
			num += method_1(buffer, offset, count);
		}
		return num;
	}

	public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
	{
		return Task.FromResult(Read(buffer, offset, count));
	}

	private int method_1(byte[] byte_2, int int_4, int int_5)
	{
		int num = 0;
		while (num < int_5)
		{
			int int_6 = int_5 - num;
			int num2 = int_1 - int_0;
			int num3 = 26 - num2;
			if (byte_0.Length - int_1 < num3)
			{
				int num4 = 0;
				int num5 = int_0;
				while (num5 < int_1)
				{
					byte_0[num4] = byte_0[num5];
					num5++;
					num4++;
				}
				int_1 -= int_0;
				int_0 = 0;
			}
			int num6 = StreamUtils.ReadRequestedBytes(stream_0, byte_0, int_1, num3);
			int_1 += num6;
			num2 = int_1 - int_0;
			if (num2 >= 26)
			{
				int num7 = method_3(byte_2, int_4, int_6, 16);
				num += num7;
				int_4 += num7;
				continue;
			}
			if (num2 <= 10)
			{
				if (num2 < 10)
				{
					throw new ZipException("Internal error missed auth code");
				}
			}
			else
			{
				int int_7 = num2 - 10;
				num += method_3(byte_2, int_4, int_6, int_7);
			}
			byte[] authCode = zipAESTransform_0.GetAuthCode();
			for (int i = 0; i < 10; i++)
			{
				if (authCode[i] != byte_0[int_0 + i])
				{
					throw new ZipException("AES Authentication Code does not match. This is a super-CRC check on the data in the file after compression and encryption. \r\nThe file may be damaged.");
				}
			}
			byte_0 = null;
			break;
		}
		return num;
	}

	private int method_2(byte[] byte_2, int int_4, int int_5)
	{
		int num = Math.Min(int_5, int_2 - int_3);
		Array.Copy(byte_1, int_3, byte_2, int_4, num);
		int_3 += num;
		return num;
	}

	private int method_3(byte[] byte_2, int int_4, int int_5, int int_6)
	{
		bool num = int_6 > int_5;
		if (!num)
		{
			if (num)
			{
				goto IL_002c;
			}
		}
		else if (byte_1 == null)
		{
			byte_1 = new byte[16];
			if (num)
			{
				goto IL_002c;
			}
		}
		else if (num)
		{
			goto IL_002c;
		}
		byte[] array = byte_2;
		goto IL_0035;
		IL_002c:
		array = byte_1;
		goto IL_0035;
		IL_0035:
		byte[] outputBuffer = array;
		int outputOffset = ((!num) ? int_4 : 0);
		zipAESTransform_0.TransformBlock(byte_0, int_0, int_6, outputBuffer, outputOffset);
		int_0 += int_6;
		if (num)
		{
			Array.Copy(byte_1, 0, byte_2, int_4, int_5);
			int_3 = int_5;
			int_2 = int_6;
			return int_5;
		}
		return int_6;
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		throw new NotImplementedException();
	}

	static ZipAESStream()
	{
		Class72.smethod_20();
	}
}
