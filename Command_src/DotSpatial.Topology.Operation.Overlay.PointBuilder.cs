using System.Collections;
using DotSpatial.Topology.GeometriesGraph;

namespace DotSpatial.Topology.Operation.Overlay;

public class PointBuilder
{
	private readonly IGeometryFactory igeometryFactory_0;

	private readonly OverlayOp overlayOp_0;

	public PointBuilder(OverlayOp op, IGeometryFactory geometryFactory)
	{
		overlayOp_0 = op;
		igeometryFactory_0 = geometryFactory;
	}

	public virtual IList Build(SpatialFunction opCode)
	{
		IList ienumerable_ = method_0(opCode);
		return method_1(ienumerable_);
	}

	private IList method_0(SpatialFunction spatialFunction_0)
	{
		IList list = new ArrayList();
		IEnumerator enumerator = overlayOp_0.Graph.Nodes.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Node node = (Node)enumerator.Current;
			if (!node.IsInResult && OverlayOp.IsResultOfOp(node.Label, spatialFunction_0))
			{
				list.Add(node);
			}
		}
		return list;
	}

	private IList method_1(IEnumerable ienumerable_0)
	{
		IList list = new ArrayList();
		IEnumerator enumerator = ienumerable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Coordinate coordinate = ((Node)enumerator.Current).Coordinate;
			if (!overlayOp_0.IsCoveredByLa(coordinate))
			{
				IPoint value = igeometryFactory_0.CreatePoint(coordinate);
				list.Add(value);
			}
		}
		return list;
	}

	static PointBuilder()
	{
		Class72.smethod_20();
	}
}
