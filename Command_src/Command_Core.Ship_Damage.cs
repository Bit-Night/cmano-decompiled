using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using DarkUI.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Ship_Damage : ActiveUnit_Damage
{
	[CompilerGenerated]
	internal sealed class _Closure$__8-0
	{
		public Warhead $VB$Local_theWarhead;

		public _Closure$__8-0(_Closure$__8-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theWarhead = arg0.$VB$Local_theWarhead;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(Warhead theWH)
		{
			return theWH != $VB$Local_theWarhead;
		}

		static _Closure$__8-0()
		{
			Class72.smethod_20();
		}
	}

	private Ship ship_0;

	[SpecialName]
	private Ship method_6()
	{
		if (ship_0 == null)
		{
			ship_0 = (Ship)myUnit;
		}
		return ship_0;
	}

	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
		try
		{
			theWriter.WriteStartElement("Ship_Damage");
			if ((int)FireIntensity > 0)
			{
				theWriter.WriteElementString("Fire", ((byte)FireIntensity).ToString());
			}
			if ((int)FloodIntensity > 0)
			{
				theWriter.WriteElementString("Flood", ((byte)FloodIntensity).ToString());
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
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100783", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static Ship_Damage FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Ship_Damage result = default(Ship_Damage);
		try
		{
			Ship_Damage ship_Damage = new Ship_Damage(ref theAU);
			ship_Damage.myUnit = theAU;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "InitialDP":
					ship_Damage.myUnit.InitialDP = Conversions.ToInteger(val.InnerText);
					break;
				case "Fire":
					ship_Damage._FireIntensity = (FireIntensityLevel)Conversions.ToByte(val.InnerText);
					break;
				case "TTNSDC":
					ship_Damage._TimeToNextSecondaryDamageControl = Math.Abs(XmlConvert.ToSingle(val.InnerText.Replace(",", ".")));
					break;
				case "LastWeaponHit":
					if (val.ChildNodes.Count > 0)
					{
						string innerText = Misc.GetNodeByName(val.ChildNodes[0].ChildNodes, "ID").InnerText;
						if (!theDictionary.ContainsKey(innerText))
						{
							XmlNode theNode2 = val.ChildNodes[0];
							ship_Damage.LastWeaponHit = Weapon.FromXML(ref theNode2, ref theDictionary, ref theAU.ParentScen);
						}
						else
						{
							ship_Damage.LastWeaponHit = (Weapon)theDictionary[innerText];
						}
					}
					break;
				case "Flood":
					ship_Damage._FloodIntensity = (FloodingIntensityLevel)Conversions.ToByte(val.InnerText);
					break;
				case "InitialDP2":
				{
					int num = Conversions.ToInteger(val.InnerText);
					if (ship_Damage.myUnit.InitialDP != num)
					{
						int initialDP = ship_Damage.myUnit.InitialDP;
						ship_Damage.myUnit.InitialDP = num;
						float damagePercent = ship_Damage.myUnit.Damage.DamagePercent;
						ship_Damage.myUnit.InitialDP = initialDP;
						ship_Damage.myUnit.set_DamagePts(ScenEditAction: false, (Weapon)null, (float)initialDP - (float)initialDP * damagePercent / 100f);
					}
					break;
				}
				}
			}
			result = ship_Damage;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100784", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public Ship_Damage(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
	}

	public override void AdjustBombletDamageForArmor(ref float BombletDamage, Warhead.WarheadType Warheadtype)
	{
		switch (Warheadtype)
		{
		case Warhead.WarheadType.Cluster_AP:
			switch (((Ship)myUnit).Armor_Belt)
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
			switch (((Ship)myUnit).Armor_Belt)
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
			switch (((Ship)myUnit).Armor_Belt)
			{
			case GlobalVariables.ArmorRating.Light:
				BombletDamage = (float)(0.9 * (double)BombletDamage);
				break;
			case GlobalVariables.ArmorRating.Medium:
				BombletDamage = (float)(0.7 * (double)BombletDamage);
				break;
			case GlobalVariables.ArmorRating.Heavy:
				BombletDamage = (float)(0.5 * (double)BombletDamage);
				break;
			case GlobalVariables.ArmorRating.Special:
				BombletDamage = (float)(0.2 * (double)BombletDamage);
				break;
			}
			break;
		}
	}

	public override void AdjustBlastDamageForArmor(ref float BlastDamage)
	{
		switch (((Ship)myUnit).Armor_Belt)
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
			_Closure$__8-0 arg = default(_Closure$__8-0);
			_Closure$__8-0 CS$<>8__locals28 = new _Closure$__8-0(arg);
			if (theWeapon.Type == Weapon._WeaponType.LaserDazzler)
			{
				double num = Module_Unit.RangeToPoint_Slant(myUnit, LaunchPoint) / theWeapon.MaxRange_NoTargetType;
				double num2 = 1.0 - num;
				ResolveDamageFromDazzler((float)num2);
				return;
			}
			float targetDP_BeforeDamage = myUnit.get_DamagePts(ScenEditAction: false, (Weapon)null);
			CS$<>8__locals28.$VB$Local_theWarhead = theWeapon.Warheads[0];
			float num3;
			double num4;
			if (!CS$<>8__locals28.$VB$Local_theWarhead.get_IsNuclear(theWeapon.ParentScen) && !CS$<>8__locals28.$VB$Local_theWarhead.get_IsAirburst(theWeapon, (ActiveUnit)method_6()))
			{
				num3 = theWeapon.ArmorPenetrationPercent(((Ship)myUnit).Armor_Belt, myUnit.VisualSizeClass) / 100f;
				num4 = theWeapon.ShockDamage_KE();
			}
			else
			{
				num3 = 0f;
				num4 = 0.0;
			}
			double num5 = default(double);
			if (theWeapon.IsLaserShot)
			{
				num5 = 0.0;
				num4 = CalculateLaserImpactDamage_DP(theWeapon, LaunchPoint);
			}
			float num6 = ((!theWeapon.IsMissile) ? 0f : ((float)theWeapon.get_OptimumBurstHeight_AGL((ActiveUnit)method_6())));
			float num7 = CS$<>8__locals28.$VB$Local_theWarhead.DP;
			List<Warhead> list = theWeapon.Warheads.Where([SpecialName] (Warhead theWH) => theWH != CS$<>8__locals28.$VB$Local_theWarhead).ToList();
			foreach (Warhead item in list)
			{
				Weapon weapon = item.get_CarriedWeapon(theWeapon.ParentScen);
				if (weapon != null && weapon.Warheads.Length > 0)
				{
					num7 += item.get_CarriedWeapon(theWeapon.ParentScen).Warheads[0].DP;
				}
			}
			if (!Expl_Latitude.HasValue || !Expl_Longitude.HasValue)
			{
				float num8 = num6 - (float)((Module_Unit.Unit)myUnit).get_LandElevation(AGL: true, RequestIsFromGUI: false, Force: false, myUnit.ParentScen);
				double out_lon = default(double);
				double out_lat = default(double);
				Geodesic_EdWilliams.CalcPoint_Williams(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, DistanceFromImpact_meters / 1852f, BearingFromImpact);
				Expl_Latitude = out_lat;
				Expl_Longitude = out_lon;
				num6 = num8 + (float)Math.Max(0, (int)Terrain.GetElevation(Expl_Latitude.Value, Expl_Longitude.Value, RequestIsFromGUI: false, myUnit.ParentScen));
			}
			Module_Unit.Unit explodingUnit = ((theUnguidedWeapon != null) ? ((Module_Unit.Unit)theUnguidedWeapon) : ((Module_Unit.Unit)theWeapon));
			if (num3 > 0f)
			{
				myUnit.ParentScen.AddMessage(Conversions.ToString((int)Math.Round(num3 * 100f)) + "% penetration achieved", myUnit.Name + " - armor penetrated", LoggedMessage.MessageType.WeaponDamage, 20, theWeapon.ObjectID, null, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				num5 = ((!CS$<>8__locals28.$VB$Local_theWarhead.IsExplosive) ? ((double)(float)Math.Round(num3 * num7, 2)) : ((CS$<>8__locals28.$VB$Local_theWarhead.Type != Warhead.WarheadType.Torpedo) ? ((double)(float)Math.Round(num3 * 2f * num7, 2)) : ((!theWeapon.Flags.Torpedo_StraightRunning) ? ((double)num7 + (double)num7 * GameGeneral.GlobalRNG.NextDouble() * 3.0) : ((double)num7))));
				if (num3 < 1f && CS$<>8__locals28.$VB$Local_theWarhead.IsExplosive)
				{
					ref Scenario parentScen = ref myUnit.ParentScen;
					Weapon_AI aI;
					Contact thePrimaryTarget = (aI = theWeapon.AI).PrimaryTarget;
					new Explosion(ref parentScen, explodingUnit, ref thePrimaryTarget, myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), Expl_Longitude.Value, Expl_Latitude.Value, theWeapon.CurrentHeading, num6, theWeapon.Type, num7 * (1f - num3), CS$<>8__locals28.$VB$Local_theWarhead.DP, CS$<>8__locals28.$VB$Local_theWarhead.Type, CS$<>8__locals28.$VB$Local_theWarhead.ExplosivesType, null, null, myUnit, null, null, 0, 0, 0, 0f, theWeapon.ARM_SpecifiedEMission.Key);
					aI.PrimaryTarget = thePrimaryTarget;
				}
				else if (((Ship)myUnit).Armor_Bulkhead == GlobalVariables.ArmorRating.None && CS$<>8__locals28.$VB$Local_theWarhead.IsExplosive)
				{
					ref Scenario parentScen2 = ref myUnit.ParentScen;
					Weapon_AI aI;
					Contact thePrimaryTarget = (aI = theWeapon.AI).PrimaryTarget;
					new Explosion(ref parentScen2, explodingUnit, ref thePrimaryTarget, myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), Expl_Longitude.Value, Expl_Latitude.Value, theWeapon.CurrentHeading, num6, theWeapon.Type, (float)((double)(num7 * num3) * 0.25), CS$<>8__locals28.$VB$Local_theWarhead.DP, CS$<>8__locals28.$VB$Local_theWarhead.Type, CS$<>8__locals28.$VB$Local_theWarhead.ExplosivesType, null, null, myUnit, null, null, 0, 0, 0, 0f, theWeapon.ARM_SpecifiedEMission.Key);
					aI.PrimaryTarget = thePrimaryTarget;
				}
			}
			else if (CS$<>8__locals28.$VB$Local_theWarhead.IsExplosive)
			{
				if (CS$<>8__locals28.$VB$Local_theWarhead.get_IsAirburst(theWeapon, (ActiveUnit)method_6()))
				{
					ref Scenario parentScen3 = ref myUnit.ParentScen;
					Weapon_AI aI;
					Contact thePrimaryTarget = (aI = theWeapon.AI).PrimaryTarget;
					new Explosion(ref parentScen3, explodingUnit, ref thePrimaryTarget, Expl_Longitude.Value, Expl_Latitude.Value, Expl_Longitude.Value, Expl_Latitude.Value, theWeapon.CurrentHeading, num6, theWeapon.Type, num7, CS$<>8__locals28.$VB$Local_theWarhead.DP, CS$<>8__locals28.$VB$Local_theWarhead.Type, CS$<>8__locals28.$VB$Local_theWarhead.ExplosivesType, null, null, null, null, null, 0, 0, 0, 0f, theWeapon.ARM_SpecifiedEMission.Key);
					aI.PrimaryTarget = thePrimaryTarget;
				}
				else
				{
					ref Scenario parentScen4 = ref myUnit.ParentScen;
					Weapon_AI aI;
					Contact thePrimaryTarget = (aI = theWeapon.AI).PrimaryTarget;
					new Explosion(ref parentScen4, explodingUnit, ref thePrimaryTarget, myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), Expl_Longitude.Value, Expl_Latitude.Value, theWeapon.CurrentHeading, num6, theWeapon.Type, num7, CS$<>8__locals28.$VB$Local_theWarhead.DP, CS$<>8__locals28.$VB$Local_theWarhead.Type, CS$<>8__locals28.$VB$Local_theWarhead.ExplosivesType, myUnit, null, null, null, null, 0, 0, 0, 0f, theWeapon.ARM_SpecifiedEMission.Key);
					aI.PrimaryTarget = thePrimaryTarget;
				}
			}
			else
			{
				myUnit.ParentScen.AddMessage("No armor penetration", "No armor penetration", LoggedMessage.MessageType.WeaponDamage, 20, theWeapon.ObjectID, null, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				ref Scenario parentScen5 = ref myUnit.ParentScen;
				Weapon_AI aI;
				Contact thePrimaryTarget = (aI = theWeapon.AI).PrimaryTarget;
				new Explosion(ref parentScen5, explodingUnit, ref thePrimaryTarget, myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), Expl_Longitude.Value, Expl_Latitude.Value, theWeapon.CurrentHeading, num6, theWeapon.Type, num7, CS$<>8__locals28.$VB$Local_theWarhead.DP, CS$<>8__locals28.$VB$Local_theWarhead.Type, CS$<>8__locals28.$VB$Local_theWarhead.ExplosivesType, myUnit, null, null, null, null, 0, 0, 0, 0f, theWeapon.ARM_SpecifiedEMission.Key);
				aI.PrimaryTarget = thePrimaryTarget;
			}
			if (Math.Round(num5 + num4, 1) > 0.0)
			{
				myUnit.AddMessage(Misc.RemoveHiddenString(myUnit.Name) + " has suffered weapon damage: " + Conversions.ToString(Math.Round(num5 + num4, 1)) + " DPs", myUnit.Name + " damaged", LoggedMessage.MessageType.UnitDamage, 1, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			myUnit.set_DamagePts(ScenEditAction: false, theWeapon, (float)((double)myUnit.get_DamagePts(ScenEditAction: false, (Weapon)null) - (num5 + num4)));
			ResolveComponentHits(CS$<>8__locals28.$VB$Local_theWarhead.Type, CS$<>8__locals28.$VB$Local_theWarhead.ExplosivesType, num5 + num4, targetDP_BeforeDamage, num3, IsAreaEffect: false, theWeapon.ARM_SpecifiedEMission.Key);
			ResolveProximityDamageToHostedUnits(IsAreaEffect: false);
			RaiseEvent_DamageSustained();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100785", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void DetermineSecondaryDamage(float theDamage, Warhead.WarheadType theWarheadType, float ArmorPenetration)
	{
		try
		{
			if (theDamage <= 0f)
			{
				return;
			}
			float num = theDamage / myUnit.get_DamagePts(ScenEditAction: false, (Weapon)null);
			double num2 = num;
			double num3 = num;
			if (ArmorPenetration > 0f)
			{
				switch (theWarheadType)
				{
				case Warhead.WarheadType.Torpedo:
					num3 = 4.0 * num3;
					break;
				case Warhead.WarheadType.Incendiary:
					num2 = 8.0 * num2;
					num3 = 0.0;
					break;
				case Warhead.WarheadType.AntiElectrical:
					num2 = 2.0 * num2;
					break;
				case Warhead.WarheadType.Chemical:
				case Warhead.WarheadType.Biological:
					num2 = 0.0;
					num3 = 0.0;
					break;
				}
				switch (method_6().Category)
				{
				case Ship._ShipCategory.Amphibious:
					num2 = (float)(1.5 * num2);
					num3 = (float)(1.5 * num3);
					break;
				case Ship._ShipCategory.Auxiliary:
				case Ship._ShipCategory.Merchant:
				case Ship._ShipCategory.Civilian:
				case Ship._ShipCategory.MobileOffshoreBase:
					num2 = 2.0 * num2;
					num3 = 2.0 * num3;
					break;
				}
				num2 *= (double)ArmorPenetration;
				num3 *= (double)ArmorPenetration;
			}
			if ((uint)(theWarheadType - 6001) <= 2u || theWarheadType == Warhead.WarheadType.Cluster_SmartSubs)
			{
				num2 = Math.Max(0.7, num2);
			}
			ObservableList<Engine> propulsion = ((Ship)myUnit).Propulsion;
			foreach (Engine item in propulsion)
			{
				if (item.Status == PlatformComponent._ComponentStatus.Destroyed)
				{
					num3 *= 1.3;
				}
			}
			if (num2 >= 0.9)
			{
				num2 = 0.9;
			}
			if (num3 >= 0.9)
			{
				num3 = 0.9;
			}
			double num4 = num2;
			float num5 = (float)(num2 * 0.3);
			float num6 = (float)(num2 * 0.1);
			double num7 = GameGeneral.GlobalRNG.NextDouble();
			if (num7 < (double)num6)
			{
				CauseFire(FireIntensityLevel.Severe);
			}
			else if (num7 < (double)num5)
			{
				CauseFire(FireIntensityLevel.Major);
			}
			else if (num7 < num4)
			{
				CauseFire(FireIntensityLevel.Minor);
			}
			double num8 = num3;
			float num9 = (float)(num2 * 0.3);
			float num10 = (float)(num2 * 0.1);
			double num11 = GameGeneral.GlobalRNG.NextDouble();
			if (num11 < (double)num10)
			{
				CauseFlooding(FloodingIntensityLevel.Severe);
			}
			else if (num11 < (double)num9)
			{
				CauseFlooding(FloodingIntensityLevel.Major);
			}
			else if (num11 < num8)
			{
				CauseFlooding(FloodingIntensityLevel.Minor);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100785", "");
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
		float targetDP_BeforeDamage = myUnit.get_DamagePts(ScenEditAction: false, (Weapon)null);
		try
		{
			if (!(DamageYield > 0f))
			{
				return;
			}
			new WeaponImpact(ref myUnit.ParentScen, myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), WeaponImpact.ImpactType.Kinetic, 0);
			bool flag = false;
			switch (theWarheadType)
			{
			case Warhead.WarheadType.SuperFrag:
				flag = method_6().Armor_Belt <= GlobalVariables.ArmorRating.Light;
				break;
			case Warhead.WarheadType.Fragmentation:
			case Warhead.WarheadType.Fragmentation_ABM:
				flag = method_6().Armor_Belt < GlobalVariables.ArmorRating.Light;
				break;
			}
			if (flag)
			{
				if ((int)Math.Round(DamageYield) != 0)
				{
					myUnit.AddMessage(myUnit.Name + " has suffered fragmentation damage: " + Conversions.ToString(Math.Round(DamageYield, 1)) + " DPs", myUnit.Name + " damaged", LoggedMessage.MessageType.UnitDamage, 1, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				else
				{
					myUnit.AddMessage(myUnit.Name + " has suffered minor fragmentation damage", myUnit.Name + " damaged", LoggedMessage.MessageType.UnitDamage, 1, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				myUnit.set_DamagePts(ScenEditAction: false, (Weapon)null, myUnit.get_DamagePts(ScenEditAction: false, (Weapon)null) - DamageYield);
			}
			ResolveComponentHits(Warhead.WarheadType.Fragmentation, Warhead.WarheadExplosivesType.Fragmentation, DamageYield, targetDP_BeforeDamage, 0f, IsAreaEffect: true, ARM_TargetedRadar);
			ResolveProximityDamageToHostedUnits(IsAreaEffect: true);
			RaiseEvent_DamageSustained();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100114", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override ComponentHitType ResolveComponentHitType(Warhead theWarhead)
	{
		int num = GameGeneral.GlobalRNG.Next(1, 101);
		switch (theWarhead.Type)
		{
		default:
			switch (((Ship)myUnit).Category)
			{
			case Ship._ShipCategory.AviationShip:
			case Ship._ShipCategory.MobileOffshoreBase:
				if (num > 10)
				{
					if (num <= 20)
					{
						return ComponentHitType.FlightDeck;
					}
					if (num <= 40)
					{
						return ComponentHitType.Hangar;
					}
					if (num <= 50)
					{
						return ComponentHitType.Sensor;
					}
					if (num <= 60)
					{
						return ComponentHitType.Flooding;
					}
					if (num > 70)
					{
						if (num <= 80)
						{
							return ComponentHitType.Engineering;
						}
						if (num > 90)
						{
							return ComponentHitType.Rudder;
						}
						return ComponentHitType.CIC;
					}
					return ComponentHitType.Fire;
				}
				return ComponentHitType.Mount;
			default:
				if (num > 30)
				{
					if (num > 50)
					{
						if (num <= 60)
						{
							return ComponentHitType.Flooding;
						}
						if (num > 70)
						{
							if (num <= 80)
							{
								return ComponentHitType.Engineering;
							}
							if (num > 90)
							{
								return ComponentHitType.Rudder;
							}
							return ComponentHitType.CIC;
						}
						return ComponentHitType.Fire;
					}
					return ComponentHitType.Sensor;
				}
				return ComponentHitType.Mount;
			case Ship._ShipCategory.Auxiliary:
				if (num <= 10)
				{
					return ComponentHitType.Mount;
				}
				if (num <= 30)
				{
					return ComponentHitType.Cargo;
				}
				if (num > 50)
				{
					if (num > 70)
					{
						if (num <= 80)
						{
							return ComponentHitType.Engineering;
						}
						if (num > 90)
						{
							return ComponentHitType.Rudder;
						}
						return ComponentHitType.CIC;
					}
					return ComponentHitType.Fire;
				}
				return ComponentHitType.Flooding;
			case Ship._ShipCategory.Merchant:
				if (num > 10)
				{
					if (num > 30)
					{
						if (num > 50)
						{
							if (num <= 70)
							{
								return ComponentHitType.Fire;
							}
							if (num <= 80)
							{
								return ComponentHitType.Engineering;
							}
							if (num > 90)
							{
								return ComponentHitType.Rudder;
							}
							return ComponentHitType.CIC;
						}
						return ComponentHitType.Flooding;
					}
					return ComponentHitType.Cargo;
				}
				return ComponentHitType.Mount;
			}
		case Warhead.WarheadType.Torpedo:
			if (num <= 10)
			{
				return ComponentHitType.Mount;
			}
			if (num > 50)
			{
				if (num <= 60)
				{
					return ComponentHitType.Sonar;
				}
				if (num <= 90)
				{
					return ComponentHitType.Engineering;
				}
				return ComponentHitType.Rudder;
			}
			return ComponentHitType.Flooding;
		case Warhead.WarheadType.Fragmentation:
		{
			Ship._ShipCategory category = ((Ship)myUnit).Category;
			if (category != Ship._ShipCategory.AviationShip && category != Ship._ShipCategory.MobileOffshoreBase)
			{
				if (num <= 30)
				{
					return ComponentHitType.Sensor;
				}
				if (num > 50)
				{
					if (num <= 80)
					{
						return ComponentHitType.Mount;
					}
					if (num <= 90)
					{
						return ComponentHitType.FlightDeck;
					}
					return ComponentHitType.CIC;
				}
				return ComponentHitType.Mount;
			}
			if (num > 30)
			{
				if (num > 50)
				{
					if (num > 80)
					{
						if (num <= 90)
						{
							return ComponentHitType.FlightDeck;
						}
						return ComponentHitType.CIC;
					}
					return ComponentHitType.FlightDeck;
				}
				return ComponentHitType.Mount;
			}
			return ComponentHitType.Sensor;
		}
		}
	}

	protected override void DetermineDamageResult(ComponentHitType theHitType)
	{
		try
		{
			switch (theHitType)
			{
			case ComponentHitType.Mount:
			{
				PlatformComponent platformComponent = DetermineComponentThatIsHit(theHitType);
				if (platformComponent != null && platformComponent.Status != PlatformComponent._ComponentStatus.Destroyed)
				{
					platformComponent.Destroy(myUnit.get_UnitSide(SetSideOnly: false), ScenEditAction: false, IsAimpointFacility: false);
					myUnit.ParentScen.AddMessage("Mount: " + platformComponent.Name + " has been destroyed!", myUnit.Name + " lost a mount/weapon", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				break;
			}
			case ComponentHitType.Flooding:
				myUnit.ParentScen.AddMessage(myUnit.Name + " is flooding!", myUnit.Name + " is flooding!", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				break;
			case ComponentHitType.Fire:
				myUnit.ParentScen.AddMessage(myUnit.Name + " is on fire!", myUnit.Name + " is on fire!", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				break;
			case ComponentHitType.Engineering:
			{
				Engine engine = (Engine)DetermineComponentThatIsHit(theHitType);
				if (engine != null && engine.Status != PlatformComponent._ComponentStatus.Destroyed)
				{
					engine.Destroy(myUnit.get_UnitSide(SetSideOnly: false), ScenEditAction: false, IsAimpointFacility: false);
					myUnit.ParentScen.AddMessage("Powerplant: " + engine.Name + " has been destroyed!", myUnit.Name + " lost an engine", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				break;
			}
			case ComponentHitType.CIC:
				((Ship)myUnit).CIC.Destroy(myUnit.get_UnitSide(SetSideOnly: false), ScenEditAction: false, IsAimpointFacility: false);
				break;
			case ComponentHitType.Rudder:
				((Ship)myUnit).Rudder.Destroy(myUnit.get_UnitSide(SetSideOnly: false), ScenEditAction: false, IsAimpointFacility: false);
				myUnit.ParentScen.AddMessage("Rudder has been destroyed!", myUnit.Name + " lost its rudder", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				break;
			case ComponentHitType.FlightDeck:
			case ComponentHitType.Hangar:
			{
				AirFacility airFacility = (AirFacility)DetermineComponentThatIsHit(theHitType);
				if (airFacility != null && airFacility.Status != PlatformComponent._ComponentStatus.Destroyed)
				{
					airFacility.Destroy(myUnit.get_UnitSide(SetSideOnly: false), ScenEditAction: false, IsAimpointFacility: false);
					myUnit.ParentScen.AddMessage("Air Facility: " + airFacility.Name + " has been destroyed!", myUnit.Name + " lost an air facility", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				break;
			}
			case ComponentHitType.Cargo:
				throw new NotImplementedException();
			case ComponentHitType.Sensor:
			case ComponentHitType.Sonar:
			{
				Sensor sensor = (Sensor)DetermineComponentThatIsHit(theHitType);
				if (sensor != null && sensor.Status != PlatformComponent._ComponentStatus.Destroyed)
				{
					sensor.Destroy(myUnit.get_UnitSide(SetSideOnly: false), ScenEditAction: false, IsAimpointFacility: false);
					myUnit.ParentScen.AddMessage("Sensor: " + sensor.Name + " has been destroyed!", myUnit.Name + " lost a sensor", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				break;
			}
			case ComponentHitType.Magazine:
			{
				Magazine magazine = (Magazine)DetermineComponentThatIsHit(theHitType);
				if (magazine != null && magazine.Status != PlatformComponent._ComponentStatus.Destroyed)
				{
					magazine.Destroy(myUnit.get_UnitSide(SetSideOnly: false), ScenEditAction: false, IsAimpointFacility: false);
					myUnit.ParentScen.AddMessage("Magazine: " + magazine.Name + " has been destroyed!", myUnit.Name + " lost a shared magazine", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				break;
			}
			case ComponentHitType.PressureHull:
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100787", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	static Ship_Damage()
	{
		Class72.smethod_20();
	}
}
