using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Caching;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class Pathfinding
{
	[AccessedThroughProperty("BW1")]
	[CompilerGenerated]
	private static BackgroundWorker backgroundWorker_0;

	internal static PFCache_Array pfcache_Array_0;

	private static MemoryCache memoryCache_0;

	private static List<PathfindRequest> list_0;

	[CompilerGenerated]
	private static bool bool_0;

	internal static GInterface1 PathFinderSettlersEngine;

	internal static GInterface1 PathFinderCostBasedEngine;

	internal static GInterface1 GroundCostBasedEngine;

	private static string string_0;

	public static ConcurrentDictionary<string, ActiveUnit> CurrentRequests;

	private static LockObject lockObject_0;

	private static AutoResetEvent autoResetEvent_0;

	public static bool PFQueueIsBeingProcessed
	{
		get
		{
			return bool_0;
		}
		set
		{
			smethod_1(value);
		}
	}

	public static bool PFRequestsPending => list_0.Count > 0;

	static Pathfinding()
	{
		Class72.smethod_20();
		smethod_0(new BackgroundWorker());
		memoryCache_0 = MemoryCache.Default;
		list_0 = new List<PathfindRequest>();
		string_0 = "";
		CurrentRequests = new ConcurrentDictionary<string, ActiveUnit>();
		lockObject_0 = new LockObject();
		autoResetEvent_0 = new AutoResetEvent(initialState: false);
	}

	[SpecialName]
	[CompilerGenerated]
	private static void smethod_0(BackgroundWorker backgroundWorker_1)
	{
		DoWorkEventHandler value = smethod_2;
		BackgroundWorker backgroundWorker = backgroundWorker_0;
		if (backgroundWorker != null)
		{
			backgroundWorker.DoWork -= value;
		}
		backgroundWorker_0 = backgroundWorker_1;
		backgroundWorker = backgroundWorker_0;
		if (backgroundWorker != null)
		{
			backgroundWorker.DoWork += value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private static void smethod_1(bool bool_1)
	{
		bool_0 = bool_1;
	}

	public static void Initialize()
	{
		if (!backgroundWorker_0.IsBusy)
		{
			backgroundWorker_0.RunWorkerAsync();
		}
		PathFinderSettlersEngine = new SettlersEnginePathfinder();
		PathFinderCostBasedEngine = new CostBasedPathfinder();
		GroundCostBasedEngine = new GroundCostBasedPathfinder();
	}

	public static void LoadIntervalElevations()
	{
		if (!backgroundWorker_0.IsBusy)
		{
			backgroundWorker_0.RunWorkerAsync();
		}
	}

	private static void smethod_2(object sender, CancelEventArgs e)
	{
		pfcache_Array_0 = new PFCache_Array();
		while (!backgroundWorker_0.CancellationPending)
		{
			if (list_0.Count > 0)
			{
				try
				{
					smethod_1(bool_1: true);
					while (list_0.Count > 0)
					{
						PathfindRequest pathfindRequest = null;
						string_0 = "";
						lock (lockObject_0)
						{
							if (list_0.Count > 0)
							{
								list_0.Sort([SpecialName] (PathfindRequest i1, PathfindRequest i2) =>
								{
									if (i1 != null)
									{
										if (i2 != null)
										{
											return i1.Distance - i1.Age - (i2.Distance - i2.Age);
										}
										return 1;
									}
									return (i2 != null) ? (-1) : 0;
								});
								pathfindRequest = list_0[0];
								list_0.RemoveAt(0);
								int num = list_0.Count - 1;
								for (int num2 = 0; num2 <= num; num2++)
								{
									if (list_0[num2] != null)
									{
										list_0[num2].Age = list_0[num2].Age + 10;
									}
								}
							}
						}
						if (pathfindRequest == null || ((pathfindRequest.theUnit == null || pathfindRequest.theUnit.IsMorituri) && pathfindRequest.theFlightPlan == null))
						{
							continue;
						}
						try
						{
							if (pathfindRequest.theUnit != null)
							{
								if (!CurrentRequests.ContainsKey(pathfindRequest.theUnit.ObjectID))
								{
									CurrentRequests.TryAdd(pathfindRequest.theUnit.ObjectID, pathfindRequest.theUnit);
								}
								if (pathfindRequest.theUnit != null)
								{
									string_0 = pathfindRequest.theUnit.Name;
								}
								else
								{
									string_0 = "Unit has been destroyed";
								}
								pathfindRequest.theUnit.Navigator.StartPathfinding(pathfindRequest.StartWP, pathfindRequest.theUnit, null, theFlightPlanIngressPath: false, pathfindRequest.ProximityThreshold_Deg, pathfindRequest.DestLat, pathfindRequest.DestLon, pathfindRequest.theScenario, pathfindRequest.ManouverTowardsTarget);
								CurrentRequests.TryRemove(pathfindRequest.theUnit.ObjectID, out pathfindRequest.theUnit);
								pathfindRequest.theScenario.AddMessage(pathfindRequest.theUnit.Name + " path evaluation terminated", "Finished Path Evaluation for " + pathfindRequest.theUnit.Name, LoggedMessage.MessageType.UnitAI, 1, null);
							}
							else if (!Information.IsNothing((object)pathfindRequest.theFlightPlan) && !Information.IsNothing((object)pathfindRequest.theFlightPlan.get_ReferenceUnit(pathfindRequest.theScenario)))
							{
								pathfindRequest.theFlightPlan.get_ReferenceUnit(pathfindRequest.theScenario).Navigator.StartPathfinding(pathfindRequest.StartWP, null, pathfindRequest.theFlightPlan, pathfindRequest.theFlightPlanIngressPath, pathfindRequest.ProximityThreshold_Deg, pathfindRequest.DestLat, pathfindRequest.DestLon, pathfindRequest.theScenario, pathfindRequest.ManouverTowardsTarget);
								string_0 = "Strike mission flight plan";
							}
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception ex2 = ex;
							ex2?.Data.Add("Error at 200497", ex2.Message);
							GameGeneral.WriteExceptionsToLog(ex2);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					smethod_1(bool_1: false);
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					ex4?.Data.Add("Error at 101110", "");
					GameGeneral.WriteExceptionsToLog(ex4);
					int bool_;
					if (Debugger.IsAttached)
					{
						Debugger.Break();
						bool_ = 0;
					}
					else
					{
						bool_ = 0;
					}
					smethod_1((byte)bool_ != 0);
					ProjectData.ClearProjectError();
				}
			}
			else
			{
				autoResetEvent_0.WaitOne();
			}
		}
		e.Cancel = true;
	}

	public static void ClearAllPathfinderRequests()
	{
		lock (lockObject_0)
		{
			list_0.Clear();
		}
	}

	public static void SubmitPathfindRequest(PathfindRequest theReq, Scenario theScen)
	{
		lock (lockObject_0)
		{
			list_0.Add(theReq);
		}
		autoResetEvent_0.Set();
	}

	internal static int PathfindRequestCount()
	{
		return list_0.Count;
	}

	internal static string PathfindRequestCurrentUnit()
	{
		if (bool_0)
		{
			return string_0;
		}
		return null;
	}

	public static void CancelPathfindRequests(ActiveUnit theUnit, Mission.Flight theFlightPlan)
	{
		try
		{
			if (theUnit != null && CurrentRequests.ContainsKey(theUnit.ObjectID))
			{
				theUnit.Navigator.PathFindingAbortNextPath = true;
			}
			else
			{
				if (list_0.Count < 1)
				{
					return;
				}
				lock (lockObject_0)
				{
					int num = list_0.Count - 1;
					while (true)
					{
						if (num >= 0)
						{
							if (list_0[num] != null && ((theUnit != null && list_0[num].theUnit == theUnit) || (theFlightPlan != null && list_0[num].theFlightPlan == theFlightPlan)))
							{
								break;
							}
							num += -1;
							continue;
						}
						return;
					}
					list_0.RemoveAt(num);
					return;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200342", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal static bool UnitOrFlightPlanHasPFRequestInQueue(ActiveUnit theUnit, Mission.Flight FlightPlan, ref Exception ThrownError)
	{
		bool result;
		try
		{
			if (theUnit != null && CurrentRequests.ContainsKey(theUnit.ObjectID))
			{
				result = true;
			}
			else if (list_0.Count >= 1)
			{
				lock (lockObject_0)
				{
					for (int i = list_0.Count - 1; i >= 0; i += -1)
					{
						if (list_0[i] == null)
						{
							continue;
						}
						int num;
						if (theUnit == null || list_0[i].theUnit != theUnit)
						{
							if (FlightPlan == null || list_0[i].theFlightPlan != FlightPlan)
							{
								continue;
							}
							num = 1;
						}
						else
						{
							num = 1;
						}
						result = (byte)num != 0;
						goto end_IL_0001;
					}
				}
				result = false;
			}
			else
			{
				result = false;
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200335", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			int num2;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num2 = 1;
			}
			else
			{
				num2 = 1;
			}
			result = (byte)num2 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static void ProcessRequests(ref Scenario theScen)
	{
		throw new NotImplementedException();
	}
}
