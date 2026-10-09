using System;

namespace DotSpatial.Topology.Voronoi;

public class VoronoiEdge
{
	internal bool Done;

	public Vector2 LeftData;

	public Vector2 RightData;

	public Vector2 VVertexA = Fortune.VVUnkown;

	public Vector2 VVertexB = Fortune.VVUnkown;

	public bool IsInfinite
	{
		get
		{
			if (!(VVertexA == Fortune.vector2_0))
			{
				return false;
			}
			return VVertexB == Fortune.vector2_0;
		}
	}

	public bool IsPartlyInfinite
	{
		get
		{
			if (VVertexA == Fortune.vector2_0)
			{
				return true;
			}
			return VVertexB == Fortune.vector2_0;
		}
	}

	public Vector2 FixedPoint
	{
		get
		{
			if (!IsInfinite)
			{
				if (!(VVertexA != Fortune.vector2_0))
				{
					return VVertexB;
				}
				return VVertexA;
			}
			return (LeftData + RightData) * 0.5;
		}
	}

	public Vector2 DirectionVector
	{
		get
		{
			if (!IsPartlyInfinite)
			{
				return (VVertexB - VVertexA) * (1.0 / VVertexA.Distance(VVertexB));
			}
			if (LeftData.X == RightData.X)
			{
				if (LeftData.Y < RightData.Y)
				{
					return new Vector2(-1.0, 0.0);
				}
				return new Vector2(1.0, 0.0);
			}
			Vector2 vector = new Vector2((0.0 - (RightData.Y - LeftData.Y)) / (RightData.X - LeftData.X), 1.0);
			if (RightData.X < LeftData.X)
			{
				vector *= -1.0;
			}
			return vector * (1.0 / Math.Sqrt(vector.SquaredLength));
		}
	}

	public double Length
	{
		get
		{
			if (!IsPartlyInfinite)
			{
				return VVertexA.Distance(VVertexB);
			}
			return double.PositiveInfinity;
		}
	}

	public void AddVertex(Vector2 v)
	{
		if (VVertexA == Fortune.VVUnkown)
		{
			VVertexA = v;
			return;
		}
		if (!(VVertexB == Fortune.VVUnkown))
		{
			throw new Exception("Tried to add third vertex!");
		}
		VVertexB = v;
	}

	static VoronoiEdge()
	{
		Class72.smethod_20();
	}
}
