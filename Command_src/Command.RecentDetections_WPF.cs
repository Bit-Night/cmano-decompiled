using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class RecentDetections_WPF : UserControl, IComponentConnector
{
	[CompilerGenerated]
	internal sealed class _Closure$__2-0
	{
		public Contact.Detection_Struct $VB$Local_theDetectionRecord;

		public _Closure$__2-0(_Closure$__2-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theDetectionRecord = arg0.$VB$Local_theDetectionRecord;
			}
		}

		[SpecialName]
		internal bool _Lambda$__1(Sensor theS)
		{
			return Operators.CompareString(theS?.ObjectID, $VB$Local_theDetectionRecord.DetectingSensorID, true) == 0;
		}

		static _Closure$__2-0()
		{
			Class72.smethod_20();
		}
	}

	private ObservableCollection<RecentDetectionViewModel> observableCollection_0;

	private bool bool_0;

	public RecentDetections_WPF()
	{
		observableCollection_0 = new ObservableCollection<RecentDetectionViewModel>();
		InitializeComponent();
		((FrameworkElement)this).DataContext = new AllRecentDetectionsViewModel
		{
			Items = observableCollection_0
		};
	}

	public void RefreshPanel(Contact theContact, Scenario theScen)
	{
		try
		{
			if (theContact != null)
			{
				if (theContact.LastDetections.Count != 0)
				{
					List<Contact.Detection_Struct> source = new List<Contact.Detection_Struct>(theContact.LastDetections);
					source = source.OrderByDescending([SpecialName] (Contact.Detection_Struct theRec) => theRec.theTime).ToList();
					int num = Math.Min(20, source.Count);
					while (observableCollection_0.Count < num)
					{
						observableCollection_0.Add(new RecentDetectionViewModel());
					}
					while (observableCollection_0.Count > num)
					{
						observableCollection_0.Remove(observableCollection_0.Last());
					}
					int num2 = num - 1;
					_Closure$__2-0 closure$__2- = default(_Closure$__2-0);
					for (int num3 = 0; num3 <= num2; num3++)
					{
						closure$__2- = new _Closure$__2-0(closure$__2-);
						closure$__2-.$VB$Local_theDetectionRecord = source[num3];
						ActiveUnit activeUnit = null;
						Sensor sensor = null;
						if (!string.IsNullOrEmpty(closure$__2-.$VB$Local_theDetectionRecord.DetectorUnitID) && Client.CurrentScenario.ActiveUnits.ContainsKey(closure$__2-.$VB$Local_theDetectionRecord.DetectorUnitID))
						{
							activeUnit = Client.CurrentScenario.ActiveUnits[closure$__2-.$VB$Local_theDetectionRecord.DetectorUnitID];
							sensor = activeUnit.Sensors_ReadOnly().Where(closure$__2-._Lambda$__1).FirstOrDefault();
						}
						float rangeEstimate = closure$__2-.$VB$Local_theDetectionRecord.RangeEstimate;
						ActiveUnit_Sensory.SpecialDetectionMode theDetectionMode = closure$__2-.$VB$Local_theDetectionRecord.theDetectionMode;
						DateTime theTime = closure$__2-.$VB$Local_theDetectionRecord.theTime;
						RecentDetectionViewModel recentDetectionViewModel = observableCollection_0[num3];
						if (sensor == null)
						{
							recentDetectionViewModel.PlatformName = "[Unknown]";
							if (activeUnit != null)
							{
								recentDetectionViewModel.PlatformDBID = activeUnit.DBID;
								recentDetectionViewModel.PlatformName = activeUnit.Name;
								recentDetectionViewModel.PlatformGUID = activeUnit.ObjectID;
							}
							recentDetectionViewModel.SensorName = "[Unknown]";
							switch (theDetectionMode)
							{
							case ActiveUnit_Sensory.SpecialDetectionMode.SubAssumedFromTorpedoDetection:
								recentDetectionViewModel.SensorName = "POSSUB from torpedo detection";
								break;
							case ActiveUnit_Sensory.SpecialDetectionMode.SubAssumedFromMissileDetection:
								recentDetectionViewModel.SensorName = "POSSUB from missile detection";
								break;
							case ActiveUnit_Sensory.SpecialDetectionMode.FlamingDatum:
								recentDetectionViewModel.SensorName = "POSSUB from torpedo detonation (flaming datum)";
								break;
							case ActiveUnit_Sensory.SpecialDetectionMode.AutoDetection:
								recentDetectionViewModel.SensorName = "Automatic detection";
								break;
							case ActiveUnit_Sensory.SpecialDetectionMode.MissileAssumedFromSemiActiveIllumination:
								recentDetectionViewModel.SensorName = "Possible missile from semi-active illumination detection.";
								break;
							case ActiveUnit_Sensory.SpecialDetectionMode.CounterBatteryTrack:
								recentDetectionViewModel.SensorName = "Probable artillery (counter-battery detection)";
								break;
							case ActiveUnit_Sensory.SpecialDetectionMode.ContactSharing:
								recentDetectionViewModel.SensorName = "Contact sharing [" + closure$__2-.$VB$Local_theDetectionRecord.DetectorUnitID + "]";
								break;
							}
						}
						else
						{
							recentDetectionViewModel.SensorDBID = sensor.DBID;
							recentDetectionViewModel.SensorName = sensor.Name;
							if (activeUnit != null)
							{
								recentDetectionViewModel.CoreUnitGUID = activeUnit.ObjectID;
							}
							else
							{
								recentDetectionViewModel.CoreUnitGUID = "";
							}
							activeUnit = sensor.ParentPlatform;
							if (activeUnit.IsWeapon)
							{
								Weapon weapon = (Weapon)activeUnit;
								if (weapon.AttachedTo != null)
								{
									activeUnit = weapon.AttachedTo;
								}
							}
							if (activeUnit != null)
							{
								recentDetectionViewModel.PlatformDBID = activeUnit.DBID;
								recentDetectionViewModel.PlatformName = activeUnit.Name;
								recentDetectionViewModel.PlatformGUID = activeUnit.ObjectID;
							}
						}
						if (theContact.UncertaintyArea != null)
						{
							if (sensor == null)
							{
								recentDetectionViewModel.DetectionRange_String = "Unknown";
							}
							else
							{
								recentDetectionViewModel.DetectionRange_String = "Estimated " + $"{sensor.ParentPlatform.RangeToUnit_Horiz(theContact):0.0}" + "nm";
							}
						}
						else
						{
							recentDetectionViewModel.DetectionRange_String = $"{rangeEstimate:0.0}" + "nm";
						}
						recentDetectionViewModel.DetectionRange_String = " - Range: " + recentDetectionViewModel.DetectionRange_String;
						recentDetectionViewModel.TimeSinceDetection = Math.Max((long)Math.Round((Client.CurrentScenario.Time - theTime).TotalSeconds), 0L);
						recentDetectionViewModel.TimeSinceDetection_String = Misc.TimeString(recentDetectionViewModel.TimeSinceDetection, 0, ReturnNo: false, ReturnZero: true) + " ago ";
						switch (theDetectionMode)
						{
						case ActiveUnit_Sensory.SpecialDetectionMode.AutoDetection:
							recentDetectionViewModel.TimeSinceDetection_String = null;
							recentDetectionViewModel.DetectionRange_String = null;
							break;
						case ActiveUnit_Sensory.SpecialDetectionMode.ContactSharing:
							recentDetectionViewModel.DetectionRange_String = null;
							break;
						}
					}
				}
				else if (observableCollection_0.Count > 0)
				{
					observableCollection_0.Clear();
				}
			}
			else
			{
				observableCollection_0.Clear();
				((UIElement)this).Visibility = (Visibility)2;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!bool_0)
		{
			bool_0 = true;
			Uri uri = new Uri("/Command;component/customcontrols/rightcolumn/recentdetections_wpf.xaml", UriKind.Relative);
			Application.LoadComponent((object)this, uri);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
	{
		bool_0 = true;
	}

	static RecentDetections_WPF()
	{
		Class72.smethod_20();
	}
}
