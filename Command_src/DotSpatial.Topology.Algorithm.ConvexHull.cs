using System;
using System.Collections.Generic;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Algorithm;

public class ConvexHull
{
	private class Class64 : IComparer<Coordinate>
	{
		private readonly Coordinate coordinate_0 = Coordinate.Empty;

		public Class64(Coordinate coordinate_1)
		{
			coordinate_0 = coordinate_1;
		}

		public int Compare(Coordinate x, Coordinate y)
		{
			return smethod_0(coordinate_0, x, y);
		}

		private static int smethod_0(Coordinate coordinate_1, Coordinate coordinate_2, Coordinate coordinate_3)
		{
			double num = coordinate_2.X - coordinate_1.X;
			double num2 = coordinate_2.Y - coordinate_1.Y;
			double num3 = coordinate_3.X - coordinate_1.X;
			double num4 = coordinate_3.Y - coordinate_1.Y;
			switch (CgAlgorithms.ComputeOrientation(coordinate_1, coordinate_2, coordinate_3))
			{
			case 1:
				return 1;
			case -1:
				return -1;
			default:
			{
				double num5 = num * num + num2 * num2;
				double num6 = num3 * num3 + num4 * num4;
				if (num5 >= num6)
				{
					if (num5 > num6)
					{
						return 1;
					}
					return 0;
				}
				return -1;
			}
			}
		}

		static Class64()
		{
			Class72.smethod_20();
		}
	}

	private readonly IGeometryFactory igeometryFactory_0;

	private readonly Coordinate[] coordinate_0;

	public ConvexHull(IGeometry geometry)
		: this(smethod_0(geometry), geometry.Factory)
	{
	}

	public ConvexHull(Coordinate[] pts, IGeometryFactory geomFactory)
	{
		coordinate_0 = pts;
		igeometryFactory_0 = geomFactory;
	}

	private static Coordinate[] smethod_0(IGeometry igeometry_0)
	{
		UniqueCoordinateArrayFilter uniqueCoordinateArrayFilter = new UniqueCoordinateArrayFilter();
		igeometry_0.Apply(uniqueCoordinateArrayFilter);
		return uniqueCoordinateArrayFilter.Coordinates;
	}

	public virtual IGeometry GetConvexHull()
	{
		if (coordinate_0.Length != 0)
		{
			if (coordinate_0.Length == 1)
			{
				return igeometryFactory_0.CreatePoint(coordinate_0[0]);
			}
			if (coordinate_0.Length == 2)
			{
				return igeometryFactory_0.CreateLineString(coordinate_0);
			}
			Coordinate[] object_ = coordinate_0;
			if (coordinate_0.Length > 50)
			{
				object_ = Reduce(coordinate_0);
			}
			Coordinate[] coordinate_ = smethod_2(smethod_1(object_)).ToArray();
			return method_1(coordinate_);
		}
		return igeometryFactory_0.CreateGeometryCollection(null);
	}

	private static Coordinate[] Reduce(object pts)
	{
		Coordinate[] array = smethod_4(pts);
		if (array != null)
		{
			SortedSet<Coordinate> sortedSet = new SortedSet<Coordinate>();
			for (int i = 0; i < array.Length; i++)
			{
				sortedSet.Add(array[i]);
			}
			for (int j = 0; j < ((Array)pts).Length; j++)
			{
				if (!CgAlgorithms.IsPointInRing((Coordinate)((object[])pts)[j], array))
				{
					sortedSet.Add((Coordinate)((object[])pts)[j]);
				}
			}
			Coordinate[] array2 = new Coordinate[sortedSet.Count];
			sortedSet.CopyTo(array2, 0);
			return array2;
		}
		return (Coordinate[])pts;
	}

	private static Coordinate[] smethod_1(object object_0)
	{
		for (int i = 1; i < ((Array)object_0).Length; i++)
		{
			if (((Coordinate)((object[])object_0)[i]).Y < ((Coordinate)((object[])object_0)[0]).Y || (((Coordinate)((object[])object_0)[i]).Y == ((Coordinate)((object[])object_0)[0]).Y && ((Coordinate)((object[])object_0)[i]).X < ((Coordinate)((object[])object_0)[0]).X))
			{
				Coordinate coordinate = (Coordinate)((object[])object_0)[0];
				((object[])object_0)[0] = ((object[])object_0)[i];
				((object[])object_0)[i] = coordinate;
			}
		}
		Array.Sort((Coordinate[])object_0, 1, ((Array)object_0).Length - 1, new Class64((Coordinate)((object[])object_0)[0]));
		return (Coordinate[])object_0;
	}

	private static Stack<Coordinate> smethod_2(object object_0)
	{
		Stack<Coordinate> stack = new Stack<Coordinate>(((Array)object_0).Length);
		stack.Push((Coordinate)((object[])object_0)[0]);
		stack.Push((Coordinate)((object[])object_0)[1]);
		stack.Push((Coordinate)((object[])object_0)[2]);
		for (int i = 3; i < ((Array)object_0).Length; i++)
		{
			Coordinate coordinate = stack.Pop();
			while (CgAlgorithms.ComputeOrientation(stack.Peek(), coordinate, (Coordinate)((object[])object_0)[i]) > 0)
			{
				coordinate = stack.Pop();
			}
			stack.Push(coordinate);
			stack.Push((Coordinate)((object[])object_0)[i]);
		}
		stack.Push((Coordinate)((object[])object_0)[0]);
		return stack;
	}

