using System;
using System.IO;
using System.Text;
using ICSharpCode.SharpZipLib.Checksum;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Encryption;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace ICSharpCode.SharpZipLib.Zip;

public class ZipInputStream : InflaterInputStream
{
	private delegate int Delegate4(byte[] b, int offset, int length);

	private Delegate4 delegate4_0;

	private Crc32 crc32_0 = new Crc32();

	private ZipEntry zipEntry_0;

	private long long_0;

	private CompressionMethod compressionMethod_0;

	private int int_0;

	private string string_0;

	private readonly StringCodec stringCodec_0 = ZipStrings.GetStringCodec();

	public string Password
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public bool CanDecompressEntry
	{
		get
		{
			if (zipEntry_0 != null && smethod_0(zipEntry_0) && zipEntry_0.CanDecompress)
			{
				int result;
				if (zipEntry_0.HasFlag(GeneralBitFlags.Descriptor))
				{
					if (zipEntry_0.CompressionMethod == CompressionMethod.Stored)
					{
						return zipEntry_0.IsCrypted;
					}
					result = 1;
				}
				else
				{
					result = 1;
				}
				return (byte)result != 0;
			}
			return false;
		}
	}

	public override int Available => (zipEntry_0 != null) ? 1 : 0;

	public override long Length
	{
		get
		{
			if (zipEntry_0 != null)
			{
				if (zipEntry_0.Size < 0L)
				{
					throw new ZipException("Length not available for the current entry");
				}
				return zipEntry_0.Size;
			}
			throw new InvalidOperationException("No current entry");
		}
	}

	public ZipInputStream(Stream baseInputStream)
		: base(baseInputStream, InflaterPool.Instance.Rent(noHeader: true))
	{
		delegate4_0 = method_3;
	}

	public ZipInputStream(Stream baseInputStream, int bufferSize)
		: base(baseInputStream, InflaterPool.Instance.Rent(noHeader: true), bufferSize)
	{
		delegate4_0 = method_3;
	}

	public ZipInputStream(Stream baseInputStream, StringCodec stringCodec)
		: base(baseInputStream, new Inflater(noHeader: true))
	{
		delegate4_0 = method_3;
		if (stringCodec != null)
		{
			stringCodec_0 = stringCodec;
		}
	}

	private static bool smethod_0(ZipEntry zipEntry_1)
	{
		CompressionMethod compressionMethodForHeader = zipEntry_1.CompressionMethodForHeader;
		if (compressionMethodForHeader != CompressionMethod.Deflated)
		{
			return compressionMethodForHeader == CompressionMethod.Stored;
		}
		return true;
	}

	public ZipEntry GetNextEntry()
	{
		if (crc32_0 == null)
		{
			throw new InvalidOperationException("Closed.");
		}
		if (zipEntry_0 != null)
		{
			CloseEntry();
		}
		if (!method_0())
		{
			Dispose();
			return null;
		}
		short versionRequiredToExtract = (short)inputBuffer.ReadLeShort();
		int_0 = inputBuffer.ReadLeShort();
		compressionMethod_0 = (CompressionMethod)inputBuffer.ReadLeShort();
		uint num = (uint)inputBuffer.ReadLeInt();
		int num2 = inputBuffer.ReadLeInt();
		csize = inputBuffer.ReadLeInt();
		long_0 = inputBuffer.ReadLeInt();
		int num3 = inputBuffer.ReadLeShort();
		int num4 = inputBuffer.ReadLeShort();
		bool flag = (int_0 & 1) == 1;
		byte[] array = new byte[num3];
		inputBuffer.ReadRawBuffer(array);
		Encoding encoding = stringCodec_0.ZipInputEncoding(int_0);
		string name = encoding.GetString(array);
		bool unicode = EncodingExtensions.IsZipUnicode(encoding);
		zipEntry_0 = new ZipEntry(name, versionRequiredToExtract, 51, compressionMethod_0, unicode)
		{
			Flags = int_0
		};
		if ((int_0 & 8) == 0)
		{
			zipEntry_0.Crc = num2 & 0xFFFFFFFFL;
			zipEntry_0.Size = long_0 & 0xFFFFFFFFL;
			zipEntry_0.CompressedSize = csize & 0xFFFFFFFFL;
			zipEntry_0.CryptoCheckValue = (byte)((num2 >> 24) & 0xFF);
		}
		else
		{
			if (num2 != 0)
			{
				zipEntry_0.Crc = num2 & 0xFFFFFFFFL;
			}
			if (long_0 != 0L)
			{
				zipEntry_0.Size = long_0 & 0xFFFFFFFFL;
			}
			if (csize != 0L)
			{
				zipEntry_0.CompressedSize = csize & 0xFFFFFFFFL;
			}
			zipEntry_0.CryptoCheckValue = (byte)((num >> 8) & 0xFF);
		}
		zipEntry_0.DosTime = num;
		if (num4 > 0)
		{
			byte[] array2 = new byte[num4];
			inputBuffer.ReadRawBuffer(array2);
			zipEntry_0.ExtraData = array2;
		}
		zipEntry_0.ProcessExtraData(localHeader: true);
		if (zipEntry_0.CompressedSize >= 0L)
		{
			csize = zipEntry_0.CompressedSize;
		}
		if (zipEntry_0.Size >= 0L)
		{
			long_0 = zipEntry_0.Size;
		}
		if (compressionMethod_0 == CompressionMethod.Stored && ((!flag && csize != long_0) || (flag && csize - 12L != long_0)))
		{
			throw new ZipException("Stored, but compressed != uncompressed");
		}
		if (!smethod_0(zipEntry_0))
		{
			delegate4_0 = method_4;
		}
		else
		{
			delegate4_0 = method_6;
		}
		return zipEntry_0;
	}

