using System.Collections.Generic;
using System.IO;
using System.Text;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.GeometriesGraph.Index;

namespace DotSpatial.Topology.GeometriesGraph;

public class Edge : GraphComponent
{
	private readonly Depth depth_0 = new Depth();

	private readonly EdgeIntersectionList edgeIntersectionList_0;

	private int int_0;

	private Envelope envelope_0;

	private bool bool_4 = true;

	private MonotoneChainEdge monotoneChainEdge_0;

	private string string_0;

	private IList<Coordinate> ilist_0;

	public virtual IList<Coordinate> Points
	{
		get
		{
			return ilist_0;
		}
		set
		{
			ilist_0 = value;
		}
	}

	public virtual int NumPoints => ilist_0.Count;

	public virtual string Name
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public virtual IList<Coordinate> Coordinates => ilist_0;

	public override Coordinate Coordinate
	{
		get
		{
			if (Points.Count <= 0)
			{
				return Coordinate.Empty;
			}
			return Points[0];
		}
		set
		{
			if (Points.Count > 0)
			{
				Points[0] = value;
			}
		}
	}

	public virtual Envelope Envelope
	{
		get
		{
			if (envelope_0 == null)
			{
				envelope_0 = new Envelope();
				for (int i = 0; i < Points.Count; i++)
				{
					envelope_0.ExpandToInclude(Points[i]);
				}
			}
			return envelope_0;
		}
	}

	public virtual Depth Depth => depth_0;

	public virtual int DepthDelta
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public virtual int MaximumSegmentIndex => Points.Count - 1;

	public virtual EdgeIntersectionList EdgeIntersectionList => edgeIntersectionList_0;

	public virtual MonotoneChainEdge MonotoneChainEdge
	{
		get
		{
			if (monotoneChainEdge_0 == null)
			{
				monotoneChainEdge_0 = new MonotoneChainEdge(this);
			}
			return monotoneChainEdge_0;
		}
	}

	public virtual bool IsClosed => Points[0].Equals(Points[Points.Count - 1]);

	public virtual bool IsCollapsed
	{
		get
		{
			if (Label.IsArea())
			{
				if (Points.Count != 3)
				{
					return false;
				}
				if (!Points[0].Equals(Points[2]))
				{
					return false;
				}
				return true;
			}
			return false;
		}
	}

	public virtual Edge CollapsedEdge => new Edge(new Coordinate[2]
	{
		Points[0],
		Points[1]
	}, Label.ToLineLabel(Label));

	public virtual bool Isolated
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	public override bool IsIsolated => bool_4;

	public Edge(IList<Coordinate> pts, Label label)
	{
		edgeIntersectionList_0 = new EdgeIntersectionList(this);
		ilist_0 = pts;
		base.Label = label;
	}

	public Edge(IList<Coordinate> pts)
		: this(pts, null)
	{
	}

	public static void UpdateIm(Label label, IntersectionMatrix im)
	{
		im.SetAtLeastIfValid(label.GetLocation(0, PositionType.On), label.GetLocation(1, PositionType.On), DimensionType.Curve);
		if (label.IsArea())
		{
			im.SetAtLeastIfValid(label.GetLocation(0, PositionType.Left), label.GetLocation(1, PositionType.Left), DimensionType.Surface);
			im.SetAtLeastIfValid(label.GetLocation(0, PositionType.Right), label.GetLocation(1, PositionType.Right), DimensionType.Surface);
		}
	}

	public virtual Coordinate GetCoordinate(int i)
	{
		return Points[i];
	}

	public virtual void AddIntersections(LineIntersector li, int segmentIndex, int geomIndex)
	{
		for (int i = 0; i < li.IntersectionNum; i++)
		{
			AddIntersection(li, segmentIndex, geomIndex, i);
		}
	}

	public virtual void AddIntersection(LineIntersector li, int segmentIndex, int geomIndex, int intIndex)
	{
		Coordinate coordinate = new Coordinate(li.GetIntersection(intIndex));
		int num = segmentIndex;
		double dist = li.GetEdgeDistance(geomIndex, intIndex);
		int num2 = num + 1;
		if (num2 < Points.Count)
		{
			Coordinate b = Points[num2];
			if (coordinate.Equals2D(b))
			{
				num = num2;
				dist = 0.0;
			}
			EdgeIntersectionList.Add(coordinate, num, dist);
		}
	}

	public override void ComputeIm(IntersectionMatrix im)
	{
		UpdateIm(Label, im);
	}

	public override bool Equals(object o)
	{
		if (o == null)
		{
			return false;
		}
		if (o is Edge)
		{
			return Equals(o as Edge);
		}
		return false;
	}

	protected virtual bool Equals(Edge e)
	{
		if (Points.Count != e.Points.Count)
		{
			return false;
		}
		bool flag = true;
		bool flag2 = true;
		int num = Points.Count;
		int num2 = 0;
		while (true)
		{
			if (num2 < Points.Count)
			{
				if (!Points[num2].Equals2D(e.Points[num2]))
				{
					flag = false;
				}
				if (!Points[num2].Equals2D(e.Points[--num]))
				{
					flag2 = false;
				}
				if (!flag && !flag2)
				{
					break;
				}
				num2++;
				continue;
			}
			return true;
		}
		return false;
	}

	public static bool operator ==(Edge obj1, Edge obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(Edge obj1, Edge obj2)
	{
		return !(obj1 == obj2);
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public virtual bool IsPointwiseEqual(Edge e)
	{
		if (Points.Count != e.Points.Count)
		{
			return false;
		}
		for (int i = 0; i < Points.Count; i++)
		{
			if (!Points[i].Equals2D(e.Points[i]))
			{
				return false;
			}
		}
		return true;
	}

	public virtual void Write(StreamWriter outstream)
	{
		outstream.Write("edge " + string_0 + ": ");
		outstream.Write("LINESTRING (");
		for (int i = 0; i < Points.Count; i++)
		{
			if (i > 0)
			{
				outstream.Write(",");
			}
			outstream.Write(Points[i].X + " " + Points[i].Y);
		}
		outstream.Write(")  " + Label?.ToString() + " " + int_0);
	}

	public virtual void WriteReverse(StreamWriter outstream)
	{
		outstream.Write("edge " + string_0 + ": ");
		for (int num = Points.Count - 1; num >= 0; num--)
		{
			outstream.Write(((object)Points[num])?.ToString() + " ");
		}
		outstream.WriteLine(string.Empty);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("edge " + string_0 + ": ");
		stringBuilder.Append("LINESTRING (");
		for (int i = 0; i < Points.Count; i++)
		{
			if (i > 0)
			{
				stringBuilder.Append(",");
			}
			stringBuilder.Append(Points[i].X + " " + Points[i].Y);
		}
		stringBuilder.Append(")  " + Label?.ToString() + " " + int_0);
		return stringBuilder.ToString();
	}

	static Edge()
	{
		Class72.smethod_20();
	}
}
