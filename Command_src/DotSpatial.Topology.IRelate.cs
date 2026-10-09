namespace DotSpatial.Topology;

public interface IRelate
{
	bool Contains(IGeometry geom);

	bool CoveredBy(IGeometry geom);

	bool Covers(IGeometry geom);

	bool Crosses(IGeometry geom);

	bool Disjoint(IGeometry geom);

	bool Intersects(IGeometry geom);

	bool Overlaps(IGeometry geom);

	bool Relate(IGeometry geom, string intersectionPattern);

	GInterface7 Relate(IGeometry g);

	bool Touches(IGeometry geom);

	bool Within(IGeometry geom);
}
