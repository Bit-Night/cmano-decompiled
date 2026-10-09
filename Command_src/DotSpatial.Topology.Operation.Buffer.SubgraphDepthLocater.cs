using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.GeometriesGraph;

namespace DotSpatial.Topology.Operation.Buffer;

public class SubgraphDepthLocater
{
	private class Class54 : IComparable
	{
		private readonly int int_0;

		private readonly LineSegment iiKeImeQwsT;

		public Class54(ILineSegmentBase ilineSegmentBase_0, int int_1)
		{
			iiKeImeQwsT = new LineSegment(ilineSegmentBase_0);
			int_0 = int_1;
		}

		[SpecialName]
		public int method_0()
		{
			return int_0;
		}

		public int CompareTo(object obj)
		{
			Class54 @class = (Class54)obj;
			int num = iiKeImeQwsT.OrientationIndex(@class.iiKeImeQwsT);
			if (num == 0)
			{
				num = -1 * @class.iiKeImeQwsT.OrientationIndex(iiKeImeQwsT);
			}
			if (num == 0)
			{
				return smethod_0(iiKeImeQwsT, @class.iiKeImeQwsT);
			}
			return num;
		}

		private static int smethod_0(ILineSegmentBase ilineSegmentBase_0, ILineSegmentBase ilineSegmentBase_1)
		{
			int num = ilineSegmentBase_0.P0.CompareTo(ilineSegmentBase_1.P0);
			if (num == 0)
			{
				return ilineSegmentBase_0.P1.CompareTo(ilineSegmentBase_1.P1);
			}
			return num;
		}

		static Class54()
		{
			Class72.smethod_20();
		}
	}

	private readonly LineSegment lineSegment_0 = new LineSegment();

	private readonly IList ilist_0;

	public SubgraphDepthLocater(IList subgraphs)
	{
		ilist_0 = subgraphs;
	}

	public virtual int GetDepth(Coordinate p)
	{
		ArrayList arrayList = new ArrayList(method_0(p));
		if (arrayList.Count != 0)
		{
			arrayList.Sort();
			return ((Class54)arrayList[0]).method_0();
		}
		return 0;
	}

	private IList method_0(Coordinate coordinate_0)
	{
		IList list = new ArrayList();
		IEnumerator enumerator = ilist_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			BufferSubgraph bufferSubgraph = (BufferSubgraph)enumerator.Current;
			method_1(coordinate_0, bufferSubgraph.DirectedEdges, list);
		}
		return list;
	}

	private void method_1(Coordinate coordinate_0, IEnumerable ienumerable_0, IList ilist_1)
	{
		IEnumerator enumerator = ienumerable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			DirectedEdge directedEdge = (DirectedEdge)enumerator.Current;
			if (directedEdge.IsForward)
			{
				method_2(coordinate_0, directedEdge, ilist_1);
			}
		}
	}

	private void method_2(Coordinate coordinate_0, DirectedEdge directedEdge_0, IList ilist_1)
	{
		IList<Coordinate> coordinates = directedEdge_0.Edge.Coordinates;
		for (int i = 0; i < coordinates.Count - 1; i++)
		{
			lineSegment_0.P0 = coordinates[i];
			lineSegment_0.P1 = coordinates[i + 1];
			if (lineSegment_0.P0.Y > lineSegment_0.P1.Y)
			{
				lineSegment_0.Reverse();
			}
			if (!(Math.Max(lineSegment_0.P0.X, lineSegment_0.P1.X) < coordinate_0.X) && !lineSegment_0.IsHorizontal && !(coordinate_0.Y < lineSegment_0.P0.Y) && !(coordinate_0.Y > lineSegment_0.P1.Y) && CgAlgorithms.ComputeOrientation(lineSegment_0.P0, lineSegment_0.P1, coordinate_0) != -1)
			{
				int depth = directedEdge_0.GetDepth(PositionType.Left);
				if (!lineSegment_0.P0.Equals(coordinates[i]))
				{
					depth = directedEdge_0.GetDepth(PositionType.Right);
				}
				Class54 value = new Class54(lineSegment_0, depth);
				ilist_1.Add(value);
			}
		}
	}

	static SubgraphDepthLocater()
	{
		Class72.smethod_20();
	}
}
