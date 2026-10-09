using System;

namespace VectorTileRenderer;

public class TileProviderException : Exception
{
	public TileProviderException(string message, Exception inner)
		: base(message, inner)
	{
	}

	public TileProviderException(string message)
		: base(message)
	{
	}

	static TileProviderException()
	{
		Class72.smethod_20();
	}
}
