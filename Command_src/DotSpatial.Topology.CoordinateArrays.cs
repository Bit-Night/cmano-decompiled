using System;
using System.Collections;
using System.Collections.Generic;

namespace DotSpatial.Topology;

public static class CoordinateArrays
{
	public class BidirectionalComparator : IComparer<Coordinate[]>
	{
		public virtual int Compare(Coordinate[] pts1, Coordinate[] pts2)
		{
			if (pts1.Length < pts2.Length)
			{
				return -1;
			}
			if (pts1.Length > pts2.Length)
			{
				return 1;
			}
			if (pts1.Length != 0)
			{
				int result = CoordinateArrays.Compare(pts1, pts2);
				if (smethod_0(pts1, pts2))
				{
					return 0;
				}
				return result;
			}
			return 0;
		}

		static BidirectionalComparator()
		{
			Class72.smethod_20();
		}
	}

	public class ForwardComparator : IComparer<Coordinate[]>
	{
		public virtual int Compare(Coordinate[] pts1, Coordinate[] pts2)
		{
			return CoordinateArrays.Compare(pts1, pts2);
		}

		static ForwardComparator()
		{
			Class72.smethod_20();
		}
	}

	public static Coordinate PointNotInList(Coordinate[] testPts, Coordinate[] pts)
	{
		int num = 0;
		Coordinate coordinate;
		while (true)
		{
			if (num < testPts.Length)
			{
				coordinate = testPts[num];
				if (IndexOf(coordinate, pts) < 0)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return coordinate;
	}

	public static int Compare(Coordinate[] pts1, Coordinate[] pts2)
	{
		int i;
		for (i = 0; i < pts1.Length && i < pts2.Length; i++)
		{
			int num = pts1[i].CompareTo(pts2[i]);
			if (num != 0)
			{
				return num;
			}
		}
		if (i < pts2.Length)
		{
			return -1;
		}
		if (i >= pts1.Length)
		{
			return 0;
		}
		return 1;
	}

	public static int IncreasingDirection(IList<Coordinate> pts)
	{
		int num = 0;
		int num2;
		while (true)
		{
			if (num < pts.Count / 2)
			{
				int index = pts.Count - 1 - num;
				num2 = pts[num].CompareTo(pts[index]);
				if (num2 != 0)
				{
					break;
				}
				num++;
				continue;
			}
			return 1;
		}
		return num2;
	}

	private static bool smethod_0(object object_0, object object_1)
	{
		for (int i = 0; i < ((Array)object_0).Length; i++)
		{
			object obj = ((object[])object_0)[i];
			Coordinate other = (Coordinate)((object[])object_1)[((Array)object_0).Length - i - 1];
			if (((Coordinate)obj).CompareTo(other) != 0)
			{
				return false;
			}
		}
		return true;
	}

	public static Coordinate[] CopyDeep(Coordinate[] coordinates)
	{
		Coordinate[] array = new Coordinate[coordinates.Length];
		for (int i = 0; i < coordinates.Length; i++)
		{
			array[i] = new Coordinate(coordinates[i]);
		}
		return array;
	}

	[Obsolete("Use generic method instead")]
	public static Coordinate[] ToCoordinateArray(IList coordList)
	{
		List<Coordinate> list = new List<Coordinate>(coordList.Count);
		foreach (Coordinate coord in coordList)
		{
			list.Add(coord);
		}
		return list.ToArray();
	}

	public static Coordinate[] ToCoordinateArray(IList<Coordinate> coordList)
	{
		List<Coordinate> list = new List<Coordinate>(coordList.Count);
		foreach (Coordinate coord in coordList)
		{
			list.Add(coord);
		}
		return list.ToArray();
	}

	public static bool HasRepeatedPoints(IEnumerable<Coordinate> coords)
	{
		Coordinate obj = null;
		foreach (Coordinate coord in coords)
		{
			if (!coord.Equals(obj))
			{
				obj = coord;
				continue;
			}
			return true;
		}
		return false;
	}

	public static Coordinate[] AtLeastNCoordinatesOrNothing(int n, Coordinate[] c)
	{
		if (c.Length < n)
		{
			return new Coordinate[0];
		}
		return c;
	}

	public static IList<Coordinate> RemoveRepeatedPoints(IList<Coordinate> coords)
	{
		if (HasRepeatedPoints(coords))
		{
			return new CoordinateList(coords, allowRepeated: false);
		}
		return coords;
	}

	public static void Reverse(Coordinate[] coord)
	{
		Array.Reverse((Array)coord);
	}

	public static bool Equals(Coordinate[] coord1, Coordinate[] coord2)
	{
		if (coord1 == coord2)
		{
			return true;
		}
		int result;
		if (coord1 == null)
		{
			result = 0;
		}
		else
		{
			if (coord2 != null)
			{
				if (coord1.Length != coord2.Length)
				{
					return false;
				}
				for (int i = 0; i < coord1.Length; i++)
				{
					if (!coord1[i].Equals(coord2[i]))
					{
						return false;
					}
				}
				return true;
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	public static bool Equals(Coordinate[] coord1, Coordinate[] coord2, IComparer<Coordinate[]> coordinateComparer)
	{
		if (coord1 == coord2)
		{
			return true;
		}
		int result;
		if (coord1 != null)
		{
			if (coord2 != null)
			{
				if (coord1.Length != coord2.Length)
				{
					return false;
				}
				if (coordinateComparer.Compare(coord1, coord2) != 0)
				{
					return false;
				}
				return true;
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public static Coordinate MinCoordinate(Coordinate[] coordinates)
	{
		Coordinate coordinate = null;
		for (int i = 0; i < coordinates.Length; i++)
		{
			if (coordinate == null || coordinate.CompareTo(coordinates[i]) > 0)
			{
				coordinate = coordinates[i];
			}
		}
		return coordinate;
	}

	public static void Scroll(Coordinate[] coordinates, Coordinate firstCoordinate)
	{
		int num = IndexOf(firstCoordinate, coordinates);
		if (num >= 0)
		{
			Coordinate[] array = new Coordinate[coordinates.Length];
			Array.Copy(coordinates, num, array, 0, coordinates.Length - num);
			Array.Copy(coordinates, 0, array, coordinates.Length - num, num);
			Array.Copy(array, 0, coordinates, 0, coordinates.Length);
		}
	}

	public static int IndexOf(Coordinate coordinate, Coordinate[] coordinates)
	{
		for (int i = 0; i < coordinates.Length; i++)
		{
			if (coordinate.Equals(coordinates[i]))
			{
				return i;
			}
		}
		return -1;
	}

	public static Coordinate[] Extract(Coordinate[] pts, int start, int end)
	{
		int num = end - start + 1;
		Coordinate[] array = new Coordinate[num];
		Array.Copy(pts, start, array, 0, num);
		return array;
	}

	static CoordinateArrays()
	{
		Class72.smethod_20();
	}
}
