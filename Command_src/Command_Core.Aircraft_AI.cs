using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Xml;
using Collections.Pooled;
using CSMaterial;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ThreadSafeCollections;

namespace Command_Core;

public sealed class Aircraft_AI : ActiveUnit_AI
{
	public struct RTBRequest
	{
		public delegate void VoidVoidDelegate();

		public delegate void SingleVoidDelegate(float elapsedTime);

		public bool DirectAssignment;

		public bool ManuallyOrdered;

		public ActiveUnit._ActiveUnitStatus _ActiveUnitStatus_0;

		public bool GroupMembersRTB;

		public ActiveUnit._ActiveUnitStatus GroupMembersRTBStatus;

		public bool DetachFromGroup;

		public bool ClearPlottedCourse;

		public Aircraft_AirOps._AirOpsCondition? AirOpsCondition;

		public VoidVoidDelegate onSuccessCallback;

		public VoidVoidDelegate onFailCallback;

		public SingleVoidDelegate onCompletionCallback;

		public RTBRequest(bool manuallyOrdered, ActiveUnit._ActiveUnitStatus _ActiveUnitStatus_1, bool groupMembersRTB, ActiveUnit._ActiveUnitStatus groupMembersRTBStatus, bool detachFromGroup, bool clearPlottedCourse, Aircraft_AirOps._AirOpsCondition? airOpsCondition = null, VoidVoidDelegate onSuccessCallback = null, VoidVoidDelegate onFailCallback = null)
		{
			this = default(RTBRequest);
			DirectAssignment = false;
			ManuallyOrdered = manuallyOrdered;
			_ActiveUnitStatus_0 = _ActiveUnitStatus_1;
			GroupMembersRTB = groupMembersRTB;
			GroupMembersRTBStatus = groupMembersRTBStatus;
			DetachFromGroup = detachFromGroup;
			ClearPlottedCourse = clearPlottedCourse;
			AirOpsCondition = airOpsCondition;
			this.onSuccessCallback = onSuccessCallback;
			this.onFailCallback = onFailCallback;
		}

		public RTBRequest(ActiveUnit._ActiveUnitStatus _ActiveUnitStatus_1, SingleVoidDelegate onCompletionCallback = null)
		{
			this = default(RTBRequest);
			DirectAssignment = true;
			_ActiveUnitStatus_0 = _ActiveUnitStatus_1;
			this.onCompletionCallback = onCompletionCallback;
		}

		private byte method_0()
		{
			if (AirOpsCondition.HasValue && AirOpsCondition.Value == Aircraft_AirOps._AirOpsCondition.EmergencyLanding)
			{
				return 3;
			}
			return _ActiveUnitStatus_0 switch
			{
				ActiveUnit._ActiveUnitStatus.RTB_Exhaustion => 2, 
				ActiveUnit._ActiveUnitStatus.RTB_Manual => 1, 
				_ => 0, 
			};
		}

		public bool takesPrecedenceOver(RTBRequest otherRequest)
		{
			if ((uint)method_0() < (uint)otherRequest.method_0())
			{
				return true;
			}
			return false;
		}

		static RTBRequest()
		{
			Class72.smethod_20();
		}
	}

	public class StatusRelatedEventsInformation
	{
		internal ActiveUnit._ActiveUnitStatus? RestorePreRefuelStatus;

		internal ActiveUnit._ActiveUnitStatus? ForceStatusbeforeEvaluation;

		internal ActiveUnit._ActiveUnitStatus? desiredStatusAfterTankerDisconnect;

		internal bool triedFollowingPlottedCourseButHadNone;

		internal bool GeneratedAttackRoute;

		internal List<RTBRequest> list_0;

		public StatusRelatedEventsInformation()
		{
			RestorePreRefuelStatus = null;
			ForceStatusbeforeEvaluation = null;
			desiredStatusAfterTankerDisconnect = null;
			triedFollowingPlottedCourseButHadNone = false;
			GeneratedAttackRoute = false;
		}

		public void method_0(bool manuallyOrdered, ActiveUnit._ActiveUnitStatus _ActiveUnitStatus_0, bool groupMembersRTB, ActiveUnit._ActiveUnitStatus groupMembersRTBStatus, bool detachFromGroup, bool clearPlottedCourse, Aircraft_AirOps._AirOpsCondition? airOpsCondition = null, RTBRequest.VoidVoidDelegate onSuccessCallback = null, RTBRequest.VoidVoidDelegate onFailCallback = null)
		{
			if (list_0 == null)
			{
				list_0 = new List<RTBRequest>();
			}
			list_0.Add(new RTBRequest(manuallyOrdered, _ActiveUnitStatus_0, groupMembersRTB, groupMembersRTBStatus, detachFromGroup, clearPlottedCourse, airOpsCondition, onSuccessCallback, onFailCallback));
		}

		public void method_1(ActiveUnit._ActiveUnitStatus _ActiveUnitStatus_0, RTBRequest.SingleVoidDelegate onCompletionCallback = null)
		{
			if (list_0 == null)
			{
				list_0 = new List<RTBRequest>();
			}
			list_0.Add(new RTBRequest(_ActiveUnitStatus_0, onCompletionCallback));
		}

		static StatusRelatedEventsInformation()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__103-0
	{
		public Dictionary<string, UnguidedWeapon> $VB$Local_WeaponsDic;

		public List<ReferencePoint> $VB$Local_MissionArea;

		public TList<UnguidedWeapon> $VB$Local_LegitTargets;

		public _Closure$__103-1 $VB$NonLocal_$VB$Closure_2;

		public _Closure$__103-0(_Closure$__103-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_WeaponsDic = arg0.$VB$Local_WeaponsDic;
				$VB$Local_MissionArea = arg0.$VB$Local_MissionArea;
				$VB$Local_LegitTargets = arg0.$VB$Local_LegitTargets;
			}
		}

		[SpecialName]
		internal void _Lambda$__0(string theUW_ObjectID)
		{
			$VB$Local_WeaponsDic.TryGetValue(theUW_ObjectID, out var value);
			if (value != null && value.IsMine)
			{
				if (((Module_Unit.Unit)value).get_IsInsideThisArea($VB$Local_MissionArea, $VB$NonLocal_$VB$Closure_2.$VB$Me.myUnit.ParentScen, UseCache: true))
				{
					$VB$Local_LegitTargets.Add(value);
				}
				else if ($VB$NonLocal_$VB$Closure_2.$VB$Local_myMission.MovementStyle == Mission.MissionMovementStyle.RepeatableLoop && $VB$NonLocal_$VB$Closure_2.$VB$Me.myUnit.Navigator.IsInsideMissionArea(ref $VB$Local_MissionArea, ref $VB$NonLocal_$VB$Closure_2.$VB$Local_myMission.Area_2nm_Buffered, ref $VB$NonLocal_$VB$Closure_2.$VB$Local_myMission.Area_2nm_ChangeCheck, 2, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
				{
					$VB$Local_LegitTargets.Add(value);
				}
			}
		}

		static _Closure$__103-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__103-1
	{
		public MineClearingMission $VB$Local_myMission;

		public Aircraft_AI $VB$Me;

		public _Closure$__103-1(_Closure$__103-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_myMission = arg0.$VB$Local_myMission;
			}
		}

		static _Closure$__103-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__105-0
	{
		public CargoMission $VB$Local_myMission;

		public Aircraft_AI $VB$Me;

		public _Closure$__105-0(_Closure$__105-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_myMission = arg0.$VB$Local_myMission;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			ActiveUnit myUnit = $VB$Me.myUnit;
			Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
			myUnit.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: true, ref Result);
			$VB$Me.myUnit.AddMessage($VB$Me.myUnit.Name + " (" + $VB$Me.myUnit.UnitClass + ") is unable to return to base during cargo mission: " + $VB$Local_myMission.Name + ". The unit will be removed from the mission.", $VB$Me.myUnit.Name + " unable to return to base; removed from mission", LoggedMessage.MessageType.AirOps, 5, new Geopoint_Struct($VB$Me.myUnit.get_Longitude((GlobalVariables.BooleanObject)null), $VB$Me.myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
		}

		[SpecialName]
		internal void _Lambda$__1(float _elapsedTime)
		{
			$VB$Me.myUnit.AddMessage($VB$Me.myUnit.Name + " (" + $VB$Me.myUnit.UnitClass + ") was unable to unload all cargo for mission: " + $VB$Local_myMission.Name + " (Some onboard cargo could not be air dropped.) The unit will return to base.", $VB$Me.myUnit.Name + " unable to unload all cargo; returning to base", LoggedMessage.MessageType.AirOps, 5, new Geopoint_Struct($VB$Me.myUnit.get_Longitude((GlobalVariables.BooleanObject)null), $VB$Me.myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
		}

		static _Closure$__105-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__25-0
	{
		public Strike $VB$Local_myStrike;

		public Aircraft_AI $VB$Me;

		public _Closure$__25-0(_Closure$__25-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_myStrike = arg0.$VB$Local_myStrike;
			}
		}

		[SpecialName]
		internal bool _Lambda$__3(Contact theC)
		{
			if (!theC.get_IsSpecificTargetForThisStrike($VB$Local_myStrike))
			{
				return false;
			}
			ActiveUnit_Weaponry weaponry = $VB$Me.myUnit.Weaponry;
			Doctrine doctrine = $VB$Me.myUnit.Doctrine;
			string Feedback = string.Empty;
			int FeedbackSeverity = 0;
			return weaponry.HaveAvailableWeaponSuitableForThisTarget(theC, CheckWRA: true, doctrine, ref Feedback, ref FeedbackSeverity, HumanFeedBackNeeded: false);
		}

		[SpecialName]
		internal bool _Lambda$__6(Contact theC)
		{
			if (!theC.get_IsSpecificTargetForThisStrike($VB$Local_myStrike))
			{
				return false;
			}
			ActiveUnit_Weaponry weaponry = $VB$Me.myUnit.Weaponry;
			Doctrine doctrine = $VB$Me.myUnit.Doctrine;
			string Feedback = string.Empty;
			int FeedbackSeverity = 0;
			return weaponry.HaveAvailableWeaponSuitableForThisTarget(theC, CheckWRA: true, doctrine, ref Feedback, ref FeedbackSeverity, HumanFeedBackNeeded: false);
		}

		static _Closure$__25-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__25-1
	{
		public HashSet<string> $VB$Local_missionTargetIDs;

		public _Closure$__25-1(_Closure$__25-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_missionTargetIDs = arg0.$VB$Local_missionTargetIDs;
			}
		}

		[SpecialName]
		internal bool _Lambda$__13(Contact theT)
		{
			return $VB$Local_missionTargetIDs.Contains(theT.ActualUnit.ObjectID);
		}

		static _Closure$__25-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__25-2
	{
		public Contact $VB$Local_theT;

		public _Closure$__25-2(_Closure$__25-2 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theT = arg0.$VB$Local_theT;
			}
		}

		[SpecialName]
		internal double _Lambda$__14(ActiveUnit theAU)
		{
			return Module_Unit.RangeToUnit_Horiz_Angular(theAU, $VB$Local_theT);
		}

		static _Closure$__25-2()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__25-3
	{
		public HashSet<string> $VB$Local_themissionTargetIDs;

		public _Closure$__25-3(_Closure$__25-3 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_themissionTargetIDs = arg0.$VB$Local_themissionTargetIDs;
			}
		}

		[SpecialName]
		internal bool _Lambda$__15(Contact theT)
		{
			return $VB$Local_themissionTargetIDs.Contains(theT.ActualUnit.ObjectID);
		}

		static _Closure$__25-3()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__25-4
	{
		public Contact $VB$Local_theT;

		public _Closure$__25-4(_Closure$__25-4 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theT = arg0.$VB$Local_theT;
			}
		}

		[SpecialName]
		internal double _Lambda$__26(ActiveUnit theAU)
		{
			return Module_Unit.RangeToUnit_Horiz_Angular(theAU, $VB$Local_theT);
		}

		static _Closure$__25-4()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__32-0
	{
		public Strike $VB$Local_theStrikeMission;

		public _Closure$__32-0(_Closure$__32-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theStrikeMission = arg0.$VB$Local_theStrikeMission;
			}
		}

		[SpecialName]
		internal bool _Lambda$__2(Contact theC)
		{
			return theC.get_IsSpecificTargetForThisStrike($VB$Local_theStrikeMission);
		}

		static _Closure$__32-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__62-0
	{
		public Contact $VB$Local_theTarget;

		public Aircraft_AI $VB$Me;

		public _Closure$__62-0(_Closure$__62-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theTarget = arg0.$VB$Local_theTarget;
			}
		}

		[SpecialName]
		internal float _Lambda$__2(Weapon theW)
		{
			return theW.get_MaxRangeForThisTarget($VB$Me.myUnit, $VB$Local_theTarget, CheckWRA: true, $VB$Me.myUnit.Doctrine, ManualFire: false);
		}

		static _Closure$__62-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__94-0
	{
		public Doctrine $VB$Local_theDoc;

		public Aircraft_AI $VB$Me;

		public _Closure$__94-0(_Closure$__94-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theDoc = arg0.$VB$Local_theDoc;
			}
		}

		[SpecialName]
		internal float _Lambda$__0(Weapon theWeapon)
		{
			return theWeapon.get_MaxRangeForThisTarget($VB$Me.myUnit, $VB$Me.PrimaryTarget, CheckWRA: true, $VB$Local_theDoc, ManualFire: false);
		}

		static _Closure$__94-0()
		{
			Class72.smethod_20();
		}
	}

	private Aircraft aircraft_0;

	private AircraftAltitudePreset aircraftAltitudePreset_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private (Mount, float, bool) valueTuple_0;

	internal StatusRelatedEventsInformation StatusRelatedEvents;

	private Aircraft_DecisionChecklist aircraft_DecisionChecklist_0;

	[ThreadStatic]
	private List<Contact> list_4;

	[ThreadStatic]
	private List<Contact> list_5;

	[ThreadStatic]
	private List<ActiveUnit> list_6;

	[ThreadStatic]
	private List<ActiveUnit> list_7;

	[ThreadStatic]
	private List<Contact> list_8;

	private Dictionary<int, Weapon> dictionary_0;

	[CompilerGenerated]
	private string string_0;

	private ConcurrentHashSet<string> concurrentHashSet_0;

	[ThreadStatic]
	private List<Contact> list_9;

	[ThreadStatic]
	private Weapon[] weapon_0;

	public AircraftAltitudePreset AltitudePreset
	{
		get
		{
			return aircraftAltitudePreset_0;
		}
		set
		{
			aircraftAltitudePreset_0 = value;
			if (value != AircraftAltitudePreset.None)
			{
				myUnit.Kinematics.DesiredAltitudeOverride = true;
			}
		}
	}

	public string MissionPreviousEvaluation
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	[SpecialName]
	private Aircraft method_12()
	{
		if (aircraft_0 == null)
		{
			aircraft_0 = (Aircraft)myUnit;
		}
		return aircraft_0;
	}

	public static Aircraft_AI FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_0512: Unknown result type (might be due to invalid IL or missing references)
		//IL_0519: Expected O, but got Unknown
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		Aircraft_AI result;
		try
		{
			Aircraft_AI aircraft_AI = new Aircraft_AI(ref theAU);
			aircraft_AI.myUnit = theAU;
			if (theNode.ChildNodes.Count != 0)
			{
				if (Operators.CompareString(theNode.ChildNodes[0].Name, "ActiveUnit_AI", false) == 0)
				{
					theNode = theNode.ChildNodes[0];
				}
				foreach (XmlNode childNode in theNode.ChildNodes)
				{
					XmlNode theNode2 = childNode;
					switch (theNode2.Name)
					{
					case "SpeedAdjustmentToT_OriginalThrottle":
						aircraft_AI.SpeedAdjustmentToT_OriginalThrottle = (ActiveUnit.Throttle)Conversions.ToByte(theNode2.InnerText);
						break;
					case "PTarget":
					case "PrimaryTarget":
						aircraft_AI._PrimaryTarget = Contact.FromXML(theNode2.InnerText, ref theDictionary);
						break;
					case "Threats":
						if (aircraft_AI._Threats == null)
						{
							aircraft_AI._Threats = new List<Contact>();
						}
						foreach (XmlNode childNode2 in theNode2.ChildNodes)
						{
							XmlNode theNode3 = childNode2;
							Contact item = Contact.FromXML(ref theNode3, ref theDictionary);
							aircraft_AI._Threats.Add(item);
						}
						break;
					case "PrimaryThreat":
					case "PThreat":
						aircraft_AI._PrimaryThreat = Contact.FromXML(theNode2.InnerText, ref theDictionary);
						break;
					case "MSF":
						uint.TryParse(theNode2.InnerText, out aircraft_AI._Mission_State_Flags);
						break;
					case "AP":
						aircraft_AI.AltitudePreset = (AircraftAltitudePreset)Conversions.ToByte(theNode2.InnerText);
						break;
					case "DPT_E":
						aircraft_AI.DeterminePrimaryTarget_Enabled = Misc.ParseBool(theNode2.InnerText);
						break;
					case "LeadMustSlowDownDueToBingo":
						aircraft_AI.LeadMustSlowDownDueToBingo = Misc.ParseBool(theNode2.InnerText);
						break;
					case "MissionPreviousEvaluation":
						aircraft_AI.MissionPreviousEvaluation = theNode2.InnerText;
						break;
					case "TTNPTE":
						aircraft_AI.TimeToNextTargetsEvaluation = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
						break;
					case "IE":
						aircraft_AI.IsEscort = true;
						break;
					case "PrimaryTarget_LastKnown_Lon":
						aircraft_AI.PrimaryTarget_LastKnown_Lon = XmlConvert.ToDouble(theNode2.InnerText);
						break;
					case "TimeToNextSpeedAdjustmentForToTEvaluation":
						aircraft_AI.TimeToNextSpeedAdjustmentForToTEvaluation = XmlConvert.ToSingle(theNode2.InnerText);
						break;
					case "PrimaryTarget_LastKnown_Lat":
						aircraft_AI.PrimaryTarget_LastKnown_Lat = XmlConvert.ToDouble(theNode2.InnerText);
						break;
					case "TargetList":
						aircraft_AI._TargetList = new ObservableDictionary<string, TargetingEntry>();
						foreach (XmlNode childNode3 in theNode2.ChildNodes)
						{
							XmlNode theNode4 = childNode3;
							TargetingEntry targetingEntry = TargetingEntry.FromXML(ref theNode4, ref theDictionary);
							if (targetingEntry.Target != null && !aircraft_AI._TargetList.ContainsKey(targetingEntry.Target.ObjectID))
							{
								aircraft_AI.AddTargetList_Threadsafe(targetingEntry.Target.ObjectID, targetingEntry);
							}
						}
						break;
					case "FerryCycleLegIsOutbound":
					case "FCLIO":
						aircraft_AI.SetMissionStateFlag(4u, Misc.ParseBool(theNode2.InnerText));
						break;
					case "PrimaryPickupTarget":
						aircraft_AI._PrimaryPickupTarget = ActiveUnit.FromXML(theNode2.InnerText, ref theDictionary);
						break;
					case "SpeedAdjustmentToT_OriginalSpeed":
						aircraft_AI.SpeedAdjustmentToT_OriginalSpeed = XmlConvert.ToSingle(theNode2.InnerText);
						break;
					case "SpeedAdjustmentToT_OriginalSpeedOverride":
						aircraft_AI.SpeedAdjustmentToT_OriginalSpeedOverride = XmlConvert.ToSingle(theNode2.InnerText);
						break;
					case "SpeedAdjustmentToT_OriginalThrottlePreset":
						aircraft_AI.SpeedAdjustmentToT_OriginalThrottlePreset = (ActiveUnit_Kinematics.UnitThrottlePreset)Conversions.ToByte(theNode2.InnerText);
						break;
					case "RTL":
						aircraft_AI.SetMissionStateFlag(1u, theValue: true);
						break;
					case "PTOE":
					case "PrimaryTargetOverrideExists":
						aircraft_AI.PrimaryTargetOverrideExists = Misc.ParseBool(theNode2.InnerText);
						break;
					case "IsPerformingSpeedAdjustmentToT":
						aircraft_AI.IsPerformingSpeedAdjustmentToT = Misc.ParseBool(theNode2.InnerText);
						break;
					case "MiningInformation":
						aircraft_AI.MiningInfo = MiningMission.MiningInformation.FromXML(ref theNode2, ref theDictionary, aircraft_AI);
						break;
					case "ET_E":
						aircraft_AI.EvaluateTargets_Enabled = Misc.ParseBool(theNode2.InnerText);
						break;
					case "PrimaryTarget_LastKnown_Alt":
						aircraft_AI.PrimaryTarget_LastKnown_Altitude = XmlConvert.ToSingle(theNode2.InnerText);
						break;
					case "IgnorePlottedCourse":
					case "IPC":
					{
						bool num = Misc.ParseBool(theNode2.InnerText);
						if (theAU.Doctrine != null)
						{
							theAU.Doctrine.set_IgnorePlottedCourse(theAU.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._UseIgnorePlottedCourse?)(Doctrine._UseIgnorePlottedCourse)(0u - (Misc.ParseBool(theNode2.InnerText) ? 1u : 0u)));
						}
						if (num && theAU.ActiveMissionOrPackage() != null)
						{
							Mission mission = theAU.ActiveMissionOrPackage();
							if (mission.MissionClass == Mission._MissionClass.Patrol)
							{
								mission.Doctrine.set_IgnorePlottedCourse(theAU.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._UseIgnorePlottedCourse?)Doctrine._UseIgnorePlottedCourse.Yes);
							}
						}
						break;
					}
					}
				}
				result = aircraft_AI;
			}
			else
			{
				result = aircraft_AI;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100375", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Aircraft_AI(ref theAU);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
		try
		{
			if (!Information.IsNothing((object)PrimaryTarget))
			{
				theWriter.WriteElementString("PrimaryTarget", PrimaryTarget.ObjectID);
			}
			if (!Information.IsNothing((object)_PrimaryThreat))
			{
				theWriter.WriteElementString("PrimaryThreat", _PrimaryThreat.ObjectID);
			}
			if (PrimaryTarget_LastKnown_Lat != 0.0)
			{
				theWriter.WriteElementString("PrimaryTarget_LastKnown_Lat", XmlConvert.ToString(PrimaryTarget_LastKnown_Lat));
			}
			if (PrimaryTarget_LastKnown_Lon != 0.0)
			{
				theWriter.WriteElementString("PrimaryTarget_LastKnown_Lon", XmlConvert.ToString(PrimaryTarget_LastKnown_Lon));
			}
			if (PrimaryTarget_LastKnown_Altitude != 0f)
			{
				theWriter.WriteElementString("PrimaryTarget_LastKnown_Alt", XmlConvert.ToString(PrimaryTarget_LastKnown_Altitude));
			}
			if (TimeToNextTargetsEvaluation != 0f)
			{
				theWriter.WriteElementString("TTNPTE", XmlConvert.ToString(TimeToNextTargetsEvaluation));
			}
			if (PrimaryTargetOverrideExists)
			{
				theWriter.WriteElementString("PTOE", PrimaryTargetOverrideExists.ToString());
			}
			if (!EvaluateTargets_Enabled)
			{
				theWriter.WriteElementString("ET_E", "False");
			}
			if (!DeterminePrimaryTarget_Enabled)
			{
				theWriter.WriteElementString("DPT_E", "False");
			}
			if (AltitudePreset != AircraftAltitudePreset.None)
			{
				theWriter.WriteElementString("AP", ((byte)AltitudePreset).ToString());
			}
			if (IsEscort)
			{
				theWriter.WriteElementString("IE", IsEscort.ToString());
			}
			if (!Information.IsNothing((object)_LastKnownTargetLocation))
			{
				theWriter.WriteStartElement("LKTL");
				theWriter.WriteRaw(_LastKnownTargetLocation.ToXML(ObjectsAlreadySerialized));
				theWriter.WriteEndElement();
			}
			if (_TargetList != null && _TargetList.Count > 0)
			{
				theWriter.WriteStartElement("TargetList");
				try
				{
					foreach (TargetingEntry value in _TargetList.Values)
					{
						if (!Information.IsNothing((object)value.Target.ActualUnit))
						{
							theWriter.WriteRaw(value.ToXML(myUnit.get_UnitSide(SetSideOnly: false)));
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
				finally
				{
					theWriter.WriteEndElement();
				}
			}
			if (_Threats != null && _Threats.Count > 0)
			{
				theWriter.WriteStartElement("Threats");
				List<Contact> list = new List<Contact>(_Threats);
				foreach (Contact item in list)
				{
					if (item != null)
					{
						theWriter.WriteRaw(item.ToXML(ObjectsAlreadySerialized, myUnit.get_UnitSide(SetSideOnly: false)));
					}
				}
				theWriter.WriteEndElement();
			}
			if (!Information.IsNothing((object)SnakeAxis))
			{
				theWriter.WriteElementString("SnakeAxis", Conversions.ToString(SnakeAxis.Value));
			}
			if (!Information.IsNothing((object)TimeToNextSpeedAdjustmentForToTEvaluation))
			{
				theWriter.WriteElementString("TimeToNextSpeedAdjustmentForToTEvaluation", XmlConvert.ToString(TimeToNextSpeedAdjustmentForToTEvaluation.Value));
			}
			if (!Information.IsNothing((object)SpeedAdjustmentToT_OriginalSpeed))
			{
				theWriter.WriteElementString("SpeedAdjustmentToT_OriginalSpeed", XmlConvert.ToString(SpeedAdjustmentToT_OriginalSpeed.Value));
			}
			if (!Information.IsNothing((object)SpeedAdjustmentToT_OriginalSpeedOverride))
			{
				theWriter.WriteElementString("SpeedAdjustmentToT_OriginalSpeedOverride", XmlConvert.ToString(SpeedAdjustmentToT_OriginalSpeedOverride.Value));
			}
			if (!Information.IsNothing((object)SpeedAdjustmentToT_OriginalThrottle))
			{
				theWriter.WriteElementString("SpeedAdjustmentToT_OriginalThrottle", Conversions.ToString((byte)SpeedAdjustmentToT_OriginalThrottle.Value));
			}
			if (!Information.IsNothing((object)SpeedAdjustmentToT_OriginalThrottlePreset))
			{
				theWriter.WriteElementString("SpeedAdjustmentToT_OriginalThrottlePreset", Conversions.ToString((byte)SpeedAdjustmentToT_OriginalThrottlePreset.Value));
			}
			if (IsPerformingSpeedAdjustmentToT)
			{
				theWriter.WriteElementString("IsPerformingSpeedAdjustmentToT", IsPerformingSpeedAdjustmentToT.ToString());
			}
			if (LeadMustSlowDownDueToBingo)
			{
				theWriter.WriteElementString("LeadMustSlowDownDueToBingo", LeadMustSlowDownDueToBingo.ToString());
			}
			if (base.PrimaryPickupTarget != null)
			{
				theWriter.WriteElementString("PrimaryPickupTarget", _PrimaryPickupTarget.ObjectID);
			}
			if (MiningInfo != null)
			{
				MiningInfo.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
			}
			if (!Information.IsNothing((object)MissionPreviousEvaluation))
			{
				theWriter.WriteElementString("MissionPreviousEvaluation", MissionPreviousEvaluation);
			}
			if ((long)_Mission_State_Flags > 0L)
			{
				theWriter.WriteElementString("MSF", _Mission_State_Flags.ToString());
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100374", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public Aircraft_AI(ref ActiveUnit theUnit)
		: base(theUnit)
	{
		valueTuple_0 = (null, -1f, false);
		StatusRelatedEvents = new StatusRelatedEventsInformation();
		dictionary_0 = new Dictionary<int, Weapon>();
		concurrentHashSet_0 = new ConcurrentHashSet<string>(useReadLock: false);
	}

	private void method_13(Contact contact_5)
	{
		double value = Module_Unit.GrazingAngleToUnit(contact_5, myUnit);
		value = ((!(((Module_Unit.Unit)contact_5).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > method_12().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))) ? Math.Abs(value) : (0.0 - Math.Abs(value)));
		myUnit.DesiredPitch = (float)value;
	}

	private void method_14(Contact contact_5)
	{
		double num = Module_Unit.GrazingAngleToUnit(myUnit, contact_5);
		myUnit.DesiredPitch = (float)num;
	}

	public override void ManouverAgainstPrimaryThreat(float elapsedTime)
	{
		if (method_12().Crew == 0 && !((ActiveUnit_CommStuff)method_12().CommStuff).IsConnectedToSideNetwork && !((ActiveUnit)method_12()).IsRTB)
		{
			return;
		}
		try
		{
			double num = Math.Round(Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)_PrimaryThreat).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)_PrimaryThreat).get_Longitude((GlobalVariables.BooleanObject)null)), 0);
			if (double.IsNaN(num))
			{
				return;
			}
			if (method_12().Status == ActiveUnit._ActiveUnitStatus.Refuelling)
			{
				method_12().AirOps.DisconnectFromTanker();
			}
			switch (_PrimaryThreat.Type)
			{
			case Contact_Base.ContactType.Air:
				if (!IsTargetingThisContact(_PrimaryThreat))
				{
					float num4 = 2f;
					if (method_12().RangeToUnit_Horiz(_PrimaryThreat) <= num4)
					{
						BeamThreat((int)Math.Round(num));
						myUnit.SetThrottle(ActiveUnit.Throttle.Flank);
					}
					else
					{
						int ThreatBearing = (int)Math.Round(num);
						OutrunThreat(ref ThreatBearing);
					}
				}
				else
				{
					double out_lon = default(double);
					double out_lat = default(double);
					Geodesic_EdWilliams.CalcPoint_Williams(((Module_Unit.Unit)_PrimaryThreat).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)_PrimaryThreat).get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, 0.5, Math2.NormalizeBearing(_PrimaryThreat.CurrentHeading + 180f));
					myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, Module_Unit.BearingToPoint_True(myUnit, out_lat, out_lon));
				}
				break;
			case Contact_Base.ContactType.Missile:
				if (myUnit.ETA_To_Unit(PrimaryThreat) < 15f)
				{
					bool flag = false;
					if (_PrimaryThreat.ActualUnit != null && _PrimaryThreat.ActualUnit.IsMissile)
					{
						Weapon weapon = (Weapon)_PrimaryThreat.ActualUnit;
						if (weapon.SensorProvidingFireControlForMe != null)
						{
							Sensor sensorProvidingFireControlForMe = weapon.SensorProvidingFireControlForMe;
							if ((sensorProvidingFireControlForMe.Codes.Doppler_LDSD_Full || sensorProvidingFireControlForMe.Codes.Doppler_LDSD_Limited) && !sensorProvidingFireControlForMe.Codes.PESA && !sensorProvidingFireControlForMe.Codes.AESA && !sensorProvidingFireControlForMe.Codes.FrequencyAgile)
							{
								ActiveUnit parentPlatform = sensorProvidingFireControlForMe.ParentPlatform;
								IEnumerable<Contact> source = from theC in Module_ActiveUnit_Sensory.ContactsVisibleToMe(method_12().Sensory)
									where Operators.CompareString(theC.ActualUnit.ObjectID, parentPlatform?.ObjectID, false) == 0
									select theC;
								int num2;
								if (source.Count() > 0)
								{
									BeamThreat((int)Math.Round(Module_Unit.BearingToUnit_True(method_12(), source.ElementAtOrDefault(0))));
									method_14(PrimaryThreat);
									num2 = 1;
								}
								else
								{
									num2 = 1;
								}
								flag = (byte)num2 != 0;
							}
						}
						else if (weapon.DataLinkParent != null)
						{
							ActiveUnit dataLinkParent = weapon.DataLinkParent;
							IEnumerable<Contact> source2 = from theC in Module_ActiveUnit_Sensory.ContactsVisibleToMe(method_12().Sensory)
								where Operators.CompareString(theC.ActualUnit.ObjectID, dataLinkParent?.ObjectID, false) == 0
								select theC;
							int num3;
							if (source2.Count() > 0)
							{
								BeamThreat((int)Math.Round(Module_Unit.BearingToUnit_True(method_12(), source2.ElementAtOrDefault(0))));
								method_14(PrimaryThreat);
								num3 = 1;
							}
							else
							{
								num3 = 1;
							}
							flag = (byte)num3 != 0;
						}
					}
					if (!flag)
					{
						BeamThreat((int)Math.Round(num));
						myUnit.SetThrottle(ActiveUnit.Throttle.Flank);
						method_14(PrimaryThreat);
					}
				}
				else
				{
					int ThreatBearing = (int)Math.Round(num);
					OutrunThreat(ref ThreatBearing);
					myUnit.SetThrottle(ActiveUnit.Throttle.Flank);
					method_13(PrimaryThreat);
				}
				break;
			}
			byte? b = (byte?)method_12().Doctrine.get_Jettison(method_12().ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
			{
				method_12().Weaponry.JettisonOrdnance(ExecuteImmediately: false, JettisonDropTanks: true, JettisonUnguidedAG: true, JettisonGuidedAG: true, bool_12: false, JettisonPod: false, JettisonInternalWeapons: false);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100376", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void DeterminePrimaryTarget(float elapsedTime, bool IgnoreTimeToNextEvaluation, bool CheckCombatRadius)
	{
		if (!DeterminePrimaryTarget_Enabled)
		{
			return;
		}
		if (myUnit.IsDrone() && myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DroneAutonomyLevels) && !((ActiveUnit_CommStuff)method_12().CommStuff).IsConnectedToSideNetwork)
		{
			ActiveUnit.DroneAutonomyLevel autonomyLevel = myUnit.AutonomyLevel;
			if (autonomyLevel == ActiveUnit.DroneAutonomyLevel.RemotelyPiloted || autonomyLevel == ActiveUnit.DroneAutonomyLevel.SelfRecovering)
			{
				return;
			}
		}
		try
		{
			if (myUnit == null)
			{
				return;
			}
			Contact closestWeaponTarget = myUnit.ClosestWeaponTarget;
			if (closestWeaponTarget == null)
			{
				if (myUnit.IsRTB_Or_CalledOff)
				{
					PrimaryTarget = null;
					return;
				}
				if ((myUnit.WeaponState == ActiveUnit._ActiveUnitWeaponState.IsWinchester || myUnit.WeaponState == ActiveUnit._ActiveUnitWeaponState.IsShotgun) && !myUnit.Weaponry.IsGuidingWeaponsOntoThisContact(PrimaryTarget))
				{
					Doctrine._WeaponStateRTB? weaponStateRTB = myUnit.Doctrine.WinchesterShotgunRTB;
					byte? b = (byte?)weaponStateRTB;
					if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() != 0)) == true)
					{
						bool flag = true;
						if (method_12().IsGroupMember())
						{
							b = (byte?)weaponStateRTB;
							if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
							{
								ActiveUnit._ActiveUnitWeaponState activeUnitWeaponState = ((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).Weaponry.IsWinchesterOrShotgun();
								if (activeUnitWeaponState != ActiveUnit._ActiveUnitWeaponState.IsWinchester && activeUnitWeaponState != ActiveUnit._ActiveUnitWeaponState.IsShotgun)
								{
									flag = false;
								}
							}
						}
						if (flag)
						{
							PrimaryTarget = null;
							return;
						}
					}
				}
				if (PrimaryTarget != null && TargetIsWasteOfAmmo(PrimaryTarget))
				{
					PrimaryTarget = null;
				}
				if (list_4 != null)
				{
					list_4.Clear();
				}
				else
				{
					list_4 = new List<Contact>();
				}
				Contact[] targets_ReadOnly = base.Targets_ReadOnly;
				if (method_12().Loadout != null && method_12().Loadout.Role == Loadout.LoadoutRole.AntiSatellite_Intercept)
				{
					list_4 = targets_ReadOnly.Where([SpecialName] (Contact contact7) => contact7.Type == Contact_Base.ContactType.Orbital).ToList();
				}
				else
				{
					Contact[] array = targets_ReadOnly;
					foreach (Contact contact in array)
					{
						if (contact.IsAir_GuidedWeapon_Contact || contact.IsShipContact || contact.IsSubmergedContact || contact.IsGroundContact)
						{
							list_4.Add(contact);
						}
					}
				}
				for (int num2 = list_4.Count - 1; num2 >= 0; num2 += -1)
				{
					if ((list_4[num2].get_Stance(myUnit.get_UnitSide(SetSideOnly: false)) == Misc.PostureStance.Friendly || list_4[num2].get_Stance(myUnit.get_UnitSide(SetSideOnly: false)) == Misc.PostureStance.Neutral) && (list_4[num2].IDStatus == Contact_Base.IdentificationStatus.PreciseID || list_4[num2].IDStatus == Contact_Base.IdentificationStatus.KnownClass))
					{
						list_4.RemoveAt(num2);
					}
				}
				if ((list_4.Count == 0) & !myUnit.AI.IsEscort)
				{
					PrimaryTarget = null;
					return;
				}
				if (list_5 != null)
				{
					list_5.Clear();
				}
				else
				{
					list_5 = new List<Contact>();
				}
				ObservableDictionary<string, TargetingEntry> targetList = _TargetList;
				if (method_12().Loadout == null || method_12().Loadout.Role != Loadout.LoadoutRole.AntiSatellite_Intercept)
				{
					foreach (Contact item in list_4)
					{
						Contact theC = item;
						switch (TargetingBehaviorForThisTarget(theC, targetList))
						{
						case TargetingEntry._TargetingBehavior.ManualTargeted:
							if (theC.IsAir_GuidedWeapon_Contact || theC.IsShipContact || theC.IsSubmergedContact || theC.IsGroundContact)
							{
								list_5.Add(theC);
							}
							break;
						case TargetingEntry._TargetingBehavior.ManualWeaponAlloc:
							if ((theC.IsAir_GuidedWeapon_Contact || theC.IsShipContact || theC.IsSubmergedContact || theC.IsGroundContact) && ManualWeaponAllocTargetIsPrimaryTargetCandidate(ref theC))
							{
								list_5.Add(theC);
							}
							break;
						}
					}
				}
				else
				{
					foreach (Contact item2 in list_4)
					{
						Contact theC2 = item2;
						switch (TargetingBehaviorForThisTarget(theC2, targetList))
						{
						case TargetingEntry._TargetingBehavior.ManualTargeted:
							if (theC2.Type == Contact_Base.ContactType.Orbital)
							{
								list_5.Add(theC2);
							}
							break;
						case TargetingEntry._TargetingBehavior.ManualWeaponAlloc:
							if (theC2.Type == Contact_Base.ContactType.Orbital && ManualWeaponAllocTargetIsPrimaryTargetCandidate(ref theC2))
							{
								list_5.Add(theC2);
							}
							break;
						}
					}
				}
				PooledList<Contact> pooledList = new PooledList<Contact>();
				foreach (Contact item3 in list_5)
				{
					if (ContactIsInsideNoNavZone(item3))
					{
						pooledList.Add(item3);
					}
				}
				foreach (Contact item4 in pooledList)
				{
					list_5.Remove(item4);
				}
				pooledList.Dispose();
				if (list_5.Count > 0)
				{
					if (list_5.Count == 1)
					{
						PrimaryTarget = list_5[0];
						return;
					}
					List<Contact> list = (from result in list_5
						select (result) into theUnit
						orderby Module_Unit.RangeToUnit_Horiz_Angular(myUnit, theUnit)
						select theUnit).ToList();
					PrimaryTarget = list[0];
					return;
				}
				if (!myUnit.IsOnActiveMission && !myUnit.Weaponry.IsGuidingWeaponsInAir())
				{
					PrimaryTarget = null;
					return;
				}
				pooledList = new PooledList<Contact>();
				foreach (Contact item5 in list_4)
				{
					if (ContactIsInsideNoNavZone(item5))
					{
						pooledList.Add(item5);
					}
				}
				foreach (Contact item6 in pooledList)
				{
					list_4.Remove(item6);
				}
				pooledList.Dispose();
				if (!myUnit.IsOnActiveStrike)
				{
					if (myUnit.IsOnActivePatrol())
					{
						Patrol patrol = (Patrol)myUnit.ActiveMissionOrPackage();
						GlobalVariables.PatrolType type = ((Patrol)myUnit.ActiveMissionOrPackage()).Type;
						if (type == GlobalVariables.PatrolType.SEAD)
						{
							List<Contact> targetList2 = list_4;
							Mission._FlightSize theFlightSize = 1;
							int maxNumberOfFlightsEngagingContact = patrol.FlightSize_To_ActualAircraftQty(ref theFlightSize, ref patrol.NumberOfFlights_Engage);
							theFlightSize = 1;
							DeterminePrimaryTarget_SEAD_Prioritize(targetList2, maxNumberOfFlightsEngagingContact, patrol.FlightSize_To_ActualAircraftQty(ref theFlightSize, ref patrol.NumberOfFlights_Investigate), patrol.WingmanEngageDistance, elapsedTime);
						}
						else
						{
							ActiveUnit activeUnit = myUnit;
							List<Contact> targetList3 = list_4;
							Mission._FlightSize theFlightSize = 1;
							int maxNumberOfFlightsEngagingContact2 = patrol.FlightSize_To_ActualAircraftQty(ref theFlightSize, ref patrol.NumberOfFlights_Engage);
							theFlightSize = 1;
							ActiveUnit_AI.DeterminePrimaryTarget_PatrolAndEscortLogic(activeUnit, targetList3, maxNumberOfFlightsEngagingContact2, patrol.FlightSize_To_ActualAircraftQty(ref theFlightSize, ref patrol.NumberOfFlights_Investigate), patrol.WingmanEngageDistance, elapsedTime);
						}
					}
					else if (method_12().Loadout != null)
					{
						if (!method_12().Loadout.IsAAW)
						{
							List<Contact> list2 = ((!myUnit.Doctrine.HasPriorityTargetList(myUnit.ParentScen)) ? (from contact7 in list_4
								where !contact7.IsAir_Missile_Orbital_Contact
								orderby contact7.get_ApparentSize(myUnit.ParentScen) descending, contact7.RangeToUnit_Horiz(myUnit)
								select contact7).ToList() : (from contact7 in myUnit.Doctrine.ApplyPriorityTargetList(myUnit.ParentScen, list_4)
								where !contact7.IsAir_Missile_Orbital_Contact
								orderby contact7.get_ApparentSize(myUnit.ParentScen) descending, contact7.RangeToUnit_Horiz(myUnit)
								select contact7).ToList());
							if (list2.Count > 0)
							{
								PrimaryTarget = list2[0];
							}
						}
						else
						{
							Contact contact2 = null;
							if (list_6 != null)
							{
								list_6.Clear();
							}
							else
							{
								list_6 = new List<ActiveUnit>();
							}
							foreach (ActiveUnit item7 in myUnit.get_UnitSide(SetSideOnly: false).Units.ToList())
							{
								if (item7 != null && !item7.IsGroup && item7.IsOperating())
								{
									list_6.Add(item7);
								}
							}
							List<Contact> list3 = list_4;
							if (method_12().Doctrine.HasPriorityTargetList(method_12().ParentScen))
							{
								list3 = method_12().Doctrine.SortTargetsByPriority(method_12().ParentScen, list_4);
							}
							using (List<Contact>.Enumerator enumerator8 = list3.GetEnumerator())
							{
								_Closure$__25-4 closure$__25- = default(_Closure$__25-4);
								while (enumerator8.MoveNext())
								{
									closure$__25- = new _Closure$__25-4(closure$__25-);
									closure$__25-.$VB$Local_theT = enumerator8.Current;
									List<ActiveUnit> list4 = new List<ActiveUnit>();
									foreach (ActiveUnit item8 in list_6)
									{
										if (item8.AI.IsTargetingThisContact(closure$__25-.$VB$Local_theT))
										{
											list4.Add(item8);
										}
									}
									if (list4.Count != 0)
									{
										list4 = list4.OrderBy(closure$__25-._Lambda$__26).ToList();
										if (list4[0] == myUnit)
										{
											contact2 = closure$__25-.$VB$Local_theT;
											break;
										}
										continue;
									}
									contact2 = closure$__25-.$VB$Local_theT;
									break;
								}
							}
							if (contact2 != null)
							{
								PrimaryTarget = contact2;
							}
							else
							{
								list3 = list_4;
								if (method_12().Doctrine.HasPriorityTargetList(method_12().ParentScen))
								{
									list3 = method_12().Doctrine.ApplyPriorityTargetList(method_12().ParentScen, list_4);
								}
								List<Contact> list5 = (myUnit.CommStuff.IsConnectedToSideNetwork ? (from result in list3
									select (result) into theContact
									orderby (from theAC in Module_Contact.IsPrimaryTargetForThesePlatforms(theContact, myUnit.get_UnitSide(SetSideOnly: false), GroupsOnly: false, myUnit)
										where theAC.IsAircraft
										select theAC).Count()
									select theContact).ThenBy([SpecialName] (Contact theUnit) => Module_Unit.RangeToUnit_Horiz_Angular(myUnit, theUnit)).ToList() : (from result in list3
									select (result) into theUnit
									orderby Module_Unit.RangeToUnit_Horiz_Angular(myUnit, theUnit)
									select theUnit).ToList());
								PrimaryTarget = list5[0];
							}
						}
					}
				}
				else if (!myUnit.AI.IsEscort)
				{
					_Closure$__25-0 arg = default(_Closure$__25-0);
					_Closure$__25-0 CS$<>8__locals50 = new _Closure$__25-0(arg);
					CS$<>8__locals50.$VB$Me = this;
					CS$<>8__locals50.$VB$Local_myStrike = (Strike)myUnit.ActiveMissionOrPackage();
					if (CS$<>8__locals50.$VB$Local_myStrike.TargetCount > 0)
					{
						Weapon weapon = null;
						if (PrimaryTarget != null && CS$<>8__locals50.$VB$Local_myStrike.Type != Strike.StrikeType.Air_Intercept)
						{
							weapon = myUnit.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, CheckIfWithinRange: false, CheckIfWithinAltitude: false, CheckWRA: true, myUnit.Doctrine, excludeChaffsAndCounterMeasures: true, CheckWeaponQuantity: true);
							if (weapon != null && myUnit.get_UnitSide(SetSideOnly: false).WRAQuantityRemainingForWeaponVsTarget_ExistingSalvos(myUnit, PrimaryTarget, weapon) < 1)
							{
								PrimaryTarget = null;
							}
						}
						if (PrimaryTarget == null || (!PrimaryTarget.get_IsSpecificTargetForThisStrike(CS$<>8__locals50.$VB$Local_myStrike) && CS$<>8__locals50.$VB$Local_myStrike.get_FocusEntirelyOnStrikeTargets(myUnit)))
						{
							if (CS$<>8__locals50.$VB$Local_myStrike.Type == Strike.StrikeType.Air_Intercept && PrimaryTarget == null && myUnit.Navigator.HasFlight)
							{
								Contact primaryTarget = myUnit.Navigator.get_Flight(HierarchySearch: true).PrimaryTarget;
								if (primaryTarget != null)
								{
									foreach (Contact item9 in list_4)
									{
										if (item9 == primaryTarget || item9.ActualUnit == primaryTarget.ActualUnit)
										{
											PrimaryTarget = item9;
											return;
										}
									}
								}
							}
							List<Contact> list6;
							if (myUnit.Doctrine.HasPriorityTargetList(myUnit.ParentScen))
							{
								new List<Contact>();
								list6 = (from contact7 in myUnit.Doctrine.ApplyPriorityTargetList(myUnit.ParentScen, list_4).Where([SpecialName] (Contact contact7) =>
									{
										if (!contact7.get_IsSpecificTargetForThisStrike(CS$<>8__locals50.$VB$Local_myStrike))
										{
											return false;
										}
										ActiveUnit_Weaponry weaponry2 = CS$<>8__locals50.$VB$Me.myUnit.Weaponry;
										Doctrine doctrine2 = CS$<>8__locals50.$VB$Me.myUnit.Doctrine;
										string Feedback2 = string.Empty;
										int FeedbackSeverity2 = 0;
										return weaponry2.HaveAvailableWeaponSuitableForThisTarget(contact7, CheckWRA: true, doctrine2, ref Feedback2, ref FeedbackSeverity2, HumanFeedBackNeeded: false);
									})
									orderby contact7.get_ApparentSize(myUnit.ParentScen) descending, contact7.RangeToUnit_Horiz(myUnit)
									select contact7).ToList();
							}
							else
							{
								list6 = (from contact7 in list_4.Where([SpecialName] (Contact contact7) =>
									{
										if (!contact7.get_IsSpecificTargetForThisStrike(CS$<>8__locals50.$VB$Local_myStrike))
										{
											return false;
										}
										ActiveUnit_Weaponry weaponry2 = CS$<>8__locals50.$VB$Me.myUnit.Weaponry;
										Doctrine doctrine2 = CS$<>8__locals50.$VB$Me.myUnit.Doctrine;
										string Feedback2 = string.Empty;
										int FeedbackSeverity2 = 0;
										return weaponry2.HaveAvailableWeaponSuitableForThisTarget(contact7, CheckWRA: true, doctrine2, ref Feedback2, ref FeedbackSeverity2, HumanFeedBackNeeded: false);
									})
									orderby contact7.get_ApparentSize(myUnit.ParentScen) descending, contact7.RangeToUnit_Horiz(myUnit)
									select contact7).ToList();
							}
							ActiveUnit a = method_12().AirOps.get_AssignedHostUnit(PickNewAssignedHost: false);
							int num3 = CS$<>8__locals50.$VB$Local_myStrike.MaxResponseRadius_Aircraft;
							if (num3 == 0)
							{
								num3 = int.MaxValue;
							}
							if (list6.Count > 1 && !IsEscort && CS$<>8__locals50.$VB$Local_myStrike.Type != Strike.StrikeType.Air_Intercept && CS$<>8__locals50.$VB$Local_myStrike.get_FocusEntirelyOnStrikeTargets(myUnit) && myUnit.Navigator.HasFlightPlan)
							{
								if (myUnit.Navigator.get_Flight(HierarchySearch: true).PrimaryTarget == null && !string.IsNullOrEmpty(myUnit.Navigator.get_Flight(HierarchySearch: true).PrimaryTarget_ID))
								{
									Contact[] contacts_List_As_Array_Threadsafe = myUnit.get_UnitSide(SetSideOnly: false).Contacts_List_As_Array_Threadsafe;
									foreach (Contact contact3 in contacts_List_As_Array_Threadsafe)
									{
										if (Operators.CompareString(contact3.ObjectID, myUnit.Navigator.get_Flight(HierarchySearch: true).PrimaryTarget_ID, false) == 0)
										{
											myUnit.Navigator.get_Flight(HierarchySearch: true).PrimaryTarget = contact3;
											break;
										}
									}
								}
								if (myUnit.Navigator.get_Flight(HierarchySearch: true).PrimaryTarget != null && list6[0] != myUnit.Navigator.get_Flight(HierarchySearch: true).PrimaryTarget && list6.Contains(myUnit.Navigator.get_Flight(HierarchySearch: true).PrimaryTarget))
								{
									List<Contact> list7 = new List<Contact>();
									list7.Add(myUnit.Navigator.get_Flight(HierarchySearch: true).PrimaryTarget);
									list7.AddRange(list6);
									list6 = list7;
								}
							}
							int num5 = list6.Count - 1;
							for (int num6 = 0; num6 <= num5; num6++)
							{
								if (TargetIsWasteOfAmmo(list6[num6]) || (num3 != int.MaxValue && Math2.CalcDist(a, list6[num6]) > (float)num3) || PrimaryTarget == list6[num6])
								{
									continue;
								}
								if (CS$<>8__locals50.$VB$Local_myStrike.Type != Strike.StrikeType.Air_Intercept)
								{
									weapon = myUnit.Weaponry.MostSuitableWeaponForThisTarget(list6[num6], CheckIfWithinRange: false, CheckIfWithinAltitude: false, CheckWRA: true, myUnit.Doctrine, excludeChaffsAndCounterMeasures: true, CheckWeaponQuantity: true);
									if (weapon != null && myUnit.get_UnitSide(SetSideOnly: false).WRAQuantityRemainingForWeaponVsTarget_ExistingSalvos(myUnit, list6[num6], weapon) > 0)
									{
										PrimaryTarget = list6[num6];
										if (myUnit.get_UnitSide(SetSideOnly: false) != null && myUnit.get_UnitSide(SetSideOnly: false).IsHumanControlled)
										{
											Notification_Bark.Create_UnitBehaviour(myUnit, "Switching to target: " + list6[num6].Name);
										}
										break;
									}
									continue;
								}
								PrimaryTarget = list6[num6];
								if (myUnit.get_UnitSide(SetSideOnly: false) != null && myUnit.get_UnitSide(SetSideOnly: false).IsHumanControlled)
								{
									Notification_Bark.Create_UnitBehaviour(myUnit, "Switching to target: " + list6[num6].Name);
								}
								break;
							}
							if (PrimaryTarget == null)
							{
								if (myUnit.Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint || myUnit.Status == ActiveUnit._ActiveUnitStatus.Refuelling)
								{
									return;
								}
								if (method_12().Navigator.FollowingRTB_FlightPlan())
								{
									if (!GlobalVariables.AI_REWORK)
									{
										method_12().Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
									}
									if (((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false) != null && !method_12().IsGroupLead())
									{
										if (method_12().IsGroupWingman())
										{
											method_12().Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
										}
									}
									else
									{
										method_12().Navigator.FollowPlottedCourse(elapsedTime);
									}
									return;
								}
								if (myUnit.ActiveMissionOrPackage() == null)
								{
									if (!GlobalVariables.AI_REWORK)
									{
										method_12().Status = ActiveUnit._ActiveUnitStatus.RTB_MissionOver;
										ReturnToBase(elapsedTime);
									}
									else
									{
										method_12().AI.StatusRelatedEvents.method_1(ActiveUnit._ActiveUnitStatus.RTB_MissionOver, [SpecialName] (float _elapsedTime) =>
										{
											method_12().AI.ReturnToBase(_elapsedTime);
										});
									}
								}
								else if (myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
								{
									myUnit.Navigator.EgressToRejoinPoint(elapsedTime, ForceObjectiveWaypointRemoval: false);
								}
							}
						}
					}
					else if (CS$<>8__locals50.$VB$Local_myStrike.RTB_When_Target_Destroyed && CS$<>8__locals50.$VB$Local_myStrike.TargetCount == 0 && PrimaryTarget != null && !ContactIsRelevantToFlight(PrimaryTarget))
					{
						PrimaryTarget = null;
						return;
					}
					if (CS$<>8__locals50.$VB$Local_myStrike.Type != Strike.StrikeType.Air_Intercept)
					{
						if (PrimaryTarget != null)
						{
							Contact primaryTarget2 = PrimaryTarget;
							Mission theMission = method_12().ActiveMissionOrPackage();
							Doctrine._UseShootTourists? canShootTourists = myUnit.Doctrine.get_ShootTourists(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
							string Feedback = "";
							int FeedbackSeverity = 0;
							if (ContactIsRelevantToFlightOrMission(primaryTarget2, theMission, canShootTourists, IgnoreContacStance: false, MyUnitIsInsidePatrolArea: false, IgnoreNeutralContacts: true, null, ref Feedback, ref FeedbackSeverity))
							{
								goto IL_1faa;
							}
						}
						if (method_12().Navigator.HasFlightPlan && !method_12().Navigator.IsOnAutoPlannerPlottedCourse_CruiseAndAttackIngressRun)
						{
							PrimaryTarget = null;
						}
						else
						{
							List<Contact> list8 = (from theUnit in list_4.Where([SpecialName] (Contact contact7) =>
								{
									int result;
									if (!contact7.IsAir_Missile_Orbital_Contact)
									{
										Mission theMission3 = method_12().ActiveMissionOrPackage();
										Doctrine._UseShootTourists? canShootTourists2 = myUnit.Doctrine.get_ShootTourists(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
										string Feedback2 = string.Empty;
										int FeedbackSeverity2 = 0;
										if (ContactIsRelevantToFlightOrMission(contact7, theMission3, canShootTourists2, IgnoreContacStance: false, MyUnitIsInsidePatrolArea: false, IgnoreNeutralContacts: true, null, ref Feedback2, ref FeedbackSeverity2))
										{
											ActiveUnit_Weaponry weaponry2 = myUnit.Weaponry;
											Doctrine doctrine2 = myUnit.Doctrine;
											Feedback2 = string.Empty;
											FeedbackSeverity2 = 0;
											return weaponry2.HaveAvailableWeaponSuitableForThisTarget(contact7, CheckWRA: true, doctrine2, ref Feedback2, ref FeedbackSeverity2, HumanFeedBackNeeded: false);
										}
										result = 0;
									}
									else
									{
										result = 0;
									}
									return (byte)result != 0;
								})
								orderby Module_Unit.RangeToUnit_Horiz_Angular(myUnit, theUnit)
								select theUnit).ToList();
							if (list8.Count > 0)
							{
								if ((CS$<>8__locals50.$VB$Local_myStrike.Type == Strike.StrikeType.Land_Strike || CS$<>8__locals50.$VB$Local_myStrike.Type == Strike.StrikeType.Maritime_Strike) && CheckCombatRadius && method_12().Navigator.HasFlight)
								{
									if (!method_12().Navigator.HasFlightPlan)
									{
										if (method_12().Doctrine.HasPriorityTargetList(method_12().ParentScen))
										{
											list8 = (from theUnit in method_12().Doctrine.ApplyPriorityTargetList(method_12().ParentScen, list8)
												orderby Module_Unit.RangeToUnit_Horiz_Angular(myUnit, theUnit)
												select theUnit).ToList();
										}
										PrimaryTarget = list8[0];
									}
									else
									{
										if (method_12().Doctrine.HasPriorityTargetList(method_12().ParentScen))
										{
											list8 = method_12().Doctrine.SortTargetsByPriority(method_12().ParentScen, list8);
										}
										Aircraft aircraft = ((!method_12().IsGroupMember()) ? method_12() : ((Aircraft)((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).GroupLead));
										Mission theMission2 = myUnit.ActiveMissionOrPackage();
										Aircraft_AI aI = aircraft.AI;
										ref Scenario parentScen = ref myUnit.ParentScen;
										ActiveUnit activeUnit2;
										Side theSide = (activeUnit2 = myUnit).get_UnitSide(SetSideOnly: false);
										Aircraft_Navigator navigator;
										Mission.Flight theMasterFlightPlanEntry = ((ActiveUnit_Navigator)(navigator = aircraft.Navigator)).get_Flight(HierarchySearch: true);
										List<Contact> list9;
										Contact theTarget = (list9 = list8)[0];
										int minResponseRadius_Aircraft = CS$<>8__locals50.$VB$Local_myStrike.MinResponseRadius_Aircraft;
										int maxResponseRadius_Aircraft = CS$<>8__locals50.$VB$Local_myStrike.MaxResponseRadius_Aircraft;
										Doctrine._UseUnderwayRefuelAndReplenishment? tankerUsage = CS$<>8__locals50.$VB$Local_myStrike.Doctrine.get_UseReplenishment(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
										bool launchMissionWithoutTankersInPlace = myUnit.ActiveMissionOrPackage().LaunchMissionWithoutTankersInPlace;
										Mission._RadarBehaviour radarBehaviour = CS$<>8__locals50.$VB$Local_myStrike.RadarBehaviour;
										bool usePlanner = CS$<>8__locals50.$VB$Local_myStrike.UsePlanner;
										float FuelQtyRequired = 0f;
										bool IsBananaSplitRedSection = true;
										float Offset_Ingress = 0f;
										float Offset_Egress = 0f;
										string FlightPlanFeedback = default(string);
										bool num7 = aI.CanReachTarget_Strike(ref parentScen, ref theSide, ref theMission2, ref theMasterFlightPlanEntry, ref theTarget, minResponseRadius_Aircraft, maxResponseRadius_Aircraft, tankerUsage, launchMissionWithoutTankersInPlace, radarBehaviour, AttemptPathfinderFlightPlan: true, SeparateIngressEgressPathfinderFlightPlans: true, AircraftIsAirborne: true, usePlanner, ref FuelQtyRequired, ref FlightPlanFeedback, CallNavigatorImmediately: false, ref IsBananaSplitRedSection, UsePreDefinedOffsets: false, ref Offset_Ingress, ref Offset_Egress, CreateFlightPlan: false, list8[0], IsCreatedManually: true, theMission2.TakeOffTime, theMission2.TimeOnTarget, IsContinousCoverage: false, IsMFP: true);
										list9[0] = theTarget;
										((ActiveUnit_Navigator)navigator).set_Flight(HierarchySearch: true, theMasterFlightPlanEntry);
										activeUnit2.set_UnitSide(SetSideOnly: false, theSide);
										if (num7 && CS$<>8__locals50.$VB$Local_myStrike.get_FocusEntirelyOnStrikeTargets(myUnit) && list8[0].get_IsSpecificTargetForThisStrike(CS$<>8__locals50.$VB$Local_myStrike))
										{
											PrimaryTarget = list8[0];
										}
										else
										{
											if (!string.IsNullOrEmpty(FlightPlanFeedback))
											{
												string text = "";
												if (method_12().IsAircraft && Operators.CompareString(method_12().Name, method_12().UnitClass, false) != 0)
												{
													text = " (" + method_12().UnitClass + ")";
												}
												method_12().ParentScen.AddMessage("Aircraft " + method_12().Name + text + " with loadout " + method_12().LoadoutName + " is not allowed to engage a new target. Reason: " + FlightPlanFeedback, method_12().Name + " not allowed to engage", LoggedMessage.MessageType.AirOps, 0, null, ((ActiveUnit)method_12()).get_UnitSide(SetSideOnly: false), new Geopoint_Struct(method_12().get_Longitude((GlobalVariables.BooleanObject)null), method_12().get_Latitude((GlobalVariables.BooleanObject)null)));
											}
											PrimaryTarget = null;
										}
									}
								}
								else
								{
									if (method_12().Doctrine.HasPriorityTargetList(method_12().ParentScen))
									{
										list8 = (from theUnit in method_12().Doctrine.ApplyPriorityTargetList(method_12().ParentScen, list8)
											orderby Module_Unit.RangeToUnit_Horiz_Angular(myUnit, theUnit)
											select theUnit).ToList();
									}
									foreach (Contact item10 in list8)
									{
										ActiveUnit activeUnit3 = method_12().AirOps.get_AssignedHostUnit(PickNewAssignedHost: false);
										if (activeUnit3 == null)
										{
											if (CS$<>8__locals50.$VB$Local_myStrike.MaxResponseRadius_Aircraft != 0)
											{
												continue;
											}
											PrimaryTarget = item10;
											break;
										}
										if (CS$<>8__locals50.$VB$Local_myStrike.MaxResponseRadius_Aircraft != 0)
										{
											if (!(Math2.CalcDist(item10, activeUnit3) <= (float)CS$<>8__locals50.$VB$Local_myStrike.MaxResponseRadius_Aircraft))
											{
												continue;
											}
											PrimaryTarget = item10;
											break;
										}
										PrimaryTarget = item10;
										break;
									}
									if (PrimaryTarget == null)
									{
										ReturnToBase(elapsedTime);
										return;
									}
								}
							}
						}
					}
					else
					{
						_Closure$__25-1 arg2 = default(_Closure$__25-1);
						_Closure$__25-1 CS$<>8__locals51 = new _Closure$__25-1(arg2);
						Contact contact4 = null;
						Contact contact5 = null;
						if (list_6 != null)
						{
							list_6.Clear();
						}
						else
						{
							list_6 = new List<ActiveUnit>();
						}
						list_6 = Module_Mission.UnitsAssignedToMissionOrPackage(CS$<>8__locals50.$VB$Local_myStrike, myUnit.ParentScen).Where([SpecialName] (ActiveUnit u) =>
						{
							int result;
							if (u == null)
							{
								result = 0;
							}
							else
							{
								if (!u.IsGroup)
								{
									return u.IsOperating();
								}
								result = 0;
							}
							return (byte)result != 0;
						}).ToList();
						List<Contact> source = list_4;
						Contact contact6 = null;
						if (myUnit.Doctrine.HasPriorityTargetList(myUnit.ParentScen))
						{
							source = myUnit.Doctrine.ApplyPriorityTargetList(myUnit.ParentScen, list_4);
							contact6 = list_4.OrderBy([SpecialName] (Contact theUnit) => Module_Unit.RangeToUnit_Horiz_Angular(myUnit, theUnit)).First();
						}
						List<Contact> list10 = source.OrderBy([SpecialName] (Contact theUnit) => Module_Unit.RangeToUnit_Horiz_Angular(myUnit, theUnit)).ToList();
						ActiveUnit activeUnit4 = null;
						if (method_12().IsGroupWingman())
						{
							float num8;
							if (IsEscort)
							{
								activeUnit4 = myUnit.getEscortedUnitsLead();
								num8 = ((Strike)myUnit.ActiveMissionOrPackage()).Escort_WingmanEngageDistance;
							}
							else
							{
								activeUnit4 = myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead;
								num8 = Mission.SplitDistanceToNumber(((Strike)myUnit.ActiveMissionOrPackage()).SplitDistance);
							}
							if (PrimaryTarget == null)
							{
								PrimaryTarget = activeUnit4.AI.PrimaryTarget;
							}
							else if (PrimaryTarget != activeUnit4.AI.PrimaryTarget && activeUnit4.RangeToUnit_Horiz(PrimaryTarget) > num8)
							{
								PrimaryTarget = activeUnit4.AI.PrimaryTarget;
							}
						}
						CS$<>8__locals51.$VB$Local_missionTargetIDs = new HashSet<string>();
						foreach (Module_Unit.Unit specificTarget in CS$<>8__locals50.$VB$Local_myStrike.SpecificTargets)
						{
							if (!specificTarget.IsContact())
							{
								if (specificTarget.IsActiveUnit)
								{
									CS$<>8__locals51.$VB$Local_missionTargetIDs.Add(specificTarget.ObjectID);
								}
							}
							else
							{
								CS$<>8__locals51.$VB$Local_missionTargetIDs.Add(((Contact)specificTarget).ActualUnit.ObjectID);
							}
						}
						if ((CS$<>8__locals51.$VB$Local_missionTargetIDs != null) & (CS$<>8__locals51.$VB$Local_missionTargetIDs.Count > 0))
						{
							list10 = list10.Where([SpecialName] (Contact theT) => CS$<>8__locals51.$VB$Local_missionTargetIDs.Contains(theT.ActualUnit.ObjectID)).ToList();
						}
						using (List<Contact>.Enumerator enumerator13 = list10.GetEnumerator())
						{
							_Closure$__25-2 closure$__25-2 = default(_Closure$__25-2);
							while (enumerator13.MoveNext())
							{
								closure$__25-2 = new _Closure$__25-2(closure$__25-2);
								closure$__25-2.$VB$Local_theT = enumerator13.Current;
								if ((CS$<>8__locals50.$VB$Local_myStrike.MinResponseRadius_Aircraft > 0 && myUnit.RangeToUnit_Horiz(closure$__25-2.$VB$Local_theT) < (float)CS$<>8__locals50.$VB$Local_myStrike.MinResponseRadius_Aircraft) || (CS$<>8__locals50.$VB$Local_myStrike.MaxResponseRadius_Aircraft > 0 && myUnit.RangeToUnit_Horiz(closure$__25-2.$VB$Local_theT) > (float)CS$<>8__locals50.$VB$Local_myStrike.MaxResponseRadius_Aircraft))
								{
									continue;
								}
								if (contact5 == null)
								{
									ActiveUnit_Weaponry weaponry = myUnit.Weaponry;
									Contact theTarget2 = closure$__25-2.$VB$Local_theT;
									Doctrine doctrine = myUnit.Doctrine;
									string Feedback = string.Empty;
									int FeedbackSeverity = 0;
									if (weaponry.HaveAvailableWeaponSuitableForThisTarget(theTarget2, CheckWRA: true, doctrine, ref Feedback, ref FeedbackSeverity, HumanFeedBackNeeded: false))
									{
										contact5 = closure$__25-2.$VB$Local_theT;
									}
								}
								if (list_7 != null)
								{
									list_7.Clear();
								}
								else
								{
									list_7 = new List<ActiveUnit>();
								}
								foreach (ActiveUnit item11 in list_6)
								{
									if (item11.AI.PrimaryTarget == closure$__25-2.$VB$Local_theT)
									{
										list_7.Add(item11);
									}
								}
								if (list_7.Count != 0)
								{
									list_7 = list_7.OrderBy(closure$__25-2._Lambda$__14).ToList();
									if (list_7[0] != myUnit)
									{
										if (myUnit.IsGroupWingman() && list_7[0] == myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead && PrimaryTarget == closure$__25-2.$VB$Local_theT)
										{
											contact4 = closure$__25-2.$VB$Local_theT;
											break;
										}
										continue;
									}
									contact4 = closure$__25-2.$VB$Local_theT;
									break;
								}
								contact4 = closure$__25-2.$VB$Local_theT;
								break;
							}
						}
						if (contact4 == null)
						{
							if ((CS$<>8__locals50.$VB$Local_myStrike.MinResponseRadius_Aircraft > 0 || CS$<>8__locals50.$VB$Local_myStrike.MaxResponseRadius_Aircraft > 0) && contact5 == null && contact6 == null)
							{
								PrimaryTarget = null;
							}
							else
							{
								source = list_4;
								if (myUnit.Doctrine.HasPriorityTargetList(myUnit.ParentScen))
								{
									source = myUnit.Doctrine.ApplyPriorityTargetList(myUnit.ParentScen, list_4);
								}
								List<Contact> source2 = source;
								if (myUnit.AssignedMissionOrPackage() != null && myUnit.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
								{
									Strike strike = (Strike)myUnit.AssignedMissionOrPackage();
									if (strike.Type == Strike.StrikeType.Air_Intercept)
									{
										_Closure$__25-3 arg3 = default(_Closure$__25-3);
										_Closure$__25-3 CS$<>8__locals52 = new _Closure$__25-3(arg3);
										CS$<>8__locals52.$VB$Local_themissionTargetIDs = new HashSet<string>();
										foreach (Module_Unit.Unit specificTarget2 in strike.SpecificTargets)
										{
											Contact contactForThisUnit = GetContactForThisUnit(specificTarget2);
											if (contactForThisUnit != null)
											{
												CS$<>8__locals52.$VB$Local_themissionTargetIDs.Add(contactForThisUnit.ActualUnit.ObjectID);
											}
										}
										if (CS$<>8__locals52.$VB$Local_themissionTargetIDs.Count > 0)
										{
											source2 = source.Where([SpecialName] (Contact theT) => CS$<>8__locals52.$VB$Local_themissionTargetIDs.Contains(theT.ActualUnit.ObjectID)).ToList();
										}
									}
								}
								List<Contact> list11 = ((!myUnit.CommStuff.IsConnectedToSideNetwork) ? (from result in source2
									select (result) into theUnit
									orderby Module_Unit.RangeToUnit_Horiz_Angular(myUnit, theUnit)
									select theUnit).ToList() : (from result in source2
									select (result) into theContact
									orderby (from theAC in Module_Contact.IsPrimaryTargetForThesePlatforms(theContact, myUnit.get_UnitSide(SetSideOnly: false), GroupsOnly: false, myUnit)
										where theAC.IsAircraft
										select theAC).Count()
									select theContact).ThenBy([SpecialName] (Contact theUnit) => Module_Unit.RangeToUnit_Horiz_Angular(myUnit, theUnit)).ToList());
								if ((list11 != null && list11.Count != 0) || activeUnit4 == null)
								{
									if (list11 != null && list11.Count > 0)
									{
										PrimaryTarget = list11[0];
									}
								}
								else
								{
									PrimaryTarget = activeUnit4.AI.PrimaryTarget;
								}
							}
						}
						else
						{
							PrimaryTarget = contact4;
						}
					}
				}
				else
				{
					Strike strike2 = (Strike)myUnit.ActiveMissionOrPackage();
					ActiveUnit activeUnit5 = myUnit;
					List<Contact> targetList4 = list_4;
					Mission._FlightSize theFlightSize = 1;
					int maxNumberOfFlightsEngagingContact3 = strike2.FlightSize_To_ActualAircraftQty(ref theFlightSize, ref strike2.Escort_NumberOfFlights_Engage);
					theFlightSize = 1;
					ActiveUnit_AI.DeterminePrimaryTarget_PatrolAndEscortLogic(activeUnit5, targetList4, maxNumberOfFlightsEngagingContact3, strike2.FlightSize_To_ActualAircraftQty(ref theFlightSize, ref strike2.Escort_NumberOfFlights_Investigate), strike2.Escort_WingmanEngageDistance, elapsedTime);
				}
				goto IL_1faa;
			}
			PrimaryTarget = closestWeaponTarget;
			return;
			IL_1faa:
			if (myUnit == null)
			{
				return;
			}
			if (list_8 == null)
			{
				list_8 = new List<Contact>();
			}
			else
			{
				list_8.Clear();
			}
			foreach (Contact item12 in list_4)
			{
				if (myUnit == null)
				{
					break;
				}
				if (_Threats != null && _Threats.Contains(item12) && Module_Unit.RangeToUnit_Slant(myUnit, item12) < 5f)
				{
					list_8.Add(item12);
				}
				if (list_8.Count == 1)
				{
					PrimaryTarget = list_8[0];
				}
				double num9 = 20000.0;
				foreach (Contact item13 in list_8)
				{
					double num10 = Module_Unit.RangeToUnit_Slant(myUnit, item13);
					if (num10 < num9)
					{
						PrimaryTarget = item13;
						num9 = num10;
					}
				}
			}
			list_8 = null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100377", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private void method_15(double double_0, Doctrine._UnderwayRefuelAndReplenishmentSelection _UnderwayRefuelAndReplenishmentSelection_0)
	{
		if (method_12().IsGroupWingman() || (!method_12().BoomRefuelling && !method_12().ProbeRefuelling))
		{
			return;
		}
		byte? b = (byte?)method_12().Doctrine.get_UseReplenishment(method_12().ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
		if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true || (method_12().IsTanker && (method_12().AirOps.RefuellingQueue.Count > 0 || method_12().AirOps.A2AR_Connections.Count > 0)) || AlreadyRTBAndNearlyBackToBase())
		{
			return;
		}
		try
		{
			float num = float.MaxValue;
			ActiveUnit activeUnit = myUnit;
			if (myUnit.IsGroupMember())
			{
				List<ActiveUnit> list = new List<ActiveUnit>(myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values);
				foreach (ActiveUnit item in list)
				{
					if (item != null && (float)item.FuelCapacityCurrent < num)
					{
						num = item.FuelCapacityCurrent;
						activeUnit = item;
					}
				}
			}
			ActiveUnit activeUnit2 = activeUnit;
			double TotalCurrent = 0.0;
			double TotalMax = 0.0;
			if (activeUnit2.FuelPercent(ref TotalCurrent, ref TotalMax, MissionFuel: true) < double_0)
			{
				GeoPoint intermediateTargetPoint = IntermediateTargetPointForRefuelCalcs();
				bool MissionPlanner_PostponedRefuelling = false;
				Aircraft_AirOps airOps = method_12().AirOps;
				bool IsManual = false;
				ActiveUnit theSelectedTanker = null;
				List<Mission> theSelectedMissions = null;
				string UserFeedback = "";
				bool IsRTB = false;
				airOps.AttemptToScheduleRefuel(intermediateTargetPoint, _UnderwayRefuelAndReplenishmentSelection_0, ref IsManual, IsForced: false, ref theSelectedTanker, ref theSelectedMissions, ref UserFeedback, ref IsRTB, ref MissionPlanner_PostponedRefuelling, Aircraft_AirOps.RefuelScheduleReason.TopUpRefuelIngress);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100378", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_16(Doctrine._UnderwayRefuelAndReplenishmentSelection _UnderwayRefuelAndReplenishmentSelection_0)
	{
		byte? b = (byte?)method_12().Doctrine.get_UseReplenishment(method_12().ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
		if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true || (!method_12().BoomRefuelling && !method_12().ProbeRefuelling) || (method_12().IsTanker && (method_12().AirOps.RefuellingQueue.Count > 0 || method_12().AirOps.A2AR_Connections.Count > 0)))
		{
			return;
		}
		try
		{
			Aircraft_AirOps airOps = method_12().AirOps;
			ActiveUnit actualDestinationHost = airOps.ActualDestinationHost;
			if (!Information.IsNothing((object)actualDestinationHost))
			{
				int num;
				switch (method_12().get_IsBingoTowardsThisDestination(actualDestinationHost, (GeoPoint)null, method_12().Doctrine.BingoJoker))
				{
				case ActiveUnit._ActiveUnitFuelState.IsJoker:
					num = 0;
					break;
				case ActiveUnit._ActiveUnitFuelState.IsBingo:
					num = 0;
					break;
				default:
					return;
				}
				bool MissionPlanner_PostponedRefuelling = (byte)num != 0;
				bool IsManual = false;
				ActiveUnit theSelectedTanker = null;
				List<Mission> theSelectedMissions = null;
				string UserFeedback = "";
				bool IsRTB = true;
				airOps.AttemptToScheduleRefuel(null, _UnderwayRefuelAndReplenishmentSelection_0, ref IsManual, IsForced: false, ref theSelectedTanker, ref theSelectedMissions, ref UserFeedback, ref IsRTB, ref MissionPlanner_PostponedRefuelling, Aircraft_AirOps.RefuelScheduleReason.TopUpRefuelEgress);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100379", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private Weapon method_17(int int_4)
	{
		if (dictionary_0.TryGetValue(int_4, out var value))
		{
			return value;
		}
		value = Weapon.GetNewWeapon(ref method_12().ParentScen, int_4, bool_5: false);
		try
		{
			dictionary_0.Add(int_4, value);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		return value;
	}

	public override void EvaluateUnitStatus(float elapsedTime, bool ForceFuelStateCheck, bool ForceWeaponStateCheck)
	{
		if (GlobalVariables.AI_REWORK)
		{
			StatusRelatedEventsInformation statusRelatedEvents = method_12().AI.StatusRelatedEvents;
			method_12().AI.StatusRelatedEvents = new StatusRelatedEventsInformation();
			if (statusRelatedEvents.ForceStatusbeforeEvaluation.HasValue)
			{
				method_12().Status = statusRelatedEvents.ForceStatusbeforeEvaluation.Value;
			}
			string text = "";
			if (method_12().AssignedMissionOrPackage() != null)
			{
				text = method_12().AssignedMissionOrPackage().ObjectID;
			}
			if (Operators.CompareString(MissionPreviousEvaluation, text, false) != 0)
			{
				if (method_12().AssignedMissionOrPackage() == null)
				{
					method_12().Status = ActiveUnit._ActiveUnitStatus.Unassigned;
					MissionPreviousEvaluation = "";
				}
				else
				{
					method_12().Status = ActiveUnit._ActiveUnitStatus.Tasked;
					MissionPreviousEvaluation = method_12().AssignedMissionOrPackage().ObjectID;
				}
			}
			if (statusRelatedEvents.GeneratedAttackRoute)
			{
				myUnit.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
			}
			if (statusRelatedEvents.triedFollowingPlottedCourseButHadNone && !method_12().IsGroupWingman())
			{
				Waypoint[] array = method_12().Navigator.PlottedCourse;
				if ((array.Length == 0) & method_12().Navigator.HasFlightPlan)
				{
					array = ((ActiveUnit_Navigator)method_12().Navigator).get_Flight(HierarchySearch: true).FlightPlan;
				}
				if (!myUnit.AI.HoldPosition && array.Length == 0 && !myUnit.IsRTB)
				{
					if (myUnit.ActiveMissionOrPackage() == null)
					{
						myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
					}
					else if (myUnit.AI.PrimaryTarget == null)
					{
						myUnit.Status = ActiveUnit._ActiveUnitStatus.Tasked;
					}
					else
					{
						myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
					}
					return;
				}
			}
			if (statusRelatedEvents.list_0 != null)
			{
				RTBRequest? rTBRequest = null;
				if (statusRelatedEvents.list_0.Count > 1 && Debugger.IsAttached)
				{
					Debugger.Break();
				}
				foreach (RTBRequest item in statusRelatedEvents.list_0)
				{
					if (rTBRequest.HasValue)
					{
						if (item.takesPrecedenceOver(rTBRequest.Value))
						{
							rTBRequest = item;
						}
					}
					else
					{
						rTBRequest = item;
					}
				}
				if (rTBRequest.HasValue)
				{
					RTBRequest value = rTBRequest.Value;
					if (value.DirectAssignment)
					{
						myUnit.Status = value._ActiveUnitStatus_0;
						if (value.onCompletionCallback != null)
						{
							value.onCompletionCallback(elapsedTime);
						}
						return;
					}
					if (!method_12().AirOps.AttemptToRTB(value.ManuallyOrdered, value._ActiveUnitStatus_0, value.GroupMembersRTB, value.GroupMembersRTBStatus, value.DetachFromGroup, value.ClearPlottedCourse))
					{
						if (value.onFailCallback != null)
						{
							value.onFailCallback();
						}
					}
					else if (value.onSuccessCallback != null)
					{
						value.onSuccessCallback();
					}
					if (value.AirOpsCondition.HasValue)
					{
						method_12().AirOps.Condition = value.AirOpsCondition.Value;
					}
					return;
				}
			}
			if (statusRelatedEvents.RestorePreRefuelStatus.HasValue)
			{
				method_12().Status = statusRelatedEvents.RestorePreRefuelStatus.Value;
				return;
			}
			if (method_12().Status == ActiveUnit._ActiveUnitStatus.OnPatrol && Information.IsNothing((object)myUnit.ActiveMissionOrPackage()))
			{
				myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
				return;
			}
			if (method_12().IsOnActivePatrol())
			{
				CheckIfReachedPatrolAreaThiSortie();
				if (method_12().Status == ActiveUnit._ActiveUnitStatus.OnPlottedCourse)
				{
					Patrol patrol = (Patrol)method_12().ActiveMissionOrPackage();
					if (PrimaryTarget != null && ((Module_Unit.Unit)method_12()).get_IsInsideThisArea(patrol.PatrolArea, method_12().ParentScen, UseCache: false))
					{
						Contact primaryTarget = PrimaryTarget;
						Mission theMission = method_12().ActiveMissionOrPackage();
						Doctrine._UseShootTourists? canShootTourists = method_12().Doctrine.get_ShootTourists(method_12().ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
						string Feedback = "";
						int FeedbackSeverity = 0;
						if (ContactIsRelevantToFlightOrMission(primaryTarget, theMission, canShootTourists, IgnoreContacStance: false, MyUnitIsInsidePatrolArea: false, IgnoreNeutralContacts: true, null, ref Feedback, ref FeedbackSeverity))
						{
							method_12().Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
							return;
						}
					}
				}
			}
			if (method_12().AirOps.Condition == Aircraft_AirOps._AirOpsCondition.OffloadingFuel && method_12().AirOps.A2AR_Connections.Skip(0).Count() == 0 && !myUnit.IsRTB)
			{
				method_12().AirOps.Condition = Aircraft_AirOps._AirOpsCondition.Airborne;
			}
			if (method_12().AirborneTime == 0f)
			{
				method_12().Status = ActiveUnit._ActiveUnitStatus.Unassigned;
			}
			if (method_12().AirOps.Condition == Aircraft_AirOps._AirOpsCondition.Refuelling)
			{
				if (method_12().AirOps.A2AR_Destination != null && !method_12().AirOps.A2AR_Destination.IsMorituri)
				{
					method_12().Status = ActiveUnit._ActiveUnitStatus.Refuelling;
					return;
				}
				method_12().Status = ActiveUnit._ActiveUnitStatus.Unassigned;
				method_12().AirOps.Condition = Aircraft_AirOps._AirOpsCondition.Airborne;
				return;
			}
			if (method_12().AirOps.Condition == Aircraft_AirOps._AirOpsCondition.ManoeuveringToRefuel)
			{
				if (myUnit.IsGroupWingman() && myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Status == ActiveUnit._ActiveUnitStatus.EngagedOffensive)
				{
					method_12().Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
					method_12().AirOps.Condition = ((Aircraft)myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead).AirOps.Condition;
					return;
				}
				Aircraft a2AR_Destination = method_12().AirOps.A2AR_Destination;
				if (a2AR_Destination != null)
				{
					if (!method_12().AirOps.A2AR_Destination.AirOps.RefuellingQueue.ContainsKey(method_12().ObjectID))
					{
						method_12().AirOps.DisconnectFromTanker(recoveringFromDirtystate: true);
						StatusRelatedEvents.desiredStatusAfterTankerDisconnect = null;
						ActiveUnit theSelectedTanker = a2AR_Destination;
						Mission mission = a2AR_Destination.AssignedMissionOrPackage();
						List<Mission> theSelectedMissions = null;
						if (mission != null)
						{
							theSelectedTanker = null;
							theSelectedMissions = new List<Mission> { mission };
						}
						Aircraft_AirOps airOps = method_12().AirOps;
						GeoPoint intermediateTargetPoint = IntermediateTargetPointForRefuelCalcs();
						bool IsManual = false;
						string Feedback = "";
						bool IsRTB = ((ActiveUnit)method_12()).IsRTB;
						bool MissionPlanner_PostponedRefuelling = false;
						airOps.AttemptToScheduleRefuel(intermediateTargetPoint, Doctrine._UnderwayRefuelAndReplenishmentSelection.PickNearest, ref IsManual, IsForced: false, ref theSelectedTanker, ref theSelectedMissions, ref Feedback, ref IsRTB, ref MissionPlanner_PostponedRefuelling, Aircraft_AirOps.RefuelScheduleReason.RescheduleAfterDisconnect);
					}
					if (!myUnit.Navigator.PathFindingInProgress)
					{
						ActiveUnit theUnit = myUnit;
						Exception ThrownError = null;
						if (!Pathfinding.UnitOrFlightPlanHasPFRequestInQueue(theUnit, null, ref ThrownError))
						{
							method_12().Status = ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint;
							return;
						}
					}
					method_12().Status = ActiveUnit._ActiveUnitStatus.WaitForPathfinder;
				}
				else
				{
					method_12().AirOps.DisconnectFromTanker(recoveringFromDirtystate: true);
					if (StatusRelatedEvents.desiredStatusAfterTankerDisconnect.HasValue)
					{
						method_12().Status = StatusRelatedEvents.desiredStatusAfterTankerDisconnect.Value;
					}
				}
				return;
			}
			Mission mission2 = myUnit.AssignedMissionOrPackage();
			if (mission2 != null && mission2.EndTime.HasValue)
			{
				DateTime? endTime = myUnit.AssignedMissionOrPackage().EndTime;
				DateTime time = myUnit.ParentScen.Time;
				if (((!endTime.HasValue) ? ((bool?)null) : new bool?(DateTime.Compare(endTime.GetValueOrDefault(), time) < 0)) == true && !myUnit.IsRTB && !myUnit.IsRefuellingOrHeadingToRefuel)
				{
					myUnit.Status = ActiveUnit._ActiveUnitStatus.RTB_MissionOver;
					method_12().AirOps.Condition = Aircraft_AirOps._AirOpsCondition.RTB;
					return;
				}
			}
			if (myUnit.get_ParentGroup(UsingMissionPlanner: false) != null && myUnit == myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead)
			{
				IEnumerator<KeyValuePair<string, ActiveUnit>> enumerator2 = myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					ActiveUnit value2 = enumerator2.Current.Value;
					if (value2 != myUnit && value2.IsPerformingStandoffAttack)
					{
						method_12().Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
						return;
					}
				}
			}
			if (method_12().IsOnActiveStrike && !IsEscort)
			{
				Strike strike = (Strike)myUnit.ActiveMissionOrPackage();
				if ((PrimaryTarget == null || (PrimaryTarget.get_IsSpecificTargetForThisStrike(strike) && strike.get_FocusEntirelyOnStrikeTargets(myUnit))) && !myUnit.IsRTB && method_12().Navigator.FollowingRTB_FlightPlan())
				{
					Waypoint waypoint = myUnit.Navigator.PlottedCourse.First();
					if (waypoint != null && (waypoint.Type == Waypoint.WaypointType.WeaponLaunch || waypoint.Type == Waypoint.WaypointType.Target || waypoint.Type == Waypoint.WaypointType.WeaponTarget))
					{
						ActiveUnit_Weaponry weaponry = myUnit.Weaponry;
						Contact primaryTarget2 = PrimaryTarget;
						Doctrine doctrine = myUnit.Doctrine;
						string Feedback = "";
						int FeedbackSeverity = 0;
						if (weaponry.HaveAvailableWeaponSuitableForThisTarget(primaryTarget2, CheckWRA: true, doctrine, ref Feedback, ref FeedbackSeverity, HumanFeedBackNeeded: false))
						{
							method_12().Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
						}
						else
						{
							method_12().Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
						}
					}
					else
					{
						method_12().Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
					}
					return;
				}
			}
			if (statusRelatedEvents.desiredStatusAfterTankerDisconnect.HasValue)
			{
				method_12().Status = statusRelatedEvents.desiredStatusAfterTankerDisconnect.Value;
				return;
			}
			if (method_12().ParentScen.list_8.Contains(method_12()))
			{
				method_12().Status = ActiveUnit._ActiveUnitStatus.Unassigned;
				method_12().ParentScen.list_8.Remove(method_12());
				return;
			}
			if ((method_12().IsHelicopter & (method_12().AirOps.HostAirFacility != null)) && method_12().AirOps.HostAirFacility.IsPad())
			{
				method_12().AirOps.Condition = Aircraft_AirOps._AirOpsCondition.Parked;
				method_12().Status = ActiveUnit._ActiveUnitStatus.Unassigned;
				return;
			}
		}
		EvaluateUnitStatus_legacy(elapsedTime, ForceFuelStateCheck, ForceWeaponStateCheck);
	}

	public void getExpectedBingoBehaviourBasedOnRTBDoctrine(ref bool ReturnToBase, bool DetatchFromGroup)
	{
		ReturnToBase = false;
		DetatchFromGroup = false;
		try
		{
			Doctrine._FuelStateRTB? bingoJokerRTB = myUnit.Doctrine.BingoJokerRTB;
			byte? b;
			if (!myUnit.IsGroupMember())
			{
				b = (byte?)bingoJokerRTB;
				bool? flag = ((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0));
				if (((!flag) ?? flag) == true && method_12().AirOps.Condition != Aircraft_AirOps._AirOpsCondition.HoldingOnLandingQueue)
				{
					ReturnToBase = true;
				}
				return;
			}
			b = (byte?)bingoJokerRTB;
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 3)) == true)
			{
				DetatchFromGroup = true;
				ReturnToBase = true;
				return;
			}
			b = (byte?)bingoJokerRTB;
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)) != true)
			{
				b = (byte?)bingoJokerRTB;
				if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) != true)
				{
					return;
				}
				bool flag2 = true;
				foreach (ActiveUnit value in myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values)
				{
					if (value.FuelState == ActiveUnit._ActiveUnitFuelState.None)
					{
						flag2 = false;
						break;
					}
				}
				if (flag2)
				{
					ReturnToBase = true;
				}
			}
			else
			{
				ReturnToBase = true;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200344_11", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void EvaluateUnitStatus_legacy(float elapsedTime, bool ForceFuelStateCheck, bool ForceWeaponStateCheck)
	{
		if (myUnit == null)
		{
			return;
		}
		EvaluateUnitCargoStatus(elapsedTime);
		if (method_12().IsDrone() && method_12().ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DroneAutonomyLevels))
		{
			ActiveUnit.DroneAutonomyLevel autonomyLevel = method_12().AutonomyLevel;
			if (autonomyLevel < ActiveUnit.DroneAutonomyLevel.SelfRecovering)
			{
				if (method_12().CommStuff.TimeOffComms > 0f)
				{
					return;
				}
			}
			else if (autonomyLevel < ActiveUnit.DroneAutonomyLevel.ChangeableMission)
			{
				if (method_12().CommStuff.TimeOffComms > 0f)
				{
					if (method_12().CommStuff.TimeOffComms <= 30f)
					{
						method_12().AirOps.Condition = Aircraft_AirOps._AirOpsCondition.HoldingPattern_CommsLost;
						return;
					}
					method_12().Status = ActiveUnit._ActiveUnitStatus.RTB_CommsLost;
					method_12().AirOps.Condition = Aircraft_AirOps._AirOpsCondition.RTB;
					return;
				}
				if (method_12().Status == ActiveUnit._ActiveUnitStatus.RTB_CommsLost)
				{
					method_12().Status = ActiveUnit._ActiveUnitStatus.Unassigned;
					method_12().AirOps.Condition = Aircraft_AirOps._AirOpsCondition.Airborne;
				}
			}
		}
		EvaluateUnitCargoStatus(elapsedTime);
		Mission mission = myUnit.ActiveMissionOrPackage();
		WeaponThreat = null;
		Aircraft_AirOps airOps = method_12().AirOps;
		if (airOps.Condition == Aircraft_AirOps._AirOpsCondition.EmergencyLanding)
		{
			return;
		}
		if (airOps.A2AR_Destination != null && ((airOps.A2AR_Destination.FuelState == ActiveUnit._ActiveUnitFuelState.IsBingo) | (airOps.A2AR_Destination.FuelState == ActiveUnit._ActiveUnitFuelState.IsJoker) | ((ActiveUnit)airOps.A2AR_Destination).IsRTB))
		{
			ActiveUnit_Navigator navigator = myUnit.Navigator;
			Waypoint[] theArray = navigator.PlottedCourse;
			ArrayExtensions.Clear(ref theArray);
			navigator.PlottedCourse = theArray;
			if (myUnit.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint && myUnit.Status != ActiveUnit._ActiveUnitStatus.Refuelling)
			{
				myUnit._StatusBefore_NeedToRefuel = ActiveUnit._ActiveUnitStatus.Unassigned;
				airOps.A2AR_Destination = null;
			}
			else
			{
				myUnit.Status = myUnit._StatusBefore_NeedToRefuel;
			}
			return;
		}
		bool isInsidePatrolArea_10nmBuffer = base.IsInsidePatrolArea_10nmBuffer;
		bool flag = false;
		if (myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
		{
			flag = true;
		}
		else if (myUnit.IsGroupWingman() && myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead != null)
		{
			myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.Has_NonPathfind_NonFP_PlottedCourse();
		}
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
				if (mission == null || mission.MissionClass != Mission._MissionClass.Strike || (!method_12().Navigator.IsOnAutoPlannerPlottedCourse_FinalTargetRun && (!myUnit.IsGroupWingman() || Information.IsNothing((object)myUnit.IsGroupLead()) || !myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.IsOnAutoPlannerPlottedCourse_FinalTargetRun)))
				{
					myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedDefensive;
					return;
				}
				if (myUnit.Status == ActiveUnit._ActiveUnitStatus.EngagedDefensive)
				{
					myUnit.Status = myUnit._StatusBefore_EngagedDefensive;
				}
			}
			else if (myUnit.Status == ActiveUnit._ActiveUnitStatus.EngagedDefensive)
			{
				myUnit.Status = myUnit._StatusBefore_EngagedDefensive;
			}
		}
		if (myUnit.Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint || airOps.Condition == Aircraft_AirOps._AirOpsCondition.ManoeuveringToRefuel)
		{
			if (myUnit.IsGroupWingman() && !Information.IsNothing((object)myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead) && myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint && myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Status != ActiveUnit._ActiveUnitStatus.Refuelling)
			{
				myUnit.Status = myUnit._StatusBefore_NeedToRefuel;
				airOps.Condition = Aircraft_AirOps._AirOpsCondition.Airborne;
				return;
			}
			if (myUnit.Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint && myUnit.AssignedMissionOrPackage() == null)
			{
				return;
			}
			if (myUnit.IsBingoOrJoker == ActiveUnit._ActiveUnitFuelState.IsBingo)
			{
				myUnit.Status = ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint;
				return;
			}
		}
		if (myUnit.Status == ActiveUnit._ActiveUnitStatus.Refuelling && airOps.Condition == Aircraft_AirOps._AirOpsCondition.Refuelling)
		{
			return;
		}
		if (!myUnit.IsRTB && method_12().IsBingoOrJoker != ActiveUnit._ActiveUnitFuelState.IsBingo && method_12().FuelState == ActiveUnit._ActiveUnitFuelState.IsBingo && method_12().AirOps.Condition != Aircraft_AirOps._AirOpsCondition.ManoeuveringToRefuel)
		{
			method_12().FuelState = ActiveUnit._ActiveUnitFuelState.None;
			airOps.Condition = Aircraft_AirOps._AirOpsCondition.Airborne;
			if (!myUnit.Navigator.HasFlightPlan && !myUnit.Navigator.HasPlottedCourse())
			{
				Mission mission2 = method_12().ActiveMissionOrPackage();
				if (mission2 != null)
				{
					if (mission2.MissionClass == Mission._MissionClass.Patrol)
					{
						method_12().Status = ActiveUnit._ActiveUnitStatus.OnPatrol;
					}
					else if (mission2.MissionClass == Mission._MissionClass.Support)
					{
						method_12().Status = ActiveUnit._ActiveUnitStatus.OnSupportMission;
					}
					else if (method_12().Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint)
					{
						method_12().Status = ActiveUnit._ActiveUnitStatus.Tasked;
					}
				}
			}
			else
			{
				method_12().Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
			}
		}
		if (airOps.Condition == Aircraft_AirOps._AirOpsCondition.Landing_PreTouchdown)
		{
			myUnit.Status = ActiveUnit._ActiveUnitStatus.RTB_Manual;
			return;
		}
		if (myUnit.IsGroupLead() && myUnit.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint && !IsEscort && method_12().AssignedMissionOrPackage() != null && method_12().AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike && method_12().AssignedMissionOrPackage().HasFlightPlans() && (!myUnit.FollowingPCThatIsRTB || (myUnit.Navigator.PlottedCourse.Count() > 0 && (myUnit.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.LandingMarshal || myUnit.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.Land) && myUnit.Navigator.PlottedCourse[0].RangeToUnit_Horiz(myUnit) < 20f)))
		{
			method_12().AI.ReturnToBase(elapsedTime);
			method_12().Status = ActiveUnit._ActiveUnitStatus.RTB_Manual;
			method_12().AirOps.Condition = Aircraft_AirOps._AirOpsCondition.HoldingOnLandingQueue;
			return;
		}
		ActiveUnit._ActiveUnitFuelState isBingoOrJoker;
		bool flag4;
		bool MissionPlanner_PostponedRefuelling;
		GeoPoint geoPoint;
		bool? obj2;
		bool? flag2;
		bool CheckForMines;
		string UserFeedback;
		bool CheckNoNavZones;
		if (!myUnit.Navigator.PathFindingInProgress)
		{
			ActiveUnit theUnit = myUnit;
			Exception ThrownError = null;
			if (!Pathfinding.UnitOrFlightPlanHasPFRequestInQueue(theUnit, null, ref ThrownError))
			{
				if (myUnit.Navigator.HasPathfindingPlottedCourse && myUnit.Status == ActiveUnit._ActiveUnitStatus.WaitForPathfinder)
				{
					myUnit.Status = myUnit._StatusBefore_WaitForPathfinder;
				}
				if (myUnit.ParentScen.MinuteIsChangingOnThisPulse)
				{
					ActiveUnit activeUnit = myUnit;
					double theLat = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
					double theLon = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
					int MovementCost = 0;
					CheckNoNavZones = true;
					CheckForMines = true;
					List<ActiveUnit> ProvidedPiers = null;
					UserFeedback = "";
					bool AllowBounce = false;
					if (!activeUnit.CanMoveToThisLocation(theLat, theLon, ref MovementCost, IsPathfindingQuery: true, UsePathfindingBufferDistance: true, IgnoreMinesBehindUs: false, ref CheckNoNavZones, CheckForIcepack: true, ref CheckForMines, null, null, ref ProvidedPiers, 0f, CheckIfTargetIsOutsideProsecutionArea: false, CheckDistanceToNoNavZones: true, ref UserFeedback, ref AllowBounce))
					{
						if (!myUnit.Navigator.HasPlottedCourse())
						{
							ActiveUnit_Navigator navigator2 = myUnit.Navigator;
							double startLat = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
							double startLon = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
							ProvidedPiers = null;
							Waypoint nearestAccessibleSpot = navigator2.GetNearestAccessibleSpot(startLat, startLon, ref ProvidedPiers);
							if (!Information.IsNothing((object)nearestAccessibleSpot))
							{
								ActiveUnit_Navigator navigator3 = myUnit.Navigator;
								Waypoint[] theArray = navigator3.PlottedCourse;
								ArrayExtensions.Insert(ref theArray, 0, nearestAccessibleSpot);
								navigator3.PlottedCourse = theArray;
								myUnit.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
								return;
							}
						}
						else
						{
							Waypoint waypoint = myUnit.Navigator.PlottedCourse[0];
							if (waypoint.Type != Waypoint.WaypointType.PathfindingPoint)
							{
								ActiveUnit_Navigator navigator4 = myUnit.Navigator;
								double startLat2 = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
								double startLon2 = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
								ProvidedPiers = null;
								Waypoint nearestAccessibleSpot2 = navigator4.GetNearestAccessibleSpot(startLat2, startLon2, ref ProvidedPiers);
								ActiveUnit activeUnit2 = myUnit;
								double latitude = waypoint.Latitude;
								double longitude = waypoint.Longitude;
								MovementCost = 0;
								AllowBounce = true;
								CheckForMines = true;
								ProvidedPiers = null;
								UserFeedback = "";
								CheckNoNavZones = false;
								if (activeUnit2.CanMoveToThisLocation(latitude, longitude, ref MovementCost, IsPathfindingQuery: true, UsePathfindingBufferDistance: true, IgnoreMinesBehindUs: false, ref AllowBounce, CheckForIcepack: true, ref CheckForMines, null, null, ref ProvidedPiers, 0f, CheckIfTargetIsOutsideProsecutionArea: false, CheckDistanceToNoNavZones: true, ref UserFeedback, ref CheckNoNavZones))
								{
									if (Module_Unit.RangeToPoint_Horiz_Angular(myUnit, nearestAccessibleSpot2) + 0.2 < Module_Unit.RangeToPoint_Horiz_Angular(myUnit, waypoint))
									{
										ActiveUnit_Navigator navigator5 = myUnit.Navigator;
										Waypoint[] theArray = navigator5.PlottedCourse;
										ArrayExtensions.Insert(ref theArray, 0, nearestAccessibleSpot2);
										navigator5.PlottedCourse = theArray;
									}
									myUnit.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
								}
								else
								{
									ActiveUnit_Navigator navigator6 = myUnit.Navigator;
									Waypoint[] theArray = navigator6.PlottedCourse;
									ArrayExtensions.Insert(ref theArray, 0, nearestAccessibleSpot2);
									navigator6.PlottedCourse = theArray;
									myUnit.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
								}
								return;
							}
						}
					}
				}
				if (myUnit.ParentScen.FifteenthSecondIsChangingOnThisPulse || ForceFuelStateCheck)
				{
					if (method_12().FuelState != ActiveUnit._ActiveUnitFuelState.IgnoreBingoAndJoker)
					{
						isBingoOrJoker = method_12().IsBingoOrJoker;
						if (airOps.Condition != Aircraft_AirOps._AirOpsCondition.HoldingOnLandingQueue)
						{
							if (isBingoOrJoker != ActiveUnit._ActiveUnitFuelState.IsBingo && isBingoOrJoker != ActiveUnit._ActiveUnitFuelState.IsJoker)
							{
								bool? obj;
								if (myUnit.Navigator.HasFlightPlan)
								{
									Waypoint previousWaypoint = myUnit.Navigator.PreviousWaypoint;
									obj = ((previousWaypoint == null) ? ((bool?)null) : new bool?(previousWaypoint.Type == Waypoint.WaypointType.Refuel));
								}
								else
								{
									obj = false;
								}
								flag2 = obj;
								if (!(flag2 ?? true) || GetMissionStateFlag(1u) || !flag2.HasValue)
								{
									goto IL_2436;
								}
							}
							bool flag3 = method_12().Status == ActiveUnit._ActiveUnitStatus.RTB_Exhaustion || method_12().Status == ActiveUnit._ActiveUnitStatus.RTB_Manual || method_12().Status == ActiveUnit._ActiveUnitStatus.RTB_MissionOver || method_12().Status == ActiveUnit._ActiveUnitStatus.RTB_CommsLost || (method_12().Status == ActiveUnit._ActiveUnitStatus.RTB && myUnit.FuelState == ActiveUnit._ActiveUnitFuelState.None) || method_12()._StatusBefore_NeedToRefuel == ActiveUnit._ActiveUnitStatus.RTB_Manual || method_12()._StatusBefore_NeedToRefuel == ActiveUnit._ActiveUnitStatus.RTB_MissionOver || method_12().Status == ActiveUnit._ActiveUnitStatus.RTB_CommsLost || (method_12()._StatusBefore_NeedToRefuel == ActiveUnit._ActiveUnitStatus.RTB && myUnit.FuelState == ActiveUnit._ActiveUnitFuelState.None);
							flag4 = method_12().FuelState == ActiveUnit._ActiveUnitFuelState.IsBingo || method_12().FuelState == ActiveUnit._ActiveUnitFuelState.IsJoker;
							MissionPlanner_PostponedRefuelling = false;
							if (method_12().FuelState != isBingoOrJoker)
							{
								method_12().DisconnectTankerClients("has reached Bingo or Joker fuel");
							}
							method_12().FuelState = isBingoOrJoker;
							if (!myUnit.IsPaintingATarget && !myUnit.WillNeedToPaintATarget && !NeedToCrank() && myUnit.Status != ActiveUnit._ActiveUnitStatus.RTB_CalledOff)
							{
								geoPoint = IntermediateTargetPointForRefuelCalcs();
								if (!flag3)
								{
									int value;
									if (myUnit.Navigator.HasFlightPlan)
									{
										if (myUnit.Navigator.PlottedCourse.Count() > 0)
										{
											Waypoint previousWaypoint2 = myUnit.Navigator.PreviousWaypoint;
											obj2 = ((previousWaypoint2 == null) ? ((bool?)null) : new bool?(previousWaypoint2.Type == Waypoint.WaypointType.Refuel));
											goto IL_0c0a;
										}
										value = 0;
									}
									else
									{
										value = 0;
									}
									obj2 = (byte)value != 0;
									goto IL_0c0a;
								}
								goto IL_1d65;
							}
							goto IL_2369;
						}
						goto IL_2436;
					}
					goto IL_2452;
				}
				goto IL_2820;
			}
		}
		if (myUnit.Status != ActiveUnit._ActiveUnitStatus.WaitForPathfinder)
		{
			myUnit._StatusBefore_WaitForPathfinder = myUnit.Status;
			myUnit.Status = ActiveUnit._ActiveUnitStatus.WaitForPathfinder;
		}
		return;
		IL_1017:
		bool? obj3;
		flag2 = (bool?)obj3;
		ActiveUnit theSelectedTanker;
		List<Mission> theSelectedMissions;
		if ((flag2 ?? true) && !GetMissionStateFlag(1u) && flag2.HasValue && !AlreadyRTBAndNearlyBackToBase())
		{
			Doctrine._UnderwayRefuelAndReplenishmentSelection value2 = myUnit.Doctrine.get_ReplenishmentSelection(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false).Value;
			CheckForMines = false;
			theSelectedTanker = null;
			theSelectedMissions = null;
			UserFeedback = "";
			CheckNoNavZones = false;
			if (airOps.AttemptToScheduleRefuel(geoPoint, value2, ref CheckForMines, IsForced: false, ref theSelectedTanker, ref theSelectedMissions, ref UserFeedback, ref CheckNoNavZones, ref MissionPlanner_PostponedRefuelling, Aircraft_AirOps.RefuelScheduleReason.OnStrikeFarFromBase))
			{
				return;
			}
		}
		bool flag5;
		double num2 = default(double);
		bool flag7;
		bool flag8;
		bool? flag10;
		bool? flag9;
		if (!MissionPlanner_PostponedRefuelling)
		{
			if (myUnit.Navigator.IsOnAutoPlannerPlottedCourse)
			{
				int num;
				if (myUnit.Navigator.IsOnAutoPlannerPlottedCourse_OnStation)
				{
					num = 0;
				}
				else if (myUnit.Navigator.IsOnAutoPlannerPlottedCourse_StationIngressRun)
				{
					num = 0;
				}
				else
				{
					if (!myUnit.Navigator.HasFlight || myUnit.Navigator.get_Flight(HierarchySearch: true).get_Status(myUnit.ParentScen) == Mission._FlightStatus.Airborne_EgressLeg)
					{
						goto IL_19fb;
					}
					num = 0;
				}
				bool ReturnToBase = (byte)num != 0;
				flag5 = false;
				getExpectedBingoBehaviourBasedOnRTBDoctrine(ref ReturnToBase, DetatchFromGroup: false);
				if (ReturnToBase)
				{
					bool flag6 = false;
					Waypoint waypoint2 = null;
					Waypoint[] theArray = myUnit.Navigator.PlottedCourse;
					foreach (Waypoint waypoint3 in theArray)
					{
						if (waypoint3 == null)
						{
							continue;
						}
						int num3;
						if (waypoint3.Type != Waypoint.WaypointType.StationEnd)
						{
							if (waypoint3.Type != Waypoint.WaypointType.StrikeEgress)
							{
								if (flag6)
								{
									num2 += (double)waypoint3.Leg_FuelRequired;
								}
								continue;
							}
							num3 = 1;
						}
						else
						{
							num3 = 1;
						}
						flag6 = (byte)num3 != 0;
						waypoint2 = waypoint3;
					}
					if (waypoint2 != null)
					{
						Math2.CalcDist(method_12().get_Latitude((GlobalVariables.BooleanObject)null), method_12().get_Longitude((GlobalVariables.BooleanObject)null), waypoint2.Latitude, waypoint2.Longitude);
						num2 += (double)method_12().Kinematics.FuelNecessaryToReachWaypoint(waypoint2.Leg_Speed_Straight, waypoint2.ThrottlePreset, waypoint2);
					}
					num2 *= 1.1;
					flag7 = false;
					flag8 = false;
					b = (byte?)myUnit.Doctrine.get_UseReplenishment(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
					flag2 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
					if (((!flag2) ?? flag2) == true && !Information.IsNothing((object)mission))
					{
						Mission mission3 = mission;
						int num5;
						if (mission3.TankerMinNumber_Airborne <= 0)
						{
							if (!mission3.LaunchMissionWithoutTankersInPlace)
							{
								if (mission3.MissionClass == Mission._MissionClass.Strike)
								{
									Module_Unit.Unit unit2 = default(Module_Unit.Unit);
									if (((Strike)mission3).SpecificTargets != null)
									{
										unit2 = ((Strike)mission3).SpecificTargets.FirstOrDefault();
									}
									if (unit2 != null)
									{
										Aircraft_Navigator navigator7 = method_12().Navigator;
										CheckNoNavZones = false;
										float bingoFuelAltitude = navigator7.GetBingoFuelAltitude(ref CheckNoNavZones);
										int num4;
										if (mission3.KeepOnMissionWithoutTankersInPlace)
										{
											num4 = 1;
										}
										else
										{
											double theLatitude = unit2.get_Latitude((GlobalVariables.BooleanObject)null);
											double theLongitude = unit2.get_Longitude((GlobalVariables.BooleanObject)null);
											float theTacRadius = method_12().Loadout.CombatRadius;
											float? theAltitude = bingoFuelAltitude;
											UserFeedback = "";
											if (!HaveTankersWithinTacticalRadiusFromTarget(theLatitude, theLongitude, theTacRadius, theAltitude, ref UserFeedback))
											{
												goto IL_136c;
											}
											num4 = 1;
										}
										flag7 = (byte)num4 != 0;
									}
								}
								goto IL_136c;
							}
							num5 = 1;
						}
						else
						{
							num5 = 1;
						}
						flag7 = (byte)num5 != 0;
						flag8 = mission3.LaunchMissionWithoutTankersInPlace;
					}
					goto IL_136c;
				}
			}
			else if (myUnit.IsGroupWingman())
			{
				Group obj4 = myUnit.get_ParentGroup(UsingMissionPlanner: false);
				if (obj4 != null)
				{
					ActiveUnit groupLead = obj4.GroupLead;
					if (groupLead != null && groupLead.Navigator.IsOnAutoPlannerPlottedCourse)
					{
						b = (byte?)myUnit.Doctrine.get_UseReplenishment(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
						flag9 = (flag10 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)));
						flag2 = ((flag9.HasValue && flag10 == true) ? new bool?(true) : ((!method_12().ActiveMissionOrPackage().KeepOnMissionWithoutTankersInPlace) ? new bool?(true) : flag10));
						if ((flag2 ?? true) && (myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.IsOnAutoPlannerPlottedCourse_OnStation || myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.IsOnAutoPlannerPlottedCourse_StationIngressRun || (myUnit.Navigator.HasFlight && myUnit.Navigator.get_Flight(HierarchySearch: true).get_Status(myUnit.ParentScen) != Mission._FlightStatus.Airborne_EgressLeg && ((mission != null && mission.MissionClass == Mission._MissionClass.Patrol) || (mission != null && mission.MissionClass == Mission._MissionClass.Support))) || myUnit.AI.IsEscort) && flag2.HasValue)
						{
							bool flag11 = false;
							Doctrine._FuelStateRTB? bingoJokerRTB = myUnit.Doctrine.BingoJokerRTB;
							b = (byte?)bingoJokerRTB;
							if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 3)) == true)
							{
								myUnit.DetachUnit(NotifyPlayer: false, ClearPlottedCourse: false, UseFlightplan: true);
								flag11 = true;
							}
							else
							{
								b = (byte?)bingoJokerRTB;
								if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)) == true)
								{
									int num6;
									if (myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Status != ActiveUnit._ActiveUnitStatus.RTB_CalledOff)
									{
										myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.EgressToRejoinPoint(elapsedTime, ForceObjectiveWaypointRemoval: false);
										myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Status = ActiveUnit._ActiveUnitStatus.RTB_CalledOff;
										Doctrine doctrine = myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Doctrine;
										CheckNoNavZones = true;
										Doctrine parentDoctrine = doctrine.GetParentDoctrine(ref CheckNoNavZones);
										myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Doctrine.set_UseReplenishment(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false, parentDoctrine.get_UseReplenishment(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false));
										num6 = 1;
									}
									else
									{
										num6 = 1;
									}
									flag11 = (byte)num6 != 0;
								}
							}
							if (flag11)
							{
								b = (byte?)myUnit.Doctrine.get_UseReplenishment(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
								if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true || !method_12().ActiveMissionOrPackage().KeepOnMissionWithoutTankersInPlace)
								{
									myUnit.Navigator.EgressToRejoinPoint(elapsedTime, ForceObjectiveWaypointRemoval: false);
									myUnit.Status = ActiveUnit._ActiveUnitStatus.RTB_CalledOff;
									Doctrine doctrine2 = myUnit.Doctrine;
									CheckNoNavZones = true;
									Doctrine parentDoctrine2 = doctrine2.GetParentDoctrine(ref CheckNoNavZones);
									myUnit.Doctrine.set_UseReplenishment(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false, parentDoctrine2.get_UseReplenishment(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false));
									return;
								}
							}
						}
					}
				}
			}
		}
		goto IL_19fb;
		IL_2820:
		if (myUnit.IsRTB)
		{
			if (myUnit.IsPaintingATarget || NeedToCrank())
			{
				myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
				return;
			}
			if (airOps.Condition != Aircraft_AirOps._AirOpsCondition.HoldingOnLandingQueue && (!myUnit.IsUsingDippingSonar() || myUnit.FuelState == ActiveUnit._ActiveUnitFuelState.IsBingo) && airOps.Condition != Aircraft_AirOps._AirOpsCondition.RTB)
			{
				airOps.Condition = Aircraft_AirOps._AirOpsCondition.RTB;
			}
		}
		if (myUnit.IsUsingDippingSonar() || airOps.Condition == Aircraft_AirOps._AirOpsCondition.TransferringCargo)
		{
			return;
		}
		if (method_12().WeaponState != ActiveUnit._ActiveUnitWeaponState.IgnoreWinchesterAndShotgun)
		{
			ActiveUnit._ActiveUnitWeaponState activeUnitWeaponState = method_12().Weaponry.IsWinchesterOrShotgun();
			if (activeUnitWeaponState != ActiveUnit._ActiveUnitWeaponState.IsWinchester && activeUnitWeaponState != ActiveUnit._ActiveUnitWeaponState.IsShotgun)
			{
				if (myUnit.ParentScen.MinuteIsChangingOnThisPulse && myUnit.Navigator.IsOnAutoPlannerPlottedCourse_CruiseAndAttackEgressRun)
				{
					b = (byte?)method_12().Doctrine.get_UseReplenishment(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
					flag2 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
					if (((!flag2) ?? flag2) == true)
					{
						Aircraft_Navigator obj5 = (Aircraft_Navigator)myUnit.Navigator;
						ActiveUnit.Throttle bingoFuelThrottle = obj5.GetBingoFuelThrottle();
						CheckForMines = false;
						float bingoFuelAltitude2 = obj5.GetBingoFuelAltitude(ref CheckForMines);
						float num7 = float.MaxValue;
						ActiveUnit activeUnit3 = myUnit;
						if (myUnit.IsGroupMember())
						{
							List<ActiveUnit> list = new List<ActiveUnit>(myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values);
							List<ActiveUnit>.Enumerator enumerator = list.GetEnumerator();
							while (enumerator.MoveNext())
							{
								ActiveUnit current = enumerator.Current;
								if (current != null && (float)current.FuelCapacityCurrent < num7)
								{
									num7 = current.FuelCapacityCurrent;
									activeUnit3 = current;
								}
							}
						}
						ActiveUnit actualDestinationHost = ((Aircraft_AirOps)activeUnit3.AirOps).ActualDestinationHost;
						if (!Information.IsNothing((object)actualDestinationHost) && (double)activeUnit3.Kinematics.FuelNecessaryForThisDistance(activeUnit3.RangeToUnit_Horiz(actualDestinationHost), bingoFuelThrottle, bingoFuelAltitude2, activeUnit3.Kinematics.GetMaximumSpeed(bingoFuelAltitude2, bingoFuelThrottle, ValidateAndFixAltitude: false), CombatRadiusCalc: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false) > (double)((float)activeUnit3.FuelCapacityCurrent - activeUnit3.Kinematics.ReserveFuel) * 0.9)
						{
							float num8 = (Information.IsNothing((object)mission) ? 0.85f : ((mission.FuelQtyToStartLookingForTanker_Airborne <= 0) ? 0f : ((float)((double)mission.FuelQtyToStartLookingForTanker_Airborne / 100.0))));
							if (num8 > 0f)
							{
								method_15(num8, myUnit.Doctrine.get_ReplenishmentSelection(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false).Value);
							}
						}
					}
				}
				if (method_12().WeaponState != activeUnitWeaponState)
				{
					method_12().WeaponState = activeUnitWeaponState;
				}
			}
			else
			{
				myUnit.WeaponState = activeUnitWeaponState;
				if (!myUnit.IsPaintingATarget && !myUnit.WillNeedToPaintATarget && !NeedToCrank() && myUnit.Status != ActiveUnit._ActiveUnitStatus.RTB_CalledOff)
				{
					if (myUnit.Navigator.IsOnAutoPlannerPlottedCourse_CruiseAndAttackIngressRun)
					{
						if (activeUnitWeaponState == ActiveUnit._ActiveUnitWeaponState.IsWinchester)
						{
							if (myUnit.Navigator.HasPlottedCourse())
							{
								Waypoint? waypoint4 = myUnit.Navigator.PlottedCourse.FirstOrDefault();
								if (waypoint4 != null && waypoint4.Type == Waypoint.WaypointType.HoldStart)
								{
									if (method_12().AirOps.AttemptToRTB(ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB, GroupMembersRTB: true, ActiveUnit._ActiveUnitStatus.RTB, DetachFromGroup: false, ClearPlottedCourse: true))
									{
										return;
									}
									goto IL_2c63;
								}
							}
							if (!myUnit.AI.IsEscort && myUnit.Navigator.IsOnAutoPlannerPlottedCourse_AttackIngressRun && (myUnit.get_ParentGroup(UsingMissionPlanner: false) == null || myUnit.get_ParentGroup(UsingMissionPlanner: false).Weaponry.IsWinchesterOrShotgun() == ActiveUnit._ActiveUnitWeaponState.IsWinchester))
							{
								myUnit.Navigator.EgressToRejoinPoint(elapsedTime, ForceObjectiveWaypointRemoval: false);
							}
						}
						goto IL_2c63;
					}
					if (!myUnit.Navigator.IsOnAutoPlannerPlottedCourse_CruiseAndAttackEgressRun)
					{
						if (!myUnit.Navigator.IsOnAutoPlannerPlottedCourse)
						{
							if (myUnit.IsGroupWingman() && myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead != null && myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.IsOnAutoPlannerPlottedCourse)
							{
								if (myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.IsOnAutoPlannerPlottedCourse_OnStation || myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.IsOnAutoPlannerPlottedCourse_StationIngressRun || (myUnit.Navigator.HasFlight && myUnit.Navigator.get_Flight(HierarchySearch: true).get_Status(myUnit.ParentScen) != Mission._FlightStatus.Airborne_EgressLeg && ((!Information.IsNothing((object)mission) && (mission.MissionClass == Mission._MissionClass.Patrol || mission.MissionClass == Mission._MissionClass.Support)) || myUnit.AI.IsEscort)))
								{
									bool flag12 = false;
									Doctrine._WeaponStateRTB? weaponStateRTB = myUnit.Doctrine.WinchesterShotgunRTB;
									b = (byte?)weaponStateRTB;
									if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 3)) != true)
									{
										b = (byte?)weaponStateRTB;
										if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)) == true)
										{
											myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.EgressToRejoinPoint(elapsedTime, ForceObjectiveWaypointRemoval: false);
											myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
										}
									}
									else
									{
										myUnit.DetachUnit(NotifyPlayer: false, ClearPlottedCourse: false, UseFlightplan: true);
										flag12 = true;
									}
									if (flag12)
									{
										myUnit.Navigator.EgressToRejoinPoint(elapsedTime, ForceObjectiveWaypointRemoval: false);
										myUnit.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
										return;
									}
									if (!Information.IsNothing((object)myUnit.Kinematics.DesiredSpeedOverride))
									{
										myUnit.Kinematics.DesiredSpeedOverride = null;
									}
									if (myUnit.Kinematics.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None)
									{
										myUnit.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
									}
									if ((Information.IsNothing((object)myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead) || myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint) && !Information.IsNothing((object)mission))
									{
										switch (mission.MissionClass)
										{
										case Mission._MissionClass.Strike:
											myUnit.Status = ActiveUnit._ActiveUnitStatus.Tasked;
											return;
										case Mission._MissionClass.Patrol:
											myUnit.Status = ActiveUnit._ActiveUnitStatus.OnPatrol;
											return;
										case Mission._MissionClass.Support:
											myUnit.Status = ActiveUnit._ActiveUnitStatus.OnSupportMission;
											return;
										}
									}
								}
							}
							else if (!myUnit.IsRTB && myUnit.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint && myUnit.Status != ActiveUnit._ActiveUnitStatus.Refuelling && myUnit.Status != ActiveUnit._ActiveUnitStatus.WaitForPathfinder)
							{
								Doctrine._WeaponStateRTB? weaponStateRTB2 = myUnit.Doctrine.WinchesterShotgunRTB;
								if (myUnit.FollowingPCThatIsRTB && ((myUnit.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.LandingMarshal) | (myUnit.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.Land)))
								{
									method_12().AI.ReturnToBase(elapsedTime);
									return;
								}
								if (!myUnit.IsGroupMember())
								{
									b = (byte?)weaponStateRTB2;
									flag2 = ((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0));
									if (((!flag2) ?? flag2) == true && method_12().AirOps.Condition != Aircraft_AirOps._AirOpsCondition.HoldingOnLandingQueue && !method_12().Weaponry.IsGuidingWeaponsInAir())
									{
										if (myUnit.Navigator.HasPlottedCourse() && myUnit.Navigator.PlottedCourse[0].Category == Waypoint.WaypointCategory.PlottedCourse)
										{
											myUnit.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
											return;
										}
										if (method_12().AirOps.AttemptToRTB(ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB, GroupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, DetachFromGroup: true, ClearPlottedCourse: true))
										{
											return;
										}
									}
								}
								else
								{
									b = (byte?)weaponStateRTB2;
									if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 3)) == true)
									{
										if (!method_12().Weaponry.IsGuidingWeaponsInAir() && method_12().AirOps.AttemptToRTB(ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB, GroupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, DetachFromGroup: true, ClearPlottedCourse: true))
										{
											return;
										}
									}
									else
									{
										b = (byte?)weaponStateRTB2;
										if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)) == true)
										{
											if (!method_12().Weaponry.IsGuidingWeaponsInAir() && method_12().AirOps.AttemptToRTB(ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB, GroupMembersRTB: true, ActiveUnit._ActiveUnitStatus.RTB_Group, DetachFromGroup: false, ClearPlottedCourse: true))
											{
												return;
											}
										}
										else
										{
											b = (byte?)weaponStateRTB2;
											if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
											{
												bool flag13 = true;
												List<ActiveUnit>.Enumerator enumerator2 = myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values.ToList().GetEnumerator();
												while (enumerator2.MoveNext())
												{
													ActiveUnit current2 = enumerator2.Current;
													if (current2.WeaponState == ActiveUnit._ActiveUnitWeaponState.None || current2.WeaponState == ActiveUnit._ActiveUnitWeaponState.IsShotgun_EngagingToO || current2.WeaponState == ActiveUnit._ActiveUnitWeaponState.IsWinchester_EngagingToO || current2.Weaponry.IsGuidingWeaponsInAir())
													{
														flag13 = false;
														break;
													}
												}
												if (flag13)
												{
													if (method_12().Navigator.HasFlightPlan)
													{
														method_12().Navigator.FollowPlottedCourse(elapsedTime);
														return;
													}
													if (method_12().AirOps.AttemptToRTB(ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB, GroupMembersRTB: true, ActiveUnit._ActiveUnitStatus.RTB_Group, DetachFromGroup: false, ClearPlottedCourse: true))
													{
														return;
													}
												}
											}
										}
									}
								}
							}
						}
						else
						{
							int num9;
							if (myUnit.Navigator.IsOnAutoPlannerPlottedCourse_OnStation)
							{
								num9 = 0;
							}
							else if (myUnit.Navigator.IsOnAutoPlannerPlottedCourse_StationIngressRun)
							{
								num9 = 0;
							}
							else
							{
								if (!myUnit.Navigator.HasFlight || myUnit.Navigator.get_Flight(HierarchySearch: true).get_Status(myUnit.ParentScen) == Mission._FlightStatus.Airborne_EgressLeg)
								{
									goto IL_3957;
								}
								if (!Information.IsNothing((object)mission) && (mission.MissionClass == Mission._MissionClass.Patrol || mission.MissionClass == Mission._MissionClass.Support))
								{
									num9 = 0;
								}
								else
								{
									if (!myUnit.AI.IsEscort)
									{
										goto IL_3957;
									}
									num9 = 0;
								}
							}
							bool flag14 = (byte)num9 != 0;
							Doctrine._WeaponStateRTB? weaponStateRTB3 = myUnit.Doctrine.WinchesterShotgunRTB;
							if (myUnit.IsGroupMember())
							{
								b = (byte?)weaponStateRTB3;
								if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 3)) != true)
								{
									b = (byte?)weaponStateRTB3;
									if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)) != true)
									{
										b = (byte?)weaponStateRTB3;
										if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
										{
											bool flag15 = true;
											IEnumerator<ActiveUnit> enumerator3 = myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values.GetEnumerator();
											while (enumerator3.MoveNext())
											{
												ActiveUnit current3 = enumerator3.Current;
												int num10;
												if (current3.WeaponState != ActiveUnit._ActiveUnitWeaponState.None)
												{
													if (current3.WeaponState != ActiveUnit._ActiveUnitWeaponState.IsShotgun_EngagingToO && current3.WeaponState != ActiveUnit._ActiveUnitWeaponState.IsWinchester_EngagingToO)
													{
														if (!current3.Weaponry.IsGuidingWeaponsInAir())
														{
															continue;
														}
														num10 = 0;
													}
													else
													{
														num10 = 0;
													}
												}
												else
												{
													num10 = 0;
												}
												flag15 = (byte)num10 != 0;
												break;
											}
											if (flag15)
											{
												flag14 = true;
											}
										}
									}
									else
									{
										flag14 = true;
									}
								}
								else
								{
									myUnit.DetachUnit(NotifyPlayer: false, ClearPlottedCourse: false, UseFlightplan: true);
									flag14 = true;
								}
							}
							else
							{
								b = (byte?)weaponStateRTB3;
								flag2 = ((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0));
								if (((!flag2) ?? flag2) == true && method_12().AirOps.Condition != Aircraft_AirOps._AirOpsCondition.HoldingOnLandingQueue)
								{
									flag14 = true;
								}
							}
							if (flag14)
							{
								Aircraft aircraft = method_12();
								if (weaponStateRTB3.HasValue && weaponStateRTB3.Value == Doctrine._WeaponStateRTB.YesFirstUnit && method_12().IsGroupWingman())
								{
									aircraft = (Aircraft)((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).GroupLead;
								}
								aircraft.Navigator.EgressToRejoinPoint(elapsedTime, ForceObjectiveWaypointRemoval: false);
								if (((ActiveUnit)aircraft).IsRTB)
								{
									return;
								}
								aircraft.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
								if (!aircraft.IsGroupLead())
								{
									return;
								}
								IEnumerator<KeyValuePair<string, ActiveUnit>> enumerator4 = myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.GetEnumerator();
								while (enumerator4.MoveNext())
								{
									KeyValuePair<string, ActiveUnit> current4 = enumerator4.Current;
									if (current4.Value != myUnit && current4.Value.Weaponry.IsWinchesterOrShotgun() == ActiveUnit._ActiveUnitWeaponState.IsWinchester)
									{
										current4.Value.Status = ActiveUnit._ActiveUnitStatus.Tasked;
									}
								}
								return;
							}
						}
					}
					else if (myUnit.ParentScen.MinuteIsChangingOnThisPulse && !Information.IsNothing((object)mission))
					{
						b = (byte?)method_12().Doctrine.get_UseReplenishment(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
						flag2 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
						if (((!flag2) ?? flag2) == true)
						{
							ActiveUnit.Throttle bingoFuelThrottle2 = method_12().Navigator.GetBingoFuelThrottle();
							Aircraft_Navigator navigator8 = method_12().Navigator;
							CheckNoNavZones = false;
							float bingoFuelAltitude3 = navigator8.GetBingoFuelAltitude(ref CheckNoNavZones);
							float num11 = float.MaxValue;
							Aircraft aircraft2 = method_12();
							if (myUnit.IsGroupMember())
							{
								IEnumerator<ActiveUnit> enumerator5 = myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values.GetEnumerator();
								while (enumerator5.MoveNext())
								{
									ActiveUnit current5 = enumerator5.Current;
									if ((float)current5.FuelCapacityCurrent < num11)
									{
										num11 = current5.FuelCapacityCurrent;
										aircraft2 = (Aircraft)current5;
									}
								}
							}
							ActiveUnit actualDestinationHost2 = aircraft2.AirOps.ActualDestinationHost;
							if (!Information.IsNothing((object)actualDestinationHost2) && (double)aircraft2.Kinematics.FuelNecessaryForThisDistance(aircraft2.RangeToUnit_Horiz(actualDestinationHost2), bingoFuelThrottle2, bingoFuelAltitude3, aircraft2.Kinematics.GetMaximumSpeed(bingoFuelAltitude3, bingoFuelThrottle2, ValidateAndFixAltitude: false), CombatRadiusCalc: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false) > (double)((float)aircraft2.FuelCapacityCurrent - aircraft2.Kinematics.ReserveFuel) * 0.9)
							{
								GeoPoint intermediateTargetPoint = IntermediateTargetPointForRefuelCalcs();
								bool MissionPlanner_PostponedRefuelling2 = false;
								Doctrine._UnderwayRefuelAndReplenishmentSelection value3 = myUnit.Doctrine.get_ReplenishmentSelection(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false).Value;
								CheckNoNavZones = false;
								theSelectedTanker = null;
								theSelectedMissions = null;
								UserFeedback = "";
								CheckForMines = true;
								if (airOps.AttemptToScheduleRefuel(intermediateTargetPoint, value3, ref CheckNoNavZones, IsForced: false, ref theSelectedTanker, ref theSelectedMissions, ref UserFeedback, ref CheckForMines, ref MissionPlanner_PostponedRefuelling2, Aircraft_AirOps.RefuelScheduleReason.AutoPlannerCruiseAndAttackEgressRun))
								{
									return;
								}
							}
						}
					}
				}
			}
		}
		goto IL_3957;
		IL_0fcc:
		bool? obj6;
		bool? flag16 = (bool?)obj6;
		flag16 = (flag10 = (!flag16) ?? flag16);
		obj3 = ((!flag16.HasValue) ? ((bool?)null) : ((flag10 == true) & flag9));
		goto IL_1017;
		IL_2436:
		if (method_12().FuelState != isBingoOrJoker)
		{
			method_12().FuelState = isBingoOrJoker;
		}
		goto IL_2452;
		IL_1aee:
		if (!myUnit.Navigator.EgressToRejoinPoint_CallOff(elapsedTime))
		{
			goto IL_1d96;
		}
		return;
		IL_2c63:
		if (!myUnit.IsRTB)
		{
			myUnit.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
		}
		return;
		IL_1d96:
		if (airOps.Condition != Aircraft_AirOps._AirOpsCondition.RTB || !myUnit.IsRTB)
		{
			if (!myUnit.Navigator.IsOnAutoPlannerPlottedCourse && (!myUnit.IsGroupWingman() || Information.IsNothing((object)myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead) || !myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.IsOnAutoPlannerPlottedCourse))
			{
				Doctrine._FuelStateRTB? bingoJokerRTB2 = myUnit.Doctrine.BingoJokerRTB;
				if (!myUnit.IsGroupMember())
				{
					b = (byte?)bingoJokerRTB2;
					flag2 = ((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0));
					if (((!flag2) ?? flag2) == true && !method_12().Weaponry.IsGuidingWeaponsInAir())
					{
						method_12().AirOps.AttemptToRTB(ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB, GroupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, DetachFromGroup: true, ClearPlottedCourse: true);
					}
					return;
				}
				b = (byte?)bingoJokerRTB2;
				if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 3)) == true)
				{
					if (!method_12().Weaponry.IsGuidingWeaponsInAir())
					{
						method_12().AirOps.AttemptToRTB(ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB, GroupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, DetachFromGroup: true, ClearPlottedCourse: true);
					}
					return;
				}
				b = (byte?)bingoJokerRTB2;
				if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)) == true)
				{
					if (method_12().Weaponry.IsGuidingWeaponsInAir())
					{
						method_12().AirOps.AttemptToRTB(ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB, GroupMembersRTB: true, ActiveUnit._ActiveUnitStatus.RTB_Group, DetachFromGroup: false, ClearPlottedCourse: true);
						return;
					}
					if (!((method_12().Navigator.HasFlightPlan && method_12().IsOnActivePatrol()) & myUnit.Navigator.IsInsidePatrolArea))
					{
						method_12().AirOps.AttemptToRTB(ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB, GroupMembersRTB: true, ActiveUnit._ActiveUnitStatus.RTB_Group, DetachFromGroup: false, ClearPlottedCourse: true);
						return;
					}
					Aircraft_Navigator navigator9 = method_12().Navigator;
					Waypoint[] theArray2 = navigator9.PlottedCourse;
					ArrayExtensions.Clear(ref theArray2);
					navigator9.PlottedCourse = theArray2;
					bool flag17 = false;
					theArray2 = ((ActiveUnit_Navigator)method_12().Navigator).get_Flight(HierarchySearch: true).FlightPlan;
					foreach (Waypoint waypoint5 in theArray2)
					{
						if (waypoint5.Type == Waypoint.WaypointType.StationEnd)
						{
							flag17 = true;
						}
						if (waypoint5.Latitude != 0.0 && waypoint5.Longitude != 0.0)
						{
							if (flag17)
							{
								Aircraft_Navigator navigator10 = method_12().Navigator;
								Waypoint[] theArray3 = navigator10.PlottedCourse;
								ArrayExtensions.Add(ref theArray3, waypoint5);
								navigator10.PlottedCourse = theArray3;
							}
						}
						else if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
					}
					method_12().Navigator.FollowPlottedCourse(elapsedTime);
					return;
				}
				b = (byte?)bingoJokerRTB2;
				if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) != true)
				{
					return;
				}
				bool flag18 = true;
				IEnumerator<ActiveUnit> enumerator6 = myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values.GetEnumerator();
				while (enumerator6.MoveNext())
				{
					ActiveUnit current6 = enumerator6.Current;
					int num12;
					if (current6.FuelState != ActiveUnit._ActiveUnitFuelState.None)
					{
						if (!current6.Weaponry.IsGuidingWeaponsInAir())
						{
							continue;
						}
						num12 = 0;
					}
					else
					{
						num12 = 0;
					}
					flag18 = (byte)num12 != 0;
					break;
				}
				if (flag18)
				{
					method_12().AirOps.AttemptToRTB(ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB, GroupMembersRTB: true, ActiveUnit._ActiveUnitStatus.RTB_Group, DetachFromGroup: false, ClearPlottedCourse: true);
				}
				return;
			}
			b = (byte?)method_12().Doctrine.BingoJokerRTB;
			flag2 = ((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() != 0));
			if ((MissionPlanner_PostponedRefuelling ? new bool?(false) : flag2) == true && myUnit.Navigator.HasFlightPlan && myUnit.Navigator.PlottedCourse.Count() > 0 && myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan.Where([SpecialName] (Waypoint w) => w.Type == Waypoint.WaypointType.Refuel).FirstOrDefault() == null && (myUnit.Navigator.IsOnAutoPlannerPlottedCourse_OnStation || myUnit.Navigator.IsOnAutoPlannerPlottedCourse_StationIngressRun || (myUnit.Navigator.HasFlight && myUnit.Navigator.get_Flight(HierarchySearch: true).get_Status(myUnit.ParentScen) != Mission._FlightStatus.Airborne_EgressLeg && ((!Information.IsNothing((object)mission) && (mission.MissionClass == Mission._MissionClass.Patrol || mission.MissionClass == Mission._MissionClass.Support)) || myUnit.AI.IsEscort))))
			{
				myUnit.Navigator.EgressToRejoinPoint(elapsedTime, ForceObjectiveWaypointRemoval: false);
				myUnit.Status = ActiveUnit._ActiveUnitStatus.RTB_CalledOff;
				return;
			}
		}
		goto IL_2369;
		IL_2369:
		if (myUnit.IsRTB_Or_CalledOff && airOps.Condition != Aircraft_AirOps._AirOpsCondition.EmergencyLanding && airOps.Condition != Aircraft_AirOps._AirOpsCondition.HoldingOnLandingQueue && method_12().FuelState_Destination != null && !method_12().FuelState_Destination.IsAircraft)
		{
			float num13 = (float)method_12().get_FuelEndurance(method_12().ThrottleSetting, (AltBand)null, (float?)method_12().DesiredSpeed, (float?)method_12().DesiredAltitude) * method_12().DesiredSpeed / 3600f;
			if (method_12().FuelState_DistanceToBase > Aircraft.EMERGENCY_LANDING_DISTANCE_NM && method_12().FuelState_DistanceToBase > num13 && method_12().DivertForEmergencyLanding())
			{
				return;
			}
		}
		goto IL_2452;
		IL_6956:
		bool? obj7;
		flag10 = (bool?)obj7;
		flag16 = (bool?)obj7;
		flag2 = ((flag16.HasValue && flag10 != true) ? new bool?(false) : (myUnit.IsGroupMember() & flag10));
		if ((flag2 ?? true) && myUnit.get_ParentGroup(UsingMissionPlanner: false).IsFormingUp && flag2.HasValue)
		{
			myUnit.Status = ActiveUnit._ActiveUnitStatus.FormingUp;
		}
		else if (mission != null && mission.MissionClass == Mission._MissionClass.Strike && ((Strike)mission).SpecificTargets.Count == 0)
		{
			myUnit.Status = ActiveUnit._ActiveUnitStatus.RTB_MissionOver;
			myUnit.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
		}
		else if (method_12().AirOps.Condition != Aircraft_AirOps._AirOpsCondition.ManoeuveringToRefuel && method_12().AirOps.A2AR_Destination == null)
		{
			if (method_12().IsGroupMember() && ((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).IsPerformingStandoffAttack)
			{
				myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
			}
			else
			{
				myUnit.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
			}
		}
		else
		{
			myUnit.Status = ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint;
		}
		return;
		IL_2452:
		if (method_12().Navigator.HasPlottedCourse())
		{
			if (method_12().ParentScen.MinuteIsChangingOnThisPulse)
			{
				if (myUnit.Navigator.IsOnAutoPlannerPlottedCourse_CruiseAndAttackIngressRun)
				{
					float num14;
					if (mission != null)
					{
						num14 = ((mission.FuelQtyToStartLookingForTanker_Airborne <= 0) ? 0f : ((float)((double)mission.FuelQtyToStartLookingForTanker_Airborne / 100.0)));
					}
					else
					{
						num14 = myUnit.Doctrine.GetBingoThreshold(myUnit) * 1.25f;
						if ((double)num14 > 0.85)
						{
							num14 = 0.85f;
						}
					}
					method_15(num14, myUnit.Doctrine.get_ReplenishmentSelection(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false).Value);
				}
				else
				{
					Waypoint obj8 = method_12().Navigator.PlottedCourse[0];
					if (obj8 != null && obj8.Type == Waypoint.WaypointType.PatrolStation)
					{
						float num15 = ((mission == null) ? myUnit.Doctrine.GetBingoThreshold(myUnit) : ((mission.FuelQtyToStartLookingForTanker_Airborne <= 0) ? 0f : ((float)((double)mission.FuelQtyToStartLookingForTanker_Airborne / 100.0))));
						if (num15 > 0f)
						{
							method_15(num15, myUnit.Doctrine.get_ReplenishmentSelection(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false).Value);
						}
					}
					else
					{
						method_15(myUnit.Doctrine.GetBingoThreshold(myUnit), myUnit.Doctrine.get_ReplenishmentSelection(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false).Value);
					}
				}
			}
		}
		else if (((ActiveUnit)method_12()).IsRTB)
		{
			ActiveUnit actualDestinationHost3 = method_12().AirOps.ActualDestinationHost;
			if (method_12().get_IsBingoTowardsThisDestination(actualDestinationHost3, (GeoPoint)null, method_12().Doctrine.BingoJoker) == ActiveUnit._ActiveUnitFuelState.IsBingo)
			{
				method_15(myUnit.Doctrine.GetBingoThreshold(myUnit), myUnit.Doctrine.get_ReplenishmentSelection(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false).Value);
			}
		}
		else if (myUnit.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint && myUnit.Status != ActiveUnit._ActiveUnitStatus.Refuelling)
		{
			method_15(myUnit.Doctrine.GetBingoThreshold(myUnit), myUnit.Doctrine.get_ReplenishmentSelection(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false).Value);
		}
		if (IsEscort && myUnit.IsRTB)
		{
			bool flag19 = false;
			bool flag20 = false;
			if (mission != null && mission.MissionClass == Mission._MissionClass.Strike)
			{
				PooledList<ActiveUnit> pooledList = new PooledList<ActiveUnit>(myUnit.get_UnitSide(SetSideOnly: false).Units);
				PooledList<ActiveUnit>.Enumerator enumerator7 = pooledList.GetEnumerator();
				while (enumerator7.MoveNext())
				{
					ActiveUnit current7 = enumerator7.Current;
					if (current7.IsGroup)
					{
						continue;
					}
					Mission mission4 = current7.ActiveMissionOrPackage();
					if (mission4 == null || mission4 != mission)
					{
						continue;
					}
					if (!current7.IsOperating())
					{
						if (!current7.AI.IsEscort)
						{
							Aircraft_AirOps airOps2 = ((Aircraft)current7).AirOps;
							if (airOps2.Condition != Aircraft_AirOps._AirOpsCondition.Readying && airOps2.Condition != Aircraft_AirOps._AirOpsCondition.TaxyingToPark && airOps2.Condition != Aircraft_AirOps._AirOpsCondition.Landing_PostTouchdown && airOps2.Condition != Aircraft_AirOps._AirOpsCondition.TaxyingToFlightDeck)
							{
								flag20 = true;
							}
						}
					}
					else if (!current7.AI.IsEscort)
					{
						flag19 = true;
						break;
					}
				}
				pooledList.Dispose();
			}
			if (!flag20 && !flag19)
			{
				myUnit.Status = ActiveUnit._ActiveUnitStatus.RTB_MissionOver;
				this.ReturnToBase(elapsedTime);
			}
		}
		goto IL_2820;
		IL_3957:
		if (!myUnit.IsRTB && myUnit.IsOnActiveStrike)
		{
			Strike strike = (Strike)myUnit.AssignedMissionOrPackage();
			if (strike.Type != Strike.StrikeType.Air_Intercept && !strike.get_FocusEntirelyOnStrikeTargets(myUnit) && (strike.SpecificTargets == null || strike.TargetCount == 0))
			{
				PrimaryTarget = null;
				bool flag21 = myUnit.FollowingPCThatIsRTB || method_12().FollowingPCThatIsPathfinderGeneratedAndLeadsToAssignedHost;
				int num16;
				if (myUnit.Navigator.PathFindingInProgress)
				{
					num16 = 1;
				}
				else
				{
					ActiveUnit theUnit2 = myUnit;
					Exception ThrownError = null;
					num16 = (Pathfinding.UnitOrFlightPlanHasPFRequestInQueue(theUnit2, null, ref ThrownError) ? 1 : 0);
				}
				bool flag22 = (byte)num16 != 0;
				if (strike.RTB_When_Target_Destroyed)
				{
					myUnit.Status = ActiveUnit._ActiveUnitStatus.RTB_MissionOver;
					myUnit.Navigator.ResetTimeToNextPathfinderCheck();
					return;
				}
				if (myUnit.Navigator.HasPlottedCourse() && !flag21 && !flag22)
				{
					myUnit.Navigator.ClearPlottedCourse();
				}
			}
		}
		if (myUnit.IsRTB)
		{
			return;
		}
		if (myUnit.AI.PrimaryTarget == null && airOps.Condition == Aircraft_AirOps._AirOpsCondition.const_19)
		{
			airOps.Condition = Aircraft_AirOps._AirOpsCondition.Airborne;
			myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
		}
		if (PrimaryTarget == null && !myUnit.AI.IsEscort && mission != null && mission.MissionClass == Mission._MissionClass.Strike)
		{
			Strike strike2 = (Strike)mission;
			if (strike2.SpecificTargets != null && strike2.SpecificTargets.Count > 0)
			{
				HashSet<Module_Unit.Unit>.Enumerator enumerator8 = strike2.SpecificTargets.GetEnumerator();
				while (enumerator8.MoveNext())
				{
					Module_Unit.Unit current8 = enumerator8.Current;
					if (PrimaryTarget == null)
					{
						Contact contactForThisUnit = GetContactForThisUnit(current8);
						if (contactForThisUnit != null)
						{
							PrimaryTarget = contactForThisUnit;
							break;
						}
						continue;
					}
					break;
				}
			}
		}
		if (!myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
		{
			if (myUnit.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint && myUnit.Status != ActiveUnit._ActiveUnitStatus.Refuelling)
			{
				Weapon weapon = null;
				Aircraft aircraft3 = ((!method_12().IsGroupWingman()) ? method_12() : ((Aircraft)((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).GroupLead));
				if (aircraft3 != null)
				{
					Aircraft_Navigator navigator11 = aircraft3.Navigator;
					if (navigator11 != null && navigator11.HasFlightPlan)
					{
						Waypoint[] flightPlan = ((ActiveUnit_Navigator)aircraft3.Navigator).get_Flight(HierarchySearch: true).FlightPlan;
						foreach (Waypoint waypoint6 in flightPlan)
						{
							if (waypoint6.ReferenceWeapon_ID != 0)
							{
								weapon = method_17(waypoint6.ReferenceWeapon_ID);
								break;
							}
						}
						if (mission != null)
						{
							flag2 = ((weapon != null) ? new bool?(false) : ((mission == null) ? ((bool?)null) : new bool?(mission.MissionClass == Mission._MissionClass.Strike)));
							if (flag2 ?? true)
							{
								HashSet<Module_Unit.Unit> specificTargets = ((Strike)mission).SpecificTargets;
								if (specificTargets != null && specificTargets.Count > 0 && flag2.HasValue)
								{
									Module_Unit.Unit u = ((Strike)mission).SpecificTargets.ElementAtOrDefault(0);
									Contact contactForThisUnit2 = GetContactForThisUnit(u);
									if (contactForThisUnit2 != null)
									{
										weapon = myUnit.Weaponry.MostSuitableWeaponForThisTarget(contactForThisUnit2, CheckIfWithinRange: false, CheckIfWithinAltitude: false, CheckWRA: true, myUnit.Doctrine);
									}
								}
							}
						}
					}
				}
				if (myUnit.Status == ActiveUnit._ActiveUnitStatus.Manual_Unassigned)
				{
					return;
				}
				b = (byte?)myUnit.Doctrine.WinchesterShotgunRTB;
				flag16 = (flag10 = ((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() != 0)));
				flag2 = ((flag16.HasValue && flag10 != true) ? new bool?(false) : ((myUnit.Weaponry.IsWinchesterOrShotgun() == ActiveUnit._ActiveUnitWeaponState.IsWinchester) & flag10));
				if ((flag2 ?? true) && !NeedToCrank() && flag2.HasValue)
				{
					bool flag23 = true;
					if (myUnit.IsGroupMember())
					{
						b = (byte?)myUnit.Doctrine.WinchesterShotgunRTB;
						if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
						{
							IEnumerator<ActiveUnit> enumerator9 = myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values.GetEnumerator();
							while (enumerator9.MoveNext())
							{
								ActiveUnit current9 = enumerator9.Current;
								if (!current9.IsRTB && current9.Weaponry.IsWinchesterOrShotgun() != ActiveUnit._ActiveUnitWeaponState.IsWinchester)
								{
									flag23 = false;
									break;
								}
							}
						}
					}
					if (flag23)
					{
						weapon = null;
						if (myUnit.AI.PrimaryTarget != null && ((TargetingBehaviorForThisTarget(myUnit.AI.PrimaryTarget, null) == TargetingEntry._TargetingBehavior.ManualTargeted) | (TargetingBehaviorForThisTarget(myUnit.AI.PrimaryTarget, null) == TargetingEntry._TargetingBehavior.ManualWeaponAlloc)))
						{
							myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
						}
						else if (!myUnit.FollowingPCThatIsRTB)
						{
							if (!myUnit.IsGroupWingman())
							{
								myUnit.AI.ReturnToBase(elapsedTime);
							}
							else if (myUnit.AssignedMissionOrPackage() == null)
							{
								myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
							}
							else if (myUnit.Navigator.HasPlottedCourse() && myUnit.FollowingPCThatIsRTB)
							{
								myUnit.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
							}
							else
							{
								myUnit.Status = ActiveUnit._ActiveUnitStatus.Tasked;
							}
						}
						else
						{
							myUnit.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
							myUnit.Navigator.FollowPlottedCourse(elapsedTime);
						}
						return;
					}
				}
				bool flag24 = true;
				if (weapon != null)
				{
					if (mission != null && mission.MissionClass == Mission._MissionClass.Strike)
					{
						HashSet<Module_Unit.Unit>.Enumerator enumerator10 = ((Strike)mission).SpecificTargets.GetEnumerator();
						while (enumerator10.MoveNext())
						{
							Module_Unit.Unit current10 = enumerator10.Current;
							Contact contactForThisUnit3 = GetContactForThisUnit(current10);
							if (contactForThisUnit3 == null || myUnit.Weaponry.MostSuitableWeaponForThisTarget(contactForThisUnit3, CheckIfWithinRange: false, CheckIfWithinAltitude: false, CheckWRA: true, myUnit.Doctrine) == null || myUnit.get_UnitSide(SetSideOnly: false).WRAQuantityRemainingForWeaponVsTarget_ExistingSalvos(myUnit, contactForThisUnit3, weapon) <= 0)
							{
								continue;
							}
							flag24 = false;
							break;
						}
					}
				}
				else
				{
					flag24 = false;
				}
				if (mission != null)
				{
					if (flag24 && mission.MissionClass == Mission._MissionClass.Strike && !((Strike)mission).RTB_When_Target_Destroyed && !method_12().Navigator.HasFlightPlan)
					{
						flag24 = false;
					}
					if (flag24)
					{
						if (method_12().Navigator.FollowingRTB_FlightPlan())
						{
							method_12().Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
							if (((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false) != null && !method_12().IsGroupLead())
							{
								if (method_12().IsGroupWingman())
								{
									method_12().Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
								}
							}
							else
							{
								method_12().Navigator.FollowPlottedCourse(elapsedTime);
							}
						}
						else if (!method_12().Navigator.HasPlottedCourse())
						{
							method_12().Status = ActiveUnit._ActiveUnitStatus.RTB_MissionOver;
							this.ReturnToBase(elapsedTime);
						}
						else
						{
							method_12().Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
							method_12().Navigator.FollowPlottedCourse(elapsedTime);
						}
						return;
					}
				}
			}
			if (myUnit.IsGroupWingman() && !Information.IsNothing((object)myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead))
			{
				if (myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint)
				{
					if (myUnit.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint)
					{
						myUnit.Status = ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint;
					}
					return;
				}
				if (myUnit.Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint && myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint && myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Status != ActiveUnit._ActiveUnitStatus.Refuelling)
				{
					myUnit.Status = myUnit._StatusBefore_NeedToRefuel;
				}
				else if (myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Status == ActiveUnit._ActiveUnitStatus.Refuelling)
				{
					if (myUnit.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint || myUnit.Status != ActiveUnit._ActiveUnitStatus.Refuelling)
					{
						ActiveUnit activeUnit4 = myUnit;
						double TotalCurrent = 0.0;
						double TotalMax = 0.0;
						if (activeUnit4.FuelPercent(ref TotalCurrent, ref TotalMax, MissionFuel: false) < 0.95)
						{
							myUnit.Status = ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint;
						}
					}
					return;
				}
			}
			if (myUnit.IsGroupMember())
			{
				if (myUnit.get_ParentGroup(UsingMissionPlanner: false).Type == Group.GroupType.AirGroup && myUnit.get_ParentGroup(UsingMissionPlanner: false).IsFormingUp)
				{
					myUnit.Status = ActiveUnit._ActiveUnitStatus.FormingUp;
					return;
				}
				if (myUnit.Status == ActiveUnit._ActiveUnitStatus.FormingUp)
				{
					EvaluateTargets(elapsedTime, IgnoreContacStance: false, Immediately: true);
				}
			}
			if (mission != null && myUnit.Status != ActiveUnit._ActiveUnitStatus.RTB_MissionOver && mission.IsActive)
			{
				bool flag30;
				ActiveUnit actualDestinationHost4;
				HashSet<Module_Unit.Unit> targetsFromFlightPlan;
				_Closure$__32-0 CS$<>8__locals11;
				Contact contact = default(Contact);
				List<Contact> list3;
				bool flag28;
				bool? flag29;
				switch (mission.MissionClass)
				{
				case Mission._MissionClass.Strike:
					if (myUnit.Status != ActiveUnit._ActiveUnitStatus.RTB_CalledOff)
					{
						flag30 = true;
						if (myUnit.AI.IsEscort)
						{
							if (!myUnit.get_UnitSide(SetSideOnly: false).Cache_UnitsAssignedToMissionOrPackage.TryGetValue(mission, out var value6))
							{
								value6 = Module_Mission.UnitsAssignedToMissionOrPackage(mission, myUnit.ParentScen);
								myUnit.get_UnitSide(SetSideOnly: false).Cache_UnitsAssignedToMissionOrPackage.AddIfNotExists(mission, value6);
							}
							List<ActiveUnit>.Enumerator enumerator15 = value6.GetEnumerator();
							while (enumerator15.MoveNext())
							{
								ActiveUnit current14 = enumerator15.Current;
								if (current14 != null && !current14.IsMorituri && !current14.IsGroup && !current14.AI.IsEscort)
								{
									flag30 = false;
									break;
								}
							}
						}
						else
						{
							if (((Strike)mission).SpecificTargets != null && ((Strike)mission).TargetCount > 0)
							{
								goto IL_43f3;
							}
							if (_TargetList != null)
							{
								ObservableDictionary<string, TargetingEntry> targetList = _TargetList;
								if (targetList != null && targetList.Count > 0)
								{
									goto IL_43f3;
								}
							}
						}
						goto IL_43f8;
					}
					goto IL_518f;
				case Mission._MissionClass.Patrol:
				{
					b = (byte?)myUnit.Doctrine.get_IgnorePlottedCourse(myUnit.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false);
					bool value4 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)).Value;
					bool flag25 = myUnit.Status == ActiveUnit._ActiveUnitStatus.EngagedOffensive && value4;
					if ((myUnit.Status != ActiveUnit._ActiveUnitStatus.RTB_Exhaustion) & (myUnit.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint) & (myUnit.Status != ActiveUnit._ActiveUnitStatus.Refuelling))
					{
						if (myUnit.Status != ActiveUnit._ActiveUnitStatus.RTB_CalledOff && (flag25 || (!myUnit.Navigator.HasPathfindingPlottedCourse && !myUnit.Navigator.HasFlightPlan)))
						{
							List<Weapon> list2 = myUnit.Weaponry.IsGuidingWeaponsInAir_List();
							bool flag26 = false;
							List<Weapon>.Enumerator enumerator11 = list2.GetEnumerator();
							while (enumerator11.MoveNext())
							{
								Weapon current11 = enumerator11.Current;
								if (current11.AI.PrimaryTarget != null)
								{
									Contact primaryTarget = current11.AI.PrimaryTarget;
									Doctrine._UseShootTourists? canShootTourists = myUnit.Doctrine.get_ShootTourists(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
									UserFeedback = "";
									int FeedbackSeverity = 0;
									if (ContactIsRelevantToFlightOrMission(primaryTarget, mission, canShootTourists, IgnoreContacStance: false, isInsidePatrolArea_10nmBuffer, IgnoreNeutralContacts: true, null, ref UserFeedback, ref FeedbackSeverity))
									{
										myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
										flag26 = true;
										break;
									}
								}
							}
							if (!flag26)
							{
								if (PrimaryTarget != null)
								{
									Contact primaryTarget2 = PrimaryTarget;
									Doctrine._UseShootTourists? canShootTourists2 = myUnit.Doctrine.get_ShootTourists(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
									UserFeedback = "";
									int FeedbackSeverity = 0;
									if (ContactIsRelevantToFlightOrMission(primaryTarget2, mission, canShootTourists2, IgnoreContacStance: false, isInsidePatrolArea_10nmBuffer, IgnoreNeutralContacts: true, null, ref UserFeedback, ref FeedbackSeverity) || myUnit.AI.TargetingBehaviorForThisTarget(myUnit.AI.PrimaryTarget, null) == TargetingEntry._TargetingBehavior.ManualTargeted)
									{
										ActiveUnit_Weaponry weaponry = myUnit.Weaponry;
										Contact primaryTarget3 = PrimaryTarget;
										Doctrine doctrine3 = myUnit.Doctrine;
										UserFeedback = string.Empty;
										FeedbackSeverity = 0;
										if (weaponry.HaveAvailableWeaponSuitableForThisTarget(primaryTarget3, CheckWRA: true, doctrine3, ref UserFeedback, ref FeedbackSeverity, HumanFeedBackNeeded: false))
										{
											myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
										}
										else if (!myUnit.IsPaintingATarget && !myUnit.WillNeedToPaintATarget && !NeedToCrank())
										{
											if (myUnit.get_ParentGroup(UsingMissionPlanner: false) != null && myUnit.get_ParentGroup(UsingMissionPlanner: false).IsPerformingStandoffAttack)
											{
												myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
											}
											else if (PrimaryTarget.IDStatus < Contact_Base.IdentificationStatus.KnownClass)
											{
												myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
											}
											else
											{
												myUnit.Status = ActiveUnit._ActiveUnitStatus.OnPatrol;
											}
										}
										else
										{
											myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
										}
										goto IL_594f;
									}
								}
								myUnit.Status = ActiveUnit._ActiveUnitStatus.OnPatrol;
							}
						}
						else
						{
							if (method_12().WeaponState != ActiveUnit._ActiveUnitWeaponState.IgnoreWinchesterAndShotgun && method_12().Weaponry.IsWinchesterOrShotgun() == ActiveUnit._ActiveUnitWeaponState.IsWinchester)
							{
								if (myUnit.FollowingPCThatIsRTB)
								{
									return;
								}
								bool flag27 = false;
								ActiveUnit activeUnit5 = null;
								b = (byte?)myUnit.Doctrine.WinchesterShotgunRTB;
								if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)) == true)
								{
									flag27 = true;
								}
								else
								{
									b = (byte?)myUnit.Doctrine.WinchesterShotgunRTB;
									if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
									{
										flag27 = true;
										if (myUnit.get_ParentGroup(UsingMissionPlanner: false) != null)
										{
											IEnumerator<KeyValuePair<string, ActiveUnit>> enumerator12 = myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.GetEnumerator();
											while (enumerator12.MoveNext())
											{
												ActiveUnit value5 = enumerator12.Current.Value;
												if (!value5.IsRTB && value5.WeaponState != ActiveUnit._ActiveUnitWeaponState.IsWinchester)
												{
													activeUnit5 = value5;
													flag27 = false;
													break;
												}
											}
										}
									}
								}
								if (flag27)
								{
									myUnit.AirOps.AttemptToRTB(ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB, GroupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, DetachFromGroup: true, ClearPlottedCourse: true);
								}
								else if (!myUnit.IsGroupWingman())
								{
									if (!myUnit.Navigator.HasPlottedCourse())
									{
										if (myUnit.IsGroupLead() && activeUnit5 != null)
										{
											myUnit.get_ParentGroup(UsingMissionPlanner: false).DesignateGroupLead_Manual(activeUnit5);
											myUnit.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
										}
										else
										{
											method_12().Kinematics.Loiter(elapsedTime);
										}
									}
									else
									{
										myUnit.Navigator.FollowPlottedCourse(elapsedTime);
									}
								}
								else
								{
									myUnit.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
								}
								return;
							}
							if (myUnit.Navigator.HasFlightPlan)
							{
								if (myUnit.Status == ActiveUnit._ActiveUnitStatus.OnPatrol)
								{
									if (myUnit.AI.PrimaryTarget == null)
									{
										if (myUnit.TargetsEvaluatedOnThisPulse)
										{
											myUnit.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
											myUnit.Navigator.FollowPlottedCourse(elapsedTime);
										}
									}
									else
									{
										myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
									}
								}
								else if (!myUnit.IsRTB)
								{
									if (PrimaryTarget == null && myUnit.IsGroupWingman() && myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.AI.PrimaryTarget != null)
									{
										PrimaryTarget = myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.AI.PrimaryTarget;
									}
									if (myUnit.AssignedMissionOrPackage() != null && myUnit.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol && !myUnit.Navigator.IsInsidePatrolArea)
									{
										myUnit.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
										myUnit.Navigator.FollowPlottedCourse(elapsedTime);
									}
									else if (PrimaryTarget != null && !myUnit.IsRTB)
									{
										myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
									}
									else
									{
										myUnit.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
										myUnit.Navigator.FollowPlottedCourse(elapsedTime);
									}
								}
							}
						}
					}
					goto IL_594f;
				}
				case Mission._MissionClass.Support:
					if (myUnit.Status != ActiveUnit._ActiveUnitStatus.RTB_CalledOff)
					{
						if (PrimaryTarget != null)
						{
							if (TargetingBehaviorForThisTarget(PrimaryTarget, null) != TargetingEntry._TargetingBehavior.ManualTargeted)
							{
								b = (byte?)myUnit.Doctrine.get_ShootTourists(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
								if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) != true)
								{
									goto IL_5a66;
								}
							}
							myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
							return;
						}
						goto IL_5a66;
					}
					goto IL_5ad2;
				case Mission._MissionClass.Ferry:
					if (myUnit.Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint)
					{
						return;
					}
					if (PrimaryTarget != null)
					{
						if (TargetingBehaviorForThisTarget(PrimaryTarget, null) != TargetingEntry._TargetingBehavior.ManualTargeted)
						{
							b = (byte?)myUnit.Doctrine.get_ShootTourists(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
							if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) != true)
							{
								goto IL_5bed;
							}
						}
						myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
						return;
					}
					goto IL_5bed;
				case Mission._MissionClass.Mining:
					myUnit.Status = ActiveUnit._ActiveUnitStatus.Tasked;
					return;
				case Mission._MissionClass.MineClearing:
					myUnit.Status = ActiveUnit._ActiveUnitStatus.Tasked;
					return;
				case Mission._MissionClass.Cargo:
					{
						if (myUnit.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint && myUnit.Status != ActiveUnit._ActiveUnitStatus.Refuelling)
						{
							myUnit.Status = ActiveUnit._ActiveUnitStatus.Tasked;
							return;
						}
						break;
					}
					IL_594f:
					if (myUnit.ParentScen.MinuteIsChangingOnThisPulse && mission.FuelQtyToStartLookingForTanker_Airborne > 0)
					{
						method_15((float)((double)mission.FuelQtyToStartLookingForTanker_Airborne / 100.0), myUnit.Doctrine.get_ReplenishmentSelection(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false).Value);
					}
					return;
					IL_5bed:
					actualDestinationHost4 = method_12().AirOps.ActualDestinationHost;
					if (!method_12().Navigator.HasReachedLandingAssemblyPoint(actualDestinationHost4))
					{
						myUnit.Status = ActiveUnit._ActiveUnitStatus.OnFerryMission;
						if (!myUnit.Navigator.HasPlottedCourse())
						{
							ActiveUnit._ActiveUnitStatus activeUnitStatus_ = ActiveUnit._ActiveUnitStatus.RTB;
							if (method_12().AirOps.ActualDestinationHost != null && Operators.CompareString(method_12().AirOps.ActualDestinationHost.ObjectID, ((FerryMission)myUnit.AssignedMissionOrPackage()).get_NominalDestinationHost(method_12().ParentScen)?.ObjectID, false) == 0)
							{
								activeUnitStatus_ = myUnit.Status;
							}
							else
							{
								method_12().AirOps.AttemptToRTB(ManuallyOrdered: false, activeUnitStatus_, GroupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, DetachFromGroup: true, ClearPlottedCourse: true);
							}
						}
						else
						{
							myUnit.Navigator.FollowPlottedCourse(elapsedTime);
						}
					}
					else if (!method_12().Weaponry.IsGuidingWeaponsInAir())
					{
						method_12().AirOps.AttemptToRTB(ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB, GroupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, DetachFromGroup: true, ClearPlottedCourse: true);
					}
					return;
					IL_5ad2:
					if (myUnit.ParentScen.MinuteIsChangingOnThisPulse && mission.FuelQtyToStartLookingForTanker_Airborne > 0)
					{
						method_15((float)((double)mission.FuelQtyToStartLookingForTanker_Airborne / 100.0), myUnit.Doctrine.get_ReplenishmentSelection(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false).Value);
					}
					return;
					IL_4753:
					if (!flag28 && targetsFromFlightPlan != null)
					{
						HashSet<Module_Unit.Unit>.Enumerator enumerator13 = targetsFromFlightPlan.GetEnumerator();
						while (enumerator13.MoveNext())
						{
							Module_Unit.Unit current12 = enumerator13.Current;
							Contact contactForThisUnit4 = GetContactForThisUnit(current12);
							if (contactForThisUnit4 != null && (flag28 = KeepOnEngagingTheTarget(contactForThisUnit4, CS$<>8__locals11.$VB$Local_theStrikeMission)))
							{
								contact = contactForThisUnit4;
								break;
							}
						}
					}
					if (!flag28)
					{
						List<Contact>.Enumerator enumerator14 = list3.GetEnumerator();
						while (enumerator14.MoveNext())
						{
							Contact current13 = enumerator14.Current;
							if (flag28 = KeepOnEngagingTheTarget(current13, CS$<>8__locals11.$VB$Local_theStrikeMission))
							{
								contact = current13;
								break;
							}
						}
					}
					b = (byte?)myUnit.Doctrine.WinchesterShotgunRTB;
					flag10 = ((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() != 0));
					flag2 = ((myUnit.Doctrine.WinchesterShotgunRTB.Value != Doctrine._WeaponStateRTB.YesLastUnit) ? flag10 : new bool?(false));
					flag29 = ((myUnit.Doctrine.WinchesterShotgunRTB.Value != Doctrine._WeaponStateRTB.YesLeaveGroup) ? flag2 : new bool?(false));
					flag9 = (flag16 = flag29);
					flag16 = (flag10 = ((flag9.HasValue && flag16 != true) ? new bool?(false) : ((contact != null) & flag16)));
					flag2 = ((flag16.HasValue && flag10 != true) ? new bool?(false) : ((CS$<>8__locals11.$VB$Local_theStrikeMission.SpecificTargets.Count != 0) ? new bool?(false) : flag10));
					if ((flag2 ?? true) && !myUnit.FollowingPCThatIsRTB && flag2.HasValue)
					{
						method_12().AirOps.AttemptToRTB(ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB, GroupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, DetachFromGroup: true, ClearPlottedCourse: true);
					}
					else if (contact != null)
					{
						method_12().Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
						method_12().AI.PrimaryTarget = contact;
						if (method_12().isUAV && method_12().isSuicide())
						{
							((ActiveUnit_Navigator)method_12().Navigator).get_Flight(HierarchySearch: true).ClearFlightPlan();
							method_12().AI.EngageTargets(elapsedTime);
						}
					}
					else
					{
						if (method_12().Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint || method_12().Status == ActiveUnit._ActiveUnitStatus.Refuelling)
						{
							return;
						}
						if (!method_12().Navigator.HasPlottedCourse())
						{
							if (method_12().AI.PrimaryTarget != null && !method_12().AssignedMissionOrPackage().HasFlightPlans())
							{
								method_12().Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
							}
							else
							{
								method_12().Status = ActiveUnit._ActiveUnitStatus.Tasked;
							}
						}
						else
						{
							method_12().Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
						}
					}
					return;
					IL_43f3:
					flag30 = false;
					goto IL_43f8;
					IL_518f:
					if (myUnit.ParentScen.MinuteIsChangingOnThisPulse && mission.FuelQtyToStartLookingForTanker_Airborne > 0)
					{
						method_15((float)((double)mission.FuelQtyToStartLookingForTanker_Airborne / 100.0), myUnit.Doctrine.get_ReplenishmentSelection(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false).Value);
					}
					if (myUnit.Navigator.HasPlottedCourse())
					{
						Waypoint waypoint7 = method_12().Navigator.PlottedCourse?.First();
						if (method_12().isSuicide() && waypoint7 != null && waypoint7.Type == Waypoint.WaypointType.Target)
						{
							method_12().Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
						}
					}
					return;
					IL_5a66:
					if (myUnit.Navigator.IsFinishingSupportMissionCourse(elapsedTime))
					{
						if (!method_12().Weaponry.IsGuidingWeaponsInAir())
						{
							method_12().AirOps.AttemptToRTB(ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB_Manual, GroupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, DetachFromGroup: false, ClearPlottedCourse: true);
						}
					}
					else if (myUnit.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint && myUnit.Status != ActiveUnit._ActiveUnitStatus.Refuelling)
					{
						myUnit.Status = ActiveUnit._ActiveUnitStatus.OnSupportMission;
					}
					goto IL_5ad2;
					IL_43f8:
					if (!flag30)
					{
						if (!IsEscort)
						{
							if (!flag)
							{
								_Closure$__32-0 arg = default(_Closure$__32-0);
								CS$<>8__locals11 = new _Closure$__32-0(arg);
								CS$<>8__locals11.$VB$Local_theStrikeMission = (Strike)mission;
								if (CS$<>8__locals11.$VB$Local_theStrikeMission.TargetCount > 0)
								{
									List<Contact> list4 = new List<Contact>();
									list4.AddRange(base.Targets_ReadOnly);
									HashSet<Module_Unit.Unit>.Enumerator enumerator16 = CS$<>8__locals11.$VB$Local_theStrikeMission.SpecificTargets.GetEnumerator();
									while (enumerator16.MoveNext())
									{
										Module_Unit.Unit current15 = enumerator16.Current;
										Contact contactForThisUnit5 = GetContactForThisUnit(current15);
										if (contactForThisUnit5 != null)
										{
											list4.Add(contactForThisUnit5);
										}
									}
									if (list4.Where([SpecialName] (Contact theC) => theC.get_IsSpecificTargetForThisStrike(CS$<>8__locals11.$VB$Local_theStrikeMission)).ToList().Count == 0)
									{
										myUnit.Status = ActiveUnit._ActiveUnitStatus.RTB_MissionOver;
										return;
									}
								}
								else
								{
									if (CS$<>8__locals11.$VB$Local_theStrikeMission.RTB_When_Target_Destroyed && CS$<>8__locals11.$VB$Local_theStrikeMission.TargetCount == 0)
									{
										myUnit.Status = ActiveUnit._ActiveUnitStatus.RTB_MissionOver;
										return;
									}
									if (PrimaryTarget != null && myUnit.ParentScen.SecondIsChangingOnThisPulse)
									{
										bool flag31 = false;
										Doctrine._UseShootTourists? canShootTourists3 = myUnit.Doctrine.get_ShootTourists(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
										Contact primaryTarget4 = PrimaryTarget;
										UserFeedback = "";
										int FeedbackSeverity = 0;
										if (!ContactIsRelevantToFlightOrMission(primaryTarget4, mission, canShootTourists3, IgnoreContacStance: true, isInsidePatrolArea_10nmBuffer, IgnoreNeutralContacts: true, null, ref UserFeedback, ref FeedbackSeverity))
										{
											List<Contact> list5 = base.Targets_ReadOnly.ToList();
											List<Contact>.Enumerator enumerator17 = list5.GetEnumerator();
											while (enumerator17.MoveNext())
											{
												Contact current16 = enumerator17.Current;
												UserFeedback = "";
												FeedbackSeverity = 0;
												if (ContactIsRelevantToFlightOrMission(current16, mission, canShootTourists3, IgnoreContacStance: true, isInsidePatrolArea_10nmBuffer, IgnoreNeutralContacts: true, null, ref UserFeedback, ref FeedbackSeverity))
												{
													flag31 = true;
													break;
												}
											}
										}
										else
										{
											flag31 = true;
										}
										if (!flag31)
										{
											myUnit.Status = ActiveUnit._ActiveUnitStatus.RTB_MissionOver;
											return;
										}
									}
								}
								if (method_12().Navigator.HasPlottedCourse() && myUnit.Weaponry.IsWinchesterOrShotgun() == ActiveUnit._ActiveUnitWeaponState.IsWinchester && myUnit.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint && myUnit.Status != ActiveUnit._ActiveUnitStatus.Refuelling)
								{
									myUnit.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
									return;
								}
								if (myUnit?.Navigator?.get_Flight(HierarchySearch: true) != null)
								{
									list3 = new List<Contact>();
									targetsFromFlightPlan = MissionPlanner.GetTargetsFromFlightPlan(myUnit);
									if (targetsFromFlightPlan != null)
									{
										HashSet<Module_Unit.Unit>.Enumerator enumerator18 = CS$<>8__locals11.$VB$Local_theStrikeMission.SpecificTargets.GetEnumerator();
										while (enumerator18.MoveNext())
										{
											Module_Unit.Unit current17 = enumerator18.Current;
											if (!targetsFromFlightPlan.Contains(current17))
											{
												Contact contactForThisUnit6 = GetContactForThisUnit(current17);
												if (contactForThisUnit6 != null)
												{
													list3.Add(contactForThisUnit6);
												}
											}
										}
									}
									flag28 = false;
									int num18;
									if (NeedToCrank())
									{
										num18 = 1;
									}
									else
									{
										if (PrimaryTarget == null || CS$<>8__locals11.$VB$Local_theStrikeMission.Type != Strike.StrikeType.Air_Intercept)
										{
											goto IL_4753;
										}
										num18 = 1;
									}
									flag28 = (byte)num18 != 0;
									contact = method_12().AI.PrimaryTarget;
									goto IL_4753;
								}
							}
						}
						else if (PrimaryTarget != null)
						{
							myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
						}
						else
						{
							List<Aircraft> list6 = new List<Aircraft>();
							ActiveUnit[] array = myUnit.get_UnitSide(SetSideOnly: false).Units.InternalArray();
							int num19 = myUnit.get_UnitSide(SetSideOnly: false).Units.Count - 1;
							for (int num20 = 0; num20 <= num19; num20++)
							{
								ActiveUnit activeUnit6 = array[num20];
								if (activeUnit6 == null || !activeUnit6.IsAircraft || activeUnit6 == method_12())
								{
									continue;
								}
								Mission mission5 = activeUnit6.ActiveMissionOrPackage();
								if (mission5 == null || mission5 != mission || activeUnit6.AI.IsEscort)
								{
									continue;
								}
								if (!activeUnit6.IsOperating())
								{
									if (((Aircraft)activeUnit6).AirOps.IsTakingOff | (((Aircraft)activeUnit6).AirOps.Condition == Aircraft_AirOps._AirOpsCondition.Parked))
									{
										list6.Add((Aircraft)activeUnit6);
									}
								}
								else
								{
									list6.Add((Aircraft)activeUnit6);
								}
							}
							if (myUnit.ParentScen.MinuteIsChangingOnThisPulse)
							{
								Doctrine._UnderwayRefuelAndReplenishmentSelection underwayRefuelAndReplenishmentSelection = Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround;
								bool MissionPlanner_PostponedRefuelling3 = false;
								GeoPoint geoPoint2 = null;
								if (list6 == null || ((list6.Count == 0) & !myUnit.IsRTB))
								{
									myUnit.Status = ActiveUnit._ActiveUnitStatus.RTB_MissionOver;
									return;
								}
								List<Aircraft>.Enumerator enumerator19 = list6.GetEnumerator();
								while (enumerator19.MoveNext())
								{
									Aircraft current18 = enumerator19.Current;
									if (current18.AI.IsEscort)
									{
										continue;
									}
									if (current18.IsGroupLead() || !current18.IsGroupMember())
									{
										if (current18.Navigator.IsOnAutoPlannerPlottedCourse_CruiseAndAttackIngressRun)
										{
											underwayRefuelAndReplenishmentSelection = Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveOnly;
											if (Information.IsNothing((object)geoPoint2))
											{
												geoPoint2 = current18.AI.IntermediateTargetPointForRefuelCalcs();
											}
										}
										int num21;
										if (current18.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint)
										{
											if (current18.Status != ActiveUnit._ActiveUnitStatus.Refuelling)
											{
												goto IL_4c8d;
											}
											num21 = 1;
										}
										else
										{
											num21 = 1;
										}
										MissionPlanner_PostponedRefuelling3 = (byte)num21 != 0;
									}
									goto IL_4c8d;
									IL_4c8d:
									if (MissionPlanner_PostponedRefuelling3 && underwayRefuelAndReplenishmentSelection == Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround)
									{
										break;
									}
								}
								if (MissionPlanner_PostponedRefuelling3 && method_12().Doctrine.get_UseReplenishment(method_12().ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false).Value != Doctrine._UseUnderwayRefuelAndReplenishment.Never)
								{
									GeoPoint intermediateTargetPoint2 = geoPoint2;
									Doctrine._UnderwayRefuelAndReplenishmentSelection theRefuelLogic = underwayRefuelAndReplenishmentSelection;
									CheckForMines = false;
									theSelectedTanker = null;
									theSelectedMissions = null;
									UserFeedback = "";
									CheckNoNavZones = false;
									if (airOps.AttemptToScheduleRefuel(intermediateTargetPoint2, theRefuelLogic, ref CheckForMines, IsForced: false, ref theSelectedTanker, ref theSelectedMissions, ref UserFeedback, ref CheckNoNavZones, ref MissionPlanner_PostponedRefuelling3, Aircraft_AirOps.RefuelScheduleReason.EscortedMissionStrikersAreRefueling))
									{
										return;
									}
								}
							}
							if (method_12().getEscortedUnitsLead() == null)
							{
								myUnit.Status = ActiveUnit._ActiveUnitStatus.RTB_MissionOver;
								return;
							}
							myUnit.Status = ActiveUnit._ActiveUnitStatus.Tasked;
						}
					}
					else if (IsEscort && !myUnit.Navigator.IsOnAutoPlannerPlottedCourse && (!myUnit.IsGroupWingman() || myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead == null || !myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.IsOnAutoPlannerPlottedCourse))
					{
						List<Aircraft> list7 = new List<Aircraft>();
						List<ActiveUnit> list8 = new List<ActiveUnit>(myUnit.get_UnitSide(SetSideOnly: false).Units);
						List<ActiveUnit>.Enumerator enumerator20 = list8.GetEnumerator();
						while (enumerator20.MoveNext())
						{
							ActiveUnit current19 = enumerator20.Current;
							if (!current19.IsAircraft)
							{
								continue;
							}
							Mission mission6 = current19.ActiveMissionOrPackage();
							if (mission6 == null || mission6 != mission || current19.AI.IsEscort)
							{
								continue;
							}
							if (!current19.IsOperating())
							{
								if (((Aircraft)current19).AirOps.IsTakingOff)
								{
									list7.Add((Aircraft)current19);
								}
							}
							else
							{
								list7.Add((Aircraft)current19);
							}
						}
						if (list7.Count > 0)
						{
							if (myUnit.ParentScen.MinuteIsChangingOnThisPulse)
							{
								Doctrine._UnderwayRefuelAndReplenishmentSelection underwayRefuelAndReplenishmentSelection2 = Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround;
								bool flag32 = false;
								GeoPoint geoPoint3 = null;
								List<Aircraft>.Enumerator enumerator21 = list7.GetEnumerator();
								while (enumerator21.MoveNext())
								{
									Aircraft current20 = enumerator21.Current;
									if (current20.AI.IsEscort)
									{
										continue;
									}
									if (current20.IsGroupLead() || !current20.IsGroupMember())
									{
										if (current20.Navigator.IsOnAutoPlannerPlottedCourse_CruiseAndAttackIngressRun)
										{
											underwayRefuelAndReplenishmentSelection2 = Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveOnly;
											if (Information.IsNothing((object)geoPoint3))
											{
												geoPoint3 = current20.AI.IntermediateTargetPointForRefuelCalcs();
											}
										}
										int num22;
										if (current20.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint)
										{
											if (current20.Status != ActiveUnit._ActiveUnitStatus.Refuelling)
											{
												goto IL_4ef8;
											}
											num22 = 1;
										}
										else
										{
											num22 = 1;
										}
										flag32 = (byte)num22 != 0;
									}
									goto IL_4ef8;
									IL_4ef8:
									if (flag32 && underwayRefuelAndReplenishmentSelection2 == Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround)
									{
										break;
									}
								}
								if (flag32)
								{
									float num23 = ((mission.FuelQtyToStartLookingForTanker_Airborne > 0) ? ((float)((double)mission.FuelQtyToStartLookingForTanker_Airborne / 100.0)) : 0f);
									if (method_12().Doctrine.get_UseReplenishment(method_12().ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false).Value != Doctrine._UseUnderwayRefuelAndReplenishment.Never)
									{
										bool MissionPlanner_PostponedRefuelling4 = false;
										float num24 = float.MaxValue;
										ActiveUnit activeUnit7 = myUnit;
										if (myUnit.IsGroupMember())
										{
											IEnumerator<ActiveUnit> enumerator22 = myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values.GetEnumerator();
											while (enumerator22.MoveNext())
											{
												ActiveUnit current21 = enumerator22.Current;
												if ((float)current21.FuelCapacityCurrent < num24)
												{
													num24 = current21.FuelCapacityCurrent;
													activeUnit7 = current21;
												}
											}
										}
										ActiveUnit activeUnit8 = activeUnit7;
										double TotalMax = 0.0;
										double TotalCurrent = 0.0;
										if (activeUnit8.FuelPercent(ref TotalMax, ref TotalCurrent, MissionFuel: true) < (double)num23)
										{
											GeoPoint intermediateTargetPoint3 = geoPoint3;
											Doctrine._UnderwayRefuelAndReplenishmentSelection theRefuelLogic2 = underwayRefuelAndReplenishmentSelection2;
											CheckForMines = false;
											theSelectedTanker = null;
											theSelectedMissions = null;
											UserFeedback = "";
											CheckNoNavZones = false;
											if (airOps.AttemptToScheduleRefuel(intermediateTargetPoint3, theRefuelLogic2, ref CheckForMines, IsForced: false, ref theSelectedTanker, ref theSelectedMissions, ref UserFeedback, ref CheckNoNavZones, ref MissionPlanner_PostponedRefuelling4))
											{
												return;
											}
										}
									}
								}
							}
							myUnit.Status = ActiveUnit._ActiveUnitStatus.Tasked;
							Aircraft aircraft4 = (method_12().IsGroupWingman() ? ((Aircraft)((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).GroupLead) : method_12());
							if (aircraft4.AI.IsEscort)
							{
								Mission mission7 = aircraft4.ActiveMissionOrPackage();
								if (mission7 != null)
								{
									List<Mission.Flight>.Enumerator enumerator23 = mission7.FlightList.GetEnumerator();
									while (enumerator23.MoveNext())
									{
										Mission.Flight current22 = enumerator23.Current;
										PooledList<ActiveUnit>.Enumerator enumerator24 = current22.get_Item(mission7, aircraft4.ParentScen).GetEnumerator();
										while (enumerator24.MoveNext())
										{
											if (!enumerator24.Current.AI.IsEscort)
											{
												HeadToNearestEscortSubject();
											}
										}
									}
								}
							}
						}
						else
						{
							myUnit.Status = ActiveUnit._ActiveUnitStatus.RTB_MissionOver;
						}
					}
					else if (flag)
					{
						myUnit.Status = ActiveUnit._ActiveUnitStatus.Tasked;
					}
					else if (myUnit.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint && myUnit.Status != ActiveUnit._ActiveUnitStatus.Refuelling)
					{
						if (!myUnit.Navigator.HasPlottedCourse())
						{
							myUnit.Status = ActiveUnit._ActiveUnitStatus.RTB_MissionOver;
						}
						else
						{
							myUnit.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
						}
					}
					goto IL_518f;
				}
			}
			if (PrimaryTarget == null)
			{
				if (myUnit.Status == ActiveUnit._ActiveUnitStatus.RTB_MissionOver)
				{
					return;
				}
				if (base.PrimaryPickupTarget != null && !myUnit.Navigator.HasPlottedCourse())
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
				if ((method_12().AirOps.RefuellingQueue != null && method_12().AirOps.RefuellingQueue.Count > 0) || (method_12().AirOps.Condition == Aircraft_AirOps._AirOpsCondition.OffloadingFuel && method_12().AirOps.A2AR_Connections.Count > 0))
				{
					return;
				}
				if (method_12().AssignedMissionOrPackage() == null && method_12().Status != ActiveUnit._ActiveUnitStatus.WaitForPathfinder)
				{
					method_12().Status = ActiveUnit._ActiveUnitStatus.Unassigned;
					method_12().AirOps.Condition = Aircraft_AirOps._AirOpsCondition.Airborne;
				}
				else
				{
					if (myUnit.Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint)
					{
						return;
					}
					if (method_12().Navigator.HasPlottedCourse())
					{
						method_12().Navigator.FollowPlottedCourse(elapsedTime);
					}
					else if (!method_12().AI.IsEscort)
					{
						if (method_12().IsGroupWingman() & (method_12().Status == ActiveUnit._ActiveUnitStatus.OnPlottedCourse))
						{
							method_12().Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
						}
						else if (myUnit.Status != ActiveUnit._ActiveUnitStatus.Unassigned || myUnit.ActiveMissionOrPackage() != null)
						{
							if (myUnit.Status == ActiveUnit._ActiveUnitStatus.OnPlottedCourse && myUnit.ActiveMissionOrPackage() == null)
							{
								myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
							}
							if (method_12().FollowingPCThatIsRTB)
							{
								myUnit.Navigator.FollowPlottedCourse(elapsedTime);
							}
							else
							{
								myUnit.AI.ReturnToBase(elapsedTime);
							}
						}
					}
					else
					{
						method_12().AI.HeadToNearestEscortSubject();
					}
				}
			}
			else
			{
				myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
			}
			return;
		}
		if (myUnit.Status == ActiveUnit._ActiveUnitStatus.RTB_CalledOff)
		{
			return;
		}
		if (!Information.IsNothing((object)PrimaryTarget))
		{
			b = (byte?)myUnit.Doctrine.get_IgnorePlottedCourse(myUnit.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false);
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
			{
				ActiveUnit_Weaponry weaponry2 = myUnit.Weaponry;
				Contact primaryTarget5 = PrimaryTarget;
				Doctrine doctrine4 = myUnit.Doctrine;
				UserFeedback = string.Empty;
				int FeedbackSeverity2 = 0;
				if (!weaponry2.HaveAvailableWeaponSuitableForThisTarget(primaryTarget5, CheckWRA: true, doctrine4, ref UserFeedback, ref FeedbackSeverity2, HumanFeedBackNeeded: false))
				{
					if (!method_12().IsOnActivePatrol())
					{
						return;
					}
					if (PrimaryTarget.IDStatus < Contact_Base.IdentificationStatus.KnownClass)
					{
						myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
					}
					else if (!myUnit.IsPaintingATarget && !myUnit.WillNeedToPaintATarget && !NeedToCrank())
					{
						if (myUnit.get_ParentGroup(UsingMissionPlanner: false) != null && myUnit.get_ParentGroup(UsingMissionPlanner: false).IsPerformingStandoffAttack)
						{
							myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
						}
						else if (myUnit.Navigator.HasFlightPlan)
						{
							myUnit.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
						}
						else
						{
							myUnit.Status = ActiveUnit._ActiveUnitStatus.OnPatrol;
						}
					}
					else
					{
						myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
					}
					return;
				}
				int num25;
				if (method_12().IsOnActivePatrol())
				{
					if (TargetingBehaviorForThisTarget(PrimaryTarget, null) == TargetingEntry._TargetingBehavior.AutoTargeted)
					{
						Doctrine._UseShootTourists? canShootTourists4 = myUnit.Doctrine.get_ShootTourists(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
						Contact primaryTarget6 = PrimaryTarget;
						UserFeedback = "";
						FeedbackSeverity2 = 0;
						if (!ContactIsRelevantToFlightOrMission(primaryTarget6, mission, canShootTourists4, IgnoreContacStance: false, isInsidePatrolArea_10nmBuffer, IgnoreNeutralContacts: true, null, ref UserFeedback, ref FeedbackSeverity2))
						{
							if (myUnit.Navigator.HasFlightPlan)
							{
								myUnit.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
							}
							else
							{
								myUnit.Status = ActiveUnit._ActiveUnitStatus.OnPatrol;
							}
						}
						else
						{
							myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
						}
						return;
					}
					num25 = 1;
				}
				else
				{
					num25 = 1;
				}
				bool flag33 = (byte)num25 != 0;
				if (myUnit.Status != ActiveUnit._ActiveUnitStatus.EngagedOffensive)
				{
					flag33 = true;
				}
				if (myUnit.get_UnitSide(SetSideOnly: false).WeaponSalvos != null)
				{
					int num26;
					if (myUnit.get_UnitSide(SetSideOnly: false).WeaponSalvos.Count == 0)
					{
						flag33 = true;
						num26 = 0;
					}
					else
					{
						num26 = 0;
					}
					bool flag34 = (byte)num26 != 0;
					List<WeaponSalvo>.Enumerator enumerator25 = myUnit.get_UnitSide(SetSideOnly: false).WeaponSalvos.GetEnumerator();
					while (enumerator25.MoveNext())
					{
						WeaponSalvo current23 = enumerator25.Current;
						if (current23 == null || current23.ShootersList == null)
						{
							continue;
						}
						WeaponSalvo.Shooter[] shootersList = current23.ShootersList;
						foreach (WeaponSalvo.Shooter shooter in shootersList)
						{
							if (Operators.CompareString(shooter.ShooterObjectID, myUnit.ObjectID, false) == 0)
							{
								if (shooter.QuantityFired < shooter.QuantityAssigned && myUnit.Weaponry.HowManyOfThisWeapon(current23.int_1) != 0)
								{
									flag33 = true;
									flag34 = true;
									break;
								}
								flag33 = false;
							}
						}
						if (flag34)
						{
							break;
						}
					}
				}
				Aircraft aircraft5;
				int num27;
				if (method_12().IsGroupWingman())
				{
					aircraft5 = (Aircraft)((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).GroupLead;
					num27 = 1;
				}
				else
				{
					aircraft5 = method_12();
					num27 = 1;
				}
				bool flag35 = (byte)num27 != 0;
				if (aircraft5.AI.PrimaryTarget == null && aircraft5.IsGroupWingman())
				{
					aircraft5.AI.PrimaryTarget = ((ActiveUnit)aircraft5).get_ParentGroup(UsingMissionPlanner: false).GroupLead.AI.PrimaryTarget;
				}
				TargetingEntry._TargetingBehavior targetingBehavior = aircraft5.AI.TargetingBehaviorForThisTarget(aircraft5.AI.PrimaryTarget, null);
				Weapon weapon2 = default(Weapon);
				if (aircraft5.Navigator.HasFlightPlan)
				{
					Waypoint[] theArray3 = ((ActiveUnit_Navigator)aircraft5.Navigator).get_Flight(HierarchySearch: true).FlightPlan;
					foreach (Waypoint waypoint8 in theArray3)
					{
						if (waypoint8.ReferenceWeapon_ID != 0)
						{
							weapon2 = method_17(waypoint8.ReferenceWeapon_ID);
						}
					}
				}
				else if (aircraft5.AI.PrimaryTarget != null)
				{
					if (targetingBehavior == TargetingEntry._TargetingBehavior.ManualWeaponAlloc || targetingBehavior == TargetingEntry._TargetingBehavior.ManualTargeted)
					{
						flag33 = true;
						flag35 = false;
					}
					weapon2 = aircraft5.Weaponry.MostSuitableWeaponForThisTarget(aircraft5.AI.PrimaryTarget, CheckIfWithinRange: false, CheckIfWithinAltitude: false, targetingBehavior != TargetingEntry._TargetingBehavior.ManualWeaponAlloc && targetingBehavior != TargetingEntry._TargetingBehavior.ManualTargeted, aircraft5.Doctrine);
				}
				if (weapon2 != null && targetingBehavior != TargetingEntry._TargetingBehavior.ManualWeaponAlloc && targetingBehavior != TargetingEntry._TargetingBehavior.ManualTargeted && mission != null && mission.MissionClass == Mission._MissionClass.Strike)
				{
					IEnumerator<Module_Unit.Unit> enumerator26 = ((Strike)mission).SpecificTargets.OrderBy([SpecialName] (Module_Unit.Unit theC) => theC.RangeToUnit_Horiz(method_12())).GetEnumerator();
					while (enumerator26.MoveNext())
					{
						Module_Unit.Unit current24 = enumerator26.Current;
						Contact contactForThisUnit7 = GetContactForThisUnit(current24);
						if (contactForThisUnit7 == null || myUnit.get_UnitSide(SetSideOnly: false).WRAQuantityRemainingForWeaponVsTarget_ExistingSalvos(myUnit, contactForThisUnit7, weapon2) <= 0)
						{
							continue;
						}
						flag35 = false;
						break;
					}
				}
				if (flag35)
				{
					flag33 = false;
				}
				if (flag33 && !method_12().Navigator.IsOnReturningLegFlightPlan)
				{
					myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
					if (myUnit.IsGroupLead() && !flag35)
					{
						IEnumerator<KeyValuePair<string, ActiveUnit>> enumerator27 = myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.GetEnumerator();
						while (enumerator27.MoveNext())
						{
							KeyValuePair<string, ActiveUnit> current25 = enumerator27.Current;
							if (current25.Value.Weaponry.IsWinchesterOrShotgun() == ActiveUnit._ActiveUnitWeaponState.IsWinchester)
							{
								current25.Value.Status = ActiveUnit._ActiveUnitStatus.Tasked;
								current25.Value.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
							}
							else
							{
								current25.Value.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
							}
						}
					}
					Doctrine._UseShootTourists? canShootTourists5 = myUnit.Doctrine.get_ShootTourists(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
					Contact primaryTarget7 = PrimaryTarget;
					UserFeedback = "";
					int FeedbackSeverity3 = 0;
					if (!ContactIsRelevantToFlightOrMission(primaryTarget7, mission, canShootTourists5, IgnoreContacStance: false, isInsidePatrolArea_10nmBuffer, IgnoreNeutralContacts: true, null, ref UserFeedback, ref FeedbackSeverity3) || !aircraft5.Navigator.HasFlightPlan)
					{
						return;
					}
					Waypoint[] flightPlan2 = ((ActiveUnit_Navigator)aircraft5.Navigator).get_Flight(HierarchySearch: true).FlightPlan;
					FeedbackSeverity3 = 0;
					Waypoint waypoint9;
					while (true)
					{
						if (FeedbackSeverity3 < flightPlan2.Length)
						{
							waypoint9 = flightPlan2[FeedbackSeverity3];
							if (waypoint9.ReferenceWeapon_ID != 0)
							{
								break;
							}
							FeedbackSeverity3 = checked(FeedbackSeverity3 + 1);
							continue;
						}
						return;
					}
					if (waypoint9.TerrainFollowing && waypoint9.DesiredAltitude_TerrainFollowing.HasValue)
					{
						method_12().DesiredAltitude_AGL = waypoint9.DesiredAltitude_TerrainFollowing.Value;
					}
				}
				else
				{
					myUnit.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
				}
				return;
			}
		}
		if (!Information.IsNothing((object)PrimaryTarget) && (myUnit.Navigator.IsOnAutoPlannerPlottedCourse_FinalTargetRun || myUnit.Navigator.IsOnLocalizationRun))
		{
			if ((PrimaryTarget == null || myUnit.Navigator.PlottedCourse.Count() <= 0 || !myUnit.Navigator.IsOnLocalizationRun || !(Module_Unit.RangeToPoint_Horiz(myUnit, myUnit.Navigator.PlottedCourse[0].Latitude, myUnit.Navigator.PlottedCourse[0].Longitude) < 30f)) && !GeoPoint.IsInsideThisArea(myUnit.Navigator.PlottedCourse[0].Latitude, myUnit.Navigator.PlottedCourse[0].Longitude, myUnit.AI.PrimaryTarget.UncertaintyArea))
			{
				myUnit.Navigator.ClearPlottedCourse();
			}
			myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
			return;
		}
		if (!Information.IsNothing((object)mission) && mission.MissionClass == Mission._MissionClass.Patrol && !Information.IsNothing((object)PrimaryTarget))
		{
			myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
			return;
		}
		if (airOps.Condition == Aircraft_AirOps._AirOpsCondition.ManoeuveringToRefuel)
		{
			myUnit.Status = ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint;
			return;
		}
		int value7;
		if (!myUnit.Navigator.HasPlottedCourse())
		{
			value7 = 0;
		}
		else
		{
			if (myUnit.Navigator.PlottedCourse.Count() > 0)
			{
				Waypoint? waypoint10 = myUnit.Navigator.PlottedCourse.FirstOrDefault();
				bool? flag37;
				bool? flag36 = (flag37 = ((waypoint10 == null) ? ((bool?)null) : new bool?(waypoint10.Type == Waypoint.WaypointType.Assemble)));
				bool? obj9;
				bool? flag38;
				if (flag36.HasValue && flag37 == true)
				{
					obj9 = true;
				}
				else
				{
					Waypoint? waypoint11 = myUnit.Navigator.PlottedCourse.FirstOrDefault();
					flag36 = (flag38 = ((waypoint11 == null) ? ((bool?)null) : new bool?(waypoint11.Type == Waypoint.WaypointType.HoldStart)));
					obj9 = ((!flag36.HasValue) ? ((bool?)null) : ((flag38 == true) | flag37));
				}
				flag9 = obj9;
				flag38 = obj9;
				if (flag38.HasValue && flag9 == true)
				{
					obj7 = true;
				}
				else
				{
					Waypoint? waypoint12 = myUnit.Navigator.PlottedCourse.FirstOrDefault();
					flag38 = (flag16 = ((waypoint12 != null) ? new bool?(waypoint12.Type == Waypoint.WaypointType.HoldEnd) : ((bool?)null)));
					obj7 = ((!flag38.HasValue) ? ((bool?)null) : ((flag16 == true) | flag9));
				}
				goto IL_6956;
			}
			value7 = 0;
		}
		obj7 = (byte)value7 != 0;
		goto IL_6956;
		IL_136c:
		if (num2 > (double)method_12().FuelCapacityCurrent && !flag7)
		{
			Notification_Bark.Create_UnitBehaviour(myUnit, "immediate RTB issued", Color.Red);
			IssueImmediateReturnToBase();
			return;
		}
		if (!flag7)
		{
			b = (byte?)myUnit.Doctrine.get_UseReplenishment(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true || !method_12().ActiveMissionOrPackage().KeepOnMissionWithoutTankersInPlace)
			{
				if (flag5)
				{
					myUnit.DetachUnit(NotifyPlayer: false, ClearPlottedCourse: false, UseFlightplan: true);
				}
				if (myUnit.ActiveMissionOrPackage() != null)
				{
					if (myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
					{
						if (!flag5 && myUnit.get_ParentGroup(UsingMissionPlanner: false) != null)
						{
							myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.EgressToRejoinPoint(elapsedTime, ForceObjectiveWaypointRemoval: false);
						}
						else
						{
							myUnit.Navigator.EgressToRejoinPoint(elapsedTime, ForceObjectiveWaypointRemoval: false);
						}
						myUnit.Status = ActiveUnit._ActiveUnitStatus.RTB_CalledOff;
					}
				}
				else
				{
					myUnit.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
				}
				Doctrine doctrine5 = myUnit.Doctrine;
				CheckNoNavZones = true;
				Doctrine parentDoctrine3 = doctrine5.GetParentDoctrine(ref CheckNoNavZones);
				myUnit.Doctrine.set_UseReplenishment(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false, parentDoctrine3.get_UseReplenishment(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false));
				return;
			}
		}
		if (flag8 && !flag4)
		{
			string text = "";
			if (Operators.CompareString(myUnit.Name, myUnit.UnitClass, false) != 0)
			{
				text = " (" + myUnit.UnitClass + ")";
			}
			method_12().AddMessage(myUnit.Name + text + " has reached Bingo fuel but is NOT returning to base due to mission tanker option settings.", myUnit.Name + " is Bingo and expects a tanker!", LoggedMessage.MessageType.UnitAIEmergency, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
		}
		return;
		IL_1d65:
		CheckNoNavZones = false;
		theSelectedTanker = null;
		theSelectedMissions = null;
		UserFeedback = "";
		CheckForMines = true;
		if (!airOps.AttemptToScheduleRefuel(geoPoint, Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround, ref CheckNoNavZones, IsForced: false, ref theSelectedTanker, ref theSelectedMissions, ref UserFeedback, ref CheckForMines, ref MissionPlanner_PostponedRefuelling))
		{
			goto IL_1d96;
		}
		SetMissionStateFlag(1u, theValue: true);
		return;
		IL_0c0a:
		flag2 = obj2;
		if ((flag2 ?? true) && !GetMissionStateFlag(1u) && flag2.HasValue)
		{
			goto IL_1d65;
		}
		if (!Information.IsNothing((object)geoPoint))
		{
			if (!Information.IsNothing((object)mission) && mission.MissionClass == Mission._MissionClass.Ferry && mission.FuelQtyToStartLookingForTanker_Airborne > 0)
			{
				b = (byte?)myUnit.Doctrine.get_UseReplenishment(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
				flag9 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
				flag2 = (!flag9) ?? flag9;
				if (flag2 ?? true)
				{
					bool? obj10;
					if (myUnit.IsGroupWingman() && !Information.IsNothing((object)myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead))
					{
						b = (byte?)myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Doctrine.get_UseReplenishment(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
						obj10 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
					}
					else
					{
						obj10 = false;
					}
					flag9 = obj10;
					if (((!flag9) ?? flag9) == true && flag2.HasValue)
					{
						float num29 = float.MaxValue;
						ActiveUnit activeUnit9 = myUnit;
						if (myUnit.IsGroupMember())
						{
							IEnumerator<ActiveUnit> enumerator28 = myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values.GetEnumerator();
							while (enumerator28.MoveNext())
							{
								ActiveUnit current26 = enumerator28.Current;
								if ((float)current26.FuelCapacityCurrent < num29)
								{
									num29 = current26.FuelCapacityCurrent;
									activeUnit9 = current26;
								}
							}
						}
						ActiveUnit activeUnit10 = activeUnit9;
						double TotalMax = 0.0;
						double TotalCurrent = 0.0;
						if (activeUnit10.FuelPercent(ref TotalMax, ref TotalCurrent, MissionFuel: true) > (double)(float)((double)mission.FuelQtyToStartLookingForTanker_Airborne / 100.0))
						{
							return;
						}
					}
				}
			}
			b = (byte?)myUnit.Doctrine.get_UseReplenishment(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
			flag16 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
			flag16 = (flag9 = (!flag16) ?? flag16);
			if (flag16.HasValue && flag9 != true)
			{
				obj3 = false;
				goto IL_1017;
			}
			int value8;
			if (!myUnit.IsGroupWingman())
			{
				value8 = 0;
			}
			else
			{
				if (!Information.IsNothing((object)myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead))
				{
					b = (byte?)myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Doctrine.get_UseReplenishment(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
					obj6 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
					goto IL_0fcc;
				}
				value8 = 0;
			}
			obj6 = (byte)value8 != 0;
			goto IL_0fcc;
		}
		if (method_12().Status != ActiveUnit._ActiveUnitStatus.RTB_Exhaustion && method_12().Status != ActiveUnit._ActiveUnitStatus.RTB_Manual && method_12().Status != ActiveUnit._ActiveUnitStatus.RTB_MissionOver && method_12().Status != ActiveUnit._ActiveUnitStatus.RTB_CommsLost && method_12().Status != ActiveUnit._ActiveUnitStatus.RTB && method_12()._StatusBefore_NeedToRefuel != ActiveUnit._ActiveUnitStatus.RTB_MissionOver && method_12()._StatusBefore_NeedToRefuel != ActiveUnit._ActiveUnitStatus.RTB && method_12().FuelState != ActiveUnit._ActiveUnitFuelState.IsBingo && method_12().FuelState != ActiveUnit._ActiveUnitFuelState.IsJoker)
		{
			Doctrine._UnderwayRefuelAndReplenishmentSelection value9 = myUnit.Doctrine.get_ReplenishmentSelection(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false).Value;
			CheckNoNavZones = false;
			theSelectedTanker = null;
			theSelectedMissions = null;
			UserFeedback = "";
			CheckForMines = false;
			if (airOps.AttemptToScheduleRefuel(null, value9, ref CheckNoNavZones, IsForced: false, ref theSelectedTanker, ref theSelectedMissions, ref UserFeedback, ref CheckForMines, ref MissionPlanner_PostponedRefuelling))
			{
				return;
			}
		}
		else
		{
			CheckForMines = false;
			theSelectedTanker = null;
			theSelectedMissions = null;
			UserFeedback = "";
			CheckNoNavZones = true;
			if (airOps.AttemptToScheduleRefuel(null, Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround, ref CheckForMines, IsForced: false, ref theSelectedTanker, ref theSelectedMissions, ref UserFeedback, ref CheckNoNavZones, ref MissionPlanner_PostponedRefuelling))
			{
				return;
			}
		}
		if (!MissionPlanner_PostponedRefuelling && myUnit.Navigator.HasFlightPlan && myUnit.Navigator.PlottedCourse.Count() > 0 && (myUnit.Navigator.IsOnAutoPlannerPlottedCourse_OnStation || myUnit.Navigator.IsOnAutoPlannerPlottedCourse_StationIngressRun || (myUnit.Navigator.HasFlight && myUnit.Navigator.get_Flight(HierarchySearch: true).get_Status(myUnit.ParentScen) != Mission._FlightStatus.Airborne_EgressLeg && ((!Information.IsNothing((object)mission) && (mission.MissionClass == Mission._MissionClass.Patrol || mission.MissionClass == Mission._MissionClass.Support)) || myUnit.AI.IsEscort))))
		{
			myUnit.Navigator.EgressToRejoinPoint(elapsedTime, ForceObjectiveWaypointRemoval: false);
			myUnit.Status = ActiveUnit._ActiveUnitStatus.RTB_CalledOff;
			Doctrine doctrine6 = myUnit.Doctrine;
			CheckNoNavZones = true;
			Doctrine parentDoctrine4 = doctrine6.GetParentDoctrine(ref CheckNoNavZones);
			myUnit.Doctrine.set_UseReplenishment(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false, parentDoctrine4.get_UseReplenishment(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false));
			return;
		}
		goto IL_1d96;
		IL_19fb:
		if (myUnit.Navigator.IsOnAutoPlannerPlottedCourse)
		{
			goto IL_1aee;
		}
		if (myUnit.IsGroupWingman() && myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead != null && myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.IsOnAutoPlannerPlottedCourse && method_12().ActiveMissionOrPackage() != null)
		{
			b = (byte?)myUnit.Doctrine.get_UseReplenishment(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true || !method_12().ActiveMissionOrPackage().KeepOnMissionWithoutTankersInPlace)
			{
				goto IL_1aee;
			}
		}
		goto IL_1d96;
	}

	public bool KeepOnEngagingTheTarget(Contact theTarget, Strike theStrikeMission)
	{
		Weapon theW = myUnit.Weaponry.MostSuitableWeaponForThisTarget(theTarget, CheckIfWithinRange: false, CheckIfWithinAltitude: false, CheckWRA: true, myUnit.Doctrine);
		if (theW != null)
		{
			Weapon theW2 = theW;
			GlobalVariables.BooleanObject EmitterClassificable = null;
			Doctrine._WRA_WeaponTargetType theTargetType = Contact.WRA_DetermineTargetType(ref theTarget, theW2, ref EmitterClassificable);
			Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType = Doctrine.WRA_ConvertWeaponTargetTypeToWRA_TargetType(ref theW, ref theTarget, ref theTargetType, myUnit.get_UnitSide(SetSideOnly: false).ObjectID);
			bool flag = false;
			bool flag2 = false;
			Doctrine doctrine = myUnit.Doctrine;
			Scenario parentScen = myUnit.ParentScen;
			Weapon theWeapon = theW;
			int? TargetType_InheritedWeaponQty = null;
			int? TargetType_UnspecifiedWeaponQty = null;
			int? num = Doctrine.WRA_WeaponQty_AnyTargetType(doctrine, parentScen, theWeapon, wRA_WeaponTargetType, FindInheritedValuesOnly: false, ref TargetType_InheritedWeaponQty, ref TargetType_UnspecifiedWeaponQty);
			TargetType_UnspecifiedWeaponQty = num;
			if (((!TargetType_UnspecifiedWeaponQty.HasValue) ? ((bool?)null) : new bool?(TargetType_UnspecifiedWeaponQty == -99)) == true)
			{
				num = myUnit.Weaponry.HowManyOfThisWeapon(theW.DBID) * Doctrine.GetShooterNumber(theW, myUnit, theTarget, wRA_WeaponTargetType);
				flag = true;
			}
			else
			{
				TargetType_UnspecifiedWeaponQty = num;
				if (((!TargetType_UnspecifiedWeaponQty.HasValue) ? ((bool?)null) : new bool?(TargetType_UnspecifiedWeaponQty.GetValueOrDefault() < 0)) == true)
				{
					num = myUnit.get_UnitSide(SetSideOnly: false).ConvertSalvoWeaponQty_To_ActualQuantity(num, ref myUnit, ref theTarget, ref theW);
				}
			}
			Doctrine doctrine2 = myUnit.Doctrine;
			Scenario parentScen2 = myUnit.ParentScen;
			Weapon theWeapon2 = theW;
			TargetType_UnspecifiedWeaponQty = null;
			TargetType_InheritedWeaponQty = null;
			int? num2 = Doctrine.WRA_ShooterQty_AnyTargetType(doctrine2, parentScen2, theWeapon2, wRA_WeaponTargetType, FindInheritedValuesOnly: false, ref TargetType_UnspecifiedWeaponQty, ref TargetType_InheritedWeaponQty);
			TargetType_InheritedWeaponQty = num2;
			if ((TargetType_InheritedWeaponQty.HasValue ? new bool?(TargetType_InheritedWeaponQty == -99) : ((bool?)null)) == true)
			{
				num2 = int.MaxValue;
				flag2 = true;
			}
			int num3;
			if (!flag)
			{
				num3 = 0;
			}
			else if (flag2)
			{
				num3 = 0;
			}
			else
			{
				num = method_12().Weaponry.HowManyOfThisWeapon(theW.DBID) * num2;
				num3 = 0;
			}
			int num4 = num3;
			Weapon[] incomingGuidedWeapons = theTarget.IncomingGuidedWeapons;
			if (incomingGuidedWeapons != null)
			{
				Weapon[] array = incomingGuidedWeapons;
				for (int i = 0; i < array.Length; i = checked(i + 1))
				{
					if (array[i].DBID == theW.DBID)
					{
						num4++;
					}
				}
			}
			if ((num.HasValue ? new bool?(num4 < num.GetValueOrDefault()) : ((bool?)null)) == true)
			{
				double num5 = theW.get_MaxRangeForThisTarget(myUnit, theTarget, CheckWRA: false, (Doctrine)null, ManualFire: false);
				double num6 = myUnit.RangeToUnit_Horiz(theTarget);
				double num7 = double.MaxValue;
				try
				{
					if (method_12().IsGroupWingman() && theTarget != null)
					{
						num7 = Mission.SplitDistanceToNumber(theStrikeMission.SplitDistance);
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 200344_76", "");
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				bool result = default(bool);
				if (num5 + num7 >= num6)
				{
					if (!method_12().Navigator.HasFlightPlan)
					{
						return true;
					}
					try
					{
						int num8;
						if (method_12().Status == ActiveUnit._ActiveUnitStatus.EngagedOffensive)
						{
							num8 = 1;
							goto IL_0375;
						}
						if ((method_12().Status == ActiveUnit._ActiveUnitStatus.OnPlottedCourse && method_12().Navigator.HasReachedWeaponReleasePoint(fromUI: false)) & !method_12().Navigator.IsOnReturningLegFlightPlan)
						{
							num8 = 1;
							goto IL_0375;
						}
						goto end_IL_032b;
						IL_0375:
						result = (byte)num8 != 0;
						return result;
						end_IL_032b:;
					}
					catch (Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						Exception ex4 = ex3;
						ex4?.Data.Add("Error at 200344_78", "");
						GameGeneral.WriteExceptionsToLog(ex4);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				return result;
			}
			return false;
		}
		return false;
	}

	public void IssueImmediateReturnToBase()
	{
		method_12().FuelState = method_12().IsBingoOrJoker;
		method_12().WeaponState = method_12().Weaponry.IsWinchesterOrShotgun();
		method_12().AirOps.AttemptToRTB(ManuallyOrdered: true, ActiveUnit._ActiveUnitStatus.RTB_Manual, GroupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, DetachFromGroup: true, ClearPlottedCourse: true);
		string text = "";
		if (Operators.CompareString(method_12().Name, method_12().UnitClass, false) != 0)
		{
			text = " (" + method_12().UnitClass + ")";
		}
		string text2 = "";
		ActiveUnit actualDestinationHost = method_12().AirOps.ActualDestinationHost;
		if (!Information.IsNothing((object)actualDestinationHost))
		{
			text2 = " (" + actualDestinationHost.Name + ")";
		}
		method_12().Navigator.ResetTimeToNextPathfinderCheck();
		method_12().ParentScen.AddMessage(method_12().Name + text + " Is returning to base following the shortest path possible (plotted course was too long for remaining fuel)" + text2, "Unit returning to base", LoggedMessage.MessageType.AirOps, 5, method_12().ObjectID, ((ActiveUnit)method_12()).get_UnitSide(SetSideOnly: false), new Geopoint_Struct(method_12().get_Longitude((GlobalVariables.BooleanObject)null), method_12().get_Latitude((GlobalVariables.BooleanObject)null)));
	}

	public override void EvaluateThreats(float elapsedTime)
	{
		if (myUnit == null || myUnit.get_UnitSide(SetSideOnly: false) == null || (myUnit.IsDrone() && myUnit.AutonomyLevel < ActiveUnit.DroneAutonomyLevel.BattlespaceCognizant && myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DroneAutonomyLevels) && !((ActiveUnit_CommStuff)method_12().CommStuff).IsConnectedToSideNetwork))
		{
			return;
		}
		ClearAllNonImminentThreats(elapsedTime);
		Contact[] array = theContactsVisibleToMe.InternalArray();
		int count = theContactsVisibleToMe.Count;
		try
		{
			int num = count - 1;
			for (int i = 0; i <= num; i++)
			{
				try
				{
					Contact contact = array[i];
					if (method_20(contact))
					{
						AddContactToThreatList(contact);
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 100381", "");
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 100382", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private Weapon[] method_18()
	{
		return myUnit.Weaponry.AllDistinctWeaponsAboard_Actual().ToArray();
	}

	public override void EvaluateTargets(float elapsedTime, bool IgnoreContacStance, bool Immediately)
	{
		if (!EvaluateTargets_Enabled || myUnit == null || method_12().HasLostControlPulse_CACHED || (myUnit.IsDrone() && myUnit.AutonomyLevel < ActiveUnit.DroneAutonomyLevel.BattlespaceCognizant && myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DroneAutonomyLevels) && !myUnit.CommStuff.IsConnectedToSideNetwork))
		{
			return;
		}
		Side side = myUnit.get_UnitSide(SetSideOnly: false);
		Aircraft_Weaponry weaponry = method_12().Weaponry;
		try
		{
			HashSet<Contact> hashSet = new HashSet<Contact>();
			Contact current2 = default(Contact);
			if (myUnit.Mounts.Count == 0 && myUnit.Sensors_Cached.Length == 0 && (method_12().Loadout == null || method_12().Loadout.Weapons.Length == 0))
			{
				if (PrimaryTarget != null)
				{
					DropTarget(PrimaryTarget);
				}
				hashSet = new HashSet<Contact>(base.Targets_ReadOnly);
				if (hashSet.Count <= 0)
				{
					return;
				}
				PooledList<Contact> pooledList = new PooledList<Contact>();
				foreach (Contact item2 in hashSet)
				{
					if (item2 != null)
					{
						pooledList.Add(item2);
					}
				}
				foreach (Contact item3 in pooledList)
				{
					if (item3 != null)
					{
						DropTarget(item3);
						current2 = null;
					}
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
			bool flag = true;
			if (!IsEscort && myUnit.Navigator.HasFlightPlan && mission != null && mission.MissionClass == Mission._MissionClass.Strike && ((Strike)mission).get_FocusEntirelyOnStrikeTargets(myUnit))
			{
				flag = false;
			}
			hashSet = new HashSet<Contact>(base.Targets_ReadOnly);
			bool isInsidePatrolArea_10nmBuffer = base.IsInsidePatrolArea_10nmBuffer;
			List<Weapon> list = new List<Weapon>();
			list.AddRange(method_18());
			Doctrine._UseShootTourists? useShootTourists = myUnit.Doctrine.get_ShootTourists(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
			if (theContactsVisibleToMe == null)
			{
				theContactsVisibleToMe = Module_ActiveUnit_Sensory.ContactsVisibleToMe(myUnit.Sensory);
			}
			_ = theContactsVisibleToMe.Count;
			if (concurrentHashSet_0.Count > 0)
			{
				concurrentHashSet_0.Clear();
			}
			foreach (Contact item4 in theContactsVisibleToMe)
			{
				if (item4 != null && TargetingBehaviorForThisTarget(item4, null) != TargetingEntry._TargetingBehavior.NotTargeted)
				{
					concurrentHashSet_0.Add(item4.ObjectID);
				}
			}
			int FeedbackSeverity;
			if (mission != null && mission.IsActive)
			{
				PooledList<(ActiveUnit, Mission)> pooledList2 = null;
				if (IsEscort)
				{
					for (int i = side.Units.Count - 1; i >= 0; i += -1)
					{
						ActiveUnit activeUnit;
						try
						{
							activeUnit = side.Units[i];
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							ProjectData.ClearProjectError();
							continue;
						}
						bool? flag2 = activeUnit?.IsGroup;
						if (((!flag2) ?? flag2) == true && activeUnit.IsOperating() && !activeUnit.AI.IsEscort)
						{
							Mission item = activeUnit.ActiveMissionOrPackage();
							if (pooledList2 == null)
							{
								pooledList2 = new PooledList<(ActiveUnit, Mission)>();
							}
							pooledList2.Add((activeUnit, item));
						}
					}
				}
				foreach (Contact item5 in theContactsVisibleToMe)
				{
					if (_DoNotTargetList.Contains(item5))
					{
						continue;
					}
					string objectID = item5.ObjectID;
					if (hashSet.Contains(item5))
					{
						continue;
					}
					byte? b = (byte?)item5.BDA_StructuralIntegrity;
					if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 4)) == true)
					{
						continue;
					}
					bool? flag2 = ((item5.IDStatus < Contact_Base.IdentificationStatus.KnownType) ? new bool?(false) : item5.ActualUnit?.IsWeapon);
					if ((flag2 ?? true) && ((Weapon)item5.ActualUnit).IsMobileDecoy && flag2.HasValue)
					{
						bool flag3 = false;
						Sensor[] sensors_Cached = item5.ActualUnit.Sensors_Cached;
						for (int j = 0; j < sensors_Cached.Length; j = checked(j + 1))
						{
							if (sensors_Cached[j].IsOECM)
							{
								flag3 = true;
								break;
							}
						}
						if (!flag3)
						{
							continue;
						}
					}
					if (!myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactStancesOnThisPulse.TryGetValue(objectID, out var value))
					{
						value = item5.get_Stance(myUnit.get_UnitSide(SetSideOnly: false));
						myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactStancesOnThisPulse.AddIfNotExists(item5.ObjectID, value);
					}
					switch (value)
					{
					case Misc.PostureStance.Unfriendly:
					case Misc.PostureStance.Hostile:
					{
						Doctrine._UseShootTourists? canShootTourists2 = useShootTourists;
						Misc.PostureStance? contactStance2 = value;
						string Feedback = "";
						FeedbackSeverity = 0;
						if (!ContactIsRelevantToFlightOrMission(item5, mission, canShootTourists2, IgnoreContacStance, isInsidePatrolArea_10nmBuffer, IgnoreNeutralContacts: true, contactStance2, ref Feedback, ref FeedbackSeverity, pooledList2) || IsContactTooAmbiguousForEvaluation(item5))
						{
							break;
						}
						if (item5.Type == Contact_Base.ContactType.Submarine)
						{
							if (!item5.IsClassifiedFalseTarget && !SeaIceProvider.PointIsUnderIce(((Module_Unit.Unit)item5).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)item5).get_Latitude((GlobalVariables.BooleanObject)null)))
							{
								TargetThisContact(item5, AddedManually: false, PriorityTarget: false, TargetingEntry._TargetingBehavior.AutoTargeted);
								concurrentHashSet_0.Add(item5.ObjectID);
							}
							break;
						}
						Doctrine doctrine = myUnit.Doctrine;
						Feedback = null;
						FeedbackSeverity = 0;
						if (weaponry.HaveAvailableWeaponSuitableForThisTarget(item5, CheckWRA: true, doctrine, ref Feedback, ref FeedbackSeverity, HumanFeedBackNeeded: false, list))
						{
							TargetThisContact(item5, AddedManually: false, PriorityTarget: false, TargetingEntry._TargetingBehavior.AutoTargeted);
							concurrentHashSet_0.Add(item5.ObjectID);
						}
						break;
					}
					case Misc.PostureStance.Unknown:
					{
						Doctrine._UseShootTourists? canShootTourists = useShootTourists;
						Misc.PostureStance? contactStance = value;
						string Feedback = "";
						FeedbackSeverity = 0;
						if (ContactIsRelevantToFlightOrMission(item5, mission, canShootTourists, IgnoreContacStance, isInsidePatrolArea_10nmBuffer, IgnoreNeutralContacts: true, contactStance, ref Feedback, ref FeedbackSeverity, pooledList2) && (item5.Type != Contact_Base.ContactType.Submarine || !SeaIceProvider.PointIsUnderIce(((Module_Unit.Unit)item5).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)item5).get_Latitude((GlobalVariables.BooleanObject)null))) && (item5.UncertaintyArea == null || GetTargetAmbiguity(item5, 100f) != AmbiguityLevel.ExtremelyAmbiguous) && (!IsEscort || !((ActiveUnit)method_12()).IsRTB))
						{
							TargetThisContact(item5, AddedManually: false, PriorityTarget: false, TargetingEntry._TargetingBehavior.AutoTargeted);
						}
						break;
					}
					}
				}
				pooledList2?.Dispose();
			}
			Weapon longestRange_AAWeapon = weaponry.GetLongestRange_AAWeapon(current2);
			Weapon longestRange_ASWWeapon = weaponry.GetLongestRange_ASWWeapon(current2);
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
						longestWeapon_ASuW = weaponry.GetLongestRange_ASWeapon(ExcludeICBMs: false, current2);
						longestWeapon_AG = weaponry.GetLongestRange_AGWeapon(ExcludeICBMs: false, current2);
					}
				}
			}
			else
			{
				longestWeapon_ASuW = weaponry.GetLongestRange_ASWeapon(ExcludeICBMs: false, current2);
				longestWeapon_AG = weaponry.GetLongestRange_AGWeapon(ExcludeICBMs: false, current2);
			}
			bool flag4 = myUnit.IsOnActivePatrol() && ((Patrol)mission).HasProsecutionArea;
			bool hasValue;
			Doctrine._UseShootTourists value2 = default(Doctrine._UseShootTourists);
			if (hasValue = useShootTourists.HasValue)
			{
				value2 = useShootTourists.Value;
			}
			ObservableDictionary<string, TargetingEntry> targetList = _TargetList;
			Contact[] array = theContactsVisibleToMe.ToArray();
			FeedbackSeverity = array.Length - 1;
			for (int k = 0; k <= FeedbackSeverity; k++)
			{
				current2 = array[k];
				if (_DoNotTargetList.Contains(current2))
				{
					continue;
				}
				string objectID2 = current2.ObjectID;
				Misc.PostureStance contactsStance_Cache = GetContactsStance_Cache(current2, k);
				if (contactsStance_Cache == Misc.PostureStance.Friendly || contactsStance_Cache == Misc.PostureStance.Neutral)
				{
					continue;
				}
				new bool?(current2.get_IsDestroyed(myUnit.ParentScen));
				if (concurrentHashSet_0.Contains(objectID2))
				{
					continue;
				}
				bool? flag2 = ((current2.IDStatus < Contact_Base.IdentificationStatus.KnownType) ? new bool?(false) : current2.ActualUnit?.IsWeapon);
				if ((flag2 ?? true) && ((Weapon)current2.ActualUnit).IsMobileDecoy && flag2.HasValue)
				{
					bool flag5 = false;
					Sensor[] sensors_Cached2 = current2.ActualUnit.Sensors_Cached;
					for (int l = 0; l < sensors_Cached2.Length; l = checked(l + 1))
					{
						if (sensors_Cached2[l].IsOECM)
						{
							flag5 = true;
							break;
						}
					}
					if (!flag5)
					{
						continue;
					}
				}
				byte? b = (byte?)current2.BDA_StructuralIntegrity;
				if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 4)) == true)
				{
					continue;
				}
				if (weaponry.ContactIsWithinSelfDefenceRange(current2))
				{
					_SelfDefenceTargets.Add(current2);
				}
				if (!flag4 && mission != null && mission.IsActive && mission.MissionClass == Mission._MissionClass.Patrol)
				{
					Patrol patrol2 = (Patrol)mission;
					if (!current2.IsAir_Missile_Submarine_Contact && ((Module_Unit.Unit)current2).get_IsInsideThisArea(patrol2.PatrolArea, myUnit.ParentScen, UseCache: true) && !concurrentHashSet_0.Contains(objectID2))
					{
						TargetThisContact(current2, AddedManually: false, PriorityTarget: false, TargetingEntry._TargetingBehavior.AutoTargeted);
						concurrentHashSet_0.Add(current2.ObjectID);
						continue;
					}
					if (!((Patrol)mission).get_InvestigateOutsidePatrolArea(myUnit.ParentScen) && !((Module_Unit.Unit)current2).get_IsInsideThisArea(patrol2.PatrolArea, myUnit.ParentScen, UseCache: true) && TargetingBehaviorForThisTarget(current2, targetList) != TargetingEntry._TargetingBehavior.ManualWeaponAlloc && !myUnit.Sensory.IsIlluminatingThisContact(current2) && (!hasValue || value2 != Doctrine._UseShootTourists.Yes))
					{
						continue;
					}
				}
				if (!concurrentHashSet_0.Contains(objectID2) && flag && (current2.UncertaintyArea == null || GetTargetAmbiguity(current2, 100f) != AmbiguityLevel.ExtremelyAmbiguous) && TargetIsEligibleBasedOnWeaponRange(current2, contactsStance_Cache, hasValue, value2, longestRange_AAWeapon, longestWeapon_ASuW, longestWeapon_AG, longestRange_ASWWeapon))
				{
					Contact theTarget = current2;
					Doctrine doctrine2 = myUnit.Doctrine;
					string Feedback = null;
					int FeedbackSeverity2 = 0;
					if (weaponry.HaveAvailableWeaponSuitableForThisTarget(theTarget, CheckWRA: true, doctrine2, ref Feedback, ref FeedbackSeverity2, HumanFeedBackNeeded: false, list) && !DropTargetDueToRearwardFiringDoctrine(current2))
					{
						TargetThisContact(current2, AddedManually: false, PriorityTarget: false, TargetingEntry._TargetingBehavior.AutoTargeted);
						concurrentHashSet_0.Add(current2.ObjectID);
					}
				}
			}
			foreach (Contact selfDefenceTarget in _SelfDefenceTargets)
			{
				if (!concurrentHashSet_0.Contains(selfDefenceTarget.ObjectID) && !_DoNotTargetList.Contains(selfDefenceTarget))
				{
					TargetThisContact(selfDefenceTarget, AddedManually: false, PriorityTarget: false, TargetingEntry._TargetingBehavior.AutoSelfDefence);
					concurrentHashSet_0.Add(current2.ObjectID);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100383", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private bool method_19(Contact contact_5)
	{
		if (method_12().Loadout != null)
		{
			Loadout.LoadoutRole role = method_12().Loadout.Role;
			int result;
			if (role > Loadout.LoadoutRole.LandNaval_DEAD)
			{
				if (role > Loadout.LoadoutRole.NavalOnly_DEAD)
				{
					if (role == Loadout.LoadoutRole.BAI_CAS)
					{
						goto IL_004e;
					}
					if (role == Loadout.LoadoutRole.Armed_Recon)
					{
						goto IL_00b6;
					}
					result = 0;
				}
				else
				{
					if ((uint)(role - 3101) <= 4u)
					{
						goto IL_004e;
					}
					if ((uint)(role - 3201) <= 4u)
					{
						Contact_Base.ContactType type = contact_5.Type;
						if (type == Contact_Base.ContactType.Surface)
						{
							return true;
						}
						return false;
					}
					result = 0;
				}
			}
			else
			{
				if ((uint)(role - 2001) <= 5u || role == Loadout.LoadoutRole.AntiSatellite_Intercept)
				{
					int result2;
					switch (contact_5.Type)
					{
					case Contact_Base.ContactType.Orbital:
						result2 = 1;
						break;
					default:
						return false;
					case Contact_Base.ContactType.Air:
					case Contact_Base.ContactType.Missile:
						result2 = 1;
						break;
					}
					return (byte)result2 != 0;
				}
				if ((uint)(role - 3001) <= 4u)
				{
					goto IL_00b6;
				}
				result = 0;
			}
			return (byte)result != 0;
		}
		return false;
		IL_004e:
		Contact_Base.ContactType type2 = contact_5.Type;
		int result3;
		if (type2 - 7 <= Contact_Base.ContactType.Missile)
		{
			result3 = 1;
		}
		else
		{
			if (type2 != Contact_Base.ContactType.AggregateGroundUnit)
			{
				return false;
			}
			result3 = 1;
		}
		return (byte)result3 != 0;
		IL_00b6:
		int result4;
		switch (contact_5.Type)
		{
		case Contact_Base.ContactType.Facility_Fixed:
		case Contact_Base.ContactType.Facility_Mobile:
			result4 = 1;
			break;
		case Contact_Base.ContactType.AggregateGroundUnit:
			result4 = 1;
			break;
		default:
			return false;
		case Contact_Base.ContactType.Surface:
			result4 = 1;
			break;
		}
		return (byte)result4 != 0;
	}

	private bool method_20(Contact contact_5)
	{
		if (contact_5 != null)
		{
			if (contact_5.TimeSinceDetection_Visual > 0f && contact_5.ActualUnit?.get_ParentGroup(UsingMissionPlanner: false) != null && contact_5.ActualUnit.get_ParentGroup(UsingMissionPlanner: false).Units.ContainsKey(myUnit.ObjectID))
			{
				return false;
			}
			int result;
			switch (contact_5.Type)
			{
			case Contact_Base.ContactType.Missile:
				if (contact_5.ActualUnit == null)
				{
					return false;
				}
				if (!contact_5.get_IsDestroyed(myUnit.ParentScen))
				{
					if (!myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactStancesOnThisPulse.TryGetValue(contact_5.ObjectID, out var value))
					{
						value = contact_5.get_Stance(myUnit.get_UnitSide(SetSideOnly: false));
						myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactStancesOnThisPulse.AddIfNotExists(contact_5.ObjectID, value);
					}
					if (value == Misc.PostureStance.Friendly || value == Misc.PostureStance.Neutral)
					{
						return false;
					}
					Weapon weapon = (Weapon)contact_5.ActualUnit;
					if (!weapon.ValidTargets.Aircraft)
					{
						return false;
					}
					if (weapon.Type == Weapon._WeaponType.Decoy_Vehicle)
					{
						return false;
					}
					float num2 = Module_Unit.RangeToUnit_Slant(myUnit, contact_5, 0f, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
					if (GameGeneral.Beta_DEFENSIVE_DUE_TO_ILLUMINATION & contact_5.GeneratedFromGuidanceIlluminationDetection)
					{
						foreach (KeyValuePair<int, EmissionContainer> detectedEmission in contact_5.DetectedEmissions)
						{
							Sensor sensor = detectedEmission.Value.get_AssociatedSensor(detectedEmission.Key, myUnit.ParentScen);
							if (sensor != null && sensor.IsTrackingThisUnitForFireControl(ref myUnit))
							{
								return true;
							}
						}
					}
					float num3 = num2;
					float? num4 = method_12().Doctrine.GetElementState(Doctrine.DoctrineItem_E.ThreatMaxDist);
					if (((!num4.HasValue) ? ((bool?)null) : new bool?(num3 > num4.GetValueOrDefault())) != true)
					{
						if (contact_5.HeadingIsKnown)
						{
							float? num5 = 90f - 85f * num2 / (float?)method_12().Doctrine.GetElementState(Doctrine.DoctrineItem_E.ThreatMaxDist);
							num3 = Math.Abs(AngleOffContactsBoresight(ref contact_5, GlobalVariables.ObjectTrue));
							if (((!num5.HasValue) ? ((bool?)null) : new bool?(num3 > num5.GetValueOrDefault())) == true)
							{
								return false;
							}
						}
						Contact[] array = Module_ActiveUnit_Sensory.ContactsVisibleToMe(myUnit.Sensory).InternalArray();
						if (weapon.FiringParent == null)
						{
							goto IL_03d1;
						}
						Contact contact = null;
						Contact[] array2 = array;
						for (int i = 0; i < array2.Length; i = checked(i + 1))
						{
							contact_5 = array2[i];
							if (contact_5 != null && contact_5.ActualUnit == weapon.FiringParent)
							{
								contact = contact_5;
								break;
							}
						}
						if (contact == null)
						{
							result = 1;
						}
						else
						{
							if (contact.IDStatus >= Contact_Base.IdentificationStatus.KnownClass)
							{
								float? num6 = contact.MaxPotentialWeaponRange_AAW();
								float num7 = Module_Unit.RangeToUnit_Slant(myUnit, contact, 0f, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
								if (num6.HasValue && (double)num7 > (double)num6.Value * 1.1)
								{
									return false;
								}
								goto IL_03d1;
							}
							result = 1;
						}
						goto IL_03d2;
					}
					return false;
				}
				return false;
			default:
				return false;
			case Contact_Base.ContactType.Air:
				{
					if (contact_5.ActualUnit != null)
					{
						if (contact_5.IDStatus >= Contact_Base.IdentificationStatus.KnownType)
						{
							if (!(contact_5.ActualUnit is Aircraft))
							{
								return false;
							}
							Aircraft._AircraftType type = ((Aircraft)contact_5.ActualUnit).Type;
							if ((uint)(type - 2001) > 1u && (uint)(type - 3001) > 1u)
							{
								return false;
							}
						}
						if (Math.Abs(AngleOffContactsBoresight(ref contact_5, GlobalVariables.ObjectTrue)) > 90f)
						{
							return false;
						}
						if (Math.Abs(MathFunctions.AngularDifference(method_12().CurrentHeading, Module_Unit.BearingToUnit_True(method_12(), contact_5, GlobalVariables.ObjectTrue))) < 20f)
						{
							return false;
						}
						float num = 0f;
						List<Weapon> list = contact_5.ActualUnit.Weaponry.AllDistinctWeaponsAboard_Actual();
						foreach (Weapon item in list)
						{
							if (item.Type == Weapon._WeaponType.Gun && item.MaxAirRange > num)
							{
								num = item.MaxAirRange;
							}
						}
						if ((double)Module_Unit.RangeToUnit_Slant(myUnit, contact_5, 0f, GlobalVariables.ObjectTrue) > (double)num * 1.1)
						{
							return false;
						}
						return true;
					}
					return false;
				}
				IL_03d1:
				result = 1;
				goto IL_03d2;
				IL_03d2:
				return (byte)result != 0;
			}
		}
		return false;
	}

	private void method_21(float float_0)
	{
		if (myUnit.RangeToUnit_Horiz(PrimaryTarget.ActualUnit) > 4f)
		{
			Contact primaryTarget = PrimaryTarget;
			ActiveUnit observerUnit = myUnit;
			string feedbackMessage = "";
			if (Math.Abs(Module_Unit.AngleOffThisUnitsBoresight(primaryTarget, observerUnit, DistinguishBetweenStarboardAndPort: true, ref feedbackMessage, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue)) < 90f || myUnit.AI.PrimaryTarget.IsOrbitalContact)
			{
				method_22(float_0);
				return;
			}
		}
		method_24(float_0);
	}

	private void method_22(float float_0)
	{
		try
		{
			if (myUnit.Kinematics.DesiredAltitudeOverride && myUnit.Kinematics.DesiredSpeedOverride.HasValue && !myUnit.Navigator.IsOnAutoPlannerPlottedCourse)
			{
				return;
			}
			Aircraft_AirOps airOps = method_12().AirOps;
			Aircraft_AirOps._AirOpsCondition airOpsCondition = Aircraft_AirOps._AirOpsCondition.const_19;
			if (NeedToCrank())
			{
				airOpsCondition = Aircraft_AirOps._AirOpsCondition.BVRCrank;
			}
			else
			{
				Weapon weapon = myUnit.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, CheckIfWithinRange: true, CheckIfWithinAltitude: true, CheckWRA: true, myUnit.Doctrine);
				airOpsCondition = ((weapon != null) ? (weapon.IsBVR() ? Aircraft_AirOps._AirOpsCondition.const_19 : Aircraft_AirOps._AirOpsCondition.Airborne) : Aircraft_AirOps._AirOpsCondition.Airborne);
			}
			airOps.Condition = airOpsCondition;
			Weapon longestRange_AAWeapon = myUnit.Weaponry.GetLongestRange_AAWeapon(PrimaryTarget);
			ActiveUnit_Sensory sensory = myUnit.Sensory;
			Sensor[] theSensorList = null;
			Sensor sensor = sensory.GetLongestRange_AASensor(ActiveCapableSensorsOnly: true, EmmittingSensorsOnly: true, OnlyOperatingSensors: true, OnlySensorsScanningThisPulse: false, ref theSensorList)?.FirstOrDefault();
			float num = myUnit.RangeToUnit_Horiz(PrimaryTarget);
			float num2 = longestRange_AAWeapon?.MaxAirRange ?? 0f;
			float? num3 = null;
			ActiveUnit.Throttle? throttle = null;
			float? num4 = null;
			Patrol patrol = default(Patrol);
			float num5;
			if (!Information.IsNothing((object)myUnit.ActiveMissionOrPackage()) && myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
			{
				patrol = (Patrol)myUnit.ActiveMissionOrPackage();
				num4 = patrol.AttackDistance_Aircraft;
				num5 = (Information.IsNothing((object)num4) ? ((float)Math.Max(10f + num2, (double)num2 * 1.2)) : (num4 + num2).Value);
			}
			else
			{
				num5 = (float)Math.Max(10f + num2, (double)num2 * 1.2);
			}
			if (!myUnit.Kinematics.DesiredAltitudeOverride || myUnit.Navigator.IsOnAutoPlannerPlottedCourse)
			{
				_ = myUnit.DesiredAltitude;
				Mission mission = myUnit.ActiveMissionOrPackage();
				if (mission != null && mission.MissionClass == Mission._MissionClass.Patrol)
				{
					if (patrol == null)
					{
						patrol = (Patrol)myUnit.ActiveMissionOrPackage();
					}
					num3 = ((!num4.HasValue || !(num > num5)) ? patrol.AttackAltitude_Aircraft : patrol.TransitAltitude_Aircraft);
				}
				if (Information.IsNothing((object)num3))
				{
					if (num > num5)
					{
						if (!myUnit.Kinematics.DesiredAltitudeOverride)
						{
							method_12().Navigator.SetInterceptAltitude(airOps.Condition);
						}
					}
					else if (PrimaryTarget.AltitudeIsKnown && ((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < method_12().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) && !method_12().Sensory.HasLDSDRadar && !Information.IsNothing((object)sensor) && num < sensor.maxRange)
					{
						if (!myUnit.Kinematics.DesiredAltitudeOverride)
						{
							myUnit.DesiredAltitude = ((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - 30.48f;
						}
					}
					else if (PrimaryTarget.AltitudeIsKnown && num < (float)Math.Max((double)num2 * 0.75, 10.0))
					{
						if (!myUnit.Kinematics.DesiredAltitudeOverride)
						{
							float num6 = Math.Abs(method_12().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - ((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
							if (num6 == 0f)
							{
								myUnit.DesiredAltitude = ((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
							}
							else if (((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > method_12().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))
							{
								float num7 = method_12().ETA_To_Unit(PrimaryTarget);
								myUnit.DesiredAltitude = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + num6 / num7 * float_0;
							}
							else
							{
								float num8 = method_12().ETA_To_Unit(PrimaryTarget);
								myUnit.DesiredAltitude = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - num6 / num8 * float_0;
							}
						}
					}
					else if (!myUnit.Kinematics.DesiredAltitudeOverride)
					{
						method_12().Navigator.SetInterceptAltitude(airOps.Condition);
					}
				}
				else
				{
					myUnit.DesiredAltitude = num3.Value;
				}
				if (longestRange_AAWeapon != null)
				{
					float LowerReleaseAltitudeLimit_ASL = 0f;
					float UpperReleaseAltitudeLimit_ASL = 0f;
					float LowerReleaseAltitudeLimit_AGL = 0f;
					float UpperReleaseAltitudeLimit_AGL = 0f;
					GetWeaponReleaseLimits(float_0, longestRange_AAWeapon, ref LowerReleaseAltitudeLimit_ASL, ref UpperReleaseAltitudeLimit_ASL, ref LowerReleaseAltitudeLimit_AGL, ref UpperReleaseAltitudeLimit_AGL, myUnit.AI.PrimaryTarget, short.MinValue);
					if (LowerReleaseAltitudeLimit_ASL > myUnit.DesiredAltitude)
					{
						myUnit.DesiredAltitude = LowerReleaseAltitudeLimit_ASL;
					}
					else if (UpperReleaseAltitudeLimit_ASL < myUnit.DesiredAltitude)
					{
						myUnit.DesiredAltitude = UpperReleaseAltitudeLimit_ASL;
					}
					else
					{
						if (myUnit.DesiredAltitude > UpperReleaseAltitudeLimit_ASL)
						{
							myUnit.DesiredAltitude = UpperReleaseAltitudeLimit_ASL;
						}
						if (myUnit.DesiredAltitude < LowerReleaseAltitudeLimit_ASL)
						{
							myUnit.DesiredAltitude = LowerReleaseAltitudeLimit_ASL;
						}
					}
					if (myUnit.get_DesiredAltitude_UseTerrainFollowing(myUnit))
					{
						if (LowerReleaseAltitudeLimit_AGL > myUnit.DesiredAltitude_AGL)
						{
							myUnit.DesiredAltitude_AGL = LowerReleaseAltitudeLimit_AGL;
						}
						else if (UpperReleaseAltitudeLimit_AGL < myUnit.DesiredAltitude_AGL)
						{
							myUnit.DesiredAltitude_AGL = UpperReleaseAltitudeLimit_AGL;
						}
						else
						{
							if (myUnit.DesiredAltitude_AGL > UpperReleaseAltitudeLimit_AGL)
							{
								myUnit.DesiredAltitude_AGL = UpperReleaseAltitudeLimit_AGL;
							}
							if (myUnit.DesiredAltitude_AGL < LowerReleaseAltitudeLimit_AGL)
							{
								myUnit.DesiredAltitude_AGL = LowerReleaseAltitudeLimit_AGL;
							}
						}
					}
					else
					{
						int num9 = ((Module_Unit.Unit)myUnit).get_LandElevation(AGL: true, RequestIsFromGUI: false, Force: false, myUnit.ParentScen);
						LowerReleaseAltitudeLimit_ASL = (float)num9 + LowerReleaseAltitudeLimit_AGL;
						UpperReleaseAltitudeLimit_ASL = (float)num9 + UpperReleaseAltitudeLimit_AGL;
						if (myUnit.DesiredAltitude > UpperReleaseAltitudeLimit_ASL)
						{
							myUnit.DesiredAltitude = UpperReleaseAltitudeLimit_ASL;
						}
						if (myUnit.DesiredAltitude < LowerReleaseAltitudeLimit_ASL)
						{
							myUnit.DesiredAltitude = LowerReleaseAltitudeLimit_ASL;
						}
					}
				}
				if (longestRange_AAWeapon != null && longestRange_AAWeapon.SnapUpDown != 0f && PrimaryTarget != null && PrimaryTarget.AltitudeIsKnown)
				{
					float num10 = myUnit.DesiredAltitude - ((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
					if (Math.Abs(num10) > longestRange_AAWeapon.SnapUpDown)
					{
						if (num10 > 0f)
						{
							myUnit.DesiredAltitude = ((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + longestRange_AAWeapon.SnapUpDown;
						}
						else
						{
							myUnit.DesiredAltitude = ((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - longestRange_AAWeapon.SnapUpDown;
						}
					}
				}
			}
			if (!Information.IsNothing((object)myUnit.Kinematics.DesiredSpeedOverride) && !myUnit.Navigator.IsOnAutoPlannerPlottedCourse)
			{
				return;
			}
			if (!Information.IsNothing((object)myUnit.ActiveMissionOrPackage()) && myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
			{
				if (Information.IsNothing((object)patrol))
				{
					patrol = (Patrol)myUnit.ActiveMissionOrPackage();
				}
				throttle = ((Information.IsNothing((object)num4) || !(num > num5)) ? patrol.AttackThrottle_Aircraft : patrol.TransitThrottle_Aircraft);
			}
			if (!Information.IsNothing((object)throttle))
			{
				myUnit.SetThrottle(throttle.Value);
			}
			else
			{
				method_12().Navigator.SetInterceptThrottle(myUnit.DesiredAltitude, null, CanUseAfterburner: true, airOps.Condition);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100384", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void GetWeaponReleaseLimits(float elapsedTime, Weapon BestWeapon, ref float LowerReleaseAltitudeLimit_ASL, ref float UpperReleaseAltitudeLimit_ASL, ref float LowerReleaseAltitudeLimit_AGL, ref float UpperReleaseAltitudeLimit_AGL, Contact theTarget, short LocalTerrainElevation, double TargetLatitude = 0.0, double TargetLongitude = 0.0)
	{
		if (LocalTerrainElevation == short.MinValue)
		{
			LocalTerrainElevation = Terrain.GetElevation(myUnit.get_Latitude(GlobalVariables.ObjectTrue), myUnit.get_Longitude(GlobalVariables.ObjectTrue), RequestIsFromGUI: false, myUnit.ParentScen);
		}
		if (theTarget == null && TargetLatitude == 0.0 && TargetLongitude == 0.0)
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return;
		}
		float num = 0f;
		num = ((theTarget != null) ? ((float)((Module_Unit.Unit)theTarget).get_LandElevation(AGL: true, RequestIsFromGUI: false, Force: false, myUnit.ParentScen)) : ((float)Terrain.GetElevation(TargetLatitude, TargetLongitude, RequestIsFromGUI: false, myUnit.ParentScen)));
		float val = LocalTerrainElevation;
		float num2 = Math.Max(val2: ((Module_Unit.Unit)myUnit).get_LandElevation_next(AGL: true, elapsedTime), val1: Math.Max(val, num));
		float maxLaunchAlt_AGL = BestWeapon.MaxLaunchAlt_AGL;
		maxLaunchAlt_AGL = method_23(maxLaunchAlt_AGL);
		float maxLaunchAlt_ASL = BestWeapon.MaxLaunchAlt_ASL;
		maxLaunchAlt_ASL = method_23(maxLaunchAlt_ASL);
		if (maxLaunchAlt_AGL != 0f && maxLaunchAlt_ASL == 0f)
		{
			UpperReleaseAltitudeLimit_ASL = maxLaunchAlt_AGL + num2;
			UpperReleaseAltitudeLimit_AGL = maxLaunchAlt_AGL;
		}
		else if (maxLaunchAlt_AGL == 0f && maxLaunchAlt_ASL != 0f)
		{
			UpperReleaseAltitudeLimit_ASL = maxLaunchAlt_ASL;
			UpperReleaseAltitudeLimit_AGL = maxLaunchAlt_ASL - num2;
		}
		else if (maxLaunchAlt_AGL != 0f && maxLaunchAlt_ASL != 0f)
		{
			UpperReleaseAltitudeLimit_ASL = Math.Min(maxLaunchAlt_AGL + num2, maxLaunchAlt_ASL);
			UpperReleaseAltitudeLimit_AGL = Math.Min(maxLaunchAlt_ASL - num2, maxLaunchAlt_AGL);
		}
		if (BestWeapon.MinLaunchAlt_AGL != 0f && BestWeapon.MinLaunchAlt_ASL == 0f)
		{
			LowerReleaseAltitudeLimit_ASL = BestWeapon.MinLaunchAlt_AGL + num2;
			LowerReleaseAltitudeLimit_AGL = BestWeapon.MinLaunchAlt_AGL;
		}
		else if (BestWeapon.MinLaunchAlt_AGL == 0f && BestWeapon.MinLaunchAlt_ASL != 0f)
		{
			LowerReleaseAltitudeLimit_ASL = BestWeapon.MinLaunchAlt_ASL;
			LowerReleaseAltitudeLimit_AGL = BestWeapon.MinLaunchAlt_ASL - num2;
		}
		else if (BestWeapon.MinLaunchAlt_AGL != 0f && BestWeapon.MinLaunchAlt_ASL != 0f)
		{
			LowerReleaseAltitudeLimit_ASL = Math.Max(BestWeapon.MinLaunchAlt_AGL + num2, BestWeapon.MinLaunchAlt_ASL);
			LowerReleaseAltitudeLimit_AGL = Math.Max(BestWeapon.MinLaunchAlt_ASL - num2, BestWeapon.MinLaunchAlt_AGL);
		}
		if (UpperReleaseAltitudeLimit_AGL == 0f)
		{
			UpperReleaseAltitudeLimit_AGL = LowerReleaseAltitudeLimit_AGL * 2f;
		}
		if (UpperReleaseAltitudeLimit_ASL == 0f)
		{
			UpperReleaseAltitudeLimit_ASL = LowerReleaseAltitudeLimit_ASL * 2f;
		}
		if ((double)(UpperReleaseAltitudeLimit_ASL / LowerReleaseAltitudeLimit_ASL) > 1.4)
		{
			LowerReleaseAltitudeLimit_AGL = (float)((double)LowerReleaseAltitudeLimit_AGL * 1.1);
			LowerReleaseAltitudeLimit_ASL = (float)((double)LowerReleaseAltitudeLimit_ASL * 1.1);
			UpperReleaseAltitudeLimit_AGL = (float)((double)UpperReleaseAltitudeLimit_AGL * 0.9);
			UpperReleaseAltitudeLimit_ASL = (float)((double)UpperReleaseAltitudeLimit_ASL * 0.9);
		}
	}

	private float method_23(float float_0)
	{
		if (float_0 == 0f)
		{
			return method_12().Kinematics.GetMaximumAltitude();
		}
		return float_0;
	}

	private void method_24(float float_0)
	{
		try
		{
			Manouver_PurePursuit(float_0, 0f, 0f);
			Doctrine doctrine = default(Doctrine);
			Weapon weapon = default(Weapon);
			if (!myUnit.Kinematics.DesiredSpeedOverride.HasValue)
			{
				float relativeBearing = MathFunctions.GetRelativeBearing(myUnit.CurrentHeading, BearingToUnit_True(PrimaryTarget));
				if (!(relativeBearing > 330f) && relativeBearing >= 30f)
				{
					float num = method_12().Kinematics.CornerVelocity;
					if (myUnit.CurrentSpeed < num)
					{
						myUnit.SetThrottle(ActiveUnit.Throttle.Flank);
					}
					else
					{
						myUnit.DesiredSpeed = num;
					}
				}
				else
				{
					doctrine = myUnit.Doctrine;
					weapon = myUnit.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, CheckIfWithinRange: true, CheckIfWithinAltitude: true, CheckWRA: true, doctrine);
					if (weapon != null)
					{
						ActiveUnit_Weaponry weaponry = myUnit.Weaponry;
						Weapon theWeapon = weapon;
						Contact primaryTarget = PrimaryTarget;
						Sensor SuitableDirectorSensor = null;
						int? ASL_atFiringUnit = default(int?);
						if (weaponry.CanThisWeaponEngageThisTarget(theWeapon, primaryTarget, ref ASL_atFiringUnit, ManualFire: false, IgnoreAircraftOrientation: false, HumanFeedBackNeeded: false, null, ref SuitableDirectorSensor).EvaluationEnum == ActiveUnit_Weaponry.WeaponPrefireChecklistEvaluation.OK)
						{
							if ((double)myUnit.RangeToUnit_Horiz(PrimaryTarget) <= (double)weapon.get_MaxRangeForThisTarget(myUnit, PrimaryTarget, CheckWRA: true, doctrine, ManualFire: false) * 0.5)
							{
								bool flag = default(bool);
								if (PrimaryTarget.IDStatus >= Contact_Base.IdentificationStatus.KnownClass)
								{
									foreach (Mount mount in PrimaryTarget.ActualUnit.Mounts)
									{
										if (mount != null && mount.HasGuns && mount.TargetIsWithinCoverageArc(myUnit, PrimaryTarget.CurrentHeading))
										{
											flag = true;
											break;
										}
									}
								}
								if (flag)
								{
									myUnit.SetThrottle(ActiveUnit.Throttle.Flank);
								}
								else
								{
									myUnit.DesiredSpeed = PrimaryTarget.CurrentSpeed;
								}
							}
							else
							{
								myUnit.SetThrottle(ActiveUnit.Throttle.Flank);
							}
							goto IL_021c;
						}
					}
					myUnit.SetThrottle(ActiveUnit.Throttle.Flank);
				}
			}
			goto IL_021c;
			IL_021c:
			if (myUnit.Kinematics.DesiredAltitudeOverride || !PrimaryTarget.AltitudeIsKnown)
			{
				return;
			}
			if (!method_12().SupportsAttitude_Pitch)
			{
				float num2 = Math.Abs(method_12().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - ((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
				if (num2 == 0f)
				{
					myUnit.DesiredAltitude = ((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
				}
				else if (((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > method_12().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))
				{
					float num3 = method_12().ETA_To_Unit(PrimaryTarget);
					if (num3 > 0f)
					{
						myUnit.DesiredAltitude = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + num2 / num3 * float_0;
					}
					else
					{
						float num4 = myUnit.CurrentSpeed * float_0 / 3600f;
						float num5 = myUnit.RangeToUnit_Horiz(PrimaryTarget);
						myUnit.DesiredAltitude = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + num4 * Math.Abs(num2) / num5;
					}
				}
				else
				{
					float num6 = method_12().ETA_To_Unit(PrimaryTarget);
					if (num6 > 0f)
					{
						myUnit.DesiredAltitude = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - num2 / num6 * float_0;
					}
					else
					{
						float num7 = myUnit.CurrentSpeed * float_0 / 3600f;
						float num8 = myUnit.RangeToUnit_Horiz(PrimaryTarget);
						myUnit.DesiredAltitude = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - num7 * Math.Abs(num2) / num8;
					}
				}
			}
			else
			{
				myUnit.DesiredAltitude = ((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
				Calculate_And_Set_DesiredPitch(((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), myUnit.DesiredAltitude);
			}
			if (doctrine == null)
			{
				doctrine = myUnit.Doctrine;
			}
			if (weapon == null)
			{
				weapon = myUnit.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, CheckIfWithinRange: true, CheckIfWithinAltitude: true, CheckWRA: true, doctrine);
			}
			if (weapon == null || weapon.Type != Weapon._WeaponType.GuidedWeapon)
			{
				return;
			}
			float val = ((Module_Unit.Unit)PrimaryTarget).get_LandElevation(AGL: true, RequestIsFromGUI: false, Force: false, myUnit.ParentScen);
			float val2 = ((Module_Unit.Unit)myUnit).get_LandElevation(AGL: true, RequestIsFromGUI: false, Force: false, myUnit.ParentScen);
			float num9 = Math.Max(val2: ((Module_Unit.Unit)myUnit).get_LandElevation_next(AGL: true, float_0), val1: Math.Max(val2, val));
			float num11 = default(float);
			float num10 = default(float);
			if (weapon.MaxLaunchAlt_AGL != 0f && weapon.MaxLaunchAlt_ASL == 0f)
			{
				num10 = weapon.MaxLaunchAlt_AGL + num9;
				num11 = weapon.MaxLaunchAlt_AGL;
			}
			else if (weapon.MaxLaunchAlt_AGL == 0f && weapon.MaxLaunchAlt_ASL != 0f)
			{
				num10 = weapon.MaxLaunchAlt_ASL;
				num11 = weapon.MaxLaunchAlt_ASL - num9;
			}
			else if (weapon.MaxLaunchAlt_AGL != 0f && weapon.MaxLaunchAlt_ASL != 0f)
			{
				num10 = Math.Min(weapon.MaxLaunchAlt_AGL + num9, weapon.MaxLaunchAlt_ASL);
				num11 = Math.Min(weapon.MaxLaunchAlt_ASL - num9, weapon.MaxLaunchAlt_AGL);
			}
			float num13 = default(float);
			float num12 = default(float);
			if (weapon.MinLaunchAlt_AGL != 0f && weapon.MinLaunchAlt_ASL == 0f)
			{
				num12 = weapon.MinLaunchAlt_AGL + num9;
				num13 = weapon.MinLaunchAlt_AGL;
			}
			else if (weapon.MinLaunchAlt_AGL == 0f && weapon.MinLaunchAlt_ASL != 0f)
			{
				num12 = weapon.MinLaunchAlt_ASL;
				num13 = weapon.MinLaunchAlt_ASL - num9;
			}
			else if (weapon.MinLaunchAlt_AGL != 0f && weapon.MinLaunchAlt_ASL != 0f)
			{
				num12 = Math.Max(weapon.MinLaunchAlt_AGL + num9, weapon.MinLaunchAlt_ASL);
				num13 = Math.Max(weapon.MinLaunchAlt_ASL - num9, weapon.MinLaunchAlt_AGL);
			}
			if (num12 > myUnit.DesiredAltitude)
			{
				myUnit.DesiredAltitude = num12;
			}
			else if (num10 < myUnit.DesiredAltitude)
			{
				myUnit.DesiredAltitude = num10;
			}
			else
			{
				if (myUnit.DesiredAltitude > num10)
				{
					myUnit.DesiredAltitude = num10;
				}
				if (myUnit.DesiredAltitude < num12)
				{
					myUnit.DesiredAltitude = num12;
				}
			}
			if (!myUnit.get_DesiredAltitude_UseTerrainFollowing(myUnit))
			{
				num12 = num9 + num13;
				num10 = num9 + num11;
				if (myUnit.DesiredAltitude > num10)
				{
					myUnit.DesiredAltitude = num10;
				}
				if (myUnit.DesiredAltitude < num12)
				{
					myUnit.DesiredAltitude = num12;
				}
			}
			else if (num13 > myUnit.DesiredAltitude_AGL)
			{
				myUnit.DesiredAltitude_AGL = num13;
			}
			else if (num11 < myUnit.DesiredAltitude_AGL)
			{
				myUnit.DesiredAltitude_AGL = num11;
			}
			else
			{
				if (myUnit.DesiredAltitude_AGL > num11)
				{
					myUnit.DesiredAltitude_AGL = num11;
				}
				if (myUnit.DesiredAltitude_AGL < num13)
				{
					myUnit.DesiredAltitude_AGL = num13;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100385", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal float AltitudeNeededToReachPitchAngle(float theEndPitch)
	{
		float result;
		try
		{
			if (theEndPitch == myUnit.Attitude_Pitch)
			{
				result = 0f;
			}
			else
			{
				float num = 0f;
				float num2 = myUnit.Attitude_Pitch;
				if (num2 <= 0f)
				{
					for (float num3 = myUnit.Kinematics.PitchRate_Positive(); !(num2 >= theEndPitch); num2 += num3)
					{
						num += (float)((double)myUnit.CurrentSpeed * 0.514444 * Math2.Sind(num2));
					}
				}
				else
				{
					float num4 = myUnit.Kinematics.PitchRate_Negative();
					while (num2 > theEndPitch)
					{
						num += (float)((double)myUnit.CurrentSpeed * 0.514444 * Math2.Sind(num2));
						num2 -= num4;
					}
				}
				result = num;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at \u00a89083476587346", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = 0f;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal void CalculateDesiredPitch_NoTargetPoint(float elapsedTime, float theDesiredAlt)
	{
		float num2;
		if (!method_12().HasLostControlPulse_CACHED && method_12().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < (float)Terrain.GlobalMaxTerrainElevation)
		{
			float? num = method_12().get_MinimumSafeHeight(bool_7: false);
			float desiredAltitude = method_12().DesiredAltitude;
			num2 = ((((!num.HasValue) ? ((bool?)null) : new bool?(desiredAltitude < num.GetValueOrDefault())) == true) ? num.Value : theDesiredAlt);
		}
		else
		{
			num2 = theDesiredAlt;
		}
		float num3 = num2 - method_12().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
		if (num3 == 0f)
		{
			myUnit.DesiredPitch = 0f;
		}
		else if (num3 > 0f)
		{
			if (myUnit.Attitude_Pitch < 0f)
			{
				myUnit.DesiredPitch = 0f;
			}
			else if (AltitudeNeededToReachPitchAngle(0f) < num3)
			{
				float num4;
				float num5;
				if (myUnit.DesiredTurnRate == ActiveUnit.TurnRate.Navigation)
				{
					num4 = (float)((double)myUnit.Kinematics.GetMaximumSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Cruise, ValidateAndFixAltitude: false) * 0.514444);
					num5 = myUnit.Kinematics.get_ClimbRate_Nominal(LimitByTrueAirspeed: true);
				}
				else
				{
					num4 = (float)((double)myUnit.Kinematics.GetMaximumSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), myUnit.ThrottleSetting, ValidateAndFixAltitude: false) * 0.514444);
					num5 = myUnit.Kinematics.ClimbRate_Max();
				}
				float val = num5 / num3 * elapsedTime * 2f;
				val = Math.Max(1f, val);
				if (num5 > num4)
				{
					int_2 = 89;
				}
				else if (num4 > 0f)
				{
					int_2 = (int)Math.Round(Math2.Arcsind(num5 / num4) / (double)val);
					if (int_2 > 89)
					{
						int_2 = 89;
					}
				}
				myUnit.DesiredPitch = int_2;
			}
			else if (num3 < 10f && (double)myUnit.Attitude_Pitch < 0.5)
			{
				myUnit.DesiredPitch = myUnit.Attitude_Pitch;
			}
			else
			{
				myUnit.DesiredPitch = 0f;
			}
		}
		else if (AltitudeNeededToReachPitchAngle(0f) > num3)
		{
			float num6;
			float num7;
			if (myUnit.DesiredTurnRate == ActiveUnit.TurnRate.Navigation)
			{
				num6 = (float)((double)myUnit.Kinematics.GetMaximumSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Cruise, ValidateAndFixAltitude: false) * 0.514444);
				num7 = myUnit.Kinematics.DiveRate_Nominal();
			}
			else
			{
				num6 = (float)((double)myUnit.Kinematics.GetMaximumSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), myUnit.ThrottleSetting, ValidateAndFixAltitude: false) * 0.514444);
				num7 = myUnit.Kinematics.DiveRate_Max();
			}
			float val2 = num7 / (0f - num3) * elapsedTime * 2f;
			val2 = Math.Max(1f, val2);
			if (num7 > num6)
			{
				int_3 = -89;
			}
			else if (num6 > 0f)
			{
				int_3 = -(int)Math.Round(Math2.Arcsind(num7 / num6) / (double)val2);
				if (int_3 < -89)
				{
					int_3 = -89;
				}
			}
			myUnit.DesiredPitch = int_3;
		}
		else if (num3 > -10f && (double)myUnit.Attitude_Pitch > -0.5)
		{
			myUnit.DesiredPitch = myUnit.Attitude_Pitch;
		}
		else
		{
			myUnit.DesiredPitch = 0f;
		}
	}

	internal void CalculateDesiredPitch(GeoPoint TargetPoint, float elapsedTime, float theDesiredAlt)
	{
		try
		{
			if (method_12().SupportsAttitude_Pitch)
			{
				if (TargetPoint != null)
				{
					CalculateDesiredPitch(TargetPoint.Latitude, TargetPoint.Longitude);
				}
				else
				{
					CalculateDesiredPitch_NoTargetPoint(elapsedTime, theDesiredAlt);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 9876434676783", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	protected void CalculateDesiredPitch(double TargetLat, double TargetLon)
	{
		if (myUnit.SupportsAttitude_Pitch)
		{
			float num2;
			if (method_12().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < (float)Terrain.GlobalMaxTerrainElevation)
			{
				float? num = method_12().get_MinimumSafeHeight(bool_7: false);
				float desiredAltitude = method_12().DesiredAltitude;
				num2 = ((((!num.HasValue) ? ((bool?)null) : new bool?(desiredAltitude < num.GetValueOrDefault())) == true) ? num.Value : method_12().DesiredAltitude);
			}
			else
			{
				num2 = method_12().DesiredAltitude;
			}
			Calculate_And_Set_DesiredPitch(TargetLat, TargetLon, num2);
		}
	}

	public override void ReturnToBase(float elapsedTime)
	{
		if (myUnit == null || myUnit.Navigator == null)
		{
			return;
		}
		try
		{
			if (method_12().ActiveMissionOrPackage() != null && method_12().ActiveMissionOrPackage().SecondaryAirBase != null)
			{
				method_12().AirOps.set_AssignedHostUnit(PickNewAssignedHost: false, method_12().ActiveMissionOrPackage().SecondaryAirBase);
			}
			if (myUnit.ParentScen.FifthMinuteIsChangingOnThisPulse)
			{
				method_25(elapsedTime);
			}
			if (myUnit.FuelState == ActiveUnit._ActiveUnitFuelState.IgnoreBingoAndJoker)
			{
				myUnit.FuelState = ActiveUnit._ActiveUnitFuelState.None;
			}
			ActiveUnit actualDestinationHost = method_12().AirOps.ActualDestinationHost;
			Aircraft_Navigator navigator;
			bool theAltitude_TerrainFollowing = default(bool);
			ActiveUnit activeUnit;
			bool flag;
			bool flag2;
			int num2;
			float bingoFuelAltitude = default(float);
			float num;
			if (actualDestinationHost != null && !actualDestinationHost.Location.HasZeroCoords)
			{
				navigator = method_12().Navigator;
				if (!navigator.HasReachedLandingAssemblyPoint(actualDestinationHost))
				{
					if (myUnit.FuelState == ActiveUnit._ActiveUnitFuelState.IsBingo)
					{
						if (!Information.IsNothing((object)myUnit.Kinematics.DesiredSpeedOverride) || myUnit.Kinematics.DesiredAltitudeOverride)
						{
							myUnit.Kinematics.DesiredSpeedOverride = null;
							myUnit.Kinematics.DesiredAltitudeOverride = false;
							string text = "";
							if (method_12().IsAircraft && Operators.CompareString(method_12().Name, method_12().UnitClass, false) != 0)
							{
								text = " (" + method_12().UnitClass + ")";
							}
							method_12().AddMessage(method_12().Name + text + " has reached Bingo fuel and cancels altitude and speed overrides. If you want to manually control the speed or altitude for this aircraft, unassign it from the current Bingo fuel state (U hotkey). Please note that if you do, all safety measures will be disabled and you are be responsible for bringing the aircraft safely back to base yourself.", method_12().Name + " cancels throttle/alt overrides (Bingo)", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(method_12().get_Longitude((GlobalVariables.BooleanObject)null), method_12().get_Latitude((GlobalVariables.BooleanObject)null)));
						}
						bingoFuelAltitude = navigator.GetBingoFuelAltitude(ref theAltitude_TerrainFollowing);
						num = myUnit.Kinematics.GetMaximumSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Cruise, ValidateAndFixAltitude: false);
						if (!method_12().FollowingPCThatIsRTB && !method_12().FollowingPCThatIsPathfinderGeneratedAndLeadsToAssignedHost)
						{
							if (method_12().AirOps.Condition != Aircraft_AirOps._AirOpsCondition.Landing_PreTouchdown && method_12().AirOps.Condition != Aircraft_AirOps._AirOpsCondition.EmergencyLanding)
							{
								if (navigator.HasPlottedCourse())
								{
									navigator.ClearPlottedCourse();
								}
								navigator.HeadToLandingAssemblyPoint(elapsedTime, actualDestinationHost, num, bingoFuelAltitude, ref theAltitude_TerrainFollowing);
							}
							return;
						}
						myUnit.Navigator.FollowPlottedCourse(elapsedTime);
						myUnit.DesiredSpeed = num;
						myUnit.SetThrottle(myUnit.Kinematics.GetThrottleSuitableForThisSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (int)Math.Round(myUnit.DesiredSpeed)));
						if (!myUnit.Navigator.HasPlottedCourse() || !myUnit.Navigator.HasFlightPlan || myUnit.Navigator.PlottedCourse[0].Category != Waypoint.WaypointCategory.FlightPlan)
						{
							myUnit.set_DesiredAltitude_UseTerrainFollowing(myUnit, theAltitude_TerrainFollowing);
							if (theAltitude_TerrainFollowing)
							{
								myUnit.DesiredAltitude_AGL = bingoFuelAltitude;
							}
							else
							{
								myUnit.DesiredAltitude = bingoFuelAltitude;
							}
						}
						return;
					}
					activeUnit = ((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false)?.GroupLead;
					flag = false;
					flag2 = false;
					if (method_12().IsGroupWingman() && activeUnit != null && activeUnit.Navigator != null)
					{
						flag = activeUnit.Navigator.PlottedCourse != null && activeUnit.Navigator.PlottedCourse.Count() > 0 && activeUnit.Navigator.PlottedCourse.FirstOrDefault()?.Waypoint_LeadElementWingman == null;
						if (activeUnit.IsRTB)
						{
							goto IL_041c;
						}
						if (activeUnit.Navigator.PathFindingInProgress)
						{
							num2 = 1;
						}
						else
						{
							if (activeUnit.Navigator.HasPathfindingPlottedCourse)
							{
								goto IL_041c;
							}
							Exception ThrownError = null;
							num2 = (Pathfinding.UnitOrFlightPlanHasPFRequestInQueue(activeUnit, null, ref ThrownError) ? 1 : 0);
						}
						goto IL_041d;
					}
					goto IL_0466;
				}
				if (myUnit.IsGroupMember())
				{
					myUnit.DetachUnit(NotifyPlayer: false, ClearPlottedCourse: true, UseFlightplan: false);
				}
				method_12().SetThrottle(ActiveUnit.Throttle.Loiter);
				method_12().DesiredSpeed = method_12().Kinematics.GetMaximumSpeed(method_12().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Loiter, ValidateAndFixAltitude: false);
				method_12().set_DesiredAltitude_UseTerrainFollowing((ActiveUnit)method_12(), value: false);
				method_12().AirOps.EnterLandingQueue(actualDestinationHost);
				return;
			}
			if (!method_12().Navigator.HasPlottedCourse())
			{
				method_12().Kinematics.Loiter(elapsedTime);
			}
			else
			{
				method_12().Navigator.FollowPlottedCourse(elapsedTime);
			}
			return;
			IL_041d:
			flag2 = (byte)num2 != 0;
			if (activeUnit.Status == ActiveUnit._ActiveUnitStatus.WaitForPathfinder)
			{
				flag2 = flag2 || ActiveUnit.get_IsRTB(activeUnit._StatusBefore_WaitForPathfinder);
			}
			if (activeUnit.IsAircraft)
			{
				flag2 = flag2 || ((Aircraft)activeUnit).AirOps.Condition == Aircraft_AirOps._AirOpsCondition.RTB;
			}
			goto IL_0466;
			IL_0466:
			if (method_12().IsGroupWingman() && activeUnit != null && (flag || flag2) && myUnit.Status != ActiveUnit._ActiveUnitStatus.EngagedOffensive)
			{
				method_12().Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
				return;
			}
			if (!myUnit.Kinematics.DesiredSpeedOverride.HasValue)
			{
				if (myUnit.IsGroupWingman() && myUnit.get_ParentGroup(UsingMissionPlanner: false).Kinematics.DesiredSpeedOverride.HasValue)
				{
					num = myUnit.get_ParentGroup(UsingMissionPlanner: false).DesiredSpeed;
					myUnit.SetThrottle(myUnit.Kinematics.GetThrottleSuitableForThisSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), num), num);
				}
				else
				{
					num = myUnit.Kinematics.GetMaximumSpeed(method_12().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Full, ValidateAndFixAltitude: false);
				}
			}
			else
			{
				num = myUnit.Kinematics.DesiredSpeedOverride.Value;
			}
			if (myUnit.Kinematics.DesiredAltitudeOverride)
			{
				bingoFuelAltitude = myUnit.DesiredAltitude;
			}
			else if (myUnit.IsGroupWingman() && myUnit.get_ParentGroup(UsingMissionPlanner: false).Kinematics.DesiredAltitudeOverride && myUnit.get_ParentGroup(UsingMissionPlanner: false).DesiredAltitude != 0f)
			{
				num = myUnit.get_ParentGroup(UsingMissionPlanner: false).DesiredAltitude;
			}
			else
			{
				bingoFuelAltitude = navigator.GetBingoFuelAltitude(ref theAltitude_TerrainFollowing);
			}
			if (myUnit.IsGroupWingman() && myUnit.get_ParentGroup(UsingMissionPlanner: false).Kinematics.DesiredSpeedOverride.HasValue)
			{
				num = myUnit.get_ParentGroup(UsingMissionPlanner: false).DesiredSpeed;
				myUnit.SetThrottle(myUnit.Kinematics.GetThrottleSuitableForThisSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), num), num);
			}
			else if (navigator.HasPlottedCourse() && (FollowingRTB_PlottedCourse() || navigator.PlottedCourse[0].Type == Waypoint.WaypointType.PathfindingPoint))
			{
				myUnit.Navigator.FollowPlottedCourse(elapsedTime);
			}
			else
			{
				navigator.HeadToLandingAssemblyPoint(elapsedTime, actualDestinationHost, num, bingoFuelAltitude, ref theAltitude_TerrainFollowing);
			}
			return;
			IL_041c:
			num2 = 1;
			goto IL_041d;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100386", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_25(float float_0)
	{
		try
		{
			ActiveUnit actualDestinationHost = method_12().AirOps.ActualDestinationHost;
			if (actualDestinationHost != null)
			{
				(bool, string) tuple = method_12().AirOps.ThisUnitCanHostMe(actualDestinationHost, HumanFeedbackNeeded: true);
				if (actualDestinationHost.IsMorituri || !tuple.Item1)
				{
					string text = "";
					if (method_12().IsAircraft && Operators.CompareString(method_12().Name, method_12().UnitClass, false) != 0)
					{
						text = " (" + method_12().UnitClass + ")";
					}
					method_12().AddMessage(method_12().Name + text + " cannot be hosted by its current assigned base (" + actualDestinationHost.Name + "). Reason: " + tuple.Item2, method_12().Name + " cannot be hosted by its current base", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(method_12().get_Longitude((GlobalVariables.BooleanObject)null), method_12().get_Latitude((GlobalVariables.BooleanObject)null)));
					method_12().AirOps.PickNewAssignedHost_NearestToThisUnit(actualDestinationHost);
				}
			}
			else
			{
				method_12().AirOps.PickNewAssignedHost_Nearest();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100387", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private Contact method_26()
	{
		if (PrimaryTarget != null)
		{
			return PrimaryTarget;
		}
		Contact contact = null;
		if (myUnit.get_ParentGroup(UsingMissionPlanner: false) != null)
		{
			List<ActiveUnit> list = myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values.ToList();
			foreach (ActiveUnit item in list)
			{
				if (item != null && item != myUnit && item.Status == ActiveUnit._ActiveUnitStatus.EngagedOffensive && item.AI.PrimaryTarget != null && myUnit.RangeToUnit_Horiz(item) < 50f && (contact == null || myUnit.RangeToUnit_Horiz(item.AI.PrimaryTarget) < myUnit.RangeToUnit_Horiz(contact)))
				{
					contact = item.AI.PrimaryTarget;
				}
			}
		}
		return contact;
	}

	private bool method_27(Contact contact_5)
	{
		int result;
		if (myUnit.get_ParentGroup(UsingMissionPlanner: false) != null)
		{
			if (!myUnit.get_ParentGroup(UsingMissionPlanner: false).IsPerformingStandoffAttack)
			{
				result = 0;
				goto IL_006d;
			}
			if (!myUnit.IsPerformingStandoffAttack)
			{
				if (contact_5 != null)
				{
					int result2;
					if (!IsClearedToEngageThisTarget(contact_5))
					{
						result2 = 1;
					}
					else
					{
						Side side = myUnit.get_UnitSide(SetSideOnly: false);
						ref ActiveUnit theAttacker = ref myUnit;
						TargetingEntry._TargetingBehavior theTargetBehaviour = TargetingEntry._TargetingBehavior.AutoTargeted;
						if (side.NumberOfAnyWeaponTypesOnThisUnitLeftToFireAtThisTarget(ref theAttacker, ref contact_5, ref theTargetBehaviour) >= 1)
						{
							result = 0;
							goto IL_006d;
						}
						result2 = 1;
					}
					return (byte)result2 != 0;
				}
				return true;
			}
		}
		result = 0;
		goto IL_006d;
		IL_006d:
		return (byte)result != 0;
	}

	private void method_28(Contact contact_5, float float_0, ref Weapon weapon_1, bool bool_0 = false)
	{
		_Closure$__62-0 arg = default(_Closure$__62-0);
		_Closure$__62-0 CS$<>8__locals18 = new _Closure$__62-0(arg);
		CS$<>8__locals18.$VB$Me = this;
		CS$<>8__locals18.$VB$Local_theTarget = contact_5;
		try
		{
			if (CS$<>8__locals18.$VB$Local_theTarget == null || (!CS$<>8__locals18.$VB$Local_theTarget.IsLandContact && !CS$<>8__locals18.$VB$Local_theTarget.IsShipContact))
			{
				return;
			}
			List<Weapon> list = new List<Weapon>();
			if (!bool_0 && method_12().Loadout.Weapons.Where([SpecialName] (WeaponRec WR) => WR.get_ReferenceWeapon(myUnit.ParentScen).IsMissile && WR.get_ReferenceWeapon(myUnit.ParentScen).IsStandOff() && WR.CurrentLoad > 0).Count() > 0)
			{
				float num = 50f;
				IEnumerable<Weapon> enumerable = from theW in method_12().Weaponry.AllDistinctWeaponsAboard_Actual()
					where theW.IsMissile && theW.IsStandOff()
					select theW;
				if (!Information.IsNothing((object)enumerable) && enumerable.Count() > 0)
				{
					float num2 = enumerable.Select([SpecialName] (Weapon theW) => theW.get_MaxRangeForThisTarget(CS$<>8__locals18.$VB$Me.myUnit, CS$<>8__locals18.$VB$Local_theTarget, CheckWRA: true, CS$<>8__locals18.$VB$Me.myUnit.Doctrine, ManualFire: false)).Max();
					float num3 = method_12().RangeToUnit_Horiz(CS$<>8__locals18.$VB$Local_theTarget);
					if (num3 > num || (double)num3 > (double)num2 * 0.75)
					{
						return;
					}
				}
			}
			foreach (Weapon item in myUnit.ParentScen.GuidedWeaponsInAir)
			{
				if (item.AI.PrimaryTarget != CS$<>8__locals18.$VB$Local_theTarget)
				{
					continue;
				}
				if (item.FiringParent != method_12())
				{
					if (method_12().IsGroupMember() && item != null)
					{
						ActiveUnit firingParent = item.FiringParent;
						if (firingParent != null && firingParent.IsGroupMember() && item.FiringParent.get_ParentGroup(UsingMissionPlanner: false) == ((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false))
						{
							list.Add(item);
						}
					}
					continue;
				}
				list.Add(item);
				if (!item.Flags.TerminalIllumination && !item.Flags.IlluminateAtLaunch)
				{
					if (item.Guidance == Weapon.WeaponGuidanceType.CommandGuided_Datalinked)
					{
						weapon_1 = item;
					}
				}
				else
				{
					weapon_1 = item;
				}
				break;
			}
			int num4;
			if (list.Count != 0)
			{
				num4 = 0;
			}
			else
			{
				if (!bool_0)
				{
					return;
				}
				num4 = 0;
			}
			bool flag = (byte)num4 != 0;
			List<WeaponSalvo> list2 = new List<WeaponSalvo>(myUnit.get_UnitSide(SetSideOnly: false).WeaponSalvos);
			foreach (WeaponSalvo item2 in list2)
			{
				WeaponSalvo.Shooter[] shootersList = item2.ShootersList;
				foreach (WeaponSalvo.Shooter shooter in shootersList)
				{
					if (Operators.CompareString(shooter.ShooterObjectID, myUnit.ObjectID, false) == 0)
					{
						if (shooter.QuantityAssigned - shooter.QuantityFired > 0)
						{
							flag = true;
						}
						break;
					}
				}
				if (flag)
				{
					break;
				}
			}
			if (flag && method_12().Weaponry.CanPhysicallyAttackThisTargetRightNow(CS$<>8__locals18.$VB$Local_theTarget, IgnoreAircraftOrientation: true, IgnoreWeaponRecTimeToFire: true))
			{
				return;
			}
			Weapon weapon = null;
			if (list.Count > 0)
			{
				foreach (Weapon item3 in list)
				{
					Weapon theWeapon = item3;
					if (weapon == null || theWeapon.TimeSinceLaunch < weapon.TimeSinceLaunch)
					{
						weapon = theWeapon;
					}
					if ((!theWeapon.Flags.TerminalIllumination && !theWeapon.Flags.IlluminateAtLaunch) || myUnit.Sensory.IsIlluminatingThisContact(theWeapon.AI.PrimaryTarget) || (theWeapon.Flags.SupportsBuddyIllumination && theWeapon.AttemptBuddyIllumination()))
					{
						continue;
					}
					Module_Unit.Unit.LOSCheckResult? LOS_Exists_Visual = null;
					bool? LOS_Exists_Radar = null;
					bool? LOS_Exists_RadarSW = null;
					bool? LOS_Exists_Sonar = null;
					ActiveUnit_Sensory sensory = myUnit.Sensory;
					Contact primaryTarget = theWeapon.AI.PrimaryTarget;
					Weapon theWeapon2 = theWeapon;
					Sensor SuitableIlluminator = null;
					if (sensory.CanIlluminateThisContactForThisWeapon(primaryTarget, theWeapon2, ref SuitableIlluminator, ref LOS_Exists_Radar, ref LOS_Exists_RadarSW, ref LOS_Exists_Visual, ref LOS_Exists_Sonar))
					{
						continue;
					}
					ActiveUnit actualUnit = theWeapon.AI.PrimaryTarget.ActualUnit;
					if (Information.IsNothing((object)actualUnit))
					{
						continue;
					}
					List<ActiveUnit> list3 = null;
					Sensor[] sensors_Cached = myUnit.Sensors_Cached;
					foreach (Sensor sensor in sensors_Cached)
					{
						if (sensor.Status != PlatformComponent._ComponentStatus.Operational || !sensor.CanIlluminateForThisWeapon(ref theWeapon) || !sensor.HasFireControlChannelAvailable())
						{
							continue;
						}
						if (sensor.Type == Sensor.Sensor_Type.Radar && Information.IsNothing((object)list3))
						{
							list3 = myUnit.Sensory.get_JammerUnitsAffectingMe(FactorHavingActiveRadars: false);
						}
						switch (sensor.CanIlluminateTarget(myUnit, actualUnit, Module_Unit.RangeToUnit_Slant(myUnit, theWeapon.AI.PrimaryTarget), list3, myUnit.IsShip, WeaponIsAirborne: false, ref LOS_Exists_Radar, ref LOS_Exists_RadarSW, ref LOS_Exists_Visual, ref LOS_Exists_Sonar))
						{
						case Sensor.SensorDetectionCheckResult.Fail_NoLOS_Terrain:
						case Sensor.SensorDetectionCheckResult.Fail_NoLOS_Horizon:
							myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, Module_Unit.BearingToUnit_True(myUnit, theWeapon.AI.PrimaryTarget));
							if (!myUnit.Kinematics.DesiredAltitudeOverride)
							{
								myUnit.DesiredAltitude = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + myUnit.Kinematics.ClimbRate_Actual(method_12().Attitude_Pitch) * float_0 * 2f;
							}
							return;
						case Sensor.SensorDetectionCheckResult.Fail_OutsideCoverageArc:
							myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, Module_Unit.BearingToUnit_True(myUnit, theWeapon.AI.PrimaryTarget));
							return;
						case Sensor.SensorDetectionCheckResult.Fail_OutOfRange:
						case Sensor.SensorDetectionCheckResult.Fail_NotEnoughReturn:
						case Sensor.SensorDetectionCheckResult.Fail_Other:
							myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, Module_Unit.BearingToUnit_True(myUnit, theWeapon.AI.PrimaryTarget));
							return;
						}
					}
				}
			}
			if (myUnit.IsGroupWingman() && myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.IsPerformingStandoffAttack)
			{
				myUnit.IsPerformingStandoffAttack = true;
				myUnit.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(float_0);
				return;
			}
			float num7 = Module_Unit.BearingToUnit_True(CS$<>8__locals18.$VB$Local_theTarget, method_12());
			float num8 = Math2.NormalizeBearing(num7 + 90f);
			float num9 = Math2.NormalizeBearing(num7 - 90f);
			if (!myUnit.Navigator.HasPlottedCourse() && (!myUnit.IsGroupMember() || !myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.HasPlottedCourse()))
			{
				float num10 = 50f;
				float num11 = 20f;
				float originalBearing = myUnit.CurrentHeading;
				Geopoint_Struct thePoint = default(Geopoint_Struct);
				if (myUnit.Navigator.HasFlightPlan)
				{
					Waypoint[] flightPlan = myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan;
					foreach (Waypoint waypoint in flightPlan)
					{
						if (waypoint.Type == Waypoint.WaypointType.WeaponLaunch)
						{
							thePoint = waypoint.ToGeopoint_Struct();
							break;
						}
					}
				}
				if (thePoint.HasZeroCoords && weapon != null)
				{
					thePoint = weapon.LaunchPoint.ToGeopoint_Struct();
				}
				if (thePoint.RangeToPoint_Horiz(((Module_Unit.Unit)CS$<>8__locals18.$VB$Local_theTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)CS$<>8__locals18.$VB$Local_theTarget).get_Latitude((GlobalVariables.BooleanObject)null)) > num10)
				{
					num11 += thePoint.RangeToPoint_Horiz(((Module_Unit.Unit)CS$<>8__locals18.$VB$Local_theTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)CS$<>8__locals18.$VB$Local_theTarget).get_Latitude((GlobalVariables.BooleanObject)null)) - num10;
				}
				if (!thePoint.HasZeroCoords && Module_Unit.RangeToPoint_Horiz(myUnit, thePoint) > num11)
				{
					originalBearing = Module_Unit.BearingToPoint_True(myUnit, thePoint.Latitude, thePoint.Longitude);
				}
				if (Math.Abs(MathFunctions.AngularDifference(originalBearing, num8)) < Math.Abs(MathFunctions.AngularDifference(originalBearing, num9)))
				{
					((ActiveUnit)method_12()).set_DesiredHeading(ActiveUnit.TurnRate.Max, num8);
				}
				else
				{
					((ActiveUnit)method_12()).set_DesiredHeading(ActiveUnit.TurnRate.Max, num9);
				}
				myUnit.IsPerformingStandoffAttack = true;
			}
			else
			{
				Waypoint waypoint2 = ((!myUnit.Navigator.HasPlottedCourse()) ? ((myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlottedCourse[0].Type != Waypoint.WaypointType.Target && myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlottedCourse[0].Type != Waypoint.WaypointType.WeaponTarget) ? myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlottedCourse[0] : ((myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlottedCourse.Count() <= 1) ? myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlottedCourse[0] : myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlottedCourse[1])) : ((myUnit.Navigator.PlottedCourse[0].Type != Waypoint.WaypointType.Target && myUnit.Navigator.PlottedCourse[0].Type != Waypoint.WaypointType.WeaponTarget) ? myUnit.Navigator.PlottedCourse[0] : ((myUnit.Navigator.PlottedCourse.Count() <= 1) ? myUnit.Navigator.PlottedCourse[0] : myUnit.Navigator.PlottedCourse[1])));
				float num13 = MathFunctions.AngularDifference(Math2.CalcAzimuth(((Module_Unit.Unit)CS$<>8__locals18.$VB$Local_theTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)CS$<>8__locals18.$VB$Local_theTarget).get_Longitude((GlobalVariables.BooleanObject)null), waypoint2.Latitude, waypoint2.Longitude), num7);
				if (num13 > 0f)
				{
					if (num13 < 60f)
					{
						if (Math.Abs(MathFunctions.AngularDifference(myUnit.CurrentHeading, num8)) < 90f)
						{
							((ActiveUnit)method_12()).set_DesiredHeading(ActiveUnit.TurnRate.Max, num8);
						}
						else
						{
							((ActiveUnit)method_12()).set_DesiredHeading(ActiveUnit.TurnRate.Max, num9);
						}
					}
					else
					{
						((ActiveUnit)method_12()).set_DesiredHeading(ActiveUnit.TurnRate.Max, num9);
					}
				}
				else if (num13 > -60f)
				{
					if (Math.Abs(MathFunctions.AngularDifference(myUnit.CurrentHeading, num9)) < 90f)
					{
						((ActiveUnit)method_12()).set_DesiredHeading(ActiveUnit.TurnRate.Max, num9);
					}
					else
					{
						((ActiveUnit)method_12()).set_DesiredHeading(ActiveUnit.TurnRate.Max, num8);
					}
				}
				else
				{
					((ActiveUnit)method_12()).set_DesiredHeading(ActiveUnit.TurnRate.Max, num8);
				}
				myUnit.IsPerformingStandoffAttack = true;
			}
			if (!GlobalVariables.AI_REWORK && myUnit.IsPerformingStandoffAttack && myUnit.get_ParentGroup(UsingMissionPlanner: false) != null && myUnit != myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead)
			{
				myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 1007843634777711", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void CalculateDesiredRoll()
	{
		if (myUnit == null)
		{
			return;
		}
		float relativeBearing = MathFunctions.GetRelativeBearing(myUnit.CurrentHeading, myUnit.DesiredHeading);
		bool flag;
		if (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < (float)Terrain.GlobalMaxTerrainElevation && myUnit.CurrentAltitude_AGL < 500f)
		{
			flag = false;
		}
		else
		{
			ActiveUnit._ActiveUnitStatus status = myUnit.Status;
			flag = status - 2 <= ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
		}
		float num = 89f;
		if (!method_12().IsHelicopter)
		{
			switch (method_12().VisualSizeClass)
			{
			case GlobalVariables.TargetVisualSizeClass.Stealthy:
			case GlobalVariables.TargetVisualSizeClass.Small:
			case GlobalVariables.TargetVisualSizeClass.Medium:
				num = 89f;
				break;
			case GlobalVariables.TargetVisualSizeClass.Large:
				num = 70f;
				break;
			case GlobalVariables.TargetVisualSizeClass.VLarge:
				num = 45f;
				break;
			}
		}
		else
		{
			num = 60f;
		}
		if (relativeBearing == 0f)
		{
			myUnit.DesiredRoll = 0f;
		}
		else if (relativeBearing > 0f && relativeBearing <= 40f)
		{
			myUnit.DesiredRoll = 4f * relativeBearing;
		}
		else if (relativeBearing > 40f && relativeBearing <= 180f)
		{
			myUnit.DesiredRoll = ((!flag) ? num : 90f);
		}
		else if (relativeBearing > 180f && relativeBearing <= 320f)
		{
			myUnit.DesiredRoll = (flag ? (-90f) : (0f - num));
		}
		else
		{
			myUnit.DesiredRoll = -4f * (360f - relativeBearing);
		}
		if (method_12().Kinematics.Current_G_StrainingMode == Aircraft_Kinematics.G_Straining_Mode.Recovering)
		{
			num = 45f;
		}
		if (myUnit.DesiredRoll > num)
		{
			myUnit.DesiredRoll = num;
		}
		if (myUnit.DesiredRoll < 0f - num)
		{
			myUnit.DesiredRoll = 0f - num;
		}
	}

	public override void ManouverTowardsTarget(float elapsedTime)
	{
		try
		{
			if (PrimaryTarget == null || GetTargetAmbiguity(PrimaryTarget, 50f) == AmbiguityLevel.ExtremelyAmbiguous)
			{
				return;
			}
			if (PrimaryTarget.Type == Contact_Base.ContactType.Air)
			{
				if (method_33())
				{
					method_42();
					return;
				}
				if (NeedToCrank())
				{
					method_41();
					return;
				}
				if (method_32(PrimaryTarget))
				{
					method_41(bool_0: true);
					return;
				}
			}
			if (method_30())
			{
				return;
			}
			Weapon theW = null;
			float buffer_Distance_nm = 0f;
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			Misc.PostureStance postureStance = Misc.PostureStance.Unknown;
			Sensor sensor = null;
			bool AllowAfterburner = false;
			if (PrimaryTarget != null)
			{
				theW = myUnit.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, CheckIfWithinRange: true, CheckIfWithinAltitude: true, CheckWRA: true, myUnit.Doctrine, excludeChaffsAndCounterMeasures: true);
				if (theW == null)
				{
					theW = myUnit.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, CheckIfWithinRange: false, CheckIfWithinAltitude: false, CheckWRA: true, myUnit.Doctrine, excludeChaffsAndCounterMeasures: true);
				}
				if (theW != null)
				{
					buffer_Distance_nm = theW.MinRangeForTarget(PrimaryTarget);
					num = theW.get_MaxRangeForThisTarget(myUnit, PrimaryTarget, CheckWRA: false, (Doctrine)null, ManualFire: false);
				}
				ActiveUnit_Sensory sensory = myUnit.Sensory;
				Contact primaryTarget = PrimaryTarget;
				Sensor[] theSensorList = null;
				PooledList<Sensor> longestRange_SensorForContact = sensory.GetLongestRange_SensorForContact(primaryTarget, ActiveCapableSensorsOnly: true, EmmittingSensorsOnly: true, OnlyOperatingSensors: true, OnlySensorsScanningThisPulse: false, ref theSensorList);
				if (longestRange_SensorForContact != null)
				{
					sensor = longestRange_SensorForContact.FirstOrDefault();
					longestRange_SensorForContact.Dispose();
				}
				if (sensor != null)
				{
					num2 = sensor.maxRange;
				}
				num3 = myUnit.RangeToUnit_Horiz(PrimaryTarget);
				postureStance = PrimaryTarget.get_Stance(myUnit.get_UnitSide(SetSideOnly: false));
			}
			if (PrimaryTarget.HeadingIsKnown && PrimaryTarget.CurrentSpeed > 0f)
			{
				if (Math.Abs(Math.Abs(MathFunctions.AngularDifference(PrimaryTarget.CurrentHeading, Module_Unit.BearingToUnit_True(PrimaryTarget, myUnit)))) <= 90f)
				{
					if (!method_12().Weaponry.IsGuidingWeaponsOntoThisContact(PrimaryTarget))
					{
						if (PrimaryTarget?.ActualUnit?.AI?.PrimaryTarget?.ActualUnit == method_12())
						{
							Manouver_PurePursuit(elapsedTime, 10f, buffer_Distance_nm);
						}
						else if ((postureStance != Misc.PostureStance.Unfriendly && postureStance != Misc.PostureStance.Hostile) || (!(num > num3) && num2 <= num3))
						{
							Manouver_InterceptCourse(elapsedTime, null, ref AllowAfterburner);
						}
						else
						{
							Manouver_PurePursuit(elapsedTime, 10f, buffer_Distance_nm);
						}
					}
					else
					{
						Manouver_PurePursuit(elapsedTime, 10f, buffer_Distance_nm);
					}
				}
				else
				{
					Manouver_PurePursuit(elapsedTime, 10f, buffer_Distance_nm);
				}
			}
			else
			{
				Manouver_PurePursuit(elapsedTime, 10f, buffer_Distance_nm);
			}
			valueTuple_0 = (null, -1f, false);
			TurnToUnmaskPrimaryWeapon(ref theW, PrimaryTarget, ref valueTuple_0);
			Weapon weapon_ = null;
			bool flag = method_27(PrimaryTarget);
			if (IsClearedToEngageThisTarget(PrimaryTarget) || flag)
			{
				byte? b = (byte?)myUnit.Doctrine.get_MaintainStandoff(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
				if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
				{
					Contact contact = PrimaryTarget;
					bool bool_ = false;
					if (contact != null)
					{
						if (flag && !ContinueStandoffAttackAgainstThisTargetToMeetWRA(contact, null, RequireFlightPlan: false))
						{
							bool_ = true;
						}
					}
					else
					{
						contact = method_26();
						bool_ = true;
					}
					method_28(contact, elapsedTime, ref weapon_, bool_);
				}
			}
			if (myUnit.Navigator.bool_0 && !PathBlockCheckInProgress)
			{
				PathBlockCheckInProgress = true;
				Task.Factory.StartNew([SpecialName] () =>
				{
					method_40(elapsedTime, bool_0: true);
				});
			}
			else if (myUnit.Navigator.HasPathfindingPlottedCourse)
			{
				myUnit.Navigator.FollowPlottedCourse(elapsedTime);
			}
			Aircraft_AirOps airOps;
			if (PrimaryTarget.Type == Contact_Base.ContactType.Submarine && PrimaryTarget.UncertaintyArea != null)
			{
				airOps = method_12().AirOps;
				if (!method_12().Weaponry.HaveSuitableWeaponForAmbigousTarget(PrimaryTarget, CheckCanShootRightNow: false))
				{
					if (!method_12().Navigator.IsOnLocalizationRun)
					{
						if (method_12().Navigator.HasPlottedCourse())
						{
							byte? b = (byte?)method_12().Doctrine.get_IgnorePlottedCourse(method_12().ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false);
							if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) != true)
							{
								goto IL_0567;
							}
						}
						method_12().Navigator.PlotLocalizationCourse();
					}
					goto IL_0567;
				}
				if (!method_12().Navigator.HasPlottedCourse())
				{
					if (Information.IsNothing((object)myUnit.Kinematics.DesiredSpeedOverride) && !myUnit.IsUsingDippingSonar())
					{
						method_12().SetThrottle(ActiveUnit.Throttle.Full);
					}
				}
				else
				{
					byte? b = (byte?)myUnit.Doctrine.get_IgnorePlottedCourse(myUnit.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false);
					if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) == true)
					{
						method_12().Navigator.FollowPlottedCourse(elapsedTime);
					}
				}
			}
			if (!myUnit.Kinematics.DesiredAltitudeOverride)
			{
				if (IsClearedToEngageThisTarget(PrimaryTarget))
				{
					if (weapon_ == null && theW == null)
					{
						method_12().Navigator.SetInterceptAltitude(method_12().AirOps.Condition);
					}
					else
					{
						OptimizeAltSpeedForNextEngagement(elapsedTime, weapon_, theW);
					}
				}
				else if (theW != null && method_12().AssignedMissionOrPackage() != null && method_12().AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
				{
					Strike strike = (Strike)method_12().AssignedMissionOrPackage();
					float LowerReleaseAltitudeLimit_ASL = 0f;
					float UpperReleaseAltitudeLimit_ASL = 0f;
					float LowerReleaseAltitudeLimit_AGL = 0f;
					float UpperReleaseAltitudeLimit_AGL = 0f;
					GetWeaponReleaseLimits(elapsedTime, theW, ref LowerReleaseAltitudeLimit_ASL, ref UpperReleaseAltitudeLimit_ASL, ref LowerReleaseAltitudeLimit_AGL, ref UpperReleaseAltitudeLimit_AGL, PrimaryTarget, short.MinValue);
					if (!(strike.SpecificTargets.Contains(PrimaryTarget) | strike.SpecificTargets.Contains(PrimaryTarget.ActualUnit)))
					{
						if (PrimaryTarget.IDStatus < Contact_Base.IdentificationStatus.KnownClass)
						{
							method_34(AllowAfterburner);
						}
						else
						{
							method_29(LowerReleaseAltitudeLimit_AGL, UpperReleaseAltitudeLimit_AGL);
						}
					}
					else
					{
						method_29(LowerReleaseAltitudeLimit_AGL, UpperReleaseAltitudeLimit_AGL);
					}
				}
			}
			if (Math.Abs(MathFunctions.AngularDifference(method_12().CurrentHeading, ((ActiveUnit)method_12()).DesiredHeading)) > 90f)
			{
				int cornerVelocity = method_12().Kinematics.CornerVelocity;
				if (method_12().CurrentSpeed > (float)cornerVelocity)
				{
					method_12().DesiredSpeed = cornerVelocity;
					method_12().SetThrottle(method_12().Kinematics.GetThrottleSuitableForThisSpeed(method_12().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), cornerVelocity));
				}
			}
			return;
			IL_0567:
			if ((myUnit.AssignedMissionOrPackage() != null && myUnit.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike) & myUnit.Navigator.HasFlightPlan)
			{
				method_12().Navigator.FollowPlottedCourse(elapsedTime);
			}
			if (!myUnit.Kinematics.DesiredSpeedOverride.HasValue && !myUnit.IsUsingDippingSonar())
			{
				method_12().SetThrottle(ActiveUnit.Throttle.Full);
			}
			if (!myUnit.Kinematics.DesiredAltitudeOverride)
			{
				if (myUnit.ActiveMissionOrPackage() == null)
				{
					method_12().Navigator.SetStrikeMissionOrUnassignedAltitude();
				}
				else if (myUnit.ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Patrol && myUnit.ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Mining && myUnit.ActiveMissionOrPackage().MissionClass != Mission._MissionClass.MineClearing)
				{
					method_12().Navigator.SetStrikeMissionOrUnassignedAltitude();
				}
				else
				{
					method_12().Navigator.SetPatrolAltitude(PursueContact: true, airOps.Condition);
				}
			}
			OptimizeAltSpeedForNextEngagement(elapsedTime, weapon_, theW);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100388", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_29(float float_0, float float_1)
	{
		if (method_12().Navigator.PlottedCourse.Count() > 0 && method_12().Navigator.PlottedCourse[0].DesiredAltitude.HasValue)
		{
			method_12().DesiredAltitude = method_12().Navigator.PlottedCourse[0].DesiredAltitude.Value;
		}
		else if (method_12().Navigator.PlottedCourse.Count() > 0)
		{
			if (float_1 == 0f)
			{
				method_12().Navigator.PlottedCourse[0].DesiredAltitude = float_0;
			}
			else
			{
				method_12().Navigator.PlottedCourse[0].DesiredAltitude = (float_0 + float_1) / 2f;
			}
		}
		else
		{
			method_12().DesiredAltitude = (float_0 + float_1) / 2f;
		}
	}

	private bool method_30()
	{
		bool result;
		try
		{
			int num;
			int num2;
			if (myUnit.Status == ActiveUnit._ActiveUnitStatus.EngagedOffensive)
			{
				if (myUnit.Status != ActiveUnit._ActiveUnitStatus.EngagedDefensive)
				{
					if (myUnit.Navigator.HasFlightPlan && myUnit.Navigator.HasPlottedCourse())
					{
						goto IL_00be;
					}
					if (!myUnit.IsGroupWingman())
					{
						goto IL_0724;
					}
					if (Information.IsNothing((object)myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead))
					{
						num = 0;
					}
					else if (!myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.HasFlightPlan)
					{
						num = 0;
					}
					else
					{
						if (myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.HasPlottedCourse())
						{
							goto IL_00be;
						}
						num = 0;
					}
					goto IL_0725;
				}
				num2 = 0;
			}
			else
			{
				num2 = 0;
			}
			result = (byte)num2 != 0;
			goto end_IL_0001;
			IL_0725:
			result = (byte)num != 0;
			goto end_IL_0001;
			IL_00be:
			Waypoint TargetWaypoint;
			DateTime? previousWaypointTime;
			if (!myUnit.Navigator.HasPlottedCourse())
			{
				TargetWaypoint = myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.PlottedCourse[0];
				previousWaypointTime = myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.PreviousWaypointTime;
			}
			else
			{
				TargetWaypoint = myUnit.Navigator.PlottedCourse[0];
				previousWaypointTime = myUnit.Navigator.PreviousWaypointTime;
			}
			if ((TargetWaypoint.Type != Waypoint.WaypointType.Target && TargetWaypoint.Type != Waypoint.WaypointType.WeaponTarget) || (TargetWaypoint.AttackMethod != Mission._AttackMethod.EchelonAtActionPoint && TargetWaypoint.AttackMethod != Mission._AttackMethod.SplitAtActionPoint) || !((TargetWaypoint.Separation_Time > 0f) & (TargetWaypoint.SpacingManeuver_Time > 0f)))
			{
				goto IL_0724;
			}
			DateTime? dateTime = default(DateTime?);
			if (Information.IsNothing((object)previousWaypointTime))
			{
				if (!Information.IsNothing((object)TargetWaypoint.Time_Zulu))
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					dateTime = TargetWaypoint.Time_Zulu;
				}
			}
			else
			{
				dateTime = previousWaypointTime.Value.AddSeconds(TargetWaypoint.Leg_Time_Straight + TargetWaypoint.Leg_Time_Turn + TargetWaypoint.Hold_Time + TargetWaypoint.Station_Time + TargetWaypoint.SpacingManeuver_Time);
			}
			if (!Information.IsNothing((object)dateTime))
			{
				switch (myUnit.FlightRole)
				{
				case Mission.Flight.FlightElement.LeadElement:
					if (myUnit.IsGroupLead())
					{
						dateTime = dateTime.Value.AddSeconds((float)(myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Count - 1) * TargetWaypoint.Separation_Time);
					}
					break;
				case Mission.Flight.FlightElement.LeadElementWingman:
					if (myUnit.IsGroupLead())
					{
						dateTime = dateTime.Value.AddSeconds((float)(myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Count - 1) * TargetWaypoint.Separation_Time);
					}
					else
					{
						if (!myUnit.IsGroupMember())
						{
							break;
						}
						int num5 = 0;
						for (int k = myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Count - 1; k >= 0; k += -1)
						{
							ActiveUnit activeUnit3 = myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values.ElementAtOrDefault(k);
							if (!activeUnit3.IsGroupLead())
							{
								if (activeUnit3 == myUnit)
								{
									dateTime = dateTime.Value.AddSeconds((float)num5 * TargetWaypoint.Separation_Time);
									break;
								}
								num5++;
							}
						}
					}
					break;
				case Mission.Flight.FlightElement.SecondElement:
					if (myUnit.IsGroupLead())
					{
						dateTime = dateTime.Value.AddSeconds((float)(myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Count - 1) * TargetWaypoint.Separation_Time);
					}
					else
					{
						if (!myUnit.IsGroupMember())
						{
							break;
						}
						int num6 = 0;
						for (int l = myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Count - 1; l >= 0; l += -1)
						{
							ActiveUnit activeUnit4 = myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values.ElementAtOrDefault(l);
							if (!activeUnit4.IsGroupLead())
							{
								if (activeUnit4 == myUnit)
								{
									dateTime = dateTime.Value.AddSeconds((float)num6 * TargetWaypoint.Separation_Time);
									break;
								}
								num6++;
							}
						}
					}
					break;
				case Mission.Flight.FlightElement.SecondElementWingman:
					if (!myUnit.IsGroupLead())
					{
						if (!myUnit.IsGroupMember())
						{
							break;
						}
						int num4 = 0;
						for (int j = myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Count - 1; j >= 0; j += -1)
						{
							ActiveUnit activeUnit2 = myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values.ElementAtOrDefault(j);
							if (!activeUnit2.IsGroupLead())
							{
								if (activeUnit2 == myUnit)
								{
									dateTime = dateTime.Value.AddSeconds((float)num4 * TargetWaypoint.Separation_Time);
									break;
								}
								num4++;
							}
						}
					}
					else
					{
						dateTime = dateTime.Value.AddSeconds((float)(myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Count - 1) * TargetWaypoint.Separation_Time);
					}
					break;
				case Mission.Flight.FlightElement.ThirdElement:
					if (!myUnit.IsGroupLead())
					{
						if (!myUnit.IsGroupMember())
						{
							break;
						}
						int num7 = 0;
						for (int m = myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Count - 1; m >= 0; m += -1)
						{
							ActiveUnit activeUnit5 = myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values.ElementAtOrDefault(m);
							if (!activeUnit5.IsGroupLead())
							{
								if (activeUnit5 == myUnit)
								{
									dateTime = dateTime.Value.AddSeconds((float)num7 * TargetWaypoint.Separation_Time);
									break;
								}
								num7++;
							}
						}
					}
					else
					{
						dateTime = dateTime.Value.AddSeconds((float)(myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Count - 1) * TargetWaypoint.Separation_Time);
					}
					break;
				case Mission.Flight.FlightElement.ThirdElementWingman:
					if (myUnit.IsGroupLead())
					{
						dateTime = dateTime.Value.AddSeconds((float)(myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Count - 1) * TargetWaypoint.Separation_Time);
					}
					else
					{
						if (!myUnit.IsGroupMember())
						{
							break;
						}
						int num3 = 0;
						for (int i = myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Count - 1; i >= 0; i += -1)
						{
							ActiveUnit activeUnit = myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values.ElementAtOrDefault(i);
							if (!activeUnit.IsGroupLead())
							{
								if (activeUnit == myUnit)
								{
									dateTime = dateTime.Value.AddSeconds((float)num3 * TargetWaypoint.Separation_Time);
									break;
								}
								num3++;
							}
						}
					}
					break;
				}
				result = myUnit.AI.ManouverForSpace(dateTime, ref TargetWaypoint, LoiterAtWaypoint: false);
			}
			else
			{
				result = false;
			}
			goto end_IL_0001;
			IL_0724:
			num = 0;
			goto IL_0725;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101373", "");
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
		return result;
	}

	public override bool ManouverForSpace(DateTime? DesiredArrivalTime, ref Waypoint TargetWaypoint, bool LoiterAtWaypoint)
	{
		bool result;
		try
		{
			if (myUnit.CurrentSpeed == 0f)
			{
				result = false;
			}
			else if (!Information.IsNothing((object)TargetWaypoint))
			{
				if (TargetWaypoint.Type == Waypoint.WaypointType.HoldEnd)
				{
					result = false;
				}
				else
				{
					if (!Information.IsNothing((object)DesiredArrivalTime))
					{
						goto IL_00b4;
					}
					if (!Information.IsNothing((object)myUnit.Navigator.PreviousWaypointTime))
					{
						DesiredArrivalTime = myUnit.Navigator.PreviousWaypointTime.Value.AddSeconds(TargetWaypoint.Leg_Time_Straight + TargetWaypoint.Leg_Time_Turn + TargetWaypoint.Hold_Time + TargetWaypoint.Station_Time + TargetWaypoint.SpacingManeuver_Time);
						goto IL_00b4;
					}
					result = false;
				}
			}
			else
			{
				result = false;
			}
			goto end_IL_0001;
			IL_00b4:
			double num = method_31(ref myUnit.ParentScen, ref DesiredArrivalTime, ref TargetWaypoint, LoiterAtWaypoint);
			if (!(num > 0.0) && (num != -3.4028234663852886E+38 || (DesiredArrivalTime.Value - myUnit.ParentScen.Time).TotalSeconds <= 60.0))
			{
				result = false;
			}
			else
			{
				float num2 = ((Information.IsNothing((object)myUnit.Navigator.PreviousWaypointLatitude) || Information.IsNothing((object)myUnit.Navigator.PreviousWaypointLongitude)) ? Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), TargetWaypoint.Latitude, TargetWaypoint.Longitude) : Math2.CalcAzimuth(myUnit.Navigator.PreviousWaypointLatitude.Value, myUnit.Navigator.PreviousWaypointLongitude.Value, TargetWaypoint.Latitude, TargetWaypoint.Longitude));
				if (!LoiterAtWaypoint)
				{
					if (TargetWaypoint.Type == Waypoint.WaypointType.Target || TargetWaypoint.Type == Waypoint.WaypointType.WeaponTarget)
					{
						switch (myUnit.FlightRole)
						{
						case Mission.Flight.FlightElement.LeadElement:
							if (TargetWaypoint.AttackMethod == Mission._AttackMethod.SplitAtActionPoint)
							{
								myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.NormalizeBearing(num2 + 90f));
								result = true;
							}
							else
							{
								myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.NormalizeBearing(num2 - 90f));
								result = true;
							}
							goto end_IL_0001;
						case Mission.Flight.FlightElement.LeadElementWingman:
							myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.NormalizeBearing(num2 - 90f));
							result = true;
							goto end_IL_0001;
						case Mission.Flight.FlightElement.SecondElement:
							if (TargetWaypoint.AttackMethod == Mission._AttackMethod.SplitAtActionPoint)
							{
								myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.NormalizeBearing(num2 + 90f));
								result = true;
							}
							else
							{
								myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.NormalizeBearing(num2 - 90f));
								result = true;
							}
							goto end_IL_0001;
						case Mission.Flight.FlightElement.SecondElementWingman:
							myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.NormalizeBearing(num2 - 90f));
							result = true;
							goto end_IL_0001;
						case Mission.Flight.FlightElement.ThirdElement:
							if (TargetWaypoint.AttackMethod == Mission._AttackMethod.SplitAtActionPoint)
							{
								myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.NormalizeBearing(num2 + 90f));
								result = true;
							}
							else
							{
								myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.NormalizeBearing(num2 - 90f));
								result = true;
							}
							goto end_IL_0001;
						case Mission.Flight.FlightElement.ThirdElementWingman:
							myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.NormalizeBearing(num2 - 90f));
							result = true;
							goto end_IL_0001;
						}
					}
					float num3 = (float)(DesiredArrivalTime.Value - myUnit.ParentScen.Time).TotalSeconds;
					if (!(num3 < 90f) && !(num / (double)num3 > 0.1) && num != -3.4028234663852886E+38)
					{
						if (num % 60.0 < 30.0)
						{
							myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.NormalizeBearing(num2 + 45f));
							result = true;
						}
						else
						{
							myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.NormalizeBearing(num2 - 45f));
							result = true;
						}
					}
					else if (num % 240.0 > 120.0)
					{
						myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.NormalizeBearing(num2 + 90f));
						result = true;
					}
					else
					{
						myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.NormalizeBearing(num2 - 90f));
						result = true;
					}
				}
				else if (Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), TargetWaypoint.Latitude, TargetWaypoint.Longitude) > Weapon.StandOffMaxRange)
				{
					result = false;
				}
				else if (num % 120.0 > 60.0)
				{
					myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.NormalizeBearing(num2 + 90f));
					result = true;
				}
				else
				{
					myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.NormalizeBearing(num2 - 90f));
					result = true;
				}
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101374", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num4;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num4 = 0;
			}
			else
			{
				num4 = 0;
			}
			result = (byte)num4 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override bool ManouverRaceTrack(ref Scenario theScen, ref Waypoint HoldEndWaypoint)
	{
		bool result;
		try
		{
			if (myUnit.CurrentSpeed == 0f)
			{
				RaceTrackPoint = null;
				result = false;
			}
			else if (HoldEndWaypoint == null)
			{
				RaceTrackPoint = null;
				result = false;
			}
			else
			{
				int num;
				if (RaceTrackPoint.HasValue)
				{
					num = 0;
				}
				else
				{
					_ = HoldEndWaypoint.Latitude;
					_ = HoldEndWaypoint.Longitude;
					RaceTrackPoint = new Geopoint_Struct(HoldEndWaypoint.Longitude, HoldEndWaypoint.Latitude);
					num = 0;
				}
				bool flag = (byte)num != 0;
				bool flag2 = false;
				if (!myUnit.Navigator.HaveReachedPoint(HoldEndWaypoint, theScen.GameResolution, Overshoot: true, simplify_calc_for_ACs: true))
				{
					if (myUnit.Navigator.HaveReachedPoint(HoldEndWaypoint.RaceTrackHelperPoint, theScen.GameResolution, Overshoot: true, simplify_calc_for_ACs: true))
					{
						flag2 = true;
					}
					else if (RaceTrackPoint.HasValue && myUnit.Navigator.HaveReachedPoint(RaceTrackPoint.Value.ToGeoPoint(), theScen.GameResolution, Overshoot: true, simplify_calc_for_ACs: true))
					{
						if (Math2.CalcDist(method_12(), HoldEndWaypoint) < Math2.CalcDist(method_12(), HoldEndWaypoint.RaceTrackHelperPoint))
						{
							flag = true;
						}
						else
						{
							flag2 = true;
						}
					}
				}
				else
				{
					flag = true;
				}
				if (!flag)
				{
					if (flag2)
					{
						RaceTrackPoint = new Geopoint_Struct(HoldEndWaypoint.Longitude, HoldEndWaypoint.Latitude);
					}
					goto IL_0271;
				}
				if (HoldEndWaypoint.IsHoldWaypoint() && !Information.IsNothing((object)HoldEndWaypoint.RaceTrackHelperPoint))
				{
					RaceTrackPoint = new Geopoint_Struct(HoldEndWaypoint.RaceTrackHelperPoint.Longitude, HoldEndWaypoint.RaceTrackHelperPoint.Latitude);
					goto IL_0271;
				}
				if (!Information.IsNothing((object)myUnit.Navigator.PreviousWaypointLatitude) && !Information.IsNothing((object)myUnit.Navigator.PreviousWaypointLongitude))
				{
					RaceTrackPoint = new Geopoint_Struct(myUnit.Navigator.PreviousWaypointLongitude.Value, myUnit.Navigator.PreviousWaypointLatitude.Value);
					goto IL_0271;
				}
				RaceTrackPoint = null;
				result = false;
			}
			goto end_IL_0001;
			IL_062d:
			bool flag3;
			if (!flag3)
			{
				myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), RaceTrackPoint.Value.Latitude, RaceTrackPoint.Value.Longitude));
				result = true;
			}
			else
			{
				HoldEndWaypoint.Hold_Time = 0f;
				RaceTrackPoint = null;
				Aircraft_Navigator navigator = method_12().Navigator;
				bool ForceWaypointSwitch = true;
				bool ForceStationAbort = false;
				navigator.CheckIfReachedWaypoint_AND_Apply_WP_logic(1f, ref ForceWaypointSwitch, ref ForceStationAbort);
				result = false;
			}
			goto end_IL_0001;
			IL_03bd:
			int num2;
			flag3 = (byte)num2 != 0;
			if (method_12().ParentScen.FifthSecondIsChangingOnThisPulse)
			{
				if (!HoldEndWaypoint.Time_Zulu.HasValue)
				{
					HoldEndWaypoint.Time_Zulu = method_12().ParentScen.Time.AddSeconds(HoldEndWaypoint.Hold_Time);
				}
				_ = HoldEndWaypoint.Time_Zulu.Value;
				float num3 = Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), HoldEndWaypoint.Latitude, HoldEndWaypoint.Longitude);
				Misc.TurnDirection turnDirection = Misc.DetermineTurnDirection(myUnit.CurrentHeading, num3);
				float wedgeArcResolution = default(float);
				switch (turnDirection)
				{
				case Misc.TurnDirection.TurnRight:
					wedgeArcResolution = 9f;
					break;
				case Misc.TurnDirection.TurnLeft:
					wedgeArcResolution = -9f;
					break;
				}
				float PreviousWaypointEntryBearing = myUnit.CurrentHeading;
				float LastKnownSpeed_Straight = ((!Information.IsNothing((object)HoldEndWaypoint.DesiredSpeed)) ? HoldEndWaypoint.DesiredSpeed.Value : myUnit.CurrentSpeed);
				float currentSpeed = myUnit.CurrentSpeed;
				List<Waypoint.FlightPlanSegment> theFlightPlanPointList = new List<Waypoint.FlightPlanSegment>();
				bool PreviousWaypoitIsTooClose = false;
				Waypoint[] theArray = new Waypoint[0];
				ref Scenario parentScen = ref myUnit.ParentScen;
				Doctrine FlightLeadDoctrine = null;
				Waypoint thePrevWaypoint = Waypoint.CopyWaypoint(ref parentScen, ref HoldEndWaypoint, CopyWingmanWaypoints: false, CopyFlightplanPointsList: false, ref FlightLeadDoctrine);
				thePrevWaypoint.Latitude = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
				thePrevWaypoint.Longitude = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
				ArrayExtensions.Add(ref theArray, thePrevWaypoint);
				ArrayExtensions.Add(ref theArray, HoldEndWaypoint);
				Waypoint theWaypoint_Lead = null;
				Mission.Flight theFlight = null;
				MissionPlanner.CreateFlightPlanCurve(ref PreviousWaypointEntryBearing, ref theFlightPlanPointList, ref HoldEndWaypoint, ref thePrevWaypoint, ref theWaypoint_Lead, ref LastKnownSpeed_Straight, currentSpeed, ref theFlight, wedgeArcResolution, turnDirection, num3, ref PreviousWaypoitIsTooClose, ExitWhenPreviousWaypoitIsTooClose: true, "", myUnit.Navigator.PlottedCourse);
				double num4 = default(double);
				foreach (Waypoint.FlightPlanSegment item in theFlightPlanPointList)
				{
					num4 += (double)Math2.CalcDist(item.StartLatitude, item.StartLongitude, item.EndLatitude, item.EndLongitude);
				}
				double num5 = num4 * 1852.0 / ((double)currentSpeed * 0.514444);
				DateTime time = theScen.Time;
				int num6;
				if (!(num5 > (double)(HoldEndWaypoint.Hold_Time + 15f)))
				{
					if (DateTime.Compare(time.AddSeconds(num5), HoldEndWaypoint.Time_Zulu.Value.AddSeconds(HoldEndWaypoint.Hold_Time)) <= 0)
					{
						goto IL_062d;
					}
					num6 = 1;
				}
				else
				{
					num6 = 1;
				}
				flag3 = (byte)num6 != 0;
			}
			goto IL_062d;
			IL_03bc:
			num2 = 0;
			goto IL_03bd;
			IL_0271:
			if (Information.IsNothing((object)HoldEndWaypoint.Time_Zulu))
			{
				num2 = 0;
			}
			else if (!HoldEndWaypoint.DesiredAltitude.HasValue)
			{
				num2 = 0;
			}
			else
			{
				DateTime? time_Zulu = HoldEndWaypoint.Time_Zulu;
				DateTime time2 = myUnit.ParentScen.Time;
				if (((!time_Zulu.HasValue) ? ((bool?)null) : new bool?(DateTime.Compare(time_Zulu.GetValueOrDefault(), time2) < 0)) != true)
				{
					num2 = 0;
				}
				else
				{
					float? desiredAltitude = HoldEndWaypoint.DesiredAltitude;
					float desiredAltitude2 = myUnit.DesiredAltitude;
					if ((desiredAltitude.HasValue ? new bool?(desiredAltitude.GetValueOrDefault() > desiredAltitude2) : ((bool?)null)) != true)
					{
						goto IL_03bc;
					}
					myUnit.DesiredAltitude = HoldEndWaypoint.DesiredAltitude.Value;
					float maximumAltitude = myUnit.Kinematics.GetMaximumAltitude();
					float minimumAltitude = myUnit.Kinematics.GetMinimumAltitude();
					if (myUnit.DesiredAltitude > maximumAltitude)
					{
						myUnit.DesiredAltitude = maximumAltitude;
						num2 = 0;
					}
					else
					{
						if (!(myUnit.DesiredAltitude < minimumAltitude))
						{
							goto IL_03bc;
						}
						myUnit.DesiredAltitude = minimumAltitude;
						num2 = 0;
					}
				}
			}
			goto IL_03bd;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 098234572876", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			RaceTrackPoint = null;
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private double method_31(ref Scenario scenario_0, ref DateTime? nullable_4, ref Waypoint waypoint_0, bool bool_0)
	{
		double result;
		try
		{
			if (Information.IsNothing((object)waypoint_0))
			{
				result = 0.0;
			}
			else if (waypoint_0.Type != Waypoint.WaypointType.StationStart_FigureEight && (method_12().Navigator.PreviousWaypoint == null || method_12().Navigator.PreviousWaypoint.Type != Waypoint.WaypointType.StationStart_FigureEight))
			{
				if (Information.IsNothing((object)nullable_4))
				{
					result = 0.0;
				}
				else
				{
					DateTime time = myUnit.ParentScen.Time;
					DateTime? dateTime = nullable_4;
					if ((dateTime.HasValue ? new bool?(DateTime.Compare(time, dateTime.GetValueOrDefault()) >= 0) : ((bool?)null)) != true)
					{
						if (bool_0 || Information.IsNothing((object)waypoint_0) || Information.IsNothing((object)waypoint_0.Time_Zulu) || Information.IsNothing((object)myUnit.Navigator.PreviousWaypointTime))
						{
							goto IL_015d;
						}
						DateTime t = myUnit.Navigator.PreviousWaypointTime.Value.AddSeconds(waypoint_0.Leg_Time_Straight + waypoint_0.Leg_Time_Turn);
						if (DateTime.Compare(t, nullable_4.Value) < 0)
						{
							goto IL_015d;
						}
						result = -1.0;
					}
					else
					{
						result = -1.0;
					}
				}
			}
			else
			{
				result = 0.0;
			}
			goto end_IL_0001;
			IL_015d:
			DateTime value = default(DateTime);
			if (!myUnit.Navigator.HasPlottedCourse())
			{
				if (myUnit.IsGroupWingman() && !Information.IsNothing((object)myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead) && myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.HasPlottedCourse())
				{
					if (!myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.HasFlightPlan)
					{
						result = -1.0;
					}
					else
					{
						myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.get_Flight(HierarchySearch: true);
						if (bool_0)
						{
							goto IL_02f2;
						}
						if (!Information.IsNothing((object)myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.PreviousWaypointTime))
						{
							value = myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.PreviousWaypointTime.Value;
							goto IL_02f2;
						}
						result = -1.0;
					}
				}
				else
				{
					result = -1.0;
				}
			}
			else if (!myUnit.Navigator.HasFlightPlan)
			{
				result = -1.0;
			}
			else
			{
				myUnit.Navigator.get_Flight(HierarchySearch: true);
				if (bool_0)
				{
					goto IL_02f2;
				}
				if (!Information.IsNothing((object)myUnit.Navigator.PreviousWaypointTime))
				{
					value = myUnit.Navigator.PreviousWaypointTime.Value;
					goto IL_02f2;
				}
				result = -1.0;
			}
			goto end_IL_0001;
			IL_02f2:
			int num = myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan.Count() - 1;
			Waypoint theOriginalWaypoint = default(Waypoint);
			Waypoint theOriginalWaypoint2 = default(Waypoint);
			for (int i = 1; i <= num; i++)
			{
				theOriginalWaypoint = myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan[i];
				if (theOriginalWaypoint != waypoint_0)
				{
					if (Information.IsNothing((object)theOriginalWaypoint.Waypoint_LeadElementWingman) || theOriginalWaypoint.Waypoint_LeadElementWingman != waypoint_0)
					{
						if (Information.IsNothing((object)theOriginalWaypoint.Waypoint_SecondElement) || theOriginalWaypoint.Waypoint_SecondElement != waypoint_0)
						{
							if (Information.IsNothing((object)theOriginalWaypoint.Waypoint_SecondElementWingman) || theOriginalWaypoint.Waypoint_SecondElementWingman != waypoint_0)
							{
								if (Information.IsNothing((object)theOriginalWaypoint.Waypoint_ThirdElement) || theOriginalWaypoint.Waypoint_ThirdElement != waypoint_0)
								{
									if (!Information.IsNothing((object)theOriginalWaypoint.Waypoint_ThirdElementWingman) && theOriginalWaypoint.Waypoint_ThirdElementWingman == waypoint_0)
									{
										theOriginalWaypoint2 = ((!Information.IsNothing((object)myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan[i - 1].Waypoint_ThirdElementWingman)) ? myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan[i - 1].Waypoint_ThirdElementWingman : myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan[i - 1]);
										theOriginalWaypoint = theOriginalWaypoint.Waypoint_ThirdElement;
										break;
									}
									continue;
								}
								theOriginalWaypoint2 = ((!Information.IsNothing((object)myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan[i - 1].Waypoint_ThirdElement)) ? myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan[i - 1].Waypoint_ThirdElement : myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan[i - 1]);
								theOriginalWaypoint = theOriginalWaypoint.Waypoint_ThirdElement;
								break;
							}
							theOriginalWaypoint2 = ((!Information.IsNothing((object)myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan[i - 1].Waypoint_SecondElementWingman)) ? myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan[i - 1].Waypoint_SecondElementWingman : myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan[i - 1]);
							theOriginalWaypoint = theOriginalWaypoint.Waypoint_SecondElementWingman;
							break;
						}
						theOriginalWaypoint2 = (Information.IsNothing((object)myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan[i - 1].Waypoint_SecondElement) ? myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan[i - 1] : myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan[i - 1].Waypoint_SecondElement);
						theOriginalWaypoint = theOriginalWaypoint.Waypoint_SecondElement;
						break;
					}
					theOriginalWaypoint2 = ((!Information.IsNothing((object)myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan[i - 1].Waypoint_LeadElementWingman)) ? myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan[i - 1].Waypoint_LeadElementWingman : myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan[i - 1]);
					theOriginalWaypoint = theOriginalWaypoint.Waypoint_LeadElementWingman;
					break;
				}
				theOriginalWaypoint2 = myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan[i - 1];
				break;
			}
			if (!Information.IsNothing((object)theOriginalWaypoint) && !Information.IsNothing((object)theOriginalWaypoint2))
			{
				if (!bool_0 && !Information.IsNothing((object)nullable_4) && !Information.IsNothing((object)theOriginalWaypoint2.Time_Zulu))
				{
					DateTime time = value;
					DateTime? dateTime = theOriginalWaypoint2.Time_Zulu;
					if (((!dateTime.HasValue) ? ((bool?)null) : new bool?(DateTime.Compare(time, dateTime.GetValueOrDefault()) > 0)) == true)
					{
						nullable_4 = nullable_4.Value.AddSeconds((value - theOriginalWaypoint2.Time_Zulu.Value).TotalSeconds);
					}
				}
				float num2 = Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), theOriginalWaypoint.Latitude, theOriginalWaypoint.Longitude);
				Misc.TurnDirection turnDirection = Misc.DetermineTurnDirection(myUnit.CurrentHeading, num2);
				float wedgeArcResolution = default(float);
				switch (turnDirection)
				{
				case Misc.TurnDirection.TurnRight:
					wedgeArcResolution = 9f;
					break;
				case Misc.TurnDirection.TurnLeft:
					wedgeArcResolution = -9f;
					break;
				}
				float PreviousWaypointEntryBearing = myUnit.CurrentHeading;
				float LastKnownSpeed_Straight = myUnit.DesiredSpeed;
				float currentSpeed = myUnit.CurrentSpeed;
				List<Waypoint.FlightPlanSegment> theFlightPlanPointList = new List<Waypoint.FlightPlanSegment>();
				bool PreviousWaypoitIsTooClose = false;
				Waypoint[] theArray = new Waypoint[0];
				ref Scenario parentScen = ref myUnit.ParentScen;
				Doctrine FlightLeadDoctrine = null;
				theOriginalWaypoint = Waypoint.CopyWaypoint(ref parentScen, ref theOriginalWaypoint, CopyWingmanWaypoints: false, CopyFlightplanPointsList: false, ref FlightLeadDoctrine);
				ref Scenario parentScen2 = ref myUnit.ParentScen;
				FlightLeadDoctrine = null;
				theOriginalWaypoint2 = Waypoint.CopyWaypoint(ref parentScen2, ref theOriginalWaypoint2, CopyWingmanWaypoints: false, CopyFlightplanPointsList: false, ref FlightLeadDoctrine);
				theOriginalWaypoint.Type = Waypoint.WaypointType.TurningPoint;
				theOriginalWaypoint2.Type = Waypoint.WaypointType.TurningPoint;
				theOriginalWaypoint2.Latitude = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
				theOriginalWaypoint2.Longitude = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
				ArrayExtensions.Add(ref theArray, theOriginalWaypoint2);
				ArrayExtensions.Add(ref theArray, theOriginalWaypoint);
				Waypoint theWaypoint_Lead = null;
				Mission.Flight theFlight = null;
				MissionPlanner.CreateFlightPlanCurve(ref PreviousWaypointEntryBearing, ref theFlightPlanPointList, ref theOriginalWaypoint, ref theOriginalWaypoint2, ref theWaypoint_Lead, ref LastKnownSpeed_Straight, currentSpeed, ref theFlight, wedgeArcResolution, turnDirection, num2, ref PreviousWaypoitIsTooClose, ExitWhenPreviousWaypoitIsTooClose: true, "", myUnit.Navigator.PlottedCourse);
				if (PreviousWaypoitIsTooClose)
				{
					result = -3.4028234663852886E+38;
				}
				else
				{
					theFlight = null;
					ref ActiveUnit theAU = ref myUnit;
					float NecessaryFuel = 0f;
					float MissionFuel = 0f;
					bool IsOnIngressLeg = false;
					MissionPlanner.DetermineTimesAndFuelQty(ref theFlight, ref theArray, ref theAU, ref NecessaryFuel, ref MissionFuel, ref IsOnIngressLeg, IsWingman: false, NewFlightPlan: false, "", IsManouverForSpace: true);
					float num3 = theOriginalWaypoint.Leg_Time_Turn + theOriginalWaypoint.Leg_Time_Straight;
					DateTime dateTime2 = myUnit.ParentScen.Time.AddSeconds(num3);
					result = (float)(nullable_4.Value - dateTime2).TotalSeconds;
				}
			}
			else
			{
				result = -1.0;
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101375", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = -1.0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public bool ContactIsRelevantToEscortsLoadout(Contact theContact)
	{
		if (!Information.IsNothing((object)theContact.ActualUnit))
		{
			if (Information.IsNothing((object)method_12().Loadout))
			{
				return false;
			}
			Loadout loadout = method_12().Loadout;
			int result3;
			int result;
			int result2;
			switch (theContact.Type)
			{
			default:
				result3 = 0;
				goto IL_010b;
			case Contact_Base.ContactType.Air:
			{
				Loadout.LoadoutRole role3 = loadout.Role;
				if ((uint)(role3 - 2001) <= 6u)
				{
					return true;
				}
				return false;
			}
			case Contact_Base.ContactType.Surface:
			{
				int result4;
				switch (loadout.Role)
				{
				case Loadout.LoadoutRole.LandNaval_Strike:
				case Loadout.LoadoutRole.LandNaval_Standoff:
				case Loadout.LoadoutRole.LandNaval_SEAD_ARM:
				case Loadout.LoadoutRole.LandNaval_SEAD_TALD:
				case Loadout.LoadoutRole.LandNaval_DEAD:
					result4 = 1;
					break;
				case Loadout.LoadoutRole.NavalOnly_Strike:
				case Loadout.LoadoutRole.NavalOnly_Standoff:
				case Loadout.LoadoutRole.NavalOnly_SEAD_ARM:
					result4 = 1;
					break;
				case Loadout.LoadoutRole.Forward_Observer:
					result4 = 1;
					break;
				default:
					return false;
				case Loadout.LoadoutRole.LandOnly_SEAD_TALD:
				case Loadout.LoadoutRole.NavalOnly_DEAD:
				case Loadout.LoadoutRole.BAI_CAS:
					result4 = 1;
					break;
				}
				return (byte)result4 != 0;
			}
			case Contact_Base.ContactType.Submarine:
			{
				Loadout.LoadoutRole role2 = loadout.Role;
				if ((uint)(role2 - 6001) <= 1u)
				{
					return true;
				}
				return false;
			}
			case Contact_Base.ContactType.Missile:
			case Contact_Base.ContactType.UndeterminedNaval:
			case Contact_Base.ContactType.Aimpoint:
			case Contact_Base.ContactType.Orbital:
				result3 = 0;
				goto IL_010b;
			case Contact_Base.ContactType.Facility_Fixed:
			case Contact_Base.ContactType.Facility_Mobile:
			case Contact_Base.ContactType.AggregateGroundUnit:
				{
					Loadout.LoadoutRole role = loadout.Role;
					if (role > Loadout.LoadoutRole.LandOnly_DEAD)
					{
						if (role == Loadout.LoadoutRole.BAI_CAS)
						{
							goto IL_0154;
						}
						if (role != Loadout.LoadoutRole.Forward_Observer)
						{
							result = 0;
							goto IL_0151;
						}
						result2 = 1;
					}
					else
					{
						if ((uint)(role - 3002) > 3u)
						{
							if ((uint)(role - 3101) > 4u)
							{
								result = 0;
								goto IL_0151;
							}
							goto IL_0154;
						}
						result2 = 1;
					}
					goto IL_0155;
				}
				IL_0154:
				result2 = 1;
				goto IL_0155;
				IL_0155:
				return (byte)result2 != 0;
				IL_010b:
				return (byte)result3 != 0;
				IL_0151:
				return (byte)result != 0;
			}
		}
		return false;
	}

	private bool method_32(Contact contact_5)
	{
		if (myUnit.IsGroupMember())
		{
			foreach (ActiveUnit value in myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values)
			{
				if (value == myUnit || !value.IsAircraft)
				{
					continue;
				}
				Aircraft aircraft = (Aircraft)value;
				if (aircraft.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.BVRCrank || !aircraft.Weaponry.IsGuidingWeaponsOntoThisContact(contact_5) || !(myUnit.RangeToUnit_Horiz(value) < 50f))
				{
					continue;
				}
				int result;
				if (IsClearedToEngageThisTarget(contact_5))
				{
					Side side = myUnit.get_UnitSide(SetSideOnly: false);
					ref ActiveUnit theAttacker = ref myUnit;
					TargetingEntry._TargetingBehavior theTargetBehaviour = TargetingEntry._TargetingBehavior.AutoTargeted;
					if (side.NumberOfAnyWeaponTypesOnThisUnitLeftToFireAtThisTarget(ref theAttacker, ref contact_5, ref theTargetBehaviour) >= 1)
					{
						continue;
					}
					result = 1;
				}
				else
				{
					result = 1;
				}
				return (byte)result != 0;
			}
		}
		return false;
	}

	public bool NeedToCrank()
	{
		byte? b = (byte?)method_12().Doctrine.get_BVRLogic(method_12().ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
		bool result;
		if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) == true)
		{
			result = false;
		}
		else
		{
			try
			{
				if (base.Targets_ReadOnly.Length != 0)
				{
					if (method_12().ParentScen.GuidedWeaponsInAir.Count == 0)
					{
						result = false;
					}
					else if ((from theW in method_12().Weaponry.IsGuidingWeaponsInAir_List()
						where theW.IsBVR()
						select theW).ToList().Count != 0)
					{
						bool flag = false;
						foreach (Contact contacts_ in myUnit.get_UnitSide(SetSideOnly: false).Contacts_List)
						{
							if (contacts_.get_Stance(myUnit.get_UnitSide(SetSideOnly: false)) != Misc.PostureStance.Friendly && contacts_.get_Stance(myUnit.get_UnitSide(SetSideOnly: false)) != Misc.PostureStance.Neutral && contacts_.Type == Contact_Base.ContactType.Air)
							{
								ActiveUnit activeUnit = myUnit;
								string feedbackMessage = "";
								if (!(Math.Abs(Module_Unit.AngleOffThisUnitsBoresight(activeUnit, contacts_, DistinguishBetweenStarboardAndPort: true, ref feedbackMessage, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue)) >= 45f))
								{
									flag = true;
									break;
								}
							}
							if (flag)
							{
								break;
							}
						}
						if (method_12().Loadout.Weapons.Where([SpecialName] (WeaponRec WR) =>
						{
							int result2;
							if (WR.get_ReferenceWeapon(myUnit.ParentScen).IsMissile)
							{
								if (WR.get_ReferenceWeapon(myUnit.ParentScen).IsBVR())
								{
									return WR.CurrentLoad > 0;
								}
								result2 = 0;
							}
							else
							{
								result2 = 0;
							}
							return (byte)result2 != 0;
						}).Count() == 0 && flag)
						{
							result = true;
						}
						else
						{
							List<Weapon> list = (from theW in method_12().Weaponry.AllDistinctWeaponsAboard_Actual()
								where theW.IsAAWCapable && !theW.IsBVR()
								select theW).ToList();
							if (list.Count != 0)
							{
								float num = list.Select([SpecialName] (Weapon theW) => theW.MaxAirRange).Max();
								WeaponSalvo[] array = myUnit.get_UnitSide(SetSideOnly: false).WeaponSalvos.ToArray();
								int num2 = 0;
								while (true)
								{
									if (num2 < array.Length)
									{
										WeaponSalvo weaponSalvo = array[num2];
										WeaponSalvo.Shooter[] shootersList = weaponSalvo.ShootersList;
										int num3 = 0;
										while (true)
										{
											if (num3 < shootersList.Length)
											{
												WeaponSalvo.Shooter shooter = shootersList[num3];
												if (Operators.CompareString(shooter.ShooterObjectID, myUnit.ObjectID, false) == 0)
												{
													if (!(method_12().RangeToUnit_Horiz(weaponSalvo.Target) >= num))
													{
														result = false;
														goto end_IL_02d7;
													}
													if (shooter.QuantityAssigned - shooter.QuantityFired > 0)
													{
														result = false;
														goto end_IL_02d7;
													}
												}
												num3 = checked(num3 + 1);
												continue;
											}
											num2 = checked(num2 + 1);
											break;
										}
										continue;
									}
									result = (flag ? true : false);
									break;
									continue;
									end_IL_02d7:
									break;
								}
							}
							else
							{
								result = true;
							}
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
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100389", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				int num4;
				if (!Debugger.IsAttached)
				{
					num4 = 0;
				}
				else
				{
					Debugger.Break();
					num4 = 0;
				}
				result = (byte)num4 != 0;
				ProjectData.ClearProjectError();
			}
		}
		return result;
	}

	private bool method_33()
	{
		Doctrine._BVRLogicEnum? bVRLogicEnum = method_12().Doctrine.get_BVRLogic(method_12().ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
		byte? b = (byte?)bVRLogicEnum;
		bool? flag2;
		bool? flag = (flag2 = ((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)));
		bool? obj;
		bool? flag3;
		if (flag.HasValue && flag2 == true)
		{
			obj = true;
		}
		else
		{
			b = (byte?)bVRLogicEnum;
			flag = (flag3 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)));
			obj = ((!flag.HasValue) ? ((bool?)null) : ((flag3 == true) | flag2));
		}
		flag3 = obj;
		bool result = default(bool);
		if (flag3 == true)
		{
			result = false;
		}
		else
		{
			b = (byte?)bVRLogicEnum;
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)) == true)
			{
				try
				{
					if (base.Targets_ReadOnly.Length == 0)
					{
						result = false;
					}
					else if (method_12().ParentScen.GuidedWeaponsInAir.Count != 0)
					{
						if (method_12().ParentScen.GuidedWeaponsInAir.Where([SpecialName] (Weapon theW) => theW.FiringParent == method_12() && theW.IsBVR()).ToList().Count == 0)
						{
							result = false;
						}
						else
						{
							List<Weapon> list = (from theW in method_12().Weaponry.IsGuidingWeaponsInAir_List()
								where theW.IsBVR()
								select theW).ToList();
							foreach (Weapon item in list)
							{
								if (item.DataLinkParent != myUnit || item.HasGoneAutonomous)
								{
									Sensor[] sensors_Cached = method_12().Sensors_Cached;
									int num = 0;
									while (num < sensors_Cached.Length)
									{
										if (!sensors_Cached[num].SemiActiveWeaponsGuided.Contains(item))
										{
											num = checked(num + 1);
											continue;
										}
										result = false;
										goto end_IL_015f;
									}
									continue;
								}
								result = false;
								goto end_IL_015f;
							}
							bool flag4 = false;
							foreach (Contact contacts_ in myUnit.get_UnitSide(SetSideOnly: false).Contacts_List)
							{
								if (contacts_.get_Stance(myUnit.get_UnitSide(SetSideOnly: false)) != Misc.PostureStance.Friendly && contacts_.get_Stance(myUnit.get_UnitSide(SetSideOnly: false)) != Misc.PostureStance.Neutral && contacts_.Type == Contact_Base.ContactType.Air)
								{
									ActiveUnit activeUnit = myUnit;
									string feedbackMessage = "";
									if (!(Math.Abs(Module_Unit.AngleOffThisUnitsBoresight(activeUnit, contacts_, DistinguishBetweenStarboardAndPort: true, ref feedbackMessage, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue)) >= 70f))
									{
										flag4 = true;
										break;
									}
								}
								if (flag4)
								{
									break;
								}
							}
							if (method_12().Loadout.Weapons.Where([SpecialName] (WeaponRec WR) =>
							{
								int result2;
								if (WR.get_ReferenceWeapon(myUnit.ParentScen).IsMissile)
								{
									if (WR.get_ReferenceWeapon(myUnit.ParentScen).IsBVR())
									{
										return WR.CurrentLoad > 0;
									}
									result2 = 0;
								}
								else
								{
									result2 = 0;
								}
								return (byte)result2 != 0;
							}).Count() == 0 && flag4)
							{
								result = true;
							}
							else
							{
								IEnumerable<Weapon> source = from theW in method_12().Weaponry.AllDistinctWeaponsAboard_Actual()
									where theW.IsAAWCapable && !theW.IsBVR()
									select theW;
								if (source.Count() != 0)
								{
									float num2 = source.Select([SpecialName] (Weapon theW) => theW.MaxAirRange).Max();
									foreach (WeaponSalvo weaponSalvo in myUnit.get_UnitSide(SetSideOnly: false).WeaponSalvos)
									{
										WeaponSalvo.Shooter[] shootersList = weaponSalvo.ShootersList;
										foreach (WeaponSalvo.Shooter shooter in shootersList)
										{
											if (Operators.CompareString(shooter.ShooterObjectID, myUnit.ObjectID, false) != 0)
											{
												continue;
											}
											if (method_12().RangeToUnit_Horiz(weaponSalvo.Target) >= num2)
											{
												if (shooter.QuantityAssigned - shooter.QuantityFired <= 0)
												{
													continue;
												}
												result = false;
											}
											else
											{
												result = false;
											}
											goto end_IL_015f;
										}
									}
									result = (flag4 ? true : false);
								}
								else
								{
									result = true;
								}
							}
						}
					}
					else
					{
						result = false;
					}
					end_IL_015f:;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 100389", "");
					GameGeneral.WriteExceptionsToLog(ex2);
					int num4;
					if (Debugger.IsAttached)
					{
						Debugger.Break();
						num4 = 0;
					}
					else
					{
						num4 = 0;
					}
					result = (byte)num4 != 0;
					ProjectData.ClearProjectError();
				}
			}
			else
			{
				b = (byte?)bVRLogicEnum;
				if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 5)) == true)
				{
					try
					{
						if (base.Targets_ReadOnly.Length == 0)
						{
							result = false;
						}
						else if (method_12().ParentScen.GuidedWeaponsInAir.Count == 0)
						{
							result = false;
						}
						else if (method_12().ParentScen.GuidedWeaponsInAir.Where([SpecialName] (Weapon theW) => theW.FiringParent == method_12() && theW.IsBVR()).ToList().Count == 0)
						{
							result = false;
						}
						else
						{
							List<Weapon> list2 = (from theW in method_12().Weaponry.IsGuidingWeaponsInAir_List()
								where theW.IsBVR()
								select theW).ToList();
							foreach (Weapon item2 in list2)
							{
								Sensor[] sensors_Cached2 = method_12().Sensors_Cached;
								int num5 = 0;
								while (num5 < sensors_Cached2.Length)
								{
									if (!sensors_Cached2[num5].SemiActiveWeaponsGuided.Contains(item2))
									{
										num5 = checked(num5 + 1);
										continue;
									}
									result = false;
									goto end_IL_0552;
								}
							}
							bool flag5 = false;
							PooledList<Contact> contacts_List = myUnit.get_UnitSide(SetSideOnly: false).Contacts_List;
							foreach (Contact item3 in contacts_List)
							{
								if (item3.get_Stance(myUnit.get_UnitSide(SetSideOnly: false)) != Misc.PostureStance.Friendly && item3.get_Stance(myUnit.get_UnitSide(SetSideOnly: false)) != Misc.PostureStance.Neutral && item3.Type == Contact_Base.ContactType.Air)
								{
									ActiveUnit activeUnit2 = myUnit;
									string feedbackMessage = "";
									if (!(Math.Abs(Module_Unit.AngleOffThisUnitsBoresight(activeUnit2, item3, DistinguishBetweenStarboardAndPort: true, ref feedbackMessage, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue)) >= 70f))
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
							if (method_12().Loadout.Weapons.Where([SpecialName] (WeaponRec WR) => WR.get_ReferenceWeapon(myUnit.ParentScen).IsMissile && WR.get_ReferenceWeapon(myUnit.ParentScen).IsBVR() && WR.CurrentLoad > 0).Count() == 0 && flag5)
							{
								result = true;
							}
							else
							{
								IEnumerable<Weapon> source2 = from theW in method_12().Weaponry.AllDistinctWeaponsAboard_Actual()
									where theW.IsAAWCapable && !theW.IsBVR()
									select theW;
								if (source2.Count() != 0)
								{
									float num6 = source2.Select([SpecialName] (Weapon theW) => theW.MaxAirRange).Max();
									foreach (WeaponSalvo weaponSalvo2 in myUnit.get_UnitSide(SetSideOnly: false).WeaponSalvos)
									{
										WeaponSalvo.Shooter[] shootersList2 = weaponSalvo2.ShootersList;
										foreach (WeaponSalvo.Shooter shooter2 in shootersList2)
										{
											if (Operators.CompareString(shooter2.ShooterObjectID, myUnit.ObjectID, false) != 0)
											{
												continue;
											}
											if (method_12().RangeToUnit_Horiz(weaponSalvo2.Target) >= num6)
											{
												if (shooter2.QuantityAssigned - shooter2.QuantityFired <= 0)
												{
													continue;
												}
												result = false;
											}
											else
											{
												result = false;
											}
											goto end_IL_0552;
										}
									}
									result = (flag5 ? true : false);
								}
								else
								{
									result = true;
								}
							}
						}
						end_IL_0552:;
					}
					catch (Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						Exception ex4 = ex3;
						ex4?.Data.Add("Error at 100389", "");
						GameGeneral.WriteExceptionsToLog(ex4);
						int num8;
						if (!Debugger.IsAttached)
						{
							num8 = 0;
						}
						else
						{
							Debugger.Break();
							num8 = 0;
						}
						result = (byte)num8 != 0;
						ProjectData.ClearProjectError();
					}
				}
			}
		}
		return result;
	}

	private void method_34(bool bool_0)
	{
		try
		{
			if (!Information.IsNothing((object)PrimaryTarget.ActualUnit))
			{
				IEnumerable<Sensor> source = from theS in method_12().Sensors_Cached
					where theS.Codes.Classification && theS.get_IsSuitableForThisTarget(PrimaryTarget.ActualUnit)
					orderby theS.MaxIDRangeOnThisTarget(method_12(), PrimaryTarget.ActualUnit) descending
					select theS;
				if (source.Count() == 0)
				{
					return;
				}
				float num = source.ElementAtOrDefault(0).MaxIDRangeOnThisTarget(method_12(), PrimaryTarget.ActualUnit);
				if (num > 20f)
				{
					num = 20f;
				}
				float num2 = method_12().RangeToUnit_Horiz(PrimaryTarget);
				if (PrimaryTarget.AltitudeIsKnown && num2 < 2f * num)
				{
					method_12().DesiredAltitude = ((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
					myUnit.set_DesiredAltitude_UseTerrainFollowing(myUnit, value: false);
					return;
				}
				if ((PrimaryTarget.isSurfaceOrLandContact || PrimaryTarget.IsSubmergedContact) && num2 < num)
				{
					method_12().DesiredAltitude = 304.80002f;
					myUnit.set_DesiredAltitude_UseTerrainFollowing(myUnit, value: false);
					return;
				}
				Aircraft_Navigator navigator = method_12().Navigator;
				Aircraft_AirOps airOps = method_12().AirOps;
				if (!navigator.HasFlightPlan)
				{
					navigator.SetInterceptAltitude(airOps.Condition);
				}
				navigator.SetInterceptThrottle(myUnit.DesiredAltitude, myUnit.Kinematics.GetMaximumSpeed(myUnit.DesiredAltitude, ActiveUnit.Throttle.Cruise, ValidateAndFixAltitude: false), bool_0, airOps.Condition);
			}
			else
			{
				ActiveUnit activeUnit = myUnit;
				Aircraft theAircraft = method_12();
				ActiveUnit activeUnit2;
				ActiveUnit theAU;
				bool Return_theAltitude_TerrainFollowing = (activeUnit2 = myUnit).get_DesiredAltitude_UseTerrainFollowing(theAU = myUnit);
				float desiredAltitude = MostRealisticOptimumAltitude(ref theAircraft, ActiveUnit.Throttle.Cruise, ref Return_theAltitude_TerrainFollowing);
				activeUnit2.set_DesiredAltitude_UseTerrainFollowing(theAU, Return_theAltitude_TerrainFollowing);
				activeUnit.DesiredAltitude = desiredAltitude;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100391", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void DetermineDesiredAttitudeAndThrottle(float elapsedTime, bool RecalculatePlottedCourse = true)
	{
		if (method_12() == null || (method_12().IsDrone() && method_12().AutonomyLevel < ActiveUnit.DroneAutonomyLevel.SelfRecovering && method_12().ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DroneAutonomyLevels) && method_12().CommStuff.TimeOffComms > 0f))
		{
			return;
		}
		if (method_12().AirOps.Condition == Aircraft_AirOps._AirOpsCondition.HoldingPattern_CommsLost)
		{
			method_12().Kinematics.Loiter(elapsedTime);
			return;
		}
		method_12().Navigator.IsManouveringToFormationStation = false;
		if (!method_12().HasLostControl())
		{
			method_12().Navigator.IsManouveringToFormationStation = false;
			method_12().IsPerformingStandoffAttack = false;
			if (method_12().Status == ActiveUnit._ActiveUnitStatus.AvoidingWeaponEffects && WeaponThreat != null)
			{
				ManouverAwayFromWeaponEffects(elapsedTime, WeaponThreat);
				method_12().Kinematics.DesiredSpeedOverride = null;
				method_12().SetThrottle(ActiveUnit.Throttle.Flank);
				return;
			}
			Mission mission = method_12().ActiveMissionOrPackage();
			if (mission != null && mission.get_Status(method_12().ParentScen) == Mission.MissionStatus.Active)
			{
				switch (method_12().ActiveMissionOrPackage().MissionClass)
				{
				case Mission._MissionClass.Strike:
				{
					Strike strike = (Strike)method_12().ActiveMissionOrPackage();
					if (strike == null || strike == null || strike.Type != Strike.StrikeType.Air_Intercept || !((method_12().Status == ActiveUnit._ActiveUnitStatus.OnPlottedCourse) | (method_12().Status == ActiveUnit._ActiveUnitStatus.Tasked)))
					{
						break;
					}
					method_12().DesiredAltitude = method_12().Loadout.get_MissionProfile(method_12().ParentScen).CruiseAltitudeIngress;
					if (method_12().AI.PrimaryTarget == null)
					{
						break;
					}
					float num = BearingToUnit_True(method_12().AI.PrimaryTarget);
					Aircraft_AI aI = method_12().AI;
					Contact primaryTarget = PrimaryTarget;
					ActiveUnit.Throttle cruiseThrottleSettingIngress = method_12().Loadout.get_MissionProfile(method_12().ParentScen).CruiseThrottleSettingIngress;
					float? safetyMargin = 0.1f;
					bool BingoFuelEndurance = false;
					if (!aI.CanInterceptTarget(primaryTarget, null, 0f, null, num, cruiseThrottleSettingIngress, safetyMargin, IgnoreMotionVectors: false, TotalRemainingEndurance: false, ref BingoFuelEndurance))
					{
						break;
					}
					if (method_12().IsGroupMember())
					{
						IEnumerator<ActiveUnit> enumerator = ((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).Units.Values.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ActiveUnit current = enumerator.Current;
							if (current != null && !current.Kinematics.DesiredSpeedOverride.HasValue)
							{
								current.SetThrottle(((Aircraft)current).Loadout.get_MissionProfile(current.ParentScen).CruiseThrottleSettingIngress);
							}
						}
					}
					else if (!method_12().Kinematics.DesiredSpeedOverride.HasValue)
					{
						method_12().SetThrottle(method_12().Loadout.get_MissionProfile(method_12().ParentScen).CruiseThrottleSettingIngress);
					}
					((ActiveUnit)method_12()).set_DesiredHeading(method_12().DesiredTurnRate, num);
					break;
				}
				case Mission._MissionClass.Patrol:
				{
					Patrol patrol = (Patrol)method_12().ActiveMissionOrPackage();
					if (patrol == null)
					{
						break;
					}
					if (method_12().Loadout != null)
					{
						AircraftMissionProfile aircraftMissionProfile2 = method_12().Loadout.get_MissionProfile(method_12().ParentScen);
						if (patrol.UseStationAltitude_Preset == true)
						{
							patrol.StationAltitude_Aircraft = ActiveUnit_AI.ConvertAltitudePresetToValue_AI(patrol.StationAltitude_Preset.Value, patrol.StationAltitude_Aircraft, aircraftMissionProfile2.StationAltitude, aircraftMissionProfile2.CruiseAltitudeIngress);
						}
						if (patrol.UseTransitAltitude_Preset == true)
						{
							patrol.TransitAltitude_Aircraft = ActiveUnit_AI.ConvertAltitudePresetToValue_AI(patrol.TransitAltitude_Preset.Value, patrol.TransitAltitude_Aircraft, aircraftMissionProfile2.CruiseAltitudeIngress);
						}
						if (patrol.UseAttackAltitude_Preset == true)
						{
							patrol.AttackAltitude_Aircraft = ActiveUnit_AI.ConvertAltitudePresetToValue_AI(patrol.AttackAltitude_Preset.Value, patrol.AttackAltitude_Aircraft, aircraftMissionProfile2.AttackAltitudeIngress);
						}
					}
					if (method_12().Status == ActiveUnit._ActiveUnitStatus.EngagedOffensive)
					{
						if (patrol.AttackThrottle_Aircraft.HasValue)
						{
							method_12().SetThrottle(patrol.AttackThrottle_Aircraft.Value);
						}
						else if (method_12().IsPerformingStandoffAttack)
						{
							method_12().SetThrottle(ActiveUnit.Throttle.Cruise);
						}
						else
						{
							method_12().SetThrottle(ActiveUnit.Throttle.Flank);
						}
					}
					break;
				}
				case Mission._MissionClass.Support:
				{
					SupportMission supportMission = (SupportMission)method_12().ActiveMissionOrPackage();
					if (method_12().Loadout == null)
					{
						break;
					}
					AircraftMissionProfile aircraftMissionProfile4 = method_12().Loadout.get_MissionProfile(method_12().ParentScen);
					if (supportMission != null)
					{
						if (supportMission.UseStationAltitude_Preset == true)
						{
							supportMission.StationAltitude_Aircraft = ActiveUnit_AI.ConvertAltitudePresetToValue_AI(supportMission.StationAltitude_Preset.Value, supportMission.StationAltitude_Aircraft, aircraftMissionProfile4.StationAltitude, aircraftMissionProfile4.CruiseAltitudeIngress);
						}
						if (supportMission.UseTransitAltitude_Preset == true)
						{
							supportMission.TransitAltitude_Aircraft = ActiveUnit_AI.ConvertAltitudePresetToValue_AI(supportMission.TransitAltitude_Preset.Value, supportMission.TransitAltitude_Aircraft, aircraftMissionProfile4.CruiseAltitudeIngress);
						}
					}
					break;
				}
				case Mission._MissionClass.Mining:
				{
					AircraftMissionProfile aircraftMissionProfile3 = method_12().Loadout.get_MissionProfile(method_12().ParentScen);
					MiningMission miningMission = (MiningMission)method_12().ActiveMissionOrPackage();
					if (miningMission != null && miningMission != null)
					{
						if (miningMission.UseStationAltitude_Preset == true)
						{
							miningMission.StationAltitude_Aircraft = ActiveUnit_AI.ConvertAltitudePresetToValue_AI(miningMission.StationAltitude_Preset.Value, miningMission.StationAltitude_Aircraft, aircraftMissionProfile3.StationAltitude, aircraftMissionProfile3.CruiseAltitudeIngress);
						}
						if (miningMission.UseTransitAltitude_Preset == true)
						{
							miningMission.TransitAltitude_Aircraft = ActiveUnit_AI.ConvertAltitudePresetToValue_AI(miningMission.TransitAltitude_Preset.Value, miningMission.TransitAltitude_Aircraft, aircraftMissionProfile3.CruiseAltitudeIngress);
						}
					}
					break;
				}
				case Mission._MissionClass.MineClearing:
				{
					MineClearingMission mineClearingMission = (MineClearingMission)method_12().ActiveMissionOrPackage();
					AircraftMissionProfile aircraftMissionProfile = method_12().Loadout.get_MissionProfile(method_12().ParentScen);
					if (mineClearingMission != null && mineClearingMission != null)
					{
						mineClearingMission.StationThrottle_Aircraft = ActiveUnit.Throttle.Loiter;
						if (mineClearingMission.UseStationAltitude_Preset == true)
						{
							mineClearingMission.StationAltitude_Aircraft = 76.200005f;
						}
						if (mineClearingMission.UseTransitAltitude_Preset == true)
						{
							mineClearingMission.TransitAltitude_Aircraft = ActiveUnit_AI.ConvertAltitudePresetToValue_AI(mineClearingMission.TransitAltitude_Preset.Value, mineClearingMission.TransitAltitude_Aircraft, aircraftMissionProfile.CruiseAltitudeIngress);
						}
					}
					break;
				}
				}
			}
			Aircraft_AirOps theAO = method_12().AirOps;
			ActiveUnit._ActiveUnitStatus activeUnitStatus = method_12().Status;
			GeoPoint InterruptLocation;
			switch (activeUnitStatus)
			{
			case ActiveUnit._ActiveUnitStatus.WaitForPathfinder:
				method_12().DesiredSpeed = method_12().Kinematics.GetMaximumSpeed(method_12().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Loiter, ValidateAndFixAltitude: false);
				method_12().SetThrottle(ActiveUnit.Throttle.Loiter);
				method_12().Kinematics.Loiter(elapsedTime);
				return;
			case ActiveUnit._ActiveUnitStatus.RTB_CalledOff:
				if (method_12().IsGroupWingman() && ((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).GroupLead != null && ((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.HasPlottedCourse())
				{
					activeUnitStatus = ActiveUnit._ActiveUnitStatus.Tasked;
				}
				else if (method_12().Navigator.HasPlottedCourse())
				{
					activeUnitStatus = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
				}
				break;
			case ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint:
			{
				if (method_12().IsGroupWingman() || ((ActiveUnit)method_12()).get_UnitSide(SetSideOnly: false).NoNavZones.Count <= 0 || theAO.A2AR_Destination == null || !method_12().Navigator.bool_0)
				{
					break;
				}
				Aircraft_Navigator navigator = method_12().Navigator;
				double startLat = method_12().get_Latitude((GlobalVariables.BooleanObject)null);
				double startLon = method_12().get_Longitude((GlobalVariables.BooleanObject)null);
				double destLat = theAO.A2AR_Destination.get_Latitude((GlobalVariables.BooleanObject)null);
				double destLon = theAO.A2AR_Destination.get_Longitude((GlobalVariables.BooleanObject)null);
				int ReasonForInterrupt = 0;
				InterruptLocation = null;
				if (!navigator.PathLineIsInterrupted(startLat, startLon, destLat, destLon, RunInParallel: false, 0f, CheckIfCurrentlyInsideIllegalArea: false, null, IsPathfindingQuery: true, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: true, null, ref ReasonForInterrupt, ref InterruptLocation))
				{
					method_12().Navigator.TankerIsBlockedByNoNavZone = false;
					if (Math2.CalcDist(method_12(), theAO.A2AR_Destination) < 15f && method_12().Navigator.HasPathfindingPlottedCourse)
					{
						method_12().Navigator.ClearPathfindingWaypoints();
					}
					break;
				}
				method_12().Navigator.TankerIsBlockedByNoNavZone = true;
				if (!method_12().Navigator.PathfindingPlottedCourseLeadsToA2ARDestination)
				{
					method_12().Navigator.ClearPlottedCourse();
					method_12().Navigator.HeadToDesiredPoint_AccountForPathfinderIfInGroup(elapsedTime, theAO.A2AR_Destination.get_Latitude((GlobalVariables.BooleanObject)null), theAO.A2AR_Destination.get_Longitude((GlobalVariables.BooleanObject)null));
					string text = "";
					string text2 = "";
					if (Operators.CompareString(method_12().Name, method_12().UnitClass, false) != 0)
					{
						text = " (" + method_12().UnitClass + ")";
					}
					if (Operators.CompareString(theAO.A2AR_Destination.Name, theAO.A2AR_Destination.UnitClass, false) != 0)
					{
						text2 = " (" + theAO.A2AR_Destination.UnitClass + ")";
					}
					method_12().AddMessage(method_12().Name + text + " has been ordered to refuel from tanker " + theAO.A2AR_Destination.Name + text2 + ", however the tanker is blocked by a No-Navigation Zone. Will proceed to tanker following pathfinder plotted course.", method_12().Name + " tanker is blocked by no-nav zone", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(method_12().get_Longitude((GlobalVariables.BooleanObject)null), method_12().get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				break;
			}
			}
			switch (theAO.Condition)
			{
			case Aircraft_AirOps._AirOpsCondition.TransferringCargo:
				if (!((method_12().Loadout != null) & (method_12().Loadout.Role == Loadout.LoadoutRole.SearchAndRescue || method_12().Loadout.Role == Loadout.LoadoutRole.CombatSearchAndRescue)))
				{
					if (method_12().IsOnActiveCargoMission)
					{
						CargoMission cargoMission = (CargoMission)method_12().ActiveMissionOrPackage();
						if (!method_12().Navigator.IsInsideMissionArea(ref cargoMission.Area, ref cargoMission.Area_1nm_Buffered, ref cargoMission.Area_1nm_ChangeCheck, 1, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
						{
							theAO.Condition = Aircraft_AirOps._AirOpsCondition.Airborne;
							theAO.ConditionTimer = 0f;
							return;
						}
					}
					method_12().Kinematics.DesiredSpeedOverride = null;
					method_12().SetThrottle(ActiveUnit.Throttle.FullStop);
					((ActiveUnit)method_12()).set_DesiredHeading(ActiveUnit.TurnRate.Max, method_12().CurrentHeading);
					method_12().DesiredAltitude = 0f;
					method_12().DesiredAltitude_AGL = 0f;
					if (!Module_Unit.IsOverLand(method_12()))
					{
						theAO.Condition = Aircraft_AirOps._AirOpsCondition.Airborne;
						theAO.ConditionTimer = 0f;
					}
					else if (method_12().CurrentAltitude_AGL > (float)Aircraft_AirOps.HelicopterDippingSonarAltitude || method_12().CurrentSpeed > 10f)
					{
						theAO.ConditionTimer = 120f;
					}
				}
				else if (method_12().AI.PrimaryPickupTarget != null && (double)method_12().RangeToUnit_Horiz(method_12().AI.PrimaryPickupTarget) > 0.1)
				{
					theAO.Condition = Aircraft_AirOps._AirOpsCondition.Airborne;
					theAO.ConditionTimer = 0f;
					method_12().SetThrottle(ActiveUnit.Throttle.Loiter);
					method_12().Navigator.PlotCourseToPickupPoint();
				}
				else
				{
					if (method_12().CurrentAltitude_AGL > (float)Aircraft_AirOps.HelicopterDippingSonarAltitude || method_12().CurrentSpeed > 10f)
					{
						theAO.ConditionTimer = 120f;
					}
					method_12().Kinematics.DesiredSpeedOverride = null;
					method_12().SetThrottle(ActiveUnit.Throttle.FullStop);
					((ActiveUnit)method_12()).set_DesiredHeading(ActiveUnit.TurnRate.Max, method_12().CurrentHeading);
					method_12().DesiredAltitude = 0f;
					method_12().DesiredAltitude_AGL = 0f;
				}
				return;
			case Aircraft_AirOps._AirOpsCondition.DeployingDippingSonar:
				method_12().Kinematics.DesiredSpeedOverride = null;
				method_12().SetThrottle(ActiveUnit.Throttle.FullStop);
				((ActiveUnit)method_12()).set_DesiredHeading(ActiveUnit.TurnRate.Max, method_12().CurrentHeading);
				method_12().DesiredAltitude = Aircraft_AirOps.HelicopterDippingSonarAltitude;
				if (!Module_Unit.IsOverLand(method_12()) && !SeaIceProvider.PointIsUnderIce(method_12().get_Longitude((GlobalVariables.BooleanObject)null), method_12().get_Latitude((GlobalVariables.BooleanObject)null)))
				{
					if (method_12().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > (float)Aircraft_AirOps.HelicopterDippingSonarAltitude)
					{
						theAO.ConditionTimer = 240f;
					}
				}
				else
				{
					theAO.Condition = Aircraft_AirOps._AirOpsCondition.Airborne;
					theAO.ConditionTimer = 0f;
				}
				return;
			}
			if (!method_12().ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DroneAutonomyLevels) && method_12().IsDrone() && !((ActiveUnit_CommStuff)method_12().CommStuff).IsConnectedToSideNetwork && !((ActiveUnit)method_12()).IsRTB)
			{
				method_12().Kinematics.Loiter(elapsedTime);
				return;
			}
			bool? obj6;
			MiningMission miningMission2;
			GeoPoint geoPoint;
			Waypoint waypoint;
			float bearing;
			double lon;
			double lat;
			double out_lon;
			double out_lat;
			GeoPoint geoPoint2;
			bool? flag4;
			bool? flag5;
			bool? flag;
			switch (activeUnitStatus)
			{
			case ActiveUnit._ActiveUnitStatus.Unassigned:
			case ActiveUnit._ActiveUnitStatus.Manual_Unassigned:
				if (!method_12().IsGroupLead())
				{
					if (!method_12().IsGroupMember())
					{
						int value4;
						if (method_12().IsHelicopter)
						{
							if (!method_12().Sensory.HasAvailableDippingSonar)
							{
								value4 = 0;
							}
							else if (method_12().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= (float)Aircraft_AirOps.HelicopterDippingSonarAltitude && method_12().DesiredAltitude <= (float)Aircraft_AirOps.HelicopterDippingSonarAltitude)
							{
								if (((Module_Unit.Unit)method_12()).get_LandElevation_next(AGL: false, elapsedTime) < 0)
								{
									byte? b = (byte?)method_12().Doctrine.get_DippingSonar(method_12().ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
									obj6 = ((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0));
									goto IL_0cad;
								}
								value4 = 0;
							}
							else
							{
								value4 = 0;
							}
						}
						else
						{
							value4 = 0;
						}
						obj6 = (byte)value4 != 0;
						goto IL_0cad;
					}
					if (((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).Type == Group.GroupType.AirGroup)
					{
						method_12().Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
					}
					else
					{
						method_12().Kinematics.Loiter(elapsedTime);
					}
				}
				else
				{
					method_12().Kinematics.Loiter(elapsedTime);
				}
				goto IL_0de7;
			case ActiveUnit._ActiveUnitStatus.OnPlottedCourse:
			{
				if (method_12().ActiveMissionOrPackage() != null && method_12().ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Strike)
				{
					if (method_12().IsOnActivePatrol())
					{
						Patrol patrol3 = (Patrol)method_12().ActiveMissionOrPackage();
						if (!GlobalVariables.AI_REWORK && PrimaryTarget != null && ((Module_Unit.Unit)method_12()).get_IsInsideThisArea(patrol3.PatrolArea, method_12().ParentScen, UseCache: false))
						{
							Contact primaryTarget2 = PrimaryTarget;
							Mission theMission = method_12().ActiveMissionOrPackage();
							Doctrine._UseShootTourists? canShootTourists = method_12().Doctrine.get_ShootTourists(method_12().ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
							string UserFeedback = "";
							int FeedbackSeverity = 0;
							if (ContactIsRelevantToFlightOrMission(primaryTarget2, theMission, canShootTourists, IgnoreContacStance: false, MyUnitIsInsidePatrolArea: true, IgnoreNeutralContacts: true, null, ref UserFeedback, ref FeedbackSeverity))
							{
								method_12().Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
								break;
							}
						}
						if (method_12().Navigator.HasFlightPlan)
						{
							if (!myUnit.IsGroupWingman())
							{
								method_12().Navigator.FollowPlottedCourse(elapsedTime);
							}
							else
							{
								method_12().Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
							}
						}
						else if (method_12().Navigator.HasPlottedCourse())
						{
							bool? obj4;
							if (method_12().Navigator.NextWaypointIsManual)
							{
								obj4 = true;
							}
							else
							{
								Waypoint? waypoint2 = method_12().Navigator.PlottedCourse.FirstOrDefault();
								obj4 = ((waypoint2 == null) ? ((bool?)null) : new bool?(waypoint2.Type == Waypoint.WaypointType.LocalizationRun));
							}
							flag = obj4;
							if (((!flag) ?? flag) == true)
							{
								if (!method_12().Navigator.PlottedCourseLeadsToMissionArea(ref patrol3.PatrolArea, ref patrol3.PatrolArea_30nm_Buffered, ref patrol3.PatrolArea_30nm_ChangeCheck, 30f, IgnoreTimeToNextEvaluation: false))
								{
									method_12().Navigator.ClearPlottedCourse();
									method_12().Navigator.PlotCourseToStationArea(elapsedTime, AddWaypointToExistingPlottedCourse: false);
								}
								else if (method_12()._Status_Oldvalue == ActiveUnit._ActiveUnitStatus.EngagedOffensive && patrol3.PatrolArea[0].BearingType == ReferencePoint.OrientationType.Fixed && !method_12().Navigator.PlottedCourseLeadsToMissionArea(ref patrol3.PatrolArea, ref patrol3.PatrolArea, ref patrol3.PatrolArea_ChangeCheck, 0f, IgnoreTimeToNextEvaluation: false))
								{
									method_12().Navigator.ClearPlottedCourse();
									method_12().Navigator.PlotCourseToStationArea(elapsedTime, AddWaypointToExistingPlottedCourse: false);
								}
								if (method_12().AI.PrimaryTarget == null)
								{
									byte? b = (byte?)method_12().Doctrine.get_IgnorePlottedCourse(method_12().ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false);
									if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) == true)
									{
										if (method_12().Doctrine.IgnorePlottedCourse_Inherits() != patrol3.Doctrine.IgnorePlottedCourse_Inherits())
										{
											method_12().Doctrine.set_IgnorePlottedCourse(method_12().ParentScen, MultipleUnits: false, (bool?)false, ViaDoctrineForm: false, ViaRightColumn: false, patrol3.Doctrine.get_IgnorePlottedCourse(method_12().ParentScen, MultipleUnits: false, (bool?)false, ViaDoctrineForm: false, ViaRightColumn: false));
										}
										else
										{
											b = (byte?)patrol3.Doctrine.get_IgnorePlottedCourse(method_12().ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false);
											flag = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
											if (((!flag) ?? flag) == true)
											{
												method_12().Doctrine.set_IgnorePlottedCourse(method_12().ParentScen, MultipleUnits: false, (bool?)false, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._UseIgnorePlottedCourse?)Doctrine._UseIgnorePlottedCourse.Yes);
											}
										}
									}
								}
							}
						}
						else if (!method_12().IsGroupWingman())
						{
							method_12().Navigator.PlotCourseToStationArea(elapsedTime, AddWaypointToExistingPlottedCourse: false);
						}
						else
						{
							method_12().Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
						}
					}
					else if (method_12().IsOnActiveMineClearingMission)
					{
						method_43(elapsedTime);
					}
				}
				if (((method_12().WeaponState != ActiveUnit._ActiveUnitWeaponState.IgnoreWinchesterAndShotgun) & myUnit.ParentScen.SecondIsChangingOnThisPulse) && method_12().Weaponry.IsWinchesterOrShotgun() == ActiveUnit._ActiveUnitWeaponState.IsWinchester && !FollowingRTB_PlottedCourse())
				{
					bool flag2 = method_12().Doctrine.WinchesterShotgunRTB.Value != Doctrine._WeaponStateRTB.No;
					if (method_12().IsGroupMember())
					{
						flag2 = flag2 && method_12().Doctrine.WinchesterShotgunRTB.Value != Doctrine._WeaponStateRTB.YesLastUnit && method_12().Doctrine.WinchesterShotgunRTB.Value != Doctrine._WeaponStateRTB.YesLeaveGroup;
					}
					if (!flag2)
					{
						if (method_12().IsGroupWingman())
						{
							method_12().Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
						}
						else if (!method_12().Navigator.HasPlottedCourse())
						{
							method_12().Kinematics.Loiter(elapsedTime);
						}
						else
						{
							method_12().Navigator.FollowPlottedCourse(elapsedTime);
						}
					}
					else if (!GlobalVariables.AI_REWORK)
					{
						method_12().AirOps.AttemptToRTB(ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB, GroupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, DetachFromGroup: true, ClearPlottedCourse: true);
					}
					else
					{
						method_12().AI.StatusRelatedEvents.method_0(manuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB, groupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, detachFromGroup: true, clearPlottedCourse: true);
					}
					break;
				}
				if (method_12().IsGroupWingman())
				{
					if (myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.PlottedCourse != null && myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.PlottedCourse.Count() > 0)
					{
						bool flag3 = false;
						Waypoint[] plottedCourse = method_12().Navigator.PlottedCourse;
						for (int FeedbackSeverity = 0; FeedbackSeverity < plottedCourse.Length; FeedbackSeverity = checked(FeedbackSeverity + 1))
						{
							if (myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.PlottedCourse.FirstOrDefault()?.Waypoint_LeadElementWingman != null)
							{
								flag3 = true;
								break;
							}
						}
						if (!flag3)
						{
							method_12().Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
							method_12().Navigator.PlottedCourse = myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.PlottedCourse;
						}
						else if (method_12().Navigator.HasPlottedCourse())
						{
							method_12().Navigator.FollowPlottedCourse(elapsedTime);
						}
					}
					else if (method_12().Navigator.HasPlottedCourse())
					{
						method_12().Navigator.FollowPlottedCourse(elapsedTime);
					}
				}
				else if (method_12().Navigator.HasPlottedCourse())
				{
					method_12().Navigator.FollowPlottedCourse(elapsedTime);
				}
				if (method_12().ActiveMissionOrPackage() == null)
				{
					if (method_12().Navigator.HasPlottedCourse() && method_12().AI.PrimaryTarget != null && (method_12().AI.PrimaryTarget.Type == Contact_Base.ContactType.Submarine || method_12().AI.PrimaryTarget.Type == Contact_Base.ContactType.Surface) && method_12().Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.LocalizationRun)
					{
						Aircraft_Navigator navigator4 = method_12().Navigator;
						navigator4.SetPatrolThrottle(PursueContact: false, theAO.Condition);
						navigator4.SetPatrolAltitude(PursueContact: false, theAO.Condition);
					}
				}
				else if (method_12().ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Strike)
				{
					if (method_12().ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Ferry)
					{
						if (!method_12().IsGroupWingman())
						{
							_ = method_12().Navigator;
							if (method_12().IsOnActiveMiningMission)
							{
								if (!method_12().Kinematics.DesiredAltitudeOverride)
								{
									MiningMission miningMission3 = (MiningMission)method_12().ActiveMissionOrPackage();
									if (!method_12().IsAircraft)
									{
										if (method_12().Navigator.IsInsideMissionArea(ref miningMission3.Area, ref miningMission3.Area_2nm_Buffered, ref miningMission3.Area_2nm_ChangeCheck, 2, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
										{
											AdjustAltitudeForMinelaying();
										}
									}
									else if (method_12().Navigator.IsInsideMissionArea(ref miningMission3.Area, ref miningMission3.Area_5nm_Buffered, ref miningMission3.Area_5nm_ChangeCheck, 5, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
									{
										AdjustAltitudeForMinelaying();
									}
								}
							}
							else if (method_12().IsOnActiveCargoMission)
							{
								CargoMission cargoMission_ = (CargoMission)method_12().ActiveMissionOrPackage();
								method_44(cargoMission_);
							}
							else if (method_12().IsOnActivePatrol() & !method_12().Navigator.HasFlightPlan)
							{
								Patrol patrol4 = (Patrol)method_12().ActiveMissionOrPackage();
								if (method_12().AI.IsInsidePatrolArea_2nmBuffer)
								{
									if (!method_12().Kinematics.DesiredSpeedOverride.HasValue && patrol4.StationThrottle_Aircraft.HasValue)
									{
										method_12().SetThrottle(patrol4.StationThrottle_Aircraft.Value);
									}
									if (!method_12().Kinematics.DesiredAltitudeOverride && patrol4.StationAltitude_Aircraft.HasValue)
									{
										method_12().DesiredAltitude = patrol4.StationAltitude_Aircraft.Value;
									}
								}
								else
								{
									if (!method_12().Kinematics.DesiredSpeedOverride.HasValue && patrol4.TransitThrottle_Aircraft.HasValue)
									{
										method_12().SetThrottle(patrol4.TransitThrottle_Aircraft.Value);
									}
									if (!method_12().Kinematics.DesiredAltitudeOverride && patrol4.TransitAltitude_Aircraft.HasValue)
									{
										method_12().DesiredAltitude = patrol4.TransitAltitude_Aircraft.Value;
									}
								}
							}
							else if (method_12().Navigator.HasFlightPlan)
							{
								method_12().Navigator.FollowPlottedCourse(elapsedTime);
							}
						}
						else if (method_12().IsOnActivePatrol() & !method_12().Navigator.HasFlightPlan)
						{
							Patrol patrol5 = (Patrol)method_12().ActiveMissionOrPackage();
							if (method_12().AI.IsInsidePatrolArea_2nmBuffer)
							{
								if (!method_12().Kinematics.DesiredAltitudeOverride && patrol5.StationAltitude_Aircraft.HasValue)
								{
									method_12().DesiredAltitude = patrol5.StationAltitude_Aircraft.Value;
								}
							}
							else if (!method_12().Kinematics.DesiredAltitudeOverride && patrol5.TransitAltitude_Aircraft.HasValue)
							{
								method_12().DesiredAltitude = patrol5.TransitAltitude_Aircraft.Value;
							}
						}
					}
					else
					{
						FerryMission ferryMission2 = (FerryMission)method_12().ActiveMissionOrPackage();
						if (method_12().Kinematics.DesiredSpeedOverride.HasValue)
						{
							method_12().SetThrottle(method_12().ThrottleSetting);
						}
						else if (method_12().Loadout != null)
						{
							if (ferryMission2.FerryThrottle_Aircraft.HasValue)
							{
								method_12().SetThrottle(ferryMission2.FerryThrottle_Aircraft.Value);
							}
							else
							{
								method_12().SetThrottle(ActiveUnit.Throttle.Cruise);
							}
						}
						else
						{
							method_12().SetThrottle(ActiveUnit.Throttle.Cruise);
						}
						if (!method_12().Kinematics.DesiredAltitudeOverride)
						{
							if (method_12().Loadout == null)
							{
								Aircraft aircraft3 = method_12();
								Aircraft aircraft = method_12();
								ActiveUnit.Throttle throttleSetting = method_12().ThrottleSetting;
								Aircraft theAircraft;
								ActiveUnit theSelectedTanker;
								bool IsRTB = (theAircraft = method_12()).get_DesiredAltitude_UseTerrainFollowing(theSelectedTanker = method_12());
								float num7 = MostRealisticOptimumAltitude(ref aircraft, throttleSetting, ref IsRTB);
								theAircraft.set_DesiredAltitude_UseTerrainFollowing(theSelectedTanker, IsRTB);
								aircraft3.DesiredAltitude = num7;
							}
							else if (!ferryMission2.FerryAltitude_Aircraft.HasValue)
							{
								Aircraft aircraft4 = method_12();
								Aircraft theAircraft = method_12();
								ActiveUnit.Throttle throttleSetting2 = method_12().ThrottleSetting;
								Aircraft aircraft;
								ActiveUnit theSelectedTanker;
								bool IsRTB = (aircraft = method_12()).get_DesiredAltitude_UseTerrainFollowing(theSelectedTanker = method_12());
								float num8 = MostRealisticOptimumAltitude(ref theAircraft, throttleSetting2, ref IsRTB);
								aircraft.set_DesiredAltitude_UseTerrainFollowing(theSelectedTanker, IsRTB);
								aircraft4.DesiredAltitude = num8;
							}
							else
							{
								method_12().DesiredAltitude = ferryMission2.FerryAltitude_Aircraft.Value;
							}
						}
						else
						{
							method_12().DesiredAltitude = method_12().DesiredAltitude;
						}
						if (method_12().IsTanker)
						{
							AssistRefuellingClients();
						}
					}
				}
				else if (method_12().ParentScen.MinuteIsChangingOnThisPulse)
				{
					if (!method_12().Navigator.IsOnAutoPlannerPlottedCourse_CruiseAndAttackEgressRun)
					{
						LeadMustSlowDownDueToBingo = false;
					}
					else
					{
						LeadMustSlowDownDueToBingo = false;
						if (method_12().IsGroupMember())
						{
							IEnumerator<ActiveUnit> enumerator2 = ((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).Units.Values.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								if (enumerator2.Current.FuelState != ActiveUnit._ActiveUnitFuelState.IsBingo)
								{
									continue;
								}
								if (method_12().ThrottleSetting <= ActiveUnit.Throttle.Cruise)
								{
									LeadMustSlowDownDueToBingo = true;
									continue;
								}
								method_12().SetThrottle(ActiveUnit.Throttle.Cruise);
								if (method_12().Kinematics.DesiredSpeedOverride.HasValue)
								{
									method_12().Kinematics.DesiredSpeedOverride = null;
								}
								method_12().ParentScen.AddMessage("One of the aircraft in " + ((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).Name + " has reached Bingo fuel, so the flight goes to cruise speed to prevent running any of the wingmen dry!", ((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).Name + " slowing to cruise (thirsty member)", LoggedMessage.MessageType.AirOps, 0, null, ((ActiveUnit)method_12()).get_UnitSide(SetSideOnly: false), new Geopoint_Struct(method_12().get_Longitude((GlobalVariables.BooleanObject)null), method_12().get_Latitude((GlobalVariables.BooleanObject)null)));
								break;
							}
						}
						else if (method_12().FuelState == ActiveUnit._ActiveUnitFuelState.IsBingo)
						{
							if (method_12().ThrottleSetting > ActiveUnit.Throttle.Cruise)
							{
								string text4 = "";
								if (Operators.CompareString(method_12().Name, method_12().UnitClass, false) != 0)
								{
									text4 = " (" + method_12().UnitClass + ")";
								}
								method_12().ParentScen.AddMessage("Aircraft " + method_12().Name + text4 + " has reached Bingo fuel, so the aircraft goes to cruise speed to prevent running dry", method_12().Name + " slowing to cruise (Bingo)", LoggedMessage.MessageType.AirOps, 0, null, ((ActiveUnit)method_12()).get_UnitSide(SetSideOnly: false), new Geopoint_Struct(method_12().get_Longitude((GlobalVariables.BooleanObject)null), method_12().get_Latitude((GlobalVariables.BooleanObject)null)));
								method_12().SetThrottle(ActiveUnit.Throttle.Cruise);
							}
							LeadMustSlowDownDueToBingo = true;
						}
					}
				}
				bool? obj5;
				if (method_12().Navigator.PlottedCourse.Count() <= 0)
				{
					obj5 = false;
				}
				else
				{
					Waypoint? waypoint3 = method_12().Navigator.PlottedCourse.FirstOrDefault();
					obj5 = ((waypoint3 != null) ? new bool?(waypoint3.Type == Waypoint.WaypointType.LocalizationRun) : ((bool?)null));
				}
				flag = obj5;
				if ((flag ?? true) && method_12().UnitType == GlobalVariables.ActiveUnitType.Aircraft && flag.HasValue && PrimaryTarget != null && PrimaryTarget.Type == Contact_Base.ContactType.Submarine)
				{
					if (PrimaryTarget.UncertaintyArea != null)
					{
						if (!GeoPoint.IsInsideThisArea(method_12().Navigator.PlottedCourse[0].Latitude, method_12().Navigator.PlottedCourse[0].Longitude, PrimaryTarget.UncertaintyArea))
						{
							method_12().Navigator.ClearPlottedCourse();
						}
					}
					else
					{
						method_12().Navigator.ClearPlottedCourse();
					}
				}
				SpeedAdjustmentForToT(elapsedTime);
				PerformTerrainFollowingIfNecessary();
				if (method_12().IsTanker)
				{
					AssistRefuellingClients();
				}
				break;
			}
			case ActiveUnit._ActiveUnitStatus.EngagedOffensive:
				if (PrimaryTarget == null)
				{
					int num9;
					if (((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false) != null)
					{
						if (((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).IsPerformingStandoffAttack)
						{
							PrimaryTarget = method_26();
							goto IL_1f6f;
						}
						num9 = 7;
					}
					else
					{
						num9 = 7;
					}
					activeUnitStatus = (ActiveUnit._ActiveUnitStatus)num9;
					break;
				}
				goto IL_1f6f;
			case ActiveUnit._ActiveUnitStatus.EngagedDefensive:
				if (method_12().Navigator.HasFlightPlan && !method_12().Navigator.IsOnAutoPlannerPlottedCourse_FinalTargetRun)
				{
					Aircraft_Navigator navigator5 = method_12().Navigator;
					bool BingoFuelEndurance = false;
					bool IsRTB = false;
					navigator5.CheckIfReachedWaypoint_AND_Apply_WP_logic(elapsedTime, ref BingoFuelEndurance, ref IsRTB);
				}
				if (_PrimaryThreat != null)
				{
					method_12().Kinematics.DesiredSpeedOverride = null;
					ManouverAgainstPrimaryThreat(elapsedTime);
				}
				break;
			case ActiveUnit._ActiveUnitStatus.OnPatrol:
			{
				if (Information.IsNothing((object)method_12().ActiveMissionOrPackage()))
				{
					activeUnitStatus = ActiveUnit._ActiveUnitStatus.Unassigned;
					break;
				}
				if (method_12().ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Patrol)
				{
					break;
				}
				Patrol patrol2 = (Patrol)method_12().ActiveMissionOrPackage();
				if (myUnit.IsUsingDippingSonar())
				{
					method_12().Navigator.ClearPlottedCourse();
					theAO.HoverForDippingSonar();
				}
				else if (patrol2 == null)
				{
					if (!GlobalVariables.AI_REWORK)
					{
						activeUnitStatus = ActiveUnit._ActiveUnitStatus.Unassigned;
					}
				}
				else if (method_12().IsGroupMember())
				{
					if (!method_12().IsGroupLead())
					{
						method_12().Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
					}
					else if (method_12().Navigator.HasFlightPlan)
					{
						method_12().Navigator.FollowPlottedCourse(elapsedTime);
					}
					else if (method_12().Navigator.Has_NonPathfind_NonFP_PlottedCourse())
					{
						if (!((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).Navigator.PlottedCourseLeadsToMissionArea(ref patrol2.PatrolArea, ref patrol2.PatrolArea_30nm_Buffered, ref patrol2.PatrolArea_30nm_ChangeCheck, 30f, IgnoreTimeToNextEvaluation: false))
						{
							((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).Navigator.PlotCourseToStationArea(elapsedTime, AddWaypointToExistingPlottedCourse: false);
						}
						method_12().Navigator.FollowPlottedCourse(elapsedTime);
					}
					else
					{
						((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).Navigator.PlotCourseToStationArea(elapsedTime, AddWaypointToExistingPlottedCourse: false);
					}
				}
				else if (method_12().Navigator.Has_NonPathfind_NonFP_PlottedCourse())
				{
					if (method_12().Navigator.HasFlightPlan)
					{
						break;
					}
					if (!method_12().Navigator.NextWaypointIsManual)
					{
						if (method_12().Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.PatrolStation)
						{
							if (!method_12().Navigator.PlottedCourseLeadsToMissionArea(ref patrol2.PatrolArea, ref patrol2.PatrolArea_30nm_Buffered, ref patrol2.PatrolArea_30nm_ChangeCheck, 30f, IgnoreTimeToNextEvaluation: false))
							{
								method_12().Navigator.PlotCourseToStationArea(elapsedTime, AddWaypointToExistingPlottedCourse: false);
							}
							method_12().Navigator.FollowPlottedCourse(elapsedTime);
						}
					}
					else
					{
						method_12().Navigator.FollowPlottedCourse(elapsedTime);
					}
				}
				else
				{
					method_12().Navigator.PlotCourseToStationArea(elapsedTime, AddWaypointToExistingPlottedCourse: false);
				}
				break;
			}
			case ActiveUnit._ActiveUnitStatus.Tasked:
				if (!method_12().IsOnActiveCargoMission)
				{
					if (method_12().ActiveMissionOrPackage() == null)
					{
						activeUnitStatus = ActiveUnit._ActiveUnitStatus.Unassigned;
						break;
					}
					if (method_12().ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Mining)
					{
						miningMission2 = (MiningMission)method_12().ActiveMissionOrPackage();
						if (method_12().AI.MiningInfo == null)
						{
							method_12().AI.MiningInfo = new MiningMission.MiningInformation(null, miningMission2.MinesLaidInSets, miningMission2.MinesLaidInterval, miningMission2.MinesLaidMethod, miningMission2.MinesLaidSetInterval);
						}
						if (miningMission2.MovementStyle == Patrol.PatrolMovementStyle.RepeatableLoop)
						{
							bool isInTransit = method_12().Navigator.SupportMission_NextRefPoint == miningMission2.Area[0];
							method_12().Navigator.FollowPatrolRepeatableLoopCourse(elapsedTime, isInTransit);
							break;
						}
						if (method_12().Navigator.Has_NonPathfind_NonFP_PlottedCourse())
						{
							if (!method_12().IsGroupMember())
							{
								if (method_12().Navigator.PlottedCourse[0].Creator == Waypoint.WaypointCreator.Manual)
								{
									method_12().Navigator.PlottedCourse[0].Description = "Mining Mission Segment Start - Manual";
									if (!method_12().Kinematics.DesiredSpeedOverride.HasValue)
									{
										if (!method_12().Navigator.IsInsideMissionArea(ref miningMission2.Area, ref miningMission2.Area_1nm_Buffered, ref miningMission2.Area_1nm_ChangeCheck, 1, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
										{
											method_12().SetThrottle(miningMission2.TransitThrottle_Ship);
											method_12().AI.MiningInfo.StartedMining = false;
										}
										else
										{
											method_12().SetThrottle(miningMission2.StationThrottle_Ship);
										}
									}
									break;
								}
							}
							else
							{
								ActiveUnit groupLead2 = ((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).GroupLead;
								if (groupLead2.Navigator.PlottedCourse[0].Creator == Waypoint.WaypointCreator.Manual)
								{
									groupLead2.Navigator.PlottedCourse[0].Description = "Mining Mission Segment Start - Manual";
									if (!method_12().Kinematics.DesiredSpeedOverride.HasValue)
									{
										if (!method_12().Navigator.IsInsideMissionArea(ref miningMission2.Area, ref miningMission2.Area_1nm_Buffered, ref miningMission2.Area_1nm_ChangeCheck, 1, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
										{
											method_12().SetThrottle(miningMission2.TransitThrottle_Ship);
											method_12().AI.MiningInfo.StartedMining = false;
										}
										else
										{
											method_12().SetThrottle(miningMission2.StationThrottle_Ship);
										}
									}
									break;
								}
							}
						}
						if (method_12().IsGroupMember())
						{
							if (!method_12().IsGroupLead())
							{
								if (((ActiveUnit_CommStuff)method_12().CommStuff).IsConnectedToSideNetwork)
								{
									method_12().Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
								}
							}
							else if (method_12().Navigator.Has_NonPathfind_NonFP_PlottedCourse())
							{
								if (((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).Navigator.IsInsideMissionArea(ref miningMission2.Area, ref miningMission2.Area_1nm_Buffered, ref miningMission2.Area_1nm_ChangeCheck, 1, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
								{
									if (method_12().AI.MiningInfo != null && !method_12().AI.MiningInfo.StartedMining)
									{
										method_12().AI.MiningInfo.StartedMining = true;
									}
								}
								else if (((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).Navigator.PlottedCourseLeadsToMissionArea(ref miningMission2.Area, ref miningMission2.Area_30nm_Buffered, ref miningMission2.Area_30nm_ChangeCheck, 30f, IgnoreTimeToNextEvaluation: false))
								{
									method_12().Navigator.FollowPlottedCourse(elapsedTime);
								}
								else
								{
									((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).Navigator.PlotCourseToArea(miningMission2.Area);
									if (method_12().AI.MiningInfo != null)
									{
										method_12().AI.MiningInfo.ResetMiningInfo(method_12(), miningMission2);
									}
								}
							}
							else
							{
								((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).Navigator.PlotCourseToArea(miningMission2.Area);
								if (method_12().AI.MiningInfo != null)
								{
									method_12().AI.MiningInfo.ResetMiningInfo(method_12(), miningMission2);
								}
							}
						}
						else if (method_12().Navigator.Has_NonPathfind_NonFP_PlottedCourse())
						{
							if (!method_12().Navigator.IsInsideMissionArea(ref miningMission2.Area, ref miningMission2.Area_1nm_Buffered, ref miningMission2.Area_1nm_ChangeCheck, 1, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
							{
								if (method_12().Navigator.PlottedCourseLeadsToMissionArea(ref miningMission2.Area, ref miningMission2.Area_30nm_Buffered, ref miningMission2.Area_30nm_ChangeCheck, 30f, IgnoreTimeToNextEvaluation: false))
								{
									method_12().Navigator.FollowPlottedCourse(elapsedTime);
								}
								else
								{
									method_12().Navigator.PlotCourseToArea(miningMission2.Area);
									if (method_12().AI.MiningInfo != null)
									{
										method_12().AI.MiningInfo.ResetMiningInfo(method_12(), miningMission2);
									}
									if (method_12().Navigator.PlottedCourse.Count() > 0)
									{
										method_12().Navigator.PlottedCourse[0].Description = "Mining Mission Segment Start";
									}
								}
							}
						}
						else if (method_12().Navigator.IsInsideMissionArea(ref miningMission2.Area, ref miningMission2.Area, ref miningMission2.Area_ChangeCheck, 0, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
						{
							if (method_12().AI.MiningInfo != null && !method_12().AI.MiningInfo.StartedMining)
							{
								method_12().AI.MiningInfo.StartedMining = true;
							}
							MiningMission.MiningInformation miningInfo = method_12().AI.MiningInfo;
							if (miningInfo != null && miningInfo.Sequence.HasValue)
							{
								int? num10 = method_12().AI.MiningInfo?.Sequence;
								if (((!num10.HasValue) ? ((bool?)null) : new bool?(num10.GetValueOrDefault() > 0)) == true)
								{
									if (!method_12().Navigator.HasPlottedCourse())
									{
										geoPoint = new GeoPoint();
										waypoint = new Waypoint();
										float desiredHeading = ((ActiveUnit)method_12()).DesiredHeading;
										bearing = desiredHeading;
										if (miningMission2.MinesLaidMethod.HasValue)
										{
											num10 = miningMission2.MinesLaidMethod;
											if (((!num10.HasValue) ? ((bool?)null) : new bool?(num10.GetValueOrDefault() == 0)) == true)
											{
												bearing = desiredHeading;
												goto IL_31d6;
											}
										}
										bearing = Math2.NormalizeBearing(desiredHeading + (float)GameGeneral.GlobalRNG.Next(45) - (float)GameGeneral.GlobalRNG.Next(45));
										goto IL_31d6;
									}
									goto IL_337c;
								}
							}
							method_12().Navigator.PlotCourseToArea(miningMission2.Area);
							if (method_12().Navigator.PlottedCourse.Count() > 0)
							{
								method_12().Navigator.PlottedCourse[0].Description = "Mining Mission Segment Start";
							}
							if (method_12().AI.MiningInfo != null)
							{
								method_12().AI.MiningInfo.ResetMiningInfo(method_12(), miningMission2);
							}
						}
						else
						{
							method_12().Navigator.PlotCourseToArea(miningMission2.Area);
							if (method_12().Navigator.PlottedCourse.Count() > 0)
							{
								method_12().Navigator.PlottedCourse[0].Description = "Mining Mission Segment Start";
							}
							if (method_12().AI.MiningInfo != null)
							{
								method_12().AI.MiningInfo.ResetMiningInfo(method_12(), miningMission2);
							}
						}
						goto IL_337c;
					}
					if (method_12().ActiveMissionOrPackage().MissionClass == Mission._MissionClass.MineClearing)
					{
						method_43(elapsedTime);
						break;
					}
					if (PrimaryTarget == null && !method_12().AI.IsEscort && !method_12().IsGroupWingman() && !method_12().Kinematics.DesiredSpeedOverride.HasValue)
					{
						method_12().SetThrottle(ActiveUnit.Throttle.Loiter);
					}
					if (method_12().ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
					{
						switch (((Strike)method_12().ActiveMissionOrPackage()).Type)
						{
						case Strike.StrikeType.Land_Strike:
						case Strike.StrikeType.Maritime_Strike:
						case Strike.StrikeType.Sub_Strike:
							if (PrimaryTarget == null && !IsEscort)
							{
								Strike strike2 = (Strike)method_12().ActiveMissionOrPackage();
								if (strike2.SpecificTargets != null && strike2.SpecificTargets.Count > 0)
								{
									Contact contactForThisUnit = GetContactForThisUnit(strike2.SpecificTargets.ElementAtOrDefault(0));
									PrimaryTarget = contactForThisUnit;
								}
							}
							if (PrimaryTarget != null)
							{
								if (!method_12().IsGroupMember())
								{
									if (!method_30())
									{
										ManouverTowardsTarget(elapsedTime);
									}
									break;
								}
								if (method_12().IsGroupLead())
								{
									ManouverTowardsTarget(elapsedTime);
									break;
								}
								if (method_12().AI.PrimaryTarget != null && ((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.HasFlightPlan)
								{
									Waypoint waypoint4 = null;
									Waypoint[] flightPlan = ((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.get_Flight(HierarchySearch: true).FlightPlan;
									foreach (Waypoint waypoint5 in flightPlan)
									{
										if (waypoint5.Type != Waypoint.WaypointType.InitialPoint || waypoint5.TargeteeringList == null)
										{
											continue;
										}
										List<Mission.TargeteeringEntry>.Enumerator enumerator3 = waypoint5.TargeteeringList.GetEnumerator();
										while (enumerator3.MoveNext())
										{
											Mission.TargeteeringEntry current2 = enumerator3.Current;
											if (Operators.CompareString(current2.Target_ContactObjectID, PrimaryTarget.ObjectID, false) == 0 || (PrimaryTarget.ActualUnit != null && Operators.CompareString(current2.Target_ActualUnitObjectID, PrimaryTarget.ActualUnit.ObjectID, false) == 0))
											{
												waypoint4 = waypoint5;
												break;
											}
										}
										if (waypoint4 != null)
										{
											break;
										}
									}
									if (waypoint4 != null)
									{
										float num11 = Math2.CalcDist(method_12().get_Latitude((GlobalVariables.BooleanObject)null), method_12().get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)method_12().AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)method_12().AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null));
										float num12 = Math2.CalcDist(method_12().get_Latitude((GlobalVariables.BooleanObject)null), method_12().get_Longitude((GlobalVariables.BooleanObject)null), waypoint4.Latitude, waypoint4.Longitude);
										if (num11 < num12)
										{
											Weapon weapon = method_12().Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, CheckIfWithinRange: false, CheckIfWithinAltitude: false, CheckWRA: true, method_12().Doctrine);
											if (weapon != null && myUnit.get_UnitSide(SetSideOnly: false).WRAQuantityRemainingForWeaponVsTarget_ExistingSalvos(myUnit, PrimaryTarget, weapon) > 0 && !method_30())
											{
												ManouverTowardsTarget(elapsedTime);
												method_12().AI.TargetThisContact(method_12().AI.PrimaryTarget, AddedManually: false, PriorityTarget: true, TargetingEntry._TargetingBehavior.AutoTargeted);
												break;
											}
										}
									}
								}
								method_12().Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
								break;
							}
							if (IsEscort)
							{
								bool IsRTB = false;
								if (method_36(elapsedTime, ref IsRTB))
								{
									break;
								}
							}
							if (!method_12().Kinematics.DesiredAltitudeOverride)
							{
								Aircraft aircraft6 = method_12();
								Aircraft aircraft = method_12();
								Aircraft theAircraft;
								ActiveUnit theSelectedTanker;
								bool IsRTB = (theAircraft = method_12()).get_DesiredAltitude_UseTerrainFollowing(theSelectedTanker = method_12());
								float desiredAltitude2 = MostRealisticOptimumAltitude(ref aircraft, ActiveUnit.Throttle.Loiter, ref IsRTB);
								theAircraft.set_DesiredAltitude_UseTerrainFollowing(theSelectedTanker, IsRTB);
								aircraft6.DesiredAltitude = desiredAltitude2;
							}
							method_12().Kinematics.Loiter(elapsedTime);
							if (IsEscort)
							{
								if (method_12().IsGroupWingman() && Math2.CalcDist(method_12().get_Latitude((GlobalVariables.BooleanObject)null), method_12().get_Longitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).GroupLead.get_Latitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).GroupLead.get_Longitude((GlobalVariables.BooleanObject)null)) > (float)((Strike)method_12().ActiveMissionOrPackage()).Escort_WingmanEngageDistance)
								{
									method_12().Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
								}
							}
							else if (method_12().IsGroupWingman() && Math2.CalcDist(method_12().get_Latitude((GlobalVariables.BooleanObject)null), method_12().get_Longitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).GroupLead.get_Latitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).GroupLead.get_Longitude((GlobalVariables.BooleanObject)null)) > Mission.SplitDistanceToNumber(((Strike)method_12().ActiveMissionOrPackage()).SplitDistance))
							{
								method_12().Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
							}
							break;
						case Strike.StrikeType.Air_Intercept:
							if (PrimaryTarget != null)
							{
								ManouverTowardsTarget(elapsedTime);
								if (!IsEscort)
								{
									if (method_12().IsGroupWingman() && Math2.CalcDist(method_12().get_Latitude((GlobalVariables.BooleanObject)null), method_12().get_Longitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).GroupLead.get_Latitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).GroupLead.get_Longitude((GlobalVariables.BooleanObject)null)) > Mission.SplitDistanceToNumber(((Strike)method_12().ActiveMissionOrPackage()).SplitDistance))
									{
										method_12().Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
									}
								}
								else if (method_12().IsGroupWingman() && Math2.CalcDist(method_12().get_Latitude((GlobalVariables.BooleanObject)null), method_12().get_Longitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).GroupLead.get_Latitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).GroupLead.get_Longitude((GlobalVariables.BooleanObject)null)) > (float)((Strike)method_12().ActiveMissionOrPackage()).Escort_WingmanEngageDistance)
								{
									method_12().Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
								}
								break;
							}
							if (!method_12().Kinematics.DesiredAltitudeOverride)
							{
								Aircraft aircraft5 = method_12();
								Aircraft theAircraft = method_12();
								Aircraft aircraft;
								ActiveUnit theSelectedTanker;
								bool IsRTB = (aircraft = method_12()).get_DesiredAltitude_UseTerrainFollowing(theSelectedTanker = method_12());
								float desiredAltitude = MostRealisticOptimumAltitude(ref theAircraft, ActiveUnit.Throttle.Loiter, ref IsRTB);
								aircraft.set_DesiredAltitude_UseTerrainFollowing(theSelectedTanker, IsRTB);
								aircraft5.DesiredAltitude = desiredAltitude;
							}
							method_12().Kinematics.Loiter(elapsedTime);
							break;
						}
					}
					else if (method_12().IsGroupWingman())
					{
						method_12().Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
					}
					break;
				}
				Manouver_CargoMission(elapsedTime);
				break;
			case ActiveUnit._ActiveUnitStatus.FormingUp:
				if (!method_12().IsGroupLead())
				{
					if (!method_12().IsGroupMember())
					{
						method_12().Kinematics.Loiter(elapsedTime, UseFormUpAltitude: true);
					}
					else if (((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).Type != Group.GroupType.AirGroup)
					{
						method_12().Kinematics.Loiter(elapsedTime);
					}
					else if (myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.PlottedCourse != null && myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.PlottedCourse.Count() > 0)
					{
						if (myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.PlottedCourse[0].Waypoint_LeadElementWingman == null)
						{
							method_12().Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
						}
						else
						{
							method_12().Navigator.FollowPlottedCourse(elapsedTime);
						}
					}
					else
					{
						method_12().Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
					}
				}
				else if (!method_12().Navigator.HasPlottedCourse())
				{
					method_12().Kinematics.Loiter(elapsedTime);
				}
				else
				{
					method_12().Navigator.FollowPlottedCourse(elapsedTime);
				}
				break;
			case ActiveUnit._ActiveUnitStatus.OnSupportMission:
				if (Information.IsNothing((object)method_12().ActiveMissionOrPackage()))
				{
					activeUnitStatus = ActiveUnit._ActiveUnitStatus.Unassigned;
					break;
				}
				if (method_12().ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Support)
				{
					break;
				}
				if (method_12().IsGroupMember())
				{
					if (!method_12().IsGroupLead())
					{
						method_12().Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
					}
					else
					{
						method_12().Navigator.FollowSupportMissionCourse(elapsedTime, method_12().Navigator.IsInSupportTransit);
					}
					break;
				}
				method_12().Navigator.FollowSupportMissionCourse(elapsedTime, method_12().Navigator.IsInSupportTransit);
				if (method_12().IsTanker)
				{
					AssistRefuellingClients();
				}
				break;
			case ActiveUnit._ActiveUnitStatus.OnFerryMission:
			{
				if (Information.IsNothing((object)method_12().ActiveMissionOrPackage()))
				{
					activeUnitStatus = ActiveUnit._ActiveUnitStatus.Unassigned;
					break;
				}
				if (method_12().ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Ferry)
				{
					break;
				}
				FerryMission ferryMission = (FerryMission)method_12().ActiveMissionOrPackage();
				ActiveUnit.Throttle throttle = (method_12().Kinematics.DesiredSpeedOverride.HasValue ? method_12().ThrottleSetting : (Information.IsNothing((object)method_12().Loadout) ? ActiveUnit.Throttle.Cruise : (Information.IsNothing((object)ferryMission.FerryThrottle_Aircraft) ? ActiveUnit.Throttle.Cruise : ferryMission.FerryThrottle_Aircraft.Value)));
				float num5;
				if (!method_12().Kinematics.DesiredAltitudeOverride)
				{
					if (method_12().Loadout != null)
					{
						if (!ferryMission.FerryAltitude_Aircraft.HasValue)
						{
							Aircraft theAircraft = method_12();
							Aircraft aircraft;
							ActiveUnit theSelectedTanker;
							bool IsRTB = (aircraft = method_12()).get_DesiredAltitude_UseTerrainFollowing(theSelectedTanker = method_12());
							float num4 = MostRealisticOptimumAltitude(ref theAircraft, throttle, ref IsRTB);
							aircraft.set_DesiredAltitude_UseTerrainFollowing(theSelectedTanker, IsRTB);
							num5 = num4;
						}
						else
						{
							num5 = ferryMission.FerryAltitude_Aircraft.Value;
						}
					}
					else
					{
						Aircraft aircraft = method_12();
						Aircraft theAircraft;
						ActiveUnit theSelectedTanker;
						bool IsRTB = (theAircraft = method_12()).get_DesiredAltitude_UseTerrainFollowing(theSelectedTanker = method_12());
						float num6 = MostRealisticOptimumAltitude(ref aircraft, throttle, ref IsRTB);
						theAircraft.set_DesiredAltitude_UseTerrainFollowing(theSelectedTanker, IsRTB);
						num5 = num6;
					}
				}
				else
				{
					num5 = method_12().DesiredAltitude;
				}
				if (!method_12().IsGroupWingman())
				{
					if (!method_12().Navigator.HasPlottedCourse() && !method_12().Navigator.HasPathfindingPlottedCourse)
					{
						if (theAO.ActualDestinationHost != null)
						{
							Aircraft_Navigator navigator3 = method_12().Navigator;
							ActiveUnit actualDestinationHost2 = theAO.ActualDestinationHost;
							float theSpeed = method_12().Kinematics.GetMaximumSpeed(method_12().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), throttle, ValidateAndFixAltitude: false);
							float theAltitude = num5;
							bool IsRTB = false;
							navigator3.HeadToLandingAssemblyPoint(elapsedTime, actualDestinationHost2, theSpeed, theAltitude, ref IsRTB);
						}
						else
						{
							string text3 = "";
							if (Operators.CompareString(method_12().Name, method_12().UnitClass, false) != 0)
							{
								text3 = " (" + method_12().UnitClass + ")";
							}
							method_12().ParentScen.AddMessage("Aircraft " + method_12().Name + text3 + " is assigned to a ferry mission but it cannot land at the desired destination. Unassigning aircraft and returning to nearest base.", method_12().Name + " cannot do ferry mission; aborting", LoggedMessage.MessageType.AirOps, 0, null, ((ActiveUnit)method_12()).get_UnitSide(SetSideOnly: false), new Geopoint_Struct(method_12().get_Longitude((GlobalVariables.BooleanObject)null), method_12().get_Latitude((GlobalVariables.BooleanObject)null)));
							Aircraft aircraft2 = method_12();
							Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
							aircraft2.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: false, ref Result);
							if (!GlobalVariables.AI_REWORK)
							{
								method_12().AirOps.AttemptToRTB(ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB, GroupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, DetachFromGroup: true, ClearPlottedCourse: true);
							}
							else
							{
								method_12().AI.StatusRelatedEvents.method_0(manuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB, groupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, detachFromGroup: true, clearPlottedCourse: true);
							}
						}
					}
					else
					{
						method_12().Navigator.FollowPlottedCourse(elapsedTime);
					}
				}
				else
				{
					method_12().Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
				}
				if (method_12().IsTanker)
				{
					AssistRefuellingClients();
				}
				break;
			}
			case ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint:
				if (method_12().ActiveMissionOrPackage() != null && method_12().ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Support)
				{
					method_12().Navigator.CheckSupportMissionCourseRefPointReached((SupportMission)method_12().ActiveMissionOrPackage(), elapsedTime);
				}
				if (method_12().IsGroupWingman() && ((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).Type == Group.GroupType.AirGroup && ((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).GroupLead != null)
				{
					ActiveUnit groupLead = ((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).GroupLead;
					if (groupLead.Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint || groupLead.Status == ActiveUnit._ActiveUnitStatus.Refuelling)
					{
						HeadToGroupLead(elapsedTime, ref theAO);
						break;
					}
				}
				if (method_12().ParentScen.MinuteIsChangingOnThisPulse || theAO.A2AR_Destination == null)
				{
					GeoPoint intermediateTargetPoint = IntermediateTargetPointForRefuelCalcs();
					Aircraft_AirOps aircraft_AirOps3 = theAO;
					bool IsRTB = false;
					ActiveUnit theSelectedTanker = null;
					string UserFeedback = "";
					List<Aircraft> potentialTankers = aircraft_AirOps3.GetPotentialTankers(ref IsRTB, ref theSelectedTanker, MustBeAbleToReachItDirectly: true, null, ref UserFeedback);
					bool MissionPlanner_PostponedRefuelling2 = false;
					if (theAO.A2AR_Destination != null && potentialTankers.Contains(theAO.A2AR_Destination))
					{
						if (!theAO.AttemptToRendezvousWithTanker(theAO.A2AR_Destination, ref MissionPlanner_PostponedRefuelling2, IsManual: true, IsForced: false))
						{
							Aircraft_AirOps aircraft_AirOps4 = theAO;
							Doctrine._UnderwayRefuelAndReplenishmentSelection value2 = method_12().Doctrine.get_ReplenishmentSelection(method_12().ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false).Value;
							IsRTB = false;
							theSelectedTanker = null;
							List<Mission> theSelectedMissions = null;
							UserFeedback = "";
							bool BingoFuelEndurance = false;
							aircraft_AirOps4.AttemptToScheduleRefuel(intermediateTargetPoint, value2, ref IsRTB, IsForced: false, ref theSelectedTanker, ref theSelectedMissions, ref UserFeedback, ref BingoFuelEndurance, ref MissionPlanner_PostponedRefuelling2);
						}
					}
					else if (potentialTankers.Count > 0)
					{
						Aircraft_AirOps aircraft_AirOps5 = theAO;
						Doctrine._UnderwayRefuelAndReplenishmentSelection value3 = method_12().Doctrine.get_ReplenishmentSelection(method_12().ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false).Value;
						bool BingoFuelEndurance = false;
						theSelectedTanker = null;
						List<Mission> theSelectedMissions = null;
						UserFeedback = "";
						IsRTB = false;
						aircraft_AirOps5.AttemptToScheduleRefuel(intermediateTargetPoint, value3, ref BingoFuelEndurance, IsForced: false, ref theSelectedTanker, ref theSelectedMissions, ref UserFeedback, ref IsRTB, ref MissionPlanner_PostponedRefuelling2);
					}
					else if (!Information.IsNothing((object)theAO.A2AR_Destination))
					{
						theAO.DisconnectFromTanker();
					}
				}
				PerformScheduledRefuel(elapsedTime);
				break;
			case ActiveUnit._ActiveUnitStatus.Refuelling:
				if (method_12().ActiveMissionOrPackage() != null && method_12().ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Support)
				{
					method_12().Navigator.CheckSupportMissionCourseRefPointReached((SupportMission)method_12().ActiveMissionOrPackage(), elapsedTime);
				}
				if (!method_12().AI.IsEscort)
				{
					if (method_12().IsGroupWingman() || method_12().ActiveMissionOrPackage() == null)
					{
						break;
					}
					if (method_12().Navigator.TankerFollowsMe.HasValue)
					{
						if (method_12().Navigator.TankerFollowsMe == true && method_12().Navigator.HasPlottedCourse())
						{
							method_12().Navigator.FollowPlottedCourse(elapsedTime);
						}
					}
					else if (method_12().ActiveMissionOrPackage().TankerFollowsReceivers && method_12().Navigator.HasPlottedCourse())
					{
						method_12().Navigator.FollowPlottedCourse(elapsedTime);
					}
					break;
				}
				if (method_12().ActiveMissionOrPackage() == null)
				{
					break;
				}
				if (!method_12().Navigator.TankerFollowsMe.HasValue)
				{
					if (method_12().ActiveMissionOrPackage().TankerFollowsReceivers)
					{
						bool IsRTB = true;
						method_36(elapsedTime, ref IsRTB);
					}
				}
				else if (method_12().Navigator.TankerFollowsMe == true && method_12().ActiveMissionOrPackage().TankerFollowsReceivers)
				{
					bool IsRTB = true;
					method_36(elapsedTime, ref IsRTB);
				}
				break;
			case ActiveUnit._ActiveUnitStatus.RTB:
			case ActiveUnit._ActiveUnitStatus.RTB_Manual:
			case ActiveUnit._ActiveUnitStatus.RTB_MissionOver:
			case ActiveUnit._ActiveUnitStatus.RTB_Group:
			case ActiveUnit._ActiveUnitStatus.RTB_CalledOff:
			case ActiveUnit._ActiveUnitStatus.RTB_CommsLost:
			case ActiveUnit._ActiveUnitStatus.RTB_Exhaustion:
				{
					if (method_12().IsOnActiveMiningMission)
					{
						method_12().AI.MiningInfo = null;
					}
					bool? obj;
					switch (theAO.Condition)
					{
					case Aircraft_AirOps._AirOpsCondition.Airborne:
						theAO.Condition = Aircraft_AirOps._AirOpsCondition.RTB;
						break;
					default:
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						break;
					case Aircraft_AirOps._AirOpsCondition.Landing_PreTouchdown:
					case Aircraft_AirOps._AirOpsCondition.EmergencyLanding:
						if (!method_12().Navigator.AboutToLand(elapsedTime))
						{
							method_12().Navigator.GlideToHomeBase(elapsedTime);
						}
						else
						{
							theAO.ConditionTimer = 0f;
						}
						break;
					case Aircraft_AirOps._AirOpsCondition.RTB:
					{
						if (method_12().ParentScen.MinuteIsChangingOnThisPulse)
						{
							bool MissionPlanner_PostponedRefuelling = false;
							if (theAO.ActualDestinationHost != null)
							{
								if (method_12().FuelState != ActiveUnit._ActiveUnitFuelState.IsBingo && method_12().FuelState != ActiveUnit._ActiveUnitFuelState.IsJoker)
								{
									Aircraft_Navigator navigator2 = method_12().Navigator;
									ActiveUnit.Throttle bingoFuelThrottle = navigator2.GetBingoFuelThrottle();
									bool BingoFuelEndurance = false;
									float bingoFuelAltitude = navigator2.GetBingoFuelAltitude(ref BingoFuelEndurance);
									if ((double)method_12().Kinematics.FuelNecessaryForThisDistance(method_12().RangeToUnit_Horiz(theAO.ActualDestinationHost), bingoFuelThrottle, bingoFuelAltitude, method_12().Kinematics.GetMaximumSpeed(bingoFuelAltitude, bingoFuelThrottle, ValidateAndFixAltitude: false), CombatRadiusCalc: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false) > (double)method_12().FuelCapacityCurrent * 0.9)
									{
										Aircraft_AirOps aircraft_AirOps = theAO;
										BingoFuelEndurance = false;
										ActiveUnit theSelectedTanker = null;
										List<Mission> theSelectedMissions = null;
										string UserFeedback = "";
										bool IsRTB = true;
										if (aircraft_AirOps.AttemptToScheduleRefuel(null, Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround, ref BingoFuelEndurance, IsForced: false, ref theSelectedTanker, ref theSelectedMissions, ref UserFeedback, ref IsRTB, ref MissionPlanner_PostponedRefuelling))
										{
											break;
										}
									}
								}
								else
								{
									Aircraft_AirOps aircraft_AirOps2 = theAO;
									bool IsRTB = false;
									ActiveUnit theSelectedTanker = null;
									List<Mission> theSelectedMissions = null;
									string UserFeedback = "";
									bool BingoFuelEndurance = true;
									if (aircraft_AirOps2.AttemptToScheduleRefuel(null, Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround, ref IsRTB, IsForced: false, ref theSelectedTanker, ref theSelectedMissions, ref UserFeedback, ref BingoFuelEndurance, ref MissionPlanner_PostponedRefuelling))
									{
										break;
									}
								}
							}
						}
						if (method_12().Navigator.HasPlottedCourse() && !((ActiveUnit)method_12()).IsRTB && !method_12().IsDrone())
						{
							method_12().Navigator.FollowPlottedCourse(elapsedTime);
							goto IL_4739;
						}
						int value;
						if (!((ActiveUnit)method_12()).IsRTB)
						{
							value = 0;
						}
						else
						{
							if (myUnit.AssignedMissionOrPackage() != null && myUnit.AssignedMissionOrPackage().HasFlightPlans())
							{
								Mission mission2 = myUnit.AssignedMissionOrPackage();
								obj = ((mission2 == null) ? ((bool?)null) : new bool?(mission2.MissionClass == Mission._MissionClass.Patrol));
								goto IL_45eb;
							}
							value = 0;
						}
						obj = (byte)value != 0;
						goto IL_45eb;
					}
					case Aircraft_AirOps._AirOpsCondition.HoldingOnLandingQueue:
						{
							ReturnToBase(elapsedTime);
							method_12().SetThrottle(ActiveUnit.Throttle.Loiter);
							break;
						}
						IL_4739:
						if (method_12().IsGroupMember() && ((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).Type == Group.GroupType.AirGroup)
						{
							byte? b = (byte?)method_12().Doctrine.WinchesterShotgunRTB;
							if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 3)) == true)
							{
								method_12().DetachUnit(NotifyPlayer: false, ClearPlottedCourse: true, UseFlightplan: false);
							}
						}
						break;
						IL_45eb:
						flag = obj;
						if ((flag ?? true) && !method_12().IsDrone() && flag.HasValue)
						{
							if (!method_12().IsGroupWingman())
							{
								ActiveUnit actualDestinationHost = method_12().AirOps.ActualDestinationHost;
								double num2 = Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), actualDestinationHost.get_Latitude((GlobalVariables.BooleanObject)null), actualDestinationHost.get_Longitude((GlobalVariables.BooleanObject)null));
								if (!method_12().Navigator.HasPlottedCourse() && method_12().Navigator.HasFlightPlan && num2 > 10.0)
								{
									method_12().Navigator.PlottedCourse = ((ActiveUnit_Navigator)method_12().Navigator).get_Flight(HierarchySearch: true).FlightPlan;
								}
								if (!method_12().Navigator.HasPlottedCourse())
								{
									ReturnToBase(elapsedTime);
								}
								else
								{
									method_12().Navigator.EgressToRejoinPoint(elapsedTime, ForceObjectiveWaypointRemoval: false);
									method_12().Navigator.FollowPlottedCourse(elapsedTime);
								}
							}
							else
							{
								method_12().Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
							}
						}
						else
						{
							method_12().Navigator.PlottedCourse.FirstOrDefault();
							ReturnToBase(elapsedTime);
						}
						goto IL_4739;
					}
					break;
				}
				IL_31d6:
				lon = method_12().get_Longitude((GlobalVariables.BooleanObject)null);
				lat = method_12().get_Latitude((GlobalVariables.BooleanObject)null);
				out_lon = (InterruptLocation = geoPoint).Longitude;
				out_lat = (geoPoint2 = geoPoint).Latitude;
				Geodesic_EdWilliams.CalcPoint_Williams(lon, lat, ref out_lon, ref out_lat, 0.5, bearing);
				geoPoint2.Latitude = out_lat;
				InterruptLocation.Longitude = out_lon;
				waypoint.Longitude = geoPoint.Longitude;
				waypoint.Latitude = geoPoint.Latitude;
				waypoint.Type = Waypoint.WaypointType.PatrolStation;
				waypoint.Creator = Waypoint.WaypointCreator.Navigator;
				waypoint.Category = Waypoint.WaypointCategory.PlottedCourse;
				waypoint.Description = "Mining Mission Drop point";
				method_12().Navigator.AddWaypoint(waypoint);
				goto IL_337c;
				IL_0de7:
				PerformTerrainFollowingIfNecessary();
				if (method_12().IsTanker)
				{
					AssistRefuellingClients();
				}
				break;
				IL_337c:
				if (!method_12().Kinematics.DesiredAltitudeOverride && method_12().Navigator.IsInsideMissionArea(ref miningMission2.Area, ref miningMission2.Area_5nm_Buffered, ref miningMission2.Area_5nm_ChangeCheck, 5, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
				{
					float? num3 = AdjustAltitudeForMinelaying();
					if (num3.HasValue)
					{
						method_12().DesiredAltitude = num3.Value;
					}
				}
				break;
				IL_1f6f:
				if (method_12().IsGroupMember())
				{
					if (!method_12().Navigator.HasFlightPlan)
					{
						if (((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).Navigator.Has_NonPathfind_NonFP_PlottedCourse())
						{
							if (method_12().IsGroupLead())
							{
								if (method_12().AI.PrimaryTarget != null)
								{
									_ = (method_12().AI.TargetingBehaviorForThisTarget(method_12().AI.PrimaryTarget, null) == TargetingEntry._TargetingBehavior.ManualTargeted) | (method_12().AI.TargetingBehaviorForThisTarget(method_12().AI.PrimaryTarget, null) == TargetingEntry._TargetingBehavior.ManualWeaponAlloc);
								}
								byte? b = (byte?)method_12().Doctrine.get_IgnorePlottedCourse(method_12().ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false);
								if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
								{
									ManouverTowardsTarget(elapsedTime);
								}
								else
								{
									method_12().Navigator.FollowPlottedCourse(elapsedTime);
								}
							}
							else if (!((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.IsOnAutoPlannerPlottedCourse_FinalTargetRun && !((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.IsOnAutoPlannerPlottedCourse_CruiseAndAttackEgressRun && (list_5 == null || list_5.Count <= 0))
							{
								byte? b = (byte?)method_12().Doctrine.get_IgnorePlottedCourse(method_12().ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false);
								flag = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
								if ((flag ?? true) && (method_12().WeaponState == ActiveUnit._ActiveUnitWeaponState.None || method_12().WeaponState == ActiveUnit._ActiveUnitWeaponState.IsWinchester_EngagingToO || method_12().WeaponState == ActiveUnit._ActiveUnitWeaponState.IsShotgun_EngagingToO) && flag.HasValue)
								{
									ManouverTowardsTarget(elapsedTime);
								}
								else
								{
									method_12().Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
								}
							}
							else
							{
								ManouverTowardsTarget(elapsedTime);
							}
							break;
						}
						if (method_12().IsGroupLead())
						{
							if (!method_12().Navigator.HasFlightPlan)
							{
								if (method_12().Kinematics.DesiredSpeedOverride.HasValue)
								{
									method_12().DesiredSpeed = method_12().Kinematics.DesiredSpeedOverride.Value;
									method_12().SetThrottle(method_12().ThrottleSetting, method_12().DesiredSpeed);
								}
								else
								{
									if (!method_12().IsPerformingStandoffAttack)
									{
										Group obj2 = ((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false);
										if (obj2 == null || !obj2.IsPerformingStandoffAttack)
										{
											method_12().SetThrottle(ActiveUnit.Throttle.Flank);
											goto IL_2511;
										}
									}
									method_12().SetThrottle(ActiveUnit.Throttle.Cruise);
								}
							}
							goto IL_2511;
						}
						if (!((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).Kinematics.DesiredSpeedOverride.HasValue)
						{
							if (!method_12().IsPerformingStandoffAttack)
							{
								Group obj3 = ((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false);
								if (obj3 == null || !obj3.IsPerformingStandoffAttack)
								{
									if (!method_12().Navigator.HasFlightPlan)
									{
										method_12().SetThrottle(ActiveUnit.Throttle.Flank);
									}
									goto IL_24db;
								}
							}
							method_12().SetThrottle(ActiveUnit.Throttle.Cruise);
						}
						else
						{
							method_12().DesiredSpeed = ((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).Kinematics.DesiredSpeedOverride.Value;
							if (method_12().ThrottleSetting != ((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).ThrottleSetting)
							{
								method_12().SetThrottle(((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).ThrottleSetting, method_12().DesiredSpeed);
							}
						}
						goto IL_24db;
					}
					if ((method_12().ActiveMissionOrPackage() == null || method_12().ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Patrol) && !method_12().Weaponry.IsFiringWeaponSalvos() && !method_12().Weaponry.IsGuidingStandoffWeaponOntoThisContact(PrimaryTarget) && !ContinueStandoffAttackAgainstThisTargetToMeetWRA(PrimaryTarget, null) && !method_12().Navigator.HasReachedWeaponReleasePoint(fromUI: false))
					{
						if (myUnit.IsGroupLead())
						{
							method_12().Navigator.FollowPlottedCourse(elapsedTime);
						}
						else
						{
							myUnit.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
						}
					}
					else if (method_12().AI.PrimaryTarget != null && method_12().Status == ActiveUnit._ActiveUnitStatus.EngagedOffensive)
					{
						ManouverTowardsTarget(elapsedTime);
					}
					else if (!myUnit.IsGroupLead())
					{
						myUnit.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
					}
					else
					{
						method_12().Navigator.FollowPlottedCourse(elapsedTime);
					}
				}
				else if (method_12().Navigator.HasFlightPlan)
				{
					if ((method_12().ActiveMissionOrPackage() == null || method_12().ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Patrol) && !method_12().Weaponry.IsFiringWeaponSalvos() && !method_12().Weaponry.IsGuidingStandoffWeaponOntoThisContact(PrimaryTarget) && !ContinueStandoffAttackAgainstThisTargetToMeetWRA(PrimaryTarget, null))
					{
						method_12().Navigator.FollowPlottedCourse(elapsedTime);
					}
					else if (!((method_12().AI.PrimaryTarget != null) & (method_12().Status == ActiveUnit._ActiveUnitStatus.EngagedOffensive)))
					{
						method_12().Navigator.FollowPlottedCourse(elapsedTime);
					}
					else
					{
						ManouverTowardsTarget(elapsedTime);
					}
				}
				else if (method_12().Navigator.Has_NonPathfind_NonFP_PlottedCourse())
				{
					byte? b = (byte?)method_12().Doctrine.get_IgnorePlottedCourse(method_12().ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false);
					if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) != true && (method_12().AssignedMissionOrPackage() == null || method_12().AssignedMissionOrPackage().MissionClass != Mission._MissionClass.Patrol))
					{
						method_12().Navigator.FollowPlottedCourse(elapsedTime);
					}
					else if (method_12().Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.LocalizationRun && method_12().AI.PrimaryTarget != null && method_12().AI.PrimaryTarget.IsSubmergedContact && method_12().AI.PrimaryTarget.UncertaintyArea != null)
					{
						method_12().Navigator.FollowPlottedCourse(elapsedTime);
					}
					else
					{
						ManouverTowardsTarget(elapsedTime);
					}
				}
				else
				{
					if (!method_12().Navigator.HasFlightPlan)
					{
						if (!method_12().Kinematics.DesiredSpeedOverride.HasValue)
						{
							if (method_12().IsPerformingStandoffAttack)
							{
								method_12().SetThrottle(ActiveUnit.Throttle.Cruise);
							}
							else if (method_12().ThrottleSetting == ActiveUnit.Throttle.Loiter)
							{
								method_12().SetThrottle(ActiveUnit.Throttle.Cruise);
							}
						}
						else
						{
							method_12().DesiredSpeed = method_12().Kinematics.DesiredSpeedOverride.Value;
							method_12().SetThrottle(method_12().ThrottleSetting, method_12().DesiredSpeed);
						}
					}
					ManouverTowardsTarget(elapsedTime);
				}
				goto IL_27f1;
				IL_2511:
				ManouverTowardsTarget(elapsedTime);
				goto IL_27f1;
				IL_24db:
				if (((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).Kinematics.DesiredAltitudeOverride)
				{
					method_12().DesiredAltitude = ((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).DesiredAltitude;
				}
				goto IL_2511;
				IL_0cad:
				flag4 = obj6;
				flag5 = obj6;
				flag = ((flag5.HasValue && flag4 != true) ? new bool?(false) : ((PrimaryTarget != null) & flag4));
				if ((flag ?? true) && !method_12().Navigator.HasPlottedCourse() && flag.HasValue)
				{
					method_12().Kinematics.DesiredSpeedOverride = null;
					method_12().DesiredSpeed = 0f;
					theAO.ConditionTimer = 240f;
					theAO.Condition = Aircraft_AirOps._AirOpsCondition.DeployingDippingSonar;
				}
				else if ((!method_12().IsHelicopter || method_12().DesiredSpeed != 0f) && method_12().Type != Aircraft._AircraftType.AeroStat)
				{
					method_12().Kinematics.Loiter(elapsedTime);
				}
				goto IL_0de7;
				IL_27f1:
				PerformTerrainFollowingIfNecessary();
				break;
			}
			return;
		}
		method_12().SetThrottle(ActiveUnit.Throttle.Loiter, 0f);
		float num13 = 100f + Math.Abs(method_12().Attitude_Pitch * 0.01f) + Math.Abs(method_12().Attitude_Roll * 0.01f);
		if (method_12().Proficiency.HasValue)
		{
			switch (method_12().Proficiency.Value)
			{
			case GlobalVariables.ProficiencyLevel.Cadet:
				num13 *= 0.75f;
				break;
			case GlobalVariables.ProficiencyLevel.Regular:
				num13 *= 0.65f;
				break;
			case GlobalVariables.ProficiencyLevel.Veteran:
				num13 *= 0.55f;
				break;
			case GlobalVariables.ProficiencyLevel.Ace:
				num13 *= 0.45f;
				break;
			}
		}
		if (num13 > 1f)
		{
			if (new LockRandom((int)Math.Round(method_12().Span * 1000f)).Next(100) > 50)
			{
				method_12().DesiredAltitude = method_12().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - 100f;
				((ActiveUnit)method_12()).set_DesiredHeading(ActiveUnit.TurnRate.Max, Math2.NormalizeBearing(method_12().CurrentHeading + 10f));
			}
			else
			{
				method_12().DesiredAltitude = method_12().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + 100f;
				((ActiveUnit)method_12()).set_DesiredHeading(ActiveUnit.TurnRate.Max, Math2.NormalizeBearing(method_12().CurrentHeading - 10f));
			}
		}
		else
		{
			((ActiveUnit)method_12()).set_DesiredHeading(ActiveUnit.TurnRate.Max, method_12().CurrentHeading);
			method_12().DesiredAltitude = method_12().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			method_12().DesiredAltitude_AGL = method_12().CurrentAltitude_AGL;
		}
	}

	public bool FollowingRTB_PlottedCourse()
	{
		if (!myUnit.FollowingPCThatIsRTB)
		{
			return method_12().FollowingPCThatIsPathfinderGeneratedAndLeadsToAssignedHost;
		}
		return true;
	}

	public bool AlreadyRTBAndNearlyBackToBase()
	{
		if (myUnit.Status == ActiveUnit._ActiveUnitStatus.OnPlottedCourse && myUnit.Navigator.HasFlightPlan)
		{
			Waypoint waypoint = null;
			if (myUnit.IsGroupWingman() && myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.HasPlottedCourse() && myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlottedCourse.Count() > 0)
			{
				waypoint = myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlottedCourse[0];
			}
			else if (myUnit.Navigator.HasPlottedCourse() && myUnit.Navigator.PlottedCourse.Count() > 0)
			{
				waypoint = myUnit.Navigator.PlottedCourse[0];
			}
			if (waypoint != null)
			{
				return waypoint.Type == Waypoint.WaypointType.LandingMarshal || waypoint.Type == Waypoint.WaypointType.Land;
			}
			goto IL_0192;
		}
		int result;
		if (!myUnit.IsRTB)
		{
			result = 0;
		}
		else
		{
			if (method_12().AirOps.ActualDestinationHost != null)
			{
				float num = myUnit.RangeToUnit_Horiz(method_12().AirOps.ActualDestinationHost);
				if (num <= Aircraft.EMERGENCY_LANDING_DISTANCE_NM)
				{
					return true;
				}
				if ((double)myUnit.Kinematics.FuelNecessaryForThisDistance(num, myUnit.ThrottleSetting, myUnit.DesiredAltitude, myUnit.DesiredSpeed, CombatRadiusCalc: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false) < (double)myUnit.FuelCapacityCurrent * 0.9)
				{
					return true;
				}
				goto IL_0192;
			}
			result = 0;
		}
		goto IL_0193;
		IL_0193:
		return (byte)result != 0;
		IL_0192:
		result = 0;
		goto IL_0193;
	}

	public void PerformScheduledRefuel(float elapsedTime)
	{
		Aircraft_AirOps airOps = method_12().AirOps;
		if (airOps.A2AR_Destination != null)
		{
			Aircraft a2AR_Destination = airOps.A2AR_Destination;
			float num = method_12().RangeToUnit_Horiz(a2AR_Destination);
			if (((ActiveUnit_CommStuff)a2AR_Destination.CommStuff).IsConnectedToSideNetwork)
			{
				myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, Module_Unit.BearingToUnit_True(myUnit, a2AR_Destination));
			}
			else
			{
				myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, Module_Unit.BearingToPoint_True(myUnit, a2AR_Destination.Latitude_LastReported.Value, a2AR_Destination.Longitude_LastReported.Value));
			}
			string key = a2AR_Destination.AirOps.RefuellingQueue.FirstOrDefault().Key;
			bool flag = string.CompareOrdinal(key, myUnit.ObjectID) == 0;
			bool flag2 = a2AR_Destination.AirOps.A2AR_Connections.ContainsKey(myUnit.ObjectID);
			if (!flag && myUnit.IsGroupMember())
			{
				foreach (KeyValuePair<string, ActiveUnit> unit in myUnit.get_ParentGroup(UsingMissionPlanner: false).Units)
				{
					if (Operators.CompareString(unit.Key, key, false) != 0)
					{
						if (a2AR_Destination.AirOps.A2AR_Connections.ContainsKey(unit.Key))
						{
							flag2 = true;
							break;
						}
						continue;
					}
					flag = true;
					break;
				}
			}
			double num2 = 0.5;
			if (flag2 || (flag && a2AR_Destination.AirOps.get_HasAvailableRefuelSlotForThisAircraft(method_12(), WingmenHookingUpWithGroupleadTanker: true)))
			{
				num2 = 0.1;
			}
			if ((double)num < num2)
			{
				method_12().DesiredSpeed = a2AR_Destination.CurrentSpeed;
				method_12().DesiredAltitude = a2AR_Destination.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
				method_12().SetThrottle(method_12().Kinematics.GetThrottleSuitableForThisSpeed(a2AR_Destination.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (int)Math.Round(method_12().DesiredSpeed)));
			}
			else
			{
				int maximumSpeed = method_12().Kinematics.GetMaximumSpeed(method_12().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Cruise, ValidateAndFixAltitude: false);
				float num3 = ((num < 1f) ? 1.1f : 1.2f);
				if ((float)maximumSpeed / a2AR_Destination.CurrentSpeed > num3)
				{
					method_12().DesiredSpeed = maximumSpeed;
					method_12().SetThrottle(ActiveUnit.Throttle.Cruise);
				}
				else
				{
					method_12().DesiredSpeed = a2AR_Destination.CurrentSpeed * num3;
					method_12().SetThrottle(method_12().Kinematics.GetThrottleSuitableForThisSpeed(a2AR_Destination.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (int)Math.Round(method_12().DesiredSpeed)));
				}
				if (num > 10f)
				{
					if (method_12().Navigator.PathfindingPlottedCourseLeadsToA2ARDestination)
					{
						method_12().Navigator.FollowPlottedCourse(elapsedTime);
					}
					if (!myUnit.Kinematics.DesiredAltitudeOverride)
					{
						if (!method_12().get_DesiredAltitude_UseTerrainFollowing((ActiveUnit)method_12()))
						{
							Aircraft aircraft = method_12();
							Aircraft_Navigator navigator = method_12().Navigator;
							bool theAltitude_TerrainFollowing = false;
							aircraft.DesiredAltitude = navigator.GetBingoFuelAltitude(ref theAltitude_TerrainFollowing);
						}
						else
						{
							Aircraft aircraft2 = method_12();
							Aircraft_Navigator navigator2 = method_12().Navigator;
							bool theAltitude_TerrainFollowing = false;
							aircraft2.DesiredAltitude_AGL = navigator2.GetBingoFuelAltitude(ref theAltitude_TerrainFollowing);
						}
					}
				}
				else
				{
					method_12().DesiredAltitude = a2AR_Destination.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
					method_12().set_DesiredAltitude_UseTerrainFollowing((ActiveUnit)method_12(), value: false);
				}
			}
		}
		else
		{
			if (method_12().Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint || method_12().Status == ActiveUnit._ActiveUnitStatus.Refuelling)
			{
				if (!GlobalVariables.AI_REWORK)
				{
					method_12().Status = method_12()._StatusBefore_NeedToRefuel;
				}
				else
				{
					method_12().AI.StatusRelatedEvents.RestorePreRefuelStatus = method_12()._StatusBefore_NeedToRefuel;
				}
			}
			if (airOps.Condition == Aircraft_AirOps._AirOpsCondition.ManoeuveringToRefuel || airOps.Condition == Aircraft_AirOps._AirOpsCondition.Refuelling)
			{
				airOps.Condition = Aircraft_AirOps._AirOpsCondition.Airborne;
			}
		}
		SetMissionStateFlag(1u, theValue: true);
	}

	public bool CheckSeparationAndRejoin(float elapsedTime)
	{
		int result;
		if (method_12() != null)
		{
			if (((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false) != null)
			{
				if (method_12().IsGroupLead())
				{
					return false;
				}
				if (method_12().Navigator.PlottedCourse.Count() != ((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.PlottedCourse.Count())
				{
					return false;
				}
				if (myUnit.Status != ActiveUnit._ActiveUnitStatus.EngagedDefensive && myUnit.Status != ActiveUnit._ActiveUnitStatus.EngagedOffensive && myUnit.Status != ActiveUnit._ActiveUnitStatus.RTB_Exhaustion)
				{
					if (myUnit.IsRTB_Or_CalledOff)
					{
						if (method_12().FuelState == ActiveUnit._ActiveUnitFuelState.IsBingo)
						{
							goto IL_01e6;
						}
						if (method_12().FuelState == ActiveUnit._ActiveUnitFuelState.IsJoker)
						{
							result = 0;
							goto IL_01e7;
						}
					}
					if (myUnit.ActiveMissionOrPackage() != null && myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
					{
						if (IsEscort)
						{
							try
							{
								if (((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false) != null && method_12().IsGroupWingman())
								{
									return method_35(elapsedTime);
								}
								HeadToNearestEscortSubject();
							}
							catch (Exception ex)
							{
								ProjectData.SetProjectError(ex);
								Exception ex2 = ex;
								ex2?.Data.Add("Error at 100398657547", "");
								GameGeneral.WriteExceptionsToLog(ex2);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
							}
						}
						else
						{
							try
							{
								if (method_12().IsGroupWingman() && ((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false) != null)
								{
									return method_35(elapsedTime);
								}
							}
							catch (Exception ex3)
							{
								ProjectData.SetProjectError(ex3);
								Exception ex4 = ex3;
								ex4?.Data.Add("Error at 1003986575472", "");
								GameGeneral.WriteExceptionsToLog(ex4);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
							}
						}
						return false;
					}
					return method_35(elapsedTime);
				}
				goto IL_01e6;
			}
			return false;
		}
		return false;
		IL_01e6:
		result = 0;
		goto IL_01e7;
		IL_01e7:
		return (byte)result != 0;
	}

	private bool method_35(float float_0)
	{
		Group obj = ((ActiveUnit)method_12()).get_ParentGroup(UsingMissionPlanner: false);
		if (obj != null)
		{
			float num = Math2.CalcDist(method_12().get_Latitude((GlobalVariables.BooleanObject)null), method_12().get_Longitude((GlobalVariables.BooleanObject)null), obj.GroupLead.get_Latitude((GlobalVariables.BooleanObject)null), obj.GroupLead.get_Longitude((GlobalVariables.BooleanObject)null));
			float relativeBearing = MathFunctions.GetRelativeBearing(myUnit.CurrentHeading, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), obj.GroupLead.get_Latitude((GlobalVariables.BooleanObject)null), obj.GroupLead.get_Longitude((GlobalVariables.BooleanObject)null)));
			Waypoint waypoint = method_12().Navigator.PlottedCourse.FirstOrDefault();
			Waypoint waypoint2 = obj.GroupLead.Navigator.PlottedCourse.FirstOrDefault();
			int? num2 = (int?)waypoint?.Type;
			int? num3 = (int?)waypoint2?.Type;
			if (((!(num2.HasValue & num3.HasValue)) ? ((bool?)null) : new bool?(num2.GetValueOrDefault() != num3.GetValueOrDefault())) == true)
			{
				method_12().Navigator.FollowPlottedCourse(float_0);
				method_12().Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
			}
			float num4 = 4f;
			if (myUnit.ActiveMissionOrPackage() != null && myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
			{
				num4 = ((Strike)myUnit.ActiveMissionOrPackage()).Escort_WingmanEngageDistance;
			}
			if (num > num4 || (relativeBearing > 90f && relativeBearing < 270f))
			{
				method_12().Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(float_0);
				return true;
			}
			return false;
		}
		return false;
	}

	private bool method_36(float float_0, ref bool bool_0)
	{
		bool result;
		try
		{
			List<Aircraft> list = new List<Aircraft>();
			ActiveUnit[] array;
			try
			{
				array = myUnit.get_UnitSide(SetSideOnly: false).Units.ToArray();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				array = myUnit.get_UnitSide(SetSideOnly: false).Units.ToArray();
				ProjectData.ClearProjectError();
			}
			List<Aircraft> list2 = new List<Aircraft>();
			ActiveUnit[] array2 = array;
			int num = default(int);
			float num2 = default(float);
			int num3 = default(int);
			float num4 = default(float);
			foreach (ActiveUnit activeUnit in array2)
			{
				if (activeUnit != null && activeUnit.IsAircraft && activeUnit.IsOperating() && activeUnit != method_12() && activeUnit.ActiveMissionOrPackage() == method_12().ActiveMissionOrPackage() && !activeUnit.AI.IsEscort)
				{
					Aircraft aircraft = (Aircraft)activeUnit;
					list.Add(aircraft);
					num += (int)Math.Round(aircraft.CurrentSpeed);
					num2 += aircraft.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
					if (aircraft.AirOps.get_AssignedHostUnit(PickNewAssignedHost: false) == method_12().AirOps.get_AssignedHostUnit(PickNewAssignedHost: false))
					{
						list2.Add(aircraft);
						num3 += (int)Math.Round(aircraft.CurrentSpeed);
						num4 += aircraft.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
					}
				}
			}
			if (list2.Count > 0)
			{
				list = list2;
				num = num3;
				num2 = num4;
			}
			if (list.Count == 0)
			{
				result = false;
			}
			else
			{
				GeoPoint geoPoint = new GeoPoint();
				int count = list.Count;
				if (count == 1)
				{
					geoPoint.Longitude = list[0].get_Longitude((GlobalVariables.BooleanObject)null);
					geoPoint.Latitude = list[0].get_Latitude((GlobalVariables.BooleanObject)null);
				}
				else
				{
					geoPoint.Longitude = list.Select([SpecialName] (Aircraft theAU) => theAU.get_Longitude((GlobalVariables.BooleanObject)null)).Sum() / (double)list.Count;
					geoPoint.Latitude = list.Select([SpecialName] (Aircraft theAU) => theAU.get_Latitude((GlobalVariables.BooleanObject)null)).Sum() / (double)list.Count;
				}
				if (!method_12().Navigator.HeadToDesiredPoint_AccountForPathfinderIfInGroup(float_0, geoPoint.Latitude, geoPoint.Longitude))
				{
					((ActiveUnit)method_12()).set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.CalcAzimuth(method_12().get_Latitude((GlobalVariables.BooleanObject)null), method_12().get_Longitude((GlobalVariables.BooleanObject)null), geoPoint.Latitude, geoPoint.Longitude));
				}
				if (myUnit.Navigator.HasPathfindingPlottedCourse)
				{
					myUnit.Navigator.FollowPlottedCourse(float_0);
				}
				int num5;
				if (bool_0)
				{
					num5 = 1;
				}
				else
				{
					if (!method_12().Kinematics.DesiredSpeedOverride.HasValue)
					{
						float num6 = (float)((double)num / (double)list.Count);
						method_12().SetThrottle(method_12().Kinematics.GetThrottleSuitableForThisSpeed(method_12().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (int)Math.Round(num6)));
						method_12().DesiredSpeed = num6;
					}
					if (!myUnit.Kinematics.DesiredAltitudeOverride)
					{
						float num7 = 0f;
						float num8 = 9999999f;
						foreach (Mount mount in myUnit.Mounts)
						{
							if (mount.Status != PlatformComponent._ComponentStatus.Operational)
							{
								continue;
							}
							foreach (WeaponRec mountWeapon in mount.MountWeapons)
							{
								WeaponRec current2;
								Weapon weapon = (current2 = mountWeapon).get_ReferenceWeapon(myUnit.ParentScen);
								if (weapon.IsSoftKill || weapon.IsFuelTank || weapon.IsSensorPod || current2.CurrentLoad == 0)
								{
									continue;
								}
								if (weapon.IsNuke.Value)
								{
									byte? b = (byte?)myUnit.Doctrine.get_NukesAllowed(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
									bool? flag = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
									if (((!flag) ?? flag) == true)
									{
										continue;
									}
								}
								if (weapon.MinLaunchAlt_AGL != 0f && weapon.MinLaunchAlt_AGL > num7)
								{
									num7 = weapon.MinLaunchAlt_AGL;
								}
								if (weapon.MaxLaunchAlt_AGL != 0f && weapon.MaxLaunchAlt_AGL < num8)
								{
									num8 = weapon.MaxLaunchAlt_AGL;
								}
								current2 = null;
							}
						}
						if (myUnit.IsAircraft && !Information.IsNothing((object)((Aircraft)myUnit).Loadout))
						{
							WeaponRec[] weapons = ((Aircraft)myUnit).Loadout.Weapons;
							for (int num9 = 0; num9 < weapons.Length; num9 = checked(num9 + 1))
							{
								WeaponRec weaponRec;
								Weapon weapon2 = (weaponRec = weapons[num9]).get_ReferenceWeapon(myUnit.ParentScen);
								if (weapon2.IsSoftKill || weapon2.IsFuelTank || weapon2.IsSensorPod || weaponRec.CurrentLoad == 0)
								{
									continue;
								}
								if (weapon2.IsNuke.Value)
								{
									byte? b = (byte?)myUnit.Doctrine.get_NukesAllowed(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
									bool? flag = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
									if (((!flag) ?? flag) == true)
									{
										continue;
									}
								}
								if (weapon2.MinLaunchAlt_AGL != 0f && weapon2.MinLaunchAlt_AGL > num7)
								{
									num7 = weapon2.MinLaunchAlt_AGL;
								}
								if (weapon2.MaxLaunchAlt_AGL != 0f && weapon2.MaxLaunchAlt_AGL < num8)
								{
									num8 = weapon2.MaxLaunchAlt_AGL;
								}
								weaponRec = null;
							}
						}
						float num10 = num2 / (float)list.Count;
						if (num7 > num8)
						{
							if (num10 < num7)
							{
								num10 = num7;
								float num11 = Math.Max(0, ((Module_Unit.Unit)myUnit).get_LandElevation(AGL: true, RequestIsFromGUI: false, Force: false, myUnit.ParentScen));
								if (num11 > 0f)
								{
									num10 += num11;
								}
							}
						}
						else
						{
							if (num10 < num7)
							{
								num10 = num7;
								float num12 = Math.Max(0, ((Module_Unit.Unit)myUnit).get_LandElevation(AGL: true, RequestIsFromGUI: false, Force: false, myUnit.ParentScen));
								if (num12 > 0f)
								{
									num10 += num12;
								}
							}
							if (num10 < num7)
							{
								num10 = num7;
							}
						}
						myUnit.DesiredAltitude = num10;
						num5 = 1;
					}
					else
					{
						num5 = 1;
					}
				}
				result = (byte)num5 != 0;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 10023409582340958", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num13;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num13 = 1;
			}
			else
			{
				num13 = 1;
			}
			result = (byte)num13 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void SpeedAdjustmentForToT(float elapsedTime, double TimeCorrectionNeeded = 0.0)
	{
		if (myUnit.IsGroupWingman())
		{
			return;
		}
		Waypoint[] plottedCourse = method_12().Navigator.PlottedCourse;
		try
		{
			if (myUnit.Kinematics.DesiredSpeedOverride.HasValue && myUnit.Navigator.HasFlight)
			{
				Waypoint[] flightPlan = myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan;
				Waypoint waypoint2 = default(Waypoint);
				foreach (Waypoint waypoint in flightPlan)
				{
					if (Operators.CompareString(waypoint.Name, plottedCourse.FirstOrDefault()?.Name, false) == 0 && waypoint2 != null)
					{
						float? desiredSpeedOverride = waypoint2.DesiredSpeedOverride;
						float? desiredSpeedOverride2 = myUnit.Kinematics.DesiredSpeedOverride;
						bool? flag = ((!(desiredSpeedOverride.HasValue & desiredSpeedOverride2.HasValue)) ? ((bool?)null) : new bool?(desiredSpeedOverride.GetValueOrDefault() == desiredSpeedOverride2.GetValueOrDefault()));
						if (((!flag) ?? flag) == true)
						{
							return;
						}
					}
					waypoint2 = waypoint;
				}
			}
			if (method_12().Navigator.Has_NonPathfind_NonFP_PlottedCourse())
			{
				Waypoint obj = plottedCourse[0];
				if (obj == null || !obj.Time_Zulu.HasValue)
				{
					float? desiredSpeedOverride2 = TimeToNextSpeedAdjustmentForToTEvaluation;
					if (((!desiredSpeedOverride2.HasValue) ? ((bool?)null) : new bool?(desiredSpeedOverride2.GetValueOrDefault() > 0f)) == true)
					{
						SpeedAdjustmentToT_OriginalSpeed = null;
						SpeedAdjustmentToT_OriginalSpeedOverride = null;
						SpeedAdjustmentToT_OriginalThrottle = null;
						SpeedAdjustmentToT_OriginalThrottlePreset = null;
					}
					return;
				}
			}
			if (!Information.IsNothing((object)TimeToNextSpeedAdjustmentForToTEvaluation))
			{
				TimeToNextSpeedAdjustmentForToTEvaluation -= elapsedTime;
				float? desiredSpeedOverride2 = TimeToNextSpeedAdjustmentForToTEvaluation;
				if (((!desiredSpeedOverride2.HasValue) ? ((bool?)null) : new bool?(desiredSpeedOverride2.GetValueOrDefault() < 0f)) == true || myUnit.IsRTB_Or_CalledOff || myUnit.FuelState == ActiveUnit._ActiveUnitFuelState.IsBingo)
				{
					TimeToNextSpeedAdjustmentForToTEvaluation = null;
					if (IsPerformingSpeedAdjustmentToT)
					{
						if (method_12().Navigator.HasFlightPlan)
						{
							ResetOriginalSpeed();
						}
						SpeedAdjustmentToT_OriginalSpeed = null;
						SpeedAdjustmentToT_OriginalSpeedOverride = null;
						SpeedAdjustmentToT_OriginalThrottle = null;
						SpeedAdjustmentToT_OriginalThrottlePreset = null;
						IsPerformingSpeedAdjustmentToT = false;
					}
				}
			}
			if (!Information.IsNothing((object)TimeToNextSpeedAdjustmentForToTEvaluation))
			{
				return;
			}
			if (method_12().CurrentSpeed > 0f && method_12().Navigator.HasFlightPlan && !method_12().Navigator.Has_NonPathfind_NonFP_PlottedCourse() && plottedCourse != null && plottedCourse.Count() > 0 && plottedCourse[0].Time_Zulu.HasValue)
			{
				Waypoint waypoint3 = plottedCourse[0];
				if (waypoint3.TimeFixed == Waypoint.FixedFree.Fixed || (waypoint3.TimeFixed == Waypoint.FixedFree.Bound && myUnit.Navigator.get_Flight(HierarchySearch: true).ObjectiveWaypointFixedTime == Waypoint.FixedFree.Fixed))
				{
					float newBearing = Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), waypoint3.Latitude, waypoint3.Longitude);
					if (Math.Abs(MathFunctions.AngularDifference(myUnit.CurrentHeading, newBearing)) < 5f)
					{
						float desiredSpeed = myUnit.DesiredSpeed;
						float num = Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), waypoint3.Latitude, waypoint3.Longitude);
						float num2 = num / desiredSpeed * 3600f;
						DateTime? time_Zulu = waypoint3.Time_Zulu;
						DateTime? dateTime = myUnit.ParentScen.Time.AddSeconds(num2);
						double totalSeconds = (time_Zulu.Value - dateTime.Value).TotalSeconds;
						float float_ = (float)((double)num / ((time_Zulu.Value - myUnit.ParentScen.Time).TotalSeconds / 3600.0));
						PerformTimeAdjustment(waypoint3, totalSeconds, float_, 5.0);
					}
					else
					{
						TimeToNextSpeedAdjustmentForToTEvaluation = 15f;
					}
					return;
				}
			}
			TimeToNextSpeedAdjustmentForToTEvaluation = 60f;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999994524549", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ResetOriginalSpeed()
	{
		if (SpeedAdjustmentToT_OriginalSpeed.HasValue)
		{
			myUnit.DesiredSpeed = SpeedAdjustmentToT_OriginalSpeed.Value;
		}
		if (SpeedAdjustmentToT_OriginalSpeedOverride.HasValue)
		{
			myUnit.Kinematics.DesiredSpeedOverride = SpeedAdjustmentToT_OriginalSpeedOverride;
		}
		if (SpeedAdjustmentToT_OriginalThrottle.HasValue)
		{
			myUnit.SetThrottle(SpeedAdjustmentToT_OriginalThrottle.Value);
		}
		if (SpeedAdjustmentToT_OriginalThrottlePreset.HasValue)
		{
			myUnit.Kinematics.ThrottlePreset = SpeedAdjustmentToT_OriginalThrottlePreset.Value;
		}
	}

	public void PerformTimeAdjustment(Waypoint theWP, double Diff_Time, float float_0, double Diff_Time_threashold)
	{
		if (Math.Abs(Diff_Time) > Diff_Time_threashold)
		{
			if (Diff_Time < 0.0 && LeadMustSlowDownDueToBingo)
			{
				TimeToNextSpeedAdjustmentForToTEvaluation = 60f;
				return;
			}
			if (Diff_Time < 0.0 && theWP.SpeedAdjustmentToT == Waypoint.SpeedToT.Yes_DownOnly)
			{
				TimeToNextSpeedAdjustmentForToTEvaluation = 60f;
				return;
			}
			bool flag = false;
			if (float_0 > (float)myUnit.Kinematics.GetMaximumSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)))
			{
				flag = true;
			}
			else if (float_0 < (float)myUnit.Kinematics.GetMinimumSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Loiter, ValidateAndFixAltitude: false))
			{
				flag = true;
			}
			if (flag)
			{
				TimeToNextSpeedAdjustmentForToTEvaluation = 30f;
				return;
			}
			float num = float_0 - myUnit.DesiredSpeed;
			float value = (float)((double)myUnit.DesiredSpeed * Diff_Time / 3600.0) / num * 3600f;
			SpeedAdjustmentToT_OriginalSpeed = myUnit.DesiredSpeed;
			SpeedAdjustmentToT_OriginalSpeedOverride = myUnit.Kinematics.DesiredSpeedOverride;
			SpeedAdjustmentToT_OriginalThrottle = myUnit.ThrottleSetting;
			SpeedAdjustmentToT_OriginalThrottlePreset = myUnit.Kinematics.ThrottlePreset;
			myUnit.Kinematics.DesiredSpeedOverride = null;
			myUnit.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
			ActiveUnit.Throttle throttleSuitableForThisSpeed = myUnit.Kinematics.GetThrottleSuitableForThisSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), float_0);
			myUnit.SetThrottle(throttleSuitableForThisSpeed, float_0);
			IsPerformingSpeedAdjustmentToT = true;
			if (Math.Abs(value) <= 75f)
			{
				TimeToNextSpeedAdjustmentForToTEvaluation = Math.Max(Math.Abs(value) - 5f, 5f);
			}
			else
			{
				TimeToNextSpeedAdjustmentForToTEvaluation = 60f;
			}
		}
		else
		{
			TimeToNextSpeedAdjustmentForToTEvaluation = 30f;
		}
	}

	public static float MostRealisticOptimumAltitude(ref Aircraft theAircraft, ActiveUnit.Throttle theThrottle, ref bool Return_theAltitude_TerrainFollowing)
	{
		float result;
		try
		{
			float maximumAltitude = theAircraft.Kinematics.GetMaximumAltitude();
			Return_theAltitude_TerrainFollowing = false;
			result = ((theAircraft.Propulsion[0].AltBands.Length >= 4) ? ((maximumAltitude * 3.28084f > 60001f) ? ((!Information.IsNothing((object)theThrottle)) ? theAircraft.Propulsion[0].get_OptimumAltBandForThisThrottle(theThrottle).MaxAlt : maximumAltitude) : ((!Information.IsNothing((object)theThrottle)) ? theAircraft.Propulsion[0].get_OptimumAltBandForThisThrottle(theThrottle).MinAlt : 10972.8f)) : ((theAircraft.Propulsion[0].AltBands.Length != 1 && !theAircraft.IsHelicopter) ? (Information.IsNothing((object)theThrottle) ? maximumAltitude : theAircraft.Propulsion[0].get_OptimumAltBandForThisThrottle(theThrottle).MaxAlt) : ((!(maximumAltitude >= 609.60004f)) ? maximumAltitude : 609.60004f)));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101362", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = 0f;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal float MostRealisticAttackAltitude(ref Aircraft theAircraft, ActiveUnit.Throttle theThrottle, bool LoadoutAltitudesOnly, ref bool MissionProfileAttackIngressAltitudeTerrainFollowing)
	{
		if (!theAircraft.Kinematics.DesiredAltitudeOverride)
		{
			Weapon weapon = default(Weapon);
			if (PrimaryTarget != null)
			{
				weapon = myUnit.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, CheckIfWithinRange: false, CheckIfWithinAltitude: false, CheckWRA: true, myUnit.Doctrine);
				if (weapon != null && weapon.IsWeaponPallet)
				{
					weapon.InitializeWeaponWeaponsPallet();
					weapon = weapon.WeaponWeapons[0].get_ReferenceWeapon(myUnit.ParentScen);
				}
			}
			if (weapon == null)
			{
				return theAircraft.DesiredAltitude;
			}
			if (PrimaryTarget != null && !PrimaryTarget.IsBallisticTarget() && myUnit.ParentScen.FeatureCompatibility.get_WeaponSnapUpDown(myUnit.ParentScen.DBConnection))
			{
				try
				{
					if (weapon.SnapUpDown > 0f && PrimaryTarget.IsAir_Missile_Orbital_Contact && Module_Unit.CurrentSpeed_Vertical(PrimaryTarget, myUnit.ParentScen) == 0f)
					{
						float result = method_12().DesiredAltitude;
						if (Math.Abs(((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) > weapon.SnapUpDown)
						{
							result = ((!(((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > method_12().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))) ? (((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + weapon.SnapUpDown) : (((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - weapon.SnapUpDown));
						}
						return result;
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 987654321000010", "");
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			if (myUnit.ActiveMissionOrPackage() != null && ((myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Patrol) & (myUnit.Status != ActiveUnit._ActiveUnitStatus.EngagedOffensive)))
			{
				Patrol patrol = (Patrol)myUnit.ActiveMissionOrPackage();
				if (patrol.AttackAltitude_Aircraft.HasValue)
				{
					return patrol.AttackAltitude_Aircraft.Value;
				}
			}
			float num = weapon.MaxLaunchAlt_ASL;
			float num2 = weapon.MinLaunchAlt_ASL;
			if (weapon.MaxLaunchAlt_AGL != 0f || weapon.MinLaunchAlt_AGL != 0f)
			{
				short elevation = Terrain.GetElevation(theAircraft.get_Latitude((GlobalVariables.BooleanObject)null), theAircraft.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, theAircraft.ParentScen);
				if (weapon.MaxLaunchAlt_AGL != 0f)
				{
					num = weapon.MaxLaunchAlt_AGL + (float)elevation - 10f;
				}
				if (weapon.MinLaunchAlt_AGL != 0f)
				{
					num2 = weapon.MinLaunchAlt_AGL + (float)elevation + 10f;
				}
			}
			if (num > 0f && num < theAircraft.DesiredAltitude)
			{
				return num;
			}
			if (num2 > 0f && num2 > theAircraft.DesiredAltitude)
			{
				return num2;
			}
			float val = num2;
			if (weapon.Guidance == Weapon.WeaponGuidanceType.Inertial)
			{
				val = Math.Max(num2, 100f);
			}
			if (!((num == 0f && num2 == 0f) & (weapon.Type == Weapon._WeaponType.Gun)))
			{
				return Math.Max(val, theAircraft.DesiredAltitude);
			}
			return ((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
		}
		return theAircraft.DesiredAltitude;
	}

	internal bool IsOnSonobuoyRun()
	{
		bool result;
		try
		{
			int value;
			bool flag;
			bool flag2;
			int num;
			if (myUnit == null)
			{
				result = false;
			}
			else if (myUnit.IsUsingDippingSonar())
			{
				result = false;
			}
			else if (!((ActiveUnit)method_12()).IsRTB)
			{
				value = myUnit.Doctrine.GetElementState(Doctrine.DoctrineItem_E.SonobuoyUse).Value;
				if (value == 2)
				{
					result = false;
				}
				else
				{
					flag = false;
					flag2 = false;
					List<Weapon> list = method_12().Weaponry.AllDistinctWeaponsAboard_Actual();
					foreach (Weapon item2 in list)
					{
						if (item2.Type == Weapon._WeaponType.Sonobuoy && method_12().Weaponry.TotalAvailableInventoryForThisWeapon(item2.DBID, IncludeNonOperationalMountsAndMags: false) > 0)
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						if (Information.IsNothing((object)PrimaryTarget))
						{
							num = 0;
							goto IL_00f9;
						}
						if (PrimaryTarget.IsSubmergedContact)
						{
							num = 0;
							goto IL_00f9;
						}
						result = false;
					}
					else
					{
						result = false;
					}
				}
			}
			else
			{
				result = false;
			}
			goto end_IL_0001;
			IL_00f9:
			bool flag3 = (byte)num != 0;
			CommDevice[] comms_ReadOnly = myUnit.Comms_ReadOnly;
			foreach (CommDevice commDevice in comms_ReadOnly)
			{
				if (commDevice.IsSonobuoyLink && commDevice.OccupiedChannels < commDevice.MaxChannels)
				{
					flag3 = true;
					break;
				}
			}
			if (!flag3)
			{
				int num2;
				if (myUnit.get_UnitSide(SetSideOnly: false) != null && myUnit.get_UnitSide(SetSideOnly: false).IsHumanControlled)
				{
					Notification_Bark.Create_UnitBehaviour(myUnit, "Cannot drop anymore sonobuoys, no channel available");
					num2 = 0;
				}
				else
				{
					num2 = 0;
				}
				result = (byte)num2 != 0;
			}
			else
			{
				if (flag)
				{
					bool item = Terrain.PointIsOverland(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null)).IsOverland;
					if ((float)((Module_Unit.Unit)myUnit).get_LandElevation(item, RequestIsFromGUI: false, Force: false, myUnit.ParentScen) > -20f)
					{
						flag2 = false;
					}
					else if (SeaIceProvider.PointIsUnderIce(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)))
					{
						flag2 = false;
					}
					else
					{
						Contact primaryTarget = PrimaryTarget;
						if (!Information.IsNothing((object)primaryTarget))
						{
							if (Information.IsNothing((object)primaryTarget.UncertaintyArea))
							{
								if (!primaryTarget.IsPreciselyLocatedOnThisPulse && method_12().RangeToUnit_Horiz(primaryTarget) < 2f)
								{
									flag2 = true;
								}
							}
							else
							{
								ActiveUnit_Navigator navigator = myUnit.Navigator;
								Contact contact;
								List<Geopoint_Struct> theArea = (contact = primaryTarget).UncertaintyArea;
								bool num3 = navigator.IsInsideUncertaintryArea(ref theArea, 1f);
								contact.UncertaintyArea = theArea;
								if (num3)
								{
									flag2 = true;
								}
							}
						}
						if (!flag2)
						{
							Mission mission = method_12().ActiveMissionOrPackage();
							if (!Information.IsNothing((object)mission))
							{
								Mission._MissionClass missionClass = mission.MissionClass;
								if (missionClass == Mission._MissionClass.Patrol)
								{
									Patrol patrol = (Patrol)mission;
									GlobalVariables.PatrolType type = patrol.Type;
									if (type != GlobalVariables.PatrolType.ASW && type != GlobalVariables.PatrolType.SeaControl)
									{
										flag2 = false;
									}
									else if (!Information.IsNothing((object)patrol.PatrolArea))
									{
										if (!Information.IsNothing((object)primaryTarget))
										{
											if (!Information.IsNothing((object)primaryTarget.UncertaintyArea))
											{
												ActiveUnit_Navigator navigator2 = myUnit.Navigator;
												Contact contact;
												List<Geopoint_Struct> theArea = (contact = primaryTarget).UncertaintyArea;
												bool num4 = navigator2.IsInsideUncertaintryArea(ref theArea, 5f);
												contact.UncertaintyArea = theArea;
												if (num4)
												{
													flag2 = true;
												}
											}
										}
										else if (value == 0)
										{
											if (patrol.MovementStyle != Patrol.PatrolMovementStyle.RepeatableLoop && patrol.PatrolArea.Count >= 3)
											{
												if (method_12().AI.IsInsidePatrolArea_NoBuffer)
												{
													flag2 = true;
												}
											}
											else if (method_12().AI.IsWithinBufferPath(new GeoPoint(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)), patrol.PatrolArea, 2f))
											{
												flag2 = true;
											}
										}
									}
								}
							}
						}
					}
				}
				result = flag2;
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100393", "");
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

	public override void EmployUntargetedWeapons(float elapsedTime)
	{
		if (!method_12().ParentScen.SecondIsChangingOnThisPulse)
		{
			return;
		}
		Loadout.LoadoutRole? loadoutRole = method_12().Loadout?.Role;
		int? num = (int?)loadoutRole;
		bool? flag2;
		bool? flag = (flag2 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 3104)));
		bool? obj;
		bool? flag3;
		if (flag.HasValue && flag2 == true)
		{
			obj = true;
		}
		else
		{
			num = (int?)loadoutRole;
			flag = (flag3 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 3004)));
			obj = ((!flag.HasValue) ? ((bool?)null) : ((flag3 == true) | flag2));
		}
		bool? flag4 = obj;
		flag3 = obj;
		bool? obj2;
		bool? flag5;
		if (flag3.HasValue && flag4 == true)
		{
			obj2 = true;
		}
		else
		{
			num = (int?)loadoutRole;
			flag3 = (flag5 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 3204)));
			obj2 = ((!flag3.HasValue) ? ((bool?)null) : ((flag5 == true) | flag4));
		}
		flag5 = obj2;
		if (flag5 != true)
		{
			return;
		}
		List<ReferencePoint> list = null;
		if (method_12().ActiveMissionOrPackage() != null)
		{
			Mission._MissionClass missionClass = method_12().ActiveMissionOrPackage().MissionClass;
			if (missionClass == Mission._MissionClass.Patrol)
			{
				Doctrine._WCS? wCS = method_12().Doctrine.get_WeaponControlStatus_Land(method_12().ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false);
				if (!wCS.HasValue || wCS.Value != Doctrine._WCS.Hold)
				{
					list = ((Patrol)method_12().ActiveMissionOrPackage()).PatrolArea;
				}
			}
		}
		if (list == null)
		{
			return;
		}
		List<Weapon> source = method_12().Weaponry.AllDistinctWeaponsAboard_Actual();
		source = source.Where([SpecialName] (Weapon x) => x.IsMobileDecoy_Air).ToList();
		if (source.Count <= 0)
		{
			return;
		}
		Geopoint_Struct thePoint = Math2.RandomPointWithinThisArea(list);
		foreach (Weapon item in source)
		{
			if (item.MaxLandRange > Module_Unit.RangeToPoint_Horiz(method_12(), thePoint) && !method_12().IsInsideNoNavZones(thePoint.Latitude, thePoint.Longitude, 0f))
			{
				Contact theTarget = new ActivationPointContact(thePoint.Latitude, thePoint.Longitude);
				Aircraft_Weaponry weaponry = method_12().Weaponry;
				int dBID = item.DBID;
				Doctrine._GunStrafeGroundTargets? GunStrafingSalvo = null;
				weaponry.CreateSalvo(theTarget, dBID, 1, IsManual: true, ref GunStrafingSalvo, DateTime.MinValue, CreatingSalvoForPalletWeapon: false, CreatingSalvoForPallettizedWeapon: false, RebuildSalvoCache: false);
			}
		}
	}

	public void EvaluateSonoBuoyUse(float elapsedTime)
	{
		Aircraft aircraft = method_12();
		aircraft.ShouldDropSonobuoysOnThisPulse = true;
		if (IsOnSonobuoyRun())
		{
			Parallel.ForEach(new List<Weapon>(aircraft.ParentScen.SonobuoysInWater), [SpecialName] (Weapon theSon, ParallelLoopState loopstate) =>
			{
				if (theSon.Type == Weapon._WeaponType.Sonobuoy && theSon.WeaponSensors().Count > 0 && (((ActiveUnit)aircraft).get_UnitSide(SetSideOnly: false) == ((ActiveUnit)theSon).get_UnitSide(SetSideOnly: false) || Module_Side.IsAlliedWithThisSide(((ActiveUnit)aircraft).get_UnitSide(SetSideOnly: false), ((ActiveUnit)theSon).get_UnitSide(SetSideOnly: false))) && (double)aircraft.RangeToUnit_Horiz(theSon) < Math.Min(9.5, (double)theSon.WeaponSensors()[0].maxRange * 1.5))
				{
					aircraft.ShouldDropSonobuoysOnThisPulse = false;
					loopstate.Stop();
				}
			});
		}
		else
		{
			aircraft.ShouldDropSonobuoysOnThisPulse = false;
		}
	}

	public override void EngageTargets(float elapsedTime)
	{
		try
		{
			if (!myUnit.CommStuff.IsConnectedToSideNetwork && myUnit.IsDrone() && (!myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DroneAutonomyLevels) || myUnit.AutonomyLevel < ActiveUnit.DroneAutonomyLevel.BattlespaceCognizant))
			{
				return;
			}
			int num;
			if (!method_12().ShouldDropSonobuoysOnThisPulse)
			{
				num = 0;
			}
			else
			{
				Aircraft_Weaponry weaponry = method_12().Weaponry;
				string UserFeedback = null;
				weaponry.DropSonobuoy(elapsedTime, IsManual: false, ref UserFeedback);
				num = 0;
			}
			bool flag = (byte)num != 0;
			Mission mission = method_12().ActiveMissionOrPackage();
			if (mission != null && mission.MissionClass == Mission._MissionClass.Support)
			{
				int? num2 = (int?)method_12()?.Loadout?.Role;
				if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2 == 4004)) == true && !method_12().Navigator.IsInSupportTransit)
				{
					flag = true;
				}
			}
			if ((method_12().Weaponry.LayChaffStream || flag) && method_12().Weaponry.HasChaffBundles)
			{
				bool flag2 = false;
				foreach (ChaffCorridorCloud chaffCloud in myUnit.ParentScen.ChaffClouds)
				{
					if (!((double)myUnit.RangeToUnit_Horiz(chaffCloud) > 3.2397419999999997))
					{
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					method_12().Weaponry.FireChaffBundle(elapsedTime);
				}
			}
			if (myUnit.IsOnActiveStrike && myUnit.Navigator.HasFlightPlan && !method_12().Navigator.HasReachedWeaponReleasePoint(fromUI: false))
			{
				Strike strike = (Strike)myUnit.AssignedMissionOrPackage();
				bool flag3 = true;
				if (strike.SpecificTargets.Count > 0)
				{
					Contact[] targets_ReadOnly = base.Targets_ReadOnly;
					foreach (Contact contact in targets_ReadOnly)
					{
						if (contact != null && !contact.get_IsSpecificTargetForThisStrike(strike))
						{
							flag3 = false;
							break;
						}
					}
				}
				else
				{
					Contact[] targets_ReadOnly2 = base.Targets_ReadOnly;
					foreach (Contact contact2 in targets_ReadOnly2)
					{
						if (contact2 != null && !ContactIsRelevantToFlight(contact2))
						{
							flag3 = false;
							break;
						}
					}
				}
				if (flag3)
				{
					return;
				}
			}
			base.EngageTargets(elapsedTime);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100395", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override bool ClosingWithinWeaponRangeOfPrimaryTarget()
	{
		bool result;
		try
		{
			Weapon weapon = myUnit.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, CheckIfWithinRange: false, CheckIfWithinAltitude: false, CheckWRA: true, myUnit.Doctrine);
			if (Information.IsNothing((object)weapon))
			{
				result = false;
			}
			else
			{
				double num = weapon.get_MaxRangeForThisTarget(myUnit, PrimaryTarget, CheckWRA: false, (Doctrine)null, ManualFire: false);
				result = !((double)myUnit.RangeToUnit_Horiz(PrimaryTarget) > num * 1.5);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100396", "");
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

	public override void OptimizeAltSpeedForNextEngagement(float elapsedTime, Weapon weaponBeingGuided, Weapon mostSuitableWeapon)
	{
		Weapon weapon;
		if (weaponBeingGuided != null)
		{
			weapon = weaponBeingGuided;
		}
		else
		{
			if (mostSuitableWeapon == null)
			{
				return;
			}
			weapon = mostSuitableWeapon;
		}
		Waypoint waypoint2 = default(Waypoint);
		if (method_12().Navigator.HasFlightPlan && !myUnit.IsOnActivePatrol())
		{
			ActiveUnit_Navigator navigator;
			int num;
			if (myUnit.get_ParentGroup(UsingMissionPlanner: false) != null && myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator != null)
			{
				navigator = myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator;
				num = 0;
			}
			else
			{
				navigator = myUnit.Navigator;
				num = 0;
			}
			bool flag = (byte)num != 0;
			if (myUnit.ActiveMissionOrPackage() != null && myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike && ((Strike)myUnit.ActiveMissionOrPackage()).TargetCount > 0)
			{
				flag = true;
			}
			Waypoint[] flightPlan = myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan;
			foreach (Waypoint waypoint in flightPlan)
			{
				if (!(flag | navigator.IsOnAutoPlannerPlottedCourse_FinalTargetRun) || waypoint.Type != Waypoint.WaypointType.Target)
				{
					if (navigator.IsOnAutoPlannerPlottedCourse_CruiseAndAttackEgressRun && waypoint.Type == Waypoint.WaypointType.StrikeEgress)
					{
						waypoint2 = waypoint;
						break;
					}
					continue;
				}
				waypoint2 = waypoint;
				break;
			}
			if (waypoint2 == null && navigator.PlottedCourse != null && navigator.PlottedCourse.Length > 0)
			{
				waypoint2 = navigator.PlottedCourse[0];
			}
			if (waypoint2 != null && myUnit.IsAircraft)
			{
				if (waypoint2.TerrainFollowing && waypoint2.DesiredAltitude_TerrainFollowing.HasValue && waypoint2.DesiredAltitude_TerrainFollowing.Value > 0f)
				{
					myUnit.DesiredAltitude_AGL = waypoint2.DesiredAltitude_TerrainFollowing.Value;
					return;
				}
				if (waypoint2.DesiredAltitude.HasValue && waypoint2.DesiredAltitude.Value > 0f)
				{
					myUnit.DesiredAltitude_AGL = 0f;
					if (weapon.MaxLaunchAlt_ASL > 0f)
					{
						float? desiredAltitude = waypoint2.DesiredAltitude;
						float maxLaunchAlt_ASL = weapon.MaxLaunchAlt_ASL;
						if (((!desiredAltitude.HasValue) ? ((bool?)null) : new bool?(desiredAltitude.GetValueOrDefault() > maxLaunchAlt_ASL)) == true)
						{
							waypoint2.DesiredAltitude = weapon.MaxLaunchAlt_ASL;
							goto IL_03fb;
						}
					}
					if (weapon.MinLaunchAlt_ASL > 0f)
					{
						float? desiredAltitude = waypoint2.DesiredAltitude;
						float maxLaunchAlt_ASL = weapon.MinLaunchAlt_ASL;
						if ((desiredAltitude.HasValue ? new bool?(desiredAltitude.GetValueOrDefault() < maxLaunchAlt_ASL) : ((bool?)null)) == true)
						{
							waypoint2.DesiredAltitude = weapon.MinLaunchAlt_ASL;
							goto IL_03fb;
						}
					}
					int val;
					if (!(weapon.MaxLaunchAlt_AGL > 0f))
					{
						if (!(weapon.MinLaunchAlt_AGL > 0f))
						{
							goto IL_03fb;
						}
						val = 0;
					}
					else
					{
						val = 0;
					}
					float num2 = Math.Max(val, Terrain.GetElevation(waypoint2.Latitude, waypoint2.Longitude, RequestIsFromGUI: false, myUnit.ParentScen));
					if (PrimaryTarget != null)
					{
						int num3 = ((Module_Unit.Unit)PrimaryTarget).get_LandElevation(AGL: true, RequestIsFromGUI: false, Force: false, myUnit.ParentScen);
						if ((float)num3 > num2)
						{
							num2 = num3;
						}
					}
					method_12().DesiredAltitude_AGL = 0f;
					if (weapon.MaxLaunchAlt_AGL > 0f)
					{
						float? desiredAltitude = waypoint2.DesiredAltitude;
						float maxLaunchAlt_ASL = weapon.MaxLaunchAlt_AGL + num2;
						if ((desiredAltitude.HasValue ? new bool?(desiredAltitude.GetValueOrDefault() > maxLaunchAlt_ASL) : ((bool?)null)) == true)
						{
							waypoint2.DesiredAltitude = weapon.MaxLaunchAlt_AGL + num2;
							goto IL_03fb;
						}
					}
					if (weapon.MinLaunchAlt_AGL > 0f)
					{
						float? desiredAltitude = waypoint2.DesiredAltitude;
						float maxLaunchAlt_ASL = weapon.MinLaunchAlt_AGL + num2;
						if (((!desiredAltitude.HasValue) ? ((bool?)null) : new bool?(desiredAltitude.GetValueOrDefault() < maxLaunchAlt_ASL)) == true)
						{
							waypoint2.DesiredAltitude = weapon.MinLaunchAlt_AGL + num2;
						}
					}
					goto IL_03fb;
				}
			}
			if (PrimaryTarget.ActualUnit == null)
			{
				ActiveUnit activeUnit = myUnit;
				Aircraft theAircraft = method_12();
				ActiveUnit activeUnit2;
				ActiveUnit theAU;
				bool Return_theAltitude_TerrainFollowing = (activeUnit2 = myUnit).get_DesiredAltitude_UseTerrainFollowing(theAU = myUnit);
				float desiredAltitude2 = MostRealisticOptimumAltitude(ref theAircraft, ActiveUnit.Throttle.Cruise, ref Return_theAltitude_TerrainFollowing);
				activeUnit2.set_DesiredAltitude_UseTerrainFollowing(theAU, Return_theAltitude_TerrainFollowing);
				activeUnit.DesiredAltitude = desiredAltitude2;
				return;
			}
		}
		try
		{
			switch (PrimaryTarget.Type)
			{
			default:
				throw new NotImplementedException();
			case Contact_Base.ContactType.Air:
			case Contact_Base.ContactType.Missile:
			case Contact_Base.ContactType.Orbital:
			case Contact_Base.ContactType.Decoy_Air:
				if (PrimaryTarget.ActualUnit != null && PrimaryTarget.ActualUnit.IsAircraft && ((Aircraft)PrimaryTarget.ActualUnit).IsLighterThanAir)
				{
					method_37(elapsedTime, PrimaryTarget.Type, weaponBeingGuided);
				}
				else
				{
					method_21(elapsedTime);
				}
				break;
			case Contact_Base.ContactType.Submarine:
			case Contact_Base.ContactType.Torpedo:
			case Contact_Base.ContactType.Decoy_Sub:
				method_37(elapsedTime, PrimaryTarget.Type, weaponBeingGuided);
				break;
			case Contact_Base.ContactType.Surface:
			case Contact_Base.ContactType.UndeterminedNaval:
			case Contact_Base.ContactType.Aimpoint:
			case Contact_Base.ContactType.Facility_Fixed:
			case Contact_Base.ContactType.Facility_Mobile:
			case Contact_Base.ContactType.Mine:
			case Contact_Base.ContactType.Decoy_Surface:
			case Contact_Base.ContactType.Decoy_Land:
			case Contact_Base.ContactType.Sonobuoy:
			case Contact_Base.ContactType.Installation:
			case Contact_Base.ContactType.AirBase:
			case Contact_Base.ContactType.NavalBase:
			case Contact_Base.ContactType.MobileGroup:
			case Contact_Base.ContactType.ActivationPoint:
			case Contact_Base.ContactType.AggregateGroundUnit:
				method_37(elapsedTime, PrimaryTarget.Type, weaponBeingGuided);
				break;
			}
			return;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100397", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return;
		}
		IL_03fb:
		((Aircraft)myUnit).DesiredAltitude = waypoint2.DesiredAltitude.Value;
	}

	private void method_37(float float_0, Contact_Base.ContactType contactType_0, Weapon weapon_1)
	{
		Aircraft theAircraft;
		if (PrimaryTarget != null)
		{
			float desiredAltitude = method_12().DesiredAltitude;
			try
			{
				_Closure$__94-0 arg = default(_Closure$__94-0);
				_Closure$__94-0 CS$<>8__locals8 = new _Closure$__94-0(arg);
				CS$<>8__locals8.$VB$Me = this;
				CS$<>8__locals8.$VB$Local_theDoc = myUnit.Doctrine;
				Weapon weapon = weapon_1;
				if (weapon == null)
				{
					Side side = myUnit.get_UnitSide(SetSideOnly: false);
					ref ActiveUnit theAttacker = ref myUnit;
					Contact theTarget = PrimaryTarget;
					List<Weapon> list = side.WeaponsLeftToFireAtThisTarget(ref theAttacker, ref theTarget);
					PrimaryTarget = theTarget;
					List<Weapon> list2 = list;
					weapon = ((list2.Count <= 0) ? myUnit.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, CheckIfWithinRange: true, CheckIfWithinAltitude: true, CheckWRA: true, CS$<>8__locals8.$VB$Local_theDoc) : list2.OrderByDescending([SpecialName] (Weapon theWeapon) => theWeapon.get_MaxRangeForThisTarget(CS$<>8__locals8.$VB$Me.myUnit, CS$<>8__locals8.$VB$Me.PrimaryTarget, CheckWRA: true, CS$<>8__locals8.$VB$Local_theDoc, ManualFire: false)).ElementAtOrDefault(0));
				}
				if (weapon == null)
				{
					weapon = myUnit.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, CheckIfWithinRange: false, CheckIfWithinAltitude: false, CheckWRA: true, CS$<>8__locals8.$VB$Local_theDoc);
				}
				float num;
				float num2;
				bool flag;
				float? num3;
				bool flag2;
				ActiveUnit.Throttle? throttle;
				float? num4;
				Patrol patrol = default(Patrol);
				float num5;
				bool bool_;
				float num7;
				int num10;
				int num11;
				float num9;
				bool value;
				float num8;
				if (weapon != null)
				{
					num = weapon.get_MaxRangeForThisTarget(myUnit, PrimaryTarget, CheckWRA: true, CS$<>8__locals8.$VB$Local_theDoc, ManualFire: false);
					num2 = myUnit.RangeToUnit_Horiz(PrimaryTarget);
					flag = false;
					num3 = null;
					flag2 = false;
					throttle = null;
					num4 = null;
					Mission mission = myUnit.ActiveMissionOrPackage();
					int num6;
					if (mission != null && mission.MissionClass == Mission._MissionClass.Patrol)
					{
						patrol = (Patrol)myUnit.ActiveMissionOrPackage();
						num4 = patrol.AttackDistance_Aircraft;
						if (num4.HasValue)
						{
							num5 = (num4 + num).Value;
							num6 = 0;
						}
						else
						{
							num5 = (float)Math.Max(10f + num, (double)num * 1.2);
							num6 = 0;
						}
					}
					else
					{
						num5 = (float)Math.Max(10f + num, (double)num * 1.2);
						num6 = 0;
					}
					bool_ = (byte)num6 != 0;
					if (!myUnit.IsPaintingATarget || NeedToCrank())
					{
						float val = ((Module_Unit.Unit)PrimaryTarget).get_LandElevation(AGL: true, RequestIsFromGUI: false, Force: false, myUnit.ParentScen);
						float val2 = ((Module_Unit.Unit)myUnit).get_LandElevation(AGL: true, RequestIsFromGUI: false, Force: false, myUnit.ParentScen);
						num7 = Math.Max(val2: ((Module_Unit.Unit)myUnit).get_LandElevation_next(AGL: true, float_0), val1: Math.Max(val2, val));
						num8 = myUnit.DesiredAltitude;
						num9 = myUnit.DesiredAltitude_AGL;
						value = false;
						if (!myUnit.Kinematics.DesiredAltitudeOverride || myUnit.Navigator.IsOnAutoPlannerPlottedCourse)
						{
							Mission mission2 = myUnit.ActiveMissionOrPackage();
							if (mission2 != null && mission2.MissionClass == Mission._MissionClass.Patrol)
							{
								if (patrol == null)
								{
									patrol = (Patrol)myUnit.ActiveMissionOrPackage();
								}
								if (!num4.HasValue || !(num2 > num5))
								{
									if (!patrol.UseAttackAltitude_Preset.HasValue)
									{
										num10 = 0;
										goto IL_03b8;
									}
									bool? useAttackAltitude_Preset = patrol.UseAttackAltitude_Preset;
									bool? flag3 = useAttackAltitude_Preset;
									if (flag3 ?? true)
									{
										byte? b = (byte?)patrol.AttackAltitude_Preset;
										if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 9)) == true)
										{
											if (!flag3.HasValue)
											{
												num11 = 1;
												goto IL_03bd;
											}
											num10 = 0;
											goto IL_03b8;
										}
									}
									num11 = 1;
									goto IL_03bd;
								}
								num3 = patrol.TransitAltitude_Aircraft;
								flag2 = patrol.TransitTerrainFollowing_Aircraft;
								flag = true;
							}
						}
						goto IL_03d4;
					}
					goto IL_14a9;
				}
				ActiveUnit activeUnit = myUnit;
				theAircraft = method_12();
				bool MissionProfileAttackIngressAltitudeTerrainFollowing = default(bool);
				activeUnit.DesiredAltitude = MostRealisticAttackAltitude(ref theAircraft, ActiveUnit.Throttle.Cruise, LoadoutAltitudesOnly: false, ref MissionProfileAttackIngressAltitudeTerrainFollowing);
				if (!myUnit.IsGroupWingman())
				{
					myUnit.set_DesiredAltitude_UseTerrainFollowing(myUnit, MissionProfileAttackIngressAltitudeTerrainFollowing);
				}
				return;
				IL_03bf:
				num3 = patrol.AttackAltitude_Aircraft;
				flag2 = patrol.AttackTerrainFollowing_Aircraft;
				goto IL_03d4;
				IL_03d4:
				float num12;
				float num13;
				bool MissionProfileAttackIngressAltitudeTerrainFollowing2 = default(bool);
				float num14 = default(float);
				if (num3.HasValue)
				{
					num12 = num3.Value;
					num13 = num3.Value;
					if (MissionProfileAttackIngressAltitudeTerrainFollowing2 = flag2)
					{
						num14 = num12;
					}
					if (MissionProfileAttackIngressAltitudeTerrainFollowing2)
					{
						num13 += num7;
					}
				}
				else
				{
					theAircraft = method_12();
					num12 = MostRealisticAttackAltitude(ref theAircraft, ActiveUnit.Throttle.Cruise, LoadoutAltitudesOnly: true, ref MissionProfileAttackIngressAltitudeTerrainFollowing2);
					num13 = num12;
					if (MissionProfileAttackIngressAltitudeTerrainFollowing2)
					{
						num14 = num12;
					}
					if (MissionProfileAttackIngressAltitudeTerrainFollowing2)
					{
						num13 += num7;
					}
				}
				if (num4.HasValue && num2 > num5)
				{
					myUnit.DesiredAltitude = num13;
					myUnit.DesiredAltitude_AGL = num14;
					myUnit.set_DesiredAltitude_UseTerrainFollowing(myUnit, MissionProfileAttackIngressAltitudeTerrainFollowing2);
					return;
				}
				float? num15 = null;
				Weapon._WeaponType type = weapon.Type;
				float num16 = default(float);
				float num17 = default(float);
				if (type != Weapon._WeaponType.Rocket && type != Weapon._WeaponType.Gun)
				{
					if (weapon.MaxLaunchAlt_AGL > 0f && weapon.MaxLaunchAlt_ASL == 0f)
					{
						num16 = weapon.MaxLaunchAlt_AGL + num7;
						num17 = weapon.MaxLaunchAlt_AGL;
					}
					else if (weapon.MaxLaunchAlt_AGL == 0f && weapon.MaxLaunchAlt_ASL > 0f)
					{
						num16 = weapon.MaxLaunchAlt_ASL;
						num17 = weapon.MaxLaunchAlt_ASL - num7;
					}
					else if (weapon.MaxLaunchAlt_AGL > 0f && weapon.MaxLaunchAlt_ASL > 0f)
					{
						num16 = Math.Min(weapon.MaxLaunchAlt_AGL + num7, weapon.MaxLaunchAlt_ASL);
						num17 = Math.Min(weapon.MaxLaunchAlt_ASL - num7, weapon.MaxLaunchAlt_AGL);
					}
					else if (!weapon.IsTorpedo && weapon.MaxLaunchAlt_AGL == 0f && weapon.MaxLaunchAlt_ASL == 0f)
					{
						num16 = num13;
						num17 = num14;
					}
				}
				else
				{
					if (Module_Unit.RangeToUnit_Slant(myUnit, PrimaryTarget) > num)
					{
						num16 = (float)(Math.Sqrt(2.0) / 2.0 * (double)num * 1852.0 + (double)num7);
						num17 = (float)(Math.Sqrt(2.0) / 2.0 * (double)num * 1852.0);
					}
					else
					{
						num16 = weapon.MaxLaunchAlt_AGL + num7;
						num17 = weapon.MaxLaunchAlt_AGL;
					}
					if (num17 > weapon.MaxLaunchAlt_AGL)
					{
						num16 = weapon.MaxLaunchAlt_AGL + num7;
						num17 = weapon.MaxLaunchAlt_AGL;
					}
				}
				float num18 = default(float);
				float num19 = default(float);
				int num20;
				if (weapon.MinLaunchAlt_AGL > 0f && weapon.MinLaunchAlt_ASL == 0f)
				{
					num18 = weapon.MinLaunchAlt_AGL + num7;
					num19 = weapon.MinLaunchAlt_AGL;
					num20 = 0;
				}
				else if (weapon.MinLaunchAlt_AGL == 0f && weapon.MinLaunchAlt_ASL > 0f)
				{
					num18 = weapon.MinLaunchAlt_ASL;
					num19 = weapon.MinLaunchAlt_ASL - num7;
					num20 = 0;
				}
				else if (weapon.MinLaunchAlt_AGL > 0f && weapon.MinLaunchAlt_ASL > 0f)
				{
					num18 = Math.Max(weapon.MinLaunchAlt_AGL + num7, weapon.MinLaunchAlt_ASL);
					num19 = Math.Max(weapon.MinLaunchAlt_ASL - num7, weapon.MinLaunchAlt_AGL);
					num20 = 0;
				}
				else if (weapon.MinLaunchAlt_AGL == 0f && weapon.MinLaunchAlt_ASL < 0f)
				{
					num18 = weapon.MinLaunchAlt_AGL + num7;
					num19 = weapon.MinLaunchAlt_AGL;
					num20 = 0;
				}
				else
				{
					num20 = 0;
				}
				bool flag4 = (byte)num20 != 0;
				if (!Information.IsNothing((object)num3))
				{
					flag4 = true;
				}
				else if (num13 > 0f)
				{
					if (!Information.IsNothing((object)myUnit.ActiveMissionOrPackage()) && myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
					{
						if (myUnit.IsGroupMember() && myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead != null)
						{
							if (myUnit.IsGroupLead())
							{
								Waypoint[] plottedCourse = myUnit.Navigator.PlottedCourse;
								foreach (Waypoint waypoint in plottedCourse)
								{
									if (waypoint.Type == Waypoint.WaypointType.Target && !waypoint.DesiredAltitudeOverride)
									{
										flag4 = true;
										break;
									}
								}
							}
							else
							{
								flag4 = myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.DesiredAltitude != num8;
							}
						}
					}
					else if (!myUnit.Navigator.HasPlottedCourse())
					{
						flag4 = true;
					}
					else if (myUnit.get_DesiredAltitude_UseTerrainFollowing(myUnit) == MissionProfileAttackIngressAltitudeTerrainFollowing2)
					{
						if (!MissionProfileAttackIngressAltitudeTerrainFollowing2)
						{
							if (myUnit.DesiredAltitude == num12)
							{
								flag4 = true;
							}
						}
						else if (myUnit.DesiredAltitude_AGL == num14)
						{
							flag4 = true;
						}
					}
				}
				Aircraft_Navigator navigator = default(Aircraft_Navigator);
				Aircraft_AirOps airOps = default(Aircraft_AirOps);
				if (flag4)
				{
					num8 = num13;
					num9 = num14;
					value = MissionProfileAttackIngressAltitudeTerrainFollowing2;
					if (!flag)
					{
						if (!Information.IsNothing((object)weapon_1))
						{
							float value2 = method_12().get_MinimumSafeHeight(bool_7: true).Value;
							if (num8 < num7 + value2)
							{
								num8 = num7 + value2;
							}
							if (num9 < value2)
							{
								num9 = value2;
							}
						}
						if (!(num13 > 0f) && num14 <= 0f)
						{
							if (num8 > num16)
							{
								num8 = num16;
							}
							if (num8 < num18)
							{
								num8 = num18;
							}
							if (num9 > num17)
							{
								num9 = num17;
							}
							if (num9 < num19)
							{
								num9 = num19;
							}
						}
						else
						{
							if (num18 > num8)
							{
								num8 = num18;
							}
							else if (num16 < num8)
							{
								num8 = num16;
							}
							else
							{
								if (num8 > num16)
								{
									num8 = num16;
								}
								if (num8 < num18)
								{
									num8 = num18;
								}
							}
							if (num19 > num9)
							{
								num9 = num19;
							}
							else if (num17 < num9)
							{
								num9 = num17;
							}
							else
							{
								if (num9 > num17)
								{
									num9 = num17;
								}
								if (num9 < num19)
								{
									num9 = num19;
								}
							}
						}
					}
					if (weapon.get_NeedsVisualLOSBeforeLaunch(PrimaryTarget.isSurfaceOrLandContact))
					{
						num15 = method_39(2.1474836E+09f);
					}
					if (!Information.IsNothing((object)num15))
					{
						if ((num15.HasValue ? new bool?(num18 > num15.GetValueOrDefault()) : ((bool?)null)) == true)
						{
							if (myUnit.ParentScen.ThirtiethSecondIsChangingOnThisPulse)
							{
								string text = "";
								if (Operators.CompareString(method_12().Name, method_12().UnitClass, false) != 0)
								{
									text = " (" + method_12().UnitClass + ")";
								}
								method_12().AddMessage(method_12().Name + text + " cannot engage ground targets because the cloud cover is too low. There will not be enough altitude clearance to deploy weapon.", method_12().Name + " cannot engage target", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(method_12().get_Longitude((GlobalVariables.BooleanObject)null), method_12().get_Latitude((GlobalVariables.BooleanObject)null)));
							}
						}
						else if ((num15.HasValue ? new bool?(num8 > num15.GetValueOrDefault()) : ((bool?)null)) == true)
						{
							num8 = num15.Value;
							num9 = (num15 - num7).Value;
							num16 = num8;
							num17 = num9;
						}
					}
					if (!myUnit.Kinematics.DesiredAltitudeOverride)
					{
						if (!Information.IsNothing((object)myUnit.ActiveMissionOrPackage()) && myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike && (method_12().Navigator.IsOnAutoPlannerPlottedCourse || (myUnit.IsGroupWingman() && !Information.IsNothing((object)myUnit.IsGroupLead()) && myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.IsOnAutoPlannerPlottedCourse)))
						{
							if (num8 != myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))
							{
								myUnit.DesiredAltitude = num8;
								myUnit.DesiredAltitude_AGL = num9;
							}
							else
							{
								myUnit.DesiredAltitude = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
								myUnit.DesiredAltitude_AGL = num9;
							}
						}
						else if (!Information.IsNothing((object)num3))
						{
							myUnit.DesiredAltitude = num8;
							myUnit.DesiredAltitude_AGL = num9;
							myUnit.set_DesiredAltitude_UseTerrainFollowing(myUnit, value);
						}
						else
						{
							float num22 = Math.Abs(myUnit.Kinematics.HorizDistranceRequiredToReachDesiredAltitude(myUnit, num8));
							if (num2 <= num5 + num22)
							{
								bool_ = true;
								if (num8 != myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))
								{
									myUnit.DesiredAltitude = num8;
									myUnit.DesiredAltitude_AGL = num9;
								}
								else
								{
									myUnit.DesiredAltitude = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
									myUnit.DesiredAltitude_AGL = num9;
								}
							}
							else if (!Information.IsNothing((object)myUnit.ActiveMissionOrPackage()) && myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
							{
								ActiveUnit activeUnit2 = myUnit;
								theAircraft = method_12();
								ActiveUnit activeUnit3;
								ActiveUnit theAU;
								bool Return_theAltitude_TerrainFollowing = (activeUnit3 = myUnit).get_DesiredAltitude_UseTerrainFollowing(theAU = myUnit);
								float desiredAltitude2 = MostRealisticOptimumAltitude(ref theAircraft, ActiveUnit.Throttle.Cruise, ref Return_theAltitude_TerrainFollowing);
								activeUnit3.set_DesiredAltitude_UseTerrainFollowing(theAU, Return_theAltitude_TerrainFollowing);
								activeUnit2.DesiredAltitude = desiredAltitude2;
							}
							else if (!Information.IsNothing((object)myUnit.ActiveMissionOrPackage()) && myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
							{
								if (!Information.IsNothing((object)num4) && num2 > num5)
								{
									if (Information.IsNothing((object)navigator))
									{
										navigator = method_12().Navigator;
									}
									if (Information.IsNothing((object)airOps))
									{
										airOps = method_12().AirOps;
									}
									navigator.SetPatrolAltitude(PursueContact: false, airOps.Condition);
								}
								else
								{
									theAircraft = method_12();
									ActiveUnit theAU;
									ActiveUnit activeUnit3;
									bool Return_theAltitude_TerrainFollowing = (theAU = myUnit).get_DesiredAltitude_UseTerrainFollowing(activeUnit3 = myUnit);
									float num23 = MostRealisticAttackAltitude(ref theAircraft, ActiveUnit.Throttle.Cruise, LoadoutAltitudesOnly: false, ref Return_theAltitude_TerrainFollowing);
									theAU.set_DesiredAltitude_UseTerrainFollowing(activeUnit3, Return_theAltitude_TerrainFollowing);
									num8 = num23;
									myUnit.DesiredAltitude = num8;
									myUnit.DesiredAltitude_AGL = num8;
								}
							}
							else
							{
								if (Information.IsNothing((object)navigator))
								{
									navigator = method_12().Navigator;
								}
								Aircraft_Navigator aircraft_Navigator = navigator;
								ActiveUnit activeUnit3;
								ActiveUnit theAU;
								bool Return_theAltitude_TerrainFollowing = (activeUnit3 = myUnit).get_DesiredAltitude_UseTerrainFollowing(theAU = myUnit);
								float bingoFuelAltitude = aircraft_Navigator.GetBingoFuelAltitude(ref Return_theAltitude_TerrainFollowing);
								activeUnit3.set_DesiredAltitude_UseTerrainFollowing(theAU, Return_theAltitude_TerrainFollowing);
								num8 = bingoFuelAltitude;
								myUnit.DesiredAltitude = num8;
							}
						}
					}
					else
					{
						if (myUnit.DesiredAltitude > num16)
						{
							myUnit.DesiredAltitude = num16;
						}
						if (myUnit.DesiredAltitude < num18)
						{
							myUnit.DesiredAltitude = num18;
						}
						if (myUnit.DesiredAltitude_AGL > num17)
						{
							myUnit.DesiredAltitude_AGL = num17;
						}
						if (myUnit.DesiredAltitude_AGL < num19)
						{
							myUnit.DesiredAltitude_AGL = num19;
						}
					}
				}
				else
				{
					if (!Information.IsNothing((object)weapon_1))
					{
						float value3 = method_12().get_MinimumSafeHeight(bool_7: true).Value;
						if (num8 < num7 + value3)
						{
							num8 = num7 + value3;
						}
						if (num9 < value3)
						{
							num9 = value3;
						}
					}
					if (num8 > num16)
					{
						num8 = num16;
					}
					if (num8 < num18)
					{
						num8 = num18;
					}
					if (num9 > num17)
					{
						num9 = num17;
					}
					if (num9 < num19)
					{
						num9 = num19;
					}
					if (weapon.get_NeedsVisualLOSBeforeLaunch(PrimaryTarget.isSurfaceOrLandContact))
					{
						num15 = method_39(2.1474836E+09f);
					}
					if (!Information.IsNothing((object)num15))
					{
						if ((num15.HasValue ? new bool?(num18 > num15.GetValueOrDefault()) : ((bool?)null)) == true)
						{
							if (myUnit.ParentScen.ThirtiethSecondIsChangingOnThisPulse)
							{
								string text2 = "";
								if (Operators.CompareString(method_12().Name, method_12().UnitClass, false) != 0)
								{
									text2 = " (" + method_12().UnitClass + ")";
								}
								method_12().AddMessage(method_12().Name + text2 + " cannot engage ground targets because the cloud cover is too low. There will not be enough altitude clearance to deploy weapon.", method_12().Name + " cannot engage targets", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(method_12().get_Longitude((GlobalVariables.BooleanObject)null), method_12().get_Latitude((GlobalVariables.BooleanObject)null)));
							}
						}
						else if ((num15.HasValue ? new bool?(num8 > num15.GetValueOrDefault()) : ((bool?)null)) == true)
						{
							num8 = (num15 - 10f).Value;
							num9 = (num15 - num7).Value;
							num16 = num8;
							num17 = num9;
						}
					}
					if (myUnit.Kinematics.DesiredAltitudeOverride)
					{
						if (myUnit.DesiredAltitude > num16)
						{
							myUnit.DesiredAltitude = num16;
						}
						if (myUnit.DesiredAltitude < num18)
						{
							myUnit.DesiredAltitude = num18;
						}
						if (myUnit.DesiredAltitude_AGL > num17)
						{
							myUnit.DesiredAltitude_AGL = num17;
						}
						if (myUnit.DesiredAltitude_AGL < num19)
						{
							myUnit.DesiredAltitude_AGL = num19;
						}
					}
					else if (!Information.IsNothing((object)myUnit.ActiveMissionOrPackage()) && myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike && (method_12().Navigator.IsOnAutoPlannerPlottedCourse || (myUnit.IsGroupWingman() && !Information.IsNothing((object)myUnit.IsGroupLead()) && myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.IsOnAutoPlannerPlottedCourse)))
					{
						if (num8 != myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))
						{
							myUnit.DesiredAltitude = num8;
							myUnit.DesiredAltitude_AGL = num9;
						}
						else
						{
							myUnit.DesiredAltitude = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
							myUnit.DesiredAltitude_AGL = num9;
						}
					}
					else if (!Information.IsNothing((object)num3))
					{
						myUnit.DesiredAltitude = num8;
						myUnit.DesiredAltitude_AGL = num9;
						myUnit.set_DesiredAltitude_UseTerrainFollowing(myUnit, value);
					}
					else
					{
						float num22 = Math.Abs(myUnit.Kinematics.HorizDistranceRequiredToReachDesiredAltitude(myUnit, num8));
						if (num2 <= num5 + num22)
						{
							bool_ = true;
							if (num8 != myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))
							{
								myUnit.DesiredAltitude = num8;
								myUnit.DesiredAltitude_AGL = num9;
							}
							else
							{
								myUnit.DesiredAltitude = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
								myUnit.DesiredAltitude_AGL = num9;
							}
						}
						else if (!Information.IsNothing((object)myUnit.ActiveMissionOrPackage()) && myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
						{
							ActiveUnit activeUnit4 = myUnit;
							theAircraft = method_12();
							ActiveUnit theAU;
							ActiveUnit activeUnit3;
							bool Return_theAltitude_TerrainFollowing = (theAU = myUnit).get_DesiredAltitude_UseTerrainFollowing(activeUnit3 = myUnit);
							float desiredAltitude3 = MostRealisticOptimumAltitude(ref theAircraft, ActiveUnit.Throttle.Cruise, ref Return_theAltitude_TerrainFollowing);
							theAU.set_DesiredAltitude_UseTerrainFollowing(activeUnit3, Return_theAltitude_TerrainFollowing);
							activeUnit4.DesiredAltitude = desiredAltitude3;
						}
						else if (!Information.IsNothing((object)myUnit.ActiveMissionOrPackage()) && myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
						{
							if (!Information.IsNothing((object)num4) && num2 > num5)
							{
								if (Information.IsNothing((object)navigator))
								{
									navigator = method_12().Navigator;
								}
								if (Information.IsNothing((object)airOps))
								{
									airOps = method_12().AirOps;
								}
								navigator.SetPatrolAltitude(PursueContact: false, airOps.Condition);
							}
							else
							{
								theAircraft = method_12();
								ActiveUnit activeUnit3;
								ActiveUnit theAU;
								bool Return_theAltitude_TerrainFollowing = (activeUnit3 = myUnit).get_DesiredAltitude_UseTerrainFollowing(theAU = myUnit);
								float num24 = MostRealisticAttackAltitude(ref theAircraft, ActiveUnit.Throttle.Cruise, LoadoutAltitudesOnly: false, ref Return_theAltitude_TerrainFollowing);
								activeUnit3.set_DesiredAltitude_UseTerrainFollowing(theAU, Return_theAltitude_TerrainFollowing);
								num8 = num24;
								myUnit.DesiredAltitude = num8;
								myUnit.DesiredAltitude_AGL = num9;
							}
						}
						else
						{
							if (Information.IsNothing((object)navigator))
							{
								navigator = method_12().Navigator;
							}
							Aircraft_Navigator aircraft_Navigator2 = navigator;
							ActiveUnit theAU;
							ActiveUnit activeUnit3;
							bool Return_theAltitude_TerrainFollowing = (theAU = myUnit).get_DesiredAltitude_UseTerrainFollowing(activeUnit3 = myUnit);
							float bingoFuelAltitude2 = aircraft_Navigator2.GetBingoFuelAltitude(ref Return_theAltitude_TerrainFollowing);
							theAU.set_DesiredAltitude_UseTerrainFollowing(activeUnit3, Return_theAltitude_TerrainFollowing);
							num8 = bingoFuelAltitude2;
							myUnit.DesiredAltitude = num8;
							myUnit.DesiredAltitude_AGL = num9;
							myUnit.set_DesiredAltitude_UseTerrainFollowing(myUnit, value);
						}
					}
				}
				goto IL_14a9;
				IL_14a9:
				if (!method_12().Kinematics.DesiredSpeedOverride.HasValue || myUnit.Navigator.IsOnAutoPlannerPlottedCourse)
				{
					if (!Information.IsNothing((object)myUnit.ActiveMissionOrPackage()) && myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
					{
						if (Information.IsNothing((object)patrol))
						{
							patrol = (Patrol)myUnit.ActiveMissionOrPackage();
						}
						throttle = ((Information.IsNothing((object)num4) || !(num2 > num5)) ? patrol.AttackThrottle_Aircraft : patrol.TransitThrottle_Aircraft);
					}
					if (!Information.IsNothing((object)throttle))
					{
						myUnit.SetThrottle(throttle.Value);
					}
					else if (num2 > num5)
					{
						myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
					}
					else
					{
						if (Information.IsNothing((object)navigator))
						{
							navigator = method_12().Navigator;
						}
						if (Information.IsNothing((object)airOps))
						{
							airOps = method_12().AirOps;
						}
						navigator.SetInterceptThrottle(myUnit.DesiredAltitude, myUnit.Kinematics.GetMaximumSpeed(myUnit.DesiredAltitude, ActiveUnit.Throttle.Cruise, ValidateAndFixAltitude: false), CanUseAfterburner: false, airOps.Condition);
						if (weapon.MaxLaunchSpeed != 0 && (float)weapon.MaxLaunchSpeed < myUnit.DesiredSpeed)
						{
							myUnit.DesiredSpeed = weapon.MaxLaunchSpeed;
						}
						if (weapon.MinLaunchSpeed != 0 && (float)weapon.MinLaunchSpeed > myUnit.DesiredSpeed)
						{
							myUnit.DesiredSpeed = weapon.MinLaunchSpeed;
						}
					}
				}
				if (weapon_1 == null && myUnit.DesiredAltitude == desiredAltitude && weapon != null)
				{
					Mount mount = null;
					mount = valueTuple_0.Item1;
					if (method_38(weapon, mount, bool_))
					{
						myUnit.AI.Calculate_And_Set_DesiredPitch(((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
					}
				}
				return;
				IL_03bd:
				flag = (byte)num11 != 0;
				goto IL_03bf;
				IL_03b8:
				flag = (byte)num10 != 0;
				goto IL_03bf;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200351", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return;
			}
		}
		ActiveUnit activeUnit5 = myUnit;
		theAircraft = method_12();
		bool MissionProfileAttackIngressAltitudeTerrainFollowing3 = default(bool);
		activeUnit5.DesiredAltitude = MostRealisticAttackAltitude(ref theAircraft, ActiveUnit.Throttle.Cruise, LoadoutAltitudesOnly: false, ref MissionProfileAttackIngressAltitudeTerrainFollowing3);
		if (!myUnit.IsGroupWingman())
		{
			myUnit.set_DesiredAltitude_UseTerrainFollowing(myUnit, MissionProfileAttackIngressAltitudeTerrainFollowing3);
		}
	}

	private bool method_38(Weapon weapon_1, Mount mount_0, bool bool_0)
	{
		int result;
		if (weapon_1 != null)
		{
			if (PrimaryTarget == null)
			{
				result = 0;
				goto IL_0163;
			}
			if (bool_0 || myUnit.RangeToUnit_Horiz(PrimaryTarget) < weapon_1.get_MaxRangeForThisTarget(myUnit, PrimaryTarget, CheckWRA: false, myUnit.Doctrine, ManualFire: false))
			{
				float BoresightLimit = default(float);
				bool bool_1 = default(bool);
				weapon_1.GetBoresightLimit(myUnit, PrimaryTarget, ref BoresightLimit, ref bool_1);
				if (BoresightLimit > 0f)
				{
					double BearingAngle = default(double);
					double VerticalAngle = default(double);
					Module_Unit.AngleOffThisUnitsBoresight3D(PrimaryTarget, myUnit, ref BearingAngle, ref VerticalAngle);
					if (!bool_1)
					{
						result = 0;
						goto IL_0163;
					}
					if (Math.Abs(BearingAngle) <= (double)BoresightLimit && Math.Abs(VerticalAngle - (double)myUnit.Attitude_Pitch) > (double)(BoresightLimit - 1f))
					{
						if (VerticalAngle < 0.0)
						{
							int result2;
							if (weapon_1.MinLaunchAlt_ASL > 0f && !(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > weapon_1.MinLaunchAlt_ASL))
							{
								result2 = 0;
							}
							else
							{
								if (!(weapon_1.MinLaunchAlt_AGL > 0f) || !(myUnit.CurrentAltitude_AGL <= weapon_1.MinLaunchAlt_AGL))
								{
									goto IL_015d;
								}
								result2 = 0;
							}
							return (byte)result2 != 0;
						}
						int result3;
						if (weapon_1.MaxLaunchAlt_ASL > 0f && !(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < weapon_1.MaxLaunchAlt_ASL))
						{
							result3 = 0;
						}
						else
						{
							if (!(weapon_1.MaxLaunchAlt_AGL > 0f) || !(myUnit.CurrentAltitude_AGL >= weapon_1.MaxLaunchAlt_AGL))
							{
								goto IL_015d;
							}
							result3 = 0;
						}
						return (byte)result3 != 0;
					}
				}
			}
		}
		result = 0;
		goto IL_0163;
		IL_0163:
		return (byte)result != 0;
		IL_015d:
		return true;
	}

	private float? method_39(float float_0)
	{
		Weather.WeatherProfile weatherProfile = Weather.get_WeatherAtThisTimeAndPlace(myUnit.ParentScen, myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), (int)Math.Round(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)));
		float? num = null;
		if (weatherProfile.CloudInfo.HighCloudCoverThickness > 0 && float_0 >= (float)weatherProfile.CloudInfo.HighCloudBase_m)
		{
			if ((float)weatherProfile.CloudInfo.HighCloudTop_m > float_0)
			{
				return num;
			}
			num = weatherProfile.CloudInfo.HighCloudBase_m;
		}
		if (weatherProfile.CloudInfo.MiddleCloudCoverThickness > 0 && float_0 >= (float)weatherProfile.CloudInfo.MiddleCloudBase_m)
		{
			num = ((!Information.IsNothing((object)num) || !((float)weatherProfile.CloudInfo.MiddleCloudTop_m > float_0)) ? new float?(weatherProfile.CloudInfo.MiddleCloudBase_m) : ((float?)null));
		}
		if (weatherProfile.CloudInfo.LowCloudCoverThickness > 0 && float_0 >= (float)weatherProfile.CloudInfo.LowCloudBase_m)
		{
			num = ((!Information.IsNothing((object)num) || !((float)weatherProfile.CloudInfo.LowCloudTop_m > float_0)) ? new float?(weatherProfile.CloudInfo.LowCloudBase_m) : ((float?)null));
		}
		return num;
	}

	public void AssistRefuellingClients()
	{
		try
		{
			List<Aircraft> list = new List<Aircraft>();
			if (method_12().AirOps.RefuellingQueue.Count > 0)
			{
				PooledList<string> pooledList = new PooledList<string>(method_12().AirOps.RefuellingQueue.Keys);
				double TotalCurrent = default(double);
				foreach (string item in pooledList)
				{
					if (string.IsNullOrEmpty(item))
					{
						continue;
					}
					Aircraft aircraft = (Aircraft)method_12().ParentScen.ActiveUnits[item];
					if (aircraft != null)
					{
						bool flag = false;
						flag = ((!aircraft.IsGroupWingman()) ? aircraft.Navigator.TankerIsBlockedByNoNavZone : ((ActiveUnit)aircraft).get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.TankerIsBlockedByNoNavZone);
						if (flag || aircraft == null)
						{
							continue;
						}
						double TotalMax = 0.0;
						double num = aircraft.FuelPercent(ref TotalCurrent, ref TotalMax, MissionFuel: false);
						float num2 = aircraft.RangeToUnit_Horiz(method_12());
						float num3 = (float)((double)aircraft.get_FuelEndurance(aircraft.ThrottleSetting, (AltBand)null, (float?)aircraft.CurrentSpeed, (float?)aircraft.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) / 3600.0 * (double)aircraft.CurrentSpeed);
						if (!(num < 0.15) && (double)num3 >= (double)num2 * 1.15)
						{
							if (aircraft.ActiveMissionOrPackage() != null && aircraft.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike && aircraft.FuelState == ActiveUnit._ActiveUnitFuelState.IsBingo)
							{
								list.Add(aircraft);
							}
						}
						else
						{
							list.Add(aircraft);
						}
					}
					else
					{
						method_12().AirOps.RefuellingQueue.Remove(item);
					}
				}
				pooledList.Dispose();
			}
			if (list.Count > 0)
			{
				if (method_12().RangeToUnit_Horiz(list[0]) > 10f)
				{
					((ActiveUnit)method_12()).set_DesiredHeading(ActiveUnit.TurnRate.Max, Math2.CalcAzimuth(method_12().get_Latitude((GlobalVariables.BooleanObject)null), method_12().get_Longitude((GlobalVariables.BooleanObject)null), list[0].get_Latitude((GlobalVariables.BooleanObject)null), list[0].get_Longitude((GlobalVariables.BooleanObject)null)));
				}
				if (method_12().AirOps.Condition != Aircraft_AirOps._AirOpsCondition.OffloadingFuel && method_12().ThrottleSetting < ActiveUnit.Throttle.Cruise)
				{
					method_12().SetThrottle(ActiveUnit.Throttle.Cruise);
				}
			}
			else if (method_12().AirOps.Condition == Aircraft_AirOps._AirOpsCondition.OffloadingFuel)
			{
				List<KeyValuePair<string, Aircraft_AirOps.GEnum0>> list2 = new List<KeyValuePair<string, Aircraft_AirOps.GEnum0>>();
				ActiveUnit activeUnit = null;
				ActiveUnit activeUnit2 = null;
				list2.AddRange(method_12().AirOps.A2AR_Connections);
				foreach (KeyValuePair<string, Aircraft_AirOps.GEnum0> item2 in list2)
				{
					if (string.IsNullOrEmpty(item2.Key))
					{
						continue;
					}
					if (!method_12().ParentScen.ActiveUnits.TryGetValue(item2.Key, out var value))
					{
						method_12().AirOps.A2AR_Connections.Remove(item2.Key);
						continue;
					}
					Aircraft aircraft2 = (Aircraft)value;
					if (aircraft2.AI.IsEscort)
					{
						if (activeUnit2 != null || aircraft2.ActiveMissionOrPackage() == null)
						{
							continue;
						}
						if (!aircraft2.Navigator.TankerFollowsMe.HasValue)
						{
							if (aircraft2.ActiveMissionOrPackage().TankerFollowsReceivers)
							{
								activeUnit2 = aircraft2;
							}
						}
						else if (aircraft2.Navigator.TankerFollowsMe == true && aircraft2.ActiveMissionOrPackage().TankerFollowsReceivers)
						{
							activeUnit2 = aircraft2;
						}
					}
					else
					{
						if (aircraft2.IsGroupWingman() || aircraft2.ActiveMissionOrPackage() == null)
						{
							continue;
						}
						if (aircraft2.Navigator.TankerFollowsMe.HasValue)
						{
							if (aircraft2.Navigator.TankerFollowsMe == true && aircraft2.Navigator.HasPlottedCourse())
							{
								activeUnit = aircraft2;
								break;
							}
						}
						else if (aircraft2.ActiveMissionOrPackage().TankerFollowsReceivers && aircraft2.Navigator.HasPlottedCourse())
						{
							activeUnit = aircraft2;
							break;
						}
					}
				}
				if (activeUnit != null)
				{
					((ActiveUnit)method_12()).set_DesiredHeading(ActiveUnit.TurnRate.Navigation, activeUnit.DesiredHeading);
					method_12().DesiredTurnRate_Navigation = activeUnit.DesiredTurnRate_Navigation;
				}
				else if (activeUnit2 != null)
				{
					((ActiveUnit)method_12()).set_DesiredHeading(ActiveUnit.TurnRate.Navigation, activeUnit2.DesiredHeading);
					method_12().DesiredTurnRate_Navigation = activeUnit2.DesiredTurnRate_Navigation;
				}
			}
			if (method_12().AirOps.RefuellingQueue.Count > 0)
			{
				PooledList<string> pooledList2 = new PooledList<string>(method_12().AirOps.RefuellingQueue.Keys);
				foreach (string item3 in pooledList2)
				{
					if ((object)item3 == string.Empty)
					{
						method_12().AirOps.RefuellingQueue.Remove(item3);
					}
					else
					{
						if (item3 == null)
						{
							continue;
						}
						Aircraft aircraft3 = (Aircraft)method_12().ParentScen.ActiveUnits[item3];
						if (aircraft3 == null)
						{
							method_12().AirOps.RefuellingQueue.Remove(item3);
							continue;
						}
						if (!method_12().Kinematics.DesiredAltitudeOverride && method_12().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > aircraft3.Kinematics.GetMaximumAltitude())
						{
							method_12().DesiredAltitude = aircraft3.Kinematics.GetMaximumAltitude() - 100f;
						}
						if (method_12().Kinematics.DesiredSpeedOverride.HasValue || method_12().ThrottleSetting <= ActiveUnit.Throttle.Loiter)
						{
							continue;
						}
						Aircraft observerUnit = method_12();
						string feedbackMessage = "";
						float num4 = Module_Unit.AngleOffThisUnitsBoresight(aircraft3, observerUnit, DistinguishBetweenStarboardAndPort: false, ref feedbackMessage, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
						if (!(num4 <= 315f) || !(num4 >= 135f))
						{
							continue;
						}
						if (method_12().RangeToUnit_Horiz(aircraft3) < 25f)
						{
							method_12().SetThrottle(ActiveUnit.Throttle.Loiter);
						}
						else if (!aircraft3.Navigator.IsOnAutoPlannerPlottedCourse)
						{
							if (method_12().ActiveMissionOrPackage() != null && method_12().ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Ferry)
							{
								method_12().SetThrottle(ActiveUnit.Throttle.Loiter);
							}
						}
						else
						{
							method_12().SetThrottle(ActiveUnit.Throttle.Loiter);
						}
					}
				}
				pooledList2.Dispose();
			}
			if (!method_12().Kinematics.DesiredSpeedOverride.HasValue && method_12().AirOps.Condition == Aircraft_AirOps._AirOpsCondition.OffloadingFuel && method_12().ThrottleSetting > ActiveUnit.Throttle.Loiter)
			{
				method_12().SetThrottle(ActiveUnit.Throttle.Loiter);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100401", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_40(float float_0, bool bool_0)
	{
		PathBlockCheckInProgress = true;
		if (PrimaryTarget == null)
		{
			return;
		}
		try
		{
			if (!myUnit.Navigator.PathFindingInProgress)
			{
				ActiveUnit_Navigator navigator = myUnit.Navigator;
				double startLat = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
				double startLon = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
				double destLat = ((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null);
				double destLon = ((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null);
				int ReasonForInterrupt = 0;
				GeoPoint InterruptLocation = null;
				if (navigator.PathLineIsInterrupted(startLat, startLon, destLat, destLon, RunInParallel: true, 0f, CheckIfCurrentlyInsideIllegalArea: false, null, IsPathfindingQuery: true, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: false, null, ref ReasonForInterrupt, ref InterruptLocation))
				{
					List<Waypoint> list = new List<Waypoint>();
					list.AddRange(myUnit.Navigator.PlottedCourse);
					if (!myUnit.Navigator.PathFindingInProgress)
					{
						if (myUnit.Navigator.HasPathfindingPlottedCourse)
						{
							Waypoint waypoint = (from theWP in list
								where theWP.Type == Waypoint.WaypointType.PathfindingPoint
								orderby list.IndexOf(theWP) descending
								select theWP).ElementAtOrDefault(0);
							float num = myUnit.Weaponry.LongestRangedSuitableWeaponForThisTarget(PrimaryTarget)?.get_MaxRangeForThisTarget(myUnit, PrimaryTarget, CheckWRA: false, (Doctrine)null, ManualFire: false) ?? 1f;
							if (Math2.CalcDist(waypoint.Latitude, waypoint.Longitude, ((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null)) > num)
							{
								myUnit.Navigator.TriggerPathfinderThread(waypoint, myUnit, null, theIngressPath: false, 0.15f, ((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), myUnit.ParentScen, bool_0);
							}
							else
							{
								myUnit.Navigator.FollowPlottedCourse(float_0);
							}
						}
						else
						{
							myUnit.Navigator.TriggerPathfinderThread(null, myUnit, null, theIngressPath: false, 0.15f, ((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), myUnit.ParentScen, bool_0);
						}
					}
				}
				else if (myUnit.Navigator.HasPathfindingPlottedCourse)
				{
					myUnit.Navigator.ClearPathfindingWaypoints();
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100402", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		PathBlockCheckInProgress = false;
	}

	private void method_41(bool bool_0 = false)
	{
		try
		{
			if (base.Targets_ReadOnly.Length == 0 || method_12().ParentScen.GuidedWeaponsInAir.Count == 0)
			{
				return;
			}
			List<Weapon> list = method_12().Weaponry.IsGuidingWeaponsInAir_List();
			if (list.Count == 0 && !bool_0)
			{
				return;
			}
			if (list_9 != null)
			{
				list_9.Clear();
			}
			else
			{
				list_9 = new List<Contact>();
			}
			Contact[] targets_ReadOnly = base.Targets_ReadOnly;
			foreach (Contact contact in targets_ReadOnly)
			{
				weapon_0 = contact.IncomingGuidedWeapons;
				if (list.Intersect(weapon_0).Count() > 0)
				{
					list_9.Add(contact);
				}
			}
			if (bool_0 && list_9.Count == 0)
			{
				list_9.Add(PrimaryTarget);
			}
			if (list_9.Count == 0)
			{
				return;
			}
			List<Sensor> list2 = new List<Sensor>();
			List<Weapon> list3 = list.Where([SpecialName] (Weapon w) => w.GuidanceHasSemiActivePhase && !w.HasGoneAutonomous).ToList();
			if (list3.Count > 0)
			{
				Sensor SuitableIlluminator = null;
				foreach (Weapon item in list3)
				{
					if (item.Guidance != Weapon.WeaponGuidanceType.TimesharedSemiActive_Plus_Active && (item.FiringParent == myUnit || item.AttemptBuddyIllumination()))
					{
						ActiveUnit_Sensory sensory = myUnit.Sensory;
						Contact primaryTarget = item.AI.PrimaryTarget;
						bool? LOS_Exists_Radar = null;
						bool? LOS_Exists_RadarSW = null;
						Module_Unit.Unit.LOSCheckResult? LOS_Exists_Visual = null;
						bool? LOS_Exists_Sonar = null;
						if (sensory.CanIlluminateThisContactForThisWeapon(primaryTarget, item, ref SuitableIlluminator, ref LOS_Exists_Radar, ref LOS_Exists_RadarSW, ref LOS_Exists_Visual, ref LOS_Exists_Sonar) && SuitableIlluminator != null)
						{
							list2.Add(SuitableIlluminator);
							SuitableIlluminator = null;
						}
					}
				}
			}
			method_12().AirOps.Condition = Aircraft_AirOps._AirOpsCondition.BVRCrank;
			Contact contact2 = ((PrimaryTarget != null) ? PrimaryTarget : base.Targets_ReadOnly[0]);
			int num = (int)Math.Round(Math2.CalcAzimuth(method_12().get_Latitude((GlobalVariables.BooleanObject)null), method_12().get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact2).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact2).get_Longitude((GlobalVariables.BooleanObject)null)));
			int num2 = num;
			int num3 = 5;
			do
			{
				int num4 = Math2.NormalizeBearing(num - num3);
				int num5 = 0;
				foreach (Contact item2 in list_9)
				{
					Sensor[] sensors_Cached = method_12().Sensors_Cached;
					foreach (Sensor sensor in sensors_Cached)
					{
						if (sensor.Type != Sensor.Sensor_Type.Radar)
						{
							continue;
						}
						if (list2.Contains(sensor))
						{
							if (sensor.TargetIsWithinIlluminateCoverageArc(item2, num4))
							{
								num5++;
								break;
							}
						}
						else if (sensor.TargetIsWithinCoverageArc(item2, num4))
						{
							num5++;
							break;
						}
					}
				}
				if (num5 != list_9.Count)
				{
					break;
				}
				num2 = num4;
				num3 += 5;
			}
			while (num3 <= 360);
			Sensor sensor2 = method_12().Sensors_Cached.Where([SpecialName] (Sensor theS) => theS.Type == Sensor.Sensor_Type.Radar).FirstOrDefault();
			int num7 = 0;
			int num9;
			if (sensor2 != null)
			{
				if (sensor2.Codes.PESA || sensor2.Codes.AESA)
				{
					float startAngle = 0f;
					float endAngle = 0f;
					if (sensor2.GetCoverageArc(0f, ref startAngle, ref endAngle))
					{
						float num8 = endAngle - startAngle;
						num7 = Math.Min(20, 4 + (int)Math.Round((double)num8 / 22.5 * 2.0));
					}
					else
					{
						num7 = 20;
					}
					goto IL_03ee;
				}
				num9 = 1;
			}
			else
			{
				num9 = 1;
			}
			num7 = num9;
			goto IL_03ee;
			IL_03ee:
			int num10 = Math2.NormalizeBearing(num2 - num7);
			((ActiveUnit)method_12()).set_DesiredHeading(ActiveUnit.TurnRate.Max, (float)num10);
			if (!method_12().Kinematics.DesiredSpeedOverride.HasValue)
			{
				method_12().SetThrottle(ActiveUnit.Throttle.Loiter);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100403", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_42()
	{
		try
		{
			if (base.Targets_ReadOnly.Length == 0 || method_12().ParentScen.GuidedWeaponsInAir.Count == 0)
			{
				return;
			}
			List<Weapon> first = method_12().ParentScen.GuidedWeaponsInAir.Where([SpecialName] (Weapon theW) => theW.FiringParent == method_12() && theW.IsBVR()).ToList();
			List<Contact> list = new List<Contact>();
			Contact[] targets_ReadOnly = base.Targets_ReadOnly;
			foreach (Contact contact in targets_ReadOnly)
			{
				Weapon[] incomingGuidedWeapons = contact.IncomingGuidedWeapons;
				if (first.Intersect(incomingGuidedWeapons).Count() > 0)
				{
					list.Add(contact);
				}
			}
			if (list.Count != 0)
			{
				method_12().AirOps.Condition = Aircraft_AirOps._AirOpsCondition.BVRDrag;
				Contact theUnit = list.OrderByDescending([SpecialName] (Contact theC) => theC.RangeToUnit_Horiz(method_12())).ElementAtOrDefault(0);
				((ActiveUnit)method_12()).set_DesiredHeading(ActiveUnit.TurnRate.Max, Math2.NormalizeBearing(Module_Unit.BearingToUnit_True(method_12(), theUnit) + 180f));
				if (Information.IsNothing((object)method_12().Kinematics.DesiredSpeedOverride))
				{
					method_12().SetThrottle(ActiveUnit.Throttle.Flank);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 10324523409589238590238095", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_43(float float_0)
	{
		_Closure$__103-1 closure$__103- = new _Closure$__103-1(closure$__103-);
		closure$__103-.$VB$Me = this;
		float num = 2f;
		closure$__103-.$VB$Local_myMission = (MineClearingMission)myUnit.ActiveMissionOrPackage();
		bool flag = myUnit.Navigator.IsInsideMissionArea(ref closure$__103-.$VB$Local_myMission.Area, ref closure$__103-.$VB$Local_myMission.Area_2nm_Buffered, ref closure$__103-.$VB$Local_myMission.Area_2nm_ChangeCheck, 2, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false);
		Aircraft_AirOps airOps = method_12().AirOps;
		method_12().Navigator.SetPatrolThrottle(PursueContact: false, airOps.Condition);
		method_12().Navigator.SetPatrolAltitude(PursueContact: false, airOps.Condition);
		try
		{
			_Closure$__103-0 arg = default(_Closure$__103-0);
			_Closure$__103-0 CS$<>8__locals49 = new _Closure$__103-0(arg);
			CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2 = closure$__103-;
			if (!flag)
			{
				if (myUnit.IsGroupMember())
				{
					if (!myUnit.IsGroupLead())
					{
						if (myUnit.CommStuff.IsConnectedToSideNetwork)
						{
							myUnit.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(float_0);
						}
					}
					else if (myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
					{
						if (!myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlottedCourseLeadsToMissionArea(ref CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_myMission.Area, ref CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_myMission.Area_30nm_Buffered, ref CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_myMission.Area_30nm_ChangeCheck, 30f, IgnoreTimeToNextEvaluation: false))
						{
							myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlotCourseToArea(CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_myMission.Area);
						}
						myUnit.Navigator.FollowPlottedCourse(float_0);
					}
					else
					{
						myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlotCourseToArea(CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_myMission.Area);
					}
				}
				else if (!myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
				{
					myUnit.Navigator.PlotCourseToArea(CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_myMission.Area);
				}
				else
				{
					if (!myUnit.Navigator.PlottedCourseLeadsToMissionArea(ref CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_myMission.Area, ref CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_myMission.Area_30nm_Buffered, ref CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_myMission.Area_30nm_ChangeCheck, 30f, IgnoreTimeToNextEvaluation: false))
					{
						myUnit.Navigator.PlotCourseToArea(CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_myMission.Area);
					}
					myUnit.Navigator.FollowPlottedCourse(float_0);
				}
				return;
			}
			CS$<>8__locals49.$VB$Local_LegitTargets = new TList<UnguidedWeapon>();
			CS$<>8__locals49.$VB$Local_MissionArea = CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_myMission.Area;
			CS$<>8__locals49.$VB$Local_WeaponsDic = new Dictionary<string, UnguidedWeapon>();
			int num2 = myUnit.ParentScen.Mines.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (i < myUnit.ParentScen.Mines.Count)
				{
					try
					{
						CS$<>8__locals49.$VB$Local_WeaponsDic.Add(myUnit.ParentScen.Mines[i].ObjectID, myUnit.ParentScen.Mines[i]);
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
				}
			}
			if (method_12().HasMineCountermeasures() || method_12().HasMineCounterWeapons())
			{
				try
				{
					Parallel.ForEach(myUnit.get_UnitSide(SetSideOnly: false).Contacts_NonAU, [SpecialName] (string theUW_ObjectID) =>
					{
						CS$<>8__locals49.$VB$Local_WeaponsDic.TryGetValue(theUW_ObjectID, out var value3);
						if (value3 != null && value3.IsMine)
						{
							if (((Module_Unit.Unit)value3).get_IsInsideThisArea(CS$<>8__locals49.$VB$Local_MissionArea, CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Me.myUnit.ParentScen, UseCache: true))
							{
								CS$<>8__locals49.$VB$Local_LegitTargets.Add(value3);
							}
							else if (CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_myMission.MovementStyle == Mission.MissionMovementStyle.RepeatableLoop && CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Me.myUnit.Navigator.IsInsideMissionArea(ref CS$<>8__locals49.$VB$Local_MissionArea, ref CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_myMission.Area_2nm_Buffered, ref CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_myMission.Area_2nm_ChangeCheck, 2, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
							{
								CS$<>8__locals49.$VB$Local_LegitTargets.Add(value3);
							}
						}
					});
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					ProjectData.ClearProjectError();
				}
			}
			TList<UnguidedWeapon> tList = new TList<UnguidedWeapon>();
			UnguidedWeapon unguidedWeapon = null;
			UnguidedWeapon unguidedWeapon2 = null;
			foreach (UnguidedWeapon item in CS$<>8__locals49.$VB$Local_LegitTargets)
			{
				if (item == null)
				{
					continue;
				}
				float num3 = myUnit.RangeToUnit_Horiz(item);
				if (num3 > num || (double)num3 * 1852.0 < 500.0)
				{
					continue;
				}
				if (item.Mine_Targeted == null)
				{
					tList.Add(item);
					continue;
				}
				if (myUnit.ParentScen.MineAllocation.ContainsKey(item.Mine_Targeted.ObjectID) && !myUnit.ParentScen.MineAllocation.Contains(new KeyValuePair<string, UnguidedWeapon>(item.Mine_Targeted.ObjectID, item)))
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
									float num4 = num3;
									float? num5 = item.Mine_Targeted?.RangeToUnit_Horiz(item);
									bool? flag3;
									bool? flag2 = (flag3 = ((!num5.HasValue) ? ((bool?)null) : new bool?(num4 < num5.GetValueOrDefault())));
									bool? flag4 = ((flag2.HasValue && flag3 != true) ? new bool?(false) : (myUnit.get_CanSweepMine(item) & flag3));
									if ((flag4 ?? true) && !myUnit.ParentScen.MineAllocation.ContainsKey(myUnit.ObjectID) && flag4.HasValue)
									{
									}
									goto IL_0657;
								}
							}
							item.Mine_Targeted = null;
						}
					}
				}
				else if (item.Mine_Targeted != null && item.Mine_Targeted.Equals(myUnit))
				{
					tList.Add(item);
					if (!myUnit.ParentScen.MineAllocation.ContainsKey(myUnit.ObjectID))
					{
						myUnit.ParentScen.MineAllocation.Add(myUnit.ObjectID, item);
					}
				}
				goto IL_0657;
				IL_0657:
				if (item.Mine_Targeted == null)
				{
					tList.Add(item);
				}
			}
			CS$<>8__locals49.$VB$Local_LegitTargets = tList;
			if (CS$<>8__locals49.$VB$Local_LegitTargets.Count > 0)
			{
				while (CS$<>8__locals49.$VB$Local_LegitTargets.Count > 0)
				{
					unguidedWeapon2 = (from theMine in CS$<>8__locals49.$VB$Local_LegitTargets.ToList()
						where theMine != null && myUnit.get_CanSweepMine(theMine)
						orderby Module_Unit.RangeToUnit_Horiz_Angular(myUnit, theMine)
						select theMine).ElementAtOrDefault(0);
					if (unguidedWeapon2 == null || unguidedWeapon2.Mine_Targeted == null || unguidedWeapon2.Mine_Targeted.Equals(myUnit))
					{
						break;
					}
					if (((Module_Unit.Unit)unguidedWeapon2).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < -5f)
					{
						CS$<>8__locals49.$VB$Local_LegitTargets.Remove(unguidedWeapon2);
					}
					else
					{
						CS$<>8__locals49.$VB$Local_LegitTargets.Remove(unguidedWeapon2);
					}
				}
			}
			else
			{
				myUnit.ParentScen.MineAllocation.Remove(myUnit.ObjectID);
			}
			if (unguidedWeapon2 != null && myUnit.Navigator.PlottedCourse.Count() > 0 && myUnit.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.TerminalPoint)
			{
				unguidedWeapon = null;
				myUnit.ParentScen.MineAllocation.TryGetValue(myUnit.ObjectID, ref unguidedWeapon);
				unguidedWeapon2 = null;
			}
			if ((unguidedWeapon2 == null) & (CS$<>8__locals49.$VB$Local_LegitTargets.Count > 0))
			{
				UnguidedWeapon unguidedWeapon4 = (from theMine in CS$<>8__locals49.$VB$Local_LegitTargets.ToList()
					where theMine != null && ((Module_Unit.Unit)theMine).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < -5f
					orderby Module_Unit.RangeToUnit_Horiz_Angular(myUnit, theMine)
					select theMine).ElementAtOrDefault(0);
				if (unguidedWeapon4 != null && ((Aircraft)myUnit).Loadout != null && (unguidedWeapon4.Type == Weapon._WeaponType.BottomMine || unguidedWeapon4.Type == Weapon._WeaponType.RisingMine))
				{
					WeaponRec[] weapons = ((Aircraft)myUnit).Loadout.Weapons;
					for (int num6 = 0; num6 < weapons.Length; num6 = checked(num6 + 1))
					{
						WeaponRec theWeaponRec = weapons[num6];
						if (theWeaponRec.TimeToFire != 0f || theWeaponRec.CurrentLoad <= 0)
						{
							continue;
						}
						Weapon weapon = theWeaponRec.get_ReferenceWeapon(myUnit.ParentScen);
						if (weapon.Type != Weapon._WeaponType.Torpedo || theWeaponRec.CurrentLoad < 1 || !weapon.ValidTargets.Mine || unguidedWeapon4.Mine_Targeted != null)
						{
							continue;
						}
						AimpointContact aimpointContact = new AimpointContact(((Module_Unit.Unit)unguidedWeapon4).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)unguidedWeapon4).get_Longitude((GlobalVariables.BooleanObject)null));
						((Module_Unit.Unit)aimpointContact).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)unguidedWeapon4).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
						if (myUnit.RangeToUnit_Horiz(unguidedWeapon4) >= weapon.MaxSubsurfaceRange / 2f)
						{
							continue;
						}
						ActiveUnit_Weaponry weaponry = myUnit.Weaponry;
						int NumberOfWeaponsFired = 1;
						WeaponSalvo theWeaponSalvo = null;
						List<Module_Unit.Unit> list = weaponry.FireWeapon_Normal(float_0, ref theWeaponRec, aimpointContact, ref NumberOfWeaponsFired, 0, 0f, ActiveUnit.Throttle.Flank, null, SonarModel.PositionRelativeToThermocline.Above, 0L, ref theWeaponSalvo);
						if (list.Count > 0)
						{
							Module_Unit.Unit unit = list.First();
							if (!myUnit.ParentScen.MineAllocation.ContainsKey(unit.ObjectID))
							{
								myUnit.ParentScen.MineAllocation.Add(unit.ObjectID, unguidedWeapon4);
							}
							unguidedWeapon4.Mine_Targeted = (ActiveUnit)unit;
							ActiveUnit obj = (ActiveUnit)unit;
							MineClearingMission value = CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_myMission;
							Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
							obj.Set_AssignedMissionOrPackage(value, SetMissionOnly: true, IgnoreCommsState: true, ref Result);
						}
						break;
					}
				}
			}
			if (unguidedWeapon2 == null)
			{
				if (!myUnit.IsGroupMember())
				{
					if (myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
					{
						if (!myUnit.Navigator.PlottedCourseLeadsToMissionArea(ref CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_myMission.Area, ref CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_myMission.Area_30nm_Buffered, ref CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_myMission.Area_30nm_ChangeCheck, 30f, IgnoreTimeToNextEvaluation: false))
						{
							myUnit.Navigator.PlotCourseToArea(CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_myMission.Area);
						}
						myUnit.Navigator.FollowPlottedCourse(float_0);
						method_12().Navigator.SetPatrolThrottle(PursueContact: false, airOps.Condition);
						method_12().Navigator.SetPatrolAltitude(PursueContact: false, airOps.Condition);
					}
					else
					{
						myUnit.Navigator.PlotCourseToArea(CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_myMission.Area);
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
					if (!myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlottedCourseLeadsToMissionArea(ref CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_myMission.Area, ref CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_myMission.Area_30nm_Buffered, ref CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_myMission.Area_30nm_ChangeCheck, 30f, IgnoreTimeToNextEvaluation: false))
					{
						myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlotCourseToArea(CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_myMission.Area);
					}
					myUnit.Navigator.FollowPlottedCourse(float_0);
				}
				else
				{
					myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlotCourseToArea(CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_myMission.Area);
				}
				return;
			}
			float num7 = myUnit.RangeToUnit_Horiz(unguidedWeapon2);
			if (unguidedWeapon2.Mine_Targeted == null && myUnit.ParentScen.MineAllocation.ContainsKey(myUnit.ObjectID))
			{
				unguidedWeapon = null;
				if (myUnit.ParentScen.MineAllocation.TryGetValue(myUnit.ObjectID, ref unguidedWeapon))
				{
					unguidedWeapon2 = unguidedWeapon;
					num7 = myUnit.RangeToUnit_Horiz(unguidedWeapon2);
				}
				else
				{
					unguidedWeapon.Mine_Targeted = null;
					myUnit.ParentScen.MineAllocation.Remove(myUnit.ObjectID);
					if (myUnit.Navigator.HasPlottedCourse() && myUnit.Navigator.PlottedCourse.Count() > 0 && myUnit.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.TerminalPoint)
					{
						myUnit.Navigator.RemoveWaypoint_Soft(myUnit.Navigator.PlottedCourse[0], RemoveWingmanWaypoints: true);
					}
				}
			}
			else if (unguidedWeapon2.Mine_Targeted != null && unguidedWeapon2.Mine_Targeted.Equals(myUnit) && myUnit.Navigator.HasPlottedCourse() && myUnit.Navigator.PlottedCourse.Count() > 0 && myUnit.Navigator.PlottedCourse[0].Type != Waypoint.WaypointType.TerminalPoint)
			{
				ManouverToSweepMine(unguidedWeapon2, num7, ResetPath: true);
			}
			myUnit.Navigator.FollowPlottedCourse(float_0);
			if (unguidedWeapon2 != null && unguidedWeapon2.Mine_Targeted == null)
			{
				ManouverToSweepMine(unguidedWeapon2, num7, ResetPath: true);
				unguidedWeapon2.Mine_Targeted = myUnit;
				if (myUnit.ParentScen.MineAllocation.ContainsKey(myUnit.ObjectID))
				{
					UnguidedWeapon value2 = null;
					if (!myUnit.ParentScen.MineAllocation.TryGetValue(myUnit.ObjectID, ref value2) || !unguidedWeapon2.Equals(value2))
					{
						myUnit.ParentScen.MineAllocation.Remove(myUnit.ObjectID);
						myUnit.ParentScen.MineAllocation.Add(myUnit.ObjectID, unguidedWeapon2);
					}
				}
				else
				{
					myUnit.ParentScen.MineAllocation.Add(myUnit.ObjectID, unguidedWeapon2);
				}
				if (myUnit.IsOnActiveMineClearingMission && myUnit.ParentScen.MineAllocation.ContainsKey(myUnit.ObjectID))
				{
					myUnit.Navigator.bool_0 = false;
					if (myUnit.Navigator.TimeToNextPathfinderCheck <= 0f && myUnit.Navigator.IsInsideMissionArea(ref CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_myMission.Area, ref CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_myMission.Area_5nm_Buffered, ref CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_myMission.Area_5nm_ChangeCheck, 5, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
					{
						myUnit.Navigator.TimeToNextPathfinderCheck = GameGeneral.GlobalRNG.Next(10, 16);
					}
				}
				myUnit.Navigator.FollowPlottedCourse(float_0);
			}
			else if (unguidedWeapon2 != null && unguidedWeapon2.Mine_Targeted != null && Operators.CompareString(unguidedWeapon2.Mine_Targeted.ObjectID, myUnit.ObjectID, false) == 0)
			{
				if ((double)num7 > 0.6)
				{
					ManouverToSweepMine(unguidedWeapon2, num7, ResetPath: true);
				}
				if (myUnit.Navigator.PlottedCourse.Count() <= 0 || myUnit.Navigator.PlottedCourse[0].Type != Waypoint.WaypointType.TerminalPoint)
				{
					unguidedWeapon2.Mine_Targeted = null;
					myUnit.ParentScen.MineAllocation.Remove(myUnit.ObjectID);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100780", "Full sub ");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_44(CargoMission cargoMission_0)
	{
		switch (cargoMission_0.Type)
		{
		case CargoMission.CargoMissionType.Transfer:
			if (!myUnit.Kinematics.DesiredSpeedOverride.HasValue)
			{
				myUnit.SetThrottle(cargoMission_0.TransitThrottle_Aircraft);
			}
			if (!myUnit.Kinematics.DesiredAltitudeOverride && cargoMission_0.TransitAltitude_Aircraft > 0f)
			{
				myUnit.DesiredAltitude = cargoMission_0.TransitAltitude_Aircraft;
			}
			break;
		case CargoMission.CargoMissionType.Delivery:
			if (!myUnit.Kinematics.DesiredSpeedOverride.HasValue)
			{
				if (myUnit.Navigator.IsInsideMissionArea(ref cargoMission_0.Area, ref cargoMission_0.Area_1nm_Buffered, ref cargoMission_0.Area_1nm_ChangeCheck, 1, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
				{
					myUnit.SetThrottle(cargoMission_0.StationThrottle_Aircraft);
				}
				else
				{
					myUnit.SetThrottle(cargoMission_0.TransitThrottle_Aircraft);
				}
			}
			if (myUnit.Kinematics.DesiredAltitudeOverride)
			{
				break;
			}
			if (!myUnit.Navigator.IsInsideMissionArea(ref cargoMission_0.Area, ref cargoMission_0.Area_1nm_Buffered, ref cargoMission_0.Area_1nm_ChangeCheck, 1, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
			{
				if (cargoMission_0.TransitAltitude_Aircraft > 0f)
				{
					myUnit.DesiredAltitude = cargoMission_0.TransitAltitude_Aircraft;
				}
			}
			else if (cargoMission_0.StationAltitude_Aircraft > 0f)
			{
				myUnit.DesiredAltitude = cargoMission_0.StationAltitude_Aircraft;
			}
			break;
		}
	}

	protected override void Manouver_CargoMission(float elapsedTime)
	{
		_Closure$__105-0 arg = default(_Closure$__105-0);
		_Closure$__105-0 CS$<>8__locals42 = new _Closure$__105-0(arg);
		CS$<>8__locals42.$VB$Me = this;
		CS$<>8__locals42.$VB$Local_myMission = (CargoMission)myUnit.ActiveMissionOrPackage();
		Aircraft aircraft = (Aircraft)myUnit;
		if (CS$<>8__locals42.$VB$Local_myMission.Type == CargoMission.CargoMissionType.Transfer)
		{
			if (!myUnit.IsGroupWingman())
			{
				if (aircraft.AirOps.ActualDestinationHost == null)
				{
					string text = "";
					if (Operators.CompareString(myUnit.Name, myUnit.UnitClass, false) != 0)
					{
						text = " (" + myUnit.UnitClass + ")";
					}
					if (CS$<>8__locals42.$VB$Local_myMission.DestinationUnit != null)
					{
						myUnit.ParentScen.AddMessage("Aircraft " + myUnit.Name + text + " is assigned to a cargo mission but cannot land at " + CS$<>8__locals42.$VB$Local_myMission.DestinationUnit.Name + ". Unassigning aircraft and returning to nearest base.", myUnit.Name + " cannot perform cargo mission; aborting", LoggedMessage.MessageType.AirOps, 0, null, myUnit.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
					}
					else
					{
						myUnit.ParentScen.AddMessage("Aircraft " + myUnit.Name + text + " is assigned to a cargo mission but has no destination set. Unassigning aircraft and returning to nearest base.", myUnit.Name + " cannot perform cargo mission; aborting", LoggedMessage.MessageType.AirOps, 0, null, myUnit.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
					}
					ActiveUnit activeUnit = myUnit;
					Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
					activeUnit.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: false, ref Result);
					if (!GlobalVariables.AI_REWORK)
					{
						aircraft.AirOps.AttemptToRTB(ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB, GroupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, DetachFromGroup: true, ClearPlottedCourse: true);
					}
					else
					{
						aircraft.AI.StatusRelatedEvents.method_0(manuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB, groupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, detachFromGroup: true, clearPlottedCourse: true);
					}
				}
				else
				{
					ReturnToBase(elapsedTime);
					method_44(CS$<>8__locals42.$VB$Local_myMission);
				}
			}
			else
			{
				aircraft.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
			}
			if (aircraft.IsTanker)
			{
				AssistRefuellingClients();
			}
			return;
		}
		if (myUnit.OnboardCargo.Count() == 0)
		{
			if (CS$<>8__locals42.$VB$Local_myMission.RTBUponCompletion)
			{
				if (GlobalVariables.AI_REWORK)
				{
					aircraft.AI.StatusRelatedEvents.method_0(manuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB_MissionOver, groupMembersRTB: true, ActiveUnit._ActiveUnitStatus.RTB_Group, detachFromGroup: true, clearPlottedCourse: true, null, null, [SpecialName] () =>
					{
						ActiveUnit activeUnit4 = CS$<>8__locals42.$VB$Me.myUnit;
						Mission.MissionAssignmentAttemptResult Result2 = Mission.MissionAssignmentAttemptResult.None;
						activeUnit4.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: true, ref Result2);
						CS$<>8__locals42.$VB$Me.myUnit.AddMessage(CS$<>8__locals42.$VB$Me.myUnit.Name + " (" + CS$<>8__locals42.$VB$Me.myUnit.UnitClass + ") is unable to return to base during cargo mission: " + CS$<>8__locals42.$VB$Local_myMission.Name + ". The unit will be removed from the mission.", CS$<>8__locals42.$VB$Me.myUnit.Name + " unable to return to base; removed from mission", LoggedMessage.MessageType.AirOps, 5, new Geopoint_Struct(CS$<>8__locals42.$VB$Me.myUnit.get_Longitude((GlobalVariables.BooleanObject)null), CS$<>8__locals42.$VB$Me.myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
					});
					method_44(CS$<>8__locals42.$VB$Local_myMission);
				}
				else if (aircraft.AirOps.AttemptToRTB(ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB_MissionOver, GroupMembersRTB: true, ActiveUnit._ActiveUnitStatus.RTB_Group, DetachFromGroup: true, ClearPlottedCourse: true))
				{
					method_44(CS$<>8__locals42.$VB$Local_myMission);
				}
				else
				{
					ActiveUnit activeUnit2 = myUnit;
					Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
					activeUnit2.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: true, ref Result);
					myUnit.AddMessage(myUnit.Name + " (" + myUnit.UnitClass + ") is unable to return to base during cargo mission: " + CS$<>8__locals42.$VB$Local_myMission.Name + ". The unit will be removed from the mission.", myUnit.Name + " unable to return to base; removed from mission", LoggedMessage.MessageType.AirOps, 5, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
			}
			else
			{
				ActiveUnit activeUnit3 = myUnit;
				Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
				activeUnit3.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: true, ref Result);
				myUnit.AddMessage(myUnit.Name + " (" + myUnit.UnitClass + ") has completed cargo mission: " + CS$<>8__locals42.$VB$Local_myMission.Name + ". The unit will be removed from the mission.", myUnit.Name + " has completed its cargo mission", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			return;
		}
		if (!myUnit.Navigator.IsInsideMissionArea(ref CS$<>8__locals42.$VB$Local_myMission.Area, ref CS$<>8__locals42.$VB$Local_myMission.Area_1nm_Buffered, ref CS$<>8__locals42.$VB$Local_myMission.Area_1nm_ChangeCheck, 1, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
		{
			if (myUnit.IsGroupMember())
			{
				if (!myUnit.IsGroupLead())
				{
					if (myUnit.CommStuff.IsConnectedToSideNetwork)
					{
						myUnit.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
					}
				}
				else if (myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
				{
					if (!myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlottedCourseLeadsToMissionArea(ref CS$<>8__locals42.$VB$Local_myMission.Area, ref CS$<>8__locals42.$VB$Local_myMission.Area_30nm_Buffered, ref CS$<>8__locals42.$VB$Local_myMission.Area_30nm_ChangeCheck, 30f, IgnoreTimeToNextEvaluation: false))
					{
						myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlotCourseToArea(CS$<>8__locals42.$VB$Local_myMission.Area);
					}
					myUnit.Navigator.FollowPlottedCourse(elapsedTime);
				}
				else
				{
					myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlotCourseToArea(CS$<>8__locals42.$VB$Local_myMission.Area, OvershootDestination: false, Waypoint.WaypointType.DropOffPoint);
				}
			}
			else if (!myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
			{
				if (aircraft.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.TransferringCargo)
				{
					myUnit.Navigator.PlotCourseToArea(CS$<>8__locals42.$VB$Local_myMission.Area, OvershootDestination: false, Waypoint.WaypointType.DropOffPoint);
				}
			}
			else
			{
				if (!myUnit.Navigator.PlottedCourseLeadsToMissionArea(ref CS$<>8__locals42.$VB$Local_myMission.Area, ref CS$<>8__locals42.$VB$Local_myMission.Area_30nm_Buffered, ref CS$<>8__locals42.$VB$Local_myMission.Area_30nm_ChangeCheck, 30f, IgnoreTimeToNextEvaluation: false))
				{
					myUnit.Navigator.PlotCourseToArea(CS$<>8__locals42.$VB$Local_myMission.Area);
				}
				myUnit.Navigator.FollowPlottedCourse(elapsedTime);
			}
			method_44(CS$<>8__locals42.$VB$Local_myMission);
			return;
		}
		if (!Module_Unit.IsOverLand(myUnit) && !Module_Unit.IsOverLand_next(myUnit, elapsedTime))
		{
			int num = 0;
			Geopoint_Struct theLocation;
			do
			{
				num++;
				theLocation = Math2.RandomPointWithinThisArea(CS$<>8__locals42.$VB$Local_myMission.Area);
				if (num > 1000)
				{
					myUnit.AddMessage(myUnit.Name + " is unable to pick a suitable point inside cargo landing area defined by Ref. Points", myUnit.Name + " unable to pick point", LoggedMessage.MessageType.DockingOps, 1, theLocation, ActiveUnit.NotificationType.Bark);
					return;
				}
			}
			while (Terrain.GetElevation(theLocation.Latitude, theLocation.Longitude, RequestIsFromGUI: false, myUnit.ParentScen) <= 0);
			myUnit.Navigator.ClearPlottedCourse();
			myUnit.Navigator.AddWaypoint(theLocation.Latitude, theLocation.Longitude, 0f, Waypoint.WaypointType.PatrolStation, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse);
			myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), theLocation.Latitude, theLocation.Longitude));
			return;
		}
		if (aircraft.Loadout.Cargo_ParadropCapable)
		{
			aircraft.AirOps.UnloadCargoParadrop();
		}
		if (aircraft.OnboardCargo.Count() == 0)
		{
			return;
		}
		if (!aircraft.IsHelicopter)
		{
			if (!GlobalVariables.AI_REWORK)
			{
				aircraft.Status = ActiveUnit._ActiveUnitStatus.RTB_MissionOver;
				myUnit.AddMessage(myUnit.Name + " (" + myUnit.UnitClass + ") was unable to unload all cargo for mission: " + CS$<>8__locals42.$VB$Local_myMission.Name + " (Some onboard cargo could not be air dropped.) The unit will return to base.", myUnit.Name + " unable to unload all cargo; returning to base", LoggedMessage.MessageType.AirOps, 5, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			else
			{
				aircraft.AI.StatusRelatedEvents.method_1(ActiveUnit._ActiveUnitStatus.RTB_MissionOver, [SpecialName] (float _elapsedTime) =>
				{
					CS$<>8__locals42.$VB$Me.myUnit.AddMessage(CS$<>8__locals42.$VB$Me.myUnit.Name + " (" + CS$<>8__locals42.$VB$Me.myUnit.UnitClass + ") was unable to unload all cargo for mission: " + CS$<>8__locals42.$VB$Local_myMission.Name + " (Some onboard cargo could not be air dropped.) The unit will return to base.", CS$<>8__locals42.$VB$Me.myUnit.Name + " unable to unload all cargo; returning to base", LoggedMessage.MessageType.AirOps, 5, new Geopoint_Struct(CS$<>8__locals42.$VB$Me.myUnit.get_Longitude((GlobalVariables.BooleanObject)null), CS$<>8__locals42.$VB$Me.myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				});
			}
		}
		else
		{
			aircraft.AirOps.Condition = Aircraft_AirOps._AirOpsCondition.TransferringCargo;
			aircraft.AirOps.ConditionTimer = Math.Max(120, ActiveUnit_DockingOps.TimeToUnloadCargo(aircraft, aircraft.OnboardCargo.ToList()));
		}
	}

	public bool ContinueStandoffAttackAgainstThisTargetToMeetWRA(Contact theTarget, Weapon ReferenceWeapon, bool RequireFlightPlan = true)
	{
		if (theTarget == null)
		{
			return false;
		}
		if (RequireFlightPlan)
		{
			int result;
			if (method_12().Navigator.HasPlottedCourse())
			{
				if (method_12().Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.WeaponLaunch)
				{
					goto IL_0044;
				}
				result = 0;
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}
		goto IL_0044;
		IL_0044:
		if (ReferenceWeapon == null)
		{
			ReferenceWeapon = myUnit.Weaponry.MostSuitableWeaponForThisTarget(theTarget, CheckIfWithinRange: true, CheckIfWithinAltitude: true, CheckWRA: true, myUnit.Doctrine, excludeChaffsAndCounterMeasures: true, CheckWeaponQuantity: true);
			if (ReferenceWeapon == null)
			{
				return false;
			}
		}
		Weapon theW = ReferenceWeapon;
		GlobalVariables.BooleanObject EmitterClassificable = null;
		Doctrine._WRA_WeaponTargetType theTargetType = Contact.WRA_DetermineTargetType(ref theTarget, theW, ref EmitterClassificable);
		Doctrine._WRA_WeaponTargetType selectedNodeTargetType = Doctrine.WRA_ConvertWeaponTargetTypeToWRA_TargetType(ref ReferenceWeapon, ref theTarget, ref theTargetType, myUnit.get_UnitSide(SetSideOnly: false).ObjectID);
		Doctrine doctrine = myUnit.Doctrine;
		Scenario parentScen = myUnit.ParentScen;
		Weapon theWeapon = ReferenceWeapon;
		int? TargetType_InheritedWeaponQty = null;
		int? TargetType_UnspecifiedWeaponQty = null;
		int? num = Doctrine.WRA_WeaponQty_AnyTargetType(doctrine, parentScen, theWeapon, selectedNodeTargetType, FindInheritedValuesOnly: false, ref TargetType_InheritedWeaponQty, ref TargetType_UnspecifiedWeaponQty);
		TargetType_UnspecifiedWeaponQty = num;
		if (((!TargetType_UnspecifiedWeaponQty.HasValue) ? ((bool?)null) : new bool?(TargetType_UnspecifiedWeaponQty == -99)) != true)
		{
			TargetType_UnspecifiedWeaponQty = num;
			int num2;
			if ((TargetType_UnspecifiedWeaponQty.HasValue ? new bool?(TargetType_UnspecifiedWeaponQty.GetValueOrDefault() < 0) : ((bool?)null)) == true)
			{
				num = myUnit.get_UnitSide(SetSideOnly: false).ConvertSalvoWeaponQty_To_ActualQuantity(num, ref myUnit, ref theTarget, ref ReferenceWeapon);
				num2 = 0;
			}
			else
			{
				num2 = 0;
			}
			int num3 = num2;
			List<WeaponSalvo> list = new List<WeaponSalvo>(myUnit.get_UnitSide(SetSideOnly: false).WeaponSalvos);
			foreach (WeaponSalvo item in list)
			{
				TargetType_UnspecifiedWeaponQty = item?.int_1;
				TargetType_InheritedWeaponQty = ReferenceWeapon?.DBID;
				if (((!(TargetType_UnspecifiedWeaponQty.HasValue & TargetType_InheritedWeaponQty.HasValue)) ? ((bool?)null) : new bool?(TargetType_UnspecifiedWeaponQty.GetValueOrDefault() == TargetType_InheritedWeaponQty.GetValueOrDefault())) == true && Operators.CompareString(item.Target.ActualUnit.ObjectID, theTarget.ActualUnit.ObjectID, false) == 0)
				{
					num3 = item.WpnQuantityAssigned;
				}
			}
			if ((num.HasValue ? new bool?(num3 < num.GetValueOrDefault()) : ((bool?)null)) != true)
			{
				return false;
			}
			return true;
		}
		return true;
	}

	static Aircraft_AI()
	{
		Class72.smethod_20();
	}
}
