namespace CommandNetcode;

internal class NullTimingGraph : ITimingGraph
{
	public void StartTimer(string key)
	{
	}

	public void StopTimer(string key)
	{
	}

	static NullTimingGraph()
	{
		Class72.smethod_20();
	}
}
