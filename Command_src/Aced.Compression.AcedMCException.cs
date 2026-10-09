using System;

namespace Aced.Compression;

public sealed class AcedMCException : Exception
{
	internal static void ThrowArgumentNullException(string paramName)
	{
		throw new ArgumentNullException(paramName);
	}

	internal static void ThrowNoPlaceToStoreCompressedDataException()
	{
		throw new AcedMCException("Destination byte array is not enough to store compressed data.");
	}

	internal static void ThrowNoPlaceToStoreDecompressedDataException()
	{
		throw new AcedMCException("Destination byte array is not enough to store decompressed data.");
	}

	internal static void ThrowReadBeyondTheEndException()
	{
		throw new AcedMCException("An attempt to read beyond the end of the source byte array.");
	}

	private AcedMCException(string message)
		: base(message)
	{
	}

	static AcedMCException()
	{
		Class72.smethod_20();
	}
}
