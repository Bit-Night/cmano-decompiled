using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CSMaterial;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
internal sealed class LOS
{
	private class Class12
	{
		public int int_0;

		public double double_0;

		public double double_1;

		public bool bool_0;

		[SpecialName]
		public bool method_0()
		{
			return double_0 < double_1;
		}

		[SpecialName]
		public double method_1()
		{
			return double_1 - double_0;
		}

		static Class12()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__13-0
	{
		public float[] $VB$Local_samples;

		public double $VB$Local_Lat_Src;

		public double $VB$Local_Lon_Src;

		public double $VB$Local_Distance_Cartesian;

		public double $VB$Local_X_S;

		public double $VB$Local_Y_S;

		public double $VB$Local_Z_S;

		public double $VB$Local_deltaX;

		public double $VB$Local_deltaY;

		public double $VB$Local_deltaZ;

		public float $VB$Local_Alt_Src;

		public float $VB$Local_Alt_Dest;

		public bool $VB$Local_LandMassCheck;

		public bool $VB$Local_IgnoreRadarHorizon;

		public Scenario $VB$Local_CurrentScen;

		public Side $VB$Local_NatureSide;

		public bool $VB$Local_BlockFound;

		public _Closure$__13-0(_Closure$__13-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_samples = arg0.$VB$Local_samples;
				$VB$Local_Lat_Src = arg0.$VB$Local_Lat_Src;
				$VB$Local_Lon_Src = arg0.$VB$Local_Lon_Src;
				$VB$Local_Distance_Cartesian = arg0.$VB$Local_Distance_Cartesian;
				$VB$Local_X_S = arg0.$VB$Local_X_S;
				$VB$Local_Y_S = arg0.$VB$Local_Y_S;
				$VB$Local_Z_S = arg0.$VB$Local_Z_S;
				$VB$Local_deltaX = arg0.$VB$Local_deltaX;
				$VB$Local_deltaY = arg0.$VB$Local_deltaY;
				$VB$Local_deltaZ = arg0.$VB$Local_deltaZ;
				$VB$Local_Alt_Src = arg0.$VB$Local_Alt_Src;
				$VB$Local_Alt_Dest = arg0.$VB$Local_Alt_Dest;
				$VB$Local_LandMassCheck = arg0.$VB$Local_LandMassCheck;
				$VB$Local_IgnoreRadarHorizon = arg0.$VB$Local_IgnoreRadarHorizon;
				$VB$Local_CurrentScen = arg0.$VB$Local_CurrentScen;
				$VB$Local_NatureSide = arg0.$VB$Local_NatureSide;
				$VB$Local_BlockFound = arg0.$VB$Local_BlockFound;
			}
		}

		[SpecialName]
		internal void _Lambda$__0(Tuple<int, int> range, ParallelLoopState loopstate)
		{
			int item = range.Item1;
			int num = range.Item2 - 1;
			for (int i = item; i <= num; i++)
			{
				if (loopstate.IsStopped)
				{
					break;
				}
				float theDist = $VB$Local_samples[i];
				if (Terrain.TerrainBlocksLOS($VB$Local_Lat_Src, $VB$Local_Lon_Src, theDist, $VB$Local_Distance_Cartesian, $VB$Local_X_S, $VB$Local_Y_S, $VB$Local_Z_S, $VB$Local_deltaX, $VB$Local_deltaY, $VB$Local_deltaZ, $VB$Local_Alt_Src, $VB$Local_Alt_Dest, $VB$Local_LandMassCheck, $VB$Local_IgnoreRadarHorizon, $VB$Local_CurrentScen, $VB$Local_NatureSide))
				{
					$VB$Local_BlockFound = true;
					loopstate.Stop();
					break;
				}
			}
		}

		static _Closure$__13-0()
		{
			Class72.smethod_20();
		}
	}

	private static int int_0;

	private static List<Class12> list_0;

	private static int int_1;

	private static bool bool_0;

	private static readonly ScenarioObject IeeLzJeZjma;

	static LOS()
	{
		Class72.smethod_20();
		int_0 = 0;
		list_0 = new List<Class12>();
		int_1 = 50;
		bool_0 = false;
		IeeLzJeZjma = new ScenarioObject();
	}

