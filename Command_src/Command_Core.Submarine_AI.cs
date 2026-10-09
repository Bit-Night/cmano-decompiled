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

public sealed class Submarine_AI : ActiveUnit_AI
{
	[CompilerGenerated]
	internal sealed class _Closure$__47-0
	{
		public List<ReferencePoint> $VB$Local_MissionArea;

		public TList<UnguidedWeapon> $VB$Local_LegitTargets;

		public MineClearingMission $VB$Local_myMission;

		public Submarine_AI $VB$Me;

		public _Closure$__47-0(_Closure$__47-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_MissionArea = arg0.$VB$Local_MissionArea;
				$VB$Local_LegitTargets = arg0.$VB$Local_LegitTargets;
				$VB$Local_myMission = arg0.$VB$Local_myMission;
			}
		}

		[SpecialName]
		internal void _Lambda$__2(string theUW_ObjectID)
		{
			UnguidedWeapon value = null;
			$VB$Me.myUnit.ParentScen.UnguidedWeapons.TryGetValue(theUW_ObjectID, out value);
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

		static _Closure$__47-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__47-1
	{
		public List<ReferencePoint> $VB$Local_MissionArea;

		public Submarine_AI $VB$Me;

		public _Closure$__47-1(_Closure$__47-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_MissionArea = arg0.$VB$Local_MissionArea;
			}
		}

		static _Closure$__47-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__47-2
	{
		public TList<UnguidedWeapon> $VB$Local_LegitTargets;

		public _Closure$__47-1 $VB$NonLocal_$VB$Closure_2;

		public _Closure$__47-2(_Closure$__47-2 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_LegitTargets = arg0.$VB$Local_LegitTargets;
			}
		}

		[SpecialName]
		internal void _Lambda$__5(string theUW_ObjectID)
		{
			UnguidedWeapon value = null;
			$VB$NonLocal_$VB$Closure_2.$VB$Me.myUnit.ParentScen.UnguidedWeapons.TryGetValue(theUW_ObjectID, out value);
			if (!Information.IsNothing((object)value) && value.IsMine && ((Module_Unit.Unit)value).get_IsInsideThisArea($VB$NonLocal_$VB$Closure_2.$VB$Local_MissionArea, $VB$NonLocal_$VB$Closure_2.$VB$Me.myUnit.ParentScen, UseCache: true))
			{
				$VB$Local_LegitTargets.Add(value);
			}
		}

		static _Closure$__47-2()
		{
			Class72.smethod_20();
		}
	}

	private float float_0;

	private SubmarineDepthPreset submarineDepthPreset_0;

	private Submarine submarine_0;

	protected Contact _LastPrimaryThreat;

	private float float_1;

	private HashSet<string> hashSet_0;

	private bool bool_0;

	public override Contact PrimaryThreat
	{
		get
		{
			return _PrimaryThreat;
		}
		set
		{
			if (_PrimaryThreat != value)
			{
				_LastPrimaryThreat = _PrimaryThreat;
			}
			_PrimaryThreat = value;
		}
	}

	public Contact LastPrimaryThreat => _LastPrimaryThreat;

	public SubmarineDepthPreset DepthPreset
	{
		get
		{
			return submarineDepthPreset_0;
		}
		set
		{
			submarineDepthPreset_0 = value;
			if (value != SubmarineDepthPreset.None)
			{
				myUnit.Kinematics.DesiredAltitudeOverride = true;
			}
		}
	}

	[SpecialName]
	private Submarine method_12()
	{
		if (submarine_0 == null)
		{
			submarine_0 = (Submarine)myUnit;
		}
		return submarine_0;
	}

