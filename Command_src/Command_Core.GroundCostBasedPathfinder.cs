using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using Algorithms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class GroundCostBasedPathfinder : GInterface1
{
	private sealed class Class10
	{
		public double double_0;

		public double double_1;

		private bool? nullable_0;

		private short? nullable_1;

		private int int_0;

		private List<ActiveUnit> list_0;

		private float float_0;

		[SpecialName]
		public short method_0(Scenario scenario_0)
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
		public void method_4(List<ActiveUnit> list_1)
		{
			list_0 = list_1;
		}

		[SpecialName]
		public int method_5()
		{
			return int_0;
		}

		[SpecialName]
		public void method_6(int int_1)
		{
			int_0 = int_1;
		}

		internal bool method_7(ActiveUnit activeUnit_0)
		{
			if (!nullable_0.HasValue)
			{
				double theLat = double_0;
				double theLon = double_1;
				int MovementCost = method_5();
				bool CheckNoNavZones = true;
				bool CheckForMines = true;
				short? providedElevation = method_0(activeUnit_0.ParentScen);
				List<ActiveUnit> ProvidedPiers = method_3();
				float proximityThreshold_Deg = method_1();
				string UserFeedback = "";
				bool AllowBounce = false;
				bool value = activeUnit_0.CanMoveToThisLocation(theLat, theLon, ref MovementCost, IsPathfindingQuery: true, UsePathfindingBufferDistance: true, IgnoreMinesBehindUs: false, ref CheckNoNavZones, CheckForIcepack: true, ref CheckForMines, null, providedElevation, ref ProvidedPiers, proximityThreshold_Deg, CheckIfTargetIsOutsideProsecutionArea: false, CheckDistanceToNoNavZones: false, ref UserFeedback, ref AllowBounce);
				method_4(ProvidedPiers);
				method_6(MovementCost);
				nullable_0 = value;
			}
			return nullable_0.Value;
		}

		public void method_8()
		{
			nullable_0 = false;
		}

		public Class10(double double_2, double double_3)
		{
			float_0 = 0f;
			double_0 = double_2;
			double_1 = double_3;
		}

		static Class10()
		{
			Class72.smethod_20();
		}
	}

	private sealed class Class11
	{
		public double double_0;

		public double double_1;

		private bool? nullable_0;

		private short? nullable_1;

		public int int_0;

		private float float_0;

		private List<ActiveUnit> list_0;

		[SpecialName]
		public void method_0(float float_1)
		{
			float_0 = float_1;
		}

		[SpecialName]
		public void method_1(List<ActiveUnit> list_1)
		{
			list_0 = list_1;
		}

		internal bool method_2(ActiveUnit activeUnit_0)
		{
			if (!nullable_0.HasValue)
			{
				if (!nullable_1.HasValue)
				{
					nullable_1 = Terrain.GetElevation(double_0, double_1, RequestIsFromGUI: false, activeUnit_0.ParentScen);
				}
				double theLat = double_0;
				double theLon = double_1;
				ref int movementCost = ref int_0;
				bool CheckNoNavZones = true;
				bool CheckForMines = true;
				short? providedElevation = nullable_1;
				ref List<ActiveUnit> providedPiers = ref list_0;
				float proximityThreshold_Deg = float_0;
				string UserFeedback = "";
				bool AllowBounce = false;
				nullable_0 = activeUnit_0.CanMoveToThisLocation(theLat, theLon, ref movementCost, IsPathfindingQuery: true, UsePathfindingBufferDistance: true, IgnoreMinesBehindUs: false, ref CheckNoNavZones, CheckForIcepack: true, ref CheckForMines, null, providedElevation, ref providedPiers, proximityThreshold_Deg, CheckIfTargetIsOutsideProsecutionArea: false, CheckDistanceToNoNavZones: false, ref UserFeedback, ref AllowBounce);
			}
			return nullable_0.Value;
		}

		public Class11(double double_2, double double_3)
		{
			float_0 = 0f;
			double_0 = double_2;
			double_1 = double_3;
		}

		public void method_3()
		{
			nullable_0 = false;
		}

		static Class11()
		{
			Class72.smethod_20();
		}
	}

	public const int MAX_PATHGRID_ALLOCATE = 4096;

	public const float DEGREE_INTERVAL_COARSE = 0.05f;

	public const float DEGREE_INTERVAL_FINE = 0.025f;

	public const double MAX_SOLVABLE_DEGREES = 102.4000015258789;

	public const int MIN_INTERCONTINENTAL_CHECK = 1800;

	public float DegreeInterval_Coarse => 0.05f;

	public float DegreeInterval_Finegrained => 0.025f;

	public static bool CanSolve(double startLat, double startLon, double endLat, double endLon)
	{
		if (!Math2.LineCrossesAntimeridian(startLat, startLon, endLat, endLon))
		{
			return Math.Abs(startLat - endLat) <= 102.4000015258789 && Math.Abs(startLon - endLon) <= 102.4000015258789;
		}
		if (startLon > 0.0)
		{
			return Math.Abs(startLat - endLat) <= 102.4000015258789 && Math.Abs(180.0 - startLon + (180.0 + endLon)) <= 102.4000015258789;
		}
		return Math.Abs(startLat - endLat) <= 102.4000015258789 && Math.Abs(180.0 - endLon + (180.0 + startLon)) <= 102.4000015258789;
	}

	internal List<Waypoint> SolvePF_Coarse(ActiveUnit theUnit, double StartLat, double StartLon, double EndLat, double EndLon, float CurrentHeading, float DegreeBuffer, float ProximityThreshold_Deg, ref List<ActiveUnit> ProvidedPiers, ref float PercentComplete, bool IsMissionPlannerRequest, bool AllowFineGrainedNav)
	{
		throw new Exception();
	}

	List<Waypoint> GInterface1.SolvePF_Coarse(ActiveUnit theUnit, double StartLat, double StartLon, double EndLat, double EndLon, float CurrentHeading, float DegreeBuffer, float ProximityThreshold_Deg, ref List<ActiveUnit> ProvidedPiers, ref float PercentComplete, bool IsMissionPlannerRequest, bool AllowFineGrainedNav)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SolvePF_Coarse
		return this.SolvePF_Coarse(theUnit, StartLat, StartLon, EndLat, EndLon, CurrentHeading, DegreeBuffer, ProximityThreshold_Deg, ref ProvidedPiers, ref PercentComplete, IsMissionPlannerRequest, AllowFineGrainedNav);
	}

	private bool method_0(int int_0, double double_0, double double_1, double double_2, double double_3)
	{
		if (int_0 > 1800)
		{
			if (double_0 < -60.0 && double_2 >= -60.0)
			{
				return true;
			}
			if (double_0 < -10.0 && double_0 > -40.0 && double_1 > 110.0 && double_1 < 160.0)
			{
				int result;
				if (!(double_2 >= -10.0) && !(double_2 <= -40.0) && !(double_3 <= 110.0))
				{
					if (!(double_3 >= 160.0))
					{
						goto IL_0096;
					}
					result = 1;
				}
				else
				{
					result = 1;
				}
				return (byte)result != 0;
			}
			goto IL_0096;
		}
		goto IL_00ed;
		IL_0096:
		if (double_1 > -20.0 && double_1 < 168.5)
		{
			int result2;
			if (!(double_3 > -20.0))
			{
				result2 = 1;
			}
			else
			{
				if (!(double_3 >= 168.5))
				{
					goto IL_00ed;
				}
				result2 = 1;
			}
			return (byte)result2 != 0;
		}
		if (double_3 >= -20.0 && double_3 <= 168.5)
		{
			return true;
		}
		goto IL_00ed;
		IL_00ed:
		return false;
	}

	internal List<Waypoint> SolvePF_Finegrained(ActiveUnit theUnit_, double StartLat, double StartLon, double EndLat, double EndLon, float CurrentHeading, float DegreeBuffer, float ProximityThreshold_Deg, ref List<ActiveUnit> ProvidedPiers, ref float PercentComplete, bool IsMissionPlannerRequest)
	{
		List<Waypoint> result;
		if (!theUnit_.IsFacility)
		{
			Vehicle vehicle_ = (Vehicle)theUnit_;
			try
			{
				if (!vehicle_.ParentScen.ThreadedOpsMustStop)
				{
					bool flag = Math2.LineCrossesAntimeridian(StartLat, StartLon, EndLat, EndLon);
					float num = Math.Min((float)(short)Math.Round(Math.Max(StartLat, EndLat)) + DegreeBuffer, 90f);
					float num2 = Math.Max((float)(short)Math.Round(Math.Min(StartLat, EndLat)) - DegreeBuffer, -90f);
					short num3 = (short)Math.Round(Math.Abs(num - num2) / DegreeInterval_Finegrained);
					float num4;
					float num5;
					short num6;
					if (!flag)
					{
						num4 = (float)(short)Math.Round(Math.Min(StartLon, EndLon)) - DegreeBuffer;
						num5 = (float)(short)Math.Round(Math.Max(StartLon, EndLon)) + DegreeBuffer;
						num6 = Math.Abs((short)Math.Round(Math.Abs(num5 - num4) / DegreeInterval_Finegrained));
					}
					else
					{
						num4 = (float)(short)Math.Round(Math.Min(StartLon, EndLon)) + DegreeBuffer;
						num5 = (float)(short)Math.Round(Math.Max(StartLon, EndLon)) - DegreeBuffer;
						num6 = Math.Abs((short)Math.Round((180f - Math.Abs(num4) + (180f - num5)) / DegreeInterval_Finegrained));
					}
					long num7 = (long)num6 * (long)num3;
					vehicle_.Doctrine.get_LandNavigation(vehicle_.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
					int i;
					for (i = 1; !(Math.Pow(2.0, i) > (double)num3) || !(Math.Pow(2.0, i) > (double)num6); i++)
					{
					}
					int num8 = (int)Math.Round(Math.Pow(2.0, i));
					int num9 = (int)Math.Round(Math.Pow(2.0, i));
					if (num8 <= 4096 && !method_0(num8, StartLat, StartLon, EndLat, EndLon))
					{
						Class11[,] array = new Class11[num9 - 1 + 1, num8 - 1 + 1];
						int num10 = num6 - 1;
						int num11 = 0;
						short? nullable_ = default(short?);
						short? nullable_2 = default(short?);
						short short_ = default(short);
						short short_2 = default(short);
						long num13 = default(long);
						while (true)
						{
							double theLongitude;
							if (num11 > num10)
							{
								if (!nullable_.HasValue)
								{
									try
									{
										double num12 = double.MaxValue;
										GeoPoint geoPoint = new GeoPoint(StartLon, StartLat);
										num13 = 0L;
										float num14 = num;
										float degreeInterval_Finegrained = DegreeInterval_Finegrained;
										bool flag2 = degreeInterval_Finegrained >= 0f;
										for (float num15 = num2; (!flag2) ? (num15 >= num14) : (num15 <= num14); num15 += degreeInterval_Finegrained)
										{
											double num16 = geoPoint.RangeToPoint_Horiz_Angular(StartLon, num15);
											if (num16 < num12)
											{
												num12 = num16;
												nullable_ = (short)num13;
											}
											num13++;
										}
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
										double num17 = double.MaxValue;
										GeoPoint geoPoint2 = new GeoPoint(StartLon, StartLat);
										num13 = 0L;
										float num18 = num4;
										float num19 = num5;
										float degreeInterval_Finegrained2 = DegreeInterval_Finegrained;
										bool flag3 = degreeInterval_Finegrained2 >= 0f;
										float num20 = num18;
										while (flag3 ? (num20 <= num19) : (num20 >= num19))
										{
											num20 = Math2.NormalizeLongitude(num20);
											double num21 = geoPoint2.RangeToPoint_Horiz_Angular(num20, StartLat);
											if (num21 < num17)
											{
												num17 = num21;
												nullable_2 = (short)num13;
											}
											num13++;
											num20 += degreeInterval_Finegrained2;
										}
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
								Class10[,] class10_ = null;
								method_3(ref vehicle_, ref nullable_2, ref nullable_, ref short_, ref short_2, ref class10_, array, num6, num3);
								int[,] array2 = new int[num9 - 1 + 1, num8 - 1 + 1];
								int num22 = num9 - 1;
								for (int j = 0; j <= num22; j++)
								{
									int num23 = num8 - 1;
									for (int k = 0; k <= num23; k++)
									{
										if (!Information.IsNothing((object)array[j, k]))
										{
											array2[j, k] = array[j, k].int_0;
										}
										else
										{
											array2[j, k] = 0;
										}
									}
								}
								List<PathFinderNode> list = new PathFinderFast(array2)
								{
									Formula = HeuristicFormula.Euclidean,
									Diagonals = true,
									HeavyDiagonals = false,
									PunishChangeDirection = true,
									PunishWalkingOnEdge = false,
									TrimAutoNavPoints = true,
									TieBreaker = true,
									SearchLimit = int.MaxValue,
									DebugProgress = false,
									ReopenCloseNodes = true,
									EdgeCost = 0
								}.FindPath(new Point(nullable_2.Value, nullable_.Value), new Point(short_, short_2));
								if (list == null)
								{
									result = null;
									break;
								}
								List<Waypoint> list2 = new List<Waypoint>();
								list.Reverse();
								foreach (PathFinderNode item in list)
								{
									theLongitude = (flag ? ((double)Math2.NormalizeLongitude(num4 - (float)item.X * DegreeInterval_Finegrained)) : ((double)Math2.NormalizeLongitude(num4 + (float)item.X * DegreeInterval_Finegrained)));
									double theLatitude = Math2.NormalizeLatitude(num2 + (float)item.Y * DegreeInterval_Finegrained);
									list2.Add(new Waypoint(theLongitude, theLatitude, 0f, Waypoint.WaypointType.PathfindingPoint, Waypoint.WaypointCreator.Pathfinder, Waypoint.WaypointCategory.PlottedCourse));
								}
								result = list2;
								break;
							}
							theLongitude = (flag ? ((double)Math2.NormalizeLongitude(num4 - (float)num11 * DegreeInterval_Finegrained)) : ((double)Math2.NormalizeLongitude(num4 + (float)num11 * DegreeInterval_Finegrained)));
							int num24 = num3 - 1;
							int num25 = 0;
							while (true)
							{
								if (num25 <= num24)
								{
									if (!vehicle_.ParentScen.ThreadedOpsMustStop)
									{
										if (IsMissionPlannerRequest || !vehicle_.IsMorituri)
										{
											double theLatitude = Math2.NormalizeLatitude(num2 + (float)num25 * DegreeInterval_Finegrained);
											Class11 @class = new Class11(theLatitude, theLongitude);
											@class.method_0(ProximityThreshold_Deg);
											@class.method_1(ProvidedPiers);
											if (!@class.method_2(vehicle_))
											{
												@class.int_0 = 0;
											}
											else
											{
												int maximumSpeed = vehicle_.Kinematics.GetMaximumSpeed();
												int num26 = Convert.ToInt32(vehicle_.Kinematics.GetMaximumSpeed_AtLocation(theLatitude, theLongitude));
												int int_ = ((num26 != 0) ? ((maximumSpeed <= num26) ? 1 : ((int)Math.Round(100.0 * Math.Pow(maximumSpeed - num26, 2.0)))) : 0);
												@class.int_0 = int_;
												if (Math.Abs(StartLon - theLongitude) < (double)DegreeInterval_Finegrained && (!nullable_2.HasValue || Math.Abs(MathFunctions.AngularDifference(CurrentHeading, Math2.CalcAzimuth(StartLat, StartLon, theLatitude, theLongitude))) < 90f))
												{
													nullable_2 = (short)num11;
												}
												if (Math.Abs(EndLon - theLongitude) < (double)DegreeInterval_Finegrained)
												{
													short_ = (short)num11;
												}
												if (Math.Abs(StartLat - theLatitude) < (double)DegreeInterval_Finegrained && (!nullable_.HasValue || Math.Abs(MathFunctions.AngularDifference(CurrentHeading, Math2.CalcAzimuth(StartLat, StartLon, theLatitude, theLongitude))) < 90f))
												{
													nullable_ = (short)num25;
												}
												if (Math.Abs(EndLat - theLatitude) < (double)DegreeInterval_Finegrained)
												{
													short_2 = (short)num25;
												}
											}
											array[num11, num25] = @class;
											num13++;
											num25++;
											continue;
										}
										result = null;
										goto end_IL_03fc;
									}
									result = null;
									goto end_IL_03fc;
								}
								PercentComplete = (float)((double)num13 / (double)num7);
								num11++;
								break;
							}
							continue;
							end_IL_03fc:
							break;
						}
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
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				ex6?.Data.Add("Error at 101334", "");
				GameGeneral.WriteExceptionsToLog(ex6);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = null;
				ProjectData.ClearProjectError();
			}
		}
		else
		{
			Facility facility_ = (Facility)theUnit_;
			try
			{
				if (facility_.ParentScen.ThreadedOpsMustStop)
				{
					result = null;
				}
				else
				{
					bool flag4 = Math2.LineCrossesAntimeridian(StartLat, StartLon, EndLat, EndLon);
					float num27 = Math.Min((float)(short)Math.Round(Math.Max(StartLat, EndLat)) + DegreeBuffer, 90f);
					float num28 = Math.Max((float)(short)Math.Round(Math.Min(StartLat, EndLat)) - DegreeBuffer, -90f);
					short num29 = (short)Math.Round(Math.Abs(num27 - num28) / DegreeInterval_Finegrained);
					float num30;
					float num31;
					short num32;
					if (flag4)
					{
						num30 = (float)(short)Math.Round(Math.Min(StartLon, EndLon)) + DegreeBuffer;
						num31 = (float)(short)Math.Round(Math.Max(StartLon, EndLon)) - DegreeBuffer;
						num32 = Math.Abs((short)Math.Round((180f - Math.Abs(num30) + (180f - num31)) / DegreeInterval_Finegrained));
					}
					else
					{
						num30 = (float)(short)Math.Round(Math.Min(StartLon, EndLon)) - DegreeBuffer;
						num31 = (float)(short)Math.Round(Math.Max(StartLon, EndLon)) + DegreeBuffer;
						num32 = Math.Abs((short)Math.Round(Math.Abs(num31 - num30) / DegreeInterval_Finegrained));
					}
					long num33 = (long)num32 * (long)num29;
					facility_.Doctrine.get_LandNavigation(facility_.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
					int l;
					for (l = 1; !(Math.Pow(2.0, l) > (double)num29) || !(Math.Pow(2.0, l) > (double)num32); l++)
					{
					}
					int num34 = (int)Math.Round(Math.Pow(2.0, l));
					int num35 = (int)Math.Round(Math.Pow(2.0, l));
					if (num34 <= 4096 && !method_0(num34, StartLat, StartLon, EndLat, EndLon))
					{
						Class11[,] array3 = new Class11[num35 - 1 + 1, num34 - 1 + 1];
						int num36 = num32 - 1;
						int num37 = 0;
						short? nullable_3 = default(short?);
						short? nullable_4 = default(short?);
						short short_3 = default(short);
						short short_4 = default(short);
						long num39 = default(long);
						while (true)
						{
							double theLongitude2;
							if (num37 > num36)
							{
								if (!nullable_3.HasValue)
								{
									try
									{
										double num38 = double.MaxValue;
										GeoPoint geoPoint3 = new GeoPoint(StartLon, StartLat);
										num39 = 0L;
										float num40 = num27;
										float degreeInterval_Finegrained3 = DegreeInterval_Finegrained;
										bool flag5 = degreeInterval_Finegrained3 >= 0f;
										for (float num41 = num28; (!flag5) ? (num41 >= num40) : (num41 <= num40); num41 += degreeInterval_Finegrained3)
										{
											double num42 = geoPoint3.RangeToPoint_Horiz_Angular(StartLon, num41);
											if (num42 < num38)
											{
												num38 = num42;
												nullable_3 = (short)num39;
											}
											num39++;
										}
									}
									catch (Exception ex7)
									{
										ProjectData.SetProjectError(ex7);
										Exception ex8 = ex7;
										ex8?.Data.Add("Error at 999999", "");
										GameGeneral.WriteExceptionsToLog(ex8);
										if (Debugger.IsAttached)
										{
											Debugger.Break();
										}
										result = null;
										ProjectData.ClearProjectError();
										break;
									}
								}
								if (!nullable_4.HasValue)
								{
									try
									{
										double num43 = double.MaxValue;
										GeoPoint geoPoint4 = new GeoPoint(StartLon, StartLat);
										num39 = 0L;
										float num44 = num30;
										float num45 = num31;
										float degreeInterval_Finegrained4 = DegreeInterval_Finegrained;
										bool flag6 = degreeInterval_Finegrained4 >= 0f;
										float num46 = num44;
										while ((!flag6) ? (num46 >= num45) : (num46 <= num45))
										{
											num46 = Math2.NormalizeLongitude(num46);
											double num47 = geoPoint4.RangeToPoint_Horiz_Angular(num46, StartLat);
											if (num47 < num43)
											{
												num43 = num47;
												nullable_4 = (short)num39;
											}
											num39++;
											num46 += degreeInterval_Finegrained4;
										}
									}
									catch (Exception ex9)
									{
										ProjectData.SetProjectError(ex9);
										Exception ex10 = ex9;
										ex10?.Data.Add("Error at 999999", "");
										GameGeneral.WriteExceptionsToLog(ex10);
										if (Debugger.IsAttached)
										{
											Debugger.Break();
										}
										result = null;
										ProjectData.ClearProjectError();
										break;
									}
								}
								Class10[,] class10_ = null;
								method_2(ref facility_, ref nullable_4, ref nullable_3, ref short_3, ref short_4, ref class10_, array3, num32, num29);
								int[,] array4 = new int[num35 - 1 + 1, num34 - 1 + 1];
								int num48 = num35 - 1;
								for (int m = 0; m <= num48; m++)
								{
									int num49 = num34 - 1;
									for (int n = 0; n <= num49; n++)
									{
										if (!Information.IsNothing((object)array3[m, n]))
										{
											array4[m, n] = array3[m, n].int_0;
										}
										else
										{
											array4[m, n] = 0;
										}
									}
								}
								List<PathFinderNode> list3 = new PathFinderFast(array4)
								{
									Formula = HeuristicFormula.Euclidean,
									Diagonals = true,
									HeavyDiagonals = false,
									PunishChangeDirection = true,
									PunishWalkingOnEdge = false,
									TrimAutoNavPoints = true,
									TieBreaker = true,
									SearchLimit = int.MaxValue,
									DebugProgress = false,
									ReopenCloseNodes = true,
									EdgeCost = 0
								}.FindPath(new Point(nullable_4.Value, nullable_3.Value), new Point(short_3, short_4));
								if (list3 != null)
								{
									List<Waypoint> list4 = new List<Waypoint>();
									list3.Reverse();
									foreach (PathFinderNode item2 in list3)
									{
										theLongitude2 = (flag4 ? ((double)Math2.NormalizeLongitude(num30 - (float)item2.X * DegreeInterval_Finegrained)) : ((double)Math2.NormalizeLongitude(num30 + (float)item2.X * DegreeInterval_Finegrained)));
										double theLatitude2 = Math2.NormalizeLatitude(num28 + (float)item2.Y * DegreeInterval_Finegrained);
										list4.Add(new Waypoint(theLongitude2, theLatitude2, 0f, Waypoint.WaypointType.PathfindingPoint, Waypoint.WaypointCreator.Pathfinder, Waypoint.WaypointCategory.PlottedCourse));
									}
									result = list4;
								}
								else
								{
									result = null;
								}
								break;
							}
							theLongitude2 = (flag4 ? ((double)Math2.NormalizeLongitude(num30 - (float)num37 * DegreeInterval_Finegrained)) : ((double)Math2.NormalizeLongitude(num30 + (float)num37 * DegreeInterval_Finegrained)));
							int num50 = num29 - 1;
							int num51 = 0;
							while (true)
							{
								if (num51 <= num50)
								{
									if (!facility_.ParentScen.ThreadedOpsMustStop)
									{
										if (IsMissionPlannerRequest || !facility_.IsMorituri)
										{
											double theLatitude2 = Math2.NormalizeLatitude(num28 + (float)num51 * DegreeInterval_Finegrained);
											Class11 class2 = new Class11(theLatitude2, theLongitude2);
											class2.method_0(ProximityThreshold_Deg);
											class2.method_1(ProvidedPiers);
											if (!class2.method_2(facility_))
											{
												class2.int_0 = 0;
											}
											else
											{
												int maximumSpeed2 = facility_.Kinematics.GetMaximumSpeed();
												int maximumSpeedAtThisLocation = facility_.Kinematics.GetMaximumSpeedAtThisLocation(theLatitude2, theLongitude2, MinimumBounceSpeed: false);
												int int_2 = ((maximumSpeedAtThisLocation != 0) ? ((maximumSpeed2 <= maximumSpeedAtThisLocation) ? 1 : ((int)Math.Round(100.0 * Math.Pow(maximumSpeed2 - maximumSpeedAtThisLocation, 2.0)))) : 0);
												class2.int_0 = int_2;
												if (Math.Abs(StartLon - theLongitude2) < (double)DegreeInterval_Finegrained && (!nullable_4.HasValue || Math.Abs(MathFunctions.AngularDifference(CurrentHeading, Math2.CalcAzimuth(StartLat, StartLon, theLatitude2, theLongitude2))) < 90f))
												{
													nullable_4 = (short)num37;
												}
												if (Math.Abs(EndLon - theLongitude2) < (double)DegreeInterval_Finegrained)
												{
													short_3 = (short)num37;
												}
												if (Math.Abs(StartLat - theLatitude2) < (double)DegreeInterval_Finegrained && (!nullable_3.HasValue || Math.Abs(MathFunctions.AngularDifference(CurrentHeading, Math2.CalcAzimuth(StartLat, StartLon, theLatitude2, theLongitude2))) < 90f))
												{
													nullable_3 = (short)num51;
												}
												if (Math.Abs(EndLat - theLatitude2) < (double)DegreeInterval_Finegrained)
												{
													short_4 = (short)num51;
												}
											}
											array3[num37, num51] = class2;
											num39++;
											num51++;
											continue;
										}
										result = null;
										goto end_IL_0bea;
									}
									result = null;
									goto end_IL_0bea;
								}
								PercentComplete = (float)((double)num39 / (double)num33);
								num37++;
								break;
							}
							continue;
							end_IL_0bea:
							break;
						}
					}
					else
					{
						result = null;
					}
				}
			}
			catch (Exception ex11)
			{
				ProjectData.SetProjectError(ex11);
				Exception ex12 = ex11;
				ex12?.Data.Add("Error at 101334", "");
				GameGeneral.WriteExceptionsToLog(ex12);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = null;
				ProjectData.ClearProjectError();
			}
		}
		return result;
	}

	List<Waypoint> GInterface1.SolvePF_Finegrained(ActiveUnit theUnit_, double StartLat, double StartLon, double EndLat, double EndLon, float CurrentHeading, float DegreeBuffer, float ProximityThreshold_Deg, ref List<ActiveUnit> ProvidedPiers, ref float PercentComplete, bool IsMissionPlannerRequest)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SolvePF_Finegrained
		return this.SolvePF_Finegrained(theUnit_, StartLat, StartLon, EndLat, EndLon, CurrentHeading, DegreeBuffer, ProximityThreshold_Deg, ref ProvidedPiers, ref PercentComplete, IsMissionPlannerRequest);
	}

	private void method_1(ref Class11[,] class11_0, int int_0, int int_1, int int_2, int int_3, int int_4, int int_5)
	{
		try
		{
			if (int_1 > 0 && class11_0[int_0, int_1 - 1].int_0 == int_2)
			{
				class11_0[int_0, int_1].int_0 = int_3;
			}
			else if (int_1 > 0 && int_0 < int_4 - 1 && class11_0[int_0 + 1, int_1 - 1].int_0 == int_2)
			{
				class11_0[int_0, int_1].int_0 = int_3;
			}
			else if (int_0 < int_4 - 1 && class11_0[int_0 + 1, int_1].int_0 == int_2)
			{
				class11_0[int_0, int_1].int_0 = int_3;
			}
			else if (int_1 < int_5 - 1 && int_0 < int_4 - 1 && class11_0[int_0 + 1, int_1 + 1].int_0 == int_2)
			{
				class11_0[int_0, int_1].int_0 = int_3;
			}
			else if (int_1 < int_5 - 1 && class11_0[int_0, int_1 + 1].int_0 == int_2)
			{
				class11_0[int_0, int_1].int_0 = int_3;
			}
			else if (int_1 < int_5 - 1 && int_0 > 0 && class11_0[int_0 - 1, int_1 + 1].int_0 == int_2)
			{
				class11_0[int_0, int_1].int_0 = int_3;
			}
			else if (int_0 > 0 && class11_0[int_0 - 1, int_1].int_0 == int_2)
			{
				class11_0[int_0, int_1].int_0 = int_3;
			}
			else if (int_1 > 0 && int_0 > 0 && class11_0[int_0 - 1, int_1 - 1].int_0 == int_2)
			{
				class11_0[int_0, int_1].int_0 = int_3;
			}
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
			ProjectData.ClearProjectError();
		}
	}

	private void method_2(ref Facility facility_0, ref short? nullable_0, ref short? nullable_1, ref short short_0, ref short short_1, ref Class10[,] class10_0, Class11[,] class11_0, short short_2, short short_3)
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
					if (!Information.IsNothing((object)class10_0) && class10_0[nullable_0.Value, nullable_1.Value].method_7(facility_0))
					{
						if (num6 != short_3 - 1 && class10_0[num5, num6 + 1].method_7(facility_0))
						{
							num11++;
						}
						if (num6 != 0 && class10_0[num5, num6 - 1].method_7(facility_0))
						{
							num11++;
						}
						if (num5 != 0 && class10_0[num5 - 1, num6].method_7(facility_0))
						{
							num11++;
						}
						if (num5 != short_2 - 1 && class10_0[num5 + 1, num6].method_7(facility_0))
						{
							num11++;
						}
					}
					else if (!Information.IsNothing((object)class11_0) && class11_0[nullable_0.Value, nullable_1.Value].method_2(facility_0))
					{
						if (num6 != short_3 - 1 && class11_0[num5, num6 + 1].method_2(facility_0))
						{
							num11++;
						}
						if (num6 != 0 && class11_0[num5, num6 - 1].method_2(facility_0))
						{
							num11++;
						}
						if (num5 != 0 && class11_0[num5 - 1, num6].method_2(facility_0))
						{
							num11++;
						}
						if (num5 != short_2 - 1 && class11_0[num5 + 1, num6].method_2(facility_0))
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
						if (!Information.IsNothing((object)class10_0))
						{
							class10_0[num5, num6].method_8();
						}
						if (!Information.IsNothing((object)class11_0))
						{
							class11_0[num5, num6].method_3();
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
									if (facility_0.ParentScen.ThreadedOpsMustStop)
									{
										return;
									}
									short num22 = (short)(num16 + num21);
									if (num22 >= 0 && num22 <= short_3 - 1 && (num18 == 0 || num18 == num13 - 1 || num21 == 0 || num21 == num13 - 1) && ((!Information.IsNothing((object)class10_0) && class10_0[num19, num22].method_7(facility_0)) || (!Information.IsNothing((object)class11_0) && class11_0[num19, num22].method_2(facility_0))))
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
					if (!Information.IsNothing((object)class10_0) && class10_0[short_0, short_1].method_7(facility_0))
					{
						if (num8 != short_3 - 1 && class10_0[num7, num8 + 1].method_7(facility_0))
						{
							num24++;
						}
						if (num8 != 0 && class10_0[num7, num8 - 1].method_7(facility_0))
						{
							num24++;
						}
						if (num7 != 0 && class10_0[num7 - 1, num8].method_7(facility_0))
						{
							num24++;
						}
						if (num7 != short_2 - 1 && class10_0[num7 + 1, num8].method_7(facility_0))
						{
							num24++;
						}
					}
					else if (!Information.IsNothing((object)class11_0) && class11_0[short_0, short_1].method_2(facility_0))
					{
						if (num8 != short_3 - 1 && class11_0[num7, num8 + 1].method_2(facility_0))
						{
							num24++;
						}
						if (num8 != 0 && class11_0[num7, num8 - 1].method_2(facility_0))
						{
							num24++;
						}
						if (num7 != 0 && class11_0[num7 - 1, num8].method_2(facility_0))
						{
							num24++;
						}
						if (num7 != short_2 - 1 && class11_0[num7 + 1, num8].method_2(facility_0))
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
						if (!Information.IsNothing((object)class10_0))
						{
							class10_0[num7, num8].method_8();
						}
						if (!Information.IsNothing((object)class11_0))
						{
							class11_0[num7, num8].method_3();
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
									if (facility_0.ParentScen.ThreadedOpsMustStop)
									{
										return;
									}
									short num35 = (short)(num29 + num34);
									if (num35 >= 0 && num35 <= short_3 - 1 && (num31 == 0 || num31 == num26 - 1 || num34 == 0 || num34 == num26 - 1) && ((!Information.IsNothing((object)class10_0) && class10_0[num32, num35].method_7(facility_0)) || (!Information.IsNothing((object)class11_0) && class11_0[num32, num35].method_2(facility_0))))
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
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_3(ref Vehicle vehicle_0, ref short? nullable_0, ref short? nullable_1, ref short short_0, ref short short_1, ref Class10[,] class10_0, Class11[,] class11_0, short short_2, short short_3)
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
					if (!Information.IsNothing((object)class10_0) && class10_0[nullable_0.Value, nullable_1.Value].method_7(vehicle_0))
					{
						if (num6 != short_3 - 1 && class10_0[num5, num6 + 1].method_7(vehicle_0))
						{
							num11++;
						}
						if (num6 != 0 && class10_0[num5, num6 - 1].method_7(vehicle_0))
						{
							num11++;
						}
						if (num5 != 0 && class10_0[num5 - 1, num6].method_7(vehicle_0))
						{
							num11++;
						}
						if (num5 != short_2 - 1 && class10_0[num5 + 1, num6].method_7(vehicle_0))
						{
							num11++;
						}
					}
					else if (!Information.IsNothing((object)class11_0) && class11_0[nullable_0.Value, nullable_1.Value].method_2(vehicle_0))
					{
						if (num6 != short_3 - 1 && class11_0[num5, num6 + 1].method_2(vehicle_0))
						{
							num11++;
						}
						if (num6 != 0 && class11_0[num5, num6 - 1].method_2(vehicle_0))
						{
							num11++;
						}
						if (num5 != 0 && class11_0[num5 - 1, num6].method_2(vehicle_0))
						{
							num11++;
						}
						if (num5 != short_2 - 1 && class11_0[num5 + 1, num6].method_2(vehicle_0))
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
						if (!Information.IsNothing((object)class10_0))
						{
							class10_0[num5, num6].method_8();
						}
						if (!Information.IsNothing((object)class11_0))
						{
							class11_0[num5, num6].method_3();
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
									if (vehicle_0.ParentScen.ThreadedOpsMustStop)
									{
										return;
									}
									short num22 = (short)(num16 + num21);
									if (num22 >= 0 && num22 <= short_3 - 1 && (num18 == 0 || num18 == num13 - 1 || num21 == 0 || num21 == num13 - 1) && ((!Information.IsNothing((object)class10_0) && class10_0[num19, num22].method_7(vehicle_0)) || (!Information.IsNothing((object)class11_0) && class11_0[num19, num22].method_2(vehicle_0))))
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
					if (!Information.IsNothing((object)class10_0) && class10_0[short_0, short_1].method_7(vehicle_0))
					{
						if (num8 != short_3 - 1 && class10_0[num7, num8 + 1].method_7(vehicle_0))
						{
							num24++;
						}
						if (num8 != 0 && class10_0[num7, num8 - 1].method_7(vehicle_0))
						{
							num24++;
						}
						if (num7 != 0 && class10_0[num7 - 1, num8].method_7(vehicle_0))
						{
							num24++;
						}
						if (num7 != short_2 - 1 && class10_0[num7 + 1, num8].method_7(vehicle_0))
						{
							num24++;
						}
					}
					else if (!Information.IsNothing((object)class11_0) && class11_0[short_0, short_1].method_2(vehicle_0))
					{
						if (num8 != short_3 - 1 && class11_0[num7, num8 + 1].method_2(vehicle_0))
						{
							num24++;
						}
						if (num8 != 0 && class11_0[num7, num8 - 1].method_2(vehicle_0))
						{
							num24++;
						}
						if (num7 != 0 && class11_0[num7 - 1, num8].method_2(vehicle_0))
						{
							num24++;
						}
						if (num7 != short_2 - 1 && class11_0[num7 + 1, num8].method_2(vehicle_0))
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
						if (!Information.IsNothing((object)class10_0))
						{
							class10_0[num7, num8].method_8();
						}
						if (!Information.IsNothing((object)class11_0))
						{
							class11_0[num7, num8].method_3();
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
									if (vehicle_0.ParentScen.ThreadedOpsMustStop)
									{
										return;
									}
									short num35 = (short)(num29 + num34);
									if (num35 >= 0 && num35 <= short_3 - 1 && (num31 == 0 || num31 == num26 - 1 || num34 == 0 || num34 == num26 - 1) && ((!Information.IsNothing((object)class10_0) && class10_0[num32, num35].method_7(vehicle_0)) || (!Information.IsNothing((object)class11_0) && class11_0[num32, num35].method_2(vehicle_0))))
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
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	static GroundCostBasedPathfinder()
	{
		Class72.smethod_20();
	}
}
