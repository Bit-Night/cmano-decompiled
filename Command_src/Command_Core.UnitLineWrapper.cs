using System;
using System.Collections.Generic;
using Command_Core.SmartAssembly.Attributes;

namespace Command_Core;

[DoNotObfuscateType]
[DoNotPrune]
[DoNotPruneType]
public class UnitLineWrapper
{
	public ChalkUnit ChalkUnit;

	private bool bool_0;

	public int Index;

	public string Priority
	{
		get
		{
			if (bool_0)
			{
				return "";
			}
			return ChalkUnit.AssociatedChalk.Priority.ToString();
		}
		set
		{
			int.TryParse(value, out ChalkUnit.AssociatedChalk.Priority);
		}
	}

	public string CurrentTransport
	{
		get
		{
			if (ChalkUnit.TransportErrorMessage.Length > 0)
			{
				return ChalkUnit.TransportErrorMessage;
			}
			if (ChalkUnit.AssociatedChalk.Preboat == null)
			{
				if (ChalkUnit.CurrentTransport != null)
				{
					if (ChalkUnit.CurrentTransport.ActualTransport == null)
					{
						return "None";
					}
					(float, float, float) unitAllocationProportion = ChalkUnit.CurrentTransport.GetUnitAllocationProportion(ChalkUnit);
					return ChalkUnit.CurrentTransport.ActualTransport.Name + " (" + (int)Math.Round(unitAllocationProportion.Item1 * 100f) + "%, " + (int)Math.Round(unitAllocationProportion.Item2 * 100f) + " %," + (int)Math.Round(unitAllocationProportion.Item3 * 100f) + " %)";
				}
				return "None";
			}
			return ChalkUnit.AssociatedChalk.Preboat.ActualTransport.Name + " Preboated";
		}
	}

	public string Serial
	{
		get
		{
			if (!bool_0)
			{
				string text = "";
				int num;
				if (ChalkUnit.AssociatedChalk.ID == -1)
				{
					text = "Pre-Boated";
					num = 8;
				}
				else
				{
					text = ChalkUnit.AssociatedChalk.ID.ToString();
					num = 8;
				}
				string[] array = new string[num];
				array[0] = text;
				array[1] = "  ( ";
				array[2] = Math.Round(ChalkUnit.AssociatedChalk.GetMass(), 1).ToString();
				array[3] = " | ";
				array[4] = Math.Round(ChalkUnit.AssociatedChalk.GetArea(), 1).ToString();
				array[5] = " | ";
				array[6] = Math.Round(ChalkUnit.AssociatedChalk.GetCrew(), 1).ToString();
				array[7] = " )";
				return string.Concat(array);
			}
			return "";
		}
	}

	public string Unit
	{
		get
		{
			return ChalkUnit.Unit.CargoObjectName;
		}
		set
		{
		}
	}

	public int Wave
	{
		get
		{
			if (ChalkUnit.AssociatedChalk.Preboat != null)
			{
				return 1;
			}
			return ChalkUnit.Wave;
		}
		set
		{
			ChalkUnit.Wave = value;
		}
	}

	public UnitLineWrapper(Chalk _tChalk, Cargo _tChalkUnit, int _tPriority, int _tWave, ActiveUnit _tCurrentTransport, bool _isSubEntry, Dictionary<string, TransportAvailability> AllowedTransports, LandingZoneWrapper _LandingZoneWrapper, int _Index)
	{
		Index = _Index;
		bool_0 = _isSubEntry;
		ChalkUnit = new ChalkUnit(_tChalk, _tChalkUnit, _tPriority, _tWave, _tCurrentTransport, _isSubEntry, _LandingZoneWrapper);
		foreach (KeyValuePair<string, TransportAvailability> AllowedTransport in AllowedTransports)
		{
			ChalkUnit.TransportAvailable.Add(AllowedTransport.Key, AllowedTransport.Value);
		}
	}

	static UnitLineWrapper()
	{
		Class72.smethod_20();
	}
}
