using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading;
using System.Xml;
using Collections.Pooled;
using Command_Core.DAL;
using ConcurrentObservableCollections.ConcurrentObservableDictionary;
using CSMaterial.ClipperLib;
using Cysharp.Text;
using DotSpatial.Topology;
using Easy.Common;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ServiceStack.Text;
using ThreadSafeCollections;

namespace Command_Core;

public class Contact : Contact_Base, IEquatable<Contact>, Ipoolable
{
	public struct Detection_Struct
	{
		public string DetectorUnitID;

		public string DetectingSensorID;

		public Sensor DetectingSensor;

		public float RangeEstimate;

		public ActiveUnit_Sensory.SpecialDetectionMode theDetectionMode;

		public DateTime theTime;

		public Detection_Struct(string detectorUnitID, Sensor theSensor, float rangeEstimate, ActiveUnit_Sensory.SpecialDetectionMode theDetectionMode, DateTime theTime)
		{
			this = default(Detection_Struct);
			DetectorUnitID = detectorUnitID;
			DetectingSensor = theSensor;
			if (theSensor == null)
			{
				DetectingSensorID = null;
			}
			else
			{
				DetectingSensorID = theSensor.ObjectID;
			}
			RangeEstimate = rangeEstimate;
			this.theDetectionMode = theDetectionMode;
			this.theTime = theTime;
		}

		static Detection_Struct()
		{
			Class72.smethod_20();
		}
	}

	public delegate void BDA_ChangedEventHandler(Contact theC);

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct ExpirationTimes
	{
		public static int Air;

		public static int Missile;

		public static int Orbital;

		public static int Torpedo;

		public static int Surface;

		public static int Mobile;

		public static int Submarine;

		public static int AGU;

		static ExpirationTimes()
		{
			Class72.smethod_20();
			Air = 300;
			Missile = 300;
			Orbital = 300;
			Torpedo = 600;
			Surface = 7200;
			Mobile = 7200;
			Submarine = 21600;
			AGU = 604800;
		}
	}

	public enum BDA_StructuralIntegrityLevel : byte
	{
		Undamaged,
		LightDamage,
		MediumDamage,
		HeavyDamage,
		Destroyed
	}

	public sealed class HostedUnitReconRecord
	{
		public string UnitID;

		public IdentificationStatus IDStatus;

		public float ReconAge;

