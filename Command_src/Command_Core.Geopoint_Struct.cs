using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public struct Geopoint_Struct : IEquatable<Geopoint_Struct>
{
	public double Longitude;

	public double Latitude;

	public float Altitude;

	[ThreadStatic]
	private static StringBuilder stringBuilder_0;

	public bool HasZeroCoords
	{
		get
		{
			if (Longitude == 0.0)
			{
				return Latitude == 0.0;
			}
			return false;
		}
	}

	public bool HasNaNOrInfiniteCoords
	{
		get
		{
			if (!double.IsNaN(Longitude) && !double.IsInfinity(Longitude) && !double.IsNaN(Latitude) && !double.IsNaN(Latitude))
			{
				return false;
			}
			int result;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				result = 1;
			}
			else
			{
				result = 1;
			}
			return (byte)result != 0;
		}
	}

	public Geopoint_Struct(double theLon, double theLat)
	{
		this = default(Geopoint_Struct);
		Longitude = theLon;
		Latitude = theLat;
	}

	public Geopoint_Struct(double theLon, double theLat, float theAlt)
	{
		this = default(Geopoint_Struct);
		Longitude = theLon;
		Latitude = theLat;
		Altitude = theAlt;
	}

	internal GeoPoint ToGeoPoint()
	{
		return new GeoPoint(Longitude, Latitude, Altitude);
	}

	public ReferencePoint ToReferencePoint()
	{
		return new ReferencePoint(Longitude, Latitude);
	}

	public float RangeToPoint_Horiz(double thePoint_Lon, double thePoint_Lat)
	{
		return Math2.CalcDist(Latitude, Longitude, thePoint_Lat, thePoint_Lon);
	}

	public float RangeToPoint_Slant(Geopoint_Struct thePoint)
	{
		float num = Math2.CalcDist(Latitude, Longitude, thePoint.Latitude, thePoint.Longitude);
		float num2 = (float)((double)Math.Abs(Altitude - thePoint.Altitude) / 1852.0);
		return (float)Math.Sqrt(num * num + num2 * num2);
	}

	internal float AngleOffThisUnitsBoresight(Module_Unit.Unit ObserverUnit)
	{
		float result = default(float);
		try
		{
			float currentHeading = ObserverUnit.CurrentHeading;
			float num = Math2.CalcAzimuth(ObserverUnit.get_Latitude((GlobalVariables.BooleanObject)null), ObserverUnit.get_Longitude((GlobalVariables.BooleanObject)null), Latitude, Longitude);
			num = Math2.NormalizeBearing(num - currentHeading);
			currentHeading = 0f;
			if (num <= 180f)
			{
				result = num;
				return result;
			}
			result = 0f - (360f - num);
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100575", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal static Geopoint_Struct FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		Geopoint_Struct result = default(Geopoint_Struct);
		Geopoint_Struct result2;
		try
		{
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "Altitude":
				case "Alt":
					result.Altitude = XmlConvert.ToSingle(val.InnerText.Replace(",", "."));
					break;
				case "Latitude":
				case "Lat":
					result.Latitude = XmlConvert.ToDouble(val.InnerText.Replace(",", "."));
					break;
				case "Longitude":
				case "Lon":
					result.Longitude = XmlConvert.ToDouble(val.InnerText.Replace(",", "."));
					break;
				}
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 1032453245345634563456092839482347235847", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result2 = default(Geopoint_Struct);
			ProjectData.ClearProjectError();
		}
		return result2;
	}

	public string ToXML(HashSet<string> ObjectsAlreadySerialized)
	{
		try
		{
			if (stringBuilder_0 == null)
			{
				stringBuilder_0 = new StringBuilder();
			}
			else
			{
				stringBuilder_0.Clear();
			}
			stringBuilder_0.Append("<GPointStruct>");
			if (Longitude != 0.0)
			{
				stringBuilder_0.Append("<Lon>").Append(XmlConvert.ToString(Longitude)).Append("</Lon>");
			}
			if (Latitude != 0.0)
			{
				stringBuilder_0.Append("<Lat>").Append(XmlConvert.ToString(Latitude)).Append("</Lat>");
			}
			if (Altitude != 0f)
			{
				stringBuilder_0.Append("<Alt>").Append(XmlConvert.ToString(Altitude)).Append("</Alt>");
			}
			stringBuilder_0.Append("</GPointStruct>");
			return stringBuilder_0.ToString();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100572", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	internal bool IsOverLand(Scenario theScen)
	{
		return Terrain.GetElevation(Latitude, Longitude, RequestIsFromGUI: false, theScen) >= 0;
	}

	internal bool IsAtSea(Scenario theScen)
	{
		return Terrain.GetElevation(Latitude, Longitude, RequestIsFromGUI: false, theScen) < 0;
	}

	public bool Equals(Geopoint_Struct other)
	{
		if (Longitude == other.Longitude && Latitude == other.Latitude)
		{
			return Altitude == other.Altitude;
		}
		return false;
	}

	public static bool operator ==(Geopoint_Struct Geopoint1, Geopoint_Struct Geopoint2)
	{
		return Geopoint1.Equals(Geopoint2);
	}

	public static bool operator !=(Geopoint_Struct Geopoint1, Geopoint_Struct Geopoint2)
	{
		return !Geopoint1.Equals(Geopoint2);
	}

	private static double smethod_0(double double_0)
	{
		while (double_0 > 180.0)
		{
			double_0 -= 360.0;
		}
		while (double_0 < -180.0)
		{
			double_0 += 360.0;
		}
		return double_0;
	}

	private static double smethod_1(double double_0, double double_1)
	{
		if (double_0 > 90.0)
		{
			double_0 = 180.0 - double_0;
			double_1 = smethod_0(double_1 + 180.0);
		}
		else if (double_0 < -90.0)
		{
			double_0 = -180.0 - double_0;
			double_1 = smethod_0(double_1 + 180.0);
		}
		return double_0;
	}

	public static Geopoint_Struct ComputeOffset(Geopoint_Struct point1, Geopoint_Struct point2)
	{
		double theLon = point1.Longitude - point2.Longitude;
		double theLat = point1.Latitude - point2.Latitude;
		float theAlt = point1.Altitude - point2.Altitude;
		Geopoint_Struct result = new Geopoint_Struct(theLon, theLat, theAlt);
		result.Longitude = smethod_0(result.Longitude);
		result.Latitude = smethod_1(result.Latitude, result.Longitude);
		return result;
	}

	public Geopoint_Struct AddOffset(Geopoint_Struct offset)
	{
		double theLon = Longitude - offset.Longitude;
		double theLat = Latitude - offset.Latitude;
		float theAlt = Altitude - offset.Altitude;
		Geopoint_Struct result = new Geopoint_Struct(theLon, theLat, theAlt);
		result.Longitude = smethod_0(result.Longitude);
		result.Latitude = smethod_1(result.Latitude, result.Longitude);
		return result;
	}

	public static void AddOffset(ref double Lati, ref double Longi, ref float Alti, Geopoint_Struct offset)
	{
		Longi = smethod_0(Longi - offset.Longitude);
		Lati = smethod_1(Lati - offset.Latitude, Longi);
		Alti += offset.Altitude;
	}

	public static Geopoint_Struct AddOffset(Geopoint_Struct p, double bearingDeg, double distNm)
	{
		double num = MathFunctions.DegreesToRadians(p.Latitude);
		double num2 = MathFunctions.DegreesToRadians(p.Longitude);
		double num3 = MathFunctions.DegreesToRadians(bearingDeg);
		double num4 = distNm / 3440.065;
		double num5 = Math.Sin(num);
		double num6 = Math.Cos(num);
		double num7 = Math.Sin(num4);
		double num8 = Math.Cos(num4);
		double num9 = num5 * num8 + num6 * num7 * Math.Cos(num3);
		double radians = Math.Asin(num9);
		double y = Math.Sin(num3) * num7 * num6;
		double x = num8 - num5 * num9;
		double radians2 = num2 + Math.Atan2(y, x);
		Geopoint_Struct result = new Geopoint_Struct(MathFunctions.RadiansToDegrees(radians2), MathFunctions.RadiansToDegrees(radians), p.Altitude);
		result.Longitude = smethod_0(result.Longitude);
		result.Latitude = smethod_1(result.Latitude, result.Longitude);
		return result;
	}

	public override string ToString()
	{
		return "Lat:" + Latitude + " Lon " + Longitude;
	}

	static Geopoint_Struct()
	{
		Class72.smethod_20();
	}
}
