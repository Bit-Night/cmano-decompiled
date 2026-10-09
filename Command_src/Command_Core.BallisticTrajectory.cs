using System;
using System.Globalization;
using System.Xml;
using CSMaterial;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class BallisticTrajectory
{
	public struct LatLonAlt
	{
		public double lat;

		public double lon;

		public double radius_km;

		public static implicit operator LatLonAlt(GeoPoint p1)
		{
			return new LatLonAlt
			{
				lat = p1.Latitude * CSMath.PI_dividedBy_180,
				lon = p1.Longitude * CSMath.PI_dividedBy_180,
				radius_km = (double)p1.Altitude / 1000.0 + 6371.0
			};
		}

		public static implicit operator LatLonAlt(Module_Unit.Unit p1)
		{
			return new LatLonAlt
			{
				lat = p1.get_Latitude((GlobalVariables.BooleanObject)null) * CSMath.PI_dividedBy_180,
				lon = p1.get_Longitude((GlobalVariables.BooleanObject)null) * CSMath.PI_dividedBy_180,
				radius_km = (double)(p1.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) / 1000f) + 6371.0
			};
		}

		internal LatLonAlt Haversine(double Bearing, double RangeAngle)
		{
			double double_ = Wrap(smethod_10(smethod_9(lat) * smethod_8(RangeAngle) + smethod_8(lat) * smethod_9(RangeAngle) * smethod_8(Bearing)));
			return new LatLonAlt
			{
				lat = double_,
				lon = Wrap(lon + Math.Atan2(smethod_9(Bearing) * smethod_9(RangeAngle) * smethod_8(lat), smethod_8(RangeAngle) - smethod_9(lat) * smethod_9(double_))),
				radius_km = radius_km
			};
		}

		public void ToXML(ref XmlWriter theWriter)
		{
			theWriter.WriteStartElement("LatLonAlt");
			theWriter.WriteElementString("lat", XmlConvert.ToString(lat));
			theWriter.WriteElementString("lon", XmlConvert.ToString(lon));
			theWriter.WriteElementString("radius_km", XmlConvert.ToString(radius_km));
			theWriter.WriteEndElement();
		}

		public static LatLonAlt FromXML(ref XmlNode theNode)
		{
			return new LatLonAlt
			{
				lat = double.Parse(Misc.GetNodeByName(theNode.ChildNodes, "lat").InnerText, CultureInfo.InvariantCulture),
				lon = double.Parse(Misc.GetNodeByName(theNode.ChildNodes, "lon").InnerText, CultureInfo.InvariantCulture),
				radius_km = double.Parse(Misc.GetNodeByName(theNode.ChildNodes, "radius_km").InnerText, CultureInfo.InvariantCulture)
			};
		}

		static LatLonAlt()
		{
			Class72.smethod_20();
		}
	}

	public struct Record
	{
		public double CurrentMeanAngularMotion_rad__s;

		public double Time_s;

		public double Radius_km;

		public double TA;

		public double MA;

		public byte Phase;

		public double Pitch;

		public void ToXML(ref XmlWriter theWriter)
		{
			theWriter.WriteStartElement("Record");
			theWriter.WriteElementString("CurrentMeanAngularMotion_rad__s", XmlConvert.ToString(CurrentMeanAngularMotion_rad__s));
			theWriter.WriteElementString("Time_s", XmlConvert.ToString(Time_s));
			theWriter.WriteElementString("Radius_km", XmlConvert.ToString(Radius_km));
			theWriter.WriteElementString("TA", XmlConvert.ToString(TA));
			theWriter.WriteElementString("MA", XmlConvert.ToString(MA));
			theWriter.WriteElementString("Phase", XmlConvert.ToString(Phase));
			theWriter.WriteElementString("Pitch", XmlConvert.ToString(Pitch));
			theWriter.WriteEndElement();
		}

		public static Record FromXML(ref XmlNode theNode)
		{
			return new Record
			{
				CurrentMeanAngularMotion_rad__s = double.Parse(Misc.GetNodeByName(theNode.ChildNodes, "CurrentMeanAngularMotion_rad__s").InnerText, CultureInfo.InvariantCulture),
				Time_s = double.Parse(Misc.GetNodeByName(theNode.ChildNodes, "Time_s").InnerText, CultureInfo.InvariantCulture),
				Radius_km = double.Parse(Misc.GetNodeByName(theNode.ChildNodes, "Radius_km").InnerText, CultureInfo.InvariantCulture),
				TA = double.Parse(Misc.GetNodeByName(theNode.ChildNodes, "TA").InnerText, CultureInfo.InvariantCulture),
				MA = double.Parse(Misc.GetNodeByName(theNode.ChildNodes, "MA").InnerText, CultureInfo.InvariantCulture),
				Phase = Conversions.ToByte(Misc.GetNodeByName(theNode.ChildNodes, "Phase").InnerText),
				Pitch = double.Parse(Misc.GetNodeByName(theNode.ChildNodes, "Pitch").InnerText, CultureInfo.InvariantCulture)
			};
		}

		static Record()
		{
			Class72.smethod_20();
		}
	}

	public struct BallisticResult
	{
		public double Lat_deg;

		public double Lon_deg;

		public double AltASL_m;

		public double Heading_deg;

		public double Speed_kts;

		public double Pitch_deg;
	}

	public bool High;

	public LatLonAlt Shooter;

	public LatLonAlt Target;

	public double RangeAngle_MaxRange;

	public double e;

	public double a_km;

	public double w;

	public double DeltaMeanAngularMotion_rad__s;

	public double FinalMeanAngularMotion_rad__s;

	public double InitialHeading;

	public Record CurrentRecord;

	public Record NextRecord;

	public double StartTA;

	public double EndTA;

	public double BoostTime_s;

	public void ToXML(ref XmlWriter theWriter)
	{
		theWriter.WriteStartElement("BallisticTrajectory");
		theWriter.WriteElementString("e", XmlConvert.ToString(e));
		theWriter.WriteElementString("a_km", XmlConvert.ToString(a_km));
		theWriter.WriteElementString("w", XmlConvert.ToString(w));
		theWriter.WriteElementString("DeltaMeanAngularMotion_rad__s", XmlConvert.ToString(DeltaMeanAngularMotion_rad__s));
		theWriter.WriteElementString("FinalMeanAngularMotion_rad__s", XmlConvert.ToString(FinalMeanAngularMotion_rad__s));
		theWriter.WriteElementString("InitialHeading", XmlConvert.ToString(InitialHeading));
		theWriter.WriteElementString("StartTA", XmlConvert.ToString(StartTA));
		theWriter.WriteElementString("EndTA", XmlConvert.ToString(EndTA));
		theWriter.WriteElementString("BoostTime_s", XmlConvert.ToString(BoostTime_s));
		theWriter.WriteElementString("High", XmlConvert.ToString(High));
		theWriter.WriteElementString("RangeAngle_MaxRange", XmlConvert.ToString(RangeAngle_MaxRange));
		theWriter.WriteStartElement("CurrentRecord");
		CurrentRecord.ToXML(ref theWriter);
		theWriter.WriteEndElement();
		theWriter.WriteStartElement("NextRecord");
		NextRecord.ToXML(ref theWriter);
		theWriter.WriteEndElement();
		theWriter.WriteStartElement("Shooter");
		Shooter.ToXML(ref theWriter);
		theWriter.WriteEndElement();
		theWriter.WriteStartElement("Target");
		Target.ToXML(ref theWriter);
		theWriter.WriteEndElement();
		theWriter.WriteEndElement();
	}

	public static BallisticTrajectory FromXML(ref XmlNode theNode)
	{
		BallisticTrajectory obj = new BallisticTrajectory
		{
			e = double.Parse(Misc.GetNodeByName(theNode.ChildNodes, "e").InnerText, CultureInfo.InvariantCulture),
			a_km = double.Parse(Misc.GetNodeByName(theNode.ChildNodes, "a_km").InnerText, CultureInfo.InvariantCulture),
			w = double.Parse(Misc.GetNodeByName(theNode.ChildNodes, "w").InnerText, CultureInfo.InvariantCulture),
			DeltaMeanAngularMotion_rad__s = double.Parse(Misc.GetNodeByName(theNode.ChildNodes, "DeltaMeanAngularMotion_rad__s").InnerText, CultureInfo.InvariantCulture),
			FinalMeanAngularMotion_rad__s = double.Parse(Misc.GetNodeByName(theNode.ChildNodes, "FinalMeanAngularMotion_rad__s").InnerText, CultureInfo.InvariantCulture),
			InitialHeading = double.Parse(Misc.GetNodeByName(theNode.ChildNodes, "InitialHeading").InnerText, CultureInfo.InvariantCulture),
			StartTA = double.Parse(Misc.GetNodeByName(theNode.ChildNodes, "StartTA").InnerText, CultureInfo.InvariantCulture),
			EndTA = double.Parse(Misc.GetNodeByName(theNode.ChildNodes, "EndTA").InnerText, CultureInfo.InvariantCulture),
			BoostTime_s = double.Parse(Misc.GetNodeByName(theNode.ChildNodes, "BoostTime_s").InnerText, CultureInfo.InvariantCulture),
			High = Conversions.ToBoolean(Misc.GetNodeByName(theNode.ChildNodes, "High").InnerText),
			RangeAngle_MaxRange = double.Parse(Misc.GetNodeByName(theNode.ChildNodes, "RangeAngle_MaxRange").InnerText, CultureInfo.InvariantCulture)
		};
		XmlNode theNode2 = Misc.GetNodeByName(theNode.ChildNodes, "CurrentRecord").FirstChild;
		obj.CurrentRecord = Record.FromXML(ref theNode2);
		theNode2 = Misc.GetNodeByName(theNode.ChildNodes, "NextRecord").FirstChild;
		obj.NextRecord = Record.FromXML(ref theNode2);
		theNode2 = Misc.GetNodeByName(theNode.ChildNodes, "Shooter").FirstChild;
		obj.Shooter = LatLonAlt.FromXML(ref theNode2);
		theNode2 = Misc.GetNodeByName(theNode.ChildNodes, "Target").FirstChild;
		obj.Target = LatLonAlt.FromXML(ref theNode2);
		return obj;
	}

	private void method_0(double double_0)
	{
		if (double_0 < CurrentRecord.Time_s)
		{
			throw new Exception();
		}
		while (double_0 >= NextRecord.Time_s)
		{
			CurrentRecord = NextRecord;
			NextRecord = ComputeNextRecord(this, CurrentRecord, 1.0);
		}
	}

	internal BallisticResult Calculate(double TimeSinceLaunch_s)
	{
		method_0(TimeSinceLaunch_s);
		double num = method_1(CurrentRecord.Time_s, NextRecord.Time_s, CurrentRecord.TA, NextRecord.TA, TimeSinceLaunch_s);
		double altASL_m = (method_1(CurrentRecord.Time_s, NextRecord.Time_s, CurrentRecord.Radius_km, NextRecord.Radius_km, TimeSinceLaunch_s) - 6371.0) * 1000.0;
		double num2 = num - StartTA;
		if (num2 < 0.0)
		{
			num2 += Math.PI * 2.0;
		}
		LatLonAlt latLonAlt = Shooter.Haversine(InitialHeading, num2);
		LatLonAlt latLonAlt2 = Shooter.Haversine(InitialHeading, num2 + 0.001);
		float num3 = Math2.CalcAzimuth(latLonAlt.lat * 180.0 / Math.PI, latLonAlt.lon * 180.0 / Math.PI, latLonAlt2.lat * 180.0 / Math.PI, latLonAlt2.lon * 180.0 / Math.PI);
		double num4 = (NextRecord.Radius_km - CurrentRecord.Radius_km) / (NextRecord.Time_s - CurrentRecord.Time_s) * 1000.0 * 0.000539957;
		double num5 = (NextRecord.TA - CurrentRecord.TA) / (NextRecord.Time_s - CurrentRecord.Time_s) * 3443.9170326175517;
		double speed_kts = smethod_7(num4 * num4 + num5 * num5) * 60.0 * 60.0;
		double num6 = method_1(CurrentRecord.Time_s, NextRecord.Time_s, CurrentRecord.Pitch, NextRecord.Pitch, TimeSinceLaunch_s);
		return new BallisticResult
		{
			AltASL_m = altASL_m,
			Lat_deg = smethod_1(latLonAlt.lat) * 180.0 / Math.PI,
			Lon_deg = smethod_1(latLonAlt.lon) * 180.0 / Math.PI,
			Heading_deg = num3,
			Speed_kts = speed_kts,
			Pitch_deg = num6 * 180.0 / Math.PI
		};
	}

	private double method_1(double double_0, double double_1, double double_2, double double_3, double double_4)
	{
		return (double_4 * double_2 - double_1 * double_2 - double_4 * double_3 + double_0 * double_3) / (double_0 - double_1);
	}

	private static double smethod_0(double double_0, double double_1, double double_2)
	{
		return Math.Acos((double_1 - double_1 * double_2 * double_2 - double_0) / (double_2 * double_0));
	}

	private static double smethod_1(double double_0)
	{
		while (double_0 >= Math.PI)
		{
			double_0 -= Math.PI * 2.0;
		}
		while (double_0 < -Math.PI)
		{
			double_0 += Math.PI * 2.0;
		}
		return double_0;
	}

	private static double Wrap(double angle)
	{
		while (angle >= Math.PI * 2.0)
		{
			angle -= Math.PI * 2.0;
		}
		while (angle < 0.0)
		{
			angle += Math.PI * 2.0;
		}
		return angle;
	}

	private static double smethod_2(double double_0, double double_1)
	{
		if (double_1 >= 1.0)
		{
			throw new Exception();
		}
		return Wrap(2.0 * Math.Atan(Math.Sqrt((1.0 + double_1) / (1.0 - double_1)) * Math.Tan(double_0 / 2.0)));
	}

	private static double smethod_3(double double_0, double double_1)
	{
		return 2.0 * smethod_6(smethod_5(double_0 / 2.0), smethod_7((1.0 + double_1) / (1.0 - double_1))) - double_1 * smethod_9(2.0 * smethod_6(smethod_5(double_0 / 2.0), smethod_7((1.0 + double_1) / (1.0 - double_1))));
	}

	private static double smethod_4(double double_0, double double_1)
	{
		double num = 1.0;
		if (double_1 >= 1.0)
		{
			throw new Exception();
		}
		double num2 = 0.0;
		num2 = ((!(double_0 < Math.PI)) ? (double_0 - double_1 / 2.0) : (double_0 + double_1 / 2.0));
		while (Math.Abs(num) > 1E-09)
		{
			num = (num2 - double_1 * smethod_9(num2) - double_0) / (1.0 - double_1 * smethod_8(num2));
			num2 -= num;
		}
		return num2;
	}

	public static BallisticTrajectory Factory(LatLonAlt Shooter, LatLonAlt Target, double MaxRange_nmi, bool High, double BoostTime_s)
	{
		BallisticTrajectory ballisticTrajectory = new BallisticTrajectory
		{
			Shooter = Shooter,
			Target = Target,
			BoostTime_s = BoostTime_s,
			RangeAngle_MaxRange = MaxRange_nmi * 0.00029036704151956565,
			High = High
		};
		double d = Target.lon - Shooter.lon;
		double num = Math.Acos(Math.Cos(Shooter.lat) * Math.Cos(Target.lat) * Math.Cos(d) + Math.Sin(Shooter.lat) * Math.Sin(Target.lat));
		Geodesic_Vincenty.SphericalRangeNM(ref Shooter.lat, ref Shooter.lon, ref Target.lat, ref Target.lon);
		if (num > ballisticTrajectory.RangeAngle_MaxRange)
		{
			ballisticTrajectory.RangeAngle_MaxRange = num;
		}
		ballisticTrajectory.w = (0.0 - num) / 2.0 + Math.PI;
		if (!High)
		{
			ballisticTrajectory.e = EccentricityLowTrajectory(num, ballisticTrajectory.RangeAngle_MaxRange);
		}
		else
		{
			ballisticTrajectory.e = EccentricityHighTrajectory(num, ballisticTrajectory.RangeAngle_MaxRange);
		}
		ballisticTrajectory.a_km = SemiMajorAxis(ballisticTrajectory.RangeAngle_MaxRange, (Shooter.radius_km + Target.radius_km) / 2.0);
		ballisticTrajectory.InitialHeading = MathFunctions.GetBearing(Shooter.lat * 180.0 / Math.PI, Shooter.lon * 180.0 / Math.PI, Target.lat * 180.0 / Math.PI, Target.lon * 180.0 / Math.PI) * CSMath.PI_dividedBy_180;
		ballisticTrajectory.StartTA = smethod_0(Shooter.radius_km, ballisticTrajectory.a_km, ballisticTrajectory.e);
		ballisticTrajectory.EndTA = Wrap(0.0 - smethod_0(Target.radius_km, ballisticTrajectory.a_km, ballisticTrajectory.e));
		ballisticTrajectory.FinalMeanAngularMotion_rad__s = Math.Sqrt(398600.0 / (ballisticTrajectory.a_km * ballisticTrajectory.a_km * ballisticTrajectory.a_km));
		ballisticTrajectory.DeltaMeanAngularMotion_rad__s = ballisticTrajectory.FinalMeanAngularMotion_rad__s / BoostTime_s;
		ballisticTrajectory.CurrentRecord = new Record
		{
			Time_s = 0.0,
			Phase = 1,
			Radius_km = Shooter.radius_km,
			TA = ballisticTrajectory.StartTA,
			MA = smethod_3(ballisticTrajectory.StartTA, ballisticTrajectory.e),
			CurrentMeanAngularMotion_rad__s = 0.0
		};
		ballisticTrajectory.NextRecord = ComputeNextRecord(ballisticTrajectory, ballisticTrajectory.CurrentRecord, 1.0);
		return ballisticTrajectory;
	}

	public static Record ComputeNextRecord(BallisticTrajectory bt, Record last, double dt_s)
	{
		double num = Wrap(last.MA + last.CurrentMeanAngularMotion_rad__s * dt_s);
		double num2 = smethod_2(smethod_4(num, bt.e), bt.e);
		double pitch = smethod_6(bt.e * smethod_9(num2), 1.0 + bt.e * smethod_8(num2));
		Record result = new Record
		{
			Time_s = last.Time_s + dt_s,
			MA = num,
			TA = num2,
			Phase = last.Phase,
			Radius_km = RadiusEllipse(bt.a_km, bt.e, num2),
			Pitch = pitch,
			CurrentMeanAngularMotion_rad__s = Math.Min(last.CurrentMeanAngularMotion_rad__s + bt.DeltaMeanAngularMotion_rad__s, bt.FinalMeanAngularMotion_rad__s)
		};
		if (result.Pitch > 0.0 && result.Radius_km < 6371.0)
		{
			result.Radius_km = 6371.001;
		}
		return result;
	}

	private BallisticTrajectory()
	{
	}

	private static double smethod_5(double double_0)
	{
		return Math.Tan(double_0);
	}

	private static double smethod_6(double double_0, double double_1)
	{
		return Math.Atan2(double_0, double_1);
	}

	private static double smethod_7(double double_0)
	{
		return Math.Sqrt(double_0);
	}

	private static double smethod_8(double double_0)
	{
		return Math.Cos(double_0);
	}

	private static double smethod_9(double double_0)
	{
		return Math.Sin(double_0);
	}

	private static double smethod_10(double double_0)
	{
		return Math.Asin(double_0);
	}

	private static double smethod_11(double double_0)
	{
		return 1.0 / Math.Sin(double_0);
	}

	private static double smethod_12(double double_0, double double_1)
	{
		return Math.Pow(double_0, double_1);
	}

	public static double SemiMajorAxis(double rangeAngleMaxRange, double burnoutAltitude)
	{
		return burnoutAltitude * (1.0 + smethod_9(rangeAngleMaxRange / 2.0)) / 2.0;
	}

	public static double SemiMinorAxis(double a, double e)
	{
		return smethod_7(0.0 - a * a * (-1.0 + e * e));
	}

	public static double EccentricityHighTrajectory(double rangeAngleToTarget, double rangeAngleMaxRange)
	{
		return smethod_7((1.0 + smethod_8(rangeAngleToTarget) * smethod_12(smethod_11(rangeAngleMaxRange / 2.0), 2.0) + 2.0 * smethod_8(rangeAngleToTarget / 2.0) * smethod_11(rangeAngleMaxRange / 2.0) * (1.0 + smethod_11(rangeAngleMaxRange / 2.0)) * smethod_7((smethod_8(rangeAngleMaxRange) - smethod_8(rangeAngleToTarget)) / (-3.0 + smethod_8(rangeAngleMaxRange) - 4.0 * smethod_9(rangeAngleMaxRange / 2.0)))) / smethod_12(1.0 + smethod_11(rangeAngleMaxRange / 2.0), 2.0));
	}

	public static double EccentricityLowTrajectory(double rangeAngleToTarget, double rangeAngleMaxRange)
	{
		return smethod_7((1.0 + smethod_8(rangeAngleToTarget) * smethod_12(smethod_11(rangeAngleMaxRange / 2.0), 2.0) - 2.0 * smethod_8(rangeAngleToTarget / 2.0) * smethod_11(rangeAngleMaxRange / 2.0) * (1.0 + smethod_11(rangeAngleMaxRange / 2.0)) * smethod_7((smethod_8(rangeAngleMaxRange) - smethod_8(rangeAngleToTarget)) / (-3.0 + smethod_8(rangeAngleMaxRange) - 4.0 * smethod_9(rangeAngleMaxRange / 2.0)))) / smethod_12(1.0 + smethod_11(rangeAngleMaxRange / 2.0), 2.0));
	}

	public static double RadiusEllipse(double a, double e, double TA)
	{
		return (a - a * e * e) / (1.0 + e * smethod_8(TA));
	}

	static BallisticTrajectory()
	{
		Class72.smethod_20();
	}
}
