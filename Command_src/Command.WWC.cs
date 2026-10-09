using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using Command_Core;
using CSMaterial.ExWorldWind;
using ExWorldWind;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[StandardModule]
internal sealed class WWC
{
	public static WorldCamera _WorldCamera;

	private static bool bool_0;

	static WWC()
	{
		Class72.smethod_20();
		bool_0 = false;
	}

	public static void WWC_WorldToScreen(WorldWindow theWW, double theLat, double theLon, ref int ScreenX, ref int ScreenY)
	{
		WWC_WorldToScreen(theWW, Module1.WW_DrawArgs, ref theLat, ref theLon, ref ScreenX, ref ScreenY);
	}

	public static Point WWC_WorldToScreen(WorldWindow theWW, double Lat, double Lon)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		Point result = default(Point);
		try
		{
			if (Lat == Lat && !double.IsInfinity(Lat) && Lon == Lon && !double.IsInfinity(Lon))
			{
				Vector3 val = MathEngine.SphericalToCartesian((float)Lat, (float)Lon, 6378137f);
				Vector3 vector = new Vector3(val.X - Module1.WW_DrawArgs.WorldCamera.ReferenceCenter.X, val.Y - Module1.WW_DrawArgs.WorldCamera.ReferenceCenter.Y, val.Z - Module1.WW_DrawArgs.WorldCamera.ReferenceCenter.Z);
				if (!bool_0)
				{
					_WorldCamera = Module1.WW_DrawArgs.WorldCamera;
					bool_0 = true;
				}
				Vector3 val2 = _WorldCamera.Project(vector);
				if (val2.X == val2.X && val2.Y == val2.Y)
				{
					result = new Point((int)Math.Round(val2.X), (int)Math.Round(val2.Y));
					return result;
				}
				result = default(Point);
			}
			else
			{
				result = default(Point);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200213904812590", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static Point[] WWC_WorldToScreen(WorldWindow theWW, (double Lon, double Lat)[] CoordsArray, int ExplicitArrayLength = -1)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		if (!bool_0)
		{
			_WorldCamera = Module1.WW_DrawArgs.WorldCamera;
			bool_0 = true;
		}
		Point[] result;
		try
		{
			int count = ((ExplicitArrayLength != -1) ? ExplicitArrayLength : CoordsArray.Length);
			float radius = 6378137f;
			Vector3 referenceCenter = _WorldCamera.ReferenceCenter;
			result = WorldCamera.SphericalToScreenOptimized(CoordsArray, count, radius, _WorldCamera, referenceCenter);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 2032489572389674", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Point[CoordsArray.Length - 1 + 1];
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static Point[] SphericalToScreenPoints((double Lon, double Lat)[] coords, int count, float radius, WorldCamera camera, Vector3 cameraRefCenter)
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		Point[] array = new Point[count - 1 + 1];
		Vector3[] array2 = ArrayPool<Vector3>.Shared.Rent(count);
		try
		{
			int num = count - 1;
			for (int i = 0; i <= num; i++)
			{
				Vector3 val = MathEngine.SphericalToCartesianSingle(Angle.FromDegrees(coords[i].Lon), Angle.FromDegrees(coords[i].Lat), radius);
				array2[i] = new Vector3(val.X - cameraRefCenter.X, val.Y - cameraRefCenter.Y, val.Z - cameraRefCenter.Z);
			}
			Vector3[] array3 = camera.Project(array2);
			int num2 = count - 1;
			for (int j = 0; j <= num2; j++)
			{
				Vector3 val2 = array3[j];
				array[j] = new Point((int)Math.Round(val2.X), (int)Math.Round(val2.Y));
			}
			ArrayPool<Vector3>.Shared.Return(array3, clearArray: true);
			return array;
		}
		finally
		{
			ArrayPool<Vector3>.Shared.Return(array2, clearArray: true);
		}
	}

	public static Point WWC_WorldToScreen(WorldWindow theWW, double theLat, double theLon, float theAlt)
	{
		Point result = default(Point);
		DrawArgs wW_DrawArgs = Module1.WW_DrawArgs;
		int ScreenX = result.X;
		int ScreenY = result.Y;
		WWC_WorldToScreen(theWW, wW_DrawArgs, ref theLat, ref theLon, ref theAlt, ref ScreenX, ref ScreenY);
		result.Y = ScreenY;
		result.X = ScreenX;
		return result;
	}

	public static Point WWC_WorldToScreen_WithAltitude(WorldWindow theWW, double theLat, double theLon, double TheAlt)
	{
		Point result = default(Point);
		DrawArgs wW_DrawArgs = Module1.WW_DrawArgs;
		int ScreenX = result.X;
		int ScreenY = result.Y;
		WWC_WorldToScreen(theWW, wW_DrawArgs, ref theLat, ref theLon, ref ScreenX, ref ScreenY);
		result.Y = ScreenY;
		result.X = ScreenX;
		return result;
	}

	public static GeoPoint WWC_ScreenToWorld(WorldWindow theWW, int PointX, int PointY)
	{
		GeoPoint geoPoint = new GeoPoint();
		Angle latitude = default(Angle);
		Angle longitude = default(Angle);
		theWW.DrawArgs.WorldCamera.PickingRayIntersection(PointX, PointY, out latitude, out longitude);
		geoPoint.Longitude = longitude.Degrees;
		geoPoint.Latitude = latitude.Degrees;
		return geoPoint;
	}

	public static Geopoint_Struct WWC_ScreenToWorld_Struct(WorldWindow theWW, int PointX, int PointY)
	{
		Geopoint_Struct geopoint_Struct = default(Geopoint_Struct);
		Angle latitude = default(Angle);
		Angle longitude = default(Angle);
		Geopoint_Struct result = default(Geopoint_Struct);
		try
		{
			theWW?.DrawArgs?.WorldCamera?.PickingRayIntersection(PointX, PointY, out latitude, out longitude);
			geopoint_Struct.Longitude = longitude.Degrees;
			geopoint_Struct.Latitude = latitude.Degrees;
			result = geopoint_Struct;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 32450239465095", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static void WWC_ScreenToWorld(WorldWindow theWW, ref int PointX, ref int PointY, ref double WorldLon, ref double WorldLat)
	{
		try
		{
			Angle latitude = default(Angle);
			Angle longitude = default(Angle);
			theWW?.DrawArgs?.WorldCamera?.PickingRayIntersection(PointX, PointY, out latitude, out longitude);
			WorldLon = longitude.Degrees;
			WorldLat = latitude.Degrees;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 32459038569486", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void WWC_ScreenToWorldAtGivenAltitude(WorldWindow theWW, ref int PointX, ref int PointY, ref float knownAltitude, ref double WorldLon, ref double WorldLat)
	{
		try
		{
			Angle latitude = default(Angle);
			Angle longitude = default(Angle);
			theWW?.DrawArgs?.WorldCamera?.PickingRayIntersection(PointX, PointY, knownAltitude, out latitude, out longitude);
			WorldLon = longitude.Degrees;
			WorldLat = latitude.Degrees;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 32459038569486", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void WWC_WorldToScreen(WorldWindow theWW, DrawArgs theWW_DrawArgs, ref double Latitude, ref double Longitude, ref int ScreenX, ref int ScreenY)
	{
		float Altitude = 0f;
		WWC_WorldToScreen(theWW, theWW_DrawArgs, ref Latitude, ref Longitude, ref Altitude, ref ScreenX, ref ScreenY);
	}

	public static void WWC_WorldToScreen(WorldWindow theWW, DrawArgs theWW_DrawArgs, ref double Latitude, ref double Longitude, ref float Altitude, ref int ScreenX, ref int ScreenY)
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		double num = Latitude;
		double num2 = Longitude;
		float num3 = Altitude;
		try
		{
			if (num == num && !double.IsInfinity(num) && num2 == num2 && !double.IsInfinity(num2) && num3 == num3 && !double.IsInfinity(num3))
			{
				Vector3 val = MathEngine.SphericalToCartesian((float)num, (float)num2, 6378137f + num3);
				Vector3 vector = new Vector3(val.X - theWW_DrawArgs.WorldCamera.ReferenceCenter.X, val.Y - theWW_DrawArgs.WorldCamera.ReferenceCenter.Y, val.Z - theWW_DrawArgs.WorldCamera.ReferenceCenter.Z);
				if (!bool_0)
				{
					_WorldCamera = theWW.DrawArgs.WorldCamera;
					bool_0 = true;
				}
				Vector3 val2 = _WorldCamera.Project(vector);
				if (val2.X == val2.X && val2.Y == val2.Y)
				{
					ScreenX = (int)Math.Round(val2.X);
					ScreenY = (int)Math.Round(val2.Y);
				}
			}
			else
			{
				ScreenX = -1;
				ScreenY = -1;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200424", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static bool IsVisibleOnMap(WorldWindow theWW, double Latitude, double Longitude, float Altitude = float.NaN)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		if (!(Latitude != Latitude || Longitude != Longitude))
		{
			Vector3 point = MathEngine.SphericalToCartesian((float)Latitude, (float)Longitude, 6378137f);
			if (theWW.DrawArgs.WorldCamera.ViewFrustum.ContainsPoint(point))
			{
				return true;
			}
			if (SimConfiguration.DefaultGamePreferences.AltitudeRender.UnitsAtAltitude)
			{
				if (double.IsNaN(Altitude))
				{
					return false;
				}
				Point point2 = WWC_WorldToScreen(theWW, Latitude, Longitude, Altitude);
				theWW.DrawArgs.WorldCamera.PickingRayIntersection(point2.X, point2.Y, out var latitude, out var longitude);
				int result;
				if (Angle.IsNaN(latitude))
				{
					result = 1;
				}
				else
				{
					if (!Angle.IsNaN(longitude))
					{
						return false;
					}
					result = 1;
				}
				return (byte)result != 0;
			}
			return false;
		}
		return false;
	}

	public static bool IsVisibleOnMap(WorldWindow theWW, Geopoint_Struct theGeoPoint_Struct)
	{
		return IsVisibleOnMap(theWW, theGeoPoint_Struct.Latitude, theGeoPoint_Struct.Longitude, theGeoPoint_Struct.Altitude);
	}

	public static bool IsVisibleOnMap(WorldWindow theWW, Module_Unit.Unit theUnit)
	{
		if (theUnit.IsActiveUnit && !((ActiveUnit)theUnit).IsOperating())
		{
			return false;
		}
		if (!theUnit.IsContact())
		{
			if (SimConfiguration.DefaultGamePreferences.AltitudeRender.UnitsAtAltitude && theUnit.IsActiveUnit && ((ActiveUnit)theUnit).IsAerospaceUnit)
			{
				return IsVisibleOnMap(theWW, theUnit.get_Latitude((GlobalVariables.BooleanObject)null), theUnit.get_Longitude((GlobalVariables.BooleanObject)null), theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
			}
			return IsVisibleOnMap(theWW, theUnit.get_Latitude((GlobalVariables.BooleanObject)null), theUnit.get_Longitude((GlobalVariables.BooleanObject)null));
		}
		Contact contact = (Contact)theUnit;
		List<Geopoint_Struct> uncertaintyArea = contact.UncertaintyArea;
		if (uncertaintyArea != null)
		{
			int count = uncertaintyArea.Count;
			if (IsVisibleOnMap(theWW, theUnit.get_Latitude((GlobalVariables.BooleanObject)null), theUnit.get_Longitude((GlobalVariables.BooleanObject)null)))
			{
				return true;
			}
			int num = count - 1;
			int num2 = 0;
			while (true)
			{
				if (num2 <= num)
				{
					Geopoint_Struct geopoint_Struct = uncertaintyArea[num2];
					if (IsVisibleOnMap(theWW, geopoint_Struct.Latitude, geopoint_Struct.Longitude))
					{
						break;
					}
					num2++;
					continue;
				}
				return false;
			}
			return true;
		}
		if (SimConfiguration.DefaultGamePreferences.AltitudeRender.UnitsAtAltitude && contact.ActualUnit != null && contact.ActualUnit.IsAerospaceUnit)
		{
			return IsVisibleOnMap(theWW, theUnit.get_Latitude((GlobalVariables.BooleanObject)null), theUnit.get_Longitude((GlobalVariables.BooleanObject)null), theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
		}
		return IsVisibleOnMap(theWW, theUnit.get_Latitude((GlobalVariables.BooleanObject)null), theUnit.get_Longitude((GlobalVariables.BooleanObject)null));
	}
}
