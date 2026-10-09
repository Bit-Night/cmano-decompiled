using System.Collections;

namespace DotSpatial.Topology.Operation.Polygonize;

public class Polygonizer
{
	private readonly PolygonizeGraph polygonizeGraph_0 = new PolygonizeGraph(new GeometryFactory());

	private readonly LineStringAdder lineStringAdder_0;

	private IList ilist_0 = new ArrayList();

	private IList ilist_1 = new ArrayList();

	private IList ilist_2;

	private IList ilist_3 = new ArrayList();

	private IList ilist_4;

	private IList ilist_5;

	public virtual IList Polygons
	{
		get
		{
			method_0();
			return ilist_4;
		}
	}

	public virtual IList Dangles
	{
		get
		{
			method_0();
			return ilist_1;
		}
		protected set
		{
			ilist_1 = value;
		}
	}

	public virtual IList CutEdges
	{
		get
		{
			method_0();
			return ilist_0;
		}
		protected set
		{
			ilist_0 = value;
		}
	}

	public virtual IList InvalidRingLines
	{
		get
		{
			method_0();
			return ilist_3;
		}
		protected set
		{
			ilist_3 = value;
		}
	}

	public Polygonizer()
	{
		lineStringAdder_0 = new LineStringAdder(this);
	}

	public virtual void Add(IList geomList)
	{
		IEnumerator enumerator = geomList.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Geometry g = (Geometry)enumerator.Current;
			Add(g);
		}
	}

	public virtual void Add(IGeometry g)
	{
		g.Apply(lineStringAdder_0);
	}

	private void method_0()
	{
		if (ilist_4 != null)
		{
			return;
		}
		ilist_4 = new ArrayList();
		if (polygonizeGraph_0 != null)
		{
			ilist_1 = polygonizeGraph_0.DeleteDangles();
			ilist_0 = polygonizeGraph_0.DeleteCutEdges();
			IList edgeRings = polygonizeGraph_0.GetEdgeRings();
			IList list = new ArrayList();
			ilist_3 = new ArrayList();
			smethod_0(edgeRings, list, ilist_3);
			method_1(list);
			smethod_1(ilist_2, ilist_5);
			ilist_4 = new ArrayList();
			IEnumerator enumerator = ilist_5.GetEnumerator();
			while (enumerator.MoveNext())
			{
				EdgeRing edgeRing = (EdgeRing)enumerator.Current;
				ilist_4.Add(edgeRing.Polygon);
			}
		}
	}

	private static void smethod_0(IEnumerable ienumerable_0, IList ilist_6, IList ilist_7)
	{
		IEnumerator enumerator = ienumerable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			EdgeRing edgeRing = (EdgeRing)enumerator.Current;
			if (!edgeRing.IsValid)
			{
				ilist_7.Add(edgeRing.LineString);
			}
			else
			{
				ilist_6.Add(edgeRing);
			}
		}
	}

	private void method_1(IEnumerable ienumerable_0)
	{
		ilist_2 = new ArrayList();
		ilist_5 = new ArrayList();
		IEnumerator enumerator = ienumerable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			EdgeRing edgeRing = (EdgeRing)enumerator.Current;
			if (edgeRing.IsHole)
			{
				ilist_2.Add(edgeRing);
			}
			else
			{
				ilist_5.Add(edgeRing);
			}
		}
	}

	private static void smethod_1(IEnumerable ienumerable_0, IList ilist_6)
	{
		IEnumerator enumerator = ienumerable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			smethod_2((EdgeRing)enumerator.Current, ilist_6);
		}
	}

	private static void smethod_2(EdgeRing edgeRing_0, IList ilist_6)
	{
		EdgeRing.FindEdgeRingContaining(edgeRing_0, ilist_6)?.AddHole(edgeRing_0.Ring);
	}

	static Polygonizer()
	{
		Class72.smethod_20();
	}
}
