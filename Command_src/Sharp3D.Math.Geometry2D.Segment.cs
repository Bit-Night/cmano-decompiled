using System;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using Sharp3D.Math.Core;

namespace Sharp3D.Math.Geometry2D;

[Serializable]
[TypeConverter(typeof(SegmentConverter))]
public struct Segment : ICloneable
{
	private Vector2D vector2D_0;

	private Vector2D vector2D_1;

	public Vector2D P0
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

	public Vector2D P1
	{
		get
		{
			return vector2D_1;
		}
		set
		{
			vector2D_1 = value;
		}
	}

	public Segment(Vector2D p0, Vector2D p1)
	{
		vector2D_0 = p0;
		vector2D_1 = p1;
	}

	public Segment(Segment segment)
	{
		vector2D_0 = segment.P0;
		vector2D_1 = segment.P1;
	}

	public void Transform(Transform2D transf)
	{
		vector2D_0 = transf.transform(vector2D_0);
		vector2D_1 = transf.transform(vector2D_1);
	}

	object ICloneable.Clone()
	{
		return new Segment(this);
	}

	public Segment Clone()
	{
		return new Segment(this);
	}

	public static Segment Parse(string value)
	{
		Match match = new Regex("\\((?<p0>\\([^\\)]*\\)), (?<p1>\\([^\\)]*\\))\\)", RegexOptions.None).Match(value);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		return new Segment(Vector2D.Parse(match.Result("${p0}")), Vector2D.Parse(match.Result("${p1}")));
	}

	public override int GetHashCode()
	{
		return vector2D_0.GetHashCode() ^ vector2D_1.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (!(obj is Segment segment))
		{
			return false;
		}
		if (!(vector2D_0 == segment.vector2D_0))
		{
			return false;
		}
		return vector2D_1 == segment.vector2D_1;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "Segment(P0={0}, P1={1})", vector2D_0, vector2D_1);
	}

	public static bool operator ==(Segment left, Segment right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(Segment left, Segment right)
	{
		return !object.Equals(left, right);
	}

	static Segment()
	{
		Class72.smethod_20();
	}
}
