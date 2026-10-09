using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using Algorithms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class CostBasedPathfinder : GInterface1
{
	public sealed class NavPathNode
	{
		public float Lat;

		public float Lon;

		private byte byte_0;

		private short short_0;

		public int MovementCost;

		public List<ActiveUnit> ProvidedPiers;

		public float ProximityThreshold_Deg;

		public void Reset()
		{
			Lat = 0f;
			Lon = 0f;
			byte_0 = 0;
			short_0 = 0;
			MovementCost = 0;
			ProvidedPiers = null;
			ProximityThreshold_Deg = 0f;
		}

		public short Elevation(Scenario theScen)
		{
			if (short_0 == short.MaxValue)
			{
				short_0 = Pathfinding.pfcache_Array_0.GetElev(Lat, Lon, theScen);
			}
			return short_0;
		}

		internal bool IsWalkable(ActiveUnit inContext)
		{
			if (byte_0 == byte.MaxValue)
			{
				double theLat = Lat;
				double theLon = Lon;
				ref int movementCost = ref MovementCost;
				bool CheckNoNavZones = true;
				bool CheckForMines = true;
				short? providedElevation = Elevation(inContext.ParentScen);
				ref List<ActiveUnit> providedPiers = ref ProvidedPiers;
				float proximityThreshold_Deg = ProximityThreshold_Deg;
				string UserFeedback = "";
				bool AllowBounce = false;
				if (!inContext.CanMoveToThisLocation(theLat, theLon, ref movementCost, IsPathfindingQuery: true, UsePathfindingBufferDistance: true, IgnoreMinesBehindUs: false, ref CheckNoNavZones, CheckForIcepack: true, ref CheckForMines, null, providedElevation, ref providedPiers, proximityThreshold_Deg, CheckIfTargetIsOutsideProsecutionArea: false, CheckDistanceToNoNavZones: false, ref UserFeedback, ref AllowBounce))
				{
					byte_0 = 0;
				}
				else
				{
					byte_0 = 1;
				}
			}
			return byte_0 == 1;
		}

		public void IsNotWalkable()
		{
			byte_0 = 0;
		}

		public NavPathNode()
		{
			ProximityThreshold_Deg = 0f;
			byte_0 = byte.MaxValue;
			short_0 = short.MaxValue;
		}

		public NavPathNode(double theLat, double theLon)
		{
			ProximityThreshold_Deg = 0f;
			Lat = (float)theLat;
			Lon = (float)theLon;
			byte_0 = byte.MaxValue;
			short_0 = short.MaxValue;
		}

		static NavPathNode()
		{
			Class72.smethod_20();
		}
	}

	private sealed class Class15
	{
		public float float_0;

		public float float_1;

		private byte byte_0;

		private short short_0;

		public int int_0;

		public float float_2;

		public List<ActiveUnit> list_0;

		[SpecialName]
		public short method_0(Scenario scenario_0)
		{
			if (short_0 == short.MaxValue)
			{
				short_0 = Terrain.GetElevation(float_0, float_1, RequestIsFromGUI: false, scenario_0);
			}
			return short_0;
		}

		internal bool method_1(ActiveUnit activeUnit_0)
		{
			if (byte_0 == byte.MaxValue)
			{
				double theLat = float_0;
				double theLon = float_1;
				ref int movementCost = ref int_0;
				bool CheckNoNavZones = true;
				bool CheckForMines = true;
				short? providedElevation = method_0(activeUnit_0.ParentScen);
				ref List<ActiveUnit> providedPiers = ref list_0;
				float proximityThreshold_Deg = float_2;
				string UserFeedback = "";
				bool AllowBounce = false;
				if (activeUnit_0.CanMoveToThisLocation(theLat, theLon, ref movementCost, IsPathfindingQuery: true, UsePathfindingBufferDistance: true, IgnoreMinesBehindUs: false, ref CheckNoNavZones, CheckForIcepack: true, ref CheckForMines, null, providedElevation, ref providedPiers, proximityThreshold_Deg, CheckIfTargetIsOutsideProsecutionArea: false, CheckDistanceToNoNavZones: false, ref UserFeedback, ref AllowBounce))
				{
					byte_0 = 1;
				}
				else
				{
					byte_0 = 0;
				}
			}
			return byte_0 == 1;
		}

		public Class15()
		{
			float_2 = 0f;
			byte_0 = byte.MaxValue;
			short_0 = short.MaxValue;
		}

		public Class15(double double_0, double double_1)
		{
			float_2 = 0f;
			float_0 = (float)double_0;
			float_1 = (float)double_1;
			byte_0 = byte.MaxValue;
			short_0 = short.MaxValue;
		}

		public void method_2()
		{
			byte_0 = 0;
		}

		static Class15()
		{
			Class72.smethod_20();
		}
	}

	public const short ELEVATION_UNDEFINED = short.MaxValue;

	public const byte WALKABLE = 1;

	public const byte UNWALKABLE = 0;

	public const byte WALKABILITY_UNDEFINED = byte.MaxValue;

	private NavPathNodePool navPathNodePool_0;

	private static readonly ConcurrentDictionary<object, ConcurrentDictionary<(int, int), bool>> concurrentDictionary_0;

	public float DegreeInterval_Global => 0.18f;

	public float DegreeInterval_Coarse => 0.05f;

	public float DegreeInterval_Finegrained => 0.005f;

	static CostBasedPathfinder()
	{
		Class72.smethod_20();
		concurrentDictionary_0 = new ConcurrentDictionary<object, ConcurrentDictionary<(int, int), bool>>();
	}

	public CostBasedPathfinder()
	{
		navPathNodePool_0 = new NavPathNodePool();
	}

	internal List<Waypoint> SolvePF_Global(ActiveUnit theUnit, double StartLat, double StartLon, double EndLat, double EndLon, float CurrentHeading, float DegreeBuffer, float ProximityThreshold_Deg, ref List<ActiveUnit> ProvidedPiers, ref float PercentComplete, bool IsMissionPlannerRequest, bool AllowFineGrainedNav)
	{
		float degreeInterval_Global = DegreeInterval_Global;
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
				float num = 90f;
				float num2 = -90f;
				float num3 = (float)Math2.NormalizeLongitude(StartLon + 180.0);
				float num4 = (float)Math2.NormalizeLongitude(StartLon - 180.0);
				short num5 = (short)Math.Round(180f / degreeInterval_Global);
				short num6 = (short)Math.Round(360f / degreeInterval_Global);
				int i;
				for (i = 1; !(Math.Pow(2.0, i) > (double)num5) || !(Math.Pow(2.0, i) > (double)num6); i++)
				{
				}
				int num7 = (int)Math.Round(Math.Pow(2.0, i));
				int num8 = (int)Math.Round(Math.Pow(2.0, i));
				long num9 = (long)num6 * (long)num5;
				NavPathNode[,] navPathNode_ = new NavPathNode[num6 - 1 + 1, num5 - 1 + 1];
				Doctrine._NavigationMethod? navigationMethod;
				if (theUnit != null)
				{
					if (!theUnit.IsShip)
					{
						if (theUnit.IsSubmarine)
						{
							navigationMethod = theUnit.Doctrine.get_SubmarineNavigation(theUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
						}
						else
						{
							if (theUnit.IsFacility)
							{
								throw new Exception();
							}
							navigationMethod = Doctrine._NavigationMethod.ShortestRoute;
						}
					}
					else
					{
						navigationMethod = theUnit.Doctrine.get_SurfaceNavigation(theUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
					}
				}
				else
				{
					navigationMethod = Doctrine._NavigationMethod.ShortestRoute;
				}
				int num10 = num6 - 1;
				int num11 = 0;
				short? nullable_ = default(short?);
				short? nullable_2 = default(short?);
				short short_ = default(short);
				short short_2 = default(short);
				double num53 = default(double);
				double num54 = default(double);
				long num13 = default(long);
				while (true)
				{
					double num49;
					if (num11 > num10)
					{
						if (!nullable_.HasValue)
						{
							try
							{
								double num12 = double.MaxValue;
								GeoPoint geoPoint = new GeoPoint(StartLon, StartLat);
								num13 = 0L;
								float num14 = num - degreeInterval_Global;
								float num15 = degreeInterval_Global;
								bool flag2 = num15 >= 0f;
								for (float num16 = num2; flag2 ? (num16 <= num14) : (num16 >= num14); num16 += num15)
								{
									double num17 = geoPoint.RangeToPoint_Horiz_Angular(StartLon, num16);
									if (num17 < num12)
									{
										num12 = num17;
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
								double num18 = double.MaxValue;
								GeoPoint geoPoint2 = new GeoPoint(StartLon, StartLat);
								num13 = 0L;
								float num19 = num4 - degreeInterval_Global;
								float num20 = degreeInterval_Global;
								bool flag3 = num20 >= 0f;
								float num21 = num3;
								while (flag3 ? (num21 <= num19) : (num21 >= num19))
								{
									num21 = Math2.NormalizeLongitude(num21);
									double num22 = geoPoint2.RangeToPoint_Horiz_Angular(num21, StartLat);
									if (num22 < num18)
									{
										num18 = num22;
										nullable_2 = (short)num13;
									}
									num13++;
									num21 += num20;
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
						method_3(ref theUnit, ref nullable_2, ref nullable_, ref short_, ref short_2, ref navPathNode_, null, num6, num5);
						int num23 = 10000;
						int num24 = num6 - 1;
						for (int j = 0; j <= num24; j++)
						{
							int num25 = num5 - 1;
							for (int k = 0; k <= num25; k++)
							{
								if (navPathNode_[j, k].MovementCost != 0)
								{
									method_1(ref navPathNode_, j, k, 0, num23, num6, num5);
								}
							}
						}
						if (theUnit.IsSubmarine || theUnit.IsShip)
						{
							List<int> list = new List<int>();
							Doctrine._NavigationMethod? navigationMethod2 = navigationMethod;
							byte? b = (byte?)navigationMethod2;
							if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)) != true)
							{
								b = (byte?)navigationMethod2;
								if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 5)) != true)
								{
									list.Add(6000);
									list.Add(3000);
									list.Add(1500);
								}
							}
							else
							{
								list.Add(50);
								list.Add(60);
								list.Add(70);
								list.Add(80);
								list.Add(90);
							}
							int num26 = num23;
							num13 = list.Count;
							b = (byte?)navigationMethod;
							if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)) == true)
							{
								long num27 = num13 - 1L;
								for (long num28 = 0L; num28 <= num27; num28++)
								{
									int num29 = list[(int)num28];
									int num30 = num6 - 1;
									for (int l = 0; l <= num30; l++)
									{
										int num31 = num5 - 1;
										for (int m = 0; m <= num31; m++)
										{
											if (navPathNode_[l, m].MovementCost != 0 && navPathNode_[l, m].MovementCost != num23 && (num26 >= 100 || navPathNode_[l, m].MovementCost > num26))
											{
												method_1(ref navPathNode_, l, m, num26, num29, num6, num5);
											}
										}
									}
									num26 = num29;
								}
							}
							else
							{
								long num32 = num13 - 1L;
								for (long num33 = 0L; num33 <= num32; num33++)
								{
									int num29 = list[(int)num33];
									int num34 = num6 - 1;
									for (int n = 0; n <= num34; n++)
									{
										int num35 = num5 - 1;
										for (int num36 = 0; num36 <= num35; num36++)
										{
											if (navPathNode_[n, num36].MovementCost != 0 && navPathNode_[n, num36].MovementCost < num26)
											{
												method_1(ref navPathNode_, n, num36, num26, num29, num6, num5);
											}
										}
									}
									num26 = num29;
								}
							}
						}
						int[,] array = new int[num8 - 1 + 1, num7 - 1 + 1];
						int num37 = num6 - 1;
						for (int num38 = 0; num38 <= num37; num38++)
						{
							int num39 = num5 - 1;
							for (int num40 = 0; num40 <= num39; num40++)
							{
								array[num38, num40] = navPathNode_[num38, num40].MovementCost;
							}
						}
						int num41 = num6 - 1;
						for (int num42 = 0; num42 <= num41; num42++)
						{
							int num43 = num5 - 1;
							for (int num44 = 0; num44 <= num43; num44++)
							{
								navPathNodePool_0.ReturnNode(navPathNode_[num42, num44]);
							}
						}
						navPathNode_ = null;
						List<PathFinderNode> list2 = new PathFinderFast(array)
						{
							Formula = HeuristicFormula.Euclidean,
							Diagonals = true,
							HeavyDiagonals = false,
							PunishChangeDirection = false,
							PunishWalkingOnEdge = true,
							TrimAutoNavPoints = true,
							TieBreaker = true,
							SearchLimit = int.MaxValue,
							DebugProgress = false,
							ReopenCloseNodes = true,
							EdgeCost = num23
						}.FindPath(new Point(nullable_2.Value, nullable_.Value), new Point(short_, short_2));
						if (list2 == null)
						{
							result = null;
							break;
						}
						List<Waypoint> list3 = new List<Waypoint>();
						list2.Reverse();
						num13 = list2.Count;
						double num45 = StartLat;
						double num46 = StartLon;
						long num47 = num13 - 1L;
						for (long num48 = 0L; num48 <= num47; num48++)
						{
							PathFinderNode pathFinderNode = list2[(int)num48];
							num49 = (flag ? ((double)Math2.NormalizeLongitude(num3 - (float)pathFinderNode.X * degreeInterval_Global)) : ((double)Math2.NormalizeLongitude(num3 + (float)pathFinderNode.X * degreeInterval_Global)));
							double num50 = Math2.NormalizeLatitude(num2 + (float)pathFinderNode.Y * degreeInterval_Global);
							double num51;
							double num52;
							if (num48 == 0L)
							{
								num51 = StartLat;
								num52 = StartLon;
							}
							else
							{
								num51 = num45;
								num52 = num46;
							}
							if (!pathFinderNode.E)
							{
								num53 = num50;
								num54 = num49;
								ActiveUnit_Navigator navigator = theUnit.Navigator;
								double startLat = num51;
								double startLon = num52;
								double destLat = num53;
								double destLon = num54;
								float? samplingInterval_Deg = DegreeInterval_Coarse;
								int ReasonForInterrupt = 0;
								GeoPoint InterruptLocation = null;
								if (navigator.PathLineIsInterrupted(startLat, startLon, destLat, destLon, RunInParallel: false, 0f, CheckIfCurrentlyInsideIllegalArea: false, null, IsPathfindingQuery: false, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: false, samplingInterval_Deg, ref ReasonForInterrupt, ref InterruptLocation))
								{
									List<Waypoint> list4 = Pathfinding.PathFinderCostBasedEngine.SolvePF_Coarse(theUnit, num51, num52, num53, num54, CurrentHeading, 2f, ProximityThreshold_Deg, ref ProvidedPiers, ref PercentComplete, IsMissionPlannerRequest, AllowFineGrainedNav);
									if (!Information.IsNothing((object)list4))
									{
										foreach (Waypoint item in list4)
										{
											if (!(Math.Abs(item.Latitude - num53) < (double)DegreeInterval_Finegrained) || !(Math.Abs(item.Longitude - num54) < (double)DegreeInterval_Finegrained))
											{
												list3.Add(item);
												continue;
											}
											break;
										}
										num45 = num53;
										num46 = num54;
										continue;
									}
								}
							}
							else
							{
								int ReasonForInterrupt;
								GeoPoint InterruptLocation;
								if (num48 == 0L && num13 > 1L)
								{
									PathFinderNode pathFinderNode2 = list2[(int)num48 + 1];
									num54 = (flag ? ((double)Math2.NormalizeLongitude(num3 - (float)pathFinderNode2.X * degreeInterval_Global)) : ((double)Math2.NormalizeLongitude(num3 + (float)pathFinderNode2.X * degreeInterval_Global)));
									num53 = Math2.NormalizeLatitude(num2 + (float)pathFinderNode2.Y * degreeInterval_Global);
									ActiveUnit_Navigator navigator2 = theUnit.Navigator;
									double startLat2 = num51;
									double startLon2 = num52;
									double destLat2 = num53;
									double destLon2 = num54;
									float? samplingInterval_Deg2 = DegreeInterval_Finegrained;
									ReasonForInterrupt = 0;
									InterruptLocation = null;
									if (!navigator2.PathLineIsInterrupted(startLat2, startLon2, destLat2, destLon2, RunInParallel: false, 0f, CheckIfCurrentlyInsideIllegalArea: false, null, IsPathfindingQuery: false, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: false, samplingInterval_Deg2, ref ReasonForInterrupt, ref InterruptLocation))
									{
										continue;
									}
								}
								long num55 = 0L;
								bool flag4 = false;
								if (num48 == num13 - 1L)
								{
									num53 = EndLat;
									num54 = EndLon;
								}
								else
								{
									long num56 = num48 + 1L;
									long num57 = num13 - 1L;
									for (num55 = num56; num55 <= num57; num55++)
									{
										PathFinderNode pathFinderNode3 = list2[(int)num48 + 1];
										if (pathFinderNode3.E)
										{
											num48 = num55;
											continue;
										}
										flag4 = true;
										num54 = (flag ? ((double)Math2.NormalizeLongitude(num3 - (float)pathFinderNode3.X * degreeInterval_Global)) : ((double)Math2.NormalizeLongitude(num3 + (float)pathFinderNode3.X * degreeInterval_Global)));
										num53 = Math2.NormalizeLatitude(num2 + (float)pathFinderNode3.Y * degreeInterval_Global);
										break;
									}
									if (!flag4)
									{
										num53 = EndLat;
										num54 = EndLon;
										num48 = num13 - 1L;
									}
								}
								ActiveUnit_Navigator navigator3 = theUnit.Navigator;
								double startLat3 = num51;
								double startLon3 = num52;
								double destLat3 = num53;
								double destLon3 = num54;
								float? samplingInterval_Deg3 = DegreeInterval_Coarse;
								ReasonForInterrupt = 0;
								InterruptLocation = null;
								if (!navigator3.PathLineIsInterrupted(startLat3, startLon3, destLat3, destLon3, RunInParallel: false, 0f, CheckIfCurrentlyInsideIllegalArea: false, null, IsPathfindingQuery: false, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: false, samplingInterval_Deg3, ref ReasonForInterrupt, ref InterruptLocation))
								{
									num45 = num53;
									num46 = num54;
									continue;
								}
								List<Waypoint> list5 = Pathfinding.PathFinderCostBasedEngine.SolvePF_Coarse(theUnit, num51, num52, num53, num54, CurrentHeading, 2f, ProximityThreshold_Deg, ref ProvidedPiers, ref PercentComplete, IsMissionPlannerRequest, AllowFineGrainedNav);
								if (list5 != null)
								{
									foreach (Waypoint item2 in list5)
									{
										if (!(Math.Abs(item2.Latitude - num53) < (double)DegreeInterval_Finegrained) || !(Math.Abs(item2.Longitude - num54) < (double)DegreeInterval_Finegrained))
										{
											list3.Add(item2);
											continue;
										}
										break;
									}
									num45 = num53;
									num46 = num54;
									continue;
								}
							}
							num45 = num50;
							num46 = num49;
							list3.Add(new Waypoint(num49, num50, 0f, Waypoint.WaypointType.PathfindingPoint, Waypoint.WaypointCreator.Pathfinder, Waypoint.WaypointCategory.PlottedCourse));
						}
						result = list3;
						break;
					}
					num49 = ((!flag) ? ((double)Math2.NormalizeLongitude(num3 + (float)num11 * degreeInterval_Global)) : ((double)Math2.NormalizeLongitude(num3 - (float)num11 * degreeInterval_Global)));
					int num58 = num5 - 1;
					int num59 = 0;
					while (true)
					{
						if (num59 <= num58)
						{
							if (!theUnit.ParentScen.ThreadedOpsMustStop)
							{
								if (IsMissionPlannerRequest || !theUnit.IsMorituri)
								{
									double num50 = Math2.NormalizeLatitude(num2 + (float)num59 * degreeInterval_Global);
									NavPathNode navPathNode = navPathNodePool_0.Rent();
									navPathNode.Lat = (float)num50;
									navPathNode.Lon = (float)num49;
									navPathNode.ProximityThreshold_Deg = ProximityThreshold_Deg;
									navPathNode.ProvidedPiers = ProvidedPiers;
									if (navPathNode.IsWalkable(theUnit))
									{
										int movementCost;
										if (!theUnit.IsShip)
										{
											if (theUnit.IsSubmarine)
											{
												short num60 = navPathNode.Elevation(theUnit.ParentScen);
												Doctrine._NavigationMethod? navigationMethod3 = navigationMethod;
												byte? b = (byte?)navigationMethod3;
												if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 3)) == true)
												{
													movementCost = ((num60 >= -40) ? 1000 : ((num60 >= -300) ? 600 : ((num60 < -1525) ? 100 : 300)));
												}
												else
												{
													b = (byte?)navigationMethod3;
													if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 4)) == true)
													{
														movementCost = ((num60 >= -40) ? 1000 : ((num60 < -300) ? 100 : 300));
													}
													else
													{
														b = (byte?)navigationMethod3;
														movementCost = ((((!b.HasValue) ? ((bool?)null) : new bool?(b == 5)) == true) ? ((num60 >= -40) ? 1000 : ((num60 < -300) ? 1000 : 100)) : ((num60 < -40) ? 100 : 1000));
													}
												}
											}
											else
											{
												if (theUnit.IsFacility)
												{
													throw new Exception();
												}
												movementCost = 100;
											}
										}
										else
										{
											short num60 = navPathNode.Elevation(theUnit.ParentScen);
											Doctrine._NavigationMethod? navigationMethod4 = navigationMethod;
											byte? b = (byte?)navigationMethod4;
											if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
											{
												movementCost = ((num60 >= -50) ? 1000 : ((num60 >= -200) ? 600 : ((num60 >= -305) ? 300 : ((num60 >= -365) ? 300 : ((num60 >= -1000) ? 300 : ((num60 < -1525) ? 100 : 300))))));
											}
											else
											{
												b = (byte?)navigationMethod4;
												movementCost = ((((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)) != true) ? 100 : ((num60 < -200) ? 1000 : 100));
											}
										}
										navPathNode.MovementCost = movementCost;
										if (Math.Abs(StartLon - num49) < (double)degreeInterval_Global && (!nullable_2.HasValue || Math.Abs(MathFunctions.AngularDifference(CurrentHeading, Math2.CalcAzimuth(StartLat, StartLon, num50, num49))) < 90f))
										{
											nullable_2 = (short)num11;
										}
										if (Math.Abs(EndLon - num49) < (double)degreeInterval_Global)
										{
											short_ = (short)num11;
										}
										if (Math.Abs(StartLat - num50) < (double)degreeInterval_Global && (!nullable_.HasValue || Math.Abs(MathFunctions.AngularDifference(CurrentHeading, Math2.CalcAzimuth(StartLat, StartLon, num50, num49))) < 90f))
										{
											nullable_ = (short)num59;
										}
										if (Math.Abs(EndLat - num50) < (double)degreeInterval_Global)
										{
											short_2 = (short)num59;
										}
									}
									else
									{
										navPathNode.MovementCost = 0;
									}
									navPathNode_[num11, num59] = navPathNode;
									num13++;
									num59++;
									continue;
								}
								result = null;
								goto end_IL_0654;
							}
							result = null;
							goto end_IL_0654;
						}
						PercentComplete = (float)((double)num13 / (double)num9);
						num11++;
						break;
					}
					continue;
					end_IL_0654:
					break;
				}
			}
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			ex6?.Data.Add("Error at 101333", "");
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

	internal List<Waypoint> SolvePF_Coarse(ActiveUnit theUnit, double StartLat, double StartLon, double EndLat, double EndLon, float CurrentHeading, float DegreeBuffer, float ProximityThreshold_Deg, ref List<ActiveUnit> ProvidedPiers, ref float PercentComplete, bool IsMissionPlannerRequest, bool AllowFineGrainedNav)
	{
		float degreeInterval_Coarse = DegreeInterval_Coarse;
		List<Waypoint> result;
		try
		{
			if (!theUnit.ParentScen.ThreadedOpsMustStop)
			{
				Geopoint_Struct[] array = new Geopoint_Struct[0];
				if (theUnit.AssignedMissionOrPackage() != null)
				{
					Mission._MissionClass missionClass = theUnit.AssignedMissionOrPackage().MissionClass;
					if (missionClass == Mission._MissionClass.Patrol)
					{
						List<ReferencePoint> patrolArea_10nm_Buffered = ((Patrol)theUnit.AssignedMissionOrPackage()).PatrolArea_10nm_Buffered;
						if (patrolArea_10nm_Buffered != null)
						{
							List<Geopoint_Struct> list = new List<Geopoint_Struct>(patrolArea_10nm_Buffered.Count);
							foreach (ReferencePoint item in patrolArea_10nm_Buffered)
							{
								list.Add(item.ToGeopoint_Struct());
							}
							array = list.ToArray();
						}
					}
				}
				bool flag;
				double num = default(double);
				double num2 = default(double);
				double num3 = default(double);
				double num4 = default(double);
				if (flag = array != null && array.Length > 0)
				{
					num = array.Min([SpecialName] (Geopoint_Struct p) => p.Latitude);
					num2 = array.Max([SpecialName] (Geopoint_Struct p) => p.Latitude);
					num3 = array.Min([SpecialName] (Geopoint_Struct p) => p.Longitude);
					num4 = array.Max([SpecialName] (Geopoint_Struct p) => p.Longitude);
				}
				bool flag2 = Math2.LineCrossesAntimeridian(StartLat, StartLon, EndLat, EndLon);
				float num5 = Math.Min((float)(short)Math.Round(Math.Max(StartLat, EndLat)) + DegreeBuffer, 90f);
				float num6 = Math.Max((float)(short)Math.Round(Math.Min(StartLat, EndLat)) - DegreeBuffer, -90f);
				short num7 = (short)Math.Round(Math.Abs(num5 - num6) / degreeInterval_Coarse);
				float num8;
				float num9;
				short num10;
				int num11;
				if (!flag2)
				{
					num8 = (float)(short)Math.Round(Math.Min(StartLon, EndLon)) - DegreeBuffer;
					num9 = (float)(short)Math.Round(Math.Max(StartLon, EndLon)) + DegreeBuffer;
					num10 = Math.Abs((short)Math.Round(Math.Abs(num9 - num8) / degreeInterval_Coarse));
					num11 = 1;
				}
				else
				{
					num8 = (float)(short)Math.Round(Math.Min(StartLon, EndLon)) + DegreeBuffer;
					num9 = (float)(short)Math.Round(Math.Max(StartLon, EndLon)) - DegreeBuffer;
					num10 = Math.Abs((short)Math.Round((180f - Math.Abs(num8) + (180f - num9)) / degreeInterval_Coarse));
					num11 = 1;
				}
				int num12;
				for (num12 = num11; !(Math.Pow(2.0, num12) >= (double)num7) || !(Math.Pow(2.0, num12) >= (double)num10); num12++)
				{
				}
				int num13 = (int)Math.Round(Math.Pow(2.0, num12));
				int num14 = (int)Math.Round(Math.Pow(2.0, num12));
				if (num13 > 2048)
				{
					result = SolvePF_Global(theUnit, StartLat, StartLon, EndLat, EndLon, CurrentHeading, DegreeBuffer, ProximityThreshold_Deg, ref ProvidedPiers, ref PercentComplete, IsMissionPlannerRequest, AllowFineGrainedNav);
				}
				else
				{
					long num15 = (long)num10 * (long)num7;
					NavPathNode[,] navPathNode_ = new NavPathNode[num10 - 1 + 1, num7 - 1 + 1];
					Doctrine._NavigationMethod? navigationMethod;
					if (theUnit != null)
					{
						if (!theUnit.IsShip)
						{
							if (theUnit.IsSubmarine)
							{
								navigationMethod = theUnit.Doctrine.get_SubmarineNavigation(theUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
							}
							else
							{
								if (theUnit.IsFacility)
								{
									throw new Exception();
								}
								navigationMethod = Doctrine._NavigationMethod.ShortestRoute;
							}
						}
						else
						{
							navigationMethod = theUnit.Doctrine.get_SurfaceNavigation(theUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
						}
					}
					else
					{
						navigationMethod = Doctrine._NavigationMethod.ShortestRoute;
					}
					bool isShip = theUnit.IsShip;
					bool isSubmarine = theUnit.IsSubmarine;
					bool isFacility = theUnit.IsFacility;
					double[] array2 = new double[num7 - 1 + 1];
					int num16 = num7 - 1;
					for (int num17 = 0; num17 <= num16; num17++)
					{
						array2[num17] = Math2.NormalizeLatitude(num6 + (float)num17 * degreeInterval_Coarse);
					}
					int num18 = num10 - 1;
					int num19 = 0;
					short? nullable_ = default(short?);
					short short_ = default(short);
					short? nullable_2 = default(short?);
					short short_2 = default(short);
					long num25 = default(long);
					double num70 = default(double);
					double num71 = default(double);
					while (true)
					{
						if (num19 <= num18)
						{
							if (theUnit != null)
							{
								Scenario parentScen = theUnit.ParentScen;
								if (parentScen != null && parentScen.ThreadedOpsMustStop)
								{
									result = null;
									break;
								}
							}
							if (!IsMissionPlannerRequest && theUnit.IsMorituri)
							{
								result = null;
								break;
							}
							double num20 = (flag2 ? ((double)Math2.NormalizeLongitude(num8 - (float)num19 * degreeInterval_Coarse)) : ((double)Math2.NormalizeLongitude(num8 + (float)num19 * degreeInterval_Coarse)));
							bool flag3 = !flag || (num20 >= num3 && num20 <= num4);
							int num21 = num7 - 1;
							for (int num22 = 0; num22 <= num21; num22++)
							{
								double num23 = array2[num22];
								NavPathNode navPathNode = navPathNodePool_0.Rent();
								navPathNode.Lat = (float)num23;
								navPathNode.Lon = (float)num20;
								navPathNode.ProximityThreshold_Deg = ProximityThreshold_Deg;
								navPathNode.ProvidedPiers = ProvidedPiers;
								bool flag4 = !flag || (flag3 && num23 >= num && num23 <= num2);
								if (!flag4 || !navPathNode.IsWalkable(theUnit) || (flag && !method_0(theUnit.AssignedMissionOrPackage(), array, num19, num22, num23, num20)))
								{
									navPathNode.MovementCost = 0;
								}
								else
								{
									int movementCost;
									if (isShip)
									{
										short num24 = navPathNode.Elevation(theUnit.ParentScen);
										Doctrine._NavigationMethod? navigationMethod2 = navigationMethod;
										byte? b = (byte?)navigationMethod2;
										if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
										{
											movementCost = ((num24 >= -50) ? 1000 : ((num24 >= -200) ? 600 : ((num24 >= -305) ? 300 : ((num24 >= -365) ? 300 : ((num24 >= -1000) ? 300 : ((num24 < -1525) ? 100 : 300))))));
										}
										else
										{
											b = (byte?)navigationMethod2;
											movementCost = ((((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)) != true) ? 100 : ((num24 < -200) ? 1000 : 100));
										}
									}
									else if (isSubmarine)
									{
										short num24 = navPathNode.Elevation(theUnit.ParentScen);
										Doctrine._NavigationMethod? navigationMethod3 = navigationMethod;
										byte? b = (byte?)navigationMethod3;
										if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 3)) == true)
										{
											movementCost = ((num24 >= -40) ? 1000 : ((num24 >= -300) ? 600 : ((num24 < -1525) ? 100 : 300)));
										}
										else
										{
											b = (byte?)navigationMethod3;
											if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 4)) == true)
											{
												movementCost = ((num24 >= -40) ? 1000 : ((num24 < -300) ? 100 : 300));
											}
											else
											{
												b = (byte?)navigationMethod3;
												movementCost = ((((!b.HasValue) ? ((bool?)null) : new bool?(b == 5)) != true) ? ((num24 < -40) ? 100 : 1000) : ((num24 >= -40) ? 1000 : ((num24 < -300) ? 1000 : 100)));
											}
										}
									}
									else
									{
										if (isFacility)
										{
											throw new Exception();
										}
										movementCost = 100;
									}
									navPathNode.MovementCost = movementCost;
									if (Math.Abs(StartLon - num20) < (double)degreeInterval_Coarse && (!nullable_.HasValue || Math.Abs(MathFunctions.AngularDifference(CurrentHeading, Math2.CalcAzimuth(StartLat, StartLon, num23, num20))) < 90f))
									{
										nullable_ = (short)num19;
									}
									if (Math.Abs(EndLon - num20) < (double)degreeInterval_Coarse)
									{
										short_ = (short)num19;
									}
									if (Math.Abs(StartLat - num23) < (double)degreeInterval_Coarse && (!nullable_2.HasValue || Math.Abs(MathFunctions.AngularDifference(CurrentHeading, Math2.CalcAzimuth(StartLat, StartLon, num23, num20))) < 90f))
									{
										nullable_2 = (short)num22;
									}
									if (Math.Abs(EndLat - num23) < (double)degreeInterval_Coarse)
									{
										short_2 = (short)num22;
									}
								}
								navPathNode_[num19, num22] = navPathNode;
								num25++;
							}
							PercentComplete = (float)((double)num25 / (double)num15);
							num19++;
							continue;
						}
						if (!nullable_2.HasValue)
						{
							try
							{
								double num26 = double.MaxValue;
								GeoPoint geoPoint = new GeoPoint(StartLon, StartLat);
								num25 = 0L;
								float num27 = num5 - degreeInterval_Coarse;
								float num28 = degreeInterval_Coarse;
								bool flag5 = num28 >= 0f;
								for (float num29 = num6; flag5 ? (num29 <= num27) : (num29 >= num27); num29 += num28)
								{
									double num30 = geoPoint.RangeToPoint_Horiz_Angular(StartLon, num29);
									if (num30 < num26)
									{
										num26 = num30;
										nullable_2 = (short)num25;
									}
									num25++;
								}
							}
							catch (Exception ex)
							{
								ProjectData.SetProjectError(ex);
								Exception ex2 = ex;
								ex2?.Data.Add("Error at 751245214214512421", "");
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
								double num31 = double.MaxValue;
								GeoPoint geoPoint2 = new GeoPoint(StartLon, StartLat);
								num25 = 0L;
								float num32 = num8;
								float num33 = num9 - degreeInterval_Coarse;
								float num34 = degreeInterval_Coarse;
								bool flag6 = num34 >= 0f;
								float num35 = num32;
								while ((!flag6) ? (num35 >= num33) : (num35 <= num33))
								{
									num35 = Math2.NormalizeLongitude(num35);
									double num36 = geoPoint2.RangeToPoint_Horiz_Angular(num35, StartLat);
									if (num36 < num31)
									{
										num31 = num36;
										nullable_ = (short)num25;
									}
									num25++;
									num35 += num34;
								}
							}
							catch (Exception ex3)
							{
								ProjectData.SetProjectError(ex3);
								Exception ex4 = ex3;
								ex4?.Data.Add("Error at 25322721741174174", "");
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
						method_3(ref theUnit, ref nullable_, ref nullable_2, ref short_, ref short_2, ref navPathNode_, null, num10, num7);
						int num37 = 10000;
						int num38 = num10 - 1;
						for (int num39 = 0; num39 <= num38; num39++)
						{
							int num40 = num7 - 1;
							for (int num41 = 0; num41 <= num40; num41++)
							{
								if (navPathNode_[num39, num41].MovementCost != 0)
								{
									method_1(ref navPathNode_, num39, num41, 0, num37, num10, num7);
								}
							}
						}
						if (theUnit.IsSubmarine || theUnit.IsShip)
						{
							List<int> list2 = new List<int>();
							Doctrine._NavigationMethod? navigationMethod4 = navigationMethod;
							byte? b = (byte?)navigationMethod4;
							if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)) != true)
							{
								b = (byte?)navigationMethod4;
								if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 5)) != true)
								{
									list2.Add(6000);
									list2.Add(3000);
									list2.Add(1500);
								}
							}
							else
							{
								list2.Add(50);
								list2.Add(60);
								list2.Add(70);
								list2.Add(80);
								list2.Add(90);
							}
							int num42 = num37;
							num25 = list2.Count;
							b = (byte?)navigationMethod;
							if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)) != true)
							{
								long num43 = num25 - 1L;
								for (long num44 = 0L; num44 <= num43; num44++)
								{
									int num45 = list2[(int)num44];
									int num46 = num10 - 1;
									for (int num47 = 0; num47 <= num46; num47++)
									{
										int num48 = num7 - 1;
										for (int num49 = 0; num49 <= num48; num49++)
										{
											if (navPathNode_[num47, num49].MovementCost != 0 && navPathNode_[num47, num49].MovementCost < num42)
											{
												method_1(ref navPathNode_, num47, num49, num42, num45, num10, num7);
											}
										}
									}
									num42 = num45;
								}
							}
							else
							{
								long num50 = num25 - 1L;
								for (long num51 = 0L; num51 <= num50; num51++)
								{
									int num45 = list2[(int)num51];
									int num52 = num10 - 1;
									for (int num53 = 0; num53 <= num52; num53++)
									{
										int num54 = num7 - 1;
										for (int num55 = 0; num55 <= num54; num55++)
										{
											if (navPathNode_[num53, num55].MovementCost != 0 && navPathNode_[num53, num55].MovementCost != num37 && (num42 >= 100 || navPathNode_[num53, num55].MovementCost > num42))
											{
												method_1(ref navPathNode_, num53, num55, num42, num45, num10, num7);
											}
										}
									}
									num42 = num45;
								}
							}
						}
						int[,] array3 = new int[num14 - 1 + 1, num13 - 1 + 1];
						int num56 = num10 - 1;
						for (int num57 = 0; num57 <= num56; num57++)
						{
							int num58 = num7 - 1;
							for (int num59 = 0; num59 <= num58; num59++)
							{
								array3[num57, num59] = navPathNode_[num57, num59].MovementCost;
							}
						}
						int num60 = num10 - 1;
						for (int num61 = 0; num61 <= num60; num61++)
						{
							int num62 = num7 - 1;
							for (int num63 = 0; num63 <= num62; num63++)
							{
								navPathNodePool_0.ReturnNode(navPathNode_[num61, num63]);
							}
						}
						navPathNode_ = null;
						List<PathFinderNode> list3 = new PathFinderFast(array3)
						{
							Formula = HeuristicFormula.Euclidean,
							Diagonals = true,
							HeavyDiagonals = false,
							PunishChangeDirection = false,
							PunishWalkingOnEdge = true,
							TrimAutoNavPoints = true,
							TieBreaker = true,
							SearchLimit = int.MaxValue,
							DebugProgress = false,
							ReopenCloseNodes = true,
							EdgeCost = num37
						}.FindPath(new Point(nullable_.Value, nullable_2.Value), new Point(short_, short_2));
						if (list3 != null)
						{
							List<Waypoint> list4 = new List<Waypoint>();
							list3.Reverse();
							num25 = list3.Count;
							double num64 = StartLat;
							double num65 = StartLon;
							long num66 = num25 - 1L;
							for (long num67 = 0L; num67 <= num66; num67++)
							{
								PathFinderNode pathFinderNode = list3[(int)num67];
								double num20 = (flag2 ? ((double)Math2.NormalizeLongitude(num8 - (float)pathFinderNode.X * degreeInterval_Coarse)) : ((double)Math2.NormalizeLongitude(num8 + (float)pathFinderNode.X * degreeInterval_Coarse)));
								double num23 = Math2.NormalizeLatitude(num6 + (float)pathFinderNode.Y * degreeInterval_Coarse);
								if (AllowFineGrainedNav)
								{
									double num68;
									double num69;
									if (num67 == 0L)
									{
										num68 = StartLat;
										num69 = StartLon;
									}
									else
									{
										num68 = num64;
										num69 = num65;
									}
									if (!pathFinderNode.E)
									{
										num70 = num23;
										num71 = num20;
										ActiveUnit_Navigator navigator = theUnit.Navigator;
										double startLat = num68;
										double startLon = num69;
										double destLat = num70;
										double destLon = num71;
										float? samplingInterval_Deg = DegreeInterval_Finegrained;
										int ReasonForInterrupt = 0;
										GeoPoint InterruptLocation = null;
										if (navigator.PathLineIsInterrupted(startLat, startLon, destLat, destLon, RunInParallel: false, 0f, CheckIfCurrentlyInsideIllegalArea: false, null, IsPathfindingQuery: false, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: false, samplingInterval_Deg, ref ReasonForInterrupt, ref InterruptLocation))
										{
											List<Waypoint> list5 = Pathfinding.PathFinderCostBasedEngine.SolvePF_Finegrained(theUnit, num68, num69, num70, num71, CurrentHeading, 2f, ProximityThreshold_Deg, ref ProvidedPiers, ref PercentComplete, IsMissionPlannerRequest);
											if (list5 != null)
											{
												foreach (Waypoint item2 in list5)
												{
													if (!(Math.Abs(item2.Latitude - num70) < (double)DegreeInterval_Finegrained) || !(Math.Abs(item2.Longitude - num71) < (double)DegreeInterval_Finegrained))
													{
														list4.Add(item2);
														continue;
													}
													break;
												}
												num64 = num70;
												num65 = num71;
												continue;
											}
										}
									}
									else
									{
										int num72;
										int ReasonForInterrupt;
										GeoPoint InterruptLocation;
										if (num67 != 0L)
										{
											num72 = 0;
										}
										else if (num25 > 1L)
										{
											PathFinderNode pathFinderNode2 = list3[(int)num67 + 1];
											num71 = ((!flag2) ? ((double)Math2.NormalizeLongitude(num8 + (float)pathFinderNode2.X * degreeInterval_Coarse)) : ((double)Math2.NormalizeLongitude(num8 - (float)pathFinderNode2.X * degreeInterval_Coarse)));
											num70 = Math2.NormalizeLatitude(num6 + (float)pathFinderNode2.Y * degreeInterval_Coarse);
											ActiveUnit_Navigator navigator2 = theUnit.Navigator;
											double startLat2 = num68;
											double startLon2 = num69;
											double destLat2 = num70;
											double destLon2 = num71;
											float? samplingInterval_Deg2 = DegreeInterval_Finegrained;
											ReasonForInterrupt = 0;
											InterruptLocation = null;
											if (!navigator2.PathLineIsInterrupted(startLat2, startLon2, destLat2, destLon2, RunInParallel: false, 0f, CheckIfCurrentlyInsideIllegalArea: false, null, IsPathfindingQuery: false, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: false, samplingInterval_Deg2, ref ReasonForInterrupt, ref InterruptLocation))
											{
												continue;
											}
											num72 = 0;
										}
										else
										{
											num72 = 0;
										}
										long num73 = num72;
										bool flag7 = false;
										if (num67 == num25 - 1L)
										{
											num70 = EndLat;
											num71 = EndLon;
										}
										else
										{
											long num74 = num67 + 1L;
											long num75 = num25 - 1L;
											for (num73 = num74; num73 <= num75; num73++)
											{
												PathFinderNode pathFinderNode3 = list3[(int)num67 + 1];
												if (pathFinderNode3.E)
												{
													num67 = num73;
													continue;
												}
												flag7 = true;
												num71 = ((!flag2) ? ((double)Math2.NormalizeLongitude(num8 + (float)pathFinderNode3.X * degreeInterval_Coarse)) : ((double)Math2.NormalizeLongitude(num8 - (float)pathFinderNode3.X * degreeInterval_Coarse)));
												num70 = Math2.NormalizeLatitude(num6 + (float)pathFinderNode3.Y * degreeInterval_Coarse);
												break;
											}
											if (!flag7)
											{
												num70 = EndLat;
												num71 = EndLon;
												num67 = num25 - 1L;
											}
										}
										ActiveUnit_Navigator navigator3 = theUnit.Navigator;
										double startLat3 = num68;
										double startLon3 = num69;
										double destLat3 = num70;
										double destLon3 = num71;
										float? samplingInterval_Deg3 = DegreeInterval_Finegrained;
										ReasonForInterrupt = 0;
										InterruptLocation = null;
										if (!navigator3.PathLineIsInterrupted(startLat3, startLon3, destLat3, destLon3, RunInParallel: false, 0f, CheckIfCurrentlyInsideIllegalArea: false, null, IsPathfindingQuery: false, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: false, samplingInterval_Deg3, ref ReasonForInterrupt, ref InterruptLocation))
										{
											num64 = num70;
											num65 = num71;
											continue;
										}
										List<Waypoint> list6 = Pathfinding.PathFinderCostBasedEngine.SolvePF_Finegrained(theUnit, num68, num69, num70, num71, CurrentHeading, 2f, ProximityThreshold_Deg, ref ProvidedPiers, ref PercentComplete, IsMissionPlannerRequest);
										if (list6 != null)
										{
											foreach (Waypoint item3 in list6)
											{
												if (!(Math.Abs(item3.Latitude - num70) < (double)DegreeInterval_Finegrained) || !(Math.Abs(item3.Longitude - num71) < (double)DegreeInterval_Finegrained))
												{
													list4.Add(item3);
													continue;
												}
												break;
											}
											num64 = num70;
											num65 = num71;
											continue;
										}
									}
									num64 = num23;
									num65 = num20;
								}
								list4.Add(new Waypoint(num20, num23, 0f, Waypoint.WaypointType.PathfindingPoint, Waypoint.WaypointCreator.Pathfinder, Waypoint.WaypointCategory.PlottedCourse));
							}
							result = list4;
						}
						else
						{
							result = null;
						}
						break;
					}
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
			ex6?.Data.Add("Error at 10133174040100013", "");
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

	private bool method_0(Mission mission_0, Geopoint_Struct[] geopoint_Struct_0, int int_0, int int_1, double double_0, double double_1)
	{
		if (geopoint_Struct_0 != null)
		{
			ConcurrentDictionary<(int, int), bool> orAdd = concurrentDictionary_0.GetOrAdd(mission_0.ObjectID, [SpecialName] (object k) => new ConcurrentDictionary<(int, int), bool>());
			(int, int) key = (int_0, int_1);
			if (!orAdd.TryGetValue(key, out var value))
			{
				return orAdd[key] = GeoPoint.PointInPolygonHorizRayCast(double_0, double_1, geopoint_Struct_0);
			}
			return value;
		}
		return true;
	}

	private void method_1(ref NavPathNode[,] navPathNode_0, int int_0, int int_1, int int_2, int int_3, int int_4, int int_5)
	{
		try
		{
			if (int_1 > 0 && navPathNode_0[int_0, int_1 - 1].MovementCost == int_2)
			{
				navPathNode_0[int_0, int_1].MovementCost = int_3;
			}
			else if (int_1 > 0 && int_0 < int_4 - 1 && navPathNode_0[int_0 + 1, int_1 - 1].MovementCost == int_2)
			{
				navPathNode_0[int_0, int_1].MovementCost = int_3;
			}
			else if (int_0 < int_4 - 1 && navPathNode_0[int_0 + 1, int_1].MovementCost == int_2)
			{
				navPathNode_0[int_0, int_1].MovementCost = int_3;
			}
			else if (int_1 < int_5 - 1 && int_0 < int_4 - 1 && navPathNode_0[int_0 + 1, int_1 + 1].MovementCost == int_2)
			{
				navPathNode_0[int_0, int_1].MovementCost = int_3;
			}
			else if (int_1 < int_5 - 1 && navPathNode_0[int_0, int_1 + 1].MovementCost == int_2)
			{
				navPathNode_0[int_0, int_1].MovementCost = int_3;
			}
			else if (int_1 < int_5 - 1 && int_0 > 0 && navPathNode_0[int_0 - 1, int_1 + 1].MovementCost == int_2)
			{
				navPathNode_0[int_0, int_1].MovementCost = int_3;
			}
			else if (int_0 > 0 && navPathNode_0[int_0 - 1, int_1].MovementCost == int_2)
			{
				navPathNode_0[int_0, int_1].MovementCost = int_3;
			}
			else if (int_1 > 0 && int_0 > 0 && navPathNode_0[int_0 - 1, int_1 - 1].MovementCost == int_2)
			{
				navPathNode_0[int_0, int_1].MovementCost = int_3;
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

	internal List<Waypoint> SolvePF_Finegrained(ActiveUnit theUnit, double StartLat, double StartLon, double EndLat, double EndLon, float CurrentHeading, float DegreeBuffer, float ProximityThreshold_Deg, ref List<ActiveUnit> ProvidedPiers, ref float PercentComplete, bool IsMissionPlannerRequest)
	{
		List<Waypoint> result;
		try
		{
			if (!theUnit.ParentScen.ThreadedOpsMustStop)
			{
				bool flag = Math2.LineCrossesAntimeridian(StartLat, StartLon, EndLat, EndLon);
				float num = Math.Min((float)(short)Math.Round(Math.Max(StartLat, EndLat)) + DegreeBuffer, 90f);
				float num2 = Math.Max((float)(short)Math.Round(Math.Min(StartLat, EndLat)) - DegreeBuffer, -90f);
				short num3 = (short)Math.Round(Math.Abs(num - num2) / DegreeInterval_Finegrained);
				float num4;
				float num5;
				short num6;
				if (flag)
				{
					num4 = (float)(short)Math.Round(Math.Min(StartLon, EndLon)) + DegreeBuffer;
					num5 = (float)(short)Math.Round(Math.Max(StartLon, EndLon)) - DegreeBuffer;
					num6 = Math.Abs((short)Math.Round((180f - Math.Abs(num4) + (180f - num5)) / DegreeInterval_Finegrained));
				}
				else
				{
					num4 = (float)(short)Math.Round(Math.Min(StartLon, EndLon)) - DegreeBuffer;
					num5 = (float)(short)Math.Round(Math.Max(StartLon, EndLon)) + DegreeBuffer;
					num6 = Math.Abs((short)Math.Round(Math.Abs(num5 - num4) / DegreeInterval_Finegrained));
				}
				long num7 = (long)num6 * (long)num3;
				Doctrine._NavigationMethod? navigationMethod;
				int num8;
				if (Information.IsNothing((object)theUnit))
				{
					navigationMethod = Doctrine._NavigationMethod.ShortestRoute;
					num8 = 1;
				}
				else if (theUnit.IsShip)
				{
					navigationMethod = theUnit.Doctrine.get_SurfaceNavigation(theUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
					num8 = 1;
				}
				else if (theUnit.IsSubmarine)
				{
					navigationMethod = theUnit.Doctrine.get_SubmarineNavigation(theUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
					num8 = 1;
				}
				else
				{
					if (theUnit.IsFacility)
					{
						throw new Exception();
					}
					navigationMethod = Doctrine._NavigationMethod.ShortestRoute;
					num8 = 1;
				}
				int i;
				for (i = num8; !(Math.Pow(2.0, i) > (double)num3) || !(Math.Pow(2.0, i) > (double)num6); i++)
				{
				}
				int num9 = (int)Math.Round(Math.Pow(2.0, i));
				int num10 = (int)Math.Round(Math.Pow(2.0, i));
				if (num10 > 2048)
				{
					result = SolvePF_Coarse(theUnit, StartLat, StartLon, EndLat, EndLon, CurrentHeading, DegreeBuffer, ProximityThreshold_Deg, ref ProvidedPiers, ref PercentComplete, IsMissionPlannerRequest, AllowFineGrainedNav: false);
				}
				else
				{
					Class15[,] class15_ = new Class15[num10 - 1 + 1, num9 - 1 + 1];
					int num11 = num6 - 1;
					int num12 = 0;
					short? nullable_ = default(short?);
					short? nullable_2 = default(short?);
					short short_ = default(short);
					short short_2 = default(short);
					int num26 = default(int);
					int num25 = default(int);
					long num14 = default(long);
					while (true)
					{
						double theLongitude;
						if (num12 > num11)
						{
							if (!nullable_.HasValue)
							{
								try
								{
									double num13 = double.MaxValue;
									GeoPoint geoPoint = new GeoPoint(StartLon, StartLat);
									num14 = 0L;
									float num15 = num;
									float degreeInterval_Finegrained = DegreeInterval_Finegrained;
									bool flag2 = degreeInterval_Finegrained >= 0f;
									for (float num16 = num2; (!flag2) ? (num16 >= num15) : (num16 <= num15); num16 += degreeInterval_Finegrained)
									{
										double num17 = geoPoint.RangeToPoint_Horiz_Angular(StartLon, num16);
										if (num17 < num13)
										{
											num13 = num17;
											nullable_ = (short)num14;
										}
										num14++;
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
									double num18 = double.MaxValue;
									GeoPoint geoPoint2 = new GeoPoint(StartLon, StartLat);
									num14 = 0L;
									float num19 = num4;
									float num20 = num5;
									float degreeInterval_Finegrained2 = DegreeInterval_Finegrained;
									bool flag3 = degreeInterval_Finegrained2 >= 0f;
									float num21 = num19;
									while (flag3 ? (num21 <= num20) : (num21 >= num20))
									{
										num21 = Math2.NormalizeLongitude(num21);
										double num22 = geoPoint2.RangeToPoint_Horiz_Angular(num21, StartLat);
										if (num22 < num18)
										{
											num18 = num22;
											nullable_2 = (short)num14;
										}
										num14++;
										num21 += degreeInterval_Finegrained2;
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
							NavPathNode[,] navPathNode_ = null;
							method_3(ref theUnit, ref nullable_2, ref nullable_, ref short_, ref short_2, ref navPathNode_, class15_, num6, num3);
							int num23 = 0;
							int num24 = 0;
							do
							{
								byte? b = (byte?)navigationMethod;
								if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)) == true)
								{
									switch (num24)
									{
									case 1:
										num25 = 300;
										break;
									case 0:
										num25 = 10000;
										num26 = 10000;
										break;
									}
								}
								else
								{
									switch (num24)
									{
									case 0:
										num25 = 20000;
										num26 = 20000;
										break;
									case 1:
										num25 = 15000;
										break;
									case 6:
										num25 = 10000;
										break;
									}
								}
								int num27 = num6 - 1;
								for (int j = 0; j <= num27; j++)
								{
									int num28 = num3 - 1;
									for (int k = 0; k <= num28; k++)
									{
										if (class15_[j, k].int_0 != 0 && (num23 <= 0 || class15_[j, k].int_0 < num23))
										{
											method_2(ref class15_, j, k, num23, num25, num6, num3);
										}
									}
								}
								num23 = num25;
								num25--;
								num24++;
							}
							while (num24 <= 9);
							if (theUnit.IsSubmarine || theUnit.IsShip)
							{
								List<int> list = new List<int>();
								Doctrine._NavigationMethod? navigationMethod2 = navigationMethod;
								byte? b = (byte?)navigationMethod2;
								if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)) != true)
								{
									b = (byte?)navigationMethod2;
									if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 5)) != true)
									{
										list.Add(6000);
										list.Add(3000);
										list.Add(1500);
									}
								}
								else
								{
									list.Add(50);
									list.Add(60);
									list.Add(70);
									list.Add(80);
									list.Add(90);
								}
								num14 = list.Count;
								long num29 = num14 - 1L;
								for (long num30 = 0L; num30 <= num29; num30++)
								{
									num25 = list[(int)num30];
									b = (byte?)navigationMethod;
									if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)) != true)
									{
										int num31 = 0;
										do
										{
											int num32 = num6 - 1;
											for (int l = 0; l <= num32; l++)
											{
												int num33 = num3 - 1;
												for (int m = 0; m <= num33; m++)
												{
													if (class15_[l, m].int_0 != 0 && class15_[l, m].int_0 < num23)
													{
														method_2(ref class15_, l, m, num23, num25, num6, num3);
													}
												}
											}
											num23 = num25;
											num25--;
											num31++;
										}
										while (num31 <= 9);
										continue;
									}
									int num34 = 0;
									do
									{
										int num35 = num6 - 1;
										for (int n = 0; n <= num35; n++)
										{
											int num36 = num3 - 1;
											for (int num37 = 0; num37 <= num36; num37++)
											{
												if (class15_[n, num37].int_0 != 0 && class15_[n, num37].int_0 != num26 && (class15_[n, num37].int_0 > 300 || class15_[n, num37].int_0 <= 290) && (num23 >= 100 || class15_[n, num37].int_0 > num23))
												{
													method_2(ref class15_, n, num37, num23, num25, num6, num3);
												}
											}
										}
										num23 = num25;
										num25++;
										num34++;
									}
									while (num34 <= 9);
								}
							}
							int[,] array = new int[num10 - 1 + 1, num9 - 1 + 1];
							int num38 = num10 - 1;
							for (int num39 = 0; num39 <= num38; num39++)
							{
								int num40 = num9 - 1;
								for (int num41 = 0; num41 <= num40; num41++)
								{
									if (Information.IsNothing((object)class15_[num39, num41]))
									{
										array[num39, num41] = 0;
									}
									else
									{
										array[num39, num41] = class15_[num39, num41].int_0;
									}
								}
							}
							class15_ = null;
							PathFinderFast pathFinderFast = new PathFinderFast(array);
							pathFinderFast.Formula = HeuristicFormula.Manhattan;
							if (theUnit.IsFacility)
							{
								pathFinderFast.Formula = HeuristicFormula.EuclideanNoSQR;
							}
							pathFinderFast.Diagonals = true;
							pathFinderFast.HeavyDiagonals = false;
							pathFinderFast.PunishChangeDirection = false;
							pathFinderFast.PunishWalkingOnEdge = true;
							pathFinderFast.TrimAutoNavPoints = true;
							pathFinderFast.TieBreaker = true;
							pathFinderFast.SearchLimit = int.MaxValue;
							pathFinderFast.DebugProgress = false;
							pathFinderFast.ReopenCloseNodes = true;
							pathFinderFast.EdgeCost = num26;
							List<PathFinderNode> list2 = pathFinderFast.FindPath(new Point(nullable_2.Value, nullable_.Value), new Point(short_, short_2));
							if (Information.IsNothing((object)list2))
							{
								result = null;
								break;
							}
							List<Waypoint> list3 = new List<Waypoint>();
							list2.Reverse();
							foreach (PathFinderNode item in list2)
							{
								theLongitude = (flag ? ((double)Math2.NormalizeLongitude(num4 - (float)item.X * DegreeInterval_Finegrained)) : ((double)Math2.NormalizeLongitude(num4 + (float)item.X * DegreeInterval_Finegrained)));
								double theLatitude = Math2.NormalizeLatitude(num2 + (float)item.Y * DegreeInterval_Finegrained);
								list3.Add(new Waypoint(theLongitude, theLatitude, 0f, Waypoint.WaypointType.PathfindingPoint, Waypoint.WaypointCreator.Pathfinder, Waypoint.WaypointCategory.PlottedCourse));
							}
							result = list3;
							break;
						}
						theLongitude = (flag ? ((double)Math2.NormalizeLongitude(num4 - (float)num12 * DegreeInterval_Finegrained)) : ((double)Math2.NormalizeLongitude(num4 + (float)num12 * DegreeInterval_Finegrained)));
						int num42 = num3 - 1;
						int num43 = 0;
						while (true)
						{
							if (num43 <= num42)
							{
								if (theUnit != null)
								{
									Scenario parentScen = theUnit.ParentScen;
									if (parentScen != null && parentScen.ThreadedOpsMustStop)
									{
										result = null;
										goto end_IL_0711;
									}
								}
								if (IsMissionPlannerRequest || !theUnit.IsMorituri)
								{
									double theLatitude = Math2.NormalizeLatitude(num2 + (float)num43 * DegreeInterval_Finegrained);
									Class15 @class = new Class15(theLatitude, theLongitude);
									@class.float_2 = ProximityThreshold_Deg;
									@class.list_0 = ProvidedPiers;
									if (!@class.method_1(theUnit))
									{
										@class.int_0 = 0;
									}
									else
									{
										int int_;
										if (theUnit.IsShip)
										{
											short num44 = @class.method_0(theUnit.ParentScen);
											Doctrine._NavigationMethod? navigationMethod3 = navigationMethod;
											byte? b = (byte?)navigationMethod3;
											if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
											{
												int_ = ((num44 >= -50) ? 1000 : ((num44 >= -200) ? 600 : ((num44 >= -305) ? 300 : ((num44 >= -365) ? 300 : ((num44 >= -1000) ? 300 : ((num44 < -1525) ? 100 : 300))))));
											}
											else
											{
												b = (byte?)navigationMethod3;
												int_ = ((((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)) != true) ? 100 : ((num44 < -200) ? 1000 : 100));
											}
										}
										else if (!theUnit.IsSubmarine)
										{
											if (theUnit.IsFacility)
											{
												throw new Exception();
											}
											int_ = 100;
										}
										else
										{
											short num44 = @class.method_0(theUnit.ParentScen);
											Doctrine._NavigationMethod? navigationMethod4 = navigationMethod;
											byte? b = (byte?)navigationMethod4;
											if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 3)) == true)
											{
												int_ = ((num44 >= -40) ? 1000 : ((num44 < -300) ? 100 : 300));
											}
											else
											{
												b = (byte?)navigationMethod4;
												if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 4)) == true)
												{
													int_ = ((num44 >= -40) ? 1000 : ((num44 >= -200) ? 600 : ((num44 < -300) ? 100 : 300)));
												}
												else
												{
													b = (byte?)navigationMethod4;
													int_ = ((((!b.HasValue) ? ((bool?)null) : new bool?(b == 5)) != true) ? 100 : ((num44 >= -40) ? 1000 : ((num44 < -300) ? 1000 : 100)));
												}
											}
										}
										@class.int_0 = int_;
										if (Math.Abs(StartLon - theLongitude) < (double)DegreeInterval_Finegrained && (!nullable_2.HasValue || Math.Abs(MathFunctions.AngularDifference(CurrentHeading, Math2.CalcAzimuth(StartLat, StartLon, theLatitude, theLongitude))) < 90f))
										{
											nullable_2 = (short)num12;
										}
										if (Math.Abs(EndLon - theLongitude) < (double)DegreeInterval_Finegrained)
										{
											short_ = (short)num12;
										}
										if (Math.Abs(StartLat - theLatitude) < (double)DegreeInterval_Finegrained && (!nullable_.HasValue || Math.Abs(MathFunctions.AngularDifference(CurrentHeading, Math2.CalcAzimuth(StartLat, StartLon, theLatitude, theLongitude))) < 90f))
										{
											nullable_ = (short)num43;
										}
										if (Math.Abs(EndLat - theLatitude) < (double)DegreeInterval_Finegrained)
										{
											short_2 = (short)num43;
										}
									}
									class15_[num12, num43] = @class;
									num14++;
									num43++;
									continue;
								}
								result = null;
								goto end_IL_0711;
							}
							PercentComplete = (float)((double)num14 / (double)num7);
							num12++;
							break;
						}
						continue;
						end_IL_0711:
						break;
					}
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
		return result;
	}

	List<Waypoint> GInterface1.SolvePF_Finegrained(ActiveUnit theUnit, double StartLat, double StartLon, double EndLat, double EndLon, float CurrentHeading, float DegreeBuffer, float ProximityThreshold_Deg, ref List<ActiveUnit> ProvidedPiers, ref float PercentComplete, bool IsMissionPlannerRequest)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SolvePF_Finegrained
		return this.SolvePF_Finegrained(theUnit, StartLat, StartLon, EndLat, EndLon, CurrentHeading, DegreeBuffer, ProximityThreshold_Deg, ref ProvidedPiers, ref PercentComplete, IsMissionPlannerRequest);
	}

	private void method_2(ref Class15[,] class15_0, int int_0, int int_1, int int_2, int int_3, int int_4, int int_5)
	{
		try
		{
			if (int_1 > 0 && class15_0[int_0, int_1 - 1].int_0 == int_2)
			{
				class15_0[int_0, int_1].int_0 = int_3;
			}
			else if (int_1 > 0 && int_0 < int_4 - 1 && class15_0[int_0 + 1, int_1 - 1].int_0 == int_2)
			{
				class15_0[int_0, int_1].int_0 = int_3;
			}
			else if (int_0 < int_4 - 1 && class15_0[int_0 + 1, int_1].int_0 == int_2)
			{
				class15_0[int_0, int_1].int_0 = int_3;
			}
			else if (int_1 < int_5 - 1 && int_0 < int_4 - 1 && class15_0[int_0 + 1, int_1 + 1].int_0 == int_2)
			{
				class15_0[int_0, int_1].int_0 = int_3;
			}
			else if (int_1 < int_5 - 1 && class15_0[int_0, int_1 + 1].int_0 == int_2)
			{
				class15_0[int_0, int_1].int_0 = int_3;
			}
			else if (int_1 < int_5 - 1 && int_0 > 0 && class15_0[int_0 - 1, int_1 + 1].int_0 == int_2)
			{
				class15_0[int_0, int_1].int_0 = int_3;
			}
			else if (int_0 > 0 && class15_0[int_0 - 1, int_1].int_0 == int_2)
			{
				class15_0[int_0, int_1].int_0 = int_3;
			}
			else if (int_1 > 0 && int_0 > 0 && class15_0[int_0 - 1, int_1 - 1].int_0 == int_2)
			{
				class15_0[int_0, int_1].int_0 = int_3;
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

	private void method_3(ref ActiveUnit activeUnit_0, ref short? nullable_0, ref short? nullable_1, ref short short_0, ref short short_1, ref NavPathNode[,] navPathNode_0, Class15[,] class15_0, short short_2, short short_3)
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
					if (!Information.IsNothing((object)navPathNode_0) && navPathNode_0[nullable_0.Value, nullable_1.Value].IsWalkable(activeUnit_0))
					{
						if (num6 != short_3 - 1 && navPathNode_0[num5, num6 + 1].IsWalkable(activeUnit_0))
						{
							num11++;
						}
						if (num6 != 0 && navPathNode_0[num5, num6 - 1].IsWalkable(activeUnit_0))
						{
							num11++;
						}
						if (num5 != 0 && navPathNode_0[num5 - 1, num6].IsWalkable(activeUnit_0))
						{
							num11++;
						}
						if (num5 != short_2 - 1 && navPathNode_0[num5 + 1, num6].IsWalkable(activeUnit_0))
						{
							num11++;
						}
					}
					else if (!Information.IsNothing((object)class15_0) && class15_0[nullable_0.Value, nullable_1.Value].method_1(activeUnit_0))
					{
						if (num6 != short_3 - 1 && class15_0[num5, num6 + 1].method_1(activeUnit_0))
						{
							num11++;
						}
						if (num6 != 0 && class15_0[num5, num6 - 1].method_1(activeUnit_0))
						{
							num11++;
						}
						if (num5 != 0 && class15_0[num5 - 1, num6].method_1(activeUnit_0))
						{
							num11++;
						}
						if (num5 != short_2 - 1 && class15_0[num5 + 1, num6].method_1(activeUnit_0))
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
						if (!Information.IsNothing((object)navPathNode_0))
						{
							navPathNode_0[num5, num6].IsNotWalkable();
						}
						if (!Information.IsNothing((object)class15_0))
						{
							class15_0[num5, num6].method_2();
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
									if (num22 >= 0 && num22 <= short_3 - 1 && (num18 == 0 || num18 == num13 - 1 || num21 == 0 || num21 == num13 - 1) && ((!Information.IsNothing((object)navPathNode_0) && navPathNode_0[num19, num22].IsWalkable(activeUnit_0)) || (!Information.IsNothing((object)class15_0) && class15_0[num19, num22].method_1(activeUnit_0))))
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
					if (!Information.IsNothing((object)navPathNode_0) && navPathNode_0[short_0, short_1].IsWalkable(activeUnit_0))
					{
						if (num8 != short_3 - 1 && navPathNode_0[num7, num8 + 1].IsWalkable(activeUnit_0))
						{
							num24++;
						}
						if (num8 != 0 && navPathNode_0[num7, num8 - 1].IsWalkable(activeUnit_0))
						{
							num24++;
						}
						if (num7 != 0 && navPathNode_0[num7 - 1, num8].IsWalkable(activeUnit_0))
						{
							num24++;
						}
						if (num7 != short_2 - 1 && navPathNode_0[num7 + 1, num8].IsWalkable(activeUnit_0))
						{
							num24++;
						}
					}
					else if (!Information.IsNothing((object)class15_0) && class15_0[short_0, short_1].method_1(activeUnit_0))
					{
						if (num8 != short_3 - 1 && class15_0[num7, num8 + 1].method_1(activeUnit_0))
						{
							num24++;
						}
						if (num8 != 0 && class15_0[num7, num8 - 1].method_1(activeUnit_0))
						{
							num24++;
						}
						if (num7 != 0 && class15_0[num7 - 1, num8].method_1(activeUnit_0))
						{
							num24++;
						}
						if (num7 != short_2 - 1 && class15_0[num7 + 1, num8].method_1(activeUnit_0))
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
						if (!Information.IsNothing((object)navPathNode_0))
						{
							navPathNode_0[num7, num8].IsNotWalkable();
						}
						if (!Information.IsNothing((object)class15_0))
						{
							class15_0[num7, num8].method_2();
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
									if (num35 >= 0 && num35 <= short_3 - 1 && (num31 == 0 || num31 == num26 - 1 || num34 == 0 || num34 == num26 - 1) && ((!Information.IsNothing((object)navPathNode_0) && navPathNode_0[num32, num35].IsWalkable(activeUnit_0)) || (!Information.IsNothing((object)class15_0) && class15_0[num32, num35].method_1(activeUnit_0))))
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
}
