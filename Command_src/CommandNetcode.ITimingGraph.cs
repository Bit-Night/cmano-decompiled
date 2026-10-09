namespace CommandNetcode;

public interface ITimingGraph
{
	void StartTimer(string key);

	void StopTimer(string key);
}
