using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using SettlersEngine;

namespace Command_Core;

public sealed class SettlersEnginePathfinder : GInterface1
{
	private sealed class Class17 : IPathNode<ActiveUnit>
	{
		public double double_0;

		public double double_1;

		private bool? nullable_0;

		private short? nullable_1;

		private List<ActiveUnit> list_0;

		private float float_0;

		[SpecialName]
		private short method_0(Scenario scenario_0)
		{
			if (Information.IsNothing((object)nullable_1))
			{
				nullable_1 = Pathfinding.pfcache_Array_0.GetElev(double_0, double_1, scenario_0);
			}
			return nullable_1.Value;
		}

		[SpecialName]
		public float method_1()
		{
			return float_0;
		}

		[SpecialName]
		public void XiHykbBsju8(float float_1)
		{
			float_0 = float_1;
		}

		[SpecialName]
		public List<ActiveUnit> method_2()
		{
			return list_0;
		}

		[SpecialName]
		public void method_3(List<ActiveUnit> list_1)
		{
			list_0 = list_1;
		}

		internal bool IsWalkable(ActiveUnit inContext)
		{
			if (!nullable_0.HasValue)
			{
				double theLat = double_0;
				double theLon = double_1;
				int MovementCost = 0;
				bool CheckNoNavZones = true;
				bool CheckForMines = true;
				short? providedElevation = method_0(inContext.ParentScen);
				List<ActiveUnit> ProvidedPiers = method_2();
				float proximityThreshold_Deg = method_1();
				string UserFeedback = "";
				bool AllowBounce = false;
				bool value = inContext.CanMoveToThisLocation(theLat, theLon, ref MovementCost, IsPathfindingQuery: true, UsePathfindingBufferDistance: true, IgnoreMinesBehindUs: false, ref CheckNoNavZones, CheckForIcepack: true, ref CheckForMines, null, providedElevation, ref ProvidedPiers, proximityThreshold_Deg, CheckIfTargetIsOutsideProsecutionArea: false, CheckDistanceToNoNavZones: false, ref UserFeedback, ref AllowBounce);
				method_3(ProvidedPiers);
				nullable_0 = value;
			}
			return nullable_0.Value;
		}

		bool IPathNode<ActiveUnit>.IsWalkable(ActiveUnit inContext)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IsWalkable
			return this.IsWalkable(inContext);
		}

		public void method_4()
		{
			nullable_0 = false;
		}

		public Class17(double double_2, double double_3)
		{
			float_0 = 0f;
			double_0 = double_2;
			double_1 = double_3;
		}

