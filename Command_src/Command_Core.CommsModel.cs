using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
internal sealed class CommsModel
{
	internal static bool CommsJammingEquation_Simple_SingleJammer(CommDevice theCommDevice, Sensor theJammingSensor, float theDistance)
	{
		LockRandom lockRandom_ = GameGeneral.GlobalRNG;
		if (!theJammingSensor.get_CanJamThisCommDevice(theCommDevice))
		{
			return true;
		}
		float num = (float)Math.Pow(theJammingSensor.ECM_PeakPower, 0.75);
		if (theDistance <= num)
		{
			double num2 = Math.Min(1.0, 1.5 * (double)(1f - theDistance / num));
			if (theCommDevice.IsSatelliteLink())
			{
				num2 *= 0.333;
			}
			if (num2 > lockRandom_.NextDouble())
			{
				return false;
			}
			return true;
		}
		return true;
	}

	private static double smethod_0(object object_0, object object_1, Sensor sensor_0)
	{
		if (!sensor_0.get_CanJamThisCommDevice((CommDevice)object_1))
		{
			return 0.0;
		}
		double num = smethod_1(((PlatformComponent)object_0).ParentPlatform, ((PlatformComponent)object_1).ParentPlatform);
		double num2 = smethod_1(sensor_0.ParentPlatform, ((PlatformComponent)object_1).ParentPlatform);
		if (num2 < 1.0)
		{
			return double.MaxValue;
		}
		if (num < 1.0)
		{
			return 0.0;
		}
		double num3 = (double)((CommDevice)object_0).Range * 1852.0;
		double num4 = (double)sensor_0.ECM_PeakPower * (double)sensor_0.ECM_Gain;
		double num5 = ((CommDevice)object_0).QualityGrade switch
		{
			CommDevice.EnumCommQuality.TacP => 200.0, 
			CommDevice.EnumCommQuality.GLoc => 50.0, 
			CommDevice.EnumCommQuality.FMV => 800.0, 
			CommDevice.EnumCommQuality.BMD => 5000.0, 
			CommDevice.EnumCommQuality.AAW => 1000.0, 
			_ => 100.0, 
		};
		double num6 = num3 * Math.Sqrt(num4 / num5);
		if (num2 > num6)
		{
			return 0.0;
		}
		double num7 = num4 * Math.Pow(num, 2.0) / (num5 * Math.Pow(num2, 2.0));
		double num8 = smethod_2(((PlatformComponent)object_0).ParentPlatform, ((PlatformComponent)object_1).ParentPlatform, sensor_0.ParentPlatform);
		if (!((CommDevice)object_1).Flags.Broadcast)
		{
			double num9 = Math.Min(1.0, num8 / (Math.PI / 2.0));
			double num10 = ((!((CommDevice)object_1).Flags.Phased_Array_Antenna) ? 100.0 : 1000.0);
			num7 *= 1.0 / (1.0 + (num10 - 1.0) * num9);
		}
		double num11 = 1.0;
		if (((CommDevice)object_0).Flags.LPI)
		{
			num11 = Math.Min(1.0, (double)sensor_0.ECM_Bandwidth / 100000000.0);
			num7 *= num11;
		}
		if (((CommDevice)object_0).IsSatelliteLink() || ((CommDevice)object_1).IsSatelliteLink())
		{
			num7 *= 0.1;
		}
		int techGeneration = (int)sensor_0.TechGeneration;
		int val = (int)CommDevice.InferCommDeviceTechGeneration((CommDevice)object_1);
		int val2 = (int)CommDevice.InferCommDeviceTechGeneration((CommDevice)object_0);
		val = Math.Min(val, val2);
		if (techGeneration >= 2001 && techGeneration <= 2016 && val >= 2001 && val <= 2016)
		{
			int num12 = techGeneration - val;
			double val3 = Math.Pow(2.0, (double)num12 / 2.0);
			val3 = Math.Max(0.125, Math.Min(8.0, val3));
			num7 *= val3;
			if (((CommDevice)object_0).Flags.LPI && num12 >= 3)
			{
				double num13 = Math.Min(1.0, (double)(num12 - 2) / 5.0);
				double num14 = 1.0 + num13 * (1.0 / Math.Max(num11, 0.001) - 1.0);
				num7 *= num14;
			}
		}
		return num7;
	}

