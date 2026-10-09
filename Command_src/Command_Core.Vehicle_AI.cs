using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using Collections.Pooled;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Vehicle_AI : ActiveUnit_AI
{
	private Vehicle vehicle_0;

	[SpecialName]
	private Vehicle ejwLfgOrlVD()
	{
		if (vehicle_0 == null)
		{
			vehicle_0 = (Vehicle)myUnit;
		}
		return vehicle_0;
	}

	public static Vehicle_AI FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_034f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0356: Expected O, but got Unknown
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		Vehicle_AI result;
		try
		{
			Vehicle_AI vehicle_AI = new Vehicle_AI(ref theAU);
			vehicle_AI.myUnit = theAU;
			if (Operators.CompareString(theNode.ChildNodes[0].Name, "ActiveUnit_AI", false) == 0)
			{
				theNode = theNode.ChildNodes[0];
			}
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "PrimaryTarget":
				case "PTarget":
					vehicle_AI._PrimaryTarget = Contact.FromXML(val.InnerText, ref theDictionary);
					break;
				case "MSF":
					uint.TryParse(val.InnerText, out vehicle_AI._Mission_State_Flags);
					break;
				case "Threats":
					if (vehicle_AI._Threats == null)
					{
						vehicle_AI._Threats = new List<Contact>();
					}
					foreach (XmlNode childNode2 in val.ChildNodes)
					{
						XmlNode theNode2 = childNode2;
						Contact item = Contact.FromXML(ref theNode2, ref theDictionary);
						vehicle_AI._Threats.Add(item);
					}
					break;
				case "TTNPTE":
					vehicle_AI.TimeToNextTargetsEvaluation = XmlConvert.ToSingle(val.InnerText.Replace(",", "."));
					break;
				case "IE":
					vehicle_AI.IsEscort = true;
					break;
				case "PrimaryThreat":
				case "PThreat":
					vehicle_AI._PrimaryThreat = Contact.FromXML(val.InnerText, ref theDictionary);
					break;
				case "PrimaryTarget_LastKnown_Lon":
					vehicle_AI.PrimaryTarget_LastKnown_Lon = XmlConvert.ToDouble(val.InnerText);
					break;
				case "TargetList":
					foreach (XmlNode childNode3 in val.ChildNodes)
					{
						XmlNode theNode3 = childNode3;
						TargetingEntry targetingEntry = TargetingEntry.FromXML(ref theNode3, ref theDictionary);
						if (targetingEntry.Target != null)
						{
							if (vehicle_AI._TargetList == null)
							{
								vehicle_AI._TargetList = new ObservableDictionary<string, TargetingEntry>();
							}
							if (!vehicle_AI._TargetList.ContainsKey(targetingEntry.Target.ObjectID))
							{
								vehicle_AI._TargetList.Add(targetingEntry.Target.ObjectID, targetingEntry);
							}
						}
					}
					break;
				case "PrimaryTarget_LastKnown_Lat":
					vehicle_AI.PrimaryTarget_LastKnown_Lat = XmlConvert.ToDouble(val.InnerText);
					break;
				case "HP":
				case "HPos":
					vehicle_AI.HoldPosition = Misc.ParseBool(val.InnerText);
					break;
				case "PrimaryTarget_LastKnown_Alt":
					vehicle_AI.PrimaryTarget_LastKnown_Altitude = XmlConvert.ToSingle(val.InnerText);
					break;
				case "IgnorePlottedCourse":
				case "IPC":
				{
					bool num = Misc.ParseBool(val.InnerText);
					if (!Information.IsNothing((object)theAU.Doctrine))
					{
						theAU.Doctrine.set_IgnorePlottedCourse(theAU.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._UseIgnorePlottedCourse?)(Doctrine._UseIgnorePlottedCourse)(0u - (Misc.ParseBool(val.InnerText) ? 1u : 0u)));
					}
					if (num && !Information.IsNothing((object)theAU.ActiveMissionOrPackage()))
					{
						Mission mission = theAU.ActiveMissionOrPackage();
						if (mission.MissionClass == Mission._MissionClass.Patrol)
						{
							mission.Doctrine.set_IgnorePlottedCourse(theAU.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._UseIgnorePlottedCourse?)Doctrine._UseIgnorePlottedCourse.Yes);
						}
					}
					break;
				}
				case "PTOE":
				case "PrimaryTargetOverrideExists":
					vehicle_AI.PrimaryTargetOverrideExists = Misc.ParseBool(val.InnerText);
					break;
				}
			}
			result = vehicle_AI;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100545", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Vehicle_AI(ref theAU);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public Vehicle_AI(ref ActiveUnit theUnit)
		: base(theUnit)
	{
	}

	public FuelRec._FuelType SelectFuelTypeToConsume(Engine theEngine)
	{
		switch (theEngine.Type)
		{
		default:
			return FuelRec._FuelType.NoFuel;
		case Engine.EngineType.AIP:
			if (myUnit.Propulsion.Where([SpecialName] (Engine theE) => theE.Type == Engine.EngineType.Electric).Count() == 0)
			{
				return FuelRec._FuelType.Battery;
			}
			return FuelRec._FuelType.AirIndepedent;
		case Engine.EngineType.Electric:
			return FuelRec._FuelType.Battery;
		case Engine.EngineType.Diesel:
			return FuelRec._FuelType.DieselFuel;
		}
	}

	internal void SelectEngines()
	{
		if (myUnit == null || myUnit.Propulsion.Count == 0)
		{
			return;
		}
		new Dictionary<int, Engine>();
		if (myUnit.Propulsion.Count == 1)
		{
			ejwLfgOrlVD().PrimaryEngine = myUnit.Propulsion[0];
		}
		try
		{
			if (Module_Unit.IsOverLand(ejwLfgOrlVD()))
			{
				Engine engine = myUnit.Propulsion.Where([SpecialName] (Engine theE) => theE.CanBeUsedOverland()).FirstOrDefault();
				if (engine != null)
				{
					ejwLfgOrlVD().PrimaryEngine = engine;
				}
			}
			else
			{
				Engine engine2 = myUnit.Propulsion.Where([SpecialName] (Engine theE) => theE.CanBeUsedOnWater()).FirstOrDefault();
				if (engine2 != null)
				{
					ejwLfgOrlVD().PrimaryEngine = engine2;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100812", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private bool method_12()
	{
		int result;
		if (!myUnit.IsGroupMember())
		{
			result = 0;
		}
		else
		{
			List<ActiveUnit> list = new List<ActiveUnit>();
			List<ActiveUnit> list2 = new List<ActiveUnit>();
			foreach (ActiveUnit value in myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values)
			{
				if (value != null && value != myUnit)
				{
					switch (value.DesignatedSupplier)
					{
					case ActiveUnit_DockingOps.ResupplyCapacity.Fuel:
						list.Add(value);
						break;
					case ActiveUnit_DockingOps.ResupplyCapacity.Material:
						list2.Add(value);
						break;
					case ActiveUnit_DockingOps.ResupplyCapacity.FuelAndMaterial:
						list.Add(value);
						list2.Add(value);
						break;
					}
				}
			}
			double TotalCurrent = default(double);
			double TotalMax = default(double);
			if (list.Count > 0 && (int)Math.Round(myUnit.FuelPercent(ref TotalCurrent, ref TotalMax, MissionFuel: false) * 100.0) < 5)
			{
				foreach (ActiveUnit item in list)
				{
					if (myUnit.DockingOps.AttemptToScheduleUNREP(myUnit.AI.IntermediateTargetPointForRefuelCalcs(), item, null, IsManualOrder: false, null, ActiveUnit_DockingOps.ResupplyRequest.Fuel).Result == ActiveUnit_DockingOps.ResultOfAttemptToScheduleUNREP.Success)
					{
						myUnit.Status = ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint;
						myUnit.AddMessage(myUnit.Name + " is automatically refueling from group member " + item.Name + " (Reason: Fuel exhausted). ", "Unit refueling", LoggedMessage.MessageType.DockingOps, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
						return true;
					}
				}
			}
			if (list2.Count > 0)
			{
				Weapon weapon = myUnit.Weaponry.PrimaryAttackWeapon_Default;
				if (weapon == null || myUnit.Weaponry.TotalAvailableInventoryForThisWeapon(weapon.DBID, IncludeNonOperationalMountsAndMags: false) > 0)
				{
					weapon = myUnit.Weaponry.PrimaryDefenceWeapon_Default;
				}
				if (weapon == null)
				{
					result = 0;
					goto IL_0331;
				}
				if (myUnit.Weaponry.TotalAvailableInventoryForThisWeapon(weapon.DBID, IncludeNonOperationalMountsAndMags: false) == 0)
				{
					foreach (ActiveUnit item2 in list2)
					{
						if (item2.Weaponry.TotalAvailableInventoryForThisWeapon(weapon.DBID, IncludeNonOperationalMountsAndMags: false) > 0 && myUnit.DockingOps.AttemptToScheduleUNREP(myUnit.AI.IntermediateTargetPointForRefuelCalcs(), item2, null, IsManualOrder: false, null, ActiveUnit_DockingOps.ResupplyRequest.Material).Result == ActiveUnit_DockingOps.ResultOfAttemptToScheduleUNREP.Success)
						{
							myUnit.Status = ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint;
							myUnit.AddMessage(myUnit.Name + " is automatically re-arming from group member " + item2.Name + " (Reason: " + weapon.Name + " ammunition exhausted). ", "Unit re-arming", LoggedMessage.MessageType.DockingOps, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
							return true;
						}
					}
				}
			}
			result = 0;
		}
		goto IL_0331;
		IL_0331:
		return (byte)result != 0;
	}

	public override void EvaluateUnitStatus(float elapsedTime, bool ForceFuelStateCheck, bool ForceWeaponStateCheck)
	{
		if (myUnit == null)
		{
			return;
		}
		try
		{
			EvaluateUnitCargoStatus(elapsedTime);
			if (myUnit.IsDrone() && myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DroneAutonomyLevels))
			{
				ActiveUnit.DroneAutonomyLevel autonomyLevel = myUnit.AutonomyLevel;
				if (autonomyLevel < ActiveUnit.DroneAutonomyLevel.SelfRecovering)
				{
					if (myUnit.CommStuff.TimeOffComms > 0f)
					{
						return;
					}
				}
				else if (autonomyLevel < ActiveUnit.DroneAutonomyLevel.ChangeableMission)
				{
					if (myUnit.CommStuff.TimeOffComms > 0f)
					{
						if (myUnit.CommStuff.TimeOffComms <= 30f)
						{
							myUnit.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.HoldingPattern_CommsLost;
							return;
						}
						myUnit.Status = ActiveUnit._ActiveUnitStatus.RTB_CommsLost;
						myUnit.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.RTB;
						return;
					}
					if (myUnit.Status == ActiveUnit._ActiveUnitStatus.RTB_CommsLost)
					{
						myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
						myUnit.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.Underway;
					}
				}
			}
			byte? b = (byte?)myUnit.Doctrine.get_AutoEvade(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
			{
				if (_PrimaryThreat != null)
				{
					myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedDefensive;
					return;
				}
				if (myUnit.Status == ActiveUnit._ActiveUnitStatus.EngagedDefensive)
				{
					myUnit.Status = myUnit._StatusBefore_EngagedDefensive;
				}
			}
			if (myUnit.Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint || myUnit.Status == ActiveUnit._ActiveUnitStatus.Refuelling || myUnit.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.TransferringCargo || myUnit.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.TransferringMissionCargo || myUnit.IsRTB || (ejwLfgOrlVD().IsMobileGroundUnit && myUnit.ParentScen.FifteenthSecondIsChangingOnThisPulse && !myUnit.IsRTB && (CheckForWithdrawalCriteria() || method_12())))
			{
				return;
			}
			if (myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
			{
				bool? obj;
				if (Information.IsNothing((object)PrimaryTarget))
				{
					obj = false;
				}
				else
				{
					b = (byte?)myUnit.Doctrine.get_IgnorePlottedCourse(myUnit.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false);
					obj = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
				}
				bool? flag = obj;
				if (((!flag) ?? flag) == true)
				{
					myUnit.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
					return;
				}
			}
			bool flag2;
			if (PrimaryTarget != null)
			{
				Contact_Base.ContactType type = PrimaryTarget.Type;
				if (type > Contact_Base.ContactType.Missile)
				{
					flag2 = true;
					if (!Information.IsNothing((object)myUnit.ActiveMissionOrPackage()) && myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
					{
						Strike strike = (Strike)myUnit.ActiveMissionOrPackage();
						if (strike.MaxResponseRadius_Ship > 0 || strike.MinResponseRadius_Ship > 0)
						{
							float num = Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null));
							int num2;
							if (strike.MaxResponseRadius_Ship > 0 && !(num <= (float)strike.MaxResponseRadius_Ship))
							{
								num2 = 0;
							}
							else
							{
								if (strike.MinResponseRadius_Ship <= 0 || !(num < (float)strike.MinResponseRadius_Ship))
								{
									goto IL_041c;
								}
								num2 = 0;
							}
							flag2 = (byte)num2 != 0;
						}
					}
					goto IL_041c;
				}
			}
			goto IL_0431;
			IL_041c:
			if (flag2)
			{
				myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
				return;
			}
			goto IL_0431;
			IL_0431:
			if (myUnit.IsGroupMember())
			{
				if (myUnit.get_ParentGroup(UsingMissionPlanner: false).Type == Group.GroupType.AirGroup && myUnit.get_ParentGroup(UsingMissionPlanner: false).Status == ActiveUnit._ActiveUnitStatus.FormingUp)
				{
					myUnit.Status = ActiveUnit._ActiveUnitStatus.FormingUp;
					return;
				}
				if (myUnit.Status == ActiveUnit._ActiveUnitStatus.FormingUp)
				{
					EvaluateTargets(elapsedTime, IgnoreContacStance: false, Immediately: true);
				}
			}
			if (myUnit.ActiveMissionOrPackage() != null && myUnit.ActiveMissionOrPackage().IsActive && myUnit.Status != ActiveUnit._ActiveUnitStatus.RTB_MissionOver)
			{
				switch (myUnit.ActiveMissionOrPackage().MissionClass)
				{
				case Mission._MissionClass.Strike:
					myUnit.Status = ActiveUnit._ActiveUnitStatus.Tasked;
					return;
				case Mission._MissionClass.Patrol:
					CheckIfReachedPatrolAreaThiSortie();
					myUnit.Status = ActiveUnit._ActiveUnitStatus.OnPatrol;
					return;
				case Mission._MissionClass.Support:
					if (!Information.IsNothing((object)PrimaryTarget))
					{
						myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
					}
					else
					{
						myUnit.Status = ActiveUnit._ActiveUnitStatus.OnSupportMission;
					}
					return;
				case Mission._MissionClass.Cargo:
					myUnit.Status = ActiveUnit._ActiveUnitStatus.Tasked;
					return;
				case Mission._MissionClass.ArtyFireMission:
					myUnit.Status = ActiveUnit._ActiveUnitStatus.OnFireMission;
					return;
				}
				myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
			}
			if (myUnit.Status == ActiveUnit._ActiveUnitStatus.RTB_MissionOver || myUnit.FuelState == ActiveUnit._ActiveUnitFuelState.IgnoreBingoAndJoker || myUnit.WeaponState == ActiveUnit._ActiveUnitWeaponState.IgnoreWinchesterAndShotgun)
			{
				return;
			}
			if (base.PrimaryPickupTarget != null)
			{
				if (myUnit.Navigator.HasPlottedCourse())
				{
					ActiveUnit_Navigator navigator = myUnit.Navigator;
					double startLat = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
					double startLon = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
					double latitude = myUnit.Navigator.PlottedCourse[0].Latitude;
					double longitude = myUnit.Navigator.PlottedCourse[0].Longitude;
					int ReasonForInterrupt = 0;
					GeoPoint InterruptLocation = null;
					if (navigator.PathLineIsInterrupted(startLat, startLon, latitude, longitude, RunInParallel: false, 0f, CheckIfCurrentlyInsideIllegalArea: false, null, IsPathfindingQuery: false, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: true, null, ref ReasonForInterrupt, ref InterruptLocation))
					{
						myUnit.Navigator.PlotCourseToPickupPoint();
						if (!myUnit.Navigator.HasPlottedCourse())
						{
							myUnit.AddMessage(myUnit.Name + " is unable to reach cargo pick up target " + base.PrimaryPickupTarget.Name, "Cannot pick up cargo", LoggedMessage.MessageType.UI, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
							myUnit.AI.RemovePickupTarget(base.PrimaryPickupTarget.ObjectID);
						}
					}
				}
				else if (myUnit.RangeToUnit_Horiz(base.PrimaryPickupTarget) < 2f)
				{
					myUnit.DockingOps.SettleForCargoTransfer();
				}
				else
				{
					myUnit.Navigator.PlotCourseToPickupPoint();
					if (myUnit.Navigator.HasPlottedCourse())
					{
						myUnit.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
						return;
					}
					myUnit.AddMessage(myUnit.Name + " is unable to reach cargo pick up target " + base.PrimaryPickupTarget.Name, "Cannot pick up cargo", LoggedMessage.MessageType.UI, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
					myUnit.AI.RemovePickupTarget(base.PrimaryPickupTarget.ObjectID);
				}
			}
			if (myUnit.Status != ActiveUnit._ActiveUnitStatus.Unassigned)
			{
				myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200346", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private Weapon[] method_13()
	{
		return myUnit.Weaponry.AllDistinctWeaponsAboard_Actual().ToArray();
	}

	public override void EvaluateTargets(float elapsedTime, bool IgnoreContacStance, bool Immediately)
	{
		if (myUnit == null)
		{
			return;
		}
		try
		{
			if (myUnit.IsDrone() && myUnit.AutonomyLevel < ActiveUnit.DroneAutonomyLevel.BattlespaceCognizant && myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DroneAutonomyLevels) && !myUnit.CommStuff.IsConnectedToSideNetwork)
			{
				return;
			}
			if (myUnit.Mounts.Count == 0 && myUnit.Sensors_Cached.Length == 0)
			{
				if (!Information.IsNothing((object)PrimaryTarget))
				{
					DropTarget(PrimaryTarget);
				}
				if (base.Targets_ReadOnly.Length <= 0)
				{
					return;
				}
				PooledList<Contact> pooledList = new PooledList<Contact>();
				Contact[] targets_ReadOnly = base.Targets_ReadOnly;
				foreach (Contact item in targets_ReadOnly)
				{
					pooledList.Add(item);
				}
				foreach (Contact item2 in pooledList)
				{
					DropTarget(item2);
					Contact current = null;
				}
				pooledList.Dispose();
				return;
			}
			base.EvaluateTargets(elapsedTime, IgnoreContacStance, Immediately);
			if (myUnit == null || (myUnit.IsFixedFacility && myUnit.Mounts.Count == 0))
			{
				return;
			}
			_SelfDefenceTargets.Clear();
			Mission mission = myUnit.ActiveMissionOrPackage();
			List<Weapon> list = myUnit.Weaponry.AllDistinctWeaponsAboard_Actual();
			Weapon weapon = default(Weapon);
			Weapon weapon2 = default(Weapon);
			Weapon weapon3 = default(Weapon);
			Weapon weapon4 = default(Weapon);
			foreach (Weapon item3 in list)
			{
				if (!Information.IsNothing((object)weapon))
				{
					if (item3.MaxAirRange > weapon.MaxAirRange)
					{
						weapon = item3;
					}
				}
				else if (item3.MaxAirRange > 0f)
				{
					weapon = item3;
				}
				if (Information.IsNothing((object)weapon2))
				{
					if (item3.MaxSurfaceRange > 0f)
					{
						weapon2 = item3;
					}
				}
				else if (item3.MaxSurfaceRange > weapon2.MaxSurfaceRange)
				{
					weapon2 = item3;
				}
				if (!Information.IsNothing((object)weapon3))
				{
					if (item3.MaxLandRange > weapon3.MaxLandRange)
					{
						weapon3 = item3;
					}
				}
				else if (item3.MaxLandRange > 0f)
				{
					weapon3 = item3;
				}
				if (Information.IsNothing((object)weapon4))
				{
					if (item3.MaxSubsurfaceRange > 0f)
					{
						weapon4 = item3;
					}
				}
				else if (item3.MaxSubsurfaceRange > weapon4.MaxSubsurfaceRange)
				{
					weapon4 = item3;
				}
			}
			if (Information.IsNothing((object)weapon) && Information.IsNothing((object)weapon2) && Information.IsNothing((object)weapon4) && Information.IsNothing((object)weapon3) && (myUnit.IsFixedFacility || HoldPosition))
			{
				return;
			}
			_ = base.Targets_ReadOnly;
			bool isInsidePatrolArea_10nmBuffer = base.IsInsidePatrolArea_10nmBuffer;
			List<Weapon> list2 = new List<Weapon>();
			list2.AddRange(method_13());
			Doctrine._UseShootTourists? useShootTourists = myUnit.Doctrine.get_ShootTourists(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
			if (theContactsVisibleToMe == null)
			{
				theContactsVisibleToMe = Module_ActiveUnit_Sensory.ContactsVisibleToMe(myUnit.Sensory);
			}
			int count = theContactsVisibleToMe.Count;
			int FeedbackSeverity;
			if (mission != null && mission.IsActive)
			{
				int num = count - 1;
				for (int j = 0; j <= num; j++)
				{
					Contact current = theContactsVisibleToMe[j];
					if (_DoNotTargetList.Contains(current))
					{
						continue;
					}
					bool? flag = ((current.IDStatus < Contact_Base.IdentificationStatus.KnownType) ? new bool?(false) : current.ActualUnit?.IsWeapon);
					if ((flag ?? true) && ((Weapon)current.ActualUnit).IsMobileDecoy && flag.HasValue)
					{
						bool flag2 = false;
						Sensor[] sensors_Cached = current.ActualUnit.Sensors_Cached;
						for (int k = 0; k < sensors_Cached.Length; k = checked(k + 1))
						{
							if (sensors_Cached[k].IsOECM)
							{
								flag2 = true;
								break;
							}
						}
						if (!flag2)
						{
							continue;
						}
					}
					if ((!Immediately && current.Type != Contact_Base.ContactType.Missile && (current.Type != Contact_Base.ContactType.Air || !myUnit.ParentScen.FifthSecondIsChangingOnThisPulse) && !myUnit.ParentScen.FifteenthSecondIsChangingOnThisPulse) || (_TargetList != null && _TargetList.ContainsKey(current.ObjectID)) || new bool?(current.get_IsDestroyed(myUnit.ParentScen)) == true)
					{
						continue;
					}
					byte? b = (byte?)current.BDA_StructuralIntegrity;
					if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 4)) == true)
					{
						continue;
					}
					Misc.PostureStance contactsStance_Cache = GetContactsStance_Cache(current, j);
					Contact theContact = current;
					Doctrine._UseShootTourists? canShootTourists = useShootTourists;
					Misc.PostureStance? contactStance = contactsStance_Cache;
					string Feedback = "";
					FeedbackSeverity = 0;
					if (!ContactIsRelevantToFlightOrMission(theContact, mission, canShootTourists, IgnoreContacStance, isInsidePatrolArea_10nmBuffer, IgnoreNeutralContacts: true, contactStance, ref Feedback, ref FeedbackSeverity))
					{
						continue;
					}
					switch (contactsStance_Cache)
					{
					case Misc.PostureStance.Unfriendly:
					case Misc.PostureStance.Hostile:
						if (!IsContactTooAmbiguousForEvaluation(current) && (current.Type != Contact_Base.ContactType.Submarine || (!current.IsClassifiedFalseTarget && !SeaIceProvider.PointIsUnderIce(((Module_Unit.Unit)current).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)current).get_Latitude((GlobalVariables.BooleanObject)null)))))
						{
							ActiveUnit_Weaponry weaponry = myUnit.Weaponry;
							Contact theTarget = current;
							Doctrine doctrine = myUnit.Doctrine;
							Feedback = null;
							FeedbackSeverity = 0;
							if (weaponry.HaveAvailableWeaponSuitableForThisTarget(theTarget, CheckWRA: true, doctrine, ref Feedback, ref FeedbackSeverity, HumanFeedBackNeeded: false, list2))
							{
								TargetThisContact(current, AddedManually: false, PriorityTarget: false, TargetingEntry._TargetingBehavior.AutoTargeted);
							}
						}
						break;
					case Misc.PostureStance.Unknown:
						TargetThisContact(current, AddedManually: false, PriorityTarget: false, TargetingEntry._TargetingBehavior.AutoTargeted);
						break;
					}
				}
			}
			if (myUnit.IsOnActivePatrol())
			{
				Patrol patrol = (Patrol)mission;
				GlobalVariables.PatrolType type = patrol.Type;
				if (type <= GlobalVariables.PatrolType.ASuW_Naval || type - 3 <= GlobalVariables.PatrolType.ASuW_Land)
				{
					if (patrol.get_InvestigateWithinWeaponRange(myUnit.ParentScen))
					{
						weapon2 = myUnit.Weaponry.GetLongestRange_ASWeapon(ExcludeICBMs: false);
						weapon3 = myUnit.Weaponry.GetLongestRange_AGWeapon(ExcludeICBMs: false);
					}
					else
					{
						weapon2 = null;
						weapon3 = null;
					}
				}
			}
			bool flag3 = myUnit.IsOnActivePatrol() && ((Patrol)mission).HasProsecutionArea;
			ObservableDictionary<string, TargetingEntry> targetList = _TargetList;
			FeedbackSeverity = count - 1;
			for (int l = 0; l <= FeedbackSeverity; l++)
			{
				Contact current = theContactsVisibleToMe[l];
				if (_DoNotTargetList.Contains(current) || myUnit == null || current == null || (_TargetList != null && _TargetList.ContainsKey(current.ObjectID)))
				{
					continue;
				}
				Misc.PostureStance contactsStance_Cache2 = GetContactsStance_Cache(current, l);
				if (contactsStance_Cache2 == Misc.PostureStance.Neutral || contactsStance_Cache2 == Misc.PostureStance.Friendly)
				{
					continue;
				}
				bool? flag = ((current.IDStatus < Contact_Base.IdentificationStatus.KnownType) ? new bool?(false) : current.ActualUnit?.IsWeapon);
				if ((flag ?? true) && ((Weapon)current.ActualUnit).IsMobileDecoy && flag.HasValue)
				{
					bool flag4 = false;
					Sensor[] sensors_Cached2 = current.ActualUnit.Sensors_Cached;
					for (int m = 0; m < sensors_Cached2.Length; m = checked(m + 1))
					{
						if (sensors_Cached2[m].IsOECM)
						{
							flag4 = true;
							break;
						}
					}
					if (!flag4)
					{
						continue;
					}
				}
				byte? b = (byte?)current.BDA_StructuralIntegrity;
				if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 4)) == true)
				{
					continue;
				}
				if (myUnit.Weaponry.ContactIsWithinSelfDefenceRange(current))
				{
					_SelfDefenceTargets.Add(current);
				}
				if (!flag3 && mission != null && mission.IsActive && mission.MissionClass == Mission._MissionClass.Patrol && !current.IsAir_Missile_Submarine_Contact && !((Patrol)mission).get_InvestigateOutsidePatrolArea(myUnit.ParentScen))
				{
					Patrol patrol2 = (Patrol)mission;
					if (!((Module_Unit.Unit)current).get_IsInsideThisArea(patrol2.PatrolArea, myUnit.ParentScen, UseCache: true) && TargetingBehaviorForThisTarget(current, targetList) != TargetingEntry._TargetingBehavior.ManualWeaponAlloc && !myUnit.Sensory.IsIlluminatingThisContact(current))
					{
						continue;
					}
				}
				new bool?(current.get_IsDestroyed(myUnit.ParentScen));
				if (TargetIsEligibleBasedOnWeaponRange(current, contactsStance_Cache2, useShootTourists.HasValue, useShootTourists.Value, weapon, weapon2, weapon3, weapon4))
				{
					ActiveUnit_Weaponry weaponry2 = myUnit.Weaponry;
					Contact theTarget2 = current;
					Doctrine doctrine2 = myUnit.Doctrine;
					string Feedback = null;
					int FeedbackSeverity2 = 0;
					if (weaponry2.HaveAvailableWeaponSuitableForThisTarget(theTarget2, CheckWRA: true, doctrine2, ref Feedback, ref FeedbackSeverity2, HumanFeedBackNeeded: false, list2) && !DropTargetDueToRearwardFiringDoctrine(current))
					{
						TargetThisContact(current, AddedManually: false, PriorityTarget: false, TargetingEntry._TargetingBehavior.AutoTargeted);
					}
				}
			}
			foreach (Contact selfDefenceTarget in _SelfDefenceTargets)
			{
				if (_TargetList == null || (!_TargetList.ContainsKey(selfDefenceTarget.ObjectID) && !_DoNotTargetList.Contains(selfDefenceTarget)))
				{
					TargetThisContact(selfDefenceTarget, AddedManually: false, PriorityTarget: false, TargetingEntry._TargetingBehavior.AutoSelfDefence);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100547", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private bool method_14(Weapon weapon_0)
	{
		int result;
		if (weapon_0 != null)
		{
			IMobileGroundUnit._MobileUnitCategory mobileUnitCategory = ejwLfgOrlVD().MobileUnitCategory;
			if (mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.AAA && mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.SAM)
			{
				goto IL_0078;
			}
			if (weapon_0.ValidTargets.MobileTarget_Hard)
			{
				result = 1;
			}
			else
			{
				if (weapon_0.ValidTargets.MobileTarget_Soft)
				{
					goto IL_00ec;
				}
				if (weapon_0.ValidTargets.MobileTarget_Personnel)
				{
					result = 1;
				}
				else
				{
					if (weapon_0.ValidTargets.LandStructure_Hard)
					{
						goto IL_00ec;
					}
					if (!weapon_0.ValidTargets.LandStructure_Soft)
					{
						goto IL_0078;
					}
					result = 1;
				}
			}
			goto IL_00ed;
		}
		return false;
		IL_00c3:
		int result2;
		if (weapon_0.ValidTargets.Radar)
		{
			if (myUnit.HasRadarSensor)
			{
				return true;
			}
			result2 = 0;
		}
		else
		{
			result2 = 0;
		}
		return (byte)result2 != 0;
		IL_0078:
		if (ejwLfgOrlVD().IsHardTarget)
		{
			if (weapon_0.ValidTargets.MobileTarget_Hard)
			{
				return true;
			}
			goto IL_00c3;
		}
		int result3;
		if (!weapon_0.ValidTargets.MobileTarget_Hard)
		{
			if (weapon_0.ValidTargets.MobileTarget_Soft)
			{
				result3 = 1;
			}
			else
			{
				if (!weapon_0.ValidTargets.MobileTarget_Personnel)
				{
					goto IL_00c3;
				}
				result3 = 1;
			}
		}
		else
		{
			result3 = 1;
		}
		return (byte)result3 != 0;
		IL_00ec:
		result = 1;
		goto IL_00ed;
		IL_00ed:
		return (byte)result != 0;
	}

	public override void EvaluateThreats(float elapsedTime)
	{
		if (myUnit == null || myUnit.IsFixedFacility || HoldPosition || (myUnit.IsDrone() && myUnit.AutonomyLevel < ActiveUnit.DroneAutonomyLevel.BattlespaceCognizant && myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DroneAutonomyLevels) && !myUnit.CommStuff.IsConnectedToSideNetwork))
		{
			return;
		}
		try
		{
			ClearAllNonImminentThreats(elapsedTime);
			List<Weapon> availableWeapons = null;
			bool flag = false;
			if (theContactsVisibleToMe == null)
			{
				theContactsVisibleToMe = Module_ActiveUnit_Sensory.ContactsVisibleToMe(myUnit.Sensory);
			}
			int num = Module_ActiveUnit_Sensory.ContactsVisibleToMe(myUnit.Sensory).Count - 1;
			Contact contact;
			ActiveUnit actualUnit;
			Misc.PostureStance value;
			Weapon longestRange_AAWeapon;
			for (int i = 0; i <= num; i++)
			{
				contact = theContactsVisibleToMe[i];
				if (contact == null)
				{
					continue;
				}
				actualUnit = contact.ActualUnit;
				if (actualUnit == null)
				{
					continue;
				}
				if ((actualUnit.IsVehicle || actualUnit.IsFacility || actualUnit.IsAggregatedUnit) && contact.IDStatus >= Contact_Base.IdentificationStatus.KnownType)
				{
					if (ContactStanceCache[i].Item1 == null)
					{
						if (!myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactStancesOnThisPulse.TryGetValue(contact.ObjectID, out value))
						{
							value = contact.get_Stance(myUnit.get_UnitSide(SetSideOnly: false));
							myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactStancesOnThisPulse.AddIfNotExists(contact.ObjectID, value);
						}
					}
					else
					{
						value = ContactStanceCache[i].Item2;
					}
					if (value == Misc.PostureStance.Hostile && (double)Module_Unit.RangeToUnit_Slant(myUnit, contact, 0f, GlobalVariables.ObjectTrue) < 5.0)
					{
						AddContactToThreatList(contact);
					}
				}
				else
				{
					if (!actualUnit.IsWeapon)
					{
						continue;
					}
					value = GetContactsStance_Cache(contact, i);
					if (value == Misc.PostureStance.Friendly || !method_14((Weapon)actualUnit))
					{
						continue;
					}
					AddContactToThreatList(contact);
					if (_TargetList != null && _TargetList.ContainsKey(contact.ObjectID))
					{
						continue;
					}
					Weapon._WeaponType type = ((Weapon)actualUnit).Type;
					if (type != Weapon._WeaponType.GuidedWeapon)
					{
						continue;
					}
					longestRange_AAWeapon = myUnit.Weaponry.GetLongestRange_AAWeapon(contact);
					if (longestRange_AAWeapon != null)
					{
						if (!flag)
						{
							availableWeapons = myUnit.Weaponry.AllDistinctWeaponsAboard_Actual();
							flag = true;
						}
						ActiveUnit_Weaponry weaponry = myUnit.Weaponry;
						Contact theTarget = contact;
						Doctrine doctrine = myUnit.Doctrine;
						string Feedback = null;
						int FeedbackSeverity = 0;
						if (weaponry.HaveAvailableWeaponSuitableForThisTarget(theTarget, CheckWRA: true, doctrine, ref Feedback, ref FeedbackSeverity, HumanFeedBackNeeded: false, availableWeapons) && (double)Module_Unit.RangeToUnit_Slant(myUnit, contact) < 1.5 * (double)longestRange_AAWeapon.MaxAirRange)
						{
							TargetThisContact(contact, AddedManually: false, PriorityTarget: false, TargetingEntry._TargetingBehavior.AutoTargeted);
						}
					}
				}
			}
			availableWeapons = null;
			contact = null;
			actualUnit = null;
			value = Misc.PostureStance.Neutral;
			longestRange_AAWeapon = null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100548", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void EngageTargets(float elapsedTime)
	{
		if (myUnit == null)
		{
			return;
		}
		try
		{
			if (ejwLfgOrlVD().CanFireOnTheMove || (int)Math.Round(ejwLfgOrlVD().CurrentSpeed) <= 0)
			{
				base.EngageTargets(elapsedTime);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100549", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void MaintainStandoff(float elapsedTime)
	{
		try
		{
			Doctrine doctrine = myUnit.Doctrine;
			Weapon weapon = myUnit.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, CheckIfWithinRange: false, CheckIfWithinAltitude: false, CheckWRA: true, doctrine);
			if (Information.IsNothing((object)weapon))
			{
				return;
			}
			float num = myUnit.RangeToUnit_Horiz(PrimaryTarget);
			float num2 = weapon.get_MaxRangeForThisTarget(myUnit, PrimaryTarget, CheckWRA: true, doctrine, ManualFire: false);
			float num3 = num / num2;
			float num4 = 0.8f;
			switch (ejwLfgOrlVD().MobileUnitCategory)
			{
			case IMobileGroundUnit._MobileUnitCategory.Infantry:
			case IMobileGroundUnit._MobileUnitCategory.Armor:
			case IMobileGroundUnit._MobileUnitCategory.MechInfantry:
				num4 = 0.5f;
				break;
			case IMobileGroundUnit._MobileUnitCategory.Artillery_Gun:
			case IMobileGroundUnit._MobileUnitCategory.Artillery_Towed:
			case IMobileGroundUnit._MobileUnitCategory.Artillery_SSM:
				num4 = 0.95f;
				break;
			}
			if (num3 > num4)
			{
				myUnit.Kinematics.DesiredSpeedOverride = null;
				if ((int)myUnit.ThrottleSetting < 3)
				{
					myUnit.SetThrottle(ActiveUnit.Throttle.Full);
				}
				ManouverTowardsTarget(elapsedTime);
			}
			else
			{
				myUnit.SetThrottle(ActiveUnit.Throttle.FullStop);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100550", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private bool method_15()
	{
		if (myUnit.Status != ActiveUnit._ActiveUnitStatus.EngagedOffensive && !ejwLfgOrlVD().CanFireOnTheMove && _TargetList != null)
		{
			Doctrine._UseShootTourists? useShootTourists = myUnit.Doctrine.get_ShootTourists(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
			int result;
			if (!useShootTourists.HasValue)
			{
				result = 0;
			}
			else
			{
				byte? b = (byte?)useShootTourists;
				if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
				{
					foreach (KeyValuePair<string, TargetingEntry> target in _TargetList)
					{
						if (myUnit.Weaponry.MostSuitableWeaponForThisTarget(target.Value.Target, CheckIfWithinRange: true, CheckIfWithinAltitude: true, CheckWRA: true, myUnit.Doctrine) != null)
						{
							return true;
						}
					}
				}
				result = 0;
			}
			return (byte)result != 0;
		}
		return false;
	}

	public override void DetermineDesiredAttitudeAndThrottle(float elapsedTime, bool RecalculatePlottedCourse = true)
	{
		if (myUnit == null)
		{
			return;
		}
		try
		{
			myUnit.Navigator.IsManouveringToFormationStation = false;
			if (myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DroneAutonomyLevels))
			{
				if (myUnit.IsDrone() && myUnit.AutonomyLevel < ActiveUnit.DroneAutonomyLevel.SelfRecovering && myUnit.CommStuff.TimeOffComms > 0f)
				{
					return;
				}
			}
			else if (myUnit.IsDrone() && !myUnit.CommStuff.IsConnectedToSideNetwork && !myUnit.IsRTB)
			{
				myUnit.Kinematics.Loiter(elapsedTime);
				return;
			}
			if (myUnit.IsFixedFacility || HoldPosition)
			{
				return;
			}
			if (myUnit.DockingOps.Condition != ActiveUnit_DockingOps._DockingOpsCondition.TransferringCargo && myUnit.DockingOps.Condition != ActiveUnit_DockingOps._DockingOpsCondition.TransferringMissionCargo)
			{
				switch (myUnit.Status)
				{
				case ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint:
				{
					bool flag = true;
					GeoPoint intermediateTargetPoint = IntermediateTargetPointForRefuelCalcs();
					ActiveUnit_DockingOps dockingOps = myUnit.DockingOps;
					string UserFeedback = "";
					List<ActiveUnit> potentialUNREPunits = dockingOps.GetPotentialUNREPunits(MustBeAbleToReachItDirectly: true, null, ref UserFeedback, ActiveUnit_DockingOps.ResupplyRequest.FuelOrMaterial);
					if (myUnit.ParentScen.MinuteIsChangingOnThisPulse || myUnit.DockingOps.UNREP_Destination == null)
					{
						if (myUnit.DockingOps.UNREP_Destination != null && potentialUNREPunits.Contains(myUnit.DockingOps.UNREP_Destination))
						{
							flag = myUnit.DockingOps.AttemptToRendezvousWithTanker(myUnit.DockingOps.UNREP_Destination) == ActiveUnit_DockingOps.ResultOfAttemptToRendezvousWithTanker.Success || myUnit.DockingOps.AttemptToScheduleUNREP(intermediateTargetPoint, null, null, IsManualOrder: false).Result == ActiveUnit_DockingOps.ResultOfAttemptToScheduleUNREP.Success;
						}
						else if (potentialUNREPunits.Count > 0)
						{
							flag = myUnit.DockingOps.AttemptToScheduleUNREP(intermediateTargetPoint, null, null, IsManualOrder: false, 100).Result == ActiveUnit_DockingOps.ResultOfAttemptToScheduleUNREP.Success;
						}
						else
						{
							int num;
							if (myUnit.DockingOps.UNREP_Destination != null)
							{
								myUnit.DockingOps.DisconnectFromSupplier();
								num = 0;
							}
							else
							{
								num = 0;
							}
							flag = (byte)num != 0;
						}
					}
					if (myUnit.DockingOps.UNREP_Destination != null && flag)
					{
						ActiveUnit uNREP_Destination = myUnit.DockingOps.UNREP_Destination;
						if (myUnit.IsGroupLead() && uNREP_Destination.IsGroupMember() && myUnit.get_ParentGroup(UsingMissionPlanner: false) == uNREP_Destination.get_ParentGroup(UsingMissionPlanner: false) && !uNREP_Destination.IsFixedFacility)
						{
							uNREP_Destination.set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Module_Unit.BearingToUnit_True(uNREP_Destination, myUnit));
							uNREP_Destination.SetThrottle(ActiveUnit.Throttle.Full);
							if (myUnit.DesiredSpeed > 0f)
							{
								myUnit.DesiredSpeed = Math.Max(5f, uNREP_Destination.CurrentSpeed - 10f);
								myUnit.SetThrottle(myUnit.Kinematics.GetThrottleSuitableForThisSpeed(0f, (int)Math.Round(myUnit.DesiredSpeed)), (int)Math.Round(myUnit.DesiredSpeed));
							}
							return;
						}
						if (!uNREP_Destination.CommStuff.IsConnectedToSideNetwork)
						{
							myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Module_Unit.BearingToPoint_True(myUnit, uNREP_Destination.Latitude_LastReported.Value, uNREP_Destination.Longitude_LastReported.Value));
						}
						else
						{
							myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Module_Unit.BearingToUnit_True(myUnit, uNREP_Destination));
						}
						if ((double)myUnit.RangeToUnit_Horiz(uNREP_Destination) < 0.1)
						{
							return;
						}
						if ((float)(myUnit.Kinematics.GetMaximumSpeed(0f, ActiveUnit.Throttle.Cruise, ValidateAndFixAltitude: false) - 5) < uNREP_Destination.DesiredSpeed)
						{
							int maximumSpeed = myUnit.Kinematics.GetMaximumSpeed(0f, ActiveUnit.Throttle.Full, ValidateAndFixAltitude: false);
							ActiveUnit.Throttle newThrottleSetting = ActiveUnit.Throttle.Full;
							if ((float)(maximumSpeed - 5) < uNREP_Destination.DesiredSpeed)
							{
								newThrottleSetting = ActiveUnit.Throttle.Flank;
							}
							myUnit.SetThrottle(newThrottleSetting);
						}
						else
						{
							myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
						}
					}
					else
					{
						if (myUnit.Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint || myUnit.Status == ActiveUnit._ActiveUnitStatus.Refuelling)
						{
							myUnit.Status = myUnit._StatusBefore_NeedToRefuel;
						}
						if (myUnit.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.ManoeuveringToRefuel || myUnit.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.Replenishing)
						{
							myUnit.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.Underway;
						}
					}
					return;
				}
				case ActiveUnit._ActiveUnitStatus.Refuelling:
					if (myUnit.DockingOps.UNREP_Destination == null)
					{
						myUnit.Status = ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint;
						break;
					}
					myUnit.DesiredSpeed = 0f;
					return;
				}
				switch (myUnit.Status)
				{
				case ActiveUnit._ActiveUnitStatus.OnFireMission:
					if (!method_15())
					{
						if (!Information.IsNothing((object)myUnit.ActiveMissionOrPackage()))
						{
							if (myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.ArtyFireMission)
							{
								FireMission fireMission = (FireMission)myUnit.ActiveMissionOrPackage();
								if (fireMission != null && fireMission.UnitIsInFiringPosition(myUnit) == FireMission.UnitPositionStatus.OffMission)
								{
									myUnit.Navigator.PlotCourseToArea(fireMission.PositionArea);
									myUnit.SetThrottle(ActiveUnit.Throttle.Flank);
								}
							}
						}
						else
						{
							myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
						}
						goto default;
					}
					myUnit.SetThrottle(ActiveUnit.Throttle.FullStop);
					break;
				case ActiveUnit._ActiveUnitStatus.OnPlottedCourse:
					if (method_15())
					{
						myUnit.SetThrottle(ActiveUnit.Throttle.FullStop);
						break;
					}
					if (myUnit.IsOnActivePatrol() && !myUnit.Navigator.NextWaypointIsManual)
					{
						if (myUnit.Status == ActiveUnit._ActiveUnitStatus.EngagedOffensive && myUnit.Navigator.PlottedCourse.Length == 1 && myUnit.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.PatrolStation)
						{
							myUnit.Navigator.ClearPlottedCourse();
							break;
						}
						Patrol patrol = (Patrol)myUnit.ActiveMissionOrPackage();
						if (!myUnit.Navigator.PlottedCourseLeadsToMissionArea(ref patrol.PatrolArea, ref patrol.PatrolArea, ref patrol.PatrolArea_ChangeCheck, 0f, IgnoreTimeToNextEvaluation: false))
						{
							myUnit.Navigator.ClearPlottedCourse();
							myUnit.Navigator.PlotCourseToStationArea(elapsedTime, AddWaypointToExistingPlottedCourse: false);
						}
					}
					myUnit.Navigator.FollowPlottedCourse(elapsedTime);
					Common_FollowRoadNetwork(elapsedTime);
					if (!myUnit.AI.MustSlowDownToAllowGroupFormUp())
					{
						if (myUnit.Kinematics.DesiredSpeedOverride.HasValue)
						{
							myUnit.DesiredSpeed = myUnit.Kinematics.DesiredSpeedOverride.Value;
						}
						else if (myUnit.IsGroupMember() && myUnit.IsGroupLead())
						{
							float num3 = myUnit.Kinematics.GetMaximumSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), myUnit.ThrottleSetting, ValidateAndFixAltitude: false);
							foreach (ActiveUnit value in myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values)
							{
								if (value != myUnit && !value.IsFixedFacility)
								{
									float num4 = value.Kinematics.GetMaximumSpeed(value.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), myUnit.ThrottleSetting, ValidateAndFixAltitude: false);
									if (num4 < num3)
									{
										num3 = num4;
									}
								}
							}
							myUnit.DesiredSpeed = num3;
						}
					}
					else
					{
						float num5 = float.MaxValue;
						foreach (ActiveUnit value2 in myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values)
						{
							if (!value2.IsGroupLead() && !value2.Navigator.HaveReachedFormationStation() && value2.DesiredSpeed > 0f && value2.DesiredSpeed / 2f < num5)
							{
								num5 = value2.DesiredSpeed / 2f;
							}
						}
						myUnit.DesiredSpeed = Math.Min(myUnit.DesiredSpeed, num5);
					}
					myUnit.SetThrottle(myUnit.Kinematics.GetThrottleSuitableForThisSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (int)Math.Round(myUnit.DesiredSpeed)), (int)Math.Round(myUnit.DesiredSpeed));
					break;
				case ActiveUnit._ActiveUnitStatus.EngagedOffensive:
				{
					if (Information.IsNothing((object)PrimaryTarget))
					{
						break;
					}
					Contact_Base.ContactType type = PrimaryTarget.Type;
					if (type <= Contact_Base.ContactType.Missile)
					{
						myUnit.DesiredSpeed = 0f;
					}
					else if (myUnit.IsGroupMember())
					{
						if (myUnit.IsGroupLead())
						{
							ActiveUnit_Weaponry weaponry = myUnit.Weaponry;
							Contact primaryTarget = PrimaryTarget;
							Doctrine doctrine = myUnit.Doctrine;
							string UserFeedback = string.Empty;
							int FeedbackSeverity = 0;
							if (weaponry.HaveAvailableWeaponSuitableForThisTarget(primaryTarget, CheckWRA: true, doctrine, ref UserFeedback, ref FeedbackSeverity, HumanFeedBackNeeded: false))
							{
								MaintainStandoff(elapsedTime);
							}
							else if ((double)myUnit.RangeToUnit_Horiz(PrimaryTarget) > 0.05)
							{
								ManouverTowardsTarget(elapsedTime);
							}
							else
							{
								myUnit.SetThrottle(ActiveUnit.Throttle.FullStop);
							}
						}
						else if (myUnit.ActiveMissionOrPackage() == myUnit.get_ParentGroup(UsingMissionPlanner: false).ActiveMissionOrPackage() && myUnit.CommStuff.IsConnectedToSideNetwork)
						{
							bool flag2 = false;
							ActiveUnit_Weaponry weaponry2 = myUnit.Weaponry;
							Contact primaryTarget2 = PrimaryTarget;
							Doctrine doctrine2 = myUnit.Doctrine;
							string UserFeedback = string.Empty;
							int FeedbackSeverity = 0;
							if (weaponry2.HaveAvailableWeaponSuitableForThisTarget(primaryTarget2, CheckWRA: true, doctrine2, ref UserFeedback, ref FeedbackSeverity, HumanFeedBackNeeded: false))
							{
								Weapon weapon = myUnit.Weaponry.LongestRangedSuitableWeaponForThisTarget(PrimaryTarget);
								if (weapon != null)
								{
									float num2 = weapon.get_MaxRangeForThisTarget(myUnit, PrimaryTarget, CheckWRA: true, myUnit.Doctrine, ManualFire: false);
									if (PrimaryTarget == myUnit.get_ParentGroup(UsingMissionPlanner: false).AI.PrimaryTarget)
									{
										foreach (ActiveUnit value3 in myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values)
										{
											if (!(num2 <= value3.RangeToUnit_Horiz(PrimaryTarget)))
											{
												flag2 = true;
												break;
											}
										}
									}
									else
									{
										flag2 = num2 > myUnit.RangeToUnit_Horiz(PrimaryTarget);
									}
								}
							}
							if (flag2)
							{
								MaintainStandoff(elapsedTime);
							}
							else
							{
								myUnit.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
							}
						}
						else
						{
							MaintainStandoff(elapsedTime);
						}
					}
					else
					{
						MaintainStandoff(elapsedTime);
					}
					break;
				}
				case ActiveUnit._ActiveUnitStatus.OnPatrol:
					if (!method_15())
					{
						Patrol patrol2 = (Patrol)myUnit.ActiveMissionOrPackage();
						if (!Information.IsNothing((object)patrol2))
						{
							if (!myUnit.IsGroupMember())
							{
								if (!myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
								{
									myUnit.Navigator.PlotCourseToStationArea(elapsedTime, AddWaypointToExistingPlottedCourse: false);
									break;
								}
								ActiveUnit_Navigator navigator = myUnit.Navigator;
								ref List<ReferencePoint> patrolArea = ref patrol2.PatrolArea;
								List<ReferencePoint> theArea_Buffer = null;
								List<ReferencePoint> theArea_ChangeCheck = null;
								if (!navigator.PlottedCourseLeadsToMissionArea(ref patrolArea, ref theArea_Buffer, ref theArea_ChangeCheck, 30f, IgnoreTimeToNextEvaluation: false))
								{
									myUnit.Navigator.PlotCourseToStationArea(elapsedTime, AddWaypointToExistingPlottedCourse: false);
								}
								myUnit.Navigator.FollowPlottedCourse(elapsedTime);
								break;
							}
							if (myUnit.IsGroupLead())
							{
								if (!myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
								{
									myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlotCourseToStationArea(elapsedTime, AddWaypointToExistingPlottedCourse: false);
									break;
								}
								ActiveUnit_Navigator navigator2 = myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator;
								ref List<ReferencePoint> patrolArea2 = ref patrol2.PatrolArea;
								List<ReferencePoint> theArea_ChangeCheck = null;
								List<ReferencePoint> theArea_Buffer = null;
								if (!navigator2.PlottedCourseLeadsToMissionArea(ref patrolArea2, ref theArea_ChangeCheck, ref theArea_Buffer, 0f, IgnoreTimeToNextEvaluation: false))
								{
									myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlotCourseToStationArea(elapsedTime, AddWaypointToExistingPlottedCourse: false);
								}
								myUnit.Navigator.FollowPlottedCourse(elapsedTime);
								break;
							}
							if (myUnit.CommStuff.IsConnectedToSideNetwork)
							{
								myUnit.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
								break;
							}
						}
						else
						{
							myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
						}
						goto default;
					}
					myUnit.SetThrottle(ActiveUnit.Throttle.FullStop);
					break;
				case ActiveUnit._ActiveUnitStatus.Tasked:
					if (IsEscort)
					{
						HeadToNearestEscortSubject();
					}
					if (myUnit.IsOnActiveCargoMission)
					{
						Manouver_CargoMission(elapsedTime);
						break;
					}
					goto default;
				case ActiveUnit._ActiveUnitStatus.RTB:
				case ActiveUnit._ActiveUnitStatus.RTB_Manual:
				case ActiveUnit._ActiveUnitStatus.RTB_Group:
				case ActiveUnit._ActiveUnitStatus.RTB_CalledOff:
				case ActiveUnit._ActiveUnitStatus.RTB_Exhaustion:
					if (myUnit.IsVehicle && ((Vehicle)myUnit).IsAmphibiousSeaworthy)
					{
						ReturnToBase(elapsedTime);
					}
					goto default;
				case ActiveUnit._ActiveUnitStatus.OnSupportMission:
					if (!method_15())
					{
						if (Information.IsNothing((object)myUnit.ActiveMissionOrPackage()))
						{
							myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
						}
						else if (myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Support)
						{
							if (!myUnit.IsGroupMember())
							{
								myUnit.Navigator.FollowSupportMissionCourse(elapsedTime, myUnit.Navigator.IsInSupportTransit);
								break;
							}
							if (myUnit.IsGroupLead())
							{
								myUnit.Navigator.FollowSupportMissionCourse(elapsedTime, myUnit.Navigator.IsInSupportTransit);
								break;
							}
							if (myUnit.CommStuff.IsConnectedToSideNetwork)
							{
								myUnit.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
								break;
							}
						}
						goto default;
					}
					myUnit.SetThrottle(ActiveUnit.Throttle.FullStop);
					break;
				default:
					if (myUnit.IsGroupWingman())
					{
						if (!myUnit.IsGroupLead() && !Information.IsNothing((object)myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead) && myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.DockingOps.UNREP_Destination == myUnit)
						{
							switch (myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Status)
							{
							default:
								if (myUnit.CommStuff.IsConnectedToSideNetwork)
								{
									myUnit.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
								}
								break;
							case ActiveUnit._ActiveUnitStatus.Refuelling:
								myUnit.SetThrottle(ActiveUnit.Throttle.FullStop);
								break;
							case ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint:
								myUnit.set_DesiredHeading(myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.DesiredTurnRate, Module_Unit.BearingToUnit_True(myUnit, myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead));
								myUnit.SetThrottle(ActiveUnit.Throttle.Full);
								break;
							}
							break;
						}
						if (myUnit.CommStuff.IsConnectedToSideNetwork)
						{
							if (!method_15())
							{
								myUnit.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
								if (!myUnit.Navigator.IsManouveringToFormationStation)
								{
									myUnit.DesiredSpeed = myUnit.get_ParentGroup(UsingMissionPlanner: false).DesiredSpeed;
								}
							}
							else
							{
								myUnit.SetThrottle(ActiveUnit.Throttle.FullStop);
							}
							break;
						}
					}
					if (myUnit.Status == ActiveUnit._ActiveUnitStatus.Unassigned)
					{
						myUnit.DesiredSpeed = 0f;
					}
					break;
				case ActiveUnit._ActiveUnitStatus.RTB_MissionOver:
				case ActiveUnit._ActiveUnitStatus.RTB_CommsLost:
					if (myUnit.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.Underway)
					{
						myUnit.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.RTB;
					}
					ReturnToBase(elapsedTime);
					break;
				}
			}
			else
			{
				myUnit.Kinematics.DesiredSpeedOverride = null;
				myUnit.SetThrottle(ActiveUnit.Throttle.FullStop);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100551", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private bool method_16(Geopoint_Struct geopoint_Struct_0, CargoMission cargoMission_0)
	{
		return method_17(geopoint_Struct_0, cargoMission_0)?.Any() ?? false;
	}

	private List<Geopoint_Struct> method_17(Geopoint_Struct geopoint_Struct_0, CargoMission cargoMission_0)
	{
		bool flag = false;
		List<Geopoint_Struct> list = new List<Geopoint_Struct>();
		if (cargoMission_0.DestinationUnit != null)
		{
			Geopoint_Struct item = new Geopoint_Struct(cargoMission_0.DestinationUnit.get_Longitude((GlobalVariables.BooleanObject)null), cargoMission_0.DestinationUnit.get_Latitude((GlobalVariables.BooleanObject)null));
			list.Add(item);
			return list;
		}
		if (!((cargoMission_0.Area_1nm_Buffered == null) ? GeoPoint.IsInsideThisArea(geopoint_Struct_0.Latitude, geopoint_Struct_0.Longitude, cargoMission_0.Area) : GeoPoint.IsInsideThisArea(geopoint_Struct_0.Latitude, geopoint_Struct_0.Longitude, cargoMission_0.Area_1nm_Buffered)))
		{
			return null;
		}
		short num = short.MaxValue;
		short num2 = 1;
		short elevation = Terrain.GetElevation(geopoint_Struct_0.Latitude, geopoint_Struct_0.Longitude, RequestIsFromGUI: false, myUnit.ParentScen);
		if (elevation < short.MaxValue && elevation > num2)
		{
			int num3 = 1;
			do
			{
				float num4 = 0f;
				do
				{
					Geopoint_Struct item2 = default(Geopoint_Struct);
					Geodesic_EdWilliams.CalcPoint_Williams(geopoint_Struct_0.Longitude, geopoint_Struct_0.Latitude, ref item2.Longitude, ref item2.Latitude, num4, num3);
					if (GeoPoint.IsInsideThisArea(item2.Latitude, item2.Longitude, cargoMission_0.Area))
					{
						short elevation2 = Terrain.GetElevation(item2.Latitude, item2.Longitude, RequestIsFromGUI: false, myUnit.ParentScen);
						if (elevation2 > num2 && elevation2 < num)
						{
							list.Add(item2);
						}
					}
					num4 += 0.1f;
				}
				while (!(num4 > 2f));
				num3++;
			}
			while (num3 <= 360);
			return list;
		}
		return null;
	}

	private void method_18(float float_0)
	{
		if (myUnit.Navigator.HasPlottedCourse())
		{
			myUnit.Navigator.FollowPlottedCourse(float_0);
		}
		else if (!IsPerformingCargoSelfTransport())
		{
			if (myUnit.DockingOps.ActualDestinationHost != null)
			{
				myUnit.Navigator.PlotCourseToCargoDestination(myUnit.DockingOps.ActualDestinationHost);
			}
		}
		else
		{
			myUnit.Navigator.PlotCourseToCargoDestination(((CargoMission)myUnit.ActiveMissionOrPackage()).DestinationUnit);
		}
	}

	internal bool IsPerformingCargoSelfTransport()
	{
		if (myUnit.ActiveMissionOrPackage() != null && myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Cargo)
		{
			CargoMission cargoMission = (CargoMission)myUnit.ActiveMissionOrPackage();
			if (cargoMission.AllowAllSelfDelivery)
			{
				return true;
			}
			if (cargoMission.AllowSelfDeliveryFromCargo)
			{
				if (myUnit.DockingOps.Condition != ActiveUnit_DockingOps._DockingOpsCondition.LoadedAsCargo && myUnit.DockingOps.OriginalCargoHostUnit == null)
				{
					return false;
				}
				if (cargoMission.MoveAllCargo)
				{
					return true;
				}
				foreach (CargoManifestItem item in cargoMission.CargoToUnload)
				{
					if (Operators.CompareString(myUnit.ObjectID, item.ObjectID, false) == 0)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	protected override void Manouver_CargoMission(float elapsedTime)
	{
		CargoMission cargoMission = (CargoMission)myUnit.ActiveMissionOrPackage();
		bool flag = true;
		bool flag2 = IsPerformingCargoSelfTransport();
		if (myUnit.OnboardCargo.Count() == 0 && !flag2)
		{
			if (myUnit.DockingOps.ActualDestinationHost != null)
			{
				if (myUnit.RangeToUnit_Horiz(myUnit.DockingOps.ActualDestinationHost) < 2f)
				{
					if (ejwLfgOrlVD().IsAmphibiousSeaworthy)
					{
						ActiveUnit_DockingOps dockingOps = myUnit.DockingOps.ActualDestinationHost.DockingOps;
						ActiveUnit theBoat = myUnit;
						DockFacility bestFacility = null;
						if (dockingOps.CanHostThisBoat(theBoat, ref bestFacility))
						{
							ReturnToBase(elapsedTime);
							return;
						}
					}
					if (myUnit.DockingOps.ActualDestinationHost.IsGroup)
					{
						myUnit.DockingOps.SettleForCargoMissionTransfer(myUnit.DockingOps.OriginalCargoHostUnit);
					}
					else
					{
						myUnit.DockingOps.SettleForCargoMissionTransfer(myUnit.DockingOps.ActualDestinationHost);
					}
					return;
				}
				if (myUnit.IsGroupMember())
				{
					if (myUnit.IsGroupLead())
					{
						method_18(elapsedTime);
					}
					else if (myUnit.CommStuff.IsConnectedToSideNetwork)
					{
						myUnit.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
						flag = false;
					}
				}
				else
				{
					method_18(elapsedTime);
				}
				if (!myUnit.Kinematics.DesiredSpeedOverride.HasValue && flag)
				{
					myUnit.SetThrottle(cargoMission.TransitThrottle_Ship);
				}
			}
			else if (!cargoMission.RTBUponCompletion)
			{
				ActiveUnit activeUnit = myUnit;
				Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
				activeUnit.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: true, ref Result);
				myUnit.AddMessage(myUnit.Name + " (" + myUnit.UnitClass + ") has completed cargo mission: " + cargoMission.Name + ". The unit will be removed from the mission.", myUnit.Name + " has completed its cargo mission", LoggedMessage.MessageType.DockingOps, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			else if (!myUnit.DockingOps.AttemptToRTB(ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB_MissionOver, GroupMembersRTB: true, ActiveUnit._ActiveUnitStatus.RTB_Group, DetachFromGroup: true, ClearPlottedCourse: true))
			{
				if (myUnit.Navigator.HasPlottedCourse())
				{
					myUnit.Navigator.FollowPlottedCourse(elapsedTime);
					return;
				}
				myUnit.Kinematics.DesiredSpeedOverride = null;
				myUnit.DesiredSpeed = 0f;
				ActiveUnit activeUnit2 = myUnit;
				Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
				activeUnit2.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: true, ref Result);
				myUnit.AddMessage(myUnit.Name + " (" + myUnit.UnitClass + ") is unable to return to base during cargo mission: " + cargoMission.Name + ". The unit will be removed from the mission.", myUnit.Name + " unable to return to base; removed from mission", LoggedMessage.MessageType.DockingOps, 5, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			return;
		}
		if (cargoMission.Type == CargoMission.CargoMissionType.Transfer)
		{
			if (cargoMission.DestinationUnit != null && myUnit.RangeToUnit_Horiz(cargoMission.DestinationUnit) < 2f)
			{
				ActiveUnit_DockingOps dockingOps2 = cargoMission.DestinationUnit.DockingOps;
				ActiveUnit theBoat2 = myUnit;
				DockFacility bestFacility = null;
				if (!dockingOps2.CanHostThisBoat(theBoat2, ref bestFacility))
				{
					if (flag2)
					{
						Cargo item = new Cargo(cargoMission.DestinationUnit, myUnit);
						List<Cargo> list = new List<Cargo>();
						list.Add(item);
						ActiveUnit_DockingOps.PerformCargoTransferBetweenHostAndTarget(myUnit, cargoMission.DestinationUnit, list);
						foreach (CargoManifestItem item2 in cargoMission.CargoToUnload)
						{
							if (Operators.CompareString(item2.ObjectID, myUnit.ObjectID, false) == 0)
							{
								cargoMission.CargoToUnload.Remove(item2);
								break;
							}
						}
						ActiveUnit activeUnit3 = myUnit;
						Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
						activeUnit3.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: true, ref Result);
						myUnit.AddMessage(myUnit.Name + " (" + myUnit.UnitClass + ") has completed self-transport for cargo mission: " + cargoMission.Name + ". The unit will be removed from the mission.", myUnit.Name + " has completed cargo mission self-transport", LoggedMessage.MessageType.DockingOps, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
					}
					else
					{
						myUnit.DockingOps.SettleForCargoMissionTransfer(cargoMission.DestinationUnit);
					}
					return;
				}
			}
			if (myUnit.IsGroupMember())
			{
				if (!myUnit.IsGroupLead())
				{
					if (myUnit.CommStuff.IsConnectedToSideNetwork)
					{
						myUnit.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
						flag = false;
					}
				}
				else
				{
					method_18(elapsedTime);
				}
			}
			else
			{
				method_18(elapsedTime);
			}
			if (!myUnit.Kinematics.DesiredSpeedOverride.HasValue && flag)
			{
				myUnit.SetThrottle(cargoMission.TransitThrottle_Ship);
			}
			return;
		}
		if (!myUnit.Navigator.IsInsideMissionArea(ref cargoMission.Area, ref cargoMission.Area_1nm_Buffered, ref cargoMission.Area_1nm_ChangeCheck, 1, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
		{
			if (myUnit.IsGroupMember())
			{
				if (!myUnit.IsGroupLead())
				{
					if (myUnit.CommStuff.IsConnectedToSideNetwork)
					{
						myUnit.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
						flag = false;
					}
				}
				else if (myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
				{
					if (!myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlottedCourseLeadsToMissionArea(ref cargoMission.Area, ref cargoMission.Area_30nm_Buffered, ref cargoMission.Area_30nm_ChangeCheck, 30f, IgnoreTimeToNextEvaluation: false))
					{
						myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlotCourseToArea(cargoMission.Area);
					}
					myUnit.Navigator.FollowPlottedCourse(elapsedTime);
				}
				else
				{
					myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlotCourseToArea(cargoMission.Area);
				}
			}
			else if (!myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
			{
				if (myUnit.DockingOps.Condition != ActiveUnit_DockingOps._DockingOpsCondition.TransferringCargo)
				{
					myUnit.Navigator.PlotCourseToArea(cargoMission.Area, OvershootDestination: false, Waypoint.WaypointType.DropOffPoint);
				}
			}
			else
			{
				if (!myUnit.Navigator.PlottedCourseLeadsToMissionArea(ref cargoMission.Area, ref cargoMission.Area_30nm_Buffered, ref cargoMission.Area_30nm_ChangeCheck, 30f, IgnoreTimeToNextEvaluation: false))
				{
					myUnit.Navigator.PlotCourseToArea(cargoMission.Area);
				}
				myUnit.Navigator.FollowPlottedCourse(elapsedTime);
			}
			if (!myUnit.Kinematics.DesiredSpeedOverride.HasValue && flag)
			{
				if (!myUnit.Navigator.IsInsideMissionArea(ref cargoMission.Area, ref cargoMission.Area_1nm_Buffered, ref cargoMission.Area_1nm_ChangeCheck, 1, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
				{
					myUnit.SetThrottle(cargoMission.TransitThrottle_Ship);
				}
				else
				{
					myUnit.SetThrottle(cargoMission.StationThrottle_Ship);
				}
			}
			return;
		}
		if (!flag2 && method_16(new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)), cargoMission))
		{
			myUnit.DockingOps.SettleForCargoTransfer();
			return;
		}
		if (flag2 && Module_Unit.IsOverLand(myUnit))
		{
			ActiveUnit activeUnit4 = myUnit;
			Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
			activeUnit4.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: true, ref Result);
			myUnit.AddMessage(myUnit.Name + " (" + myUnit.UnitClass + ") has completed self-transport for cargo mission: " + cargoMission.Name + ". The unit will be removed from the mission.", myUnit.Name + " has completed cargo mission self-transport", LoggedMessage.MessageType.DockingOps, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
			return;
		}
		Geopoint_Struct geopoint_Struct = default(Geopoint_Struct);
		int num = 0;
		Geopoint_Struct geopoint_Struct2 = default(Geopoint_Struct);
		List<Geopoint_Struct> list2 = null;
		do
		{
			num++;
			geopoint_Struct = Math2.RandomPointWithinThisArea(cargoMission.Area);
			if (num <= 1000)
			{
				list2 = method_17(geopoint_Struct, cargoMission);
				continue;
			}
			myUnit.AddMessage(myUnit.Name + " is unable to pick a suitable point inside cargo landing area defined by Ref. Points", myUnit.Name + " unable to pick point", LoggedMessage.MessageType.DockingOps, 1, geopoint_Struct, ActiveUnit.NotificationType.Bark);
			return;
		}
		while (list2 == null || !list2.Any());
		geopoint_Struct2 = list2.OrderBy([SpecialName] (Geopoint_Struct thepoint) => Math2.CalcDist_Angular(thepoint.Latitude, thepoint.Longitude, myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null))).ThenBy([SpecialName] (Geopoint_Struct thePoint) => Terrain.GetElevation(thePoint.Latitude, thePoint.Longitude, RequestIsFromGUI: false, myUnit.ParentScen)).First();
		myUnit.Navigator.ClearPlottedCourse();
		myUnit.Navigator.AddWaypoint(geopoint_Struct2.Latitude, geopoint_Struct2.Longitude, 0f, Waypoint.WaypointType.PatrolStation, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse);
		myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), geopoint_Struct2.Latitude, geopoint_Struct2.Longitude));
	}

	static Vehicle_AI()
	{
		Class72.smethod_20();
	}
}