	private bool method_0()
	{
		int num = 0;
		while (inputBuffer.ReadLeByte() == 0)
		{
			num++;
		}
		inputBuffer.Available++;
		int num2 = 0;
		uint num3 = (uint)inputBuffer.ReadLeInt();
		int result;
		while (true)
		{
			switch (num3)
			{
			default:
				goto IL_0053;
			case 67324752u:
				return true;
			case 117853008u:
				result = 0;
				break;
			case 33639248u:
			case 84233040u:
			case 101010256u:
			case 101075792u:
				result = 0;
				break;
			}
			break;
			IL_0053:
			num3 = (uint)(inputBuffer.ReadLeByte() << 24) | (num3 >> 8);
			num2++;
		}
		return (byte)result != 0;
	}

	private void method_1()
	{
		if (inputBuffer.ReadLeInt() != 134695760)
		{
			throw new ZipException("Data descriptor signature not found");
		}
		zipEntry_0.Crc = inputBuffer.ReadLeInt() & 0xFFFFFFFFL;
		if (zipEntry_0.LocalHeaderRequiresZip64)
		{
			csize = inputBuffer.ReadLeLong();
			long_0 = inputBuffer.ReadLeLong();
		}
		else
		{
			csize = inputBuffer.ReadLeInt();
			long_0 = inputBuffer.ReadLeInt();
		}
		zipEntry_0.CompressedSize = csize;
		zipEntry_0.Size = long_0;
	}

	private void method_2(bool bool_2)
	{
		StopDecrypting();
		if ((int_0 & 8) != 0)
		{
			method_1();
		}
		long_0 = 0L;
		if (bool_2 && (crc32_0.Value & 0xFFFFFFFFL) != zipEntry_0.Crc && zipEntry_0.Crc != -1L)
		{
			throw new ZipException("CRC mismatch");
		}
		crc32_0.Reset();
		if (compressionMethod_0 == CompressionMethod.Deflated)
		{
			inf.Reset();
		}
		zipEntry_0 = null;
	}

	public void CloseEntry()
	{
		if (crc32_0 == null)
		{
			throw new InvalidOperationException("Closed");
		}
		if (zipEntry_0 == null)
		{
			return;
		}
		if (compressionMethod_0 == CompressionMethod.Deflated)
		{
			if ((int_0 & 8) != 0)
			{
				byte[] array = new byte[4096];
				while (Read(array, 0, array.Length) > 0)
				{
				}
				return;
			}
			csize -= inf.TotalIn;
			inputBuffer.Available += inf.RemainingInput;
		}
		if (inputBuffer.Available > csize && csize >= 0L)
		{
			inputBuffer.Available = (int)(inputBuffer.Available - csize);
		}
		else
		{
			csize -= inputBuffer.Available;
			inputBuffer.Available = 0;
			while (csize != 0L)
			{
				long num = Skip(csize);
				if (num > 0L)
				{
					csize -= num;
					continue;
				}
				throw new ZipException("Zip archive ends early.");
			}
		}
		method_2(bool_2: false);
	}

	public override int ReadByte()
	{
		byte[] array = new byte[1];
		if (Read(array, 0, 1) <= 0)
		{
			return -1;
		}
		return array[0] & 0xFF;
	}

	private int method_3(byte[] byte_0, int int_1, int int_2)
	{
		throw new InvalidOperationException("Unable to read from this stream");
	}

	private int method_4(byte[] byte_0, int int_1, int int_2)
	{
		throw new ZipException("The compression method for this entry is not supported");
	}

	private int method_5(byte[] byte_0, int int_1, int int_2)
	{
		throw new StreamUnsupportedException("The combination of Stored compression method and Descriptor flag is not possible to read using ZipInputStream");
	}

