using System;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using Sharp3D.Math.Core;

namespace Sharp3D.Math.Geometry3D;

[Serializable]
[TypeConverter(typeof(RayConverter))]
public struct Ray : ICloneable
{
	private Vector3F vector3F_0;

	private Vector3F vector3F_1;

	public Vector3F Origin
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

	public Vector3F Direction
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

	public Ray(Vector3F origin, Vector3F direction)
	{
		vector3F_0 = origin;
		vector3F_1 = direction;
	}

	public Ray(Ray ray)
	{
		vector3F_0 = ray.Origin;
		vector3F_1 = ray.Direction;
	}

	object ICloneable.Clone()
	{
		return new Ray(this);
	}

	public Ray Clone()
	{
		return new Ray(this);
	}

	public static Ray Parse(string s)
	{
		Match match = new Regex("\\((?<origin>\\([^\\)]*\\)), (?<direction>\\([^\\)]*\\))\\)", RegexOptions.None).Match(s);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		return new Ray(Vector3F.Parse(match.Result("${origin}")), Vector3F.Parse(match.Result("${direction}")));
	}

	public Vector3F GetPointOnRay(float t)
	{
		return Origin + Direction * t;
	}

	public override int GetHashCode()
	{
		return vector3F_0.GetHashCode() ^ vector3F_1.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is Ray ray)
		{
			if (!(vector3F_0 == ray.Origin))
			{
				return false;
			}
			return vector3F_1 == ray.Direction;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "({0}, {1})", vector3F_0, vector3F_1);
	}

	public static bool operator ==(Ray a, Ray b)
	{
		return object.Equals(a, b);
	}

	public static bool operator !=(Ray a, Ray b)
	{
		return !object.Equals(a, b);
	}

	static Ray()
	{
		Class72.smethod_20();
	}
}
