using System;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using Sharp3D.Math.Core;

namespace Sharp3D.Math.Geometry2D;

[Serializable]
[TypeConverter(typeof(CircleConverter))]
public struct Circle : ICloneable
{
	private Vector2F vector2F_0;

	private float float_0;

	public static readonly Circle UnitCircle;

	public Vector2F Center
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

	public float Radius
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

	public Circle(Vector2F center, float radius)
	{
		vector2F_0 = center;
		float_0 = radius;
	}

	public Circle(Circle circle)
	{
		vector2F_0 = circle.vector2F_0;
		float_0 = circle.float_0;
	}

	object ICloneable.Clone()
	{
		return new Circle(this);
	}

	public Circle Clone()
	{
		return new Circle(this);
	}

	public static Circle Parse(string s)
	{
		Match match = new Regex("Circle\\(Center=(?<center>\\([^\\)]*\\)), Radius=(?<radius>.*)\\)", RegexOptions.None).Match(s);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		return new Circle(Vector2F.Parse(match.Result("${center}")), float.Parse(match.Result("${radius}")));
	}

	public override int GetHashCode()
	{
		return vector2F_0.GetHashCode() ^ float_0.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is Circle circle)
		{
			if (!(vector2F_0 == circle.vector2F_0))
			{
				return false;
			}
			return float_0 == circle.float_0;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "({0}, {1})", vector2F_0, float_0);
	}

	public float GetArea()
	{
		return (float)System.Math.PI * float_0 * float_0;
	}

	static Circle()
	{
		Class72.smethod_20();
		UnitCircle = new Circle(new Vector2F(0f, 0f), 1f);
	}
}
