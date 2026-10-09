using System;
using System.Collections;
using DotSpatial.Topology.Algorithm;

namespace DotSpatial.Topology.GeometriesGraph.Index;

public class SegmentIntersector
{
	private readonly bool bool_0;

	private readonly LineIntersector lineIntersector_0;

	private readonly bool bool_1;

	public int NumTests;

	private ICollection[] icollection_0;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private int int_0;

	private Coordinate coordinate_0;

	public virtual Coordinate ProperIntersectionPoint => coordinate_0;

	public virtual bool HasIntersection => bool_2;

	public virtual bool HasProperIntersection => bool_3;

	public virtual bool HasProperInteriorIntersection => bool_4;

	public SegmentIntersector(LineIntersector li, bool includeProper, bool recordIsolated)
	{
		lineIntersector_0 = li;
		bool_0 = includeProper;
		bool_1 = recordIsolated;
	}

	public static bool IsAdjacentSegments(int i1, int i2)
	{
		return Math.Abs(i1 - i2) == 1;
	}

	public virtual void SetBoundaryNodes(ICollection bdyNodes0, ICollection bdyNodes1)
	{
		icollection_0 = new ICollection[2];
		icollection_0[0] = bdyNodes0;
		icollection_0[1] = bdyNodes1;
	}

	private bool method_0(Edge edge_0, int int_1, Edge edge_1, int int_2)
	{
		if ((object)edge_0 != edge_1 || lineIntersector_0.IntersectionNum != 1)
		{
			goto IL_004a;
		}
		int result;
		if (!IsAdjacentSegments(int_1, int_2))
		{
			if (!edge_0.IsClosed)
			{
				result = 0;
				goto IL_004b;
			}
			int num = edge_0.NumPoints - 1;
			int result2;
			if (int_1 == 0 && int_2 == num)
			{
				result2 = 1;
			}
			else
			{
				if (int_2 != 0 || int_1 != num)
				{
					goto IL_004a;
				}
				result2 = 1;
			}
			return (byte)result2 != 0;
		}
		return true;
		IL_004b:
		return (byte)result != 0;
		IL_004a:
		result = 0;
		goto IL_004b;
	}

	public virtual void AddIntersections(Edge e0, int segIndex0, Edge e1, int segIndex1)
	{
		if ((object)e0 == e1 && segIndex0 == segIndex1)
		{
			return;
		}
		NumTests++;
		Coordinate p = e0.Coordinates[segIndex0];
		Coordinate p2 = e0.Coordinates[segIndex0 + 1];
		Coordinate p3 = e1.Coordinates[segIndex1];
		Coordinate p4 = e1.Coordinates[segIndex1 + 1];
		lineIntersector_0.ComputeIntersection(p, p2, p3, p4);
		if (!lineIntersector_0.HasIntersection)
		{
			return;
		}
		if (bool_1)
		{
			e0.Isolated = false;
			e1.Isolated = false;
		}
		int_0++;
		if (method_0(e0, segIndex0, e1, segIndex1))
		{
			return;
		}
		bool_2 = true;
		if (bool_0 || !lineIntersector_0.IsProper)
		{
			e0.AddIntersections(lineIntersector_0, segIndex0, 0);
			e1.AddIntersections(lineIntersector_0, segIndex1, 1);
		}
		if (lineIntersector_0.IsProper)
		{
			coordinate_0 = (Coordinate)lineIntersector_0.GetIntersection(0).Clone();
			bool_3 = true;
			if (!smethod_0(lineIntersector_0, icollection_0))
			{
				bool_4 = true;
			}
		}
	}

	private static bool smethod_0(LineIntersector lineIntersector_1, object object_0)
	{
		if (object_0 == null)
		{
			return false;
		}
		if (smethod_1(lineIntersector_1, (IEnumerable)((object[])object_0)[0]))
		{
			return true;
		}
		if (!smethod_1(lineIntersector_1, (IEnumerable)((object[])object_0)[1]))
		{
			return false;
		}
		return true;
	}

	private static bool smethod_1(LineIntersector lineIntersector_1, IEnumerable ienumerable_0)
	{
		IEnumerator enumerator = ienumerable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Coordinate coordinate = ((Node)enumerator.Current).Coordinate;
			if (lineIntersector_1.IsIntersection(coordinate))
			{
				return true;
			}
		}
		return false;
	}

	static SegmentIntersector()
	{
		Class72.smethod_20();
	}
}
