using System;

namespace VectorTileRenderer;

public class TileFetchException : TileProviderException
{
	public TileFetchException(string message, Exception inner)
		: base(message, inner)
	{
	}

	static TileFetchException()
	{
		Class72.smethod_20();
	}
}
