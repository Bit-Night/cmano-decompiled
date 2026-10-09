using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Xml;
using Collections.Pooled;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ThreadSafeCollections;

namespace Command_Core;

public sealed class Ship_AI : ActiveUnit_AI
{
	[CompilerGenerated]
	internal sealed class _Closure$__14-0
	{
		public ObservableDictionary<string, UnguidedWeapon> $VB$Local_WeaponsDic;

		public List<ReferencePoint> $VB$Local_MissionArea;

		public TList<UnguidedWeapon> $VB$Local_LegitTargets;

		public MineClearingMission $VB$Local_myMission;

		public Ship_AI $VB$Me;

		public _Closure$__14-0(_Closure$__14-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_WeaponsDic = arg0.$VB$Local_WeaponsDic;
				$VB$Local_MissionArea = arg0.$VB$Local_MissionArea;
				$VB$Local_LegitTargets = arg0.$VB$Local_LegitTargets;
				$VB$Local_myMission = arg0.$VB$Local_myMission;
			}
		}

		[SpecialName]
		internal void _Lambda$__0(string theUW_ObjectID)
		{
			if (theUW_ObjectID == null)
			{
				return;
			}
			UnguidedWeapon value = default(UnguidedWeapon);
			$VB$Local_WeaponsDic.TryGetValue(theUW_ObjectID, ref value);
			if (!Information.IsNothing((object)value) && value.IsMine)
			{
				if (((Module_Unit.Unit)value).get_IsInsideThisArea($VB$Local_MissionArea, $VB$Me.myUnit.ParentScen, UseCache: true))
				{
					$VB$Local_LegitTargets.Add(value);
				}
				else if ($VB$Local_myMission.MovementStyle == Mission.MissionMovementStyle.RepeatableLoop && $VB$Me.myUnit.Navigator.IsInsideMissionArea(ref $VB$Local_MissionArea, ref $VB$Local_myMission.Area_2nm_Buffered, ref $VB$Local_myMission.Area_2nm_ChangeCheck, 2, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
				{
					$VB$Local_LegitTargets.Add(value);
				}
			}
		}

		static _Closure$__14-0()
		{
			Class72.smethod_20();
		}
	}

	private bool bool_0;

	private HashSet<string> hashSet_0;

	public static Ship_AI FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_0412: Unknown result type (might be due to invalid IL or missing references)
		//IL_0419: Expected O, but got Unknown
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Expected O, but got Unknown
		Ship_AI result = default(Ship_AI);
		try
		{
			Ship_AI ship_AI = new Ship_AI(ref theAU);
			ship_AI.myUnit = theAU;
			if (Operators.CompareString(theNode.ChildNodes[0].Name, "ActiveUnit_AI", false) == 0)
			{
				theNode = theNode.ChildNodes[0];
			}
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode theNode2 = childNode;
				switch (theNode2.Name)
				{
				case "IE":
					ship_AI.IsEscort = true;
					break;
				case "DPT_E":
					ship_AI.DeterminePrimaryTarget_Enabled = Misc.ParseBool(theNode2.InnerText);
					break;
				case "PrimaryTarget_LastKnown_Lon":
					ship_AI.PrimaryTarget_LastKnown_Lon = XmlConvert.ToDouble(theNode2.InnerText);
					break;
				case "TTNPTE":
					ship_AI.TimeToNextTargetsEvaluation = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
					break;
				case "PrimaryTarget":
					ship_AI._PrimaryTarget = Contact.FromXML(theNode2.InnerText, ref theDictionary);
					break;
				case "MSF":
					uint.TryParse(theNode2.InnerText, out ship_AI._Mission_State_Flags);
					break;
				case "Threats":
					if (ship_AI._Threats == null)
					{
						ship_AI._Threats = new List<Contact>();
					}
					foreach (XmlNode childNode2 in theNode2.ChildNodes)
					{
						XmlNode theNode4 = childNode2;
						Contact item = Contact.FromXML(ref theNode4, ref theDictionary);
						ship_AI._Threats.Add(item);
					}
					break;
				case "PrimaryThreat":
					ship_AI._PrimaryThreat = Contact.FromXML(theNode2.InnerText, ref theDictionary);
					break;
				case "FerryCycleLegIsOutbound":
				case "FCLIO":
					ship_AI.SetMissionStateFlag(4u, Misc.ParseBool(theNode2.InnerText));
					break;
				case "PrimaryTarget_LastKnown_Lat":
					ship_AI.PrimaryTarget_LastKnown_Lat = XmlConvert.ToDouble(theNode2.InnerText);
					break;
				case "PrimaryPickupTarget":
					ship_AI._PrimaryPickupTarget = ActiveUnit.FromXML(theNode2.InnerText, ref theDictionary);
					break;
				case "TargetList":
					ship_AI._TargetList = new ObservableDictionary<string, TargetingEntry>();
					foreach (XmlNode childNode3 in theNode2.ChildNodes)
					{
						XmlNode theNode3 = childNode3;
						TargetingEntry targetingEntry = TargetingEntry.FromXML(ref theNode3, ref theDictionary);
						if (targetingEntry.Target == null)
						{
							continue;
						}
						try
						{
							ship_AI._TargetList.Add(targetingEntry.Target.ObjectID, targetingEntry);
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception ex2 = ex;
							ex2?.Data.Add("Error at 200037", ex2.Message);
							GameGeneral.WriteExceptionsToLog(ex2);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					ship_AI.TargetsSortedByRange = ship_AI.SortTargetsByRange_ReadOnly;
					break;
				case "ET_E":
					ship_AI.EvaluateTargets_Enabled = Misc.ParseBool(theNode2.InnerText);
					break;
				case "PTOE":
				case "PrimaryTargetOverrideExists":
					ship_AI.PrimaryTargetOverrideExists = Misc.ParseBool(theNode2.InnerText);
					break;
				case "PrimaryTarget_LastKnown_Alt":
					ship_AI.PrimaryTarget_LastKnown_Altitude = XmlConvert.ToSingle(theNode2.InnerText);
					break;
				case "IgnorePlottedCourse":
				case "IPC":
				{
					bool num = Misc.ParseBool(theNode2.InnerText);
					if (!Information.IsNothing((object)theAU.Doctrine))
					{
						theAU.Doctrine.set_IgnorePlottedCourse(theAU.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._UseIgnorePlottedCourse?)(Doctrine._UseIgnorePlottedCourse)(0u - (Misc.ParseBool(theNode2.InnerText) ? 1u : 0u)));
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
				case "MiningInformation":
					ship_AI.MiningInfo = MiningMission.MiningInformation.FromXML(ref theNode2, ref theDictionary, ship_AI);
					break;
				}
			}
			result = ship_AI;
			return result;
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 100773", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public Ship_AI(ref ActiveUnit theUnit)
		: base(theUnit)
	{
		bool_0 = false;
		hashSet_0 = new HashSet<string>();
	}

	public override Geopoint_Struct? Manouver_InterceptCourse(float elapsedTime, float? EstimatedAverageSpeed, ref bool AllowAfterburner)
	{
		Geopoint_Struct? result = default(Geopoint_Struct?);
		try
		{
			if (PrimaryTarget == null)
			{
				result = null;
			}
			else
			{
				if (myUnit.Navigator.PlottedCourse == null || myUnit.Navigator.PlottedCourse.Length <= 0 || myUnit.Navigator.PlottedCourse[0].Type != Waypoint.WaypointType.LocalizationRun)
				{
					goto IL_00e3;
				}
				if (PrimaryTarget.UncertaintyArea == null)
				{
					myUnit.Navigator.ApplyWaypointSpeedAltToUnit(myUnit.Navigator.PlottedCourse[0]);
					myUnit.Navigator.ApplyWaypointDoctrineToUnit(myUnit.Navigator.PlottedCourse[0]);
					myUnit.Navigator.RemoveWaypoint_Soft(myUnit.Navigator.PlottedCourse[0], RemoveWingmanWaypoints: false);
					goto IL_00e3;
				}
				result = null;
			}
			goto end_IL_0001;
			IL_00e3:
			if (!PrimaryTarget.AppearsToBeLoitering && PrimaryTarget.HeadingIsKnown && PrimaryTarget.SpeedIsKnown)
			{
				float interceptVelocity = ((!EstimatedAverageSpeed.HasValue) ? myUnit.CurrentSpeed : EstimatedAverageSpeed.Value);
				Weapon weapon = myUnit.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, CheckIfWithinRange: false, CheckIfWithinAltitude: false, CheckWRA: true, myUnit.Doctrine);
				if (weapon != null)
				{
					if (weapon.MinAirRange > 0f && myUnit.RangeToUnit_Horiz(PrimaryTarget) <= weapon.MinAirRange)
					{
						myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, Math2.NormalizeBearing(Module_Unit.BearingToUnit_True(myUnit, PrimaryTarget) + 90f));
						result = PrimaryTarget.Location;
						return result;
					}
					if (weapon.Flags.RearAspect_AAM || weapon.Flags.SternChase_AAM)
					{
						double out_lon = default(double);
						double out_lat = default(double);
						Geodesic_EdWilliams.CalcPoint_Williams(((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, weapon.MinAirRange + 1f, Math2.NormalizeBearing(PrimaryTarget.CurrentHeading + 180f));
						myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, Module_Unit.BearingToPoint_True(myUnit, out_lat, out_lon));
						result = new Geopoint_Struct(out_lon, out_lat);
						return result;
					}
				}
				double? num = ActiveUnit_Navigator.CalculateInterceptHeading(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.CurrentHeading, PrimaryTarget, interceptVelocity);
				if (num.HasValue)
				{
					myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, (float)num.Value);
				}
				else if (myUnit.CurrentSpeed < PrimaryTarget.CurrentSpeed)
				{
					if (Math.Abs(MathFunctions.AngularDifference(myUnit.DesiredHeading, Module_Unit.BearingToUnit_True(myUnit, PrimaryTarget))) > 15f)
					{
						Manouver_PurePursuit(elapsedTime, 0f, 0f);
					}
					AllowAfterburner = true;
				}
				else
				{
					Manouver_PurePursuit(elapsedTime, 0f, 0f);
					AllowAfterburner = true;
				}
			}
			else
			{
				Manouver_PurePursuit(elapsedTime, 0f, 0f);
				result = null;
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100052", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override void ManoueverTorpedoEvasion(float elapsedTime, Contact TorpedoThreat)
	{
		if (TorpedoThreat == null)
		{
			return;
		}
		float num = Module_Unit.RangeToPoint_Horiz(myUnit, ((Module_Unit.Unit)TorpedoThreat).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)TorpedoThreat).get_Longitude((GlobalVariables.BooleanObject)null));
		Weapon theW = myUnit.Weaponry.MostSuitableWeaponForThisTarget(TorpedoThreat, CheckIfWithinRange: true, CheckIfWithinAltitude: true, CheckWRA: true, myUnit.Doctrine);
		if (theW != null && theW.Type != Weapon._WeaponType.Decoy_Expendable && theW.Type != Weapon._WeaponType.Decoy_Towed && IsClearedToEngageThisTarget(TorpedoThreat) && num <= theW.get_MaxRangeForThisTarget(myUnit, TorpedoThreat, CheckWRA: true, myUnit.Doctrine, ManualFire: false))
		{
			myUnit.SetThrottle(ActiveUnit.Throttle.Flank);
			(Mount, float, bool) theMountDetails = default((Mount, float, bool));
			TurnToUnmaskPrimaryWeapon(ref theW, TorpedoThreat, ref theMountDetails);
			return;
		}
		if (EvasionManeuver != null)
		{
			if (myUnit.ParentScen.SecondIsChangingOnThisPulse)
			{
				if (TorpedoThreat != EvasionManeuver.TargetContact)
				{
					EvasionManeuver = null;
				}
				else if (num < ActiveUnit_AI.TorpedoEvasionEmergencyRange && EvasionManeuver.OriginalRange > ActiveUnit_AI.TorpedoEvasionEmergencyRange)
				{
					EvasionManeuver = null;
				}
			}
			if (EvasionManeuver != null)
			{
				ExecuteManeuver(EvasionManeuver);
				return;
			}
		}
		float num2 = (float)Math.Round(Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)TorpedoThreat).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)TorpedoThreat).get_Longitude((GlobalVariables.BooleanObject)null)), 0);
		ActiveUnit observerUnit = myUnit;
		string feedbackMessage = "";
		float num3 = Module_Unit.AngleOffThisUnitsBoresight(TorpedoThreat, observerUnit, DistinguishBetweenStarboardAndPort: true, ref feedbackMessage, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
		bool flag;
		if (!(flag = num > ActiveUnit_AI.TorpedoEvasionCloseRange) && TorpedoThreat.ActualUnit != null && TorpedoThreat.ActualUnit.IsWeapon && TorpedoThreat.IDStatus >= Contact_Base.IdentificationStatus.KnownClass && TorpedoThreat.HeadingIsKnown && ((Weapon)TorpedoThreat.ActualUnit).Guidance == Weapon.WeaponGuidanceType.Inertial)
		{
			flag = true;
		}
		float num4;
		bool flag2;
		if (flag)
		{
			num4 = TorpedoThreat.CurrentHeading;
			flag2 = false;
			if (!TorpedoThreat.HeadingIsKnown)
			{
				num4 = Math2.NormalizeBearing(num2 + 180f);
				flag2 = true;
			}
			else
			{
				float num5 = Math.Abs(MathFunctions.AngularDifference(num2, num4));
				int num6;
				if (!(num5 < 2.5f))
				{
					if (!((double)num5 > 177.5) || !((double)num5 < 182.5))
					{
						flag2 = !MathFunctions.Intersection(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.DesiredHeading, ((Module_Unit.Unit)TorpedoThreat).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)TorpedoThreat).get_Longitude((GlobalVariables.BooleanObject)null), num4).HasZeroCoords;
						goto IL_026d;
					}
					num6 = 1;
				}
				else
				{
					num6 = 1;
				}
				flag2 = (byte)num6 != 0;
			}
			goto IL_026d;
		}
		float num7 = 20f;
		float num8 = 20f;
		if (TorpedoThreat.SpeedIsKnown)
		{
			num7 = TorpedoThreat.CurrentSpeed;
			num8 = myUnit.Kinematics.GetMaximumSpeed();
		}
		if (num8 >= num7)
		{
			float num9 = Math.Abs(Math2.NormalizeBearing(num2 + 180f) - myUnit.CurrentHeading);
			if (num9 > 180f)
			{
				num9 = 360f - num9;
			}
			if (num9 < 1f || num9 / myUnit.Kinematics.TurnRate() < num / (num7 / 3600f))
			{
				myUnit.SetThrottle(ActiveUnit.Throttle.Flank);
				int ThreatBearing = (int)Math.Round(num2);
				OutrunThreat(ref ThreatBearing);
				return;
			}
		}
		float num10 = Math.Abs(num3);
		EvasionManeuver = new PersistentManeuver(myUnit, TorpedoThreat, num);
		EvasionManeuver.DesiredThrottle = ActiveUnit.Throttle.Flank;
		if (num > ActiveUnit_AI.TorpedoEvasionEmergencyRange)
		{
			if (num10 < 30f)
			{
				EvasionManeuver.DesiredHeading = num2;
				EvasionManeuver.DesiredThrottle = ActiveUnit.Throttle.Cruise;
			}
			else if (num10 < 60f)
			{
				if (num3 < 0f)
				{
					EvasionManeuver.DesiredHeading = Math2.NormalizeBearing(num2 - 30f);
					EvasionManeuver.Direction = PersistentManeuver.TurnDirection.Left;
				}
				else
				{
					EvasionManeuver.DesiredHeading = Math2.NormalizeBearing(num2 + 30f);
					EvasionManeuver.Direction = PersistentManeuver.TurnDirection.Right;
				}
			}
			else if (num3 < 0f)
			{
				EvasionManeuver.DesiredHeading = Math2.NormalizeBearing(num2 - 30f);
				EvasionManeuver.Direction = PersistentManeuver.TurnDirection.Right;
			}
			else
			{
				EvasionManeuver.DesiredHeading = Math2.NormalizeBearing(num2 + 30f);
				EvasionManeuver.Direction = PersistentManeuver.TurnDirection.Left;
			}
		}
		else if (num10 < 60f)
		{
			if (num3 < 0f)
			{
				EvasionManeuver.DesiredHeading = Math2.NormalizeBearing(myUnit.CurrentHeading - 90f);
				EvasionManeuver.Direction = PersistentManeuver.TurnDirection.Left;
			}
			else
			{
				EvasionManeuver.DesiredHeading = Math2.NormalizeBearing(myUnit.CurrentHeading + 90f);
				EvasionManeuver.Direction = PersistentManeuver.TurnDirection.Right;
			}
		}
		else if (num3 < 0f)
		{
			EvasionManeuver.DesiredHeading = Math2.NormalizeBearing(myUnit.CurrentHeading + 90f);
			EvasionManeuver.Direction = PersistentManeuver.TurnDirection.Right;
		}
		else
		{
			EvasionManeuver.DesiredHeading = Math2.NormalizeBearing(myUnit.CurrentHeading - 90f);
			EvasionManeuver.Direction = PersistentManeuver.TurnDirection.Left;
		}
		return;
		IL_026d:
		if (!flag2)
		{
			return;
		}
		EvasionManeuver = new PersistentManeuver(myUnit, TorpedoThreat, num);
		EvasionManeuver.DesiredThrottle = ActiveUnit.Throttle.Flank;
		if (num3 < 0f)
		{
			EvasionManeuver.DesiredHeading = Math2.NormalizeBearing(num4 + 90f);
		}
		else
		{
			EvasionManeuver.DesiredHeading = Math2.NormalizeBearing(num4 - 90f);
		}
		EvasionManeuver.Direction = PersistentManeuver.TurnDirection.Right;
		if (num3 < 90f && num3 > -90f)
		{
			if (num3 < 0f)
			{
				EvasionManeuver.Direction = PersistentManeuver.TurnDirection.Left;
			}
		}
		else if (num3 > 0f)
		{
			EvasionManeuver.Direction = PersistentManeuver.TurnDirection.Left;
		}
	}

	public override void ManouverAgainstPrimaryThreat(float elapsedTime)
	{
		try
		{
			if (Information.IsNothing((object)_PrimaryThreat))
			{
				return;
			}
			double num = Math.Round(Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)_PrimaryThreat).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)_PrimaryThreat).get_Longitude((GlobalVariables.BooleanObject)null)), 0);
			if (double.IsNaN(num))
			{
				return;
			}
			switch (_PrimaryThreat.Type)
			{
			case Contact_Base.ContactType.Torpedo:
				ManoueverTorpedoEvasion(elapsedTime, _PrimaryThreat);
				break;
			case Contact_Base.ContactType.Missile:
			{
				BeamThreat((int)Math.Round(num));
				myUnit.SetThrottle(ActiveUnit.Throttle.Flank);
				Weapon theW = null;
				if (!Information.IsNothing((object)PrimaryThreat))
				{
					theW = myUnit.Weaponry.MostSuitableWeaponForThisTarget(PrimaryThreat, CheckIfWithinRange: false, CheckIfWithinAltitude: false, CheckWRA: true, myUnit.Doctrine);
				}
				if (!Information.IsNothing((object)theW) && IsClearedToEngageThisTarget(PrimaryThreat))
				{
					Contact primaryThreat = PrimaryThreat;
					(Mount, float, bool) theMountDetails = default((Mount, float, bool));
					TurnToUnmaskPrimaryWeapon(ref theW, primaryThreat, ref theMountDetails);
				}
				break;
			}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100775", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private Weapon[] method_12()
	{
		return myUnit.Weaponry.AllDistinctWeaponsAboard_Actual().ToArray();
	}

	public override void EvaluateTargets(float elapsedTime, bool IgnoreContacStance, bool Immediately)
	{
		if (!EvaluateTargets_Enabled || myUnit == null || myUnit.IsMorituri || (myUnit.IsDrone() && myUnit.AutonomyLevel < ActiveUnit.DroneAutonomyLevel.BattlespaceCognizant && myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DroneAutonomyLevels) && !myUnit.CommStuff.IsConnectedToSideNetwork))
		{
			return;
		}
		Side side = myUnit.get_UnitSide(SetSideOnly: false);
		try
		{
			Contact current = default(Contact);
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
					current = null;
				}
				pooledList.Dispose();
				return;
			}
			base.EvaluateTargets(elapsedTime, IgnoreContacStance, Immediately);
			if (myUnit == null)
			{
				return;
			}
			_SelfDefenceTargets.Clear();
			Mission mission = myUnit.ActiveMissionOrPackage();
			_ = base.Targets_ReadOnly;
			bool isInsidePatrolArea_10nmBuffer = base.IsInsidePatrolArea_10nmBuffer;
			List<Weapon> list = new List<Weapon>();
			list.AddRange(method_12());
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
			foreach (Contact item3 in theContactsVisibleToMe)
			{
				if (TargetingBehaviorForThisTarget(item3, targetList) != TargetingEntry._TargetingBehavior.NotTargeted)
				{
					hashSet_0.Add(item3.ObjectID);
				}
			}
			int FeedbackSeverity;
			if (mission != null && mission.IsActive)
			{
				int num = count - 1;
				for (int j = 0; j <= num; j++)
				{
					current = theContactsVisibleToMe[j];
					if (_DoNotTargetList.Contains(current) || hashSet_0.Contains(current.ObjectID))
					{
						continue;
					}
					byte? b = (byte?)current.BDA_StructuralIntegrity;
					if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 4)) == true)
					{
						continue;
					}
					Misc.PostureStance contactsStance_Cache = GetContactsStance_Cache(current, j);
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
							if (weaponry.HaveAvailableWeaponSuitableForThisTarget(theTarget, CheckWRA: true, doctrine, ref Feedback, ref FeedbackSeverity, HumanFeedBackNeeded: false, list))
							{
								TargetThisContact(current, AddedManually: false, PriorityTarget: false, TargetingEntry._TargetingBehavior.AutoTargeted);
								hashSet_0.Add(current.ObjectID);
							}
						}
						break;
					case Misc.PostureStance.Unknown:
						if (current.Type != Contact_Base.ContactType.Submarine || !SeaIceProvider.PointIsUnderIce(((Module_Unit.Unit)current).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)current).get_Latitude((GlobalVariables.BooleanObject)null)))
						{
							TargetThisContact(current, AddedManually: false, PriorityTarget: false, TargetingEntry._TargetingBehavior.AutoTargeted);
							hashSet_0.Add(current.ObjectID);
						}
						break;
					}
				}
			}
			Weapon longestRange_AAWeapon = myUnit.Weaponry.GetLongestRange_AAWeapon(current);
			Weapon longestRange_ASWWeapon = myUnit.Weaponry.GetLongestRange_ASWWeapon(current);
			Weapon longestWeapon_ASuW = default(Weapon);
			Weapon longestWeapon_AG = default(Weapon);
			if (myUnit.IsOnActivePatrol())
			{
				Patrol patrol = (Patrol)mission;
				GlobalVariables.PatrolType type = patrol.Type;
				if (type <= GlobalVariables.PatrolType.ASuW_Naval || type - 3 <= GlobalVariables.PatrolType.ASuW_Land)
				{
					if (!patrol.get_InvestigateWithinWeaponRange(myUnit.ParentScen))
					{
						longestWeapon_ASuW = null;
						longestWeapon_AG = null;
					}
					else
					{
						longestWeapon_ASuW = myUnit.Weaponry.GetLongestRange_ASWeapon(ExcludeICBMs: false, current);
						longestWeapon_AG = myUnit.Weaponry.GetLongestRange_AGWeapon(ExcludeICBMs: false, current);
					}
				}
			}
			else
			{
				longestWeapon_ASuW = myUnit.Weaponry.GetLongestRange_ASWeapon(ExcludeICBMs: false, current);
				longestWeapon_AG = myUnit.Weaponry.GetLongestRange_AGWeapon(ExcludeICBMs: false, current);
			}
			bool flag3 = myUnit.IsOnActivePatrol() && ((Patrol)mission).HasProsecutionArea;
			bool hasValue;
			Doctrine._UseShootTourists value = default(Doctrine._UseShootTourists);
			if (hasValue = useShootTourists.HasValue)
			{
				value = useShootTourists.Value;
			}
			FeedbackSeverity = count - 1;
			for (int l = 0; l <= FeedbackSeverity; l++)
			{
				current = theContactsVisibleToMe[l];
				if (_DoNotTargetList.Contains(current) || hashSet_0.Contains(current.ObjectID))
				{
					continue;
				}
				Misc.PostureStance contactsStance_Cache = GetContactsStance_Cache(current, l);
				if (contactsStance_Cache == Misc.PostureStance.Friendly || contactsStance_Cache == Misc.PostureStance.Neutral)
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
					if (!((Module_Unit.Unit)current).get_IsInsideThisArea(patrol2.PatrolArea, myUnit.ParentScen, UseCache: true) && TargetingBehaviorForThisTarget(current, targetList) != TargetingEntry._TargetingBehavior.ManualWeaponAlloc && !myUnit.Sensory.IsIlluminatingThisContact(current) && (!hasValue || value != Doctrine._UseShootTourists.Yes))
					{
						continue;
					}
				}
				if (!hashSet_0.Contains(current.ObjectID) && TargetIsEligibleBasedOnWeaponRange(current, contactsStance_Cache, hasValue, value, longestRange_AAWeapon, longestWeapon_ASuW, longestWeapon_AG, longestRange_ASWWeapon))
				{
					ActiveUnit_Weaponry weaponry2 = myUnit.Weaponry;
					Contact theTarget2 = current;
					Doctrine doctrine2 = myUnit.Doctrine;
					string Feedback = null;
					int FeedbackSeverity2 = 0;
					if (weaponry2.HaveAvailableWeaponSuitableForThisTarget(theTarget2, CheckWRA: true, doctrine2, ref Feedback, ref FeedbackSeverity2, HumanFeedBackNeeded: false, list) && !DropTargetDueToRearwardFiringDoctrine(current))
					{
						TargetThisContact(current, AddedManually: false, PriorityTarget: false, TargetingEntry._TargetingBehavior.AutoTargeted);
						hashSet_0.Add(current.ObjectID);
					}
				}
			}
			foreach (Contact selfDefenceTarget in _SelfDefenceTargets)
			{
				if (!hashSet_0.Contains(selfDefenceTarget.ObjectID) && !_DoNotTargetList.Contains(selfDefenceTarget))
				{
					TargetThisContact(selfDefenceTarget, AddedManually: false, PriorityTarget: false, TargetingEntry._TargetingBehavior.AutoSelfDefence);
					hashSet_0.Add(current.ObjectID);
				}
			}
			if (PrimaryTarget != null && PrimaryTarget is AimpointContact)
			{
				ref ActiveUnit theAttacker = ref myUnit;
				Contact theTarget3 = PrimaryTarget;
				List<Weapon> list2 = side.WeaponsLeftToFireAtThisTarget(ref theAttacker, ref theTarget3);
				PrimaryTarget = theTarget3;
				List<Weapon> list3 = list2;
				bool flag5 = false;
				foreach (Mount mount in myUnit.Mounts)
				{
					foreach (WeaponRec mountWeapon in mount.MountWeapons)
					{
						int int_ = mountWeapon.int_3;
						foreach (Weapon item4 in list3)
						{
							if (item4.DBID == int_)
							{
								flag5 = true;
								break;
							}
						}
						if (flag5)
						{
							break;
						}
					}
					if (flag5)
					{
						break;
					}
				}
				if (!flag5)
				{
					DropTarget(PrimaryTarget);
				}
			}
			if (base.MayTargetNonAUs)
			{
				TargetNonAUsRelevantToMission();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100776", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void TargetNonAUsRelevantToMission()
	{
	}

	public override void EvaluateThreats(float elapsedTime)
	{
		if (myUnit == null || myUnit.IsMorituri)
		{
			return;
		}
		try
		{
			if (myUnit.IsDrone() && myUnit.AutonomyLevel < ActiveUnit.DroneAutonomyLevel.BattlespaceCognizant && myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DroneAutonomyLevels) && !myUnit.CommStuff.IsConnectedToSideNetwork)
			{
				return;
			}
			ClearAllNonImminentThreats(elapsedTime);
			List<Weapon> availableWeapons = myUnit.Weaponry.AllDistinctWeaponsAboard_Actual();
			Contact[] array = theContactsVisibleToMe.InternalArray();
			if (theContactsVisibleToMe.Count == 0)
			{
				return;
			}
			int num = theContactsVisibleToMe.Count - 1;
			bool flag = default(bool);
			for (int i = 0; i <= num; i++)
			{
				Contact contact = array[i];
				if (contact == null || contact.ActualUnit == null || flag || !contact.ActualUnit.IsWeapon)
				{
					continue;
				}
				if (!myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactStancesOnThisPulse.TryGetValue(contact.ObjectID, out var value))
				{
					value = contact.get_Stance(myUnit.get_UnitSide(SetSideOnly: false));
					myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactStancesOnThisPulse.AddIfNotExists(contact.ObjectID, value);
				}
				if (value == Misc.PostureStance.Friendly || !((Weapon)contact.ActualUnit).ValidTargets.SurfaceVessel)
				{
					continue;
				}
				AddContactToThreatList(contact);
				Weapon._WeaponType type = ((Weapon)contact.ActualUnit).Type;
				if (type != Weapon._WeaponType.Torpedo)
				{
					continue;
				}
				Weapon longestRange_ASWWeapon = myUnit.Weaponry.GetLongestRange_ASWWeapon(contact);
				if (longestRange_ASWWeapon != null)
				{
					ActiveUnit_Weaponry weaponry = myUnit.Weaponry;
					Doctrine doctrine = myUnit.Doctrine;
					string Feedback = null;
					int FeedbackSeverity = 0;
					if (weaponry.HaveAvailableWeaponSuitableForThisTarget(contact, CheckWRA: true, doctrine, ref Feedback, ref FeedbackSeverity, HumanFeedBackNeeded: false, availableWeapons) && (double)Module_Unit.RangeToUnit_Slant(myUnit, contact) < 1.5 * (double)longestRange_ASWWeapon.MaxSubsurfaceRange)
					{
						TargetThisContact(contact, AddedManually: false, PriorityTarget: false, TargetingEntry._TargetingBehavior.AutoTargeted);
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100777", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
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
			WeaponThreat = null;
			byte? b = (byte?)myUnit.Doctrine.get_AutoEvade(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
			{
				if (myUnit.ParentScen.AnyActiveWeaponEffectThreats)
				{
					Module_Unit.Unit unit = DetermineWeaponEffectThreat();
					if (unit != null)
					{
						myUnit.Status = ActiveUnit._ActiveUnitStatus.AvoidingWeaponEffects;
						WeaponThreat = unit;
						return;
					}
				}
				if (_PrimaryThreat != null)
				{
					double num = myUnit.RangeToUnit_Horiz(_PrimaryThreat);
					switch (_PrimaryThreat.Type)
					{
					case Contact_Base.ContactType.Torpedo:
						if (num < 3.0)
						{
							myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedDefensive;
							return;
						}
						if (num < 10.0 && AngleOffContactsBoresight(ref _PrimaryThreat, GlobalVariables.ObjectTrue) < 90f)
						{
							myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedDefensive;
							return;
						}
						break;
					case Contact_Base.ContactType.Air:
					case Contact_Base.ContactType.Missile:
					{
						if (Module_Unit.RangeToUnit_Slant(myUnit, _PrimaryThreat) < 50f)
						{
							myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedDefensive;
							return;
						}
						Weapon weapon = myUnit.Weaponry.LongestRangedSuitableWeaponForThisTarget(_PrimaryThreat);
						if (!Information.IsNothing((object)weapon))
						{
							float num2 = weapon.get_MaxRangeForThisTarget(myUnit, _PrimaryThreat, CheckWRA: false, myUnit.Doctrine, ManualFire: false);
							if (_PrimaryThreat.SpeedIsKnown)
							{
								num2 += 3f * _PrimaryThreat.CurrentSpeed / 60f;
							}
							if (Module_Unit.RangeToUnit_Slant(myUnit, _PrimaryThreat) < num2)
							{
								myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedDefensive;
								return;
							}
						}
						if (!myUnit.IsGroupLead())
						{
							break;
						}
						ActiveUnit[] array = myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values.ToArray();
						foreach (ActiveUnit activeUnit in array)
						{
							if (activeUnit != myUnit && activeUnit.Status == ActiveUnit._ActiveUnitStatus.EngagedDefensive && activeUnit.AI.PrimaryThreat == _PrimaryThreat)
							{
								myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedDefensive;
								return;
							}
						}
						break;
					}
					}
				}
				else if (myUnit.Status == ActiveUnit._ActiveUnitStatus.EngagedDefensive)
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
			bool flag2;
			if (!Pathfinding.UnitOrFlightPlanHasPFRequestInQueue(theUnit, null, ref ThrownError))
			{
				if (myUnit.Navigator.HasPathfindingPlottedCourse && myUnit.Status == ActiveUnit._ActiveUnitStatus.WaitForPathfinder)
				{
					myUnit.Status = myUnit._StatusBefore_WaitForPathfinder;
				}
				if (myUnit.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.TransferringCargo || myUnit.IsRTB)
				{
					return;
				}
				if (myUnit.ParentScen.FifthSecondIsChangingOnThisPulse && !myUnit.IsRTB && myUnit.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint && CheckForWithdrawalCriteria())
				{
					myUnit.Navigator.ResetTimeToNextPathfinderCheck();
					return;
				}
				if (myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
				{
					b = (byte?)myUnit.Doctrine.get_IgnorePlottedCourse(myUnit.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false);
					bool? flag = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
					if (!((!flag) ?? false) && !Information.IsNothing((object)PrimaryTarget) && flag.HasValue)
					{
						flag2 = true;
						if (!Information.IsNothing((object)myUnit.ActiveMissionOrPackage()) && myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
						{
							Strike strike = (Strike)myUnit.ActiveMissionOrPackage();
							if (strike.MaxResponseRadius_Ship > 0 || strike.MinResponseRadius_Ship > 0)
							{
								float num3 = Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null));
								int num4;
								if (strike.MaxResponseRadius_Ship > 0 && !(num3 <= (float)strike.MaxResponseRadius_Ship))
								{
									num4 = 0;
								}
								else
								{
									if (strike.MinResponseRadius_Ship <= 0 || !(num3 < (float)strike.MinResponseRadius_Ship))
									{
										goto IL_0628;
									}
									num4 = 0;
								}
								flag2 = (byte)num4 != 0;
							}
						}
						goto IL_0628;
					}
					if (myUnit.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.LocalizationRun && !Information.IsNothing((object)PrimaryTarget))
					{
						if (Information.IsNothing((object)PrimaryTarget.UncertaintyArea))
						{
							myUnit.Navigator.ClearPlottedCourse();
							myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
						}
						else if (!GeoPoint.IsInsideThisArea(myUnit.Navigator.PlottedCourse[0].Latitude, myUnit.Navigator.PlottedCourse[0].Longitude, PrimaryTarget.UncertaintyArea))
						{
							myUnit.Navigator.ClearPlottedCourse();
							myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
						}
						else
						{
							myUnit.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
						}
					}
					else
					{
						myUnit.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
					}
					return;
				}
				goto IL_0722;
			}
			myUnit.Status = ActiveUnit._ActiveUnitStatus.WaitForPathfinder;
			return;
			IL_081e:
			bool flag3;
			if (flag3)
			{
				ActiveUnit_Weaponry weaponry = myUnit.Weaponry;
				Contact primaryTarget = PrimaryTarget;
				Doctrine doctrine = myUnit.Doctrine;
				string Feedback = string.Empty;
				int FeedbackSeverity = 0;
				if (weaponry.HaveAvailableWeaponSuitableForThisTarget(primaryTarget, CheckWRA: true, doctrine, ref Feedback, ref FeedbackSeverity, HumanFeedBackNeeded: false))
				{
					myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
					return;
				}
			}
			goto IL_0867;
			IL_0867:
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
				if (myUnit.Status != ActiveUnit._ActiveUnitStatus.RTB_MissionOver)
				{
					switch (myUnit.ActiveMissionOrPackage().MissionClass)
					{
					case Mission._MissionClass.Strike:
						myUnit.Status = ActiveUnit._ActiveUnitStatus.Tasked;
						return;
					case Mission._MissionClass.Patrol:
						CheckIfReachedPatrolAreaThiSortie();
						if (Information.IsNothing((object)PrimaryTarget) && myUnit.IsGroupMember() && !myUnit.IsGroupLead())
						{
							Contact primaryTarget2 = myUnit.get_ParentGroup(UsingMissionPlanner: false).AI.PrimaryTarget;
							if (primaryTarget2 != null)
							{
								PrimaryTarget = primaryTarget2;
							}
						}
						if (!Information.IsNothing((object)PrimaryTarget))
						{
							Contact_Base.ContactType type = PrimaryTarget.Type;
							if (type > Contact_Base.ContactType.Missile)
							{
								myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
								return;
							}
							if (myUnit.Status == ActiveUnit._ActiveUnitStatus.EngagedOffensive)
							{
								myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
							}
						}
						if (myUnit.IsGroupMember() && !myUnit.IsGroupLead())
						{
							Contact contact = myUnit.get_ParentGroup(UsingMissionPlanner: false)?.GroupLead?.AI?.PrimaryTarget;
							if (contact != null)
							{
								PrimaryTarget = contact;
								myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
								return;
							}
						}
						myUnit.Status = ActiveUnit._ActiveUnitStatus.OnPatrol;
						return;
					case Mission._MissionClass.Support:
						if (!Information.IsNothing((object)PrimaryTarget))
						{
							b = (byte?)myUnit.Doctrine.get_ShootTourists(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
							if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
							{
								myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
								return;
							}
						}
						myUnit.Status = ActiveUnit._ActiveUnitStatus.OnSupportMission;
						return;
					case Mission._MissionClass.Ferry:
						if (!Information.IsNothing((object)PrimaryTarget))
						{
							b = (byte?)myUnit.Doctrine.get_ShootTourists(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
							if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
							{
								myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
								return;
							}
						}
						myUnit.Status = ActiveUnit._ActiveUnitStatus.OnFerryMission;
						return;
					case Mission._MissionClass.Mining:
						myUnit.Status = ActiveUnit._ActiveUnitStatus.Tasked;
						return;
					case Mission._MissionClass.MineClearing:
						myUnit.Status = ActiveUnit._ActiveUnitStatus.Tasked;
						return;
					case Mission._MissionClass.Cargo:
						myUnit.Status = ActiveUnit._ActiveUnitStatus.Tasked;
						return;
					}
				}
				else
				{
					myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
				}
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
					int FeedbackSeverity = 0;
					GeoPoint InterruptLocation = null;
					if (navigator.PathLineIsInterrupted(startLat, startLon, latitude, longitude, RunInParallel: false, 0f, CheckIfCurrentlyInsideIllegalArea: false, null, IsPathfindingQuery: false, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: true, null, ref FeedbackSeverity, ref InterruptLocation))
					{
						myUnit.Navigator.PlotCourseToPickupPoint();
						if (!myUnit.Navigator.HasPlottedCourse())
						{
							myUnit.AddMessage(myUnit.Name + " is unable to reach cargo pick up target " + base.PrimaryPickupTarget.Name, "Cannot pick up cargo", LoggedMessage.MessageType.UI, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
							myUnit.AI.RemovePickupTarget(base.PrimaryPickupTarget.ObjectID);
						}
					}
				}
				else if ((double)myUnit.RangeToUnit_Horiz(base.PrimaryPickupTarget) <= 2.2)
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
			return;
			IL_0628:
			if (flag2)
			{
				myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
				return;
			}
			goto IL_0722;
			IL_0722:
			if (PrimaryTarget != null)
			{
				Contact_Base.ContactType type2 = PrimaryTarget.Type;
				if (type2 > Contact_Base.ContactType.Missile)
				{
					flag3 = true;
					if (!Information.IsNothing((object)myUnit.ActiveMissionOrPackage()) && myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
					{
						Strike strike2 = (Strike)myUnit.ActiveMissionOrPackage();
						if (strike2.MaxResponseRadius_Ship > 0 || strike2.MinResponseRadius_Ship > 0)
						{
							float num5 = Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null));
							int num6;
							if (strike2.MaxResponseRadius_Ship > 0 && !(num5 <= (float)strike2.MaxResponseRadius_Ship))
							{
								num6 = 0;
							}
							else
							{
								if (strike2.MinResponseRadius_Ship <= 0 || !(num5 < (float)strike2.MinResponseRadius_Ship))
								{
									goto IL_081e;
								}
								num6 = 0;
							}
							flag3 = (byte)num6 != 0;
						}
					}
					goto IL_081e;
				}
				if (myUnit.Status == ActiveUnit._ActiveUnitStatus.EngagedOffensive)
				{
					myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
				}
			}
			goto IL_0867;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200348", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_13()
	{
		if (myUnit.Kinematics.DesiredSpeedOverride.HasValue)
		{
			return;
		}
		bool BingoFuelEndurance;
		if (PrimaryTarget.Type == Contact_Base.ContactType.Submarine)
		{
			ActiveUnit_Sensory sensory = myUnit.Sensory;
			Sensor[] theSensorList = null;
			PooledList<Sensor> longestRange_ASWSensor = sensory.GetLongestRange_ASWSensor(ActiveCapableSensorsOnly: false, EmmittingSensorsOnly: false, OnlyOperatingSensors: true, OnlySensorsScanningThisPulse: false, ref theSensorList, SonarsOnly: true);
			float num;
			if (longestRange_ASWSensor != null && longestRange_ASWSensor.Count > 0)
			{
				num = longestRange_ASWSensor[0].maxRange;
				longestRange_ASWSensor.Dispose();
			}
			else
			{
				num = 0f;
			}
			if ((double)myUnit.RangeToUnit_Horiz(PrimaryTarget) > Math.Max(3.0, (double)num * 1.1))
			{
				myUnit.SetThrottle(ActiveUnit.Throttle.Flank);
				return;
			}
			ActiveUnit_AI aI = myUnit.AI;
			Contact primaryTarget = PrimaryTarget;
			float currentHeading = myUnit.CurrentHeading;
			float? safetyMargin = 0.1f;
			BingoFuelEndurance = false;
			if (!aI.CanInterceptTarget(primaryTarget, null, 0f, null, currentHeading, ActiveUnit.Throttle.Loiter, safetyMargin, IgnoreMotionVectors: false, TotalRemainingEndurance: false, ref BingoFuelEndurance))
			{
				myUnit.SetThrottle(ActiveUnit.Throttle.Flank);
				myUnit.Kinematics.AdjustSpeedForCavitation();
			}
			else
			{
				myUnit.SetThrottle(ActiveUnit.Throttle.Loiter);
			}
			return;
		}
		ActiveUnit_AI aI2 = myUnit.AI;
		Contact primaryTarget2 = PrimaryTarget;
		float currentHeading2 = myUnit.CurrentHeading;
		float? safetyMargin2 = 0.1f;
		BingoFuelEndurance = false;
		if (!aI2.CanInterceptTarget(primaryTarget2, null, 0f, null, currentHeading2, ActiveUnit.Throttle.Full, safetyMargin2, IgnoreMotionVectors: false, TotalRemainingEndurance: false, ref BingoFuelEndurance))
		{
			myUnit.SetThrottle(ActiveUnit.Throttle.Flank);
			return;
		}
		Weapon._WeaponType? weaponType = myUnit.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, CheckIfWithinRange: false, CheckIfWithinAltitude: false, CheckWRA: true, myUnit.Doctrine)?.Type;
		short? num2 = (short?)weaponType;
		bool? flag2;
		bool? flag = (flag2 = ((!num2.HasValue) ? ((bool?)null) : new bool?(num2 == 2011)));
		bool? obj;
		bool? flag3;
		if (flag.HasValue && flag2 == true)
		{
			obj = true;
		}
		else
		{
			num2 = (short?)weaponType;
			flag = (flag3 = ((!num2.HasValue) ? ((bool?)null) : new bool?(num2 == 2010)));
			obj = ((!flag.HasValue) ? ((bool?)null) : ((flag3 == true) | flag2));
		}
		flag3 = obj;
		int num3;
		if (flag3 != true)
		{
			num3 = 0;
		}
		else
		{
			ActiveUnit_AI aI3 = myUnit.AI;
			Contact primaryTarget3 = PrimaryTarget;
			float currentHeading3 = myUnit.CurrentHeading;
			float? safetyMargin3 = 0.1f;
			BingoFuelEndurance = false;
			if (aI3.CanInterceptTarget(primaryTarget3, null, 0f, null, currentHeading3, ActiveUnit.Throttle.Flank, safetyMargin3, IgnoreMotionVectors: false, TotalRemainingEndurance: false, ref BingoFuelEndurance))
			{
				myUnit.SetThrottle(ActiveUnit.Throttle.Flank);
				return;
			}
			num3 = 0;
		}
		bool flag4 = (byte)num3 != 0;
		if (PrimaryTarget == null)
		{
			return;
		}
		float num4 = Math2.CalcDist(myUnit, PrimaryTarget);
		Weapon weapon = myUnit.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, CheckIfWithinRange: true, CheckIfWithinAltitude: true, CheckWRA: true, myUnit.Doctrine);
		if (weapon != null && num4 <= weapon.get_MaxRangeForThisTarget(myUnit, PrimaryTarget, CheckWRA: true, myUnit.Doctrine, ManualFire: false))
		{
			flag4 = true;
			if (myUnit.Kinematics.DesiredSpeedOverride.HasValue && !myUnit.Navigator.NextWaypointIsManual)
			{
				myUnit.SetThrottle(ActiveUnit.Throttle.FullStop);
			}
		}
		if ((!flag4 & !bool_0) && myUnit.ThrottleSetting != ActiveUnit.Throttle.Full)
		{
			myUnit.SetThrottle(ActiveUnit.Throttle.Full);
		}
	}

	public override void DetermineDesiredAttitudeAndThrottle(float elapsedTime, bool RecalculatePlottedCourse = true)
	{
		if (myUnit == null || myUnit.IsMorituri)
		{
			return;
		}
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
		try
		{
			ActiveUnit._ActiveUnitStatus activeUnitStatus = myUnit.Status;
			myUnit.Kinematics.HasAdjustedSpeedForCavitation = false;
			if (myUnit.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.TransferringCargo)
			{
				myUnit.Kinematics.DesiredSpeedOverride = null;
				myUnit.SetThrottle(ActiveUnit.Throttle.FullStop);
				return;
			}
			if (activeUnitStatus == ActiveUnit._ActiveUnitStatus.AvoidingWeaponEffects && WeaponThreat != null)
			{
				ManouverAwayFromWeaponEffects(elapsedTime, WeaponThreat);
				myUnit.Kinematics.DesiredSpeedOverride = null;
				myUnit.SetThrottle(ActiveUnit.Throttle.Flank);
				return;
			}
			switch (activeUnitStatus)
			{
			case ActiveUnit._ActiveUnitStatus.EngagedDefensive:
				myUnit.Kinematics.DesiredSpeedOverride = null;
				myUnit.SetThrottle(ActiveUnit.Throttle.Flank);
				ManouverAgainstPrimaryThreat(elapsedTime);
				return;
			case ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint:
			{
				bool flag = true;
				GeoPoint intermediateTargetPoint = IntermediateTargetPointForRefuelCalcs();
				ActiveUnit_DockingOps dockingOps = myUnit.DockingOps;
				string UserFeedback = "";
				List<ActiveUnit> potentialUNREPunits = dockingOps.GetPotentialUNREPunits(MustBeAbleToReachItDirectly: true, null, ref UserFeedback, ActiveUnit_DockingOps.ResupplyRequest.FuelOrMaterial);
				if (myUnit.ParentScen.MinuteIsChangingOnThisPulse || Information.IsNothing((object)myUnit.DockingOps.UNREP_Destination))
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
						if (Information.IsNothing((object)myUnit.DockingOps.UNREP_Destination))
						{
							num = 0;
						}
						else
						{
							myUnit.DockingOps.DisconnectFromSupplier();
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
						if (myUnit.RangeToUnit_Horiz(uNREP_Destination) < 1f)
						{
							uNREP_Destination.DesiredSpeed = Math.Max(5f, myUnit.CurrentSpeed + 5f);
							return;
						}
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
			{
				myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, myUnit.DockingOps.UNREP_Destination.DesiredHeading);
				ActiveUnit uNREP_Destination2 = myUnit.DockingOps.UNREP_Destination;
				if (myUnit.IsGroupLead() && uNREP_Destination2.IsGroupMember() && myUnit.get_ParentGroup(UsingMissionPlanner: false) == uNREP_Destination2.get_ParentGroup(UsingMissionPlanner: false))
				{
					uNREP_Destination2.DesiredSpeed = myUnit.DesiredSpeed;
					return;
				}
				myUnit.DesiredSpeed = uNREP_Destination2.DesiredSpeed;
				myUnit.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
				myUnit.SetThrottle(myUnit.Kinematics.GetThrottleSuitableForThisSpeed(0f, (int)Math.Round(myUnit.DesiredSpeed)), (int)Math.Round(myUnit.DesiredSpeed));
				return;
			}
			case ActiveUnit._ActiveUnitStatus.WaitForPathfinder:
				if (myUnit.DesiredSpeed != 0f)
				{
					myUnit.DesiredSpeed = 0f;
					myUnit.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
					myUnit.SetThrottle(ActiveUnit.Throttle.FullStop, 0f);
					return;
				}
				break;
			}
			if (activeUnitStatus != ActiveUnit._ActiveUnitStatus.RTB && activeUnitStatus != ActiveUnit._ActiveUnitStatus.RTB_Manual && activeUnitStatus != ActiveUnit._ActiveUnitStatus.RTB_MissionOver && activeUnitStatus != ActiveUnit._ActiveUnitStatus.RTB_Exhaustion && activeUnitStatus != ActiveUnit._ActiveUnitStatus.RTB_CommsLost)
			{
				bool flag2 = false;
				switch (activeUnitStatus)
				{
				case ActiveUnit._ActiveUnitStatus.EngagedOffensive:
				{
					if (PrimaryTarget == null)
					{
						return;
					}
					byte? b = (byte?)myUnit.Doctrine.get_MaintainStandoff(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
					if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true && myUnit.AI.PrimaryTarget != null && MyAssignedMissionContainsTarget(myUnit.AI.PrimaryTarget) && HasActiveFireProposalForTarget(PrimaryTarget))
					{
						Weapon weapon = myUnit.Weaponry.MostSuitableWeaponForThisTarget(myUnit.AI.PrimaryTarget, CheckIfWithinRange: true, CheckIfWithinAltitude: true, CheckWRA: true, myUnit.Doctrine);
						if (weapon != null && weapon.get_MaxRangeForThisTarget(myUnit, myUnit.AI.PrimaryTarget, CheckWRA: true, myUnit.Doctrine, ManualFire: false) > Math2.CalcDist(myUnit, myUnit.AI.PrimaryTarget))
						{
							HoldPosition = true;
							flag2 = true;
							return;
						}
					}
					if (!myUnit.IsGroupMember())
					{
						if (myUnit.AssignedMissionOrPackage() != null && myUnit.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike && ((Strike)myUnit.AssignedMissionOrPackage()).TimeOnTarget.HasValue && myUnit.AI.PrimaryTarget != null && MyAssignedMissionContainsTarget(myUnit.AI.PrimaryTarget) && HasActiveFireProposalForTarget(PrimaryTarget))
						{
							Weapon weapon2 = myUnit.Weaponry.MostSuitableWeaponForThisTarget(myUnit.AI.PrimaryTarget, CheckIfWithinRange: true, CheckIfWithinAltitude: true, CheckWRA: true, myUnit.Doctrine);
							if (weapon2 != null && weapon2.get_MaxRangeForThisTarget(myUnit, myUnit.AI.PrimaryTarget, CheckWRA: true, myUnit.Doctrine, ManualFire: false) > Math2.CalcDist(myUnit, myUnit.AI.PrimaryTarget))
							{
								flag2 = true;
							}
						}
						if (!flag2)
						{
							ManouverTowardsTarget(elapsedTime);
							method_13();
						}
						else
						{
							myUnit.SetThrottle(ActiveUnit.Throttle.FullStop);
						}
					}
					else if (myUnit.IsGroupLead())
					{
						Contact_Base.ContactType type2 = PrimaryTarget.Type;
						if (type2 > Contact_Base.ContactType.Missile && type2 != Contact_Base.ContactType.Orbital)
						{
							ManouverTowardsTarget(elapsedTime);
							method_13();
						}
						else
						{
							myUnit.Navigator.FollowPlottedCourse(elapsedTime);
						}
					}
					else if (myUnit.ActiveMissionOrPackage() == myUnit.get_ParentGroup(UsingMissionPlanner: false).ActiveMissionOrPackage())
					{
						if (myUnit.CommStuff.IsConnectedToSideNetwork)
						{
							myUnit.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
						}
					}
					else
					{
						ManouverTowardsTarget(elapsedTime);
						method_13();
					}
					if (!myUnit.IsGroupWingman() && !myUnit.Kinematics.DesiredSpeedOverride.HasValue)
					{
						float? num6 = null;
						float num7 = float.MaxValue;
						ActiveUnit.Throttle? throttle = default(ActiveUnit.Throttle?);
						if (!Information.IsNothing((object)myUnit.ActiveMissionOrPackage()) && myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
						{
							Patrol patrol5 = (Patrol)myUnit.ActiveMissionOrPackage();
							if (!Information.IsNothing((object)patrol5.AttackThrottle_Ship))
							{
								num6 = patrol5.AttackDistance_Ship;
								if (Information.IsNothing((object)num6))
								{
									throttle = patrol5.AttackThrottle_Ship;
								}
								else
								{
									num7 = myUnit.RangeToUnit_Horiz(PrimaryTarget);
									throttle = (((num6.HasValue ? new bool?(num7 > num6.GetValueOrDefault()) : ((bool?)null)) == true) ? new ActiveUnit.Throttle?(patrol5.TransitThrottle_Ship) : patrol5.AttackThrottle_Ship);
								}
							}
						}
						if (!Information.IsNothing((object)throttle))
						{
							myUnit.SetThrottle(throttle.Value);
						}
						else
						{
							Weapon weapon3 = myUnit.Weaponry.MostSuitableWeaponForThisTarget(myUnit.AI.PrimaryTarget, CheckIfWithinRange: true, CheckIfWithinAltitude: true, CheckWRA: true, myUnit.Doctrine, excludeChaffsAndCounterMeasures: false, CheckWeaponQuantity: true);
							if (weapon3 == null)
							{
								method_13();
							}
							else
							{
								float num8 = weapon3.get_MaxRangeForThisTarget(myUnit, myUnit.AI.PrimaryTarget, CheckWRA: true, myUnit.Doctrine, ManualFire: false);
								if (!HasToTMissionAndFiringProposalActive(PrimaryTarget) || !(num8 > Math2.CalcDist(myUnit, myUnit.AI.PrimaryTarget)))
								{
									method_13();
								}
							}
						}
					}
					if (myUnit.AI.MustSlowDownToAllowGroupFormUp())
					{
						float desiredSpeed2 = myUnit.get_ParentGroup(UsingMissionPlanner: false).Kinematics.GroupMaxSpeedForThisThrottleSetting(myUnit.ThrottleSetting);
						myUnit.DesiredSpeed = desiredSpeed2;
					}
					return;
				}
				case ActiveUnit._ActiveUnitStatus.OnPlottedCourse:
					if (!myUnit.IsUsingDippingSonar())
					{
						if (myUnit.IsOnActivePatrol() && !myUnit.Navigator.NextWaypointIsManual)
						{
							if (myUnit.Status == ActiveUnit._ActiveUnitStatus.EngagedOffensive && myUnit.Navigator.PlottedCourse.Length == 1 && myUnit.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.PatrolStation)
							{
								myUnit.Navigator.ClearPlottedCourse();
								return;
							}
							Patrol patrol3 = (Patrol)myUnit.ActiveMissionOrPackage();
							if (!myUnit.Navigator.PlottedCourseLeadsToMissionArea(ref patrol3.PatrolArea, ref patrol3.PatrolArea_30nm_Buffered, ref patrol3.PatrolArea_30nm_ChangeCheck, 30f, IgnoreTimeToNextEvaluation: false))
							{
								myUnit.Navigator.ClearPlottedCourse();
								myUnit.Navigator.PlotCourseToStationArea(elapsedTime, AddWaypointToExistingPlottedCourse: false);
							}
						}
						if (myUnit.IsOnActiveMineClearingMission && myUnit.ParentScen.MineAllocation.ContainsKey(myUnit.ObjectID))
						{
							myUnit.Navigator.bool_0 = false;
							MineClearingMission mineClearingMission = (MineClearingMission)myUnit.ActiveMissionOrPackage();
							if (myUnit.Navigator.TimeToNextPathfinderCheck <= 0f && myUnit.Navigator.IsInsideMissionArea(ref mineClearingMission.Area, ref mineClearingMission.Area_5nm_Buffered, ref mineClearingMission.Area_5nm_ChangeCheck, 5, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
							{
								myUnit.Navigator.TimeToNextPathfinderCheck = GameGeneral.GlobalRNG.Next(10, 20);
							}
						}
						myUnit.Navigator.FollowPlottedCourse(elapsedTime);
						if (!myUnit.Navigator.HasPlottedCourse() && myUnit.Kinematics.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.FullStop && myUnit.DesiredSpeed != 0f)
						{
							myUnit.Kinematics.DesiredSpeedOverride = null;
							myUnit.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
							myUnit.SetThrottle(ActiveUnit.Throttle.FullStop);
							myUnit.Status = myUnit._Status_Oldvalue;
							return;
						}
						if (myUnit.Navigator.HasPlottedCourse() && myUnit.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.LocalizationRun && !Information.IsNothing((object)PrimaryTarget) && !Information.IsNothing((object)PrimaryTarget.UncertaintyArea) && !((Module_Unit.Unit)myUnit).get_IsInsideThisArea(PrimaryTarget.UncertaintyArea, myUnit.ParentScen, UseCache: true))
						{
							myUnit.SetThrottle(ActiveUnit.Throttle.Full);
							if (!CanInterceptTargetAtCurrentAltSpeed(PrimaryTarget, myUnit.RangeToUnit_Horiz(PrimaryTarget), 0f, myUnit.CurrentSpeed, myUnit.CurrentHeading, null, IgnoreMotionVectors: true, TotalRemainingEndurance: true, BingoFuelEndurance: false))
							{
								myUnit.SetThrottle(ActiveUnit.Throttle.Flank);
							}
							if (myUnit.AI.MustSlowDownToAllowGroupFormUp())
							{
								float desiredSpeed = myUnit.get_ParentGroup(UsingMissionPlanner: false).Kinematics.GroupMaxSpeedForThisThrottleSetting(myUnit.ThrottleSetting);
								myUnit.DesiredSpeed = desiredSpeed;
							}
							return;
						}
						if (!myUnit.Kinematics.DesiredSpeedOverride.HasValue && !myUnit.Navigator.SprintDrift)
						{
							if (myUnit.IsOnActivePatrol())
							{
								Patrol patrol4 = (Patrol)myUnit.ActiveMissionOrPackage();
								if (!myUnit.Navigator.IsInsideMissionArea(ref patrol4.PatrolArea, ref patrol4.PatrolArea_2nm_Buffered, ref patrol4.PatrolArea_2nm_ChangeCheck, 2, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
								{
									if (!Information.IsNothing((object)patrol4.TransitThrottle_Ship))
									{
										myUnit.SetThrottle(patrol4.TransitThrottle_Ship);
									}
								}
								else if (!Information.IsNothing((object)patrol4.StationThrottle_Ship))
								{
									myUnit.SetThrottle(patrol4.StationThrottle_Ship);
								}
							}
							else if (!myUnit.IsOnActiveMiningMission)
							{
								if (myUnit.IsOnActiveMineClearingMission)
								{
									MineClearingMission mineClearingMission2 = (MineClearingMission)myUnit.ActiveMissionOrPackage();
									bool flag3 = false;
									float num2 = 9999f;
									foreach (ActiveUnit assignedBoat in myUnit.DockingOps.AssignedBoats)
									{
										if (!assignedBoat.IsOperating() || !assignedBoat.IsOnActiveMineClearingMission)
										{
											continue;
										}
										if (!assignedBoat.IsRTB)
										{
											if (((Submarine)assignedBoat).IsTetheredROV)
											{
												_ = (float)assignedBoat.Kinematics.GetMaximumSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Loiter, ValidateAndFixAltitude: false);
												num2 = Math.Min(num2, Math.Max(1f, assignedBoat.DesiredSpeed - 1f));
												flag3 = true;
											}
										}
										else if ((float)assignedBoat.Kinematics.GetMaximumSpeed(assignedBoat.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Cruise, ValidateAndFixAltitude: false) >= 5f)
										{
											num2 = Math.Min(num2, (float)(0.5 * (double)assignedBoat.Kinematics.GetMaximumSpeed(assignedBoat.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Cruise, ValidateAndFixAltitude: false)));
											flag3 = true;
										}
									}
									bool flag4 = myUnit.Navigator.IsInsideMissionArea(ref mineClearingMission2.Area, ref mineClearingMission2.Area_2nm_Buffered, ref mineClearingMission2.Area_2nm_ChangeCheck, 2, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false);
									if (flag3 && num2 > 0f && num2 < 9999f)
									{
										num2 = ((!flag4) ? Math.Min(num2, myUnit.Kinematics.GetMaximumSpeed(0f, mineClearingMission2.TransitThrottle_Ship, ValidateAndFixAltitude: false)) : Math.Min(num2, myUnit.Kinematics.GetMaximumSpeed(0f, mineClearingMission2.StationThrottle_Ship, ValidateAndFixAltitude: false)));
										myUnit.DesiredSpeed = num2;
									}
									else if (!flag4)
									{
										myUnit.SetThrottle(mineClearingMission2.TransitThrottle_Ship);
									}
									else
									{
										myUnit.SetThrottle(mineClearingMission2.StationThrottle_Ship);
									}
								}
								else if (myUnit.IsOnActiveFerryMission)
								{
									FerryMission ferryMission = (FerryMission)myUnit.ActiveMissionOrPackage();
									if (!myUnit.Kinematics.DesiredSpeedOverride.HasValue)
									{
										if (ferryMission.FerryThrottle_Ship.HasValue)
										{
											myUnit.SetThrottle(ferryMission.FerryThrottle_Ship.Value);
										}
										else
										{
											myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
										}
									}
								}
								else
								{
									myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
								}
							}
							else
							{
								MiningMission miningMission = (MiningMission)myUnit.ActiveMissionOrPackage();
								if (!myUnit.Navigator.IsInsideMissionArea(ref miningMission.Area, ref miningMission.Area_2nm_Buffered, ref miningMission.Area_2nm_ChangeCheck, 2, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
								{
									if (!Information.IsNothing((object)miningMission.TransitThrottle_Ship))
									{
										myUnit.SetThrottle(miningMission.TransitThrottle_Ship);
									}
								}
								else if (!Information.IsNothing((object)miningMission.StationThrottle_Ship))
								{
									myUnit.SetThrottle(miningMission.StationThrottle_Ship);
								}
							}
						}
						if (myUnit.AI.MustSlowDownToAllowGroupFormUp())
						{
							float num3 = float.MaxValue;
							foreach (ActiveUnit value in myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values)
							{
								if (value.IsGroupLead() || value.Navigator.SprintDrift || value.Navigator.HaveReachedFormationStation() || !(value.DesiredSpeed > 0f))
								{
									continue;
								}
								if (value.Kinematics.HasAdjustedSpeedForCavitation && !value.IsGroupLead())
								{
									if ((double)value.DesiredSpeed * 0.8 < (double)num3)
									{
										num3 = (float)((double)value.DesiredSpeed * 0.8);
									}
								}
								else if (value.DesiredSpeed / 2f < num3)
								{
									num3 = value.DesiredSpeed / 2f;
								}
							}
							if (myUnit.Navigator.SprintDrift)
							{
								myUnit.Navigator.SprintDrift_AverageSpeed = num3;
							}
							else
							{
								myUnit.DesiredSpeed = num3;
							}
						}
						else if (myUnit.Kinematics.DesiredSpeedOverride.HasValue)
						{
							myUnit.DesiredSpeed = myUnit.Kinematics.DesiredSpeedOverride.Value;
						}
						else if (myUnit.IsGroupMember())
						{
							if (!myUnit.IsGroupLead())
							{
								if (myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.SprintDrift && !Information.IsNothing((object)myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.SprintDrift_AverageSpeed))
								{
									if (!myUnit.Navigator.SprintDrift)
									{
										myUnit.DesiredSpeed = myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.SprintDrift_AverageSpeed.Value;
									}
									else
									{
										myUnit.Navigator.SprintDrift_AverageSpeed = myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.SprintDrift_AverageSpeed;
									}
								}
								else if (myUnit.Navigator.SprintDrift)
								{
									myUnit.Navigator.SprintDrift_AverageSpeed = myUnit.get_ParentGroup(UsingMissionPlanner: false).DesiredSpeed;
								}
								else
								{
									myUnit.DesiredSpeed = myUnit.get_ParentGroup(UsingMissionPlanner: false).DesiredSpeed;
								}
							}
							else
							{
								float num4 = float.MaxValue;
								foreach (ActiveUnit value2 in myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values)
								{
									if (value2.Kinematics.HasAdjustedSpeedForCavitation)
									{
										num4 = value2.DesiredSpeed;
										continue;
									}
									if (value2.Navigator.SprintDrift)
									{
										if (!Information.IsNothing((object)value2.Navigator.SprintDrift_AverageSpeed))
										{
											num4 = value2.Navigator.SprintDrift_AverageSpeed.Value;
										}
										continue;
									}
									float num5 = value2.Kinematics.GetMaximumSpeed(value2.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), myUnit.ThrottleSetting, ValidateAndFixAltitude: false);
									if (num5 < num4)
									{
										num4 = num5;
									}
								}
								if (!myUnit.Navigator.SprintDrift)
								{
									myUnit.DesiredSpeed = num4;
								}
								else
								{
									myUnit.Navigator.SprintDrift_AverageSpeed = num4;
								}
							}
						}
						if (myUnit.IsOnActiveMiningMission)
						{
							method_15(elapsedTime);
						}
						if (!myUnit.Navigator.SprintDrift)
						{
							myUnit.SetThrottle(myUnit.Kinematics.GetThrottleSuitableForThisSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (int)Math.Round(myUnit.DesiredSpeed)), (int)Math.Round(myUnit.DesiredSpeed));
						}
						else
						{
							myUnit.Navigator.PerformSprintDrift(elapsedTime);
						}
						if (myUnit.IsOnActiveMineClearingMission && myUnit.ParentScen.FifteenthSecondIsChangingOnThisPulse)
						{
							method_14(elapsedTime);
						}
					}
					else
					{
						myUnit.Kinematics.DesiredSpeedOverride = null;
						myUnit.SetThrottle(ActiveUnit.Throttle.FullStop);
						myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, myUnit.CurrentHeading);
					}
					return;
				case ActiveUnit._ActiveUnitStatus.OnPatrol:
					if (!Information.IsNothing((object)myUnit.ActiveMissionOrPackage()))
					{
						if (myUnit.ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Patrol)
						{
							break;
						}
						Patrol patrol = (Patrol)myUnit.ActiveMissionOrPackage();
						if (Information.IsNothing((object)patrol))
						{
							activeUnitStatus = ActiveUnit._ActiveUnitStatus.Unassigned;
							return;
						}
						if (!myUnit.IsGroupMember())
						{
							if (!myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
							{
								myUnit.Navigator.PlotCourseToStationArea(elapsedTime, AddWaypointToExistingPlottedCourse: false);
							}
							else
							{
								if (!myUnit.Navigator.PlottedCourseLeadsToMissionArea(ref patrol.PatrolArea, ref patrol.PatrolArea_30nm_Buffered, ref patrol.PatrolArea_30nm_ChangeCheck, 30f, IgnoreTimeToNextEvaluation: false))
								{
									myUnit.Navigator.PlotCourseToStationArea(elapsedTime, AddWaypointToExistingPlottedCourse: false);
								}
								myUnit.Navigator.FollowPlottedCourse(elapsedTime);
							}
						}
						else if (!myUnit.IsGroupLead())
						{
							if (myUnit.CommStuff.IsConnectedToSideNetwork)
							{
								myUnit.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
							}
						}
						else if (!myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
						{
							myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlotCourseToStationArea(elapsedTime, AddWaypointToExistingPlottedCourse: false);
						}
						else
						{
							if (!myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlottedCourseLeadsToMissionArea(ref patrol.PatrolArea, ref patrol.PatrolArea_30nm_Buffered, ref patrol.PatrolArea_30nm_ChangeCheck, 30f, IgnoreTimeToNextEvaluation: false))
							{
								myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlotCourseToStationArea(elapsedTime, AddWaypointToExistingPlottedCourse: false);
							}
							myUnit.Navigator.FollowPlottedCourse(elapsedTime);
						}
						if (!myUnit.Kinematics.DesiredSpeedOverride.HasValue && !myUnit.Navigator.IsManouveringToFormationStation && !myUnit.AI.MustSlowDownToAllowGroupFormUp())
						{
							if (!myUnit.Navigator.IsInsideMissionArea(ref patrol.PatrolArea, ref patrol.PatrolArea_2nm_Buffered, ref patrol.PatrolArea_2nm_ChangeCheck, 2, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
							{
								if (!Information.IsNothing((object)patrol.TransitThrottle_Ship))
								{
									myUnit.SetThrottle(patrol.TransitThrottle_Ship);
								}
							}
							else if (!Information.IsNothing((object)patrol.StationThrottle_Ship))
							{
								myUnit.SetThrottle(patrol.StationThrottle_Ship);
							}
						}
						if (!Information.IsNothing((object)myUnit.ActiveMissionOrPackage()))
						{
							GlobalVariables.PatrolType type = ((Patrol)myUnit.ActiveMissionOrPackage()).Type;
							if (type == GlobalVariables.PatrolType.ASW || type == GlobalVariables.PatrolType.SeaControl)
							{
								Patrol patrol2 = (Patrol)myUnit.ActiveMissionOrPackage();
								if (myUnit.Navigator.IsInsideMissionArea(ref patrol2.PatrolArea, ref patrol2.PatrolArea_2nm_Buffered, ref patrol2.PatrolArea_2nm_ChangeCheck, 2, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false) && (!myUnit.IsGroupMember() || myUnit.IsGroupLead() || myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead == null || !myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.IsBoat || !((IBoat)myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead).IsCavitating()))
								{
									myUnit.Kinematics.AdjustSpeedForCavitation();
								}
							}
						}
						if (myUnit.Navigator.SprintDrift)
						{
							myUnit.Navigator.PerformSprintDrift(elapsedTime);
						}
						return;
					}
					activeUnitStatus = ActiveUnit._ActiveUnitStatus.Unassigned;
					break;
				}
				if (activeUnitStatus == ActiveUnit._ActiveUnitStatus.OnSupportMission)
				{
					if (Information.IsNothing((object)myUnit.ActiveMissionOrPackage()))
					{
						activeUnitStatus = ActiveUnit._ActiveUnitStatus.Unassigned;
					}
					else if (myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Support)
					{
						if (Information.IsNothing((object)myUnit.ActiveMissionOrPackage()))
						{
							activeUnitStatus = ActiveUnit._ActiveUnitStatus.Unassigned;
						}
						else
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
					}
				}
				if (activeUnitStatus == ActiveUnit._ActiveUnitStatus.OnFerryMission)
				{
					if (Information.IsNothing((object)myUnit.ActiveMissionOrPackage()))
					{
						activeUnitStatus = ActiveUnit._ActiveUnitStatus.Unassigned;
					}
					else if (myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Ferry)
					{
						FerryMission ferryMission2 = (FerryMission)myUnit.ActiveMissionOrPackage();
						if (!myUnit.Kinematics.DesiredSpeedOverride.HasValue && ferryMission2.FerryThrottle_Ship.HasValue)
						{
							_ = ferryMission2.FerryThrottle_Ship.Value;
						}
						if (myUnit.IsGroupWingman())
						{
							myUnit.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
						}
						else if (!Information.IsNothing((object)myUnit.DockingOps.ActualDestinationHost))
						{
							ReturnToBase(elapsedTime);
						}
						else
						{
							string text = "";
							if (Operators.CompareString(myUnit.Name, myUnit.UnitClass, false) != 0)
							{
								text = " (" + myUnit.UnitClass + ")";
							}
							myUnit.ParentScen.AddMessage("Ship: " + myUnit.Name + text + " is assigned to a ferry mission but it cannot dock at the desired destination. Unassigning ship and returning to nearest base.", myUnit.Name + " cannot dock at destination; aborting ferry", LoggedMessage.MessageType.DockingOps, 0, null, myUnit.get_UnitSide(SetSideOnly: false));
							ActiveUnit activeUnit = myUnit;
							Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
							activeUnit.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: false, ref Result);
							myUnit.DockingOps.AttemptToRTB(ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB, GroupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, DetachFromGroup: true, ClearPlottedCourse: true);
						}
					}
				}
				if (activeUnitStatus == ActiveUnit._ActiveUnitStatus.Tasked)
				{
					if (IsEscort)
					{
						HeadToNearestEscortSubject();
						return;
					}
					if (myUnit.IsOnActiveMiningMission)
					{
						method_15(elapsedTime);
						return;
					}
					if (myUnit.IsOnActiveCargoMission)
					{
						Manouver_CargoMission(elapsedTime);
						return;
					}
					if (myUnit.IsOnActiveMineClearingMission)
					{
						method_14(elapsedTime);
						return;
					}
					if (Information.IsNothing((object)PrimaryTarget) && !myUnit.Kinematics.DesiredSpeedOverride.HasValue)
					{
						myUnit.SetThrottle(ActiveUnit.Throttle.FullStop);
					}
				}
				if (myUnit.IsGroupMember())
				{
					if (!myUnit.IsGroupLead() && !Information.IsNothing((object)myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead) && myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.DockingOps.UNREP_Destination == myUnit)
					{
						switch (myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Status)
						{
						case ActiveUnit._ActiveUnitStatus.Refuelling:
							myUnit.set_DesiredHeading(myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.DesiredTurnRate, myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.DesiredHeading);
							myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
							return;
						case ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint:
							myUnit.set_DesiredHeading(myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.DesiredTurnRate, Module_Unit.BearingToUnit_True(myUnit, myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead));
							myUnit.SetThrottle(ActiveUnit.Throttle.Full);
							return;
						}
						if (myUnit.CommStuff.IsConnectedToSideNetwork)
						{
							myUnit.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
						}
					}
					else if (myUnit.CommStuff.IsConnectedToSideNetwork)
					{
						myUnit.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
					}
				}
				else if (myUnit.Status == ActiveUnit._ActiveUnitStatus.Unassigned)
				{
					myUnit.DesiredSpeed = 0f;
				}
				return;
			}
			if (myUnit.IsOnActiveMiningMission)
			{
				myUnit.AI.MiningInfo = null;
			}
			switch (myUnit.DockingOps.Condition)
			{
			case ActiveUnit_DockingOps._DockingOpsCondition.Underway:
				myUnit.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.RTB;
				ReturnToBase(elapsedTime);
				break;
			case ActiveUnit_DockingOps._DockingOpsCondition.DeployingDippingSonar:
				myUnit.Kinematics.DesiredSpeedOverride = null;
				myUnit.SetThrottle(ActiveUnit.Throttle.FullStop);
				myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, myUnit.CurrentHeading);
				break;
			case ActiveUnit_DockingOps._DockingOpsCondition.RTB:
				if (myUnit.IsGroupMember())
				{
					myUnit.DetachUnit(NotifyPlayer: false, ClearPlottedCourse: true, UseFlightplan: false);
				}
				ReturnToBase(elapsedTime);
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100780", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_14(float float_0)
	{
		float num = 1f;
		try
		{
			_Closure$__14-0 arg = default(_Closure$__14-0);
			_Closure$__14-0 CS$<>8__locals30 = new _Closure$__14-0(arg);
			CS$<>8__locals30.$VB$Me = this;
			MineClearingMission mineClearingMission = (MineClearingMission)myUnit.ActiveMissionOrPackage();
			bool flag;
			if (!(flag = myUnit.Navigator.IsInsideMissionArea(ref mineClearingMission.Area, ref mineClearingMission.Area_2nm_Buffered, ref mineClearingMission.Area_2nm_ChangeCheck, 2, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false)))
			{
				if (myUnit.IsGroupMember())
				{
					if (myUnit.IsGroupLead())
					{
						if (myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
						{
							if (!myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlottedCourseLeadsToMissionArea(ref mineClearingMission.Area, ref mineClearingMission.Area_30nm_Buffered, ref mineClearingMission.Area_30nm_ChangeCheck, 30f, IgnoreTimeToNextEvaluation: false))
							{
								myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlotCourseToStationArea(float_0, AddWaypointToExistingPlottedCourse: false);
							}
							myUnit.Navigator.FollowPlottedCourse(float_0);
						}
						else
						{
							myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlotCourseToStationArea(float_0, AddWaypointToExistingPlottedCourse: false);
						}
					}
					else if (myUnit.CommStuff.IsConnectedToSideNetwork)
					{
						myUnit.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(float_0);
					}
				}
				else if (myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
				{
					if (!myUnit.Navigator.PlottedCourseLeadsToMissionArea(ref mineClearingMission.Area, ref mineClearingMission.Area_30nm_Buffered, ref mineClearingMission.Area_30nm_ChangeCheck, 30f, IgnoreTimeToNextEvaluation: false))
					{
						myUnit.Navigator.PlotCourseToStationArea(float_0, AddWaypointToExistingPlottedCourse: false);
					}
					myUnit.Navigator.FollowPlottedCourse(float_0);
				}
				else
				{
					myUnit.Navigator.PlotCourseToStationArea(float_0, AddWaypointToExistingPlottedCourse: false);
				}
				return;
			}
			bool flag2 = true;
			foreach (Sensor mineCountermeasure in myUnit.MineCountermeasures)
			{
				if (mineCountermeasure.IsActive())
				{
					flag2 = false;
					break;
				}
			}
			float num2 = 1f;
			CS$<>8__locals30.$VB$Local_myMission = (MineClearingMission)myUnit.ActiveMissionOrPackage();
			CS$<>8__locals30.$VB$Local_MissionArea = CS$<>8__locals30.$VB$Local_myMission.Area;
			CS$<>8__locals30.$VB$Local_LegitTargets = new TList<UnguidedWeapon>();
			CS$<>8__locals30.$VB$Local_WeaponsDic = new ObservableDictionary<string, UnguidedWeapon>();
			int num3 = myUnit.ParentScen.Mines.Count - 1;
			for (int i = 0; i <= num3; i++)
			{
				if (i < myUnit.ParentScen.Mines.Count)
				{
					num = 1.1f;
					CS$<>8__locals30.$VB$Local_WeaponsDic.Add(myUnit.ParentScen.Mines[i].ObjectID, myUnit.ParentScen.Mines[i]);
				}
			}
			num = 1.2f;
			if (myUnit.HasMineCountermeasures() || myUnit.HasMineCounterWeapons())
			{
				try
				{
					Parallel.ForEach(myUnit.get_UnitSide(SetSideOnly: false).Contacts_NonAU, [SpecialName] (string theUW_ObjectID) =>
					{
						if (theUW_ObjectID != null)
						{
							UnguidedWeapon value5 = default(UnguidedWeapon);
							CS$<>8__locals30.$VB$Local_WeaponsDic.TryGetValue(theUW_ObjectID, ref value5);
							if (!Information.IsNothing((object)value5) && value5.IsMine)
							{
								if (((Module_Unit.Unit)value5).get_IsInsideThisArea(CS$<>8__locals30.$VB$Local_MissionArea, CS$<>8__locals30.$VB$Me.myUnit.ParentScen, UseCache: true))
								{
									CS$<>8__locals30.$VB$Local_LegitTargets.Add(value5);
								}
								else if (CS$<>8__locals30.$VB$Local_myMission.MovementStyle == Mission.MissionMovementStyle.RepeatableLoop && CS$<>8__locals30.$VB$Me.myUnit.Navigator.IsInsideMissionArea(ref CS$<>8__locals30.$VB$Local_MissionArea, ref CS$<>8__locals30.$VB$Local_myMission.Area_2nm_Buffered, ref CS$<>8__locals30.$VB$Local_myMission.Area_2nm_ChangeCheck, 2, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
								{
									CS$<>8__locals30.$VB$Local_LegitTargets.Add(value5);
								}
							}
						}
					});
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
			}
			TList<UnguidedWeapon> tList = new TList<UnguidedWeapon>();
			UnguidedWeapon unguidedWeapon = null;
			float num4 = 0f;
			num = 2f;
			foreach (UnguidedWeapon item in CS$<>8__locals30.$VB$Local_LegitTargets)
			{
				if (item == null)
				{
					continue;
				}
				float num5 = myUnit.RangeToUnit_Horiz(item);
				if (item != null && item.Mine_Targeted == null)
				{
					if (unguidedWeapon == null)
					{
						unguidedWeapon = item;
						num4 = num5;
					}
					else if (num5 > num4)
					{
						unguidedWeapon = item;
						num4 = num5;
					}
				}
				if (num5 > num2)
				{
					if (item.Mine_Targeted != null && Operators.CompareString(item.Mine_Targeted.ObjectID, myUnit.ObjectID, false) == 0)
					{
						item.Mine_Targeted = null;
						myUnit.ParentScen.MineAllocation.Remove(myUnit.ObjectID);
					}
					continue;
				}
				if ((double)num5 * 1852.0 < 300.0)
				{
					continue;
				}
				if (item.Mine_Targeted != null)
				{
					if (!myUnit.ParentScen.ActiveUnits.ContainsKey(item.Mine_Targeted.ObjectID))
					{
						item.Mine_Targeted = null;
					}
					if (item.Mine_Targeted != null && myUnit.ParentScen.MineAllocation.ContainsKey(item.Mine_Targeted.ObjectID) && !myUnit.ParentScen.MineAllocation.Contains(new KeyValuePair<string, UnguidedWeapon>(item.Mine_Targeted.ObjectID, item)))
					{
						item.Mine_Targeted = null;
					}
					if (item.Mine_Targeted != null && !item.Mine_Targeted.Equals(myUnit))
					{
						ActiveUnit mine_Targeted = item.Mine_Targeted;
						if (mine_Targeted == null || !mine_Targeted.IsWeapon)
						{
							if (!myUnit.get_UnitSide(SetSideOnly: false).Units.Contains(item.Mine_Targeted))
							{
								item.Mine_Targeted = null;
							}
							else
							{
								if (item.Mine_Targeted?.ActiveMissionOrPackage() != null)
								{
									ActiveUnit mine_Targeted2 = item.Mine_Targeted;
									if (mine_Targeted2 == null || mine_Targeted2.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.MineClearing)
									{
										bool? obj;
										if (!(num5 < num2 / 2f))
										{
											obj = false;
										}
										else
										{
											float num6 = num5;
											float? num7 = item.Mine_Targeted?.RangeToUnit_Horiz(item);
											obj = ((!num7.HasValue) ? ((bool?)null) : new bool?(num6 < num7.GetValueOrDefault()));
										}
										bool? flag3 = obj;
										if ((flag3 ?? true) && myUnit.get_CanSweepMine(item) && flag3.HasValue && item.Mine_Targeted != null)
										{
											myUnit.ParentScen.MineAllocation.Remove(item.Mine_Targeted.ObjectID);
											if (item.Mine_Targeted.Navigator.HasPlottedCourse() && item.Mine_Targeted.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.TerminalPoint)
											{
												item.Mine_Targeted.Navigator.RemoveWaypoint_Soft(item.Mine_Targeted.Navigator.PlottedCourse[0], RemoveWingmanWaypoints: false);
											}
											else if (item.Mine_Targeted.Navigator.PlottedCourse.Count() <= 1)
											{
												item.Mine_Targeted.Navigator.ClearPlottedCourse();
												item.Mine_Targeted.Navigator.PlotCourseToStationArea(float_0, AddWaypointToExistingPlottedCourse: false);
											}
											item.Mine_Targeted = null;
										}
										goto IL_07fd;
									}
								}
								item.Mine_Targeted = null;
							}
						}
					}
					else if (item.Mine_Targeted != null && item.Mine_Targeted.Equals(myUnit) && myUnit.get_CanSweepMine(item))
					{
						tList.Add(item);
						if (!myUnit.ParentScen.MineAllocation.ContainsKey(myUnit.ObjectID))
						{
							myUnit.ParentScen.MineAllocation.Add(myUnit.ObjectID, item);
						}
					}
					else if (item.Mine_Targeted != null)
					{
						myUnit.ParentScen.MineAllocation.Remove(item.Mine_Targeted.ObjectID);
						if (item.Mine_Targeted.Navigator.HasPlottedCourse() && item.Mine_Targeted.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.TerminalPoint)
						{
							item.Mine_Targeted.Navigator.RemoveWaypoint_Soft(item.Mine_Targeted.Navigator.PlottedCourse[0], RemoveWingmanWaypoints: false);
						}
						else if (item.Mine_Targeted.Navigator.PlottedCourse.Count() <= 1)
						{
							item.Mine_Targeted.Navigator.ClearPlottedCourse();
							item.Mine_Targeted.Navigator.PlotCourseToStationArea(float_0, AddWaypointToExistingPlottedCourse: false);
						}
						item.Mine_Targeted = null;
					}
					goto IL_07fd;
				}
				tList.Add(item);
				continue;
				IL_07fd:
				if (item.Mine_Targeted == null)
				{
					tList.Add(item);
				}
			}
			try
			{
				UnguidedWeapon value = null;
				bool flag4 = false;
				num = 3f;
				int num8 = myUnit.ParentScen.MineAllocation.Count - 1;
				for (int num9 = 0; num9 <= num8; num9++)
				{
					if (num9 >= myUnit.ParentScen.MineAllocation.Count)
					{
						continue;
					}
					num = 3.2f;
					value = myUnit.ParentScen.MineAllocation.Values.ElementAtOrDefault(num9);
					if (value == null || value.Mine_Targeted == null || Operators.CompareString(value.Mine_Targeted.ObjectID, myUnit.ObjectID, false) == 0)
					{
						continue;
					}
					int num10;
					if (!((double)myUnit.RangeToUnit_Horiz(value.Mine_Targeted) * 1852.0 < 1500.0))
					{
						if ((double)myUnit.RangeToUnit_Horiz(value) * 1852.0 >= 1500.0)
						{
							continue;
						}
						num10 = 1;
					}
					else
					{
						num10 = 1;
					}
					flag4 = (byte)num10 != 0;
					break;
				}
				num = 3.3f;
				if (flag4)
				{
					if (myUnit.ParentScen.MineAllocation.TryGetValue(myUnit.ObjectID, ref value))
					{
						if (value != null)
						{
							value.Mine_Targeted = null;
							myUnit.ParentScen.MineAllocation.Remove(myUnit.ObjectID);
						}
						if (myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse() && myUnit.Navigator.HasPlottedCourse() && myUnit.Navigator.PlottedCourse.Count() > 1 && myUnit.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.TerminalPoint)
						{
							myUnit.Navigator.RemoveWaypoint_Soft(myUnit.Navigator.PlottedCourse[0], RemoveWingmanWaypoints: true);
						}
					}
					foreach (Sensor mineCountermeasure2 in myUnit.MineCountermeasures)
					{
						if (mineCountermeasure2.IsActive())
						{
							mineCountermeasure2.TimeToNextScan = 360;
						}
					}
					tList.Clear();
				}
				UnguidedWeapon unguidedWeapon3 = null;
				num = 4f;
				if (tList.Count > 0 && (myUnit.HasMineCountermeasures() || myUnit.HasMineCounterWeapons()))
				{
					while (tList.Count > 0)
					{
						unguidedWeapon3 = (from theMine in tList.ToList()
							where theMine != null && myUnit.get_CanSweepMine(theMine)
							orderby Module_Unit.RangeToUnit_Horiz_Angular(myUnit, theMine)
							select theMine).ElementAtOrDefault(0);
						if (unguidedWeapon3 == null || unguidedWeapon3.Mine_Targeted == null || unguidedWeapon3.Mine_Targeted.Equals(myUnit))
						{
							break;
						}
						if (((Module_Unit.Unit)unguidedWeapon3).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < -5f)
						{
							tList.Remove(unguidedWeapon3);
						}
						else
						{
							tList.Remove(unguidedWeapon3);
						}
					}
				}
				else
				{
					myUnit.ParentScen.MineAllocation.Remove(myUnit.ObjectID);
				}
				if (flag4)
				{
					unguidedWeapon3 = null;
				}
				int num11;
				if (unguidedWeapon3 == null)
				{
					num11 = 0;
				}
				else if (myUnit.Navigator.PlottedCourse.Count() > 0 && myUnit.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.TerminalPoint)
				{
					unguidedWeapon3 = null;
					num11 = 0;
				}
				else
				{
					num11 = 0;
				}
				bool flag5 = (byte)num11 != 0;
				if (myUnit.Weaponry != null && tList.Count > 0 && myUnit.HasMineCounterWeapons())
				{
					float num12 = 500f;
					if (myUnit.ParentScen.MineAllocation.ContainsKey(myUnit.ObjectID))
					{
						num12 = 1000f;
					}
					if (!((unguidedWeapon3 == null) & (tList.Count > 0)))
					{
						if (tList.Count > 0)
						{
							IOrderedEnumerable<UnguidedWeapon> orderedEnumerable = tList.OrderBy([SpecialName] (UnguidedWeapon theMine) => Module_Unit.RangeToUnit_Horiz_Angular(myUnit, theMine));
							foreach (UnguidedWeapon item2 in orderedEnumerable)
							{
								if (item2 == null)
								{
									continue;
								}
								num12 = 500f;
								if (myUnit.ParentScen.MineAllocation.ContainsKey(myUnit.ObjectID))
								{
									num12 = 1000f;
								}
								if ((double)myUnit.RangeToUnit_Horiz(item2) * 1852.0 < (double)num12 || (!flag2 && item2.Type != Weapon._WeaponType.BottomMine && item2.Type != Weapon._WeaponType.RisingMine))
								{
									continue;
								}
								foreach (Mount mount in myUnit.Mounts)
								{
									if (mount.TimeToFire != 0f)
									{
										continue;
									}
									foreach (WeaponRec mountWeapon in mount.MountWeapons)
									{
										WeaponRec theWeaponRec = mountWeapon;
										if (theWeaponRec.TimeToFire != 0f || theWeaponRec.CurrentLoad < 1)
										{
											continue;
										}
										Weapon weapon = theWeaponRec.get_ReferenceWeapon(myUnit.ParentScen);
										if (weapon.Type != Weapon._WeaponType.Torpedo || !weapon.ValidTargets.Mine || item2.Mine_Targeted != null)
										{
											continue;
										}
										AimpointContact theTarget = new AimpointContact(((Module_Unit.Unit)item2).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)item2).get_Longitude((GlobalVariables.BooleanObject)null)) { [false, null] = ((Module_Unit.Unit)item2).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) };
										if (myUnit.RangeToUnit_Horiz(item2) >= weapon.MaxSubsurfaceRange / 2f)
										{
											continue;
										}
										ActiveUnit_Weaponry weaponry = myUnit.Weaponry;
										int NumberOfWeaponsFired = 1;
										WeaponSalvo theWeaponSalvo = null;
										List<Module_Unit.Unit> list = weaponry.FireWeapon_Normal(float_0, ref theWeaponRec, theTarget, ref NumberOfWeaponsFired, 0, 0f, ActiveUnit.Throttle.Flank, null, SonarModel.PositionRelativeToThermocline.Above, 0L, ref theWeaponSalvo);
										int num13;
										if (list.Count > 0)
										{
											Module_Unit.Unit unit = list.First();
											if (!myUnit.ParentScen.MineAllocation.ContainsKey(unit.ObjectID))
											{
												myUnit.ParentScen.MineAllocation.Add(unit.ObjectID, item2);
											}
											item2.Mine_Targeted = (ActiveUnit)unit;
											ActiveUnit obj2 = (ActiveUnit)unit;
											MineClearingMission value2 = CS$<>8__locals30.$VB$Local_myMission;
											Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
											obj2.Set_AssignedMissionOrPackage(value2, SetMissionOnly: true, IgnoreCommsState: true, ref Result);
											num13 = 1;
										}
										else
										{
											num13 = 1;
										}
										flag5 = (byte)num13 != 0;
										break;
									}
									if (flag5)
									{
										break;
									}
								}
							}
						}
					}
					else
					{
						UnguidedWeapon unguidedWeapon4 = (from theMine in tList.ToList()
							where theMine != null
							orderby Module_Unit.RangeToUnit_Horiz_Angular(myUnit, theMine)
							select theMine).ElementAtOrDefault(0);
						if (unguidedWeapon4 != null && (double)myUnit.RangeToUnit_Horiz(unguidedWeapon4) * 1852.0 > (double)num12 && (flag2 || unguidedWeapon4.Type == Weapon._WeaponType.BottomMine || unguidedWeapon4.Type == Weapon._WeaponType.RisingMine))
						{
							foreach (Mount mount2 in myUnit.Mounts)
							{
								if (mount2.TimeToFire != 0f)
								{
									continue;
								}
								foreach (WeaponRec mountWeapon2 in mount2.MountWeapons)
								{
									WeaponRec theWeaponRec2 = mountWeapon2;
									if (theWeaponRec2.TimeToFire != 0f || theWeaponRec2.CurrentLoad < 1)
									{
										continue;
									}
									Weapon weapon2 = theWeaponRec2.get_ReferenceWeapon(myUnit.ParentScen);
									if (weapon2.Type != Weapon._WeaponType.Torpedo || !weapon2.ValidTargets.Mine || unguidedWeapon4.Mine_Targeted != null)
									{
										continue;
									}
									AimpointContact theTarget2 = new AimpointContact(((Module_Unit.Unit)unguidedWeapon4).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)unguidedWeapon4).get_Longitude((GlobalVariables.BooleanObject)null)) { [false, null] = ((Module_Unit.Unit)unguidedWeapon4).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) };
									if (myUnit.RangeToUnit_Horiz(unguidedWeapon4) >= weapon2.MaxSubsurfaceRange / 2f)
									{
										continue;
									}
									ActiveUnit_Weaponry weaponry2 = myUnit.Weaponry;
									int NumberOfWeaponsFired = 1;
									WeaponSalvo theWeaponSalvo = null;
									List<Module_Unit.Unit> list2 = weaponry2.FireWeapon_Normal(float_0, ref theWeaponRec2, theTarget2, ref NumberOfWeaponsFired, 0, 0f, ActiveUnit.Throttle.Flank, null, SonarModel.PositionRelativeToThermocline.Above, 0L, ref theWeaponSalvo);
									int num14;
									if (list2.Count > 0)
									{
										Module_Unit.Unit unit2 = list2.First();
										if (!myUnit.ParentScen.MineAllocation.ContainsKey(unit2.ObjectID))
										{
											myUnit.ParentScen.MineAllocation.Add(unit2.ObjectID, unguidedWeapon4);
										}
										unguidedWeapon4.Mine_Targeted = (ActiveUnit)unit2;
										ActiveUnit obj3 = (ActiveUnit)unit2;
										MineClearingMission value3 = CS$<>8__locals30.$VB$Local_myMission;
										Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
										obj3.Set_AssignedMissionOrPackage(value3, SetMissionOnly: true, IgnoreCommsState: true, ref Result);
										num14 = 1;
									}
									else
									{
										num14 = 1;
									}
									flag5 = (byte)num14 != 0;
									break;
								}
								if (flag5)
								{
									break;
								}
							}
						}
					}
				}
				num = 5f;
				if (unguidedWeapon3 != null)
				{
					float num15 = myUnit.RangeToUnit_Horiz(unguidedWeapon3);
					if (unguidedWeapon3.Mine_Targeted == null && myUnit.ParentScen.MineAllocation.ContainsKey(myUnit.ObjectID))
					{
						value = null;
						if (!myUnit.ParentScen.MineAllocation.TryGetValue(myUnit.ObjectID, ref value))
						{
							value.Mine_Targeted = null;
							myUnit.ParentScen.MineAllocation.Remove(myUnit.ObjectID);
							if (myUnit.Navigator.HasPlottedCourse() && myUnit.Navigator.PlottedCourse.Count() > 0 && myUnit.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.TerminalPoint)
							{
								myUnit.Navigator.RemoveWaypoint_Soft(myUnit.Navigator.PlottedCourse[0], RemoveWingmanWaypoints: true);
							}
						}
						else
						{
							unguidedWeapon3 = value;
							num15 = myUnit.RangeToUnit_Horiz(unguidedWeapon3);
						}
					}
					else if (unguidedWeapon3.Mine_Targeted != null && unguidedWeapon3.Mine_Targeted.Equals(myUnit) && myUnit.Navigator.HasPlottedCourse() && myUnit.Navigator.PlottedCourse.Count() > 0 && myUnit.Navigator.PlottedCourse[0].Type != Waypoint.WaypointType.TerminalPoint)
					{
						ManouverToSweepMine(unguidedWeapon3, num15, ResetPath: true);
					}
					num = 6f;
					if (unguidedWeapon3 != null && unguidedWeapon3.Mine_Targeted == null)
					{
						ManouverToSweepMine(unguidedWeapon3, num15, ResetPath: true);
						unguidedWeapon3.Mine_Targeted = myUnit;
						if (!myUnit.ParentScen.MineAllocation.ContainsKey(myUnit.ObjectID))
						{
							myUnit.ParentScen.MineAllocation.Add(myUnit.ObjectID, unguidedWeapon3);
						}
						else
						{
							UnguidedWeapon value4 = null;
							if (!myUnit.ParentScen.MineAllocation.TryGetValue(myUnit.ObjectID, ref value4) || !unguidedWeapon3.Equals(value4))
							{
								myUnit.ParentScen.MineAllocation.Remove(myUnit.ObjectID);
								myUnit.ParentScen.MineAllocation.Add(myUnit.ObjectID, unguidedWeapon3);
							}
						}
						if (myUnit.ParentScen.MineAllocation.ContainsKey(myUnit.ObjectID))
						{
							myUnit.Navigator.bool_0 = false;
							if (myUnit.Navigator.TimeToNextPathfinderCheck <= 0f && myUnit.Navigator.IsInsideMissionArea(ref mineClearingMission.Area, ref mineClearingMission.Area_5nm_Buffered, ref mineClearingMission.Area_5nm_ChangeCheck, 5, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
							{
								myUnit.Navigator.TimeToNextPathfinderCheck = GameGeneral.GlobalRNG.Next(10, 16);
							}
						}
						myUnit.Navigator.FollowPlottedCourse(float_0);
						if (num15 < 3f)
						{
							myUnit.DesiredSpeed = num15 + 1f;
						}
					}
					else if (unguidedWeapon3 != null && unguidedWeapon3.Mine_Targeted != null && Operators.CompareString(unguidedWeapon3.Mine_Targeted.ObjectID, myUnit.ObjectID, false) == 0)
					{
						if ((double)num15 > 0.6)
						{
							ManouverToSweepMine(unguidedWeapon3, num15, ResetPath: true);
						}
						if (myUnit.Navigator.PlottedCourse.Count() <= 0 || myUnit.Navigator.PlottedCourse[0].Type != Waypoint.WaypointType.TerminalPoint)
						{
							unguidedWeapon3.Mine_Targeted = null;
							myUnit.ParentScen.MineAllocation.Remove(myUnit.ObjectID);
						}
					}
					else if (Information.IsNothing((object)myUnit.Kinematics.DesiredSpeedOverride))
					{
						myUnit.DesiredSpeed = 3f;
						myUnit.SetThrottle(myUnit.Kinematics.GetThrottleSuitableForThisSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (int)Math.Round(myUnit.DesiredSpeed)), (int)Math.Round(myUnit.DesiredSpeed));
					}
				}
				else if (!myUnit.IsGroupMember())
				{
					if (myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
					{
						if (!myUnit.Navigator.PlottedCourseLeadsToMissionArea(ref CS$<>8__locals30.$VB$Local_myMission.Area, ref CS$<>8__locals30.$VB$Local_myMission.Area_30nm_Buffered, ref CS$<>8__locals30.$VB$Local_myMission.Area_30nm_ChangeCheck, 30f, IgnoreTimeToNextEvaluation: false))
						{
							myUnit.Navigator.PlotCourseToStationArea(float_0, AddWaypointToExistingPlottedCourse: false);
						}
						myUnit.Navigator.FollowPlottedCourse(float_0);
					}
					else
					{
						myUnit.Navigator.PlotCourseToStationArea(float_0, AddWaypointToExistingPlottedCourse: false);
					}
				}
				else if (!myUnit.IsGroupLead())
				{
					if (myUnit.CommStuff.IsConnectedToSideNetwork)
					{
						myUnit.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(float_0);
					}
				}
				else if (myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
				{
					if (!myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlottedCourseLeadsToMissionArea(ref CS$<>8__locals30.$VB$Local_myMission.Area, ref CS$<>8__locals30.$VB$Local_myMission.Area_30nm_Buffered, ref CS$<>8__locals30.$VB$Local_myMission.Area_30nm_ChangeCheck, 30f, IgnoreTimeToNextEvaluation: false))
					{
						myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlotCourseToStationArea(float_0, AddWaypointToExistingPlottedCourse: false);
					}
					myUnit.Navigator.FollowPlottedCourse(float_0);
				}
				else
				{
					myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlotCourseToStationArea(float_0, AddWaypointToExistingPlottedCourse: false);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100780", "Nearest mine process");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			try
			{
				if (!myUnit.Kinematics.DesiredSpeedOverride.HasValue)
				{
					bool flag6 = false;
					float num16 = 9999f;
					foreach (ActiveUnit assignedBoat in myUnit.DockingOps.AssignedBoats)
					{
						if (!assignedBoat.IsOperating() || !assignedBoat.IsOnActiveMineClearingMission)
						{
							continue;
						}
						if (!assignedBoat.IsRTB)
						{
							if (assignedBoat.IsSubmarine && ((Submarine)assignedBoat).IsTetheredROV)
							{
								_ = (float)assignedBoat.Kinematics.GetMaximumSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Loiter, ValidateAndFixAltitude: false);
								num16 = Math.Min(num16, Math.Max(1f, assignedBoat.DesiredSpeed - 1f));
								flag6 = true;
							}
						}
						else if ((float)assignedBoat.Kinematics.GetMaximumSpeed(assignedBoat.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Cruise, ValidateAndFixAltitude: false) >= 5f)
						{
							num16 = Math.Min(num16, (float)(0.5 * (double)assignedBoat.Kinematics.GetMaximumSpeed(assignedBoat.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Cruise, ValidateAndFixAltitude: false)));
							flag6 = true;
						}
					}
					if (flag6 && num16 > 0f && num16 < 9999f)
					{
						num16 = (flag ? Math.Min(num16, myUnit.Kinematics.GetMaximumSpeed(0f, CS$<>8__locals30.$VB$Local_myMission.StationThrottle_Ship, ValidateAndFixAltitude: false)) : Math.Min(num16, myUnit.Kinematics.GetMaximumSpeed(0f, CS$<>8__locals30.$VB$Local_myMission.TransitThrottle_Ship, ValidateAndFixAltitude: false)));
						myUnit.DesiredSpeed = num16;
					}
					else if (!flag)
					{
						myUnit.SetThrottle(CS$<>8__locals30.$VB$Local_myMission.TransitThrottle_Ship);
					}
					else
					{
						myUnit.SetThrottle(CS$<>8__locals30.$VB$Local_myMission.StationThrottle_Ship);
					}
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at 100780", "Speed check");
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			try
			{
				ActiveUnit[] array = myUnit.get_UnitSide(SetSideOnly: false).Units.ToArray();
				foreach (ActiveUnit activeUnit in array)
				{
					if (activeUnit == null || !activeUnit.IsSubmarine || (((Submarine)activeUnit).Type != Submarine._SubmarineType.ROV && ((Submarine)activeUnit).Type != Submarine._SubmarineType.UUV) || !activeUnit.IsOperating() || activeUnit.DockingOps.get_AssignedHostUnit(PickNewAssignedHost: false) != myUnit)
					{
						continue;
					}
					ActiveUnit._ActiveUnitFuelState isBingoOrJoker = activeUnit.IsBingoOrJoker;
					if (myUnit.IsRTB)
					{
						activeUnit.AI.ReturnToBase(float_0);
					}
					if (isBingoOrJoker != ActiveUnit._ActiveUnitFuelState.IsBingo && isBingoOrJoker != ActiveUnit._ActiveUnitFuelState.IsJoker)
					{
						if (activeUnit.IsRTB)
						{
							if ((float)activeUnit.Kinematics.GetMaximumSpeed(activeUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Cruise, ValidateAndFixAltitude: false) >= 5f)
							{
								myUnit.DesiredSpeed = (float)(0.5 * (double)activeUnit.Kinematics.GetMaximumSpeed(activeUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Cruise, ValidateAndFixAltitude: false));
								continue;
							}
							myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
							myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, Module_Unit.BearingToUnit_True(myUnit, activeUnit));
						}
					}
					else
					{
						if ((float)activeUnit.Kinematics.GetMaximumSpeed(activeUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Cruise, ValidateAndFixAltitude: false) >= 5f)
						{
							myUnit.DesiredSpeed = (float)(0.5 * (double)activeUnit.Kinematics.GetMaximumSpeed(activeUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Cruise, ValidateAndFixAltitude: false));
						}
						else
						{
							myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
						}
						myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, Module_Unit.BearingToUnit_True(myUnit, activeUnit));
					}
				}
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				ex6?.Data.Add("Error at 100780", "Rov check");
				GameGeneral.WriteExceptionsToLog(ex6);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		catch (Exception ex7)
		{
			ProjectData.SetProjectError(ex7);
			Exception ex8 = ex7;
			ex8?.Data.Add("Error at 100780", "Full sub " + Conversions.ToString(num));
			GameGeneral.WriteExceptionsToLog(ex8);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			_ = ((MineClearingMission)myUnit.ActiveMissionOrPackage()).Area;
			ProjectData.ClearProjectError();
		}
	}

	private void method_15(float float_0)
	{
		MiningMission miningMission = (MiningMission)myUnit.ActiveMissionOrPackage();
		if (myUnit.AI.MiningInfo == null)
		{
			myUnit.AI.MiningInfo = new MiningMission.MiningInformation(null, miningMission.MinesLaidInSets, miningMission.MinesLaidInterval, miningMission.MinesLaidMethod, miningMission.MinesLaidSetInterval);
		}
		if (miningMission.MovementStyle == Patrol.PatrolMovementStyle.RepeatableLoop)
		{
			bool isInTransit = myUnit.Navigator.SupportMission_NextRefPoint == miningMission.Area[0];
			myUnit.Navigator.FollowPatrolRepeatableLoopCourse(float_0, isInTransit);
			return;
		}
		if (myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
		{
			if (myUnit.IsGroupMember())
			{
				ActiveUnit groupLead = myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead;
				if (groupLead.Navigator.PlottedCourse[0].Creator == Waypoint.WaypointCreator.Manual)
				{
					groupLead.Navigator.PlottedCourse[0].Description = "Mining Mission Segment Start - Manual";
					if (!myUnit.Kinematics.DesiredSpeedOverride.HasValue)
					{
						if (myUnit.Navigator.IsInsideMissionArea(ref miningMission.Area, ref miningMission.Area_1nm_Buffered, ref miningMission.Area_1nm_ChangeCheck, 1, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
						{
							myUnit.SetThrottle(miningMission.StationThrottle_Ship);
							return;
						}
						myUnit.SetThrottle(miningMission.TransitThrottle_Ship);
						myUnit.AI.MiningInfo.StartedMining = false;
					}
					return;
				}
			}
			else if (myUnit.Navigator.PlottedCourse[0].Creator == Waypoint.WaypointCreator.Manual)
			{
				myUnit.Navigator.PlottedCourse[0].Description = "Mining Mission Segment Start - Manual";
				if (!myUnit.Kinematics.DesiredSpeedOverride.HasValue)
				{
					if (!myUnit.Navigator.IsInsideMissionArea(ref miningMission.Area, ref miningMission.Area_1nm_Buffered, ref miningMission.Area_1nm_ChangeCheck, 1, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
					{
						myUnit.SetThrottle(miningMission.TransitThrottle_Ship);
						myUnit.AI.MiningInfo.StartedMining = false;
					}
					else
					{
						myUnit.SetThrottle(miningMission.StationThrottle_Ship);
					}
				}
				return;
			}
		}
		GeoPoint geoPoint;
		Waypoint waypoint;
		float num2;
		if (myUnit.IsGroupMember())
		{
			if (!myUnit.IsGroupLead())
			{
				if (myUnit.CommStuff.IsConnectedToSideNetwork)
				{
					myUnit.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(float_0);
				}
			}
			else if (!myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
			{
				myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlotCourseToArea(miningMission.Area);
				if (myUnit.AI.MiningInfo != null)
				{
					myUnit.AI.MiningInfo.ResetMiningInfo(myUnit, miningMission);
				}
			}
			else if (!myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.IsInsideMissionArea(ref miningMission.Area, ref miningMission.Area_1nm_Buffered, ref miningMission.Area_1nm_ChangeCheck, 1, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
			{
				if (!myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlottedCourseLeadsToMissionArea(ref miningMission.Area, ref miningMission.Area_30nm_Buffered, ref miningMission.Area_30nm_ChangeCheck, 30f, IgnoreTimeToNextEvaluation: false))
				{
					myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlotCourseToArea(miningMission.Area);
					if (myUnit.AI.MiningInfo != null)
					{
						myUnit.AI.MiningInfo.ResetMiningInfo(myUnit, miningMission);
					}
				}
				else
				{
					myUnit.Navigator.FollowPlottedCourse(float_0);
				}
			}
			else if (myUnit.AI.MiningInfo != null && !myUnit.AI.MiningInfo.StartedMining)
			{
				myUnit.AI.MiningInfo.StartedMining = true;
			}
		}
		else if (!myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
		{
			if (!myUnit.Navigator.IsInsideMissionArea(ref miningMission.Area, ref miningMission.Area, ref miningMission.Area_ChangeCheck, 0, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
			{
				myUnit.Navigator.PlotCourseToArea(miningMission.Area);
				if (myUnit.Navigator.PlottedCourse.Count() > 0)
				{
					myUnit.Navigator.PlottedCourse[0].Description = "Mining Mission Segment Start";
				}
				if (myUnit.AI.MiningInfo != null)
				{
					myUnit.AI.MiningInfo.ResetMiningInfo(myUnit, miningMission);
				}
			}
			else
			{
				if (myUnit.AI.MiningInfo != null && !myUnit.AI.MiningInfo.StartedMining)
				{
					myUnit.AI.MiningInfo.StartedMining = true;
				}
				MiningMission.MiningInformation miningInfo = myUnit.AI.MiningInfo;
				if (miningInfo != null && miningInfo.Sequence.HasValue)
				{
					int? num = myUnit.AI.MiningInfo?.Sequence;
					if (((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() > 0)) == true)
					{
						if (!myUnit.Navigator.HasPlottedCourse())
						{
							geoPoint = new GeoPoint();
							waypoint = new Waypoint();
							float desiredHeading = myUnit.DesiredHeading;
							num2 = desiredHeading;
							if (miningMission.MinesLaidMethod.HasValue)
							{
								num = miningMission.MinesLaidMethod;
								if (((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() == 0)) == true)
								{
									num2 = desiredHeading;
									goto IL_065c;
								}
							}
							num2 = Math2.NormalizeBearing(desiredHeading + (float)GameGeneral.GlobalRNG.Next(45) - (float)GameGeneral.GlobalRNG.Next(45));
							goto IL_065c;
						}
						goto IL_086c;
					}
				}
				myUnit.Navigator.PlotCourseToArea(miningMission.Area);
				if (myUnit.Navigator.PlottedCourse.Count() > 0)
				{
					myUnit.Navigator.PlottedCourse[0].Description = "Mining Mission Segment Start";
				}
				if (myUnit.AI.MiningInfo != null)
				{
					myUnit.AI.MiningInfo.ResetMiningInfo(myUnit, miningMission);
				}
			}
		}
		else if (!myUnit.Navigator.IsInsideMissionArea(ref miningMission.Area, ref miningMission.Area_1nm_Buffered, ref miningMission.Area_1nm_ChangeCheck, 1, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
		{
			if (!myUnit.Navigator.PlottedCourseLeadsToMissionArea(ref miningMission.Area, ref miningMission.Area_30nm_Buffered, ref miningMission.Area_30nm_ChangeCheck, 30f, IgnoreTimeToNextEvaluation: false))
			{
				myUnit.Navigator.PlotCourseToArea(miningMission.Area);
				if (myUnit.AI.MiningInfo != null)
				{
					myUnit.AI.MiningInfo.ResetMiningInfo(myUnit, miningMission);
				}
				if (myUnit.Navigator.PlottedCourse.Count() > 0)
				{
					myUnit.Navigator.PlottedCourse[0].Description = "Mining Mission Segment Start";
				}
			}
			else
			{
				myUnit.Navigator.FollowPlottedCourse(float_0);
			}
		}
		goto IL_086c;
		IL_065c:
		double lon = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
		double lat = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
		GeoPoint geoPoint2;
		double out_lon = (geoPoint2 = geoPoint).Longitude;
		GeoPoint geoPoint3;
		double out_lat = (geoPoint3 = geoPoint).Latitude;
		Geodesic_EdWilliams.CalcPoint_Williams(lon, lat, ref out_lon, ref out_lat, 0.5, num2);
		geoPoint3.Latitude = out_lat;
		geoPoint2.Longitude = out_lon;
		waypoint.Longitude = geoPoint.Longitude;
		waypoint.Latitude = geoPoint.Latitude;
		waypoint.Type = Waypoint.WaypointType.PatrolStation;
		waypoint.Creator = Waypoint.WaypointCreator.Navigator;
		waypoint.Category = Waypoint.WaypointCategory.PlottedCourse;
		waypoint.Description = "Mining Mission Drop point";
		myUnit.Navigator.AddWaypoint(waypoint);
		goto IL_086c;
		IL_086c:
		if (!myUnit.Kinematics.DesiredSpeedOverride.HasValue)
		{
			if (!myUnit.Navigator.IsInsideMissionArea(ref miningMission.Area, ref miningMission.Area_2nm_Buffered, ref miningMission.Area_2nm_ChangeCheck, 2, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
			{
				myUnit.SetThrottle(miningMission.TransitThrottle_Ship);
			}
			else
			{
				myUnit.SetThrottle(miningMission.StationThrottle_Ship);
			}
		}
	}

	private bool method_16(Geopoint_Struct geopoint_Struct_0, CargoMission cargoMission_0)
	{
		return myUnit.DockingOps.CargoUnloadLocationPointQuery(geopoint_Struct_0, cargoMission_0)?.Any() ?? false;
	}

	protected override void Manouver_CargoMission(float elapsedTime)
	{
		CargoMission cargoMission = (CargoMission)myUnit.ActiveMissionOrPackage();
		bool flag = true;
		if (myUnit.OnboardCargo.Count() != 0)
		{
			if (cargoMission.Type == CargoMission.CargoMissionType.Transfer)
			{
				if (myUnit.IsGroupWingman())
				{
					myUnit.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
					return;
				}
				if (myUnit.DockingOps.ActualDestinationHost == null)
				{
					myUnit.ParentScen.AddMessage("Unit " + myUnit.Name + " is assigned to a cargo mission but cannot dock at current destination. Unassigning unit and attempting to returning to base.", myUnit.Name + " cannot perform cargo mission; aborting", LoggedMessage.MessageType.DockingOps, 0, null, myUnit.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
					ActiveUnit activeUnit = myUnit;
					Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
					activeUnit.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: false, ref Result);
					myUnit.DockingOps.AttemptToRTB(ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB, GroupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, DetachFromGroup: true, ClearPlottedCourse: true);
				}
				else
				{
					ReturnToBase(elapsedTime);
				}
				if (!myUnit.Kinematics.DesiredSpeedOverride.HasValue && flag)
				{
					myUnit.SetThrottle(cargoMission.TransitThrottle_Ship);
				}
				return;
			}
			if (!myUnit.Navigator.HasPlottedCourse())
			{
				if (myUnit.IsGroupWingman())
				{
					myUnit.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
				}
			}
			else
			{
				myUnit.Navigator.FollowPlottedCourse(elapsedTime);
			}
			if (myUnit.Navigator.IsInsideMissionArea(ref cargoMission.Area, ref cargoMission.Area_1nm_Buffered, ref cargoMission.Area_1nm_ChangeCheck, 1, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
			{
				if (myUnit.DockingOps.CanUnloadCargoOverBeach())
				{
					if ((Module_Unit.IsOverLand(myUnit) || Module_Unit.IsOverLand_next(myUnit, elapsedTime)) && method_16(new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)), cargoMission))
					{
						myUnit.DockingOps.SettleForCargoTransfer();
					}
					else if (!method_16(new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)), cargoMission))
					{
						Geopoint_Struct geopoint_Struct = myUnit.DockingOps.FindCoastalUnloadPointForSeaVesselCargoDelivery(cargoMission);
						if (!geopoint_Struct.HasZeroCoords)
						{
							myUnit.Navigator.ClearPlottedCourse();
							myUnit.Navigator.AddWaypoint(geopoint_Struct.Latitude, geopoint_Struct.Longitude, 0f, Waypoint.WaypointType.DropOffPoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse, _Overshoot: false);
							myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), geopoint_Struct.Latitude, geopoint_Struct.Longitude));
						}
					}
					else
					{
						myUnit.DockingOps.SettleForCargoTransfer();
					}
					return;
				}
				myUnit.ParentScen.AddMessage("Unit " + myUnit.Name + " is assigned to a cargo delivery mission but cannot unload cargo ashore. Unassigning unit and attempting to returning to base.", myUnit.Name + " cannot perform cargo mission; aborting", LoggedMessage.MessageType.DockingOps, 0, null, myUnit.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				ActiveUnit activeUnit2 = myUnit;
				Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
				activeUnit2.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: false, ref Result);
				myUnit.DockingOps.AttemptToRTB(ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB, GroupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, DetachFromGroup: true, ClearPlottedCourse: true);
			}
			if (!myUnit.IsGroupMember())
			{
				if (!myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
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
			}
			else if (myUnit.IsGroupLead())
			{
				if (myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
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
			else if (myUnit.CommStuff.IsConnectedToSideNetwork)
			{
				myUnit.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
				flag = false;
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
		}
		else if (cargoMission.RTBUponCompletion)
		{
			if (!myUnit.DockingOps.AttemptToRTB(ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB_MissionOver, GroupMembersRTB: true, ActiveUnit._ActiveUnitStatus.RTB_Group, DetachFromGroup: true, ClearPlottedCourse: true))
			{
				if (myUnit.Navigator.HasPlottedCourse())
				{
					myUnit.Navigator.FollowPlottedCourse(elapsedTime);
					return;
				}
				myUnit.Kinematics.DesiredSpeedOverride = null;
				myUnit.DesiredSpeed = 0f;
				ActiveUnit activeUnit3 = myUnit;
				Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
				activeUnit3.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: true, ref Result);
				myUnit.AddMessage(myUnit.Name + " (" + myUnit.UnitClass + ") is unable to return to base during cargo mission: " + cargoMission.Name + ". The unit will be removed from the mission.", myUnit.Name + " unable to return to base; removed from mission", LoggedMessage.MessageType.DockingOps, 5, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
		}
		else
		{
			ActiveUnit activeUnit4 = myUnit;
			Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
			activeUnit4.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: true, ref Result);
			myUnit.AddMessage(myUnit.Name + " (" + myUnit.UnitClass + ") has completed cargo mission: " + cargoMission.Name + ". The unit will be removed from the mission.", myUnit.Name + " has completed its cargo mission", LoggedMessage.MessageType.DockingOps, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
		}
	}

	public override void ManouverTowardsTarget(float elapsedTime)
	{
		bool flag = false;
		int num;
		if (IsClearedToEngageThisTarget(PrimaryTarget))
		{
			byte? b = (byte?)myUnit.Doctrine.get_MaintainStandoff(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
			{
				flag = MaintainStandoff(elapsedTime);
				num = 0;
				goto IL_008d;
			}
		}
		num = 0;
		goto IL_008d;
		IL_008d:
		bool flag2 = (byte)num != 0;
		if (!flag)
		{
			Weapon theW = null;
			if (PrimaryTarget != null)
			{
				theW = myUnit.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, CheckIfWithinRange: true, CheckIfWithinAltitude: true, CheckWRA: true, myUnit.Doctrine);
			}
			if (theW != null && IsClearedToEngageThisTarget(PrimaryTarget) && myUnit.RangeToUnit_Horiz(PrimaryTarget) <= theW.get_MaxRangeForThisTarget(myUnit, PrimaryTarget, CheckWRA: true, myUnit.Doctrine, ManualFire: false))
			{
				Contact primaryTarget = PrimaryTarget;
				(Mount, float, bool) theMountDetails = default((Mount, float, bool));
				flag2 = TurnToUnmaskPrimaryWeapon(ref theW, primaryTarget, ref theMountDetails);
			}
		}
		if (!flag2 && !flag)
		{
			base.ManouverTowardsTarget(elapsedTime);
		}
		if (PrimaryTarget.Type != Contact_Base.ContactType.Submarine || PrimaryTarget.UncertaintyArea == null)
		{
			return;
		}
		if (!myUnit.Weaponry.HaveSuitableWeaponForAmbigousTarget(PrimaryTarget, CheckCanShootRightNow: false))
		{
			myUnit.Navigator.PlotLocalizationCourse();
			myUnit.Navigator.FollowPlottedCourse(elapsedTime);
		}
		else if (myUnit.Navigator.HasPlottedCourse())
		{
			byte? b = (byte?)myUnit.Doctrine.get_IgnorePlottedCourse(myUnit.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false);
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) == true)
			{
				myUnit.Navigator.FollowPlottedCourse(elapsedTime);
			}
		}
	}

	internal bool MaintainStandoff(float elapsedTime)
	{
		bool result;
		try
		{
			bool_0 = false;
			int num;
			Geopoint_Struct geopoint_Struct;
			if (PrimaryTarget == null)
			{
				result = false;
			}
			else
			{
				if (PrimaryTarget.Type == Contact_Base.ContactType.Air)
				{
					num = 0;
					goto IL_02d7;
				}
				if (PrimaryTarget.Type == Contact_Base.ContactType.Missile)
				{
					num = 0;
					goto IL_02d7;
				}
				Doctrine doctrine = myUnit.Doctrine;
				Weapon weapon = myUnit.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, CheckIfWithinRange: true, CheckIfWithinAltitude: true, CheckWRA: true, doctrine);
				if (weapon != null)
				{
					float num2 = weapon.get_MaxRangeForThisTarget(myUnit, PrimaryTarget, CheckWRA: true, doctrine, ManualFire: false);
					float? num3 = PrimaryTarget.MaxPotentialWeaponRange_ASuW_Naval();
					if (num3.HasValue)
					{
						float value = num3.Value;
						if (value >= num2)
						{
							result = false;
						}
						else
						{
							float num4 = value + (num2 - value) / 4f;
							geopoint_Struct = default(Geopoint_Struct);
							Geodesic_EdWilliams.CalcPoint_Williams(((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ref geopoint_Struct.Longitude, ref geopoint_Struct.Latitude, num4, Math2.CalcAzimuth(((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null)));
							if (!(Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null)) > num4))
							{
								goto IL_0205;
							}
							byte? b = (byte?)myUnit.Doctrine.get_IgnorePlottedCourse(myUnit.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false);
							bool? flag = ((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0));
							if (((!flag) ?? flag) != true)
							{
								goto IL_0205;
							}
							result = true;
						}
					}
					else
					{
						float value = 0f;
						result = false;
					}
				}
				else
				{
					result = false;
				}
			}
			goto end_IL_0001;
			IL_02d7:
			result = (byte)num != 0;
			goto end_IL_0001;
			IL_0205:
			if (Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), geopoint_Struct.Latitude, geopoint_Struct.Longitude) > 1f)
			{
				myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), geopoint_Struct.Latitude, geopoint_Struct.Longitude));
				result = false;
			}
			else
			{
				myUnit.DesiredSpeed = 0f;
				myUnit.SetThrottle(ActiveUnit.Throttle.FullStop, 0f);
				ActiveUnit_Navigator navigator = myUnit.Navigator;
				Waypoint[] theArray = navigator.PlottedCourse;
				ArrayExtensions.Clear(ref theArray);
				navigator.PlottedCourse = theArray;
				bool_0 = true;
				result = true;
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100781", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num5;
			if (!Debugger.IsAttached)
			{
				num5 = 0;
			}
			else
			{
				Debugger.Break();
				num5 = 0;
			}
			result = (byte)num5 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	static Ship_AI()
	{
		Class72.smethod_20();
	}
}
