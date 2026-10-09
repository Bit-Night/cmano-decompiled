using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class KinMod
{
	public enum KinModTier
	{
		Undefined,
		Tier1,
		Tier2,
		Tier3,
		Tier4
	}

	public static (KinModTier Tier, int AgilityScore, List<string> Reasons) GetKinModTier(Weapon w)
	{
		double num = 0.0;
		List<string> list = new List<string>();
		(int, string) tuple = smethod_0(w);
		if (tuple.Item1 != 0)
		{
			num += (double)tuple.Item1;
			list.Add(tuple.Item2);
		}
		if (w.Flags.HOB_AAM)
		{
			num += 5.0;
			list.Add("HOBS Dogfight missile (+5)");
		}
		if (w.Flags.AllAspect_AAM)
		{
			num += 2.0;
			list.Add("All-Aspect (+2)");
		}
		bool num2 = w.Flags.AttitudeControl == Weapon.WeaponFlags.AttitudeControlEnum.Combined || w.Flags.AttitudeControl == Weapon.WeaponFlags.AttitudeControlEnum.NonAerodynamic;
		double num3 = ((w.BurnoutWeight() != 0) ? w.BurnoutWeight() : w.MaxWeight);
		bool flag = w.Flags.HOB_AAM || w.Flags.C_RAM || num3 < 200.0;
		if (num2 && flag)
		{
			num += 3.0;
			list.Add("TVC / non-aero attitude control (+3)");
		}
		if (w.Flags.LOAL || w.Flags.LOAL_CEC)
		{
			num += 1.0;
			list.Add("LOAL (+1)");
		}
		if (w.Flags.CapableVsSeaskimmer)
		{
			num += 1.0;
			list.Add("Capable vs Seaskimmer (+1)");
		}
		if (w.Flags.C_RAM)
		{
			num += 3.0;
			list.Add("C-RAM capable (+3)");
		}
		double num4 = smethod_1(w.MaxRange_NoTargetType);
		if (num4 != 0.0)
		{
			num += num4;
			list.Add("Range " + Conversions.ToString(w.MaxRange_NoTargetType) + " nm ({rMod:+0.0;-0.0})");
		}
		double num5 = smethod_2(w.BurnoutWeight());
		if (num5 != 0.0)
		{
			num += num5;
			list.Add("Weight " + Conversions.ToString(w.BurnoutWeight()) + " kg ({wMod:+0.0;-0.0})");
		}
		int num6 = (int)Math.Round(num);
		KinModTier item = ((num6 >= 10) ? KinModTier.Tier1 : ((num6 >= 6) ? KinModTier.Tier2 : ((num6 >= 3) ? KinModTier.Tier3 : KinModTier.Tier4)));
		return (Tier: item, AgilityScore: num6, Reasons: list);
	}

	private static (int, string) smethod_0(object object_0)
	{
		(int, string) result = default((int, string));
		switch (((Weapon)object_0).Guidance)
		{
		case Weapon.WeaponGuidanceType.Passive:
		case Weapon.WeaponGuidanceType.Inertial_Plus_Passive:
		case Weapon.WeaponGuidanceType.DataLink_Plus_Passive:
		{
			Sensor sensor2 = ((ActiveUnit)object_0).Sensors_Cached.FirstOrDefault();
			if (sensor2 == null)
			{
				break;
			}
			switch (sensor2.Type)
			{
			case Sensor.Sensor_Type.Infrared:
			{
				int num7;
				int num6 = default(int);
				switch (sensor2.TechGeneration)
				{
				default:
					num7 = 4;
					break;
				case GlobalVariables.TechGenerationClass.IR_SingleSpectral:
					num6 = 0;
					num7 = 4;
					break;
				case GlobalVariables.TechGenerationClass.IR_DualSpectral:
					num6 = 1;
					num7 = 4;
					break;
				case GlobalVariables.TechGenerationClass.IR_Imaging_FPA:
					num6 = 2;
					num7 = 4;
					break;
				}
				int num8 = num7 + num6;
				result = (num8, $"Guidance={sensor2.Type.ToString()} gen{Misc.ToEnglishString(sensor2.TechGeneration)} (+{num8})");
				break;
			}
			case Sensor.Sensor_Type.Visual:
			{
				int num4;
				int num3 = default(int);
				switch (sensor2.TechGeneration)
				{
				default:
					num4 = 4;
					break;
				case GlobalVariables.TechGenerationClass.Visual_Gen1:
					num3 = 0;
					num4 = 4;
					break;
				case GlobalVariables.TechGenerationClass.Visual_Gen2:
					num3 = 1;
					num4 = 4;
					break;
				case GlobalVariables.TechGenerationClass.Visual_Gen3:
					num3 = 2;
					num4 = 4;
					break;
				}
				int num5 = num4 + num3;
				result = (num5, $"Guidance={sensor2.Type.ToString()} gen{Misc.ToEnglishString(sensor2.TechGeneration)} (+{num5})");
				break;
			}
			}
			break;
		}
		case Weapon.WeaponGuidanceType.CommandGuided_Datalinked:
			result = (1, $"Guidance={((Weapon)object_0).Guidance.ToString()} (+1)");
			break;
		case Weapon.WeaponGuidanceType.SemiActive:
		case Weapon.WeaponGuidanceType.Inertial_Plus_SemiActive:
		case Weapon.WeaponGuidanceType.Datalink_Plus_SemiActive:
		case Weapon.WeaponGuidanceType.TVM:
			result = (1, $"Guidance={((Weapon)object_0).Guidance.ToString()} (+1)");
			break;
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = (0, null);
			break;
		case Weapon.WeaponGuidanceType.Active:
		case Weapon.WeaponGuidanceType.Datalink_Plus_Active:
		case Weapon.WeaponGuidanceType.Inertial_Plus_Active:
		case Weapon.WeaponGuidanceType.SemiActive_Plus_Active:
		case Weapon.WeaponGuidanceType.TimesharedSemiActive_Plus_Active:
		{
			Sensor sensor = ((ActiveUnit)object_0).Sensors_Cached.FirstOrDefault();
			if (sensor != null)
			{
				Sensor.Sensor_Type type = sensor.Type;
				if (type == Sensor.Sensor_Type.Radar)
				{
					int num = ((sensor.TechGeneration >= GlobalVariables.TechGenerationClass.const_12) ? 1 : 0);
					string arg = ((num <= 0) ? "legacy" : "AESA/modern");
					int num2 = 3 + num;
					result = (num2, $"Guidance=ARH {arg} (+{num2})");
				}
			}
			break;
		}
		}
		return result;
	}

	private static double smethod_1(double? nullable_0)
	{
		double num = ((!nullable_0.HasValue) ? 0.0 : nullable_0.Value);
		if (num <= 0.0)
		{
			return 0.0;
		}
		return smethod_3(-1.5 * Math.Log(num / 80.0, 2.0), -4.0, 3.0);
	}

	private static double smethod_2(double? nullable_0)
	{
		double num = (nullable_0.HasValue ? nullable_0.Value : 0.0);
		if (num <= 0.0)
		{
			return 0.0;
		}
		return smethod_3(-1.5 * Math.Log(num / 250.0, 2.0), -4.0, 2.0);
	}

	private static double smethod_3(double double_0, double double_1, double double_2)
	{
		return Math.Max(double_1, Math.Min(double_2, double_0));
	}

	static KinMod()
	{
		Class72.smethod_20();
	}
}
