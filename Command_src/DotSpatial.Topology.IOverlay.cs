namespace DotSpatial.Topology;

public interface IOverlay
{
	IGeometry Difference(IGeometry geom);

	IGeometry Intersection(IGeometry geom);

	IGeometry SymmetricDifference(IGeometry geom);

	IGeometry Union(IGeometry geom);
}
