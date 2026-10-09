using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.GeometriesGraph;
using DotSpatial.Topology.GeometriesGraph.Index;

namespace DotSpatial.Topology.Operation;

public class IsSimpleOp
{
	public class EndpointInfo
	{
		private int int_0;

		private bool bool_0;

		private Coordinate coordinate_0;

		public virtual Coordinate Point
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

		public virtual bool IsClosed
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		public virtual int Degree
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

		public EndpointInfo(Coordinate pt)
		{
			coordinate_0 = pt;
			bool_0 = false;
			int_0 = 0;
		}

		public virtual void AddEndpoint(bool isClosed)
		{
			Degree++;
			IsClosed |= isClosed;
		}

		static EndpointInfo()
		{
			Class72.smethod_20();
		}
	}

	public virtual bool IsSimple(LineString geom)
	{
		return smethod_0(geom);
	}

	public virtual bool IsSimple(MultiLineString geom)
	{
		return smethod_0(geom);
	}

	public virtual bool IsSimple(MultiPoint mp)
	{
		if (!mp.IsEmpty)
		{
			HashSet<Coordinate> hashSet = new HashSet<Coordinate>();
			int num = 0;
			while (true)
			{
				if (num < mp.NumGeometries)
				{
					Coordinate coordinate = ((Point)mp.GetGeometryN(num)).Coordinate;
					if (hashSet.Contains(coordinate))
					{
						break;
					}
					hashSet.Add(coordinate);
					num++;
					continue;
				}
				return true;
			}
			return false;
		}
		return true;
	}

	private static bool smethod_0(IGeometry igeometry_0)
	{
		if (igeometry_0.IsEmpty)
		{
			return true;
		}
		GeometryGraph geometryGraph = new GeometryGraph(0, igeometry_0);
		LineIntersector li = new RobustLineIntersector();
		SegmentIntersector segmentIntersector = geometryGraph.ComputeSelfNodes(li, computeRingSelfNodes: true);
		if (!segmentIntersector.HasIntersection)
		{
			return true;
		}
		if (segmentIntersector.HasProperIntersection)
		{
			return false;
		}
		if (!smethod_1(geometryGraph))
		{
			if (smethod_2(geometryGraph))
			{
				return false;
			}
			return true;
		}
		return false;
	}

	private static bool smethod_1(PlanarGraph planarGraph_0)
	{
		IEnumerator edgeEnumerator = planarGraph_0.GetEdgeEnumerator();
		while (edgeEnumerator.MoveNext())
		{
			Edge obj = (Edge)edgeEnumerator.Current;
			int maximumSegmentIndex = obj.MaximumSegmentIndex;
			IEnumerator enumerator = obj.EdgeIntersectionList.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (!((EdgeIntersection)enumerator.Current).IsEndPoint(maximumSegmentIndex))
				{
					return true;
				}
			}
		}
		return false;
	}

	private static bool smethod_2(PlanarGraph planarGraph_0)
	{
		IDictionary dictionary = new SortedList();
		IEnumerator edgeEnumerator = planarGraph_0.GetEdgeEnumerator();
		while (edgeEnumerator.MoveNext())
		{
			Edge obj = (Edge)edgeEnumerator.Current;
			bool isClosed = obj.IsClosed;
			Coordinate coordinate = obj.GetCoordinate(0);
			smethod_3(dictionary, coordinate, isClosed);
			Coordinate coordinate2 = obj.GetCoordinate(obj.NumPoints - 1);
			smethod_3(dictionary, coordinate2, isClosed);
		}
		IEnumerator enumerator = dictionary.Values.GetEnumerator();
		while (enumerator.MoveNext())
		{
			EndpointInfo endpointInfo = (EndpointInfo)enumerator.Current;
			if (endpointInfo.IsClosed && endpointInfo.Degree != 2)
			{
				return true;
			}
		}
		return false;
	}

	private static void smethod_3(IDictionary idictionary_0, Coordinate coordinate_0, bool bool_0)
	{
		EndpointInfo endpointInfo = (EndpointInfo)idictionary_0[coordinate_0];
		if (endpointInfo == null)
		{
			endpointInfo = new EndpointInfo(coordinate_0);
			idictionary_0.Add(coordinate_0, endpointInfo);
		}
		endpointInfo.AddEndpoint(bool_0);
	}

	static IsSimpleOp()
	{
		Class72.smethod_20();
	}
}
