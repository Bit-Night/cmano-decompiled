using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Command_Core.DAL;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;

namespace Command_Core;

public sealed class Doctrine
{
	public delegate void DoctrineChangedEventHandler(ScenarioObject theSubject, bool? viaMainForm, bool MultipleUnits, bool ViaDoctrineForm, bool ViaRightColumn, bool viaFlightPlanEditor);

	public delegate void EmconChangedEventHandler(ScenarioObject theSubject, bool? viaMainForm, bool MultipleUnits, bool ViaDoctrineForm, bool ViaRightColumn, bool viaFlightPlanEditor);

	public class PriorityTargetEntry
	{
		public enum PriorityFlags
		{
			PriorityLow,
			PriorityDefault,
			PriorityHigh
		}

		private static GlobalVariables.ActiveUnitType[] activeUnitType_0;

		private static string[] string_0;

		public static int FACILITY_SUBTYPE_OFFSET_INDEX;

		public GlobalVariables.ActiveUnitType Type;

		public int SubType;

		public int DBID;

		public PriorityFlags Priority;

		static PriorityTargetEntry()
		{
			Class72.smethod_20();
			activeUnitType_0 = new GlobalVariables.ActiveUnitType[7]
			{
				GlobalVariables.ActiveUnitType.None,
				GlobalVariables.ActiveUnitType.Aircraft,
				GlobalVariables.ActiveUnitType.Ship,
				GlobalVariables.ActiveUnitType.Submarine,
				GlobalVariables.ActiveUnitType.Facility,
				GlobalVariables.ActiveUnitType.Weapon,
				GlobalVariables.ActiveUnitType.Vehicle
			};
			string_0 = new string[3] { "Delayed", "Default", "Immediate" };
			FACILITY_SUBTYPE_OFFSET_INDEX = 32768;
		}

		public PriorityTargetEntry()
		{
			Type = GlobalVariables.ActiveUnitType.None;
			SubType = 0;
			DBID = 0;
			Priority = PriorityFlags.PriorityDefault;
		}

		public PriorityTargetEntry(GlobalVariables.ActiveUnitType theType, int theSubType, int theDBID, PriorityFlags thePriority, bool isFacilityType = false)
		{
			Type = GlobalVariables.ActiveUnitType.None;
			SubType = 0;
			DBID = 0;
			Priority = PriorityFlags.PriorityDefault;
			Type = theType;
			SubType = theSubType;
			if (isFacilityType)
			{
				SubType += FACILITY_SUBTYPE_OFFSET_INDEX;
			}
			DBID = theDBID;
			Priority = thePriority;
		}

		internal string TypeString()
		{
			if (Type == GlobalVariables.ActiveUnitType.None)
			{
				return "Any";
			}
			return Misc.ActiveUnitType_Description(Type);
		}

		internal string SubTypeString(Scenario theScenario)
		{
			if (SubType == 0)
			{
				return "Any";
			}
			switch (Type)
			{
			case GlobalVariables.ActiveUnitType.Aircraft:
				return Misc.Description((Aircraft._AircraftType)SubType, theScenario.DBConnection);
			case GlobalVariables.ActiveUnitType.Ship:
				return Misc.Description((Ship._ShipType)SubType, theScenario.DBConnection);
			case GlobalVariables.ActiveUnitType.Submarine:
				return Misc.Description((Submarine._SubmarineType)SubType, theScenario.DBConnection);
			case GlobalVariables.ActiveUnitType.Facility:
				if (SubType >= FACILITY_SUBTYPE_OFFSET_INDEX)
				{
					return Misc.Description((Facility._FacilityCategory)(SubType - FACILITY_SUBTYPE_OFFSET_INDEX), theScenario.DBConnection);
				}
				return Misc.ToEnglishString((IMobileGroundUnit._MobileUnitCategory)SubType);
			case GlobalVariables.ActiveUnitType.Weapon:
				return Misc.ToEnglishString((Weapon._WeaponType)SubType);
			default:
				return "";
			case GlobalVariables.ActiveUnitType.Vehicle:
				return Misc.ToEnglishString((IMobileGroundUnit._MobileUnitCategory)SubType);
			}
		}

		internal string method_0(Scenario theScenario)
		{
			if (DBID != 0)
			{
				return DBFunctions.GetActiveUnitName(Type, DBID, theScenario.DBConnection);
			}
			return "Any";
		}

		internal string PriorityString()
		{
			return string_0[(int)Priority];
		}

		internal string LBItemString(Scenario theScenario)
		{
			return "\t" + TypeString() + "\t" + SubTypeString(theScenario) + "\t" + method_0(theScenario) + "\t" + PriorityString();
		}

		internal string ShortString(Scenario theScenario)
		{
			return "(" + TypeString() + ", " + SubTypeString(theScenario) + ", " + method_0(theScenario) + ")";
		}

		public void ToXML(ref XmlWriter theWriter, ref Scenario theScen, string theDoctrineName = "Doctrine")
		{
			theWriter.WriteStartElement("PTLEntry");
			if (Type != GlobalVariables.ActiveUnitType.None)
			{
				XmlWriter obj = theWriter;
				int type = (int)Type;
				obj.WriteElementString("PTL_T", type.ToString());
			}
			if (SubType != 0)
			{
				theWriter.WriteElementString("PTL_ST", SubType.ToString());
			}
			if (DBID != 0)
			{
				theWriter.WriteElementString("PTL_DBID", DBID.ToString());
			}
			if (Priority != PriorityFlags.PriorityDefault)
			{
				XmlWriter obj2 = theWriter;
				int type = (int)Priority;
				obj2.WriteElementString("PTL_P", type.ToString());
			}
			theWriter.WriteEndElement();
		}

		public static PriorityTargetEntry FromXML(ref XmlNode theNode)
		{
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			PriorityTargetEntry priorityTargetEntry = new PriorityTargetEntry();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "PTL_T":
					priorityTargetEntry.Type = (GlobalVariables.ActiveUnitType)Conversions.ToByte(val.InnerText);
					break;
				case "PTL_ST":
					priorityTargetEntry.SubType = Conversions.ToInteger(val.InnerText);
					break;
				case "PTL_DBID":
					priorityTargetEntry.DBID = Conversions.ToInteger(val.InnerText);
					break;
				case "PTL_P":
					priorityTargetEntry.Priority = (PriorityFlags)Conversions.ToInteger(val.InnerText);
					break;
				}
			}
			return priorityTargetEntry;
		}

		internal bool TypeMatch(Contact target)
		{
			int result;
			if (target.IDStatus < Contact_Base.IdentificationStatus.KnownDomain)
			{
				result = 0;
			}
			else
			{
				if (target.ActualUnit != null)
				{
					int result2;
					switch (Type)
					{
					default:
						result2 = 0;
						goto IL_0099;
					case GlobalVariables.ActiveUnitType.None:
						return true;
					case GlobalVariables.ActiveUnitType.Aircraft:
						return target.ActualUnit.IsAircraft;
					case GlobalVariables.ActiveUnitType.Ship:
						return target.ActualUnit.IsShip;
					case GlobalVariables.ActiveUnitType.Submarine:
						return target.ActualUnit.IsSubmarine;
					case GlobalVariables.ActiveUnitType.Facility:
						return target.ActualUnit.IsFacility;
					case GlobalVariables.ActiveUnitType.Weapon:
						return target.ActualUnit.IsWeapon;
					case GlobalVariables.ActiveUnitType.Aimpoint:
					case GlobalVariables.ActiveUnitType.Satellite:
						result2 = 0;
						goto IL_0099;
					case GlobalVariables.ActiveUnitType.Vehicle:
						{
							return target.ActualUnit.IsVehicle;
						}
						IL_0099:
						return (byte)result2 != 0;
					}
				}
				result = 0;
			}
			return (byte)result != 0;
		}

		internal bool SubTypeMatch(Contact target)
		{
			if (SubType == 0)
			{
				return true;
			}
			int result;
			if (target.IDStatus >= Contact_Base.IdentificationStatus.KnownType && target.ActualUnit != null)
			{
				switch (Type)
				{
				default:
					result = 0;
					goto IL_00fb;
				case GlobalVariables.ActiveUnitType.Aircraft:
					return SubType == target.ActualUnit.SubType;
				case GlobalVariables.ActiveUnitType.Ship:
					return SubType == target.ActualUnit.SubType;
				case GlobalVariables.ActiveUnitType.Submarine:
					return SubType == target.ActualUnit.SubType;
				case GlobalVariables.ActiveUnitType.Facility:
				{
					Facility facility = (Facility)target.ActualUnit;
					if (SubType < FACILITY_SUBTYPE_OFFSET_INDEX)
					{
						return SubType == (int)facility.MobileUnitCategory();
					}
					return SubType - FACILITY_SUBTYPE_OFFSET_INDEX == facility.SubType;
				}
				case GlobalVariables.ActiveUnitType.Weapon:
					return SubType == target.ActualUnit.SubType;
				case GlobalVariables.ActiveUnitType.Aimpoint:
				case GlobalVariables.ActiveUnitType.Satellite:
					result = 0;
					goto IL_00fb;
				case GlobalVariables.ActiveUnitType.Vehicle:
					{
						return SubType == (int)((IMobileGroundUnit)target.ActualUnit).MobileUnitCategory;
					}
					IL_00fb:
					return (byte)result != 0;
				}
			}
			return false;
		}

		internal bool method_1(Contact target)
		{
			if (DBID == 0)
			{
				return true;
			}
			int result;
			if (target.IDStatus >= Contact_Base.IdentificationStatus.KnownClass)
			{
				if (target.ActualUnit != null)
				{
					return target.ActualUnit.DBID == DBID;
				}
				result = 0;
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}

		internal bool AppliesTo(Contact theTarget)
		{
			if (TypeMatch(theTarget) && SubTypeMatch(theTarget))
			{
				return method_1(theTarget);
			}
			return false;
		}

		public static void PopulateUnitTypeList(ComboBox combo)
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("ID", typeof(int));
			dataTable.Columns.Add("Description", typeof(string));
			dataTable.Rows.Add(GlobalVariables.ActiveUnitType.Aircraft, Misc.ActiveUnitType_Description(GlobalVariables.ActiveUnitType.Aircraft));
			dataTable.Rows.Add(GlobalVariables.ActiveUnitType.Ship, Misc.ActiveUnitType_Description(GlobalVariables.ActiveUnitType.Ship));
			dataTable.Rows.Add(GlobalVariables.ActiveUnitType.Submarine, Misc.ActiveUnitType_Description(GlobalVariables.ActiveUnitType.Submarine));
			dataTable.Rows.Add(GlobalVariables.ActiveUnitType.Facility, Misc.ActiveUnitType_Description(GlobalVariables.ActiveUnitType.Facility));
			dataTable.Rows.Add(GlobalVariables.ActiveUnitType.Vehicle, Misc.ActiveUnitType_Description(GlobalVariables.ActiveUnitType.Vehicle));
			dataTable.Rows.Add(GlobalVariables.ActiveUnitType.Weapon, Misc.ActiveUnitType_Description(GlobalVariables.ActiveUnitType.Weapon));
			((ListControl)combo).DisplayMember = "Description";
			((ListControl)combo).ValueMember = "ID";
			combo.DataSource = dataTable;
			combo.SelectedIndex = 0;
		}

		public static bool ScenarioContains(GlobalVariables.ActiveUnitType unitType, int unitSubType, int unitDBID, Scenario scen)
		{
			if (scen != null && scen.ActiveUnits.Count >= 1)
			{
				List<ActiveUnit> list = scen.ActiveUnits_List.Where([SpecialName] (ActiveUnit au) => au.UnitType == unitType).ToList();
				if (list.Count > 0)
				{
					if (unitDBID > 0)
					{
						return list.Where([SpecialName] (ActiveUnit au) => au.DBID == unitDBID).ToList().Count > 0;
					}
					List<ActiveUnit> list2 = default(List<ActiveUnit>);
					switch (unitType)
					{
					case GlobalVariables.ActiveUnitType.Facility:
						list2 = ((unitSubType < FACILITY_SUBTYPE_OFFSET_INDEX) ? list.Where([SpecialName] (ActiveUnit au) => ((Facility)au).MobileUnitCategory() == (IMobileGroundUnit._MobileUnitCategory)unitSubType).ToList() : list.Where([SpecialName] (ActiveUnit au) => au.SubType == unitSubType - FACILITY_SUBTYPE_OFFSET_INDEX).ToList());
						break;
					case GlobalVariables.ActiveUnitType.Aircraft:
					case GlobalVariables.ActiveUnitType.Ship:
					case GlobalVariables.ActiveUnitType.Submarine:
					case GlobalVariables.ActiveUnitType.Weapon:
						list2 = list.Where([SpecialName] (ActiveUnit au) => au.SubType == unitSubType).ToList();
						break;
					case GlobalVariables.ActiveUnitType.Vehicle:
						list2 = list.Where([SpecialName] (ActiveUnit au) => ((IMobileGroundUnit)au).MobileUnitCategory == (IMobileGroundUnit._MobileUnitCategory)unitSubType).ToList();
						break;
					}
					return list2.Count > 0;
				}
				return false;
			}
			return false;
		}

		public static void PopulateUnitSubTypeList(ComboBox combo, GlobalVariables.ActiveUnitType theType, Scenario theScen, bool LimitToExistingSubTypes = false)
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("ID", typeof(int));
			dataTable.Columns.Add("Description", typeof(string));
			dataTable.Rows.Add(0, "Any");
			switch (theType)
			{
			case GlobalVariables.ActiveUnitType.Aircraft:
				foreach (object value in Enum.GetValues(typeof(Aircraft._AircraftType)))
				{
					Aircraft._AircraftType aircraftType = (Aircraft._AircraftType)Conversions.ToInteger(value);
					if (aircraftType != Aircraft._AircraftType.None && !(aircraftType >= (Aircraft._AircraftType)9000 && aircraftType <= (Aircraft._AircraftType)9009) && (!LimitToExistingSubTypes || ScenarioContains(theType, (int)aircraftType, 0, theScen)))
					{
						string text4 = Misc.Description(aircraftType, theScen.DBConnection);
						if (string.IsNullOrEmpty(text4))
						{
							dataTable.Rows.Add((int)aircraftType, aircraftType.ToString());
						}
						else
						{
							dataTable.Rows.Add((int)aircraftType, text4);
						}
					}
				}
				break;
			case GlobalVariables.ActiveUnitType.Ship:
				foreach (object value2 in Enum.GetValues(typeof(Ship._ShipType)))
				{
					Ship._ShipType shipType = (Ship._ShipType)Conversions.ToInteger(value2);
					if (shipType != Ship._ShipType.None && (!LimitToExistingSubTypes || ScenarioContains(theType, (int)shipType, 0, theScen)))
					{
						string text6 = Misc.Description(shipType, theScen.DBConnection);
						if (string.IsNullOrEmpty(text6))
						{
							dataTable.Rows.Add((int)shipType, shipType.ToString());
						}
						else
						{
							dataTable.Rows.Add((int)shipType, text6);
						}
					}
				}
				break;
			case GlobalVariables.ActiveUnitType.Submarine:
				foreach (object value3 in Enum.GetValues(typeof(Submarine._SubmarineType)))
				{
					Submarine._SubmarineType submarineType = (Submarine._SubmarineType)Conversions.ToInteger(value3);
					if (submarineType != Submarine._SubmarineType.None && (!LimitToExistingSubTypes || ScenarioContains(theType, (int)submarineType, 0, theScen)))
					{
						string text5 = Misc.Description(submarineType, theScen.DBConnection);
						if (string.IsNullOrEmpty(text5))
						{
							dataTable.Rows.Add((int)submarineType, submarineType.ToString());
						}
						else
						{
							dataTable.Rows.Add((int)submarineType, text5);
						}
					}
				}
				break;
			case GlobalVariables.ActiveUnitType.Facility:
				foreach (object value4 in Enum.GetValues(typeof(Facility._FacilityCategory)))
				{
					Facility._FacilityCategory facilityCategory = (Facility._FacilityCategory)Conversions.ToShort(value4);
					if (facilityCategory == Facility._FacilityCategory.None)
					{
						continue;
					}
					int num = (int)facilityCategory + FACILITY_SUBTYPE_OFFSET_INDEX;
					if (!LimitToExistingSubTypes || ScenarioContains(theType, num, 0, theScen))
					{
						string text2 = Misc.Description(facilityCategory, theScen.DBConnection);
						if (string.IsNullOrEmpty(text2))
						{
							dataTable.Rows.Add(num, facilityCategory.ToString());
						}
						else
						{
							dataTable.Rows.Add(num, text2);
						}
					}
				}
				foreach (object value5 in Enum.GetValues(typeof(IMobileGroundUnit._MobileUnitCategory)))
				{
					IMobileGroundUnit._MobileUnitCategory mobileUnitCategory2 = (IMobileGroundUnit._MobileUnitCategory)Conversions.ToInteger(value5);
					if (mobileUnitCategory2 != IMobileGroundUnit._MobileUnitCategory.None && mobileUnitCategory2 != IMobileGroundUnit._MobileUnitCategory.Infantry_Old && (!LimitToExistingSubTypes || ScenarioContains(theType, (int)mobileUnitCategory2, 0, theScen)))
					{
						string text3 = Misc.ToEnglishString(mobileUnitCategory2);
						if (string.IsNullOrEmpty(text3))
						{
							dataTable.Rows.Add((int)mobileUnitCategory2, mobileUnitCategory2.ToString());
						}
						else
						{
							dataTable.Rows.Add((int)mobileUnitCategory2, text3);
						}
					}
				}
				break;
			case GlobalVariables.ActiveUnitType.Weapon:
				dataTable.Rows.Add(2001, Misc.ToEnglishString(Weapon._WeaponType.GuidedWeapon));
				break;
			case GlobalVariables.ActiveUnitType.Vehicle:
				foreach (object value6 in Enum.GetValues(typeof(IMobileGroundUnit._MobileUnitCategory)))
				{
					IMobileGroundUnit._MobileUnitCategory mobileUnitCategory = (IMobileGroundUnit._MobileUnitCategory)Conversions.ToInteger(value6);
					if (mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.None && mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.Infantry_Old && (!LimitToExistingSubTypes || ScenarioContains(theType, (int)mobileUnitCategory, 0, theScen)))
					{
						string text = Misc.ToEnglishString(mobileUnitCategory);
						if (!string.IsNullOrEmpty(text))
						{
							dataTable.Rows.Add((int)mobileUnitCategory, text);
						}
						else
						{
							dataTable.Rows.Add((int)mobileUnitCategory, mobileUnitCategory.ToString());
						}
					}
				}
				break;
			}
			((ListControl)combo).DisplayMember = "Description";
			((ListControl)combo).ValueMember = "ID";
			combo.DataSource = dataTable;
			combo.SelectedIndex = 0;
		}

		public static void PopulateDBIDList(ComboBox combo, GlobalVariables.ActiveUnitType theType, int theSubType, Scenario theScen, bool LimitToExistingClasses = false)
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("ID", typeof(int));
			dataTable.Columns.Add("Description", typeof(string));
			dataTable.Rows.Add(0, "Any");
			if (LimitToExistingClasses && !ScenarioContains(theType, theSubType, 0, theScen))
			{
				((ListControl)combo).DisplayMember = "Description";
				((ListControl)combo).ValueMember = "ID";
				combo.DataSource = dataTable;
				combo.SelectedIndex = 0;
				return;
			}
			if (theSubType != 0)
			{
				switch (theType)
				{
				case GlobalVariables.ActiveUnitType.Aircraft:
					foreach (DataRow row in theScen.Cache_Aircraft_DT.Rows)
					{
						if (Conversions.ToInteger(row["Type"]) == theSubType && (!LimitToExistingClasses || ScenarioContains(theType, theSubType, Conversions.ToInteger(row["ID"]), theScen)))
						{
							dataTable.Rows.Add(Conversions.ToInteger(row["ID"]), row["LongName"]);
						}
					}
					break;
				case GlobalVariables.ActiveUnitType.Ship:
					foreach (DataRow row2 in theScen.Cache_Ships_DT.Rows)
					{
						if (Conversions.ToInteger(row2["Type"]) == theSubType && (!LimitToExistingClasses || ScenarioContains(theType, theSubType, Conversions.ToInteger(row2["ID"]), theScen)))
						{
							dataTable.Rows.Add(Conversions.ToInteger(row2["ID"]), row2["LongName"]);
						}
					}
					break;
				case GlobalVariables.ActiveUnitType.Submarine:
					foreach (DataRow row3 in theScen.Cache_Subs_DT.Rows)
					{
						if (Conversions.ToInteger(row3["Type"]) == theSubType && (!LimitToExistingClasses || ScenarioContains(theType, theSubType, Conversions.ToInteger(row3["ID"]), theScen)))
						{
							dataTable.Rows.Add(Conversions.ToInteger(row3["ID"]), row3["LongName"]);
						}
					}
					break;
				case GlobalVariables.ActiveUnitType.Facility:
				{
					bool flag = true;
					int num = theSubType;
					if (theSubType >= FACILITY_SUBTYPE_OFFSET_INDEX)
					{
						num -= FACILITY_SUBTYPE_OFFSET_INDEX;
						flag = false;
					}
					foreach (DataRow row4 in theScen.Cache_Facilities_DT.Rows)
					{
						if (!flag)
						{
							if (Conversions.ToInteger(row4["Category"]) == num && (!LimitToExistingClasses || ScenarioContains(theType, theSubType, Conversions.ToInteger(row4["ID"]), theScen)))
							{
								dataTable.Rows.Add(Conversions.ToInteger(row4["ID"]), row4["LongName"]);
							}
						}
						else if (Facility.MobileUnitCategory(row4["Name"].ToString()) == (IMobileGroundUnit._MobileUnitCategory)num && (!LimitToExistingClasses || ScenarioContains(theType, theSubType, Conversions.ToInteger(row4["ID"]), theScen)))
						{
							dataTable.Rows.Add(Conversions.ToInteger(row4["ID"]), row4["LongName"]);
						}
					}
					break;
				}
				case GlobalVariables.ActiveUnitType.Weapon:
					foreach (DataRow row5 in theScen.Cache_Weapons_DT.Rows)
					{
						if (Conversions.ToInteger(row5["Type"]) == theSubType && (!LimitToExistingClasses || ScenarioContains(theType, theSubType, Conversions.ToInteger(row5["ID"]), theScen)))
						{
							dataTable.Rows.Add(Conversions.ToInteger(row5["ID"]), row5["LongName"]);
						}
					}
					break;
				case GlobalVariables.ActiveUnitType.Vehicle:
					foreach (DataRow row6 in theScen.Cache_GroundUnits_DT.Rows)
					{
						if (Conversions.ToInteger(row6["Category"]) == theSubType && (!LimitToExistingClasses || ScenarioContains(theType, theSubType, Conversions.ToInteger(row6["ID"]), theScen)))
						{
							dataTable.Rows.Add(Conversions.ToInteger(row6["ID"]), row6["LongName"]);
						}
					}
					break;
				}
			}
			((ListControl)combo).DisplayMember = "Description";
			((ListControl)combo).ValueMember = "ID";
			combo.DataSource = dataTable;
			combo.SelectedIndex = 0;
		}
	}

	public enum DoctrineItemAutopopulate
	{
		None,
		DefaultValue,
		Inherited
	}

	public class EMCONSettings
	{
		public enum _EMCONSetting : byte
		{
			Passive,
			Active,
			Various,
			NotConfigured,
			Intermittent
		}

		private _EMCONSetting _EMCONSetting_0;

		private _EMCONSetting _EMCONSetting_1;

		private _EMCONSetting _EMCONSetting_2;

		public EMCONSettings()
		{
		}

		public EMCONSettings(_EMCONSetting RadarSetting, _EMCONSetting SonarSetting, _EMCONSetting _EMCONSetting_3)
		{
			_EMCONSetting_0 = RadarSetting;
			_EMCONSetting_1 = SonarSetting;
			_EMCONSetting_2 = _EMCONSetting_3;
		}

		public bool HasActiveEmissions()
		{
			if (_EMCONSetting_0 != _EMCONSetting.Active && _EMCONSetting_1 != _EMCONSetting.Active)
			{
				return _EMCONSetting_2 == _EMCONSetting.Active;
			}
			return true;
		}

		internal _EMCONSetting Radar()
		{
			return _EMCONSetting_0;
		}

		internal _EMCONSetting Sonar()
		{
			return _EMCONSetting_1;
		}

		internal _EMCONSetting OECM()
		{
			return _EMCONSetting_2;
		}

		public static _EMCONSetting EMCONSettingSelection_To_EMCONSetting(int value)
		{
			return value switch
			{
				1 => _EMCONSetting.Active, 
				0 => _EMCONSetting.Passive, 
				_ => _EMCONSetting.NotConfigured, 
			};
		}

		static EMCONSettings()
		{
			Class72.smethod_20();
		}
	}

	public class WRA_Weapon
	{
		public WRADictionary<WRA_FiringDoctrineEntry> WRA_WeaponTargets;

		private Weapon weapon_0;

		public WRA_FiringDoctrineEntry AddTo_WRAWeaponTargets(_WRA_WeaponTargetType type, WRA_FiringDoctrineEntry entry = null)
		{
			if (entry == null)
			{
				entry = new WRA_FiringDoctrineEntry(type);
			}
			if (!WRA_WeaponTargets.ContainsKey((int)type))
			{
				WRA_WeaponTargets.Add((int)type, entry);
			}
			return entry;
		}

		public void AddTo_WRAWeaponTargets(WRA_FiringDoctrineEntry entry)
		{
			if (!WRA_WeaponTargets.ContainsKey((int)entry.TargetType))
			{
				WRA_WeaponTargets.Add((int)entry.TargetType, entry);
			}
		}

		public WRA_Weapon()
		{
			WRA_WeaponTargets = new WRADictionary<WRA_FiringDoctrineEntry>();
		}

		public WRA_Weapon(ref Weapon myWeapon, Scenario theScen)
		{
			WRA_WeaponTargets = new WRADictionary<WRA_FiringDoctrineEntry>();
			WRADictionary<WRA_FiringDoctrineEntry> thelist = new WRADictionary<WRA_FiringDoctrineEntry>();
			if (!myWeapon.ValidTargets.Aircraft)
			{
				if (myWeapon.ValidTargets.Helicopter)
				{
					Populate_WRAWeaponTarget_Collection(_WRA_WeaponTargetType.Helicopter_Unspecified, ref thelist);
				}
			}
			else
			{
				Populate_WRAWeaponTarget_Collection(_WRA_WeaponTargetFamilyType.Aircrafts, ref thelist);
			}
			if (myWeapon.ValidTargets.Missile)
			{
				Populate_WRAWeaponTarget_Collection(_WRA_WeaponTargetFamilyType.Missile, ref thelist);
			}
			if (myWeapon.ValidTargets.Satellite)
			{
				Populate_WRAWeaponTarget_Collection(_WRA_WeaponTargetFamilyType.Satellite, ref thelist);
			}
			if (myWeapon.ValidTargets.SurfaceVessel)
			{
				Populate_WRAWeaponTarget_Collection(_WRA_WeaponTargetFamilyType.SurfaceVessel, ref thelist);
			}
			if (myWeapon.ValidTargets.Submarine)
			{
				Populate_WRAWeaponTarget_Collection(_WRA_WeaponTargetFamilyType.Submarines, ref thelist);
			}
			if (myWeapon.ValidTargets.LandStructure_Soft || myWeapon.ValidTargets.LandStructure_Hard)
			{
				Populate_WRAWeaponTarget_Collection(_WRA_WeaponTargetFamilyType.LandStructureHard, ref thelist);
				Populate_WRAWeaponTarget_Collection(_WRA_WeaponTargetFamilyType.LandStructureSoft, ref thelist);
			}
			if (myWeapon.ValidTargets.Runway)
			{
				Populate_WRAWeaponTarget_Collection(_WRA_WeaponTargetFamilyType.Runway, ref thelist);
			}
			if (myWeapon.ValidTargets.Radar)
			{
				Populate_WRAWeaponTarget_Collection(_WRA_WeaponTargetFamilyType.Emitter, ref thelist);
			}
			int family;
			int num;
			if (myWeapon.ValidTargets.MobileTarget_Soft)
			{
				family = 12;
			}
			else
			{
				if (!myWeapon.ValidTargets.MobileTarget_Hard)
				{
					num = 0;
					goto IL_0134;
				}
				family = 12;
			}
			Populate_WRAWeaponTarget_Collection((_WRA_WeaponTargetFamilyType)family, ref thelist);
			Populate_WRAWeaponTarget_Collection(_WRA_WeaponTargetFamilyType.MobileSoft, ref thelist);
			num = 0;
			goto IL_0134;
			IL_0134:
			bool flag = (byte)num != 0;
			foreach (WRA_Weapon value in myWeapon.Doctrine.WRA.Values)
			{
				if ((myWeapon.ValidTargets.LandStructure_Soft || myWeapon.ValidTargets.LandStructure_Hard) && !myWeapon.ValidTargets.MobileTarget_Soft && !myWeapon.ValidTargets.MobileTarget_Hard)
				{
					foreach (int key in value.WRA_WeaponTargets.Keys)
					{
						int family2;
						if (key != 5400)
						{
							if (key != 5500)
							{
								continue;
							}
							family2 = 12;
						}
						else
						{
							family2 = 12;
						}
						Populate_WRAWeaponTarget_Collection((_WRA_WeaponTargetFamilyType)family2, ref thelist);
						Populate_WRAWeaponTarget_Collection(_WRA_WeaponTargetFamilyType.MobileSoft, ref thelist);
						flag = true;
						break;
					}
				}
				if (flag)
				{
					break;
				}
			}
			if (myWeapon.ValidTargets.UnderwaterStructure)
			{
				Populate_WRAWeaponTarget_Collection(_WRA_WeaponTargetFamilyType.Underwater, ref thelist);
			}
			if (myWeapon.ValidTargets.AirBaseSingleUnit)
			{
				Populate_WRAWeaponTarget_Collection(_WRA_WeaponTargetFamilyType.SingleUnitAirbase, ref thelist);
			}
			WRA_WeaponTargets = thelist;
		}

		public void WRA_Skeleton(ref Weapon theWeapon)
		{
			List<WRA_FiringDoctrineEntry> list = new List<WRA_FiringDoctrineEntry>();
			int theTargetType;
			int value;
			if (!theWeapon.ValidTargets.Aircraft && !theWeapon.ValidTargets.Helicopter && !theWeapon.ValidTargets.Missile)
			{
				if (!theWeapon.ValidTargets.Satellite)
				{
					goto IL_0077;
				}
				theTargetType = 1999;
				value = 2;
			}
			else
			{
				theTargetType = 1999;
				value = 2;
			}
			WRA_FiringDoctrineEntry item = new WRA_FiringDoctrineEntry((_WRA_WeaponTargetType)theTargetType, value, 1, 0f, null);
			list.Add(item);
			goto IL_0077;
			IL_0773:
			if (theWeapon.ValidTargets.MobileTarget_Soft || (theWeapon.ValidTargets.LandStructure_Soft && !theWeapon.Flags.PreBriefedTargetOnly && !theWeapon.ValidTargets.MobileTarget_Soft) || theWeapon.ValidTargets.MobileTarget_Hard || (theWeapon.ValidTargets.LandStructure_Hard && !theWeapon.Flags.PreBriefedTargetOnly && !theWeapon.ValidTargets.MobileTarget_Hard))
			{
				int theTargetType2;
				int value2;
				if (theWeapon.Type != Weapon._WeaponType.Gun && theWeapon.Type != Weapon._WeaponType.Rocket)
				{
					if (theWeapon.Type != Weapon._WeaponType.IronBomb)
					{
						WRA_FiringDoctrineEntry item2 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Mobile_Target_Soft_Unspecified, -2, 1, 0f, null);
						list.Add(item2);
						item2 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Mobile_Target_Hardened_Unspecified, -2, 1, 0f, null);
						list.Add(item2);
						goto IL_08f9;
					}
					theTargetType2 = 5400;
					value2 = -99;
				}
				else
				{
					theTargetType2 = 5400;
					value2 = -99;
				}
				WRA_FiringDoctrineEntry item3 = new WRA_FiringDoctrineEntry((_WRA_WeaponTargetType)theTargetType2, value2, -99, 0f, null);
				list.Add(item3);
				item3 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Mobile_Target_Hardened_Unspecified, -99, -99, 0f, null);
				list.Add(item3);
			}
			goto IL_08f9;
			IL_09a8:
			if (theWeapon.ValidTargets.AirBaseSingleUnit)
			{
				int theTargetType3;
				int value3;
				if (theWeapon.Type != Weapon._WeaponType.Gun && theWeapon.Type != Weapon._WeaponType.Rocket)
				{
					if (theWeapon.Type != Weapon._WeaponType.IronBomb)
					{
						WRA_FiringDoctrineEntry item4 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Air_Base_Single_Unit_Airfield, -2, 1, 0f, null);
						list.Add(item4);
						goto IL_0a57;
					}
					theTargetType3 = 5801;
					value3 = -99;
				}
				else
				{
					theTargetType3 = 5801;
					value3 = -99;
				}
				WRA_FiringDoctrineEntry item5 = new WRA_FiringDoctrineEntry((_WRA_WeaponTargetType)theTargetType3, value3, -99, 0f, null);
				list.Add(item5);
			}
			goto IL_0a57;
			IL_032b:
			if (theWeapon.ValidTargets.Submarine)
			{
				if (theWeapon.Type == Weapon._WeaponType.DepthCharge)
				{
					WRA_FiringDoctrineEntry item6 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Submarine_Unspecified, -99, -99, 0f, null);
					list.Add(item6);
					item6 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Subsurface_Contact_Unknown_Type, -99, -99, 0f, null);
					list.Add(item6);
				}
				else
				{
					WRA_FiringDoctrineEntry item7 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Submarine_Unspecified, 2, 1, 0f, null);
					list.Add(item7);
					item7 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Subsurface_Contact_Unknown_Type, 2, 1, 0f, null);
					list.Add(item7);
				}
			}
			if (theWeapon.ValidTargets.LandStructure_Soft || theWeapon.ValidTargets.LandStructure_Hard || theWeapon.ValidTargets.MobileTarget_Soft || theWeapon.ValidTargets.MobileTarget_Hard || theWeapon.ValidTargets.Runway || theWeapon.ValidTargets.UnderwaterStructure || theWeapon.ValidTargets.AerostatMooring || theWeapon.ValidTargets.AirBaseSingleUnit)
			{
				int theTargetType4;
				int value4;
				if (theWeapon.Type != Weapon._WeaponType.Gun && theWeapon.Type != Weapon._WeaponType.Rocket)
				{
					if (theWeapon.Type != Weapon._WeaponType.IronBomb)
					{
						WRA_FiringDoctrineEntry item8 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Land_Contact_Unknown_Type, 2, 1, 0f, null);
						list.Add(item8);
						item8 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Runway_Facility_Unspecified, 2, 1, 0f, null);
						list.Add(item8);
						goto IL_0597;
					}
					theTargetType4 = 4999;
					value4 = -99;
				}
				else
				{
					theTargetType4 = 4999;
					value4 = -99;
				}
				WRA_FiringDoctrineEntry item9 = new WRA_FiringDoctrineEntry((_WRA_WeaponTargetType)theTargetType4, value4, -99, 0f, null);
				list.Add(item9);
				item9 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Runway_Facility_Unspecified, -99, -99, 0f, null);
				list.Add(item9);
			}
			goto IL_0597;
			IL_010f:
			if (theWeapon.ValidTargets.Missile)
			{
				WRA_FiringDoctrineEntry item10 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Guided_Weapon_Unspecified, 2, 1, 0f, null);
				list.Add(item10);
			}
			if (theWeapon.ValidTargets.Satellite)
			{
				WRA_FiringDoctrineEntry item11 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Satellite_Unspecified, 2, 1, 0f, null);
				list.Add(item11);
			}
			if (theWeapon.ValidTargets.SurfaceVessel)
			{
				int theTargetType5;
				int value5;
				if (theWeapon.Type != Weapon._WeaponType.Gun && theWeapon.Type != Weapon._WeaponType.Rocket)
				{
					if (theWeapon.Type != Weapon._WeaponType.IronBomb)
					{
						if (theWeapon.Type == Weapon._WeaponType.Torpedo)
						{
							WRA_FiringDoctrineEntry item12 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Surface_Contact_Unknown_Type, 2, 1, 0f, null);
							list.Add(item12);
							item12 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Unspecified, 2, 1, 0f, null);
							list.Add(item12);
						}
						else
						{
							WRA_FiringDoctrineEntry item13 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Surface_Contact_Unknown_Type, 2, 1, 0f, null);
							list.Add(item13);
							item13 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Unspecified, -2, -99, 0f, null);
							list.Add(item13);
						}
						goto IL_032b;
					}
					theTargetType5 = 2999;
					value5 = -99;
				}
				else
				{
					theTargetType5 = 2999;
					value5 = -99;
				}
				WRA_FiringDoctrineEntry item14 = new WRA_FiringDoctrineEntry((_WRA_WeaponTargetType)theTargetType5, value5, -99, 0f, null);
				list.Add(item14);
				item14 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Unspecified, -99, -99, 0f, null);
				list.Add(item14);
			}
			goto IL_032b;
			IL_08f9:
			if (theWeapon.ValidTargets.UnderwaterStructure)
			{
				int theTargetType6;
				int value6;
				if (theWeapon.Type != Weapon._WeaponType.Gun && theWeapon.Type != Weapon._WeaponType.Rocket)
				{
					if (theWeapon.Type != Weapon._WeaponType.IronBomb)
					{
						WRA_FiringDoctrineEntry item15 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Underwater_Structure, -2, 1, 0f, null);
						list.Add(item15);
						goto IL_09a8;
					}
					theTargetType6 = 5601;
					value6 = -99;
				}
				else
				{
					theTargetType6 = 5601;
					value6 = -99;
				}
				WRA_FiringDoctrineEntry item16 = new WRA_FiringDoctrineEntry((_WRA_WeaponTargetType)theTargetType6, value6, -99, 0f, null);
				list.Add(item16);
			}
			goto IL_09a8;
			IL_0a57:
			WRA_WeaponTargets.Clear();
			foreach (WRA_FiringDoctrineEntry item23 in list)
			{
				AddTo_WRAWeaponTargets(item23);
			}
			return;
			IL_0077:
			if (theWeapon.ValidTargets.Aircraft)
			{
				WRA_FiringDoctrineEntry item17 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Aircraft_Unspecified, 2, 1, 0f, null);
				list.Add(item17);
			}
			int theTargetType7;
			int value7;
			if (theWeapon.ValidTargets.Helicopter)
			{
				theTargetType7 = 2100;
				value7 = 2;
			}
			else
			{
				if (!theWeapon.ValidTargets.Aircraft)
				{
					goto IL_010f;
				}
				theTargetType7 = 2100;
				value7 = 2;
			}
			WRA_FiringDoctrineEntry item18 = new WRA_FiringDoctrineEntry((_WRA_WeaponTargetType)theTargetType7, value7, 1, 0f, null);
			list.Add(item18);
			goto IL_010f;
			IL_0597:
			if (theWeapon.ValidTargets.LandStructure_Soft || theWeapon.ValidTargets.LandStructure_Hard)
			{
				int theTargetType8;
				int value8;
				if (theWeapon.Type != Weapon._WeaponType.Gun && theWeapon.Type != Weapon._WeaponType.Rocket)
				{
					if (theWeapon.Type != Weapon._WeaponType.IronBomb)
					{
						WRA_FiringDoctrineEntry item19 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Land_Structure_Soft_Unspecified, -2, 1, 0f, null);
						list.Add(item19);
						item19 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Land_Structure_Hardened_Unspecified, -2, 1, 0f, null);
						list.Add(item19);
						goto IL_06c3;
					}
					theTargetType8 = 5000;
					value8 = -99;
				}
				else
				{
					theTargetType8 = 5000;
					value8 = -99;
				}
				WRA_FiringDoctrineEntry item20 = new WRA_FiringDoctrineEntry((_WRA_WeaponTargetType)theTargetType8, value8, -99, 0f, null);
				list.Add(item20);
				item20 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Land_Structure_Hardened_Unspecified, -99, -99, 0f, null);
				list.Add(item20);
			}
			goto IL_06c3;
			IL_06c3:
			if (theWeapon.ValidTargets.Radar)
			{
				int theTargetType9;
				int value9;
				if (theWeapon.Type != Weapon._WeaponType.Gun && theWeapon.Type != Weapon._WeaponType.Rocket)
				{
					if (theWeapon.Type != Weapon._WeaponType.IronBomb)
					{
						WRA_FiringDoctrineEntry item21 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Emitter_Unspecified, -2, -99, 0f, null);
						list.Add(item21);
						goto IL_0773;
					}
					theTargetType9 = 5300;
					value9 = -99;
				}
				else
				{
					theTargetType9 = 5300;
					value9 = -99;
				}
				WRA_FiringDoctrineEntry item22 = new WRA_FiringDoctrineEntry((_WRA_WeaponTargetType)theTargetType9, value9, -99, 0f, null);
				list.Add(item22);
			}
			goto IL_0773;
		}

		internal Weapon ReferenceWeapon(Scenario theScen, int int_0)
		{
			if (weapon_0 == null)
			{
				if (IsUnguidedWeapon(theScen, int_0))
				{
					weapon_0 = theScen.Cache_GetWeapon(int_0);
				}
				else
				{
					weapon_0 = Weapon.GetNewWeapon(ref theScen, int_0, bool_5: false);
				}
			}
			return weapon_0;
		}

		public bool IsUnguidedWeapon(Scenario theScen, int int_0)
		{
			SQLiteConnection sqliteConnection_ = theScen.DBConnection;
			Weapon._WeaponType weaponType = DBFunctions.GetWeaponType(int_0, ref sqliteConnection_);
			int result;
			int result2;
			if (weaponType <= Weapon._WeaponType.DepthCharge)
			{
				if ((uint)(weaponType - 2002) > 2u)
				{
					if (weaponType != Weapon._WeaponType.DepthCharge)
					{
						result = 0;
						goto IL_0048;
					}
					goto IL_004b;
				}
				result2 = 1;
			}
			else
			{
				if ((uint)(weaponType - 6001) > 2u)
				{
					if ((uint)(weaponType - 9002) > 1u)
					{
						result = 0;
						goto IL_0048;
					}
					goto IL_004b;
				}
				result2 = 1;
			}
			goto IL_004c;
			IL_0048:
			return (byte)result != 0;
			IL_004b:
			result2 = 1;
			goto IL_004c;
			IL_004c:
			return (byte)result2 != 0;
		}

		static WRA_Weapon()
		{
			Class72.smethod_20();
		}
	}

	public class WRA_FiringDoctrineEntry
	{
		public _WRA_WeaponTargetType TargetType;

		public int? WeaponQty;

		private int? nullable_0;

		public float? FiringRange;

		public float? SelfDefenceRange;

		public int? ShooterQty
		{
			get
			{
				int? num = nullable_0;
				if ((num.HasValue ? new bool?(num == -101) : ((bool?)null)) == true)
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					return -99;
				}
				return nullable_0;
			}
			set
			{
				int? num = value;
				if (((!num.HasValue) ? ((bool?)null) : new bool?(num == -101)) == true)
				{
					_ = Debugger.IsAttached;
					value = -99;
				}
				nullable_0 = value;
			}
		}

		public WRA_FiringDoctrineEntry()
		{
		}

		public WRA_FiringDoctrineEntry(WeaponTargets ValidTargets)
		{
		}

		public WRA_FiringDoctrineEntry(_WRA_WeaponTargetType theTargetType)
		{
			try
			{
				TargetType = theTargetType;
				WeaponQty = null;
				ShooterQty = null;
				SelfDefenceRange = null;
				FiringRange = null;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101196", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}

		public WRA_FiringDoctrineEntry(_WRA_WeaponTargetType theTargetType, int? theWeaponQty, int? theShooterQty, float? theSelfDefenceRange, float? theFiringRange)
		{
			try
			{
				TargetType = theTargetType;
				WeaponQty = theWeaponQty;
				ShooterQty = theShooterQty;
				SelfDefenceRange = theSelfDefenceRange;
				FiringRange = theFiringRange;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101203", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}

		static WRA_FiringDoctrineEntry()
		{
			Class72.smethod_20();
		}
	}

	public enum _WRA_WeaponTargetType
	{
		None = 1001,
		Decoy = 1002,
		Air_Contact_Unknown_Type = 1999,
		Aircraft_Unspecified = 2000,
		Aircraft_5th_Generation = 2001,
		Aircraft_4th_Generation = 2002,
		Aircraft_3rd_Generation = 2003,
		Aircraft_Less_Capable = 2004,
		Aircraft_High_Perf_Bombers = 2011,
		Aircraft_Medium_Perf_Bombers = 2012,
		Aircraft_Low_Perf_Bombers = 2013,
		Aircraft_High_Perf_Recon_EW = 2021,
		Aircraft_Medium_Perf_Recon_EW = 2022,
		Aircraft_Low_Perf_Recon_EW = 2023,
		Aircraft_AEW = 2031,
		Aircraft_Class1_UAS = 2032,
		Aircraft_Tanker = 2033,
		Aircraft_Class2_UAS = 2034,
		Helicopter_Unspecified = 2100,
		Guided_Weapon_Unspecified = 2200,
		Guided_Weapon_Supersonic_Sea_Skimming = 2201,
		Guided_Weapon_Subsonic_Sea_Skimming = 2202,
		Guided_Weapon_Supersonic = 2203,
		Guided_Weapon_Subsonic = 2204,
		Guided_Weapon_Ballistic = 2211,
		Satellite_Unspecified = 2300,
		C_RAM = 2400,
		Surface_Contact_Unknown_Type = 2999,
		Ship_Unspecified = 3000,
		Ship_Carrier_0_25000_tons = 3001,
		Ship_Carrier_25001_45000_tons = 3002,
		Ship_Carrier_45001_95000_tons = 3003,
		Ship_Carrier_95000_tons = 3004,
		Ship_Surface_Combatant_0_500_tons = 3101,
		Ship_Surface_Combatant_501_1500_tons = 3102,
		Ship_Surface_Combatant_1501_5000_tons = 3103,
		Ship_Surface_Combatant_5001_10000_tons = 3104,
		Ship_Surface_Combatant_10001_25000_tons = 3105,
		Ship_Surface_Combatant_25001_45000_tons = 3106,
		Ship_Surface_Combatant_45001_95000_tons = 3107,
		Ship_Surface_Combatant_95000_tons = 3108,
		Ship_Amphibious_0_500_tons = 3201,
		Ship_Amphibious_501_1500_tons = 3202,
		Ship_Amphibious_1501_5000_tons = 3203,
		Ship_Amphibious_5001_10000_tons = 3204,
		Ship_Amphibious_10001_25000_tons = 3205,
		Ship_Amphibious_25001_45000_tons = 3206,
		Ship_Amphibious_45001_95000_tons = 3207,
		Ship_Amphibious_95000_tons = 3208,
		Ship_Auxiliary_0_500_tons = 3301,
		Ship_Auxiliary_501_1500_tons = 3302,
		Ship_Auxiliary_1501_5000_tons = 3303,
		Ship_Auxiliary_5001_10000_tons = 3304,
		Ship_Auxiliary_10001_25000_tons = 3305,
		Ship_Auxiliary_25001_45000_tons = 3306,
		Ship_Auxiliary_45001_95000_tons = 3307,
		Ship_Auxiliary_95000_tons = 3308,
		Ship_Merchant_Civilian_0_500_tons = 3401,
		Ship_Merchant_Civilian_501_1500_tons = 3402,
		Ship_Merchant_Civilian_1501_5000_tons = 3403,
		Ship_Merchant_Civilian_5001_10000_tons = 3404,
		Ship_Merchant_Civilian_10001_25000_tons = 3405,
		Ship_Merchant_Civilian_25001_45000_tons = 3406,
		Ship_Merchant_Civilian_45001_95000_tons = 3407,
		Ship_Merchant_Civilian_95000_tons = 3408,
		Submarine_Surfaced = 3501,
		Subsurface_Contact_Unknown_Type = 3999,
		Submarine_Unspecified = 4000,
		Land_Contact_Unknown_Type = 4999,
		Land_Structure_Soft_Unspecified = 5000,
		Land_Structure_Soft_Building_Surface = 5001,
		Land_Structure_Soft_Building_Reveted = 5002,
		Land_Structure_Soft_Building_Bunker = 5003,
		Land_Structure_Soft_Building_Underground = 5004,
		Land_Structure_Soft_Structure_Open = 5005,
		Land_Structure_Soft_Structure_Reveted = 5006,
		Land_Structure_Soft_Aerostat_Moring = 5011,
		Land_Structure_Hardened_Unspecified = 5100,
		Land_Structure_Hardened_Building_Surface = 5101,
		Land_Structure_Hardened_Building_Reveted = 5102,
		Land_Structure_Hardened_Building_Bunker = 5103,
		Land_Structure_Hardened_Building_Underground = 5104,
		Land_Structure_Hardened_Structure_Open = 5105,
		Land_Structure_Hardened_Structure_Reveted = 5106,
		Runway_Facility_Unspecified = 5200,
		Runway = 5201,
		Runway_Grade_Taxiway = 5202,
		Runway_Access_Point = 5203,
		Emitter_Unspecified = 5300,
		Emitter_Radar = 5310,
		Emitter_Jammer = 5320,
		Mobile_Target_Soft_Unspecified = 5400,
		Mobile_Target_Soft_Mobile_Vehicle = 5401,
		Mobile_Target_Soft_Mobile_Personnel = 5402,
		Mobile_Target_Hardened_Unspecified = 5500,
		Mobile_Target_Hardened_Mobile_Vehicle = 5501,
		Underwater_Structure = 5601,
		Air_Base_Single_Unit_Airfield = 5801
	}

	public enum _WRA_WeaponTargetFamilyType
	{
		Decoy,
		Aircrafts,
		Missile,
		Satellite,
		C_RAM,
		SurfaceVessel,
		Submarines,
		LandStructureSoft,
		LandStructureHard,
		Runway,
		Emitter,
		MobileSoft,
		MobileHard,
		Underwater,
		SingleUnitAirbase
	}

	public enum _WRA_WeaponQty
	{
		SystemDefault = -1,
		DoNotUse = 0,
		NotDefined = -98,
		AllWeapons = -99,
		MissileDefence = -2,
		MissileDefence_x_2 = -3,
		MissileDefence_x_4 = -4,
		MissileDefence_d_2 = -5,
		MissileDefence_d_4 = -6,
		Various = -100,
		NotConfigured = -101
	}

	public enum _WRA_ShooterQty
	{
		SystemDefault = -1,
		AnyNumber = -99,
		Various = -100,
		NotConfigured = -101
	}

	public enum _WRA_SelfDefenceRange
	{
		SystemDefault = -1,
		DoNotUse = 0,
		NotDefined = -98,
		MaxRange = -99,
		Various = -100,
		NotConfigured = -101,
		NoEscapeZone = -102
	}

	public enum _WRA_FiringRange
	{
		DoNotUse = 0,
		Range25Percent = -95,
		Range50Percent = -96,
		Range75Percent = -97,
		NotDefined = -98,
		MaxRange = -99,
		Various = -100,
		NotConfigured = -101,
		NoEscapeZone = -102
	}

	public class DoctrineItem
	{
		public DoctrineDefinition Definifition;

		public int? _CurrentState;

		public bool _PlayerEditable;

		public Doctrine Doctrine;

		public HashSet<IUIListener> hashSet_0;

		public bool IsInheriting
		{
			get
			{
				if (Doctrine.CanInheritDoctrine)
				{
					return !_CurrentState.HasValue;
				}
				return false;
			}
		}

		public ScenarioObject Subject => Doctrine.Subject;

		public int? CurrentState
		{
			get
			{
				if (ConsiderInheritance)
				{
					int? result;
					if (Subject is Side)
					{
						if (_CurrentState.HasValue)
						{
							return _CurrentState;
						}
						result = 0;
					}
					else
					{
						try
						{
							if (IsInheriting)
							{
								Doctrine doctrine = Doctrine;
								bool UnitIsOperating = true;
								Doctrine parentDoctrine = doctrine.GetParentDoctrine(ref UnitIsOperating);
								if (parentDoctrine != null)
								{
									return parentDoctrine.GetElement(Definifition).get_CurrentState(ConsiderInheritance);
								}
							}
							return _CurrentState;
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception ex2 = ex;
							ex2?.Data.Add("Error at Doctrine item (current state) " + Definifition.ID, ex2.Message);
							GameGeneral.WriteExceptionsToLog(ex2);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							result = 0;
							ProjectData.ClearProjectError();
						}
					}
					return result;
				}
				return _CurrentState;
			}
			set
			{
				_CurrentState = value;
				PropagateToListeners();
			}
		}

		public bool PlayerEditable
		{
			get
			{
				return _PlayerEditable;
			}
			set
			{
				_PlayerEditable = value;
				PropagateToListeners();
			}
		}

		public DoctrineItem(DoctrineItem Original, Doctrine Doctrine)
		{
			_CurrentState = null;
			hashSet_0 = new HashSet<IUIListener>();
			Definifition = Original.Definifition;
			_CurrentState = Original._CurrentState;
			_PlayerEditable = Original._PlayerEditable;
			this.Doctrine = Doctrine;
		}

		public DoctrineItem(DoctrineDefinition Definifition, int? _CurrentState, bool PlayerEditable, Doctrine Doctrine)
		{
			this._CurrentState = null;
			hashSet_0 = new HashSet<IUIListener>();
			this.Definifition = Definifition;
			this._CurrentState = _CurrentState;
			this.PlayerEditable = PlayerEditable;
			this.Doctrine = Doctrine;
		}

		public DoctrineItem(DoctrineDefinition Definifition, Doctrine Doctrine, DoctrineItemAutopopulate DefaultValue)
		{
			_CurrentState = null;
			hashSet_0 = new HashSet<IUIListener>();
			this.Definifition = Definifition;
			this.Doctrine = Doctrine;
			Type type = Doctrine.Subject.GetType();
			if ((object)type != typeof(Side))
			{
				_ = (object)type == typeof(Waypoint);
			}
			if (Doctrine.CanInheritDoctrine)
			{
				return;
			}
			Type type2 = Doctrine.Subject.GetType();
			if (!(type2 == typeof(Side)))
			{
				if (!(type2 == typeof(Waypoint)))
				{
					if (DefaultValue == DoctrineItemAutopopulate.DefaultValue || DefaultValue == DoctrineItemAutopopulate.None)
					{
						if (Definifition.DefaultState[2].HasValue)
						{
							int? currentState = default(int?);
							_CurrentState = currentState;
						}
						else
						{
							_CurrentState = null;
						}
					}
					_PlayerEditable = Definifition.DefaultPlayerEditable[2];
				}
				else
				{
					_CurrentState = Definifition.DefaultState[1];
					_PlayerEditable = Definifition.DefaultPlayerEditable[1];
				}
			}
			else
			{
				_CurrentState = Definifition.DefaultState[0];
				_PlayerEditable = Definifition.DefaultPlayerEditable[0];
			}
		}

		public void SetToDefaultValue()
		{
			Type type = Doctrine.Subject.GetType();
			if (!Doctrine.CanInheritDoctrine)
			{
				if ((object)type == typeof(Side))
				{
					_CurrentState = Definifition.DefaultState[0];
				}
				else if ((object)type == typeof(Waypoint))
				{
					_CurrentState = Definifition.DefaultState[1];
				}
				else
				{
					_CurrentState = 0;
				}
			}
			else
			{
				_CurrentState = Definifition.DefaultState[2];
			}
			PropagateToListeners();
		}

		public string GetStateReadableString(bool ConsiderInheritance = false)
		{
			int? num = this.get_CurrentState(ConsiderInheritance);
			if (num.HasValue && Definifition.States.TryGetValue(num.Value, out var value))
			{
				return value;
			}
			return "Undefined";
		}

		public void PropagateToListeners()
		{
			if (Doctrine.method_0())
			{
				return;
			}
			foreach (IUIListener item in hashSet_0)
			{
				item.updateListener();
			}
		}

		public void AddListener(IUIListener Listener)
		{
			if (!hashSet_0.Contains(Listener))
			{
				hashSet_0.Add(Listener);
			}
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return !_CurrentState.HasValue;
			}
			if (!_CurrentState.HasValue)
			{
				return obj == null;
			}
			if (!(obj is Enum))
			{
				if (!(obj is int? num))
				{
					if (!(obj is DoctrineItem))
					{
						return false;
					}
					DoctrineItem doctrineItem = (DoctrineItem)obj;
					return _CurrentState.Equals(doctrineItem._CurrentState);
				}
				return _CurrentState.Equals(num);
			}
			Conversions.ToInteger(obj);
			return _CurrentState.Equals(_CurrentState.Value);
		}

		static DoctrineItem()
		{
			Class72.smethod_20();
		}
	}

	[Serializable]
	public class DoctrineDefinition
	{
		public string ID;

		public string Name;

		public string Description;

		public Dictionary<int, string> States;

		[NonSerialized]
		public Dictionary<string, int> _States_2way;

		public DoctrineCategory Category;

		public DoctrineItem_E EnumLink;

		public int MinNumericValue;

		public int MaxNumericValue;

		public string MeasurementUnit;

		public HashSet<GlobalVariables.ActiveUnitType> UnitType_Exclusion;

		public HashSet<GlobalVariables.ActiveUnitType> UnitType_Requirement;

		public int?[] DefaultState;

		public bool[] DefaultPlayerEditable;

		public List<string> _SaveID;

		public List<string> _SaveID_PlayerEditable;

		public string _LuaID;

		public bool UseLegacyBooleanState;

		public string Magic255Value;

		private static (string, bool)[] valueTuple_0;

		public bool IsNumeric
		{
			get
			{
				if (MinNumericValue == 0)
				{
					return MaxNumericValue != 0;
				}
				return true;
			}
		}

		public string SaveID
		{
			get
			{
				string text = "";
				if (_SaveID.Count > 0)
				{
					text = _SaveID[0];
				}
				if (!string.IsNullOrEmpty(text))
				{
					return text;
				}
				return ID;
			}
		}

		public string SaveID_PlayerEditable
		{
			get
			{
				string text = "";
				if (_SaveID_PlayerEditable.Count > 0)
				{
					text = _SaveID_PlayerEditable[0];
				}
				if (!string.IsNullOrEmpty(text))
				{
					return text;
				}
				return ID + "_PE";
			}
		}

		public string LuaID
		{
			get
			{
				if (string.IsNullOrEmpty(_LuaID))
				{
					return ID.ToLowerInvariant();
				}
				return _LuaID;
			}
		}

		static DoctrineDefinition()
		{
			Class72.smethod_20();
			valueTuple_0 = new(string, bool)[5]
			{
				("Yes", true),
				("No", false),
				("Free", true),
				("YesLeaveGroup", true),
				("Pessimistic", true)
			};
		}

		public static bool? GetLegacyBooleanState(string State)
		{
			(string, bool)[] array = valueTuple_0;
			int num = 0;
			bool? result;
			while (true)
			{
				if (num < array.Length)
				{
					(string, bool) tuple = array[num];
					if (Operators.CompareString(State, tuple.Item1, false) != 0)
					{
						num = checked(num + 1);
						continue;
					}
					result = tuple.Item2;
					break;
				}
				result = false;
				break;
			}
			return result;
		}

		public DoctrineDefinition()
		{
			States = new Dictionary<int, string>();
			_States_2way = new Dictionary<string, int>();
			MinNumericValue = 0;
			MaxNumericValue = 0;
			UnitType_Exclusion = new HashSet<GlobalVariables.ActiveUnitType>();
			UnitType_Requirement = new HashSet<GlobalVariables.ActiveUnitType>();
			_SaveID = new List<string>();
			_SaveID_PlayerEditable = new List<string>();
		}

		public DoctrineDefinition(string _ID, DoctrineItem_E _EnumLink, string _Name, string _Description, List<string> _States, DoctrineCategory _Category, List<(DoctrinePossibleSubjects, string)> DefaultState = null, List<(DoctrinePossibleSubjects, bool)> DefaultPlayerEditable = null)
		{
			States = new Dictionary<int, string>();
			_States_2way = new Dictionary<string, int>();
			MinNumericValue = 0;
			MaxNumericValue = 0;
			UnitType_Exclusion = new HashSet<GlobalVariables.ActiveUnitType>();
			UnitType_Requirement = new HashSet<GlobalVariables.ActiveUnitType>();
			_SaveID = new List<string>();
			_SaveID_PlayerEditable = new List<string>();
			ID = _ID;
			Name = _Name;
			Description = _Description;
			EnumLink = _EnumLink;
			int num = _States.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				States.Add(i, _States[i]);
				_States_2way.Add(_States[i], i);
			}
			int length = Enum.GetValues(typeof(DoctrineItem_E)).Length;
			this.DefaultState = new int?[length + 1];
			this.DefaultPlayerEditable = new bool[length + 1];
			if (DefaultState != null)
			{
				foreach (var item in DefaultState)
				{
					AddDefaultState(item.Item1, item.Item2);
				}
			}
			if (DefaultPlayerEditable != null)
			{
				foreach (var item2 in DefaultPlayerEditable)
				{
					this.DefaultPlayerEditable[(int)item2.Item1] = item2.Item2;
				}
			}
			Category = _Category;
		}

		public DoctrineDefinition(string _ID, DoctrineItem_E _EnumLink, string _Name, string _Description, List<(string, int)> _States, DoctrineCategory _Category, List<(DoctrinePossibleSubjects, string)> DefaultState = null, List<(DoctrinePossibleSubjects, bool)> DefaultPlayerEditable = null)
		{
			States = new Dictionary<int, string>();
			_States_2way = new Dictionary<string, int>();
			MinNumericValue = 0;
			MaxNumericValue = 0;
			UnitType_Exclusion = new HashSet<GlobalVariables.ActiveUnitType>();
			UnitType_Requirement = new HashSet<GlobalVariables.ActiveUnitType>();
			_SaveID = new List<string>();
			_SaveID_PlayerEditable = new List<string>();
			ID = _ID;
			int length = Enum.GetValues(typeof(DoctrineItem_E)).Length;
			this.DefaultState = new int?[length + 1];
			this.DefaultPlayerEditable = new bool[length + 1];
			Name = _Name;
			Description = _Description;
			EnumLink = _EnumLink;
			BuildCache(_States, DefaultState, DefaultPlayerEditable);
			Category = _Category;
		}

		public void BuildCache(List<(string, int)> _States, List<(DoctrinePossibleSubjects, string)> DefaultState = null, List<(DoctrinePossibleSubjects, bool)> DefaultPlayerEditable = null)
		{
			foreach (var _State in _States)
			{
				if (!States.ContainsKey(_State.Item2) && !_States_2way.ContainsKey(_State.Item1))
				{
					States.Add(_State.Item2, _State.Item1);
					_States_2way.Add(_State.Item1, _State.Item2);
				}
				else if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
			}
			if (DefaultState != null)
			{
				foreach (var item in DefaultState)
				{
					AddDefaultState(item.Item1, item.Item2);
				}
			}
			if (DefaultPlayerEditable == null)
			{
				return;
			}
			foreach (var item2 in DefaultPlayerEditable)
			{
				this.DefaultPlayerEditable[(int)item2.Item1] = item2.Item2;
			}
		}

		[Obsolete]
		public string _GETSTATEDEF_LEGACYBOOLEAN(bool value)
		{
			(string, bool)[] array = valueTuple_0;
			int num = 0;
			(string, bool) tuple;
			while (true)
			{
				if (num < array.Length)
				{
					tuple = array[num];
					if (value == tuple.Item2 && _States_2way.ContainsKey(tuple.Item1))
					{
						break;
					}
					num = checked(num + 1);
					continue;
				}
				return null;
			}
			return tuple.Item1;
		}

		public string GetState(int value)
		{
			if (value <= States.Count - 1)
			{
				return States.ElementAt(value).Value;
			}
			return null;
		}

		public int? GetState(string value)
		{
			return (!_States_2way.ContainsKey(value)) ? ((int?)null) : new int?(_States_2way[value]);
		}

		public void DefineBackwardCompatibilityRules(string _SavingID, string _SavingIDPlayerEdit, bool _UseLegacyBooleanState, string Magic255Value, string _LuaID)
		{
			_SaveID = new List<string> { _SavingID };
			_SaveID_PlayerEditable = new List<string> { _SavingIDPlayerEdit };
			UseLegacyBooleanState = _UseLegacyBooleanState;
			this.Magic255Value = Magic255Value;
			this._LuaID = _LuaID;
		}

		public void DefineBackwardCompatibilityRules(List<string> _SavingID, List<string> _SavingIDPlayerEdit, bool _UseLegacyBooleanState, string Magic255Value, string _LuaID)
		{
			_SaveID = _SavingID;
			_SaveID_PlayerEditable = _SavingIDPlayerEdit;
			UseLegacyBooleanState = _UseLegacyBooleanState;
			this.Magic255Value = Magic255Value;
			this._LuaID = _LuaID;
		}

		public void AddDefaultState(DoctrinePossibleSubjects SubjectType, string value, bool ThrowOnFailure = true)
		{
			int? num = null;
			foreach (KeyValuePair<int, string> state in States)
			{
				if (Operators.CompareString(state.Value, value, false) == 0)
				{
					num = state.Key;
					break;
				}
			}
			if (!num.HasValue)
			{
				if (ThrowOnFailure)
				{
					throw new NotImplementedException();
				}
			}
			else
			{
				DefaultState[(int)SubjectType] = num;
			}
		}

		public bool IsThisDoctrineAppliesToObject(object Theobject)
		{
			if (Theobject == null)
			{
				return true;
			}
			Type type = Theobject.GetType();
			if ((object)type == typeof(Waypoint))
			{
				return true;
			}
			if ((object)type == typeof(Side))
			{
				return true;
			}
			if ((object)type == typeof(Group))
			{
				return true;
			}
			int result;
			if (!(Theobject is ActiveUnit))
			{
				result = 1;
			}
			else
			{
				ActiveUnit activeUnit = (ActiveUnit)Theobject;
				if (UnitType_Requirement.Count > 0 && !UnitType_Requirement.Contains(activeUnit.UnitType))
				{
					return false;
				}
				if (UnitType_Exclusion.Contains(activeUnit.UnitType))
				{
					return false;
				}
				result = 1;
			}
			return (byte)result != 0;
		}
	}

	public enum DoctrineCategory
	{
		Misc,
		Strategic,
		RoE,
		EMCON,
		Air_Ops,
		ASuW,
		ASW,
		Land,
		RedeployCondition,
		WithdrawCondition,
		Refuel,
		AGU
	}

	public enum DoctrinePossibleSubjects
	{
		Side,
		Waypoint,
		Other
	}

	public enum _ContinueGuidanceForImpossibleIntercept : byte
	{
		Yes,
		No,
		Various,
		NotConfigured
	}

	public enum _FireOverTheShoulder : byte
	{
		Yes,
		NoForAircraftAndWeapons,
		NoForAircraftOnly,
		NoForWeaponsOnly,
		Various,
		NotConfigured
	}

	public enum _WRACountByWeaponDBID : byte
	{
		Yes,
		NoForAircraftAndWeapons,
		NoForAircraftOnly,
		NoForWeaponsOnly,
		Various,
		NotConfigured
	}

	public enum _BehaviorTowardsTargetAmbiguity : byte
	{
		Ignore,
		Optimistic,
		Pessimistic,
		Various,
		NotConfigured
	}

	public enum _WCS : byte
	{
		Free,
		Tight,
		Hold,
		Various,
		NotConfigured
	}

	public enum _QuickTurnAroundForAicraft : byte
	{
		Yes,
		FightersAndASW,
		No,
		Various,
		NotConfigured
	}

	public enum _AirOpsTempo : byte
	{
		Surge,
		Sustained,
		Various,
		NotConfigured
	}

	public enum _WeaponState
	{
		LoadoutSetting = 0,
		Winchester = 2001,
		Winchester_ToO = 2002,
		const_3 = 3001,
		ShotgunBVR_WVR = 3002,
		ShotgunBVR_WVR_Guns = 3003,
		ShotgunOneEngagementBVR = 5001,
		ShotgunOneEngagementBVR_Opportunity_WVR = 5002,
		ShotgunOneEngagementBVR_Opportunity_WVR_Guns = 5003,
		ShotgunOneEngagementBVR_And_WVR = 5005,
		ShotgunOneEngagementBVR_And_WVR_Opportunity_Guns = 5006,
		ShotgunOneEngagementWVR = 5011,
		ShotgunOneEngagementWVR_Guns = 5012,
		ShotgunOneEngagementGun = 5021,
		const_14 = 4001,
		Shotgun25_ToO = 4002,
		const_16 = 4011,
		Shotgun50_ToO = 4012,
		const_18 = 4021,
		Shotgun75_ToO = 4022,
		Various = 1,
		NotConfigured = 2
	}

	public enum _FuelState : byte
	{
		Bingo,
		Joker10Percent,
		Joker20Percent,
		Joker25Percent,
		Joker30Percent,
		Joker40Percent,
		Joker50Percent,
		Joker60Percent,
		Joker70Percent,
		Joker75Percent,
		Joker80Percent,
		Joker90Percent,
		Various,
		Chicken,
		NotConfigured
	}

	public enum _UseKinematicRangeForTorpedoes : byte
	{
		AutomaticAndManualFire,
		ManualFireOnly,
		No,
		Various,
		NotConfigured
	}

	public enum _UseUnderwayRefuelAndReplenishment : byte
	{
		Always_ExceptTankersRefuellingTankers,
		Never,
		Always_IncludingTankersRefuellingTankers,
		Various,
		NotConfigured
	}

	public enum _UnderwayRefuelAndReplenishmentSelection : byte
	{
		PickNearest,
		TankersBetweenUsAndObjectiveOnly,
		TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround,
		Various,
		NotConfigured
	}

	public enum _UseSAMsAgainstShips : byte
	{
		No,
		Yes,
		Various,
		NotConfigured
	}

	public enum _UseWpMissileAgainstShips : byte
	{
		No,
		Yes,
		Various,
		NotConfigured
	}

	public enum _UseShootTourists : byte
	{
		No,
		Yes,
		Various,
		NotConfigured
	}

	public enum _StrikeMemberFocus : byte
	{
		OpportunityScrambling,
		FocusingOnTheTarget,
		OnlyMissionSpecificTargets
	}

	public enum _UseIgnoreEMCONunderAttack : byte
	{
		No,
		Yes,
		Various,
		NotConfigured
	}

	public enum _UseAutoEvade : byte
	{
		No,
		Yes,
		Various,
		NotConfigured
	}

	public enum _UseMaintainStandoff : byte
	{
		No,
		Yes,
		Various,
		NotConfigured
	}

	public enum _NavigationMethod : byte
	{
		ShortestRoute,
		DeepWater,
		Littoral,
		DeepWater_Submarine,
		CZ_Submarine,
		Littoral_Submarine,
		Various,
		NotConfigured,
		Direct
	}

	public enum _AGU_Integrity : byte
	{
		Consolidate = 0,
		OccupySpace = 1,
		Various = 6,
		Not_Configured = 7
	}

	public enum _GunStrafeGroundTargets : byte
	{
		No,
		Yes,
		Various,
		NotConfigured
	}

	public enum _UseIgnorePlottedCourse : byte
	{
		No,
		Yes,
		Various,
		NotConfigured
	}

	public enum _UseNukesAllowed : byte
	{
		No,
		Yes,
		Various,
		NotConfigured
	}

	public enum _CanRedeployOnlyWithFullWeapons : byte
	{
		No,
		Yes,
		Various,
		NotConfigured
	}

	public enum _WeaponStateRTB : byte
	{
		No,
		YesLastUnit,
		YesFirstUnit,
		YesLeaveGroup,
		Various,
		NotConfigured
	}

	public enum _FuelStateRTB : byte
	{
		No,
		YesLastUnit,
		YesFirstUnit,
		YesLeaveGroup,
		Various,
		NotConfigured
	}

	public enum _JettisonOrdnance : byte
	{
		No,
		Yes,
		Various,
		NotConfigured
	}

	public enum _BVRLogicEnum : byte
	{
		StraightIn,
		Crank,
		CrankAndDrag,
		Various,
		NotConfigured,
		DragImmediately
	}

	public enum _RefuelAlliedUnits : byte
	{
		Yes,
		Yes_ReceiveOnly,
		Yes_DeliverOnly,
		No,
		Various,
		NotConfigured
	}

	public enum _BingoThreshold_E : byte
	{
		Bingo30Percent,
		Bingo40Percent,
		Bingo50Percent,
		Bingo60Percent,
		Bingo70Percent,
		Bingo80Percent,
		Various,
		NotConfigured
	}

	public enum _AvoidContactWhenPossible : byte
	{
		No,
		Yes_ExceptSelfDefence,
		Yes_Always,
		Various,
		NotConfigured
	}

	public enum _DiveOnContact : byte
	{
		Yes,
		Yes_ESM_Only,
		Yes_Ships20nm_Aircraft30nm,
		No,
		Various,
		NotConfigured
	}

	public enum _RechargeBatteryPercentage
	{
		Recharge_Empty = 0,
		Recharge_10_Percent = 10,
		Recharge_20_Percent = 20,
		Recharge_30_Percent = 30,
		Recharge_40_Percent = 40,
		Recharge_50_Percent = 50,
		Recharge_60_Percent = 60,
		Recharge_70_Percent = 70,
		Recharge_80_Percent = 80,
		Recharge_90_Percent = 90,
		Various = -100,
		NotConfigured = -101
	}

	public enum _UseAIP : byte
	{
		No,
		Yes_AttackOnly,
		Yes_Always,
		Various,
		NotConfigured
	}

	public enum _UseDippingSonar : byte
	{
		Automatically_HoverAnd150ft,
		ManualAndMissionOnly,
		Various,
		NotConfigured
	}

	public enum _DamageThreshold : short
	{
		Ignore,
		Percent5,
		const_2,
		const_3,
		const_4,
		Various,
		NotConfigured
	}

	public enum _FuelQuantityThreshold : short
	{
		Ignore,
		Bingo,
		const_2,
		const_3,
		const_4,
		const_5,
		Various,
		NotConfigured
	}

	public enum _WeaponQuantityThreshold : short
	{
		Ignore,
		Exhausted,
		const_2,
		const_3,
		const_4,
		const_5,
		LoadFullWeapons,
		Various,
		NotConfigured
	}

	public enum _SonobuoyUse : byte
	{
		SearchAndLocalization,
		Localization,
		ManualOnly,
		Various,
		NotConfigured
	}

	public enum DoctrineItem_E
	{
		NukesAllowed = 1,
		WeaponControlStatusAir = 2,
		WeaponControlStatusSurface = 3,
		WeaponControlStatusSubsurface = 4,
		WeaponControlStatusLand = 5,
		IgnorePlottedCourse = 6,
		BehaviorTowardsAmbiguousTarget = 7,
		ShootTourists = 8,
		IgnoreEMCONunderAttack = 9,
		UseKinematicRangeForTorpedoes = 10,
		AutoEvade = 11,
		UseReplenishment = 12,
		ReplenishmentSelection = 13,
		RefuelAllies = 14,
		BingoThreshold = 15,
		AirOpsTempo = 16,
		QuickTurnAroundForAircraft = 17,
		BingoJoker = 18,
		BingoJokerRTB = 19,
		WinchesterShotgun = 20,
		const_20 = 21,
		GunStrafing = 22,
		Jettison = 23,
		BVRLogic = 24,
		RTBWhenWinchester = 25,
		UseSAMsOnASuW = 26,
		MaintainStandoff = 27,
		const_27 = 28,
		AvoidContact = 29,
		DiveWhenThreatsDetected = 30,
		RechargePercentagePatrol = 31,
		RechargePercentageAttack = 32,
		AIPUsage = 33,
		DippingSonar = 34,
		NavSurface = 35,
		NavSubSurface = 36,
		NavLand = 37,
		WithdrawDamage = 38,
		WithdrawFuel = 39,
		WithdrawAttack = 40,
		WithdrawDefence = 41,
		DeployDamage = 42,
		DeployFuel = 43,
		DeployAttack = 44,
		DeployDefence = 45,
		StrikeMemberFocus = 46,
		AGU_TacticalPosture = 47,
		ThreatMaxDist = 48,
		MissileEngagement_ContinueGuidanceForImpossibleIntercept = 49,
		MissileEngagement_FireOverTheShoulder = 50,
		MissileEngagement_WRACounting = 51,
		SonobuoyUse = 52,
		CustomDoctrine_Start = 100,
		CustomDoctrine_End = 200
	}

	public ScenarioObject Subject;

	public Type SubjectType;

	public List<ActiveUnit> SelectedUnits;

	public Scenario ScenarioContext;

	private EMCONSettings emconsettings_0;

	public DoctrineItem[] DoctrineItems;

	private ConcurrentPagedArray<WRA_Weapon> concurrentPagedArray_0;

	private Dictionary<DoctrineDefinition, int?> dictionary_0;

	public static Dictionary<string, DoctrineDefinition> _CacheDoctrineDefinitions_DIC;

	public static Dictionary<string, DoctrineDefinition> _CacheDoctrineDefinitions_PlayerEditDIC;

	public static Dictionary<string, DoctrineDefinition> DoctrineDefinitions;

	public static DoctrineDefinition[] DoctrineDefinitions_Array;

	public static Dictionary<string, DoctrineDefinition> DoctrineDefinitions_Savable;

	[CompilerGenerated]
	private static DoctrineChangedEventHandler doctrineChangedEventHandler_0;

	[CompilerGenerated]
	private static EmconChangedEventHandler emconChangedEventHandler_0;

	public bool DoctrineRefresh;

	private static int int_0;

	private List<PriorityTargetEntry> list_0;

	private LockObject lockObject_0;

	private int int_1;

	private bool bool_0;

	private Doctrine doctrine_0;

	private static HashSet<_WRA_WeaponTargetType> hashSet_0;

	private static LockObject lockObject_1;

	public static Dictionary<_WRA_WeaponTargetFamilyType, List<_WRA_WeaponTargetType>> WRA_WeaponTargetsChache;

	public Dictionary<DoctrineDefinition, int?> MultipleUnitsInherits_State
	{
		get
		{
			if (dictionary_0 == null)
			{
				dictionary_0 = new Dictionary<DoctrineDefinition, int?>();
			}
			return dictionary_0;
		}
		set
		{
			dictionary_0 = value;
		}
	}

	public List<PriorityTargetEntry> PriorityTargetList
	{
		get
		{
			List<PriorityTargetEntry> list = new List<PriorityTargetEntry>();
			list.AddRange(list_0);
			return list;
		}
	}

	public bool CanInheritDoctrine
	{
		get
		{
			if (Subject is Side)
			{
				return false;
			}
			return !(Subject is Waypoint);
		}
	}

	public bool EMCON_Inherits
	{
		get
		{
			return Information.IsNothing((object)emconsettings_0);
		}
		set
		{
			if (!value)
			{
				if (Information.IsNothing((object)emconsettings_0))
				{
					emconsettings_0 = new EMCONSettings();
				}
			}
			else
			{
				emconsettings_0 = null;
			}
		}
	}

	public int? WRA_WeaponQty_Inherits
	{
		get
		{
			return method_3(theWeaponDBID_TGV, selectedNodeTargetType);
		}
		set
		{
			if (value.HasValue)
			{
				concurrentPagedArray_0 = new ConcurrentPagedArray<WRA_Weapon>();
			}
			else
			{
				concurrentPagedArray_0 = null;
			}
		}
	}

	public int? WRA_ShooterQty_Inherits
	{
		get
		{
			return method_4(theWeaponDBID_TGV, selectedNodeTargetType);
		}
		set
		{
			if (value.HasValue)
			{
				concurrentPagedArray_0 = new ConcurrentPagedArray<WRA_Weapon>();
			}
			else
			{
				concurrentPagedArray_0 = null;
			}
		}
	}

	public float? WRA_SelfDefenceRange_Inherits
	{
		get
		{
			return method_5(theWeaponDBID_TGV, selectedNodeTargetType);
		}
		set
		{
			if (value.HasValue)
			{
				concurrentPagedArray_0 = new ConcurrentPagedArray<WRA_Weapon>();
			}
			else
			{
				concurrentPagedArray_0 = null;
			}
		}
	}

	public ConcurrentPagedArray<WRA_Weapon> WRA
	{
		get
		{
			return concurrentPagedArray_0;
		}
		set
		{
			concurrentPagedArray_0 = value;
		}
	}

	public static List<_WRA_WeaponTargetType> TopNodeWeaponTargetTypes
	{
		get
		{
			if (hashSet_0 == null)
			{
				smethod_2();
			}
			return new List<_WRA_WeaponTargetType>(hashSet_0);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _AirOpsTempo? AirOpsTempo
	{
		get
		{
			return (_AirOpsTempo?)GetElementState(DoctrineItem_E.AirOpsTempo);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.AirOpsTempo, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _UseKinematicRangeForTorpedoes? UseKinematicRangeForTorpedoes
	{
		get
		{
			return (_UseKinematicRangeForTorpedoes?)GetElementState(DoctrineItem_E.UseKinematicRangeForTorpedoes);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.UseKinematicRangeForTorpedoes, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _WCS? WeaponControlStatus_Air
	{
		get
		{
			return (_WCS?)GetElementState(DoctrineItem_E.WeaponControlStatusAir);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.WeaponControlStatusAir, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool WeaponControlStatus_Air_PlayerEditable
	{
		get
		{
			return GetElement_PlayerEditable(DoctrineItem_E.WeaponControlStatusAir);
		}
		set
		{
			SetElement_PlayerEditable(DoctrineItem_E.WeaponControlStatusAir, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _WCS? WeaponControlStatus_Surface
	{
		get
		{
			return (_WCS?)GetElementState(DoctrineItem_E.WeaponControlStatusSurface);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.WeaponControlStatusSurface, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool WeaponControlStatus_Surface_PlayerEditable
	{
		get
		{
			return GetElement_PlayerEditable(DoctrineItem_E.WeaponControlStatusSurface);
		}
		set
		{
			SetElement_PlayerEditable(DoctrineItem_E.WeaponControlStatusSurface, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _WCS? WeaponControlStatus_Submarine
	{
		get
		{
			return (_WCS?)GetElementState(DoctrineItem_E.WeaponControlStatusSubsurface);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.WeaponControlStatusSubsurface, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool WeaponControlStatus_Submarine_PlayerEditable
	{
		get
		{
			return GetElement_PlayerEditable(DoctrineItem_E.WeaponControlStatusSubsurface);
		}
		set
		{
			SetElement_PlayerEditable(DoctrineItem_E.WeaponControlStatusSubsurface, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _WCS? WeaponControlStatus_Land
	{
		get
		{
			return (_WCS?)GetElementState(DoctrineItem_E.WeaponControlStatusLand);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.WeaponControlStatusLand, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool WeaponControlStatus_Land_PlayerEditable
	{
		get
		{
			return GetElement_PlayerEditable(DoctrineItem_E.WeaponControlStatusLand);
		}
		set
		{
			SetElement_PlayerEditable(DoctrineItem_E.WeaponControlStatusLand, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _UseIgnorePlottedCourse? IgnorePlottedCourse
	{
		get
		{
			return (_UseIgnorePlottedCourse?)GetElementState(DoctrineItem_E.IgnorePlottedCourse);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.IgnorePlottedCourse, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool IgnorePlottedCourse_PlayerEditable
	{
		get
		{
			return GetElement_PlayerEditable(DoctrineItem_E.IgnorePlottedCourse);
		}
		set
		{
			SetElement_PlayerEditable(DoctrineItem_E.IgnorePlottedCourse, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _BehaviorTowardsTargetAmbiguity? BehaviorTowardsAmbigousTarget
	{
		get
		{
			return (_BehaviorTowardsTargetAmbiguity?)GetElementState(DoctrineItem_E.BehaviorTowardsAmbiguousTarget);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.BehaviorTowardsAmbiguousTarget, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _DamageThreshold? WithdrawDamageThreshold
	{
		get
		{
			return (_DamageThreshold?)GetElementState(DoctrineItem_E.WithdrawDamage);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.WithdrawDamage, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _FuelQuantityThreshold? WithdrawFuelThreshold
	{
		get
		{
			return (_FuelQuantityThreshold?)GetElementState(DoctrineItem_E.WithdrawFuel);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.WithdrawFuel, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _WeaponQuantityThreshold? WithdrawAttackThreshold
	{
		get
		{
			return (_WeaponQuantityThreshold?)GetElementState(DoctrineItem_E.WithdrawAttack);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.WithdrawAttack, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _WeaponQuantityThreshold? WithdrawDefenceThreshold
	{
		get
		{
			return (_WeaponQuantityThreshold?)GetElementState(DoctrineItem_E.WithdrawDefence);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.WithdrawDefence, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _DamageThreshold? RedeployDamageThreshold
	{
		get
		{
			return (_DamageThreshold?)GetElementState(DoctrineItem_E.DeployDamage);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.DeployDamage, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _FuelQuantityThreshold? RedeployFuelThreshold
	{
		get
		{
			return (_FuelQuantityThreshold?)GetElementState(DoctrineItem_E.DeployFuel);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.DeployFuel, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _WeaponQuantityThreshold? RedeployAttackThreshold
	{
		get
		{
			return (_WeaponQuantityThreshold?)GetElementState(DoctrineItem_E.DeployAttack);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.DeployAttack, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _WeaponQuantityThreshold? RedeployDefenceThreshold
	{
		get
		{
			return (_WeaponQuantityThreshold?)GetElementState(DoctrineItem_E.DeployDefence);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.DeployDefence, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _WeaponStateRTB? WinchesterShotgunRTB
	{
		get
		{
			return (_WeaponStateRTB?)GetElementState(DoctrineItem_E.const_20);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.const_20, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _FuelStateRTB? BingoJokerRTB
	{
		get
		{
			return (_FuelStateRTB?)GetElementState(DoctrineItem_E.BingoJokerRTB);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.BingoJokerRTB, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _JettisonOrdnance? Jettison
	{
		get
		{
			return (_JettisonOrdnance?)GetElementState(DoctrineItem_E.Jettison);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.Jettison, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _BVRLogicEnum? BVRLogic
	{
		get
		{
			return (_BVRLogicEnum?)GetElementState(DoctrineItem_E.BVRLogic);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.BVRLogic, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _UseAutoEvade? AutoEvade
	{
		get
		{
			return (_UseAutoEvade?)GetElementState(DoctrineItem_E.AutoEvade);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.AutoEvade, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _UseMaintainStandoff? MaintainStandoff
	{
		get
		{
			return (_UseMaintainStandoff?)GetElementState(DoctrineItem_E.MaintainStandoff);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.MaintainStandoff, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _GunStrafeGroundTargets? GunStrafing
	{
		get
		{
			return (_GunStrafeGroundTargets?)GetElementState(DoctrineItem_E.GunStrafing);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.GunStrafing, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _UseUnderwayRefuelAndReplenishment? UseReplenishment
	{
		get
		{
			return (_UseUnderwayRefuelAndReplenishment?)GetElementState(DoctrineItem_E.UseReplenishment);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.UseReplenishment, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _UnderwayRefuelAndReplenishmentSelection? ReplenishmentSelection
	{
		get
		{
			return (_UnderwayRefuelAndReplenishmentSelection?)GetElementState(DoctrineItem_E.ReplenishmentSelection);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.ReplenishmentSelection, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _UseShootTourists? ShootTourists
	{
		get
		{
			return (_UseShootTourists?)GetElementState(DoctrineItem_E.ShootTourists);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.ShootTourists, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _UseSAMsAgainstShips? UseSAMsOnASuW
	{
		get
		{
			return (_UseSAMsAgainstShips?)GetElementState(DoctrineItem_E.UseSAMsOnASuW);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.UseSAMsOnASuW, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _UseWpMissileAgainstShips? UseWPMissileOnASuW
	{
		get
		{
			return (_UseWpMissileAgainstShips?)GetElementState(DoctrineItem_E.const_27);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.const_27, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _UseIgnoreEMCONunderAttack? IgnoreEMCONunderAttack
	{
		get
		{
			return (_UseIgnoreEMCONunderAttack?)GetElementState(DoctrineItem_E.IgnoreEMCONunderAttack);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.IgnoreEMCONunderAttack, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _NavigationMethod? SurfaceNavigation
	{
		get
		{
			return (_NavigationMethod?)GetElementState(DoctrineItem_E.NavSurface);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.NavSurface, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _NavigationMethod? SubmarineNavigation
	{
		get
		{
			return (_NavigationMethod?)GetElementState(DoctrineItem_E.NavSubSurface);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.NavSubSurface, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _NavigationMethod? LandNavigation
	{
		get
		{
			return (_NavigationMethod?)GetElementState(DoctrineItem_E.NavLand);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.NavLand, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _BingoThreshold_E? BingoThreshold
	{
		get
		{
			return (_BingoThreshold_E?)GetElementState(DoctrineItem_E.BingoThreshold);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.BingoThreshold, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _RefuelAlliedUnits? RefuelAllies
	{
		get
		{
			return (_RefuelAlliedUnits?)GetElementState(DoctrineItem_E.RefuelAllies);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.RefuelAllies, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _AvoidContactWhenPossible? AvoidContact
	{
		get
		{
			return (_AvoidContactWhenPossible?)GetElementState(DoctrineItem_E.AvoidContact);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.AvoidContact, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _DiveOnContact? DiveWhenThreatsDetected
	{
		get
		{
			return (_DiveOnContact?)GetElementState(DoctrineItem_E.DiveWhenThreatsDetected);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.DiveWhenThreatsDetected, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _RechargeBatteryPercentage? RechargePercentagePatrol
	{
		get
		{
			return (_RechargeBatteryPercentage?)GetElementState(DoctrineItem_E.RechargePercentagePatrol);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.RechargePercentagePatrol, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _RechargeBatteryPercentage? RechargePercentageAttack
	{
		get
		{
			return (_RechargeBatteryPercentage?)GetElementState(DoctrineItem_E.RechargePercentageAttack);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.RechargePercentageAttack, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool IsShotgunSingleEngagment
	{
		get
		{
			_WeaponState? weaponState = this.get_WinchesterShotgun(CurrentScen, MultipleUnits: false, UnitIsOperating: true, ViaDoctrineForm: false, ViaRightColumn: false);
			int? num = (int?)weaponState;
			bool? flag = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 5001));
			num = (int?)weaponState;
			bool? flag2 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 5021));
			bool? flag3 = ((flag ?? false) ? new bool?(true) : ((!flag2.HasValue) ? ((bool?)null) : ((flag2 == true) | flag)));
			num = (int?)weaponState;
			bool? flag4 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 5011));
			bool? flag5 = ((flag3 ?? false) ? new bool?(true) : ((!flag4.HasValue) ? ((bool?)null) : ((flag4 == true) | flag3)));
			num = (int?)weaponState;
			bool? flag6 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 5012));
			if (((flag5 ?? false) ? new bool?(true) : ((!flag6.HasValue) ? ((bool?)null) : ((flag6 == true) | flag5))) == true)
			{
				return true;
			}
			return false;
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _UseDippingSonar? DippingSonar
	{
		get
		{
			return (_UseDippingSonar?)GetElementState(DoctrineItem_E.DippingSonar);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.DippingSonar, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _UseNukesAllowed? NukesAllowed
	{
		get
		{
			return (_UseNukesAllowed?)GetElementState(DoctrineItem_E.NukesAllowed);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.NukesAllowed, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _UseAIP? AIPUsage
	{
		get
		{
			return (_UseAIP?)GetElementState(DoctrineItem_E.AIPUsage);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.AIPUsage, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _FuelState? BingoJoker
	{
		get
		{
			return (_FuelState?)GetElementState(DoctrineItem_E.BingoJoker);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.BingoJoker, value);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public _WeaponState? WinchesterShotgun
	{
		get
		{
			return (_WeaponState?)GetElementState(DoctrineItem_E.WinchesterShotgun);
		}
		set
		{
			SetElementState_Raw(DoctrineItem_E.WinchesterShotgun, value);
		}
	}

	public static event DoctrineChangedEventHandler DoctrineChanged
	{
		[CompilerGenerated]
		add
		{
			DoctrineChangedEventHandler doctrineChangedEventHandler = doctrineChangedEventHandler_0;
			DoctrineChangedEventHandler doctrineChangedEventHandler2;
			do
			{
				doctrineChangedEventHandler2 = doctrineChangedEventHandler;
				DoctrineChangedEventHandler value2 = (DoctrineChangedEventHandler)Delegate.Combine(doctrineChangedEventHandler2, value);
				doctrineChangedEventHandler = Interlocked.CompareExchange(ref doctrineChangedEventHandler_0, value2, doctrineChangedEventHandler2);
			}
			while ((object)doctrineChangedEventHandler != doctrineChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			DoctrineChangedEventHandler doctrineChangedEventHandler = doctrineChangedEventHandler_0;
			DoctrineChangedEventHandler doctrineChangedEventHandler2;
			do
			{
				doctrineChangedEventHandler2 = doctrineChangedEventHandler;
				DoctrineChangedEventHandler value2 = (DoctrineChangedEventHandler)Delegate.Remove(doctrineChangedEventHandler2, value);
				doctrineChangedEventHandler = Interlocked.CompareExchange(ref doctrineChangedEventHandler_0, value2, doctrineChangedEventHandler2);
			}
			while ((object)doctrineChangedEventHandler != doctrineChangedEventHandler2);
		}
	}

	public static event EmconChangedEventHandler EmconChanged
	{
		[CompilerGenerated]
		add
		{
			EmconChangedEventHandler emconChangedEventHandler = emconChangedEventHandler_0;
			EmconChangedEventHandler emconChangedEventHandler2;
			do
			{
				emconChangedEventHandler2 = emconChangedEventHandler;
				EmconChangedEventHandler value2 = (EmconChangedEventHandler)Delegate.Combine(emconChangedEventHandler2, value);
				emconChangedEventHandler = Interlocked.CompareExchange(ref emconChangedEventHandler_0, value2, emconChangedEventHandler2);
			}
			while ((object)emconChangedEventHandler != emconChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EmconChangedEventHandler emconChangedEventHandler = emconChangedEventHandler_0;
			EmconChangedEventHandler emconChangedEventHandler2;
			do
			{
				emconChangedEventHandler2 = emconChangedEventHandler;
				EmconChangedEventHandler value2 = (EmconChangedEventHandler)Delegate.Remove(emconChangedEventHandler2, value);
				emconChangedEventHandler = Interlocked.CompareExchange(ref emconChangedEventHandler_0, value2, emconChangedEventHandler2);
			}
			while ((object)emconChangedEventHandler != emconChangedEventHandler2);
		}
	}

	static Doctrine()
	{
		Class72.smethod_20();
		_CacheDoctrineDefinitions_DIC = new Dictionary<string, DoctrineDefinition>();
		_CacheDoctrineDefinitions_PlayerEditDIC = new Dictionary<string, DoctrineDefinition>();
		DoctrineDefinitions = new Dictionary<string, DoctrineDefinition>();
		DoctrineDefinitions_Savable = new Dictionary<string, DoctrineDefinition>();
		int_0 = Enum.GetValues(typeof(DoctrineItem_E)).Cast<int>().Max();
		lockObject_1 = new LockObject();
		WRA_WeaponTargetsChache = new Dictionary<_WRA_WeaponTargetFamilyType, List<_WRA_WeaponTargetType>>();
	}

	public static void RaiseEvent_EMCONChanged(ScenarioObject theSubject, bool? viaMainForm, bool MultipleUnits, bool ViaDoctrineForm, bool ViaRightColumn, bool viaFlightPlanEditor)
	{
		emconChangedEventHandler_0?.Invoke(theSubject, viaMainForm, MultipleUnits, ViaDoctrineForm, ViaRightColumn, viaFlightPlanEditor);
	}

	public List<(string, string, Delegate, string)> GetWarnings()
	{
		List<(string, string, Delegate, string)> list = new List<(string, string, Delegate, string)>();
		if (Subject is ActiveUnit)
		{
			ActiveUnit activeUnit = (ActiveUnit)Subject;
			if (activeUnit.Doctrine != null)
			{
				int? elementState = activeUnit.Doctrine.GetElementState(DoctrineItem_E.WeaponControlStatusSurface);
				Mission mission = activeUnit.AssignedMissionOrPackage();
				if (mission != null)
				{
					bool flag = false;
					switch (mission.MissionClass)
					{
					case Mission._MissionClass.Patrol:
						if (mission is Patrol)
						{
							flag = ((Patrol)mission).Type == GlobalVariables.PatrolType.ASuW_Naval;
						}
						break;
					case Mission._MissionClass.Strike:
						if (mission is Strike)
						{
							flag = ((Strike)mission).Type == Strike.StrikeType.Maritime_Strike;
						}
						break;
					}
					if (flag)
					{
						int? num = elementState;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 2)) == true)
						{
							Action item = [SpecialName] () =>
							{
								activeUnit.Doctrine.SetElementState(DoctrineItem_E.WeaponControlStatusSurface, 0);
							};
							list.Add(("Mission & WCS Conflict", "The unit has an ASuW mission but its WCS for surface units is set to 'hold'.", item, ""));
						}
					}
				}
			}
		}
		return list;
	}

	public void Init()
	{
		if ((object)SubjectType == typeof(Side))
		{
			emconsettings_0 = new EMCONSettings();
		}
		else
		{
			_ = typeof(Waypoint);
		}
	}

	public Doctrine(Scenario _ScenarioContext, ScenarioObject DoctrineSubject, ref List<ActiveUnit> DoctrineSelectedUnits)
	{
		list_0 = new List<PriorityTargetEntry>();
		lockObject_0 = new LockObject();
		int_1 = 0;
		bool_0 = false;
		try
		{
			DoctrineItems = new DoctrineItem[int_0 + 1];
			ScenarioContext = _ScenarioContext;
			Subject = DoctrineSubject;
			SubjectType = DoctrineSubject.GetType();
			SelectedUnits = DoctrineSelectedUnits;
			Init();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101000", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal Doctrine CopyDoctrine(ref Doctrine theOriginalDoctrine, ScenarioObject theSubject, ref Scenario theScen)
	{
		EMCONSettings._EMCONSetting theEMCON_Radar;
		EMCONSettings._EMCONSetting theEMCON_Sonar;
		EMCONSettings._EMCONSetting theEMCON_OECM;
		if (theOriginalDoctrine.EMCON_Inherits && (object)SubjectType == typeof(Waypoint))
		{
			theEMCON_Radar = EMCONSettings._EMCONSetting.NotConfigured;
			theEMCON_Sonar = EMCONSettings._EMCONSetting.NotConfigured;
			theEMCON_OECM = EMCONSettings._EMCONSetting.NotConfigured;
		}
		else
		{
			theEMCON_Radar = theOriginalDoctrine.EMCON(theScen).Radar();
			theEMCON_Sonar = theOriginalDoctrine.EMCON(theScen).Sonar();
			theEMCON_OECM = theOriginalDoctrine.EMCON(theScen).OECM();
		}
		return new Doctrine(ref theScen, ref theSubject, theOriginalDoctrine.EMCON_Inherits, theEMCON_Radar, theEMCON_Sonar, theEMCON_OECM, DoctrineItems);
	}

	public Doctrine(ref Scenario theScen, ref ScenarioObject theSubject, bool theEMCON_Inherits, EMCONSettings._EMCONSetting theEMCON_Radar, EMCONSettings._EMCONSetting theEMCON_Sonar, EMCONSettings._EMCONSetting theEMCON_OECM, DoctrineItem[] _DoctrineItems)
	{
		list_0 = new List<PriorityTargetEntry>();
		lockObject_0 = new LockObject();
		int_1 = 0;
		bool_0 = false;
		try
		{
			DoctrineItems = new DoctrineItem[Enum.GetValues(typeof(DoctrineItem_E)).Cast<int>().Max() + 1];
			ScenarioContext = theScen;
			Subject = theSubject;
			SubjectType = theSubject.GetType();
			foreach (DoctrineItem doctrineItem in _DoctrineItems)
			{
				if (doctrineItem != null && DoctrineItems[(int)doctrineItem.Definifition.EnumLink] == null)
				{
					DoctrineItems[(int)doctrineItem.Definifition.EnumLink] = new DoctrineItem(doctrineItem, this);
				}
			}
			if (theEMCON_Inherits)
			{
				EMCON_Inherits = theEMCON_Inherits;
				return;
			}
			EMCON_Inherits = theEMCON_Inherits;
			SetEMCON_Radar(theEMCON_Radar, theScen);
			SetEMCON_Sonar(theEMCON_Sonar, theScen);
			SetEMCON_OECM(theEMCON_OECM, theScen);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101306", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void CreatePriorityTargetList()
	{
		list_0.Add(new PriorityTargetEntry());
	}

	public void RemovePriorityTargetList()
	{
		list_0 = new List<PriorityTargetEntry>();
	}

	public void AddPriorityTargetListEntry(GlobalVariables.ActiveUnitType theType, int theSubType, int theDBID, int index)
	{
		if (index >= 0 && index < list_0.Count)
		{
			int num = 0;
			PriorityTargetEntry.PriorityFlags thePriority = PriorityTargetEntry.PriorityFlags.PriorityLow;
			using (List<PriorityTargetEntry>.Enumerator enumerator = list_0.GetEnumerator())
			{
				while (enumerator.MoveNext() && enumerator.Current.Priority != PriorityTargetEntry.PriorityFlags.PriorityDefault)
				{
					num++;
				}
			}
			if (index <= num)
			{
				thePriority = PriorityTargetEntry.PriorityFlags.PriorityHigh;
			}
			PriorityTargetEntry item = new PriorityTargetEntry(theType, theSubType, theDBID, thePriority);
			list_0.Insert(index, item);
		}
		else
		{
			PriorityTargetEntry item2 = new PriorityTargetEntry(theType, theSubType, theDBID, PriorityTargetEntry.PriorityFlags.PriorityLow);
			list_0.Add(item2);
		}
	}

	public void DeletePriorityTargetListEntry(int index)
	{
		if (list_0.Count > index && list_0[index].Priority != PriorityTargetEntry.PriorityFlags.PriorityDefault)
		{
			list_0.RemoveAt(index);
		}
	}

	public void SwapPriorityTargetListEntry(int index, bool up)
	{
		if (list_0.Count < 2)
		{
			return;
		}
		int num = index;
		num = ((!up) ? Math.Min(index + 1, list_0.Count - 1) : Math.Max(index - 1, 0));
		if (index == num)
		{
			return;
		}
		PriorityTargetEntry priorityTargetEntry = list_0[num];
		list_0[num] = list_0[index];
		list_0[index] = priorityTargetEntry;
		if (priorityTargetEntry.Priority == PriorityTargetEntry.PriorityFlags.PriorityDefault)
		{
			if (!up)
			{
				list_0[num].Priority = PriorityTargetEntry.PriorityFlags.PriorityLow;
			}
			else
			{
				list_0[num].Priority = PriorityTargetEntry.PriorityFlags.PriorityHigh;
			}
		}
		else if (list_0[num].Priority == PriorityTargetEntry.PriorityFlags.PriorityDefault)
		{
			if (up)
			{
				priorityTargetEntry.Priority = PriorityTargetEntry.PriorityFlags.PriorityLow;
			}
			else
			{
				priorityTargetEntry.Priority = PriorityTargetEntry.PriorityFlags.PriorityHigh;
			}
		}
	}

	public void SortPriorityTargetList()
	{
		if (list_0 == null || list_0.Count <= 1)
		{
			return;
		}
		List<PriorityTargetEntry> list = new List<PriorityTargetEntry>();
		List<PriorityTargetEntry> list2 = new List<PriorityTargetEntry>();
		foreach (PriorityTargetEntry item in list_0)
		{
			switch (item.Priority)
			{
			case PriorityTargetEntry.PriorityFlags.PriorityLow:
				list2.Add(item);
				break;
			case PriorityTargetEntry.PriorityFlags.PriorityHigh:
				list.Add(item);
				break;
			}
		}
		list_0 = new List<PriorityTargetEntry>();
		list_0.AddRange(list);
		list_0.Add(new PriorityTargetEntry());
		list_0.AddRange(list2);
	}

	internal string VerifyPriorityTargetList(Scenario theScenario)
	{
		if (list_0.Count > 1)
		{
			int num = list_0.Count - 2;
			for (int i = 0; i <= num; i++)
			{
				int num2 = i + 1;
				int num3 = list_0.Count - 1;
				for (int j = num2; j <= num3; j++)
				{
					if (list_0[j].Type != list_0[i].Type)
					{
						continue;
					}
					if (list_0[i].SubType != 0)
					{
						if (list_0[j].SubType != list_0[i].SubType)
						{
							continue;
						}
						int num4;
						if (list_0[i].DBID != 0)
						{
							if (list_0[j].DBID != list_0[i].DBID)
							{
								continue;
							}
							num4 = 8;
						}
						else
						{
							num4 = 8;
						}
						string[] array = new string[num4];
						array[0] = "Warning: Priority Target List entry at index ";
						array[1] = i.ToString();
						array[2] = " ";
						array[3] = list_0[i].ShortString(theScenario);
						array[4] = " will always apply before similar entry at index ";
						array[5] = j.ToString();
						array[6] = " ";
						array[7] = list_0[j].ShortString(theScenario);
						return string.Concat(array);
					}
					return "Warning: Priority Target List entry at index " + i + " " + list_0[i].ShortString(theScenario) + " will always apply before similar entry at index " + j + " " + list_0[j].ShortString(theScenario);
				}
			}
		}
		return "";
	}

	internal bool HasPriorityTargetList(Scenario theScenario)
	{
		if (list_0.Count <= 0)
		{
			bool UnitIsOperating = true;
			Doctrine parentDoctrine = GetParentDoctrine(ref UnitIsOperating);
			while (true)
			{
				if (parentDoctrine != null)
				{
					if (parentDoctrine.list_0.Count > 0)
					{
						break;
					}
					if (!(parentDoctrine.Subject is Side))
					{
						Doctrine doctrine = parentDoctrine;
						UnitIsOperating = true;
						parentDoctrine = doctrine.GetParentDoctrine(ref UnitIsOperating);
						continue;
					}
					return false;
				}
				return false;
			}
			return true;
		}
		return true;
	}

	internal Doctrine GetPriorityTargetListDoctrine(Scenario theScenario)
	{
		if (list_0.Count <= 0)
		{
			bool UnitIsOperating = true;
			Doctrine parentDoctrine = GetParentDoctrine(ref UnitIsOperating);
			while (true)
			{
				if (parentDoctrine != null)
				{
					if (parentDoctrine.list_0.Count > 0)
					{
						break;
					}
					if (!(parentDoctrine.Subject is Side))
					{
						Doctrine doctrine = parentDoctrine;
						UnitIsOperating = true;
						parentDoctrine = doctrine.GetParentDoctrine(ref UnitIsOperating);
						continue;
					}
					return null;
				}
				return null;
			}
			return parentDoctrine;
		}
		return this;
	}

	internal List<Contact> ApplyPriorityTargetList(Scenario theScenario, List<Contact> theTargetList)
	{
		List<Contact> list = new List<Contact>();
		if (theTargetList != null && theTargetList.Count != 0)
		{
			List<Contact> list2 = new List<Contact>();
			List<Contact> list3 = new List<Contact>();
			List<PriorityTargetEntry> list4 = list_0;
			bool UnitIsOperating = true;
			Doctrine parentDoctrine = GetParentDoctrine(ref UnitIsOperating);
			bool flag = false;
			while (list4.Count < 2 && parentDoctrine != null)
			{
				list4 = parentDoctrine.list_0;
				if (parentDoctrine.Subject is Side)
				{
					break;
				}
				Doctrine doctrine = parentDoctrine;
				UnitIsOperating = true;
				parentDoctrine = doctrine.GetParentDoctrine(ref UnitIsOperating);
			}
			list.AddRange(theTargetList);
			if (list4.Count < 2)
			{
				return list;
			}
			foreach (PriorityTargetEntry item in list4)
			{
				switch (item.Priority)
				{
				case PriorityTargetEntry.PriorityFlags.PriorityLow:
					foreach (Contact theTarget in theTargetList)
					{
						if (item.AppliesTo(theTarget))
						{
							list.Remove(theTarget);
							if (!flag)
							{
								list3.Add(theTarget);
							}
						}
					}
					if (list3.Count > 0)
					{
						flag = true;
					}
					break;
				case PriorityTargetEntry.PriorityFlags.PriorityHigh:
					foreach (Contact theTarget2 in theTargetList)
					{
						if (item.AppliesTo(theTarget2))
						{
							list2.Add(theTarget2);
						}
					}
					if (list2.Count > 0)
					{
						return list2;
					}
					break;
				}
			}
			if (list.Count == 0 && list3.Count > 0)
			{
				list.AddRange(list3);
			}
			return list;
		}
		return list;
	}

	internal List<Contact> SortTargetsByPriority(Scenario theScenario, List<Contact> theTargetList)
	{
		List<Contact> list = new List<Contact>();
		if (theTargetList != null && theTargetList.Count != 0)
		{
			List<Contact> list2 = new List<Contact>();
			List<Contact> list3 = new List<Contact>();
			List<Contact> list4 = new List<Contact>();
			List<PriorityTargetEntry> list5 = list_0;
			bool UnitIsOperating = true;
			Doctrine parentDoctrine = GetParentDoctrine(ref UnitIsOperating);
			bool flag = false;
			while (list5.Count < 2 && parentDoctrine != null)
			{
				list5 = parentDoctrine.list_0;
				if (parentDoctrine.Subject is Side)
				{
					break;
				}
				Doctrine doctrine = parentDoctrine;
				UnitIsOperating = true;
				parentDoctrine = doctrine.GetParentDoctrine(ref UnitIsOperating);
			}
			if (list5.Count < 2)
			{
				list.AddRange(theTargetList);
				return list;
			}
			list4.AddRange(theTargetList);
			foreach (PriorityTargetEntry item in list5)
			{
				switch (item.Priority)
				{
				case PriorityTargetEntry.PriorityFlags.PriorityLow:
					foreach (Contact theTarget in theTargetList)
					{
						if (item.AppliesTo(theTarget))
						{
							list.Remove(theTarget);
							if (!flag)
							{
								list3.Add(theTarget);
								list4.Remove(theTarget);
							}
						}
					}
					break;
				case PriorityTargetEntry.PriorityFlags.PriorityHigh:
					foreach (Contact theTarget2 in theTargetList)
					{
						if (item.AppliesTo(theTarget2))
						{
							list2.Add(theTarget2);
							list4.Remove(theTarget2);
						}
					}
					break;
				}
			}
			list.AddRange(list2);
			list.AddRange(list4);
			list.AddRange(list3);
			return list;
		}
		return list;
	}

	private bool method_0()
	{
		if (int_1 < 0)
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			int_1 = 0;
		}
		return int_1 > 0;
	}

	public void SuspendDoctrineChangeEvents()
	{
		lock (lockObject_0)
		{
			int_1++;
		}
	}

	public void ResumeDoctrineChangeEvents(bool? viaMainForm, bool MultipleUnits, bool ViaDoctrineForm, bool ViaRightColumn, bool viaFlightPlanEditor)
	{
		lock (lockObject_0)
		{
			int_1--;
			if (!method_0() && bool_0)
			{
				bool_0 = false;
				doctrineChangedEventHandler_0?.Invoke(Subject, viaMainForm, MultipleUnits, ViaDoctrineForm, ViaRightColumn, viaFlightPlanEditor);
			}
		}
	}

	private void method_1(ScenarioObject scenarioObject_0, bool? nullable_0, bool bool_1, bool bool_2, bool bool_3, bool bool_4)
	{
		lock (lockObject_0)
		{
			if (method_0())
			{
				bool_0 = true;
			}
			else
			{
				doctrineChangedEventHandler_0?.Invoke(scenarioObject_0, nullable_0, bool_1, bool_2, bool_3, bool_4);
			}
		}
	}

	private bool method_2<T>(ref T? nullable_0, T? nullable_1, bool? nullable_2, bool bool_1, bool bool_2, bool bool_3, bool bool_4) where T : struct, IConvertible
	{
		if (Subject.IsActiveUnit)
		{
			ActiveUnit activeUnit = (ActiveUnit)Subject;
			if (activeUnit.IsPlatform && ((Platform)activeUnit).Crew == 0 && activeUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DroneAutonomyLevels) && !activeUnit.CommStuff.IsConnectedToSideNetwork)
			{
				if (bool_2 || bool_3 || bool_4)
				{
					GameGeneral.SendMessageBoxToUI("Cannot change doctrine setting to disconnected drone", activeUnit.get_UnitSide(SetSideOnly: false), "Unable to change doctrine setting", GameGeneral.MessageBoxMessageType.ErrorMessage);
				}
				return false;
			}
		}
		bool flag = default(bool);
		if (!nullable_0.HasValue)
		{
			flag = true;
		}
		else if (!nullable_0.Value.Equals(nullable_1))
		{
			flag = true;
		}
		if (flag)
		{
			nullable_0 = nullable_1;
			method_1(Subject, nullable_2, bool_1, bool_2, bool_3, bool_4: false);
		}
		return flag;
	}

	public void FireEvent_DoctrineChanged(ScenarioObject Subject, bool? viaMainForm, bool MultipleUnits, bool ViaDoctrineForm, bool ViaRightColumn, bool viaFlightPlanEditor)
	{
		doctrineChangedEventHandler_0?.Invoke(Subject, viaMainForm, MultipleUnits, ViaDoctrineForm, ViaRightColumn, viaFlightPlanEditor);
	}

	public void FireEvent_EmconChanged(ScenarioObject Subject, bool? viaMainForm, bool MultipleUnits, bool ViaDoctrineForm, bool ViaRightColumn, bool viaFlightPlanEditor)
	{
		emconChangedEventHandler_0?.Invoke(Subject, viaMainForm, MultipleUnits, ViaDoctrineForm, ViaRightColumn, viaFlightPlanEditor);
	}

	public Side GetSide(Side CurrentSide = null)
	{
		if (!Subject.IsUnit())
		{
			if (Subject.IsActiveUnit)
			{
				return ((ActiveUnit)Subject).get_UnitSide(SetSideOnly: false);
			}
			if ((object)SubjectType == typeof(Side))
			{
				return (Side)Subject;
			}
			if (!(Subject is Mission))
			{
				if ((object)SubjectType == typeof(Waypoint))
				{
					bool UnitIsOperating = true;
					Doctrine parentDoctrine = GetParentDoctrine(ref UnitIsOperating, IgnoreMissionStatusEvaluation: false, CurrentSide);
					if (parentDoctrine != null && parentDoctrine != this)
					{
						return parentDoctrine.GetSide(CurrentSide);
					}
				}
				return null;
			}
			return CurrentSide;
		}
		return ((Module_Unit.Unit)Subject).get_UnitSide(SetSideOnly: false);
	}

	public void InheritDoctrine(ref Type SubjectType)
	{
		try
		{
			if ((object)SubjectType == typeof(Side) || (object)SubjectType == typeof(Waypoint))
			{
				return;
			}
			foreach (DoctrineItem item in DoctrineItems.ToList())
			{
				if (item != null)
				{
					item.set_CurrentState(ConsiderInheritance: false, (int?)null);
				}
			}
			EMCON_Inherits = true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at IneritDoctrine", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public Doctrine GetParentDoctrine(ref bool UnitIsOperating, bool IgnoreMissionStatusEvaluation = false, Side FallbackSide = null)
	{
		Doctrine doctrine;
		try
		{
			if (doctrine_0 != null)
			{
				goto IL_05ae;
			}
			try
			{
				if (UnitIsOperating || !Subject.IsActiveUnit)
				{
					goto IL_006c;
				}
				ActiveUnit activeUnit = (ActiveUnit)Subject;
				if (!activeUnit.IsAircraft)
				{
					if (activeUnit.IsShip)
					{
					}
					goto IL_006c;
				}
				Aircraft aircraft = (Aircraft)activeUnit;
				if (aircraft.IsOperating())
				{
					goto IL_006c;
				}
				Aircraft_AirOps airOps = aircraft.AirOps;
				if (airOps.CurrentHostUnit == null)
				{
					goto IL_006c;
				}
				doctrine = airOps.CurrentHostUnit.Doctrine;
				goto end_IL_000d;
				IL_0532:
				if (SelectedUnits == null || doctrine_0 != null)
				{
					goto IL_05ae;
				}
				if (FallbackSide != null)
				{
					doctrine = FallbackSide.Doctrine;
				}
				else
				{
					FallbackSide = ScenarioContext.GetCurrentSide();
					if (FallbackSide == null)
					{
						goto IL_05ae;
					}
					doctrine = FallbackSide.Doctrine;
				}
				goto end_IL_000d;
				IL_006c:
				if (Subject.IsGroup)
				{
					Group obj = (Group)Subject;
					Mission mission = obj.ActiveMissionOrPackage();
					if (mission != null && (mission.IsActive || IgnoreMissionStatusEvaluation))
					{
						if (obj.GroupLead != null && obj.GroupLead.AI.IsEscort)
						{
							if (mission.MissionClass == Mission._MissionClass.Strike)
							{
								doctrine_0 = ((Strike)mission).Doctrine_Escorts;
							}
							else
							{
								doctrine_0 = mission.Doctrine;
							}
						}
						else
						{
							doctrine_0 = mission.Doctrine;
						}
					}
					else
					{
						doctrine_0 = obj.get_UnitSide(SetSideOnly: false).Doctrine;
					}
					goto IL_0532;
				}
				if (Subject.IsActiveUnit)
				{
					ActiveUnit activeUnit2 = (ActiveUnit)Subject;
					if (activeUnit2.IsGroupMember())
					{
						doctrine_0 = activeUnit2.get_ParentGroup(UsingMissionPlanner: false).Doctrine;
					}
					else
					{
						Mission mission2 = activeUnit2.ActiveMissionOrPackage();
						if (mission2 != null && (mission2.IsActive || IgnoreMissionStatusEvaluation))
						{
							if (activeUnit2.AI.IsEscort && mission2.MissionClass == Mission._MissionClass.Strike)
							{
								doctrine_0 = ((Strike)mission2).Doctrine_Escorts;
							}
							else
							{
								doctrine_0 = mission2.Doctrine;
							}
						}
						else if (!activeUnit2.IsWeapon)
						{
							doctrine_0 = activeUnit2.get_UnitSide(SetSideOnly: false).Doctrine;
						}
						else
						{
							ActiveUnit firingParent = ((Weapon)activeUnit2).FiringParent;
							if (firingParent == null)
							{
								doctrine_0 = activeUnit2.get_UnitSide(SetSideOnly: false).Doctrine;
							}
							else
							{
								doctrine_0 = firingParent.get_UnitSide(SetSideOnly: false).Doctrine;
							}
						}
					}
					goto IL_0532;
				}
				if (Subject.IsMission)
				{
					Mission value = (Mission)Subject;
					Side[] sides_ReadOnly = ScenarioContext.Sides_ReadOnly;
					foreach (Side side in sides_ReadOnly)
					{
						if (side.get_MissionsTotal(ScenarioContext).Contains(value))
						{
							doctrine_0 = side.Doctrine;
							break;
						}
					}
					if (doctrine_0 != null)
					{
						goto IL_0532;
					}
					if (FallbackSide != null)
					{
						doctrine = FallbackSide.Doctrine;
					}
					else
					{
						FallbackSide = ScenarioContext.GetCurrentSide();
						if (FallbackSide == null)
						{
							goto IL_0532;
						}
						doctrine = FallbackSide.Doctrine;
					}
				}
				else
				{
					if (!Subject.IsWaypoint)
					{
						if ((object)SubjectType == typeof(Side))
						{
							doctrine_0 = ((Side)Subject).Doctrine;
						}
						goto IL_0532;
					}
					Waypoint waypoint = (Waypoint)Subject;
					bool flag = false;
					if (ScenarioContext != null)
					{
						if (waypoint.Category == Waypoint.WaypointCategory.PlottedCourse)
						{
							foreach (ActiveUnit activeUnits_ in ScenarioContext.ActiveUnits_List)
							{
								if (activeUnits_ != null && activeUnits_.Navigator.HasPlottedCourse() && activeUnits_.Navigator.PlottedCourse.Contains(waypoint))
								{
									doctrine_0 = activeUnits_.Doctrine;
									break;
								}
							}
						}
						else
						{
							Side[] sides_ReadOnly2 = ScenarioContext.Sides_ReadOnly;
							foreach (Side side2 in sides_ReadOnly2)
							{
								foreach (Mission mission3 in side2.Missions)
								{
									if (mission3.HasFlightPlans())
									{
										foreach (Mission.Flight flight in mission3.FlightList)
										{
											Waypoint[] flightPlan = flight.FlightPlan;
											foreach (Waypoint waypoint2 in flightPlan)
											{
												if (waypoint2 != waypoint)
												{
													if (waypoint2.Waypoint_LeadElementWingman == null)
													{
														if (waypoint2.Waypoint_SecondElement == null)
														{
															if (waypoint2.Waypoint_SecondElementWingman == null)
															{
																if (waypoint2.Waypoint_ThirdElement == null)
																{
																	if (waypoint2.Waypoint_ThirdElementWingman != null)
																	{
																		doctrine_0 = mission3.Doctrine;
																		flag = true;
																		break;
																	}
																	continue;
																}
																doctrine_0 = mission3.Doctrine;
																flag = true;
																break;
															}
															doctrine_0 = mission3.Doctrine;
															flag = true;
															break;
														}
														doctrine_0 = mission3.Doctrine;
														flag = true;
														break;
													}
													doctrine_0 = mission3.Doctrine;
													flag = true;
													break;
												}
												doctrine_0 = mission3.Doctrine;
												flag = true;
												break;
											}
											if (flag)
											{
												break;
											}
										}
									}
									if (flag)
									{
										break;
									}
								}
								if (flag)
								{
									break;
								}
							}
						}
					}
					if (doctrine_0 != null)
					{
						goto IL_0532;
					}
					if (FallbackSide != null)
					{
						doctrine = FallbackSide.Doctrine;
					}
					else
					{
						FallbackSide = ScenarioContext.GetCurrentSide();
						if (FallbackSide == null)
						{
							goto IL_0532;
						}
						doctrine = FallbackSide.Doctrine;
					}
				}
				end_IL_000d:;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101171", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				goto IL_05ae;
			}
			goto end_IL_0001;
			IL_05ae:
			if (doctrine_0 == null && Debugger.IsAttached)
			{
				_ = typeof(Side);
			}
			doctrine = doctrine_0;
			end_IL_0001:;
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 101001", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			doctrine = ScenarioContext.GetCurrentSide().Doctrine;
			ProjectData.ClearProjectError();
		}
		return doctrine;
	}

	public void ClearCachedParentDoctrine(bool ClearParentGroupDoctrine = true)
	{
		if (ClearParentGroupDoctrine && doctrine_0 != null && doctrine_0.Subject.IsGroup)
		{
			doctrine_0.doctrine_0 = null;
		}
		doctrine_0 = null;
	}

	internal List<ActiveUnit> AffectedUnits(Scenario theScen, bool? MissionEscort)
	{
		List<ActiveUnit> result;
		try
		{
			List<ActiveUnit> list = new List<ActiveUnit>();
			if ((object)SubjectType == typeof(Side))
			{
				list.AddRange(((Side)Subject).Units);
				goto IL_01a4;
			}
			if ((object)SubjectType != typeof(Waypoint))
			{
				if (Subject.IsMission)
				{
					foreach (ActiveUnit activeUnits_ in theScen.ActiveUnits_List)
					{
						if (activeUnits_ != null && activeUnits_.ActiveMissionOrPackage() == Subject)
						{
							if (!MissionEscort.HasValue)
							{
								list.Add(activeUnits_);
							}
							bool? flag = MissionEscort;
							if ((flag ?? true) && activeUnits_.AI.IsEscort && flag.HasValue)
							{
								list.Add(activeUnits_);
							}
							flag = (!MissionEscort) ?? MissionEscort;
							if ((flag ?? true) && !activeUnits_.AI.IsEscort && flag.HasValue)
							{
								list.Add(activeUnits_);
							}
						}
					}
				}
				else if (Subject.IsGroup)
				{
					list.AddRange(((Group)Subject).Units.Values);
				}
				else if (SelectedUnits != null && SelectedUnits.Count > 0)
				{
					list.AddRange(SelectedUnits);
				}
				else
				{
					list.Add((ActiveUnit)Subject);
				}
				goto IL_01a4;
			}
			result = new List<ActiveUnit>();
			goto end_IL_0001;
			IL_01a4:
			result = list;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101002", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new List<ActiveUnit>();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal bool DoctrineItemDiffers(Scenario theScen, object fromDoctrine, object toDoctrine)
	{
		bool result = true;
		if (fromDoctrine == toDoctrine)
		{
			return false;
		}
		if (fromDoctrine != null && fromDoctrine.Equals(RuntimeHelpers.GetObjectValue(toDoctrine)))
		{
			return false;
		}
		return result;
	}

	public DoctrineDefinition GetDoctrineDefinitionByID(string ID)
	{
		DoctrineDefinition value = null;
		DoctrineDefinitions.TryGetValue(ID, out value);
		return value;
	}

	public void SetDoctrineItem_XML(string Node, string InnerValue)
	{
		DoctrineDefinition value = null;
		DoctrineDefinitions_Savable.TryGetValue(Node, out value);
		if (value == null)
		{
			return;
		}
		int? currentState = null;
		if (!string.IsNullOrEmpty(InnerValue) && Operators.CompareString(InnerValue, "-1", false) != 0)
		{
			if (Versioned.IsNumeric((object)InnerValue))
			{
				currentState = ((Operators.CompareString(InnerValue, "255", false) != 0) ? new int?(Convert.ToInt32(InnerValue)) : value.GetState(value.Magic255Value));
			}
			else
			{
				string value2 = value._GETSTATEDEF_LEGACYBOOLEAN(Conversions.ToBoolean(InnerValue));
				if (!string.IsNullOrEmpty(value2))
				{
					currentState = value.GetState(value2);
				}
			}
		}
		GetElement(value)._CurrentState = currentState;
	}

	public DoctrineItem GetElement(DoctrineItem_E _doctrine, DoctrineItemAutopopulate AutopopulateMethod = DoctrineItemAutopopulate.DefaultValue)
	{
		return GetElement(DoctrineDefinitions_Array[(int)_doctrine], AutopopulateMethod);
	}

	public DoctrineItem GetElement(DoctrineDefinition doctrineDefinition, DoctrineItemAutopopulate AutopopulateMethod = DoctrineItemAutopopulate.DefaultValue)
	{
		DoctrineItem doctrineItem = DoctrineItems[(int)doctrineDefinition.EnumLink];
		if (doctrineItem == null)
		{
			DoctrineItem doctrineItem2 = null;
			if (AutopopulateMethod != DoctrineItemAutopopulate.None)
			{
				doctrineItem2 = new DoctrineItem(doctrineDefinition, this, AutopopulateMethod);
				DoctrineItems[(int)doctrineDefinition.EnumLink] = doctrineItem2;
			}
			return doctrineItem2;
		}
		return doctrineItem;
	}

	public int? GetElementState(DoctrineDefinition DoctrineType)
	{
		if (DoctrineType == null)
		{
			throw new NotImplementedException();
		}
		DoctrineItem doctrineItem = DoctrineItems[(int)DoctrineType.EnumLink];
		if (doctrineItem == null)
		{
			doctrineItem = new DoctrineItem(DoctrineType, this, DoctrineItemAutopopulate.Inherited);
			DoctrineItems[(int)DoctrineType.EnumLink] = doctrineItem;
		}
		return doctrineItem.get_CurrentState(ConsiderInheritance: true);
	}

	public int? GetElementState(DoctrineItem_E ID)
	{
		return GetElementState(DoctrineDefinitions_Array[(int)ID]);
	}

	public int? GetElementState(string ID)
	{
		return GetElementState(GetDoctrineDefinitionByID(ID));
	}

	public bool GetElement_PlayerEditable(DoctrineItem_E ID)
	{
		DoctrineDefinition doctrineDefinition = DoctrineDefinitions_Array[(int)ID];
		if ((object)SubjectType == typeof(Side))
		{
			DoctrineItem doctrineItem = DoctrineItems[(int)doctrineDefinition.EnumLink];
			if (doctrineItem == null)
			{
				doctrineItem = new DoctrineItem(doctrineDefinition, this, DoctrineItemAutopopulate.Inherited);
				DoctrineItems[(int)doctrineDefinition.EnumLink] = doctrineItem;
			}
			return doctrineItem.PlayerEditable;
		}
		bool UnitIsOperating = true;
		return GetParentDoctrine(ref UnitIsOperating).GetElement(ID).PlayerEditable;
	}

	public void SetElement_PlayerEditable(DoctrineItem_E ID, bool Value)
	{
		if ((object)SubjectType == typeof(Side))
		{
			GetElement(ID).PlayerEditable = Value;
			return;
		}
		bool UnitIsOperating = true;
		GetParentDoctrine(ref UnitIsOperating).GetElement(ID).PlayerEditable = Value;
	}

	public void SetElementState(DoctrineDefinition DoctrineType, int? value)
	{
		GetElement(DoctrineType).set_CurrentState(ConsiderInheritance: false, value);
	}

	public void SetElementState(DoctrineItem_E ID, int? value)
	{
		GetElement(DoctrineDefinitions_Array[(int)ID]).set_CurrentState(ConsiderInheritance: false, value);
	}

	public void SetElementState(DoctrineDefinition DoctrineType, object value)
	{
		int? value2 = null;
		if (value != null)
		{
			if (!(value is Enum))
			{
				throw new ArgumentException("SetElementState : Not an enum or null", "value");
			}
			value2 = Convert.ToInt32(RuntimeHelpers.GetObjectValue(value));
		}
		SetElementState(DoctrineType, value2);
	}

	public void SetElementState_Raw(DoctrineItem_E ID, object value)
	{
		int? currentState = null;
		if (value != null)
		{
			if (!(value is Enum))
			{
				throw new ArgumentException("SetElementState : Not an enum or null", "value");
			}
			currentState = Convert.ToInt32(RuntimeHelpers.GetObjectValue(value));
		}
		GetElement(DoctrineDefinitions_Array[(int)ID])._CurrentState = currentState;
	}

	public void SetElementState(string ID, int? value)
	{
		SetElementState(GetDoctrineDefinitionByID(ID), value);
	}

	public void SetElementState(string ID, int value)
	{
		SetElementState(GetDoctrineDefinitionByID(ID), value);
	}

	internal StringBuilder DoctrineDiffers(Doctrine fromDoctrine, Scenario theScen, bool IgnoreMissionStatusEvaluation = false)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Clear();
		bool UnitIsOperating = true;
		Doctrine parentDoctrine = GetParentDoctrine(ref UnitIsOperating, IgnoreMissionStatusEvaluation);
		DoctrineItem[] doctrineItems = DoctrineItems;
		foreach (DoctrineItem doctrineItem in doctrineItems)
		{
			if (doctrineItem != null)
			{
				int? elementState;
				int? num = (elementState = fromDoctrine.GetElementState(doctrineItem.Definifition));
				object fromDoctrine2 = ((!num.HasValue) ? parentDoctrine.GetElementState(doctrineItem.Definifition) : elementState);
				num = (elementState = GetElementState(doctrineItem.Definifition));
				if (DoctrineItemDiffers(theScen, fromDoctrine2, (!num.HasValue) ? parentDoctrine.GetElementState(doctrineItem.Definifition) : elementState))
				{
					stringBuilder.Append(" " + doctrineItem.Definifition.Name + ",");
				}
			}
		}
		if ((emconsettings_0 != null || fromDoctrine.emconsettings_0 != null) && emconsettings_0 != null)
		{
			emconsettings_0.Equals(fromDoctrine.emconsettings_0);
		}
		if (stringBuilder.Length > 0)
		{
			stringBuilder.Remove(stringBuilder.Length - 1, 1);
		}
		return stringBuilder;
	}

	internal EMCONSettings EMCON(Scenario theScen)
	{
		if (EMCON_Inherits)
		{
			bool UnitIsOperating = true;
			Doctrine parentDoctrine = GetParentDoctrine(ref UnitIsOperating);
			if (!Information.IsNothing((object)parentDoctrine))
			{
				return parentDoctrine.EMCON(theScen);
			}
		}
		return emconsettings_0;
	}

	public static int? WRA_WeaponQty_AnyTargetType(Doctrine theDoc, Scenario theScen, Weapon theWeapon, _WRA_WeaponTargetType selectedNodeTargetType, bool FindInheritedValuesOnly, [Optional][DefaultParameterValue(null)] ref int? TargetType_InheritedWeaponQty, [Optional][DefaultParameterValue(null)] ref int? TargetType_UnspecifiedWeaponQty)
	{
		int? result = default(int?);
		if (theWeapon != null)
		{
			if (theWeapon.IsWeaponPallet)
			{
				if (theWeapon.WeaponWeapons.Count == 0)
				{
					theWeapon.InitializeWeaponWeaponsPallet();
				}
				theWeapon = theWeapon.WeaponWeapons[0].get_ReferenceWeapon(theScen);
			}
			if ((object)theDoc.SubjectType != typeof(Side) && theWeapon.DBID > 0)
			{
				if (FindInheritedValuesOnly)
				{
					bool UnitIsOperating = true;
					TargetType_InheritedWeaponQty = WRA_WeaponQty_CurrentTargetType(theDoc.GetParentDoctrine(ref UnitIsOperating), theScen, theWeapon, selectedNodeTargetType);
				}
				else
				{
					TargetType_InheritedWeaponQty = WRA_WeaponQty_CurrentTargetType(theDoc, theScen, theWeapon, selectedNodeTargetType);
				}
				if (!TargetType_InheritedWeaponQty.HasValue && !WRA_IsTopNodeTargetType(ref selectedNodeTargetType))
				{
					_WRA_WeaponTargetType selectedNodeTargetType2 = WRA_DetermineTargetType_Unspecified(ref selectedNodeTargetType);
					TargetType_UnspecifiedWeaponQty = WRA_WeaponQty_CurrentTargetType(theDoc, theScen, theWeapon, selectedNodeTargetType2);
					return TargetType_UnspecifiedWeaponQty;
				}
				int? num = TargetType_InheritedWeaponQty;
				if ((num.HasValue ? new bool?(num == -1) : ((bool?)null)) == true)
				{
					TargetType_InheritedWeaponQty = WRA_WeaponQty_SystemDefault(theWeapon, selectedNodeTargetType);
				}
				return TargetType_InheritedWeaponQty;
			}
		}
		else
		{
			result = 0;
		}
		return result;
	}

	public static int? WRA_WeaponQty_CurrentTargetType(Doctrine theDoc, Scenario theScen, Weapon theWeapon, _WRA_WeaponTargetType selectedNodeTargetType)
	{
		int? num = theDoc.method_3(theWeapon.DBID, selectedNodeTargetType);
		if (!num.HasValue && (object)theDoc.SubjectType != typeof(Side))
		{
			bool UnitIsOperating = true;
			Doctrine parentDoctrine = theDoc.GetParentDoctrine(ref UnitIsOperating);
			if (parentDoctrine != null)
			{
				num = WRA_WeaponQty_CurrentTargetType(parentDoctrine, theScen, theWeapon, selectedNodeTargetType);
			}
		}
		return num ?? WRA_WeaponQty_SystemDefault(theWeapon, selectedNodeTargetType);
	}

	public static int? WRA_WeaponQty_SystemDefault(Weapon theWeapon, _WRA_WeaponTargetType selectedNodeTargetType)
	{
		if (selectedNodeTargetType == _WRA_WeaponTargetType.Decoy)
		{
			return 0;
		}
		WRA_FiringDoctrineEntry value = null;
		if (theWeapon.SingularWeaponWRA == null)
		{
			ConcurrentPagedArray<WRA_Weapon> wRA = theWeapon.Doctrine.WRA;
			if (wRA != null && wRA.Count > 0)
			{
				theWeapon.SingularWeaponWRA = wRA.Values.ElementAtOrDefault(0);
			}
		}
		WRA_Weapon singularWeaponWRA = theWeapon.SingularWeaponWRA;
		if (singularWeaponWRA != null && singularWeaponWRA.WRA_WeaponTargets.TryGetValue((int)selectedNodeTargetType, ref value))
		{
			return value.WeaponQty;
		}
		int? result = default(int?);
		if (selectedNodeTargetType == _WRA_WeaponTargetType.Helicopter_Unspecified)
		{
			result = WRA_WeaponQty_SystemDefault(theWeapon, _WRA_WeaponTargetType.Aircraft_Unspecified);
		}
		if (selectedNodeTargetType == _WRA_WeaponTargetType.Aircraft_Unspecified)
		{
			result = WRA_WeaponQty_SystemDefault(theWeapon, _WRA_WeaponTargetType.Air_Contact_Unknown_Type);
		}
		return result;
	}

	private int? method_3(int int_2, _WRA_WeaponTargetType _WRA_WeaponTargetType_0)
	{
		int? result;
		if (concurrentPagedArray_0 == null)
		{
			result = null;
		}
		else
		{
			WRA_Weapon wRA_Weapon = concurrentPagedArray_0[int_2];
			if (wRA_Weapon != null)
			{
				WRA_FiringDoctrineEntry value = null;
				wRA_Weapon.WRA_WeaponTargets.TryGetValue((int)_WRA_WeaponTargetType_0, ref value);
				if (value != null)
				{
					return value.WeaponQty;
				}
			}
			result = null;
		}
		return result;
	}

	public static int? WRA_ShooterQty_AnyTargetType(Doctrine theDoc, Scenario theScen, Weapon theWeapon, _WRA_WeaponTargetType selectedNodeTargetType, bool FindInheritedValuesOnly, [Optional][DefaultParameterValue(null)] ref int? TargetType_InheritedShooterQty, [Optional][DefaultParameterValue(null)] ref int? TargetType_UnspecifiedShooterQty)
	{
		if ((object)theDoc.SubjectType != typeof(Side) && theWeapon.DBID > 0)
		{
			if (!FindInheritedValuesOnly)
			{
				TargetType_InheritedShooterQty = WRA_ShooterQty_CurrentTargetType(theDoc, theScen, theWeapon, selectedNodeTargetType);
			}
			else
			{
				bool UnitIsOperating = true;
				TargetType_InheritedShooterQty = WRA_ShooterQty_CurrentTargetType(theDoc.GetParentDoctrine(ref UnitIsOperating), theScen, theWeapon, selectedNodeTargetType);
			}
			if (!TargetType_InheritedShooterQty.HasValue && !WRA_IsTopNodeTargetType(ref selectedNodeTargetType))
			{
				_WRA_WeaponTargetType selectedNodeTargetType2 = WRA_DetermineTargetType_Unspecified(ref selectedNodeTargetType);
				TargetType_UnspecifiedShooterQty = WRA_ShooterQty_CurrentTargetType(theDoc, theScen, theWeapon, selectedNodeTargetType2);
				return TargetType_UnspecifiedShooterQty;
			}
			int? num = TargetType_InheritedShooterQty;
			if (((!num.HasValue) ? ((bool?)null) : new bool?(num == -1)) == true)
			{
				TargetType_InheritedShooterQty = WRA_ShooterQty_SystemDefault(theWeapon, selectedNodeTargetType);
			}
			return TargetType_InheritedShooterQty;
		}
		int? result = default(int?);
		return result;
	}

	public static int? WRA_ShooterQty_CurrentTargetType(Doctrine theDoc, Scenario theScen, Weapon theWeapon, _WRA_WeaponTargetType selectedNodeTargetType)
	{
		int? num = theDoc.method_4(theWeapon.DBID, selectedNodeTargetType);
		if (!num.HasValue && (object)theDoc.SubjectType != typeof(Side))
		{
			bool UnitIsOperating = true;
			Doctrine parentDoctrine = theDoc.GetParentDoctrine(ref UnitIsOperating);
			if (!Information.IsNothing((object)parentDoctrine))
			{
				num = WRA_ShooterQty_CurrentTargetType(parentDoctrine, theScen, theWeapon, selectedNodeTargetType);
			}
		}
		if (num.HasValue)
		{
			int? num2 = num;
			if ((num2.HasValue ? new bool?(num2 == -1) : ((bool?)null)) != true)
			{
				return num;
			}
		}
		return WRA_ShooterQty_SystemDefault(theWeapon, selectedNodeTargetType);
	}

	public static int? WRA_ShooterQty_SystemDefault(Weapon theWeapon, _WRA_WeaponTargetType selectedNodeTargetType)
	{
		int? result;
		if (selectedNodeTargetType == _WRA_WeaponTargetType.Decoy)
		{
			result = -101;
		}
		else
		{
			if (theWeapon.SingularWeaponWRA == null)
			{
				ConcurrentPagedArray<WRA_Weapon> wRA = theWeapon.Doctrine.WRA;
				if (wRA != null && wRA.Count > 0)
				{
					theWeapon.SingularWeaponWRA = wRA.Values.ElementAtOrDefault(0);
				}
			}
			WRA_Weapon singularWeaponWRA = theWeapon.SingularWeaponWRA;
			WRA_FiringDoctrineEntry value = default(WRA_FiringDoctrineEntry);
			if (singularWeaponWRA != null && singularWeaponWRA.WRA_WeaponTargets.TryGetValue((int)selectedNodeTargetType, ref value))
			{
				return value.ShooterQty;
			}
			if (selectedNodeTargetType == _WRA_WeaponTargetType.Helicopter_Unspecified)
			{
				return WRA_ShooterQty_SystemDefault(theWeapon, _WRA_WeaponTargetType.Aircraft_Unspecified);
			}
			result = null;
		}
		return result;
	}

	private int? method_4(int int_2, _WRA_WeaponTargetType _WRA_WeaponTargetType_0)
	{
		int? result;
		if (concurrentPagedArray_0 == null)
		{
			result = null;
		}
		else
		{
			WRA_Weapon wRA_Weapon = concurrentPagedArray_0[int_2];
			if (wRA_Weapon != null)
			{
				WRA_FiringDoctrineEntry value = null;
				wRA_Weapon.WRA_WeaponTargets.TryGetValue((int)_WRA_WeaponTargetType_0, ref value);
				if (value != null)
				{
					return value.ShooterQty;
				}
			}
			result = null;
		}
		return result;
	}

	internal float? WRA_SelfDefenceRange_AnyTargetType(Doctrine theDoc, Scenario theScen, Weapon theWeapon, _WRA_WeaponTargetType selectedNodeTargetType, bool FindInheritedValuesOnly, [Optional][DefaultParameterValue(null)] ref float? TargetType_InheriteSelfDefenceRange, [Optional][DefaultParameterValue(null)] ref float? TargetType_UnspecifiedSelfDefenceRange)
	{
		if ((object)theDoc.SubjectType != typeof(Side) && theWeapon.DBID > 0)
		{
			if (!FindInheritedValuesOnly)
			{
				TargetType_InheriteSelfDefenceRange = WRA_SelfDefenceRange_CurrentTargetType(theDoc, theScen, theWeapon, selectedNodeTargetType);
			}
			else
			{
				bool UnitIsOperating = true;
				TargetType_InheriteSelfDefenceRange = WRA_SelfDefenceRange_CurrentTargetType(theDoc.GetParentDoctrine(ref UnitIsOperating), theScen, theWeapon, selectedNodeTargetType);
			}
			if (!WRA_IsTopNodeTargetType(ref selectedNodeTargetType) && !TargetType_InheriteSelfDefenceRange.HasValue)
			{
				_WRA_WeaponTargetType selectedNodeTargetType2 = WRA_DetermineTargetType_Unspecified(ref selectedNodeTargetType);
				TargetType_UnspecifiedSelfDefenceRange = WRA_SelfDefenceRange_CurrentTargetType(theDoc, theScen, theWeapon, selectedNodeTargetType2);
				return TargetType_UnspecifiedSelfDefenceRange;
			}
			float? num = TargetType_InheriteSelfDefenceRange;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == -1f) : ((bool?)null)) == true)
			{
				TargetType_InheriteSelfDefenceRange = WRA_SelfDefenceRange_SystemDefault(theWeapon, selectedNodeTargetType);
			}
			return TargetType_InheriteSelfDefenceRange;
		}
		float? result = default(float?);
		return result;
	}

	public static float? WRA_SelfDefenceRange_CurrentTargetType(Doctrine theDoc, Scenario theScen, Weapon theWeapon, _WRA_WeaponTargetType selectedNodeTargetType)
	{
		float? num = theDoc.method_5(theWeapon.DBID, selectedNodeTargetType);
		if (!num.HasValue && (object)theDoc.SubjectType != typeof(Side))
		{
			bool UnitIsOperating = true;
			Doctrine parentDoctrine = theDoc.GetParentDoctrine(ref UnitIsOperating);
			if (parentDoctrine != null)
			{
				num = WRA_SelfDefenceRange_CurrentTargetType(parentDoctrine, theScen, theWeapon, selectedNodeTargetType);
			}
		}
		return num ?? WRA_SelfDefenceRange_SystemDefault(theWeapon, selectedNodeTargetType);
	}

	public static float? WRA_SelfDefenceRange_SystemDefault(Weapon theWeapon, _WRA_WeaponTargetType selectedNodeTargetType)
	{
		float? result;
		if (selectedNodeTargetType == _WRA_WeaponTargetType.Decoy)
		{
			result = 0f;
		}
		else
		{
			if (theWeapon.SingularWeaponWRA == null)
			{
				ConcurrentPagedArray<WRA_Weapon> wRA = theWeapon.Doctrine.WRA;
				if (wRA != null && wRA.Count > 0)
				{
					theWeapon.SingularWeaponWRA = wRA.Values.ElementAtOrDefault(0);
				}
			}
			WRA_Weapon singularWeaponWRA = theWeapon.SingularWeaponWRA;
			WRA_FiringDoctrineEntry value = default(WRA_FiringDoctrineEntry);
			if (singularWeaponWRA != null && singularWeaponWRA.WRA_WeaponTargets.TryGetValue((int)selectedNodeTargetType, ref value))
			{
				return value.SelfDefenceRange;
			}
			if (selectedNodeTargetType == _WRA_WeaponTargetType.Helicopter_Unspecified)
			{
				return WRA_SelfDefenceRange_SystemDefault(theWeapon, _WRA_WeaponTargetType.Aircraft_Unspecified);
			}
			result = null;
		}
		return result;
	}

	private float? method_5(int int_2, _WRA_WeaponTargetType _WRA_WeaponTargetType_0)
	{
		float? result;
		if (concurrentPagedArray_0 == null)
		{
			result = null;
		}
		else
		{
			WRA_Weapon wRA_Weapon = concurrentPagedArray_0[int_2];
			if (wRA_Weapon != null)
			{
				WRA_FiringDoctrineEntry value = null;
				wRA_Weapon.WRA_WeaponTargets.TryGetValue((int)_WRA_WeaponTargetType_0, ref value);
				if (value != null)
				{
					return value.SelfDefenceRange;
				}
			}
			result = null;
		}
		return result;
	}

	internal float? WRA_FiringRange_AnyTargetType(Doctrine theDoc, Scenario theScen, int theWeaponDBID, _WRA_WeaponTargetType selectedNodeTargetType, bool FindInheritedValuesOnly, [Optional][DefaultParameterValue(null)] ref float? TargetType_InheritedFiringRange, [Optional][DefaultParameterValue(null)] ref float? TargetType_UnspecifiedFiringRange)
	{
		if ((object)theDoc.SubjectType != typeof(Side) && theWeaponDBID > 0)
		{
			if (!FindInheritedValuesOnly)
			{
				TargetType_InheritedFiringRange = WRA_FiringRange_CurrentTargetType(theDoc, theScen, theWeaponDBID, selectedNodeTargetType);
			}
			else
			{
				bool UnitIsOperating = true;
				TargetType_InheritedFiringRange = WRA_FiringRange_CurrentTargetType(theDoc.GetParentDoctrine(ref UnitIsOperating), theScen, theWeaponDBID, selectedNodeTargetType);
			}
			float? num;
			bool? flag;
			if (!TargetType_InheritedFiringRange.HasValue && !WRA_IsTopNodeTargetType(ref selectedNodeTargetType))
			{
				_WRA_WeaponTargetType selectedNodeTargetType2 = WRA_DetermineTargetType_Unspecified(ref selectedNodeTargetType);
				TargetType_UnspecifiedFiringRange = WRA_FiringRange_CurrentTargetType(theDoc, theScen, theWeaponDBID, selectedNodeTargetType2);
				num = TargetType_UnspecifiedFiringRange;
				flag = ((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() == -102f));
				if ((IsNEZValidTarget(selectedNodeTargetType) ? new bool?(false) : flag) == true)
				{
					TargetType_UnspecifiedFiringRange = (float)WRA_FiringRange_GetDefaultFiringRange(theScen, theWeaponDBID, selectedNodeTargetType);
				}
				return TargetType_UnspecifiedFiringRange;
			}
			num = TargetType_InheritedFiringRange;
			flag = ((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() == -102f));
			if ((IsNEZValidTarget(selectedNodeTargetType) ? new bool?(false) : flag) == true)
			{
				TargetType_UnspecifiedFiringRange = (float)WRA_FiringRange_GetDefaultFiringRange(theScen, theWeaponDBID, selectedNodeTargetType);
			}
			return TargetType_InheritedFiringRange;
		}
		if (!TargetType_InheritedFiringRange.HasValue)
		{
			TargetType_UnspecifiedFiringRange = (float)WRA_FiringRange_GetDefaultFiringRange(theScen, theWeaponDBID, selectedNodeTargetType);
		}
		return TargetType_InheritedFiringRange;
	}

	public static _WRA_FiringRange WRA_FiringRange_GetDefaultFiringRange(Scenario theScen, int theWeaponDBID, _WRA_WeaponTargetType theTargetType)
	{
		int result;
		if (theScen.DefaultGuidedWeaponsVsAirTargetWRASetting != _WRA_FiringRange.NotConfigured)
		{
			if (!smethod_1(theTargetType))
			{
				result = -99;
				goto IL_002f;
			}
			if (DBFunctions.GetWeaponType(theWeaponDBID, theScen) == Weapon._WeaponType.GuidedWeapon)
			{
				return theScen.DefaultGuidedWeaponsVsAirTargetWRASetting;
			}
		}
		result = -99;
		goto IL_002f;
		IL_002f:
		return (_WRA_FiringRange)result;
	}

	internal float? WRA_FiringRange_CurrentTargetType(Doctrine theDoc, Scenario theScen, int theWeaponDBID, _WRA_WeaponTargetType selectedNodeTargetType)
	{
		float? result = smethod_0(theDoc, theScen, theWeaponDBID, selectedNodeTargetType);
		if (!result.HasValue && (object)theDoc.SubjectType != typeof(Side))
		{
			bool UnitIsOperating = true;
			Doctrine parentDoctrine = theDoc.GetParentDoctrine(ref UnitIsOperating);
			if (parentDoctrine != null)
			{
				result = WRA_FiringRange_CurrentTargetType(parentDoctrine, theScen, theWeaponDBID, selectedNodeTargetType);
			}
		}
		return result;
	}

	private static float? smethod_0(object object_0, Scenario scenario_0, int int_2, _WRA_WeaponTargetType _WRA_WeaponTargetType_0)
	{
		float? result = null;
		float? result2;
		if (((Doctrine)object_0).concurrentPagedArray_0 == null)
		{
			result2 = null;
		}
		else
		{
			WRA_Weapon wRA_Weapon = ((Doctrine)object_0).concurrentPagedArray_0[int_2];
			if (wRA_Weapon != null)
			{
				WRA_FiringDoctrineEntry value = null;
				if (wRA_Weapon.WRA_WeaponTargets.TryGetValue((int)_WRA_WeaponTargetType_0, ref value))
				{
					result = value.FiringRange;
				}
			}
			if (result.HasValue || (object)((Doctrine)object_0).SubjectType != typeof(Side) || !WRA_IsTopNodeTargetType(ref _WRA_WeaponTargetType_0))
			{
				return result;
			}
			float value2 = (float)WRA_FiringRange_GetDefaultFiringRange(scenario_0, int_2, _WRA_WeaponTargetType_0);
			result2 = value2;
		}
		return result2;
	}

	public static _WRA_WeaponTargetType WRA_ConvertWeaponTargetTypeToWRA_TargetType(ref Weapon theW, ref Contact theTarget, ref _WRA_WeaponTargetType theTargetType, string theSideID)
	{
		ActiveUnit actualUnit = theTarget.ActualUnit;
		if (actualUnit == null || !actualUnit.get_isTaggedAsDecoyByThisSide(theSideID))
		{
			if (theW.ValidTargets.Radar && (theTargetType == _WRA_WeaponTargetType.Emitter_Unspecified || theTargetType == _WRA_WeaponTargetType.Emitter_Radar || theTargetType == _WRA_WeaponTargetType.Emitter_Jammer))
			{
				return theTargetType;
			}
			if (theW.ValidTargets.Submarine && theTargetType == _WRA_WeaponTargetType.Submarine_Surfaced)
			{
				return _WRA_WeaponTargetType.Submarine_Unspecified;
			}
			if (theW.ValidTargets.Torpedo && theTarget.Type == Contact_Base.ContactType.Torpedo)
			{
				return _WRA_WeaponTargetType.Subsurface_Contact_Unknown_Type;
			}
			if (theTarget.Type == Contact_Base.ContactType.Decoy_Air)
			{
				if (theTarget.DetectedEmissions.Count != 0)
				{
					foreach (KeyValuePair<int, EmissionContainer> detectedEmission in theTarget.DetectedEmissions)
					{
						if (detectedEmission.Value.get_AssociatedSensor(detectedEmission.Key, theW.ParentScen).IsOECM)
						{
							return _WRA_WeaponTargetType.Aircraft_Unspecified;
						}
					}
				}
				return _WRA_WeaponTargetType.Decoy;
			}
			int result;
			if (theTarget.Type != Contact_Base.ContactType.Decoy_Land && theTarget.Type != Contact_Base.ContactType.Decoy_Surface)
			{
				if (theTarget.Type != Contact_Base.ContactType.Decoy_Sub)
				{
					return theTargetType;
				}
				result = 1002;
			}
			else
			{
				result = 1002;
			}
			return (_WRA_WeaponTargetType)result;
		}
		return _WRA_WeaponTargetType.Decoy;
	}

	public static _WRA_WeaponTargetType WRA_DetermineTargetType(ref ActiveUnit theAU, Weapon theW, ref GlobalVariables.BooleanObject RadarClassificable)
	{
		Contact theTarget = Contact.Instantiate(theAU, 0, forWRA: true);
		theTarget.IDStatusBypassIdentification = Contact_Base.IdentificationStatus.PreciseID;
		return Contact.WRA_DetermineTargetType(ref theTarget, theW, ref RadarClassificable);
	}

	public static bool WRA_IsTopNodeTargetType(ref _WRA_WeaponTargetType theTargetType)
	{
		_WRA_WeaponTargetType wRA_WeaponTargetType = theTargetType;
		int result;
		if (wRA_WeaponTargetType <= _WRA_WeaponTargetType.Land_Structure_Soft_Unspecified)
		{
			if (wRA_WeaponTargetType <= _WRA_WeaponTargetType.Guided_Weapon_Unspecified)
			{
				switch (wRA_WeaponTargetType)
				{
				case _WRA_WeaponTargetType.Guided_Weapon_Unspecified:
					return true;
				case _WRA_WeaponTargetType.Helicopter_Unspecified:
					return true;
				case _WRA_WeaponTargetType.Air_Contact_Unknown_Type:
				case _WRA_WeaponTargetType.Aircraft_Unspecified:
					return true;
				}
				result = 0;
			}
			else if (wRA_WeaponTargetType <= _WRA_WeaponTargetType.Ship_Unspecified)
			{
				switch (wRA_WeaponTargetType)
				{
				case _WRA_WeaponTargetType.Surface_Contact_Unknown_Type:
				case _WRA_WeaponTargetType.Ship_Unspecified:
					return true;
				case _WRA_WeaponTargetType.Satellite_Unspecified:
					return true;
				}
				result = 0;
			}
			else
			{
				switch (wRA_WeaponTargetType)
				{
				case _WRA_WeaponTargetType.Subsurface_Contact_Unknown_Type:
				case _WRA_WeaponTargetType.Submarine_Unspecified:
					return true;
				case _WRA_WeaponTargetType.Land_Contact_Unknown_Type:
				case _WRA_WeaponTargetType.Land_Structure_Soft_Unspecified:
					return true;
				}
				result = 0;
			}
		}
		else if (wRA_WeaponTargetType <= _WRA_WeaponTargetType.Emitter_Unspecified)
		{
			switch (wRA_WeaponTargetType)
			{
			case _WRA_WeaponTargetType.Emitter_Unspecified:
				return true;
			case _WRA_WeaponTargetType.Runway_Facility_Unspecified:
				return true;
			case _WRA_WeaponTargetType.Land_Structure_Hardened_Unspecified:
				return true;
			}
			result = 0;
		}
		else if (wRA_WeaponTargetType > _WRA_WeaponTargetType.Mobile_Target_Hardened_Unspecified)
		{
			switch (wRA_WeaponTargetType)
			{
			case _WRA_WeaponTargetType.Air_Base_Single_Unit_Airfield:
				return true;
			case _WRA_WeaponTargetType.Underwater_Structure:
				return true;
			}
			result = 0;
		}
		else
		{
			if (wRA_WeaponTargetType == _WRA_WeaponTargetType.Mobile_Target_Soft_Unspecified)
			{
				return true;
			}
			if (wRA_WeaponTargetType == _WRA_WeaponTargetType.Mobile_Target_Hardened_Unspecified)
			{
				return true;
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	public static _WRA_WeaponTargetType WRA_DetermineTargetType_Unspecified(ref _WRA_WeaponTargetType theTargetType)
	{
		_WRA_WeaponTargetType wRA_WeaponTargetType = theTargetType;
		int result;
		int result2;
		int result3;
		int result4;
		if (wRA_WeaponTargetType <= _WRA_WeaponTargetType.Ship_Auxiliary_95000_tons)
		{
			if (wRA_WeaponTargetType > _WRA_WeaponTargetType.Guided_Weapon_Subsonic)
			{
				if (wRA_WeaponTargetType <= _WRA_WeaponTargetType.Ship_Carrier_95000_tons)
				{
					if (wRA_WeaponTargetType != _WRA_WeaponTargetType.Guided_Weapon_Ballistic)
					{
						if ((uint)(wRA_WeaponTargetType - 3001) > 3u)
						{
							goto IL_00b4;
						}
						result = 3000;
						goto IL_0187;
					}
					result2 = 2200;
					goto IL_00ae;
				}
				if ((uint)(wRA_WeaponTargetType - 3101) > 7u)
				{
					if ((uint)(wRA_WeaponTargetType - 3201) <= 7u)
					{
						result = 3000;
						goto IL_0187;
					}
					if ((uint)(wRA_WeaponTargetType - 3301) > 7u)
					{
						result3 = 1001;
						goto IL_01ab;
					}
				}
				goto IL_0182;
			}
			if (wRA_WeaponTargetType > _WRA_WeaponTargetType.Aircraft_Low_Perf_Bombers)
			{
				if ((uint)(wRA_WeaponTargetType - 2021) > 2u)
				{
					if ((uint)(wRA_WeaponTargetType - 2031) <= 3u)
					{
						result4 = 2000;
						goto IL_00e1;
					}
					if ((uint)(wRA_WeaponTargetType - 2201) <= 3u)
					{
						result2 = 2200;
						goto IL_00ae;
					}
					goto IL_00b4;
				}
			}
			else if ((uint)(wRA_WeaponTargetType - 2001) > 3u && (uint)(wRA_WeaponTargetType - 2011) > 2u)
			{
				result3 = 1001;
				goto IL_01ab;
			}
			result4 = 2000;
			goto IL_00e1;
		}
		if (wRA_WeaponTargetType > _WRA_WeaponTargetType.Land_Structure_Hardened_Structure_Reveted)
		{
			if (wRA_WeaponTargetType > _WRA_WeaponTargetType.Emitter_Radar)
			{
				if (wRA_WeaponTargetType == _WRA_WeaponTargetType.Emitter_Jammer)
				{
					goto IL_014a;
				}
				switch (wRA_WeaponTargetType)
				{
				case _WRA_WeaponTargetType.Mobile_Target_Soft_Mobile_Vehicle:
				case _WRA_WeaponTargetType.Mobile_Target_Soft_Mobile_Personnel:
					return _WRA_WeaponTargetType.Mobile_Target_Soft_Unspecified;
				case _WRA_WeaponTargetType.Mobile_Target_Hardened_Mobile_Vehicle:
					return _WRA_WeaponTargetType.Mobile_Target_Hardened_Unspecified;
				}
				result3 = 1001;
			}
			else
			{
				if ((uint)(wRA_WeaponTargetType - 5201) <= 2u)
				{
					return _WRA_WeaponTargetType.Runway_Facility_Unspecified;
				}
				if (wRA_WeaponTargetType == _WRA_WeaponTargetType.Emitter_Radar)
				{
					goto IL_014a;
				}
				result3 = 1001;
			}
		}
		else if (wRA_WeaponTargetType <= _WRA_WeaponTargetType.Submarine_Surfaced)
		{
			if ((uint)(wRA_WeaponTargetType - 3401) <= 7u)
			{
				result = 3000;
				goto IL_0187;
			}
			if (wRA_WeaponTargetType == _WRA_WeaponTargetType.Submarine_Surfaced)
			{
				goto IL_0182;
			}
			result3 = 1001;
		}
		else
		{
			if ((uint)(wRA_WeaponTargetType - 5001) <= 5u || wRA_WeaponTargetType == _WRA_WeaponTargetType.Land_Structure_Soft_Aerostat_Moring)
			{
				return _WRA_WeaponTargetType.Land_Structure_Soft_Unspecified;
			}
			if ((uint)(wRA_WeaponTargetType - 5101) <= 5u)
			{
				return _WRA_WeaponTargetType.Land_Structure_Hardened_Unspecified;
			}
			result3 = 1001;
		}
		goto IL_01ab;
		IL_014a:
		return _WRA_WeaponTargetType.Emitter_Unspecified;
		IL_00b4:
		result3 = 1001;
		goto IL_01ab;
		IL_0182:
		result = 3000;
		goto IL_0187;
		IL_00ae:
		return (_WRA_WeaponTargetType)result2;
		IL_0187:
		return (_WRA_WeaponTargetType)result;
		IL_00e1:
		return (_WRA_WeaponTargetType)result4;
		IL_01ab:
		return (_WRA_WeaponTargetType)result3;
	}

	public void SetEMCON_Radar(EMCONSettings._EMCONSetting NewValue, Scenario theScen)
	{
		if (EMCON_Inherits && !Information.IsNothing((object)EMCON(theScen)))
		{
			emconsettings_0 = new EMCONSettings(NewValue, EMCON(theScen).Sonar(), EMCON(theScen).OECM());
		}
		else if (!Information.IsNothing((object)emconsettings_0))
		{
			emconsettings_0 = new EMCONSettings(NewValue, emconsettings_0.Sonar(), emconsettings_0.OECM());
		}
		else
		{
			emconsettings_0 = new EMCONSettings(NewValue, EMCONSettings._EMCONSetting.NotConfigured, EMCONSettings._EMCONSetting.NotConfigured);
		}
	}

	public void SetEMCON_Sonar(EMCONSettings._EMCONSetting NewValue, Scenario theScen)
	{
		if (EMCON_Inherits && !Information.IsNothing((object)EMCON(theScen)))
		{
			emconsettings_0 = new EMCONSettings(EMCON(theScen).Radar(), NewValue, EMCON(theScen).OECM());
		}
		else if (Information.IsNothing((object)emconsettings_0))
		{
			emconsettings_0 = new EMCONSettings(EMCONSettings._EMCONSetting.NotConfigured, NewValue, EMCONSettings._EMCONSetting.NotConfigured);
		}
		else
		{
			emconsettings_0 = new EMCONSettings(emconsettings_0.Radar(), NewValue, emconsettings_0.OECM());
		}
	}

	public void SetEMCON_OECM(EMCONSettings._EMCONSetting NewValue, Scenario theScen)
	{
		if (EMCON_Inherits && EMCON(theScen) != null)
		{
			emconsettings_0 = new EMCONSettings(EMCON(theScen).Radar(), EMCON(theScen).Sonar(), NewValue);
		}
		else if (emconsettings_0 != null)
		{
			emconsettings_0 = new EMCONSettings(emconsettings_0.Radar(), emconsettings_0.Sonar(), NewValue);
		}
		else
		{
			emconsettings_0 = new EMCONSettings(EMCONSettings._EMCONSetting.NotConfigured, EMCONSettings._EMCONSetting.NotConfigured, NewValue);
		}
	}

	public void SetEMCON(EMCONSettings._EMCONSetting RadarValue, EMCONSettings._EMCONSetting SonarValue, EMCONSettings._EMCONSetting _EMCONSetting_0)
	{
		emconsettings_0 = new EMCONSettings(RadarValue, SonarValue, _EMCONSetting_0);
	}

	public void ComboBoxDataSource_WeaponQty(ref DataTable theComboBoxDataSource_WeaponQty, _WRA_WeaponTargetType theTargetType, ref Weapon theWeapon, int theComboBoxValue)
	{
		if (!theComboBoxDataSource_WeaponQty.Columns.Contains("ID"))
		{
			theComboBoxDataSource_WeaponQty.Columns.Add("ID", typeof(int));
		}
		if (!theComboBoxDataSource_WeaponQty.Columns.Contains("Description"))
		{
			theComboBoxDataSource_WeaponQty.Columns.Add("Description", typeof(string));
		}
		int? weaponQty = default(int?);
		foreach (KeyValuePair<int, WRA_Weapon> item in theWeapon.Doctrine.WRA)
		{
			_ = item.Key;
			WRA_FiringDoctrineEntry value = null;
			if (item.Value.WRA_WeaponTargets.TryGetValue((int)theTargetType, ref value))
			{
				weaponQty = value.WeaponQty;
			}
		}
		int? TargetType_InheritedWeaponQty = default(int?);
		int? TargetType_UnspecifiedWeaponQty = default(int?);
		if ((object)SubjectType != typeof(Side))
		{
			WRA_WeaponQty_AnyTargetType(this, theWeapon.ParentScen, theWeapon, theTargetType, FindInheritedValuesOnly: true, ref TargetType_InheritedWeaponQty, ref TargetType_UnspecifiedWeaponQty);
		}
		else if (!WRA_IsTopNodeTargetType(ref theTargetType))
		{
			_WRA_WeaponTargetType selectedNodeTargetType = WRA_DetermineTargetType_Unspecified(ref theTargetType);
			TargetType_UnspecifiedWeaponQty = WRA_WeaponQty_CurrentTargetType(this, theWeapon.ParentScen, theWeapon, selectedNodeTargetType);
		}
		switch (theTargetType)
		{
		case _WRA_WeaponTargetType.Subsurface_Contact_Unknown_Type:
		case _WRA_WeaponTargetType.Submarine_Unspecified:
			if ((object)SubjectType != typeof(Side))
			{
				if (Information.IsNothing((object)weaponQty))
				{
					if (Information.IsNothing((object)TargetType_InheritedWeaponQty) && Information.IsNothing((object)TargetType_UnspecifiedWeaponQty))
					{
						theComboBoxDataSource_WeaponQty.Rows.Add(0, "Inherited");
					}
					else if (Information.IsNothing((object)TargetType_InheritedWeaponQty))
					{
						theComboBoxDataSource_WeaponQty.Rows.Add(0, "Inherited, " + WRA_WeaponQtyString(TargetType_UnspecifiedWeaponQty, !Information.IsNothing((object)TargetType_UnspecifiedWeaponQty)));
					}
					else if (!Information.IsNothing((object)TargetType_InheritedWeaponQty))
					{
						theComboBoxDataSource_WeaponQty.Rows.Add(0, "Inherited, " + WRA_WeaponQtyString(TargetType_InheritedWeaponQty, !Information.IsNothing((object)TargetType_UnspecifiedWeaponQty)));
					}
					else
					{
						theComboBoxDataSource_WeaponQty.Rows.Add(0, "Inherited, " + WRA_WeaponQtyString(weaponQty, !Information.IsNothing((object)TargetType_UnspecifiedWeaponQty)));
					}
				}
				else if (Information.IsNothing((object)TargetType_InheritedWeaponQty) && Information.IsNothing((object)TargetType_UnspecifiedWeaponQty))
				{
					theComboBoxDataSource_WeaponQty.Rows.Add(0, "Inherited");
				}
				else
				{
					theComboBoxDataSource_WeaponQty.Rows.Add(0, "Inherited, " + WRA_WeaponQtyString(TargetType_InheritedWeaponQty, !Information.IsNothing((object)TargetType_UnspecifiedWeaponQty)));
				}
			}
			if (!Information.IsNothing((object)weaponQty))
			{
				if (Information.IsNothing((object)TargetType_InheritedWeaponQty) && Information.IsNothing((object)TargetType_UnspecifiedWeaponQty) && (object)SubjectType != typeof(Side))
				{
					theComboBoxDataSource_WeaponQty.Rows.Add(1, "System default");
				}
				else
				{
					theComboBoxDataSource_WeaponQty.Rows.Add(1, "System default, " + WRA_WeaponQtyString(weaponQty, TargetTypeUnspecified: false));
				}
			}
			else if ((object)SubjectType == typeof(Side) && theTargetType != _WRA_WeaponTargetType.Submarine_Unspecified && theTargetType != _WRA_WeaponTargetType.Subsurface_Contact_Unknown_Type)
			{
				if (Information.IsNothing((object)TargetType_InheritedWeaponQty) && Information.IsNothing((object)TargetType_UnspecifiedWeaponQty))
				{
					theComboBoxDataSource_WeaponQty.Rows.Add(1, "Not Configured");
				}
				else if (Information.IsNothing((object)TargetType_InheritedWeaponQty))
				{
					theComboBoxDataSource_WeaponQty.Rows.Add(1, "Not Configured, " + WRA_WeaponQtyString(TargetType_UnspecifiedWeaponQty, !Information.IsNothing((object)TargetType_UnspecifiedWeaponQty)));
				}
				else
				{
					theComboBoxDataSource_WeaponQty.Rows.Add(1, "Not Configured, " + WRA_WeaponQtyString(weaponQty, !Information.IsNothing((object)TargetType_UnspecifiedWeaponQty)));
				}
			}
			theComboBoxDataSource_WeaponQty.Rows.Add(2, "Do not use weapon against this target type");
			theComboBoxDataSource_WeaponQty.Rows.Add(3, "1 rnd");
			theComboBoxDataSource_WeaponQty.Rows.Add(4, "2 rnds");
			theComboBoxDataSource_WeaponQty.Rows.Add(5, "3 rnds");
			theComboBoxDataSource_WeaponQty.Rows.Add(6, "4 rnds");
			theComboBoxDataSource_WeaponQty.Rows.Add(7, "Use all weapons against target");
			if (theComboBoxValue == WeaponQty_To_WeaponsPerSalvoSelection(ref theTargetType, -100))
			{
				theComboBoxDataSource_WeaponQty.Rows.Add(8, "Various settings");
			}
			break;
		case _WRA_WeaponTargetType.Land_Structure_Soft_Unspecified:
		case _WRA_WeaponTargetType.Land_Structure_Soft_Building_Surface:
		case _WRA_WeaponTargetType.Land_Structure_Soft_Building_Reveted:
		case _WRA_WeaponTargetType.Land_Structure_Soft_Building_Bunker:
		case _WRA_WeaponTargetType.Land_Structure_Soft_Building_Underground:
		case _WRA_WeaponTargetType.Land_Structure_Soft_Structure_Open:
		case _WRA_WeaponTargetType.Land_Structure_Soft_Structure_Reveted:
		case _WRA_WeaponTargetType.Land_Structure_Soft_Aerostat_Moring:
		case _WRA_WeaponTargetType.Land_Structure_Hardened_Unspecified:
		case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Surface:
		case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Reveted:
		case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Bunker:
		case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Underground:
		case _WRA_WeaponTargetType.Land_Structure_Hardened_Structure_Open:
		case _WRA_WeaponTargetType.Land_Structure_Hardened_Structure_Reveted:
		case _WRA_WeaponTargetType.Runway_Facility_Unspecified:
		case _WRA_WeaponTargetType.Runway:
		case _WRA_WeaponTargetType.Runway_Grade_Taxiway:
		case _WRA_WeaponTargetType.Runway_Access_Point:
		case _WRA_WeaponTargetType.Emitter_Unspecified:
		case _WRA_WeaponTargetType.Emitter_Radar:
		case _WRA_WeaponTargetType.Emitter_Jammer:
		case _WRA_WeaponTargetType.Mobile_Target_Soft_Unspecified:
		case _WRA_WeaponTargetType.Mobile_Target_Soft_Mobile_Vehicle:
		case _WRA_WeaponTargetType.Mobile_Target_Soft_Mobile_Personnel:
		case _WRA_WeaponTargetType.Mobile_Target_Hardened_Unspecified:
		case _WRA_WeaponTargetType.Mobile_Target_Hardened_Mobile_Vehicle:
		case _WRA_WeaponTargetType.Underwater_Structure:
		case _WRA_WeaponTargetType.Air_Base_Single_Unit_Airfield:
			if ((object)SubjectType != typeof(Side))
			{
				if (weaponQty.HasValue)
				{
					if (Information.IsNothing((object)TargetType_InheritedWeaponQty) && Information.IsNothing((object)TargetType_UnspecifiedWeaponQty))
					{
						theComboBoxDataSource_WeaponQty.Rows.Add(0, "Inherited");
					}
					else
					{
						theComboBoxDataSource_WeaponQty.Rows.Add(0, "Inherited, " + WRA_WeaponQtyString(TargetType_InheritedWeaponQty, !Information.IsNothing((object)TargetType_UnspecifiedWeaponQty)));
					}
				}
				else if (!TargetType_InheritedWeaponQty.HasValue && !TargetType_UnspecifiedWeaponQty.HasValue)
				{
					theComboBoxDataSource_WeaponQty.Rows.Add(0, "Inherited");
				}
				else if (TargetType_InheritedWeaponQty.HasValue)
				{
					if (!Information.IsNothing((object)TargetType_InheritedWeaponQty))
					{
						theComboBoxDataSource_WeaponQty.Rows.Add(0, "Inherited, " + WRA_WeaponQtyString(TargetType_InheritedWeaponQty, !Information.IsNothing((object)TargetType_UnspecifiedWeaponQty)));
					}
					else
					{
						theComboBoxDataSource_WeaponQty.Rows.Add(0, "Inherited, " + WRA_WeaponQtyString(weaponQty, !Information.IsNothing((object)TargetType_UnspecifiedWeaponQty)));
					}
				}
				else
				{
					theComboBoxDataSource_WeaponQty.Rows.Add(0, "Inherited, " + WRA_WeaponQtyString(TargetType_UnspecifiedWeaponQty, TargetType_UnspecifiedWeaponQty.HasValue));
				}
			}
			if (Information.IsNothing((object)weaponQty))
			{
				if ((object)SubjectType == typeof(Side))
				{
					switch (theTargetType)
					{
					default:
						if (!TargetType_InheritedWeaponQty.HasValue && Information.IsNothing((object)TargetType_UnspecifiedWeaponQty))
						{
							theComboBoxDataSource_WeaponQty.Rows.Add(1, "Not Configured");
						}
						else if (TargetType_InheritedWeaponQty.HasValue)
						{
							theComboBoxDataSource_WeaponQty.Rows.Add(1, "Not Configured, " + WRA_WeaponQtyString(weaponQty, !Information.IsNothing((object)TargetType_UnspecifiedWeaponQty)));
						}
						else
						{
							theComboBoxDataSource_WeaponQty.Rows.Add(1, "Not Configured, " + WRA_WeaponQtyString(TargetType_UnspecifiedWeaponQty, !Information.IsNothing((object)TargetType_UnspecifiedWeaponQty)));
						}
						break;
					case _WRA_WeaponTargetType.Land_Structure_Soft_Unspecified:
					case _WRA_WeaponTargetType.Land_Structure_Hardened_Unspecified:
					case _WRA_WeaponTargetType.Runway_Facility_Unspecified:
					case _WRA_WeaponTargetType.Emitter_Unspecified:
					case _WRA_WeaponTargetType.Mobile_Target_Soft_Unspecified:
					case _WRA_WeaponTargetType.Mobile_Target_Hardened_Unspecified:
					case _WRA_WeaponTargetType.Underwater_Structure:
					case _WRA_WeaponTargetType.Air_Base_Single_Unit_Airfield:
						break;
					}
				}
			}
			else if (Information.IsNothing((object)TargetType_InheritedWeaponQty) && Information.IsNothing((object)TargetType_UnspecifiedWeaponQty) && (object)SubjectType != typeof(Side))
			{
				theComboBoxDataSource_WeaponQty.Rows.Add(1, "System default");
			}
			else
			{
				theComboBoxDataSource_WeaponQty.Rows.Add(1, "System default, " + WRA_WeaponQtyString(weaponQty, TargetTypeUnspecified: false));
			}
			theComboBoxDataSource_WeaponQty.Rows.Add(2, "Do not use weapon against this target type");
			theComboBoxDataSource_WeaponQty.Rows.Add(3, "Use target's Missile Defence value");
			theComboBoxDataSource_WeaponQty.Rows.Add(4, "Use twice as many weapons as the target's Missile Defence value");
			theComboBoxDataSource_WeaponQty.Rows.Add(5, "Use four times the target's Missile Defence value");
			theComboBoxDataSource_WeaponQty.Rows.Add(6, "Use 1/2 the target's Missile Defence value");
			theComboBoxDataSource_WeaponQty.Rows.Add(7, "Use 1/4 the target's Missile Defence value");
			theComboBoxDataSource_WeaponQty.Rows.Add(8, "1 rnd");
			theComboBoxDataSource_WeaponQty.Rows.Add(9, "2 rnds");
			theComboBoxDataSource_WeaponQty.Rows.Add(10, "3 rnds");
			theComboBoxDataSource_WeaponQty.Rows.Add(11, "4 rnds");
			theComboBoxDataSource_WeaponQty.Rows.Add(12, "5 rnds");
			theComboBoxDataSource_WeaponQty.Rows.Add(13, "6 rnds");
			theComboBoxDataSource_WeaponQty.Rows.Add(14, "7 rnds");
			theComboBoxDataSource_WeaponQty.Rows.Add(15, "8 rnds");
			theComboBoxDataSource_WeaponQty.Rows.Add(16, "Use all weapons against target");
			if (theComboBoxValue == WeaponQty_To_WeaponsPerSalvoSelection(ref theTargetType, -100))
			{
				theComboBoxDataSource_WeaponQty.Rows.Add(17, "Various settings");
			}
			break;
		case _WRA_WeaponTargetType.Surface_Contact_Unknown_Type:
		case _WRA_WeaponTargetType.Land_Contact_Unknown_Type:
			if ((object)SubjectType != typeof(Side))
			{
				if (Information.IsNothing((object)weaponQty))
				{
					if (Information.IsNothing((object)TargetType_InheritedWeaponQty) && Information.IsNothing((object)TargetType_UnspecifiedWeaponQty))
					{
						theComboBoxDataSource_WeaponQty.Rows.Add(0, "Inherited");
					}
					else if (Information.IsNothing((object)TargetType_InheritedWeaponQty))
					{
						theComboBoxDataSource_WeaponQty.Rows.Add(0, "Inherited, " + WRA_WeaponQtyString(TargetType_UnspecifiedWeaponQty, !Information.IsNothing((object)TargetType_UnspecifiedWeaponQty)));
					}
					else if (!Information.IsNothing((object)TargetType_InheritedWeaponQty))
					{
						theComboBoxDataSource_WeaponQty.Rows.Add(0, "Inherited, " + WRA_WeaponQtyString(TargetType_InheritedWeaponQty, !Information.IsNothing((object)TargetType_UnspecifiedWeaponQty)));
					}
					else
					{
						theComboBoxDataSource_WeaponQty.Rows.Add(0, "Inherited, " + WRA_WeaponQtyString(weaponQty, !Information.IsNothing((object)TargetType_UnspecifiedWeaponQty)));
					}
				}
				else if (Information.IsNothing((object)TargetType_InheritedWeaponQty) && Information.IsNothing((object)TargetType_UnspecifiedWeaponQty))
				{
					theComboBoxDataSource_WeaponQty.Rows.Add(0, "Inherited");
				}
				else
				{
					theComboBoxDataSource_WeaponQty.Rows.Add(0, "Inherited, " + WRA_WeaponQtyString(TargetType_InheritedWeaponQty, !Information.IsNothing((object)TargetType_UnspecifiedWeaponQty)));
				}
			}
			if (!Information.IsNothing((object)weaponQty))
			{
				if (Information.IsNothing((object)TargetType_InheritedWeaponQty) && Information.IsNothing((object)TargetType_UnspecifiedWeaponQty) && (object)SubjectType != typeof(Side))
				{
					theComboBoxDataSource_WeaponQty.Rows.Add(1, "System default");
				}
				else
				{
					theComboBoxDataSource_WeaponQty.Rows.Add(1, "System default, " + WRA_WeaponQtyString(weaponQty, TargetTypeUnspecified: false));
				}
			}
			else if ((object)SubjectType == typeof(Side))
			{
				if (theTargetType != _WRA_WeaponTargetType.Surface_Contact_Unknown_Type && theTargetType != _WRA_WeaponTargetType.Land_Contact_Unknown_Type)
				{
					if (Information.IsNothing((object)TargetType_InheritedWeaponQty) && Information.IsNothing((object)TargetType_UnspecifiedWeaponQty))
					{
						theComboBoxDataSource_WeaponQty.Rows.Add(1, "Not Configured");
					}
					else if (!Information.IsNothing((object)TargetType_InheritedWeaponQty))
					{
						theComboBoxDataSource_WeaponQty.Rows.Add(1, "Not Configured, " + WRA_WeaponQtyString(weaponQty, !Information.IsNothing((object)TargetType_UnspecifiedWeaponQty)));
					}
					else
					{
						theComboBoxDataSource_WeaponQty.Rows.Add(1, "Not Configured, " + WRA_WeaponQtyString(TargetType_UnspecifiedWeaponQty, !Information.IsNothing((object)TargetType_UnspecifiedWeaponQty)));
					}
				}
				else if (Information.IsNothing((object)TargetType_InheritedWeaponQty) && Information.IsNothing((object)TargetType_UnspecifiedWeaponQty) && (object)SubjectType != typeof(Side))
				{
					theComboBoxDataSource_WeaponQty.Rows.Add(1, "System default");
				}
				else
				{
					theComboBoxDataSource_WeaponQty.Rows.Add(1, "System default, " + WRA_WeaponQtyString(weaponQty, TargetTypeUnspecified: false));
				}
			}
			theComboBoxDataSource_WeaponQty.Rows.Add(2, "Do not use weapon against this target type");
			theComboBoxDataSource_WeaponQty.Rows.Add(3, "1 rnd");
			theComboBoxDataSource_WeaponQty.Rows.Add(4, "2 rnds");
			theComboBoxDataSource_WeaponQty.Rows.Add(5, "3 rnds");
			theComboBoxDataSource_WeaponQty.Rows.Add(6, "4 rnds");
			theComboBoxDataSource_WeaponQty.Rows.Add(7, "5 rnds");
			theComboBoxDataSource_WeaponQty.Rows.Add(8, "6 rnds");
			theComboBoxDataSource_WeaponQty.Rows.Add(9, "7 rnds");
			theComboBoxDataSource_WeaponQty.Rows.Add(10, "8 rnds");
			theComboBoxDataSource_WeaponQty.Rows.Add(11, "Use all weapons against target");
			if (theComboBoxValue == WeaponQty_To_WeaponsPerSalvoSelection(ref theTargetType, -100))
			{
				theComboBoxDataSource_WeaponQty.Rows.Add(12, "Various settings");
			}
			break;
		case _WRA_WeaponTargetType.Satellite_Unspecified:
			if ((object)SubjectType != typeof(Side))
			{
				if (Information.IsNothing((object)weaponQty))
				{
					if (Information.IsNothing((object)TargetType_InheritedWeaponQty) && Information.IsNothing((object)TargetType_UnspecifiedWeaponQty))
					{
						theComboBoxDataSource_WeaponQty.Rows.Add(0, "Inherited");
					}
					else if (!Information.IsNothing((object)TargetType_InheritedWeaponQty))
					{
						if (Information.IsNothing((object)TargetType_InheritedWeaponQty))
						{
							theComboBoxDataSource_WeaponQty.Rows.Add(0, "Inherited, " + WRA_WeaponQtyString(weaponQty, !Information.IsNothing((object)TargetType_UnspecifiedWeaponQty)));
						}
						else
						{
							theComboBoxDataSource_WeaponQty.Rows.Add(0, "Inherited, " + WRA_WeaponQtyString(TargetType_InheritedWeaponQty, !Information.IsNothing((object)TargetType_UnspecifiedWeaponQty)));
						}
					}
					else
					{
						theComboBoxDataSource_WeaponQty.Rows.Add(0, "Inherited, " + WRA_WeaponQtyString(TargetType_UnspecifiedWeaponQty, !Information.IsNothing((object)TargetType_UnspecifiedWeaponQty)));
					}
				}
				else if (Information.IsNothing((object)TargetType_InheritedWeaponQty) && Information.IsNothing((object)TargetType_UnspecifiedWeaponQty))
				{
					theComboBoxDataSource_WeaponQty.Rows.Add(0, "Inherited");
				}
				else
				{
					theComboBoxDataSource_WeaponQty.Rows.Add(0, "Inherited, " + WRA_WeaponQtyString(TargetType_InheritedWeaponQty, !Information.IsNothing((object)TargetType_UnspecifiedWeaponQty)));
				}
			}
			if (!Information.IsNothing((object)weaponQty))
			{
				if (Information.IsNothing((object)TargetType_InheritedWeaponQty) && Information.IsNothing((object)TargetType_UnspecifiedWeaponQty) && (object)SubjectType != typeof(Side))
				{
					theComboBoxDataSource_WeaponQty.Rows.Add(1, "System default");
				}
				else
				{
					theComboBoxDataSource_WeaponQty.Rows.Add(1, "System default, " + WRA_WeaponQtyString(weaponQty, TargetTypeUnspecified: false));
				}
			}
			else if ((object)SubjectType == typeof(Side) && theTargetType != _WRA_WeaponTargetType.Satellite_Unspecified)
			{
				if (Information.IsNothing((object)TargetType_InheritedWeaponQty) && Information.IsNothing((object)TargetType_UnspecifiedWeaponQty))
				{
					theComboBoxDataSource_WeaponQty.Rows.Add(1, "Not Configured");
				}
				else if (!Information.IsNothing((object)TargetType_InheritedWeaponQty))
				{
					theComboBoxDataSource_WeaponQty.Rows.Add(1, "Not Configured, " + WRA_WeaponQtyString(weaponQty, !Information.IsNothing((object)TargetType_UnspecifiedWeaponQty)));
				}
				else
				{
					theComboBoxDataSource_WeaponQty.Rows.Add(1, "Not Configured, " + WRA_WeaponQtyString(TargetType_UnspecifiedWeaponQty, !Information.IsNothing((object)TargetType_UnspecifiedWeaponQty)));
				}
			}
			theComboBoxDataSource_WeaponQty.Rows.Add(2, "Do not use weapon against this target type");
			theComboBoxDataSource_WeaponQty.Rows.Add(3, "1 rnd");
			theComboBoxDataSource_WeaponQty.Rows.Add(4, "2 rnds");
			theComboBoxDataSource_WeaponQty.Rows.Add(5, "Use all weapons against target");
			if (theComboBoxValue == WeaponQty_To_WeaponsPerSalvoSelection(ref theTargetType, -100))
			{
				theComboBoxDataSource_WeaponQty.Rows.Add(6, "Various settings");
			}
			break;
		case _WRA_WeaponTargetType.Ship_Unspecified:
		case _WRA_WeaponTargetType.Ship_Carrier_0_25000_tons:
		case _WRA_WeaponTargetType.Ship_Carrier_25001_45000_tons:
		case _WRA_WeaponTargetType.Ship_Carrier_45001_95000_tons:
		case _WRA_WeaponTargetType.Ship_Carrier_95000_tons:
		case _WRA_WeaponTargetType.Ship_Surface_Combatant_0_500_tons:
		case _WRA_WeaponTargetType.Ship_Surface_Combatant_501_1500_tons:
		case _WRA_WeaponTargetType.Ship_Surface_Combatant_1501_5000_tons:
		case _WRA_WeaponTargetType.Ship_Surface_Combatant_5001_10000_tons:
		case _WRA_WeaponTargetType.Ship_Surface_Combatant_10001_25000_tons:
		case _WRA_WeaponTargetType.Ship_Surface_Combatant_25001_45000_tons:
		case _WRA_WeaponTargetType.Ship_Surface_Combatant_45001_95000_tons:
		case _WRA_WeaponTargetType.Ship_Surface_Combatant_95000_tons:
		case _WRA_WeaponTargetType.Ship_Amphibious_0_500_tons:
		case _WRA_WeaponTargetType.Ship_Amphibious_501_1500_tons:
		case _WRA_WeaponTargetType.Ship_Amphibious_1501_5000_tons:
		case _WRA_WeaponTargetType.Ship_Amphibious_5001_10000_tons:
		case _WRA_WeaponTargetType.Ship_Amphibious_10001_25000_tons:
		case _WRA_WeaponTargetType.Ship_Amphibious_25001_45000_tons:
		case _WRA_WeaponTargetType.Ship_Amphibious_45001_95000_tons:
		case _WRA_WeaponTargetType.Ship_Amphibious_95000_tons:
		case _WRA_WeaponTargetType.Ship_Auxiliary_0_500_tons:
		case _WRA_WeaponTargetType.Ship_Auxiliary_501_1500_tons:
		case _WRA_WeaponTargetType.Ship_Auxiliary_1501_5000_tons:
		case _WRA_WeaponTargetType.Ship_Auxiliary_5001_10000_tons:
		case _WRA_WeaponTargetType.Ship_Auxiliary_10001_25000_tons:
		case _WRA_WeaponTargetType.Ship_Auxiliary_25001_45000_tons:
		case _WRA_WeaponTargetType.Ship_Auxiliary_45001_95000_tons:
		case _WRA_WeaponTargetType.Ship_Auxiliary_95000_tons:
		case _WRA_WeaponTargetType.Ship_Merchant_Civilian_0_500_tons:
		case _WRA_WeaponTargetType.Ship_Merchant_Civilian_501_1500_tons:
		case _WRA_WeaponTargetType.Ship_Merchant_Civilian_1501_5000_tons:
		case _WRA_WeaponTargetType.Ship_Merchant_Civilian_5001_10000_tons:
		case _WRA_WeaponTargetType.Ship_Merchant_Civilian_10001_25000_tons:
		case _WRA_WeaponTargetType.Ship_Merchant_Civilian_25001_45000_tons:
		case _WRA_WeaponTargetType.Ship_Merchant_Civilian_45001_95000_tons:
		case _WRA_WeaponTargetType.Ship_Merchant_Civilian_95000_tons:
		case _WRA_WeaponTargetType.Submarine_Surfaced:
			if ((object)SubjectType != typeof(Side))
			{
				if (!Information.IsNothing((object)weaponQty))
				{
					if (Information.IsNothing((object)TargetType_InheritedWeaponQty) && Information.IsNothing((object)TargetType_UnspecifiedWeaponQty))
					{
						theComboBoxDataSource_WeaponQty.Rows.Add(0, "Inherited");
					}
					else
					{
						theComboBoxDataSource_WeaponQty.Rows.Add(0, "Inherited, " + WRA_WeaponQtyString(TargetType_InheritedWeaponQty, !Information.IsNothing((object)TargetType_UnspecifiedWeaponQty)));
					}
				}
				else if (Information.IsNothing((object)TargetType_InheritedWeaponQty) && Information.IsNothing((object)TargetType_UnspecifiedWeaponQty))
				{
					theComboBoxDataSource_WeaponQty.Rows.Add(0, "Inherited");
				}
				else if (Information.IsNothing((object)TargetType_InheritedWeaponQty))
				{
					theComboBoxDataSource_WeaponQty.Rows.Add(0, "Inherited, " + WRA_WeaponQtyString(TargetType_UnspecifiedWeaponQty, !Information.IsNothing((object)TargetType_UnspecifiedWeaponQty)));
				}
				else if (!Information.IsNothing((object)TargetType_InheritedWeaponQty))
				{
					theComboBoxDataSource_WeaponQty.Rows.Add(0, "Inherited, " + WRA_WeaponQtyString(TargetType_InheritedWeaponQty, !Information.IsNothing((object)TargetType_UnspecifiedWeaponQty)));
				}
				else
				{
					theComboBoxDataSource_WeaponQty.Rows.Add(0, "Inherited, " + WRA_WeaponQtyString(weaponQty, !Information.IsNothing((object)TargetType_UnspecifiedWeaponQty)));
				}
			}
			if (!Information.IsNothing((object)weaponQty))
			{
				if (Information.IsNothing((object)TargetType_InheritedWeaponQty) && Information.IsNothing((object)TargetType_UnspecifiedWeaponQty) && (object)SubjectType != typeof(Side))
				{
					theComboBoxDataSource_WeaponQty.Rows.Add(1, "System default");
				}
				else
				{
					theComboBoxDataSource_WeaponQty.Rows.Add(1, "System default, " + WRA_WeaponQtyString(weaponQty, TargetTypeUnspecified: false));
				}
			}
			else if ((object)SubjectType == typeof(Side) && theTargetType != _WRA_WeaponTargetType.Ship_Unspecified)
			{
				if (Information.IsNothing((object)TargetType_InheritedWeaponQty) && Information.IsNothing((object)TargetType_UnspecifiedWeaponQty))
				{
					theComboBoxDataSource_WeaponQty.Rows.Add(1, "Not Configured");
				}
				else if (!Information.IsNothing((object)TargetType_InheritedWeaponQty))
				{
					theComboBoxDataSource_WeaponQty.Rows.Add(1, "Not Configured, " + WRA_WeaponQtyString(weaponQty, !Information.IsNothing((object)TargetType_UnspecifiedWeaponQty)));
				}
				else
				{
					theComboBoxDataSource_WeaponQty.Rows.Add(1, "Not Configured, " + WRA_WeaponQtyString(TargetType_UnspecifiedWeaponQty, !Information.IsNothing((object)TargetType_UnspecifiedWeaponQty)));
				}
			}
			theComboBoxDataSource_WeaponQty.Rows.Add(2, "Do not use weapon against this target type");
			theComboBoxDataSource_WeaponQty.Rows.Add(3, "Use target's Missile Defence value");
			theComboBoxDataSource_WeaponQty.Rows.Add(4, "Use twice as many weapons as the target's Missile Defence value");
			theComboBoxDataSource_WeaponQty.Rows.Add(5, "Use four times the target's Missile Defence value");
			theComboBoxDataSource_WeaponQty.Rows.Add(6, "Use 1/2 the target's Missile Defence value");
			theComboBoxDataSource_WeaponQty.Rows.Add(7, "Use 1/4 the target's Missile Defence value");
			theComboBoxDataSource_WeaponQty.Rows.Add(8, "1 rnd");
			theComboBoxDataSource_WeaponQty.Rows.Add(9, "2 rnds");
			theComboBoxDataSource_WeaponQty.Rows.Add(10, "3 rnds");
			theComboBoxDataSource_WeaponQty.Rows.Add(11, "4 rnds");
			theComboBoxDataSource_WeaponQty.Rows.Add(12, "5 rnds");
			theComboBoxDataSource_WeaponQty.Rows.Add(13, "6 rnds");
			theComboBoxDataSource_WeaponQty.Rows.Add(14, "7 rnds");
			theComboBoxDataSource_WeaponQty.Rows.Add(15, "8 rnds");
			theComboBoxDataSource_WeaponQty.Rows.Add(16, "Use all weapons against target");
			if (theComboBoxValue == WeaponQty_To_WeaponsPerSalvoSelection(ref theTargetType, -100))
			{
				theComboBoxDataSource_WeaponQty.Rows.Add(17, "Various settings");
			}
			break;
		default:
			theComboBoxDataSource_WeaponQty.Rows.Add(0, "Not implemented");
			break;
		case _WRA_WeaponTargetType.Air_Contact_Unknown_Type:
		case _WRA_WeaponTargetType.Aircraft_Unspecified:
		case _WRA_WeaponTargetType.Aircraft_5th_Generation:
		case _WRA_WeaponTargetType.Aircraft_4th_Generation:
		case _WRA_WeaponTargetType.Aircraft_3rd_Generation:
		case _WRA_WeaponTargetType.Aircraft_Less_Capable:
		case _WRA_WeaponTargetType.Aircraft_High_Perf_Bombers:
		case _WRA_WeaponTargetType.Aircraft_Medium_Perf_Bombers:
		case _WRA_WeaponTargetType.Aircraft_Low_Perf_Bombers:
		case _WRA_WeaponTargetType.Aircraft_High_Perf_Recon_EW:
		case _WRA_WeaponTargetType.Aircraft_Medium_Perf_Recon_EW:
		case _WRA_WeaponTargetType.Aircraft_Low_Perf_Recon_EW:
		case _WRA_WeaponTargetType.Aircraft_AEW:
		case _WRA_WeaponTargetType.Aircraft_Class1_UAS:
		case _WRA_WeaponTargetType.Aircraft_Tanker:
		case _WRA_WeaponTargetType.Aircraft_Class2_UAS:
		case _WRA_WeaponTargetType.Helicopter_Unspecified:
		case _WRA_WeaponTargetType.Guided_Weapon_Unspecified:
		case _WRA_WeaponTargetType.Guided_Weapon_Supersonic_Sea_Skimming:
		case _WRA_WeaponTargetType.Guided_Weapon_Subsonic_Sea_Skimming:
		case _WRA_WeaponTargetType.Guided_Weapon_Supersonic:
		case _WRA_WeaponTargetType.Guided_Weapon_Subsonic:
		case _WRA_WeaponTargetType.Guided_Weapon_Ballistic:
			if ((object)SubjectType != typeof(Side))
			{
				if (Information.IsNothing((object)weaponQty))
				{
					if (Information.IsNothing((object)TargetType_InheritedWeaponQty) && Information.IsNothing((object)TargetType_UnspecifiedWeaponQty))
					{
						theComboBoxDataSource_WeaponQty.Rows.Add(0, "Inherited");
					}
					else if (Information.IsNothing((object)TargetType_InheritedWeaponQty))
					{
						theComboBoxDataSource_WeaponQty.Rows.Add(0, "Inherited, " + WRA_WeaponQtyString(TargetType_UnspecifiedWeaponQty, !Information.IsNothing((object)TargetType_UnspecifiedWeaponQty)));
					}
					else if (!Information.IsNothing((object)TargetType_InheritedWeaponQty))
					{
						theComboBoxDataSource_WeaponQty.Rows.Add(0, "Inherited, " + WRA_WeaponQtyString(TargetType_InheritedWeaponQty, !Information.IsNothing((object)TargetType_UnspecifiedWeaponQty)));
					}
					else
					{
						theComboBoxDataSource_WeaponQty.Rows.Add(0, "Inherited, " + WRA_WeaponQtyString(weaponQty, !Information.IsNothing((object)TargetType_UnspecifiedWeaponQty)));
					}
				}
				else if (Information.IsNothing((object)TargetType_InheritedWeaponQty) && Information.IsNothing((object)TargetType_UnspecifiedWeaponQty))
				{
					theComboBoxDataSource_WeaponQty.Rows.Add(0, "Inherited");
				}
				else
				{
					theComboBoxDataSource_WeaponQty.Rows.Add(0, "Inherited, " + WRA_WeaponQtyString(TargetType_InheritedWeaponQty, !Information.IsNothing((object)TargetType_UnspecifiedWeaponQty)));
				}
			}
			if (!Information.IsNothing((object)weaponQty))
			{
				if (Information.IsNothing((object)TargetType_InheritedWeaponQty) && Information.IsNothing((object)TargetType_UnspecifiedWeaponQty) && (object)SubjectType != typeof(Side))
				{
					theComboBoxDataSource_WeaponQty.Rows.Add(1, "System default");
				}
				else
				{
					theComboBoxDataSource_WeaponQty.Rows.Add(1, "System default, " + WRA_WeaponQtyString(weaponQty, TargetTypeUnspecified: false));
				}
			}
			else if ((object)SubjectType == typeof(Side) && theTargetType != _WRA_WeaponTargetType.Air_Contact_Unknown_Type && theTargetType != _WRA_WeaponTargetType.Aircraft_Unspecified)
			{
				if (Information.IsNothing((object)TargetType_InheritedWeaponQty) && Information.IsNothing((object)TargetType_UnspecifiedWeaponQty))
				{
					theComboBoxDataSource_WeaponQty.Rows.Add(1, "Not Configured");
				}
				else if (Information.IsNothing((object)TargetType_InheritedWeaponQty))
				{
					theComboBoxDataSource_WeaponQty.Rows.Add(1, "Not Configured, " + WRA_WeaponQtyString(TargetType_UnspecifiedWeaponQty, !Information.IsNothing((object)TargetType_UnspecifiedWeaponQty)));
				}
				else
				{
					theComboBoxDataSource_WeaponQty.Rows.Add(1, "Not Configured, " + WRA_WeaponQtyString(weaponQty, !Information.IsNothing((object)TargetType_UnspecifiedWeaponQty)));
				}
			}
			theComboBoxDataSource_WeaponQty.Rows.Add(2, "Do not use weapon against this target type");
			theComboBoxDataSource_WeaponQty.Rows.Add(3, "1 rnd (easy target, or IR-guided weapon)");
			theComboBoxDataSource_WeaponQty.Rows.Add(4, "2 rnds (non-cooperative target)");
			theComboBoxDataSource_WeaponQty.Rows.Add(5, "3 rnds (extremely difficult target)");
			theComboBoxDataSource_WeaponQty.Rows.Add(6, "4 rnds (extremely difficult target, rarely used)");
			theComboBoxDataSource_WeaponQty.Rows.Add(7, "Use all weapons against target");
			if (theComboBoxValue == WeaponQty_To_WeaponsPerSalvoSelection(ref theTargetType, -100))
			{
				theComboBoxDataSource_WeaponQty.Rows.Add(8, "Various settings");
			}
			break;
		}
	}

	public void ComboBoxDataSource_ShooterQty(ref DataTable theComboBoxDataSource_ShooterQty, _WRA_WeaponTargetType theTargetType, ref Weapon theWeapon, int theComboBoxValue)
	{
		if (!theComboBoxDataSource_ShooterQty.Columns.Contains("ID"))
		{
			theComboBoxDataSource_ShooterQty.Columns.Add("ID", typeof(int));
		}
		if (!theComboBoxDataSource_ShooterQty.Columns.Contains("Description"))
		{
			theComboBoxDataSource_ShooterQty.Columns.Add("Description", typeof(string));
		}
		int? shooterQty = default(int?);
		foreach (KeyValuePair<int, WRA_Weapon> item in theWeapon.Doctrine.WRA)
		{
			_ = item.Key;
			WRA_FiringDoctrineEntry value = null;
			if (item.Value.WRA_WeaponTargets.TryGetValue((int)theTargetType, ref value))
			{
				shooterQty = value.ShooterQty;
			}
		}
		int? TargetType_InheritedShooterQty = default(int?);
		int? TargetType_UnspecifiedShooterQty = default(int?);
		if ((object)SubjectType != typeof(Side))
		{
			WRA_ShooterQty_AnyTargetType(this, theWeapon.ParentScen, theWeapon, theTargetType, FindInheritedValuesOnly: true, ref TargetType_InheritedShooterQty, ref TargetType_UnspecifiedShooterQty);
		}
		else if (!WRA_IsTopNodeTargetType(ref theTargetType))
		{
			_WRA_WeaponTargetType selectedNodeTargetType = WRA_DetermineTargetType_Unspecified(ref theTargetType);
			TargetType_UnspecifiedShooterQty = WRA_ShooterQty_CurrentTargetType(this, theWeapon.ParentScen, theWeapon, selectedNodeTargetType);
		}
		if ((object)SubjectType != typeof(Side))
		{
			if (Information.IsNothing((object)shooterQty))
			{
				if (Information.IsNothing((object)TargetType_InheritedShooterQty) && Information.IsNothing((object)TargetType_UnspecifiedShooterQty))
				{
					theComboBoxDataSource_ShooterQty.Rows.Add(0, "Inherited");
				}
				else if (!Information.IsNothing((object)TargetType_InheritedShooterQty))
				{
					if (Information.IsNothing((object)TargetType_InheritedShooterQty))
					{
						theComboBoxDataSource_ShooterQty.Rows.Add(0, "Inherited, " + WRA_ShooterQtyString(shooterQty, !Information.IsNothing((object)TargetType_UnspecifiedShooterQty)));
					}
					else
					{
						theComboBoxDataSource_ShooterQty.Rows.Add(0, "Inherited, " + WRA_ShooterQtyString(TargetType_InheritedShooterQty, !Information.IsNothing((object)TargetType_UnspecifiedShooterQty)));
					}
				}
				else
				{
					theComboBoxDataSource_ShooterQty.Rows.Add(0, "Inherited, " + WRA_ShooterQtyString(TargetType_UnspecifiedShooterQty, !Information.IsNothing((object)TargetType_UnspecifiedShooterQty)));
				}
			}
			else if (Information.IsNothing((object)TargetType_InheritedShooterQty) && Information.IsNothing((object)TargetType_UnspecifiedShooterQty))
			{
				theComboBoxDataSource_ShooterQty.Rows.Add(0, "Inherited");
			}
			else
			{
				theComboBoxDataSource_ShooterQty.Rows.Add(0, "Inherited, " + WRA_ShooterQtyString(TargetType_InheritedShooterQty, !Information.IsNothing((object)TargetType_UnspecifiedShooterQty)));
			}
		}
		if (Information.IsNothing((object)shooterQty))
		{
			if ((object)SubjectType == typeof(Side) && theTargetType != _WRA_WeaponTargetType.Air_Contact_Unknown_Type && theTargetType != _WRA_WeaponTargetType.Aircraft_Unspecified)
			{
				if (!Information.IsNothing((object)TargetType_InheritedShooterQty) && !Information.IsNothing((object)TargetType_UnspecifiedShooterQty))
				{
					theComboBoxDataSource_ShooterQty.Rows.Add(1, "Not Configured");
				}
				else if (!Information.IsNothing((object)TargetType_InheritedShooterQty))
				{
					theComboBoxDataSource_ShooterQty.Rows.Add(1, "Not Configured, " + WRA_ShooterQtyString(shooterQty, !Information.IsNothing((object)TargetType_UnspecifiedShooterQty)));
				}
				else
				{
					theComboBoxDataSource_ShooterQty.Rows.Add(1, "Not Configured, " + WRA_ShooterQtyString(TargetType_UnspecifiedShooterQty, !Information.IsNothing((object)TargetType_UnspecifiedShooterQty)));
				}
			}
		}
		else if (Information.IsNothing((object)TargetType_InheritedShooterQty) && Information.IsNothing((object)TargetType_UnspecifiedShooterQty) && (object)SubjectType != typeof(Side))
		{
			theComboBoxDataSource_ShooterQty.Rows.Add(1, "System default");
		}
		else
		{
			theComboBoxDataSource_ShooterQty.Rows.Add(1, "System default, " + WRA_ShooterQtyString(shooterQty, TargetTypeUnspecified: false));
		}
		theComboBoxDataSource_ShooterQty.Rows.Add(2, "Fire weapons from enough units to fill the salvo's Weapon Qty requirement");
		theComboBoxDataSource_ShooterQty.Rows.Add(3, "1 unit");
		theComboBoxDataSource_ShooterQty.Rows.Add(4, "2 units");
		theComboBoxDataSource_ShooterQty.Rows.Add(5, "4 units");
		if (theComboBoxValue == ShooterQty_To_ShootersPerSalvoSelection(-100))
		{
			theComboBoxDataSource_ShooterQty.Rows.Add(6, "Various settings");
		}
	}

	public void ComboBoxDataSource_SelfDefenceRange(ref DataTable theComboBoxDataSource_SelfDefenceRange, _WRA_WeaponTargetType theTargetType, ref Weapon theWeapon, int theComboBoxValue)
	{
		if (!theComboBoxDataSource_SelfDefenceRange.Columns.Contains("ID"))
		{
			theComboBoxDataSource_SelfDefenceRange.Columns.Add("ID", typeof(int));
		}
		if (!theComboBoxDataSource_SelfDefenceRange.Columns.Contains("Description"))
		{
			theComboBoxDataSource_SelfDefenceRange.Columns.Add("Description", typeof(string));
		}
		WRA_FiringDoctrineEntry value = default(WRA_FiringDoctrineEntry);
		float? selfDefenceRange = default(float?);
		foreach (KeyValuePair<int, WRA_Weapon> item in theWeapon.Doctrine.WRA)
		{
			_ = item.Key;
			if (item.Value.WRA_WeaponTargets.TryGetValue((int)theTargetType, ref value))
			{
				selfDefenceRange = value.SelfDefenceRange;
			}
		}
		float? TargetType_InheriteSelfDefenceRange = default(float?);
		float? TargetType_UnspecifiedSelfDefenceRange = default(float?);
		if ((object)SubjectType != typeof(Side))
		{
			WRA_SelfDefenceRange_AnyTargetType(this, theWeapon.ParentScen, theWeapon, theTargetType, FindInheritedValuesOnly: true, ref TargetType_InheriteSelfDefenceRange, ref TargetType_UnspecifiedSelfDefenceRange);
		}
		else if (!WRA_IsTopNodeTargetType(ref theTargetType))
		{
			_WRA_WeaponTargetType selectedNodeTargetType = WRA_DetermineTargetType_Unspecified(ref theTargetType);
			TargetType_UnspecifiedSelfDefenceRange = WRA_SelfDefenceRange_CurrentTargetType(this, theWeapon.ParentScen, theWeapon, selectedNodeTargetType);
		}
		switch (theTargetType)
		{
		case _WRA_WeaponTargetType.Satellite_Unspecified:
			if ((object)SubjectType != typeof(Side))
			{
				if (!Information.IsNothing((object)selfDefenceRange))
				{
					if (Information.IsNothing((object)TargetType_InheriteSelfDefenceRange) && Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange))
					{
						theComboBoxDataSource_SelfDefenceRange.Rows.Add(0, "Inherited");
					}
					else
					{
						theComboBoxDataSource_SelfDefenceRange.Rows.Add(0, "Inherited, " + WRA_SelfDefenceRangeString(TargetType_InheriteSelfDefenceRange, !Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange)));
					}
				}
				else if (Information.IsNothing((object)TargetType_InheriteSelfDefenceRange) && Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange))
				{
					theComboBoxDataSource_SelfDefenceRange.Rows.Add(0, "Inherited");
				}
				else if (Information.IsNothing((object)TargetType_InheriteSelfDefenceRange))
				{
					theComboBoxDataSource_SelfDefenceRange.Rows.Add(0, "Inherited, " + WRA_SelfDefenceRangeString(TargetType_UnspecifiedSelfDefenceRange, !Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange)));
				}
				else if (!Information.IsNothing((object)TargetType_InheriteSelfDefenceRange))
				{
					theComboBoxDataSource_SelfDefenceRange.Rows.Add(0, "Inherited, " + WRA_SelfDefenceRangeString(TargetType_InheriteSelfDefenceRange, !Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange)));
				}
				else
				{
					theComboBoxDataSource_SelfDefenceRange.Rows.Add(0, "Inherited, " + WRA_SelfDefenceRangeString(selfDefenceRange, !Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange)));
				}
			}
			if (Information.IsNothing((object)selfDefenceRange))
			{
				if ((object)SubjectType == typeof(Side) && theTargetType != _WRA_WeaponTargetType.Satellite_Unspecified)
				{
					if (!Information.IsNothing((object)TargetType_InheriteSelfDefenceRange) && !Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange))
					{
						theComboBoxDataSource_SelfDefenceRange.Rows.Add(1, "Not Configured");
					}
					else if (!Information.IsNothing((object)TargetType_InheriteSelfDefenceRange))
					{
						theComboBoxDataSource_SelfDefenceRange.Rows.Add(1, "Not Configured, " + WRA_SelfDefenceRangeString(selfDefenceRange, !Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange)));
					}
					else
					{
						theComboBoxDataSource_SelfDefenceRange.Rows.Add(1, "Not Configured, " + WRA_SelfDefenceRangeString(TargetType_UnspecifiedSelfDefenceRange, !Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange)));
					}
				}
			}
			else if (Information.IsNothing((object)TargetType_InheriteSelfDefenceRange) && Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange) && (object)SubjectType != typeof(Side))
			{
				theComboBoxDataSource_SelfDefenceRange.Rows.Add(1, "System default");
			}
			else
			{
				theComboBoxDataSource_SelfDefenceRange.Rows.Add(1, "System default, " + WRA_SelfDefenceRangeString(selfDefenceRange, TargetTypeUnspecified: false));
			}
			if (theComboBoxValue == SelfDefenceRange_To_SelfDefenceRangeSelection(ref theTargetType, -100f))
			{
				theComboBoxDataSource_SelfDefenceRange.Rows.Add(2, "Various settings");
			}
			break;
		case _WRA_WeaponTargetType.Subsurface_Contact_Unknown_Type:
		case _WRA_WeaponTargetType.Submarine_Unspecified:
			if ((object)SubjectType != typeof(Side))
			{
				if (Information.IsNothing((object)selfDefenceRange))
				{
					if (Information.IsNothing((object)TargetType_InheriteSelfDefenceRange) && Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange))
					{
						theComboBoxDataSource_SelfDefenceRange.Rows.Add(0, "Inherited");
					}
					else if (!Information.IsNothing((object)TargetType_InheriteSelfDefenceRange))
					{
						if (!Information.IsNothing((object)TargetType_InheriteSelfDefenceRange))
						{
							theComboBoxDataSource_SelfDefenceRange.Rows.Add(0, "Inherited, " + WRA_SelfDefenceRangeString(TargetType_InheriteSelfDefenceRange, !Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange)));
						}
						else
						{
							theComboBoxDataSource_SelfDefenceRange.Rows.Add(0, "Inherited, " + WRA_SelfDefenceRangeString(selfDefenceRange, !Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange)));
						}
					}
					else
					{
						theComboBoxDataSource_SelfDefenceRange.Rows.Add(0, "Inherited, " + WRA_SelfDefenceRangeString(TargetType_UnspecifiedSelfDefenceRange, !Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange)));
					}
				}
				else if (Information.IsNothing((object)TargetType_InheriteSelfDefenceRange) && Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange))
				{
					theComboBoxDataSource_SelfDefenceRange.Rows.Add(0, "Inherited");
				}
				else
				{
					theComboBoxDataSource_SelfDefenceRange.Rows.Add(0, "Inherited, " + WRA_SelfDefenceRangeString(TargetType_InheriteSelfDefenceRange, !Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange)));
				}
			}
			if (!Information.IsNothing((object)selfDefenceRange))
			{
				if (Information.IsNothing((object)TargetType_InheriteSelfDefenceRange) && Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange) && (object)SubjectType != typeof(Side))
				{
					theComboBoxDataSource_SelfDefenceRange.Rows.Add(1, "System default");
				}
				else
				{
					theComboBoxDataSource_SelfDefenceRange.Rows.Add(1, "System default, " + WRA_SelfDefenceRangeString(selfDefenceRange, TargetTypeUnspecified: false));
				}
			}
			else if ((object)SubjectType == typeof(Side) && theTargetType != _WRA_WeaponTargetType.Subsurface_Contact_Unknown_Type && theTargetType != _WRA_WeaponTargetType.Submarine_Unspecified)
			{
				if (!Information.IsNothing((object)TargetType_InheriteSelfDefenceRange) && !Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange))
				{
					theComboBoxDataSource_SelfDefenceRange.Rows.Add(1, "Not Configured");
				}
				else if (Information.IsNothing((object)TargetType_InheriteSelfDefenceRange))
				{
					theComboBoxDataSource_SelfDefenceRange.Rows.Add(1, "Not Configured, " + WRA_SelfDefenceRangeString(TargetType_UnspecifiedSelfDefenceRange, !Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange)));
				}
				else
				{
					theComboBoxDataSource_SelfDefenceRange.Rows.Add(1, "Not Configured, " + WRA_SelfDefenceRangeString(selfDefenceRange, !Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange)));
				}
			}
			theComboBoxDataSource_SelfDefenceRange.Rows.Add(2, "Do not use weapon in self defence");
			if (theWeapon.MaxSubsurfaceRange > 2f)
			{
				theComboBoxDataSource_SelfDefenceRange.Rows.Add(3, " 2 nm");
			}
			if (theWeapon.MaxSubsurfaceRange > 5f)
			{
				theComboBoxDataSource_SelfDefenceRange.Rows.Add(4, " 5 nm");
			}
			if (theWeapon.MaxSubsurfaceRange > 10f)
			{
				theComboBoxDataSource_SelfDefenceRange.Rows.Add(5, "10 nm");
			}
			if (theWeapon.MaxSubsurfaceRange > 15f)
			{
				theComboBoxDataSource_SelfDefenceRange.Rows.Add(6, "15 nm");
			}
			theComboBoxDataSource_SelfDefenceRange.Rows.Add(7, "Maximum range");
			if (theComboBoxValue == SelfDefenceRange_To_SelfDefenceRangeSelection(ref theTargetType, -100f))
			{
				theComboBoxDataSource_SelfDefenceRange.Rows.Add(8, "Various settings");
			}
			break;
		case _WRA_WeaponTargetType.Surface_Contact_Unknown_Type:
		case _WRA_WeaponTargetType.Ship_Unspecified:
		case _WRA_WeaponTargetType.Ship_Carrier_0_25000_tons:
		case _WRA_WeaponTargetType.Ship_Carrier_25001_45000_tons:
		case _WRA_WeaponTargetType.Ship_Carrier_45001_95000_tons:
		case _WRA_WeaponTargetType.Ship_Carrier_95000_tons:
		case _WRA_WeaponTargetType.Ship_Surface_Combatant_0_500_tons:
		case _WRA_WeaponTargetType.Ship_Surface_Combatant_501_1500_tons:
		case _WRA_WeaponTargetType.Ship_Surface_Combatant_1501_5000_tons:
		case _WRA_WeaponTargetType.Ship_Surface_Combatant_5001_10000_tons:
		case _WRA_WeaponTargetType.Ship_Surface_Combatant_10001_25000_tons:
		case _WRA_WeaponTargetType.Ship_Surface_Combatant_25001_45000_tons:
		case _WRA_WeaponTargetType.Ship_Surface_Combatant_45001_95000_tons:
		case _WRA_WeaponTargetType.Ship_Surface_Combatant_95000_tons:
		case _WRA_WeaponTargetType.Ship_Amphibious_0_500_tons:
		case _WRA_WeaponTargetType.Ship_Amphibious_501_1500_tons:
		case _WRA_WeaponTargetType.Ship_Amphibious_1501_5000_tons:
		case _WRA_WeaponTargetType.Ship_Amphibious_5001_10000_tons:
		case _WRA_WeaponTargetType.Ship_Amphibious_10001_25000_tons:
		case _WRA_WeaponTargetType.Ship_Amphibious_25001_45000_tons:
		case _WRA_WeaponTargetType.Ship_Amphibious_45001_95000_tons:
		case _WRA_WeaponTargetType.Ship_Amphibious_95000_tons:
		case _WRA_WeaponTargetType.Ship_Auxiliary_0_500_tons:
		case _WRA_WeaponTargetType.Ship_Auxiliary_501_1500_tons:
		case _WRA_WeaponTargetType.Ship_Auxiliary_1501_5000_tons:
		case _WRA_WeaponTargetType.Ship_Auxiliary_5001_10000_tons:
		case _WRA_WeaponTargetType.Ship_Auxiliary_10001_25000_tons:
		case _WRA_WeaponTargetType.Ship_Auxiliary_25001_45000_tons:
		case _WRA_WeaponTargetType.Ship_Auxiliary_45001_95000_tons:
		case _WRA_WeaponTargetType.Ship_Auxiliary_95000_tons:
		case _WRA_WeaponTargetType.Ship_Merchant_Civilian_0_500_tons:
		case _WRA_WeaponTargetType.Ship_Merchant_Civilian_501_1500_tons:
		case _WRA_WeaponTargetType.Ship_Merchant_Civilian_1501_5000_tons:
		case _WRA_WeaponTargetType.Ship_Merchant_Civilian_5001_10000_tons:
		case _WRA_WeaponTargetType.Ship_Merchant_Civilian_10001_25000_tons:
		case _WRA_WeaponTargetType.Ship_Merchant_Civilian_25001_45000_tons:
		case _WRA_WeaponTargetType.Ship_Merchant_Civilian_45001_95000_tons:
		case _WRA_WeaponTargetType.Ship_Merchant_Civilian_95000_tons:
		case _WRA_WeaponTargetType.Submarine_Surfaced:
			if ((object)SubjectType != typeof(Side))
			{
				if (!Information.IsNothing((object)selfDefenceRange))
				{
					if (Information.IsNothing((object)TargetType_InheriteSelfDefenceRange) && Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange))
					{
						theComboBoxDataSource_SelfDefenceRange.Rows.Add(0, "Inherited");
					}
					else
					{
						theComboBoxDataSource_SelfDefenceRange.Rows.Add(0, "Inherited, " + WRA_SelfDefenceRangeString(TargetType_InheriteSelfDefenceRange, !Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange)));
					}
				}
				else if (Information.IsNothing((object)TargetType_InheriteSelfDefenceRange) && Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange))
				{
					theComboBoxDataSource_SelfDefenceRange.Rows.Add(0, "Inherited");
				}
				else if (Information.IsNothing((object)TargetType_InheriteSelfDefenceRange))
				{
					theComboBoxDataSource_SelfDefenceRange.Rows.Add(0, "Inherited, " + WRA_SelfDefenceRangeString(TargetType_UnspecifiedSelfDefenceRange, !Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange)));
				}
				else if (Information.IsNothing((object)TargetType_InheriteSelfDefenceRange))
				{
					theComboBoxDataSource_SelfDefenceRange.Rows.Add(0, "Inherited, " + WRA_SelfDefenceRangeString(selfDefenceRange, !Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange)));
				}
				else
				{
					theComboBoxDataSource_SelfDefenceRange.Rows.Add(0, "Inherited, " + WRA_SelfDefenceRangeString(TargetType_InheriteSelfDefenceRange, !Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange)));
				}
			}
			if (Information.IsNothing((object)selfDefenceRange))
			{
				if ((object)SubjectType == typeof(Side))
				{
					string text = "System Default";
					if (theTargetType != _WRA_WeaponTargetType.Surface_Contact_Unknown_Type && theTargetType != _WRA_WeaponTargetType.Ship_Unspecified)
					{
						text = "Not Configured";
					}
					if (!Information.IsNothing((object)TargetType_InheriteSelfDefenceRange) && !Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange))
					{
						theComboBoxDataSource_SelfDefenceRange.Rows.Add(1, text);
					}
					else if (!Information.IsNothing((object)TargetType_InheriteSelfDefenceRange))
					{
						theComboBoxDataSource_SelfDefenceRange.Rows.Add(1, text + ", " + WRA_SelfDefenceRangeString(selfDefenceRange, !Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange)));
					}
					else
					{
						theComboBoxDataSource_SelfDefenceRange.Rows.Add(1, text + ", " + WRA_SelfDefenceRangeString(TargetType_UnspecifiedSelfDefenceRange, !Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange)));
					}
				}
			}
			else if (Information.IsNothing((object)TargetType_InheriteSelfDefenceRange) && Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange) && (object)SubjectType != typeof(Side))
			{
				theComboBoxDataSource_SelfDefenceRange.Rows.Add(1, "System default");
			}
			else
			{
				theComboBoxDataSource_SelfDefenceRange.Rows.Add(1, "System default, " + WRA_SelfDefenceRangeString(selfDefenceRange, TargetTypeUnspecified: false));
			}
			theComboBoxDataSource_SelfDefenceRange.Rows.Add(2, "Do not use weapon in self defence");
			if (theWeapon.MaxSurfaceRange > 2f)
			{
				theComboBoxDataSource_SelfDefenceRange.Rows.Add(3, " 2 nm");
			}
			if (theWeapon.MaxSurfaceRange > 5f)
			{
				theComboBoxDataSource_SelfDefenceRange.Rows.Add(4, " 5 nm");
			}
			if (theWeapon.MaxSurfaceRange > 10f)
			{
				theComboBoxDataSource_SelfDefenceRange.Rows.Add(5, "10 nm");
			}
			if (theWeapon.MaxSurfaceRange > 15f)
			{
				theComboBoxDataSource_SelfDefenceRange.Rows.Add(6, "15 nm");
			}
			theComboBoxDataSource_SelfDefenceRange.Rows.Add(7, "Maximum range");
			if (theComboBoxValue == SelfDefenceRange_To_SelfDefenceRangeSelection(ref theTargetType, -100f))
			{
				theComboBoxDataSource_SelfDefenceRange.Rows.Add(8, "Various settings");
			}
			break;
		case _WRA_WeaponTargetType.Air_Contact_Unknown_Type:
		case _WRA_WeaponTargetType.Aircraft_Unspecified:
		case _WRA_WeaponTargetType.Aircraft_5th_Generation:
		case _WRA_WeaponTargetType.Aircraft_4th_Generation:
		case _WRA_WeaponTargetType.Aircraft_3rd_Generation:
		case _WRA_WeaponTargetType.Aircraft_Less_Capable:
		case _WRA_WeaponTargetType.Aircraft_High_Perf_Bombers:
		case _WRA_WeaponTargetType.Aircraft_Medium_Perf_Bombers:
		case _WRA_WeaponTargetType.Aircraft_Low_Perf_Bombers:
		case _WRA_WeaponTargetType.Aircraft_High_Perf_Recon_EW:
		case _WRA_WeaponTargetType.Aircraft_Medium_Perf_Recon_EW:
		case _WRA_WeaponTargetType.Aircraft_Low_Perf_Recon_EW:
		case _WRA_WeaponTargetType.Aircraft_AEW:
		case _WRA_WeaponTargetType.Aircraft_Class1_UAS:
		case _WRA_WeaponTargetType.Aircraft_Tanker:
		case _WRA_WeaponTargetType.Aircraft_Class2_UAS:
		case _WRA_WeaponTargetType.Helicopter_Unspecified:
		case _WRA_WeaponTargetType.Guided_Weapon_Unspecified:
		case _WRA_WeaponTargetType.Guided_Weapon_Supersonic_Sea_Skimming:
		case _WRA_WeaponTargetType.Guided_Weapon_Subsonic_Sea_Skimming:
		case _WRA_WeaponTargetType.Guided_Weapon_Supersonic:
		case _WRA_WeaponTargetType.Guided_Weapon_Subsonic:
		case _WRA_WeaponTargetType.Guided_Weapon_Ballistic:
		case _WRA_WeaponTargetType.Emitter_Radar:
		case _WRA_WeaponTargetType.Emitter_Jammer:
			if ((object)SubjectType != typeof(Side))
			{
				if (!selfDefenceRange.HasValue)
				{
					if (Information.IsNothing((object)TargetType_InheriteSelfDefenceRange) && Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange))
					{
						theComboBoxDataSource_SelfDefenceRange.Rows.Add(0, "Inherited");
					}
					else if (Information.IsNothing((object)TargetType_InheriteSelfDefenceRange))
					{
						theComboBoxDataSource_SelfDefenceRange.Rows.Add(0, "Inherited, " + WRA_SelfDefenceRangeString(TargetType_UnspecifiedSelfDefenceRange, !Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange)));
					}
					else if (Information.IsNothing((object)TargetType_InheriteSelfDefenceRange))
					{
						theComboBoxDataSource_SelfDefenceRange.Rows.Add(0, "Inherited, " + WRA_SelfDefenceRangeString(selfDefenceRange, !Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange)));
					}
					else
					{
						theComboBoxDataSource_SelfDefenceRange.Rows.Add(0, "Inherited, " + WRA_SelfDefenceRangeString(TargetType_InheriteSelfDefenceRange, !Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange)));
					}
				}
				else if (Information.IsNothing((object)TargetType_InheriteSelfDefenceRange) && Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange))
				{
					theComboBoxDataSource_SelfDefenceRange.Rows.Add(0, "Inherited");
				}
				else
				{
					theComboBoxDataSource_SelfDefenceRange.Rows.Add(0, "Inherited, " + WRA_SelfDefenceRangeString(TargetType_InheriteSelfDefenceRange, !Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange)));
				}
			}
			if (!Information.IsNothing((object)selfDefenceRange))
			{
				if (Information.IsNothing((object)TargetType_InheriteSelfDefenceRange) && Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange) && (object)SubjectType != typeof(Side))
				{
					theComboBoxDataSource_SelfDefenceRange.Rows.Add(1, "System default");
				}
				else
				{
					theComboBoxDataSource_SelfDefenceRange.Rows.Add(1, "System default, " + WRA_SelfDefenceRangeString(selfDefenceRange, TargetTypeUnspecified: false));
				}
			}
			else if ((object)SubjectType == typeof(Side))
			{
				if (theTargetType != _WRA_WeaponTargetType.Air_Contact_Unknown_Type && theTargetType != _WRA_WeaponTargetType.Aircraft_Unspecified)
				{
					if (!Information.IsNothing((object)TargetType_InheriteSelfDefenceRange) && !Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange))
					{
						theComboBoxDataSource_SelfDefenceRange.Rows.Add(1, "Not Configured");
					}
					else if (!Information.IsNothing((object)TargetType_InheriteSelfDefenceRange))
					{
						theComboBoxDataSource_SelfDefenceRange.Rows.Add(1, "Not Configured, " + WRA_SelfDefenceRangeString(selfDefenceRange, !Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange)));
					}
					else
					{
						theComboBoxDataSource_SelfDefenceRange.Rows.Add(1, "Not Configured, " + WRA_SelfDefenceRangeString(TargetType_UnspecifiedSelfDefenceRange, !Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange)));
					}
				}
				else
				{
					theComboBoxDataSource_SelfDefenceRange.Rows.Add(1, "System default");
				}
			}
			theComboBoxDataSource_SelfDefenceRange.Rows.Add(2, "Do not use weapon in self defence");
			if (theWeapon.MaxAirRange > 2f)
			{
				theComboBoxDataSource_SelfDefenceRange.Rows.Add(3, " 2 nm");
			}
			if (theWeapon.MaxAirRange > 5f)
			{
				theComboBoxDataSource_SelfDefenceRange.Rows.Add(4, " 5 nm");
			}
			if (theWeapon.MaxAirRange > 10f)
			{
				theComboBoxDataSource_SelfDefenceRange.Rows.Add(5, "10 nm");
			}
			if (theWeapon.MaxAirRange > 15f)
			{
				theComboBoxDataSource_SelfDefenceRange.Rows.Add(6, "15 nm");
			}
			theComboBoxDataSource_SelfDefenceRange.Rows.Add(7, "Maximum range");
			if (theComboBoxValue == SelfDefenceRange_To_SelfDefenceRangeSelection(ref theTargetType, -100f))
			{
				theComboBoxDataSource_SelfDefenceRange.Rows.Add(8, "Various settings");
			}
			break;
		default:
			theComboBoxDataSource_SelfDefenceRange.Rows.Add(0, "Not implemented");
			break;
		case _WRA_WeaponTargetType.Land_Contact_Unknown_Type:
		case _WRA_WeaponTargetType.Land_Structure_Soft_Unspecified:
		case _WRA_WeaponTargetType.Land_Structure_Soft_Building_Surface:
		case _WRA_WeaponTargetType.Land_Structure_Soft_Building_Reveted:
		case _WRA_WeaponTargetType.Land_Structure_Soft_Building_Bunker:
		case _WRA_WeaponTargetType.Land_Structure_Soft_Building_Underground:
		case _WRA_WeaponTargetType.Land_Structure_Soft_Structure_Open:
		case _WRA_WeaponTargetType.Land_Structure_Soft_Structure_Reveted:
		case _WRA_WeaponTargetType.Land_Structure_Soft_Aerostat_Moring:
		case _WRA_WeaponTargetType.Land_Structure_Hardened_Unspecified:
		case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Surface:
		case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Reveted:
		case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Bunker:
		case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Underground:
		case _WRA_WeaponTargetType.Land_Structure_Hardened_Structure_Open:
		case _WRA_WeaponTargetType.Land_Structure_Hardened_Structure_Reveted:
		case _WRA_WeaponTargetType.Runway_Facility_Unspecified:
		case _WRA_WeaponTargetType.Runway:
		case _WRA_WeaponTargetType.Runway_Grade_Taxiway:
		case _WRA_WeaponTargetType.Runway_Access_Point:
		case _WRA_WeaponTargetType.Emitter_Unspecified:
		case _WRA_WeaponTargetType.Mobile_Target_Soft_Unspecified:
		case _WRA_WeaponTargetType.Mobile_Target_Soft_Mobile_Vehicle:
		case _WRA_WeaponTargetType.Mobile_Target_Soft_Mobile_Personnel:
		case _WRA_WeaponTargetType.Mobile_Target_Hardened_Unspecified:
		case _WRA_WeaponTargetType.Mobile_Target_Hardened_Mobile_Vehicle:
		case _WRA_WeaponTargetType.Underwater_Structure:
		case _WRA_WeaponTargetType.Air_Base_Single_Unit_Airfield:
			if ((object)SubjectType != typeof(Side))
			{
				if (!Information.IsNothing((object)selfDefenceRange))
				{
					if (Information.IsNothing((object)TargetType_InheriteSelfDefenceRange) && Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange))
					{
						theComboBoxDataSource_SelfDefenceRange.Rows.Add(0, "Inherited");
					}
					else
					{
						theComboBoxDataSource_SelfDefenceRange.Rows.Add(0, "Inherited, " + WRA_SelfDefenceRangeString(TargetType_InheriteSelfDefenceRange, !Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange)));
					}
				}
				else if (Information.IsNothing((object)TargetType_InheriteSelfDefenceRange) && Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange))
				{
					theComboBoxDataSource_SelfDefenceRange.Rows.Add(0, "Inherited");
				}
				else if (!Information.IsNothing((object)TargetType_InheriteSelfDefenceRange))
				{
					if (Information.IsNothing((object)TargetType_InheriteSelfDefenceRange))
					{
						theComboBoxDataSource_SelfDefenceRange.Rows.Add(0, "Inherited, " + WRA_SelfDefenceRangeString(selfDefenceRange, !Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange)));
					}
					else
					{
						theComboBoxDataSource_SelfDefenceRange.Rows.Add(0, "Inherited, " + WRA_SelfDefenceRangeString(TargetType_InheriteSelfDefenceRange, !Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange)));
					}
				}
				else
				{
					theComboBoxDataSource_SelfDefenceRange.Rows.Add(0, "Inherited, " + WRA_SelfDefenceRangeString(TargetType_UnspecifiedSelfDefenceRange, !Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange)));
				}
			}
			if (!Information.IsNothing((object)selfDefenceRange))
			{
				if (Information.IsNothing((object)TargetType_InheriteSelfDefenceRange) && Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange) && (object)SubjectType != typeof(Side))
				{
					theComboBoxDataSource_SelfDefenceRange.Rows.Add(1, "System default");
				}
				else
				{
					theComboBoxDataSource_SelfDefenceRange.Rows.Add(1, "System default, " + WRA_SelfDefenceRangeString(selfDefenceRange, TargetTypeUnspecified: false));
				}
			}
			else if ((object)SubjectType == typeof(Side))
			{
				switch (theTargetType)
				{
				default:
					if (!Information.IsNothing((object)TargetType_InheriteSelfDefenceRange) && !Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange))
					{
						theComboBoxDataSource_SelfDefenceRange.Rows.Add(1, "Not Configured");
					}
					else if (Information.IsNothing((object)TargetType_InheriteSelfDefenceRange))
					{
						theComboBoxDataSource_SelfDefenceRange.Rows.Add(1, "Not Configured, " + WRA_SelfDefenceRangeString(TargetType_UnspecifiedSelfDefenceRange, !Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange)));
					}
					else
					{
						theComboBoxDataSource_SelfDefenceRange.Rows.Add(1, "Not Configured, " + WRA_SelfDefenceRangeString(selfDefenceRange, !Information.IsNothing((object)TargetType_UnspecifiedSelfDefenceRange)));
					}
					break;
				case _WRA_WeaponTargetType.Land_Structure_Soft_Unspecified:
				case _WRA_WeaponTargetType.Land_Structure_Hardened_Unspecified:
				case _WRA_WeaponTargetType.Runway_Facility_Unspecified:
				case _WRA_WeaponTargetType.Emitter_Unspecified:
				case _WRA_WeaponTargetType.Mobile_Target_Soft_Unspecified:
				case _WRA_WeaponTargetType.Mobile_Target_Hardened_Unspecified:
				case _WRA_WeaponTargetType.Underwater_Structure:
				case _WRA_WeaponTargetType.Air_Base_Single_Unit_Airfield:
					break;
				}
			}
			theComboBoxDataSource_SelfDefenceRange.Rows.Add(2, "Do not use weapon in self defence");
			if (theWeapon.MaxLandRange > 2f)
			{
				theComboBoxDataSource_SelfDefenceRange.Rows.Add(3, " 2 nm");
			}
			if (theWeapon.MaxLandRange > 5f)
			{
				theComboBoxDataSource_SelfDefenceRange.Rows.Add(4, " 5 nm");
			}
			if (theWeapon.MaxLandRange > 10f)
			{
				theComboBoxDataSource_SelfDefenceRange.Rows.Add(5, "10 nm");
			}
			if (theWeapon.MaxLandRange > 15f)
			{
				theComboBoxDataSource_SelfDefenceRange.Rows.Add(6, "15 nm");
			}
			theComboBoxDataSource_SelfDefenceRange.Rows.Add(7, "Maximum range");
			if (theComboBoxValue == SelfDefenceRange_To_SelfDefenceRangeSelection(ref theTargetType, -100f))
			{
				theComboBoxDataSource_SelfDefenceRange.Rows.Add(8, "Various settings");
			}
			break;
		}
	}

	public void ComboBoxDataSource_FiringRange(ref DataTable theComboBoxDataSource_FiringRange, _WRA_WeaponTargetType theTargetType, ref Weapon theWeapon, int theComboBoxValue)
	{
		if (!theComboBoxDataSource_FiringRange.Columns.Contains("ID"))
		{
			theComboBoxDataSource_FiringRange.Columns.Add("ID", typeof(int));
		}
		if (!theComboBoxDataSource_FiringRange.Columns.Contains("Description"))
		{
			theComboBoxDataSource_FiringRange.Columns.Add("Description", typeof(string));
		}
		float? num = (float)WRA_FiringRange_GetDefaultFiringRange(theWeapon.ParentScen, theWeapon.DBID, theTargetType);
		float? TargetType_InheritedFiringRange = default(float?);
		float? TargetType_UnspecifiedFiringRange = default(float?);
		float? num2 = default(float?);
		if ((object)SubjectType != typeof(Side))
		{
			WRA_FiringRange_AnyTargetType(this, theWeapon.ParentScen, theWeapon.DBID, theTargetType, FindInheritedValuesOnly: true, ref TargetType_InheritedFiringRange, ref TargetType_UnspecifiedFiringRange);
		}
		else if (!WRA_IsTopNodeTargetType(ref theTargetType))
		{
			_WRA_WeaponTargetType selectedNodeTargetType = WRA_DetermineTargetType_Unspecified(ref theTargetType);
			TargetType_UnspecifiedFiringRange = WRA_FiringRange_CurrentTargetType(this, theWeapon.ParentScen, theWeapon.DBID, selectedNodeTargetType);
		}
		else
		{
			num2 = num;
		}
		if (Information.IsNothing((object)TargetType_UnspecifiedFiringRange))
		{
			TargetType_UnspecifiedFiringRange = num;
		}
		if ((object)SubjectType != typeof(Side))
		{
			if (Information.IsNothing((object)num2))
			{
				if (Information.IsNothing((object)TargetType_InheritedFiringRange) && Information.IsNothing((object)TargetType_UnspecifiedFiringRange))
				{
					theComboBoxDataSource_FiringRange.Rows.Add(0, "Inherited");
				}
				else if (!Information.IsNothing((object)TargetType_InheritedFiringRange))
				{
					if (!Information.IsNothing((object)TargetType_InheritedFiringRange))
					{
						theComboBoxDataSource_FiringRange.Rows.Add(0, "Inherited, " + WRA_FiringRangeString(TargetType_InheritedFiringRange, !Information.IsNothing((object)TargetType_UnspecifiedFiringRange)));
					}
					else
					{
						theComboBoxDataSource_FiringRange.Rows.Add(0, "Inherited, " + WRA_FiringRangeString(num2, !Information.IsNothing((object)TargetType_UnspecifiedFiringRange)));
					}
				}
				else
				{
					theComboBoxDataSource_FiringRange.Rows.Add(0, "Inherited, " + WRA_FiringRangeString(TargetType_UnspecifiedFiringRange, !Information.IsNothing((object)TargetType_UnspecifiedFiringRange)));
				}
			}
			else if (Information.IsNothing((object)TargetType_InheritedFiringRange) && Information.IsNothing((object)TargetType_UnspecifiedFiringRange))
			{
				theComboBoxDataSource_FiringRange.Rows.Add(0, "Inherited");
			}
			else
			{
				theComboBoxDataSource_FiringRange.Rows.Add(0, "Inherited, " + WRA_FiringRangeString(TargetType_InheritedFiringRange, !Information.IsNothing((object)TargetType_UnspecifiedFiringRange)));
			}
		}
		if (!Information.IsNothing((object)num2))
		{
			if (!Information.IsNothing((object)TargetType_InheritedFiringRange) && !Information.IsNothing((object)TargetType_UnspecifiedFiringRange) && (object)SubjectType != typeof(Side))
			{
				float? num3 = num;
				if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3.GetValueOrDefault() == -102f)) != true)
				{
					theComboBoxDataSource_FiringRange.Rows.Add(1, "System Default, Automatic Fire to Max Range");
				}
				else
				{
					theComboBoxDataSource_FiringRange.Rows.Add(1, "System Default, No-Escape Zone");
				}
			}
			else
			{
				theComboBoxDataSource_FiringRange.Rows.Add(1, "System Default, " + WRA_FiringRangeString(num, !Information.IsNothing((object)TargetType_UnspecifiedFiringRange)));
			}
		}
		else if ((object)SubjectType == typeof(Side))
		{
			if (Information.IsNothing((object)TargetType_InheritedFiringRange) && Information.IsNothing((object)TargetType_UnspecifiedFiringRange))
			{
				theComboBoxDataSource_FiringRange.Rows.Add(1, "Not Configured");
			}
			else if (Information.IsNothing((object)TargetType_InheritedFiringRange))
			{
				theComboBoxDataSource_FiringRange.Rows.Add(1, "Not Configured, " + WRA_FiringRangeString(TargetType_UnspecifiedFiringRange, !Information.IsNothing((object)TargetType_UnspecifiedFiringRange)));
			}
			else
			{
				theComboBoxDataSource_FiringRange.Rows.Add(1, "Not Configured, " + WRA_FiringRangeString(TargetType_InheritedFiringRange, !Information.IsNothing((object)TargetType_UnspecifiedFiringRange)));
			}
		}
		theComboBoxDataSource_FiringRange.Rows.Add(2, "No Automatic Fire");
		float maxRange_NoTargetType = theWeapon.MaxRange_NoTargetType;
		float minRange_NoTargetType = theWeapon.MinRange_NoTargetType;
		if (maxRange_NoTargetType > 2f && minRange_NoTargetType < 2f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(3, " 2 nm");
		}
		if (maxRange_NoTargetType > 5f && minRange_NoTargetType < 5f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(4, " 5 nm");
		}
		if (maxRange_NoTargetType > 10f && minRange_NoTargetType < 10f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(5, "10 nm");
		}
		if (maxRange_NoTargetType > 15f && minRange_NoTargetType < 15f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(6, "15 nm");
		}
		if (maxRange_NoTargetType > 20f && minRange_NoTargetType < 20f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(7, "20 nm");
		}
		if (maxRange_NoTargetType > 25f && minRange_NoTargetType < 25f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(8, "25 nm");
		}
		if (maxRange_NoTargetType > 30f && minRange_NoTargetType < 30f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(9, "30 nm");
		}
		if (maxRange_NoTargetType > 35f && minRange_NoTargetType < 35f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(10, "35 nm");
		}
		if (maxRange_NoTargetType > 40f && minRange_NoTargetType < 40f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(11, "40 nm");
		}
		if (maxRange_NoTargetType > 45f && minRange_NoTargetType < 45f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(12, "45 nm");
		}
		if (maxRange_NoTargetType > 50f && minRange_NoTargetType < 50f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(13, "50 nm");
		}
		if (maxRange_NoTargetType > 60f && minRange_NoTargetType < 60f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(14, "60 nm");
		}
		if (maxRange_NoTargetType > 70f && minRange_NoTargetType < 70f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(15, "70 nm");
		}
		if (maxRange_NoTargetType > 80f && minRange_NoTargetType < 80f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(16, "80 nm");
		}
		if (maxRange_NoTargetType > 90f && minRange_NoTargetType < 90f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(17, "90 nm");
		}
		if (maxRange_NoTargetType > 100f && minRange_NoTargetType < 100f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(18, "100 nm");
		}
		if (maxRange_NoTargetType > 125f && minRange_NoTargetType < 125f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(19, "125 nm");
		}
		if (maxRange_NoTargetType > 150f && minRange_NoTargetType < 150f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(20, "150 nm");
		}
		if (maxRange_NoTargetType > 175f && minRange_NoTargetType < 175f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(21, "175 nm");
		}
		if (maxRange_NoTargetType > 200f && minRange_NoTargetType < 200f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(22, "200 nm");
		}
		if (maxRange_NoTargetType > 250f && minRange_NoTargetType < 250f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(23, "250 nm");
		}
		if (maxRange_NoTargetType > 300f && minRange_NoTargetType < 300f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(24, "300 nm");
		}
		if (maxRange_NoTargetType > 500f && minRange_NoTargetType < 500f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(25, "500 nm");
		}
		if (maxRange_NoTargetType > 750f && minRange_NoTargetType < 750f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(26, "750 nm");
		}
		if (maxRange_NoTargetType > 1000f && minRange_NoTargetType < 1000f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(27, "1000 nm");
		}
		if (maxRange_NoTargetType > 1500f && minRange_NoTargetType < 1500f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(28, "1500 nm");
		}
		if (maxRange_NoTargetType > 2000f && minRange_NoTargetType < 2000f)
		{
			theComboBoxDataSource_FiringRange.Rows.Add(29, "2000 nm");
		}
		if (maxRange_NoTargetType > 10f)
		{
			minRange_NoTargetType = (int)Math.Round((double)maxRange_NoTargetType * 0.25);
			theComboBoxDataSource_FiringRange.Rows.Add(32, "25% of max (" + Conversions.ToString(minRange_NoTargetType) + " nm)");
			minRange_NoTargetType = (int)Math.Round((double)maxRange_NoTargetType * 0.5);
			theComboBoxDataSource_FiringRange.Rows.Add(33, "50% of max (" + Conversions.ToString(minRange_NoTargetType) + " nm)");
			minRange_NoTargetType = (int)Math.Round((double)maxRange_NoTargetType * 0.75);
			theComboBoxDataSource_FiringRange.Rows.Add(34, "75% of max (" + Conversions.ToString(minRange_NoTargetType) + " nm)");
			theComboBoxDataSource_FiringRange.Rows.Add(36, "Automatic Fire to Max Range (" + Conversions.ToString(maxRange_NoTargetType) + " nm)");
		}
		if (IsNEZValidTarget(theTargetType))
		{
			theComboBoxDataSource_FiringRange.Rows.Add(35, "No-Escape Zone");
		}
		if (theComboBoxValue == FiringRange_To_FiringRangeSelection(-100f))
		{
			theComboBoxDataSource_FiringRange.Rows.Add(30, "Various settings");
		}
	}

	public static bool IsNEZValidTarget(_WRA_WeaponTargetType theTargetType)
	{
		int result;
		if (theTargetType <= _WRA_WeaponTargetType.Aircraft_Low_Perf_Bombers)
		{
			if ((uint)(theTargetType - 1999) <= 5u)
			{
				goto IL_0041;
			}
			if ((uint)(theTargetType - 2011) > 2u)
			{
				goto IL_0043;
			}
			result = 1;
		}
		else if ((uint)(theTargetType - 2021) <= 2u)
		{
			result = 1;
		}
		else
		{
			if (theTargetType == _WRA_WeaponTargetType.Aircraft_AEW)
			{
				goto IL_0041;
			}
			if (theTargetType != _WRA_WeaponTargetType.Aircraft_Tanker)
			{
				goto IL_0043;
			}
			result = 1;
		}
		goto IL_0042;
		IL_0043:
		bool result2 = default(bool);
		return result2;
		IL_0041:
		result = 1;
		goto IL_0042;
		IL_0042:
		return (byte)result != 0;
	}

	public static bool smethod_1(_WRA_WeaponTargetType theTargetType)
	{
		int result;
		int result2;
		if (theTargetType > _WRA_WeaponTargetType.Aircraft_Low_Perf_Bombers)
		{
			if ((uint)(theTargetType - 2021) <= 2u)
			{
				result = 1;
			}
			else
			{
				if (theTargetType == _WRA_WeaponTargetType.Aircraft_AEW)
				{
					goto IL_0048;
				}
				if (theTargetType != _WRA_WeaponTargetType.Aircraft_Tanker)
				{
					result2 = 0;
					goto IL_0045;
				}
				result = 1;
			}
		}
		else
		{
			if ((uint)(theTargetType - 1999) > 5u)
			{
				if ((uint)(theTargetType - 2011) > 2u)
				{
					result2 = 0;
					goto IL_0045;
				}
				goto IL_0048;
			}
			result = 1;
		}
		goto IL_0049;
		IL_0045:
		return (byte)result2 != 0;
		IL_0048:
		result = 1;
		goto IL_0049;
		IL_0049:
		return (byte)result != 0;
	}

	public static bool IsNEZValidTarget(Weapon theWeapon, Contact theTarget)
	{
		GlobalVariables.BooleanObject EmitterClassificable = null;
		return smethod_1(Contact.WRA_DetermineTargetType(ref theTarget, theWeapon, ref EmitterClassificable));
	}

	private static void smethod_2()
	{
		try
		{
			HashSet<_WRA_WeaponTargetType> hashSet = new HashSet<_WRA_WeaponTargetType>();
			Array values = Enum.GetValues(typeof(_WRA_WeaponTargetType));
			foreach (object item in values)
			{
				_WRA_WeaponTargetType theTargetType = (_WRA_WeaponTargetType)Conversions.ToInteger(item);
				if (WRA_IsTopNodeTargetType(ref theTargetType))
				{
					hashSet.Add(theTargetType);
				}
			}
			hashSet_0 = hashSet;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 9408533490856", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private static List<_WRA_WeaponTargetType> smethod_3(_WRA_WeaponTargetFamilyType _WRA_WeaponTargetFamilyType_0)
	{
		if (WRA_WeaponTargetsChache.Count < Enum.GetValues(typeof(_WRA_WeaponTargetType)).Length)
		{
			List<_WRA_WeaponTargetType> list = new List<_WRA_WeaponTargetType>();
			List<_WRA_WeaponTargetType> list2 = new List<_WRA_WeaponTargetType>();
			(short, short) tuple = default((short, short));
			switch (_WRA_WeaponTargetFamilyType_0)
			{
			case _WRA_WeaponTargetFamilyType.Decoy:
				tuple = (1002, 1002);
				break;
			case _WRA_WeaponTargetFamilyType.Aircrafts:
				tuple = (1999, 2100);
				list2.Add(_WRA_WeaponTargetType.Air_Contact_Unknown_Type);
				break;
			case _WRA_WeaponTargetFamilyType.Missile:
				tuple = (2200, 2211);
				list2.Add(_WRA_WeaponTargetType.Air_Contact_Unknown_Type);
				break;
			case _WRA_WeaponTargetFamilyType.Satellite:
				tuple = (2300, 2300);
				list2.Add(_WRA_WeaponTargetType.Air_Contact_Unknown_Type);
				break;
			case _WRA_WeaponTargetFamilyType.C_RAM:
				tuple = (2400, 2400);
				break;
			case _WRA_WeaponTargetFamilyType.SurfaceVessel:
				tuple = (2999, 3501);
				break;
			case _WRA_WeaponTargetFamilyType.Submarines:
				tuple = (3999, 4000);
				break;
			case _WRA_WeaponTargetFamilyType.LandStructureSoft:
				tuple = (5000, 5011);
				list2.Add(_WRA_WeaponTargetType.Land_Contact_Unknown_Type);
				break;
			case _WRA_WeaponTargetFamilyType.LandStructureHard:
				tuple = (5100, 5106);
				list2.Add(_WRA_WeaponTargetType.Land_Contact_Unknown_Type);
				break;
			case _WRA_WeaponTargetFamilyType.Runway:
				tuple = (5200, 5203);
				list2.Add(_WRA_WeaponTargetType.Land_Contact_Unknown_Type);
				break;
			case _WRA_WeaponTargetFamilyType.Emitter:
				tuple = (5300, 5300);
				list2.Add(_WRA_WeaponTargetType.Emitter_Radar);
				list2.Add(_WRA_WeaponTargetType.Emitter_Jammer);
				break;
			case _WRA_WeaponTargetFamilyType.MobileSoft:
				tuple = (5400, 5402);
				list2.Add(_WRA_WeaponTargetType.Land_Contact_Unknown_Type);
				break;
			case _WRA_WeaponTargetFamilyType.MobileHard:
				tuple = (5500, 5501);
				list2.Add(_WRA_WeaponTargetType.Land_Contact_Unknown_Type);
				break;
			case _WRA_WeaponTargetFamilyType.Underwater:
				tuple = (5601, 5601);
				list2.Add(_WRA_WeaponTargetType.Land_Contact_Unknown_Type);
				break;
			case _WRA_WeaponTargetFamilyType.SingleUnitAirbase:
				tuple = (5801, 5801);
				list2.Add(_WRA_WeaponTargetType.Land_Contact_Unknown_Type);
				break;
			}
			foreach (object value in Enum.GetValues(typeof(_WRA_WeaponTargetType)))
			{
				_WRA_WeaponTargetType wRA_WeaponTargetType = (_WRA_WeaponTargetType)Conversions.ToInteger(value);
				if ((int)wRA_WeaponTargetType >= (int)tuple.Item1 && (int)wRA_WeaponTargetType <= (int)tuple.Item2)
				{
					list.Add(wRA_WeaponTargetType);
				}
			}
			foreach (_WRA_WeaponTargetType item in list2)
			{
				if (!list.Contains(item))
				{
					list.Add(item);
				}
			}
			if (!WRA_WeaponTargetsChache.ContainsKey(_WRA_WeaponTargetFamilyType_0))
			{
				WRA_WeaponTargetsChache.Add(_WRA_WeaponTargetFamilyType_0, list);
			}
			return list;
		}
		return WRA_WeaponTargetsChache[_WRA_WeaponTargetFamilyType_0];
	}

	public static void Populate_WRAWeaponTarget_Collection(_WRA_WeaponTargetFamilyType Family, ref WRADictionary<WRA_FiringDoctrineEntry> thelist)
	{
		foreach (_WRA_WeaponTargetType item in smethod_3(Family))
		{
			if (!thelist.ContainsKey((int)item))
			{
				thelist.Add((int)item, new WRA_FiringDoctrineEntry(item));
			}
		}
	}

	public static void Populate_WRAWeaponTarget_Collection(_WRA_WeaponTargetType type, ref WRADictionary<WRA_FiringDoctrineEntry> thelist)
	{
		if (!thelist.ContainsKey((int)type))
		{
			thelist.Add((int)type, new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Air_Contact_Unknown_Type));
		}
	}

	private static void smethod_4()
	{
		foreach (KeyValuePair<_WRA_WeaponTargetFamilyType, List<_WRA_WeaponTargetType>> item in WRA_WeaponTargetsChache)
		{
			if (item.Value.Count == 0 && Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
	}

	public static void IntialiseCache()
	{
		foreach (object value in Enum.GetValues(typeof(_WRA_WeaponTargetFamilyType)))
		{
			_WRA_WeaponTargetFamilyType wRA_WeaponTargetFamilyType = (_WRA_WeaponTargetFamilyType)Conversions.ToInteger(value);
			WRA_WeaponTargetsChache.Add(wRA_WeaponTargetFamilyType, smethod_3(wRA_WeaponTargetFamilyType));
		}
		smethod_4();
	}

	public static bool isASuWTarget(int EnumTargetType)
	{
		return smethod_3(_WRA_WeaponTargetFamilyType.SurfaceVessel).Contains((_WRA_WeaponTargetType)EnumTargetType);
	}

	public void SelectionChanged_Combo(ComboBox combobox, ref Scenario CurrentScenario, ref int ExistingSelection, bool ViaDoctrineForm, bool ViaRightColumn)
	{
		switch (combobox.SelectedIndex)
		{
		case 0:
			if (SelectedUnits != null)
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.set_MaintainStandoff(CurrentScenario, MultipleUnits: true, ViaDoctrineForm, ViaRightColumn, (_UseMaintainStandoff?)(_UseMaintainStandoff)combobox.SelectedIndex);
				}
			}
			this.set_MaintainStandoff(CurrentScenario, MultipleUnits: false, ViaDoctrineForm, ViaRightColumn, (_UseMaintainStandoff?)_UseMaintainStandoff.Yes);
			break;
		case 1:
			if (!Information.IsNothing((object)SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.set_MaintainStandoff(CurrentScenario, MultipleUnits: true, ViaDoctrineForm, ViaRightColumn, (_UseMaintainStandoff?)_UseMaintainStandoff.No);
				}
			}
			this.set_MaintainStandoff(CurrentScenario, MultipleUnits: false, ViaDoctrineForm, ViaRightColumn, (_UseMaintainStandoff?)_UseMaintainStandoff.No);
			break;
		case 2:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.SendMessageBoxToUI("Side-level Doctrine/RoE settings cannot be inherited from elsewhere!", (Side)Subject);
				combobox.SelectedIndex = ExistingSelection;
				break;
			}
			if (!Information.IsNothing((object)SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.set_MaintainStandoff(CurrentScenario, MultipleUnits: true, ViaDoctrineForm, ViaRightColumn, (_UseMaintainStandoff?)null);
				}
			}
			this.set_MaintainStandoff(CurrentScenario, MultipleUnits: false, ViaDoctrineForm, ViaRightColumn, (_UseMaintainStandoff?)null);
			break;
		}
	}

	public void Populate_Combo_(ComboBox combobox, ref Scenario CurrentScenario, _NavigationMethod? MultipleUnitsInheritedSetting)
	{
		_NavigationMethod? navigationMethod = this.get_SubmarineNavigation(CurrentScenario, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
		DataTable dataSource = new DataTable();
		ComboBox val = combobox;
		((ListControl)val).DisplayMember = "Description";
		((ListControl)val).ValueMember = "ID";
		val.DataSource = dataSource;
		if (!SubmarineNavigation_Inherits())
		{
			_NavigationMethod? navigationMethod2 = navigationMethod;
			byte? b = (byte?)navigationMethod2;
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) == true)
			{
				val.SelectedIndex = 0;
			}
			else
			{
				b = (byte?)navigationMethod2;
				if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 3)) == true)
				{
					val.SelectedIndex = 1;
				}
				else
				{
					b = (byte?)navigationMethod2;
					if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 4)) == true)
					{
						val.SelectedIndex = 2;
					}
					else
					{
						b = (byte?)navigationMethod2;
						if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 5)) != true)
						{
							b = (byte?)navigationMethod2;
							if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 6)) != true)
							{
								b = (byte?)navigationMethod2;
								if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 7)) == true)
								{
									val.SelectedIndex = 5;
								}
							}
							else
							{
								val.SelectedIndex = 5;
							}
						}
						else
						{
							val.SelectedIndex = 3;
						}
					}
				}
			}
		}
		else
		{
			val.SelectedIndex = 4;
		}
		val = null;
	}

	public static string WRA_TargetType_String(Contact theTarget, _WRA_WeaponTargetType TargetType, bool EmitterClassifiable)
	{
		string text = "";
		if (EmitterClassifiable && theTarget != null)
		{
			switch (theTarget.TreatThisAsSurfaceEmitter(TargetType))
			{
			default:
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				break;
			case _WRA_WeaponTargetType.Emitter_Jammer:
				text = "Emitter (Jammer) + ";
				break;
			case _WRA_WeaponTargetType.Emitter_Radar:
				text = "Emitter (Radar) + ";
				break;
			case _WRA_WeaponTargetType.Emitter_Unspecified:
				text = "Emitter (Unspecified) + ";
				break;
			}
		}
		return text + smethod_5(TargetType);
	}

	private static string smethod_5(_WRA_WeaponTargetType _WRA_WeaponTargetType_0)
	{
		return _WRA_WeaponTargetType_0 switch
		{
			_WRA_WeaponTargetType.Aircraft_AEW => "Aircraft - Airborne Early Warning and Control", 
			_WRA_WeaponTargetType.Aircraft_Class1_UAS => "Aircraft - Class 1 (Small) UAV", 
			_WRA_WeaponTargetType.Aircraft_Tanker => "Aircraft - Tanker", 
			_WRA_WeaponTargetType.Aircraft_Class2_UAS => "Aircraft - Class 2 (Medium) UAV", 
			_WRA_WeaponTargetType.Aircraft_High_Perf_Recon_EW => "Aircraft - High-Performance Reconnaissance and Electronic Warfare", 
			_WRA_WeaponTargetType.Aircraft_Medium_Perf_Recon_EW => "Aircraft - Medium-Performance Reconnaissance and Electronic Warfare", 
			_WRA_WeaponTargetType.Aircraft_Low_Perf_Recon_EW => "Aircraft - Low-Performance Reconnaissance and Electronic Warfare", 
			_WRA_WeaponTargetType.Air_Contact_Unknown_Type => "Air Contact - Unknown Type", 
			_WRA_WeaponTargetType.Aircraft_Unspecified => "Aircraft - Unspecified", 
			_WRA_WeaponTargetType.Aircraft_5th_Generation => "Aircraft - Super-manouverability fighter (F-22, Eurofighter, Su-35)", 
			_WRA_WeaponTargetType.Aircraft_4th_Generation => "Aircraft - High manouverability fighter (F-14, F-15, F-16, MiG-29, Su-27)", 
			_WRA_WeaponTargetType.Aircraft_3rd_Generation => "Aircraft - Increased manouverability fighter (F-4, F-5, MiG-21, MiG-23)", 
			_WRA_WeaponTargetType.Aircraft_Less_Capable => "Aircraft - Less manouverable fighter/attack (F-111, Lightning, Su-7, MiG-17)", 
			_WRA_WeaponTargetType.Aircraft_High_Perf_Bombers => "Aircraft - High-performance bomber (B-1B, B-2A, Tu-22M", 
			_WRA_WeaponTargetType.Aircraft_Medium_Perf_Bombers => "Aircraft - Medium-performance bomber (B-52, Vulcan, Tu-16)", 
			_WRA_WeaponTargetType.Aircraft_Low_Perf_Bombers => "Aircraft - Low-performance Bomber (B-24, Canberra, Tu-95, Bison)", 
			_WRA_WeaponTargetType.Guided_Weapon_Ballistic => "Guided Weapon - Ballistic", 
			_WRA_WeaponTargetType.Guided_Weapon_Unspecified => "Guided Weapon - Unspecified", 
			_WRA_WeaponTargetType.Guided_Weapon_Supersonic_Sea_Skimming => "Guided Weapon - Supersonic Sea-Skimming", 
			_WRA_WeaponTargetType.Guided_Weapon_Subsonic_Sea_Skimming => "Guided Weapon - Subsonic Sea-Skimming", 
			_WRA_WeaponTargetType.Guided_Weapon_Supersonic => "Guided Weapon - Supersonic", 
			_WRA_WeaponTargetType.Guided_Weapon_Subsonic => "Guided Weapon - Subsonic", 
			_WRA_WeaponTargetType.Helicopter_Unspecified => "Helicopter - Unspecified", 
			_WRA_WeaponTargetType.Surface_Contact_Unknown_Type => "Surface Contact - Unknown Type", 
			_WRA_WeaponTargetType.Ship_Unspecified => "Ship - Unspecified", 
			_WRA_WeaponTargetType.Ship_Carrier_0_25000_tons => "Ship - Carrier, 0-25000 tons", 
			_WRA_WeaponTargetType.Ship_Carrier_25001_45000_tons => "Ship - Carrier, 25001-45000 tons", 
			_WRA_WeaponTargetType.Ship_Carrier_45001_95000_tons => "Ship - Carrier, 45001-95000 tons", 
			_WRA_WeaponTargetType.Ship_Carrier_95000_tons => "Ship - Carrier, 95000+ tons", 
			_WRA_WeaponTargetType.C_RAM => "Counter-Rocket, Artillery & Mortar", 
			_WRA_WeaponTargetType.Satellite_Unspecified => "Satellite - Unspecified", 
			_WRA_WeaponTargetType.Ship_Amphibious_0_500_tons => "Ship - Amphibious, 0-500 tons", 
			_WRA_WeaponTargetType.Ship_Amphibious_501_1500_tons => "Ship - Amphibious, 501-1500 tons", 
			_WRA_WeaponTargetType.Ship_Amphibious_1501_5000_tons => "Ship - Amphibious, 1501-5000 tons", 
			_WRA_WeaponTargetType.Ship_Amphibious_5001_10000_tons => "Ship - Amphibious, 5001-10000 tons", 
			_WRA_WeaponTargetType.Ship_Amphibious_10001_25000_tons => "Ship - Amphibious, 10001-25000 tons", 
			_WRA_WeaponTargetType.Ship_Amphibious_25001_45000_tons => "Ship - Amphibious, 25001-45000 tons", 
			_WRA_WeaponTargetType.Ship_Amphibious_45001_95000_tons => "Ship - Amphibious, 45001-95000 tons", 
			_WRA_WeaponTargetType.Ship_Amphibious_95000_tons => "Ship - Amphibious, 95000+ tons", 
			_WRA_WeaponTargetType.Ship_Surface_Combatant_0_500_tons => "Ship - Surface Combatant, 0-500 tons", 
			_WRA_WeaponTargetType.Ship_Surface_Combatant_501_1500_tons => "Ship - Surface Combatant, 501-1500 tons, plus Missile Boats with smaller displacement", 
			_WRA_WeaponTargetType.Ship_Surface_Combatant_1501_5000_tons => "Ship - Surface Combatant, 1501-5000 tons, plus Frigates and Corvettes with smaller displacement", 
			_WRA_WeaponTargetType.Ship_Surface_Combatant_5001_10000_tons => "Ship - Surface Combatant, 5001-10000 tons, plus Destroyers with smaller displacement", 
			_WRA_WeaponTargetType.Ship_Surface_Combatant_10001_25000_tons => "Ship - Surface Combatant, 10001-25000 tons, plus Cruisers with smaller displacement", 
			_WRA_WeaponTargetType.Ship_Surface_Combatant_25001_45000_tons => "Ship - Surface Combatant, 25001-45000 tons", 
			_WRA_WeaponTargetType.Ship_Surface_Combatant_45001_95000_tons => "Ship - Surface Combatant, 45001-95000 tons", 
			_WRA_WeaponTargetType.Ship_Surface_Combatant_95000_tons => "Ship - Surface Combatant, 95000+ tons", 
			_WRA_WeaponTargetType.Ship_Merchant_Civilian_0_500_tons => "Ship - Merchant / Civilian, 0-500 tons", 
			_WRA_WeaponTargetType.Ship_Merchant_Civilian_501_1500_tons => "Ship - Merchant / Civilian, 501-1500 tons", 
			_WRA_WeaponTargetType.Ship_Merchant_Civilian_1501_5000_tons => "Ship - Merchant / Civilian, 1501-5000 tons", 
			_WRA_WeaponTargetType.Ship_Merchant_Civilian_5001_10000_tons => "Ship - Merchant / Civilian, 5001-10000 tons", 
			_WRA_WeaponTargetType.Ship_Merchant_Civilian_10001_25000_tons => "Ship - Merchant / Civilian, 10001-25000 tons", 
			_WRA_WeaponTargetType.Ship_Merchant_Civilian_25001_45000_tons => "Ship - Merchant / Civilian, 25001-45000 tons", 
			_WRA_WeaponTargetType.Ship_Merchant_Civilian_45001_95000_tons => "Ship - Merchant / Civilian, 45001-95000 tons", 
			_WRA_WeaponTargetType.Ship_Merchant_Civilian_95000_tons => "Ship - Merchant / Civilian, 95000+ tons", 
			_WRA_WeaponTargetType.Ship_Auxiliary_0_500_tons => "Ship - Auxiliary, 0-500 tons", 
			_WRA_WeaponTargetType.Ship_Auxiliary_501_1500_tons => "Ship - Auxiliary, 501-1500 tons", 
			_WRA_WeaponTargetType.Ship_Auxiliary_1501_5000_tons => "Ship - Auxiliary, 1501-5000 tons", 
			_WRA_WeaponTargetType.Ship_Auxiliary_5001_10000_tons => "Ship - Auxiliary, 5001-10000 tons", 
			_WRA_WeaponTargetType.Ship_Auxiliary_10001_25000_tons => "Ship - Auxiliary, 10001-25000 tons", 
			_WRA_WeaponTargetType.Ship_Auxiliary_25001_45000_tons => "Ship - Auxiliary, 25001-45000 tons", 
			_WRA_WeaponTargetType.Ship_Auxiliary_45001_95000_tons => "Ship - Auxiliary, 45001-95000 tons", 
			_WRA_WeaponTargetType.Ship_Auxiliary_95000_tons => "Ship - Auxiliary, 95000+ tons", 
			_WRA_WeaponTargetType.Mobile_Target_Soft_Unspecified => "Mobile Target - Soft - Unspecified", 
			_WRA_WeaponTargetType.Mobile_Target_Soft_Mobile_Vehicle => "Mobile Target - Soft - Mobile Vehicle(s)", 
			_WRA_WeaponTargetType.Mobile_Target_Soft_Mobile_Personnel => "Mobile Target - Soft - Mobile Personnel", 
			_WRA_WeaponTargetType.Emitter_Jammer => "Emitter - Jammer", 
			_WRA_WeaponTargetType.Emitter_Radar => "Emitter - Radar", 
			_WRA_WeaponTargetType.Air_Base_Single_Unit_Airfield => "Air Base (Single-Unit Airfield)", 
			_WRA_WeaponTargetType.Underwater_Structure => "Underwater Structure", 
			_WRA_WeaponTargetType.Mobile_Target_Hardened_Mobile_Vehicle => "Mobile Target - Hardened - Mobile Vehicle(s)", 
			_WRA_WeaponTargetType.Mobile_Target_Hardened_Unspecified => "Mobile Target - Hardened - Unspecified", 
			_WRA_WeaponTargetType.Emitter_Unspecified => "Emitter - Unspecified", 
			_WRA_WeaponTargetType.Runway_Facility_Unspecified => "Runway Facility - Unspecified", 
			_WRA_WeaponTargetType.Runway => "Runway", 
			_WRA_WeaponTargetType.Runway_Grade_Taxiway => "Runway-Grade Taxiway", 
			_WRA_WeaponTargetType.Runway_Access_Point => "Runway Access Point", 
			_WRA_WeaponTargetType.Land_Structure_Hardened_Unspecified => "Land Structure - Hardened - Unspecified", 
			_WRA_WeaponTargetType.Land_Structure_Hardened_Building_Surface => "Land Structure - Hardened - Building (Surface)", 
			_WRA_WeaponTargetType.Land_Structure_Hardened_Building_Reveted => "Land Structure - Hardened - Building (Reveted)", 
			_WRA_WeaponTargetType.Land_Structure_Hardened_Building_Bunker => "Land Structure - Hardened - Building (Bunker)", 
			_WRA_WeaponTargetType.Land_Structure_Hardened_Building_Underground => "Land Structure - Hardened - Building (Underground)", 
			_WRA_WeaponTargetType.Land_Structure_Hardened_Structure_Open => "Land Structure - Hardened - Structure (Open)", 
			_WRA_WeaponTargetType.Land_Structure_Hardened_Structure_Reveted => "Land Structure - Hardened - Structure (Reveted)", 
			_WRA_WeaponTargetType.Land_Contact_Unknown_Type => "Land Contact - Unknown Type", 
			_WRA_WeaponTargetType.Land_Structure_Soft_Unspecified => "Land Structure - Soft - Unspecified", 
			_WRA_WeaponTargetType.Land_Structure_Soft_Building_Surface => "Land Structure - Soft - Building (Surface)", 
			_WRA_WeaponTargetType.Land_Structure_Soft_Building_Reveted => "Land Structure - Soft - Building (Reveted)", 
			_WRA_WeaponTargetType.Land_Structure_Soft_Structure_Open => "Land Structure - Soft - Structure (Open)", 
			_WRA_WeaponTargetType.Land_Structure_Soft_Structure_Reveted => "Land Structure - Soft - Structure (Reveted)", 
			_WRA_WeaponTargetType.Land_Structure_Soft_Aerostat_Moring => "Land Structure - Soft - Aerostat Moring", 
			_WRA_WeaponTargetType.Submarine_Unspecified => "Submarine - Unspecified", 
			_WRA_WeaponTargetType.Subsurface_Contact_Unknown_Type => "Sub-Surface Contact - Unknown Type", 
			_WRA_WeaponTargetType.Submarine_Surfaced => "Ship - Surfaced Submarine", 
			_ => _WRA_WeaponTargetType_0.ToString(), 
		};
	}

	public static string WRA_WeaponQty_String(int? WeaponsPerSalvoValue, ActiveUnit myUnit, Contact theTarget, Weapon theWeapon)
	{
		int? num = WeaponsPerSalvoValue;
		int? num2 = num;
		if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2 == -99)) == true)
		{
			return "Fire all weapons per salvo";
		}
		num2 = num;
		if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 0) : ((bool?)null)) == true)
		{
			return "Do not use weapon against this target type";
		}
		num2 = num;
		if ((num2.HasValue ? new bool?(num2 == -2) : ((bool?)null)) == true)
		{
			int? num3 = myUnit.get_UnitSide(SetSideOnly: false).ConvertSalvoWeaponQty_To_ActualQuantity(WeaponsPerSalvoValue, ref myUnit, ref theTarget, ref theWeapon);
			num2 = num3;
			if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2 == 1)) != true)
			{
				return ((!num3.HasValue) ? null : Conversions.ToString(num3.GetValueOrDefault())) + "x rnds per salvo (using target's Missile Defence value)";
			}
			return (num3.HasValue ? Conversions.ToString(num3.GetValueOrDefault()) : null) + "x rnd per salvo (using target's Missile Defence value)";
		}
		num2 = num;
		if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2 == -3)) == true)
		{
			int? num4 = myUnit.get_UnitSide(SetSideOnly: false).ConvertSalvoWeaponQty_To_ActualQuantity(WeaponsPerSalvoValue, ref myUnit, ref theTarget, ref theWeapon);
			num2 = num4;
			if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2 == 1)) == true)
			{
				return ((!num4.HasValue) ? null : Conversions.ToString(num4.GetValueOrDefault())) + "x rnd per salvo (using twice the target's Missile Defence value)";
			}
			return (num4.HasValue ? Conversions.ToString(num4.GetValueOrDefault()) : null) + "x rnds per salvo (using twice the target's Missile Defence value)";
		}
		num2 = num;
		if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2 == -4)) != true)
		{
			num2 = num;
			if ((num2.HasValue ? new bool?(num2 == -5) : ((bool?)null)) == true)
			{
				int? num5 = myUnit.get_UnitSide(SetSideOnly: false).ConvertSalvoWeaponQty_To_ActualQuantity(WeaponsPerSalvoValue, ref myUnit, ref theTarget, ref theWeapon);
				num2 = num5;
				if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2 == 1)) != true)
				{
					return (num5.HasValue ? Conversions.ToString(num5.GetValueOrDefault()) : null) + "x rnds per salvo (using half the target's Missile Defence value)";
				}
				return (num5.HasValue ? Conversions.ToString(num5.GetValueOrDefault()) : null) + "x rnd per salvo (using half the target's Missile Defence value)";
			}
			num2 = num;
			if ((num2.HasValue ? new bool?(num2 == -6) : ((bool?)null)) == true)
			{
				int? num6 = myUnit.get_UnitSide(SetSideOnly: false).ConvertSalvoWeaponQty_To_ActualQuantity(WeaponsPerSalvoValue, ref myUnit, ref theTarget, ref theWeapon);
				num2 = num6;
				if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2 == 1)) != true)
				{
					return ((!num6.HasValue) ? null : Conversions.ToString(num6.GetValueOrDefault())) + "x rnds per salvo (using one-fourth the target's Missile Defence value)";
				}
				return (num6.HasValue ? Conversions.ToString(num6.GetValueOrDefault()) : null) + "x rnd per salvo (using one-fourth the target's Missile Defence value)";
			}
			num2 = num;
			if ((num2.HasValue ? new bool?(num2 == -98) : ((bool?)null)) == true)
			{
				return "Not defined";
			}
			num2 = num;
			if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2 == -1)) == true)
			{
				int? num7 = myUnit.get_UnitSide(SetSideOnly: false).ConvertSalvoWeaponQty_To_ActualQuantity(WeaponsPerSalvoValue, ref myUnit, ref theTarget, ref theWeapon);
				num2 = num7;
				if ((num2.HasValue ? new bool?(num2 == 1) : ((bool?)null)) != true)
				{
					return (num7.HasValue ? Conversions.ToString(num7.GetValueOrDefault()) : null) + "x rnds per salvo (using system default)";
				}
				return ((!num7.HasValue) ? null : Conversions.ToString(num7.GetValueOrDefault())) + "x rnd per salvo (using system default)";
			}
			num2 = num;
			if ((num2.HasValue ? new bool?(num2 == -100) : ((bool?)null)) == true)
			{
				return "Various weapon quantities";
			}
			num2 = WeaponsPerSalvoValue;
			if ((num2.HasValue ? new bool?(num2 == 1) : ((bool?)null)) == true)
			{
				return WeaponsPerSalvoValue + "x rnd per salvo";
			}
			return WeaponsPerSalvoValue + "x rnds per salvo";
		}
		int? num8 = myUnit.get_UnitSide(SetSideOnly: false).ConvertSalvoWeaponQty_To_ActualQuantity(WeaponsPerSalvoValue, ref myUnit, ref theTarget, ref theWeapon);
		num2 = num8;
		if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2 == 1)) != true)
		{
			return (num8.HasValue ? Conversions.ToString(num8.GetValueOrDefault()) : null) + "x rnds per salvo (using four times the target's Missile Defence value)";
		}
		return (num8.HasValue ? Conversions.ToString(num8.GetValueOrDefault()) : null) + "x rnd per salvo (using four times the target's Missile Defence value)";
	}

	internal string WRA_FiringRange_String(float? FiringRange)
	{
		if (!FiringRange.HasValue)
		{
			FiringRange = -99f;
		}
		float? num = FiringRange;
		float? num2 = num;
		if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2.GetValueOrDefault() == 0f)) != true)
		{
			num2 = num;
			if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2.GetValueOrDefault() == -99f)) == true)
			{
				return "Weapon launch at max range";
			}
			num2 = num;
			if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -98f) : ((bool?)null)) == true)
			{
				return "Not defined";
			}
			num2 = num;
			if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -100f) : ((bool?)null)) == true)
			{
				return "Various firing ranges";
			}
			num2 = num;
			if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -95f) : ((bool?)null)) != true)
			{
				num2 = num;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -96f) : ((bool?)null)) == true)
				{
					return "50% of max range";
				}
				num2 = num;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -97f) : ((bool?)null)) == true)
				{
					return "75% of max range";
				}
				num2 = num;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -102f) : ((bool?)null)) == true)
				{
					return "No-Escape Zone";
				}
				return (FiringRange.HasValue ? Conversions.ToString(FiringRange.GetValueOrDefault()) : null) + "nm maximum firing range";
			}
			return "25% of max range";
		}
		return "No automatic fire against this target type, manual fire only";
	}

	internal int? WeaponsPerSalvoSelection_To_WeaponQty(ref _WRA_WeaponTargetType WeaponTargetType, ref object WeaponsPerSalvoValue)
	{
		int? result = default(int?);
		try
		{
			_WRA_WeaponTargetType wRA_WeaponTargetType = WeaponTargetType;
			int value;
			if (wRA_WeaponTargetType > _WRA_WeaponTargetType.Ship_Auxiliary_95000_tons)
			{
				if (wRA_WeaponTargetType > _WRA_WeaponTargetType.Runway_Access_Point)
				{
					if (wRA_WeaponTargetType > _WRA_WeaponTargetType.Emitter_Jammer)
					{
						if (wRA_WeaponTargetType <= _WRA_WeaponTargetType.Mobile_Target_Hardened_Mobile_Vehicle)
						{
							if ((uint)(wRA_WeaponTargetType - 5400) > 2u && (uint)(wRA_WeaponTargetType - 5500) > 1u)
							{
								goto IL_05be;
							}
						}
						else if (wRA_WeaponTargetType != _WRA_WeaponTargetType.Underwater_Structure && wRA_WeaponTargetType != _WRA_WeaponTargetType.Air_Base_Single_Unit_Airfield)
						{
							value = 0;
							goto IL_05de;
						}
					}
					else if (wRA_WeaponTargetType != _WRA_WeaponTargetType.Emitter_Unspecified && wRA_WeaponTargetType != _WRA_WeaponTargetType.Emitter_Radar && wRA_WeaponTargetType != _WRA_WeaponTargetType.Emitter_Jammer)
					{
						value = 0;
						goto IL_05de;
					}
				}
				else
				{
					switch (wRA_WeaponTargetType)
					{
					case _WRA_WeaponTargetType.Land_Structure_Soft_Unspecified:
					case _WRA_WeaponTargetType.Land_Structure_Soft_Building_Surface:
					case _WRA_WeaponTargetType.Land_Structure_Soft_Building_Reveted:
					case _WRA_WeaponTargetType.Land_Structure_Soft_Building_Bunker:
					case _WRA_WeaponTargetType.Land_Structure_Soft_Building_Underground:
					case _WRA_WeaponTargetType.Land_Structure_Soft_Structure_Open:
					case _WRA_WeaponTargetType.Land_Structure_Soft_Structure_Reveted:
					case _WRA_WeaponTargetType.Land_Structure_Soft_Aerostat_Moring:
					case _WRA_WeaponTargetType.Land_Structure_Hardened_Unspecified:
					case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Surface:
					case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Reveted:
					case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Bunker:
					case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Underground:
					case _WRA_WeaponTargetType.Land_Structure_Hardened_Structure_Open:
					case _WRA_WeaponTargetType.Land_Structure_Hardened_Structure_Reveted:
					case _WRA_WeaponTargetType.Runway_Facility_Unspecified:
					case _WRA_WeaponTargetType.Runway:
					case _WRA_WeaponTargetType.Runway_Grade_Taxiway:
					case _WRA_WeaponTargetType.Runway_Access_Point:
						break;
					case _WRA_WeaponTargetType.Subsurface_Contact_Unknown_Type:
					case _WRA_WeaponTargetType.Submarine_Unspecified:
						goto IL_022e;
					case _WRA_WeaponTargetType.Ship_Merchant_Civilian_0_500_tons:
					case _WRA_WeaponTargetType.Ship_Merchant_Civilian_501_1500_tons:
					case _WRA_WeaponTargetType.Ship_Merchant_Civilian_1501_5000_tons:
					case _WRA_WeaponTargetType.Ship_Merchant_Civilian_5001_10000_tons:
					case _WRA_WeaponTargetType.Ship_Merchant_Civilian_10001_25000_tons:
					case _WRA_WeaponTargetType.Ship_Merchant_Civilian_25001_45000_tons:
					case _WRA_WeaponTargetType.Ship_Merchant_Civilian_45001_95000_tons:
					case _WRA_WeaponTargetType.Ship_Merchant_Civilian_95000_tons:
					case _WRA_WeaponTargetType.Submarine_Surfaced:
						goto IL_030e;
					case _WRA_WeaponTargetType.Land_Contact_Unknown_Type:
						goto IL_0458;
					default:
						goto IL_05be;
					}
				}
				switch (Conversions.ToInteger(WeaponsPerSalvoValue))
				{
				default:
					result = null;
					break;
				case 2:
					result = 0;
					return result;
				case 3:
					result = -2;
					return result;
				case 4:
					result = -3;
					return result;
				case 5:
					result = -4;
					return result;
				case 6:
					result = -5;
					return result;
				case 7:
					result = -6;
					return result;
				case 8:
					result = 1;
					return result;
				case 9:
					result = 2;
					return result;
				case 10:
					result = 3;
					return result;
				case 11:
					result = 4;
					return result;
				case 12:
					result = 5;
					return result;
				case 13:
					result = 6;
					return result;
				case 14:
					result = 7;
					return result;
				case 15:
					result = 8;
					return result;
				case 16:
					result = -99;
					return result;
				case 17:
					result = -100;
					return result;
				}
			}
			else
			{
				if (wRA_WeaponTargetType <= _WRA_WeaponTargetType.Guided_Weapon_Subsonic)
				{
					if (wRA_WeaponTargetType <= _WRA_WeaponTargetType.Aircraft_Low_Perf_Recon_EW)
					{
						if ((uint)(wRA_WeaponTargetType - 1999) > 5u && (uint)(wRA_WeaponTargetType - 2011) > 2u && (uint)(wRA_WeaponTargetType - 2021) > 2u)
						{
							goto IL_05be;
						}
					}
					else if ((uint)(wRA_WeaponTargetType - 2031) > 3u && wRA_WeaponTargetType != _WRA_WeaponTargetType.Helicopter_Unspecified && (uint)(wRA_WeaponTargetType - 2200) > 4u)
					{
						value = 0;
						goto IL_05de;
					}
					goto IL_05e9;
				}
				if (wRA_WeaponTargetType > _WRA_WeaponTargetType.Surface_Contact_Unknown_Type)
				{
					if (wRA_WeaponTargetType <= _WRA_WeaponTargetType.Ship_Surface_Combatant_95000_tons)
					{
						if ((uint)(wRA_WeaponTargetType - 3000) <= 4u || (uint)(wRA_WeaponTargetType - 3101) <= 7u)
						{
							goto IL_030e;
						}
					}
					else if ((uint)(wRA_WeaponTargetType - 3201) <= 7u || (uint)(wRA_WeaponTargetType - 3301) <= 7u)
					{
						goto IL_030e;
					}
					goto IL_05be;
				}
				if (wRA_WeaponTargetType == _WRA_WeaponTargetType.Guided_Weapon_Ballistic)
				{
					goto IL_05e9;
				}
				if (wRA_WeaponTargetType != _WRA_WeaponTargetType.Satellite_Unspecified)
				{
					if (wRA_WeaponTargetType == _WRA_WeaponTargetType.Surface_Contact_Unknown_Type)
					{
						goto IL_0458;
					}
					value = 0;
					goto IL_05de;
				}
				switch (Conversions.ToInteger(WeaponsPerSalvoValue))
				{
				default:
					result = null;
					break;
				case 2:
					result = 0;
					return result;
				case 3:
					result = 1;
					return result;
				case 4:
					result = 2;
					return result;
				case 5:
					result = -99;
					return result;
				case 6:
					result = -100;
					return result;
				}
			}
			goto end_IL_0001;
			IL_05e9:
			switch (Conversions.ToInteger(WeaponsPerSalvoValue))
			{
			default:
				result = null;
				break;
			case 2:
				result = 0;
				return result;
			case 3:
				result = 1;
				return result;
			case 4:
				result = 2;
				return result;
			case 5:
				result = 3;
				return result;
			case 6:
				result = 4;
				return result;
			case 7:
				result = -99;
				return result;
			case 8:
				result = -100;
				return result;
			}
			goto end_IL_0001;
			IL_0458:
			switch (Conversions.ToInteger(WeaponsPerSalvoValue))
			{
			default:
				result = null;
				break;
			case 2:
				result = 0;
				return result;
			case 3:
				result = 1;
				return result;
			case 4:
				result = 2;
				return result;
			case 5:
				result = 3;
				return result;
			case 6:
				result = 4;
				return result;
			case 7:
				result = 5;
				return result;
			case 8:
				result = 6;
				return result;
			case 9:
				result = 7;
				return result;
			case 10:
				result = 8;
				return result;
			case 11:
				result = -99;
				return result;
			case 12:
				result = -100;
				return result;
			}
			goto end_IL_0001;
			IL_022e:
			switch (Conversions.ToInteger(WeaponsPerSalvoValue))
			{
			default:
				result = null;
				break;
			case 2:
				result = 0;
				return result;
			case 3:
				result = 1;
				return result;
			case 4:
				result = 2;
				return result;
			case 5:
				result = 3;
				return result;
			case 6:
				result = 4;
				return result;
			case 7:
				result = -99;
				return result;
			case 8:
				result = -100;
				return result;
			}
			goto end_IL_0001;
			IL_030e:
			switch (Conversions.ToInteger(WeaponsPerSalvoValue))
			{
			default:
				result = null;
				break;
			case 2:
				result = 0;
				return result;
			case 3:
				result = -2;
				return result;
			case 4:
				result = -3;
				return result;
			case 5:
				result = -4;
				return result;
			case 6:
				result = -5;
				return result;
			case 7:
				result = -6;
				return result;
			case 8:
				result = 1;
				return result;
			case 9:
				result = 2;
				return result;
			case 10:
				result = 3;
				return result;
			case 11:
				result = 4;
				return result;
			case 12:
				result = 5;
				return result;
			case 13:
				result = 6;
				return result;
			case 14:
				result = 7;
				return result;
			case 15:
				result = 8;
				return result;
			case 16:
				result = -99;
				return result;
			case 17:
				result = -100;
				return result;
			}
			goto end_IL_0001;
			IL_05be:
			value = 0;
			goto IL_05de;
			IL_05de:
			result = value;
			return result;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101197", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal int WeaponQty_To_WeaponsPerSalvoSelection(ref _WRA_WeaponTargetType WeaponTargetType, int? WeaponQty)
	{
		int result;
		try
		{
			_WRA_WeaponTargetType wRA_WeaponTargetType = WeaponTargetType;
			int num;
			if (wRA_WeaponTargetType > _WRA_WeaponTargetType.Ship_Auxiliary_95000_tons)
			{
				if (wRA_WeaponTargetType > _WRA_WeaponTargetType.Runway_Access_Point)
				{
					if (wRA_WeaponTargetType <= _WRA_WeaponTargetType.Emitter_Jammer)
					{
						if (wRA_WeaponTargetType != _WRA_WeaponTargetType.Emitter_Unspecified && wRA_WeaponTargetType != _WRA_WeaponTargetType.Emitter_Radar && wRA_WeaponTargetType != _WRA_WeaponTargetType.Emitter_Jammer)
						{
							num = 0;
							goto IL_0e8c;
						}
					}
					else if (wRA_WeaponTargetType <= _WRA_WeaponTargetType.Mobile_Target_Hardened_Mobile_Vehicle)
					{
						if ((uint)(wRA_WeaponTargetType - 5400) > 2u && (uint)(wRA_WeaponTargetType - 5500) > 1u)
						{
							goto IL_0e8b;
						}
					}
					else if (wRA_WeaponTargetType != _WRA_WeaponTargetType.Underwater_Structure && wRA_WeaponTargetType != _WRA_WeaponTargetType.Air_Base_Single_Unit_Airfield)
					{
						num = 0;
						goto IL_0e8c;
					}
					goto IL_0840;
				}
				switch (wRA_WeaponTargetType)
				{
				case _WRA_WeaponTargetType.Land_Contact_Unknown_Type:
					break;
				case _WRA_WeaponTargetType.Land_Structure_Soft_Unspecified:
				case _WRA_WeaponTargetType.Land_Structure_Soft_Building_Surface:
				case _WRA_WeaponTargetType.Land_Structure_Soft_Building_Reveted:
				case _WRA_WeaponTargetType.Land_Structure_Soft_Building_Bunker:
				case _WRA_WeaponTargetType.Land_Structure_Soft_Building_Underground:
				case _WRA_WeaponTargetType.Land_Structure_Soft_Structure_Open:
				case _WRA_WeaponTargetType.Land_Structure_Soft_Structure_Reveted:
				case _WRA_WeaponTargetType.Land_Structure_Soft_Aerostat_Moring:
				case _WRA_WeaponTargetType.Land_Structure_Hardened_Unspecified:
				case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Surface:
				case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Reveted:
				case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Bunker:
				case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Underground:
				case _WRA_WeaponTargetType.Land_Structure_Hardened_Structure_Open:
				case _WRA_WeaponTargetType.Land_Structure_Hardened_Structure_Reveted:
				case _WRA_WeaponTargetType.Runway_Facility_Unspecified:
				case _WRA_WeaponTargetType.Runway:
				case _WRA_WeaponTargetType.Runway_Grade_Taxiway:
				case _WRA_WeaponTargetType.Runway_Access_Point:
					goto IL_0840;
				case _WRA_WeaponTargetType.Subsurface_Contact_Unknown_Type:
				case _WRA_WeaponTargetType.Submarine_Unspecified:
					goto IL_0c8d;
				default:
					goto IL_0e8b;
				case _WRA_WeaponTargetType.Ship_Merchant_Civilian_0_500_tons:
				case _WRA_WeaponTargetType.Ship_Merchant_Civilian_501_1500_tons:
				case _WRA_WeaponTargetType.Ship_Merchant_Civilian_1501_5000_tons:
				case _WRA_WeaponTargetType.Ship_Merchant_Civilian_5001_10000_tons:
				case _WRA_WeaponTargetType.Ship_Merchant_Civilian_10001_25000_tons:
				case _WRA_WeaponTargetType.Ship_Merchant_Civilian_25001_45000_tons:
				case _WRA_WeaponTargetType.Ship_Merchant_Civilian_45001_95000_tons:
				case _WRA_WeaponTargetType.Ship_Merchant_Civilian_95000_tons:
				case _WRA_WeaponTargetType.Submarine_Surfaced:
					goto IL_0e92;
				}
				goto IL_0547;
			}
			if (wRA_WeaponTargetType <= _WRA_WeaponTargetType.Guided_Weapon_Subsonic)
			{
				if (wRA_WeaponTargetType > _WRA_WeaponTargetType.Aircraft_Low_Perf_Recon_EW)
				{
					if ((uint)(wRA_WeaponTargetType - 2031) > 3u && wRA_WeaponTargetType != _WRA_WeaponTargetType.Helicopter_Unspecified && (uint)(wRA_WeaponTargetType - 2200) > 4u)
					{
						num = 0;
						goto IL_0e8c;
					}
				}
				else if ((uint)(wRA_WeaponTargetType - 1999) > 5u && (uint)(wRA_WeaponTargetType - 2011) > 2u && (uint)(wRA_WeaponTargetType - 2021) > 2u)
				{
					goto IL_0e8b;
				}
				goto IL_0269;
			}
			if (wRA_WeaponTargetType > _WRA_WeaponTargetType.Surface_Contact_Unknown_Type)
			{
				if (wRA_WeaponTargetType <= _WRA_WeaponTargetType.Ship_Surface_Combatant_95000_tons)
				{
					if ((uint)(wRA_WeaponTargetType - 3000) > 4u && (uint)(wRA_WeaponTargetType - 3101) > 7u)
					{
						goto IL_0e8b;
					}
				}
				else if ((uint)(wRA_WeaponTargetType - 3201) > 7u && (uint)(wRA_WeaponTargetType - 3301) > 7u)
				{
					num = 0;
					goto IL_0e8c;
				}
				goto IL_0e92;
			}
			if (wRA_WeaponTargetType == _WRA_WeaponTargetType.Guided_Weapon_Ballistic)
			{
				goto IL_0269;
			}
			if (wRA_WeaponTargetType != _WRA_WeaponTargetType.Satellite_Unspecified)
			{
				if (wRA_WeaponTargetType == _WRA_WeaponTargetType.Surface_Contact_Unknown_Type)
				{
					goto IL_0547;
				}
				num = 0;
				goto IL_0e8c;
			}
			int? num2 = WeaponQty;
			int? num3 = num2;
			if ((num3.HasValue ? new bool?(num3 == -1) : ((bool?)null)) == true)
			{
				result = 1;
			}
			else
			{
				num3 = num2;
				if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == 0) : ((bool?)null)) == true)
				{
					result = 2;
				}
				else
				{
					num3 = num2;
					if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 1)) == true)
					{
						result = 3;
					}
					else
					{
						num3 = num2;
						if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 2)) != true)
						{
							num3 = num2;
							if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == -99)) == true)
							{
								result = 5;
							}
							else
							{
								num3 = num2;
								result = (((num3.HasValue ? new bool?(num3 == -100) : ((bool?)null)) == true) ? 6 : (((object)SubjectType == typeof(Side)) ? 1 : 0));
							}
						}
						else
						{
							result = 4;
						}
					}
				}
			}
			goto end_IL_0001;
			IL_0840:
			int? num4 = WeaponQty;
			int? num5 = num4;
			if ((num5.HasValue ? new bool?(num5 == -1) : ((bool?)null)) == true)
			{
				result = 1;
			}
			else
			{
				num5 = num4;
				if ((num5.HasValue ? new bool?(num5.GetValueOrDefault() == 0) : ((bool?)null)) != true)
				{
					num5 = num4;
					if (((!num5.HasValue) ? ((bool?)null) : new bool?(num5 == -2)) == true)
					{
						result = 3;
					}
					else
					{
						num5 = num4;
						if ((num5.HasValue ? new bool?(num5 == -3) : ((bool?)null)) != true)
						{
							num5 = num4;
							if ((num5.HasValue ? new bool?(num5 == -4) : ((bool?)null)) == true)
							{
								result = 5;
							}
							else
							{
								num5 = num4;
								if ((num5.HasValue ? new bool?(num5 == -5) : ((bool?)null)) == true)
								{
									result = 6;
								}
								else
								{
									num5 = num4;
									if ((num5.HasValue ? new bool?(num5 == -6) : ((bool?)null)) != true)
									{
										num5 = num4;
										if (((!num5.HasValue) ? ((bool?)null) : new bool?(num5 == 1)) == true)
										{
											result = 8;
										}
										else
										{
											num5 = num4;
											if ((num5.HasValue ? new bool?(num5 == 2) : ((bool?)null)) == true)
											{
												result = 9;
											}
											else
											{
												num5 = num4;
												if (((!num5.HasValue) ? ((bool?)null) : new bool?(num5 == 3)) == true)
												{
													result = 10;
												}
												else
												{
													num5 = num4;
													if (((!num5.HasValue) ? ((bool?)null) : new bool?(num5 == 4)) != true)
													{
														num5 = num4;
														if ((num5.HasValue ? new bool?(num5 == 5) : ((bool?)null)) != true)
														{
															num5 = num4;
															if (((!num5.HasValue) ? ((bool?)null) : new bool?(num5 == 6)) != true)
															{
																num5 = num4;
																if (((!num5.HasValue) ? ((bool?)null) : new bool?(num5 == 7)) != true)
																{
																	num5 = num4;
																	if ((num5.HasValue ? new bool?(num5 == 8) : ((bool?)null)) != true)
																	{
																		num5 = num4;
																		if ((num5.HasValue ? new bool?(num5 == -99) : ((bool?)null)) == true)
																		{
																			result = 16;
																		}
																		else
																		{
																			num5 = num4;
																			result = ((((!num5.HasValue) ? ((bool?)null) : new bool?(num5 == -100)) == true) ? 17 : (((object)SubjectType == typeof(Side)) ? 1 : 0));
																		}
																	}
																	else
																	{
																		result = 15;
																	}
																}
																else
																{
																	result = 14;
																}
															}
															else
															{
																result = 13;
															}
														}
														else
														{
															result = 12;
														}
													}
													else
													{
														result = 11;
													}
												}
											}
										}
									}
									else
									{
										result = 7;
									}
								}
							}
						}
						else
						{
							result = 4;
						}
					}
				}
				else
				{
					result = 2;
				}
			}
			goto end_IL_0001;
			IL_0e8c:
			result = num;
			goto end_IL_0001;
			IL_0c8d:
			int? num6 = WeaponQty;
			num4 = num6;
			if ((num4.HasValue ? new bool?(num4 == -1) : ((bool?)null)) == true)
			{
				result = 1;
			}
			else
			{
				num4 = num6;
				if (((!num4.HasValue) ? ((bool?)null) : new bool?(num4.GetValueOrDefault() == 0)) == true)
				{
					result = 2;
				}
				else
				{
					num4 = num6;
					if ((num4.HasValue ? new bool?(num4 == 1) : ((bool?)null)) == true)
					{
						result = 3;
					}
					else
					{
						num4 = num6;
						if (((!num4.HasValue) ? ((bool?)null) : new bool?(num4 == 2)) != true)
						{
							num4 = num6;
							if (((!num4.HasValue) ? ((bool?)null) : new bool?(num4 == 3)) != true)
							{
								num4 = num6;
								if ((num4.HasValue ? new bool?(num4 == 4) : ((bool?)null)) != true)
								{
									num4 = num6;
									if (((!num4.HasValue) ? ((bool?)null) : new bool?(num4 == -99)) == true)
									{
										result = 7;
									}
									else
									{
										num4 = num6;
										result = ((((!num4.HasValue) ? ((bool?)null) : new bool?(num4 == -100)) == true) ? 8 : (((object)SubjectType == typeof(Side)) ? 1 : 0));
									}
								}
								else
								{
									result = 6;
								}
							}
							else
							{
								result = 5;
							}
						}
						else
						{
							result = 4;
						}
					}
				}
			}
			goto end_IL_0001;
			IL_0e8b:
			num = 0;
			goto IL_0e8c;
			IL_0547:
			num3 = WeaponQty;
			int? num7 = num3;
			if ((num7.HasValue ? new bool?(num7 == -1) : ((bool?)null)) != true)
			{
				num7 = num3;
				if (((!num7.HasValue) ? ((bool?)null) : new bool?(num7.GetValueOrDefault() == 0)) != true)
				{
					num7 = num3;
					if (((!num7.HasValue) ? ((bool?)null) : new bool?(num7 == 1)) != true)
					{
						num7 = num3;
						if ((num7.HasValue ? new bool?(num7 == 2) : ((bool?)null)) != true)
						{
							num7 = num3;
							if ((num7.HasValue ? new bool?(num7 == 3) : ((bool?)null)) == true)
							{
								result = 5;
							}
							else
							{
								num7 = num3;
								if ((num7.HasValue ? new bool?(num7 == 4) : ((bool?)null)) != true)
								{
									num7 = num3;
									if ((num7.HasValue ? new bool?(num7 == 5) : ((bool?)null)) == true)
									{
										result = 7;
									}
									else
									{
										num7 = num3;
										if ((num7.HasValue ? new bool?(num7 == 6) : ((bool?)null)) != true)
										{
											num7 = num3;
											if (((!num7.HasValue) ? ((bool?)null) : new bool?(num7 == 7)) != true)
											{
												num7 = num3;
												if ((num7.HasValue ? new bool?(num7 == 8) : ((bool?)null)) != true)
												{
													num7 = num3;
													if (((!num7.HasValue) ? ((bool?)null) : new bool?(num7 == -99)) != true)
													{
														num7 = num3;
														result = (((num7.HasValue ? new bool?(num7 == -100) : ((bool?)null)) == true) ? 12 : (((object)SubjectType == typeof(Side)) ? 1 : 0));
													}
													else
													{
														result = 11;
													}
												}
												else
												{
													result = 10;
												}
											}
											else
											{
												result = 9;
											}
										}
										else
										{
											result = 8;
										}
									}
								}
								else
								{
									result = 6;
								}
							}
						}
						else
						{
							result = 4;
						}
					}
					else
					{
						result = 3;
					}
				}
				else
				{
					result = 2;
				}
			}
			else
			{
				result = 1;
			}
			goto end_IL_0001;
			IL_0269:
			num2 = WeaponQty;
			if ((num2.HasValue ? new bool?(num2 == -1) : ((bool?)null)) == true)
			{
				result = 1;
			}
			else
			{
				num2 = WeaponQty;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 0) : ((bool?)null)) != true)
				{
					num2 = WeaponQty;
					if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2 == 1)) != true)
					{
						num2 = WeaponQty;
						if ((num2.HasValue ? new bool?(num2 == 2) : ((bool?)null)) == true)
						{
							result = 4;
						}
						else
						{
							num2 = WeaponQty;
							if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2 == 3)) == true)
							{
								result = 5;
							}
							else
							{
								num2 = WeaponQty;
								if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2 == 4)) == true)
								{
									result = 6;
								}
								else
								{
									num2 = WeaponQty;
									if ((num2.HasValue ? new bool?(num2 == -99) : ((bool?)null)) == true)
									{
										result = 7;
									}
									else
									{
										num2 = WeaponQty;
										result = (((num2.HasValue ? new bool?(num2 == -100) : ((bool?)null)) == true) ? 8 : (((object)SubjectType == typeof(Side)) ? 1 : 0));
									}
								}
							}
						}
					}
					else
					{
						result = 3;
					}
				}
				else
				{
					result = 2;
				}
			}
			goto end_IL_0001;
			IL_0e92:
			num7 = WeaponQty;
			num6 = num7;
			if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == -1)) != true)
			{
				num6 = num7;
				if ((num6.HasValue ? new bool?(num6.GetValueOrDefault() == 0) : ((bool?)null)) == true)
				{
					result = 2;
				}
				else
				{
					num6 = num7;
					if ((num6.HasValue ? new bool?(num6 == -2) : ((bool?)null)) == true)
					{
						result = 3;
					}
					else
					{
						num6 = num7;
						if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == -3)) == true)
						{
							result = 4;
						}
						else
						{
							num6 = num7;
							if ((num6.HasValue ? new bool?(num6 == -4) : ((bool?)null)) == true)
							{
								result = 5;
							}
							else
							{
								num6 = num7;
								if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == -5)) != true)
								{
									num6 = num7;
									if ((num6.HasValue ? new bool?(num6 == -6) : ((bool?)null)) != true)
									{
										num6 = num7;
										if ((num6.HasValue ? new bool?(num6 == 1) : ((bool?)null)) != true)
										{
											num6 = num7;
											if ((num6.HasValue ? new bool?(num6 == 2) : ((bool?)null)) == true)
											{
												result = 9;
											}
											else
											{
												num6 = num7;
												if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 3)) != true)
												{
													num6 = num7;
													if ((num6.HasValue ? new bool?(num6 == 4) : ((bool?)null)) != true)
													{
														num6 = num7;
														if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 5)) != true)
														{
															num6 = num7;
															if ((num6.HasValue ? new bool?(num6 == 6) : ((bool?)null)) == true)
															{
																result = 13;
															}
															else
															{
																num6 = num7;
																if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 7)) == true)
																{
																	result = 14;
																}
																else
																{
																	num6 = num7;
																	if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == 8)) == true)
																	{
																		result = 15;
																	}
																	else
																	{
																		num6 = num7;
																		if ((num6.HasValue ? new bool?(num6 == -99) : ((bool?)null)) != true)
																		{
																			num6 = num7;
																			result = ((((!num6.HasValue) ? ((bool?)null) : new bool?(num6 == -100)) == true) ? 17 : (((object)SubjectType == typeof(Side)) ? 1 : 0));
																		}
																		else
																		{
																			result = 16;
																		}
																	}
																}
															}
														}
														else
														{
															result = 12;
														}
													}
													else
													{
														result = 11;
													}
												}
												else
												{
													result = 10;
												}
											}
										}
										else
										{
											result = 8;
										}
									}
									else
									{
										result = 7;
									}
								}
								else
								{
									result = 6;
								}
							}
						}
					}
				}
			}
			else
			{
				result = 1;
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101198", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num8;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num8 = 0;
			}
			else
			{
				num8 = 0;
			}
			result = num8;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal int? ShootersPerSalvoSelection_To_ShooterQty(ref object ShootersPerSalvoValue)
	{
		int? result;
		try
		{
			switch (Conversions.ToInteger(ShootersPerSalvoValue))
			{
			default:
				result = null;
				break;
			case 2:
				return -99;
			case 3:
				return 1;
			case 4:
				return 2;
			case 5:
				return 4;
			case 6:
				return -100;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101212", "");
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

	internal int ShooterQty_To_ShootersPerSalvoSelection(int? ShooterQty)
	{
		int result;
		try
		{
			int? num = ShooterQty;
			if (((!num.HasValue) ? ((bool?)null) : new bool?(num == -1)) == true)
			{
				result = 1;
			}
			else
			{
				num = ShooterQty;
				if ((num.HasValue ? new bool?(num == -99) : ((bool?)null)) != true)
				{
					num = ShooterQty;
					if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 1)) == true)
					{
						result = 3;
					}
					else
					{
						num = ShooterQty;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 2)) != true)
						{
							num = ShooterQty;
							if ((num.HasValue ? new bool?(num == 4) : ((bool?)null)) != true)
							{
								num = ShooterQty;
								result = (((num.HasValue ? new bool?(num == -100) : ((bool?)null)) == true) ? 6 : (((object)SubjectType == typeof(Side)) ? 1 : 0));
							}
							else
							{
								result = 5;
							}
						}
						else
						{
							result = 4;
						}
					}
				}
				else
				{
					result = 2;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101213", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num2;
			if (!Debugger.IsAttached)
			{
				num2 = 0;
			}
			else
			{
				Debugger.Break();
				num2 = 0;
			}
			result = num2;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal float? SelfDefenceRangeSelection_To_SelfDefenceRange(ref _WRA_WeaponTargetType WeaponTargetType, ref object SelfDefenceRange, float CustomValue = -99f)
	{
		float? result;
		try
		{
			switch (WeaponTargetType)
			{
			case _WRA_WeaponTargetType.Satellite_Unspecified:
				switch (Conversions.ToInteger(SelfDefenceRange))
				{
				default:
					result = null;
					break;
				case 2:
					return 0f;
				case 3:
					return -100f;
				case 4:
					return CustomValue;
				}
				break;
			case _WRA_WeaponTargetType.Air_Contact_Unknown_Type:
			case _WRA_WeaponTargetType.Aircraft_Unspecified:
			case _WRA_WeaponTargetType.Aircraft_5th_Generation:
			case _WRA_WeaponTargetType.Aircraft_4th_Generation:
			case _WRA_WeaponTargetType.Aircraft_3rd_Generation:
			case _WRA_WeaponTargetType.Aircraft_Less_Capable:
			case _WRA_WeaponTargetType.Aircraft_High_Perf_Bombers:
			case _WRA_WeaponTargetType.Aircraft_Medium_Perf_Bombers:
			case _WRA_WeaponTargetType.Aircraft_Low_Perf_Bombers:
			case _WRA_WeaponTargetType.Aircraft_High_Perf_Recon_EW:
			case _WRA_WeaponTargetType.Aircraft_Medium_Perf_Recon_EW:
			case _WRA_WeaponTargetType.Aircraft_Low_Perf_Recon_EW:
			case _WRA_WeaponTargetType.Aircraft_AEW:
			case _WRA_WeaponTargetType.Aircraft_Class1_UAS:
			case _WRA_WeaponTargetType.Aircraft_Tanker:
			case _WRA_WeaponTargetType.Aircraft_Class2_UAS:
			case _WRA_WeaponTargetType.Helicopter_Unspecified:
			case _WRA_WeaponTargetType.Guided_Weapon_Unspecified:
			case _WRA_WeaponTargetType.Guided_Weapon_Supersonic_Sea_Skimming:
			case _WRA_WeaponTargetType.Guided_Weapon_Subsonic_Sea_Skimming:
			case _WRA_WeaponTargetType.Guided_Weapon_Supersonic:
			case _WRA_WeaponTargetType.Guided_Weapon_Subsonic:
			case _WRA_WeaponTargetType.Guided_Weapon_Ballistic:
				switch (Conversions.ToInteger(SelfDefenceRange))
				{
				default:
					result = null;
					break;
				case 2:
					return 0f;
				case 3:
					return 2f;
				case 4:
					return 5f;
				case 5:
					return 10f;
				case 6:
					return 15f;
				case 7:
					return -99f;
				case 8:
					return -100f;
				case 9:
					return CustomValue;
				}
				break;
			case _WRA_WeaponTargetType.Subsurface_Contact_Unknown_Type:
			case _WRA_WeaponTargetType.Submarine_Unspecified:
				switch (Conversions.ToInteger(SelfDefenceRange))
				{
				default:
					result = null;
					break;
				case 2:
					return 0f;
				case 3:
					return 2f;
				case 4:
					return 5f;
				case 5:
					return 10f;
				case 6:
					return 15f;
				case 7:
					return -99f;
				case 8:
					return -100f;
				case 9:
					return CustomValue;
				}
				break;
			case _WRA_WeaponTargetType.Surface_Contact_Unknown_Type:
			case _WRA_WeaponTargetType.Ship_Unspecified:
			case _WRA_WeaponTargetType.Ship_Carrier_0_25000_tons:
			case _WRA_WeaponTargetType.Ship_Carrier_25001_45000_tons:
			case _WRA_WeaponTargetType.Ship_Carrier_45001_95000_tons:
			case _WRA_WeaponTargetType.Ship_Carrier_95000_tons:
			case _WRA_WeaponTargetType.Ship_Surface_Combatant_0_500_tons:
			case _WRA_WeaponTargetType.Ship_Surface_Combatant_501_1500_tons:
			case _WRA_WeaponTargetType.Ship_Surface_Combatant_1501_5000_tons:
			case _WRA_WeaponTargetType.Ship_Surface_Combatant_5001_10000_tons:
			case _WRA_WeaponTargetType.Ship_Surface_Combatant_10001_25000_tons:
			case _WRA_WeaponTargetType.Ship_Surface_Combatant_25001_45000_tons:
			case _WRA_WeaponTargetType.Ship_Surface_Combatant_45001_95000_tons:
			case _WRA_WeaponTargetType.Ship_Surface_Combatant_95000_tons:
			case _WRA_WeaponTargetType.Ship_Amphibious_0_500_tons:
			case _WRA_WeaponTargetType.Ship_Amphibious_501_1500_tons:
			case _WRA_WeaponTargetType.Ship_Amphibious_1501_5000_tons:
			case _WRA_WeaponTargetType.Ship_Amphibious_5001_10000_tons:
			case _WRA_WeaponTargetType.Ship_Amphibious_10001_25000_tons:
			case _WRA_WeaponTargetType.Ship_Amphibious_25001_45000_tons:
			case _WRA_WeaponTargetType.Ship_Amphibious_45001_95000_tons:
			case _WRA_WeaponTargetType.Ship_Amphibious_95000_tons:
			case _WRA_WeaponTargetType.Ship_Auxiliary_0_500_tons:
			case _WRA_WeaponTargetType.Ship_Auxiliary_501_1500_tons:
			case _WRA_WeaponTargetType.Ship_Auxiliary_1501_5000_tons:
			case _WRA_WeaponTargetType.Ship_Auxiliary_5001_10000_tons:
			case _WRA_WeaponTargetType.Ship_Auxiliary_10001_25000_tons:
			case _WRA_WeaponTargetType.Ship_Auxiliary_25001_45000_tons:
			case _WRA_WeaponTargetType.Ship_Auxiliary_45001_95000_tons:
			case _WRA_WeaponTargetType.Ship_Auxiliary_95000_tons:
			case _WRA_WeaponTargetType.Ship_Merchant_Civilian_0_500_tons:
			case _WRA_WeaponTargetType.Ship_Merchant_Civilian_501_1500_tons:
			case _WRA_WeaponTargetType.Ship_Merchant_Civilian_1501_5000_tons:
			case _WRA_WeaponTargetType.Ship_Merchant_Civilian_5001_10000_tons:
			case _WRA_WeaponTargetType.Ship_Merchant_Civilian_10001_25000_tons:
			case _WRA_WeaponTargetType.Ship_Merchant_Civilian_25001_45000_tons:
			case _WRA_WeaponTargetType.Ship_Merchant_Civilian_45001_95000_tons:
			case _WRA_WeaponTargetType.Ship_Merchant_Civilian_95000_tons:
			case _WRA_WeaponTargetType.Submarine_Surfaced:
				switch (Conversions.ToInteger(SelfDefenceRange))
				{
				default:
					result = null;
					break;
				case 2:
					return 0f;
				case 3:
					return 2f;
				case 4:
					return 5f;
				case 5:
					return 10f;
				case 6:
					return 15f;
				case 7:
					return -99f;
				case 8:
					return -100f;
				case 9:
					return CustomValue;
				}
				break;
			default:
				result = null;
				break;
			case _WRA_WeaponTargetType.Land_Contact_Unknown_Type:
			case _WRA_WeaponTargetType.Land_Structure_Soft_Unspecified:
			case _WRA_WeaponTargetType.Land_Structure_Soft_Building_Surface:
			case _WRA_WeaponTargetType.Land_Structure_Soft_Building_Reveted:
			case _WRA_WeaponTargetType.Land_Structure_Soft_Building_Bunker:
			case _WRA_WeaponTargetType.Land_Structure_Soft_Building_Underground:
			case _WRA_WeaponTargetType.Land_Structure_Soft_Structure_Open:
			case _WRA_WeaponTargetType.Land_Structure_Soft_Structure_Reveted:
			case _WRA_WeaponTargetType.Land_Structure_Soft_Aerostat_Moring:
			case _WRA_WeaponTargetType.Land_Structure_Hardened_Unspecified:
			case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Surface:
			case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Reveted:
			case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Bunker:
			case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Underground:
			case _WRA_WeaponTargetType.Land_Structure_Hardened_Structure_Open:
			case _WRA_WeaponTargetType.Land_Structure_Hardened_Structure_Reveted:
			case _WRA_WeaponTargetType.Runway_Facility_Unspecified:
			case _WRA_WeaponTargetType.Runway:
			case _WRA_WeaponTargetType.Runway_Grade_Taxiway:
			case _WRA_WeaponTargetType.Runway_Access_Point:
			case _WRA_WeaponTargetType.Emitter_Unspecified:
			case _WRA_WeaponTargetType.Emitter_Radar:
			case _WRA_WeaponTargetType.Emitter_Jammer:
			case _WRA_WeaponTargetType.Mobile_Target_Soft_Unspecified:
			case _WRA_WeaponTargetType.Mobile_Target_Soft_Mobile_Vehicle:
			case _WRA_WeaponTargetType.Mobile_Target_Soft_Mobile_Personnel:
			case _WRA_WeaponTargetType.Mobile_Target_Hardened_Unspecified:
			case _WRA_WeaponTargetType.Mobile_Target_Hardened_Mobile_Vehicle:
			case _WRA_WeaponTargetType.Underwater_Structure:
			case _WRA_WeaponTargetType.Air_Base_Single_Unit_Airfield:
				switch (Conversions.ToInteger(SelfDefenceRange))
				{
				default:
					result = null;
					break;
				case 2:
					return 0f;
				case 3:
					return 2f;
				case 4:
					return 5f;
				case 5:
					return 10f;
				case 6:
					return 15f;
				case 7:
					return -99f;
				case 8:
					return -100f;
				case 9:
					return CustomValue;
				}
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101199", "");
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

	internal int SelfDefenceRange_To_SelfDefenceRangeSelection(ref _WRA_WeaponTargetType WeaponTargetType, float? SelfDefenceRange)
	{
		int result;
		try
		{
			int num;
			float? num3;
			float? num4;
			float? num5;
			float? num2;
			if (!SelfDefenceRange.HasValue)
			{
				result = (((object)Subject.GetType() == typeof(Side)) ? 1 : 0);
			}
			else
			{
				_WRA_WeaponTargetType wRA_WeaponTargetType = WeaponTargetType;
				if (wRA_WeaponTargetType <= _WRA_WeaponTargetType.Ship_Merchant_Civilian_95000_tons)
				{
					if (wRA_WeaponTargetType <= _WRA_WeaponTargetType.Guided_Weapon_Subsonic)
					{
						if (wRA_WeaponTargetType <= _WRA_WeaponTargetType.Aircraft_Low_Perf_Recon_EW)
						{
							if ((uint)(wRA_WeaponTargetType - 1999) <= 5u || (uint)(wRA_WeaponTargetType - 2011) <= 2u || (uint)(wRA_WeaponTargetType - 2021) <= 2u)
							{
								goto IL_0178;
							}
							num = 0;
						}
						else
						{
							if ((uint)(wRA_WeaponTargetType - 2031) <= 3u || wRA_WeaponTargetType == _WRA_WeaponTargetType.Helicopter_Unspecified || (uint)(wRA_WeaponTargetType - 2200) <= 4u)
							{
								goto IL_0178;
							}
							num = 0;
						}
						goto IL_0873;
					}
					if (wRA_WeaponTargetType > _WRA_WeaponTargetType.Ship_Carrier_95000_tons)
					{
						if (wRA_WeaponTargetType <= _WRA_WeaponTargetType.Ship_Amphibious_95000_tons)
						{
							if ((uint)(wRA_WeaponTargetType - 3101) <= 7u || (uint)(wRA_WeaponTargetType - 3201) <= 7u)
							{
								goto IL_05fd;
							}
							num = 0;
						}
						else
						{
							if ((uint)(wRA_WeaponTargetType - 3301) <= 7u || (uint)(wRA_WeaponTargetType - 3401) <= 7u)
							{
								goto IL_05fd;
							}
							num = 0;
						}
						goto IL_0873;
					}
					if (wRA_WeaponTargetType == _WRA_WeaponTargetType.Guided_Weapon_Ballistic)
					{
						goto IL_0178;
					}
					if (wRA_WeaponTargetType != _WRA_WeaponTargetType.Satellite_Unspecified)
					{
						if ((uint)(wRA_WeaponTargetType - 2999) <= 5u)
						{
							goto IL_05fd;
						}
						num = 0;
						goto IL_0873;
					}
					num2 = SelfDefenceRange;
					num3 = num2;
					if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == -1f) : ((bool?)null)) == true)
					{
						result = 1;
					}
					else
					{
						num3 = num2;
						if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == 0f) : ((bool?)null)) != true)
						{
							num3 = num2;
							result = (((num3.HasValue ? new bool?(num3.GetValueOrDefault() == -100f) : ((bool?)null)) != true) ? 4 : 3);
						}
						else
						{
							result = 2;
						}
					}
				}
				else
				{
					if (wRA_WeaponTargetType > _WRA_WeaponTargetType.Runway_Access_Point)
					{
						if (wRA_WeaponTargetType <= _WRA_WeaponTargetType.Emitter_Jammer)
						{
							if (wRA_WeaponTargetType != _WRA_WeaponTargetType.Emitter_Unspecified && wRA_WeaponTargetType != _WRA_WeaponTargetType.Emitter_Radar && wRA_WeaponTargetType != _WRA_WeaponTargetType.Emitter_Jammer)
							{
								num = 0;
								goto IL_0873;
							}
						}
						else if (wRA_WeaponTargetType <= _WRA_WeaponTargetType.Mobile_Target_Hardened_Mobile_Vehicle)
						{
							if ((uint)(wRA_WeaponTargetType - 5400) > 2u && (uint)(wRA_WeaponTargetType - 5500) > 1u)
							{
								num = 0;
								goto IL_0873;
							}
						}
						else if (wRA_WeaponTargetType != _WRA_WeaponTargetType.Underwater_Structure && wRA_WeaponTargetType != _WRA_WeaponTargetType.Air_Base_Single_Unit_Airfield)
						{
							num = 0;
							goto IL_0873;
						}
						goto IL_0879;
					}
					if (wRA_WeaponTargetType > _WRA_WeaponTargetType.Land_Structure_Soft_Structure_Reveted)
					{
						if (wRA_WeaponTargetType != _WRA_WeaponTargetType.Land_Structure_Soft_Aerostat_Moring && (uint)(wRA_WeaponTargetType - 5100) > 6u && (uint)(wRA_WeaponTargetType - 5200) > 3u)
						{
							num = 0;
							goto IL_0873;
						}
						goto IL_0879;
					}
					if (wRA_WeaponTargetType == _WRA_WeaponTargetType.Submarine_Surfaced)
					{
						goto IL_05fd;
					}
					if ((uint)(wRA_WeaponTargetType - 3999) > 1u)
					{
						if ((uint)(wRA_WeaponTargetType - 4999) > 7u)
						{
							num = 0;
							goto IL_0873;
						}
						goto IL_0879;
					}
					num4 = SelfDefenceRange;
					num5 = num4;
					if (((!num5.HasValue) ? ((bool?)null) : new bool?(num5.GetValueOrDefault() == -1f)) != true)
					{
						num5 = num4;
						if (((!num5.HasValue) ? ((bool?)null) : new bool?(num5.GetValueOrDefault() == 0f)) == true)
						{
							result = 2;
						}
						else
						{
							num5 = num4;
							if ((num5.HasValue ? new bool?(num5.GetValueOrDefault() == 2f) : ((bool?)null)) != true)
							{
								num5 = num4;
								if ((num5.HasValue ? new bool?(num5.GetValueOrDefault() == 5f) : ((bool?)null)) == true)
								{
									result = 4;
								}
								else
								{
									num5 = num4;
									if ((num5.HasValue ? new bool?(num5.GetValueOrDefault() == 10f) : ((bool?)null)) != true)
									{
										num5 = num4;
										if (((!num5.HasValue) ? ((bool?)null) : new bool?(num5.GetValueOrDefault() == 15f)) == true)
										{
											result = 6;
										}
										else
										{
											num5 = num4;
											if ((num5.HasValue ? new bool?(num5.GetValueOrDefault() == -99f) : ((bool?)null)) != true)
											{
												num5 = num4;
												result = ((((!num5.HasValue) ? ((bool?)null) : new bool?(num5.GetValueOrDefault() == -100f)) == true) ? 8 : 9);
											}
											else
											{
												result = 7;
											}
										}
									}
									else
									{
										result = 5;
									}
								}
							}
							else
							{
								result = 3;
							}
						}
					}
					else
					{
						result = 1;
					}
				}
			}
			goto end_IL_0001;
			IL_05fd:
			num3 = SelfDefenceRange;
			num4 = num3;
			if ((num4.HasValue ? new bool?(num4.GetValueOrDefault() == -1f) : ((bool?)null)) != true)
			{
				num4 = num3;
				if (((!num4.HasValue) ? ((bool?)null) : new bool?(num4.GetValueOrDefault() == 0f)) == true)
				{
					result = 2;
				}
				else
				{
					num4 = num3;
					if ((num4.HasValue ? new bool?(num4.GetValueOrDefault() == 2f) : ((bool?)null)) == true)
					{
						result = 3;
					}
					else
					{
						num4 = num3;
						if ((num4.HasValue ? new bool?(num4.GetValueOrDefault() == 5f) : ((bool?)null)) != true)
						{
							num4 = num3;
							if (((!num4.HasValue) ? ((bool?)null) : new bool?(num4.GetValueOrDefault() == 10f)) != true)
							{
								num4 = num3;
								if (((!num4.HasValue) ? ((bool?)null) : new bool?(num4.GetValueOrDefault() == 15f)) == true)
								{
									result = 6;
								}
								else
								{
									num4 = num3;
									if ((num4.HasValue ? new bool?(num4.GetValueOrDefault() == -99f) : ((bool?)null)) != true)
									{
										num4 = num3;
										result = ((((!num4.HasValue) ? ((bool?)null) : new bool?(num4.GetValueOrDefault() == -100f)) != true) ? 9 : 8);
									}
									else
									{
										result = 7;
									}
								}
							}
							else
							{
								result = 5;
							}
						}
						else
						{
							result = 4;
						}
					}
				}
			}
			else
			{
				result = 1;
			}
			goto end_IL_0001;
			IL_0873:
			result = num;
			goto end_IL_0001;
			IL_0879:
			num5 = SelfDefenceRange;
			float? num6 = num5;
			if ((num6.HasValue ? new bool?(num6.GetValueOrDefault() == -1f) : ((bool?)null)) != true)
			{
				num6 = num5;
				if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6.GetValueOrDefault() == 0f)) != true)
				{
					num6 = num5;
					if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6.GetValueOrDefault() == 2f)) != true)
					{
						num6 = num5;
						if ((num6.HasValue ? new bool?(num6.GetValueOrDefault() == 5f) : ((bool?)null)) != true)
						{
							num6 = num5;
							if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6.GetValueOrDefault() == 10f)) != true)
							{
								num6 = num5;
								if ((num6.HasValue ? new bool?(num6.GetValueOrDefault() == 15f) : ((bool?)null)) == true)
								{
									result = 6;
								}
								else
								{
									num6 = num5;
									if (((!num6.HasValue) ? ((bool?)null) : new bool?(num6.GetValueOrDefault() == -99f)) != true)
									{
										num6 = num5;
										result = (((num6.HasValue ? new bool?(num6.GetValueOrDefault() == -100f) : ((bool?)null)) == true) ? 8 : 9);
									}
									else
									{
										result = 7;
									}
								}
							}
							else
							{
								result = 5;
							}
						}
						else
						{
							result = 4;
						}
					}
					else
					{
						result = 3;
					}
				}
				else
				{
					result = 2;
				}
			}
			else
			{
				result = 1;
			}
			goto end_IL_0001;
			IL_0178:
			float? num7 = SelfDefenceRange;
			num2 = num7;
			if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2.GetValueOrDefault() == -1f)) != true)
			{
				num2 = num7;
				if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2.GetValueOrDefault() == 0f)) == true)
				{
					result = 2;
				}
				else
				{
					num2 = num7;
					if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 2f) : ((bool?)null)) == true)
					{
						result = 3;
					}
					else
					{
						num2 = num7;
						if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 5f) : ((bool?)null)) != true)
						{
							num2 = num7;
							if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 10f) : ((bool?)null)) == true)
							{
								result = 5;
							}
							else
							{
								num2 = num7;
								if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 15f) : ((bool?)null)) != true)
								{
									num2 = num7;
									if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -99f) : ((bool?)null)) != true)
									{
										num2 = num7;
										result = ((((!num2.HasValue) ? ((bool?)null) : new bool?(num2.GetValueOrDefault() == -100f)) != true) ? 9 : 8);
									}
									else
									{
										result = 7;
									}
								}
								else
								{
									result = 6;
								}
							}
						}
						else
						{
							result = 4;
						}
					}
				}
			}
			else
			{
				result = 1;
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101200", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num8;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num8 = 0;
			}
			else
			{
				num8 = 0;
			}
			result = num8;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal float? FiringRangeSelection_To_FiringRange(ref object FiringRange, float customValue = -99f)
	{
		float? result;
		try
		{
			switch (Conversions.ToInteger(FiringRange))
			{
			default:
				result = null;
				break;
			case 1:
				result = null;
				break;
			case 2:
				return 0f;
			case 3:
				return 2f;
			case 4:
				return 5f;
			case 5:
				return 10f;
			case 6:
				return 15f;
			case 7:
				return 20f;
			case 8:
				return 25f;
			case 9:
				return 30f;
			case 10:
				return 35f;
			case 11:
				return 40f;
			case 12:
				return 45f;
			case 13:
				return 50f;
			case 14:
				return 60f;
			case 15:
				return 70f;
			case 16:
				return 80f;
			case 17:
				return 90f;
			case 18:
				return 100f;
			case 19:
				return 125f;
			case 20:
				return 150f;
			case 21:
				return 175f;
			case 22:
				return 200f;
			case 23:
				return 250f;
			case 24:
				return 300f;
			case 25:
				return 500f;
			case 26:
				return 750f;
			case 27:
				return 1000f;
			case 28:
				return 1500f;
			case 29:
				return 2000f;
			case 30:
				return -100f;
			case 31:
				return customValue;
			case 32:
				return -95f;
			case 33:
				return -96f;
			case 34:
				return -97f;
			case 35:
				return -102f;
			case 36:
				return -99f;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101201", "");
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

	internal int FiringRange_To_FiringRangeSelection(float? FiringRange)
	{
		int result;
		try
		{
			if (!FiringRange.HasValue)
			{
				result = (((object)Subject.GetType() == typeof(Side)) ? 1 : 0);
			}
			else
			{
				float? num = FiringRange;
				float? num2 = num;
				if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2.GetValueOrDefault() == 0f)) == true)
				{
					result = 2;
				}
				else
				{
					num2 = num;
					if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2.GetValueOrDefault() == 2f)) != true)
					{
						num2 = num;
						if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 5f) : ((bool?)null)) != true)
						{
							num2 = num;
							if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2.GetValueOrDefault() == 10f)) == true)
							{
								result = 5;
							}
							else
							{
								num2 = num;
								if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 15f) : ((bool?)null)) != true)
								{
									num2 = num;
									if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2.GetValueOrDefault() == 20f)) != true)
									{
										num2 = num;
										if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2.GetValueOrDefault() == 25f)) == true)
										{
											result = 8;
										}
										else
										{
											num2 = num;
											if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 30f) : ((bool?)null)) == true)
											{
												result = 9;
											}
											else
											{
												num2 = num;
												if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 35f) : ((bool?)null)) == true)
												{
													result = 10;
												}
												else
												{
													num2 = num;
													if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 40f) : ((bool?)null)) == true)
													{
														result = 11;
													}
													else
													{
														num2 = num;
														if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 45f) : ((bool?)null)) != true)
														{
															num2 = num;
															if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 50f) : ((bool?)null)) == true)
															{
																result = 13;
															}
															else
															{
																num2 = num;
																if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 60f) : ((bool?)null)) == true)
																{
																	result = 14;
																}
																else
																{
																	num2 = num;
																	if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 70f) : ((bool?)null)) == true)
																	{
																		result = 15;
																	}
																	else
																	{
																		num2 = num;
																		if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 80f) : ((bool?)null)) != true)
																		{
																			num2 = num;
																			if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 90f) : ((bool?)null)) != true)
																			{
																				num2 = num;
																				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 100f) : ((bool?)null)) != true)
																				{
																					num2 = num;
																					if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 125f) : ((bool?)null)) == true)
																					{
																						result = 19;
																					}
																					else
																					{
																						num2 = num;
																						if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 150f) : ((bool?)null)) == true)
																						{
																							result = 20;
																						}
																						else
																						{
																							num2 = num;
																							if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2.GetValueOrDefault() == 175f)) == true)
																							{
																								result = 21;
																							}
																							else
																							{
																								num2 = num;
																								if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 200f) : ((bool?)null)) == true)
																								{
																									result = 22;
																								}
																								else
																								{
																									num2 = num;
																									if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 250f) : ((bool?)null)) == true)
																									{
																										result = 23;
																									}
																									else
																									{
																										num2 = num;
																										if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 300f) : ((bool?)null)) != true)
																										{
																											num2 = num;
																											if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2.GetValueOrDefault() == 500f)) != true)
																											{
																												num2 = num;
																												if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 750f) : ((bool?)null)) != true)
																												{
																													num2 = num;
																													if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 1000f) : ((bool?)null)) == true)
																													{
																														result = 27;
																													}
																													else
																													{
																														num2 = num;
																														if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 1500f) : ((bool?)null)) != true)
																														{
																															num2 = num;
																															if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2.GetValueOrDefault() == 2000f)) != true)
																															{
																																num2 = num;
																																if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -100f) : ((bool?)null)) != true)
																																{
																																	num2 = num;
																																	if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2.GetValueOrDefault() == -95f)) != true)
																																	{
																																		num2 = num;
																																		if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2.GetValueOrDefault() == -96f)) != true)
																																		{
																																			num2 = num;
																																			if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2.GetValueOrDefault() == -97f)) != true)
																																			{
																																				num2 = num;
																																				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -102f) : ((bool?)null)) == true)
																																				{
																																					result = 35;
																																				}
																																				else
																																				{
																																					num2 = num;
																																					result = ((((!num2.HasValue) ? ((bool?)null) : new bool?(num2.GetValueOrDefault() == -99f)) == true) ? 36 : 31);
																																				}
																																			}
																																			else
																																			{
																																				result = 34;
																																			}
																																		}
																																		else
																																		{
																																			result = 33;
																																		}
																																	}
																																	else
																																	{
																																		result = 32;
																																	}
																																}
																																else
																																{
																																	result = 30;
																																}
																															}
																															else
																															{
																																result = 29;
																															}
																														}
																														else
																														{
																															result = 28;
																														}
																													}
																												}
																												else
																												{
																													result = 26;
																												}
																											}
																											else
																											{
																												result = 25;
																											}
																										}
																										else
																										{
																											result = 24;
																										}
																									}
																								}
																							}
																						}
																					}
																				}
																				else
																				{
																					result = 18;
																				}
																			}
																			else
																			{
																				result = 17;
																			}
																		}
																		else
																		{
																			result = 16;
																		}
																	}
																}
															}
														}
														else
														{
															result = 12;
														}
													}
												}
											}
										}
									}
									else
									{
										result = 7;
									}
								}
								else
								{
									result = 6;
								}
							}
						}
						else
						{
							result = 4;
						}
					}
					else
					{
						result = 3;
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101202", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num3;
			if (!Debugger.IsAttached)
			{
				num3 = 0;
			}
			else
			{
				Debugger.Break();
				num3 = 0;
			}
			result = num3;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static string WRA_WeaponQtyString(int? theWeaponQty, bool TargetTypeUnspecified)
	{
		string text = "";
		if (TargetTypeUnspecified)
		{
			text = " (Using 'Unspecified' target type settings)";
		}
		int? num = theWeaponQty;
		int? num2 = num;
		if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2 == -1)) == true)
		{
			return "System default (from database)" + text;
		}
		num2 = num;
		if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2.GetValueOrDefault() == 0)) == true)
		{
			return "Do not use weapon against this target type" + text;
		}
		num2 = num;
		if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2 == -98)) != true)
		{
			num2 = num;
			if ((num2.HasValue ? new bool?(num2 == -99) : ((bool?)null)) == true)
			{
				return "All weapons" + text;
			}
			num2 = num;
			if ((num2.HasValue ? new bool?(num2 == -2) : ((bool?)null)) == true)
			{
				return "Target's Missile Defence value" + text;
			}
			num2 = num;
			if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2 == -3)) != true)
			{
				num2 = num;
				if ((num2.HasValue ? new bool?(num2 == -4) : ((bool?)null)) == true)
				{
					return "4x Target's Missile Defence value" + text;
				}
				num2 = num;
				if ((num2.HasValue ? new bool?(num2 == -5) : ((bool?)null)) != true)
				{
					num2 = num;
					if ((num2.HasValue ? new bool?(num2 == -6) : ((bool?)null)) != true)
					{
						num2 = num;
						if ((num2.HasValue ? new bool?(num2 == -100) : ((bool?)null)) != true)
						{
							if (!theWeaponQty.HasValue)
							{
								return text + "Not Configured";
							}
							num2 = theWeaponQty;
							if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() > 1) : ((bool?)null)) != true)
							{
								return theWeaponQty + " rnd" + text;
							}
							return theWeaponQty + " rnds" + text;
						}
						return "Various" + text;
					}
					return "1/4 Target's Missile Defence value" + text;
				}
				return "1/2 Target's Missile Defence value" + text;
			}
			return "2x Target's Missile Defence value" + text;
		}
		return "Not defined" + text;
	}

	public static string WRA_ShooterQtyString(int? theShooterQty, bool TargetTypeUnspecified)
	{
		string text = "";
		if (TargetTypeUnspecified)
		{
			text = " (Using 'Unspecified' target type settings)";
		}
		int? num = theShooterQty;
		int? num2 = num;
		if ((num2.HasValue ? new bool?(num2 == -1) : ((bool?)null)) == true)
		{
			return "System default (from database)" + text;
		}
		num2 = num;
		if ((num2.HasValue ? new bool?(num2 == -99) : ((bool?)null)) != true)
		{
			num2 = num;
			if ((num2.HasValue ? new bool?(num2 == -100) : ((bool?)null)) != true)
			{
				if (!theShooterQty.HasValue)
				{
					return text + "Not Configured";
				}
				num2 = theShooterQty;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() > 1) : ((bool?)null)) == true)
				{
					return theShooterQty + " units" + text;
				}
				return theShooterQty + " unit" + text;
			}
			return "Various" + text;
		}
		return "Fire weapons from enough units to fill the salvo's Weapon Qty requirement" + text;
	}

	internal string WRA_SelfDefenceRangeString(float? theSelfDefenceRange, bool TargetTypeUnspecified)
	{
		string text = "";
		if (TargetTypeUnspecified)
		{
			text = " (Using 'Unspecified' target type settings)";
		}
		float? num = theSelfDefenceRange;
		float? num2 = num;
		if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2.GetValueOrDefault() == -1f)) == true)
		{
			return "System default (from database)" + text;
		}
		num2 = num;
		if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2.GetValueOrDefault() == 0f)) == true)
		{
			return "Do not use weapon in self defence" + text;
		}
		num2 = num;
		if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2.GetValueOrDefault() == -98f)) == true)
		{
			return "Not defined" + text;
		}
		num2 = num;
		if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -99f) : ((bool?)null)) == true)
		{
			return "Maximum range" + text;
		}
		num2 = num;
		if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -100f) : ((bool?)null)) == true)
		{
			return "Various" + text;
		}
		if (theSelfDefenceRange.HasValue)
		{
			return theSelfDefenceRange + " nm" + text;
		}
		return "Not Configured" + text;
	}

	internal string WRA_FiringRangeString(float? theFiringRange, bool TargetTypeUnspecified)
	{
		string text = "";
		if (TargetTypeUnspecified)
		{
			text = " (Using 'Unspecified' target type settings)";
		}
		float? num = theFiringRange;
		float? num2 = num;
		if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2.GetValueOrDefault() == 0f)) == true)
		{
			return "No automatic use, manual fire only" + text;
		}
		num2 = num;
		if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2.GetValueOrDefault() == -98f)) == true)
		{
			return "Not defined" + text;
		}
		num2 = num;
		if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2.GetValueOrDefault() == -99f)) != true)
		{
			num2 = num;
			if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -100f) : ((bool?)null)) == true)
			{
				return "Various" + text;
			}
			num2 = num;
			if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -95f) : ((bool?)null)) != true)
			{
				num2 = num;
				if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2.GetValueOrDefault() == -96f)) == true)
				{
					return "50% of max" + text;
				}
				num2 = num;
				if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2.GetValueOrDefault() == -97f)) != true)
				{
					num2 = num;
					if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2.GetValueOrDefault() == -102f)) != true)
					{
						if (theFiringRange.HasValue)
						{
							return theFiringRange + "nm" + text;
						}
						return "";
					}
					return "No-Escape Zone" + text;
				}
				return "75% of max" + text;
			}
			return "25% of max" + text;
		}
		return "Automatic Fire to Max Range" + text;
	}

	internal bool WRA_RelevantWeapon(ref Weapon theWeapon)
	{
		Weapon._WeaponType type = theWeapon.Type;
		int result;
		if (type <= Weapon._WeaponType.FerryTank)
		{
			switch (type)
			{
			default:
				result = 1;
				break;
			case Weapon._WeaponType.SensorPod:
				return false;
			case Weapon._WeaponType.DropTank:
				return false;
			case Weapon._WeaponType.BuddyStore:
				return false;
			case Weapon._WeaponType.FerryTank:
				return false;
			case Weapon._WeaponType.Decoy_Expendable:
				return false;
			case Weapon._WeaponType.Decoy_Towed:
				return false;
			case Weapon._WeaponType.Decoy_Vehicle:
				result = 1;
				break;
			case Weapon._WeaponType.TrainingRound:
				return false;
			}
		}
		else
		{
			switch (type)
			{
			case Weapon._WeaponType.Cargo:
				return false;
			case Weapon._WeaponType.Troops:
				return false;
			case Weapon._WeaponType.Paratroops:
				return false;
			case Weapon._WeaponType.HeliTowedPackage:
				return false;
			case Weapon._WeaponType.Sonobuoy:
				return false;
			}
			result = 1;
		}
		return (byte)result != 0;
	}

	public void ToXML(ref XmlWriter theWriter, ref Scenario theScen, string theDoctrineName = "Doctrine")
	{
		try
		{
			theWriter.WriteStartElement(theDoctrineName);
			DoctrineItem[] doctrineItems = DoctrineItems;
			foreach (DoctrineItem doctrineItem in doctrineItems)
			{
				if (doctrineItem != null)
				{
					if (doctrineItem._CurrentState.HasValue)
					{
						theWriter.WriteElementString(doctrineItem.Definifition.SaveID, doctrineItem._CurrentState.Value.ToString());
					}
					else
					{
						theWriter.WriteElementString(doctrineItem.Definifition.SaveID, "-1");
					}
					if (doctrineItem.PlayerEditable)
					{
						theWriter.WriteElementString(doctrineItem.Definifition.SaveID_PlayerEditable, (0 - (doctrineItem.PlayerEditable ? 1 : 0)).ToString());
					}
				}
			}
			if (!Information.IsNothing((object)emconsettings_0))
			{
				theWriter.WriteElementString("E_Radar", ((int)emconsettings_0.Radar()).ToString());
				theWriter.WriteElementString("E_Sonar", ((int)emconsettings_0.Sonar()).ToString());
				theWriter.WriteElementString("E_OECM", ((int)emconsettings_0.OECM()).ToString());
			}
			if (!Information.IsNothing((object)WRA))
			{
				theWriter.WriteStartElement("WRA");
				foreach (KeyValuePair<int, WRA_Weapon> item in WRA)
				{
					theWriter.WriteStartElement("Weapon_" + Conversions.ToString(Conversions.ToInteger(item.Key.ToString())));
					foreach (WRA_FiringDoctrineEntry value in item.Value.WRA_WeaponTargets.Values)
					{
						XmlWriter obj = theWriter;
						int targetType = (int)value.TargetType;
						obj.WriteStartElement("WeaponTarget_" + targetType);
						if ((object)SubjectType == typeof(Side))
						{
							if (!Information.IsNothing((object)value.WeaponQty))
							{
								int? weaponQty = value.WeaponQty;
								bool? flag = ((!weaponQty.HasValue) ? ((bool?)null) : new bool?(weaponQty == -1));
								if (((!flag) ?? flag) == true)
								{
									theWriter.WriteElementString("WeaponQty", value.WeaponQty.Value.ToString());
								}
							}
							if (!Information.IsNothing((object)value.ShooterQty))
							{
								int? weaponQty = value.ShooterQty;
								bool? flag = ((!weaponQty.HasValue) ? ((bool?)null) : new bool?(weaponQty == -1));
								if (((!flag) ?? flag) == true)
								{
									theWriter.WriteElementString("ShooterQty", value.ShooterQty.Value.ToString());
								}
							}
							if (!Information.IsNothing((object)value.SelfDefenceRange))
							{
								float? selfDefenceRange = value.SelfDefenceRange;
								bool? flag = (selfDefenceRange.HasValue ? new bool?(selfDefenceRange.GetValueOrDefault() == -1f) : ((bool?)null));
								if (((!flag) ?? flag) == true)
								{
									theWriter.WriteElementString("SelfDefenceRange", value.SelfDefenceRange.Value.ToString());
								}
							}
							if (!Information.IsNothing((object)value.FiringRange))
							{
								theWriter.WriteElementString("FiringRange", value.FiringRange.Value.ToString());
							}
						}
						else
						{
							if (!Information.IsNothing((object)value.WeaponQty))
							{
								theWriter.WriteElementString("WeaponQty", value.WeaponQty.Value.ToString());
							}
							if (!Information.IsNothing((object)value.ShooterQty))
							{
								theWriter.WriteElementString("ShooterQty", value.ShooterQty.Value.ToString());
							}
							if (!Information.IsNothing((object)value.SelfDefenceRange))
							{
								theWriter.WriteElementString("SelfDefenceRange", value.SelfDefenceRange.Value.ToString());
							}
							if (!Information.IsNothing((object)value.FiringRange))
							{
								theWriter.WriteElementString("FiringRange", value.FiringRange.Value.ToString());
							}
						}
						theWriter.WriteEndElement();
					}
					theWriter.WriteEndElement();
				}
				theWriter.WriteEndElement();
			}
			if (list_0.Count > 0)
			{
				theWriter.WriteStartElement("PTL");
				foreach (PriorityTargetEntry item2 in list_0)
				{
					item2.ToXML(ref theWriter, ref theScen, theDoctrineName);
				}
				theWriter.WriteEndElement();
			}
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101003", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_6()
	{
		InheritDoctrine(ref SubjectType);
		Init();
	}

	public static Doctrine FromXML(Scenario _ScenarioContext, ref XmlNode theNode, ScenarioObject theSubject, Doctrine existingObject = null, bool reinitializeObject = false)
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_03d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03df: Expected O, but got Unknown
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Expected O, but got Unknown
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Expected O, but got Unknown
		Doctrine doctrine = default(Doctrine);
		List<ActiveUnit> DoctrineSelectedUnits;
		try
		{
			if (existingObject == null)
			{
				DoctrineSelectedUnits = null;
				doctrine = new Doctrine(_ScenarioContext, theSubject, ref DoctrineSelectedUnits);
			}
			else
			{
				doctrine = existingObject;
			}
			doctrine.SuspendDoctrineChangeEvents();
			if (reinitializeObject)
			{
				doctrine.method_6();
			}
			EMCONSettings._EMCONSetting? eMCONSetting2 = default(EMCONSettings._EMCONSetting?);
			EMCONSettings._EMCONSetting? eMCONSetting = default(EMCONSettings._EMCONSetting?);
			EMCONSettings._EMCONSetting? eMCONSetting3 = default(EMCONSettings._EMCONSetting?);
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "EMCON_Radar":
				case "E_Radar":
					eMCONSetting2 = (EMCONSettings._EMCONSetting)XmlConvert.ToByte(val.InnerText);
					break;
				case "WRA":
					doctrine.concurrentPagedArray_0 = new ConcurrentPagedArray<WRA_Weapon>();
					foreach (XmlNode childNode2 in val.ChildNodes)
					{
						XmlNode val2 = childNode2;
						if (Operators.CompareString(val2.Name, "#comment", false) == 0)
						{
							continue;
						}
						int key = Conversions.ToInteger(val2.Name.Split(new char[1] { '_' })[1]);
						WRA_Weapon wRA_Weapon = new WRA_Weapon();
						doctrine.concurrentPagedArray_0[key] = wRA_Weapon;
						foreach (XmlNode childNode3 in val2.ChildNodes)
						{
							XmlNode val3 = childNode3;
							if (Operators.CompareString(val3.Name, "#comment", false) == 0)
							{
								continue;
							}
							_WRA_WeaponTargetType wRA_WeaponTargetType = (_WRA_WeaponTargetType)Conversions.ToInteger(val3.Name.Split(new char[1] { '_' })[1]);
							WRA_FiringDoctrineEntry wRA_FiringDoctrineEntry = new WRA_FiringDoctrineEntry(wRA_WeaponTargetType);
							foreach (XmlNode childNode4 in val3.ChildNodes)
							{
								XmlNode val4 = childNode4;
								switch (val4.Name)
								{
								case "WeaponQty":
									wRA_FiringDoctrineEntry.WeaponQty = Conversions.ToInteger(val4.InnerText);
									break;
								case "SelfDefenceRange":
									wRA_FiringDoctrineEntry.SelfDefenceRange = Conversions.ToSingle(val4.InnerText);
									break;
								case "FiringRange":
									wRA_FiringDoctrineEntry.FiringRange = Conversions.ToSingle(val4.InnerText);
									break;
								case "ShooterQty":
									wRA_FiringDoctrineEntry.ShooterQty = Conversions.ToInteger(val4.InnerText);
									break;
								}
							}
							wRA_Weapon.AddTo_WRAWeaponTargets(wRA_WeaponTargetType, wRA_FiringDoctrineEntry);
						}
					}
					break;
				case "EMCON_Sonar":
				case "E_Sonar":
					eMCONSetting = (EMCONSettings._EMCONSetting)XmlConvert.ToByte(val.InnerText);
					break;
				case "PTL":
					doctrine.list_0.Clear();
					foreach (XmlNode childNode5 in val.ChildNodes)
					{
						XmlNode theNode2 = childNode5;
						PriorityTargetEntry item = PriorityTargetEntry.FromXML(ref theNode2);
						doctrine.list_0.Add(item);
					}
					break;
				case "EMCON_OECM":
				case "E_OECM":
					eMCONSetting3 = (EMCONSettings._EMCONSetting)XmlConvert.ToByte(val.InnerText);
					break;
				default:
				{
					DoctrineDefinition value = null;
					if (_CacheDoctrineDefinitions_PlayerEditDIC.TryGetValue(val.Name, out value))
					{
						doctrine.GetElement(value)._PlayerEditable = Misc.ParseBool(val.InnerText);
					}
					if (_CacheDoctrineDefinitions_DIC.TryGetValue(val.Name, out value))
					{
						doctrine.SetDoctrineItem_XML(val.Name, val.InnerText);
					}
					break;
				}
				case "NukesAllowed_Inherits":
					if (Misc.ParseBool(val.InnerText))
					{
						doctrine.GetElement(DoctrineItem_E.NukesAllowed)._CurrentState = null;
					}
					break;
				case "#comment":
					break;
				}
			}
			if (eMCONSetting2.HasValue || eMCONSetting.HasValue || eMCONSetting3.HasValue)
			{
				doctrine.emconsettings_0 = new EMCONSettings(eMCONSetting2.Value, eMCONSetting.Value, eMCONSetting3.Value);
			}
			return doctrine;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101004", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		finally
		{
			doctrine?.ResumeDoctrineChangeEvents(false, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
		}
		DoctrineSelectedUnits = null;
		return new Doctrine(_ScenarioContext, theSubject, ref DoctrineSelectedUnits);
	}

	public void ResetMission_TimeSincePlayerNotification(ref Scenario CurrentScenario, ref Side CurrentSide)
	{
		Side[] sides_ReadOnly = CurrentScenario.Sides_ReadOnly;
		foreach (Side side in sides_ReadOnly)
		{
			if (side != CurrentSide && !Module_Side.IsAlliedWithThisSide(side, CurrentSide))
			{
				continue;
			}
			foreach (Mission mission in side.Missions)
			{
				mission.TimeSincePlayerNotification = 0;
			}
		}
	}

	private DoctrineDefinition method_7()
	{
		return DoctrineDefinitions.ElementAt(0).Value;
	}

	public static void InitializeDoctrines()
	{
		DoctrineDefinitions.Add("BehaviorTowardsTargetAmbiguity", new DoctrineDefinition("BehaviorTowardsTargetAmbiguity", DoctrineItem_E.BehaviorTowardsAmbiguousTarget, "Engage Ambiguous", "Behavior Towards Target Ambiguity", new List<string> { "Ignore", "Optimistic", "Pessimistic", "Various", "Not Configured" }, DoctrineCategory.RoE, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "Pessimistic") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, true) }));
		DoctrineDefinitions.Add("WeaponControlStatus_Air", new DoctrineDefinition("WeaponControlStatus_Air", DoctrineItem_E.WeaponControlStatusAir, "WCS (Air)", "Weapon Control Status (Air)", new List<string> { "Free", "Tight", "Hold", "Various", "Not Configured" }, DoctrineCategory.RoE, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "Tight") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, true) }));
		DoctrineDefinitions.Add("WeaponControlStatus_Surface", new DoctrineDefinition("WeaponControlStatus_Surface", DoctrineItem_E.WeaponControlStatusSurface, "WCS (Surface)", "Weapon Control Status (Surface)", new List<string> { "Free", "Tight", "Hold", "Various", "Not Configured" }, DoctrineCategory.RoE, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "Tight") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, true) }));
		DoctrineDefinitions.Add("WeaponControlStatus_Submarine", new DoctrineDefinition("WeaponControlStatus_Submarine", DoctrineItem_E.WeaponControlStatusSubsurface, "WCS (Submarine)", "Weapon Control Status (Submarine)", new List<string> { "Free", "Tight", "Hold", "Various", "Not Configured" }, DoctrineCategory.RoE, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "Tight") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, true) }));
		DoctrineDefinitions.Add("WeaponControlStatus_Land", new DoctrineDefinition("WeaponControlStatus_Land", DoctrineItem_E.WeaponControlStatusLand, "WCS (Land)", "Weapon Control Status (Land)", new List<string> { "Free", "Tight", "Hold", "Various", "Not Configured" }, DoctrineCategory.RoE, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "Tight") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, true) }));
		DoctrineDefinitions.Add("QuickTurnAroundForAicraft", new DoctrineDefinition("QuickTurnAroundForAicraft", DoctrineItem_E.QuickTurnAroundForAircraft, "Quick TurnAround", "Quick TurnAround For Aicraft", new List<string> { "Yes", "Fighters And ASW", "No", "Various", "Not Configured" }, DoctrineCategory.Air_Ops, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "Fighters And ASW") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, false) }));
		DoctrineDefinitions.Add("AirOpsTempo", new DoctrineDefinition("AirOpsTempo", DoctrineItem_E.AirOpsTempo, "Air Ops Tempo", "Air Ops Tempo", new List<string> { "Surge", "Sustained", "Various", "Not Configured" }, DoctrineCategory.Air_Ops, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "Surge") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, false) }));
		DoctrineDefinitions.Add("WinchesterShotgun", new DoctrineDefinition("WinchesterShotgun", DoctrineItem_E.WinchesterShotgun, "Weapon State", "Weapon State (Winchester Shotgun)", new List<(string, int)>
		{
			("Loadout Setting", 0),
			("Winchester: Mission-specific weapons have been expended. Disengage immediately", 2001),
			("Winchester: Mission-specific weapons have been expended. Allow targets of opportunity with air-to-air guns. PREFERRED!", 2002),
			("Shotgun: All BVR or Stand-Off weapons have been expended. Disengage immediately", 3001),
			("Shotgun: All BVR or Stand-Off weapons have been expended. Allow easy targets of opportunity with WVR or Strike weapons. No air-to-air guns", 3002),
			("Shotgun: All BVR or Stand-Off weapons have been expended. Allow easy targets of opportunity with WVR or Strike weapons, and air-to-air guns", 3003),
			("Shotgun: One engagement with BVR or Stand-Off weapons. Disengage immediately", 5001),
			("Shotgun: One engagement with BVR or Stand-Off weapons. Allow easy targets of opportunity with WVR or Strike weapons. No air-to-air guns. PREFERRED!", 5002),
			("Shotgun: One engagement with BVR or Stand-Off weapons. Allow easy targets of opportunity with WVR or Strike weapons, and air-to-air guns", 5003),
			("Shotgun: One engagement with both BVR and WVR or Stand-Off and Strike weapons. No air-to-air guns.", 5005),
			("Shotgun: One engagement with both BVR and WVR or Stand-Off and Strike weapons. Allow easy targets of opportunity with air-to-air guns. PREFERRED!", 5006),
			("Shotgun: One engagement with WVR or Strike weapons. Disengage immediately", 5011),
			("Shotgun: One engagement with WVR or Strike weapons. Allow targets of opportunity with air-to-air guns. PREFERRED!", 5012),
			("Shotgun: One engagement with guns", 5021),
			("Shotgun: 25% of relevant weapons have been expended. Disengage immediately", 4001),
			("Shotgun: 25% of relevant weapons have been expended. Allow targets of opportunity, including air-to-air guns", 4002),
			("Shotgun: 50% of relevant weapons have been expended. Disengage immediately", 4011),
			("Shotgun: 50% of relevant weapons have been expended. Allow targets of opportunity, including air-to-air guns", 4012),
			("Shotgun: 75% of relevant weapons have been expended. Disengage immediately", 4021),
			("Shotgun: 75% of relevant weapons have been expended. Allow targets of opportunity, including air-to-air guns", 4022),
			("Various", 1),
			("Not Configured", 2)
		}, DoctrineCategory.Air_Ops, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "Loadout Setting") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, true) }));
		DoctrineDefinitions.Add("UseKinematicRangeForTorpedoes", new DoctrineDefinition("UseKinematicRangeForTorpedoes", DoctrineItem_E.UseKinematicRangeForTorpedoes, "Torpedo Range", "Use Kinematic Range For Torpedoes", new List<(string, int)>
		{
			("Automatic And Manual Fire", 0),
			("Manual Fire Only", 1),
			("No", 2),
			("Various", 3),
			("Not Configured", 4)
		}, DoctrineCategory.ASW, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "No") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, true) }));
		DoctrineDefinitions.Add("UseUnderwayRefuelAndReplenishment", new DoctrineDefinition("UseUnderwayRefuelAndReplenishment", DoctrineItem_E.UseReplenishment, "Refuel", "Use Underway Refuel And Replenishment", new List<(string, int)>
		{
			("Always Except Tankers Refuelling Tankers", 0),
			("Never", 1),
			("Always Including Tankers Refuelling Tankers", 2),
			("Various", 3),
			("Not Configured", 4)
		}, DoctrineCategory.Refuel, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "Always Except Tankers Refuelling Tankers") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, true) }));
		DoctrineDefinitions.Add("UnderwayRefuelAndReplenishmentSelection", new DoctrineDefinition("UnderwayRefuelAndReplenishmentSelection", DoctrineItem_E.ReplenishmentSelection, "Refuel Selection", "Underway Refuel And Replenishment Selection", new List<(string, int)>
		{
			("Pick Nearest", 0),
			("Tankers Between Us And Objective Only", 1),
			("Tankers Between Us And Objective But Allow Emergency Turnaround", 2),
			("Various", 3),
			("Not Configured", 4)
		}, DoctrineCategory.Refuel, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "Pick Nearest") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, true) }));
		DoctrineDefinitions.Add("UseSAMsAgainstShips", new DoctrineDefinition("UseSAMsAgainstShips", DoctrineItem_E.UseSAMsOnASuW, "Anti-Surface SAMs", "Use SAMs Against Ships", new List<(string, int)>
		{
			("No", 0),
			("Yes", 1),
			("Various", 2),
			("Not Configured", 3)
		}, DoctrineCategory.ASuW, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "No") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, true) }));
		DoctrineDefinitions.Add("AAW_Guidance", new DoctrineDefinition("AAW_Guidance", DoctrineItem_E.MissileEngagement_ContinueGuidanceForImpossibleIntercept, "AAW Guidance", "Continue missile guidance even when current intercept appears impossible.", new List<string> { "Always Continue Guidance", "Drop Guidance When Intercept Appears Impossible", "Various", "Not Configured" }, DoctrineCategory.RoE, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "Always Continue Guidance") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, false) }));
		DoctrineDefinitions.Add("AAW_Rearward_Fire", new DoctrineDefinition("AAW_Rearward_Fire", DoctrineItem_E.MissileEngagement_FireOverTheShoulder, "AAW Rearward Fire", "Fire missiles at targets that will pass the shooter before intercept is possible.", new List<string> { "Always Fire", "Fire vs. Aircraft or Weapons: Only if Closing and Intercept is in Front Of Shooter", "Fire vs. Aircraft: Only if Closing and Intercept is in Front Of Shooter", "Fire vs. Weapons: Only if Closing and Intercept is in Front Of Shooter", "Various", "Not Configured" }, DoctrineCategory.RoE, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "Always Fire") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, false) }));
		DoctrineDefinitions.Add("AAW_WRA_qty", new DoctrineDefinition("AAW_WRA_qty", DoctrineItem_E.MissileEngagement_WRACounting, "AAW WRA Qty", "How to count weapons when fulfilling WRA quantity for AAW Engagements.", new List<string> { "For All Targets, WRA Quantity is Fulfilled Separately for each Weapon by Database ID", "For Aircraft or Weapon Targets, WRA Quantity is Fulfilled by any Guided Weapon", "For Aircraft Targets, WRA Quantity is Fulfilled by any Guided Weapon", "For Weapon Targets, WRA Quantity is Fulfilled by any Guided Weapon", "Various", "Not Configured" }, DoctrineCategory.RoE, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "For Weapon Targets, WRA Quantity is Fulfilled by any Guided Weapon") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, false) }));
		DoctrineDefinitions.Add("UseWpMissileAgainstShips", new DoctrineDefinition("UseWpMissileAgainstShips", DoctrineItem_E.const_27, "ASuW WP Missiles", "Use Waypoint-Capable Missile Against Ships", new List<(string, int)>
		{
			("No", 0),
			("Yes", 1),
			("Various", 2),
			("Not Configured", 3)
		}, DoctrineCategory.RoE, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "No") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, true) }));
		DoctrineDefinitions.Add("UseShootTourists", new DoctrineDefinition("UseShootTourists", DoctrineItem_E.ShootTourists, "Engage Opportunities", "Use Shoot Tourists", new List<(string, int)>
		{
			("No", 0),
			("Yes", 1),
			("Various", 2),
			("Not Configured", 3)
		}, DoctrineCategory.RoE, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "No") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, true) }));
		DoctrineDefinitions.Add("StrikeMemberFocus", new DoctrineDefinition("StrikeMemberFocus", DoctrineItem_E.StrikeMemberFocus, "Strike Mission Focus", "", new List<(string, int)>
		{
			("Opportunity Scrambling", 0),
			("Prioritize Mission Specific Targets", 1),
			("Only Engage Mission Specific Targets", 2),
			("Not Configured", 3)
		}, DoctrineCategory.RoE, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "Prioritize Mission Specific Targets") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, true) }));
		DoctrineDefinitions.Add("UseIgnoreEMCONunderAttack", new DoctrineDefinition("UseIgnoreEMCONunderAttack", DoctrineItem_E.IgnoreEMCONunderAttack, "Ignore Under Attack", "Use Ignore EMCON Under Attack", new List<(string, int)>
		{
			("No", 0),
			("Yes", 1),
			("Various", 2),
			("Not Configured", 3)
		}, DoctrineCategory.EMCON, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "Yes") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, true) }));
		DoctrineDefinitions.Add("UseAutoEvade", new DoctrineDefinition("UseAutoEvade", DoctrineItem_E.AutoEvade, "Auto Evade", "Use Auto Evade", new List<(string, int)>
		{
			("No", 0),
			("Yes", 1),
			("Various", 2),
			("Not Configured", 3)
		}, DoctrineCategory.RoE, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "Yes") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, true) }));
		DoctrineDefinition doctrineDefinition = new DoctrineDefinition("ThreatMaxDist", DoctrineItem_E.ThreatMaxDist, "Threat Max Distance", "Maximum range at which an inbound weapon is considered a threat." + Environment.NewLine + "\r\nMissiles beyond this distance are ignored for threat evaluation and defensive reactions.", new List<string>(), DoctrineCategory.RoE);
		DoctrineDefinitions.Add("ThreatMaxDist", doctrineDefinition);
		doctrineDefinition.MinNumericValue = 10;
		doctrineDefinition.MaxNumericValue = 210;
		doctrineDefinition.MeasurementUnit = "Nm";
		doctrineDefinition.DefaultState[0] = 30;
		doctrineDefinition.DefaultState[2] = 30;
		doctrineDefinition.DefaultState[1] = 30;
		DoctrineDefinitions.Add("UseMaintainStandoff", new DoctrineDefinition("UseMaintainStandoff", DoctrineItem_E.MaintainStandoff, "Maintain Standoff", "Use Maintain Standoff", new List<(string, int)>
		{
			("No", 0),
			("Yes", 1),
			("Various", 2),
			("Not Configured", 3)
		}, DoctrineCategory.RoE, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "Yes") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, true) }));
		DoctrineDefinitions.Add("NavigationMethodSubmarine", new DoctrineDefinition("NavigationMethodSubmarine", DoctrineItem_E.NavSubSurface, "Navigation (Submarine)", "Navigation Method (Submarine)", new List<(string, int)>
		{
			("Shortest Route", 0),
			("Deep Water Navigation 1525m+ (5000ft+)", 1),
			("CZ", 2),
			("Littoral", 3),
			("Various", 4),
			("Not Configured", 5)
		}, DoctrineCategory.ASW, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "Shortest Route") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, true) }));
		DoctrineDefinitions.Add("NavigationMethodSurface", new DoctrineDefinition("NavigationMethodSurface", DoctrineItem_E.NavSurface, "Navigation (Surface)", "Navigation Method (Surface)", new List<(string, int)>
		{
			("Shortest Route", 0),
			("Deep Water Navigation 1525m+ (5000ft+)", 1),
			("Littoral Navigation 200m (660ft)", 2),
			("Various", 3),
			("Not Configured", 4)
		}, DoctrineCategory.ASuW, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "Shortest Route") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, true) }));
		DoctrineDefinitions.Add("NavigationMethodLand", new DoctrineDefinition("NavigationMethodLand", DoctrineItem_E.NavLand, "Navigation (Land)", "Navigation Method (Land)", new List<(string, int)>
		{
			("Shortest Route", 0),
			("Direct", 1),
			("Various", 2),
			("Not Configured", 3)
		}, DoctrineCategory.Land, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "Shortest Route") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, true) }));
		DoctrineDefinitions.Add("GunStrafeGroundTargets", new DoctrineDefinition("GunStrafeGroundTargets", DoctrineItem_E.GunStrafing, "A/G Strafing (Gun)", "Gun Strafe Ground Targets", new List<(string, int)>
		{
			("No", 0),
			("Yes", 1),
			("Various", 2),
			("Not Configured", 3)
		}, DoctrineCategory.Air_Ops, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "No") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, true) }));
		DoctrineDefinitions.Add("UseIgnorePlottedCourse", new DoctrineDefinition("UseIgnorePlottedCourse", DoctrineItem_E.IgnorePlottedCourse, "Ignore Plotted Course", "Use Ignore Plotted Course", new List<(string, int)>
		{
			("No", 0),
			("Yes", 1),
			("Various", 2),
			("Not Configured", 3)
		}, DoctrineCategory.RoE, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "No") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, true) }));
		DoctrineDefinitions.Add("UseNukesAllowed", new DoctrineDefinition("UseNukesAllowed", DoctrineItem_E.NukesAllowed, "Nuclear Weapons", "Nuclear Weapons", new List<(string, int)>
		{
			("No", 0),
			("Yes", 1),
			("Various", 2),
			("Not Configured", 3)
		}, DoctrineCategory.RoE, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "No") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, false) }));
		DoctrineDefinitions.Add("RedeployAttackThreshold", new DoctrineDefinition("RedeployAttackThreshold", DoctrineItem_E.DeployAttack, "Redeploy Threshold (Attack)", "", new List<(string, int)>
		{
			("Ignore", 0),
			("Exhausted", 1),
			("25%", 2),
			("50%", 3),
			("75%", 4),
			("100%", 5),
			("Load Full Weapons", 6),
			("Various", 7),
			("Not Configured", 8)
		}, DoctrineCategory.RedeployCondition, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "100%") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, false) }));
		DoctrineDefinitions.Add("RedeployDefenseThreshold", new DoctrineDefinition("RedeployDefenseThreshold", DoctrineItem_E.DeployDefence, "Redeploy Threshold (Defense)", "", new List<(string, int)>
		{
			("Ignore", 0),
			("Exhausted", 1),
			("25%", 2),
			("50%", 3),
			("75%", 4),
			("100%", 5),
			("Load Full Weapons", 6),
			("Various", 7),
			("Not Configured", 8)
		}, DoctrineCategory.RedeployCondition, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "100%") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, false) }));
		DoctrineDefinitions.Add("WinchesterShotgunRTB", new DoctrineDefinition("WinchesterShotgunRTB", DoctrineItem_E.const_20, "Weapon State RTB", "RTB (Winchester Shotgun)", new List<(string, int)>
		{
			("No", 0),
			("Yes Last Unit", 1),
			("Yes First Unit", 2),
			("Yes Leave Group", 3),
			("Various", 4),
			("Not Configured", 5)
		}, DoctrineCategory.Air_Ops, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "Yes Last Unit") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, true) }));
		DoctrineDefinitions.Add("JettisonOrdnance", new DoctrineDefinition("JettisonOrdnance", DoctrineItem_E.Jettison, "Jettison Ordnance", "Jettison Ordnance", new List<(string, int)>
		{
			("No", 0),
			("Yes", 1),
			("Various", 2),
			("Not Configured", 3)
		}, DoctrineCategory.Air_Ops, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "No") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, true) }));
		DoctrineDefinitions.Add("BVRLogicEnum", new DoctrineDefinition("BVRLogicEnum", DoctrineItem_E.BVRLogic, "BVR Logic Enum", "", new List<(string, int)>
		{
			("Straight In", 0),
			("Crank", 1),
			("Crank And Drag", 2),
			("Various", 3),
			("Not Configured", 4),
			("Drag Immediately", 5)
		}, DoctrineCategory.Air_Ops, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "Crank") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, true) }));
		DoctrineDefinitions.Add("RefuelAlliedUnits", new DoctrineDefinition("RefuelAlliedUnits", DoctrineItem_E.RefuelAllies, "Refuel Allies", "Refuel Allied Units", new List<(string, int)>
		{
			("Yes", 0),
			("Yes Receive Only", 1),
			("Yes Deliver Only", 2),
			("No", 3),
			("Various", 4),
			("Not Configured", 5)
		}, DoctrineCategory.Refuel, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "Yes") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, true) }));
		DoctrineDefinitions.Add("BingoThreshold", new DoctrineDefinition("BingoThreshold", DoctrineItem_E.BingoThreshold, "Fuel State (Bingo)", "Bingo Threshold", new List<(string, int)>
		{
			("Bingo 30%", 0),
			("Bingo 40%", 1),
			("Bingo 50%", 2),
			("Bingo 60%", 3),
			("Bingo 70%", 4),
			("Bingo 80%", 5),
			("Various", 6),
			("Not Configured", 7)
		}, DoctrineCategory.Refuel, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "Bingo 60%") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, true) }));
		DoctrineDefinitions.Add("BingoJoker", new DoctrineDefinition("BingoJoker", DoctrineItem_E.BingoJoker, "Fuel State (Joker)", "Bingo Joker", new List<(string, int)>
		{
			("Bingo", 0),
			("Joker 10%", 1),
			("Joker 20%", 2),
			("Joker 25%", 3),
			("Joker 30%", 4),
			("Joker 40%", 5),
			("Joker 50%", 6),
			("Joker 60%", 7),
			("Joker 70%", 8),
			("Joker 75%", 9),
			("Joker 80%", 10),
			("Joker 90%", 11),
			("Various", 12),
			("Chicken", 13),
			("Not Configured", 14)
		}, DoctrineCategory.Air_Ops, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "Bingo") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, true) }));
		DoctrineDefinitions.Add("BingoJokerRTB", new DoctrineDefinition("BingoJokerRTB", DoctrineItem_E.BingoJokerRTB, "Fuel State RTB (Joker)", "Bingo Joker (RTB)", new List<(string, int)>
		{
			("No", 0),
			("Yes, Last Unit", 1),
			("Yes, First Unit", 2),
			("Yes, Leave Group", 3),
			("Various", 4),
			("Not Configured", 5)
		}, DoctrineCategory.Air_Ops, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "Yes, First Unit") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, true) }));
		DoctrineDefinitions.Add("AvoidContactWhenPossible", new DoctrineDefinition("AvoidContactWhenPossible", DoctrineItem_E.AvoidContact, "Avoid Contact", "Avoid Contact When Possible", new List<(string, int)>
		{
			("No", 0),
			("Yes Except Self-Defence", 1),
			("Yes Always", 2),
			("Various", 3),
			("Not Configured", 4)
		}, DoctrineCategory.ASW, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "No") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, true) }));
		DoctrineDefinitions.Add("DiveOnContact", new DoctrineDefinition("DiveOnContact", DoctrineItem_E.DiveWhenThreatsDetected, "Dive On Threat", "Dive On Contact", new List<(string, int)>
		{
			("Yes", 0),
			("Yes ESM Only", 1),
			("Yes Ships (20nm) Aircraft (30nm)", 2),
			("No", 3),
			("Various", 4),
			("Not Configured", 5)
		}, DoctrineCategory.ASW, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "Yes") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, true) }));
		DoctrineDefinitions.Add("RechargeBatteryPercentagePatrol", new DoctrineDefinition("RechargeBatteryPercentagePatrol", DoctrineItem_E.RechargePercentagePatrol, "Recharge (Patrol)", "Recharge Battery Percentage (Patrol)", new List<(string, int)>
		{
			("Recharge Empty", 0),
			("Recharge 10%", 10),
			("Recharge 20%", 20),
			("Recharge 30%", 30),
			("Recharge 40%", 40),
			("Recharge 50%", 50),
			("Recharge 60%", 60),
			("Recharge 70%", 70),
			("Recharge 80%", 80),
			("Recharge 90%", 90),
			("Various", -100),
			("Not Configured", -101)
		}, DoctrineCategory.ASW, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "Recharge 60%") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, true) }));
		DoctrineDefinitions.Add("RechargeBatteryPercentageAttack", new DoctrineDefinition("RechargeBatteryPercentageAttack", DoctrineItem_E.RechargePercentageAttack, "Recharge (Attack)", "Recharge Battery Percentage (Attack)", new List<(string, int)>
		{
			("Recharge Empty", 0),
			("Recharge 10%", 10),
			("Recharge 20%", 20),
			("Recharge 30%", 30),
			("Recharge 40%", 40),
			("Recharge 50%", 50),
			("Recharge 60%", 60),
			("Recharge 70%", 70),
			("Recharge 80%", 80),
			("Recharge 90%", 90),
			("Various", -100),
			("Not Configured", -101)
		}, DoctrineCategory.ASW, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "Recharge 10%") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, true) }));
		DoctrineDefinitions.Add("UseAIP", new DoctrineDefinition("UseAIP", DoctrineItem_E.AIPUsage, "AIP Usage", "Use AIP", new List<(string, int)>
		{
			("No", 0),
			("Yes Attack Only", 1),
			("Yes Always", 2),
			("Various", 3),
			("Not Configured", 4)
		}, DoctrineCategory.ASW, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "Yes Attack Only") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, true) }));
		DoctrineDefinitions.Add("UseDippingSonar", new DoctrineDefinition("UseDippingSonar", DoctrineItem_E.DippingSonar, "Dipping Sonar", "Use Dipping Sonar", new List<(string, int)>
		{
			("Automatically Hover at 150ft", 0),
			("Manual And MissionOnly", 1),
			("Various", 2),
			("Not Configured", 3)
		}, DoctrineCategory.ASW, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "Automatically Hover at 150ft") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, true) }));
		DoctrineDefinitions.Add("SonobuoyUse", new DoctrineDefinition("SonobuoyUse", DoctrineItem_E.SonobuoyUse, "Sonobuoy Use", "Control AI use of Sonobuoys", new List<(string, int)>
		{
			("Automatic for search and localization", 0),
			("Automatic for localization", 1),
			("Manual (player order) only", 2),
			("Various", 3),
			("Not Configured", 4)
		}, DoctrineCategory.ASW, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "Automatic for search and localization") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, true) }));
		DoctrineDefinitions.Add("DamageThresholdWithdraw", new DoctrineDefinition("DamageThresholdWithdraw", DoctrineItem_E.WithdrawDamage, "Damage Threshold (Withdraw)", "", new List<(string, int)>
		{
			("Ignore", 0),
			("5%", 1),
			("25%", 2),
			("50%", 3),
			("75%", 4),
			("Various", 5),
			("Not Configured", 6)
		}, DoctrineCategory.WithdrawCondition, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "Ignore") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, true) }));
		DoctrineDefinitions.Add("AttackThresholdWithdraw", new DoctrineDefinition("AttackThresholdWithdraw", DoctrineItem_E.WithdrawAttack, "Attack Threshold (Withdraw)", "", new List<(string, int)>
		{
			("Ignore", 0),
			("Exhausted", 1),
			("25%", 2),
			("50%", 3),
			("75%", 4),
			("100%", 5),
			("Load Full Weapons", 6),
			("Various", 7),
			("Not Configured", 8)
		}, DoctrineCategory.WithdrawCondition, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "Ignore") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, false) }));
		DoctrineDefinitions.Add("DefenceThresholdWithdraw", new DoctrineDefinition("DefenceThresholdWithdraw", DoctrineItem_E.WithdrawDefence, "Defence Threshold (Withdraw)", "", new List<(string, int)>
		{
			("Ignore", 0),
			("Exhausted", 1),
			("25%", 2),
			("50%", 3),
			("75%", 4),
			("100%", 5),
			("Load Full Weapons", 6),
			("Various", 7),
			("Not Configured", 8)
		}, DoctrineCategory.WithdrawCondition, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "Ignore") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, false) }));
		DoctrineDefinitions.Add("DamageThresholdRedeploy", new DoctrineDefinition("DamageThresholdRedeploy", DoctrineItem_E.DeployDamage, "Damage Threshold (Redeploy)", "", new List<(string, int)>
		{
			("Ignore", 0),
			("5%", 1),
			("25%", 2),
			("50%", 3),
			("75%", 4),
			("Various", 5),
			("Not Configured", 6)
		}, DoctrineCategory.RedeployCondition, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "5%") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, true) }));
		DoctrineDefinitions.Add("FuelQuantityThreshold_Withdraw", new DoctrineDefinition("FuelQuantityThreshold_Withdraw", DoctrineItem_E.WithdrawFuel, "Fuel Threshold (Withdraw)", "", new List<(string, int)>
		{
			("Ignore", 0),
			("Bingo", 1),
			("25%", 2),
			("50%", 3),
			("75%", 4),
			("100%", 5),
			("Various", 6),
			("Not Configured", 7)
		}, DoctrineCategory.RedeployCondition, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "Bingo") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, false) }));
		DoctrineDefinitions.Add("FuelQuantityThreshold_Redeploy", new DoctrineDefinition("FuelQuantityThreshold_Redeploy", DoctrineItem_E.DeployFuel, "Fuel Threshold (Redeploy)", "", new List<(string, int)>
		{
			("Ignore", 0),
			("Bingo", 1),
			("25%", 2),
			("50%", 3),
			("75%", 4),
			("100%", 5),
			("Various", 6),
			("Not Configured", 7)
		}, DoctrineCategory.RedeployCondition, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "100%") }, new List<(DoctrinePossibleSubjects, bool)> { (DoctrinePossibleSubjects.Side, false) }));
		DoctrineDefinitions.Add("AGU_TacticalPosture", new DoctrineDefinition("AGU_TacticalPosture", DoctrineItem_E.AGU_TacticalPosture, "AGU Tactical Posture", "Determines aggressiveness, pressure behaviour and planned withdrawals.", new List<(string, int)>
		{
			("Withdraw", 0),
			("Delay", 1),
			("Hold", 2),
			("Push", 3),
			("Breakthrough", 4),
			("Not Configured", 5)
		}, DoctrineCategory.AGU, new List<(DoctrinePossibleSubjects, string)> { (DoctrinePossibleSubjects.Side, "Hold") }));
		foreach (DoctrineDefinition item in DoctrineDefinitions.Values.ToList())
		{
			item.AddDefaultState(DoctrinePossibleSubjects.Waypoint, "NotConfigured", ThrowOnFailure: false);
		}
		try
		{
			DoctrineDefinitions["UseNukesAllowed"].DefineBackwardCompatibilityRules(new List<string> { "NukesAllowed", "Nukes" }, new List<string> { "Nukes_Player" }, _UseLegacyBooleanState: true, "Yes", "use_nuclear_weapons");
			DoctrineDefinitions["WeaponControlStatus_Air"].DefineBackwardCompatibilityRules(new List<string> { "WCS_Air" }, new List<string> { "WCS_Air_Player" }, _UseLegacyBooleanState: true, "Free", "weapon_control_status_air");
			DoctrineDefinitions["WeaponControlStatus_Surface"].DefineBackwardCompatibilityRules(new List<string> { "WCS_Surface" }, new List<string> { "WCS_Surface_Player" }, _UseLegacyBooleanState: false, "", "weapon_control_status_surface");
			DoctrineDefinitions["WeaponControlStatus_Submarine"].DefineBackwardCompatibilityRules(new List<string> { "WCS_Submarine" }, new List<string> { "WCS_Submarine_Player" }, _UseLegacyBooleanState: false, "", "weapon_control_status_subsurface");
			DoctrineDefinitions["WeaponControlStatus_Land"].DefineBackwardCompatibilityRules(new List<string> { "WCS_Land" }, new List<string> { "WCS_Land_Player" }, _UseLegacyBooleanState: false, "", "weapon_control_status_land");
			DoctrineDefinitions["GunStrafeGroundTargets"].DefineBackwardCompatibilityRules(new List<string> { "GS" }, new List<string> { "GS_Player" }, _UseLegacyBooleanState: false, "", "gun_strafing");
			DoctrineDefinitions["UseIgnorePlottedCourse"].DefineBackwardCompatibilityRules(new List<string> { "IPCWA" }, new List<string> { "IPCWA_Player" }, _UseLegacyBooleanState: true, "Yes", "ignore_plotted_course");
			DoctrineDefinitions["WinchesterShotgunRTB"].DefineBackwardCompatibilityRules(new List<string> { "WinchesterShotgunRTB", "RTBWhenWinchester", "RTBWW" }, new List<string> { "WinchesterShotgunRTB_Player", "RTBWW_Player", "rtb_when_winchester" }, _UseLegacyBooleanState: true, "YesLeaveGroup", "weapon_state_rtb");
			DoctrineDefinitions["BingoJokerRTB"].DefineBackwardCompatibilityRules(new List<string> { "BingoJokerRTB" }, new List<string> { "BingoJokerRTB_Player" }, _UseLegacyBooleanState: false, "", "fuel_state_rtb");
			DoctrineDefinitions["JettisonOrdnance"].DefineBackwardCompatibilityRules(new List<string> { "JettisonOrdnance" }, new List<string> { "JettisonOrdnance_Player" }, _UseLegacyBooleanState: false, "", "jettison_ordnance");
			DoctrineDefinitions["BVRLogicEnum"].DefineBackwardCompatibilityRules(new List<string> { "BVRLogic" }, new List<string> { "BVRLogic_Player" }, _UseLegacyBooleanState: false, "", "bvr_logic");
			DoctrineDefinitions["BehaviorTowardsTargetAmbiguity"].DefineBackwardCompatibilityRules(new List<string> { "BehaviorTowardsAmbigousTarget", "BTAT" }, new List<string> { "BTAT_Player" }, _UseLegacyBooleanState: true, "Pessimistic", "engaging_ambiguous_targets");
			DoctrineDefinitions["UseAutoEvade"].DefineBackwardCompatibilityRules(new List<string> { "AE" }, new List<string> { "AE_Player" }, _UseLegacyBooleanState: true, "Yes", "automatic_evasion");
			DoctrineDefinitions["UseMaintainStandoff"].DefineBackwardCompatibilityRules(new List<string> { "MS" }, new List<string> { "MS_Player" }, _UseLegacyBooleanState: true, "Yes", "maintain_standoff");
			DoctrineDefinitions["UnderwayRefuelAndReplenishmentSelection"].DefineBackwardCompatibilityRules(new List<string> { "UR" }, new List<string> { "UR_Player" }, _UseLegacyBooleanState: false, "Always_ExceptTankersRefuellingTankers", "unrep_selection");
			DoctrineDefinitions["UseUnderwayRefuelAndReplenishment"].DefineBackwardCompatibilityRules(new List<string> { "RS" }, new List<string> { "RS_Player" }, _UseLegacyBooleanState: false, "", "use_refuel_unrep");
			DoctrineDefinitions["UseShootTourists"].DefineBackwardCompatibilityRules(new List<string> { "ST" }, new List<string> { "ST_Player" }, _UseLegacyBooleanState: true, "No", "engage_opportunity_targets");
			DoctrineDefinitions["UseSAMsAgainstShips"].DefineBackwardCompatibilityRules(new List<string> { "SAM_ASUW" }, new List<string> { "SAM_ASUW_Player" }, _UseLegacyBooleanState: true, "No", "use_sams_in_anti_surface_mode");
			DoctrineDefinitions["UseWpMissileAgainstShips"].DefineBackwardCompatibilityRules(new List<string> { "WPMissile_ASUW" }, new List<string> { "WPMissile_ASUW_Player" }, _UseLegacyBooleanState: true, "No", "use_wp_missile_in_anti_surface_mode");
			DoctrineDefinitions["QuickTurnAroundForAicraft"].DefineBackwardCompatibilityRules(new List<string> { "QuickTurnAround" }, new List<string> { "QuickTurnAround_Player", "QTA_Player" }, _UseLegacyBooleanState: false, "", "quick_turnaround_for_aircraft");
			DoctrineDefinitions["BingoJoker"].DefineBackwardCompatibilityRules(new List<string> { "BingoJoker" }, new List<string> { "BingoJoker_Player" }, _UseLegacyBooleanState: false, "", "fuel_state_planned");
			DoctrineDefinitions["WinchesterShotgun"].DefineBackwardCompatibilityRules(new List<string> { "WinchesterShotgun" }, new List<string> { "WinchesterShotgun_Player" }, _UseLegacyBooleanState: false, "", "weapon_state_planned");
			DoctrineDefinitions["DamageThresholdWithdraw"].DefineBackwardCompatibilityRules(new List<string> { "WithdrawDamageThreshold" }, new List<string>(), _UseLegacyBooleanState: false, "", "withdraw_on_damage");
			DoctrineDefinitions["FuelQuantityThreshold_Withdraw"].DefineBackwardCompatibilityRules(new List<string> { "WithdrawFuelThreshold" }, new List<string>(), _UseLegacyBooleanState: false, "", "withdraw_on_fuel");
			DoctrineDefinitions["AttackThresholdWithdraw"].DefineBackwardCompatibilityRules(new List<string> { "WithdrawAttackThreshold" }, new List<string>(), _UseLegacyBooleanState: false, "", "withdraw_on_attack");
			DoctrineDefinitions["DefenceThresholdWithdraw"].DefineBackwardCompatibilityRules(new List<string> { "WithdrawDefenceThreshold" }, new List<string>(), _UseLegacyBooleanState: false, "", "withdraw_on_defence");
			DoctrineDefinitions["DamageThresholdRedeploy"].DefineBackwardCompatibilityRules(new List<string> { "RedeployDamageThreshold" }, new List<string>(), _UseLegacyBooleanState: false, "", "deploy_on_damage");
			DoctrineDefinitions["FuelQuantityThreshold_Redeploy"].DefineBackwardCompatibilityRules(new List<string> { "RedeployFuelThreshold" }, new List<string>(), _UseLegacyBooleanState: false, "", "deploy_on_fuel");
			DoctrineDefinitions["RedeployAttackThreshold"].DefineBackwardCompatibilityRules(new List<string> { "RedeployAttackThreshold" }, new List<string>(), _UseLegacyBooleanState: false, "", "deploy_on_attack");
			DoctrineDefinitions["RedeployDefenseThreshold"].DefineBackwardCompatibilityRules(new List<string> { "RedeployDefenceThreshold" }, new List<string>(), _UseLegacyBooleanState: false, "", "deploy_on_defence");
			DoctrineDefinitions["AirOpsTempo"].DefineBackwardCompatibilityRules(new List<string> { "AirOpsTempo" }, new List<string> { "AirOpsTempo_Player" }, _UseLegacyBooleanState: false, "", "air_operations_tempo");
			DoctrineDefinitions["UseIgnoreEMCONunderAttack"].DefineBackwardCompatibilityRules(new List<string> { "IgnoreEMCONUnderAttack" }, new List<string> { "IgnoreEMCONUnderAttack_Player" }, _UseLegacyBooleanState: false, "", "ignore_emcon_while_under_attack");
			DoctrineDefinitions["UseKinematicRangeForTorpedoes"].DefineBackwardCompatibilityRules(new List<string> { "UseTorpedoesKinematicRange" }, new List<string> { "UseTorpedoesKinematicRange_Player" }, _UseLegacyBooleanState: false, "", "kinematic_range_for_torpedoes");
			DoctrineDefinitions["RefuelAlliedUnits"].DefineBackwardCompatibilityRules(new List<string> { "RefuelAllies" }, new List<string> { "RefuelAllies_Player" }, _UseLegacyBooleanState: false, "", "refuel_unrep_allied");
			DoctrineDefinitions["BingoThreshold"].DefineBackwardCompatibilityRules(new List<string> { "BingoThreshold" }, new List<string> { "BingoThreshold_Player" }, _UseLegacyBooleanState: false, "", "bingo_threshold");
			DoctrineDefinitions["AvoidContactWhenPossible"].DefineBackwardCompatibilityRules(new List<string> { "AvoidContact" }, new List<string> { "AvoidContact_Player" }, _UseLegacyBooleanState: false, "", "avoid_contact");
			DoctrineDefinitions["RechargeBatteryPercentagePatrol"].DefineBackwardCompatibilityRules(new List<string> { "RechargePercentagePatrol" }, new List<string> { "RechargePercentagePatrol_Player" }, _UseLegacyBooleanState: false, "", "recharge_on_patrol");
			DoctrineDefinitions["RechargeBatteryPercentageAttack"].DefineBackwardCompatibilityRules(new List<string> { "RechargePercentageAttack" }, new List<string> { "RechargePercentageAttack_Player" }, _UseLegacyBooleanState: false, "", "recharge_on_attack");
			DoctrineDefinitions["UseAIP"].DefineBackwardCompatibilityRules(new List<string> { "AIPUsage" }, new List<string> { "AIPUsage_Player" }, _UseLegacyBooleanState: false, "", "use_aip");
			DoctrineDefinitions["UseDippingSonar"].DefineBackwardCompatibilityRules(new List<string> { "DippingSonar" }, new List<string> { "DippingSonar_Player" }, _UseLegacyBooleanState: false, "", "dipping_sonar");
			DoctrineDefinitions["NavigationMethodSurface"].DefineBackwardCompatibilityRules(new List<string> { "SurfNav" }, new List<string> { "SurfNav_Player" }, _UseLegacyBooleanState: false, "", "navigation_surface");
			DoctrineDefinitions["NavigationMethodSubmarine"].DefineBackwardCompatibilityRules(new List<string> { "SubNav" }, new List<string> { "SubNav_Player" }, _UseLegacyBooleanState: false, "", "navigation_sub_surface");
			DoctrineDefinitions["NavigationMethodLand"].DefineBackwardCompatibilityRules(new List<string> { "LandNav" }, new List<string> { "LandNav_Player" }, _UseLegacyBooleanState: false, "", "navigation_land");
			DoctrineDefinitions["DiveOnContact"].DefineBackwardCompatibilityRules(new List<string> { "DiveWhenThreatsDetected" }, new List<string> { "DiveWhenThreatsDetected_Player" }, _UseLegacyBooleanState: false, "", "dive_on_threat");
			DoctrineDefinitions["ThreatMaxDist"].UnitType_Requirement = new HashSet<GlobalVariables.ActiveUnitType> { GlobalVariables.ActiveUnitType.Aircraft };
			DoctrineDefinitions["WinchesterShotgun"].UnitType_Requirement = new HashSet<GlobalVariables.ActiveUnitType> { GlobalVariables.ActiveUnitType.Aircraft };
			DoctrineDefinitions["WinchesterShotgunRTB"].UnitType_Requirement = new HashSet<GlobalVariables.ActiveUnitType> { GlobalVariables.ActiveUnitType.Aircraft };
			DoctrineDefinitions["BingoJoker"].UnitType_Requirement = new HashSet<GlobalVariables.ActiveUnitType> { GlobalVariables.ActiveUnitType.Aircraft };
			DoctrineDefinitions["BingoJokerRTB"].UnitType_Requirement = new HashSet<GlobalVariables.ActiveUnitType> { GlobalVariables.ActiveUnitType.Aircraft };
			DoctrineDefinitions["WinchesterShotgun"].UnitType_Requirement = new HashSet<GlobalVariables.ActiveUnitType> { GlobalVariables.ActiveUnitType.Aircraft };
			DoctrineDefinitions["BingoThreshold"].UnitType_Requirement = new HashSet<GlobalVariables.ActiveUnitType> { GlobalVariables.ActiveUnitType.Aircraft };
			DoctrineDefinitions["NavigationMethodLand"].UnitType_Exclusion = new HashSet<GlobalVariables.ActiveUnitType>
			{
				GlobalVariables.ActiveUnitType.Satellite,
				GlobalVariables.ActiveUnitType.Weapon,
				GlobalVariables.ActiveUnitType.Aircraft,
				GlobalVariables.ActiveUnitType.Ship,
				GlobalVariables.ActiveUnitType.Submarine
			};
			DoctrineDefinitions["UseDippingSonar"].UnitType_Requirement = new HashSet<GlobalVariables.ActiveUnitType> { GlobalVariables.ActiveUnitType.Aircraft };
			DoctrineDefinitions["NavigationMethodSurface"].UnitType_Requirement = new HashSet<GlobalVariables.ActiveUnitType> { GlobalVariables.ActiveUnitType.Ship };
			DoctrineDefinitions["NavigationMethodSubmarine"].UnitType_Requirement = new HashSet<GlobalVariables.ActiveUnitType> { GlobalVariables.ActiveUnitType.Submarine };
			DoctrineDefinitions["BVRLogicEnum"].UnitType_Requirement = new HashSet<GlobalVariables.ActiveUnitType> { GlobalVariables.ActiveUnitType.Aircraft };
			DoctrineDefinitions["UseAIP"].UnitType_Requirement = new HashSet<GlobalVariables.ActiveUnitType> { GlobalVariables.ActiveUnitType.Submarine };
			DoctrineDefinitions["RechargeBatteryPercentageAttack"].UnitType_Requirement = new HashSet<GlobalVariables.ActiveUnitType> { GlobalVariables.ActiveUnitType.Submarine };
			DoctrineDefinitions["RechargeBatteryPercentagePatrol"].UnitType_Requirement = new HashSet<GlobalVariables.ActiveUnitType> { GlobalVariables.ActiveUnitType.Submarine };
			DoctrineDefinitions["DiveOnContact"].UnitType_Requirement = new HashSet<GlobalVariables.ActiveUnitType> { GlobalVariables.ActiveUnitType.Submarine };
			DoctrineDefinitions["AirOpsTempo"].UnitType_Requirement = new HashSet<GlobalVariables.ActiveUnitType> { GlobalVariables.ActiveUnitType.Aircraft };
			DoctrineDefinitions["GunStrafeGroundTargets"].UnitType_Requirement = new HashSet<GlobalVariables.ActiveUnitType> { GlobalVariables.ActiveUnitType.Aircraft };
			DoctrineDefinitions["JettisonOrdnance"].UnitType_Requirement = new HashSet<GlobalVariables.ActiveUnitType> { GlobalVariables.ActiveUnitType.Aircraft };
			DoctrineDefinitions["QuickTurnAroundForAicraft"].UnitType_Requirement = new HashSet<GlobalVariables.ActiveUnitType> { GlobalVariables.ActiveUnitType.Aircraft };
			DoctrineDefinitions["UseAutoEvade"].UnitType_Exclusion = new HashSet<GlobalVariables.ActiveUnitType> { GlobalVariables.ActiveUnitType.Satellite };
			DoctrineDefinitions["UseIgnorePlottedCourse"].UnitType_Exclusion = new HashSet<GlobalVariables.ActiveUnitType> { GlobalVariables.ActiveUnitType.Satellite };
			DoctrineDefinitions["AGU_TacticalPosture"].UnitType_Requirement = new HashSet<GlobalVariables.ActiveUnitType> { GlobalVariables.ActiveUnitType.AggregateGroundUnit };
			string path = Path.Combine(GameGeneral.TopLevelWritablePath + Conversions.ToString(Path.DirectorySeparatorChar) + "Resources", "Doctrines.json");
			List<DoctrineDefinition> list = new List<DoctrineDefinition>();
			if (!File.Exists(path))
			{
				_ = Debugger.IsAttached;
			}
			else
			{
				list = JsonConvert.DeserializeObject<List<DoctrineDefinition>>(File.ReadAllText(path));
			}
			foreach (DoctrineDefinition item2 in list)
			{
				foreach (KeyValuePair<int, string> state in item2.States)
				{
					item2._States_2way.Add(state.Value, state.Key);
				}
				DoctrineDefinitions.Add(item2.ID, item2);
			}
			DoctrineDefinitions_Array = new DoctrineDefinition[Enum.GetValues(typeof(DoctrineItem_E)).Cast<int>().Max() + 1];
			foreach (DoctrineDefinition value in DoctrineDefinitions.Values)
			{
				_CacheDoctrineDefinitions_PlayerEditDIC.Add(value.SaveID_PlayerEditable, value);
				_CacheDoctrineDefinitions_DIC.Add(value.SaveID, value);
				DoctrineDefinitions_Array[(int)value.EnumLink] = value;
			}
			int num = 100;
			foreach (DoctrineDefinition item3 in list)
			{
				item3.EnumLink = (DoctrineItem_E)num;
				DoctrineDefinitions[item3.ID] = item3;
				DoctrineDefinitions_Array[num] = item3;
				num++;
				if (num > 200)
				{
					throw new InvalidOperationException("Out of custom doctrine slots");
				}
			}
			foreach (KeyValuePair<string, DoctrineDefinition> doctrineDefinition2 in DoctrineDefinitions)
			{
				foreach (string item4 in doctrineDefinition2.Value._SaveID)
				{
					DoctrineDefinitions_Savable.Add(item4, doctrineDefinition2.Value);
				}
				if (!DoctrineDefinitions_Savable.ContainsKey(doctrineDefinition2.Value.SaveID))
				{
					DoctrineDefinitions_Savable.Add(doctrineDefinition2.Value.SaveID, doctrineDefinition2.Value);
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void Populate_DataTable_States(DataTable DT, ref DoctrineItem_E theDocEnum)
	{
		DT.Rows.Clear();
		DoctrineDefinition doctrineDefinition = null;
		if (!DT.Columns.Contains("ID"))
		{
			DT.Columns.Add("ID", typeof(int));
		}
		if (!DT.Columns.Contains("Description"))
		{
			DT.Columns.Add("Description", typeof(string));
		}
		doctrineDefinition = DoctrineDefinitions_Array[(int)theDocEnum];
		if (doctrineDefinition == null)
		{
			return;
		}
		foreach (KeyValuePair<int, string> state in doctrineDefinition.States)
		{
			DT.Rows.Add(state.Key, state.Value);
		}
	}

	public void Populate_Combo_EMCON_Radar(ComboBox combobox, ref Scenario CurrentScenario, ref Doctrine theDoc)
	{
		combobox.Items.Clear();
		combobox.Items.Add((object)"Passive");
		combobox.Items.Add((object)"Active");
		if (!Information.IsNothing((object)SelectedUnits) && SelectedUnits.Count > 1 && !theDoc.EMCON_Inherits && emconsettings_0.Radar() == EMCONSettings._EMCONSetting.Various)
		{
			combobox.Items.Add((object)"Various");
		}
		if (!theDoc.EMCON_Inherits && (object)SubjectType == typeof(Waypoint))
		{
			combobox.Items.Add((object)"Not configured");
		}
		if (theDoc.EMCON(CurrentScenario).Radar() == EMCONSettings._EMCONSetting.Passive)
		{
			combobox.SelectedIndex = 0;
		}
		else if (theDoc.EMCON(CurrentScenario).Radar() == EMCONSettings._EMCONSetting.Active)
		{
			combobox.SelectedIndex = 1;
		}
		else if (theDoc.EMCON(CurrentScenario).Radar() == EMCONSettings._EMCONSetting.NotConfigured)
		{
			combobox.SelectedIndex = 2;
		}
		((Control)combobox).Enabled = !theDoc.EMCON_Inherits;
	}

	public void Populate_Combo_EMCON_OECM(ComboBox combobox, ref Scenario CurrentScenario, ref Doctrine theDoc)
	{
		combobox.Items.Clear();
		combobox.Items.Add((object)"Passive");
		combobox.Items.Add((object)"Active");
		if (!Information.IsNothing((object)SelectedUnits) && SelectedUnits.Count > 1 && !theDoc.EMCON_Inherits && emconsettings_0.OECM() == EMCONSettings._EMCONSetting.Various)
		{
			combobox.Items.Add((object)"Various");
		}
		if (!theDoc.EMCON_Inherits && (object)SubjectType == typeof(Waypoint))
		{
			combobox.Items.Add((object)"Not configured");
		}
		if (theDoc.EMCON(CurrentScenario).OECM() == EMCONSettings._EMCONSetting.Passive)
		{
			combobox.SelectedIndex = 0;
		}
		else if (theDoc.EMCON(CurrentScenario).OECM() == EMCONSettings._EMCONSetting.Active)
		{
			combobox.SelectedIndex = 1;
		}
		else if (theDoc.EMCON(CurrentScenario).OECM() == EMCONSettings._EMCONSetting.NotConfigured)
		{
			combobox.SelectedIndex = 2;
		}
		((Control)combobox).Enabled = !theDoc.EMCON_Inherits;
	}

	public void Populate_Combo_EMCON_Sonar(ComboBox combobox, ref Scenario CurrentScenario, ref Doctrine theDoc)
	{
		combobox.Items.Clear();
		combobox.Items.Add((object)"Passive");
		combobox.Items.Add((object)"Active");
		if (!Information.IsNothing((object)SelectedUnits) && SelectedUnits.Count > 1 && !theDoc.EMCON_Inherits && emconsettings_0.Sonar() == EMCONSettings._EMCONSetting.Various)
		{
			combobox.Items.Add((object)"Various");
		}
		if (!theDoc.EMCON_Inherits && (object)SubjectType == typeof(Waypoint))
		{
			combobox.Items.Add((object)"Not configured");
		}
		if (theDoc.EMCON(CurrentScenario).Sonar() == EMCONSettings._EMCONSetting.Passive)
		{
			combobox.SelectedIndex = 0;
		}
		else if (theDoc.EMCON(CurrentScenario).Sonar() == EMCONSettings._EMCONSetting.Active)
		{
			combobox.SelectedIndex = 1;
		}
		else if (theDoc.EMCON(CurrentScenario).Sonar() == EMCONSettings._EMCONSetting.NotConfigured)
		{
			combobox.SelectedIndex = 2;
		}
		((Control)combobox).Enabled = !theDoc.EMCON_Inherits;
	}

	public void Set_Checkbox_EMCON_Inherit(CheckBox checkbox, ref ScenarioObject Subject, ref Doctrine theDoc)
	{
		if (!Information.IsNothing((object)Subject))
		{
			((Control)checkbox).Enabled = (object)SubjectType != typeof(Side);
		}
		else
		{
			((Control)checkbox).Enabled = true;
		}
		checkbox.Checked = theDoc.EMCON_Inherits;
	}

	public void Set_Checkbox_State_Visibility_EMCON(CheckBox checkbox_inherit, ComboBox combobox_radar, ComboBox combobox_oecm, ComboBox combobox_sonar, ref Doctrine theDoc, Scenario theScen, bool ViaDoctrineForm, bool ViaRightColumn)
	{
		EMCONSettings._EMCONSetting newValue = default(EMCONSettings._EMCONSetting);
		if (theDoc.EMCON(theScen).Radar() == EMCONSettings._EMCONSetting.Active)
		{
			newValue = EMCONSettings._EMCONSetting.Active;
		}
		else if (theDoc.EMCON(theScen).Radar() == EMCONSettings._EMCONSetting.Intermittent)
		{
			newValue = EMCONSettings._EMCONSetting.Intermittent;
		}
		EMCONSettings._EMCONSetting newValue2 = default(EMCONSettings._EMCONSetting);
		if (theDoc.EMCON(theScen).Sonar() == EMCONSettings._EMCONSetting.Active)
		{
			newValue2 = EMCONSettings._EMCONSetting.Active;
		}
		else if (theDoc.EMCON(theScen).Sonar() == EMCONSettings._EMCONSetting.Intermittent)
		{
			newValue2 = EMCONSettings._EMCONSetting.Intermittent;
		}
		EMCONSettings._EMCONSetting newValue3 = default(EMCONSettings._EMCONSetting);
		if (theDoc.EMCON(theScen).OECM() == EMCONSettings._EMCONSetting.Active)
		{
			newValue3 = EMCONSettings._EMCONSetting.Active;
		}
		else if (theDoc.EMCON(theScen).OECM() == EMCONSettings._EMCONSetting.Intermittent)
		{
			newValue3 = EMCONSettings._EMCONSetting.Intermittent;
		}
		theDoc.EMCON_Inherits = checkbox_inherit.Checked;
		((Control)combobox_radar).Enabled = !theDoc.EMCON_Inherits;
		((Control)combobox_oecm).Enabled = !theDoc.EMCON_Inherits;
		((Control)combobox_sonar).Enabled = !theDoc.EMCON_Inherits;
		if (theDoc.DoctrineRefresh)
		{
			return;
		}
		if (!Information.IsNothing((object)SelectedUnits))
		{
			foreach (ActiveUnit selectedUnit in SelectedUnits)
			{
				selectedUnit.Doctrine.EMCON_Inherits = checkbox_inherit.Checked;
				if (!selectedUnit.Doctrine.EMCON_Inherits)
				{
					selectedUnit.Doctrine.SetEMCON_Radar(newValue, theScen);
					selectedUnit.Doctrine.SetEMCON_Sonar(newValue2, theScen);
					selectedUnit.Doctrine.SetEMCON_OECM(newValue3, theScen);
				}
			}
		}
		if (!theDoc.EMCON_Inherits)
		{
			theDoc.SetEMCON_Radar(newValue, theScen);
			theDoc.SetEMCON_Sonar(newValue2, theScen);
			theDoc.SetEMCON_OECM(newValue3, theScen);
		}
		if (!Information.IsNothing((object)SelectedUnits))
		{
			foreach (ActiveUnit selectedUnit2 in SelectedUnits)
			{
				selectedUnit2.Doctrine.FireEvent_EmconChanged(selectedUnit2, false, MultipleUnits: true, ViaDoctrineForm, ViaRightColumn, viaFlightPlanEditor: false);
			}
			return;
		}
		theDoc.FireEvent_EmconChanged(Subject, false, MultipleUnits: false, ViaDoctrineForm, ViaRightColumn, viaFlightPlanEditor: false);
	}

	public void ApplyEMCON_For_AffectedUnits(ref Side CurrentSide, ref Scenario CurrentScenario, ref bool MissionEscort)
	{
		if ((object)SubjectType != typeof(Side))
		{
			{
				foreach (ActiveUnit item in AffectedUnits(CurrentScenario, MissionEscort))
				{
					item.Sensory.vmethod_2(item.Sensors_Cached);
				}
				return;
			}
		}
		foreach (ActiveUnit unit in CurrentSide.Units)
		{
			unit.Sensory.vmethod_2(unit.Sensors_Cached);
		}
	}

	public void Populate_List_PriorityTarget(DarkListView theList, Scenario theScen, int SelIndex = -1)
	{
		int num = 0;
		theList.Items.Clear();
		foreach (PriorityTargetEntry item in list_0)
		{
			theList.Items.Add(new DarkListItem(item.LBItemString(theScen)));
			if (SelIndex == -1 && item.Priority == PriorityTargetEntry.PriorityFlags.PriorityDefault)
			{
				SelIndex = num;
			}
			else
			{
				num++;
			}
		}
		if (SelIndex > -1)
		{
			theList.SelectItem(SelIndex);
		}
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool AirOpsTempo_Inherits()
	{
		return GetElement(DoctrineItem_E.AirOpsTempo).IsInheriting;
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool UseKinematicRangeForTorpedoes_Inherits()
	{
		return GetElement(DoctrineItem_E.UseKinematicRangeForTorpedoes).IsInheriting;
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool WeaponControlStatus_Air_Inherits()
	{
		return GetElement(DoctrineItem_E.WeaponControlStatusAir).IsInheriting;
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool WeaponControlStatus_Surface_Inherits()
	{
		return GetElement(DoctrineItem_E.WeaponControlStatusSurface).IsInheriting;
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool WeaponControlStatus_Submarine_Inherits()
	{
		return GetElement(DoctrineItem_E.WeaponControlStatusSubsurface).IsInheriting;
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool WeaponControlStatus_Land_Inherits()
	{
		return GetElement(DoctrineItem_E.WeaponControlStatusLand).IsInheriting;
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool IgnorePlottedCourse_Inherits()
	{
		return GetElement(DoctrineItem_E.IgnorePlottedCourse).IsInheriting;
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool BehaviorTowardsAmbigousTarget_Inherits()
	{
		return GetElement(DoctrineItem_E.BehaviorTowardsAmbiguousTarget).IsInheriting;
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool WithdrawDamageThreshold_Inherits()
	{
		return GetElement(DoctrineItem_E.WithdrawDamage).IsInheriting;
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool WithdrawFuelThreshold_Inherits()
	{
		return GetElement(DoctrineItem_E.WithdrawFuel).IsInheriting;
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool WithdrawAttackThreshold_Inherits()
	{
		return GetElement(DoctrineItem_E.WithdrawAttack).IsInheriting;
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool WithdrawDefenceThreshold_Inherits()
	{
		return GetElement(DoctrineItem_E.WithdrawDefence).IsInheriting;
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool RedeployFuelThreshold_Inherits()
	{
		return GetElement(DoctrineItem_E.DeployFuel).IsInheriting;
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool RedeployAttackThreshold_Inherits()
	{
		return GetElement(DoctrineItem_E.DeployAttack).IsInheriting;
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool RedeployDefenceThreshold_Inherits()
	{
		return GetElement(DoctrineItem_E.DeployDefence).IsInheriting;
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool WinchesterShotgunRTB_Inherits()
	{
		return GetElement(DoctrineItem_E.const_20).IsInheriting;
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool BingoJokerRTB_Inherits()
	{
		return GetElement(DoctrineItem_E.BingoJokerRTB).IsInheriting;
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool JettisonOrdnance_Inherits()
	{
		return GetElement(DoctrineItem_E.Jettison).IsInheriting;
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool BVRLogic_Inherits()
	{
		return GetElement(DoctrineItem_E.BVRLogic).IsInheriting;
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool AutoEvade_Inherits()
	{
		return GetElement(DoctrineItem_E.AutoEvade).IsInheriting;
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool MaintainStandoff_Inherits()
	{
		return GetElement(DoctrineItem_E.MaintainStandoff).IsInheriting;
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool GunStrafing_Inherits()
	{
		return GetElement(DoctrineItem_E.GunStrafing).IsInheriting;
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool UseReplenishment_Inherits()
	{
		return GetElement(DoctrineItem_E.UseReplenishment).IsInheriting;
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool ReplenishmentSelection_Inherits()
	{
		return GetElement(DoctrineItem_E.ReplenishmentSelection).IsInheriting;
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool ShootTourists_Inherits()
	{
		return GetElement(DoctrineItem_E.ShootTourists).IsInheriting;
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool UseSAMsOnASuW_Inherits()
	{
		return GetElement(DoctrineItem_E.UseSAMsOnASuW).IsInheriting;
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool IgnoreEMCONunderAttack_Inherits()
	{
		return GetElement(DoctrineItem_E.IgnoreEMCONunderAttack).IsInheriting;
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool SubmarineNavigation_Inherits()
	{
		return GetElement(DoctrineItem_E.NavSubSurface).IsInheriting;
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool LandNavigation_Inherits()
	{
		return GetElement(DoctrineItem_E.NavLand).IsInheriting;
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool RefuelAllies_Inherits()
	{
		return GetElement(DoctrineItem_E.RefuelAllies).IsInheriting;
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool AvoidContact_Inherits()
	{
		return GetElement(DoctrineItem_E.AvoidContact).IsInheriting;
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool DiveWhenThreatsDetected_Inherits()
	{
		return GetElement(DoctrineItem_E.DiveWhenThreatsDetected).IsInheriting;
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool RechargePercentagePatrol_Inherits()
	{
		return GetElement(DoctrineItem_E.RechargePercentagePatrol).IsInheriting;
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool RechargePercentageAttack_Inherits()
	{
		return GetElement(DoctrineItem_E.RechargePercentageAttack).IsInheriting;
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool DippingSonar_Inherits()
	{
		return GetElement(DoctrineItem_E.DippingSonar).IsInheriting;
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool NukesAllowed_Inherits()
	{
		return GetElement(DoctrineItem_E.NukesAllowed).IsInheriting;
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool AIPUsage_Inherits()
	{
		return GetElement(DoctrineItem_E.AIPUsage).IsInheriting;
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool BingoJoker_Inherits()
	{
		return GetElement(DoctrineItem_E.BingoJoker).IsInheriting;
	}

	[Obsolete("Replace with generic getter/setter")]
	public bool WinchesterShotgun_Inherits()
	{
		return GetElement(DoctrineItem_E.WinchesterShotgun).IsInheriting;
	}

	[Obsolete("Replace with generic getter/setter")]
	internal float GetBingoThreshold(ActiveUnit TheUnit)
	{
		if (TheUnit.ActiveMissionOrPackage() != null && TheUnit.ActiveMissionOrPackage().FuelQtyToStartLookingForTanker_Airborne > 0)
		{
			return Convert.ToSingle((double)TheUnit.ActiveMissionOrPackage().FuelQtyToStartLookingForTanker_Airborne / 100.0);
		}
		_BingoThreshold_E? bingoThreshold_E = this.get_BingoThreshold(TheUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
		byte? b = (byte?)bingoThreshold_E;
		if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) == true)
		{
			return 0.3f;
		}
		b = (byte?)bingoThreshold_E;
		if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) != true)
		{
			b = (byte?)bingoThreshold_E;
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)) == true)
			{
				return 0.5f;
			}
			b = (byte?)bingoThreshold_E;
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 3)) != true)
			{
				b = (byte?)bingoThreshold_E;
				if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 4)) == true)
				{
					return 0.7f;
				}
				b = (byte?)bingoThreshold_E;
				if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 5)) == true)
				{
					return 0.8f;
				}
				return 0.6f;
			}
			return 0.6f;
		}
		return 0.4f;
	}

	public void ApplyInheritanceToAllDoctrineDefinitions()
	{
		DoctrineItem[] doctrineItems = DoctrineItems;
		foreach (DoctrineItem doctrineItem in doctrineItems)
		{
			if (doctrineItem != null)
			{
				doctrineItem.set_CurrentState(ConsiderInheritance: false, (int?)null);
			}
		}
	}

	public void ApplyInheritanceToAllDoctrineDefinitionsWRAandEMCON()
	{
		ApplyInheritanceToAllDoctrineDefinitions();
		WRA = null;
		EMCON_Inherits = true;
	}

	public void ResetDefaultToAllDoctrineDefinitions()
	{
		ScenarioObject subject = Subject;
		Doctrine theDoctrine = this;
		ResetDoctrineSettings(subject, ref theDoctrine);
	}

	public static void ResetDoctrineSettings(ScenarioObject theUnit, ref Doctrine theDoctrine)
	{
		DoctrineItem[] doctrineItems = theDoctrine.DoctrineItems;
		for (int i = 0; i < doctrineItems.Length; i = checked(i + 1))
		{
			doctrineItems[i]?.SetToDefaultValue();
		}
		if (!Information.IsNothing((object)theUnit) && theUnit.IsAircraft)
		{
			((Aircraft)theUnit).Kinematics.DetermineReserveFuelQty();
		}
	}

	internal static int GetShooterNumber(Weapon ReferenceWeapon, ActiveUnit theAU, Contact theTarget, _WRA_WeaponTargetType theWRATargetType)
	{
		Doctrine doctrine = theAU.Doctrine;
		Scenario parentScen = theAU.ParentScen;
		int? TargetType_InheritedShooterQty = null;
		int? TargetType_UnspecifiedShooterQty = null;
		int? num = WRA_ShooterQty_AnyTargetType(doctrine, parentScen, ReferenceWeapon, theWRATargetType, FindInheritedValuesOnly: false, ref TargetType_InheritedShooterQty, ref TargetType_UnspecifiedShooterQty);
		TargetType_UnspecifiedShooterQty = num;
		if ((TargetType_UnspecifiedShooterQty.HasValue ? new bool?(TargetType_UnspecifiedShooterQty == -99) : ((bool?)null)) == true)
		{
			num = 99999;
		}
		return num.Value;
	}
}
