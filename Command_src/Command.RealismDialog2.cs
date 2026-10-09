using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class RealismDialog2 : Window, INotifyPropertyChanged, IComponentConnector
{
	private string string_0;

	private string string_1;

	[CompilerGenerated]
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	[AccessedThroughProperty("FeaturesContainer")]
	[CompilerGenerated]
	private ItemsControl itemsControl_0;

	[CompilerGenerated]
	[AccessedThroughProperty("PlayScenarioBtn")]
	private Button button_0;

	private bool bool_0;

	public string ScenarioName
	{
		get
		{
			return string_0;
		}
		set
		{
			if (!object.Equals(string_0, value))
			{
				string_0 = value;
				OnPropertyChanged("ScenarioName");
			}
		}
	}

	public string DurationText
	{
		get
		{
			return string_1;
		}
		set
		{
			if (!object.Equals(string_1, value))
			{
				string_1 = value;
				OnPropertyChanged("DurationText");
			}
		}
	}

	internal virtual ItemsControl FeaturesContainer
	{
		[CompilerGenerated]
		get
		{
			return itemsControl_0;
		}
		[CompilerGenerated]
		set
		{
			itemsControl_0 = value;
		}
	}

	internal virtual Button PlayScenarioBtn
	{
		[CompilerGenerated]
		get
		{
			return button_0;
		}
		[CompilerGenerated]
		set
		{
			button_0 = value;
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		[CompilerGenerated]
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = propertyChangedEventHandler_0;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref propertyChangedEventHandler_0, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = propertyChangedEventHandler_0;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref propertyChangedEventHandler_0, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public RealismDialog2()
	{
		InitializeComponent();
		((FrameworkElement)this).DataContext = this;
		ScenarioName = Client.CurrentScenario.Title;
		DurationText = "Duration: " + Misc.TimeString((long)Math.Round(Client.CurrentScenario.Duration.TotalSeconds));
		method_0();
	}

	private void method_0()
	{
		List<FeatureItem> itemsSource = new List<FeatureItem>
		{
			new FeatureItem
			{
				Label = "Detailed Gun Fire-Control",
				IsEnabled = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DetailedGunFireControl),
				ToolTipText = Misc.ToEnglishString(Scenario.ScenarioFeatureOption.DetailedGunFireControl)
			},
			new FeatureItem
			{
				Label = "Unlimited magazines at air/naval bases",
				IsEnabled = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines),
				ToolTipText = Misc.ToEnglishString(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines)
			},
			new FeatureItem
			{
				Label = "Aircraft Damage",
				IsEnabled = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.AircraftDamage),
				ToolTipText = Misc.ToEnglishString(Scenario.ScenarioFeatureOption.AircraftDamage)
			},
			new FeatureItem
			{
				Label = "Realistic Submarine Communications",
				IsEnabled = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.RealisticSubComms),
				ToolTipText = Misc.ToEnglishString(Scenario.ScenarioFeatureOption.RealisticSubComms)
			},
			new FeatureItem
			{
				Label = "Effects of Terrain Type",
				IsEnabled = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LandTypeEffects),
				ToolTipText = Misc.ToEnglishString(Scenario.ScenarioFeatureOption.LandTypeEffects)
			},
			new FeatureItem
			{
				Label = "Effects of Terrain Type - ADVANCED",
				IsEnabled = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LandTypeEffects_Advanced),
				ToolTipText = Misc.ToEnglishString(Scenario.ScenarioFeatureOption.LandTypeEffects_Advanced)
			},
			new FeatureItem
			{
				Label = "Weather affects ship speed",
				IsEnabled = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.WeatherAffectsShipSpeed),
				ToolTipText = Misc.ToEnglishString(Scenario.ScenarioFeatureOption.WeatherAffectsShipSpeed)
			},
			new FeatureItem
			{
				Label = "Communications Disruption",
				IsEnabled = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.CommsDisruption),
				ToolTipText = Misc.ToEnglishString(Scenario.ScenarioFeatureOption.CommsDisruption)
			},
			new FeatureItem
			{
				Label = "Communications Jamming",
				IsEnabled = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.CommsJamming),
				ToolTipText = Misc.ToEnglishString(Scenario.ScenarioFeatureOption.CommsJamming)
			},
			new FeatureItem
			{
				Label = "Weather and day/night affect aircraft sorties",
				IsEnabled = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.ACS_NAW_Limitations),
				ToolTipText = Misc.ToEnglishString(Scenario.ScenarioFeatureOption.ACS_NAW_Limitations)
			},
			new FeatureItem
			{
				Label = "Drone Autonomy Levels",
				IsEnabled = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DroneAutonomyLevels),
				ToolTipText = Misc.ToEnglishString(Scenario.ScenarioFeatureOption.DroneAutonomyLevels)
			},
			new FeatureItem
			{
				Label = "ASCM Terrain Following restriction",
				IsEnabled = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.ASCMTerrainFollowingRestriction),
				ToolTipText = Misc.ToEnglishString(Scenario.ScenarioFeatureOption.ASCMTerrainFollowingRestriction)
			},
			new FeatureItem
			{
				Label = "Variable boost-coast burnout speed",
				IsEnabled = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.VariableBurnoutSpeed),
				ToolTipText = Misc.ToEnglishString(Scenario.ScenarioFeatureOption.VariableBurnoutSpeed)
			},
			new FeatureItem
			{
				Label = "Limited Sonobuoy Replenishment",
				IsEnabled = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LimitedSonobuoysInMagazines),
				ToolTipText = Misc.ToEnglishString(Scenario.ScenarioFeatureOption.LimitedSonobuoysInMagazines)
			}
		};
		FeaturesContainer.ItemsSource = itemsSource;
	}

	private void method_1(object sender, RoutedEventArgs e)
	{
		((Window)this).Close();
	}

	protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		propertyChangedEventHandler_0?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!bool_0)
		{
			bool_0 = true;
			Uri uri = new Uri("/Command;component/forms/scenario/realismdialog/realismdialog2.xaml", UriKind.Relative);
			Application.LoadComponent((object)this, uri);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			FeaturesContainer = (ItemsControl)target;
			break;
		case 2:
			PlayScenarioBtn = (Button)target;
			((ButtonBase)PlayScenarioBtn).Click += new RoutedEventHandler(method_1);
			break;
		default:
			bool_0 = true;
			break;
		}
	}

	static RealismDialog2()
	{
		Class72.smethod_20();
	}
}
