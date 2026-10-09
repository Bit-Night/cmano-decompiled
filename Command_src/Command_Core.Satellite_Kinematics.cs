using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Zeptomoby.OrbitTools;
using Zeptomoby.OrbitTools.Pro;

namespace Command_Core;

public sealed class Satellite_Kinematics : ActiveUnit_Kinematics
{
	public sealed class CoverageRecord
	{
		public Satellite theSat;

		public DateTime StartOfCoverage;

		public long DwellTime;

		static CoverageRecord()
		{
			Class72.smethod_20();
		}
	}

	private Zeptomoby.OrbitTools.Pro.Satellite satellite_0;

	private SatelliteModel_Tukey.TSatellite tsatellite_0;

	public long Apogee
	{
		get
		{
			if (tsatellite_0 == null)
			{
				return (long)Math.Round(satellite_0.Orbit.ApogeeKmRec * 1000.0);
			}
			return (long)Math.Round(tsatellite_0.ApogeeAltitude_km * 1000.0);
		}
	}

	public long Perigee
	{
		get
		{
			if (tsatellite_0 != null)
			{
				return (long)Math.Round(tsatellite_0.PerigeeAltitude_km * 1000.0);
			}
			return (long)Math.Round(satellite_0.Orbit.PerigeeKmRec * 1000.0);
		}
	}

	public Satellite_Kinematics(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
	}

	public void SetOrbit_Tukey(string[] TLE_Array)
	{
		satellite_0 = null;
		tsatellite_0 = new SatelliteModel_Tukey.TSatellite();
		tsatellite_0.method_0(TLE_Array);
		try
		{
			Move(0f, CheckForMinimumSafeHeight: false, SimplifiedCalcs_DLZ: false, myUnit.ParentScen.Time);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			SetOrbit_Tukey((float)tsatellite_0.Inclination, (long)Math.Round(tsatellite_0.ApogeeAltitude_km * 1000.0), (long)Math.Round(tsatellite_0.PerigeeAltitude_km * 1000.0), tsatellite_0.MeanAnomaly);
			ProjectData.ClearProjectError();
		}
	}

	public void SetOrbit_Tukey(float theInclination, long Apogee_m, long Perigee_m)
	{
		SetOrbit_Tukey(theInclination, Apogee_m, Perigee_m, 0.0);
	}

