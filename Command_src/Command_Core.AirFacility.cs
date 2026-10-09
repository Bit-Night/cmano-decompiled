using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Xml;
using Command_Core.DAL;
using Cysharp.Text;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ThreadSafeCollections;

namespace Command_Core;

public sealed class AirFacility : PlatformComponent
{
	public enum _AirFacType : short
	{
		None = 1001,
		Runway = 2001,
		RunwayWithArrest = 2002,
		RunwayGrade_Taxiway = 2003,
		RunwayAccessPoint = 2004,
		Catapult = 2005,
		SkiJump = 2006,
		CarrierArrestingGear = 2007,
		Pad = 3001,
		PadWithHaulDown = 3002,
		Hangar = 4001,
		OpenParking = 4002,
		Elevator = 4003,
		const_13 = 5001
	}

	public enum _ReasonForAircraftRemoval : byte
	{
		TransferToAnotherAirFac = 1,
		TakeoffOrDestruction
	}

	private _AirFacType _AirFacType_0;

	private GlobalVariables.AircraftSizeClass aircraftSizeClass_0;

	public int Capacity;

	private TDictionary<string, Aircraft> tdictionary_0;

	public GlobalVariables.RunwayLengthClass RunwayLength;

	public TDictionary<string, Aircraft> HostedAircraft => tdictionary_0;

	public string TypeString => method_1(Name);

	public string RunwayString
	{
		get
		{
			string result = "";
			switch (RunwayLength)
			{
			case GlobalVariables.RunwayLengthClass.VTOL:
				result = "Veritcal Take-Off and Landing";
				break;
			case GlobalVariables.RunwayLengthClass.CatapultLaunched:
				result = "Catapult launched";
				break;
			case GlobalVariables.RunwayLengthClass.ManualLaunch:
				result = "Manual Launch";
				break;
			case GlobalVariables.RunwayLengthClass.Between_451_900m:
				result = "450-900m long";
				break;
			case GlobalVariables.RunwayLengthClass.Between_1_450m:
				result = "Short Take-Off and Landing up to 450m";
				break;
			case GlobalVariables.RunwayLengthClass.Between_1_250m:
				result = "Short Take-Off and Landing up to 250m";
				break;
			case GlobalVariables.RunwayLengthClass.Between_4000_5600m:
				result = "4000-5600m long";
				break;
			case GlobalVariables.RunwayLengthClass.Between_3201_4000m:
				result = "3200-4000m long";
				break;
			case GlobalVariables.RunwayLengthClass.Between_2601_3200m:
				result = "2600-3200m long";
				break;
			case GlobalVariables.RunwayLengthClass.Between_2001_2600m:
				result = "2000-2600m long";
				break;
			case GlobalVariables.RunwayLengthClass.Between_1401_2000m:
				result = "1400-2000m long";
				break;
			case GlobalVariables.RunwayLengthClass.Between_901_1400m:
				result = "900-1400m long";
				break;
			}
			return result;
		}
	}

	public GlobalVariables.AircraftSizeClass EffectiveRunwaySize
	{
		get
		{
			if (!Information.IsNothing((object)ParentPlatform))
			{
				double num = 100f - ParentPlatform.Damage.DamagePercent;
				if (num > 75.0)
				{
					return aircraftSizeClass_0;
				}
				if (num > 50.0)
				{
					return (GlobalVariables.AircraftSizeClass)Math.Max((int)(aircraftSizeClass_0 - 1), 0);
				}
				if (num > 25.0)
				{
					return (GlobalVariables.AircraftSizeClass)Math.Max((int)(aircraftSizeClass_0 - 2), 0);
				}
				if (num > 10.0)
				{
					return (GlobalVariables.AircraftSizeClass)Math.Max((int)(aircraftSizeClass_0 - 3), 0);
				}
				return GlobalVariables.AircraftSizeClass.None;
			}
			return GlobalVariables.AircraftSizeClass.None;
		}
	}

	public _AirFacType AirFacType => _AirFacType_0;

	public GlobalVariables.AircraftSizeClass MaxAircraftSize => aircraftSizeClass_0;

