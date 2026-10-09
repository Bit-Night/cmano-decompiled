using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using Sharp3D.Math.Core;

namespace Sharp3D.Math.Geometry2D;

[Serializable]
[TypeConverter(typeof(ExpandableObjectConverter))]
internal class Polygon : ICloneable
{
	private List<Vector2F> list_0 = new List<Vector2F>();

	[XmlArrayItem(Type = typeof(Vector2F))]
	public List<Vector2F> Points => list_0;

	public int Count => list_0.Count;

	public Polygon()
	{
	}

	public Polygon(Vector2F[] points)
	{
		list_0.AddRange(points);
	}

	public Polygon(List<Vector2F> points)
	{
		list_0.AddRange(points);
	}

	public Polygon(Polygon polygon)
	{
		list_0.AddRange(polygon.list_0);
	}

	object ICloneable.Clone()
	{
		return new Polygon(this);
	}

	public Polygon Clone()
	{
		return new Polygon(this);
	}

	public void Flip()
	{
		list_0.Reverse();
	}

	static Polygon()
	{
		Class72.smethod_20();
	}
}
