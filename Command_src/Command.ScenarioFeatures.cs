using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using Command_Core;
using Command.My;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class ScenarioFeatures : Window, IComponentConnector
{
	[CompilerGenerated]
	internal sealed class _Closure$__2-0
	{
		public Side $VB$Local_theSide;

		public _Closure$__2-0(_Closure$__2-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theSide = arg0.$VB$Local_theSide;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(ActiveUnit theUnit)
		{
			return Operators.CompareString(theUnit.ObjectID, $VB$Local_theSide.HQ_ID, true) == 0;
		}

		static _Closure$__2-0()
		{
			Class72.smethod_20();
		}
	}

	[AccessedThroughProperty("StackPanel1")]
	[CompilerGenerated]
	private StackPanel stackPanel_0;

	[AccessedThroughProperty("CB_GunfireControl")]
	[CompilerGenerated]
	private CheckBox checkBox_0;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_UnlimitedBaseMags")]
	private CheckBox checkBox_1;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_ACDamage")]
	private CheckBox checkBox_2;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_RealisticSubComms")]
	private CheckBox checkBox_3;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_TerrainTypeEffects")]
	private CheckBox checkBox_4;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_TerrainTypeEffects_Advanced")]
	private CheckBox checkBox_5;

	[AccessedThroughProperty("CB_CommsDisruption")]
	[CompilerGenerated]
	private CheckBox checkBox_6;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_CommsJamming")]
	private CheckBox checkBox_7;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_WeatherAffectsShipSpeed")]
	private CheckBox checkBox_8;

	[AccessedThroughProperty("CB_LandingPlannerInstantLoading")]
	[CompilerGenerated]
	private CheckBox checkBox_9;

	[AccessedThroughProperty("CB_AC_NAW_Loadout")]
	[CompilerGenerated]
	private CheckBox checkBox_10;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_DroneAutonomy")]
	private CheckBox checkBox_11;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_ASCMTerrainFollowing")]
	private CheckBox checkBox_12;

	[AccessedThroughProperty("CB_PointToPointComm")]
	[CompilerGenerated]
	private CheckBox checkBox_13;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_RealisticOrderChain")]
	private CheckBox checkBox_14;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_VariableBurnoutSpeed")]
	private CheckBox checkBox_15;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_LimitedSonobuoys")]
	private CheckBox checkBox_16;

	[AccessedThroughProperty("LB_LimitedSonobuoys")]
	[CompilerGenerated]
	private Label label_0;

	[AccessedThroughProperty("Button_OK")]
	[CompilerGenerated]
	private Button button_0;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Cancel")]
	private Button button_1;

	private bool bool_0;

	internal virtual StackPanel StackPanel1
	{
		[CompilerGenerated]
		get
		{
			return stackPanel_0;
		}
		[CompilerGenerated]
		set
		{
			stackPanel_0 = value;
		}
	}

	internal virtual CheckBox CB_GunfireControl
	{
		[CompilerGenerated]
		get
		{
			return checkBox_0;
		}
		[CompilerGenerated]
		set
		{
			checkBox_0 = value;
		}
	}

	internal virtual CheckBox CB_UnlimitedBaseMags
	{
		[CompilerGenerated]
		get
		{
			return checkBox_1;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			RoutedEventHandler val = new RoutedEventHandler(method_2);
			RoutedEventHandler val2 = new RoutedEventHandler(method_3);
			CheckBox val3 = checkBox_1;
			if (val3 != null)
			{
				((ToggleButton)val3).Checked -= val;
				((ToggleButton)val3).Unchecked -= val2;
			}
			checkBox_1 = value;
			val3 = checkBox_1;
			if (val3 != null)
			{
				((ToggleButton)val3).Checked += val;
				((ToggleButton)val3).Unchecked += val2;
			}
		}
	}

	internal virtual CheckBox CB_ACDamage
	{
		[CompilerGenerated]
		get
		{
			return checkBox_2;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			RoutedEventHandler val = new RoutedEventHandler(method_5);
			CheckBox val2 = checkBox_2;
			if (val2 != null)
			{
				((ButtonBase)val2).Click -= val;
			}
			checkBox_2 = value;
			val2 = checkBox_2;
			if (val2 != null)
			{
				((ButtonBase)val2).Click += val;
			}
		}
	}

	internal virtual CheckBox CB_RealisticSubComms
	{
		[CompilerGenerated]
		get
		{
			return checkBox_3;
		}
		[CompilerGenerated]
		set
		{
			checkBox_3 = value;
		}
	}

	internal virtual CheckBox CB_TerrainTypeEffects
	{
		[CompilerGenerated]
		get
		{
			return checkBox_4;
		}
		[CompilerGenerated]
		set
		{
			checkBox_4 = value;
		}
	}

	internal virtual CheckBox CB_TerrainTypeEffects_Advanced
	{
		[CompilerGenerated]
		get
		{
			return checkBox_5;
		}
		[CompilerGenerated]
		set
		{
			checkBox_5 = value;
		}
	}

	internal virtual CheckBox CB_CommsDisruption
	{
		[CompilerGenerated]
		get
		{
			return checkBox_6;
		}
		[CompilerGenerated]
		set
		{
			checkBox_6 = value;
		}
	}

	internal virtual CheckBox CB_CommsJamming
	{
		[CompilerGenerated]
		get
		{
			return checkBox_7;
		}
		[CompilerGenerated]
		set
		{
			checkBox_7 = value;
		}
	}

	internal virtual CheckBox CB_WeatherAffectsShipSpeed
	{
		[CompilerGenerated]
		get
		{
			return checkBox_8;
		}
		[CompilerGenerated]
		set
		{
			checkBox_8 = value;
		}
	}

	internal virtual CheckBox CB_LandingPlannerInstantLoading
	{
		[CompilerGenerated]
		get
		{
			return checkBox_9;
		}
		[CompilerGenerated]
		set
		{
			checkBox_9 = value;
		}
	}

	internal virtual CheckBox CB_AC_NAW_Loadout
	{
		[CompilerGenerated]
		get
		{
			return checkBox_10;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			RoutedEventHandler val = new RoutedEventHandler(method_6);
			CheckBox val2 = checkBox_10;
			if (val2 != null)
			{
				((ButtonBase)val2).Click -= val;
			}
			checkBox_10 = value;
			val2 = checkBox_10;
			if (val2 != null)
			{
				((ButtonBase)val2).Click += val;
			}
		}
	}

	internal virtual CheckBox CB_DroneAutonomy
	{
		[CompilerGenerated]
		get
		{
			return checkBox_11;
		}
		[CompilerGenerated]
		set
		{
			checkBox_11 = value;
		}
	}

	internal virtual CheckBox CB_ASCMTerrainFollowing
	{
		[CompilerGenerated]
		get
		{
			return checkBox_12;
		}
		[CompilerGenerated]
		set
		{
			checkBox_12 = value;
		}
	}

	internal virtual CheckBox CB_PointToPointComm
	{
		[CompilerGenerated]
		get
		{
			return checkBox_13;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			RoutedEventHandler val = new RoutedEventHandler(method_7);
			CheckBox val2 = checkBox_13;
			if (val2 != null)
			{
				((ButtonBase)val2).Click -= val;
			}
			checkBox_13 = value;
			val2 = checkBox_13;
			if (val2 != null)
			{
				((ButtonBase)val2).Click += val;
			}
		}
	}

	internal virtual CheckBox CB_RealisticOrderChain
	{
		[CompilerGenerated]
		get
		{
			return checkBox_14;
		}
		[CompilerGenerated]
		set
		{
			checkBox_14 = value;
		}
	}

	internal virtual CheckBox CB_VariableBurnoutSpeed
	{
		[CompilerGenerated]
		get
		{
			return checkBox_15;
		}
		[CompilerGenerated]
		set
		{
			checkBox_15 = value;
		}
	}

	internal virtual CheckBox CB_LimitedSonobuoys
	{
		[CompilerGenerated]
		get
		{
			return checkBox_16;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			DependencyPropertyChangedEventHandler val = (DependencyPropertyChangedEventHandler)([SpecialName] (object sender, DependencyPropertyChangedEventArgs e) =>
			{
				method_4();
			});
			CheckBox val2 = checkBox_16;
			if (val2 != null)
			{
				((UIElement)val2).IsEnabledChanged -= val;
			}
			checkBox_16 = value;
			val2 = checkBox_16;
			if (val2 != null)
			{
				((UIElement)val2).IsEnabledChanged += val;
			}
		}
	}

	internal virtual Label LB_LimitedSonobuoys
	{
		[CompilerGenerated]
		get
		{
			return label_0;
		}
		[CompilerGenerated]
		set
		{
			label_0 = value;
		}
	}

	internal virtual Button Button_OK
	{
		[CompilerGenerated]
		get
		{
			return button_0;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			RoutedEventHandler val = new RoutedEventHandler(method_0);
			Button val2 = button_0;
			if (val2 != null)
			{
				((ButtonBase)val2).Click -= val;
			}
			button_0 = value;
			val2 = button_0;
			if (val2 != null)
			{
				((ButtonBase)val2).Click += val;
			}
		}
	}

	internal virtual Button Button_Cancel
	{
		[CompilerGenerated]
		get
		{
			return button_1;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			RoutedEventHandler val = new RoutedEventHandler(method_1);
			Button val2 = button_1;
			if (val2 != null)
			{
				((ButtonBase)val2).Click -= val;
			}
			button_1 = value;
			val2 = button_1;
			if (val2 != null)
			{
				((ButtonBase)val2).Click += val;
			}
		}
	}

	public ScenarioFeatures()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += new RoutedEventHandler(ScenarioFeatures_Loaded);
		((UIElement)this).KeyDown += new KeyEventHandler(ScenarioFeatures_KeyDown);
		((Window)this).Closing += ScenarioFeatures_Closing;
		InitializeComponent();
	}

	private void ScenarioFeatures_Loaded(object sender, RoutedEventArgs e)
	{
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		if (!Client.AllowEditModeActions)
		{
			((UIElement)Button_OK).Visibility = (Visibility)2;
			((UIElement)Button_Cancel).Visibility = (Visibility)2;
			((UIElement)CB_GunfireControl).IsEnabled = false;
			((UIElement)CB_UnlimitedBaseMags).IsEnabled = false;
			((UIElement)CB_LimitedSonobuoys).IsEnabled = false;
			((UIElement)CB_CommsJamming).IsEnabled = false;
			((UIElement)CB_CommsDisruption).IsEnabled = false;
			((UIElement)CB_ACDamage).IsEnabled = false;
		}
		else
		{
			if (!GameGeneral.Beta_PlatformComms)
			{
				((UIElement)CB_PointToPointComm).Visibility = (Visibility)2;
				((ToggleButton)CB_PointToPointComm).IsChecked = false;
			}
			else
			{
				((ToggleButton)CB_PointToPointComm).IsChecked = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.PointToPointComm);
				((FrameworkElement)CB_PointToPointComm).ToolTip = Misc.ToEnglishString(Scenario.ScenarioFeatureOption.PointToPointComm);
			}
			((UIElement)CB_RealisticOrderChain).Visibility = (Visibility)2;
			((ToggleButton)CB_RealisticOrderChain).IsChecked = false;
			((UIElement)Button_OK).Visibility = (Visibility)0;
			((UIElement)Button_Cancel).Visibility = (Visibility)0;
			((UIElement)CB_GunfireControl).IsEnabled = true;
			((UIElement)CB_UnlimitedBaseMags).IsEnabled = true;
			int theFeature;
			if (Licensing.UserHasLicenseForThisFeature(Scenario.ScenarioFeatureOption.AircraftDamage))
			{
				((UIElement)CB_ACDamage).IsEnabled = true;
				((Control)((ContentControl)CB_ACDamage).Content).Foreground = (Brush)(object)Brushes.White;
				theFeature = 6;
			}
			else
			{
				((UIElement)CB_ACDamage).IsEnabled = false;
				((Control)((ContentControl)CB_ACDamage).Content).Foreground = (Brush)(object)Brushes.Gray;
				theFeature = 6;
			}
			int theFeature2;
			if (Licensing.UserHasLicenseForThisFeature((Scenario.ScenarioFeatureOption)theFeature))
			{
				((UIElement)CB_CommsDisruption).IsEnabled = true;
				((Control)((ContentControl)CB_CommsDisruption).Content).Foreground = (Brush)(object)Brushes.White;
				theFeature2 = 5;
			}
			else
			{
				((UIElement)CB_CommsDisruption).IsEnabled = false;
				((Control)((ContentControl)CB_CommsDisruption).Content).Foreground = (Brush)(object)Brushes.Gray;
				theFeature2 = 5;
			}
			if (!Licensing.UserHasLicenseForThisFeature((Scenario.ScenarioFeatureOption)theFeature2))
			{
				((UIElement)CB_CommsJamming).Visibility = (Visibility)2;
			}
			else
			{
				((UIElement)CB_CommsJamming).Visibility = (Visibility)0;
			}
		}
		((ToggleButton)CB_GunfireControl).IsChecked = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DetailedGunFireControl);
		((FrameworkElement)CB_GunfireControl).ToolTip = Misc.ToEnglishString(Scenario.ScenarioFeatureOption.DetailedGunFireControl);
		((ToggleButton)CB_UnlimitedBaseMags).IsChecked = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines);
		((FrameworkElement)CB_UnlimitedBaseMags).ToolTip = Misc.ToEnglishString(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines);
		((ToggleButton)CB_RealisticSubComms).IsChecked = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.RealisticSubComms);
		((FrameworkElement)CB_RealisticSubComms).ToolTip = Misc.ToEnglishString(Scenario.ScenarioFeatureOption.RealisticSubComms);
		((ToggleButton)CB_TerrainTypeEffects).IsChecked = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LandTypeEffects);
		((FrameworkElement)CB_TerrainTypeEffects).ToolTip = Misc.ToEnglishString(Scenario.ScenarioFeatureOption.LandTypeEffects);
		((ToggleButton)CB_TerrainTypeEffects_Advanced).IsChecked = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LandTypeEffects_Advanced);
		((FrameworkElement)CB_TerrainTypeEffects_Advanced).ToolTip = Misc.ToEnglishString(Scenario.ScenarioFeatureOption.LandTypeEffects_Advanced);
		((ToggleButton)CB_CommsJamming).IsChecked = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.CommsJamming);
		((FrameworkElement)CB_CommsJamming).ToolTip = Misc.ToEnglishString(Scenario.ScenarioFeatureOption.CommsJamming);
		((ToggleButton)CB_CommsDisruption).IsChecked = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.CommsDisruption);
		((FrameworkElement)CB_CommsDisruption).ToolTip = Misc.ToEnglishString(Scenario.ScenarioFeatureOption.CommsDisruption);
		((ToggleButton)CB_ACDamage).IsChecked = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.AircraftDamage);
		((FrameworkElement)CB_ACDamage).ToolTip = Misc.ToEnglishString(Scenario.ScenarioFeatureOption.AircraftDamage);
		((ToggleButton)CB_WeatherAffectsShipSpeed).IsChecked = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.WeatherAffectsShipSpeed);
		((FrameworkElement)CB_WeatherAffectsShipSpeed).ToolTip = Misc.ToEnglishString(Scenario.ScenarioFeatureOption.WeatherAffectsShipSpeed);
		((ToggleButton)CB_LandingPlannerInstantLoading).IsChecked = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.AllowLandingPlannerInstantLoading);
		((FrameworkElement)CB_LandingPlannerInstantLoading).ToolTip = Misc.ToEnglishString(Scenario.ScenarioFeatureOption.AllowLandingPlannerInstantLoading);
		((ToggleButton)CB_AC_NAW_Loadout).IsChecked = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.ACS_NAW_Limitations);
		((FrameworkElement)CB_AC_NAW_Loadout).ToolTip = Misc.ToEnglishString(Scenario.ScenarioFeatureOption.ACS_NAW_Limitations);
		((ToggleButton)CB_DroneAutonomy).IsChecked = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DroneAutonomyLevels);
		((FrameworkElement)CB_DroneAutonomy).ToolTip = Misc.ToEnglishString(Scenario.ScenarioFeatureOption.DroneAutonomyLevels);
		((ToggleButton)CB_ASCMTerrainFollowing).IsChecked = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.ASCMTerrainFollowingRestriction);
		((FrameworkElement)CB_ASCMTerrainFollowing).ToolTip = Misc.ToEnglishString(Scenario.ScenarioFeatureOption.ASCMTerrainFollowingRestriction);
		((ToggleButton)CB_VariableBurnoutSpeed).IsChecked = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.VariableBurnoutSpeed);
		((FrameworkElement)CB_VariableBurnoutSpeed).ToolTip = Misc.ToEnglishString(Scenario.ScenarioFeatureOption.VariableBurnoutSpeed);
		if (((ToggleButton)CB_UnlimitedBaseMags).IsChecked == true)
		{
			((ToggleButton)CB_LimitedSonobuoys).IsChecked = false;
			((UIElement)CB_LimitedSonobuoys).IsEnabled = false;
		}
		else
		{
			((ToggleButton)CB_LimitedSonobuoys).IsChecked = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LimitedSonobuoysInMagazines);
			((UIElement)CB_LimitedSonobuoys).IsEnabled = true;
		}
		((FrameworkElement)CB_LimitedSonobuoys).ToolTip = Misc.ToEnglishString(Scenario.ScenarioFeatureOption.LimitedSonobuoysInMagazines);
		((FrameworkElement)this).Height = ((FrameworkElement)StackPanel1).Height + 5.0;
	}

	private void method_0(object sender, RoutedEventArgs e)
	{
		//IL_0348: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0538: Unknown result type (might be due to invalid IL or missing references)
		if (((ToggleButton)CB_GunfireControl).IsChecked != true)
		{
			Client.CurrentScenario.DeclaredFeatures.Remove(Scenario.ScenarioFeatureOption.DetailedGunFireControl);
		}
		else
		{
			Client.CurrentScenario.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.DetailedGunFireControl);
		}
		if (((ToggleButton)CB_UnlimitedBaseMags).IsChecked == true)
		{
			Client.CurrentScenario.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines);
			((ToggleButton)CB_LimitedSonobuoys).IsChecked = false;
		}
		else
		{
			Client.CurrentScenario.DeclaredFeatures.Remove(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines);
		}
		string text = "";
		if (((ToggleButton)CB_RealisticSubComms).IsChecked == true)
		{
			if (!Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.RealisticSubComms))
			{
				text = "Enabling 'Realistic Sub Communications' has changed the default WRA Doctrine for new missions that target submarines to 'Tight' to prevent friendly fire. Existing missions have not been changed.";
			}
			Client.CurrentScenario.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.RealisticSubComms);
		}
		else
		{
			if (Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.RealisticSubComms))
			{
				text = "Disabling 'Realistic Sub Communications' has changed the default WRA Doctrine for new missions that target submarines to 'Free.' Existing missions have not been changed.";
			}
			Client.CurrentScenario.DeclaredFeatures.Remove(Scenario.ScenarioFeatureOption.RealisticSubComms);
		}
		if (((ToggleButton)CB_TerrainTypeEffects).IsChecked == true)
		{
			Client.CurrentScenario.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.LandTypeEffects);
		}
		else
		{
			Client.CurrentScenario.DeclaredFeatures.Remove(Scenario.ScenarioFeatureOption.LandTypeEffects);
		}
		if (((ToggleButton)CB_TerrainTypeEffects_Advanced).IsChecked != true)
		{
			Client.CurrentScenario.DeclaredFeatures.Remove(Scenario.ScenarioFeatureOption.LandTypeEffects_Advanced);
		}
		else
		{
			Client.CurrentScenario.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.LandTypeEffects_Advanced);
		}
		if (((ToggleButton)CB_CommsJamming).IsChecked == true)
		{
			Client.CurrentScenario.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.CommsJamming);
		}
		else
		{
			Client.CurrentScenario.DeclaredFeatures.Remove(Scenario.ScenarioFeatureOption.CommsJamming);
		}
		if (((ToggleButton)CB_ACDamage).IsChecked != true)
		{
			Client.CurrentScenario.DeclaredFeatures.Remove(Scenario.ScenarioFeatureOption.AircraftDamage);
		}
		else
		{
			Client.CurrentScenario.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.AircraftDamage);
		}
		if (((ToggleButton)CB_WeatherAffectsShipSpeed).IsChecked != true)
		{
			Client.CurrentScenario.DeclaredFeatures.Remove(Scenario.ScenarioFeatureOption.WeatherAffectsShipSpeed);
		}
		else
		{
			Client.CurrentScenario.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.WeatherAffectsShipSpeed);
		}
		if (((ToggleButton)CB_LandingPlannerInstantLoading).IsChecked == true)
		{
			Client.CurrentScenario.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.AllowLandingPlannerInstantLoading);
		}
		else
		{
			Client.CurrentScenario.DeclaredFeatures.Remove(Scenario.ScenarioFeatureOption.AllowLandingPlannerInstantLoading);
		}
		if (((ToggleButton)CB_CommsDisruption).IsChecked != true)
		{
			Client.CurrentScenario.DeclaredFeatures.Remove(Scenario.ScenarioFeatureOption.CommsDisruption);
		}
		else
		{
			Client.CurrentScenario.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.CommsDisruption);
		}
		if (((ToggleButton)CB_AC_NAW_Loadout).IsChecked == true)
		{
			Client.CurrentScenario.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.ACS_NAW_Limitations);
		}
		else
		{
			Client.CurrentScenario.DeclaredFeatures.Remove(Scenario.ScenarioFeatureOption.ACS_NAW_Limitations);
		}
		if (((ToggleButton)CB_DroneAutonomy).IsChecked != true)
		{
			Client.CurrentScenario.DeclaredFeatures.Remove(Scenario.ScenarioFeatureOption.DroneAutonomyLevels);
		}
		else
		{
			Client.CurrentScenario.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.DroneAutonomyLevels);
		}
		if (((ToggleButton)CB_PointToPointComm).IsChecked == true)
		{
			Client.CurrentScenario.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.PointToPointComm);
			if (Client.PlayerWantsFullNetwork())
			{
				Client.CurrentScenario.FullNetworkGeneration();
				DarkMessageBox.ShowInformation("Full network generation executed for all Sides", "Completed");
			}
		}
		else
		{
			Client.CurrentScenario.DeclaredFeatures.Remove(Scenario.ScenarioFeatureOption.PointToPointComm);
		}
		if (((ToggleButton)CB_RealisticOrderChain).IsChecked == true)
		{
			if (!Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.PointToPointComm))
			{
				Client.CurrentScenario.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.PointToPointComm);
			}
			Client.CurrentScenario.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.RealisticOrderChain);
			DarkMessageBox.ShowInformation("An HQ for every Side must be defined for the scenario to properly work, to do that right click on the designated unit and select 'Set as HQ'", "Realistic Order Chain Enabled");
		}
		else
		{
			Client.CurrentScenario.DeclaredFeatures.Remove(Scenario.ScenarioFeatureOption.RealisticOrderChain);
			Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
			_Closure$__2-0 closure$__2- = default(_Closure$__2-0);
			for (int i = 0; i < sides_ReadOnly.Length; i = checked(i + 1))
			{
				closure$__2- = new _Closure$__2-0(closure$__2-);
				closure$__2-.$VB$Local_theSide = sides_ReadOnly[i];
				if (closure$__2-.$VB$Local_theSide.HQ_ID == null)
				{
					closure$__2-.$VB$Local_theSide.Units.Where(closure$__2-._Lambda$__0).FirstOrDefault()?.Name.Replace(GameGeneral.HQString, "");
				}
				closure$__2-.$VB$Local_theSide.HQ_ID = null;
			}
		}
		if (((ToggleButton)CB_ASCMTerrainFollowing).IsChecked != true)
		{
			Client.CurrentScenario.DeclaredFeatures.Remove(Scenario.ScenarioFeatureOption.ASCMTerrainFollowingRestriction);
		}
		else
		{
			Client.CurrentScenario.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.ASCMTerrainFollowingRestriction);
		}
		if (((ToggleButton)CB_VariableBurnoutSpeed).IsChecked != true)
		{
			Client.CurrentScenario.DeclaredFeatures.Remove(Scenario.ScenarioFeatureOption.VariableBurnoutSpeed);
		}
		else
		{
			Client.CurrentScenario.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.VariableBurnoutSpeed);
		}
		if (((ToggleButton)CB_LimitedSonobuoys).IsChecked != true)
		{
			Client.CurrentScenario.DeclaredFeatures.Remove(Scenario.ScenarioFeatureOption.LimitedSonobuoysInMagazines);
		}
		else
		{
			Client.CurrentScenario.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.LimitedSonobuoysInMagazines);
		}
		MyProject.Forms.MainForm.AdjustToScenActiveFeatureChanges();
		((Window)this).Close();
		if (Operators.CompareString(text, "", true) != 0)
		{
			DarkMessageBox.ShowWarning(text, "");
		}
	}

	private void method_1(object sender, RoutedEventArgs e)
	{
		((Window)this).Close();
	}

	private void method_2(object sender, RoutedEventArgs e)
	{
		((ToggleButton)CB_LimitedSonobuoys).IsChecked = false;
		((UIElement)CB_LimitedSonobuoys).IsEnabled = false;
	}

	private void method_3(object sender, RoutedEventArgs e)
	{
		((UIElement)CB_LimitedSonobuoys).IsEnabled = true;
	}

	private void method_4()
	{
		if (((UIElement)CB_LimitedSonobuoys).IsEnabled)
		{
			((Control)LB_LimitedSonobuoys).Foreground = (Brush)(object)Brushes.White;
		}
		else
		{
			((Control)LB_LimitedSonobuoys).Foreground = (Brush)(object)Brushes.Gray;
		}
	}

	private void ScenarioFeatures_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Invalid comparison between Unknown and I4
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.Key == 27 && (int)((UIElement)this).Visibility == 0)
		{
			((Window)this).Close();
		}
		else if ((int)e.Key == 32)
		{
			_ = ((UIElement)this).Visibility;
		}
	}

	private void ScenarioFeatures_Closing(object sender, CancelEventArgs e)
	{
		MyProject.Forms.MainForm.UpdateMenusVisibility();
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void method_5(object sender, RoutedEventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (((ToggleButton)CB_ACDamage).IsChecked == true)
		{
			DarkMessageBox.ShowWarning("It appears that you are activating the 'Aircraft Damage' feature. If this scenario has been built prior to v1.12 and not been rebuilt afterwards, it is likely that one or more aircraft will not have their proper DP values set, and may immediately appear as damaged or even destroyed when the scenario runs. Please ensure that the scenario is deep-rebuilt prior to testing & release.", "CAUTION!");
		}
	}

	private void method_6(object sender, RoutedEventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (((ToggleButton)CB_AC_NAW_Loadout).IsChecked == true)
		{
			DarkMessageBox.ShowWarning("It appears that you are activating the 'Aircraft Loadout weather TOD limitation' feature. If this scenario has been built prior to the introduction of this feature, it is likely that one or more aircraft will not take off due to their loadout not being able to fly during night time or in heavy rain. This might also lead some aircraft to crash when landing if they are trying to do that in unfavourable conditions. This could lead to losing them and to serious damage to the runway", "CAUTION!");
		}
	}

	private void method_7(object sender, RoutedEventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (((ToggleButton)CB_PointToPointComm).IsChecked == true)
		{
			DarkMessageBox.ShowWarning("It appears that you are activating the 'Point to Point Communication overhaul' feature. If this scenario has been built prior to the introduction of this feature, it is likely that the scenario was not designed with such a feature in mind, this can cause your experience to be significantly different then the one originally designed", "CAUTION!");
		}
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!bool_0)
		{
			bool_0 = true;
			Uri uri = new Uri("/Command;component/forms/scenario/scenariofeatures.xaml", UriKind.Relative);
			Application.LoadComponent((object)this, uri);
		}
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Expected O, but got Unknown
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			StackPanel1 = (StackPanel)target;
			break;
		case 2:
			CB_GunfireControl = (CheckBox)target;
			break;
		case 3:
			CB_UnlimitedBaseMags = (CheckBox)target;
			break;
		case 4:
			CB_ACDamage = (CheckBox)target;
			break;
		case 5:
			CB_RealisticSubComms = (CheckBox)target;
			break;
		case 6:
			CB_TerrainTypeEffects = (CheckBox)target;
			break;
		case 7:
			CB_TerrainTypeEffects_Advanced = (CheckBox)target;
			break;
		case 8:
			CB_CommsDisruption = (CheckBox)target;
			break;
		case 9:
			CB_CommsJamming = (CheckBox)target;
			break;
		case 10:
			CB_WeatherAffectsShipSpeed = (CheckBox)target;
			break;
		case 11:
			CB_LandingPlannerInstantLoading = (CheckBox)target;
			break;
		case 12:
			CB_AC_NAW_Loadout = (CheckBox)target;
			break;
		case 13:
			CB_DroneAutonomy = (CheckBox)target;
			break;
		case 14:
			CB_ASCMTerrainFollowing = (CheckBox)target;
			break;
		case 15:
			CB_PointToPointComm = (CheckBox)target;
			break;
		case 16:
			CB_RealisticOrderChain = (CheckBox)target;
			break;
		case 17:
			CB_VariableBurnoutSpeed = (CheckBox)target;
			break;
		case 18:
			CB_LimitedSonobuoys = (CheckBox)target;
			break;
		case 19:
			LB_LimitedSonobuoys = (Label)target;
			break;
		case 20:
			Button_OK = (Button)target;
			break;
		case 21:
			Button_Cancel = (Button)target;
			break;
		default:
			bool_0 = true;
			break;
		}
	}

	static ScenarioFeatures()
	{
		Class72.smethod_20();
	}
}