		static Class17()
		{
			Class72.smethod_20();
		}
	}

	private sealed class Class18 : IPathNode<ActiveUnit>
	{
		public double double_0;

		public double double_1;

		private bool? nullable_0;

		private short? nullable_1;

		private float float_0;

		private List<ActiveUnit> list_0;

		[SpecialName]
		private short method_0(Scenario scenario_0)
		{
			if (Information.IsNothing((object)nullable_1))
			{
				nullable_1 = Terrain.GetElevation(double_0, double_1, RequestIsFromGUI: false, scenario_0);
			}
			return nullable_1.Value;
		}

		[SpecialName]
		public float method_1()
		{
			return float_0;
		}

		[SpecialName]
		public void method_2(float float_1)
		{
			float_0 = float_1;
		}

		[SpecialName]
		public List<ActiveUnit> method_3()
		{
			return list_0;
		}

		[SpecialName]
		public void HcUyptvctBk(List<ActiveUnit> list_1)
		{
			list_0 = list_1;
		}

		internal bool IsWalkable(ActiveUnit inContext)
		{
			if (Information.IsNothing((object)nullable_0))
			{
				double theLat = double_0;
				double theLon = double_1;
				int MovementCost = 0;
				bool CheckNoNavZones = true;
				bool CheckForMines = true;
				short? providedElevation = method_0(inContext.ParentScen);
				List<ActiveUnit> ProvidedPiers = method_3();
				float proximityThreshold_Deg = method_1();
				string UserFeedback = "";
				bool AllowBounce = false;
				bool value = inContext.CanMoveToThisLocation(theLat, theLon, ref MovementCost, IsPathfindingQuery: true, UsePathfindingBufferDistance: true, IgnoreMinesBehindUs: false, ref CheckNoNavZones, CheckForIcepack: true, ref CheckForMines, null, providedElevation, ref ProvidedPiers, proximityThreshold_Deg, CheckIfTargetIsOutsideProsecutionArea: false, CheckDistanceToNoNavZones: false, ref UserFeedback, ref AllowBounce);
				HcUyptvctBk(ProvidedPiers);
				nullable_0 = value;
			}
			return nullable_0.Value;
		}

		bool IPathNode<ActiveUnit>.IsWalkable(ActiveUnit inContext)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IsWalkable
			return this.IsWalkable(inContext);
		}

		public Class18(double double_2, double double_3)
		{
			float_0 = 0f;
			double_0 = double_2;
			double_1 = double_3;
		}

		public void method_4()
		{
			nullable_0 = false;
		}

		static Class18()
		{
			Class72.smethod_20();
		}
	}

	public float DegreeInterval_Coarse => 0.05f;

	public float DegreeInterval_Finegrained => 0.005f;

	internal List<Waypoint> SolvePF_Coarse(ActiveUnit theUnit, double StartLat, double StartLon, double EndLat, double EndLon, float CurrentHeading, float DegreeBuffer, float ProximityThreshold_Deg, ref List<ActiveUnit> ProvidedPiers, ref float PercentComplete, bool IsMissionPlannerRequest, bool AllowFineGrainedNav)
	{
		List<Waypoint> result;
		try
		{
			if (theUnit.ParentScen.ThreadedOpsMustStop)
			{
				result = null;
			}
			else
			{
				bool flag = Math2.LineCrossesAntimeridian(StartLat, StartLon, EndLat, EndLon);
				float num = Math.Min((float)(short)Math.Round(Math.Max(StartLat, EndLat)) + DegreeBuffer, 90f);
				float num2 = Math.Max((float)(short)Math.Round(Math.Min(StartLat, EndLat)) - DegreeBuffer, -90f);
				short num3 = (short)Math.Round(Math.Abs(num - num2) / DegreeInterval_Coarse);
				float num4;
				float num5;
				short num6;
				if (flag)
				{
					num4 = (float)(short)Math.Round(Math.Min(StartLon, EndLon)) + DegreeBuffer;
					num5 = (float)(short)Math.Round(Math.Max(StartLon, EndLon)) - DegreeBuffer;
					num6 = Math.Abs((short)Math.Round((180f - Math.Abs(num4) + (180f - num5)) / DegreeInterval_Coarse));
				}
				else
				{
					num4 = (float)(short)Math.Round(Math.Min(StartLon, EndLon)) - DegreeBuffer;
					num5 = (float)(short)Math.Round(Math.Max(StartLon, EndLon)) + DegreeBuffer;
					num6 = Math.Abs((short)Math.Round(Math.Abs(num5 - num4) / DegreeInterval_Coarse));
				}
				if (num3 == 0)
				{
					num3 = 1;
				}
				if (num6 == 0)
				{
					num6 = 1;
				}
				long num7 = (long)num6 * (long)num3;
				Class17[,] class17_ = new Class17[num6 - 1 + 1, num3 - 1 + 1];
				int num8 = num6 - 1;
				int num9 = 0;
				short? nullable_ = default(short?);
				float num14 = default(float);
				long num15 = default(long);
				short? nullable_2 = default(short?);
				float num21 = default(float);
				short short_ = default(short);
				short short_2 = default(short);
				while (true)
				{
					if (num9 > num8)
					{
						if (!nullable_.HasValue)
						{
							try
							{
								double num10 = double.MaxValue;
								GeoPoint geoPoint = new GeoPoint(StartLon, StartLat);
								float num11 = num - DegreeInterval_Coarse;
								float degreeInterval_Coarse = DegreeInterval_Coarse;
								bool flag2 = degreeInterval_Coarse >= 0f;
								for (float num12 = num2; flag2 ? (num12 <= num11) : (num12 >= num11); num12 += degreeInterval_Coarse)
								{
									double num13 = geoPoint.RangeToPoint_Horiz_Angular(StartLon, num12);
									if (num13 < num10)
									{
										num10 = num13;
										num14 = num15;
									}
								}
								nullable_ = (short)Math.Round(num14);
							}
							catch (Exception ex)
							{
								ProjectData.SetProjectError(ex);
								Exception ex2 = ex;
								ex2?.Data.Add("Error at 999999", "");
								GameGeneral.WriteExceptionsToLog(ex2);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								result = null;
								ProjectData.ClearProjectError();
								break;
							}
						}
						if (!nullable_2.HasValue)
						{
							try
							{
								double num16 = double.MaxValue;
								GeoPoint geoPoint2 = new GeoPoint(StartLon, StartLat);
								float num17 = num4;
								float num18 = num5 - DegreeInterval_Coarse;
								float degreeInterval_Coarse2 = DegreeInterval_Coarse;
								bool flag3 = degreeInterval_Coarse2 >= 0f;
								float num19 = num17;
								while ((!flag3) ? (num19 >= num18) : (num19 <= num18))
								{
									num19 = Math2.NormalizeLongitude(num19);
									double num20 = geoPoint2.RangeToPoint_Horiz_Angular(num19, StartLat);
									if (num20 < num16)
									{
										num16 = num20;
										num21 = num15;
									}
									num19 += degreeInterval_Coarse2;
								}
								nullable_2 = (short)Math.Round(num21);
							}
							catch (Exception ex3)
							{
								ProjectData.SetProjectError(ex3);
								Exception ex4 = ex3;
								ex4?.Data.Add("Error at 999999", "");
								GameGeneral.WriteExceptionsToLog(ex4);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								result = null;
								ProjectData.ClearProjectError();
								break;
							}
						}
						method_0(ref theUnit, ref nullable_2, ref nullable_, ref short_, ref short_2, ref class17_, null, num6, num3);
						if (class17_[nullable_2.Value, nullable_.Value].IsWalkable(theUnit))
						{
							if (class17_[short_, short_2].IsWalkable(theUnit))
							{
								LinkedList<Class17> linkedList = new SpatialAStar<Class17, ActiveUnit>(class17_).Search(new Point(nullable_2.Value, nullable_.Value), new Point(short_, short_2), theUnit);
								class17_ = null;
								if (Information.IsNothing((object)linkedList))
								{
									result = null;
									break;
								}
								List<Waypoint> list = new List<Waypoint>();
								foreach (Class17 item in linkedList)
								{
									list.Add(new Waypoint(item.double_1, item.double_0, 0f, Waypoint.WaypointType.PathfindingPoint, Waypoint.WaypointCreator.Pathfinder, Waypoint.WaypointCategory.PlottedCourse));
								}
								result = list;
							}
							else
							{
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								result = null;
							}
						}
						else
						{
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							result = null;
						}
						break;
					}
					double num22 = (flag ? ((double)Math2.NormalizeLongitude(num4 - (float)num9 * DegreeInterval_Coarse)) : ((double)Math2.NormalizeLongitude(num4 + (float)num9 * DegreeInterval_Coarse)));
					int num23 = num3 - 1;
					int num24 = 0;
					while (true)
					{
						if (num24 <= num23)
						{
							if (!theUnit.ParentScen.ThreadedOpsMustStop)
							{
								double num25 = Math2.NormalizeLatitude(num2 + (float)num24 * DegreeInterval_Coarse);
								Class17 @class = new Class17(num25, num22);
								@class.XiHykbBsju8(ProximityThreshold_Deg);
								@class.method_3(ProvidedPiers);
								if (IsMissionPlannerRequest || !theUnit.IsMorituri)
								{
									if (@class.IsWalkable(theUnit))
									{
										if (Math.Abs(StartLon - num22) < (double)DegreeInterval_Coarse && (!nullable_2.HasValue || Math.Abs(MathFunctions.AngularDifference(CurrentHeading, Math2.CalcAzimuth(StartLat, StartLon, num25, num22))) < 90f))
										{
											nullable_2 = (short)num9;
										}
										if (Math.Abs(EndLon - num22) < (double)DegreeInterval_Coarse)
										{
											short_ = (short)num9;
										}
										if (Math.Abs(StartLat - num25) < (double)DegreeInterval_Coarse && (!nullable_.HasValue || Math.Abs(MathFunctions.AngularDifference(CurrentHeading, Math2.CalcAzimuth(StartLat, StartLon, num25, num22))) < 90f))
										{
											nullable_ = (short)num24;
										}
										if (Math.Abs(EndLat - num25) < (double)DegreeInterval_Coarse)
										{
											short_2 = (short)num24;
										}
									}
									class17_[num9, num24] = @class;
									num15++;
									num24++;
									continue;
								}
								result = null;
								goto end_IL_02d2;
							}
							result = null;
							goto end_IL_02d2;
						}
						PercentComplete = (float)((double)num15 / (double)num7);
						num9++;
						break;
					}
					continue;
					end_IL_02d2:
					break;
				}
			}
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			ex6?.Data.Add("Error at 101112", "");
			GameGeneral.WriteExceptionsToLog(ex6);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	List<Waypoint> GInterface1.SolvePF_Coarse(ActiveUnit theUnit, double StartLat, double StartLon, double EndLat, double EndLon, float CurrentHeading, float DegreeBuffer, float ProximityThreshold_Deg, ref List<ActiveUnit> ProvidedPiers, ref float PercentComplete, bool IsMissionPlannerRequest, bool AllowFineGrainedNav)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SolvePF_Coarse
		return this.SolvePF_Coarse(theUnit, StartLat, StartLon, EndLat, EndLon, CurrentHeading, DegreeBuffer, ProximityThreshold_Deg, ref ProvidedPiers, ref PercentComplete, IsMissionPlannerRequest, AllowFineGrainedNav);
	}

	internal List<Waypoint> SolvePF_Finegrained(ActiveUnit theUnit, double StartLat, double StartLon, double EndLat, double EndLon, float CurrentHeading, float DegreeBuffer, float ProximityThreshold_Deg, ref List<ActiveUnit> ProvidedPiers, ref float PercentComplete, bool IsMissionPlannerRequest)
	{
		List<Waypoint> result;
		try
		{
			if (theUnit.ParentScen.ThreadedOpsMustStop)
			{
				result = null;
			}
			else
			{
				float num = (float)Math.Min(Math.Max(StartLat, EndLat) + (double)DegreeBuffer, 90.0);
				float num2 = (float)Math.Max(Math.Min(StartLat, EndLat) - (double)DegreeBuffer, -90.0);
				float num3 = (float)Math.Max(Math.Min(StartLon, EndLon) - (double)DegreeBuffer, -180.0);
				float num4 = (float)Math.Min(Math.Max(StartLon, EndLon) + (double)DegreeBuffer, 180.0);
				short num5 = (short)Math.Round(Math.Abs(num - num2) / DegreeInterval_Finegrained);
				short num6 = (short)Math.Round(Math.Abs(num4 - num3) / DegreeInterval_Finegrained);
				if (num5 == 0)
				{
					num5 = 1;
				}
				if (num6 == 0)
				{
					num6 = 1;
				}
				long num7 = (long)num6 * (long)num5;
				Class18[,] array = new Class18[num6 - 1 + 1, num5 - 1 + 1];
				List<Class18> list = new List<Class18>();
				int num8 = num6 - 1;
				int num9 = 0;
				short? nullable_ = default(short?);
				short short_ = default(short);
				short? nullable_2 = default(short?);
				short short_2 = default(short);
				long num14 = default(long);
				float num19 = default(float);
				float num24 = default(float);
				LinkedList<Class18> linkedList = default(LinkedList<Class18>);
				while (true)
				{
					if (num9 <= num8)
					{
						double num10 = Math2.NormalizeLongitude(num3 + (float)num9 * DegreeInterval_Finegrained);
						int num11 = num5 - 1;
						int num12 = 0;
						while (true)
						{
							if (num12 <= num11)
							{
								if (!theUnit.ParentScen.ThreadedOpsMustStop)
								{
									double num13 = Math2.NormalizeLatitude(num2 + (float)num12 * DegreeInterval_Finegrained);
									Class18 @class = new Class18(num13, num10);
									@class.method_2(ProximityThreshold_Deg);
									@class.HcUyptvctBk(ProvidedPiers);
									if (@class.IsWalkable(theUnit))
									{
										if (Math.Abs(StartLon - num10) < (double)DegreeInterval_Finegrained && (!nullable_.HasValue || Math.Abs(MathFunctions.AngularDifference(CurrentHeading, Math2.CalcAzimuth(StartLat, StartLon, num13, num10))) < 90f))
										{
											nullable_ = (short)num9;
										}
										if (Math.Abs(EndLon - num10) < (double)DegreeInterval_Finegrained)
										{
											short_ = (short)num9;
										}
										if (Math.Abs(StartLat - num13) < (double)DegreeInterval_Finegrained && (!nullable_2.HasValue || Math.Abs(MathFunctions.AngularDifference(CurrentHeading, Math2.CalcAzimuth(StartLat, StartLon, num13, num10))) < 90f))
										{
											nullable_2 = (short)num12;
										}
										if (Math.Abs(EndLat - num13) < (double)DegreeInterval_Finegrained)
										{
											short_2 = (short)num12;
										}
									}
									array[num9, num12] = @class;
									list.Add(@class);
									num14++;
									num12++;
									continue;
								}
								result = null;
								goto end_IL_0266;
							}
							PercentComplete = (float)((double)num14 / (double)num7);
							num9++;
							break;
						}
						continue;
					}
					if (!nullable_2.HasValue)
					{
						try
						{
							double num15 = double.MaxValue;
							GeoPoint geoPoint = new GeoPoint(StartLon, StartLat);
							float num16 = num;
							float degreeInterval_Coarse = DegreeInterval_Coarse;
							bool flag = degreeInterval_Coarse >= 0f;
							for (float num17 = num2; (!flag) ? (num17 >= num16) : (num17 <= num16); num17 += degreeInterval_Coarse)
							{
								double num18 = geoPoint.RangeToPoint_Horiz_Angular(StartLon, num17);
								if (num18 < num15)
								{
									num15 = num18;
									num19 = num14;
								}
							}
							nullable_2 = (short)Math.Round(num19);
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception ex2 = ex;
							ex2?.Data.Add("Error at 999999", "");
							GameGeneral.WriteExceptionsToLog(ex2);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							result = null;
							ProjectData.ClearProjectError();
							break;
						}
					}
					if (!nullable_.HasValue)
					{
						try
						{
							double num20 = double.MaxValue;
							GeoPoint geoPoint2 = new GeoPoint(StartLon, StartLat);
							float num21 = num4 - DegreeInterval_Finegrained;
							float degreeInterval_Finegrained = DegreeInterval_Finegrained;
							bool flag2 = degreeInterval_Finegrained >= 0f;
							float num22 = num3;
							while ((!flag2) ? (num22 >= num21) : (num22 <= num21))
							{
								num22 = Math2.NormalizeLongitude(num22);
								double num23 = geoPoint2.RangeToPoint_Horiz_Angular(num22, StartLat);
								if (num23 < num20)
								{
									num20 = num23;
									num24 = num14;
								}
								num14++;
								num22 += degreeInterval_Finegrained;
							}
							nullable_ = (short)Math.Round(num24);
						}
						catch (Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							Exception ex4 = ex3;
							ex4?.Data.Add("Error at 999999", "");
							GameGeneral.WriteExceptionsToLog(ex4);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							result = null;
							ProjectData.ClearProjectError();
							break;
						}
					}
					Class17[,] class17_ = null;
					method_0(ref theUnit, ref nullable_, ref nullable_2, ref short_, ref short_2, ref class17_, array, num6, num5);
					if (!array[nullable_.Value, nullable_2.Value].IsWalkable(theUnit))
					{
						result = null;
					}
					else if (array[short_, short_2].IsWalkable(theUnit))
					{
						SpatialAStar<Class18, ActiveUnit> spatialAStar = new SpatialAStar<Class18, ActiveUnit>(array);
						try
						{
							linkedList = spatialAStar.Search(new Point(nullable_.Value, nullable_2.Value), new Point(short_, short_2), theUnit);
						}
						catch (Exception ex5)
						{
							ProjectData.SetProjectError(ex5);
							Exception ex6 = ex5;
							ex6?.Data.Add("Error at 200096", ex6.Message);
							GameGeneral.WriteExceptionsToLog(ex6);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
						array = null;
						spatialAStar = null;
						if (!Information.IsNothing((object)linkedList))
						{
							List<Waypoint> list2 = new List<Waypoint>();
							foreach (Class18 item in linkedList)
							{
								list2.Add(new Waypoint(item.double_1, item.double_0, 0f, Waypoint.WaypointType.PathfindingPoint, Waypoint.WaypointCreator.Pathfinder, Waypoint.WaypointCategory.PlottedCourse));
							}
							result = list2;
						}
						else
						{
							result = null;
						}
					}
					else
					{
						result = null;
					}
					break;
					continue;
					end_IL_0266:
					break;
				}
			}
		}
		catch (Exception ex7)
		{
			ProjectData.SetProjectError(ex7);
			Exception ex8 = ex7;
			ex8?.Data.Add("Error at 101111", "");
			GameGeneral.WriteExceptionsToLog(ex8);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	List<Waypoint> GInterface1.SolvePF_Finegrained(ActiveUnit theUnit, double StartLat, double StartLon, double EndLat, double EndLon, float CurrentHeading, float DegreeBuffer, float ProximityThreshold_Deg, ref List<ActiveUnit> ProvidedPiers, ref float PercentComplete, bool IsMissionPlannerRequest)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SolvePF_Finegrained
		return this.SolvePF_Finegrained(theUnit, StartLat, StartLon, EndLat, EndLon, CurrentHeading, DegreeBuffer, ProximityThreshold_Deg, ref ProvidedPiers, ref PercentComplete, IsMissionPlannerRequest);
	}

	private void method_0(ref ActiveUnit activeUnit_0, ref short? nullable_0, ref short? nullable_1, ref short short_0, ref short short_1, ref Class17[,] class17_0, Class18[,] class18_0, short short_2, short short_3)
	{
		bool flag = false;
		bool flag2 = false;
		short num = 1;
		short num2 = 1;
		short num3 = 0;
		short num4 = 0;
		short num5 = nullable_0.Value;
		short num6 = nullable_1.Value;
		short num7 = short_0;
		short num8 = short_1;
		int num9 = 0;
		int num10 = Math.Min(short_2, short_3);
		try
		{
			do
			{
				if (!flag)
				{
					int num11 = 0;
					if (!Information.IsNothing((object)class17_0) && class17_0[nullable_0.Value, nullable_1.Value].IsWalkable(activeUnit_0))
					{
						if (num6 != short_3 - 1 && class17_0[num5, num6 + 1].IsWalkable(activeUnit_0))
						{
							num11++;
						}
						if (num6 != 0 && class17_0[num5, num6 - 1].IsWalkable(activeUnit_0))
						{
							num11++;
						}
						if (num5 != 0 && class17_0[num5 - 1, num6].IsWalkable(activeUnit_0))
						{
							num11++;
						}
						if (num5 != short_2 - 1 && class17_0[num5 + 1, num6].IsWalkable(activeUnit_0))
						{
							num11++;
						}
					}
					else if (!Information.IsNothing((object)class18_0) && class18_0[nullable_0.Value, nullable_1.Value].IsWalkable(activeUnit_0))
					{
						if (num6 != short_3 - 1 && class18_0[num5, num6 + 1].IsWalkable(activeUnit_0))
						{
							num11++;
						}
						if (num6 != 0 && class18_0[num5, num6 - 1].IsWalkable(activeUnit_0))
						{
							num11++;
						}
						if (num5 != 0 && class18_0[num5 - 1, num6].IsWalkable(activeUnit_0))
						{
							num11++;
						}
						if (num5 != short_2 - 1 && class18_0[num5 + 1, num6].IsWalkable(activeUnit_0))
						{
							num11++;
						}
					}
					if (num11 > 0)
					{
						flag = true;
					}
					else
					{
						if (!Information.IsNothing((object)class17_0))
						{
							class17_0[num5, num6].method_4();
						}
						if (!Information.IsNothing((object)class18_0))
						{
							class18_0[num5, num6].method_4();
						}
						double num12 = double.MaxValue;
						short num13 = (short)(num * 2 + 1);
						num3 = 0;
						short num14 = (short)((num == 1) ? 1 : ((short)Math.Round((double)(num13 + 1) / 2.0)));
						short num15 = (short)(nullable_0.Value - num);
						short num16 = (short)(nullable_1.Value - num);
						short num17 = (short)(num13 - 1);
						for (short num18 = 0; num18 <= num17; num18++)
						{
							short num19 = (short)(num15 + num18);
							if (num19 >= 0 && num19 <= short_2 - 1)
							{
								short num20 = (short)(num13 - 1);
								for (short num21 = 0; num21 <= num20; num21++)
								{
									if (activeUnit_0.ParentScen.ThreadedOpsMustStop)
									{
										return;
									}
									short num22 = (short)(num16 + num21);
									if (num22 >= 0 && num22 <= short_3 - 1 && (num18 == 0 || num18 == num13 - 1 || num21 == 0 || num21 == num13 - 1) && ((!Information.IsNothing((object)class17_0) && class17_0[num19, num22].IsWalkable(activeUnit_0)) || (!Information.IsNothing((object)class18_0) && class18_0[num19, num22].IsWalkable(activeUnit_0))))
									{
										double num23 = Math.Min(Math.Abs((short)(num18 - num14)), Math.Abs((short)(num21 - num14)));
										if (num23 < num12)
										{
											num12 = num23;
											num5 = num19;
											num6 = num22;
										}
										num3++;
									}
								}
							}
						}
						nullable_0 = num5;
						nullable_1 = num6;
						if (num3 == 0)
						{
							num++;
						}
					}
				}
				if (!flag2)
				{
					int num24 = 0;
					if (!Information.IsNothing((object)class17_0) && class17_0[short_0, short_1].IsWalkable(activeUnit_0))
					{
						if (num8 != short_3 - 1 && class17_0[num7, num8 + 1].IsWalkable(activeUnit_0))
						{
							num24++;
						}
						if (num8 != 0 && class17_0[num7, num8 - 1].IsWalkable(activeUnit_0))
						{
							num24++;
						}
						if (num7 != 0 && class17_0[num7 - 1, num8].IsWalkable(activeUnit_0))
						{
							num24++;
						}
						if (num7 != short_2 - 1 && class17_0[num7 + 1, num8].IsWalkable(activeUnit_0))
						{
							num24++;
						}
					}
					else if (!Information.IsNothing((object)class18_0) && class18_0[short_0, short_1].IsWalkable(activeUnit_0))
					{
						if (num8 != short_3 - 1 && class18_0[num7, num8 + 1].IsWalkable(activeUnit_0))
						{
							num24++;
						}
						if (num8 != 0 && class18_0[num7, num8 - 1].IsWalkable(activeUnit_0))
						{
							num24++;
						}
						if (num7 != 0 && class18_0[num7 - 1, num8].IsWalkable(activeUnit_0))
						{
							num24++;
						}
						if (num7 != short_2 - 1 && class18_0[num7 + 1, num8].IsWalkable(activeUnit_0))
						{
							num24++;
						}
					}
					if (num24 > 0)
					{
						flag2 = true;
					}
					else
					{
						if (!Information.IsNothing((object)class17_0))
						{
							class17_0[num7, num8].method_4();
						}
						if (!Information.IsNothing((object)class18_0))
						{
							class18_0[num7, num8].method_4();
						}
						double num25 = double.MaxValue;
						short num26 = (short)(num * 2 + 1);
						num4 = 0;
						short num27 = (short)((num2 == 1) ? 1 : ((short)Math.Round((double)(num26 + 1) / 2.0)));
						short num28 = (short)(short_0 - num2);
						short num29 = (short)(short_1 - num2);
						short num30 = (short)(num26 - 1);
						for (short num31 = 0; num31 <= num30; num31++)
						{
							short num32 = (short)(num28 + num31);
							if (num32 >= 0 && num32 <= short_2 - 1)
							{
								short num33 = (short)(num26 - 1);
								for (short num34 = 0; num34 <= num33; num34++)
								{
									if (activeUnit_0.ParentScen.ThreadedOpsMustStop)
									{
										return;
									}
									short num35 = (short)(num29 + num34);
									if (num35 >= 0 && num35 <= short_3 - 1 && (num31 == 0 || num31 == num26 - 1 || num34 == 0 || num34 == num26 - 1) && ((!Information.IsNothing((object)class17_0) && class17_0[num32, num35].IsWalkable(activeUnit_0)) || (!Information.IsNothing((object)class18_0) && class18_0[num32, num35].IsWalkable(activeUnit_0))))
									{
										double num36 = Math.Min(Math.Abs((short)(num31 - num27)), Math.Abs((short)(num34 - num27)));
										if (num36 < num25)
										{
											num25 = num36;
											num7 = num32;
											num8 = num35;
										}
										num4++;
									}
								}
							}
						}
						short_0 = num7;
						short_1 = num8;
						if (num4 == 0)
						{
							num2++;
						}
					}
				}
				if (!flag || !flag2)
				{
					num9++;
					continue;
				}
				break;
			}
			while (num10 != num9);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101267", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	static SettlersEnginePathfinder()
	{
		Class72.smethod_20();
	}
}
