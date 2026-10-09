using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml;
using Collections.Pooled;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Facility_AI : ActiveUnit_AI
{
	private Facility facility_0;

	private HashSet<string> hashSet_0;

	public override bool ConsidersToBeUnderAttack => base.get_ConsidersToBeUnderAttack(IgnoreThreatIfNoSensor: true);

	[SpecialName]
	private Facility method_12()
	{
		if (facility_0 == null)
		{
			facility_0 = (Facility)myUnit;
		}
		return facility_0;
	}

	public static Facility_AI FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		//IL_03ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c1: Expected O, but got Unknown
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		Facility_AI result;
		try
		{
			Facility_AI facility_AI = new Facility_AI(ref theAU);
			facility_AI.myUnit = theAU;
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
					facility_AI._PrimaryTarget = Contact.FromXML(val.InnerText, ref theDictionary);
					break;
				case "Threats":
					if (facility_AI._Threats == null)
					{
						facility_AI._Threats = new List<Contact>();
					}
					foreach (XmlNode childNode2 in val.ChildNodes)
					{
						XmlNode theNode2 = childNode2;
						Contact item = Contact.FromXML(ref theNode2, ref theDictionary);
						facility_AI._Threats.Add(item);
					}
					break;
				case "PrimaryThreat":
				case "PThreat":
					facility_AI._PrimaryThreat = Contact.FromXML(val.InnerText, ref theDictionary);
					break;
				case "MSF":
					uint.TryParse(val.InnerText, out facility_AI._Mission_State_Flags);
					break;
				case "TTNPTE":
					facility_AI.TimeToNextTargetsEvaluation = XmlConvert.ToSingle(val.InnerText.Replace(",", "."));
					break;
				case "IE":
					facility_AI.IsEscort = true;
					break;
				case "DPT_E":
					facility_AI.DeterminePrimaryTarget_Enabled = Misc.ParseBool(val.InnerText);
					break;
				case "PrimaryTarget_LastKnown_Lon":
					facility_AI.PrimaryTarget_LastKnown_Lon = XmlConvert.ToDouble(val.InnerText);
					break;
				case "PrimaryPickupTarget":
					facility_AI._PrimaryPickupTarget = ActiveUnit.FromXML(val.InnerText, ref theDictionary);
					break;
				case "TargetList":
					facility_AI._TargetList = new ObservableDictionary<string, TargetingEntry>();
					foreach (XmlNode childNode3 in val.ChildNodes)
					{
						XmlNode theNode3 = childNode3;
						TargetingEntry targetingEntry = TargetingEntry.FromXML(ref theNode3, ref theDictionary);
						if (targetingEntry.Target != null && !facility_AI._TargetList.ContainsKey(targetingEntry.Target.ObjectID))
						{
							facility_AI._TargetList.Add(targetingEntry.Target.ObjectID, targetingEntry);
						}
					}
					break;
				case "PrimaryTarget_LastKnown_Lat":
					facility_AI.PrimaryTarget_LastKnown_Lat = XmlConvert.ToDouble(val.InnerText);
					break;
				case "HP":
				case "HPos":
					facility_AI.HoldPosition = Misc.ParseBool(val.InnerText);
					break;
				case "PrimaryTargetOverrideExists":
				case "PTOE":
					facility_AI.PrimaryTargetOverrideExists = Misc.ParseBool(val.InnerText);
					break;
				case "PrimaryTarget_LastKnown_Alt":
					facility_AI.PrimaryTarget_LastKnown_Altitude = XmlConvert.ToSingle(val.InnerText);
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
				case "ET_E":
					facility_AI.EvaluateTargets_Enabled = Misc.ParseBool(val.InnerText);
					break;
				}
			}
			result = facility_AI;
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
			result = new Facility_AI(ref theAU);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public Facility_AI(ref ActiveUnit theUnit)
		: base(theUnit)
	{
		hashSet_0 = new HashSet<string>();
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
			if (myUnit.Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint || myUnit.Status == ActiveUnit._ActiveUnitStatus.Refuelling)
			{
				return;
			}
			ActiveUnit theUnit = myUnit;
			Exception ThrownError = null;
			if (Pathfinding.UnitOrFlightPlanHasPFRequestInQueue(theUnit, null, ref ThrownError))
			{
				myUnit.Status = ActiveUnit._ActiveUnitStatus.WaitForPathfinder;
				return;
			}
			if (myUnit.Navigator.HasPathfindingPlottedCourse && myUnit.Status == ActiveUnit._ActiveUnitStatus.WaitForPathfinder)
			{
				myUnit.Status = myUnit._StatusBefore_WaitForPathfinder;
			}
			if (myUnit.IsRTB)
			{
				return;
			}
			if (method_12().RepresentsMobileGroundUnit && myUnit.ParentScen.FifteenthSecondIsChangingOnThisPulse && !myUnit.IsRTB && CheckForWithdrawalCriteria())
			{
				myUnit.Navigator.ResetTimeToNextPathfinderCheck();
				return;
			}
			if (myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse() || myUnit.Navigator.HasRoadSystemPlottedCourse())
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
			if (!Information.IsNothing((object)PrimaryTarget))
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
									goto IL_0463;
								}
								num2 = 0;
							}
							flag2 = (byte)num2 != 0;
						}
					}
					goto IL_0463;
				}
			}
			goto IL_0478;
			IL_0478:
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
			if (myUnit.ActiveMissionOrPackage() != null && myUnit.ActiveMissionOrPackage().IsActive)
			{
				switch (myUnit.ActiveMissionOrPackage().MissionClass)
				{
				case Mission._MissionClass.ArtyFireMission:
					myUnit.Status = ActiveUnit._ActiveUnitStatus.OnFireMission;
					return;
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
				}
				myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
			}
			if (myUnit.FuelState != ActiveUnit._ActiveUnitFuelState.IgnoreBingoAndJoker && myUnit.WeaponState != ActiveUnit._ActiveUnitWeaponState.IgnoreWinchesterAndShotgun && myUnit.Status != ActiveUnit._ActiveUnitStatus.Unassigned)
			{
				myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
			}
			return;
			IL_0463:
			if (flag2)
			{
				myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
				return;
			}
			goto IL_0478;
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
		if (!EvaluateTargets_Enabled || myUnit == null || (myUnit.IsDrone() && myUnit.AutonomyLevel < ActiveUnit.DroneAutonomyLevel.BattlespaceCognizant && myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DroneAutonomyLevels) && !myUnit.CommStuff.IsConnectedToSideNetwork))
		{
			return;
		}
		ActiveUnit_Weaponry weaponry = myUnit.Weaponry;
		try
		{
			if (myUnit.Mounts.Count == 0 && myUnit.Sensors_Cached.Length == 0)
			{
				if (PrimaryTarget != null)
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
			List<Weapon> list = weaponry.AllDistinctWeaponsAboard_Actual();
			Weapon weapon = default(Weapon);
			Weapon weapon2 = default(Weapon);
			Weapon weapon3 = default(Weapon);
			Weapon weapon4 = default(Weapon);
			foreach (Weapon item3 in list)
			{
				if (weapon == null)
				{
					if (item3.MaxAirRange > 0f)
					{
						weapon = item3;
					}
				}
				else if (item3.MaxAirRange > weapon.MaxAirRange)
				{
					weapon = item3;
				}
				if (weapon2 != null)
				{
					if (item3.MaxSurfaceRange > weapon2.MaxSurfaceRange)
					{
						weapon2 = item3;
					}
				}
				else if (item3.MaxSurfaceRange > 0f)
				{
					weapon2 = item3;
				}
				if (weapon3 != null)
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
				if (weapon4 == null)
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
			if (weapon == null && weapon2 == null && weapon4 == null && weapon3 == null && (myUnit.IsFixedFacility || HoldPosition))
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
			if (hashSet_0.Count > 0)
			{
				hashSet_0.Clear();
			}
			ObservableDictionary<string, TargetingEntry> targetList = _TargetList;
			Contact[] array = theContactsVisibleToMe.InternalArray();
			int num = count - 1;
			for (int j = 0; j <= num; j++)
			{
				Contact contact = array[j];
				if (TargetingBehaviorForThisTarget(contact, targetList) != TargetingEntry._TargetingBehavior.NotTargeted)
				{
					hashSet_0.Add(contact.ObjectID);
				}
			}
			Contact contact2 = default(Contact);
			int FeedbackSeverity;
			if (mission != null && mission.IsActive)
			{
				int num2 = count - 1;
				for (int k = 0; k <= num2; k++)
				{
					contact2 = array[k];
					if (_DoNotTargetList.Contains(contact2) || contact2 == null)
					{
						continue;
					}
					string objectID = contact2.ObjectID;
					if (hashSet_0.Contains(objectID))
					{
						continue;
					}
					byte? b = (byte?)contact2.BDA_StructuralIntegrity;
					if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 4)) == true)
					{
						continue;
					}
					bool? flag = ((contact2.IDStatus < Contact_Base.IdentificationStatus.KnownType) ? new bool?(false) : contact2.ActualUnit?.IsWeapon);
					if ((flag ?? true) && ((Weapon)contact2.ActualUnit).IsMobileDecoy && flag.HasValue)
					{
						bool flag2 = false;
						Sensor[] sensors_Cached = contact2.ActualUnit.Sensors_Cached;
						for (int l = 0; l < sensors_Cached.Length; l = checked(l + 1))
						{
							if (sensors_Cached[l].IsOECM)
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
					Misc.PostureStance contactsStance_Cache = GetContactsStance_Cache(contact2, k);
					Contact theContact = contact2;
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
						if (!IsContactTooAmbiguousForEvaluation(contact2) && (contact2.Type != Contact_Base.ContactType.Submarine || (!contact2.IsClassifiedFalseTarget && !SeaIceProvider.PointIsUnderIce(((Module_Unit.Unit)contact2).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact2).get_Latitude((GlobalVariables.BooleanObject)null)) && GetTargetAmbiguity(contact2, 100f) != AmbiguityLevel.ExtremelyAmbiguous)))
						{
							Contact theTarget = contact2;
							Doctrine doctrine = myUnit.Doctrine;
							Feedback = null;
							FeedbackSeverity = 0;
							if (weaponry.HaveAvailableWeaponSuitableForThisTarget(theTarget, CheckWRA: true, doctrine, ref Feedback, ref FeedbackSeverity, HumanFeedBackNeeded: false, list2))
							{
								TargetThisContact(contact2, AddedManually: false, PriorityTarget: false, TargetingEntry._TargetingBehavior.AutoTargeted);
								hashSet_0.Add(contact2.ObjectID);
							}
						}
						break;
					case Misc.PostureStance.Unknown:
						TargetThisContact(contact2, AddedManually: false, PriorityTarget: false, TargetingEntry._TargetingBehavior.AutoTargeted);
						hashSet_0.Add(contact2.ObjectID);
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
						weapon2 = weaponry.GetLongestRange_ASWeapon(ExcludeICBMs: false, contact2);
						weapon3 = weaponry.GetLongestRange_AGWeapon(ExcludeICBMs: false, contact2);
					}
					else
					{
						weapon2 = null;
						weapon3 = null;
					}
				}
			}
			if (myUnit.IsOnActivePatrol())
			{
				_ = ((Patrol)mission).HasProsecutionArea;
			}
			bool hasValue;
			Doctrine._UseShootTourists value = default(Doctrine._UseShootTourists);
			if (hasValue = useShootTourists.HasValue)
			{
				value = useShootTourists.Value;
			}
			FeedbackSeverity = count - 1;
			for (int m = 0; m <= FeedbackSeverity; m++)
			{
				try
				{
					contact2 = array[m];
					if (contact2 == null || _DoNotTargetList.Contains(contact2))
					{
						continue;
					}
					string objectID = contact2.ObjectID;
					if (hashSet_0.Contains(objectID))
					{
						continue;
					}
					Misc.PostureStance contactsStance_Cache = GetContactsStance_Cache(contact2, m);
					if (contactsStance_Cache == Misc.PostureStance.Neutral || contactsStance_Cache == Misc.PostureStance.Friendly)
					{
						continue;
					}
					byte? b = (byte?)contact2.BDA_StructuralIntegrity;
					if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 4)) == true)
					{
						continue;
					}
					bool? flag = ((contact2.IDStatus < Contact_Base.IdentificationStatus.KnownType) ? new bool?(false) : contact2.ActualUnit?.IsWeapon);
					if (((!flag) ?? false) || !((Weapon)contact2.ActualUnit).IsMobileDecoy || !flag.HasValue)
					{
						goto IL_07af;
					}
					bool flag3 = false;
					Sensor[] sensors_Cached2 = contact2.ActualUnit.Sensors_Cached;
					for (int n = 0; n < sensors_Cached2.Length; n = checked(n + 1))
					{
						if (sensors_Cached2[n].IsOECM)
						{
							flag3 = true;
							break;
						}
					}
					if (flag3)
					{
						goto IL_07af;
					}
					goto end_IL_065c;
					IL_07af:
					if (myUnit.Weaponry.ContactIsWithinSelfDefenceRange(contact2))
					{
						_SelfDefenceTargets.Add(contact2);
					}
					if (mission == null || !mission.IsActive || mission.MissionClass != Mission._MissionClass.Patrol || ((Patrol)mission).get_InvestigateOutsidePatrolArea(myUnit.ParentScen))
					{
						goto IL_084a;
					}
					Patrol patrol2 = (Patrol)mission;
					if (((Module_Unit.Unit)contact2).get_IsInsideThisArea(patrol2.PatrolArea, myUnit.ParentScen, UseCache: true) || TargetingBehaviorForThisTarget(contact2, targetList) == TargetingEntry._TargetingBehavior.ManualWeaponAlloc || myUnit.Sensory.IsIlluminatingThisContact(contact2) || (hasValue && value == Doctrine._UseShootTourists.Yes))
					{
						goto IL_084a;
					}
					goto end_IL_065c;
					IL_084a:
					if (!hashSet_0.Contains(contact2.ObjectID) && TargetIsEligibleBasedOnWeaponRange(contact2, contactsStance_Cache, hasValue, value, weapon, weapon2, weapon3, weapon4))
					{
						Contact theTarget2 = contact2;
						Doctrine doctrine2 = myUnit.Doctrine;
						string Feedback = null;
						int FeedbackSeverity2 = 0;
						if (weaponry.HaveAvailableWeaponSuitableForThisTarget(theTarget2, CheckWRA: true, doctrine2, ref Feedback, ref FeedbackSeverity2, HumanFeedBackNeeded: false, list2) && !DropTargetDueToRearwardFiringDoctrine(contact2))
						{
							TargetThisContact(contact2, AddedManually: false, PriorityTarget: false, TargetingEntry._TargetingBehavior.AutoTargeted);
							hashSet_0.Add(contact2.ObjectID);
						}
					}
					end_IL_065c:;
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
			foreach (Contact selfDefenceTarget in _SelfDefenceTargets)
			{
				if (!hashSet_0.Contains(selfDefenceTarget.ObjectID) && !_DoNotTargetList.Contains(selfDefenceTarget))
				{
					TargetThisContact(selfDefenceTarget, AddedManually: false, PriorityTarget: false, TargetingEntry._TargetingBehavior.AutoSelfDefence);
					hashSet_0.Add(contact2.ObjectID);
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
		if (weapon_0 == null)
		{
			return false;
		}
		if (method_12().Category == Facility._FacilityCategory.Underwater)
		{
			return weapon_0.ValidTargets.UnderwaterStructure;
		}
		IMobileGroundUnit._MobileUnitCategory mobileUnitCategory = method_12().MobileUnitCategory();
		if (mobileUnitCategory == IMobileGroundUnit._MobileUnitCategory.AAA || mobileUnitCategory == IMobileGroundUnit._MobileUnitCategory.SAM)
		{
			int result;
			if (weapon_0.ValidTargets.MobileTarget_Hard)
			{
				result = 1;
			}
			else if (weapon_0.ValidTargets.MobileTarget_Soft)
			{
				result = 1;
			}
			else if (weapon_0.ValidTargets.MobileTarget_Personnel)
			{
				result = 1;
			}
			else if (!weapon_0.ValidTargets.LandStructure_Hard)
			{
				if (!weapon_0.ValidTargets.LandStructure_Soft)
				{
					goto IL_00a5;
				}
				result = 1;
			}
			else
			{
				result = 1;
			}
			return (byte)result != 0;
		}
		goto IL_00a5;
		IL_00a5:
		if (!method_12().RepresentsMobileGroundUnit)
		{
			if (method_12().Category == Facility._FacilityCategory.Runway)
			{
				if (weapon_0.ValidTargets.Runway)
				{
					return true;
				}
			}
			else
			{
				if (!method_12().IsHardTarget)
				{
					int result2;
					if (!weapon_0.ValidTargets.LandStructure_Hard)
					{
						if (!weapon_0.ValidTargets.LandStructure_Soft)
						{
							goto IL_0168;
						}
						result2 = 1;
					}
					else
					{
						result2 = 1;
					}
					return (byte)result2 != 0;
				}
				if (weapon_0.ValidTargets.LandStructure_Hard)
				{
					return true;
				}
			}
		}
		else
		{
			if (!method_12().IsHardTarget)
			{
				int result3;
				if (weapon_0.ValidTargets.MobileTarget_Hard)
				{
					result3 = 1;
				}
				else if (weapon_0.ValidTargets.MobileTarget_Soft)
				{
					result3 = 1;
				}
				else
				{
					if (!weapon_0.ValidTargets.MobileTarget_Personnel)
					{
						goto IL_0168;
					}
					result3 = 1;
				}
				return (byte)result3 != 0;
			}
			if (weapon_0.ValidTargets.MobileTarget_Hard)
			{
				return true;
			}
		}
		goto IL_0168;
		IL_0168:
		int result4;
		if (!weapon_0.ValidTargets.Radar)
		{
			result4 = 0;
		}
		else
		{
			if (myUnit.HasRadarSensor)
			{
				return true;
			}
			result4 = 0;
		}
		return (byte)result4 != 0;
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
			Contact[] array = theContactsVisibleToMe.InternalArray();
			int num = theContactsVisibleToMe.Count - 1;
			Contact contact;
			ActiveUnit actualUnit;
			Weapon longestRange_AAWeapon;
			for (int i = 0; i <= num; i++)
			{
				contact = array[i];
				if (contact == null)
				{
					continue;
				}
				actualUnit = contact.ActualUnit;
				if (actualUnit == null || !actualUnit.IsWeapon || GetContactsStance_Cache(contact, i) == Misc.PostureStance.Friendly || !method_14((Weapon)actualUnit))
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
					if (weaponry.HaveAvailableWeaponSuitableForThisTarget(theTarget, CheckWRA: true, doctrine, ref Feedback, ref FeedbackSeverity, HumanFeedBackNeeded: false, availableWeapons) && (double)Module_Unit.RangeToUnit_Slant(myUnit, contact, 0f, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue) < 1.5 * (double)longestRange_AAWeapon.MaxAirRange)
					{
						TargetThisContact(contact, AddedManually: false, PriorityTarget: false, TargetingEntry._TargetingBehavior.AutoTargeted);
					}
				}
			}
			availableWeapons = null;
			contact = null;
			actualUnit = null;
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
			if (!method_12().CanFireOnTheMove && (int)Math.Round(method_12().CurrentSpeed) > 0)
			{
				bool flag = false;
				if (myUnit.get_UnitSide(SetSideOnly: false).FiringProposals != null && myUnit.get_UnitSide(SetSideOnly: false).FiringProposals.Count > 0)
				{
					foreach (KeyValuePair<string, FiringProposal> firingProposal in myUnit.get_UnitSide(SetSideOnly: false).FiringProposals)
					{
						if (Operators.CompareString(firingProposal.Value.FiringUnit.ObjectID, myUnit.ObjectID, false) == 0)
						{
							float num = firingProposal.Value.get_ReferenceWeapon(myUnit.ParentScen).get_MaxRangeForThisTarget(myUnit, firingProposal.Value.Target, CheckWRA: true, myUnit.Doctrine, ManualFire: false);
							Geopoint_Struct Point = myUnit.Location;
							Geopoint_Struct Point2 = firingProposal.Value.Target.Location;
							if (num > Math2.CalcDist(ref Point, ref Point2))
							{
								flag = true;
							}
						}
					}
				}
				if (!flag && myUnit.get_UnitSide(SetSideOnly: false).WeaponSalvos != null && myUnit.get_UnitSide(SetSideOnly: false).WeaponSalvos.Count > 0)
				{
					int num2 = myUnit.get_UnitSide(SetSideOnly: false).WeaponSalvos.Count - 1;
					for (int i = 0; i <= num2; i++)
					{
						WeaponSalvo weaponSalvo;
						try
						{
							weaponSalvo = myUnit.get_UnitSide(SetSideOnly: false).WeaponSalvos[i];
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
							continue;
						}
						bool flag2 = false;
						WeaponSalvo.Shooter[] shootersList = weaponSalvo.ShootersList;
						for (int j = 0; j < shootersList.Length; j = checked(j + 1))
						{
							if (Operators.CompareString(shootersList[j]?.ShooterObjectID, method_12()?.ObjectID, false) != 0)
							{
								if (flag2)
								{
									break;
								}
								continue;
							}
							flag2 = true;
							float num3 = weaponSalvo.get_ReferenceWeapon(myUnit.ParentScen).get_MaxRangeForThisTarget(myUnit, weaponSalvo.Target, CheckWRA: true, myUnit.Doctrine, ManualFire: false);
							Geopoint_Struct Point2 = myUnit.Location;
							Geopoint_Struct Point = weaponSalvo.Target.Location;
							if (num3 > Math2.CalcDist(ref Point2, ref Point))
							{
								flag = true;
							}
							break;
						}
					}
				}
				if (flag)
				{
					method_12().DesiredSpeed = 0f;
					method_12().SetThrottle(ActiveUnit.Throttle.FullStop);
				}
			}
			else
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
			if (weapon == null)
			{
				return;
			}
			float num = myUnit.RangeToUnit_Horiz(PrimaryTarget);
			float num2 = weapon.get_MaxRangeForThisTarget(myUnit, PrimaryTarget, CheckWRA: true, doctrine, ManualFire: false);
			float num3 = num / num2;
			float num4 = 0.8f;
			switch (method_12().MobileUnitCategory())
			{
			case IMobileGroundUnit._MobileUnitCategory.Infantry:
			case IMobileGroundUnit._MobileUnitCategory.Armor:
			case IMobileGroundUnit._MobileUnitCategory.MechInfantry:
				num4 = 0.5f;
				break;
			case IMobileGroundUnit._MobileUnitCategory.Artillery_Gun:
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
		int result;
		if (myUnit.Status != ActiveUnit._ActiveUnitStatus.EngagedOffensive)
		{
			if (method_12().CanFireOnTheMove)
			{
				result = 0;
			}
			else
			{
				if (_TargetList != null)
				{
					Doctrine._UseShootTourists? useShootTourists = myUnit.Doctrine.get_ShootTourists(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
					int result2;
					if (!useShootTourists.HasValue)
					{
						result2 = 0;
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
						result2 = 0;
					}
					return (byte)result2 != 0;
				}
				result = 0;
			}
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public override void DetermineDesiredAttitudeAndThrottle(float elapsedTime, bool RecalculatePlottedCourse = true)
	{
		if (myUnit == null)
		{
			return;
		}
		try
		{
			if (myUnit.IsFixedFacility || HoldPosition)
			{
				return;
			}
			if (!myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DroneAutonomyLevels))
			{
				if (myUnit.IsDrone() && !myUnit.CommStuff.IsConnectedToSideNetwork && !myUnit.IsRTB)
				{
					myUnit.Kinematics.Loiter(elapsedTime);
					return;
				}
			}
			else if (myUnit.IsDrone() && myUnit.AutonomyLevel < ActiveUnit.DroneAutonomyLevel.SelfRecovering && myUnit.CommStuff.TimeOffComms > 0f)
			{
				return;
			}
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
					if (myUnit.IsGroupLead() && uNREP_Destination.IsGroupMember() && myUnit.get_ParentGroup(UsingMissionPlanner: false) == uNREP_Destination.get_ParentGroup(UsingMissionPlanner: false))
					{
						uNREP_Destination.set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Module_Unit.BearingToUnit_True(uNREP_Destination, myUnit));
						uNREP_Destination.SetThrottle(ActiveUnit.Throttle.Full);
						myUnit.DesiredSpeed = Math.Max(5f, uNREP_Destination.CurrentSpeed - 10f);
						myUnit.SetThrottle(myUnit.Kinematics.GetThrottleSuitableForThisSpeed(0f, (int)Math.Round(myUnit.DesiredSpeed)), (int)Math.Round(myUnit.DesiredSpeed));
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
						myUnit.DesiredSpeed = uNREP_Destination.CurrentSpeed;
						myUnit.SetThrottle(myUnit.Kinematics.GetThrottleSuitableForThisSpeed(0f, (int)Math.Round(myUnit.DesiredSpeed)), (int)Math.Round(myUnit.DesiredSpeed));
					}
					else if ((float)(myUnit.Kinematics.GetMaximumSpeed(0f, ActiveUnit.Throttle.Cruise, ValidateAndFixAltitude: false) - 5) < uNREP_Destination.DesiredSpeed)
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
				myUnit.SetThrottle(ActiveUnit.Throttle.FullStop);
				return;
			}
			switch (myUnit.Status)
			{
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
							return;
						}
						if (myUnit.IsGroupLead())
						{
							myUnit.Navigator.FollowSupportMissionCourse(elapsedTime, myUnit.Navigator.IsInSupportTransit);
							return;
						}
						if (myUnit.CommStuff.IsConnectedToSideNetwork)
						{
							myUnit.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
							return;
						}
					}
					break;
				}
				myUnit.SetThrottle(ActiveUnit.Throttle.FullStop);
				return;
			case ActiveUnit._ActiveUnitStatus.OnPlottedCourse:
				if (!method_15())
				{
					if (myUnit.IsOnActivePatrol() && !myUnit.Navigator.NextWaypointIsManual)
					{
						if (myUnit.Status == ActiveUnit._ActiveUnitStatus.EngagedOffensive && myUnit.Navigator.PlottedCourse.Length == 1 && myUnit.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.PatrolStation)
						{
							myUnit.Navigator.ClearPlottedCourse();
							return;
						}
						Patrol patrol2 = (Patrol)myUnit.ActiveMissionOrPackage();
						if (!myUnit.Navigator.PlottedCourseLeadsToMissionArea(ref patrol2.PatrolArea, ref patrol2.PatrolArea, ref patrol2.PatrolArea_ChangeCheck, 0f, IgnoreTimeToNextEvaluation: false))
						{
							myUnit.Navigator.ClearPlottedCourse();
							myUnit.Navigator.PlotCourseToStationArea(elapsedTime, AddWaypointToExistingPlottedCourse: false);
						}
					}
					myUnit.Navigator.FollowPlottedCourse(elapsedTime);
					Common_FollowRoadNetwork(elapsedTime);
					if (myUnit.AI.MustSlowDownToAllowGroupFormUp())
					{
						float num3 = float.MaxValue;
						foreach (ActiveUnit value in myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values)
						{
							if (!value.IsGroupLead() && !value.Navigator.HaveReachedFormationStation() && value.DesiredSpeed > 0f && value.DesiredSpeed / 2f < num3)
							{
								num3 = value.DesiredSpeed / 2f;
							}
						}
						myUnit.DesiredSpeed = Math.Min(myUnit.DesiredSpeed, num3);
					}
					else if (myUnit.Kinematics.DesiredSpeedOverride.HasValue)
					{
						myUnit.DesiredSpeed = myUnit.Kinematics.DesiredSpeedOverride.Value;
					}
					else
					{
						if (!myUnit.IsGroupMember() || !myUnit.IsGroupLead())
						{
							return;
						}
						float num4 = float.MaxValue;
						foreach (ActiveUnit value2 in myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values)
						{
							if (value2 != myUnit)
							{
								float num5 = value2.Kinematics.GetMaximumSpeed(value2.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), myUnit.ThrottleSetting, ValidateAndFixAltitude: false);
								if (num5 < num4)
								{
									num4 = num5;
								}
							}
						}
						myUnit.DesiredSpeed = num4;
					}
				}
				else
				{
					myUnit.SetThrottle(ActiveUnit.Throttle.FullStop);
				}
				return;
			case ActiveUnit._ActiveUnitStatus.EngagedOffensive:
				if (Information.IsNothing((object)PrimaryTarget))
				{
					return;
				}
				if (PrimaryTarget.IsAir_Missile_Orbital_Contact)
				{
					myUnit.SetThrottle(ActiveUnit.Throttle.FullStop);
				}
				else if (!myUnit.IsGroupMember())
				{
					MaintainStandoff(elapsedTime);
				}
				else if (!myUnit.IsGroupLead())
				{
					if (myUnit.ActiveMissionOrPackage() == myUnit.get_ParentGroup(UsingMissionPlanner: false).ActiveMissionOrPackage() && myUnit.CommStuff.IsConnectedToSideNetwork)
					{
						bool flag2 = false;
						ActiveUnit_Weaponry weaponry = myUnit.Weaponry;
						Contact primaryTarget = PrimaryTarget;
						Doctrine doctrine = myUnit.Doctrine;
						string UserFeedback = string.Empty;
						int FeedbackSeverity = 0;
						if (weaponry.HaveAvailableWeaponSuitableForThisTarget(primaryTarget, CheckWRA: true, doctrine, ref UserFeedback, ref FeedbackSeverity, HumanFeedBackNeeded: false))
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
					ActiveUnit_Weaponry weaponry2 = myUnit.Weaponry;
					Contact primaryTarget2 = PrimaryTarget;
					Doctrine doctrine2 = myUnit.Doctrine;
					string UserFeedback = string.Empty;
					int FeedbackSeverity = 0;
					if (weaponry2.HaveAvailableWeaponSuitableForThisTarget(primaryTarget2, CheckWRA: true, doctrine2, ref UserFeedback, ref FeedbackSeverity, HumanFeedBackNeeded: false))
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
				return;
			case ActiveUnit._ActiveUnitStatus.OnPatrol:
			{
				if (method_15())
				{
					myUnit.SetThrottle(ActiveUnit.Throttle.FullStop);
					return;
				}
				Patrol patrol = (Patrol)myUnit.ActiveMissionOrPackage();
				if (Information.IsNothing((object)patrol))
				{
					myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
					break;
				}
				List<ReferencePoint> theArea_ChangeCheck;
				List<ReferencePoint> theArea_Buffer;
				if (myUnit.IsGroupMember())
				{
					if (myUnit.IsGroupLead())
					{
						if (!myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
						{
							myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlotCourseToStationArea(elapsedTime, AddWaypointToExistingPlottedCourse: false);
							return;
						}
						ActiveUnit_Navigator navigator = myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator;
						ref List<ReferencePoint> patrolArea = ref patrol.PatrolArea;
						theArea_Buffer = null;
						theArea_ChangeCheck = null;
						if (!navigator.PlottedCourseLeadsToMissionArea(ref patrolArea, ref theArea_Buffer, ref theArea_ChangeCheck, 0f, IgnoreTimeToNextEvaluation: false))
						{
							myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlotCourseToStationArea(elapsedTime, AddWaypointToExistingPlottedCourse: false);
						}
						myUnit.Navigator.FollowPlottedCourse(elapsedTime);
						return;
					}
					if (!myUnit.CommStuff.IsConnectedToSideNetwork)
					{
						break;
					}
					myUnit.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
					return;
				}
				if (!myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
				{
					myUnit.Navigator.PlotCourseToStationArea(elapsedTime, AddWaypointToExistingPlottedCourse: false);
					return;
				}
				ActiveUnit_Navigator navigator2 = myUnit.Navigator;
				ref List<ReferencePoint> patrolArea2 = ref patrol.PatrolArea;
				theArea_ChangeCheck = null;
				theArea_Buffer = null;
				if (!navigator2.PlottedCourseLeadsToMissionArea(ref patrolArea2, ref theArea_ChangeCheck, ref theArea_Buffer, 30f, IgnoreTimeToNextEvaluation: false))
				{
					myUnit.Navigator.PlotCourseToStationArea(elapsedTime, AddWaypointToExistingPlottedCourse: false);
				}
				myUnit.Navigator.FollowPlottedCourse(elapsedTime);
				return;
			}
			case ActiveUnit._ActiveUnitStatus.Tasked:
				if (IsEscort)
				{
					HeadToNearestEscortSubject();
				}
				break;
			case ActiveUnit._ActiveUnitStatus.OnFireMission:
				if (!method_15())
				{
					if (Information.IsNothing((object)myUnit.ActiveMissionOrPackage()))
					{
						myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
					}
					else if (myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.ArtyFireMission)
					{
						FireMission fireMission = (FireMission)myUnit.ActiveMissionOrPackage();
						if (fireMission != null && fireMission.UnitIsInFiringPosition(myUnit) == FireMission.UnitPositionStatus.OffMission)
						{
							myUnit.Navigator.PlotCourseToArea(fireMission.PositionArea);
							myUnit.SetThrottle(ActiveUnit.Throttle.Flank);
						}
					}
					break;
				}
				myUnit.SetThrottle(ActiveUnit.Throttle.FullStop);
				return;
			}
			if (myUnit.IsGroupMember() && myUnit.CommStuff.IsConnectedToSideNetwork)
			{
				if (!method_15())
				{
					myUnit.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
				}
				else
				{
					myUnit.SetThrottle(ActiveUnit.Throttle.FullStop);
				}
			}
			else
			{
				_ = myUnit.Status;
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

	static Facility_AI()
	{
		Class72.smethod_20();
	}
}
