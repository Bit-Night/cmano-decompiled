using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using CSMaterial;
using Sharp3D.Math.Core;

namespace Sharp3D.Math.Geometry2D;

[Serializable]
[TypeConverter(typeof(SegmentConverter))]
public struct Arc : ICloneable
{
	private Vector2D vector2D_0;

	private double double_0;

	private double double_1;

	private double double_2;

	public Vector2D Center
	{
		get
		{
			return vector2D_0;
		}
		set
		{
			vector2D_0 = value;
		}
	}

	public double Radius
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	public double Angle0
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	public double Angle1
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	public Vector2D P0 => PointAtAngle(double_1);

	public Vector2D P1 => PointAtAngle(double_2);

	public Arc(Vector2D pCenter, float radius, float angle0, float angle1)
	{
		vector2D_0 = pCenter;
		double_0 = radius;
		double_1 = angle0;
		double_2 = angle1;
	}

	public Arc(Arc arc)
	{
		vector2D_0 = arc.vector2D_0;
		double_0 = arc.double_0;
		double_1 = arc.double_1;
		double_2 = arc.double_2;
	}

	public void Transform(Transform2D transf)
	{
		Vector2D p = transf.transform(P0);
		Vector2D p2 = transf.transform(P1);
		vector2D_0 = transf.transform(vector2D_0);
		double_1 = AngleAtPoint(p);
		double_2 = AngleAtPoint(p2);
	}

	public Vector2D PointAtAngle(double angle)
	{
		double num = angle * CSMath.PI_dividedBy_180;
		return vector2D_0 + double_0 * new Vector2D(System.Math.Cos(num), System.Math.Sin(num));
	}

	public double AngleAtPoint(Vector2D p)
	{
		Vector2D vector2D = p - vector2D_0;
		if (vector2D.X > 0.0)
		{
			return -180.0 * (System.Math.Asin(vector2D.Y / vector2D.GetLength()) / System.Math.PI);
		}
		if (vector2D.Y > 0.0)
		{
			return 180.0 * ((System.Math.PI + System.Math.Asin(vector2D.Y / vector2D.GetLength())) / System.Math.PI);
		}
		return 180.0 * ((System.Math.PI - System.Math.Acos((0.0 - vector2D.Y) / vector2D.GetLength())) / System.Math.PI);
	}

	public List<Segment> Explode(int iStepNumber)
	{
		List<Segment> list = new List<Segment>();
		double num = (double_2 - double_1) / (double)iStepNumber;
		for (int i = 0; i < iStepNumber; i++)
		{
			list.Add(new Segment(PointAtAngle(double_1 + (double)i * num), PointAtAngle(double_1 + (double)(i + 1) * num)));
		}
		return list;
	}

	object ICloneable.Clone()
	{
		return new Arc(this);
	}

	public Arc Clone()
	{
		return new Arc(this);
	}

	public static Arc Parse(string value)
	{
		Match match = new Regex("\\((?<pC>\\([^\\)]*\\)), (?<r>\\([^\\)]*\\)), (?<a0>\\([^\\)]*\\)), ((?<a1>\\([^\\)]*\\))\\)", RegexOptions.None).Match(value);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		return new Arc(Vector2D.Parse(match.Result("${pC}")), float.Parse(match.Result("${r}")), float.Parse(match.Result("${a0}")), float.Parse(match.Result("${a1}")));
	}

	public override int GetHashCode()
	{
		return vector2D_0.GetHashCode() ^ double_0.GetHashCode() ^ double_1.GetHashCode() ^ double_2.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (!(obj is Arc arc))
		{
			return false;
		}
		int result;
		if (!(vector2D_0 == arc.vector2D_0))
		{
			result = 0;
		}
		else
		{
			if (double_0 == arc.double_0 && double_1 == arc.double_1)
			{
				return double_2 == arc.double_2;
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "Arc(Center={0}, Radius={1}, Angle0={2}, Angle1={3})", vector2D_0, double_1, double_2);
	}

	public static bool operator ==(Arc left, Arc right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(Arc left, Arc right)
	{
		return !object.Equals(left, right);
	}

	static Arc()
	{
		Class72.smethod_20();
	}
}
