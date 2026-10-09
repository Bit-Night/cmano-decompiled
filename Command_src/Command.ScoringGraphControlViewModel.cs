using Command_Core.SmartAssembly.Attributes;
using LiveCharts;

namespace Command;

[DoNotPruneType]
[DoNotObfuscate]
[DoNotPrune]
public sealed class ScoringGraphControlViewModel : CommandViewModel
{
	private ChartValues<ScoringDatapointViewModel> chartValues_0;

	public ChartValues<ScoringDatapointViewModel> PlayerScore
	{
		get
		{
			return chartValues_0;
		}
		set
		{
			SetProperty(ref chartValues_0, value, "PlayerScore");
		}
	}

	static ScoringGraphControlViewModel()
	{
		Class72.smethod_20();
	}
}
