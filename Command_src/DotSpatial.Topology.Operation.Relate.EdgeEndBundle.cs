using System.Collections;
using System.IO;
using DotSpatial.Topology.GeometriesGraph;

namespace DotSpatial.Topology.Operation.Relate;

public class EdgeEndBundle : EdgeEnd
{
	private readonly IList ilist_0 = new ArrayList();

	public virtual IList EdgeEnds => ilist_0;

	public EdgeEndBundle(EdgeEnd e)
		: base(e.Edge, e.Coordinate, e.DirectedCoordinate, new Label(e.Label))
	{
		Insert(e);
	}

	public virtual IEnumerator GetEnumerator()
	{
		return ilist_0.GetEnumerator();
	}

	public void Insert(EdgeEnd e)
	{
		ilist_0.Add(e);
	}

	public override void ComputeLabel()
	{
		bool flag = false;
		IEnumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			if (((EdgeEnd)enumerator.Current).Label.IsArea())
			{
				flag = true;
			}
		}
		int num;
		if (flag)
		{
			Label = new Label(LocationType.Null, LocationType.Null, LocationType.Null);
			num = 0;
		}
		else
		{
			Label = new Label(LocationType.Null);
			num = 0;
		}
		for (int i = num; i < 2; i++)
		{
			method_1(i);
			if (flag)
			{
				method_2(i);
			}
		}
	}

	private void method_1(int int_1)
	{
		int num = 0;
		bool flag = false;
		IEnumerator enumerator = GetEnumerator();
		LocationType location;
		while (enumerator.MoveNext())
		{
			location = ((EdgeEnd)enumerator.Current).Label.GetLocation(int_1);
			if (location == LocationType.Boundary)
			{
				num++;
			}
			if (location == LocationType.Interior)
			{
				flag = true;
			}
		}
		location = LocationType.Null;
		if (flag)
		{
			location = LocationType.Interior;
		}
		if (num > 0)
		{
			location = GeometryGraph.DetermineBoundary(num);
		}
		Label.SetLocation(int_1, location);
	}

	private void method_2(int int_1)
	{
		method_3(int_1, PositionType.Left);
		method_3(int_1, PositionType.Right);
	}

	private void method_3(int int_1, PositionType positionType_0)
	{
		IEnumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			EdgeEnd edgeEnd = (EdgeEnd)enumerator.Current;
			if (edgeEnd.Label.IsArea())
			{
				switch (edgeEnd.Label.GetLocation(int_1, positionType_0))
				{
				case LocationType.Exterior:
					Label.SetLocation(int_1, positionType_0, LocationType.Exterior);
					break;
				case LocationType.Interior:
					Label.SetLocation(int_1, positionType_0, LocationType.Interior);
					return;
				}
			}
		}
	}

	public virtual void UpdateIm(IntersectionMatrix im)
	{
		Edge.UpdateIm(Label, im);
	}

	public override void Write(StreamWriter outstream)
	{
		outstream.WriteLine("EdgeEndBundle--> Label: " + Label);
		IEnumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			((EdgeEnd)enumerator.Current).Write(outstream);
			outstream.WriteLine();
		}
	}

	static EdgeEndBundle()
	{
		Class72.smethod_20();
	}
}