	internal static bool DetermineLOS(double Lat_Src, double Lon_Src, float Alt_Src, double Lat_Dest, double Lon_Dest, float Alt_Dest, bool LandMassCheck, Scenario CurrentScen, int ExtraSensorHeight = 0, bool IgnoreRadarHorizon = false, bool considerOverlappingCoordinatesAsValid = false)
	{
		bool result;
		try
		{
			Side natureSide = CurrentScen.GetNatureSide();
			result = smethod_0(Lat_Src, Lon_Src, Lat_Dest, Lon_Dest, Alt_Src + (float)ExtraSensorHeight, Alt_Dest, LandMassCheck, IgnoreRadarHorizon, CurrentScen, natureSide, considerOverlappingCoordinatesAsValid);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100872", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num;
			if (!Debugger.IsAttached)
			{
				num = 0;
			}
			else
			{
				Debugger.Break();
				num = 0;
			}
			result = (byte)num != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private static bool smethod_0(double double_0, double double_1, double double_2, double double_3, float float_0, float float_1, bool bool_1, bool bool_2, Scenario scenario_0, Side side_0, bool bool_3 = false)
	{
		double X = default(double);
		double Y = default(double);
		double Z = default(double);
		Geodesic_Vincenty.ApproxSphericalToCartesian(double_0, double_1, float_0, ref X, ref Y, ref Z);
		double X2 = default(double);
		double Y2 = default(double);
		double Z2 = default(double);
		Geodesic_Vincenty.ApproxSphericalToCartesian(double_2, double_3, float_1, ref X2, ref Y2, ref Z2);
		double num = X2 - X;
		double num2 = Y2 - Y;
		double num3 = Z2 - Z;
		double num4 = Math.Sqrt(num * num + num2 * num2 + num3 * num3);
		int num5 = (int)Math.Floor(num4 / 900.0);
		if (num5 != 0)
		{
			bool flag = false;
			lock (IeeLzJeZjma)
			{
				int_0++;
				if (!bool_0 && int_0 % 25 == 0)
				{
					flag = true;
				}
				else if (bool_0 && int_0 % 500 == 0)
				{
					flag = true;
				}
			}
			if (flag && num5 > 10)
			{
				Class12 @class = smethod_1(double_0, double_1, num5, 900f, num4, X, Y, Z, num, num2, num3, float_0, float_1, bool_1, bool_2, scenario_0, side_0);
				lock (IeeLzJeZjma)
				{
					list_0.Add(@class);
					smethod_2();
				}
				return @class.bool_0;
			}
			return smethod_3(double_0, double_1, num5, 900f, num4, X, Y, Z, num, num2, num3, float_0, float_1, bool_1, bool_2, scenario_0, side_0);
		}
		return bool_3;
	}

	private static Class12 smethod_1(double double_0, double double_1, int int_2, float float_0, double double_2, double double_3, double double_4, double double_5, double double_6, double double_7, double double_8, float float_1, float float_2, bool bool_1, bool bool_2, Scenario scenario_0, Side side_0)
	{
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Restart();
		bool flag = smethod_4(double_0, double_1, int_2, float_0, double_2, double_3, double_4, double_5, double_6, double_7, double_8, float_1, float_2, bool_1, bool_2, scenario_0, side_0);
		stopwatch.Stop();
		double totalMilliseconds = stopwatch.Elapsed.TotalMilliseconds;
		stopwatch.Restart();
		smethod_5(double_0, double_1, int_2, float_0, double_2, double_3, double_4, double_5, double_6, double_7, double_8, float_1, float_2, bool_1, bool_2, scenario_0, side_0);
		stopwatch.Stop();
		double totalMilliseconds2 = stopwatch.Elapsed.TotalMilliseconds;
		return new Class12
		{
			int_0 = int_2,
			double_0 = totalMilliseconds,
			double_1 = totalMilliseconds2,
			bool_0 = flag
		};
	}

	private static void smethod_2()
	{
		if (list_0.Count < 3)
		{
			return;
		}
		List<Class12> list = list_0.Where([SpecialName] (Class12 r) => r.method_0()).ToList();
		List<Class12> list2 = list_0.Where([SpecialName] (Class12 r) => !r.method_0()).ToList();
		if (list.Count > 0 && list2.Count > 0)
		{
			int num = list.Max([SpecialName] (Class12 r) => r.int_0);
			int num2 = list2.Min([SpecialName] (Class12 r) => r.int_0);
			int_1 = (int)Math.Round((double)(num + num2) / 2.0);
			if (list_0.Count >= 8)
			{
				bool_0 = true;
			}
		}
	}

	private static bool smethod_3(double double_0, double double_1, int int_2, float float_0, double double_2, double double_3, double double_4, double double_5, double double_6, double double_7, double double_8, float float_1, float float_2, bool bool_1, bool bool_2, Scenario scenario_0, Side side_0)
	{
		if (int_2 < int_1)
		{
			return smethod_4(double_0, double_1, int_2, float_0, double_2, double_3, double_4, double_5, double_6, double_7, double_8, float_1, float_2, bool_1, bool_2, scenario_0, side_0);
		}
		return smethod_5(double_0, double_1, int_2, float_0, double_2, double_3, double_4, double_5, double_6, double_7, double_8, float_1, float_2, bool_1, bool_2, scenario_0, side_0);
	}

	private static bool smethod_4(double double_0, double double_1, int int_2, float float_0, double double_2, double double_3, double double_4, double double_5, double double_6, double double_7, double double_8, float float_1, float float_2, bool bool_1, bool bool_2, Scenario scenario_0, Side side_0)
	{
		int num = int_2 - 1;
		int num2 = 0;
		while (true)
		{
			if (num2 <= num)
			{
				float theDist = (float)(num2 + 1) * float_0;
				if (Terrain.TerrainBlocksLOS(double_0, double_1, theDist, double_2, double_3, double_4, double_5, double_6, double_7, double_8, float_1, float_2, bool_1, bool_2, scenario_0, side_0))
				{
					break;
				}
				num2++;
				continue;
			}
			return true;
		}
		return false;
	}

	private static bool smethod_5(double double_0, double double_1, int int_2, float float_0, double double_2, double double_3, double double_4, double double_5, double double_6, double double_7, double double_8, float float_1, float float_2, bool bool_1, bool bool_2, Scenario scenario_0, Side side_0)
	{
		_Closure$__13-0 arg = default(_Closure$__13-0);
		_Closure$__13-0 CS$<>8__locals37 = new _Closure$__13-0(arg);
		CS$<>8__locals37.$VB$Local_Lat_Src = double_0;
		CS$<>8__locals37.$VB$Local_Lon_Src = double_1;
		CS$<>8__locals37.$VB$Local_Distance_Cartesian = double_2;
		CS$<>8__locals37.$VB$Local_X_S = double_3;
		CS$<>8__locals37.$VB$Local_Y_S = double_4;
		CS$<>8__locals37.$VB$Local_Z_S = double_5;
		CS$<>8__locals37.$VB$Local_deltaX = double_6;
		CS$<>8__locals37.$VB$Local_deltaY = double_7;
		CS$<>8__locals37.$VB$Local_deltaZ = double_8;
		CS$<>8__locals37.$VB$Local_Alt_Src = float_1;
		CS$<>8__locals37.$VB$Local_Alt_Dest = float_2;
		CS$<>8__locals37.$VB$Local_LandMassCheck = bool_1;
		CS$<>8__locals37.$VB$Local_IgnoreRadarHorizon = bool_2;
		CS$<>8__locals37.$VB$Local_CurrentScen = scenario_0;
		CS$<>8__locals37.$VB$Local_NatureSide = side_0;
		CS$<>8__locals37.$VB$Local_samples = new float[int_2 - 1 + 1];
		int num = int_2 - 1;
		for (int i = 0; i <= num; i++)
		{
			CS$<>8__locals37.$VB$Local_samples[i] = (float)(i + 1) * float_0;
		}
		CS$<>8__locals37.$VB$Local_BlockFound = false;
		int rangeSize = Math.Max(10, int_2 / CSMaterial.Misc.Environment_ProcessorCount);
		Parallel.ForEach(Partitioner.Create(0, CS$<>8__locals37.$VB$Local_samples.Count(), rangeSize), [SpecialName] (Tuple<int, int> range, ParallelLoopState loopstate) =>
		{
			int item = range.Item1;
			int num2 = range.Item2 - 1;
			for (int j = item; j <= num2; j++)
			{
				if (loopstate.IsStopped)
				{
					break;
				}
				float theDist = CS$<>8__locals37.$VB$Local_samples[j];
				if (Terrain.TerrainBlocksLOS(CS$<>8__locals37.$VB$Local_Lat_Src, CS$<>8__locals37.$VB$Local_Lon_Src, theDist, CS$<>8__locals37.$VB$Local_Distance_Cartesian, CS$<>8__locals37.$VB$Local_X_S, CS$<>8__locals37.$VB$Local_Y_S, CS$<>8__locals37.$VB$Local_Z_S, CS$<>8__locals37.$VB$Local_deltaX, CS$<>8__locals37.$VB$Local_deltaY, CS$<>8__locals37.$VB$Local_deltaZ, CS$<>8__locals37.$VB$Local_Alt_Src, CS$<>8__locals37.$VB$Local_Alt_Dest, CS$<>8__locals37.$VB$Local_LandMassCheck, CS$<>8__locals37.$VB$Local_IgnoreRadarHorizon, CS$<>8__locals37.$VB$Local_CurrentScen, CS$<>8__locals37.$VB$Local_NatureSide))
				{
					CS$<>8__locals37.$VB$Local_BlockFound = true;
					loopstate.Stop();
					break;
				}
			}
		});
		return !CS$<>8__locals37.$VB$Local_BlockFound;
	}

	private static void smethod_6()
	{
		lock (IeeLzJeZjma)
		{
			if (list_0.Count != 0)
			{
				Console.WriteLine($"Benchmark Statistics (Total runs: {list_0.Count})");
				Console.WriteLine($"Optimal Threshold: {int_1} samples");
				Console.WriteLine($"Threshold Locked: {bool_0}");
				Console.WriteLine("\r\nSample Data:");
				{
					foreach (Class12 item in list_0.OrderBy([SpecialName] (Class12 r) => r.int_0))
					{
						string text = (item.method_0() ? "SEQ" : "PAR");
						Console.WriteLine($"  {item.int_0,4} samples: SEQ={item.double_0:F3}ms PAR={item.double_1:F3}ms [{text}] (overhead: {item.method_1():+#.##;-#.##}ms)");
					}
					return;
				}
			}
			Console.WriteLine("No benchmark data available yet");
		}
	}
}
