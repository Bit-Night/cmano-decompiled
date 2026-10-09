using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading;
using System.Xml;
using Collections.Pooled;
using Command_Core.DAL;
using ConcurrentObservableCollections.ConcurrentObservableDictionary;
using Cysharp.Text;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ServiceStack.Text;

namespace Command_Core;

public sealed class UnguidedWeapon : Module_Unit.Unit
{
	[CompilerGenerated]
	internal sealed class _Closure$__96-0
	{
		public WeaponSalvo $VB$Local_ParentWS;

		public UnguidedWeapon $VB$Me;

		public _Closure$__96-0(_Closure$__96-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_ParentWS = arg0.$VB$Local_ParentWS;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(UnguidedWeapon theUW)
		{
			if (Operators.CompareString(theUW.FiringParent_ID, $VB$Me.FiringParent_ID, false) != 0)
			{
				return false;
			}
			return $VB$Local_ParentWS.WeaponList.ContainsKey(theUW.ObjectID);
		}

		static _Closure$__96-0()
		{
			Class72.smethod_20();
		}
	}

	private int int_1;

	private Weapon weapon_0;

	private Weapon._WeaponType _WeaponType_0;

	public float CEP_Surface;

	public float CEP_Land;

	public float CruiseAltitude_AGL;

	public float CruiseAltitude_ASL;

	public float AirPOK;

	public float SurfPOK;

	public float LandPOK;

	public float SubPOK;

	public float MaxAirRange;

	public float MinAirRange;

	public float MaxSurfaceRange;

	public float MinSurfaceRange;

	public float MaxLandRange;

	public float MinLandRange;

	public float MaxSubsurfaceRange;

	public float MinSubsurfaceRange;

	public float MinLaunchAlt_AGL;

	public float MaxLaunchAlt_AGL;

	public float MinTargetAlt_AGL;

	public float MaxTargetAlt_AGL;

	public float MinLaunchAlt_ASL;

	public float MaxLaunchAlt_ASL;

	public float MinTargetAlt_ASL;

	public float MaxTargetAlt_ASL;

	public Warhead[] Warheads;

	public Weapon.WeaponFlags Flags;

	public Contact Target;

	private float float_6;

	private GeoPoint geoPoint_0;

	private float float_7;

	private ActiveUnit activeUnit_0;

	public string FiringParent_ID;

	internal int DirectorDBID;

	public string FiringWeaponRec_ID;

	private float float_8;

	internal ActiveUnit Mine_Targeted;

	public string Mine_Targeted_ID;

	private bool? nullable_9;

	private bool bool_0;

	public GeoPoint LaunchPoint
	{
		get
		{
			return geoPoint_0;
		}
		set
		{
			geoPoint_0 = value;
		}
	}

	public override string AnnexAndDBID => "Weapon_" + Conversions.ToString(ReferenceWeapon.DBID);

	public ActiveUnit FiringParent
	{
		get
		{
			if (activeUnit_0 != null)
			{
				if (activeUnit_0.IsMorituri)
				{
					return null;
				}
				return activeUnit_0;
			}
			return null;
		}
		set
		{
			activeUnit_0 = value;
		}
	}

	public Weapon ReferenceWeapon => weapon_0;

	public override Side UnitSide
	{
		get
		{
			return _UnitSide;
		}
		set
		{
			_UnitSide = value;
			if (weapon_0 != null)
			{
				((ActiveUnit)weapon_0).set_UnitSide(SetSideOnly: false, _UnitSide);
			}
		}
	}

	public float TimeToDetonate
	{
		get
		{
			return float_7;
		}
		set
		{
			float_7 = value;
		}
	}

	public Weapon._WeaponType Type
	{
		get
		{
			return _WeaponType_0;
		}
		set
		{
			_WeaponType_0 = value;
		}
	}

	public bool IsUnderwaterWeapon
	{
		get
		{
			if (!IsMine)
			{
				if (Type == Weapon._WeaponType.DepthCharge)
				{
					return true;
				}
				return false;
			}
			return true;
		}
	}

	public bool IsMine
	{
		get
		{
			Weapon._WeaponType type = Type;
			if ((uint)(type - 4004) <= 7u)
			{
				return true;
			}
			return false;
		}
	}

	public WeaponSalvo ParentSalvo
	{
		get
		{
			Side[] sides_ReadOnly = theScen.Sides_ReadOnly;
			foreach (Side side in sides_ReadOnly)
			{
				foreach (WeaponSalvo weaponSalvo in side.WeaponSalvos)
				{
					if (weaponSalvo.WeaponList.ContainsKey(ObjectID))
					{
						return weaponSalvo;
					}
				}
			}
			return null;
		}
	}

	public WeaponSalvo.Shooter ParentSalvoShooter
	{
		get
		{
			if (activeUnit_0 != null)
			{
				Side[] sides_ReadOnly = theScen.Sides_ReadOnly;
				foreach (Side side in sides_ReadOnly)
				{
					if (side.WeaponSalvos == null)
					{
						continue;
					}
					foreach (WeaponSalvo weaponSalvo in side.WeaponSalvos)
					{
						if (!weaponSalvo.WeaponList.ContainsKey(ObjectID) || weaponSalvo.ShootersList == null)
						{
							continue;
						}
						WeaponSalvo.Shooter[] shootersList = weaponSalvo.ShootersList;
						foreach (WeaponSalvo.Shooter shooter in shootersList)
						{
							if (shooter != null && Operators.CompareString(shooter.ShooterObjectID, activeUnit_0.ObjectID, false) == 0)
							{
								return shooter;
							}
						}
					}
				}
			}
			return null;
		}
	}

	public float OptimumBurstHeight
	{
		get
		{
			if (Warheads.Length != 0)
			{
				if (Warheads[0].IsCluster)
				{
					return 800f;
				}
				return 0f;
			}
			return 0f;
		}
	}

	public double MaxRangeForThisTargetType
	{
		get
		{
			if (theTarget.IsAerospaceUnit)
			{
				return MaxAirRange;
			}
			if (!theTarget.IsShip && !theTarget.IsFacility)
			{
				if (!theTarget.IsSubmarine && !theTarget.IsTorpedo)
				{
					throw new NotImplementedException();
				}
				return MaxSubsurfaceRange;
			}
			return MaxSurfaceRange;
		}
	}

