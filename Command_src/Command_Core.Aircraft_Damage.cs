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

public sealed class Aircraft_Damage : ActiveUnit_Damage
{
	private Aircraft aircraft_0;

	[SpecialName]
	private Aircraft method_6()
	{
		if (Information.IsNothing((object)aircraft_0))
		{
			aircraft_0 = (Aircraft)myUnit;
		}
		return aircraft_0;
	}

	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
		try
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
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100445", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static Aircraft_Damage FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		Aircraft_Damage result;
		try
		{
			Aircraft_Damage aircraft_Damage = new Aircraft_Damage(ref theAU);
			aircraft_Damage.myUnit = theAU;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "TTNSDC":
					aircraft_Damage._TimeToNextSecondaryDamageControl = Math.Abs(XmlConvert.ToSingle(val.InnerText.Replace(",", ".")));
					break;
				case "LastWeaponHit":
				{
					string innerText = Misc.GetNodeByName(val.ChildNodes[0].ChildNodes, "ID").InnerText;
					if (!theDictionary.ContainsKey(innerText))
					{
						XmlNode theNode2 = val.ChildNodes[0];
						aircraft_Damage.LastWeaponHit = Weapon.FromXML(ref theNode2, ref theDictionary, ref theAU.ParentScen);
					}
					else
					{
						aircraft_Damage.LastWeaponHit = (Weapon)theDictionary[innerText];
					}
					break;
				}
				case "Fire":
					aircraft_Damage._FireIntensity = (FireIntensityLevel)Conversions.ToByte(val.InnerText);
					break;
				}
			}
			result = aircraft_Damage;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100446", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Aircraft_Damage(ref theAU);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public Aircraft_Damage(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
	}

	public override void ResolveDamageFromWeapon(Weapon theWeapon, GeoPoint LaunchPoint, float DistanceFromImpact_meters, float BearingFromImpact, ActiveUnit ExcludedUnit, double? Expl_Latitude, double? Expl_Longitude, float? Expl_Altitude, ref string PreferredAimpoint, bool DirectHit, UnguidedWeapon theUnguidedWeapon)
	{
		if (!Module_Unit.IsRemoteSimEntity(myUnit))
		{
			if (!method_6().IsLighterThanAir && !method_6().ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.AircraftDamage))
			{
				myUnit.ParentScen.DestroyThisUnit(myUnit, $"Destroyed, hit by {theWeapon.Name} ({theWeapon.ObjectID})", "Weapon Interaction");
				return;
			}
			string PreferredAimpoint2 = "";
			base.ResolveDamageFromWeapon(theWeapon, LaunchPoint, DistanceFromImpact_meters, BearingFromImpact, ExcludedUnit, Expl_Latitude, Expl_Longitude, Expl_Altitude, ref PreferredAimpoint2, DirectHit, theUnguidedWeapon);
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
			float targetDP_BeforeDamage = myUnit.get_DamagePts(ScenEditAction: false, (Weapon)null);
			double num3 = (theWeapon.IsGuidedWeapon() ? ((double)MathFunctions.GetRelativeBearing(myUnit.CurrentHeading, Module_Unit.BearingToUnit_True(myUnit, theWeapon))) : ((double)MathFunctions.GetRelativeBearing(myUnit.CurrentHeading, Module_Unit.BearingToPoint_True(myUnit, LaunchPoint.Latitude, LaunchPoint.Longitude))));
			Warhead warhead = theWeapon.Warheads[0];
			LockRandom lockRandom_ = GameGeneral.GlobalRNG;
			double num4 = 0.0;
			double num5 = warhead.DP;
			switch (theWeapon.TechGeneration)
			{
			case GlobalVariables.TechGenerationClass.const_7:
				num5 = (double)warhead.DP * 1.05;
				break;
			case GlobalVariables.TechGenerationClass.const_8:
				num5 = (double)warhead.DP * 1.1;
				break;
			case GlobalVariables.TechGenerationClass.const_9:
				num5 = (double)warhead.DP * 1.15;
				break;
			case GlobalVariables.TechGenerationClass.const_10:
				num5 = (double)warhead.DP * 1.2;
				break;
			case GlobalVariables.TechGenerationClass.const_11:
				num5 = (double)warhead.DP * 1.25;
				break;
			case GlobalVariables.TechGenerationClass.const_12:
				num5 = (double)warhead.DP * 1.3;
				break;
			case GlobalVariables.TechGenerationClass.const_13:
				num5 = (double)warhead.DP * 1.35;
				break;
			case GlobalVariables.TechGenerationClass.const_14:
				num5 = (double)warhead.DP * 1.4;
				break;
			case GlobalVariables.TechGenerationClass.const_15:
				num5 = (double)warhead.DP * 1.45;
				break;
			case GlobalVariables.TechGenerationClass.const_16:
				num5 = (double)warhead.DP * 1.5;
				break;
			case GlobalVariables.TechGenerationClass.const_17:
				num5 = (double)warhead.DP * 1.55;
				break;
			}
			if (!theWeapon.IsGuidedWeapon() && (theWeapon.Flags.Fuze_Proximity || theWeapon.Flags.Fuze_Combination))
			{
				int num6 = (int)Math.Round(GameGeneral.GlobalRNG.NextDouble() * 100.0);
				int num7;
				if (num6 <= 20)
				{
					num7 = 100;
					myUnit.AddMessage("Direct-hit of proximity-fuze warhead - full damage applied.", "Prox - Direct hit", LoggedMessage.MessageType.WeaponDamage, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				else if (num6 <= 40)
				{
					num7 = 80;
					myUnit.AddMessage("Near-miss of proximity-fuze warhead - 80% damage applied.", "Prox - Near miss", LoggedMessage.MessageType.WeaponDamage, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				else if (num6 <= 60)
				{
					num7 = 40;
					myUnit.AddMessage("Close miss of proximity-fuze warhead - 40% damage applied.", "Prox - Close miss", LoggedMessage.MessageType.WeaponDamage, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				else if (num6 <= 80)
				{
					num7 = 20;
					myUnit.AddMessage("Miss of proximity-fuze warhead - 20% damage applied.", "Prox - Miss", LoggedMessage.MessageType.WeaponDamage, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				else
				{
					num7 = 10;
					myUnit.AddMessage("Far miss of proximity-fuze warhead - 10% damage applied.", "Prox - Far miss", LoggedMessage.MessageType.WeaponDamage, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				num5 = num5 * (double)num7 / 100.0;
			}
			double num8 = ((!theWeapon.IsUnguidedBallisticWeapon || (!UnguidedWeapon.IsSalvo(theWeapon.Name) && !UnguidedWeapon.IsBurst(theWeapon.Name))) ? num5 : ((double)(float)((double)lockRandom_.Next(1, 11) * 0.1 * num5)));
			if (theWeapon.IsLaserShot)
			{
				num8 = 0.0;
				num4 = CalculateLaserImpactDamage_DP(theWeapon, LaunchPoint);
			}
			if (warhead.Type == Warhead.WarheadType.Kinetic || warhead.Type == Warhead.WarheadType.ArmorPiercing)
			{
				num4 = theWeapon.ShockDamage_KE();
			}
			string text = "";
			if (Operators.CompareString(method_6().Name, method_6().UnitClass, false) != 0)
			{
				text = " (" + method_6().UnitClass + ")";
			}
			float num9 = ((!method_6().IsLighterThanAir) ? (theWeapon.ArmorPenetrationPercent(method_6().Armor_Fuselage, myUnit.VisualSizeClass) / 100f) : ((float)lockRandom_.NextDouble()));
			LastWeaponHit = theWeapon;
			if (num9 > 0f)
			{
				if (method_7())
				{
					myUnit.AddMessage(Misc.RemoveHiddenString(myUnit.Name) + text + " suffered penetration on pressurized cabin - Disintegrating in mid-air!", myUnit.Name + " destroyed!", LoggedMessage.MessageType.UnitDamage, 1, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
					method_6().ParentScen.DestroyThisUnit(method_6(), Misc.RemoveHiddenString(myUnit.Name) + text + $" suffered penetration on pressurized cabin - Disintegrating in mid-air! hit by {theWeapon.Name} ({theWeapon.ObjectID})", "Weapon Interaction");
					myUnit.set_DamagePts(ScenEditAction: false, (Weapon)null, 0f);
				}
				else
				{
					double num10 = (double)num9 * (num8 + num4);
					myUnit.AddMessage(Misc.RemoveHiddenString(myUnit.Name) + text + " has suffered weapon damage: " + Conversions.ToString(Math.Round(num10, 2)) + " DPs", myUnit.Name + " damaged", LoggedMessage.MessageType.UnitDamage, 1, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
					myUnit.set_DamagePts(ScenEditAction: false, (Weapon)null, (float)((double)myUnit.get_DamagePts(ScenEditAction: false, (Weapon)null) - num10));
					if (myUnit.get_DamagePts(ScenEditAction: false, (Weapon)null) > 0f)
					{
						double num11 = num10 / 40.0;
						if (lockRandom_.NextDouble() < num11)
						{
							myUnit.AddMessage(Misc.RemoveHiddenString(myUnit.Name) + text + " has its flight controls knocked out - going down!", myUnit.Name + " destroyed!", LoggedMessage.MessageType.UnitDamage, 1, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
							method_6().ParentScen.DestroyThisUnit(method_6(), Misc.RemoveHiddenString(myUnit.Name) + text + $" has its flight controls knocked out - going down! hit by {theWeapon.Name} ({theWeapon.ObjectID})", "Weapon Interaction");
							myUnit.set_DamagePts(ScenEditAction: false, (Weapon)null, 0f);
						}
					}
				}
			}
			if (myUnit.get_DamagePts(ScenEditAction: false, (Weapon)null) > 0f)
			{
				double num12 = default(double);
				if (method_6().Crew == 0)
				{
					num12 = 0.0;
				}
				else
				{
					switch (method_6().Size)
					{
					case GlobalVariables.AircraftSizeClass.Medium:
						num12 = 0.3;
						break;
					case GlobalVariables.AircraftSizeClass.Small:
						num12 = 0.4;
						break;
					case GlobalVariables.AircraftSizeClass.VLarge:
						num12 = 0.1;
						break;
					case GlobalVariables.AircraftSizeClass.Large:
						num12 = 0.2;
						break;
					}
				}
				if (theWeapon.IsUnguidedBallisticWeapon)
				{
					num12 = (float)(num12 * 0.2);
				}
				double num13 = num3;
				if (num13 < 45.0)
				{
					num12 *= 1.5;
				}
				else if (!(num13 < 135.0))
				{
					if (num13 < 225.0)
					{
						num12 *= 0.5;
					}
					else if (!(num13 < 315.0))
					{
						num12 *= 1.5;
					}
				}
				if (method_6().Crew > 0 && lockRandom_.NextDouble() < num12)
				{
					num9 = theWeapon.ArmorPenetrationPercent(method_6().Armor_Cockpit, myUnit.VisualSizeClass) / 100f;
					myUnit.AddMessage("Cockpit hit - penetration " + Conversions.ToString(num9 * 100f) + "%", "Cockpit hit", LoggedMessage.MessageType.UnitDamage, 0, new Geopoint_Struct(method_6().get_Longitude((GlobalVariables.BooleanObject)null), method_6().get_Latitude((GlobalVariables.BooleanObject)null)));
					if ((double)num9 > 0.5)
					{
						myUnit.AddMessage("Cockpit & crew incapacitated - aircraft is out of control!", myUnit.Name + " destroyed!", LoggedMessage.MessageType.UnitDamage, 0, new Geopoint_Struct(method_6().get_Longitude((GlobalVariables.BooleanObject)null), method_6().get_Latitude((GlobalVariables.BooleanObject)null)));
						method_6().ParentScen.DestroyThisUnit(method_6(), $"Cockpit & crew incapacitated - aircraft is out of control! hit by {theWeapon.Name} ({theWeapon.ObjectID})", "Weapon Interaction");
						return;
					}
				}
				float num14 = default(float);
				switch (method_6().Size)
				{
				case GlobalVariables.AircraftSizeClass.Small:
					num14 = 0.5f;
					break;
				case GlobalVariables.AircraftSizeClass.UAS_Class1_Micro:
				case GlobalVariables.AircraftSizeClass.UAS_Class1_Mini:
				case GlobalVariables.AircraftSizeClass.UAS_Class1_Small:
				case GlobalVariables.AircraftSizeClass.UAS_Class2:
					num14 = 0.7f;
					break;
				case GlobalVariables.AircraftSizeClass.VLarge:
					num14 = 0.1f;
					break;
				case GlobalVariables.AircraftSizeClass.Large:
					num14 = 0.2f;
					break;
				case GlobalVariables.AircraftSizeClass.Medium:
					num14 = 0.3f;
					break;
				}
				if (theWeapon.IsUnguidedBallisticWeapon)
				{
					num14 = (float)((double)num14 * 0.2);
				}
				if (lockRandom_.NextDouble() < (double)num14)
				{
					num9 = theWeapon.ArmorPenetrationPercent(method_6().Armor_Powerplant, myUnit.VisualSizeClass) / 100f;
					myUnit.AddMessage("Engine hit - penetration " + Conversions.ToString(num9 * 100f) + "%", "Engine hit", LoggedMessage.MessageType.UnitLost, 0, new Geopoint_Struct(method_6().get_Longitude((GlobalVariables.BooleanObject)null), method_6().get_Latitude((GlobalVariables.BooleanObject)null)));
					if ((double)num9 > 0.5)
					{
						IEnumerable<Engine> source = method_6().Propulsion.Where([SpecialName] (Engine theE) => theE.Status == PlatformComponent._ComponentStatus.Operational);
						if (source.Count() > 0)
						{
							Engine engine = source.ElementAtOrDefault(lockRandom_.Next(0, source.Count()));
							engine.Destroy(((ActiveUnit)method_6()).get_UnitSide(SetSideOnly: false), ScenEditAction: false, IsAimpointFacility: false);
							myUnit.AddMessage("Engine " + engine.Name + " has been destroyed!", myUnit.Name + " destroyed!", LoggedMessage.MessageType.UnitDamage, 0, new Geopoint_Struct(method_6().get_Longitude((GlobalVariables.BooleanObject)null), method_6().get_Latitude((GlobalVariables.BooleanObject)null)));
						}
					}
				}
				ResolveComponentHits(warhead.Type, warhead.ExplosivesType, num8 + num4, targetDP_BeforeDamage, num9, IsAreaEffect: false, theWeapon.ARM_SpecifiedEMission.Key);
			}
			ResolveProximityDamageToHostedUnits(IsAreaEffect: true);
			RaiseEvent_DamageSustained();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100447", "");
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
			if (!(theDamage <= 0f))
			{
				double num = theDamage / myUnit.get_DamagePts(ScenEditAction: false, (Weapon)null);
				num = 0.3;
				switch (theWarheadType)
				{
				case Warhead.WarheadType.Fragmentation_ABM:
					num += 0.4;
					break;
				case Warhead.WarheadType.Fragmentation:
				case Warhead.WarheadType.ContinuousRod:
					num += 0.2;
					break;
				}
				if (num >= 0.9)
				{
					num = 0.9;
				}
				double num2 = num;
				float num3 = (float)(num - 0.1);
				float num4 = (float)(num - 0.2);
				double num5 = GameGeneral.GlobalRNG.NextDouble();
				if (num5 < (double)num4)
				{
					CauseFire(FireIntensityLevel.Severe);
				}
				else if (num5 < (double)num3)
				{
					CauseFire(FireIntensityLevel.Major);
				}
				else if (num5 < num2)
				{
					CauseFire(FireIntensityLevel.Minor);
				}
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

	[SpecialName]
	private bool method_7()
	{
		if (method_6().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < 3657.6f)
		{
			return false;
		}
		Aircraft._AircraftType type = method_6().Type;
		int result;
		int result2;
		if (type <= Aircraft._AircraftType.SIGINT)
		{
			if (type <= Aircraft._AircraftType.AirborneCP)
			{
				if (type != Aircraft._AircraftType.AirborneLaserPlatform && (uint)(type - 4001) > 2u)
				{
					result = 0;
					goto IL_00a6;
				}
			}
			else if (type != Aircraft._AircraftType.SAR && (uint)(type - 6001) > 1u && (uint)(type - 7001) > 4u)
			{
				result = 0;
				goto IL_00a6;
			}
		}
		else if (type <= Aircraft._AircraftType.Cargo)
		{
			if (type != Aircraft._AircraftType.Transport && type != Aircraft._AircraftType.Cargo)
			{
				result = 0;
				goto IL_00a6;
			}
		}
		else if ((uint)(type - 7301) > 1u && type != Aircraft._AircraftType.Tanker)
		{
			if ((uint)(type - 8901) <= 1u)
			{
				result2 = 1;
				goto IL_00aa;
			}
			result = 0;
			goto IL_00a6;
		}
		result2 = 1;
		goto IL_00aa;
		IL_00aa:
		return (byte)result2 != 0;
		IL_00a6:
		return (byte)result != 0;
	}

	public override void ResolveDamageFromFrag(float DamageYield, float theCutOffRange_Frag, Warhead.WarheadType theWarheadType, int ARM_TargetedRadar = 0)
	{
		if (myUnit.RemoteSimEntityType != Module_Unit.Unit.RemoteSimEntityTypeEnum.Local)
		{
			return;
		}
		try
		{
			if (method_6().IsLighterThanAir)
			{
				base.ResolveDamageFromFrag(DamageYield, theCutOffRange_Frag, theWarheadType);
				if (myUnit.get_DamagePts(ScenEditAction: false, (Weapon)null) <= 0f)
				{
					myUnit.set_DamagePts(ScenEditAction: false, (Weapon)null, 0f);
					myUnit.ParentScen.DestroyThisUnit(myUnit, "Fragmentation warhead detonated nearby", "Weapon Interaction");
				}
			}
			else
			{
				myUnit.ParentScen.DestroyThisUnit(myUnit, "Fragmentation warhead detonated nearby", "Weapon Interaction");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100448", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void ResolveDamageFromBlast(float BlastYield, Warhead.WarheadType theWarheadType, Warhead.WarheadExplosivesType theWarheadExplosivesType, Weapon.DetonationMedium theMedium)
	{
		if (myUnit.RemoteSimEntityType != Module_Unit.Unit.RemoteSimEntityTypeEnum.Local)
		{
			return;
		}
		try
		{
			if (BlastYield >= 2f)
			{
				if (!method_6().IsLighterThanAir)
				{
					myUnit.ParentScen.DestroyThisUnit(myUnit, "Blast warhead detonated nearby", "Weapon Interaction");
				}
				else
				{
					base.ResolveDamageFromBlast(BlastYield, theWarheadType, theWarheadExplosivesType, theMedium);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100449", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void UnderwayRepairs(float ElapsedTime)
	{
	}

	public override void DoSecondaryDamage(float elapsedTime)
	{
		if (!method_6().ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.AircraftDamage))
		{
			return;
		}
		try
		{
			float num = default(float);
			switch (FireIntensity)
			{
			case FireIntensityLevel.Minor:
				num = (float)((double)myUnit.InitialDP * 0.2 * (double)(elapsedTime / 3600f));
				break;
			case FireIntensityLevel.Major:
				num = (float)((double)myUnit.InitialDP * 0.4 * (double)(elapsedTime / 3600f));
				break;
			case FireIntensityLevel.Severe:
				num = (float)((double)myUnit.InitialDP * 0.8 * (double)(elapsedTime / 3600f));
				break;
			case FireIntensityLevel.Conflagration:
				num = (float)myUnit.InitialDP * (elapsedTime / 3600f);
				if (GameGeneral.GlobalRNG.Next(1, 101) <= 5)
				{
					myUnit.AddMessage(myUnit.Name + " has a fuel explosion and is disintegrating!!!", myUnit.Name + " destroyed!", LoggedMessage.MessageType.UnitDamage, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
					myUnit.ParentScen.DestroyThisUnit(myUnit, myUnit.Name + " has a fuel explosion and is disintegrating!!!", "Fire / Flooding");
					return;
				}
				break;
			}
			if (num > 0f)
			{
				myUnit.set_DamagePts(ScenEditAction: false, (Weapon)null, myUnit.get_DamagePts(ScenEditAction: false, (Weapon)null) - num);
			}
			if (myUnit.Damage.DamagePercent > 80f)
			{
				myUnit.AddMessage(myUnit.Name + " has exceeded 80% structural/fuselage damage and is disintegrating!!!", myUnit.Name + " destroyed!", LoggedMessage.MessageType.UnitDamage, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				myUnit.ParentScen.DestroyThisUnit(myUnit, myUnit.Name + " has exceeded 80% structural/fuselage damage and is disintegrating!!!", "Fire / Flooding");
				return;
			}
			if (!method_6().ParentScen.FifthSecondIsChangingOnThisPulse || FireIntensity == FireIntensityLevel.NoFire)
			{
				return;
			}
			byte b = (byte)GameGeneral.GlobalRNG.Next(1, 11);
			GlobalVariables.ProficiencyLevel? proficiency = myUnit.Proficiency;
			int? num2 = (int?)proficiency;
			int val;
			if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2.GetValueOrDefault() == 0)) == true)
			{
				b += 3;
				val = 0;
			}
			else
			{
				num2 = (int?)proficiency;
				if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2 == 1)) == true)
				{
					b += 2;
					val = 0;
				}
				else
				{
					num2 = (int?)proficiency;
					if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2 == 2)) == true)
					{
						b++;
						val = 0;
					}
					else
					{
						num2 = (int?)proficiency;
						if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2 == 3)) != true)
						{
							num2 = (int?)proficiency;
							if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2 == 4)) == true)
							{
								b = (byte)Math.Max(0, b - 2);
								val = 0;
								goto IL_0436;
							}
						}
						val = 0;
					}
				}
			}
			goto IL_0436;
			IL_0436:
			b = (byte)Math.Max(val, b);
			if (b > 10)
			{
				b = 10;
			}
			else
			{
				switch (b)
				{
				default:
					return;
				case 1:
				case 2:
				case 3:
				case 4:
					FireIntensity = (FireIntensityLevel)Math.Max(0, (int)(FireIntensity - 1));
					return;
				case 9:
				case 10:
					break;
				case 5:
				case 6:
				case 7:
				case 8:
					return;
				}
			}
			if (FireIntensity != FireIntensityLevel.Conflagration)
			{
				FireIntensity++;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200283", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	static Aircraft_Damage()
	{
		Class72.smethod_20();
	}
}
