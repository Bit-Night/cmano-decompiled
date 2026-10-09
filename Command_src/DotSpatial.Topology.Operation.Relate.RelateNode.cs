using DotSpatial.Topology.GeometriesGraph;

namespace DotSpatial.Topology.Operation.Relate;

public class RelateNode : Node
{
	public RelateNode(Coordinate coord, EdgeEndStar edges)
		: base(coord, edges)
	{
	}

	public override void ComputeIm(IntersectionMatrix im)
	{
		im.SetAtLeastIfValid(Label.GetLocation(0), Label.GetLocation(1), DimensionType.Point);
	}

	public virtual void UpdateImFromEdges(IntersectionMatrix im)
	{
		((EdgeEndBundleStar)Edges).UpdateIm(im);
	}

	static RelateNode()
	{
		Class72.smethod_20();
	}
}
