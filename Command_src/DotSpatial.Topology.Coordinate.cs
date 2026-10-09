using System;
using DotSpatial.Serialization;

namespace DotSpatial.Topology;

[Serializable]
public class Coordinate : ICloneable, IComparable<Coordinate>, IComparable
{
	[Serialize("M")]
	public double M;

	[Serialize("X")]
	public double X;

	[Serialize("Y")]
	public double Y;

	[Serialize("Z")]
	public double Z;

	public static Coordinate Empty => new Coordinate(double.NaN, double.NaN);

	public double this[int index]
	{
		get
		{
			return index switch
			{
				0 => X, 
				1 => Y, 
				2 => Z, 
				_ => throw new IndexOutOfRangeException(), 
			};
		}
		set
		{
			switch (index)
			{
			default:
				throw new IndexOutOfRangeException();
			case 0:
				X = value;
				break;
			case 1:
				Y = value;
				break;
			case 2:
				Z = value;
				break;
			}
		}
	}

	public int NumOrdinates
	{
		get
		{
			if (double.IsNaN(Z))
			{
				return 2;
			}
			return 3;
		}
	}

	public Coordinate()
	{
		X = double.NaN;
		Y = double.NaN;
		Z = double.NaN;
		M = double.NaN;
	}

	public Coordinate(double x, double y)
	{
		X = x;
		Y = y;
		Z = double.NaN;
		M = double.NaN;
	}

	public Coordinate(double x, double y, double z)
	{
		X = x;
		Y = y;
		Z = z;
		M = double.NaN;
	}

	public Coordinate(double[] values)
	{
		if (values.Length != 0)
		{
			X = values[0];
		}
		if (values.Length > 1)
		{
			Y = values[1];
		}
		if (values.Length > 2)
		{
			Z = values[2];
		}
	}

	public Coordinate(ICoordinate c)
	{
		double[] values = c.Values;
		if (values.Length != 0)
		{
			X = values[0];
		}
		if (values.Length > 1)
		{
			Y = values[1];
		}
		if (values.Length > 2)
		{
			Z = values[2];
		}
		M = c.M;
	}

	public Coordinate(Coordinate c)
	{
		X = c.X;
		Y = c.Y;
		Z = c.Z;
		M = c.M;
	}

