using System;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using Sharp3D.Math.Core;

namespace Sharp3D.Math.Geometry2D;

[Serializable]
[TypeConverter(typeof(TriangleConverter))]
public struct Triangle : ICloneable
{
	private Vector2F vector2F_0;

	private Vector2F vector2F_1;

	private Vector2F vector2F_2;

	public Vector2F Point0
	{
		get
		{
			return vector2F_0;
		}
		set
		{
			vector2F_0 = value;
		}
	}

	public Vector2F Point1
	{
		get
		{
			return vector2F_1;
		}
		set
		{
			vector2F_1 = value;
		}
	}

	public Vector2F Point2
	{
		get
		{
			return vector2F_2;
		}
		set
		{
			vector2F_2 = value;
		}
	}

	public Ordering Ordering
	{
		get
		{
			float determinant = new Matrix3F(1f, 1f, 1f, vector2F_0.X, vector2F_1.X, vector2F_2.X, vector2F_0.Y, vector2F_1.Y, vector2F_2.Y).GetDeterminant();
			if (determinant > 0f)
			{
				return Ordering.Counterclockwise;
			}
			if (determinant < 0f)
			{
				return Ordering.Clockwise;
			}
			return Ordering.None;
		}
	}

	public Vector2F this[int index]
	{
		get
		{
			return index switch
			{
				0 => vector2F_0, 
				1 => vector2F_1, 
				2 => vector2F_2, 
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
				vector2F_0 = value;
				break;
			case 1:
				vector2F_1 = value;
				break;
			case 2:
				vector2F_2 = value;
				break;
			}
		}
	}

	public Triangle(Vector2F p0, Vector2F p1, Vector2F p2)
	{
		vector2F_0 = p0;
		vector2F_1 = p1;
		vector2F_2 = p2;
	}

	public Triangle(Triangle triangle)
	{
		vector2F_0 = triangle.vector2F_0;
		vector2F_1 = triangle.vector2F_1;
		vector2F_2 = triangle.vector2F_2;
	}

	object ICloneable.Clone()
	{
		return new Triangle(this);
	}

	public Triangle Clone()
	{
		return new Triangle(this);
	}

	public static Triangle Parse(string value)
	{
		Match match = new Regex("\\((?<p1>\\([^\\)]*\\)), (?<p2>\\([^\\)]*\\)), (?<p3>\\([^\\)]*\\))\\)", RegexOptions.None).Match(value);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		return new Triangle(Vector2F.Parse(match.Result("${p1}")), Vector2F.Parse(match.Result("${p2}")), Vector2F.Parse(match.Result("${p3}")));
	}

	public override int GetHashCode()
	{
		return vector2F_0.GetHashCode() ^ vector2F_1.GetHashCode() ^ vector2F_2.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is Triangle triangle)
		{
			int result;
			if (vector2F_0 == triangle.vector2F_0)
			{
				if (vector2F_1 == triangle.vector2F_1)
				{
					return vector2F_2 == triangle.vector2F_2;
				}
				result = 0;
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "({0}, {1}, {2})", vector2F_0, vector2F_1, vector2F_2);
	}

	public Vector2F FromBarycentric(float u, float v)
	{
		return (1f - u - v) * vector2F_0 + u * vector2F_1 + v * vector2F_2;
	}

	public float GetArea()
	{
		return 0.5f * ((vector2F_1.X - vector2F_0.X) * (vector2F_2.Y - vector2F_0.Y)) - (vector2F_2.X - vector2F_0.X) * (vector2F_1.Y - vector2F_0.Y);
	}

	public static bool operator ==(Triangle left, Triangle right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(Triangle left, Triangle right)
	{
		return !object.Equals(left, right);
	}

	static Triangle()
	{
		Class72.smethod_20();
	}
}
