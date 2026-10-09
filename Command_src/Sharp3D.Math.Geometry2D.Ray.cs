using System;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using Sharp3D.Math.Core;

namespace Sharp3D.Math.Geometry2D;

[Serializable]
[TypeConverter(typeof(RayConverter))]
public struct Ray : ICloneable
{
	private Vector2D vector2D_0;

	private Vector2D vector2D_1;

	public Vector2D Origin
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

	public Vector2D Direction
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

	public Ray(Vector2D origin, Vector2D direction)
	{
		vector2D_0 = origin;
		vector2D_1 = direction;
	}

	public Ray(Ray ray)
	{
		vector2D_0 = ray.Origin;
		vector2D_1 = ray.Direction;
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
		Match match = new Regex("Ray\\(Origin=(?<origin>\\([^\\)]*\\)), Direction=(?<direction>\\([^\\)]*\\))\\)", RegexOptions.None).Match(s);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		return new Ray(Vector2D.Parse(match.Result("${origin}")), Vector2D.Parse(match.Result("${direction}")));
	}

	public Vector2D GetPointOnRay(double t)
	{
		return Origin + Direction * t;
	}

	public override int GetHashCode()
	{
		return vector2D_0.GetHashCode() ^ vector2D_1.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (!(obj is Ray ray))
		{
			return false;
		}
		if (vector2D_0 == ray.Origin)
		{
			return vector2D_1 == ray.Direction;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "Ray(Origin={0}, Direction={1})", vector2D_0, vector2D_1);
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
