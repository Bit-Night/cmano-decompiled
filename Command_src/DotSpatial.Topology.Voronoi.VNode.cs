using System;
using System.Runtime.CompilerServices;

namespace DotSpatial.Topology.Voronoi;

internal abstract class VNode
{
	private VNode vnode_0;

	private VNode vnode_1;

	private VNode vnode_2;

	private VNode Left
	{
		get
		{
			return vnode_0;
		}
		set
		{
			vnode_0 = value;
			value.method_1(this);
		}
	}

	private VNode Right
	{
		get
		{
			return vnode_2;
		}
		set
		{
			vnode_2 = value;
			value.method_1(this);
		}
	}

	[SpecialName]
	private VNode method_0()
	{
		return vnode_1;
	}

	[SpecialName]
	private void method_1(VNode vnode_3)
	{
		vnode_1 = vnode_3;
	}

	private void method_2(VNode vnode_3, VNode vnode_4)
	{
		if (Left == vnode_3)
		{
			Left = vnode_4;
		}
		else
		{
			if (Right != vnode_3)
			{
				throw new Exception("Child not found!");
			}
			Right = vnode_4;
		}
		vnode_3.method_1(null);
	}

	private static VDataNode smethod_0(VNode vnode_3)
	{
		VNode vNode = vnode_3;
		while (true)
		{
			if (vNode.method_0() != null)
			{
				if (vNode.method_0().Left != vNode)
				{
					break;
				}
				vNode = vNode.method_0();
				continue;
			}
			return null;
		}
		vNode = vNode.method_0();
		vNode = vNode.Left;
		while (vNode.Right != null)
		{
			vNode = vNode.Right;
		}
		return (VDataNode)vNode;
	}

	private static VDataNode smethod_1(VNode vnode_3)
	{
		VNode vNode = vnode_3;
		while (true)
		{
			if (vNode.method_0() != null)
			{
				if (vNode.method_0().Right != vNode)
				{
					break;
				}
				vNode = vNode.method_0();
				continue;
			}
			return null;
		}
		vNode = vNode.method_0();
		vNode = vNode.Right;
		while (vNode.Left != null)
		{
			vNode = vNode.Left;
		}
		return (VDataNode)vNode;
	}

	private static VEdgeNode smethod_2(VNode vnode_3)
	{
		VNode vNode = vnode_3;
		while (true)
		{
			if (vNode.method_0() != null)
			{
				if (vNode.method_0().Right != vNode)
				{
					break;
				}
				vNode = vNode.method_0();
				continue;
			}
			throw new Exception("No Left Leaf found!");
		}
		vNode = vNode.method_0();
		return (VEdgeNode)vNode;
	}

	private static VDataNode smethod_3(VNode vnode_3, double double_0, double double_1)
	{
		VNode vNode = vnode_3;
		while (!(vNode is VDataNode))
		{
			vNode = ((!(((VEdgeNode)vNode).Cut(double_0, double_1) < 0.0)) ? vNode.Right : vNode.Left);
		}
		return (VDataNode)vNode;
	}

	public static VNode ProcessDataEvent(VDataEvent e, VNode root, VoronoiGraph vg, double ys, out VDataNode[] circleCheckList)
	{
		if (root == null)
		{
			root = new VDataNode(e.DataPoint);
			circleCheckList = new VDataNode[1] { (VDataNode)root };
			return root;
		}
		VNode vNode = smethod_3(root, ys, e.DataPoint.X);
		VoronoiEdge voronoiEdge = new VoronoiEdge();
		voronoiEdge.LeftData = ((VDataNode)vNode).DataPoint;
		voronoiEdge.RightData = e.DataPoint;
		voronoiEdge.VVertexA = Fortune.VVUnkown;
		voronoiEdge.VVertexB = Fortune.VVUnkown;
		vg.Edges.Add(voronoiEdge);
		VNode vNode2;
		if (Math.Abs(voronoiEdge.LeftData.Y - voronoiEdge.RightData.Y) < 1E-10)
		{
			if (voronoiEdge.LeftData.X < voronoiEdge.RightData.X)
			{
				vNode2 = new VEdgeNode(voronoiEdge, flipped: false);
				vNode2.Left = new VDataNode(voronoiEdge.LeftData);
				vNode2.Right = new VDataNode(voronoiEdge.RightData);
			}
			else
			{
				vNode2 = new VEdgeNode(voronoiEdge, flipped: true);
				vNode2.Left = new VDataNode(voronoiEdge.RightData);
				vNode2.Right = new VDataNode(voronoiEdge.LeftData);
			}
			circleCheckList = new VDataNode[2]
			{
				(VDataNode)vNode2.Left,
				(VDataNode)vNode2.Right
			};
		}
		else
		{
			vNode2 = new VEdgeNode(voronoiEdge, flipped: false);
			vNode2.Left = new VDataNode(voronoiEdge.LeftData);
			vNode2.Right = new VEdgeNode(voronoiEdge, flipped: true);
			vNode2.Right.Left = new VDataNode(voronoiEdge.RightData);
			vNode2.Right.Right = new VDataNode(voronoiEdge.LeftData);
			circleCheckList = new VDataNode[3]
			{
				(VDataNode)vNode2.Left,
				(VDataNode)vNode2.Right.Left,
				(VDataNode)vNode2.Right.Right
			};
		}
		if (vNode.method_0() != null)
		{
			vNode.method_0().method_2(vNode, vNode2);
			return root;
		}
		return vNode2;
	}

