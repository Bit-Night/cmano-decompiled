namespace DotSpatial.Topology.Algorithm;

public interface IPointInRing
{
	bool IsInside(Coordinate pt);
}
