using System;
using System.IO;
using System.Text;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.GeometriesGraph;

public class EdgeEnd : IComparable
{
	private double double_0;

	private double double_1;

	private Edge edge_0;

	private Label label_0;

	private Node node_0;

	private Coordinate coordinate_0;

	private Coordinate coordinate_1;

	private int int_0;

	public virtual Edge Edge
	{
		get
		{
			return edge_0;
		}
		protected set
		{
			edge_0 = value;
		}
	}

	public virtual Label Label
	{
		get
		{
			return label_0;
		}
		protected set
		{
			label_0 = value;
		}
	}

	public virtual Coordinate Coordinate => coordinate_0;

	public virtual Coordinate DirectedCoordinate => coordinate_1;

	public virtual int Quadrant => int_0;

	public virtual double Dx => double_0;

	public virtual double Dy => double_1;

	public virtual Node Node
	{
		get
		{
			return node_0;
		}
		set
		{
			node_0 = value;
		}
	}

	protected EdgeEnd(Edge inEdge)
	{
		edge_0 = inEdge;
	}

	public EdgeEnd(Edge edge, Coordinate p0, Coordinate p1)
		: this(edge, p0, p1, null)
	{
	}

	public EdgeEnd(Edge edge, Coordinate p0, Coordinate p1, Label inLabel)
		: this(edge)
	{
		method_0(p0, p1);
		label_0 = inLabel;
	}

	public virtual int CompareTo(object obj)
	{
		EdgeEnd e = (EdgeEnd)obj;
		return CompareDirection(e);
	}

	private void method_0(Coordinate coordinate_2, Coordinate coordinate_3)
	{
		coordinate_0 = coordinate_2;
		coordinate_1 = coordinate_3;
		double_0 = coordinate_3.X - coordinate_2.X;
		double_1 = coordinate_3.Y - coordinate_2.Y;
		int_0 = QuadrantOp.Quadrant(double_0, double_1);
		Assert.IsTrue(double_0 != 0.0 || double_1 != 0.0, "EdgeEnd with identical endpoints found");
	}

	protected virtual void Init(Coordinate p0, Coordinate p1)
	{
		method_0(p0, p1);
	}

	public virtual int CompareDirection(EdgeEnd e)
	{
		if (double_0 == e.double_0 && double_1 == e.double_1)
		{
			return 0;
		}
		if (int_0 > e.int_0)
		{
			return 1;
		}
		if (int_0 < e.int_0)
		{
			return -1;
		}
		return CgAlgorithms.ComputeOrientation(e.coordinate_0, e.coordinate_1, coordinate_1);
	}

	public virtual void ComputeLabel()
	{
	}

	public virtual void Write(StreamWriter outstream)
	{
		double num = Math.Atan2(double_1, double_0);
		string? fullName = GetType().FullName;
		int num2 = fullName.LastIndexOf('.');
		string text = fullName.Substring(num2 + 1);
		outstream.Write("  " + text + ": " + ((object)coordinate_0)?.ToString() + " - " + ((object)coordinate_1)?.ToString() + " " + int_0 + ":" + num + "   " + Label);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append('[');
		stringBuilder.Append(coordinate_0.X);
		stringBuilder.Append(' ');
		stringBuilder.Append(coordinate_1.Y);
		stringBuilder.Append(']');
		return stringBuilder.ToString();
	}

	static EdgeEnd()
	{
		Class72.smethod_20();
	}
}
