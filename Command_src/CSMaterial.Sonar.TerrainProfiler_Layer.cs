using System.Windows.Media;

namespace CSMaterial.Sonar;

public sealed class TerrainProfiler_Layer
{
	public Color color;

	public string Name;

	public double Height_m;

	public double Top_m;

	public TerrainProfiler_Layer(double _Top_m, double _Height_m, Color? _color = null, string _Name = "")
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		Top_m = _Top_m;
		Height_m = _Height_m;
		if (!_color.HasValue)
		{
			_color = Colors.Pink;
		}
		else
		{
			color = _color.Value;
		}
		Name = _Name;
	}

	static TerrainProfiler_Layer()
	{
		Class72.smethod_20();
	}
}