	public void SetOrbit_Tukey(float theInclination, long Apogee_m, long Perigee_m, double theMeanAnomaly)
	{
		satellite_0 = null;
		tsatellite_0 = new SatelliteModel_Tukey.TSatellite();
		tsatellite_0.ReInit(theInclination, (double)Apogee_m / 1000.0, (double)Perigee_m / 1000.0);
		tsatellite_0.MeanAnomaly = theMeanAnomaly;
		try
		{
			Move(0f, CheckForMinimumSafeHeight: false, SimplifiedCalcs_DLZ: false, myUnit.ParentScen.Time);
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

	public void SetOrbit_OT(string[] TLE_Array)
	{
		try
		{
			tsatellite_0 = null;
			if (TLE_Array.Length == 2)
			{
				List<string> list = TLE_Array.ToList();
				list.Insert(0, "Mysat");
				TLE_Array = list.ToArray();
			}
			if (Operators.CompareString(TLE_Array[1].Substring(17, 1), " ", false) != 0)
			{
				string[] array = TLE_Array[1].Split(new char[1] { ' ' });
				string text = $"{array[0]} {array[1],6} {array[2],-8} {array[3],-14} {array[4],11} {array[5],-8} {array[6],-7} {array[7]} {array[8],5}";
				TLE_Array[1] = text;
			}
			if (Operators.CompareString(TLE_Array[2].Substring(7, 2), "  ", false) != 0)
			{
				string[] theArray = TLE_Array[2].Split(new char[1] { ' ' });
				if (theArray.Count() != 9)
				{
					ArrayExtensions.Add(ref theArray, "0");
				}
				string text2 = $"{theArray[0]} {theArray[1],5} {theArray[2],-8} {theArray[3],8} {theArray[4],-7} {theArray[5],-8} {theArray[6],-8} {theArray[7],11} {theArray[8],6}";
				TLE_Array[2] = text2;
			}
			TwoLineElements elem = new TwoLineElements(TLE_Array[0], TLE_Array[1], TLE_Array[2]);
			satellite_0 = new Zeptomoby.OrbitTools.Pro.Satellite(elem, Wgs84.Ellipsoid);
			if (satellite_0.Orbit.ApogeeKmRec != 0.0 && satellite_0.Orbit.PerigeeKmRec != 0.0)
			{
				if (satellite_0.Orbit.ApogeeKmRec < satellite_0.Orbit.PerigeeKmRec)
				{
					throw new Exception("Satellite " + myUnit.Name + ": Perigee can't have a greater value than apogee");
				}
				if (satellite_0.Orbit.Elements.Eccentricity != 0.0 && satellite_0.Orbit.Elements.Eccentricity <= 1.0)
				{
					Move(0f, CheckForMinimumSafeHeight: false, SimplifiedCalcs_DLZ: false, myUnit.ParentScen.Time);
					if (float.IsNaN(myUnit.CurrentHeading))
					{
						SetOrbit_Tukey(TLE_Array);
					}
					return;
				}
				throw new Exception("Satellite " + myUnit.Name + ": Eccentricity value is out of bound, ejection isn't supported.");
			}
			throw new Exception("Satellite " + myUnit.Name + ": Either apogee or perigee has a value of 0 ");
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			SetOrbit_Tukey(TLE_Array);
			ProjectData.ClearProjectError();
		}
	}

	public void PredictPosition(DateTime theTime, ref double Latitude, ref double Longitude, ref double Altitude_Km, ref double Speed_knots)
	{
		Satellite.SatelliteOrbitAnchor orbitAnchor = ((Satellite)myUnit).OrbitAnchor;
		if (orbitAnchor != null)
		{
			Longitude = orbitAnchor.Longitude;
			Latitude = orbitAnchor.Latitude;
			Altitude_Km = orbitAnchor.Altitude / 1000f;
			Speed_knots = 0.0;
			return;
		}
		if (satellite_0 != null)
		{
			EciTime eciTime = satellite_0.PositionEci(theTime);
			Geo geo = new Geo(eciTime, new Julian(theTime), Wgs84.Ellipsoid);
			Latitude = geo.LatitudeDeg;
			Longitude = geo.LongitudeDeg;
			Altitude_Km = geo.Altitude;
			double num = Math.Abs(Math.Sqrt(Math.Pow(eciTime.Velocity.X, 2.0) + Math.Pow(eciTime.Velocity.Y, 2.0) + Math.Pow(eciTime.Velocity.Z, 2.0)) * 1000.0);
			Speed_knots = num * 1.94384;
			return;
		}
		double Velocity = default(double);
		tsatellite_0.Predict_Position(theTime, IsUTC: true, ref Latitude, ref Longitude, ref Altitude_Km, ref Velocity);
		if (Altitude_Km < (double)Perigee / 1000.0)
		{
			Altitude_Km = (double)Perigee / 1000.0;
		}
		if (Altitude_Km > (double)Apogee / 1000.0)
		{
			Altitude_Km = (double)Apogee / 1000.0;
		}
		Speed_knots = Velocity * 1000.0 * 1.94384;
	}

	public override void Move(float elapsedTime, bool CheckForMinimumSafeHeight, bool SimplifiedCalcs_DLZ, DateTime ExplicitDateTime, bool GhostMovement = false)
	{
		try
		{
			((Satellite)myUnit).InvalidatePositionVector();
			myUnit.Altitude_old = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			double Latitude = default(double);
			double Longitude = default(double);
			double Altitude_Km = default(double);
			double Speed_knots = default(double);
			double Latitude2 = default(double);
			double Longitude2 = default(double);
			double Altitude_Km2 = default(double);
			double Speed_knots2 = default(double);
			try
			{
				PredictPosition(ExplicitDateTime, ref Latitude, ref Longitude, ref Altitude_Km, ref Speed_knots);
				PredictPosition(ExplicitDateTime.AddSeconds(1.0), ref Latitude2, ref Longitude2, ref Altitude_Km2, ref Speed_knots2);
			}
			catch (DecayException projectError)
			{
				ProjectData.SetProjectError((Exception)projectError);
				myUnit.Destroy(ScenEditAction: false, IsFacilityAimpoint: false, DestroyUnitNow: true, "Orbit decayed");
				ProjectData.ClearProjectError();
			}
			if (!double.IsNaN(Latitude) && !double.IsNaN(Longitude) && !double.IsNaN(Latitude2) && !double.IsNaN(Longitude2))
			{
				myUnit.CurrentHeading = Math2.CalcAzimuth(Latitude, Longitude, Latitude2, Longitude2);
				if (myUnit.ParentScen.TimeCompression_SimSeconds > 1)
				{
					myUnit.set_Latitude((GlobalVariables.BooleanObject)null, Latitude);
					myUnit.set_Longitude((GlobalVariables.BooleanObject)null, Longitude);
					myUnit.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)(Altitude_Km * 1000.0));
					myUnit.CurrentSpeed = (float)Speed_knots;
				}
				else
				{
					float num = (float)((double)ExplicitDateTime.Millisecond / 1000.0);
					float num2 = Math2.CalcDist(Latitude, Longitude, Latitude2, Longitude2);
					float distance_NM = num * num2;
					double lon = Longitude;
					double lat = Latitude;
					ActiveUnit activeUnit;
					double out_lon = (activeUnit = myUnit).get_Longitude((GlobalVariables.BooleanObject)null);
					ActiveUnit activeUnit2;
					double out_lat = (activeUnit2 = myUnit).get_Latitude((GlobalVariables.BooleanObject)null);
					Geodesic_EdWilliams.CalcPoint_Williams(lon, lat, ref out_lon, ref out_lat, distance_NM, myUnit.CurrentHeading);
					activeUnit2.set_Latitude((GlobalVariables.BooleanObject)null, out_lat);
					activeUnit.set_Longitude((GlobalVariables.BooleanObject)null, out_lon);
					myUnit.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)((Altitude_Km + (Altitude_Km2 - Altitude_Km) * (double)num) * 1000.0));
					myUnit.CurrentSpeed = (float)(Speed_knots + (Speed_knots2 - Speed_knots) * (double)num);
				}
				myUnit.updateLastReportedInfo();
				if (!SimplifiedCalcs_DLZ)
				{
					myUnit.Kinematics.ExportLocationEvent();
				}
				Module_Unit.ComputeCurrentSpeed_Vertical(myUnit, elapsedTime);
				return;
			}
			throw new Exception("NaN values generated duirng orbital calculation.");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100755", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			throw;
		}
	}

	public static List<CoverageRecord> PassPrediction(Geopoint_Struct LocationPoint, Satellite theSat, DateTime StartTime, DateTime EndTime, float MaxSensorRange, float MaxAngleOffZenith, int SampleInterval = 10)
	{
		List<CoverageRecord> list = new List<CoverageRecord>();
		if (Information.IsNothing((object)theSat))
		{
			return list;
		}
		int num = (int)Math.Round((EndTime - StartTime).TotalSeconds);
		Module_Unit.Unit unit = new Module_Unit.Unit();
		bool flag = false;
		int num2 = num;
		double Altitude_Km = default(double);
		double Speed_knots = default(double);
		CoverageRecord coverageRecord = default(CoverageRecord);
		for (int i = 0; ((SampleInterval >> 31) ^ i) <= ((SampleInterval >> 31) ^ num2); i += SampleInterval)
		{
			DateTime dateTime = StartTime.AddSeconds(i);
			Satellite_Kinematics kinematics = theSat.Kinematics;
			Module_Unit.Unit unit2;
			double Latitude = (unit2 = unit).get_Latitude((GlobalVariables.BooleanObject)null);
			Module_Unit.Unit unit3;
			double Longitude = (unit3 = unit).get_Longitude((GlobalVariables.BooleanObject)null);
			kinematics.PredictPosition(dateTime, ref Latitude, ref Longitude, ref Altitude_Km, ref Speed_knots);
			unit3.set_Longitude((GlobalVariables.BooleanObject)null, Longitude);
			unit2.set_Latitude((GlobalVariables.BooleanObject)null, Latitude);
			unit.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)(Altitude_Km * 1000.0));
			if (Module_Unit.RangeToPoint_Slant(unit, LocationPoint.Latitude, LocationPoint.Longitude, LocationPoint.Altitude) <= MaxSensorRange && Module_Unit.OffZenithAngleToPoint(unit, LocationPoint.Latitude, LocationPoint.Longitude, LocationPoint.Altitude) <= (double)MaxAngleOffZenith && Module_Unit.RangeToPoint_Horiz(unit, LocationPoint.Latitude, LocationPoint.Longitude) < Horizon.VisualHorizonNM(unit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), LocationPoint.Altitude))
			{
				if (!flag)
				{
					coverageRecord = new CoverageRecord();
					coverageRecord.theSat = theSat;
					coverageRecord.StartOfCoverage = dateTime;
					coverageRecord.DwellTime = 0L;
					flag = true;
				}
				else
				{
					coverageRecord.DwellTime += SampleInterval;
				}
			}
			else if (flag)
			{
				coverageRecord.DwellTime += SampleInterval;
				list.Add(coverageRecord);
				coverageRecord = null;
				flag = false;
			}
		}
		if (coverageRecord != null)
		{
			list.Add(coverageRecord);
		}
		return list;
	}

	static Satellite_Kinematics()
	{
		Class72.smethod_20();
	}
}
