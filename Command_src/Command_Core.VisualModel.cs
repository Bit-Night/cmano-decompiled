using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Sharp3D.Math.Core;

namespace Command_Core;

[StandardModule]
public sealed class VisualModel
{
	public enum TVisibilityType
	{
		vt_Cannot_See,
		vt_Can_Detect,
		vt_Can_Identify
	}

	public enum TVisionMode
	{
		vm_Scanning,
		vm_Tracking
	}

	public const string ModuleVersion = "Version 0.5";

	public const string ModuleCredits = "Sources: \r\n\t-> Karasik V.E., Orlov V.M. Lazernyye sistemy videniya. M, 2001.\r\n\t-> CIE DS 011.2/E:2002, CIE Central Bureau, Wien. \r\n ('Spatial distribution of daylight - CIE standard general sky') ";

	public const double Standard_VisibilityNM = 15.0;

	internal static double VisualHorizonRangeNM(double Altitude)
	{
		if (Altitude < 0.0)
		{
			return 0.0;
		}
		return Math.Sqrt(Altitude * Altitude + 2.0 * Altitude * 6371.0 * 1000.0);
	}

	internal static bool CanSee(ref ActiveUnit Who, ref ActiveUnit Whom, DateTime ScenTime)
	{
		QuaternionD quaternionD = default(QuaternionD);
		new Contact(Whom);
		Geodesic_Vincenty.TCoord Location = default(Geodesic_Vincenty.TCoord);
		Location.Lat = Who.get_Latitude((GlobalVariables.BooleanObject)null);
		Location.Lon = Who.get_Longitude((GlobalVariables.BooleanObject)null);
		Geodesic_Vincenty.TCoord tCoord = default(Geodesic_Vincenty.TCoord);
		tCoord.Lat = Whom.get_Latitude((GlobalVariables.BooleanObject)null);
		tCoord.Lon = Whom.get_Longitude((GlobalVariables.BooleanObject)null);
		Geodesic_Vincenty.smethod_1(tCoord, Whom.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
		quaternionD.Inverse();
		double num = Geodesic_Vincenty.SlantRangeNM(Location, tCoord, Who.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), Whom.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
		if (VisualHorizonRangeNM(Who.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) + VisualHorizonRangeNM(Whom.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) < num)
		{
			return false;
		}
		double x = default(double);
		double num2 = Math.Atan2(num * 1852.0, x) * 57.2957795130823 * 60.0;
		double num3 = 27.78 / (0.0 - Math.Log(0.02));
		double d;
		double num4;
		switch (Weather.GetTOD(ScenTime, ref Location, Who.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)))
		{
		default:
		{
			Exception ex = new Exception("Wrong time of day type");
			ex?.Data.Add("Error at 101161", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw ex;
		}
		case Weather.TTimeOfDayType.tod_Day:
			if (num2 >= 20.0)
			{
				d = 0.02;
			}
			else
			{
				if (!(num2 >= 1.0))
				{
					return false;
				}
				d = 0.02 * (num2 - 1.0) / 19.0;
			}
			goto IL_01e5;
		case Weather.TTimeOfDayType.tod_Twilight:
			if (num2 >= 20.0)
			{
				d = 0.035;
			}
			else
			{
				if (!(num2 >= 1.0))
				{
					return false;
				}
				d = 0.035 * (num2 - 1.0) / 19.0;
			}
			goto IL_01e5;
		case Weather.TTimeOfDayType.tod_Night:
			{
				return false;
			}
			IL_01e5:
			num4 = (0.0 - Math.Log(d)) / num3;
			if (num > num4)
			{
				return false;
			}
			return true;
		}
	}

	internal static double SurfaceVisibilityDistance(double EyeResolution, float EyeHeight, float ObjectHeight)
	{
		return 2.1 * Math.Sqrt(EyeHeight) - 1.2 * EyeResolution + Math.Sqrt(Math.Pow(2.1 + Math.Sqrt(EyeHeight) - 1.2 * EyeResolution, 2.0) + 4.41 * (double)(ObjectHeight - EyeHeight));
	}

	internal static int CloudVisibilityLimit(float Altitude, ref Weather.WeatherProfile Env)
	{
		if (Env.CloudInfo.LowCloudCoverThickness > 0)
		{
			if (Altitude < (float)Env.CloudInfo.LowCloudBase_m)
			{
				return -1;
			}
			if (Altitude < (float)Env.CloudInfo.LowCloudTop_m)
			{
				if (!((double)VBMath.Rnd() < Math.Pow(1.0 - (double)Env.CloudInfo.LowCloudCoverThickness / 8.0, 2.0)))
				{
					return -1;
				}
				switch (Env.CloudInfo.LowCloudType)
				{
				case Weather.TLowCloudType.Cb_Cumulonimbus:
					return (int)Math.Round(21f * VBMath.Rnd() + 0f);
				case Weather.TLowCloudType.Sc_Stratocumulus:
					return (int)Math.Round(51f * VBMath.Rnd() + 50f);
				case Weather.TLowCloudType.St_Stratus:
					return (int)Math.Round(201f * VBMath.Rnd() + 100f);
				case Weather.TLowCloudType.Cu_Cumulus:
					return (int)Math.Round(11f * VBMath.Rnd() + 30f);
				}
			}
		}
		if (Env.CloudInfo.MiddleCloudCoverThickness > 0)
		{
			if (Altitude < (float)Env.CloudInfo.MiddleCloudBase_m)
			{
				return -1;
			}
			if (Altitude < (float)Env.CloudInfo.MiddleCloudTop_m)
			{
				if (!((double)VBMath.Rnd() < Math.Pow(1.0 - (double)Env.CloudInfo.MiddleCloudCoverThickness / 8.0, 2.0)))
				{
					return -1;
				}
				switch (Env.CloudInfo.MiddleCloudType)
				{
				case Weather.TMiddleCloudType.Ac_Altocumulus:
					return (int)Math.Round(21f * VBMath.Rnd() + 80f);
				case Weather.TMiddleCloudType.As_Altostratus:
					return (int)Math.Round(451f * VBMath.Rnd() + 50f);
				case Weather.TMiddleCloudType.Ns_Nimbostratus:
					return (int)Math.Round(41f * VBMath.Rnd() + 10f);
				}
			}
		}
		if (Env.CloudInfo.HighCloudCoverThickness > 0)
		{
			if (Altitude < (float)Env.CloudInfo.HighCloudBase_m)
			{
				return -1;
			}
			if (Altitude < (float)Env.CloudInfo.HighCloudTop_m)
			{
				if ((double)VBMath.Rnd() < Math.Pow(1.0 - (double)Env.CloudInfo.HighCloudCoverThickness / 8.0, 2.0))
				{
					return (int)Math.Round(301f * VBMath.Rnd() + 200f);
				}
				return -1;
			}
		}
		return -1;
	}

	internal static double SkyLuminance(double SunElevation, double Elevation, double SunAzimouth, double Azimouth, int SkyType)
	{
		double num = 1.5707963267949 - SunElevation * 0.0174532925199433;
		double num2 = 1.5707963267949 - Elevation * 0.0174532925199433;
		double num3 = Math.Acos(Math.Cos(num) * Math.Cos(num2) + Math.Sin(num) * Math.Sin(num2) * Math.Cos(Math.Abs(Azimouth - SunAzimouth) * 0.0174532925199433));
		double num4 = Math.Sqrt(double.Epsilon);
		double num5;
		double num6;
		double num7;
		double num8;
		double num9;
		switch (SkyType)
		{
		default:
		{
			Exception ex = new Exception("Invalid sky type");
			ex?.Data.Add("Error at 101162", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw ex;
		}
		case 1:
			num5 = 4.0;
			num6 = -0.7;
			num7 = 0.0;
			num8 = -1.0;
			num9 = 0.0;
			break;
		case 2:
			num5 = 4.0;
			num6 = -0.7;
			num7 = 2.0;
			num8 = -1.5;
			num9 = 0.15;
			break;
		case 3:
			num5 = 1.1;
			num6 = -0.8;
			num7 = 0.0;
			num8 = -1.0;
			num9 = 0.0;
			break;
		case 4:
			num5 = 1.1;
			num6 = -0.8;
			num7 = 2.0;
			num8 = -1.5;
			num9 = 0.15;
			break;
		case 5:
			num5 = 0.0;
			num6 = -1.0;
			num7 = 0.0;
			num8 = -1.0;
			num9 = 0.0;
			break;
		case 6:
			num5 = 0.0;
			num6 = -1.0;
			num7 = 2.0;
			num8 = -1.5;
			num9 = 0.15;
			break;
		case 7:
			num5 = 0.0;
			num6 = -1.0;
			num7 = 5.0;
			num8 = -2.5;
			num9 = 0.3;
			break;
		case 8:
			num5 = 0.0;
			num6 = -1.0;
			num7 = 10.0;
			num8 = -3.0;
			num9 = 0.45;
			break;
		case 9:
			num5 = -1.0;
			num6 = -0.55;
			num7 = 2.0;
			num8 = -1.5;
			num9 = 0.15;
			break;
		case 10:
			num5 = -1.0;
			num6 = -0.55;
			num7 = 5.0;
			num8 = -2.5;
			num9 = 0.3;
			break;
		case 11:
			num5 = -1.0;
			num6 = -0.55;
			num7 = 10.0;
			num8 = -3.0;
			num9 = 0.45;
			break;
		case 12:
			num5 = -1.0;
			num6 = -0.32;
			num7 = 10.0;
			num8 = -3.0;
			num9 = 0.45;
			break;
		case 13:
			num5 = -1.0;
			num6 = -0.32;
			num7 = 16.0;
			num8 = -3.0;
			num9 = 0.3;
			break;
		case 14:
			num5 = -1.0;
			num6 = -0.15;
			num7 = 16.0;
			num8 = -3.0;
			num9 = 0.3;
			break;
		case 15:
			num5 = -1.0;
			num6 = -0.15;
			num7 = 24.0;
			num8 = -2.8;
			num9 = 0.15;
			break;
		}
		double num10 = ((!(Math.Abs(num2 - 1.5707963267949) < num4)) ? (1.0 + num5 * Math.Exp(num6 * Math.Cos(num2))) : 1.0);
		double num11 = 1.0 + num5 * Math.Exp(num6);
		double num12 = 1.0 + num7 * (Math.Exp(num8 * num3) - Math.Exp(num8 * 1.5707963267949)) + num9 * Math.Pow(Math.Cos(num3), 2.0);
		double num13 = 1.0 + num7 * (Math.Exp(num8 * num) - Math.Exp(num8 * 1.5707963267949)) + num9 * Math.Pow(Math.Cos(num), 2.0);
		return num12 * num10 / (num13 * num11);
	}

	internal static TVisibilityType VisualEquation(float EyeAltitude, double ObjectSize, float ObjectAltitude, double DistanceToObjectNM, TVisibilityType PreviousVisibility, Weather.TTimeOfDayType TimeOfDay, ref Weather.WeatherProfile Env)
	{
		double num = DistanceToObjectNM * 1852.0 / 1000.0;
		Math.Atan2(num * 1000.0, ObjectSize);
		double num2 = default(double);
		double num3 = default(double);
		_ = Math.Abs(num2 - num3) / (num2 + num3);
		double num6 = default(double);
		double num5 = default(double);
		double num4 = num2 * Math.Exp((0.0 - num5) * num) + num6 * (1.0 - Math.Exp((0.0 - num5) * num));
		double num7 = num3 * Math.Exp((0.0 - num5) * num) + num6 * (1.0 - Math.Exp((0.0 - num5) * num));
		_ = Math.Abs(num4 - num7) / (num4 + num7);
		if (DistanceToObjectNM > SurfaceVisibilityDistance(1.0, EyeAltitude, ObjectAltitude))
		{
			return TVisibilityType.vt_Cannot_See;
		}
		double d = default(double);
		double d2 = default(double);
		double d3 = default(double);
		switch (TimeOfDay)
		{
		case Weather.TTimeOfDayType.tod_Day:
			d = 0.02;
			d2 = 0.05;
			d3 = 0.07;
			break;
		case Weather.TTimeOfDayType.tod_Twilight:
			d = 0.3;
			d2 = 0.35;
			d3 = 0.4;
			break;
		case Weather.TTimeOfDayType.tod_Night:
			d = 0.6;
			d2 = 0.65;
			d3 = 0.7;
			break;
		}
		double num8 = default(double);
		if (Math.Max(EyeAltitude, ObjectAltitude) < (float)Env.CloudInfo.LowCloudBase_m)
		{
			num8 = Env.SurfaceVisibilityKM;
		}
		else
		{
			double num9 = default(double);
			if ((double)CloudVisibilityLimit(EyeAltitude, ref Env) == -1.0)
			{
				num9 = CloudVisibilityLimit(ObjectAltitude, ref Env);
			}
			if (num9 == -1.0)
			{
				num8 = 0.0;
			}
		}
		num5 = (0.0 - Math.Log(0.02)) / num8;
		double num10 = (0.0 - Math.Log(0.02)) / (double)Env.SurfaceVisibilityKM;
		double d4 = 1.0;
		double num12;
		if (PreviousVisibility == TVisibilityType.vt_Cannot_See)
		{
			double num11 = (Math.Log(d4) - Math.Log(d2)) / num10;
			if (num < num11)
			{
				num12 = (Math.Log(d4) - Math.Log(d3)) / num10;
				if (num < num12)
				{
					return TVisibilityType.vt_Can_Identify;
				}
				return TVisibilityType.vt_Can_Detect;
			}
			return TVisibilityType.vt_Cannot_See;
		}
		double num13 = (Math.Log(d4) - Math.Log(d)) / num10;
		if (num > num13)
		{
			return TVisibilityType.vt_Cannot_See;
		}
		num12 = (Math.Log(d4) - Math.Log(d3)) / num10;
		if (num < num12)
		{
			return TVisibilityType.vt_Can_Identify;
		}
		return PreviousVisibility;
	}

	static VisualModel()
	{
		Class72.smethod_20();
	}
}
