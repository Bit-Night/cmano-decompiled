using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Collections.Pooled;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class CoreClientCode
{
	[CompilerGenerated]
	internal sealed class _Closure$__104-0
	{
		public Mission.Flight $VB$Local_theFlight;

		public _Closure$__104-0(_Closure$__104-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theFlight = arg0.$VB$Local_theFlight;
			}
		}

		[SpecialName]
		internal bool _Lambda$__2(ActiveUnit x)
		{
			return Operators.CompareString(x.Navigator.get_Flight(HierarchySearch: true).Callsign, $VB$Local_theFlight.Callsign, false) == 0;
		}

		static _Closure$__104-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__17-0
	{
		public Mission.Flight $VB$Local_theFlight;

		public _Closure$__17-0(_Closure$__17-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theFlight = arg0.$VB$Local_theFlight;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(ActiveUnit theAU)
		{
			int result;
			if (!theAU.Navigator.HasFlight)
			{
				result = 0;
			}
			else if (theAU.IsAircraft)
			{
				if (theAU.IsOperating())
				{
					return theAU.Navigator.get_Flight(HierarchySearch: true) == $VB$Local_theFlight;
				}
				result = 0;
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}

		static _Closure$__17-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__82-0
	{
		public Mission $VB$Local_theMission;

		public _Closure$__82-0(_Closure$__82-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theMission = arg0.$VB$Local_theMission;
			}
		}

		static _Closure$__82-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__82-1
	{
		public int $VB$Local_FlightIndex;

		public _Closure$__82-0 $VB$NonLocal_$VB$Closure_2;

		public _Closure$__82-1(_Closure$__82-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_FlightIndex = arg0.$VB$Local_FlightIndex;
			}
		}

		[SpecialName]
		internal bool _Lambda$__2(ActiveUnit x)
		{
			return Operators.CompareString(x.Navigator.get_Flight(HierarchySearch: true).Callsign, $VB$NonLocal_$VB$Closure_2.$VB$Local_theMission.FlightList[$VB$Local_FlightIndex].Callsign, false) == 0;
		}

		[SpecialName]
		internal bool _Lambda$__3(ActiveUnit x)
		{
			if (!x.IsAircraft)
			{
				return false;
			}
			return ((Aircraft)x).LoadoutDBID == $VB$NonLocal_$VB$Closure_2.$VB$Local_theMission.FlightList[$VB$Local_FlightIndex].int_1;
		}

		[SpecialName]
		internal bool _Lambda$__4(ActiveUnit x)
		{
			if (!x.IsAircraft)
			{
				return false;
			}
			return ((Aircraft)x).DBID == $VB$NonLocal_$VB$Closure_2.$VB$Local_theMission.FlightList[$VB$Local_FlightIndex].int_1;
		}

		[SpecialName]
		internal bool _Lambda$__7(KeyValuePair<string, int> x)
		{
			return Operators.CompareString(x.Key, $VB$NonLocal_$VB$Closure_2.$VB$Local_theMission.FlightList[$VB$Local_FlightIndex].Callsign, false) == 0;
		}

		static _Closure$__82-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__82-2
	{
		public SecondaryFlightPlan $VB$Local_theSecondaryF;

		public _Closure$__82-2(_Closure$__82-2 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theSecondaryF = arg0.$VB$Local_theSecondaryF;
			}
		}

		[SpecialName]
		internal bool _Lambda$__5(ActiveUnit x)
		{
			if (!x.IsAircraft)
			{
				return false;
			}
			return ((Aircraft)x).DBID == $VB$Local_theSecondaryF.DBID;
		}

		static _Closure$__82-2()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__82-3
	{
		public SecondaryFlightPlan $VB$Local_theSecondaryF;

		public _Closure$__82-3(_Closure$__82-3 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theSecondaryF = arg0.$VB$Local_theSecondaryF;
			}
		}

		[SpecialName]
		internal bool _Lambda$__6(ActiveUnit x)
		{
			if (!x.IsAircraft)
			{
				return false;
			}
			return ((Aircraft)x).DBID == $VB$Local_theSecondaryF.DBID;
		}

		static _Closure$__82-3()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__82-4
	{
		public ActiveUnit $VB$Local_AU;

		public _Closure$__82-4(_Closure$__82-4 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_AU = arg0.$VB$Local_AU;
			}
		}

		[SpecialName]
		internal bool _Lambda$__8(ActiveUnit x)
		{
			return Operators.CompareString(x.ObjectID, $VB$Local_AU.ObjectID, false) == 0;
		}

		static _Closure$__82-4()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__83-0
	{
		public ActiveUnit $VB$Local_theUnit;

		public _Closure$__83-0(_Closure$__83-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theUnit = arg0.$VB$Local_theUnit;
			}
		}

		[SpecialName]
		internal bool _Lambda$__1(ActiveUnit x)
		{
			return Operators.CompareString(x.ObjectID, $VB$Local_theUnit.ObjectID, false) == 0;
		}

		static _Closure$__83-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__95-0
	{
		public Mission.Flight $VB$Local_theFlight;

		public _Closure$__95-0(_Closure$__95-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theFlight = arg0.$VB$Local_theFlight;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(ActiveUnit theAU)
		{
			int result;
			if (!theAU.Navigator.HasFlight)
			{
				result = 0;
			}
			else
			{
				if (theAU.IsAircraft && !theAU.IsOperating())
				{
					return theAU.Navigator.get_Flight(HierarchySearch: true) == $VB$Local_theFlight;
				}
				result = 0;
			}
			return (byte)result != 0;
		}

		[SpecialName]
		internal bool _Lambda$__1(ActiveUnit theAU)
		{
			int result;
			if (!theAU.Navigator.HasFlight)
			{
				result = 0;
			}
			else if (!theAU.IsAircraft)
			{
				result = 0;
			}
			else
			{
				if (theAU.IsOperating())
				{
					return theAU.Navigator.get_Flight(HierarchySearch: true) == $VB$Local_theFlight;
				}
				result = 0;
			}
			return (byte)result != 0;
		}

		static _Closure$__95-0()
		{
			Class72.smethod_20();
		}
	}

	public static void TargetingContactAutoEngage_Core(Dictionary<ActiveUnit, List<Contact>> Targeting)
	{
		if (Targeting == null)
		{
			return;
		}
		List<ActiveUnit> list = Targeting.Keys.ToList();
		foreach (ActiveUnit item in list)
		{
			List<Contact> list2 = Targeting[item];
			foreach (Contact item2 in list2)
			{
				if (!item.IsWeapon)
				{
					item.AI.TargetThisContact(item2, AddedManually: true, PriorityTarget: false, ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualTargeted);
				}
				else
				{
					item.AI.TargetThisContact(item2, AddedManually: true, PriorityTarget: true, ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualTargeted);
				}
			}
		}
	}

	public static void DetachUnits_Core(IEnumerable<Module_Unit.Unit> Units, Side Side, Scenario Scenario)
	{
		foreach (Module_Unit.Unit Unit in Units)
		{
			if (Unit.get_UnitSide(SetSideOnly: false) == Side && !Unit.IsWeapon)
			{
				((ActiveUnit)Unit).DetachUnit(NotifyPlayer: true, ClearPlottedCourse: true, UseFlightplan: false);
			}
		}
	}

	public static int GroupUnits_Core(IEnumerable<Module_Unit.Unit> Units, Side Side, Scenario Scenario, string theGroupingMode_IntString = "1", bool FromUI = false)
	{
		if (Side != null)
		{
			if (Units.Count() >= 1)
			{
				List<ActiveUnit> list = new List<ActiveUnit>(Units.Count());
				foreach (ActiveUnit Unit in Units)
				{
					if (!Unit.IsDrone() || Unit.AutonomyLevel >= ActiveUnit.DroneAutonomyLevel.MultiVehicleCoordination || !Scenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DroneAutonomyLevels) || Unit.CommStuff.IsConnectedToSideNetwork)
					{
						list.Add(Unit);
					}
				}
				int result;
				if (list.Count <= 1)
				{
					result = -1;
				}
				else
				{
					IEnumerable<ActiveUnit> enumerable = list.Where([SpecialName] (ActiveUnit theAU) => theAU.IsGroup);
					int num = enumerable.Count();
					if (num == 0)
					{
						int result2;
						if (Operators.CompareString(theGroupingMode_IntString, "0", false) != 0)
						{
							if (Operators.CompareString(theGroupingMode_IntString, "1", false) != 0)
							{
								result2 = 0;
							}
							else
							{
								Misc.FormIntoGroups(list.ToList(), Scenario, Side, Misc.GroupingLogic.MixedGroup, null, FromUI);
								result2 = 0;
							}
						}
						else
						{
							Misc.FormIntoGroups(list.ToList(), Scenario, Side, Misc.GroupingLogic.SplitByType, null, FromUI);
							result2 = 0;
						}
						return result2;
					}
					if (num != 1)
					{
						Group obj = new Group(ref Scenario, ref Side, null);
						obj.IsParentGroup = true;
						foreach (ActiveUnit item in enumerable)
						{
							item.set_ParentGroup(UsingMissionPlanner: false, obj);
						}
						result = -1;
					}
					else
					{
						IEnumerable<ActiveUnit> enumerable2 = list.Where([SpecialName] (ActiveUnit theAU) => !theAU.IsGroup);
						Group obj2 = (Group)enumerable.ElementAtOrDefault(0);
						int num2 = 0;
						foreach (ActiveUnit item2 in enumerable2)
						{
							if (obj2.IsGroupableUnit(item2))
							{
								item2.set_ParentGroup(UsingMissionPlanner: false, obj2);
								num2 = 1;
							}
						}
						if (num2 > 0)
						{
							return 1;
						}
						result = -1;
					}
				}
				return result;
			}
			return -1;
		}
		return -1;
	}

	public static void UnassignUnitsAndDisengage_Core(IEnumerable<Module_Unit.Unit> Units, Scenario Scenario, Side Side)
	{
		if (Units == null || Units.Count() == 0)
		{
			return;
		}
		List<ActiveUnit> list = new List<ActiveUnit>();
		foreach (Module_Unit.Unit Unit in Units)
		{
			if (Unit.IsActiveUnit && Unit.get_UnitSide(SetSideOnly: false) == Side)
			{
				list.Add((ActiveUnit)Unit);
			}
		}
		if (list.Count > 0)
		{
			smethod_0(list, Scenario, Side);
		}
		DisengageTargets_Core(Units, Side);
	}

	public static void DisengageTargets_Core(IEnumerable<Module_Unit.Unit> Units, Side Side)
	{
		foreach (Module_Unit.Unit Unit in Units)
		{
			if (!Unit.IsActiveUnit || Unit.get_UnitSide(SetSideOnly: false) != Side || Unit.IsWeapon)
			{
				continue;
			}
			if (Unit.IsGroup)
			{
				foreach (ActiveUnit value in ((Group)Unit).Units.Values)
				{
					ActiveUnit theAU = value;
					theAU.AI.ClearAllTargets(ref theAU);
				}
			}
			else
			{
				ActiveUnit theAU2 = (ActiveUnit)Unit;
				theAU2.AI.ClearAllTargets(ref theAU2);
			}
		}
	}

	public static void DropOneTarget_Core(IEnumerable<Module_Unit.Unit> Units, Side Side, Contact Target)
	{
		if (Units == null || Side == null || Target == null)
		{
			return;
		}
		List<Contact> list = new List<Contact>();
		Contact_Base.ContactType type = Target.Type;
		if (type - 18 > Contact_Base.ContactType.Submarine)
		{
			list.Add(Target);
		}
		else if (Target.ActualUnit != null)
		{
			for (int i = Side.Contacts_List.Count - 1; i >= 0; i += -1)
			{
				Contact contact = Side.Contacts_List[i];
				if (contact.ActualUnit != null && !contact.ActualUnit.IsGroup && contact.ActualUnit.get_ParentGroup(UsingMissionPlanner: false) == Target.ActualUnit)
				{
					list.Add(contact);
				}
			}
		}
		foreach (Module_Unit.Unit Unit in Units)
		{
			if (!Unit.IsActiveUnit || Unit.get_UnitSide(SetSideOnly: false) != Side || Unit.IsWeapon)
			{
				continue;
			}
			foreach (Contact item in list)
			{
				if (Unit.IsGroup)
				{
					foreach (ActiveUnit value in ((Group)Unit).Units.Values)
					{
						value.AI.DropTarget(item);
					}
				}
				else
				{
					((ActiveUnit)Unit).AI.DropTarget(item);
				}
			}
		}
	}

	public static void HoldPosition_Core(ActiveUnit AU, bool OnOrOff)
	{
		AU.AI.HoldPosition = OnOrOff;
	}

	public static void HoldPosition_Core(List<ActiveUnit> Units, bool OnOrOff)
	{
		foreach (ActiveUnit Unit in Units)
		{
			HoldPosition_Core(Unit, OnOrOff);
		}
	}

	public static void SummonToReestablishComms_Core(ActiveUnit theAU)
	{
		if (!theAU.CommStuff.IsConnectedToSideNetwork && !theAU.CommStuff.HasBeenSummonedToReestablishComms)
		{
			theAU.CommStuff.HasBeenSummonedToReestablishComms = true;
			theAU.AddMessage(theAU.Name + " has been recalled to re-establish communication", theAU.Name + " summoned", LoggedMessage.MessageType.UnitAI, 0, new Geopoint_Struct(theAU.Longitude_LastReported.Value, theAU.Latitude_LastReported.Value), ActiveUnit.NotificationType.Bark);
		}
	}

	public static void LeadAllowedToSlowDown_Core(ActiveUnit theAU, bool allowed)
	{
		if (theAU.IsGroup)
		{
			((Group)theAU).Kinematics.LeadAllowedToSlowDown = allowed;
		}
	}

	public static string AssignUnitToMission_Core(IEnumerable<ActiveUnit> theSelectedUnits, Scenario theScenario, ref Mission theMission, ref bool isEscort)
	{
		string text = "";
		foreach (ActiveUnit theSelectedUnit in theSelectedUnits)
		{
			ActiveUnit theAU = theSelectedUnit;
			Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult = theAU.AssignToMission(ref theScenario, ref theAU, ref theMission, ref isEscort);
			if (missionAssignmentAttemptResult != Mission.MissionAssignmentAttemptResult.Success)
			{
				int num;
				if (!string.IsNullOrEmpty(text))
				{
					text += "\r\n";
					num = 5;
				}
				else
				{
					num = 5;
				}
				string[] array = new string[num];
				array[0] = text;
				array[1] = "It was not possible to assign ";
				array[2] = theAU.Name;
				array[3] = " to the mission. Reason: ";
				array[4] = Misc.ToEnglishString(missionAssignmentAttemptResult);
				text = string.Concat(array);
				continue;
			}
			StringBuilder stringBuilder = theAU.Doctrine.DoctrineDiffers(theMission.Doctrine, theScenario, IgnoreMissionStatusEvaluation: true);
			if (stringBuilder.Length > 0)
			{
				int num2;
				if (!string.IsNullOrEmpty(text))
				{
					text += "\r\n";
					num2 = 7;
				}
				else
				{
					num2 = 7;
				}
				string[] array2 = new string[num2];
				array2[0] = text;
				array2[1] = theAU.Name;
				array2[2] = " is assigned to mission but the ";
				array2[3] = (string)Interaction.IIf(theAU.IsGroup, (object)"Group", (object)"Unit");
				array2[4] = " Doctrine may conflict with the Mission one for ";
				array2[5] = stringBuilder.ToString();
				array2[6] = ".";
				text = string.Concat(array2);
			}
		}
		return text;
	}

	public static void RemoveUnitFromMission_Core(ActiveUnit theAU, Scenario Scenario, Side Side, bool logMessage = true)
	{
		string text = "";
		if (theAU.IsAircraft && Operators.CompareString(theAU.Name, theAU.UnitClass, false) != 0)
		{
			text = " (" + theAU.UnitClass + ")";
		}
		if (!Information.IsNothing((object)theAU.ActiveMissionOrPackage()))
		{
			string name = theAU.ActiveMissionOrPackage().Name;
			Mission mission = theAU.ActiveMissionOrPackage();
			if (theAU.AI.IsEscort)
			{
				theAU.AI.IsEscort = false;
			}
			theAU.Navigator.ClearFlight();
			Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
			theAU.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: false, ref Result);
			theAU.AssignedTaskPool = null;
			theAU.Doctrine.ClearCachedParentDoctrine();
			theAU.Sensory.vmethod_2(theAU.Sensors_Cached);
			if (!Information.IsNothing((object)mission))
			{
				mission.RemoveFlightsWithoutAircraft(Scenario, Side);
			}
			if (logMessage)
			{
				Scenario.AddMessage(theAU.Name + text + " has been removed from mission: " + name, "Unit removed from mission", LoggedMessage.MessageType.UnitAI, 5, theAU.ObjectID, Side, new Geopoint_Struct(theAU.get_Longitude((GlobalVariables.BooleanObject)null), theAU.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
		}
		else if (Information.IsNothing((object)theAU.AssignedTaskPool))
		{
			if (logMessage)
			{
				Scenario.AddMessage(theAU.Name + text + " has no orders (Unassigned)", "Unit unassigned", LoggedMessage.MessageType.UnitAI, 5, theAU.ObjectID, Side, new Geopoint_Struct(theAU.get_Longitude((GlobalVariables.BooleanObject)null), theAU.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
		}
		else
		{
			string name2 = theAU.AssignedTaskPool.Name;
			Mission mission2 = theAU.ActiveMissionOrPackage();
			Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
			theAU.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: false, ref Result);
			theAU.AssignedTaskPool = null;
			if (!Information.IsNothing((object)mission2))
			{
				mission2.RemoveFlightsWithoutAircraft(Scenario, Side);
			}
			if (logMessage)
			{
				Scenario.AddMessage(theAU.Name + text + " has been removed from task pool: " + name2, "Unit removed from task pool", LoggedMessage.MessageType.UnitAI, 5, theAU.ObjectID, Side, new Geopoint_Struct(theAU.get_Longitude((GlobalVariables.BooleanObject)null), theAU.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
		}
	}

	public static string MissionEditor_AssignUnitToMission_Core(ActiveUnit theSelectedUnit, Mission SelectedMission, bool FromUI = true)
	{
		if (SelectedMission == null)
		{
			return "No mission selected.";
		}
		if (theSelectedUnit == null)
		{
			return "No unit selected.";
		}
		if (theSelectedUnit.AllowMultiMission)
		{
			theSelectedUnit.AssignMissionInQueue(SelectedMission);
			if (SelectedMission.Category == Mission.MissionCategory.TaskPool)
			{
				theSelectedUnit.AssignedTaskPool = SelectedMission;
			}
			return "";
		}
		if (theSelectedUnit.IsAircraft && ((Aircraft)theSelectedUnit).Loadout == null)
		{
			return "Aircraft " + theSelectedUnit.Name + " does not have a loadout, and can not be assigned to any mission.";
		}
		if (SelectedMission.Category == Mission.MissionCategory.TaskPool)
		{
			theSelectedUnit.AssignedTaskPool = SelectedMission;
		}
		else
		{
			Mission.MissionAssignmentAttemptResult Result = default(Mission.MissionAssignmentAttemptResult);
			theSelectedUnit.Set_AssignedMissionOrPackage(SelectedMission, SetMissionOnly: false, IgnoreCommsState: false, ref Result);
			if (Result != Mission.MissionAssignmentAttemptResult.Success)
			{
				return "Unable to change mission assignment for " + theSelectedUnit.Name + ". Reason: " + Misc.ToEnglishString(Result);
			}
		}
		if (FromUI)
		{
			MissionPlanner.CheckRangeToMissionTargets_LoadoutRadius(theSelectedUnit.ParentScen, SelectedMission, ref theSelectedUnit);
		}
		theSelectedUnit.Doctrine.ClearCachedParentDoctrine();
		theSelectedUnit.Sensory.vmethod_2(theSelectedUnit.Sensors_Cached);
		if (SelectedMission.Category != Mission.MissionCategory.TaskPool && (theSelectedUnit.IsAircraft || (theSelectedUnit.IsGroup && ((Group)theSelectedUnit).Type == Group.GroupType.AirGroup)) && theSelectedUnit.IsOperating())
		{
			List<ActiveUnit> theSelectedUnits = new List<ActiveUnit>();
			theSelectedUnits.Add(theSelectedUnit);
			MissionPlanner.GenerateFlightPlan_Strike_AirborneAircraft(theSelectedUnit.ParentScen, SelectedMission, ref theSelectedUnits, isManual: true);
		}
		string result = default(string);
		return result;
	}

	public static string MissionEditor_RemoveUnitFromMission_Core(ActiveUnit theSelectedUnit, Mission SelectedMission)
	{
		if (!theSelectedUnit.AllowMultiMission)
		{
			Mission.MissionAssignmentAttemptResult Result = default(Mission.MissionAssignmentAttemptResult);
			theSelectedUnit.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: false, ref Result);
			if (Result != Mission.MissionAssignmentAttemptResult.Success)
			{
				return "Unable to change mission assignment for " + theSelectedUnit.Name + ". Reason: " + Misc.ToEnglishString(Result);
			}
		}
		else
		{
			theSelectedUnit.UnassignMissionInQueue(SelectedMission);
		}
		if (!Information.IsNothing((object)theSelectedUnit.ActiveMissionOrPackage()) && theSelectedUnit.ActiveMissionOrPackage().Category == Mission.MissionCategory.Package && !theSelectedUnit.IsOperating())
		{
			theSelectedUnit.set_ParentGroup(UsingMissionPlanner: false, (Group)null);
		}
		theSelectedUnit.Navigator.ClearFlight();
		theSelectedUnit.Doctrine.ClearCachedParentDoctrine();
		theSelectedUnit.Sensory.vmethod_2(theSelectedUnit.Sensors_Cached);
		theSelectedUnit.AI.IsEscort = false;
		string result = default(string);
		return result;
	}

	public static void ReturnToBase_Core(IEnumerable<Module_Unit.Unit> Units, Scenario Scenario, Side Side)
	{
		foreach (Module_Unit.Unit Unit in Units)
		{
			if (Unit.get_UnitSide(SetSideOnly: false) != Side)
			{
				continue;
			}
			ActiveUnit activeUnit = (ActiveUnit)Unit;
			if (!activeUnit.IsAircraft)
			{
				if (activeUnit.IsShip || activeUnit.IsSubmarine || (activeUnit.IsVehicle && ((Vehicle)activeUnit).IsAmphibiousSeaworthy))
				{
					string text = "";
					ActiveUnit actualDestinationHost = activeUnit.DockingOps.ActualDestinationHost;
					if (!Information.IsNothing((object)actualDestinationHost))
					{
						text = " (" + actualDestinationHost.Name + ")";
					}
					activeUnit.DockingOps.AttemptToRTB(ManuallyOrdered: true, ActiveUnit._ActiveUnitStatus.RTB_Manual, GroupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, DetachFromGroup: true, ClearPlottedCourse: true);
					activeUnit.Navigator.ResetTimeToNextPathfinderCheck();
					Scenario.AddMessage(activeUnit.Name + " Is returning to docking unit" + text, "Unit returning to mothership", LoggedMessage.MessageType.DockingOps, 5, activeUnit.ObjectID, Side, new Geopoint_Struct(activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
			}
			else
			{
				Aircraft aircraft = (Aircraft)activeUnit;
				activeUnit.FuelState = aircraft.IsBingoOrJoker;
				activeUnit.WeaponState = aircraft.Weaponry.IsWinchesterOrShotgun();
				if (!GlobalVariables.AI_REWORK)
				{
					activeUnit.AirOps.AttemptToRTB(ManuallyOrdered: true, ActiveUnit._ActiveUnitStatus.RTB_Manual, GroupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, DetachFromGroup: true, ClearPlottedCourse: true);
				}
				else
				{
					((Aircraft)activeUnit).AI.StatusRelatedEvents.method_0(manuallyOrdered: true, ActiveUnit._ActiveUnitStatus.RTB_Manual, groupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, detachFromGroup: true, clearPlottedCourse: true);
				}
				string text2 = "";
				if (Operators.CompareString(activeUnit.Name, activeUnit.UnitClass, false) != 0)
				{
					text2 = " (" + activeUnit.UnitClass + ")";
				}
				string text3 = "";
				ActiveUnit actualDestinationHost2 = ((Aircraft_AirOps)activeUnit.AirOps).ActualDestinationHost;
				if (!Information.IsNothing((object)actualDestinationHost2))
				{
					text3 = " (" + actualDestinationHost2.Name + ")";
				}
				activeUnit.Navigator.ResetTimeToNextPathfinderCheck();
				Scenario.AddMessage(activeUnit.Name + text2 + " Is returning to base" + text3, "Unit returning to base", LoggedMessage.MessageType.AirOps, 5, activeUnit.ObjectID, Side, new Geopoint_Struct(activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			if (!activeUnit.IsGroup)
			{
				continue;
			}
			if (((Group)activeUnit).Type == Group.GroupType.AirGroup)
			{
				List<ActiveUnit> list = new List<ActiveUnit>();
				list.AddRange(((Group)activeUnit).Units.Values);
				foreach (ActiveUnit item in list)
				{
					item.FuelState = ((Aircraft)item).IsBingoOrJoker;
					item.WeaponState = ((Aircraft)item).Weaponry.IsWinchesterOrShotgun();
					string text4 = "";
					if (Operators.CompareString(item.Name, item.UnitClass, false) != 0)
					{
						text4 = " (" + item.UnitClass + ")";
					}
					string text5 = "";
					ActiveUnit actualDestinationHost3 = ((Aircraft_AirOps)item.AirOps).ActualDestinationHost;
					if (!Information.IsNothing((object)actualDestinationHost3))
					{
						text5 = " (" + actualDestinationHost3.Name + ") ";
					}
					item.AirOps.AttemptToRTB(ManuallyOrdered: true, ActiveUnit._ActiveUnitStatus.RTB_Manual, GroupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, DetachFromGroup: false, ClearPlottedCourse: true);
					item.Navigator.ResetTimeToNextPathfinderCheck();
					Scenario.AddMessage(item.Name + text4 + " Is returning to base" + text5, "Unit returning to base", LoggedMessage.MessageType.AirOps, 5, item.ObjectID, Side, new Geopoint_Struct(item.get_Longitude((GlobalVariables.BooleanObject)null), item.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
			}
			else
			{
				if (((Group)activeUnit).Type != Group.GroupType.SurfaceGroup && ((Group)activeUnit).Type != Group.GroupType.SubGroup)
				{
					continue;
				}
				List<ActiveUnit> list2 = new List<ActiveUnit>();
				list2.AddRange(((Group)activeUnit).Units.Values);
				foreach (ActiveUnit item2 in list2)
				{
					if (item2.IsShip || item2.IsSubmarine)
					{
						item2.DockingOps.AttemptToRTB(ManuallyOrdered: true, ActiveUnit._ActiveUnitStatus.RTB_Manual, GroupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, DetachFromGroup: true, ClearPlottedCourse: true);
						string text6 = "";
						ActiveUnit actualDestinationHost4 = activeUnit.DockingOps.ActualDestinationHost;
						if (!Information.IsNothing((object)actualDestinationHost4))
						{
							text6 = " (" + actualDestinationHost4.Name + ") ";
						}
						item2.Navigator.ResetTimeToNextPathfinderCheck();
						Scenario.AddMessage(item2.Name + " Is returning to docking unit" + text6, "Unit returning to mothership", LoggedMessage.MessageType.DockingOps, 5, item2.ObjectID, Side);
					}
				}
			}
		}
	}

	private static void smethod_0(IEnumerable<ActiveUnit> ienumerable_0, Scenario scenario_0, Side side_0)
	{
		foreach (ActiveUnit item in ienumerable_0)
		{
			UnassignUnit_Core(item, scenario_0, side_0);
		}
	}

	internal static void UnassignUnit_Core(ActiveUnit theActiveUnit, Scenario Scenario, Side Side)
	{
		if (theActiveUnit.IsActiveUnit && theActiveUnit.get_UnitSide(SetSideOnly: false) == Side && !theActiveUnit.IsWeapon)
		{
			if (theActiveUnit.IsOperating())
			{
				if (!theActiveUnit.IsAircraft)
				{
					if (theActiveUnit.IsShip)
					{
						Ship ship = (Ship)theActiveUnit;
						ActiveUnit_DockingOps dockingOps = ship.DockingOps;
						if (!ship.IsUsingDippingSonar() || dockingOps.ConditionTimer == 0f)
						{
							dockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.Underway;
						}
						if (ship.Navigator.PlottedCourse.Count() > 0)
						{
							ship.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
						}
						else
						{
							ship.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
						}
						if (!Information.IsNothing((object)dockingOps.UNREP_Destination))
						{
							dockingOps.DisconnectFromSupplier();
						}
					}
					else if (!theActiveUnit.IsSubmarine)
					{
						if (theActiveUnit.IsGroup)
						{
							RemoveUnitFromMission_Core(theActiveUnit, Scenario, Side);
							theActiveUnit.Doctrine.ClearCachedParentDoctrine();
							foreach (ActiveUnit value in ((Group)theActiveUnit).Units.Values)
							{
								if (value.IsOperating())
								{
									UnassignUnit_Core(value, Scenario, Side);
								}
							}
						}
						else
						{
							theActiveUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
						}
					}
					else
					{
						Submarine submarine = (Submarine)theActiveUnit;
						ActiveUnit_DockingOps dockingOps2 = submarine.DockingOps;
						dockingOps2.Condition = ActiveUnit_DockingOps._DockingOpsCondition.Underway;
						if (submarine.Navigator.PlottedCourse.Count() > 0)
						{
							submarine.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
						}
						else
						{
							submarine.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
						}
						if (!Information.IsNothing((object)dockingOps2.UNREP_Destination))
						{
							dockingOps2.DisconnectFromSupplier();
						}
					}
				}
				else
				{
					Aircraft aircraft = (Aircraft)theActiveUnit;
					Aircraft_AirOps airOps = aircraft.AirOps;
					if (airOps.Condition != Aircraft_AirOps._AirOpsCondition.DeployingDippingSonar || airOps.ConditionTimer == 0f)
					{
						airOps.Condition = Aircraft_AirOps._AirOpsCondition.Airborne;
					}
					if (aircraft.Navigator.PlottedCourse.Count() > 0 && aircraft.Status == ActiveUnit._ActiveUnitStatus.OnPlottedCourse)
					{
						aircraft.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
					}
					else if (aircraft.Status == ActiveUnit._ActiveUnitStatus.Tasked)
					{
						aircraft.Status = ActiveUnit._ActiveUnitStatus.Tasked;
					}
					else
					{
						aircraft.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
					}
					if (aircraft.DesiredAltitude_AGL > 0f && !aircraft.get_DesiredAltitude_UseTerrainFollowing((ActiveUnit)aircraft))
					{
						aircraft.DesiredAltitude_AGL = 0f;
					}
					if (aircraft.FuelState != ActiveUnit._ActiveUnitFuelState.None)
					{
						aircraft.FuelState = ActiveUnit._ActiveUnitFuelState.IgnoreBingoAndJoker;
					}
					if (aircraft.WeaponState != ActiveUnit._ActiveUnitWeaponState.None)
					{
						aircraft.WeaponState = ActiveUnit._ActiveUnitWeaponState.IgnoreWinchesterAndShotgun;
					}
					if (!Information.IsNothing((object)airOps.A2AR_Destination))
					{
						airOps.DisconnectFromTanker();
					}
				}
			}
			else
			{
				theActiveUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
			}
			theActiveUnit.ClearManualOrders();
			RemoveUnitFromMission_Core(theActiveUnit, Scenario, Side);
			theActiveUnit.Doctrine.ClearCachedParentDoctrine();
			theActiveUnit.Sensory.vmethod_2(theActiveUnit.Sensors_Cached);
			theActiveUnit.DesiredTurnRate_Navigation = Waypoint.TurnRateCategory.DoubleStandardRateTurn;
		}
		theActiveUnit.Status = ActiveUnit._ActiveUnitStatus.Manual_Unassigned;
		theActiveUnit.Navigator.ClearPlottedCourse();
	}

	public static string MissionSetSecondaryAirBase_Core(Mission theMission, Scenario theScenario, ActiveUnit NewSecondaryHomeBase)
	{
		ActiveUnit secondaryAirBase = theMission.SecondaryAirBase;
		theMission.SecondaryAirBase = NewSecondaryHomeBase;
		if (secondaryAirBase != theMission.SecondaryAirBase)
		{
			using List<Mission.Flight>.Enumerator enumerator = theMission.FlightList.GetEnumerator();
			_Closure$__17-0 closure$__17- = default(_Closure$__17-0);
			while (enumerator.MoveNext())
			{
				closure$__17- = new _Closure$__17-0(closure$__17-);
				closure$__17-.$VB$Local_theFlight = enumerator.Current;
				if (theMission.SecondaryAirBase != null)
				{
					closure$__17-.$VB$Local_theFlight.LandingLocation_HostUnitObjectID = theMission.SecondaryAirBase.ObjectID;
					closure$__17-.$VB$Local_theFlight.LandingLocation_HostUnitObjectName = theMission.SecondaryAirBase.Name;
				}
				else
				{
					closure$__17-.$VB$Local_theFlight.LandingLocation_HostUnitObjectID = "";
					closure$__17-.$VB$Local_theFlight.LandingLocation_HostUnitObjectName = "";
				}
				if (closure$__17-.$VB$Local_theFlight.FlightPlan.Count() <= 0)
				{
					continue;
				}
				Waypoint waypoint = null;
				Waypoint waypoint2 = null;
				Waypoint[] flightPlan = closure$__17-.$VB$Local_theFlight.FlightPlan;
				foreach (Waypoint waypoint3 in flightPlan)
				{
					if (waypoint3.Type == Waypoint.WaypointType.LandingMarshal)
					{
						waypoint2 = waypoint3;
					}
					else if (waypoint3.Type == Waypoint.WaypointType.Land)
					{
						waypoint = waypoint3;
						break;
					}
				}
				if (waypoint != null && theMission.SecondaryAirBase != null)
				{
					waypoint.Latitude = theMission.SecondaryAirBase.get_Latitude((GlobalVariables.BooleanObject)null);
					waypoint.Longitude = theMission.SecondaryAirBase.get_Longitude((GlobalVariables.BooleanObject)null);
					if (waypoint2 != null)
					{
						Geopoint_Struct landingQueueAssemblyPoint = theMission.SecondaryAirBase.AirOps.LandingQueueAssemblyPoint;
						waypoint2.Latitude = landingQueueAssemblyPoint.Latitude;
						waypoint2.Longitude = landingQueueAssemblyPoint.Longitude;
					}
					List<ActiveUnit> list = new List<ActiveUnit>();
					list.AddRange(Module_Mission.UnitsAssignedToMissionOrPackage(theMission, theScenario).Where(closure$__17-._Lambda$__0).ToList());
					foreach (Aircraft item in list)
					{
						if (Operators.CompareString(closure$__17-.$VB$Local_theFlight.LandingLocation_HostUnitObjectID, item.AirOps.get_AssignedHostUnit(PickNewAssignedHost: false).ObjectID, false) == 0)
						{
							continue;
						}
						if (!theScenario.ActiveUnits.ContainsKey(closure$__17-.$VB$Local_theFlight.LandingLocation_HostUnitObjectID))
						{
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
						}
						else
						{
							item.AirOps.set_AssignedHostUnit(PickNewAssignedHost: false, theScenario.ActiveUnits[closure$__17-.$VB$Local_theFlight.LandingLocation_HostUnitObjectID]);
						}
					}
					continue;
				}
				return "Error! Could not find the landing waypoint in flightplan " + closure$__17-.$VB$Local_theFlight.Name + "!";
			}
		}
		return "OK";
	}

	public static void DropContacts_Core(Side theSide, Scenario theScenario, List<Module_Unit.Unit> UnitList)
	{
		foreach (Module_Unit.Unit Unit in UnitList)
		{
			if (!Unit.IsContact())
			{
				continue;
			}
			Contact contact = (Contact)Unit;
			theSide.DropContact(contact, ref theScenario, LogMessage: true);
			Side[] sides_ReadOnly = theScenario.Sides_ReadOnly;
			foreach (Side side in sides_ReadOnly)
			{
				if (side.get_ConsidersThisSideToBe(theSide, (Scenario)null) == Misc.PostureStance.Friendly && side != theSide && side.Contacts_List.Contains(contact))
				{
					side.DropContact(contact, ref theScenario, LogMessage: false);
				}
			}
			theSide.DropBaseContact(contact, ref theScenario);
		}
		theSide.ProcessContactListChanges(theScenario);
		theSide.ProcessBaseContactListChanges(theScenario);
	}

	public static void MarkContacts_Core(Side theSide, Scenario theScenario, Misc.PostureStance newStance, List<Module_Unit.Unit> UnitList, string PlayerName = null)
	{
		string text = ".";
		string text2;
		switch (newStance)
		{
		default:
			text2 = "unknown";
			break;
		case Misc.PostureStance.Neutral:
			text2 = "neutral";
			break;
		case Misc.PostureStance.Friendly:
			text2 = "friendly";
			break;
		case Misc.PostureStance.Unfriendly:
			text2 = "unfriendly";
			break;
		case Misc.PostureStance.Hostile:
			text2 = "hostile";
			text = "!";
			break;
		}
		foreach (Module_Unit.Unit Unit in UnitList)
		{
			if (!Unit.IsContact())
			{
				continue;
			}
			Contact contact = (Contact)Unit;
			if (contact.get_Stance(theSide) != newStance)
			{
				contact.set_Stance(theSide, MarkManually: true, newStance);
				if (PlayerName != null)
				{
					theScenario.AddMessage("Contact: " + contact.Name + " has been manually marked as " + text2 + text, "[" + PlayerName + "] Contact marked " + text2, LoggedMessage.MessageType.ContactChange, 1, null, theSide, new Geopoint_Struct(((Module_Unit.Unit)contact).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact).get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				else
				{
					theScenario.AddMessage("Contact: " + contact.Name + " has been manually marked as " + text2 + text, "Contact marked " + text2, LoggedMessage.MessageType.ContactChange, 1, null, theSide, new Geopoint_Struct(((Module_Unit.Unit)contact).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact).get_Latitude((GlobalVariables.BooleanObject)null)));
				}
			}
		}
	}

	public static void MarkContactPosition_Core(Side theSide, Scenario theScenario, Module_Unit.Unit theUnit)
	{
		if (theUnit != null && theUnit.IsContact())
		{
			Contact contact = (Contact)theUnit;
			string name = contact.Name + " at " + theScenario.Time.ToShortDateString() + "-" + theScenario.Time.ToShortTimeString();
			ReferencePoint referencePoint = new ReferencePoint(((Module_Unit.Unit)contact).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact).get_Latitude((GlobalVariables.BooleanObject)null));
			referencePoint.Name = name;
			referencePoint.IsHighlighted = true;
			theSide.RefPoints.Add(referencePoint);
		}
	}

	public static void ToggleContactFilteredOutStatus_Core(Module_Unit.Unit theUnit)
	{
		if (theUnit != null && theUnit.IsContact())
		{
			Contact obj = (Contact)theUnit;
			obj.IsFilteredOut = !obj.IsFilteredOut;
		}
	}

	public static void SetAllContactsFilteredOutStatus_Core(Side theSide, bool filteredOut)
	{
		if (theSide == null)
		{
			return;
		}
		foreach (Contact contacts_ in theSide.Contacts_List)
		{
			contacts_.IsFilteredOut = filteredOut;
		}
	}

	public static void SetCivilianContactsFilteredOutStatus_Core(Side theSide, bool filteredOut)
	{
		if (theSide == null)
		{
			return;
		}
		foreach (Contact contacts_ in theSide.Contacts_List)
		{
			if (contacts_.IsCivilian && contacts_.SideIsKnown && contacts_.get_Stance(theSide) < Misc.PostureStance.Unfriendly)
			{
				contacts_.IsFilteredOut = filteredOut;
			}
		}
	}

	public static void SetBiologicContactsFilteredOutStatus_Core(Side theSide, bool filteredOut)
	{
		if (theSide == null)
		{
			return;
		}
		foreach (Contact contacts_ in theSide.Contacts_List)
		{
			if (contacts_.IsBiological && contacts_.SideIsKnown && contacts_.get_Stance(theSide) < Misc.PostureStance.Unfriendly)
			{
				contacts_.IsFilteredOut = filteredOut;
			}
		}
	}

	public static void SetNeutralContactsFilteredOutStatus_Core(Side theSide, bool filteredOut)
	{
		if (theSide == null)
		{
			return;
		}
		foreach (Contact contacts_ in theSide.Contacts_List)
		{
			if (contacts_.get_Stance(theSide) == Misc.PostureStance.Neutral)
			{
				contacts_.IsFilteredOut = filteredOut;
			}
		}
	}

	public static void SetFriendlyContactsFilteredOutStatus_Core(Side theSide, bool filteredOut)
	{
		if (theSide == null)
		{
			return;
		}
		foreach (Contact contacts_ in theSide.Contacts_List)
		{
			if (contacts_.get_Stance(theSide) == Misc.PostureStance.Friendly)
			{
				contacts_.IsFilteredOut = filteredOut;
			}
		}
	}

	public static void SetNewHomeBaseForUnits_Core(Side theSide, List<Module_Unit.Unit> theUnits, Module_Unit.Unit DestinationUnit)
	{
		if (DestinationUnit == null || !DestinationUnit.IsActiveUnit)
		{
			return;
		}
		for (int i = theUnits.Count - 1; i >= 0; i += -1)
		{
			Module_Unit.Unit unit = theUnits[i];
			if (unit.IsActiveUnit && unit.get_UnitSide(SetSideOnly: false) == theSide)
			{
				((ActiveUnit)unit).AttemptToSetNewAssignedHost((ActiveUnit)DestinationUnit);
			}
		}
	}

	public static void RefuelIfPossible_Core(Scenario theScen, Module_Unit.Unit theUnit, ActiveUnit theSelectedTanker, Mission theSelectedMission, ref string Results, ref string ResultCategory)
	{
		List<Mission> list = default(List<Mission>);
		if (theSelectedMission != null)
		{
			list = new List<Mission>();
			list.Add(theSelectedMission);
		}
		RefuelIfPossible_Core_Internal(theScen, theUnit, theSelectedTanker, list, ref Results, ref ResultCategory);
	}

	public static void RefuelIfPossible_Core(Scenario theScen, List<Module_Unit.Unit> theUnits, ActiveUnit theSelectedTanker, Mission theSelectedMission, ref string Results, ref string ResultCategory)
	{
		List<Mission> list = default(List<Mission>);
		if (theSelectedMission != null)
		{
			list = new List<Mission>();
			list.Add(theSelectedMission);
		}
		RefuelIfPossible_Core(theScen, theUnits, theSelectedTanker, list, ref Results, ref ResultCategory);
	}

	public static void RefuelIfPossible_Core(Scenario theScen, List<Module_Unit.Unit> theUnits, ActiveUnit theSelectedTanker, List<Mission> theSelectedMissions, ref string Results, ref string ResultCategory)
	{
		foreach (Module_Unit.Unit theUnit in theUnits)
		{
			RefuelIfPossible_Core_Internal(theScen, theUnit, theSelectedTanker, theSelectedMissions, ref Results, ref ResultCategory);
		}
	}

	public static void RefuelIfPossible_Core(Scenario theScen, Module_Unit.Unit theU, ActiveUnit theSelectedTanker, List<Mission> theSelectedMissions, ref string Results, ref string ResultCategory)
	{
		RefuelIfPossible_Core_Internal(theScen, theU, theSelectedTanker, theSelectedMissions, ref Results, ref ResultCategory);
	}

	public static void RefuelIfPossible_Core_Internal(Scenario theScen, Module_Unit.Unit theU, ActiveUnit theSelectedTanker, List<Mission> theSelectedMissions, ref string Results, ref string ResultCategory)
	{
		if (theSelectedTanker != null && theSelectedTanker.IsGroup)
		{
			Group obj = (Group)theSelectedTanker;
			if (obj.GroupLead == null)
			{
				return;
			}
			theSelectedTanker = obj.GroupLead;
		}
		Aircraft aircraft = null;
		bool MissionPlanner_PostponedRefuelling = false;
		string UserFeedback = "";
		if (!theU.IsAircraft)
		{
			if (theU.IsGroup)
			{
				Group obj2 = (Group)theU;
				if (obj2.Type == Group.GroupType.AirGroup && !Information.IsNothing((object)((Group)theU).GroupLead))
				{
					Aircraft aircraft2 = (Aircraft)((Group)theU).GroupLead;
					Aircraft_AirOps airOps = aircraft2.AirOps;
					GeoPoint intermediateTargetPoint = aircraft2.AI.IntermediateTargetPointForRefuelCalcs();
					bool IsManual = true;
					bool IsRTB = true;
					if (airOps.AttemptToScheduleRefuel(intermediateTargetPoint, Doctrine._UnderwayRefuelAndReplenishmentSelection.PickNearest, ref IsManual, IsForced: false, ref theSelectedTanker, ref theSelectedMissions, ref UserFeedback, ref IsRTB, ref MissionPlanner_PostponedRefuelling))
					{
						Aircraft a2AR_Destination = aircraft2.AirOps.A2AR_Destination;
						if (!Information.IsNothing((object)a2AR_Destination))
						{
							foreach (ActiveUnit value in obj2.Units.Values)
							{
								if (value != aircraft2 && value.Status != ActiveUnit._ActiveUnitStatus.Refuelling && value.IsOperating() && value != a2AR_Destination)
								{
									Aircraft_AirOps obj3 = (Aircraft_AirOps)value.AirOps;
									obj3.Condition = Aircraft_AirOps._AirOpsCondition.ManoeuveringToRefuel;
									obj3.A2AR_Destination = a2AR_Destination;
								}
							}
						}
					}
					else if (Operators.CompareString(UserFeedback, "", false) != 0)
					{
						if (Results != null)
						{
							Results = "The aircraft in group " + obj2.Name + " cannot refuel. Reason: " + UserFeedback;
						}
						theScen.AddMessage(Results, "AC unable to refuel", LoggedMessage.MessageType.AirOps, 5, aircraft2.ObjectID, theU.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(aircraft2.get_Longitude((GlobalVariables.BooleanObject)null), aircraft2.get_Latitude((GlobalVariables.BooleanObject)null)));
					}
				}
				obj2.AI.EvaluateUnitStatus(0f, ForceFuelStateCheck: false, ForceWeaponStateCheck: false);
			}
		}
		else
		{
			aircraft = (Aircraft)theU;
			Aircraft_AirOps airOps2 = aircraft.AirOps;
			GeoPoint intermediateTargetPoint2 = aircraft.AI.IntermediateTargetPointForRefuelCalcs();
			bool IsRTB = true;
			bool IsManual = ((ActiveUnit)aircraft).IsRTB;
			if (!airOps2.AttemptToScheduleRefuel(intermediateTargetPoint2, Doctrine._UnderwayRefuelAndReplenishmentSelection.PickNearest, ref IsRTB, IsForced: false, ref theSelectedTanker, ref theSelectedMissions, ref UserFeedback, ref IsManual, ref MissionPlanner_PostponedRefuelling) && Operators.CompareString(UserFeedback, "", false) != 0)
			{
				string text = "";
				if (Operators.CompareString(aircraft.Name, aircraft.UnitClass, false) != 0)
				{
					text = " (" + aircraft.UnitClass + ")";
				}
				if (Results != null)
				{
					Results = "Aircraft " + aircraft.Name + text + " cannot refuel. Reason: " + UserFeedback;
				}
				theScen.AddMessage(Results, "AC unable to refuel", LoggedMessage.MessageType.AirOps, 5, aircraft.ObjectID, theU.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(aircraft.get_Longitude((GlobalVariables.BooleanObject)null), aircraft.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			aircraft.AI.EvaluateUnitStatus(0f, ForceFuelStateCheck: false, ForceWeaponStateCheck: false);
		}
		if (!theU.IsBoat)
		{
			if (theU.IsFacility && !((Facility)theU).IsFixedFacility)
			{
				(ActiveUnit_DockingOps.ResultOfAttemptToScheduleUNREP, string) tuple = ((ActiveUnit)theU).DockingOps.AttemptToScheduleUNREP(((ActiveUnit)theU).AI.IntermediateTargetPointForRefuelCalcs(), theSelectedTanker, theSelectedMissions, IsManualOrder: false, 100);
				if (tuple.Item1 != ActiveUnit_DockingOps.ResultOfAttemptToScheduleUNREP.Success && Operators.CompareString(tuple.Item2, string.Empty, false) != 0)
				{
					if (ResultCategory != null)
					{
						ResultCategory = "Unable to replenish";
					}
					if (Results != null)
					{
						Results = tuple.Item2;
					}
					theScen.AddMessage("Unit " + theU.Name + " cannot replenish. Reason: " + tuple.Item2, "Unit " + theU.Name + " cannot replenish", LoggedMessage.MessageType.DockingOps, 5, theU.ObjectID, theU.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(theU.get_Longitude((GlobalVariables.BooleanObject)null), theU.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				((ActiveUnit)theU).AI.EvaluateUnitStatus(0f, ForceFuelStateCheck: false, ForceWeaponStateCheck: false);
			}
			else if (theU.IsVehicle)
			{
				(ActiveUnit_DockingOps.ResultOfAttemptToScheduleUNREP, string) tuple2 = ((ActiveUnit)theU).DockingOps.AttemptToScheduleUNREP(((ActiveUnit)theU).AI.IntermediateTargetPointForRefuelCalcs(), theSelectedTanker, theSelectedMissions, IsManualOrder: false, 100, ActiveUnit_DockingOps.ResupplyRequest.Fuel);
				if (tuple2.Item1 != ActiveUnit_DockingOps.ResultOfAttemptToScheduleUNREP.Success && Operators.CompareString(tuple2.Item2, string.Empty, false) != 0)
				{
					if (ResultCategory != null)
					{
						ResultCategory = "Unable to replenish";
					}
					if (Results != null)
					{
						Results = tuple2.Item2;
					}
					theScen.AddMessage("Unit " + theU.Name + " cannot replenish. Reason: " + tuple2.Item2, "Unit " + theU.Name + " cannot replenish", LoggedMessage.MessageType.DockingOps, 5, theU.ObjectID, theU.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(theU.get_Longitude((GlobalVariables.BooleanObject)null), theU.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				((ActiveUnit)theU).AI.EvaluateUnitStatus(0f, ForceFuelStateCheck: false, ForceWeaponStateCheck: false);
			}
		}
		else
		{
			(ActiveUnit_DockingOps.ResultOfAttemptToScheduleUNREP, string) tuple3 = ((ActiveUnit)theU).DockingOps.AttemptToScheduleUNREP(((ActiveUnit)theU).AI.IntermediateTargetPointForRefuelCalcs(), theSelectedTanker, theSelectedMissions, IsManualOrder: false, 100);
			if (tuple3.Item1 != ActiveUnit_DockingOps.ResultOfAttemptToScheduleUNREP.Success && Operators.CompareString(tuple3.Item2, string.Empty, false) != 0)
			{
				if (ResultCategory != null)
				{
					ResultCategory = "Unable to UNREP";
				}
				if (Results != null)
				{
					Results = tuple3.Item2;
				}
				theScen.AddMessage("Unit " + theU.Name + " cannot UNREP. Reason: " + tuple3.Item2, "Unit " + theU.Name + " cannot UNREP", LoggedMessage.MessageType.DockingOps, 5, theU.ObjectID, theU.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(theU.get_Longitude((GlobalVariables.BooleanObject)null), theU.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			((ActiveUnit)theU).AI.EvaluateUnitStatus(0f, ForceFuelStateCheck: false, ForceWeaponStateCheck: false);
		}
		if (!theU.IsGroup)
		{
			return;
		}
		Group obj4 = (Group)theU;
		if (obj4.Type != Group.GroupType.AirGroup)
		{
			List<string> list = new List<string>();
			foreach (ActiveUnit value2 in obj4.Units.Values)
			{
				(ActiveUnit_DockingOps.ResultOfAttemptToScheduleUNREP, string) tuple4 = value2.DockingOps.AttemptToScheduleUNREP(value2.AI.IntermediateTargetPointForRefuelCalcs(), theSelectedTanker, theSelectedMissions, IsManualOrder: false, 100);
				if (tuple4.Item1 != ActiveUnit_DockingOps.ResultOfAttemptToScheduleUNREP.Success && Operators.CompareString(tuple4.Item2, string.Empty, false) != 0)
				{
					theScen.AddMessage("Unit " + value2.Name + " cannot UNREP. Reason: " + tuple4.Item2, "Unit " + theU.Name + " cannot UNREP", LoggedMessage.MessageType.AirOps, 5, value2.ObjectID, theU.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(value2.get_Longitude((GlobalVariables.BooleanObject)null), value2.get_Latitude((GlobalVariables.BooleanObject)null)));
					list.Add(value2.Name + ": " + tuple4.Item2);
				}
			}
			if (list.Count > 0)
			{
				if (ResultCategory != null)
				{
					ResultCategory = "Some of the group's units failed to schedule an UNREP redezvous";
				}
				if (Results != null)
				{
					Results = string.Join("\r\n", list);
				}
			}
		}
		obj4.AI.EvaluateUnitStatus(0f, ForceFuelStateCheck: false, ForceWeaponStateCheck: false);
	}

	public static void RearmIfPossible_Core(Scenario theScen, List<Module_Unit.Unit> theUnits, ActiveUnit theSelectedTanker, Dictionary<int, Weapon> WeaponsToSupply, ref string Results, ref string ResultCategory)
	{
		foreach (Module_Unit.Unit theUnit in theUnits)
		{
			if (!theUnit.IsMobileGroundUnit && !theUnit.IsFacility && !theUnit.IsBoat && !theUnit.IsShip)
			{
				continue;
			}
			(ActiveUnit_DockingOps.ResultOfAttemptToScheduleUNREP, string) tuple = ((ActiveUnit)theUnit).DockingOps.AttemptToScheduleUNREP(((ActiveUnit)theUnit).AI.IntermediateTargetPointForRefuelCalcs(), theSelectedTanker, null, IsManualOrder: false, 100, ActiveUnit_DockingOps.ResupplyRequest.Material, WeaponsToSupply);
			if (tuple.Item1 != ActiveUnit_DockingOps.ResultOfAttemptToScheduleUNREP.Success && Operators.CompareString(tuple.Item2, string.Empty, false) != 0)
			{
				if (ResultCategory != null)
				{
					ResultCategory = "Unable to rearm";
				}
				if (Results != null)
				{
					Results = tuple.Item2;
				}
				theScen.AddMessage("Unit " + theUnit.Name + " cannot rearm. Reason: " + tuple.Item2, "Unit " + theUnit.Name + " cannot rearm", LoggedMessage.MessageType.DockingOps, 5, theUnit.ObjectID, theUnit.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(theUnit.get_Longitude((GlobalVariables.BooleanObject)null), theUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			((ActiveUnit)theUnit).AI.EvaluateUnitStatus(0f, ForceFuelStateCheck: false, ForceWeaponStateCheck: false);
		}
	}

	public static void DropSonobuoy_Core(Scenario theScenario, Module_Unit.Unit theUnit, bool ActiveSonobuoy, bool ShallowSonobuoy, bool IsManual)
	{
		string UserFeedback = "";
		if (ActiveSonobuoy)
		{
			ActiveUnit_Weaponry.DropActiveSonobuoy(theUnit, ShallowSonobuoy, IsManual, ref UserFeedback);
		}
		else
		{
			ActiveUnit_Weaponry.DropPassiveSonobuoy(theUnit, ShallowSonobuoy, IsManual, ref UserFeedback);
		}
		if (!string.IsNullOrEmpty(UserFeedback))
		{
			string text = "passive";
			string text2 = "deep";
			if (ActiveSonobuoy)
			{
				text = "active";
			}
			if (ShallowSonobuoy)
			{
				text2 = "shallow";
			}
			theScenario.AddMessage(theUnit.Name + " is attempting to drop " + text + " sonobuoy (" + text2 + "). " + UserFeedback, "Drop sonobuoy", LoggedMessage.MessageType.AirOps, 5, theUnit.ObjectID, theUnit.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(theUnit.get_Longitude((GlobalVariables.BooleanObject)null), theUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
		}
	}

	public static void DeployDippingSonar_Core(Module_Unit.Unit theUnit)
	{
		if (theUnit == null || !theUnit.IsActiveUnit)
		{
			return;
		}
		ActiveUnit activeUnit = (ActiveUnit)theUnit;
		if (!activeUnit.IsAircraft)
		{
			if (activeUnit.IsShip && activeUnit.Sensory.HasAvailableDippingSonar && !activeUnit.IsUsingDippingSonar())
			{
				activeUnit.DockingOps.AttemptDippingSonar();
			}
		}
		else if (((Aircraft)activeUnit).IsHelicopter && activeUnit.Sensory.HasAvailableDippingSonar && !activeUnit.IsUsingDippingSonar())
		{
			((Aircraft_AirOps)activeUnit.AirOps).HoverForDippingSonar();
		}
	}

	public static void SetCargoPickupTargets_Core(List<Module_Unit.Unit> UnitList, List<string> TargetIDList)
	{
		foreach (Module_Unit.Unit Unit in UnitList)
		{
			if (!Unit.IsActiveUnit)
			{
				continue;
			}
			ActiveUnit activeUnit = (ActiveUnit)Unit;
			foreach (string TargetID in TargetIDList)
			{
				activeUnit.AI.AddPickupTarget(TargetID);
			}
		}
	}

	public static void UnloadCargoAction_Core(List<Module_Unit.Unit> UnitList, List<Cargo> CargoToUnload = null)
	{
		foreach (Module_Unit.Unit Unit in UnitList)
		{
			bool flag = false;
			if (Information.IsNothing((object)Unit) || !Unit.IsActiveUnit)
			{
				continue;
			}
			ActiveUnit activeUnit = (ActiveUnit)Unit;
			if (activeUnit.IsAircraft)
			{
				Aircraft aircraft = (Aircraft)activeUnit;
				if (aircraft.Loadout.Cargo_ParadropCapable)
				{
					aircraft.AirOps.UnloadCargoParadrop();
					flag = true;
				}
				if (aircraft.OnboardCargo.Count() != 0 && aircraft.IsHelicopter)
				{
					aircraft.AirOps.Condition = Aircraft_AirOps._AirOpsCondition.TransferringCargo;
					aircraft.AirOps.ConditionTimer = Math.Max(120, ActiveUnit_DockingOps.TimeToUnloadCargo(aircraft, aircraft.OnboardCargo.ToList()));
					flag = true;
				}
			}
			else if (activeUnit.IsGroup)
			{
				if ((activeUnit is Group) & ((Group)activeUnit).IsLandInstallation)
				{
					foreach (ActiveUnit value in ((Group)activeUnit).Units.Values)
					{
						if (value.OnboardCargo.Count() > 0)
						{
							if (value.CargoTransferList == null)
							{
								Cargo.UnloadCargoAtLocation(value, ref value.OnboardCargo, CargoToUnload, value.get_Latitude((GlobalVariables.BooleanObject)null), value.get_Longitude((GlobalVariables.BooleanObject)null), value.ParentScen, value.get_UnitSide(SetSideOnly: false), paradropOnly: false);
								break;
							}
							Cargo.UnloadCargoAtLocation(value, ref value.OnboardCargo, value.CargoTransferList, value.get_Latitude((GlobalVariables.BooleanObject)null), value.get_Longitude((GlobalVariables.BooleanObject)null), value.ParentScen, value.get_UnitSide(SetSideOnly: false), paradropOnly: false);
							value.CargoTransferList = null;
						}
					}
				}
			}
			else if (CargoToUnload != null)
			{
				Cargo.UnloadCargoAtLocation(activeUnit, ref activeUnit.OnboardCargo, CargoToUnload, activeUnit.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit.ParentScen, activeUnit.get_UnitSide(SetSideOnly: false), paradropOnly: false);
				flag = true;
			}
			else if (activeUnit.DockingOps.CanUnloadCargoOverBeach())
			{
				activeUnit.DockingOps.SettleForCargoTransfer();
				flag = true;
			}
			if (!Unit.IsGroup && ((ActiveUnit)Unit).OnboardCargo.Count() > 0 && !flag)
			{
				((ActiveUnit)Unit).AddMessage(Unit.Name + " unable to unload cargo here", "Cannot unload cargo", LoggedMessage.MessageType.UI, 0, new Geopoint_Struct(Unit.get_Longitude((GlobalVariables.BooleanObject)null), Unit.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
		}
	}

	public static void CargoOpsAction_Core(List<ActiveUnit> UnitList, ActiveUnit DestinationUnit, List<Cargo> CargoList)
	{
		if (UnitList == null || CargoList == null)
		{
			return;
		}
		if (DestinationUnit == null)
		{
			List<Module_Unit.Unit> list = new List<Module_Unit.Unit>();
			foreach (ActiveUnit Unit in UnitList)
			{
				Unit.CargoTransferList = null;
				if (Unit.OnboardCargo.Count() > 0)
				{
					List<Cargo> list2 = CargoList.Intersect(Unit.OnboardCargo).ToList();
					if (list2.Count > 0)
					{
						Unit.CargoTransferList = list2;
						list.Add(Unit);
					}
				}
			}
			UnloadCargoAction_Core(list);
			return;
		}
		if ((CargoList != null && CargoList.Count != 0) || DestinationUnit == null || UnitList.Count <= 0)
		{
			foreach (ActiveUnit Unit2 in UnitList)
			{
				Unit2.CargoTransferList = null;
				if (Unit2.OnboardCargo.Count() > 0)
				{
					List<Cargo> list3 = CargoList.Intersect(Unit2.OnboardCargo).ToList();
					if (list3.Count > 0)
					{
						ActiveUnit_DockingOps.PerformCargoTransferBetweenHostAndTarget(Unit2, DestinationUnit, list3);
						if (!Unit2.IsOperating())
						{
							if (!Unit2.IsShip && !Unit2.IsVehicle)
							{
								if (Unit2.IsAircraft)
								{
									Aircraft aircraft = (Aircraft)Unit2;
									aircraft.AirOps.Condition = Aircraft_AirOps._AirOpsCondition.Readying;
									aircraft.AirOps.ConditionTimer = Math.Max(aircraft.AirOps.ConditionTimer, ActiveUnit_DockingOps.TimeToUnloadCargo(Unit2, list3));
								}
							}
							else
							{
								Unit2.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.Readying;
								Unit2.DockingOps.ConditionTimer = Math.Max(Unit2.DockingOps.ConditionTimer, ActiveUnit_DockingOps.TimeToUnloadCargo(Unit2, list3));
							}
						}
						else if (DestinationUnit.IsOperating())
						{
							if (!Unit2.IsVehicle)
							{
								if (DestinationUnit.IsVehicle)
								{
									DestinationUnit.DockingOps.SettleForCargoTransfer();
									DestinationUnit.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.TransferringMissionCargo;
									DestinationUnit.DockingOps.ConditionTimer = Math.Max(DestinationUnit.DockingOps.ConditionTimer, ActiveUnit_DockingOps.TimeToLoadCargo(DestinationUnit, list3));
								}
							}
							else
							{
								Unit2.DockingOps.SettleForCargoTransfer();
								Unit2.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.TransferringMissionCargo;
								Unit2.DockingOps.ConditionTimer = Math.Max(Unit2.DockingOps.ConditionTimer, ActiveUnit_DockingOps.TimeToUnloadCargo(Unit2, list3));
							}
						}
						else if (!DestinationUnit.IsShip && !DestinationUnit.IsVehicle)
						{
							if (DestinationUnit.IsAircraft)
							{
								Aircraft aircraft2 = (Aircraft)DestinationUnit;
								aircraft2.AirOps.Condition = Aircraft_AirOps._AirOpsCondition.Readying;
								aircraft2.AirOps.ConditionTimer = Math.Max(aircraft2.AirOps.ConditionTimer, ActiveUnit_DockingOps.TimeToLoadCargo(DestinationUnit, list3));
							}
						}
						else
						{
							DestinationUnit.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.Readying;
							DestinationUnit.DockingOps.ConditionTimer = Math.Max(DestinationUnit.DockingOps.ConditionTimer, ActiveUnit_DockingOps.TimeToLoadCargo(DestinationUnit, list3));
						}
					}
				}
			}
			return;
		}
		List<Module_Unit.Unit> list4 = new List<Module_Unit.Unit>();
		list4.Add(DestinationUnit);
		List<ActiveUnit> list5 = new List<ActiveUnit>();
		List<Cargo> list6 = new List<Cargo>();
		foreach (ActiveUnit Unit3 in UnitList)
		{
			if (Unit3.IsAircraft)
			{
				if (((Aircraft)Unit3).AirOps.HostAirFacility != null)
				{
					list5.Add(Unit3);
				}
			}
			else if (Unit3.DockingOps.HostDockFacility != null)
			{
				list5.Add(Unit3);
			}
		}
		foreach (ActiveUnit item in list5)
		{
			if (((ICargoHost)DestinationUnit).CanLoad((ICargoClient)item))
			{
				list6.Add(new Cargo(null, item));
				ActiveUnit_DockingOps.PerformCargoTransferBetweenHostAndTarget(item, DestinationUnit, list6);
			}
		}
		if (!DestinationUnit.IsOperating())
		{
			if (!DestinationUnit.IsShip && !DestinationUnit.IsVehicle)
			{
				if (DestinationUnit.IsAircraft)
				{
					Aircraft aircraft3 = (Aircraft)DestinationUnit;
					aircraft3.AirOps.Condition = Aircraft_AirOps._AirOpsCondition.Readying;
					aircraft3.AirOps.ConditionTimer = Math.Max(aircraft3.AirOps.ConditionTimer, ActiveUnit_DockingOps.TimeToLoadCargo(aircraft3, list6));
				}
			}
			else
			{
				DestinationUnit.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.Readying;
				DestinationUnit.DockingOps.ConditionTimer = Math.Max(DestinationUnit.DockingOps.ConditionTimer, ActiveUnit_DockingOps.TimeToLoadCargo(DestinationUnit, list6));
			}
		}
		UnitList = UnitList.Except(list5).ToList();
		List<string> list7 = new List<string>();
		foreach (ActiveUnit Unit4 in UnitList)
		{
			list7.Add("ActiveUnit_" + Unit4.ObjectID);
		}
		SetCargoPickupTargets_Core(list4, list7);
	}

	public static bool CargoContainerOpsAction_Core(CargoContainer theContainer, List<Cargo> theContents, ActiveUnit theUnit, bool SourceIsContainer)
	{
		bool flag = false;
		if (!SourceIsContainer)
		{
			return Cargo.LoadContainerContentsFromUnit(theUnit, theContainer, theContents);
		}
		return Cargo.UnloadContainerContentsToUnit(theContainer, theContents, theUnit);
	}

	public static bool SetWaypointThrottlePreset_Core(Waypoint theWP, ActiveUnit_Kinematics.UnitThrottlePreset theThrottle)
	{
		if (theWP != null)
		{
			theWP.ThrottlePreset = theThrottle;
			theWP.DesiredSpeed = null;
			theWP.DesiredSpeedOverride = null;
			theWP.SpeedFixed = Waypoint.FixedFree.Fixed;
			return true;
		}
		return false;
	}

	public static bool ClearWaypointThrottlePreset_Core(Waypoint theWP)
	{
		if (theWP == null)
		{
			return false;
		}
		theWP.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
		return true;
	}

	public static bool UpdateMissionPlannerForFlightplanChange_Core(Scenario theScen, Mission.Flight theFlight)
	{
		int result;
		if (theScen != null)
		{
			if (theFlight != null)
			{
				ActiveUnit activeUnit = theFlight.get_ReferenceUnit(theScen);
				Mission mission = activeUnit.get_UnitSide(SetSideOnly: false).Missions.Where([SpecialName] (Mission m) => Operators.CompareString(m.ObjectID, theFlight.ParentMissionOrPackageObjectID, false) == 0).First();
				Mission.Flight theFlight2 = theFlight;
				Mission.Flight flight;
				Waypoint[] theFlightplan = (flight = theFlight).FlightPlan;
				float NecessaryFuel = 0f;
				float MissionFuel = 0f;
				MissionPlanner.CalculateFuelQtyAndTimes_And_CheckIfEnoughFuelForFlightPlan(theScen, mission, activeUnit, theFlight2, ref theFlightplan, ref NecessaryFuel, ref MissionFuel, RangeCheck: false, RunValidation: true, RunFreeSpeedChecks: true, SetWaypointTimes: true, NewFlightPlan: false, EditLeadWaypoints: true, EditWingmanWaypoints: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, AircraftIsAirborne: false, BananaSplitRedSection: false, mission.TakeOffTime, mission.TimeOnTarget, IsMFP: false);
				flight.FlightPlan = theFlightplan;
				return true;
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public static bool SetFlightplanWaypointThrottlePreset_Core(Waypoint theWP, Scenario theScen, Mission.Flight theFlight, ActiveUnit_Kinematics.UnitThrottlePreset theThrottle)
	{
		if (theWP != null && theFlight != null && theScen != null)
		{
			if (theFlight.ReferenceUnit_DBID == 0)
			{
				return false;
			}
			theWP.ThrottlePreset = theThrottle;
			theWP.DesiredSpeed = null;
			theWP.DesiredSpeedOverride = null;
			theWP.SpeedFixed = Waypoint.FixedFree.Fixed;
			UpdateMissionPlannerForFlightplanChange_Core(theScen, theFlight);
			return true;
		}
		return false;
	}

	public static bool ClearFlightplanWaypointThrottlePreset_Core(Waypoint theWP)
	{
		if (theWP == null)
		{
			return false;
		}
		theWP.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
		return true;
	}

	public static bool SetUnitThrottlePreset_Core(ActiveUnit theAU, ActiveUnit_Kinematics.UnitThrottlePreset theThrottle)
	{
		if (theAU == null)
		{
			return false;
		}
		theAU.Kinematics.ThrottlePreset = theThrottle;
		theAU.Kinematics.FollowSpeedPreset();
		theAU.AI.UpdateSpeedAlt_MatchGroupLead();
		return true;
	}

	public static bool ClearUnitThrottlePreset_Core(ActiveUnit theAU)
	{
		if (theAU == null)
		{
			return false;
		}
		theAU.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
		return true;
	}

	public static bool SetWaypointDesiredSpeed_Core(Waypoint theWP, float theSpeed)
	{
		if (theWP != null)
		{
			ClearWaypointThrottlePreset_Core(theWP);
			int result;
			if (theWP.SprintDrift != true)
			{
				theWP.DesiredSpeed = theSpeed;
				theWP.DesiredSpeedOverride = theWP.DesiredSpeed;
				theWP.SpeedFixed = Waypoint.FixedFree.Fixed;
				result = 1;
			}
			else
			{
				theWP.SprintDrift_AverageSpeed = theSpeed;
				theWP.DesiredSpeedOverride = null;
				theWP.SpeedFixed = Waypoint.FixedFree.Free;
				result = 1;
			}
			return (byte)result != 0;
		}
		return false;
	}

	public static bool SetFlightplanWaypointDesiredSpeed_Core(Waypoint theWP, Scenario theScen, Mission.Flight theFlight, float theSpeed)
	{
		if (theWP == null)
		{
			return false;
		}
		ClearFlightplanWaypointThrottlePreset_Core(theWP);
		theWP.DesiredSpeed = theSpeed;
		theWP.DesiredSpeedOverride = theWP.DesiredSpeed;
		theWP.SpeedFixed = Waypoint.FixedFree.Fixed;
		UpdateMissionPlannerForFlightplanChange_Core(theScen, theFlight);
		return true;
	}

	public static bool SetUnitDesiredSpeed_Core(ActiveUnit theAU, float theSpeed)
	{
		if (theAU != null)
		{
			ClearUnitThrottlePreset_Core(theAU);
			int num = 0;
			float num2 = Math.Max(theAU.Kinematics.GetMaximumSpeed(theAU.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), theAU.MaxPossibleThrottleSetting, ValidateAndFixAltitude: false), theAU.Kinematics.GetMaximumSpeed(theAU.DesiredAltitude));
			if (theAU.IsAircraft)
			{
				Aircraft aircraft = (Aircraft)theAU;
				if (!aircraft.get_CanHover(bool_7: false))
				{
					num = aircraft.Kinematics.GetMaximumSpeed(aircraft.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Loiter, ValidateAndFixAltitude: false);
				}
			}
			else if (!theAU.IsWeapon)
			{
				if (theAU.IsGroup && ((Group)theAU).Type == Group.GroupType.AirGroup)
				{
					Group obj = (Group)theAU;
					if (obj.GroupLead == null)
					{
						return false;
					}
					Aircraft aircraft2 = (Aircraft)obj.GroupLead;
					if (!aircraft2.get_CanHover(bool_7: false))
					{
						num = aircraft2.Kinematics.GetMaximumSpeed(aircraft2.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Loiter, ValidateAndFixAltitude: false);
					}
				}
				else
				{
					num = (int)Math.Round(theAU.Kinematics.GetMinimumSpeed_Total(theAU.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ValidateAndFixAltitude: false));
				}
			}
			else
			{
				Weapon weapon = (Weapon)theAU;
				num = ((!weapon.Kinematics.CanApplyLoiterThrottle()) ? weapon.Kinematics.GetMaximumSpeed(theAU.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Cruise, ValidateAndFixAltitude: false) : weapon.Kinematics.GetMaximumSpeed(theAU.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Loiter, ValidateAndFixAltitude: false));
			}
			if (theSpeed > num2)
			{
				theSpeed = num2;
			}
			if (theSpeed < (float)num)
			{
				theSpeed = num;
			}
			if (theAU.Navigator.SprintDrift)
			{
				if (theAU.Navigator.AvoidCavitation)
				{
					theAU.DesiredSpeed = theSpeed;
					theAU.Navigator.SprintDrift_AverageSpeed = theAU.DesiredSpeed;
				}
				else
				{
					theAU.Navigator.SprintDrift_AverageSpeed = theSpeed;
				}
				theAU.Kinematics.DesiredSpeedOverride = null;
			}
			else
			{
				theAU.DesiredSpeed = theSpeed;
				theAU.Kinematics.DesiredSpeedOverride = theSpeed;
			}
			theAU.AI.UpdateSpeedAlt_MatchGroupLead();
			return true;
		}
		return false;
	}

	public static bool SetUnitDesiredAltitude_Core(ActiveUnit theAU, float theAltitude)
	{
		if (theAU != null)
		{
			ClearUnitAltitudeAndDepthPreset_Core(theAU);
			float maximumAltitude = theAU.Kinematics.GetMaximumAltitude();
			float minimumAltitude = theAU.Kinematics.GetMinimumAltitude();
			if (theAltitude > maximumAltitude)
			{
				theAltitude = maximumAltitude;
			}
			if (theAltitude < minimumAltitude)
			{
				theAltitude = minimumAltitude;
			}
			if (theAU.get_DesiredAltitude_UseTerrainFollowing(theAU))
			{
				theAU.DesiredAltitude_AGL = theAltitude;
			}
			else
			{
				theAU.DesiredAltitude = theAltitude;
			}
			theAU.Kinematics.DesiredAltitudeOverride = true;
			theAU.AI.UpdateSpeedAlt_MatchGroupLead();
			return true;
		}
		return false;
	}

	public static bool SetWaypointDesiredAltitude_Core(Waypoint theWP, float theAltitude)
	{
		if (theWP == null)
		{
			return false;
		}
		ClearWaypointAltitudePreset_Core(theWP);
		if (theWP.TerrainFollowing)
		{
			theWP.DesiredAltitude = null;
			theWP.DesiredAltitude_TerrainFollowing = theAltitude;
		}
		else
		{
			theWP.DesiredAltitude = theAltitude;
			theWP.DesiredAltitude_TerrainFollowing = null;
		}
		theWP.DesiredAltitudeOverride = true;
		return true;
	}

	public static bool ClearWaypointDesiredAltitude_Core(Waypoint theWP)
	{
		if (theWP != null)
		{
			ClearWaypointAltitudePreset_Core(theWP);
			theWP.DesiredAltitudeOverride = false;
			theWP.DesiredAltitude = null;
			theWP.DesiredAltitude_TerrainFollowing = null;
			return true;
		}
		return false;
	}

	public static bool ClearUnitAltitudeAndDepthPreset_Core(ActiveUnit theAU)
	{
		int result;
		if (theAU != null)
		{
			if (!theAU.UseSubmerisbleUnitUI)
			{
				if (!theAU.UseAerialUnitUI)
				{
					goto IL_0099;
				}
				if (theAU.IsAircraft)
				{
					((Aircraft_AI)theAU.AI).AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.None;
					result = 1;
				}
				else if (!theAU.IsGroup)
				{
					result = 1;
				}
				else if (((Group)theAU).Type != Group.GroupType.AirGroup)
				{
					result = 1;
				}
				else
				{
					((Group_AI)theAU.AI).AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.None;
					result = 1;
				}
			}
			else if (!theAU.IsSubmarine)
			{
				if (!theAU.IsGroup)
				{
					result = 1;
				}
				else
				{
					if (((Group)theAU).Type != Group.GroupType.SubGroup)
					{
						goto IL_0099;
					}
					((Group_AI)theAU.AI).DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.None;
					result = 1;
				}
			}
			else
			{
				((Submarine_AI)theAU.AI).DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.None;
				result = 1;
			}
			goto IL_00ae;
		}
		return false;
		IL_00ae:
		return (byte)result != 0;
		IL_0099:
		result = 1;
		goto IL_00ae;
	}

	public static bool SetWaypointDepthPreset_Core(Waypoint theWP, Scenario theScen, ActiveUnit theAU, ActiveUnit_AI.SubmarineDepthPreset theDepth)
	{
		if (theWP != null)
		{
			theWP.DepthPreset = theDepth;
			theWP.FollowDepthPreset(theScen);
			int result;
			if (theWP.DepthPreset == ActiveUnit_AI.SubmarineDepthPreset.MaxDepth)
			{
				if (theAU == null)
				{
					result = 1;
				}
				else
				{
					theWP.DesiredAltitude = theAU.Kinematics.GetMinimumAltitude();
					result = 1;
				}
			}
			else
			{
				result = 1;
			}
			return (byte)result != 0;
		}
		return false;
	}

	public static bool ClearWaypointDepthPreset_Core(Waypoint theWP)
	{
		if (theWP == null)
		{
			return false;
		}
		theWP.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.None;
		theWP.DesiredAltitude = null;
		theWP.DesiredAltitude_TerrainFollowing = null;
		return true;
	}

	public static bool SetFlightplanWaypointDepthPreset_Core(Waypoint theWP, Scenario theScen, ActiveUnit_AI.SubmarineDepthPreset theDepth)
	{
		if (theWP != null)
		{
			theWP.DepthPreset = theDepth;
			theWP.FollowDepthPreset(theScen);
			return true;
		}
		return false;
	}

	public static bool SetUnitDepthPreset_Core(ActiveUnit theAU, ActiveUnit_AI.SubmarineDepthPreset theDepth)
	{
		if (theAU != null)
		{
			if (!theAU.IsSubmarine)
			{
				if (theAU.IsGroup)
				{
					Group_AI obj = (Group_AI)theAU.AI;
					obj.DepthPreset = theDepth;
					obj.FollowDepthPreset(CheckThreats: false);
				}
			}
			else
			{
				Submarine_AI obj2 = (Submarine_AI)theAU.AI;
				obj2.DepthPreset = theDepth;
				obj2.FollowDepthPreset(CheckThreats: false);
			}
			theAU.AI.UpdateSpeedAlt_MatchGroupLead();
			return true;
		}
		return false;
	}

	public static bool SetWaypointAltitudePreset_Core(Waypoint theWP, ActiveUnit theAU, ActiveUnit_AI.AircraftAltitudePreset theAltitude)
	{
		if (theWP != null)
		{
			theWP.AltitudePreset = theAltitude;
			int result;
			switch (theAltitude)
			{
			case ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude:
				theWP.DesiredAltitude = null;
				theWP.DesiredAltitude_TerrainFollowing = null;
				if (!theAU.IsWeapon)
				{
					result = 1;
					break;
				}
				theWP.DesiredAltitude = theAU.Kinematics.GetMaximumAltitude();
				result = 1;
				break;
			default:
				theWP.FollowAltitudePreset();
				result = 1;
				break;
			case ActiveUnit_AI.AircraftAltitudePreset.MinAltitude:
			{
				theWP.FollowAltitudePreset();
				if (!theAU.IsWeapon)
				{
					result = 1;
					break;
				}
				Weapon weapon = (Weapon)theAU;
				if (!weapon.get_MinimumSafeHeight(bool_5: false).HasValue)
				{
					theWP.DesiredAltitude = weapon.Kinematics.GetMinimumAltitude();
					result = 1;
				}
				else
				{
					theWP.DesiredAltitude = weapon.get_MinimumSafeHeight(bool_5: false).Value;
					result = 1;
				}
				break;
			}
			}
			return (byte)result != 0;
		}
		return false;
	}

	public static bool ClearWaypointAltitudePreset_Core(Waypoint theWP)
	{
		if (theWP != null)
		{
			theWP.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.None;
			theWP.DesiredAltitude = null;
			theWP.DesiredAltitude_TerrainFollowing = null;
			return true;
		}
		return false;
	}

	public static bool SetFlightplanWaypointAltitudePreset_Core(Waypoint theWP, ActiveUnit_AI.AircraftAltitudePreset theAltitude)
	{
		if (theWP != null)
		{
			theWP.AltitudePreset = theAltitude;
			ActiveUnit_AI.AircraftAltitudePreset aircraftAltitudePreset = theAltitude;
			int result;
			if (aircraftAltitudePreset == ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude)
			{
				theWP.DesiredAltitude = null;
				theWP.DesiredAltitude_TerrainFollowing = null;
				result = 1;
			}
			else
			{
				theWP.FollowAltitudePreset();
				result = 1;
			}
			return (byte)result != 0;
		}
		return false;
	}

	public static bool SetUnitAltitudePreset_Core(ActiveUnit theAU, ActiveUnit_AI.AircraftAltitudePreset theAltitude)
	{
		if (theAU != null)
		{
			if (theAU.IsAircraft)
			{
				Aircraft_AI aI = ((Aircraft)theAU).AI;
				aI.AltitudePreset = theAltitude;
				aI.FollowAltitudePreset();
			}
			else if (theAU.IsGroup)
			{
				Group_AI obj = (Group_AI)theAU.AI;
				obj.AltitudePreset = theAltitude;
				obj.FollowAltitudePreset();
			}
			else if (theAU.IsWeapon)
			{
				switch (theAltitude)
				{
				case ActiveUnit_AI.AircraftAltitudePreset.MinAltitude:
				{
					Weapon weapon = (Weapon)theAU;
					if (weapon.get_MinimumSafeHeight(bool_5: false).HasValue)
					{
						theAU.DesiredAltitude = weapon.get_MinimumSafeHeight(bool_5: false).Value;
					}
					else
					{
						theAU.DesiredAltitude = theAU.Kinematics.GetMinimumAltitude();
					}
					break;
				}
				case ActiveUnit_AI.AircraftAltitudePreset.Low1000:
					theAU.DesiredAltitude = 304.80002f;
					break;
				case ActiveUnit_AI.AircraftAltitudePreset.Low2000:
					theAU.DesiredAltitude = 609.60004f;
					break;
				case ActiveUnit_AI.AircraftAltitudePreset.const_4:
					theAU.DesiredAltitude = 3657.6f;
					break;
				case ActiveUnit_AI.AircraftAltitudePreset.const_5:
					theAU.DesiredAltitude = 7620f;
					break;
				case ActiveUnit_AI.AircraftAltitudePreset.const_6:
					theAU.DesiredAltitude = 10972.8f;
					break;
				case ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude:
					theAU.DesiredAltitude = theAU.Kinematics.GetMaximumAltitude();
					break;
				}
			}
			theAU.AI.UpdateSpeedAlt_MatchGroupLead();
			return true;
		}
		return false;
	}

	public static bool ClearWaypointDesiredSpeed_Core(Waypoint theWP)
	{
		if (theWP != null)
		{
			theWP.DesiredSpeedOverride = null;
			theWP.DesiredSpeed = null;
			theWP.SpeedFixed = Waypoint.FixedFree.Fixed;
			ClearWaypointThrottlePreset_Core(theWP);
			return true;
		}
		return false;
	}

	public static bool SetWaypointAltitudeOverride_Core(Waypoint theWP, bool @override)
	{
		if (theWP != null)
		{
			theWP.DesiredAltitudeOverride = @override;
			if (theWP.DesiredAltitude.HasValue)
			{
				theWP.DesiredAltitude = 0f;
			}
			int result;
			if (@override)
			{
				result = 1;
			}
			else
			{
				theWP.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.None;
				theWP.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.None;
				theWP.DesiredAltitude = null;
				theWP.DesiredAltitude_TerrainFollowing = null;
				result = 1;
			}
			return (byte)result != 0;
		}
		return false;
	}

	public static bool SetUnitAltitudeOverride_Core(ActiveUnit theAU, bool @override)
	{
		if (theAU == null)
		{
			return false;
		}
		theAU.Kinematics.DesiredAltitudeOverride = @override;
		int result;
		if (!@override)
		{
			ClearUnitAltitudeAndDepthPreset_Core(theAU);
			theAU.AI.UpdateSpeedAlt_MatchGroupLead();
			result = 1;
		}
		else
		{
			result = 1;
		}
		return (byte)result != 0;
	}

	public static bool SetWaypointSpeedOverride_Core(Waypoint theWP, bool @override)
	{
		if (theWP == null)
		{
			return false;
		}
		int result;
		if (!@override)
		{
			ClearWaypointThrottlePreset_Core(theWP);
			theWP.SpeedFixed = Waypoint.FixedFree.Free;
			theWP.DesiredSpeedOverride = null;
			theWP.DesiredSpeed = null;
			result = 1;
		}
		else if (theWP.DesiredSpeed.HasValue)
		{
			theWP.DesiredSpeedOverride = theWP.DesiredSpeed;
			result = 1;
		}
		else
		{
			theWP.DesiredSpeed = 0f;
			theWP.DesiredSpeedOverride = theWP.DesiredSpeed;
			result = 1;
		}
		return (byte)result != 0;
	}

	public static bool SetFlightplanWaypointSpeedOverride_Core(Waypoint theWP, Scenario theScen, Mission.Flight theFlight, bool @override)
	{
		if (theWP == null)
		{
			return false;
		}
		int result;
		if (!@override)
		{
			ClearWaypointThrottlePreset_Core(theWP);
			theWP.SpeedFixed = Waypoint.FixedFree.Free;
			theWP.DesiredSpeedOverride = null;
			theWP.DesiredSpeed = null;
			UpdateMissionPlannerForFlightplanChange_Core(theScen, theFlight);
			result = 1;
		}
		else if (!theWP.DesiredSpeed.HasValue)
		{
			theWP.DesiredSpeed = 0f;
			theWP.DesiredSpeedOverride = theWP.DesiredSpeed;
			result = 1;
		}
		else
		{
			theWP.DesiredSpeedOverride = theWP.DesiredSpeed;
			result = 1;
		}
		return (byte)result != 0;
	}

	public static bool SetUnitSpeedOverride_Core(ActiveUnit theAU, bool @override)
	{
		if (theAU != null)
		{
			int result;
			if (!@override)
			{
				ClearUnitThrottlePreset_Core(theAU);
				theAU.Kinematics.DesiredSpeedOverride = null;
				theAU.AI.UpdateSpeedAlt_MatchGroupLead();
				result = 1;
			}
			else
			{
				theAU.Kinematics.DesiredSpeedOverride = theAU.DesiredSpeed;
				result = 1;
			}
			return (byte)result != 0;
		}
		return false;
	}

	public static bool SetWaypointTerrainFollowing_Core(Waypoint theWP, bool following)
	{
		if (theWP != null)
		{
			theWP.TerrainFollowing = following;
			int result;
			if (theWP.TerrainFollowing)
			{
				theWP.DesiredAltitude_TerrainFollowing = theWP.DesiredAltitude;
				theWP.DesiredAltitude = null;
				result = 1;
			}
			else
			{
				theWP.DesiredAltitude = theWP.DesiredAltitude_TerrainFollowing;
				theWP.DesiredAltitude_TerrainFollowing = null;
				result = 1;
			}
			return (byte)result != 0;
		}
		return false;
	}

	public static bool SetUnitTerrainFollowing_Core(ActiveUnit theAU, bool following)
	{
		int result;
		if (theAU != null)
		{
			if (theAU.IsAircraft)
			{
				theAU.set_DesiredAltitude_UseTerrainFollowing(theAU, following);
			}
			else if (theAU.IsGroup && ((Group)theAU).Type == Group.GroupType.AirGroup)
			{
				Group obj = (Group)theAU;
				if (obj.GroupLead != null)
				{
					obj.GroupLead.set_DesiredAltitude_UseTerrainFollowing(obj.GroupLead, following);
				}
			}
			if (!(theAU.IsAircraft | (theAU.IsGroup && ((Group)theAU).Type == Group.GroupType.AirGroup)))
			{
				goto IL_013d;
			}
			if (theAU.get_DesiredAltitude_UseTerrainFollowing(theAU))
			{
				if (theAU.DesiredAltitude > 0f)
				{
					theAU.DesiredAltitude_AGL = theAU.DesiredAltitude;
					result = 1;
				}
				else if (!theAU.IsGroupWingman())
				{
					theAU.DesiredAltitude_AGL = 200f;
					result = 1;
				}
				else
				{
					if (theAU.get_ParentGroup(UsingMissionPlanner: false).GroupLead == null)
					{
						goto IL_013d;
					}
					if (theAU.get_ParentGroup(UsingMissionPlanner: false).GroupLead.DesiredAltitude_AGL > 0f)
					{
						theAU.DesiredAltitude_AGL = theAU.get_ParentGroup(UsingMissionPlanner: false).GroupLead.DesiredAltitude_AGL;
						result = 1;
					}
					else
					{
						theAU.DesiredAltitude_AGL = 200f;
						result = 1;
					}
				}
			}
			else
			{
				float num = theAU.DesiredAltitude_AGL;
				float maximumAltitude = theAU.Kinematics.GetMaximumAltitude();
				float minimumAltitude = theAU.Kinematics.GetMinimumAltitude();
				if (num < minimumAltitude)
				{
					num = minimumAltitude;
				}
				if (num > maximumAltitude)
				{
					num = maximumAltitude;
				}
				theAU.DesiredAltitude = num;
				result = 1;
			}
			goto IL_013e;
		}
		return false;
		IL_013e:
		return (byte)result != 0;
		IL_013d:
		result = 1;
		goto IL_013e;
	}

	public static bool SetWaypointTerrainFollowingMode_Core(Waypoint theWP, ActiveUnit.TerrainFollowMode mode)
	{
		if (theWP != null)
		{
			theWP.TerrainFollowingType = mode;
			return true;
		}
		return false;
	}

	public static bool SetUnitTerrainFollowingMode_Core(ActiveUnit theAU, ActiveUnit.TerrainFollowMode mode)
	{
		if (theAU == null)
		{
			return false;
		}
		int result;
		if (theAU.IsGroup)
		{
			Group obj = (Group)theAU;
			if (obj.GroupLead == null)
			{
				result = 1;
			}
			else
			{
				obj.GroupLead.TerrainFollowingType = mode;
				result = 1;
			}
		}
		else
		{
			theAU.TerrainFollowingType = mode;
			result = 1;
		}
		return (byte)result != 0;
	}

	public static bool SetWaypointSprintDrift_Core(Waypoint theWP, bool sprintDrift)
	{
		if (theWP != null)
		{
			theWP.SprintDrift = sprintDrift;
			int result;
			if (!sprintDrift)
			{
				theWP.SprintDrift_AverageSpeed = null;
				result = 1;
			}
			else if (theWP.SprintDrift_AverageSpeed.HasValue)
			{
				result = 1;
			}
			else if (!theWP.DesiredSpeed.HasValue)
			{
				result = 1;
			}
			else
			{
				theWP.SprintDrift_AverageSpeed = theWP.DesiredSpeed;
				result = 1;
			}
			return (byte)result != 0;
		}
		return false;
	}

	public static bool ClearWaypointSprintDrift_Core(Waypoint theWP)
	{
		if (theWP == null)
		{
			return false;
		}
		theWP.SprintDrift = null;
		return true;
	}

	public static bool SetUnitSprintDrift_Core(ActiveUnit theAU, bool sprintDrift)
	{
		if (theAU != null)
		{
			theAU.Navigator.SprintDrift = sprintDrift;
			return true;
		}
		return false;
	}

	public static bool SetWaypointAvoidCavitation_Core(Waypoint theWP, bool avoidCavitation)
	{
		if (theWP == null)
		{
			return false;
		}
		theWP.AvoidCavitation = avoidCavitation;
		return true;
	}

	public static bool ClearWaypointAvoidCavitation_Core(Waypoint theWP)
	{
		if (theWP == null)
		{
			return false;
		}
		theWP.AvoidCavitation = null;
		return true;
	}

	public static bool SetUnitAvoidCavitation_Core(ActiveUnit theAU, bool avoidCavitation)
	{
		if (theAU != null)
		{
			theAU.Navigator.AvoidCavitation = avoidCavitation;
			if (theAU.IsGroup)
			{
				foreach (ActiveUnit value in ((Group)theAU).Units.Values)
				{
					value.Navigator.AvoidCavitation = avoidCavitation;
				}
			}
			int result;
			if (!theAU.Navigator.SprintDrift)
			{
				result = 1;
			}
			else if (!theAU.Navigator.SprintDrift_AverageSpeed.HasValue)
			{
				result = 1;
			}
			else
			{
				theAU.DesiredSpeed = theAU.Navigator.SprintDrift_AverageSpeed.Value;
				theAU.Navigator.SprintDrift_AverageSpeed = theAU.DesiredSpeed;
				result = 1;
			}
			return (byte)result != 0;
		}
		return false;
	}

	public static bool SetAirborneAircraftQuickTurnaround_Core(Module_Unit.Unit theUnit, bool QuickTurnaroundOn, int MaxSorties)
	{
		int result;
		if (theUnit == null)
		{
			result = 0;
		}
		else
		{
			if (theUnit.IsAircraft)
			{
				Aircraft aircraft = (Aircraft)theUnit;
				if (aircraft.AirOps.QuickTurnaround_SortiesFlown <= 0)
				{
					aircraft.AirOps.QuickTurnaround_SortiesFlown = 1;
				}
				aircraft.AirOps.QuickTurnaround_Enabled = QuickTurnaroundOn;
				int result2;
				if (QuickTurnaroundOn)
				{
					if (MaxSorties <= 0)
					{
						result2 = 1;
					}
					else
					{
						aircraft.AirOps.QuickTurnaround_SortiesTotal = MaxSorties;
						result2 = 1;
					}
				}
				else
				{
					result2 = 1;
				}
				return (byte)result2 != 0;
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	public static TaskPool AddNewPackageToParentPool_Core(Mission thePackage, Side theSide, string ParentTaskPoolName)
	{
		if (thePackage != null && theSide != null)
		{
			foreach (Mission mission in theSide.Missions)
			{
				if (mission.Category == Mission.MissionCategory.TaskPool && Operators.CompareString(mission.Name, ParentTaskPoolName, false) == 0)
				{
					TaskPool obj = (TaskPool)mission;
					obj.PackageList.Add(thePackage);
					thePackage.set_ParentTaskPoolID(theSide, mission.ObjectID);
					return obj;
				}
			}
		}
		return null;
	}

	public static string GenerateMissionFlightPlans_Core(Scenario theScen, Side theSide, Mission theMission, int RequestedFlightSize)
	{
		new List<ActiveUnit>();
		string result = "OK";
		if (RequestedFlightSize >= 6)
		{
			theMission.FlightSize = 6;
		}
		else
		{
			theMission.FlightSize = RequestedFlightSize;
		}
		while (theMission.FlightList.Count > 0)
		{
			Mission.Flight string_ = theMission.FlightList.Last();
			smethod_2(theScen, theMission, (string)(object)string_);
		}
		CreateMissionFlights_Core(theMission, theScen, theSide, RequestedFlightSize);
		int num = int.MaxValue;
		if (theMission.MissionClass == Mission._MissionClass.Strike)
		{
			num = Mission.FlightQty_To_ActualFlightQty(ref ((Strike)theMission).MaxFlightNumber_Strike);
			if (num == 0)
			{
				num = int.MaxValue;
			}
		}
		if (theMission.FlightList.Count > num)
		{
			for (int num2 = theMission.FlightList.Where([SpecialName] (Mission.Flight theF) => !theF.IsEscort).Count() - num; num2 > 0; num2--)
			{
				Mission.Flight flight = theMission.FlightList.Where([SpecialName] (Mission.Flight theF) => !theF.IsEscort).LastOrDefault();
				if (flight == null)
				{
					break;
				}
				smethod_2(theScen, theMission, (string)(object)flight);
			}
			smethod_1(theScen, theMission);
		}
		if (theMission.FlightSize < RequestedFlightSize)
		{
			bool flag = true;
			new List<ActiveUnit>();
			int num3 = (from x in Module_Mission.UnitsAssignedToMissionOrPackage(theMission, theScen)
				where x.IsAircraft && Information.IsNothing((object)x.Navigator.get_Flight(HierarchySearch: true))
				select x).ToList().Count;
			if (num3 > 0)
			{
				foreach (Mission.Flight flight3 in theMission.FlightList)
				{
					int count = flight3.get_Item(theMission, theScen).Count;
					if (count < RequestedFlightSize)
					{
						if (num3 <= 0)
						{
							flag = false;
							break;
						}
						num3 -= RequestedFlightSize - count;
					}
				}
			}
			else
			{
				flag = false;
			}
			if (flag)
			{
				smethod_1(theScen, theMission);
			}
			else
			{
				bool flag2 = true;
				Mission.Flight flight2 = default(Mission.Flight);
				while (flag2 && theMission.FlightList.Count != 1)
				{
					foreach (IGrouping<string, Mission.Flight> item in from theF in theMission.FlightList
						group theF by theF.TakeOffLocation_HostUnitObjectID)
					{
						flight2 = null;
						if (item.Count() > 1)
						{
							foreach (Mission.Flight item2 in item)
							{
								if (item2.get_Item(theMission, theScen).Count < RequestedFlightSize)
								{
									flight2 = item2;
									break;
								}
							}
						}
						if (flight2 != null)
						{
							break;
						}
					}
					if (flight2 == null)
					{
						break;
					}
					smethod_2(theScen, theMission, (string)(object)flight2);
					smethod_1(theScen, theMission);
					(from x in Module_Mission.UnitsAssignedToMissionOrPackage(theMission, theScen)
						where !Information.IsNothing((object)x.Navigator.get_Flight(HierarchySearch: true))
						select x).ToList();
					foreach (Mission.Flight flight4 in theMission.FlightList)
					{
						flag2 = false;
						if (flight4.get_Item(theMission, theScen).Count < RequestedFlightSize)
						{
							flag2 = true;
							break;
						}
					}
				}
			}
		}
		return result;
	}

	public static void CreateMissionFlights_Core(Mission theMission, Scenario theScen, Side theSide, int RequestedFlightSize)
	{
		if (!Information.IsNothing((object)theMission.MasterFlightList))
		{
			theMission.MasterFlightList.Clear();
		}
		theMission.TimeSincePlayerNotification = 0;
		GameGeneral.CheckForMissionWakeup(ref theScen, ref theSide, ref theMission, IncludeEmptySlots: true, OrderTakeOff: false, LaunchPrePlannedPackages: false, RequestedFlightSize);
	}

	private static void smethod_1(Scenario scenario_0, Mission mission_0)
	{
		_Closure$__82-0 closure$__82- = new _Closure$__82-0(closure$__82-);
		closure$__82-.$VB$Local_theMission = mission_0;
		if (closure$__82-.$VB$Local_theMission.FlightList.Count == 0)
		{
			return;
		}
		bool flag = true;
		foreach (Mission.Flight flight in closure$__82-.$VB$Local_theMission.FlightList)
		{
			PooledList<ActiveUnit> pooledList = flight.get_Item(closure$__82-.$VB$Local_theMission, scenario_0);
			if (pooledList.Count > closure$__82-.$VB$Local_theMission.FlightSize)
			{
				while (pooledList.Count == closure$__82-.$VB$Local_theMission.FlightSize)
				{
					pooledList[pooledList.Count - 1].Navigator.ClearFlight();
					pooledList.RemoveAt(pooledList.Count - 1);
				}
				flag = true;
			}
			else if (pooledList.Count < closure$__82-.$VB$Local_theMission.FlightSize)
			{
				flag = false;
			}
		}
		if (flag)
		{
			return;
		}
		List<ActiveUnit> list = (from x in Module_Mission.UnitsAssignedToMissionOrPackage(closure$__82-.$VB$Local_theMission, scenario_0)
			where x.IsAircraft && Information.IsNothing((object)x.Navigator.get_Flight(HierarchySearch: true))
			select x).ToList();
		List<ActiveUnit> list2 = (from x in Module_Mission.UnitsAssignedToMissionOrPackage(closure$__82-.$VB$Local_theMission, scenario_0)
			where x.IsAircraft && !Information.IsNothing((object)x.Navigator.get_Flight(HierarchySearch: true))
			select x).ToList();
		List<KeyValuePair<string, int>> list3 = new List<KeyValuePair<string, int>>();
		foreach (Mission.Flight flight2 in closure$__82-.$VB$Local_theMission.FlightList)
		{
			list3.Add(new KeyValuePair<string, int>(flight2.Callsign, 2));
		}
		_Closure$__82-1 closure$__82-2 = default(_Closure$__82-1);
		_Closure$__82-4 closure$__82-4 = default(_Closure$__82-4);
		_Closure$__82-2 closure$__82-5 = default(_Closure$__82-2);
		_Closure$__82-3 closure$__82-6 = default(_Closure$__82-3);
		string name = default(string);
		while (list.Count > 0)
		{
			bool flag2 = false;
			closure$__82-2 = new _Closure$__82-1(closure$__82-2);
			closure$__82-2.$VB$NonLocal_$VB$Closure_2 = closure$__82-;
			_Closure$__82-1 closure$__82-3 = closure$__82-2;
			int num = closure$__82-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMission.FlightList.Count - 1;
			closure$__82-3.$VB$Local_FlightIndex = 0;
			for (; closure$__82-2.$VB$Local_FlightIndex <= num; closure$__82-2.$VB$Local_FlightIndex++)
			{
				closure$__82-4 = new _Closure$__82-4(closure$__82-4);
				if (list.Count == 0)
				{
					break;
				}
				string text = "";
				if (list2.Count > 0)
				{
					ActiveUnit activeUnit = list2.Where(closure$__82-2._Lambda$__2).FirstOrDefault();
					if (activeUnit == null)
					{
						continue;
					}
					if (activeUnit.IsAircraft)
					{
						Aircraft aircraft = (Aircraft)activeUnit;
						if (aircraft.AirOps.CurrentHostUnit != null)
						{
							text = aircraft.AirOps.CurrentHostUnit.Name;
						}
					}
				}
				if (GameGeneral.FlightGroupFilter != GameGeneral.FlightGroupFilterOptions.Equipment)
				{
					if (GameGeneral.FlightGroupFilter == GameGeneral.FlightGroupFilterOptions.Aircraft)
					{
						closure$__82-4.$VB$Local_AU = list.Where(closure$__82-2._Lambda$__4).FirstOrDefault();
						if (closure$__82-4.$VB$Local_AU == null)
						{
							foreach (Mission.Flight flight3 in closure$__82-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMission.FlightList)
							{
								using (List<SecondaryFlightPlan>.Enumerator enumerator4 = flight3.SecondaryFlightPlans.GetEnumerator())
								{
									while (enumerator4.MoveNext())
									{
										closure$__82-5 = new _Closure$__82-2(closure$__82-5);
										closure$__82-5.$VB$Local_theSecondaryF = enumerator4.Current;
										closure$__82-4.$VB$Local_AU = list.Where(closure$__82-5._Lambda$__5).FirstOrDefault();
										if (closure$__82-4.$VB$Local_AU != null)
										{
											break;
										}
									}
								}
								if (closure$__82-4.$VB$Local_AU != null)
								{
									break;
								}
							}
						}
					}
					else if (GameGeneral.FlightGroupFilter == GameGeneral.FlightGroupFilterOptions.FreeForAll)
					{
						closure$__82-4.$VB$Local_AU = list.First();
					}
					else if (GameGeneral.FlightGroupFilter == GameGeneral.FlightGroupFilterOptions.Advanced)
					{
						foreach (ActiveUnit item in list)
						{
							if (MissionPlanner.CheckAdvancedGroupCompatibility(closure$__82-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMission.FlightList[closure$__82-2.$VB$Local_FlightIndex].ReferenceUnit_DBID, closure$__82-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMission.FlightList[closure$__82-2.$VB$Local_FlightIndex].int_1, ((Aircraft)item).DBID, ((Aircraft)item).LoadoutDBID))
							{
								closure$__82-4.$VB$Local_AU = item;
							}
						}
						if (closure$__82-4.$VB$Local_AU == null)
						{
							foreach (Mission.Flight flight4 in closure$__82-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMission.FlightList)
							{
								using (List<SecondaryFlightPlan>.Enumerator enumerator7 = flight4.SecondaryFlightPlans.GetEnumerator())
								{
									while (enumerator7.MoveNext())
									{
										closure$__82-6 = new _Closure$__82-3(closure$__82-6);
										closure$__82-6.$VB$Local_theSecondaryF = enumerator7.Current;
										closure$__82-4.$VB$Local_AU = list.Where(closure$__82-6._Lambda$__6).FirstOrDefault();
										if (closure$__82-4.$VB$Local_AU != null)
										{
											break;
										}
									}
								}
								if (closure$__82-4.$VB$Local_AU != null)
								{
									break;
								}
							}
						}
					}
				}
				else
				{
					closure$__82-4.$VB$Local_AU = list.Where(closure$__82-2._Lambda$__3).FirstOrDefault();
				}
				if (closure$__82-4.$VB$Local_AU == null)
				{
					continue;
				}
				if (closure$__82-4.$VB$Local_AU.IsAircraft && ((Aircraft)closure$__82-4.$VB$Local_AU).AirOps.CurrentHostUnit != null)
				{
					name = ((Aircraft)closure$__82-4.$VB$Local_AU).AirOps.CurrentHostUnit.Name;
				}
				if ((Operators.CompareString(text, name, false) == 0) | (Operators.CompareString(text, "", false) == 0))
				{
					int value = list3.Where(closure$__82-2._Lambda$__7).First().Value;
					Module_Mission.UnitsAssignedToMissionOrPackage(closure$__82-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMission, scenario_0).Where(closure$__82-4._Lambda$__8).First()
						.SetFlight(closure$__82-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMission.FlightList[closure$__82-2.$VB$Local_FlightIndex], value);
					list3.Remove(new KeyValuePair<string, int>(closure$__82-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMission.FlightList[closure$__82-2.$VB$Local_FlightIndex].Callsign, value));
					list3.Add(new KeyValuePair<string, int>(closure$__82-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMission.FlightList[closure$__82-2.$VB$Local_FlightIndex].Callsign, value + 1));
					list = (from x in Module_Mission.UnitsAssignedToMissionOrPackage(closure$__82-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMission, scenario_0)
						where x.IsAircraft && Information.IsNothing((object)x.Navigator.get_Flight(HierarchySearch: true))
						select x).ToList();
					list2 = (from x in Module_Mission.UnitsAssignedToMissionOrPackage(closure$__82-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMission, scenario_0)
						where x.IsAircraft && !Information.IsNothing((object)x.Navigator.get_Flight(HierarchySearch: true))
						select x).ToList();
					flag2 = true;
				}
			}
			if (flag2)
			{
				continue;
			}
			break;
		}
	}

	private static void smethod_2(Scenario scenario_0, object object_0, string string_0)
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		list = (from x in Module_Mission.UnitsAssignedToMissionOrPackage((Mission)object_0, scenario_0)
			where !Information.IsNothing((object)x.Navigator.get_Flight(HierarchySearch: true))
			select x).ToList();
		using (List<ActiveUnit>.Enumerator enumerator = list.GetEnumerator())
		{
			_Closure$__83-0 closure$__83- = default(_Closure$__83-0);
			while (enumerator.MoveNext())
			{
				closure$__83- = new _Closure$__83-0(closure$__83-);
				closure$__83-.$VB$Local_theUnit = enumerator.Current;
				if (closure$__83-.$VB$Local_theUnit.Navigator.get_Flight(HierarchySearch: true) != null && Operators.CompareString(closure$__83-.$VB$Local_theUnit.Navigator.get_Flight(HierarchySearch: true).Callsign, ((Mission.Flight)(object)string_0).Callsign, false) == 0)
				{
					Module_Mission.UnitsAssignedToMissionOrPackage((Mission)object_0, scenario_0).Where(closure$__83-._Lambda$__1).FirstOrDefault()
						.Navigator.ClearFlight();
				}
			}
		}
		((Mission)object_0).FlightList.Remove((Mission.Flight)(object)string_0);
	}

	public static void DeleteFlight_Core(Scenario theScen, Side theSide, Mission theMission, Mission.Flight theFlight)
	{
		theMission.DeleteFlight(ref theScen, ref theSide, ref theFlight, theFlight.ObjectID);
	}

	public static void CreateFlight_Core(Scenario theScen, Side theSide, Mission theMission, Mission._FlightSize FlightSize, bool isEscort)
	{
		string nextAvailableNewFlightName = theMission.GetNextAvailableNewFlightName();
		string referenceUnit_Name = "Any type";
		string value = "Any loadout";
		Mission.Flight theFlightPlan = null;
		Mission.Flight theF = new Mission.Flight(ref theScen, ref theMission, ref theFlightPlan, nextAvailableNewFlightName, null, null, FlightSize, isEscort);
		theF.ReferenceUnit_Name = referenceUnit_Name;
		theF.set_LoadoutName(theScen, value);
		theMission.AddFlight(ref theF);
	}

	public static void CopyFlight_Core(Scenario theScen, Side theSide, Mission theMission, Mission.Flight theFlight)
	{
		Mission.Flight flight = theFlight;
		Mission.Flight NewFlight = new Mission.Flight();
		int CreatedBy = (int)theFlight.CreatedBy;
		int EditedBy = (int)theFlight.EditedBy;
		flight.Copy(ref theScen, ref theFlight, ref NewFlight, UseMissionSettings: false, ref theMission, ref CreatedBy, ref EditedBy, AddEmptySlotsToMission: true, CopyErrors: true);
	}

	public static void ChangeFlightSetAllSpeedsFixed_Core(Scenario theScen, Side theSide, Mission theMission, Mission.Flight theFlight)
	{
		int num = theFlight.FlightPlan.Count() - 1;
		for (int i = 0; i <= num; i++)
		{
			Waypoint waypoint = theFlight.FlightPlan[i];
			waypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
			if (waypoint.SpeedFixed == Waypoint.FixedFree.Fixed)
			{
				waypoint.DesiredSpeedOverride = waypoint.DesiredSpeed;
				continue;
			}
			float? desiredSpeed = waypoint.DesiredSpeed;
			if ((desiredSpeed.HasValue ? new bool?(desiredSpeed.GetValueOrDefault() > 0f) : ((bool?)null)) == true)
			{
				waypoint.DesiredSpeedOverride = waypoint.DesiredSpeed;
			}
			else
			{
				waypoint.DesiredSpeed = waypoint.ActualSpeed;
				waypoint.DesiredSpeedOverride = waypoint.ActualSpeed;
			}
			waypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
		}
	}

	public static void ChangeFlightPlanToggleWaypointSpeed_Core(Scenario theScen, Side theSide, Mission theMission, Mission.Flight theFlight, Mission.Flight.FlightElement theFlightElement, Waypoint theWaypoint)
	{
		if (theFlight.ReferenceUnit_DBID == 0)
		{
			theWaypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
		}
		else if (theWaypoint.SpeedFixed != Waypoint.FixedFree.Free)
		{
			if (theWaypoint.SpeedFixed == Waypoint.FixedFree.Fixed)
			{
				if (theWaypoint.Type != Waypoint.WaypointType.TakeOff && theWaypoint.Type != Waypoint.WaypointType.Land)
				{
					if (theWaypoint.FlightFormation == Waypoint.Formation.Split && theFlightElement != Mission.Flight.FlightElement.LeadElement)
					{
						theWaypoint.SpeedFixed = Waypoint.FixedFree.Relative;
						if (theFlight != null)
						{
							Waypoint mainWaypointFromFlightElementWaypoint_Core = GetMainWaypointFromFlightElementWaypoint_Core(theFlight.FlightPlan, theWaypoint, theFlightElement);
							if (mainWaypointFromFlightElementWaypoint_Core != null)
							{
								theWaypoint.DesiredSpeed = mainWaypointFromFlightElementWaypoint_Core.DesiredSpeed;
								theWaypoint.DesiredSpeedOverride = mainWaypointFromFlightElementWaypoint_Core.DesiredSpeedOverride;
								theWaypoint.ThrottlePreset = mainWaypointFromFlightElementWaypoint_Core.ThrottlePreset;
							}
						}
					}
					else
					{
						theWaypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Cruise;
						theWaypoint.DesiredSpeed = null;
						theWaypoint.DesiredSpeedOverride = null;
						theWaypoint.SpeedFixed = Waypoint.FixedFree.Free;
					}
				}
				else
				{
					theWaypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Loiter;
					theWaypoint.DesiredSpeed = null;
					theWaypoint.DesiredSpeedOverride = null;
					theWaypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
				}
			}
			else if (theWaypoint.SpeedFixed == Waypoint.FixedFree.Relative)
			{
				theWaypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Cruise;
				theWaypoint.DesiredSpeed = null;
				theWaypoint.DesiredSpeedOverride = null;
				theWaypoint.SpeedFixed = Waypoint.FixedFree.Free;
			}
		}
		else if (theWaypoint.DesiredSpeed.HasValue || theWaypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None)
		{
			theWaypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
		}
		ActiveUnit theAU = theFlight.get_ReferenceUnit(theScen);
		Mission.Flight flight;
		Waypoint[] theFlightplan = (flight = theFlight).FlightPlan;
		float NecessaryFuel = 0f;
		float MissionFuel = 0f;
		MissionPlanner.CalculateFuelQtyAndTimes_And_CheckIfEnoughFuelForFlightPlan(theScen, theMission, theAU, theFlight, ref theFlightplan, ref NecessaryFuel, ref MissionFuel, RangeCheck: false, RunValidation: true, RunFreeSpeedChecks: true, SetWaypointTimes: true, NewFlightPlan: false, EditLeadWaypoints: true, EditWingmanWaypoints: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, AircraftIsAirborne: false, BananaSplitRedSection: false, theMission.TakeOffTime, theMission.TimeOnTarget, IsMFP: false);
		flight.FlightPlan = theFlightplan;
	}

	public static void ChangeFlightPlanToggleWaypointTime_Core(Scenario theScen, Side theSide, Mission theMission, Mission.Flight theFlight, Mission.Flight.FlightElement theFlightElement, Waypoint theWP)
	{
		Waypoint[] theFlightplan;
		Mission.Flight flight;
		if (theWP.TimeFixed == Waypoint.FixedFree.Free)
		{
			theWP.TimeFixed = Waypoint.FixedFree.Fixed;
			theFlightplan = (flight = theFlight).FlightPlan;
			UpdateWingmanWaypoints_Core(theFlight, ref theWP, ref theMission, ref theFlightplan, theFlightElement);
			flight.FlightPlan = theFlightplan;
		}
		else if (theWP.TimeFixed == Waypoint.FixedFree.Fixed)
		{
			if (theWP.FlightFormation == Waypoint.Formation.Split && theFlightElement != Mission.Flight.FlightElement.LeadElement)
			{
				theWP.TimeFixed = Waypoint.FixedFree.Relative;
			}
			else
			{
				theWP.TimeFixed = Waypoint.FixedFree.Free;
			}
		}
		else if (theWP.TimeFixed == Waypoint.FixedFree.Relative)
		{
			theWP.TimeFixed = Waypoint.FixedFree.Free;
		}
		Mission theMission2 = theMission;
		ActiveUnit theAU = theFlight.get_ReferenceUnit(theScen);
		theFlightplan = (flight = theFlight).FlightPlan;
		float NecessaryFuel = 0f;
		float MissionFuel = 0f;
		MissionPlanner.CalculateFuelQtyAndTimes_And_CheckIfEnoughFuelForFlightPlan(theScen, theMission2, theAU, theFlight, ref theFlightplan, ref NecessaryFuel, ref MissionFuel, RangeCheck: false, RunValidation: true, RunFreeSpeedChecks: true, SetWaypointTimes: true, NewFlightPlan: false, EditLeadWaypoints: true, EditWingmanWaypoints: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, AircraftIsAirborne: false, BananaSplitRedSection: false, theMission.TakeOffTime, theMission.TimeOnTarget, IsMFP: false);
		flight.FlightPlan = theFlightplan;
	}

	public static bool ChangeFlightToggleTakeoffWaypointTime_Core(Scenario theScen, Side theSide, Mission theMission, Mission.Flight theFlight)
	{
		int result;
		if (theFlight.FlightPlan.Count() > 0)
		{
			int num = theFlight.FlightPlan.Count() - 1;
			int num2 = 0;
			while (true)
			{
				if (num2 <= num)
				{
					Waypoint TheWaypoint = theFlight.FlightPlan[num2];
					if (TheWaypoint.Time_Zulu.HasValue)
					{
						if (TheWaypoint.Type != Waypoint.WaypointType.TakeOff)
						{
							num2++;
							continue;
						}
						Waypoint[] theFlightplan;
						Mission.Flight flight;
						if (TheWaypoint.TimeFixed != Waypoint.FixedFree.Free)
						{
							if (TheWaypoint.TimeFixed == Waypoint.FixedFree.Fixed)
							{
								TheWaypoint.TimeFixed = Waypoint.FixedFree.Free;
								theFlight.TakeOffWaypointFixedTime = TheWaypoint.TimeFixed;
							}
							else if (TheWaypoint.TimeFixed == Waypoint.FixedFree.Relative)
							{
								TheWaypoint.TimeFixed = Waypoint.FixedFree.Free;
								theFlight.TakeOffWaypointFixedTime = TheWaypoint.TimeFixed;
							}
						}
						else
						{
							TheWaypoint.TimeFixed = Waypoint.FixedFree.Fixed;
							theFlight.TakeOffWaypointFixedTime = TheWaypoint.TimeFixed;
							theFlightplan = (flight = theFlight).FlightPlan;
							UpdateWingmanWaypoints_Core(theFlight, ref TheWaypoint, ref theMission, ref theFlightplan, Mission.Flight.FlightElement.LeadElement);
							flight.FlightPlan = theFlightplan;
						}
						Mission theMission2 = theMission;
						ActiveUnit theAU = theFlight.get_ReferenceUnit(theScen);
						theFlightplan = (flight = theFlight).FlightPlan;
						float NecessaryFuel = 0f;
						float MissionFuel = 0f;
						MissionPlanner.CalculateFuelQtyAndTimes_And_CheckIfEnoughFuelForFlightPlan(theScen, theMission2, theAU, theFlight, ref theFlightplan, ref NecessaryFuel, ref MissionFuel, RangeCheck: false, RunValidation: true, RunFreeSpeedChecks: true, SetWaypointTimes: true, NewFlightPlan: false, EditLeadWaypoints: true, EditWingmanWaypoints: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, AircraftIsAirborne: false, BananaSplitRedSection: false, theMission.TakeOffTime, theMission.TimeOnTarget, IsMFP: false);
						flight.FlightPlan = theFlightplan;
						return true;
					}
					result = 0;
					break;
				}
				result = 0;
				break;
			}
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public static bool ChangeFlightToggleTargetWaypointTime_Core(Scenario theScen, Side theSide, Mission theMission, Mission.Flight theFlight)
	{
		int result;
		if (theFlight.FlightPlan.Count() > 0)
		{
			int num = theFlight.FlightPlan.Count() - 1;
			int num2 = 0;
			while (true)
			{
				if (num2 <= num)
				{
					Waypoint TheWaypoint = theFlight.FlightPlan[num2];
					if (TheWaypoint.Time_Zulu.HasValue)
					{
						if (!((TheWaypoint.Type == Waypoint.WaypointType.Target) | (TheWaypoint.Type == Waypoint.WaypointType.WeaponTarget)) && !TheWaypoint.IsStationStartWaypoint())
						{
							num2++;
							continue;
						}
						Waypoint[] theFlightplan;
						Mission.Flight flight;
						if (TheWaypoint.TimeFixed == Waypoint.FixedFree.Free)
						{
							TheWaypoint.TimeFixed = Waypoint.FixedFree.Fixed;
							theFlight.ObjectiveWaypointFixedTime = TheWaypoint.TimeFixed;
							theFlightplan = (flight = theFlight).FlightPlan;
							UpdateWingmanWaypoints_Core(theFlight, ref TheWaypoint, ref theMission, ref theFlightplan, Mission.Flight.FlightElement.LeadElement);
							flight.FlightPlan = theFlightplan;
						}
						else if (TheWaypoint.TimeFixed == Waypoint.FixedFree.Fixed)
						{
							TheWaypoint.TimeFixed = Waypoint.FixedFree.Free;
							theFlight.ObjectiveWaypointFixedTime = TheWaypoint.TimeFixed;
						}
						else if (TheWaypoint.TimeFixed == Waypoint.FixedFree.Relative)
						{
							TheWaypoint.TimeFixed = Waypoint.FixedFree.Free;
							theFlight.ObjectiveWaypointFixedTime = TheWaypoint.TimeFixed;
						}
						Mission theMission2 = theMission;
						ActiveUnit theAU = theFlight.get_ReferenceUnit(theScen);
						theFlightplan = (flight = theFlight).FlightPlan;
						float NecessaryFuel = 0f;
						float MissionFuel = 0f;
						MissionPlanner.CalculateFuelQtyAndTimes_And_CheckIfEnoughFuelForFlightPlan(theScen, theMission2, theAU, theFlight, ref theFlightplan, ref NecessaryFuel, ref MissionFuel, RangeCheck: false, RunValidation: true, RunFreeSpeedChecks: true, SetWaypointTimes: true, NewFlightPlan: false, EditLeadWaypoints: true, EditWingmanWaypoints: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, AircraftIsAirborne: false, BananaSplitRedSection: false, theMission.TakeOffTime, theMission.TimeOnTarget, IsMFP: false);
						flight.FlightPlan = theFlightplan;
						return true;
					}
					result = 0;
					break;
				}
				result = 0;
				break;
			}
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public static void ChangeFlightAircraftType_Core(Scenario theScen, Side theSide, Mission theMission, Mission.Flight theFlight, bool ClearExistingAircraft, int AircraftDBID)
	{
		if (ClearExistingAircraft)
		{
			theMission.ClearAllAircraft_ReplaceWithEmptySlots(ref theScen, ref theSide, ref theFlight);
		}
		if (theFlight.ReferenceUnit_DBID == AircraftDBID)
		{
			return;
		}
		theFlight.ReferenceUnit_DBID = AircraftDBID;
		theFlight.set_ReferenceUnit(theScen, (ActiveUnit)null);
		theFlight.ReferenceUnit_ObjectID = "";
		theFlight.int_1 = 0;
		theFlight.set_LoadoutName(theScen, "Any loadout");
		ActiveUnit activeUnit = theFlight.get_ReferenceUnit(theScen);
		if (AircraftDBID > 0)
		{
			theFlight.ReferenceUnit_Name = activeUnit.UnitClass;
		}
		else
		{
			theFlight.ReferenceUnit_Name = "Any type";
		}
		if (!Information.IsNothing((object)theMission.EmptySlotsList))
		{
			for (int i = theMission.EmptySlotsList.Count - 1; i >= 0; i += -1)
			{
				Mission.EmptyAircraftSlot emptyAircraftSlot = theMission.EmptySlotsList[i];
				if (emptyAircraftSlot.get_MissionFlight(theScen) != null && (theFlight == null || Operators.CompareString(theFlight.ObjectID, emptyAircraftSlot.MissionFlight_ObjectID, false) == 0))
				{
					emptyAircraftSlot.set_ReferenceUnit(theScen, (Mission)null, theFlight.get_ReferenceUnit(theScen));
					if (theFlight.get_ReferenceUnit(theScen) == null)
					{
						emptyAircraftSlot.ReferenceUnit_UnitClass = "Any type";
						emptyAircraftSlot.ReferenceUnit_DBID = 0;
					}
					else
					{
						emptyAircraftSlot.ReferenceUnit_UnitClass = theFlight.get_ReferenceUnit(theScen).UnitClass;
						emptyAircraftSlot.ReferenceUnit_DBID = theFlight.get_ReferenceUnit(theScen).DBID;
					}
					emptyAircraftSlot.int_0 = theFlight.int_1;
					emptyAircraftSlot.LoadoutName = theFlight.get_LoadoutName(theScen);
				}
			}
		}
		if (theFlight.ReferenceUnit_DBID == 0 && theFlight.FlightPlan.Count() > 0)
		{
			GameGeneral.SendMessageBoxToUI("The flight plan can be used by 'any' aircraft type, so setting all speeds to fixed...", theSide);
			ChangeFlightSetAllSpeedsFixed_Core(theScen, theSide, theMission, theFlight);
		}
		Scenario theScen2 = theScen;
		ActiveUnit theAU = theFlight.get_ReferenceUnit(theScen);
		Mission.Flight theFlight2 = theFlight;
		Mission.Flight flight;
		Waypoint[] theFlightplan = (flight = theFlight).FlightPlan;
		float NecessaryFuel = 0f;
		float MissionFuel = 0f;
		MissionPlanner.CalculateFuelQtyAndTimes_And_CheckIfEnoughFuelForFlightPlan(theScen2, theMission, theAU, theFlight2, ref theFlightplan, ref NecessaryFuel, ref MissionFuel, RangeCheck: false, RunValidation: true, RunFreeSpeedChecks: true, SetWaypointTimes: true, NewFlightPlan: false, EditLeadWaypoints: true, EditWingmanWaypoints: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, AircraftIsAirborne: false, BananaSplitRedSection: false, theMission.TakeOffTime, theMission.TimeOnTarget, IsMFP: false);
		flight.FlightPlan = theFlightplan;
	}

	public static void ChangeFlightLoadout_Core(Scenario theScen, Side theSide, Mission theMission, Mission.Flight theFlight, bool ClearExistingAircraft, int int_0, string LoadoutName = "")
	{
		if (ClearExistingAircraft)
		{
			theMission.ClearAllAircraft_ReplaceWithEmptySlots(ref theScen, ref theSide, ref theFlight);
		}
		theFlight.set_ReferenceUnit(theScen, (ActiveUnit)null);
		theFlight.ReferenceUnit_ObjectID = "";
		if (int_0 <= 0)
		{
			int_0 = 0;
			theFlight.int_1 = 0;
			theFlight.set_LoadoutName(theScen, "Any loadout");
		}
		else
		{
			theFlight.int_1 = int_0;
			theFlight.set_LoadoutName(theScen, LoadoutName);
		}
		theFlight.get_ReferenceUnit(theScen);
		if (theMission.EmptySlotsList == null)
		{
			return;
		}
		for (int i = theMission.EmptySlotsList.Count - 1; i >= 0; i += -1)
		{
			Mission.EmptyAircraftSlot emptyAircraftSlot = theMission.EmptySlotsList[i];
			if (emptyAircraftSlot.get_MissionFlight(theScen) != null && Operators.CompareString(theFlight.ObjectID, emptyAircraftSlot.MissionFlight_ObjectID, false) == 0)
			{
				emptyAircraftSlot.int_0 = theFlight.int_1;
				emptyAircraftSlot.LoadoutName = theFlight.get_LoadoutName(theScen);
			}
		}
	}

	public static void ChangeFlightAssignedUnits_Core(Scenario theScen, Side theSide, Mission theMission, Mission.Flight theFlight, List<ActiveUnit> AssignedUnits)
	{
		if (AssignedUnits == null || AssignedUnits.Count < 1 || theFlight.get_Status(theScen) != Mission._FlightStatus.None)
		{
			return;
		}
		List<ActiveUnit> list = Module_Mission.UnitsAssignedToMissionOrPackage(theMission, theScen);
		if (theMission.Category == Mission.MissionCategory.Package)
		{
			foreach (Mission mission in theSide.Missions)
			{
				if (Operators.CompareString(mission.ObjectID, theMission.get_ParentTaskPoolID(theSide), false) != 0)
				{
					continue;
				}
				foreach (ActiveUnit item in mission.get_UnitsAssignedToTaskPool(theScen))
				{
					if (item.IsAircraft && item.ActiveMissionOrPackage() == null)
					{
						list.Add(item);
					}
				}
			}
		}
		int count = list.Count;
		string text = "";
		int num;
		if (theFlight.ReferenceUnit_DBID != 0 && theFlight.int_1 != 0)
		{
			num = 0;
		}
		else
		{
			bool flag = false;
			int num2 = count - 1;
			for (int i = 0; i <= num2; i++)
			{
				ActiveUnit activeUnit = list[i];
				if (Information.IsNothing((object)activeUnit) || !activeUnit.IsAircraft || (theFlight.ReferenceUnit_DBID > 0 && activeUnit.DBID != theFlight.ReferenceUnit_DBID))
				{
					continue;
				}
				int num3 = AssignedUnits.Count - 1;
				for (int j = 0; j <= num3; j++)
				{
					ActiveUnit activeUnit2 = AssignedUnits[j];
					if (Operators.CompareString(activeUnit.Name, activeUnit2.Name, false) != 0)
					{
						if (flag)
						{
							break;
						}
						continue;
					}
					if (theFlight.ReferenceUnit_DBID == 0)
					{
						theFlight.set_ReferenceUnit(theScen, activeUnit);
						theFlight.ReferenceUnit_DBID = activeUnit.DBID;
						theFlight.ReferenceUnit_ObjectID = activeUnit.ObjectID;
						text = "Aircraft type for this flight has been set to " + activeUnit.UnitClass + ".";
					}
					int num4;
					if (theFlight.int_1 != 0)
					{
						num4 = 1;
					}
					else
					{
						Aircraft aircraft = (Aircraft)activeUnit;
						if (aircraft.Loadout == null)
						{
							num4 = 1;
						}
						else
						{
							theFlight.int_1 = aircraft.Loadout.DBID;
							theFlight.set_LoadoutName(theScen, aircraft.Loadout.Name);
							if (!string.IsNullOrEmpty(text))
							{
								text += "\r\n";
							}
							text = text + "Flight will use loadout " + aircraft.Loadout.Name;
							num4 = 1;
						}
					}
					flag = (byte)num4 != 0;
					break;
				}
			}
			if (!string.IsNullOrEmpty(text))
			{
				GameGeneral.SendMessageBoxToUI(text, theSide);
				num = 0;
			}
			else
			{
				num = 0;
			}
		}
		bool flag2 = (byte)num != 0;
		int num5 = 0;
		int num6 = theFlight.DesiredAircraftQty;
		text = "";
		int num7 = count - 1;
		for (int k = 0; k <= num7; k++)
		{
			ActiveUnit activeUnit = list[k];
			if (Information.IsNothing((object)activeUnit) || !activeUnit.IsAircraft || activeUnit.DBID != theFlight.ReferenceUnit_DBID)
			{
				continue;
			}
			if (activeUnit.Navigator.HasFlight)
			{
				if (activeUnit.Navigator.get_Flight(HierarchySearch: true) != theFlight)
				{
					continue;
				}
				int count2 = AssignedUnits.Count;
				flag2 = false;
				int num8 = count2 - 1;
				for (int l = 0; l <= num8; l++)
				{
					ActiveUnit activeUnit3 = AssignedUnits[l];
					if (Operators.CompareString(activeUnit.Name, activeUnit3.Name, false) == 0)
					{
						flag2 = true;
						num5++;
						break;
					}
				}
				if (!flag2)
				{
					theMission.ClearAircraft_ReplaceWithEmptySlot(ref theScen, ref theFlight, ref activeUnit);
				}
				continue;
			}
			int count3 = AssignedUnits.Count;
			flag2 = false;
			int num9 = count3 - 1;
			for (int m = 0; m <= num9; m++)
			{
				ActiveUnit activeUnit4 = AssignedUnits[m];
				if (Operators.CompareString(activeUnit.Name, activeUnit4.Name, false) != 0)
				{
					continue;
				}
				activeUnit.Navigator.set_Flight(HierarchySearch: true, theFlight);
				activeUnit.AI.IsEscort = theFlight.IsEscort;
				int num10;
				if (activeUnit.ActiveMissionOrPackage() == null)
				{
					ActiveUnit activeUnit5 = activeUnit;
					Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
					activeUnit5.Set_AssignedMissionOrPackage(theMission, SetMissionOnly: false, IgnoreCommsState: false, ref Result);
					if (!string.IsNullOrEmpty(text))
					{
						text += "\r\n";
					}
					text = text + activeUnit.Name + " was pulled from the Task Pool and assigned to the selected Package. ";
					num10 = 1;
				}
				else
				{
					num10 = 1;
				}
				flag2 = (byte)num10 != 0;
				num5++;
				break;
			}
		}
		if (!string.IsNullOrEmpty(text))
		{
			GameGeneral.SendMessageBoxToUI(text, theSide);
			text = "";
		}
		int num11 = num6 - num5;
		int num12 = 0;
		if (theMission.EmptySlotsList != null)
		{
			for (int n = theMission.EmptySlotsList.Count - 1; n >= 0; n += -1)
			{
				Mission.EmptyAircraftSlot emptyAircraftSlot = theMission.EmptySlotsList[n];
				if (emptyAircraftSlot.get_MissionFlight(theScen) != null && (theFlight == null || Operators.CompareString(theFlight.ObjectID, emptyAircraftSlot.MissionFlight_ObjectID, false) == 0))
				{
					num12++;
					if (num12 > num11)
					{
						theMission.EmptySlotsList.Remove(emptyAircraftSlot);
					}
				}
			}
		}
		theMission.ResetFlightReadyAicraftCount(theScen, theFlight);
		Scenario theScen2 = theScen;
		ActiveUnit theAU = theFlight.get_ReferenceUnit(theScen);
		Mission.Flight theFlight2 = theFlight;
		Mission.Flight flight;
		Waypoint[] theFlightplan = (flight = theFlight).FlightPlan;
		float NecessaryFuel = 0f;
		float MissionFuel = 0f;
		MissionPlanner.CalculateFuelQtyAndTimes_And_CheckIfEnoughFuelForFlightPlan(theScen2, theMission, theAU, theFlight2, ref theFlightplan, ref NecessaryFuel, ref MissionFuel, RangeCheck: false, RunValidation: true, RunFreeSpeedChecks: true, SetWaypointTimes: true, NewFlightPlan: false, EditLeadWaypoints: true, EditWingmanWaypoints: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, AircraftIsAirborne: false, BananaSplitRedSection: false, theMission.TakeOffTime, theMission.TimeOnTarget, IsMFP: false);
		flight.FlightPlan = theFlightplan;
	}

	public static void ChangeFlightLocation_Core(ref Scenario theScen, ref Side theSide, ref Mission theMission, Mission.Flight theFlight, ref string theLocationName, ref string theLocationObjectID, ref Module_Unit.Unit theSelectedUnit, bool IsTakeOffLocation, bool IsLandingLocation, bool IsDiversionLocation)
	{
		_Closure$__95-0 arg = default(_Closure$__95-0);
		_Closure$__95-0 CS$<>8__locals17 = new _Closure$__95-0(arg);
		CS$<>8__locals17.$VB$Local_theFlight = theFlight;
		if (IsTakeOffLocation)
		{
			List<ActiveUnit> list = new List<ActiveUnit>();
			list.AddRange(Module_Mission.UnitsAssignedToMissionOrPackage(theMission, theScen).Where([SpecialName] (ActiveUnit activeUnit) =>
			{
				int result;
				if (!activeUnit.Navigator.HasFlight)
				{
					result = 0;
				}
				else
				{
					if (activeUnit.IsAircraft && !activeUnit.IsOperating())
					{
						return activeUnit.Navigator.get_Flight(HierarchySearch: true) == CS$<>8__locals17.$VB$Local_theFlight;
					}
					result = 0;
				}
				return (byte)result != 0;
			}).ToList());
			if (list.Count > 0)
			{
				theMission.ClearAllAircraft_ReplaceWithEmptySlots(ref theScen, ref theSide, ref CS$<>8__locals17.$VB$Local_theFlight);
			}
		}
		if (!theSelectedUnit.IsActiveUnit)
		{
			return;
		}
		Aircraft aircraft = (Aircraft)CS$<>8__locals17.$VB$Local_theFlight.get_ReferenceUnit(theScen);
		bool flag = !theSelectedUnit.IsGroup;
		bool flag2 = false;
		bool flag3 = false;
		if (theSelectedUnit.IsGroup)
		{
			if (((Group)theSelectedUnit).Type == Group.GroupType.AirBase)
			{
				flag3 = true;
			}
			else
			{
				flag2 = true;
			}
		}
		if (aircraft == null)
		{
			theLocationName = theSelectedUnit.Name;
			theLocationObjectID = theSelectedUnit.ObjectID;
		}
		else
		{
			if (flag || flag3)
			{
				if (!aircraft.AirOps.ThisUnitCanHostMe((ActiveUnit)theSelectedUnit, HumanFeedbackNeeded: false).ResponseBoolean)
				{
					return;
				}
				theLocationName = theSelectedUnit.Name;
				theLocationObjectID = theSelectedUnit.ObjectID;
			}
			if (flag2)
			{
				Module_Unit.Unit unit = null;
				foreach (ActiveUnit value in ((Group)theSelectedUnit).Units.Values)
				{
					if (aircraft.AirOps.ThisUnitCanHostMe(value, HumanFeedbackNeeded: false).ResponseBoolean)
					{
						theLocationName = theSelectedUnit.Name;
						theLocationObjectID = theSelectedUnit.ObjectID;
						unit = value;
						break;
					}
				}
				if (unit == null)
				{
					return;
				}
			}
		}
		if (IsTakeOffLocation)
		{
			if (CS$<>8__locals17.$VB$Local_theFlight.FlightPlan.Count() > 0)
			{
				Waypoint[] flightPlan = CS$<>8__locals17.$VB$Local_theFlight.FlightPlan;
				Waypoint waypoint2 = default(Waypoint);
				Waypoint waypoint3 = default(Waypoint);
				Waypoint waypoint4 = default(Waypoint);
				Waypoint waypoint5 = default(Waypoint);
				Waypoint waypoint6 = default(Waypoint);
				foreach (Waypoint waypoint in flightPlan)
				{
					if (waypoint.Type == Waypoint.WaypointType.Assemble)
					{
						waypoint2 = waypoint;
						continue;
					}
					if (waypoint.Type == Waypoint.WaypointType.HoldStart)
					{
						waypoint3 = waypoint;
						continue;
					}
					if (waypoint.Type == Waypoint.WaypointType.HoldEnd)
					{
						waypoint4 = waypoint;
						continue;
					}
					if (waypoint.Type == Waypoint.WaypointType.TakeOff)
					{
						waypoint5 = waypoint;
						continue;
					}
					waypoint6 = waypoint;
					break;
				}
				if (waypoint5 == null)
				{
					return;
				}
				waypoint5.Latitude = theSelectedUnit.get_Latitude((GlobalVariables.BooleanObject)null);
				waypoint5.Longitude = theSelectedUnit.get_Longitude((GlobalVariables.BooleanObject)null);
				if (!Information.IsNothing((object)waypoint6))
				{
					float num2 = Math2.CalcDist(waypoint5.Latitude, waypoint5.Longitude, waypoint6.Latitude, waypoint6.Longitude);
					float num3 = Math2.CalcAzimuth(waypoint5.Latitude, waypoint5.Longitude, waypoint6.Latitude, waypoint6.Longitude);
					float num4 = GameGeneral.GlobalRNG.Next(-45, 45);
					if (!Information.IsNothing((object)waypoint2))
					{
						if (num2 > 15f)
						{
							double longitude = waypoint5.Longitude;
							double latitude = waypoint5.Latitude;
							Waypoint waypoint7;
							double out_lon = (waypoint7 = waypoint2).Longitude;
							Waypoint waypoint8;
							double out_lat = (waypoint8 = waypoint2).Latitude;
							Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref out_lon, ref out_lat, 10f, Math2.NormalizeBearing(num3 + num4));
							waypoint8.Latitude = out_lat;
							waypoint7.Longitude = out_lon;
						}
						else
						{
							double longitude2 = waypoint5.Longitude;
							double latitude2 = waypoint5.Latitude;
							Waypoint waypoint8;
							double out_lat = (waypoint8 = waypoint2).Longitude;
							Waypoint waypoint7;
							double out_lon = (waypoint7 = waypoint2).Latitude;
							Geodesic_EdWilliams.CalcPoint_Williams(longitude2, latitude2, ref out_lat, ref out_lon, 10f, Math2.NormalizeBearing(num3 + 180f + num4));
							waypoint7.Latitude = out_lon;
							waypoint8.Longitude = out_lat;
						}
					}
					else if (!Information.IsNothing((object)waypoint3) && !Information.IsNothing((object)waypoint4))
					{
						if (num2 > 30f)
						{
							double longitude3 = waypoint5.Longitude;
							double latitude3 = waypoint5.Latitude;
							Waypoint waypoint7;
							double out_lon = (waypoint7 = waypoint3).Longitude;
							Waypoint waypoint8;
							double out_lat = (waypoint8 = waypoint3).Latitude;
							Geodesic_EdWilliams.CalcPoint_Williams(longitude3, latitude3, ref out_lon, ref out_lat, 10f, Math2.NormalizeBearing(num3 + num4));
							waypoint8.Latitude = out_lat;
							waypoint7.Longitude = out_lon;
							float x = Math2.CalcAzimuth(waypoint3.Latitude, waypoint3.Longitude, waypoint6.Latitude, waypoint6.Longitude);
							double longitude4 = waypoint3.Longitude;
							double latitude4 = waypoint3.Latitude;
							out_lat = (waypoint8 = waypoint4).Longitude;
							out_lon = (waypoint7 = waypoint4).Latitude;
							Geodesic_EdWilliams.CalcPoint_Williams(longitude4, latitude4, ref out_lat, ref out_lon, 10f, Math2.NormalizeBearing(x));
							waypoint7.Latitude = out_lon;
							waypoint8.Longitude = out_lat;
						}
						else
						{
							double longitude5 = waypoint5.Longitude;
							double latitude5 = waypoint5.Latitude;
							Waypoint waypoint7;
							double out_lon = (waypoint7 = waypoint3).Longitude;
							Waypoint waypoint8;
							double out_lat = (waypoint8 = waypoint3).Latitude;
							Geodesic_EdWilliams.CalcPoint_Williams(longitude5, latitude5, ref out_lon, ref out_lat, 10f, Math2.NormalizeBearing(num3 + 180f + num4));
							waypoint8.Latitude = out_lat;
							waypoint7.Longitude = out_lon;
							double longitude6 = waypoint5.Longitude;
							double latitude6 = waypoint5.Latitude;
							out_lat = (waypoint8 = waypoint4).Longitude;
							out_lon = (waypoint7 = waypoint4).Latitude;
							Geodesic_EdWilliams.CalcPoint_Williams(longitude6, latitude6, ref out_lat, ref out_lon, 20f, Math2.NormalizeBearing(num3 + 180f + num4));
							waypoint7.Latitude = out_lon;
							waypoint8.Longitude = out_lat;
						}
					}
				}
			}
			if (theMission.EmptySlotsList != null)
			{
				for (int num5 = theMission.EmptySlotsList.Count - 1; num5 >= 0; num5 += -1)
				{
					Mission.EmptyAircraftSlot emptyAircraftSlot = theMission.EmptySlotsList[num5];
					if (Operators.CompareString(emptyAircraftSlot.MissionFlight_ObjectID, CS$<>8__locals17.$VB$Local_theFlight.ObjectID, false) == 0)
					{
						emptyAircraftSlot.set_CurrentHostUnit(theScen, (ActiveUnit)theSelectedUnit);
						emptyAircraftSlot.CurrentHostUnit_Name = theSelectedUnit.Name;
						emptyAircraftSlot.CurrentHostUnit_ObjectID = theSelectedUnit.ObjectID;
					}
				}
			}
			CS$<>8__locals17.$VB$Local_theFlight.set_ReferenceUnit(theScen, (ActiveUnit)null);
		}
		if (IsLandingLocation && CS$<>8__locals17.$VB$Local_theFlight.FlightPlan.Count() > 0)
		{
			Waypoint[] flightPlan2 = CS$<>8__locals17.$VB$Local_theFlight.FlightPlan;
			Waypoint waypoint10 = default(Waypoint);
			Waypoint waypoint11 = default(Waypoint);
			foreach (Waypoint waypoint9 in flightPlan2)
			{
				if (waypoint9.Type == Waypoint.WaypointType.LandingMarshal)
				{
					waypoint10 = waypoint9;
				}
				else if (waypoint9.Type == Waypoint.WaypointType.Land)
				{
					waypoint11 = waypoint9;
					break;
				}
			}
			if (Information.IsNothing((object)waypoint11))
			{
				return;
			}
			waypoint11.Latitude = theSelectedUnit.get_Latitude((GlobalVariables.BooleanObject)null);
			waypoint11.Longitude = theSelectedUnit.get_Longitude((GlobalVariables.BooleanObject)null);
			if (!aircraft.IsHelicopter && !Information.IsNothing((object)waypoint10))
			{
				Geopoint_Struct landingQueueAssemblyPoint = ((ActiveUnit)theSelectedUnit).AirOps.LandingQueueAssemblyPoint;
				waypoint10.Latitude = landingQueueAssemblyPoint.Latitude;
				waypoint10.Longitude = landingQueueAssemblyPoint.Longitude;
			}
			List<ActiveUnit> list2 = new List<ActiveUnit>();
			list2.AddRange(Module_Mission.UnitsAssignedToMissionOrPackage(theMission, theScen).Where([SpecialName] (ActiveUnit activeUnit) =>
			{
				int result;
				if (!activeUnit.Navigator.HasFlight)
				{
					result = 0;
				}
				else if (!activeUnit.IsAircraft)
				{
					result = 0;
				}
				else
				{
					if (activeUnit.IsOperating())
					{
						return activeUnit.Navigator.get_Flight(HierarchySearch: true) == CS$<>8__locals17.$VB$Local_theFlight;
					}
					result = 0;
				}
				return (byte)result != 0;
			}).ToList());
			foreach (Aircraft item in list2)
			{
				if (Operators.CompareString(CS$<>8__locals17.$VB$Local_theFlight.LandingLocation_HostUnitObjectID, item.AirOps.get_AssignedHostUnit(PickNewAssignedHost: false).ObjectID, false) == 0)
				{
					continue;
				}
				if (!theScen.ActiveUnits.ContainsKey(CS$<>8__locals17.$VB$Local_theFlight.LandingLocation_HostUnitObjectID))
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
				}
				else
				{
					item.AirOps.set_AssignedHostUnit(PickNewAssignedHost: false, theScen.ActiveUnits[CS$<>8__locals17.$VB$Local_theFlight.LandingLocation_HostUnitObjectID]);
				}
			}
		}
		Scenario theScen2 = theScen;
		Mission theMission2 = theMission;
		ActiveUnit theAU = CS$<>8__locals17.$VB$Local_theFlight.get_ReferenceUnit(theScen);
		Mission.Flight theFlight2 = CS$<>8__locals17.$VB$Local_theFlight;
		Mission.Flight flight;
		Waypoint[] theFlightplan = (flight = CS$<>8__locals17.$VB$Local_theFlight).FlightPlan;
		float NecessaryFuel = 0f;
		float MissionFuel = 0f;
		MissionPlanner.CalculateFuelQtyAndTimes_And_CheckIfEnoughFuelForFlightPlan(theScen2, theMission2, theAU, theFlight2, ref theFlightplan, ref NecessaryFuel, ref MissionFuel, RangeCheck: false, RunValidation: true, RunFreeSpeedChecks: true, SetWaypointTimes: true, NewFlightPlan: false, EditLeadWaypoints: true, EditWingmanWaypoints: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, AircraftIsAirborne: false, BananaSplitRedSection: false, theMission.TakeOffTime, theMission.TimeOnTarget, IsMFP: false);
		flight.FlightPlan = theFlightplan;
	}

	public static void ClearFlightTime_Core(Mission.Flight theFlight)
	{
		try
		{
			int num = theFlight.FlightPlan.Count() - 1;
			for (int i = 0; i <= num; i++)
			{
				Waypoint waypoint = theFlight.FlightPlan[i];
				waypoint.Time_Zulu = null;
				waypoint.Time_Zulu_Weapon = null;
				waypoint.Station_Time = 0f;
				waypoint.TimeFixed = Waypoint.FixedFree.Free;
				if (!Information.IsNothing((object)waypoint.Waypoint_LeadElementWingman))
				{
					waypoint.Waypoint_LeadElementWingman.Time_Zulu = null;
					waypoint.Waypoint_LeadElementWingman.Time_Zulu_Weapon = null;
					waypoint.Waypoint_LeadElementWingman.TimeFixed = Waypoint.FixedFree.Free;
				}
				if (!Information.IsNothing((object)waypoint.Waypoint_SecondElement))
				{
					waypoint.Waypoint_SecondElement.Time_Zulu = null;
					waypoint.Waypoint_SecondElement.Time_Zulu_Weapon = null;
					waypoint.Waypoint_SecondElement.TimeFixed = Waypoint.FixedFree.Free;
				}
				if (!Information.IsNothing((object)waypoint.Waypoint_SecondElementWingman))
				{
					waypoint.Waypoint_SecondElementWingman.Time_Zulu = null;
					waypoint.Waypoint_SecondElementWingman.Time_Zulu_Weapon = null;
					waypoint.Waypoint_SecondElementWingman.TimeFixed = Waypoint.FixedFree.Free;
				}
				if (!Information.IsNothing((object)waypoint.Waypoint_ThirdElement))
				{
					waypoint.Waypoint_ThirdElement.Time_Zulu = null;
					waypoint.Waypoint_ThirdElement.Time_Zulu_Weapon = null;
					waypoint.Waypoint_ThirdElement.TimeFixed = Waypoint.FixedFree.Free;
				}
				if (!Information.IsNothing((object)waypoint.Waypoint_ThirdElementWingman))
				{
					waypoint.Waypoint_ThirdElementWingman.Time_Zulu = null;
					waypoint.Waypoint_ThirdElementWingman.Time_Zulu_Weapon = null;
					waypoint.Waypoint_ThirdElementWingman.TimeFixed = Waypoint.FixedFree.Free;
				}
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

	public static void ChangeFlightType_Core(Mission.Flight theFlight, ref Scenario theScenario, ref Side theSide, ref Mission theMission, Mission._FlightType theFlightType)
	{
		try
		{
			switch (theFlightType)
			{
			case Mission._FlightType.Flightplan:
				theFlight.Type = theFlightType;
				break;
			case Mission._FlightType.FlightplanTemplate:
			{
				ClearFlightTime_Core(theFlight);
				theMission.ClearAllAircraft_ReplaceWithEmptySlots(ref theScenario, ref theSide, ref theFlight);
				theFlight.Type = theFlightType;
				Scenario theScen = theScenario;
				Mission theMission2 = theMission;
				ActiveUnit theAU = theFlight.get_ReferenceUnit(theScenario);
				Mission.Flight theFlight2 = theFlight;
				Mission.Flight flight;
				Waypoint[] theFlightplan = (flight = theFlight).FlightPlan;
				float NecessaryFuel = 0f;
				float MissionFuel = 0f;
				MissionPlanner.CalculateFuelQtyAndTimes_And_CheckIfEnoughFuelForFlightPlan(theScen, theMission2, theAU, theFlight2, ref theFlightplan, ref NecessaryFuel, ref MissionFuel, RangeCheck: false, RunValidation: true, RunFreeSpeedChecks: true, SetWaypointTimes: true, NewFlightPlan: false, EditLeadWaypoints: true, EditWingmanWaypoints: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, AircraftIsAirborne: false, BananaSplitRedSection: false, theMission.TakeOffTime, theMission.TimeOnTarget, IsMFP: false);
				flight.FlightPlan = theFlightplan;
				break;
			}
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

	public static void ChangeFlightTask_Core(Scenario theScen, Side theSide, Mission theMission, Mission.Flight theFlight, Mission._FlightTask NewTask)
	{
		if (NewTask == Mission._FlightTask.QRA && theFlight.FlightPlan.Count() > 0 && theFlight.FlightPlan[0].Time_Zulu.HasValue)
		{
			ClearFlightTime_Core(theFlight);
		}
		theFlight.Task = NewTask;
		if (!theFlight.IsEscortTask())
		{
			theFlight.IsEscort = false;
		}
		else
		{
			theFlight.IsEscort = true;
		}
		foreach (ActiveUnit item in Module_Mission.UnitsAssignedToMissionOrPackage(theMission, theScen))
		{
			if (item.Navigator.HasFlight && item.Navigator.get_Flight(HierarchySearch: true) == theFlight)
			{
				item.AI.IsEscort = theFlight.IsEscort;
			}
		}
		if (theMission.EmptySlotsList != null)
		{
			foreach (Mission.EmptyAircraftSlot emptySlots in theMission.EmptySlotsList)
			{
				if (Operators.CompareString(emptySlots.MissionFlight_ObjectID, theFlight.ObjectID, false) == 0)
				{
					emptySlots.IsEscort = theFlight.IsEscort;
				}
			}
		}
		ActiveUnit theAU = theFlight.get_ReferenceUnit(theScen);
		Mission.Flight flight;
		Waypoint[] theFlightplan = (flight = theFlight).FlightPlan;
		float NecessaryFuel = 0f;
		float MissionFuel = 0f;
		MissionPlanner.CalculateFuelQtyAndTimes_And_CheckIfEnoughFuelForFlightPlan(theScen, theMission, theAU, theFlight, ref theFlightplan, ref NecessaryFuel, ref MissionFuel, RangeCheck: false, RunValidation: true, RunFreeSpeedChecks: true, SetWaypointTimes: true, NewFlightPlan: false, EditLeadWaypoints: true, EditWingmanWaypoints: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, AircraftIsAirborne: false, BananaSplitRedSection: false, theMission.TakeOffTime, theMission.TimeOnTarget, IsMFP: false);
		flight.FlightPlan = theFlightplan;
	}

	public static void ChangeFlightPlanWaypointAttackMethod_Core(Scenario theScen, Side theSide, Mission theMission, Mission.Flight theFlight, Waypoint theWaypoint, Mission._AttackMethod theAttackMethod)
	{
		theWaypoint.AttackMethod = theAttackMethod;
		ActiveUnit theAU = theFlight.get_ReferenceUnit(theScen);
		Mission.Flight flight;
		Waypoint[] theFlightplan = (flight = theFlight).FlightPlan;
		float NecessaryFuel = 0f;
		float MissionFuel = 0f;
		MissionPlanner.CalculateFuelQtyAndTimes_And_CheckIfEnoughFuelForFlightPlan(theScen, theMission, theAU, theFlight, ref theFlightplan, ref NecessaryFuel, ref MissionFuel, RangeCheck: false, RunValidation: true, RunFreeSpeedChecks: true, SetWaypointTimes: true, NewFlightPlan: false, EditLeadWaypoints: true, EditWingmanWaypoints: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, AircraftIsAirborne: false, BananaSplitRedSection: false, theMission.TakeOffTime, theMission.TimeOnTarget, IsMFP: false);
		flight.FlightPlan = theFlightplan;
	}

	public static void ChangeFlightPlanWaypointTime_Core(Scenario theScen, Side theSide, Mission theMission, Mission.Flight theFlight, Mission.Flight.FlightElement theFlightElement, Waypoint theWaypoint, DateTime theDateTime, float HoldSeconds, float StationSeconds, float SpacingSeconds, float SeparationSeconds, bool RunValidation)
	{
		bool flag;
		bool flag2;
		bool flag3;
		bool flag4;
		bool flag5;
		if (theFlight.Type != Mission._FlightType.FlightplanTemplate)
		{
			flag = false;
			flag2 = theWaypoint.Hold_Time != HoldSeconds;
			flag3 = theWaypoint.Station_Time != StationSeconds;
			flag4 = theWaypoint.SpacingManeuver_Time != SpacingSeconds;
			flag5 = theWaypoint.Separation_Time != SeparationSeconds;
			DateTime t = (theWaypoint.Time_Zulu.HasValue ? new DateTime(theWaypoint.Time_Zulu.Value.Year, theWaypoint.Time_Zulu.Value.Month, theWaypoint.Time_Zulu.Value.Day, theWaypoint.Time_Zulu.Value.Hour, theWaypoint.Time_Zulu.Value.Minute, theWaypoint.Time_Zulu.Value.Second) : new DateTime(theScen.StartTime.Year, theScen.StartTime.Month, theScen.StartTime.Day, theScen.StartTime.Hour, theScen.StartTime.Minute, theScen.StartTime.Second));
			DateTime t2 = ((!theWaypoint.Time_Zulu_Weapon.HasValue) ? new DateTime(theScen.StartTime.Year, theScen.StartTime.Month, theScen.StartTime.Day, theScen.StartTime.Hour, theScen.StartTime.Minute, theScen.StartTime.Second) : new DateTime(theWaypoint.Time_Zulu_Weapon.Value.Year, theWaypoint.Time_Zulu_Weapon.Value.Month, theWaypoint.Time_Zulu_Weapon.Value.Day, theWaypoint.Time_Zulu_Weapon.Value.Hour, theWaypoint.Time_Zulu_Weapon.Value.Minute, theWaypoint.Time_Zulu_Weapon.Value.Second));
			if (theWaypoint.Leg_Time_Weapon > 0f)
			{
				if (DateTime.Compare(t2, theDateTime) != 0)
				{
					int num;
					if (theDateTime.Year == theScen.StartTime.Year && theDateTime.Month == theScen.StartTime.Month && theDateTime.Day == theScen.StartTime.Day && theDateTime.Hour == theScen.StartTime.Hour && theDateTime.Minute == theScen.StartTime.Minute)
					{
						if (theDateTime.Second == theScen.StartTime.Second)
						{
							goto IL_031f;
						}
						num = 1;
					}
					else
					{
						num = 1;
					}
					flag = (byte)num != 0;
				}
			}
			else if (DateTime.Compare(t, theDateTime) != 0)
			{
				flag = true;
			}
			goto IL_031f;
		}
		if (theWaypoint.Type == Waypoint.WaypointType.StationEnd)
		{
			theWaypoint.Station_Time = StationSeconds;
		}
		goto IL_07a6;
		IL_031f:
		if (theWaypoint.Hold_Time != HoldSeconds)
		{
			flag2 = true;
			if (!theWaypoint.Time_Zulu.HasValue)
			{
				flag = true;
			}
		}
		if (theWaypoint.Station_Time != StationSeconds)
		{
			flag3 = true;
			if (!theWaypoint.Time_Zulu.HasValue)
			{
				flag = true;
			}
		}
		if (theWaypoint.SpacingManeuver_Time != SpacingSeconds)
		{
			flag4 = true;
		}
		if (theWaypoint.Separation_Time != SeparationSeconds)
		{
			flag5 = true;
		}
		if (!flag && !flag2 && !flag3 && !flag4 && !flag5)
		{
			return;
		}
		int num2 = theFlight.FlightPlan.Count();
		if (flag5)
		{
			theWaypoint.Separation_Time = SeparationSeconds;
		}
		Waypoint[] theFlightplan;
		Mission.Flight flight;
		if (!flag)
		{
			if (flag5)
			{
				theFlightplan = (flight = theFlight).FlightPlan;
				UpdateWingmanWaypoints_Core(theFlight, ref theWaypoint, ref theMission, ref theFlightplan, theFlightElement);
				flight.FlightPlan = theFlightplan;
			}
		}
		else
		{
			if (theWaypoint.Leg_Time_Weapon > 0f)
			{
				theWaypoint.Time_Zulu = theDateTime.AddSeconds(0f - theWaypoint.Leg_Time_Weapon);
				theWaypoint.Time_Zulu_Weapon = theDateTime;
				theWaypoint.TimeFixed = Waypoint.FixedFree.Fixed;
			}
			else
			{
				theWaypoint.Time_Zulu = theDateTime;
				theWaypoint.Time_Zulu_Weapon = null;
				theWaypoint.TimeFixed = Waypoint.FixedFree.Fixed;
			}
			if (!flag3 && theWaypoint.Type == Waypoint.WaypointType.StationEnd)
			{
				int num3 = num2 - 1;
				Waypoint waypoint = default(Waypoint);
				Waypoint waypoint2 = default(Waypoint);
				for (int i = 0; i <= num3; i++)
				{
					waypoint = theFlight.FlightPlan[i];
					if (waypoint != null)
					{
						if (waypoint == theWaypoint)
						{
							break;
						}
						if (waypoint.IsStationStartWaypoint())
						{
							waypoint2 = waypoint;
						}
					}
				}
				if (waypoint2 != null && waypoint2.Time_Zulu.HasValue && waypoint != null && waypoint.Time_Zulu.HasValue)
				{
					double a = Math.Max((theWaypoint.Time_Zulu.Value - waypoint2.Time_Zulu.Value).TotalSeconds, 0.0);
					theWaypoint.Station_Time = (long)Math.Round(a);
				}
				else
				{
					GameGeneral.SendMessageBoxToUI("Give the Station End waypoint a Station Time before setting the Zulu Time.", theSide);
				}
			}
			if (theWaypoint.IsHoldWaypoint() && !theWaypoint.Time_Zulu.HasValue)
			{
				theWaypoint.Time_Zulu = theDateTime;
			}
			theFlightplan = (flight = theFlight).FlightPlan;
			UpdateWingmanWaypoints_Core(theFlight, ref theWaypoint, ref theMission, ref theFlightplan, theFlightElement);
			flight.FlightPlan = theFlightplan;
			if (theWaypoint.FlightFormation != Waypoint.Formation.Split)
			{
				if (theWaypoint.Waypoint_LeadElementWingman != null)
				{
					theWaypoint.Waypoint_LeadElementWingman.Time_Zulu = theWaypoint.Time_Zulu;
					theWaypoint.Waypoint_LeadElementWingman.Time_Zulu_Weapon = theWaypoint.Time_Zulu_Weapon;
					theWaypoint.Waypoint_LeadElementWingman.TimeFixed = Waypoint.FixedFree.Fixed;
				}
				if (theWaypoint.Waypoint_SecondElement != null)
				{
					theWaypoint.Waypoint_SecondElement.Time_Zulu = theWaypoint.Time_Zulu;
					theWaypoint.Waypoint_SecondElement.Time_Zulu_Weapon = theWaypoint.Time_Zulu_Weapon;
					theWaypoint.Waypoint_SecondElement.TimeFixed = Waypoint.FixedFree.Fixed;
				}
				if (theWaypoint.Waypoint_SecondElementWingman != null)
				{
					theWaypoint.Waypoint_SecondElementWingman.Time_Zulu = theWaypoint.Time_Zulu;
					theWaypoint.Waypoint_SecondElementWingman.Time_Zulu_Weapon = theWaypoint.Time_Zulu_Weapon;
					theWaypoint.Waypoint_SecondElementWingman.TimeFixed = Waypoint.FixedFree.Fixed;
				}
				if (theWaypoint.Waypoint_ThirdElement != null)
				{
					theWaypoint.Waypoint_ThirdElement.Time_Zulu = theWaypoint.Time_Zulu;
					theWaypoint.Waypoint_ThirdElement.Time_Zulu_Weapon = theWaypoint.Time_Zulu_Weapon;
					theWaypoint.Waypoint_ThirdElement.TimeFixed = Waypoint.FixedFree.Fixed;
				}
				if (theWaypoint.Waypoint_ThirdElementWingman != null)
				{
					theWaypoint.Waypoint_ThirdElementWingman.Time_Zulu = theWaypoint.Time_Zulu;
					theWaypoint.Waypoint_ThirdElementWingman.Time_Zulu_Weapon = theWaypoint.Time_Zulu_Weapon;
					theWaypoint.Waypoint_ThirdElementWingman.TimeFixed = Waypoint.FixedFree.Fixed;
				}
			}
		}
		if (flag2 && (theWaypoint.Type == Waypoint.WaypointType.Assemble || theWaypoint.Type == Waypoint.WaypointType.HoldEnd) && theWaypoint.Time_Zulu.HasValue)
		{
			theWaypoint.Hold_Time = HoldSeconds;
		}
		if (flag3 && theWaypoint.Type == Waypoint.WaypointType.StationEnd && theWaypoint.Time_Zulu.HasValue)
		{
			theWaypoint.Station_Time = StationSeconds;
		}
		if (flag4)
		{
			theWaypoint.SpacingManeuver_Time = SpacingSeconds;
		}
		if (flag5)
		{
			theWaypoint.Separation_Time = SeparationSeconds;
			theFlightplan = (flight = theFlight).FlightPlan;
			UpdateWingmanWaypoints_Core(theFlight, ref theWaypoint, ref theMission, ref theFlightplan, theFlightElement);
			flight.FlightPlan = theFlightplan;
		}
		if (flag2 || flag3)
		{
			int num4 = num2 - 1;
			for (int j = 0; j <= num4; j++)
			{
				Waypoint waypoint = theFlight.FlightPlan[j];
				if (waypoint != null && waypoint.TimeFixed != Waypoint.FixedFree.Fixed && !waypoint.Time_Zulu.HasValue)
				{
					waypoint.Time_Zulu = theDateTime;
				}
			}
		}
		goto IL_07a6;
		IL_07a6:
		Mission theMission2 = theMission;
		ActiveUnit theAU = theFlight.get_ReferenceUnit(theScen);
		theFlightplan = (flight = theFlight).FlightPlan;
		float NecessaryFuel = 0f;
		float MissionFuel = 0f;
		MissionPlanner.CalculateFuelQtyAndTimes_And_CheckIfEnoughFuelForFlightPlan(theScen, theMission2, theAU, theFlight, ref theFlightplan, ref NecessaryFuel, ref MissionFuel, RangeCheck: false, RunValidation, RunFreeSpeedChecks: true, SetWaypointTimes: true, NewFlightPlan: false, EditLeadWaypoints: true, EditWingmanWaypoints: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, AircraftIsAirborne: false, BananaSplitRedSection: false, theMission.TakeOffTime, theMission.TimeOnTarget, IsMFP: false);
		flight.FlightPlan = theFlightplan;
	}

	public static Waypoint GetMainWaypointFromFlightElementWaypoint_Core(Waypoint[] theFlightPlan, Waypoint theElementWaypoint, Mission.Flight.FlightElement theFlightPlan_Element)
	{
		if (theElementWaypoint != null && theFlightPlan_Element != Mission.Flight.FlightElement.LeadElement)
		{
			foreach (Waypoint waypoint in theFlightPlan)
			{
				if (waypoint.Waypoint_LeadElementWingman == theElementWaypoint || waypoint.Waypoint_SecondElement == theElementWaypoint || waypoint.Waypoint_SecondElementWingman == theElementWaypoint || waypoint.Waypoint_ThirdElement == theElementWaypoint || waypoint.Waypoint_ThirdElementWingman == theElementWaypoint)
				{
					return waypoint;
				}
			}
		}
		return null;
	}

	public static void UpdateWingmanWaypoints_Core(Mission.Flight theFlight, ref Waypoint TheWaypoint, ref Mission theMission, ref Waypoint[] theFlightplan, Mission.Flight.FlightElement theFlightPlan_Element)
	{
		LockWingmanTargetWaypoints_Core(theFlight, ref theMission, ref TheWaypoint);
		if (theFlightPlan_Element == Mission.Flight.FlightElement.LeadElement)
		{
			return;
		}
		Waypoint[] array = theFlightplan;
		int num = 0;
		Waypoint TheWaypoint2;
		bool flag;
		while (true)
		{
			if (num >= array.Length)
			{
				return;
			}
			TheWaypoint2 = array[num];
			flag = theMission.MissionClass == Mission._MissionClass.Strike && (TheWaypoint2.Type == Waypoint.WaypointType.Target || TheWaypoint2.Type == Waypoint.WaypointType.WeaponTarget);
			if (TheWaypoint2.Waypoint_LeadElementWingman == null || TheWaypoint2.Waypoint_LeadElementWingman != TheWaypoint)
			{
				if (TheWaypoint2.Waypoint_SecondElement == null || TheWaypoint2.Waypoint_SecondElement != TheWaypoint)
				{
					if (TheWaypoint2.Waypoint_SecondElementWingman == null || TheWaypoint2.Waypoint_SecondElementWingman != TheWaypoint)
					{
						if (TheWaypoint2.Waypoint_ThirdElement == null || TheWaypoint2.Waypoint_ThirdElement != TheWaypoint)
						{
							if (TheWaypoint2.Waypoint_ThirdElementWingman != null && TheWaypoint2.Waypoint_ThirdElementWingman == TheWaypoint)
							{
								break;
							}
							num = checked(num + 1);
							continue;
						}
						if (!flag)
						{
							TheWaypoint2.Time_Zulu = TheWaypoint.Time_Zulu;
							TheWaypoint2.Time_Zulu_Weapon = null;
						}
						else if (TheWaypoint.Leg_Time_Weapon > 0f)
						{
							TheWaypoint2.Time_Zulu_Weapon = TheWaypoint.Time_Zulu_Weapon.Value.AddSeconds((0f - TheWaypoint2.Separation_Time) * 4f);
							TheWaypoint2.Time_Zulu = TheWaypoint2.Time_Zulu_Weapon.Value.AddSeconds(0f - TheWaypoint2.Leg_Time_Weapon);
						}
						else
						{
							TheWaypoint2.Time_Zulu = TheWaypoint.Time_Zulu.Value.AddSeconds((0f - TheWaypoint2.Separation_Time) * 4f);
							TheWaypoint2.Time_Zulu_Weapon = null;
						}
						TheWaypoint2.TimeFixed = TheWaypoint.TimeFixed;
						LockWingmanTargetWaypoints_Core(theFlight, ref theMission, ref TheWaypoint2);
						return;
					}
					if (!flag)
					{
						TheWaypoint2.Time_Zulu = TheWaypoint.Time_Zulu;
						TheWaypoint2.Time_Zulu_Weapon = null;
					}
					else if (TheWaypoint.Leg_Time_Weapon > 0f)
					{
						TheWaypoint2.Time_Zulu_Weapon = TheWaypoint.Time_Zulu_Weapon.Value.AddSeconds((0f - TheWaypoint2.Separation_Time) * 3f);
						TheWaypoint2.Time_Zulu = TheWaypoint2.Time_Zulu_Weapon.Value.AddSeconds(0f - TheWaypoint2.Leg_Time_Weapon);
					}
					else
					{
						TheWaypoint2.Time_Zulu = TheWaypoint.Time_Zulu.Value.AddSeconds((0f - TheWaypoint2.Separation_Time) * 3f);
						TheWaypoint2.Time_Zulu_Weapon = null;
					}
					TheWaypoint2.TimeFixed = TheWaypoint.TimeFixed;
					LockWingmanTargetWaypoints_Core(theFlight, ref theMission, ref TheWaypoint2);
					return;
				}
				if (flag)
				{
					if (TheWaypoint.Leg_Time_Weapon <= 0f)
					{
						TheWaypoint2.Time_Zulu = TheWaypoint.Time_Zulu.Value.AddSeconds((0f - TheWaypoint2.Separation_Time) * 2f);
						TheWaypoint2.Time_Zulu_Weapon = null;
					}
					else
					{
						TheWaypoint2.Time_Zulu_Weapon = TheWaypoint.Time_Zulu_Weapon.Value.AddSeconds((0f - TheWaypoint2.Separation_Time) * 2f);
						TheWaypoint2.Time_Zulu = TheWaypoint2.Time_Zulu_Weapon.Value.AddSeconds(0f - TheWaypoint2.Leg_Time_Weapon);
					}
				}
				else
				{
					TheWaypoint2.Time_Zulu = TheWaypoint.Time_Zulu;
					TheWaypoint2.Time_Zulu_Weapon = null;
				}
				TheWaypoint2.TimeFixed = TheWaypoint.TimeFixed;
				LockWingmanTargetWaypoints_Core(theFlight, ref theMission, ref TheWaypoint2);
				return;
			}
			if (flag)
			{
				if (TheWaypoint.Leg_Time_Weapon > 0f)
				{
					TheWaypoint2.Time_Zulu_Weapon = TheWaypoint.Time_Zulu_Weapon.Value.AddSeconds(0f - TheWaypoint2.Separation_Time);
					TheWaypoint2.Time_Zulu = TheWaypoint2.Time_Zulu_Weapon.Value.AddSeconds(0f - TheWaypoint2.Leg_Time_Weapon);
				}
				else
				{
					TheWaypoint2.Time_Zulu = TheWaypoint.Time_Zulu.Value.AddSeconds(0f - TheWaypoint2.Separation_Time);
					TheWaypoint2.Time_Zulu_Weapon = null;
				}
			}
			else
			{
				TheWaypoint2.Time_Zulu = TheWaypoint.Time_Zulu;
				TheWaypoint2.Time_Zulu_Weapon = null;
			}
			TheWaypoint2.TimeFixed = TheWaypoint.TimeFixed;
			LockWingmanTargetWaypoints_Core(theFlight, ref theMission, ref TheWaypoint2);
			return;
		}
		if (!flag)
		{
			TheWaypoint2.Time_Zulu = TheWaypoint.Time_Zulu;
			TheWaypoint2.Time_Zulu_Weapon = null;
		}
		else if (TheWaypoint.Leg_Time_Weapon > 0f)
		{
			TheWaypoint2.Time_Zulu_Weapon = TheWaypoint.Time_Zulu_Weapon.Value.AddSeconds((0f - TheWaypoint2.Separation_Time) * 5f);
			TheWaypoint2.Time_Zulu = TheWaypoint2.Time_Zulu_Weapon.Value.AddSeconds(0f - TheWaypoint2.Leg_Time_Weapon);
		}
		else
		{
			TheWaypoint2.Time_Zulu = TheWaypoint.Time_Zulu.Value.AddSeconds((0f - TheWaypoint2.Separation_Time) * 5f);
			TheWaypoint2.Time_Zulu_Weapon = null;
		}
		TheWaypoint2.TimeFixed = TheWaypoint.TimeFixed;
		LockWingmanTargetWaypoints_Core(theFlight, ref theMission, ref TheWaypoint2);
	}

	public static void LockWingmanTargetWaypoints_Core(Mission.Flight theFlight, ref Mission theMission, ref Waypoint TheWaypoint)
	{
		if ((TheWaypoint.Type != Waypoint.WaypointType.Target && TheWaypoint.Type != Waypoint.WaypointType.WeaponTarget) || !TheWaypoint.HasWingmanWaypoints())
		{
			return;
		}
		if (TheWaypoint.Waypoint_LeadElementWingman != null)
		{
			TheWaypoint.Waypoint_LeadElementWingman.TimeFixed = Waypoint.FixedFree.Relative;
			TheWaypoint.Waypoint_LeadElementWingman.Time_Zulu = TheWaypoint.Time_Zulu.Value.AddSeconds(TheWaypoint.Separation_Time);
			if (TheWaypoint.Time_Zulu_Weapon.HasValue)
			{
				TheWaypoint.Waypoint_LeadElementWingman.Time_Zulu_Weapon = TheWaypoint.Time_Zulu_Weapon.Value.AddSeconds(TheWaypoint.Separation_Time);
			}
			else
			{
				TheWaypoint.Waypoint_LeadElementWingman.Time_Zulu_Weapon = null;
			}
		}
		if (TheWaypoint.Waypoint_SecondElement != null)
		{
			TheWaypoint.Waypoint_SecondElement.TimeFixed = Waypoint.FixedFree.Relative;
			TheWaypoint.Waypoint_SecondElement.Time_Zulu = TheWaypoint.Time_Zulu.Value.AddSeconds(TheWaypoint.Separation_Time * 2f);
			if (TheWaypoint.Time_Zulu_Weapon.HasValue)
			{
				TheWaypoint.Waypoint_SecondElement.Time_Zulu_Weapon = TheWaypoint.Time_Zulu_Weapon.Value.AddSeconds(TheWaypoint.Separation_Time * 2f);
			}
			else
			{
				TheWaypoint.Waypoint_SecondElement.Time_Zulu_Weapon = null;
			}
		}
		if (TheWaypoint.Waypoint_SecondElementWingman != null)
		{
			TheWaypoint.Waypoint_SecondElementWingman.TimeFixed = Waypoint.FixedFree.Relative;
			TheWaypoint.Waypoint_SecondElementWingman.Time_Zulu = TheWaypoint.Time_Zulu.Value.AddSeconds(TheWaypoint.Separation_Time * 3f);
			if (TheWaypoint.Time_Zulu_Weapon.HasValue)
			{
				TheWaypoint.Waypoint_SecondElementWingman.Time_Zulu_Weapon = TheWaypoint.Time_Zulu_Weapon.Value.AddSeconds(TheWaypoint.Separation_Time * 3f);
			}
			else
			{
				TheWaypoint.Waypoint_SecondElementWingman.Time_Zulu_Weapon = null;
			}
		}
		if (TheWaypoint.Waypoint_ThirdElement != null)
		{
			TheWaypoint.Waypoint_ThirdElement.TimeFixed = Waypoint.FixedFree.Relative;
			TheWaypoint.Waypoint_ThirdElement.Time_Zulu = TheWaypoint.Time_Zulu.Value.AddSeconds(TheWaypoint.Separation_Time * 4f);
			if (!TheWaypoint.Time_Zulu_Weapon.HasValue)
			{
				TheWaypoint.Waypoint_ThirdElement.Time_Zulu_Weapon = null;
			}
			else
			{
				TheWaypoint.Waypoint_ThirdElement.Time_Zulu_Weapon = TheWaypoint.Time_Zulu_Weapon.Value.AddSeconds(TheWaypoint.Separation_Time * 4f);
			}
		}
		if (TheWaypoint.Waypoint_ThirdElementWingman != null)
		{
			TheWaypoint.Waypoint_ThirdElementWingman.TimeFixed = Waypoint.FixedFree.Relative;
			TheWaypoint.Waypoint_ThirdElementWingman.Time_Zulu = TheWaypoint.Time_Zulu.Value.AddSeconds(TheWaypoint.Separation_Time * 5f);
			if (!TheWaypoint.Time_Zulu_Weapon.HasValue)
			{
				TheWaypoint.Waypoint_ThirdElementWingman.Time_Zulu_Weapon = null;
			}
			else
			{
				TheWaypoint.Waypoint_ThirdElementWingman.Time_Zulu_Weapon = TheWaypoint.Time_Zulu_Weapon.Value.AddSeconds(TheWaypoint.Separation_Time * 5f);
			}
		}
	}

	public static void PopulateFlightsFollowingFlightSizes_Core(Scenario theScen, Side theSide, Mission theMission, Mission.Flight theFlight)
	{
		_Closure$__104-0 arg = default(_Closure$__104-0);
		_Closure$__104-0 CS$<>8__locals6 = new _Closure$__104-0(arg);
		CS$<>8__locals6.$VB$Local_theFlight = theFlight;
		int num = 0;
		List<ActiveUnit> list = (from x in Module_Mission.UnitsAssignedToMissionOrPackage(theMission, theScen)
			where Information.IsNothing((object)x.Navigator.get_Flight(HierarchySearch: true))
			select x).ToList();
		num = (from x in Module_Mission.UnitsAssignedToMissionOrPackage(theMission, theScen)
			where !Information.IsNothing((object)x.Navigator.get_Flight(HierarchySearch: true))
			where Operators.CompareString(x.Navigator.get_Flight(HierarchySearch: true).Callsign, CS$<>8__locals6.$VB$Local_theFlight.Callsign, false) == 0
			select x).Count();
		int num2 = list.Count - 1;
		for (int num3 = 0; num3 <= num2; num3++)
		{
			if ((from x in Module_Mission.UnitsAssignedToMissionOrPackage(theMission, theScen)
				where Information.IsNothing((object)x.Navigator.get_Flight(HierarchySearch: true))
				select x).Count() > 0)
			{
				if (!(num < CS$<>8__locals6.$VB$Local_theFlight.DesiredAircraftQty))
				{
					break;
				}
				(from x in Module_Mission.UnitsAssignedToMissionOrPackage(theMission, theScen)
					where Information.IsNothing((object)x.Navigator.get_Flight(HierarchySearch: true))
					select x).ToList().First().SetFlight(CS$<>8__locals6.$VB$Local_theFlight, num3);
				num++;
			}
		}
		if (num < CS$<>8__locals6.$VB$Local_theFlight.MinimumAircraftQty)
		{
			GameGeneral.SendMessageBoxToUI("Minimum flight number for flight " + CS$<>8__locals6.$VB$Local_theFlight.Callsign + " cannot be reached", theSide, "Minimum flight size not reached");
		}
	}

	public static void GenerateMissionFlightPlanSkeleton_Core(Scenario theScen, Side theSide, Mission theMission, Mission.Flight theFlight)
	{
		theFlight.DesiredAircraftQty = theMission.FlightSize;
		int num;
		if (!theMission.UseFlightSizeHardLimit)
		{
			theFlight.MinimumAircraftQty = 1;
			num = 0;
		}
		else
		{
			theFlight.MinimumAircraftQty = theMission.FlightSize;
			num = 0;
		}
		bool value = (byte)num != 0;
		bool AttemptPathfinderFlightPlan = false;
		bool separateIngressEgressPathfinderFlightPlans = false;
		bool aircraftIsAirborne = false;
		float FuelQtyRequired = 0f;
		Aircraft theAC = (Aircraft)theFlight.get_ReferenceUnit(theScen);
		bool mustUseTanker = false;
		float distanceFromAircraftToPatrolArea = 0f;
		Waypoint.TurnRateCategory theStationTurnRate = Waypoint.TurnRateCategory.DoubleStandardRateTurn;
		if (theFlight.DesiredAircraftQty > 6)
		{
			_ = (int)theFlight.DesiredAircraftQty;
			_ = (int)theFlight.MinimumAircraftQty;
			theFlight.DesiredAircraftQty = 6;
			theFlight.MinimumAircraftQty = 6;
		}
		bool? tankersFound = value;
		string FlightPlanFeedback = "";
		MissionPlanner.GenerateFlightPlan_Skeleton(ref theScen, ref theSide, ref theMission, ref theFlight, ref theAC, tankersFound, ref AttemptPathfinderFlightPlan, separateIngressEgressPathfinderFlightPlans, aircraftIsAirborne, ref FuelQtyRequired, ref FlightPlanFeedback, mustUseTanker, distanceFromAircraftToPatrolArea, theStationTurnRate, IsCreatedManually: true, theMission.TakeOffTime, theMission.TimeOnTarget, IsMFP: false);
		PopulateFlightsFollowingFlightSizes_Core(theScen, theSide, theMission, theFlight);
	}

	public static void GenerateMissionFlightPlanFull_Core(Scenario theScen, Side theSide, Mission theMission, Mission.Flight theFlight)
	{
		Aircraft theFlightPlanParent = (Aircraft)theFlight.get_ReferenceUnit(theScen);
		Doctrine._UseShootTourists? doctrine_ShootTourists = theMission.Doctrine.get_ShootTourists(theScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
		int num = 6;
		int num2 = 6;
		if (theFlight.DesiredAircraftQty > 6)
		{
			num = theFlight.DesiredAircraftQty;
			num2 = theFlight.MinimumAircraftQty;
			theFlight.DesiredAircraftQty = 6;
			theFlight.MinimumAircraftQty = 6;
		}
		string callsign = theFlight.Callsign;
		Mission._FlightSize desiredAircraftQty = theFlight.DesiredAircraftQty;
		Group theFlightPlanParentGroup = null;
		MissionPlanner.GenerateFlightPlan_ExistingFlight(ref theScen, ref theSide, theMission, isManual: true, isAirborne: false, ref theFlight, callsign, desiredAircraftQty, ref theFlightPlanParent, ref theFlightPlanParentGroup, theFlightPlanParent_HadFlight: true, doctrine_ShootTourists);
		if (theFlight.DesiredAircraftQty > num)
		{
			theFlight.DesiredAircraftQty = num;
			theFlight.MinimumAircraftQty = num2;
		}
		PopulateFlightsFollowingFlightSizes_Core(theScen, theSide, theMission, theFlight);
	}

	public static void ChangeFightPlanDeleteWaypoint_Core(Scenario theScen, Side theSide, Mission theMission, Mission.Flight theFlight, Mission.Flight.FlightElement theFlightElement, Waypoint theWaypoint)
	{
		if (theWaypoint == null)
		{
			return;
		}
		foreach (ActiveUnit unit in theSide.Units)
		{
			if (unit.Navigator.HasPlottedCourse())
			{
				if (unit.Navigator.PlottedCourse.Contains(theWaypoint))
				{
					unit.Navigator.RemoveWaypoint_Soft(theWaypoint, RemoveWingmanWaypoints: true);
				}
				else if (!Information.IsNothing((object)theWaypoint.Waypoint_LeadElementWingman) && unit.Navigator.PlottedCourse.Contains(theWaypoint.Waypoint_LeadElementWingman))
				{
					unit.Navigator.RemoveWaypoint_Soft(theWaypoint.Waypoint_LeadElementWingman, RemoveWingmanWaypoints: false);
				}
				else if (!Information.IsNothing((object)theWaypoint.Waypoint_SecondElement) && unit.Navigator.PlottedCourse.Contains(theWaypoint.Waypoint_SecondElement))
				{
					unit.Navigator.RemoveWaypoint_Soft(theWaypoint.Waypoint_SecondElement, RemoveWingmanWaypoints: false);
				}
				else if (!Information.IsNothing((object)theWaypoint.Waypoint_SecondElementWingman) && unit.Navigator.PlottedCourse.Contains(theWaypoint.Waypoint_SecondElementWingman))
				{
					unit.Navigator.RemoveWaypoint_Soft(theWaypoint.Waypoint_SecondElementWingman, RemoveWingmanWaypoints: false);
				}
				else if (!Information.IsNothing((object)theWaypoint.Waypoint_ThirdElement) && unit.Navigator.PlottedCourse.Contains(theWaypoint.Waypoint_ThirdElement))
				{
					unit.Navigator.RemoveWaypoint_Soft(theWaypoint.Waypoint_ThirdElement, RemoveWingmanWaypoints: false);
				}
				else if (!Information.IsNothing((object)theWaypoint.Waypoint_ThirdElementWingman) && unit.Navigator.PlottedCourse.Contains(theWaypoint.Waypoint_ThirdElementWingman))
				{
					unit.Navigator.RemoveWaypoint_Soft(theWaypoint.Waypoint_ThirdElementWingman, RemoveWingmanWaypoints: false);
				}
			}
		}
		ActiveUnit_Navigator.RemoveWaypoint_Hard(theScen, theMission, theFlight, theWaypoint);
	}

	public static void ChangeFightPlanInsertWaypoint_Core(Scenario theScen, Side theSide, Mission theMission, Mission.Flight theFlight, Mission.Flight.FlightElement theFlightElement, Waypoint thePreceedingWaypoint)
	{
		int num = theFlight.FlightPlan.Count();
		Waypoint.WaypointType waypointType = Waypoint.WaypointType.StrikeIngress;
		int num2 = num - 1;
		int i;
		for (i = 0; i <= num2; i++)
		{
			switch (theFlight.FlightPlan[i].Type)
			{
			case Waypoint.WaypointType.Split:
				waypointType = Waypoint.WaypointType.StrikeIngress;
				break;
			case Waypoint.WaypointType.StrikeIngress:
				waypointType = Waypoint.WaypointType.StrikeIngress;
				break;
			case Waypoint.WaypointType.StrikeEgress:
				waypointType = Waypoint.WaypointType.StrikeEgress;
				break;
			case Waypoint.WaypointType.InitialPoint:
			case Waypoint.WaypointType.Formate:
			case Waypoint.WaypointType.Target:
			case Waypoint.WaypointType.WeaponLaunch:
			case Waypoint.WaypointType.WeaponTarget:
				waypointType = Waypoint.WaypointType.StrikeEgress;
				break;
			}
			if (theFlight.FlightPlan[i] == thePreceedingWaypoint)
			{
				break;
			}
		}
		if (i >= num)
		{
			return;
		}
		int num3;
		Waypoint.WaypointType type;
		int assignObjectID;
		switch (thePreceedingWaypoint.Type)
		{
		default:
			num3 = 0;
			goto IL_0141;
		case Waypoint.WaypointType.ManualPlottedCourseWaypoint:
			type = Waypoint.WaypointType.ManualPlottedCourseWaypoint;
			assignObjectID = 1;
			break;
		case Waypoint.WaypointType.TurningPoint:
			type = Waypoint.WaypointType.TurningPoint;
			assignObjectID = 1;
			break;
		case Waypoint.WaypointType.StrikeIngress:
			type = Waypoint.WaypointType.StrikeIngress;
			assignObjectID = 1;
			break;
		case Waypoint.WaypointType.StrikeEgress:
			type = Waypoint.WaypointType.StrikeEgress;
			assignObjectID = 1;
			break;
		case Waypoint.WaypointType.InitialPoint:
		case Waypoint.WaypointType.Split:
		case Waypoint.WaypointType.WeaponLaunch:
			type = Waypoint.WaypointType.StrikeEgress;
			assignObjectID = 1;
			break;
		case Waypoint.WaypointType.Formate:
		case Waypoint.WaypointType.Target:
		case Waypoint.WaypointType.WeaponTarget:
			type = Waypoint.WaypointType.StrikeEgress;
			assignObjectID = 1;
			break;
		case Waypoint.WaypointType.TerminalPoint:
		case Waypoint.WaypointType.LocalizationRun:
		case Waypoint.WaypointType.PathfindingPoint:
		case Waypoint.WaypointType.PickupPoint:
			num3 = 0;
			goto IL_0141;
		case Waypoint.WaypointType.PatrolStation:
		case Waypoint.WaypointType.Assemble:
		case Waypoint.WaypointType.LandingMarshal:
		case Waypoint.WaypointType.Refuel:
		case Waypoint.WaypointType.TakeOff:
		case Waypoint.WaypointType.Marshal:
		case Waypoint.WaypointType.Land:
		case Waypoint.WaypointType.StationStart_Racetrack:
		case Waypoint.WaypointType.StationStart_FigureEight:
		case Waypoint.WaypointType.StationStart_Area:
		case Waypoint.WaypointType.StationStart_RaceTrackRandom:
		case Waypoint.WaypointType.StationEnd:
		case Waypoint.WaypointType.HoldStart:
		case Waypoint.WaypointType.HoldEnd:
			{
				if (!(theMission is Strike))
				{
					type = Waypoint.WaypointType.TurningPoint;
					assignObjectID = 1;
				}
				else
				{
					type = waypointType;
					assignObjectID = 1;
				}
				break;
			}
			IL_0141:
			type = (Waypoint.WaypointType)num3;
			assignObjectID = 1;
			break;
		}
		GeoPoint geoPoint = new GeoPoint((byte)assignObjectID != 0);
		GeoPoint geoPoint2 = new GeoPoint();
		GeoPoint geoPoint3 = new GeoPoint();
		GeoPoint geoPoint4 = new GeoPoint();
		GeoPoint geoPoint5 = new GeoPoint();
		GeoPoint geoPoint6 = new GeoPoint();
		if (i + 1 <= num - 1)
		{
			Waypoint waypoint = theFlight.FlightPlan[i + 1];
			double x = Math2.CalcAzimuth(thePreceedingWaypoint.Latitude, thePreceedingWaypoint.Longitude, waypoint.Latitude, waypoint.Longitude);
			double num4 = Math2.CalcDist(thePreceedingWaypoint.Latitude, thePreceedingWaypoint.Longitude, waypoint.Latitude, waypoint.Longitude);
			Waypoint waypoint2 = thePreceedingWaypoint;
			double Lon = waypoint2.Longitude;
			Waypoint waypoint3;
			double Lat = (waypoint3 = thePreceedingWaypoint).Latitude;
			GeoPoint geoPoint7;
			double out_lon = (geoPoint7 = geoPoint).Longitude;
			GeoPoint geoPoint8;
			double out_lat = (geoPoint8 = geoPoint).Latitude;
			double distance_NM = num4 / 2.0;
			double bearing = Math2.NormalizeBearing(x);
			Geodesic_EdWilliams.CalcPoint_Williams(ref Lon, ref Lat, ref out_lon, ref out_lat, ref distance_NM, ref bearing);
			geoPoint8.Latitude = out_lat;
			geoPoint7.Longitude = out_lon;
			waypoint3.Latitude = Lat;
			waypoint2.Longitude = Lon;
			if (thePreceedingWaypoint.Waypoint_LeadElementWingman != null)
			{
				Waypoint waypoint_LeadElementWingman = thePreceedingWaypoint.Waypoint_LeadElementWingman;
				Waypoint waypoint4 = ((waypoint.Waypoint_LeadElementWingman != null) ? waypoint.Waypoint_LeadElementWingman : waypoint);
				x = Math2.CalcAzimuth(waypoint_LeadElementWingman.Latitude, waypoint_LeadElementWingman.Longitude, waypoint4.Latitude, waypoint4.Longitude);
				num4 = Math2.CalcDist(waypoint_LeadElementWingman.Latitude, waypoint_LeadElementWingman.Longitude, waypoint4.Latitude, waypoint4.Longitude);
				bearing = waypoint_LeadElementWingman.Longitude;
				distance_NM = (waypoint3 = waypoint_LeadElementWingman).Latitude;
				out_lat = (geoPoint8 = geoPoint2).Longitude;
				out_lon = (geoPoint7 = geoPoint2).Latitude;
				Lat = num4 / 2.0;
				Lon = Math2.NormalizeBearing(x);
				Geodesic_EdWilliams.CalcPoint_Williams(ref bearing, ref distance_NM, ref out_lat, ref out_lon, ref Lat, ref Lon);
				geoPoint7.Latitude = out_lon;
				geoPoint8.Longitude = out_lat;
				waypoint3.Latitude = distance_NM;
				waypoint_LeadElementWingman.Longitude = bearing;
			}
			if (thePreceedingWaypoint.Waypoint_SecondElement != null)
			{
				Waypoint waypoint_SecondElement = thePreceedingWaypoint.Waypoint_SecondElement;
				Waypoint waypoint5 = ((waypoint.Waypoint_SecondElement != null) ? waypoint.Waypoint_SecondElement : waypoint);
				x = Math2.CalcAzimuth(waypoint_SecondElement.Latitude, waypoint_SecondElement.Longitude, waypoint5.Latitude, waypoint5.Longitude);
				num4 = Math2.CalcDist(waypoint_SecondElement.Latitude, waypoint_SecondElement.Longitude, waypoint5.Latitude, waypoint5.Longitude);
				Lon = waypoint_SecondElement.Longitude;
				Lat = (waypoint3 = waypoint_SecondElement).Latitude;
				out_lon = (geoPoint7 = geoPoint).Longitude;
				out_lat = (geoPoint8 = geoPoint).Latitude;
				distance_NM = num4 / 2.0;
				bearing = Math2.NormalizeBearing(x);
				Geodesic_EdWilliams.CalcPoint_Williams(ref Lon, ref Lat, ref out_lon, ref out_lat, ref distance_NM, ref bearing);
				geoPoint8.Latitude = out_lat;
				geoPoint7.Longitude = out_lon;
				waypoint3.Latitude = Lat;
				waypoint_SecondElement.Longitude = Lon;
			}
			if (thePreceedingWaypoint.Waypoint_SecondElementWingman != null)
			{
				Waypoint waypoint_SecondElement2 = thePreceedingWaypoint.Waypoint_SecondElement;
				Waypoint waypoint6 = ((waypoint.Waypoint_SecondElement == null) ? waypoint : waypoint.Waypoint_SecondElement);
				x = Math2.CalcAzimuth(waypoint_SecondElement2.Latitude, waypoint_SecondElement2.Longitude, waypoint6.Latitude, waypoint6.Longitude);
				num4 = Math2.CalcDist(waypoint_SecondElement2.Latitude, waypoint_SecondElement2.Longitude, waypoint6.Latitude, waypoint6.Longitude);
				bearing = waypoint_SecondElement2.Longitude;
				distance_NM = (waypoint3 = waypoint_SecondElement2).Latitude;
				out_lat = (geoPoint8 = geoPoint).Longitude;
				out_lon = (geoPoint7 = geoPoint).Latitude;
				Lat = num4 / 2.0;
				Lon = Math2.NormalizeBearing(x);
				Geodesic_EdWilliams.CalcPoint_Williams(ref bearing, ref distance_NM, ref out_lat, ref out_lon, ref Lat, ref Lon);
				geoPoint7.Latitude = out_lon;
				geoPoint8.Longitude = out_lat;
				waypoint3.Latitude = distance_NM;
				waypoint_SecondElement2.Longitude = bearing;
			}
			if (thePreceedingWaypoint.Waypoint_ThirdElement != null)
			{
				Waypoint waypoint_SecondElement3 = thePreceedingWaypoint.Waypoint_SecondElement;
				Waypoint waypoint7 = ((waypoint.Waypoint_SecondElement == null) ? waypoint : waypoint.Waypoint_SecondElement);
				x = Math2.CalcAzimuth(waypoint_SecondElement3.Latitude, waypoint_SecondElement3.Longitude, waypoint7.Latitude, waypoint7.Longitude);
				num4 = Math2.CalcDist(waypoint_SecondElement3.Latitude, waypoint_SecondElement3.Longitude, waypoint7.Latitude, waypoint7.Longitude);
				Lon = waypoint_SecondElement3.Longitude;
				Lat = (waypoint3 = waypoint_SecondElement3).Latitude;
				out_lon = (geoPoint7 = geoPoint).Longitude;
				out_lat = (geoPoint8 = geoPoint).Latitude;
				distance_NM = num4 / 2.0;
				bearing = Math2.NormalizeBearing(x);
				Geodesic_EdWilliams.CalcPoint_Williams(ref Lon, ref Lat, ref out_lon, ref out_lat, ref distance_NM, ref bearing);
				geoPoint8.Latitude = out_lat;
				geoPoint7.Longitude = out_lon;
				waypoint3.Latitude = Lat;
				waypoint_SecondElement3.Longitude = Lon;
			}
			if (thePreceedingWaypoint.Waypoint_ThirdElementWingman != null)
			{
				Waypoint waypoint_SecondElement4 = thePreceedingWaypoint.Waypoint_SecondElement;
				Waypoint waypoint8 = ((waypoint.Waypoint_SecondElement == null) ? waypoint : waypoint.Waypoint_SecondElement);
				x = Math2.CalcAzimuth(waypoint_SecondElement4.Latitude, waypoint_SecondElement4.Longitude, waypoint8.Latitude, waypoint8.Longitude);
				num4 = Math2.CalcDist(waypoint_SecondElement4.Latitude, waypoint_SecondElement4.Longitude, waypoint8.Latitude, waypoint8.Longitude);
				bearing = waypoint_SecondElement4.Longitude;
				distance_NM = (waypoint3 = waypoint_SecondElement4).Latitude;
				out_lat = (geoPoint8 = geoPoint).Longitude;
				out_lon = (geoPoint7 = geoPoint).Latitude;
				Lat = num4 / 2.0;
				Lon = Math2.NormalizeBearing(x);
				Geodesic_EdWilliams.CalcPoint_Williams(ref bearing, ref distance_NM, ref out_lat, ref out_lon, ref Lat, ref Lon);
				geoPoint7.Latitude = out_lon;
				geoPoint8.Longitude = out_lat;
				waypoint3.Latitude = distance_NM;
				waypoint_SecondElement4.Longitude = bearing;
			}
		}
		else
		{
			Waypoint waypoint9 = thePreceedingWaypoint;
			double Lon = waypoint9.Longitude;
			Waypoint waypoint3;
			double Lat = (waypoint3 = thePreceedingWaypoint).Latitude;
			GeoPoint geoPoint7;
			double out_lon = (geoPoint7 = geoPoint).Longitude;
			GeoPoint geoPoint8;
			double out_lat = (geoPoint8 = geoPoint).Latitude;
			int distance_NM2 = 10;
			int bearing2 = 0;
			Geodesic_EdWilliams.CalcPoint_Williams(ref Lon, ref Lat, ref out_lon, ref out_lat, ref distance_NM2, ref bearing2);
			geoPoint8.Latitude = out_lat;
			geoPoint7.Longitude = out_lon;
			waypoint3.Latitude = Lat;
			waypoint9.Longitude = Lon;
			if (thePreceedingWaypoint.Waypoint_LeadElementWingman != null)
			{
				Waypoint waypoint_LeadElementWingman2 = thePreceedingWaypoint.Waypoint_LeadElementWingman;
				out_lat = waypoint_LeadElementWingman2.Longitude;
				out_lon = (waypoint3 = thePreceedingWaypoint.Waypoint_LeadElementWingman).Latitude;
				Lat = (geoPoint8 = geoPoint).Longitude;
				Lon = (geoPoint7 = geoPoint).Latitude;
				bearing2 = 10;
				distance_NM2 = 0;
				Geodesic_EdWilliams.CalcPoint_Williams(ref out_lat, ref out_lon, ref Lat, ref Lon, ref bearing2, ref distance_NM2);
				geoPoint7.Latitude = Lon;
				geoPoint8.Longitude = Lat;
				waypoint3.Latitude = out_lon;
				waypoint_LeadElementWingman2.Longitude = out_lat;
			}
			if (thePreceedingWaypoint.Waypoint_SecondElement != null)
			{
				Waypoint waypoint_SecondElement5 = thePreceedingWaypoint.Waypoint_SecondElement;
				Lon = waypoint_SecondElement5.Longitude;
				Lat = (waypoint3 = thePreceedingWaypoint.Waypoint_SecondElement).Latitude;
				out_lon = (geoPoint7 = geoPoint).Longitude;
				out_lat = (geoPoint8 = geoPoint).Latitude;
				distance_NM2 = 10;
				bearing2 = 0;
				Geodesic_EdWilliams.CalcPoint_Williams(ref Lon, ref Lat, ref out_lon, ref out_lat, ref distance_NM2, ref bearing2);
				geoPoint8.Latitude = out_lat;
				geoPoint7.Longitude = out_lon;
				waypoint3.Latitude = Lat;
				waypoint_SecondElement5.Longitude = Lon;
			}
			if (thePreceedingWaypoint.Waypoint_SecondElementWingman != null)
			{
				Waypoint waypoint_SecondElementWingman = thePreceedingWaypoint.Waypoint_SecondElementWingman;
				out_lat = waypoint_SecondElementWingman.Longitude;
				out_lon = (waypoint3 = thePreceedingWaypoint.Waypoint_SecondElementWingman).Latitude;
				Lat = (geoPoint8 = geoPoint).Longitude;
				Lon = (geoPoint7 = geoPoint).Latitude;
				bearing2 = 10;
				distance_NM2 = 0;
				Geodesic_EdWilliams.CalcPoint_Williams(ref out_lat, ref out_lon, ref Lat, ref Lon, ref bearing2, ref distance_NM2);
				geoPoint7.Latitude = Lon;
				geoPoint8.Longitude = Lat;
				waypoint3.Latitude = out_lon;
				waypoint_SecondElementWingman.Longitude = out_lat;
			}
			if (thePreceedingWaypoint.Waypoint_ThirdElement != null)
			{
				Waypoint waypoint_ThirdElement = thePreceedingWaypoint.Waypoint_ThirdElement;
				Lon = waypoint_ThirdElement.Longitude;
				Lat = (waypoint3 = thePreceedingWaypoint.Waypoint_ThirdElement).Latitude;
				out_lon = (geoPoint7 = geoPoint).Longitude;
				out_lat = (geoPoint8 = geoPoint).Latitude;
				distance_NM2 = 10;
				bearing2 = 0;
				Geodesic_EdWilliams.CalcPoint_Williams(ref Lon, ref Lat, ref out_lon, ref out_lat, ref distance_NM2, ref bearing2);
				geoPoint8.Latitude = out_lat;
				geoPoint7.Longitude = out_lon;
				waypoint3.Latitude = Lat;
				waypoint_ThirdElement.Longitude = Lon;
			}
			if (thePreceedingWaypoint.Waypoint_ThirdElementWingman != null)
			{
				Waypoint waypoint_ThirdElementWingman = thePreceedingWaypoint.Waypoint_ThirdElementWingman;
				out_lat = waypoint_ThirdElementWingman.Longitude;
				out_lon = (waypoint3 = thePreceedingWaypoint.Waypoint_ThirdElementWingman).Latitude;
				Lat = (geoPoint8 = geoPoint).Longitude;
				Lon = (geoPoint7 = geoPoint).Latitude;
				bearing2 = 10;
				distance_NM2 = 0;
				Geodesic_EdWilliams.CalcPoint_Williams(ref out_lat, ref out_lon, ref Lat, ref Lon, ref bearing2, ref distance_NM2);
				geoPoint7.Latitude = Lon;
				geoPoint8.Longitude = Lat;
				waypoint3.Latitude = out_lon;
				waypoint_ThirdElementWingman.Longitude = out_lat;
			}
		}
		Doctrine FlightLeadDoctrine = null;
		Waypoint waypoint10 = Waypoint.CopyWaypoint(ref theScen, ref thePreceedingWaypoint, CopyWingmanWaypoints: true, CopyFlightplanPointsList: false, ref FlightLeadDoctrine);
		waypoint10.Type = type;
		waypoint10.Latitude = geoPoint.Latitude;
		waypoint10.Longitude = geoPoint.Longitude;
		waypoint10.Hold_Time = 0f;
		waypoint10.Station_Time = 0f;
		waypoint10.SpacingManeuver_Time = 0f;
		if (waypoint10.Waypoint_LeadElementWingman != null)
		{
			Waypoint waypoint_LeadElementWingman3 = waypoint10.Waypoint_LeadElementWingman;
			waypoint_LeadElementWingman3.Type = type;
			waypoint_LeadElementWingman3.Latitude = geoPoint2.Latitude;
			waypoint_LeadElementWingman3.Longitude = geoPoint2.Longitude;
		}
		if (waypoint10.Waypoint_SecondElement != null)
		{
			Waypoint waypoint_SecondElement6 = waypoint10.Waypoint_SecondElement;
			waypoint_SecondElement6.Type = type;
			waypoint_SecondElement6.Latitude = geoPoint3.Latitude;
			waypoint_SecondElement6.Longitude = geoPoint3.Longitude;
		}
		if (waypoint10.Waypoint_SecondElementWingman != null)
		{
			Waypoint waypoint_SecondElementWingman2 = waypoint10.Waypoint_SecondElementWingman;
			waypoint_SecondElementWingman2.Type = type;
			waypoint_SecondElementWingman2.Latitude = geoPoint4.Latitude;
			waypoint_SecondElementWingman2.Longitude = geoPoint4.Longitude;
		}
		if (waypoint10.Waypoint_ThirdElement != null)
		{
			Waypoint waypoint_ThirdElement2 = waypoint10.Waypoint_ThirdElement;
			waypoint_ThirdElement2.Type = type;
			waypoint_ThirdElement2.Latitude = geoPoint5.Latitude;
			waypoint_ThirdElement2.Longitude = geoPoint5.Longitude;
		}
		if (waypoint10.Waypoint_ThirdElementWingman != null)
		{
			Waypoint waypoint_ThirdElementWingman2 = waypoint10.Waypoint_ThirdElementWingman;
			waypoint_ThirdElementWingman2.Type = type;
			waypoint_ThirdElementWingman2.Latitude = geoPoint6.Latitude;
			waypoint_ThirdElementWingman2.Longitude = geoPoint6.Longitude;
		}
		Waypoint[] theFlightPlan = theFlight.FlightPlan;
		ActiveUnit_Navigator.AddWaypoint(ref theFlightPlan, i + 1, waypoint10);
		theFlight.FlightPlan = theFlightPlan;
		Scenario theScen2 = theScen;
		ActiveUnit theAU = theFlight.get_ReferenceUnit(theScen);
		Mission.Flight flight;
		theFlightPlan = (flight = theFlight).FlightPlan;
		float NecessaryFuel = 0f;
		float MissionFuel = 0f;
		MissionPlanner.CalculateFuelQtyAndTimes_And_CheckIfEnoughFuelForFlightPlan(theScen2, theMission, theAU, theFlight, ref theFlightPlan, ref NecessaryFuel, ref MissionFuel, RangeCheck: false, RunValidation: true, RunFreeSpeedChecks: true, SetWaypointTimes: true, NewFlightPlan: false, EditLeadWaypoints: true, EditWingmanWaypoints: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, AircraftIsAirborne: false, BananaSplitRedSection: false, theMission.TakeOffTime, theMission.TimeOnTarget, IsMFP: false);
		flight.FlightPlan = theFlightPlan;
		bool flag = false;
		for (i = theScen.ActiveUnits_List.Count - 1; i >= 0; i += -1)
		{
			ActiveUnit activeUnit = theScen.ActiveUnits_List[i];
			if (Information.IsNothing((object)activeUnit) || !activeUnit.IsOperating())
			{
				continue;
			}
			if (!activeUnit.IsAircraft && (!activeUnit.IsGroup || ((Group)activeUnit).Type != Group.GroupType.AirGroup))
			{
				goto IL_0c7b;
			}
			int num5;
			if (!activeUnit.Navigator.HasFlightPlan)
			{
				num5 = 0;
			}
			else
			{
				if (activeUnit.get_UnitSide(SetSideOnly: false) != theSide)
				{
					goto IL_0c7b;
				}
				int distance_NM2 = activeUnit.Navigator.PlottedCourse.Count() - 1;
				int num6 = 0;
				while (true)
				{
					if (num6 <= distance_NM2)
					{
						if (activeUnit.Navigator.PlottedCourse[num6] == thePreceedingWaypoint && num6 >= 0)
						{
							ActiveUnit_Navigator navigator = activeUnit.Navigator;
							theFlightPlan = navigator.PlottedCourse;
							ActiveUnit_Navigator.AddWaypoint(ref theFlightPlan, num6 + 1, waypoint10);
							navigator.PlottedCourse = theFlightPlan;
							flag = true;
						}
						if (!flag)
						{
							num6++;
							continue;
						}
						num5 = 0;
						break;
					}
					num5 = 0;
					break;
				}
			}
			goto IL_0c7c;
			IL_0c7b:
			num5 = 0;
			goto IL_0c7c;
			IL_0c7c:
			flag = (byte)num5 != 0;
		}
	}

	public static void ChangeFlightPlanWaypointType_Core(Scenario theScen, Side theSide, Mission theMission, Mission.Flight theFlight, Mission.Flight.FlightElement theFlightElement, Waypoint theWaypoint, Waypoint.WaypointType theWayPointType, Waypoint theNextWaypoint, bool RefuelAtWaypointOnly)
	{
		bool flag = true;
		switch (theWayPointType)
		{
		case Waypoint.WaypointType.LandingMarshal:
		case Waypoint.WaypointType.TakeOff:
		case Waypoint.WaypointType.Land:
			theWaypoint.Type = theWayPointType;
			flag = false;
			break;
		case Waypoint.WaypointType.StationStart_Racetrack:
		case Waypoint.WaypointType.StationStart_FigureEight:
		case Waypoint.WaypointType.StationStart_Area:
		case Waypoint.WaypointType.StationStart_RaceTrackRandom:
			theWaypoint.Type = theWayPointType;
			theWaypoint.TurnRate_Navigation = Waypoint.TurnRateCategory.HalfStandardRateTurn;
			if (theFlight.get_ReferenceUnit(theScen) != null)
			{
				theWaypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Loiter;
				theWaypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
				if (theWaypoint.TerrainFollowing && theWaypoint.DesiredAltitude_TerrainFollowing.HasValue)
				{
					theWaypoint.DesiredSpeed = theFlight.get_ReferenceUnit(theScen).Kinematics.GetMaximumSpeed(theWaypoint.DesiredAltitude_TerrainFollowing.Value, (ActiveUnit.Throttle)theWaypoint.ThrottlePreset, ValidateAndFixAltitude: false);
				}
				else
				{
					theWaypoint.DesiredSpeed = theFlight.get_ReferenceUnit(theScen).Kinematics.GetMaximumSpeed(theWaypoint.DesiredAltitude.Value, (ActiveUnit.Throttle)theWaypoint.ThrottlePreset, ValidateAndFixAltitude: false);
				}
				theWaypoint.DesiredSpeedOverride = null;
			}
			if (theNextWaypoint != null)
			{
				theNextWaypoint.Type = Waypoint.WaypointType.StationEnd;
			}
			break;
		default:
			if ((theWaypoint.IsHoldStartWaypoint() || theWaypoint.IsStationStartWaypoint()) && theFlight.get_ReferenceUnit(theScen) != null)
			{
				theWaypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Cruise;
				theWaypoint.SpeedFixed = Waypoint.FixedFree.Free;
				if (theWaypoint.TerrainFollowing && theWaypoint.DesiredAltitude_TerrainFollowing.HasValue)
				{
					theWaypoint.DesiredSpeed = theFlight.get_ReferenceUnit(theScen).Kinematics.GetMaximumSpeed(theWaypoint.DesiredAltitude_TerrainFollowing.Value, (ActiveUnit.Throttle)theWaypoint.ThrottlePreset, ValidateAndFixAltitude: false);
				}
				else
				{
					theWaypoint.DesiredSpeed = theFlight.get_ReferenceUnit(theScen).Kinematics.GetMaximumSpeed(theWaypoint.DesiredAltitude.Value, (ActiveUnit.Throttle)theWaypoint.ThrottlePreset, ValidateAndFixAltitude: false);
				}
				theWaypoint.DesiredSpeedOverride = null;
			}
			theWaypoint.Type = theWayPointType;
			switch (theWayPointType)
			{
			case Waypoint.WaypointType.Assemble:
				theWaypoint.Hold_Time = 600f;
				break;
			case Waypoint.WaypointType.Refuel:
			{
				theWaypoint.GetDoctrine(theScen).set_UseReplenishment(theScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false, (Doctrine._UseUnderwayRefuelAndReplenishment?)Doctrine._UseUnderwayRefuelAndReplenishment.Always_IncludingTankersRefuellingTankers);
				if (!RefuelAtWaypointOnly)
				{
					break;
				}
				Waypoint[] flightPlan = theFlight.FlightPlan;
				foreach (Waypoint waypoint in flightPlan)
				{
					if (waypoint.Type != Waypoint.WaypointType.Refuel)
					{
						waypoint.GetDoctrine(theScen).set_UseReplenishment(theScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false, (Doctrine._UseUnderwayRefuelAndReplenishment?)Doctrine._UseUnderwayRefuelAndReplenishment.Never);
					}
				}
				break;
			}
			}
			if (theNextWaypoint == null)
			{
				break;
			}
			if (theNextWaypoint.Type == Waypoint.WaypointType.StationEnd)
			{
				theNextWaypoint.Type = Waypoint.WaypointType.TurningPoint;
				theNextWaypoint.Station_Time = 0f;
				theNextWaypoint.Hold_Time = 0f;
				theNextWaypoint.TimeFixed = Waypoint.FixedFree.Free;
				theNextWaypoint.TurnRate_Navigation = Waypoint.TurnRateCategory.DoubleStandardRateTurn;
			}
			else if (theNextWaypoint.Type == Waypoint.WaypointType.HoldEnd)
			{
				switch (theWayPointType)
				{
				case Waypoint.WaypointType.StrikeIngress:
					theNextWaypoint.Type = Waypoint.WaypointType.StrikeIngress;
					break;
				case Waypoint.WaypointType.StrikeEgress:
					theNextWaypoint.Type = Waypoint.WaypointType.StrikeEgress;
					break;
				default:
					theNextWaypoint.Type = Waypoint.WaypointType.TurningPoint;
					break;
				}
				theNextWaypoint.Station_Time = 0f;
				theNextWaypoint.Hold_Time = 0f;
				theNextWaypoint.TimeFixed = Waypoint.FixedFree.Free;
				theNextWaypoint.TurnRate_Navigation = Waypoint.TurnRateCategory.DoubleStandardRateTurn;
			}
			break;
		case Waypoint.WaypointType.HoldStart:
			theWaypoint.Type = theWayPointType;
			theWaypoint.TurnRate_Navigation = Waypoint.TurnRateCategory.StandardRateTurn;
			if (theFlight.get_ReferenceUnit(theScen) != null)
			{
				theWaypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Loiter;
				theWaypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
				if (theWaypoint.TerrainFollowing && theWaypoint.DesiredAltitude_TerrainFollowing.HasValue)
				{
					theWaypoint.DesiredSpeed = theFlight.get_ReferenceUnit(theScen).Kinematics.GetMaximumSpeed(theWaypoint.DesiredAltitude_TerrainFollowing.Value, (ActiveUnit.Throttle)theWaypoint.ThrottlePreset, ValidateAndFixAltitude: false);
				}
				else
				{
					theWaypoint.DesiredSpeed = theFlight.get_ReferenceUnit(theScen).Kinematics.GetMaximumSpeed(theWaypoint.DesiredAltitude.Value, (ActiveUnit.Throttle)theWaypoint.ThrottlePreset, ValidateAndFixAltitude: false);
				}
				theWaypoint.DesiredSpeedOverride = null;
			}
			if (theNextWaypoint != null)
			{
				theNextWaypoint.Type = Waypoint.WaypointType.HoldEnd;
				theNextWaypoint.Hold_Time = 600f;
			}
			break;
		case Waypoint.WaypointType.StationEnd:
		case Waypoint.WaypointType.HoldEnd:
			return;
		}
		if (theWaypoint.Type != Waypoint.WaypointType.Assemble && theWaypoint.Type != Waypoint.WaypointType.HoldEnd && theWaypoint.Hold_Time > 0f)
		{
			theWaypoint.Hold_Time = 0f;
		}
		if (theWaypoint.Waypoint_LeadElementWingman != null)
		{
			theWaypoint.Waypoint_LeadElementWingman.Type = theWaypoint.Type;
		}
		if (theWaypoint.Waypoint_SecondElement != null)
		{
			theWaypoint.Waypoint_SecondElement.Type = theWaypoint.Type;
		}
		if (theWaypoint.Waypoint_SecondElementWingman != null)
		{
			theWaypoint.Waypoint_SecondElementWingman.Type = theWaypoint.Type;
		}
		if (theWaypoint.Waypoint_ThirdElement != null)
		{
			theWaypoint.Waypoint_ThirdElement.Type = theWaypoint.Type;
		}
		if (theWaypoint.Waypoint_ThirdElementWingman != null)
		{
			theWaypoint.Waypoint_ThirdElementWingman.Type = theWaypoint.Type;
		}
		if (flag)
		{
			ActiveUnit theAU = theFlight.get_ReferenceUnit(theScen);
			Mission.Flight flight;
			Waypoint[] theFlightplan = (flight = theFlight).FlightPlan;
			float NecessaryFuel = 0f;
			float MissionFuel = 0f;
			MissionPlanner.CalculateFuelQtyAndTimes_And_CheckIfEnoughFuelForFlightPlan(theScen, theMission, theAU, theFlight, ref theFlightplan, ref NecessaryFuel, ref MissionFuel, RangeCheck: false, RunValidation: true, RunFreeSpeedChecks: true, SetWaypointTimes: true, NewFlightPlan: false, EditLeadWaypoints: true, EditWingmanWaypoints: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, AircraftIsAirborne: false, BananaSplitRedSection: false, theMission.TakeOffTime, theMission.TimeOnTarget, IsMFP: false);
			flight.FlightPlan = theFlightplan;
		}
	}

	public static void ChangeFlightPlanWaypointFormation_Core(Scenario theScen, Side theSide, Mission theMission, Mission.Flight theFlight, Mission.Flight.FlightElement theFlightElement, Waypoint theWaypoint, Waypoint.Formation theFormation, Waypoint theNextWaypoint, Waypoint thePreviousWaypoint)
	{
		theWaypoint.FlightFormation = theFormation;
		if (theWaypoint.FlightFormation == Waypoint.Formation.Split)
		{
			theWaypoint.SplitWaypoint(ref theScen, ref theFlight.DesiredAircraftQty, ref thePreviousWaypoint, ref theNextWaypoint, OverwriteExistingWingmanWaypoints: true);
		}
		else
		{
			theWaypoint.FormateWaypoint(ref thePreviousWaypoint, ref theNextWaypoint);
		}
	}

	public static void ChangeFlightPlanWaypointTurnRate_Core(Scenario theScen, Side theSide, Mission theMission, Mission.Flight theFlight, Mission.Flight.FlightElement theFlightElement, Waypoint theWaypoint, Waypoint.TurnRateCategory theTurnRate)
	{
		theWaypoint.TurnRate_Navigation = theTurnRate;
		ActiveUnit theAU = theFlight.get_ReferenceUnit(theScen);
		Mission.Flight flight;
		Waypoint[] theFlightplan = (flight = theFlight).FlightPlan;
		float NecessaryFuel = 0f;
		float MissionFuel = 0f;
		MissionPlanner.CalculateFuelQtyAndTimes_And_CheckIfEnoughFuelForFlightPlan(theScen, theMission, theAU, theFlight, ref theFlightplan, ref NecessaryFuel, ref MissionFuel, RangeCheck: false, RunValidation: true, RunFreeSpeedChecks: true, SetWaypointTimes: true, NewFlightPlan: false, EditLeadWaypoints: true, EditWingmanWaypoints: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, AircraftIsAirborne: false, BananaSplitRedSection: false, theMission.TakeOffTime, theMission.TimeOnTarget, IsMFP: false);
		flight.FlightPlan = theFlightplan;
	}

	public static void ChangeFlightPlanWaypointDoctrineAARUsage_Core(Scenario theScen, Side theSide, Mission theMission, Mission.Flight theFlight, Mission.Flight.FlightElement theFlightElement, Waypoint theWaypoint, int theUsage)
	{
		theWaypoint.GetDoctrine(theScen).set_UseReplenishment(theScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false, (Doctrine._UseUnderwayRefuelAndReplenishment?)(Doctrine._UseUnderwayRefuelAndReplenishment)theUsage);
		ActiveUnit theAU = theFlight.get_ReferenceUnit(theScen);
		Mission.Flight flight;
		Waypoint[] theFlightplan = (flight = theFlight).FlightPlan;
		float NecessaryFuel = 0f;
		float MissionFuel = 0f;
		MissionPlanner.CalculateFuelQtyAndTimes_And_CheckIfEnoughFuelForFlightPlan(theScen, theMission, theAU, theFlight, ref theFlightplan, ref NecessaryFuel, ref MissionFuel, RangeCheck: false, RunValidation: true, RunFreeSpeedChecks: true, SetWaypointTimes: true, NewFlightPlan: false, EditLeadWaypoints: true, EditWingmanWaypoints: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, AircraftIsAirborne: false, BananaSplitRedSection: false, theMission.TakeOffTime, theMission.TimeOnTarget, IsMFP: false);
		flight.FlightPlan = theFlightplan;
	}

	public static void ChangeFlightPlanWaypointDoctrineAARSelection_Core(Scenario theScen, Side theSide, Mission theMission, Mission.Flight theFlight, Mission.Flight.FlightElement theFlightElement, Waypoint theWaypoint, int theSelection)
	{
		theWaypoint.GetDoctrine(theScen).set_ReplenishmentSelection(theScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false, (Doctrine._UnderwayRefuelAndReplenishmentSelection?)(Doctrine._UnderwayRefuelAndReplenishmentSelection)theSelection);
		ActiveUnit theAU = theFlight.get_ReferenceUnit(theScen);
		Mission.Flight flight;
		Waypoint[] theFlightplan = (flight = theFlight).FlightPlan;
		float NecessaryFuel = 0f;
		float MissionFuel = 0f;
		MissionPlanner.CalculateFuelQtyAndTimes_And_CheckIfEnoughFuelForFlightPlan(theScen, theMission, theAU, theFlight, ref theFlightplan, ref NecessaryFuel, ref MissionFuel, RangeCheck: false, RunValidation: true, RunFreeSpeedChecks: true, SetWaypointTimes: true, NewFlightPlan: false, EditLeadWaypoints: true, EditWingmanWaypoints: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, AircraftIsAirborne: false, BananaSplitRedSection: false, theMission.TakeOffTime, theMission.TimeOnTarget, IsMFP: false);
		flight.FlightPlan = theFlightplan;
	}

	static CoreClientCode()
	{
		Class72.smethod_20();
	}
}
