using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ServiceStack.Text;

namespace Command_Core;

public sealed class Torpedo : Weapon
{
	private Torpedo_AI torpedo_AI_0;

	private Torpedo_Kinematics torpedo_Kinematics_0;

	public float MaxKinematicRange_Cruise;

	public float MaxKinematicRange_Full;

	public override Weapon_AI AI => torpedo_AI_0;

	public override Weapon_Kinematics Kinematics => torpedo_Kinematics_0;

	public Torpedo(ref Scenario theScen, string theGUID = null)
		: base(theScen, theGUID)
	{
		torpedo_AI_0 = new Torpedo_AI(this);
		ActiveUnit theUnit = this;
		torpedo_Kinematics_0 = new Torpedo_Kinematics(ref theUnit);
		IsWeapon = true;
		base.Type = _WeaponType.Torpedo;
		IsTorpedo = true;
	}

	public override float GetSpeedForETACalculation(float travelDistance_nm)
	{
		float maxSpeed = base.MaxSpeed;
		if (MaxPossibleThrottleSetting > Throttle.Cruise)
		{
			if (Kinematics.FuelNecessaryForThisDistance(travelDistance_nm, Throttle.MaxPossibleThrottle, ((Weapon)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), maxSpeed, CombatRadiusCalc: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false) < (float)FuelCapacityCurrent)
			{
				return maxSpeed;
			}
			return Kinematics.GetMaximumSpeed(((Weapon)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), Throttle.Cruise, ValidateAndFixAltitude: false, ConsiderDamage: false);
		}
		return maxSpeed;
	}