	public Coordinate(double x, double y, double z, double m)
	{
		X = x;
		Y = y;
		Z = z;
		M = m;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is Coordinate))
		{
			if (obj is ICoordinate coordinate)
			{
				if (!double.IsNaN(Z) && !double.IsNaN(coordinate.Z))
				{
					if (coordinate.X == X && coordinate.Y == Y)
					{
						return coordinate.Z == Z;
					}
					return false;
				}
				if (coordinate.X == X)
				{
					return coordinate.Y == Y;
				}
				return false;
			}
			return false;
		}
		Coordinate coordinate2 = (Coordinate)obj;
		if (!double.IsNaN(Z) && !double.IsNaN(coordinate2.Z))
		{
			if (coordinate2.X == X && coordinate2.Y == Y)
			{
				return coordinate2.Z == Z;
			}
			return false;
		}
		if (coordinate2.X == X)
		{
			return coordinate2.Y == Y;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public double[] ToArray()
	{
		if (!double.IsNaN(Z))
		{
			return new double[3] { X, Y, Z };
		}
		return new double[2] { X, Y };
	}

	public double Distance(Coordinate end)
	{
		double num = end.X - X;
		double num2 = end.Y - Y;
		return Math.Sqrt(num * num + num2 * num2);
	}

	public bool Equals2D(Coordinate b)
	{
		if (X == b.X && Y == b.Y)
		{
			return true;
		}
		return false;
	}

	public bool Equals3D(Coordinate b)
	{
		if (X == b.X && Y == b.Y)
		{
			if (Z != b.Z)
			{
				if (double.IsNaN(Z))
				{
					return double.IsNaN(b.Z);
				}
				return false;
			}
			return true;
		}
		return false;
	}

	public double HyperDistance(Coordinate b)
	{
		if (NumOrdinates != b.NumOrdinates)
		{
			throw new CoordinateMismatchException();
		}
		double num = 0.0;
		double[] array = ToArray();
		double[] array2 = b.ToArray();
		for (int i = 0; i < NumOrdinates; i++)
		{
			double num2 = array2[i] - array[i];
			num += num2 * num2;
		}
		return Math.Sqrt(num);
	}

	public new string ToString()
	{
		string text = "(" + X;
		for (int i = 1; i < NumOrdinates; i++)
		{
			text = text + ", " + this[i];
		}
		return text + ")";
	}

	int IComparable.CompareTo(object other)
	{
		Coordinate coordinate = other as Coordinate;
		if (coordinate == null)
		{
			throw new ArgumentException(TopologyText.ArgumentCouldNotBeCast_S1_S2.Replace("%S1", "other").Replace("%S2", "ICoordinate"));
		}
		if (X < coordinate.X)
		{
			return -1;
		}
		if (X > coordinate.X)
		{
			return 1;
		}
		if (Y < coordinate.Y)
		{
			return -1;
		}
		if (Y > coordinate.Y)
		{
			return 1;
		}
		return 0;
	}

	public virtual int CompareTo(Coordinate other)
	{
		if (!(other == null))
		{
			if (X < other.X)
			{
				return -1;
			}
			if (X > other.X)
			{
				return 1;
			}
			if (Y < other.Y)
			{
				return -1;
			}
			if (Y > other.Y)
			{
				return 1;
			}
			return 0;
		}
		throw new ArgumentException(TopologyText.ArgumentCouldNotBeCast_S1_S2.Replace("%S1", "other").Replace("%S2", "ICoordinate"));
	}

	public bool IsEmpty()
	{
		if (!double.IsNaN(X))
		{
			return double.IsNaN(Y);
		}
		return true;
	}

	public object Clone()
	{
		return MemberwiseClone();
	}

	public static bool operator ==(Coordinate obj1, Coordinate obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(Coordinate obj1, Coordinate obj2)
	{
		return !(obj1 == obj2);
	}

	public static Coordinate operator +(Coordinate coord1, Coordinate coord2)
	{
		return new Coordinate(coord1.X + coord2.X, coord1.Y + coord2.Y, coord1.Z + coord2.Z);
	}

	public static Coordinate operator +(Coordinate coord1, double d)
	{
		return new Coordinate(coord1.X + d, coord1.Y + d, coord1.Z + d);
	}

	public static Coordinate operator +(double d, Coordinate coord1)
	{
		return coord1 + d;
	}

	public static Coordinate operator *(Coordinate coord1, Coordinate coord2)
	{
		return new Coordinate(coord1.X * coord2.X, coord1.Y * coord2.Y, coord1.Z * coord2.Z);
	}

	public static Coordinate operator *(Coordinate coord1, double d)
	{
		return new Coordinate(coord1.X * d, coord1.Y * d, coord1.Z * d);
	}

	public static Coordinate operator *(double d, Coordinate coord1)
	{
		return coord1 * d;
	}

	public static Coordinate operator -(Coordinate coord1, Coordinate coord2)
	{
		return new Coordinate(coord1.X - coord2.X, coord1.Y - coord2.Y, coord1.Z - coord2.Z);
	}

	public static Coordinate operator -(Coordinate coord1, double d)
	{
		return new Coordinate(coord1.X - d, coord1.Y - d, coord1.Z - d);
	}

	public static Coordinate operator -(double d, Coordinate coord1)
	{
		return coord1 - d;
	}

	public static Coordinate operator /(Coordinate coord1, Coordinate coord2)
	{
		return new Coordinate(coord1.X / coord2.X, coord1.Y / coord2.Y, coord1.Z / coord2.Z);
	}

	public static Coordinate operator /(Coordinate coord1, double d)
	{
		return new Coordinate(coord1.X / d, coord1.Y / d, coord1.Z / d);
	}

	public static Coordinate operator /(double d, Coordinate coord1)
	{
		return coord1 / d;
	}

	static Coordinate()
	{
		Class72.smethod_20();
	}
}
