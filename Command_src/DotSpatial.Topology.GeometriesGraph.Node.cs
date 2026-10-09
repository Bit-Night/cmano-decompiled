using System.IO;

namespace DotSpatial.Topology.GeometriesGraph;

public class Node : GraphComponent
{
	private Coordinate coordinate_0;

	private EdgeEndStar edgeEndStar_0;

	public override Coordinate Coordinate
	{
		get
		{
			return coordinate_0;
		}
		set
		{
			coordinate_0 = value;
		}
	}

	public virtual EdgeEndStar Edges
	{
		get
		{
			return edgeEndStar_0;
		}
		protected set
		{
			edgeEndStar_0 = value;
		}
	}

	public override bool IsIsolated => Label.GeometryCount == 1;

	public Node(Coordinate coord, EdgeEndStar edges)
	{
		coordinate_0 = coord;
		edgeEndStar_0 = edges;
		base.Label = new Label(0, LocationType.Null);
	}

	public override void ComputeIm(IntersectionMatrix im)
	{
	}

	public virtual void Add(EdgeEnd e)
	{
		edgeEndStar_0.Insert(e);
		e.Node = this;
	}

	public virtual void MergeLabel(Node n)
	{
		MergeLabel(n.Label);
	}

	public virtual void MergeLabel(Label label2)
	{
		for (int i = 0; i < 2; i++)
		{
			LocationType location = ComputeMergedLocation(label2, i);
			if (Label.GetLocation(i) == LocationType.Null)
			{
				Label.SetLocation(i, location);
			}
		}
	}

	public virtual void SetLabel(int argIndex, LocationType onLocation)
	{
		if (Label != null)
		{
			Label.SetLocation(argIndex, onLocation);
		}
		else
		{
			Label = new Label(argIndex, onLocation);
		}
	}

	public virtual void SetLabelBoundary(int argIndex)
	{
		LocationType locationType = LocationType.Null;
		if (Label != null)
		{
			locationType = Label.GetLocation(argIndex);
		}
		base.Label.SetLocation(argIndex, locationType switch
		{
			LocationType.Interior => LocationType.Boundary, 
			LocationType.Boundary => LocationType.Interior, 
			_ => LocationType.Boundary, 
		});
	}

	public virtual LocationType ComputeMergedLocation(Label label2, int eltIndex)
	{
		LocationType locationType = Label.GetLocation(eltIndex);
		if (!label2.IsNull(eltIndex))
		{
			LocationType location = label2.GetLocation(eltIndex);
			if (locationType != LocationType.Boundary)
			{
				locationType = location;
			}
		}
		return locationType;
	}

	public virtual void Write(StreamWriter outstream)
	{
		outstream.WriteLine("node " + ((object)coordinate_0)?.ToString() + " lbl: " + Label);
	}

	public override string ToString()
	{
		return ((object)coordinate_0)?.ToString() + " " + edgeEndStar_0;
	}

	static Node()
	{
		Class72.smethod_20();
	}
}
