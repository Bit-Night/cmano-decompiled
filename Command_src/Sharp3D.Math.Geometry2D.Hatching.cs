using System;
using System.Collections.Generic;
using CSMaterial;
using Sharp3D.Math.Core;

namespace Sharp3D.Math.Geometry2D;

public sealed class Hatching
{
	public sealed class PointComparer : IComparer<Vector2D>
	{
		private Vector2D vector2D_0;

		private Vector2D vector2D_1;

		public PointComparer(Vector2D ptOrigin, Vector2D direction)
		{
			vector2D_0 = ptOrigin;
			vector2D_1 = direction;
		}

		public int Compare(Vector2D pt1, Vector2D pt2)
		{
			if (!(Vector2D.DotProduct(pt1 - vector2D_0, vector2D_1) >= Vector2D.DotProduct(pt2 - vector2D_0, vector2D_1)))
			{
				return -1;
			}
			return 1;
		}

		static PointComparer()
		{
			Class72.smethod_20();
		}
	}

	private Rectangle NbcyXgUwtr1;

	private Rectangle rectangle_0;

	private bool bool_0;

	public Hatching(Rectangle rOuter)
	{
		NbcyXgUwtr1 = rOuter;
	}

	public Hatching(Rectangle rOuter, Rectangle rHole)
	{
		NbcyXgUwtr1 = rOuter;
		rectangle_0 = rHole;
		bool_0 = true;
	}

	public Segment[] GetHatchingSegments(double angle, double spacing)
	{
		double num = angle * CSMath.PI_dividedBy_180;
		Vector2D vector2D = new Vector2D(System.Math.Cos(num), System.Math.Sin(num));
		Vector2D direction = new Vector2D(0.0 - vector2D.Y, vector2D.X);
		int num2 = Convert.ToInt32(Vector2D.DotProduct(NbcyXgUwtr1.Dimensions, vector2D) / spacing);
		Segment[] segments = NbcyXgUwtr1.Segments;
		Segment[] segments2 = rectangle_0.Segments;
		List<Segment> list = new List<Segment>();
		Segment[] array = segments;
		foreach (Segment item in array)
		{
			list.Add(item);
		}
		array = segments2;
		foreach (Segment item2 in array)
		{
			list.Add(item2);
		}
		for (int j = 0; j < num2; j++)
		{
			Vector2D vector2D2 = NbcyXgUwtr1.Origin + (double)j * spacing * vector2D;
			Ray ray = new Ray(vector2D2, direction);
			List<Vector2D> list2 = new List<Vector2D>();
			array = segments;
			for (int i = 0; i < array.Length; i++)
			{
				if (IntersectMethods.Intersect(array[i], ray, out var interObj))
				{
					list2.Add((Vector2D)interObj.Result);
				}
			}
			if (bool_0 && list2.Count >= 2)
			{
				array = segments2;
				for (int i = 0; i < array.Length; i++)
				{
					if (IntersectMethods.Intersect(array[i], ray, out var interObj2))
					{
						list2.Add((Vector2D)interObj2.Result);
					}
				}
			}
			list2.Sort(new PointComparer(vector2D2, direction));
			if (list2.Count >= 2)
			{
				list.Add(new Segment(list2[0], list2[1]));
			}
			if (list2.Count >= 4)
			{
				list.Add(new Segment(list2[2], list2[3]));
			}
		}
		return list.ToArray();
	}

	static Hatching()
	{
		Class72.smethod_20();
	}
}
