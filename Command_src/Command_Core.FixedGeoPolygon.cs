using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public abstract class FixedGeoPolygon
{
	protected float Bounds_North;

	protected float Bounds_South;

	protected float Bounds_East;

	protected float Bounds_West;

	private double[] double_0;

	private double[] double_1;

	public abstract List<Geopoint_Struct> Area { get; }

	public bool PointIsInArea
	{
		get
		{
			bool result;
			try
			{
				if (Bounds_North == float.MinValue)
				{
					method_0();
				}
				if (theLat > (double)Bounds_North)
				{
					result = false;
				}
				else if (theLat < (double)Bounds_South)
				{
					result = false;
				}
				else if (theLon > (double)Bounds_East)
				{
					result = false;
				}
				else if (theLon < (double)Bounds_West)
				{
					result = false;
				}
				else
				{
					while (true)
					{
						int millisecondsTimeout;
						if (double_0 != null)
						{
							if (double_1 != null)
							{
								break;
							}
							millisecondsTimeout = 10;
						}
						else
						{
							millisecondsTimeout = 10;
						}
						Thread.Sleep(millisecondsTimeout);
					}
					result = GeoPoint.PointInPolygonB3(theLat, theLon, double_0, double_1);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200095", ex2.Message);
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
	}

	public bool PointIsInArea
	{
		get
		{
			if (Bounds_North == float.MinValue)
			{
				method_0();
			}
			if (thePoint.Latitude > (double)Bounds_North)
			{
				return false;
			}
			if (thePoint.Latitude < (double)Bounds_South)
			{
				return false;
			}
			if (thePoint.Longitude > (double)Bounds_East)
			{
				return false;
			}
			if (thePoint.Longitude < (double)Bounds_West)
			{
				return false;
			}
			while (true)
			{
				int millisecondsTimeout;
				if (double_0 == null)
				{
					millisecondsTimeout = 10;
				}
				else
				{
					if (double_1 != null)
					{
						break;
					}
					millisecondsTimeout = 10;
				}
				Thread.Sleep(millisecondsTimeout);
			}
			return GeoPoint.PointInPolygonB3(thePoint.Latitude, thePoint.Longitude, double_0, double_1);
		}
	}

	protected FixedGeoPolygon()
	{
		Bounds_North = float.MinValue;
		Bounds_South = float.MinValue;
		Bounds_East = float.MinValue;
		Bounds_West = float.MinValue;
	}

	private void method_0()
	{
		if (Area == null || Area.Count == 0)
		{
			return;
		}
		int count = Area.Count;
		double_0 = new double[count - 1 + 1];
		double_1 = new double[count - 1 + 1];
		Bounds_North = (float)Area[0].Latitude;
		Bounds_South = (float)Area[0].Latitude;
		Bounds_East = (float)Area[0].Longitude;
		Bounds_West = (float)Area[0].Longitude;
		int num = count - 1;
		for (int i = 0; i <= num; i++)
		{
			double latitude = Area[i].Latitude;
			double longitude = Area[i].Longitude;
			double_1[i] = latitude;
			double_0[i] = longitude;
			if (latitude > (double)Bounds_North)
			{
				Bounds_North = (float)latitude;
			}
			if (latitude < (double)Bounds_South)
			{
				Bounds_South = (float)latitude;
			}
			if (longitude > (double)Bounds_East)
			{
				Bounds_East = (float)longitude;
			}
			if (longitude < (double)Bounds_West)
			{
				Bounds_West = (float)longitude;
			}
		}
	}

	static FixedGeoPolygon()
	{
		Class72.smethod_20();
	}
}
