using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class SonarModel
{
	public enum PositionRelativeToThermocline : byte
	{
		Above,
		Inside,
		Below
	}

	public class SonarArrayGainEstimator
	{
		public static double EstimateArrayGain(double targetNoiseLevel, double detectionRangeNm, double ambientNoiseLevel = 60.0, double frequency = 3000.0, double detectionThreshold = 10.0)
		{
			double num = detectionRangeNm * 1852.0;
			double num2 = smethod_0(frequency);
			double num3 = num / 1000.0;
			double num4 = 20.0 * Math.Log10(num);
			double num5 = num2 * num3;
			double num6 = num4 + num5;
			return ambientNoiseLevel - (targetNoiseLevel - num6) + detectionThreshold;
		}

		private static double smethod_0(double double_0)
		{
			double num = double_0 / 1000.0;
			if (num >= 0.4)
			{
				return 0.11 * num * num / (1.0 + num * num);
			}
			return 0.002 * num;
		}

		public static double EstimateArrayGainSimple(double targetNoiseLevel, double detectionRangeNm)
		{
			return EstimateArrayGain(targetNoiseLevel, detectionRangeNm, 70.0, 10000.0);
		}

		static SonarArrayGainEstimator()
		{
			Class72.smethod_20();
		}
	}

	public sealed class ThermoclineLayer
	{
		public int Ceiling;

		public int Floor;

		public float Strength;

		public bool IsInsideDeepSoundChannel => Math.Abs(theAlt - (float)Floor) < 70f;

		static ThermoclineLayer()
		{
			Class72.smethod_20();
		}
	}

	public const double DirectPathMaxRange__Nominal_NM = 9.87473;

	public const int SurfaceDuctMaxDepth = -50;

	private static Dictionary<int, float> dictionary_0;

	private static List<int> list_0;

	private static LockObject lockObject_0;

	static SonarModel()
	{
		Class72.smethod_20();
		lockObject_0 = new LockObject();
	}

	public static float smethod_0(double theLat, double theLon, Side theSide, Scenario theScen)
	{
		if (!(theLat >= 69.7) && theLat > -59.45)
		{
			double num = ((!(theLat < 0.0)) ? (40.0 - Math.Abs(theLat) / 3.4) : (40.0 - Math.Abs(theLat) / 2.9));
			if (theScen.NatureSideExists())
			{
				CustomEnvironmentZone[] customEnvironmentZones = theScen.GetNatureSide().CustomEnvironmentZones;
				foreach (CustomEnvironmentZone customEnvironmentZone in customEnvironmentZones)
				{
					if (GeoPoint.IsInsideThisArea(theLat, theLon, customEnvironmentZone.Area_AsArray))
					{
						return customEnvironmentZone.CZInterval;
					}
				}
			}
			return (float)num;
		}
		return 0f;
	}

	public static void GetThermalLayerAtThisLocation(double theLat, double theLon, int BottomDepth, ref int LayerCeiling, ref int LayerFloor, ref float LayerStrengthPercentage, bool RequestIsFromGUI, Scenario TheScen)
	{
		ThermoclineLayer thermalLayerAtThisLocation = GetThermalLayerAtThisLocation(theLat, theLon, BottomDepth, TheScen);
		LayerCeiling = thermalLayerAtThisLocation.Ceiling;
		LayerFloor = thermalLayerAtThisLocation.Floor;
		LayerStrengthPercentage = thermalLayerAtThisLocation.Strength;
	}

	private static float UiEyGwuVaBo(double double_0)
	{
		if (!(double_0 <= -63.0) && double_0 < 70.0)
		{
			if (dictionary_0 == null || list_0 == null)
			{
				lock (lockObject_0)
				{
					dictionary_0 = new Dictionary<int, float>();
					dictionary_0.Add(-63, 0f);
					dictionary_0.Add(-54, 0.1f);
					dictionary_0.Add(-45, 0.2f);
					dictionary_0.Add(-36, 0.3f);
					dictionary_0.Add(-27, 0.4f);
					dictionary_0.Add(-18, 0.5f);
					dictionary_0.Add(-9, 0.6f);
					dictionary_0.Add(0, 0.7f);
					dictionary_0.Add(10, 0.6f);
					dictionary_0.Add(20, 0.5f);
					dictionary_0.Add(30, 0.4f);
					dictionary_0.Add(40, 0.3f);
					dictionary_0.Add(50, 0.2f);
					dictionary_0.Add(60, 0.1f);
					dictionary_0.Add(70, 0f);
					list_0 = new List<int>(dictionary_0.Keys);
				}
			}
			float result = default(float);
			try
			{
				int num = list_0.Count - 2;
				for (int i = 0; i <= num; i++)
				{
					int num2 = list_0[i];
					int num3 = list_0[i + 1];
					if (double_0 > (double)num2 && !(double_0 >= (double)num3))
					{
						double num4 = (double_0 - (double)num2) / (double)(num3 - num2);
						double num5 = ((!(double_0 < 0.0)) ? ((double)dictionary_0[num2] - num4 * (double)Math.Abs(dictionary_0[num3] - dictionary_0[num2])) : ((double)dictionary_0[num2] + num4 * (double)Math.Abs(dictionary_0[num3] - dictionary_0[num2])));
						result = (float)num5;
						return result;
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return result;
		}
		return 0f;
	}

	public static float SonarPropagationModifier(bool UsesDSC, ActiveUnit SensorParent, ActiveUnit Target, float? ExplicitSensorDepth = null)
	{
		float float_ = 1f;
		smethod_2(SensorParent, Target, ref float_, ExplicitSensorDepth);
		EffectOfThermalLayer(SensorParent, Target, ref float_, ExplicitSensorDepth);
		if (UsesDSC)
		{
			smethod_1(SensorParent, Target, ref float_, ExplicitSensorDepth);
		}
		return float_;
	}

	private static void smethod_1(object object_0, object object_1, ref float float_0, float? nullable_0 = null)
	{
		try
		{
			ThermoclineLayer thermalLayerAtThisLocation = GetThermalLayerAtThisLocation(((ActiveUnit)object_0).get_Latitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)object_0).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)object_0).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, ((ActiveUnit)object_0).ParentScen), ((ActiveUnit)object_0).ParentScen);
			ThermoclineLayer thermalLayerAtThisLocation2 = GetThermalLayerAtThisLocation(((ActiveUnit)object_1).get_Latitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)object_1).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)object_1).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, ((ActiveUnit)object_0).ParentScen), ((ActiveUnit)object_0).ParentScen);
			float theAlt = ((!nullable_0.HasValue) ? ((float)(int)Math.Round(((ActiveUnit)object_0).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))) : nullable_0.Value);
			PositionRelativeToThermocline positionRelativeToThermocline = GetPositionRelativeToThermocline(theAlt, thermalLayerAtThisLocation);
			PositionRelativeToThermocline positionRelativeToThermocline2 = GetPositionRelativeToThermocline((int)Math.Round(((ActiveUnit)object_1).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)), thermalLayerAtThisLocation2);
			if (positionRelativeToThermocline == PositionRelativeToThermocline.Below && positionRelativeToThermocline2 == PositionRelativeToThermocline.Below)
			{
				if (thermalLayerAtThisLocation.get_IsInsideDeepSoundChannel(theAlt) && thermalLayerAtThisLocation2.get_IsInsideDeepSoundChannel((float)(int)Math.Round(((ActiveUnit)object_1).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))))
				{
					float_0 *= 2f;
				}
				else if (thermalLayerAtThisLocation.get_IsInsideDeepSoundChannel(theAlt) || thermalLayerAtThisLocation2.get_IsInsideDeepSoundChannel((float)(int)Math.Round(((ActiveUnit)object_1).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))))
				{
					float_0 = (float)((double)float_0 * 1.5);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 102134656566777", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void EffectOfThermalLayer(ActiveUnit SensorParent, ActiveUnit theUnit, ref float DetectionRange, float? ExplicitSensorDepth = null)
	{
		try
		{
			ThermoclineLayer thermalLayerAtThisLocation = GetThermalLayerAtThisLocation(SensorParent.get_Latitude((GlobalVariables.BooleanObject)null), SensorParent.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)SensorParent).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, SensorParent.ParentScen), theUnit.ParentScen);
			ThermoclineLayer thermalLayerAtThisLocation2 = GetThermalLayerAtThisLocation(theUnit.get_Latitude((GlobalVariables.BooleanObject)null), theUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theUnit).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, SensorParent.ParentScen), theUnit.ParentScen);
			float theAlt = ((!ExplicitSensorDepth.HasValue) ? ((float)(int)Math.Round(SensorParent.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))) : ExplicitSensorDepth.Value);
			PositionRelativeToThermocline positionRelativeToThermocline = GetPositionRelativeToThermocline(theAlt, thermalLayerAtThisLocation);
			PositionRelativeToThermocline positionRelativeToThermocline2 = GetPositionRelativeToThermocline((int)Math.Round(theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)), thermalLayerAtThisLocation2);
			float num = (thermalLayerAtThisLocation.Strength + thermalLayerAtThisLocation2.Strength) / 2f;
			if (num == 0f || (positionRelativeToThermocline == PositionRelativeToThermocline.Above && positionRelativeToThermocline2 == PositionRelativeToThermocline.Above))
			{
				return;
			}
			if (positionRelativeToThermocline == PositionRelativeToThermocline.Inside && positionRelativeToThermocline2 == PositionRelativeToThermocline.Inside)
			{
				DetectionRange = (float)((double)DetectionRange * Math.Max(0.1, 1f - num * 2f));
			}
			else if (positionRelativeToThermocline != PositionRelativeToThermocline.Inside && positionRelativeToThermocline2 != PositionRelativeToThermocline.Inside)
			{
				if (positionRelativeToThermocline != positionRelativeToThermocline2)
				{
					DetectionRange *= 1f - num;
				}
				else if (positionRelativeToThermocline != PositionRelativeToThermocline.Below)
				{
				}
			}
			else
			{
				DetectionRange *= 1f - num / 2f;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100734", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void smethod_2(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, ref float float_0, float? nullable_0 = null)
	{
		try
		{
			int num = -50;
			float num2 = ((!nullable_0.HasValue) ? ((float)(int)Math.Round(activeUnit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))) : nullable_0.Value);
			if (num2 > (float)num && activeUnit_1.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > (float)num)
			{
				float_0 = (float)(1.5 * (double)float_0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100732", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal static int MinimumDepthForCZ_m(double theLatitude)
	{
		int result;
		if (!(theLatitude >= 69.7))
		{
			if (!(theLatitude <= -59.45))
			{
				double a = ((!(theLatitude < 0.0)) ? (-5380.0 + Math.Abs(theLatitude) / 3.4 * 220.0) : (-5380.0 + Math.Abs(theLatitude) / 2.9 * 220.0));
				return (int)Math.Round(a);
			}
			result = int.MaxValue;
		}
		else
		{
			result = int.MaxValue;
		}
		return result;
	}

	public static ThermoclineLayer GetThermalLayerAtThisLocation(double theLat, double theLon, int BottomDepth, Scenario TheScen)
	{
		ThermoclineLayer result = default(ThermoclineLayer);
		try
		{
			ThermoclineLayer thermoclineLayer = new ThermoclineLayer();
			float num = 1f - (float)(Math.Abs(theLat) / 90.0);
			thermoclineLayer.Ceiling = Math.Min(-40, (int)Math.Round(-10f + num * -150f - -10f));
			int num2 = (int)Math.Round(10f + num * 90f);
			thermoclineLayer.Floor = thermoclineLayer.Ceiling - num2;
			short elevation = Terrain.GetElevation(theLat, theLon, RequestIsFromGUI: false, TheScen);
			if (elevation > thermoclineLayer.Floor)
			{
				thermoclineLayer.Ceiling = (int)Math.Round((double)thermoclineLayer.Ceiling * ((double)Math.Abs(elevation) / 250.0));
				num2 = (int)Math.Round((double)num2 * ((double)Math.Abs(elevation) / 250.0));
				thermoclineLayer.Floor = (int)Math.Round((double)thermoclineLayer.Floor * ((double)Math.Abs(elevation) / 250.0));
			}
			thermoclineLayer.Strength = UiEyGwuVaBo(theLat);
			if (TheScen != null && TheScen.NatureSideExists())
			{
				CustomEnvironmentZone[] customEnvironmentZones = TheScen.GetNatureSide().CustomEnvironmentZones;
				foreach (CustomEnvironmentZone customEnvironmentZone in customEnvironmentZones)
				{
					if (GeoPoint.IsInsideThisArea(theLat, theLon, customEnvironmentZone.Area_AsArray))
					{
						result = customEnvironmentZone.ThermalLayer;
						return result;
					}
				}
			}
			result = thermoclineLayer;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101125", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static PositionRelativeToThermocline GetPositionRelativeToThermocline(float theAlt, ThermoclineLayer theLayer)
	{
		if (theAlt > -10f)
		{
			return PositionRelativeToThermocline.Above;
		}
		if (theAlt > (float)theLayer.Ceiling)
		{
			return PositionRelativeToThermocline.Above;
		}
		if (theAlt < (float)theLayer.Floor)
		{
			return PositionRelativeToThermocline.Below;
		}
		return PositionRelativeToThermocline.Inside;
	}

	public static PositionRelativeToThermocline GetPositionRelativeToThermocline(double theLat, double theLon, float theAlt, Scenario TheScen)
	{
		if (theAlt <= -10f)
		{
			int elevation = Terrain.GetElevation(theLat, theLon, RequestIsFromGUI: false, TheScen);
			int LayerCeiling = default(int);
			int LayerFloor = default(int);
			float LayerStrengthPercentage = default(float);
			GetThermalLayerAtThisLocation(theLat, theLon, elevation, ref LayerCeiling, ref LayerFloor, ref LayerStrengthPercentage, RequestIsFromGUI: false, TheScen);
			if (theAlt > (float)LayerCeiling)
			{
				return PositionRelativeToThermocline.Above;
			}
			if (theAlt < (float)LayerFloor)
			{
				return PositionRelativeToThermocline.Below;
			}
			return PositionRelativeToThermocline.Inside;
		}
		return PositionRelativeToThermocline.Above;
	}

	public static double ComputeApparentSL_Active(double OSL, double range, double directPathLimit, double czInterval, double czWidth, double transitionWidth = 2.0, bool czActive = true)
	{
		double num = Compute_ApparentSL_at_Range(OSL, range, directPathLimit, czInterval, czWidth, transitionWidth, czActive);
		double num2 = OSL - num;
		return OSL - 2.0 * num2;
	}

	public static double Compute_ApparentSL_at_Range(double OSL, double range, double directPathLimit, double czInterval, double czWidth, double transitionWidth = 2.0, bool czActive = true)
	{
		double num = 10.0;
		if (range <= directPathLimit)
		{
			return OSL;
		}
		int num2 = 1;
		if (czActive)
		{
			num2 = (int)Math.Floor(range / czInterval);
			if (num2 < 1)
			{
				num2 = 1;
			}
		}
		double num3 = (double)num2 * czInterval;
		double num4 = czWidth / 2.0;
		double num5 = num3 - num4;
		double num6 = num3 + num4;
		if (czActive && range >= num5 && range <= num6)
		{
			return OSL - num;
		}
		double num7;
		double num8;
		if (num2 == 1)
		{
			num7 = OSL - 50.0;
			num8 = ((!czActive) ? num7 : (OSL - num));
		}
		else
		{
			num7 = OSL - 70.0;
			num8 = (czActive ? (OSL - num) : num7);
		}
		double num9;
		double num10;
		if (num2 == 1 && range < num5)
		{
			num9 = directPathLimit;
			num10 = num5;
		}
		else if (range < num5)
		{
			num9 = num3 - czInterval + num4;
			num10 = num5;
		}
		else
		{
			num9 = num6;
			num10 = num3 + czInterval - num4;
		}
		double num11 = num9;
		double num12 = Math.Min(num9 + transitionWidth, num10);
		double num13 = Math.Max(num10 - transitionWidth, num9);
		double num14 = num10;
		if (range >= num11 && range <= num12)
		{
			return Interpolate(num11, num12, num8, num7, range);
		}
		if (range > num12 && range < num13)
		{
			return num7;
		}
		if (range >= num13 && range <= num14)
		{
			return Interpolate(num13, num14, num7, num8, range);
		}
		return num7;
	}

	private static double Interpolate(double x0, double x1, double y0, double y1, double x)
	{
		if (x1 == x0)
		{
			return y1;
		}
		double num = (x - x0) / (x1 - x0);
		return y0 + num * (y1 - y0);
	}

	public static double EffectOfSurfaceDuct(double nominalRange, double sensorDepth, double targetDepth, float? ExplicitSensorDepth = null)
	{
		sensorDepth = (ExplicitSensorDepth.HasValue ? ((double)ExplicitSensorDepth.Value) : sensorDepth);
		double num = smethod_3(sensorDepth);
		double num2 = smethod_3(targetDepth);
		double num3 = Math.Pow(num, 2.0);
		double num4 = Math.Pow(num2, 2.0);
		double num5 = (num * num3 + num2 * num4) / (num3 + num4);
		return nominalRange * num5;
	}

	private static double smethod_3(double double_0)
	{
		double num = Math.Abs(double_0);
		if (num >= 50.0)
		{
			return 1.0;
		}
		if (num <= 0.0)
		{
			return 1.5;
		}
		double num2 = (50.0 - num) / 50.0;
		return 1.0 + 0.5 * num2;
	}

	public static double ComputeNarrowbandAmbientNoise(double freq_kHz, int seaState, double bottomDepth, double receiverDepth, int shippingLevel, string bottomType = "sand")
	{
		seaState = Math.Max(0, Math.Min(6, seaState));
		shippingLevel = Math.Max(0, Math.Min(3, shippingLevel));
		freq_kHz = Math.Max(0.01, freq_kHz);
		bottomType = bottomType.Trim().ToLower();
		double num = 40.0 + 10.0 * (double)shippingLevel + 26.0 * Math.Log10(0.1 + freq_kHz);
		double num2 = 50.0 + 7.5 * Math.Pow(seaState, 0.7) + 20.0 * Math.Log10(freq_kHz);
		double num3 = 17.0 - 30.0 * Math.Log10(freq_kHz);
		double d = Math.Pow(10.0, num / 10.0) + Math.Pow(10.0, num2 / 10.0) + Math.Pow(10.0, num3 / 10.0);
		double num4 = 10.0 * Math.Log10(d);
		double num5 = 0.0;
		if (receiverDepth > 50.0)
		{
			num5 = -10.0 * (1.0 - Math.Exp((0.0 - receiverDepth) / 1000.0));
		}
		num4 += num5;
		double num6 = bottomType switch
		{
			"mud" => 0.6, 
			"rock" => 1.4, 
			"sand" => 1.0, 
			_ => 1.0, 
		};
		double num7 = 0.0;
		if (bottomDepth < 2000.0)
		{
			num7 = 15.0 * Math.Exp((0.0 - bottomDepth) / 200.0) * num6;
			double num8 = 1.0 / (1.0 + Math.Pow(freq_kHz / 5.0, 2.0));
			num7 *= num8;
		}
		return num4 + num7;
	}

	private static double smethod_4(double double_0, string string_0 = "spherical", double double_1 = 0.0)
	{
		if (double_0 <= 0.0)
		{
			return 0.0;
		}
		string text = string_0.ToLower();
		if (Operators.CompareString(text, "spherical", false) != 0)
		{
			if (Operators.CompareString(text, "cylindrical", false) == 0)
			{
				return 10.0 * Math.Log10(double_0) + double_1 * double_0;
			}
			return 20.0 * Math.Log10(double_0) + double_1 * double_0;
		}
		return 20.0 * Math.Log10(double_0) + double_1 * double_0;
	}

	public static (double N_ship_dB, double s_est, double P_total) EstimateShippingLevelFromShips(double[] shipRanges, double[] shipSLs, double freq_kHz, double alpha = 0.0, string tlModel = "spherical")
	{
		if (shipRanges != null && shipSLs != null)
		{
			if (shipRanges.Length != shipSLs.Length)
			{
				throw new ArgumentException("shipRanges and shipSLs must be same length");
			}
			if (freq_kHz <= 0.0)
			{
				freq_kHz = 1.0;
			}
			double num = 0.0;
			int num2 = shipRanges.Length - 1;
			for (int i = 0; i <= num2; i++)
			{
				double num3 = shipRanges[i] * 1852.0;
				double num4 = shipSLs[i];
				if (num3 < 0.001)
				{
					num3 = 0.001;
				}
				double num5 = smethod_4(num3, tlModel, alpha);
				double num6 = num4 - num5;
				double num7 = Math.Pow(10.0, num6 / 10.0);
				num += num7;
			}
			(double, double, double) result;
			if (num <= 0.0)
			{
				result = (double.NegativeInfinity, 0.0, 0.0);
			}
			else
			{
				double num8 = 10.0 * Math.Log10(num);
				double num9 = 40.0 + 26.0 * Math.Log10(0.1 + freq_kHz);
				double num10 = (num8 - num9) / 10.0;
				if (double.IsNaN(num10))
				{
					num10 = 0.0;
				}
				if (num10 < 0.0)
				{
					num10 = 0.0;
				}
				if (num10 > 3.0)
				{
					num10 = 3.0;
				}
				result = (num8, num10, num);
			}
			return result;
		}
		throw new ArgumentException("shipRanges and shipSLs required");
	}
}
