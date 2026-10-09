using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using Collections.Pooled;
using DarkUI.Collections;
using DotSpatial.Topology;
using DotSpatial.Topology.Operation.Distance;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class Zone : ScenarioObject
{
	public enum ZoneType
	{
		Zone,
		NoNavZone,
		ExclusionZone,
		CustomEnvironmentZone
	}

	public string Description;

	internal int _Layer;

	public SideEnablers Enablers;

	public bool IsLocked;

	public float? AltitudeEnvelopeMin;

	public float? AltitudeEnvelopeMax;

	private LockObject lockObject_0;

	[AccessedThroughProperty("_Area")]
	[CompilerGenerated]
	private ObservableList<ReferencePoint> observableList_0;

	internal ReferencePoint[] Area_AsArray;

	public List<ReferencePoint> Area_RefPoints_020deg_ChangeCheck;

	public List<ReferencePoint> Area_RefPoints_015deg_ChangeCheck;

	public List<Geopoint_Struct> Area_GeoPoints_020deg_Buffered;

	public List<Geopoint_Struct> Area_GeoPoints_015deg_Buffered;

	public Color AreaColor;

	[CompilerGenerated]
	[AccessedThroughProperty("AffectedUnitTypes")]
	private ObservableList<GlobalVariables.ActiveUnitType> observableList_1;

	public bool _IsActive;

	private bool? nullable_0;

	private bool? nullable_1;

	private bool? nullable_2;

	private bool? nullable_3;

	private bool? nullable_4;

	private bool? nullable_5;

	private bool? nullable_6;

	public virtual ZoneType Type => ZoneType.Zone;

	public int Layer
	{
		get
		{
			return _Layer;
		}
		set
		{
			if (value != _Layer)
			{
				_Layer = Math.Max(value, 0);
				ReorderAccordingTolayer(side, Type);
			}
		}
	}

	public virtual ObservableList<GlobalVariables.ActiveUnitType> AffectedUnitTypes
	{
		[CompilerGenerated]
		get
		{
			return observableList_1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler<ObservableListModified<GlobalVariables.ActiveUnitType>> value2 = method_1;
			EventHandler<ObservableListModified<GlobalVariables.ActiveUnitType>> value3 = method_2;
			ObservableList<GlobalVariables.ActiveUnitType> observableList = observableList_1;
			if (observableList != null)
			{
				observableList.ItemsAdded -= value2;
				observableList.ItemsRemoved -= value3;
			}
			observableList_1 = value;
			observableList = observableList_1;
			if (observableList != null)
			{
				observableList.ItemsAdded += value2;
				observableList.ItemsRemoved += value3;
			}
		}
	}

	public bool IsActive
	{
		get
		{
			return _IsActive;
		}
		set
		{
			_IsActive = value;
		}
	}

	public ObservableList<ReferencePoint> Area
	{
		get
		{
			return vmethod_0();
		}
		set
		{
			vmethod_1(value);
			Area_AsArray = vmethod_0().ToArray();
		}
	}

	public bool AffectsThisUnit
	{
		get
		{
			bool result;
			if (theAU == null)
			{
				result = false;
			}
			else if (IsActive)
			{
				try
				{
					if (theAU.IsGroup)
					{
						result = !Information.IsNothing((object)((Group)theAU).GroupLead) && this.get_AffectsThisUnit(((Group)theAU).GroupLead);
					}
					else
					{
						bool? flag;
						switch (theAU.UnitType)
						{
						case GlobalVariables.ActiveUnitType.Aircraft:
							if (!nullable_0.HasValue)
							{
								method_0();
							}
							flag = nullable_0;
							break;
						case GlobalVariables.ActiveUnitType.Ship:
							if (!nullable_1.HasValue)
							{
								method_0();
							}
							flag = nullable_1;
							break;
						case GlobalVariables.ActiveUnitType.Submarine:
							if (!nullable_2.HasValue)
							{
								method_0();
							}
							flag = nullable_2;
							break;
						case GlobalVariables.ActiveUnitType.Facility:
							if (!nullable_3.HasValue)
							{
								method_0();
							}
							flag = nullable_3;
							break;
						case GlobalVariables.ActiveUnitType.Weapon:
						{
							int num;
							if (((Weapon)theAU).Type != Weapon._WeaponType.Decoy_Vehicle)
							{
								if (((Weapon)theAU).Type != Weapon._WeaponType.UAV_Expendable)
								{
									if (!nullable_5.HasValue)
									{
										method_0();
									}
									flag = nullable_5;
									break;
								}
								num = 1;
							}
							else
							{
								num = 1;
							}
							result = (byte)num != 0;
							goto end_IL_0016;
						}
						case GlobalVariables.ActiveUnitType.Satellite:
							if (!nullable_6.HasValue)
							{
								method_0();
							}
							flag = nullable_6;
							break;
						case GlobalVariables.ActiveUnitType.Vehicle:
							if (!nullable_4.HasValue)
							{
								method_0();
							}
							flag = nullable_4;
							break;
						default:
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							throw new NotImplementedException();
						case GlobalVariables.ActiveUnitType.AggregateGroundUnit:
							if (!nullable_4.HasValue)
							{
								method_0();
							}
							flag = nullable_4;
							break;
						}
						result = flag.Value;
					}
					end_IL_0016:;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 100995", "");
					GameGeneral.WriteExceptionsToLog(ex2);
					int num2;
					if (!Debugger.IsAttached)
					{
						num2 = 0;
					}
					else
					{
						Debugger.Break();
						num2 = 0;
					}
					result = (byte)num2 != 0;
					ProjectData.ClearProjectError();
				}
			}
			else
			{
				result = false;
			}
			return result;
		}
	}

	public bool IsPlayerEditable(Side _Side)
	{
		bool result;
		try
		{
			Scenario parentScen = _Side.ParentScen;
			if (parentScen == null || !parentScen.GameContext.IsScenEditGameMode)
			{
				foreach (ReferencePoint item in Area)
				{
					if (_Side.RefPoints.Contains(item))
					{
						continue;
					}
					result = false;
					goto end_IL_0001;
				}
				goto IL_00ab;
			}
			result = true;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 13413415553221", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num;
			if (!Debugger.IsAttached)
			{
				num = 1;
			}
			else
			{
				Debugger.Break();
				num = 1;
			}
			result = (byte)num != 0;
			ProjectData.ClearProjectError();
		}
		goto IL_00ad;
		IL_00ab:
		result = true;
		goto IL_00ad;
		IL_00ad:
		return result;
	}

	public void ReorderAccordingTolayer(Side side, ZoneType Type)
	{
		lock (lockObject_0)
		{
			switch (Type)
			{
			case ZoneType.Zone:
				side.StandardZones = side.StandardZones.OrderBy([SpecialName] (Zone x) => x.get_Layer(side)).ToList();
				break;
			default:
				throw new NotImplementedException();
			case ZoneType.CustomEnvironmentZone:
				side.CustomEnvironmentZones = side.CustomEnvironmentZones.OrderBy([SpecialName] (CustomEnvironmentZone x) => ((Zone)x).get_Layer(side)).ToArray();
				break;
			}
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private virtual ObservableList<ReferencePoint> vmethod_0()
	{
		return observableList_0;
	}

	[SpecialName]
	[CompilerGenerated]
	private virtual void vmethod_1(ObservableList<ReferencePoint> WithEventsValue)
	{
		EventHandler<ObservableListModified<ReferencePoint>> value = method_3;
		EventHandler<object> value2 = method_4;
		EventHandler<ObservableListModified<ReferencePoint>> value3 = method_5;
		ObservableList<ReferencePoint> observableList = observableList_0;
		if (observableList != null)
		{
			observableList.ItemsAdded -= value;
			observableList.ItemsCleared -= value2;
			observableList.ItemsRemoved -= value3;
		}
		observableList_0 = WithEventsValue;
		observableList = observableList_0;
		if (observableList != null)
		{
			observableList.ItemsAdded += value;
			observableList.ItemsCleared += value2;
			observableList.ItemsRemoved += value3;
		}
	}

	public static Zone Create(ZoneType type, Side side, List<ReferencePoint> area, string Name = "", Color Color = default(Color))
	{
		Zone zone = default(Zone);
		return type switch
		{
			ZoneType.Zone => Create(side, area, Name, Color), 
			ZoneType.NoNavZone => NoNavZone.Create(side, area, Name, Color), 
			ZoneType.ExclusionZone => ExclusionZone.Create(side, area, Name, Color), 
			_ => zone, 
		};
	}

	public static Zone Create(Side side, List<ReferencePoint> area, string Name = "", Color Color = default(Color))
	{
		Zone zone = new Zone();
		if (!string.IsNullOrEmpty(Name))
		{
			zone.Description = Name;
		}
		if (Information.IsNothing((object)Color))
		{
			zone.AreaColor = Color.FromArgb(60, 100, 100, 100);
		}
		else
		{
			zone.AreaColor = Color;
		}
		zone.Area = new ObservableList<ReferencePoint>(area);
		side.StandardZones.Add(zone);
		return zone;
	}

	public static Zone Create(Side side, List<string> area, string Name = "", Color Color = default(Color))
	{
		ObservableList<ReferencePoint> observableList = ReferencePoint.FetchReferencePointsFromID(side, area);
		if (observableList.Count > 0)
		{
			return Create(side, observableList, Name, Color);
		}
		return null;
	}

	public void Copy(Geopoint_Struct Position, Side side)
	{
		Geopoint_Struct offset = Geopoint_Struct.ComputeOffset(Misc.Center(Area), Position);
		List<ReferencePoint> list = new List<ReferencePoint>();
		foreach (ReferencePoint item in Area)
		{
			ReferencePoint theOriginalRefPoint = item;
			ReferencePoint referencePoint = ReferencePoint.CopyRefPoint(ref theOriginalRefPoint, side);
			double Lati = referencePoint.Latitude;
			ReferencePoint referencePoint2;
			double Longi = (referencePoint2 = referencePoint).Longitude;
			ReferencePoint referencePoint3;
			float Alti = (referencePoint3 = referencePoint).Altitude;
			Geopoint_Struct.AddOffset(ref Lati, ref Longi, ref Alti, offset);
			referencePoint3.Altitude = Alti;
			referencePoint2.Longitude = Longi;
			referencePoint.Latitude = Lati;
			list.Add(referencePoint);
		}
		Create(side, list, Description, AreaColor);
	}

	public void Remove(Side side)
	{
		switch (Type)
		{
		case ZoneType.Zone:
			if (side.StandardZones.Contains(this))
			{
				side.StandardZones.Remove(this);
			}
			break;
		case ZoneType.NoNavZone:
		{
			NoNavZone item = (NoNavZone)this;
			if (side.NoNavZones.Contains(item))
			{
				side.NoNavZones.Remove(item);
			}
			break;
		}
		case ZoneType.ExclusionZone:
		{
			ExclusionZone item2 = (ExclusionZone)this;
			if (side.ExclusionZones.Contains(item2))
			{
				side.ExclusionZones.Remove(item2);
			}
			break;
		}
		case ZoneType.CustomEnvironmentZone:
		{
			CustomEnvironmentZone value = (CustomEnvironmentZone)this;
			if (side.ParentScen.GetNatureSide().CustomEnvironmentZones.Contains(value))
			{
				ArrayExtensions.Remove(ref side.ParentScen.GetNatureSide().CustomEnvironmentZones, value);
			}
			break;
		}
		}
	}

	public Zone(string theDescription, List<ReferencePoint> theArea)
	{
		lockObject_0 = new LockObject();
		vmethod_1(new ObservableList<ReferencePoint>());
		Area_RefPoints_020deg_ChangeCheck = new List<ReferencePoint>();
		Area_RefPoints_015deg_ChangeCheck = new List<ReferencePoint>();
		Area_GeoPoints_020deg_Buffered = new List<Geopoint_Struct>();
		Area_GeoPoints_015deg_Buffered = new List<Geopoint_Struct>();
		AffectedUnitTypes = new ObservableList<GlobalVariables.ActiveUnitType>();
		_IsActive = true;
		Description = theDescription;
		Area = new ObservableList<ReferencePoint>(theArea);
		Enablers.GNSS_GPS = true;
		Enablers.GNSS_GLONASS = true;
		Enablers.GNSS_BeiDou = true;
		Enablers.GNSS_NavIC = true;
	}

	public Zone()
	{
		lockObject_0 = new LockObject();
		vmethod_1(new ObservableList<ReferencePoint>());
		Area_RefPoints_020deg_ChangeCheck = new List<ReferencePoint>();
		Area_RefPoints_015deg_ChangeCheck = new List<ReferencePoint>();
		Area_GeoPoints_020deg_Buffered = new List<Geopoint_Struct>();
		Area_GeoPoints_015deg_Buffered = new List<Geopoint_Struct>();
		AffectedUnitTypes = new ObservableList<GlobalVariables.ActiveUnitType>();
		_IsActive = true;
		Enablers.GNSS_GPS = true;
		Enablers.GNSS_GLONASS = true;
		Enablers.GNSS_BeiDou = true;
		Enablers.GNSS_NavIC = true;
	}

	internal bool IsInArea(double theLat, double theLong)
	{
		return GeoPoint.IsInsideThisArea(theLat, theLong, Area_AsArray);
	}

	internal bool IsInArea(ActiveUnit TheUnit)
	{
		return ((Module_Unit.Unit)TheUnit).get_IsInsideThisArea((GeoPoint[])Area_AsArray, TheUnit.ParentScen, UseCache: false);
	}

	public static bool IsInArea(List<Geopoint_Struct> AreaA, List<Geopoint_Struct> AreaB)
	{
		foreach (Geopoint_Struct item in AreaA)
		{
			if (!GeoPoint.IsInsideThisArea(item.Latitude, item.Longitude, AreaB))
			{
				return false;
			}
		}
		return true;
	}

	public static void TransformTo(Zone SourceZone, Side TargetSide, Scenario Scen)
	{
		Scen.CreateNatureSideIfNeeded();
		if (SourceZone != null)
		{
			ArrayExtensions.Add(ref Scen.GetNatureSide().CustomEnvironmentZones, new CustomEnvironmentZone(SourceZone.Description, SourceZone.Area, Scen, TargetSide, Scen.GlobalWeather));
			TargetSide.StandardZones.Remove(SourceZone);
		}
	}

	public static void TransformTo(ExclusionZone SourceZone, Side TargetSide, Scenario Scen)
	{
		if (SourceZone != null)
		{
			TargetSide.StandardZones.Add(new Zone(SourceZone.Description, SourceZone.Area));
			TargetSide.ExclusionZones.Remove(SourceZone);
		}
	}

	public static void TransformTo(NoNavZone SourceZone, Side TargetSide, Scenario Scen)
	{
		if (SourceZone != null)
		{
			TargetSide.StandardZones.Add(new Zone(SourceZone.Description, SourceZone.Area));
			TargetSide.NoNavZones.Remove(SourceZone);
		}
	}

	public static void TransformTo(CustomEnvironmentZone SourceZone, Side TargetSide, Scenario Scen)
	{
		Scen.CreateNatureSideIfNeeded();
		if (SourceZone != null)
		{
			ArrayExtensions.Add(ref Scen.GetNatureSide().CustomEnvironmentZones, new CustomEnvironmentZone(SourceZone.Description, SourceZone.Area, Scen, TargetSide, Scen.GlobalWeather));
			ArrayExtensions.Remove(ref TargetSide.CustomEnvironmentZones, SourceZone);
		}
	}

	public bool isEqual(List<ReferencePoint> ReferencePoints)
	{
		if (ReferencePoints != null)
		{
			if (ReferencePoints.Count != Area.Count)
			{
				return false;
			}
			foreach (ReferencePoint ReferencePoint in ReferencePoints)
			{
				if (!Area.Contains(ReferencePoint))
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	internal List<ReferencePoint> Interpolate(Scenario ParentScen, Side Side, int IntermediatePoints = 1)
	{
		if (Area.Count < 2)
		{
			return null;
		}
		if (IntermediatePoints < 1)
		{
			return null;
		}
		Dictionary<int, List<ReferencePoint>> dictionary = new Dictionary<int, List<ReferencePoint>>();
		int num = Area.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			ReferencePoint referencePoint = Area.ElementAt(i);
			ReferencePoint referencePoint2 = ((i != Area.Count - 1) ? Area.ElementAt(i + 1) : Area.ElementAt(0));
			float bearing = Math2.CalcAzimuth(referencePoint.Latitude, referencePoint.Longitude, referencePoint2.Latitude, referencePoint2.Longitude);
			double num2 = Math2.CalcDist(referencePoint.Latitude, referencePoint.Longitude, referencePoint2.Latitude, referencePoint2.Longitude) / (float)(IntermediatePoints + 1);
			dictionary.Add(i, new List<ReferencePoint>());
			int num3 = IntermediatePoints - 1;
			for (int j = 0; j <= num3; j++)
			{
				ReferencePoint referencePoint3 = ReferencePoint.CreateNew(ParentScen, "", referencePoint.Longitude, referencePoint.Latitude, Side, null, Color.White);
				double longitude = referencePoint.Longitude;
				double latitude = referencePoint.Latitude;
				ReferencePoint referencePoint4;
				double out_lon = (referencePoint4 = referencePoint3).Longitude;
				ReferencePoint referencePoint5;
				double out_lat = (referencePoint5 = referencePoint3).Latitude;
				Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref out_lon, ref out_lat, num2 * (double)(j + 1), bearing);
				referencePoint5.Latitude = out_lat;
				referencePoint4.Longitude = out_lon;
				dictionary[i].Add(referencePoint3);
			}
		}
		List<ReferencePoint> list = new List<ReferencePoint>();
		int num4 = Area.Count - 1;
		for (int k = 0; k <= num4; k++)
		{
			list.Add(Area[k]);
			if (!dictionary.ContainsKey(k))
			{
				continue;
			}
			foreach (ReferencePoint item in dictionary[k])
			{
				list.Add(item);
			}
		}
		Area = new ObservableList<ReferencePoint>(list);
		return list;
	}

	public static bool ValidateArea(ref List<GeoPoint> theArea)
	{
		bool result;
		if (theArea == null)
		{
			result = false;
		}
		else
		{
			try
			{
				if (theArea.Count < 3)
				{
					result = false;
				}
				else if (theArea.Count == 3)
				{
					result = true;
				}
				else
				{
					int count = theArea.Count;
					Coordinate[] array = new Coordinate[count + 1];
					int num = count - 1;
					for (int i = 0; i <= num; i++)
					{
						MercatorProjection.MercatorPixel mercatorPixel = new MercatorProjection.MercatorPixel(theArea[i].Longitude, theArea[i].Latitude);
						array[i] = new Coordinate(mercatorPixel.x, mercatorPixel.y);
					}
					array[count] = array[0];
					result = new Polygon(new LinearRing(array)).IsValid;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				int num2;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
					num2 = 0;
				}
				else
				{
					num2 = 0;
				}
				result = (byte)num2 != 0;
				ProjectData.ClearProjectError();
			}
		}
		return result;
	}

	public static bool ValidateArea(ref PooledList<Geopoint_Struct> theArea)
	{
		if (theArea.Count < 3)
		{
			return false;
		}
		if (theArea.Count == 3)
		{
			return true;
		}
		int count = theArea.Count;
		Coordinate[] array = new Coordinate[count + 1];
		int num = count - 1;
		for (int i = 0; i <= num; i++)
		{
			MercatorProjection.MercatorPixel mercatorPixel = new MercatorProjection.MercatorPixel(theArea[i].Longitude, theArea[i].Latitude);
			array[i] = new Coordinate(mercatorPixel.x, mercatorPixel.y);
		}
		array[count] = array[0];
		return new Polygon(new LinearRing(array)).IsValid;
	}

	public static bool ValidateArea(ref List<Geopoint_Struct> theArea)
	{
		if (theArea.Count < 3)
		{
			return false;
		}
		if (theArea.Count == 3)
		{
			return true;
		}
		int count = theArea.Count;
		Coordinate[] array = new Coordinate[count + 1];
		int num = count - 1;
		for (int i = 0; i <= num; i++)
		{
			MercatorProjection.MercatorPixel mercatorPixel = new MercatorProjection.MercatorPixel(theArea[i].Longitude, theArea[i].Latitude);
			array[i] = new Coordinate(mercatorPixel.x, mercatorPixel.y);
		}
		array[count] = array[0];
		return new Polygon(new LinearRing(array)).IsValid;
	}

	public static bool ValidateArea(List<ReferencePoint> theArea)
	{
		List<Geopoint_Struct> theArea2 = new List<Geopoint_Struct>();
		foreach (ReferencePoint item in theArea)
		{
			theArea2.Add(new Geopoint_Struct(item.Longitude, item.Latitude));
		}
		return ValidateArea(ref theArea2);
	}

	public static double ComputeArea(List<GeoPoint> Path, bool PerformPathValidation = true, float SphereRadius = 6371f)
	{
		if (PerformPathValidation && !ValidateArea(ref Path))
		{
			return 0.0;
		}
		int count = Path.Count;
		if (count < 3)
		{
			return 0.0;
		}
		double num = 0.0;
		GeoPoint geoPoint = Path[count - 1];
		double tan = Math.Tan(Math.PI / 2.0 - geoPoint.Latitude / 180.0 * Math.PI / 2.0);
		double lng = geoPoint.Longitude / 180.0 * Math.PI;
		foreach (GeoPoint item in Path)
		{
			double num2 = Math.Tan(Math.PI / 2.0 - item.Latitude / 180.0 * Math.PI / 2.0);
			double num3 = item.Longitude / 180.0 * Math.PI;
			num += PolarTriangleArea(num2, num3, tan, lng);
			tan = num2;
			lng = num3;
		}
		return num * (double)(SphereRadius * SphereRadius);
	}

	public static double ComputeArea(PooledList<Geopoint_Struct> Path, bool PerformPathValidation = true, float SphereRadius = 6371f)
	{
		if (PerformPathValidation && !ValidateArea(ref Path))
		{
			return 0.0;
		}
		int count = Path.Count;
		if (count < 3)
		{
			return 0.0;
		}
		double num = 0.0;
		Geopoint_Struct geopoint_Struct = Path[count - 1];
		double tan = Math.Tan(Math.PI / 2.0 - geopoint_Struct.Latitude / 180.0 * Math.PI / 2.0);
		double lng = geopoint_Struct.Longitude / 180.0 * Math.PI;
		foreach (Geopoint_Struct item in Path)
		{
			double num2 = Math.Tan(Math.PI / 2.0 - item.Latitude / 180.0 * Math.PI / 2.0);
			double num3 = item.Longitude / 180.0 * Math.PI;
			num += PolarTriangleArea(num2, num3, tan, lng);
			tan = num2;
			lng = num3;
		}
		return num * (double)(SphereRadius * SphereRadius);
	}

	public static double ComputeArea(List<Geopoint_Struct> Path, bool PerformPathValidation = true, float SphereRadius = 6371f)
	{
		if (PerformPathValidation && !ValidateArea(ref Path))
		{
			return 0.0;
		}
		int count = Path.Count;
		if (count < 3)
		{
			return 0.0;
		}
		double num = 0.0;
		Geopoint_Struct geopoint_Struct = Path[count - 1];
		double tan = Math.Tan(Math.PI / 2.0 - geopoint_Struct.Latitude / 180.0 * Math.PI / 2.0);
		double lng = geopoint_Struct.Longitude / 180.0 * Math.PI;
		foreach (Geopoint_Struct item in Path)
		{
			double num2 = Math.Tan(Math.PI / 2.0 - item.Latitude / 180.0 * Math.PI / 2.0);
			double num3 = item.Longitude / 180.0 * Math.PI;
			num += PolarTriangleArea(num2, num3, tan, lng);
			tan = num2;
			lng = num3;
		}
		return num * (double)(SphereRadius * SphereRadius);
	}

	public static double PolarTriangleArea(double tan1, double lng1, double tan2, double lng2)
	{
		double num = lng1 - lng2;
		double num2 = tan1 * tan2;
		return 2.0 * Math.Atan2(num2 * Math.Sin(num), 1.0 + num2 * Math.Cos(num));
	}

	public void CalculateAreaWithThresholdAdded(float ProximityThreshold_Deg, ref List<Geopoint_Struct> BufferedArea_GeoPoints, ref List<ReferencePoint> ChangeCheck_RefPoints, bool SplitLongSegments = true)
	{
		try
		{
			int count = Area.Count;
			bool flag = count >= 3;
			bool flag2 = count == 2;
			bool flag3 = !flag && !flag2;
			if (count == 0)
			{
				return;
			}
			ChangeCheck_RefPoints.Clear();
			BufferedArea_GeoPoints.Clear();
			int num = count - 1;
			for (int i = 0; i <= num; i++)
			{
				List<ReferencePoint> obj = ChangeCheck_RefPoints;
				ObservableList<ReferencePoint> area;
				int index;
				ReferencePoint theOriginalRefPoint = (area = Area)[index = i];
				ReferencePoint item = ReferencePoint.CopyRefPoint(ref theOriginalRefPoint);
				area[index] = theOriginalRefPoint;
				obj.Add(item);
			}
			List<ReferencePoint> list = default(List<ReferencePoint>);
			if (!SplitLongSegments)
			{
				list = Area;
			}
			else
			{
				int num2 = 300;
				if (Area.Count >= 2)
				{
					list = new List<ReferencePoint>();
					ReferencePoint referencePoint = Area.Last();
					int index = Area.Count - 1;
					double out_lon = default(double);
					double out_lat = default(double);
					for (int j = 0; j <= index; j++)
					{
						ReferencePoint referencePoint2 = Area[j];
						float num3 = Math2.CalcDist(referencePoint, referencePoint2);
						if (num3 > (float)num2)
						{
							int num4 = (int)Math.Ceiling(num3 / (float)num2);
							float num5 = num3 / (float)num4;
							float bearing = Math2.NormalizeBearing(Math2.CalcAzimuth(referencePoint.Latitude, referencePoint.Longitude, referencePoint2.Latitude, referencePoint2.Longitude));
							int num6 = num4 - 1;
							for (int k = 1; k <= num6; k++)
							{
								Geodesic_EdWilliams.CalcPoint_Williams(referencePoint.Longitude, referencePoint.Latitude, ref out_lon, ref out_lat, num5 * (float)k, bearing);
								list.Add(new ReferencePoint(out_lon, out_lat));
							}
						}
						list.Add(referencePoint2);
						referencePoint = referencePoint2;
					}
					count = list.Count;
				}
			}
			int num7 = ((!flag) ? (count - 1) : count);
			Coordinate[] array = new Coordinate[num7 + 1];
			int num8 = count - 1;
			for (int l = 0; l <= num8; l++)
			{
				array[l] = new Coordinate(list[l].Longitude, list[l].Latitude);
			}
			if (flag)
			{
				array[count] = array[0];
			}
			IGeometry geometry = default(IGeometry);
			if (!flag)
			{
				if (flag2)
				{
					LineString lineString = new LineString(array);
					try
					{
						geometry = lineString.Buffer(ProximityThreshold_Deg, 3);
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2?.Data.Add("Error at 200315", ex2.Message);
						GameGeneral.WriteExceptionsToLog(ex2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
						return;
					}
				}
				else if (flag3)
				{
					DotSpatial.Topology.Point point = new DotSpatial.Topology.Point(array[0]);
					try
					{
						geometry = point.Buffer(ProximityThreshold_Deg, 3);
					}
					catch (Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						Exception ex4 = ex3;
						ex4?.Data.Add("Error at 200652", ex4.Message);
						GameGeneral.WriteExceptionsToLog(ex4);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
						return;
					}
				}
			}
			else
			{
				Polygon polygon = new Polygon(new LinearRing(array));
				try
				{
					geometry = polygon.Buffer(ProximityThreshold_Deg, 2);
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception ex6 = ex5;
					ex6?.Data.Add("Error at 200278", ex6.Message);
					GameGeneral.WriteExceptionsToLog(ex6);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			if (Debugger.IsAttached && (Information.IsNothing((object)geometry) || geometry.Coordinates.Count == 0))
			{
				Debugger.Break();
			}
			if (Information.IsNothing((object)geometry))
			{
				return;
			}
			if ((object)geometry.GetType() == typeof(MultiPolygon))
			{
				IGeometry[] geometries = ((MultiPolygon)geometry).Geometries;
				for (int m = 0; m < geometries.Length; m = checked(m + 1))
				{
					IPolygon ibasicGeometry_ = (IPolygon)geometries[m];
					smethod_0(BufferedArea_GeoPoints, ibasicGeometry_);
				}
			}
			else
			{
				IPolygon ibasicGeometry_2 = (IPolygon)geometry;
				smethod_0(BufferedArea_GeoPoints, ibasicGeometry_2);
			}
		}
		catch (Exception ex7)
		{
			ProjectData.SetProjectError(ex7);
			Exception ex8 = ex7;
			ex8?.Data.Add("Error at 200277", ex8.Message);
			GameGeneral.WriteExceptionsToLog(ex8);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void smethod_0(List<Geopoint_Struct> list_0, IBasicGeometry ibasicGeometry_0)
	{
		int num = ibasicGeometry_0.Coordinates.Count - 2;
		for (int i = 0; i <= num; i++)
		{
			if (ibasicGeometry_0.Coordinates[i].X > 180.0)
			{
				ibasicGeometry_0.Coordinates[i].X = 180.0;
			}
			else if (ibasicGeometry_0.Coordinates[i].X < -180.0)
			{
				ibasicGeometry_0.Coordinates[i].X = -180.0;
			}
			if (ibasicGeometry_0.Coordinates[i].Y > 90.0)
			{
				ibasicGeometry_0.Coordinates[i].Y = 90.0;
			}
			else if (ibasicGeometry_0.Coordinates[i].Y < -90.0)
			{
				ibasicGeometry_0.Coordinates[i].Y = -90.0;
			}
			list_0.Add(new Geopoint_Struct(ibasicGeometry_0.Coordinates[i].X, ibasicGeometry_0.Coordinates[i].Y));
		}
	}

	internal float CalculateDistanceToZone(double theLat, double theLon, Scenario theScen)
	{
		float result;
		try
		{
			int count = Area.Count;
			if (count == 0)
			{
				result = float.MaxValue;
				goto IL_0213;
			}
			int num = ((count <= 2) ? (count - 1) : count);
			Coordinate[] array = new Coordinate[num + 1];
			int num2 = count - 1;
			for (int i = 0; i <= num2; i++)
			{
				array[i] = new Coordinate(Area[i].Longitude, Area[i].Latitude);
			}
			if (count > 2)
			{
				array[count] = array[0];
			}
			if (count > 2)
			{
				Polygon g = new Polygon(new LinearRing(array));
				try
				{
					DotSpatial.Topology.Point g2 = new DotSpatial.Topology.Point(theLon, theLat);
					Coordinate[] array2 = DistanceOp.ClosestPoints(g, g2);
					result = Math2.CalcDist(array2[0].Y, array2[0].X, array2[1].Y, array2[1].X);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 200339", ex2.Message);
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					result = float.MaxValue;
					ProjectData.ClearProjectError();
				}
				goto IL_0213;
			}
			switch (count)
			{
			case 2:
			{
				LineString g3 = new LineString(array);
				try
				{
					DotSpatial.Topology.Point g4 = new DotSpatial.Topology.Point(theLon, theLat);
					Coordinate[] array3 = DistanceOp.ClosestPoints(g3, g4);
					result = Math2.CalcDist(array3[0].Y, array3[0].X, array3[1].Y, array3[1].X);
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					ex4?.Data.Add("Error at 200338", ex4.Message);
					GameGeneral.WriteExceptionsToLog(ex4);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					result = float.MaxValue;
					ProjectData.ClearProjectError();
				}
				goto IL_0213;
			}
			case 1:
				result = float.MaxValue;
				goto IL_0213;
			}
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			ex6?.Data.Add("Error at 200336", ex6.Message);
			GameGeneral.WriteExceptionsToLog(ex6);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		result = float.MaxValue;
		goto IL_0213;
		IL_0213:
		return result;
	}

	private void method_0()
	{
		nullable_0 = AffectedUnitTypes.Contains(GlobalVariables.ActiveUnitType.Aircraft);
		nullable_1 = AffectedUnitTypes.Contains(GlobalVariables.ActiveUnitType.Ship);
		nullable_2 = AffectedUnitTypes.Contains(GlobalVariables.ActiveUnitType.Submarine);
		nullable_3 = AffectedUnitTypes.Contains(GlobalVariables.ActiveUnitType.Facility) | AffectedUnitTypes.Contains(GlobalVariables.ActiveUnitType.Vehicle);
		nullable_4 = AffectedUnitTypes.Contains(GlobalVariables.ActiveUnitType.Vehicle) | AffectedUnitTypes.Contains(GlobalVariables.ActiveUnitType.Facility);
		nullable_5 = AffectedUnitTypes.Contains(GlobalVariables.ActiveUnitType.Weapon);
		nullable_6 = AffectedUnitTypes.Contains(GlobalVariables.ActiveUnitType.Satellite);
	}

	public virtual void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized, ref Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("Zone");
			theWriter.WriteElementString("ID", ObjectID);
			theWriter.WriteElementString("Description", Description);
			theWriter.WriteElementString("Color_A", AreaColor.A.ToString());
			theWriter.WriteElementString("Color_R", AreaColor.R.ToString());
			theWriter.WriteElementString("Color_G", AreaColor.G.ToString());
			theWriter.WriteElementString("Color_B", AreaColor.B.ToString());
			theWriter.WriteElementString("Layer", _Layer.ToString());
			theWriter.WriteElementString("IsLocked", IsLocked.ToString());
			theWriter.WriteStartElement("Area");
			int num = Area.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				ReferencePoint referencePoint;
				try
				{
					referencePoint = Area[i];
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
					continue;
				}
				theWriter.WriteRaw(referencePoint.ToXML(ref ObjectsAlreadySerialized));
			}
			theWriter.WriteEndElement();
			if (AltitudeEnvelopeMin.HasValue)
			{
				theWriter.WriteElementString("AltitudeEnvelopeMin", AltitudeEnvelopeMin.ToString());
			}
			if (AltitudeEnvelopeMax.HasValue)
			{
				theWriter.WriteElementString("AltitudeEnvelopeMax", AltitudeEnvelopeMax.ToString());
			}
			theWriter.WriteRaw("<Enablers>");
			if (!Enablers.GNSS_GPS)
			{
				theWriter.WriteRaw("<GPS_False/>");
			}
			if (!Enablers.GNSS_GLONASS)
			{
				theWriter.WriteRaw("<GLONASS_False/>");
			}
			if (!Enablers.GNSS_BeiDou)
			{
				theWriter.WriteRaw("<BeiDou_False/>");
			}
			if (!Enablers.GNSS_NavIC)
			{
				theWriter.WriteRaw("<NavIC_False/>");
			}
			theWriter.WriteRaw("</Enablers>");
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100993", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static Zone FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref Scenario theScen)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_031a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected O, but got Unknown
		Zone result2;
		try
		{
			Zone zone = new Zone();
			byte alpha = 110;
			byte? b = default(byte?);
			byte? b3 = default(byte?);
			byte? b2 = default(byte?);
			IEnumerator enumerator2 = default(IEnumerator);
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "Color_A":
					alpha = XmlConvert.ToByte(val.InnerText);
					break;
				case "Area":
					foreach (XmlNode childNode2 in val.ChildNodes)
					{
						XmlNode theNode2 = childNode2;
						zone.Area.Add(ReferencePoint.FromXML(ref theNode2, ref theDictionary, theScen));
					}
					break;
				case "Color_G":
					b = XmlConvert.ToByte(val.InnerText);
					break;
				case "IsLocked":
					zone.IsLocked = Misc.ParseBool(val.InnerText);
					break;
				case "Color_R":
					b3 = XmlConvert.ToByte(val.InnerText);
					break;
				case "Color_B":
					b2 = XmlConvert.ToByte(val.InnerText);
					break;
				case "AltitudeEnvelopeMin":
				{
					if (float.TryParse(val.InnerText, out var result3))
					{
						zone.AltitudeEnvelopeMin = result3;
					}
					break;
				}
				case "Description":
					zone.Description = val.InnerText;
					break;
				case "ID":
					if (!theDictionary.ContainsKey(val.InnerText))
					{
						zone.ObjectID_Set(val.InnerText);
						theDictionary.TryAdd(zone.ObjectID, zone);
						break;
					}
					result2 = (NoNavZone)theDictionary[val.InnerText];
					goto end_IL_0001;
				case "Layer":
					zone._Layer = XmlConvert.ToInt32(val.InnerText);
					break;
				case "Enablers":
					{
						enumerator2 = val.ChildNodes.GetEnumerator();
						try
						{
							while (enumerator2.MoveNext())
							{
								switch (((XmlNode)enumerator2.Current).Name)
								{
								case "GPS_False":
									zone.Enablers.GNSS_GPS = false;
									break;
								case "GLONASS_False":
									zone.Enablers.GNSS_GLONASS = false;
									break;
								case "NavIC_False":
									zone.Enablers.GNSS_NavIC = false;
									break;
								case "BeiDou_False":
									zone.Enablers.GNSS_BeiDou = false;
									break;
								}
							}
						}
						finally
						{
							IDisposable disposable = enumerator2 as IDisposable;
							if (disposable != null)
							{
								disposable.Dispose();
							}
						}
					}
					break;
				case "AltitudeEnvelopeMax":
				{
					if (float.TryParse(val.InnerText, out var result))
					{
						zone.AltitudeEnvelopeMax = result;
					}
					break;
				}
				}
			}
			if (!Information.IsNothing((object)b3))
			{
				zone.AreaColor = Color.FromArgb(alpha, b3.Value, b.Value, b2.Value);
			}
			else
			{
				zone.AreaColor = Color.Beige;
			}
			if (Information.IsNothing((object)zone.AffectedUnitTypes))
			{
				zone.AffectedUnitTypes = new ObservableList<GlobalVariables.ActiveUnitType>
				{
					GlobalVariables.ActiveUnitType.Aircraft,
					GlobalVariables.ActiveUnitType.Ship,
					GlobalVariables.ActiveUnitType.Submarine,
					GlobalVariables.ActiveUnitType.Facility
				};
			}
			result2 = zone;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100994", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result2 = new Zone();
			ProjectData.ClearProjectError();
		}
		return result2;
	}

	private void method_1(object object_0, ObservableListModified<GlobalVariables.ActiveUnitType> observableListModified_0)
	{
		method_0();
	}

	private void method_2(object object_0, ObservableListModified<GlobalVariables.ActiveUnitType> observableListModified_0)
	{
		method_0();
	}

	private void method_3(object object_0, ObservableListModified<ReferencePoint> observableListModified_0)
	{
		Area_AsArray = Area.ToArray();
	}

	private void method_4(object object_0, object object_1)
	{
		Area_AsArray = new ReferencePoint[0];
	}

	private void method_5(object object_0, ObservableListModified<ReferencePoint> observableListModified_0)
	{
		Area_AsArray = Area.ToArray();
	}

	static Zone()
	{
		Class72.smethod_20();
	}
}