	public bool IsOpenAirFacility
	{
		get
		{
			_AirFacType airFacType = AirFacType;
			int result;
			int result2;
			if (airFacType > _AirFacType.SkiJump)
			{
				if ((uint)(airFacType - 3001) > 1u)
				{
					if (airFacType == _AirFacType.OpenParking)
					{
						result = 1;
						goto IL_003e;
					}
					result2 = 0;
					goto IL_003a;
				}
			}
			else if ((uint)(airFacType - 2001) > 3u && airFacType != _AirFacType.SkiJump)
			{
				result2 = 0;
				goto IL_003a;
			}
			result = 1;
			goto IL_003e;
			IL_003e:
			return (byte)result != 0;
			IL_003a:
			return (byte)result2 != 0;
		}
	}

	public int ParkingSpace_Total
	{
		get
		{
			int num = default(int);
			switch (aircraftSizeClass_0)
			{
			case GlobalVariables.AircraftSizeClass.Small:
				num = Capacity;
				break;
			case GlobalVariables.AircraftSizeClass.UAS_Class2:
				num = Math.Max((int)Math.Round((double)Capacity * 0.5), (int)aircraftSizeClass_0);
				break;
			case GlobalVariables.AircraftSizeClass.UAS_Class1_Micro:
			case GlobalVariables.AircraftSizeClass.UAS_Class1_Mini:
			case GlobalVariables.AircraftSizeClass.UAS_Class1_Small:
				num = Math.Max((int)Math.Round((double)Capacity * 0.25), (int)aircraftSizeClass_0);
				break;
			case GlobalVariables.AircraftSizeClass.VLarge:
				num = 4 * Capacity;
				break;
			case GlobalVariables.AircraftSizeClass.Large:
				num = 3 * Capacity;
				break;
			case GlobalVariables.AircraftSizeClass.Medium:
				num = 2 * Capacity;
				break;
			}
			if ((int)aircraftSizeClass_0 >= 10)
			{
				return num * 10;
			}
			return num;
		}
	}