	internal static bool CommsJammingEquation_PointToPoint_MultiJammer(CommDevice theSender, CommDevice theReceiver, IEnumerable<Sensor> theJammers)
	{
		LockRandom lockRandom_ = GameGeneral.GlobalRNG;
		int result;
		if (theJammers == null)
		{
			result = 1;
		}
		else
		{
			if (theJammers.Count() != 0)
			{
				double num = 0.0;
				foreach (Sensor theJammer in theJammers)
				{
					num += smethod_0(theSender, theReceiver, theJammer);
				}
				if (num == 0.0)
				{
					return true;
				}
				double num2 = 1.0;
				if (theReceiver.Flags.Jam_Resistant)
				{
					num2 *= 10.0;
				}
				int num3 = Math.Min((int)CommDevice.InferCommDeviceTechGeneration(theReceiver), (int)CommDevice.InferCommDeviceTechGeneration(theSender));
				int num4 = (from j in theJammers
					select (int)j.TechGeneration into g
					where g >= 2001 && g <= 2016
					select g).DefaultIfEmpty(0).Max();
				if (num4 >= 2001 && num3 >= 2001)
				{
					int num5 = num4 - num3;
					double val = Math.Pow(1.5, (0.0 - (double)num5) / 2.0);
					val = Math.Max(0.25, Math.Min(4.0, val));
					num2 *= val;
				}
				if (num < num2)
				{
					return true;
				}
				double num6 = num / num2;
				double val2 = (theReceiver.Flags.DegradesWithRange ? ((1.0 - num2 / num) * 0.8) : (1.0 - 1.0 / (1.0 + (num6 - 1.0) * 3.0)));
				val2 = Math.Max(0.0, Math.Min(1.0, val2));
				if (val2 > lockRandom_.NextDouble())
				{
					return false;
				}
				return true;
			}
			result = 1;
		}
		return (byte)result != 0;
	}

	internal static bool CommsJammingEquation_PointToPoint_SingleJammer(CommDevice theSender, CommDevice theReceiver, Sensor theJammingSensor)
	{
		return CommsJammingEquation_PointToPoint_MultiJammer(theSender, theReceiver, new Sensor[1] { theJammingSensor });
	}

	private static double smethod_1(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1)
	{
		double d = activeUnit_0.get_Latitude((GlobalVariables.BooleanObject)null) * Math.PI / 180.0;
		double d2 = activeUnit_1.get_Latitude((GlobalVariables.BooleanObject)null) * Math.PI / 180.0;
		double num = (activeUnit_1.get_Latitude((GlobalVariables.BooleanObject)null) - activeUnit_0.get_Latitude((GlobalVariables.BooleanObject)null)) * Math.PI / 180.0;
		double num2 = (activeUnit_1.get_Longitude((GlobalVariables.BooleanObject)null) - activeUnit_0.get_Longitude((GlobalVariables.BooleanObject)null)) * Math.PI / 180.0;
		double num3 = Math.Pow(Math.Sin(num / 2.0), 2.0) + Math.Cos(d) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);
		double x = 12742000.0 * Math.Atan2(Math.Sqrt(num3), Math.Sqrt(1.0 - num3));
		double x2 = (double)activeUnit_1.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - (double)activeUnit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
		return Math.Sqrt(Math.Pow(x, 2.0) + Math.Pow(x2, 2.0));
	}

	private static double smethod_2(object object_0, object object_1, object object_2)
	{
		double[] array = smethod_3(object_1, object_0);
		double[] array2 = smethod_3(object_1, object_2);
		double num = Math.Sqrt(Math.Pow(array[0], 2.0) + Math.Pow(array[1], 2.0) + Math.Pow(array[2], 2.0));
		double num2 = Math.Sqrt(Math.Pow(array2[0], 2.0) + Math.Pow(array2[1], 2.0) + Math.Pow(array2[2], 2.0));
		if (!(num < 1.0) && num2 >= 1.0)
		{
			double val = (array[0] * array2[0] + array[1] * array2[1] + array[2] * array2[2]) / (num * num2);
			val = Math.Max(-1.0, Math.Min(1.0, val));
			return Math.Acos(val);
		}
		return 0.0;
	}

	private static double[] smethod_3(object object_0, object object_1)
	{
		Func<ActiveUnit, double[]> obj = [SpecialName] (ActiveUnit p) =>
		{
			double num = p.get_Latitude((GlobalVariables.BooleanObject)null) * Math.PI / 180.0;
			double num2 = p.get_Longitude((GlobalVariables.BooleanObject)null) * Math.PI / 180.0;
			double num3 = 6371000.0 + (double)p.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			return new double[3]
			{
				num3 * Math.Cos(num) * Math.Cos(num2),
				num3 * Math.Cos(num) * Math.Sin(num2),
				num3 * Math.Sin(num)
			};
		};
		double[] array = obj((ActiveUnit)object_0);
		double[] array2 = obj((ActiveUnit)object_1);
		return new double[3]
		{
			array2[0] - array[0],
			array2[1] - array[1],
			array2[2] - array[2]
		};
	}

	static CommsModel()
	{
		Class72.smethod_20();
	}
}
