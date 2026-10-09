using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Xml;
using Collections.Pooled;
using CSMaterial;
using CSMaterial.ExWorldWind;
using Easy.Common;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class GeoPoint : ScenarioObject, IGeopoint
{
	public class InProgressSubArea
	{
		public List<Geopoint_Struct> points;

		private double double_0;

		private double double_1;

		private bool bool_0;

		public double startAbstractLat;

		public double endAbstractLat;

		public List<InProgressSubArea> subAreas;

		public InProgressSubArea()
		{
			points = new List<Geopoint_Struct>();
			subAreas = null;
		}

		public InProgressSubArea(Geopoint_Struct intersect, Geopoint_Struct followingPoint)
		{
			points = new List<Geopoint_Struct>();
			subAreas = null;
			openArea(intersect, followingPoint);
		}

		public void openArea(Geopoint_Struct intersect, Geopoint_Struct followingPoint)
		{
			if (-1.0 < intersect.Longitude && intersect.Longitude < 1.0)
			{
				intersect.Longitude = 0.0;
			}
			else if (followingPoint.Longitude < 0.0)
			{
				intersect.Longitude = -180.0;
			}
			else
			{
				intersect.Longitude = 180.0;
			}
			points.Add(intersect);
			points.Add(followingPoint);
		}

		public void continueArea(Geopoint_Struct followingPoint)
		{
			points.Add(followingPoint);
		}

		public void closeArea(Geopoint_Struct intersect)
		{
			if (-1.0 < intersect.Longitude && intersect.Longitude < 1.0)
			{
				intersect.Longitude = 0.0;
			}
			else if (points.Count > 0 && points[points.Count - 1].Longitude < 0.0)
			{
				intersect.Longitude = -180.0;
			}
			else
			{
				intersect.Longitude = 180.0;
			}
			points.Add(intersect);
		}

		private double mwoymmcXydt(Geopoint_Struct geopoint_Struct_0)
		{
			if (geopoint_Struct_0.Longitude == 0.0)
			{
				return -90.0 + geopoint_Struct_0.Latitude;
			}
			if (geopoint_Struct_0.Longitude != 180.0 && geopoint_Struct_0.Longitude != -180.0)
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				return 0.0;
			}
			return 90.0 - geopoint_Struct_0.Latitude;
		}

		public void calculateAbstractLat()
		{
			double_0 = mwoymmcXydt(points.First());
			double_1 = mwoymmcXydt(points.Last());
			if (double_0 > double_1)
			{
				startAbstractLat = double_1;
				endAbstractLat = double_0;
			}
			else
			{
				startAbstractLat = double_0;
				endAbstractLat = double_1;
			}
		}

		public bool containsSubArea(InProgressSubArea subArea)
		{
			if (startAbstractLat >= subArea.startAbstractLat)
			{
				return false;
			}
			return subArea.endAbstractLat < endAbstractLat;
		}

		public bool AddSubAreaIfContained(InProgressSubArea subArea)
		{
			if (!containsSubArea(subArea))
			{
				return false;
			}
			if (subAreas == null)
			{
				subAreas = new List<InProgressSubArea>();
			}
			foreach (InProgressSubArea subArea2 in subAreas)
			{
				if (subArea2.AddSubAreaIfContained(subArea))
				{
					return true;
				}
			}
			subAreas.Add(subArea);
			return true;
		}

		public void mergeWithSubAreas()
		{
			if (subAreas == null)
			{
				return;
			}
			foreach (InProgressSubArea subArea in subAreas)
			{
				subArea.mergeWithSubAreas();
				points.AddRange(subArea.points);
			}
		}

		static InProgressSubArea()
		{
			Class72.smethod_20();
		}
	}

	private double double_0;

	private double double_1;

	private float float_0;

	[ThreadStatic]
	private static StringBuilder stringBuilder_0;

	public float Altitude_AGL => Altitude - (float)Terrain.GetElevation(Latitude, Longitude, RequestIsFromGUI: false, theScen);

	public bool IsOverLand => Terrain.GetElevation(double_1, double_0, RequestIsFromGUI: false, theScen) >= 0;

	public bool IsAtSea => Terrain.GetElevation(double_1, double_0, RequestIsFromGUI: false, theScen) < 0;

	public static bool IsInCanal
	{
		get
		{
			bool result = default(bool);
			try
			{
				if (!((FixedGeoPolygon)CanalHandler.Canal_Suez()).get_PointIsInArea(theLat, theLon, NeedToCheckAntimeridian: false))
				{
					if (!((FixedGeoPolygon)CanalHandler.Canal_Panama()).get_PointIsInArea(theLat, theLon, NeedToCheckAntimeridian: false))
					{
						if (((FixedGeoPolygon)CanalHandler.Canal_Dardanelles()).get_PointIsInArea(theLat, theLon, NeedToCheckAntimeridian: false))
						{
							result = true;
							return result;
						}
						if (!((FixedGeoPolygon)CanalHandler.Canal_Bosphorus()).get_PointIsInArea(theLat, theLon, NeedToCheckAntimeridian: false))
						{
							result = false;
							return result;
						}
						result = true;
						return result;
					}
					result = true;
					return result;
				}
				result = true;
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100583", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public double Longitude
	{
		get
		{
			return double_0;
		}
		set
		{
			if (value > 180.0 || value < -180.0)
			{
				value = Math2.NormalizeLongitude(value);
			}
			if (double.IsNaN(value))
			{
				_ = Debugger.IsAttached;
				value = 0.0;
			}
			double_0 = value;
		}
	}

	public double Latitude
	{
		get
		{
			return double_1;
		}
		set
		{
			if (value > 90.0 || value < -90.0)
			{
				value = Math2.NormalizeLatitude(value);
			}
			if (double.IsNaN(value))
			{
				_ = Debugger.IsAttached;
				value = 0.0;
			}
			double_1 = value;
		}
	}

	public float Altitude
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	public string ToXML(HashSet<string> ObjectsAlreadySerialized)
	{
		try
		{
			if (stringBuilder_0 != null)
			{
				stringBuilder_0.Clear();
			}
			else
			{
				stringBuilder_0 = new StringBuilder();
			}
			stringBuilder_0.Append("<GPoint>");
			if (string.IsNullOrEmpty(ObjectID))
			{
				ObjectID = IDGenerator.Instance.Next;
			}
			stringBuilder_0.Append("<ID>").Append(ObjectID).Append("</ID>");
			if (ObjectsAlreadySerialized != null)
			{
				if (ObjectsAlreadySerialized.Contains(ObjectID))
				{
					stringBuilder_0.Append("</GPoint>");
					return stringBuilder_0.ToString();
				}
				ObjectsAlreadySerialized.Add(ObjectID);
			}
			if (double_0 != 0.0)
			{
				stringBuilder_0.Append("<Lon>").Append(XmlConvert.ToString(double_0)).Append("</Lon>");
			}
			if (double_1 != 0.0)
			{
				stringBuilder_0.Append("<Lat>").Append(XmlConvert.ToString(double_1)).Append("</Lat>");
			}
			if (float_0 != 0f)
			{
				stringBuilder_0.Append("<Alt>").Append(XmlConvert.ToString(float_0)).Append("</Alt>");
			}
			if (!string.IsNullOrEmpty(Name))
			{
				stringBuilder_0.Append("<Name>").Append(SecurityElement.Escape(Name)).Append("</Name>");
			}
			stringBuilder_0.Append("</GPoint>");
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

	public static GeoPoint FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		GeoPoint geoPoint = new GeoPoint();
		GeoPoint result;
		try
		{
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "ID":
					if (!theDictionary.ContainsKey(val.InnerText))
					{
						geoPoint.ObjectID_Set(val.InnerText);
						theDictionary.TryAdd(geoPoint.ObjectID, geoPoint);
						break;
					}
					result = (GeoPoint)theDictionary[val.InnerText];
					goto end_IL_0008;
				case "Name":
					geoPoint.Name = val.InnerText;
					break;
				case "Alt":
				case "Altitude":
					geoPoint.float_0 = XmlConvert.ToSingle(val.InnerText.Replace(",", "."));
					break;
				case "Latitude":
				case "Lat":
					FastDoubleParse.FastTryParseDouble(val.InnerText.Replace(",", "."), out geoPoint.double_1);
					break;
				case "Longitude":
				case "Lon":
					FastDoubleParse.FastTryParseDouble(val.InnerText.Replace(",", "."), out geoPoint.double_0);
					break;
				}
			}
			result = geoPoint;
			end_IL_0008:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100573", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public GeoPoint(bool AssignObjectID = true)
		: base(AssignObjectID)
	{
		Name = "";
	}

	public GeoPoint(double theLon, double theLat, bool AssignObjectID = true)
		: base(AssignObjectID)
	{
		double_0 = theLon;
		double_1 = theLat;
		Name = "";
	}

	public GeoPoint(double theLon, double theLat, float theAlt, bool AssignObjectID = true)
		: base(AssignObjectID)
	{
		double_0 = theLon;
		double_1 = theLat;
		float_0 = theAlt;
		Name = "";
	}

	public float RangeToPoint_Horiz(double thePoint_Lon, double thePoint_Lat)
	{
		return Math2.CalcDist(double_1, double_0, thePoint_Lat, thePoint_Lon);
	}

	public float RangeToPoint_Horiz(GeoPoint thePoint)
	{
		return Math2.CalcDist(double_1, double_0, thePoint.double_1, thePoint.double_0);
	}

	public float RangeToUnit_Horiz(Module_Unit.Unit theUnit)
	{
		return Math2.CalcDist(double_1, double_0, theUnit.get_Latitude((GlobalVariables.BooleanObject)null), theUnit.get_Longitude((GlobalVariables.BooleanObject)null));
	}

	public float RangeToPoint_Slant(Geopoint_Struct thePoint)
	{
		float num = Math2.CalcDist(Latitude, Longitude, thePoint.Latitude, thePoint.Longitude);
		float num2 = (float)((double)Math.Abs(Altitude - thePoint.Altitude) / 1852.0);
		return (float)Math.Sqrt(num * num + num2 * num2);
	}

	public float RangeToPoint_Slant(GeoPoint thePoint)
	{
		float num = Math2.CalcDist(Latitude, Longitude, thePoint.Latitude, thePoint.Longitude);
		float num2 = (float)((double)Math.Abs(Altitude - thePoint.Altitude) / 1852.0);
		return (float)Math.Sqrt(num * num + num2 * num2);
	}

	public static double RangeToPoint_Horiz_Angular(double StartLon, double StartLat, double thePoint_Lon, double thePoint_Lat)
	{
		double result;
		try
		{
			Angle latA = default(Angle);
			Angle lonA = default(Angle);
			Angle latB = default(Angle);
			Angle lonB = default(Angle);
			latA.Degrees = StartLat;
			lonA.Degrees = StartLon;
			latB.Degrees = thePoint_Lat;
			lonB.Degrees = thePoint_Lon;
			result = World.ApproxAngularDistance(latA, lonA, latB, lonB).Degrees;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 10032453245234", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = 0.0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public double RangeToPoint_Horiz_Angular(double thePoint_Lon, double thePoint_Lat)
	{
		try
		{
			Angle latA = default(Angle);
			Angle lonA = default(Angle);
			Angle latB = default(Angle);
			Angle lonB = default(Angle);
			latA.Degrees = Latitude;
			lonA.Degrees = Longitude;
			latB.Degrees = thePoint_Lat;
			lonB.Degrees = thePoint_Lon;
			return World.ApproxAngularDistance(latA, lonA, latB, lonB).Degrees;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100574", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return 0.0;
	}

	public ReferencePoint ToReferencePoint()
	{
		return new ReferencePoint(Longitude, Latitude);
	}

	public static bool AreaHasChanged(List<GeoPoint> theArea, List<GeoPoint> BufferedArea)
	{
		bool result;
		try
		{
			if (BufferedArea != null)
			{
				if (theArea.Count != BufferedArea.Count)
				{
					result = true;
				}
				else
				{
					int num = theArea.Count - 1;
					int num2 = 0;
					while (true)
					{
						if (num2 <= num)
						{
							int num3;
							if (theArea[num2].double_1 == BufferedArea[num2].double_1)
							{
								if (theArea[num2].double_0 == BufferedArea[num2].double_0)
								{
									num2++;
									continue;
								}
								num3 = 1;
							}
							else
							{
								num3 = 1;
							}
							result = (byte)num3 != 0;
						}
						else
						{
							result = false;
						}
						break;
					}
				}
			}
			else
			{
				result = true;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200565", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			int num4;
			if (!Debugger.IsAttached)
			{
				num4 = 0;
			}
			else
			{
				Debugger.Break();
				num4 = 0;
			}
			result = (byte)num4 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static bool AreaHasChanged(List<ReferencePoint> theArea, List<ReferencePoint> BufferedArea)
	{
		bool result;
		try
		{
			if (BufferedArea != null)
			{
				int count = theArea.Count;
				int count2 = BufferedArea.Count;
				if (count2 != 0)
				{
					if (count != count2)
					{
						result = true;
					}
					else
					{
						int num = count - 1;
						int num2 = 0;
						double num5 = default(double);
						double num6 = default(double);
						while (true)
						{
							if (num2 <= num)
							{
								double num3;
								double num4;
								try
								{
									ReferencePoint referencePoint = theArea[num2];
									num3 = referencePoint.double_1;
									num4 = referencePoint.double_0;
									if (count2 > num2)
									{
										ReferencePoint referencePoint2 = BufferedArea[num2];
										if (referencePoint2 != null)
										{
											num5 = referencePoint2.double_1;
											num6 = referencePoint2.double_0;
										}
									}
								}
								catch (Exception projectError)
								{
									ProjectData.SetProjectError(projectError);
									ProjectData.ClearProjectError();
									goto IL_00b2;
								}
								if (num3 == num5 || Math.Abs(num3 - num5) <= 0.1)
								{
									if (num4 != num6 && !(Math.Abs(num4 - num6) <= 0.1))
									{
										result = true;
										break;
									}
									goto IL_00b2;
								}
								result = true;
								break;
							}
							result = false;
							break;
							IL_00b2:
							num2++;
						}
					}
				}
				else
				{
					result = false;
				}
			}
			else
			{
				result = true;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200322", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			int num7;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num7 = 0;
			}
			else
			{
				num7 = 0;
			}
			result = (byte)num7 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
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

	public static bool PointInPolygonB3(double theLat, double theLon, double[] LongArray, double[] LatArray)
	{
		int num = LongArray.Length;
		bool flag = false;
		int num2 = num - 1;
		int num3 = num - 1;
		for (int i = 0; i <= num3; i++)
		{
			if (LatArray[i] > theLat != LatArray[num2] > theLat && theLon < (LongArray[num2] - LongArray[i]) * (theLat - LatArray[i]) / (LatArray[num2] - LatArray[i]) + LongArray[i])
			{
				flag = !flag;
			}
			num2 = i;
		}
		return flag;
	}

	internal static int isLeft(double P0_Lon, double P0_Lat, double P1_Lon, double P1_Lat, double P2_Lon, double P2_Lat)
	{
		int result = default(int);
		try
		{
			double num = (P1_Lon - P0_Lon) * (P2_Lat - P0_Lat) - (P2_Lon - P0_Lon) * (P1_Lat - P0_Lat);
			if (num <= 0.0)
			{
				if (num < 0.0)
				{
					result = -1;
					return result;
				}
				result = 0;
				return result;
			}
			result = 1;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100581", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private static int smethod_0(GeoPoint geoPoint_0, GeoPoint geoPoint_1, GeoPoint geoPoint_2)
	{
		int result = default(int);
		try
		{
			double longitude = geoPoint_0.Longitude;
			double latitude = geoPoint_0.Latitude;
			double longitude2 = geoPoint_1.Longitude;
			double latitude2 = geoPoint_1.Latitude;
			double longitude3 = geoPoint_2.Longitude;
			double latitude3 = geoPoint_2.Latitude;
			double num = (longitude2 - longitude) * (latitude3 - latitude) - (longitude3 - longitude) * (latitude2 - latitude);
			if (num > 0.0)
			{
				result = 1;
				return result;
			}
			if (num < 0.0)
			{
				result = -1;
				return result;
			}
			result = 0;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100582", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static bool IsInPierLane(double theLat, double theLon, Scenario theScen)
	{
		bool result = default(bool);
		if (theScen != null)
		{
			int num5;
			if (theScen.Cache_FacilitiesWithPiers != null)
			{
				if (theScen.Cache_FacilitiesWithPiers.Length != 0)
				{
					try
					{
						int num = theScen.Cache_FacilitiesWithPiers.Length - 1;
						while (true)
						{
							if (num >= 0)
							{
								ActiveUnit activeUnit = theScen.Cache_FacilitiesWithPiers[num];
								double num2 = activeUnit.get_Latitude(GlobalVariables.ObjectTrue);
								ActiveUnit_DockingOps dockingOps = activeUnit.DockingOps;
								double num3 = Math2.Distance_To_AngularDegrees(dockingOps.PierLaneLength);
								if (theLat > num2 + num3 || theLat < num2 - num3 || Module_Unit.RangeToPoint_Horiz(activeUnit, theLat, theLon, GlobalVariables.ObjectTrue) > dockingOps.PierLaneLength || !IsInsideThisArea(theLat, theLon, dockingOps.PierEntranceLane, HaveToCheckAntimeridian: false))
								{
									num += -1;
									continue;
								}
								result = true;
								break;
							}
							result = false;
							break;
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2?.Data.Add("Error at 200462", ex2.Message);
						GameGeneral.WriteExceptionsToLog(ex2);
						int num4;
						if (Debugger.IsAttached)
						{
							Debugger.Break();
							num4 = 0;
						}
						else
						{
							num4 = 0;
						}
						result = (byte)num4 != 0;
						ProjectData.ClearProjectError();
					}
					goto IL_00eb;
				}
				num5 = 0;
			}
			else
			{
				num5 = 0;
			}
			result = (byte)num5 != 0;
		}
		goto IL_00eb;
		IL_00eb:
		return result;
	}

	public static GeoPoint GetNewPoint(GeoPoint SourcePoint, float theBearing, float theDistance)
	{
		GeoPoint geoPoint = new GeoPoint();
		double longitude = SourcePoint.Longitude;
		double latitude = SourcePoint.Latitude;
		GeoPoint geoPoint2;
		double out_lon = (geoPoint2 = geoPoint).Longitude;
		GeoPoint geoPoint3;
		double out_lat = (geoPoint3 = geoPoint).Latitude;
		Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref out_lon, ref out_lat, theDistance, theBearing);
		geoPoint3.Latitude = out_lat;
		geoPoint2.Longitude = out_lon;
		return geoPoint;
	}

	public static GeoPoint GetNewPoint(double theLat, double theLon, float theBearing, float theDistance)
	{
		GeoPoint geoPoint = new GeoPoint();
		GeoPoint geoPoint2;
		double out_lon = (geoPoint2 = geoPoint).Longitude;
		GeoPoint geoPoint3;
		double out_lat = (geoPoint3 = geoPoint).Latitude;
		Geodesic_EdWilliams.CalcPoint_Williams(theLon, theLat, ref out_lon, ref out_lat, theDistance, theBearing);
		geoPoint3.Latitude = out_lat;
		geoPoint2.Longitude = out_lon;
		return geoPoint;
	}

	public static Geopoint_Struct GetNewPoint_Struct(double theLat, double theLon, float theBearing, float theDistance)
	{
		Geopoint_Struct result = default(Geopoint_Struct);
		Geodesic_EdWilliams.CalcPoint_Williams(theLon, theLat, ref result.Longitude, ref result.Latitude, theDistance, theBearing);
		return result;
	}

	internal Geopoint_Struct ToGeopoint_Struct()
	{
		return new Geopoint_Struct(double_0, double_1, float_0);
	}

	public static bool ZoneHasChanged(List<ReferencePoint> Area, List<ReferencePoint> BufferedArea)
	{
		if (Area.Count != BufferedArea.Count)
		{
			return true;
		}
		int num = Area.Count - 1;
		int num2 = 0;
		int result;
		while (true)
		{
			if (num2 <= num)
			{
				ReferencePoint referencePoint = Area[num2];
				ReferencePoint referencePoint2 = BufferedArea[num2];
				if (referencePoint.double_1 == referencePoint2.double_1)
				{
					if (referencePoint.double_0 == referencePoint2.double_0)
					{
						num2++;
						continue;
					}
					result = 1;
					break;
				}
				result = 1;
				break;
			}
			return false;
		}
		return (byte)result != 0;
	}

	public static Geopoint_Struct InterpolateGeopoint(GeoPoint startWP, GeoPoint endWP, double fraction)
	{
		double latitude = startWP.double_1 + fraction * (endWP.double_1 - startWP.double_1);
		double longitude = startWP.double_0 + fraction * (endWP.double_0 - startWP.double_0);
		return new Geopoint_Struct
		{
			Latitude = latitude,
			Longitude = longitude
		};
	}

	public static bool SegmentCrossesAntimeridian(double ptALon, double ptBLon, [Optional][DefaultParameterValue(false)] ref bool segmentCrossesMeridian)
	{
		if (ptALon > 0.0 == ptBLon > 0.0)
		{
			return false;
		}
		double num;
		double num2;
		if (ptALon > ptBLon)
		{
			num = ptALon;
			num2 = ptBLon;
		}
		else
		{
			num2 = ptALon;
			num = ptBLon;
		}
		double num3 = 180.0 + num2;
		if (num > num3)
		{
			return true;
		}
		segmentCrossesMeridian = true;
		return false;
	}

	public static bool SegmentCrossesAntimeridianOrMeridian(double ptALon, double ptBLon)
	{
		if (ptALon > 0.0 == ptBLon > 0.0)
		{
			return false;
		}
		if (ptALon <= ptBLon)
		{
		}
		return true;
	}

	public static bool SegmentCrossesAntimeridianOrMeridian_WithIntersection(double ptALon, double ptALat, double ptBLon, double ptBLat, ref Geopoint_Struct intersect, ref bool segmentCrossesAntimeridian, ref bool segmentCrossesMeridian, ref bool clockwise)
	{
		clockwise = ptALon > ptBLon;
		if (ptALon > 0.0 == ptBLon > 0.0)
		{
			segmentCrossesAntimeridian = false;
			segmentCrossesMeridian = false;
			clockwise = !clockwise;
			return false;
		}
		double num;
		double num2;
		if (ptALon > ptBLon)
		{
			num = ptALon;
			num2 = ptBLon;
		}
		else
		{
			num2 = ptALon;
			num = ptBLon;
		}
		double num3 = 180.0 + num2;
		Geopoint_Struct? geopoint_Struct;
		if (num > num3)
		{
			segmentCrossesMeridian = false;
			clockwise = !clockwise;
			segmentCrossesAntimeridian = true;
			geopoint_Struct = AntimeridianOrMeridianIntersection(ptALon, ptALat, ptBLon, ptBLat);
			int result;
			if (!geopoint_Struct.HasValue)
			{
				result = 1;
			}
			else
			{
				intersect = geopoint_Struct.Value;
				result = 1;
			}
			return (byte)result != 0;
		}
		segmentCrossesAntimeridian = false;
		segmentCrossesMeridian = true;
		geopoint_Struct = AntimeridianOrMeridianIntersection(ptALon, ptALat, ptBLon, ptBLat);
		int result2;
		if (geopoint_Struct.HasValue)
		{
			intersect = geopoint_Struct.Value;
			result2 = 1;
		}
		else
		{
			result2 = 1;
		}
		return (byte)result2 != 0;
	}

	public static bool PolygonCrossesAntimeridian(Geopoint_Struct[] theArea)
	{
		if (theArea != null)
		{
			int num = theArea.Length;
			if (num >= 2)
			{
				double num2 = theArea[num - 1].Longitude;
				if (num2 < -180.0 || num2 > 180.0)
				{
					num2 = Math2.NormalizeLongitude(num2);
				}
				int num3 = num - 1;
				int num4 = 0;
				while (true)
				{
					if (num4 <= num3)
					{
						double num5 = theArea[num4].Longitude;
						if (num5 < -180.0 || num5 > 180.0)
						{
							num5 = Math2.NormalizeLongitude(num5);
						}
						double ptALon = num2;
						double ptBLon = num5;
						bool segmentCrossesMeridian = false;
						if (SegmentCrossesAntimeridian(ptALon, ptBLon, ref segmentCrossesMeridian))
						{
							break;
						}
						num2 = num5;
						num4++;
						continue;
					}
					return false;
				}
				return true;
			}
			return false;
		}
		return false;
	}

	public static bool PolygonCrossesAntimeridian(PooledList<Geopoint_Struct> theArea)
	{
		if (theArea == null)
		{
			return false;
		}
		int count = theArea.Count;
		if (count < 2)
		{
			return false;
		}
		double num = Math2.NormalizeLongitude(theArea[count - 1].Longitude);
		int num2 = count - 1;
		int num3 = 0;
		while (true)
		{
			if (num3 <= num2)
			{
				double num4 = Math2.NormalizeLongitude(theArea[num3].Longitude);
				double ptALon = num;
				bool segmentCrossesMeridian = false;
				if (SegmentCrossesAntimeridian(ptALon, num4, ref segmentCrossesMeridian))
				{
					break;
				}
				num = num4;
				num3++;
				continue;
			}
			return false;
		}
		return true;
	}

	public static bool PolygonCrossesAntimeridian(List<Geopoint_Struct> theArea)
	{
		if (theArea == null)
		{
			return false;
		}
		int count = theArea.Count;
		if (count >= 2)
		{
			double num = Math2.NormalizeLongitude(theArea[count - 1].Longitude);
			int num2 = count - 1;
			int num3 = 0;
			while (true)
			{
				if (num3 <= num2)
				{
					double num4 = Math2.NormalizeLongitude(theArea[num3].Longitude);
					double ptALon = num;
					bool segmentCrossesMeridian = false;
					if (SegmentCrossesAntimeridian(ptALon, num4, ref segmentCrossesMeridian))
					{
						break;
					}
					num = num4;
					num3++;
					continue;
				}
				return false;
			}
			return true;
		}
		return false;
	}

	public static bool PolygonCrossesAntimeridian(GeoPoint[] theArea)
	{
		if (theArea == null)
		{
			return false;
		}
		int num = theArea.Count();
		if (num < 2)
		{
			return false;
		}
		double num2 = Math2.NormalizeLongitude(theArea[num - 1].double_0);
		int num3 = num - 1;
		int num4 = 0;
		while (true)
		{
			if (num4 <= num3)
			{
				double num5 = Math2.NormalizeLongitude(theArea[num4].double_0);
				double ptALon = num2;
				bool segmentCrossesMeridian = false;
				if (SegmentCrossesAntimeridian(ptALon, num5, ref segmentCrossesMeridian))
				{
					break;
				}
				num2 = num5;
				num4++;
				continue;
			}
			return false;
		}
		return true;
	}

	public static bool PolygonCrossesAntimeridian(List<GeoPoint> theArea)
	{
		if (theArea == null)
		{
			return false;
		}
		int count = theArea.Count;
		if (count < 2)
		{
			return false;
		}
		double num = Math2.NormalizeLongitude(theArea[count - 1].double_0);
		int num2 = count - 1;
		int num3 = 0;
		while (true)
		{
			if (num3 <= num2)
			{
				double num4 = Math2.NormalizeLongitude(theArea[num3].double_0);
				double ptALon = num;
				bool segmentCrossesMeridian = false;
				if (SegmentCrossesAntimeridian(ptALon, num4, ref segmentCrossesMeridian))
				{
					break;
				}
				num = num4;
				num3++;
				continue;
			}
			return false;
		}
		return true;
	}

	public static bool PolygonCrossesAntimeridian(ReferencePoint[] theArea)
	{
		if (theArea != null)
		{
			int num = theArea.Count();
			if (num < 2)
			{
				return false;
			}
			double num2 = Math2.NormalizeLongitude(theArea[num - 1].double_0);
			int num3 = num - 1;
			int num4 = 0;
			while (true)
			{
				if (num4 <= num3)
				{
					double num5 = Math2.NormalizeLongitude(theArea[num4].double_0);
					double ptALon = num2;
					bool segmentCrossesMeridian = false;
					if (SegmentCrossesAntimeridian(ptALon, num5, ref segmentCrossesMeridian))
					{
						break;
					}
					num2 = num5;
					num4++;
					continue;
				}
				return false;
			}
			return true;
		}
		return false;
	}

	public static bool PolygonCrossesAntimeridian(List<ReferencePoint> theArea)
	{
		if (theArea != null)
		{
			int count = theArea.Count;
			if (count < 2)
			{
				return false;
			}
			double num = Math2.NormalizeLongitude(theArea[count - 1].double_0);
			int num2 = count - 1;
			int num3 = 0;
			while (true)
			{
				if (num3 <= num2)
				{
					double num4 = Math2.NormalizeLongitude(theArea[num3].double_0);
					double ptALon = num;
					bool segmentCrossesMeridian = false;
					if (SegmentCrossesAntimeridian(ptALon, num4, ref segmentCrossesMeridian))
					{
						break;
					}
					num = num4;
					num3++;
					continue;
				}
				return false;
			}
			return true;
		}
		return false;
	}

	public static bool PointInPolygonBoundingBox(double theLat, double theLon, Geopoint_Struct[] poly, [Optional][DefaultParameterValue(-90.0)] ref double BoundNorth, [Optional][DefaultParameterValue(90.0)] ref double BoundSouth)
	{
		int num = poly.Length;
		BoundNorth = -90.0;
		BoundSouth = 90.0;
		double num2 = 180.0;
		double num3 = -180.0;
		int num4 = num - 1;
		for (int i = 0; i <= num4; i++)
		{
			Geopoint_Struct geopoint_Struct = poly[i];
			double latitude = geopoint_Struct.Latitude;
			double longitude = geopoint_Struct.Longitude;
			if (latitude > BoundNorth)
			{
				BoundNorth = latitude;
			}
			if (latitude < BoundSouth)
			{
				BoundSouth = latitude;
			}
			if (longitude > num3)
			{
				num3 = longitude;
			}
			if (longitude < num2)
			{
				num2 = longitude;
			}
		}
		int result;
		if (!(theLat > BoundNorth) && !(theLat < BoundSouth) && !(theLon > num3))
		{
			if (!(theLon < num2))
			{
				return true;
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public static bool PointInPolygonBoundingBox(double theLat, double theLon, PooledList<Geopoint_Struct> poly, [Optional][DefaultParameterValue(-90.0)] ref double BoundNorth, [Optional][DefaultParameterValue(90.0)] ref double BoundSouth)
	{
		int count = poly.Count;
		BoundNorth = -90.0;
		BoundSouth = 90.0;
		double num = 180.0;
		double num2 = -180.0;
		int num3 = count - 1;
		for (int i = 0; i <= num3; i++)
		{
			Geopoint_Struct geopoint_Struct = poly[i];
			double latitude = geopoint_Struct.Latitude;
			double longitude = geopoint_Struct.Longitude;
			if (latitude > BoundNorth)
			{
				BoundNorth = latitude;
			}
			if (latitude < BoundSouth)
			{
				BoundSouth = latitude;
			}
			if (longitude > num2)
			{
				num2 = longitude;
			}
			if (longitude < num)
			{
				num = longitude;
			}
		}
		int result;
		if (!(theLat > BoundNorth) && !(theLat < BoundSouth) && !(theLon > num2))
		{
			if (!(theLon < num))
			{
				return true;
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public static bool PointInPolygonBoundingBox(double theLat, double theLon, List<Geopoint_Struct> poly, [Optional][DefaultParameterValue(-90.0)] ref double BoundNorth, [Optional][DefaultParameterValue(90.0)] ref double BoundSouth)
	{
		int count = poly.Count;
		BoundNorth = -90.0;
		BoundSouth = 90.0;
		double num = 180.0;
		double num2 = -180.0;
		int num3 = count - 1;
		for (int i = 0; i <= num3; i++)
		{
			Geopoint_Struct geopoint_Struct = poly[i];
			double latitude = geopoint_Struct.Latitude;
			double longitude = geopoint_Struct.Longitude;
			if (latitude > BoundNorth)
			{
				BoundNorth = latitude;
			}
			if (latitude < BoundSouth)
			{
				BoundSouth = latitude;
			}
			if (longitude > num2)
			{
				num2 = longitude;
			}
			if (longitude < num)
			{
				num = longitude;
			}
		}
		int result;
		if (!(theLat > BoundNorth) && !(theLat < BoundSouth) && !(theLon > num2))
		{
			if (!(theLon < num))
			{
				return true;
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public static bool PointInPolygonBoundingBox(double theLat, double theLon, GeoPoint[] poly, [Optional][DefaultParameterValue(-90.0)] ref double BoundNorth, [Optional][DefaultParameterValue(90.0)] ref double BoundSouth)
	{
		int num = poly.Length;
		BoundNorth = -90.0;
		BoundSouth = 90.0;
		double num2 = 180.0;
		double num3 = -180.0;
		int num4 = num - 1;
		for (int i = 0; i <= num4; i++)
		{
			GeoPoint obj = poly[i];
			double num5 = obj.double_1;
			double num6 = obj.double_0;
			if (num5 > BoundNorth)
			{
				BoundNorth = num5;
			}
			if (num5 < BoundSouth)
			{
				BoundSouth = num5;
			}
			if (num6 > num3)
			{
				num3 = num6;
			}
			if (num6 < num2)
			{
				num2 = num6;
			}
		}
		int result;
		if (!(theLat > BoundNorth) && !(theLat < BoundSouth) && !(theLon > num3))
		{
			if (!(theLon < num2))
			{
				return true;
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public static bool PointInPolygonBoundingBox(double theLat, double theLon, List<GeoPoint> poly, [Optional][DefaultParameterValue(-90.0)] ref double BoundNorth, [Optional][DefaultParameterValue(90.0)] ref double BoundSouth)
	{
		int count = poly.Count;
		BoundNorth = -90.0;
		BoundSouth = 90.0;
		double num = 180.0;
		double num2 = -180.0;
		int num3 = count - 1;
		for (int i = 0; i <= num3; i++)
		{
			GeoPoint geoPoint = poly[i];
			double num4 = geoPoint.double_1;
			double num5 = geoPoint.double_0;
			if (num4 > BoundNorth)
			{
				BoundNorth = num4;
			}
			if (num4 < BoundSouth)
			{
				BoundSouth = num4;
			}
			if (num5 > num2)
			{
				num2 = num5;
			}
			if (num5 < num)
			{
				num = num5;
			}
		}
		int result;
		if (!(theLat > BoundNorth) && !(theLat < BoundSouth) && !(theLon > num2))
		{
			if (!(theLon < num))
			{
				return true;
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public static bool PointInPolygonBoundingBox(double theLat, double theLon, ReferencePoint[] poly, [Optional][DefaultParameterValue(-90.0)] ref double BoundNorth, [Optional][DefaultParameterValue(90.0)] ref double BoundSouth)
	{
		int num = poly.Length;
		BoundNorth = -90.0;
		BoundSouth = 90.0;
		double num2 = 180.0;
		double num3 = -180.0;
		int num4 = num - 1;
		for (int i = 0; i <= num4; i++)
		{
			ReferencePoint obj = poly[i];
			double num5 = obj.double_1;
			double num6 = obj.double_0;
			if (num5 > BoundNorth)
			{
				BoundNorth = num5;
			}
			if (num5 < BoundSouth)
			{
				BoundSouth = num5;
			}
			if (num6 > num3)
			{
				num3 = num6;
			}
			if (num6 < num2)
			{
				num2 = num6;
			}
		}
		int result;
		if (!(theLat > BoundNorth) && !(theLat < BoundSouth) && !(theLon > num3))
		{
			if (!(theLon < num2))
			{
				return true;
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public static bool PointInPolygonBoundingBox(double theLat, double theLon, List<ReferencePoint> poly, [Optional][DefaultParameterValue(-90.0)] ref double BoundNorth, [Optional][DefaultParameterValue(90.0)] ref double BoundSouth)
	{
		int count = poly.Count;
		BoundNorth = -90.0;
		BoundSouth = 90.0;
		double num = 180.0;
		double num2 = -180.0;
		int num3 = count - 1;
		for (int i = 0; i <= num3; i++)
		{
			ReferencePoint referencePoint = poly[i];
			double num4 = referencePoint.double_1;
			double num5 = referencePoint.double_0;
			if (num4 > BoundNorth)
			{
				BoundNorth = num4;
			}
			if (num4 < BoundSouth)
			{
				BoundSouth = num4;
			}
			if (num5 > num2)
			{
				num2 = num5;
			}
			if (num5 < num)
			{
				num = num5;
			}
		}
		int result;
		if (!(theLat > BoundNorth) && !(theLat < BoundSouth) && !(theLon > num2))
		{
			if (!(theLon < num))
			{
				return true;
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public static bool PointInPolygonHorizRayCast(double theLat, double theLon, Geopoint_Struct[] poly)
	{
		int num = poly.Length;
		if (num < 3)
		{
			return false;
		}
		bool flag = false;
		int num2 = num - 1;
		int num3 = num - 1;
		for (int i = 0; i <= num3; i++)
		{
			Geopoint_Struct geopoint_Struct = poly[i];
			Geopoint_Struct geopoint_Struct2 = poly[num2];
			double latitude = geopoint_Struct.Latitude;
			double longitude = geopoint_Struct.Longitude;
			double latitude2 = geopoint_Struct2.Latitude;
			double longitude2 = geopoint_Struct2.Longitude;
			if (latitude > theLat != latitude2 > theLat && theLon < (longitude2 - longitude) * (theLat - latitude) / (latitude2 - latitude) + longitude)
			{
				flag = !flag;
			}
			num2 = i;
		}
		return flag;
	}

	public static bool PointInPolygonHorizRayCast(double theLat, double theLon, PooledList<Geopoint_Struct> poly)
	{
		int count = poly.Count;
		if (count < 3)
		{
			return false;
		}
		bool flag = false;
		int index = count - 1;
		int num = count - 1;
		for (int i = 0; i <= num; i++)
		{
			Geopoint_Struct geopoint_Struct = poly[i];
			Geopoint_Struct geopoint_Struct2 = poly[index];
			double latitude = geopoint_Struct.Latitude;
			double longitude = geopoint_Struct.Longitude;
			double latitude2 = geopoint_Struct2.Latitude;
			double longitude2 = geopoint_Struct2.Longitude;
			if (latitude > theLat != latitude2 > theLat && theLon < (longitude2 - longitude) * (theLat - latitude) / (latitude2 - latitude) + longitude)
			{
				flag = !flag;
			}
			index = i;
		}
		return flag;
	}

	public static bool PointInPolygonHorizRayCast(double theLat, double theLon, List<Geopoint_Struct> poly)
	{
		int count = poly.Count;
		if (count < 3)
		{
			return false;
		}
		bool flag = false;
		int index = count - 1;
		int num = count - 1;
		for (int i = 0; i <= num; i++)
		{
			Geopoint_Struct geopoint_Struct = poly[i];
			Geopoint_Struct geopoint_Struct2 = poly[index];
			double latitude = geopoint_Struct.Latitude;
			double longitude = geopoint_Struct.Longitude;
			double latitude2 = geopoint_Struct2.Latitude;
			double longitude2 = geopoint_Struct2.Longitude;
			if (latitude > theLat != latitude2 > theLat && theLon < (longitude2 - longitude) * (theLat - latitude) / (latitude2 - latitude) + longitude)
			{
				flag = !flag;
			}
			index = i;
		}
		return flag;
	}

	public static bool PointInPolygonHorizRayCast(double theLat, double theLon, GeoPoint[] poly)
	{
		int num = poly.Length;
		if (num < 3)
		{
			return false;
		}
		bool flag = false;
		int num2 = num - 1;
		int num3 = num - 1;
		for (int i = 0; i <= num3; i++)
		{
			GeoPoint geoPoint = poly[i];
			GeoPoint obj = poly[num2];
			double num4 = geoPoint.double_1;
			double num5 = geoPoint.double_0;
			double num6 = obj.double_1;
			double num7 = obj.double_0;
			if (num4 > theLat != num6 > theLat && theLon < (num7 - num5) * (theLat - num4) / (num6 - num4) + num5)
			{
				flag = !flag;
			}
			num2 = i;
		}
		return flag;
	}

	public static bool PointInPolygonHorizRayCast(double theLat, double theLon, List<GeoPoint> poly)
	{
		int count = poly.Count;
		if (count < 3)
		{
			return false;
		}
		bool flag = false;
		int index = count - 1;
		int num = count - 1;
		for (int i = 0; i <= num; i++)
		{
			GeoPoint geoPoint = poly[i];
			GeoPoint geoPoint2 = poly[index];
			double num2 = geoPoint.double_1;
			double num3 = geoPoint.double_0;
			double num4 = geoPoint2.double_1;
			double num5 = geoPoint2.double_0;
			if (num2 > theLat != num4 > theLat && theLon < (num5 - num3) * (theLat - num2) / (num4 - num2) + num3)
			{
				flag = !flag;
			}
			index = i;
		}
		return flag;
	}

	public static bool PointInPolygonHorizRayCast(double theLat, double theLon, ReferencePoint[] poly)
	{
		int num = poly.Length;
		if (num < 3)
		{
			return false;
		}
		bool flag = false;
		int num2 = num - 1;
		int num3 = num - 1;
		for (int i = 0; i <= num3; i++)
		{
			ReferencePoint referencePoint = poly[i];
			ReferencePoint obj = poly[num2];
			double num4 = referencePoint.double_1;
			double num5 = referencePoint.double_0;
			double num6 = obj.double_1;
			double num7 = obj.double_0;
			if (num4 > theLat != num6 > theLat && theLon < (num7 - num5) * (theLat - num4) / (num6 - num4) + num5)
			{
				flag = !flag;
			}
			num2 = i;
		}
		return flag;
	}

	public static bool PointInPolygonHorizRayCast(double theLat, double theLon, List<ReferencePoint> poly)
	{
		int count = poly.Count;
		if (count < 3)
		{
			return false;
		}
		bool flag = false;
		int index = count - 1;
		int num = count - 1;
		for (int i = 0; i <= num; i++)
		{
			ReferencePoint referencePoint = poly[i];
			ReferencePoint referencePoint2 = poly[index];
			double num2 = referencePoint.double_1;
			double num3 = referencePoint.double_0;
			double num4 = referencePoint2.double_1;
			double num5 = referencePoint2.double_0;
			if (num2 > theLat != num4 > theLat && theLon < (num5 - num3) * (theLat - num2) / (num4 - num2) + num3)
			{
				flag = !flag;
			}
			index = i;
		}
		return flag;
	}

	public static bool IsInsideThisArea(double PointLat, double PointLon, Geopoint_Struct[] theArea, bool HaveToCheckAntimeridian = true)
	{
		bool result = default(bool);
		try
		{
			if (theArea == null)
			{
				result = false;
				return result;
			}
			if (theArea.Count() < 3)
			{
				result = false;
				return result;
			}
			if (PolygonCrossesAntimeridian(theArea))
			{
				result = PointInPolygonGeodesicRayCast(PointLat, PointLon, theArea);
				return result;
			}
			double BoundNorth = default(double);
			double BoundSouth = default(double);
			if (!PointInPolygonBoundingBox(PointLat, PointLon, theArea, ref BoundNorth, ref BoundSouth))
			{
				result = false;
				return result;
			}
			if (BoundNorth > 80.0 && BoundSouth < -80.0)
			{
				result = PointInPolygonGeodesicRayCast(PointLat, PointLon, theArea);
				return result;
			}
			result = PointInPolygonHorizRayCast(PointLat, PointLon, theArea);
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100577502503", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static bool IsInsideThisArea(double PointLat, double PointLon, PooledList<Geopoint_Struct> theArea, bool HaveToCheckAntimeridian = true)
	{
		bool result = default(bool);
		try
		{
			if (theArea == null)
			{
				result = false;
				return result;
			}
			if (theArea.Count < 3)
			{
				result = false;
				return result;
			}
			if (!PolygonCrossesAntimeridian(theArea))
			{
				double BoundNorth = default(double);
				double BoundSouth = default(double);
				if (!PointInPolygonBoundingBox(PointLat, PointLon, theArea, ref BoundNorth, ref BoundSouth))
				{
					result = false;
					return result;
				}
				if (BoundNorth > 80.0 && BoundSouth < -80.0)
				{
					result = PointInPolygonGeodesicRayCast(PointLat, PointLon, theArea);
					return result;
				}
				result = PointInPolygonHorizRayCast(PointLat, PointLon, theArea);
				return result;
			}
			result = PointInPolygonGeodesicRayCast(PointLat, PointLon, theArea);
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100577502517", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static bool IsInsideThisArea(double PointLat, double PointLon, List<Geopoint_Struct> theArea, bool HaveToCheckAntimeridian = true)
	{
		bool result = default(bool);
		try
		{
			if (theArea != null)
			{
				if (theArea.Count < 3)
				{
					result = false;
					return result;
				}
				if (!PolygonCrossesAntimeridian(theArea))
				{
					double BoundNorth = default(double);
					double BoundSouth = default(double);
					if (PointInPolygonBoundingBox(PointLat, PointLon, theArea, ref BoundNorth, ref BoundSouth))
					{
						if (BoundNorth > 80.0 && BoundSouth < -80.0)
						{
							result = PointInPolygonGeodesicRayCast(PointLat, PointLon, theArea);
							return result;
						}
						result = PointInPolygonHorizRayCast(PointLat, PointLon, theArea);
						return result;
					}
					result = false;
					return result;
				}
				result = PointInPolygonGeodesicRayCast(PointLat, PointLon, theArea);
				return result;
			}
			result = false;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100577502517", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static bool IsInsideThisArea(double PointLat, double PointLon, GeoPoint[] theArea, bool HaveToCheckAntimeridian = true)
	{
		bool result = default(bool);
		try
		{
			if (theArea != null)
			{
				if (theArea.Count() >= 3)
				{
					if (PolygonCrossesAntimeridian(theArea))
					{
						result = PointInPolygonGeodesicRayCast(PointLat, PointLon, theArea);
						return result;
					}
					double BoundNorth = default(double);
					double BoundSouth = default(double);
					if (!PointInPolygonBoundingBox(PointLat, PointLon, theArea, ref BoundNorth, ref BoundSouth))
					{
						result = false;
						return result;
					}
					if (BoundNorth > 80.0 && BoundSouth < -80.0)
					{
						result = PointInPolygonGeodesicRayCast(PointLat, PointLon, theArea);
						return result;
					}
					result = PointInPolygonHorizRayCast(PointLat, PointLon, theArea);
					return result;
				}
				result = false;
				return result;
			}
			result = false;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100577502531", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static bool IsInsideThisArea(double PointLat, double PointLon, List<GeoPoint> theArea, bool HaveToCheckAntimeridian = true)
	{
		bool result = default(bool);
		try
		{
			if (theArea != null)
			{
				if (theArea.Count < 3)
				{
					result = false;
					return result;
				}
				if (PolygonCrossesAntimeridian(theArea))
				{
					result = PointInPolygonGeodesicRayCast(PointLat, PointLon, theArea);
					return result;
				}
				double BoundNorth = default(double);
				double BoundSouth = default(double);
				if (PointInPolygonBoundingBox(PointLat, PointLon, theArea, ref BoundNorth, ref BoundSouth))
				{
					if (BoundNorth > 80.0 && BoundSouth < -80.0)
					{
						result = PointInPolygonGeodesicRayCast(PointLat, PointLon, theArea);
						return result;
					}
					result = PointInPolygonHorizRayCast(PointLat, PointLon, theArea);
					return result;
				}
				result = false;
				return result;
			}
			result = false;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100577502550", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static bool IsInsideThisArea(double PointLat, double PointLon, ReferencePoint[] theArea, bool HaveToCheckAntimeridian = true)
	{
		bool result = default(bool);
		try
		{
			if (theArea != null)
			{
				if (theArea.Count() < 3)
				{
					result = false;
					return result;
				}
				if (!PolygonCrossesAntimeridian(theArea))
				{
					double BoundNorth = default(double);
					double BoundSouth = default(double);
					if (PointInPolygonBoundingBox(PointLat, PointLon, theArea, ref BoundNorth, ref BoundSouth))
					{
						if (BoundNorth > 80.0 && BoundSouth < -80.0)
						{
							result = PointInPolygonGeodesicRayCast(PointLat, PointLon, theArea);
							return result;
						}
						result = PointInPolygonHorizRayCast(PointLat, PointLon, theArea);
						return result;
					}
					result = false;
					return result;
				}
				result = PointInPolygonGeodesicRayCast(PointLat, PointLon, theArea);
				return result;
			}
			result = false;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 10057750251099", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static bool IsInsideThisArea(double PointLat, double PointLon, List<ReferencePoint> theArea, bool HaveToCheckAntimeridian = true)
	{
		bool result = default(bool);
		try
		{
			if (theArea == null)
			{
				result = false;
				return result;
			}
			if (theArea.Count < 3)
			{
				result = false;
				return result;
			}
			if (PolygonCrossesAntimeridian(theArea))
			{
				result = PointInPolygonGeodesicRayCast(PointLat, PointLon, theArea);
				return result;
			}
			double BoundNorth = default(double);
			double BoundSouth = default(double);
			if (!PointInPolygonBoundingBox(PointLat, PointLon, theArea, ref BoundNorth, ref BoundSouth))
			{
				result = false;
				return result;
			}
			if (BoundNorth > 80.0 && BoundSouth < -80.0)
			{
				result = PointInPolygonGeodesicRayCast(PointLat, PointLon, theArea);
				return result;
			}
			result = PointInPolygonHorizRayCast(PointLat, PointLon, theArea);
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 10057750251117", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private static Geopoint_Struct smethod_1(double double_2, double double_3, double double_4)
	{
		double num = double_3 + double_4;
		double num2 = double_2;
		if (num > 90.0)
		{
			num = 180.0 - num;
			num2 = Math2.NormalizeLongitudePreserveNegative180(num2 + 180.0);
		}
		else if (num < -90.0)
		{
			num = -180.0 - num;
			num2 = Math2.NormalizeLongitudePreserveNegative180(num2 + 180.0);
		}
		return new Geopoint_Struct(num2, num);
	}

	public static bool PointInPolygonGeodesicRayCast(double theLat, double theLon, Geopoint_Struct[] poly)
	{
		if (poly.Length >= 3)
		{
			Geopoint_Struct geopoint_Struct = smethod_1(theLon, theLat, 90.0);
			return GeoSegmentIntersect_Geodesic_ListIntersectCountOptimization(poly, geopoint_Struct.Longitude, geopoint_Struct.Latitude, theLat, theLon) % 2.0 == 1.0;
		}
		return false;
	}

	public static bool PointInPolygonGeodesicRayCast(double theLat, double theLon, PooledList<Geopoint_Struct> poly)
	{
		if (poly.Count < 3)
		{
			return false;
		}
		Geopoint_Struct geopoint_Struct = smethod_1(theLon, theLat, 90.0);
		return GeoSegmentIntersect_Geodesic_ListIntersectCountOptimization(poly, geopoint_Struct.Longitude, geopoint_Struct.Latitude, theLat, theLon) % 2.0 == 1.0;
	}

	public static bool PointInPolygonGeodesicRayCast(double theLat, double theLon, List<Geopoint_Struct> poly)
	{
		if (poly.Count < 3)
		{
			return false;
		}
		Geopoint_Struct geopoint_Struct = smethod_1(theLon, theLat, 90.0);
		return GeoSegmentIntersect_Geodesic_ListIntersectCountOptimization(poly, geopoint_Struct.Longitude, geopoint_Struct.Latitude, theLat, theLon) % 2.0 == 1.0;
	}

	public static bool PointInPolygonGeodesicRayCast(double theLat, double theLon, GeoPoint[] poly)
	{
		if (poly.Length < 3)
		{
			return false;
		}
		Geopoint_Struct geopoint_Struct = smethod_1(theLon, theLat, 90.0);
		return GeoSegmentIntersect_Geodesic_ListIntersectCountOptimization(poly, geopoint_Struct.Longitude, geopoint_Struct.Latitude, theLat, theLon) % 2.0 == 1.0;
	}

	public static bool PointInPolygonGeodesicRayCast(double theLat, double theLon, List<GeoPoint> poly)
	{
		if (poly.Count < 3)
		{
			return false;
		}
		Geopoint_Struct geopoint_Struct = smethod_1(theLon, theLat, 90.0);
		return GeoSegmentIntersect_Geodesic_ListIntersectCountOptimization(poly, geopoint_Struct.Longitude, geopoint_Struct.Latitude, theLon, theLat) % 2.0 == 1.0;
	}

	public static bool PointInPolygonGeodesicRayCast(double theLat, double theLon, ReferencePoint[] poly)
	{
		if (poly.Length < 3)
		{
			return false;
		}
		Geopoint_Struct geopoint_Struct = smethod_1(theLon, theLat, 90.0);
		return GeoSegmentIntersect_Geodesic_ListIntersectCountOptimization(poly, geopoint_Struct.Longitude, geopoint_Struct.Latitude, theLon, theLat) % 2.0 == 1.0;
	}

	public static bool PointInPolygonGeodesicRayCast(double theLat, double theLon, List<ReferencePoint> poly)
	{
		if (poly.Count >= 3)
		{
			Geopoint_Struct geopoint_Struct = smethod_1(theLon, theLat, 90.0);
			return GeoSegmentIntersect_Geodesic_ListIntersectCountOptimization(poly, geopoint_Struct.Longitude, geopoint_Struct.Latitude, theLon, theLat) % 2.0 == 1.0;
		}
		return false;
	}

	public static bool PointOnArc(Geodesic_Vincenty.Point3D a, Geodesic_Vincenty.Point3D b, Geodesic_Vincenty.Point3D p)
	{
		double num = Geodesic_Vincenty.Point3D.Dot(a, b);
		double num2 = Geodesic_Vincenty.Point3D.Dot(a, p);
		double num3 = Geodesic_Vincenty.Point3D.Dot(p, b);
		if (num2 >= num)
		{
			return num3 >= num;
		}
		return false;
	}

	public static Geopoint_Struct? GeoSegmentIntersect_Geodesic(double a0Lon, double a0Lat, double a1Lon, double a1Lat, double b0Lon, double b0Lat, double b1Lon, double b1Lat)
	{
		a0Lon *= 0.0174532925199433;
		a0Lat *= 0.0174532925199433;
		a1Lon *= 0.0174532925199433;
		a1Lat *= 0.0174532925199433;
		b0Lon *= 0.0174532925199433;
		b0Lat *= 0.0174532925199433;
		b1Lon *= 0.0174532925199433;
		b1Lat *= 0.0174532925199433;
		Geodesic_Vincenty.Point3D a = new Geodesic_Vincenty.Point3D(Math.Cos(a0Lon) * Math.Cos(a0Lat), Math.Sin(a0Lon) * Math.Cos(a0Lat), Math.Sin(a0Lat));
		Geodesic_Vincenty.Point3D a2 = new Geodesic_Vincenty.Point3D(Math.Cos(a1Lon) * Math.Cos(a1Lat), Math.Sin(a1Lon) * Math.Cos(a1Lat), Math.Sin(a1Lat));
		Geodesic_Vincenty.Point3D b = new Geodesic_Vincenty.Point3D(Math.Cos(b0Lon) * Math.Cos(b0Lat), Math.Sin(b0Lon) * Math.Cos(b0Lat), Math.Sin(b0Lat));
		Geodesic_Vincenty.Point3D b2 = new Geodesic_Vincenty.Point3D(Math.Cos(b1Lon) * Math.Cos(b1Lat), Math.Sin(b1Lon) * Math.Cos(b1Lat), Math.Sin(b1Lat));
		Geodesic_Vincenty.Point3D? point3D = GeoSegmentIntersect_Geodesic(a, a2, b, b2);
		Geopoint_Struct? result;
		if (!point3D.HasValue)
		{
			result = null;
		}
		else
		{
			Geodesic_Vincenty.Point3D value = point3D.Value;
			result = new Geopoint_Struct(57.2957795130823 * Math.Atan2(value.Y, value.X), 57.2957795130823 * Math.Atan2(value.Z, Math.Sqrt(value.X * value.X + value.Y * value.Y)));
		}
		return result;
	}

	public static Geodesic_Vincenty.Point3D? GeoSegmentIntersect_Geodesic(Geodesic_Vincenty.Point3D a0, Geodesic_Vincenty.Point3D a1, Geodesic_Vincenty.Point3D b0, Geodesic_Vincenty.Point3D b1)
	{
		Geodesic_Vincenty.Point3D lHS = Geodesic_Vincenty.Point3D.Cross(a0, a1);
		Geodesic_Vincenty.Point3D rHS = Geodesic_Vincenty.Point3D.Cross(b0, b1);
		Geodesic_Vincenty.Point3D point3D = Geodesic_Vincenty.Point3D.Cross(lHS, rHS);
		Geodesic_Vincenty.Point3D point3D2 = point3D / point3D.Length();
		Geodesic_Vincenty.Point3D? result;
		if (PointOnArc(a0, a1, point3D2) && PointOnArc(b0, b1, point3D2))
		{
			result = point3D2;
		}
		else
		{
			Geodesic_Vincenty.Point3D point3D3 = point3D2 * -1.0;
			result = ((!PointOnArc(a0, a1, point3D3) || !PointOnArc(b0, b1, point3D3)) ? ((Geodesic_Vincenty.Point3D?)null) : new Geodesic_Vincenty.Point3D?(point3D3));
		}
		return result;
	}

	public static double GeoSegmentIntersect_Geodesic_ListIntersectCountOptimization(Geopoint_Struct[] poly, double b0Lon, double b0Lat, double b1Lon, double b1Lat)
	{
		int num = poly.Length;
		int num2 = 0;
		b0Lon *= 0.0174532925199433;
		b0Lat *= 0.0174532925199433;
		b1Lon *= 0.0174532925199433;
		b1Lat *= 0.0174532925199433;
		Geodesic_Vincenty.Point3D b = new Geodesic_Vincenty.Point3D(Math.Cos(b0Lon) * Math.Cos(b0Lat), Math.Sin(b0Lon) * Math.Cos(b0Lat), Math.Sin(b0Lat));
		Geodesic_Vincenty.Point3D b2 = new Geodesic_Vincenty.Point3D(Math.Cos(b1Lon) * Math.Cos(b1Lat), Math.Sin(b1Lon) * Math.Cos(b1Lat), Math.Sin(b1Lat));
		Geopoint_Struct geopoint_Struct = poly[num - 1];
		double num3 = geopoint_Struct.Longitude * 0.0174532925199433;
		double num4 = geopoint_Struct.Latitude * 0.0174532925199433;
		Geodesic_Vincenty.Point3D a = new Geodesic_Vincenty.Point3D(Math.Cos(num3) * Math.Cos(num4), Math.Sin(num3) * Math.Cos(num4), Math.Sin(num4));
		for (int i = 0; i < poly.Length; i = checked(i + 1))
		{
			Geopoint_Struct geopoint_Struct2 = poly[i];
			double num5 = geopoint_Struct2.Longitude * 0.0174532925199433;
			double num6 = geopoint_Struct2.Latitude * 0.0174532925199433;
			Geodesic_Vincenty.Point3D point3D = new Geodesic_Vincenty.Point3D(Math.Cos(num5) * Math.Cos(num6), Math.Sin(num5) * Math.Cos(num6), Math.Sin(num6));
			if (GeoSegmentIntersect_Geodesic(a, point3D, b, b2).HasValue)
			{
				num2++;
			}
			a = point3D;
		}
		return num2;
	}

	public static double GeoSegmentIntersect_Geodesic_ListIntersectCountOptimization(PooledList<Geopoint_Struct> poly, double b0Lon, double b0Lat, double b1Lon, double b1Lat)
	{
		int count = poly.Count;
		int num = 0;
		b0Lon *= 0.0174532925199433;
		b0Lat *= 0.0174532925199433;
		b1Lon *= 0.0174532925199433;
		b1Lat *= 0.0174532925199433;
		Geodesic_Vincenty.Point3D b = new Geodesic_Vincenty.Point3D(Math.Cos(b0Lon) * Math.Cos(b0Lat), Math.Sin(b0Lon) * Math.Cos(b0Lat), Math.Sin(b0Lat));
		Geodesic_Vincenty.Point3D b2 = new Geodesic_Vincenty.Point3D(Math.Cos(b1Lon) * Math.Cos(b1Lat), Math.Sin(b1Lon) * Math.Cos(b1Lat), Math.Sin(b1Lat));
		Geopoint_Struct geopoint_Struct = poly[count - 1];
		double num2 = geopoint_Struct.Longitude * 0.0174532925199433;
		double num3 = geopoint_Struct.Latitude * 0.0174532925199433;
		Geodesic_Vincenty.Point3D a = new Geodesic_Vincenty.Point3D(Math.Cos(num2) * Math.Cos(num3), Math.Sin(num2) * Math.Cos(num3), Math.Sin(num3));
		foreach (Geopoint_Struct item in poly)
		{
			double num4 = item.Longitude * 0.0174532925199433;
			double num5 = item.Latitude * 0.0174532925199433;
			Geodesic_Vincenty.Point3D point3D = new Geodesic_Vincenty.Point3D(Math.Cos(num4) * Math.Cos(num5), Math.Sin(num4) * Math.Cos(num5), Math.Sin(num5));
			if (GeoSegmentIntersect_Geodesic(a, point3D, b, b2).HasValue)
			{
				num++;
			}
			a = point3D;
		}
		return num;
	}

	public static double GeoSegmentIntersect_Geodesic_ListIntersectCountOptimization(List<Geopoint_Struct> poly, double b0Lon, double b0Lat, double b1Lon, double b1Lat)
	{
		int count = poly.Count;
		int num = 0;
		b0Lon *= 0.0174532925199433;
		b0Lat *= 0.0174532925199433;
		b1Lon *= 0.0174532925199433;
		b1Lat *= 0.0174532925199433;
		Geodesic_Vincenty.Point3D b = new Geodesic_Vincenty.Point3D(Math.Cos(b0Lon) * Math.Cos(b0Lat), Math.Sin(b0Lon) * Math.Cos(b0Lat), Math.Sin(b0Lat));
		Geodesic_Vincenty.Point3D b2 = new Geodesic_Vincenty.Point3D(Math.Cos(b1Lon) * Math.Cos(b1Lat), Math.Sin(b1Lon) * Math.Cos(b1Lat), Math.Sin(b1Lat));
		Geopoint_Struct geopoint_Struct = poly[count - 1];
		double num2 = geopoint_Struct.Longitude * 0.0174532925199433;
		double num3 = geopoint_Struct.Latitude * 0.0174532925199433;
		Geodesic_Vincenty.Point3D a = new Geodesic_Vincenty.Point3D(Math.Cos(num2) * Math.Cos(num3), Math.Sin(num2) * Math.Cos(num3), Math.Sin(num3));
		foreach (Geopoint_Struct item in poly)
		{
			double num4 = item.Longitude * 0.0174532925199433;
			double num5 = item.Latitude * 0.0174532925199433;
			Geodesic_Vincenty.Point3D point3D = new Geodesic_Vincenty.Point3D(Math.Cos(num4) * Math.Cos(num5), Math.Sin(num4) * Math.Cos(num5), Math.Sin(num5));
			if (GeoSegmentIntersect_Geodesic(a, point3D, b, b2).HasValue)
			{
				num++;
			}
			a = point3D;
		}
		return num;
	}

	public static double GeoSegmentIntersect_Geodesic_ListIntersectCountOptimization(GeoPoint[] poly, double b0Lon, double b0Lat, double b1Lon, double b1Lat)
	{
		int num = poly.Length;
		int num2 = 0;
		b0Lon *= 0.0174532925199433;
		b0Lat *= 0.0174532925199433;
		b1Lon *= 0.0174532925199433;
		b1Lat *= 0.0174532925199433;
		Geodesic_Vincenty.Point3D b = new Geodesic_Vincenty.Point3D(Math.Cos(b0Lon) * Math.Cos(b0Lat), Math.Sin(b0Lon) * Math.Cos(b0Lat), Math.Sin(b0Lat));
		Geodesic_Vincenty.Point3D b2 = new Geodesic_Vincenty.Point3D(Math.Cos(b1Lon) * Math.Cos(b1Lat), Math.Sin(b1Lon) * Math.Cos(b1Lat), Math.Sin(b1Lat));
		GeoPoint obj = poly[num - 1];
		double num3 = obj.double_0 * 0.0174532925199433;
		double num4 = obj.double_1 * 0.0174532925199433;
		Geodesic_Vincenty.Point3D a = new Geodesic_Vincenty.Point3D(Math.Cos(num3) * Math.Cos(num4), Math.Sin(num3) * Math.Cos(num4), Math.Sin(num4));
		foreach (GeoPoint obj2 in poly)
		{
			double num5 = obj2.double_0 * 0.0174532925199433;
			double num6 = obj2.double_1 * 0.0174532925199433;
			Geodesic_Vincenty.Point3D point3D = new Geodesic_Vincenty.Point3D(Math.Cos(num5) * Math.Cos(num6), Math.Sin(num5) * Math.Cos(num6), Math.Sin(num6));
			if (GeoSegmentIntersect_Geodesic(a, point3D, b, b2).HasValue)
			{
				num2++;
			}
			a = point3D;
		}
		return num2;
	}

	public static double GeoSegmentIntersect_Geodesic_ListIntersectCountOptimization(List<GeoPoint> poly, double b0Lon, double b0Lat, double b1Lon, double b1Lat)
	{
		int count = poly.Count;
		int num = 0;
		b0Lon *= 0.0174532925199433;
		b0Lat *= 0.0174532925199433;
		b1Lon *= 0.0174532925199433;
		b1Lat *= 0.0174532925199433;
		Geodesic_Vincenty.Point3D b = new Geodesic_Vincenty.Point3D(Math.Cos(b0Lon) * Math.Cos(b0Lat), Math.Sin(b0Lon) * Math.Cos(b0Lat), Math.Sin(b0Lat));
		Geodesic_Vincenty.Point3D b2 = new Geodesic_Vincenty.Point3D(Math.Cos(b1Lon) * Math.Cos(b1Lat), Math.Sin(b1Lon) * Math.Cos(b1Lat), Math.Sin(b1Lat));
		GeoPoint geoPoint = poly[count - 1];
		double num2 = geoPoint.double_0 * 0.0174532925199433;
		double num3 = geoPoint.double_1 * 0.0174532925199433;
		Geodesic_Vincenty.Point3D a = new Geodesic_Vincenty.Point3D(Math.Cos(num2) * Math.Cos(num3), Math.Sin(num2) * Math.Cos(num3), Math.Sin(num3));
		foreach (GeoPoint item in poly)
		{
			double num4 = item.double_0 * 0.0174532925199433;
			double num5 = item.double_1 * 0.0174532925199433;
			Geodesic_Vincenty.Point3D point3D = new Geodesic_Vincenty.Point3D(Math.Cos(num4) * Math.Cos(num5), Math.Sin(num4) * Math.Cos(num5), Math.Sin(num5));
			if (GeoSegmentIntersect_Geodesic(a, point3D, b, b2).HasValue)
			{
				num++;
			}
			a = point3D;
		}
		return num;
	}

	public static double GeoSegmentIntersect_Geodesic_ListIntersectCountOptimization(ReferencePoint[] poly, double b0Lon, double b0Lat, double b1Lon, double b1Lat)
	{
		int num = poly.Length;
		int num2 = 0;
		b0Lon *= 0.0174532925199433;
		b0Lat *= 0.0174532925199433;
		b1Lon *= 0.0174532925199433;
		b1Lat *= 0.0174532925199433;
		Geodesic_Vincenty.Point3D b = new Geodesic_Vincenty.Point3D(Math.Cos(b0Lon) * Math.Cos(b0Lat), Math.Sin(b0Lon) * Math.Cos(b0Lat), Math.Sin(b0Lat));
		Geodesic_Vincenty.Point3D b2 = new Geodesic_Vincenty.Point3D(Math.Cos(b1Lon) * Math.Cos(b1Lat), Math.Sin(b1Lon) * Math.Cos(b1Lat), Math.Sin(b1Lat));
		ReferencePoint obj = poly[num - 1];
		double num3 = obj.double_0 * 0.0174532925199433;
		double num4 = obj.double_1 * 0.0174532925199433;
		Geodesic_Vincenty.Point3D a = new Geodesic_Vincenty.Point3D(Math.Cos(num3) * Math.Cos(num4), Math.Sin(num3) * Math.Cos(num4), Math.Sin(num4));
		foreach (ReferencePoint obj2 in poly)
		{
			double num5 = obj2.double_0 * 0.0174532925199433;
			double num6 = obj2.double_1 * 0.0174532925199433;
			Geodesic_Vincenty.Point3D point3D = new Geodesic_Vincenty.Point3D(Math.Cos(num5) * Math.Cos(num6), Math.Sin(num5) * Math.Cos(num6), Math.Sin(num6));
			if (GeoSegmentIntersect_Geodesic(a, point3D, b, b2).HasValue)
			{
				num2++;
			}
			a = point3D;
		}
		return num2;
	}

	public static double GeoSegmentIntersect_Geodesic_ListIntersectCountOptimization(List<ReferencePoint> poly, double b0Lon, double b0Lat, double b1Lon, double b1Lat)
	{
		int count = poly.Count;
		int num = 0;
		b0Lon *= 0.0174532925199433;
		b0Lat *= 0.0174532925199433;
		b1Lon *= 0.0174532925199433;
		b1Lat *= 0.0174532925199433;
		Geodesic_Vincenty.Point3D b = new Geodesic_Vincenty.Point3D(Math.Cos(b0Lon) * Math.Cos(b0Lat), Math.Sin(b0Lon) * Math.Cos(b0Lat), Math.Sin(b0Lat));
		Geodesic_Vincenty.Point3D b2 = new Geodesic_Vincenty.Point3D(Math.Cos(b1Lon) * Math.Cos(b1Lat), Math.Sin(b1Lon) * Math.Cos(b1Lat), Math.Sin(b1Lat));
		ReferencePoint referencePoint = poly[count - 1];
		double num2 = referencePoint.double_0 * 0.0174532925199433;
		double num3 = referencePoint.double_1 * 0.0174532925199433;
		Geodesic_Vincenty.Point3D a = new Geodesic_Vincenty.Point3D(Math.Cos(num2) * Math.Cos(num3), Math.Sin(num2) * Math.Cos(num3), Math.Sin(num3));
		foreach (ReferencePoint item in poly)
		{
			double num4 = item.double_0 * 0.0174532925199433;
			double num5 = item.double_1 * 0.0174532925199433;
			Geodesic_Vincenty.Point3D point3D = new Geodesic_Vincenty.Point3D(Math.Cos(num4) * Math.Cos(num5), Math.Sin(num4) * Math.Cos(num5), Math.Sin(num5));
			if (GeoSegmentIntersect_Geodesic(a, point3D, b, b2).HasValue)
			{
				num++;
			}
			a = point3D;
		}
		return num;
	}

	public static Geopoint_Struct? AntimeridianOrMeridianIntersection(double Lon1, double Lat1, double Lon2, double Lat2)
	{
		return GeoSegmentIntersect_Geodesic(Lon1, Lat1, Lon2, Lat2, 180.0, -89.999, 180.0, 89.999);
	}

	public static List<Geopoint_Struct[]> SplitPolygonIntoSubAreas<T>(IEnumerable<T> theArea) where T : IGeopoint
	{
		List<Geopoint_Struct[]> result = default(List<Geopoint_Struct[]>);
		try
		{
			if (theArea == null)
			{
				result = null;
				return result;
			}
			int num = theArea.Count();
			if (num < 3)
			{
				result = null;
				return result;
			}
			List<InProgressSubArea> list = new List<InProgressSubArea>();
			List<InProgressSubArea> list2 = new List<InProgressSubArea>();
			InProgressSubArea inProgressSubArea = new InProgressSubArea();
			Geopoint_Struct? geopoint_Struct = null;
			double ptALon = theArea.ElementAtOrDefault(num - 1).Longitude;
			int num2 = num - 1;
			int num3 = default(int);
			for (int i = 0; i <= num2; i++)
			{
				double longitude = theArea.ElementAtOrDefault(i).Longitude;
				if (!SegmentCrossesAntimeridianOrMeridian(ptALon, longitude))
				{
					ptALon = longitude;
					continue;
				}
				num3 = i;
				break;
			}
			int num4 = num - 1;
			int num5 = num3;
			int num6 = num3 - 1;
			if (num6 < 0)
			{
				num6 = num4;
			}
			T val = theArea.ElementAtOrDefault(num6);
			ptALon = Math2.NormalizeLongitudePreserveNegative180(val.Longitude);
			double ptALat = Math2.NormalizeLatitude(val.Latitude);
			bool flag = ptALon < 0.0;
			int num7 = num4;
			Geopoint_Struct intersect = default(Geopoint_Struct);
			bool segmentCrossesAntimeridian = default(bool);
			bool segmentCrossesMeridian = default(bool);
			bool clockwise = default(bool);
			for (int j = 0; j <= num7; j++)
			{
				int num8 = (num5 + j) % (num4 + 1);
				T val2 = theArea.ElementAtOrDefault(num8);
				double longitude = Math2.NormalizeLongitudePreserveNegative180(val2.Longitude);
				double num9 = Math2.NormalizeLatitude(val2.Latitude);
				SegmentCrossesAntimeridianOrMeridian_WithIntersection(ptALon, ptALat, longitude, num9, ref intersect, ref segmentCrossesAntimeridian, ref segmentCrossesMeridian, ref clockwise);
				if (num8 == num5)
				{
					if (!segmentCrossesAntimeridian && !segmentCrossesMeridian)
					{
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
					}
					else
					{
						inProgressSubArea.openArea(intersect, new Geopoint_Struct(val2.Longitude, val2.Latitude));
						geopoint_Struct = intersect;
					}
				}
				else
				{
					if (!segmentCrossesAntimeridian && !segmentCrossesMeridian)
					{
						inProgressSubArea.continueArea(new Geopoint_Struct(longitude, num9));
					}
					else
					{
						inProgressSubArea.closeArea(intersect);
						if (flag)
						{
							list.Add(inProgressSubArea);
						}
						else
						{
							list2.Add(inProgressSubArea);
						}
						inProgressSubArea = new InProgressSubArea(intersect, new Geopoint_Struct(val2.Longitude, val2.Latitude));
						flag = !flag;
					}
					if (num8 == num6)
					{
						inProgressSubArea.closeArea(geopoint_Struct.Value);
						if (flag)
						{
							list.Add(inProgressSubArea);
						}
						else
						{
							list2.Add(inProgressSubArea);
						}
						break;
					}
				}
				val = val2;
				ptALon = longitude;
				ptALat = num9;
			}
			List<Geopoint_Struct[]> list3 = new List<Geopoint_Struct[]>();
			if (list.Count == 1 && list2.Count == 1)
			{
				list3.Add(list.First().points.ToArray());
				list3.Add(list2.First().points.ToArray());
				result = list3;
				return result;
			}
			foreach (InProgressSubArea item in list)
			{
				item.calculateAbstractLat();
			}
			foreach (InProgressSubArea item2 in list2)
			{
				item2.calculateAbstractLat();
			}
			list = list.OrderBy([SpecialName] (InProgressSubArea ss) => ss.startAbstractLat).ToList();
			list2 = list2.OrderBy([SpecialName] (InProgressSubArea ss) => ss.startAbstractLat).ToList();
			int num10 = 0;
			do
			{
				List<InProgressSubArea> list4 = ((num10 == 0) ? list2 : list);
				num4 = list4.Count - 1;
				bool flag2 = true;
				List<InProgressSubArea> list5 = new List<InProgressSubArea>();
				int num11 = num4;
				for (int num12 = 0; num12 <= num11; num12++)
				{
					InProgressSubArea inProgressSubArea2 = list4[num12];
					if (flag2)
					{
						if (num12 < num4 && inProgressSubArea2.endAbstractLat < list4[num12 + 1].startAbstractLat)
						{
							list3.Add(inProgressSubArea2.points.ToArray());
							continue;
						}
						list5.Add(inProgressSubArea2);
						flag2 = !flag2;
						continue;
					}
					if (num12 >= num4 || !(inProgressSubArea2.endAbstractLat < list4[num12 + 1].startAbstractLat))
					{
						flag2 = !flag2;
					}
					bool flag3 = false;
					for (int num13 = list5.Count - 1; num13 >= 0; num13 += -1)
					{
						if (list5[num13].AddSubAreaIfContained(inProgressSubArea2))
						{
							flag3 = true;
							break;
						}
					}
					if (!flag3)
					{
						list5.Add(inProgressSubArea2);
					}
				}
				foreach (InProgressSubArea item3 in list5)
				{
					item3.mergeWithSubAreas();
					list3.Add(item3.points.ToArray());
				}
				num10++;
			}
			while (num10 <= 1);
			result = list3;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 22462256", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	static GeoPoint()
	{
		Class72.smethod_20();
	}
}
