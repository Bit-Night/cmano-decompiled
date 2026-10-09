using System.Collections;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.GeometriesGraph;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Operation.Overlay;

public class PolygonBuilder
{
	private readonly IGeometryFactory igeometryFactory_0;

	private readonly IList ilist_0 = new ArrayList();

	public virtual IList Polygons => method_1(ilist_0);

	public PolygonBuilder(IGeometryFactory geometryFactory)
	{
		igeometryFactory_0 = geometryFactory;
	}

	public virtual void Add(PlanarGraph graph)
	{
		Add(graph.EdgeEnds, graph.NodeValues);
	}

	public virtual void Add(IList dirEdges, IList nodes)
	{
		PlanarGraph.LinkResultDirectedEdges(nodes);
		IList ienumerable_ = method_0(dirEdges);
		IList list = new ArrayList();
		smethod_3(smethod_0(ienumerable_, ilist_0, list), ilist_0, list);
		smethod_4(ilist_0, list);
	}

	private IList method_0(IEnumerable ienumerable_0)
	{
		IList list = new ArrayList();
		IEnumerator enumerator = ienumerable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			DirectedEdge directedEdge = (DirectedEdge)enumerator.Current;
			if (directedEdge.IsInResult && directedEdge.Label.IsArea() && directedEdge.EdgeRing == null)
			{
				MaximalEdgeRing maximalEdgeRing = new MaximalEdgeRing(directedEdge, igeometryFactory_0);
				list.Add(maximalEdgeRing);
				maximalEdgeRing.SetInResult();
			}
		}
		return list;
	}

	private static IList smethod_0(IEnumerable ienumerable_0, IList ilist_1, IList ilist_2)
	{
		IList list = new ArrayList();
		IEnumerator enumerator = ienumerable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			MaximalEdgeRing maximalEdgeRing = (MaximalEdgeRing)enumerator.Current;
			if (maximalEdgeRing.MaxNodeDegree > 2)
			{
				maximalEdgeRing.LinkDirectedEdgesForMinimalEdgeRings();
				IList list2 = maximalEdgeRing.BuildMinimalRings();
				EdgeRing edgeRing = smethod_1(list2);
				if (edgeRing != null)
				{
					smethod_2(edgeRing, list2);
					ilist_1.Add(edgeRing);
					continue;
				}
				foreach (object item in list2)
				{
					ilist_2.Add(item);
				}
			}
			else
			{
				list.Add(maximalEdgeRing);
			}
		}
		return list;
	}

	private static EdgeRing smethod_1(IEnumerable ienumerable_0)
	{
		int num = 0;
		EdgeRing result = null;
		IEnumerator enumerator = ienumerable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			EdgeRing edgeRing = (MinimalEdgeRing)enumerator.Current;
			if (!edgeRing.IsHole)
			{
				result = edgeRing;
				num++;
			}
		}
		Assert.IsTrue(num <= 1, "found two shells in MinimalEdgeRing list");
		return result;
	}

	private static void smethod_2(EdgeRing edgeRing_0, IEnumerable ienumerable_0)
	{
		IEnumerator enumerator = ienumerable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			MinimalEdgeRing minimalEdgeRing = (MinimalEdgeRing)enumerator.Current;
			if (minimalEdgeRing.IsHole)
			{
				minimalEdgeRing.Shell = edgeRing_0;
			}
		}
	}

	private static void smethod_3(IEnumerable ienumerable_0, IList ilist_1, IList ilist_2)
	{
		IEnumerator enumerator = ienumerable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			EdgeRing edgeRing = (EdgeRing)enumerator.Current;
			edgeRing.SetInResult();
			if (edgeRing.IsHole)
			{
				ilist_2.Add(edgeRing);
			}
			else
			{
				ilist_1.Add(edgeRing);
			}
		}
	}

	private static void smethod_4(IEnumerable ienumerable_0, IEnumerable ienumerable_1)
	{
		IEnumerator enumerator = ienumerable_1.GetEnumerator();
		while (enumerator.MoveNext())
		{
			EdgeRing edgeRing = (EdgeRing)enumerator.Current;
			if (edgeRing.Shell == null)
			{
				EdgeRing edgeRing2 = smethod_5(edgeRing, ienumerable_0);
				Assert.IsTrue(edgeRing2 != null, "unable to assign hole to a shell");
				edgeRing.Shell = edgeRing2;
			}
		}
	}

	private static EdgeRing smethod_5(EdgeRing edgeRing_0, IEnumerable ienumerable_0)
	{
		ILinearRing linearRing = edgeRing_0.LinearRing;
		IEnvelope envelopeInternal = linearRing.EnvelopeInternal;
		Coordinate p = linearRing.Coordinates[0];
		EdgeRing edgeRing = null;
		IEnvelope envelope = null;
		IEnumerator enumerator = ienumerable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			EdgeRing edgeRing2 = (EdgeRing)enumerator.Current;
			ILinearRing linearRing2 = edgeRing2.LinearRing;
			IEnvelope envelopeInternal2 = linearRing2.EnvelopeInternal;
			int num;
			if (edgeRing != null)
			{
				envelope = edgeRing.LinearRing.EnvelopeInternal;
				num = 0;
			}
			else
			{
				num = 0;
			}
			bool flag = (byte)num != 0;
			if (envelopeInternal2.Contains(envelopeInternal) && CgAlgorithms.IsPointInRing(p, linearRing2.Coordinates))
			{
				flag = true;
			}
			if (flag && (edgeRing == null || envelope.Contains(envelopeInternal2)))
			{
				edgeRing = edgeRing2;
			}
		}
		return edgeRing;
	}

	private IList method_1(IEnumerable ienumerable_0)
	{
		IList list = new ArrayList();
		IEnumerator enumerator = ienumerable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			IPolygon value = ((EdgeRing)enumerator.Current).ToPolygon(igeometryFactory_0);
			list.Add(value);
		}
		return list;
	}

	public virtual bool ContainsPoint(Coordinate p)
	{
		IEnumerator enumerator = ilist_0.GetEnumerator();
		do
		{
			if (!enumerator.MoveNext())
			{
				return false;
			}
		}
		while (!((EdgeRing)enumerator.Current).ContainsPoint(p));
		return true;
	}

	static PolygonBuilder()
	{
		Class72.smethod_20();
	}
}