	public Submarine_AI(ref ActiveUnit theUnit)
		: base(theUnit)
	{
		hashSet_0 = new HashSet<string>();
		bool_0 = false;
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
			theWriter.WriteElementString("TTNPTE", XmlConvert.ToString(TimeToNextTargetsEvaluation));
			theWriter.WriteElementString("PTOE", PrimaryTargetOverrideExists.ToString());
			if (!EvaluateTargets_Enabled)
			{
				theWriter.WriteElementString("ET_E", "False");
			}
			if (!DeterminePrimaryTarget_Enabled)
			{
				theWriter.WriteElementString("DPT_E", "False");
			}
			theWriter.WriteElementString("DP", ((byte)DepthPreset).ToString());
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
				foreach (TargetingEntry value in _TargetList.Values)
				{
					if (!Information.IsNothing((object)value.Target.ActualUnit))
					{
						theWriter.WriteRaw(value.ToXML(myUnit.get_UnitSide(SetSideOnly: false)));
					}
				}
				theWriter.WriteEndElement();
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
			if (base.PrimaryPickupTarget != null)
			{
				theWriter.WriteElementString("PrimaryPickupTarget", _PrimaryPickupTarget.ObjectID);
			}
			if (MiningInfo != null)
			{
				MiningInfo.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
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
			ex2?.Data.Add("Error at 100815", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static Submarine_AI FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0443: Unknown result type (might be due to invalid IL or missing references)
		//IL_044a: Expected O, but got Unknown
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Expected O, but got Unknown
		Submarine_AI result;
		try
		{
			Submarine_AI submarine_AI = new Submarine_AI(ref theAU);
			submarine_AI.myUnit = theAU;
			if (Operators.CompareString(theNode.ChildNodes[0].Name, "ActiveUnit_AI", false) == 0)
			{
				theNode = theNode.ChildNodes[0];
			}
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode theNode2 = childNode;
				switch (theNode2.Name)
				{
				case "PrimaryTarget":
					submarine_AI._PrimaryTarget = Contact.FromXML(theNode2.InnerText, ref theDictionary);
					break;
				case "MSF":
					uint.TryParse(theNode2.InnerText, out submarine_AI._Mission_State_Flags);
					break;
				case "Threats":
					if (submarine_AI._Threats == null)
					{
						submarine_AI._Threats = new List<Contact>();
					}
					foreach (XmlNode childNode2 in theNode2.ChildNodes)
					{
						XmlNode theNode3 = childNode2;
						Contact item = Contact.FromXML(ref theNode3, ref theDictionary);
						submarine_AI._Threats.Add(item);
					}
					break;
				case "PrimaryThreat":
					submarine_AI._PrimaryThreat = Contact.FromXML(theNode2.InnerText, ref theDictionary);
					break;
				case "LKTL":
					submarine_AI._LastKnownTargetLocation = GeoPoint.FromXML(ref theNode2, ref theDictionary);
					break;
				case "DPT_E":
					submarine_AI.DeterminePrimaryTarget_Enabled = Misc.ParseBool(theNode2.InnerText);
					break;
				case "DP":
					submarine_AI.DepthPreset = (SubmarineDepthPreset)Conversions.ToByte(theNode2.InnerText);
					break;
				case "TTNPTE":
					submarine_AI.TimeToNextTargetsEvaluation = XmlConvert.ToSingle(theNode2.InnerText.Replace(",", "."));
					break;
				case "IE":
					submarine_AI.IsEscort = true;
					break;
				case "PrimaryTarget_LastKnown_Lat":
					submarine_AI.PrimaryTarget_LastKnown_Lat = XmlConvert.ToDouble(theNode2.InnerText);
					break;
				case "PrimaryTarget_LastKnown_Lon":
					submarine_AI.PrimaryTarget_LastKnown_Lon = XmlConvert.ToDouble(theNode2.InnerText);
					break;
				case "PrimaryPickupTarget":
					submarine_AI._PrimaryPickupTarget = ActiveUnit.FromXML(theNode2.InnerText, ref theDictionary);
					break;
				case "TargetList":
					submarine_AI._TargetList = new ObservableDictionary<string, TargetingEntry>();
					foreach (XmlNode childNode3 in theNode2.ChildNodes)
					{
						XmlNode theNode4 = childNode3;
						TargetingEntry targetingEntry = TargetingEntry.FromXML(ref theNode4, ref theDictionary);
						if (targetingEntry.Target != null && !submarine_AI._TargetList.ContainsKey(targetingEntry.Target.ObjectID))
						{
							submarine_AI._TargetList.Add(targetingEntry.Target.ObjectID, targetingEntry);
						}
					}
					break;
				case "FerryCycleLegIsOutbound":
				case "FCLIO":
					submarine_AI.SetMissionStateFlag(4u, Misc.ParseBool(theNode2.InnerText));
					break;
				case "ET_E":
					submarine_AI.EvaluateTargets_Enabled = Misc.ParseBool(theNode2.InnerText);
					break;
				case "PrimaryTargetOverride":
				case "PrimaryTargetOverrideExists":
				case "PTOE":
					submarine_AI.PrimaryTargetOverrideExists = Misc.ParseBool(theNode2.InnerText);
					break;
				case "PrimaryTarget_LastKnown_Alt":
					submarine_AI.PrimaryTarget_LastKnown_Altitude = XmlConvert.ToSingle(theNode2.InnerText);
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
					submarine_AI.MiningInfo = MiningMission.MiningInformation.FromXML(ref theNode2, ref theDictionary, submarine_AI);
					break;
				}
			}
			result = submarine_AI;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100816", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Submarine_AI(ref theAU);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private bool method_13(int int_0)
	{
		int result;
		if (_Threats == null)
		{
			result = 0;
		}
		else
		{
			if (_Threats.Count != 0)
			{
				foreach (Contact threat in _Threats)
				{
					if (!(method_12().RangeToUnit_Horiz(threat) >= (float)int_0))
					{
						return true;
					}
				}
				return false;
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	public FuelRec._FuelType SelectFuelTypeToConsume(Engine theEngine)
	{
		FuelRec._FuelType result;
		try
		{
			result = ((theEngine == null) ? FuelRec._FuelType.NoFuel : (theEngine.Type switch
			{
				Engine.EngineType.AIP => (myUnit.Propulsion.Where([SpecialName] (Engine theE) => theE.Type == Engine.EngineType.Electric).Count() != 0) ? FuelRec._FuelType.AirIndepedent : FuelRec._FuelType.Battery, 
				Engine.EngineType.Electric => FuelRec._FuelType.Battery, 
				Engine.EngineType.Diesel => FuelRec._FuelType.DieselFuel, 
				_ => FuelRec._FuelType.NoFuel, 
			}));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 321654987245", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num = 1001;
			}
			else
			{
				num = 1001;
			}
			result = (FuelRec._FuelType)num;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public Dictionary<int, Engine> SelectEngines()
	{
		Dictionary<int, Engine> result;
		if (myUnit == null)
		{
			result = new Dictionary<int, Engine>();
		}
		else if (myUnit.Propulsion.Count == 0)
		{
			result = new Dictionary<int, Engine>();
		}
		else
		{
			Dictionary<int, Engine> dictionary = new Dictionary<int, Engine>();
			if (myUnit.Propulsion.Count == 1)
			{
				method_12().PrimaryEngine = myUnit.Propulsion[0];
				method_12().PrimaryEngineNo = 0;
				dictionary.Add(0, myUnit.Propulsion[0]);
				result = dictionary;
			}
			else
			{
				try
				{
					if (Math.Round(method_12().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) >= -20.0)
					{
						if (DecideToSnort())
						{
							if (!Information.IsNothing((object)method_12().Propulsion) && method_12().Propulsion.Count > 0)
							{
								int num = method_12().Propulsion.Count - 1;
								for (int i = 0; i <= num; i++)
								{
									Engine engine = method_12().Propulsion[i];
									if (engine.Status != PlatformComponent._ComponentStatus.Destroyed)
									{
										if (engine.Type == Engine.EngineType.Diesel)
										{
											dictionary.Add(i, engine);
											method_12().PrimaryEngine = engine;
											method_12().PrimaryEngineNo = i;
										}
										if (engine.Type == Engine.EngineType.Electric)
										{
											dictionary.Add(i, engine);
										}
									}
								}
							}
						}
						else if (!Information.IsNothing((object)method_12().Propulsion) && method_12().Propulsion.Count > 0)
						{
							int num2 = method_12().Propulsion.Count - 1;
							for (int j = 0; j <= num2; j++)
							{
								Engine engine = method_12().Propulsion[j];
								if (engine.Status != PlatformComponent._ComponentStatus.Destroyed && engine.Type == Engine.EngineType.Electric)
								{
									dictionary.Add(j, engine);
									method_12().PrimaryEngine = engine;
									method_12().PrimaryEngineNo = j;
									break;
								}
							}
						}
					}
					else
					{
						if (method_12().Propulsion != null && method_12().Propulsion.Count > 0)
						{
							int num3 = method_12().Propulsion.Count - 1;
							for (int k = 0; k <= num3; k++)
							{
								Engine engine = method_12().Propulsion[k];
								if (engine.Status != PlatformComponent._ComponentStatus.Destroyed && engine.Type == Engine.EngineType.Electric)
								{
									dictionary.Add(k, engine);
									method_12().PrimaryEngine = engine;
									method_12().PrimaryEngineNo = k;
									break;
								}
							}
							if (dictionary.Count == 0)
							{
								int num4 = method_12().Propulsion.Count - 1;
								for (int l = 0; l <= num4; l++)
								{
									Engine engine = method_12().Propulsion[l];
									if (engine.Status != PlatformComponent._ComponentStatus.Destroyed && engine.Type == Engine.EngineType.AIP)
									{
										dictionary.Add(l, engine);
										method_12().PrimaryEngine = engine;
										method_12().PrimaryEngineNo = l;
										break;
									}
								}
							}
						}
						if (method_12().IsAIP)
						{
							Doctrine._UseAIP? useAIP = myUnit.Doctrine.get_AIPUsage(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
							byte? b = (byte?)useAIP;
							if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)) != true)
							{
								if (myUnit.Status == ActiveUnit._ActiveUnitStatus.EngagedDefensive || myUnit.Status == ActiveUnit._ActiveUnitStatus.EngagedOffensive)
								{
									b = (byte?)useAIP;
									if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true && !Information.IsNothing((object)method_12().Propulsion) && method_12().Propulsion.Count > 0)
									{
										int num5 = method_12().Propulsion.Count - 1;
										for (int m = 0; m <= num5; m++)
										{
											Engine engine = method_12().Propulsion[m];
											if (engine.Status != PlatformComponent._ComponentStatus.Destroyed && engine.Type == Engine.EngineType.AIP && dictionary.Where([SpecialName] (KeyValuePair<int, Engine> theKVP) => theKVP.Value.Type == Engine.EngineType.AIP).Count() == 0)
											{
												dictionary.Add(m, engine);
												break;
											}
										}
									}
								}
							}
							else if (!Information.IsNothing((object)method_12().Propulsion) && method_12().Propulsion.Count > 0)
							{
								int num6 = method_12().Propulsion.Count - 1;
								for (int num7 = 0; num7 <= num6; num7++)
								{
									Engine engine = method_12().Propulsion[num7];
									if (engine.Status != PlatformComponent._ComponentStatus.Destroyed && engine.Type == Engine.EngineType.AIP)
									{
										dictionary.Add(num7, engine);
										break;
									}
								}
							}
						}
					}
					result = dictionary;
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
					result = new Dictionary<int, Engine>();
					ProjectData.ClearProjectError();
				}
			}
		}
		return result;
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
				if (_PrimaryThreat == null)
				{
					if (myUnit.Status == ActiveUnit._ActiveUnitStatus.EngagedDefensive)
					{
						myUnit.Status = myUnit._StatusBefore_EngagedDefensive;
					}
				}
				else if (_PrimaryThreat.Type == Contact_Base.ContactType.Torpedo)
				{
					if (myUnit.RangeToUnit_Horiz(_PrimaryThreat) < 3f)
					{
						myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedDefensive;
						return;
					}
					if (myUnit.RangeToUnit_Horiz(_PrimaryThreat) < 10f && AngleOffContactsBoresight(ref _PrimaryThreat, GlobalVariables.ObjectTrue) < 90f)
					{
						myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedDefensive;
						return;
					}
				}
				else
				{
					Submarine._SubmarineType type = method_12().Type;
					if ((uint)(type - 2004) <= 1u && method_12().RangeToUnit_Horiz(_PrimaryThreat) < 30f)
					{
						myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedDefensive;
						return;
					}
				}
			}
			if (myUnit.Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint || myUnit.Status == ActiveUnit._ActiveUnitStatus.Refuelling)
			{
				return;
			}
			if (myUnit.CommStuff.HasBeenSummonedToReestablishComms)
			{
				myUnit.Status = ActiveUnit._ActiveUnitStatus.AttemptingToReestablishComms;
				return;
			}
			ActiveUnit theUnit = myUnit;
			Exception ThrownError = null;
			bool flag;
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
				if (myUnit.ParentScen.FifteenthSecondIsChangingOnThisPulse && !myUnit.IsRTB && CheckForWithdrawalCriteria())
				{
					myUnit.Navigator.ResetTimeToNextPathfinderCheck();
					return;
				}
				if (myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
				{
					if (Information.IsNothing((object)PrimaryTarget))
					{
						myUnit.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
						return;
					}
					b = (byte?)myUnit.Doctrine.get_IgnorePlottedCourse(myUnit.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false);
					if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) == true)
					{
						myUnit.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
						return;
					}
				}
				if (PrimaryTarget != null)
				{
					Contact_Base.ContactType type2 = PrimaryTarget.Type;
					if (type2 > Contact_Base.ContactType.Missile)
					{
						flag = true;
						Mission mission = myUnit.ActiveMissionOrPackage();
						if (mission != null && mission.MissionClass == Mission._MissionClass.Strike)
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
										goto IL_0545;
									}
									num2 = 0;
								}
								flag = (byte)num2 != 0;
							}
						}
						goto IL_0545;
					}
				}
				goto IL_055a;
			}
			myUnit.Status = ActiveUnit._ActiveUnitStatus.WaitForPathfinder;
			return;
			IL_055a:
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
						if (!Information.IsNothing((object)PrimaryTarget))
						{
							myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
						}
						else
						{
							myUnit.Status = ActiveUnit._ActiveUnitStatus.OnPatrol;
						}
						return;
					case Mission._MissionClass.Support:
						if (Information.IsNothing((object)PrimaryTarget))
						{
							myUnit.Status = ActiveUnit._ActiveUnitStatus.OnSupportMission;
						}
						else
						{
							myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
						}
						return;
					case Mission._MissionClass.Ferry:
						if (Information.IsNothing((object)PrimaryTarget))
						{
							myUnit.Status = ActiveUnit._ActiveUnitStatus.OnFerryMission;
						}
						else
						{
							myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
						}
						return;
					case Mission._MissionClass.Mining:
						myUnit.Status = ActiveUnit._ActiveUnitStatus.Tasked;
						return;
					case Mission._MissionClass.MineClearing:
						myUnit.Status = ActiveUnit._ActiveUnitStatus.Tasked;
						return;
					}
				}
				else
				{
					myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
				}
			}
			if (myUnit.Status != ActiveUnit._ActiveUnitStatus.RTB_MissionOver && myUnit.FuelState != ActiveUnit._ActiveUnitFuelState.IgnoreBingoAndJoker && myUnit.WeaponState != ActiveUnit._ActiveUnitWeaponState.IgnoreWinchesterAndShotgun && myUnit.Status != ActiveUnit._ActiveUnitStatus.Unassigned)
			{
				myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
			}
			return;
			IL_0545:
			if (flag)
			{
				myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
				return;
			}
			goto IL_055a;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200347", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override bool CanInterceptTargetAtCurrentAltSpeed(double TargetLat, double TargetLon, float TargetHeading, float TargetSpeed, float theAltitude, float OwnSpeed, float OwnHeading, float? SafetyMargin, bool IgnoreMotionVectors, bool AddTarget)
	{
		bool result;
		try
		{
			if (Information.IsNothing((object)SafetyMargin))
			{
				SafetyMargin = 0.1f;
			}
			float num = Module_Unit.RangeToPoint_Horiz(myUnit, TargetLat, TargetLon);
			float num2;
			if (!float.IsNaN(num))
			{
				if (IgnoreMotionVectors)
				{
					num2 = OwnSpeed;
					int num3;
					if (!(OwnSpeed <= 0f))
					{
						if (!double.IsNaN(OwnSpeed))
						{
							goto IL_00c1;
						}
						num3 = 0;
					}
					else
					{
						num3 = 0;
					}
					result = (byte)num3 != 0;
				}
				else
				{
					if (!AddTarget)
					{
						float ownHeading = Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), TargetLat, TargetLon);
						num2 = Module_Unit.ClosureSpeed(myUnit, TargetLat, TargetLon, TargetHeading, TargetSpeed, OwnSpeed, ownHeading);
					}
					else
					{
						num2 = Module_Unit.ClosureSpeed(myUnit, TargetLat, TargetLon, TargetHeading, TargetSpeed, OwnSpeed, OwnHeading);
					}
					if (!(num2 <= 0f) && !double.IsNaN(num2))
					{
						goto IL_00c1;
					}
					result = false;
				}
			}
			else
			{
				result = true;
			}
			goto end_IL_0001;
			IL_00c1:
			long num4 = (long)Math.Round(num / num2 * 3600f);
			float? num5 = (float)method_12().Kinematics.RemainingEndurance(OwnSpeed, theAltitude, TotalRemainingEndurance: true, MissionFuelEndurance: false) * (1f + SafetyMargin);
			float num6 = num4;
			result = ((((!num5.HasValue) ? ((bool?)null) : new bool?(num5.GetValueOrDefault() > num6)) == true) ? true : false);
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100047", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num7;
			if (!Debugger.IsAttached)
			{
				num7 = 0;
			}
			else
			{
				Debugger.Break();
				num7 = 0;
			}
			result = (byte)num7 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private Weapon[] method_14()
	{
		return myUnit.Weaponry.AllDistinctWeaponsAboard_Actual().ToArray();
	}

	public override void EvaluateTargets(float elapsedTime, bool IgnoreContacStance, bool Immediately)
	{
		if (!EvaluateTargets_Enabled)
		{
			return;
		}
		try
		{
			if (myUnit == null || (myUnit.IsDrone() && myUnit.AutonomyLevel < ActiveUnit.DroneAutonomyLevel.BattlespaceCognizant && myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DroneAutonomyLevels) && !myUnit.CommStuff.IsConnectedToSideNetwork) || method_12().IsBiological || method_12().IsFalseTarget)
			{
				return;
			}
			Contact current = default(Contact);
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
			list.AddRange(method_14());
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
			if (mission != null && mission.IsActive && count > 0)
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
					Misc.PostureStance contactsStance_Cache = GetContactsStance_Cache(current, j);
					Contact theContact = current;
					Doctrine._UseShootTourists? canShootTourists = useShootTourists;
					Misc.PostureStance? contactStance = contactsStance_Cache;
					string Feedback = "";
					int FeedbackSeverity = 0;
					if (!ContactIsRelevantToFlightOrMission(theContact, mission, canShootTourists, IgnoreContacStance, isInsidePatrolArea_10nmBuffer, IgnoreNeutralContacts: true, contactStance, ref Feedback, ref FeedbackSeverity))
					{
						continue;
					}
					switch (contactsStance_Cache)
					{
					case Misc.PostureStance.Unfriendly:
					case Misc.PostureStance.Hostile:
					{
						if (IsContactTooAmbiguousForEvaluation(current))
						{
							break;
						}
						ActiveUnit_Weaponry weaponry = myUnit.Weaponry;
						Contact theTarget = current;
						Doctrine doctrine = myUnit.Doctrine;
						Feedback = null;
						FeedbackSeverity = 0;
						if (!weaponry.HaveAvailableWeaponSuitableForThisTarget(theTarget, CheckWRA: true, doctrine, ref Feedback, ref FeedbackSeverity, HumanFeedBackNeeded: false, list) || (current.Type == Contact_Base.ContactType.Submarine && current.IsClassifiedFalseTarget))
						{
							break;
						}
						if (current.HeadingIsKnown && current.SpeedIsKnown && current.CurrentSpeed > 0f && myUnit.CurrentSpeed > 0f)
						{
							if (CanCatchUpWithTarget(current, AddTarget: true))
							{
								TargetThisContact(current, AddedManually: false, PriorityTarget: false, TargetingEntry._TargetingBehavior.AutoTargeted);
								hashSet_0.Add(current.ObjectID);
							}
						}
						else
						{
							TargetThisContact(current, AddedManually: false, PriorityTarget: false, TargetingEntry._TargetingBehavior.AutoTargeted);
							hashSet_0.Add(current.ObjectID);
						}
						break;
					}
					case Misc.PostureStance.Unknown:
						if (current.HeadingIsKnown && current.SpeedIsKnown && current.CurrentSpeed > 0f && myUnit.CurrentSpeed > 0f)
						{
							if (CanCatchUpWithTarget(current, AddTarget: true))
							{
								TargetThisContact(current, AddedManually: false, PriorityTarget: false, TargetingEntry._TargetingBehavior.AutoTargeted);
								hashSet_0.Add(current.ObjectID);
							}
						}
						else
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
					if (patrol.get_InvestigateWithinWeaponRange(myUnit.ParentScen))
					{
						longestWeapon_ASuW = myUnit.Weaponry.GetLongestRange_ASWeapon(ExcludeICBMs: false, current);
						longestWeapon_AG = myUnit.Weaponry.GetLongestRange_AGWeapon(ExcludeICBMs: false, current);
					}
					else
					{
						longestWeapon_ASuW = null;
						longestWeapon_AG = null;
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
			if (count > 0)
			{
				int FeedbackSeverity = count - 1;
				for (int l = 0; l <= FeedbackSeverity; l++)
				{
					current = theContactsVisibleToMe[l];
					if (_DoNotTargetList.Contains(current) || hashSet_0.Contains(current.ObjectID))
					{
						continue;
					}
					Misc.PostureStance contactsStance_Cache = GetContactsStance_Cache(current, l);
					if (contactsStance_Cache == Misc.PostureStance.Neutral || contactsStance_Cache == Misc.PostureStance.Friendly)
					{
						continue;
					}
					byte? b = (byte?)current.BDA_StructuralIntegrity;
					if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 4)) == true)
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
					if (myUnit.Weaponry.ContactIsWithinSelfDefenceRange(current))
					{
						_SelfDefenceTargets.Add(current);
					}
					if (!CanCatchUpWithTarget(current, AddTarget: true))
					{
						continue;
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
			}
			foreach (Contact selfDefenceTarget in _SelfDefenceTargets)
			{
				if (!hashSet_0.Contains(selfDefenceTarget.ObjectID) && !_DoNotTargetList.Contains(selfDefenceTarget))
				{
					TargetThisContact(selfDefenceTarget, AddedManually: false, PriorityTarget: false, TargetingEntry._TargetingBehavior.AutoSelfDefence);
					hashSet_0.Add(current.ObjectID);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100815", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void ManouverTowardsTarget(float elapsedTime)
	{
		bool flag = false;
		if (IsClearedToEngageThisTarget(PrimaryTarget, setStatus: false))
		{
			byte? b = (byte?)myUnit.Doctrine.get_MaintainStandoff(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
			{
				flag = MaintainStandoff(elapsedTime);
			}
		}
		if (!flag)
		{
			base.ManouverTowardsTarget(elapsedTime);
		}
	}

	private bool method_15(Geopoint_Struct geopoint_Struct_0, CargoMission cargoMission_0)
	{
		return myUnit.DockingOps.CargoUnloadLocationPointQuery(geopoint_Struct_0, cargoMission_0)?.Any() ?? false;
	}

	protected override void Manouver_CargoMission(float elapsedTime)
	{
		CargoMission cargoMission = (CargoMission)myUnit.ActiveMissionOrPackage();
		bool flag = true;
		if (myUnit.OnboardCargo.Count() == 0)
		{
			if (cargoMission.RTBUponCompletion)
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
					ActiveUnit activeUnit = myUnit;
					Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
					activeUnit.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: true, ref Result);
					myUnit.AddMessage(myUnit.Name + " (" + myUnit.UnitClass + ") is unable to return to base during cargo mission: " + cargoMission.Name + ". The unit will be removed from the mission.", myUnit.Name + " unable to return to base; removed from mission", LoggedMessage.MessageType.DockingOps, 5, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
			}
			else
			{
				ActiveUnit activeUnit2 = myUnit;
				Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
				activeUnit2.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: true, ref Result);
				myUnit.AddMessage(myUnit.Name + " (" + myUnit.UnitClass + ") has completed cargo mission: " + cargoMission.Name + ". The unit will be removed from the mission.", myUnit.Name + " has completed its cargo mission", LoggedMessage.MessageType.DockingOps, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			return;
		}
		if (cargoMission.Type == CargoMission.CargoMissionType.Transfer)
		{
			if (!myUnit.IsGroupWingman())
			{
				if (myUnit.DockingOps.ActualDestinationHost != null)
				{
					ReturnToBase(elapsedTime);
				}
				else
				{
					myUnit.ParentScen.AddMessage("Unit " + myUnit.Name + " is assigned to a cargo mission but cannot dock at current destination. Unassigning unit and attempting to returning to base.", myUnit.Name + " cannot perform cargo mission; aborting", LoggedMessage.MessageType.DockingOps, 0, null, myUnit.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
					ActiveUnit activeUnit3 = myUnit;
					Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
					activeUnit3.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: false, ref Result);
					myUnit.DockingOps.AttemptToRTB(ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB, GroupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, DetachFromGroup: true, ClearPlottedCourse: true);
				}
				if (!myUnit.Kinematics.DesiredSpeedOverride.HasValue && flag)
				{
					myUnit.SetThrottle(cargoMission.TransitThrottle_Ship);
				}
			}
			else
			{
				myUnit.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
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
			if (!method_15(new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)), cargoMission))
			{
				Geopoint_Struct geopoint_Struct = myUnit.DockingOps.FindCoastalUnloadPointForSeaVesselCargoDelivery(cargoMission);
				if (!geopoint_Struct.HasZeroCoords)
				{
					myUnit.Navigator.ClearPlottedCourse();
					myUnit.Navigator.AddWaypoint(geopoint_Struct.Latitude, geopoint_Struct.Longitude, 0f, Waypoint.WaypointType.DropOffPoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse, _Overshoot: false);
					myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), geopoint_Struct.Latitude, geopoint_Struct.Longitude));
				}
				return;
			}
			float num = method_12().DesiredAltitude;
			List<Cargo> list = new List<Cargo>();
			Cargo[] onboardCargo = myUnit.OnboardCargo;
			foreach (Cargo cargo in onboardCargo)
			{
				if (cargo.InternalObjectType == Cargo.CargoObjectType.Vehicle)
				{
					Vehicle vehicle = (Vehicle)cargo.CargoObjectActiveUnit;
					if (!vehicle.IsAmphibiousSeaworthy)
					{
						continue;
					}
					foreach (Engine item in vehicle.Propulsion)
					{
						if (!item.CanBeUsedOnWater())
						{
							continue;
						}
						AltBand[] altBands = item.AltBands;
						foreach (AltBand altBand in altBands)
						{
							if (altBand.MinAlt > num)
							{
								num = altBand.MinAlt;
							}
						}
					}
					list.Add(cargo);
				}
				else if (cargo.InternalObjectType == Cargo.CargoObjectType.Facility && ((Facility)cargo.CargoObjectActiveUnit).MobileUnitCategory() == IMobileGroundUnit._MobileUnitCategory.Special_Forces && num < -20f)
				{
					num = -20f;
					list.Add(cargo);
				}
			}
			if (list.Count == 0)
			{
				list = myUnit.OnboardCargo.ToList();
				num = 0f;
			}
			if (method_12().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < num)
			{
				method_12().DesiredAltitude = num;
				method_12().DesiredSpeed = 0f;
			}
			else
			{
				myUnit.CargoTransferList = list;
				myUnit.DockingOps.SettleForCargoTransfer();
			}
			return;
		}
		if (!myUnit.IsGroupMember())
		{
			if (myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
			{
				if (!myUnit.Navigator.PlottedCourseLeadsToMissionArea(ref cargoMission.Area, ref cargoMission.Area_30nm_Buffered, ref cargoMission.Area_30nm_ChangeCheck, 30f, IgnoreTimeToNextEvaluation: false))
				{
					myUnit.Navigator.PlotCourseToArea(cargoMission.Area);
				}
				myUnit.Navigator.FollowPlottedCourse(elapsedTime);
			}
			else if (myUnit.DockingOps.Condition != ActiveUnit_DockingOps._DockingOpsCondition.TransferringCargo)
			{
				myUnit.Navigator.PlotCourseToArea(cargoMission.Area, OvershootDestination: false, Waypoint.WaypointType.DropOffPoint);
			}
		}
		else if (!myUnit.IsGroupLead())
		{
			if (myUnit.CommStuff.IsConnectedToSideNetwork)
			{
				myUnit.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
				flag = false;
			}
		}
		else if (!myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
		{
			myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlotCourseToArea(cargoMission.Area);
		}
		else
		{
			if (!myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlottedCourseLeadsToMissionArea(ref cargoMission.Area, ref cargoMission.Area_30nm_Buffered, ref cargoMission.Area_30nm_ChangeCheck, 30f, IgnoreTimeToNextEvaluation: false))
			{
				myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlotCourseToArea(cargoMission.Area);
			}
			myUnit.Navigator.FollowPlottedCourse(elapsedTime);
		}
		if (myUnit.Navigator.HasPlottedCourse() && !myUnit.Kinematics.DesiredSpeedOverride.HasValue && flag)
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

	internal bool MaintainStandoff(float elapsedTime)
	{
		bool result;
		try
		{
			bool_0 = false;
			int num;
			Weapon weapon;
			Geopoint_Struct geopoint_Struct;
			if (PrimaryTarget != null)
			{
				if (PrimaryTarget.Type == Contact_Base.ContactType.Air)
				{
					num = 0;
					goto IL_0032;
				}
				if (PrimaryTarget.Type == Contact_Base.ContactType.Missile)
				{
					num = 0;
					goto IL_0032;
				}
				Doctrine doctrine = myUnit.Doctrine;
				weapon = myUnit.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, CheckIfWithinRange: true, CheckIfWithinAltitude: true, CheckWRA: true, doctrine, excludeChaffsAndCounterMeasures: false, CheckWeaponQuantity: true);
				if (!Information.IsNothing((object)weapon))
				{
					float num2 = weapon.get_MaxRangeForThisTarget(myUnit, PrimaryTarget, CheckWRA: true, doctrine, ManualFire: false);
					if (PrimaryTarget != null)
					{
						float? num3 = PrimaryTarget.MaxPotentialWeaponRange_ASuW_Naval();
						float num4 = ((!num3.HasValue) ? 0f : num3.Value);
						if (num4 >= num2)
						{
							result = false;
						}
						else
						{
							float num5 = num4 + (num2 - num4) / 4f;
							geopoint_Struct = default(Geopoint_Struct);
							Geodesic_EdWilliams.CalcPoint_Williams(((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ref geopoint_Struct.Longitude, ref geopoint_Struct.Latitude, num5, Math2.CalcAzimuth(((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null)));
							if (!(Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null)) > num5))
							{
								goto IL_0218;
							}
							byte? b = (byte?)myUnit.Doctrine.get_IgnorePlottedCourse(myUnit.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false);
							bool? flag = ((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0));
							if (((!flag) ?? flag) != true)
							{
								goto IL_0218;
							}
							result = true;
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
			else
			{
				result = false;
			}
			goto end_IL_0001;
			IL_0218:
			int num6;
			if (Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), geopoint_Struct.Latitude, geopoint_Struct.Longitude) > 1f)
			{
				myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), geopoint_Struct.Latitude, geopoint_Struct.Longitude));
				num6 = 1;
			}
			else
			{
				if (myUnit.IsSubmarine && weapon.IsMissile)
				{
					((Submarine)myUnit).DesiredAltitude = -20f;
				}
				myUnit.DesiredSpeed = 0f;
				myUnit.SetThrottle(ActiveUnit.Throttle.FullStop, 0f);
				ActiveUnit_Navigator navigator = myUnit.Navigator;
				Waypoint[] theArray = navigator.PlottedCourse;
				ArrayExtensions.Clear(ref theArray);
				navigator.PlottedCourse = theArray;
				bool_0 = true;
				num6 = 1;
			}
			result = (byte)num6 != 0;
			goto end_IL_0001;
			IL_0032:
			result = (byte)num != 0;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100781", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num7;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num7 = 0;
			}
			else
			{
				num7 = 0;
			}
			result = (byte)num7 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal void CalculateDesiredPitch_NoTargetPoint()
	{
		if (method_12().DesiredAltitude > method_12().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))
		{
			if (method_12().DesiredAltitude > method_12().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + 150f)
			{
				method_12().DesiredPitch = 30f;
			}
			else
			{
				method_12().DesiredPitch = (method_12().DesiredAltitude - method_12().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) / 5f;
			}
		}
		else if (method_12().DesiredAltitude < method_12().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))
		{
			if (method_12().DesiredAltitude < method_12().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - 150f)
			{
				method_12().DesiredPitch = -30f;
			}
			else
			{
				method_12().DesiredPitch = (method_12().DesiredAltitude - method_12().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) / 5f;
			}
		}
		else
		{
			method_12().DesiredPitch = 0f;
		}
	}

	private float method_16(Contact contact_5)
	{
		float num = method_12().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
		if (contact_5.AltitudeIsKnown)
		{
			num = ((Module_Unit.Unit)contact_5).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
		}
		if (Math.Abs(num - method_12().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) > 20f)
		{
			return method_12().DesiredAltitude;
		}
		float num2 = method_12().Kinematics.GetMinimumAltitude();
		float num3 = ((Module_Unit.Unit)method_12()).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, myUnit.ParentScen);
		if (num2 < num3)
		{
			num2 = num3;
		}
		float num4 = Math.Abs(method_12().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - num2);
		float num5 = Math.Abs(method_12().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - -20f);
		if (method_12().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > num)
		{
			num4 /= 4f;
		}
		else
		{
			num5 /= 4f;
		}
		if (num5 > num4)
		{
			return -19f;
		}
		return num2;
	}

	public override void ManoueverTorpedoEvasion(float elapsedTime, Contact TorpedoThreat)
	{
		if (TorpedoThreat == null)
		{
			return;
		}
		float num = Module_Unit.RangeToPoint_Horiz(method_12(), ((Module_Unit.Unit)TorpedoThreat).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)TorpedoThreat).get_Longitude((GlobalVariables.BooleanObject)null));
		Weapon theW = method_12().Weaponry.MostSuitableWeaponForThisTarget(TorpedoThreat, CheckIfWithinRange: true, CheckIfWithinAltitude: true, CheckWRA: true, myUnit.Doctrine);
		if (theW != null && theW.Type != Weapon._WeaponType.Decoy_Expendable && theW.Type != Weapon._WeaponType.Decoy_Towed && IsClearedToEngageThisTarget(TorpedoThreat) && num <= theW.get_MaxRangeForThisTarget((ActiveUnit)method_12(), TorpedoThreat, CheckWRA: true, method_12().Doctrine, ManualFire: false))
		{
			method_12().SetThrottle(ActiveUnit.Throttle.Flank);
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
		float num2 = (float)Math.Round(Math2.CalcAzimuth(((ActiveUnit)method_12()).get_Latitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)method_12()).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)TorpedoThreat).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)TorpedoThreat).get_Longitude((GlobalVariables.BooleanObject)null)), 0);
		Submarine observerUnit = method_12();
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
			if (TorpedoThreat.HeadingIsKnown)
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
			else
			{
				num4 = Math2.NormalizeBearing(num2 + 180f);
				flag2 = true;
			}
			goto IL_026d;
		}
		float num7 = 20f;
		float num8 = 20f;
		if (TorpedoThreat.SpeedIsKnown)
		{
			num7 = TorpedoThreat.CurrentSpeed;
			num8 = method_12().Kinematics.GetMaximumSpeed();
		}
		if (num8 >= num7)
		{
			float num9 = Math.Abs(Math2.NormalizeBearing(num2 + 180f) - method_12().CurrentHeading);
			if (num9 > 180f)
			{
				num9 = 360f - num9;
			}
			if (num9 < 1f || num9 / method_12().Kinematics.TurnRate() < num / (num7 / 3600f))
			{
				int ThreatBearing = (int)Math.Round(num2);
				OutrunThreat(ref ThreatBearing);
				method_12().SetThrottle(ActiveUnit.Throttle.Flank);
				method_12().DesiredAltitude = myUnit.Kinematics.GetMinimumAltitude();
				return;
			}
		}
		float num10 = Math.Abs(num3);
		EvasionManeuver = new PersistentManeuver(method_12(), TorpedoThreat, num);
		EvasionManeuver.DesiredThrottle = ActiveUnit.Throttle.Flank;
		EvasionManeuver.DesiredAltitude = method_16(TorpedoThreat);
		if (num > ActiveUnit_AI.TorpedoEvasionEmergencyRange)
		{
			if (num3 < 0f)
			{
				EvasionManeuver.DesiredHeading = Math2.NormalizeBearing(num2 - 135f);
				EvasionManeuver.Direction = PersistentManeuver.TurnDirection.Right;
			}
			else
			{
				EvasionManeuver.DesiredHeading = Math2.NormalizeBearing(num2 - 225f);
				EvasionManeuver.Direction = PersistentManeuver.TurnDirection.Left;
			}
		}
		else if (num10 < 60f)
		{
			if (num3 < 0f)
			{
				EvasionManeuver.DesiredHeading = Math2.NormalizeBearing(method_12().CurrentHeading - 90f);
				EvasionManeuver.Direction = PersistentManeuver.TurnDirection.Left;
			}
			else
			{
				EvasionManeuver.DesiredHeading = Math2.NormalizeBearing(method_12().CurrentHeading + 90f);
				EvasionManeuver.Direction = PersistentManeuver.TurnDirection.Right;
			}
		}
		else if (num3 < 0f)
		{
			EvasionManeuver.DesiredHeading = Math2.NormalizeBearing(method_12().CurrentHeading + 90f);
			EvasionManeuver.Direction = PersistentManeuver.TurnDirection.Right;
		}
		else
		{
			EvasionManeuver.DesiredHeading = Math2.NormalizeBearing(method_12().CurrentHeading - 90f);
			EvasionManeuver.Direction = PersistentManeuver.TurnDirection.Left;
		}
		return;
		IL_026d:
		if (!flag2)
		{
			return;
		}
		EvasionManeuver = new PersistentManeuver(method_12(), TorpedoThreat, num);
		EvasionManeuver.DesiredAltitude = method_12().DesiredAltitude;
		if (method_12().Weaponry.IsGuidingWireTorpedoes)
		{
			EvasionManeuver.DesiredThrottle = method_12().Kinematics.GetThrottleSuitableForThisSpeed(method_12().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), Submarine.MaxTorpedoWireSpeed);
		}
		else
		{
			EvasionManeuver.DesiredThrottle = ActiveUnit.Throttle.Flank;
		}
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
		if (myUnit == null || PrimaryThreat == null)
		{
			return;
		}
		try
		{
			float num = (float)Math.Round(Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryThreat).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryThreat).get_Longitude((GlobalVariables.BooleanObject)null)), 0);
			if (float.IsNegativeInfinity(num))
			{
				return;
			}
			switch (PrimaryThreat.Type)
			{
			case Contact_Base.ContactType.Surface:
			case Contact_Base.ContactType.Submarine:
			{
				if (!Information.IsNothing((object)LastPrimaryThreat) && (double)Math.Abs(LastPrimaryThreat.RangeToUnit_Horiz(myUnit) - PrimaryThreat.RangeToUnit_Horiz(myUnit)) < 0.5)
				{
					float num2 = (float)Math.Round(Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)LastPrimaryThreat).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)LastPrimaryThreat).get_Longitude((GlobalVariables.BooleanObject)null)), 0);
					double x = Math.Cos(0.0174532925199433 * (double)num) + Math.Cos(0.0174532925199433 * (double)num2);
					double y = Math.Sin(0.0174532925199433 * (double)num) + Math.Sin(0.0174532925199433 * (double)num2);
					num = (float)(57.2957795130823 * Math.Atan2(y, x));
				}
				int ThreatBearing = (int)Math.Round(num);
				OutrunThreat(ref ThreatBearing);
				if (PrimaryThreat.SpeedIsKnown && method_12().IsNuke)
				{
					method_12().DesiredSpeed = PrimaryThreat.CurrentSpeed;
					method_12().SetThrottle(method_12().Kinematics.GetThrottleSuitableForThisSpeed(method_12().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), method_12().DesiredSpeed), method_12().DesiredSpeed);
				}
				else
				{
					method_12().SetThrottle(ActiveUnit.Throttle.Loiter);
				}
				break;
			}
			case Contact_Base.ContactType.Torpedo:
				ManoueverTorpedoEvasion(elapsedTime, PrimaryThreat);
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100816", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void DeterminePrimaryThreat(float elapsedTime)
	{
		try
		{
			if (myUnit == null)
			{
				return;
			}
			if (_Threats != null && _Threats.Count != 0)
			{
				Platform platform = (Platform)myUnit;
				if (platform.Crew == 0 && !platform.CommStuff.IsConnectedToSideNetwork)
				{
					ActiveUnit.DroneAutonomyLevel autonomyLevel = platform.AutonomyLevel;
					if (autonomyLevel == ActiveUnit.DroneAutonomyLevel.RemotelyPiloted || autonomyLevel == ActiveUnit.DroneAutonomyLevel.SelfRecovering)
					{
						return;
					}
				}
				IEnumerable<Contact> source = from theC in _Threats
					where ((theC == null) ? new bool?(false) : theC.ActualUnit?.IsWeapon) == true
					select (theC) into theC
					orderby Module_Unit.RangeToUnit_Horiz_Angular(myUnit, theC)
					select theC;
				if (source.Count() <= 0)
				{
					IEnumerable<Contact> source2 = from theC in _Threats
						where theC != null
						select (theC) into theC
						orderby Module_Unit.RangeToUnit_Horiz_Angular(myUnit, theC)
						select theC;
					PrimaryThreat = source2.ElementAtOrDefault(0);
				}
				else
				{
					PrimaryThreat = source.ElementAtOrDefault(0);
				}
			}
			else
			{
				PrimaryThreat = null;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100817", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void EvaluateThreats(float elapsedTime)
	{
		if (myUnit == null || method_12().IsBiological || method_12().IsFalseTarget)
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
			Contact[] array = theContactsVisibleToMe.InternalArray();
			if (theContactsVisibleToMe.Count == 0)
			{
				return;
			}
			int num = theContactsVisibleToMe.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				Contact contact;
				try
				{
					contact = array[i];
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
					continue;
				}
				if (contact == null || contact.get_IsDestroyed(myUnit.ParentScen))
				{
					continue;
				}
				if (contact.IDStatus >= Contact_Base.IdentificationStatus.KnownType)
				{
					ActiveUnit actualUnit = contact.ActualUnit;
					if (actualUnit != null && actualUnit.IsSubmarine)
					{
						Submarine submarine = (Submarine)contact.ActualUnit;
						if (submarine.Type == Submarine._SubmarineType.Biologics || submarine.Type == Submarine._SubmarineType.FalseTarget)
						{
							continue;
						}
					}
				}
				if (contact.ActualUnit == null)
				{
					continue;
				}
				if (!myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactStancesOnThisPulse.TryGetValue(contact.ObjectID, out var value))
				{
					value = contact.get_Stance(myUnit.get_UnitSide(SetSideOnly: false));
					myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactStancesOnThisPulse.AddIfNotExists(contact.ObjectID, value);
				}
				if (value != Misc.PostureStance.Friendly && contact.ActualUnit.IsWeapon)
				{
					Weapon._WeaponType type = ((Weapon)contact.ActualUnit).Type;
					if (type == Weapon._WeaponType.Torpedo)
					{
						AddContactToThreatList(contact);
						Weapon longestRange_ASWWeapon = myUnit.Weaponry.GetLongestRange_ASWWeapon(contact);
						if (longestRange_ASWWeapon != null)
						{
							ActiveUnit_Weaponry weaponry = myUnit.Weaponry;
							Doctrine doctrine = myUnit.Doctrine;
							string Feedback = "";
							int FeedbackSeverity = 0;
							if (weaponry.HaveAvailableWeaponSuitableForThisTarget(contact, CheckWRA: true, doctrine, ref Feedback, ref FeedbackSeverity, HumanFeedBackNeeded: false) && (double)Module_Unit.RangeToUnit_Slant(myUnit, contact) < 1.5 * (double)longestRange_ASWWeapon.MaxSubsurfaceRange)
							{
								TargetThisContact(contact, AddedManually: false, PriorityTarget: false, TargetingEntry._TargetingBehavior.AutoTargeted);
							}
						}
						continue;
					}
				}
				switch (contact.Type)
				{
				case Contact_Base.ContactType.Submarine:
				case Contact_Base.ContactType.UndeterminedNaval:
					if (!contact.IsClassifiedFalseTarget && (value == Misc.PostureStance.Hostile || value == Misc.PostureStance.Unfriendly || value == Misc.PostureStance.Unknown))
					{
						AddContactToThreatList(contact);
					}
					break;
				case Contact_Base.ContactType.Surface:
				{
					Ship ship = (Ship)contact.ActualUnit;
					if (contact.IDStatus >= Contact_Base.IdentificationStatus.KnownType)
					{
						Ship._ShipCategory category = ship.Category;
						if (((uint)(category - 2001) <= 1u || (uint)(category - 2007) <= 1u) && (value == Misc.PostureStance.Hostile || value == Misc.PostureStance.Unfriendly))
						{
							AddContactToThreatList(contact);
						}
					}
					break;
				}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100818", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static float OverLayerDepth(ActiveUnit myUnit)
	{
		return Math.Min(SonarModel.GetThermalLayerAtThisLocation(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)myUnit).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, myUnit.ParentScen), myUnit.ParentScen).Ceiling + 10, -25);
	}

	public static float UnderLayerDepth(ActiveUnit myUnit)
	{
		return Math.Min(SonarModel.GetThermalLayerAtThisLocation(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)myUnit).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, myUnit.ParentScen), myUnit.ParentScen).Floor - 10, -25);
	}

	public bool DecideToSnort()
	{
		if (Math.Round(method_12().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) >= -20.0)
		{
			if (Math.Round(method_12().DesiredAltitude) >= -20.0)
			{
				if (method_12().Propulsion.Where([SpecialName] (Engine theE) => theE.Type == Engine.EngineType.Diesel && theE.Status != PlatformComponent._ComponentStatus.Destroyed).Count() != 0)
				{
					if (method_12().Propulsion.Where([SpecialName] (Engine theE) => theE.Type == Engine.EngineType.Diesel && theE.Status != PlatformComponent._ComponentStatus.Destroyed).Count() == 0)
					{
						return false;
					}
					return true;
				}
				return false;
			}
			return false;
		}
		return true;
	}

	private bool method_17(float float_2)
	{
		bool result;
		if (myUnit != null)
		{
			try
			{
				if (!method_12().IsNuke)
				{
					FuelRec fuelRec = method_12().Fuel_ReadOnly.Where([SpecialName] (FuelRec theRec) => theRec.FuelType == FuelRec._FuelType.DieselFuel).ElementAtOrDefault(0);
					if ((Information.IsNothing((object)fuelRec) || fuelRec.CurrentQuantity <= 0f) && method_12().IsAIP)
					{
						fuelRec = method_12().Fuel_ReadOnly.Where([SpecialName] (FuelRec theRec) => theRec.FuelType == FuelRec._FuelType.AirIndepedent).ElementAtOrDefault(0);
					}
					if (!Information.IsNothing((object)fuelRec) && fuelRec.CurrentQuantity > 0f)
					{
						FuelRec fuelRec2 = method_12().Fuel_ReadOnly.Where([SpecialName] (FuelRec theRec) => theRec.FuelType == FuelRec._FuelType.Battery).ElementAtOrDefault(0);
						if (Information.IsNothing((object)fuelRec2))
						{
							result = false;
						}
						else
						{
							double num = fuelRec2.PercentFull;
							result = num == 0.0 || ((num <= (double)(float_2 / 100f)) ? true : false);
						}
					}
					else
					{
						method_12().StopRechargingBatteries();
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
				ex2?.Data.Add("Error at 100820", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				int num2;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
					num2 = 0;
				}
				else
				{
					num2 = 0;
				}
				result = (byte)num2 != 0;
				ProjectData.ClearProjectError();
			}
		}
		else
		{
			result = false;
		}
		return result;
	}

	internal bool IsBatteryRechargePossible(bool IsAttackRechargeSetting, ActiveUnit_DockingOps._DockingOpsCondition? theCondition)
	{
		bool result;
		if (myUnit == null)
		{
			result = false;
		}
		else if (!method_12().IsNuke)
		{
			try
			{
				double num = (double)myUnit.Doctrine.get_RechargePercentageAttack(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false).Value / 100.0;
				FuelRec fuelRec = method_12().Fuel_ReadOnly.Where([SpecialName] (FuelRec theRec) => theRec.FuelType == FuelRec._FuelType.Battery).ElementAtOrDefault(0);
				double num2;
				if (!Information.IsNothing((object)fuelRec))
				{
					num2 = fuelRec.PercentFull;
					if (num2 < num)
					{
						result = true;
					}
					else
					{
						if (Information.IsNothing((object)theCondition))
						{
							theCondition = method_12().DockingOps.Condition;
						}
						byte? b = (byte?)theCondition;
						if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 9)) != true)
						{
							goto IL_0160;
						}
						double num3 = (double)myUnit.Doctrine.get_RechargePercentagePatrol(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false).Value / 100.0;
						if (!(num2 < num3))
						{
							goto IL_0160;
						}
						result = true;
					}
				}
				else
				{
					method_12().StopRechargingBatteries();
					result = false;
				}
				goto end_IL_0020;
				IL_0160:
				result = CanComeToPeriscopeDepth_CheckThreats(IsAttackRechargeSetting, theCondition, num, num2);
				end_IL_0020:;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100822", "");
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
		else
		{
			result = false;
		}
		return result;
	}

	internal bool CanComeToPeriscopeDepth_CheckThreats(bool IsAttackRechargeSetting, ActiveUnit_DockingOps._DockingOpsCondition? theCondition, double RechargeBatteryPercentage, double BatteryLevel)
	{
		bool result;
		try
		{
			bool value2;
			if (!method_12().IsBiological)
			{
				if (!method_12().IsFalseTarget)
				{
					if (!method_12().IsNuke)
					{
						if (RechargeBatteryPercentage < 0.0)
						{
							RechargeBatteryPercentage = (double)myUnit.Doctrine.get_RechargePercentageAttack(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false).Value / 100.0;
						}
						if (BatteryLevel < 0.0)
						{
							BatteryLevel = method_12().Fuel_ReadOnly.Where([SpecialName] (FuelRec theRec) => theRec.FuelType == FuelRec._FuelType.Battery).ElementAtOrDefault(0).PercentFull;
						}
					}
					Doctrine._DiveOnContact? diveOnContact = myUnit.Doctrine.get_DiveWhenThreatsDetected(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
					byte? b = (byte?)diveOnContact;
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
						b = (byte?)diveOnContact;
						flag = (flag3 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)));
						obj = ((!flag.HasValue) ? ((bool?)null) : ((flag3 == true) | flag2));
					}
					flag3 = obj;
					bool value = flag3.Value;
					b = (byte?)diveOnContact;
					flag = (flag3 = ((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)));
					bool? obj2;
					if (flag.HasValue && flag3 == true)
					{
						obj2 = true;
					}
					else
					{
						b = (byte?)diveOnContact;
						flag = (flag2 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)));
						obj2 = ((!flag.HasValue) ? ((bool?)null) : ((flag2 == true) | flag3));
					}
					flag2 = obj2;
					value2 = flag2.Value;
					if (!(myUnit.TimeSinceLastThreatDetection_ESM < 1800f) || !value)
					{
						goto IL_03ca;
					}
					if (Math.Round(myUnit.DesiredAltitude) >= -20.0)
					{
						string text = "";
						if (Operators.CompareString(myUnit.Name, myUnit.UnitClass, false) != 0)
						{
							text = " (" + myUnit.UnitClass + ")";
						}
						if (myUnit.Kinematics.DesiredAltitudeOverride)
						{
							myUnit.ParentScen.AddMessage("Submarine: " + myUnit.Name + text + " has been ordered to periscope depth or surface, but the doctrine has been set to dive on threat proximity. The submarine will now dive. To allow the sub to come to periscope depth or surface, change the Dive when threat is detected doctrine setting to No.", myUnit.Name + " dives (nearby threats!)", LoggedMessage.MessageType.UnitAI, 0, null, myUnit.get_UnitSide(SetSideOnly: false));
						}
					}
					if (method_12().IsNuke)
					{
						result = false;
					}
					else
					{
						if (IsAttackRechargeSetting || RechargeBatteryPercentage > BatteryLevel)
						{
							goto IL_03ca;
						}
						method_12().StopRechargingBatteries();
						result = false;
					}
				}
				else
				{
					result = false;
				}
			}
			else
			{
				result = true;
			}
			goto end_IL_0001;
			IL_03ca:
			if (value2)
			{
				foreach (Contact item in theContactsVisibleToMe)
				{
					if (!myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactStancesOnThisPulse.TryGetValue(item.ObjectID, out var value3))
					{
						value3 = item.get_Stance(myUnit.get_UnitSide(SetSideOnly: false));
						myUnit.get_UnitSide(SetSideOnly: false).Cache_ContactStancesOnThisPulse.AddIfNotExists(item.ObjectID, value3);
					}
					if (item.IDStatus <= Contact_Base.IdentificationStatus.KnownType)
					{
						continue;
					}
					if (item.IsSubmergedContact && !Information.IsNothing((object)item.ActualUnit) && item.ActualUnit.IsSubmarine)
					{
						Submarine submarine = (Submarine)item.ActualUnit;
						if (submarine.Type == Submarine._SubmarineType.Biologics || submarine.Type == Submarine._SubmarineType.FalseTarget)
						{
							continue;
						}
					}
					if (value3 == Misc.PostureStance.Friendly || value3 == Misc.PostureStance.Neutral)
					{
						continue;
					}
					Contact_Base.ContactType type = item.Type;
					int num2;
					if (type != Contact_Base.ContactType.Air)
					{
						int num;
						if (type - 2 > Contact_Base.ContactType.Missile)
						{
							if (type != Contact_Base.ContactType.Sonobuoy)
							{
								continue;
							}
							num = 20;
						}
						else
						{
							num = 20;
						}
						num2 = num;
					}
					else
					{
						num2 = 30;
					}
					if (method_12().RangeToUnit_Horiz(item) >= (float)num2)
					{
						continue;
					}
					if (!method_12().IsNuke)
					{
						method_12().StopRechargingBatteries();
					}
					int num3;
					if (Math.Round(myUnit.DesiredAltitude) >= -20.0)
					{
						string text2 = "";
						if (Operators.CompareString(myUnit.Name, myUnit.UnitClass, false) != 0)
						{
							text2 = " (" + myUnit.UnitClass + ")";
						}
						if (!myUnit.Kinematics.DesiredAltitudeOverride)
						{
							num3 = 0;
						}
						else
						{
							myUnit.ParentScen.AddMessage("Submarine: " + myUnit.Name + text2 + " has been ordered to periscope depth or surface, but the doctrine has been configured to order the submarine to dive when threats are nearby. The submarine will now dive. To allow the sub to come to periscope depth or surface, change the Dive when threat is detected doctrine to No.", myUnit.Name + " dives (nearby threats!)", LoggedMessage.MessageType.UnitAI, 0, null, myUnit.get_UnitSide(SetSideOnly: false));
							num3 = 0;
						}
					}
					else
					{
						num3 = 0;
					}
					result = (byte)num3 != 0;
					goto end_IL_0001;
				}
			}
			result = true;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101280", "");
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
		return result;
	}

	internal bool RiseToPeriscopeDepthForRechargeIfNecessary(float BatteryThreshold, bool UseAIPifAvailable, bool IsAttackRechargeSetting)
	{
		ActiveUnit_DockingOps._DockingOpsCondition condition = method_12().DockingOps.Condition;
		bool result;
		if (condition == ActiveUnit_DockingOps._DockingOpsCondition.RechargingBatteries)
		{
			if (!IsBatteryRechargePossible(IsAttackRechargeSetting, condition))
			{
				method_12().DesiredAltitude = -40f;
				result = false;
			}
			else
			{
				int num;
				if (method_12().Flags.HasSnorkel && Math.Round(method_12().DesiredAltitude) < -20.0)
				{
					method_12().DesiredAltitude = -20f;
					num = 1;
				}
				else if (method_12().Flags.HasSnorkel)
				{
					num = 1;
				}
				else if (Math.Round(method_12().DesiredAltitude) < -5.0)
				{
					method_12().DesiredAltitude = -5f;
					num = 1;
				}
				else
				{
					num = 1;
				}
				result = (byte)num != 0;
			}
		}
		else
		{
			try
			{
				int num2;
				if (myUnit != null)
				{
					if (method_12().IsNuke)
					{
						result = false;
					}
					else
					{
						_ = method_12().DesiredAltitude;
						if (!method_17(BatteryThreshold))
						{
							num2 = 0;
							goto IL_01bb;
						}
						if (!IsAttackRechargeSetting && !IsBatteryRechargePossible(IsAttackRechargeSetting, null))
						{
							num2 = 0;
							goto IL_01bb;
						}
						method_12().DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.RechargingBatteries;
						int num3;
						if (method_12().Flags.HasSnorkel && Math.Round(method_12().DesiredAltitude) < -20.0)
						{
							method_12().DesiredAltitude = -20f;
							num3 = 1;
						}
						else if (method_12().Flags.HasSnorkel)
						{
							num3 = 1;
						}
						else if (Math.Round(method_12().DesiredAltitude) < -5.0)
						{
							method_12().DesiredAltitude = -5f;
							num3 = 1;
						}
						else
						{
							num3 = 1;
						}
						result = (byte)num3 != 0;
					}
				}
				else
				{
					result = false;
				}
				goto end_IL_00cc;
				IL_01bb:
				result = (byte)num2 != 0;
				end_IL_00cc:;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100823", "");
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
		return result;
	}

	private void method_18(float float_2)
	{
		if (myUnit == null || myUnit.ActiveMissionOrPackage() == null || myUnit.ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Patrol)
		{
			return;
		}
		try
		{
			if (method_12().DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.RechargingBatteries)
			{
				return;
			}
			Patrol patrol = (Patrol)myUnit.ActiveMissionOrPackage();
			if (patrol.StationDepth_Submarine.HasValue)
			{
				float num = default(float);
				if (!((Module_Unit.Unit)myUnit).get_IsInsideThisArea(patrol.PatrolArea, myUnit.ParentScen, UseCache: false))
				{
					num = ((!patrol.TransitDepth_Submarine.HasValue) ? patrol.StationDepth_Submarine.Value : patrol.TransitDepth_Submarine.Value);
				}
				if (Math.Round(num) >= -20.0 && !IsBatteryRechargePossible(IsAttackRechargeSetting: false, null))
				{
					myUnit.DesiredAltitude = -40f;
				}
				else
				{
					myUnit.DesiredAltitude = num;
				}
				return;
			}
			switch (patrol.Type)
			{
			case GlobalVariables.PatrolType.AAW:
			case GlobalVariables.PatrolType.ASuW_Land:
			case GlobalVariables.PatrolType.ASuW_Mixed:
			case GlobalVariables.PatrolType.SEAD:
				if (!patrol.StationDepth_Submarine.HasValue)
				{
					myUnit.DesiredAltitude = -40f;
				}
				else if (Math.Round(patrol.StationDepth_Submarine.Value) >= -20.0 && !IsBatteryRechargePossible(IsAttackRechargeSetting: false, null))
				{
					myUnit.DesiredAltitude = -40f;
				}
				else
				{
					myUnit.DesiredAltitude = -20f;
				}
				break;
			case GlobalVariables.PatrolType.ASW:
			case GlobalVariables.PatrolType.ASuW_Naval:
			case GlobalVariables.PatrolType.SeaControl:
				float_0 -= float_2;
				if (float_0 <= 0f)
				{
					float_0 = GameGeneral.GlobalRNG.Next(1, 901);
					SonarModel.ThermoclineLayer thermalLayerAtThisLocation = SonarModel.GetThermalLayerAtThisLocation(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), Terrain.GetElevation(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, myUnit.ParentScen), myUnit.ParentScen);
					int num2 = -40;
					int num3 = ((!myUnit.Sensory.HasOperationalTowedArray) ? (thermalLayerAtThisLocation.Floor - 10) : (thermalLayerAtThisLocation.Ceiling + 10));
					if (num2 < num3)
					{
						num2 = num3 + 1;
					}
					if (GameGeneral.GlobalRNG.Next(1, 101) < 50)
					{
						myUnit.DesiredAltitude = num2;
					}
					else
					{
						myUnit.DesiredAltitude = num3;
					}
				}
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100824", "");
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
		if (myUnit != null)
		{
			float relativeBearing = MathFunctions.GetRelativeBearing(myUnit.CurrentHeading, myUnit.DesiredHeading);
			float num = 30f;
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
				myUnit.DesiredRoll = num;
			}
			else if (relativeBearing > 180f && relativeBearing <= 320f)
			{
				myUnit.DesiredRoll = 0f - num;
			}
			else
			{
				myUnit.DesiredRoll = -4f * (360f - relativeBearing);
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
	}

	private float method_19(string string_0)
	{
		Patrol patrol = (Patrol)myUnit.ActiveMissionOrPackage();
		float result = default(float);
		if (Operators.CompareString(string_0, "Transit", false) == 0)
		{
			result = ((patrol == null || patrol.UseTransitDepth_Submarine_Preset != true) ? patrol.TransitDepth_Submarine.Value : myUnit.AI.ConvertDepthPresetToValue(CheckThreats: false, patrol.TransitDepth_Submarine_Preset.Value));
		}
		if (Operators.CompareString(string_0, "Station", false) == 0)
		{
			result = ((patrol == null || patrol.UseStationDepth_Submarine_Preset != true) ? patrol.StationDepth_Submarine.Value : myUnit.AI.ConvertDepthPresetToValue(CheckThreats: false, patrol.StationDepth_Submarine_Preset.Value));
		}
		if (Operators.CompareString(string_0, "Attack", false) == 0)
		{
			result = ((patrol == null || patrol.UseAttackDepth_Submarine_Preset != true) ? patrol.AttackDepth_Submarine.Value : myUnit.AI.ConvertDepthPresetToValue(CheckThreats: false, patrol.AttackDepth_Submarine_Preset.Value));
		}
		return result;
	}

	public override void DetermineDesiredAttitudeAndThrottle(float elapsedTime, bool RecalculatePlottedCourse = true)
	{
		if (myUnit == null)
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
				myUnit.DesiredAltitude = myUnit.Kinematics.GetMinimumAltitude();
				return;
			}
			if (!Information.IsNothing((object)myUnit.ActiveMissionOrPackage()))
			{
				switch (myUnit.ActiveMissionOrPackage().MissionClass)
				{
				case Mission._MissionClass.Patrol:
				{
					Patrol patrol = (Patrol)myUnit.ActiveMissionOrPackage();
					if (patrol != null)
					{
						if (patrol.UseStationDepth_Submarine_Preset == true)
						{
							patrol.StationDepth_Submarine = ConvertDepthPresetToValue(CheckThreats: false, patrol.StationDepth_Submarine_Preset.Value);
						}
						if (patrol.UseTransitDepth_Submarine_Preset == true)
						{
							patrol.TransitDepth_Submarine = ConvertDepthPresetToValue(CheckThreats: false, patrol.TransitDepth_Submarine_Preset.Value);
						}
						if (patrol.UseAttackDepth_Submarine_Preset == true)
						{
							patrol.AttackDepth_Submarine = ConvertDepthPresetToValue(CheckThreats: false, patrol.AttackDepth_Submarine_Preset.Value);
						}
					}
					break;
				}
				case Mission._MissionClass.Support:
				{
					SupportMission supportMission = (SupportMission)myUnit.ActiveMissionOrPackage();
					if (supportMission != null)
					{
						if (supportMission.UseStationDepth_Submarine_Preset == true)
						{
							supportMission.StationDepth_Submarine = ConvertDepthPresetToValue(CheckThreats: false, supportMission.StationDepth_Submarine_Preset.Value);
						}
						if (supportMission.UseTransitDepth_Submarine_Preset == true)
						{
							supportMission.TransitDepth_Submarine = ConvertDepthPresetToValue(CheckThreats: false, supportMission.TransitDepth_Submarine_Preset.Value);
						}
					}
					break;
				}
				case Mission._MissionClass.Mining:
				{
					MiningMission miningMission = (MiningMission)myUnit.ActiveMissionOrPackage();
					if (miningMission != null)
					{
						if (miningMission.UseStationDepth_Submarine_Preset == true)
						{
							miningMission.StationDepth_Submarine = ConvertDepthPresetToValue(CheckThreats: false, miningMission.StationDepth_Submarine_Preset.Value);
						}
						if (miningMission.UseTransitDepth_Submarine_Preset == true)
						{
							miningMission.TransitDepth_Submarine = ConvertDepthPresetToValue(CheckThreats: false, miningMission.TransitDepth_Submarine_Preset.Value);
						}
					}
					break;
				}
				case Mission._MissionClass.MineClearing:
				{
					MineClearingMission mineClearingMission = (MineClearingMission)myUnit.ActiveMissionOrPackage();
					if (mineClearingMission != null)
					{
						if (mineClearingMission.UseStationDepth_Submarine_Preset == true)
						{
							mineClearingMission.StationDepth_Submarine = ConvertDepthPresetToValue(CheckThreats: false, mineClearingMission.StationDepth_Submarine_Preset.Value);
						}
						if (mineClearingMission.UseTransitDepth_Submarine_Preset == true)
						{
							mineClearingMission.TransitDepth_Submarine = ConvertDepthPresetToValue(CheckThreats: false, mineClearingMission.TransitDepth_Submarine_Preset.Value);
						}
					}
					break;
				}
				}
			}
			if (activeUnitStatus == ActiveUnit._ActiveUnitStatus.EngagedDefensive)
			{
				int value = (int)myUnit.Doctrine.get_RechargePercentageAttack(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false).Value;
				if (!RiseToPeriscopeDepthForRechargeIfNecessary(value, UseAIPifAvailable: true, IsAttackRechargeSetting: true))
				{
					myUnit.Kinematics.DesiredSpeedOverride = null;
					myUnit.SetThrottle(ActiveUnit.Throttle.Flank);
				}
				ManouverAgainstPrimaryThreat(elapsedTime);
				return;
			}
			if (activeUnitStatus == ActiveUnit._ActiveUnitStatus.AttemptingToReestablishComms)
			{
				myUnit.SetThrottle(ActiveUnit.Throttle.Loiter);
				DepthPreset = SubmarineDepthPreset.Shallow;
				FollowDepthPreset(CheckThreats: true);
				return;
			}
			if (activeUnitStatus == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint)
			{
				bool flag = true;
				GeoPoint intermediateTargetPoint = IntermediateTargetPointForRefuelCalcs();
				ActiveUnit_DockingOps dockingOps = myUnit.DockingOps;
				string UserFeedback = "";
				List<ActiveUnit> potentialUNREPunits = dockingOps.GetPotentialUNREPunits(MustBeAbleToReachItDirectly: true, null, ref UserFeedback, ActiveUnit_DockingOps.ResupplyRequest.FuelOrMaterial);
				if (myUnit.ParentScen.MinuteIsChangingOnThisPulse || Information.IsNothing((object)myUnit.DockingOps.UNREP_Destination))
				{
					if (!Information.IsNothing((object)myUnit.DockingOps.UNREP_Destination) && potentialUNREPunits.Contains(myUnit.DockingOps.UNREP_Destination))
					{
						flag = myUnit.DockingOps.AttemptToRendezvousWithTanker(myUnit.DockingOps.UNREP_Destination) == ActiveUnit_DockingOps.ResultOfAttemptToRendezvousWithTanker.Success || myUnit.DockingOps.AttemptToScheduleUNREP(intermediateTargetPoint, null, null, IsManualOrder: false, 100).Result == ActiveUnit_DockingOps.ResultOfAttemptToScheduleUNREP.Success;
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
				if (!Information.IsNothing((object)myUnit.DockingOps.UNREP_Destination) && flag)
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
					if (uNREP_Destination.CommStuff.IsConnectedToSideNetwork)
					{
						myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Module_Unit.BearingToUnit_True(myUnit, uNREP_Destination));
					}
					else
					{
						myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Module_Unit.BearingToPoint_True(myUnit, uNREP_Destination.Latitude_LastReported.Value, uNREP_Destination.Longitude_LastReported.Value));
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
			if (activeUnitStatus == ActiveUnit._ActiveUnitStatus.Refuelling)
			{
				myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, myUnit.DockingOps.UNREP_Destination.DesiredHeading);
				ActiveUnit uNREP_Destination2 = myUnit.DockingOps.UNREP_Destination;
				if (myUnit.IsGroupLead() && uNREP_Destination2.IsGroupMember() && myUnit.get_ParentGroup(UsingMissionPlanner: false) == uNREP_Destination2.get_ParentGroup(UsingMissionPlanner: false))
				{
					uNREP_Destination2.DesiredSpeed = myUnit.DesiredSpeed;
					return;
				}
				myUnit.DesiredSpeed = uNREP_Destination2.DesiredSpeed;
				myUnit.SetThrottle(myUnit.Kinematics.GetThrottleSuitableForThisSpeed(0f, (int)Math.Round(myUnit.DesiredSpeed)), (int)Math.Round(myUnit.DesiredSpeed));
				return;
			}
			if (activeUnitStatus == ActiveUnit._ActiveUnitStatus.WaitForPathfinder)
			{
				myUnit.DesiredSpeed = 0f;
				myUnit.SetThrottle(ActiveUnit.Throttle.FullStop, 0f);
				if (method_12().IsTetheredROV)
				{
					ActiveUnit activeUnit = myUnit.DockingOps.get_AssignedHostUnit(PickNewAssignedHost: false);
					if (!Information.IsNothing((object)activeUnit))
					{
						activeUnit.DesiredSpeed = 0f;
						activeUnit.SetThrottle(ActiveUnit.Throttle.FullStop, 0f);
					}
				}
				return;
			}
			if (activeUnitStatus != ActiveUnit._ActiveUnitStatus.RTB && activeUnitStatus != ActiveUnit._ActiveUnitStatus.RTB_Manual && activeUnitStatus != ActiveUnit._ActiveUnitStatus.RTB_MissionOver && activeUnitStatus != ActiveUnit._ActiveUnitStatus.RTB_CommsLost && activeUnitStatus != ActiveUnit._ActiveUnitStatus.RTB_Exhaustion)
			{
				switch (activeUnitStatus)
				{
				case ActiveUnit._ActiveUnitStatus.EngagedOffensive:
				{
					if (PrimaryTarget == null)
					{
						return;
					}
					Contact_Base.ContactType type = PrimaryTarget.Type;
					if (type > Contact_Base.ContactType.Missile && type != Contact_Base.ContactType.Orbital)
					{
						Weapon weapon = myUnit.Weaponry.MostSuitableWeaponForThisTarget(myUnit.AI.PrimaryTarget, CheckIfWithinRange: true, CheckIfWithinAltitude: true, CheckWRA: true, myUnit.Doctrine, excludeChaffsAndCounterMeasures: false, CheckWeaponQuantity: true);
						if (weapon != null)
						{
							float num14 = weapon.get_MaxRangeForThisTarget(myUnit, myUnit.AI.PrimaryTarget, CheckWRA: true, myUnit.Doctrine, ManualFire: false);
							if (!HasToTMissionAndFiringProposalActive(PrimaryTarget) || !(num14 > Math2.CalcDist(myUnit, myUnit.AI.PrimaryTarget)) || !PrimaryTarget.IsLandContact)
							{
								ManouverTowardsTarget(elapsedTime);
							}
						}
						else
						{
							ManouverTowardsTarget(elapsedTime);
						}
					}
					float? num15 = null;
					float num16 = float.MaxValue;
					int value7 = (int)myUnit.Doctrine.get_RechargePercentageAttack(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false).Value;
					Patrol patrol7 = default(Patrol);
					if (!RiseToPeriscopeDepthForRechargeIfNecessary(value7, UseAIPifAvailable: true, IsAttackRechargeSetting: true) && !myUnit.Kinematics.DesiredSpeedOverride.HasValue)
					{
						ActiveUnit.Throttle? throttle = default(ActiveUnit.Throttle?);
						if (!Information.IsNothing((object)myUnit.ActiveMissionOrPackage()) && myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
						{
							patrol7 = (Patrol)myUnit.ActiveMissionOrPackage();
							if (!Information.IsNothing((object)patrol7.AttackThrottle_Submarine))
							{
								num15 = patrol7.AttackDistance_Submarine;
								if (Information.IsNothing((object)num15))
								{
									throttle = patrol7.AttackThrottle_Submarine;
								}
								else
								{
									num16 = myUnit.RangeToUnit_Horiz(PrimaryTarget);
									throttle = ((((!num15.HasValue) ? ((bool?)null) : new bool?(num16 > num15.GetValueOrDefault())) != true) ? patrol7.AttackThrottle_Submarine : new ActiveUnit.Throttle?(patrol7.TransitThrottle_Submarine));
								}
							}
						}
						if (!Information.IsNothing((object)throttle) & (myUnit.Status != ActiveUnit._ActiveUnitStatus.EngagedOffensive))
						{
							myUnit.SetThrottle(throttle.Value);
						}
						else if (PrimaryTarget != null && (PrimaryTarget.IsShipContact || PrimaryTarget.IsSubmergedContact))
						{
							int? num17 = MinimumSpeedToInterceptTarget(PrimaryTarget.ActualUnit);
							if (PrimaryTarget.HeadingIsKnown && PrimaryTarget.SpeedIsKnown)
							{
								float num18 = Math.Abs(MathFunctions.GetRelativeBearing(Module_Unit.BearingToUnit_True(method_12(), PrimaryTarget), PrimaryTarget.CurrentHeading));
								if (num18 < 20f)
								{
									if (!num17.HasValue)
									{
										myUnit.DesiredSpeed = PrimaryTarget.CurrentSpeed * 2f + 1f;
									}
									else
									{
										myUnit.DesiredSpeed = Math.Max(num17.Value, PrimaryTarget.CurrentSpeed * 2f + 1f);
									}
									myUnit.SetThrottle(myUnit.Kinematics.GetThrottleSuitableForThisSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (int)Math.Round(myUnit.DesiredSpeed)));
								}
								else if (num18 < 90f)
								{
									if (num17.HasValue)
									{
										myUnit.DesiredSpeed = Math.Max(num17.Value, PrimaryTarget.CurrentSpeed * 2f + 1f);
									}
									else
									{
										myUnit.DesiredSpeed = (float)((double)PrimaryTarget.CurrentSpeed * 1.5) + 1f;
									}
									myUnit.SetThrottle(myUnit.Kinematics.GetThrottleSuitableForThisSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (int)Math.Round(myUnit.DesiredSpeed)));
								}
								else if (num17.HasValue)
								{
									myUnit.DesiredSpeed = num17.Value;
									myUnit.SetThrottle(myUnit.Kinematics.GetThrottleSuitableForThisSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (int)Math.Round(myUnit.DesiredSpeed)));
								}
								else
								{
									myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
								}
							}
							else if (PrimaryTarget.HeadingIsKnown && PrimaryTarget.SpeedIsKnown)
							{
								if (Module_Unit.ClosureSpeed(myUnit, PrimaryTarget, myUnit.CurrentSpeed, myUnit.CurrentHeading) > 0f)
								{
									myUnit.SetThrottle(ActiveUnit.Throttle.Loiter);
								}
								else
								{
									myUnit.SetThrottle(ActiveUnit.Throttle.Full);
								}
							}
							else
							{
								myUnit.SetThrottle(ActiveUnit.Throttle.Loiter);
							}
						}
						else if (!bool_0 && !HasActiveFireProposalForTarget(PrimaryTarget))
						{
							myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
						}
					}
					if (!myUnit.Kinematics.DesiredAltitudeOverride && method_12().DockingOps.Condition != ActiveUnit_DockingOps._DockingOpsCondition.RechargingBatteries)
					{
						float? num19 = null;
						if (!Information.IsNothing((object)myUnit.ActiveMissionOrPackage()) && myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
						{
							if (Information.IsNothing((object)patrol7))
							{
								patrol7 = (Patrol)myUnit.ActiveMissionOrPackage();
							}
							if (!Information.IsNothing((object)patrol7.AttackDepth_Submarine))
							{
								if (Information.IsNothing((object)num15))
								{
									num15 = patrol7.AttackDistance_Submarine;
								}
								if (Information.IsNothing((object)num15))
								{
									num19 = patrol7.AttackDepth_Submarine;
								}
								else
								{
									if (num16 == float.MaxValue)
									{
										num16 = myUnit.RangeToUnit_Horiz(PrimaryTarget);
									}
									num19 = ((((!num15.HasValue) ? ((bool?)null) : new bool?(num16 > num15.GetValueOrDefault())) != true) ? patrol7.AttackDepth_Submarine : patrol7.TransitDepth_Submarine);
								}
							}
						}
						if (Information.IsNothing((object)num19))
						{
							if ((float)myUnit.Kinematics.GetMaximumSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), myUnit.ThrottleSetting, ValidateAndFixAltitude: false) < myUnit.DesiredSpeed)
							{
								int num20;
								if (myUnit.TimeSinceLastThreatDetection_ESM < 1800f)
								{
									if (!IsBatteryRechargePossible(IsAttackRechargeSetting: false, null))
									{
										myUnit.DesiredAltitude = -40f;
										return;
									}
									num20 = 1;
								}
								else
								{
									num20 = 1;
								}
								int num21 = num20;
								do
								{
									ActiveUnit.Throttle throttle2 = (ActiveUnit.Throttle)num21;
									float? num22 = ((Submarine_Kinematics)myUnit.Kinematics).MinimumDepthToAchieveThisSpeed(myUnit.DesiredSpeed, throttle2);
									if (num22.HasValue)
									{
										myUnit.SetThrottle(throttle2);
										float? num12 = num22;
										if ((num12.HasValue ? new bool?(num12.GetValueOrDefault() < -40f) : ((bool?)null)) == true)
										{
											myUnit.DesiredAltitude = num22.Value;
										}
									}
									num21++;
								}
								while (num21 <= 4);
								return;
							}
							if (PrimaryTarget != null)
							{
								switch (PrimaryTarget.Type)
								{
								default:
									myUnit.DesiredAltitude = -40f;
									break;
								case Contact_Base.ContactType.Submarine:
									if (!PrimaryTarget.AltitudeIsKnown)
									{
										myUnit.DesiredAltitude = -40f;
									}
									else if (((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > -40f)
									{
										myUnit.DesiredAltitude = -40f;
									}
									else
									{
										myUnit.DesiredAltitude = ((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
									}
									break;
								case Contact_Base.ContactType.Surface:
									myUnit.DesiredAltitude = -40f;
									break;
								}
							}
							OptimizeAltSpeedForNextEngagement(elapsedTime, null, null);
						}
						else
						{
							float value8 = num19.Value;
							if (Math.Round(value8) >= -20.0 && !IsBatteryRechargePossible(IsAttackRechargeSetting: false, null))
							{
								myUnit.DesiredAltitude = -40f;
							}
							else if (!bool_0)
							{
								myUnit.DesiredAltitude = value8;
							}
						}
					}
					else if (method_12().DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.RechargingBatteries)
					{
						if (!IsBatteryRechargePossible(IsAttackRechargeSetting: false, null))
						{
							OptimizeAltSpeedForNextEngagement(elapsedTime, null, null);
						}
						else if (Math.Round(myUnit.DesiredAltitude) < -20.0)
						{
							myUnit.DesiredAltitude = -20f;
						}
					}
					else
					{
						FollowDepthPreset(CheckThreats: true);
					}
					return;
				}
				case ActiveUnit._ActiveUnitStatus.OnPlottedCourse:
				{
					if (myUnit.IsOnActivePatrol() && !myUnit.Navigator.NextWaypointIsManual)
					{
						if (myUnit.Status == ActiveUnit._ActiveUnitStatus.EngagedOffensive && myUnit.Navigator.PlottedCourse.Length == 1 && myUnit.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.PatrolStation)
						{
							myUnit.Navigator.ClearPlottedCourse();
							return;
						}
						Patrol patrol2 = (Patrol)myUnit.ActiveMissionOrPackage();
						if (!myUnit.Navigator.PlottedCourseLeadsToMissionArea(ref patrol2.PatrolArea, ref patrol2.PatrolArea_30nm_Buffered, ref patrol2.PatrolArea_30nm_ChangeCheck, 30f, IgnoreTimeToNextEvaluation: false))
						{
							myUnit.Navigator.ClearPlottedCourse();
							myUnit.Navigator.PlotCourseToStationArea(elapsedTime, AddWaypointToExistingPlottedCourse: false);
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
					if (method_12().IsOnActiveMiningMission)
					{
						method_20(elapsedTime);
						return;
					}
					int num5;
					if (!myUnit.Navigator.SprintDrift)
					{
						num5 = 0;
					}
					else
					{
						myUnit.Navigator.PerformSprintDrift(elapsedTime);
						num5 = 0;
					}
					bool flag2 = (byte)num5 != 0;
					MineClearingMission mineClearingMission3 = null;
					if (!method_12().IsOnActivePatrol())
					{
						if (method_12().IsOnActiveMineClearingMission)
						{
							mineClearingMission3 = (MineClearingMission)myUnit.ActiveMissionOrPackage();
							flag2 = (myUnit.Navigator.IsInsideMissionArea(ref mineClearingMission3.Area, ref mineClearingMission3.Area_2nm_Buffered, ref mineClearingMission3.Area_2nm_ChangeCheck, 2, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false) ? true : false);
						}
					}
					else
					{
						Patrol patrol3 = (Patrol)myUnit.ActiveMissionOrPackage();
						flag2 = (myUnit.Navigator.IsInsideMissionArea(ref patrol3.PatrolArea, ref patrol3.PatrolArea_2nm_Buffered, ref patrol3.PatrolArea_2nm_ChangeCheck, 2, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false) ? true : false);
					}
					if (method_12().DockingOps.Condition != ActiveUnit_DockingOps._DockingOpsCondition.RechargingBatteries && !myUnit.Kinematics.DesiredSpeedOverride.HasValue && !myUnit.Navigator.SprintDrift)
					{
						if (!method_12().IsOnActivePatrol())
						{
							if (method_12().IsOnActiveMineClearingMission)
							{
								if (!flag2)
								{
									myUnit.SetThrottle(mineClearingMission3.TransitThrottle_Submarine);
								}
								else if (method_12().IsTetheredROV)
								{
									myUnit.SetThrottle(ActiveUnit.Throttle.Flank);
								}
								else
								{
									myUnit.SetThrottle(mineClearingMission3.StationThrottle_Submarine);
								}
							}
							else if (!method_12().IsOnActiveFerryMission)
							{
								if (method_12().IsTetheredROV)
								{
									myUnit.SetThrottle(ActiveUnit.Throttle.Flank);
								}
								else if (!myUnit.Navigator.SprintDrift)
								{
									if (!method_12().IsNuke)
									{
										FuelRec fuelRec = (from theRec in myUnit.Fuel_ReadOnly
											where theRec.FuelType == FuelRec._FuelType.Battery
											select (theRec)).ElementAtOrDefault(0);
										if (!Information.IsNothing((object)fuelRec))
										{
											if ((double)fuelRec.PercentFull < 0.0001)
											{
												myUnit.SetThrottle(ActiveUnit.Throttle.FullStop);
												myUnit.Kinematics.AdjustSpeedForCavitation();
											}
											else if (fuelRec.PercentFull < 1f)
											{
												myUnit.SetThrottle(ActiveUnit.Throttle.Loiter);
												myUnit.Kinematics.AdjustSpeedForCavitation();
											}
											else
											{
												myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
												myUnit.Kinematics.AdjustSpeedForCavitation();
											}
										}
										else
										{
											myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
											myUnit.Kinematics.AdjustSpeedForCavitation();
										}
									}
									else
									{
										myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
										myUnit.Kinematics.AdjustSpeedForCavitation();
									}
								}
							}
							else
							{
								FerryMission ferryMission = (FerryMission)method_12().ActiveMissionOrPackage();
								if (!method_12().Kinematics.DesiredSpeedOverride.HasValue)
								{
									if (!ferryMission.FerryThrottle_Submarine.HasValue)
									{
										method_12().SetThrottle(ActiveUnit.Throttle.Cruise);
									}
									else
									{
										method_12().SetThrottle(ferryMission.FerryThrottle_Submarine.Value);
									}
								}
							}
						}
						else
						{
							Patrol patrol4 = (Patrol)myUnit.ActiveMissionOrPackage();
							if (!flag2)
							{
								myUnit.SetThrottle(patrol4.TransitThrottle_Submarine);
							}
							else
							{
								myUnit.SetThrottle(patrol4.StationThrottle_Submarine);
							}
						}
					}
					int value3 = (int)myUnit.Doctrine.get_RechargePercentagePatrol(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false).Value;
					if (method_12().DockingOps.Condition != ActiveUnit_DockingOps._DockingOpsCondition.RechargingBatteries)
					{
						if (!myUnit.Kinematics.DesiredAltitudeOverride)
						{
							if (!myUnit.IsOnActivePatrol())
							{
								if (!method_12().IsOnActiveMineClearingMission)
								{
									if (!method_12().IsOnActiveFerryMission)
									{
										if (!method_12().Kinematics.DesiredAltitudeOverride && !RiseToPeriscopeDepthForRechargeIfNecessary(value3, UseAIPifAvailable: true, IsAttackRechargeSetting: false))
										{
											method_12().DesiredAltitude = Math.Min(-20f, OverLayerDepth(method_12()));
										}
									}
									else
									{
										FerryMission ferryMission2 = (FerryMission)method_12().ActiveMissionOrPackage();
										if (!RiseToPeriscopeDepthForRechargeIfNecessary(value3, UseAIPifAvailable: false, IsAttackRechargeSetting: false))
										{
											if (!ferryMission2.FerryAltitude_Submarine.HasValue)
											{
												method_12().DesiredAltitude = OverLayerDepth(method_12());
											}
											else
											{
												int num6 = (int)Math.Round(ferryMission2.FerryAltitude_Submarine.Value);
												if (num6 >= -20 && !IsBatteryRechargePossible(IsAttackRechargeSetting: false, null))
												{
													method_12().DesiredAltitude = (int)Math.Round(OverLayerDepth(method_12()));
												}
												else
												{
													method_12().DesiredAltitude = num6;
												}
											}
										}
									}
								}
								else if (!flag2)
								{
									if (!RiseToPeriscopeDepthForRechargeIfNecessary(value3, UseAIPifAvailable: false, IsAttackRechargeSetting: false))
									{
										if (!mineClearingMission3.TransitDepth_Submarine.HasValue)
										{
											method_12().DesiredAltitude = OverLayerDepth(method_12());
										}
										else
										{
											int num7 = (int)Math.Round(mineClearingMission3.TransitDepth_Submarine.Value);
											if (num7 >= -20 && !IsBatteryRechargePossible(IsAttackRechargeSetting: false, null))
											{
												myUnit.DesiredAltitude = (int)Math.Round(OverLayerDepth(method_12()));
											}
											else
											{
												myUnit.DesiredAltitude = num7;
											}
										}
									}
								}
								else if (!RiseToPeriscopeDepthForRechargeIfNecessary(value3, UseAIPifAvailable: false, IsAttackRechargeSetting: false) && !myUnit.ParentScen.MineAllocation.ContainsKey(myUnit.ObjectID))
								{
									if (!mineClearingMission3.StationDepth_Submarine.HasValue)
									{
										myUnit.DesiredAltitude = -20f;
									}
									else
									{
										int num8 = (int)Math.Round(mineClearingMission3.StationDepth_Submarine.Value);
										if (num8 >= -20 && !IsBatteryRechargePossible(IsAttackRechargeSetting: false, null))
										{
											myUnit.DesiredAltitude = -40f;
										}
										else
										{
											myUnit.DesiredAltitude = num8;
										}
									}
								}
							}
							else if (!flag2)
							{
								if (!RiseToPeriscopeDepthForRechargeIfNecessary(value3, UseAIPifAvailable: false, IsAttackRechargeSetting: false))
								{
									Patrol patrol5 = (Patrol)myUnit.ActiveMissionOrPackage();
									if (!patrol5.TransitDepth_Submarine.HasValue)
									{
										method_12().DesiredAltitude = OverLayerDepth(method_12());
									}
									else
									{
										int num9 = (int)Math.Round(patrol5.TransitDepth_Submarine.Value);
										if (num9 >= -20 && !IsBatteryRechargePossible(IsAttackRechargeSetting: false, null))
										{
											myUnit.DesiredAltitude = (int)Math.Round(OverLayerDepth(method_12()));
										}
										else
										{
											myUnit.DesiredAltitude = num9;
										}
									}
								}
							}
							else if (!RiseToPeriscopeDepthForRechargeIfNecessary(value3, UseAIPifAvailable: false, IsAttackRechargeSetting: false))
							{
								Patrol patrol6 = (Patrol)myUnit.ActiveMissionOrPackage();
								if (!patrol6.StationDepth_Submarine.HasValue)
								{
									method_18(elapsedTime);
								}
								else
								{
									int num10 = (int)Math.Round(patrol6.StationDepth_Submarine.Value);
									if (num10 >= -20 && !IsBatteryRechargePossible(IsAttackRechargeSetting: false, null))
									{
										myUnit.DesiredAltitude = -40f;
									}
									else
									{
										myUnit.DesiredAltitude = num10;
									}
								}
							}
						}
						else
						{
							FollowDepthPreset(CheckThreats: true);
						}
					}
					if (Information.IsNothing((object)myUnit.ActiveMissionOrPackage()) || myUnit.ActiveMissionOrPackage().MissionClass != Mission._MissionClass.MineClearing)
					{
						return;
					}
					if (myUnit.ParentScen.FifteenthSecondIsChangingOnThisPulse)
					{
						_Closure$__47-0 arg2 = default(_Closure$__47-0);
						_Closure$__47-0 CS$<>8__locals41 = new _Closure$__47-0(arg2);
						CS$<>8__locals41.$VB$Me = this;
						CS$<>8__locals41.$VB$Local_myMission = (MineClearingMission)myUnit.ActiveMissionOrPackage();
						CS$<>8__locals41.$VB$Local_MissionArea = CS$<>8__locals41.$VB$Local_myMission.Area;
						CS$<>8__locals41.$VB$Local_LegitTargets = new TList<UnguidedWeapon>();
						if (!myUnit.HasMineCountermeasures() && !myUnit.HasMineCounterWeapons())
						{
							if (!method_12().IsTetheredROV)
							{
								myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
							}
							else
							{
								myUnit.SetThrottle(ActiveUnit.Throttle.Full);
							}
						}
						else
						{
							Parallel.ForEach(myUnit.get_UnitSide(SetSideOnly: false).Contacts_NonAU, [SpecialName] (string theUW_ObjectID) =>
							{
								UnguidedWeapon value14 = null;
								CS$<>8__locals41.$VB$Me.myUnit.ParentScen.UnguidedWeapons.TryGetValue(theUW_ObjectID, out value14);
								if (!Information.IsNothing((object)value14) && value14.IsMine)
								{
									if (((Module_Unit.Unit)value14).get_IsInsideThisArea(CS$<>8__locals41.$VB$Local_MissionArea, CS$<>8__locals41.$VB$Me.myUnit.ParentScen, UseCache: true))
									{
										CS$<>8__locals41.$VB$Local_LegitTargets.Add(value14);
									}
									else if (CS$<>8__locals41.$VB$Local_myMission.MovementStyle == Mission.MissionMovementStyle.RepeatableLoop && CS$<>8__locals41.$VB$Me.myUnit.Navigator.IsInsideMissionArea(ref CS$<>8__locals41.$VB$Local_MissionArea, ref CS$<>8__locals41.$VB$Local_myMission.Area_2nm_Buffered, ref CS$<>8__locals41.$VB$Local_myMission.Area_2nm_ChangeCheck, 2, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
									{
										CS$<>8__locals41.$VB$Local_LegitTargets.Add(value14);
									}
								}
							});
							TList<UnguidedWeapon> tList2 = new TList<UnguidedWeapon>();
							foreach (UnguidedWeapon item in CS$<>8__locals41.$VB$Local_LegitTargets)
							{
								if ((float)method_12().MaxDepth > ((Module_Unit.Unit)item).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))
								{
									if (item.Mine_Targeted != null && item.Mine_Targeted.IsSubmarine && myUnit.ParentScen.MineAllocation.ContainsKey(item.Mine_Targeted.ObjectID))
									{
										myUnit.ParentScen.MineAllocation.Remove(item.Mine_Targeted.ObjectID);
										item.Mine_Targeted = null;
									}
									continue;
								}
								if (((Module_Unit.Unit)item).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > -5f)
								{
									if (item.Mine_Targeted != null && item.Mine_Targeted.IsSubmarine && myUnit.ParentScen.MineAllocation.ContainsKey(item.Mine_Targeted.ObjectID))
									{
										myUnit.ParentScen.MineAllocation.Remove(item.Mine_Targeted.ObjectID);
										item.Mine_Targeted = null;
									}
									continue;
								}
								if (method_12().IsTetheredROV)
								{
									if ((double)myUnit.RangeToUnit_Horiz(item) > (double)method_12().ROVControlRadius_m / 1852.0 * 2.0)
									{
										continue;
									}
									ActiveUnit activeUnit4 = myUnit.DockingOps.get_AssignedHostUnit(PickNewAssignedHost: false);
									if (!Information.IsNothing((object)activeUnit4) && ((double)activeUnit4.RangeToUnit_Horiz(method_12()) * 1852.0 > (double)(method_12().ROVControlRadius_m - 20) || (double)activeUnit4.RangeToUnit_Horiz(item) * 1852.0 > (double)(method_12().ROVControlRadius_m - 20)))
									{
										continue;
									}
								}
								if (myUnit.RangeToUnit_Horiz(item) > 2f)
								{
									continue;
								}
								if (item.Mine_Targeted != null)
								{
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
														float num11 = myUnit.RangeToUnit_Horiz(item);
														float? num12 = item.Mine_Targeted?.RangeToUnit_Horiz(item);
														bool? flag3 = ((!num12.HasValue) ? ((bool?)null) : new bool?(num11 < num12.GetValueOrDefault()));
														if ((flag3 ?? true) && myUnit.get_CanSweepMine(item) && flag3.HasValue)
														{
															if (item.Mine_Targeted != null)
															{
																myUnit.ParentScen.MineAllocation.Remove(item.Mine_Targeted.ObjectID);
																if (item.Mine_Targeted.Navigator.HasPlottedCourse() && item.Mine_Targeted.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.TerminalPoint)
																{
																	item.Mine_Targeted.Navigator.RemoveWaypoint_Soft(item.Mine_Targeted.Navigator.PlottedCourse[0], RemoveWingmanWaypoints: false);
																}
																else if (item.Mine_Targeted.Navigator.PlottedCourse.Count() <= 1)
																{
																	item.Mine_Targeted.Navigator.ClearPlottedCourse();
																	item.Mine_Targeted.Navigator.PlotCourseToStationArea(elapsedTime, AddWaypointToExistingPlottedCourse: false);
																}
															}
															item.Mine_Targeted = null;
														}
														goto IL_237d;
													}
												}
												item.Mine_Targeted = null;
											}
										}
									}
									else if (item.Mine_Targeted != null && item.Mine_Targeted.Equals(myUnit))
									{
										tList2.Add(item);
										if (!myUnit.ParentScen.MineAllocation.ContainsKey(myUnit.ObjectID))
										{
											myUnit.ParentScen.MineAllocation.Add(myUnit.ObjectID, item);
										}
									}
									goto IL_237d;
								}
								tList2.Add(item);
								continue;
								IL_237d:
								if (item.Mine_Targeted == null)
								{
									tList2.Add(item);
								}
							}
							CS$<>8__locals41.$VB$Local_LegitTargets = tList2;
							UnguidedWeapon unguidedWeapon4 = null;
							if (CS$<>8__locals41.$VB$Local_LegitTargets.Count > 0)
							{
								while (CS$<>8__locals41.$VB$Local_LegitTargets.Count > 0)
								{
									unguidedWeapon4 = (from theMine in CS$<>8__locals41.$VB$Local_LegitTargets.ToList()
										where !Information.IsNothing((object)theMine) && myUnit.get_CanSweepMine(theMine)
										orderby Module_Unit.RangeToUnit_Horiz_Angular(myUnit, theMine)
										select theMine).ElementAtOrDefault(0);
									if (unguidedWeapon4 == null || unguidedWeapon4.Mine_Targeted == null || unguidedWeapon4.Mine_Targeted.Equals(myUnit))
									{
										break;
									}
									CS$<>8__locals41.$VB$Local_LegitTargets.Remove(unguidedWeapon4);
								}
								if (unguidedWeapon4 == null)
								{
									UnguidedWeapon value4 = null;
									if (myUnit.ParentScen.MineAllocation.TryGetValue(myUnit.ObjectID, ref value4))
									{
										if (value4 != null && Operators.CompareString(value4.Mine_Targeted.ObjectID, myUnit.ObjectID, false) == 0)
										{
											value4.Mine_Targeted = null;
										}
										myUnit.ParentScen.MineAllocation.Remove(myUnit.ObjectID);
									}
								}
							}
							else
							{
								UnguidedWeapon value5 = null;
								if (myUnit.ParentScen.MineAllocation.TryGetValue(myUnit.ObjectID, ref value5))
								{
									if (value5 != null && Operators.CompareString(value5.Mine_Targeted.ObjectID, myUnit.ObjectID, false) == 0)
									{
										value5.Mine_Targeted = null;
									}
									myUnit.ParentScen.MineAllocation.Remove(myUnit.ObjectID);
								}
							}
							if (CS$<>8__locals41.$VB$Local_LegitTargets.Count > 0 && unguidedWeapon4 != null)
							{
								float num13 = myUnit.RangeToUnit_Horiz(unguidedWeapon4);
								if (!myUnit.HasMineDisposalCharges)
								{
									ManouverToSweepMine(unguidedWeapon4, num13);
								}
								else
								{
									ManouverToNeutralizeMine(unguidedWeapon4, num13);
								}
								unguidedWeapon4.Mine_Targeted = myUnit;
								if (!myUnit.ParentScen.MineAllocation.ContainsKey(myUnit.ObjectID))
								{
									myUnit.ParentScen.MineAllocation.Add(myUnit.ObjectID, unguidedWeapon4);
								}
								else
								{
									UnguidedWeapon value6 = null;
									if (!myUnit.ParentScen.MineAllocation.TryGetValue(myUnit.ObjectID, ref value6) || !unguidedWeapon4.Equals(value6))
									{
										myUnit.ParentScen.MineAllocation.Remove(myUnit.ObjectID);
										myUnit.ParentScen.MineAllocation.Add(myUnit.ObjectID, unguidedWeapon4);
									}
								}
								if (method_12().Type != Submarine._SubmarineType.ROV && method_12().Type != Submarine._SubmarineType.UUV)
								{
									if (!myUnit.Kinematics.DesiredSpeedOverride.HasValue)
									{
										if (!myUnit.Navigator.IsInsideMissionArea(ref CS$<>8__locals41.$VB$Local_myMission.Area, ref CS$<>8__locals41.$VB$Local_myMission.Area_2nm_Buffered, ref CS$<>8__locals41.$VB$Local_myMission.Area_2nm_ChangeCheck, 2, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
										{
											myUnit.SetThrottle(CS$<>8__locals41.$VB$Local_myMission.TransitThrottle_Submarine);
										}
										else
										{
											myUnit.SetThrottle(CS$<>8__locals41.$VB$Local_myMission.StationThrottle_Submarine);
										}
									}
								}
								else
								{
									if ((double)num13 > 0.5)
									{
										if (!method_12().IsTetheredROV)
										{
											myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
										}
										else
										{
											myUnit.SetThrottle(ActiveUnit.Throttle.Full);
										}
									}
									else if ((double)num13 > 0.1)
									{
										myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
									}
									else
									{
										myUnit.DesiredSpeed = Math.Max(1f, num13 * 10f);
									}
									myUnit.DesiredAltitude = ((Module_Unit.Unit)unguidedWeapon4).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
								}
								if (method_12().IsTetheredROV)
								{
									ActiveUnit activeUnit5 = myUnit.DockingOps.get_AssignedHostUnit(PickNewAssignedHost: false);
									if (!Information.IsNothing((object)activeUnit5))
									{
										if (activeUnit5.RangeToUnit_Horiz(unguidedWeapon4) < num13)
										{
											activeUnit5.DesiredSpeed = 0f;
										}
										else if ((double)myUnit.RangeToUnit_Horiz(activeUnit5) * 1852.0 < (double)(method_12().ROVControlRadius_m - 20))
										{
											if (activeUnit5.CurrentSpeed > myUnit.CurrentSpeed)
											{
												activeUnit5.DesiredSpeed = myUnit.CurrentSpeed;
											}
										}
										else if ((float)myUnit.Kinematics.GetMaximumSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Loiter, ValidateAndFixAltitude: false) >= 5f)
										{
											activeUnit5.DesiredSpeed = (float)(0.5 * (double)activeUnit5.Kinematics.GetMaximumSpeed(activeUnit5.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Loiter, ValidateAndFixAltitude: false));
										}
									}
									myUnit.Navigator.bool_0 = false;
								}
							}
							else if (!method_12().IsTetheredROV)
							{
								myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
							}
							else
							{
								myUnit.SetThrottle(ActiveUnit.Throttle.Full);
							}
						}
					}
					myUnit.Navigator.FollowPlottedCourse(elapsedTime);
					return;
				}
				case ActiveUnit._ActiveUnitStatus.Tasked:
				{
					if (IsEscort)
					{
						HeadToNearestEscortSubject();
						return;
					}
					if (myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Mining)
					{
						method_20(elapsedTime);
						return;
					}
					if (myUnit.ActiveMissionOrPackage().MissionClass != Mission._MissionClass.MineClearing)
					{
						break;
					}
					_Closure$__47-1 closure$__47- = new _Closure$__47-1(closure$__47-);
					closure$__47-.$VB$Me = this;
					MineClearingMission mineClearingMission2 = (MineClearingMission)myUnit.ActiveMissionOrPackage();
					closure$__47-.$VB$Local_MissionArea = mineClearingMission2.Area;
					if (!myUnit.HasMineCountermeasures() && !myUnit.HasMineCounterWeapons())
					{
						if (!myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
						{
							myUnit.Navigator.PlotCourseToArea(mineClearingMission2.Area);
						}
						else
						{
							if (!myUnit.Navigator.PlottedCourseLeadsToMissionArea(ref mineClearingMission2.Area, ref mineClearingMission2.Area_30nm_Buffered, ref mineClearingMission2.Area_30nm_ChangeCheck, 30f, IgnoreTimeToNextEvaluation: false))
							{
								myUnit.Navigator.PlotCourseToArea(mineClearingMission2.Area);
							}
							myUnit.Navigator.FollowPlottedCourse(elapsedTime);
						}
						if (myUnit.Kinematics.DesiredSpeedOverride.HasValue)
						{
							return;
						}
						if (myUnit.Navigator.IsInsideMissionArea(ref mineClearingMission2.Area, ref mineClearingMission2.Area_2nm_Buffered, ref mineClearingMission2.Area_2nm_ChangeCheck, 2, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
						{
							if (!method_12().IsTetheredROV)
							{
								myUnit.SetThrottle(mineClearingMission2.StationThrottle_Submarine);
							}
							else
							{
								myUnit.SetThrottle(ActiveUnit.Throttle.Flank);
							}
						}
						else
						{
							myUnit.SetThrottle(mineClearingMission2.TransitThrottle_Submarine);
						}
						return;
					}
					_Closure$__47-2 arg = default(_Closure$__47-2);
					_Closure$__47-2 CS$<>8__locals31 = new _Closure$__47-2(arg);
					CS$<>8__locals31.$VB$NonLocal_$VB$Closure_2 = closure$__47-;
					CS$<>8__locals31.$VB$Local_LegitTargets = new TList<UnguidedWeapon>();
					Parallel.ForEach(myUnit.get_UnitSide(SetSideOnly: false).Contacts_NonAU, [SpecialName] (string theUW_ObjectID) =>
					{
						UnguidedWeapon value14 = null;
						CS$<>8__locals31.$VB$NonLocal_$VB$Closure_2.$VB$Me.myUnit.ParentScen.UnguidedWeapons.TryGetValue(theUW_ObjectID, out value14);
						if (!Information.IsNothing((object)value14) && value14.IsMine && ((Module_Unit.Unit)value14).get_IsInsideThisArea(CS$<>8__locals31.$VB$NonLocal_$VB$Closure_2.$VB$Local_MissionArea, CS$<>8__locals31.$VB$NonLocal_$VB$Closure_2.$VB$Me.myUnit.ParentScen, UseCache: true))
						{
							CS$<>8__locals31.$VB$Local_LegitTargets.Add(value14);
						}
					});
					TList<UnguidedWeapon> tList = new TList<UnguidedWeapon>();
					foreach (UnguidedWeapon item2 in CS$<>8__locals31.$VB$Local_LegitTargets)
					{
						if ((float)method_12().MaxDepth > ((Module_Unit.Unit)item2).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))
						{
							if (item2.Mine_Targeted != null && item2.Mine_Targeted.IsSubmarine && myUnit.ParentScen.MineAllocation.ContainsKey(item2.Mine_Targeted.ObjectID))
							{
								myUnit.ParentScen.MineAllocation.Remove(item2.Mine_Targeted.ObjectID);
								item2.Mine_Targeted = null;
							}
							continue;
						}
						if (((Module_Unit.Unit)item2).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > -5f)
						{
							if (item2.Mine_Targeted != null && item2.Mine_Targeted.IsSubmarine && myUnit.ParentScen.MineAllocation.ContainsKey(item2.Mine_Targeted.ObjectID))
							{
								myUnit.ParentScen.MineAllocation.Remove(item2.Mine_Targeted.ObjectID);
								item2.Mine_Targeted = null;
							}
							continue;
						}
						if (method_12().IsTetheredROV)
						{
							if ((double)myUnit.RangeToUnit_Horiz(item2) > (double)method_12().ROVControlRadius_m / 1852.0 * 2.0)
							{
								continue;
							}
							ActiveUnit activeUnit2 = myUnit.DockingOps.get_AssignedHostUnit(PickNewAssignedHost: false);
							if (!Information.IsNothing((object)activeUnit2) && ((double)activeUnit2.RangeToUnit_Horiz(method_12()) * 1852.0 > (double)method_12().ROVControlRadius_m || (double)activeUnit2.RangeToUnit_Horiz(item2) * 1852.0 > (double)method_12().ROVControlRadius_m))
							{
								continue;
							}
						}
						if (myUnit.RangeToUnit_Horiz(item2) > 2f)
						{
							continue;
						}
						if (item2.Mine_Targeted != null)
						{
							if (myUnit.ParentScen.MineAllocation.ContainsKey(item2.Mine_Targeted.ObjectID) && !myUnit.ParentScen.MineAllocation.Contains(new KeyValuePair<string, UnguidedWeapon>(item2.Mine_Targeted.ObjectID, item2)))
							{
								item2.Mine_Targeted = null;
							}
							if (item2.Mine_Targeted != null && !item2.Mine_Targeted.Equals(myUnit))
							{
								if (!item2.Mine_Targeted.IsWeapon)
								{
									if (!myUnit.get_UnitSide(SetSideOnly: false).Units.Contains(item2.Mine_Targeted))
									{
										item2.Mine_Targeted = null;
									}
									else if (item2.Mine_Targeted.ActiveMissionOrPackage() != null && item2.Mine_Targeted.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.MineClearing)
									{
										if (myUnit.RangeToUnit_Horiz(item2) < item2.Mine_Targeted.RangeToUnit_Horiz(item2) && myUnit.get_CanSweepMine(item2))
										{
											if (item2.Mine_Targeted != null)
											{
												myUnit.ParentScen.MineAllocation.Remove(item2.Mine_Targeted.ObjectID);
												if (item2.Mine_Targeted.Navigator.HasPlottedCourse() && item2.Mine_Targeted.Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.TerminalPoint)
												{
													item2.Mine_Targeted.Navigator.RemoveWaypoint_Soft(item2.Mine_Targeted.Navigator.PlottedCourse[0], RemoveWingmanWaypoints: false);
												}
												else if (item2.Mine_Targeted.Navigator.PlottedCourse.Count() <= 1)
												{
													item2.Mine_Targeted.Navigator.ClearPlottedCourse();
													item2.Mine_Targeted.Navigator.PlotCourseToStationArea(elapsedTime, AddWaypointToExistingPlottedCourse: false);
												}
											}
											item2.Mine_Targeted = null;
										}
									}
									else
									{
										item2.Mine_Targeted = null;
									}
								}
							}
							else if (item2.Mine_Targeted != null && item2.Mine_Targeted.Equals(myUnit))
							{
								tList.Add(item2);
								if (!myUnit.ParentScen.MineAllocation.ContainsKey(myUnit.ObjectID))
								{
									myUnit.ParentScen.MineAllocation.Add(myUnit.ObjectID, item2);
								}
							}
							if (item2.Mine_Targeted == null)
							{
								tList.Add(item2);
							}
						}
						else
						{
							tList.Add(item2);
						}
					}
					CS$<>8__locals31.$VB$Local_LegitTargets = tList;
					UnguidedWeapon unguidedWeapon2 = null;
					if (CS$<>8__locals31.$VB$Local_LegitTargets.Count > 0 && myUnit.MineCountermeasures.Count > 0)
					{
						while (CS$<>8__locals31.$VB$Local_LegitTargets.Count > 0)
						{
							unguidedWeapon2 = (from theMine in CS$<>8__locals31.$VB$Local_LegitTargets.ToList()
								where theMine != null && myUnit.get_CanSweepMine(theMine)
								orderby Module_Unit.RangeToUnit_Horiz_Angular(myUnit, theMine)
								select theMine).ElementAtOrDefault(0);
							if (unguidedWeapon2 == null || unguidedWeapon2.Mine_Targeted == null || unguidedWeapon2.Mine_Targeted.Equals(myUnit))
							{
								break;
							}
							CS$<>8__locals31.$VB$Local_LegitTargets.Remove(unguidedWeapon2);
						}
					}
					else
					{
						myUnit.ParentScen.MineAllocation.Remove(myUnit.ObjectID);
					}
					if (CS$<>8__locals31.$VB$Local_LegitTargets.Count > 0 && unguidedWeapon2 != null)
					{
						float num2 = myUnit.RangeToUnit_Horiz(unguidedWeapon2);
						if (myUnit.HasMineDisposalCharges)
						{
							ManouverToNeutralizeMine(unguidedWeapon2, num2);
						}
						else
						{
							ManouverToSweepMine(unguidedWeapon2, num2);
						}
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
						Submarine submarine = (Submarine)myUnit;
						if (submarine.Type != Submarine._SubmarineType.ROV && submarine.Type != Submarine._SubmarineType.UUV)
						{
							if (!myUnit.Kinematics.DesiredSpeedOverride.HasValue)
							{
								if (!myUnit.Navigator.IsInsideMissionArea(ref mineClearingMission2.Area, ref mineClearingMission2.Area_2nm_Buffered, ref mineClearingMission2.Area_2nm_ChangeCheck, 2, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
								{
									myUnit.SetThrottle(mineClearingMission2.TransitThrottle_Submarine);
								}
								else
								{
									myUnit.SetThrottle(mineClearingMission2.StationThrottle_Submarine);
								}
							}
						}
						else
						{
							if ((double)num2 > 0.5)
							{
								if (submarine.IsTetheredROV)
								{
									myUnit.SetThrottle(ActiveUnit.Throttle.Full);
								}
								else
								{
									myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
								}
							}
							else if ((double)num2 > 0.1)
							{
								myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
							}
							else
							{
								myUnit.DesiredSpeed = Math.Max(1f, num2 * 10f);
							}
							myUnit.DesiredAltitude = ((Module_Unit.Unit)unguidedWeapon2).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
						}
						myUnit.Navigator.FollowPlottedCourse(elapsedTime);
						return;
					}
					if (myUnit.IsGroupMember())
					{
						if (myUnit.IsGroupLead())
						{
							if (!myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
							{
								myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlotCourseToArea(mineClearingMission2.Area);
							}
							else
							{
								if (!myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlottedCourseLeadsToMissionArea(ref mineClearingMission2.Area, ref mineClearingMission2.Area_30nm_Buffered, ref mineClearingMission2.Area_30nm_ChangeCheck, 30f, IgnoreTimeToNextEvaluation: false))
								{
									myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlotCourseToArea(mineClearingMission2.Area);
								}
								myUnit.Navigator.FollowPlottedCourse(elapsedTime);
							}
						}
						else if (myUnit.CommStuff.IsConnectedToSideNetwork)
						{
							myUnit.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
						}
					}
					else if (!myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
					{
						if (method_12().IsTetheredROV)
						{
							ActiveUnit activeUnit3 = method_12().DockingOps.get_AssignedHostUnit(PickNewAssignedHost: false);
							if (!Information.IsNothing((object)activeUnit3))
							{
								try
								{
									float num3 = myUnit.RangeToUnit_Horiz(activeUnit3);
									if (method_12().IsTetheredROV && (double)num3 * 1852.0 > (double)((Submarine)myUnit).ROVControlRadius_m)
									{
										method_12().set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Module_Unit.BearingToUnit_True(method_12(), activeUnit3));
									}
									else if (myUnit.ParentScen.FifteenthMinuteIsChangingOnThisPulse)
									{
										float distance_NM = (method_12().IsTetheredROV ? ((float)((double)method_12().ROVControlRadius_m / 1852.0)) : ((method_12().Sensors_Cached.Length <= 0) ? 5f : method_12().Sensors_Cached[0].maxRange));
										float num4 = activeUnit3.CurrentHeading;
										if (num4 - 45f <= 0f)
										{
											num4 += 360f;
										}
										int bearing = Math2.NormalizeBearing(GameGeneral.GlobalRNG.Next((int)Math.Round(num4 - 45f), (int)Math.Round(num4 + 46f)));
										double out_lon = default(double);
										double out_lat = default(double);
										Geodesic_EdWilliams.CalcPoint_Williams(activeUnit3.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit3.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, distance_NM, bearing);
										method_12().set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.CalcAzimuth(((ActiveUnit)method_12()).get_Latitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)method_12()).get_Longitude((GlobalVariables.BooleanObject)null), out_lat, out_lon));
									}
									myUnit.Navigator.FollowPlottedCourse(elapsedTime);
								}
								catch (Exception projectError)
								{
									ProjectData.SetProjectError(projectError);
									ProjectData.ClearProjectError();
								}
							}
						}
						else
						{
							myUnit.Navigator.PlotCourseToArea(mineClearingMission2.Area);
						}
					}
					else
					{
						if (!myUnit.Navigator.PlottedCourseLeadsToMissionArea(ref mineClearingMission2.Area, ref mineClearingMission2.Area_30nm_Buffered, ref mineClearingMission2.Area_30nm_ChangeCheck, 30f, IgnoreTimeToNextEvaluation: false))
						{
							myUnit.Navigator.PlotCourseToArea(mineClearingMission2.Area);
						}
						myUnit.Navigator.FollowPlottedCourse(elapsedTime);
					}
					if (myUnit.Kinematics.DesiredSpeedOverride.HasValue)
					{
						return;
					}
					if (myUnit.Navigator.IsInsideMissionArea(ref mineClearingMission2.Area, ref mineClearingMission2.Area_2nm_Buffered, ref mineClearingMission2.Area_2nm_ChangeCheck, 2, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
					{
						if (method_12().IsTetheredROV)
						{
							myUnit.SetThrottle(ActiveUnit.Throttle.Flank);
						}
						else if (method_12().Type == Submarine._SubmarineType.UUV)
						{
							myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
						}
						else
						{
							myUnit.SetThrottle(mineClearingMission2.StationThrottle_Submarine);
						}
					}
					else
					{
						myUnit.SetThrottle(mineClearingMission2.TransitThrottle_Submarine);
					}
					return;
				}
				}
				if (activeUnitStatus == ActiveUnit._ActiveUnitStatus.OnPatrol)
				{
					if (Information.IsNothing((object)myUnit.ActiveMissionOrPackage()))
					{
						activeUnitStatus = ActiveUnit._ActiveUnitStatus.Unassigned;
					}
					else if (myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
					{
						Patrol patrol8 = (Patrol)myUnit.ActiveMissionOrPackage();
						if (Information.IsNothing((object)patrol8))
						{
							activeUnitStatus = ActiveUnit._ActiveUnitStatus.Unassigned;
						}
						else
						{
							if (myUnit.IsGroupMember())
							{
								if (myUnit.IsGroupLead())
								{
									if (myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
									{
										if (!myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlottedCourseLeadsToMissionArea(ref patrol8.PatrolArea, ref patrol8.PatrolArea_30nm_Buffered, ref patrol8.PatrolArea_30nm_ChangeCheck, 30f, IgnoreTimeToNextEvaluation: false))
										{
											myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlotCourseToStationArea(elapsedTime, AddWaypointToExistingPlottedCourse: false);
										}
										myUnit.Navigator.FollowPlottedCourse(elapsedTime);
									}
									else
									{
										myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlotCourseToStationArea(elapsedTime, AddWaypointToExistingPlottedCourse: false);
									}
								}
								else if (myUnit.CommStuff.IsConnectedToSideNetwork)
								{
									myUnit.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
								}
							}
							else if (myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
							{
								if (!myUnit.Navigator.PlottedCourseLeadsToMissionArea(ref patrol8.PatrolArea, ref patrol8.PatrolArea_30nm_Buffered, ref patrol8.PatrolArea_30nm_ChangeCheck, 30f, IgnoreTimeToNextEvaluation: false))
								{
									myUnit.Navigator.PlotCourseToStationArea(elapsedTime, AddWaypointToExistingPlottedCourse: false);
								}
								myUnit.Navigator.FollowPlottedCourse(elapsedTime);
							}
							else
							{
								myUnit.Navigator.PlotCourseToStationArea(elapsedTime, AddWaypointToExistingPlottedCourse: false);
							}
							if (!myUnit.Kinematics.DesiredSpeedOverride.HasValue)
							{
								myUnit.Kinematics.AdjustSpeedForCavitation();
							}
						}
						int value9 = (int)myUnit.Doctrine.get_RechargePercentagePatrol(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false).Value;
						if (!RiseToPeriscopeDepthForRechargeIfNecessary(value9, UseAIPifAvailable: false, IsAttackRechargeSetting: false) && !method_12().Kinematics.DesiredAltitudeOverride)
						{
							method_18(elapsedTime);
						}
					}
				}
				switch (activeUnitStatus)
				{
				case ActiveUnit._ActiveUnitStatus.OnSupportMission:
					if (!Information.IsNothing((object)myUnit.ActiveMissionOrPackage()))
					{
						if (myUnit.ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Support)
						{
							return;
						}
						if (!myUnit.IsGroupMember())
						{
							myUnit.Navigator.FollowSupportMissionCourse(elapsedTime, myUnit.Navigator.IsInSupportTransit);
						}
						else if (!myUnit.IsGroupLead())
						{
							if (myUnit.CommStuff.IsConnectedToSideNetwork)
							{
								myUnit.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
							}
							int value10 = (int)myUnit.Doctrine.get_RechargePercentagePatrol(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false).Value;
							RiseToPeriscopeDepthForRechargeIfNecessary(value10, UseAIPifAvailable: false, IsAttackRechargeSetting: false);
						}
						else
						{
							myUnit.Navigator.FollowSupportMissionCourse(elapsedTime, myUnit.Navigator.IsInSupportTransit);
						}
					}
					else
					{
						activeUnitStatus = ActiveUnit._ActiveUnitStatus.Unassigned;
					}
					return;
				case ActiveUnit._ActiveUnitStatus.OnFerryMission:
					if (Information.IsNothing((object)myUnit.ActiveMissionOrPackage()))
					{
						activeUnitStatus = ActiveUnit._ActiveUnitStatus.Unassigned;
					}
					else
					{
						if (myUnit.ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Ferry)
						{
							break;
						}
						FerryMission ferryMission3 = (FerryMission)myUnit.ActiveMissionOrPackage();
						if (!myUnit.Kinematics.DesiredSpeedOverride.HasValue && ferryMission3.FerryThrottle_Submarine.HasValue)
						{
							_ = ferryMission3.FerryThrottle_Submarine.Value;
						}
						if (!myUnit.Kinematics.DesiredAltitudeOverride)
						{
							if (Information.IsNothing((object)ferryMission3.FerryAltitude_Submarine))
							{
								method_12().Kinematics.GetMinimumAltitude();
							}
							else
							{
								_ = ferryMission3.FerryAltitude_Submarine.Value;
							}
						}
						else
						{
							_ = myUnit.DesiredAltitude;
						}
						if (!myUnit.IsGroupWingman())
						{
							if (!Information.IsNothing((object)myUnit.DockingOps.ActualDestinationHost))
							{
								ReturnToBase(elapsedTime);
								break;
							}
							string text = "";
							if (Operators.CompareString(myUnit.Name, myUnit.UnitClass, false) != 0)
							{
								text = " (" + myUnit.UnitClass + ")";
							}
							myUnit.ParentScen.AddMessage("Submarine: " + myUnit.Name + text + " is assigned to a ferry mission but it cannot dock at the desired destination. Unassigning submarine and returning to nearest base.", myUnit.Name + " cannot dock at destination; aborting", LoggedMessage.MessageType.DockingOps, 0, null, myUnit.get_UnitSide(SetSideOnly: false));
							ActiveUnit activeUnit6 = myUnit;
							Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
							activeUnit6.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: false, ref Result);
							myUnit.DockingOps.AttemptToRTB(ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB, GroupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, DetachFromGroup: true, ClearPlottedCourse: true);
						}
						else
						{
							myUnit.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
						}
					}
					break;
				}
				if (myUnit.IsOnActiveCargoMission)
				{
					Manouver_CargoMission(elapsedTime);
				}
				else if (myUnit.IsGroupMember())
				{
					if (myUnit.CommStuff.IsConnectedToSideNetwork)
					{
						myUnit.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
					}
					int value11 = (int)myUnit.Doctrine.get_RechargePercentagePatrol(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false).Value;
					RiseToPeriscopeDepthForRechargeIfNecessary(value11, UseAIPifAvailable: false, IsAttackRechargeSetting: false);
				}
				else if (myUnit.Status == ActiveUnit._ActiveUnitStatus.Unassigned)
				{
					if (!myUnit.Navigator.HasPlottedCourse())
					{
						myUnit.DesiredSpeed = 0f;
					}
					if (myUnit.Kinematics.DesiredAltitudeOverride)
					{
						FollowDepthPreset(CheckThreats: true);
					}
				}
				return;
			}
			if (myUnit.IsOnActiveMiningMission)
			{
				myUnit.AI.MiningInfo = null;
			}
			switch (myUnit.DockingOps.Condition)
			{
			case ActiveUnit_DockingOps._DockingOpsCondition.RechargingBatteries:
				myUnit.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.RTB;
				ReturnToBase(elapsedTime);
				break;
			case ActiveUnit_DockingOps._DockingOpsCondition.RTB:
				if (myUnit.IsGroupMember())
				{
					myUnit.DetachUnit(NotifyPlayer: false, ClearPlottedCourse: true, UseFlightplan: false);
				}
				ReturnToBase(elapsedTime);
				if (myUnit != null)
				{
					int value13 = (int)myUnit.Doctrine.get_RechargePercentagePatrol(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false).Value;
					RiseToPeriscopeDepthForRechargeIfNecessary(value13, UseAIPifAvailable: true, IsAttackRechargeSetting: false);
				}
				break;
			case ActiveUnit_DockingOps._DockingOpsCondition.Underway:
			{
				ReturnToBase(elapsedTime);
				int value12 = (int)myUnit.Doctrine.get_RechargePercentagePatrol(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false).Value;
				RiseToPeriscopeDepthForRechargeIfNecessary(value12, UseAIPifAvailable: true, IsAttackRechargeSetting: false);
				break;
			}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100825", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_20(float float_2)
	{
		MiningMission miningMission = (MiningMission)myUnit.ActiveMissionOrPackage();
		if (myUnit.AI.MiningInfo == null)
		{
			myUnit.AI.MiningInfo = new MiningMission.MiningInformation(null, miningMission.MinesLaidInSets, miningMission.MinesLaidInterval, miningMission.MinesLaidMethod, miningMission.MinesLaidSetInterval);
		}
		if (miningMission.MovementStyle == Patrol.PatrolMovementStyle.RepeatableLoop)
		{
			bool isInTransit = myUnit.Navigator.SupportMission_NextRefPoint == miningMission.Area[0];
			myUnit.Navigator.FollowPatrolRepeatableLoopCourse(float_2, isInTransit);
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
		if (!myUnit.IsGroupMember())
		{
			if (myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
			{
				if (!myUnit.Navigator.IsInsideMissionArea(ref miningMission.Area, ref miningMission.Area_1nm_Buffered, ref miningMission.Area_1nm_ChangeCheck, 1, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
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
						myUnit.Navigator.FollowPlottedCourse(float_2);
					}
				}
			}
			else if (!myUnit.Navigator.IsInsideMissionArea(ref miningMission.Area, ref miningMission.Area, ref miningMission.Area_ChangeCheck, 0, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
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
									goto IL_0598;
								}
							}
							num2 = Math2.NormalizeBearing(desiredHeading + (float)GameGeneral.GlobalRNG.Next(45) - (float)GameGeneral.GlobalRNG.Next(45));
							goto IL_0598;
						}
						goto IL_0869;
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
		else if (myUnit.IsGroupLead())
		{
			if (!myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
			{
				myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlotCourseToArea(miningMission.Area);
				if (myUnit.AI.MiningInfo != null)
				{
					myUnit.AI.MiningInfo.ResetMiningInfo(myUnit, miningMission);
				}
			}
			else if (myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.IsInsideMissionArea(ref miningMission.Area, ref miningMission.Area_1nm_Buffered, ref miningMission.Area_1nm_ChangeCheck, 1, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
			{
				if (myUnit.AI.MiningInfo != null && !myUnit.AI.MiningInfo.StartedMining)
				{
					myUnit.AI.MiningInfo.StartedMining = true;
				}
			}
			else if (!myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlottedCourseLeadsToMissionArea(ref miningMission.Area, ref miningMission.Area_30nm_Buffered, ref miningMission.Area_30nm_ChangeCheck, 30f, IgnoreTimeToNextEvaluation: false))
			{
				myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlotCourseToArea(miningMission.Area);
				if (myUnit.AI.MiningInfo != null)
				{
					myUnit.AI.MiningInfo.ResetMiningInfo(myUnit, miningMission);
				}
			}
			else
			{
				myUnit.Navigator.FollowPlottedCourse(float_2);
			}
		}
		else if (myUnit.CommStuff.IsConnectedToSideNetwork)
		{
			myUnit.Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(float_2);
		}
		goto IL_0869;
		IL_0869:
		if (Information.IsNothing((object)method_12().Kinematics.DesiredSpeedOverride))
		{
			if (!myUnit.Navigator.IsInsideMissionArea(ref miningMission.Area, ref miningMission.Area_2nm_Buffered, ref miningMission.Area_2nm_ChangeCheck, 2, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
			{
				myUnit.SetThrottle(miningMission.TransitThrottle_Submarine);
			}
			else
			{
				myUnit.SetThrottle(miningMission.StationThrottle_Submarine);
			}
		}
		if (method_12().Kinematics.DesiredAltitudeOverride)
		{
			if (!method_12().IsNuke && !IsBatteryRechargePossible(IsAttackRechargeSetting: false, null))
			{
				if (method_12().DesiredAltitude >= -20f)
				{
					method_12().Kinematics.DesiredAltitudeOverride = false;
				}
				else if (Math.Round(Math.Min(-20f, OverLayerDepth(method_12()))) < -20.0)
				{
					method_12().DesiredAltitude = Math.Min(-20f, OverLayerDepth(method_12()));
				}
			}
			else
			{
				FollowDepthPreset(CheckThreats: true);
			}
		}
		else if (!myUnit.Navigator.IsInsideMissionArea(ref miningMission.Area, ref miningMission.Area_2nm_Buffered, ref miningMission.Area_2nm_ChangeCheck, 2, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
		{
			if (miningMission.TransitDepth_Submarine.HasValue)
			{
				float value = miningMission.TransitDepth_Submarine.Value;
				if (Math.Round(value) >= -20.0 && !IsBatteryRechargePossible(IsAttackRechargeSetting: false, null))
				{
					myUnit.DesiredAltitude = Math.Min(-20f, OverLayerDepth(method_12()));
				}
				else
				{
					myUnit.DesiredAltitude = value;
				}
			}
			else
			{
				method_12().DesiredAltitude = Math.Min(-20f, OverLayerDepth(method_12()));
			}
		}
		else if (!miningMission.StationDepth_Submarine.HasValue)
		{
			if (myUnit.TimeSinceLastThreatDetection_ESM < 1800f && !IsBatteryRechargePossible(IsAttackRechargeSetting: false, null))
			{
				myUnit.DesiredAltitude = -40f;
			}
			else
			{
				myUnit.DesiredAltitude = -20f;
			}
		}
		else
		{
			float value2 = miningMission.StationDepth_Submarine.Value;
			if (Math.Round(value2) >= -20.0 && !IsBatteryRechargePossible(IsAttackRechargeSetting: false, null))
			{
				myUnit.DesiredAltitude = -40f;
			}
			else
			{
				myUnit.DesiredAltitude = value2;
			}
		}
		return;
		IL_0598:
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
		goto IL_0869;
	}

	public override void OptimizeAltSpeedForNextEngagement(float elapsedTime, Weapon weaponBeingGuided, Weapon mostSuitableWeapon)
	{
		Weapon weapon = mostSuitableWeapon;
		if (myUnit == null || Information.IsNothing((object)PrimaryTarget))
		{
			return;
		}
		try
		{
			Doctrine doctrine = myUnit.Doctrine;
			if (Information.IsNothing((object)weapon))
			{
				Side side = myUnit.get_UnitSide(SetSideOnly: false);
				ref ActiveUnit theAttacker = ref myUnit;
				Contact theTarget = PrimaryTarget;
				List<Weapon> list = side.WeaponsLeftToFireAtThisTarget(ref theAttacker, ref theTarget);
				PrimaryTarget = theTarget;
				List<Weapon> list2 = list;
				weapon = ((list2.Count <= 0) ? myUnit.Weaponry.MostSuitableWeaponForThisTarget(PrimaryTarget, CheckIfWithinRange: false, CheckIfWithinAltitude: false, CheckWRA: true, doctrine) : list2.OrderByDescending([SpecialName] (Weapon theWeapon) => theWeapon.get_MaxRangeForThisTarget(myUnit, PrimaryTarget, CheckWRA: true, doctrine, ManualFire: false)).ElementAtOrDefault(0));
			}
			if (Information.IsNothing((object)weapon))
			{
				return;
			}
			float num = weapon.get_MaxRangeForThisTarget(myUnit, PrimaryTarget, CheckWRA: true, doctrine, ManualFire: false);
			float num2 = myUnit.RangeToUnit_Horiz(PrimaryTarget);
			if (!myUnit.Kinematics.DesiredAltitudeOverride)
			{
				float closureSpeed = ((PrimaryTarget.CurrentSpeed != 0f) ? Module_Unit.ClosureSpeed(myUnit, PrimaryTarget, myUnit.CurrentSpeed, myUnit.CurrentHeading) : myUnit.CurrentSpeed);
				Weapon._WeaponType type = weapon.Type;
				float num3 = default(float);
				if (type != Weapon._WeaponType.Rocket && type != Weapon._WeaponType.Gun)
				{
					if (weapon.ParentScen.FeatureCompatibility.get_WeaponAGL_ASL(weapon.ParentScen.DBConnection) && weapon.MinLaunchAlt_AGL == 0f && weapon.MaxLaunchAlt_AGL == 0f)
					{
						num3 = weapon.MinLaunchAlt_ASL;
						_ = weapon.MaxLaunchAlt_ASL;
					}
					else
					{
						num3 = weapon.MinLaunchAlt_AGL;
						_ = weapon.MaxLaunchAlt_AGL;
					}
				}
				else if (Module_Unit.RangeToUnit_Slant(myUnit, PrimaryTarget) > num)
				{
					num3 = (float)(Math.Sqrt(2.0) / 2.0 * (double)num * 1852.0);
				}
				float num4 = default(float);
				if (num3 < myUnit.DesiredAltitude)
				{
					num4 = (myUnit.DesiredAltitude - num3) / myUnit.Kinematics.DiveRate_Nominal();
				}
				float num5;
				if (num2 > num)
				{
					float distance = num2 - num;
					num5 = myUnit.ETA_To_Location(closureSpeed, distance);
				}
				else
				{
					num5 = 0f;
				}
				if (num5 < 0f)
				{
					return;
				}
				if (num4 >= num5)
				{
					if (num3 < myUnit.DesiredAltitude)
					{
						if (!PrimaryTarget.AltitudeIsKnown)
						{
							if (Math.Round(myUnit.DesiredAltitude) > -20.0)
							{
								myUnit.DesiredAltitude = -20f;
							}
						}
						else if (((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < num3 && myUnit.DesiredAltitude < num3)
						{
							myUnit.DesiredAltitude = num3;
						}
					}
					else if (num3 > myUnit.DesiredAltitude)
					{
						myUnit.DesiredAltitude = num3;
					}
				}
			}
			if (!myUnit.Kinematics.DesiredSpeedOverride.HasValue && (double)num * 1.2 < (double)num2)
			{
				if (weapon.MaxLaunchSpeed != 0 && (float)weapon.MaxLaunchSpeed < myUnit.CurrentSpeed)
				{
					myUnit.DesiredSpeed = weapon.MaxLaunchSpeed;
				}
				if (weapon.MinLaunchSpeed != 0 && (float)weapon.MinLaunchSpeed > myUnit.CurrentSpeed)
				{
					myUnit.DesiredSpeed = weapon.MinLaunchSpeed;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100826", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	static Submarine_AI()
	{
		Class72.smethod_20();
	}
}