	public int ParkingSpace_Free
	{
		get
		{
			try
			{
				int num = ParkingSpace_Total;
				foreach (Aircraft value in HostedAircraft.Values)
				{
					num -= (int)value.Size;
				}
				return num;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100656", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return 0;
		}
	}

	public string ToXML(HashSet<string> ObjectsAlreadySerialized)
	{
		Utf16ValueStringBuilder utf16ValueStringBuilder = ZString.CreateStringBuilder();
		try
		{
			utf16ValueStringBuilder.Append("<AirFacility>");
			utf16ValueStringBuilder.Append("<ID>");
			utf16ValueStringBuilder.Append(ObjectID);
			utf16ValueStringBuilder.Append("</ID>");
			utf16ValueStringBuilder.Append("<DBID>");
			utf16ValueStringBuilder.Append(DBID.ToString());
			utf16ValueStringBuilder.Append("</DBID>");
			if (DBID == 0)
			{
				utf16ValueStringBuilder.Append("<Name>");
				utf16ValueStringBuilder.Append(SecurityElement.Escape(Name));
				utf16ValueStringBuilder.Append("</Name>");
				utf16ValueStringBuilder.Append("<Type>");
				utf16ValueStringBuilder.Append((int)_AirFacType_0);
				utf16ValueStringBuilder.Append("</Type>");
				utf16ValueStringBuilder.Append("<Size>");
				utf16ValueStringBuilder.Append((int)aircraftSizeClass_0);
				utf16ValueStringBuilder.Append("</Size>");
				utf16ValueStringBuilder.Append("<Capacity>");
				utf16ValueStringBuilder.Append(Capacity);
				utf16ValueStringBuilder.Append("</Capacity>");
			}
			if (ObjectsAlreadySerialized != null)
			{
				if (ObjectsAlreadySerialized.Contains(ObjectID))
				{
					utf16ValueStringBuilder.Append("</AirFacility>");
					return utf16ValueStringBuilder.ToString();
				}
				ObjectsAlreadySerialized.Add(ObjectID);
			}
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
			utf16ValueStringBuilder.Append("</AirFacility>");
			string result = utf16ValueStringBuilder.ToString();
			utf16ValueStringBuilder.Dispose();
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100652", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private static AirFacility smethod_0(XmlNode xmlNode_0)
	{
		AirFacility result;
		try
		{
			int num = Conversions.ToInteger(Misc.GetNodeByName(xmlNode_0.ChildNodes, "Type").InnerText);
			int theCapacity = Conversions.ToInteger(Misc.GetNodeByName(xmlNode_0.ChildNodes, "Capacity").InnerText);
			GlobalVariables.RunwayLengthClass theRunwayLength = default(GlobalVariables.RunwayLengthClass);
			GlobalVariables.AircraftSizeClass theSize = default(GlobalVariables.AircraftSizeClass);
			switch (Conversions.ToInteger(Misc.GetNodeByName(xmlNode_0.ChildNodes, "Size").InnerText))
			{
			case 1:
				theRunwayLength = GlobalVariables.RunwayLengthClass.VTOL;
				theSize = GlobalVariables.AircraftSizeClass.Small;
				break;
			case 2:
				theRunwayLength = GlobalVariables.RunwayLengthClass.VTOL;
				theSize = GlobalVariables.AircraftSizeClass.Medium;
				break;
			case 3:
				theRunwayLength = GlobalVariables.RunwayLengthClass.VTOL;
				theSize = GlobalVariables.AircraftSizeClass.Large;
				break;
			case 4:
				theRunwayLength = GlobalVariables.RunwayLengthClass.VTOL;
				theSize = GlobalVariables.AircraftSizeClass.VLarge;
				break;
			case 5:
				theRunwayLength = GlobalVariables.RunwayLengthClass.Between_1_450m;
				theSize = GlobalVariables.AircraftSizeClass.Small;
				break;
			case 6:
				theRunwayLength = GlobalVariables.RunwayLengthClass.Between_451_900m;
				theSize = GlobalVariables.AircraftSizeClass.Small;
				break;
			case 7:
				theRunwayLength = GlobalVariables.RunwayLengthClass.Between_901_1400m;
				theSize = GlobalVariables.AircraftSizeClass.Medium;
				break;
			case 8:
				theRunwayLength = GlobalVariables.RunwayLengthClass.Between_2001_2600m;
				theSize = GlobalVariables.AircraftSizeClass.Large;
				break;
			case 9:
				theRunwayLength = GlobalVariables.RunwayLengthClass.Between_2601_3200m;
				theSize = GlobalVariables.AircraftSizeClass.VLarge;
				break;
			}
			result = new AirFacility(null, Misc.GetNodeByName(xmlNode_0.ChildNodes, "Name").InnerText, (_AirFacType)num, (int)theSize, theCapacity, theRunwayLength);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200033", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static AirFacility FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref Scenario theScen)
	{
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Expected O, but got Unknown
		AirFacility result;
		try
		{
			XmlNode nodeByName = Misc.GetNodeByName(theNode.ChildNodes, "DBID");
			string text = Misc.GetNodeByName(theNode.ChildNodes, "ID").InnerText;
			if (Misc.ContainsChar(text, ' '))
			{
				text = text.Replace(" ", "-");
			}
			AirFacility airFacility;
			if (!theDictionary.ContainsKey(text))
			{
				if (Information.IsNothing((object)nodeByName))
				{
					airFacility = smethod_0(theNode);
					goto IL_00d2;
				}
				if (Operators.CompareString(nodeByName.InnerText, "0", false) != 0)
				{
					if (Operators.CompareString(nodeByName.InnerText, "-1", false) == 0)
					{
						airFacility = AddUAV_Class1_Hanger(null);
					}
					else
					{
						int facilityDBID = Conversions.ToInteger(nodeByName.InnerText);
						SQLiteConnection sqliteConnection_ = theScen.DBConnection;
						airFacility = DBFunctions.GetAirFacility(facilityDBID, ref sqliteConnection_);
					}
					goto IL_00d2;
				}
				airFacility = smethod_0(theNode);
				if (!Information.IsNothing((object)airFacility))
				{
					goto IL_00d2;
				}
				result = null;
			}
			else
			{
				result = (AirFacility)theDictionary[text];
			}
			goto end_IL_0001;
			IL_00d2:
			if (!theDictionary.ContainsKey(text))
			{
				airFacility.ObjectID_Set(text);
				theDictionary.TryAdd(airFacility.ObjectID, airFacility);
				foreach (XmlNode childNode in theNode.ChildNodes)
				{
					XmlNode val = childNode;
					string name = val.Name;
					if (Operators.CompareString(name, "Status", false) == 0)
					{
						switch (val.InnerText)
						{
						case "Operational":
							airFacility._Status = _ComponentStatus.Operational;
							break;
						case "Destroyed":
							airFacility._Status = _ComponentStatus.Destroyed;
							break;
						default:
							airFacility._Status = (_ComponentStatus)Conversions.ToByte(val.InnerText);
							break;
						case "Damaged":
							airFacility._Status = _ComponentStatus.Damaged;
							break;
						}
					}
					else if (Operators.CompareString(name, "DamageSeverity", false) == 0)
					{
						airFacility.DamageSeverity = (_DamageSeverityFactor)Conversions.ToByte(val.InnerText);
					}
				}
				result = airFacility;
			}
			else
			{
				result = (AirFacility)theDictionary[text];
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100653", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public AirFacility(ActiveUnit theParent, string theName, _AirFacType theType, int theSize, int theCapacity, GlobalVariables.RunwayLengthClass theRunwayLength)
		: base(theParent)
	{
		Name = theName;
		_AirFacType_0 = theType;
		aircraftSizeClass_0 = (GlobalVariables.AircraftSizeClass)theSize;
		RunwayLength = theRunwayLength;
		tdictionary_0 = new TDictionary<string, Aircraft>(StringComparer.Ordinal, useReadLock: false);
		Capacity = theCapacity;
	}

	internal bool HasHostedAircraft()
	{
		return tdictionary_0.Count > 0;
	}

	public override void Destroy(Side ComponentPlatformSide, bool ScenEditAction, bool IsAimpointFacility, bool RegisterAsLosses = true)
	{
		try
		{
			if (HostedAircraft.Skip(0).Count() > 0)
			{
				foreach (Aircraft value in HostedAircraft.Values)
				{
					ParentPlatform.ParentScen.DestroyThisUnit(value, "Air facility this aircraft was landed on was destroyed", "Host Destruction");
				}
			}
			base.Destroy(ComponentPlatformSide, ScenEditAction, IsAimpointFacility);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100654", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void HandleDamageToHostedAircraft(_DamageSeverityFactor theSeverity, float PenetrationFactor)
	{
		if (HostedAircraft.Skip(0).Count() <= 0 || (!IsOpenAirFacility && PenetrationFactor == 0f))
		{
			return;
		}
		foreach (Aircraft value in HostedAircraft.Values)
		{
			if (!IsOpenAirFacility && PenetrationFactor < 1f && GameGeneral.GlobalRNG.NextDouble() > (double)PenetrationFactor)
			{
				continue;
			}
			switch (theSeverity)
			{
			case _DamageSeverityFactor.Light:
				if (GameGeneral.GlobalRNG.NextDouble() > 0.25)
				{
					continue;
				}
				break;
			case _DamageSeverityFactor.Medium:
				if (GameGeneral.GlobalRNG.NextDouble() > 0.5)
				{
					continue;
				}
				break;
			case _DamageSeverityFactor.Heavy:
				if (GameGeneral.GlobalRNG.NextDouble() > 0.75)
				{
					continue;
				}
				break;
			}
			string text = "";
			if (Operators.CompareString(value.Name, value.UnitClass, false) != 0)
			{
				text = " (" + value.UnitClass + ")";
			}
			if (ParentPlatform != null)
			{
				ParentPlatform.AddMessage(value.Name + text + " was hosted in " + Name + " and has been destroyed by the damage!", value.Name + " destroyed!", LoggedMessage.MessageType.UnitLost, 2, new Geopoint_Struct(ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null)));
				ParentPlatform.ParentScen.DestroyThisUnit(value, value.Name + text + " was hosted in " + Name + " and has been destroyed by the damage!", "Host Destruction");
			}
		}
	}

	private string method_1(string string_1)
	{
		int num = Strings.InStr(string_1, "(", (CompareMethod)0);
		if (num != 0)
		{
			return Strings.Trim(Strings.Left(string_1, num - 1));
		}
		return string_1;
	}

	internal bool IsRunwayOrPad()
	{
		_AirFacType airFacType = AirFacType;
		int result;
		if ((uint)(airFacType - 2001) <= 2u)
		{
			result = 1;
		}
		else if ((uint)(airFacType - 2005) <= 2u)
		{
			result = 1;
		}
		else
		{
			if ((uint)(airFacType - 3001) > 1u)
			{
				return false;
			}
			result = 1;
		}
		return (byte)result != 0;
	}

	internal bool IsPad()
	{
		_AirFacType airFacType = AirFacType;
		if ((uint)(airFacType - 3001) <= 1u)
		{
			return true;
		}
		return false;
	}

	internal bool IsCatapult()
	{
		return AirFacType == _AirFacType.Catapult;
	}

	internal bool IsParkingFacility()
	{
		_AirFacType airFacType = AirFacType;
		if ((uint)(airFacType - 4001) <= 1u)
		{
			return true;
		}
		return false;
	}

	internal bool IsTransitFacility()
	{
		return AirFacType switch
		{
			_AirFacType.Elevator => true, 
			_AirFacType.RunwayAccessPoint => true, 
			_ => false, 
		};
	}

	public AirOpsAttemptResult CanHostThisAircraft_BySize(Aircraft theAircraft)
	{
		AirOpsAttemptResult result;
		try
		{
			if (!Information.IsNothing((object)ParentPlatform))
			{
				if (!((theAircraft.Size == GlobalVariables.AircraftSizeClass.UAS_Class1_Micro) | (theAircraft.Size == GlobalVariables.AircraftSizeClass.UAS_Class1_Mini) | (theAircraft.Size == GlobalVariables.AircraftSizeClass.UAS_Class1_Small)))
				{
					GlobalVariables.ActiveUnitType unitType = ParentPlatform.UnitType;
					if (unitType - 2 <= GlobalVariables.ActiveUnitType.Aircraft && theAircraft.Size > aircraftSizeClass_0)
					{
						result = AirOpsAttemptResult.Unable_to_fit_in_hangar_space;
					}
					else if (theAircraft.Size < GlobalVariables.AircraftSizeClass.Small && AirFacType == _AirFacType.const_13 && HostedAircraft.Count == 0)
					{
						result = AirOpsAttemptResult.Success;
					}
					else
					{
						int num = ParkingSpace_Free;
						if (HostedAircraft.ContainsKey(theAircraft.ObjectID))
						{
							num += (int)theAircraft.Size;
						}
						result = ((num < (int)theAircraft.Size) ? AirOpsAttemptResult.Not_enough_space : AirOpsAttemptResult.Success);
					}
				}
				else
				{
					AddUAV_Class1_Hanger(ParentPlatform);
					result = AirOpsAttemptResult.Success;
				}
			}
			else
			{
				result = AirOpsAttemptResult.Failure_other;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100657", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num2;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num2 = 6;
			}
			else
			{
				num2 = 6;
			}
			result = (AirOpsAttemptResult)num2;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	~AirFacility()
	{
		base.Finalize();
	}

	public static AirFacility AddUAV_Class1_Hanger(ActiveUnit theParent)
	{
		AirFacility result;
		try
		{
			if (theParent != null && theParent.bool_2)
			{
				result = null;
			}
			else
			{
				AirFacility airFacility = new AirFacility(theParent, "UAV Storage (UAV [NATO Class I])", _AirFacType.Hangar, 3, 1000, GlobalVariables.RunwayLengthClass.CatapultLaunched);
				airFacility.DBID = -1;
				if (theParent != null)
				{
					if (airFacility != null)
					{
						theParent.AddAirFacility(airFacility);
						theParent.bool_2 = true;
					}
					result = airFacility;
				}
				else
				{
					result = airFacility;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100745.1", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	static AirFacility()
	{
		Class72.smethod_20();
	}
}