	public new static Torpedo FromXML_Private(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen, bool LoadStockComponents_Force)
	{
		Torpedo result;
		try
		{
			Torpedo torpedo = new Torpedo(ref theScen);
			torpedo.ParentScen = theScen;
			string innerText = Misc.GetNodeByName(theNode.ChildNodes, "ID").InnerText;
			if (theDictionary.ContainsKey(innerText))
			{
				result = (Torpedo)theDictionary[innerText];
			}
			else
			{
				torpedo.ObjectID_Set(innerText);
				if (theNode.ChildNodes.Count == 1)
				{
					theScen.UnitsForLateInstantiation.Add(theNode);
					result = torpedo;
				}
				else
				{
					theDictionary.TryAdd(torpedo.ObjectID, torpedo);
					int num = Conversions.ToInteger(Misc.GetNodeByName(theNode.ChildNodes, "DBID").InnerText);
					DBFunctions.GetWeapon(theScen.DBConnection, torpedo, num, theScen, LoadStockComponents_Force);
					if (LoadStockComponents_Force)
					{
						torpedo.method_3(ref theNode, ref theDictionary, ref theScen);
					}
					if (!LoadStockComponents_Force)
					{
						Weapon.LoadSavedComponents(torpedo, theScen, theNode, theDictionary);
					}
					Weapon.LoadMutableProperties(torpedo, theScen, theNode, theDictionary);
					float maximumAltitude = torpedo.Kinematics.GetMaximumAltitude();
					float minimumAltitude = torpedo.Kinematics.GetMinimumAltitude();
					if (((Weapon)torpedo).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > maximumAltitude)
					{
						((Weapon)torpedo).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, maximumAltitude);
					}
					else if (((Weapon)torpedo).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < minimumAltitude)
					{
						((Weapon)torpedo).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, minimumAltitude);
					}
					if (torpedo.DesiredAltitude > maximumAltitude)
					{
						torpedo.DesiredAltitude = maximumAltitude;
					}
					else if (torpedo.DesiredAltitude < minimumAltitude)
					{
						torpedo.DesiredAltitude = minimumAltitude;
					}
					if (torpedo.Sensors_Cached.Count() > 0)
					{
						torpedo.Flags.ReAttack_Capability = true;
					}
					result = torpedo;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100882", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Torpedo(ref theScen);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override void DoTypeSpecificActions(float elapsedTime, ref LockRandom theRNG)
	{
		try
		{
			if (((Module_Unit.Unit)this).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, ParentScen) >= 0)
			{
				Detonate(base.get_Latitude((GlobalVariables.BooleanObject)null), base.get_Longitude((GlobalVariables.BooleanObject)null), -1f, ref theRNG, Detonation_AddMessage: true);
			}
			base.TimeToReseek -= elapsedTime;
			if (base.TimeToReseek > 0f)
			{
				return;
			}
			if (base.TimeToReseek < 0f)
			{
				base.TimeToReseek = 0f;
			}
			switch (base.Guidance)
			{
			case WeaponGuidanceType.Passive:
				if (!GuidanceLogic_DestroyedOrVanishedPrimaryTarget_AutonomousWeapon() && !GuidanceLogic_Overshoot(60f, DropPrimaryTarget: true, DropDatalinkConnection: false, DropPlottedCourse: true, elapsedTime))
				{
				}
				break;
			case WeaponGuidanceType.Inertial_Plus_Passive:
				if (!GuidanceLogic_DestroyedOrVanishedPrimaryTarget_AutonomousWeapon() && !GuidanceLogic_Overshoot(60f, DropPrimaryTarget: true, DropDatalinkConnection: false, DropPlottedCourse: false, elapsedTime))
				{
				}
				break;
			case WeaponGuidanceType.DataLink_Plus_Passive:
				WeaponLogic_DatalinkedWeapons(elapsedTime);
				break;
			case WeaponGuidanceType.Active:
				if (!GuidanceLogic_DestroyedOrVanishedPrimaryTarget_AutonomousWeapon() && GuidanceLogic_Overshoot(60f, DropPrimaryTarget: true, DropDatalinkConnection: false, DropPlottedCourse: true, elapsedTime))
				{
					break;
				}
				if (!base.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
				{
					foreach (Sensor sensor in _Sensors)
					{
						if (sensor.CanBeActive && !sensor.IsActive())
						{
							sensor.GoActive();
						}
					}
				}
				else
				{
					HandleReachingActivationPoint();
				}
				break;
			case WeaponGuidanceType.Datalink_Plus_Active:
				if (_Sensors.Count > 0 && _Sensors[0].IsActive())
				{
					if (!GuidanceLogic_DatalinkParentNotAvailable(elapsedTime) && !((Torpedo_AI)AI).GuidanceLogic_DestroyedOrVanishedPrimaryTarget(elapsedTime) && !GuidanceLogic_Overshoot(60f, DropPrimaryTarget: true, DropDatalinkConnection: true, DropPlottedCourse: true, elapsedTime))
					{
					}
				}
				else
				{
					WeaponLogic_DatalinkedWeapons(elapsedTime);
					HandleReachingActivationPoint();
				}
				break;
			case WeaponGuidanceType.Inertial_Plus_Active:
				if ((GuidanceLogic_DestroyedOrVanishedPrimaryTarget_AutonomousWeapon() || !GuidanceLogic_Overshoot(60f, DropPrimaryTarget: true, DropDatalinkConnection: false, DropPlottedCourse: false, elapsedTime)) && _Sensors.Count > 0 && !_Sensors[0].IsActive())
				{
					HandleReachingActivationPoint();
				}
				break;
			case WeaponGuidanceType.CommandGuided_Datalinked:
				WeaponLogic_DatalinkedWeapons(elapsedTime);
				break;
			case WeaponGuidanceType.Inertial:
				method_44(elapsedTime, ref theRNG);
				break;
			case WeaponGuidanceType.TVM:
			case WeaponGuidanceType.BeamRiding:
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100905", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		if (base.DatalinkRetargetTime > 0f && !Information.IsNothing((object)AI.PrimaryTarget))
		{
			base.DatalinkRetargetTime = 0f;
		}
		try
		{
			if (ValidTargets.Mine && ((ActiveUnit)this).get_UnitSide(SetSideOnly: false).Contacts_NonAU.Count > 0 && !(AI.PrimaryTarget is ActivationPointContact) && !(AI.PrimaryTarget is AimpointContact))
			{
				foreach (Sensor sensor2 in _Sensors)
				{
					sensor2.GoActive();
				}
				List<UnguidedWeapon> list = new List<UnguidedWeapon>();
				foreach (string item in ((ActiveUnit)this).get_UnitSide(SetSideOnly: false).Contacts_NonAU)
				{
					UnguidedWeapon value = null;
					ParentScen.UnguidedWeapons.TryGetValue(item, out value);
					if (!Information.IsNothing((object)value) && value.IsMine && RangeToUnit_Horiz(value) < base.MaxSubsurfaceRange)
					{
						list.Add(value);
					}
				}
				UnguidedWeapon unguidedWeapon = null;
				if (list.Count > 0)
				{
					while (list.Count > 0)
					{
						unguidedWeapon = (from theMine in list.ToList()
							where theMine != null
							orderby Module_Unit.RangeToUnit_Horiz_Angular(this, theMine)
							select theMine).ElementAtOrDefault(0);
						if (unguidedWeapon == null)
						{
							break;
						}
						if (unguidedWeapon.Mine_Targeted == null)
						{
							float targetRange = Module_Unit.RangeToUnit_Slant(this, unguidedWeapon);
							if (((Module_Unit.Unit)unguidedWeapon).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < -5f)
							{
								foreach (Sensor sensor3 in _Sensors)
								{
									if (sensor3.IsSonar && sensor3.IsActive() && sensor3.IsOperating && (sensor3.get_SearchesInThisFrequency(Sensor.FrequencyBand.HF_Sonar) || sensor3.Capabilities.Mine_Obstacle_Search) && sensor3.CanDetectTarget_NonAU(this, unguidedWeapon, targetRange))
									{
										AimpointContact aimpointContact = new AimpointContact(((Module_Unit.Unit)unguidedWeapon).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)unguidedWeapon).get_Longitude((GlobalVariables.BooleanObject)null)) { [false, null] = ((Module_Unit.Unit)unguidedWeapon).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) };
										AI.PrimaryTarget = aimpointContact;
										unguidedWeapon.Mine_Targeted = this;
										base.Navigator.ClearPlottedCourse();
										Waypoint theWP = new Waypoint(((Module_Unit.Unit)unguidedWeapon).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)unguidedWeapon).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)unguidedWeapon).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), Waypoint.WaypointType.WeaponTarget, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse);
										base.Navigator.AddWaypoint(theWP);
										((ActiveUnit)this).set_DesiredHeading(TurnRate.Max, Math2.CalcAzimuth(base.get_Latitude((GlobalVariables.BooleanObject)null), base.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)aimpointContact).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)aimpointContact).get_Longitude((GlobalVariables.BooleanObject)null)));
										DesiredSpeed = 2f;
										if (!ParentScen.MineAllocation.ContainsKey(ObjectID))
										{
											ParentScen.MineAllocation.Add(ObjectID, unguidedWeapon);
										}
										goto end_IL_05c7;
									}
								}
							}
							list.Remove(unguidedWeapon);
							continue;
						}
						if (!unguidedWeapon.Mine_Targeted.Equals(this))
						{
							list.Remove(unguidedWeapon);
							continue;
						}
						if (AI.PrimaryTarget == null)
						{
							unguidedWeapon.Mine_Targeted = null;
						}
						break;
						continue;
						end_IL_05c7:
						break;
					}
				}
				else
				{
					ParentScen.MineAllocation.Remove(ObjectID);
				}
				if (_TimeToDetonate > 0f)
				{
					_TimeToDetonate -= elapsedTime;
					if (_TimeToDetonate <= 0f)
					{
						Detonate(base.get_Latitude((GlobalVariables.BooleanObject)null), base.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, ParentScen), ref theRNG, Detonation_AddMessage: true);
					}
				}
				AI.DetermineDesiredAltitude(elapsedTime);
				return;
			}
			if (ValidTargets.Mine && !base.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
			{
				AI.PrimaryTarget = null;
				((ActiveUnit)this).set_DesiredHeading(TurnRate.Max, CurrentHeading);
				AI.DetermineDesiredAltitude(elapsedTime);
			}
			if (ImpactsOnThisPulse_Contact && ValidTargets.Mine)
			{
				UnguidedWeapon value2 = null;
				if (ParentScen.MineAllocation.TryGetValue(ObjectID, ref value2))
				{
					if ((int)Math.Round((double)RangeToUnit_Horiz(value2) * 1852.0) < 20)
					{
						Detonate(base.get_Latitude((GlobalVariables.BooleanObject)null), base.get_Longitude((GlobalVariables.BooleanObject)null), ((Weapon)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ref theRNG, Detonation_AddMessage: true);
						if (!DetonationOccurs)
						{
							return;
						}
						value2.DestroyMe(ref ParentScen, "Mine detonated");
						if (base.IsMine)
						{
							((ActiveUnit)this).get_UnitSide(SetSideOnly: false).AAR.AddToLosses(value2, TreatAsAimpoint: false);
						}
						List<EventTrigger> list2 = new List<EventTrigger>();
						foreach (EventTrigger value3 in ParentScen.EventTriggers.Values)
						{
							if (value3.Type == EventTrigger.EventTriggerType.UnitDestroyed && ((EventTrigger_UnitDestroyed)value3).get_IsFulfilled(value2, (ActiveUnit)this))
							{
								list2.Add(value3);
							}
						}
						if (list2.Count > 0)
						{
							ParentScen.FireEvents(list2);
						}
						return;
					}
					if ((int)Math.Round((double)RangeToUnit_Horiz(value2) * 1852.0) < 500)
					{
						DesiredAltitude = ((Weapon)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
					}
				}
			}
			else if ((AI.PrimaryTarget != null && ImpactsOnThisPulse_ActualUnit) || ImpactsOnThisPulse_Contact)
			{
				float val;
				double theLon;
				double theLat;
				if (AI.PrimaryTarget != null)
				{
					val = ((AI.PrimaryTarget?.ActualUnit != null) ? ((Module_Unit.Unit)AI.PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) : Math.Max(((Module_Unit.Unit)AI.PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), -10f));
					theLon = ((Module_Unit.Unit)AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null);
					theLat = ((Module_Unit.Unit)AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null);
				}
				else
				{
					theLon = base.get_Longitude((GlobalVariables.BooleanObject)null);
					theLat = base.get_Latitude((GlobalVariables.BooleanObject)null);
					val = ((Weapon)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
				}
				if (Warheads.Length > 0 && Warheads[0].get_IsNuclear(ParentScen))
				{
					if (Information.IsNothing((object)AI.PrimaryTarget.ActualUnit))
					{
						Detonate(theLat, theLon, Math.Max(val, -10f), ref theRNG, Detonation_AddMessage: true);
						return;
					}
					ActiveUnit actualUnit = AI.PrimaryTarget.ActualUnit;
					Scenario parentScen = ParentScen;
					List<string> PointDefenceMessages = null;
					ResolveImpact(actualUnit, parentScen, IsPointDefenceMode: false, ref PointDefenceMessages);
					return;
				}
				if (!ImpactsOnThisPulse_ActualUnit)
				{
					if (AI.PrimaryTarget == null || !AI.PrimaryTarget.IsGroundContact)
					{
						AI.DropTarget(AI.PrimaryTarget);
						if (ValidTargets.Mine)
						{
							ParentScen.MineAllocation.Remove(ObjectID);
						}
						return;
					}
					Detonate(((Module_Unit.Unit)AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)AI.PrimaryTarget).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, ParentScen), ref theRNG, Detonation_AddMessage: true);
				}
				else
				{
					Contact primaryTarget = AI.PrimaryTarget;
					bool? flag = ((primaryTarget == null) ? ((bool?)null) : new bool?(primaryTarget.Type == Contact_Base.ContactType.Aimpoint));
					bool? flag2 = (!flag) ?? flag;
					if (flag2 ?? true)
					{
						Contact primaryTarget2 = AI.PrimaryTarget;
						flag = ((primaryTarget2 == null) ? ((bool?)null) : new bool?(primaryTarget2.Type == Contact_Base.ContactType.ActivationPoint));
						if (((!flag) ?? flag) == true && flag2.HasValue)
						{
							if (AI.PrimaryTarget.ActualUnit != null && AI.PrimaryTarget.ActualUnit.Weaponry != null)
							{
								if (!AI.PrimaryTarget.ActualUnit.IsTorpedo || ValidTargets.Torpedo)
								{
									ActiveUnit_Weaponry weaponry = AI.PrimaryTarget.ActualUnit.Weaponry;
									Weapon AttackWeapon = this;
									weaponry.ResolvePointDefence(elapsedTime, ref AttackWeapon);
								}
							}
							else
							{
								ParentScen.DestroyThisUnit(this, "Point defense resolution", "Weapon Interaction");
							}
						}
					}
				}
			}
			if (_TimeToDetonate > 0f)
			{
				_TimeToDetonate -= elapsedTime;
				if (_TimeToDetonate <= 0f)
				{
					Detonate(base.get_Latitude((GlobalVariables.BooleanObject)null), base.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)AI.PrimaryTarget).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, ParentScen), ref theRNG, Detonation_AddMessage: true);
				}
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 100906", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	protected override bool GuidanceLogic_DestroyedOrVanishedPrimaryTarget_DatalinkedWeapon(float elapsedTime)
	{
		bool result;
		try
		{
			float overshootThreshold_deg = 60f;
			if (base.DataLinkParent != null)
			{
				overshootThreshold_deg = 180f;
			}
			if (myTargetDoesNotExist())
			{
				AttemptRetargeting_Datalink(elapsedTime, overshootThreshold_deg);
				result = true;
			}
			else if (!Information.IsNothing((object)AI.PrimaryTarget) && !AI.PrimaryTarget.get_IsDestroyed(ParentScen))
			{
				if (AI.PrimaryTarget.Age > 30f && AI.PrimaryTarget.IsAir_Missile_Orbital_Contact && !base.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
				{
					int num;
					if (!base.HasGoneAutonomous)
					{
						GoAutonomous(clearPrimaryTarget: true, clearDatalink: true);
						AddMessage("Weapon: " + Name + " is not receiving firm target updates from parent unit... Going autonomous.", "Weapon issue", LoggedMessage.MessageType.WeaponLogic, 10, new Geopoint_Struct(base.get_Longitude((GlobalVariables.BooleanObject)null), base.get_Latitude((GlobalVariables.BooleanObject)null)));
						num = 1;
					}
					else
					{
						num = 1;
					}
					result = (byte)num != 0;
				}
				else
				{
					result = false;
				}
			}
			else
			{
				AttemptRetargeting_Datalink(elapsedTime, overshootThreshold_deg);
				result = true;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100935", "");
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
			result = (byte)num2 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	protected override void WeaponLogic_DatalinkedWeapons(float elapsedTime)
	{
		try
		{
			float overShootDegrees = 60f;
			if (base.DataLinkParent != null)
			{
				overShootDegrees = 180f;
			}
			if (!GuidanceLogic_DatalinkParentNotAvailable(elapsedTime) && !GuidanceLogic_DestroyedOrVanishedPrimaryTarget_DatalinkedWeapon(elapsedTime))
			{
				GuidanceLogic_Overshoot(overShootDegrees, DropPrimaryTarget: true, DropDatalinkConnection: true, DropPlottedCourse: true, elapsedTime);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100941", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void AttemptRetargeting_Datalink(float elapsedTime, float OvershootThreshold_deg)
	{
		try
		{
			if (base.Type == _WeaponType.Sonobuoy)
			{
				return;
			}
			Contact contact = null;
			if (AI.PrimaryTarget != null)
			{
				contact = AI.PrimaryTarget;
				Weapon_AI aI = AI;
				ActiveUnit theAU = this;
				aI.ClearAllTargets(ref theAU);
				if (!base.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
				{
					((ActiveUnit)this).set_DesiredHeading(TurnRate.Max, CurrentHeading);
				}
			}
			base.DatalinkRetargetTime += elapsedTime;
			if (!ParentScen.FifthSecondIsChangingOnThisPulse)
			{
				return;
			}
			List<Contact> list = new List<Contact>();
			List<Contact> list2 = new List<Contact>();
			if (AI.PrimaryTarget_Type == Contact_Base.ContactType.Air || AI.PrimaryTarget_Type == Contact_Base.ContactType.Missile || AI.PrimaryTarget_Type == Contact_Base.ContactType.Submarine || AI.PrimaryTarget_Type == Contact_Base.ContactType.Torpedo)
			{
				((ActiveUnit)this).get_UnitSide(SetSideOnly: false).RemoveWeaponFromSalvos(ref ParentScen, ref ObjectID);
			}
			if (base.DataLinkParent != null)
			{
				string text = "";
				string text2 = Module_ActiveUnit_Weaponry.ToEnglishString(ActiveUnit_Weaponry.DLZResultEnum.Fail_OutOfEnergy);
				Contact[] targets_ReadOnly = base.DataLinkParent.AI.Targets_ReadOnly;
				foreach (Contact contact2 in targets_ReadOnly)
				{
					string feedbackMessage = "";
					if (Math.Abs(Module_Unit.AngleOffThisUnitsBoresight(contact2, this, DistinguishBetweenStarboardAndPort: true, ref feedbackMessage, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue)) > OvershootThreshold_deg || contact == contact2)
					{
						continue;
					}
					bool? obj;
					if (contact2.get_Stance(base.DataLinkParent.get_UnitSide(SetSideOnly: false)) == Misc.PostureStance.Hostile)
					{
						obj = false;
					}
					else
					{
						byte? b = (byte?)base.DataLinkParent.Doctrine.get_WeaponControlStatus_Air(base.DataLinkParent.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false);
						bool? flag = ((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0));
						obj = (!flag) ?? flag;
					}
					bool? flag2 = obj;
					if ((!((!flag2) ?? false) && !contact2.IsSubmergedContact && flag2.HasValue) || !base.DataLinkParent.AI.IsClearedToEngageThisTarget(contact2))
					{
						continue;
					}
					try
					{
						if (base.DataLinkParent != null)
						{
							text = base.DataLinkParent.Weaponry.CanThisWeaponEngageThisTarget_AttemptRetargeting(this, contact2);
							if (Operators.CompareString(text, "OK", false) == 0)
							{
								goto IL_02c4;
							}
							if (Operators.CompareString(text, text2, false) == 0)
							{
								list2.Add(contact2);
							}
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2?.Data.Add("Error at 200048", ex2.Message);
						GameGeneral.WriteExceptionsToLog(ex2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
					continue;
					IL_02c4:
					if (contact2.Type == AI.PrimaryTarget_Type)
					{
						list.Add(contact2);
					}
					else
					{
						list2.Add(contact2);
					}
				}
				Weapon theWeapon;
				Contact theNewTarget;
				Weapon_AI aI2;
				switch (list.Count)
				{
				case 1:
					base.BlindTime = 0f;
					base.DatalinkRetargetTime = 0f;
					AI.PrimaryTarget = list[0];
					theWeapon = this;
					theNewTarget = (aI2 = AI).PrimaryTarget;
					CreateSalvo_Airborne(ref theWeapon, ref theNewTarget, ParentScen);
					aI2.PrimaryTarget = theNewTarget;
					AddMessage("Weapon: " + Name + " has only one alternative target to be redirected to: " + AI.PrimaryTarget.Name, "Weapon issue", LoggedMessage.MessageType.WeaponLogic, 10, new Geopoint_Struct(base.get_Longitude((GlobalVariables.BooleanObject)null), base.get_Latitude((GlobalVariables.BooleanObject)null)));
					return;
				case 0:
					AddMessage("Weapon: " + Name + " has no eligible alternative target to be redirected to...", "Weapon issue", LoggedMessage.MessageType.WeaponLogic, 10, new Geopoint_Struct(base.get_Longitude((GlobalVariables.BooleanObject)null), base.get_Latitude((GlobalVariables.BooleanObject)null)));
					switch (list2.Count)
					{
					default:
					{
						base.BlindTime = 0f;
						base.DatalinkRetargetTime = 0f;
						IEnumerable<Contact> source = from theC in list2
							orderby theC.IncomingGuidedWeapons.Length, Module_Unit.RangeToUnit_Horiz_Angular(this, theC)
							select theC;
						AI.PrimaryTarget = source.ElementAtOrDefault(0);
						theWeapon = this;
						theNewTarget = (aI2 = AI).PrimaryTarget;
						CreateSalvo_Airborne(ref theWeapon, ref theNewTarget, ParentScen);
						aI2.PrimaryTarget = theNewTarget;
						if (!Information.IsNothing((object)contact) && contact == AI.PrimaryTarget)
						{
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
						}
						else
						{
							AddMessage("Weapon: " + Name + " has been redirected to new target: " + AI.PrimaryTarget.Name, "Weapon issue", LoggedMessage.MessageType.WeaponLogic, 10, new Geopoint_Struct(base.get_Longitude((GlobalVariables.BooleanObject)null), base.get_Latitude((GlobalVariables.BooleanObject)null)));
						}
						break;
					}
					case 1:
						base.BlindTime = 0f;
						base.DatalinkRetargetTime = 0f;
						AI.PrimaryTarget = list2[0];
						theWeapon = this;
						theNewTarget = (aI2 = AI).PrimaryTarget;
						CreateSalvo_Airborne(ref theWeapon, ref theNewTarget, ParentScen);
						aI2.PrimaryTarget = theNewTarget;
						AddMessage("Weapon: " + Name + " has only one alternative (secondary) target to be redirected to: " + AI.PrimaryTarget.Name, "Weapon issue", LoggedMessage.MessageType.WeaponLogic, 10, new Geopoint_Struct(base.get_Longitude((GlobalVariables.BooleanObject)null), base.get_Latitude((GlobalVariables.BooleanObject)null)));
						break;
					case 0:
						if (AI.PrimaryTarget_Type != Contact_Base.ContactType.Surface && AI.PrimaryTarget_Type != Contact_Base.ContactType.Submarine && AI.PrimaryTarget_Type != Contact_Base.ContactType.Facility_Fixed && AI.PrimaryTarget_Type != Contact_Base.ContactType.Facility_Mobile && AI.PrimaryTarget_Type != Contact_Base.ContactType.AggregateGroundUnit)
						{
							if (!(base.DatalinkRetargetTime >= 11f))
							{
								break;
							}
							if (!base.IsAAWCapable)
							{
								if (AI.PrimaryTarget_Type != Contact_Base.ContactType.ActivationPoint)
								{
									GoAutonomous(clearPrimaryTarget: true, clearDatalink: true, clearPlottedCourse: true);
									return;
								}
							}
							else
							{
								GoAutonomous(clearPrimaryTarget: true, clearDatalink: true, clearPlottedCourse: true);
								if (base.Guidance != WeaponGuidanceType.Active && base.Guidance != WeaponGuidanceType.Passive && base.Guidance != WeaponGuidanceType.SemiActive_Plus_Active && base.Guidance != WeaponGuidanceType.TimesharedSemiActive_Plus_Active && _Sensors.Count <= 1)
								{
									AddMessage("Weapon: " + Name + " has no eligible alternative target to be redirected to...", "Weapon issue", LoggedMessage.MessageType.WeaponLogic, 10, new Geopoint_Struct(base.get_Longitude((GlobalVariables.BooleanObject)null), base.get_Latitude((GlobalVariables.BooleanObject)null)));
								}
								else
								{
									AddMessage("Weapon: " + Name + " has no eligible alternative target to be redirected to... going autonomous.", "Weapon issue", LoggedMessage.MessageType.WeaponLogic, 10, new Geopoint_Struct(base.get_Longitude((GlobalVariables.BooleanObject)null), base.get_Latitude((GlobalVariables.BooleanObject)null)));
								}
							}
						}
						else
						{
							if (_Sensors.Count > 0 && ValidTargets.Radar && base.Is_LOAL_capable)
							{
								GoAutonomous(clearPrimaryTarget: true, clearDatalink: true, clearPlottedCourse: true);
								return;
							}
							GoDumb();
						}
						break;
					}
					if (!Information.IsNothing((object)AI.PrimaryTarget) && base.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
					{
						base.Navigator.ComputeTerminalPoint(Kinematics.GetMaximumSpeed(((Weapon)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ThrottleSetting, ValidateAndFixAltitude: false), IsAirdroppedTorpedo: false);
						if (base.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
						{
							((ActiveUnit)this).set_DesiredHeading(TurnRate.Max, Math2.CalcAzimuth(base.get_Latitude((GlobalVariables.BooleanObject)null), base.get_Longitude((GlobalVariables.BooleanObject)null), base.Navigator.PlottedCourse[0].Latitude, base.Navigator.PlottedCourse[0].Longitude));
						}
					}
					return;
				}
				base.BlindTime = 0f;
				base.DatalinkRetargetTime = 0f;
				IEnumerable<Contact> source2 = from theC in list
					orderby theC.IncomingGuidedWeapons.Length, Module_Unit.RangeToUnit_Horiz_Angular(this, theC)
					select theC;
				AI.PrimaryTarget = source2.ElementAtOrDefault(0);
				theWeapon = this;
				theNewTarget = (aI2 = AI).PrimaryTarget;
				CreateSalvo_Airborne(ref theWeapon, ref theNewTarget, ParentScen);
				aI2.PrimaryTarget = theNewTarget;
				if (!Information.IsNothing((object)contact) && contact == AI.PrimaryTarget)
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
				}
				else
				{
					AddMessage("Weapon: " + Name + " has been redirected to new target: " + AI.PrimaryTarget.Name, "Weapon issue", LoggedMessage.MessageType.WeaponLogic, 10, new Geopoint_Struct(base.get_Longitude((GlobalVariables.BooleanObject)null), base.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
			}
			else
			{
				base.DatalinkRetargetTime = 0f;
				GoAutonomous(clearPrimaryTarget: true, clearDatalink: true);
				if (base.Guidance == WeaponGuidanceType.Datalink_Plus_Active)
				{
					AddMessage("Weapon: " + Name + " has no eligible alternative target to be redirected to... going autonomous.", "Weapon issue", LoggedMessage.MessageType.WeaponLogic, 10, new Geopoint_Struct(base.get_Longitude((GlobalVariables.BooleanObject)null), base.get_Latitude((GlobalVariables.BooleanObject)null)));
					return;
				}
				AddMessage("Weapon: " + Name + " lost datalink connection...", "Weapon issue", LoggedMessage.MessageType.WeaponLogic, 10, new Geopoint_Struct(base.get_Longitude((GlobalVariables.BooleanObject)null), base.get_Latitude((GlobalVariables.BooleanObject)null)));
				AI.PrimaryTarget = null;
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 100947T", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override bool AboutToImpact_ActualTarget(float elapsedTime)
	{
		if (AI.PrimaryTarget == null)
		{
			return false;
		}
		if (AI.PrimaryTarget.ActualUnit != null)
		{
			float num = Module_Unit.BearingToPoint_Relative(this, ((Module_Unit.Unit)AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null));
			if (num > 90f && num < 270f)
			{
				return false;
			}
			if (Math.Abs(((Weapon)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - AI.PrimaryTarget.ActualUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) < 20f)
			{
				switch (AI.PrimaryTarget.ActualUnit.UnitType)
				{
				case GlobalVariables.ActiveUnitType.Submarine:
				{
					double num2 = (double)((Submarine)AI.PrimaryTarget.ActualUnit).Length * 0.000539957;
					if ((double)RangeToUnit_Horiz(AI.PrimaryTarget.ActualUnit) < num2)
					{
						return true;
					}
					break;
				}
				case GlobalVariables.ActiveUnitType.Ship:
				{
					double num2 = (double)((Ship)AI.PrimaryTarget.ActualUnit).Length * 0.000539957;
					if ((double)RangeToUnit_Horiz(AI.PrimaryTarget.ActualUnit) < num2)
					{
						return true;
					}
					break;
				}
				}
			}
			return base.AboutToImpact_ActualTarget(elapsedTime);
		}
		return false;
	}

	private void method_44(float float_25, ref LockRandom lockRandom_0)
	{
		try
		{
			if (IsNuke.Value)
			{
				if (!base.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
				{
					Detonate(base.get_Latitude((GlobalVariables.BooleanObject)null), base.get_Longitude((GlobalVariables.BooleanObject)null), ((Weapon)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ref lockRandom_0, Detonation_AddMessage: true);
					ParentScen.DestroyThisUnit(this, "Nuclear armed torpedo intentionally deonated.", "Impact / Detonation");
				}
			}
			else
			{
				if (!base.IsArmed)
				{
					return;
				}
				float num = CurrentSpeed / 3600f * float_25;
				List<ActiveUnit> list = new List<ActiveUnit>();
				float num2 = default(float);
				foreach (ActiveUnit activeUnits_ in ParentScen.ActiveUnits_List)
				{
					if (activeUnits_ == null || (!activeUnits_.IsShip && !activeUnits_.IsSubmarine && (!activeUnits_.IsFacility || Module_Unit.IsOverLand(activeUnits_))) || !(Math.Round(activeUnits_.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) >= -20.0))
					{
						continue;
					}
					float relativeBearing = MathFunctions.GetRelativeBearing(CurrentHeading, Math2.CalcAzimuth(base.get_Latitude((GlobalVariables.BooleanObject)null), base.get_Longitude((GlobalVariables.BooleanObject)null), activeUnits_.get_Latitude((GlobalVariables.BooleanObject)null), activeUnits_.get_Longitude((GlobalVariables.BooleanObject)null)));
					if (!(270f > relativeBearing) || !(relativeBearing > 90f))
					{
						if (activeUnits_.IsShip)
						{
							num2 = ((Ship)activeUnits_).Length / 2f;
						}
						else if (activeUnits_.IsSubmarine)
						{
							num2 = ((Submarine)activeUnits_).Length / 2f;
						}
						else if (activeUnits_.IsFacility)
						{
							num2 = (float)Math.Sqrt(((Facility)activeUnits_).Area / 3.14159265358979);
						}
						float num3 = num2 / 1852f;
						float num4 = RangeToUnit_Horiz(activeUnits_);
						if (num4 <= num3)
						{
							list.Add(activeUnits_);
						}
						else if (num4 <= num)
						{
							list.Add(activeUnits_);
						}
					}
				}
				switch (list.Count)
				{
				case 1:
				{
					ActiveUnit theTarget2 = list[0];
					Scenario parentScen2 = ParentScen;
					List<string> PointDefenceMessages = null;
					ResolveImpact(theTarget2, parentScen2, IsPointDefenceMode: false, ref PointDefenceMessages);
					break;
				}
				default:
				{
					ActiveUnit theTarget = list[lockRandom_0.Next(list.Count - 1)];
					Scenario parentScen = ParentScen;
					List<string> PointDefenceMessages = null;
					ResolveImpact(theTarget, parentScen, IsPointDefenceMode: false, ref PointDefenceMessages);
					break;
				}
				case 0:
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100940", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override bool ResolveImpact(ActiveUnit theTarget, Scenario theScen, bool IsPointDefenceMode, ref List<string> PointDefenceMessages)
	{
		bool result;
		if (this != null)
		{
			if (!IsMorituri)
			{
				LockRandom theRNG = GameGeneral.GlobalRNG;
				try
				{
					StringBuilder stringBuilder = StringBuilderCache.Allocate();
					bool flag = false;
					bool flag2 = false;
					float num = default(float);
					if (theTarget.IsShip)
					{
						num = SurfPOK;
						goto IL_00b7;
					}
					if (theTarget.IsSubmarine)
					{
						num = SubPOK;
						if (num == 0f && theTarget.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) == 0f)
						{
							num = SurfPOK;
						}
						goto IL_00b7;
					}
					if (!theTarget.IsFacility)
					{
						if (theTarget.IsTorpedo)
						{
							num = SubPOK;
						}
						goto IL_00b7;
					}
					bool num2 = Impact_CEP(theTarget, ref theScen, ref theRNG);
					ParentScen.DestroyThisUnit(this, $"Torpedo impacted facility {theTarget.Name}", "Impact / Detonation");
					result = num2;
					goto end_IL_0018;
					IL_00b7:
					if (!string.IsNullOrEmpty(Name))
					{
						_ = Name;
					}
					if (!IsNuke.Value)
					{
						string text = ((!theTarget.IsAircraft || Operators.CompareString(theTarget.Name, theTarget.UnitClass, false) == 0) ? theTarget.Name : (theTarget.Name + " (" + theTarget.UnitClass + ")"));
						stringBuilder.Append("Torpedo " + Name + " is attacking " + text + " with a base PH of " + Conversions.ToString(Math.Round(num, 2)) + "%. ");
						float num3 = num;
						if (theTarget.IsTorpedo)
						{
							stringBuilder.Append("Target is torpedo - hit probability halved. ");
							num3 = (float)((double)num3 * 0.5);
						}
						if (num3 < 0f)
						{
							num3 = 1f;
						}
						stringBuilder.Append("Final PH: " + Conversions.ToString((int)Math.Round(num3)) + "% ");
						int num4 = theRNG.Next(1, 101);
						if ((float)num4 <= num3)
						{
							stringBuilder.Append("Result: " + Conversions.ToString(num4) + " - HIT");
							flag = true;
						}
						else
						{
							stringBuilder.Append("Result: " + Conversions.ToString(num4));
							if (!Flags.ReAttack_Capability)
							{
								stringBuilder.Append(" - MISS");
								if (Warheads.Length > 0 && theTarget.IsFacility && Warheads[0].IsExplosive)
								{
									float num5 = default(float);
									num5 = theRNG.Next(0, 359);
									float num6 = theRNG.Next(1, 50);
									stringBuilder.Append(" (Near miss: " + Conversions.ToString(num6) + "m)");
									ActiveUnit_Damage damage = theTarget.Damage;
									GeoPoint launchPoint = LaunchPoint;
									float bearingFromImpact = num5;
									string PreferredAimpoint = "";
									damage.ResolveDamageFromWeapon(this, launchPoint, num6, bearingFromImpact, null, null, null, null, ref PreferredAimpoint, DirectHit: false, null);
								}
							}
							else
							{
								float num7 = num3 / 4f;
								if ((float)theRNG.Next(1, 101) < num7)
								{
									stringBuilder.Append(" - MISS - NO REATTACK (DUD)");
								}
								else
								{
									stringBuilder.Append(" - MISS - REATTACK");
									PrepareForReattack(theTarget);
									flag2 = true;
								}
							}
						}
						if (flag)
						{
							_ = Name + " impacted " + theTarget.Name;
						}
						else if (flag2)
						{
							_ = Name + " missed and re-attacks";
						}
						else
						{
							_ = Name + " missed";
						}
						base.EndgameReport.AddEndGameMessage(flag, stringBuilder.ToString());
						if (flag2)
						{
							base.EndgameReport.ReportEndgameAfterReattackTriggered(ParentScen);
						}
						if (PointDefenceMessages != null)
						{
							PointDefenceMessages.Add(stringBuilder.ToString());
						}
						DetonationOccurs = true;
						if (flag)
						{
							smethod_4(this, theTarget);
							Impact(theTarget, stringBuilder);
						}
						if (flag || !flag2)
						{
							ParentScen.DestroyThisUnit(this, $"Torpedo impacted target {theTarget.Name}", "Impact / Detonation");
						}
						result = flag;
					}
					else
					{
						if ((float)theRNG.Next(1, 101) < num)
						{
							stringBuilder.Append("Torpedo " + Name + " is detonating its nuclear warhead.");
							Detonate(base.get_Latitude((GlobalVariables.BooleanObject)null), base.get_Longitude((GlobalVariables.BooleanObject)null), ImpactAltitude, ref theRNG, Detonation_AddMessage: true);
						}
						else
						{
							stringBuilder.Append("Torpedo " + Name + " failed to detonate its nuclear warhead (Dud!)");
						}
						smethod_4(this, theTarget);
						ParentScen.DestroyThisUnit(this, "Nuclear torpedo intentionally detonated warhead.", "Impact / Detonation");
						result = false;
					}
					end_IL_0018:;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 10032450394504329634901293", "");
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
					result = (byte)num8 != 0;
					ProjectData.ClearProjectError();
				}
			}
			else
			{
				result = false;
			}
		}
		else
		{
			result = false;
		}
		return result;
	}

	private static void smethod_4(Weapon weapon_0, object object_0)
	{
		if (weapon_0.FiringParent == null || !weapon_0.FiringParent.IsSubmarine)
		{
			return;
		}
		bool flag = false;
		foreach (Contact contacts_ in ((ActiveUnit)object_0).get_UnitSide(SetSideOnly: false).Contacts_List)
		{
			if (contacts_.Type == Contact_Base.ContactType.Submarine && ((ActiveUnit)object_0).RangeToUnit_Horiz((Module_Unit.Unit)contacts_, (GlobalVariables.BooleanObject)null, (GlobalVariables.BooleanObject)null) <= 15f && !(Math.Abs(MathFunctions.AngularDifference(Math2.CalcAzimuth(((ActiveUnit)object_0).get_Latitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)object_0).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contacts_).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contacts_).get_Longitude((GlobalVariables.BooleanObject)null)), Math2.CalcAzimuth(((ActiveUnit)object_0).get_Latitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)object_0).get_Longitude((GlobalVariables.BooleanObject)null), weapon_0.FiringParent.get_Latitude((GlobalVariables.BooleanObject)null), weapon_0.FiringParent.get_Longitude((GlobalVariables.BooleanObject)null)))) >= 45f))
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			return;
		}
		bool flag2 = default(bool);
		foreach (Contact contacts_2 in ((ActiveUnit)object_0).get_UnitSide(SetSideOnly: false).Contacts_List)
		{
			if (contacts_2.Type == Contact_Base.ContactType.Submarine && contacts_2.ActualUnit == weapon_0.FiringParent)
			{
				flag2 = true;
				break;
			}
		}
		if (!flag2)
		{
			Contact contact = Contact.Instantiate(weapon_0.FiringParent);
			((Module_Unit.Unit)contact).set_Latitude((GlobalVariables.BooleanObject)null, ((ActiveUnit)object_0).get_Latitude((GlobalVariables.BooleanObject)null));
			((Module_Unit.Unit)contact).set_Longitude((GlobalVariables.BooleanObject)null, ((ActiveUnit)object_0).get_Longitude((GlobalVariables.BooleanObject)null));
			Geodesic_Vincenty.Point3D[] CirclePoints = new Geodesic_Vincenty.Point3D[46];
			Geodesic_EdWilliams.CircleFromPoint(((Module_Unit.Unit)contact).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact).get_Longitude((GlobalVariables.BooleanObject)null), 15.0, 45, ref CirclePoints);
			List<Geopoint_Struct> list = new List<Geopoint_Struct>(CirclePoints.Length);
			Geodesic_Vincenty.Point3D[] array = CirclePoints;
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				Geodesic_Vincenty.Point3D point3D = array[i];
				list.Add(new Geopoint_Struct(point3D.X, point3D.Y));
			}
			contact.UncertaintyArea = list;
			((ActiveUnit)object_0).get_UnitSide(SetSideOnly: false).SpecialDetections.Enqueue((contact, weapon_0.FiringParent, new List<Sensor>(), 0f, ActiveUnit_Sensory.SpecialDetectionMode.FlamingDatum, ((ActiveUnit)object_0).ParentScen.Time, new List<Geopoint_Struct>()));
		}
	}

	protected override void HandleReachingActivationPoint()
	{
		if (base.Guidance != WeaponGuidanceType.Inertial && !base.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
		{
			GoAutonomous(!Information.IsNothing((object)AI.PrimaryTarget) && AI.PrimaryTarget.Type == Contact_Base.ContactType.ActivationPoint);
		}
	}

	static Torpedo()
	{
		Class72.smethod_20();
	}
}
