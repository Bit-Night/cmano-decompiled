using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Facility_Damage : ActiveUnit_Damage
{
	[Serializable]
	[CompilerGenerated]
	internal new sealed class _Closure$__
	{
		public static readonly _Closure$__ $I;

		public static Func<AirFacility, bool> $I6-0;

		public static Func<AirFacility, bool> $I6-1;

		public static Func<Mount, bool> $I7-0;

		public static Func<Mount, bool> $I7-1;

		public static Func<Mount, bool> $I8-0;

		public static Func<Mount, bool> $I8-2;

		public static Func<Mount, bool> $I8-3;

		static _Closure$__()
		{
			Class72.smethod_20();
			$I = new _Closure$__();
		}

		[SpecialName]
		internal bool _Lambda$__6-0(AirFacility AF)
		{
			return AF.IsOpenAirFacility;
		}

		[SpecialName]
		internal bool _Lambda$__6-1(AirFacility AF)
		{
			return AF.IsOpenAirFacility;
		}

		[SpecialName]
		internal bool _Lambda$__7-0(Mount theM)
		{
			return theM.Status != PlatformComponent._ComponentStatus.Destroyed;
		}

		[SpecialName]
		internal bool _Lambda$__7-1(Mount theM)
		{
			return theM.Status != PlatformComponent._ComponentStatus.Destroyed;
		}

		[SpecialName]
		internal bool _Lambda$__8-0(Mount theM)
		{
			return theM.Status != PlatformComponent._ComponentStatus.Destroyed;
		}

		[SpecialName]
		internal bool _Lambda$__8-2(Mount theM)
		{
			return theM.HasEmittingSensors;
		}

		[SpecialName]
		internal bool _Lambda$__8-3(Mount theM)
		{
			return theM.Status != PlatformComponent._ComponentStatus.Destroyed;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__7-0
	{
		public string $VB$Local_thePreferredAimpoint;

		public _Closure$__7-0(_Closure$__7-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_thePreferredAimpoint = arg0.$VB$Local_thePreferredAimpoint;
			}
		}

		[SpecialName]
		internal bool _Lambda$__2(Mount theM)
		{
			return Operators.CompareString(theM.ObjectID, $VB$Local_thePreferredAimpoint, false) == 0;
		}

		static _Closure$__7-0()
		{
			Class72.smethod_20();
		}
	}

	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
		theWriter.WriteStartElement("Damage");
		if ((int)_FireIntensity > 0)
		{
			XmlWriter obj = theWriter;
			byte fireIntensity = (byte)_FireIntensity;
			obj.WriteElementString("Fire", fireIntensity.ToString());
		}
		theWriter.WriteElementString("TTNSDC", XmlConvert.ToString(_TimeToNextSecondaryDamageControl));
		if (LastWeaponHit != null)
		{
			theWriter.WriteStartElement("LastWeaponHit");
			LastWeaponHit.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
			theWriter.WriteEndElement();
		}
		if (SBR.InProgress)
		{
			theWriter.WriteElementString("InitialDP2", XmlConvert.ToString(myUnit.InitialDP));
		}
		theWriter.WriteEndElement();
	}

	public new static Facility_Damage FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		Facility_Damage result;
		try
		{
			Facility_Damage facility_Damage = new Facility_Damage(ref theAU);
			facility_Damage.myUnit = theAU;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "InitialDP2":
				{
					int num = Conversions.ToInteger(val.InnerText);
					if (facility_Damage.myUnit.InitialDP != num)
					{
						int initialDP = facility_Damage.myUnit.InitialDP;
						facility_Damage.myUnit.InitialDP = num;
						float damagePercent = facility_Damage.myUnit.Damage.DamagePercent;
						facility_Damage.myUnit.InitialDP = initialDP;
						facility_Damage.myUnit.set_DamagePts(ScenEditAction: false, (Weapon)null, (float)initialDP - (float)initialDP * damagePercent / 100f);
					}
					break;
				}
				case "TTNSDC":
					facility_Damage._TimeToNextSecondaryDamageControl = Math.Abs(XmlConvert.ToSingle(val.InnerText.Replace(",", ".")));
					break;
				case "LastWeaponHit":
				{
					string innerText = Misc.GetNodeByName(val.ChildNodes[0].ChildNodes, "ID").InnerText;
					if (theDictionary.ContainsKey(innerText))
					{
						facility_Damage.LastWeaponHit = (Weapon)theDictionary[innerText];
						break;
					}
					XmlNode theNode2 = val.ChildNodes[0];
					facility_Damage.LastWeaponHit = Weapon.FromXML(ref theNode2, ref theDictionary, ref theAU.ParentScen);
					break;
				}
				case "Fire":
					facility_Damage._FireIntensity = (FireIntensityLevel)Conversions.ToByte(val.InnerText);
					break;
				case "InitialDP":
					facility_Damage.myUnit.InitialDP = Conversions.ToInteger(val.InnerText);
					break;
				}
			}
			result = facility_Damage;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100553", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Facility_Damage(ref theAU);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public Facility_Damage(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
	}

	public override void DetermineSecondaryDamage(float theDamage, Warhead.WarheadType theWarheadType, float ArmorPenetration)
	{
		try
		{
			if (theDamage <= 0f)
			{
				return;
			}
			double num = theDamage / myUnit.get_DamagePts(ScenEditAction: false, (Weapon)null);
			if (ArmorPenetration > 0f)
			{
				switch (theWarheadType)
				{
				case Warhead.WarheadType.Incendiary:
					num = 8.0 * num;
					break;
				case Warhead.WarheadType.AntiElectrical:
					num = 2.0 * num;
					break;
				case Warhead.WarheadType.Chemical:
				case Warhead.WarheadType.Biological:
					num = 0.0;
					break;
				}
				num *= (double)ArmorPenetration;
			}
			if (num >= 0.9)
			{
				num = 0.9;
			}
			double num2 = num;
			float num3 = (float)(num * 0.3);
			float num4 = (float)(num * 0.1);
			double num5 = GameGeneral.GlobalRNG.NextDouble();
			if (num5 >= (double)num4)
			{
				if (num5 < (double)num3)
				{
					CauseFire(FireIntensityLevel.Major);
				}
				else if (num5 < num2)
				{
					CauseFire(FireIntensityLevel.Minor);
				}
			}
			else
			{
				CauseFire(FireIntensityLevel.Severe);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100554", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void AdjustBombletDamageForArmor(ref float BombletDamage, Warhead.WarheadType Warheadtype)
	{
		switch (Warheadtype)
		{
		case Warhead.WarheadType.Cluster_AP:
			switch (((Facility)myUnit).Armor_General)
			{
			case GlobalVariables.ArmorRating.Light:
				BombletDamage = (float)(0.5 * (double)BombletDamage);
				break;
			default:
				BombletDamage = 0f;
				break;
			case GlobalVariables.ArmorRating.None:
				break;
			}
			break;
		case Warhead.WarheadType.Cluster_AT:
		case Warhead.WarheadType.Cluster_SmartSubs:
			switch (((Facility)myUnit).Armor_General)
			{
			default:
				BombletDamage = 0f;
				break;
			case GlobalVariables.ArmorRating.Medium:
				BombletDamage = (float)(0.5 * (double)BombletDamage);
				break;
			case GlobalVariables.ArmorRating.Light:
				BombletDamage = (float)(0.7 * (double)BombletDamage);
				break;
			case GlobalVariables.ArmorRating.None:
				break;
			}
			break;
		case Warhead.WarheadType.Cluster_Penetrator:
			switch (((Facility)myUnit).Armor_General)
			{
			case GlobalVariables.ArmorRating.Light:
				BombletDamage = 2f * BombletDamage;
				break;
			case GlobalVariables.ArmorRating.Medium:
				BombletDamage = BombletDamage;
				break;
			case GlobalVariables.ArmorRating.Heavy:
				BombletDamage = (float)(0.75 * (double)BombletDamage);
				break;
			case GlobalVariables.ArmorRating.Special:
				BombletDamage = (float)(0.5 * (double)BombletDamage);
				break;
			case GlobalVariables.ArmorRating.None:
				BombletDamage = 3f * BombletDamage;
				break;
			}
			break;
		case Warhead.WarheadType.SuperFrag:
		{
			GlobalVariables.ArmorRating armor_General = ((Facility)myUnit).Armor_General;
			if (armor_General != GlobalVariables.ArmorRating.None && armor_General != GlobalVariables.ArmorRating.Light)
			{
				BombletDamage = 0f;
			}
			break;
		}
		}
	}

	public override void AdjustBlastDamageForArmor(ref float BlastDamage)
	{
		switch (((Facility)myUnit).Armor_General)
		{
		case GlobalVariables.ArmorRating.Light:
			BlastDamage = (float)(0.9 * (double)BlastDamage);
			break;
		case GlobalVariables.ArmorRating.Medium:
			BlastDamage = (float)(0.6 * (double)BlastDamage);
			break;
		case GlobalVariables.ArmorRating.Heavy:
			BlastDamage = (float)(0.3 * (double)BlastDamage);
			break;
		case GlobalVariables.ArmorRating.Special:
			BlastDamage = (float)(0.1 * (double)BlastDamage);
			break;
		}
	}

	protected override void ResolveDamageFromDirectImpact(Weapon theWeapon, GeoPoint LaunchPoint, float DistanceFromImpact_meters, float BearingFromImpact, ref ActiveUnit ExcludedUnit, double? Expl_Latitude, double? Expl_Longitude, float? Expl_Altitude, UnguidedWeapon theUnguidedWeapon)
	{
		try
		{
			if (theWeapon.Type == Weapon._WeaponType.LaserDazzler)
			{
				double num = Module_Unit.RangeToPoint_Slant(myUnit, LaunchPoint) / theWeapon.MaxRange_NoTargetType;
				double num2 = 1.0 - num;
				ResolveDamageFromDazzler((float)num2);
				return;
			}
			double num3 = myUnit.get_DamagePts(ScenEditAction: false, (Weapon)null);
			Warhead warhead = theWeapon.Warheads[0];
			double num4;
			double num5 = default(double);
			if (!warhead.get_IsNuclear(theWeapon.ParentScen) && !warhead.get_IsAirburst(theWeapon, myUnit) && !warhead.IsIncendiary)
			{
				num4 = theWeapon.ArmorPenetrationPercent(((Facility)myUnit).Armor_General, myUnit.VisualSizeClass) / 100f;
				num5 = theWeapon.ShockDamage_KE();
			}
			else
			{
				num4 = 0.0;
			}
			double num6 = default(double);
			if (theWeapon.IsLaserShot)
			{
				num6 = 0.0;
				num5 = CalculateLaserImpactDamage_DP(theWeapon, LaunchPoint);
			}
			float num7 = ((!(myUnit.CurrentAltitude_AGL >= 0f)) ? myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) : ((theWeapon.Warheads.Length <= 0) ? myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) : theWeapon.ImpactAltitude));
			if (theWeapon.Warheads[0].Type == Warhead.WarheadType.HardTargetPenetrator)
			{
				Facility._FacilityCategory category = ((Facility)myUnit).Category;
				if (category == Facility._FacilityCategory.Building_Underground || category == Facility._FacilityCategory.SurfaceAndUnderground)
				{
					num7 = (float)((Module_Unit.Unit)myUnit).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, myUnit.ParentScen) - 10f;
				}
			}
			bool flag = default(bool);
			if (myUnit.AirFacilities_ReadOnly.Where([SpecialName] (AirFacility AF) => AF.IsOpenAirFacility).Count() > 0)
			{
				flag = myUnit.AirFacilities_ReadOnly.Length > 0 && myUnit.AirFacilities_ReadOnly.Length == myUnit.AirFacilities_ReadOnly.Where([SpecialName] (AirFacility AF) => AF.IsOpenAirFacility).Count();
			}
			if (!Expl_Latitude.HasValue || !Expl_Longitude.HasValue)
			{
				float num8 = num7 - (float)((Module_Unit.Unit)myUnit).get_LandElevation(AGL: true, RequestIsFromGUI: false, Force: false, myUnit.ParentScen);
				double out_lon = default(double);
				double out_lat = default(double);
				Geodesic_EdWilliams.CalcPoint_Williams(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, DistanceFromImpact_meters / 1852f, BearingFromImpact);
				Expl_Latitude = out_lat;
				Expl_Longitude = out_lon;
				num7 = num8 + (float)Math.Max(0, (int)Terrain.GetElevation(Expl_Latitude.Value, Expl_Longitude.Value, RequestIsFromGUI: false, myUnit.ParentScen));
			}
			Module_Unit.Unit explodingUnit = ((theUnguidedWeapon != null) ? ((Module_Unit.Unit)theUnguidedWeapon) : ((Module_Unit.Unit)theWeapon));
			if (num4 > 0.0)
			{
				myUnit.ParentScen.AddMessage(Conversions.ToString((int)Math.Round(num4 * 100.0)) + "% penetration achieved", myUnit.Name + " - Armor penetrated", LoggedMessage.MessageType.WeaponDamage, 20, theWeapon.ObjectID, null, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				num6 = ((!flag) ? (warhead.IsExplosive ? Math.Round(num4 * 2.0 * (double)warhead.DP, 2) : Math.Round(num4 * (double)warhead.DP, 2)) : ((num4 < 0.6 && warhead.DP < 100f) ? Math.Round(num4 * (double)warhead.DP / 8.0, 2) : ((num4 < 0.4 && warhead.DP < 250f) ? Math.Round(num4 * (double)warhead.DP / 2.0, 2) : ((!(num4 < 0.2) || !(warhead.DP < 500f)) ? Math.Round(num4 * 2.0 * (double)warhead.DP, 2) : Math.Round(num4 * (double)warhead.DP, 2)))));
				if (num4 < 1.0 && warhead.IsExplosive)
				{
					ref Scenario parentScen = ref myUnit.ParentScen;
					Weapon_AI aI;
					Contact thePrimaryTarget = (aI = theWeapon.AI).PrimaryTarget;
					new Explosion(ref parentScen, explodingUnit, ref thePrimaryTarget, myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), Expl_Longitude.Value, Expl_Latitude.Value, theWeapon.CurrentHeading, num7, theWeapon.Type, (float)((double)warhead.DP * (1.0 - num4)), warhead.DP, warhead.Type, warhead.ExplosivesType, null, null, myUnit, null, null, 0, 0, 0, 0f, theWeapon.ARM_SpecifiedEMission.Key);
					aI.PrimaryTarget = thePrimaryTarget;
				}
				else if (((Facility)myUnit).Armor_General == GlobalVariables.ArmorRating.None && warhead.IsExplosive)
				{
					ref Scenario parentScen2 = ref myUnit.ParentScen;
					Weapon_AI aI;
					Contact thePrimaryTarget = (aI = theWeapon.AI).PrimaryTarget;
					new Explosion(ref parentScen2, explodingUnit, ref thePrimaryTarget, myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), Expl_Longitude.Value, Expl_Latitude.Value, theWeapon.CurrentHeading, num7, theWeapon.Type, (float)((double)warhead.DP * num4 * 0.25), warhead.DP, warhead.Type, warhead.ExplosivesType, null, null, myUnit, null, null, 0, 0, 0, 0f, theWeapon.ARM_SpecifiedEMission.Key);
					aI.PrimaryTarget = thePrimaryTarget;
				}
				else
				{
					ref Scenario parentScen3 = ref myUnit.ParentScen;
					Weapon_AI aI;
					Contact thePrimaryTarget = (aI = theWeapon.AI).PrimaryTarget;
					new Explosion(ref parentScen3, explodingUnit, ref thePrimaryTarget, myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), Expl_Longitude.Value, Expl_Latitude.Value, theWeapon.CurrentHeading, num7, theWeapon.Type, 0f, warhead.DP, warhead.Type, warhead.ExplosivesType, null, null, myUnit, null, null, 0, 0, 0, 0f, theWeapon.ARM_SpecifiedEMission.Key);
					aI.PrimaryTarget = thePrimaryTarget;
				}
			}
			else if (warhead.IsExplosive)
			{
				if (!warhead.get_IsAirburst(theWeapon, myUnit))
				{
					ref Scenario parentScen4 = ref myUnit.ParentScen;
					Weapon_AI aI;
					Contact thePrimaryTarget = (aI = theWeapon.AI).PrimaryTarget;
					new Explosion(ref parentScen4, explodingUnit, ref thePrimaryTarget, myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), Expl_Longitude.Value, Expl_Latitude.Value, theWeapon.CurrentHeading, num7, theWeapon.Type, warhead.DP, warhead.DP, warhead.Type, warhead.ExplosivesType, myUnit, null, null, null, null, 0, 0, 0, 0f, theWeapon.ARM_SpecifiedEMission.Key);
					aI.PrimaryTarget = thePrimaryTarget;
				}
				else
				{
					ref Scenario parentScen5 = ref myUnit.ParentScen;
					Weapon_AI aI;
					Contact thePrimaryTarget = (aI = theWeapon.AI).PrimaryTarget;
					new Explosion(ref parentScen5, explodingUnit, ref thePrimaryTarget, Expl_Longitude.Value, Expl_Latitude.Value, Expl_Longitude.Value, Expl_Latitude.Value, theWeapon.CurrentHeading, ((Module_Unit.Unit)myUnit).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, myUnit.ParentScen), theWeapon.Type, warhead.DP, warhead.DP, warhead.Type, warhead.ExplosivesType, null, null, null, null, null, 0, 0, 0, 0f, theWeapon.ARM_SpecifiedEMission.Key);
					aI.PrimaryTarget = thePrimaryTarget;
				}
			}
			else
			{
				myUnit.ParentScen.AddMessage("No armor penetration!", myUnit.Name + " - No armor penetration", LoggedMessage.MessageType.WeaponDamage, 20, theWeapon.ObjectID, null, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				ref Scenario parentScen6 = ref myUnit.ParentScen;
				Weapon_AI aI;
				Contact thePrimaryTarget = (aI = theWeapon.AI).PrimaryTarget;
				new Explosion(ref parentScen6, explodingUnit, ref thePrimaryTarget, myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), Expl_Longitude.Value, Expl_Latitude.Value, theWeapon.CurrentHeading, num7, theWeapon.Type, warhead.DP, warhead.DP, warhead.Type, warhead.ExplosivesType, myUnit, null, null, null, null, 0, 0, 0, 0f, theWeapon.ARM_SpecifiedEMission.Key);
				aI.PrimaryTarget = thePrimaryTarget;
			}
			if (Math.Round(num6 + num5, 1) > 0.0)
			{
				myUnit.AddMessage(Misc.RemoveHiddenString(myUnit.Name) + " has suffered weapon damage: " + Conversions.ToString(Math.Round(num6 + num5, 1)) + " DPs", myUnit.Name + " damaged", LoggedMessage.MessageType.UnitDamage, 1, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			myUnit.set_DamagePts(ScenEditAction: false, theWeapon, (float)((double)myUnit.get_DamagePts(ScenEditAction: false, (Weapon)null) - (num6 + num5)));
			ResolveComponentHits(warhead.Type, warhead.ExplosivesType, (float)(num6 + num5), (float)num3, (float)num4, IsAreaEffect: false, theWeapon.ARM_SpecifiedEMission.Key);
			ResolveProximityDamageToHostedUnits(IsAreaEffect: false);
			RaiseEvent_DamageSustained();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100555", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_6(Weapon weapon_0, float float_0, float float_1, ActiveUnit activeUnit_0, double? nullable_0, double? nullable_1, float? nullable_2, ref string string_0, bool bool_0, UnguidedWeapon unguidedWeapon_0)
	{
		if (Debugger.IsAttached)
		{
			_ = nullable_0.HasValue;
			_ = nullable_1.HasValue;
		}
		try
		{
			bool flag = false;
			if (string.IsNullOrEmpty(string_0))
			{
				IEnumerable<Mount> enumerable = ((Facility)myUnit).Mounts.Where([SpecialName] (Mount theM) => theM.Status != PlatformComponent._ComponentStatus.Destroyed);
				if (weapon_0.Warheads.Length > 1)
				{
					int num = weapon_0.Warheads.Length - 1;
					for (int num2 = 0; num2 <= num; num2++)
					{
						if (enumerable.Count() > 0)
						{
							int num3 = GameGeneral.GlobalRNG.Next(1, enumerable.Count());
							enumerable.ElementAtOrDefault(num3 - 1).ResolveDamageFromWeapon(weapon_0, float_0, float_1, activeUnit_0, nullable_0, nullable_1, nullable_2, bool_0, unguidedWeapon_0);
							int num4;
							if (Information.IsNothing((object)enumerable))
							{
								num4 = 1;
							}
							else if (enumerable.Count() > 0 && enumerable.Count() >= num3)
							{
								string_0 = enumerable.ElementAtOrDefault(num3 - 1).ObjectID;
								num4 = 1;
							}
							else
							{
								num4 = 1;
							}
							flag = (byte)num4 != 0;
						}
						enumerable = ((Facility)myUnit).Mounts.Where((_Closure$__.$I7-1 == null) ? (_Closure$__.$I7-1 = [SpecialName] (Mount theM) => theM.Status != PlatformComponent._ComponentStatus.Destroyed) : _Closure$__.$I7-1);
					}
				}
				else if (enumerable.Count() > 0)
				{
					int num5 = GameGeneral.GlobalRNG.Next(1, enumerable.Count());
					enumerable.ElementAtOrDefault(num5 - 1).ResolveDamageFromWeapon(weapon_0, float_0, float_1, activeUnit_0, nullable_0, nullable_1, nullable_2, bool_0, unguidedWeapon_0);
					int num6;
					if (!Information.IsNothing((object)enumerable) && enumerable.Count() > 0 && enumerable.Count() >= num5)
					{
						string_0 = enumerable.ElementAtOrDefault(num5 - 1).ObjectID;
						num6 = 1;
					}
					else
					{
						num6 = 1;
					}
					flag = (byte)num6 != 0;
				}
			}
			else
			{
				_Closure$__7-0 arg = default(_Closure$__7-0);
				_Closure$__7-0 CS$<>8__locals2 = new _Closure$__7-0(arg);
				CS$<>8__locals2.$VB$Local_thePreferredAimpoint = string_0;
				IEnumerable<Mount> enumerable = ((Facility)myUnit).Mounts.Where([SpecialName] (Mount theM) => Operators.CompareString(theM.ObjectID, CS$<>8__locals2.$VB$Local_thePreferredAimpoint, false) == 0);
				if (enumerable.Count() > 0)
				{
					enumerable.ElementAtOrDefault(0).ResolveDamageFromWeapon(weapon_0, float_0, float_1, activeUnit_0, nullable_0, nullable_1, nullable_2, bool_0, unguidedWeapon_0);
					flag = true;
				}
			}
			myUnit.Damage.LastWeaponHit = weapon_0;
			if (!flag)
			{
				if (Information.IsNothing((object)nullable_0))
				{
					nullable_0 = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
				}
				if (Information.IsNothing((object)nullable_1))
				{
					nullable_1 = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
				}
				if (Information.IsNothing((object)nullable_2))
				{
					nullable_2 = ((Module_Unit.Unit)myUnit).get_LandElevation(AGL: true, RequestIsFromGUI: false, Force: false, myUnit.ParentScen);
				}
				ResolveDamageFromWeapon_CreateExplosion(weapon_0, float_0, float_1, activeUnit_0, nullable_0, nullable_1, nullable_2, unguidedWeapon_0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100556", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void ResolveDamageFromWeapon(Weapon theWeapon, GeoPoint LaunchPoint, float DistanceFromImpact_meters, float BearingFromImpact, ActiveUnit ExcludedUnit, double? Expl_Latitude, double? Expl_Longitude, float? Expl_Altitude, ref string PreferredAimpoint, bool DirectHit, UnguidedWeapon theUnguidedWeapon)
	{
		if (Module_Unit.IsRemoteSimEntity(myUnit))
		{
			return;
		}
		try
		{
			bool hasAimpoints;
			if (hasAimpoints = ((Facility)myUnit).HasAimpoints)
			{
				if (!hasAimpoints)
				{
					return;
				}
				_ = (float)(100.0 * (1.0 - (double)myUnit.Mounts.Where([SpecialName] (Mount theM) => theM.Status != PlatformComponent._ComponentStatus.Destroyed).Count() / (double)myUnit.Mounts.Count));
				if (!theWeapon.ValidTargets.Radar)
				{
					method_6(theWeapon, DistanceFromImpact_meters, BearingFromImpact, ExcludedUnit, Expl_Latitude, Expl_Longitude, Expl_Altitude, ref PreferredAimpoint, DirectHit, theUnguidedWeapon);
				}
				else
				{
					IEnumerable<Mount> source = myUnit.Mounts.Where([SpecialName] (Mount theM) => AimpointHasCompatibleEmitter(theM, theWeapon.ARM_SpecifiedEMission));
					if (source.Count() > 0)
					{
						IEnumerable<Mount> source2 = source.Where([SpecialName] (Mount theM) => theM.HasEmittingSensors);
						if (source2.Count() > 0)
						{
							if (source2.Count() == 1)
							{
								source2.ElementAtOrDefault(0).ResolveDamageFromWeapon(theWeapon, DistanceFromImpact_meters, BearingFromImpact, ExcludedUnit, Expl_Latitude, Expl_Longitude, Expl_Altitude, DirectHit, theUnguidedWeapon);
							}
							else
							{
								int num = GameGeneral.GlobalRNG.Next(1, source2.Count());
								source2.ElementAtOrDefault(num - 1).ResolveDamageFromWeapon(theWeapon, DistanceFromImpact_meters, BearingFromImpact, ExcludedUnit, Expl_Latitude, Expl_Longitude, Expl_Altitude, DirectHit, theUnguidedWeapon);
							}
						}
						else
						{
							int num2 = GameGeneral.GlobalRNG.Next(1, source.Count());
							source.ElementAtOrDefault(num2 - 1).ResolveDamageFromWeapon(theWeapon, DistanceFromImpact_meters, BearingFromImpact, ExcludedUnit, Expl_Latitude, Expl_Longitude, Expl_Altitude, DirectHit, theUnguidedWeapon);
						}
					}
					else
					{
						method_6(theWeapon, DistanceFromImpact_meters, BearingFromImpact, ExcludedUnit, Expl_Latitude, Expl_Longitude, Expl_Altitude, ref PreferredAimpoint, DirectHit, theUnguidedWeapon);
					}
				}
				if (((Facility)myUnit).Mounts.Where([SpecialName] (Mount theM) => theM.Status != PlatformComponent._ComponentStatus.Destroyed).Count() == 0 && !myUnit.IsMorituri)
				{
					myUnit.ParentScen.DestroyThisUnit(myUnit, $"Unit destroyed, final weapon: {theWeapon.Name} ({theWeapon.ObjectID})", "Weapon Interaction");
				}
			}
			else
			{
				base.ResolveDamageFromWeapon(theWeapon, LaunchPoint, DistanceFromImpact_meters, BearingFromImpact, ExcludedUnit, Expl_Latitude, Expl_Longitude, Expl_Altitude, ref PreferredAimpoint, DirectHit, theUnguidedWeapon);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100557", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void ResolveDamageFromFrag(float DamageYield, float theCutOffRange_Frag, Warhead.WarheadType theWarheadType, int ARM_TargetedRadar = 0)
	{
		if (myUnit.RemoteSimEntityType != Module_Unit.Unit.RemoteSimEntityTypeEnum.Local)
		{
			return;
		}
		try
		{
			Facility facility = (Facility)myUnit;
			double num = myUnit.get_DamagePts(ScenEditAction: false, (Weapon)null);
			if (DamageYield > 0f)
			{
				if (facility.Category == Facility._FacilityCategory.Building_Reveted)
				{
					DamageYield *= 0.9f;
				}
				new WeaponImpact(ref myUnit.ParentScen, myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), WeaponImpact.ImpactType.Kinetic, 0);
				bool flag = false;
				switch (theWarheadType)
				{
				case Warhead.WarheadType.SuperFrag:
					flag = facility.Armor_General <= GlobalVariables.ArmorRating.Light;
					break;
				case Warhead.WarheadType.Fragmentation:
				case Warhead.WarheadType.Fragmentation_ABM:
					flag = facility.Armor_General < GlobalVariables.ArmorRating.Light;
					break;
				}
				if (flag)
				{
					myUnit.AddMessage(myUnit.Name + " has suffered fragmentation damage: " + Conversions.ToString(Math.Round(DamageYield, 1)) + " DPs", myUnit.Name + " damaged", LoggedMessage.MessageType.UnitDamage, 1, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
					myUnit.set_DamagePts(ScenEditAction: false, (Weapon)null, myUnit.get_DamagePts(ScenEditAction: false, (Weapon)null) - DamageYield);
				}
				ResolveComponentHits(theWarheadType, Warhead.WarheadExplosivesType.Fragmentation, DamageYield, (float)num, 0f, IsAreaEffect: true);
				ResolveProximityDamageToHostedUnits(IsAreaEffect: true);
				RaiseEvent_DamageSustained();
				if (myUnit.get_DamagePts(ScenEditAction: false, (Weapon)null) <= 0f)
				{
					myUnit.set_DamagePts(ScenEditAction: false, (Weapon)null, 0f);
					myUnit.ParentScen.DestroyThisUnit(myUnit, "Nearby fragmentation warhead detonated and destroyed the facility.", "Weapon Interaction");
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100558", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	static Facility_Damage()
	{
		Class72.smethod_20();
	}
}
