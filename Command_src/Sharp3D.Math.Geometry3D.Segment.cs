using System;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using Sharp3D.Math.Core;

namespace Sharp3D.Math.Geometry3D;

[Serializable]
[TypeConverter(typeof(SegmentConverter))]
public struct Segment : ICloneable
{
	private Vector3F vector3F_0;

	private Vector3F vector3F_1;

	public Vector3F P0
	{
		get
		{
			return vector3F_0;
		}
		set
		{
			vector3F_0 = value;
		}
	}

	public Vector3F P1
	{
		get
		{
			return vector3F_1;
		}
		set
		{
			vector3F_1 = value;
		}
	}

	public Segment(Vector3F p0, Vector3F p1)
	{
		vector3F_0 = p0;
		vector3F_1 = p1;
	}

	public Segment(Segment segment)
	{
		vector3F_0 = segment.P0;
		vector3F_1 = segment.P1;
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
		return new Segment(Vector3F.Parse(match.Result("${p0}")), Vector3F.Parse(match.Result("${p1}")));
	}

	public override int GetHashCode()
	{
		return vector3F_0.GetHashCode() ^ vector3F_1.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is Segment segment)
		{
			if (vector3F_0 == segment.P0)
			{
				return vector3F_1 == segment.P1;
			}
			return false;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "Segment(P0={0}, P1={1})", vector3F_0, vector3F_1);
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
