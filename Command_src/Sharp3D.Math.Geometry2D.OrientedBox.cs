using System;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using Sharp3D.Math.Core;

namespace Sharp3D.Math.Geometry2D;

[Serializable]
[TypeConverter(typeof(OrientedBoxConverter))]
public struct OrientedBox : ICloneable
{
	private Vector2F vector2F_0;

	private Vector2F vector2F_1;

	private Vector2F vector2F_2;

	private float float_0;

	private float float_1;

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

	public Vector2F Axis1
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

	public Vector2F Axis2
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

	public float Extent1
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

	public float Extent2
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

	public OrientedBox(Vector2F center, Vector2F axis1, Vector2F axis2, float extent1, float extent2)
	{
		vector2F_0 = center;
		vector2F_1 = axis1;
		vector2F_2 = axis2;
		float_0 = extent1;
		float_1 = extent2;
	}

	public OrientedBox(Vector2F center, Vector2F[] axes, float[] extents)
	{
		vector2F_0 = center;
		vector2F_1 = axes[0];
		vector2F_2 = axes[1];
		float_0 = extents[0];
		float_1 = extents[1];
	}

	public OrientedBox(OrientedBox box)
	{
		vector2F_0 = box.Center;
		vector2F_1 = box.Axis1;
		vector2F_2 = box.Axis2;
		float_0 = box.Extent1;
		float_1 = box.Extent2;
	}

	object ICloneable.Clone()
	{
		return new OrientedBox(this);
	}

	public OrientedBox Clone()
	{
		return new OrientedBox(this);
	}

	public static OrientedBox Parse(string s)
	{
		Match match = new Regex("OrientedBox\\(Center=(?<center>\\([^\\)]*\\)), Axis1=(?<axis1>\\([^\\)]*\\)), Axis2=(?<axis2>\\([^\\)]*\\)), Extent1=(?<extent1>.*), Extent2=(?<extent2>.*)\\)", RegexOptions.None).Match(s);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		return new OrientedBox(Vector2F.Parse(match.Result("${center}")), Vector2F.Parse(match.Result("${axis1}")), Vector2F.Parse(match.Result("${axis2}")), float.Parse(match.Result("${extent1}")), float.Parse(match.Result("${extent2}")));
	}

	public Vector2F[] ComputeVertices()
	{
		Vector2F[] array = new Vector2F[4];
		Vector2F[] array2 = new Vector2F[2]
		{
			Axis1 * Extent1,
			Axis2 * Extent2
		};
		array[0] = Center - array2[0] - array2[1];
		array[1] = Center + array2[0] - array2[1];
		array[2] = Center + array2[0] + array2[1];
		array[3] = Center - array2[0] + array2[1];
		return array;
	}

	public override int GetHashCode()
	{
		return vector2F_0.GetHashCode() ^ vector2F_1.GetHashCode() ^ vector2F_2.GetHashCode() ^ float_0.GetHashCode() ^ float_1.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (!(obj is OrientedBox orientedBox))
		{
			return false;
		}
		int result;
		if (!(vector2F_0 == orientedBox.Center))
		{
			result = 0;
		}
		else
		{
			if (vector2F_1 == orientedBox.Axis1 && vector2F_2 == orientedBox.Axis2 && float_0 == orientedBox.Extent1)
			{
				return float_1 == orientedBox.Extent2;
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "OrientedBox(Center={0}, Axis1={1}, Axis2={2}, Extent1={3}, Extent2={4})", Center, Axis1, Axis2, Extent1, Extent2);
	}

	public static bool operator ==(OrientedBox left, OrientedBox right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(OrientedBox left, OrientedBox right)
	{
		return object.Equals(left, right);
	}

	static OrientedBox()
	{
		Class72.smethod_20();
	}
}
