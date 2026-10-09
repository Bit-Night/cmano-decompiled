using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Submarine_Damage : ActiveUnit_Damage
{
	private Submarine submarine_0;

	public override FireIntensityLevel FireIntensity
	{
		get
		{
			return base.FireIntensity;
		}
		set
		{
			bool num = value != FireIntensity;
			base.FireIntensity = value;
			if (num && FireIntensity > FireIntensityLevel.Minor)
			{
				myUnit.AddMessage(myUnit.Name + " must urgently rise to periscope depth because of the fire onboard!", myUnit.Name + " emergency blowing", LoggedMessage.MessageType.UnitDamage, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
		}
	}

	public override FloodingIntensityLevel FloodIntensity
	{
		get
		{
			return base.FloodIntensity;
		}
		set
		{
			bool num = value != FloodIntensity;
			base.FloodIntensity = value;
			if (num && FloodIntensity > FloodingIntensityLevel.Minor)
			{
				myUnit.AddMessage(myUnit.Name + " must urgently rise to the surface because of the flooding onboard!", myUnit.Name + " emergency blowing", LoggedMessage.MessageType.UnitDamage, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
		}
	}

	[SpecialName]
	private Submarine method_6()
	{
		if (submarine_0 == null)
		{
			submarine_0 = (Submarine)myUnit;
		}
		return submarine_0;
	}

	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
		theWriter.WriteStartElement("Submarine_Damage");
		if ((int)_FireIntensity > 0)
		{
			XmlWriter obj = theWriter;
			byte fireIntensity = (byte)_FireIntensity;
			obj.WriteElementString("Fire", fireIntensity.ToString());
		}
		if ((int)_FloodIntensity > 0)
		{
			XmlWriter obj2 = theWriter;
			byte fireIntensity = (byte)_FloodIntensity;
			obj2.WriteElementString("Flood", fireIntensity.ToString());
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

	public new static Submarine_Damage FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		Submarine_Damage result;
		try
		{
			Submarine_Damage submarine_Damage = new Submarine_Damage(ref theAU);
			submarine_Damage.myUnit = theAU;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "InitialDP":
					submarine_Damage.myUnit.InitialDP = Conversions.ToInteger(val.InnerText);
					break;
				case "InitialDP2":
				{
					int num = Conversions.ToInteger(val.InnerText);
					if (submarine_Damage.myUnit.InitialDP != num)
					{
						int initialDP = submarine_Damage.myUnit.InitialDP;
						submarine_Damage.myUnit.InitialDP = num;
						float damagePercent = submarine_Damage.myUnit.Damage.DamagePercent;
						submarine_Damage.myUnit.InitialDP = initialDP;
						submarine_Damage.myUnit.set_DamagePts(ScenEditAction: false, (Weapon)null, (float)initialDP - (float)initialDP * damagePercent / 100f);
					}
					break;
				}
				case "Flood":
					submarine_Damage._FloodIntensity = (FloodingIntensityLevel)Conversions.ToByte(val.InnerText);
					break;
				case "TTNSDC":
					submarine_Damage._TimeToNextSecondaryDamageControl = Math.Abs(XmlConvert.ToSingle(val.InnerText.Replace(",", ".")));
					break;
				case "LastWeaponHit":
				{
					string innerText = Misc.GetNodeByName(val.ChildNodes[0].ChildNodes, "ID").InnerText;
					if (!theDictionary.ContainsKey(innerText))
					{
						XmlNode theNode2 = val.ChildNodes[0];
						submarine_Damage.LastWeaponHit = Weapon.FromXML(ref theNode2, ref theDictionary, ref theAU.ParentScen);
					}
					else
					{
						submarine_Damage.LastWeaponHit = (Weapon)theDictionary[innerText];
					}
					break;
				}
				case "Fire":
					submarine_Damage._FireIntensity = (FireIntensityLevel)Conversions.ToByte(val.InnerText);
					break;
				}
			}
			result = submarine_Damage;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100828", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Submarine_Damage(ref theAU);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public Submarine_Damage(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
	}

	public override void ResolveDamageFromWeapon(Weapon theWeapon, GeoPoint LaunchPoint, float DistanceFromImpact_meters, float BearingFromImpact, ActiveUnit ExcludedUnit, double? Expl_Latitude, double? Expl_Longitude, float? Expl_Altitude, ref string PreferredAimpoint, bool DirectHit, UnguidedWeapon theUnguidedWeapon)
	{
		if (Module_Unit.IsRemoteSimEntity(myUnit))
		{
			return;
		}
		try
		{
			if (theWeapon.Warheads.Length == 0)
			{
				return;
			}
			Warhead warhead = theWeapon.Warheads[0];
			if (theWeapon.Warheads[0].Type == Warhead.WarheadType.Weapon)
			{
				warhead = theWeapon.Warheads[0].get_CarriedWeapon(theWeapon.ParentScen).Warheads[0];
			}
			if (DistanceFromImpact_meters == 0f)
			{
				ResolveDamageFromDirectImpact(theWeapon, LaunchPoint, DistanceFromImpact_meters, BearingFromImpact, ref ExcludedUnit, Expl_Latitude, Expl_Longitude, Expl_Altitude, theUnguidedWeapon);
			}
			else if (warhead.IsExplosive || warhead.IsIncendiary)
			{
				if (!Expl_Latitude.HasValue || !Expl_Longitude.HasValue)
				{
					double out_lon = default(double);
					double out_lat = default(double);
					Geodesic_EdWilliams.CalcPoint_Williams(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, DistanceFromImpact_meters / 1852f, BearingFromImpact);
					Expl_Latitude = out_lat;
					Expl_Longitude = out_lon;
				}
				if (Terrain.GetElevation(Expl_Latitude.Value, Expl_Longitude.Value, RequestIsFromGUI: false, myUnit.ParentScen) <= 0)
				{
					new WaterSplash(ref myUnit.ParentScen, Expl_Longitude.Value, Expl_Latitude.Value, Explosion.GetCutoffRange_Blast_nm(warhead.DP, Weapon.DetonationMedium.Underwater));
				}
				if (!Expl_Altitude.HasValue)
				{
					Expl_Altitude = (theWeapon.IsTorpedo ? new float?((int)Math.Round(theWeapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))) : (theWeapon.IsMissile ? new float?((int)Math.Round(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + (float)theWeapon.get_OptimumBurstHeight_AGL(myUnit))) : ((theWeapon.Type == Weapon._WeaponType.DepthCharge || (theWeapon.Warheads[0].Type == Warhead.WarheadType.Weapon && theWeapon.Warheads[0].get_CarriedWeapon(myUnit.ParentScen).Type == Weapon._WeaponType.DepthCharge)) ? new float?((int)Math.Round(Math.Max(-100.0, (double)Terrain.GetElevation(Expl_Latitude.Value, Expl_Longitude.Value, RequestIsFromGUI: false, myUnit.ParentScen) / 2.0))) : new float?(Math.Max(0, (int)Terrain.GetElevation(Expl_Latitude.Value, Expl_Longitude.Value, RequestIsFromGUI: false, myUnit.ParentScen))))));
				}
				Module_Unit.Unit explodingUnit = ((theUnguidedWeapon == null) ? ((Module_Unit.Unit)theWeapon) : ((Module_Unit.Unit)theUnguidedWeapon));
				ref Scenario parentScen = ref myUnit.ParentScen;
				Weapon_AI aI;
				Contact thePrimaryTarget = (aI = theWeapon.AI).PrimaryTarget;
				new Explosion(ref parentScen, explodingUnit, ref thePrimaryTarget, Expl_Longitude.Value, Expl_Latitude.Value, Expl_Longitude.Value, Expl_Latitude.Value, theWeapon.CurrentHeading, Expl_Altitude.Value, theWeapon.Type, warhead.DP, warhead.DP, warhead.Type, warhead.ExplosivesType, null, null, ExcludedUnit, null, null, 0, 0);
				aI.PrimaryTarget = thePrimaryTarget;
			}
			myUnit.Damage.LastWeaponHit = theWeapon;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100829", "");
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
			BombletDamage = (float)(0.5 * (double)BombletDamage);
			break;
		case Warhead.WarheadType.Cluster_AT:
		case Warhead.WarheadType.Cluster_SmartSubs:
			BombletDamage = (float)(0.7 * (double)BombletDamage);
			break;
		case Warhead.WarheadType.Cluster_Penetrator:
			BombletDamage = (float)(0.9 * (double)BombletDamage);
			break;
		case Warhead.WarheadType.SuperFrag:
			BombletDamage = (float)(0.6 * (double)BombletDamage);
			break;
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
				case Warhead.WarheadType.Torpedo_ASWOptimized:
					num3 = 100.0;
					num2 = 4.0 * num2;
					break;
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
				num2 *= (double)ArmorPenetration;
				num3 *= (double)ArmorPenetration;
			}
			if (method_6().Flags.UsesLiOnBattery)
			{
				num2 *= 2.0;
			}
			if (num2 >= 0.95)
			{
				num2 = 0.95;
			}
			if (num3 >= 0.95)
			{
				num3 = 0.95;
			}
			double num4 = num2;
			float num5 = (float)(num2 * 0.3);
			float num6 = (float)(num2 * 0.1);
			double num7 = (double)GameGeneral.GlobalRNG.Next(1, 101) / 100.0;
			if (num7 < (double)num6)
			{
				switch (method_6().Damage.FireIntensity)
				{
				default:
					CauseFire(FireIntensityLevel.Severe);
					break;
				case FireIntensityLevel.Severe:
					CauseFire(FireIntensityLevel.Conflagration);
					break;
				case FireIntensityLevel.Conflagration:
					break;
				}
			}
			else if (num7 < (double)num5)
			{
				switch (method_6().Damage.FireIntensity)
				{
				default:
					CauseFire(FireIntensityLevel.Major);
					break;
				case FireIntensityLevel.Major:
					CauseFire(FireIntensityLevel.Severe);
					break;
				case FireIntensityLevel.Severe:
				case FireIntensityLevel.Conflagration:
					break;
				}
			}
			else if (num7 < num4)
			{
				switch (method_6().Damage.FireIntensity)
				{
				default:
					CauseFire(FireIntensityLevel.Minor);
					break;
				case FireIntensityLevel.Minor:
					CauseFire(FireIntensityLevel.Major);
					break;
				case FireIntensityLevel.Major:
				case FireIntensityLevel.Severe:
				case FireIntensityLevel.Conflagration:
					break;
				}
			}
			double num8 = num3;
			float num9 = (float)(num3 * 0.3);
			float num10 = (float)(num3 * 0.1);
			double num11 = (double)GameGeneral.GlobalRNG.Next(1, 101) / 100.0;
			if (num11 < (double)num10)
			{
				switch (method_6().Damage.FloodIntensity)
				{
				default:
					CauseFlooding(FloodingIntensityLevel.Severe);
					break;
				case FloodingIntensityLevel.Severe:
					CauseFlooding(FloodingIntensityLevel.Capsizing);
					break;
				case FloodingIntensityLevel.Capsizing:
					break;
				}
			}
			else if (num11 < (double)num9)
			{
				switch (method_6().Damage.FloodIntensity)
				{
				default:
					CauseFlooding(FloodingIntensityLevel.Major);
					break;
				case FloodingIntensityLevel.Major:
					CauseFlooding(FloodingIntensityLevel.Severe);
					break;
				case FloodingIntensityLevel.Severe:
				case FloodingIntensityLevel.Capsizing:
					break;
				}
			}
			else if (num11 < num8)
			{
				switch (method_6().Damage.FloodIntensity)
				{
				default:
					CauseFlooding(FloodingIntensityLevel.Minor);
					break;
				case FloodingIntensityLevel.Minor:
					CauseFlooding(FloodingIntensityLevel.Major);
					break;
				case FloodingIntensityLevel.Major:
				case FloodingIntensityLevel.Severe:
				case FloodingIntensityLevel.Capsizing:
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100830", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
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
			if (theWeapon.Warheads[0].Type == Warhead.WarheadType.Weapon)
			{
				theWeapon = theWeapon.Warheads[0].get_CarriedWeapon(theWeapon.ParentScen);
			}
			Warhead warhead = theWeapon.Warheads[0];
			double num4;
			double num5 = default(double);
			if (!warhead.get_IsNuclear(theWeapon.ParentScen) && !warhead.get_IsAirburst(theWeapon, myUnit))
			{
				num4 = ((myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) == 0f || warhead.Type == Warhead.WarheadType.HEAT || warhead.Type == Warhead.WarheadType.Torpedo_ASWOptimized) ? ((double)(theWeapon.ArmorPenetrationPercent(GlobalVariables.ArmorRating.Heavy, myUnit.VisualSizeClass) / 100f)) : 0.0);
				if (((Submarine)myUnit).Flags.DoubleHull)
				{
					Warhead? warhead2 = theWeapon.Warheads.FirstOrDefault();
					if (warhead2 != null && warhead2.Type != Warhead.WarheadType.Torpedo_ASWOptimized)
					{
						num4 *= 0.5;
					}
				}
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
			Module_Unit.Unit explodingUnit = ((theUnguidedWeapon != null) ? ((Module_Unit.Unit)theUnguidedWeapon) : ((Module_Unit.Unit)theWeapon));
			if (method_6().Flags.DoubleHull)
			{
				num4 *= 0.8;
			}
			if (num4 > 0.0)
			{
				myUnit.ParentScen.AddMessage(Conversions.ToString((int)Math.Round(num4 * 100.0)) + "% penetration achieved", myUnit.Name + " - armor penetrated", LoggedMessage.MessageType.WeaponDamage, 20, theWeapon.ObjectID, null, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				num6 = Math.Round(num4 * (double)warhead.DP, 2);
				if (num4 < 1.0 && warhead.IsExplosive)
				{
					double out_lon = default(double);
					double out_lat = default(double);
					Geodesic_EdWilliams.CalcPoint_Williams(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, (float)(((double)method_6().Beam * 0.5 + 2.0) * 0.000539957), GameGeneral.GlobalRNG.Next(0, 360));
					Expl_Latitude = out_lat;
					Expl_Longitude = out_lon;
					ref Scenario parentScen = ref myUnit.ParentScen;
					Weapon_AI aI;
					Contact thePrimaryTarget = (aI = theWeapon.AI).PrimaryTarget;
					new Explosion(ref parentScen, explodingUnit, ref thePrimaryTarget, Expl_Longitude.Value, Expl_Latitude.Value, Expl_Longitude.Value, Expl_Latitude.Value, theWeapon.CurrentHeading, myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), theWeapon.Type, (float)((double)warhead.DP * (1.0 - num4)), warhead.DP, warhead.Type, warhead.ExplosivesType, null, null, null, null, null, 0, 0);
					aI.PrimaryTarget = thePrimaryTarget;
				}
				else if (!warhead.IsExplosive && !warhead.IsIncendiary)
				{
					myUnit.ParentScen.AddMessage("No armor penetration!", "No armor penetration!", LoggedMessage.MessageType.WeaponDamage, 20, theWeapon.ObjectID, null, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				else
				{
					if (!Expl_Latitude.HasValue || !Expl_Longitude.HasValue)
					{
						ActiveUnit activeUnit = myUnit;
						double Lon = activeUnit.get_Longitude((GlobalVariables.BooleanObject)null);
						ActiveUnit activeUnit2;
						double Lat = (activeUnit2 = myUnit).get_Latitude((GlobalVariables.BooleanObject)null);
						int distance_NM = GameGeneral.GlobalRNG.Next((int)Math.Round(warhead.DP / 2f), (int)Math.Round(warhead.DP * 2f));
						int bearing = GameGeneral.GlobalRNG.Next(0, 360);
						double out_lon2 = default(double);
						double out_lat2 = default(double);
						Geodesic_EdWilliams.CalcPoint_Williams(ref Lon, ref Lat, ref out_lon2, ref out_lat2, ref distance_NM, ref bearing);
						activeUnit2.set_Latitude((GlobalVariables.BooleanObject)null, Lat);
						activeUnit.set_Longitude((GlobalVariables.BooleanObject)null, Lon);
						Expl_Latitude = out_lat2;
						Expl_Longitude = out_lon2;
					}
					if (!warhead.get_IsAirburst(theWeapon, myUnit))
					{
						ref Scenario parentScen2 = ref myUnit.ParentScen;
						Weapon_AI aI;
						Contact thePrimaryTarget = (aI = theWeapon.AI).PrimaryTarget;
						new Explosion(ref parentScen2, explodingUnit, ref thePrimaryTarget, Expl_Longitude.Value, Expl_Latitude.Value, Expl_Longitude.Value, Expl_Latitude.Value, myUnit.CurrentHeading, myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), theWeapon.Type, warhead.DP, warhead.DP, warhead.Type, warhead.ExplosivesType, myUnit, null, null, null, null, 0, 0);
						aI.PrimaryTarget = thePrimaryTarget;
					}
					else
					{
						ref Scenario parentScen3 = ref myUnit.ParentScen;
						Weapon_AI aI;
						Contact thePrimaryTarget = (aI = theWeapon.AI).PrimaryTarget;
						new Explosion(ref parentScen3, explodingUnit, ref thePrimaryTarget, Expl_Longitude.Value, Expl_Latitude.Value, Expl_Longitude.Value, Expl_Latitude.Value, theWeapon.CurrentHeading, myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), theWeapon.Type, warhead.DP, warhead.DP, warhead.Type, warhead.ExplosivesType, null, null, null, null, null, 0, 0);
						aI.PrimaryTarget = thePrimaryTarget;
					}
				}
			}
			else if (!warhead.IsExplosive && !warhead.IsIncendiary)
			{
				myUnit.ParentScen.AddMessage("No armor penetration!", "No armor penetration!", LoggedMessage.MessageType.WeaponDamage, 20, theWeapon.ObjectID, null, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			else
			{
				if (!Expl_Latitude.HasValue || !Expl_Longitude.HasValue)
				{
					double out_lon3 = default(double);
					double out_lat3 = default(double);
					Geodesic_EdWilliams.CalcPoint_Williams(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon3, ref out_lat3, (float)(((double)method_6().Beam * 0.5 + 2.0) * 0.000539957), GameGeneral.GlobalRNG.Next(0, 360));
					Expl_Latitude = out_lat3;
					Expl_Longitude = out_lon3;
				}
				if (warhead.get_IsAirburst(theWeapon, myUnit))
				{
					ref Scenario parentScen4 = ref myUnit.ParentScen;
					Weapon_AI aI;
					Contact thePrimaryTarget = (aI = theWeapon.AI).PrimaryTarget;
					new Explosion(ref parentScen4, explodingUnit, ref thePrimaryTarget, Expl_Longitude.Value, Expl_Latitude.Value, Expl_Longitude.Value, Expl_Latitude.Value, theWeapon.CurrentHeading, myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), theWeapon.Type, warhead.DP, warhead.DP, warhead.Type, warhead.ExplosivesType, null, null, null, null, null, 0, 0);
					aI.PrimaryTarget = thePrimaryTarget;
				}
				else
				{
					ref Scenario parentScen5 = ref myUnit.ParentScen;
					Weapon_AI aI;
					Contact thePrimaryTarget = (aI = theWeapon.AI).PrimaryTarget;
					new Explosion(ref parentScen5, explodingUnit, ref thePrimaryTarget, Expl_Longitude.Value, Expl_Latitude.Value, Expl_Longitude.Value, Expl_Latitude.Value, theWeapon.CurrentHeading, myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), theWeapon.Type, warhead.DP, warhead.DP, warhead.Type, warhead.ExplosivesType, myUnit, null, null, null, null, 0, 0);
					aI.PrimaryTarget = thePrimaryTarget;
				}
			}
			if (Math.Round(num6 + num5, 1) > 0.0)
			{
				myUnit.AddMessage(Misc.RemoveHiddenString(myUnit.Name) + " has suffered weapon damage: " + Conversions.ToString((int)Math.Round(num6 + num5)) + " DPs", myUnit.Name + " damaged", LoggedMessage.MessageType.UnitDamage, 1, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
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
			ex2?.Data.Add("Error at 100831", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void AdjustBlastDamageForArmor(ref float BlastDamage)
	{
		if (method_6().Flags.DoubleHull)
		{
			BlastDamage = (float)((double)BlastDamage * 0.8);
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
			double num = myUnit.get_DamagePts(ScenEditAction: false, (Weapon)null);
			if (Math.Round(DamageYield, 1) > 0.0)
			{
				new WeaponImpact(ref myUnit.ParentScen, myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), WeaponImpact.ImpactType.Kinetic, 0);
				myUnit.AddMessage(myUnit.Name + " has suffered fragmentation damage: " + Conversions.ToString(Math.Round(DamageYield, 1)) + " DPs", myUnit.Name + " damaged", LoggedMessage.MessageType.UnitDamage, 1, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				myUnit.set_DamagePts(ScenEditAction: false, (Weapon)null, myUnit.get_DamagePts(ScenEditAction: false, (Weapon)null) - DamageYield);
				ResolveComponentHits(Warhead.WarheadType.Fragmentation, Warhead.WarheadExplosivesType.Fragmentation, DamageYield, (float)num, 0f, IsAreaEffect: true);
				ResolveProximityDamageToHostedUnits(IsAreaEffect: true);
				RaiseEvent_DamageSustained();
				if (myUnit.get_DamagePts(ScenEditAction: false, (Weapon)null) <= 0f)
				{
					myUnit.set_DamagePts(ScenEditAction: false, (Weapon)null, 0f);
					myUnit.ParentScen.DestroyThisUnit(myUnit, "Nearby fragmentation warhead detonated and destroyed the submarine.", "Weapon Interaction");
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100832", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	static Submarine_Damage()
	{
		Class72.smethod_20();
	}
}
