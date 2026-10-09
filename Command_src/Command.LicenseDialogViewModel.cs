using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Command_Core;
using Command.SmartAssembly.Attributes;

namespace Command;

[DoNotPrune]
[DoNotPruneType]
[DoNotObfuscate]
public sealed class LicenseDialogViewModel : CommandViewModel
{
	private bool bool_0;

	private ObservableCollection<LicenseViewModel> observableCollection_0;

	public bool BeginScenarioEnabled
	{
		get
		{
			return bool_0;
		}
		set
		{
			SetProperty(ref bool_0, value, "BeginScenarioEnabled");
		}
	}

	public ObservableCollection<LicenseViewModel> Items
	{
		get
		{
			return observableCollection_0;
		}
		set
		{
			SetProperty(ref observableCollection_0, value, "Items");
		}
	}

	[Obsolete("Used for design time only", true)]
	public LicenseDialogViewModel()
	{
		observableCollection_0 = new ObservableCollection<LicenseViewModel>();
		Items.Add(new LicenseViewModel
		{
			Title = "Aircraft Damage model",
			Subtitle = "",
			Required = true,
			Owned = false,
			AssociatedLicense = Licensing.ModuleLicense.ChainsOfWar
		});
		Items.Add(new LicenseViewModel
		{
			Title = "Cargo Operations",
			Subtitle = "",
			Required = true,
			Owned = false,
			AssociatedLicense = Licensing.ModuleLicense.ChainsOfWar
		});
		Items.Add(new LicenseViewModel
		{
			Title = "Communications Disruption",
			Subtitle = "",
			Required = true,
			Owned = false,
			AssociatedLicense = Licensing.ModuleLicense.ChainsOfWar
		});
		Items.Add(new LicenseViewModel
		{
			Title = "Tactical EMP (Omnidirectional)",
			Subtitle = "",
			Required = true,
			Owned = false,
			AssociatedLicense = Licensing.ModuleLicense.ChainsOfWar
		});
		Items.Add(new LicenseViewModel
		{
			Title = "High-Energy Lasers (Phase 2)",
			Subtitle = "",
			Required = true,
			Owned = false,
			AssociatedLicense = Licensing.ModuleLicense.ChainsOfWar
		});
		Items.Add(new LicenseViewModel
		{
			Title = "Railguns / HVPs",
			Subtitle = "",
			Required = true,
			Owned = false,
			AssociatedLicense = Licensing.ModuleLicense.ChainsOfWar
		});
		BeginScenarioEnabled = false;
	}

	public LicenseDialogViewModel(List<Scenario.ScenarioFeatureOption> theFeatureList)
	{
		observableCollection_0 = new ObservableCollection<LicenseViewModel>();
		foreach (Scenario.ScenarioFeatureOption theFeature in theFeatureList)
		{
			if (theFeature == Scenario.ScenarioFeatureOption.CommsJamming)
			{
				Items.Add(new LicenseViewModel
				{
					Title = "Communications Jamming",
					Subtitle = "",
					Required = true,
					Owned = false,
					AssociatedLicense = Licensing.ModuleLicense.CommandPE
				});
			}
		}
		BeginScenarioEnabled = false;
	}

	static LicenseDialogViewModel()
	{
		Class72.smethod_20();
	}
}
