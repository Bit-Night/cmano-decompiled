using System.Runtime.CompilerServices;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using Command.My;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotPrune]
[DoNotPruneType]
[DoNotObfuscate]
public sealed class RecentDetectionViewModel : CommandViewModel
{
	private string string_0;

	private int int_0;

	private string string_1;

	private string string_2;

	private int int_1;

	private long long_0;

	private string string_3;

	private string string_4;

	private string string_5;

	[CompilerGenerated]
	private RelayCommand relayCommand_0;

	[CompilerGenerated]
	private RelayCommand relayCommand_1;

	public string SensorName
	{
		get
		{
			return string_0;
		}
		set
		{
			SetProperty(ref string_0, value, "SensorName");
		}
	}

	public int SensorDBID
	{
		get
		{
			return int_0;
		}
		set
		{
			SetProperty(ref int_0, value, "SensorDBID");
		}
	}

	public string PlatformGUID
	{
		get
		{
			return string_1;
		}
		set
		{
			SetProperty(ref string_1, value, "PlatformGUID");
		}
	}

	public string PlatformName
	{
		get
		{
			return string_2;
		}
		set
		{
			SetProperty(ref string_2, value, "PlatformName");
		}
	}

	public int PlatformDBID
	{
		get
		{
			return int_1;
		}
		set
		{
			SetProperty(ref int_1, value, "PlatformDBID");
		}
	}

	public long TimeSinceDetection
	{
		get
		{
			return long_0;
		}
		set
		{
			SetProperty(ref long_0, value, "TimeSinceDetection");
		}
	}

	public string TimeSinceDetection_String
	{
		get
		{
			return string_3;
		}
		set
		{
			SetProperty(ref string_3, value, "TimeSinceDetection_String");
		}
	}

	public string DetectionRange_String
	{
		get
		{
			return string_4;
		}
		set
		{
			SetProperty(ref string_4, value, "DetectionRange_String");
		}
	}

	public string CoreUnitGUID
	{
		get
		{
			return string_5;
		}
		set
		{
			SetProperty(ref string_5, value, "CoreUnitGUID");
		}
	}

	public RelayCommand SensorClickCommand
	{
		[CompilerGenerated]
		get
		{
			return relayCommand_0;
		}
		[CompilerGenerated]
		set
		{
			relayCommand_0 = value;
		}
	}

	public RelayCommand PlatformClickCommand
	{
		[CompilerGenerated]
		get
		{
			return relayCommand_1;
		}
		[CompilerGenerated]
		set
		{
			relayCommand_1 = value;
		}
	}

	public void SensorClick(object obj)
	{
		if (string.IsNullOrEmpty(PlatformGUID))
		{
			return;
		}
		ActiveUnit activeUnit = null;
		foreach (ActiveUnit activeUnits_ in Client.CurrentScenario.ActiveUnits_List)
		{
			if (activeUnits_ != null && Operators.CompareString(activeUnits_.ObjectID, PlatformGUID, true) == 0)
			{
				activeUnit = activeUnits_;
				break;
			}
		}
		if (activeUnit == null && Operators.CompareString(CoreUnitGUID, "", true) != 0)
		{
			foreach (ActiveUnit activeUnits_2 in Client.CurrentScenario.ActiveUnits_List)
			{
				if (activeUnits_2 != null && Operators.CompareString(activeUnits_2.ObjectID, CoreUnitGUID, true) == 0)
				{
					activeUnit = activeUnits_2;
					break;
				}
			}
			if (activeUnit != null)
			{
				if (activeUnit.IsAircraft && ((Aircraft)activeUnit).LoadoutDBID > 0)
				{
					Client.smethod_18(activeUnit, "Loadout" + Conversions.ToString(((Aircraft)activeUnit).LoadoutDBID));
				}
				else
				{
					Client.smethod_18(activeUnit);
				}
				return;
			}
		}
		if (activeUnit != null)
		{
			Client.smethod_18(activeUnit, "Sensor" + Conversions.ToString(SensorDBID));
		}
	}

	public void PlatformClick(object obj)
	{
		if (string.IsNullOrEmpty(PlatformGUID))
		{
			return;
		}
		ActiveUnit activeUnit = null;
		foreach (ActiveUnit activeUnits_ in Client.CurrentScenario.ActiveUnits_List)
		{
			if (activeUnits_ != null && Operators.CompareString(activeUnits_.ObjectID, PlatformGUID, true) == 0)
			{
				activeUnit = activeUnits_;
				break;
			}
		}
		if (activeUnit == null && Operators.CompareString(CoreUnitGUID, "", true) != 0)
		{
			foreach (ActiveUnit activeUnits_2 in Client.CurrentScenario.ActiveUnits_List)
			{
				if (activeUnits_2 != null && Operators.CompareString(activeUnits_2.ObjectID, CoreUnitGUID, true) == 0)
				{
					activeUnit = activeUnits_2;
					break;
				}
			}
			if (activeUnit != null)
			{
				if (activeUnit.IsAircraft && ((Aircraft)activeUnit).LoadoutDBID > 0)
				{
					Client.smethod_18(activeUnit, "Loadout" + Conversions.ToString(((Aircraft)activeUnit).LoadoutDBID));
				}
				else
				{
					Client.smethod_18(activeUnit);
				}
				return;
			}
		}
		if (activeUnit != null)
		{
			MyProject.Forms.MainForm.set_MapCenter(MustRender: true, new GeoPoint(activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
			Client.SelectThisUnit(activeUnit, ThisUnitOnly: true);
		}
	}

	public RecentDetectionViewModel()
	{
		SensorClickCommand = new RelayCommand(SensorClick);
		PlatformClickCommand = new RelayCommand(PlatformClick);
	}

	static RecentDetectionViewModel()
	{
		Class72.smethod_20();
	}
}