		public string ToXML()
		{
			string result = default(string);
			try
			{
				StringBuilder stringBuilder = StringBuilderCache.Allocate();
				stringBuilder.Clear();
				stringBuilder.Append("<HURR>");
				stringBuilder.Append("<UID>").Append(UnitID).Append("</UID>");
				stringBuilder.Append("<IDS>").Append(Conversions.ToString((int)IDStatus)).Append("</IDS>");
				stringBuilder.Append("<RA>").Append(XmlConvert.ToString(ReconAge)).Append("</RA>");
				stringBuilder.Append("</HURR>");
				string text = stringBuilder.ToString();
				StringBuilderCache.Free(stringBuilder);
				result = text;
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101312340958903458932993", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return result;
		}

		public void ToXML(ref XmlWriter theWriter)
		{
			try
			{
				theWriter.WriteStartElement("HURR");
				theWriter.WriteElementString("UID", UnitID);
				theWriter.WriteElementString("IDS", Conversions.ToString((int)IDStatus));
				theWriter.WriteElementString("RA", XmlConvert.ToString(ReconAge));
				theWriter.WriteEndElement();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101313", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}

		public static HostedUnitReconRecord FromXML(XmlNode theNode)
		{
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Expected O, but got Unknown
			HostedUnitReconRecord result;
			try
			{
				HostedUnitReconRecord hostedUnitReconRecord = new HostedUnitReconRecord();
				foreach (XmlNode childNode in theNode.ChildNodes)
				{
					XmlNode val = childNode;
					switch (val.Name)
					{
					case "UID":
						hostedUnitReconRecord.UnitID = val.InnerText;
						break;
					case "IDS":
						hostedUnitReconRecord.IDStatus = (IdentificationStatus)Conversions.ToShort(val.InnerText);
						break;
					case "RA":
						hostedUnitReconRecord.ReconAge = XmlConvert.ToSingle(val.InnerText);
						break;
					}
				}
				result = hostedUnitReconRecord;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101314", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = new HostedUnitReconRecord();
				ProjectData.ClearProjectError();
			}
			return result;
		}

		static HostedUnitReconRecord()
		{
			Class72.smethod_20();
		}
	}

	private string string_1;

	public ActiveUnit ActualUnit;

	public string _ActualUnitID;

	private bool bool_0;

	private bool bool_1;

	private Dictionary<Side, Misc.PostureStance> dictionary_0;

	private Dictionary<string, Misc.PostureStance> dictionary_1;

	private Misc.PostureStance? nullable_9;

	public bool RetreivedPostureOnThisPulse;

	public float TimeSinceDetection;

	public float TimeSinceBDA;

	public float TimeSinceRecon;

	public float TimeSinceESM_Identification;

	public bool IsFilteredOut;

	private Weapon[] weapon_0;

	public BDA_StructuralIntegrityLevel? BDA_StructuralIntegrity;

	public ActiveUnit_Damage.FireIntensityLevel? BDA_FireLevel;

	public ActiveUnit_Damage.FloodingIntensityLevel? BDA_FloodLevel;

	private List<HostedUnitReconRecord> list_2;

	public bool SpeedIsKnown;

	public bool HeadingIsKnown;

	public bool AltitudeIsKnown;

	public bool IsAutoDetection;

	private List<Geopoint_Struct> list_3;

	internal float UncertaintyArea_NextGrowElapsedStep;

	internal float UncertaintyArea_TimeToNextGrow;

	private float float_6;

	public float HeldFor;

	private bool bool_2;

	public float RemainingContinousTrackTime;

	public float RemainingContinousTrackTime_Precise;

	public Queue<Detection_Struct> LastDetections;

	[CompilerGenerated]
	[AccessedThroughProperty("_DetectedEmissions")]
	private TObservableDictionary<int, EmissionContainer> tobservableDictionary_0;

	public TObservableDictionary<int, EmissionContainer> _DetectedEmissionsPrevious;

	public List<int> ListOfESMMatches;

	private LockObject lockObject_0;

	internal float TimeSinceDetection_Radar;

	internal float TimeSinceDetection_ESM;

	internal float TimeSinceDetection_Visual;

	internal float TimeSinceDetection_Infrared;

	internal float TimeSinceDetection_SonarActive;

	internal float TimeSinceDetection_SonarPassive;

	internal bool SkipZoneChecks;

	public bool HasBeenCheckedForDestructionThisPulse;

	private bool bool_3;

	internal bool PrepareForCachedDLZCheck;

	internal TrajectoryPoint[] FutureBallisticPath;

	[CompilerGenerated]
	private static BDA_ChangedEventHandler bda_ChangedEventHandler_0;

	internal bool AppearsToBeLoitering;

	public bool IsFrozenCommsContact;

	private float? nullable_10;

	private float? nullable_11;

	private float? nullable_12;

	private float? nullable_13;

	private float? nullable_14;

	private IdentificationStatus identificationStatus_0;

	private float? nullable_15;

	private IdentificationStatus identificationStatus_1;

	private float? nullable_16;

	private IdentificationStatus identificationStatus_2;

	private GlobalVariables.BooleanObject booleanObject_0;

	protected int _KnownIncomingGuidedWeaponsCount;

	protected string _KnownIncomingGuidedWeaponsSideID;

	private LockObject lockObject_1;

	private GlobalVariables.BooleanObject booleanObject_1;

	private LockObject lockObject_2;

	[CompilerGenerated]
	private bool bool_4;

	private ThreadLocal<List<IntPoint>> threadLocal_0;

	private ThreadLocal<List<List<IntPoint>>> threadLocal_1;

	private ThreadLocal<List<List<IntPoint>>> threadLocal_2;

	public float Age
	{
		get
		{
			return float_6;
		}
		set
		{
			float_6 = value;
		}
	}

	private virtual TObservableDictionary<int, EmissionContainer> _DetectedEmissions
	{
		[CompilerGenerated]
		get
		{
			return tobservableDictionary_0;
		}
		[CompilerGenerated]
		set
		{
			NotifyCollectionChangedEventHandler value2 = method_6;
			TObservableDictionary<int, EmissionContainer> tObservableDictionary = tobservableDictionary_0;
			if (tObservableDictionary != null)
			{
				tObservableDictionary.CollectionChanged -= value2;
			}
			tobservableDictionary_0 = value;
			tObservableDictionary = tobservableDictionary_0;
			if (tObservableDictionary != null)
			{
				tObservableDictionary.CollectionChanged += value2;
			}
		}
	}

	public bool InheritsSideStance => bool_2;

	internal sealed override string Name
	{
		get
		{
			return base.Name;
		}
		set
		{
			base.Name = value;
			if (string.IsNullOrEmpty(value) & (ActualUnit != null))
			{
				ref Scenario parentScen = ref ActualUnit.ParentScen;
				Side theDetectorSide = ActualUnit.ParentScen.GetCurrentSide();
				UpdateContactName(ref parentScen, ref theDetectorSide, null, null, IsNCTRupdate: false, bool_5: false, GenerateMessage: false, "", LoggedMessage.MessageType.None, bool_6: false, SahreContacts: true);
			}
		}
	}

	public bool HasDetectedEmissions
	{
		get
		{
			if (_DetectedEmissions == null)
			{
				return false;
			}
			return _DetectedEmissions.Count != 0;
		}
	}

	public bool HasPreciselyDetectedEmissions
	{
		get
		{
			if (_DetectedEmissions != null && _DetectedEmissions.Count != 0)
			{
				List<EmissionContainer> list = new List<EmissionContainer>(_DetectedEmissions.Values);
				foreach (EmissionContainer item in list)
				{
					if (item.PreciseID)
					{
						return true;
					}
				}
			}
			return false;
		}
	}

	public TObservableDictionary<int, EmissionContainer> DetectedEmissions
	{
		get
		{
			if (_DetectedEmissions == null)
			{
				_DetectedEmissions = new TObservableDictionary<int, EmissionContainer>();
			}
			return _DetectedEmissions;
		}
		set
		{
			if (_DetectedEmissions != null)
			{
				_DetectedEmissionsPrevious = _DetectedEmissions;
			}
			_DetectedEmissions = value;
		}
	}

	public List<int> PossibleMatchesBasedOnEmissions
	{
		get
		{
			if (ActualUnit == null)
			{
				return new List<int>();
			}
			GlobalVariables.ActiveUnitType theUnitType;
			switch (Type)
			{
			case ContactType.Air:
				theUnitType = GlobalVariables.ActiveUnitType.Aircraft;
				break;
			case ContactType.Surface:
				theUnitType = GlobalVariables.ActiveUnitType.Ship;
				break;
			case ContactType.Submarine:
				theUnitType = GlobalVariables.ActiveUnitType.Submarine;
				break;
			default:
				return new List<int>();
			case ContactType.Orbital:
				theUnitType = GlobalVariables.ActiveUnitType.Satellite;
				break;
			case ContactType.Facility_Fixed:
			case ContactType.Facility_Mobile:
			case ContactType.AggregateGroundUnit:
				theUnitType = GlobalVariables.ActiveUnitType.Facility;
				break;
			case ContactType.Missile:
			case ContactType.Torpedo:
				theUnitType = GlobalVariables.ActiveUnitType.Weapon;
				break;
			}
			List<int> list = new List<int>();
			foreach (int key in DetectedEmissions.Keys)
			{
				if (DetectedEmissions[key].PreciseID)
				{
					list.Add(key);
				}
			}
			return DBFunctions.EW_GetAllUnitsMatchingTheseEmissions(list, theUnitType, ActualUnit.ParentScen, ActualUnit.ParentScen.DBConnection);
		}
	}

	public string DescriptionString
	{
		get
		{
			if (ActualUnit != null)
			{
				switch (this.IDStatus)
				{
				default:
					return "";
				case IdentificationStatus.Unknown:
					return "Type: Unknown";
				case IdentificationStatus.KnownDomain:
					switch (Type)
					{
					case ContactType.AggregateGroundUnit:
						return "Type: Unknown land formation";
					case ContactType.Air:
					case ContactType.Missile:
						return "Type: Unknown air contact";
					case ContactType.Surface:
						return "Type: Unknown surface contact";
					case ContactType.Facility_Fixed:
						return "Type: Unknown fixed facility";
					case ContactType.Facility_Mobile:
						return "Type: Unknown mobile land unit";
					case ContactType.Submarine:
					case ContactType.Torpedo:
						return "Type: Unknown underwater contact";
					default:
						return Type.ToString();
					case ContactType.Undetermined:
						return "Type: Undetermined";
					}
				case IdentificationStatus.KnownType:
					return "Type: " + ActualUnit.SubTypeDescription;
				case IdentificationStatus.KnownClass:
					return "Class: " + ActualUnit.UnitClass;
				case IdentificationStatus.PreciseID:
					return "Identified: " + ActualUnit.Name;
				}
			}
			return "";
		}
	}

	public bool IsClassifiedFalseTarget
	{
		get
		{
			if (this.IDStatus >= IdentificationStatus.KnownType)
			{
				if (!Information.IsNothing((object)ActualUnit))
				{
					ContactType type = Type;
					int result;
					if (type == ContactType.Submarine)
					{
						Submarine._SubmarineType type2 = ((Submarine)ActualUnit).Type;
						if ((uint)(type2 - 9001) <= 1u)
						{
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
				return false;
			}
			return false;
		}
	}

	public bool IsSpecificTargetForThisStrike
	{
		get
		{
			if (ActualUnit == null)
			{
				return false;
			}
			IReadOnlyCollection<Module_Unit.Unit> specificTargets = theStrike.SpecificTargets;
			if (specificTargets.Count != 0)
			{
				if (specificTargets.Contains(this))
				{
					return true;
				}
				if (specificTargets.Contains(ActualUnit))
				{
					return true;
				}
				return false;
			}
			return false;
		}
	}

	public override bool IsInsideThisArea
	{
		get
		{
			bool result = default(bool);
			try
			{
				if (UncertaintyArea == null)
				{
					result = ((Module_Unit.Unit)this).get_IsInsideThisArea(theArea, theScen, UseCache);
					return result;
				}
				foreach (Geopoint_Struct item in UncertaintyArea)
				{
					if (!GeoPoint.IsInsideThisArea(item.Latitude, item.Longitude, theArea.ToList(), UseCache))
					{
						result = false;
						return result;
					}
				}
				result = true;
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100489", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public bool IsOutOfUnguidedWeaponsRange
	{
		get
		{
			bool result = default(bool);
			try
			{
				float num = Module_Unit.RangeToUnit_Slant(FiringUnit, this, 0f, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
				List<Weapon> list = new List<Weapon>();
				foreach (Mount mount in FiringUnit.Mounts)
				{
					foreach (WeaponRec mountWeapon in mount.MountWeapons)
					{
						Weapon._WeaponType type = mountWeapon.get_ReferenceWeapon(FiringUnit.ParentScen).Type;
						if ((uint)(type - 2002) <= 2u)
						{
							list.Add(mountWeapon.get_ReferenceWeapon(FiringUnit.ParentScen));
						}
					}
				}
				foreach (Weapon item in list)
				{
					if (!(item.get_MaxRangeForThisTarget(FiringUnit, this, CheckWRA: true, FiringUnit.Doctrine, ManualFire: false) <= num))
					{
						result = false;
						return result;
					}
				}
				result = true;
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100490", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	internal int KnownIncomingGuidedWeaponsCount
	{
		get
		{
			Weapon[] incomingGuidedWeapons = IncomingGuidedWeapons;
			if (sensingSide != null)
			{
				if (Operators.CompareString(sensingSide.ObjectID, _KnownIncomingGuidedWeaponsSideID, false) != 0)
				{
					_KnownIncomingGuidedWeaponsSideID = sensingSide.ObjectID;
					_KnownIncomingGuidedWeaponsCount = 0;
					if (incomingGuidedWeapons != null)
					{
						Weapon[] array = incomingGuidedWeapons;
						foreach (Weapon weapon in array)
						{
							if (((ActiveUnit)weapon).get_UnitSide(SetSideOnly: false) != sensingSide && ((ActiveUnit)weapon).get_UnitSide(SetSideOnly: false).get_ConsidersThisSideToBe(sensingSide, (Scenario)null) != Misc.PostureStance.Friendly)
							{
								if (sensingSide.Contacts.ContainsKey(weapon.ObjectID))
								{
									_KnownIncomingGuidedWeaponsCount++;
								}
							}
							else
							{
								_KnownIncomingGuidedWeaponsCount++;
							}
						}
					}
					return _KnownIncomingGuidedWeaponsCount;
				}
				return _KnownIncomingGuidedWeaponsCount;
			}
			return incomingGuidedWeapons.Count();
		}
		set
		{
			_KnownIncomingGuidedWeaponsCount = value;
			if (sensingSide == null)
			{
				_KnownIncomingGuidedWeaponsSideID = "";
			}
			else
			{
				_KnownIncomingGuidedWeaponsSideID = sensingSide.ObjectID;
			}
		}
	}

	internal Weapon[] IncomingGuidedWeapons
	{
		get
		{
			Weapon[] result;
			if (weapon_0 != null)
			{
				result = weapon_0;
			}
			else
			{
				Weapon[] theArray = Array.Empty<Weapon>();
				if (ActualUnit != null)
				{
					Side originalDetectorSide = OriginalDetectorSide;
					try
					{
						if (ActualUnit.ParentScen.GuidedWeaponsInAir == null)
						{
							goto IL_030a;
						}
						PooledList<Weapon> guidedWeaponsInAir = ActualUnit.ParentScen.GuidedWeaponsInAir;
						if (guidedWeaponsInAir != null && guidedWeaponsInAir.Count == 0)
						{
							goto IL_030a;
						}
						PooledList<Weapon> guidedWeaponsInAir2 = ActualUnit.ParentScen.GuidedWeaponsInAir;
						if (guidedWeaponsInAir2 == null)
						{
							weapon_0 = theArray;
							result = theArray;
						}
						else if (ActualUnit == null)
						{
							weapon_0 = theArray;
							result = theArray;
						}
						else
						{
							if (guidedWeaponsInAir2.Count > 0)
							{
								string objectID = ObjectID;
								Weapon[] array = guidedWeaponsInAir2.InternalArray();
								Contact primaryTarget = default(Contact);
								for (int i = guidedWeaponsInAir2.Count - 1; i >= 0; i += -1)
								{
									Weapon weapon = array[i];
									if (weapon == null)
									{
										continue;
									}
									Weapon_AI aI = weapon.AI;
									Misc.PostureStance postureStance = originalDetectorSide?.get_ConsidersThisSideToBe(((ActiveUnit)weapon).get_UnitSide(SetSideOnly: false), (Scenario)null) ?? Misc.PostureStance.Friendly;
									if (postureStance != Misc.PostureStance.Friendly)
									{
										continue;
									}
									if (aI != null)
									{
										primaryTarget = aI.PrimaryTarget;
										if (primaryTarget != null)
										{
											if (primaryTarget == this || string.CompareOrdinal(primaryTarget.ObjectID, objectID) == 0)
											{
												if (weapon.FiringParent == null || weapon.FiringParent.CommStuff.IsConnectedToSideNetwork)
												{
													ArrayExtensions.Add(ref theArray, weapon);
												}
												continue;
											}
											if (primaryTarget.ActualUnit != null && ActualUnit != null && primaryTarget.ActualUnit == ActualUnit)
											{
												if (weapon.FiringParent == null || weapon.FiringParent.CommStuff.IsConnectedToSideNetwork)
												{
													ArrayExtensions.Add(ref theArray, weapon);
												}
												continue;
											}
										}
									}
									if (weapon.IsMIRVedMissile.Value && aI.IsTargetingThisContact(this))
									{
										ArrayExtensions.Add(ref theArray, weapon);
									}
									else if (weapon.Guidance == Weapon.WeaponGuidanceType.Inertial && primaryTarget != null && primaryTarget.Type == ContactType.Aimpoint && (double)primaryTarget.RangeToUnit_Horiz(this) * 1852.0 < 20.0)
									{
										ArrayExtensions.Add(ref theArray, weapon);
									}
								}
							}
							ActiveUnit[] array2;
							try
							{
								array2 = ActualUnit.ParentScen.NewbornUnits.ToArray();
							}
							catch (Exception projectError)
							{
								ProjectData.SetProjectError(projectError);
								array2 = ActualUnit.ParentScen.NewbornUnits.ToArray();
								ProjectData.ClearProjectError();
							}
							ActiveUnit[] array3 = array2;
							foreach (ActiveUnit activeUnit in array3)
							{
								if (activeUnit == null || !activeUnit.IsWeapon)
								{
									continue;
								}
								Misc.PostureStance postureStance2 = originalDetectorSide?.get_ConsidersThisSideToBe(activeUnit.get_UnitSide(SetSideOnly: false), (Scenario)null) ?? Misc.PostureStance.Friendly;
								if (postureStance2 != Misc.PostureStance.Friendly)
								{
									continue;
								}
								Contact primaryTarget2 = activeUnit.AI.PrimaryTarget;
								if (primaryTarget2 != null)
								{
									if (primaryTarget2 == this)
									{
										ArrayExtensions.Add(ref theArray, (Weapon)activeUnit);
									}
									else if (primaryTarget2.ActualUnit != null && ActualUnit != null && primaryTarget2.ActualUnit == ActualUnit)
									{
										ArrayExtensions.Add(ref theArray, (Weapon)activeUnit);
									}
								}
							}
							weapon_0 = theArray;
							result = theArray;
						}
						goto end_IL_002d;
						IL_030a:
						weapon_0 = theArray;
						result = theArray;
						end_IL_002d:;
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2?.Data.Add("Error at 200024", ex2.Message);
						GameGeneral.WriteExceptionsToLog(ex2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						result = theArray;
						ProjectData.ClearProjectError();
					}
				}
				else
				{
					result = theArray;
				}
			}
			return result;
		}
		set
		{
			weapon_0 = value;
		}
	}

	public sealed override Side UnitSide
	{
		get
		{
			if (SideIsKnown && ActualUnit != null)
			{
				_UnitSide = ActualUnit.get_UnitSide(SetSideOnly: false);
			}
			return _UnitSide;
		}
		set
		{
			_UnitSide = value;
		}
	}

	public GlobalVariables.TargetVisualSizeClass ApparentSize
	{
		get
		{
			ActiveUnit actualUnit = ActualUnit;
			switch (this.IDStatus)
			{
			default:
				return GlobalVariables.TargetVisualSizeClass.Stealthy;
			case IdentificationStatus.KnownClass:
			case IdentificationStatus.PreciseID:
				return actualUnit.VisualSizeClass;
			case IdentificationStatus.Unknown:
			case IdentificationStatus.KnownDomain:
			case IdentificationStatus.KnownType:
				return actualUnit.VisualSizeClass;
			}
		}
	}

	public bool IsAir_Missile_Orbital_Contact
	{
		get
		{
			int result;
			if (Type == ContactType.Air)
			{
				result = 1;
			}
			else
			{
				if (Type != ContactType.Missile)
				{
					return Type == ContactType.Orbital;
				}
				result = 1;
			}
			return (byte)result != 0;
		}
	}

	public bool IsAircraftContact => Type == ContactType.Air;

	public bool IsAir_GuidedWeapon_Contact
	{
		get
		{
			if (Type == ContactType.Air)
			{
				return true;
			}
			int result;
			if (Type == ContactType.Missile)
			{
				if (!IsBallisticTarget())
				{
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
	}

	public bool IsAir_Missile_Submarine_Contact
	{
		get
		{
			int result;
			if (Type != ContactType.Air)
			{
				if (Type != ContactType.Missile)
				{
					return Type == ContactType.Submarine;
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

	public bool IsGroundContact
	{
		get
		{
			if (Type != ContactType.Facility_Fixed && Type != ContactType.Facility_Mobile)
			{
				return Type == ContactType.AggregateGroundUnit;
			}
			return true;
		}
	}

	public bool IsShipContact => Type == ContactType.Surface;

	public bool IsOrbitalContact => Type == ContactType.Orbital;

	public bool IsWeaponContact
	{
		get
		{
			ContactType type = Type;
			if (type != ContactType.Missile && type - 9 > ContactType.Missile)
			{
				return false;
			}
			return true;
		}
	}

	public bool IsGuidedWeaponContact
	{
		get
		{
			ContactType type = Type;
			if (type == ContactType.Missile)
			{
				return true;
			}
			return false;
		}
	}

	public bool IsBiological
	{
		get
		{
			if (ActualUnit != null)
			{
				if (Type == ContactType.Submarine && ((Submarine)ActualUnit).IsBiological)
				{
					return true;
				}
				return false;
			}
			return false;
		}
	}

	public bool IsCivilian
	{
		get
		{
			if (ActualUnit != null)
			{
				if (!ActualUnit.IsCivilian)
				{
					return false;
				}
				return true;
			}
			return false;
		}
	}

	public List<Geopoint_Struct> UncertaintyArea
	{
		get
		{
			return list_3;
		}
		set
		{
			list_3 = value;
		}
	}

	public bool IsPreciselyLocatedOnThisPulse
	{
		get
		{
			return bool_0;
		}
		set
		{
			if (value)
			{
				UncertaintyArea = null;
			}
			bool_0 = value;
		}
	}

	public bool ChangedToFirmOnThisPulse
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public bool IsSinkingShip
	{
		get
		{
			int result;
			if (ActualUnit != null)
			{
				if (ActualUnit.IsShip)
				{
					return ((Ship)ActualUnit).IsSinking;
				}
				result = 0;
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}
	}

	public bool IsDestroyed
	{
		get
		{
			bool result;
			if (!HasBeenCheckedForDestructionThisPulse)
			{
				if (Type != ContactType.Aimpoint && Type != ContactType.ActivationPoint)
				{
					if (ActualUnit != null)
					{
						if (!ActualUnit.IsBeingDestroyed)
						{
							try
							{
								if (!theScen.NewbornUnits.Contains(ActualUnit))
								{
									ConcurrentObservableDictionary<string, ActiveUnit> activeUnits = theScen.ActiveUnits;
									string objectID = ActualUnit.ObjectID;
									ActiveUnit value = null;
									if (!activeUnits.TryGetValue(objectID, out value))
									{
										bool_3 = true;
										goto IL_0083;
									}
								}
								bool_3 = false;
								goto IL_0083;
								IL_0083:
								HasBeenCheckedForDestructionThisPulse = true;
								result = bool_3;
							}
							catch (Exception ex)
							{
								ProjectData.SetProjectError(ex);
								Exception ex2 = ex;
								ex2?.Data.Add("Error at 200025", ex2.Message);
								GameGeneral.WriteExceptionsToLog(ex2);
								int num;
								if (!Debugger.IsAttached)
								{
									num = 1;
								}
								else
								{
									Debugger.Break();
									num = 1;
								}
								result = (byte)num != 0;
								ProjectData.ClearProjectError();
							}
						}
						else
						{
							bool_3 = true;
							HasBeenCheckedForDestructionThisPulse = true;
							result = bool_3;
						}
					}
					else
					{
						bool_3 = true;
						HasBeenCheckedForDestructionThisPulse = true;
						result = bool_3;
					}
				}
				else
				{
					bool_3 = false;
					HasBeenCheckedForDestructionThisPulse = true;
					result = bool_3;
				}
			}
			else if (!bool_3 && ActualUnit != null && ActualUnit.IsMorituri)
			{
				bool_3 = true;
				result = bool_3;
			}
			else
			{
				result = bool_3;
			}
			return result;
		}
	}

	public IdentificationStatus IDStatus => _IDStatus;

	public IdentificationStatus IDStatusBypassIdentification
	{
		set
		{
			_IDStatus = value;
			nullable_10 = null;
			nullable_11 = null;
			nullable_13 = null;
		}
	}

	public IdentificationStatus IDStatus
	{
		set
		{
			try
			{
				if ((_IDStatus != IdentificationStatus.PreciseID || !IsAutoDetection) && value >= _IDStatus)
				{
					_IDStatus = value;
					nullable_10 = null;
					nullable_11 = null;
					nullable_13 = null;
					string distanceString = "";
					if (EstimatedDistance.HasValue)
					{
						distanceString = ((UncertaintyArea == null) ? Math.Round(EstimatedDistance.Value, 1).ToString() : ("Estimated " + Math.Round(EstimatedDistance.Value, 0)));
					}
					LoggedMessage.MessageType theMessageType = (StatusUpdateIsOnCommsGrid ? LoggedMessage.MessageType.ContactChange : LoggedMessage.MessageType.CommsIsolatedMessage);
					bool flag = default(bool);
					if (SensorThatCausedChange != null)
					{
						flag = !SensorThatCausedChange.ParentPlatform.CommStuff.IsConnectedToSideNetwork;
					}
					if (ActualUnit.get_IsEligibleForAutodetection(theDetectorSide) && !flag)
					{
						_IDStatus = IdentificationStatus.PreciseID;
					}
					if (_AutoIncrement == 0 && flag)
					{
						_AutoIncrement = new LockRandom(theScen.Time.Millisecond).Next(1, int.MaxValue);
					}
					UpdateContactName(ref theScen, ref theDetectorSide, SensorThatCausedChange, EstimatedDistance, IsNCTRupdate, bool_5, GenerateMessage, distanceString, theMessageType, flag, SahreContacts: true);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100493", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public bool IsPrivate
	{
		get
		{
			if (booleanObject_1 == null)
			{
				booleanObject_1 = Misc.ToBooleanObject(!ObserverSide.Contacts.ContainsKey(ActualUnit.ObjectID));
			}
			return booleanObject_1 == GlobalVariables.ObjectTrue;
		}
		set
		{
			booleanObject_1 = Misc.ToBooleanObject(value);
		}
	}

	public Misc.PostureStance Stance
	{
		get
		{
			Misc.PostureStance result;
			try
			{
				if (ActualUnit != null)
				{
					if (SideIsKnown && Module_Side.IsAlliedWithThisSide(ObserverSide, ActualUnit.get_UnitSide(SetSideOnly: false)))
					{
						result = Misc.PostureStance.Friendly;
					}
					else if (ObserverSide.AwarenessLevel == Side.AwarenessLevel_Enum.Omniscient && ObserverSide != null && ObserverSide.Postures_ReadOnly.Count > 0)
					{
						List<KeyValuePair<Side, Misc.PostureStance>> list = ObserverSide.Postures_ReadOnly.Where([SpecialName] (KeyValuePair<Side, Misc.PostureStance> theKVP) => theKVP.Key == ActualUnit.get_UnitSide(SetSideOnly: false)).ToList();
						result = ((list.Count != 0) ? list[0].Value : Misc.PostureStance.Unknown);
					}
					else
					{
						if (!this.get_IsPrivate(ObserverSide) && !RetreivedPostureOnThisPulse)
						{
							lock (lockObject_1)
							{
								int num;
								if (!RetreivedPostureOnThisPulse)
								{
									if (ActualUnit == null)
									{
										num = 4;
										goto IL_040e;
									}
									if (ActualUnit.IsMorituri)
									{
										num = 4;
										goto IL_040e;
									}
									ActualUnit.get_UnitSide(SetSideOnly: false);
									if (Type != ContactType.Missile && Type != ContactType.Torpedo)
									{
										if (SideIsKnown && bool_2)
										{
											Dictionary<Side, Misc.PostureStance> dictionary = new Dictionary<Side, Misc.PostureStance>(ActualUnit.ParentScen.Sides_ReadOnly.Length);
											Side[] sides_ReadOnly = ActualUnit.ParentScen.Sides_ReadOnly;
											foreach (Side side in sides_ReadOnly)
											{
												if (side == null)
												{
													continue;
												}
												ContactType type = Type;
												if (type - 18 <= ContactType.Submarine)
												{
													if (ActualUnit == null || (!side.BaseContacts.ContainsKey(ActualUnit.ObjectID) && !ActualUnit.get_IsEligibleForAutodetection(side)))
													{
														continue;
													}
													if (dictionary_0 != null)
													{
														PooledList<Side> pooledList = new PooledList<Side>(dictionary_0.Keys);
														foreach (Side item in pooledList)
														{
															if (dictionary.ContainsKey(item))
															{
																dictionary[item] = dictionary_0[item];
															}
															else
															{
																dictionary.Add(item, dictionary_0[item]);
															}
														}
														pooledList.Dispose();
													}
													if (!dictionary.ContainsKey(side))
													{
														dictionary.Add(side, side.get_ConsidersThisSideToBe(ActualUnit.get_UnitSide(SetSideOnly: false), (Scenario)null));
													}
												}
												else
												{
													if (ActualUnit == null || (!side.Contacts.ContainsKey(ActualUnit.ObjectID) && !ActualUnit.get_IsEligibleForAutodetection(side)))
													{
														continue;
													}
													if (dictionary_0 != null)
													{
														PooledList<Side> pooledList2 = new PooledList<Side>(dictionary_0.Keys);
														foreach (Side item2 in pooledList2)
														{
															if (!dictionary.ContainsKey(item2))
															{
																dictionary.Add(item2, dictionary_0[item2]);
															}
															else
															{
																dictionary[item2] = dictionary_0[item2];
															}
														}
														pooledList2.Dispose();
													}
													if (!dictionary.ContainsKey(side))
													{
														dictionary.Add(side, side.get_ConsidersThisSideToBe(ActualUnit.get_UnitSide(SetSideOnly: false), (Scenario)null));
													}
												}
											}
											dictionary_0 = dictionary;
										}
									}
									else
									{
										Dictionary<Side, Misc.PostureStance> dictionary2 = new Dictionary<Side, Misc.PostureStance>(ActualUnit.ParentScen.Sides_ReadOnly.Length);
										Side[] sides_ReadOnly2 = ActualUnit.ParentScen.Sides_ReadOnly;
										foreach (Side side2 in sides_ReadOnly2)
										{
											if (side2 != null && ActualUnit != null && side2.Contacts.ContainsKey(ActualUnit.ObjectID))
											{
												Misc.PostureStance postureStance = side2.get_ConsidersThisSideToBe(ActualUnit.get_UnitSide(SetSideOnly: false), (Scenario)null);
												if (postureStance == Misc.PostureStance.Friendly)
												{
													dictionary2.Add(side2, postureStance);
												}
												else
												{
													dictionary2.Add(side2, Misc.PostureStance.Hostile);
												}
											}
										}
										dictionary_0 = dictionary2;
									}
									RetreivedPostureOnThisPulse = true;
								}
								goto end_IL_00ae;
								IL_040e:
								result = (Misc.PostureStance)num;
								goto end_IL_0001;
								end_IL_00ae:;
							}
						}
						result = (dictionary_0.TryGetValue(ObserverSide, out var value) ? value : Misc.PostureStance.Unknown);
					}
				}
				else
				{
					result = Misc.PostureStance.Unknown;
				}
				end_IL_0001:;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200572", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				int num4;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
					num4 = 4;
				}
				else
				{
					num4 = 4;
				}
				result = (Misc.PostureStance)num4;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public Misc.PostureStance Stance
	{
		set
		{
			try
			{
				if (SideIsKnown && ActualUnit != null && Module_Side.IsAlliedWithThisSide(ObserverSide, ActualUnit.get_UnitSide(SetSideOnly: false)))
				{
					return;
				}
				if (MarkManually)
				{
					bool_2 = false;
				}
				else
				{
					bool_2 = true;
				}
				if (!dictionary_0.TryGetValue(ObserverSide, out var value2))
				{
					dictionary_0.Add(ObserverSide, value2);
				}
				bool? flag = value2 != value;
				if (dictionary_0.ContainsKey(ObserverSide))
				{
					dictionary_0[ObserverSide] = value;
				}
				if (flag != true)
				{
					return;
				}
				if (ObserverSide.Cache_ContactStancesOnThisPulse.ContainsKey(ObjectID))
				{
					ObserverSide.Cache_ContactStancesOnThisPulse[ObjectID] = value;
				}
				else
				{
					lock (lockObject_0)
					{
						ObserverSide.Cache_ContactStancesOnThisPulse.AddIfNotExists(ObjectID, value);
					}
				}
				if (SideIsKnown && this.get_UnitSide(SetSideOnly: false).AssignsCollectiveResponsibility && (value == Misc.PostureStance.Unfriendly || value == Misc.PostureStance.Hostile) && !Information.IsNothing((object)ActualUnit))
				{
					ObserverSide.set_ConsidersThisSideToBe(ActualUnit.get_UnitSide(SetSideOnly: false), (Scenario)null, value);
				}
				if (IsFilteredOut && (value == Misc.PostureStance.Unfriendly || value == Misc.PostureStance.Hostile))
				{
					IsFilteredOut = false;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100494", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public bool IsConsideredManouverable
	{
		get
		{
			ContactType type = Type;
			if (type != ContactType.Missile && type != ContactType.Orbital && type - 9 > ContactType.Missile)
			{
				return true;
			}
			return false;
		}
	}

	public bool IsFirm
	{
		get
		{
			if (UncertaintyArea == null)
			{
				if (Age > 1f)
				{
					return false;
				}
				return true;
			}
			return false;
		}
	}

	public bool isSurfaceOrLandContact => method_3() | IsLandContact;

	public bool IsLandContact
	{
		get
		{
			int result;
			switch (Type)
			{
			case ContactType.Facility_Fixed:
			case ContactType.Facility_Mobile:
				result = 1;
				break;
			case ContactType.ActivationPoint:
			case ContactType.AggregateGroundUnit:
				result = 1;
				break;
			default:
				return false;
			case ContactType.Aimpoint:
				result = 1;
				break;
			}
			return (byte)result != 0;
		}
	}

	public bool IsSubmergedContact
	{
		get
		{
			int result;
			switch (Type)
			{
			default:
				return false;
			case ContactType.Torpedo:
			case ContactType.Mine:
				result = 1;
				break;
			case ContactType.Submarine:
				result = 1;
				break;
			}
			return (byte)result != 0;
		}
	}

	public int AutoIncrement => _AutoIncrement;

	public PoolableObjectType PoolableType => PoolableObjectType.Contact;

	public bool GeneratedFromGuidanceIlluminationDetection
	{
		[CompilerGenerated]
		get
		{
			return bool_4;
		}
		[CompilerGenerated]
		set
		{
			bool_4 = value;
		}
	}

	public static event BDA_ChangedEventHandler BDA_Changed
	{
		[CompilerGenerated]
		add
		{
			BDA_ChangedEventHandler bDA_ChangedEventHandler = bda_ChangedEventHandler_0;
			BDA_ChangedEventHandler bDA_ChangedEventHandler2;
			do
			{
				bDA_ChangedEventHandler2 = bDA_ChangedEventHandler;
				BDA_ChangedEventHandler value2 = (BDA_ChangedEventHandler)Delegate.Combine(bDA_ChangedEventHandler2, value);
				bDA_ChangedEventHandler = Interlocked.CompareExchange(ref bda_ChangedEventHandler_0, value2, bDA_ChangedEventHandler2);
			}
			while ((object)bDA_ChangedEventHandler != bDA_ChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			BDA_ChangedEventHandler bDA_ChangedEventHandler = bda_ChangedEventHandler_0;
			BDA_ChangedEventHandler bDA_ChangedEventHandler2;
			do
			{
				bDA_ChangedEventHandler2 = bDA_ChangedEventHandler;
				BDA_ChangedEventHandler value2 = (BDA_ChangedEventHandler)Delegate.Remove(bDA_ChangedEventHandler2, value);
				bDA_ChangedEventHandler = Interlocked.CompareExchange(ref bda_ChangedEventHandler_0, value2, bDA_ChangedEventHandler2);
			}
			while ((object)bDA_ChangedEventHandler != bDA_ChangedEventHandler2);
		}
	}

	public override string ToString()
	{
		return Name;
	}

	public bool Equals(Contact other)
	{
		if (other == null)
		{
			return false;
		}
		if (this == other)
		{
			return true;
		}
		return string.CompareOrdinal(other.ObjectID, ObjectID) == 0;
	}

	internal new void Reinitialize()
	{
		base.Reinitialize();
		string_1 = null;
		ActualUnit = null;
		_ActualUnitID = null;
		bool_0 = false;
		bool_1 = false;
		RetreivedPostureOnThisPulse = false;
		IsFilteredOut = false;
		SpeedIsKnown = false;
		HeadingIsKnown = false;
		AltitudeIsKnown = false;
		bool_2 = true;
		SkipZoneChecks = false;
		HasBeenCheckedForDestructionThisPulse = false;
		bool_3 = false;
		PrepareForCachedDLZCheck = false;
		AppearsToBeLoitering = false;
		nullable_9 = null;
		BDA_StructuralIntegrity = null;
		BDA_FireLevel = null;
		BDA_FloodLevel = null;
		TimeSinceDetection_Radar = 0f;
		TimeSinceDetection_ESM = 0f;
		TimeSinceDetection_Visual = 0f;
		TimeSinceDetection_Infrared = 0f;
		TimeSinceDetection_SonarActive = 0f;
		TimeSinceDetection_SonarPassive = 0f;
		TimeSinceDetection = 0f;
		TimeSinceBDA = 0f;
		TimeSinceRecon = 0f;
		TimeSinceESM_Identification = 0f;
		UncertaintyArea_NextGrowElapsedStep = 0f;
		UncertaintyArea_TimeToNextGrow = 0f;
		Age = 0f;
		HeldFor = 0f;
		RemainingContinousTrackTime = 0f;
		RemainingContinousTrackTime_Precise = 0f;
		dictionary_0.Clear();
		if (dictionary_1 != null)
		{
			dictionary_1.Clear();
		}
		list_2.Clear();
		if (list_3 != null)
		{
			list_3.Clear();
		}
		LastDetections.Clear();
		if (_DetectedEmissions != null)
		{
			_DetectedEmissions.Clear();
		}
		if (_DetectedEmissionsPrevious != null)
		{
			_DetectedEmissionsPrevious.Clear();
		}
		if (ListOfESMMatches != null)
		{
			ListOfESMMatches.Clear();
		}
		if (weapon_0 != null)
		{
			Array.Clear(weapon_0, 0, weapon_0.Length);
		}
		if (FutureBallisticPath != null)
		{
			Array.Clear(FutureBallisticPath, 0, FutureBallisticPath.Length);
		}
		CurrentHeading = 0f;
		CurrentSpeed = 0f;
		((Module_Unit.Unit)this).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, 0f);
		UnitClass = "";
		_UnitSide = null;
		Message = "";
		ActualUnit = null;
		IsPreciselyLocatedOnThisPulse = false;
		RemainingContinousTrackTime = 0f;
		RemainingContinousTrackTime_Precise = 0f;
		TimeSinceDetection = 0f;
		TimeSinceBDA = 0f;
		TimeSinceRecon = 0f;
		SideIsKnown = false;
		bool_2 = false;
		dictionary_0.Clear();
		Type = ContactType.Air;
		IsFilteredOut = false;
		BDA_StructuralIntegrity = null;
		BDA_FireLevel = null;
		BDA_FloodLevel = null;
		HeadingIsKnown = false;
		SpeedIsKnown = false;
		AltitudeIsKnown = false;
		IsAutoDetection = false;
		IsFrozenCommsContact = false;
		list_3 = null;
		Age = 0f;
		HeldFor = 0f;
		OriginalDetectorSide = null;
		DetectedEmissions = null;
		list_2.Clear();
		TimeSinceDetection_Radar = 0f;
		TimeSinceDetection_ESM = 0f;
		TimeSinceDetection_Visual = 0f;
		TimeSinceDetection_Infrared = 0f;
		TimeSinceDetection_SonarActive = 0f;
		TimeSinceDetection_SonarPassive = 0f;
		LastDetections.Clear();
		SkipZoneChecks = false;
		CurrentVerticalRate_mpersec = null;
	}

	void Ipoolable.Reinitialize()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Reinitialize
		this.Reinitialize();
	}

	internal int QuantityOfIncomingNukes()
	{
		int result;
		try
		{
			Weapon[] incomingGuidedWeapons = IncomingGuidedWeapons;
			int num = default(int);
			for (int i = 0; i < incomingGuidedWeapons.Length; i = checked(i + 1))
			{
				if (incomingGuidedWeapons[i].IsNuke.Value)
				{
					num++;
				}
			}
			result = num;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101097", "");
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
			result = num2;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void AgeDetectedEmissions(float elapsedTime)
	{
		TObservableDictionary<int, EmissionContainer> detectedEmissions = _DetectedEmissions;
		if (detectedEmissions == null)
		{
			_DetectedEmissions = new TObservableDictionary<int, EmissionContainer>();
			detectedEmissions = _DetectedEmissions;
		}
		if (detectedEmissions.Count > 0)
		{
			IEnumerator<KeyValuePair<int, EmissionContainer>> enumerator = detectedEmissions.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.Value.Age += elapsedTime;
			}
		}
	}

	public void CombineContactData(Contact _Contact)
	{
		if (!SpeedIsKnown)
		{
			SpeedIsKnown = _Contact.SpeedIsKnown;
		}
		if (!AltitudeIsKnown)
		{
			AltitudeIsKnown = _Contact.AltitudeIsKnown;
		}
		if (!HeadingIsKnown)
		{
			HeadingIsKnown = _Contact.HeadingIsKnown;
		}
		if (!SideIsKnown)
		{
			SideIsKnown = _Contact.SideIsKnown;
		}
	}

	public string ToXML(HashSet<string> ObjectsAlreadySerialized, Side DetectorSide)
	{
		Utf16ValueStringBuilder utf16ValueStringBuilder = ZString.CreateStringBuilder();
		try
		{
			utf16ValueStringBuilder.Append("<Contact>");
			utf16ValueStringBuilder.Append("<ID>");
			utf16ValueStringBuilder.Append(ObjectID);
			utf16ValueStringBuilder.Append("</ID>");
			if (ObjectsAlreadySerialized != null)
			{
				if (ObjectsAlreadySerialized.Contains(ObjectID))
				{
					utf16ValueStringBuilder.Append("</Contact>");
					return utf16ValueStringBuilder.ToString();
				}
				ObjectsAlreadySerialized.Add(ObjectID);
			}
			utf16ValueStringBuilder.Append("<Name>");
			utf16ValueStringBuilder.Append(SecurityElement.Escape(Name));
			utf16ValueStringBuilder.Append("</Name>");
			if (CurrentHeading != 0f)
			{
				utf16ValueStringBuilder.Append("<CH>");
				utf16ValueStringBuilder.Append(XmlConvert.ToString(CurrentHeading));
				utf16ValueStringBuilder.Append("</CH>");
			}
			if (CurrentSpeed != 0f)
			{
				utf16ValueStringBuilder.Append("<CS>");
				utf16ValueStringBuilder.Append(XmlConvert.ToString(CurrentSpeed));
				utf16ValueStringBuilder.Append("</CS>");
			}
			if (((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) != 0f)
			{
				utf16ValueStringBuilder.Append("<CA>");
				utf16ValueStringBuilder.Append(XmlConvert.ToString(((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)));
				utf16ValueStringBuilder.Append("</CA>");
			}
			if (base.Altitude_old != ((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))
			{
				utf16ValueStringBuilder.Append("<CAO>");
				utf16ValueStringBuilder.Append(XmlConvert.ToString(base.Altitude_old));
				utf16ValueStringBuilder.Append("</CAO>");
			}
			utf16ValueStringBuilder.Append("<Lon>");
			utf16ValueStringBuilder.Append(XmlConvert.ToString(((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null)));
			utf16ValueStringBuilder.Append("</Lon>");
			utf16ValueStringBuilder.Append("<Lat>");
			utf16ValueStringBuilder.Append(XmlConvert.ToString(((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null)));
			utf16ValueStringBuilder.Append("</Lat>");
			if (!string.IsNullOrEmpty(UnitClass))
			{
				utf16ValueStringBuilder.Append("<UnitClass>");
				utf16ValueStringBuilder.Append(UnitClass);
				utf16ValueStringBuilder.Append("</UnitClass>");
			}
			if (_UnitSide != null)
			{
				utf16ValueStringBuilder.Append("<Side>");
				utf16ValueStringBuilder.Append(SecurityElement.Escape(_UnitSide.Name));
				utf16ValueStringBuilder.Append("</Side>");
			}
			if (!string.IsNullOrEmpty(Message))
			{
				utf16ValueStringBuilder.Append("<Message>");
				utf16ValueStringBuilder.Append(SecurityElement.Escape(Message));
				utf16ValueStringBuilder.Append("</Message>");
			}
			if (ActualUnit != null)
			{
				utf16ValueStringBuilder.Append("<ActualUnitID>");
				utf16ValueStringBuilder.Append(ActualUnit.ObjectID);
				utf16ValueStringBuilder.Append("</ActualUnitID>");
			}
			if (IsPreciselyLocatedOnThisPulse)
			{
				utf16ValueStringBuilder.Append("<IPLOTP>");
				utf16ValueStringBuilder.Append("True");
				utf16ValueStringBuilder.Append("</IPLOTP>");
			}
			if (RemainingContinousTrackTime != 0f)
			{
				utf16ValueStringBuilder.Append("<RCTT>");
				utf16ValueStringBuilder.Append(XmlConvert.ToString(RemainingContinousTrackTime));
				utf16ValueStringBuilder.Append("</RCTT>");
			}
			if (RemainingContinousTrackTime_Precise != 0f)
			{
				utf16ValueStringBuilder.Append("<RCTTP>");
				utf16ValueStringBuilder.Append(XmlConvert.ToString(RemainingContinousTrackTime_Precise));
				utf16ValueStringBuilder.Append("</RCTTP>");
			}
			utf16ValueStringBuilder.Append("<IDStatus>");
			int iDStatus = (int)_IDStatus;
			utf16ValueStringBuilder.Append(iDStatus.ToString());
			utf16ValueStringBuilder.Append("</IDStatus>");
			if (TimeSinceDetection != 0f)
			{
				utf16ValueStringBuilder.Append("<TSD>");
				utf16ValueStringBuilder.Append(TimeSinceDetection.ToString());
				utf16ValueStringBuilder.Append("</TSD>");
			}
			if (TimeSinceBDA != 0f)
			{
				utf16ValueStringBuilder.Append("<TS_BDA>");
				utf16ValueStringBuilder.Append(((int)Math.Round(TimeSinceBDA)).ToString());
				utf16ValueStringBuilder.Append("</TS_BDA>");
			}
			if (TimeSinceRecon != 0f)
			{
				utf16ValueStringBuilder.Append("<TS_Recon>");
				utf16ValueStringBuilder.Append(((int)Math.Round(TimeSinceRecon)).ToString());
				utf16ValueStringBuilder.Append("</TS_Recon>");
			}
			if (SideIsKnown)
			{
				utf16ValueStringBuilder.Append("<SIK>");
				utf16ValueStringBuilder.Append(SideIsKnown.ToString());
				utf16ValueStringBuilder.Append("</SIK>");
			}
			if (bool_2)
			{
				utf16ValueStringBuilder.Append("<ISS>");
				utf16ValueStringBuilder.Append("True");
				utf16ValueStringBuilder.Append("</ISS>");
			}
			if (dictionary_0.Count > 0)
			{
				utf16ValueStringBuilder.Append("<Stance>");
				foreach (KeyValuePair<Side, Misc.PostureStance> item in dictionary_0)
				{
					utf16ValueStringBuilder.Append("<Stance_");
					utf16ValueStringBuilder.Append(item.Key.ObjectID);
					utf16ValueStringBuilder.Append(">");
					utf16ValueStringBuilder.Append(((int)item.Value).ToString());
					utf16ValueStringBuilder.Append("</Stance_");
					utf16ValueStringBuilder.Append(item.Key.ObjectID);
					utf16ValueStringBuilder.Append(">");
				}
				utf16ValueStringBuilder.Append("</Stance>");
			}
			if (!Information.IsNothing((object)Type))
			{
				utf16ValueStringBuilder.Append("<Type>");
				iDStatus = (int)Type;
				utf16ValueStringBuilder.Append(iDStatus.ToString());
				utf16ValueStringBuilder.Append("</Type>");
			}
			if (IsFilteredOut)
			{
				utf16ValueStringBuilder.Append("<IFO>");
				utf16ValueStringBuilder.Append("True");
				utf16ValueStringBuilder.Append("</IFO>");
			}
			if (BDA_StructuralIntegrity.HasValue)
			{
				utf16ValueStringBuilder.Append("<BDA_Struct>");
				utf16ValueStringBuilder.Append(((byte)BDA_StructuralIntegrity.Value).ToString());
				utf16ValueStringBuilder.Append("</BDA_Struct>");
			}
			if (BDA_FireLevel.HasValue)
			{
				utf16ValueStringBuilder.Append("<BDA_Fire>");
				utf16ValueStringBuilder.Append(((byte)BDA_FireLevel.Value).ToString());
				utf16ValueStringBuilder.Append("</BDA_Fire>");
			}
			if (BDA_FloodLevel.HasValue)
			{
				utf16ValueStringBuilder.Append("<BDA_Flood>");
				utf16ValueStringBuilder.Append(((byte)BDA_FloodLevel.Value).ToString());
				utf16ValueStringBuilder.Append("</BDA_Flood>");
			}
			if (HeadingIsKnown)
			{
				utf16ValueStringBuilder.Append("<H_Known>");
				utf16ValueStringBuilder.Append("True");
				utf16ValueStringBuilder.Append("</H_Known>");
			}
			if (SpeedIsKnown)
			{
				utf16ValueStringBuilder.Append("<S_Known>");
				utf16ValueStringBuilder.Append("True");
				utf16ValueStringBuilder.Append("</S_Known>");
			}
			if (AltitudeIsKnown)
			{
				utf16ValueStringBuilder.Append("<A_Known>");
				utf16ValueStringBuilder.Append("True");
				utf16ValueStringBuilder.Append("</A_Known>");
			}
			if (list_3 != null)
			{
				utf16ValueStringBuilder.Append("<UA>");
				foreach (Geopoint_Struct item2 in list_3)
				{
					utf16ValueStringBuilder.Append(item2.ToXML(ObjectsAlreadySerialized));
				}
				utf16ValueStringBuilder.Append("</UA>");
			}
			if (Age != 0f)
			{
				utf16ValueStringBuilder.Append("<Age>");
				utf16ValueStringBuilder.Append(XmlConvert.ToString(Age));
				utf16ValueStringBuilder.Append("</Age>");
			}
			if (HeldFor != 0f)
			{
				utf16ValueStringBuilder.Append("<HeldFor>");
				utf16ValueStringBuilder.Append(XmlConvert.ToString(HeldFor));
				utf16ValueStringBuilder.Append("</HeldFor>");
			}
			utf16ValueStringBuilder.Append("<AInc>");
			utf16ValueStringBuilder.Append(_AutoIncrement.ToString());
			utf16ValueStringBuilder.Append("</AInc>");
			if (!Information.IsNothing((object)OriginalDetectorSide))
			{
				utf16ValueStringBuilder.Append("<ODS>");
				utf16ValueStringBuilder.Append(SecurityElement.Escape(OriginalDetectorSide.Name));
				utf16ValueStringBuilder.Append("</ODS>");
			}
			if (!Information.IsNothing((object)OriginalDetectorUnitID))
			{
				utf16ValueStringBuilder.Append("<ODU>");
				utf16ValueStringBuilder.Append(SecurityElement.Escape(OriginalDetectorUnitID));
				utf16ValueStringBuilder.Append("</ODU>");
			}
			if (!Information.IsNothing((object)DetectedEmissions) && HasDetectedEmissions)
			{
				utf16ValueStringBuilder.Append("<DEm>");
				foreach (KeyValuePair<int, EmissionContainer> detectedEmission in DetectedEmissions)
				{
					if (detectedEmission.Value != null)
					{
						utf16ValueStringBuilder.Append("<Emission");
						utf16ValueStringBuilder.Append(Conversions.ToString(detectedEmission.Key));
						utf16ValueStringBuilder.Append(">");
						utf16ValueStringBuilder.Append(detectedEmission.Value.ToString());
						utf16ValueStringBuilder.Append("</Emission");
						utf16ValueStringBuilder.Append(Conversions.ToString(detectedEmission.Key));
						utf16ValueStringBuilder.Append(">");
					}
				}
				utf16ValueStringBuilder.Append("</DEm>");
			}
			if (list_2.Count > 0)
			{
				utf16ValueStringBuilder.Append("<RHU>");
				foreach (HostedUnitReconRecord item3 in list_2)
				{
					utf16ValueStringBuilder.Append(item3.ToXML());
				}
				utf16ValueStringBuilder.Append("</RHU>");
			}
			if (TimeSinceDetection_Radar != -1f)
			{
				utf16ValueStringBuilder.Append("<TSD_Radar>");
				utf16ValueStringBuilder.Append(TimeSinceDetection_Radar.ToString());
				utf16ValueStringBuilder.Append("</TSD_Radar>");
			}
			if (TimeSinceDetection_ESM != -1f)
			{
				utf16ValueStringBuilder.Append("<TSD_ESM>");
				utf16ValueStringBuilder.Append(TimeSinceDetection_ESM.ToString());
				utf16ValueStringBuilder.Append("</TSD_ESM>");
			}
			if (TimeSinceDetection_Visual != -1f)
			{
				utf16ValueStringBuilder.Append("<TSD_Visual>");
				utf16ValueStringBuilder.Append(TimeSinceDetection_Visual.ToString());
				utf16ValueStringBuilder.Append("</TSD_Visual>");
			}
			if (TimeSinceDetection_Infrared != -1f)
			{
				utf16ValueStringBuilder.Append("<TSD_Infrared>");
				utf16ValueStringBuilder.Append(TimeSinceDetection_Infrared.ToString());
				utf16ValueStringBuilder.Append("</TSD_Infrared>");
			}
			if (TimeSinceDetection_SonarActive != -1f)
			{
				utf16ValueStringBuilder.Append("<TSD_SonarActive>");
				utf16ValueStringBuilder.Append(TimeSinceDetection_SonarActive.ToString());
				utf16ValueStringBuilder.Append("</TSD_SonarActive>");
			}
			if (TimeSinceDetection_SonarPassive != -1f)
			{
				utf16ValueStringBuilder.Append("<TSD_SonarPassive>");
				utf16ValueStringBuilder.Append(TimeSinceDetection_SonarPassive.ToString());
				utf16ValueStringBuilder.Append("</TSD_SonarPassive>");
			}
			if (LastDetections.Count > 0)
			{
				utf16ValueStringBuilder.Append("<LastDetections>");
				try
				{
					foreach (Detection_Struct lastDetection in LastDetections)
					{
						utf16ValueStringBuilder.Append("<DET>");
						utf16ValueStringBuilder.Append("<DetectorUnitID>");
						utf16ValueStringBuilder.Append(SecurityElement.Escape(lastDetection.DetectorUnitID));
						utf16ValueStringBuilder.Append("</DetectorUnitID>");
						utf16ValueStringBuilder.Append("<DetectingSensorID>");
						utf16ValueStringBuilder.Append(SecurityElement.Escape(lastDetection.DetectingSensorID));
						utf16ValueStringBuilder.Append("</DetectingSensorID>");
						utf16ValueStringBuilder.Append("<RangeEstimate>");
						utf16ValueStringBuilder.Append(XmlConvert.ToString(lastDetection.RangeEstimate));
						utf16ValueStringBuilder.Append("</RangeEstimate>");
						utf16ValueStringBuilder.Append("<DetectionMode>");
						utf16ValueStringBuilder.Append((int)lastDetection.theDetectionMode);
						utf16ValueStringBuilder.Append("</DetectionMode>");
						utf16ValueStringBuilder.Append("<Time>");
						utf16ValueStringBuilder.Append(lastDetection.theTime.ToBinary().ToString());
						utf16ValueStringBuilder.Append("</Time>");
						utf16ValueStringBuilder.Append("</DET>");
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 1002134210938549324589328_1", "");
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				finally
				{
					utf16ValueStringBuilder.Append("</LastDetections>");
				}
			}
			if (SkipZoneChecks)
			{
				utf16ValueStringBuilder.Append("<SZC>True</SZC>");
			}
			if (IsAutoDetection)
			{
				utf16ValueStringBuilder.Append("<ISAD>True</ISAD>");
			}
			if (GameGeneral.Beta_DEFENSIVE_DUE_TO_ILLUMINATION && GeneratedFromGuidanceIlluminationDetection)
			{
				utf16ValueStringBuilder.Append("<GFGID>True</GFGID>");
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 1002134210938549324589328", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		finally
		{
			utf16ValueStringBuilder.Append("</Contact>");
		}
		string result = utf16ValueStringBuilder.ToString();
		utf16ValueStringBuilder.Dispose();
		return result;
	}

	public static Contact FromXML(string theObjectID, ref ConcurrentDictionary<string, ScenarioObject> theDictionary)
	{
		Contact result;
		try
		{
			result = (theDictionary.TryGetValue(theObjectID, out var value) ? ((Contact)value) : null);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100478", "");
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

	public static Contact FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, Contact existingObject = null)
	{
		//IL_055e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0565: Expected O, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_0d06: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d12: Expected O, but got Unknown
		//IL_0c05: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c0f: Expected O, but got Unknown
		//IL_0822: Unknown result type (might be due to invalid IL or missing references)
		//IL_0829: Expected O, but got Unknown
		//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Expected O, but got Unknown
		bool flag;
		Contact contact;
		if (flag = existingObject != null)
		{
			contact = existingObject;
			contact.Reinitialize();
		}
		else
		{
			contact = Instantiate();
		}
		Contact result;
		try
		{
			string innerText = Misc.GetNodeByName(theNode.ChildNodes, "ID").InnerText;
			if (Misc.ContainsChar(innerText, ' '))
			{
				innerText = innerText.Replace(" ", "-");
			}
			Detection_Struct item3 = default(Detection_Struct);
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "Name":
					contact.Name = val.InnerText;
					break;
				case "BDA_Fire":
					contact.BDA_FireLevel = (ActiveUnit_Damage.FireIntensityLevel)Conversions.ToByte(val.InnerText);
					break;
				case "H_Known":
					contact.HeadingIsKnown = true;
					break;
				case "Stance":
					if (flag && contact.dictionary_1 != null)
					{
						contact.dictionary_1.Clear();
					}
					foreach (XmlNode childNode2 in val.ChildNodes)
					{
						XmlNode val2 = childNode2;
						if (Operators.CompareString(val2.Name, "#text", false) == 0)
						{
							if (Versioned.IsNumeric((object)val.InnerText))
							{
								contact.nullable_9 = (Misc.PostureStance)Conversions.ToByte(val.InnerText);
							}
							else
							{
								contact.nullable_9 = (Misc.PostureStance)Enum.Parse(typeof(Misc.PostureStance), val.InnerText, ignoreCase: true);
							}
							continue;
						}
						string key = val2.Name.Split(new char[1] { '_' })[1];
						Misc.PostureStance value = (Misc.PostureStance)Conversions.ToByte(val2.InnerText);
						if (Information.IsNothing((object)contact.dictionary_1))
						{
							contact.dictionary_1 = new Dictionary<string, Misc.PostureStance>();
						}
						contact.dictionary_1.Add(key, value);
					}
					break;
				case "TSD_Visual":
				case "TimeSinceDetection_Visual":
					contact.TimeSinceDetection_Visual = XmlConvert.ToSingle(val.InnerText.Replace(",", "."));
					break;
				case "CAO":
					contact.Altitude_old = XmlConvert.ToSingle(val.InnerText);
					break;
				case "ODU":
				case "OriginalDetectorUnitID":
					contact.OriginalDetectorUnitID = val.InnerText;
					break;
				case "RCTTP":
					contact.RemainingContinousTrackTime_Precise = XmlConvert.ToSingle(val.InnerText);
					break;
				case "LastDetections":
					if (flag)
					{
						contact.LastDetections.Clear();
					}
					foreach (XmlNode childNode3 in val.ChildNodes)
					{
						XmlNode val5 = childNode3;
						try
						{
							object obj2;
							if (val5.SelectSingleNode("DetectorUnitID") != null)
							{
								XmlNode obj = val5.SelectSingleNode("DetectorUnitID");
								if (obj == null)
								{
									obj2 = null;
								}
								else
								{
									obj2 = obj.InnerText;
									if (obj2 != null)
									{
										goto IL_0599;
									}
								}
								obj2 = "";
								goto IL_0599;
							}
							string[] array = val5.InnerText.Split(Conversions.ToCharArrayRankOne("_"));
							item3.DetectorUnitID = WebUtility.HtmlDecode(array[0]);
							item3.DetectingSensorID = WebUtility.HtmlDecode(array[1]);
							item3.RangeEstimate = XmlConvert.ToSingle(array[2]);
							item3.theDetectionMode = (ActiveUnit_Sensory.SpecialDetectionMode)Conversions.ToInteger(array[3]);
							item3.theTime = DateTime.FromBinary(Conversions.ToLong(array[4]));
							goto IL_06c4;
							IL_0646:
							object obj3;
							item3.theTime = DateTime.FromBinary(Conversions.ToLong((string)obj3));
							goto IL_06c4;
							IL_05ea:
							object obj4;
							item3.RangeEstimate = XmlConvert.ToSingle((string)obj4);
							XmlNode obj5 = val5.SelectSingleNode("DetectionMode");
							object obj6;
							if (obj5 != null)
							{
								obj6 = obj5.InnerText;
								if (obj6 != null)
								{
									goto IL_0618;
								}
							}
							else
							{
								obj6 = null;
							}
							obj6 = "0";
							goto IL_0618;
							IL_0618:
							item3.theDetectionMode = (ActiveUnit_Sensory.SpecialDetectionMode)Conversions.ToInteger((string)obj6);
							XmlNode obj7 = val5.SelectSingleNode("Time");
							if (obj7 != null)
							{
								obj3 = obj7.InnerText;
								if (obj3 != null)
								{
									goto IL_0646;
								}
							}
							else
							{
								obj3 = null;
							}
							obj3 = "0";
							goto IL_0646;
							IL_05c1:
							object obj8;
							item3.DetectingSensorID = (string)obj8;
							XmlNode obj9 = val5.SelectSingleNode("RangeEstimate");
							if (obj9 != null)
							{
								obj4 = obj9.InnerText;
								if (obj4 != null)
								{
									goto IL_05ea;
								}
							}
							else
							{
								obj4 = null;
							}
							obj4 = "0";
							goto IL_05ea;
							IL_06c4:
							contact.LastDetections.Enqueue(item3);
							goto end_IL_0565;
							IL_0599:
							item3.DetectorUnitID = (string)obj2;
							XmlNode obj10 = val5.SelectSingleNode("DetectingSensorID");
							if (obj10 == null)
							{
								obj8 = null;
							}
							else
							{
								obj8 = obj10.InnerText;
								if (obj8 != null)
								{
									goto IL_05c1;
								}
							}
							obj8 = "";
							goto IL_05c1;
							end_IL_0565:;
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception ex2 = ex;
							ex2?.Data.Add("Error at 100479_1", "");
							GameGeneral.WriteExceptionsToLog(ex2);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					break;
				case "TimeSinceDetection":
				case "TSD":
					float.TryParse(val.InnerText, out contact.TimeSinceDetection);
					break;
				case "TS_BDA":
					contact.TimeSinceBDA = Conversions.ToInteger(val.InnerText);
					break;
				case "DEm":
				case "DetectedEmissions":
					if (flag)
					{
						contact.DetectedEmissions.Clear();
					}
					foreach (XmlNode childNode4 in val.ChildNodes)
					{
						XmlNode val3 = childNode4;
						int key2 = Conversions.ToInteger(val3.Name.Remove(0, 8));
						if (!contact.DetectedEmissions.ContainsKey(key2))
						{
							TObservableDictionary<int, EmissionContainer> detectedEmissions = contact.DetectedEmissions;
							XmlNode val4;
							string SourceString = (val4 = val3).InnerText;
							EmissionContainer value2 = EmissionContainer.FromString(ref SourceString);
							val4.InnerText = SourceString;
							detectedEmissions.Add(key2, value2);
						}
					}
					break;
				case "SZC":
					contact.SkipZoneChecks = Misc.ParseBool(val.InnerText);
					break;
				case "ID":
					if (!theDictionary.ContainsKey(val.InnerText))
					{
						if (theNode.ChildNodes.Count != 1)
						{
							contact.ObjectID_Set(val.InnerText);
							theDictionary.TryAdd(contact.ObjectID, contact);
							break;
						}
						result = null;
					}
					else
					{
						result = (Contact)theDictionary[val.InnerText];
					}
					goto end_IL_001b;
				case "ActualUnitID":
					contact._ActualUnitID = val.InnerText;
					break;
				case "UnitClass":
					contact.UnitClass = val.InnerText;
					break;
				case "TimeSinceDetection_Radar":
				case "TSD_Radar":
					contact.TimeSinceDetection_Radar = XmlConvert.ToSingle(val.InnerText.Replace(",", "."));
					break;
				case "IDStatus":
					if (!Versioned.IsNumeric((object)val.InnerText))
					{
						contact._IDStatus = (IdentificationStatus)Enum.Parse(typeof(IdentificationStatus), val.InnerText, ignoreCase: true);
					}
					else
					{
						contact._IDStatus = (IdentificationStatus)Conversions.ToShort(val.InnerText);
					}
					break;
				case "RHU":
					if (flag)
					{
						contact.list_2.Clear();
					}
					foreach (XmlNode childNode5 in val.ChildNodes)
					{
						HostedUnitReconRecord item2 = HostedUnitReconRecord.FromXML(childNode5);
						contact.list_2.Add(item2);
					}
					break;
				case "CurrentAltitude":
				case "CA":
					((Module_Unit.Unit)contact).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, XmlConvert.ToSingle(val.InnerText));
					break;
				case "UA":
				case "UncertaintyArea":
					if (flag && contact.UncertaintyArea != null)
					{
						contact.UncertaintyArea = null;
					}
					if (val.ChildNodes.Count <= 0)
					{
						break;
					}
					contact.UncertaintyArea = new List<Geopoint_Struct>();
					foreach (XmlNode childNode6 in val.ChildNodes)
					{
						Geopoint_Struct item = Geopoint_Struct.FromXML(childNode6, theDictionary);
						contact.UncertaintyArea.Add(item);
					}
					break;
				case "Age":
					contact.Age = XmlConvert.ToSingle(val.InnerText);
					break;
				case "Longitude":
				case "Lon":
					((Module_Unit.Unit)contact).set_Longitude((GlobalVariables.BooleanObject)null, XmlConvert.ToDouble(val.InnerText.Replace(",", ".")));
					break;
				case "A_Known":
					contact.AltitudeIsKnown = true;
					break;
				case "BDA_Struct":
					contact.BDA_StructuralIntegrity = (BDA_StructuralIntegrityLevel)Conversions.ToByte(val.InnerText);
					break;
				case "Side":
					contact.string_1 = val.InnerText;
					break;
				case "TimeSinceDetection_SonarPassive":
				case "TSD_SonarPassive":
					contact.TimeSinceDetection_SonarPassive = XmlConvert.ToSingle(val.InnerText.Replace(",", "."));
					break;
				case "BDA_Flood":
					contact.BDA_FloodLevel = (ActiveUnit_Damage.FloodingIntensityLevel)Conversions.ToByte(val.InnerText);
					break;
				case "TS_Recon":
					contact.TimeSinceRecon = Conversions.ToInteger(val.InnerText);
					break;
				case "SIK":
				case "SideIsKnown":
					contact.SideIsKnown = Misc.ParseBool(val.InnerText);
					break;
				case "RCTT":
					contact.RemainingContinousTrackTime = XmlConvert.ToSingle(val.InnerText);
					break;
				case "Message":
					contact.Message = val.InnerText;
					break;
				case "S_Known":
					contact.SpeedIsKnown = true;
					break;
				case "Latitude":
				case "Lat":
					((Module_Unit.Unit)contact).set_Latitude((GlobalVariables.BooleanObject)null, XmlConvert.ToDouble(val.InnerText.Replace(",", ".")));
					break;
				case "TimeSinceDetection_ESM":
				case "TSD_ESM":
					contact.TimeSinceDetection_ESM = XmlConvert.ToSingle(val.InnerText.Replace(",", "."));
					break;
				case "IFO":
					contact.IsFilteredOut = Misc.ParseBool(val.InnerText);
					break;
				case "TSD_SonarActive":
				case "TimeSinceDetection_SonarActive":
					contact.TimeSinceDetection_SonarActive = XmlConvert.ToSingle(val.InnerText.Replace(",", "."));
					break;
				case "AutoIncrement":
				case "AInc":
					contact._AutoIncrement = Conversions.ToInteger(val.InnerText);
					break;
				case "CS":
				case "CurrentSpeed":
					contact.CurrentSpeed = XmlConvert.ToSingle(val.InnerText);
					break;
				case "IPLOTP":
				case "IsPreciselyLocatedOnThisPulse":
					contact.IsPreciselyLocatedOnThisPulse = Misc.ParseBool(val.InnerText);
					break;
				case "InheritsSideStance":
				case "ISS":
					contact.bool_2 = Misc.ParseBool(val.InnerText);
					break;
				case "HeldFor":
					contact.HeldFor = XmlConvert.ToSingle(val.InnerText);
					break;
				case "Type":
					if (!Versioned.IsNumeric((object)val.InnerText))
					{
						contact.Type = (ContactType)Enum.Parse(typeof(ContactType), val.InnerText, ignoreCase: true);
					}
					else
					{
						contact.Type = (ContactType)Conversions.ToByte(val.InnerText);
					}
					break;
				case "TimeSinceDetection_Infrared":
				case "TSD_Infrared":
					contact.TimeSinceDetection_Infrared = XmlConvert.ToSingle(val.InnerText.Replace(",", "."));
					break;
				case "ODS":
				case "OriginalDetectorSide":
					contact._OriginalDetectorSide_Name = val.InnerText;
					break;
				case "ISAD":
					contact.IsAutoDetection = true;
					break;
				case "CH":
				case "CurrentHeading":
					contact.CurrentHeading = XmlConvert.ToSingle(val.InnerText);
					break;
				case "GFGID":
					if (GameGeneral.Beta_DEFENSIVE_DUE_TO_ILLUMINATION)
					{
						contact.GeneratedFromGuidanceIlluminationDetection = true;
					}
					break;
				}
			}
			result = contact;
			end_IL_001b:;
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 100479", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = Instantiate();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal new bool HasMoved()
	{
		if ((Latitude_old == 0.0) & (Longitude_old == 0.0) & (base.Altitude_old == 0f))
		{
			return false;
		}
		if ((Latitude_old != ((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null)) | (Longitude_old != ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null)) | (base.Altitude_old != ((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)))
		{
			return true;
		}
		bool result = default(bool);
		return result;
	}

	public override void PrePulseHousekeeping(float elapsedTime, Scenario theScen)
	{
		base.PrePulseHousekeeping(elapsedTime, theScen);
		if (IsBallisticTarget() && FutureBallisticPath.Length == 0 && PrepareForCachedDLZCheck)
		{
			FutureBallisticPath = BallisticMissile_Kinematics.EstimatedFuturePathOfBallisticTarget(this, theScen);
			PrepareForCachedDLZCheck = false;
		}
		if (theScen.SecondIsChangingOnThisPulse)
		{
			weapon_0 = null;
			_KnownIncomingGuidedWeaponsSideID = "";
			_KnownIncomingGuidedWeaponsCount = 0;
		}
		if (theScen.FifthMinuteIsChangingOnThisPulse)
		{
			RetreivedPostureOnThisPulse = false;
			theScen.WeaponFeedBackMessage.Clear();
		}
	}

	public void PostPulseHousekeeping(float elapsedTime, Side theSide, Scenario theScen, bool IsPrivateContact)
	{
		try
		{
			if (list_3 != null)
			{
				for (int i = list_3.Count - 1; i >= 0; i += -1)
				{
					Geopoint_Struct geopoint_Struct;
					try
					{
						geopoint_Struct = list_3[i];
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
						continue;
					}
					if (geopoint_Struct.Latitude != geopoint_Struct.Latitude || geopoint_Struct.Longitude != geopoint_Struct.Longitude)
					{
						list_3.RemoveAt(i);
					}
				}
			}
			if (ActualUnit != null && ActualUnit.IsFixedFacility && list_3 == null && this.IDStatus < IdentificationStatus.PreciseID)
			{
				this.set_IDStatus(theScen, theSide, (Sensor)null, (float?)null, IsNCTRupdate: false, StatusUpdateIsOnCommsGrid: false, bool_5: false, GenerateMessage: false, IdentificationStatus.PreciseID);
			}
			if (theScen.SecondIsChangingOnThisPulse)
			{
				GrowUncertaintyArea(theScen.ElapsedTimeSinceLastSecondChangeCheck, theSide, theScen, IsPrivateContact);
			}
			if (RemainingContinousTrackTime > 0f && ActualUnit != null)
			{
				Age = 0f;
				if (theSide.Units.Count > 0 && !IsAutoDetection)
				{
					PooledList<ActiveUnit> units = theSide.Units;
					ActiveUnit TheDetectingUnit = units[0];
					Contact myContact = this;
					ActiveUnit_Sensory.UpdateContactData(ref TheDetectingUnit, ref myContact, ActualUnit, ContactIsNew: false);
					units[0] = TheDetectingUnit;
				}
			}
			if (Age == 0f)
			{
				HeldFor += elapsedTime;
			}
			AppearsToBeLoitering = SpeedIsKnown && HeadingIsKnown && ActualUnit != null && ActualUnit.LoiteredThisPulse;
			weapon_0 = null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200641", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void GrowUncertaintyArea(float elapsedTime, Side theSide, Scenario theScen, bool IsPrivateContact)
	{
		if (ActualUnit == null)
		{
			return;
		}
		if (IsAutoDetection && !IsPrivateContact)
		{
			UncertaintyArea = null;
		}
		else if (UncertaintyArea != null)
		{
			UncertaintyArea_TimeToNextGrow = Misc.SubtractSingleToSignificantDigit(UncertaintyArea_TimeToNextGrow, elapsedTime, 1);
			if (UncertaintyArea_TimeToNextGrow <= 0f)
			{
				GrowUncertaintyArea_Clipper(UncertaintyArea_NextGrowElapsedStep, ref theScen);
			}
			if (UncertaintyArea.Count == 0)
			{
				UncertaintyArea = null;
			}
		}
		else if (!IsPreciselyLocatedOnThisPulse & (RemainingContinousTrackTime <= 0f))
		{
			GrowUncertaintyArea_Clipper(1.0, ref theScen);
		}
	}

	public bool PostDeserializationHousekeeping(ref Scenario theScen, ref ConcurrentDictionary<string, ScenarioObject> ObjectsDictionary, ref Side theSide)
	{
		bool result;
		try
		{
			int num;
			if (string.IsNullOrEmpty(_ActualUnitID))
			{
				num = 0;
				goto IL_0147;
			}
			if (!ObjectsDictionary.ContainsKey(_ActualUnitID))
			{
				num = 0;
				goto IL_0147;
			}
			ActualUnit = (ActiveUnit)ObjectsDictionary[_ActualUnitID];
			if (ActualUnit.isUAV)
			{
				Type = ContactType.Air;
				Name = Name.Replace("GuidedWeapon", "UAV");
			}
			Side[] sides_ReadOnly = theScen.Sides_ReadOnly;
			foreach (Side side in sides_ReadOnly)
			{
				if (Operators.CompareString(side.Name, string_1, false) == 0)
				{
					_UnitSide = side;
				}
				if (Operators.CompareString(side.Name, _OriginalDetectorSide_Name, false) == 0)
				{
					OriginalDetectorSide = side;
				}
			}
			Misc.PostureStance value;
			if (!Information.IsNothing((object)nullable_9))
			{
				dictionary_0.Add(theSide, nullable_9.Value);
			}
			else if (!Information.IsNothing((object)dictionary_1) && dictionary_1.TryGetValue(theSide.ObjectID, out value))
			{
				Side key = Side.FromXML_ByObjectID(theSide.ObjectID, ref ObjectsDictionary);
				try
				{
					dictionary_0.Add(key, value);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
			}
			dictionary_1 = null;
			result = true;
			goto end_IL_0001;
			IL_0147:
			result = (byte)num != 0;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200023", ex2.Message);
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

	public static void IncreaseAge(Contact theC, Side theSide, float elapsedTime, Scenario theScen)
	{
		if (theC.ActualUnit != null)
		{
			bool num = theC.ActualUnit.get_IsAutoDetectable(theSide);
			if (!num && !(theC.RemainingContinousTrackTime > 0f))
			{
				theC.Age = Misc.AddSingleToSignificantDigit(theC.Age, elapsedTime, 1);
			}
			if (num)
			{
				theC.TimeSinceBDA = Misc.AddSingleToSignificantDigit(theC.TimeSinceBDA, elapsedTime, 1);
			}
			TObservableDictionary<int, EmissionContainer> detectedEmissions = theC._DetectedEmissions;
			bool? flag = ((detectedEmissions != null) ? new bool?(detectedEmissions.Count == 0) : ((bool?)null));
			if (((!flag) ?? flag) == true)
			{
				theC.TimeSinceESM_Identification = Misc.AddSingleToSignificantDigit(theC.TimeSinceESM_Identification, elapsedTime, 1);
			}
		}
		theC.RemainingContinousTrackTime = Misc.SubtractSingleToSignificantDigit(theC.RemainingContinousTrackTime, elapsedTime, 1);
		theC.RemainingContinousTrackTime_Precise = Misc.SubtractSingleToSignificantDigit(theC.RemainingContinousTrackTime_Precise, elapsedTime, 1);
		theC.TimeSinceDetection = Misc.AddSingleToSignificantDigit(theC.TimeSinceDetection, elapsedTime, 1);
		theC.TimeSinceRecon = Misc.AddSingleToSignificantDigit(theC.TimeSinceRecon, elapsedTime, 1);
		theC.method_1(elapsedTime);
		if (theC.OriginalDetectorSide == null || Operators.CompareString(theC.OriginalDetectorSide.ObjectID, theSide.ObjectID, false) != 0)
		{
			return;
		}
		List<HostedUnitReconRecord> list = theC.Recon_HostedUnits(theC.OriginalDetectorSide);
		foreach (HostedUnitReconRecord item in list)
		{
			item.ReconAge = Misc.AddSingleToSignificantDigit(item.ReconAge, elapsedTime, 1);
		}
	}

	private void method_1(float float_7)
	{
		if (TimeSinceDetection_Radar != -1f)
		{
			TimeSinceDetection_Radar = Misc.AddSingleToSignificantDigit(TimeSinceDetection_Radar, float_7, 1);
		}
		if (TimeSinceDetection_ESM != -1f)
		{
			TimeSinceDetection_ESM = Misc.AddSingleToSignificantDigit(TimeSinceDetection_ESM, float_7, 1);
		}
		if (TimeSinceDetection_Visual != -1f)
		{
			TimeSinceDetection_Visual = Misc.AddSingleToSignificantDigit(TimeSinceDetection_Visual, float_7, 1);
		}
		if (TimeSinceDetection_Infrared != -1f)
		{
			TimeSinceDetection_Infrared = Misc.AddSingleToSignificantDigit(TimeSinceDetection_Infrared, float_7, 1);
		}
		if (TimeSinceDetection_SonarActive != -1f)
		{
			TimeSinceDetection_SonarActive = Misc.AddSingleToSignificantDigit(TimeSinceDetection_SonarActive, float_7, 1);
		}
		if (TimeSinceDetection_SonarPassive != -1f)
		{
			TimeSinceDetection_SonarPassive = Misc.AddSingleToSignificantDigit(TimeSinceDetection_SonarPassive, float_7, 1);
		}
	}

	public static Doctrine._WRA_WeaponTargetType KnowType_TargetType(Contact theTarget)
	{
		if (theTarget._IDStatus >= IdentificationStatus.KnownType)
		{
			if (theTarget.ActualUnit == null)
			{
				return Doctrine._WRA_WeaponTargetType.None;
			}
			ActiveUnit actualUnit = theTarget.ActualUnit;
			if (theTarget.IsGroup)
			{
				theTarget = Instantiate(((Group)actualUnit).GroupLead, 0, forWRA: true);
			}
			Aircraft aircraft;
			int result;
			switch (theTarget.Type)
			{
			case ContactType.Air:
				if (!actualUnit.IsWeapon)
				{
					aircraft = (Aircraft)actualUnit;
					if (aircraft.IsHelicopter && aircraft.Type != Aircraft._AircraftType.UAV && aircraft.Type != Aircraft._AircraftType.UCAV)
					{
						return Doctrine._WRA_WeaponTargetType.Helicopter_Unspecified;
					}
					Aircraft._AircraftType type = aircraft.Type;
					if (type <= Aircraft._AircraftType.CAS)
					{
						if (type <= Aircraft._AircraftType.WildWeasel)
						{
							if ((uint)(type - 2001) <= 1u || (uint)(type - 3001) <= 1u)
							{
								goto IL_0145;
							}
							result = 2000;
						}
						else
						{
							if (type == Aircraft._AircraftType.Bomber)
							{
								if ((double)aircraft.Agility_Nominal >= 2.0)
								{
									return Doctrine._WRA_WeaponTargetType.Aircraft_High_Perf_Bombers;
								}
								if ((double)aircraft.Agility_Nominal >= 1.5)
								{
									return Doctrine._WRA_WeaponTargetType.Aircraft_Medium_Perf_Bombers;
								}
								return Doctrine._WRA_WeaponTargetType.Aircraft_Low_Perf_Bombers;
							}
							if (type == Aircraft._AircraftType.CAS)
							{
								goto IL_0145;
							}
							result = 2000;
						}
						goto IL_0245;
					}
					if (type <= Aircraft._AircraftType.AirborneCP)
					{
						if (type != Aircraft._AircraftType.OECM)
						{
							if ((uint)(type - 4002) > 1u)
							{
								result = 2000;
								goto IL_0245;
							}
							return Doctrine._WRA_WeaponTargetType.Aircraft_AEW;
						}
					}
					else if ((uint)(type - 7003) > 2u)
					{
						if (type != Aircraft._AircraftType.Tanker)
						{
							if ((uint)(type - 8201) > 1u)
							{
								result = 2000;
								goto IL_0245;
							}
							return Aircraft.UAVSizeClassification(aircraft.MaxWeight) switch
							{
								Aircraft.NATO_UAS_ClassificationEnum.Class1_Micro => Doctrine._WRA_WeaponTargetType.Aircraft_Class1_UAS, 
								Aircraft.NATO_UAS_ClassificationEnum.Class1_Mini => Doctrine._WRA_WeaponTargetType.Aircraft_Class1_UAS, 
								Aircraft.NATO_UAS_ClassificationEnum.Class1_Small => Doctrine._WRA_WeaponTargetType.Aircraft_Class1_UAS, 
								Aircraft.NATO_UAS_ClassificationEnum.Class2 => Doctrine._WRA_WeaponTargetType.Aircraft_Class2_UAS, 
								_ => Doctrine._WRA_WeaponTargetType.Aircraft_Unspecified, 
							};
						}
						return Doctrine._WRA_WeaponTargetType.Aircraft_Tanker;
					}
					if ((double)aircraft.Agility_Nominal >= 4.0)
					{
						return Doctrine._WRA_WeaponTargetType.Aircraft_High_Perf_Recon_EW;
					}
					if ((double)aircraft.Agility_Nominal >= 3.0)
					{
						return Doctrine._WRA_WeaponTargetType.Aircraft_Medium_Perf_Recon_EW;
					}
					return Doctrine._WRA_WeaponTargetType.Aircraft_Low_Perf_Recon_EW;
				}
				if (actualUnit.isUAV)
				{
					return Aircraft.UAVSizeClassification(actualUnit.MaxWeight) switch
					{
						Aircraft.NATO_UAS_ClassificationEnum.Class1_Micro => Doctrine._WRA_WeaponTargetType.Aircraft_Class1_UAS, 
						Aircraft.NATO_UAS_ClassificationEnum.Class1_Mini => Doctrine._WRA_WeaponTargetType.Aircraft_Class1_UAS, 
						Aircraft.NATO_UAS_ClassificationEnum.Class1_Small => Doctrine._WRA_WeaponTargetType.Aircraft_Class1_UAS, 
						Aircraft.NATO_UAS_ClassificationEnum.Class2 => Doctrine._WRA_WeaponTargetType.Aircraft_Class2_UAS, 
						_ => Doctrine._WRA_WeaponTargetType.Aircraft_Unspecified, 
					};
				}
				return Doctrine._WRA_WeaponTargetType.Aircraft_Unspecified;
			case ContactType.Missile:
			{
				Weapon weapon = (Weapon)actualUnit;
				if (!weapon.IsBallisticMissile)
				{
					if ((object)weapon.GetType() == typeof(UnguidedRocket))
					{
						return Doctrine._WRA_WeaponTargetType.C_RAM;
					}
					if (theTarget.SpeedIsKnown)
					{
						if (theTarget.CurrentSpeed > 600f)
						{
							int result2;
							if (!theTarget.AltitudeIsKnown)
							{
								result2 = 2203;
							}
							else
							{
								if (((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= 30.48f)
								{
									return Doctrine._WRA_WeaponTargetType.Guided_Weapon_Supersonic_Sea_Skimming;
								}
								result2 = 2203;
							}
							return (Doctrine._WRA_WeaponTargetType)result2;
						}
						if (theTarget.AltitudeIsKnown && ((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= 30.48f)
						{
							return Doctrine._WRA_WeaponTargetType.Guided_Weapon_Subsonic_Sea_Skimming;
						}
						return Doctrine._WRA_WeaponTargetType.Guided_Weapon_Subsonic;
					}
					return Doctrine._WRA_WeaponTargetType.Guided_Weapon_Unspecified;
				}
				return Doctrine._WRA_WeaponTargetType.Guided_Weapon_Ballistic;
			}
			case ContactType.Surface:
				break;
			case ContactType.Submarine:
				if (!((Submarine)actualUnit).IsSurfaced)
				{
					return Doctrine._WRA_WeaponTargetType.Submarine_Unspecified;
				}
				return Doctrine._WRA_WeaponTargetType.Submarine_Surfaced;
			case ContactType.Orbital:
				return Doctrine._WRA_WeaponTargetType.Satellite_Unspecified;
			case ContactType.Torpedo:
				return Doctrine._WRA_WeaponTargetType.Subsurface_Contact_Unknown_Type;
			case ContactType.Decoy_Air:
			case ContactType.Decoy_Surface:
			case ContactType.Decoy_Land:
			case ContactType.Decoy_Sub:
				return Doctrine._WRA_WeaponTargetType.Decoy;
			case ContactType.Sonobuoy:
				return Doctrine._WRA_WeaponTargetType.None;
			case ContactType.Facility_Fixed:
			case ContactType.Facility_Mobile:
			case ContactType.AirBase:
			{
				if (actualUnit.IsMobileGroundUnit)
				{
					switch (((IMobileGroundUnit)actualUnit).MobileUnitCategory)
					{
					case IMobileGroundUnit._MobileUnitCategory.Armor:
						return Doctrine._WRA_WeaponTargetType.Mobile_Target_Hardened_Mobile_Vehicle;
					default:
						return Doctrine._WRA_WeaponTargetType.Mobile_Target_Soft_Mobile_Vehicle;
					case IMobileGroundUnit._MobileUnitCategory.Infantry:
					case IMobileGroundUnit._MobileUnitCategory.Infantry_Old:
						return Doctrine._WRA_WeaponTargetType.Mobile_Target_Soft_Mobile_Personnel;
					}
				}
				Facility facility = ((!actualUnit.IsGroup) ? ((Facility)actualUnit) : ((Facility)((Group)actualUnit).GroupLead));
				switch (facility.Category)
				{
				case Facility._FacilityCategory.Building_Reveted:
					if (facility.Armor_General >= GlobalVariables.ArmorRating.Light)
					{
						return Doctrine._WRA_WeaponTargetType.Land_Structure_Hardened_Building_Reveted;
					}
					return Doctrine._WRA_WeaponTargetType.Land_Structure_Soft_Building_Reveted;
				case Facility._FacilityCategory.Building_Bunker:
					return Doctrine._WRA_WeaponTargetType.Land_Structure_Hardened_Building_Bunker;
				case Facility._FacilityCategory.Structure_Open:
					if (facility.Armor_General >= GlobalVariables.ArmorRating.Light)
					{
						return Doctrine._WRA_WeaponTargetType.Land_Structure_Hardened_Structure_Open;
					}
					return Doctrine._WRA_WeaponTargetType.Land_Structure_Soft_Structure_Open;
				case Facility._FacilityCategory.Structure_Reveted:
					if (facility.Armor_General >= GlobalVariables.ArmorRating.Light)
					{
						return Doctrine._WRA_WeaponTargetType.Land_Structure_Hardened_Structure_Reveted;
					}
					return Doctrine._WRA_WeaponTargetType.Land_Structure_Soft_Structure_Reveted;
				case Facility._FacilityCategory.Building_Underground:
				case Facility._FacilityCategory.SurfaceAndUnderground:
					return Doctrine._WRA_WeaponTargetType.Land_Structure_Hardened_Building_Underground;
				case Facility._FacilityCategory.Runway:
					return Doctrine._WRA_WeaponTargetType.Runway;
				case Facility._FacilityCategory.RunwayGrade_Taxiway:
					return Doctrine._WRA_WeaponTargetType.Runway_Grade_Taxiway;
				case Facility._FacilityCategory.RunwayAccessPoint:
					return Doctrine._WRA_WeaponTargetType.Runway_Access_Point;
				case Facility._FacilityCategory.Building_Surface:
				case Facility._FacilityCategory.Water_Surface:
					if (facility.Armor_General >= GlobalVariables.ArmorRating.Light)
					{
						return Doctrine._WRA_WeaponTargetType.Land_Structure_Hardened_Building_Surface;
					}
					return Doctrine._WRA_WeaponTargetType.Land_Structure_Soft_Building_Surface;
				case Facility._FacilityCategory.Underwater:
					return Doctrine._WRA_WeaponTargetType.Underwater_Structure;
				case Facility._FacilityCategory.Mobile_Personnel:
					return Doctrine._WRA_WeaponTargetType.Mobile_Target_Soft_Mobile_Personnel;
				case Facility._FacilityCategory.Mobile_Vehicle:
					return Doctrine._WRA_WeaponTargetType.Mobile_Target_Hardened_Mobile_Vehicle;
				default:
					if (facility.Armor_General >= GlobalVariables.ArmorRating.Light)
					{
						return Doctrine._WRA_WeaponTargetType.Land_Structure_Hardened_Unspecified;
					}
					return Doctrine._WRA_WeaponTargetType.Land_Structure_Soft_Unspecified;
				case Facility._FacilityCategory.AirBase:
					return Doctrine._WRA_WeaponTargetType.Land_Structure_Hardened_Unspecified;
				case Facility._FacilityCategory.AerostatMooring:
					return Doctrine._WRA_WeaponTargetType.Land_Structure_Soft_Unspecified;
				}
			}
			default:
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new NotImplementedException();
			case ContactType.AggregateGroundUnit:
				{
					switch (((AggregateGroundUnit)actualUnit).MobileUnitCategory)
					{
					case IMobileGroundUnit._MobileUnitCategory.Armor:
						return Doctrine._WRA_WeaponTargetType.Mobile_Target_Hardened_Mobile_Vehicle;
					default:
						return Doctrine._WRA_WeaponTargetType.Mobile_Target_Soft_Mobile_Vehicle;
					case IMobileGroundUnit._MobileUnitCategory.Infantry:
					case IMobileGroundUnit._MobileUnitCategory.Infantry_Old:
						return Doctrine._WRA_WeaponTargetType.Mobile_Target_Soft_Mobile_Personnel;
					}
				}
				IL_0245:
				return (Doctrine._WRA_WeaponTargetType)result;
				IL_0145:
				if ((double)aircraft.Agility_Nominal >= 5.0)
				{
					return Doctrine._WRA_WeaponTargetType.Aircraft_5th_Generation;
				}
				if ((double)aircraft.Agility_Nominal >= 4.0)
				{
					return Doctrine._WRA_WeaponTargetType.Aircraft_4th_Generation;
				}
				if ((double)aircraft.Agility_Nominal >= 3.0)
				{
					return Doctrine._WRA_WeaponTargetType.Aircraft_3rd_Generation;
				}
				return Doctrine._WRA_WeaponTargetType.Aircraft_Less_Capable;
			}
			Ship ship = (Ship)actualUnit;
			int num;
			int result3;
			bool flag;
			PooledDictionary<int, Weapon> pooledDictionary;
			switch (ship.Category)
			{
			default:
				return Doctrine._WRA_WeaponTargetType.Ship_Unspecified;
			case Ship._ShipCategory.Amphibious:
				if (ship.Displacement_Standard >= 95001f)
				{
					return Doctrine._WRA_WeaponTargetType.Ship_Amphibious_95000_tons;
				}
				if (ship.Displacement_Standard >= 45001f)
				{
					return Doctrine._WRA_WeaponTargetType.Ship_Amphibious_45001_95000_tons;
				}
				if (ship.Displacement_Standard >= 25001f)
				{
					return Doctrine._WRA_WeaponTargetType.Ship_Amphibious_25001_45000_tons;
				}
				if (ship.Displacement_Standard >= 10001f)
				{
					return Doctrine._WRA_WeaponTargetType.Ship_Amphibious_10001_25000_tons;
				}
				if (ship.Displacement_Standard >= 5001f)
				{
					return Doctrine._WRA_WeaponTargetType.Ship_Amphibious_5001_10000_tons;
				}
				if (ship.Displacement_Standard >= 1501f)
				{
					return Doctrine._WRA_WeaponTargetType.Ship_Amphibious_1501_5000_tons;
				}
				if (ship.Displacement_Standard >= 501f)
				{
					return Doctrine._WRA_WeaponTargetType.Ship_Amphibious_501_1500_tons;
				}
				if (ship.Displacement_Standard >= 0f)
				{
					return Doctrine._WRA_WeaponTargetType.Ship_Amphibious_0_500_tons;
				}
				break;
			case Ship._ShipCategory.Auxiliary:
				if (ship.Displacement_Standard >= 95001f)
				{
					return Doctrine._WRA_WeaponTargetType.Ship_Auxiliary_95000_tons;
				}
				if (ship.Displacement_Standard >= 45001f)
				{
					return Doctrine._WRA_WeaponTargetType.Ship_Auxiliary_45001_95000_tons;
				}
				if (ship.Displacement_Standard >= 25001f)
				{
					return Doctrine._WRA_WeaponTargetType.Ship_Auxiliary_25001_45000_tons;
				}
				if (ship.Displacement_Standard >= 10001f)
				{
					return Doctrine._WRA_WeaponTargetType.Ship_Auxiliary_10001_25000_tons;
				}
				if (ship.Displacement_Standard >= 5001f)
				{
					return Doctrine._WRA_WeaponTargetType.Ship_Auxiliary_5001_10000_tons;
				}
				if (ship.Displacement_Standard >= 1501f)
				{
					return Doctrine._WRA_WeaponTargetType.Ship_Auxiliary_1501_5000_tons;
				}
				if (ship.Displacement_Standard >= 501f)
				{
					return Doctrine._WRA_WeaponTargetType.Ship_Auxiliary_501_1500_tons;
				}
				if (ship.Displacement_Standard >= 0f)
				{
					return Doctrine._WRA_WeaponTargetType.Ship_Auxiliary_0_500_tons;
				}
				break;
			case Ship._ShipCategory.Merchant:
			case Ship._ShipCategory.Civilian:
				if (ship.Displacement_Standard >= 95001f)
				{
					return Doctrine._WRA_WeaponTargetType.Ship_Merchant_Civilian_95000_tons;
				}
				if (ship.Displacement_Standard >= 45001f)
				{
					return Doctrine._WRA_WeaponTargetType.Ship_Merchant_Civilian_45001_95000_tons;
				}
				if (ship.Displacement_Standard >= 25001f)
				{
					return Doctrine._WRA_WeaponTargetType.Ship_Merchant_Civilian_25001_45000_tons;
				}
				if (ship.Displacement_Standard >= 10001f)
				{
					return Doctrine._WRA_WeaponTargetType.Ship_Merchant_Civilian_10001_25000_tons;
				}
				if (ship.Displacement_Standard >= 5001f)
				{
					return Doctrine._WRA_WeaponTargetType.Ship_Merchant_Civilian_5001_10000_tons;
				}
				if (ship.Displacement_Standard >= 1501f)
				{
					return Doctrine._WRA_WeaponTargetType.Ship_Merchant_Civilian_1501_5000_tons;
				}
				if (ship.Displacement_Standard >= 501f)
				{
					return Doctrine._WRA_WeaponTargetType.Ship_Merchant_Civilian_501_1500_tons;
				}
				if (ship.Displacement_Standard >= 0f)
				{
					return Doctrine._WRA_WeaponTargetType.Ship_Merchant_Civilian_0_500_tons;
				}
				break;
			case Ship._ShipCategory.SurfaceCombatant:
			case Ship._ShipCategory.SurfaceCombatantAviation:
			{
				if (ship.Displacement_Standard >= 95001f)
				{
					return Doctrine._WRA_WeaponTargetType.Ship_Surface_Combatant_95000_tons;
				}
				if (ship.Displacement_Standard >= 45001f)
				{
					return Doctrine._WRA_WeaponTargetType.Ship_Surface_Combatant_45001_95000_tons;
				}
				if (ship.Displacement_Standard >= 25001f)
				{
					return Doctrine._WRA_WeaponTargetType.Ship_Surface_Combatant_25001_45000_tons;
				}
				if (ship.Displacement_Standard >= 10001f)
				{
					return Doctrine._WRA_WeaponTargetType.Ship_Surface_Combatant_10001_25000_tons;
				}
				if (ship.Displacement_Standard >= 5001f)
				{
					return Doctrine._WRA_WeaponTargetType.Ship_Surface_Combatant_5001_10000_tons;
				}
				if (ship.Displacement_Standard >= 1501f)
				{
					return Doctrine._WRA_WeaponTargetType.Ship_Surface_Combatant_1501_5000_tons;
				}
				if (ship.Displacement_Standard >= 501f)
				{
					int result4;
					switch (ship.Type)
					{
					case Ship._ShipType.F:
					case Ship._ShipType.FF:
					case Ship._ShipType.FFG:
					case Ship._ShipType.FFL:
						result4 = 3103;
						break;
					default:
						return Doctrine._WRA_WeaponTargetType.Ship_Surface_Combatant_501_1500_tons;
					case Ship._ShipType.DE:
					case Ship._ShipType.DEG:
					case Ship._ShipType.DER:
						result4 = 3103;
						break;
					}
					return (Doctrine._WRA_WeaponTargetType)result4;
				}
				if (!(ship.Displacement_Standard >= 0f))
				{
					break;
				}
				Ship._ShipType type2 = ship.Type;
				if (type2 <= Ship._ShipType.PGM)
				{
					if (type2 != Ship._ShipType.PCFG && type2 != Ship._ShipType.PGM)
					{
						num = 0;
						goto IL_080e;
					}
				}
				else if (type2 != Ship._ShipType.PHM)
				{
					if (type2 == Ship._ShipType.MTB)
					{
						result3 = 3102;
						goto IL_089a;
					}
					num = 0;
					goto IL_080e;
				}
				result3 = 3102;
				goto IL_089a;
			}
			case Ship._ShipCategory.AviationShip:
			case Ship._ShipCategory.MobileOffshoreBase:
				{
					if (ship.Displacement_Standard >= 95001f)
					{
						return Doctrine._WRA_WeaponTargetType.Ship_Carrier_95000_tons;
					}
					if (ship.Displacement_Standard >= 45001f)
					{
						return Doctrine._WRA_WeaponTargetType.Ship_Carrier_45001_95000_tons;
					}
					if (ship.Displacement_Standard >= 25001f)
					{
						return Doctrine._WRA_WeaponTargetType.Ship_Carrier_25001_45000_tons;
					}
					return Doctrine._WRA_WeaponTargetType.Ship_Carrier_0_25000_tons;
				}
				IL_089a:
				return (Doctrine._WRA_WeaponTargetType)result3;
				IL_080e:
				flag = (byte)num != 0;
				pooledDictionary = ship.Weaponry.AllDistinctWeaponsAboard_Potential(IncludeAviationMags: false);
				foreach (Weapon value in pooledDictionary.Values)
				{
					if (!value.IsMissile)
					{
						continue;
					}
					int num2;
					if (!value.IsASuW_Naval)
					{
						if (!value.IsASuW_Land)
						{
							continue;
						}
						num2 = 1;
					}
					else
					{
						num2 = 1;
					}
					flag = (byte)num2 != 0;
					break;
				}
				pooledDictionary.Dispose();
				if (!flag)
				{
					return Doctrine._WRA_WeaponTargetType.Ship_Surface_Combatant_0_500_tons;
				}
				return Doctrine._WRA_WeaponTargetType.Ship_Surface_Combatant_501_1500_tons;
			}
		}
		Doctrine._WRA_WeaponTargetType result5 = default(Doctrine._WRA_WeaponTargetType);
		return result5;
	}

	public void DetermineNextGrow(ref Scenario theScen)
	{
		if (Age < 60f)
		{
			UncertaintyArea_TimeToNextGrow = GameGeneral.GlobalRNG.Next(5, 16);
		}
		else if (Age < 300f)
		{
			UncertaintyArea_TimeToNextGrow = 60f;
		}
		else if (Age < 7200f)
		{
			UncertaintyArea_TimeToNextGrow = 300f;
		}
		else
		{
			UncertaintyArea_TimeToNextGrow = 3600f;
		}
		if (theScen.TimeCompression_SimSeconds > 0 && UncertaintyArea_TimeToNextGrow < (float)theScen.TimeCompression_SimSeconds)
		{
			UncertaintyArea_TimeToNextGrow = theScen.TimeCompression_SimSeconds;
			if (theScen.TimeCompression_SimSeconds < 5)
			{
				UncertaintyArea_TimeToNextGrow *= GameGeneral.GlobalRNG.Next(2, 6);
			}
		}
		UncertaintyArea_NextGrowElapsedStep = UncertaintyArea_TimeToNextGrow;
	}

	public static Doctrine._WRA_WeaponTargetType WRA_DetermineTargetType(ref Contact theTarget, Weapon theW, ref GlobalVariables.BooleanObject EmitterClassificable)
	{
		Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType;
		switch (theTarget._IDStatus)
		{
		case IdentificationStatus.Unknown:
			return Doctrine._WRA_WeaponTargetType.None;
		default:
			wRA_WeaponTargetType = KnowType_TargetType(theTarget);
			break;
		case IdentificationStatus.KnownDomain:
			wRA_WeaponTargetType = smethod_1(theTarget);
			break;
		}
		if (EmitterClassificable != null && EmitterClassificable != GlobalVariables.ObjectTrue)
		{
			EmitterClassificable = GlobalVariables.ObjectFalse;
			return wRA_WeaponTargetType;
		}
		if (theW != null && theW.DBID != 0 && theW.ValidTargets != null && !theW.ValidTargets.Radar)
		{
			EmitterClassificable = GlobalVariables.ObjectFalse;
			return wRA_WeaponTargetType;
		}
		Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType2 = theTarget.TreatThisAsSurfaceEmitter(wRA_WeaponTargetType);
		if (wRA_WeaponTargetType2 != Doctrine._WRA_WeaponTargetType.Emitter_Unspecified && wRA_WeaponTargetType2 != Doctrine._WRA_WeaponTargetType.Emitter_Radar && wRA_WeaponTargetType2 != Doctrine._WRA_WeaponTargetType.Emitter_Jammer)
		{
			EmitterClassificable = GlobalVariables.ObjectFalse;
		}
		else
		{
			EmitterClassificable = GlobalVariables.ObjectTrue;
		}
		return wRA_WeaponTargetType2;
	}

	private static Doctrine._WRA_WeaponTargetType smethod_1(object object_0)
	{
		if (((Contact_Base)object_0)._IDStatus >= IdentificationStatus.KnownDomain)
		{
			if (((Contact)object_0).ActualUnit == null)
			{
				return Doctrine._WRA_WeaponTargetType.None;
			}
			ActiveUnit actualUnit = ((Contact)object_0).ActualUnit;
			switch (((Contact_Base)object_0).Type)
			{
			case ContactType.Air:
				return Doctrine._WRA_WeaponTargetType.Air_Contact_Unknown_Type;
			case ContactType.Missile:
				if (!actualUnit.IsBallisticMissile)
				{
					if (actualUnit.IsWeapon && ((Weapon)actualUnit).IsReEntryVehicle)
					{
						return Doctrine._WRA_WeaponTargetType.Guided_Weapon_Ballistic;
					}
					if (!((Contact)object_0).SpeedIsKnown)
					{
						return Doctrine._WRA_WeaponTargetType.Guided_Weapon_Unspecified;
					}
					if (((Module_Unit.Unit)object_0).CurrentSpeed > 600f)
					{
						int result;
						if (!((Contact)object_0).AltitudeIsKnown)
						{
							result = 2203;
						}
						else
						{
							if (((Module_Unit.Unit)object_0).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= 30.48f)
							{
								return Doctrine._WRA_WeaponTargetType.Guided_Weapon_Supersonic_Sea_Skimming;
							}
							result = 2203;
						}
						return (Doctrine._WRA_WeaponTargetType)result;
					}
					if (((Contact)object_0).AltitudeIsKnown && ((Module_Unit.Unit)object_0).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= 30.48f)
					{
						return Doctrine._WRA_WeaponTargetType.Guided_Weapon_Subsonic_Sea_Skimming;
					}
					return Doctrine._WRA_WeaponTargetType.Guided_Weapon_Subsonic;
				}
				return Doctrine._WRA_WeaponTargetType.Guided_Weapon_Ballistic;
			case ContactType.Surface:
				return Doctrine._WRA_WeaponTargetType.Surface_Contact_Unknown_Type;
			case ContactType.Submarine:
				if (!((Submarine)actualUnit).IsSurfaced)
				{
					return Doctrine._WRA_WeaponTargetType.Subsurface_Contact_Unknown_Type;
				}
				return Doctrine._WRA_WeaponTargetType.Surface_Contact_Unknown_Type;
			case ContactType.Orbital:
				return Doctrine._WRA_WeaponTargetType.Satellite_Unspecified;
			case ContactType.Facility_Fixed:
			case ContactType.Facility_Mobile:
				return Doctrine._WRA_WeaponTargetType.Land_Contact_Unknown_Type;
			case ContactType.Torpedo:
				return Doctrine._WRA_WeaponTargetType.Subsurface_Contact_Unknown_Type;
			default:
				throw new NotImplementedException();
			case ContactType.Decoy_Air:
			case ContactType.Decoy_Surface:
			case ContactType.Decoy_Land:
			case ContactType.Decoy_Sub:
				return Doctrine._WRA_WeaponTargetType.Decoy;
			case ContactType.Sonobuoy:
				return Doctrine._WRA_WeaponTargetType.None;
			}
		}
		Doctrine._WRA_WeaponTargetType result2 = default(Doctrine._WRA_WeaponTargetType);
		return result2;
	}

	internal List<HostedUnitReconRecord> Recon_HostedUnits(Side ObserverSide)
	{
		if (ActualUnit != null && ObserverSide != null && ActualUnit.IsGroup)
		{
			PooledList<Contact> contacts_List = ObserverSide.Contacts_List;
			Lazy<List<HostedUnitReconRecord>> lazy = new Lazy<List<HostedUnitReconRecord>>();
			if (contacts_List != null && contacts_List.Count > 0)
			{
				int count = contacts_List.Count;
				Contact[] array = contacts_List.InternalArray();
				int num = count - 1;
				for (int i = 0; i <= num; i++)
				{
					try
					{
						Contact contact = array[i];
						if (contact != null && contact.ActualUnit != null && contact.ActualUnit.IsGroupMember() && contact.ActualUnit.get_ParentGroup(UsingMissionPlanner: false) == ActualUnit && contact.Recon_HostedUnits(ObserverSide).Count > 0)
						{
							lazy.Value.AddRange(contact.Recon_HostedUnits(ObserverSide));
						}
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
				}
			}
			return lazy.Value;
		}
		return list_2;
	}

	internal float? MaxPotentialWeaponRange_AnyType(GlobalVariables.ActiveUnitType theUnitType)
	{
		float? result = default(float?);
		switch (theUnitType)
		{
		case GlobalVariables.ActiveUnitType.Ship:
			result = MaxPotentialWeaponRange_ASuW_Naval().GetValueOrDefault();
			break;
		case GlobalVariables.ActiveUnitType.Submarine:
			result = MaxPotentialWeaponRange_ASW().GetValueOrDefault();
			break;
		case GlobalVariables.ActiveUnitType.Facility:
			result = MaxPotentialWeaponRange_ASuW_Land().GetValueOrDefault();
			break;
		case GlobalVariables.ActiveUnitType.Aimpoint:
			result = null;
			break;
		case GlobalVariables.ActiveUnitType.Aircraft:
		case GlobalVariables.ActiveUnitType.Weapon:
			result = MaxPotentialWeaponRange_AAW().GetValueOrDefault();
			break;
		}
		return result;
	}

	internal float? MaxPotentialWeaponRange_AnyType(ContactType theContactType)
	{
		float? result = default(float?);
		switch (theContactType)
		{
		case ContactType.Air:
		case ContactType.Missile:
			result = MaxPotentialWeaponRange_AAW().GetValueOrDefault();
			break;
		case ContactType.Surface:
			result = MaxPotentialWeaponRange_ASuW_Naval().GetValueOrDefault();
			break;
		case ContactType.Submarine:
			result = MaxPotentialWeaponRange_ASW().GetValueOrDefault();
			break;
		case ContactType.Aimpoint:
		case ContactType.ActivationPoint:
			result = null;
			break;
		case ContactType.Facility_Fixed:
		case ContactType.Facility_Mobile:
		case ContactType.AggregateGroundUnit:
			result = MaxPotentialWeaponRange_ASuW_Land().GetValueOrDefault();
			break;
		}
		return result;
	}

	internal float ContactRangeModifier()
	{
		if (!IsBallisticTarget() && !IsOrbitalContact)
		{
			if (ActualUnit.IsAerospaceUnit)
			{
				double num = Physics.ComputeMach(((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), CurrentSpeed);
				return (float)(1.0 + num);
			}
			return 1.5f;
		}
		return 10f;
	}

	public float? MaxPotentialWeaponRange_AAW()
	{
		float? result = default(float?);
		try
		{
			if (_IDStatus < IdentificationStatus.KnownClass)
			{
				result = null;
			}
			else
			{
				if (ActualUnit != null)
				{
					if (!nullable_10.HasValue)
					{
						GlobalVariables.ActiveUnitType unitType = ActualUnit.UnitType;
						PooledList<Weapon> pooledList = default(PooledList<Weapon>);
						if (unitType == GlobalVariables.ActiveUnitType.Aircraft)
						{
							List<int>.Enumerator enumerator = default(List<int>.Enumerator);
							try
							{
								int dBID = ActualUnit.DBID;
								SQLiteConnection sqliteConnection_ = ActualUnit.ParentScen.DBConnection;
								enumerator = DBFunctions.WeaponsCarriedByThisAircraft(dBID, ref sqliteConnection_).GetEnumerator();
								while (enumerator.MoveNext())
								{
									int current = enumerator.Current;
									Weapon weapon = ActualUnit.ParentScen.Cache_GetWeapon(current);
									if (weapon.IsAAWCapable)
									{
										if (pooledList == null)
										{
											pooledList = new PooledList<Weapon>();
										}
										pooledList.Add(weapon);
									}
								}
							}
							finally
							{
								((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
							}
						}
						else
						{
							PooledDictionary<int, Weapon> pooledDictionary = ActualUnit.Weaponry.AllDistinctWeaponsAboard_Potential(IncludeAviationMags: false);
							PooledList<Weapon> pooledList2 = new PooledList<Weapon>(pooledDictionary.Values);
							foreach (Weapon item in pooledList2)
							{
								if (item.IsAAWCapable)
								{
									if (pooledList == null)
									{
										pooledList = new PooledList<Weapon>();
									}
									pooledList.Add(item);
								}
							}
							pooledDictionary.Dispose();
							pooledList2.Dispose();
						}
						if (pooledList != null && pooledList.Count > 0)
						{
							nullable_10 = pooledList.OrderByDescending([SpecialName] (Weapon theW) => theW.MaxAirRange).ElementAtOrDefault(0).MaxAirRange;
							pooledList.Dispose();
						}
						else
						{
							nullable_10 = 0f;
						}
					}
					result = nullable_10;
					return result;
				}
				result = null;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100480", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public float? MaxPotentialWeaponRange_ASuW_Naval()
	{
		float? result = default(float?);
		try
		{
			if (_IDStatus < IdentificationStatus.KnownClass)
			{
				result = null;
			}
			else
			{
				if (ActualUnit != null)
				{
					if (!nullable_11.HasValue)
					{
						List<Weapon> list = new List<Weapon>();
						GlobalVariables.ActiveUnitType unitType = ActualUnit.UnitType;
						if (unitType == GlobalVariables.ActiveUnitType.Aircraft)
						{
							List<int>.Enumerator enumerator = default(List<int>.Enumerator);
							try
							{
								int dBID = ActualUnit.DBID;
								SQLiteConnection sqliteConnection_ = ActualUnit.ParentScen.DBConnection;
								enumerator = DBFunctions.WeaponsCarriedByThisAircraft(dBID, ref sqliteConnection_).GetEnumerator();
								while (enumerator.MoveNext())
								{
									int current = enumerator.Current;
									Weapon weapon = ActualUnit.ParentScen.Cache_GetWeapon(current);
									if (weapon.IsASuW_Naval)
									{
										list.Add(weapon);
									}
								}
							}
							finally
							{
								((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
							}
						}
						else
						{
							PooledDictionary<int, Weapon> pooledDictionary = ActualUnit.Weaponry.AllDistinctWeaponsAboard_Potential(IncludeAviationMags: false);
							list = (from theW in pooledDictionary.Values.ToList()
								where theW.IsASuW_Naval
								select theW).ToList();
							pooledDictionary.Dispose();
						}
						if (list.Count != 0)
						{
							nullable_11 = list.OrderByDescending([SpecialName] (Weapon theW) => theW.MaxSurfaceRange).ElementAtOrDefault(0).MaxSurfaceRange;
						}
						else
						{
							nullable_11 = 0f;
						}
					}
					result = nullable_11;
					return result;
				}
				result = null;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100481", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public float? MaxPotentialWeaponRange_ASuW_Land()
	{
		float? result = default(float?);
		try
		{
			if (_IDStatus < IdentificationStatus.KnownClass)
			{
				result = null;
			}
			else
			{
				if (ActualUnit != null)
				{
					if (!nullable_12.HasValue)
					{
						List<Weapon> list = new List<Weapon>();
						GlobalVariables.ActiveUnitType unitType = ActualUnit.UnitType;
						if (unitType == GlobalVariables.ActiveUnitType.Aircraft)
						{
							List<int>.Enumerator enumerator = default(List<int>.Enumerator);
							try
							{
								int dBID = ActualUnit.DBID;
								SQLiteConnection sqliteConnection_ = ActualUnit.ParentScen.DBConnection;
								enumerator = DBFunctions.WeaponsCarriedByThisAircraft(dBID, ref sqliteConnection_).GetEnumerator();
								while (enumerator.MoveNext())
								{
									int current = enumerator.Current;
									Weapon weapon = ActualUnit.ParentScen.Cache_GetWeapon(current);
									if (weapon.IsASuW_Land)
									{
										list.Add(weapon);
									}
								}
							}
							finally
							{
								((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
							}
						}
						else
						{
							PooledDictionary<int, Weapon> pooledDictionary = ActualUnit.Weaponry.AllDistinctWeaponsAboard_Potential(IncludeAviationMags: false);
							list = (from theW in pooledDictionary.Values.ToList()
								where theW.IsASuW_Land
								select theW).ToList();
							pooledDictionary.Dispose();
						}
						if (list.Count != 0)
						{
							nullable_12 = list.OrderByDescending([SpecialName] (Weapon theW) => theW.MaxLandRange).ElementAtOrDefault(0).MaxLandRange;
						}
						else
						{
							nullable_12 = 0f;
						}
					}
					result = nullable_12;
					return result;
				}
				result = null;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101215", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public float? MaxPotentialWeaponRange_ASW()
	{
		float? result = default(float?);
		try
		{
			if (_IDStatus < IdentificationStatus.KnownClass)
			{
				result = null;
			}
			else
			{
				if (ActualUnit != null)
				{
					if (!nullable_13.HasValue)
					{
						List<Weapon> list = new List<Weapon>();
						GlobalVariables.ActiveUnitType unitType = ActualUnit.UnitType;
						if (unitType == GlobalVariables.ActiveUnitType.Aircraft)
						{
							List<int>.Enumerator enumerator = default(List<int>.Enumerator);
							try
							{
								int dBID = ActualUnit.DBID;
								SQLiteConnection sqliteConnection_ = ActualUnit.ParentScen.DBConnection;
								enumerator = DBFunctions.WeaponsCarriedByThisAircraft(dBID, ref sqliteConnection_).GetEnumerator();
								while (enumerator.MoveNext())
								{
									int current = enumerator.Current;
									Weapon weapon = ActualUnit.ParentScen.Cache_GetWeapon(current);
									if (weapon.IsASW)
									{
										list.Add(weapon);
									}
								}
							}
							finally
							{
								((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
							}
						}
						else
						{
							PooledDictionary<int, Weapon> pooledDictionary = ActualUnit.Weaponry.AllDistinctWeaponsAboard_Potential(IncludeAviationMags: false);
							list = (from theW in pooledDictionary.Values.ToList()
								where theW.IsASW
								select theW).ToList();
							pooledDictionary.Dispose();
						}
						if (list.Count == 0)
						{
							nullable_13 = 0f;
						}
						else
						{
							nullable_13 = list.OrderByDescending([SpecialName] (Weapon theW) => theW.MaxSubsurfaceRange).ElementAtOrDefault(0).MaxSubsurfaceRange;
						}
					}
					result = nullable_13;
					return result;
				}
				result = null;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100482", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public float? MaxPotentialActiveSensorRange_AAW()
	{
		float? result;
		if (ActualUnit == null)
		{
			result = null;
		}
		else
		{
			try
			{
				if (!nullable_14.HasValue || identificationStatus_0 != this.IDStatus)
				{
					identificationStatus_0 = this.IDStatus;
					if (this.IDStatus < IdentificationStatus.KnownClass)
					{
						if (!HasDetectedEmissions)
						{
							nullable_14 = 0f;
						}
						else
						{
							IEnumerable<Sensor> enumerable;
							try
							{
								enumerable = from theKVP in DetectedEmissions
									where theKVP.Value.PreciseID
									select theKVP.Value.get_AssociatedSensor(theKVP.Key, ActualUnit.ParentScen) into theS
									where theS.get_IsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Aircraft) || theS.get_IsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Satellite)
									orderby theS.maxRange descending
									select theS;
							}
							catch (Exception projectError)
							{
								ProjectData.SetProjectError(projectError);
								enumerable = from theKVP in DetectedEmissions
									where theKVP.Value.PreciseID
									select theKVP.Value.get_AssociatedSensor(theKVP.Key, ActualUnit.ParentScen) into theS
									where theS.get_IsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Aircraft) || theS.get_IsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Satellite)
									orderby theS.maxRange descending
									select theS;
								ProjectData.ClearProjectError();
							}
							if (enumerable != null && enumerable.Count() == 0)
							{
								nullable_14 = 0f;
							}
							else
							{
								nullable_14 = enumerable?.FirstOrDefault()?.maxRange;
							}
						}
					}
					else
					{
						ActiveUnit_Sensory sensory = ActualUnit.Sensory;
						Sensor[] theSensorList = null;
						PooledList<Sensor> longestRange_AASensor = sensory.GetLongestRange_AASensor(ActiveCapableSensorsOnly: true, EmmittingSensorsOnly: false, OnlyOperatingSensors: false, OnlySensorsScanningThisPulse: false, ref theSensorList);
						if (longestRange_AASensor != null && longestRange_AASensor.Count > 0)
						{
							nullable_14 = longestRange_AASensor[0].maxRange;
							longestRange_AASensor.Dispose();
						}
						else
						{
							nullable_14 = 0f;
						}
					}
				}
				return nullable_14;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200547", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = 0f;
				ProjectData.ClearProjectError();
			}
		}
		return result;
	}

	public float? MaxPotentialActiveSensorRange_ASuW()
	{
		float? result;
		if (ActualUnit != null)
		{
			try
			{
				if (!nullable_15.HasValue || identificationStatus_1 != this.IDStatus)
				{
					identificationStatus_1 = this.IDStatus;
					if (this.IDStatus >= IdentificationStatus.KnownClass)
					{
						ActiveUnit_Sensory sensory = ActualUnit.Sensory;
						Sensor[] theSensorList = null;
						PooledList<Sensor> longestRange_ASSensor = sensory.GetLongestRange_ASSensor(ActiveCapableSensorsOnly: true, EmmittingSensorsOnly: false, OnlyOperatingSensors: false, OnlySensorsScanningThisPulse: false, ref theSensorList);
						if (longestRange_ASSensor != null && longestRange_ASSensor.Count > 0)
						{
							nullable_15 = longestRange_ASSensor[0].maxRange;
						}
						else
						{
							nullable_15 = 0f;
						}
						longestRange_ASSensor?.Dispose();
					}
					else if (!HasDetectedEmissions)
					{
						nullable_15 = 0f;
					}
					else
					{
						List<Sensor> list;
						try
						{
							list = (from theKVP in DetectedEmissions
								where theKVP.Value.PreciseID
								select theKVP.Value.get_AssociatedSensor(theKVP.Key, ActualUnit.ParentScen) into theS
								where theS.get_IsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Facility) || theS.get_IsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Ship)
								orderby theS.maxRange descending
								select theS).ToList();
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							list = (from theKVP in DetectedEmissions
								where theKVP.Value.PreciseID
								select theKVP.Value.get_AssociatedSensor(theKVP.Key, ActualUnit.ParentScen) into theS
								where theS.get_IsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Facility) || theS.get_IsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Ship)
								orderby theS.maxRange descending
								select theS).ToList();
							ProjectData.ClearProjectError();
						}
						if (list.Count != 0)
						{
							nullable_15 = list[0].maxRange;
						}
						else
						{
							nullable_15 = 0f;
						}
					}
				}
				return nullable_15;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200548", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = 0f;
				ProjectData.ClearProjectError();
			}
		}
		else
		{
			result = null;
		}
		return result;
	}

	public float? MaxPotentialActiveSensorRange_ASW()
	{
		float? result = default(float?);
		if (ActualUnit == null)
		{
			result = null;
		}
		else
		{
			try
			{
				if (!nullable_16.HasValue || identificationStatus_2 != this.IDStatus)
				{
					identificationStatus_2 = this.IDStatus;
					if (this.IDStatus < IdentificationStatus.KnownClass)
					{
						if (!HasDetectedEmissions)
						{
							nullable_16 = 0f;
						}
						else
						{
							IEnumerable<Sensor> source;
							try
							{
								source = from theKVP in DetectedEmissions
									where theKVP.Value.PreciseID
									select theKVP.Value.get_AssociatedSensor(theKVP.Key, ActualUnit.ParentScen) into theS
									where theS.get_IsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Submarine)
									orderby theS.maxRange descending
									select theS;
							}
							catch (Exception projectError)
							{
								ProjectData.SetProjectError(projectError);
								source = from theKVP in DetectedEmissions
									where theKVP.Value.PreciseID
									select theKVP.Value.get_AssociatedSensor(theKVP.Key, ActualUnit.ParentScen) into theS
									where theS.get_IsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Submarine)
									orderby theS.maxRange descending
									select theS;
								ProjectData.ClearProjectError();
							}
							if (source.Count() != 0)
							{
								nullable_16 = source.ElementAtOrDefault(0).maxRange;
							}
							else
							{
								nullable_16 = 0f;
							}
						}
					}
					else
					{
						ActiveUnit_Sensory sensory = ActualUnit.Sensory;
						Sensor[] theSensorList = null;
						PooledList<Sensor> longestRange_ASWSensor = sensory.GetLongestRange_ASWSensor(ActiveCapableSensorsOnly: true, EmmittingSensorsOnly: false, OnlyOperatingSensors: false, OnlySensorsScanningThisPulse: false, ref theSensorList);
						if (longestRange_ASWSensor != null && longestRange_ASWSensor.Count != 0)
						{
							nullable_16 = longestRange_ASWSensor[0].maxRange;
						}
						else
						{
							nullable_16 = 0f;
						}
					}
				}
				result = nullable_16;
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100485", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		return result;
	}

	public string HeadingString()
	{
		if (HeadingIsKnown)
		{
			return Misc.BearingToString(CurrentHeading) + " deg";
		}
		return "XXX";
	}

	public string SpeedString(Game.GamePreferences.SpeedUnitSetting GroundUnitsSpeedUnit, string StringIfUnknown)
	{
		if (!SpeedIsKnown)
		{
			return StringIfUnknown;
		}
		if (Type != ContactType.Facility_Mobile && Type != ContactType.AggregateGroundUnit)
		{
			return Misc.SpeedToEnglishString(CurrentSpeed, 0, Game.GamePreferences.SpeedUnitSetting.Knots);
		}
		return Misc.SpeedToEnglishString(CurrentSpeed, 0, GroundUnitsSpeedUnit);
	}

	public string AltitudeString(bool bool_5)
	{
		if (AltitudeIsKnown)
		{
			if (bool_5)
			{
				if (((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > 45720f)
				{
					return Conversions.ToString(Math.Round(((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) / 1000f, 1)) + " km";
				}
				if (((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > 3048f)
				{
					return Conversions.ToString(Math.Round(((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) * 3.28084f, 0)) + " ft";
				}
				if (IsAir_Missile_Orbital_Contact && Module_Unit.IsOverLand(this))
				{
					return Conversions.ToString(Math.Round(((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) * 3.28084f, 0)) + " ft (" + Conversions.ToString(Math.Round(CurrentAltitude_AGL * 3.28084f, 0)) + " ft AGL)";
				}
				return Conversions.ToString(Math.Round(((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) * 3.28084f, 0)) + " ft";
			}
			if (((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > 45720f)
			{
				return Conversions.ToString(Math.Round(((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) / 1000f, 1)) + " km";
			}
			if (((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > 3048f)
			{
				return Conversions.ToString(Math.Round(((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), 0)) + " m";
			}
			if (IsAir_Missile_Orbital_Contact && Module_Unit.IsOverLand(this))
			{
				return Conversions.ToString(Math.Round(((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), 0)) + " m (" + Conversions.ToString((int)Math.Round(CurrentAltitude_AGL)) + " m AGL)";
			}
			return Conversions.ToString(Math.Round(((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), 0)) + " m";
		}
		return "XXX";
	}

	public bool IsHardTarget()
	{
		if (ActualUnit != null)
		{
			return ActualUnit.IsHardTarget;
		}
		return false;
	}

	public bool IsBallisticTarget()
	{
		bool result = default(bool);
		try
		{
			if (booleanObject_0 != null)
			{
				result = booleanObject_0.ToBoolean();
				return result;
			}
			if (ActualUnit != null)
			{
				if (ActualUnit.IsWeapon)
				{
					if (((Weapon)ActualUnit).IsHGV)
					{
						if (((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > 100000f)
						{
							result = true;
							return result;
						}
						result = false;
						return result;
					}
					if (!((Weapon)ActualUnit).Flags.Warhead_MIRV && !((Weapon)ActualUnit).Flags.Warhead_MRV && !((Weapon)ActualUnit).Flags.Warhead_SingleRV && !ActualUnit.IsBallisticMissile && (!((Weapon)ActualUnit).IsReEntryVehicle || ((Weapon)ActualUnit).IsHGV))
					{
						booleanObject_0 = GlobalVariables.ObjectFalse;
						result = false;
						return result;
					}
					booleanObject_0 = GlobalVariables.ObjectTrue;
					result = true;
					return result;
				}
				booleanObject_0 = GlobalVariables.ObjectFalse;
				result = false;
				return result;
			}
			booleanObject_0 = GlobalVariables.ObjectFalse;
			result = false;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100486", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal Contact GetSideMasterContact(Side theSide)
	{
		Contact result = null;
		if (theSide != null && ActualUnit != null)
		{
			result = theSide.Contacts_List.Find([SpecialName] (Contact x) => x.ActualUnit != null && string.CompareOrdinal(x.ActualUnit.ObjectID, ActualUnit.ObjectID) == 0);
		}
		return result;
	}

	public string GetContactTransmissionGradeDescription(Module_Unit.Unit theSelectedUnit)
	{
		if (theSelectedUnit == null)
		{
			return "";
		}
		if (theSelectedUnit.IsActiveUnit)
		{
			ActiveUnit activeUnit = (ActiveUnit)theSelectedUnit;
			if (activeUnit.CommStuff.ContactsInfoGrade.ContainsKey(ObjectID))
			{
				ActiveUnit_CommStuff.TransmissionContactData transmissionContactData = activeUnit.CommStuff.ContactsInfoGrade[ObjectID];
				if (!transmissionContactData.Equals(null) && !transmissionContactData.IsFrozen && ((transmissionContactData.Bandwith != (CommDevice.EnumCommQuality)2147483647) & (transmissionContactData.Latency != (CommDevice.EnumCommLatency)2147483647) & (transmissionContactData.Bandwith != CommDevice.EnumCommQuality.None) & (transmissionContactData.Latency != CommDevice.EnumCommLatency.None)))
				{
					string descriptionASSlide = CommDevice.QualityGradeDetail.GetDescriptionASSlide((int)transmissionContactData.Bandwith);
					string descriptionASSlide2 = CommDevice.LatencyGradeDetail.GetDescriptionASSlide((int)transmissionContactData.Latency);
					return descriptionASSlide + " " + descriptionASSlide2;
				}
			}
			return "";
		}
		return "";
	}

	private static string smethod_2(ActiveUnit activeUnit_0)
	{
		string result = default(string);
		try
		{
			if (((Contact)(object)activeUnit_0).ActualUnit == null)
			{
				result = "";
				return result;
			}
			if (((Contact)(object)activeUnit_0).ActualUnit.isUAV)
			{
				result = "UAV";
				return result;
			}
			if (!((Contact)(object)activeUnit_0).ActualUnit.isUAV)
			{
				switch (((Contact_Base)(object)activeUnit_0).Type)
				{
				case ContactType.AggregateGroundUnit:
					if (((Contact)(object)activeUnit_0).ActualUnit.IsAggregatedUnit)
					{
						result = Misc.ToEnglishString(((AggregateGroundUnit)((Contact)(object)activeUnit_0).ActualUnit).MobileUnitCategory);
						return result;
					}
					goto default;
				case ContactType.Air:
					if (!((Contact)(object)activeUnit_0).ActualUnit.IsAircraft)
					{
						if (((Contact)(object)activeUnit_0).ActualUnit.IsWeapon)
						{
							if (((Weapon)((Contact)(object)activeUnit_0).ActualUnit).IsDecoy)
							{
								result = "Decoy";
								return result;
							}
							result = "Unknown";
							return result;
						}
						result = "Unknown";
						return result;
					}
					result = ((Aircraft)((Contact)(object)activeUnit_0).ActualUnit).Type.ToString();
					return result;
				case ContactType.Surface:
					result = ((Ship)((Contact)(object)activeUnit_0).ActualUnit).Type.ToString();
					return result;
				case ContactType.Submarine:
					result = ((Submarine)((Contact)(object)activeUnit_0).ActualUnit).Type.ToString();
					return result;
				case ContactType.Facility_Fixed:
					result = ((Facility)((Contact)(object)activeUnit_0).ActualUnit).Category.ToString();
					return result;
				case ContactType.Facility_Mobile:
					if (!((Contact)(object)activeUnit_0).ActualUnit.IsMobileGroundUnit)
					{
						result = Misc.ToEnglishString(((Facility)((Contact)(object)activeUnit_0).ActualUnit).MobileUnitCategory());
						return result;
					}
					result = Misc.ToEnglishString(((IMobileGroundUnit)((Contact)(object)activeUnit_0).ActualUnit).MobileUnitCategory);
					return result;
				case ContactType.Missile:
				case ContactType.Torpedo:
					result = ((Weapon)((Contact)(object)activeUnit_0).ActualUnit).Type.ToString();
					return result;
				default:
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					result = ((Contact)(object)activeUnit_0).ActualUnit.UnitClass;
					return result;
				case ContactType.Decoy_Air:
				case ContactType.Decoy_Surface:
				case ContactType.Decoy_Land:
				case ContactType.Decoy_Sub:
					result = "Decoy";
					return result;
				}
			}
			result = "UAV";
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100492", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static string GeneralClassificationString(Contact theContact)
	{
		switch (theContact.IDStatus)
		{
		case IdentificationStatus.Unknown:
			return "Unknown";
		case IdentificationStatus.KnownDomain:
			return theContact.ContactType_String;
		case IdentificationStatus.KnownType:
			return smethod_2((ActiveUnit)(object)theContact);
		case IdentificationStatus.KnownClass:
		case IdentificationStatus.PreciseID:
			return theContact.ActualUnit.UnitClass;
		default:
		{
			string result = default(string);
			return result;
		}
		}
	}

	public void UpdateContactName(ref Scenario theScen, ref Side theDetectorSide, Sensor SensorThatCausedChange, float? EstimatedDistance, bool IsNCTRupdate, bool bool_5, bool GenerateMessage, string DistanceString, LoggedMessage.MessageType theMessageType, bool bool_6, bool SahreContacts)
	{
		switch (_IDStatus)
		{
		case IdentificationStatus.Unknown:
			if (bool_5)
			{
				sEyLsNsFyty(theScen, this, theDetectorSide, SensorThatCausedChange, string.Empty);
			}
			break;
		case IdentificationStatus.KnownDomain:
			switch (Type)
			{
			case ContactType.AggregateGroundUnit:
				Name = "FORMATION #" + Conversions.ToString(_AutoIncrement);
				break;
			case ContactType.Sonobuoy:
				Name = "SONOBUOY #" + Conversions.ToString(_AutoIncrement);
				break;
			case ContactType.Air:
				Name = "BOGEY #" + Conversions.ToString(_AutoIncrement);
				break;
			case ContactType.Missile:
				if (ActualUnit == null)
				{
					Name = "MISSILE #" + Conversions.ToString(_AutoIncrement);
				}
				else if (!ActualUnit.IsBallisticMissile && (!ActualUnit.IsWeapon || !((Weapon)ActualUnit).IsReEntryVehicle))
				{
					if (ActualUnit.AI.PrimaryTarget == null)
					{
						Name = "MISSILE #" + Conversions.ToString(_AutoIncrement);
						break;
					}
					Contact primaryTarget = ActualUnit.AI.PrimaryTarget;
					if (primaryTarget.IsAir_Missile_Orbital_Contact)
					{
						Weapon weapon = (Weapon)ActualUnit;
						if (weapon.FiringParent != null)
						{
							if (weapon.FiringParent.IsAircraft)
							{
								Name = "MISSILE #" + Conversions.ToString(_AutoIncrement);
							}
							else
							{
								Name = "SAM #" + Conversions.ToString(_AutoIncrement);
							}
						}
						else
						{
							Name = "MISSILE #" + Conversions.ToString(_AutoIncrement);
						}
					}
					else if ((primaryTarget.isSurfaceOrLandContact || primaryTarget.IsSubmergedContact) && !ActualUnit.IsMobileDecoy_Air && !ActualUnit.isUAV)
					{
						Name = "VAMPIRE #" + Conversions.ToString(_AutoIncrement);
					}
					else
					{
						Name = "MISSILE #" + Conversions.ToString(_AutoIncrement);
					}
				}
				else
				{
					Name = "FIREBALL #" + Conversions.ToString(_AutoIncrement);
				}
				break;
			case ContactType.Surface:
				Name = "SKUNK #" + Conversions.ToString(_AutoIncrement);
				break;
			case ContactType.Submarine:
				Name = "GOBLIN #" + Conversions.ToString(_AutoIncrement);
				break;
			default:
				Name = "CONTACT #" + Conversions.ToString(_AutoIncrement);
				break;
			case ContactType.Facility_Fixed:
				if (IsAutoDetection)
				{
					Name = ActualUnit.Name;
					SideIsKnown = true;
				}
				else
				{
					Name = "FIXED #" + Conversions.ToString(_AutoIncrement);
				}
				break;
			case ContactType.Facility_Mobile:
				Name = "MOBILE #" + Conversions.ToString(_AutoIncrement);
				break;
			case ContactType.Torpedo:
				Name = "TORPEDO #" + Conversions.ToString(_AutoIncrement);
				break;
			case ContactType.Mine:
				Name = "MINE #" + Conversions.ToString(_AutoIncrement);
				break;
			}
			if (bool_6 && !Name.StartsWith("[OOC]"))
			{
				Name = "[OOC] " + Name;
			}
			if (bool_5)
			{
				sEyLsNsFyty(theScen, this, theDetectorSide, SensorThatCausedChange, "Designated: " + Name);
			}
			break;
		case IdentificationStatus.KnownType:
		{
			if (SensorThatCausedChange != null && (SensorThatCausedChange.Type == Sensor.Sensor_Type.Visual || SensorThatCausedChange.Type == Sensor.Sensor_Type.Infrared) && Type == ContactType.Air && ActualUnit != null && ActualUnit.IsMobileDecoy_Air)
			{
				Type = ContactType.Decoy_Air;
				if (!GenerateMessage)
				{
					break;
				}
				string text4 = "Contact: " + Name + " has been type-classified as DECOY!";
				string text5 = "";
				if (SensorThatCausedChange != null)
				{
					if (SensorThatCausedChange.ParentPlatform == null)
					{
						text5 = " (Classification by Sensor: " + Misc.RemoveHiddenString(SensorThatCausedChange.Name);
					}
					else
					{
						ActiveUnit parentPlatform2 = SensorThatCausedChange.ParentPlatform;
						string text6 = "";
						int num2;
						if (!parentPlatform2.IsAircraft)
						{
							num2 = 6;
						}
						else if (Operators.CompareString(parentPlatform2.Name, parentPlatform2.UnitClass, false) == 0)
						{
							num2 = 6;
						}
						else
						{
							text6 = " (" + parentPlatform2.UnitClass + ")";
							num2 = 6;
						}
						string[] array2 = new string[num2];
						array2[0] = " (Classification by: ";
						array2[1] = SensorThatCausedChange.ParentPlatform.Name;
						array2[2] = text6;
						array2[3] = " [Sensor: ";
						array2[4] = Misc.RemoveHiddenString(SensorThatCausedChange.Name);
						array2[5] = "]";
						text5 = string.Concat(array2);
					}
					text5 += ")";
				}
				text4 += text5;
				if (bool_6 && !Name.StartsWith("[OOC]"))
				{
					Name = "[OOC] " + Name;
				}
				theScen.AddMessage(text4, Name + " is a DECOY", LoggedMessage.MessageType.ContactChange, 1, null, theDetectorSide, new Geopoint_Struct(((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null)));
				break;
			}
			string name2 = Name;
			string text7 = "Contact: " + Name;
			Name = smethod_2((ActiveUnit)(object)this) + " #" + Conversions.ToString(_AutoIncrement);
			if (GenerateMessage)
			{
				text7 = text7 + " has been type-classified as: " + smethod_2((ActiveUnit)(object)this);
				string text8 = "";
				if (SensorThatCausedChange != null)
				{
					if (SensorThatCausedChange.ParentPlatform != null)
					{
						ActiveUnit parentPlatform3 = SensorThatCausedChange.ParentPlatform;
						string text9 = "";
						int num3;
						if (!parentPlatform3.IsAircraft)
						{
							num3 = 6;
						}
						else if (Operators.CompareString(parentPlatform3.Name, parentPlatform3.UnitClass, false) != 0)
						{
							num3 = 6;
						}
						else
						{
							text9 = " (" + parentPlatform3.UnitClass + ")";
							num3 = 6;
						}
						string[] array3 = new string[num3];
						array3[0] = " (Classification by: ";
						array3[1] = SensorThatCausedChange.ParentPlatform.Name;
						array3[2] = text9;
						array3[3] = " [Sensor: ";
						array3[4] = Misc.RemoveHiddenString(SensorThatCausedChange.Name);
						array3[5] = "]";
						text8 = string.Concat(array3);
					}
					else
					{
						text8 = " (Classification by Sensor: " + Misc.RemoveHiddenString(SensorThatCausedChange.Name);
					}
					if (IsNCTRupdate)
					{
						text8 += " [NCTR mode]";
					}
					text8 = (EstimatedDistance.HasValue ? (text8 + " at " + DistanceString + " nm)") : (text8 + ")"));
				}
				text7 += text8;
				theScen.AddMessage(text7, name2 + " now type-classified: " + smethod_2((ActiveUnit)(object)this), theMessageType, 1, null, theDetectorSide, new Geopoint_Struct(((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null)));
				if (bool_6 && !Name.StartsWith("[OOC]"))
				{
					Name = "[OOC] " + Name;
				}
			}
			ContactType type = Type;
			if (type != ContactType.Submarine)
			{
				break;
			}
			Submarine._SubmarineType type2 = ((Submarine)ActualUnit).Type;
			if ((uint)(type2 - 9001) <= 1u)
			{
				SideIsKnown = true;
				if (ActualUnit != null && ActualUnit.get_UnitSide(SetSideOnly: false) != null && ActualUnit.get_UnitSide(SetSideOnly: false).AssignsCollectiveResponsibility)
				{
					this.set_Stance(theDetectorSide, MarkManually: false, theDetectorSide.get_ConsidersThisSideToBe(ActualUnit.get_UnitSide(SetSideOnly: false), (Scenario)null));
					Contact contact_ = this;
					method_2(ref theScen, ref theDetectorSide, ref contact_);
					RetreivedPostureOnThisPulse = false;
				}
			}
			break;
		}
		case IdentificationStatus.KnownClass:
		{
			SideIsKnown = true;
			if ((ActualUnit != null || ActualUnit.get_UnitSide(SetSideOnly: false) == null) && ActualUnit.get_UnitSide(SetSideOnly: false).AssignsCollectiveResponsibility)
			{
				this.set_Stance(theDetectorSide, MarkManually: false, theDetectorSide.get_ConsidersThisSideToBe(ActualUnit.get_UnitSide(SetSideOnly: false), (Scenario)null));
			}
			string name3 = Name;
			string text10 = "Contact: " + name3;
			Name = Misc.RemoveHiddenString(ActualUnit.UnitClass) + " #" + Conversions.ToString(_AutoIncrement);
			if (GenerateMessage)
			{
				text10 = text10 + " has been classified as: " + Misc.RemoveHiddenString(ActualUnit.UnitClass);
				text10 = text10 + " - Determined as: " + this.get_Stance(theDetectorSide);
				string text11 = "";
				if (SensorThatCausedChange != null)
				{
					if (SensorThatCausedChange.ParentPlatform != null)
					{
						ActiveUnit parentPlatform4 = SensorThatCausedChange.ParentPlatform;
						string text12 = "";
						int num4;
						if (!parentPlatform4.IsAircraft)
						{
							num4 = 6;
						}
						else if (Operators.CompareString(parentPlatform4.Name, parentPlatform4.UnitClass, false) == 0)
						{
							num4 = 6;
						}
						else
						{
							text12 = " (" + parentPlatform4.UnitClass + ")";
							num4 = 6;
						}
						string[] array4 = new string[num4];
						array4[0] = " (Classification by: ";
						array4[1] = SensorThatCausedChange.ParentPlatform.Name;
						array4[2] = text12;
						array4[3] = " [Sensor: ";
						array4[4] = Misc.RemoveHiddenString(SensorThatCausedChange.Name);
						array4[5] = "]";
						text11 = string.Concat(array4);
					}
					else
					{
						text11 = " (Classification by Sensor: " + Misc.RemoveHiddenString(SensorThatCausedChange.Name);
					}
					if (IsNCTRupdate)
					{
						text11 += " [NCTR mode]";
					}
					text11 = (EstimatedDistance.HasValue ? (text11 + " at " + DistanceString + " nm)") : (text11 + ")"));
				}
				text10 += text11;
				theScen.AddMessage(text10, name3 + " now platform-classified: " + Misc.RemoveHiddenString(ActualUnit.UnitClass), theMessageType, 1, null, theDetectorSide, new Geopoint_Struct(((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			if (SensorThatCausedChange == null || SensorThatCausedChange.Type != Sensor.Sensor_Type.Visual || SensorThatCausedChange.Type != Sensor.Sensor_Type.Infrared)
			{
				if (!ActualUnit.IsMobileDecoy_Air && !ActualUnit.isUAV)
				{
					if (ActualUnit.IsMobileDecoy_Surface)
					{
						Type = ContactType.Surface;
					}
					else if (ActualUnit.IsMobileDecoy_Sub)
					{
						Type = ContactType.Submarine;
					}
				}
				else
				{
					Type = ContactType.Air;
				}
			}
			Contact contact_ = this;
			method_2(ref theScen, ref theDetectorSide, ref contact_);
			RetreivedPostureOnThisPulse = false;
			break;
		}
		case IdentificationStatus.PreciseID:
		{
			SideIsKnown = true;
			if (!Information.IsNothing((object)ActualUnit) && !Information.IsNothing((object)ActualUnit.get_UnitSide(SetSideOnly: false)) && ActualUnit.get_UnitSide(SetSideOnly: false).AssignsCollectiveResponsibility)
			{
				this.set_Stance(theDetectorSide, MarkManually: false, theDetectorSide.get_ConsidersThisSideToBe(ActualUnit.get_UnitSide(SetSideOnly: false), (Scenario)null));
			}
			if (string.IsNullOrEmpty(Name) || ActualUnit.get_IsEligibleForAutodetection(theDetectorSide))
			{
				base.Name = ActualUnit.Name;
			}
			if (ActualUnit.get_IsEligibleForAutodetection(theDetectorSide))
			{
				break;
			}
			string name = Name;
			string text = "Contact: " + Name;
			base.Name = ActualUnit.Name;
			if (GenerateMessage)
			{
				text = text + " has been positively identified as: " + Misc.RemoveHiddenString(Name);
				text = text + " - Determined as: " + this.get_Stance(theDetectorSide);
				string text2 = "";
				if (!Information.IsNothing((object)SensorThatCausedChange))
				{
					if (Information.IsNothing((object)SensorThatCausedChange.ParentPlatform))
					{
						text2 = " (ID by Sensor: " + Misc.RemoveHiddenString(SensorThatCausedChange.Name);
					}
					else
					{
						ActiveUnit parentPlatform = SensorThatCausedChange.ParentPlatform;
						string text3 = "";
						int num;
						if (!parentPlatform.IsAircraft)
						{
							num = 6;
						}
						else if (Operators.CompareString(parentPlatform.Name, parentPlatform.UnitClass, false) == 0)
						{
							num = 6;
						}
						else
						{
							text3 = " (" + parentPlatform.UnitClass + ")";
							num = 6;
						}
						string[] array = new string[num];
						array[0] = " (ID by: ";
						array[1] = SensorThatCausedChange.ParentPlatform.Name;
						array[2] = text3;
						array[3] = " [Sensor: ";
						array[4] = Misc.RemoveHiddenString(SensorThatCausedChange.Name);
						array[5] = "]";
						text2 = string.Concat(array);
					}
					text2 = ((!Information.IsNothing((object)EstimatedDistance)) ? (text2 + " at " + DistanceString + " nm)") : (text2 + ")"));
				}
				text += text2;
				if (Type != ContactType.Facility_Fixed && Type != ContactType.Installation && Type != ContactType.AirBase && Type != ContactType.NavalBase && Type != ContactType.MobileGroup)
				{
					theScen.AddMessage(text, name + " now positive ID: " + Misc.RemoveHiddenString(Name), theMessageType, 1, null, theDetectorSide, new Geopoint_Struct(((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				if (bool_6 && !Name.StartsWith("[OOC]"))
				{
					Name = "[OOC] " + Name;
				}
				if (bool_5)
				{
					sEyLsNsFyty(theScen, this, theDetectorSide, SensorThatCausedChange, text);
				}
			}
			if (SahreContacts)
			{
				Contact contact_ = this;
				method_2(ref theScen, ref theDetectorSide, ref contact_);
				RetreivedPostureOnThisPulse = false;
			}
			break;
		}
		}
	}

	public void FullyIdentify(Side theDetectorSide)
	{
		_IDStatus = IdentificationStatus.PreciseID;
		SideIsKnown = true;
		AltitudeIsKnown = true;
		HeadingIsKnown = true;
		SpeedIsKnown = true;
		IsPreciselyLocatedOnThisPulse = true;
		if (UncertaintyArea != null)
		{
			UncertaintyArea = null;
		}
		if (ActualUnit != null)
		{
			((Module_Unit.Unit)this).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, ActualUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
			CurrentHeading = ActualUnit.CurrentHeading;
			CurrentSpeed = ActualUnit.CurrentSpeed;
			((Module_Unit.Unit)this).set_Latitude((GlobalVariables.BooleanObject)null, ActualUnit.get_Latitude((GlobalVariables.BooleanObject)null));
			((Module_Unit.Unit)this).set_Longitude((GlobalVariables.BooleanObject)null, ActualUnit.get_Longitude((GlobalVariables.BooleanObject)null));
			if (ActualUnit.get_UnitSide(SetSideOnly: false) != null)
			{
				this.set_Stance(theDetectorSide, MarkManually: false, theDetectorSide.get_ConsidersThisSideToBe(ActualUnit.get_UnitSide(SetSideOnly: false), (Scenario)null));
			}
			base.Name = ActualUnit.Name;
		}
	}

	private static void sEyLsNsFyty(object object_0, object object_1, Side side_0, Sensor sensor_0, object object_2)
	{
		try
		{
			IEventExporter[] applicableEventExporters = ((Scenario)object_0).ApplicableEventExporters;
			foreach (IEventExporter eventExporter in applicableEventExporters)
			{
				if (eventExporter.IsOperating && eventExporter.ExportEngagementCycle)
				{
					PooledDictionary<string, IEventExporter.EventNotificationParameter> pooledDictionary = new PooledDictionary<string, IEventExporter.EventNotificationParameter>(30, ClearMode.Always);
					if (((Scenario)object_0).MonteCarloIteration > 0)
					{
						pooledDictionary.Add("Scenario", new IEventExporter.EventNotificationParameter(((Scenario)object_0).Title, typeof(string), 500));
						pooledDictionary.Add("MC_Run", new IEventExporter.EventNotificationParameter(((Scenario)object_0).MonteCarloIteration, typeof(int)));
					}
					pooledDictionary.Add("TimelineID", new IEventExporter.EventNotificationParameter(((Scenario)object_0).TimelineID, typeof(string), 40));
					if (!eventExporter.UseZeroHour)
					{
						pooledDictionary.Add("Time", new IEventExporter.EventNotificationParameter(((Scenario)object_0).Time.ToString("MM/dd/yyyy HH:mm:ss") + "." + ((Scenario)object_0).Time.Millisecond.ToString("D3"), typeof(DateTime)));
					}
					else
					{
						pooledDictionary.Add("Time", new IEventExporter.EventNotificationParameter(((Scenario)object_0).Time.Subtract(((Scenario)object_0).ZeroHour).ToString("c"), typeof(TimeSpan), 30));
					}
					ActiveUnit activeUnit = null;
					if (sensor_0 != null && sensor_0.ParentPlatform != null)
					{
						activeUnit = sensor_0.ParentPlatform;
					}
					if (activeUnit == null)
					{
						pooledDictionary.Add("UnitID", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string), 40));
						pooledDictionary.Add("UnitName", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string), 500));
						pooledDictionary.Add("UnitClass", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string), 500));
					}
					else
					{
						pooledDictionary.Add("UnitID", new IEventExporter.EventNotificationParameter(activeUnit.ObjectID, typeof(string), 40));
						pooledDictionary.Add("UnitName", new IEventExporter.EventNotificationParameter(activeUnit.Name, typeof(string), 500));
						pooledDictionary.Add("UnitClass", new IEventExporter.EventNotificationParameter(activeUnit.UnitClass, typeof(string), 500));
					}
					if (side_0 == null)
					{
						pooledDictionary.Add("UnitSide", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string), 500));
					}
					else
					{
						pooledDictionary.Add("UnitSide", new IEventExporter.EventNotificationParameter(side_0.Name, typeof(string), 500));
					}
					pooledDictionary.Add("CycleAction", new IEventExporter.EventNotificationParameter("Contact ID status changed: " + ((Contact)object_1).DescriptionString, typeof(string), 200));
					pooledDictionary.Add("ContactID", new IEventExporter.EventNotificationParameter(((ScenarioObject)object_1).ObjectID, typeof(string), 40));
					pooledDictionary.Add("ContactName", new IEventExporter.EventNotificationParameter(((Contact)object_1).Name, typeof(string), 500));
					pooledDictionary.Add("ContactLongitude", new IEventExporter.EventNotificationParameter(((Module_Unit.Unit)object_1).get_Longitude((GlobalVariables.BooleanObject)null).ToString(), typeof(double)));
					pooledDictionary.Add("ContactLatitude", new IEventExporter.EventNotificationParameter(((Module_Unit.Unit)object_1).get_Latitude((GlobalVariables.BooleanObject)null).ToString(), typeof(double)));
					if (activeUnit == null)
					{
						pooledDictionary.Add("ContactRangeHoriz_nm", new IEventExporter.EventNotificationParameter("", typeof(float)));
						pooledDictionary.Add("ContactRangeSlant_nm", new IEventExporter.EventNotificationParameter("", typeof(float)));
					}
					else
					{
						pooledDictionary.Add("ContactRangeHoriz_nm", new IEventExporter.EventNotificationParameter(activeUnit.RangeToUnit_Horiz((Module_Unit.Unit)object_1), typeof(float)));
						pooledDictionary.Add("ContactRangeSlant_nm", new IEventExporter.EventNotificationParameter(Module_Unit.RangeToUnit_Slant(activeUnit, (Module_Unit.Unit)object_1), typeof(float)));
					}
					if (((Contact)object_1).ActualUnit != null)
					{
						pooledDictionary.Add("ContactActualUnitID", new IEventExporter.EventNotificationParameter(((Contact)object_1).ActualUnit.ObjectID, typeof(string), 40));
						pooledDictionary.Add("ContactActualUnitName", new IEventExporter.EventNotificationParameter(((Contact)object_1).ActualUnit.Name, typeof(string), 500));
						pooledDictionary.Add("ContactActualUnitClass", new IEventExporter.EventNotificationParameter(((Contact)object_1).ActualUnit.UnitClass, typeof(string), 500));
						pooledDictionary.Add("ContactActualUnitSide", new IEventExporter.EventNotificationParameter(((Contact)object_1).ActualUnit.get_UnitSide(SetSideOnly: false).Name, typeof(string), 500));
					}
					pooledDictionary.Add("SalvoID", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string)));
					pooledDictionary.Add("MiscInfo", new IEventExporter.EventNotificationParameter(object_2, typeof(string)));
					eventExporter.ExportEvent(IEventExporter.ExportedEventType.EngagementCycle, pooledDictionary, (Scenario)object_0);
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

	private void method_2(ref Scenario scenario_0, ref Side side_0, ref Contact contact_0)
	{
		HashSet<Side> friendlySidesThisPulse = side_0.FriendlySidesThisPulse;
		Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
		foreach (Side side in sides_ReadOnly)
		{
			if (side != side_0 && friendlySidesThisPulse.Contains(side) && contact_0.ActualUnit != null)
			{
				Contact value = null;
				if (side.Contacts.TryGetValue(contact_0.ActualUnit.ObjectID, out value))
				{
					smethod_3(contact_0, value);
				}
			}
		}
	}

	public static void smethod_3(Contact theContact, Contact theOtherSideContact)
	{
		if (theContact._IDStatus > theOtherSideContact._IDStatus && !ActiveUnit_Sensory.ContactsAreOfSameActualUnit(theOtherSideContact, theContact))
		{
			theOtherSideContact._IDStatus = theContact._IDStatus;
			theOtherSideContact.Name = theContact.Name;
			theOtherSideContact.RetreivedPostureOnThisPulse = false;
		}
	}

	public bool IsDueToExpire()
	{
		int result;
		int num;
		switch (Type)
		{
		default:
			result = 0;
			goto IL_006e;
		case ContactType.AggregateGroundUnit:
			num = ExpirationTimes.AGU;
			break;
		case ContactType.Air:
			num = ExpirationTimes.Air;
			break;
		case ContactType.Missile:
			num = ExpirationTimes.Missile;
			break;
		case ContactType.Surface:
			num = ExpirationTimes.Surface;
			break;
		case ContactType.Submarine:
			num = ExpirationTimes.Submarine;
			break;
		case ContactType.Orbital:
			num = ExpirationTimes.Orbital;
			break;
		case ContactType.UndeterminedNaval:
		case ContactType.Aimpoint:
		case ContactType.Facility_Fixed:
			result = 0;
			goto IL_006e;
		case ContactType.Facility_Mobile:
			num = ExpirationTimes.Mobile;
			break;
		case ContactType.Torpedo:
			{
				num = ExpirationTimes.Torpedo;
				break;
			}
			IL_006e:
			return (byte)result != 0;
		}
		return Age > (float)num;
	}

	private bool method_3()
	{
		int result;
		int result2;
		switch (Type)
		{
		case ContactType.Decoy_Surface:
			result = 1;
			break;
		default:
			if (ActualUnit != null)
			{
				if (!ActualUnit.IsFacility)
				{
					result2 = 0;
					goto IL_004b;
				}
				if (((Facility)ActualUnit).Category == Facility._FacilityCategory.Water_Surface)
				{
					return true;
				}
			}
			result2 = 0;
			goto IL_004b;
		case ContactType.Submarine:
			if (((Submarine)ActualUnit).IsSurfaced)
			{
				return true;
			}
			return false;
		case ContactType.Surface:
			{
				result = 1;
				break;
			}
			IL_004b:
			return (byte)result2 != 0;
		}
		return (byte)result != 0;
	}

	public void UpdateCenter(ActiveUnit ActualUnit)
	{
		if (UncertaintyArea != null && UncertaintyArea.Count != 0)
		{
			List<Geopoint_Struct> list = default(List<Geopoint_Struct>);
			foreach (Geopoint_Struct item in UncertaintyArea)
			{
				if (double.IsNaN(item.Longitude) || double.IsNaN(item.Latitude))
				{
					if (list == null)
					{
						list = new List<Geopoint_Struct>();
					}
					list.Add(item);
				}
			}
			if (list != null)
			{
				foreach (Geopoint_Struct item2 in list)
				{
					UncertaintyArea.Remove(item2);
				}
			}
			Geopoint_Struct geopoint_Struct = Misc.Center(UncertaintyArea);
			((Module_Unit.Unit)this).set_Longitude((GlobalVariables.BooleanObject)null, geopoint_Struct.Longitude);
			((Module_Unit.Unit)this).set_Latitude((GlobalVariables.BooleanObject)null, geopoint_Struct.Latitude);
		}
		else
		{
			((Module_Unit.Unit)this).set_Longitude((GlobalVariables.BooleanObject)null, ActualUnit.get_Longitude(GlobalVariables.ObjectTrue));
			((Module_Unit.Unit)this).set_Latitude((GlobalVariables.BooleanObject)null, ActualUnit.get_Latitude(GlobalVariables.ObjectTrue));
		}
	}

	public bool CurrentCenterIsWithinThisArea(List<GeoPoint> theArea)
	{
		return GeoPoint.IsInsideThisArea(((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), theArea);
	}

	public Contact()
	{
		nullable_9 = null;
		TimeSinceDetection = 0f;
		TimeSinceBDA = 0f;
		TimeSinceRecon = 0f;
		TimeSinceESM_Identification = 0f;
		list_2 = new List<HostedUnitReconRecord>();
		IsAutoDetection = false;
		float_6 = 0f;
		bool_2 = true;
		LastDetections = new Queue<Detection_Struct>();
		lockObject_0 = new LockObject();
		TimeSinceDetection_Radar = -1f;
		TimeSinceDetection_ESM = -1f;
		TimeSinceDetection_Visual = -1f;
		TimeSinceDetection_Infrared = -1f;
		TimeSinceDetection_SonarActive = -1f;
		TimeSinceDetection_SonarPassive = -1f;
		PrepareForCachedDLZCheck = false;
		FutureBallisticPath = new TrajectoryPoint[0];
		AppearsToBeLoitering = false;
		IsFrozenCommsContact = false;
		_KnownIncomingGuidedWeaponsCount = 0;
		_KnownIncomingGuidedWeaponsSideID = "";
		lockObject_1 = new LockObject();
		lockObject_2 = new LockObject();
		GeneratedFromGuidanceIlluminationDetection = false;
		threadLocal_0 = new ThreadLocal<List<IntPoint>>([SpecialName] () => new List<IntPoint>());
		threadLocal_1 = new ThreadLocal<List<List<IntPoint>>>();
		threadLocal_2 = new ThreadLocal<List<List<IntPoint>>>();
		ObjectPoolingSystem.Intantiated_NewObject++;
		dictionary_0 = new Dictionary<Side, Misc.PostureStance>(1);
		method_4();
	}

	public Contact(ActiveUnit DetectedUnit, int AutoIncrement = 0, bool forWRA = false)
	{
		nullable_9 = null;
		TimeSinceDetection = 0f;
		TimeSinceBDA = 0f;
		TimeSinceRecon = 0f;
		TimeSinceESM_Identification = 0f;
		list_2 = new List<HostedUnitReconRecord>();
		IsAutoDetection = false;
		float_6 = 0f;
		bool_2 = true;
		LastDetections = new Queue<Detection_Struct>();
		lockObject_0 = new LockObject();
		TimeSinceDetection_Radar = -1f;
		TimeSinceDetection_ESM = -1f;
		TimeSinceDetection_Visual = -1f;
		TimeSinceDetection_Infrared = -1f;
		TimeSinceDetection_SonarActive = -1f;
		TimeSinceDetection_SonarPassive = -1f;
		PrepareForCachedDLZCheck = false;
		FutureBallisticPath = new TrajectoryPoint[0];
		AppearsToBeLoitering = false;
		IsFrozenCommsContact = false;
		_KnownIncomingGuidedWeaponsCount = 0;
		_KnownIncomingGuidedWeaponsSideID = "";
		lockObject_1 = new LockObject();
		lockObject_2 = new LockObject();
		GeneratedFromGuidanceIlluminationDetection = false;
		threadLocal_0 = new ThreadLocal<List<IntPoint>>([SpecialName] () => new List<IntPoint>());
		threadLocal_1 = new ThreadLocal<List<List<IntPoint>>>();
		threadLocal_2 = new ThreadLocal<List<List<IntPoint>>>();
		ObjectPoolingSystem.Intantiated_NewObject++;
		if (DetectedUnit != null)
		{
			dictionary_0 = new Dictionary<Side, Misc.PostureStance>(DetectedUnit.ParentScen.Sides_ReadOnly.Count());
		}
		else
		{
			dictionary_0 = new Dictionary<Side, Misc.PostureStance>(1);
		}
		method_5(DetectedUnit, AutoIncrement, forWRA);
	}

	public static Contact Instantiate()
	{
		ObjectPoolingSystem.Intantiated++;
		Contact contact = (Contact)ObjectPoolingSystem.GetObject(PoolableObjectType.Contact);
		Contact result;
		if (contact != null)
		{
			try
			{
				contact.method_4();
				contact.ObjectID = IDGenerator.Instance.Next;
				ObjectPoolingSystem.Intantiated_Pool++;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ObjectPoolingSystem.Intantiated_FailedPooling++;
				result = new Contact();
				ProjectData.ClearProjectError();
				goto IL_0082;
			}
			result = contact;
		}
		else
		{
			result = new Contact();
		}
		goto IL_0082;
		IL_0082:
		return result;
	}

	public static Contact Instantiate(ActiveUnit DetectedUnit, int AutoIncrement = 0, bool forWRA = false)
	{
		ObjectPoolingSystem.Intantiated++;
		Contact contact = (Contact)ObjectPoolingSystem.GetObject(PoolableObjectType.Contact);
		Contact result;
		if (contact == null)
		{
			result = new Contact(DetectedUnit, AutoIncrement, forWRA);
		}
		else
		{
			try
			{
				contact.method_5(DetectedUnit, AutoIncrement, forWRA);
				contact.ObjectID = IDGenerator.Instance.Next;
				ObjectPoolingSystem.Intantiated_Pool++;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ObjectPoolingSystem.Intantiated_FailedPooling++;
				result = new Contact(DetectedUnit, AutoIncrement, forWRA);
				ProjectData.ClearProjectError();
				goto IL_008b;
			}
			result = contact;
		}
		goto IL_008b;
		IL_008b:
		return result;
	}

	private void method_4()
	{
		if (ActualUnit == null)
		{
			return;
		}
		Side[] sides_ReadOnly = ActualUnit.ParentScen.Sides_ReadOnly;
		foreach (Side side in sides_ReadOnly)
		{
			if (side != null)
			{
				PooledList<Contact> contacts_List = side.Contacts_List;
				if (contacts_List != null && contacts_List.Contains(this))
				{
					dictionary_0.Add(side, Misc.PostureStance.Unknown);
				}
			}
		}
	}

	private void method_5(ActiveUnit activeUnit_0, int int_1 = 0, bool bool_5 = false)
	{
		SideIsKnown = false;
		_AutoIncrement = int_1;
		if (activeUnit_0 == null)
		{
			return;
		}
		try
		{
			ActualUnit = activeUnit_0;
			_ActualUnitID = activeUnit_0.ObjectID;
			if (!activeUnit_0.IsAircraft)
			{
				if (activeUnit_0.IsWeapon)
				{
					if (activeUnit_0.isUAV)
					{
						Type = ContactType.Air;
					}
					else
					{
						switch (((Weapon)activeUnit_0).Type)
						{
						case Weapon._WeaponType.UAV_Expendable:
							Type = ContactType.Air;
							break;
						case Weapon._WeaponType.Decoy_Vehicle:
							if (activeUnit_0.IsMobileDecoy_Air)
							{
								Type = ContactType.Air;
							}
							else if (!activeUnit_0.IsMobileDecoy_Surface)
							{
								if (activeUnit_0.IsMobileDecoy_Sub)
								{
									Type = ContactType.Submarine;
								}
							}
							else
							{
								Type = ContactType.Surface;
							}
							break;
						case Weapon._WeaponType.Sonobuoy:
							Type = ContactType.Sonobuoy;
							break;
						case Weapon._WeaponType.Torpedo:
							Type = ContactType.Torpedo;
							break;
						default:
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							throw new NotImplementedException();
						case Weapon._WeaponType.GuidedWeapon:
						case Weapon._WeaponType.Rocket:
						case Weapon._WeaponType.BallisticMissile:
						case Weapon._WeaponType.RV:
						case Weapon._WeaponType.HGV:
							Type = ContactType.Missile;
							break;
						}
					}
				}
				else if (activeUnit_0.IsFacility)
				{
					if (!((Platform)activeUnit_0).RepresentsMobileGroundUnit)
					{
						Type = ContactType.Facility_Fixed;
					}
					else
					{
						Type = ContactType.Facility_Mobile;
					}
				}
				else if (activeUnit_0.IsAggregatedUnit)
				{
					Type = ContactType.AggregateGroundUnit;
				}
				else if (!activeUnit_0.IsMobileGroundUnit)
				{
					if (!activeUnit_0.IsShip)
					{
						if (!activeUnit_0.IsSubmarine)
						{
							if (activeUnit_0.IsSatellite)
							{
								Type = ContactType.Orbital;
							}
							else
							{
								if (!activeUnit_0.IsGroup)
								{
									if (Debugger.IsAttached)
									{
										Debugger.Break();
									}
									throw new NotImplementedException();
								}
								if (((Group)ActualUnit).Type == Group.GroupType.AirBase)
								{
									Type = ContactType.AirBase;
								}
								else if (((Group)ActualUnit).Type == Group.GroupType.MobileGroup)
								{
									Type = ContactType.MobileGroup;
								}
								else if (((Group)ActualUnit).Type == Group.GroupType.NavalBase)
								{
									Type = ContactType.NavalBase;
								}
								else
								{
									Type = ContactType.Installation;
								}
							}
						}
						else
						{
							Type = ContactType.Submarine;
						}
					}
					else
					{
						Type = ContactType.Surface;
					}
				}
				else
				{
					Type = ContactType.Facility_Mobile;
				}
			}
			else
			{
				Type = ContactType.Air;
			}
			if (!bool_5)
			{
				if (ActualUnit == null)
				{
					return;
				}
				Side[] sides_ReadOnly = ActualUnit.ParentScen.Sides_ReadOnly;
				foreach (Side side in sides_ReadOnly)
				{
					if (side != null && side.Contacts.ContainsKey(ActualUnit.ObjectID))
					{
						dictionary_0.Add(side, Misc.PostureStance.Unknown);
					}
				}
			}
			else
			{
				((Module_Unit.Unit)this).set_Latitude((GlobalVariables.BooleanObject)null, activeUnit_0.get_Latitude((GlobalVariables.BooleanObject)null));
				((Module_Unit.Unit)this).set_Longitude((GlobalVariables.BooleanObject)null, activeUnit_0.get_Longitude((GlobalVariables.BooleanObject)null));
				((Module_Unit.Unit)this).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, activeUnit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
				TimeSinceDetection = 1.7014117E+38f;
				_IDStatus = IdentificationStatus.KnownType;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	internal float AngleRateFromThisUnitsPOV(Module_Unit.Unit theUnit)
	{
		float result = default(float);
		try
		{
			float distance_NM = CurrentSpeed / 3600f;
			double out_lon = default(double);
			double out_lat = default(double);
			Geodesic_EdWilliams.CalcPoint_Williams(((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, distance_NM, CurrentHeading);
			float num = Math2.CalcAzimuth(theUnit.get_Latitude((GlobalVariables.BooleanObject)null), theUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null));
			float num2 = Math2.CalcAzimuth(theUnit.get_Latitude((GlobalVariables.BooleanObject)null), theUnit.get_Longitude((GlobalVariables.BooleanObject)null), out_lat, out_lon);
			num2 = Math2.NormalizeBearing(num2 - num);
			num = 0f;
			if (num2 > 180f)
			{
				result = 360f - num2;
				return result;
			}
			result = num2;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100496", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void GrowUncertaintyArea_Clipper(double elapsedTime, ref Scenario theScen)
	{
		if (UncertaintyArea == null && Age == 0f)
		{
			return;
		}
		try
		{
			if (UncertaintyArea != null && Misc.CrossesAPole(UncertaintyArea))
			{
				return;
			}
			double num = default(double);
			if (SpeedIsKnown)
			{
				num = CurrentSpeed;
			}
			else
			{
				switch (Type)
				{
				case ContactType.AggregateGroundUnit:
					num = 15.0;
					break;
				case ContactType.Air:
					num = 660.0;
					break;
				case ContactType.Missile:
					num = 1000.0;
					break;
				case ContactType.Surface:
				case ContactType.Submarine:
					num = 20.0;
					break;
				case ContactType.Orbital:
					num = 6000.0;
					break;
				case ContactType.Facility_Mobile:
					num = 20.0;
					break;
				case ContactType.Torpedo:
					num = 45.0;
					break;
				}
			}
			if (num == 0.0)
			{
				return;
			}
			double num2 = num / 3600.0 * elapsedTime;
			double num3 = num2 * 1852.0;
			if (UncertaintyArea == null)
			{
				Geodesic_Vincenty.Point3D[] CirclePoints = new Geodesic_Vincenty.Point3D[46];
				Geodesic_EdWilliams.CircleFromPoint(((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), num2, 45, ref CirclePoints);
				List<Geopoint_Struct> list = new List<Geopoint_Struct>(CirclePoints.Length);
				Geodesic_Vincenty.Point3D[] array = CirclePoints;
				for (int i = 0; i < array.Length; i = checked(i + 1))
				{
					Geodesic_Vincenty.Point3D point3D = array[i];
					list.Add(new Geopoint_Struct(point3D.X, point3D.Y));
				}
				UncertaintyArea = list;
				return;
			}
			if (num3 > 0.0)
			{
				try
				{
					List<IntPoint> value = threadLocal_0.Value;
					value.Clear();
					foreach (Geopoint_Struct item in UncertaintyArea)
					{
						double num4 = item.Latitude;
						double num5 = item.Longitude;
						while (num5 > 180.0 || !(num5 >= -180.0))
						{
							num5 = Math2.NormalizeLongitude(num5);
						}
						if (num4 > 90.0)
						{
							num4 = 90.0;
						}
						if (num4 < -90.0)
						{
							num4 = -90.0;
						}
						MercatorProjection.MercatorPixel mercatorPixel = new MercatorProjection.MercatorPixel(num5, num4);
						Coordinate coordinate = new Coordinate(mercatorPixel.x, mercatorPixel.y);
						value.Add(new IntPoint((long)Math.Round(coordinate[0]), (long)Math.Round(coordinate[1])));
					}
					if (!threadLocal_1.IsValueCreated)
					{
						threadLocal_1.Value = new List<List<IntPoint>>();
					}
					else
					{
						threadLocal_1.Value.Clear();
					}
					List<List<IntPoint>> value2 = threadLocal_1.Value;
					value2.Add(value);
					ClipperOffset clipperOffset = new ClipperOffset();
					clipperOffset.AddPaths(value2, JoinType.jtSquare, EndType.etClosedPolygon);
					if (!threadLocal_2.IsValueCreated)
					{
						threadLocal_2.Value = new List<List<IntPoint>>();
					}
					else
					{
						threadLocal_2.Value.Clear();
					}
					List<List<IntPoint>> solution = threadLocal_2.Value;
					clipperOffset.Execute(ref solution, num3);
					List<List<IntPoint>> list2 = solution;
					List<Geopoint_Struct> list3 = new List<Geopoint_Struct>(list2.Count);
					if (list2.Count == 0)
					{
						return;
					}
					foreach (IntPoint item2 in list2[0])
					{
						try
						{
							MercatorProjection.TCoord tCoord = MercatorProjection.toGeoCoord(item2.X, item2.Y);
							list3.Add(new Geopoint_Struct(tCoord.Lon, tCoord.Lat));
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception ex2 = ex;
							ex2?.Data.Add("Error at 200002", "");
							GameGeneral.WriteExceptionsToLog(ex2);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					if (list3.Count > 100)
					{
						list3 = Math2.SimplifyArea(list3);
					}
					UncertaintyArea = list3;
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					ex4?.Data.Add("Error at 200287", ex4.Message);
					GameGeneral.WriteExceptionsToLog(ex4);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			DetermineNextGrow(ref theScen);
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			ex6?.Data.Add("Error at 100498", "");
			GameGeneral.WriteExceptionsToLog(ex6);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void Teleport(ref Scenario theScen, double Destination_Lon, double Destination_Lat)
	{
		base.Teleport(ref theScen, Destination_Lon, Destination_Lat);
		ActualUnit.Teleport(ref theScen, Destination_Lon, Destination_Lat);
	}

	public Contact Clone()
	{
		Contact contact = (Contact)MemberwiseClone();
		Contact result;
		try
		{
			contact.ObjectID_Set(IDGenerator.Instance.Next, NeedToCheckForSpaces: false);
			TObservableDictionary<int, EmissionContainer> detectedEmissions = _DetectedEmissions;
			if (detectedEmissions != null && detectedEmissions.Count > 0)
			{
				contact._DetectedEmissions = new TObservableDictionary<int, EmissionContainer>();
				foreach (KeyValuePair<int, EmissionContainer> detectedEmission in _DetectedEmissions)
				{
					contact._DetectedEmissions.Add(detectedEmission.Key, detectedEmission.Value);
				}
			}
			if (LastDetections != null && LastDetections.Count > 0)
			{
				contact.LastDetections = new Queue<Detection_Struct>();
			}
			else
			{
				contact.LastDetections = new Queue<Detection_Struct>();
			}
			contact.weapon_0 = null;
			contact.list_2 = new List<HostedUnitReconRecord>();
			if (list_2 != null)
			{
				contact.list_2.AddRange(list_2);
			}
			if (list_3 != null)
			{
				contact.list_3 = new List<Geopoint_Struct>(list_3);
			}
			contact.ListOfESMMatches = new List<int>();
			if (ListOfESMMatches != null)
			{
				contact.ListOfESMMatches.AddRange(ListOfESMMatches);
			}
			contact.dictionary_0 = new Dictionary<Side, Misc.PostureStance>(dictionary_0.Count);
			if (dictionary_0 != null)
			{
				foreach (KeyValuePair<Side, Misc.PostureStance> item in dictionary_0)
				{
					contact.dictionary_0.Add(item.Key, item.Value);
				}
			}
			contact.IsAutoDetection = IsAutoDetection;
			contact.ActualUnit = ActualUnit;
			result = contact;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101418", "");
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

	public void AddDetectionRecord(Detection_Struct theNewRec)
	{
		LastDetections.Enqueue(theNewRec);
		while (LastDetections.Count > 50)
		{
			LastDetections.Dequeue();
		}
	}

	internal Doctrine._WRA_WeaponTargetType TreatThisAsSurfaceEmitter(Doctrine._WRA_WeaponTargetType theTargetType)
	{
		bool flag = false;
		bool flag2 = false;
		if (ActualUnit != null)
		{
			if (ActualUnit.get_UnitSide(SetSideOnly: false) != null && Operators.CompareString(ActualUnit.get_UnitSide(SetSideOnly: false).ObjectID, ActualUnit.ParentScen.GetCurrentSide().ObjectID, false) == 0)
			{
				if (ActualUnit.CouldHaveEmittingRadars)
				{
					flag = true;
				}
				if (ActualUnit.CouldHaveEmittingJammers)
				{
					flag2 = true;
				}
			}
			else
			{
				if (ActualUnit.HasEmittingRadars)
				{
					flag = true;
				}
				if (ActualUnit.HasEmittingJammers)
				{
					flag2 = true;
				}
			}
			if (!ActualUnit.IsFacility && !ActualUnit.IsMobileGroundUnit && !ActualUnit.IsShip)
			{
				return theTargetType;
			}
			if (flag && flag2)
			{
				return Doctrine._WRA_WeaponTargetType.Emitter_Unspecified;
			}
			if (flag && !flag2)
			{
				return Doctrine._WRA_WeaponTargetType.Emitter_Radar;
			}
			if (flag2)
			{
				return Doctrine._WRA_WeaponTargetType.Emitter_Jammer;
			}
			return theTargetType;
		}
		return theTargetType;
	}

	~Contact()
	{
		try
		{
			if (!ObjectPoolingSystem.ReturnObject(this))
			{
				base.Finalize();
			}
			else
			{
				GC.ReRegisterForFinalize(this);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			base.Finalize();
			ProjectData.ClearProjectError();
		}
	}

	internal Misc.PostureStance SetStance(Side observerSide, Misc.PostureStance theStance)
	{
		if (!dictionary_0.ContainsKey(observerSide))
		{
			dictionary_0.Add(observerSide, theStance);
		}
		else
		{
			dictionary_0[observerSide] = theStance;
		}
		return theStance;
	}

	internal float GetTotalSecondsContactHasBeenOrphaned(DateTime CurrentTime)
	{
		float num = float.MaxValue;
		if (LastDetections.Count > 0)
		{
			Detection_Struct detection_Struct = LastDetections.Last();
			num = (float)(CurrentTime - detection_Struct.theTime).TotalSeconds;
			if (detection_Struct.DetectingSensor != null && detection_Struct.DetectingSensor.CanBeActive && detection_Struct.DetectingSensor.IsActive())
			{
				num -= (float)detection_Struct.DetectingSensor.ScanInterval;
			}
			num -= Age;
			if (num < 0f)
			{
				num = 0f;
			}
		}
		return num;
	}

	private void method_6(object sender, NotifyCollectionChangedEventArgs e)
	{
		ListOfESMMatches = null;
	}

	static Contact()
	{
		Class72.smethod_20();
	}
}
