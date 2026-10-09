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
using ThreadSafeCollections;

namespace Command_Core;

public class Weapon_AI : ActiveUnit_AI
{
	public enum _SnakeDirection : byte
	{
		Left,
		Right
	}

	[CompilerGenerated]
	internal sealed class _Closure$__20-0
	{
		public Weapon $VB$Local_myWeapon;

		public _Closure$__20-0(_Closure$__20-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_myWeapon = arg0.$VB$Local_myWeapon;
			}
		}

		[SpecialName]
		internal bool _Lambda$__1(Contact theC)
		{
			return $VB$Local_myWeapon.Sensory.HasAnyCurrentLocalTrackOnThisContact(theC);
		}

		[SpecialName]
		internal bool _Lambda$__6(Contact theC)
		{
			return theC.DetectedEmissions.Keys.Contains($VB$Local_myWeapon.ARM_SpecifiedEMission.Key);
		}

		static _Closure$__20-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__34-0
	{
		public Weapon $VB$Local_myWeapon;

		public _Closure$__34-0(_Closure$__34-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_myWeapon = arg0.$VB$Local_myWeapon;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0((Weapon, float, float) theTuple)
		{
			return theTuple.Item1 == $VB$Local_myWeapon;
		}

		static _Closure$__34-0()
		{
			Class72.smethod_20();
		}
	}

	protected _SnakeDirection? SnakeDirection;

	private bool bool_0;

	private float float_0;

	private float float_1;

	public Geopoint_Struct? LatestPointUsedToDetermineAttitude;

	public Geopoint_Struct? LatestValidInterceptPoint;

	public string LatestValidInterceptPointTargetID;

	public Geopoint_Struct InterceptPointHistory;

	public bool TerminalDive
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public override Contact PrimaryTarget
	{
		get
		{
			return _PrimaryTarget;
		}
		set
		{
			try
			{
				Weapon weapon = (Weapon)myUnit;
				Contact primaryTarget = _PrimaryTarget;
				bool num = value != _PrimaryTarget;
				if (num)
				{
					if (_PrimaryTarget != null && value == null)
					{
						_LastKnownTargetLocation = new GeoPoint(((Module_Unit.Unit)_PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)_PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)_PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
					}
					if (value != null)
					{
						if (!IsTargetingThisContact(value) && weapon.ValidTargets.Radar)
						{
							myUnit.AI.TargetThisContact(value, AddedManually: false, PriorityTarget: false, TargetingEntry._TargetingBehavior.AutoTargeted);
							if (!weapon.ARM_SpecifiedEmissionIsMandatory)
							{
								TObservableDictionary<int, EmissionContainer> detectedEmissions = value.DetectedEmissions;
								Side theSide = ((ActiveUnit)weapon).get_UnitSide(SetSideOnly: false);
								Random theRNG = GameGeneral.GlobalRNG;
								if (weapon.ARM_DetermineEmissionToTrack(detectedEmissions, theSide, value, ShootAtTurnedOffRadar: false, ref theRNG))
								{
									weapon.ARM_SpecifiedEmissionIsMandatory = true;
								}
							}
						}
					}
					else if (_PrimaryTarget != null && _PrimaryTarget.IsAir_Missile_Orbital_Contact && _PrimaryTarget.AltitudeIsKnown)
					{
						myUnit.DesiredAltitude = ((Module_Unit.Unit)_PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
					}
					weapon.Navigator.ABMInterceptPoint = null;
				}
				if (weapon.IsReEntryVehicle | (weapon.IsAAWCapable && weapon.HasTerminalGuidance))
				{
					_PrimaryTarget = value;
				}
				else if (value == null && !Information.IsNothing((object)_PrimaryTarget) && _PrimaryTarget.IsGroundContact && !weapon.ValidTargets.Radar && weapon.Comms_ReadOnly.Count() == 0)
				{
					weapon.GoDumb();
				}
				else if (value == null && !Information.IsNothing((object)_PrimaryTarget) && _PrimaryTarget.IsShipContact && !weapon.ValidTargets.Radar && weapon.Comms_ReadOnly.Count() == 0)
				{
					if (weapon.Guidance == Weapon.WeaponGuidanceType.SemiActive)
					{
						weapon.GoDumb();
					}
					else if (weapon.CruiseAltitude_AGL == 0f && weapon.CruiseAltitude_ASL == 0f && weapon.Comms_ReadOnly.Count() == 0)
					{
						weapon.GoDumb();
					}
					else
					{
						_PrimaryTarget = value;
					}
				}
				else if (Information.IsNothing((object)value) && !Information.IsNothing((object)primaryTarget) && primaryTarget.Type != Contact_Base.ContactType.ActivationPoint && !Information.IsNothing((object)_PrimaryTarget) && weapon.ValidTargets.Radar && weapon.Comms_ReadOnly.Count() == 0 && weapon.Flags.ARMTargetMemory)
				{
					if (!_PrimaryTarget.get_IsDestroyed(myUnit.ParentScen))
					{
						weapon.GoDumb();
					}
					else
					{
						EngageTargets(weapon.ParentScen.GameResolution);
					}
				}
				else
				{
					_PrimaryTarget = value;
				}
				if (primaryTarget != null)
				{
					primaryTarget.IncomingGuidedWeapons = null;
				}
				if (value != null)
				{
					value.IncomingGuidedWeapons = null;
				}
				if (_PrimaryTarget != null)
				{
					_PrimaryTarget_Type = _PrimaryTarget.Type;
				}
				if (num && !weapon.IsDLZconstruct)
				{
					if (_PrimaryTarget != null)
					{
						float gameResolution = weapon.ParentScen.GameResolution;
						weapon.ImpactsOnThisPulse_ActualUnit = weapon.AboutToImpact_ActualTarget(gameResolution);
						weapon.ImpactsOnThisPulse_Contact = weapon.AboutToImpact_Contact(gameResolution);
					}
					else
					{
						weapon.ImpactsOnThisPulse_ActualUnit = false;
						weapon.ImpactsOnThisPulse_Contact = false;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100965", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Weapon theAU)
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		//IL_0419: Unknown result type (might be due to invalid IL or missing references)
		//IL_0420: Expected O, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Expected O, but got Unknown
		try
		{
			if (Operators.CompareString(theNode.ChildNodes[0].Name, "ActiveUnit_AI", false) == 0)
			{
				theNode = theNode.ChildNodes[0];
			}
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				try
				{
					switch (val.Name)
					{
					case "SnakeAxis":
						theAU.AI.SnakeAxis = XmlConvert.ToSingle(val.InnerText.Replace(",", "."));
						break;
					case "PrimaryTarget":
						if (!val.InnerText.Contains("Aimpoint"))
						{
							if (val.InnerText.Contains("ActivationPoint"))
							{
								theAU.AI._PrimaryTarget = ActivationPointContact.FromString(val.InnerText);
							}
							else if (val.ChildNodes.Count > 0 && Operators.CompareString(val.FirstChild.Name, "Contact", false) == 0)
							{
								Weapon_AI aI = theAU.AI;
								XmlNode theNode2 = val.FirstChild;
								aI._PrimaryTarget = Contact.FromXML(ref theNode2, ref theDictionary);
							}
							else
							{
								theAU.AI._PrimaryTarget = Contact.FromXML(val.InnerText, ref theDictionary);
							}
						}
						else
						{
							theAU.AI._PrimaryTarget = AimpointContact.FromString(val.InnerText);
						}
						if (theAU.AI._PrimaryTarget == null && Debugger.IsAttached)
						{
							Debugger.Break();
						}
						break;
					case "Threats":
						if (theAU.AI._Threats == null)
						{
							theAU.AI._Threats = new List<Contact>();
						}
						foreach (XmlNode childNode2 in val.ChildNodes)
						{
							XmlNode theNode4 = childNode2;
							Contact contact = Contact.FromXML(ref theNode4, ref theDictionary);
							if (contact != null)
							{
								theAU.AI._Threats.Add(contact);
							}
						}
						break;
					case "PrimaryThreat":
						theAU.AI._PrimaryThreat = Contact.FromXML(val.InnerText, ref theDictionary);
						break;
					case "VirtualTargetVelocity":
						theAU.AI.float_1 = XmlConvert.ToSingle(val.InnerText);
						break;
					case "MSF":
						uint.TryParse(val.InnerText, out theAU.AI._Mission_State_Flags);
						break;
					case "PrimaryTarget_LastKnown_Lon":
						theAU.AI.PrimaryTarget_LastKnown_Lon = XmlConvert.ToDouble(val.InnerText);
						break;
					case "VirtualTargetAltitude":
						theAU.AI.float_0 = XmlConvert.ToSingle(val.InnerText);
						break;
					case "IE":
						theAU.AI.IsEscort = true;
						break;
					case "TargetList":
						theAU.AI._TargetList = new ObservableDictionary<string, TargetingEntry>();
						foreach (XmlNode childNode3 in val.ChildNodes)
						{
							XmlNode theNode3 = childNode3;
							TargetingEntry targetingEntry = TargetingEntry.FromXML(ref theNode3, ref theDictionary);
							if (targetingEntry.Target != null)
							{
								theAU.AI._TargetList.Add(targetingEntry.Target.ObjectID, targetingEntry);
							}
						}
						break;
					case "PrimaryTarget_LastKnown_Lat":
						theAU.AI.PrimaryTarget_LastKnown_Lat = XmlConvert.ToDouble(val.InnerText);
						break;
					case "LatestValidInterceptPoint":
						theAU.AI.LatestValidInterceptPoint = Geopoint_Struct.FromXML(val.FirstChild, null);
						break;
					case "LatestPointUsedToDetermineAttitude":
						theAU.AI.LatestPointUsedToDetermineAttitude = Geopoint_Struct.FromXML(val.FirstChild, null);
						break;
					case "LatestValidInterceptPointTargetID":
						theAU.AI.LatestValidInterceptPointTargetID = val.InnerText;
						break;
					case "PrimaryTarget_LastKnown_Alt":
						theAU.AI.PrimaryTarget_LastKnown_Altitude = XmlConvert.ToSingle(val.InnerText);
						break;
					case "PrimaryTarget_Type":
						if (!Versioned.IsNumeric((object)val.InnerText))
						{
							theAU.AI._PrimaryTarget_Type = (Contact_Base.ContactType)Enum.Parse(typeof(Contact_Base.ContactType), val.InnerText, ignoreCase: true);
						}
						else
						{
							theAU.AI._PrimaryTarget_Type = (Contact_Base.ContactType)Conversions.ToByte(val.InnerText);
						}
						break;
					case "PTOE":
					case "PrimaryTargetOverrideExists":
						theAU.AI.PrimaryTargetOverrideExists = Misc.ParseBool(val.InnerText);
						break;
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 200049", ex2.Message);
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
			ex4?.Data.Add("Error at 100964", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
		try
		{
			if (PrimaryTarget != null)
			{
				if (PrimaryTarget.Type != Contact_Base.ContactType.Aimpoint && PrimaryTarget.Type != Contact_Base.ContactType.ActivationPoint)
				{
					if (ObjectsAlreadySerialized.Contains(PrimaryTarget.ObjectID))
					{
						theWriter.WriteElementString("PrimaryTarget", PrimaryTarget.ObjectID);
					}
					else
					{
						theWriter.WriteStartElement("PrimaryTarget");
						theWriter.WriteRaw(PrimaryTarget.ToXML(ObjectsAlreadySerialized, myUnit.get_UnitSide(SetSideOnly: false)));
						theWriter.WriteEndElement();
					}
				}
				else
				{
					theWriter.WriteElementString("PrimaryTarget", PrimaryTarget.ObjectID);
				}
			}
			if (!Information.IsNothing((object)_PrimaryTarget_Type))
			{
				XmlWriter obj = theWriter;
				int primaryTarget_Type = (int)_PrimaryTarget_Type;
				obj.WriteElementString("PrimaryTarget_Type", primaryTarget_Type.ToString());
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
			if (float_0 != 0f)
			{
				theWriter.WriteElementString("VirtualTargetAltitude", XmlConvert.ToString(float_0));
			}
			if (float_1 != 0f)
			{
				theWriter.WriteElementString("VirtualTargetVelocity", XmlConvert.ToString(float_1));
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
			if (HoldPosition)
			{
				theWriter.WriteElementString("HPos", HoldPosition.ToString());
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
				foreach (TargetingEntry value in _TargetList.Values)
				{
					if (value.Target.ActualUnit != null)
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
			if (LatestPointUsedToDetermineAttitude.HasValue)
			{
				theWriter.WriteElementString("LatestPointUsedToDetermineAttitude", LatestPointUsedToDetermineAttitude.Value.ToXML(null));
			}
			if (LatestValidInterceptPoint.HasValue)
			{
				theWriter.WriteElementString("LatestValidInterceptPoint", LatestValidInterceptPoint.Value.ToXML(null));
			}
			if (!string.IsNullOrEmpty(LatestValidInterceptPointTargetID))
			{
				theWriter.WriteElementString("LatestValidInterceptPointTargetID", LatestValidInterceptPointTargetID);
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
			ex2?.Data.Add("Error at 100021", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public Weapon_AI(Weapon theUnit)
		: base(theUnit)
	{
	}

	public override void EvaluateTargets(float elapsedTime, bool IgnoreContacStance, bool Immediately)
	{
	}

	public override void EvaluateThreats(float elapsedtime)
	{
	}

	internal bool IsInWeaponCurrentRange(Contact ContactToEvaluate)
	{
		Weapon weapon = (Weapon)myUnit;
		if (weapon.MaxSurfaceRange - myUnit.Journey.ComputeTotalDistance() <= Math2.CalcDist(weapon.get_Latitude((GlobalVariables.BooleanObject)null), weapon.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)ContactToEvaluate).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)ContactToEvaluate).get_Longitude((GlobalVariables.BooleanObject)null)))
		{
			return false;
		}
		return true;
	}

	public override void DeterminePrimaryTarget(float elapsedTime, bool IgnoreTimeToNextEvaluation, bool CheckCombatRadius)
	{
		_Closure$__20-0 arg = default(_Closure$__20-0);
		_Closure$__20-0 CS$<>8__locals31 = new _Closure$__20-0(arg);
		if (!DeterminePrimaryTarget_Enabled || myUnit == null)
		{
			return;
		}
		CS$<>8__locals31.$VB$Local_myWeapon = (Weapon)myUnit;
		if (CS$<>8__locals31.$VB$Local_myWeapon.Type == Weapon._WeaponType.Sonobuoy)
		{
			return;
		}
		if (PrimaryTarget != null && PrimaryTarget.get_IsDestroyed(myUnit.ParentScen))
		{
			PrimaryTarget = null;
		}
		CS$<>8__locals31.$VB$Local_myWeapon.DetermineGuidance();
		if (CS$<>8__locals31.$VB$Local_myWeapon.Guidance == Weapon.WeaponGuidanceType.Inertial && (myUnit.IsTorpedo || CS$<>8__locals31.$VB$Local_myWeapon.IsReEntryVehicle))
		{
			return;
		}
		try
		{
			if (PrimaryTarget != null)
			{
				PrimaryTarget_LastKnown_Lat = ((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null);
				PrimaryTarget_LastKnown_Lon = ((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null);
				if (PrimaryTarget.Type == Contact_Base.ContactType.ActivationPoint && CS$<>8__locals31.$VB$Local_myWeapon.Navigator.HasPlottedCourse())
				{
					PrimaryTarget_LastKnown_Altitude = CS$<>8__locals31.$VB$Local_myWeapon.Navigator.PlottedCourse[0].Altitude;
				}
				else
				{
					PrimaryTarget_LastKnown_Altitude = ((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
				}
			}
			if (base.Targets_ReadOnly.Length == 0)
			{
				return;
			}
			List<Contact> list = new List<Contact>();
			list.AddRange(base.Targets_ReadOnly);
			if (!CS$<>8__locals31.$VB$Local_myWeapon.Is_LOAL_capable)
			{
				switch (CS$<>8__locals31.$VB$Local_myWeapon.Guidance)
				{
				case Weapon.WeaponGuidanceType.TimesharedSemiActive_Plus_Active:
				{
					if (!Information.IsNothing((object)CS$<>8__locals31.$VB$Local_myWeapon.DataLinkParent) || list.Count <= 0)
					{
						break;
					}
					if (list.Count == 1)
					{
						PrimaryTarget = list[0];
						break;
					}
					if (!Information.IsNothing((object)PrimaryTarget))
					{
						foreach (Contact item in list)
						{
							if (item?.ActualUnit != null && PrimaryTarget?.ActualUnit != null && ActiveUnit_Sensory.ContactsAreOfSameActualUnit(item, PrimaryTarget))
							{
								return;
							}
						}
					}
					IEnumerable<Contact> source2 = list.OrderBy([SpecialName] (Contact theC) => Module_Unit.RangeToUnit_Slant(myUnit, theC));
					PrimaryTarget = source2.ElementAtOrDefault(0);
					break;
				}
				case Weapon.WeaponGuidanceType.SemiActive_Plus_Active:
				{
					if (!myUnit.Sensors_Cached[0].IsActive() || list.Count <= 0)
					{
						break;
					}
					if (base.Targets_ReadOnly.Length == 1)
					{
						PrimaryTarget = list[0];
						break;
					}
					if (!Information.IsNothing((object)PrimaryTarget))
					{
						foreach (Contact item2 in list)
						{
							if (item2?.ActualUnit != null && PrimaryTarget?.ActualUnit != null && ActiveUnit_Sensory.ContactsAreOfSameActualUnit(item2, PrimaryTarget))
							{
								return;
							}
						}
					}
					IEnumerable<Contact> source3 = list.OrderBy([SpecialName] (Contact theC) => Module_Unit.RangeToUnit_Slant(myUnit, theC));
					PrimaryTarget = source3.ElementAtOrDefault(0);
					break;
				}
				case Weapon.WeaponGuidanceType.Passive:
				{
					if (!Information.IsNothing((object)PrimaryTarget) && CS$<>8__locals31.$VB$Local_myWeapon.ValidTargets.Radar && !CS$<>8__locals31.$VB$Local_myWeapon.Flags.ARMTargetMemory && list.Count > 1)
					{
						List<int> list2 = PrimaryTarget.DetectedEmissions.Keys.ToList();
						foreach (int item3 in list2)
						{
							if (item3 == CS$<>8__locals31.$VB$Local_myWeapon.ARM_SpecifiedEMission.Key && !(CS$<>8__locals31.$VB$Local_myWeapon.ARM_SpecifiedEMission.Value.Age <= 20f))
							{
								DropTarget(PrimaryTarget);
								break;
							}
						}
					}
					if ((!Information.IsNothing((object)PrimaryTarget) && (!CS$<>8__locals31.$VB$Local_myWeapon.ValidTargets.Radar || list.Contains(PrimaryTarget))) || (!CS$<>8__locals31.$VB$Local_myWeapon.IsAAWCapable && !CS$<>8__locals31.$VB$Local_myWeapon.ValidTargets.SurfaceVessel && !CS$<>8__locals31.$VB$Local_myWeapon.ValidTargets.Radar))
					{
						break;
					}
					if (CS$<>8__locals31.$VB$Local_myWeapon.ValidTargets.Radar)
					{
						if (!Information.IsNothing((object)CS$<>8__locals31.$VB$Local_myWeapon.ARM_SpecifiedEMission))
						{
							list = list.Where([SpecialName] (Contact theC) => theC.DetectedEmissions.Keys.Contains(CS$<>8__locals31.$VB$Local_myWeapon.ARM_SpecifiedEMission.Key)).ToList();
						}
						if (list.Count > 0)
						{
							CS$<>8__locals31.$VB$Local_myWeapon.ARM_SpecifiedEMission.Value.Age = 0f;
						}
					}
					if (list.Count <= 0)
					{
						break;
					}
					if (list.Count == 1)
					{
						PrimaryTarget = list[0];
						break;
					}
					IEnumerable<Contact> source = list.OrderBy([SpecialName] (Contact theC) => Module_Unit.BearingToUnit_True(myUnit, theC));
					PrimaryTarget = source.ElementAtOrDefault(0);
					break;
				}
				}
			}
			else
			{
				if (myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
				{
					return;
				}
				if (Information.IsNothing((object)PrimaryTarget))
				{
					if (CS$<>8__locals31.$VB$Local_myWeapon.HasGoneAutonomous)
					{
						list = list.Where([SpecialName] (Contact theC) => CS$<>8__locals31.$VB$Local_myWeapon.Sensory.HasAnyCurrentLocalTrackOnThisContact(theC)).ToList();
					}
					IEnumerable<Contact> source4 = from theC in list
						select (theC) into theC
						orderby Module_Unit.RangeToUnit_Horiz_Angular(theC, myUnit)
						select theC;
					if (source4.Count() > 0)
					{
						PrimaryTarget = source4.ElementAtOrDefault(0);
						if (PrimaryTarget != null && PrimaryTarget.ActualUnit != null)
						{
							string text = myUnit.Name + " has locked on to " + PrimaryTarget.ActualUnit.Name;
							myUnit.Message = text;
							myUnit.AddMessage(text, text, LoggedMessage.MessageType.WeaponLogic, 1, new Geopoint_Struct(((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null)));
						}
					}
					return;
				}
				if (!CS$<>8__locals31.$VB$Local_myWeapon.ValidTargets.Radar || CS$<>8__locals31.$VB$Local_myWeapon.Flags.ARMTargetMemory)
				{
					foreach (Contact item4 in list)
					{
						if (Information.IsNothing((object)PrimaryTarget.ActualUnit) || item4.ActualUnit == PrimaryTarget.ActualUnit)
						{
							PrimaryTarget = item4;
							return;
						}
					}
				}
				else
				{
					PrimaryTarget = null;
				}
				if (!CS$<>8__locals31.$VB$Local_myWeapon.HasManInTheLoop && !CS$<>8__locals31.$VB$Local_myWeapon.IsBrilliantWeapon && (Information.IsNothing((object)PrimaryTarget) || !PrimaryTarget.ActualUnit.IsFixedFacility))
				{
					IEnumerable<Contact> enumerable = list.OrderBy([SpecialName] (Contact theC) => Module_Unit.RangeToUnit_Horiz_Angular(theC, myUnit));
					foreach (Contact item5 in enumerable)
					{
						if (IsInWeaponCurrentRange(item5))
						{
							PrimaryTarget = item5;
							break;
						}
					}
				}
				if (CS$<>8__locals31.$VB$Local_myWeapon.ValidTargets.Radar && Information.IsNothing((object)CS$<>8__locals31.$VB$Local_myWeapon.ARM_SpecifiedEMission))
				{
					Weapon weapon = CS$<>8__locals31.$VB$Local_myWeapon;
					TObservableDictionary<int, EmissionContainer> detectedEmissions = PrimaryTarget.DetectedEmissions;
					Side theSide = myUnit.get_UnitSide(SetSideOnly: false);
					Contact primaryTarget = PrimaryTarget;
					Random theRNG = GameGeneral.GlobalRNG;
					weapon.ARM_DetermineEmissionToTrack(detectedEmissions, theSide, primaryTarget, ShootAtTurnedOffRadar: false, ref theRNG);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100967", "");
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
	}

	protected virtual void CircleSearch(float elapsedTime)
	{
		myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, Math2.NormalizeBearing(myUnit.DesiredHeading + 10f * elapsedTime));
		if (myUnit.Kinematics.CanApplyLoiterThrottle() && PrimaryTarget == null)
		{
			myUnit.SetThrottle(ActiveUnit.Throttle.Loiter);
		}
		else
		{
			myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
		}
	}

	public virtual void SnakeSearch()
	{
		try
		{
			MaxSnakeAngle = 8;
			if (!SnakeAxis.HasValue)
			{
				SnakeAxis = myUnit.CurrentHeading;
			}
			if (!SnakeDirection.HasValue)
			{
				SnakeDirection = (_SnakeDirection)GameGeneral.GlobalRNG.Next(0, 1);
			}
			float value = Math2.NormalizeBearing(SnakeAxis.Value - (float)MaxSnakeAngle);
			float value2 = Math2.NormalizeBearing(SnakeAxis.Value + (float)MaxSnakeAngle);
			_SnakeDirection? snakeDirection = SnakeDirection;
			byte? b = (byte?)snakeDirection;
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) != true)
			{
				b = (byte?)snakeDirection;
				if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
				{
					if (Math.Abs(MathFunctions.AngularDifference(myUnit.CurrentHeading, SnakeAxis.Value)) >= (float)MaxSnakeAngle)
					{
						SnakeDirection = _SnakeDirection.Left;
						myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, value);
					}
					else
					{
						myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, value2);
					}
				}
			}
			else if (Math.Abs(MathFunctions.AngularDifference(myUnit.CurrentHeading, SnakeAxis.Value)) >= (float)MaxSnakeAngle)
			{
				SnakeDirection = _SnakeDirection.Right;
				myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, value2);
			}
			else
			{
				myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, value);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100968", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void DeterminePrimaryThreat(float ElapsedTime)
	{
	}

	public override void ManouverTowardsTarget(float elapsedTime)
	{
		if (PrimaryTarget == null)
		{
			return;
		}
		try
		{
			_ = myUnit.CurrentHeading;
			float num = Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null));
			if (myUnit.CurrentHeading == num)
			{
				return;
			}
			float relativeBearing = MathFunctions.GetRelativeBearing(myUnit.CurrentHeading, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null)));
			if (315f > relativeBearing && relativeBearing > 45f && myUnit.CurrentSpeed > PrimaryTarget.CurrentSpeed)
			{
				Manouver_PurePursuit(elapsedTime, 0f, 0f);
				return;
			}
			Weapon.WeaponGuidanceType guidance = ((Weapon)myUnit).Guidance;
			if (guidance == Weapon.WeaponGuidanceType.BeamRiding)
			{
				Manouver_PurePursuit(elapsedTime, 0f, 0f);
				return;
			}
			float? estimatedAverageSpeed = myUnit.DesiredSpeed;
			bool AllowAfterburner = false;
			Manouver_InterceptCourse(elapsedTime, estimatedAverageSpeed, ref AllowAfterburner);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100969", "");
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
	}

	protected bool CheckForGuidanceDropDueToDoctrine(Weapon myWeapon)
	{
		int result;
		if (!myWeapon.IsDLZconstruct && !myWeapon.HasGoneAutonomous && myWeapon.AI.PrimaryTarget != null && (myWeapon.AI.PrimaryTarget.Type == Contact_Base.ContactType.Air || myWeapon.AI.PrimaryTarget.Type == Contact_Base.ContactType.Missile))
		{
			if (myWeapon.FiringParent == null)
			{
				result = 0;
				goto IL_0098;
			}
			int? elementState = myWeapon.FiringParent.Doctrine.GetElementState(Doctrine.DoctrineItem_E.MissileEngagement_ContinueGuidanceForImpossibleIntercept);
			if ((elementState.HasValue ? new bool?(elementState == 1) : ((bool?)null)) == true)
			{
				return true;
			}
		}
		result = 0;
		goto IL_0098;
		IL_0098:
		return (byte)result != 0;
	}

	protected void DropGuidanceDueToDoctrine(Weapon myWeapon)
	{
		myWeapon.GoAutonomous(clearPrimaryTarget: true, clearDatalink: true);
		((ActiveUnit)myWeapon).set_DesiredHeading(ActiveUnit.TurnRate.Max, myUnit.CurrentHeading);
		if (myWeapon.FiringParent != null)
		{
			myWeapon.FiringParent.AddMessage(myWeapon.FiringParent.Name + " dropped guidance for " + myWeapon.Name + " per AAW Guidance doctrine.", "Guidance dropped: " + myWeapon.Name, LoggedMessage.MessageType.UnitAI, 1, new Geopoint_Struct(myWeapon.FiringParent.get_Latitude((GlobalVariables.BooleanObject)null), myWeapon.FiringParent.get_Longitude((GlobalVariables.BooleanObject)null)));
		}
	}

	protected Geopoint_Struct? SimulateGuidanceUpdatesFromDataLink(bool RecalculatePlottedCourse, bool DropGuidanceOnImpossibleIntercept)
	{
		try
		{
			Weapon weapon = (Weapon)myUnit;
			Geopoint_Struct? result = PrimaryTarget.Location;
			if (weapon.DataLinkParent != null && weapon.GuidanceHasDataLink && PrimaryTarget != null && PrimaryTarget.ActualUnit != null && !PrimaryTarget.ActualUnit.IsFixedFacility)
			{
				if (!PrimaryTarget.IsBallisticTarget())
				{
					if (RecalculatePlottedCourse && (!weapon.UsesBoostCoastModel.Value || !PrimaryTarget.AppearsToBeLoitering || myUnit.RangeToUnit_Horiz(PrimaryTarget) < 5f))
					{
						float weaponNominalSpeed = ((!DropGuidanceOnImpossibleIntercept || !weapon.UsesBoostCoastModel.Value || !(weapon.TimeSinceLaunch > (float)weapon.TotalBurnTime)) ? ((float)myUnit.Kinematics.GetMaximumSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), myUnit.MaxPossibleThrottleSetting, ValidateAndFixAltitude: false)) : myUnit.CurrentSpeed);
						result = weapon.Navigator.ComputeTerminalPoint(weaponNominalSpeed, weapon.DataLinkParent != null && weapon.DataLinkParent.IsAircraft && weapon.IsTorpedo);
					}
				}
				else if (RecalculatePlottedCourse)
				{
					float weaponNominalSpeed2 = ((!DropGuidanceOnImpossibleIntercept || !weapon.UsesBoostCoastModel.Value || !(weapon.TimeSinceLaunch > (float)weapon.TotalBurnTime)) ? ((float)myUnit.Kinematics.GetMaximumSpeed(weapon.Navigator.PlottedCourse[0].Altitude, myUnit.MaxPossibleThrottleSetting, ValidateAndFixAltitude: false)) : myUnit.CurrentSpeed);
					result = weapon.Navigator.ComputeTerminalPoint(weaponNominalSpeed2, weapon.DataLinkParent != null && weapon.DataLinkParent.IsAircraft && weapon.IsTorpedo);
				}
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 107973", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return null;
	}

	public override void DetermineDesiredAttitudeAndThrottle(float elapsedTime, bool RecalculatePlottedCourse = true)
	{
		Weapon theWeapon = (Weapon)myUnit;
		LatestPointUsedToDetermineAttitude = null;
		try
		{
			if (theWeapon.Type == Weapon._WeaponType.Sonobuoy || theWeapon.TimeToReseek > 0f)
			{
				return;
			}
			if (theWeapon.BlindTime > 0f)
			{
				if (theWeapon.Guidance == Weapon.WeaponGuidanceType.Inertial_Plus_SemiActive)
				{
					DetermineDesiredAltitude(elapsedTime);
				}
				if (!TerminalDive)
				{
					TerminalDive = true;
				}
				return;
			}
			if (!theWeapon.IsDLZconstruct && !PrimaryTargetLocated(ref theWeapon))
			{
				if (myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
				{
					myUnit.Navigator.FollowPlottedCourse(elapsedTime);
					DetermineDesiredAltitude(elapsedTime);
					method_12(elapsedTime);
				}
				else
				{
					if (myUnit.IsTorpedo && theWeapon.Guidance == Weapon.WeaponGuidanceType.Inertial)
					{
						return;
					}
					if (theWeapon.IsAAWCapable && theWeapon.IsSemiAutonomous && !theWeapon.HasGoneAutonomous)
					{
						_ = theWeapon.DataLinkParent;
						if (theWeapon.Sensory.CanTrackThisContact_AAWFireControlGrade(PrimaryTarget))
						{
							theWeapon.GoAutonomous(clearPrimaryTarget: true, clearDatalink: true);
						}
					}
					if (!theWeapon.Flags.SearchPattern && theWeapon.SearchPatternType == Weapon.WeaponSearchPatternType.None)
					{
						if (theWeapon.isLoiterCapable)
						{
							if (!theWeapon.IsMobileDecoy && theWeapon.AI.PrimaryTarget == null && theWeapon.AI.LastKnownTargetLocation != null)
							{
								Geopoint_Struct Point = base.LastKnownTargetLocation.ToGeopoint_Struct();
								Geopoint_Struct Point2 = theWeapon.Location;
								if ((double)Math2.CalcDist(ref Point, ref Point2) < 0.5)
								{
									Weapon weapon = theWeapon;
									double theLat = theWeapon.get_Latitude((GlobalVariables.BooleanObject)null);
									double theLon = theWeapon.get_Longitude((GlobalVariables.BooleanObject)null);
									float theAlt = Math.Max(0, (int)Terrain.GetElevation(theWeapon.get_Latitude((GlobalVariables.BooleanObject)null), theWeapon.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, myUnit.ParentScen));
									LockRandom theRNG = GameGeneral.GlobalRNG;
									weapon.Detonate(theLat, theLon, theAlt, ref theRNG, Detonation_AddMessage: true);
									return;
								}
								myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, myUnit.CurrentHeading);
							}
							theWeapon.Kinematics.Loiter(elapsedTime);
							if (PrimaryTarget != null && (theWeapon.Navigator.PlottedCourse == null || theWeapon.Navigator.PlottedCourse.Count() == 0))
							{
								LatestPointUsedToDetermineAttitude = PrimaryTarget.Location;
							}
						}
						else
						{
							myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, myUnit.CurrentHeading);
						}
					}
					else if (!Information.IsNothing((object)PrimaryTarget) && !Information.IsNothing((object)PrimaryTarget.ActualUnit) && !PrimaryTarget.ActualUnit.IsFixedFacility)
					{
						if (theWeapon.SearchPatternType == Weapon.WeaponSearchPatternType.Circle)
						{
							CircleSearch(elapsedTime);
						}
						else if (theWeapon.SearchPatternType == Weapon.WeaponSearchPatternType.Snake)
						{
							SnakeSearch();
						}
						else
						{
							myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, myUnit.CurrentHeading);
						}
					}
					else if (!theWeapon.Navigator.HasPlottedCourse() && theWeapon.SearchPatternType == Weapon.WeaponSearchPatternType.Circle)
					{
						CircleSearch(elapsedTime);
					}
					else if (PrimaryTarget != null && PrimaryTarget.ActualUnit != null && PrimaryTarget.ActualUnit.IsFixedFacility)
					{
						LatestPointUsedToDetermineAttitude = PrimaryTarget.Location;
						myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, BearingToUnit_True(PrimaryTarget));
					}
					else
					{
						myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, myUnit.CurrentHeading);
					}
					DetermineDesiredAltitude(elapsedTime);
				}
				return;
			}
			bool flag = CheckForGuidanceDropDueToDoctrine(theWeapon);
			if (theWeapon.IsParachuteLoitering)
			{
				theWeapon.ReleaseFromLoiterParachute();
			}
			if (PrimaryTarget != null && PrimaryTarget.Type != Contact_Base.ContactType.Aimpoint && PrimaryTarget.Type != Contact_Base.ContactType.ActivationPoint)
			{
				PrimaryTarget_LastKnown_Lat = ((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null);
				PrimaryTarget_LastKnown_Lon = ((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null);
				PrimaryTarget_LastKnown_Altitude = ((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			}
			if (myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse() && theWeapon.DataLinkParent != null)
			{
				Geopoint_Struct? geopoint_Struct = SimulateGuidanceUpdatesFromDataLink(RecalculatePlottedCourse, flag);
				if (!geopoint_Struct.HasValue)
				{
					if (flag)
					{
						DropGuidanceDueToDoctrine(theWeapon);
					}
				}
				else
				{
					LatestPointUsedToDetermineAttitude = geopoint_Struct.Value;
					myUnit.Navigator.FollowPlottedCourse(elapsedTime);
				}
			}
			else if (!myUnit.Navigator.HasPlottedCourse())
			{
				if (PrimaryTarget != null && PrimaryTarget.Type == Contact_Base.ContactType.ActivationPoint)
				{
					return;
				}
				if (PrimaryTarget != null)
				{
					switch (theWeapon.Guidance)
					{
					case Weapon.WeaponGuidanceType.Inertial:
						if (PrimaryTarget != null)
						{
							theWeapon.Navigator.AddWaypoint(new Waypoint(((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), 0f, Waypoint.WaypointType.TerminalPoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse));
						}
						break;
					default:
						if (PrimaryTarget.ActualUnit != null)
						{
							if (theWeapon.ImpactsOnThisPulse_ActualUnit)
							{
								LatestPointUsedToDetermineAttitude = PrimaryTarget.Location;
								myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, myUnit.CurrentHeading);
								break;
							}
							if (!PrimaryTarget.IsBallisticTarget())
							{
								if (LatestValidInterceptPoint.HasValue)
								{
									Geopoint_Struct Point2 = theWeapon.Location;
									Geopoint_Struct Point = LatestValidInterceptPoint.Value;
									if (Math2.CalcDist(ref Point2, ref Point) < theWeapon.CurrentSpeed / 3600f * elapsedTime)
									{
										LatestValidInterceptPoint = null;
										LatestValidInterceptPointTargetID = "";
									}
								}
								if (PrimaryTarget.Age > 0f && Operators.CompareString(LatestValidInterceptPointTargetID, PrimaryTarget.ObjectID, false) == 0 && LatestValidInterceptPoint.HasValue)
								{
									bool AllowAfterburner = true;
									Manouver_InterceptCourse(elapsedTime, null, ref AllowAfterburner);
									LatestPointUsedToDetermineAttitude = LatestValidInterceptPoint.Value;
									myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, BearingToPoint_True(LatestValidInterceptPoint.Value.Latitude, LatestValidInterceptPoint.Value.Longitude));
								}
								else if (Module_Unit.ClosureSpeed(theWeapon, ((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), PrimaryTarget.CurrentHeading, PrimaryTarget.CurrentSpeed, theWeapon.CurrentSpeed, theWeapon.CurrentHeading) < 0f && flag)
								{
									DropGuidanceDueToDoctrine(theWeapon);
								}
								else
								{
									bool AllowAfterburner = true;
									LatestPointUsedToDetermineAttitude = Manouver_InterceptCourse(elapsedTime, null, ref AllowAfterburner);
									LatestValidInterceptPointTargetID = PrimaryTarget.ObjectID;
									LatestValidInterceptPoint = LatestPointUsedToDetermineAttitude;
								}
								break;
							}
							Geopoint_Struct value = theWeapon.Navigator.ComputeInterceptPoint_ABM(PrimaryTarget);
							if (value.HasZeroCoords)
							{
								if (flag)
								{
									DropGuidanceDueToDoctrine(theWeapon);
								}
								else if (Operators.CompareString(LatestValidInterceptPointTargetID, PrimaryTarget.ObjectID, false) == 0 && LatestValidInterceptPoint.HasValue)
								{
									LatestPointUsedToDetermineAttitude = LatestValidInterceptPoint.Value;
									myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, BearingToPoint_True(LatestValidInterceptPoint.Value.Latitude, LatestValidInterceptPoint.Value.Longitude));
								}
								else
								{
									LatestPointUsedToDetermineAttitude = PrimaryTarget.Location;
									myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, BearingToPoint_True(((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null)));
								}
							}
							else
							{
								LatestValidInterceptPoint = value;
								LatestValidInterceptPointTargetID = PrimaryTarget.ObjectID;
								LatestPointUsedToDetermineAttitude = value;
								myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, BearingToPoint_True(value.Latitude, value.Longitude));
							}
						}
						else
						{
							LatestPointUsedToDetermineAttitude = PrimaryTarget.Location;
							myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, BearingToUnit_True(PrimaryTarget));
						}
						break;
					case Weapon.WeaponGuidanceType.CommandGuided_Datalinked:
						LatestPointUsedToDetermineAttitude = PrimaryTarget.Location;
						myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, BearingToUnit_True(PrimaryTarget));
						break;
					}
				}
				else if (!theWeapon.isLoiterCapable)
				{
					myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, myUnit.CurrentHeading);
				}
				else
				{
					theWeapon.Kinematics.Loiter(elapsedTime);
				}
			}
			else
			{
				myUnit.Navigator.FollowPlottedCourse(elapsedTime);
			}
			DetermineDesiredAltitude(elapsedTime);
			if (!theWeapon.IsDLZconstruct)
			{
				method_12(elapsedTime);
			}
			if (theWeapon.SupportsAttitude_Pitch || theWeapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) == theWeapon.CruiseAltitude_ASL || PrimaryTarget == null)
			{
				return;
			}
			Contact_Base.ContactType type = PrimaryTarget.Type;
			if (type <= Contact_Base.ContactType.Missile || type == Contact_Base.ContactType.Orbital || type == Contact_Base.ContactType.Decoy_Air)
			{
				float num = Math.Abs(((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
				float num2 = ((((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) >= myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) ? myUnit.Kinematics.get_ClimbRate_Nominal(LimitByTrueAirspeed: true) : myUnit.Kinematics.DiveRate_Nominal());
				float num3 = num / num2;
				float num4 = Module_Unit.ClosureSpeed(myUnit, PrimaryTarget, myUnit.CurrentSpeed, Module_Unit.BearingToUnit_True(myUnit, PrimaryTarget));
				float num5 = myUnit.RangeToUnit_Horiz(PrimaryTarget);
				long num6 = ((!(num4 <= 0f)) ? ((long)Math.Round(num5 / num4 * 3600f)) : long.MaxValue);
				if ((float)num6 < num3)
				{
					float value2 = (float)((double)num / ((double)num6 + 0.001));
					((ActiveUnit_Kinematics)theWeapon.Kinematics).set_ClimbRate_Nominal(LimitByTrueAirspeed: true, value2);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100970", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_12(float float_2)
	{
		_Closure$__34-0 arg = default(_Closure$__34-0);
		_Closure$__34-0 CS$<>8__locals16 = new _Closure$__34-0(arg);
		CS$<>8__locals16.$VB$Local_myWeapon = (Weapon)myUnit;
		if (CS$<>8__locals16.$VB$Local_myWeapon.IsDLZconstruct)
		{
			return;
		}
		try
		{
			bool? flag2;
			bool? flag = (flag2 = PrimaryTarget?.isSurfaceOrLandContact);
			bool? flag3 = ((flag.HasValue && flag2 != true) ? new bool?(false) : (method_13() & flag2));
			if (!(flag3 ?? true) || !CS$<>8__locals16.$VB$Local_myWeapon.Navigator.HasPlottedCourse() || !flag3.HasValue)
			{
				return;
			}
			WeaponSalvo weaponSalvo = null;
			if (((ActiveUnit)CS$<>8__locals16.$VB$Local_myWeapon).get_UnitSide(SetSideOnly: false)?.WeaponSalvos != null)
			{
				int num = ((ActiveUnit)CS$<>8__locals16.$VB$Local_myWeapon).get_UnitSide(SetSideOnly: false).WeaponSalvos.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					WeaponSalvo weaponSalvo2;
					try
					{
						weaponSalvo2 = ((ActiveUnit)CS$<>8__locals16.$VB$Local_myWeapon).get_UnitSide(SetSideOnly: false).WeaponSalvos[i];
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
						continue;
					}
					if (weaponSalvo2 != null && weaponSalvo2.WeaponList.ContainsKey(CS$<>8__locals16.$VB$Local_myWeapon.ObjectID))
					{
						weaponSalvo = weaponSalvo2;
						break;
					}
				}
			}
			if (weaponSalvo != null && weaponSalvo.WeaponList.Count > 1)
			{
				List<(Weapon, float, float)> list = new List<(Weapon, float, float)>();
				float num2 = 0f;
				Weapon weapon = null;
				PooledList<string> pooledList;
				try
				{
					pooledList = new PooledList<string>(weaponSalvo.WeaponList.Keys, Pools<string>.Local);
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					pooledList = new PooledList<string>(weaponSalvo.WeaponList.Keys, Pools<string>.Local);
					ProjectData.ClearProjectError();
				}
				foreach (string item4 in pooledList)
				{
					if (string.IsNullOrEmpty(item4) || !CS$<>8__locals16.$VB$Local_myWeapon.ParentScen.ActiveUnits.TryGetValue(item4, out var value))
					{
						continue;
					}
					Weapon weapon2 = (Weapon)value;
					if (weapon2.Navigator.PlottedCourse.LastOrDefault() != null)
					{
						float plottedCourseDistance = weapon2.Navigator.GetPlottedCourseDistance(weapon2.Navigator.PlottedCourse);
						float currentSpeed = weapon2.CurrentSpeed;
						float item = plottedCourseDistance / currentSpeed * 3600f;
						list.Add((weapon2, plottedCourseDistance, item));
						if (plottedCourseDistance > num2)
						{
							num2 = plottedCourseDistance;
							weapon = weapon2;
						}
					}
				}
				pooledList.Dispose();
				if (CS$<>8__locals16.$VB$Local_myWeapon != weapon)
				{
					float item2 = list.Where([SpecialName] ((Weapon, float, float) theTuple) => theTuple.Item1 == CS$<>8__locals16.$VB$Local_myWeapon).ElementAtOrDefault(0).Item2;
					float item3 = list.OrderByDescending([SpecialName] ((Weapon, float, float) theTuple) => theTuple.Item2).ElementAtOrDefault(0).Item3;
					if ((double)(num2 - item2) > 0.1)
					{
						float num3 = smethod_0(item2, item3);
						float num4 = Math.Abs(num3 - myUnit.CurrentSpeed);
						num3 = myUnit.CurrentSpeed - 2f * num4;
						float num5 = CS$<>8__locals16.$VB$Local_myWeapon.Kinematics.StallSpeed(CS$<>8__locals16.$VB$Local_myWeapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
						if (num3 < num5)
						{
							num3 = num5 + 10f;
						}
						if (num3 - myUnit.CurrentSpeed < 1f)
						{
							num3 = myUnit.CurrentSpeed - 1f;
						}
						CS$<>8__locals16.$VB$Local_myWeapon.Kinematics.SpeedForSimultaneousTOT = num3;
					}
					else
					{
						CS$<>8__locals16.$VB$Local_myWeapon.Kinematics.SpeedForSimultaneousTOT = -1f;
					}
				}
				else
				{
					CS$<>8__locals16.$VB$Local_myWeapon.Kinematics.SpeedForSimultaneousTOT = -1f;
				}
			}
			else
			{
				CS$<>8__locals16.$VB$Local_myWeapon.Kinematics.SpeedForSimultaneousTOT = -1f;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 90328459032485", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static float smethod_0(float float_2, float float_3)
	{
		if (float_3 > 0f)
		{
			float num = float_3 / 3600f;
			return float_2 / num;
		}
		return 0f;
	}

	private bool method_13()
	{
		Weapon weapon = (Weapon)myUnit;
		if (weapon.Type == Weapon._WeaponType.GuidedWeapon)
		{
			if (!weapon.IsBallisticMissile)
			{
				if (!weapon.IsAerospaceUnit)
				{
					return false;
				}
				if (weapon.Waypoints != 0)
				{
					return true;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	public float EstimateAverageSpeedToTarget(Contact theTarget)
	{
		float result = default(float);
		try
		{
			Weapon weapon = (Weapon)myUnit;
			Scenario parentScen = weapon.ParentScen;
			int dBID = weapon.DBID;
			double launchLongitude = weapon.get_Longitude((GlobalVariables.BooleanObject)null);
			double launchLatitude = weapon.get_Latitude((GlobalVariables.BooleanObject)null);
			float launchAltitude = weapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			int launchSpeed = (int)Math.Round(weapon.CurrentSpeed);
			double targetLongitude = ((Module_Unit.Unit)theTarget).get_Longitude((GlobalVariables.BooleanObject)null);
			double targetLatitude = ((Module_Unit.Unit)theTarget).get_Latitude((GlobalVariables.BooleanObject)null);
			float currentHeading = theTarget.CurrentHeading;
			bool headingIsKnown = theTarget.HeadingIsKnown;
			int targetSpeed = (int)Math.Round(Module_Unit.CurrentSpeed_Horizontal(theTarget));
			bool speedIsKnown = theTarget.SpeedIsKnown;
			float targetAltitude = ((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			bool altitudeIsKnown = theTarget.AltitudeIsKnown;
			float targetVerticalSpeed_mpersec = Module_Unit.CurrentSpeed_Vertical(theTarget, myUnit.ParentScen);
			Contact_Base.ContactType type = theTarget.Type;
			bool targetIsTerminalDiving = theTarget.ActualUnit.IsGuidedWeapon() && ((Weapon)theTarget.ActualUnit).AI.TerminalDive;
			string FeedbackText = string.Empty;
			GeoPoint InterceptPoint = default(GeoPoint);
			float FlightTime = default(float);
			ActiveUnit_Weaponry.TargetIsWithinDLZ(parentScen, dBID, weapon, AssumeVerticalLaunch: false, launchLongitude, launchLatitude, launchAltitude, launchSpeed, targetLongitude, targetLatitude, currentHeading, headingIsKnown, targetSpeed, speedIsKnown, targetAltitude, altitudeIsKnown, targetVerticalSpeed_mpersec, type, ref InterceptPoint, targetIsTerminalDiving, ref FeedbackText, HumanFeedBackNeeded: false, 0f, ActiveUnit.Throttle.Cruise, null, 0, null, ref FlightTime);
			if (InterceptPoint == null)
			{
				result = myUnit.Kinematics.GetMaximumSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), myUnit.MaxPossibleThrottleSetting, ValidateAndFixAltitude: false);
				return result;
			}
			result = Module_Unit.RangeToPoint_Horiz(weapon, InterceptPoint) / (FlightTime / 3600f);
			return result;
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
		return result;
	}

	protected void CalculateDesiredPitch(GeoPoint TargetPoint, float elapsedTime)
	{
		Weapon weapon = (Weapon)myUnit;
		if (!weapon.SupportsAttitude_Pitch)
		{
			return;
		}
		if (TargetPoint == null)
		{
			float num = Math.Abs(weapon.DesiredAltitude - weapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
			if (myUnit.DesiredAltitude > myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))
			{
				if (num < 2000f)
				{
					myUnit.DesiredPitch = num / 2000f * 89f;
				}
				else
				{
					myUnit.DesiredPitch = 89f;
				}
			}
			else if (num < 2000f)
			{
				myUnit.DesiredPitch = num / 2000f * -89f;
			}
			else
			{
				myUnit.DesiredPitch = -89f;
			}
		}
		else
		{
			Calculate_And_Set_DesiredPitch(TargetPoint.Latitude, TargetPoint.Longitude, TargetPoint.Altitude);
		}
	}

	protected void CalculateDesiredPitch_GPStruct(Geopoint_Struct TargetPoint, float elapsedTime)
	{
		Weapon weapon = (Weapon)myUnit;
		if (!weapon.SupportsAttitude_Pitch)
		{
			return;
		}
		if (TargetPoint.HasZeroCoords)
		{
			float num = Math.Abs(weapon.DesiredAltitude - weapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
			if (myUnit.DesiredAltitude <= myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))
			{
				if (num < 2000f)
				{
					myUnit.DesiredPitch = num / 2000f * -89f;
				}
				else
				{
					myUnit.DesiredPitch = -89f;
				}
			}
			else if (num < 2000f)
			{
				myUnit.DesiredPitch = num / 2000f * 89f;
			}
			else
			{
				myUnit.DesiredPitch = 89f;
			}
		}
		else
		{
			Calculate_And_Set_DesiredPitch(TargetPoint.Latitude, TargetPoint.Longitude, TargetPoint.Altitude);
		}
	}

	protected void CalculateDesiredPitch(double TargetLat, double TargetLon)
	{
		Weapon weapon = (Weapon)myUnit;
		if (weapon.SupportsAttitude_Pitch)
		{
			float num = Module_Unit.RangeToPoint_Horiz(weapon, TargetLat, TargetLon);
			double num2 = Math.Atan2(weapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - weapon.DesiredAltitude, (double)num * 1852.0) * 57.2957795130823;
			if (num2 > 0.0 && weapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > weapon.DesiredAltitude)
			{
				num2 = 0.0 - num2;
			}
			if (num2 < 0.0 && weapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < weapon.DesiredAltitude)
			{
				num2 = 0.0 - num2;
			}
			weapon.DesiredPitch = (float)num2;
		}
	}

	private void method_14(float float_2)
	{
		Weapon theWeapon = (Weapon)myUnit;
		if (!theWeapon.IsDLZconstruct && !PrimaryTargetLocated(ref theWeapon) && myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
		{
			Waypoint waypoint = myUnit.Navigator.PlottedCourse[0];
			myUnit.DesiredAltitude = waypoint.Altitude;
			CalculateDesiredPitch(waypoint, float_2);
		}
		else
		{
			if (PrimaryTarget == null)
			{
				return;
			}
			float num = default(float);
			Geopoint_Struct geopoint_Struct = default(Geopoint_Struct);
			if (PrimaryTarget.CurrentSpeed == 0f)
			{
				num = myUnit.RangeToUnit_Horiz(PrimaryTarget);
			}
			else
			{
				try
				{
					if (!PrimaryTarget.IsBallisticTarget())
					{
						float mySpeed = ((!theWeapon.SupportsAttitude_Pitch) ? ((float)theWeapon.Kinematics.GetMaximumSpeed()) : ((float)((double)theWeapon.Kinematics.GetMaximumSpeed() * 0.5)));
						geopoint_Struct = theWeapon.Navigator.ComputeInterceptPoint_BruteForce(mySpeed, PrimaryTarget);
						num = ((!geopoint_Struct.HasZeroCoords) ? Module_Unit.RangeToPoint_Horiz(theWeapon, geopoint_Struct) : myUnit.RangeToUnit_Horiz(PrimaryTarget));
					}
					else
					{
						geopoint_Struct = theWeapon.Navigator.ComputeInterceptPoint_ABM(PrimaryTarget);
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 0978543332", "");
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			if (!geopoint_Struct.HasZeroCoords)
			{
				InterceptPointHistory = geopoint_Struct;
			}
			if ((PrimaryTarget.Type == Contact_Base.ContactType.Air || PrimaryTarget.Type == Contact_Base.ContactType.Missile) && !theWeapon.Flags.IlluminateAtLaunch)
			{
				try
				{
					myUnit.DesiredAltitude = theWeapon.ImpactAltitude;
					if (!geopoint_Struct.HasZeroCoords)
					{
						if (PrimaryTarget.IsBallisticTarget())
						{
							myUnit.DesiredAltitude = geopoint_Struct.Altitude;
						}
						Calculate_And_Set_DesiredPitch(geopoint_Struct.Latitude, geopoint_Struct.Longitude, geopoint_Struct.Altitude);
					}
					else
					{
						Calculate_And_Set_DesiredPitch(((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
					}
					return;
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					ex4?.Data.Add("Error at 09785433323", "");
					GameGeneral.WriteExceptionsToLog(ex4);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
					return;
				}
			}
			if (!theWeapon.IsAAWCapable)
			{
				try
				{
					float num2 = num / myUnit.CurrentSpeed * 3600f;
					float num3 = Math.Abs(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - theWeapon.ImpactAltitude) / num2;
					float num4 = theWeapon.ImpactAltitude - myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
					if (theWeapon.SupportsAttitude_Pitch)
					{
						theWeapon.DesiredAltitude = theWeapon.ImpactAltitude;
						if (!geopoint_Struct.HasZeroCoords)
						{
							Calculate_And_Set_DesiredPitch(geopoint_Struct.Latitude, geopoint_Struct.Longitude, geopoint_Struct.Altitude);
						}
						else
						{
							Calculate_And_Set_DesiredPitch(((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
						}
					}
					else if (num4 < 0f)
					{
						myUnit.DesiredAltitude = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - num3 * float_2;
						if (theWeapon.IsGuidedWeapon())
						{
							((ActiveUnit_Kinematics)theWeapon.Kinematics).set_ClimbRate_Nominal(LimitByTrueAirspeed: true, num3);
						}
					}
					else
					{
						myUnit.DesiredAltitude = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + num3;
						if (theWeapon.IsGuidedWeapon())
						{
							((ActiveUnit_Kinematics)theWeapon.Kinematics).set_ClimbRate_Nominal(LimitByTrueAirspeed: true, num3);
						}
					}
					return;
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception ex6 = ex5;
					ex6?.Data.Add("Error at 0974448543332", "");
					GameGeneral.WriteExceptionsToLog(ex6);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
					return;
				}
			}
			float num5 = myUnit.CurrentSpeed * float_2 / 3600f;
			float num6 = theWeapon.ImpactAltitude - myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			if ((PrimaryTarget.IsSubmarine || PrimaryTarget.IsLandContact) && !Information.IsNothing((object)theWeapon.LaunchPoint) && theWeapon.LaunchPoint.get_Altitude_AGL(myUnit.ParentScen) <= 50f && Math.Abs(num6) < num / 4f * 1852f)
			{
				try
				{
					if (!TerminalDive)
					{
						myUnit.DesiredAltitude = theWeapon.Kinematics.GetMaximumAltitude();
						if (geopoint_Struct.HasZeroCoords)
						{
							float mySpeed2 = (theWeapon.SupportsAttitude_Pitch ? ((float)((double)theWeapon.Kinematics.GetMaximumSpeed() * 0.5)) : ((float)theWeapon.Kinematics.GetMaximumSpeed()));
							geopoint_Struct = theWeapon.Navigator.ComputeInterceptPoint_BruteForce(mySpeed2, PrimaryTarget);
						}
						CalculateDesiredPitch_GPStruct(geopoint_Struct, float_2);
					}
					return;
				}
				catch (Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					Exception ex8 = ex7;
					ex8?.Data.Add("Error at 0978543332_8", "");
					GameGeneral.WriteExceptionsToLog(ex8);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
					return;
				}
			}
			if (theWeapon.SupportsAttitude_Pitch)
			{
				try
				{
					theWeapon.DesiredAltitude = theWeapon.ImpactAltitude;
					if (geopoint_Struct.HasZeroCoords)
					{
						bool? flag2;
						bool? flag = (flag2 = PrimaryTarget?.IsBallisticTarget());
						bool? obj;
						if (flag.HasValue && flag2 != true)
						{
							obj = false;
						}
						else
						{
							bool? flag3;
							flag = (flag3 = PrimaryTarget?.ActualUnit?.IsWeapon);
							obj = ((!flag.HasValue) ? ((bool?)null) : ((flag3 == true) & flag2));
						}
						bool? flag4 = obj;
						if (flag4 ?? true)
						{
							float? num7 = PrimaryTarget?.ActualUnit?.Attitude_Pitch;
							if (((!num7.HasValue) ? ((bool?)null) : new bool?(num7.GetValueOrDefault() < 0f)) == true && flag4.HasValue)
							{
								if (PrimaryTarget.FutureBallisticPath.Length == 0)
								{
									PrimaryTarget.FutureBallisticPath = BallisticMissile_Kinematics.EstimatedFuturePathOfBallisticTarget(PrimaryTarget, myUnit.ParentScen);
								}
								float num8 = Module_Unit.ClosureSpeed(theWeapon, ((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), PrimaryTarget.CurrentHeading, Module_Unit.CurrentSpeed_Horizontal(PrimaryTarget), Module_Unit.CurrentSpeed_Horizontal(theWeapon), myUnit.CurrentHeading);
								if (num <= 0f)
								{
									num = myUnit.RangeToUnit_Horiz(PrimaryTarget);
								}
								if ((num8 == 0f) & Debugger.IsAttached)
								{
									Debugger.Break();
								}
								double value = num / num8 * 3600f;
								try
								{
									TimeSpan value2 = TimeSpan.FromSeconds(value);
									DateTime t = myUnit.ParentScen.Time.Add(value2);
									TrajectoryPoint[] futureBallisticPath = PrimaryTarget.FutureBallisticPath;
									int num9 = 0;
									TrajectoryPoint trajectoryPoint;
									while (true)
									{
										if (num9 >= futureBallisticPath.Length)
										{
											return;
										}
										trajectoryPoint = futureBallisticPath[num9];
										if (DateTime.Compare(trajectoryPoint.TimeZulu, t) > 0)
										{
											break;
										}
										num9 = checked(num9 + 1);
									}
									Calculate_And_Set_DesiredPitch(trajectoryPoint.Latitude, trajectoryPoint.Longitude, trajectoryPoint.Altitude);
									return;
								}
								catch (OverflowException projectError)
								{
									ProjectData.SetProjectError((Exception)projectError);
									ProjectData.ClearProjectError();
									return;
								}
							}
						}
						Calculate_And_Set_DesiredPitch(((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
					}
					else
					{
						Calculate_And_Set_DesiredPitch(geopoint_Struct.Latitude, geopoint_Struct.Longitude, geopoint_Struct.Altitude);
					}
					return;
				}
				catch (Exception ex9)
				{
					ProjectData.SetProjectError(ex9);
					Exception ex10 = ex9;
					ex10?.Data.Add("Error at 097854333_62", "");
					GameGeneral.WriteExceptionsToLog(ex10);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
					return;
				}
			}
			try
			{
				if (num6 < 0f)
				{
					myUnit.DesiredAltitude = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - num5 * Math.Abs(num6) / num;
				}
				else
				{
					myUnit.DesiredAltitude = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + num5 * Math.Abs(num6) / num;
				}
			}
			catch (Exception ex11)
			{
				ProjectData.SetProjectError(ex11);
				Exception ex12 = ex11;
				ex12?.Data.Add("Error at 097854366332", "");
				GameGeneral.WriteExceptionsToLog(ex12);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public virtual void DetermineDesiredImpactAltitude()
	{
		try
		{
			Weapon weapon = (Weapon)myUnit;
			float num = default(float);
			if (weapon.AI.PrimaryTarget == null)
			{
				num = ((Module_Unit.Unit)weapon).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, myUnit.ParentScen);
			}
			else
			{
				if (weapon.AI.PrimaryTarget.IsAir_Missile_Orbital_Contact)
				{
					weapon.ImpactAltitude = ((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
					return;
				}
				if (!Information.IsNothing((object)weapon.AI.PrimaryTarget_Type))
				{
					switch (weapon.AI.PrimaryTarget_Type)
					{
					case Contact_Base.ContactType.Surface:
						num = ((weapon.AI.PrimaryTarget.ActualUnit == null || !weapon.AI.PrimaryTarget.ActualUnit.IsShip) ? ((float)((Module_Unit.Unit)weapon.AI.PrimaryTarget).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, myUnit.ParentScen)) : ((Module_Unit.Unit)weapon.AI.PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
						break;
					case Contact_Base.ContactType.Submarine:
						num = Math.Max(((Module_Unit.Unit)weapon.AI.PrimaryTarget).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, myUnit.ParentScen), -100);
						break;
					case Contact_Base.ContactType.Aimpoint:
						num = ((!((float)((Module_Unit.Unit)weapon.AI.PrimaryTarget).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, myUnit.ParentScen) < 0f)) ? ((float)((Module_Unit.Unit)weapon.AI.PrimaryTarget).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, myUnit.ParentScen)) : ((!weapon.IsASW) ? 0f : ((float)Math.Max(((Module_Unit.Unit)weapon.AI.PrimaryTarget).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, myUnit.ParentScen), -100))));
						break;
					default:
						num = ((Module_Unit.Unit)weapon.AI.PrimaryTarget).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, myUnit.ParentScen);
						break;
					case Contact_Base.ContactType.Facility_Fixed:
					case Contact_Base.ContactType.Facility_Mobile:
					case Contact_Base.ContactType.AggregateGroundUnit:
						num = ((Module_Unit.Unit)weapon.AI.PrimaryTarget).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, myUnit.ParentScen);
						break;
					}
				}
			}
			if ((weapon.Guidance == Weapon.WeaponGuidanceType.Inertial || (!Information.IsNothing((object)weapon.AI.PrimaryTarget) && (weapon.AI.PrimaryTarget.Type == Contact_Base.ContactType.Aimpoint || (weapon.Warheads.Count() > 0 && weapon.Warheads[0].get_IsAirburst(weapon, myUnit.AI.PrimaryTarget.ActualUnit))))) && !weapon.IsTorpedo && weapon.Navigator.HasPlottedCourse())
			{
				weapon.ImpactAltitude = myUnit.Navigator.PlottedCourse[0].Altitude;
				if (Information.IsNothing((object)PrimaryTarget))
				{
					switch (weapon.Type)
					{
					case Weapon._WeaponType.GuidedWeapon:
					case Weapon._WeaponType.GuidedProjectile:
					case Weapon._WeaponType.BallisticMissile:
					case Weapon._WeaponType.RV:
					case Weapon._WeaponType.HGV:
						if (weapon.ImpactAltitude < num)
						{
							weapon.ImpactAltitude = num;
						}
						else if (num < 0f)
						{
							weapon.ImpactAltitude = 0f;
						}
						break;
					}
				}
				else if (weapon.ImpactAltitude < num)
				{
					if (num < 0f)
					{
						weapon.ImpactAltitude = weapon.get_OptimumBurstHeight_AGL(myUnit.AI.PrimaryTarget.ActualUnit);
					}
					else
					{
						weapon.ImpactAltitude = num + (float)weapon.get_OptimumBurstHeight_AGL(myUnit.AI.PrimaryTarget.ActualUnit);
					}
				}
				else if (weapon.Warheads.Count() > 0 && weapon.Warheads[0].get_IsAirburst(weapon, weapon.AI.PrimaryTarget.ActualUnit))
				{
					weapon.ImpactAltitude = num + (float)weapon.get_OptimumBurstHeight_AGL(myUnit.AI.PrimaryTarget.ActualUnit);
				}
				return;
			}
			if (!Information.IsNothing((object)PrimaryTarget) && num < 0f)
			{
				switch (weapon.Type)
				{
				default:
					weapon.ImpactAltitude = num;
					break;
				case Weapon._WeaponType.GuidedWeapon:
				case Weapon._WeaponType.GuidedProjectile:
				case Weapon._WeaponType.BallisticMissile:
				case Weapon._WeaponType.RV:
				case Weapon._WeaponType.HGV:
					if (weapon.ImpactAltitude < num)
					{
						weapon.ImpactAltitude = num;
					}
					else if (num < 0f)
					{
						weapon.ImpactAltitude = 0f;
					}
					break;
				}
				return;
			}
			switch (weapon.Type)
			{
			case Weapon._WeaponType.GuidedWeapon:
			case Weapon._WeaponType.GuidedProjectile:
			case Weapon._WeaponType.BallisticMissile:
			case Weapon._WeaponType.RV:
			case Weapon._WeaponType.HGV:
				if (weapon.ImpactAltitude < num)
				{
					weapon.ImpactAltitude = num;
				}
				else if (num < 0f)
				{
					weapon.ImpactAltitude = 0f;
				}
				break;
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

	public virtual void DetermineDesiredAltitude(float elapsedTime)
	{
		try
		{
			DetermineDesiredImpactAltitude();
			Weapon weapon = (Weapon)myUnit;
			if (!weapon.IsParachuteLoitering)
			{
				if (weapon.IsWeaponPallet)
				{
					return;
				}
				if (weapon.IsReEntryVehicle && weapon.SupportsAttitude_Pitch && weapon.Navigator.HasPlottedCourse())
				{
					weapon.DesiredAltitude = weapon.Navigator.PlottedCourse.First().Altitude;
					CalculateDesiredPitch(weapon.Navigator.PlottedCourse.First(), elapsedTime);
					return;
				}
				if (weapon.IsReEntryVehicle)
				{
					if (!weapon.Navigator.HasPlottedCourse())
					{
						if (!weapon.SupportsAttitude_Pitch)
						{
							weapon.DesiredAltitude = 0f;
						}
						else if (weapon.Sensors_Cached.Length > 0)
						{
							if (!Information.IsNothing((object)_PrimaryTarget))
							{
								weapon.DesiredAltitude = weapon.ImpactAltitude;
								Calculate_And_Set_DesiredPitch(((Module_Unit.Unit)_PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)_PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)_PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
							}
							else
							{
								weapon.DesiredPitch = weapon.Attitude_Pitch;
							}
						}
						else
						{
							weapon.DesiredAltitude = ((Module_Unit.Unit)_PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
							CalculateDesiredPitch(new GeoPoint(((Module_Unit.Unit)_PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)_PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null)), elapsedTime);
						}
					}
					else
					{
						weapon.DesiredAltitude = weapon.Navigator.PlottedCourse.First().Altitude;
						CalculateDesiredPitch(weapon.Navigator.PlottedCourse.First(), elapsedTime);
					}
					return;
				}
				if (!TerminalDive)
				{
					if (weapon.IsTorpedo)
					{
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						((Torpedo_AI)weapon.AI).DetermineDesiredAltitude(elapsedTime);
					}
					else
					{
						if (weapon.Flags.Navigation_AltitudeControl && weapon.Kinematics.DesiredAltitudeOverride)
						{
							CalculateDesiredPitch(null, elapsedTime);
							return;
						}
						if (weapon.Navigator.HasPlottedCourse() && !weapon.SupportsAttitude_Pitch)
						{
							Waypoint waypoint = weapon.Navigator.PlottedCourse[0];
							if (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < waypoint.Altitude)
							{
								float num = Math.Abs(myUnit.Kinematics.HorizDistranceRequiredToReachDesiredAltitude(myUnit, waypoint.Altitude));
								if ((double)Module_Unit.RangeToPoint_Horiz(weapon, waypoint) < (double)num * 1.1)
								{
									myUnit.DesiredAltitude = waypoint.Altitude;
									CalculateDesiredPitch(null, elapsedTime);
									return;
								}
							}
						}
						if (weapon.CruiseAltitude_AGL != 0f && weapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= ((ActiveUnit_Kinematics)weapon.Kinematics).get_ClimbRate_Nominal(LimitByTrueAirspeed: true))
						{
							if (weapon.IsReEntryVehicle)
							{
								weapon.DesiredAltitude = 0f;
							}
							else
							{
								if (weapon.IsAAWCapable)
								{
									weapon.DesiredAltitude = weapon.ImpactAltitude;
									CalculateDesiredPitch(null, elapsedTime);
									return;
								}
								if (weapon.IsASCMwithoutTFcapability())
								{
									if (weapon.CruiseAltitude_ASL > 0f)
									{
										myUnit.DesiredAltitude = weapon.CruiseAltitude_ASL;
									}
									else if (weapon.CruiseAltitude_AGL > 0f)
									{
										myUnit.DesiredAltitude = weapon.CruiseAltitude_AGL;
									}
								}
								else
								{
									myUnit.DesiredAltitude = weapon.CruiseAltitude_AGL + (float)Math.Max(0, (int)Terrain.GetElevation(weapon.get_Latitude((GlobalVariables.BooleanObject)null), weapon.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, weapon.ParentScen));
								}
							}
							if (!PerformTerrainFollowingIfNecessary())
							{
								CalculateDesiredPitch(null, elapsedTime);
							}
							return;
						}
					}
				}
				if (weapon.CruiseAltitude_AGL != 0f && weapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < 8850f)
				{
					int elevation = Terrain.GetElevation(weapon.get_Latitude((GlobalVariables.BooleanObject)null), weapon.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, weapon.ParentScen);
					if (elevation > 0 && weapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - (float)elevation <= ((ActiveUnit_Kinematics)weapon.Kinematics).get_ClimbRate_Nominal(LimitByTrueAirspeed: true))
					{
						myUnit.DesiredAltitude = (float)elevation + weapon.CruiseAltitude_AGL;
						if (!PerformTerrainFollowingIfNecessary())
						{
							CalculateDesiredPitch(null, elapsedTime);
						}
						return;
					}
				}
				if (_PrimaryTarget == null && !weapon.IsMobileDecoy && !weapon.isUAV)
				{
					myUnit.DesiredAltitude = PrimaryTarget_LastKnown_Altitude;
					Calculate_And_Set_DesiredPitch(PrimaryTarget_LastKnown_Lat, PrimaryTarget_LastKnown_Lon, PrimaryTarget_LastKnown_Altitude);
				}
				else if (weapon.CruiseAltitude_AGL == 0f && weapon.CruiseAltitude_ASL == 0f && myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) == weapon.ImpactAltitude && !weapon.IsMobileDecoy && !weapon.isUAV)
				{
					myUnit.DesiredAltitude = weapon.ImpactAltitude;
					Calculate_And_Set_DesiredPitch(((Module_Unit.Unit)_PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)_PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)_PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
				}
				else if (weapon.CruiseAltitude_AGL == 0f && weapon.CruiseAltitude_ASL == 0f)
				{
					if (!weapon.IsMobileDecoy && !weapon.isUAV)
					{
						if (weapon.isLoiterCapable && _PrimaryTarget != null && _PrimaryTarget.Type == Contact_Base.ContactType.ActivationPoint)
						{
							if (weapon.IsMissile && weapon.CanParachuteLoiter)
							{
								weapon.DesiredAltitude = weapon.MaxLaunchAlt_ASL * 0.7f;
							}
							else
							{
								weapon.DesiredAltitude = weapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
							}
							CalculateDesiredPitch(null, elapsedTime);
						}
						else if (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) != weapon.ImpactAltitude)
						{
							method_14(elapsedTime);
						}
					}
					else
					{
						if (!weapon.SupportsAltitude_Control)
						{
							weapon.DesiredAltitude = weapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
						}
						CalculateDesiredPitch(null, elapsedTime);
					}
				}
				else if (_PrimaryTarget != null && (_PrimaryTarget.IsBallisticTarget() || _PrimaryTarget.IsOrbitalContact))
				{
					method_14(elapsedTime);
				}
				else if (_PrimaryTarget?.ActualUnit != null && _PrimaryTarget.ActualUnit.IsGuidedWeapon() && ((Weapon)_PrimaryTarget.ActualUnit).AI.TerminalDive)
				{
					if (!(_PrimaryTarget.CurrentAltitude_AGL > 1000f) && (double)weapon.RangeToUnit_Horiz(_PrimaryTarget) >= (double)(weapon.CruiseAltitude_ASL * 2f) * 0.000539957)
					{
						Trajectory_LoftedFlight(elapsedTime);
					}
					else
					{
						method_14(elapsedTime);
					}
				}
				else
				{
					Trajectory_LoftedFlight(elapsedTime);
				}
			}
			else
			{
				myUnit.DesiredAltitude = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - 50f * elapsedTime;
				myUnit.DesiredPitch = -85f;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100971", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	protected void PitchForLoftArc(float elapsedTime, Geopoint_Struct TargetPoint)
	{
		Weapon weapon = (Weapon)myUnit;
		float num = TargetPoint.Altitude - weapon.LaunchPoint.Altitude;
		float num2 = Module_Unit.RangeToPoint_Horiz(weapon, TargetPoint);
		float num3 = Module_Unit.RangeToPoint_Horiz(weapon, weapon.LaunchPoint);
		double x = (double)num2 * 1852.0;
		double num4 = (double)weapon.LaunchPoint.RangeToPoint_Horiz(TargetPoint.Longitude, TargetPoint.Latitude) * 1852.0;
		float num5 = 1f;
		double num6 = Math.Atan2(TargetPoint.Altitude - weapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), x) * 57.2957795130823;
		if (num3 > num2)
		{
			if (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < TargetPoint.Altitude || !(num6 < (double)myUnit.Attitude_Pitch))
			{
				weapon.DesiredPitch = (float)num6;
				return;
			}
			num5 = -1f;
		}
		double num7 = Math.Atan((double)num / num4 + Math.Sqrt(Math.Pow(num, 2.0) / Math.Pow(num4, 2.0) + 1.0)) * 57.2957795130823;
		double num8 = (double)weapon.LaunchPoint.Altitude + num4 / 4.0;
		float maximumAltitude = weapon.Kinematics.GetMaximumAltitude();
		if (num8 > (double)maximumAltitude)
		{
			num8 = maximumAltitude - 1f;
		}
		double num9 = (double)(weapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - weapon.LaunchPoint.Altitude) / num8;
		if (num9 > 1.0 && num5 == -1f)
		{
			num5 = 1f;
		}
		double value = (num7 - num7 * num9) * (double)num5;
		value = Math.Abs(value);
		bool flag = value < (double)weapon.Attitude_Pitch;
		if (num3 > num2 && num6 > value)
		{
			value = num6;
			return;
		}
		if (weapon.ImpactAltitude > weapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) && num6 > value)
		{
			value = num6;
			flag = false;
		}
		if (weapon.UsesBoostCoastModel.Value)
		{
			if (weapon.TimeSinceLaunch > (float)weapon.TotalBurnTime && value > 0.0 && TargetPoint.Altitude < weapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))
			{
				double num10 = (double)weapon.Kinematics.GetMaximumSpeed() / 2.0;
				float currentSpeed = weapon.CurrentSpeed;
				if (!(currentSpeed > (float)(num10 * 1.5)))
				{
					if (currentSpeed > (float)(num10 * 1.2))
					{
						value = Math.Min(value, value / 2.0);
						flag = (double)weapon.Attitude_Pitch > value && (double)weapon.Attitude_Pitch < 2.0 * value;
					}
					else
					{
						value = 0.0 - Math.Abs(Math.Atan2(TargetPoint.Altitude - weapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), x) * 57.2957795130823);
						weapon.DesiredAltitude = TargetPoint.Altitude;
						flag = false;
					}
				}
			}
			else if (weapon.TimeSinceLaunch > (float)weapon.TotalBurnTime && TargetPoint.Altitude > weapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))
			{
				double num11 = (double)weapon.Kinematics.StallSpeed(weapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) * 1.5;
				if ((double)weapon.CurrentSpeed < num11)
				{
					value = Math.Abs(Module_Unit.GrazingAngleToPoint(weapon, TargetPoint.Latitude, TargetPoint.Longitude, TargetPoint.Altitude));
					weapon.DesiredAltitude = TargetPoint.Altitude;
					flag = false;
				}
			}
			if (weapon.TimeSinceLaunch < (float)weapon.TotalBurnTime && value > 0.0)
			{
				value *= 1.2;
			}
		}
		weapon.DesiredPitch = (float)value;
		if (flag)
		{
			weapon.Attitude_Pitch = weapon.DesiredPitch;
		}
	}

	protected void PitchForLoftArcApogeeAtPercentageOfShotRange(float elapsedTime, float ApogeeAtPercentOfRange, Geopoint_Struct TargetPoint)
	{
		Weapon weapon = (Weapon)myUnit;
		float num = weapon.LaunchPoint.RangeToPoint_Horiz(TargetPoint.Longitude, TargetPoint.Latitude);
		float num2 = weapon.LaunchPoint.RangeToUnit_Horiz(myUnit);
		double bearing = MathFunctions.GetBearing(weapon.LaunchPoint.Latitude, weapon.LaunchPoint.Longitude, TargetPoint.Latitude, TargetPoint.Longitude);
		float distance_NM = ApogeeAtPercentOfRange * num;
		GeoPoint launchPoint = weapon.LaunchPoint;
		double Lon = launchPoint.Longitude;
		GeoPoint launchPoint2;
		double Lat = (launchPoint2 = weapon.LaunchPoint).Latitude;
		Geopoint_Struct thePoint = default(Geopoint_Struct);
		Geodesic_EdWilliams.CalcPoint_Williams(ref Lon, ref Lat, ref thePoint.Longitude, ref thePoint.Latitude, ref distance_NM, ref bearing);
		launchPoint2.Latitude = Lat;
		launchPoint.Longitude = Lon;
		thePoint.Altitude = weapon.DesiredAltitude;
		float num3;
		float num4;
		if (num2 <= distance_NM)
		{
			num3 = Module_Unit.RangeToPoint_Horiz(myUnit, thePoint, GlobalVariables.ObjectTrue);
			num4 = (float)(Math.Atan2(thePoint.Altitude - myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (double)num3 * 1852.0) * 57.2957795130823);
			if (num4 > 0f)
			{
				num4 += 10f * (1f - num2 / distance_NM);
			}
		}
		else
		{
			num3 = Module_Unit.RangeToPoint_Horiz(myUnit, TargetPoint, GlobalVariables.ObjectTrue);
			num4 = (float)(Math.Atan2(TargetPoint.Altitude - myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (double)num3 * 1852.0) * 57.2957795130823);
		}
		num4 = Math.Max(-90f, Math.Min(90f, num4));
		float num5 = num4 - myUnit.Attitude_Pitch;
		if (num3 > 10f)
		{
			num5 = (float)Math.Max(-0.9, Math.Min(0.9, num5));
		}
		if (num5 > 0f && weapon.TimeSinceLaunch > (float)weapon.TotalBurnTime)
		{
			num5 = 0f;
		}
		if (!float.IsNaN(num5))
		{
			myUnit.DesiredPitch = myUnit.Attitude_Pitch + num5;
		}
	}

	private bool method_15()
	{
		if (_PrimaryTarget == null)
		{
			return false;
		}
		int result;
		switch (_PrimaryTarget.Type)
		{
		case Contact_Base.ContactType.ActivationPoint:
			result = 1;
			break;
		default:
			return false;
		case Contact_Base.ContactType.Aimpoint:
			result = 1;
			break;
		}
		return (byte)result != 0;
	}

	private void method_16(float float_2)
	{
		Weapon weapon = (Weapon)myUnit;
		try
		{
			if (PrimaryTarget == null)
			{
				return;
			}
			float num = float.MinValue;
			bool flag = false;
			Geopoint_Struct thePoint;
			float num2;
			if (weapon.Navigator.HasPlottedCourse())
			{
				thePoint = weapon.Navigator.PlottedCourse[0].ToGeopoint_Struct();
				num2 = Module_Unit.RangeToPoint_Horiz(weapon, thePoint, GlobalVariables.ObjectTrue);
				flag = true;
			}
			else if (PrimaryTarget.CurrentSpeed != 0f && !PrimaryTarget.AppearsToBeLoitering)
			{
				float num3 = ((!weapon.SupportsAttitude_Pitch) ? ((float)weapon.Kinematics.GetMaximumSpeed()) : ((float)((double)weapon.Kinematics.GetMaximumSpeed() * 0.5)));
				if (PrimaryTarget.IsBallisticTarget())
				{
					num = Module_Unit.ClosureSpeed(myUnit, PrimaryTarget, Module_Unit.CurrentSpeed_Horizontal(weapon), myUnit.CurrentHeading);
					Geopoint_Struct geopoint_Struct = weapon.Navigator.ComputeInterceptPoint_ABM(PrimaryTarget);
					thePoint = (geopoint_Struct.HasZeroCoords ? weapon.Navigator.ComputeInterceptPoint_BruteForce(num3, PrimaryTarget, num) : geopoint_Struct);
				}
				else
				{
					num = Module_Unit.ClosureSpeed(myUnit, PrimaryTarget, num3, myUnit.CurrentHeading);
					thePoint = weapon.Navigator.ComputeIntercept_3D(PrimaryTarget);
				}
				if (!thePoint.HasZeroCoords)
				{
					num2 = Module_Unit.RangeToPoint_Horiz(weapon, thePoint);
				}
				else
				{
					num2 = myUnit.RangeToUnit_Horiz(PrimaryTarget);
					thePoint = new Geopoint_Struct(((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
				}
			}
			else
			{
				num2 = myUnit.RangeToUnit_Horiz(PrimaryTarget, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
				thePoint = new Geopoint_Struct(((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
			}
			int num4 = ((!weapon.Navigator.HasPlottedCourse()) ? ((int)Math.Round(weapon.ImpactAltitude)) : ((int)Math.Round(weapon.Navigator.PlottedCourse[0].Altitude)));
			_ = (float)num4 - myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			if (num == float.MinValue)
			{
				num = Module_Unit.ClosureSpeed(myUnit, PrimaryTarget, Module_Unit.CurrentSpeed_Horizontal(weapon), myUnit.CurrentHeading);
			}
			bool flag2 = weapon.FiringParent != null && !weapon.FiringParent.IsAerospaceUnit;
			float num5 = weapon.CruiseAltitude_ASL * 0.9f;
			int num6 = 1;
			if (flag2)
			{
				num6 = 2;
			}
			if (weapon.TimeSinceLaunch + (float)num6 < (float)weapon.TotalBurnTime && weapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < num5 && (double)num2 * 1852.0 > (double)(2f * weapon.CruiseAltitude_ASL))
			{
				float num7 = 30f;
				if (flag2)
				{
					num7 = 60f;
				}
				float num8 = weapon.CruiseAltitude_ASL - weapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
				float num9 = (float)Math2.Tand((double)(num8 / num2) * 1852.0);
				weapon.DesiredPitch = num7 - (num7 - num9) * (1f - num8 / weapon.CruiseAltitude_ASL);
				weapon.DesiredAltitude = weapon.CruiseAltitude_ASL;
				return;
			}
			float num10 = 2f;
			float num11 = 2f;
			if (flag && PrimaryTarget != null)
			{
				Geopoint_Struct geopoint_Struct2 = weapon.Navigator.ComputeIntercept_3D(PrimaryTarget);
				if (!geopoint_Struct2.HasZeroCoords)
				{
					thePoint = geopoint_Struct2;
					flag = false;
				}
			}
			double latitude = thePoint.Latitude;
			double longitude = thePoint.Longitude;
			float num12 = thePoint.Altitude;
			float cruiseAltitude_ASL = weapon.CruiseAltitude_ASL;
			float num13 = Module_Unit.RangeToPoint_Horiz(weapon, latitude, longitude, GlobalVariables.ObjectTrue);
			float num14 = weapon.LaunchPoint.RangeToPoint_Horiz(longitude, latitude);
			float num15 = num13 / num14;
			if (weapon.MaxAirRange / num14 > 2f)
			{
				num10 = 1f + num14 / weapon.MaxAirRange;
			}
			if (flag)
			{
				float num16 = 0.75f * weapon.Sensory.GetTerminalSensorMaxRange();
				if (num13 > num16)
				{
					num12 += (weapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - num12) * (num16 / (num13 + num16));
				}
			}
			float num17 = num10 * cruiseAltitude_ASL - num12;
			num17 = num12 + (float)((double)num17 * Math.Pow(num15, num11));
			if (weapon.TimeSinceLaunch > 0f && num17 > num12 && num12 > weapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) && weapon.Attitude_Pitch > 0f && (double)num13 * 1852.0 < (double)((num17 - weapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) / 2f))
			{
				num17 = num12;
			}
			Calculate_And_Set_DesiredPitch(latitude, longitude, num17);
			weapon.DesiredAltitude = num17;
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

	private void method_17(float float_2)
	{
		Weapon weapon = (Weapon)myUnit;
		try
		{
			float num = Module_Unit.ClosureSpeed(myUnit, PrimaryTarget, Module_Unit.CurrentSpeed_Horizontal(weapon), myUnit.CurrentHeading);
			if (PrimaryTarget == null)
			{
				return;
			}
			float num2;
			Geopoint_Struct geopoint_Struct = default(Geopoint_Struct);
			if (PrimaryTarget.CurrentSpeed == 0f)
			{
				num2 = myUnit.RangeToUnit_Horiz(PrimaryTarget, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
			}
			else
			{
				float mySpeed = ((!weapon.SupportsAttitude_Pitch) ? ((float)weapon.Kinematics.GetMaximumSpeed()) : ((float)((double)weapon.Kinematics.GetMaximumSpeed() * 0.5)));
				geopoint_Struct = weapon.Navigator.ComputeInterceptPoint_BruteForce(mySpeed, PrimaryTarget, num);
				num2 = (geopoint_Struct.HasZeroCoords ? myUnit.RangeToUnit_Horiz(PrimaryTarget, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue) : Module_Unit.RangeToPoint_Horiz(weapon, geopoint_Struct, GlobalVariables.ObjectTrue));
			}
			int num3 = (weapon.Navigator.HasPlottedCourse() ? ((int)Math.Round(weapon.Navigator.PlottedCourse[0].Altitude)) : ((int)Math.Round(weapon.ImpactAltitude)));
			if (geopoint_Struct.HasZeroCoords)
			{
				float mySpeed2 = (weapon.SupportsAttitude_Pitch ? ((float)((double)weapon.Kinematics.GetMaximumSpeed() * 0.5)) : ((float)weapon.Kinematics.GetMaximumSpeed()));
				geopoint_Struct = weapon.Navigator.ComputeInterceptPoint_BruteForce(mySpeed2, PrimaryTarget, num);
			}
			float altDiff = (float)num3 - myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			float num4 = Math.Abs(myUnit.Kinematics.HorizDistranceRequiredToReachDesiredAltitude(myUnit, num3, num));
			if (!weapon.IsReEntryVehicle)
			{
				if (method_15() && PrimaryTarget.Type == Contact_Base.ContactType.ActivationPoint)
				{
					if (weapon.CruiseAltitude_AGL > 0f)
					{
						myUnit.DesiredAltitude = weapon.CruiseAltitude_AGL + (float)Math.Max(0, ((Module_Unit.Unit)weapon).get_LandElevation_next(AGL: false, 1f));
					}
					else
					{
						myUnit.DesiredAltitude = weapon.CruiseAltitude_ASL;
					}
					if (myUnit.DesiredAltitude > myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + 500f)
					{
						PitchForLoftArc(float_2, geopoint_Struct);
					}
					else
					{
						CalculateDesiredPitch(null, float_2);
					}
					return;
				}
				float num5 = (float)((double)weapon.MaxRange_NoTargetType * 0.25);
				if (!(num2 > num4) && (!(num2 > num5) || (PrimaryTarget.Type != Contact_Base.ContactType.Air && PrimaryTarget.Type != Contact_Base.ContactType.Missile) || weapon.DataLinkParent != null))
				{
					PerformTerminalDive(altDiff, float_2, num);
				}
				else if (!TerminalDive)
				{
					if (weapon.CruiseAltitude_AGL > 0f)
					{
						myUnit.DesiredAltitude = weapon.CruiseAltitude_AGL + (float)Math.Max(0, ((Module_Unit.Unit)weapon).get_LandElevation_next(AGL: false, 1f));
					}
					else
					{
						myUnit.DesiredAltitude = weapon.CruiseAltitude_ASL;
					}
					if (myUnit.DesiredAltitude > myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + 500f)
					{
						PitchForLoftArc(float_2, geopoint_Struct);
						return;
					}
					CalculateDesiredPitch(null, float_2);
					if (myUnit.DesiredPitch < -45f)
					{
						myUnit.DesiredPitch = -45f;
					}
				}
				else
				{
					PerformTerminalDive(altDiff, float_2, num);
				}
			}
			else if (!weapon.Navigator.HasPlottedCourse())
			{
				myUnit.DesiredAltitude = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - float_2 * myUnit.Kinematics.DiveRate_Nominal();
				CalculateDesiredPitch(null, float_2);
			}
			else if (weapon.Navigator.PlottedCourse.First().Altitude < myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) && weapon.HasRVs.Value)
			{
				myUnit.DesiredAltitude = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			}
			else
			{
				myUnit.DesiredAltitude = weapon.Navigator.PlottedCourse.First().Altitude;
				CalculateDesiredPitch(weapon.Navigator.PlottedCourse.First(), float_2);
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

	protected virtual void Trajectory_LoftedFlight(float elapsedTime)
	{
		if (PrimaryTarget != null)
		{
			if (!PrimaryTarget.IsAir_Missile_Orbital_Contact)
			{
				method_17(elapsedTime);
			}
			else
			{
				method_16(elapsedTime);
			}
		}
	}

	public void PerformTerminalDive(float AltDiff, float elapsedTime, float ClosureRateToPrimaryTarget)
	{
		TerminalDive = true;
		Weapon weapon = (Weapon)myUnit;
		float num = myUnit.RangeToUnit_Horiz(PrimaryTarget, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
		Geopoint_Struct thePoint = weapon.Navigator.ComputeInterceptPoint_BruteForce(Module_Unit.CurrentSpeed_Horizontal(weapon), PrimaryTarget, ClosureRateToPrimaryTarget, num);
		float num2 = (thePoint.HasZeroCoords ? num : Module_Unit.RangeToPoint_Horiz(myUnit, thePoint, GlobalVariables.ObjectTrue));
		if (AltDiff < 0f)
		{
			if (!weapon.SupportsAttitude_Pitch)
			{
				float num3 = myUnit.CurrentSpeed * elapsedTime / 3600f;
				myUnit.DesiredAltitude = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - num3 * Math.Abs(AltDiff) / num2;
				return;
			}
			weapon.DesiredAltitude = weapon.ImpactAltitude;
			AltDiff = weapon.DesiredAltitude - weapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			double num4 = Math.Atan2(AltDiff, (double)num2 * 1852.0) * 57.2957795130823;
			float desiredPitch = (float)Math.Min(-1.0, num4 + (double)num2);
			weapon.DesiredPitch = desiredPitch;
		}
		else if (weapon.SupportsAttitude_Pitch)
		{
			myUnit.DesiredAltitude = weapon.ImpactAltitude;
			if (!thePoint.HasZeroCoords)
			{
				Calculate_And_Set_DesiredPitch(thePoint.Latitude, thePoint.Longitude, thePoint.Altitude);
			}
			else
			{
				Calculate_And_Set_DesiredPitch(((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
			}
		}
		else
		{
			float num5 = myUnit.CurrentSpeed * elapsedTime / 3600f;
			myUnit.DesiredAltitude = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + num5 * Math.Abs(AltDiff) / num2;
		}
	}

	static Weapon_AI()
	{
		Class72.smethod_20();
	}
}
