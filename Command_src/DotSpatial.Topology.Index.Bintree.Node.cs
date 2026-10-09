using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Index.Bintree;

public class Node : NodeBase
{
	private readonly double double_0;

	private readonly Interval interval_0;

	private readonly int int_0;

	public virtual Interval Interval => interval_0;

	public Node(Interval interval, int level)
	{
		interval_0 = interval;
		int_0 = level;
		double_0 = (interval.Min + interval.Max) / 2.0;
	}

	public static Node CreateNode(Interval itemInterval)
	{
		Key key = new Key(itemInterval);
		return new Node(key.Interval, key.Level);
	}

	public static Node CreateExpanded(Node node, Interval addInterval)
	{
		Interval interval = new Interval(addInterval);
		if (node != null)
		{
			interval.ExpandToInclude(node.interval_0);
		}
		Node node2 = CreateNode(interval);
		if (node != null)
		{
			node2.Insert(node);
		}
		return node2;
	}

	protected override bool IsSearchMatch(Interval itemInterval)
	{
		return itemInterval.Overlaps(interval_0);
	}

	public virtual Node GetNode(Interval searchInterval)
	{
		int subnodeIndex = NodeBase.GetSubnodeIndex(searchInterval, double_0);
		if (subnodeIndex != -1)
		{
			return method_0(subnodeIndex).GetNode(searchInterval);
		}
		return this;
	}

	public virtual NodeBase Find(Interval searchInterval)
	{
		int subnodeIndex = NodeBase.GetSubnodeIndex(searchInterval, double_0);
		if (subnodeIndex == -1)
		{
			return this;
		}
		if (Nodes[subnodeIndex] != null)
		{
			return Nodes[subnodeIndex].Find(searchInterval);
		}
		return this;
	}

	public virtual void Insert(Node node)
	{
		Assert.IsTrue(interval_0 == null || interval_0.Contains(node.Interval));
		int subnodeIndex = NodeBase.GetSubnodeIndex(node.interval_0, double_0);
		if (node.int_0 == int_0 - 1)
		{
			Nodes[subnodeIndex] = node;
			return;
		}
		Node node2 = method_1(subnodeIndex);
		node2.Insert(node);
		Nodes[subnodeIndex] = node2;
	}

	private Node method_0(int int_1)
	{
		if (Nodes[int_1] == null)
		{
			Nodes[int_1] = method_1(int_1);
		}
		return Nodes[int_1];
	}

	private Node method_1(int int_1)
	{
		double min = 0.0;
		double max = 0.0;
		switch (int_1)
		{
		case 0:
			min = interval_0.Min;
			max = double_0;
			break;
		case 1:
			min = double_0;
			max = interval_0.Max;
			break;
		}
		return new Node(new Interval(min, max), int_0 - 1);
	}

	static Node()
	{
		Class72.smethod_20();
	}
}