	private int method_6(byte[] byte_0, int int_1, int int_2)
	{
		bool flag = (zipEntry_0.Flags & 8) != 0;
		if (!zipEntry_0.IsCrypted)
		{
			inputBuffer.CryptoTransform = null;
		}
		else
		{
			if (string_0 == null)
			{
				throw new ZipException("No password set.");
			}
			PkzipClassicManaged pkzipClassicManaged = new PkzipClassicManaged();
			byte[] rgbKey = PkzipClassic.GenerateKeys(stringCodec_0.ZipCryptoEncoding.GetBytes(string_0));
			inputBuffer.CryptoTransform = pkzipClassicManaged.CreateDecryptor(rgbKey, null);
			byte[] array = new byte[12];
			inputBuffer.ReadClearTextBuffer(array, 0, 12);
			if (array[11] != zipEntry_0.CryptoCheckValue)
			{
				throw new ZipException("Invalid password");
			}
			if (csize < 12L)
			{
				if (!flag)
				{
					throw new ZipException($"Entry compressed size {csize} too small for encryption");
				}
			}
			else
			{
				csize -= 12L;
			}
		}
		if (!(csize > 0L || flag))
		{
			delegate4_0 = method_3;
			return 0;
		}
		if (compressionMethod_0 == CompressionMethod.Deflated && inputBuffer.Available > 0)
		{
			inputBuffer.SetInflaterInput(inf);
		}
		if (!zipEntry_0.IsCrypted && compressionMethod_0 == CompressionMethod.Stored && flag)
		{
			delegate4_0 = method_5;
			return method_5(byte_0, int_1, int_2);
		}
		if (!CanDecompressEntry)
		{
			delegate4_0 = method_4;
			return method_4(byte_0, int_1, int_2);
		}
		delegate4_0 = method_7;
		return method_7(byte_0, int_1, int_2);
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		if (buffer == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (offset >= 0)
		{
			if (count >= 0)
			{
				if (buffer.Length - offset < count)
				{
					throw new ArgumentException("Invalid offset/count combination");
				}
				return delegate4_0(buffer, offset, count);
			}
			throw new ArgumentOutOfRangeException("count", "Cannot be negative");
		}
		throw new ArgumentOutOfRangeException("offset", "Cannot be negative");
	}

	private int method_7(byte[] byte_0, int int_1, int int_2)
	{
		if (crc32_0 == null)
		{
			throw new InvalidOperationException("Closed");
		}
		int result;
		if (zipEntry_0 == null)
		{
			result = 0;
		}
		else
		{
			if (int_2 > 0)
			{
				if (int_1 + int_2 > byte_0.Length)
				{
					throw new ArgumentException("Offset + count exceeds buffer size");
				}
				bool flag = false;
				switch (compressionMethod_0)
				{
				case CompressionMethod.Stored:
					if (int_2 > csize && csize >= 0L)
					{
						int_2 = (int)csize;
					}
					if (int_2 > 0)
					{
						int_2 = inputBuffer.ReadClearTextBuffer(byte_0, int_1, int_2);
						if (int_2 > 0)
						{
							csize -= int_2;
							long_0 -= int_2;
						}
					}
					if (csize == 0L)
					{
						flag = true;
					}
					else if (int_2 < 0)
					{
						throw new ZipException("EOF in stored block");
					}
					break;
				case CompressionMethod.Deflated:
					{
						int_2 = base.Read(byte_0, int_1, int_2);
						if (int_2 > 0)
						{
							break;
						}
						if (!inf.IsFinished)
						{
							throw new ZipException("Inflater not finished!");
						}
						inputBuffer.Available = inf.RemainingInput;
						if ((int_0 & 8) == 0)
						{
							int num;
							if (inf.TotalIn != csize && csize != 4294967295L && csize != -1L)
							{
								num = 8;
							}
							else
							{
								if (inf.TotalOut == long_0)
								{
									goto IL_01dd;
								}
								num = 8;
							}
							string[] array = new string[num];
							array[0] = "Size mismatch: ";
							array[1] = csize.ToString();
							array[2] = ";";
							array[3] = long_0.ToString();
							array[4] = " <-> ";
							array[5] = inf.TotalIn.ToString();
							array[6] = ";";
							array[7] = inf.TotalOut.ToString();
							throw new ZipException(string.Concat(array));
						}
						goto IL_01dd;
					}
					IL_01dd:
					inf.Reset();
					flag = true;
					break;
				}
				if (int_2 > 0)
				{
					crc32_0.Update(new ArraySegment<byte>(byte_0, int_1, int_2));
				}
				if (flag)
				{
					method_2(bool_2: true);
				}
				return int_2;
			}
			result = 0;
		}
		return result;
	}

	protected override void Dispose(bool disposing)
	{
		delegate4_0 = method_3;
		crc32_0 = null;
		zipEntry_0 = null;
		base.Dispose(disposing);
	}

	static ZipInputStream()
	{
		Class72.smethod_20();
	}
}