	public static VNode ProcessCircleEvent(VCircleEvent e, VNode root, VoronoiGraph vg, out VDataNode[] circleCheckList)
	{
		VDataNode nodeN = e.NodeN;
		VDataNode vDataNode = smethod_0(nodeN);
		VDataNode vDataNode2 = smethod_1(nodeN);
		if (vDataNode != null && nodeN.method_0() != null && vDataNode2 != null && vDataNode.DataPoint.Equals(e.NodeL.DataPoint) && vDataNode2.DataPoint.Equals(e.NodeR.DataPoint))
		{
			VEdgeNode vEdgeNode = (VEdgeNode)nodeN.method_0();
			circleCheckList = new VDataNode[2] { vDataNode, vDataNode2 };
			Vector2 vector = new Vector2(e.Center.X, e.Center.Y);
			vg.Vertices.Add(vector);
			VEdgeNode vEdgeNode2;
			if (vEdgeNode.Left == nodeN)
			{
				vEdgeNode2 = smethod_2(vDataNode);
				vEdgeNode.method_0().method_2(vEdgeNode, vEdgeNode.Right);
			}
			else
			{
				vEdgeNode2 = smethod_2(nodeN);
				vEdgeNode.method_0().method_2(vEdgeNode, vEdgeNode.Left);
			}
			vEdgeNode.Edge.AddVertex(vector);
			vEdgeNode2.Edge.AddVertex(vector);
			VoronoiEdge voronoiEdge = new VoronoiEdge();
			voronoiEdge.LeftData = vDataNode.DataPoint;
			voronoiEdge.RightData = vDataNode2.DataPoint;
			voronoiEdge.AddVertex(vector);
			vg.Edges.Add(voronoiEdge);
			VEdgeNode vEdgeNode3 = new VEdgeNode(voronoiEdge, flipped: false);
			vEdgeNode3.Left = vEdgeNode2.Left;
			vEdgeNode3.Right = vEdgeNode2.Right;
			if (vEdgeNode2.method_0() == null)
			{
				return vEdgeNode3;
			}
			vEdgeNode2.method_0().method_2(vEdgeNode2, vEdgeNode3);
			return root;
		}
		circleCheckList = new VDataNode[0];
		return root;
	}

	public static VCircleEvent CircleCheckDataNode(VDataNode n, double ys)
	{
		VDataNode vDataNode = smethod_0(n);
		VDataNode vDataNode2 = smethod_1(n);
		if (vDataNode != null && vDataNode2 != null && !(vDataNode.DataPoint == vDataNode2.DataPoint) && !(vDataNode.DataPoint == n.DataPoint) && !(n.DataPoint == vDataNode2.DataPoint))
		{
			if (MathTools.Ccw(vDataNode.DataPoint.X, vDataNode.DataPoint.Y, n.DataPoint.X, n.DataPoint.Y, vDataNode2.DataPoint.X, vDataNode2.DataPoint.Y, plusOneOnZeroDegrees: false) <= 0)
			{
				return null;
			}
			Vector2 center = Fortune.CircumCircleCenter(vDataNode.DataPoint, n.DataPoint, vDataNode2.DataPoint);
			VCircleEvent vCircleEvent = new VCircleEvent();
			vCircleEvent.NodeN = n;
			vCircleEvent.NodeL = vDataNode;
			vCircleEvent.NodeR = vDataNode2;
			vCircleEvent.Center = center;
			vCircleEvent.Valid = true;
			if (vCircleEvent.Y < ys)
			{
				return null;
			}
			return vCircleEvent;
		}
		return null;
	}

	public static void CleanUpTree(VNode root)
	{
		if (root is VDataNode)
		{
			return;
		}
		if (root is VEdgeNode vEdgeNode)
		{
			while (vEdgeNode.Edge.VVertexB == Fortune.VVUnkown)
			{
				vEdgeNode.Edge.AddVertex(Fortune.vector2_0);
			}
			if (vEdgeNode.Flipped)
			{
				Vector2 leftData = vEdgeNode.Edge.LeftData;
				vEdgeNode.Edge.LeftData = vEdgeNode.Edge.RightData;
				vEdgeNode.Edge.RightData = leftData;
			}
			vEdgeNode.Edge.Done = true;
		}
		CleanUpTree(root.Left);
		CleanUpTree(root.Right);
	}

	static VNode()
	{
		Class72.smethod_20();
	}
}
