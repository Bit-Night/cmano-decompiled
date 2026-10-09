using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.Planargraph;

namespace DotSpatial.Topology.Operation.Polygonize;

public class EdgeRing
{
	private readonly IList ilist_0 = new ArrayList();

	private readonly IGeometryFactory igeometryFactory_0;

	private IList ilist_1;

	private ILinearRing ilinearRing_0;

	private IList<Coordinate> ilist_2;

	public virtual bool IsHole => CgAlgorithms.IsCounterClockwise(Ring.Coordinates);

	public virtual IPolygon Polygon
	{
		get
		{
			ILinearRing[] array = null;
			if (ilist_1 != null)
			{
				array = new ILinearRing[ilist_1.Count];
				for (int i = 0; i < ilist_1.Count; i++)
				{
					array[i] = (ILinearRing)ilist_1[i];
				}
			}
			return igeometryFactory_0.CreatePolygon(ilinearRing_0, array);
		}
	}

	public virtual bool IsValid
	{
		get
		{
			method_0();
			if (ilist_2.Count <= 3)
			{
				return false;
			}
			method_1();
			return ilinearRing_0.IsValid;
		}
	}

	private IList<Coordinate> Coordinates
	{
		get
		{
			method_0();
			return ilist_2;
		}
	}

	public virtual ILineString LineString => igeometryFactory_0.CreateLineString(Coordinates);

	public virtual ILinearRing Ring
	{
		get
		{
			method_1();
			return ilinearRing_0;
		}
	}

	public EdgeRing(IGeometryFactory factory)
	{
		igeometryFactory_0 = factory;
	}

	public static EdgeRing FindEdgeRingContaining(EdgeRing testEr, IList shellList)
	{
		ILinearRing ring = testEr.Ring;
		IEnvelope envelopeInternal = ring.EnvelopeInternal;
		EdgeRing edgeRing = null;
		IEnvelope envelope = null;
		IEnumerator enumerator = shellList.GetEnumerator();
		while (enumerator.MoveNext())
		{
			EdgeRing edgeRing2 = (EdgeRing)enumerator.Current;
			ILinearRing ring2 = edgeRing2.Ring;
			IEnvelope envelopeInternal2 = ring2.EnvelopeInternal;
			int num;
			if (edgeRing == null)
			{
				num = 0;
			}
			else
			{
				envelope = edgeRing.Ring.EnvelopeInternal;
				num = 0;
			}
			bool flag = (byte)num != 0;
			if (!envelopeInternal2.Equals(envelopeInternal))
			{
				Coordinate p = PtNotInList(ring.Coordinates, ring2.Coordinates);
				if (envelopeInternal2.Contains(envelopeInternal) && CgAlgorithms.IsPointInRing(p, ring2.Coordinates))
				{
					flag = true;
				}
				if (flag && (edgeRing == null || envelope.Contains(envelopeInternal2)))
				{
					edgeRing = edgeRing2;
				}
			}
		}
		return edgeRing;
	}

	public static Coordinate PtNotInList(IList<Coordinate> testPts, IList<Coordinate> pts)
	{
		for (int i = 0; i < testPts.Count; i++)
		{
			if (!IsInList(testPts[i], pts))
			{
				return new Coordinate(testPts[i]);
			}
		}
		return null;
	}

	public static bool IsInList(Coordinate pt, IList<Coordinate> pts)
	{
		int num = 0;
		while (true)
		{
			if (num < pts.Count)
			{
				if (new Coordinate(pt).Equals(pts[num]))
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	public virtual void Add(DirectedEdge de)
	{
		ilist_0.Add(de);
	}

	public virtual void AddHole(ILinearRing hole)
	{
		if (ilist_1 == null)
		{
			ilist_1 = new ArrayList();
		}
		ilist_1.Add(hole);
	}

	private void method_0()
	{
		if (ilist_2 == null)
		{
			CoordinateList coordinateList_ = new CoordinateList();
			IEnumerator enumerator = ilist_0.GetEnumerator();
			while (enumerator.MoveNext())
			{
				DirectedEdge directedEdge = (DirectedEdge)enumerator.Current;
				smethod_0(((PolygonizeEdge)directedEdge.Edge).Line.Coordinates, directedEdge.EdgeDirection, coordinateList_);
			}
			ilist_2 = coordinateList_;
		}
	}

	private void method_1()
	{
		if (ilinearRing_0 == null)
		{
			ilinearRing_0 = igeometryFactory_0.CreateLinearRing(Coordinates);
		}
	}

	private static void smethod_0(IList<Coordinate> ilist_3, bool bool_0, CoordinateList coordinateList_0)
	{
		if (bool_0)
		{
			for (int i = 0; i < ilist_3.Count; i++)
			{
				coordinateList_0.Add(ilist_3[i], allowRepeated: false);
			}
			return;
		}
		for (int num = ilist_3.Count - 1; num >= 0; num--)
		{
			coordinateList_0.Add(ilist_3[num], allowRepeated: false);
		}
	}

	static EdgeRing()
	{
		Class72.smethod_20();
	}
}