	public new string ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
		Utf16ValueStringBuilder utf16ValueStringBuilder = ZString.CreateStringBuilder();
		try
		{
			utf16ValueStringBuilder.Append("<UnguidedWeapon>");
			utf16ValueStringBuilder.Append("<ID>");
			utf16ValueStringBuilder.Append(ObjectID);
			utf16ValueStringBuilder.Append("</ID>");
			if (ObjectsAlreadySerialized.Contains(ObjectID))
			{
				utf16ValueStringBuilder.Append("</UnguidedWeapon>");
				return utf16ValueStringBuilder.ToString();
			}
			ObjectsAlreadySerialized.Add(ObjectID);
			utf16ValueStringBuilder.Append("<DBID>");
			utf16ValueStringBuilder.Append(int_1.ToString());
			utf16ValueStringBuilder.Append("</DBID>");
			utf16ValueStringBuilder.Append("<Name>");
			utf16ValueStringBuilder.Append(SecurityElement.Escape(Name));
			utf16ValueStringBuilder.Append("</Name>");
			if (CurrentHeading != 0f)
			{
				utf16ValueStringBuilder.Append("<CurrentHeading>");
				utf16ValueStringBuilder.Append(XmlConvert.ToString(CurrentHeading));
				utf16ValueStringBuilder.Append("</CurrentHeading>");
			}
			if (CurrentSpeed != 0f)
			{
				utf16ValueStringBuilder.Append("<CurrentSpeed>");
				utf16ValueStringBuilder.Append(XmlConvert.ToString(CurrentSpeed));
				utf16ValueStringBuilder.Append("</CurrentSpeed>");
			}
			if (((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) != 0f)
			{
				utf16ValueStringBuilder.Append("<CurrentAltitude>");
				utf16ValueStringBuilder.Append(XmlConvert.ToString(((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)));
				utf16ValueStringBuilder.Append("</CurrentAltitude>");
			}
			if (ImpactAltitude != 0f)
			{
				utf16ValueStringBuilder.Append("<ImpactAltitude>");
				utf16ValueStringBuilder.Append(XmlConvert.ToString(ImpactAltitude));
				utf16ValueStringBuilder.Append("</ImpactAltitude>");
			}
			utf16ValueStringBuilder.Append("<Longitude>");
			utf16ValueStringBuilder.Append(XmlConvert.ToString(((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null)));
			utf16ValueStringBuilder.Append("</Longitude>");
			utf16ValueStringBuilder.Append("<Latitude>");
			utf16ValueStringBuilder.Append(XmlConvert.ToString(((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null)));
			utf16ValueStringBuilder.Append("</Latitude>");
			if (this.get_UnitSide(SetSideOnly: false) != null)
			{
				utf16ValueStringBuilder.Append("<Side>");
				utf16ValueStringBuilder.Append(SecurityElement.Escape(this.get_UnitSide(SetSideOnly: false).Name));
				utf16ValueStringBuilder.Append("</Side>");
			}
			if (CEP_Surface != 0f)
			{
				utf16ValueStringBuilder.Append("<CEP_Surface>");
				utf16ValueStringBuilder.Append(XmlConvert.ToString(CEP_Surface));
				utf16ValueStringBuilder.Append("</CEP_Surface>");
			}
			if (CEP_Land != 0f)
			{
				utf16ValueStringBuilder.Append("<CEP_Land>");
				utf16ValueStringBuilder.Append(XmlConvert.ToString(CEP_Land));
				utf16ValueStringBuilder.Append("</CEP_Land>");
			}
			if (Target != null)
			{
				utf16ValueStringBuilder.Append("<Target>");
				utf16ValueStringBuilder.Append(Target.ObjectID);
				utf16ValueStringBuilder.Append("</Target>");
			}
			if (float_6 != 0f)
			{
				utf16ValueStringBuilder.Append("<TimeToLive>");
				utf16ValueStringBuilder.Append(XmlConvert.ToString(float_6));
				utf16ValueStringBuilder.Append("</TimeToLive>");
			}
			if (LaunchPoint != null)
			{
				utf16ValueStringBuilder.Append("<LaunchPoint>");
				utf16ValueStringBuilder.Append(LaunchPoint.ToXML(ObjectsAlreadySerialized));
				utf16ValueStringBuilder.Append("</LaunchPoint>");
			}
			if (float_7 != 0f)
			{
				utf16ValueStringBuilder.Append("<TimeToDetonate>");
				utf16ValueStringBuilder.Append(XmlConvert.ToString(float_7));
				utf16ValueStringBuilder.Append("</TimeToDetonate>");
			}
			if (FiringParent != null)
			{
				utf16ValueStringBuilder.Append("<FiringParent>");
				utf16ValueStringBuilder.Append(FiringParent.ObjectID);
				utf16ValueStringBuilder.Append("</FiringParent>");
			}
			if (DirectorDBID != 0)
			{
				utf16ValueStringBuilder.Append("<DirectorDBID>");
				utf16ValueStringBuilder.Append(DirectorDBID);
				utf16ValueStringBuilder.Append("</DirectorDBID>");
			}
			if (!string.IsNullOrEmpty(FiringWeaponRec_ID))
			{
				utf16ValueStringBuilder.Append("<FiringWR>");
				utf16ValueStringBuilder.Append(FiringWeaponRec_ID);
				utf16ValueStringBuilder.Append("</FiringWR>");
			}
			if (Mine_Targeted != null)
			{
				utf16ValueStringBuilder.Append("<MineTargeted>");
				utf16ValueStringBuilder.Append(Mine_Targeted.ObjectID);
				utf16ValueStringBuilder.Append("</MineTargeted>");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100852", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		finally
		{
			utf16ValueStringBuilder.Append("</UnguidedWeapon>");
		}
		string result = utf16ValueStringBuilder.ToString();
		utf16ValueStringBuilder.Dispose();
		return result;
	}

	public static bool IsBurst(string theName)
	{
		return theName.ToLower().Contains("burst");
	}

	public static bool IsSalvo(string theName)
	{
		return theName.ToLower().Contains("salvo");
	}

	internal bool IsAerospaceWeapon()
	{
		Weapon._WeaponType type = Type;
		int result;
		int result2;
		if (type > Weapon._WeaponType.TrainingRound)
		{
			if (type == Weapon._WeaponType.PalletWeapon)
			{
				goto IL_0040;
			}
			if ((uint)(type - 6001) > 1u)
			{
				result = 0;
				goto IL_003d;
			}
			result2 = 1;
		}
		else
		{
			if ((uint)(type - 2002) > 2u)
			{
				if (type != Weapon._WeaponType.TrainingRound)
				{
					result = 0;
					goto IL_003d;
				}
				goto IL_0040;
			}
			result2 = 1;
		}
		goto IL_0041;
		IL_003d:
		return (byte)result != 0;
		IL_0040:
		result2 = 1;
		goto IL_0041;
		IL_0041:
		return (byte)result2 != 0;
	}

	public void PostDeserializationHousekeeping(ref Scenario theScen)
	{
		try
		{
			if (FiringParent_ID != null)
			{
				theScen.ActiveUnits.TryGetValue(FiringParent_ID, out activeUnit_0);
			}
			if (Mine_Targeted_ID != null)
			{
				theScen.ActiveUnits.TryGetValue(Mine_Targeted_ID, out Mine_Targeted);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101295", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static UnguidedWeapon FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref Scenario theScen)
	{
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		UnguidedWeapon result;
		try
		{
			int num = ((Misc.GetNodeByName(theNode.ChildNodes, "DBID") == null) ? DBFunctions.GetActiveUnitIDByName(Misc.GetNodeByName(theNode.ChildNodes, "Name").InnerText, GlobalVariables.ActiveUnitType.Weapon, theScen.DBConnection) : Conversions.ToInteger(Misc.GetNodeByName(theNode.ChildNodes, "DBID").InnerText));
			Weapon theReferenceWeapon = theScen.Cache_GetWeapon(num);
			UnguidedWeapon unguidedWeapon = new UnguidedWeapon(theReferenceWeapon, null, null, 0.0, 0.0);
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "CurrentAltitude":
					((Module_Unit.Unit)unguidedWeapon).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, XmlConvert.ToSingle(val.InnerText));
					break;
				case "Name":
					unguidedWeapon.Name = val.InnerText;
					break;
				case "ID":
					if (!theDictionary.ContainsKey(val.InnerText))
					{
						unguidedWeapon.ObjectID_Set(val.InnerText);
						theDictionary.TryAdd(unguidedWeapon.ObjectID, unguidedWeapon);
						break;
					}
					result = (UnguidedWeapon)theDictionary[val.InnerText];
					goto end_IL_0001;
				case "DirectorDBID":
					unguidedWeapon.DirectorDBID = Conversions.ToInteger(val.InnerText);
					break;
				case "Latitude":
					((Module_Unit.Unit)unguidedWeapon).set_Latitude((GlobalVariables.BooleanObject)null, (double)XmlConvert.ToSingle(val.InnerText));
					break;
				case "Longitude":
					((Module_Unit.Unit)unguidedWeapon).set_Longitude((GlobalVariables.BooleanObject)null, (double)XmlConvert.ToSingle(val.InnerText));
					break;
				case "LaunchPoint":
				{
					XmlNode theNode2 = val.ChildNodes[0];
					unguidedWeapon.geoPoint_0 = GeoPoint.FromXML(ref theNode2, ref theDictionary);
					break;
				}
				case "FiringParent":
					unguidedWeapon.FiringParent_ID = val.InnerText;
					break;
				case "Target":
					unguidedWeapon.Target = Contact.FromXML(val.InnerText, ref theDictionary);
					break;
				case "TimeToDetonate":
					unguidedWeapon.float_7 = XmlConvert.ToSingle(val.InnerText);
					break;
				case "Side":
					unguidedWeapon.set_UnitSide(SetSideOnly: false, Side.FromXML_ByName(val.InnerText, ref theDictionary, theScen));
					break;
				case "MineTargeted":
					unguidedWeapon.Mine_Targeted_ID = val.InnerText;
					break;
				case "TimeToLive":
					unguidedWeapon.float_6 = XmlConvert.ToSingle(val.InnerText);
					break;
				case "CEP_Land":
					unguidedWeapon.CEP_Land = XmlConvert.ToSingle(val.InnerText);
					break;
				case "CurrentSpeed":
					unguidedWeapon.CurrentSpeed = XmlConvert.ToSingle(val.InnerText);
					break;
				case "CEP":
				case "CEP_Surface":
					unguidedWeapon.CEP_Surface = XmlConvert.ToSingle(val.InnerText);
					break;
				case "CurrentHeading":
					unguidedWeapon.CurrentHeading = XmlConvert.ToSingle(val.InnerText);
					break;
				case "FiringWR":
					unguidedWeapon.FiringWeaponRec_ID = val.InnerText;
					break;
				case "ImpactAltitude":
					unguidedWeapon.ImpactAltitude = XmlConvert.ToSingle(val.InnerText);
					break;
				}
			}
			result = unguidedWeapon;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100853", "");
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

	private UnguidedWeapon()
	{
		Warheads = new Warhead[0];
		Flags = default(Weapon.WeaponFlags);
		Mine_Targeted = null;
	}

	public UnguidedWeapon(Weapon theReferenceWeapon, Contact theTarget, ActiveUnit FiringUnit, double theLatitude, double theLongitude, long ArmDelay_Sec = 0L)
	{
		Warheads = new Warhead[0];
		Flags = default(Weapon.WeaponFlags);
		Mine_Targeted = null;
		try
		{
			int_1 = theReferenceWeapon.DBID;
			weapon_0 = theReferenceWeapon;
			UnitClass = theReferenceWeapon.UnitClass;
			Name = theReferenceWeapon.Name;
			_WeaponType_0 = theReferenceWeapon.Type;
			CruiseAltitude_AGL = theReferenceWeapon.CruiseAltitude_AGL;
			CruiseAltitude_ASL = theReferenceWeapon.CruiseAltitude_ASL;
			SurfPOK = theReferenceWeapon.SurfPOK;
			LandPOK = theReferenceWeapon.LandPOK;
			SubPOK = theReferenceWeapon.SubPOK;
			AirPOK = theReferenceWeapon.AirPOK;
			MaxAirRange = theReferenceWeapon.MaxAirRange;
			MinAirRange = theReferenceWeapon.MinAirRange;
			MaxSurfaceRange = theReferenceWeapon.MaxSurfaceRange;
			MinSurfaceRange = theReferenceWeapon.MinSurfaceRange;
			MaxLandRange = theReferenceWeapon.MaxLandRange;
			MinLandRange = theReferenceWeapon.MinLandRange;
			MaxSubsurfaceRange = theReferenceWeapon.MaxSubsurfaceRange;
			MinSubsurfaceRange = theReferenceWeapon.MinSubsurfaceRange;
			MaxLaunchAlt_AGL = theReferenceWeapon.MaxLaunchAlt_AGL;
			MinLaunchAlt_AGL = theReferenceWeapon.MinLaunchAlt_AGL;
			MaxLaunchAlt_ASL = theReferenceWeapon.MaxLaunchAlt_ASL;
			MinLaunchAlt_ASL = theReferenceWeapon.MinLaunchAlt_ASL;
			MaxTargetAlt_AGL = theReferenceWeapon.MaxTargetAlt_AGL;
			MinTargetAlt_AGL = theReferenceWeapon.MinTargetAlt_AGL;
			MaxTargetAlt_ASL = theReferenceWeapon.MaxTargetAlt_ASL;
			MinTargetAlt_ASL = theReferenceWeapon.MinTargetAlt_ASL;
			CEP_Land = theReferenceWeapon.CEP_Land;
			CEP_Surface = theReferenceWeapon.CEP_Surface;
			if (ArmDelay_Sec != 0L)
			{
				float_7 = ArmDelay_Sec;
			}
			else
			{
				float_7 = theReferenceWeapon._TimeToDetonate;
			}
			if (FiringUnit != null)
			{
				FiringParent_ID = FiringUnit.ObjectID;
			}
			if (_WeaponType_0 == Weapon._WeaponType.Laser)
			{
				float_7 = 2f;
			}
			else if (_WeaponType_0 == Weapon._WeaponType.LaserDazzler)
			{
				float_7 = 3f;
			}
			if (_WeaponType_0 == Weapon._WeaponType.Microwave)
			{
				float_7 = 5f;
			}
			DBFunctions.PopulateWeaponFlags(ref theReferenceWeapon, ref Flags);
			DBFunctions.PopulateWarheads(ref Warheads, ref theReferenceWeapon);
			Target = theTarget;
			if (!Information.IsNothing((object)FiringUnit) && !Information.IsNothing((object)theTarget))
			{
				float currentSpeed = FiringUnit.CurrentSpeed;
				double num = (double)GameGeneral.GlobalRNG.Next(95, 106) / 100.0;
				switch (_WeaponType_0)
				{
				case Weapon._WeaponType.DepthCharge:
					if (!theTarget.SpeedIsKnown)
					{
						CurrentSpeed = (float)((double)(currentSpeed / 2f) + (double)(MaxSubsurfaceRange * 5f) * num);
					}
					else
					{
						CurrentSpeed = (float)((double)(currentSpeed / 2f + theTarget.CurrentSpeed * 2f) + (double)(MaxSubsurfaceRange * 5f) * num);
					}
					break;
				case Weapon._WeaponType.Rocket:
					switch (theTarget.Type)
					{
					default:
						CurrentSpeed = (float)((double)(currentSpeed + MaxSubsurfaceRange * 100f) * num);
						break;
					case Contact_Base.ContactType.Air:
					case Contact_Base.ContactType.Missile:
					case Contact_Base.ContactType.Orbital:
						CurrentSpeed = (float)((double)(currentSpeed + MaxAirRange * 100f) * num);
						break;
					case Contact_Base.ContactType.Surface:
					case Contact_Base.ContactType.Facility_Fixed:
					case Contact_Base.ContactType.Facility_Mobile:
					case Contact_Base.ContactType.AggregateGroundUnit:
						CurrentSpeed = (float)((double)(currentSpeed + MaxSurfaceRange * 100f) * num);
						break;
					}
					break;
				case Weapon._WeaponType.IronBomb:
					if (!Flags.IsRetardedWeapon)
					{
						CurrentSpeed = (float)((double)currentSpeed * 0.9 * num);
					}
					else
					{
						CurrentSpeed = (float)((double)currentSpeed * 0.4 * num);
					}
					break;
				case Weapon._WeaponType.Gun:
				{
					double num2 = CalculateGunMuzzleVelocity_mpersec(theTarget.Type, ReferenceWeapon.MaxRange_NoTargetType, method_2()) * 1.94384;
					CurrentSpeed = (float)((double)currentSpeed + num2 * num);
					Warhead.WarheadType type = Warheads[0].Type;
					if (type == Warhead.WarheadType.ArmorPiercing || type == Warhead.WarheadType.LongRodPenetrator)
					{
						CurrentSpeed = (float)((double)(CurrentSpeed * 2f) * num);
					}
					break;
				}
				}
			}
			if (Information.IsNothing((object)FiringUnit))
			{
				geoPoint_0 = new GeoPoint(theLongitude, theLatitude, 0f);
			}
			else
			{
				geoPoint_0 = new GeoPoint(theLongitude, theLatitude, FiringUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
			}
			((Module_Unit.Unit)this).set_Latitude((GlobalVariables.BooleanObject)null, theLatitude);
			((Module_Unit.Unit)this).set_Longitude((GlobalVariables.BooleanObject)null, theLongitude);
			if (Information.IsNothing((object)theTarget))
			{
				return;
			}
			if (Type == Weapon._WeaponType.IronBomb && !Information.IsNothing((object)FiringUnit) && !Information.IsNothing((object)theTarget))
			{
				float num3 = Math.Abs(FiringUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - ((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
				float num4 = ((!(num3 > 5000f)) ? ((float)Math.Sqrt((double)num3 / 4.5)) : (33f + (num3 - 5000f) / 300f));
				float_7 = Math.Max(num4, float_7);
				if (num4 > 0f)
				{
					CurrentSpeed = Math.Min(FiringUnit.CurrentSpeed - 10f, 3600f * FiringUnit.RangeToUnit_Horiz(theTarget) / num4);
				}
				float_6 = float_7 + 1f;
			}
			else
			{
				double val = ((!theTarget.SpeedIsKnown || !(theTarget.CurrentSpeed > 0f)) ? (3600.0 * method_1() / (double)CurrentSpeed) : (3600.0 * method_1() * 2.0 / (double)CurrentSpeed));
				float_6 = (float)Math.Max(val, TimeToDetonate + 1f);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100854", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool myTargetHasBeenDestroyed(Scenario theScen)
	{
		return Target.get_IsDestroyed(theScen);
	}

	private double method_1()
	{
		return Math.Max(MaxAirRange, Math.Max(MaxSurfaceRange, Math.Max(MaxLandRange, MaxSubsurfaceRange)));
	}

	public static string CanLayMineHere(ref UnguidedWeapon theM, double theLat, double theLon, float DepthAtPlacementCoords, Scenario theScen)
	{
		string result;
		try
		{
			if (DepthAtPlacementCoords > 0f)
			{
				result = "Cannot lay naval mines over land!";
			}
			else
			{
				switch (theM.Type)
				{
				case Weapon._WeaponType.BottomMine:
					if (theScen.FeatureCompatibility.get_WeaponAGL_ASL(theScen.DBConnection))
					{
						if (DepthAtPlacementCoords < theM.MinTargetAlt_ASL)
						{
							result = ((!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet) ? ("Water is too deep. Maximum mine depth is " + Conversions.ToString((int)Math.Round(theM.MinTargetAlt_ASL)) + " m while water depth is " + Conversions.ToString((int)Math.Round(DepthAtPlacementCoords)) + " m.") : ("Water is too deep. Maximum mine depth is " + Conversions.ToString((int)Math.Round(theM.MinTargetAlt_ASL * 3.28084f)) + " ft while water depth is " + Conversions.ToString((int)Math.Round(DepthAtPlacementCoords * 3.28084f)) + " ft."));
						}
						else
						{
							if (!(DepthAtPlacementCoords > -5f))
							{
								goto IL_0330;
							}
							result = (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet ? ("Water is too shallow. Minimum mine depth is " + Conversions.ToString(16) + " ft while sea depth is " + Conversions.ToString((int)Math.Round(DepthAtPlacementCoords * 3.28084f)) + " ft.") : ("Water is too shallow. Minimum mine depth is " + Conversions.ToString(5) + " m while sea depth is " + Conversions.ToString((int)Math.Round(DepthAtPlacementCoords)) + " m."));
						}
					}
					else if (DepthAtPlacementCoords < theM.MinTargetAlt_AGL)
					{
						result = (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet ? ("Water is too deep. Maximum mine depth is " + Conversions.ToString((int)Math.Round(theM.MinTargetAlt_AGL * 3.28084f)) + " ft while water depth is " + Conversions.ToString((int)Math.Round(DepthAtPlacementCoords * 3.28084f)) + " ft.") : ("Water is too deep. Maximum mine depth is " + Conversions.ToString((int)Math.Round(theM.MinTargetAlt_AGL)) + " m while water depth is " + Conversions.ToString((int)Math.Round(DepthAtPlacementCoords)) + " m."));
					}
					else
					{
						if (!(DepthAtPlacementCoords > -5f))
						{
							goto IL_0330;
						}
						result = (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet ? ("Water is too shallow. Minimum mine depth is " + Conversions.ToString(16) + " ft while sea depth is " + Conversions.ToString((int)Math.Round(DepthAtPlacementCoords * 3.28084f)) + " ft.") : ("Water is too shallow. Minimum mine depth is " + Conversions.ToString(5) + " m while sea depth is " + Conversions.ToString((int)Math.Round(DepthAtPlacementCoords)) + " m."));
					}
					goto end_IL_0001;
				case Weapon._WeaponType.FloatingMine:
				case Weapon._WeaponType.DriftingMine:
					((Module_Unit.Unit)theM).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, 0f);
					break;
				case Weapon._WeaponType.MooredMine:
				case Weapon._WeaponType.MovingMine:
				case Weapon._WeaponType.RisingMine:
				case Weapon._WeaponType.DummyMine:
					{
						if (theScen.FeatureCompatibility.get_WeaponAGL_ASL(theScen.DBConnection))
						{
							if (DepthAtPlacementCoords < theM.MinTargetAlt_ASL)
							{
								result = ((!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet) ? ("Water is too deep. Maximum mine depth is " + Conversions.ToString((int)Math.Round(theM.MinTargetAlt_ASL)) + " m while water depth is " + Conversions.ToString((int)Math.Round(DepthAtPlacementCoords)) + " m.") : ("Water is too deep. Maximum mine depth is " + Conversions.ToString((int)Math.Round(theM.MinTargetAlt_ASL * 3.28084f)) + " ft while water depth is " + Conversions.ToString((int)Math.Round(DepthAtPlacementCoords * 3.28084f)) + " ft."));
							}
							else
							{
								if (!(DepthAtPlacementCoords > theM.MaxTargetAlt_ASL))
								{
									goto IL_0676;
								}
								result = (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet ? ("Water is too shallow. Minimum mine depth is " + Conversions.ToString((int)Math.Round(theM.MaxTargetAlt_ASL * 3.28084f)) + " ft while sea depth is " + Conversions.ToString((int)Math.Round(DepthAtPlacementCoords * 3.28084f)) + " ft.") : ("Water is too shallow. Minimum mine depth is " + Conversions.ToString((int)Math.Round(theM.MaxTargetAlt_ASL)) + " m while sea depth is " + Conversions.ToString((int)Math.Round(DepthAtPlacementCoords)) + " m."));
							}
						}
						else if (DepthAtPlacementCoords < theM.MinTargetAlt_AGL)
						{
							result = ((!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet) ? ("Water is too deep. Maximum mine depth is " + Conversions.ToString((int)Math.Round(theM.MinTargetAlt_AGL)) + " m while water depth is " + Conversions.ToString((int)Math.Round(DepthAtPlacementCoords)) + " m.") : ("Water is too deep. Maximum mine depth is " + Conversions.ToString((int)Math.Round(theM.MinTargetAlt_AGL * 3.28084f)) + " ft while water depth is " + Conversions.ToString((int)Math.Round(DepthAtPlacementCoords * 3.28084f)) + " ft."));
						}
						else
						{
							if (!(DepthAtPlacementCoords > theM.MaxTargetAlt_AGL))
							{
								goto IL_0676;
							}
							result = (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet ? ("Water is too shallow. Minimum mine depth is " + Conversions.ToString((int)Math.Round(theM.MaxTargetAlt_AGL * 3.28084f)) + " ft while sea depth is " + Conversions.ToString((int)Math.Round(DepthAtPlacementCoords * 3.28084f)) + " ft.") : ("Water is too shallow. Minimum mine depth is " + Conversions.ToString((int)Math.Round(theM.MaxTargetAlt_ASL)) + " m while sea depth is " + Conversions.ToString((int)Math.Round(DepthAtPlacementCoords)) + " m."));
						}
						goto end_IL_0001;
					}
					IL_0676:
					((Module_Unit.Unit)theM).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)((double)DepthAtPlacementCoords + GameGeneral.GlobalRNG.NextDouble() * (double)(0f - DepthAtPlacementCoords) - 5.0));
					break;
					IL_0330:
					((Module_Unit.Unit)theM).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, DepthAtPlacementCoords);
					break;
				}
				((Module_Unit.Unit)theM).set_Latitude((GlobalVariables.BooleanObject)null, theLat);
				((Module_Unit.Unit)theM).set_Longitude((GlobalVariables.BooleanObject)null, theLon);
				result = "OK";
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100855", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = "Can not lay mine here (Error!)";
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void Detonate(Scenario theScen)
	{
		try
		{
			float theAltitude;
			if (!ReferenceWeapon.IsNuke.Value)
			{
				theAltitude = ((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			}
			else if (Type == Weapon._WeaponType.DepthCharge)
			{
				byte? b = (byte?)ReferenceWeapon?.AI.PrimaryTarget?.Type;
				if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 22)) != true)
				{
					b = (byte?)ReferenceWeapon?.AI.PrimaryTarget?.Type;
					if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 5)) != true)
					{
						Contact target = Target;
						if (target == null || target.Type != Contact_Base.ContactType.ActivationPoint)
						{
							Contact target2 = Target;
							if (target2 == null || target2.Type != Contact_Base.ContactType.Aimpoint)
							{
								theAltitude = ((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
								goto IL_01cd;
							}
						}
						theAltitude = Math.Max(base.get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, theScen), -300);
						goto IL_01cd;
					}
				}
				theAltitude = Math.Max(base.get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, theScen), -300);
			}
			else
			{
				theAltitude = OptimumBurstHeight + (float)Math.Max(0, base.get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, theScen));
			}
			goto IL_01cd;
			IL_01cd:
			if (Warheads.Count() <= 0)
			{
				return;
			}
			if (Type == Weapon._WeaponType.AttachedMine)
			{
				if (Target?.ActualUnit != null)
				{
					Weapon.RaiseEvent_WeaponImpact(theScen, ReferenceWeapon, Target, DirectHit: false);
					ActiveUnit actualUnit = Target.ActualUnit;
					ActiveUnit activeUnit_ = FiringParent;
					double? nullable_ = ((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null);
					double? nullable_2 = ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null);
					string string_ = null;
					method_7(actualUnit, 0f, 0f, ref activeUnit_, nullable_, nullable_2, null, ref string_);
					FiringParent = activeUnit_;
				}
			}
			else
			{
				new Explosion(ref theScen, this, ref Target, ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), CurrentHeading, theAltitude, Type, Warheads[0].DP, Warheads[0].DP, Warheads[0].Type, Warheads[0].ExplosivesType, null, null, FiringParent, null, null, 0, 0);
			}
			DestroyMe(ref theScen, "Intentional detonation");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100856", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	[SpecialName]
	private bool method_2()
	{
		if (!nullable_9.HasValue)
		{
			int result;
			if (FiringParent != null)
			{
				if (Target != null)
				{
					nullable_9 = (Type == Weapon._WeaponType.Gun || Type == Weapon._WeaponType.Rocket) && !FiringParent.IsAircraft && !Target.IsAircraftContact && !Target.IsWeaponContact;
					goto IL_0079;
				}
				result = 0;
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}
		goto IL_0079;
		IL_0079:
		return nullable_9.Value;
	}

	private void method_3(Scenario scenario_0, float float_9)
	{
		method_8();
		((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null);
		((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null);
		double num = CalculateGunMuzzleVelocity_mpersec(Target.Type, ReferenceWeapon.MaxRange_NoTargetType, method_2());
		if (method_2())
		{
			float_6 = float.MaxValue;
			double num2 = geoPoint_0.RangeToPoint_Horiz(((Module_Unit.Unit)Target).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)Target).get_Latitude((GlobalVariables.BooleanObject)null));
			double num3 = num2 / (double)ReferenceWeapon.MaxRange_NoTargetType;
			double num4 = 35.0 * num3;
			if (ReferenceWeapon.IsMortarRound())
			{
				num4 = Math.Min(80.0, num4 * 2.0);
			}
			double num5 = Math.Pow(num, 2.0) * Math.Pow(Math2.Sind(num4), 2.0) / 19.62;
			double out_lon = default(double);
			double out_lat = default(double);
			Geodesic_EdWilliams.CalcPoint_Williams(distance_NM: (double)CurrentSpeed * Math2.Cosd(num4) * (double)float_9 / 3600.0, Lon1: ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), Lat1: ((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), out_lon2: ref out_lon, out_lat2: ref out_lat, bearing: CurrentHeading);
			((Module_Unit.Unit)this).set_Longitude((GlobalVariables.BooleanObject)null, out_lon);
			((Module_Unit.Unit)this).set_Latitude((GlobalVariables.BooleanObject)null, out_lat);
			double num6 = num2 * 1852.0 / 2.0;
			double num7 = num5 / Math.Pow(num6, 2.0);
			double x = Math.Abs((double)(Module_Unit.RangeToPoint_Horiz(this, geoPoint_0) * 1852f) - num6);
			double num8 = 0.0 - num7 * Math.Pow(x, 2.0) + num5;
			((Module_Unit.Unit)this).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)(num8 + (double)geoPoint_0.Altitude));
		}
		else
		{
			ActualHorizMovement(float_9, SimplifiedCalcs_DLZ: false);
			float num9 = Math.Abs(geoPoint_0.Altitude - ((Module_Unit.Unit)Target).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
			double num10 = geoPoint_0.RangeToPoint_Horiz(((Module_Unit.Unit)Target).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)Target).get_Latitude((GlobalVariables.BooleanObject)null));
			double num11 = (double)RangeToUnit_Horiz(Target) / num10;
			if (((Module_Unit.Unit)Target).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > geoPoint_0.Altitude)
			{
				((Module_Unit.Unit)this).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)((double)((Module_Unit.Unit)Target).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - (double)num9 * num11));
			}
			else
			{
				((Module_Unit.Unit)this).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)((double)((Module_Unit.Unit)Target).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + (double)num9 * num11));
			}
		}
		if (Type == Weapon._WeaponType.Gun)
		{
			double num12 = Module_Unit.RangeToPoint_Slant(this, geoPoint_0) / ReferenceWeapon.MaxRange_NoTargetType;
			double num13 = num * 1.94384;
			CurrentSpeed = (float)(num13 * (0.34 + 0.67 * (1.0 - num12)));
		}
		ExportLocationEvent(scenario_0);
	}

	public bool WillImpactTargetThisPulse(float elapsedtime)
	{
		if (Target != null)
		{
			if (Type == Weapon._WeaponType.IronBomb)
			{
				return float_7 <= 0f;
			}
			double out_lat = ((Module_Unit.Unit)Target).get_Latitude((GlobalVariables.BooleanObject)null);
			double out_lon = ((Module_Unit.Unit)Target).get_Longitude((GlobalVariables.BooleanObject)null);
			float num = CurrentSpeed / 3600f * elapsedtime;
			if (Target.CurrentSpeed > 200f / elapsedtime)
			{
				Geodesic_EdWilliams.CalcPoint_Williams(((Module_Unit.Unit)Target).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)Target).get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, Target.CurrentSpeed / 3600f * elapsedtime, Target.CurrentHeading);
			}
			if (Module_Unit.RangeToPoint_Horiz(this, out_lat, out_lon) <= num)
			{
				return true;
			}
		}
		return false;
	}

	public void ResolveImpactResults(ref Scenario theScen, float elapsedTime, ref LockRandom theRNG)
	{
		try
		{
			string string_ = "";
			if (!Target.get_IsDestroyed(theScen))
			{
				if (CurrentAltitude_AGL < 0f)
				{
					((Module_Unit.Unit)this).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)base.get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, theScen));
				}
				if (((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < 0f)
				{
					((Module_Unit.Unit)this).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)Target).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
				}
				method_6(Target.ActualUnit, Target, ref theScen, ref theRNG, ref string_);
			}
			if (Target.Type == Contact_Base.ContactType.ActivationPoint)
			{
				Detonate(theScen);
			}
			DestroyMe(ref theScen, string_, "Impact / Detonation");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200042", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void TypeSpecificActions(ref Scenario theScen, float elapsedTime, ref LockRandom theRNG)
	{
		try
		{
			if (IsMine)
			{
				method_4(theScen, elapsedTime, ref theRNG);
				return;
			}
			if (float_7 > 0f)
			{
				float_7 -= elapsedTime;
			}
			if (Target == null)
			{
				if (Type == Weapon._WeaponType.Gun)
				{
					Detonate(theScen);
				}
			}
			else
			{
				if (WillImpactTargetThisPulse(elapsedTime))
				{
					ResolveImpactResults(ref theScen, elapsedTime, ref theRNG);
				}
				else if (Type != Weapon._WeaponType.Laser && Type != Weapon._WeaponType.Microwave && Type != Weapon._WeaponType.LaserDazzler)
				{
					method_3(theScen, elapsedTime);
				}
				if ((_WeaponType_0 == Weapon._WeaponType.Laser || _WeaponType_0 == Weapon._WeaponType.LaserDazzler) && float_7 <= 0f)
				{
					string string_ = default(string);
					method_6(Target.ActualUnit, Target, ref theScen, ref theRNG, ref string_);
					DestroyMe(ref theScen, string_, "Impact / Detonation");
				}
				if (_WeaponType_0 == Weapon._WeaponType.Microwave && float_7 <= 0f)
				{
					string string_2 = default(string);
					method_6(Target.ActualUnit, Target, ref theScen, ref theRNG, ref string_2);
					List<ActiveUnit> list = new List<ActiveUnit>();
					double num = Module_Unit.BearingToUnit_True(FiringParent, Target);
					double num2 = Module_Unit.GrazingAngleToUnit(FiringParent, Target);
					foreach (ActiveUnit activeUnits_ in theScen.ActiveUnits_List)
					{
						if (!activeUnits_.IsGroup && Module_Unit.RangeToUnit_Slant(FiringParent, activeUnits_) < MaxAirRange)
						{
							Sensor sensor = ReferenceWeapon.Sensors_Cached[0];
							double num3 = sensor.RadarHorBeamwidth;
							double num4 = sensor.RadarVertBeamwidth;
							double num5 = Module_Unit.BearingToUnit_True(FiringParent, activeUnits_);
							double num6 = Module_Unit.GrazingAngleToUnit(FiringParent, activeUnits_);
							if (Math.Abs(MathFunctions.AngularDifference((float)num, (float)num5)) < (float)(num3 / 2.0) && Math.Abs(num2 - num6) < num4 / 2.0 && Module_Unit.Has_Radar_LOS_ToUnit(FiringParent, sensor, activeUnits_, ref theScen))
							{
								list.Add(activeUnits_);
							}
						}
					}
					foreach (ActiveUnit item in list)
					{
						method_6(item, null, ref theScen, ref theRNG, ref string_2);
					}
					DestroyMe(ref theScen, string_2, "Impact / Detonation");
				}
			}
			if (!Module_Unit.IsRemoteSimEntity(this))
			{
				float_6 -= elapsedTime;
				if (float_6 <= 0f)
				{
					DestroyMe(ref theScen, "Weapon out of energy/fuel/time", "Missed");
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100857", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_4(Scenario scenario_0, float float_9, ref LockRandom lockRandom_0)
	{
		try
		{
			if (float_7 > 0f)
			{
				float_7 = Math.Max(0f, float_7 - float_9);
			}
			if (Type == Weapon._WeaponType.AttachedMine)
			{
				if (!(float_7 <= 0f))
				{
					return;
				}
				Detonate(scenario_0);
			}
			float_8 -= float_9;
			ActiveUnit activeUnit = null;
			Sensor explosiveChargeUsed = null;
			if (float_8 <= 0f)
			{
				bool flag = false;
				bool flag2 = false;
				bool flag3 = false;
				bool flag4 = false;
				if (Mine_Targeted != null && Mine_Targeted.IsWeapon)
				{
					if ((int)Math.Round((double)RangeToUnit_Horiz(Mine_Targeted) * 1852.0) < 20)
					{
						Weapon weapon = (Weapon)Mine_Targeted;
						weapon.Detonate(weapon.get_Latitude((GlobalVariables.BooleanObject)null), weapon.get_Longitude((GlobalVariables.BooleanObject)null), weapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ref lockRandom_0, Detonation_AddMessage: true);
						if (!weapon.DetonationOccurs)
						{
							return;
						}
						DestroyMe(ref scenario_0, "Mine neutralized");
						if (IsMine)
						{
							this.get_UnitSide(SetSideOnly: false).AAR.AddToLosses(this, TreatAsAimpoint: false);
						}
						List<EventTrigger> list = new List<EventTrigger>();
						foreach (EventTrigger value2 in scenario_0.EventTriggers.Values)
						{
							if (value2.Type == EventTrigger.EventTriggerType.UnitDestroyed && ((EventTrigger_UnitDestroyed)value2).get_IsFulfilled(this, activeUnit))
							{
								list.Add(value2);
							}
						}
						if (list.Count > 0)
						{
							scenario_0.FireEvents(list);
						}
						return;
					}
					if ((int)Math.Round((double)RangeToUnit_Horiz(Mine_Targeted) * 1852.0) < 500)
					{
						Mine_Targeted.DesiredAltitude = ((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
					}
				}
				if (scenario_0.CandidatesForDetectionByMines.Count == 0)
				{
					return;
				}
				bool flag5 = true;
				bool flag6 = true;
				if (Warheads.Count() > 0 && Warheads[0].get_CarriedWeapon(scenario_0) != null)
				{
					Weapon weapon2 = Warheads[0].get_CarriedWeapon(scenario_0);
					if (!weapon2.IsASuW_Naval)
					{
						flag5 = false;
					}
					if (!weapon2.IsASW)
					{
						flag6 = false;
					}
				}
				List<ActiveUnit> candidatesForDetectionByMines = scenario_0.CandidatesForDetectionByMines;
				int num4 = default(int);
				int num5 = default(int);
				foreach (ActiveUnit item in candidatesForDetectionByMines)
				{
					try
					{
						if (item.IsShip && !flag5)
						{
							continue;
						}
						if (item.IsMCMPlatform_ThisPulse == -1)
						{
							item.Determine_IsMCMPlatform();
						}
						if (!item.IsSubmarine)
						{
							goto IL_02c1;
						}
						if (!flag6)
						{
							continue;
						}
						switch (((Submarine)item).Type)
						{
						case Submarine._SubmarineType.SDV:
						case Submarine._SubmarineType.Biologics:
						case Submarine._SubmarineType.FalseTarget:
							goto end_IL_0249;
						case Submarine._SubmarineType.ROV:
						case Submarine._SubmarineType.UUV:
							if (item.IsMCMPlatform_ThisPulse != 0)
							{
								break;
							}
							goto end_IL_0249;
						}
						goto IL_02c1;
						IL_040b:
						if (!flag)
						{
							if (Math.Round(item.DesiredHeading, 2) != Math.Round(item.CurrentHeading, 2))
							{
								if (item.IsAircraft)
								{
									if ((double)Math.Abs(MathFunctions.AngularDifference(item.CurrentHeading, item.DesiredHeading)) < 0.2)
									{
										UnguidedWeapon value = null;
										if (item.ParentScen.MineAllocation.TryGetValue(item.ObjectID, ref value) && value != null)
										{
											float num = item.RangeToUnit_Horiz(value);
											if ((double)num > 0.75)
											{
												item.AI.ManouverToSweepMine(value, num, ResetPath: true);
											}
										}
									}
								}
								else
								{
									float num2 = Math.Abs(MathFunctions.AngularDifference(item.CurrentHeading, item.DesiredHeading));
									int num3 = 3;
									if (num2 < 60f)
									{
										num3 = 2;
									}
									if (num2 < 30f)
									{
										num3 = 1;
									}
									if (num2 < 10f)
									{
										num3 = 0;
									}
									List<Sensor> mineCountermeasures = item.MineCountermeasures;
									foreach (Sensor item2 in mineCountermeasures)
									{
										if (item2.IsActive() && item2.TimeToNextScan < 1 && !item2.IsExplosiveMineNeutralizer)
										{
											item2.TimeToNextScan = num3 * 60;
										}
									}
								}
							}
							else
							{
								List<Sensor> mineCountermeasures2 = item.MineCountermeasures;
								foreach (Sensor item3 in mineCountermeasures2)
								{
									if (item3.IsActive() && (item3.get_CanSweepThisMine(this) || item3.get_CanTriggerThisMine(this)))
									{
										if (float_7 > 0f)
										{
											Sensor.Sensor_Type type = item3.Type;
											if (type <= Sensor.Sensor_Type.MineNeutralization_MooredMineCableCutter)
											{
												if ((type != Sensor.Sensor_Type.MineSweep_MechanicalCableCutter && type != Sensor.Sensor_Type.MineNeutralization_MooredMineCableCutter) || (Type != Weapon._WeaponType.MooredMine && Type != Weapon._WeaponType.DummyMine))
												{
													continue;
												}
											}
											else if (type != Sensor.Sensor_Type.MineNeutralization_ExplosiveChargeMineDisposal && type != Sensor.Sensor_Type.MineNeutralization_DiverExplosiveCharge)
											{
												continue;
											}
										}
										if (!item3.IsExplosiveMineNeutralizer)
										{
											if ((Type == Weapon._WeaponType.FloatingMine || Type == Weapon._WeaponType.DriftingMine) && item.IsShip && ((Ship)item).Crew > 0)
											{
												num4 = (int)Math.Round((double)RangeToUnit_Horiz(item) * 1852.0);
												if (num4 < 200 && item.CurrentSpeed <= 5f && GameGeneral.GlobalRNG.Next(1, 50) < 30)
												{
													flag = true;
													flag3 = true;
													activeUnit = item;
													explosiveChargeUsed = null;
													num5 = (int)Math.Round(Math2.CalcAzimuth(activeUnit.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null)));
													break;
												}
											}
										}
										else
										{
											num4 = (int)Math.Round((double)RangeToUnit_Horiz(item) * 1852.0);
											if (num4 < 100 && item.CurrentSpeed <= 5f && (Mine_Targeted == null || item.ParentScen.MineAllocation.ContainsKey(item.ObjectID)))
											{
												int num6 = GameGeneral.GlobalRNG.Next(1, 50);
												if (item3.Status == PlatformComponent._ComponentStatus.Operational && num6 < 10)
												{
													flag = true;
													flag4 = true;
													activeUnit = item;
													explosiveChargeUsed = item3;
													num5 = (int)Math.Round(Math2.CalcAzimuth(activeUnit.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null)));
													break;
												}
											}
										}
										if (GeoPoint.IsInsideThisArea(((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), item3.MineSweepCoverageArea, HaveToCheckAntimeridian: false))
										{
											flag = true;
											flag3 = true;
											activeUnit = item;
											explosiveChargeUsed = item3;
											num4 = (int)Math.Round((double)RangeToUnit_Horiz(activeUnit) * 1852.0);
											num5 = (int)Math.Round(Math2.CalcAzimuth(activeUnit.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null)));
											break;
										}
									}
									else if (item3.IsActive() && item3.MineSweepCoverageArea != null && item3.TimeToNextScan < 1 && Mine_Targeted != null)
									{
										Operators.CompareString(item.ObjectID, Mine_Targeted.ObjectID, false);
									}
								}
							}
						}
						goto IL_08ab;
						IL_02c1:
						double num7 = Math2.Distance_To_AngularDegrees((float)((double)item.get_SafeDistanceAgainstKnownMineType_meters(Type, UsePathfindingBufferDistance: false) / 1852.0));
						if (Type == Weapon._WeaponType.RisingMine && item.IsMCMPlatform_ThisPulse == 0)
						{
							Weapon weapon3 = Warheads[0].get_CarriedWeapon(item.ParentScen);
							if (weapon3 != null)
							{
								num7 = Math2.Distance_To_AngularDegrees(weapon3.MaxRange_NoTargetType);
							}
						}
						int num8 = ((item.IsMCMPlatform_ThisPulse == 0) ? 1 : 5);
						if (!item.IsAircraft && float_7 == 0f)
						{
							double num9 = Module_Unit.RangeToUnit_Horiz_Angular(this, item);
							if (Type != Weapon._WeaponType.DummyMine && num9 <= num7 && (float)num8 < item.CurrentSpeed)
							{
								int num10;
								if (Type != Weapon._WeaponType.RisingMine)
								{
									if (!(Module_Unit.ClosureSpeed(this, item, CurrentSpeed, CurrentHeading) < 0f))
									{
										goto IL_040b;
									}
									num10 = 1;
								}
								else
								{
									num10 = 1;
								}
								flag = (byte)num10 != 0;
								flag2 = true;
								activeUnit = item;
								num4 = (int)Math.Round((double)RangeToUnit_Horiz(activeUnit) * 1852.0);
								num5 = (int)Math.Round(Math2.CalcAzimuth(activeUnit.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null)));
								break;
							}
						}
						goto IL_040b;
						end_IL_0249:;
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2?.Data.Add("Error at 200043", ex2.Message);
						GameGeneral.WriteExceptionsToLog(ex2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
						goto IL_08ab;
					}
					continue;
					IL_08ab:
					if (flag)
					{
						break;
					}
				}
				if (flag)
				{
					if (flag4)
					{
						activeUnit.NeutralizeMine(this, explosiveChargeUsed);
					}
					else if (float_7 > 0f)
					{
						base.EndgameReport.AddEndGameMessage(hit: false, "No mine detonation! Bearing " + Conversions.ToString(num5) + " - Range " + Conversions.ToString(num4) + "m from " + activeUnit.Name);
						DestroyMe(ref scenario_0, "Mine detonated");
					}
					else if (Warheads.Count() > 0 && Warheads[0].get_CarriedWeapon(scenario_0) != null)
					{
						try
						{
							Contact contact_ = Contact.Instantiate(activeUnit);
							((Module_Unit.Unit)contact_).set_Latitude((GlobalVariables.BooleanObject)null, activeUnit.get_Latitude((GlobalVariables.BooleanObject)null));
							((Module_Unit.Unit)contact_).set_Longitude((GlobalVariables.BooleanObject)null, activeUnit.get_Longitude((GlobalVariables.BooleanObject)null));
							contact_.Type = Contact_Base.ContactType.Aimpoint;
							Weapon weapon_ = Weapon.GetNewWeapon(ref activeUnit.ParentScen, Warheads[0].get_CarriedWeapon(activeUnit.ParentScen).DBID, bool_5: false);
							((ActiveUnit)weapon_).set_UnitSide(SetSideOnly: false, this.get_UnitSide(SetSideOnly: false));
							if (weapon_.IsTorpedo)
							{
								weapon_.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
								if (flag3)
								{
									base.EndgameReport.AddEndGameMessage(hit: false, "Underwater detonation! Bearing " + Conversions.ToString(num5) + " - Range " + Conversions.ToString(num4) + "m from " + activeUnit.Name);
									weapon_.Detonate(weapon_.get_Latitude((GlobalVariables.BooleanObject)null), weapon_.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ref lockRandom_0, Detonation_AddMessage: true);
								}
								else
								{
									method_5(ref weapon_, weapon_.DBID, ref contact_, ActiveUnit.Throttle.Flank);
								}
							}
							if (weapon_.Type == Weapon._WeaponType.Rocket)
							{
								switch (activeUnit.UnitType)
								{
								case GlobalVariables.ActiveUnitType.Ship:
								case GlobalVariables.ActiveUnitType.Submarine:
									if (!flag3)
									{
										weapon_.set_Longitude((GlobalVariables.BooleanObject)null, activeUnit.get_Longitude((GlobalVariables.BooleanObject)null));
										weapon_.set_Latitude((GlobalVariables.BooleanObject)null, activeUnit.get_Latitude((GlobalVariables.BooleanObject)null));
										weapon_.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, activeUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - 1f);
										base.EndgameReport.AddEndGameMessage(hit: false, "Underwater detonation! Right underneath " + activeUnit.Name);
										weapon_.Impact(activeUnit, null);
									}
									else
									{
										weapon_.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, -1f);
										base.EndgameReport.AddEndGameMessage(hit: false, "Underwater detonation! Bearing " + Conversions.ToString(num5) + " - Range " + Conversions.ToString(num4) + "m from " + activeUnit.Name);
										weapon_.Detonate(weapon_.get_Latitude((GlobalVariables.BooleanObject)null), weapon_.get_Longitude((GlobalVariables.BooleanObject)null), 0f, ref lockRandom_0, Detonation_AddMessage: true);
									}
									break;
								default:
									if (Debugger.IsAttached)
									{
										Debugger.Break();
									}
									break;
								case GlobalVariables.ActiveUnitType.Aircraft:
									weapon_.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, -1f);
									base.EndgameReport.AddEndGameMessage(hit: false, "Underwater detonation! Bearing " + Conversions.ToString(num5) + " - Range " + Conversions.ToString(num4) + "m from " + activeUnit.Name);
									weapon_.Detonate(weapon_.get_Latitude((GlobalVariables.BooleanObject)null), weapon_.get_Longitude((GlobalVariables.BooleanObject)null), 0f, ref lockRandom_0, Detonation_AddMessage: true);
									break;
								}
							}
							DestroyMe(ref activeUnit.ParentScen, "Mine detonation", "Impact / Detonation");
						}
						catch (Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							Exception ex4 = ex3;
							ex4?.Data.Add("Error at 200044", ex4.Message);
							GameGeneral.WriteExceptionsToLog(ex4);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					else if (Type != Weapon._WeaponType.DummyMine && float_7 <= 0f)
					{
						if (Type != Weapon._WeaponType.FloatingMine && Type != Weapon._WeaponType.DriftingMine)
						{
							base.EndgameReport.AddEndGameMessage(hit: false, "Underwater detonation! Bearing " + Conversions.ToString(num5) + " - Range " + Conversions.ToString(num4) + "m from " + activeUnit.Name);
							Detonate(scenario_0);
						}
						else
						{
							base.EndgameReport.AddEndGameMessage(hit: false, "Surface detonation! Bearing " + Conversions.ToString(num5) + " - Range " + Conversions.ToString(num4) + "m from " + activeUnit.Name);
							Detonate(scenario_0);
						}
					}
					else
					{
						base.EndgameReport.AddEndGameMessage(hit: false, "No mine detonation! Bearing " + Conversions.ToString(num5) + " - Range " + Conversions.ToString(num4) + "m from " + activeUnit.Name);
						DestroyMe(ref scenario_0, "Mine detonated");
					}
					if (IsMine && (flag4 || flag3))
					{
						this.get_UnitSide(SetSideOnly: false).AAR.AddToLosses(this, TreatAsAimpoint: false);
					}
					if (IsMine && flag2)
					{
						this.get_UnitSide(SetSideOnly: false).AAR.AddToExpenditures(DBID(), 1);
					}
					if (IsMine && !flag4)
					{
						if (flag3)
						{
							((Module_Unit.Unit)this).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, -1f);
						}
						List<EventTrigger> list2 = new List<EventTrigger>();
						foreach (EventTrigger value3 in scenario_0.EventTriggers.Values)
						{
							if (value3.Type == EventTrigger.EventTriggerType.UnitDestroyed && ((EventTrigger_UnitDestroyed)value3).get_IsFulfilled(this, activeUnit))
							{
								list2.Add(value3);
							}
						}
						if (list2.Count > 0)
						{
							scenario_0.FireEvents(list2);
						}
					}
				}
			}
			float_8 = (float)(lockRandom_0.NextDouble() * 3.0);
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			ex6?.Data.Add("Error at 100858", "");
			GameGeneral.WriteExceptionsToLog(ex6);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void DestroyMe(ref Scenario theScen, string theReason, string WhatCausedDestruction = null)
	{
		try
		{
			theScen.DestroyThisUnguidedWeapon(this, theReason, WhatCausedDestruction);
			if (this.get_UnitSide(SetSideOnly: false) != null)
			{
				this.get_UnitSide(SetSideOnly: false).RemoveWeaponFromSalvos(ref theScen, ref ObjectID);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 104856", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_5(ref Weapon weapon_1, int int_2, ref Contact contact_0, ActiveUnit.Throttle throttle_0 = ActiveUnit.Throttle.Cruise)
	{
		if (contact_0.ActualUnit == null)
		{
			return;
		}
		try
		{
			Scenario parentScen = contact_0.ActualUnit.ParentScen;
			Interlocked.Increment(ref parentScen.UnitsAutoIncrement);
			weapon_1.Name = weapon_1.Name + " #" + Conversions.ToString(parentScen.UnitsAutoIncrement);
			((ActiveUnit)weapon_1).set_UnitSide(SetSideOnly: false, this.get_UnitSide(SetSideOnly: false));
			weapon_1.AI.PrimaryTarget = contact_0;
			weapon_1.AI.PrimaryTarget_Type = contact_0.Type;
			weapon_1.set_Longitude((GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null));
			weapon_1.set_Latitude((GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null));
			weapon_1.set_CurrentAltitude(DoSanityCheck: true, (GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
			weapon_1.SetThrottle(throttle_0);
			_ = (float)weapon_1.Kinematics.GetMaximumSpeed(weapon_1.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), throttle_0, ValidateAndFixAltitude: false);
			weapon_1.DesiredSpeed = weapon_1.Kinematics.GetMaximumSpeed(weapon_1.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), throttle_0, ValidateAndFixAltitude: false);
			weapon_1.CurrentHeading = Math2.CalcAzimuth(((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)weapon_1.AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)weapon_1.AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null));
			((ActiveUnit)weapon_1).set_DesiredHeading(ActiveUnit.TurnRate.Max, weapon_1.CurrentHeading);
			if (weapon_1.IsTorpedo)
			{
				foreach (Sensor item in weapon_1.WeaponSensors())
				{
					if (item.CanBeActive)
					{
						item.GoActive();
					}
				}
			}
			weapon_1.LaunchPoint = new GeoPoint(((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
			weapon_1.LaunchSpeed = CurrentSpeed;
			parentScen.AddThisUnit(weapon_1);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100859", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private bool method_6(ActiveUnit activeUnit_1, Contact contact_0, ref Scenario scenario_0, ref LockRandom lockRandom_0, ref string string_1)
	{
		string_1 = "";
		bool result;
		if (activeUnit_1 != null)
		{
			StringBuilder stringBuilder = StringBuilderCache.Allocate();
			stringBuilder.Clear();
			bool flag = false;
			try
			{
				((Module_Unit.Unit)this).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, OptimumBurstHeight + (float)Math.Max(base.get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, scenario_0), 0));
				ImpactAltitude = ((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
				float num;
				if (activeUnit_1.IsAerospaceUnit)
				{
					num = AirPOK;
					goto IL_00aa;
				}
				if (activeUnit_1.IsSubmarine)
				{
					if (IsTorpedo)
					{
						num = SubPOK;
						if (num == 0f && activeUnit_1.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) == 0f)
						{
							num = SurfPOK;
						}
						goto IL_00aa;
					}
					result = Impact_CEP(activeUnit_1, contact_0, ref scenario_0, ref lockRandom_0, string_1);
				}
				else
				{
					result = Impact_CEP(activeUnit_1, contact_0, ref scenario_0, ref lockRandom_0, string_1);
				}
				goto end_IL_001e;
				IL_0447:
				float num3;
				if (activeUnit_1.IsAerospaceUnit && activeUnit_1.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > 0f && !Flags.CapableVsSeaskimmer)
				{
					double num2 = Math.Round(ReferenceWeapon.SeaSkimmerModifier(activeUnit_1.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)), 2);
					if (num2 > 0.0)
					{
						num3 = (float)((double)num3 - num2);
						stringBuilder.Append("Sea-skimmer modifier: -" + Conversions.ToString(num2) + "%");
					}
				}
				if (activeUnit_1.IsMissile)
				{
					num3 = Weapon.ModifierVsTargetSpeed((int)Math.Round(num3), ReferenceWeapon, activeUnit_1, stringBuilder);
				}
				if (activeUnit_1.IsAerospaceUnit)
				{
					Sensor theGuidingSensor = null;
					if (DirectorDBID != 0)
					{
						theGuidingSensor = scenario_0.Cache_GetSensor(DirectorDBID);
					}
					string feedbackMessage = "";
					float num4 = Module_Unit.AngleOffThisUnitsBoresight(this, activeUnit_1, DistinguishBetweenStarboardAndPort: false, ref feedbackMessage, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
					XSection xSection = Sensor.smethod_0(activeUnit_1, XSection._SignatureType.Radar_E_M);
					XSection xSection2 = Sensor.smethod_0(activeUnit_1, XSection._SignatureType.IR_Detect);
					float targetSignature_Radar_dbsm = default(float);
					float targetSignature_IR = default(float);
					if (!(num4 >= 315f) && num4 > 45f)
					{
						if ((num4 >= 45f && num4 <= 135f) || (num4 >= 225f && num4 <= 315f))
						{
							targetSignature_Radar_dbsm = xSection.get_Side(activeUnit_1);
							targetSignature_IR = xSection2.get_Side(activeUnit_1);
						}
						else if (num4 >= 135f && num4 <= 225f)
						{
							targetSignature_Radar_dbsm = xSection.get_Rear(activeUnit_1);
							targetSignature_IR = xSection2.get_Rear(activeUnit_1);
						}
					}
					else
					{
						targetSignature_Radar_dbsm = xSection.get_Front(activeUnit_1);
						targetSignature_IR = xSection2.get_Front(activeUnit_1);
					}
					num3 = Weapon.ModifierVsTargetSignature((int)Math.Round(num3), FiringParent, ReferenceWeapon, activeUnit_1, theGuidingSensor, targetSignature_Radar_dbsm, targetSignature_IR, stringBuilder);
				}
				if (activeUnit_1.IsMissile && Module_Unit.RangeToPoint_Horiz(this, geoPoint_0) <= 2f)
				{
					Weapon weapon = (Weapon)activeUnit_1;
					if (weapon.AI.PrimaryTarget != null && weapon.RangeToUnit_Horiz(weapon.AI.PrimaryTarget) < 2f)
					{
						if (weapon.Flags.TerminalManeuver_PopUp)
						{
							stringBuilder.Append("Target is missile with pop-up terminal manouver - hit probability reduced by 25%");
							num3 = (float)((double)num3 * 0.75);
						}
						else if (weapon.Flags.TerminalManeuver_ZigZag)
						{
							stringBuilder.Append("Target is missile with zig-zag terminal manouver - hit probability reduced by 33%");
							num3 = (float)((double)num3 * 0.66);
						}
						else if (weapon.Flags.TerminalManeuver_Random)
						{
							stringBuilder.Append("Target is missile with random terminal manouver - hit probability reduced by 50%");
							num3 = (float)((double)num3 * 0.5);
						}
					}
				}
				goto IL_06b6;
				IL_00aa:
				Weapon._WeaponType type = ReferenceWeapon.Type;
				if (type == Weapon._WeaponType.Gun)
				{
					stringBuilder.Append("Gun (" + UnitClass + ") is attacking " + activeUnit_1.Name + " with a base-Ph of " + Conversions.ToString(Math.Round(num, 1)) + "%. ");
				}
				else
				{
					stringBuilder.Append("Weapon: " + Name + " is attacking " + activeUnit_1.Name + " with a base-Ph of " + Conversions.ToString(Math.Round(num, 1)) + "%. ");
				}
				if (ReferenceWeapon.Type == Weapon._WeaponType.Laser || ReferenceWeapon.Type == Weapon._WeaponType.Microwave || ReferenceWeapon.Type == Weapon._WeaponType.LaserDazzler)
				{
					num3 = num;
					goto IL_06b6;
				}
				double num5 = Module_Unit.RangeToPoint_Slant(this, geoPoint_0);
				if (num5 > this.get_MaxRangeForThisTargetType(activeUnit_1) / 2.0)
				{
					double num6 = Math.Min(1.0, num5 / 2.0 / this.get_MaxRangeForThisTargetType(activeUnit_1));
					num -= (float)((double)(num / 2f) * num6);
				}
				stringBuilder.Append("Base-Ph adjusted for distance: " + Conversions.ToString(Math.Round(num, 1)) + "%. ");
				if (!activeUnit_1.IsAircraft)
				{
					num3 = num;
					goto IL_0447;
				}
				int num7;
				if (activeUnit_1.IsBeingDestroyed)
				{
					num7 = 1;
				}
				else
				{
					if (!activeUnit_1.IsMorituri)
					{
						if (((Aircraft)activeUnit_1).Crew > 0 && ((Aircraft)activeUnit_1).Agility_Nominal > 0f)
						{
							float num8 = ((Aircraft)activeUnit_1).Kinematics.get_ActualAgility(stringBuilder);
							string feedbackMessage = "";
							float num9 = Module_Unit.AngleOffThisUnitsBoresight(this, activeUnit_1, DistinguishBetweenStarboardAndPort: false, ref feedbackMessage, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
							if (!(num9 >= 345f) && num9 > 15f)
							{
								if ((num9 >= 15f && num9 <= 60f) || (num9 <= 345f && num9 >= 300f))
								{
									num8 = (float)((double)num8 * 0.7);
									stringBuilder.Append("Agility adjusted for forward-oblique impact effect: " + Conversions.ToString(Math.Round(num8, 1)));
								}
								else if ((num9 >= 60f && num9 <= 110f) || (num9 <= 300f && num9 >= 250f))
								{
									num8 = num8;
									stringBuilder.Append("High-deflection impact (no effect on agility). ");
								}
								else if ((num9 >= 110f && num9 <= 165f) || (num9 <= 250f && num9 >= 195f))
								{
									num8 = (float)((double)num8 * 0.85);
									stringBuilder.Append("Agility adjusted for rear-oblique impact effect: " + Conversions.ToString(Math.Round(num8, 1)));
								}
								else
								{
									num8 = (float)((double)num8 * 0.5);
									stringBuilder.Append("Agility adjusted for tail-on impact effect: " + Conversions.ToString(Math.Round(num8, 1)));
								}
							}
							else
							{
								num8 = (float)((double)num8 * 0.6);
								stringBuilder.Append("Agility adjusted for head-on impact effect: " + Conversions.ToString(Math.Round(num8, 1)));
							}
							num8 = (float)Math.Round(num8, 1);
							stringBuilder.Append("Final agility modifier: -" + Conversions.ToString((int)Math.Round(num8 * 10f)) + "%");
							num3 = num - num8 * 10f;
						}
						else
						{
							num3 = num;
						}
						goto IL_0447;
					}
					num7 = 1;
				}
				result = (byte)num7 != 0;
				goto end_IL_001e;
				IL_06b6:
				if ((Flags.Fuze_Proximity || Flags.Fuze_Combination) && activeUnit_1.IsAerospaceUnit)
				{
					Warhead.WarheadCaliber? warheadCaliber = Warheads.FirstOrDefault()?.Caliber;
					short? num10 = (short?)warheadCaliber;
					bool? flag3;
					bool? flag2 = (flag3 = ((!num10.HasValue) ? ((bool?)null) : new bool?(num10 == 2001)));
					bool? obj;
					bool? flag4;
					if (flag2.HasValue && flag3 == true)
					{
						obj = true;
					}
					else
					{
						num10 = (short?)warheadCaliber;
						flag2 = (flag4 = ((!num10.HasValue) ? ((bool?)null) : new bool?(num10 == 2002)));
						obj = ((!flag2.HasValue) ? ((bool?)null) : ((flag4 == true) | flag3));
					}
					bool? flag5 = obj;
					flag4 = obj;
					bool? obj2;
					bool? flag6;
					if (flag4.HasValue && flag5 == true)
					{
						obj2 = true;
					}
					else
					{
						num10 = (short?)warheadCaliber;
						flag4 = (flag6 = ((!num10.HasValue) ? ((bool?)null) : new bool?(num10 == 3001)));
						obj2 = ((!flag4.HasValue) ? ((bool?)null) : ((flag6 == true) | flag5));
					}
					bool? flag7 = obj2;
					flag6 = obj2;
					bool? obj3;
					bool? flag8;
					if (flag6.HasValue && flag7 == true)
					{
						obj3 = true;
					}
					else
					{
						num10 = (short?)warheadCaliber;
						flag6 = (flag8 = ((!num10.HasValue) ? ((bool?)null) : new bool?(num10 == 3002)));
						obj3 = ((!flag6.HasValue) ? ((bool?)null) : ((flag8 == true) | flag7));
					}
					flag8 = obj3;
					float num11;
					if (flag8 != true)
					{
						num10 = (short?)warheadCaliber;
						flag6 = (flag8 = ((!num10.HasValue) ? ((bool?)null) : new bool?(num10 == 2003)));
						bool? obj4;
						if (flag6.HasValue && flag8 == true)
						{
							obj4 = true;
						}
						else
						{
							num10 = (short?)warheadCaliber;
							flag6 = (flag7 = ((!num10.HasValue) ? ((bool?)null) : new bool?(num10 == 3003)));
							obj4 = ((!flag6.HasValue) ? ((bool?)null) : ((flag7 == true) | flag8));
						}
						flag7 = obj4;
						if (flag7 != true)
						{
							num10 = (short?)warheadCaliber;
							flag6 = (flag7 = ((!num10.HasValue) ? ((bool?)null) : new bool?(num10 == 2004)));
							bool? obj5;
							if (flag6.HasValue && flag7 == true)
							{
								obj5 = true;
							}
							else
							{
								num10 = (short?)warheadCaliber;
								flag6 = (flag8 = ((!num10.HasValue) ? ((bool?)null) : new bool?(num10 == 3004)));
								obj5 = ((!flag6.HasValue) ? ((bool?)null) : ((flag8 == true) | flag7));
							}
							flag8 = obj5;
							if (flag8 == true)
							{
								num11 = 3.5f;
							}
							else
							{
								num10 = (short?)warheadCaliber;
								flag6 = (flag8 = ((!num10.HasValue) ? ((bool?)null) : new bool?(num10 == 2005)));
								bool? obj6;
								if (flag6.HasValue && flag8 == true)
								{
									obj6 = true;
								}
								else
								{
									num10 = (short?)warheadCaliber;
									flag6 = (flag7 = ((!num10.HasValue) ? ((bool?)null) : new bool?(num10 == 3005)));
									obj6 = ((!flag6.HasValue) ? ((bool?)null) : ((flag7 == true) | flag8));
								}
								flag7 = obj6;
								if (flag7 == true)
								{
									num11 = 4f;
								}
								else
								{
									num10 = (short?)warheadCaliber;
									flag6 = (flag7 = ((!num10.HasValue) ? ((bool?)null) : new bool?(num10 == 2006)));
									bool? obj7;
									if (flag6.HasValue && flag7 == true)
									{
										obj7 = true;
									}
									else
									{
										num10 = (short?)warheadCaliber;
										flag6 = (flag8 = ((!num10.HasValue) ? ((bool?)null) : new bool?(num10 == 3006)));
										obj7 = ((!flag6.HasValue) ? ((bool?)null) : ((flag8 == true) | flag7));
									}
									flag8 = obj7;
									if (flag8 != true)
									{
										num10 = (short?)warheadCaliber;
										flag6 = (flag8 = ((!num10.HasValue) ? ((bool?)null) : new bool?(num10 == 2007)));
										bool? obj8;
										if (flag6.HasValue && flag8 == true)
										{
											obj8 = true;
										}
										else
										{
											num10 = (short?)warheadCaliber;
											flag6 = (flag7 = ((!num10.HasValue) ? ((bool?)null) : new bool?(num10 == 3007)));
											obj8 = ((!flag6.HasValue) ? ((bool?)null) : ((flag7 == true) | flag8));
										}
										flag7 = obj8;
										num11 = ((flag7 == true) ? 5f : 6f);
									}
									else
									{
										num11 = 4.5f;
									}
								}
							}
						}
						else
						{
							num11 = 2f;
						}
					}
					else
					{
						num11 = 1.5f;
					}
					num3 *= num11;
					string[] obj9 = new string[5] { "Proximity fuze (", null, null, null, null };
					Warhead? warhead = Warheads.FirstOrDefault();
					obj9[1] = ((warhead != null) ? Misc.ToEnglishString(warhead.Caliber) : null);
					obj9[2] = ") - Ph increased by ";
					obj9[3] = Conversions.ToString(num11);
					obj9[4] = "x. ";
					stringBuilder.Append(string.Concat(obj9));
					float num12 = Physics.ComputeMach(activeUnit_1.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), activeUnit_1.CurrentSpeed);
					if (num12 < 1f)
					{
						stringBuilder.Append("Target is subsonic - no alteration to effective flak hit probability. ");
					}
					else
					{
						num3 /= num12;
						stringBuilder.Append("Target is at Mach " + Conversions.ToString(Math.Round(num12, 2)) + "; effective flak hit probability reduced by same factor. ");
					}
				}
				if (num3 < 5f)
				{
					num3 = 5f;
				}
				if (num3 > 95f)
				{
					num3 = 95f;
				}
				if (!float.IsNaN(num3))
				{
					stringBuilder.Append("Final Ph: " + Conversions.ToString((int)Math.Round(num3)) + "% ");
				}
				float num13 = 0f;
				float num14 = 0f;
				int num15 = GameGeneral.GlobalRNG.Next(1, 101);
				if ((float)num15 <= num3)
				{
					stringBuilder.Append("Result: " + Conversions.ToString(num15) + " - HIT");
					flag = true;
				}
				else
				{
					stringBuilder.Append("Result: " + Conversions.ToString(num15) + " - MISS");
					if (Warheads.Length > 0 && activeUnit_1.IsFacility && Warheads[0].IsExplosive)
					{
						num13 = GameGeneral.GlobalRNG.Next(0, 359);
						num14 = GameGeneral.GlobalRNG.Next(1, 50);
						stringBuilder.Append(" (Near miss: " + Conversions.ToString(num14) + "m)");
						if (!string.IsNullOrEmpty(FiringParent_ID) && FiringParent == null)
						{
							ConcurrentObservableDictionary<string, ActiveUnit> activeUnits = ReferenceWeapon.ParentScen.ActiveUnits;
							string firingParent_ID = FiringParent_ID;
							ActiveUnit value = FiringParent;
							activeUnits.TryGetValue(firingParent_ID, out value);
							FiringParent = value;
						}
						ActiveUnit_Damage damage = activeUnit_1.Damage;
						Weapon referenceWeapon = ReferenceWeapon;
						GeoPoint launchPoint = geoPoint_0;
						float distanceFromImpact_meters = num14;
						float bearingFromImpact = num13;
						ActiveUnit firingParent = FiringParent;
						string feedbackMessage = "";
						damage.ResolveDamageFromWeapon(referenceWeapon, launchPoint, distanceFromImpact_meters, bearingFromImpact, firingParent, null, null, null, ref feedbackMessage, DirectHit: false, this);
					}
				}
				if (!flag)
				{
					_ = "Missed " + activeUnit_1.Name;
				}
				else
				{
					_ = "Impacted " + activeUnit_1.Name;
				}
				base.EndgameReport.AddEndGameMessage(flag, stringBuilder.ToString());
				if (flag)
				{
					ActiveUnit value;
					if (!string.IsNullOrEmpty(FiringParent_ID) && FiringParent == null)
					{
						ConcurrentObservableDictionary<string, ActiveUnit> activeUnits2 = ReferenceWeapon.ParentScen.ActiveUnits;
						string firingParent_ID2 = FiringParent_ID;
						value = FiringParent;
						activeUnits2.TryGetValue(firingParent_ID2, out value);
						FiringParent = value;
					}
					float float_ = num14;
					float float_2 = num13;
					value = FiringParent;
					string feedbackMessage = "";
					method_7(activeUnit_1, float_, float_2, ref value, null, null, null, ref feedbackMessage);
					FiringParent = value;
				}
				method_9(activeUnit_1, flag, activeUnit_1.IsMorituri, stringBuilder, scenario_0);
				StringBuilderCache.Free(stringBuilder);
				result = flag;
				end_IL_001e:;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100860", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				int num16;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
					num16 = 0;
				}
				else
				{
					num16 = 0;
				}
				result = (byte)num16 != 0;
				ProjectData.ClearProjectError();
			}
		}
		else
		{
			result = false;
		}
		return result;
	}

	public static double CalculateGunMuzzleVelocity_mpersec(Contact_Base.ContactType theTargetType, float theMaxRange, bool parabolicTrajectory)
	{
		double num = Math.Sqrt((double)(theMaxRange * 1852f) * 9.81 / Math.Sin(1.570796326794897));
		if (!parabolicTrajectory)
		{
			num *= 3.0;
		}
		if (!Information.IsNothing((object)theTargetType))
		{
			Contact_Base.ContactType contactType = theTargetType;
			if (contactType <= Contact_Base.ContactType.Missile)
			{
				num = Math.Max(990.0, num);
			}
		}
		return num;
	}

	internal int DBID()
	{
		return int_1;
	}

	internal bool Impact_CEP(ActiveUnit theTarget, Contact theContact, ref Scenario theScen, ref LockRandom theRNG, string theReason = "")
	{
		bool result;
		try
		{
			_Closure$__96-0 arg = default(_Closure$__96-0);
			_Closure$__96-0 CS$<>8__locals5 = new _Closure$__96-0(arg);
			CS$<>8__locals5.$VB$Me = this;
			theReason = $"Weapon {Name} involved in CEP weapon impact resolution with {theTarget.Name}";
			double num = default(double);
			if (!theTarget.IsShip && (!theTarget.IsSubmarine || !((Submarine)theTarget).IsSurfaced))
			{
				if (!(theTarget.IsFacility | theTarget.IsVehicle) && !theTarget.IsAggregatedUnit)
				{
					if ((theTarget.IsSubmarine && !((Submarine)theTarget).IsSurfaced) || theTarget.IsTorpedo)
					{
						num = SubPOK;
					}
				}
				else
				{
					num = LandPOK;
				}
			}
			else
			{
				num = SurfPOK;
			}
			if (Type == Weapon._WeaponType.DepthCharge || (Warheads[0].Type == Warhead.WarheadType.Weapon && Warheads[0].get_CarriedWeapon(theScen).Type == Weapon._WeaponType.DepthCharge))
			{
				if (CEP_Surface == 0f)
				{
					num = 99.0;
					CEP_Surface = 200f;
				}
				if (num < 85.0)
				{
					num = 85.0;
				}
			}
			bool flag = (double)theRNG.Next(1, 101) < num;
			string text = "";
			float num2 = (theTarget.IsFacility ? CEP_Land : CEP_Surface);
			if (theTarget.CurrentSpeed > 0f && theContact.Age > 0f)
			{
				if (theTarget.IsFacility)
				{
					_ = theContact.Age;
					_ = theTarget.CurrentSpeed;
				}
				else
				{
					_ = theContact.Age;
					_ = theTarget.CurrentSpeed;
				}
			}
			float bearing = theRNG.Next(0, 360);
			double num3 = theRNG.NextDouble();
			float num4 = ((num3 <= 0.5) ? ((float)((double)theRNG.Next(0, 101) / 100.0 * (double)num2)) : ((!(num3 < 0.937)) ? ((float)((double)(2f * num2) + (double)num2 * theRNG.NextDouble())) : ((float)((double)num2 + (double)num2 * theRNG.NextDouble()))));
			double out_lat = default(double);
			double out_lon = default(double);
			Mount mount = default(Mount);
			if (!Module_ActiveUnit.IsAimpointFacility(theTarget))
			{
				out_lat = ((Module_Unit.Unit)theContact).get_Latitude((GlobalVariables.BooleanObject)null);
				out_lon = ((Module_Unit.Unit)theContact).get_Longitude((GlobalVariables.BooleanObject)null);
			}
			else
			{
				mount = ((Facility)theTarget).PickRandomAimpoint();
				if (mount != null)
				{
					Geodesic_EdWilliams.CalcPoint_Williams(((Module_Unit.Unit)theContact).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theContact).get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, mount.AimpointOffset_Distance / 1852f, mount.AimpointOffset_Bearing);
				}
				else
				{
					out_lat = ((Module_Unit.Unit)theContact).get_Latitude((GlobalVariables.BooleanObject)null);
					out_lon = ((Module_Unit.Unit)theContact).get_Longitude((GlobalVariables.BooleanObject)null);
				}
			}
			CS$<>8__locals5.$VB$Local_ParentWS = this.get_ParentSalvo(theScen);
			WeaponSalvo.Shooter shooter = this.get_ParentSalvoShooter(theScen);
			string PreferredAimpoint = ((shooter == null) ? string.Empty : shooter.BombStickAimpointObjectID);
			if (CS$<>8__locals5.$VB$Local_ParentWS != null && shooter != null && (Type == Weapon._WeaponType.IronBomb || Type == Weapon._WeaponType.Rocket))
			{
				if (!shooter.BombStickTotalQty.HasValue)
				{
					shooter.BombStickTotalQty = theScen.UnguidedWeapons.Values.Where([SpecialName] (UnguidedWeapon theUW) => Operators.CompareString(theUW.FiringParent_ID, CS$<>8__locals5.$VB$Me.FiringParent_ID, false) == 0 && CS$<>8__locals5.$VB$Local_ParentWS.WeaponList.ContainsKey(theUW.ObjectID)).Count();
					if (!shooter.BombStickTotalQty.HasValue)
					{
						shooter.BombStickTotalQty = 1;
					}
				}
				int? bombStickTotalQty = shooter.BombStickTotalQty;
				if ((bombStickTotalQty.HasValue ? new bool?(bombStickTotalQty.GetValueOrDefault() < 2) : ((bool?)null)) == true)
				{
					double lon = out_lon;
					double lat = out_lat;
					double out_lon2 = ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null);
					double out_lat2 = ((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null);
					Geodesic_EdWilliams.CalcPoint_Williams(lon, lat, ref out_lon2, ref out_lat2, num4 / 1852f, bearing);
					((Module_Unit.Unit)this).set_Latitude((GlobalVariables.BooleanObject)null, out_lat2);
					((Module_Unit.Unit)this).set_Longitude((GlobalVariables.BooleanObject)null, out_lon2);
				}
				else
				{
					if (!shooter.BombStickIndexOfCenterShot.HasValue)
					{
						shooter.BombStickIndexOfCenterShot = RadarModel.Floor((double)shooter.BombStickTotalQty.Value / 2.0);
					}
					if (!shooter.BombStickDirection.HasValue)
					{
						shooter.BombStickDirection = CurrentHeading;
					}
					if (!shooter.BombStickLength.HasValue)
					{
						switch (Type)
						{
						default:
						{
							float num5 = 9f;
							break;
						}
						case Weapon._WeaponType.IronBomb:
						case Weapon._WeaponType.DepthCharge:
						{
							float num5 = 15.24f;
							break;
						}
						case Weapon._WeaponType.Rocket:
						case Weapon._WeaponType.Gun:
						{
							float num5 = 9.144f;
							break;
						}
						}
						if (!string.IsNullOrEmpty(FiringParent_ID) && FiringParent == null)
						{
							ConcurrentObservableDictionary<string, ActiveUnit> activeUnits = theScen.ActiveUnits;
							string firingParent_ID = FiringParent_ID;
							ActiveUnit value = FiringParent;
							activeUnits.TryGetValue(firingParent_ID, out value);
							FiringParent = value;
						}
						if (FiringParent != null && FiringParent.IsAircraft)
						{
							Aircraft._AircraftType type = ((Aircraft)FiringParent).Type;
							Weapon._WeaponType type2 = Type;
							float num5 = ((type2 != Weapon._WeaponType.IronBomb && type2 != Weapon._WeaponType.DepthCharge) ? 9.144f : ((type != Aircraft._AircraftType.Bomber) ? 15.24f : 22.86f));
							if (Type != Weapon._WeaponType.IronBomb && Type != Weapon._WeaponType.DepthCharge)
							{
								if (shooter.BombStickTotalQty.Value < 40)
								{
									shooter.BombStickLength = 30.48f;
								}
								else if (shooter.BombStickTotalQty.Value < 80)
								{
									shooter.BombStickLength = 60.96f;
								}
								else
								{
									shooter.BombStickLength = 91.44f;
								}
							}
							else if (type == Aircraft._AircraftType.Bomber)
							{
								if (shooter.BombStickTotalQty.Value < 28)
								{
									shooter.BombStickLength = (float)shooter.BombStickTotalQty.Value * num5;
								}
								else
								{
									shooter.BombStickLength = 609.60004f;
								}
							}
							else if (shooter.BombStickTotalQty.Value < 8)
							{
								shooter.BombStickLength = (float)shooter.BombStickTotalQty.Value * num5;
							}
							else if (shooter.BombStickTotalQty.Value < 25)
							{
								shooter.BombStickLength = 91.44f;
							}
							else
							{
								shooter.BombStickLength = 182.88f;
							}
						}
						else
						{
							shooter.BombStickLength = 91.44f;
						}
					}
					if (shooter.BombStickFirstWeaponDPI == null)
					{
						shooter.BombStickFirstWeaponDPI = new GeoPoint();
						shooter.BombStickFirstWeaponDPI.Latitude = out_lat;
						shooter.BombStickFirstWeaponDPI.Longitude = out_lon;
					}
					if (shooter.BombStickFirstWeaponActualPI == null)
					{
						shooter.BombStickFirstWeaponActualPI = new GeoPoint();
						double longitude = shooter.BombStickFirstWeaponDPI.Longitude;
						double latitude = shooter.BombStickFirstWeaponDPI.Latitude;
						GeoPoint bombStickFirstWeaponActualPI;
						double out_lat2 = (bombStickFirstWeaponActualPI = shooter.BombStickFirstWeaponActualPI).Longitude;
						GeoPoint bombStickFirstWeaponActualPI2;
						double out_lon2 = (bombStickFirstWeaponActualPI2 = shooter.BombStickFirstWeaponActualPI).Latitude;
						Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref out_lat2, ref out_lon2, num4 / 1852f, bearing);
						bombStickFirstWeaponActualPI2.Latitude = out_lon2;
						bombStickFirstWeaponActualPI.Longitude = out_lat2;
					}
					if (Type != Weapon._WeaponType.IronBomb && Type != Weapon._WeaponType.DepthCharge)
					{
						int num6 = shooter.BombStickTotalQty.Value - shooter.BombStickImpactedQty;
						shooter.BombStickImpactedQty++;
						bombStickTotalQty = shooter.BombStickIndexOfCenterShot;
						if (((!bombStickTotalQty.HasValue) ? ((bool?)null) : new bool?(bombStickTotalQty.GetValueOrDefault() == num6)) != true)
						{
							int num7 = num6;
							bombStickTotalQty = shooter.BombStickIndexOfCenterShot;
							if ((bombStickTotalQty.HasValue ? new bool?(num7 > bombStickTotalQty.GetValueOrDefault()) : ((bool?)null)) == true)
							{
								int num8 = num6 - shooter.BombStickIndexOfCenterShot.Value;
								float num9 = (shooter.BombStickLength / 2f / (float?)shooter.BombStickIndexOfCenterShot).Value;
								if (float.IsInfinity(num9) || float.IsNaN(num9))
								{
									num9 = 0f;
								}
								float num10 = (float)num8 * num9;
								Geodesic_EdWilliams.CalcPoint_Williams(shooter.BombStickFirstWeaponActualPI.Longitude, shooter.BombStickFirstWeaponActualPI.Latitude, ref out_lon, ref out_lat, num10 / 1852f, Math2.NormalizeBearing(shooter.BombStickDirection.Value + 180f));
							}
							else
							{
								int num11 = shooter.BombStickTotalQty.Value - (num6 + shooter.BombStickIndexOfCenterShot.Value);
								float num12 = (shooter.BombStickLength / 2f / (float?)(shooter.BombStickTotalQty.Value - 1 - shooter.BombStickIndexOfCenterShot)).Value;
								if (float.IsInfinity(num12) || float.IsNaN(num12))
								{
									num12 = 0f;
								}
								float num13 = (float)num11 * num12;
								Geodesic_EdWilliams.CalcPoint_Williams(shooter.BombStickFirstWeaponActualPI.Longitude, shooter.BombStickFirstWeaponActualPI.Latitude, ref out_lon, ref out_lat, num13 / 1852f, Math2.NormalizeBearing(shooter.BombStickDirection.Value));
							}
						}
						else
						{
							out_lat = shooter.BombStickFirstWeaponActualPI.Latitude;
							out_lon = shooter.BombStickFirstWeaponActualPI.Longitude;
						}
						if (theRNG.Next(1, 4) > 1)
						{
							float num14 = theRNG.Next(0, 8);
							double lon2 = out_lon;
							double lat2 = out_lat;
							double out_lon2 = ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null);
							double out_lat2 = ((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null);
							Geodesic_EdWilliams.CalcPoint_Williams(lon2, lat2, ref out_lon2, ref out_lat2, num14 / 1852f, bearing);
							((Module_Unit.Unit)this).set_Latitude((GlobalVariables.BooleanObject)null, out_lat2);
							((Module_Unit.Unit)this).set_Longitude((GlobalVariables.BooleanObject)null, out_lon2);
						}
						else
						{
							float num15 = theRNG.Next(7, 16);
							double lon3 = out_lon;
							double lat3 = out_lat;
							double out_lat2 = ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null);
							double out_lon2 = ((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null);
							Geodesic_EdWilliams.CalcPoint_Williams(lon3, lat3, ref out_lat2, ref out_lon2, num15 / 1852f, bearing);
							((Module_Unit.Unit)this).set_Latitude((GlobalVariables.BooleanObject)null, out_lon2);
							((Module_Unit.Unit)this).set_Longitude((GlobalVariables.BooleanObject)null, out_lat2);
						}
						num4 = shooter.BombStickFirstWeaponDPI.RangeToPoint_Horiz(((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null)) * 1852f;
					}
					else
					{
						int num16 = shooter.BombStickTotalQty.Value - shooter.BombStickImpactedQty;
						shooter.BombStickImpactedQty++;
						bombStickTotalQty = shooter.BombStickIndexOfCenterShot;
						if ((bombStickTotalQty.HasValue ? new bool?(bombStickTotalQty.GetValueOrDefault() == num16) : ((bool?)null)) != true)
						{
							int num7 = num16;
							bombStickTotalQty = shooter.BombStickIndexOfCenterShot;
							if ((bombStickTotalQty.HasValue ? new bool?(num7 > bombStickTotalQty.GetValueOrDefault()) : ((bool?)null)) == true)
							{
								int num17 = num16 - shooter.BombStickIndexOfCenterShot.Value;
								float num18 = (shooter.BombStickLength / 2f / (float?)shooter.BombStickIndexOfCenterShot).Value;
								if (float.IsInfinity(num18) || float.IsNaN(num18))
								{
									num18 = 0f;
								}
								float num19 = (float)num17 * num18;
								Geodesic_EdWilliams.CalcPoint_Williams(shooter.BombStickFirstWeaponActualPI.Longitude, shooter.BombStickFirstWeaponActualPI.Latitude, ref out_lon, ref out_lat, num19 / 1852f, Math2.NormalizeBearing(shooter.BombStickDirection.Value + 180f));
								float num20 = theRNG.Next(0, (int)Math.Round(num18));
								double lon4 = out_lon;
								double lat4 = out_lat;
								double out_lon2 = ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null);
								double out_lat2 = ((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null);
								Geodesic_EdWilliams.CalcPoint_Williams(lon4, lat4, ref out_lon2, ref out_lat2, num20 / 1852f, bearing);
								((Module_Unit.Unit)this).set_Latitude((GlobalVariables.BooleanObject)null, out_lat2);
								((Module_Unit.Unit)this).set_Longitude((GlobalVariables.BooleanObject)null, out_lon2);
								num4 = shooter.BombStickFirstWeaponDPI.RangeToPoint_Horiz(((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null)) * 1852f;
							}
							else
							{
								int num21 = shooter.BombStickTotalQty.Value - (num16 + shooter.BombStickIndexOfCenterShot.Value);
								float num22 = (shooter.BombStickLength / 2f / (float?)(shooter.BombStickTotalQty.Value - 1 - shooter.BombStickIndexOfCenterShot)).Value;
								if (float.IsInfinity(num22) || float.IsNaN(num22))
								{
									num22 = 0f;
								}
								float num23 = (float)num21 * num22;
								Geodesic_EdWilliams.CalcPoint_Williams(shooter.BombStickFirstWeaponActualPI.Longitude, shooter.BombStickFirstWeaponActualPI.Latitude, ref out_lon, ref out_lat, num23 / 1852f, Math2.NormalizeBearing(shooter.BombStickDirection.Value));
								float num24 = theRNG.Next(0, (int)Math.Round(num22));
								double lon5 = out_lon;
								double lat5 = out_lat;
								double out_lat2 = ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null);
								double out_lon2 = ((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null);
								Geodesic_EdWilliams.CalcPoint_Williams(lon5, lat5, ref out_lat2, ref out_lon2, num24 / 1852f, bearing);
								((Module_Unit.Unit)this).set_Latitude((GlobalVariables.BooleanObject)null, out_lon2);
								((Module_Unit.Unit)this).set_Longitude((GlobalVariables.BooleanObject)null, out_lat2);
								num4 = shooter.BombStickFirstWeaponDPI.RangeToPoint_Horiz(((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null)) * 1852f;
							}
						}
						else
						{
							((Module_Unit.Unit)this).set_Latitude((GlobalVariables.BooleanObject)null, shooter.BombStickFirstWeaponActualPI.Latitude);
							((Module_Unit.Unit)this).set_Longitude((GlobalVariables.BooleanObject)null, shooter.BombStickFirstWeaponActualPI.Longitude);
							num4 = shooter.BombStickFirstWeaponDPI.RangeToPoint_Horiz(((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null)) * 1852f;
						}
					}
				}
			}
			else if (num2 > 0f)
			{
				double lon6 = out_lon;
				double lat6 = out_lat;
				double out_lon2 = ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null);
				double out_lat2 = ((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null);
				Geodesic_EdWilliams.CalcPoint_Williams(lon6, lat6, ref out_lon2, ref out_lat2, num4 / 1852f, bearing);
				((Module_Unit.Unit)this).set_Latitude((GlobalVariables.BooleanObject)null, out_lat2);
				((Module_Unit.Unit)this).set_Longitude((GlobalVariables.BooleanObject)null, out_lon2);
			}
			else
			{
				((Module_Unit.Unit)this).set_Latitude((GlobalVariables.BooleanObject)null, out_lat);
				((Module_Unit.Unit)this).set_Longitude((GlobalVariables.BooleanObject)null, out_lon);
			}
			ClearElevationAndAltitudeAGL();
			if (!IsTorpedo)
			{
				if (Type != Weapon._WeaponType.DepthCharge && (Warheads[0].Type != Warhead.WarheadType.Weapon || Warheads[0].get_CarriedWeapon(theScen).Type != Weapon._WeaponType.DepthCharge))
				{
					((Module_Unit.Unit)this).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)Math.Max(0, (int)Terrain.GetElevation(((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, theScen)));
				}
				else
				{
					((Module_Unit.Unit)this).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)Math.Max(-100.0, (double)Terrain.GetElevation(((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, theScen) / 2.0));
				}
			}
			ImpactAltitude = ((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			float num25 = (float)((double)Math2.CalcDist(((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), theTarget.get_Latitude((GlobalVariables.BooleanObject)null), theTarget.get_Longitude((GlobalVariables.BooleanObject)null)) * 1852.0);
			if (mount != null && mount.AimpointOffset_Distance > 0f)
			{
				num25 = Math.Abs(num25 - mount.AimpointOffset_Distance);
			}
			float num26 = Module_Unit.BearingToPoint_True(theTarget, ((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null));
			bool flag2;
			if (flag2 = Weapon.CheckForDirectHit(theTarget, ((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), num25, geoPoint_0, ReferenceWeapon.MaxRange_NoTargetType, IsUnguidedWeapon: true))
			{
				Weapon.RaiseEvent_WeaponImpact(theScen, ReferenceWeapon, theContact, DirectHit: false);
				num25 = 0f;
			}
			if (Warheads.Length > 0 && Warheads[0].IsCluster)
			{
				int num27;
				if (!flag)
				{
					base.EndgameReport.AddEndGameMessage(hit: false, "Has malfunctioned");
					theScen.DestroyThisUnguidedWeapon(this, "Has malfunctioned", "Malfunction");
					num27 = 1;
				}
				else
				{
					Warhead[] warheads = Warheads;
					foreach (Warhead warhead in warheads)
					{
						if (warhead.IsCluster)
						{
							new Explosion(ref theScen, this, ref Target, ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), CurrentHeading, ((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), Type, warhead.DP, warhead.DP, warhead.Type, warhead.ExplosivesType, null, null, null, null, null, warhead.ClusterBombDispersionAreaLength, warhead.ClusterBombDispersionAreaWidth, warhead.NumberOfWarheads).CurrentHeading = CurrentHeading;
						}
					}
					num27 = 1;
				}
				flag2 = (byte)num27 != 0;
			}
			bool flag3;
			if (!Warheads[0].IsExplosive && (Warheads[0].Type != Warhead.WarheadType.Weapon || !Warheads[0].get_CarriedWeapon(theScen).Warheads[0].IsExplosive) && !Warheads[0].IsIncendiary && (Warheads[0].Type != Warhead.WarheadType.Weapon || !Warheads[0].get_CarriedWeapon(theScen).Warheads[0].IsIncendiary))
			{
				if (!flag2)
				{
					if (num25 < 926f)
					{
						text = (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet ? ("Missed " + theTarget.Name + " by " + Conversions.ToString(Math.Max(1, (int)Math.Round(num25 * 3.28084f))) + "ft") : ("Missed " + theTarget.Name + " by " + Conversions.ToString(Math.Max(1, (int)Math.Round(num25))) + "m"));
						base.EndgameReport.AddEndGameMessage(hit: false, text);
					}
					else
					{
						text = "Missed " + theTarget.Name + " by " + Conversions.ToString(Math.Round(num25 / 1852f, 1)) + "nm";
						base.EndgameReport.AddEndGameMessage(hit: false, text);
					}
				}
				else
				{
					ActiveUnit value;
					if (!string.IsNullOrEmpty(FiringParent_ID) && Information.IsNothing((object)FiringParent))
					{
						ConcurrentObservableDictionary<string, ActiveUnit> activeUnits2 = theScen.ActiveUnits;
						string firingParent_ID2 = FiringParent_ID;
						value = FiringParent;
						activeUnits2.TryGetValue(firingParent_ID2, out value);
						FiringParent = value;
					}
					float float_ = num25;
					value = FiringParent;
					method_7(theTarget, float_, num26, ref value, null, null, null, ref PreferredAimpoint);
					FiringParent = value;
					if (!Information.IsNothing((object)shooter) && !Information.IsNothing((object)shooter.BombStickTotalQty) && !Information.IsNothing((object)shooter.BombStickImpactedQty) && !string.IsNullOrEmpty(PreferredAimpoint) && !Information.IsNothing((object)shooter))
					{
						shooter.BombStickAimpointObjectID = PreferredAimpoint;
					}
				}
			}
			else
			{
				if (flag)
				{
					Weapon.RaiseEvent_WeaponImpact(theScen, ReferenceWeapon, theContact, DirectHit: false);
					if (flag2)
					{
						ActiveUnit value;
						if (!string.IsNullOrEmpty(FiringParent_ID) && FiringParent == null)
						{
							ConcurrentObservableDictionary<string, ActiveUnit> activeUnits3 = theScen.ActiveUnits;
							string firingParent_ID3 = FiringParent_ID;
							value = FiringParent;
							activeUnits3.TryGetValue(firingParent_ID3, out value);
							FiringParent = value;
						}
						float float_2 = num25;
						value = FiringParent;
						method_7(theTarget, float_2, num26, ref value, ((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), null, ref PreferredAimpoint);
						FiringParent = value;
						goto IL_1904;
					}
					if (!Module_ActiveUnit.IsAimpointFacility(theTarget))
					{
						if (!Warheads[0].get_IsAirburst(ReferenceWeapon, theTarget))
						{
							if ((double)num25 < 926.0)
							{
								text = ((!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet) ? ("Missed " + theTarget.Name + " by " + Conversions.ToString(Math.Max(1, (int)Math.Round(num25))) + "m") : ("Missed " + theTarget.Name + " by " + Conversions.ToString(Math.Max(1, (int)Math.Round(num25 * 3.28084f))) + "ft"));
								base.EndgameReport.AddEndGameMessage(hit: false, text);
							}
							else
							{
								text = "Missed " + theTarget.Name + " by " + Conversions.ToString(Math.Round(num25 / 1852f, 1)) + "nm";
								base.EndgameReport.AddEndGameMessage(hit: false, text);
							}
						}
						else
						{
							double num28 = Math.Sqrt(Math.Pow(Math.Abs(((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - theTarget.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)), 2.0) + Math.Pow(num25, 2.0));
							string text2 = " Airbursted off ";
							if (IsUnderwater || IsUnderground || CurrentAltitude_AGL == 0f)
							{
								text2 = " Missed ";
							}
							text = (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet ? (text2 + theTarget.Name + " by " + Conversions.ToString(Math.Max(1, (int)Math.Round(num28 * 3.2808399200439453))) + "ft") : (text2 + theTarget.Name + " by " + Conversions.ToString(Math.Max(1, (int)Math.Round(num28))) + "m"));
							base.EndgameReport.AddEndGameMessage(hit: false, text);
						}
					}
					if (!(((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) >= 0f))
					{
						goto IL_17a3;
					}
					int num29;
					if (!Module_Unit.IsOverLand(this) && Type != Weapon._WeaponType.IronBomb && Type != Weapon._WeaponType.GuidedWeapon && Type != Weapon._WeaponType.Gun)
					{
						if (Type != Weapon._WeaponType.Rocket)
						{
							goto IL_17a3;
						}
						num29 = 1;
					}
					else
					{
						num29 = 1;
					}
					flag3 = (byte)num29 != 0;
					goto IL_1819;
				}
				base.EndgameReport.AddEndGameMessage(hit: false, "Has malfunctioned");
				theScen.DestroyThisUnguidedWeapon(this, "Has malfunctioned", "Malfunction");
			}
			goto IL_194e;
			IL_1819:
			if (flag3)
			{
				if (!string.IsNullOrEmpty(FiringParent_ID) && Information.IsNothing((object)FiringParent))
				{
					ConcurrentObservableDictionary<string, ActiveUnit> activeUnits4 = theScen.ActiveUnits;
					string firingParent_ID4 = FiringParent_ID;
					ActiveUnit value = FiringParent;
					activeUnits4.TryGetValue(firingParent_ID4, out value);
					FiringParent = value;
				}
				if (Type == Weapon._WeaponType.DepthCharge)
				{
					theTarget.Damage.ResolveDamageFromWeapon(ReferenceWeapon, geoPoint_0, num25, num26, FiringParent, ((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), theTarget.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ref PreferredAimpoint, flag2, this);
				}
				else
				{
					theTarget.Damage.ResolveDamageFromWeapon(ReferenceWeapon, geoPoint_0, num25, num26, FiringParent, ((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ref PreferredAimpoint, flag2, this);
				}
			}
			goto IL_1904;
			IL_1904:
			if (!Information.IsNothing((object)shooter) && !Information.IsNothing((object)shooter.BombStickTotalQty) && !Information.IsNothing((object)shooter.BombStickImpactedQty) && !string.IsNullOrEmpty(PreferredAimpoint) && !Information.IsNothing((object)shooter))
			{
				shooter.BombStickAimpointObjectID = PreferredAimpoint;
			}
			goto IL_194e;
			IL_194e:
			result = flag2;
			goto end_IL_0001;
			IL_17a3:
			int num30;
			if (Warheads[0].get_IsNuclear(theScen))
			{
				num30 = 1;
			}
			else
			{
				if (!IsTorpedo && Type != Weapon._WeaponType.DepthCharge && (Warheads[0].Type != Warhead.WarheadType.Weapon || Warheads[0].get_CarriedWeapon(theScen).Type != Weapon._WeaponType.DepthCharge) && !Warheads[0].get_IsAirburst(ReferenceWeapon, theTarget))
				{
					flag3 = false;
					goto IL_1819;
				}
				num30 = 1;
			}
			flag3 = (byte)num30 != 0;
			goto IL_1819;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100862", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num31;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num31 = 0;
			}
			else
			{
				num31 = 0;
			}
			result = (byte)num31 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void method_7(ActiveUnit activeUnit_1, float float_9, float float_10, ref ActiveUnit activeUnit_2, double? nullable_10, double? nullable_11, float? nullable_12, ref string string_1)
	{
		try
		{
			if (!ReferenceWeapon.IsDecoy)
			{
				Weapon.RaiseEvent_WeaponImpact(ReferenceWeapon.ParentScen, ReferenceWeapon, activeUnit_1, DirectHit: true);
				new WeaponImpact(ref activeUnit_1.ParentScen, activeUnit_1.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit_1.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit_1.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), WeaponImpact.ImpactType.Kinetic, int_1);
			}
			if (!activeUnit_1.IsAircraft && !activeUnit_1.IsWeapon)
			{
				if (activeUnit_1.IsFacility)
				{
					if (!((Facility)activeUnit_1).HasAimpoints)
					{
						base.EndgameReport.AddEndGameMessage(hit: true, "Has impacted " + activeUnit_1.Name);
					}
				}
				else
				{
					base.EndgameReport.AddEndGameMessage(hit: true, "Has impacted " + activeUnit_1.Name);
				}
			}
			if (!string.IsNullOrEmpty(FiringParent_ID) && activeUnit_2 == null)
			{
				ReferenceWeapon.ParentScen.ActiveUnits.TryGetValue(FiringParent_ID, out activeUnit_2);
			}
			ReferenceWeapon.FiringParent = FiringParent;
			activeUnit_1.Damage.ResolveDamageFromWeapon(ReferenceWeapon, geoPoint_0, float_9, float_10, activeUnit_2, nullable_10, nullable_11, nullable_12, ref string_1, DirectHit: true, this);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100863", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_8()
	{
		double? num = ActiveUnit_Navigator.CalculateInterceptHeading(((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), CurrentHeading, Target, CurrentSpeed);
		if (!num.HasValue)
		{
			(Geopoint_Struct, TimeSpan) tuple = ActiveUnit_Navigator.ComputeInterceptPoint_BruteForce(this, CurrentSpeed, Target);
			if (!tuple.Item1.HasZeroCoords)
			{
				num = Module_Unit.BearingToPoint_True(this, tuple.Item1.Latitude, tuple.Item1.Longitude);
			}
		}
		if (!num.HasValue)
		{
			CurrentHeading = Math2.CalcAzimuth(((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)Target).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)Target).get_Longitude((GlobalVariables.BooleanObject)null));
		}
		else
		{
			CurrentHeading = (float)num.Value;
		}
	}

	private void method_9(ActiveUnit activeUnit_1, bool bool_1, bool bool_2, StringBuilder stringBuilder_0, Scenario scenario_0)
	{
		try
		{
			IEventExporter[] applicableEventExporters = scenario_0.ApplicableEventExporters;
			foreach (IEventExporter eventExporter in applicableEventExporters)
			{
				if (!eventExporter.IsOperating || !eventExporter.ExportWeaponEndgame)
				{
					continue;
				}
				PooledDictionary<string, IEventExporter.EventNotificationParameter> pooledDictionary = new PooledDictionary<string, IEventExporter.EventNotificationParameter>(30, ClearMode.Always);
				if (scenario_0.MonteCarloIteration > 0)
				{
					pooledDictionary.Add("Scenario", new IEventExporter.EventNotificationParameter(scenario_0.Title, typeof(string), 500));
					pooledDictionary.Add("MC_Run", new IEventExporter.EventNotificationParameter(scenario_0.MonteCarloIteration, typeof(int)));
				}
				pooledDictionary.Add("TimelineID", new IEventExporter.EventNotificationParameter(scenario_0.TimelineID, typeof(string), 40));
				if (!eventExporter.UseZeroHour)
				{
					pooledDictionary.Add("Time", new IEventExporter.EventNotificationParameter(scenario_0.Time.ToString("MM/dd/yyyy HH:mm:ss") + "." + scenario_0.Time.Millisecond.ToString("D3"), typeof(DateTime)));
				}
				else
				{
					pooledDictionary.Add("Time", new IEventExporter.EventNotificationParameter(scenario_0.Time.Subtract(scenario_0.ZeroHour).ToString("c"), typeof(TimeSpan), 30));
				}
				pooledDictionary.Add("WeaponID", new IEventExporter.EventNotificationParameter(ObjectID, typeof(string), 40));
				pooledDictionary.Add("WeaponName", new IEventExporter.EventNotificationParameter(Name, typeof(string), 500));
				pooledDictionary.Add("WeaponSide", new IEventExporter.EventNotificationParameter(this.get_UnitSide(SetSideOnly: false).Name, typeof(string), 500));
				if (Information.IsNothing((object)FiringParent))
				{
					pooledDictionary.Add("ParentFiringUnitID", new IEventExporter.EventNotificationParameter("-", typeof(string), 40));
					pooledDictionary.Add("ParentFiringUnitName", new IEventExporter.EventNotificationParameter("-", typeof(string), 500));
				}
				else
				{
					pooledDictionary.Add("ParentFiringUnitID", new IEventExporter.EventNotificationParameter(FiringParent.ObjectID, typeof(string), 40));
					pooledDictionary.Add("ParentFiringUnitName", new IEventExporter.EventNotificationParameter(FiringParent.Name, typeof(string), 500));
				}
				pooledDictionary.Add("TargetID", new IEventExporter.EventNotificationParameter(activeUnit_1.ObjectID, typeof(string), 40));
				pooledDictionary.Add("TargetName", new IEventExporter.EventNotificationParameter(activeUnit_1.Name, typeof(string), 500));
				pooledDictionary.Add("TargetSide", new IEventExporter.EventNotificationParameter(activeUnit_1.get_UnitSide(SetSideOnly: false).Name, typeof(string), 500));
				pooledDictionary.Add("TargetLongitude", new IEventExporter.EventNotificationParameter(activeUnit_1.get_Longitude((GlobalVariables.BooleanObject)null), typeof(double)));
				pooledDictionary.Add("TargetLatitude", new IEventExporter.EventNotificationParameter(activeUnit_1.get_Latitude((GlobalVariables.BooleanObject)null), typeof(double)));
				pooledDictionary.Add("TargetAltitude_ASL_m", new IEventExporter.EventNotificationParameter(activeUnit_1.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), typeof(float)));
				pooledDictionary.Add("TargetAltitude_AGL_m", new IEventExporter.EventNotificationParameter(activeUnit_1.CurrentAltitude_AGL, typeof(float)));
				pooledDictionary.Add("DistanceFromFiringUnit_Horiz", new IEventExporter.EventNotificationParameter(Conversions.ToString(Interaction.IIf(!Information.IsNothing((object)FiringParent), (object)RangeToUnit_Horiz(FiringParent), (object)"")), typeof(float)));
				if (bool_1)
				{
					if (bool_2)
					{
						pooledDictionary.Add("Result", new IEventExporter.EventNotificationParameter("KILL", typeof(string), 10));
					}
					else
					{
						pooledDictionary.Add("Result", new IEventExporter.EventNotificationParameter("HIT", typeof(string), 10));
					}
				}
				else
				{
					pooledDictionary.Add("Result", new IEventExporter.EventNotificationParameter("MISS", typeof(string), 10));
				}
				if (!Information.IsNothing((object)stringBuilder_0))
				{
					pooledDictionary.Add("EndgameMessage", new IEventExporter.EventNotificationParameter(stringBuilder_0.ToString(), typeof(string)));
				}
				else
				{
					pooledDictionary.Add("EndgameMessage", new IEventExporter.EventNotificationParameter("-", typeof(string)));
				}
				eventExporter.ExportEvent(IEventExporter.ExportedEventType.WeaponEndgame, pooledDictionary, activeUnit_1.ParentScen);
			}
			ISimConnector[] activeSimConnectors = SimConnect_General.ActiveSimConnectors;
			foreach (ISimConnector simConnector in activeSimConnectors)
			{
				if (!simConnector.ExportWeaponImpactOrDetonation)
				{
					continue;
				}
				Dictionary<string, (Type, string)> dictionary = new Dictionary<string, (Type, string)>();
				dictionary.Add("TimelineID", (typeof(string), scenario_0.TimelineID));
				dictionary.Add("Time", (typeof(DateTime), scenario_0.Time.ToString("MM/dd/yyyy HH:mm:ss") + "." + scenario_0.Time.Millisecond.ToString("D3")));
				dictionary.Add("Longitude", (typeof(double), Conversions.ToString(((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null))));
				dictionary.Add("Latitude", (typeof(double), Conversions.ToString(((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null))));
				dictionary.Add("Altitude", (typeof(float), Conversions.ToString(activeUnit_1.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))));
				dictionary.Add("WeaponID", (typeof(string), ObjectID));
				dictionary.Add("WeaponDBID", (typeof(string), Conversions.ToString(DBID())));
				dictionary.Add("WeaponCourse", (typeof(string), CurrentHeading.ToString()));
				dictionary.Add("WeaponSpeed_Horiz", (typeof(string), Module_Unit.CurrentSpeed_Horizontal(this).ToString()));
				dictionary.Add("WeaponSpeed_Vert", (typeof(string), Module_Unit.CurrentSpeed_Vertical(this, scenario_0).ToString()));
				if (!Information.IsNothing((object)FiringParent))
				{
					dictionary.Add("FiringUnitID", (typeof(string), FiringParent.ObjectID));
				}
				if (!Information.IsNothing((object)activeUnit_1))
				{
					dictionary.Add("TargetID", (typeof(string), activeUnit_1.ObjectID));
				}
				if (bool_1)
				{
					if (bool_2)
					{
						dictionary.Add("Result", (typeof(string), "KILL"));
					}
					else
					{
						dictionary.Add("Result", (typeof(string), "HIT"));
					}
				}
				else
				{
					dictionary.Add("Result", (typeof(string), "MISS"));
				}
				dictionary.Add("EventType", (typeof(string), "WeaponImpact"));
				simConnector.ExportInfo(ISimConnector.ExportedInfoType.WeaponImpactOrDetonation, dictionary, scenario_0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101329", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ExportLocationEvent(Scenario theScen, string ForceUpdateReason = null)
	{
		if (bool_0 && Debugger.IsAttached)
		{
			Debugger.Break();
		}
		try
		{
			bool flag = ForceUpdateReason != null;
			IEventExporter[] applicableEventExporters = theScen.ApplicableEventExporters;
			foreach (IEventExporter eventExporter in applicableEventExporters)
			{
				if (!eventExporter.IsOperating || !eventExporter.ExportUnitPositions || (!flag && !eventExporter.Common.LocationExportPossibleThisTick(theScen, this)))
				{
					continue;
				}
				bool_0 = true;
				if (this.get_UnitSide(SetSideOnly: false) != null || !eventExporter.Common.LocationExportPossibleThisTick(theScen, this))
				{
					PooledDictionary<string, IEventExporter.EventNotificationParameter> pooledDictionary = new PooledDictionary<string, IEventExporter.EventNotificationParameter>(30, ClearMode.Always);
					if (theScen.MonteCarloIteration > 0)
					{
						pooledDictionary.Add("Scenario", new IEventExporter.EventNotificationParameter(theScen.Title, typeof(string), 500));
						pooledDictionary.Add("MC_Run", new IEventExporter.EventNotificationParameter(theScen.MonteCarloIteration, typeof(int)));
					}
					pooledDictionary.Add("TimelineID", new IEventExporter.EventNotificationParameter(theScen.TimelineID, typeof(string), 40));
					if (!eventExporter.UseZeroHour)
					{
						pooledDictionary.Add("Time", new IEventExporter.EventNotificationParameter(theScen.Time.ToString("MM/dd/yyyy HH:mm:ss") + "." + theScen.Time.Millisecond.ToString("D3"), typeof(DateTime)));
					}
					else
					{
						pooledDictionary.Add("Time", new IEventExporter.EventNotificationParameter(theScen.Time.Subtract(theScen.ZeroHour).ToString("c"), typeof(TimeSpan), 30));
					}
					if (!flag)
					{
						pooledDictionary.Add("OutOfSequenceReason", new IEventExporter.EventNotificationParameter("-", typeof(string)));
					}
					else
					{
						pooledDictionary.Add("OutOfSequenceReason", new IEventExporter.EventNotificationParameter(ForceUpdateReason, typeof(string)));
					}
					pooledDictionary.Add("UnitID", new IEventExporter.EventNotificationParameter(ObjectID, typeof(string), 40));
					pooledDictionary.Add("UnitDBID", new IEventExporter.EventNotificationParameter(int_1, typeof(string), 10));
					pooledDictionary.Add("UnitName", new IEventExporter.EventNotificationParameter(Name, typeof(string), 500));
					pooledDictionary.Add("UnitType", new IEventExporter.EventNotificationParameter(ReferenceWeapon.UnitType_String, typeof(string), 20));
					pooledDictionary.Add("UnitClass", new IEventExporter.EventNotificationParameter(UnitClass, typeof(string), 500));
					pooledDictionary.Add("UnitSide", new IEventExporter.EventNotificationParameter(this.get_UnitSide(SetSideOnly: false).Name, typeof(string), 500));
					pooledDictionary.Add("UnitLongitude", new IEventExporter.EventNotificationParameter(((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), typeof(double)));
					pooledDictionary.Add("UnitLatitude", new IEventExporter.EventNotificationParameter(((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), typeof(double)));
					pooledDictionary.Add("UnitCourse", new IEventExporter.EventNotificationParameter(CurrentHeading, typeof(float)));
					pooledDictionary.Add("UnitSpeed_kts", new IEventExporter.EventNotificationParameter(CurrentSpeed, typeof(float)));
					pooledDictionary.Add("UnitAltitude_m", new IEventExporter.EventNotificationParameter(((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), typeof(float)));
					pooledDictionary.Add("UnitAttitude_Pitch", new IEventExporter.EventNotificationParameter(Attitude_Pitch, typeof(float)));
					pooledDictionary.Add("UnitAttitude_Roll", new IEventExporter.EventNotificationParameter(Attitude_Roll, typeof(float)));
					eventExporter.ExportEvent(IEventExporter.ExportedEventType.UnitPositions, pooledDictionary, theScen);
					eventExporter.Common.ApplyLastExportLocation(this);
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		finally
		{
			bool_0 = false;
		}
	}

	public void SimulateMovement(Scenario theScen, float elapsedTime)
	{
		if (Target != null && !IsMine && Type != Weapon._WeaponType.Laser && Type != Weapon._WeaponType.Microwave && Type != Weapon._WeaponType.LaserDazzler)
		{
			method_3(theScen, elapsedTime);
		}
	}

	public bool HasIdenticalState(UnguidedWeapon otherWeapon)
	{
		if (otherWeapon == null)
		{
			return false;
		}
		if (DBID() == otherWeapon.DBID() && _UnitSide == otherWeapon._UnitSide && activeUnit_0 == otherWeapon.activeUnit_0 && Target == otherWeapon.Target && CurrentSpeed == otherWeapon.CurrentSpeed && CurrentHeading == otherWeapon.CurrentHeading && _Latitude == otherWeapon._Latitude && _Longitude == otherWeapon._Longitude && ((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) == ((Module_Unit.Unit)otherWeapon).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))
		{
			return true;
		}
		return false;
	}

	static UnguidedWeapon()
	{
		Class72.smethod_20();
	}
}
