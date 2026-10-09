using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class RocketMaxSpeed
{
	[CompilerGenerated]
	private double double_0;

	[CompilerGenerated]
	private double double_1;

	[CompilerGenerated]
	private double double_2;

	[CompilerGenerated]
	private double double_3;

	[CompilerGenerated]
	private float float_0;

	[CompilerGenerated]
	private float float_1;

	private static readonly Dictionary<GlobalVariables.TechGenerationClass, double[]> dictionary_0;

	private readonly double[,] double_4;

	private readonly double double_5;

	private readonly GlobalVariables.TechGenerationClass techGenerationClass_0;

	private bool bool_0;

	private double double_6;

	public double MassLaunch
	{
		[CompilerGenerated]
		get
		{
			return double_0;
		}
	}

	public double MassBurnout
	{
		[CompilerGenerated]
		get
		{
			return double_1;
		}
	}

	public double FrontalArea
	{
		[CompilerGenerated]
		get
		{
			return double_2;
		}
	}

	public double BurnTime
	{
		[CompilerGenerated]
		get
		{
			return double_3;
		}
	}

	public float Length
	{
		[CompilerGenerated]
		get
		{
			return float_0;
		}
	}

	public float Diameter
	{
		[CompilerGenerated]
		get
		{
			return float_1;
		}
	}

	public double CalibratedThrust => double_5;

	public double CalibratedIsp
	{
		get
		{
			double num = (double_0 - double_1) / double_3;
			return double_5 / (9.80665 * num);
		}
	}

	public bool IspIsPlausibleForGeneration
	{
		get
		{
			double[] array = dictionary_0[techGenerationClass_0];
			if (CalibratedIsp >= array[0])
			{
				return CalibratedIsp <= array[1];
			}
			return false;
		}
	}

	public bool ThrustWasClamped => bool_0;

	static RocketMaxSpeed()
	{
		Class72.smethod_20();
		dictionary_0 = new Dictionary<GlobalVariables.TechGenerationClass, double[]>
		{
			{
				GlobalVariables.TechGenerationClass.None,
				new double[2] { 180.0, 220.0 }
			},
			{
				GlobalVariables.TechGenerationClass.NotApplicable,
				new double[2] { 180.0, 220.0 }
			},
			{
				GlobalVariables.TechGenerationClass.const_2,
				new double[2] { 170.0, 190.0 }
			},
			{
				GlobalVariables.TechGenerationClass.const_3,
				new double[2] { 185.0, 205.0 }
			},
			{
				GlobalVariables.TechGenerationClass.const_4,
				new double[2] { 200.0, 215.0 }
			},
			{
				GlobalVariables.TechGenerationClass.const_5,
				new double[2] { 210.0, 220.0 }
			},
			{
				GlobalVariables.TechGenerationClass.const_6,
				new double[2] { 215.0, 225.0 }
			},
			{
				GlobalVariables.TechGenerationClass.const_7,
				new double[2] { 220.0, 232.0 }
			},
			{
				GlobalVariables.TechGenerationClass.const_8,
				new double[2] { 225.0, 237.0 }
			},
			{
				GlobalVariables.TechGenerationClass.const_9,
				new double[2] { 230.0, 242.0 }
			},
			{
				GlobalVariables.TechGenerationClass.const_10,
				new double[2] { 235.0, 247.0 }
			},
			{
				GlobalVariables.TechGenerationClass.const_11,
				new double[2] { 240.0, 252.0 }
			},
			{
				GlobalVariables.TechGenerationClass.const_12,
				new double[2] { 245.0, 255.0 }
			},
			{
				GlobalVariables.TechGenerationClass.const_13,
				new double[2] { 248.0, 258.0 }
			},
			{
				GlobalVariables.TechGenerationClass.const_14,
				new double[2] { 252.0, 262.0 }
			},
			{
				GlobalVariables.TechGenerationClass.const_15,
				new double[2] { 255.0, 265.0 }
			},
			{
				GlobalVariables.TechGenerationClass.const_16,
				new double[2] { 258.0, 270.0 }
			},
			{
				GlobalVariables.TechGenerationClass.const_17,
				new double[2] { 262.0, 275.0 }
			}
		};
	}

	public RocketMaxSpeed(Weapon theWeapon, double massLaunch, double massBurnout, double frontalArea, double burnTime, float length, float diameter, AltBand[] nominalBands, GlobalVariables.TechGenerationClass techGen)
	{
		bool_0 = false;
		if (nominalBands != null && nominalBands.Length >= 1)
		{
			if (massLaunch <= massBurnout)
			{
				throw new ArgumentException("MassLaunch must be greater than MassBurnout.");
			}
			if (burnTime <= 0.0)
			{
				throw new ArgumentException("BurnTime must be positive.");
			}
			double_0 = massLaunch;
			double_1 = massBurnout;
			double_2 = frontalArea;
			double_3 = burnTime;
			float_0 = length;
			float_1 = diameter;
			techGenerationClass_0 = techGen;
			double_4 = new double[nominalBands.Length - 1 + 1, 3];
			int num = nominalBands.Length - 1;
			for (int i = 0; i <= num; i++)
			{
				int num2 = ((i != nominalBands.Length - 1) ? ((int)Math.Round(nominalBands[i].MaxAlt)) : 10973);
				double num3 = (double)nominalBands[i].Speed_Cruise * 0.514444;
				double num4 = Physics.ComputeMach(num2, Weapon_Kinematics.EstimateLaunchSpeedKnots(num2));
				double num5 = SpeedOfSound(num2);
				if (num4 * num5 >= num3)
				{
					num4 = num3 * 0.5 / num5;
				}
				double_4[i, 0] = num2;
				double_4[i, 1] = num4;
				double_4[i, 2] = num3;
			}
			if (!theWeapon.ParentScen.Cache_RocketThrusts.TryGetValue(theWeapon.DBID, out double_5))
			{
				double_5 = method_1(theWeapon);
				theWeapon.ParentScen.Cache_RocketThrusts.TryAdd(theWeapon.DBID, double_5);
			}
			return;
		}
		throw new ArgumentException("At least one altitude band is required.");
	}

	public void ComputeBurnoutSpeed(Weapon theWeapon, double altitudeMetre, double launchMach, out double burnoutSpeedMs, out double burnoutMach)
	{
		double double_ = AirDensity(altitudeMetre);
		double num = SpeedOfSound(altitudeMetre);
		double double_2 = launchMach * num;
		burnoutSpeedMs = method_2(theWeapon, double_2, double_5, double_, num, altitudeMetre);
		burnoutMach = burnoutSpeedMs / num;
	}

	private double method_0(double double_7)
	{
		double num = (double_0 - double_1) / double_3;
		return double_7 * 9.80665 * num;
	}

	private double method_1(Weapon weapon_0)
	{
		try
		{
			int length = double_4.GetLength(0);
			double num = double_4[length - 1, 0];
			double num2 = double_4[length - 1, 1];
			double num3 = double_4[length - 1, 2];
			double double_ = AirDensity(num);
			double num4 = SpeedOfSound(num);
			double num5 = num2 * num4;
			if (num5 >= num3)
			{
				throw new InvalidOperationException($"At {num:F0} m: nominal launch speed ({num5:F1} m/s) " + $">= nominal burnout speed ({num3:F1} m/s). " + "Check NominalLaunchMach values in the altitude band data.");
			}
			double num6 = 0.0;
			double num7 = 50000000.0;
			if (method_2(weapon_0, num5, num7, double_, num4, num) < num3)
			{
				double[] array = dictionary_0[techGenerationClass_0];
				double double_2 = (array[0] + array[1]) / 2.0;
				double result = method_0(double_2);
				bool_0 = true;
				return result;
			}
			int num8 = 1;
			do
			{
				double num9 = (num6 + num7) / 2.0;
				double num10 = method_2(weapon_0, num5, num9, double_, num4, num);
				if (!(Math.Abs(num10 - num3) < 0.1))
				{
					if (num10 < num3)
					{
						num6 = num9;
					}
					else
					{
						num7 = num9;
					}
					num8++;
					continue;
				}
				return num9;
			}
			while (num8 <= 80);
			return (num6 + num7) / 2.0;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private double method_2(Weapon weapon_0, double double_7, double double_8, double double_9, double double_10, double double_11)
	{
		double num = double_7;
		double num2 = 0.0;
		double num3 = double_3;
		if (num3 < 10.0)
		{
			double_6 = 0.1;
		}
		else if (num3 < 60.0)
		{
			double_6 = 0.5;
		}
		else
		{
			double_6 = 1.0;
		}
		for (; num2 < double_3; num2 += double_6)
		{
			if (num2 + double_6 > double_3)
			{
				double_6 = double_3 - num2;
			}
			double num4 = double_6 * method_3(weapon_0, num, num2, double_8, double_9, double_10, double_11);
			double num5 = double_6 * method_3(weapon_0, num + num4 / 2.0, num2 + double_6 / 2.0, double_8, double_9, double_10, double_11);
			double num6 = double_6 * method_3(weapon_0, num + num5 / 2.0, num2 + double_6 / 2.0, double_8, double_9, double_10, double_11);
			double num7 = double_6 * method_3(weapon_0, num + num6, num2 + double_6, double_8, double_9, double_10, double_11);
			num += (num4 + 2.0 * num5 + 2.0 * num6 + num7) / 6.0;
		}
		return num;
	}

	private double method_3(Weapon weapon_0, double double_7, double double_8, double double_9, double double_10, double double_11, double double_12)
	{
		double num = double_0 + (double_1 - double_0) * Math.Min(double_8 / double_3, 1.0);
		return (double_9 - method_4(weapon_0, double_7, double_10, double_12)) / num;
	}

	private double method_4(Weapon weapon_0, double double_7, double double_8, double double_9)
	{
		float theSpeed_kts = (float)((double)(float)Math.Max(double_7, 1.0) / 0.514444);
		double num = Weapon.DragCoefficient_AAWmissile(weapon_0, (float)double_9, theSpeed_kts, float_0, float_1);
		if (double.IsNaN(num) || double.IsInfinity(num) || num < 0.0)
		{
			num = 0.3;
		}
		return 0.5 * double_8 * double_7 * double_7 * num * double_2;
	}

	public static double AirDensity(double h)
	{
		double T = default(double);
		double p = default(double);
		AtmosphereTP(h, ref T, ref p);
		return p / (287.058 * T);
	}

	public static double SpeedOfSound(double h)
	{
		double T = default(double);
		double p = default(double);
		AtmosphereTP(h, ref T, ref p);
		return Math.Sqrt(401.8812 * T);
	}

	public static void AtmosphereTP(double h, ref double T, ref double p)
	{
		double[] array = new double[7] { 0.0, 11000.0, 20000.0, 32000.0, 47000.0, 51000.0, 71000.0 };
		double[] array2 = new double[7] { 288.15, 216.65, 216.65, 228.65, 270.65, 270.65, 214.65 };
		double[] array3 = new double[7] { 101325.0, 22632.1, 5474.89, 868.019, 110.906, 66.9389, 3.95642 };
		double[] array4 = new double[7] { -0.0065, 0.0, 0.001, 0.0028, 0.0, -0.0028, -0.002 };
		h = Math.Max(0.0, Math.Min(h, 86000.0));
		int num = array.Length - 1;
		while (num > 0 && !(h >= array[num]))
		{
			num--;
		}
		double num2 = h - array[num];
		if (Math.Abs(array4[num]) < 1E-12)
		{
			T = array2[num];
			p = array3[num] * Math.Exp(-9.80665 * num2 / (287.058 * T));
		}
		else
		{
			T = array2[num] + array4[num] * num2;
			p = array3[num] * Math.Pow(T / array2[num], -9.80665 / (array4[num] * 287.058));
		}
	}
}
