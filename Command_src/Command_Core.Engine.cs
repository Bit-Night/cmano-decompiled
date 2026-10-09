using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Xml;
using Command_Core.DAL;
using Cysharp.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Engine : PlatformComponent
{
	public enum EngineType : short
	{
		None = 1001,
		Turbojet = 2001,
		Turbofan = 2002,
		Turboprop = 2003,
		Piston = 2004,
		Turboshaft = 2005,
		Diesel = 3001,
		Steam = 3002,
		Gas_Turbine = 3003,
		Nuclear = 3004,
		PumpJet = 3005,
		Gasoline = 3006,
		Electric = 4001,
		AIP = 4002,
		Rocket_BoostCoast = 5001,
		Torpedo = 5002,
		WeaponCoast = 5003,
		Rocket_LongBurn = 5004,
		Ramjet = 5005,
		Torpedo_ThermalCombustion = 6001,
		Torpedo_ThermalClosedCycle = 6002,
		Torpedo_Electric = 6003
	}

	public EngineType Type;

	public AltBand[] AltBands;

	public bool Hypothetical;

	internal AltBand HighestAltBand;

	public AltBand OptimumAltBandForThisThrottle
	{
		get
		{
			AltBand result = null;
			double num = double.MinValue;
			int num2 = AltBands.Count() - 1;
			for (int i = 0; i <= num2; i++)
			{
				AltBand altBand = AltBands[i];
				double num3;
				switch (theThrottleSetting)
				{
				case ActiveUnit.Throttle.FullStop:
					num3 = ((float)altBand.Speed_Loiter / altBand.Consumption_Full).Value;
					break;
				case ActiveUnit.Throttle.Loiter:
					num3 = (float)altBand.Speed_Loiter / altBand.Consumption_Loiter;
					break;
				case ActiveUnit.Throttle.Cruise:
					num3 = (float)altBand.Speed_Cruise / altBand.Consumption_Cruise;
					break;
				case ActiveUnit.Throttle.Full:
					num3 = ((float?)altBand.Speed_Full / altBand.Consumption_Full).Value;
					break;
				case ActiveUnit.Throttle.Flank:
					num3 = ((float?)altBand.Speed_Flank / altBand.Consumption_Flank).Value;
					break;
				default:
					continue;
				}
				if (num3 > num)
				{
					num = num3;
					result = altBand;
				}
			}
			return result;
		}
	}

	public override void ResetIDs()
	{
		base.ResetIDs();
	}

	public string ToXML(HashSet<string> ObjectsAlreadySerialized)
	{
		Utf16ValueStringBuilder utf16ValueStringBuilder = ZString.CreateStringBuilder();
		try
		{
			utf16ValueStringBuilder.Append("<Engine>");
			utf16ValueStringBuilder.Append("<ID>");
			utf16ValueStringBuilder.Append(ObjectID);
			utf16ValueStringBuilder.Append("</ID>");
			if (ObjectsAlreadySerialized != null)
			{
				if (ObjectsAlreadySerialized.Contains(ObjectID))
				{
					utf16ValueStringBuilder.Append("</Engine>");
					return utf16ValueStringBuilder.ToString();
				}
				ObjectsAlreadySerialized.Add(ObjectID);
			}
			utf16ValueStringBuilder.Append("<DBID>");
			utf16ValueStringBuilder.Append(DBID);
			utf16ValueStringBuilder.Append("</DBID>");
			utf16ValueStringBuilder.Append("<Name>");
			utf16ValueStringBuilder.Append(SecurityElement.Escape(Name.Replace("\u0002", "")));
			utf16ValueStringBuilder.Append("</Name>");
			if (_Status != _ComponentStatus.Operational)
			{
				utf16ValueStringBuilder.Append("<Status>");
				byte status = (byte)_Status;
				utf16ValueStringBuilder.Append(status.ToString());
				utf16ValueStringBuilder.Append("</Status>");
			}
			if (base.DamageSeverity != _DamageSeverityFactor.Light)
			{
				utf16ValueStringBuilder.Append("<DamageSeverity>");
				utf16ValueStringBuilder.Append(((byte)base.DamageSeverity).ToString());
				utf16ValueStringBuilder.Append("</DamageSeverity>");
			}
			utf16ValueStringBuilder.Append("</Engine>");
			string result = utf16ValueStringBuilder.ToString();
			utf16ValueStringBuilder.Dispose();
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100669", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private Engine()
		: base(null)
	{
		AltBands = Array.Empty<AltBand>();
	}

	public static Engine FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theParentPlatform)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		Engine result;
		try
		{
			Engine engine = new Engine();
			engine.ParentPlatform = theParentPlatform;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "Name":
					engine.Name = val.InnerText;
					break;
				case "DamageSeverity":
					engine.DamageSeverity = (_DamageSeverityFactor)Conversions.ToByte(val.InnerText);
					break;
				case "DBID":
				{
					int num = Conversions.ToInteger(val.InnerText);
					Engine engine2;
					ActiveUnit theParentPlatform2 = (engine2 = engine).ParentPlatform;
					Engine engine3 = DBFunctions.GetEngine(num, ref theParentPlatform2);
					engine2.ParentPlatform = theParentPlatform2;
					engine3.ObjectID_Set(engine.ObjectID);
					engine3._Status = engine.Status;
					engine3.Name = engine.Name;
					engine = engine3;
					break;
				}
				case "Status":
					switch (val.InnerText)
					{
					case "Damaged":
						engine._Status = _ComponentStatus.Damaged;
						break;
					default:
						engine._Status = (_ComponentStatus)Conversions.ToByte(val.InnerText);
						break;
					case "Destroyed":
						engine._Status = _ComponentStatus.Destroyed;
						break;
					case "Operational":
						engine._Status = _ComponentStatus.Operational;
						break;
					}
					break;
				case "ID":
					if (!theDictionary.ContainsKey(val.InnerText))
					{
						engine.ObjectID_Set(val.InnerText);
						theDictionary.TryAdd(engine.ObjectID, engine);
						break;
					}
					result = (Engine)theDictionary[val.InnerText];
					goto end_IL_0001;
				}
			}
			result = engine;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100670", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Engine();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public bool CanUseThisFuelType(FuelRec._FuelType theFuelType)
	{
		EngineType type = Type;
		int result;
		if (type <= EngineType.Electric)
		{
			if (type <= EngineType.Turboshaft)
			{
				if ((uint)(type - 2001) <= 2u || type == EngineType.Turboshaft)
				{
					goto IL_00ff;
				}
				result = 0;
			}
			else
			{
				switch (type)
				{
				default:
					result = 0;
					break;
				case EngineType.Electric:
					return theFuelType == FuelRec._FuelType.Battery;
				case EngineType.Diesel:
					return theFuelType == FuelRec._FuelType.DieselFuel;
				case EngineType.Steam:
					return theFuelType == FuelRec._FuelType.OilFuel;
				case EngineType.Gas_Turbine:
					return theFuelType == FuelRec._FuelType.GasFuel;
				case EngineType.Nuclear:
				case EngineType.PumpJet:
					result = 0;
					break;
				case EngineType.Gasoline:
					return theFuelType == FuelRec._FuelType.Gasoline;
				}
			}
		}
		else if (type <= EngineType.Ramjet)
		{
			switch (type)
			{
			case EngineType.WeaponCoast:
				return theFuelType == FuelRec._FuelType.WeaponCoast;
			case EngineType.Rocket_BoostCoast:
			case EngineType.Rocket_LongBurn:
				return theFuelType == FuelRec._FuelType.RocketFuel;
			case EngineType.Ramjet:
				goto IL_00ff;
			case EngineType.AIP:
				return theFuelType == FuelRec._FuelType.AirIndepedent;
			case EngineType.Torpedo:
				goto IL_011f;
			}
			result = 0;
		}
		else
		{
			if ((uint)(type - 6001) <= 1u)
			{
				goto IL_011f;
			}
			if (type == EngineType.Torpedo_Electric)
			{
				return theFuelType == FuelRec._FuelType.Battery;
			}
			result = 0;
		}
		return (byte)result != 0;
		IL_011f:
		return theFuelType == FuelRec._FuelType.TorpedoFuel;
		IL_00ff:
		return theFuelType == FuelRec._FuelType.AviationFuel;
	}

	public bool CanBeUsedOverland()
	{
		AltBand[] altBands = AltBands;
		int num = 0;
		while (true)
		{
			if (num < altBands.Length)
			{
				AltBand altBand = altBands[num];
				if (altBand.MaxAlt == 0f && altBand.MinAlt == 0f)
				{
					break;
				}
				num = checked(num + 1);
				continue;
			}
			return false;
		}
		return true;
	}

	public bool CanBeUsedOnWater()
	{
		return AltBands.Length > 1;
	}

	private bool method_1()
	{
		int? speed_Flank = AltBands[0].Speed_Flank;
		return ((!speed_Flank.HasValue) ? ((bool?)null) : new bool?(speed_Flank.GetValueOrDefault() > 0)).Value;
	}

	public Engine(ActiveUnit theParent)
		: base(theParent)
	{
		AltBands = Array.Empty<AltBand>();
	}

	public Engine(ActiveUnit theParent, int int_1, string theName, EngineType theType)
		: base(theParent)
	{
		AltBands = Array.Empty<AltBand>();
		DBID = int_1;
		Name = theName;
		Type = theType;
	}

	public int MaxSpeed()
	{
		AltBand[] altBands = AltBands;
		int num = default(int);
		foreach (AltBand altBand in altBands)
		{
			num = Math.Max(num, altBand.MaxSpeed.Value);
		}
		return num;
	}

	public override void vmethod_0(float PulseStrengthRatio)
	{
		if (!ParentPlatform.IsAerospaceUnit || base.Status == _ComponentStatus.Destroyed)
		{
			return;
		}
		float num = ((PulseStrengthRatio < 0.1f) ? 0.05f : ((PulseStrengthRatio < 0.25f) ? 0.15f : ((PulseStrengthRatio < 0.5f) ? 0.3f : ((!(PulseStrengthRatio < 0.75f)) ? 0.75f : 0.5f))));
		if (base.Status != _ComponentStatus.Operational)
		{
			num /= 2f;
		}
		if ((double)num < 0.05)
		{
			num = 0.05f;
		}
		if ((double)num > 0.95)
		{
			num = 0.95f;
		}
		float num2 = num;
		float num3 = (float)((double)num - 0.1);
		float num4 = (float)((double)num - 0.2);
		float num5 = (float)((double)num - 0.3);
		double num6 = GameGeneral.GlobalRNG.NextDouble();
		if (num6 < (double)num5)
		{
			Destroy(ParentPlatform.get_UnitSide(SetSideOnly: false), ScenEditAction: false, Module_ActiveUnit.IsAimpointFacility(ParentPlatform));
			if (!ParentPlatform.IsWeapon)
			{
				ParentPlatform.ParentScen.AddMessage(Misc.RemoveHiddenString(ParentPlatform.Name) + " damage report: " + Misc.RemoveHiddenString(Name) + " has been destroyed!", ParentPlatform.Name + " lost an engine", LoggedMessage.MessageType.UnitDamage, 5, ParentPlatform.ObjectID, ParentPlatform.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
		}
		else if (num6 < (double)num4)
		{
			if (!ParentPlatform.IsWeapon)
			{
				ParentPlatform.ParentScen.AddMessage(Misc.RemoveHiddenString(ParentPlatform.Name) + " damage report: " + Misc.RemoveHiddenString(Name) + " has suffered heavy damage.", ParentPlatform.Name + " had an engine damaged", LoggedMessage.MessageType.UnitDamage, 5, ParentPlatform.ObjectID, ParentPlatform.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			Damage(_DamageSeverityFactor.Heavy);
		}
		else if (num6 < (double)num3)
		{
			if (!ParentPlatform.IsWeapon)
			{
				ParentPlatform.ParentScen.AddMessage(Misc.RemoveHiddenString(ParentPlatform.Name) + " damage report: " + Misc.RemoveHiddenString(Name) + " has suffered moderate damage.", ParentPlatform.Name + " had an engine damaged", LoggedMessage.MessageType.UnitDamage, 5, ParentPlatform.ObjectID, ParentPlatform.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			Damage(_DamageSeverityFactor.Medium);
		}
		else if (num6 < (double)num2)
		{
			if (!ParentPlatform.IsWeapon)
			{
				ParentPlatform.ParentScen.AddMessage(Misc.RemoveHiddenString(ParentPlatform.Name) + " damage report: " + Misc.RemoveHiddenString(Name) + " has suffered light damage.", ParentPlatform.Name + " had an engine damaged", LoggedMessage.MessageType.UnitDamage, 5, ParentPlatform.ObjectID, ParentPlatform.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			Damage(_DamageSeverityFactor.Light);
		}
	}

	static Engine()
	{
		Class72.smethod_20();
	}
}
