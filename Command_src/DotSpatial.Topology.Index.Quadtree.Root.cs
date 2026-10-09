using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Index.Quadtree;

public class Root : NodeBase
{
	private static readonly Coordinate coordinate_0;

	public virtual void Insert(IEnvelope itemEnv, object item)
	{
		int subnodeIndex = NodeBase.GetSubnodeIndex(itemEnv, coordinate_0);
		if (subnodeIndex == -1)
		{
			Add(item);
			return;
		}
		Node node = base.Nodes[subnodeIndex];
		if (node == null || !node.Envelope.Contains(itemEnv))
		{
			Node node2 = Node.CreateExpanded(node, itemEnv);
			base.Nodes[subnodeIndex] = node2;
		}
		smethod_0(base.Nodes[subnodeIndex], itemEnv, item);
	}

	private static void smethod_0(Node node_1, IEnvelope ienvelope_0, object object_0)
	{
		Assert.IsTrue(node_1.Envelope.Contains(ienvelope_0));
		NodeBase nodeBase = ((IntervalSize.IsZeroWidth(ienvelope_0.Minimum.X, ienvelope_0.Maximum.X) | IntervalSize.IsZeroWidth(ienvelope_0.Minimum.X, ienvelope_0.Maximum.X)) ? node_1.Find(ienvelope_0) : node_1.GetNode(ienvelope_0));
		nodeBase.Add(object_0);
	}

	protected override bool IsSearchMatch(IEnvelope searchEnv)
	{
		return true;
	}

	static Root()
	{
		Class72.smethod_20();
		coordinate_0 = new Coordinate(0.0, 0.0);
	}
}
