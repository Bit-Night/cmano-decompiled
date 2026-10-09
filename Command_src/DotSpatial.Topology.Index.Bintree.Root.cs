using DotSpatial.Topology.Index.Quadtree;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Index.Bintree;

public class Root : NodeBase
{
	public virtual void Insert(Interval itemInterval, object item)
	{
		int subnodeIndex = NodeBase.GetSubnodeIndex(itemInterval, 0.0);
		if (subnodeIndex == -1)
		{
			Add(item);
			return;
		}
		Node node = Nodes[subnodeIndex];
		if (node == null || !node.Interval.Contains(itemInterval))
		{
			Node node2 = Node.CreateExpanded(node, itemInterval);
			Nodes[subnodeIndex] = node2;
		}
		smethod_0(Nodes[subnodeIndex], itemInterval, item);
	}

	private static void smethod_0(Node node_1, Interval interval_0, object object_0)
	{
		Assert.IsTrue(node_1.Interval.Contains(interval_0));
		NodeBase nodeBase = (IntervalSize.IsZeroWidth(interval_0.Min, interval_0.Max) ? node_1.Find(interval_0) : node_1.GetNode(interval_0));
		nodeBase.Add(object_0);
	}

	protected override bool IsSearchMatch(Interval interval)
	{
		return true;
	}

	static Root()
	{
		Class72.smethod_20();
	}
}
