using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.GeometriesGraph;

public abstract class EdgeRing
{
	private readonly IList ilist_0 = new ArrayList();

	private readonly ArrayList arrayList_0 = new ArrayList();

	private readonly IGeometryFactory dCwekIjBpx9;

	private readonly Label label_0 = new Label(LocationType.Null);

	private readonly IList ilist_1 = new ArrayList();

	private bool bool_0;

	private int int_0 = -1;

	private ILinearRing ilinearRing_0;

	private EdgeRing edgeRing_0;

	private DirectedEdge directedEdge_0;

	protected IGeometryFactory InnerGeometryFactory => dCwekIjBpx9;

	public virtual bool IsIsolated => label_0.GeometryCount == 1;

	public virtual bool IsHole => bool_0;

	public virtual ILinearRing LinearRing => ilinearRing_0;

	public virtual Label Label => label_0;

	public virtual bool IsShell => edgeRing_0 == null;

	public virtual EdgeRing Shell
	{
		get
		{
			return edgeRing_0;
		}
		set
		{
			edgeRing_0 = value;
			if (value != null)
			{
				edgeRing_0.AddHole(this);
			}
		}
	}

	public virtual IList Edges => ilist_0;

	protected DirectedEdge StartDe
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

	public virtual int MaxNodeDegree
	{
		get
		{
			if (int_0 < 0)
			{
				method_0();
			}
			return int_0;
		}
	}

	protected EdgeRing(DirectedEdge start, IGeometryFactory geometryFactory)
	{
		dCwekIjBpx9 = geometryFactory;
		ComputePoints(start);
		ComputeRing();
	}

	public virtual Coordinate GetCoordinate(int i)
	{
		return (Coordinate)ilist_1[i];
	}

	public virtual void AddHole(EdgeRing ring)
	{
		arrayList_0.Add(ring);
	}

	public virtual IPolygon ToPolygon(IGeometryFactory geometryFactory)
	{
		ILinearRing[] array = new LinearRing[arrayList_0.Count];
		ILinearRing[] array2 = array;
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			array2[i] = ((EdgeRing)arrayList_0[i]).LinearRing;
		}
		return geometryFactory.CreatePolygon(LinearRing, array2);
	}

	public void ComputeRing()
	{
		if (ilinearRing_0 == null)
		{
			Coordinate[] array = new Coordinate[ilist_1.Count];
			for (int i = 0; i < ilist_1.Count; i++)
			{
				array[i] = (Coordinate)ilist_1[i];
			}
			ilinearRing_0 = InnerGeometryFactory.CreateLinearRing(array);
			bool_0 = CgAlgorithms.IsCounterClockwise(ilinearRing_0.Coordinates);
		}
	}

	public abstract DirectedEdge GetNext(DirectedEdge de);

	public abstract void SetEdgeRing(DirectedEdge de, EdgeRing er);

	protected void ComputePoints(DirectedEdge start)
	{
		StartDe = start;
		DirectedEdge directedEdge = start;
		bool isFirstEdge = true;
		while (true)
		{
			Assert.IsTrue(directedEdge != null, "found null Directed Edge");
			if (directedEdge != null)
			{
				if (directedEdge.EdgeRing == this)
				{
					break;
				}
				ilist_0.Add(directedEdge);
				Label label = directedEdge.Label;
				Assert.IsTrue(label.IsArea());
				MergeLabel(label);
				AddPoints(directedEdge.Edge, directedEdge.IsForward, isFirstEdge);
				isFirstEdge = false;
				SetEdgeRing(directedEdge, this);
				directedEdge = GetNext(directedEdge);
			}
			if (directedEdge == StartDe)
			{
				return;
			}
		}
		throw new TopologyException("Directed Edge visited twice during ring-building at " + (object)directedEdge.Coordinate);
	}

	private void method_0()
	{
		int_0 = 0;
		DirectedEdge directedEdge = StartDe;
		do
		{
			int outgoingDegree = ((DirectedEdgeStar)directedEdge.Node.Edges).GetOutgoingDegree(this);
			if (outgoingDegree > int_0)
			{
				int_0 = outgoingDegree;
			}
			directedEdge = GetNext(directedEdge);
		}
		while (directedEdge != StartDe);
		int_0 *= 2;
	}

	public virtual void SetInResult()
	{
		DirectedEdge directedEdge = StartDe;
		do
		{
			directedEdge.Edge.IsInResult = true;
			directedEdge = directedEdge.Next;
		}
		while (directedEdge != StartDe);
	}

	protected virtual void MergeLabel(Label deLabel)
	{
		MergeLabel(deLabel, 0);
		MergeLabel(deLabel, 1);
	}

	protected virtual void MergeLabel(Label deLabel, int geomIndex)
	{
		LocationType location = deLabel.GetLocation(geomIndex, PositionType.Right);
		if (location != LocationType.Null && label_0.GetLocation(geomIndex) == LocationType.Null)
		{
			label_0.SetLocation(geomIndex, location);
		}
	}

	protected virtual void AddPoints(Edge edge, bool isForward, bool isFirstEdge)
	{
		IList<Coordinate> coordinates = edge.Coordinates;
		if (!isForward)
		{
			int num = coordinates.Count - 2;
			if (isFirstEdge)
			{
				num = coordinates.Count - 1;
			}
			for (int num2 = num; num2 >= 0; num2--)
			{
				ilist_1.Add(coordinates[num2]);
			}
		}
		else
		{
			int num3 = 1;
			if (isFirstEdge)
			{
				num3 = 0;
			}
			for (int i = num3; i < coordinates.Count; i++)
			{
				ilist_1.Add(coordinates[i]);
			}
		}
	}

	public virtual bool ContainsPoint(Coordinate p)
	{
		ILinearRing linearRing = LinearRing;
		if (!linearRing.EnvelopeInternal.Contains(p))
		{
			return false;
		}
		if (!CgAlgorithms.IsPointInRing(p, linearRing.Coordinates))
		{
			return false;
		}
		IEnumerator enumerator = arrayList_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			if (((EdgeRing)enumerator.Current).ContainsPoint(p))
			{
				return false;
			}
		}
		return true;
	}

	static EdgeRing()
	{
		Class72.smethod_20();
	}
}
