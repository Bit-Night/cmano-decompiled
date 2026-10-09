namespace VectorTileRenderer;

public struct TilePoint
{
	public int X;

	public int Y;

	public TilePoint(int x, int y)
	{
		X = x;
		Y = y;
	}

	public override string ToString()
	{
		return $"({X},{Y})";
	}

	static TilePoint()
	{
		Class72.smethod_20();
	}
}
