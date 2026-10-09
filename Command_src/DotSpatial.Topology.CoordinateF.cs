using System;
using System.ComponentModel;

namespace DotSpatial.Topology;

[Serializable]
[TypeConverter(typeof(ExpandableObjectConverter))]
public sealed class CoordinateF
{
	private float float_0 = float.NaN;

	private float float_1 = float.NaN;

	private float float_2 = float.NaN;

	private float float_3 = float.NaN;

	public float X
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	public float Y
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
		}
	}

	public float Z
	{
		get
		{
			return float_3;
		}
		set
		{
			float_3 = value;
		}
	}

	public float M
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	[Browsable(false)]
	public CoordinateF CoordinateValue
	{
		get
		{
			return this;
		}
		set
		{
			float_1 = value.X;
			float_2 = value.Y;
			float_3 = value.Z;
			float_0 = value.M;
		}
	}

	public double this[int index]
	{
		get
		{
			return index switch
			{
				1 => Convert.ToDouble(float_2), 
				2 => Convert.ToDouble(float_3), 
				0 => Convert.ToDouble(float_1), 
				_ => 0.0, 
			};
		}
		set
		{
			if (index == 0)
			{
				float_1 = Convert.ToSingle(value);
			}
			if (index == 1)
			{
				float_2 = Convert.ToSingle(value);
			}
			if (index == 2)
			{
				float_3 = Convert.ToSingle(value);
			}
		}
	}

	public int NumOrdinates => 3;

	public double[] Values
	{
		get
		{
			return new double[3]
			{
				Convert.ToSingle(float_1),
				Convert.ToSingle(float_2),
				Convert.ToSingle(float_3)
			};
		}
		set
		{
			if (value.GetLength(0) > 0)
			{
				float_1 = Convert.ToSingle(value[0]);
			}
			if (value.GetLength(0) > 1)
			{
				float_2 = Convert.ToSingle(value[1]);
			}
			if (value.GetLength(0) > 2)
			{
				float_3 = Convert.ToSingle(value[2]);
			}
		}
	}

	public CoordinateF(FloatVector3 floatVector)
	{
		float_1 = floatVector.X;
		float_2 = floatVector.Y;
		float_3 = floatVector.Z;
		float_0 = float.NaN;
	}

	public CoordinateF(float x, float y, float z, float m)
	{
		float_1 = x;
		float_2 = y;
		float_3 = z;
		float_0 = m;
	}

	public CoordinateF(float x, float y, float z)
	{
		float_1 = x;
		float_2 = y;
		float_3 = z;
		float_0 = 0f;
	}

	public CoordinateF(Coordinate coordinate)
	{
		float_1 = Convert.ToSingle(coordinate.X);
		float_2 = Convert.ToSingle(coordinate.Y);
		float_3 = Convert.ToSingle(coordinate.Z);
	}

	public CoordinateF()
		: this(0f, 0f, 0f, 0f)
	{
	}

	public CoordinateF(float x, float y)
		: this(x, y, 0f, 0f)
	{
	}

	public bool Equals2D(CoordinateF coordinate)
	{
		if (!(coordinate == null))
		{
			if (float_1 != coordinate.X)
			{
				return false;
			}
			if (float_2 != coordinate.Y)
			{
				return false;
			}
		}
		else
		{
			if (float_1 != coordinate.X)
			{
				return false;
			}
			if (float_2 != coordinate.Y)
			{
				return false;
			}
		}
		return true;
	}

	public override bool Equals(object other)
	{
		if (other != null)
		{
			if (other is Coordinate)
			{
				return Equals2D((CoordinateF)other);
			}
			return false;
		}
		return false;
	}

	public static bool operator ==(CoordinateF obj1, Coordinate obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(CoordinateF obj1, Coordinate obj2)
	{
		return !(obj1 == obj2);
	}

	public int CompareTo(object other)
	{
		Coordinate coordinate = other as Coordinate;
		if (!(coordinate == null))
		{
			if ((double)float_1 >= coordinate.X)
			{
				if ((double)float_1 > coordinate.X)
				{
					return 1;
				}
				if ((double)float_2 < coordinate.Y)
				{
					return -1;
				}
				if ((double)float_2 > coordinate.Y)
				{
					return 1;
				}
				return 0;
			}
			return -1;
		}
		throw new ArgumentException(TopologyText.ArgumentCouldNotBeCast_S1_S2.Replace("%S1", "other").Replace("%S2", "ICoordinate"));
	}

	public bool Equals3D(CoordinateF other)
	{
		if (!(other == null))
		{
			if (float_1 == other.X && float_2 == other.Y)
			{
				if (float_3 != other.Z)
				{
					if (float.IsNaN(float_3))
					{
						return float.IsNaN(other.Z);
					}
					return false;
				}
				return true;
			}
			return false;
		}
		if (float_1 == other.X && float_2 == other.X)
		{
			if (float_3 != other.Z)
			{
				if (double.IsNaN(float_3))
				{
					return double.IsNaN(other.Z);
				}
				return false;
			}
			return true;
		}
		return false;
	}

	public override string ToString()
	{
		return "(" + float_1 + ", " + float_2 + ", " + float_3 + ")";
	}

	public object Clone()
	{
		return new Coordinate(float_1, float_2, float_3, float_0);
	}

	public Coordinate Copy()
	{
		return new Coordinate(float_1, float_2, float_3, float_0);
	}

	public double Distance(Coordinate coordinate)
	{
		double num = (double)float_1 - coordinate.X;
		double num2 = (double)float_2 - coordinate.Y;
		return Math.Sqrt(num * num + num2 * num2);
	}

	public double HyperDistance(Coordinate coordinate)
	{
		if (coordinate.NumOrdinates != NumOrdinates)
		{
			throw new CoordinateMismatchException();
		}
		double[] array = coordinate.ToArray();
		double num = array[0] - Convert.ToDouble(float_1);
		double num2 = num * num;
		num = array[1] - Convert.ToDouble(float_2);
		double num3 = num2 + num * num;
		num = array[2] - Convert.ToDouble(float_3);
		return Math.Sqrt(num3 + num * num);
	}

	public override int GetHashCode()
	{
		int num = 17;
		num = 629 + GetHashCode(X);
		return 37 * num + GetHashCode(Y);
	}

	public static int GetHashCode(double x)
	{
		long num = BitConverter.DoubleToInt64Bits(x);
		return (int)(num ^ (num >> 32));
	}

	public static CoordinateF operator +(CoordinateF coord1, Coordinate coord2)
	{
		return new CoordinateF(coord1.X + Convert.ToSingle(coord2.X), coord1.Y + Convert.ToSingle(coord2.Y), coord1.Z + Convert.ToSingle(coord2.Z));
	}

	public static CoordinateF operator +(CoordinateF coord1, float d)
	{
		return new CoordinateF(coord1.X + d, coord1.Y + d, coord1.Z + d);
	}

	public static CoordinateF operator +(float d, CoordinateF coord1)
	{
		return coord1 + d;
	}

	public static CoordinateF operator *(CoordinateF coord1, Coordinate coord2)
	{
		return new CoordinateF(coord1.X * Convert.ToSingle(coord2.X), coord1.Y * Convert.ToSingle(coord2.Y), coord1.Z * Convert.ToSingle(coord2.Z));
	}

	public static CoordinateF operator *(CoordinateF coord1, float d)
	{
		return new CoordinateF(coord1.X * d, coord1.Y * d, coord1.Z * d);
	}

	public static CoordinateF operator *(float d, CoordinateF coord1)
	{
		return coord1 * d;
	}

	public static CoordinateF operator -(CoordinateF coord1, Coordinate coord2)
	{
		return new CoordinateF(coord1.X - Convert.ToSingle(coord2.X), coord1.Y - Convert.ToSingle(coord2.Y), coord1.Z - Convert.ToSingle(coord2.Z));
	}

	public static CoordinateF operator -(CoordinateF coord1, float d)
	{
		return new CoordinateF(coord1.X - d, coord1.Y - d, coord1.Z - d);
	}

	public static CoordinateF operator -(float d, CoordinateF coord1)
	{
		return coord1 - d;
	}

	public static CoordinateF operator /(CoordinateF coord1, Coordinate coord2)
	{
		return new CoordinateF(coord1.X / Convert.ToSingle(coord2.X), coord1.Y / Convert.ToSingle(coord2.Y), coord1.Z / Convert.ToSingle(coord2.Z));
	}

	public static CoordinateF operator /(CoordinateF coord1, float d)
	{
		return new CoordinateF(coord1.X / d, coord1.Y / d, coord1.Z / d);
	}

	public static CoordinateF operator /(float d, CoordinateF coord1)
	{
		return coord1 / d;
	}

	public double[] ToArray()
	{
		return new double[3]
		{
			Convert.ToSingle(float_1),
			Convert.ToSingle(float_2),
			Convert.ToSingle(float_3)
		};
	}

	static CoordinateF()
	{
		Class72.smethod_20();
	}
}
