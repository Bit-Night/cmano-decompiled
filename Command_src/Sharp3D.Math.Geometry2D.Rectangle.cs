using System;
using System.Globalization;
using Sharp3D.Math.Core;

namespace Sharp3D.Math.Geometry2D;

[Serializable]
public struct Rectangle : ICloneable
{
	private Vector2D vector2D_0;

	private Vector2D vector2D_1;

	public Segment[] Segments
	{
		get
		{
			Vector2D vector2D = new Vector2D(vector2D_0);
			Vector2D vector2D2 = new Vector2D(vector2D_0 + vector2D_1.X * Vector2D.XAxis);
			Vector2D vector2D3 = new Vector2D(vector2D_0 + vector2D_1);
			Vector2D vector2D4 = new Vector2D(vector2D_0 + vector2D_1.Y * Vector2D.YAxis);
			return new Segment[4]
			{
				new Segment(vector2D, vector2D2),
				new Segment(vector2D2, vector2D3),
				new Segment(vector2D3, vector2D4),
				new Segment(vector2D4, vector2D)
			};
		}
	}

	public Vector2D Origin => vector2D_0;

	public Vector2D Dimensions => vector2D_1;

	public Rectangle(Vector2D ptOrigin, Vector2D dimensions)
	{
		vector2D_0 = ptOrigin;
		vector2D_1 = dimensions;
	}

	public Rectangle(Rectangle r)
	{
		vector2D_0 = r.vector2D_0;
		vector2D_1 = r.vector2D_1;
	}

	object ICloneable.Clone()
	{
		return new Rectangle(this);
	}

	public Rectangle Clone()
	{
		return new Rectangle(this);
	}

	public override int GetHashCode()
	{
		return vector2D_0.GetHashCode() ^ vector2D_1.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is Rectangle rectangle)
		{
			if (!(vector2D_0 == rectangle.vector2D_0))
			{
				return false;
			}
			return vector2D_1 == rectangle.vector2D_1;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "Rectangle(Origin={0}, Dimensions={1})", vector2D_0, vector2D_1);
	}

	static Rectangle()
	{
		Class72.smethod_20();
	}
}
