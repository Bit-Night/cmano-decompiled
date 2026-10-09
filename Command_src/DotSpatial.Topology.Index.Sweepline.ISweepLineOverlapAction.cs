namespace DotSpatial.Topology.Index.Sweepline;

public interface ISweepLineOverlapAction
{
	void Overlap(SweepLineInterval s0, SweepLineInterval s1);
}
