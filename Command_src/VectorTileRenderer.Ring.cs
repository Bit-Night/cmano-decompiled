using System.Collections.Generic;

namespace VectorTileRenderer;

public class Ring
{
	public List<TilePoint> Points = new List<TilePoint>();

	public double SignedArea()
	{
		double num = 0.0;
		int count = Points.Count;
		int num2 = 0;
		int index = count - 1;
		while (num2 < count)
		{
			num += (double)Points[index].X * (double)Points[num2].Y - (double)Points[num2].X * (double)Points[index].Y;
			index = num2++;
		}
		return num / 2.0;
	}

	public bool IsExterior()
	{
		return SignedArea() >= 0.0;
	}

	static Ring()
	{
		Class72.smethod_20();
	}
}
