using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotObfuscate]
[DoNotPrune]
[DoNotPruneType]
public sealed class ScenarioSelectControlViewModel : CommandViewModel
{
	public LoadScenario LoadScenarioForm;

	private ObservableCollection<ScenarioViewModel> observableCollection_0;

	public ObservableCollection<ScenarioViewModel> Scenarios
	{
		get
		{
			return observableCollection_0;
		}
		set
		{
			SetProperty(ref observableCollection_0, value, "Scenarios");
		}
	}

	public ScenarioSelectControlViewModel()
	{
		observableCollection_0 = new ObservableCollection<ScenarioViewModel>();
	}

	public void Update()
	{
		List<ScenarioViewModel> list = new List<ScenarioViewModel>();
		foreach (SteamWorkshop.WorkshopItem subscribedWorkshopItem in SteamWorkshop.SubscribedWorkshopItems)
		{
			if (!subscribedWorkshopItem.GoodToGo || subscribedWorkshopItem.pchFolder == null)
			{
				continue;
			}
			foreach (string item in Directory.EnumerateFiles(subscribedWorkshopItem.pchFolder, "*.scen", SearchOption.AllDirectories))
			{
				if (Operators.CompareString(Path.GetExtension(item), ".scen", true) == 0)
				{
					SteamScenarioViewModel steamScenarioViewModel = new SteamScenarioViewModel();
					steamScenarioViewModel.ScenarioSelectControlViewModel = this;
					steamScenarioViewModel.ScenarioName = Path.GetFileName(item);
					steamScenarioViewModel.ScenarioDate = ScenContainer.QueryScenContainer(item, "ScenDate");
					steamScenarioViewModel.ScenarioDifficulty = ScenContainer.QueryScenContainer(item, "Difficulty");
					steamScenarioViewModel.ScenarioComplexity = ScenContainer.QueryScenContainer(item, "Complexity");
					steamScenarioViewModel.ScenarioPath = item;
					list.Add(steamScenarioViewModel);
				}
			}
		}
		Scenarios = new ObservableCollection<ScenarioViewModel>(list);
		Scenarios = new ObservableCollection<ScenarioViewModel>(Scenarios.OrderBy([SpecialName] (ScenarioViewModel F) => F.ScenarioName, new NaturalSortComparer<string[]>()));
	}

	public void OrderingChange(int selectedIndex)
	{
		switch (selectedIndex)
		{
		case 0:
			Scenarios = new ObservableCollection<ScenarioViewModel>(Scenarios.OrderBy([SpecialName] (ScenarioViewModel F) => F.ScenarioName));
			break;
		case 1:
			Scenarios = new ObservableCollection<ScenarioViewModel>(Scenarios.OrderBy([SpecialName] (ScenarioViewModel F) => F.ScenarioDate));
			break;
		case 2:
			Scenarios = new ObservableCollection<ScenarioViewModel>(Scenarios.OrderBy([SpecialName] (ScenarioViewModel F) => F.ScenarioDifficulty));
			break;
		case 3:
			Scenarios = new ObservableCollection<ScenarioViewModel>(Scenarios.OrderBy([SpecialName] (ScenarioViewModel F) => F.ScenarioComplexity));
			break;
		}
	}

	static ScenarioSelectControlViewModel()
	{
		Class72.smethod_20();
	}
}