	private Stack<Coordinate> method_0(Stack<Coordinate> stack_0)
	{
		int count = stack_0.Count;
		Coordinate[] array = new Coordinate[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = stack_0.Pop();
		}
		Stack<Coordinate> stack = new Stack<Coordinate>(count);
		Coordinate[] array2 = array;
		foreach (Coordinate item in array2)
		{
			stack.Push(item);
		}
		return stack;
	}

	private static bool smethod_3(Coordinate coordinate_1, Coordinate coordinate_2, Coordinate coordinate_3)
	{
		if (CgAlgorithms.ComputeOrientation(coordinate_1, coordinate_2, coordinate_3) != 0)
		{
			return false;
		}
		if (coordinate_1.X != coordinate_3.X)
		{
			if (coordinate_1.X <= coordinate_2.X && coordinate_2.X <= coordinate_3.X)
			{
				return true;
			}
			if (coordinate_3.X <= coordinate_2.X && coordinate_2.X <= coordinate_1.X)
			{
				return true;
			}
		}
		if (coordinate_1.Y != coordinate_3.Y)
		{
			if (coordinate_1.Y <= coordinate_2.Y && coordinate_2.Y <= coordinate_3.Y)
			{
				return true;
			}
			if (coordinate_3.Y <= coordinate_2.Y && coordinate_2.Y <= coordinate_1.Y)
			{
				return true;
			}
		}
		return false;
	}

	private static Coordinate[] smethod_4(object object_0)
	{
		Coordinate[] coord = smethod_5(object_0);
		CoordinateList coordinateList = new CoordinateList { { coord, false } };
		if (coordinateList.Count >= 3)
		{
			coordinateList.CloseRing();
			return coordinateList.ToCoordinateArray();
		}
		return null;
	}

	private static Coordinate[] smethod_5(object object_0)
	{
		Coordinate[] array = new Coordinate[8];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (Coordinate)((object[])object_0)[0];
		}
		for (int j = 1; j < ((Array)object_0).Length; j++)
		{
			if (((Coordinate)((object[])object_0)[j]).X < array[0].X)
			{
				array[0] = (Coordinate)((object[])object_0)[j];
			}
			if (((Coordinate)((object[])object_0)[j]).X - ((Coordinate)((object[])object_0)[j]).Y < array[1].X - array[1].Y)
			{
				array[1] = (Coordinate)((object[])object_0)[j];
			}
			if (((Coordinate)((object[])object_0)[j]).Y > array[2].Y)
			{
				array[2] = (Coordinate)((object[])object_0)[j];
			}
			if (((Coordinate)((object[])object_0)[j]).X + ((Coordinate)((object[])object_0)[j]).Y > array[3].X + array[3].Y)
			{
				array[3] = (Coordinate)((object[])object_0)[j];
			}
			if (((Coordinate)((object[])object_0)[j]).X > array[4].X)
			{
				array[4] = (Coordinate)((object[])object_0)[j];
			}
			if (((Coordinate)((object[])object_0)[j]).X - ((Coordinate)((object[])object_0)[j]).Y > array[5].X - array[5].Y)
			{
				array[5] = (Coordinate)((object[])object_0)[j];
			}
			if (((Coordinate)((object[])object_0)[j]).Y < array[6].Y)
			{
				array[6] = (Coordinate)((object[])object_0)[j];
			}
			if (((Coordinate)((object[])object_0)[j]).X + ((Coordinate)((object[])object_0)[j]).Y < array[7].X + array[7].Y)
			{
				array[7] = (Coordinate)((object[])object_0)[j];
			}
		}
		return array;
	}

	private IGeometry method_1(Coordinate[] coordinate_1)
	{
		coordinate_1 = smethod_6(coordinate_1);
		if (coordinate_1.Length == 3)
		{
			return igeometryFactory_0.CreateLineString(new Coordinate[2]
			{
				coordinate_1[0],
				coordinate_1[1]
			});
		}
		ILinearRing shell = igeometryFactory_0.CreateLinearRing(coordinate_1);
		return igeometryFactory_0.CreatePolygon(shell, null);
	}

	private static Coordinate[] smethod_6(object object_0)
	{
		object.Equals(((object[])object_0)[0], ((object[])object_0)[^1]);
		List<Coordinate> list = new List<Coordinate>();
		Coordinate coordinate = Coordinate.Empty;
		for (int i = 0; i <= ((Array)object_0).Length - 2; i++)
		{
			Coordinate coordinate2 = (Coordinate)((object[])object_0)[i];
			Coordinate coordinate3 = (Coordinate)((object[])object_0)[i + 1];
			if (!coordinate2.Equals(coordinate3) && (coordinate.IsEmpty() || !smethod_3(coordinate, coordinate2, coordinate3)))
			{
				list.Add(coordinate2);
				coordinate = coordinate2;
			}
		}
		list.Add((Coordinate)((object[])object_0)[^1]);
		return list.ToArray();
	}

	static ConvexHull()
	{
		Class72.smethod_20();
	}
}
