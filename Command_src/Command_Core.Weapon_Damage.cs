using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Weapon_Damage : ActiveUnit_Damage
{
	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
	}

	public new static Weapon_Damage FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		Weapon_Damage result;
		try
		{
			result = new Weapon_Damage(ref theAU)
			{
				myUnit = theAU
			};
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100977", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Weapon_Damage(ref theAU);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public Weapon_Damage(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
	}

	public override void ResolveDamageFromWeapon(Weapon theWeapon, GeoPoint LaunchPoint, float DistanceFromImpact, float BearingFromImpact, ActiveUnit ExcludedUnit, double? Expl_Latitude, double? Expl_Longitude, float? Expl_Altitude, ref string PreferredAimpoint, bool DirectHit, UnguidedWeapon theUnguidedWeapon)
	{
		if (Module_Unit.IsRemoteSimEntity(myUnit))
		{
			return;
		}
		try
		{
			if (!theWeapon.Flags.Fuze_Proximity && !theWeapon.Flags.Fuze_Combination)
			{
				if (theWeapon.Type == Weapon._WeaponType.LaserDazzler)
				{
					double num = Module_Unit.RangeToPoint_Slant(myUnit, LaunchPoint) / theWeapon.MaxRange_NoTargetType;
					double num2 = 1.0 - num;
					ResolveDamageFromDazzler((float)num2);
				}
				else if (theWeapon.Type == Weapon._WeaponType.Laser)
				{
					float explosivesWeight = theWeapon.Warheads[0].ExplosivesWeight;
					float num3 = LaserWeapon.ApplyLaserAtmosphericAbsorption(LaserWeapon.CalculateLaserPowerAtImpact_NoArbsorption(theWeapon, LaunchPoint, myUnit), theWeapon, LaunchPoint, myUnit);
					GlobalVariables.WeaponFragilityClass specificWeaponTypeFragility = myUnit.GetSpecificWeaponTypeFragility((Weapon)myUnit);
					myUnit.GetLaserToughnessMultiplier(specificWeaponTypeFragility);
					float num4 = LaserWeapon.LaserPk((float)((double)num3 * 0.001), specificWeaponTypeFragility);
					string text = theWeapon.Name + " impacts " + myUnit.Name + ". Muzzle power: " + Conversions.ToString((float)((double)explosivesWeight * 0.001)) + "KW. Power at impact: " + Conversions.ToString(Math.Round((double)num3 * 0.001, 1)) + "KW. Target durability: " + specificWeaponTypeFragility.ToString() + ". Kill probability: " + Conversions.ToString((int)Math.Round(num4 * 100f)) + "%. ";
					float num5 = (float)GameGeneral.GlobalRNG.NextDouble();
					text = text + "Result: " + Conversions.ToString((int)Math.Round(num5 * 100f));
					if (num5 < num4)
					{
						LastWeaponHit = theWeapon;
						text += " - SUCCESS - Target destroyed";
						myUnit.ParentScen.DestroyThisUnit(myUnit, text, "Weapon Interaction");
					}
					else
					{
						text += " - FAILURE - Target was hit but survived";
						myUnit.ParentScen.AddMessage(text, "Laser impact failed", LoggedMessage.MessageType.WeaponDamage, 0, theWeapon.ObjectID, ((ActiveUnit)theWeapon).get_UnitSide(SetSideOnly: false), new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
						LastWeaponHit = theWeapon;
					}
				}
				else
				{
					LastWeaponHit = theWeapon;
					myUnit.ParentScen.DestroyThisUnit(myUnit, $"{theWeapon.Name} has involved in the destruction of this unit/weapon, export WeaponEndgame data for more information.", "Weapon Interaction");
				}
				return;
			}
			int num6 = (int)Math.Round(GameGeneral.GlobalRNG.NextDouble() * 100.0);
			int num7 = num6;
			int num8 = default(int);
			if (num7 > 20)
			{
				num8 = ((num7 <= 40) ? 80 : ((num7 <= 60) ? 40 : ((num7 > 80) ? 10 : 20)));
			}
			else
			{
				myUnit.ParentScen.DestroyThisUnit(myUnit, $"{theWeapon.Name} has involved in the destruction of this unit/weapon, export WeaponEndgame data for more information.", "Weapon Interaction");
			}
			if (num6 > 20)
			{
				num6 = (int)Math.Round(GameGeneral.GlobalRNG.NextDouble() * 100.0);
				if (num6 <= num8)
				{
					LastWeaponHit = theWeapon;
					myUnit.ParentScen.DestroyThisUnit(myUnit, $"{theWeapon.Name} has involved in the destruction of this unit/weapon, export WeaponEndgame data for more information.", "Weapon Interaction");
				}
				else
				{
					myUnit.ParentScen.AddMessage("Weapon: " + theWeapon.Name + " caused no or unsufficient proximity frag damage to target: " + myUnit.Name, "Insufficient frag damage", LoggedMessage.MessageType.WeaponDamage, 0, theWeapon.ObjectID, ((ActiveUnit)theWeapon).get_UnitSide(SetSideOnly: false), new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100978", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	static Weapon_Damage()
	{
		Class72.smethod_20();
	}
}
