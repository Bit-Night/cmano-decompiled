using System.Collections.Generic;

namespace Command_Core;

public sealed class Str_ConcurrentFrequencyWrapper
{
	public HashSet<Sensor.FrequencyBand> NonNatoFrequencies;

	public Str_ConcurrentFrequencyWrapper()
	{
		NonNatoFrequencies = new HashSet<Sensor.FrequencyBand>();
	}

	static Str_ConcurrentFrequencyWrapper()
	{
		Class72.smethod_20();
	}
}
