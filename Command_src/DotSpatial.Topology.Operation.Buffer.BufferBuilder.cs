using System.Collections;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.GeometriesGraph;
using DotSpatial.Topology.Noding;
using DotSpatial.Topology.Operation.Overlay;

namespace DotSpatial.Topology.Operation.Buffer;

public class BufferBuilder
{
	private readonly EdgeList edgeList_0 = new EdgeList();

	private BufferStyle bufferStyle_0 = BufferStyle.CapRound;

	private IGeometryFactory igeometryFactory_0;

	private PlanarGraph planarGraph_0;

	private int int_0 = 8;

	private PrecisionModel precisionModel_0;

	public virtual int QuadrantSegments
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public virtual PrecisionModel WorkingPrecisionModel
	{
		get
		{
			return precisionModel_0;
		}
		set
		{
			precisionModel_0 = value;
		}
	}

	public virtual BufferStyle EndCapStyle
	{
		get
		{
			return bufferStyle_0;
		}
		set
		{
			bufferStyle_0 = value;
		}
	}

	private static int smethod_0(Label label_0)
	{
		LocationType location = label_0.GetLocation(0, PositionType.Left);
		LocationType location2 = label_0.GetLocation(0, PositionType.Right);
		if (location == LocationType.Interior && location2 == LocationType.Exterior)
		{
			return 1;
		}
		int result;
		if (location == LocationType.Exterior)
		{
			if (location2 == LocationType.Interior)
			{
				return -1;
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return result;
	}

	public IGeometry Buffer(IGeometry g, double distance)
	{
		PrecisionModel precisionModel = precisionModel_0 ?? new PrecisionModel(g.PrecisionModel);
		igeometryFactory_0 = g.Factory;
		OffsetCurveBuilder offsetCurveBuilder = new OffsetCurveBuilder(precisionModel, int_0);
		offsetCurveBuilder.EndCapStyle = bufferStyle_0;
		IList curves = new OffsetCurveSetBuilder(g, distance, offsetCurveBuilder).GetCurves();
		if (curves.Count > 0)
		{
			method_0(curves, precisionModel);
			planarGraph_0 = new PlanarGraph(new OverlayNodeFactory());
			planarGraph_0.AddEdges(edgeList_0.Edges);
			IList ienumerable_ = smethod_2(planarGraph_0);
			PolygonBuilder polygonBuilder = new PolygonBuilder(igeometryFactory_0);
			smethod_3(ienumerable_, polygonBuilder);
			IList polygons = polygonBuilder.Polygons;
			return igeometryFactory_0.BuildGeometry(polygons);
		}
		IGeometryFactory geometryFactory = igeometryFactory_0;
		IGeometry[] geometries = new Geometry[0];
		return geometryFactory.CreateGeometryCollection(geometries);
	}

	private static INoder smethod_1(PrecisionModel precisionModel_1)
	{
		return new McIndexNoder(new IntersectionAdder(new RobustLineIntersector
		{
			PrecisionModel = precisionModel_1
		}));
	}

	private void method_0(IList ilist_0, PrecisionModel precisionModel_1)
	{
		INoder noder = smethod_1(precisionModel_1);
		noder.ComputeNodes(ilist_0);
		foreach (SegmentString nodedSubstring in noder.GetNodedSubstrings())
		{
			Edge e = new Edge(label: new Label((Label)nodedSubstring.Data), pts: nodedSubstring.Coordinates);
			InsertEdge(e);
		}
	}

	protected void InsertEdge(Edge e)
	{
		Edge edge = edgeList_0.FindEqualEdge(e);
		if (!(edge != null))
		{
			edgeList_0.Add(e);
			e.DepthDelta = smethod_0(e.Label);
			return;
		}
		Label label = edge.Label;
		Label label2 = e.Label;
		if (!edge.IsPointwiseEqual(e))
		{
			label2 = new Label(e.Label);
			label2.Flip();
		}
		label.Merge(label2);
		int num = smethod_0(label2);
		int depthDelta = edge.DepthDelta + num;
		edge.DepthDelta = depthDelta;
	}

	private static IList smethod_2(PlanarGraph planarGraph_1)
	{
		ArrayList arrayList = new ArrayList();
		foreach (Node node in planarGraph_1.Nodes)
		{
			if (!node.IsVisited)
			{
				BufferSubgraph bufferSubgraph = new BufferSubgraph();
				bufferSubgraph.Create(node);
				arrayList.Add(bufferSubgraph);
			}
		}
		arrayList.Sort();
		arrayList.Reverse();
		return arrayList;
	}

	private static void smethod_3(IEnumerable ienumerable_0, PolygonBuilder polygonBuilder_0)
	{
		IList list = new ArrayList();
		foreach (BufferSubgraph item in ienumerable_0)
		{
			Coordinate rightMostCoordinate = item.RightMostCoordinate;
			int depth = new SubgraphDepthLocater(list).GetDepth(rightMostCoordinate);
			item.ComputeDepth(depth);
			item.FindResultEdges();
			list.Add(item);
			polygonBuilder_0.Add(item.DirectedEdges, item.Nodes);
		}
	}

	static BufferBuilder()
	{
		Class72.smethod_20();
	}
}
