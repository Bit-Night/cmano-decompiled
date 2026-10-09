using System;
using System.Collections;
using System.IO;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.GeometriesGraph;

namespace DotSpatial.Topology.Planargraph;

public class DirectedEdge : GraphComponent, IComparable
{
	private readonly double double_0;

	private readonly bool bool_2;

	private readonly Node node_0;

	private readonly Coordinate coordinate_0;

	private readonly Coordinate coordinate_1;

	private readonly int int_0;

	private readonly Node node_1;

	private Edge edge_0;

	private DirectedEdge directedEdge_0;

	public virtual Edge Edge
	{
		get
		{
			return edge_0;
		}
		set
		{
			edge_0 = value;
		}
	}

	public virtual int Quadrant => int_0;

	public virtual Coordinate StartPoint => coordinate_0;

	public virtual Coordinate EndPoint => coordinate_1;

	public virtual bool EdgeDirection => bool_2;

	public virtual Node FromNode => node_0;

	public virtual Node ToNode => node_1;

	public virtual Coordinate Coordinate => node_0.Coordinate;

	public virtual double Angle => double_0;

	public virtual DirectedEdge Sym
	{
		get
		{
			return directedEdge_0;
		}
		set
		{
			directedEdge_0 = value;
		}
	}

	public override bool IsRemoved => edge_0 == null;

	public DirectedEdge(Node inFrom, Node inTo, Coordinate directionPt, bool inEdgeDirection)
	{
		node_0 = inFrom;
		node_1 = inTo;
		bool_2 = inEdgeDirection;
		coordinate_0 = node_0.Coordinate;
		coordinate_1 = directionPt;
		double num = coordinate_1.X - coordinate_0.X;
		double num2 = coordinate_1.Y - coordinate_0.Y;
		int_0 = QuadrantOp.Quadrant(num, num2);
		double_0 = Math.Atan2(num2, num);
	}

	public virtual int CompareTo(object obj)
	{
		DirectedEdge e = (DirectedEdge)obj;
		return CompareDirection(e);
	}

	public static IList ToEdges(IList dirEdges)
	{
		IList list = new ArrayList();
		IEnumerator enumerator = dirEdges.GetEnumerator();
		while (enumerator.MoveNext())
		{
			list.Add(((DirectedEdge)enumerator.Current).Edge);
		}
		return list;
	}

	public virtual int CompareDirection(DirectedEdge e)
	{
		if (int_0 <= e.Quadrant)
		{
			if (int_0 < e.Quadrant)
			{
				return -1;
			}
			return CgAlgorithms.ComputeOrientation(e.StartPoint, e.EndPoint, coordinate_1);
		}
		return 1;
	}

	public virtual void Write(StreamWriter outstream)
	{
		string? fullName = GetType().FullName;
		int num = fullName.LastIndexOf('.');
		string text = fullName.Substring(num + 1);
		string[] obj = new string[10]
		{
			"  ",
			text,
			": ",
			((object)coordinate_0)?.ToString(),
			" - ",
			((object)coordinate_1)?.ToString(),
			" ",
			null,
			null,
			null
		};
		int num2 = int_0;
		obj[7] = num2.ToString();
		obj[8] = ":";
		double num3 = double_0;
		obj[9] = num3.ToString();
		outstream.Write(string.Concat(obj));
	}

	internal void Remove()
	{
		directedEdge_0 = null;
		edge_0 = null;
	}

	public override string ToString()
	{
		string[] obj = new string[8]
		{
			"DirectedEdge: ",
			((object)coordinate_0)?.ToString(),
			" - ",
			((object)coordinate_1)?.ToString(),
			" ",
			null,
			null,
			null
		};
		int num = int_0;
		obj[5] = num.ToString();
		obj[6] = ":";
		double num2 = double_0;
		obj[7] = num2.ToString();
		return string.Concat(obj);
	}

	static DirectedEdge()
	{
		Class72.smethod_20();
	}
}
