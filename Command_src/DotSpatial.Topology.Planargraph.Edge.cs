using System.Runtime.CompilerServices;

namespace DotSpatial.Topology.Planargraph;

public class Edge : GraphComponent
{
	[CompilerGenerated]
	private DirectedEdge[] directedEdge_0;

	protected DirectedEdge[] DirEdge
	{
		[CompilerGenerated]
		get
		{
			return directedEdge_0;
		}
		[CompilerGenerated]
		set
		{
			directedEdge_0 = value;
		}
	}

	public override bool IsRemoved => DirEdge == null;

	public new bool IsVisited
	{
		get
		{
			return base.IsVisited;
		}
		set
		{
			base.IsVisited = value;
		}
	}

	public Edge()
	{
	}

	public Edge(DirectedEdge de0, DirectedEdge de1)
	{
		SetDirectedEdges(de0, de1);
	}

	public void SetDirectedEdges(DirectedEdge de0, DirectedEdge de1)
	{
		DirEdge = new DirectedEdge[2] { de0, de1 };
		de0.Edge = this;
		de1.Edge = this;
		de0.Sym = de1;
		de1.Sym = de0;
		de0.FromNode.AddOutEdge(de0);
		de1.FromNode.AddOutEdge(de1);
	}

	public virtual DirectedEdge GetDirEdge(int i)
	{
		return DirEdge[i];
	}

	public virtual DirectedEdge GetDirEdge(Node fromNode)
	{
		if (DirEdge[0].FromNode == fromNode)
		{
			return DirEdge[0];
		}
		if (DirEdge[1].FromNode == fromNode)
		{
			return DirEdge[1];
		}
		return null;
	}

	public virtual Node GetOppositeNode(Node node)
	{
		if (DirEdge[0].FromNode == node)
		{
			return DirEdge[0].ToNode;
		}
		if (DirEdge[1].FromNode == node)
		{
			return DirEdge[1].ToNode;
		}
		return null;
	}

	internal void Remove()
	{
		DirEdge = null;
	}

	static Edge()
	{
		Class72.smethod_20();
	}
}
