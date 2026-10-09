using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Collections.Pooled;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class Module_Contact
{
	internal static List<Platform> IsPrimaryTargetForThesePlatforms(this Contact theContact, Side theSide, bool GroupsOnly, ActiveUnit ExcludeThisUnit = null)
	{
		List<Platform> result;
		if (theContact.ActualUnit.ParentScen.Cache_PrimaryTargetForWhichPlatforms.TryGetValue(theContact.ObjectID, out var value))
		{
			List<Platform> list = new List<Platform>(value);
			if (ExcludeThisUnit != null && list.Contains((Platform)ExcludeThisUnit))
			{
				list.Remove((Platform)ExcludeThisUnit);
			}
			if (GroupsOnly)
			{
				List<ActiveUnit> list2 = new List<ActiveUnit>();
				foreach (Platform item in list)
				{
					if (item.IsGroupWingman())
					{
						list2.Add(item);
					}
				}
				if (list2.Count > 0)
				{
					foreach (ActiveUnit item2 in list2)
					{
						list.Remove((Platform)item2);
					}
				}
			}
			result = list;
		}
		else
		{
			value = new List<Platform>();
			try
			{
				if (theSide == null)
				{
					result = value;
				}
				else if (theSide.Units.Count == 0)
				{
					result = value;
				}
				else
				{
					ActiveUnit[] array = theSide.Units.InternalArray();
					int num = array.Count() - 1;
					for (int i = 0; i <= num; i++)
					{
						ActiveUnit activeUnit;
						try
						{
							activeUnit = array[i];
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							ProjectData.ClearProjectError();
							continue;
						}
						if (activeUnit != null && activeUnit.IsPlatform)
						{
							Contact primaryTarget = activeUnit.AI.PrimaryTarget;
							if (primaryTarget != null && primaryTarget == theContact)
							{
								value.Add((Platform)activeUnit);
							}
						}
					}
					theContact.ActualUnit.ParentScen.Cache_PrimaryTargetForWhichPlatforms.AddIfNotExistsElseUpdate(theContact.ObjectID, value);
					List<Platform> list3 = new List<Platform>(value);
					if (ExcludeThisUnit != null && list3.Contains((Platform)ExcludeThisUnit))
					{
						list3.Remove((Platform)ExcludeThisUnit);
					}
					if (GroupsOnly)
					{
						PooledList<ActiveUnit> pooledList = new PooledList<ActiveUnit>();
						foreach (Platform item3 in list3)
						{
							if (item3.IsGroupWingman())
							{
								pooledList.Add(item3);
							}
						}
						if (pooledList.Count > 0)
						{
							foreach (ActiveUnit item4 in pooledList)
							{
								list3.Remove((Platform)item4);
							}
						}
						pooledList.Dispose();
					}
					result = list3;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100491", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = value;
				ProjectData.ClearProjectError();
			}
		}
		return result;
	}

	internal static float CrossRangeAmbiguity(this Contact theContact, double ObservationPoint_Lat, double ObservationPoint_Lon)
	{
		float result;
		try
		{
			if (theContact.UncertaintyArea != null)
			{
				if (theContact.UncertaintyArea.Count == 0)
				{
					result = 0f;
				}
				else
				{
					double num = ((Module_Unit.Unit)theContact).get_Longitude((GlobalVariables.BooleanObject)null);
					double num2 = ((Module_Unit.Unit)theContact).get_Latitude((GlobalVariables.BooleanObject)null);
					float originalBearing = Math2.CalcAzimuth(ObservationPoint_Lat, ObservationPoint_Lon, num2, num);
					double num3 = double.MinValue;
					double num4 = double.MaxValue;
					List<Geopoint_Struct> uncertaintyArea = theContact.UncertaintyArea;
					int num5 = uncertaintyArea.Count - 1;
					Geopoint_Struct geopoint_Struct2 = default(Geopoint_Struct);
					Geopoint_Struct geopoint_Struct3 = default(Geopoint_Struct);
					for (int i = 0; i <= num5; i++)
					{
						Geopoint_Struct geopoint_Struct = uncertaintyArea[i];
						double num6 = MathFunctions.AngularDifference_SmallestValue(originalBearing, Math2.CalcAzimuth(ObservationPoint_Lat, ObservationPoint_Lon, geopoint_Struct.Latitude, geopoint_Struct.Longitude));
						if (num6 > num3)
						{
							num3 = num6;
							geopoint_Struct2 = geopoint_Struct;
						}
						if (num6 < num4)
						{
							num4 = num6;
							geopoint_Struct3 = geopoint_Struct;
						}
					}
					float num7 = MathFunctions.ClosestDistance_Geographic(new Geopoint_Struct(ObservationPoint_Lon, ObservationPoint_Lat), new Geopoint_Struct(num, num2), new Geopoint_Struct(geopoint_Struct3.Longitude, geopoint_Struct3.Latitude));
					float num8 = MathFunctions.ClosestDistance_Geographic(new Geopoint_Struct(ObservationPoint_Lon, ObservationPoint_Lat), new Geopoint_Struct(num, num2), new Geopoint_Struct(geopoint_Struct2.Longitude, geopoint_Struct2.Latitude));
					result = num7 + num8;
				}
			}
			else
			{
				result = 0f;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100487", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = float.MaxValue;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal static float DownRangeAmbiguity(this Contact theContact, Module_Unit.Unit theObserver)
	{
		float result = default(float);
		try
		{
			if (theContact.UncertaintyArea != null)
			{
				if (theContact.UncertaintyArea.Count != 0)
				{
					double num = double.MaxValue;
					double num2 = 0.0;
					List<Geopoint_Struct> uncertaintyArea = theContact.UncertaintyArea;
					int num3 = uncertaintyArea.Count - 1;
					for (int i = 0; i <= num3; i++)
					{
						Geopoint_Struct geopoint_Struct = uncertaintyArea[i];
						double num4 = Module_Unit.RangeToPoint_Horiz_Angular(theObserver, ref geopoint_Struct.Latitude, ref geopoint_Struct.Longitude, GlobalVariables.ObjectTrue);
						if (num4 < num)
						{
							num = num4;
						}
						if (num4 > num2)
						{
							num2 = num4;
						}
					}
					result = (float)(num2 - num) * 60f;
					return result;
				}
				result = 0f;
				return result;
			}
			result = 0f;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100488", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	static Module_Contact()
	{
		Class72.smethod_20();
	}
}
