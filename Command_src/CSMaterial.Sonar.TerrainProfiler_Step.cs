using System.Collections.Generic;

namespace CSMaterial.Sonar;

public sealed class TerrainProfiler_Step
{
	public double Height;

	public List<TerrainProfiler_Layer> Layers = new List<TerrainProfiler_Layer>();

	public TerrainProfiler_Step(double _Height)
	{
		Height = _Height;
	}

	static TerrainProfiler_Step()
	{
		Class72.smethod_20();
	}
}
