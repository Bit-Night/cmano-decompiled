using System.IO;
using System.Text;
using Aced.Compression;
using LZ4;
using Microsoft.VisualBasic.CompilerServices;
using SevenZip;

namespace Command_Core;

[StandardModule]
internal sealed class Compression
{
	internal static MemoryStream CompressStream_7z(Stream theStream, CompressionLevel theCompressionLevel)
	{
		MemoryStream stream = RCMS.recyclableMemoryStreamManager_0.GetStream();
		SevenZipCompressor sevenZipCompressor = new SevenZipCompressor();
		sevenZipCompressor.CompressionMethod = CompressionMethod.Lzma;
		sevenZipCompressor.CompressionLevel = theCompressionLevel;
		sevenZipCompressor.CompressStream(theStream, stream, GameGeneral.SZPW);
		return stream;
	}

	internal static byte[] CompressStream_Aced(Stream theStream, AcedCompressionLevel theCompressionLevel)
	{
		byte[] array = new byte[(int)theStream.Length + 1];
		if ((object)theStream.GetType() == typeof(MemoryStream))
		{
			array = ((MemoryStream)theStream).ToArray();
		}
		else if ((object)theStream.GetType() == typeof(MemoryStream))
		{
			array = ((MemoryStream)theStream).GetBuffer();
		}
		byte[] result = new AcedDeflator().Compress(array, 0, array.Length, theCompressionLevel, 0, 0);
		array = null;
		return result;
	}

	public static string DecompressToString_Aced(byte[] SourceByteArray)
	{
		AcedInflator acedInflator = new AcedInflator();
		byte[] array = new byte[SourceByteArray.Length + 1];
		array = SourceByteArray;
		byte[] bytes = acedInflator.Decompress(array, 0, 0, 0);
		array = null;
		string result = Encoding.UTF8.GetString(bytes);
		bytes = null;
		return result;
	}

	internal static MemoryTributary CompressStream_LZ(Stream theStream)
	{
		MemoryTributary memoryTributary = new MemoryTributary();
		LZ4Stream lZ4Stream = new LZ4Stream(memoryTributary, LZ4StreamMode.Compress, LZ4StreamFlags.IsolateInnerStream);
		theStream.Seek(0L, SeekOrigin.Begin);
		theStream.CopyTo(lZ4Stream);
		lZ4Stream.Close();
		return memoryTributary;
	}

	static Compression()
	{
		Class72.smethod_20();
	}
}
