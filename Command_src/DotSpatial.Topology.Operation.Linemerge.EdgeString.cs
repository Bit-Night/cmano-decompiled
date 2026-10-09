using System.Collections;

namespace DotSpatial.Topology.Operation.Linemerge;

public class EdgeString
{
	private readonly IList ilist_0 = new ArrayList();

	private readonly IGeometryFactory igeometryFactory_0;

	private Coordinate[] coordinate_0;

	private Coordinate[] Coordinates
	{
		get
		{
			if (coordinate_0 == null)
			{
				int num = 0;
				int num2 = 0;
				CoordinateList coordinateList = new CoordinateList();
				IEnumerator enumerator = ilist_0.GetEnumerator();
				while (enumerator.MoveNext())
				{
					LineMergeDirectedEdge lineMergeDirectedEdge = (LineMergeDirectedEdge)enumerator.Current;
					if (lineMergeDirectedEdge.EdgeDirection)
					{
						num++;
					}
					else
					{
						num2++;
					}
					coordinateList.Add(((LineMergeEdge)lineMergeDirectedEdge.Edge).Line.Coordinates, allowRepeated: false, lineMergeDirectedEdge.EdgeDirection);
				}
				coordinate_0 = coordinateList.ToCoordinateArray();
				if (num2 > num)
				{
					CoordinateArrays.Reverse(coordinate_0);
				}
			}
			return coordinate_0;
		}
	}

	public EdgeString(IGeometryFactory factory)
	{
		igeometryFactory_0 = factory;
	}

	public virtual void Add(LineMergeDirectedEdge directedEdge)
	{
		ilist_0.Add(directedEdge);
	}

	public virtual ILineString ToLineString()
	{
		return igeometryFactory_0.CreateLineString(Coordinates);
	}

	static EdgeString()
	{
		Class72.smethod_20();
	}
}
