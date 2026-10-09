using System;
using System.Diagnostics;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
internal sealed class LaserWeapon
{
	internal static float LaserPk(float impactPowerKW, GlobalVariables.WeaponFragilityClass fragility)
	{
		float num;
		float num2;
		switch (fragility)
		{
		default:
			throw new ArgumentOutOfRangeException("fragility", "Unknown fragility class.");
		case GlobalVariables.WeaponFragilityClass.VeryFragile:
			num = 5f;
			num2 = 0.8f;
			break;
		case GlobalVariables.WeaponFragilityClass.Fragile:
			num = 20f;
			num2 = 0.25f;
			break;
		case GlobalVariables.WeaponFragilityClass.Medium:
			num = 60f;
			num2 = 0.08f;
			break;
		case GlobalVariables.WeaponFragilityClass.Tough:
			num = 150f;
			num2 = 0.035f;
			break;
		}
		float num3 = (0f - num2) * (impactPowerKW - num);
		if (num3 > 700f)
		{
			return 0f;
		}
		if (num3 < -700f)
		{
			return 1f;
		}
		return (float)(1.0 / (1.0 + Math.Exp(num3)));
	}

	internal static float CalculateLaserPowerAtImpact_NoArbsorption(Weapon theLaserWeapon, GeoPoint theLaunchPoint, Module_Unit.Unit theTarget)
	{
		float result;
		try
		{
			float explosivesWeight = theLaserWeapon.Warheads[0].ExplosivesWeight;
			if (explosivesWeight <= 0f)
			{
				result = 0f;
			}
			else
			{
				float num = (float)((double)theLaunchPoint.RangeToPoint_Slant(new Geopoint_Struct(theTarget.get_Longitude((GlobalVariables.BooleanObject)null), theTarget.get_Latitude((GlobalVariables.BooleanObject)null))) * 1852.0);
				if (num <= 0f)
				{
					result = explosivesWeight;
				}
				else
				{
					float num2;
					float num3;
					float num4;
					switch (theLaserWeapon.Warheads[0].Type)
					{
					default:
						num2 = 0.04f;
						num3 = 1.5f;
						num4 = 0.02f;
						break;
					case Warhead.WarheadType.Laser_COIL:
						num2 = 0.04f;
						num3 = 1.5f;
						num4 = 0.015f;
						break;
					case Warhead.WarheadType.Laser_CarbonDioxide:
						num2 = 0.05f;
						num3 = 2.5f;
						num4 = 0.02f;
						break;
					case Warhead.WarheadType.Laser_DeuteriumFluoride:
						num2 = 0.04f;
						num3 = 2f;
						num4 = 0.02f;
						break;
					case Warhead.WarheadType.Laser_SolidStateFiber:
						num2 = 0.03f;
						num3 = 0.7f;
						num4 = 0.01f;
						break;
					}
					if ((double)num2 < 0.001)
					{
						num2 = 0.001f;
					}
					if (num3 < 0f)
					{
						num3 = 0f;
					}
					if (num4 < 0f)
					{
						num4 = 0f;
					}
					double num5 = theLaserWeapon.Warheads[0].Type switch
					{
						Warhead.WarheadType.Laser_COIL => 1.315, 
						Warhead.WarheadType.Laser_CarbonDioxide => 10.6, 
						Warhead.WarheadType.Laser_DeuteriumFluoride => 3.8, 
						Warhead.WarheadType.Laser_SolidStateFiber => 1.06, 
						_ => 1.06, 
					} * 1E-06 / (Math.PI * (double)num2);
					double num6 = num3;
					if (num6 < 0.1)
					{
						num6 = 0.1;
					}
					double num7 = num5 * num6;
					double num8 = (double)num2 + num7 * (double)num;
					if (num8 < 0.001)
					{
						num8 = 0.001;
					}
					float num9 = (float)((double)num2 / num8);
					num9 *= num9;
					if (num9 < 0f)
					{
						num9 = 0f;
					}
					if (num9 > 1f)
					{
						num9 = 1f;
					}
					float num10 = (float)((double)num / 1000.0);
					float num11 = num4 * num10;
					float num12 = (float)Math.Pow(10.0, (double)(0f - num11) / 10.0);
					if (num12 < 0f)
					{
						num12 = 0f;
					}
					if (num12 > 1f)
					{
						num12 = 1f;
					}
					result = explosivesWeight * num9 * num12;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 10011205315", "");
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

	internal static float ApplyLaserAtmosphericAbsorption(float MuzzlePower, Weapon theLaserWeapon, GeoPoint theLaunchPoint, Module_Unit.Unit theTarget)
	{
		float result;
		try
		{
			float num = MuzzlePower;
			if (num <= 0f)
			{
				result = 0f;
			}
			else if (theLaunchPoint.Altitude > 12000f && theTarget.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > 12000f)
			{
				result = num;
			}
			else
			{
				double num2 = (double)theLaunchPoint.RangeToPoint_Slant(new Geopoint_Struct(theTarget.get_Longitude((GlobalVariables.BooleanObject)null), theTarget.get_Latitude((GlobalVariables.BooleanObject)null))) * 1852.0;
				if (num2 <= 0.0)
				{
					result = num;
				}
				else
				{
					double num3 = num2 / 1000.0;
					double num4;
					int num5;
					switch (theLaserWeapon.Warheads[0].Type)
					{
					default:
						num4 = 1.06;
						num5 = 8;
						break;
					case Warhead.WarheadType.Laser_COIL:
						num4 = 1.315;
						num5 = 8;
						break;
					case Warhead.WarheadType.Laser_CarbonDioxide:
						num4 = 10.6;
						num5 = 8;
						break;
					case Warhead.WarheadType.Laser_DeuteriumFluoride:
						num4 = 3.8;
						num5 = 8;
						break;
					case Warhead.WarheadType.Laser_SolidStateFiber:
						num4 = 1.06;
						num5 = 8;
						break;
					}
					int num6 = num5;
					if (num6 < 2)
					{
						num6 = 2;
					}
					double num7 = theLaunchPoint.Altitude;
					double num8 = theTarget.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
					double num9 = 0.0;
					int num10 = num6 - 1;
					for (int i = 0; i <= num10; i++)
					{
						double num11 = (double)i / (double)num6;
						double num12 = (double)(i + 1) / (double)num6;
						double num13 = (num11 + num12) * 0.5;
						double num14 = num7 + (num8 - num7) * num13;
						double num15 = num3 / (double)num6;
						double num16 = smethod_0(num7 + (num8 - num7) * num11, num7 + (num8 - num7) * num12, 12000.0);
						if (!(num16 <= 0.0))
						{
							double num17 = num15 * num16;
							Weather.WeatherProfile weatherProfile = Weather.get_WeatherAtThisTimeAndPlace(theLaserWeapon.ParentScen, theTarget.get_Latitude((GlobalVariables.BooleanObject)null), theTarget.get_Longitude((GlobalVariables.BooleanObject)null), (int)Math.Round(num14));
							double num18 = smethod_1(num14);
							double num19 = ((num4 >= 8.0) ? 0.2 : ((!(num4 >= 3.0)) ? 0.08 : 0.12));
							num19 *= num18;
							float rainfallRate = weatherProfile.RainfallRate;
							double num20 = ((rainfallRate > 40f) ? 8.0 : ((rainfallRate > 30f) ? 5.0 : ((rainfallRate > 20f) ? 3.0 : ((rainfallRate > 10f) ? 1.8 : ((!(rainfallRate > 0f)) ? 0.0 : 0.9)))));
							if (num4 >= 8.0)
							{
								num20 *= 1.2;
							}
							else if (num4 >= 3.0)
							{
								num20 *= 1.1;
							}
							double num21 = weatherProfile.FractionUnderRain;
							if (num21 < 0.0)
							{
								num21 = 0.0;
							}
							if (num21 > 1.0)
							{
								num21 = 1.0;
							}
							num9 += num19 * num17;
							num9 += num20 * num21 * num17;
						}
					}
					double num22 = Math.Pow(10.0, (0.0 - num9) / 10.0);
					if (num22 < 0.0)
					{
						num22 = 0.0;
					}
					if (num22 > 1.0)
					{
						num22 = 1.0;
					}
					num = (float)((double)num * num22);
					if (num < 0f)
					{
						num = 0f;
					}
					result = num;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 10011205314", "");
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

	private static double smethod_0(double double_0, double double_1, double double_2)
	{
		if (double_0 <= double_2 && double_1 <= double_2)
		{
			return 1.0;
		}
		if (double_0 >= double_2 && double_1 >= double_2)
		{
			return 0.0;
		}
		double num = double_1 - double_0;
		if (Math.Abs(num) < 1E-06)
		{
			return 0.0;
		}
		double num2 = (double_2 - double_0) / num;
		if (num2 < 0.0)
		{
			num2 = 0.0;
		}
		if (num2 > 1.0)
		{
			num2 = 1.0;
		}
		if (double_0 < double_2 && double_1 > double_2)
		{
			return num2;
		}
		return 1.0 - num2;
	}

	private static double smethod_1(double double_0)
	{
		if (double_0 < 0.0)
		{
			double_0 = 0.0;
		}
		double num = 8500.0;
		double num2 = Math.Exp((0.0 - double_0) / num);
		if (num2 < 0.0)
		{
			num2 = 0.0;
		}
		if (num2 > 1.0)
		{
			num2 = 1.0;
		}
		return num2;
	}

	public static (double DamagePoints, double PenetrationProbability) CalculateLaserDamage(double powerAtImpactWatts, double dwellTimeSeconds, Warhead.WarheadType laserType, GlobalVariables.ArmorRating armorClass)
	{
		double num = powerAtImpactWatts * dwellTimeSeconds;
		double num2 = smethod_2(laserType, armorClass);
		double num3 = num * num2;
		double item = num3 / 4184000.0;
		double double_ = smethod_3(armorClass);
		double item2 = smethod_4(num3, double_);
		if (armorClass != GlobalVariables.ArmorRating.Undefined)
		{
			double_ = smethod_3(armorClass);
			item2 = smethod_4(num3, double_);
		}
		return (DamagePoints: item, PenetrationProbability: item2);
	}

	private static double smethod_2(Warhead.WarheadType warheadType_0, GlobalVariables.ArmorRating armorRating_0)
	{
		switch (warheadType_0)
		{
		default:
			return 0.15;
		case Warhead.WarheadType.Laser_COIL:
		{
			GlobalVariables.ArmorRating armorRating4 = armorRating_0;
			switch (armorRating4)
			{
			case GlobalVariables.ArmorRating.None:
				return 0.65;
			case GlobalVariables.ArmorRating.Armor_HMG:
				return 0.4;
			case GlobalVariables.ArmorRating.RHA_20mm:
			case (GlobalVariables.ArmorRating)1021:
			case (GlobalVariables.ArmorRating)1022:
			case (GlobalVariables.ArmorRating)1023:
			case (GlobalVariables.ArmorRating)1024:
			case GlobalVariables.ArmorRating.RHA_25mm:
			case (GlobalVariables.ArmorRating)1026:
			case (GlobalVariables.ArmorRating)1027:
			case (GlobalVariables.ArmorRating)1028:
			case (GlobalVariables.ArmorRating)1029:
			case GlobalVariables.ArmorRating.RHA_30mm:
			case (GlobalVariables.ArmorRating)1031:
			case (GlobalVariables.ArmorRating)1032:
			case (GlobalVariables.ArmorRating)1033:
			case (GlobalVariables.ArmorRating)1034:
			case GlobalVariables.ArmorRating.RHA_35mm:
				return 0.28;
			default:
				switch (armorRating4)
				{
				case GlobalVariables.ArmorRating.Light:
					return 0.2;
				case GlobalVariables.ArmorRating.Medium:
					return 0.13;
				default:
					return 0.13;
				case GlobalVariables.ArmorRating.Heavy:
				case GlobalVariables.ArmorRating.Special:
					return 0.07;
				}
			case GlobalVariables.ArmorRating.Armor_Handgun:
			case GlobalVariables.ArmorRating.Armor_Rifle:
				return 0.5;
			}
		}
		case Warhead.WarheadType.Laser_CarbonDioxide:
		{
			GlobalVariables.ArmorRating armorRating3 = armorRating_0;
			switch (armorRating3)
			{
			case GlobalVariables.ArmorRating.None:
				return 0.75;
			case GlobalVariables.ArmorRating.Armor_HMG:
				return 0.55;
			case GlobalVariables.ArmorRating.RHA_20mm:
			case (GlobalVariables.ArmorRating)1021:
			case (GlobalVariables.ArmorRating)1022:
			case (GlobalVariables.ArmorRating)1023:
			case (GlobalVariables.ArmorRating)1024:
			case GlobalVariables.ArmorRating.RHA_25mm:
			case (GlobalVariables.ArmorRating)1026:
			case (GlobalVariables.ArmorRating)1027:
			case (GlobalVariables.ArmorRating)1028:
			case (GlobalVariables.ArmorRating)1029:
			case GlobalVariables.ArmorRating.RHA_30mm:
			case (GlobalVariables.ArmorRating)1031:
			case (GlobalVariables.ArmorRating)1032:
			case (GlobalVariables.ArmorRating)1033:
			case (GlobalVariables.ArmorRating)1034:
			case GlobalVariables.ArmorRating.RHA_35mm:
				return 0.4;
			default:
				switch (armorRating3)
				{
				case GlobalVariables.ArmorRating.Light:
					return 0.3;
				case GlobalVariables.ArmorRating.Medium:
					return 0.2;
				default:
					return 0.2;
				case GlobalVariables.ArmorRating.Heavy:
				case GlobalVariables.ArmorRating.Special:
					return 0.12;
				}
			case GlobalVariables.ArmorRating.Armor_Handgun:
			case GlobalVariables.ArmorRating.Armor_Rifle:
				return 0.65;
			}
		}
		case Warhead.WarheadType.Laser_DeuteriumFluoride:
		{
			GlobalVariables.ArmorRating armorRating2 = armorRating_0;
			switch (armorRating2)
			{
			case GlobalVariables.ArmorRating.None:
				return 0.7;
			case GlobalVariables.ArmorRating.Armor_HMG:
				return 0.5;
			case GlobalVariables.ArmorRating.RHA_20mm:
			case (GlobalVariables.ArmorRating)1021:
			case (GlobalVariables.ArmorRating)1022:
			case (GlobalVariables.ArmorRating)1023:
			case (GlobalVariables.ArmorRating)1024:
			case GlobalVariables.ArmorRating.RHA_25mm:
			case (GlobalVariables.ArmorRating)1026:
			case (GlobalVariables.ArmorRating)1027:
			case (GlobalVariables.ArmorRating)1028:
			case (GlobalVariables.ArmorRating)1029:
			case GlobalVariables.ArmorRating.RHA_30mm:
			case (GlobalVariables.ArmorRating)1031:
			case (GlobalVariables.ArmorRating)1032:
			case (GlobalVariables.ArmorRating)1033:
			case (GlobalVariables.ArmorRating)1034:
			case GlobalVariables.ArmorRating.RHA_35mm:
				return 0.38;
			default:
				switch (armorRating2)
				{
				case GlobalVariables.ArmorRating.Light:
					return 0.28;
				case GlobalVariables.ArmorRating.Medium:
					return 0.18;
				default:
					return 0.18;
				case GlobalVariables.ArmorRating.Heavy:
				case GlobalVariables.ArmorRating.Special:
					return 0.1;
				}
			case GlobalVariables.ArmorRating.Armor_Handgun:
			case GlobalVariables.ArmorRating.Armor_Rifle:
				return 0.6;
			}
		}
		case Warhead.WarheadType.Laser_SolidStateFiber:
		{
			GlobalVariables.ArmorRating armorRating = armorRating_0;
			switch (armorRating)
			{
			case GlobalVariables.ArmorRating.None:
				return 0.6;
			case GlobalVariables.ArmorRating.Armor_HMG:
				return 0.35;
			case GlobalVariables.ArmorRating.RHA_20mm:
			case (GlobalVariables.ArmorRating)1021:
			case (GlobalVariables.ArmorRating)1022:
			case (GlobalVariables.ArmorRating)1023:
			case (GlobalVariables.ArmorRating)1024:
			case GlobalVariables.ArmorRating.RHA_25mm:
			case (GlobalVariables.ArmorRating)1026:
			case (GlobalVariables.ArmorRating)1027:
			case (GlobalVariables.ArmorRating)1028:
			case (GlobalVariables.ArmorRating)1029:
			case GlobalVariables.ArmorRating.RHA_30mm:
			case (GlobalVariables.ArmorRating)1031:
			case (GlobalVariables.ArmorRating)1032:
			case (GlobalVariables.ArmorRating)1033:
			case (GlobalVariables.ArmorRating)1034:
			case GlobalVariables.ArmorRating.RHA_35mm:
				return 0.25;
			default:
				switch (armorRating)
				{
				case GlobalVariables.ArmorRating.Light:
					return 0.17;
				case GlobalVariables.ArmorRating.Medium:
					return 0.1;
				default:
					return 0.1;
				case GlobalVariables.ArmorRating.Heavy:
				case GlobalVariables.ArmorRating.Special:
					return 0.05;
				}
			case GlobalVariables.ArmorRating.Armor_Handgun:
			case GlobalVariables.ArmorRating.Armor_Rifle:
				return 0.45;
			}
		}
		}
	}

	private static double smethod_3(GlobalVariables.ArmorRating armorRating_0)
	{
		return armorRating_0 switch
		{
			GlobalVariables.ArmorRating.Armor_Handgun => 2000.0, 
			GlobalVariables.ArmorRating.None => 500.0, 
			GlobalVariables.ArmorRating.Armor_HMG => 25000.0, 
			GlobalVariables.ArmorRating.Armor_Rifle => 8000.0, 
			GlobalVariables.ArmorRating.RHA_25mm => 150000.0, 
			GlobalVariables.ArmorRating.RHA_20mm => 80000.0, 
			GlobalVariables.ArmorRating.Light => 2000000.0, 
			GlobalVariables.ArmorRating.Medium => 10000000.0, 
			GlobalVariables.ArmorRating.Heavy => 50000000.0, 
			GlobalVariables.ArmorRating.Special => 200000000.0, 
			GlobalVariables.ArmorRating.RHA_35mm => 480000.0, 
			GlobalVariables.ArmorRating.RHA_30mm => 280000.0, 
			_ => 10000.0, 
		};
	}

	private static double smethod_4(double double_0, double double_1)
	{
		if (double_1 > 0.0)
		{
			double num = double_0 / double_1;
			double val = 1.0 / (1.0 + Math.Exp(-5.0 * (num - 1.0)));
			return Math.Max(0.0, Math.Min(1.0, val));
		}
		return 1.0;
	}

	static LaserWeapon()
	{
		Class72.smethod_20();
	}
}
