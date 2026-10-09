using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Index.Quadtree;

public class Node : NodeBase
{
	private readonly Coordinate coordinate_0;

	private readonly IEnvelope ienvelope_0;

	private readonly int int_0;

	public virtual IEnvelope Envelope => ienvelope_0;

	public Node(IEnvelope env, int level)
	{
		ienvelope_0 = env;
		int_0 = level;
		coordinate_0 = new Coordinate();
		coordinate_0.X = (env.Minimum.X + env.Maximum.X) / 2.0;
		coordinate_0.Y = (env.Minimum.Y + env.Maximum.Y) / 2.0;
	}

	public static Node CreateNode(IEnvelope env)
	{
		Key key = new Key(env);
		return new Node(key.Envelope, key.Level);
	}

	public static Node CreateExpanded(Node node, IEnvelope addEnv)
	{
		Envelope envelope = new Envelope(addEnv);
		if (node != null)
		{
			envelope.ExpandToInclude(node.ienvelope_0);
		}
		Node node2 = CreateNode(envelope);
		if (node != null)
		{
			node2.InsertNode(node);
		}
		return node2;
	}

	protected override bool IsSearchMatch(IEnvelope searchEnv)
	{
		return ienvelope_0.Intersects(searchEnv);
	}

	public virtual Node GetNode(IEnvelope searchEnv)
	{
		int subnodeIndex = NodeBase.GetSubnodeIndex(searchEnv, coordinate_0);
		if (subnodeIndex != -1)
		{
			return method_1(subnodeIndex).GetNode(searchEnv);
		}
		return this;
	}

	public virtual NodeBase Find(IEnvelope searchEnv)
	{
		int subnodeIndex = NodeBase.GetSubnodeIndex(searchEnv, coordinate_0);
		if (subnodeIndex == -1)
		{
			return this;
		}
		if (base.Nodes[subnodeIndex] == null)
		{
			return this;
		}
		return base.Nodes[subnodeIndex].Find(searchEnv);
	}

	public virtual void InsertNode(Node node)
	{
		Assert.IsTrue(ienvelope_0 == null || ienvelope_0.Contains(node.Envelope));
		int subnodeIndex = NodeBase.GetSubnodeIndex(node.ienvelope_0, coordinate_0);
		if (node.int_0 == int_0 - 1)
		{
			base.Nodes[subnodeIndex] = node;
			return;
		}
		Node node2 = method_2(subnodeIndex);
		node2.InsertNode(node);
		base.Nodes[subnodeIndex] = node2;
	}

	private Node method_1(int int_1)
	{
		if (base.Nodes[int_1] == null)
		{
			base.Nodes[int_1] = method_2(int_1);
		}
		return base.Nodes[int_1];
	}

	private Node method_2(int int_1)
	{
		double x = 0.0;
		double x2 = 0.0;
		double y = 0.0;
		double y2 = 0.0;
		switch (int_1)
		{
		case 0:
			x = ienvelope_0.Minimum.X;
			x2 = coordinate_0.X;
			y = ienvelope_0.Minimum.Y;
			y2 = coordinate_0.Y;
			break;
		case 1:
			x = coordinate_0.X;
			x2 = ienvelope_0.Maximum.X;
			y = ienvelope_0.Minimum.Y;
			y2 = coordinate_0.Y;
			break;
		case 2:
			x = ienvelope_0.Minimum.X;
			x2 = coordinate_0.X;
			y = coordinate_0.Y;
			y2 = ienvelope_0.Maximum.Y;
			break;
		case 3:
			x = coordinate_0.X;
			x2 = ienvelope_0.Maximum.X;
			y = coordinate_0.Y;
			y2 = ienvelope_0.Maximum.Y;
			break;
		}
		return new Node(new Envelope(x, x2, y, y2), int_0 - 1);
	}

	static Node()
	{
		Class72.smethod_20();
	}
}
