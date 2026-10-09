using System;
using Sharp3D.Math.Core;

namespace Sharp3D.Math.Geometry2D;

public sealed class Intersection2D
{
	public enum IntersectionType
	{
		I2D_NONE,
		I2D_POINT,
		I2D_SEGMENT,
		I2D_ARC
	}

	private IntersectionType intersectionType_0;

	private Vector2D vector2D_0;

	private Segment segment_0;

	public IntersectionType Type => intersectionType_0;

	public object Result => intersectionType_0 switch
	{
		IntersectionType.I2D_NONE => throw new Exception("No intersection!"), 
		IntersectionType.I2D_POINT => vector2D_0, 
		IntersectionType.I2D_SEGMENT => segment_0, 
		_ => throw new NotImplementedException(), 
	};

	public Intersection2D()
	{
		intersectionType_0 = IntersectionType.I2D_NONE;
	}

	public Intersection2D(Vector2D vec)
	{
		intersectionType_0 = IntersectionType.I2D_POINT;
		vector2D_0 = vec;
	}

	public Intersection2D(Segment seg)
	{
		intersectionType_0 = IntersectionType.I2D_SEGMENT;
		segment_0 = seg;
	}

	static Intersection2D()
	{
		Class72.smethod_20();
	}
}
