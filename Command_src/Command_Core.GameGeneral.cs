using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Collections.Pooled;
using Command_Core.DAL;
using Command_Core.Lua;
using ConcurrentObservableCollections.ConcurrentObservableDictionary;
using CSMaterial;
using DarkUI.Collections;
using DarkUI.Forms;
using MapReduce.NET.CollectionsB;
using Microsoft.IO;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ServiceStack.Text;
using SevenZip;
using ThreadSafeCollections;

namespace Command_Core;

[StandardModule]
public sealed class GameGeneral
{
	public delegate void CoreToUIMessageEventHandler(string theMessage, string theHeader, Side theSide, MessageBoxMessageType theType);

	public enum MessageBoxMessageType
	{
		Information,
		Warning,
		ErrorMessage
	}

	public class CustomIconWrapper
	{
		public string Filename;

		public int IconSize;

		public bool Rotatable;

		public CustomIconWrapper(string file)
		{
			IconSize = -1;
			Filename = file;
		}

		public CustomIconWrapper(string file, int _IconSize, bool _Rotatable)
		{
			if (_IconSize != -1)
			{
				IconSize = Math.Max(Math.Min(_IconSize, 128), 8);
			}
			else
			{
				IconSize = -1;
			}
			Rotatable = _Rotatable;
			Filename = file.Replace("\r", "");
		}

		static CustomIconWrapper()
		{
			Class72.smethod_20();
		}
	}

	public enum FlightGroupFilterOptions
	{
		Equipment,
		Aircraft,
		FreeForAll,
		Advanced
	}

	public enum _ProLicenseTier
	{
		None
	}

	private class Class16 : IComparer<ActiveUnit>
	{
		public int Compare(ActiveUnit x, ActiveUnit y)
		{
			return y.TimeOnLastPulse.CompareTo(x.TimeOnLastPulse);
		}

		static Class16()
		{
			Class72.smethod_20();
		}
	}

	private enum Enum9
	{
		All
	}

	public class LoggedMessageComparer_SortByTimestampDescendingAndIncrementDescending : IComparer<LoggedMessage>
	{
		public int Compare(LoggedMessage x, LoggedMessage y)
		{
			int num = y.Timestamp_ticks.CompareTo(x.Timestamp_ticks);
			if (num == 0)
			{
				num = y.Increment.CompareTo(x.Increment);
			}
			return num;
		}

		static LoggedMessageComparer_SortByTimestampDescendingAndIncrementDescending()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__142-0
	{
		public ActiveUnit $VB$Local_theAUnit;

		public _Closure$__142-1 $VB$NonLocal_$VB$Closure_2;

		public _Closure$__142-0(_Closure$__142-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theAUnit = arg0.$VB$Local_theAUnit;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			if ($VB$Local_theAUnit != null)
			{
				smethod_0($VB$Local_theAUnit, $VB$NonLocal_$VB$Closure_2.$VB$Local_OffGridUnits, $VB$NonLocal_$VB$Closure_2.$VB$Local_elapsedTime);
			}
		}

		static _Closure$__142-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__142-1
	{
		public List<ActiveUnit> $VB$Local_OffGridUnits;

		public float $VB$Local_elapsedTime;

		public _Closure$__142-1(_Closure$__142-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_OffGridUnits = arg0.$VB$Local_OffGridUnits;
				$VB$Local_elapsedTime = arg0.$VB$Local_elapsedTime;
			}
		}

		static _Closure$__142-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__146-0
	{
		public List<ActiveUnit> $VB$Local_OffGridUnits;

		public _Closure$__146-1 $VB$NonLocal_$VB$Closure_2;

		public _Closure$__146-0(_Closure$__146-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_OffGridUnits = arg0.$VB$Local_OffGridUnits;
			}
		}

		[SpecialName]
		internal void _Lambda$__0(List<ActiveUnit> bucket)
		{
			foreach (ActiveUnit item in bucket)
			{
				Stopwatch stopwatch = new Stopwatch();
				stopwatch.Start();
				smethod_0(item, $VB$Local_OffGridUnits, $VB$NonLocal_$VB$Closure_2.$VB$Local_elapsedTime);
				stopwatch.Stop();
				item.TimeOnLastPulse = Math.Max(1L, stopwatch.ElapsedTicks);
			}
		}

		static _Closure$__146-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__146-1
	{
		public float $VB$Local_elapsedTime;

		public _Closure$__146-1(_Closure$__146-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_elapsedTime = arg0.$VB$Local_elapsedTime;
			}
		}

		static _Closure$__146-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__150-0
	{
		public Scenario $VB$Local_theScen;

		public PooledList<ActiveUnit> $VB$Local_ActiveUnitsList;

		public float $VB$Local_elapsedTime;

		public _Closure$__150-0(_Closure$__150-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theScen = arg0.$VB$Local_theScen;
				$VB$Local_ActiveUnitsList = arg0.$VB$Local_ActiveUnitsList;
				$VB$Local_elapsedTime = arg0.$VB$Local_elapsedTime;
			}
		}

		[SpecialName]
		internal void _Lambda$__0(Side theSide)
		{
			theSide.PrePulseHousekeeping($VB$Local_theScen);
		}

		static _Closure$__150-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__150-1
	{
		public TList<ActiveUnit> $VB$Local_theBag;

		public _Closure$__150-0 $VB$NonLocal_$VB$Closure_2;

		public _Closure$__150-1(_Closure$__150-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theBag = arg0.$VB$Local_theBag;
			}
		}

		[SpecialName]
		internal void _Lambda$__1(Tuple<int, int> range)
		{
			int item = range.Item1;
			int num = range.Item2 - 1;
			for (int i = item; i <= num; i++)
			{
				ActiveUnit activeUnit = $VB$NonLocal_$VB$Closure_2.$VB$Local_ActiveUnitsList[i];
				if (activeUnit == null)
				{
					continue;
				}
				try
				{
					if (!activeUnit.IsOperating())
					{
						activeUnit.Longitude_AtStartOfPulse = activeUnit.get_Longitude(GlobalVariables.ObjectFalse);
						activeUnit.Latitude_AtStartOfPulse = activeUnit.get_Latitude(GlobalVariables.ObjectFalse);
					}
					else
					{
						fastDictionary_0[activeUnit] = true;
						activeUnit.Longitude_AtStartOfPulse = activeUnit.get_Longitude(GlobalVariables.ObjectTrue);
						activeUnit.Latitude_AtStartOfPulse = activeUnit.get_Latitude(GlobalVariables.ObjectTrue);
					}
					activeUnit.AI.CalculatedDesiredPitchThisPulse = false;
					ActiveUnit_Sensory sensory = activeUnit.Sensory;
					ActiveUnit_Weaponry weaponry = activeUnit.Weaponry;
					activeUnit.PrePulseHousekeeping($VB$NonLocal_$VB$Closure_2.$VB$Local_elapsedTime, $VB$NonLocal_$VB$Closure_2.$VB$Local_theScen);
					sensory.AgeLocalAndPrivateContacts($VB$NonLocal_$VB$Closure_2.$VB$Local_elapsedTime);
					if ($VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.SecondIsChangingOnThisPulse && !activeUnit.IsGroup && fastDictionary_0[activeUnit])
					{
						Sensor[] sensors_Cached = activeUnit.Sensors_Cached;
						sensory.UpdateSensorsCountdown_PreDetection(sensors_Cached);
						sensory.method_27(activeUnit.MineCountermeasures);
						activeUnit.CommStuff.ClearAllCommLinks();
					}
					if (!activeUnit.IsWeapon)
					{
						activeUnit.Doctrine.ClearCachedParentDoctrine(ClearParentGroupDoctrine: false);
						Doctrine doctrine = activeUnit.Doctrine;
						bool UnitIsOperating = true;
						doctrine.GetParentDoctrine(ref UnitIsOperating);
					}
					sensory.Housekeeping_PrePulse($VB$NonLocal_$VB$Closure_2.$VB$Local_elapsedTime);
					weaponry.Housekeeping_PrePulse();
					if (activeUnit.IsWeapon)
					{
						Weapon obj = (Weapon)activeUnit;
						obj.ImpactsOnThisPulse_ActualUnit = obj.AboutToImpact_ActualTarget($VB$NonLocal_$VB$Closure_2.$VB$Local_elapsedTime);
						obj.ImpactsOnThisPulse_Contact = obj.AboutToImpact_Contact($VB$NonLocal_$VB$Closure_2.$VB$Local_elapsedTime);
					}
					if (activeUnit.IsFacility && ActiveUnit_DockingOps.HasPiers(activeUnit))
					{
						$VB$Local_theBag.Add(activeUnit);
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 101293A", "");
					WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
		}

		static _Closure$__150-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__150-2
	{
		public Side $VB$Local_theSide;

		public _Closure$__150-2(_Closure$__150-2 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theSide = arg0.$VB$Local_theSide;
			}
		}

		[SpecialName]
		internal bool _Lambda$__2(Weapon theW)
		{
			return ((ActiveUnit)theW).get_UnitSide(SetSideOnly: false) == $VB$Local_theSide;
		}

		static _Closure$__150-2()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__150-3
	{
		public Waypoint $VB$Local_theWp;

		public _Closure$__150-3(_Closure$__150-3 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theWp = arg0.$VB$Local_theWp;
			}
		}

		[SpecialName]
		internal bool _Lambda$__3(KeyValuePair<string, Contact> theC)
		{
			return Operators.CompareString(theC.Value.ObjectID, $VB$Local_theWp.TargeteeringList[0].Target_ContactObjectID, false) == 0;
		}

		static _Closure$__150-3()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__152-0
	{
		public Side $VB$Local_theSide;

		public _Closure$__152-0(_Closure$__152-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theSide = arg0.$VB$Local_theSide;
			}
		}

		[SpecialName]
		internal void _Lambda$__0(Tuple<int, int> range)
		{
			int item = range.Item1;
			int num = range.Item2 - 1;
			for (int i = item; i <= num; i++)
			{
				ActiveUnit activeUnit = $VB$Local_theSide.Units[i];
				if (activeUnit != null && !activeUnit.IsGroup)
				{
					activeUnit.CommStuff.ReceiveAndProcessTransmissions(1f);
				}
			}
		}

		[SpecialName]
		internal void _Lambda$__1(Tuple<int, int> range)
		{
			int item = range.Item1;
			int num = range.Item2 - 1;
			for (int i = item; i <= num; i++)
			{
				ActiveUnit activeUnit = $VB$Local_theSide.Units[i];
				if (activeUnit != null && !activeUnit.IsGroup)
				{
					activeUnit.Sensory.ApplyP2PContactOverrides();
				}
			}
		}

		static _Closure$__152-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__152-1
	{
		public List<ActiveUnit>[] $VB$Local_WorkerThreadUnitLists;

		public _Closure$__152-3 $VB$NonLocal_$VB$Closure_2;

		public _Closure$__152-1(_Closure$__152-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_WorkerThreadUnitLists = arg0.$VB$Local_WorkerThreadUnitLists;
			}
		}

		static _Closure$__152-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__152-2
	{
		public int $VB$Local_theIndex;

		public _Closure$__152-1 $VB$NonLocal_$VB$Closure_3;

		public _Closure$__152-2(_Closure$__152-2 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theIndex = arg0.$VB$Local_theIndex;
			}
		}

		[SpecialName]
		internal void _Lambda$__2()
		{
			List<ActiveUnit> list = $VB$NonLocal_$VB$Closure_3.$VB$Local_WorkerThreadUnitLists[$VB$Local_theIndex];
			foreach (ActiveUnit item in list)
			{
				ActiveUnit TheDetectingUnit = item;
				try
				{
					if (TheDetectingUnit == null)
					{
						break;
					}
					ActiveUnit_Sensory sensory = TheDetectingUnit.Sensory;
					TheDetectingUnit.Housekeeping_PostPulse($VB$NonLocal_$VB$Closure_3.$VB$NonLocal_$VB$Closure_2.$VB$Local_elapsedTime);
					sensory.Housekeeping_PostPulse($VB$NonLocal_$VB$Closure_3.$VB$NonLocal_$VB$Closure_2.$VB$Local_elapsedTime);
					if ($VB$NonLocal_$VB$Closure_3.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.SecondIsChangingOnThisPulse && !TheDetectingUnit.IsGroup)
					{
						sensory.UpdateSensorsCountdown_PostDetection(TheDetectingUnit.Sensors_Cached);
						if (TheDetectingUnit.IsSubmarine)
						{
							TheDetectingUnit.TimeSinceLastThreatDetection_ESM += $VB$NonLocal_$VB$Closure_3.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.ElapsedTimeSinceLastSecondChangeCheck;
						}
					}
					TheDetectingUnit.Sensors_Cached = null;
					TheDetectingUnit.MineCountermeasures = null;
					if (TheDetectingUnit.IsWeapon)
					{
						Contact myContact = TheDetectingUnit.AI.PrimaryTarget;
						if (myContact != null && myContact.ActualUnit != null && myContact.RemainingContinousTrackTime > 0f)
						{
							myContact.Age = 0f;
							ActiveUnit_Sensory.UpdateContactData(ref TheDetectingUnit, ref myContact, myContact.ActualUnit, ContactIsNew: false);
						}
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 983174140909_91", "");
					WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
		}

		static _Closure$__152-2()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__152-3
	{
		public float $VB$Local_elapsedTime;

		public Scenario $VB$Local_theScen;

		public _Closure$__152-3(_Closure$__152-3 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_elapsedTime = arg0.$VB$Local_elapsedTime;
				$VB$Local_theScen = arg0.$VB$Local_theScen;
			}
		}

		static _Closure$__152-3()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__173-0
	{
		public ActiveUnit $VB$Local_theAU;

		public _Closure$__173-0(_Closure$__173-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theAU = arg0.$VB$Local_theAU;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			string text = "";
			if (Operators.CompareString($VB$Local_theAU.Name, $VB$Local_theAU.UnitClass, false) != 0)
			{
				text = " (" + $VB$Local_theAU.UnitClass + ")";
			}
			string text2 = "";
			ActiveUnit actualDestinationHost = ((Aircraft)$VB$Local_theAU).AirOps.ActualDestinationHost;
			if (!Information.IsNothing((object)actualDestinationHost))
			{
				text2 = " (" + actualDestinationHost.Name + ")";
			}
			$VB$Local_theAU.ParentScen.AddMessage($VB$Local_theAU.Name + text + " is returning to base" + text2, $VB$Local_theAU.Name + "is RTB", LoggedMessage.MessageType.AirOps, 5, $VB$Local_theAU.ObjectID, $VB$Local_theAU.get_UnitSide(SetSideOnly: false), new Geopoint_Struct($VB$Local_theAU.get_Longitude((GlobalVariables.BooleanObject)null), $VB$Local_theAU.get_Latitude((GlobalVariables.BooleanObject)null)));
		}

		static _Closure$__173-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__179-0
	{
		public int $VB$Local_theDBID;

		public _Closure$__179-0(_Closure$__179-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theDBID = arg0.$VB$Local_theDBID;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(Aircraft theAC)
		{
			return theAC.DBID == $VB$Local_theDBID;
		}

		static _Closure$__179-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__179-1
	{
		public int $VB$Local_theLoadoutDBID;

		public _Closure$__179-0 $VB$NonLocal_$VB$Closure_2;

		public Func<Aircraft, bool> $I5;

		public Func<Aircraft, bool> $I8;

		public Func<Aircraft, bool> $I11;

		public Func<Aircraft, bool> $I12;

		public Func<Aircraft, bool> $I13;

		public Func<Aircraft, bool> $I14;

		public Func<Aircraft, bool> $I15;

		public Func<Aircraft, bool> $I16;

		public Func<Aircraft, bool> $I17;

		public _Closure$__179-1(_Closure$__179-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theLoadoutDBID = arg0.$VB$Local_theLoadoutDBID;
			}
		}

		[SpecialName]
		internal bool _Lambda$__1(Aircraft theAC)
		{
			if (Information.IsNothing((object)theAC.Loadout))
			{
				return false;
			}
			return theAC.Loadout.DBID == $VB$Local_theLoadoutDBID;
		}

		[SpecialName]
		internal bool _Lambda$__4(Aircraft a)
		{
			if (!Information.IsNothing((object)a.Loadout))
			{
				return a.Loadout.DBID == $VB$Local_theLoadoutDBID;
			}
			return false;
		}

		[SpecialName]
		internal bool _Lambda$__5(Aircraft theAC)
		{
			if (!Information.IsNothing((object)theAC.Loadout))
			{
				return theAC.Loadout.DBID == $VB$Local_theLoadoutDBID;
			}
			return false;
		}

		[SpecialName]
		internal bool _Lambda$__8(Aircraft a)
		{
			if (Information.IsNothing((object)a.Loadout))
			{
				return false;
			}
			return a.Loadout.DBID == $VB$Local_theLoadoutDBID;
		}

		[SpecialName]
		internal bool _Lambda$__11(Aircraft theAC)
		{
			if (Information.IsNothing((object)theAC.Loadout))
			{
				return false;
			}
			return theAC.Loadout.DBID == $VB$Local_theLoadoutDBID;
		}

		[SpecialName]
		internal bool _Lambda$__12(Aircraft theAC)
		{
			int result;
			int result2;
			if (Information.IsNothing((object)theAC.Loadout))
			{
				result = 0;
			}
			else
			{
				if (theAC.Loadout.DBID == $VB$Local_theLoadoutDBID)
				{
					if (theAC.AirOps.IsTakingOff)
					{
						goto IL_00cc;
					}
					if (!theAC.IsOperating() || ((ActiveUnit)theAC).IsRTB || theAC.Navigator.IsOnAutoPlannerPlottedCourse_StationEgressRun)
					{
						goto IL_008f;
					}
					if (!theAC.IsGroupWingman())
					{
						result2 = 1;
					}
					else
					{
						if (Information.IsNothing((object)((ActiveUnit)theAC).get_ParentGroup(UsingMissionPlanner: false).GroupLead))
						{
							goto IL_00cc;
						}
						if (((ActiveUnit)theAC).get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.IsOnAutoPlannerPlottedCourse_StationEgressRun)
						{
							goto IL_008f;
						}
						result2 = 1;
					}
					goto IL_00cd;
				}
				result = 0;
			}
			return (byte)result != 0;
			IL_008f:
			int result3;
			if (theAC.Navigator.HasFlightPlan)
			{
				if (Information.IsNothing((object)((ActiveUnit_Navigator)theAC.Navigator).get_Flight(HierarchySearch: true).FlightPlan[0].Time_Zulu))
				{
					return theAC.IsReadyForTakeOff();
				}
				result3 = 0;
			}
			else
			{
				result3 = 0;
			}
			return (byte)result3 != 0;
			IL_00cc:
			result2 = 1;
			goto IL_00cd;
			IL_00cd:
			return (byte)result2 != 0;
		}

		[SpecialName]
		internal bool _Lambda$__13(Aircraft a)
		{
			if (Information.IsNothing((object)a.Loadout))
			{
				return false;
			}
			return a.Loadout.DBID == $VB$Local_theLoadoutDBID;
		}

		[SpecialName]
		internal bool _Lambda$__14(Aircraft theAC)
		{
			if (!Information.IsNothing((object)theAC.Loadout))
			{
				return theAC.Loadout.DBID == $VB$Local_theLoadoutDBID;
			}
			return false;
		}

		[SpecialName]
		internal bool _Lambda$__15(Aircraft a)
		{
			if (!Information.IsNothing((object)a.Loadout))
			{
				return a.Loadout.DBID == $VB$Local_theLoadoutDBID;
			}
			return false;
		}

		[SpecialName]
		internal bool _Lambda$__16(Aircraft theAC)
		{
			int result;
			int result2;
			if (Information.IsNothing((object)theAC.Loadout))
			{
				result = 0;
			}
			else
			{
				if (theAC.Loadout.DBID == $VB$Local_theLoadoutDBID)
				{
					if (!theAC.AirOps.IsTakingOff)
					{
						if (theAC.IsOperating() && !((ActiveUnit)theAC).IsRTB && !theAC.Navigator.IsOnAutoPlannerPlottedCourse_StationEgressRun)
						{
							if (!theAC.IsGroupWingman() || Information.IsNothing((object)((ActiveUnit)theAC).get_ParentGroup(UsingMissionPlanner: false).GroupLead))
							{
								goto IL_00c6;
							}
							if (!((ActiveUnit)theAC).get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.IsOnAutoPlannerPlottedCourse_StationEgressRun)
							{
								result2 = 1;
								goto IL_00c7;
							}
						}
						if (theAC.Navigator.HasFlightPlan && Information.IsNothing((object)((ActiveUnit_Navigator)theAC.Navigator).get_Flight(HierarchySearch: true).FlightPlan[0].Time_Zulu))
						{
							return theAC.IsReadyForTakeOff();
						}
						return false;
					}
					goto IL_00c6;
				}
				result = 0;
			}
			return (byte)result != 0;
			IL_00c6:
			result2 = 1;
			goto IL_00c7;
			IL_00c7:
			return (byte)result2 != 0;
		}

		[SpecialName]
		internal bool _Lambda$__17(Aircraft a)
		{
			if (Information.IsNothing((object)a.Loadout))
			{
				return false;
			}
			return a.Loadout.DBID == $VB$Local_theLoadoutDBID;
		}

		static _Closure$__179-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__179-2
	{
		public ActiveUnit $VB$Local_theHost;

		public _Closure$__179-1 $VB$NonLocal_$VB$Closure_3;

		public _Closure$__179-2(_Closure$__179-2 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theHost = arg0.$VB$Local_theHost;
			}
		}

		[SpecialName]
		internal bool _Lambda$__9(Aircraft theAC)
		{
			int result;
			if (theAC.DBID == $VB$NonLocal_$VB$Closure_3.$VB$NonLocal_$VB$Closure_2.$VB$Local_theDBID)
			{
				if (Information.IsNothing((object)theAC.Loadout))
				{
					result = 0;
					goto IL_0067;
				}
				if (theAC.Loadout.DBID == $VB$NonLocal_$VB$Closure_3.$VB$Local_theLoadoutDBID && !Information.IsNothing((object)theAC.AirOps.CurrentHostUnit))
				{
					return theAC.AirOps.CurrentHostUnit == $VB$Local_theHost;
				}
			}
			result = 0;
			goto IL_0067;
			IL_0067:
			return (byte)result != 0;
		}

		[SpecialName]
		internal bool _Lambda$__10(Aircraft theAC)
		{
			int result;
			if (theAC.DBID == $VB$NonLocal_$VB$Closure_3.$VB$NonLocal_$VB$Closure_2.$VB$Local_theDBID && !Information.IsNothing((object)theAC.Loadout) && theAC.Loadout.DBID == $VB$NonLocal_$VB$Closure_3.$VB$Local_theLoadoutDBID)
			{
				if (!Information.IsNothing((object)theAC.AirOps.CurrentHostUnit))
				{
					return theAC.AirOps.CurrentHostUnit == $VB$Local_theHost;
				}
				result = 0;
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}

		static _Closure$__179-2()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__179-3
	{
		public int $VB$Local_theDBID;

		public _Closure$__179-3(_Closure$__179-3 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theDBID = arg0.$VB$Local_theDBID;
			}
		}

		[SpecialName]
		internal bool _Lambda$__18(Aircraft theAC)
		{
			return theAC.DBID == $VB$Local_theDBID;
		}

		[SpecialName]
		internal bool _Lambda$__21(Aircraft a)
		{
			return a.DBID == $VB$Local_theDBID;
		}

		[SpecialName]
		internal bool _Lambda$__22(Aircraft theAC)
		{
			return theAC.DBID == $VB$Local_theDBID;
		}

		static _Closure$__179-3()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__180-0
	{
		public Aircraft $VB$Local_ac;

		public _Closure$__180-0(_Closure$__180-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_ac = arg0.$VB$Local_ac;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(Aircraft u)
		{
			return u.Loadout.DBID == $VB$Local_ac.Loadout.DBID;
		}

		static _Closure$__180-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__181-0
	{
		public Aircraft $VB$Local_theMissionAC;

		public _Closure$__181-0(_Closure$__181-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theMissionAC = arg0.$VB$Local_theMissionAC;
			}
		}

		[SpecialName]
		internal float _Lambda$__0(Module_Unit.Unit t)
		{
			Geopoint_Struct Point = t.Location;
			Geopoint_Struct Point2 = $VB$Local_theMissionAC.Location;
			return Math2.CalcDist(ref Point, ref Point2);
		}

		static _Closure$__181-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__181-1
	{
		public Contact $VB$Local_theContact;

		public _Closure$__181-1(_Closure$__181-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theContact = arg0.$VB$Local_theContact;
			}
		}

		[SpecialName]
		internal bool _Lambda$__1(KeyValuePair<Side, Misc.PostureStance> theKVP)
		{
			return theKVP.Key == $VB$Local_theContact.ActualUnit.get_UnitSide(SetSideOnly: false);
		}

		static _Closure$__181-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__186-0
	{
		public ActiveUnit $VB$Local_theAircraftHost;

		public _Closure$__186-0(_Closure$__186-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theAircraftHost = arg0.$VB$Local_theAircraftHost;
			}
		}

		[SpecialName]
		internal bool _Lambda$__2(Aircraft ac)
		{
			return ac.AirOps.CurrentHostUnit == $VB$Local_theAircraftHost;
		}

		static _Closure$__186-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__186-1
	{
		public int $VB$Local_dbid;

		public _Closure$__186-1(_Closure$__186-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_dbid = arg0.$VB$Local_dbid;
			}
		}

		[SpecialName]
		internal bool _Lambda$__3(Aircraft ac)
		{
			if (ac.Loadout == null)
			{
				return false;
			}
			return ac.Loadout.DBID == $VB$Local_dbid;
		}

		static _Closure$__186-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__186-10
	{
		public ActiveUnit $VB$Local_theAircraftHost;

		public _Closure$__186-10(_Closure$__186-10 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theAircraftHost = arg0.$VB$Local_theAircraftHost;
			}
		}

		static _Closure$__186-10()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__186-2
	{
		public int $VB$Local_dbid;

		public _Closure$__186-2(_Closure$__186-2 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_dbid = arg0.$VB$Local_dbid;
			}
		}

		[SpecialName]
		internal bool _Lambda$__4(Aircraft ac)
		{
			return ac.DBID == $VB$Local_dbid;
		}

		static _Closure$__186-2()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__186-3
	{
		public int $VB$Local_theLoadoutDBID;

		public _Closure$__186-4 $VB$NonLocal_$VB$Closure_3;

		public _Closure$__186-3(_Closure$__186-3 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theLoadoutDBID = arg0.$VB$Local_theLoadoutDBID;
			}
		}

		[SpecialName]
		internal bool _Lambda$__6(Aircraft theAC)
		{
			int result;
			if (!Information.IsNothing((object)theAC.Loadout))
			{
				if (theAC.Loadout.DBID == $VB$Local_theLoadoutDBID && !Information.IsNothing((object)theAC.AirOps.CurrentHostUnit))
				{
					return theAC.AirOps.CurrentHostUnit == $VB$NonLocal_$VB$Closure_3.$VB$Local_theAircraftHost;
				}
				result = 0;
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}

		static _Closure$__186-3()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__186-4
	{
		public ActiveUnit $VB$Local_theAircraftHost;

		public _Closure$__186-5 $VB$NonLocal_$VB$Closure_2;

		public Func<Aircraft, bool> $I7;

		public Func<Aircraft, bool> $I8;

		public _Closure$__186-4(_Closure$__186-4 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theAircraftHost = arg0.$VB$Local_theAircraftHost;
			}
		}

		[SpecialName]
		internal bool _Lambda$__7(Aircraft theAC)
		{
			if (Information.IsNothing((object)theAC.AirOps.CurrentHostUnit))
			{
				return false;
			}
			return theAC.AirOps.CurrentHostUnit == $VB$Local_theAircraftHost;
		}

		[SpecialName]
		internal bool _Lambda$__8(Aircraft theAC)
		{
			if ((theAC.DBID == $VB$NonLocal_$VB$Closure_2.$VB$Local_MissionDBID) & !Information.IsNothing((object)theAC.AirOps.CurrentHostUnit))
			{
				return theAC.AirOps.CurrentHostUnit == $VB$Local_theAircraftHost;
			}
			return false;
		}

		static _Closure$__186-4()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__186-5
	{
		public int $VB$Local_MissionDBID;

		public _Closure$__186-5(_Closure$__186-5 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_MissionDBID = arg0.$VB$Local_MissionDBID;
			}
		}

		static _Closure$__186-5()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__186-6
	{
		public int $VB$Local_GroupID;

		public _Closure$__186-3 $VB$NonLocal_$VB$Closure_4;

		public _Closure$__186-6(_Closure$__186-6 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_GroupID = arg0.$VB$Local_GroupID;
			}
		}

		[SpecialName]
		internal bool _Lambda$__9(Aircraft theAC)
		{
			if (!(MissionPlanner.CheckACForGroupMembership(theAC.DBID, theAC.LoadoutDBID, $VB$Local_GroupID) & !Information.IsNothing((object)theAC.AirOps.CurrentHostUnit)))
			{
				return false;
			}
			return theAC.AirOps.CurrentHostUnit == $VB$NonLocal_$VB$Closure_4.$VB$NonLocal_$VB$Closure_3.$VB$Local_theAircraftHost;
		}

		static _Closure$__186-6()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__186-7
	{
		public int $VB$Local_theLoadoutDBID;

		public _Closure$__186-8 $VB$NonLocal_$VB$Closure_5;

		public _Closure$__186-7(_Closure$__186-7 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theLoadoutDBID = arg0.$VB$Local_theLoadoutDBID;
			}
		}

		[SpecialName]
		internal bool _Lambda$__11(Aircraft theAC)
		{
			int result;
			if (!Information.IsNothing((object)theAC.Loadout) && theAC.Loadout.DBID == $VB$Local_theLoadoutDBID)
			{
				if (!Information.IsNothing((object)theAC.AirOps.CurrentHostUnit))
				{
					return theAC.AirOps.CurrentHostUnit == $VB$NonLocal_$VB$Closure_5.$VB$Local_theAircraftHost;
				}
				result = 0;
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}

		[SpecialName]
		internal bool _Lambda$__12(Aircraft theAC)
		{
			int result;
			if (!Information.IsNothing((object)theAC.Loadout))
			{
				if (theAC.Loadout.DBID == $VB$Local_theLoadoutDBID && !Information.IsNothing((object)theAC.AirOps.CurrentHostUnit) && theAC.AirOps.CurrentHostUnit == $VB$NonLocal_$VB$Closure_5.$VB$Local_theAircraftHost)
				{
					return !theAC.Loadout.IsSupportOrPatrol;
				}
				result = 0;
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}

		[SpecialName]
		internal bool _Lambda$__13(Aircraft theAC)
		{
			int result;
			if (!Information.IsNothing((object)theAC.Loadout) && theAC.Loadout.DBID == $VB$Local_theLoadoutDBID)
			{
				if (Information.IsNothing((object)theAC.AirOps.CurrentHostUnit))
				{
					result = 0;
					goto IL_005a;
				}
				if (theAC.AirOps.CurrentHostUnit == $VB$NonLocal_$VB$Closure_5.$VB$Local_theAircraftHost)
				{
					return theAC.Loadout.IsSupportOrPatrol;
				}
			}
			result = 0;
			goto IL_005a;
			IL_005a:
			return (byte)result != 0;
		}

		static _Closure$__186-7()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__186-8
	{
		public ActiveUnit $VB$Local_theAircraftHost;

		public _Closure$__186-8(_Closure$__186-8 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theAircraftHost = arg0.$VB$Local_theAircraftHost;
			}
		}

		static _Closure$__186-8()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__186-9
	{
		public int $VB$Local_theLoadoutDBID;

		public _Closure$__186-10 $VB$NonLocal_$VB$Closure_6;

		public _Closure$__186-9(_Closure$__186-9 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theLoadoutDBID = arg0.$VB$Local_theLoadoutDBID;
			}
		}

		[SpecialName]
		internal bool _Lambda$__14(Aircraft theAC)
		{
			int result;
			if (!Information.IsNothing((object)theAC.Loadout))
			{
				if (theAC.Loadout.DBID == $VB$Local_theLoadoutDBID)
				{
					if (!Information.IsNothing((object)theAC.AirOps.CurrentHostUnit))
					{
						return theAC.AirOps.CurrentHostUnit == $VB$NonLocal_$VB$Closure_6.$VB$Local_theAircraftHost;
					}
					result = 0;
				}
				else
				{
					result = 0;
				}
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}

		static _Closure$__186-9()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__192-0
	{
		public ActiveUnit $VB$Local_theMissionUnit;

		public _Closure$__192-1 $VB$NonLocal_$VB$Closure_2;

		public _Closure$__192-0(_Closure$__192-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theMissionUnit = arg0.$VB$Local_theMissionUnit;
			}
		}

		static _Closure$__192-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__192-1
	{
		public Mission $VB$Local_theMission;

		public _Closure$__192-1(_Closure$__192-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theMission = arg0.$VB$Local_theMission;
			}
		}

		static _Closure$__192-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__192-2
	{
		public Doctrine._UseShootTourists? $VB$Local_Doctrine_ShootTourists;

		public _Closure$__192-0 $VB$NonLocal_$VB$Closure_3;

		public _Closure$__192-2(_Closure$__192-2 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_Doctrine_ShootTourists = arg0.$VB$Local_Doctrine_ShootTourists;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(Contact theC)
		{
			ActiveUnit_AI aI = $VB$NonLocal_$VB$Closure_3.$VB$Local_theMissionUnit.AI;
			Mission theMission = $VB$NonLocal_$VB$Closure_3.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMission;
			Doctrine._UseShootTourists? canShootTourists = $VB$Local_Doctrine_ShootTourists;
			string Feedback = "";
			int FeedbackSeverity = 0;
			return aI.ContactIsRelevantToFlightOrMission(theC, theMission, canShootTourists, IgnoreContacStance: false, MyUnitIsInsidePatrolArea: false, IgnoreNeutralContacts: true, null, ref Feedback, ref FeedbackSeverity, null, IgnoreMissionSpecificTargetList: true);
		}

		static _Closure$__192-2()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__193-0
	{
		public ActiveUnit $VB$Local_theMissionUnit;

		public _Closure$__193-1 $VB$NonLocal_$VB$Closure_2;

		public _Closure$__193-0(_Closure$__193-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theMissionUnit = arg0.$VB$Local_theMissionUnit;
			}
		}

		static _Closure$__193-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__193-1
	{
		public Mission $VB$Local_theMission;

		public _Closure$__193-1(_Closure$__193-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theMission = arg0.$VB$Local_theMission;
			}
		}

		static _Closure$__193-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__193-10
	{
		public int $VB$Local_theDBID;

		public _Closure$__193-10(_Closure$__193-10 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theDBID = arg0.$VB$Local_theDBID;
			}
		}

		[SpecialName]
		internal bool _Lambda$__17(ActiveUnit theUnit)
		{
			return theUnit.DBID == $VB$Local_theDBID;
		}

		[SpecialName]
		internal bool _Lambda$__19(ActiveUnit theUnit)
		{
			return theUnit.DBID == $VB$Local_theDBID;
		}

		static _Closure$__193-10()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__193-11
	{
		public int $VB$Local_theDBID;

		public _Closure$__193-11(_Closure$__193-11 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theDBID = arg0.$VB$Local_theDBID;
			}
		}

		[SpecialName]
		internal bool _Lambda$__20(ActiveUnit theUnit)
		{
			return theUnit.DBID == $VB$Local_theDBID;
		}

		[SpecialName]
		internal bool _Lambda$__22(ActiveUnit theUnit)
		{
			return theUnit.DBID == $VB$Local_theDBID;
		}

		static _Closure$__193-11()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__193-12
	{
		public int $VB$Local_theDBID;

		public _Closure$__193-12(_Closure$__193-12 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theDBID = arg0.$VB$Local_theDBID;
			}
		}

		[SpecialName]
		internal bool _Lambda$__23(ActiveUnit theUnit)
		{
			return theUnit.DBID == $VB$Local_theDBID;
		}

		[SpecialName]
		internal bool _Lambda$__25(ActiveUnit theUnit)
		{
			return theUnit.DBID == $VB$Local_theDBID;
		}

		static _Closure$__193-12()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__193-13
	{
		public int $VB$Local_theDBID;

		public _Closure$__193-13(_Closure$__193-13 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theDBID = arg0.$VB$Local_theDBID;
			}
		}

		[SpecialName]
		internal bool _Lambda$__26(ActiveUnit theUnit)
		{
			return theUnit.DBID == $VB$Local_theDBID;
		}

		[SpecialName]
		internal bool _Lambda$__28(ActiveUnit theUnit)
		{
			return theUnit.DBID == $VB$Local_theDBID;
		}

		static _Closure$__193-13()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__193-2
	{
		public Doctrine._UseShootTourists? $VB$Local_Doctrine_ShootTourists;

		public _Closure$__193-0 $VB$NonLocal_$VB$Closure_3;

		public _Closure$__193-2(_Closure$__193-2 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_Doctrine_ShootTourists = arg0.$VB$Local_Doctrine_ShootTourists;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(Contact theC)
		{
			ActiveUnit_AI aI = $VB$NonLocal_$VB$Closure_3.$VB$Local_theMissionUnit.AI;
			Mission theMission = $VB$NonLocal_$VB$Closure_3.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMission;
			Doctrine._UseShootTourists? canShootTourists = $VB$Local_Doctrine_ShootTourists;
			string Feedback = "";
			int FeedbackSeverity = 0;
			return aI.ContactIsRelevantToFlightOrMission(theC, theMission, canShootTourists, IgnoreContacStance: false, MyUnitIsInsidePatrolArea: false, IgnoreNeutralContacts: true, null, ref Feedback, ref FeedbackSeverity, null, IgnoreMissionSpecificTargetList: true);
		}

		static _Closure$__193-2()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__193-3
	{
		public Doctrine._UseShootTourists? $VB$Local_Doctrine_ShootTourists;

		public _Closure$__193-0 $VB$NonLocal_$VB$Closure_4;

		public _Closure$__193-3(_Closure$__193-3 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_Doctrine_ShootTourists = arg0.$VB$Local_Doctrine_ShootTourists;
			}
		}

		[SpecialName]
		internal bool _Lambda$__1(Contact theC)
		{
			ActiveUnit_AI aI = $VB$NonLocal_$VB$Closure_4.$VB$Local_theMissionUnit.AI;
			Mission theMission = $VB$NonLocal_$VB$Closure_4.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMission;
			Doctrine._UseShootTourists? canShootTourists = $VB$Local_Doctrine_ShootTourists;
			string Feedback = "";
			int FeedbackSeverity = 0;
			return aI.ContactIsRelevantToFlightOrMission(theC, theMission, canShootTourists, IgnoreContacStance: false, MyUnitIsInsidePatrolArea: false, IgnoreNeutralContacts: true, null, ref Feedback, ref FeedbackSeverity, null, IgnoreMissionSpecificTargetList: true);
		}

		static _Closure$__193-3()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__193-4
	{
		public Doctrine._UseShootTourists? $VB$Local_Doctrine_ShootTourists;

		public _Closure$__193-0 $VB$NonLocal_$VB$Closure_5;

		public _Closure$__193-4(_Closure$__193-4 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_Doctrine_ShootTourists = arg0.$VB$Local_Doctrine_ShootTourists;
			}
		}

		[SpecialName]
		internal bool _Lambda$__2(Contact theC)
		{
			ActiveUnit_AI aI = $VB$NonLocal_$VB$Closure_5.$VB$Local_theMissionUnit.AI;
			Mission theMission = $VB$NonLocal_$VB$Closure_5.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMission;
			Doctrine._UseShootTourists? canShootTourists = $VB$Local_Doctrine_ShootTourists;
			string Feedback = "";
			int FeedbackSeverity = 0;
			return aI.ContactIsRelevantToFlightOrMission(theC, theMission, canShootTourists, IgnoreContacStance: false, MyUnitIsInsidePatrolArea: false, IgnoreNeutralContacts: true, null, ref Feedback, ref FeedbackSeverity, null, IgnoreMissionSpecificTargetList: true);
		}

		static _Closure$__193-4()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__193-5
	{
		public int $VB$Local_theDBID;

		public _Closure$__193-5(_Closure$__193-5 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theDBID = arg0.$VB$Local_theDBID;
			}
		}

		[SpecialName]
		internal bool _Lambda$__3(ActiveUnit theUnit)
		{
			return theUnit.DBID == $VB$Local_theDBID;
		}

		[SpecialName]
		internal bool _Lambda$__4(ActiveUnit theUnit)
		{
			return theUnit.DBID == $VB$Local_theDBID;
		}

		static _Closure$__193-5()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__193-6
	{
		public int $VB$Local_theDBID;

		public _Closure$__193-6(_Closure$__193-6 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theDBID = arg0.$VB$Local_theDBID;
			}
		}

		[SpecialName]
		internal bool _Lambda$__6(ActiveUnit theUnit)
		{
			return theUnit.DBID == $VB$Local_theDBID;
		}

		[SpecialName]
		internal bool _Lambda$__8(ActiveUnit theUnit)
		{
			return theUnit.DBID == $VB$Local_theDBID;
		}

		static _Closure$__193-6()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__193-7
	{
		public int $VB$Local_theDBID;

		public _Closure$__193-7(_Closure$__193-7 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theDBID = arg0.$VB$Local_theDBID;
			}
		}

		[SpecialName]
		internal bool _Lambda$__9(ActiveUnit theUnit)
		{
			return theUnit.DBID == $VB$Local_theDBID;
		}

		[SpecialName]
		internal bool _Lambda$__10(ActiveUnit theUnit)
		{
			return theUnit.DBID == $VB$Local_theDBID;
		}

		static _Closure$__193-7()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__193-8
	{
		public int $VB$Local_theDBID;

		public _Closure$__193-8(_Closure$__193-8 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theDBID = arg0.$VB$Local_theDBID;
			}
		}

		[SpecialName]
		internal bool _Lambda$__12(ActiveUnit theUnit)
		{
			return theUnit.DBID == $VB$Local_theDBID;
		}

		[SpecialName]
		internal bool _Lambda$__14(ActiveUnit theUnit)
		{
			return theUnit.DBID == $VB$Local_theDBID;
		}

		static _Closure$__193-8()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__193-9
	{
		public int $VB$Local_theDBID;

		public _Closure$__193-9(_Closure$__193-9 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theDBID = arg0.$VB$Local_theDBID;
			}
		}

		[SpecialName]
		internal bool _Lambda$__15(ActiveUnit theUnit)
		{
			return theUnit.DBID == $VB$Local_theDBID;
		}

		static _Closure$__193-9()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__194-0
	{
		public ActiveUnit $VB$Local_theShipSubtHost;

		public _Closure$__194-0(_Closure$__194-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theShipSubtHost = arg0.$VB$Local_theShipSubtHost;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(ActiveUnit theUnit)
		{
			return theUnit.DockingOps.CurrentHostUnit == $VB$Local_theShipSubtHost;
		}

		[SpecialName]
		internal bool _Lambda$__1(ActiveUnit theUnit)
		{
			return theUnit.DockingOps.CurrentHostUnit == $VB$Local_theShipSubtHost;
		}

		static _Closure$__194-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__203-0
	{
		public Scenario $VB$Local_theScen;

		public _Closure$__203-0(_Closure$__203-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theScen = arg0.$VB$Local_theScen;
			}
		}

		[SpecialName]
		internal string _Lambda$__0(KeyValuePair<string, HashSet<string>> theKVP)
		{
			return smethod_32($VB$Local_theScen, theKVP);
		}

		[SpecialName]
		internal string _Lambda$__1(KeyValuePair<string, HashSet<string>> theKVP)
		{
			return smethod_32($VB$Local_theScen, theKVP);
		}

		[SpecialName]
		internal string _Lambda$__2(KeyValuePair<int, int> theKVP)
		{
			return smethod_33($VB$Local_theScen, theKVP);
		}

		[SpecialName]
		internal string _Lambda$__3(KeyValuePair<int, int> theKVP)
		{
			return smethod_33($VB$Local_theScen, theKVP);
		}

		static _Closure$__203-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__204-0
	{
		public Scenario $VB$Local_theScen;

		public _Closure$__204-0(_Closure$__204-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theScen = arg0.$VB$Local_theScen;
			}
		}

		[SpecialName]
		internal string _Lambda$__0(KeyValuePair<string, HashSet<string>> theKVP)
		{
			return smethod_32($VB$Local_theScen, theKVP);
		}

		[SpecialName]
		internal string _Lambda$__1(KeyValuePair<string, HashSet<string>> theKVP)
		{
			return smethod_32($VB$Local_theScen, theKVP);
		}

		[SpecialName]
		internal string _Lambda$__2(KeyValuePair<int, int> theKVP)
		{
			return smethod_33($VB$Local_theScen, theKVP);
		}

		[SpecialName]
		internal string _Lambda$__3(KeyValuePair<int, int> theKVP)
		{
			return smethod_33($VB$Local_theScen, theKVP);
		}

		static _Closure$__204-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__210-0
	{
		public Scenario $VB$Local_theScen;

		public _Closure$__210-0(_Closure$__210-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theScen = arg0.$VB$Local_theScen;
			}
		}

		[SpecialName]
		internal void _Lambda$__0(LoggedMessage theMess)
		{
			int num = IndexOf_Fast($VB$Local_theScen.MessageLog, theMess);
			if (num >= 0)
			{
				concurrentQueue_0.Enqueue(num);
			}
		}

		static _Closure$__210-0()
		{
			Class72.smethod_20();
		}
	}

	public const string BuildNumber = "v1.10 - Build 1900.20";

	public static DateTime ReleaseDate;

	public static int BetaSlack_Days;

	public const bool IsBeta = false;

	public static bool TacviewPipeEnabled;

	public static bool bool_0;

	public static bool DedupAlliedMessages;

	private static _ProLicenseTier _ProLicenseTier_0;

	public static bool PE_Lua_EnableSocket;

	public static int PE_Lua_EncodingMode;

	public static int PE_Lua_SocketPort;

	public static bool PE_Lua_AllowIO;

	public static bool PE_Lua_AllowCLRPackage;

	public static bool PE_Lua_AllowPackageDepend;

	public static bool PE_CompleteSensorFailureReport;

	public static bool PE_SaveAsXML;

	public static bool PE_MPOnly;

	public static bool ReportCompleteSensorDetectionAttempt;

	public static bool Beta_UIGridLines;

	public static bool Beta_ShowAIOODA;

	internal static bool Beta_DEFENSIVE_DUE_TO_ILLUMINATION;

	internal static bool Beta_FlameSimSpeedTimeSync;

	internal static bool Beta_RevisedSonarModel;

	public static bool Beta_PlatformComms;

	internal static bool Beta_CivRTMP;

	internal static bool Beta_HTMLDebug;

	public static float Global_PulseResolution;

	public static bool UseDynamicResolution;

	public static string TopLevelWritablePath;

	public static Exception CatastrophicCoreException;

	internal static FastDictionary<string, HashSet<string>> AlliedSidesPerSide;

	private static string string_0;

	private static string string_1;

	private static string string_2;

	internal static string SZPW;

	public static Bitmap bitmap_0;

	private static float float_0;

	internal static int NumberOfCoreWorkerThreads;

	public static DateTime ScenarioLastGoodClone_DateTime;

	private static MemoryTributary memoryTributary_0;

	public const int MessageLogSizePerSide = 500;

	public static string InstanceName;

	private static ConcurrentDictionary<int, LockRandom> concurrentDictionary_0;

	private static RNGCryptoServiceProvider rngcryptoServiceProvider_0;

	private static LockObject lockObject_0;

	public static LockObject _TakeBackMySalvo_LockObj;

	[ThreadStatic]
	internal static StringBuilder ThreadStaticSB;

	public static int NumberOfInstancesRunning;

	public static Stopwatch Timer_1minute;

	[CompilerGenerated]
	private static CoreToUIMessageEventHandler coreToUIMessageEventHandler_0;

	public static Dictionary<int, Dictionary<GlobalVariables.ActiveUnitType, Dictionary<int, CustomIconWrapper>>> CustomIconCollection;

	public static Dictionary<int, Dictionary<GlobalVariables.ActiveUnitType, CustomIconWrapper>> CustomIconCollection_Parent;

	public static string Debug_LastLoadedScenario;

	public static string Debug_LastLoadedDB;

	public static List<Module_Unit.Unit> ViewTransmissionFeedbacks;

	public const bool USE_QUALITY_CODED_COLORS = true;

	private static float float_1;

	private static float ybgyGennFph;

	private static string string_3;

	private static string string_4;

	private static string string_5;

	public static bool EnableLoadoutFilter;

	public static FlightGroupFilterOptions FlightGroupFilter;

	private static LockObject lockObject_1;

	private static DataTable dataTable_0;

	public static LockObject MainGameLoopLockObj;

	public static int DumbAUsThisPulse;

	public static int SmartAUsThisPulse;

	private static Queue<(ActiveUnit, Task)> queue_0;

	private static List<ActiveUnit> list_0;

	private static Class16 class16_0;

	private static FastDictionary<ActiveUnit, bool> fastDictionary_0;

	internal static List<Task> TaskList_PostPulseHousekeeping_RefineAOU;

	private static LockObject lockObject_2;

	private static StreamWriter streamWriter_0;

	[ThreadStatic]
	private static StringBuilder stringBuilder_0;

	[ThreadStatic]
	private static StringBuilder stringBuilder_1;

	public const int FuseThreshold = 20;

	public const bool FuseUIfeedback = true;

	public static bool UseExceptionFuse;

	public static Dictionary<string, ExceptionEntry> RegisteredExceptions;

	private static LockObject lockObject_3;

	public const string CUSTOM_LOSS_KEY = "Custom_";

	private static HashSet<LoggedMessage> hashSet_0;

	private static ConcurrentQueue<int> concurrentQueue_0;

	private static LoggedMessageComparer_SortByTimestampDescendingAndIncrementDescending loggedMessageComparer_SortByTimestampDescendingAndIncrementDescending_0;

	private static List<LoggedMessage> list_1;

	public static bool PlanningMission;

	internal static readonly string HQString;

	public static string WebViewTempPath
	{
		get
		{
			if (!string.IsNullOrEmpty(SimConfiguration.DefaultGamePreferences.CustomFolder_WebviewCache))
			{
				return SimConfiguration.DefaultGamePreferences.CustomFolder_WebviewCache;
			}
			return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CMO_WebView2Cache");
		}
	}

	public static float VeryHighIntensityResolution
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = Math.Max(Math.Min(value, 60f), 0f);
		}
	}

	public static float HighIntensityResolution
	{
		get
		{
			return ybgyGennFph;
		}
		set
		{
			ybgyGennFph = Math.Max(Math.Min(value, 60f), 0f);
		}
	}

	public static string ScenariosRootPath => Path.Combine(TopLevelWritablePath, "Scenarios");

	public static string TempPath => Path.Combine(TopLevelWritablePath, "Temp" + Conversions.ToString(Path.DirectorySeparatorChar) + "Process_" + Conversions.ToString(Process.GetCurrentProcess().Id));

	public static string AttachmentRepoPath => Path.Combine(TopLevelWritablePath, "AttachmentRepo");

	public static string DBFolderPath
	{
		get
		{
			if (string.IsNullOrEmpty(string_3))
			{
				string_3 = Path.Combine(TopLevelWritablePath, "DB");
			}
			return string_3;
		}
		set
		{
			string_3 = value;
		}
	}

	public static string NTDSPath => Application.StartupPath + Conversions.ToString(Path.DirectorySeparatorChar) + "Symbols" + Conversions.ToString(Path.DirectorySeparatorChar) + "NTDS" + Conversions.ToString(Path.DirectorySeparatorChar);

	public static string CustomIconPath => Application.StartupPath + Conversions.ToString(Path.DirectorySeparatorChar) + "Symbols" + Conversions.ToString(Path.DirectorySeparatorChar) + "Custom" + Conversions.ToString(Path.DirectorySeparatorChar);

	public static string GISFolderPath
	{
		get
		{
			if (string.IsNullOrEmpty(string_4))
			{
				string_4 = Path.Combine(TopLevelWritablePath, "GIS");
			}
			return string_4;
		}
		set
		{
			string_4 = value;
		}
	}

	public static string WWFolderPath
	{
		get
		{
			if (string.IsNullOrEmpty(string_5))
			{
				string_5 = Path.Combine(TopLevelWritablePath, "WW");
			}
			return string_5;
		}
		set
		{
			string_5 = value;
		}
	}

	public static string SBRLogFilePath => Path.Combine(LogsPath, "SBR log file.txt");

	public static string LuaRootPath => Path.Combine(TopLevelWritablePath, "Lua");

	public static string LogsPath => Path.Combine(TopLevelWritablePath, "Logs");

	public static string ConfigFolderPath => Path.Combine(TopLevelWritablePath, "Config");

	public static string ResourcesFolderPath => Path.Combine(TopLevelWritablePath, "Resources");

	public static string ProgramTitle => "Command: Modern Operations v1.10 - Build 1900.20";

	public static _ProLicenseTier LicenseTierContext
	{
		get
		{
			return _ProLicenseTier_0;
		}
		set
		{
			_ProLicenseTier_0 = value;
		}
	}

	public static LockRandom GlobalRNG
	{
		get
		{
			int managedThreadId = Thread.CurrentThread.ManagedThreadId;
			if (!concurrentDictionary_0.ContainsKey(managedThreadId))
			{
				lock (lockObject_0)
				{
					if (!concurrentDictionary_0.ContainsKey(managedThreadId))
					{
						byte[] array = new byte[5];
						rngcryptoServiceProvider_0.GetBytes(array);
						int seed = BitConverter.ToInt32(array, 0);
						LockRandom value = new LockRandom(seed);
						concurrentDictionary_0[managedThreadId] = value;
					}
				}
			}
			return concurrentDictionary_0[managedThreadId];
		}
	}

	public static MemoryTributary ScenarioLastGoodClone
	{
		get
		{
			return memoryTributary_0;
		}
		set
		{
			if (memoryTributary_0 != null)
			{
				try
				{
					memoryTributary_0.Close();
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
				try
				{
					memoryTributary_0.Dispose();
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					ProjectData.ClearProjectError();
				}
				memoryTributary_0 = null;
			}
			memoryTributary_0 = value;
		}
	}

	public static event CoreToUIMessageEventHandler CoreToUIMessage
	{
		[CompilerGenerated]
		add
		{
			CoreToUIMessageEventHandler coreToUIMessageEventHandler = coreToUIMessageEventHandler_0;
			CoreToUIMessageEventHandler coreToUIMessageEventHandler2;
			do
			{
				coreToUIMessageEventHandler2 = coreToUIMessageEventHandler;
				CoreToUIMessageEventHandler value2 = (CoreToUIMessageEventHandler)Delegate.Combine(coreToUIMessageEventHandler2, value);
				coreToUIMessageEventHandler = Interlocked.CompareExchange(ref coreToUIMessageEventHandler_0, value2, coreToUIMessageEventHandler2);
			}
			while ((object)coreToUIMessageEventHandler != coreToUIMessageEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CoreToUIMessageEventHandler coreToUIMessageEventHandler = coreToUIMessageEventHandler_0;
			CoreToUIMessageEventHandler coreToUIMessageEventHandler2;
			do
			{
				coreToUIMessageEventHandler2 = coreToUIMessageEventHandler;
				CoreToUIMessageEventHandler value2 = (CoreToUIMessageEventHandler)Delegate.Remove(coreToUIMessageEventHandler2, value);
				coreToUIMessageEventHandler = Interlocked.CompareExchange(ref coreToUIMessageEventHandler_0, value2, coreToUIMessageEventHandler2);
			}
			while ((object)coreToUIMessageEventHandler != coreToUIMessageEventHandler2);
		}
	}

	static GameGeneral()
	{
		Class72.smethod_20();
		ReleaseDate = new DateTime(2026, 9, 17);
		BetaSlack_Days = 28;
		TacviewPipeEnabled = true;
		bool_0 = false;
		DedupAlliedMessages = true;
		_ProLicenseTier_0 = _ProLicenseTier.None;
		PE_Lua_EnableSocket = false;
		PE_Lua_EncodingMode = 0;
		PE_Lua_SocketPort = 7777;
		PE_Lua_AllowIO = false;
		PE_Lua_AllowCLRPackage = false;
		PE_Lua_AllowPackageDepend = false;
		PE_CompleteSensorFailureReport = false;
		PE_SaveAsXML = false;
		PE_MPOnly = false;
		ReportCompleteSensorDetectionAttempt = false;
		Beta_UIGridLines = false;
		Beta_ShowAIOODA = false;
		Beta_DEFENSIVE_DUE_TO_ILLUMINATION = true;
		Beta_FlameSimSpeedTimeSync = false;
		Beta_RevisedSonarModel = false;
		Beta_PlatformComms = false;
		Beta_CivRTMP = true;
		Beta_HTMLDebug = false;
		UseDynamicResolution = true;
		TopLevelWritablePath = AppDomain.CurrentDomain.BaseDirectory.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
		string_0 = "sellAr";
		string_1 = "ebUnag";
		string_2 = "oolaB";
		SZPW = string_0 + string_1 + string_2;
		float_0 = 0f;
		NumberOfCoreWorkerThreads = Environment.ProcessorCount;
		InstanceName = string.Empty;
		concurrentDictionary_0 = new ConcurrentDictionary<int, LockRandom>();
		rngcryptoServiceProvider_0 = new RNGCryptoServiceProvider();
		lockObject_0 = new LockObject();
		_TakeBackMySalvo_LockObj = new LockObject();
		NumberOfInstancesRunning = 0;
		CustomIconCollection = new Dictionary<int, Dictionary<GlobalVariables.ActiveUnitType, Dictionary<int, CustomIconWrapper>>>();
		CustomIconCollection_Parent = new Dictionary<int, Dictionary<GlobalVariables.ActiveUnitType, CustomIconWrapper>>();
		Debug_LastLoadedScenario = "N/A";
		Debug_LastLoadedDB = "N/A";
		ViewTransmissionFeedbacks = new List<Module_Unit.Unit>();
		float_1 = 0f;
		ybgyGennFph = 0f;
		EnableLoadoutFilter = false;
		FlightGroupFilter = FlightGroupFilterOptions.Equipment;
		lockObject_1 = new LockObject();
		dataTable_0 = new DataTable("DBTableColumnExistance");
		MainGameLoopLockObj = new LockObject();
		queue_0 = new Queue<(ActiveUnit, Task)>();
		list_0 = new List<ActiveUnit>();
		class16_0 = new Class16();
		fastDictionary_0 = new FastDictionary<ActiveUnit, bool>();
		TaskList_PostPulseHousekeeping_RefineAOU = new List<Task>();
		lockObject_2 = new LockObject();
		UseExceptionFuse = true;
		RegisteredExceptions = new Dictionary<string, ExceptionEntry>();
		lockObject_3 = new LockObject();
		hashSet_0 = new HashSet<LoggedMessage>();
		loggedMessageComparer_SortByTimestampDescendingAndIncrementDescending_0 = new LoggedMessageComparer_SortByTimestampDescendingAndIncrementDescending();
		list_1 = new List<LoggedMessage>();
		PlanningMission = false;
		HQString = " - (HQ)";
	}

	public static void InitThreadStaticSB()
	{
		if (ThreadStaticSB == null)
		{
			ThreadStaticSB = StringBuilderCache.Allocate();
		}
		else
		{
			ThreadStaticSB.Clear();
		}
	}

	internal static void SendMessageBoxToUI(string theMessage, Side theSide, string theHeader = "", MessageBoxMessageType theType = MessageBoxMessageType.Information)
	{
		coreToUIMessageEventHandler_0?.Invoke(theMessage, theHeader, theSide, theType);
	}

	internal static string GetNavalFormationEditorScriptResource()
	{
		string path = "Lua\\CustomUI\\nav-formation.lua";
		if (File.Exists(path))
		{
			return File.ReadAllText(path);
		}
		using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Command_Core.NavalFormationEditorTemplate.txt");
		using StreamReader streamReader = new StreamReader(stream);
		return streamReader.ReadToEnd();
	}

	public static void PopulateTableColumnToCheck()
	{
		if (dataTable_0.Columns.Count == 0)
		{
			dataTable_0.Columns.Add("Table", typeof(string));
			dataTable_0.Columns.Add("Column", typeof(string));
			dataTable_0.Columns.Add("Exists", typeof(bool));
		}
		DataRow dataRow = dataTable_0.NewRow();
		dataRow["Table"] = "DataFacility";
		dataRow["Column"] = "Type";
		dataRow["Exists"] = DBNull.Value;
		dataTable_0.Rows.Add(dataRow);
	}

	public static void DBCOlumnExistenceCheck(Scenario theScen)
	{
		foreach (object row in dataTable_0.Rows)
		{
			DataRow theRow = (DataRow)RuntimeHelpers.GetObjectValue(row);
			ExecuteDBColumnExistenceCheck(ref theRow, theScen);
		}
	}

	public static void ExecuteDBColumnExistenceCheck(ref DataRow theRow, Scenario theScen)
	{
		string text = theRow["Table"].ToString();
		string text2 = "PRAGMA table_info('" + text + "');";
		SQLiteHelper sQLiteHelper = new SQLiteHelper(theScen.DBConnection);
		bool flag = false;
		try
		{
			using (SQLiteDataReader sQLiteDataReader = sQLiteHelper.ExecuteReader(text2))
			{
				string value = theRow["Column"].ToString();
				while (sQLiteDataReader.Read())
				{
					if (sQLiteDataReader["name"].ToString().Equals(value, StringComparison.OrdinalIgnoreCase))
					{
						flag = true;
						break;
					}
				}
			}
			theRow["Exists"] = flag;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 345634563", "");
			WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static bool checkColumnExistence(string TableName, string ColumnName)
	{
		foreach (DataRow row in dataTable_0.Rows)
		{
			if (Operators.CompareString(row["Table"].ToString(), TableName, false) == 0)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(row["Exists"]);
				if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(objectValue)))
				{
					return false;
				}
				return Conversions.ToBoolean(objectValue);
			}
		}
		return false;
	}

	internal static MemoryStream GetScenarioClone(Scenario theScen)
	{
		MemoryStream stream = RCMS.recyclableMemoryStreamManager_0.GetStream();
		if (theScen != null)
		{
			lock (MainGameLoopLockObj)
			{
				theScen.SerializationInProgress = true;
				theScen.ToXML(stream, MinifyText: true);
				theScen.SerializationInProgress = false;
			}
			return stream;
		}
		return stream;
	}

	public static void ClearScenarioClone()
	{
		ScenarioLastGoodClone = null;
		ScenarioLastGoodClone_DateTime = DateTime.MinValue;
	}

	public static void DestroyPreviousScenario(ref Scenario theScen, bool ClearLuaSandbox)
	{
		ReleaseReferences();
		List<ActiveUnit> list = theScen.ActiveUnits_List.ToList();
		List<ActiveUnit>.Enumerator enumerator = list.GetEnumerator();
		while (enumerator.MoveNext())
		{
			ActiveUnit theAU = enumerator.Current;
			if (theAU != null)
			{
				DestroyUnit_PrepareForGC(ref theAU);
			}
		}
		if (theScen.Sides_ReadOnly != null)
		{
			Side[] sides_ReadOnly = theScen.Sides_ReadOnly;
			for (int i = 0; i < sides_ReadOnly.Length; i = checked(i + 1))
			{
				PooledList<Contact> contacts_List = sides_ReadOnly[i].Contacts_List;
				PooledList<Contact>.Enumerator enumerator2 = contacts_List.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					Contact theCont = enumerator2.Current;
					DestroyContact_PrepareForGC(ref theCont);
				}
			}
		}
		if (ClearLuaSandbox)
		{
			theScen.Scenario_LuaSandbox.ClearStats();
		}
		theScen.ReleaseReferences();
	}

	public static void DestroyUnit_PrepareForGC(ref ActiveUnit theAU)
	{
		try
		{
			if (theAU == null)
			{
				return;
			}
			if (theAU.Mounts != null)
			{
				foreach (Mount mount in theAU.Mounts)
				{
					foreach (WeaponRec mountWeapon in mount.MountWeapons)
					{
						mountWeapon.DestroyWeaponRec();
					}
					foreach (WeaponRec weapon in mount.MountMagazine.Weapons)
					{
						weapon.DestroyWeaponRec();
					}
				}
			}
			if (theAU.SharedMagazines != null)
			{
				Magazine[] sharedMagazines = theAU.SharedMagazines;
				foreach (Magazine magazine in sharedMagazines)
				{
					foreach (WeaponRec weapon2 in magazine.Weapons)
					{
						weapon2.DestroyWeaponRec();
					}
				}
			}
			if (theAU.IsAircraft)
			{
				Aircraft aircraft = (Aircraft)theAU;
				if (aircraft.Loadout != null)
				{
					WeaponRec[] weapons = aircraft.Loadout.Weapons;
					for (int j = 0; j < weapons.Length; j = checked(j + 1))
					{
						weapons[j].DestroyWeaponRec();
					}
				}
				aircraft.Loadout = null;
			}
			if (theAU.AirFacilities_ReadOnly != null && theAU.AirFacilities_ReadOnly.Length > 0)
			{
				AirFacility[] airFacilities_ReadOnly = theAU.AirFacilities_ReadOnly;
				foreach (AirFacility airFacility in airFacilities_ReadOnly)
				{
					if (airFacility.HasHostedAircraft())
					{
						airFacility.HostedAircraft.Clear();
					}
				}
			}
			if (theAU.DockFacilities_ReadOnly != null && theAU.DockFacilities_ReadOnly.Length > 0)
			{
				DockFacility[] dockFacilities_ReadOnly = theAU.DockFacilities_ReadOnly;
				foreach (DockFacility dockFacility in dockFacilities_ReadOnly)
				{
					if (dockFacility.HasHostedBoats())
					{
						dockFacility.HostedBoats.Clear();
					}
				}
			}
			foreach (PlatformComponent item in theAU.Components())
			{
				if (item.ParentPlatform != null)
				{
					item.ParentPlatform = null;
				}
			}
			theAU.Sensory.DestroyLocalContacts();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101226", "");
			WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void DestroyContact_PrepareForGC(ref Contact theCont)
	{
		if (theCont.ActualUnit != null)
		{
			theCont.ActualUnit = null;
		}
	}

	public static void CoreInitialize(bool CustomDBsEnabled)
	{
		CSMaterial.Misc.Environment_ProcessorCount = Environment.ProcessorCount;
		GCSettings.LatencyMode = GCLatencyMode.SustainedLowLatency;
		ThreadPool.SetMinThreads(CSMaterial.Misc.Environment_ProcessorCount * 2, CSMaterial.Misc.Environment_ProcessorCount * 2);
		Doctrine.InitializeDoctrines();
		Timer_1minute = new Stopwatch();
		Timer_1minute.Start();
		try
		{
			LicenseTierContext = _ProLicenseTier.None;
			if (!Directory.Exists(TopLevelWritablePath))
			{
				Directory.CreateDirectory(TopLevelWritablePath);
			}
			if (!Directory.Exists(TempPath))
			{
				Directory.CreateDirectory(TempPath);
			}
			if (!Directory.Exists(DBFolderPath))
			{
				Directory.CreateDirectory(DBFolderPath);
			}
			if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
			{
				WriteLogDebugInfoToFile("Starting initializing Sim Core.");
			}
			if (Directory.Exists(TempPath))
			{
				Misc.DeleteEverythingInDirectory(TempPath);
			}
			else
			{
				Directory.CreateDirectory(TempPath);
			}
			RCMS.recyclableMemoryStreamManager_0 = new RecyclableMemoryStreamManager();
			Pathfinding.Initialize();
			Task.Factory.StartNew(DBOps.ScanDatabases);
			if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
			{
				WriteLogDebugInfoToFile("Successfully started database scan.");
			}
			Terrain.InitializeTerrain();
			LandCover.LoadGrids();
			SeaIceProvider.Initialize();
			if (!Directory.Exists(AttachmentRepoPath))
			{
				Directory.CreateDirectory(AttachmentRepoPath);
			}
			SevenZipBase.SetLibraryPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "7z.dll"));
			if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
			{
				WriteLogDebugInfoToFile("Successfully created Sim World.");
			}
			Misc.AngularDistance_5nm = Math2.Distance_To_AngularDegrees(5.0);
			LongRangeBallisticTables.PopulateTables();
			if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
			{
				WriteLogDebugInfoToFile("Done initializing Sim Core.");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200577", ex2.Message);
			WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void MainGameLoop(ref Scenario theScen)
	{
		List<(string, string)> list = null;
		MemoryStream memoryStream = null;
		if (SimConfiguration.DefaultGamePreferences.DetectStuckUnitPulses && SimConfiguration.DefaultGamePreferences.SaveScenarioCopyOnDetectedStuckUnitPulse)
		{
			try
			{
				memoryStream = GetScenarioClone(theScen);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 299999", "");
				WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		lock (MainGameLoopLockObj)
		{
			try
			{
				theScen.AdjustGameResolution();
				VeryHighIntensityResolution = float_1 - theScen.GameResolution;
				HighIntensityResolution = ybgyGennFph - theScen.GameResolution;
				if (DateTime.Compare(theScen.Time, theScen.StartTime.Add(theScen.Duration)) > 0 && !theScen.HasEnded)
				{
					theScen.EndScenario();
				}
				theScen.ExecutionInProgress = true;
				CatastrophicCoreException = null;
				theScen.set_Time(ManualChange: false, theScen.Time.AddSeconds(theScen.GameResolution));
				if (theScen.HasBeenReleased)
				{
					return;
				}
				list = GameEvents(ref theScen, theScen.GameResolution);
				theScen.ExecutionInProgress = false;
				if (Timer_1minute.ElapsedMilliseconds > 30000L)
				{
					GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
					Timer_1minute.Restart();
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				theScen.ExecutionInProgress = false;
				CatastrophicCoreException = ex4;
				ex4?.Data.Add("Error at 300000", "");
				WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
		if (!SimConfiguration.DefaultGamePreferences.DetectStuckUnitPulses)
		{
			return;
		}
		try
		{
			if (list == null || list.Count <= 0)
			{
				return;
			}
			string text = "";
			if (SimConfiguration.DefaultGamePreferences.PauseOnDetectedStuckUnitPulse)
			{
				theScen.GameContext.Pause();
				text = ", simulation paused";
			}
			string text2 = "";
			if (memoryStream != null)
			{
				using (memoryStream)
				{
					if (SimConfiguration.DefaultGamePreferences.SaveScenarioCopyOnDetectedStuckUnitPulse)
					{
						try
						{
							string text3 = Path.Combine(theScen.FileNamePath, "StuckUnitPulse_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + theScen.FileName);
							ScenContainer scenContainer = new ScenContainer();
							scenContainer.BuildNumber = "v1.10 - Build 1900.20";
							scenContainer.Version = ProgramTitle;
							scenContainer.AttachAndCompressScenarioObject(memoryStream);
							scenContainer.SaveToFile(text3);
							text2 = ", scenario copy saved to " + text3;
						}
						catch (Exception ex5)
						{
							ProjectData.SetProjectError(ex5);
							Exception ex6 = ex5;
							text2 = ", issue encountered while saving scenario copy (" + ex6.Message + ")";
							ProjectData.ClearProjectError();
						}
					}
				}
			}
			foreach (var (text4, text5) in list)
			{
				theScen.AddMessage("Simulation pulse for unit '" + text5 + "' is taking longer than the allowed " + SimConfiguration.DefaultGamePreferences.StuckUnitPulseThresholdMilliseconds + "ms, please submit the scenario in this state to tech support" + text + text2, "DETECTED STUCK UNIT PULSE | " + text5, LoggedMessage.MessageType.Debug, 5, text4.ToString());
			}
		}
		catch (Exception ex7)
		{
			ProjectData.SetProjectError(ex7);
			Exception ex8 = ex7;
			ex8?.Data.Add("Error at 300001", "");
			WriteExceptionsToLog(ex8);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void smethod_0(object object_0, List<ActiveUnit> list_2, float float_2)
	{
		Thread.CurrentThread.Priority = ThreadPriority.Lowest;
		if (object_0 == null)
		{
			return;
		}
		try
		{
			bool flag = ((ActiveUnit)object_0).IsOperating();
			ActiveUnit_Weaponry weaponry = ((ActiveUnit)object_0).Weaponry;
			ActiveUnit_AI aI = ((ActiveUnit)object_0).AI;
			if (flag)
			{
				if (!Module_Unit.IsRemoteSimEntity((Module_Unit.Unit)object_0) && weaponry != null && !((ScenarioObject)object_0).IsGroup && ((ActiveUnit)object_0).ParentScen.SecondIsChangingOnThisPulse)
				{
					weaponry.PrecacheDLZchecks();
					weaponry.ReduceTimesToFire(((ActiveUnit)object_0).ParentScen.ElapsedTimeSinceLastSecondChangeCheck);
					weaponry.ReloadMounts();
					weaponry.ETA_ResultsCache.Clear();
				}
				ActiveUnit_Navigator navigator = ((ActiveUnit)object_0).Navigator;
				ActiveUnit_Sensory sensory = ((ActiveUnit)object_0).Sensory;
				try
				{
					if (!Module_Unit.IsRemoteSimEntity((Module_Unit.Unit)object_0))
					{
						navigator?.Housekeeping(float_2);
						Sensor[] sensors_Cached = ((ActiveUnit)object_0).Sensors_Cached;
						if (sensory != null && ((ActiveUnit)object_0).ParentScen != null && ((ActiveUnit)object_0).ParentScen.SecondIsChangingOnThisPulse && sensors_Cached != null && sensors_Cached.Length > 0)
						{
							sensory.vmethod_2(sensors_Cached);
							sensory.PerformDetections(sensors_Cached, list_2, ((ActiveUnit)object_0).ParentScen.ElapsedTimeSinceLastSecondChangeCheck);
						}
						if (((Module_Unit.Unit)object_0).IsWeapon)
						{
							((Weapon)object_0).IsUnderGNSSDenialThisPulse = ((Weapon)object_0).method_17();
						}
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 101263", "");
					WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				if (((ActiveUnit)object_0).IsExhausted())
				{
					if (((ScenarioObject)object_0).IsAircraft)
					{
						Aircraft aircraft = (Aircraft)object_0;
						((ActiveUnit)object_0).FuelState = aircraft.IsBingoOrJoker;
						((ActiveUnit)object_0).WeaponState = aircraft.Weaponry.IsWinchesterOrShotgun();
						if (((((ActiveUnit)object_0).FuelState == ActiveUnit._ActiveUnitFuelState.IsBingo || ((ActiveUnit)object_0).FuelState == ActiveUnit._ActiveUnitFuelState.IsJoker) && ((ActiveUnit)object_0).Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint) & (((ActiveUnit)object_0).Status != ActiveUnit._ActiveUnitStatus.Refuelling))
						{
							Aircraft_AirOps airOps = aircraft.AirOps;
							GeoPoint intermediateTargetPoint = aircraft.AI.IntermediateTargetPointForRefuelCalcs();
							bool IsManual = false;
							ActiveUnit theSelectedTanker = null;
							List<Mission> theSelectedMissions = null;
							string UserFeedback = "";
							bool IsRTB = false;
							bool MissionPlanner_PostponedRefuelling = false;
							airOps.AttemptToScheduleRefuel(intermediateTargetPoint, Doctrine._UnderwayRefuelAndReplenishmentSelection.PickNearest, ref IsManual, IsForced: false, ref theSelectedTanker, ref theSelectedMissions, ref UserFeedback, ref IsRTB, ref MissionPlanner_PostponedRefuelling, Aircraft_AirOps.RefuelScheduleReason.FuelStateReachedWhileExhausted);
						}
						else if ((((ActiveUnit)object_0).Status != ActiveUnit._ActiveUnitStatus.RTB_Exhaustion) & (((ActiveUnit)object_0).Status != ActiveUnit._ActiveUnitStatus.RTB_Manual) & (((ActiveUnit)object_0).Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint) & (((ActiveUnit)object_0).Status != ActiveUnit._ActiveUnitStatus.Refuelling))
						{
							if (GlobalVariables.AI_REWORK)
							{
								((Aircraft)object_0).AI.StatusRelatedEvents.method_0(manuallyOrdered: true, ActiveUnit._ActiveUnitStatus.RTB_Exhaustion, groupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, detachFromGroup: true, clearPlottedCourse: true);
							}
							else
							{
								((ActiveUnit)object_0).AirOps.AttemptToRTB(ManuallyOrdered: true, ActiveUnit._ActiveUnitStatus.RTB_Exhaustion, GroupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, DetachFromGroup: true, ClearPlottedCourse: true);
							}
							if (Operators.CompareString(((ActiveUnit)object_0).Name, ((Module_Unit.Unit)object_0).UnitClass, false) != 0)
							{
								_ = " (" + ((Module_Unit.Unit)object_0).UnitClass + ")";
							}
							ActiveUnit actualDestinationHost = ((Aircraft_AirOps)((ActiveUnit)object_0).AirOps).ActualDestinationHost;
							if (actualDestinationHost != null)
							{
								_ = " (" + actualDestinationHost.Name + ")";
							}
							((ActiveUnit)object_0).Navigator.ResetTimeToNextPathfinderCheck();
						}
					}
				}
				try
				{
					((ActiveUnit)object_0).EvaluateIfDumb();
					if (!Module_Unit.IsRemoteSimEntity((Module_Unit.Unit)object_0) && !((ActiveUnit)object_0).IsDumbAU)
					{
						aI.TimeToNextTargetsEvaluation -= float_2;
						if (aI.TimeToNextTargetsEvaluation > 0f)
						{
							((ActiveUnit)object_0).TargetsEvaluatedOnThisPulse = false;
						}
						else
						{
							((ActiveUnit)object_0).TargetsEvaluatedOnThisPulse = true;
							if (((ActiveUnit)object_0).OODA_Targeting != 0)
							{
								if (((ActiveUnit)object_0).OODA_Targeting_Actual == 0)
								{
									((ActiveUnit)object_0).Proficiency = ((ActiveUnit)object_0).Proficiency;
								}
								aI.TimeToNextTargetsEvaluation = ((ActiveUnit)object_0).OODA_Targeting_Actual + GlobalRNG.Next(-1, 2);
							}
							else
							{
								aI.TimeToNextTargetsEvaluation = GlobalRNG.Next(10, 21);
							}
						}
						aI.TimeToNextThreatEvaluation -= float_2;
						if (aI.TimeToNextThreatEvaluation > 0f)
						{
							((ActiveUnit)object_0).ThreatsEvaluatedOnThisPulse = false;
						}
						else
						{
							((ActiveUnit)object_0).ThreatsEvaluatedOnThisPulse = true;
							if (((ActiveUnit)object_0).OODA_Evasion == 0)
							{
								aI.TimeToNextThreatEvaluation = GlobalRNG.Next(10, 21);
							}
							else
							{
								aI.TimeToNextThreatEvaluation = ((ActiveUnit)object_0).OODA_Evasion + GlobalRNG.Next(-1, 2);
							}
						}
						if (!((ActiveUnit)object_0).IsDumbAU || !((ScenarioObject)object_0).IsFixedFacility)
						{
							if (((ActiveUnit)object_0).ThreatsEvaluatedOnThisPulse || (aI.EvaluateTargets_Enabled && ((ActiveUnit)object_0).TargetsEvaluatedOnThisPulse))
							{
								aI.RefreshVisibleContactsList();
							}
							if (((ActiveUnit)object_0).ThreatsEvaluatedOnThisPulse)
							{
								aI.EvaluateThreats(float_2);
							}
							if (aI.EvaluateTargets_Enabled && ((ActiveUnit)object_0).TargetsEvaluatedOnThisPulse)
							{
								aI.EvaluateTargets(float_2, IgnoreContacStance: false, Immediately: true);
								aI.TargetsSortedByRange = aI.SortTargetsByRange_ReadOnly;
								List<ActiveUnit_AI.TargetingEntry> list = new List<ActiveUnit_AI.TargetingEntry>();
								if ((((ActiveUnit)object_0).get_UnitSide(SetSideOnly: false).FiringProposals != null) & (aI.TargetsSortedByRange != null))
								{
									foreach (KeyValuePair<string, FiringProposal> firingProposal in ((ActiveUnit)object_0).get_UnitSide(SetSideOnly: false).FiringProposals)
									{
										foreach (ActiveUnit_AI.TargetingEntry item in aI.TargetsSortedByRange)
										{
											if ((Operators.CompareString(firingProposal.Value.Target.ObjectID, item.Target.ObjectID, false) == 0 && Operators.CompareString(firingProposal.Value.FiringUnit.ObjectID, ((ScenarioObject)object_0).ObjectID, false) == 0) & (DateTime.Compare(firingProposal.Value.ETA, DateTime.MinValue) != 0))
											{
												list.Add(item);
											}
										}
									}
									foreach (ActiveUnit_AI.TargetingEntry item2 in list)
									{
										aI.TargetsSortedByRange.Remove(item2);
									}
								}
							}
						}
						if (flag)
						{
							if (((ActiveUnit)object_0).ThreatsEvaluatedOnThisPulse)
							{
								aI.DeterminePrimaryThreat(float_2);
							}
							if (aI.DeterminePrimaryTarget_Enabled && ((ActiveUnit)object_0).TargetsEvaluatedOnThisPulse)
							{
								aI.DeterminePrimaryTarget(1f, IgnoreTimeToNextEvaluation: false, CheckCombatRadius: true);
							}
							if (((ActiveUnit)object_0).ParentScen.FifthSecondIsChangingOnThisPulse)
							{
								aI.DeterminePrimaryPickupTarget();
							}
							if (((ActiveUnit)object_0).ParentScen.SecondIsChangingOnThisPulse)
							{
								aI.EvaluateUnitStatus(float_2, ForceFuelStateCheck: false, ForceWeaponStateCheck: false);
							}
							if (((ActiveUnit)object_0).ParentScen.MinuteIsChangingOnThisPulse && aI.Threats_ReadOnly.Count > 0)
							{
								foreach (Mission mission in ((ActiveUnit)object_0).get_UnitSide(SetSideOnly: false).Missions)
								{
									if (mission.MissionClass == Mission._MissionClass.ArtyFireMission)
									{
										((FireMission)mission).SendGeneralFireSupportRequest((ActiveUnit)object_0);
									}
								}
							}
						}
						if (((ScenarioObject)object_0).IsAircraft)
						{
							((Aircraft)object_0).AI.EvaluateSonoBuoyUse(float_2);
						}
						((ActiveUnit)object_0).EvaluateIfDumb();
						if ((!Module_Unit.IsRemoteSimEntity((Module_Unit.Unit)object_0) & ((ActiveUnit)object_0).IsPalletWeapon & ((ActiveUnit)object_0).IsOperating()) && ((ActiveUnit)object_0).ParentScen.SecondIsChangingOnThisPulse)
						{
							if (aI.myUnit == null)
							{
								aI.myUnit = (ActiveUnit)object_0;
							}
							aI.EngageTargets(float_2);
							((ActiveUnit)object_0).Weaponry.ExecuteWeaponSalvos(float_2);
						}
						if (!Module_Unit.IsRemoteSimEntity((Module_Unit.Unit)object_0) && !((ActiveUnit)object_0).IsDumbAU && !((Module_Unit.Unit)object_0).IsWeapon && !((ScenarioObject)object_0).IsGroup && ((ActiveUnit)object_0).IsOperating() && ((ActiveUnit)object_0).ParentScen.SecondIsChangingOnThisPulse)
						{
							if (aI.myUnit == null)
							{
								aI.myUnit = (ActiveUnit)object_0;
							}
							aI.EngageTargets(float_2);
							((ActiveUnit)object_0).Weaponry.ExecuteWeaponSalvos(float_2);
						}
					}
					else if (((ActiveUnit)object_0).IsDumbAU)
					{
						if (((ActiveUnit)object_0).HasCargo)
						{
							((ActiveUnit)object_0).AI.EvaluateUnitCargoStatus(float_2);
						}
						if (((ActiveUnit)object_0).ParentScen.FifthSecondIsChangingOnThisPulse && ((ActiveUnit)object_0).AI.HasPickupTargets())
						{
							aI.DeterminePrimaryPickupTarget();
							if (aI.PrimaryPickupTarget != null)
							{
								((ActiveUnit)object_0).DockingOps.SettleForCargoTransfer();
							}
						}
					}
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					ex4?.Data.Add("Error at 101264", "");
					WriteExceptionsToLog(ex4);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				try
				{
					if (!Module_Unit.IsRemoteSimEntity((Module_Unit.Unit)object_0) && !((ActiveUnit)object_0).IsDumbAU && !((ScenarioObject)object_0).IsGroup)
					{
						switch (((ActiveUnit)object_0).UnitType)
						{
						case GlobalVariables.ActiveUnitType.Aircraft:
							aI.DetermineDesiredAttitudeAndThrottle(float_2);
							aI.CalculateDesiredRoll();
							break;
						case GlobalVariables.ActiveUnitType.Submarine:
						{
							Scenario parentScen2 = ((ActiveUnit)object_0).ParentScen;
							if (parentScen2 != null && parentScen2.SecondIsChangingOnThisPulse)
							{
								aI.DetermineDesiredAttitudeAndThrottle(float_2);
								if (((Module_Unit.Unit)object_0).CurrentSpeed != 0f)
								{
									((Submarine)object_0).AI.CalculateDesiredPitch_NoTargetPoint();
								}
								aI.CalculateDesiredRoll();
							}
							break;
						}
						case GlobalVariables.ActiveUnitType.Weapon:
							if (((Weapon)object_0).UsesBoostCoastModel.Value)
							{
								if (((Weapon)object_0).AI.PrimaryTarget != null)
								{
									bool flag2 = false;
									float num = Module_Unit.RangeToUnit_Slant((Module_Unit.Unit)object_0, ((Weapon)object_0).AI.PrimaryTarget);
									if (num > 50f)
									{
										if (((ActiveUnit)object_0).ParentScen.Time.Second % 5 == 0)
										{
											flag2 = true;
										}
									}
									else if (num > 25f)
									{
										if (((ActiveUnit)object_0).ParentScen.Time.Second % 2 == 0)
										{
											flag2 = true;
										}
									}
									else
									{
										flag2 = true;
									}
									if (!flag2)
									{
										aI.DetermineDesiredAttitudeAndThrottle(float_2, RecalculatePlottedCourse: false);
									}
									else
									{
										aI.DetermineDesiredAttitudeAndThrottle(float_2);
									}
								}
								else
								{
									aI.DetermineDesiredAttitudeAndThrottle(float_2);
								}
							}
							else
							{
								aI.DetermineDesiredAttitudeAndThrottle(float_2);
							}
							break;
						default:
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							break;
						case GlobalVariables.ActiveUnitType.Ship:
						case GlobalVariables.ActiveUnitType.Facility:
						case GlobalVariables.ActiveUnitType.Vehicle:
						case GlobalVariables.ActiveUnitType.AggregateGroundUnit:
						{
							Scenario parentScen = ((ActiveUnit)object_0).ParentScen;
							if (parentScen != null && parentScen.SecondIsChangingOnThisPulse)
							{
								aI.DetermineDesiredAttitudeAndThrottle(float_2);
							}
							break;
						}
						case GlobalVariables.ActiveUnitType.Satellite:
							break;
						}
					}
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception ex6 = ex5;
					ex6?.Data.Add("Error at 101265", "");
					WriteExceptionsToLog(ex6);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				if (((ScenarioObject)object_0).IsAircraft)
				{
					Scenario parentScen3 = ((ActiveUnit)object_0).ParentScen;
					if (parentScen3 != null && parentScen3.SecondIsChangingOnThisPulse)
					{
						Aircraft aircraft2 = (Aircraft)object_0;
						byte? b = (byte?)aircraft2?.Doctrine.EMCON(aircraft2.ParentScen)?.Radar();
						bool? flag3 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
						if ((flag3 ?? true) && aircraft2 != null && aircraft2.RangeToUnit_Horiz(aircraft2?.AirOps.A2AR_Destination) < 5f && flag3.HasValue)
						{
							aircraft2.AirOps.ActiveRadarDoctrineBeforeRefueling = aircraft2.Doctrine.EMCON(aircraft2.ParentScen).Radar();
							aircraft2.AirOps.EMCONInheritFromParentBeforeRefueling = aircraft2.Doctrine.EMCON_Inherits;
							aircraft2.Doctrine.SetEMCON_Radar(Doctrine.EMCONSettings._EMCONSetting.Passive, ((ActiveUnit)object_0).ParentScen);
						}
					}
				}
				try
				{
					if (!Module_Unit.IsRemoteSimEntity((Module_Unit.Unit)object_0))
					{
						ActiveUnit_Damage damage = ((ActiveUnit)object_0).Damage;
						if (damage != null && flag)
						{
							damage.UnderwayRepairs(float_2);
						}
						if (navigator == null)
						{
							navigator = ((ActiveUnit)object_0).Navigator;
						}
						if (navigator.TimeToNextIsInsideMissionAreaEvaluation_NoBuffer > 0.0)
						{
							navigator.TimeToNextIsInsideMissionAreaEvaluation_NoBuffer -= float_2;
						}
						if (navigator.TimeToNextIsInsideMissionAreaEvaluation_1nmBuffer > 0.0)
						{
							navigator.TimeToNextIsInsideMissionAreaEvaluation_1nmBuffer -= float_2;
						}
						if (navigator.TimeToNextIsInsideMissionAreaEvaluation_2nmBuffer > 0.0)
						{
							navigator.TimeToNextIsInsideMissionAreaEvaluation_2nmBuffer -= float_2;
						}
						if (navigator.TimeToNextIsInsideMissionAreaEvaluation_5nmBuffer > 0.0)
						{
							navigator.TimeToNextIsInsideMissionAreaEvaluation_5nmBuffer -= float_2;
						}
						if (navigator.TimeToNextIsInsideMissionAreaEvaluation_10nmBuffer > 0.0)
						{
							navigator.TimeToNextIsInsideMissionAreaEvaluation_10nmBuffer -= float_2;
						}
						if (navigator.TimeToNextIsInsideMissionAreaEvaluation_30nmBuffer > 0.0)
						{
							navigator.TimeToNextIsInsideMissionAreaEvaluation_30nmBuffer -= float_2;
						}
						if (navigator.TimeToNextIsInsideProsecutionAreaEvaluation_NoBuffer > 0.0)
						{
							navigator.TimeToNextIsInsideProsecutionAreaEvaluation_NoBuffer -= float_2;
						}
						if (navigator.TimeToNextIsInsideProsecutionAreaEvaluation_5nmBuffer > 0.0)
						{
							navigator.TimeToNextIsInsideProsecutionAreaEvaluation_5nmBuffer -= float_2;
						}
						if (navigator.TimeToNextPlottedCourseLeadsToMissionAreaEvaluation > 0.0)
						{
							navigator.TimeToNextPlottedCourseLeadsToMissionAreaEvaluation -= float_2;
						}
					}
				}
				catch (Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					Exception ex8 = ex7;
					ex8?.Data.Add("Error at 101266", "");
					WriteExceptionsToLog(ex8);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			else if (!((ScenarioObject)object_0).IsGroup && !((ActiveUnit)object_0).IsOperating())
			{
				((ActiveUnit)object_0).DoWithdrawalCleanUp(aI);
				weaponry.ReduceTimesToFire(float_2);
			}
			if ((Beta_PlatformComms & ((ActiveUnit)object_0).ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.PointToPointComm)) && ((ActiveUnit)object_0).ParentScen.SecondIsChangingOnThisPulse)
			{
				((ActiveUnit)object_0).CommStuff.PushContactsToSide();
			}
		}
		catch (Exception ex9)
		{
			ProjectData.SetProjectError(ex9);
			Exception ex10 = ex9;
			ex10?.Data.Add("Error at 300001", "");
			WriteExceptionsToLog(ex10);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void smethod_1(Bitmap theBMP)
	{
		bitmap_0 = theBMP;
		((Image)bitmap_0).Save(TempPath + "\\map.png");
	}

	public static void ReleaseReferences()
	{
		try
		{
			list_0.Clear();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private static List<(string, string)> smethod_2(List<ActiveUnit> list_2, float float_2)
	{
		_Closure$__142-1 closure$__142- = new _Closure$__142-1(closure$__142-);
		closure$__142-.$VB$Local_OffGridUnits = list_2;
		closure$__142-.$VB$Local_elapsedTime = float_2;
		List<(string, string)> list = null;
		try
		{
			queue_0.Clear();
			using (List<ActiveUnit>.Enumerator enumerator = list_0.GetEnumerator())
			{
				_Closure$__142-0 closure$__142-2 = default(_Closure$__142-0);
				while (enumerator.MoveNext())
				{
					closure$__142-2 = new _Closure$__142-0(closure$__142-2);
					closure$__142-2.$VB$NonLocal_$VB$Closure_2 = closure$__142-;
					closure$__142-2.$VB$Local_theAUnit = enumerator.Current;
					queue_0.Enqueue((closure$__142-2.$VB$Local_theAUnit, Task.Run((Action)closure$__142-2._Lambda$__0)));
				}
			}
			while (queue_0.Count > 0)
			{
				(ActiveUnit, Task) tuple = queue_0.Dequeue();
				if (!tuple.Item2.Wait(SimConfiguration.DefaultGamePreferences.StuckUnitPulseThresholdMilliseconds))
				{
					var (activeUnit, _) = tuple;
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					if (list == null)
					{
						list = new List<(string, string)>();
					}
					list.Add((activeUnit.ObjectID, activeUnit.Name));
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 4811654795115", "");
			WriteExceptionsToLog(ex2);
			ProjectData.ClearProjectError();
		}
		return list;
	}

	public static List<(string, string)> GameEvents(ref Scenario theScen, float elapsedTime)
	{
		_Closure$__146-1 closure$__146- = new _Closure$__146-1(closure$__146-);
		closure$__146-.$VB$Local_elapsedTime = elapsedTime;
		if (GlobalVariables.ObjectTrue == GlobalVariables.ObjectFalse && Debugger.IsAttached)
		{
			Debugger.Break();
		}
		List<(string, string)> result = null;
		Thread.Yield();
		smethod_5(theScen, closure$__146-.$VB$Local_elapsedTime);
		Thread.Yield();
		try
		{
			Side[] sides_ReadOnly = theScen.Sides_ReadOnly;
			for (int i = 0; i < sides_ReadOnly.Length; i = checked(i + 1))
			{
				sides_ReadOnly[i].DistributeWeaponQuantityInSalvos();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 5478976546421", "");
			WriteExceptionsToLog(ex2);
			ProjectData.ClearProjectError();
		}
		Thread.Yield();
		try
		{
			list_0 = new List<ActiveUnit>(theScen.ActiveUnits.Values);
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 5478976546422", "");
			WriteExceptionsToLog(ex4);
			ProjectData.ClearProjectError();
		}
		LockRandom theRNG = GlobalRNG;
		DumbAUsThisPulse = 0;
		SmartAUsThisPulse = 0;
		try
		{
			if (list_0.Count > 0)
			{
				try
				{
					_Closure$__146-0 arg = default(_Closure$__146-0);
					_Closure$__146-0 CS$<>8__locals7 = new _Closure$__146-0(arg);
					CS$<>8__locals7.$VB$NonLocal_$VB$Closure_2 = closure$__146-;
					CS$<>8__locals7.$VB$Local_OffGridUnits = new List<ActiveUnit>();
					foreach (ActiveUnit item in list_0)
					{
						if (item != null && !item.CommStuff.IsConnectedToSideNetwork && item.IsOperating())
						{
							CS$<>8__locals7.$VB$Local_OffGridUnits.Add(item);
						}
					}
					Thread.Yield();
					if (SimConfiguration.DefaultGamePreferences.DetectStuckUnitPulses && SimConfiguration.DefaultGamePreferences.StuckUnitPulseThresholdMilliseconds > 0)
					{
						result = smethod_2(CS$<>8__locals7.$VB$Local_OffGridUnits, CS$<>8__locals7.$VB$NonLocal_$VB$Closure_2.$VB$Local_elapsedTime);
					}
					else if (list_0.Count > 0)
					{
						int num = ((!theScen.RunningHeadless) ? Math.Max(1, CSMaterial.Misc.Environment_ProcessorCount - 1) : Math.Max(1, CSMaterial.Misc.Environment_ProcessorCount));
						List<ActiveUnit> list = new List<ActiveUnit>(list_0.Count);
						foreach (ActiveUnit item2 in list_0)
						{
							if (item2 != null)
							{
								list.Add(item2);
							}
						}
						list.Sort(class16_0);
						List<ActiveUnit>[] array = new List<ActiveUnit>[num - 1 + 1];
						long[] array2 = new long[num - 1 + 1];
						int num2 = num - 1;
						for (int j = 0; j <= num2; j++)
						{
							array[j] = new List<ActiveUnit>();
						}
						foreach (ActiveUnit item3 in list)
						{
							int num3 = 0;
							long num4 = long.MaxValue;
							int num5 = num - 1;
							for (int k = 0; k <= num5; k++)
							{
								if (array2[k] < num4)
								{
									num4 = array2[k];
									num3 = k;
								}
							}
							array[num3].Add(item3);
							array2[num3] += item3.TimeOnLastPulse;
						}
						Thread.Yield();
						Parallel.ForEach(array, [SpecialName] (List<ActiveUnit> bucket) =>
						{
							foreach (ActiveUnit item4 in bucket)
							{
								Stopwatch stopwatch = new Stopwatch();
								stopwatch.Start();
								smethod_0(item4, CS$<>8__locals7.$VB$Local_OffGridUnits, CS$<>8__locals7.$VB$NonLocal_$VB$Closure_2.$VB$Local_elapsedTime);
								stopwatch.Stop();
								item4.TimeOnLastPulse = Math.Max(1L, stopwatch.ElapsedTicks);
							}
						});
						Thread.Yield();
					}
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception ex6 = ex5;
					ex6?.Data.Add("Error at 200492", ex6.Message);
					WriteExceptionsToLog(ex6);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					if ((object)typeof(Exception) == typeof(AggregateException))
					{
						ex6?.Data.Add("Error at 300020 ", ((AggregateException)ex6).InnerExceptions[0].Message);
						WriteExceptionsToLog(ex6);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
					}
					else
					{
						ex6?.Data.Add("Error at 300002", "");
						WriteExceptionsToLog(ex6);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
					}
					ProjectData.ClearProjectError();
				}
				try
				{
					Scenario.CargoMovement.Clear();
					Thread.Yield();
					Side[] sides_ReadOnly2 = theScen.Sides_ReadOnly;
					foreach (Side side in sides_ReadOnly2)
					{
						if (side.FiringProposals != null && side.FiringProposals.Count > 0)
						{
							side.FiringProposalEvaluationAndSalvoCreation(theScen, closure$__146-.$VB$Local_elapsedTime);
						}
					}
					Thread.Yield();
					List<ActiveUnit> list2 = new List<ActiveUnit>(list_0);
					foreach (ActiveUnit item5 in list2)
					{
						Thread.Yield();
						try
						{
							if (item5 == null || item5.get_UnitSide(SetSideOnly: false) == null || item5.IsMorituri)
							{
								continue;
							}
							try
							{
								bool checkForMinimumSafeHeight = true;
								if (item5.IsAircraft && ((Aircraft)item5).isSuicide() && item5.AI.PrimaryTarget != null && (double)Math2.CalcDist(item5, item5.AI.PrimaryTarget) * 1852.0 < (double)(item5.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - ((Module_Unit.Unit)item5.AI.PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)))
								{
									checkForMinimumSafeHeight = false;
								}
								item5.Kinematics.Move(closure$__146-.$VB$Local_elapsedTime, checkForMinimumSafeHeight, SimplifiedCalcs_DLZ: false, item5.ParentScen.Time);
								if (!Module_Unit.IsRemoteSimEntity(item5) && !item5.IsGroup && item5.IsOperating())
								{
									item5.DoFuelConsumption(closure$__146-.$VB$Local_elapsedTime);
								}
							}
							catch (Exception ex7)
							{
								ProjectData.SetProjectError(ex7);
								Exception ex8 = ex7;
								ex8?.Data.Add("Error at 1320945888121", "");
								WriteExceptionsToLog(ex8);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
							}
							if (item5.IsShip && ((Ship)item5).IsSinking)
							{
								if (!Module_Unit.IsRemoteSimEntity(item5))
								{
									item5.set_DamagePts(ScenEditAction: false, (Weapon)null, (float)((double)item5.get_DamagePts(ScenEditAction: false, (Weapon)null) - (double)item5.InitialDP / (double)(300 * GlobalRNG.Next(1, 7)) * (double)closure$__146-.$VB$Local_elapsedTime));
									if (item5.get_DamagePts(ScenEditAction: false, (Weapon)null) <= (float)(-item5.InitialDP * 5))
									{
										theScen.DestroyThisUnit(item5, "Ship has sunk");
									}
								}
								continue;
							}
							if (theScen.SecondIsChangingOnThisPulse)
							{
								item5.AddNewJourneyWaypoint();
							}
							if (!Module_Unit.IsRemoteSimEntity(item5))
							{
								item5.DoTypeSpecificActions(closure$__146-.$VB$Local_elapsedTime, ref theRNG);
							}
							if (!Module_Unit.IsRemoteSimEntity(item5) && theScen.FifteenthSecondIsChangingOnThisPulse && item5.IsOperating())
							{
								if (theScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.CommsJamming))
								{
									item5.CommStuff.CheckForCommsJamming();
								}
								else if (theScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.CommsDisruption))
								{
									item5.CommStuff.CheckForCommsDisruption();
								}
							}
							if (!Module_Unit.IsRemoteSimEntity(item5) && theScen.SecondIsChangingOnThisPulse && !item5.IsGroup && item5.IsOperating())
							{
								if (item5.Sensors_Cached.Length > 0)
								{
									ActiveUnit_Sensory sensory = item5.Sensory;
									if (item5.CommStuff.IsConnectedToSideNetwork)
									{
										sensory.HandleDetections_OnGrid();
									}
									else
									{
										sensory.HandleDetections_OffGrid();
									}
									sensory.CheckMountDirectors();
									sensory = null;
									item5.Sensory.ProcessContactListChanges_Local();
								}
								else
								{
									item5.Sensory.ProcessContactListChanges_Local();
								}
							}
							if (theScen.FifthSecondIsChangingOnThisPulse)
							{
								item5.AI.EvaluateMissionStatus(theScen);
							}
							if (!Module_Unit.IsRemoteSimEntity(item5) && theScen.FifthSecondIsChangingOnThisPulse && item5.IsOperating())
							{
								item5.AirOps.LandingQueue_CleanUp();
								item5.AirOps.ReSortLandingQueue();
							}
							if (!Module_Unit.IsRemoteSimEntity(item5) && !item5.IsGroup && item5.IsOperating() && theScen.SecondIsChangingOnThisPulse)
							{
								item5.Damage.DoSecondaryDamage(theScen.ElapsedTimeSinceLastSecondChangeCheck);
							}
						}
						catch (Exception ex9)
						{
							ProjectData.SetProjectError(ex9);
							Exception ex10 = ex9;
							ex10?.Data.Add("Error at 300003", "");
							WriteExceptionsToLog(ex10);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
				}
				catch (Exception ex11)
				{
					ProjectData.SetProjectError(ex11);
					Exception ex12 = ex11;
					ex12?.Data.Add("Error at 300004", "");
					WriteExceptionsToLog(ex12);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			Thread.Yield();
			try
			{
				smethod_8(ref theScen, closure$__146-.$VB$Local_elapsedTime, ref theRNG);
			}
			catch (Exception ex13)
			{
				ProjectData.SetProjectError(ex13);
				Exception ex14 = ex13;
				ex14?.Data.Add("Error at 300005", "");
				WriteExceptionsToLog(ex14);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			Thread.Yield();
			try
			{
				smethod_6(theScen, closure$__146-.$VB$Local_elapsedTime);
			}
			catch (Exception ex15)
			{
				ProjectData.SetProjectError(ex15);
				Exception ex16 = ex15;
				ex16?.Data.Add("Error at 300006", "");
				WriteExceptionsToLog(ex16);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			Thread.Yield();
			try
			{
				if (theScen.SecondIsChangingOnThisPulse)
				{
					if (float_0 <= float.MaxValue)
					{
						float_0 += 1f;
					}
					if (theScen.TimeCompression_SimSeconds == 1)
					{
						if (!(float_0 >= 1f))
						{
						}
					}
					else if (theScen.TimeCompression_SimSeconds == 2)
					{
						if (!(float_0 >= 2f))
						{
						}
					}
					else if (theScen.TimeCompression_SimSeconds == 5)
					{
						if (!(float_0 >= 5f))
						{
						}
					}
					else if (theScen.TimeCompression_SimSeconds == 15)
					{
						if (!(float_0 >= 15f))
						{
						}
					}
					else if (theScen.TimeCompression_SimSeconds == 30 && !(float_0 < 30f))
					{
					}
					if (Scenario.CargoMovement.Count > 0)
					{
						foreach (EventTrigger value in theScen.EventTriggers.Values)
						{
							if (value.Type == EventTrigger.EventTriggerType.UnitCargoMoved)
							{
								((EventTrigger_UnitCargoMoved)value).updateTrigger();
							}
						}
					}
					Thread.Yield();
					if (theScen.EventTriggers != null)
					{
						List<EventTrigger> list3 = new List<EventTrigger>();
						foreach (EventTrigger value2 in theScen.EventTriggers.Values)
						{
							if (value2.Type == EventTrigger.EventTriggerType.UnitCargoMoved && ((EventTrigger_UnitCargoMoved)value2).IsFulfilled)
							{
								list3.Add(value2);
							}
						}
						if (list3.Count > 0)
						{
							theScen.FireEvents(list3);
						}
					}
					Thread.Yield();
				}
			}
			catch (Exception ex17)
			{
				ProjectData.SetProjectError(ex17);
				Exception ex18 = ex17;
				ex18?.Data.Add("Error at 300007", "");
				WriteExceptionsToLog(ex18);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			Thread.Yield();
			try
			{
				foreach (CMANO.LuaFunctionArg luaFunction in CMANO.LuaFunctionList)
				{
					CMANO.CallFunctionSynchronously(luaFunction.func, luaFunction.args.ToArray());
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			Thread.Yield();
			Thread.Yield();
		}
		catch (Exception ex19)
		{
			ProjectData.SetProjectError(ex19);
			Exception ex20 = ex19;
			ex20?.Data.Add("Error at 300009", "");
			WriteExceptionsToLog(ex20);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private static void smethod_3(ref List<ActiveUnit> list_2)
	{
		int count = list_2.Count;
		LockRandom lockRandom = new LockRandom();
		int num = count;
		do
		{
			double num2 = lockRandom.NextDouble();
			int num3 = (int)Math.Round(Math.Floor((double)num * num2) + 1.0);
			ActiveUnit value = list_2[num3 - 1];
			list_2[num3 - 1] = list_2[num - 1];
			list_2[num - 1] = value;
			num--;
		}
		while (num > 1);
	}

	private static void smethod_4(Scenario scenario_0)
	{
		try
		{
			if (!scenario_0.AnyActiveWeaponEffectThreats && scenario_0.UnguidedWeapons.HasElements())
			{
				List<UnguidedWeapon> list = scenario_0.UnguidedWeapons.Values.ToList();
				int num = list.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (list != null && list[i] != null && list[i].ReferenceWeapon != null && list[i].ReferenceWeapon.IsNuke.Value && !list[i].IsMine)
					{
						scenario_0.AnyActiveWeaponEffectThreats = true;
						break;
					}
				}
			}
			if (scenario_0.AnyActiveWeaponEffectThreats || scenario_0.Explosions.Count <= 0)
			{
				return;
			}
			List<Explosion> list2 = scenario_0.Explosions.ToList();
			using List<Explosion>.Enumerator enumerator = list2.GetEnumerator();
			do
			{
				if (!enumerator.MoveNext())
				{
					return;
				}
			}
			while (enumerator.Current.WarheadType != Warhead.WarheadType.Nuclear);
			scenario_0.AnyActiveWeaponEffectThreats = true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 0374656", "");
			WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void smethod_5(Scenario scenario_0, float float_2)
	{
		_Closure$__150-0 closure$__150- = new _Closure$__150-0(closure$__150-);
		closure$__150-.$VB$Local_theScen = scenario_0;
		closure$__150-.$VB$Local_elapsedTime = float_2;
		try
		{
			_Closure$__150-1 arg = default(_Closure$__150-1);
			_Closure$__150-1 CS$<>8__locals83 = new _Closure$__150-1(arg);
			CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2 = closure$__150-;
			CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.PrePulseHouseKeeping(CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_elapsedTime);
			smethod_4(CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen);
			AlliedSidesPerSide = new FastDictionary<string, HashSet<string>>();
			Parallel.ForEach(CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.Sides_ReadOnly, [SpecialName] (Side side4) =>
			{
				side4.PrePulseHousekeeping(CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen);
			});
			Side[] sides_ReadOnly = CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.Sides_ReadOnly;
			foreach (Side side in sides_ReadOnly)
			{
				side.ContactsJustSharedWithMe.Clear();
				side.FriendlySidesThisPulse.Clear();
				side.GetAllFriendlySides(CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen, ref side.FriendlySidesThisPulse);
				side.FriendlySidesThisPulse.Remove(side);
				HashSet<string> hashSet = new HashSet<string>();
				side.GetAllAlliedSides(CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen, hashSet);
				AlliedSidesPerSide.Remove(side.ObjectID);
				AlliedSidesPerSide.Add(side.ObjectID, hashSet);
				side.IsUnitInContactWithTheLeaderInthisPulse.Clear();
			}
			if (CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.Mines == null)
			{
				CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.Mines = new List<UnguidedWeapon>();
			}
			CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.Mines.Clear();
			if (CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.UnguidedWeapons.HasElements())
			{
				List<UnguidedWeapon> list = CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.UnguidedWeapons.Values.ToList();
				for (int num2 = list.Count - 1; num2 >= 0; num2 += -1)
				{
					if (list[num2] != null)
					{
						UnguidedWeapon unguidedWeapon = list[num2];
						if (unguidedWeapon.IsMine)
						{
							CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.Mines.Add(unguidedWeapon);
						}
					}
				}
			}
			CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.MineAllocation = new ObservableDictionary<string, UnguidedWeapon>();
			foreach (UnguidedWeapon value in CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.UnguidedWeapons.Values)
			{
				if (value != null && value.IsMine && value.Mine_Targeted != null)
				{
					if (!CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.ActiveUnits.ContainsKey(value.Mine_Targeted.ObjectID))
					{
						value.Mine_Targeted = null;
					}
					else if (value.Mine_Targeted.IsRTB_Or_CalledOff)
					{
						value.Mine_Targeted = null;
					}
					else if (CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.MineAllocation.ContainsKey(value.Mine_Targeted.ObjectID))
					{
						value.Mine_Targeted = null;
					}
					else
					{
						CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.MineAllocation.Add(value.Mine_Targeted.ObjectID, value);
					}
				}
			}
			CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.Cache_TimeOfDay = new Weather.TTimeOfDayType[360][];
			CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.ActiveUnits_List = null;
			CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_ActiveUnitsList = new PooledList<ActiveUnit>(CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.ActiveUnits_List);
			fastDictionary_0.Clear();
			foreach (ActiveUnit item2 in CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_ActiveUnitsList)
			{
				if (item2 == null)
				{
					continue;
				}
				try
				{
					fastDictionary_0.Add(item2, value: false);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2.Data.Add("Error at 987654687654354", "");
					WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			CS$<>8__locals83.$VB$Local_theBag = new TList<ActiveUnit>();
			if (CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_ActiveUnitsList.Count > 0)
			{
				Parallel.ForEach(Partitioner.Create(0, CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_ActiveUnitsList.Count), [SpecialName] (Tuple<int, int> range) =>
				{
					int item = range.Item1;
					int num14 = range.Item2 - 1;
					for (int i = item; i <= num14; i++)
					{
						ActiveUnit activeUnit2 = CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_ActiveUnitsList[i];
						if (activeUnit2 != null)
						{
							try
							{
								if (!activeUnit2.IsOperating())
								{
									activeUnit2.Longitude_AtStartOfPulse = activeUnit2.get_Longitude(GlobalVariables.ObjectFalse);
									activeUnit2.Latitude_AtStartOfPulse = activeUnit2.get_Latitude(GlobalVariables.ObjectFalse);
								}
								else
								{
									fastDictionary_0[activeUnit2] = true;
									activeUnit2.Longitude_AtStartOfPulse = activeUnit2.get_Longitude(GlobalVariables.ObjectTrue);
									activeUnit2.Latitude_AtStartOfPulse = activeUnit2.get_Latitude(GlobalVariables.ObjectTrue);
								}
								activeUnit2.AI.CalculatedDesiredPitchThisPulse = false;
								ActiveUnit_Sensory sensory = activeUnit2.Sensory;
								ActiveUnit_Weaponry weaponry = activeUnit2.Weaponry;
								activeUnit2.PrePulseHousekeeping(CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_elapsedTime, CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen);
								sensory.AgeLocalAndPrivateContacts(CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_elapsedTime);
								if (CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.SecondIsChangingOnThisPulse && !activeUnit2.IsGroup && fastDictionary_0[activeUnit2])
								{
									Sensor[] sensors_Cached = activeUnit2.Sensors_Cached;
									sensory.UpdateSensorsCountdown_PreDetection(sensors_Cached);
									sensory.method_27(activeUnit2.MineCountermeasures);
									activeUnit2.CommStuff.ClearAllCommLinks();
								}
								if (!activeUnit2.IsWeapon)
								{
									activeUnit2.Doctrine.ClearCachedParentDoctrine(ClearParentGroupDoctrine: false);
									Doctrine doctrine = activeUnit2.Doctrine;
									bool UnitIsOperating = true;
									doctrine.GetParentDoctrine(ref UnitIsOperating);
								}
								sensory.Housekeeping_PrePulse(CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_elapsedTime);
								weaponry.Housekeeping_PrePulse();
								if (activeUnit2.IsWeapon)
								{
									Weapon obj2 = (Weapon)activeUnit2;
									obj2.ImpactsOnThisPulse_ActualUnit = obj2.AboutToImpact_ActualTarget(CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_elapsedTime);
									obj2.ImpactsOnThisPulse_Contact = obj2.AboutToImpact_Contact(CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_elapsedTime);
								}
								if (activeUnit2.IsFacility && ActiveUnit_DockingOps.HasPiers(activeUnit2))
								{
									CS$<>8__locals83.$VB$Local_theBag.Add(activeUnit2);
								}
							}
							catch (Exception ex11)
							{
								ProjectData.SetProjectError(ex11);
								Exception ex12 = ex11;
								ex12?.Data.Add("Error at 101293A", "");
								WriteExceptionsToLog(ex12);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
							}
						}
					}
				});
			}
			CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_ActiveUnitsList.Dispose();
			foreach (ActiveUnit item3 in CS$<>8__locals83.$VB$Local_theBag)
			{
				_ = item3;
				CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.Cache_FacilitiesWithPiers = CS$<>8__locals83.$VB$Local_theBag.ToArray();
			}
			smethod_7(ref CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen);
			Side[] sides_ReadOnly2 = CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.Sides_ReadOnly;
			foreach (Side side2 in sides_ReadOnly2)
			{
				if (side2.PotentialContacts == null)
				{
					side2.PotentialContacts = new List<ActiveUnit>(CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.ActiveUnits.Count);
				}
				if (side2.PotentialBaseContacts == null)
				{
					side2.PotentialBaseContacts = new List<ActiveUnit>(CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.ActiveUnits.Count);
				}
				side2.PotentialContacts.Clear();
				side2.PotentialBaseContacts.Clear();
				if (Operators.CompareString(CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.GetCurrentSide().ObjectID, side2.ObjectID, false) == 0)
				{
					try
					{
						if (CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.SecondIsChangingOnThisPulse)
						{
							for (int num4 = side2.RefPoints.Count - 1; num4 >= 0; num4 += -1)
							{
								ReferencePoint referencePoint = side2.RefPoints[num4];
								if (referencePoint != null)
								{
									referencePoint.Cycle_1sec_RemoveIfNecessary(CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen, side2.RefPoints);
								}
								else
								{
									side2.RefPoints.RemoveAt(num4);
								}
							}
							string[] array = side2.PerUnitSlugtrail.Keys.ToArray();
							foreach (string key in array)
							{
								while (!side2.PerUnitSlugtrail[key].refPoints.IsEmpty && side2.PerUnitSlugtrail[key].refPoints.First().ShouldbeRemoved(CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen))
								{
									ConcurrentQueue<ReferencePoint> refPoints = side2.PerUnitSlugtrail[key].refPoints;
									ReferencePoint result = null;
									refPoints.TryDequeue(out result);
								}
								ReferencePoint[] array2 = side2.PerUnitSlugtrail[key].refPoints.ToArray();
								for (int num6 = 0; num6 < array2.Length; num6 = checked(num6 + 1))
								{
									array2[num6].Cycle_1sec(CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen);
								}
								if (side2.PerUnitSlugtrail[key].refPoints.Count == 0)
								{
									side2.PerUnitSlugtrail.Remove(key);
								}
							}
						}
					}
					catch (Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						Exception ex4 = ex3;
						ex4.Data.Add("Error at 93758569436", "");
						WriteExceptionsToLog(ex4);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
					if (SimConfiguration.DefaultGamePreferences.SlugTrail_Use && ((SimConfiguration.DefaultGamePreferences.SlugTrailTimeFrequency == SlugTrailTimeFrequency.FithSecond && CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.FifthSecondIsChangingOnThisPulse) || (SimConfiguration.DefaultGamePreferences.SlugTrailTimeFrequency == SlugTrailTimeFrequency.FithteenthSecond && CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.FifteenthSecondIsChangingOnThisPulse) || (SimConfiguration.DefaultGamePreferences.SlugTrailTimeFrequency == SlugTrailTimeFrequency.OneMinute && CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.MinuteIsChangingOnThisPulse)))
					{
						if (SimConfiguration.DefaultGamePreferences.SlugTrail_OwnAndAllied)
						{
							foreach (ActiveUnit item4 in side2.Units.ToList())
							{
								if (item4.CurrentSpeed != 0f && !item4.IsGroup && (!item4.IsActiveUnit || item4.IsOperating()))
								{
									ReferencePoint.CreateNewSlugTrailPoint(CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen, item4.ObjectID, item4.get_Longitude((GlobalVariables.BooleanObject)null), item4.get_Latitude((GlobalVariables.BooleanObject)null), item4.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), side2, CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.Time.AddSeconds(SimConfiguration.DefaultGamePreferences.SlugTrail_LifeTime), Color.White, _Fades: true, _ForceShrink: true);
								}
							}
						}
						Dictionary<Misc.PostureStance, bool> dictionary = new Dictionary<Misc.PostureStance, bool>();
						dictionary.Add(Misc.PostureStance.Friendly, SimConfiguration.DefaultGamePreferences.SlugTrail_Friendly);
						dictionary.Add(Misc.PostureStance.Hostile, SimConfiguration.DefaultGamePreferences.SlugTrail_Hostile);
						dictionary.Add(Misc.PostureStance.Neutral, SimConfiguration.DefaultGamePreferences.SlugTrail_Neutral);
						dictionary.Add(Misc.PostureStance.Unfriendly, SimConfiguration.DefaultGamePreferences.SlugTrail_Unfriendly);
						dictionary.Add(Misc.PostureStance.Unknown, SimConfiguration.DefaultGamePreferences.SlugTrail_UnKnown);
						foreach (Contact contacts_ in side2.Contacts_List)
						{
							Misc.PostureStance key2 = contacts_.get_Stance(side2);
							if (contacts_.CurrentSpeed != 0f && dictionary[key2])
							{
								Color color = Helper.get_ColorFromStance(contacts_.get_Stance(side2));
								ReferencePoint.CreateNewSlugTrailPoint(CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen, contacts_.ObjectID, ((Module_Unit.Unit)contacts_).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contacts_).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contacts_).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), side2, CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.Time.AddSeconds(SimConfiguration.DefaultGamePreferences.SlugTrail_LifeTime), color, _Fades: true, _ForceShrink: true);
							}
						}
					}
				}
				Side[] sides_ReadOnly3 = CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.Sides_ReadOnly;
				foreach (Side side3 in sides_ReadOnly3)
				{
					if (side3 == side2 || side3.FriendlySidesThisPulse.Contains(side2))
					{
						continue;
					}
					foreach (ActiveUnit unit in side3.Units)
					{
						if (unit == null)
						{
							continue;
						}
						if (!unit.IsGroup)
						{
							if (unit.IsOperating())
							{
								side2.PotentialContacts.Add(unit);
							}
							continue;
						}
						Group obj = (Group)unit;
						int num8;
						if (obj.Type != Group.GroupType.AirBase && obj.Type != Group.GroupType.Installation && obj.Type != Group.GroupType.NavalBase)
						{
							if (obj.Type != Group.GroupType.MobileGroup)
							{
								continue;
							}
							num8 = 0;
						}
						else
						{
							num8 = 0;
						}
						bool flag = (byte)num8 != 0;
						foreach (ActiveUnit value2 in obj.Units.Values)
						{
							if (side2.Contacts.ContainsKey(value2.ObjectID))
							{
								flag = true;
								break;
							}
						}
						if (flag)
						{
							side2.PotentialBaseContacts.Add(unit);
						}
					}
				}
			}
			Side[] sides_ReadOnly4 = CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.Sides_ReadOnly;
			_Closure$__150-2 closure$__150-2 = default(_Closure$__150-2);
			_Closure$__150-3 closure$__150-3 = default(_Closure$__150-3);
			Waypoint theIPWaypoint = default(Waypoint);
			for (int num9 = 0; num9 < sides_ReadOnly4.Length; num9 = checked(num9 + 1))
			{
				closure$__150-2 = new _Closure$__150-2(closure$__150-2);
				closure$__150-2.$VB$Local_theSide = sides_ReadOnly4[num9];
				try
				{
					for (int num10 = closure$__150-2.$VB$Local_theSide.Units.Count - 1; num10 >= 0; num10 += -1)
					{
						ActiveUnit activeUnit;
						try
						{
							if (num10 < closure$__150-2.$VB$Local_theSide.Units.Count)
							{
								activeUnit = closure$__150-2.$VB$Local_theSide.Units[num10];
								if (activeUnit != null)
								{
									goto IL_0bc1;
								}
								closure$__150-2.$VB$Local_theSide.Units.Remove(activeUnit);
							}
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							ProjectData.ClearProjectError();
						}
						continue;
						IL_0bc1:
						if (activeUnit.IsMorituri)
						{
							closure$__150-2.$VB$Local_theSide.Units.Remove(activeUnit);
						}
					}
					if (closure$__150-2.$VB$Local_theSide.Contacts.Count > 0)
					{
						PooledList<Contact> pooledList = new PooledList<Contact>(closure$__150-2.$VB$Local_theSide.Contacts.Values);
						PooledList<Contact> pooledList2 = new PooledList<Contact>();
						foreach (Contact item5 in pooledList)
						{
							if (CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.SecondIsChangingOnThisPulse)
							{
								Contact.IncreaseAge(item5, closure$__150-2.$VB$Local_theSide, CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.ElapsedTimeSinceLastSecondChangeCheck, CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen);
								if (item5.IsDueToExpire())
								{
									pooledList2.Add(item5);
									continue;
								}
							}
							item5.PrePulseHousekeeping(CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_elapsedTime, CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen);
							item5.IsPreciselyLocatedOnThisPulse = false;
							item5.ChangedToFirmOnThisPulse = false;
							if (CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.GenerateAutoDetectableUnitsOnThisPulse)
							{
								item5.IsAutoDetection = false;
							}
							item5.AgeDetectedEmissions(CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_elapsedTime);
						}
						foreach (Contact item6 in pooledList2)
						{
							closure$__150-2.$VB$Local_theSide.DropContact(item6, ref CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen, closure$__150-2.$VB$Local_theSide == CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.GetCurrentSide());
						}
						pooledList.Dispose();
						pooledList2.Dispose();
					}
					closure$__150-2.$VB$Local_theSide.ProcessBaseContacts(ref CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen);
					closure$__150-2.$VB$Local_theSide.ProcessAutoDetectableUnits(CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen, CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_elapsedTime);
					closure$__150-2.$VB$Local_theSide.get_Item(Refresh: true);
					if (CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.SecondIsChangingOnThisPulse)
					{
						List<Weapon> list2 = CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.AllWeaponsAlive.Where(closure$__150-2._Lambda$__2).ToList();
						if (list2.Count > 0)
						{
							List<ActiveUnit> friendlyOperatingUnits = closure$__150-2.$VB$Local_theSide.get_FriendlyUnits_OperativeOnly(CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen, IncludeWeapons: false);
							foreach (Weapon item7 in list2)
							{
								item7.CommStuff.CheckCommsAndDataLinks(CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.ElapsedTimeSinceLastSecondChangeCheck, friendlyOperatingUnits);
							}
						}
					}
					closure$__150-2.$VB$Local_theSide.Operation.Tick(CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen, CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_elapsedTime);
					if (CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.MinuteIsChangingOnThisPulse)
					{
						foreach (Mission mission in closure$__150-2.$VB$Local_theSide.Missions)
						{
							if (mission.IsActive && mission.MissionClass == Mission._MissionClass.ArtyFireMission)
							{
								((FireMission)mission).Tick(closure$__150-2.$VB$Local_theSide);
							}
						}
						ref Scenario theScen = ref CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen;
						ref Side theSide = ref closure$__150-2.$VB$Local_theSide;
						Mission theSpecificMission = null;
						CheckForMissionWakeup(ref theScen, ref theSide, ref theSpecificMission, IncludeEmptySlots: false, OrderTakeOff: true, LaunchPrePlannedPackages: true, 0);
					}
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception ex6 = ex5;
					ex6?.Data.Add("Error at 101293", "");
					WriteExceptionsToLog(ex6);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				try
				{
					if (!CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.MinuteIsChangingOnThisPulse)
					{
						continue;
					}
					foreach (Mission mission2 in closure$__150-2.$VB$Local_theSide.Missions)
					{
						foreach (Mission.Flight flight2 in mission2.FlightList)
						{
							Waypoint[] flightPlan = flight2.FlightPlan;
							for (int num11 = 0; num11 < flightPlan.Length; num11 = checked(num11 + 1))
							{
								closure$__150-3 = new _Closure$__150-3(closure$__150-3);
								closure$__150-3.$VB$Local_theWp = flightPlan[num11];
								if (closure$__150-3.$VB$Local_theWp.Type != Waypoint.WaypointType.Target || closure$__150-3.$VB$Local_theWp.TargeteeringList == null || closure$__150-3.$VB$Local_theWp.TargeteeringList.Count <= 0)
								{
									continue;
								}
								KeyValuePair<string, Contact> keyValuePair = closure$__150-2.$VB$Local_theSide.Contacts.Where(closure$__150-3._Lambda$__3).FirstOrDefault();
								if (keyValuePair.Key == null || !((((Module_Unit.Unit)keyValuePair.Value).get_Latitude((GlobalVariables.BooleanObject)null) != closure$__150-3.$VB$Local_theWp.TargeteeringList[0].Target_Latitude) | (((Module_Unit.Unit)keyValuePair.Value).get_Longitude((GlobalVariables.BooleanObject)null) != closure$__150-3.$VB$Local_theWp.TargeteeringList[0].Target_Longitude)))
								{
									continue;
								}
								float MoveBearing = 0f;
								float MoveDistance = 0f;
								int num12 = 0;
								Waypoint[] flightPlan2 = flight2.FlightPlan;
								foreach (Waypoint waypoint in flightPlan2)
								{
									if (waypoint.Type == Waypoint.WaypointType.Target)
									{
										break;
									}
									theIPWaypoint = waypoint;
									num12++;
								}
								MissionPlanner.UpdateTargetWP(null, flight2.get_ReferenceUnit(CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen), keyValuePair.Value, IsAirborne: true, flight2, ref theIPWaypoint, ref MoveBearing, ref MoveDistance, ref closure$__150-3.$VB$Local_theWp);
								Scenario theScen2 = CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen;
								ActiveUnit theAU = flight2.get_ReferenceUnit(CS$<>8__locals83.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen);
								Mission.Flight flight;
								Waypoint[] theFlightplan = (flight = flight2).FlightPlan;
								float NecessaryFuel = 0f;
								float MissionFuel = 0f;
								MissionPlanner.CalculateFuelQtyAndTimes_And_CheckIfEnoughFuelForFlightPlan(theScen2, mission2, theAU, flight2, ref theFlightplan, ref NecessaryFuel, ref MissionFuel, RangeCheck: false, RunValidation: true, RunFreeSpeedChecks: false, SetWaypointTimes: false, NewFlightPlan: false, EditLeadWaypoints: true, EditWingmanWaypoints: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, AircraftIsAirborne: true, BananaSplitRedSection: false, mission2.TakeOffTime, mission2.TimeOnTarget, IsMFP: false);
								flight.FlightPlan = theFlightplan;
							}
						}
					}
				}
				catch (Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					Exception ex8 = ex7;
					WriteExceptionsToLog(ex8);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
		}
		catch (Exception ex9)
		{
			ProjectData.SetProjectError(ex9);
			Exception ex10 = ex9;
			ex10?.Data.Add("Error at 300010", "");
			WriteExceptionsToLog(ex10);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void smethod_6(Scenario scenario_0, float float_2)
	{
		_Closure$__152-3 closure$__152- = new _Closure$__152-3(closure$__152-);
		closure$__152-.$VB$Local_theScen = scenario_0;
		closure$__152-.$VB$Local_elapsedTime = float_2;
		try
		{
			TaskList_PostPulseHousekeeping_RefineAOU.Clear();
			closure$__152-.$VB$Local_theScen.AddRemoveUnits();
			try
			{
				foreach (ActiveUnit value2 in closure$__152-.$VB$Local_theScen.ActiveUnits.Values)
				{
					if (value2 == null || !value2.IsMorituri)
					{
						continue;
					}
					Side[] sides_ReadOnly = closure$__152-.$VB$Local_theScen.Sides_ReadOnly;
					foreach (Side side in sides_ReadOnly)
					{
						try
						{
							if (value2.IsAircraft)
							{
								Aircraft obj = (Aircraft)value2;
								string text = "";
								text = ((!obj.IsTanker) ? "the client was destroyed" : "the Tanker was destroyed");
								obj.DisconnectTankerClients(text);
							}
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception ex2 = ex;
							ex2?.Data.Add("Error at 2002454224291", "");
							WriteExceptionsToLog(ex2);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
						side.Units.Remove(value2);
					}
				}
				Dictionary<string, HashSet<string>> dictionary = new Dictionary<string, HashSet<string>>();
				if (closure$__152-.$VB$Local_theScen.Sides_ReadOnly != null)
				{
					Side[] sides_ReadOnly2 = closure$__152-.$VB$Local_theScen.Sides_ReadOnly;
					foreach (Side side2 in sides_ReadOnly2)
					{
						HashSet<string> FriendsList = new HashSet<string>();
						side2.GetAllFriendlySides(closure$__152-.$VB$Local_theScen, ref FriendsList);
						FriendsList.Remove(side2.ObjectID);
						dictionary.Add(side2.ObjectID, FriendsList);
					}
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at 101255", "");
				WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			DeconflictContactsBetweenAllies(closure$__152-.$VB$Local_theScen);
			try
			{
				_Closure$__152-1 closure$__152-2 = new _Closure$__152-1(closure$__152-2);
				closure$__152-2.$VB$NonLocal_$VB$Closure_2 = closure$__152-;
				if (closure$__152-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.Sides_ReadOnly == null)
				{
					return;
				}
				List<Side> list = new List<Side>(closure$__152-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.Sides_ReadOnly);
				using (List<Side>.Enumerator enumerator2 = list.GetEnumerator())
				{
					_Closure$__152-0 closure$__152-3 = default(_Closure$__152-0);
					float bearing = default(float);
					while (enumerator2.MoveNext())
					{
						closure$__152-3 = new _Closure$__152-0(closure$__152-3);
						closure$__152-3.$VB$Local_theSide = enumerator2.Current;
						if (Beta_PlatformComms & closure$__152-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.PointToPointComm))
						{
							if (closure$__152-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.SecondIsChangingOnThisPulse)
							{
								closure$__152-3.$VB$Local_theSide.FeedbackList.Clear();
								closure$__152-3.$VB$Local_theSide.ProcessIncomingDetections();
								try
								{
									OrderablePartitioner<Tuple<int, int>> source = Partitioner.Create(0, closure$__152-3.$VB$Local_theSide.Units.Count);
									Parallel.ForEach(source, closure$__152-3._Lambda$__0);
									closure$__152-3.$VB$Local_theSide.TransmissionQueue.Clear();
									Parallel.ForEach(source, closure$__152-3._Lambda$__1);
								}
								catch (Exception ex5)
								{
									ProjectData.SetProjectError(ex5);
									Exception ex6 = ex5;
									ex6?.Data.Add("Error at 621654321321644", "");
									WriteExceptionsToLog(ex6);
									if (Debugger.IsAttached)
									{
										Debugger.Break();
									}
									ProjectData.ClearProjectError();
								}
							}
							if (closure$__152-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.MinuteIsChangingOnThisPulse)
							{
								closure$__152-3.$VB$Local_theSide.MinuteTransmissionQueue.Clear();
								closure$__152-3.$VB$Local_theSide.MinuteFeedbackList.Clear();
							}
						}
						try
						{
							closure$__152-3.$VB$Local_theSide.set_FriendlyUnits(closure$__152-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen, IncludeWeapons: false, (List<ActiveUnit>)null);
							closure$__152-3.$VB$Local_theSide.ProcessContactListChanges(closure$__152-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen);
							closure$__152-3.$VB$Local_theSide.ProcessBaseContactListChanges(closure$__152-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen);
						}
						catch (Exception ex7)
						{
							ProjectData.SetProjectError(ex7);
							Exception ex8 = ex7;
							ex8?.Data.Add("Error at 983174140909_0", "");
							WriteExceptionsToLog(ex8);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
						bool flag = closure$__152-3.$VB$Local_theSide.ExclusionZones.Count > 0;
						HashSet<Contact> hashSet = new HashSet<Contact>();
						try
						{
							foreach (Contact contacts_ in closure$__152-3.$VB$Local_theSide.Contacts_List)
							{
								Contact myContact = contacts_;
								bool flag2 = false;
								if (myContact == null)
								{
									continue;
								}
								if (myContact.ActualUnit == null)
								{
									flag2 = true;
								}
								else if (!closure$__152-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.ActiveUnits.ContainsKey(myContact.ActualUnit.ObjectID))
								{
									flag2 = true;
								}
								else if (!myContact.ActualUnit.IsOperating())
								{
									flag2 = true;
								}
								if (!flag2)
								{
									if (closure$__152-3.$VB$Local_theSide.Units.Count > 0 && myContact.IsAutoDetection)
									{
										PooledList<ActiveUnit> units = closure$__152-3.$VB$Local_theSide.Units;
										ActiveUnit TheDetectingUnit = units[0];
										ActiveUnit_Sensory.UpdateContactData(ref TheDetectingUnit, ref myContact, myContact.ActualUnit, ContactIsNew: false);
										units[0] = TheDetectingUnit;
									}
									if (myContact.Age == 0f)
									{
										myContact.HeldFor += closure$__152-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_elapsedTime;
									}
									myContact.PostPulseHousekeeping(closure$__152-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_elapsedTime, closure$__152-3.$VB$Local_theSide, closure$__152-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen, IsPrivateContact: false);
								}
								else
								{
									closure$__152-3.$VB$Local_theSide.DropContact(myContact, ref closure$__152-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen, LogMessage: true);
									hashSet.Add(myContact);
								}
							}
						}
						catch (Exception ex9)
						{
							ProjectData.SetProjectError(ex9);
							Exception ex10 = ex9;
							ex10?.Data.Add("Error at 200291", "");
							WriteExceptionsToLog(ex10);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
						List<Contact> list2 = new List<Contact>(closure$__152-3.$VB$Local_theSide.Contacts_List);
						ActiveUnit[] array = null;
						bool flag3 = true;
						foreach (Contact item in list2)
						{
							if (item.ActualUnit == null)
							{
								continue;
							}
							try
							{
								if (item.ActualUnit.IsFixedFacility && item.UncertaintyArea == null && item.IDStatus < Contact_Base.IdentificationStatus.PreciseID && item.IsAutoDetection)
								{
									item.set_IDStatus(closure$__152-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen, closure$__152-3.$VB$Local_theSide, (Sensor)null, (float?)null, IsNCTRupdate: false, StatusUpdateIsOnCommsGrid: true, bool_5: false, GenerateMessage: true, Contact_Base.IdentificationStatus.PreciseID);
								}
							}
							catch (Exception ex11)
							{
								ProjectData.SetProjectError(ex11);
								Exception ex12 = ex11;
								ex12?.Data.Add("Error at 983174140909_1", "");
								WriteExceptionsToLog(ex12);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
							}
							if (item == null || item.IsAutoDetection)
							{
								continue;
							}
							if (item.OriginalDetectorSide == null)
							{
								if (item.ActualUnit.get_UnitSide(SetSideOnly: false) == closure$__152-3.$VB$Local_theSide)
								{
									hashSet.Add(item);
									closure$__152-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.AddMessage("Contact " + item.Name + " detected by " + item.OriginalDetectorSide.Name + " droppped - " + (item.ActualUnit.get_UnitSide(SetSideOnly: false).FriendlySidesThisPulse.Contains(closure$__152-3.$VB$Local_theSide) ? "for known friendly unit " : "") + ((item.ActualUnit.get_UnitSide(SetSideOnly: false) == closure$__152-3.$VB$Local_theSide) ? "for my unit" : ""), "Contact dropped deliberately", LoggedMessage.MessageType.ContactChange, 0, null, closure$__152-3.$VB$Local_theSide, new Geopoint_Struct(((Module_Unit.Unit)item).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)item).get_Latitude((GlobalVariables.BooleanObject)null)));
								}
								else if (item.ActualUnit.get_UnitSide(SetSideOnly: false).FriendlySidesThisPulse.Contains(closure$__152-3.$VB$Local_theSide))
								{
									hashSet.Add(item);
									if (item.OriginalDetectorSide != null)
									{
										closure$__152-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.AddMessage("Contact " + item.Name + " detected by " + item.OriginalDetectorSide.Name + " droppped - for known friendly unit " + ((item.ActualUnit.get_UnitSide(SetSideOnly: false) == closure$__152-3.$VB$Local_theSide) ? "for my unit" : ""), "Contact dropped deliberately", LoggedMessage.MessageType.ContactChange, 0, null, closure$__152-3.$VB$Local_theSide, new Geopoint_Struct(((Module_Unit.Unit)item).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)item).get_Latitude((GlobalVariables.BooleanObject)null)));
									}
								}
							}
							else if (item.OriginalDetectorSide != closure$__152-3.$VB$Local_theSide)
							{
								if (item.OriginalDetectorSide.Units.Count != 0 && item.OriginalDetectorSide.FriendlySidesThisPulse.Contains(closure$__152-3.$VB$Local_theSide))
								{
									continue;
								}
								if (item.OriginalDetectorSide.Units.Count > 0)
								{
									bool flag4 = false;
									try
									{
										foreach (Side item2 in closure$__152-3.$VB$Local_theSide.FriendlySidesThisPulse)
										{
											if (item2.FriendlySidesThisPulse.Contains(item.OriginalDetectorSide))
											{
												flag4 = true;
												break;
											}
										}
									}
									catch (Exception ex13)
									{
										ProjectData.SetProjectError(ex13);
										Exception ex14 = ex13;
										ex14?.Data.Add("Error at 983174140909_2", "");
										WriteExceptionsToLog(ex14);
										if (Debugger.IsAttached)
										{
											Debugger.Break();
										}
										ProjectData.ClearProjectError();
									}
									try
									{
										if (!flag4)
										{
											foreach (Side item3 in item.OriginalDetectorSide.FriendlySidesThisPulse)
											{
												if (item3.FriendlySidesThisPulse.Contains(item.OriginalDetectorSide))
												{
													flag4 = true;
													break;
												}
											}
										}
									}
									catch (Exception ex15)
									{
										ProjectData.SetProjectError(ex15);
										Exception ex16 = ex15;
										ex16?.Data.Add("Error at 983174140909_3", "");
										WriteExceptionsToLog(ex16);
										if (Debugger.IsAttached)
										{
											Debugger.Break();
										}
										ProjectData.ClearProjectError();
									}
									try
									{
										if (!flag4 && item.OriginalDetectorSide.Contacts.ContainsKey(item.ActualUnit.ObjectID))
										{
											Contact contact = item.Clone();
											contact.OriginalDetectorSide = closure$__152-3.$VB$Local_theSide;
											closure$__152-3.$VB$Local_theSide.AddContact(contact, Forced: true);
											hashSet.Add(item);
										}
									}
									catch (Exception ex17)
									{
										ProjectData.SetProjectError(ex17);
										Exception ex18 = ex17;
										ex18?.Data.Add("Error at 983174140909_4", "");
										WriteExceptionsToLog(ex18);
										if (Debugger.IsAttached)
										{
											Debugger.Break();
										}
										ProjectData.ClearProjectError();
									}
								}
								else
								{
									Contact contact2 = item.Clone();
									contact2.OriginalDetectorSide = closure$__152-3.$VB$Local_theSide;
									closure$__152-3.$VB$Local_theSide.AddContact(contact2, Forced: true);
									hashSet.Add(item);
								}
							}
							else if (item.ActualUnit.get_UnitSide(SetSideOnly: false) == closure$__152-3.$VB$Local_theSide)
							{
								try
								{
									if (array == null)
									{
										array = new ActiveUnit[0];
										Side[] sides_ReadOnly3 = closure$__152-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.Sides_ReadOnly;
										foreach (Side side3 in sides_ReadOnly3)
										{
											if (side3 != closure$__152-3.$VB$Local_theSide && side3.get_ConsidersThisSideToBe(closure$__152-3.$VB$Local_theSide, (Scenario)null) != Misc.PostureStance.Friendly)
											{
												continue;
											}
											foreach (ActiveUnit unit2 in side3.Units)
											{
												if (!unit2.CommStuff.IsConnectedToSideNetwork)
												{
													array = (ActiveUnit[])Utils.CopyArray((Array)array, (Array)new ActiveUnit[array.Length + 1]);
													array[^1] = unit2;
												}
											}
										}
									}
									if (!array.Contains(item.ActualUnit))
									{
										hashSet.Add(item);
										closure$__152-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.AddMessage("Contact " + item.Name + " detected by " + item.OriginalDetectorSide.Name + " droppped - " + ((!item.ActualUnit.get_UnitSide(SetSideOnly: false).FriendlySidesThisPulse.Contains(closure$__152-3.$VB$Local_theSide)) ? "" : "for known friendly unit ") + ((item.ActualUnit.get_UnitSide(SetSideOnly: false) == closure$__152-3.$VB$Local_theSide) ? "for my unit" : ""), "Contact dropped deliberately", LoggedMessage.MessageType.ContactChange, 0, null, closure$__152-3.$VB$Local_theSide, new Geopoint_Struct(((Module_Unit.Unit)item).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)item).get_Latitude((GlobalVariables.BooleanObject)null)));
									}
								}
								catch (Exception ex19)
								{
									ProjectData.SetProjectError(ex19);
									Exception ex20 = ex19;
									ex20?.Data.Add("Error at 983174140909_5", "");
									WriteExceptionsToLog(ex20);
									if (Debugger.IsAttached)
									{
										Debugger.Break();
									}
									ProjectData.ClearProjectError();
								}
							}
							else
							{
								if (!AlliedSidesPerSide[item.ActualUnit.get_UnitSide(SetSideOnly: false).ObjectID].Contains(closure$__152-3.$VB$Local_theSide.ObjectID))
								{
									continue;
								}
								try
								{
									if (array == null)
									{
										array = new ActiveUnit[0];
										Side[] sides_ReadOnly4 = closure$__152-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.Sides_ReadOnly;
										foreach (Side side4 in sides_ReadOnly4)
										{
											if (side4 != closure$__152-3.$VB$Local_theSide && side4.get_ConsidersThisSideToBe(closure$__152-3.$VB$Local_theSide, (Scenario)null) != Misc.PostureStance.Friendly)
											{
												continue;
											}
											foreach (ActiveUnit unit3 in side4.Units)
											{
												if (!unit3.CommStuff.IsConnectedToSideNetwork)
												{
													array = (ActiveUnit[])Utils.CopyArray((Array)array, (Array)new ActiveUnit[array.Length + 1]);
													array[^1] = unit3;
												}
											}
										}
									}
									if (!array.Contains(item.ActualUnit))
									{
										hashSet.Add(item);
										closure$__152-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.AddMessage("Contact " + item.Name + " detected by " + item.OriginalDetectorSide.Name + " droppped - " + ((!item.ActualUnit.get_UnitSide(SetSideOnly: false).FriendlySidesThisPulse.Contains(closure$__152-3.$VB$Local_theSide)) ? "" : "for known friendly unit ") + ((item.ActualUnit.get_UnitSide(SetSideOnly: false) == closure$__152-3.$VB$Local_theSide) ? "for my unit" : ""), "Contact dropped deliberately", LoggedMessage.MessageType.ContactChange, 0, null, closure$__152-3.$VB$Local_theSide, new Geopoint_Struct(((Module_Unit.Unit)item).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)item).get_Latitude((GlobalVariables.BooleanObject)null)));
									}
								}
								catch (Exception ex21)
								{
									ProjectData.SetProjectError(ex21);
									Exception ex22 = ex21;
									ex22?.Data.Add("Error at 983174140909_6", "");
									WriteExceptionsToLog(ex22);
									if (Debugger.IsAttached)
									{
										Debugger.Break();
									}
									ProjectData.ClearProjectError();
								}
							}
						}
						try
						{
							ref Scenario theScen = ref closure$__152-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen;
							ref Side theSide = ref closure$__152-3.$VB$Local_theSide;
							ActiveUnit TheDetectingUnit = null;
							MissionPlanner.UpdateMissionWaypoints_AirborneAircraft(0f, ref theScen, ref theSide, ref TheDetectingUnit);
						}
						catch (Exception ex23)
						{
							ProjectData.SetProjectError(ex23);
							Exception ex24 = ex23;
							ex24?.Data.Add("Error at 983174140909_7", "");
							WriteExceptionsToLog(ex24);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
						if (TaskList_PostPulseHousekeeping_RefineAOU.Count > 0)
						{
							Task.WaitAll(TaskList_PostPulseHousekeeping_RefineAOU.ToArray());
							TaskList_PostPulseHousekeeping_RefineAOU.Clear();
						}
						if (closure$__152-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.FifthSecondIsChangingOnThisPulse)
						{
							foreach (Contact item4 in list2)
							{
								if (!flag || item4.SkipZoneChecks || (item4.ActualUnit != null && item4.ActualUnit.IsShip && ((Ship)item4.ActualUnit).IsSinking))
								{
									continue;
								}
								if (!closure$__152-3.$VB$Local_theSide.Cache_ContactStancesOnThisPulse.TryGetValue(item4.ObjectID, out var value))
								{
									value = item4.get_Stance(closure$__152-3.$VB$Local_theSide);
									closure$__152-3.$VB$Local_theSide.Cache_ContactStancesOnThisPulse.AddIfNotExists(item4.ObjectID, value);
								}
								if (value == Misc.PostureStance.Hostile || value == Misc.PostureStance.Friendly)
								{
									continue;
								}
								foreach (ExclusionZone exclusionZone in closure$__152-3.$VB$Local_theSide.ExclusionZones)
								{
									if (value == Misc.PostureStance.Hostile || exclusionZone.Area.Count == 0 || item4.ActualUnit == null || !((Zone)exclusionZone).get_AffectsThisUnit(item4.ActualUnit))
									{
										continue;
									}
									bool flag5 = true;
									if (((Module_Unit.Unit)item4.ActualUnit).get_IsInsideThisArea((List<ReferencePoint>)exclusionZone.Area, closure$__152-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen, UseCache: true) && ((Module_Unit.Unit)item4).get_IsInsideThisArea((List<ReferencePoint>)exclusionZone.Area, closure$__152-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen, UseCache: true))
									{
										bool flag6 = true;
										bool flag7 = true;
										if (exclusionZone.AltitudeEnvelopeMin.HasValue)
										{
											flag6 = item4.AltitudeIsKnown && ((Module_Unit.Unit)item4).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) >= exclusionZone.AltitudeEnvelopeMin.Value;
										}
										if (exclusionZone.AltitudeEnvelopeMax.HasValue)
										{
											flag7 = item4.AltitudeIsKnown && ((Module_Unit.Unit)item4).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= exclusionZone.AltitudeEnvelopeMax.Value;
										}
										if (flag6 && flag7)
										{
											flag5 = false;
											Misc.PostureStance postureStance;
											if (!item4.SideIsKnown)
											{
												if (!exclusionZone.ViolatorsStance.ContainsKey("UnknownContactSide"))
												{
													exclusionZone.ViolatorsStance.Add("UnknownContactSide", exclusionZone.MarkViolatorAs);
												}
												postureStance = exclusionZone.ViolatorsStance["UnknownContactSide"];
											}
											else
											{
												if (!exclusionZone.ViolatorsStance.ContainsKey(item4.get_UnitSide(SetSideOnly: false).ObjectID))
												{
													exclusionZone.ViolatorsStance.Add(item4.get_UnitSide(SetSideOnly: false).ObjectID, exclusionZone.MarkViolatorAs);
												}
												postureStance = exclusionZone.ViolatorsStance[item4.get_UnitSide(SetSideOnly: false).ObjectID];
											}
											if (value != postureStance)
											{
												switch (postureStance)
												{
												case Misc.PostureStance.Hostile:
													try
													{
														if (array == null)
														{
															array = new ActiveUnit[0];
															Side[] sides_ReadOnly5 = closure$__152-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.Sides_ReadOnly;
															foreach (Side side5 in sides_ReadOnly5)
															{
																if (side5 != closure$__152-3.$VB$Local_theSide && side5.get_ConsidersThisSideToBe(closure$__152-3.$VB$Local_theSide, (Scenario)null) != Misc.PostureStance.Friendly)
																{
																	continue;
																}
																foreach (ActiveUnit unit4 in side5.Units)
																{
																	if (!unit4.CommStuff.IsConnectedToSideNetwork)
																	{
																		array = (ActiveUnit[])Utils.CopyArray((Array)array, (Array)new ActiveUnit[array.Length + 1]);
																		array[^1] = unit4;
																	}
																}
															}
														}
														if (array.Length <= 0)
														{
															goto IL_149d;
														}
														bool flag8 = false;
														ActiveUnit[] array2 = array;
														foreach (ActiveUnit activeUnit in array2)
														{
															_ = Debugger.IsAttached;
															if (((activeUnit.IsAircraft && item4.IsAircraftContact) || (activeUnit.IsShip && item4.IsShipContact) || (activeUnit.IsSubmarine && item4.IsSubmergedContact) || (activeUnit.IsFacility && item4.Type == Contact_Base.ContactType.Facility_Mobile) || (activeUnit.IsAggregatedUnit && item4.Type == Contact_Base.ContactType.AggregateGroundUnit)) && Module_Unit.RangeToPoint_Horiz(item4, activeUnit.Latitude_LastReported.Value, activeUnit.Longitude_LastReported.Value) < 10f && value != Misc.PostureStance.Unfriendly)
															{
																closure$__152-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.AddMessage("Contact: " + item4.Name + " has violated Exclusion Zone: " + exclusionZone.Description + " but is near the last reported location of " + activeUnit.Name + ", so marking as UNFRIENDLY for further investigation", item4.Name + " is unfriendly", LoggedMessage.MessageType.ContactChange, 0, null, closure$__152-3.$VB$Local_theSide, new Geopoint_Struct(((Module_Unit.Unit)item4).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)item4).get_Latitude((GlobalVariables.BooleanObject)null)));
																flag8 = true;
																break;
															}
														}
														if (!flag8)
														{
															goto IL_149d;
														}
														item4.set_Stance(closure$__152-3.$VB$Local_theSide, MarkManually: false, Misc.PostureStance.Unfriendly);
														item4.SkipZoneChecks = true;
														goto end_IL_124b;
														IL_149d:
														closure$__152-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.AddMessage("Contact: " + item4.Name + " has violated Exclusion Zone: " + exclusionZone.Description + " and is now considered HOSTILE", item4.Name + "is HOSTILE!", LoggedMessage.MessageType.ContactChange, 0, null, closure$__152-3.$VB$Local_theSide, new Geopoint_Struct(((Module_Unit.Unit)item4).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)item4).get_Latitude((GlobalVariables.BooleanObject)null)));
														item4.set_Stance(closure$__152-3.$VB$Local_theSide, MarkManually: false, postureStance);
														end_IL_124b:;
													}
													catch (Exception ex27)
													{
														ProjectData.SetProjectError(ex27);
														Exception ex28 = ex27;
														ex28?.Data.Add("Error at 983174140909_99", "");
														WriteExceptionsToLog(ex28);
														if (Debugger.IsAttached)
														{
															Debugger.Break();
														}
														ProjectData.ClearProjectError();
														break;
													}
													continue;
												case Misc.PostureStance.Unfriendly:
													try
													{
														closure$__152-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.AddMessage("Contact: " + item4.Name + " has violated Exclusion Zone: " + exclusionZone.Description + " and is now considered UNFRIENDLY", item4.Name + " is UNFRIENDLY", LoggedMessage.MessageType.ContactChange, 0, null, closure$__152-3.$VB$Local_theSide, new Geopoint_Struct(((Module_Unit.Unit)item4).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)item4).get_Latitude((GlobalVariables.BooleanObject)null)));
														item4.set_Stance(closure$__152-3.$VB$Local_theSide, MarkManually: false, postureStance);
													}
													catch (Exception ex25)
													{
														ProjectData.SetProjectError(ex25);
														Exception ex26 = ex25;
														ex26?.Data.Add("Error at 983174140909_98", "");
														WriteExceptionsToLog(ex26);
														if (Debugger.IsAttached)
														{
															Debugger.Break();
														}
														ProjectData.ClearProjectError();
													}
													break;
												}
											}
										}
									}
									if (flag5 && item4.SideIsKnown && item4.InheritsSideStance && value == exclusionZone.MarkViolatorAs && value != closure$__152-3.$VB$Local_theSide.get_ConsidersThisSideToBe(item4.get_UnitSide(SetSideOnly: false), (Scenario)null))
									{
										item4.set_Stance(closure$__152-3.$VB$Local_theSide, MarkManually: false, closure$__152-3.$VB$Local_theSide.get_ConsidersThisSideToBe(item4.get_UnitSide(SetSideOnly: false), (Scenario)null));
									}
								}
							}
						}
						try
						{
							if (closure$__152-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.SecondIsChangingOnThisPulse && list2.Count > 0)
							{
								HashSet<Side> FriendsList2 = new HashSet<Side>();
								closure$__152-3.$VB$Local_theSide.GetAllFriendlySides(closure$__152-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen, ref FriendsList2);
								foreach (Contact item5 in list2)
								{
									if (!hashSet.Contains(item5) && flag3)
									{
										Module_Side.ShareContactWithFriends(closure$__152-3.$VB$Local_theSide, closure$__152-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen, item5, FriendsList2);
									}
								}
							}
						}
						catch (Exception ex29)
						{
							ProjectData.SetProjectError(ex29);
							Exception ex30 = ex29;
							ex30?.Data.Add("Error at 983174140909_97", "");
							WriteExceptionsToLog(ex30);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
						foreach (Contact baseContacts_ in closure$__152-3.$VB$Local_theSide.BaseContacts_List)
						{
							try
							{
								if (baseContacts_.ActualUnit == null)
								{
									continue;
								}
								if (baseContacts_.ActualUnit != null && !closure$__152-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.ActiveUnits.ContainsKey(baseContacts_.ActualUnit.ObjectID))
								{
									closure$__152-3.$VB$Local_theSide.DropBaseContact(baseContacts_, ref closure$__152-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen);
								}
								if (baseContacts_.ActualUnit == null)
								{
									closure$__152-3.$VB$Local_theSide.DropBaseContact(baseContacts_, ref closure$__152-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen);
								}
								else
								{
									if (baseContacts_.Type != Contact_Base.ContactType.MobileGroup)
									{
										continue;
									}
									bool flag9 = false;
									foreach (ActiveUnit value3 in ((Group)baseContacts_.ActualUnit).Units.Values)
									{
										if (closure$__152-3.$VB$Local_theSide.Contacts.ContainsKey(value3.ObjectID))
										{
											flag9 = true;
											break;
										}
									}
									if (!flag9)
									{
										closure$__152-3.$VB$Local_theSide.DropBaseContact(baseContacts_, ref closure$__152-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen);
									}
									continue;
								}
							}
							catch (Exception ex31)
							{
								ProjectData.SetProjectError(ex31);
								Exception ex32 = ex31;
								ex32?.Data.Add("Error at 983174140909_96", "");
								WriteExceptionsToLog(ex32);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
							}
						}
						int count = closure$__152-3.$VB$Local_theSide.RefPoints.Count;
						List<ReferencePoint> list3 = new List<ReferencePoint>(count);
						int num = count - 1;
						for (int num2 = 0; num2 <= num; num2++)
						{
							list3.Add(closure$__152-3.$VB$Local_theSide.RefPoints[num2]);
						}
						foreach (ExclusionZone exclusionZone2 in closure$__152-3.$VB$Local_theSide.ExclusionZones)
						{
							foreach (ReferencePoint item6 in exclusionZone2.Area)
							{
								if (item6.IsRelativeTo != null && !closure$__152-3.$VB$Local_theSide.RefPoints.Contains(item6))
								{
									list3.Add(item6);
								}
							}
						}
						foreach (NoNavZone noNavZone in closure$__152-3.$VB$Local_theSide.NoNavZones)
						{
							foreach (ReferencePoint item7 in noNavZone.Area)
							{
								if (item7.IsRelativeTo != null && !closure$__152-3.$VB$Local_theSide.RefPoints.Contains(item7))
								{
									list3.Add(item7);
								}
							}
						}
						foreach (ReferencePoint item8 in list3)
						{
							if (item8 == null || item8.IsRelativeTo == null)
							{
								continue;
							}
							try
							{
								if (item8.IsRelativeTo.IsActiveUnit && !closure$__152-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.ActiveUnits.ContainsKey(item8.IsRelativeTo.ObjectID))
								{
									item8.IsRelativeTo = null;
									continue;
								}
								if (item8.IsRelativeTo.IsContact())
								{
									bool flag10 = true;
									foreach (KeyValuePair<string, Contact> contact3 in closure$__152-3.$VB$Local_theSide.Contacts)
									{
										if ((Operators.CompareString(contact3.Value.ObjectID, item8.IsRelativeTo.ObjectID, false) == 0) | (Operators.CompareString(contact3.Value.ActualUnit.ObjectID, item8.IsRelativeTo.ObjectID, false) == 0))
										{
											flag10 = false;
										}
									}
									if (flag10)
									{
										item8.IsRelativeTo = null;
										continue;
									}
								}
							}
							catch (Exception ex33)
							{
								ProjectData.SetProjectError(ex33);
								Exception ex34 = ex33;
								ex34?.Data.Add("Error at 983174140909_94", "");
								WriteExceptionsToLog(ex34);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
							}
							if (item8.IsRelativeTo.IsUnit() | item8.IsRelativeTo.IsContact() | item8.IsRelativeTo.IsActiveUnit)
							{
								try
								{
									Module_Unit.Unit unit = (Module_Unit.Unit)item8.IsRelativeTo;
									switch (item8.BearingType)
									{
									case ReferencePoint.OrientationType.Fixed:
										bearing = item8.RelativeBearing;
										break;
									case ReferencePoint.OrientationType.Rotating:
										bearing = Math2.NormalizeBearing(unit.CurrentHeading + item8.RelativeBearing);
										break;
									}
									double lon = unit.get_Longitude((GlobalVariables.BooleanObject)null);
									double lat = unit.get_Latitude((GlobalVariables.BooleanObject)null);
									ReferencePoint referencePoint;
									double out_lon = (referencePoint = item8).Longitude;
									ReferencePoint referencePoint2;
									double out_lat = (referencePoint2 = item8).Latitude;
									Geodesic_EdWilliams.CalcPoint_Williams(lon, lat, ref out_lon, ref out_lat, item8.RelativeDistance, bearing);
									referencePoint2.Latitude = out_lat;
									referencePoint.Longitude = out_lon;
								}
								catch (Exception ex35)
								{
									ProjectData.SetProjectError(ex35);
									Exception ex36 = ex35;
									ex36?.Data.Add("Error at 983174140909_93", "");
									WriteExceptionsToLog(ex36);
									if (Debugger.IsAttached)
									{
										Debugger.Break();
									}
									ProjectData.ClearProjectError();
								}
								continue;
							}
							try
							{
								if (item8.IsRelativeTo.IsReferencePoint())
								{
									GeoPoint geoPoint = (GeoPoint)item8.IsRelativeTo;
									switch (item8.BearingType)
									{
									case ReferencePoint.OrientationType.Rotating:
										item8.BearingType = ReferencePoint.OrientationType.Fixed;
										bearing = item8.RelativeBearing;
										break;
									case ReferencePoint.OrientationType.Fixed:
										bearing = item8.RelativeBearing;
										break;
									}
									double longitude = geoPoint.Longitude;
									double latitude = geoPoint.Latitude;
									ReferencePoint referencePoint2;
									double out_lat = (referencePoint2 = item8).Longitude;
									ReferencePoint referencePoint;
									double out_lon = (referencePoint = item8).Latitude;
									Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref out_lat, ref out_lon, item8.RelativeDistance, bearing);
									referencePoint.Latitude = out_lon;
									referencePoint2.Longitude = out_lat;
								}
							}
							catch (Exception ex37)
							{
								ProjectData.SetProjectError(ex37);
								Exception ex38 = ex37;
								ex38?.Data.Add("Error at 983174140909_92", "");
								WriteExceptionsToLog(ex38);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
							}
						}
						try
						{
							foreach (Contact item9 in hashSet)
							{
								if (!closure$__152-3.$VB$Local_theSide.ContactsJustSharedWithMe.Contains(item9.ActualUnit.ObjectID))
								{
									closure$__152-3.$VB$Local_theSide.DropContact(item9, ref closure$__152-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen, LogMessage: true);
								}
							}
							closure$__152-3.$VB$Local_theSide.ProcessContactListChanges(closure$__152-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen);
							closure$__152-3.$VB$Local_theSide.ProcessBaseContactListChanges(closure$__152-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen);
						}
						catch (Exception ex39)
						{
							ProjectData.SetProjectError(ex39);
							Exception ex40 = ex39;
							ex40?.Data.Add("Error at 983174140909_91", "");
							WriteExceptionsToLog(ex40);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
				}
				Task[] array3 = new Task[NumberOfCoreWorkerThreads - 1 + 1];
				closure$__152-2.$VB$Local_WorkerThreadUnitLists = Misc.smethod_5(closure$__152-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.ActiveUnits_List, NumberOfCoreWorkerThreads);
				int num3 = NumberOfCoreWorkerThreads - 1;
				_Closure$__152-2 closure$__152-4 = default(_Closure$__152-2);
				for (int num4 = 0; num4 <= num3; num4++)
				{
					closure$__152-4 = new _Closure$__152-2(closure$__152-4);
					closure$__152-4.$VB$NonLocal_$VB$Closure_3 = closure$__152-2;
					closure$__152-4.$VB$Local_theIndex = num4;
					array3[num4] = Task.Factory.StartNew(closure$__152-4._Lambda$__2);
				}
				int num5 = NumberOfCoreWorkerThreads - 1;
				for (int num6 = 0; num6 <= num5; num6++)
				{
					if (array3[num6] != null)
					{
						array3[num6].Wait();
					}
				}
			}
			catch (Exception ex41)
			{
				ProjectData.SetProjectError(ex41);
				Exception ex42 = ex41;
				ex42?.Data.Add("Error at 101254", "");
				WriteExceptionsToLog(ex42);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			closure$__152-.$VB$Local_theScen.ActiveUnits_List = null;
			closure$__152-.$VB$Local_theScen.GuidedWeaponsInAir = null;
			closure$__152-.$VB$Local_theScen.SonobuoysInWater = null;
			closure$__152-.$VB$Local_theScen.AllWeaponsAlive = null;
			closure$__152-.$VB$Local_theScen.CleanUpExplosions();
			closure$__152-.$VB$Local_theScen.CleanUpWeaponImpacts();
			if (closure$__152-.$VB$Local_theScen.CurrentlyInsertingMessages)
			{
				closure$__152-.$VB$Local_theScen.EventWaitHandle_FinishPulse.WaitOne();
			}
		}
		catch (Exception ex43)
		{
			ProjectData.SetProjectError(ex43);
			Exception ex44 = ex43;
			ex44?.Data.Add("Error at 300012", "");
			WriteExceptionsToLog(ex44);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void smethod_7(ref Scenario scenario_0)
	{
		try
		{
			scenario_0.Groups.Clear();
			ActiveUnit[] array = scenario_0.ActiveUnits_List.InternalArray();
			foreach (ActiveUnit activeUnit in array)
			{
				if (activeUnit != null && activeUnit.IsGroup)
				{
					scenario_0.Groups.Add((Group)activeUnit);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 300013", "");
			WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void AddUnitToCollections(ref ActiveUnit theUnit, ref Scenario theScen)
	{
		lock (lockObject_1)
		{
			theScen.ActiveUnits.TryAdd(theUnit.ObjectID, theUnit);
			if ((Beta_PlatformComms & theScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.PointToPointComm)) && !theUnit.IsGroup)
			{
				theScen.ManageUnitAdditionForNetworks(theUnit);
			}
		}
	}

	internal static T DeepCopy<T>(T item)
	{
		T result = default(T);
		try
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			T val;
			using (MemoryStream memoryStream = RCMS.recyclableMemoryStreamManager_0.GetStream())
			{
				binaryFormatter.Serialize(memoryStream, item);
				memoryStream.Seek(0L, SeekOrigin.Begin);
				val = (T)binaryFormatter.Deserialize(memoryStream);
			}
			result = val;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 300015", "");
			WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private static void smethod_8(ref Scenario scenario_0, float float_2, ref LockRandom lockRandom_0)
	{
		try
		{
			ObservableList<Explosion> explosions = scenario_0.Explosions;
			if (explosions != null && explosions.Count > 0)
			{
				for (int i = scenario_0.Explosions.Count - 1; i >= 0; i += -1)
				{
					scenario_0.Explosions[i]?.Progress(ref scenario_0, float_2);
				}
			}
			ObservableList<WeaponImpact> weaponImpacts = scenario_0.WeaponImpacts;
			if (weaponImpacts != null && weaponImpacts.Count > 0)
			{
				for (int j = scenario_0.WeaponImpacts.Count - 1; j >= 0; j += -1)
				{
					scenario_0.WeaponImpacts[j]?.Progress(ref scenario_0, float_2);
				}
			}
			List<ChaffCorridorCloud> chaffClouds = scenario_0.ChaffClouds;
			if (chaffClouds != null && chaffClouds.Count > 0)
			{
				for (int k = scenario_0.ChaffClouds.Count - 1; k >= 0; k += -1)
				{
					ChaffCorridorCloud chaffCorridorCloud = scenario_0.ChaffClouds[k];
					chaffCorridorCloud.Progress(float_2);
					if (((Module_Unit.Unit)chaffCorridorCloud).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < 0f || Terrain.GetElevation(((Module_Unit.Unit)chaffCorridorCloud).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)chaffCorridorCloud).get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, scenario_0) > chaffCorridorCloud.CurtainCeiling)
					{
						scenario_0.ChaffClouds.Remove(chaffCorridorCloud);
					}
				}
			}
			ObservableList<WaterSplash> waterSplashes = scenario_0.WaterSplashes;
			if (waterSplashes != null && waterSplashes.Count > 0)
			{
				for (int l = scenario_0.WaterSplashes.Count - 1; l >= 0; l += -1)
				{
					scenario_0.WaterSplashes[l]?.Spread(scenario_0, float_2);
				}
			}
			ObservableList<GroundImpact> groundImpacts = scenario_0.GroundImpacts;
			if (groundImpacts != null && groundImpacts.Count > 0)
			{
				for (int m = scenario_0.GroundImpacts.Count - 1; m >= 0; m += -1)
				{
					scenario_0.GroundImpacts[m]?.Spread(scenario_0, float_2);
				}
			}
			scenario_0.CandidatesForDetectionByMines.Clear();
			PooledList<ActiveUnit> activeUnits_List = scenario_0.ActiveUnits_List;
			foreach (ActiveUnit item in activeUnits_List)
			{
				if (item != null)
				{
					if (item.IsMCMPlatform_ThisPulse == -1)
					{
						item.Determine_IsMCMPlatform();
					}
					if ((item.IsShip || item.IsSubmarine || item.IsMCMPlatform_ThisPulse != 0) && item.IsOperating())
					{
						scenario_0.CandidatesForDetectionByMines.Add(item);
					}
				}
			}
			ConcurrentObservableDictionary<string, UnguidedWeapon> unguidedWeapons = scenario_0.UnguidedWeapons;
			if (unguidedWeapons != null && unguidedWeapons.Count > 0)
			{
				List<UnguidedWeapon> list = scenario_0.UnguidedWeapons.Values.ToList();
				for (int n = list.Count - 1; n >= 0; n += -1)
				{
					list[n]?.TypeSpecificActions(ref scenario_0, float_2, ref lockRandom_0);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 300016", "");
			WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal static bool UnitIsDestroyed(ref Scenario theScen, Module_Unit.Unit theUnit)
	{
		bool result;
		if (theUnit != null)
		{
			try
			{
				result = theUnit.IsActiveUnit && !theScen.ActiveUnits.ContainsKey(theUnit.ObjectID);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 300017", "");
				WriteExceptionsToLog(ex2);
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
		}
		else
		{
			result = true;
		}
		return result;
	}

	public static void CloneScenario(Scenario theScen)
	{
		try
		{
			while (theScen.ExecutionInProgress)
			{
				Thread.Sleep(10);
			}
			theScen.SerializationInProgress = true;
			MemoryTributary memoryTributary = new MemoryTributary();
			theScen.ToXML(memoryTributary, MinifyText: true);
			ScenarioLastGoodClone = memoryTributary;
			ScenarioLastGoodClone_DateTime = theScen.Time;
			theScen.SerializationInProgress = false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200581", ex2.Message);
			WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void DeconflictContactsBetweenAllies(Scenario theScen)
	{
		try
		{
			if (theScen.Sides_ReadOnly == null)
			{
				return;
			}
			Side[] sides_ReadOnly = theScen.Sides_ReadOnly;
			foreach (Side side in sides_ReadOnly)
			{
				int count = side.Contacts_List.Count;
				Contact[] array = side.Contacts_List.InternalArray();
				PooledList<Contact> pooledList = null;
				int num = count - 1;
				for (int j = 0; j <= num; j++)
				{
					Contact contact = array[j];
					if (contact == null || contact.ActualUnit == null)
					{
						continue;
					}
					bool flag = false;
					Side side2 = contact.ActualUnit.get_UnitSide(SetSideOnly: false);
					Side[] sides_ReadOnly2 = theScen.Sides_ReadOnly;
					for (int k = 0; k < sides_ReadOnly2.Length; k = checked(k + 1))
					{
						if (sides_ReadOnly2[k] == side2)
						{
							flag = true;
							break;
						}
					}
					if (flag && contact.ActualUnit.CommStuff.IsConnectedToSideNetwork && Module_Side.IsAlliedWithThisSide(side, contact.ActualUnit.get_UnitSide(SetSideOnly: false)))
					{
						if (pooledList == null)
						{
							pooledList = new PooledList<Contact>();
						}
						pooledList.Add(contact);
					}
				}
				if (pooledList == null)
				{
					continue;
				}
				foreach (Contact item in pooledList)
				{
					side.DropContact(item, ref theScen, LogMessage: false);
				}
				pooledList.Dispose();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 300019", "");
			WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static ExceptionEntry smethod_9(DateTime dateTime_0, string string_6)
	{
		ExceptionEntry result = default(ExceptionEntry);
		try
		{
			lock (lockObject_3)
			{
				ExceptionEntry exceptionEntry;
				if (!RegisteredExceptions.ContainsKey(string_6))
				{
					exceptionEntry = new ExceptionEntry(string_6, dateTime_0);
					RegisteredExceptions.Add(string_6, exceptionEntry);
				}
				else
				{
					exceptionEntry = RegisteredExceptions[string_6];
					exceptionEntry.AddOccurrences(dateTime_0);
				}
				result = exceptionEntry;
				return result;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			UseExceptionFuse = false;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static void WriteExceptionsToLog(Exception ex, bool RegisterThisException = true, bool OpenUI = false, bool NoFormating = false)
	{
		if (ex == null)
		{
			return;
		}
		try
		{
			if (ex is AggregateException)
			{
				foreach (Exception innerException in ((AggregateException)ex).InnerExceptions)
				{
					smethod_10(innerException, RegisterThisException, OpenUI, NoFormating);
				}
				return;
			}
			smethod_10(ex, RegisterThisException, OpenUI, NoFormating);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			smethod_10(ex, RegisterThisException, OpenUI, NoFormating);
			ProjectData.ClearProjectError();
		}
	}

	private static void smethod_10(Exception exception_0, bool bool_1, bool bool_2, bool bool_3)
	{
		try
		{
			if (SimConfiguration.DefaultGamePreferences != null && !SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
			{
				return;
			}
			if (stringBuilder_0 != null)
			{
				stringBuilder_0.Clear();
			}
			else
			{
				stringBuilder_0 = new StringBuilder();
			}
			DateTime now = DateTime.Now;
			if (!bool_3)
			{
				stringBuilder_0.Append(" -- B").Append("v1.10 - Build 1900.20").Append(" -- ")
					.Append(exception_0.Message)
					.Append(" -- Scen : " + Debug_LastLoadedScenario + " -- ")
					.Append("DB : " + Debug_LastLoadedDB + " -- ");
				stringBuilder_0.Append("Exception: ").Append(exception_0.Message).Append("\r\n")
					.Append("Stack Trace: ")
					.Append(exception_0.StackTrace)
					.Append("\r\n");
				if (exception_0.InnerException != null)
				{
					stringBuilder_0.Append("Inner Exception: ").Append(exception_0.InnerException.Message).Append("\r\n")
						.Append("Inner StackTrace: ")
						.Append(exception_0.InnerException.StackTrace)
						.Append("\r\n");
				}
				if (exception_0.Data.Count > 0)
				{
					stringBuilder_0.Append("Call Stack & Error details: ");
					IDictionaryEnumerator enumerator = exception_0.Data.GetEnumerator();
					while (enumerator.MoveNext())
					{
						object current = enumerator.Current;
						DictionaryEntry dictionaryEntry = ((current != null) ? ((DictionaryEntry)current) : default(DictionaryEntry));
						stringBuilder_0.Append("\r\n").Append(Conversions.ToString(dictionaryEntry.Key)).Append(": ")
							.Append(RuntimeHelpers.GetObjectValue(dictionaryEntry.Value));
					}
				}
			}
			else
			{
				stringBuilder_0.Append(exception_0.Message);
			}
			if (bool_1 && UseExceptionFuse)
			{
				ExceptionEntry exceptionEntry = smethod_9(now, stringBuilder_0.ToString());
				if (exceptionEntry != null && exceptionEntry.Fused)
				{
					return;
				}
				if (bool_2 && !exceptionEntry.UI_Ignored)
				{
					ErrorForm.Open(exceptionEntry);
				}
			}
			string text = stringBuilder_0.Insert(0, now.ToString("dd/MM/yyyy HH:mm:ss")).ToString();
			if (stringBuilder_1 != null)
			{
				stringBuilder_1.Clear();
			}
			else
			{
				stringBuilder_1 = new StringBuilder();
			}
			stringBuilder_1.Append(LogsPath).Append(Path.DirectorySeparatorChar).Append("ExceptionLog_")
				.Append(DateTime.Now.Year)
				.Append("_")
				.Append(DateTime.Now.Month.ToString("D2"))
				.Append("_")
				.Append(DateTime.Now.Day.ToString("D2"))
				.Append(".txt");
			string path = stringBuilder_1.ToString();
			lock (lockObject_2)
			{
				File.AppendAllText(path, "\r\n\r\n" + text);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void WriteLogDebugInfoToFile(string theDebugInfoText)
	{
		try
		{
			bool? flag = SimConfiguration.DefaultGamePreferences?.LogDebugInfoToFile;
			if (((!flag) ?? flag) == true)
			{
				return;
			}
			if (stringBuilder_1 == null)
			{
				stringBuilder_1 = new StringBuilder();
			}
			else
			{
				stringBuilder_1.Clear();
			}
			stringBuilder_1.Append(LogsPath).Append(Path.DirectorySeparatorChar).Append("ExceptionLog_")
				.Append(DateTime.Now.Year)
				.Append("_")
				.Append(DateTime.Now.Month.ToString("D2"))
				.Append("_")
				.Append(DateTime.Now.Day.ToString("D2"))
				.Append(".txt");
			string path = stringBuilder_1.ToString();
			lock (lockObject_2)
			{
				try
				{
					File.AppendAllText(path, theDebugInfoText + "\r\n");
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
			}
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void CheckForMissionWakeup(ref Scenario theScen, ref Side theSide, ref Mission theSpecificMission, bool IncludeEmptySlots, bool OrderTakeOff, bool LaunchPrePlannedPackages, int theRequestFlightSize)
	{
		if (theSide.Missions == null)
		{
			return;
		}
		Mission._GroupSize _GroupSize_ = default(Mission._GroupSize);
		Mission._GroupSize _GroupSize_2 = default(Mission._GroupSize);
		bool bool_2 = default(bool);
		bool bool_3 = default(bool);
		_Closure$__173-0 closure$__173- = default(_Closure$__173-0);
		ActiveUnit activeUnit = default(ActiveUnit);
		DateTime? theTakeOffTime = default(DateTime?);
		DateTime? theObjectiveTime = default(DateTime?);
		Mission._FlightSize _FlightSize_ = default(Mission._FlightSize);
		Mission._FlightSize _FlightSize_2 = default(Mission._FlightSize);
		Mission._FlightSize _FlightSize_3 = default(Mission._FlightSize);
		bool bool_4 = default(bool);
		bool bool_5 = default(bool);
		Mission._ContinousCoverageDuration continousCoverage_Duration = default(Mission._ContinousCoverageDuration);
		foreach (Mission item in theSide.get_MissionsTotal(theScen))
		{
			Mission theMission = item;
			bool flag = false;
			try
			{
				if (theMission == null || (theSpecificMission != null && theMission != theSpecificMission))
				{
					continue;
				}
				DateTime? startTime;
				DateTime time;
				if (theMission.get_Status(theScen) == Mission.MissionStatus.Inactive)
				{
					if (theMission.StartTime.HasValue)
					{
						startTime = theMission.StartTime;
						time = theScen.Time;
						if ((startTime.HasValue ? new bool?(DateTime.Compare(startTime.GetValueOrDefault(), time) <= 0) : ((bool?)null)) == true && (!theMission.EndTime.HasValue || (theMission.EndTime.HasValue && DateTime.Compare(theMission.EndTime.Value, theScen.Time) > 0)))
						{
							theMission.set_Status(theScen, Mission.MissionStatus.Active);
							theScen.AddMessage("Mission " + theMission.Name + " has been activated.", theMission.Name + "is activated", LoggedMessage.MessageType.UnitAI, 0, null, theSide);
						}
					}
					goto IL_0298;
				}
				if (!theMission.StartTime.HasValue)
				{
					goto IL_01a9;
				}
				startTime = theMission.StartTime;
				time = theScen.Time;
				if (((!startTime.HasValue) ? ((bool?)null) : new bool?(DateTime.Compare(startTime.GetValueOrDefault(), time) > 0)) != true)
				{
					goto IL_01a9;
				}
				theMission.set_Status(theScen, Mission.MissionStatus.Inactive);
				goto end_IL_002a;
				IL_01a9:
				if (theMission.EndTime.HasValue)
				{
					startTime = theMission.EndTime;
					time = theScen.Time;
					if ((startTime.HasValue ? new bool?(DateTime.Compare(startTime.GetValueOrDefault(), time) <= 0) : ((bool?)null)) == true)
					{
						theMission.set_Status(theScen, Mission.MissionStatus.Inactive);
						flag = true;
						theScen.AddMessage("Mission " + theMission.Name + " has been deactivated.", theMission.Name + "is deactivated", LoggedMessage.MessageType.UnitAI, 0, null, theSide);
					}
				}
				goto IL_0298;
				end_IL_002a:;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 10117826235462356246", "");
				WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				goto IL_0298;
			}
			continue;
			IL_1991:
			List<Group> list_;
			List<Aircraft> list_2;
			List<Aircraft> list_3;
			List<Aircraft> list_4;
			double double_;
			bool bool_;
			try
			{
				if (LaunchPrePlannedPackages && theMission.MissionClass == Mission._MissionClass.Strike)
				{
					smethod_11(ref theScen, ref theSide, ref theMission, ref list_, ref list_2, ref list_3, ref list_4, double_, ref bool_, bool_2: false, bool_3: true);
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at 10124636767536737", "");
				WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			try
			{
				if (LaunchPrePlannedPackages && (theMission.MissionClass == Mission._MissionClass.Patrol || theMission.MissionClass == Mission._MissionClass.Support))
				{
					smethod_14(ref theScen, ref theSide, ref theMission, double_);
				}
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				ex6?.Data.Add("Error at 10124615415265", "");
				WriteExceptionsToLog(ex6);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			List<ActiveUnit> theShipSubList_DockedReady;
			List<ActiveUnit> theShipSubList;
			List<int> theShipSubDBIDs;
			List<ActiveUnit> TheGroundUnitList;
			List<ActiveUnit> list_9;
			try
			{
				if (theShipSubList_DockedReady.Count > 0)
				{
					List<ActiveUnit> list_5 = new List<ActiveUnit>();
					List<ActiveUnit> list_6 = new List<ActiveUnit>();
					List<ActiveUnit> list_7 = new List<ActiveUnit>();
					List<ActiveUnit> list_8 = new List<ActiveUnit>();
					if ((smethod_29(ref theScen, ref theSide, theMission, !Information.IsNothing((object)theSpecificMission), ref list_5, ref list_6, ref list_7, ref list_8, ref _GroupSize_, ref _GroupSize_2, ref bool_2, ref bool_3, ref theShipSubList, ref theShipSubList_DockedReady, ref theShipSubDBIDs) || TheGroundUnitList.Count != 0) && (list_5.Count <= 0 || smethod_30(ref theScen, ref theSide, theMission, !Information.IsNothing((object)theSpecificMission), ref list_5, ref list_6, ref list_7, ref list_8, ref _GroupSize_, ref _GroupSize_2, ref bool_2, ref bool_3, ref list_9) || TheGroundUnitList.Count != 0))
					{
						goto IL_1b23;
					}
				}
				else
				{
					if (theShipSubList.Count <= 0)
					{
						goto IL_1b23;
					}
					List<ActiveUnit> list_10 = new List<ActiveUnit>();
					if (smethod_28(ref theScen, ref theSide, theMission, ref theShipSubList, ref list_10) || TheGroundUnitList.Count != 0)
					{
						goto IL_1b23;
					}
				}
				goto end_IL_1a5a;
				IL_1b23:
				if (TheGroundUnitList.Count > 0)
				{
					List<ActiveUnit> list_11 = new List<ActiveUnit>();
					smethod_28(ref theScen, ref theSide, theMission, ref TheGroundUnitList, ref list_11);
				}
				end_IL_1a5a:;
			}
			catch (Exception ex7)
			{
				ProjectData.SetProjectError(ex7);
				Exception ex8 = ex7;
				ex8?.Data.Add("Error at 1012461451543426", "");
				WriteExceptionsToLog(ex8);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			continue;
			IL_0298:
			if (flag)
			{
				try
				{
					if (theMission.Deactivation_OrderRTB)
					{
						using PooledList<ActiveUnit>.Enumerator enumerator2 = theScen.ActiveUnits_List.GetEnumerator();
						while (enumerator2.MoveNext())
						{
							closure$__173- = new _Closure$__173-0(closure$__173-);
							closure$__173-.$VB$Local_theAU = enumerator2.Current;
							if (closure$__173-.$VB$Local_theAU == null || closure$__173-.$VB$Local_theAU.IsGroup || !closure$__173-.$VB$Local_theAU.IsOperating() || closure$__173-.$VB$Local_theAU.ActiveMissionOrPackage() != theMission)
							{
								continue;
							}
							if (closure$__173-.$VB$Local_theAU.IsAircraft)
							{
								if (GlobalVariables.AI_REWORK)
								{
									((Aircraft)closure$__173-.$VB$Local_theAU).AI.StatusRelatedEvents.method_0(manuallyOrdered: true, ActiveUnit._ActiveUnitStatus.RTB_Manual, groupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, detachFromGroup: false, clearPlottedCourse: true, null, closure$__173-._Lambda$__0);
								}
								else if (closure$__173-.$VB$Local_theAU.AirOps.AttemptToRTB(ManuallyOrdered: true, ActiveUnit._ActiveUnitStatus.RTB_Manual, GroupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, DetachFromGroup: false, ClearPlottedCourse: true))
								{
									string text = "";
									if (Operators.CompareString(closure$__173-.$VB$Local_theAU.Name, closure$__173-.$VB$Local_theAU.UnitClass, false) != 0)
									{
										text = " (" + closure$__173-.$VB$Local_theAU.UnitClass + ")";
									}
									string text2 = "";
									ActiveUnit actualDestinationHost = ((Aircraft)closure$__173-.$VB$Local_theAU).AirOps.ActualDestinationHost;
									if (!Information.IsNothing((object)actualDestinationHost))
									{
										text2 = " (" + actualDestinationHost.Name + ")";
									}
									closure$__173-.$VB$Local_theAU.ParentScen.AddMessage(closure$__173-.$VB$Local_theAU.Name + text + " is returning to base" + text2, closure$__173-.$VB$Local_theAU.Name + "is RTB", LoggedMessage.MessageType.AirOps, 5, closure$__173-.$VB$Local_theAU.ObjectID, closure$__173-.$VB$Local_theAU.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(closure$__173-.$VB$Local_theAU.get_Longitude((GlobalVariables.BooleanObject)null), closure$__173-.$VB$Local_theAU.get_Latitude((GlobalVariables.BooleanObject)null)));
								}
							}
							else if ((closure$__173-.$VB$Local_theAU.IsShip || closure$__173-.$VB$Local_theAU.IsSubmarine) && closure$__173-.$VB$Local_theAU.DockingOps.AttemptToRTB(ManuallyOrdered: true, ActiveUnit._ActiveUnitStatus.RTB_Manual, GroupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, DetachFromGroup: false, ClearPlottedCourse: true))
							{
								string text3 = "";
								ActiveUnit actualDestinationHost2 = closure$__173-.$VB$Local_theAU.DockingOps.ActualDestinationHost;
								if (!Information.IsNothing((object)actualDestinationHost2))
								{
									text3 = " (" + actualDestinationHost2.Name + ")";
								}
								closure$__173-.$VB$Local_theAU.ParentScen.AddMessage(closure$__173-.$VB$Local_theAU.Name + " is returning to docking unit" + text3, closure$__173-.$VB$Local_theAU.Name + "is RTB", LoggedMessage.MessageType.DockingOps, 5, closure$__173-.$VB$Local_theAU.ObjectID, closure$__173-.$VB$Local_theAU.get_UnitSide(SetSideOnly: false));
							}
						}
					}
					if (theMission.Deactivation_UnassignUnits)
					{
						foreach (KeyValuePair<ActiveUnit, ActiveUnit> item2 in theMission.UnitsAssignedToMission)
						{
							CoreClientCode.RemoveUnitFromMission_Core(item2.Value, theScen, theSide);
						}
						theScen.AddMessage("All units unassigned from mission " + theMission.Name + " due to the deactivation settings.", theMission.Name + " all units unassigned", LoggedMessage.MessageType.UnitAI, 0, null, theSide);
					}
					if (theMission.Deactivation_DeleteMission)
					{
						theMission.DeleteMission(ref theScen, ref theSide, BypassWarning: true);
						theScen.AddMessage("Mission " + theMission.Name + " has been deleted due to the deactivation settings.", theMission.Name + " has been deleted", LoggedMessage.MessageType.UnitAI, 0, null, theSide);
					}
				}
				catch (Exception ex9)
				{
					ProjectData.SetProjectError(ex9);
					Exception ex10 = ex9;
					ex10?.Data.Add("Error at 1011782625621646", "");
					WriteExceptionsToLog(ex10);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
					goto IL_06ca;
				}
				continue;
			}
			goto IL_06ca;
			IL_14ee:
			int NumberOfAircraft_Ready;
			if (theMission.MissionClass != Mission._MissionClass.Patrol && theMission.MissionClass != Mission._MissionClass.Support)
			{
				bool flag2 = false;
				if ((theMission.FlightList != null) & (theMission.FlightList.Count > 0))
				{
					foreach (Mission.Flight flight in theMission.FlightList)
					{
						try
						{
							if (flight.TakeOffLocation_HostUnitObjectID != null && Operators.CompareString(flight.TakeOffLocation_HostUnitObjectID, "", false) != 0)
							{
								activeUnit = theScen.ActiveUnits[flight.TakeOffLocation_HostUnitObjectID];
							}
							if (activeUnit != null)
							{
								if (activeUnit.CurrentSpeed == 0f)
								{
									if (theMission.MissionClass == Mission._MissionClass.Strike)
									{
										Strike strike = (Strike)theMission;
										foreach (Module_Unit.Unit specificTarget in strike.SpecificTargets)
										{
											if (!(specificTarget.CurrentSpeed <= 0f))
											{
												flag2 = true;
												break;
											}
										}
									}
									else if (theMission.MissionClass == Mission._MissionClass.Ferry)
									{
										FerryMission ferryMission = (FerryMission)theMission;
										if (ferryMission.get_NominalDestinationHost(theScen) != null && ferryMission.get_NominalDestinationHost(theScen).CurrentSpeed > 0f)
										{
											flag2 = true;
										}
									}
								}
								else
								{
									flag2 = true;
								}
								continue;
							}
							flag2 = true;
						}
						catch (Exception ex11)
						{
							ProjectData.SetProjectError(ex11);
							Exception ex12 = ex11;
							ex12?.Data.Add("Error at 10124600000000000", "");
							WriteExceptionsToLog(ex12);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
							continue;
						}
						break;
					}
				}
				else
				{
					flag2 = true;
				}
				if (!flag2 && NumberOfAircraft_Ready == 0)
				{
					continue;
				}
			}
			List<Aircraft> theAircraftList_AvailableForFlightPlanGenerator;
			try
			{
				foreach (Aircraft item3 in theAircraftList_AvailableForFlightPlanGenerator)
				{
					item3.Kinematics.DetermineReserveFuelQty();
				}
			}
			catch (Exception ex13)
			{
				ProjectData.SetProjectError(ex13);
				Exception ex14 = ex13;
				ex14?.Data.Add("Error at 1012412516276", "");
				WriteExceptionsToLog(ex14);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			Mission.Flight.DetermineInitialFlightPlanTimes(ref theScen, ref theMission, ref theTakeOffTime, ref theObjectiveTime);
			List<Aircraft> theAircraftList;
			int int_;
			int int_2;
			int int_3;
			int int_4;
			int int_5;
			int int_6;
			int NumberOfAircraft_AirborneOrTakingOff;
			int NumberOfAircraft_AirborneOrTakingOff_Escort_Shooter;
			int NumberOfAircraft_AirborneOrTakingOff_Escort_NonShooter;
			int NumberOfAircraft_Ready_Escorts_Shooter;
			int NumberOfAircraft_Ready_Escorts_NonShooter;
			List<Aircraft> list_13;
			List<Aircraft> list_14;
			Doctrine._UseUnderwayRefuelAndReplenishment? nullable_;
			bool bool_6;
			List<int> theLoadoutsList;
			List<int> theAircraftDBIDs;
			float float_;
			float float_2;
			string string_;
			int int_7;
			int int_8;
			List<ActiveUnit> theAircraftHostsList;
			List<Aircraft> list_12;
			if (!smethod_15(ref theScen, ref theSide, ref theMission, !Information.IsNothing((object)theSpecificMission), ref theAircraftList, ref _FlightSize_, ref _FlightSize_2, ref _FlightSize_3, ref bool_4, ref bool_5, ref int_, ref int_2, ref int_3, ref int_4, ref int_5, ref int_6, ref NumberOfAircraft_AirborneOrTakingOff, ref NumberOfAircraft_AirborneOrTakingOff_Escort_Shooter, ref NumberOfAircraft_AirborneOrTakingOff_Escort_NonShooter, ref NumberOfAircraft_Ready, ref NumberOfAircraft_Ready_Escorts_Shooter, ref NumberOfAircraft_Ready_Escorts_NonShooter, ref theAircraftList_AvailableForFlightPlanGenerator, ref list_12, ref list_13, ref list_14, ref nullable_, ref bool_6, ref theLoadoutsList, ref theAircraftDBIDs, ref float_, ref float_2, ref string_, ref int_7, ref int_8, !Information.IsNothing((object)theSpecificMission), theTakeOffTime, theObjectiveTime, bool_6: false, ref theAircraftHostsList, !Information.IsNothing((object)theSpecificMission), theRequestFlightSize))
			{
				continue;
			}
			list_12 = list_12.Distinct().ToList();
			List<Aircraft> EmptySlotsReferenceAircraftList;
			if (list_12.Count > 0 || ((IncludeEmptySlots || bool_) && (list_13.Count > 0 || list_14.Count > 0)))
			{
				if (theMission.MissionClass == Mission._MissionClass.Strike)
				{
					try
					{
						List<Mission.Flight> list = new List<Mission.Flight>();
						foreach (Aircraft item4 in theAircraftList)
						{
							if (((ActiveUnit_Navigator)item4.Navigator).get_Flight(HierarchySearch: true) != null && !list.Contains(((ActiveUnit_Navigator)item4.Navigator).get_Flight(HierarchySearch: true)))
							{
								list.Add(((ActiveUnit_Navigator)item4.Navigator).get_Flight(HierarchySearch: true));
							}
						}
						theMission.FlightList = list;
						Strike strike2 = (Strike)theMission;
						if (strike2.MaxFlightNumber_Strike == Mission._FlightQty.NoPreferences || theMission.FlightList.Count < Mission.FlightQty_To_ActualFlightQty(ref strike2.MaxFlightNumber_Strike))
						{
							bool bool_7 = !Information.IsNothing((object)theSpecificMission);
							bool bool_8 = !Information.IsNothing((object)theSpecificMission);
							Mission.Flight flight_ = null;
							if (!smethod_22(ref theScen, ref theSide, ref theMission, bool_7, ref theAircraftList, ref _FlightSize_, ref _FlightSize_2, ref _FlightSize_3, ref bool_4, ref bool_5, ref int_, ref int_2, ref int_3, ref int_4, ref int_5, ref int_6, ref list_12, ref list_13, ref list_14, ref nullable_, ref bool_6, ref theLoadoutsList, ref float_, ref float_2, OrderTakeOff, ref list_, ref list_2, ref list_3, ref list_4, ref theAircraftHostsList, ref EmptySlotsReferenceAircraftList, ref string_, double_, ref bool_, IncludeEmptySlots, bool_8, bool_9: false, ref flight_, !Information.IsNothing((object)theSpecificMission)))
							{
								continue;
							}
						}
					}
					catch (Exception ex15)
					{
						ProjectData.SetProjectError(ex15);
						Exception ex16 = ex15;
						ex16?.Data.Add("Error at 10124145145156", "");
						WriteExceptionsToLog(ex16);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
						continue;
					}
				}
				else
				{
					bool bool_9 = !Information.IsNothing((object)theSpecificMission);
					bool bool_10 = !Information.IsNothing((object)theSpecificMission);
					Mission.Flight flight_ = null;
					if (!smethod_22(ref theScen, ref theSide, ref theMission, bool_9, ref theAircraftList, ref _FlightSize_, ref _FlightSize_2, ref _FlightSize_3, ref bool_4, ref bool_5, ref int_, ref int_2, ref int_3, ref int_4, ref int_5, ref int_6, ref list_12, ref list_13, ref list_14, ref nullable_, ref bool_6, ref theLoadoutsList, ref float_, ref float_2, OrderTakeOff, ref list_, ref list_2, ref list_3, ref list_4, ref theAircraftHostsList, ref EmptySlotsReferenceAircraftList, ref string_, double_, ref bool_, IncludeEmptySlots, bool_10, bool_9: false, ref flight_, !Information.IsNothing((object)theSpecificMission)))
					{
						continue;
					}
				}
			}
			goto IL_1991;
			IL_06ca:
			if (theMission.get_Status(theScen) != Mission.MissionStatus.Active && OrderTakeOff)
			{
				continue;
			}
			list_ = new List<Group>();
			list_2 = new List<Aircraft>();
			list_3 = new List<Aircraft>();
			list_4 = new List<Aircraft>();
			double_ = 120.0;
			bool_ = false;
			if (theMission.TimeSincePlayerNotification >= 30)
			{
				theMission.TimeSincePlayerNotification = 1;
			}
			else
			{
				theMission.TimeSincePlayerNotification++;
			}
			theAircraftList = new List<Aircraft>();
			theAircraftList_AvailableForFlightPlanGenerator = new List<Aircraft>();
			List<Aircraft> theAircraftList_AssignedToFlight = new List<Aircraft>();
			List<Aircraft> theAircraftList_AssignedToFlight_OnGroundReady = new List<Aircraft>();
			theAircraftHostsList = new List<ActiveUnit>();
			theLoadoutsList = new List<int>();
			theAircraftDBIDs = new List<int>();
			theShipSubList = new List<ActiveUnit>();
			theShipSubList_DockedReady = new List<ActiveUnit>();
			theShipSubDBIDs = new List<int>();
			list_9 = new List<ActiveUnit>();
			TheGroundUnitList = new List<ActiveUnit>();
			NumberOfAircraft_AirborneOrTakingOff = 0;
			NumberOfAircraft_AirborneOrTakingOff_Escort_Shooter = 0;
			NumberOfAircraft_AirborneOrTakingOff_Escort_NonShooter = 0;
			NumberOfAircraft_Ready = 0;
			NumberOfAircraft_Ready_Escorts_Shooter = 0;
			NumberOfAircraft_Ready_Escorts_NonShooter = 0;
			List<Mission.Flight> theFlightList_Ready = new List<Mission.Flight>();
			List<Mission.Flight> theFlightList_NotReady = new List<Mission.Flight>();
			List<Mission.Flight> theFlightList_HasEmptySlots = new List<Mission.Flight>();
			bool_6 = false;
			float_ = 0f;
			float_2 = 0f;
			EmptySlotsReferenceAircraftList = new List<Aircraft>();
			List<Aircraft> EmptySlotsReferenceAircraftList_Ready = new List<Aircraft>();
			List<Aircraft> EmptySlotsReferenceAircraftList_AssignedToFlight = new List<Aircraft>();
			int NumberOfEmptySlots_Ready = 0;
			int NumberOfEmptySlots_Ready_Escorts_Shooter = 0;
			int NumberOfEmptySlots_Ready_Escorts_NonShooter = 0;
			if (IncludeEmptySlots)
			{
				try
				{
					if (!Information.IsNothing((object)theMission.EmptySlotsList) && theMission.EmptySlotsList.Count > 0)
					{
						int num = 1;
						foreach (Mission.EmptyAircraftSlot emptySlots in theMission.EmptySlotsList)
						{
							if (emptySlots.ReferenceUnit_DBID != 0)
							{
								Mission mission = theMission;
								int referenceUnit_DBID = emptySlots.ReferenceUnit_DBID;
								int int_9 = emptySlots.int_0;
								Mission.EmptyAircraftSlot emptyAircraftSlot;
								Scenario theScen2;
								ActiveUnit theHost = (emptyAircraftSlot = emptySlots).get_CurrentHostUnit(theScen2 = theScen);
								Mission.EmptyAircraftSlot emptyAircraftSlot2;
								Scenario theScen3;
								Mission.Flight flight_ = (emptyAircraftSlot2 = emptySlots).get_MissionFlight(theScen3 = theScen);
								Aircraft aircraft = mission.CreateEmptySlotReferenceUnit(ref theScen, ref theSide, referenceUnit_DBID, int_9, ref theHost, ref flight_, emptySlots.IsEscort, num);
								emptyAircraftSlot2.set_MissionFlight(theScen3, flight_);
								emptyAircraftSlot.set_CurrentHostUnit(theScen2, theHost);
								Aircraft aircraft2 = aircraft;
								emptySlots.set_ReferenceUnit(theScen, (Mission)null, (ActiveUnit)aircraft2);
								EmptySlotsReferenceAircraftList.Add(aircraft2);
								num++;
							}
						}
					}
				}
				catch (Exception ex17)
				{
					ProjectData.SetProjectError(ex17);
					Exception ex18 = ex17;
					ex18?.Data.Add("Error at 101145145145246", "");
					WriteExceptionsToLog(ex18);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			if (theSpecificMission == null && theScen.FifthMinuteIsChangingOnThisPulse)
			{
				try
				{
					bool flag3 = false;
					foreach (KeyValuePair<ActiveUnit, ActiveUnit> item5 in theMission.UnitsAssignedToMission)
					{
						if (item5.Value.IsAircraft)
						{
							Aircraft aircraft3 = (Aircraft)item5.Value;
							if (aircraft3.AirOps.get_AssignedHostUnit(PickNewAssignedHost: false) != null && aircraft3.AirOps.get_AssignedHostUnit(PickNewAssignedHost: false).MaxSpeed > 0f)
							{
								flag3 = true;
							}
						}
					}
					if (theMission.MissionClass == Mission._MissionClass.Strike)
					{
						Strike strike3 = (Strike)theMission;
						if (strike3.SpecificTargets.Count > 0)
						{
							foreach (Module_Unit.Unit specificTarget2 in strike3.SpecificTargets)
							{
								if (specificTarget2.IsContact())
								{
									if (((Contact)specificTarget2).ActualUnit.MaxSpeed > 0f)
									{
										flag3 = true;
										break;
									}
								}
								else if (!(((ActiveUnit)specificTarget2).MaxSpeed <= 0f))
								{
									flag3 = true;
									break;
								}
							}
						}
					}
					if (flag3)
					{
						MissionPlanner.UpdateMissionWaypoints_BeforeTakeOff(ref theScen, ref theMission);
					}
				}
				catch (Exception ex19)
				{
					ProjectData.SetProjectError(ex19);
					Exception ex20 = ex19;
					ex20?.Data.Add("Error at 10124572572876", "");
					WriteExceptionsToLog(ex20);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			bool flag4 = false;
			bool flag5 = false;
			bool flag6 = false;
			if (theMission.MissionClass == Mission._MissionClass.Patrol)
			{
				Patrol obj = (Patrol)theMission;
				flag4 = obj.ContinousCoverage_Enable;
				flag5 = obj.ContinousCoverage_QRAEnable;
				continousCoverage_Duration = obj.ContinousCoverage_Duration;
			}
			if (theMission.MissionClass == Mission._MissionClass.Support)
			{
				SupportMission obj2 = (SupportMission)theMission;
				flag4 = obj2.ContinousCoverage_Enable;
				flag5 = obj2.ContinousCoverage_QRAEnable;
				continousCoverage_Duration = obj2.ContinousCoverage_Duration;
			}
			if (flag4)
			{
				try
				{
					switch (continousCoverage_Duration)
					{
					default:
						if (theScen.HourIsChangingOnThisPulse)
						{
							flag6 = true;
						}
						break;
					case Mission._ContinousCoverageDuration.hr_2:
						if (theScen.FifthMinuteIsChangingOnThisPulse)
						{
							flag6 = true;
						}
						break;
					case Mission._ContinousCoverageDuration.hr_4:
						if (theScen.FifteenthMinuteIsChangingOnThisPulse)
						{
							flag6 = true;
						}
						break;
					case Mission._ContinousCoverageDuration.hr_6:
						if (theScen.ThirtiethMinuteIsChangingOnThisPulse)
						{
							flag6 = true;
						}
						break;
					}
					if (flag6 || !Information.IsNothing((object)theSpecificMission) || theMission.FlightList.Count == 0)
					{
						smethod_12(ref theScen, ref theSide, ref theMission, !Information.IsNothing((object)theSpecificMission), double_, !Information.IsNothing((object)theSpecificMission), !Information.IsNothing((object)theSpecificMission));
						if (flag5)
						{
							smethod_13(ref theScen, ref theSide, ref theMission, !Information.IsNothing((object)theSpecificMission), double_, !Information.IsNothing((object)theSpecificMission), !Information.IsNothing((object)theSpecificMission));
						}
					}
				}
				catch (Exception ex21)
				{
					ProjectData.SetProjectError(ex21);
					Exception ex22 = ex21;
					ex22?.Data.Add("Error at 10121451546", "");
					WriteExceptionsToLog(ex22);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			if (theMission.MissionClass == Mission._MissionClass.Strike && ((Strike)theMission).SpecificTargets.Count > 0)
			{
				try
				{
					bool flag7 = false;
					foreach (Module_Unit.Unit specificTarget3 in ((Strike)theMission).SpecificTargets)
					{
						if (flag7)
						{
							continue;
						}
						if (specificTarget3.IsActiveUnit)
						{
							if (!((ActiveUnit)specificTarget3).get_IsAutoDetectable(theSide))
							{
								if (flag7)
								{
									continue;
								}
								foreach (KeyValuePair<string, Contact> contact in theSide.Contacts)
								{
									if (Operators.CompareString(contact.Value.ActualUnit.ObjectID, specificTarget3.ObjectID, false) == 0)
									{
										flag7 = true;
										break;
									}
								}
								continue;
							}
							flag7 = true;
							break;
						}
						flag7 = true;
						break;
					}
					if (!flag7)
					{
						continue;
					}
				}
				catch (Exception ex23)
				{
					ProjectData.SetProjectError(ex23);
					Exception ex24 = ex23;
					ex24?.Data.Add("Error at 10121451541546", "");
					WriteExceptionsToLog(ex24);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
					continue;
				}
			}
			try
			{
				if (!LaunchPrePlannedPackages || !theMission.IsActive || !theMission.HasInactiveFlights())
				{
					goto IL_0d25;
				}
				smethod_11(ref theScen, ref theSide, ref theMission, ref list_, ref list_2, ref list_3, ref list_4, double_, ref bool_, bool_2: true, bool_3: false);
				if (bool_)
				{
					goto IL_0d25;
				}
				goto end_IL_0cf1;
				IL_0d25:
				theMission.ReconfigureMissionForPrePlannedFlights(ref theScen, ref theSide, null);
				goto IL_0d7b;
				end_IL_0cf1:;
			}
			catch (Exception ex25)
			{
				ProjectData.SetProjectError(ex25);
				Exception ex26 = ex25;
				ex26?.Data.Add("Error at 1012514351541546", "");
				WriteExceptionsToLog(ex26);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			continue;
			IL_0d7b:
			if (!theMission.UsePreGeneratedFlightplansOnly || (!Information.IsNothing((object)theSpecificMission) && !flag4))
			{
				theMission.UnitsAssignedToMission_SeparatedByType(theScen, ref theLoadoutsList, ref theAircraftDBIDs, ref theAircraftList, ref theAircraftList_AvailableForFlightPlanGenerator, ref theAircraftList_AssignedToFlight, ref theAircraftList_AssignedToFlight_OnGroundReady, ref theAircraftHostsList, ref NumberOfAircraft_AirborneOrTakingOff, ref NumberOfAircraft_AirborneOrTakingOff_Escort_Shooter, ref NumberOfAircraft_AirborneOrTakingOff_Escort_NonShooter, ref NumberOfAircraft_Ready, ref NumberOfAircraft_Ready_Escorts_Shooter, ref NumberOfAircraft_Ready_Escorts_NonShooter, ref theShipSubDBIDs, ref theShipSubList, ref theShipSubList_DockedReady, list_9, ref TheGroundUnitList, ref EmptySlotsReferenceAircraftList, ref EmptySlotsReferenceAircraftList_Ready, ref EmptySlotsReferenceAircraftList_AssignedToFlight, ref NumberOfEmptySlots_Ready, ref NumberOfEmptySlots_Ready_Escorts_Shooter, ref NumberOfEmptySlots_Ready_Escorts_NonShooter, ref theFlightList_Ready, ref theFlightList_NotReady, ref theFlightList_HasEmptySlots, OrderTakeOff, IncludeEmptySlots, IsContinousCoverage: false);
				if (NumberOfAircraft_Ready > 0 || (IncludeEmptySlots && NumberOfEmptySlots_Ready > 0) || ((IncludeEmptySlots || bool_) && (NumberOfAircraft_Ready_Escorts_Shooter > 0 || NumberOfAircraft_Ready_Escorts_NonShooter > 0 || NumberOfEmptySlots_Ready_Escorts_Shooter > 0 || NumberOfEmptySlots_Ready_Escorts_NonShooter > 0)))
				{
					list_12 = new List<Aircraft>();
					list_13 = new List<Aircraft>();
					list_14 = new List<Aircraft>();
					int_ = 0;
					int_2 = 0;
					int_3 = 0;
					int_4 = 0;
					int_5 = 0;
					int_6 = 0;
					nullable_ = theMission.Doctrine.get_UseReplenishment(theScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
					string_ = "";
					int_7 = 0;
					int_8 = 0;
					if (Information.IsNothing((object)theSpecificMission) && !Information.IsNothing((object)nullable_))
					{
						byte? b = (byte?)nullable_;
						bool? flag8 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
						if (((!flag8) ?? flag8) == true && theMission.TankerUsage == Mission.TankerMethod.Mission)
						{
							if (Information.IsNothing((object)theMission.TankerMissions) || theMission.TankerMissions.Count == 0)
							{
								theScen.AddMessage("Mission " + theMission.Name + " requires tankers from specified missions, however no tanker missions have been selected! The strike mission will not launch!", theMission.Name + " not launching (no tankers!)", LoggedMessage.MessageType.AirOps, 0, null, theSide);
								continue;
							}
							int num2;
							if (theMission.TankerMinNumber_Total <= 0 && theMission.TankerMinNumber_Airborne <= 0)
							{
								if (theMission.TankerMinNumber_Station <= 0)
								{
									goto IL_14ee;
								}
								num2 = 0;
							}
							else
							{
								num2 = 0;
							}
							int num3 = num2;
							int num4 = 0;
							int num5 = 0;
							try
							{
								foreach (Mission tankerMission in theMission.TankerMissions)
								{
									foreach (ActiveUnit item6 in Module_Mission.UnitsAssignedToMissionOrPackage(tankerMission, theScen))
									{
										if (!item6.IsAircraft)
										{
											continue;
										}
										Aircraft aircraft4 = (Aircraft)item6;
										if (!aircraft4.IsTanker || (((ActiveUnit)aircraft4).get_UnitSide(SetSideOnly: false) != theSide && !Module_Side.IsAlliedWithThisSide(((ActiveUnit)aircraft4).get_UnitSide(SetSideOnly: false), theSide)))
										{
											continue;
										}
										if (((ActiveUnit)aircraft4).get_UnitSide(SetSideOnly: false) != theSide)
										{
											Doctrine._RefuelAlliedUnits? refuelAlliedUnits = aircraft4.Doctrine.get_RefuelAllies(theScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
											b = (byte?)refuelAlliedUnits;
											if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 3)) == true)
											{
												continue;
											}
											b = (byte?)refuelAlliedUnits;
											if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
											{
												continue;
											}
										}
										num3++;
										if (aircraft4.IsOperating())
										{
											num4++;
											if (tankerMission.MissionClass == Mission._MissionClass.Support && !aircraft4.Navigator.IsInSupportTransit)
											{
												num5++;
											}
										}
									}
								}
							}
							catch (Exception ex27)
							{
								ProjectData.SetProjectError(ex27);
								Exception ex28 = ex27;
								ex28?.Data.Add("Error at 10124523626276", "");
								WriteExceptionsToLog(ex28);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
								continue;
							}
							if (theMission.TankerMinNumber_Total > 0)
							{
								if (num3 == 0)
								{
									if (theMission.TimeSincePlayerNotification == 1)
									{
										theScen.AddMessage("Mission " + theMission.Name + " requires " + Conversions.ToString(theMission.TankerMinNumber_Total) + " tankers in total, however none are available! The mission will not launch!", theMission.Name + " not launching (no tankers!)", LoggedMessage.MessageType.AirOps, 0, null, theSide);
									}
									continue;
								}
								if (num3 < theMission.TankerMinNumber_Total)
								{
									if (theMission.TimeSincePlayerNotification == 1)
									{
										theScen.AddMessage("Mission " + theMission.Name + " requires " + Conversions.ToString(theMission.TankerMinNumber_Total) + " tankers in total, however only " + Conversions.ToString(num3) + " tankers are available! The mission will not launch!", theMission.Name + " not launching (not enough tankers!)", LoggedMessage.MessageType.AirOps, 0, null, theSide);
									}
									continue;
								}
							}
							if (theMission.TankerMinNumber_Airborne > 0)
							{
								if (num4 == 0)
								{
									if (theMission.TimeSincePlayerNotification == 1)
									{
										theScen.AddMessage("Mission " + theMission.Name + " requires " + Conversions.ToString(theMission.TankerMinNumber_Airborne) + " airborne tankers, however none are currently airborne! The mission will not launch!", theMission.Name + " not launching (no tankers up!)", LoggedMessage.MessageType.AirOps, 0, null, theSide);
									}
									continue;
								}
								if (num4 < theMission.TankerMinNumber_Airborne)
								{
									if (theMission.TimeSincePlayerNotification == 1)
									{
										theScen.AddMessage("Mission " + theMission.Name + " requires " + Conversions.ToString(theMission.TankerMinNumber_Airborne) + " airborne tankers, however only " + Conversions.ToString(num4) + " tankers are currently airborne! The mission will not launch!", theMission.Name + " not launching (not enough tankers up!)", LoggedMessage.MessageType.AirOps, 0, null, theSide);
									}
									continue;
								}
							}
							if (theMission.TankerMinNumber_Station > 0)
							{
								if (num5 == 0)
								{
									if (theMission.TimeSincePlayerNotification == 1)
									{
										theScen.AddMessage("Mission " + theMission.Name + " requires " + Conversions.ToString(theMission.TankerMinNumber_Station) + " tankers on station, however none are currently on station! The mission will not launch!", theMission.Name + " not launching (no tankers on station!)", LoggedMessage.MessageType.AirOps, 0, null, theSide);
									}
									continue;
								}
								if (num5 < theMission.TankerMinNumber_Station)
								{
									if (theMission.TimeSincePlayerNotification == 1)
									{
										theScen.AddMessage("Mission " + theMission.Name + " requires " + Conversions.ToString(theMission.TankerMinNumber_Station) + " tankers on station, however only " + Conversions.ToString(num5) + " tankers are currently on station! The mission will not launch!", theMission.Name + " not launching (not enough tankers on station!)", LoggedMessage.MessageType.AirOps, 0, null, theSide);
									}
									continue;
								}
							}
						}
					}
					goto IL_14ee;
				}
			}
			goto IL_1991;
		}
	}

	private static void smethod_11(ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, ref List<Group> list_2, ref List<Aircraft> list_3, ref List<Aircraft> list_4, ref List<Aircraft> list_5, double double_0, ref bool bool_1, bool bool_2, bool bool_3)
	{
		try
		{
			if (!mission_0.HasFlights())
			{
				return;
			}
			Mission obj = mission_0;
			Scenario theScen = scenario_0;
			bool IsManual = false;
			obj.FillEmptySlots(theScen, ref side_0, ref IsManual, null, FillFlightsWithNoAircraftSpecified: true);
			int count = mission_0.FlightList.Count;
			List<Mission.Flight> list = new List<Mission.Flight>();
			list_2.Clear();
			list_3.Clear();
			list_4.Clear();
			list_5.Clear();
			PooledList<ActiveUnit> pooledList = default(PooledList<ActiveUnit>);
			if (bool_2)
			{
				double theLat = default(double);
				double theLon = default(double);
				for (int i = count - 1; i >= 0; i += -1)
				{
					Mission.Flight theFlight = mission_0.FlightList[i];
					if (theFlight == null)
					{
						continue;
					}
					if (!scenario_0.ActiveUnits.TryGetValue(theFlight.TakeOffLocation_HostUnitObjectID, out var value))
					{
						Dictionary<string, int> dictionary = new Dictionary<string, int>();
						if (pooledList == null)
						{
							pooledList = theFlight.get_Item(mission_0, scenario_0);
						}
						foreach (ActiveUnit item in pooledList)
						{
							if (!item.IsAircraft)
							{
								continue;
							}
							ActiveUnit currentHostUnit = ((Aircraft)item).AirOps.CurrentHostUnit;
							if (currentHostUnit != null)
							{
								if (dictionary.ContainsKey(currentHostUnit.ObjectID))
								{
									dictionary[currentHostUnit.ObjectID]++;
								}
								else
								{
									dictionary.Add(currentHostUnit.ObjectID, 1);
								}
							}
						}
						if (dictionary.Count > 0)
						{
							theFlight.TakeOffLocation_HostUnitObjectID = dictionary.OrderByDescending([SpecialName] (KeyValuePair<string, int> x) => x.Value).First().Key;
						}
					}
					if (theFlight.HasCriticalError)
					{
						Geopoint_Struct theLocation = default(Geopoint_Struct);
						if (value != null)
						{
							theLocation = new Geopoint_Struct(value.get_Longitude((GlobalVariables.BooleanObject)null), value.get_Latitude((GlobalVariables.BooleanObject)null));
						}
						string text = "";
						if (theFlight.ErrorList != null)
						{
							foreach (MDSP_Error error in theFlight.ErrorList)
							{
								text = text + error.Message + " \\n ";
							}
							scenario_0.AddMessage("Flight " + theFlight.Callsign + " on mission " + mission_0.Name + " flying from " + theFlight.TakeOffLocation_HostUnitObjectName + ", aircraft type " + theFlight.ReferenceUnit_Name + " and loadout type " + theFlight.get_LoadoutName(scenario_0) + " has one or more flightplan errors that prevents it from taking off!", theFlight.Callsign + " cannot take off (flightplan errors)\\n " + text, LoggedMessage.MessageType.AirOps, 0, null, side_0, theLocation);
							continue;
						}
						theFlight.HasCriticalError = false;
					}
					if (theFlight.Task == Mission._FlightTask.QRA || theFlight.IsEscort)
					{
						continue;
					}
					if (pooledList == null)
					{
						pooledList = theFlight.get_Item(mission_0, scenario_0);
					}
					if (theFlight.get_IsActive((IList<ActiveUnit>)pooledList))
					{
						continue;
					}
					double num;
					if (theFlight.FlightPlan == null || theFlight.FlightPlan.Count() <= 0)
					{
						num = ((mission_0 == null || !mission_0.TakeOffTime.HasValue) ? (-1.0) : ((mission_0.TakeOffTime.Value - scenario_0.Time).TotalSeconds - double_0));
					}
					else
					{
						Waypoint waypoint = theFlight.FlightPlan[0];
						if (!waypoint.Time_Zulu.HasValue && (mission_0.TimeOnTarget.HasValue || mission_0.TakeOffTime.HasValue))
						{
							Mission.Flight flight;
							Waypoint[] thePlottedCourse = (flight = theFlight).FlightPlan;
							Mission.Flight flight2;
							Scenario theScen2;
							ActiveUnit theAU = (flight2 = theFlight).get_ReferenceUnit(theScen2 = scenario_0);
							MissionPlanner.DetermineWaypointZuluTimes(ref scenario_0, ref mission_0, ref theFlight, ref thePlottedCourse, ref theAU, IsWingman: false, NewFlightPlan: true, BananaSplitRedSection: false, mission_0.TakeOffTime, mission_0.TimeOnTarget, Mission.Flight.FlightElement.LeadElement);
							flight2.set_ReferenceUnit(theScen2, theAU);
							flight.FlightPlan = thePlottedCourse;
							waypoint = theFlight.FlightPlan[0];
						}
						if (waypoint.Time_Zulu.HasValue)
						{
							double totalSeconds = (waypoint.Time_Zulu.Value - scenario_0.Time).TotalSeconds;
							if (value != null)
							{
								theLat = value.get_Latitude((GlobalVariables.BooleanObject)null);
								theLon = value.get_Longitude((GlobalVariables.BooleanObject)null);
							}
							if (totalSeconds < -300.0)
							{
								list.Add(theFlight);
								scenario_0.AddMessage("Flight " + theFlight.Callsign + " on mission " + mission_0.Name + " flying from " + theFlight.TakeOffLocation_HostUnitObjectName + ", aircraft type " + theFlight.ReferenceUnit_Name + " and loadout type " + theFlight.get_LoadoutName(scenario_0) + " is more than 5 minutes past its scheduled take-off time. The flight has been cancelled.", theFlight.Callsign + " cancelled", LoggedMessage.MessageType.AirOps, 0, null, side_0, new Geopoint_Struct(theLon, theLat));
								continue;
							}
							if (totalSeconds < 0.0 - double_0 - 60.0)
							{
								scenario_0.AddMessage("Flight " + theFlight.Callsign + " on mission " + mission_0.Name + " flying from " + theFlight.TakeOffLocation_HostUnitObjectName + ", aircraft type " + theFlight.ReferenceUnit_Name + " and loadout type " + theFlight.get_LoadoutName(scenario_0) + " is scheduled to take off but something has gotten in the way. The flight will be cancelled When it is 5 minutes past its scheduled take-off time.", theFlight.Callsign + " delayed, danger of cancel", LoggedMessage.MessageType.AirOps, 0, null, side_0, new Geopoint_Struct(theLon, theLat));
							}
							num = totalSeconds - double_0 - 60.0;
						}
						else
						{
							num = -1.0;
						}
					}
					if (mission_0.UseFlightSizeHardLimit)
					{
						mission_0.ResetFlightReadyAicraftCount(scenario_0, theFlight);
						if (theFlight.ReadyAircraftQty < theFlight.MinimumAircraftQty)
						{
							continue;
						}
					}
					if (!(num < 0.0))
					{
						continue;
					}
					List<ActiveUnit> list2 = new List<ActiveUnit>();
					foreach (ActiveUnit unit in side_0.Units)
					{
						if (unit.ActiveMissionOrPackage() != null && unit.Navigator.get_Flight(HierarchySearch: true) != null && theFlight == unit.Navigator.get_Flight(HierarchySearch: true) && unit.IsAircraft && !unit.IsOperating())
						{
							Aircraft aircraft = (Aircraft)unit;
							string ReasonForNot = null;
							if (aircraft.IsAvailableForOps(ref ReasonForNot) == 0 && aircraft.IsParkedAndReady())
							{
								list2.Add(unit);
								list_3.Add((Aircraft)unit);
							}
						}
					}
					if (list2.Count == 0)
					{
						continue;
					}
					if (list2.Count > 0)
					{
						if (list2.Count < theFlight.MinimumAircraftQty)
						{
							foreach (ActiveUnit item2 in list2)
							{
								list_3.Remove((Aircraft)item2);
							}
							if (mission_0.TimeSincePlayerNotification == 1)
							{
								scenario_0.AddMessage("Flight " + theFlight.Callsign + " requires minimum " + theFlight.MinimumAircraftQty.value + " aircraft, however only " + Conversions.ToString(list2.Count) + " are ready for take-off! The flight will not launch!", theFlight.Callsign + " not launching (not enough AC ready)", LoggedMessage.MessageType.AirOps, 0, null, side_0, new Geopoint_Struct(value.get_Longitude((GlobalVariables.BooleanObject)null), value.get_Latitude((GlobalVariables.BooleanObject)null)));
							}
							continue;
						}
						if (list2.Count > 1)
						{
							list2 = list2.OrderBy([SpecialName] (ActiveUnit theAc) => !theAc.Navigator.HasFlight).ToList();
							Mission.Flight flight3 = list2[0].Navigator.get_Flight(HierarchySearch: true);
							Group obj2 = new Group(ref scenario_0, ref side_0, list2, UsingMissionPlanner: true, null, mission_0);
							list_2.Add(obj2);
							int num2 = 2;
							foreach (ActiveUnit value2 in obj2.Units.Values)
							{
								if (!value2.IsGroupLead())
								{
									value2.SetFlight(flight3, num2);
									num2++;
								}
								else
								{
									value2.SetFlight(flight3, 1);
									obj2.Name = "Flight " + flight3.Callsign;
								}
							}
						}
						else
						{
							Mission.Flight flight3 = list2[0].Navigator.get_Flight(HierarchySearch: true);
							list2[0].SetFlight(flight3, 1);
						}
					}
					bool_1 = true;
				}
			}
			if (bool_3)
			{
				ActiveUnit activeUnit = default(ActiveUnit);
				for (int num3 = count - 1; num3 >= 0; num3 += -1)
				{
					Mission.Flight theFlight = mission_0.FlightList[num3];
					try
					{
						activeUnit = scenario_0.ActiveUnits[theFlight.TakeOffLocation_HostUnitObjectID];
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						Dictionary<ActiveUnit, int> dictionary2 = new Dictionary<ActiveUnit, int>();
						if (pooledList == null)
						{
							pooledList = theFlight.get_Item(mission_0, scenario_0);
						}
						foreach (ActiveUnit item3 in pooledList)
						{
							if (!item3.IsAircraft)
							{
								continue;
							}
							ActiveUnit currentHostUnit2 = ((Aircraft)item3).AirOps.CurrentHostUnit;
							if (currentHostUnit2 != null)
							{
								if (dictionary2.ContainsKey(currentHostUnit2))
								{
									dictionary2[currentHostUnit2]++;
								}
								else
								{
									dictionary2.Add(currentHostUnit2, 1);
								}
							}
						}
						if (dictionary2.Count > 0)
						{
							activeUnit = dictionary2.OrderByDescending([SpecialName] (KeyValuePair<ActiveUnit, int> x) => x.Value).First().Key;
						}
						ProjectData.ClearProjectError();
					}
					if (!theFlight.HasCriticalError)
					{
						if (theFlight.Task == Mission._FlightTask.QRA || !theFlight.IsEscort)
						{
							continue;
						}
						if (pooledList == null)
						{
							pooledList = theFlight.get_Item(mission_0, scenario_0);
						}
						if (theFlight.get_IsActive((IList<ActiveUnit>)pooledList))
						{
							continue;
						}
						double num4;
						if (theFlight.FlightPlan == null || theFlight.FlightPlan.Count() <= 0)
						{
							num4 = ((!bool_1) ? double.MaxValue : (-1.0));
						}
						else
						{
							Waypoint waypoint = theFlight.FlightPlan[0];
							if (!waypoint.Time_Zulu.HasValue)
							{
								num4 = (bool_1 ? (-1.0) : double.MaxValue);
							}
							else
							{
								double totalSeconds2 = (waypoint.Time_Zulu.Value - scenario_0.Time).TotalSeconds;
								if (totalSeconds2 < -300.0)
								{
									list.Add(theFlight);
									scenario_0.AddMessage("Flight " + theFlight.Callsign + " on mission " + mission_0.Name + " flying from " + theFlight.TakeOffLocation_HostUnitObjectName + ", aircraft type " + theFlight.ReferenceUnit_Name + " and loadout type " + theFlight.get_LoadoutName(scenario_0) + " is more than 5 minutes past its scheduled take-off time. The flight has been cancelled.", theFlight.Callsign + " cancelled (5 mins overdue)", LoggedMessage.MessageType.AirOps, 0, null, side_0, new Geopoint_Struct(activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
									continue;
								}
								if (totalSeconds2 < 0.0 - double_0 - 60.0)
								{
									scenario_0.AddMessage("Flight " + theFlight.Callsign + " on mission " + mission_0.Name + " flying from " + theFlight.TakeOffLocation_HostUnitObjectName + ", aircraft type " + theFlight.ReferenceUnit_Name + " and loadout type " + theFlight.get_LoadoutName(scenario_0) + " is scheduled to take off but something has gotten in the way. The flight will be cancelled When it is 5 minutes past its scheduled take-off time.", theFlight.Callsign + " delayed (5-min warning)", LoggedMessage.MessageType.AirOps, 0, null, side_0, new Geopoint_Struct(activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
								}
								num4 = totalSeconds2 - double_0 - 60.0;
							}
						}
						if (theFlight.ReadyAircraftQty < theFlight.MinimumAircraftQty || !(num4 < 0.0))
						{
							continue;
						}
						List<ActiveUnit> list3 = new List<ActiveUnit>();
						foreach (ActiveUnit unit2 in side_0.Units)
						{
							if (unit2.ActiveMissionOrPackage() == null || unit2.Navigator.get_Flight(HierarchySearch: true) == null || theFlight != unit2.Navigator.get_Flight(HierarchySearch: true) || !unit2.IsAircraft || unit2.IsOperating())
							{
								continue;
							}
							Aircraft aircraft2 = (Aircraft)unit2;
							string ReasonForNot = null;
							if (aircraft2.IsAvailableForOps(ref ReasonForNot) == 0 && aircraft2.IsParkedAndReady())
							{
								list3.Add(unit2);
								if (aircraft2.Loadout.IsSupportOrPatrol)
								{
									list_5.Add(aircraft2);
								}
								else
								{
									list_4.Add(aircraft2);
								}
							}
						}
						if (list3.Count == 0 || list3.Count <= 0)
						{
							continue;
						}
						if (list3.Count < theFlight.MinimumAircraftQty)
						{
							foreach (ActiveUnit item4 in list3)
							{
								if (((Aircraft)item4).Loadout.IsSupportOrPatrol)
								{
									list_5.Remove((Aircraft)item4);
								}
								else
								{
									list_4.Remove((Aircraft)item4);
								}
							}
							if (mission_0.TimeSincePlayerNotification == 1)
							{
								scenario_0.AddMessage("Flight " + theFlight.Callsign + " requires minimum " + theFlight.MinimumAircraftQty.value + " aircraft, however only " + Conversions.ToString(list3.Count) + " are ready For take-off! The flight will Not launch!", theFlight.Callsign + " not launching (not enough AC ready)", LoggedMessage.MessageType.AirOps, 0, null, side_0, new Geopoint_Struct(activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
							}
							continue;
						}
						Mission.Flight flight4 = list3[0].Navigator.get_Flight(HierarchySearch: true);
						if (list3.Count > 1)
						{
							Group obj3 = new Group(ref scenario_0, ref side_0, list3, UsingMissionPlanner: true, null, mission_0);
							list_2.Add(obj3);
							int num5 = 2;
							foreach (ActiveUnit value3 in obj3.Units.Values)
							{
								if (value3.IsGroupLead())
								{
									value3.SetFlight(flight4, 1);
									obj3.Name = "Flight " + flight4.Callsign;
								}
								else
								{
									value3.SetFlight(flight4, num5);
									num5++;
								}
							}
						}
						else
						{
							list3[0].SetFlight(flight4, 1);
						}
					}
					else
					{
						scenario_0.AddMessage("Flight " + theFlight.Callsign + " on mission " + mission_0.Name + " flying from " + theFlight.TakeOffLocation_HostUnitObjectName + ", aircraft type " + theFlight.ReferenceUnit_Name + " and loadout type " + theFlight.get_LoadoutName(scenario_0) + " has one or more flightplan errors that prevents it from taking off!", theFlight.Callsign + " not launching (flightplan errors)", LoggedMessage.MessageType.AirOps, 0, null, side_0, (activeUnit == null) ? default(Geopoint_Struct) : new Geopoint_Struct(activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
					}
				}
			}
			foreach (Mission.Flight item5 in list)
			{
				item5.ErrorList = new List<MDSP_Error>();
				item5.ErrorList.Add(new MDSP_Error(item5.ParentMissionOrPackageName, item5.Callsign, "Should have taken off at least 5 minutes ago but it didn't"));
				item5.HasCriticalError = true;
				_ = Debugger.IsAttached;
			}
			mission_0.OrderAircraftToTakeOff(ref scenario_0, list_2, list_3, list_4, list_5);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 7573735777555", "");
			WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void smethod_12(ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, bool bool_1, double double_0, bool bool_2, bool bool_3)
	{
		try
		{
			List<Aircraft> theAircraftList = new List<Aircraft>();
			List<Aircraft> theAircraftList_AvailableForFlightPlanGenerator = new List<Aircraft>();
			List<ActiveUnit> theAircraftHostsList = new List<ActiveUnit>();
			List<int> theLoadoutsList = new List<int>();
			List<int> theAircraftDBIDs = new List<int>();
			List<Mission.ContinousCoverageStation> continousCoverage_Stations = default(List<Mission.ContinousCoverageStation>);
			Mission._ContinousCoverageMethod continousCoverage_FlightGenerationMethod = default(Mission._ContinousCoverageMethod);
			Mission._ContinousCoverageStationTime continousCoverage_StationTime = default(Mission._ContinousCoverageStationTime);
			Mission._ContinousCoverageOverlap continousCoverage_Overlap = default(Mission._ContinousCoverageOverlap);
			Mission._ContinousCoverageDuration continousCoverage_Duration = default(Mission._ContinousCoverageDuration);
			int minimumNumberOnStation = default(int);
			bool oneThirdRule = default(bool);
			if (mission_0.MissionClass == Mission._MissionClass.Patrol)
			{
				Patrol obj = (Patrol)mission_0;
				continousCoverage_Stations = obj.ContinousCoverage_Stations;
				continousCoverage_FlightGenerationMethod = obj.ContinousCoverage_FlightGenerationMethod;
				continousCoverage_StationTime = obj.ContinousCoverage_StationTime;
				continousCoverage_Overlap = obj.ContinousCoverage_Overlap;
				continousCoverage_Duration = obj.ContinousCoverage_Duration;
				minimumNumberOnStation = obj.MinimumNumberOnStation;
				oneThirdRule = obj.OneThirdRule;
			}
			if (mission_0.MissionClass == Mission._MissionClass.Support)
			{
				SupportMission obj2 = (SupportMission)mission_0;
				continousCoverage_Stations = obj2.ContinousCoverage_Stations;
				continousCoverage_FlightGenerationMethod = obj2.ContinousCoverage_FlightGenerationMethod;
				continousCoverage_StationTime = obj2.ContinousCoverage_StationTime;
				continousCoverage_Overlap = obj2.ContinousCoverage_Overlap;
				continousCoverage_Duration = obj2.ContinousCoverage_Duration;
				minimumNumberOnStation = obj2.MinimumNumberOnStation;
				oneThirdRule = obj2.OneThirdRule;
			}
			switch (continousCoverage_FlightGenerationMethod)
			{
			case Mission._ContinousCoverageMethod.FlightplanTemplates:
			{
				Mission._FlightSize _FlightSize_4 = mission_0.FlightSize;
				bool bool_8 = mission_0.UseFlightSizeHardLimit;
				int int_8 = 0;
				List<Mission.Flight> list4 = new List<Mission.Flight>();
				List<Mission.Flight> list5 = new List<Mission.Flight>();
				foreach (Mission.Flight flight5 in mission_0.FlightList)
				{
					if (flight5.Task == Mission._FlightTask.QRA)
					{
						continue;
					}
					if (flight5.Type == Mission._FlightType.FlightplanTemplate)
					{
						if (!Information.IsNothing((object)flight5.FlightPlan) && flight5.FlightPlan.Count() != 0)
						{
							bool flag3 = false;
							bool flag4 = true;
							Waypoint[] theFlightplan2 = flight5.FlightPlan;
							foreach (Waypoint waypoint5 in theFlightplan2)
							{
								if (waypoint5.IsStationWaypoint())
								{
									flag3 = true;
								}
								if (waypoint5.IsStationEndWaypoint() && waypoint5.Station_Time <= 0f)
								{
									SendMessageBoxToUI("Flightplan " + flight5.Callsign + " has no station time set!", side_0);
									flag4 = false;
								}
							}
							if (flag4)
							{
								if (!flag3)
								{
									SendMessageBoxToUI("Flightplan " + flight5.Callsign + " has no station start / End waypoints! Flightplans must have station waypoints When used As templates For continuous coverage.", side_0);
								}
								else
								{
									list4.Add(flight5);
								}
							}
						}
						else
						{
							SendMessageBoxToUI("Flightplan " + flight5.Callsign + " has no waypoints! Add waypoints And Try again.", side_0);
						}
					}
					else
					{
						list5.Add(flight5);
					}
				}
				if (list4.Count > 0)
				{
					List<Mission.ContinousCoverageStation> list6 = null;
					if (list5.Count == 0 && !Information.IsNothing((object)continousCoverage_Stations))
					{
						if (mission_0.MissionClass == Mission._MissionClass.Patrol)
						{
							((Patrol)mission_0).ContinousCoverage_Stations.Clear();
						}
						if (mission_0.MissionClass == Mission._MissionClass.Support)
						{
							((SupportMission)mission_0).ContinousCoverage_Stations.Clear();
						}
					}
					if (!Information.IsNothing((object)continousCoverage_Stations) && continousCoverage_Stations.Count > 0)
					{
						list6 = continousCoverage_Stations.ToList();
					}
					int count5;
					if (!Information.IsNothing((object)list6))
					{
						int count4 = list6.Count;
						count5 = list5.Count;
						for (int num10 = count4 - 1; num10 >= 0; num10 += -1)
						{
							Mission.ContinousCoverageStation continousCoverageStation4 = list6[num10];
							bool flag5 = false;
							for (int num11 = count5 - 1; num11 >= 0; num11 += -1)
							{
								Mission.Flight flight2 = list5[num11];
								if (Operators.CompareString(flight2.ObjectID, continousCoverageStation4.FlightObjectID, false) == 0)
								{
									flag5 = true;
									break;
								}
							}
							if (!flag5)
							{
								if (mission_0.MissionClass == Mission._MissionClass.Patrol)
								{
									((Patrol)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation4);
								}
								if (mission_0.MissionClass == Mission._MissionClass.Support)
								{
									((SupportMission)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation4);
								}
							}
						}
					}
					if (!Information.IsNothing((object)continousCoverage_Stations) && continousCoverage_Stations.Count > 0)
					{
						list6 = continousCoverage_Stations.ToList();
					}
					int count6 = list4.Count;
					count5 = ((!Information.IsNothing((object)list6)) ? list6.Count : 0);
					string theHostUnitObjectID = default(string);
					for (int num12 = count6 - 1; num12 >= 0; num12 += -1)
					{
						Mission.Flight flight2 = list4[num12];
						bool flag6 = false;
						if (!Information.IsNothing((object)list6))
						{
							for (int num13 = count5 - 1; num13 >= 0; num13 += -1)
							{
								Mission.ContinousCoverageStation continousCoverageStation4 = list6[num13];
								if (Operators.CompareString(flight2.ObjectID, continousCoverageStation4.FlightplanTemplateObjectID, false) == 0)
								{
									flag6 = true;
									break;
								}
							}
						}
						if (flag6)
						{
							continue;
						}
						int theAircraftDBID;
						int theLoadoutDBID;
						if (!Information.IsNothing((object)flight2.get_ReferenceUnit(scenario_0)))
						{
							Aircraft aircraft6 = (Aircraft)flight2.get_ReferenceUnit(scenario_0);
							theAircraftDBID = aircraft6.DBID;
							theLoadoutDBID = aircraft6.LoadoutDBID;
							if (!Information.IsNothing((object)aircraft6.AirOps.CurrentHostUnit))
							{
								theHostUnitObjectID = aircraft6.AirOps.CurrentHostUnit.ObjectID;
							}
							else if (!Information.IsNothing((object)aircraft6.AirOps.get_AssignedHostUnit(PickNewAssignedHost: false)))
							{
								theHostUnitObjectID = aircraft6.AirOps.get_AssignedHostUnit(PickNewAssignedHost: false).ObjectID;
							}
						}
						else
						{
							Aircraft aircraft6 = null;
							theAircraftDBID = flight2.ReferenceUnit_DBID;
							theLoadoutDBID = flight2.int_1;
							theHostUnitObjectID = flight2.TakeOffLocation_HostUnitObjectID;
						}
						Mission.ContinousCoverageStation item3 = new Mission.ContinousCoverageStation("", theAircraftDBID, theLoadoutDBID, theHostUnitObjectID, scenario_0.Time, scenario_0.Time, flight2.ObjectID);
						if (mission_0.MissionClass == Mission._MissionClass.Patrol)
						{
							Patrol patrol2 = (Patrol)mission_0;
							if (Information.IsNothing((object)patrol2.ContinousCoverage_Stations))
							{
								patrol2.ContinousCoverage_Stations = new List<Mission.ContinousCoverageStation>();
							}
							patrol2.ContinousCoverage_Stations.Add(item3);
						}
						if (mission_0.MissionClass == Mission._MissionClass.Support)
						{
							SupportMission supportMission2 = (SupportMission)mission_0;
							if (Information.IsNothing((object)supportMission2.ContinousCoverage_Stations))
							{
								supportMission2.ContinousCoverage_Stations = new List<Mission.ContinousCoverageStation>();
							}
							supportMission2.ContinousCoverage_Stations.Add(item3);
						}
					}
					if (mission_0.MissionClass == Mission._MissionClass.Patrol)
					{
						continousCoverage_Stations = ((Patrol)mission_0).ContinousCoverage_Stations;
					}
					if (mission_0.MissionClass == Mission._MissionClass.Support)
					{
						continousCoverage_Stations = ((SupportMission)mission_0).ContinousCoverage_Stations;
					}
					DateTime t2 = scenario_0.Time.AddHours(mission_0.CCDurationQty_To_Hours(continousCoverage_Duration));
					double value4 = default(double);
					Waypoint waypoint8 = default(Waypoint);
					Waypoint waypoint9 = default(Waypoint);
					for (int num14 = continousCoverage_Stations.Count - 1; num14 >= 0; num14 += -1)
					{
						Mission.ContinousCoverageStation continousCoverageStation5 = continousCoverage_Stations[num14];
						DateTime? stationStartTime = continousCoverageStation5.StationStartTime;
						if ((stationStartTime.HasValue ? new bool?(DateTime.Compare(stationStartTime.GetValueOrDefault(), t2) < 0) : ((bool?)null)) != true)
						{
							continue;
						}
						if (!Information.IsNothing((object)continousCoverageStation5.HostUnitObjectID))
						{
							int int_9 = 0;
							Doctrine._UseUnderwayRefuelAndReplenishment? nullable_2 = mission_0.Doctrine.get_UseReplenishment(scenario_0, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
							string string_2 = "";
							if (!scenario_0.ActiveUnits.ContainsKey(continousCoverageStation5.HostUnitObjectID))
							{
								if (mission_0.MissionClass == Mission._MissionClass.Patrol)
								{
									((Patrol)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation5);
								}
								if (mission_0.MissionClass == Mission._MissionClass.Support)
								{
									((SupportMission)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation5);
								}
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								continue;
							}
							ActiveUnit theHost2 = scenario_0.ActiveUnits[continousCoverageStation5.HostUnitObjectID];
							if (!Information.IsNothing((object)theHost2))
							{
								Mission.Flight OriginalFlight = null;
								foreach (Mission.Flight flight6 in mission_0.FlightList)
								{
									if (Operators.CompareString(flight6.ObjectID, continousCoverageStation5.FlightplanTemplateObjectID, false) == 0)
									{
										OriginalFlight = flight6;
									}
								}
								if (Information.IsNothing((object)OriginalFlight))
								{
									if (Debugger.IsAttached)
									{
										Debugger.Break();
									}
									continue;
								}
								if (Information.IsNothing((object)theAircraftHostsList))
								{
									theAircraftHostsList = new List<ActiveUnit>();
								}
								theAircraftHostsList.Clear();
								theAircraftHostsList.Add(theHost2);
								int int_10 = continousCoverageStation5.int_0;
								if (Information.IsNothing((object)theLoadoutsList))
								{
									theLoadoutsList = new List<int>();
								}
								theLoadoutsList.Clear();
								theLoadoutsList.Add(int_10);
								DateTime dateTime4 = continousCoverageStation5.StationEndTime.Value;
								bool bool_9 = true;
								Mission.Flight flight3 = null;
								while (true)
								{
									List<Aircraft> list7 = new List<Aircraft>();
									List<Mission.EmptyAircraftSlot> list8 = new List<Mission.EmptyAircraftSlot>();
									int num15 = 1;
									int int_7 = _FlightSize_4.value;
									for (int num16 = 1; num16 <= int_7; num16++)
									{
										Mission obj7 = mission_0;
										int aircraftDBID2 = continousCoverageStation5.AircraftDBID;
										int int_11 = continousCoverageStation5.int_0;
										Mission.Flight theFlight = null;
										Aircraft aircraft7 = obj7.CreateEmptySlotReferenceUnit(ref scenario_0, ref side_0, aircraftDBID2, int_11, ref theHost2, ref theFlight, theUnitIsEscort: false, num15);
										Mission.EmptyAircraftSlot item4 = new Mission.EmptyAircraftSlot(aircraft7, aircraft7.DBID, aircraft7.UnitClass, aircraft7.LoadoutDBID, aircraft7.LoadoutName, ref theHost2, theHost2.ObjectID, theHost2.Name, theIsEscort: false);
										list7.Add(aircraft7);
										list8.Add(item4);
										num15++;
									}
									List<Aircraft> list_6 = list7.ToList();
									flight3 = null;
									Mission.Flight NewFlight = new Mission.Flight();
									Mission.Flight flight4 = OriginalFlight;
									Mission theMission3 = null;
									int NumberOfAircraft_AirborneOrTakingOff_Escort_NonShooter = 0;
									int NumberOfAircraft_Ready = 0;
									flight4.Copy(ref scenario_0, ref OriginalFlight, ref NewFlight, UseMissionSettings: false, ref theMission3, ref NumberOfAircraft_AirborneOrTakingOff_Escort_NonShooter, ref NumberOfAircraft_Ready, AddEmptySlotsToMission: false, CopyErrors: false);
									NewFlight.Type = Mission._FlightType.Flightplan;
									mission_0.MasterFlightList.Clear();
									mission_0.MasterFlightList.Add(NewFlight);
									OriginalFlight.UsedByFlightCount = 0;
									if (list_6.Count > 0)
									{
										Mission._FlightSize _FlightSize_2 = 0;
										Mission._FlightSize _FlightSize_3 = 0;
										bool bool_7 = false;
										NumberOfAircraft_Ready = 0;
										NumberOfAircraft_AirborneOrTakingOff_Escort_NonShooter = 0;
										int NumberOfAircraft_Ready_Escorts_Shooter = 0;
										int NumberOfAircraft_Ready_Escorts_NonShooter = 0;
										List<Aircraft> list_5 = new List<Aircraft>();
										List<Aircraft> theAircraftList_AssignedToFlight = new List<Aircraft>();
										bool bool_5 = false;
										float float_ = 0f;
										float float_2 = 0f;
										List<Group> list_4 = null;
										List<Aircraft> theAircraftList_AssignedToFlight_OnGroundReady = null;
										List<Aircraft> EmptySlotsReferenceAircraftList_AssignedToFlight = null;
										List<Aircraft> EmptySlotsReferenceAircraftList_Ready = null;
										List<Aircraft> EmptySlotsReferenceAircraftList = new List<Aircraft>();
										bool bool_6 = false;
										if (smethod_22(ref scenario_0, ref side_0, ref mission_0, bool_1, ref theAircraftList, ref _FlightSize_4, ref _FlightSize_2, ref _FlightSize_3, ref bool_8, ref bool_7, ref int_9, ref int_8, ref NumberOfAircraft_Ready, ref NumberOfAircraft_AirborneOrTakingOff_Escort_NonShooter, ref NumberOfAircraft_Ready_Escorts_Shooter, ref NumberOfAircraft_Ready_Escorts_NonShooter, ref list_6, ref list_5, ref theAircraftList_AssignedToFlight, ref nullable_2, ref bool_5, ref theLoadoutsList, ref float_, ref float_2, bool_5: false, ref list_4, ref theAircraftList_AssignedToFlight_OnGroundReady, ref EmptySlotsReferenceAircraftList_AssignedToFlight, ref EmptySlotsReferenceAircraftList_Ready, ref theAircraftHostsList, ref EmptySlotsReferenceAircraftList, ref string_2, double_0, ref bool_6, bool_7: false, bool_2, bool_9, ref flight3, bool_3))
										{
											if (!Information.IsNothing((object)flight3))
											{
												if (!Information.IsNothing((object)flight3.FlightPlan) && flight3.FlightPlan.Count() != 0)
												{
													int num17 = mission_0.CCOverlapQty_To_Minutes(continousCoverage_Overlap);
													Waypoint[] flightPlan2 = flight3.FlightPlan;
													foreach (Waypoint waypoint6 in flightPlan2)
													{
														if (waypoint6.IsStationEndWaypoint())
														{
															value4 = waypoint6.Station_Time;
															break;
														}
													}
													DateTime dateTime5 = dateTime4;
													DateTime date2 = dateTime5.Date;
													TimeSpan value5 = TimeSpan.FromMinutes(Math.Floor((dateTime5.TimeOfDay.TotalMinutes + 2.5) / 5.0) * 5.0);
													dateTime4 = date2.Add(value5);
													DateTime dateTime6 = dateTime4.AddSeconds(value4);
													dateTime4 = dateTime4.AddMinutes(-num17);
													if (Information.IsNothing((object)mission_0.EmptySlotsList))
													{
														mission_0.EmptySlotsList = new List<Mission.EmptyAircraftSlot>();
													}
													foreach (Mission.EmptyAircraftSlot item5 in list8)
													{
														item5.set_MissionFlight(scenario_0, flight3);
														item5.MissionFlight_ObjectID = flight3.ObjectID;
														item5.set_CurrentHostUnit(scenario_0, theHost2);
														item5.CurrentHostUnit_ObjectID = theHost2.ObjectID;
														item5.CurrentHostUnit_Name = theHost2.Name;
														item5.MissionFlight_ObjectID = flight3.ObjectID;
														mission_0.EmptySlotsList.Add(item5);
													}
													Waypoint[] flightPlan3 = flight3.FlightPlan;
													foreach (Waypoint waypoint7 in flightPlan3)
													{
														if (!waypoint7.IsStationStartWaypoint())
														{
															if (waypoint7.IsStationEndWaypoint())
															{
																waypoint8 = waypoint7;
																break;
															}
														}
														else
														{
															waypoint9 = waypoint7;
														}
													}
													if (!Information.IsNothing((object)waypoint9))
													{
														if (!Information.IsNothing((object)waypoint8))
														{
															waypoint9.Time_Zulu = dateTime4;
															waypoint9.TimeFixed = Waypoint.FixedFree.Fixed;
															waypoint8.Time_Zulu = dateTime6;
															waypoint8.TimeFixed = Waypoint.FixedFree.Fixed;
															Scenario theScen4 = scenario_0;
															Mission theMission4 = mission_0;
															ActiveUnit theAU3 = flight3.get_ReferenceUnit(scenario_0);
															Mission.Flight theFlight4 = flight3;
															Mission.Flight theFlight;
															Waypoint[] theFlightplan3 = (theFlight = flight3).FlightPlan;
															float_2 = 0f;
															float_ = 0f;
															MissionPlanner.CalculateFuelQtyAndTimes_And_CheckIfEnoughFuelForFlightPlan(theScen4, theMission4, theAU3, theFlight4, ref theFlightplan3, ref float_2, ref float_, RangeCheck: false, RunValidation: true, RunFreeSpeedChecks: true, SetWaypointTimes: true, NewFlightPlan: false, EditLeadWaypoints: true, EditWingmanWaypoints: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, AircraftIsAirborne: false, BananaSplitRedSection: false, mission_0.TakeOffTime, mission_0.TimeOnTarget, IsMFP: true);
															theFlight.FlightPlan = theFlightplan3;
															while (true)
															{
																stationStartTime = flight3.FlightPlan[0].Time_Zulu;
																DateTime time = scenario_0.Time;
																if (((!stationStartTime.HasValue) ? ((bool?)null) : new bool?(DateTime.Compare(stationStartTime.GetValueOrDefault(), time) < 0)) != true)
																{
																	break;
																}
																TimeSpan value6 = TimeSpan.FromMinutes(Math.Floor(((scenario_0.Time - flight3.FlightPlan[0].Time_Zulu.Value).TotalMinutes + 2.5) / 5.0) * 5.0 + 5.0);
																dateTime4 = dateTime4.Add(value6);
																dateTime6 = dateTime6.Add(value6);
																theFlightplan3 = flight3.FlightPlan;
																foreach (Waypoint waypoint10 in theFlightplan3)
																{
																	if (waypoint10.IsStationStartWaypoint())
																	{
																		waypoint10.Time_Zulu = dateTime4;
																	}
																	else if (waypoint10.IsStationEndWaypoint())
																	{
																		waypoint10.Time_Zulu = dateTime6;
																		break;
																	}
																}
																Scenario theScen5 = scenario_0;
																Mission theMission5 = mission_0;
																ActiveUnit theAU4 = flight3.get_ReferenceUnit(scenario_0);
																Mission.Flight theFlight5 = flight3;
																Waypoint[] theFlightplan4 = (theFlight = flight3).FlightPlan;
																float_ = 0f;
																float_2 = 0f;
																MissionPlanner.CalculateFuelQtyAndTimes_And_CheckIfEnoughFuelForFlightPlan(theScen5, theMission5, theAU4, theFlight5, ref theFlightplan4, ref float_, ref float_2, RangeCheck: false, RunValidation: true, RunFreeSpeedChecks: true, SetWaypointTimes: true, NewFlightPlan: false, EditLeadWaypoints: true, EditWingmanWaypoints: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, AircraftIsAirborne: false, BananaSplitRedSection: false, mission_0.TakeOffTime, mission_0.TimeOnTarget, IsMFP: true);
																theFlight.FlightPlan = theFlightplan4;
															}
															if (DateTime.Compare(dateTime4, t2) <= 0)
															{
																dateTime4 = dateTime6;
																continue;
															}
															Mission.ContinousCoverageStation continousCoverageStation6 = new Mission.ContinousCoverageStation(flight3.ObjectID, flight3.ReferenceUnit_DBID, flight3.int_1, theHost2.ObjectID, dateTime4, dateTime6, continousCoverageStation5.FlightplanTemplateObjectID);
															if (!Information.IsNothing((object)continousCoverageStation6))
															{
																if (mission_0.MissionClass == Mission._MissionClass.Patrol)
																{
																	Patrol obj8 = (Patrol)mission_0;
																	obj8.ContinousCoverage_Stations.Remove(continousCoverageStation5);
																	obj8.ContinousCoverage_Stations.Add(continousCoverageStation6);
																}
																if (mission_0.MissionClass == Mission._MissionClass.Support)
																{
																	SupportMission obj9 = (SupportMission)mission_0;
																	obj9.ContinousCoverage_Stations.Remove(continousCoverageStation5);
																	obj9.ContinousCoverage_Stations.Add(continousCoverageStation6);
																}
															}
															break;
														}
														if (mission_0.MissionClass == Mission._MissionClass.Patrol)
														{
															((Patrol)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation5);
														}
														if (mission_0.MissionClass == Mission._MissionClass.Support)
														{
															((SupportMission)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation5);
														}
														break;
													}
													if (mission_0.MissionClass == Mission._MissionClass.Patrol)
													{
														((Patrol)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation5);
													}
													if (mission_0.MissionClass == Mission._MissionClass.Support)
													{
														((SupportMission)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation5);
													}
													break;
												}
												if (Debugger.IsAttached)
												{
													Debugger.Break();
												}
												if (mission_0.MissionClass == Mission._MissionClass.Patrol)
												{
													((Patrol)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation5);
												}
												if (mission_0.MissionClass == Mission._MissionClass.Support)
												{
													((SupportMission)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation5);
												}
												break;
											}
											if (Debugger.IsAttached)
											{
												Debugger.Break();
											}
											if (mission_0.MissionClass == Mission._MissionClass.Patrol)
											{
												((Patrol)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation5);
											}
											if (mission_0.MissionClass == Mission._MissionClass.Support)
											{
												((SupportMission)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation5);
											}
											break;
										}
										if (Debugger.IsAttached)
										{
											Debugger.Break();
										}
										if (mission_0.MissionClass == Mission._MissionClass.Patrol)
										{
											((Patrol)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation5);
										}
										if (mission_0.MissionClass == Mission._MissionClass.Support)
										{
											((SupportMission)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation5);
										}
										break;
									}
									if (Debugger.IsAttached)
									{
										Debugger.Break();
									}
									if (mission_0.MissionClass == Mission._MissionClass.Patrol)
									{
										((Patrol)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation5);
									}
									if (mission_0.MissionClass == Mission._MissionClass.Support)
									{
										((SupportMission)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation5);
									}
									break;
								}
							}
							else
							{
								if (mission_0.MissionClass == Mission._MissionClass.Patrol)
								{
									((Patrol)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation5);
								}
								if (mission_0.MissionClass == Mission._MissionClass.Support)
								{
									((SupportMission)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation5);
								}
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
							}
						}
						else
						{
							continousCoverage_Stations.Remove(continousCoverageStation5);
						}
					}
				}
				else
				{
					SendMessageBoxToUI("No valid flightplan templates exist For this mission. Create one or more flightplan templates And Try again.", side_0);
				}
				break;
			}
			case Mission._ContinousCoverageMethod.Dynamic:
			{
				Mission obj3 = mission_0;
				Scenario theScen = scenario_0;
				List<Aircraft> theAircraftList_AssignedToFlight = null;
				List<Aircraft> theAircraftList_AssignedToFlight_OnGroundReady = null;
				int NumberOfAircraft_AirborneOrTakingOff = 0;
				int NumberOfAircraft_AirborneOrTakingOff_Escort_Shooter = 0;
				int NumberOfAircraft_AirborneOrTakingOff_Escort_NonShooter = 0;
				int NumberOfAircraft_Ready = 0;
				int NumberOfAircraft_Ready_Escorts_Shooter = 0;
				int NumberOfAircraft_Ready_Escorts_NonShooter = 0;
				List<int> theShipSubDBIDs = null;
				List<ActiveUnit> theShipSubList = null;
				List<ActiveUnit> theShipSubList_DockedReady = null;
				List<ActiveUnit> TheGroundUnitList = null;
				List<Aircraft> EmptySlotsReferenceAircraftList = new List<Aircraft>();
				List<Aircraft> EmptySlotsReferenceAircraftList_Ready = new List<Aircraft>();
				List<Aircraft> EmptySlotsReferenceAircraftList_AssignedToFlight = new List<Aircraft>();
				int NumberOfEmptySlots_Ready = 0;
				int NumberOfEmptySlots_Ready_Escorts_Shooter = 0;
				int NumberOfEmptySlots_Ready_Escorts_NonShooter = 0;
				List<Mission.Flight> theFlightList_Ready = null;
				List<Mission.Flight> theFlightList_NotReady = null;
				List<Mission.Flight> theFlightList_HasEmptySlots = null;
				obj3.UnitsAssignedToMission_SeparatedByType(theScen, ref theLoadoutsList, ref theAircraftDBIDs, ref theAircraftList, ref theAircraftList_AvailableForFlightPlanGenerator, ref theAircraftList_AssignedToFlight, ref theAircraftList_AssignedToFlight_OnGroundReady, ref theAircraftHostsList, ref NumberOfAircraft_AirborneOrTakingOff, ref NumberOfAircraft_AirborneOrTakingOff_Escort_Shooter, ref NumberOfAircraft_AirborneOrTakingOff_Escort_NonShooter, ref NumberOfAircraft_Ready, ref NumberOfAircraft_Ready_Escorts_Shooter, ref NumberOfAircraft_Ready_Escorts_NonShooter, ref theShipSubDBIDs, ref theShipSubList, ref theShipSubList_DockedReady, null, ref TheGroundUnitList, ref EmptySlotsReferenceAircraftList, ref EmptySlotsReferenceAircraftList_Ready, ref EmptySlotsReferenceAircraftList_AssignedToFlight, ref NumberOfEmptySlots_Ready, ref NumberOfEmptySlots_Ready_Escorts_Shooter, ref NumberOfEmptySlots_Ready_Escorts_NonShooter, ref theFlightList_Ready, ref theFlightList_NotReady, ref theFlightList_HasEmptySlots, OrderTakeOff: false, IncludeEmptySlots: false, IsContinousCoverage: true);
				List<Aircraft> list_ = new List<Aircraft>();
				Mission._FlightSize _FlightSize_ = mission_0.FlightSize;
				bool bool_4 = mission_0.UseFlightSizeHardLimit;
				int int_ = 0;
				smethod_16(bool_1: true, mission_0, ref list_, oneThirdRule, minimumNumberOnStation, ref theAircraftHostsList, ref theAircraftDBIDs, ref theAircraftList, ref theLoadoutsList, ref theAircraftList_AvailableForFlightPlanGenerator, ref _FlightSize_, ref bool_4);
				if (list_.Count <= 0)
				{
					break;
				}
				List<Mission.Flight> list = new List<Mission.Flight>();
				foreach (Mission.Flight flight7 in mission_0.FlightList)
				{
					if (flight7.Task != Mission._FlightTask.QRA && flight7.Type != Mission._FlightType.FlightplanTemplate)
					{
						list.Add(flight7);
					}
				}
				List<Mission.ContinousCoverageStation> list2 = null;
				if (list.Count == 0 && !Information.IsNothing((object)continousCoverage_Stations))
				{
					if (mission_0.MissionClass == Mission._MissionClass.Patrol)
					{
						((Patrol)mission_0).ContinousCoverage_Stations.Clear();
					}
					if (mission_0.MissionClass == Mission._MissionClass.Support)
					{
						((SupportMission)mission_0).ContinousCoverage_Stations.Clear();
					}
				}
				if (!Information.IsNothing((object)continousCoverage_Stations) && continousCoverage_Stations.Count > 0)
				{
					list2 = continousCoverage_Stations.ToList();
				}
				if (!Information.IsNothing((object)list2))
				{
					int count = list2.Count;
					int count2 = list.Count;
					for (int i = count - 1; i >= 0; i += -1)
					{
						Mission.ContinousCoverageStation continousCoverageStation = list2[i];
						bool flag = false;
						for (int j = count2 - 1; j >= 0; j += -1)
						{
							if (Operators.CompareString(list[j].ObjectID, continousCoverageStation.FlightObjectID, false) == 0)
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							if (mission_0.MissionClass == Mission._MissionClass.Patrol)
							{
								((Patrol)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation);
							}
							if (mission_0.MissionClass == Mission._MissionClass.Support)
							{
								((SupportMission)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation);
							}
						}
					}
				}
				if (!Information.IsNothing((object)continousCoverage_Stations) && continousCoverage_Stations.Count > 0)
				{
					list2 = continousCoverage_Stations.ToList();
				}
				if (!Information.IsNothing((object)list2))
				{
					for (int k = list2.Count - 1; k >= 0; k += -1)
					{
						Mission.ContinousCoverageStation continousCoverageStation = list2[k];
						if (Information.IsNothing((object)continousCoverageStation.HostUnitObjectID))
						{
							continousCoverage_Stations.Remove(continousCoverageStation);
							continue;
						}
						if (list_.Count == 0)
						{
							break;
						}
						int count3 = list_.Count;
						for (int l = count3 - 1; l >= 0; l += -1)
						{
							Aircraft aircraft = list_[l];
							int num = mission_0.FlightSize;
							if (continousCoverageStation.AircraftDBID == aircraft.DBID)
							{
								if (continousCoverageStation.int_0 == aircraft.LoadoutDBID)
								{
									string text = null;
									if (!Information.IsNothing((object)aircraft.AirOps.CurrentHostUnit))
									{
										text = aircraft.AirOps.CurrentHostUnit.ObjectID;
									}
									else if (!Information.IsNothing((object)aircraft.AirOps.get_AssignedHostUnit(PickNewAssignedHost: false)))
									{
										text = aircraft.AirOps.get_AssignedHostUnit(PickNewAssignedHost: false).ObjectID;
									}
									if (!Information.IsNothing((object)text) && Operators.CompareString(continousCoverageStation.HostUnitObjectID, text, false) == 0)
									{
										list_.Remove(aircraft);
										count3 = list_.Count;
										num--;
										if (num > 0)
										{
											_ = list_.Count;
											for (int m = count3 - 1; m >= 0; m += -1)
											{
												Aircraft aircraft2 = list_[m];
												if (continousCoverageStation.AircraftDBID != aircraft2.DBID || continousCoverageStation.int_0 != aircraft2.LoadoutDBID)
												{
													continue;
												}
												string text2 = null;
												if (!Information.IsNothing((object)aircraft2.AirOps.CurrentHostUnit))
												{
													text2 = aircraft2.AirOps.CurrentHostUnit.ObjectID;
												}
												else if (!Information.IsNothing((object)aircraft2.AirOps.get_AssignedHostUnit(PickNewAssignedHost: false)))
												{
													text2 = aircraft2.AirOps.get_AssignedHostUnit(PickNewAssignedHost: false).ObjectID;
												}
												if (!Information.IsNothing((object)text2))
												{
													if (Operators.CompareString(continousCoverageStation.HostUnitObjectID, text2, false) == 0)
													{
														list_.Remove(aircraft2);
														l--;
														num--;
														if (num == 0)
														{
															break;
														}
													}
													continue;
												}
												list_.Remove(aircraft);
												break;
											}
										}
										if (num == 0)
										{
											break;
										}
									}
								}
								else
								{
									list_.Remove(aircraft);
								}
							}
							if (list_.Count == 0)
							{
								break;
							}
						}
						list2.Remove(continousCoverageStation);
					}
				}
				if (!Information.IsNothing((object)list2) && list2.Count > 0 && !Information.IsNothing((object)list2))
				{
					int count2 = list2.Count;
					for (int n = count2 - 1; n >= 0; n += -1)
					{
						Mission.ContinousCoverageStation continousCoverageStation = list2[n];
						if (mission_0.MissionClass == Mission._MissionClass.Patrol)
						{
							((Patrol)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation);
						}
						if (mission_0.MissionClass == Mission._MissionClass.Support)
						{
							((SupportMission)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation);
						}
					}
				}
				string objectID = default(string);
				for (int num2 = list_.Count - 1; num2 >= 0; num2 += -1)
				{
					Aircraft aircraft3 = list_[num2];
					int num3 = mission_0.FlightSize;
					int dBID = aircraft3.DBID;
					int int32_ = aircraft3.LoadoutDBID;
					if (!Information.IsNothing((object)aircraft3.AirOps.CurrentHostUnit))
					{
						objectID = aircraft3.AirOps.CurrentHostUnit.ObjectID;
					}
					else if (!Information.IsNothing((object)aircraft3.AirOps.get_AssignedHostUnit(PickNewAssignedHost: false)))
					{
						objectID = aircraft3.AirOps.get_AssignedHostUnit(PickNewAssignedHost: false).ObjectID;
					}
					Mission.ContinousCoverageStation item = new Mission.ContinousCoverageStation("", dBID, int32_, objectID, scenario_0.Time, scenario_0.Time, "");
					if (mission_0.MissionClass == Mission._MissionClass.Patrol)
					{
						Patrol patrol = (Patrol)mission_0;
						if (Information.IsNothing((object)patrol.ContinousCoverage_Stations))
						{
							patrol.ContinousCoverage_Stations = new List<Mission.ContinousCoverageStation>();
						}
						patrol.ContinousCoverage_Stations.Add(item);
					}
					if (mission_0.MissionClass == Mission._MissionClass.Support)
					{
						SupportMission supportMission = (SupportMission)mission_0;
						if (Information.IsNothing((object)supportMission.ContinousCoverage_Stations))
						{
							supportMission.ContinousCoverage_Stations = new List<Mission.ContinousCoverageStation>();
						}
						supportMission.ContinousCoverage_Stations.Add(item);
					}
					num3--;
					if (num3 <= 0)
					{
						continue;
					}
					for (int num4 = list_.Count - 1; num4 >= 0; num4 += -1)
					{
						Aircraft aircraft4 = list_[num4];
						if (dBID != aircraft4.DBID || int32_ != aircraft4.LoadoutDBID)
						{
							continue;
						}
						string text3 = null;
						if (Information.IsNothing((object)aircraft4.AirOps.CurrentHostUnit))
						{
							if (!Information.IsNothing((object)aircraft4.AirOps.get_AssignedHostUnit(PickNewAssignedHost: false)))
							{
								text3 = aircraft4.AirOps.get_AssignedHostUnit(PickNewAssignedHost: false).ObjectID;
							}
						}
						else
						{
							text3 = aircraft4.AirOps.CurrentHostUnit.ObjectID;
						}
						if (!Information.IsNothing((object)text3) && Operators.CompareString(objectID, text3, false) == 0)
						{
							num3--;
							num2--;
							if (num3 == 0)
							{
								break;
							}
						}
					}
				}
				if (mission_0.MissionClass == Mission._MissionClass.Patrol)
				{
					continousCoverage_Stations = ((Patrol)mission_0).ContinousCoverage_Stations;
				}
				if (mission_0.MissionClass == Mission._MissionClass.Support)
				{
					continousCoverage_Stations = ((SupportMission)mission_0).ContinousCoverage_Stations;
				}
				DateTime t = scenario_0.Time.AddHours(mission_0.CCDurationQty_To_Hours(continousCoverage_Duration));
				Waypoint waypoint2 = default(Waypoint);
				Waypoint waypoint3 = default(Waypoint);
				for (int num5 = continousCoverage_Stations.Count - 1; num5 >= 0; num5 += -1)
				{
					Mission.ContinousCoverageStation continousCoverageStation2 = continousCoverage_Stations[num5];
					if (!Information.IsNothing((object)continousCoverageStation2.HostUnitObjectID))
					{
						DateTime? stationStartTime = continousCoverageStation2.StationStartTime;
						if ((stationStartTime.HasValue ? new bool?(DateTime.Compare(stationStartTime.GetValueOrDefault(), t) < 0) : ((bool?)null)) != true)
						{
							continue;
						}
						int int_2 = 0;
						Doctrine._UseUnderwayRefuelAndReplenishment? nullable_ = mission_0.Doctrine.get_UseReplenishment(scenario_0, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
						string string_ = "";
						int int_3 = 0;
						int int_4 = 0;
						if (scenario_0.ActiveUnits.ContainsKey(continousCoverageStation2.HostUnitObjectID))
						{
							ActiveUnit theHost = scenario_0.ActiveUnits[continousCoverageStation2.HostUnitObjectID];
							if (Information.IsNothing((object)theHost))
							{
								if (mission_0.MissionClass == Mission._MissionClass.Patrol)
								{
									((Patrol)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation2);
								}
								if (mission_0.MissionClass == Mission._MissionClass.Support)
								{
									((SupportMission)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation2);
								}
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								continue;
							}
							DateTime value = continousCoverageStation2.StationEndTime.Value;
							int num6 = mission_0.CCStationTimeQty_To_Minutes(continousCoverage_StationTime);
							int num7 = mission_0.CCOverlapQty_To_Minutes(continousCoverage_Overlap);
							DateTime dateTime = value;
							bool flag2 = true;
							Mission.Flight flight = null;
							while (true)
							{
								List<Aircraft> list_2 = new List<Aircraft>();
								List<Mission.EmptyAircraftSlot> list3 = new List<Mission.EmptyAircraftSlot>();
								int num8 = 1;
								NumberOfEmptySlots_Ready_Escorts_NonShooter = _FlightSize_.value;
								for (int num9 = 1; num9 <= NumberOfEmptySlots_Ready_Escorts_NonShooter; num9++)
								{
									Mission obj4 = mission_0;
									int aircraftDBID = continousCoverageStation2.AircraftDBID;
									int int_5 = continousCoverageStation2.int_0;
									Mission.Flight theFlight = null;
									Aircraft aircraft5 = obj4.CreateEmptySlotReferenceUnit(ref scenario_0, ref side_0, aircraftDBID, int_5, ref theHost, ref theFlight, theUnitIsEscort: false, num8);
									Mission.EmptyAircraftSlot item2 = new Mission.EmptyAircraftSlot(aircraft5, aircraft5.DBID, aircraft5.UnitClass, aircraft5.LoadoutDBID, aircraft5.LoadoutName, ref theHost, theHost.ObjectID, theHost.Name, theIsEscort: false);
									list_2.Add(aircraft5);
									list3.Add(item2);
									num8++;
								}
								List<Aircraft> list_3 = list_2.ToList();
								DateTime dateTime2 = dateTime;
								DateTime date = dateTime2.Date;
								TimeSpan value2 = TimeSpan.FromMinutes(Math.Floor((dateTime2.TimeOfDay.TotalMinutes + 2.5) / 5.0) * 5.0);
								dateTime = date.Add(value2);
								DateTime dateTime3 = dateTime.AddMinutes(num6);
								dateTime = dateTime.AddMinutes(-num7);
								flight = null;
								Mission._FlightSize _FlightSize_2 = 0;
								Mission._FlightSize _FlightSize_3 = 0;
								bool bool_5 = false;
								NumberOfEmptySlots_Ready_Escorts_Shooter = 0;
								NumberOfEmptySlots_Ready = 0;
								NumberOfAircraft_Ready_Escorts_NonShooter = 0;
								NumberOfAircraft_Ready_Escorts_Shooter = 0;
								NumberOfAircraft_Ready = 0;
								NumberOfAircraft_AirborneOrTakingOff_Escort_NonShooter = 0;
								NumberOfAircraft_AirborneOrTakingOff_Escort_Shooter = 0;
								NumberOfAircraft_AirborneOrTakingOff = 0;
								int int_6 = 0;
								int int_7 = 0;
								EmptySlotsReferenceAircraftList_AssignedToFlight = list_2.ToList();
								EmptySlotsReferenceAircraftList_Ready = new List<Aircraft>();
								EmptySlotsReferenceAircraftList = new List<Aircraft>();
								bool bool_6 = false;
								float float_ = 0f;
								float float_2 = 0f;
								if (smethod_15(ref scenario_0, ref side_0, ref mission_0, bool_1, ref list_2, ref _FlightSize_, ref _FlightSize_2, ref _FlightSize_3, ref bool_4, ref bool_5, ref int_2, ref int_, ref NumberOfEmptySlots_Ready_Escorts_Shooter, ref NumberOfEmptySlots_Ready, ref NumberOfAircraft_Ready_Escorts_NonShooter, ref NumberOfAircraft_Ready_Escorts_Shooter, ref NumberOfAircraft_Ready, ref NumberOfAircraft_AirborneOrTakingOff_Escort_NonShooter, ref NumberOfAircraft_AirborneOrTakingOff_Escort_Shooter, ref NumberOfAircraft_AirborneOrTakingOff, ref int_6, ref int_7, ref EmptySlotsReferenceAircraftList_AssignedToFlight, ref list_3, ref EmptySlotsReferenceAircraftList_Ready, ref EmptySlotsReferenceAircraftList, ref nullable_, ref bool_6, ref theLoadoutsList, ref theAircraftDBIDs, ref float_, ref float_2, ref string_, ref int_3, ref int_4, bool_2, null, null, flag2, ref theAircraftHostsList, bool_3, 0))
								{
									if (list_3.Count <= 0)
									{
										break;
									}
									_FlightSize_3 = 0;
									_FlightSize_2 = 0;
									bool_6 = false;
									int_7 = 0;
									int_6 = 0;
									NumberOfAircraft_AirborneOrTakingOff = 0;
									NumberOfAircraft_AirborneOrTakingOff_Escort_Shooter = 0;
									EmptySlotsReferenceAircraftList = new List<Aircraft>();
									EmptySlotsReferenceAircraftList_Ready = new List<Aircraft>();
									bool_5 = false;
									float_2 = 0f;
									float_ = 0f;
									List<Group> list_4 = null;
									EmptySlotsReferenceAircraftList_AssignedToFlight = null;
									theAircraftList_AssignedToFlight_OnGroundReady = null;
									theAircraftList_AssignedToFlight = null;
									List<Aircraft> list_5 = new List<Aircraft>();
									bool bool_7 = false;
									if (smethod_22(ref scenario_0, ref side_0, ref mission_0, bool_1, ref theAircraftList, ref _FlightSize_, ref _FlightSize_3, ref _FlightSize_2, ref bool_4, ref bool_6, ref int_2, ref int_, ref int_7, ref int_6, ref NumberOfAircraft_AirborneOrTakingOff, ref NumberOfAircraft_AirborneOrTakingOff_Escort_Shooter, ref list_3, ref EmptySlotsReferenceAircraftList, ref EmptySlotsReferenceAircraftList_Ready, ref nullable_, ref bool_5, ref theLoadoutsList, ref float_2, ref float_, bool_5: false, ref list_4, ref EmptySlotsReferenceAircraftList_AssignedToFlight, ref theAircraftList_AssignedToFlight_OnGroundReady, ref theAircraftList_AssignedToFlight, ref theAircraftHostsList, ref list_5, ref string_, double_0, ref bool_7, bool_7: false, bool_2, flag2, ref flight, bool_3))
									{
										if (!Information.IsNothing((object)flight))
										{
											if (!Information.IsNothing((object)flight.FlightPlan) && flight.FlightPlan.Count() != 0)
											{
												if (Information.IsNothing((object)mission_0.EmptySlotsList))
												{
													mission_0.EmptySlotsList = new List<Mission.EmptyAircraftSlot>();
												}
												foreach (Mission.EmptyAircraftSlot item6 in list3)
												{
													item6.set_MissionFlight(scenario_0, flight);
													item6.MissionFlight_ObjectID = flight.ObjectID;
													item6.set_CurrentHostUnit(scenario_0, theHost);
													item6.CurrentHostUnit_ObjectID = theHost.ObjectID;
													item6.CurrentHostUnit_Name = theHost.Name;
													item6.MissionFlight_ObjectID = flight.ObjectID;
													mission_0.EmptySlotsList.Add(item6);
												}
												Waypoint[] flightPlan = flight.FlightPlan;
												foreach (Waypoint waypoint in flightPlan)
												{
													if (!waypoint.IsStationStartWaypoint())
													{
														if (waypoint.IsStationEndWaypoint())
														{
															waypoint2 = waypoint;
															break;
														}
													}
													else
													{
														waypoint3 = waypoint;
													}
												}
												if (!Information.IsNothing((object)waypoint3))
												{
													if (!Information.IsNothing((object)waypoint2))
													{
														waypoint3.Time_Zulu = dateTime;
														waypoint3.TimeFixed = Waypoint.FixedFree.Fixed;
														waypoint2.Time_Zulu = dateTime3;
														waypoint2.TimeFixed = Waypoint.FixedFree.Fixed;
														waypoint2.Station_Time = (long)Math.Round(Math.Max((waypoint2.Time_Zulu.Value - waypoint3.Time_Zulu.Value).TotalSeconds, 0.0));
														Scenario theScen2 = scenario_0;
														Mission theMission = mission_0;
														ActiveUnit theAU = flight.get_ReferenceUnit(scenario_0);
														Mission.Flight theFlight2 = flight;
														Mission.Flight theFlight;
														Waypoint[] theFlightplan = (theFlight = flight).FlightPlan;
														float_ = 0f;
														float_2 = 0f;
														MissionPlanner.CalculateFuelQtyAndTimes_And_CheckIfEnoughFuelForFlightPlan(theScen2, theMission, theAU, theFlight2, ref theFlightplan, ref float_, ref float_2, RangeCheck: false, RunValidation: true, RunFreeSpeedChecks: true, SetWaypointTimes: true, NewFlightPlan: false, EditLeadWaypoints: true, EditWingmanWaypoints: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, AircraftIsAirborne: false, BananaSplitRedSection: false, mission_0.TakeOffTime, mission_0.TimeOnTarget, IsMFP: true);
														theFlight.FlightPlan = theFlightplan;
														while (true)
														{
															stationStartTime = flight.FlightPlan[0].Time_Zulu;
															DateTime time = scenario_0.Time;
															if (((!stationStartTime.HasValue) ? ((bool?)null) : new bool?(DateTime.Compare(stationStartTime.GetValueOrDefault(), time) < 0)) != true)
															{
																break;
															}
															TimeSpan value3 = TimeSpan.FromMinutes(Math.Floor(((scenario_0.Time - flight.FlightPlan[0].Time_Zulu.Value).TotalMinutes + 2.5) / 5.0) * 5.0 + 5.0);
															dateTime = dateTime.Add(value3);
															dateTime3 = dateTime3.Add(value3);
															theFlightplan = flight.FlightPlan;
															foreach (Waypoint waypoint4 in theFlightplan)
															{
																if (waypoint4.IsStationStartWaypoint())
																{
																	waypoint4.Time_Zulu = dateTime;
																}
																else if (waypoint4.IsStationEndWaypoint())
																{
																	waypoint4.Time_Zulu = dateTime3;
																	break;
																}
															}
															Scenario theScen3 = scenario_0;
															Mission theMission2 = mission_0;
															ActiveUnit theAU2 = flight.get_ReferenceUnit(scenario_0);
															Mission.Flight theFlight3 = flight;
															Waypoint[] theFlightplan2 = (theFlight = flight).FlightPlan;
															float_2 = 0f;
															float_ = 0f;
															MissionPlanner.CalculateFuelQtyAndTimes_And_CheckIfEnoughFuelForFlightPlan(theScen3, theMission2, theAU2, theFlight3, ref theFlightplan2, ref float_2, ref float_, RangeCheck: false, RunValidation: true, RunFreeSpeedChecks: true, SetWaypointTimes: true, NewFlightPlan: false, EditLeadWaypoints: true, EditWingmanWaypoints: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, AircraftIsAirborne: false, BananaSplitRedSection: false, mission_0.TakeOffTime, mission_0.TimeOnTarget, IsMFP: true);
															theFlight.FlightPlan = theFlightplan2;
														}
														if (DateTime.Compare(dateTime, t) <= 0)
														{
															dateTime = dateTime3;
															continue;
														}
														Mission.ContinousCoverageStation continousCoverageStation3 = new Mission.ContinousCoverageStation(flight.ObjectID, flight.ReferenceUnit_DBID, flight.int_1, theHost.ObjectID, dateTime, dateTime3, continousCoverageStation2.FlightplanTemplateObjectID);
														if (!Information.IsNothing((object)continousCoverageStation3))
														{
															if (mission_0.MissionClass == Mission._MissionClass.Patrol)
															{
																Patrol obj5 = (Patrol)mission_0;
																obj5.ContinousCoverage_Stations.Remove(continousCoverageStation2);
																obj5.ContinousCoverage_Stations.Add(continousCoverageStation3);
															}
															if (mission_0.MissionClass == Mission._MissionClass.Support)
															{
																SupportMission obj6 = (SupportMission)mission_0;
																obj6.ContinousCoverage_Stations.Remove(continousCoverageStation2);
																obj6.ContinousCoverage_Stations.Add(continousCoverageStation3);
															}
														}
														break;
													}
													if (mission_0.MissionClass == Mission._MissionClass.Patrol)
													{
														((Patrol)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation2);
													}
													if (mission_0.MissionClass == Mission._MissionClass.Support)
													{
														((SupportMission)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation2);
													}
													break;
												}
												if (mission_0.MissionClass == Mission._MissionClass.Patrol)
												{
													((Patrol)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation2);
												}
												if (mission_0.MissionClass == Mission._MissionClass.Support)
												{
													((SupportMission)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation2);
												}
												break;
											}
											if (Debugger.IsAttached)
											{
												Debugger.Break();
											}
											if (mission_0.MissionClass == Mission._MissionClass.Patrol)
											{
												((Patrol)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation2);
											}
											if (mission_0.MissionClass == Mission._MissionClass.Support)
											{
												((SupportMission)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation2);
											}
											break;
										}
										if (Debugger.IsAttached)
										{
											Debugger.Break();
										}
										if (mission_0.MissionClass == Mission._MissionClass.Patrol)
										{
											((Patrol)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation2);
										}
										if (mission_0.MissionClass == Mission._MissionClass.Support)
										{
											((SupportMission)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation2);
										}
										break;
									}
									if (Debugger.IsAttached)
									{
										Debugger.Break();
									}
									if (mission_0.MissionClass == Mission._MissionClass.Patrol)
									{
										((Patrol)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation2);
									}
									if (mission_0.MissionClass == Mission._MissionClass.Support)
									{
										((SupportMission)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation2);
									}
									break;
								}
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								if (mission_0.MissionClass == Mission._MissionClass.Patrol)
								{
									((Patrol)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation2);
								}
								if (mission_0.MissionClass == Mission._MissionClass.Support)
								{
									((SupportMission)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation2);
								}
								break;
							}
						}
						else
						{
							if (mission_0.MissionClass == Mission._MissionClass.Patrol)
							{
								((Patrol)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation2);
							}
							if (mission_0.MissionClass == Mission._MissionClass.Support)
							{
								((SupportMission)mission_0).ContinousCoverage_Stations.Remove(continousCoverageStation2);
							}
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
						}
					}
					else
					{
						continousCoverage_Stations.Remove(continousCoverageStation2);
					}
				}
				break;
			}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 9158685885", "");
			WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void smethod_13(ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, bool bool_1, double double_0, bool bool_2, bool bool_3)
	{
		try
		{
			List<Aircraft> theAircraftList = new List<Aircraft>();
			List<Aircraft> theAircraftList_AvailableForFlightPlanGenerator = new List<Aircraft>();
			List<ActiveUnit> theAircraftHostsList = new List<ActiveUnit>();
			List<int> theLoadoutsList = new List<int>();
			List<int> theAircraftDBIDs = new List<int>();
			List<Mission.ContinousCoverageStation> continousCoverage_QRAs = default(List<Mission.ContinousCoverageStation>);
			Mission._ContinousCoverageMethod continousCoverage_QRAFlightGenerationMethod = default(Mission._ContinousCoverageMethod);
			if (mission_0.MissionClass == Mission._MissionClass.Patrol)
			{
				Patrol obj = (Patrol)mission_0;
				continousCoverage_QRAs = obj.ContinousCoverage_QRAs;
				continousCoverage_QRAFlightGenerationMethod = obj.ContinousCoverage_QRAFlightGenerationMethod;
			}
			if (mission_0.MissionClass == Mission._MissionClass.Support)
			{
				SupportMission obj2 = (SupportMission)mission_0;
				continousCoverage_QRAs = obj2.ContinousCoverage_QRAs;
				continousCoverage_QRAFlightGenerationMethod = obj2.ContinousCoverage_QRAFlightGenerationMethod;
			}
			switch (continousCoverage_QRAFlightGenerationMethod)
			{
			case Mission._ContinousCoverageMethod.FlightplanTemplates:
			{
				Mission._FlightSize _FlightSize_4 = mission_0.FlightSize;
				bool bool_8 = mission_0.UseFlightSizeHardLimit;
				int int_7 = 0;
				List<Mission.Flight> list4 = new List<Mission.Flight>();
				List<Mission.Flight> list5 = new List<Mission.Flight>();
				foreach (Mission.Flight flight5 in mission_0.FlightList)
				{
					if (flight5.Task == Mission._FlightTask.QRA)
					{
						if (flight5.Type == Mission._FlightType.FlightplanTemplate)
						{
							list4.Add(flight5);
						}
						else
						{
							list5.Add(flight5);
						}
					}
				}
				if (list4.Count > 0)
				{
					List<Mission.ContinousCoverageStation> list6 = null;
					if (list5.Count == 0 && !Information.IsNothing((object)continousCoverage_QRAs))
					{
						if (mission_0.MissionClass == Mission._MissionClass.Patrol)
						{
							((Patrol)mission_0).ContinousCoverage_QRAs.Clear();
						}
						if (mission_0.MissionClass == Mission._MissionClass.Support)
						{
							((SupportMission)mission_0).ContinousCoverage_QRAs.Clear();
						}
					}
					if (!Information.IsNothing((object)continousCoverage_QRAs) && continousCoverage_QRAs.Count > 0)
					{
						list6 = continousCoverage_QRAs.ToList();
					}
					Mission.ContinousCoverageStation continousCoverageStation = default(Mission.ContinousCoverageStation);
					int count5;
					if (!Information.IsNothing((object)list6))
					{
						int count4 = list6.Count;
						count5 = list5.Count;
						for (int m = count4 - 1; m >= 0; m += -1)
						{
							continousCoverageStation = list6[m];
							bool flag = false;
							for (int n = count5 - 1; n >= 0; n += -1)
							{
								Mission.Flight flight2 = list5[n];
								if (Operators.CompareString(flight2.ObjectID, continousCoverageStation.FlightObjectID, false) == 0)
								{
									flag = true;
									break;
								}
							}
							if (!flag)
							{
								if (mission_0.MissionClass == Mission._MissionClass.Patrol)
								{
									((Patrol)mission_0).ContinousCoverage_QRAs.Remove(continousCoverageStation);
								}
								if (mission_0.MissionClass == Mission._MissionClass.Support)
								{
									((SupportMission)mission_0).ContinousCoverage_QRAs.Remove(continousCoverageStation);
								}
							}
						}
					}
					if (!Information.IsNothing((object)continousCoverage_QRAs) && continousCoverage_QRAs.Count > 0)
					{
						list6 = continousCoverage_QRAs.ToList();
					}
					count5 = ((!Information.IsNothing((object)continousCoverage_QRAs)) ? continousCoverage_QRAs.Count : 0);
					for (int num7 = list4.Count - 1; num7 >= 0; num7 += -1)
					{
						Mission.Flight flight2 = list4[num7];
						bool flag2 = false;
						if (!Information.IsNothing((object)list6))
						{
							for (int num8 = count5 - 1; num8 >= 0; num8 += -1)
							{
								continousCoverageStation = list6[num8];
								if (Operators.CompareString(flight2.ObjectID, continousCoverageStation.FlightplanTemplateObjectID, false) == 0)
								{
									flag2 = true;
									break;
								}
							}
						}
						if (flag2)
						{
							continue;
						}
						if (!Information.IsNothing((object)flight2))
						{
							int int_8 = 0;
							Doctrine._UseUnderwayRefuelAndReplenishment? nullable_2 = mission_0.Doctrine.get_UseReplenishment(scenario_0, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
							string string_2 = "";
							if (!scenario_0.ActiveUnits.ContainsKey(flight2.TakeOffLocation_HostUnitObjectID))
							{
								if (mission_0.MissionClass == Mission._MissionClass.Patrol)
								{
									((Patrol)mission_0).ContinousCoverage_QRAs.Remove(continousCoverageStation);
								}
								if (mission_0.MissionClass == Mission._MissionClass.Support)
								{
									((SupportMission)mission_0).ContinousCoverage_QRAs.Remove(continousCoverageStation);
								}
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								continue;
							}
							ActiveUnit theHost2 = scenario_0.ActiveUnits[flight2.TakeOffLocation_HostUnitObjectID];
							if (!Information.IsNothing((object)theHost2))
							{
								if (Information.IsNothing((object)theAircraftHostsList))
								{
									theAircraftHostsList = new List<ActiveUnit>();
								}
								theAircraftHostsList.Clear();
								theAircraftHostsList.Add(theHost2);
								int int_9 = flight2.int_1;
								if (Information.IsNothing((object)theLoadoutsList))
								{
									theLoadoutsList = new List<int>();
								}
								theLoadoutsList.Clear();
								theLoadoutsList.Add(int_9);
								Mission.Flight flight3 = null;
								List<Aircraft> list7 = new List<Aircraft>();
								List<Mission.EmptyAircraftSlot> list8 = new List<Mission.EmptyAircraftSlot>();
								int num9 = 1;
								int NumberOfAircraft_AirborneOrTakingOff_Escort_Shooter = _FlightSize_4.value;
								for (int num10 = 1; num10 <= NumberOfAircraft_AirborneOrTakingOff_Escort_Shooter; num10++)
								{
									Mission obj5 = mission_0;
									int referenceUnit_DBID = flight2.ReferenceUnit_DBID;
									int int_10 = flight2.int_1;
									Mission.Flight theFlight = null;
									Aircraft aircraft2 = obj5.CreateEmptySlotReferenceUnit(ref scenario_0, ref side_0, referenceUnit_DBID, int_10, ref theHost2, ref theFlight, theUnitIsEscort: false, num9);
									Mission.EmptyAircraftSlot item2 = new Mission.EmptyAircraftSlot(aircraft2, aircraft2.DBID, aircraft2.UnitClass, aircraft2.LoadoutDBID, aircraft2.LoadoutName, ref theHost2, theHost2.ObjectID, theHost2.Name, theIsEscort: false);
									list7.Add(aircraft2);
									list8.Add(item2);
									num9++;
								}
								List<Aircraft> list_7 = list7.ToList();
								flight3 = null;
								Mission.Flight NewFlight = new Mission.Flight();
								Mission.Flight flight4 = flight2;
								Mission theMission = null;
								int NumberOfAircraft_AirborneOrTakingOff = 0;
								int int_5 = 0;
								flight4.Copy(ref scenario_0, ref flight2, ref NewFlight, UseMissionSettings: false, ref theMission, ref NumberOfAircraft_AirborneOrTakingOff, ref int_5, AddEmptySlotsToMission: false, CopyErrors: false);
								NewFlight.Type = Mission._FlightType.Flightplan;
								mission_0.MasterFlightList.Clear();
								mission_0.MasterFlightList.Add(NewFlight);
								flight2.UsedByFlightCount = 0;
								if (list_7.Count > 0)
								{
									Mission._FlightSize _FlightSize_2 = 0;
									Mission._FlightSize _FlightSize_3 = 0;
									bool bool_7 = false;
									int_5 = 0;
									NumberOfAircraft_AirborneOrTakingOff = 0;
									int int_6 = 0;
									int NumberOfAircraft_AirborneOrTakingOff_Escort_NonShooter = 0;
									List<Aircraft> list_6 = new List<Aircraft>();
									List<Aircraft> theAircraftList_AssignedToFlight = new List<Aircraft>();
									bool bool_5 = false;
									float float_ = 0f;
									float float_2 = 0f;
									List<Group> list_5 = null;
									List<Aircraft> theAircraftList_AssignedToFlight_OnGroundReady = null;
									List<Aircraft> EmptySlotsReferenceAircraftList_AssignedToFlight = null;
									List<Aircraft> EmptySlotsReferenceAircraftList_Ready = null;
									List<Aircraft> EmptySlotsReferenceAircraftList = new List<Aircraft>();
									bool bool_6 = false;
									if (!smethod_22(ref scenario_0, ref side_0, ref mission_0, bool_1, ref theAircraftList, ref _FlightSize_4, ref _FlightSize_2, ref _FlightSize_3, ref bool_8, ref bool_7, ref int_8, ref int_7, ref int_5, ref NumberOfAircraft_AirborneOrTakingOff, ref int_6, ref NumberOfAircraft_AirborneOrTakingOff_Escort_NonShooter, ref list_7, ref list_6, ref theAircraftList_AssignedToFlight, ref nullable_2, ref bool_5, ref theLoadoutsList, ref float_, ref float_2, bool_5: false, ref list_5, ref theAircraftList_AssignedToFlight_OnGroundReady, ref EmptySlotsReferenceAircraftList_AssignedToFlight, ref EmptySlotsReferenceAircraftList_Ready, ref theAircraftHostsList, ref EmptySlotsReferenceAircraftList, ref string_2, double_0, ref bool_6, bool_7: false, bool_2, bool_9: true, ref flight3, bool_3))
									{
										if (Debugger.IsAttached)
										{
											Debugger.Break();
										}
										if (mission_0.MissionClass == Mission._MissionClass.Patrol)
										{
											((Patrol)mission_0).ContinousCoverage_QRAs.Remove(continousCoverageStation);
										}
										if (mission_0.MissionClass == Mission._MissionClass.Support)
										{
											((SupportMission)mission_0).ContinousCoverage_QRAs.Remove(continousCoverageStation);
										}
									}
									else
									{
										if (Information.IsNothing((object)flight3))
										{
											continue;
										}
										flight3.Task = Mission._FlightTask.QRA;
										if (Information.IsNothing((object)mission_0.EmptySlotsList))
										{
											mission_0.EmptySlotsList = new List<Mission.EmptyAircraftSlot>();
										}
										foreach (Mission.EmptyAircraftSlot item4 in list8)
										{
											item4.set_MissionFlight(scenario_0, flight3);
											item4.MissionFlight_ObjectID = flight3.ObjectID;
											item4.set_CurrentHostUnit(scenario_0, theHost2);
											item4.CurrentHostUnit_ObjectID = theHost2.ObjectID;
											item4.CurrentHostUnit_Name = theHost2.Name;
											item4.MissionFlight_ObjectID = flight3.ObjectID;
											mission_0.EmptySlotsList.Add(item4);
										}
										Mission.ContinousCoverageStation item3 = new Mission.ContinousCoverageStation(flight3.ObjectID, flight2.ReferenceUnit_DBID, int_9, theHost2.ObjectID, scenario_0.Time, scenario_0.Time, flight2.ObjectID);
										if (mission_0.MissionClass == Mission._MissionClass.Patrol)
										{
											Patrol patrol = (Patrol)mission_0;
											if (Information.IsNothing((object)patrol.ContinousCoverage_QRAs))
											{
												patrol.ContinousCoverage_QRAs = new List<Mission.ContinousCoverageStation>();
											}
											patrol.ContinousCoverage_QRAs.Add(item3);
										}
										if (mission_0.MissionClass == Mission._MissionClass.Support)
										{
											SupportMission supportMission = (SupportMission)mission_0;
											if (Information.IsNothing((object)supportMission.ContinousCoverage_QRAs))
											{
												supportMission.ContinousCoverage_QRAs = new List<Mission.ContinousCoverageStation>();
											}
											supportMission.ContinousCoverage_QRAs.Add(item3);
										}
									}
								}
								else
								{
									if (Debugger.IsAttached)
									{
										Debugger.Break();
									}
									if (mission_0.MissionClass == Mission._MissionClass.Patrol)
									{
										((Patrol)mission_0).ContinousCoverage_QRAs.Remove(continousCoverageStation);
									}
									if (mission_0.MissionClass == Mission._MissionClass.Support)
									{
										((SupportMission)mission_0).ContinousCoverage_QRAs.Remove(continousCoverageStation);
									}
								}
							}
							else
							{
								if (mission_0.MissionClass == Mission._MissionClass.Patrol)
								{
									((Patrol)mission_0).ContinousCoverage_QRAs.Remove(continousCoverageStation);
								}
								if (mission_0.MissionClass == Mission._MissionClass.Support)
								{
									((SupportMission)mission_0).ContinousCoverage_QRAs.Remove(continousCoverageStation);
								}
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
							}
						}
						else if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
					}
				}
				else
				{
					if (bool_3)
					{
						SendMessageBoxToUI("No QRA (Quick Reaction Alert) flightplan templates exist For this mission. Create one or more QRA flightplan templates And Try again.", side_0);
					}
					scenario_0.AddMessage("No QRA (Quick Reaction Alert) flightplan templates exist For mission " + mission_0.Name + ". Create one or more QRA flightplan templates And Try again.", "No QRA templates for " + mission_0.Name, LoggedMessage.MessageType.AirOps, 0, null, side_0);
				}
				break;
			}
			case Mission._ContinousCoverageMethod.Dynamic:
			{
				Mission._FlightSize _FlightSize_ = mission_0.FlightSize;
				bool bool_4 = mission_0.UseFlightSizeHardLimit;
				int int_ = 0;
				int num = default(int);
				if (mission_0.MissionClass == Mission._MissionClass.Patrol)
				{
					num = Mission.FlightQty_To_ActualFlightQty(ref ((Patrol)mission_0).ContinousCoverage_QRANumberOfFlights);
				}
				if (mission_0.MissionClass == Mission._MissionClass.Support)
				{
					num = Mission.FlightQty_To_ActualFlightQty(ref ((SupportMission)mission_0).ContinousCoverage_QRANumberOfFlights);
				}
				List<Mission.Flight> list = new List<Mission.Flight>();
				foreach (Mission.Flight flight6 in mission_0.FlightList)
				{
					if (flight6.Task == Mission._FlightTask.QRA && flight6.Type != Mission._FlightType.FlightplanTemplate)
					{
						list.Add(flight6);
					}
				}
				if (list.Count == 0 && !Information.IsNothing((object)continousCoverage_QRAs))
				{
					if (mission_0.MissionClass == Mission._MissionClass.Patrol)
					{
						((Patrol)mission_0).ContinousCoverage_QRAs.Clear();
					}
					if (mission_0.MissionClass == Mission._MissionClass.Support)
					{
						((SupportMission)mission_0).ContinousCoverage_QRAs.Clear();
					}
				}
				Mission obj3 = mission_0;
				Scenario theScen = scenario_0;
				List<Aircraft> theAircraftList_AssignedToFlight = null;
				List<Aircraft> theAircraftList_AssignedToFlight_OnGroundReady = null;
				int NumberOfAircraft_AirborneOrTakingOff = 0;
				int NumberOfAircraft_AirborneOrTakingOff_Escort_Shooter = 0;
				int NumberOfAircraft_AirborneOrTakingOff_Escort_NonShooter = 0;
				int NumberOfAircraft_Ready = 0;
				int NumberOfAircraft_Ready_Escorts_Shooter = 0;
				int NumberOfAircraft_Ready_Escorts_NonShooter = 0;
				List<int> theShipSubDBIDs = null;
				List<ActiveUnit> theShipSubList = null;
				List<ActiveUnit> theShipSubList_DockedReady = null;
				List<ActiveUnit> TheGroundUnitList = null;
				List<Aircraft> EmptySlotsReferenceAircraftList = new List<Aircraft>();
				List<Aircraft> EmptySlotsReferenceAircraftList_Ready = new List<Aircraft>();
				List<Aircraft> EmptySlotsReferenceAircraftList_AssignedToFlight = new List<Aircraft>();
				int NumberOfEmptySlots_Ready = 0;
				int NumberOfEmptySlots_Ready_Escorts_Shooter = 0;
				int NumberOfEmptySlots_Ready_Escorts_NonShooter = 0;
				List<Mission.Flight> theFlightList_Ready = null;
				List<Mission.Flight> theFlightList_NotReady = null;
				List<Mission.Flight> theFlightList_HasEmptySlots = null;
				obj3.UnitsAssignedToMission_SeparatedByType(theScen, ref theLoadoutsList, ref theAircraftDBIDs, ref theAircraftList, ref theAircraftList_AvailableForFlightPlanGenerator, ref theAircraftList_AssignedToFlight, ref theAircraftList_AssignedToFlight_OnGroundReady, ref theAircraftHostsList, ref NumberOfAircraft_AirborneOrTakingOff, ref NumberOfAircraft_AirborneOrTakingOff_Escort_Shooter, ref NumberOfAircraft_AirborneOrTakingOff_Escort_NonShooter, ref NumberOfAircraft_Ready, ref NumberOfAircraft_Ready_Escorts_Shooter, ref NumberOfAircraft_Ready_Escorts_NonShooter, ref theShipSubDBIDs, ref theShipSubList, ref theShipSubList_DockedReady, null, ref TheGroundUnitList, ref EmptySlotsReferenceAircraftList, ref EmptySlotsReferenceAircraftList_Ready, ref EmptySlotsReferenceAircraftList_AssignedToFlight, ref NumberOfEmptySlots_Ready, ref NumberOfEmptySlots_Ready_Escorts_Shooter, ref NumberOfEmptySlots_Ready_Escorts_NonShooter, ref theFlightList_Ready, ref theFlightList_NotReady, ref theFlightList_HasEmptySlots, OrderTakeOff: false, IncludeEmptySlots: false, IsContinousCoverage: true);
				int count = theAircraftHostsList.Count;
				int count2 = theAircraftDBIDs.Count;
				int count3 = theLoadoutsList.Count;
				for (int i = count - 1; i >= 0; i += -1)
				{
					ActiveUnit theHost = theAircraftHostsList[i];
					for (int j = count2 - 1; j >= 0; j += -1)
					{
						int num2 = theAircraftDBIDs[j];
						for (int k = count3 - 1; k >= 0; k += -1)
						{
							int num3 = theLoadoutsList[k];
							List<Mission.Flight> list2 = new List<Mission.Flight>();
							foreach (Mission.Flight flight7 in mission_0.FlightList)
							{
								if (flight7.Type != Mission._FlightType.FlightplanTemplate && flight7.Task == Mission._FlightTask.QRA && Operators.CompareString(flight7.TakeOffLocation_HostUnitObjectID, theHost.ObjectID, false) == 0 && flight7.ReferenceUnit_DBID == num2 && flight7.int_1 == num3)
								{
									list2.Add(flight7);
								}
							}
							int num4 = list2.Count;
							if (num4 >= num)
							{
								continue;
							}
							int num5 = 0;
							while (true)
							{
								int int_2 = num5;
								Doctrine._UseUnderwayRefuelAndReplenishment? nullable_ = mission_0.Doctrine.get_UseReplenishment(scenario_0, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
								string string_ = "";
								int int_3 = 0;
								int int_4 = 0;
								List<ActiveUnit> list_ = new List<ActiveUnit>();
								list_.Add(theHost);
								List<int> list_2 = new List<int>();
								list_2.Add(num3);
								Mission.Flight flight = null;
								List<Aircraft> list_3 = new List<Aircraft>();
								List<Mission.EmptyAircraftSlot> list3 = new List<Mission.EmptyAircraftSlot>();
								int num6 = 1;
								NumberOfEmptySlots_Ready_Escorts_NonShooter = _FlightSize_.value;
								for (int l = 1; l <= NumberOfEmptySlots_Ready_Escorts_NonShooter; l++)
								{
									Mission obj4 = mission_0;
									Mission.Flight theFlight = null;
									Aircraft aircraft = obj4.CreateEmptySlotReferenceUnit(ref scenario_0, ref side_0, num2, num3, ref theHost, ref theFlight, theUnitIsEscort: false, num6);
									Mission.EmptyAircraftSlot item = new Mission.EmptyAircraftSlot(aircraft, aircraft.DBID, aircraft.UnitClass, aircraft.LoadoutDBID, aircraft.LoadoutName, ref theHost, theHost.ObjectID, theHost.Name, theIsEscort: false);
									list_3.Add(aircraft);
									list3.Add(item);
									num6++;
								}
								List<Aircraft> list_4 = list_3.ToList();
								flight = null;
								Mission._FlightSize _FlightSize_2 = 0;
								Mission._FlightSize _FlightSize_3 = 0;
								bool bool_5 = false;
								NumberOfEmptySlots_Ready_Escorts_Shooter = 0;
								NumberOfEmptySlots_Ready = 0;
								NumberOfAircraft_Ready_Escorts_NonShooter = 0;
								NumberOfAircraft_Ready_Escorts_Shooter = 0;
								NumberOfAircraft_Ready = 0;
								NumberOfAircraft_AirborneOrTakingOff_Escort_NonShooter = 0;
								NumberOfAircraft_AirborneOrTakingOff_Escort_Shooter = 0;
								NumberOfAircraft_AirborneOrTakingOff = 0;
								int int_5 = 0;
								int int_6 = 0;
								EmptySlotsReferenceAircraftList_AssignedToFlight = list_3.ToList();
								EmptySlotsReferenceAircraftList_Ready = new List<Aircraft>();
								EmptySlotsReferenceAircraftList = new List<Aircraft>();
								bool bool_6 = false;
								float float_ = 0f;
								float float_2 = 0f;
								if (smethod_15(ref scenario_0, ref side_0, ref mission_0, bool_1, ref list_3, ref _FlightSize_, ref _FlightSize_2, ref _FlightSize_3, ref bool_4, ref bool_5, ref int_2, ref int_, ref NumberOfEmptySlots_Ready_Escorts_Shooter, ref NumberOfEmptySlots_Ready, ref NumberOfAircraft_Ready_Escorts_NonShooter, ref NumberOfAircraft_Ready_Escorts_Shooter, ref NumberOfAircraft_Ready, ref NumberOfAircraft_AirborneOrTakingOff_Escort_NonShooter, ref NumberOfAircraft_AirborneOrTakingOff_Escort_Shooter, ref NumberOfAircraft_AirborneOrTakingOff, ref int_5, ref int_6, ref EmptySlotsReferenceAircraftList_AssignedToFlight, ref list_4, ref EmptySlotsReferenceAircraftList_Ready, ref EmptySlotsReferenceAircraftList, ref nullable_, ref bool_6, ref theLoadoutsList, ref theAircraftDBIDs, ref float_, ref float_2, ref string_, ref int_3, ref int_4, bool_2, null, null, bool_6: true, ref theAircraftHostsList, bool_3, 0))
								{
									if (list_4.Count > 0)
									{
										_FlightSize_3 = 0;
										_FlightSize_2 = 0;
										bool_6 = false;
										int_6 = 0;
										int_5 = 0;
										NumberOfAircraft_AirborneOrTakingOff = 0;
										NumberOfAircraft_AirborneOrTakingOff_Escort_Shooter = 0;
										EmptySlotsReferenceAircraftList = new List<Aircraft>();
										EmptySlotsReferenceAircraftList_Ready = new List<Aircraft>();
										bool_5 = false;
										float_2 = 0f;
										float_ = 0f;
										List<Group> list_5 = null;
										EmptySlotsReferenceAircraftList_AssignedToFlight = null;
										theAircraftList_AssignedToFlight_OnGroundReady = null;
										theAircraftList_AssignedToFlight = null;
										List<Aircraft> list_6 = new List<Aircraft>();
										bool bool_7 = false;
										if (smethod_22(ref scenario_0, ref side_0, ref mission_0, bool_1, ref theAircraftList, ref _FlightSize_, ref _FlightSize_3, ref _FlightSize_2, ref bool_4, ref bool_6, ref int_2, ref int_, ref int_6, ref int_5, ref NumberOfAircraft_AirborneOrTakingOff, ref NumberOfAircraft_AirborneOrTakingOff_Escort_Shooter, ref list_4, ref EmptySlotsReferenceAircraftList, ref EmptySlotsReferenceAircraftList_Ready, ref nullable_, ref bool_5, ref list_2, ref float_2, ref float_, bool_5: false, ref list_5, ref EmptySlotsReferenceAircraftList_AssignedToFlight, ref theAircraftList_AssignedToFlight_OnGroundReady, ref theAircraftList_AssignedToFlight, ref list_, ref list_6, ref string_, double_0, ref bool_7, bool_7: false, bool_2, bool_9: true, ref flight, bool_3))
										{
											if (Information.IsNothing((object)flight))
											{
												break;
											}
											flight.Task = Mission._FlightTask.QRA;
											if (Information.IsNothing((object)mission_0.EmptySlotsList))
											{
												mission_0.EmptySlotsList = new List<Mission.EmptyAircraftSlot>();
											}
											foreach (Mission.EmptyAircraftSlot item5 in list3)
											{
												item5.set_MissionFlight(scenario_0, flight);
												item5.MissionFlight_ObjectID = flight.ObjectID;
												item5.set_CurrentHostUnit(scenario_0, theHost);
												item5.CurrentHostUnit_ObjectID = theHost.ObjectID;
												item5.CurrentHostUnit_Name = theHost.Name;
												item5.MissionFlight_ObjectID = flight.ObjectID;
												mission_0.EmptySlotsList.Add(item5);
											}
											num4++;
											if (num4 >= num)
											{
												break;
											}
											num5 = 0;
											continue;
										}
										if (Debugger.IsAttached)
										{
											Debugger.Break();
										}
										break;
									}
									if (Debugger.IsAttached)
									{
										Debugger.Break();
									}
									break;
								}
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								break;
							}
						}
					}
				}
				break;
			}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 7533558282882", "");
			WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void smethod_14(ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, double double_0)
	{
		try
		{
			if (!mission_0.HasFlights())
			{
				return;
			}
			bool flag = false;
			if (mission_0.MissionClass == Mission._MissionClass.Patrol)
			{
				flag = ((Patrol)mission_0).ContinousCoverage_QRAEnable;
			}
			if (mission_0.MissionClass == Mission._MissionClass.Support)
			{
				flag = ((SupportMission)mission_0).ContinousCoverage_QRAEnable;
			}
			if (!flag)
			{
				return;
			}
			List<Mission.Flight> list = new List<Mission.Flight>();
			List<Mission.Flight> list2 = new List<Mission.Flight>();
			foreach (Mission.Flight flight3 in mission_0.FlightList)
			{
				if (flight3.Type == Mission._FlightType.FlightplanTemplate)
				{
					continue;
				}
				if (flight3.Task == Mission._FlightTask.QRA)
				{
					if (flight3.get_Status(scenario_0) == Mission._FlightStatus.None && !(flight3.ReadyAircraftQty < flight3.MinimumAircraftQty) && flight3.ReadyAircraftQty >= flight3.get_Item(mission_0, scenario_0).Count)
					{
						list.Add(flight3);
					}
				}
				else if (flight3.get_Item(mission_0, scenario_0).Count >= flight3.DesiredAircraftQty)
				{
					list2.Add(flight3);
				}
			}
			if (list.Count == 0)
			{
				return;
			}
			if (list2.Count == 0)
			{
				foreach (Mission.Flight item in list)
				{
					Mission.Flight theFlight = item;
					mission_0.ClearAllAircraft_ReplaceWithEmptySlots(ref scenario_0, ref side_0, ref theFlight);
				}
				return;
			}
			List<Group> list3 = new List<Group>();
			List<Aircraft> list4 = new List<Aircraft>();
			bool flag2 = false;
			List<ActiveUnit> list5 = Module_Mission.UnitsAssignedToMissionOrPackage(mission_0, scenario_0);
			int count = list5.Count;
			if (mission_0.MissionClass == Mission._MissionClass.Patrol && !flag2)
			{
				int num = count - 1;
				while (num >= 0)
				{
					ActiveUnit activeUnit = list5[num];
					int num3;
					if (activeUnit.Status != ActiveUnit._ActiveUnitStatus.EngagedOffensive)
					{
						if (activeUnit.Status != ActiveUnit._ActiveUnitStatus.EngagedDefensive)
						{
							int num2;
							if (activeUnit.WeaponState != ActiveUnit._ActiveUnitWeaponState.IsWinchester && activeUnit.WeaponState != ActiveUnit._ActiveUnitWeaponState.IsWinchester_EngagingToO && activeUnit.WeaponState != ActiveUnit._ActiveUnitWeaponState.IsShotgun)
							{
								if (activeUnit.WeaponState != ActiveUnit._ActiveUnitWeaponState.IsShotgun_EngagingToO)
								{
									num += -1;
									continue;
								}
								num2 = 1;
							}
							else
							{
								num2 = 1;
							}
							flag2 = (byte)num2 != 0;
							break;
						}
						num3 = 1;
					}
					else
					{
						num3 = 1;
					}
					flag2 = (byte)num3 != 0;
					break;
				}
			}
			if (!flag2)
			{
				for (int i = count - 1; i >= 0; i += -1)
				{
					ActiveUnit activeUnit = list5[i];
					if ((activeUnit.FuelState == ActiveUnit._ActiveUnitFuelState.IsBingo || activeUnit.FuelState == ActiveUnit._ActiveUnitFuelState.IsJoker) && activeUnit.IsRTB_Or_CalledOff)
					{
						flag2 = true;
						break;
					}
				}
			}
			if (flag2)
			{
				for (int j = list.Count - 1; j >= 0; j += -1)
				{
					Mission.Flight flight = list[j];
					ActiveUnit activeUnit2 = scenario_0.ActiveUnits[flight.TakeOffLocation_HostUnitObjectID];
					if (flight.get_IsActive((IList<ActiveUnit>)flight.get_Item(mission_0, scenario_0)))
					{
						continue;
					}
					List<ActiveUnit> list6 = new List<ActiveUnit>();
					foreach (ActiveUnit unit in side_0.Units)
					{
						if (!Information.IsNothing((object)unit.ActiveMissionOrPackage()) && !Information.IsNothing((object)unit.Navigator.get_Flight(HierarchySearch: true)) && flight == unit.Navigator.get_Flight(HierarchySearch: true) && unit.IsAircraft && !unit.IsOperating())
						{
							Aircraft aircraft = (Aircraft)unit;
							string ReasonForNot = null;
							if (aircraft.IsAvailableForOps(ref ReasonForNot) == 0 && aircraft.IsParkedAndReady())
							{
								list6.Add(unit);
								list4.Add((Aircraft)unit);
							}
						}
					}
					if (list6.Count == 0 || list6.Count <= 1)
					{
						continue;
					}
					if (list6.Count < flight.MinimumAircraftQty)
					{
						foreach (ActiveUnit item2 in list6)
						{
							list4.Remove((Aircraft)item2);
						}
						if (mission_0.TimeSincePlayerNotification == 1)
						{
							scenario_0.AddMessage("Flight " + flight.Callsign + " requires minimum " + flight.MinimumAircraftQty.value + " aircraft, however only " + Conversions.ToString(list6.Count) + " are ready For take-off! The flight will Not launch!", flight.Callsign + " not launching (not enough AC ready)", LoggedMessage.MessageType.AirOps, 0, null, side_0, new Geopoint_Struct(activeUnit2.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit2.get_Latitude((GlobalVariables.BooleanObject)null)));
						}
						continue;
					}
					Mission.Flight flight2 = list6[0].Navigator.get_Flight(HierarchySearch: true);
					Group obj = new Group(ref scenario_0, ref side_0, list6, UsingMissionPlanner: true, null, mission_0);
					list3.Add(obj);
					int num4 = 2;
					foreach (ActiveUnit value in obj.Units.Values)
					{
						if (value.IsGroupLead())
						{
							value.SetFlight(flight2, 1);
							obj.Name = "Flight " + flight2.Callsign;
						}
						else
						{
							value.SetFlight(flight2, num4);
							num4++;
						}
					}
				}
			}
			mission_0.OrderAircraftToTakeOff(ref scenario_0, list3, list4, null, null);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 424242777777", "");
			WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static bool smethod_15(ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, bool bool_1, ref List<Aircraft> list_2, ref Mission._FlightSize _FlightSize_0, ref Mission._FlightSize _FlightSize_1, ref Mission._FlightSize _FlightSize_2, ref bool bool_2, ref bool bool_3, ref int int_0, ref int int_1, ref int int_2, ref int int_3, ref int int_4, ref int int_5, ref int int_6, ref int int_7, ref int int_8, ref int int_9, ref int int_10, ref int int_11, ref List<Aircraft> list_3, ref List<Aircraft> list_4, ref List<Aircraft> list_5, ref List<Aircraft> list_6, ref Doctrine._UseUnderwayRefuelAndReplenishment? nullable_0, ref bool bool_4, ref List<int> list_7, ref List<int> list_8, ref float float_2, ref float float_3, ref string string_6, ref int int_12, ref int int_13, bool bool_5, DateTime? nullable_1, DateTime? nullable_2, bool bool_6, ref List<ActiveUnit> list_9, bool bool_7, int int_14)
	{
		bool result;
		try
		{
			List<Mission.Flight> list = new List<Mission.Flight>();
			foreach (Mission.Flight masterFlight in mission_0.MasterFlightList)
			{
				if (!Information.IsNothing((object)masterFlight))
				{
					masterFlight.ClearFlightPlan();
					masterFlight.UsedByFlightCount = 0;
					if (mission_0.MissionClass == Mission._MissionClass.Strike && Information.IsNothing((object)masterFlight.PrimaryTarget))
					{
						Waypoint[] theArray = masterFlight.FlightPlan_Pathfinder_Ingress_1;
						ArrayExtensions.Clear(ref theArray);
						masterFlight.FlightPlan_Pathfinder_Ingress_1 = theArray;
					}
					if (masterFlight.Age > 120)
					{
						masterFlight.Age = 0;
						Waypoint[] theArray = masterFlight.FlightPlan_Pathfinder_Ingress_1;
						ArrayExtensions.Clear(ref theArray);
						masterFlight.FlightPlan_Pathfinder_Ingress_1 = theArray;
						masterFlight.Pathfinder_Ingress_RequestBeingProcessed = false;
					}
					else if (masterFlight.Age > 10 && !masterFlight.Pathfinder_Ingress_RequestBeingProcessed)
					{
						masterFlight.Age = 0;
						Waypoint[] theArray = masterFlight.FlightPlan_Pathfinder_Ingress_1;
						ArrayExtensions.Clear(ref theArray);
						masterFlight.FlightPlan_Pathfinder_Ingress_1 = theArray;
					}
					else if (!bool_6)
					{
						masterFlight.Age++;
					}
					if (masterFlight.FlightPlan.Count() == 0 && masterFlight.FlightPlan_Pathfinder_Ingress_1.Count() == 0 && !masterFlight.Pathfinder_Ingress_RequestBeingProcessed && !masterFlight.PathfinderRequestBeingProcessed_OnThisPulse)
					{
						list.Add(masterFlight);
					}
					masterFlight.PathfinderRequestBeingProcessed_OnThisPulse = false;
				}
				else
				{
					list.Add(masterFlight);
				}
			}
			foreach (Mission.Flight item in list)
			{
				mission_0.MasterFlightList.Remove(item);
			}
			int num;
			Patrol patrol_;
			SupportMission supportMission_;
			switch (mission_0.MissionClass)
			{
			default:
				num = 1;
				break;
			case Mission._MissionClass.Strike:
			{
				Strike strike_ = (Strike)mission_0;
				bool_2 = mission_0.UseFlightSizeHardLimit;
				bool_3 = strike_.UseFlightSizeHardLimit_Escort;
				if (strike_.OneTimeOnly && strike_.OneTimeOnlyFlown)
				{
					if (mission_0.TimeSincePlayerNotification == 1 || bool_7)
					{
						scenario_0.AddMessage("***WARNING*** Mission " + mission_0.Name + " is only allowed to be executed once. This mission has been flown and will not take off again. Removing aircraft from mission.", mission_0.Name + " is one-time and now over", LoggedMessage.MessageType.SpecialMessage, 0, null, side_0);
					}
					if (bool_7)
					{
						SendMessageBoxToUI("***WARNING*** Mission " + mission_0.Name + " is only allowed to be executed once. This mission has been flown and will not take off again. Removing aircraft from mission.", side_0);
					}
					foreach (Aircraft item2 in list_2)
					{
						if (!item2.IsOperating() && !item2.AirOps.IsTakingOff)
						{
							Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
							item2.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: false, ref Result);
						}
					}
					result = false;
				}
				else if ((strike_.RTB_When_Target_Destroyed & (strike_.Type != Strike.StrikeType.Air_Intercept)) && strike_.TargetCount == 0)
				{
					if (mission_0.TimeSincePlayerNotification == 1 || bool_7)
					{
						scenario_0.AddMessage("Mission " + mission_0.Name + " is only allowed to attack targets In the target list, and the list is empty. As such the mission will not launch. Either add targets or uncheck Pre-Planned Targets Only", mission_0.Name + " not launching (no defined targets)", LoggedMessage.MessageType.AirOps, 0, null, side_0);
					}
					int num6;
					if (bool_7)
					{
						SendMessageBoxToUI("Mission " + mission_0.Name + " is only allowed to attack targets In the target list, and the list is empty. As such the mission will not launch. Either add targets or uncheck Pre-Planned Targets Only", side_0);
						num6 = 0;
					}
					else
					{
						num6 = 0;
					}
					result = (byte)num6 != 0;
				}
				else
				{
					_FlightSize_0 = mission_0.FlightSize;
					_FlightSize_1 = strike_.Escort_FlightSize_Shooter;
					_FlightSize_2 = strike_.Escort_FlightSize_NonShooter;
					int_3 = mission_0.FlightSize_To_ActualAircraftQty(ref _FlightSize_1, ref strike_.MaximumNumberOfAircraft_Escorts_Shooter);
					int_5 = mission_0.FlightSize_To_ActualAircraftQty(ref _FlightSize_2, ref strike_.MaximumNumberOfAircraft_Escorts_NonShooter);
					if (int_14 > 0)
					{
						Mission obj = mission_0;
						Mission._FlightSize theFlightSize = new Mission._FlightSize(int_14);
						int_0 = obj.FlightSize_To_ActualAircraftQty(ref theFlightSize, ref strike_.MinimumNumberOfAircraft);
					}
					else
					{
						int_0 = mission_0.FlightSize_To_ActualAircraftQty(ref _FlightSize_0, ref strike_.MinimumNumberOfAircraft);
					}
					int_2 = mission_0.FlightSize_To_ActualAircraftQty(ref _FlightSize_1, ref strike_.MinimumNumberOfAircraft_Escorts_Shooter);
					int_4 = mission_0.FlightSize_To_ActualAircraftQty(ref _FlightSize_2, ref strike_.MinimumNumberOfAircraft_Escorts_NonShooter);
					if (list_2.Count == list_3.Count)
					{
						if (int_0 == int.MaxValue)
						{
							int_0 = int_9;
						}
						if (int_2 == int.MaxValue)
						{
							int_2 = int_10;
						}
						if (int_4 == int.MaxValue)
						{
							int_4 = int_11;
						}
					}
					if (!smethod_31(ref scenario_0, ref side_0, ref mission_0, ref list_2, ref list_3, int_0, _FlightSize_0))
					{
						result = false;
					}
					else if (!Information.IsNothing((object)int_0) && list_3.Count < int_0)
					{
						if (mission_0.TimeSincePlayerNotification == 1 || bool_7)
						{
							scenario_0.AddMessage("Mission " + mission_0.Name + " requires a minimum of " + ((strike_.MinimumNumberOfAircraft == Mission._FlightQty.All) ? "All" : int_0.ToString()) + " aircraft, however only " + Conversions.ToString(list_3.Count) + " are available", "Not enough AC available", LoggedMessage.MessageType.AirOps, 0, null, side_0);
						}
						int num7;
						if (bool_7)
						{
							SendMessageBoxToUI("Mission " + mission_0.Name + " requires a minimum of " + ((strike_.MinimumNumberOfAircraft == Mission._FlightQty.All) ? "All" : int_0.ToString()) + " aircraft, however only " + Conversions.ToString(list_3.Count) + " are available", side_0);
							num7 = 0;
						}
						else
						{
							num7 = 0;
						}
						result = (byte)num7 != 0;
					}
					else
					{
						List<Aircraft> list2 = list_2.Where([SpecialName] (Aircraft theAC) => theAC.IsOperating() && ((ActiveUnit)theAC).IsRTB).ToList();
						_ = list2.Count;
						int num8 = 0;
						int num9 = 0;
						foreach (Aircraft item3 in list2)
						{
							if (item3.AI.IsEscort)
							{
								if (item3.Loadout.IsSupportOrPatrol)
								{
									num9++;
								}
								else
								{
									num8++;
								}
							}
						}
						if (list_2.Count - int_6 - list2.Count < int_0)
						{
							int num10;
							if (!bool_7)
							{
								num10 = 0;
							}
							else
							{
								SendMessageBoxToUI("Mission " + mission_0.Name + " requires a minimum of " + int_0 + " aircraft, however only " + (int_6 - list2.Count) + " are available", side_0);
								num10 = 0;
							}
							result = (byte)num10 != 0;
						}
						else if (int_10 - num8 < int_2)
						{
							int num11;
							if (!bool_7)
							{
								num11 = 0;
							}
							else
							{
								SendMessageBoxToUI("Mission " + mission_0.Name + " requires a minimum of " + int_2 + " escorting aircraft, however only " + (int_7 - num8) + " are available", side_0);
								num11 = 0;
							}
							result = (byte)num11 != 0;
						}
						else
						{
							if (_FlightSize_2 == 0 || int_11 - num9 >= int_5)
							{
								switch (strike_.Type)
								{
								case Strike.StrikeType.Air_Intercept:
									smethod_17(ref scenario_0, ref side_0, ref mission_0, ref strike_, bool_1, ref _FlightSize_0, ref _FlightSize_1, ref _FlightSize_2, ref list_4, ref list_5, ref list_6, ref list_3, ref string_6, ref int_12, ref int_13, ref nullable_0, bool_5, nullable_1, nullable_2, bool_6, bool_7);
									break;
								case Strike.StrikeType.Land_Strike:
								case Strike.StrikeType.Maritime_Strike:
								case Strike.StrikeType.Sub_Strike:
								{
									Contact contact_ = default(Contact);
									smethod_18(ref scenario_0, ref side_0, ref mission_0, ref strike_, bool_1, ref _FlightSize_0, ref _FlightSize_1, ref _FlightSize_2, ref list_4, ref list_5, ref list_6, ref list_3, contact_, ref string_6, ref int_12, ref float_2, ref float_3, ref int_13, ref nullable_0, ref bool_4, bool_5, nullable_1, nullable_2, bool_6, bool_7);
									break;
								}
								}
								if (mission_0.MasterFlightList.Count > 0)
								{
									foreach (Mission.Flight masterFlight2 in mission_0.MasterFlightList)
									{
										ActiveUnit activeUnit2 = scenario_0.ActiveUnits[masterFlight2.TakeOffLocation_HostUnitObjectID];
										if (masterFlight2.FlightCannotLaunch && !Information.IsNothing((object)masterFlight2.get_ReferenceUnit(scenario_0)) && !string.IsNullOrEmpty(masterFlight2.FlightCannotLaunch_Feedback))
										{
											if (mission_0.TimeSincePlayerNotification == 1 || bool_7)
											{
												scenario_0.AddMessage("Mission " + strike_.Name + ", aircraft type " + masterFlight2.get_ReferenceUnit(scenario_0).UnitClass + " With loadout " + ((Aircraft)masterFlight2.get_ReferenceUnit(scenario_0)).LoadoutName + " based On " + masterFlight2.TakeOffLocation_HostUnitObjectName + " cannot launch! Reason: " + masterFlight2.FlightCannotLaunch_Feedback, strike_.Name + " cannot launch", LoggedMessage.MessageType.AirOps, 0, null, side_0, new Geopoint_Struct(activeUnit2.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit2.get_Latitude((GlobalVariables.BooleanObject)null)));
											}
											if (bool_7)
											{
												SendMessageBoxToUI("Mission " + strike_.Name + ", aircraft type " + masterFlight2.get_ReferenceUnit(scenario_0).UnitClass + " with loadout " + ((Aircraft)masterFlight2.get_ReferenceUnit(scenario_0)).LoadoutName + " based on " + masterFlight2.TakeOffLocation_HostUnitObjectName + " cannot launch! Reason: " + masterFlight2.FlightCannotLaunch_Feedback, side_0);
											}
										}
									}
								}
								goto IL_14c9;
							}
							int num12;
							if (bool_7)
							{
								SendMessageBoxToUI("Mission " + mission_0.Name + " requires a minimum of " + int_5 + " non shooter escorting aircraft, however only " + (int_8 - num9) + " are available", side_0);
								num12 = 0;
							}
							else
							{
								num12 = 0;
							}
							result = (byte)num12 != 0;
						}
					}
				}
				goto end_IL_0001;
			}
			case Mission._MissionClass.Patrol:
				patrol_ = (Patrol)mission_0;
				_FlightSize_0 = mission_0.FlightSize;
				bool_2 = mission_0.UseFlightSizeHardLimit;
				if (bool_6)
				{
					goto IL_0c2a;
				}
				int_0 = patrol_.FlightSize_To_ActualAircraftQty(ref _FlightSize_0, ref patrol_.MinimumNumberOfAircraft);
				if (list_2.Count == list_3.Count && int_0 == int.MaxValue)
				{
					int_0 = int_9;
				}
				if (smethod_31(ref scenario_0, ref side_0, ref mission_0, ref list_2, ref list_3, int_0, _FlightSize_0))
				{
					if (Information.IsNothing((object)int_0) || list_2.Count >= int_0)
					{
						int minimumNumberOnStation2 = ((Patrol)mission_0).MinimumNumberOnStation;
						bool oneThirdRule3 = ((Patrol)mission_0).OneThirdRule;
						smethod_16(bool_1: false, mission_0, ref list_4, oneThirdRule3, minimumNumberOnStation2, ref list_9, ref list_8, ref list_2, ref list_7, ref list_3, ref _FlightSize_0, ref bool_2);
						goto IL_0c2a;
					}
					if (mission_0.TimeSincePlayerNotification == 1 || bool_7)
					{
						scenario_0.AddMessage("Mission " + mission_0.Name + " requires a minimum of " + Conversions.ToString(int_0) + " aircraft, however only " + Conversions.ToString(list_2.Count) + "are available", mission_0.Name + " does not have enough AC", LoggedMessage.MessageType.AirOps, 0, null, side_0);
					}
					int num4;
					if (bool_7)
					{
						SendMessageBoxToUI("Mission " + mission_0.Name + " requires a minimum of " + Conversions.ToString(int_0) + " aircraft, however only " + Conversions.ToString(list_2.Count) + "are available", side_0);
						num4 = 0;
					}
					else
					{
						num4 = 0;
					}
					result = (byte)num4 != 0;
				}
				else
				{
					result = false;
				}
				goto end_IL_0001;
			case Mission._MissionClass.Support:
				supportMission_ = (SupportMission)mission_0;
				_FlightSize_0 = mission_0.FlightSize;
				bool_2 = mission_0.UseFlightSizeHardLimit;
				if (bool_6)
				{
					goto IL_10ed;
				}
				int_0 = supportMission_.FlightSize_To_ActualAircraftQty(ref _FlightSize_0, ref supportMission_.MinimumNumberOfAircraft);
				if (list_2.Count == list_3.Count && int_0 == int.MaxValue)
				{
					int_0 = int_9;
				}
				if (!smethod_31(ref scenario_0, ref side_0, ref mission_0, ref list_2, ref list_3, int_0, _FlightSize_0))
				{
					result = false;
				}
				else
				{
					if (Information.IsNothing((object)int_0) || list_2.Count >= int_0)
					{
						int minimumNumberOnStation = ((SupportMission)mission_0).MinimumNumberOnStation;
						bool oneThirdRule2 = ((SupportMission)mission_0).OneThirdRule;
						smethod_16(bool_1: false, mission_0, ref list_4, oneThirdRule2, minimumNumberOnStation, ref list_9, ref list_8, ref list_2, ref list_7, ref list_3, ref _FlightSize_0, ref bool_2);
						goto IL_10ed;
					}
					if (mission_0.TimeSincePlayerNotification == 1 || bool_7)
					{
						scenario_0.AddMessage("Mission " + mission_0.Name + " requires a minimum of " + Conversions.ToString(int_0) + " aircraft, however only " + Conversions.ToString(list_2.Count) + "are available", mission_0.Name + " does not have enough AC", LoggedMessage.MessageType.AirOps, 0, null, side_0);
					}
					int num3;
					if (!bool_7)
					{
						num3 = 0;
					}
					else
					{
						SendMessageBoxToUI("Mission " + mission_0.Name + " requires a minimum of " + Conversions.ToString(int_0) + " aircraft, however only " + Conversions.ToString(list_2.Count) + "are available", side_0);
						num3 = 0;
					}
					result = (byte)num3 != 0;
				}
				goto end_IL_0001;
			case Mission._MissionClass.Ferry:
			{
				FerryMission ferryMission = (FerryMission)mission_0;
				_FlightSize_0 = mission_0.FlightSize;
				bool_2 = mission_0.UseFlightSizeHardLimit;
				int_0 = ferryMission.FlightSize_To_ActualAircraftQty(ref _FlightSize_0, ref ferryMission.MinimumNumberOfAircraft);
				if (list_2.Count == list_3.Count && int_0 == int.MaxValue)
				{
					int_0 = int_9;
				}
				if (smethod_31(ref scenario_0, ref side_0, ref mission_0, ref list_2, ref list_3, int_0, _FlightSize_0))
				{
					foreach (Aircraft item4 in list_3)
					{
						list_4.Add(item4);
					}
					goto IL_14c9;
				}
				if (mission_0.TimeSincePlayerNotification == 1 || bool_7)
				{
					scenario_0.AddMessage("Mission " + mission_0.Name + " requires a minimum of " + Conversions.ToString(int_0) + " aircraft, however only " + Conversions.ToString(list_2.Count) + "are available", mission_0.Name + " does not have enough AC", LoggedMessage.MessageType.AirOps, 0, null, side_0);
				}
				int num13;
				if (bool_7)
				{
					SendMessageBoxToUI("Mission " + mission_0.Name + " requires a minimum of " + Conversions.ToString(int_0) + " aircraft, however only " + Conversions.ToString(list_2.Count) + "are available", side_0);
					num13 = 0;
				}
				else
				{
					num13 = 0;
				}
				result = (byte)num13 != 0;
				goto end_IL_0001;
			}
			case Mission._MissionClass.Mining:
			{
				MiningMission miningMission = (MiningMission)mission_0;
				_FlightSize_0 = mission_0.FlightSize;
				bool_2 = mission_0.UseFlightSizeHardLimit;
				int_0 = mission_0.FlightSize_To_ActualAircraftQty(ref _FlightSize_0, ref miningMission.MinimumNumberOfAircraft);
				if (list_2.Count == list_3.Count && int_0 == int.MaxValue)
				{
					int_0 = int_9;
				}
				if (smethod_31(ref scenario_0, ref side_0, ref mission_0, ref list_2, ref list_3, int_0, _FlightSize_0))
				{
					if (Information.IsNothing((object)int_0) || list_2.Count >= int_0)
					{
						bool oneThirdRule4 = ((MiningMission)mission_0).OneThirdRule;
						smethod_16(bool_1: false, mission_0, ref list_4, oneThirdRule4, 0, ref list_9, ref list_8, ref list_2, ref list_7, ref list_3, ref _FlightSize_0, ref bool_2);
						num = 1;
						break;
					}
					if (mission_0.TimeSincePlayerNotification == 1 || bool_7)
					{
						scenario_0.AddMessage("Mission " + mission_0.Name + " requires a minimum of " + Conversions.ToString(int_0) + " aircraft, however only " + Conversions.ToString(list_2.Count) + "are available", mission_0.Name + " does not have enough AC", LoggedMessage.MessageType.AirOps, 0, null, side_0);
					}
					int num5;
					if (!bool_7)
					{
						num5 = 0;
					}
					else
					{
						SendMessageBoxToUI("Mission " + mission_0.Name + " requires a minimum of " + Conversions.ToString(int_0) + " aircraft, however only " + Conversions.ToString(list_2.Count) + "are available", side_0);
						num5 = 0;
					}
					result = (byte)num5 != 0;
				}
				else
				{
					result = false;
				}
				goto end_IL_0001;
			}
			case Mission._MissionClass.MineClearing:
			{
				MineClearingMission mineClearingMission = (MineClearingMission)mission_0;
				_FlightSize_0 = mission_0.FlightSize;
				bool_2 = mission_0.UseFlightSizeHardLimit;
				int_0 = mineClearingMission.FlightSize_To_ActualAircraftQty(ref _FlightSize_0, ref mineClearingMission.MinimumNumberOfAircraft);
				if (list_2.Count == list_3.Count && int_0 == int.MaxValue)
				{
					int_0 = int_9;
				}
				if (!smethod_31(ref scenario_0, ref side_0, ref mission_0, ref list_2, ref list_3, int_0, _FlightSize_0))
				{
					result = false;
				}
				else
				{
					if (Information.IsNothing((object)int_0) || list_2.Count >= int_0)
					{
						bool oneThirdRule = ((MineClearingMission)mission_0).OneThirdRule;
						smethod_16(bool_1: false, mission_0, ref list_4, oneThirdRule, 0, ref list_9, ref list_8, ref list_2, ref list_7, ref list_3, ref _FlightSize_0, ref bool_2);
						num = 1;
						break;
					}
					if (mission_0.TimeSincePlayerNotification == 1 || bool_7)
					{
						scenario_0.AddMessage("Mission " + mission_0.Name + " requires a minimum of " + Conversions.ToString(int_0) + " aircraft, however only " + Conversions.ToString(list_2.Count) + "are available", mission_0.Name + " does not have enough AC", LoggedMessage.MessageType.AirOps, 0, null, side_0);
					}
					int num2;
					if (!bool_7)
					{
						num2 = 0;
					}
					else
					{
						SendMessageBoxToUI("Mission " + mission_0.Name + " requires a minimum of " + Conversions.ToString(int_0) + " aircraft, however only " + Conversions.ToString(list_2.Count) + "are available", side_0);
						num2 = 0;
					}
					result = (byte)num2 != 0;
				}
				goto end_IL_0001;
			}
			case Mission._MissionClass.Escort:
				{
					_FlightSize_0 = mission_0.FlightSize;
					bool_2 = mission_0.UseFlightSizeHardLimit;
					num = 1;
					break;
				}
				IL_10ed:
				if (supportMission_.UseFlightplans)
				{
					list_3.Clear();
					list_3 = list_4.ToList();
					list_4.Clear();
					smethod_21(ref scenario_0, ref side_0, ref mission_0, ref supportMission_, bool_1, ref _FlightSize_0, ref list_4, ref list_3, ref string_6, ref nullable_0, bool_5, nullable_1, nullable_2, bool_6, bool_7);
				}
				if (mission_0.MasterFlightList.Count > 0)
				{
					foreach (Mission.Flight masterFlight3 in mission_0.MasterFlightList)
					{
						ActiveUnit activeUnit = scenario_0.ActiveUnits[masterFlight3.TakeOffLocation_HostUnitObjectID];
						if (masterFlight3.FlightCannotLaunch && !Information.IsNothing((object)masterFlight3.get_ReferenceUnit(scenario_0)) && !string.IsNullOrEmpty(masterFlight3.FlightCannotLaunch_Feedback))
						{
							if (mission_0.TimeSincePlayerNotification == 1 || bool_7)
							{
								scenario_0.AddMessage("Mission " + supportMission_.Name + ", aircraft type " + masterFlight3.get_ReferenceUnit(scenario_0).UnitClass + " with loadout " + ((Aircraft)masterFlight3.get_ReferenceUnit(scenario_0)).LoadoutName + " based on " + masterFlight3.TakeOffLocation_HostUnitObjectName + " cannot launch! Reason: " + masterFlight3.FlightCannotLaunch_Feedback, supportMission_.Name + " cannot launch", LoggedMessage.MessageType.AirOps, 0, null, side_0, new Geopoint_Struct(activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
							}
							if (bool_7)
							{
								SendMessageBoxToUI("Mission " + supportMission_.Name + ", aircraft type " + masterFlight3.get_ReferenceUnit(scenario_0).UnitClass + " with loadout " + ((Aircraft)masterFlight3.get_ReferenceUnit(scenario_0)).LoadoutName + " based on " + masterFlight3.TakeOffLocation_HostUnitObjectName + " cannot launch! Reason: " + masterFlight3.FlightCannotLaunch_Feedback, side_0);
							}
						}
					}
				}
				goto IL_14c9;
				IL_14c9:
				num = 1;
				break;
				IL_0c2a:
				if (patrol_.UseFlightplans && patrol_.MovementStyle != Patrol.PatrolMovementStyle.ChainsawLoop)
				{
					switch (patrol_.Type)
					{
					case GlobalVariables.PatrolType.AAW:
						list_3.Clear();
						list_3 = list_4.ToList();
						list_4.Clear();
						smethod_20(ref scenario_0, ref side_0, ref mission_0, ref patrol_, bool_1, ref _FlightSize_0, ref list_4, ref list_3, ref string_6, ref nullable_0, bool_5, nullable_1, nullable_2, bool_6, bool_7);
						break;
					case GlobalVariables.PatrolType.SEAD:
						list_3.Clear();
						list_3 = list_4.ToList();
						list_4.Clear();
						smethod_20(ref scenario_0, ref side_0, ref mission_0, ref patrol_, bool_1, ref _FlightSize_0, ref list_4, ref list_3, ref string_6, ref nullable_0, bool_5, nullable_1, nullable_2, bool_6, bool_7);
						break;
					case GlobalVariables.PatrolType.ASW:
					case GlobalVariables.PatrolType.ASuW_Naval:
					case GlobalVariables.PatrolType.ASuW_Land:
					case GlobalVariables.PatrolType.ASuW_Mixed:
					case GlobalVariables.PatrolType.SeaControl:
						list_3.Clear();
						list_3 = list_4.ToList();
						list_4.Clear();
						smethod_20(ref scenario_0, ref side_0, ref mission_0, ref patrol_, bool_1, ref _FlightSize_0, ref list_4, ref list_3, ref string_6, ref nullable_0, bool_5, nullable_1, nullable_2, bool_6, bool_7);
						break;
					}
				}
				if (mission_0.MasterFlightList.Count > 0)
				{
					foreach (Mission.Flight masterFlight4 in mission_0.MasterFlightList)
					{
						ActiveUnit activeUnit3 = scenario_0.ActiveUnits[masterFlight4.TakeOffLocation_HostUnitObjectID];
						if (masterFlight4.FlightCannotLaunch && !Information.IsNothing((object)masterFlight4.get_ReferenceUnit(scenario_0)) && !string.IsNullOrEmpty(masterFlight4.FlightCannotLaunch_Feedback))
						{
							if (mission_0.TimeSincePlayerNotification == 1 || bool_7)
							{
								scenario_0.AddMessage("Mission " + patrol_.Name + ", aircraft type " + masterFlight4.get_ReferenceUnit(scenario_0).UnitClass + " with loadout " + ((Aircraft)masterFlight4.get_ReferenceUnit(scenario_0)).LoadoutName + " based on " + masterFlight4.TakeOffLocation_HostUnitObjectName + " cannot launch! Reason: " + masterFlight4.FlightCannotLaunch_Feedback, patrol_.Name + " cannot launch", LoggedMessage.MessageType.AirOps, 0, null, side_0, new Geopoint_Struct(activeUnit3.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit3.get_Latitude((GlobalVariables.BooleanObject)null)));
							}
							if (bool_7)
							{
								SendMessageBoxToUI("Mission " + patrol_.Name + ", aircraft type " + masterFlight4.get_ReferenceUnit(scenario_0).UnitClass + " with loadout " + ((Aircraft)masterFlight4.get_ReferenceUnit(scenario_0)).LoadoutName + " based on " + masterFlight4.TakeOffLocation_HostUnitObjectName + " cannot launch! Reason: " + masterFlight4.FlightCannotLaunch_Feedback, side_0);
							}
						}
					}
				}
				goto IL_14c9;
			}
			result = (byte)num != 0;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 699638525572", "");
			WriteExceptionsToLog(ex2);
			int num14;
			if (!Debugger.IsAttached)
			{
				num14 = 0;
			}
			else
			{
				Debugger.Break();
				num14 = 0;
			}
			result = (byte)num14 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private static void smethod_16(bool bool_1, object object_0, ref List<Aircraft> list_2, bool bool_2, int int_0, ref List<ActiveUnit> list_3, ref List<int> list_4, ref List<Aircraft> list_5, ref List<int> list_6, ref List<Aircraft> list_7, ref Mission._FlightSize _FlightSize_0, ref bool bool_3)
	{
		try
		{
			int num = int_0;
			if (!bool_2 && num <= 0)
			{
				foreach (Aircraft item in list_7)
				{
					list_2.Add(item);
				}
				return;
			}
			List<Aircraft> list;
			int num2;
			int num4;
			List<Aircraft> list15;
			int count;
			int num23;
			List<Aircraft> list16;
			int num24;
			int num25;
			switch (((Mission)object_0).OneThirdGrouping)
			{
			case Mission.OneThirdGroupingType.ByLoadout:
			{
				using List<int>.Enumerator enumerator2 = list_4.GetEnumerator();
				_Closure$__179-0 closure$__179- = default(_Closure$__179-0);
				_Closure$__179-1 closure$__179-2 = default(_Closure$__179-1);
				_Closure$__179-2 closure$__179-3 = default(_Closure$__179-2);
				while (enumerator2.MoveNext())
				{
					closure$__179- = new _Closure$__179-0(closure$__179-);
					closure$__179-.$VB$Local_theDBID = enumerator2.Current;
					List<Aircraft> list2 = list_5.Where(closure$__179-._Lambda$__0).ToList();
					List<Aircraft> list3 = new List<Aircraft>();
					if (list2.Count <= 0)
					{
						continue;
					}
					using List<int>.Enumerator enumerator3 = list_6.GetEnumerator();
					while (enumerator3.MoveNext())
					{
						closure$__179-2 = new _Closure$__179-1(closure$__179-2);
						closure$__179-2.$VB$NonLocal_$VB$Closure_2 = closure$__179-;
						closure$__179-2.$VB$Local_theLoadoutDBID = enumerator3.Current;
						if (bool_2)
						{
							List<Aircraft> list4 = list2.Where(closure$__179-2._Lambda$__1).ToList();
							int num5 = _FlightSize_0;
							int num6 = (int)Math.Round(Math.Ceiling((double)list4.Count / 3.0 / (double)num5) * (double)num5);
							List<Aircraft> list5 = ((!bool_1) ? list4.Where([SpecialName] (Aircraft theAC) =>
							{
								if (!theAC.AirOps.IsTakingOff && (!theAC.IsOperating() || ((ActiveUnit)theAC).IsRTB || theAC.Navigator.IsOnAutoPlannerPlottedCourse_StationEgressRun || (theAC.IsGroupWingman() && !Information.IsNothing((object)((ActiveUnit)theAC).get_ParentGroup(UsingMissionPlanner: false).GroupLead) && ((ActiveUnit)theAC).get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.IsOnAutoPlannerPlottedCourse_StationEgressRun)))
								{
									int result;
									if (!theAC.Navigator.HasFlightPlan)
									{
										result = 0;
									}
									else
									{
										if (Information.IsNothing((object)((ActiveUnit_Navigator)theAC.Navigator).get_Flight(HierarchySearch: true).FlightPlan[0].Time_Zulu))
										{
											return theAC.IsReadyForTakeOff();
										}
										result = 0;
									}
									return (byte)result != 0;
								}
								return true;
							}).ToList() : list4.Select([SpecialName] (Aircraft theAC) => theAC).ToList());
							list5.AddRange(list3.Where(closure$__179-2._Lambda$__4));
							if (list5.Count >= num6)
							{
								continue;
							}
						}
						using List<ActiveUnit>.Enumerator enumerator4 = list_3.GetEnumerator();
						while (enumerator4.MoveNext())
						{
							closure$__179-3 = new _Closure$__179-2(closure$__179-3);
							closure$__179-3.$VB$NonLocal_$VB$Closure_3 = closure$__179-2;
							closure$__179-3.$VB$Local_theHost = enumerator4.Current;
							int num7 = 0;
							if (bool_2)
							{
								List<Aircraft> list6 = list2.Where((closure$__179-3.$VB$NonLocal_$VB$Closure_3.$I5 != null) ? closure$__179-3.$VB$NonLocal_$VB$Closure_3.$I5 : (closure$__179-3.$VB$NonLocal_$VB$Closure_3.$I5 = [SpecialName] (Aircraft theAC) => !Information.IsNothing((object)theAC.Loadout) && theAC.Loadout.DBID == closure$__179-3.$VB$NonLocal_$VB$Closure_3.$VB$Local_theLoadoutDBID)).ToList();
								int num8 = _FlightSize_0;
								int num9 = (int)Math.Round(Math.Ceiling((double)list6.Count / 3.0 / (double)num8) * (double)num8);
								List<Aircraft> list7 = ((!bool_1) ? list6.Where([SpecialName] (Aircraft theAC) =>
								{
									if (theAC.AirOps.IsTakingOff)
									{
										goto IL_00a3;
									}
									if (!theAC.IsOperating() || ((ActiveUnit)theAC).IsRTB || theAC.Navigator.IsOnAutoPlannerPlottedCourse_StationEgressRun)
									{
										goto IL_0066;
									}
									int result;
									if (!theAC.IsGroupWingman())
									{
										result = 1;
									}
									else
									{
										if (!Information.IsNothing((object)((ActiveUnit)theAC).get_ParentGroup(UsingMissionPlanner: false).GroupLead))
										{
											if (((ActiveUnit)theAC).get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.IsOnAutoPlannerPlottedCourse_StationEgressRun)
											{
												goto IL_0066;
											}
											goto IL_00a3;
										}
										result = 1;
									}
									goto IL_00a4;
									IL_00a3:
									result = 1;
									goto IL_00a4;
									IL_00a4:
									return (byte)result != 0;
									IL_0066:
									int result2;
									if (!theAC.Navigator.HasFlightPlan)
									{
										result2 = 0;
									}
									else
									{
										if (Information.IsNothing((object)((ActiveUnit_Navigator)theAC.Navigator).get_Flight(HierarchySearch: true).FlightPlan[0].Time_Zulu))
										{
											return theAC.IsReadyForTakeOff();
										}
										result2 = 0;
									}
									return (byte)result2 != 0;
								}).ToList() : list6.Select([SpecialName] (Aircraft theAC) => theAC).ToList());
								list7.AddRange(list3.Where([SpecialName] (Aircraft a) => !Information.IsNothing((object)a.Loadout) && a.Loadout.DBID == closure$__179-3.$VB$NonLocal_$VB$Closure_3.$VB$Local_theLoadoutDBID));
								int num10 = Math.Max(0, num9 - list7.Count);
								if (num10 <= 0)
								{
									break;
								}
								num7 = (int)Math.Round(Math.Ceiling((double)num10 / (double)num8) * (double)num8);
							}
							List<Aircraft> list8 = (bool_1 ? list2.Where(closure$__179-3._Lambda$__9).ToList() : list_7.Where(closure$__179-3._Lambda$__10).ToList());
							if (!bool_2)
							{
								int num11 = _FlightSize_0;
								int num12 = ((num > 0) ? ((int)Math.Round(Math.Ceiling((double)num / (double)num11) * (double)num11)) : 0);
								if (num12 > 0)
								{
									List<Aircraft> list9 = ((!bool_1) ? list2.Where((closure$__179-3.$VB$NonLocal_$VB$Closure_3.$I12 != null) ? closure$__179-3.$VB$NonLocal_$VB$Closure_3.$I12 : (closure$__179-3.$VB$NonLocal_$VB$Closure_3.$I12 = [SpecialName] (Aircraft theAC) =>
									{
										int result;
										int result2;
										if (Information.IsNothing((object)theAC.Loadout))
										{
											result = 0;
										}
										else
										{
											if (theAC.Loadout.DBID == closure$__179-3.$VB$NonLocal_$VB$Closure_3.$VB$Local_theLoadoutDBID)
											{
												if (theAC.AirOps.IsTakingOff)
												{
													goto IL_00cc;
												}
												if (!theAC.IsOperating() || ((ActiveUnit)theAC).IsRTB || theAC.Navigator.IsOnAutoPlannerPlottedCourse_StationEgressRun)
												{
													goto IL_008f;
												}
												if (!theAC.IsGroupWingman())
												{
													result2 = 1;
												}
												else
												{
													if (Information.IsNothing((object)((ActiveUnit)theAC).get_ParentGroup(UsingMissionPlanner: false).GroupLead))
													{
														goto IL_00cc;
													}
													if (((ActiveUnit)theAC).get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.IsOnAutoPlannerPlottedCourse_StationEgressRun)
													{
														goto IL_008f;
													}
													result2 = 1;
												}
												goto IL_00cd;
											}
											result = 0;
										}
										return (byte)result != 0;
										IL_008f:
										int result3;
										if (theAC.Navigator.HasFlightPlan)
										{
											if (Information.IsNothing((object)((ActiveUnit_Navigator)theAC.Navigator).get_Flight(HierarchySearch: true).FlightPlan[0].Time_Zulu))
											{
												return theAC.IsReadyForTakeOff();
											}
											result3 = 0;
										}
										else
										{
											result3 = 0;
										}
										return (byte)result3 != 0;
										IL_00cc:
										result2 = 1;
										goto IL_00cd;
										IL_00cd:
										return (byte)result2 != 0;
									})).ToList() : list2.Where((closure$__179-3.$VB$NonLocal_$VB$Closure_3.$I11 != null) ? closure$__179-3.$VB$NonLocal_$VB$Closure_3.$I11 : (closure$__179-3.$VB$NonLocal_$VB$Closure_3.$I11 = [SpecialName] (Aircraft theAC) => !Information.IsNothing((object)theAC.Loadout) && theAC.Loadout.DBID == closure$__179-3.$VB$NonLocal_$VB$Closure_3.$VB$Local_theLoadoutDBID)).ToList());
									list9.AddRange(list3.Where((closure$__179-3.$VB$NonLocal_$VB$Closure_3.$I13 != null) ? closure$__179-3.$VB$NonLocal_$VB$Closure_3.$I13 : (closure$__179-3.$VB$NonLocal_$VB$Closure_3.$I13 = [SpecialName] (Aircraft a) => !Information.IsNothing((object)a.Loadout) && a.Loadout.DBID == closure$__179-3.$VB$NonLocal_$VB$Closure_3.$VB$Local_theLoadoutDBID)));
									if (list9.Count >= num12)
									{
										break;
									}
								}
							}
							if (list8.Count <= 0 || (bool_3 && list8.Count < (int)_FlightSize_0))
							{
								continue;
							}
							if (bool_2 && num > 0)
							{
								num = (int)Math.Round(Math.Ceiling(Math.Max((double)list2.Count / (double)(int)_FlightSize_0 / 3.0, (double)num / (double)(int)_FlightSize_0)) * (double)(int)_FlightSize_0);
							}
							else if (bool_2 && num == 0)
							{
								num = (int)Math.Round(Math.Ceiling((double)list2.Count / (double)(int)_FlightSize_0 / 3.0) * (double)(int)_FlightSize_0);
							}
							else if (!bool_2 && num > 0)
							{
								num = (int)Math.Round(Math.Ceiling((double)num / (double)(int)_FlightSize_0) * (double)(int)_FlightSize_0);
							}
							if (!bool_2)
							{
								int num13 = _FlightSize_0;
								int num14 = ((num > 0) ? ((int)Math.Round(Math.Ceiling((double)num / (double)num13) * (double)num13)) : 0);
								if (bool_1)
								{
									List<Aircraft> list10 = list2.Where((closure$__179-3.$VB$NonLocal_$VB$Closure_3.$I14 != null) ? closure$__179-3.$VB$NonLocal_$VB$Closure_3.$I14 : (closure$__179-3.$VB$NonLocal_$VB$Closure_3.$I14 = [SpecialName] (Aircraft theAC) => !Information.IsNothing((object)theAC.Loadout) && theAC.Loadout.DBID == closure$__179-3.$VB$NonLocal_$VB$Closure_3.$VB$Local_theLoadoutDBID)).ToList();
									list10.AddRange(list3.Where((closure$__179-3.$VB$NonLocal_$VB$Closure_3.$I15 != null) ? closure$__179-3.$VB$NonLocal_$VB$Closure_3.$I15 : (closure$__179-3.$VB$NonLocal_$VB$Closure_3.$I15 = [SpecialName] (Aircraft a) => !Information.IsNothing((object)a.Loadout) && a.Loadout.DBID == closure$__179-3.$VB$NonLocal_$VB$Closure_3.$VB$Local_theLoadoutDBID)));
									num7 = (int)Math.Round(Math.Ceiling((double)Math.Max(0, num14 - list10.Count) / (double)num13) * (double)num13);
								}
								else
								{
									List<Aircraft> list11 = list2.Where([SpecialName] (Aircraft theAC) =>
									{
										int result;
										int result2;
										if (Information.IsNothing((object)theAC.Loadout))
										{
											result = 0;
										}
										else
										{
											if (theAC.Loadout.DBID == closure$__179-3.$VB$NonLocal_$VB$Closure_3.$VB$Local_theLoadoutDBID)
											{
												if (!theAC.AirOps.IsTakingOff)
												{
													if (theAC.IsOperating() && !((ActiveUnit)theAC).IsRTB && !theAC.Navigator.IsOnAutoPlannerPlottedCourse_StationEgressRun)
													{
														if (!theAC.IsGroupWingman() || Information.IsNothing((object)((ActiveUnit)theAC).get_ParentGroup(UsingMissionPlanner: false).GroupLead))
														{
															goto IL_00c6;
														}
														if (!((ActiveUnit)theAC).get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.IsOnAutoPlannerPlottedCourse_StationEgressRun)
														{
															result2 = 1;
															goto IL_00c7;
														}
													}
													if (theAC.Navigator.HasFlightPlan && Information.IsNothing((object)((ActiveUnit_Navigator)theAC.Navigator).get_Flight(HierarchySearch: true).FlightPlan[0].Time_Zulu))
													{
														return theAC.IsReadyForTakeOff();
													}
													return false;
												}
												goto IL_00c6;
											}
											result = 0;
										}
										return (byte)result != 0;
										IL_00c6:
										result2 = 1;
										goto IL_00c7;
										IL_00c7:
										return (byte)result2 != 0;
									}).ToList();
									list11.AddRange(list3.Where([SpecialName] (Aircraft a) => !Information.IsNothing((object)a.Loadout) && a.Loadout.DBID == closure$__179-3.$VB$NonLocal_$VB$Closure_3.$VB$Local_theLoadoutDBID));
									num7 = (int)Math.Round(Math.Ceiling((double)Math.Max(0, num14 - list11.Count) / (double)num13) * (double)num13);
								}
							}
							if (Information.IsNothing((object)num7) || num7 <= 0)
							{
								continue;
							}
							for (int num15 = num7 - 1; num15 >= 0; num15 += -1)
							{
								if (bool_3 && list8.Count < (int)_FlightSize_0)
								{
									break;
								}
								int num16 = _FlightSize_0;
								for (int num17 = 1; num17 <= num16; num17++)
								{
									if (list8.Count > 0)
									{
										list_2.Add(list8[0]);
										list3.Add(list8[0]);
										list8.RemoveAt(0);
										if (num17 > 1)
										{
											num15--;
										}
									}
								}
							}
						}
					}
				}
				break;
			}
			case Mission.OneThirdGroupingType.ByUnitClass:
			{
				using List<int>.Enumerator enumerator5 = list_4.GetEnumerator();
				_Closure$__179-3 closure$__179-4 = default(_Closure$__179-3);
				while (enumerator5.MoveNext())
				{
					closure$__179-4 = new _Closure$__179-3(closure$__179-4);
					closure$__179-4.$VB$Local_theDBID = enumerator5.Current;
					List<Aircraft> list12 = list_5.Where(closure$__179-4._Lambda$__18).ToList();
					if (list12.Count == 0)
					{
						continue;
					}
					int num18 = _FlightSize_0;
					int num19 = (bool_2 ? ((int)Math.Ceiling((double)list12.Count / 3.0)) : ((!bool_2 && num > 0) ? ((int)Math.Ceiling((double)num / 1.0)) : 0));
					if (bool_3 && num18 > 1)
					{
						num19 = (int)Math.Round(Math.Ceiling((double)num19 / (double)num18) * (double)num18);
					}
					List<Aircraft> list13 = ((!bool_1) ? list12.Where([SpecialName] (Aircraft theAC) =>
					{
						int result;
						if (!theAC.AirOps.IsTakingOff)
						{
							if (theAC.IsOperating() && !((ActiveUnit)theAC).IsRTB && !theAC.Navigator.IsOnAutoPlannerPlottedCourse_StationEgressRun)
							{
								if (!theAC.IsGroupWingman())
								{
									result = 1;
									goto IL_009a;
								}
								if (((ActiveUnit)theAC).get_ParentGroup(UsingMissionPlanner: false).GroupLead == null || !((ActiveUnit)theAC).get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.IsOnAutoPlannerPlottedCourse_StationEgressRun)
								{
									goto IL_0099;
								}
							}
							int result2;
							if (!theAC.Navigator.HasFlightPlan)
							{
								result2 = 0;
							}
							else
							{
								if (!((ActiveUnit_Navigator)theAC.Navigator).get_Flight(HierarchySearch: true).FlightPlan[0].Time_Zulu.HasValue)
								{
									return theAC.IsReadyForTakeOff();
								}
								result2 = 0;
							}
							return (byte)result2 != 0;
						}
						goto IL_0099;
						IL_009a:
						return (byte)result != 0;
						IL_0099:
						result = 1;
						goto IL_009a;
					}).ToList() : list12.Select([SpecialName] (Aircraft theAC) => theAC).ToList());
					int num20 = list_2.Where(closure$__179-4._Lambda$__21).Count();
					int num21 = num19 - (list13.Count + num20);
					if (num21 <= 0)
					{
						continue;
					}
					List<Aircraft> list14 = list_7.Where(closure$__179-4._Lambda$__22).ToList();
					if ((bool_3 && list14.Count < num18) || list14.Count <= 0)
					{
						continue;
					}
					int num22 = 0;
					if (bool_3 && num18 > 1)
					{
						num21 = (int)Math.Round(Math.Ceiling((double)num21 / (double)num18) * (double)num18);
					}
					while (num21 > 0 && num22 < list14.Count)
					{
						Aircraft aircraft = list14[num22];
						if (aircraft != null && aircraft.AI.IsAllowedToRedeploy_AllChecks)
						{
							list_2.Add(aircraft);
							num21--;
						}
						num22++;
					}
				}
				break;
			}
			case Mission.OneThirdGroupingType.NoGrouping:
				{
					list = list_5.ToList();
					num2 = _FlightSize_0;
					if (!bool_2)
					{
						int num3;
						if (bool_2)
						{
							num3 = 0;
						}
						else
						{
							if (num > 0)
							{
								num4 = num;
								goto IL_0aff;
							}
							num3 = 0;
						}
						num4 = num3;
					}
					else
					{
						num4 = (int)Math.Ceiling((double)list.Count / 3.0);
					}
					goto IL_0aff;
				}
				IL_0aff:
				if (bool_3 && num2 > 1)
				{
					num4 = (int)Math.Round(Math.Ceiling((double)num4 / (double)num2) * (double)num2);
				}
				list15 = (bool_1 ? list.Select([SpecialName] (Aircraft theAC) => theAC).ToList() : list.Where([SpecialName] (Aircraft theAC) =>
				{
					int result;
					if (theAC.AirOps.IsTakingOff)
					{
						result = 1;
					}
					else
					{
						if (!theAC.IsOperating() || ((ActiveUnit)theAC).IsRTB || theAC.Navigator.IsOnAutoPlannerPlottedCourse_StationEgressRun || (theAC.IsGroupWingman() && ((ActiveUnit)theAC).get_ParentGroup(UsingMissionPlanner: false).GroupLead != null && ((ActiveUnit)theAC).get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.IsOnAutoPlannerPlottedCourse_StationEgressRun))
						{
							int result2;
							if (!theAC.Navigator.HasFlightPlan)
							{
								result2 = 0;
							}
							else
							{
								if (!((ActiveUnit_Navigator)theAC.Navigator).get_Flight(HierarchySearch: true).FlightPlan[0].Time_Zulu.HasValue)
								{
									return theAC.IsReadyForTakeOff();
								}
								result2 = 0;
							}
							return (byte)result2 != 0;
						}
						result = 1;
					}
					return (byte)result != 0;
				}).ToList());
				count = list_2.Count;
				num23 = num4 - (list15.Count + count);
				if (num23 <= 0)
				{
					break;
				}
				list16 = list_7.ToList();
				if ((bool_3 && list16.Count < num2) || list16.Count <= 0)
				{
					break;
				}
				if (!bool_3)
				{
					num24 = 0;
				}
				else if (num2 > 1)
				{
					num23 = (int)Math.Round(Math.Ceiling((double)num23 / (double)num2) * (double)num2);
					num24 = 0;
				}
				else
				{
					num24 = 0;
				}
				num25 = num24;
				while (num23 > 0 && num25 < list16.Count)
				{
					Aircraft aircraft2 = list16[num25];
					if (aircraft2 != null && aircraft2.AI.IsAllowedToRedeploy_AllChecks)
					{
						list_2.Add(aircraft2);
						num23--;
					}
					num25++;
				}
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 7552222222", "");
			WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void smethod_17(ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, ref Strike strike_0, bool bool_1, ref Mission._FlightSize _FlightSize_0, ref Mission._FlightSize _FlightSize_1, ref Mission._FlightSize _FlightSize_2, ref List<Aircraft> list_2, ref List<Aircraft> list_3, ref List<Aircraft> list_4, ref List<Aircraft> list_5, ref string string_6, ref int int_0, ref int int_1, ref Doctrine._UseUnderwayRefuelAndReplenishment? nullable_0, bool bool_2, DateTime? nullable_1, DateTime? nullable_2, bool bool_3, bool bool_4)
	{
		try
		{
			Strike strike = (Strike)mission_0;
			Dictionary<Contact, int> dictionary = new Dictionary<Contact, int>();
			List<ActiveUnit> list = Module_Mission.UnitsAssignedToMissionOrPackage(strike, scenario_0);
			foreach (Module_Unit.Unit specificTarget in strike.SpecificTargets)
			{
				Contact value = null;
				if (!specificTarget.IsContact())
				{
					if (specificTarget.IsActiveUnit)
					{
						side_0.Contacts.TryGetValue(specificTarget.ObjectID, out value);
					}
				}
				else
				{
					value = (Contact)specificTarget;
				}
				if (value == null)
				{
					continue;
				}
				int num = 0;
				foreach (ActiveUnit item2 in list)
				{
					if (!item2.IsAircraft)
					{
						continue;
					}
					Aircraft aircraft = (Aircraft)item2;
					if (((ActiveUnit_Navigator)aircraft.Navigator).get_Flight(HierarchySearch: true) != null)
					{
						if (((ActiveUnit_Navigator)aircraft.Navigator).get_Flight(HierarchySearch: true).PrimaryTarget == value)
						{
							num++;
						}
					}
					else if (aircraft.AI.PrimaryTarget == value)
					{
						num++;
					}
				}
				dictionary.Add(value, num);
			}
			List<Mission.MissionAircraftEntry> list2 = new List<Mission.MissionAircraftEntry>();
			foreach (Aircraft item3 in list_5)
			{
				if (!item3.Navigator.HasFlight && item3.AI.PrimaryTarget != null)
				{
					item3.AI.DropTarget(item3.AI.PrimaryTarget);
				}
			}
			Dictionary<Contact, List<Aircraft>> dictionary2 = new Dictionary<Contact, List<Aircraft>>();
			string Feedback = default(string);
			int FeedbackSeverity = default(int);
			foreach (Aircraft item4 in list_5)
			{
				if (list2.Count > 0)
				{
					bool flag = false;
					foreach (Mission.MissionAircraftEntry item5 in list2)
					{
						if (Operators.CompareString(item5.HostUnitObjectID, item4.AirOps.CurrentHostUnit.ObjectID, false) == 0 && item5.AircraftDBID == item4.DBID && item5.int_0 == item4.Loadout.DBID)
						{
							flag = true;
						}
					}
					if (flag)
					{
						continue;
					}
				}
				bool flag2 = true;
				if (!item4.AI.IsEscort)
				{
					Doctrine._UseShootTourists? canShootTourists = item4.Doctrine.get_ShootTourists(scenario_0, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
					foreach (Contact contacts_ in side_0.Contacts_List)
					{
						if (!item4.AI.ContactIsRelevantToFlightOrMission(contacts_, mission_0, canShootTourists, IgnoreContacStance: false, MyUnitIsInsidePatrolArea: false, IgnoreNeutralContacts: true, null, ref string_6, ref int_0, null, IgnoreMissionSpecificTargetList: true) || !item4.Weaponry.HaveAvailableWeaponSuitableForThisTarget(contacts_, CheckWRA: true, item4.Doctrine, ref Feedback, ref FeedbackSeverity, HumanFeedBackNeeded: false) || !item4.AI.CanMissionTargetThisContactBasedOnPostureStance(ref strike_0, contacts_.get_Stance(((ActiveUnit)item4).get_UnitSide(SetSideOnly: false))) || !item4.AI.CanReachTarget_AirIntercept(contacts_, strike_0.MinResponseRadius_Aircraft, strike_0.MaxResponseRadius_Aircraft, nullable_0, mission_0.LaunchMissionWithoutTankersInPlace, ref string_6))
						{
							continue;
						}
						if (!dictionary.ContainsKey(contacts_) || dictionary[contacts_] < _FlightSize_0.value)
						{
							if (!dictionary2.ContainsKey(contacts_))
							{
								dictionary2.Add(contacts_, new List<Aircraft>());
							}
							dictionary2[contacts_].Add(item4);
						}
						int num2;
						if (!strike.SpecificTargets.Contains(contacts_))
						{
							strike.AddToSpecificTargets(contacts_, automaticallyAquired: true);
							num2 = 0;
						}
						else
						{
							num2 = 0;
						}
						flag2 = (byte)num2 != 0;
					}
					if (flag2)
					{
						Aircraft_AirOps airOps = item4.AirOps;
						Mission.MissionAircraftEntry item = new Mission.MissionAircraftEntry(airOps.CurrentHostUnit.ObjectID, airOps.CurrentHostUnit.Name, item4.DBID, item4.UnitClass, item4.Loadout.DBID, item4.Loadout.Name);
						list2.Add(item);
					}
				}
				else if (item4.Loadout.IsSupportOrPatrol && !(_FlightSize_2 == 0))
				{
					list_4.Add(item4);
				}
				else
				{
					list_3.Add(item4);
				}
			}
			_Closure$__180-0 closure$__180- = default(_Closure$__180-0);
			foreach (Contact key in dictionary2.Keys)
			{
				IEnumerable<Aircraft> enumerable = dictionary2[key];
				List<int> list3 = new List<int>();
				if (enumerable.Count() < _FlightSize_0.value)
				{
					continue;
				}
				using IEnumerator<Aircraft> enumerator8 = enumerable.GetEnumerator();
				while (enumerator8.MoveNext())
				{
					closure$__180- = new _Closure$__180-0(closure$__180-);
					closure$__180-.$VB$Local_ac = enumerator8.Current;
					if (list_2.Contains(closure$__180-.$VB$Local_ac) || closure$__180-.$VB$Local_ac.Loadout == null || list3.Contains(closure$__180-.$VB$Local_ac.Loadout.DBID))
					{
						continue;
					}
					list3.Add(closure$__180-.$VB$Local_ac.Loadout.DBID);
					List<Aircraft> first = enumerable.Where(closure$__180-._Lambda$__0).ToList();
					first = first.Except(list_2).ToList();
					if (first.Count >= _FlightSize_0.value)
					{
						int num3 = _FlightSize_0.value - 1;
						for (int i = 0; i <= num3; i++)
						{
							first[i].AI.PrimaryTarget = key;
							list_2.Add(first[i]);
						}
						break;
					}
				}
			}
			if (list2.Count <= 0)
			{
				return;
			}
			foreach (Mission.MissionAircraftEntry item6 in list2)
			{
				if (!string.IsNullOrEmpty(string_6))
				{
					if (mission_0.TimeSincePlayerNotification == 1 || bool_4)
					{
						ActiveUnit activeUnit = scenario_0.ActiveUnits[item6.HostUnitObjectID];
						scenario_0.AddMessage("Mission " + strike_0.Name + ", aircraft type " + item6.AircraftName + " with loadout " + item6.LoadoutName + " based on " + item6.HostUnitObjectName + " cannot launch! Reason: " + string_6, strike_0.Name + " cannot launch", LoggedMessage.MessageType.AirOps, 0, null, side_0, new Geopoint_Struct(activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
					}
					if (bool_4)
					{
						SendMessageBoxToUI("Mission " + strike_0.Name + ", aircraft type " + item6.AircraftName + " with loadout " + item6.LoadoutName + " based on " + item6.HostUnitObjectName + " cannot launch! Reason: " + string_6, side_0);
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 3475638737636753", "");
			WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void smethod_18(ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, ref Strike strike_0, bool bool_1, ref Mission._FlightSize _FlightSize_0, ref Mission._FlightSize _FlightSize_1, ref Mission._FlightSize _FlightSize_2, ref List<Aircraft> list_2, ref List<Aircraft> list_3, ref List<Aircraft> list_4, ref List<Aircraft> list_5, Contact contact_0, ref string string_6, ref int int_0, ref float float_2, ref float float_3, ref int int_1, ref Doctrine._UseUnderwayRefuelAndReplenishment? nullable_0, ref bool bool_2, bool bool_3, DateTime? nullable_1, DateTime? nullable_2, bool bool_4, bool bool_5)
	{
		try
		{
			Dictionary<string, List<Aircraft>> dictionary = new Dictionary<string, List<Aircraft>>();
			Dictionary<string, Dictionary<int, List<Aircraft>>> dictionary2 = new Dictionary<string, Dictionary<int, List<Aircraft>>>();
			List<Aircraft> list = new List<Aircraft>();
			List<Contact> list2 = new List<Contact>();
			foreach (Aircraft item in list_5)
			{
				if (!item.AI.IsEscort)
				{
					if (!dictionary.ContainsKey(item.AirOps.CurrentHostUnit.ObjectID))
					{
						dictionary.Add(item.AirOps.CurrentHostUnit.ObjectID, new List<Aircraft> { item });
					}
					else
					{
						dictionary[item.AirOps.CurrentHostUnit.ObjectID].Add(item);
					}
					if (dictionary2.ContainsKey(item.AirOps.CurrentHostUnit.ObjectID))
					{
						if (dictionary2[item.AirOps.CurrentHostUnit.ObjectID].ContainsKey(item.LoadoutDBID))
						{
							dictionary2[item.AirOps.CurrentHostUnit.ObjectID][item.LoadoutDBID].Add(item);
							continue;
						}
						dictionary2[item.AirOps.CurrentHostUnit.ObjectID].Add(item.LoadoutDBID, new List<Aircraft> { item });
						list.Add(item);
					}
					else
					{
						dictionary2.Add(item.AirOps.CurrentHostUnit.ObjectID, new Dictionary<int, List<Aircraft>> { 
						{
							item.LoadoutDBID,
							new List<Aircraft> { item }
						} });
						list.Add(item);
					}
				}
				else if (item.Loadout.IsSupportOrPatrol && !(_FlightSize_2 == 0))
				{
					list_4.Add(item);
				}
				else
				{
					list_3.Add(item);
				}
			}
			using (List<Aircraft>.Enumerator enumerator2 = list.GetEnumerator())
			{
				_Closure$__181-0 closure$__181- = default(_Closure$__181-0);
				_Closure$__181-1 closure$__181-2 = default(_Closure$__181-1);
				while (enumerator2.MoveNext())
				{
					closure$__181- = new _Closure$__181-0(closure$__181-);
					closure$__181-.$VB$Local_theMissionAC = enumerator2.Current;
					Mission.Flight theMasterFlightPlanEntry = null;
					List<Mission.Flight> list3 = new List<Mission.Flight>();
					foreach (Mission.Flight masterFlight in mission_0.MasterFlightList)
					{
						if (masterFlight.PathfinderRequestCompleteAndAwaitingUse && masterFlight.int_1 == closure$__181-.$VB$Local_theMissionAC.LoadoutDBID && closure$__181-.$VB$Local_theMissionAC.AirOps.CurrentHostUnit != null && Operators.CompareString(masterFlight.TakeOffLocation_HostUnitObjectID, closure$__181-.$VB$Local_theMissionAC.AirOps.CurrentHostUnit.ObjectID, false) == 0)
						{
							list3.Add(masterFlight);
						}
					}
					bool flag = true;
					Doctrine._UseShootTourists? canShootTourists = closure$__181-.$VB$Local_theMissionAC.Doctrine.get_ShootTourists(scenario_0, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
					PooledSet<string> pooledSet = new PooledSet<string>();
					foreach (Mission.Flight masterFlight2 in mission_0.MasterFlightList)
					{
						pooledSet.Add(masterFlight2.PrimaryTarget_ID);
					}
					if (strike_0.TargetCount > 0)
					{
						IOrderedEnumerable<Module_Unit.Unit> orderedEnumerable = strike_0.SpecificTargets.ToList().OrderByDescending(closure$__181-._Lambda$__0);
						foreach (Module_Unit.Unit item2 in orderedEnumerable)
						{
							closure$__181-2 = new _Closure$__181-1(closure$__181-2);
							Misc.PostureStance theContactStance = Misc.PostureStance.Unknown;
							bool flag2 = false;
							int num;
							if (item2.IsContact())
							{
								closure$__181-2.$VB$Local_theContact = (Contact)item2;
								theContactStance = closure$__181-2.$VB$Local_theContact.get_Stance(side_0);
								num = 0;
							}
							else
							{
								closure$__181-2.$VB$Local_theContact = closure$__181-.$VB$Local_theMissionAC.AI.GetContactForThisUnit(item2);
								if (closure$__181-2.$VB$Local_theContact != null)
								{
									theContactStance = closure$__181-2.$VB$Local_theContact.get_Stance(side_0);
									num = 0;
								}
								else
								{
									flag2 = true;
									closure$__181-2.$VB$Local_theContact = new Contact((ActiveUnit)item2, 0, forWRA: true);
									List<KeyValuePair<Side, Misc.PostureStance>> list4 = side_0.Postures_ReadOnly.Where(closure$__181-2._Lambda$__1).ToList();
									if (list4.Count > 0)
									{
										theContactStance = list4[0].Value;
										num = 0;
									}
									else
									{
										num = 0;
									}
								}
							}
							bool flag3 = (byte)num != 0;
							bool flag4;
							if (closure$__181-2.$VB$Local_theContact.get_IsSpecificTargetForThisStrike(strike_0) && closure$__181-.$VB$Local_theMissionAC.AI.CanMissionTargetThisContactBasedOnPostureStance(ref strike_0, theContactStance) && closure$__181-.$VB$Local_theMissionAC.Weaponry.HaveAvailableWeaponSuitableForThisTarget(closure$__181-2.$VB$Local_theContact, CheckWRA: true, closure$__181-.$VB$Local_theMissionAC.Doctrine, ref string_6, ref int_1, HumanFeedBackNeeded: true))
							{
								if (list3.Count > 0)
								{
									foreach (Mission.Flight item3 in list3)
									{
										if (Operators.CompareString(item3.PrimaryTarget_ID, closure$__181-2.$VB$Local_theContact.ObjectID, false) == 0)
										{
											theMasterFlightPlanEntry = item3;
											theMasterFlightPlanEntry.PathfinderRequestCompleteAndAwaitingUse = false;
											break;
										}
									}
								}
								if (theMasterFlightPlanEntry == null || !pooledSet.Contains(closure$__181-2.$VB$Local_theContact.ObjectID))
								{
									_ = closure$__181-.$VB$Local_theMissionAC.AirOps;
									string theCallsign = ((strike_0.Type != Strike.StrikeType.Sub_Strike) ? ("Master Flightplan AircraftDBID: " + Conversions.ToString(closure$__181-.$VB$Local_theMissionAC.DBID) + " LoadoutDBID: " + Conversions.ToString(closure$__181-.$VB$Local_theMissionAC.LoadoutDBID)) : "Master Flightplan");
									Mission.Flight theFlightPlan = null;
									theMasterFlightPlanEntry = new Mission.Flight(ref scenario_0, ref mission_0, ref theFlightPlan, theCallsign, closure$__181-2.$VB$Local_theContact, closure$__181-.$VB$Local_theMissionAC, _FlightSize_0, theIsEscort: false);
								}
								Aircraft_AI aI = closure$__181-.$VB$Local_theMissionAC.AI;
								ref Contact theTarget = ref closure$__181-2.$VB$Local_theContact;
								int minResponseRadius_Aircraft = strike_0.MinResponseRadius_Aircraft;
								int maxResponseRadius_Aircraft = strike_0.MaxResponseRadius_Aircraft;
								Doctrine._UseUnderwayRefuelAndReplenishment? tankerUsage = nullable_0;
								bool launchMissionWithoutTankersInPlace = mission_0.LaunchMissionWithoutTankersInPlace;
								Mission._RadarBehaviour radarBehaviour = strike_0.RadarBehaviour;
								bool usePlanner = strike_0.UsePlanner;
								float FuelQtyRequired = 0f;
								int num2;
								if (aI.CanReachTarget_Strike(ref scenario_0, ref side_0, ref mission_0, ref theMasterFlightPlanEntry, ref theTarget, minResponseRadius_Aircraft, maxResponseRadius_Aircraft, tankerUsage, launchMissionWithoutTankersInPlace, radarBehaviour, AttemptPathfinderFlightPlan: true, SeparateIngressEgressPathfinderFlightPlans: false, AircraftIsAirborne: false, usePlanner, ref FuelQtyRequired, ref string_6, bool_1, ref bool_2, bool_2, ref float_2, ref float_3, CreateFlightPlan: true, null, bool_3, nullable_1, nullable_2, bool_4, IsMFP: true))
								{
									flag = false;
									theMasterFlightPlanEntry.FlightCannotLaunch = false;
									theMasterFlightPlanEntry.FlightCannotLaunch_Feedback = "";
									mission_0.AddMasterFlight(ref theMasterFlightPlanEntry);
									num2 = 0;
								}
								else
								{
									num2 = 0;
								}
								flag4 = (byte)num2 != 0;
								if (strike_0.Type == Strike.StrikeType.Sub_Strike)
								{
									flag4 = true;
								}
								else
								{
									int num3;
									if (theMasterFlightPlanEntry.FlightPlan.Count() <= 0)
									{
										if (theMasterFlightPlanEntry.FlightPlan_Pathfinder_Ingress_1.Count() <= 0)
										{
											goto IL_062f;
										}
										num3 = 1;
									}
									else
									{
										num3 = 1;
									}
									flag4 = (byte)num3 != 0;
								}
								goto IL_062f;
							}
							goto IL_0764;
							IL_062f:
							if (strike_0.MaxResponseRadius_Aircraft > 0)
							{
								ActiveUnit b = closure$__181-.$VB$Local_theMissionAC.AirOps.get_AssignedHostUnit(PickNewAssignedHost: false);
								flag4 = !(Math2.CalcDist(closure$__181-2.$VB$Local_theContact, b) > (float)strike_0.MaxResponseRadius_Aircraft);
							}
							foreach (Aircraft item4 in list_5)
							{
								if (!((Operators.CompareString(item4.AirOps.CurrentHostUnit.ObjectID, closure$__181-.$VB$Local_theMissionAC.AirOps.CurrentHostUnit.ObjectID, false) == 0) & (item4.LoadoutDBID == closure$__181-.$VB$Local_theMissionAC.LoadoutDBID)))
								{
									continue;
								}
								if (!flag4)
								{
									if (item4.AirborneTime > 0f && item4.AI.IsTargetingThisContact(closure$__181-2.$VB$Local_theContact))
									{
										item4.AI.DropTarget(closure$__181-2.$VB$Local_theContact, IgnoreTargetIllumination: false);
									}
									continue;
								}
								if (!list_2.Contains(item4))
								{
									list_2.Add(item4);
								}
								if (contact_0 == null && !flag2)
								{
									contact_0 = closure$__181-2.$VB$Local_theContact;
								}
							}
							goto IL_0764;
							IL_0764:
							if (flag3)
							{
								break;
							}
						}
					}
					else
					{
						List<Contact> list5 = new List<Contact>();
						for (int i = side_0.Contacts_List.Count - 1; i >= 0; i += -1)
						{
							Contact contact = side_0.Contacts_List[i];
							if (!closure$__181-.$VB$Local_theMissionAC.AI.ContactIsRelevantToFlightOrMission(contact, mission_0, canShootTourists, IgnoreContacStance: false, MyUnitIsInsidePatrolArea: false, IgnoreNeutralContacts: true, null, ref string_6, ref int_0, null, IgnoreMissionSpecificTargetList: true) || !closure$__181-.$VB$Local_theMissionAC.Weaponry.HaveAvailableWeaponSuitableForThisTarget(contact, CheckWRA: true, closure$__181-.$VB$Local_theMissionAC.Doctrine, ref string_6, ref int_1, HumanFeedBackNeeded: true) || !is_Target_Distance_Valid(strike_0, contact))
							{
								continue;
							}
							bool flag5 = false;
							foreach (Mission.Flight flight in mission_0.FlightList)
							{
								if (flight != null && flight.PrimaryTarget == contact && flight.get_Status(scenario_0) != Mission._FlightStatus.Completed)
								{
									flag5 = true;
									break;
								}
							}
							if (!flag5)
							{
								list5.Add(contact);
								if (closure$__181-.$VB$Local_theMissionAC.AI.CanMissionTargetThisContactBasedOnPostureStance(ref strike_0, contact.get_Stance(side_0)) && !list2.Contains(contact))
								{
									list2.Add(contact);
								}
							}
						}
						foreach (Contact item5 in list5)
						{
							Contact theTarget2 = item5;
							if (list3.Count > 0)
							{
								foreach (Mission.Flight item6 in list3)
								{
									if (Operators.CompareString(item6.PrimaryTarget_ID, theTarget2.ObjectID, false) == 0)
									{
										theMasterFlightPlanEntry = item6;
										theMasterFlightPlanEntry.PathfinderRequestCompleteAndAwaitingUse = false;
										break;
									}
								}
							}
							if (theMasterFlightPlanEntry == null || !pooledSet.Contains(theTarget2.ObjectID))
							{
								_ = closure$__181-.$VB$Local_theMissionAC.AirOps;
								string theCallsign2 = ((strike_0.Type != Strike.StrikeType.Sub_Strike) ? ("Master Flightplan AircraftDBID: " + Conversions.ToString(closure$__181-.$VB$Local_theMissionAC.DBID) + " LoadoutDBID: " + Conversions.ToString(closure$__181-.$VB$Local_theMissionAC.LoadoutDBID)) : "Master Flightplan");
								Mission.Flight theFlightPlan = null;
								theMasterFlightPlanEntry = new Mission.Flight(ref scenario_0, ref mission_0, ref theFlightPlan, theCallsign2, theTarget2, closure$__181-.$VB$Local_theMissionAC, _FlightSize_0, theIsEscort: false);
							}
							Aircraft_AI aI2 = closure$__181-.$VB$Local_theMissionAC.AI;
							int minResponseRadius_Aircraft2 = strike_0.MinResponseRadius_Aircraft;
							int maxResponseRadius_Aircraft2 = strike_0.MaxResponseRadius_Aircraft;
							Doctrine._UseUnderwayRefuelAndReplenishment? tankerUsage2 = nullable_0;
							bool launchMissionWithoutTankersInPlace2 = mission_0.LaunchMissionWithoutTankersInPlace;
							Mission._RadarBehaviour radarBehaviour2 = strike_0.RadarBehaviour;
							bool usePlanner2 = strike_0.UsePlanner;
							float FuelQtyRequired = 0f;
							int num4;
							if (aI2.CanReachTarget_Strike(ref scenario_0, ref side_0, ref mission_0, ref theMasterFlightPlanEntry, ref theTarget2, minResponseRadius_Aircraft2, maxResponseRadius_Aircraft2, tankerUsage2, launchMissionWithoutTankersInPlace2, radarBehaviour2, AttemptPathfinderFlightPlan: true, SeparateIngressEgressPathfinderFlightPlans: false, AircraftIsAirborne: false, usePlanner2, ref FuelQtyRequired, ref string_6, bool_1, ref bool_2, bool_2, ref float_2, ref float_3, CreateFlightPlan: true, null, bool_3, nullable_1, nullable_2, bool_4, IsMFP: true))
							{
								flag = false;
								theMasterFlightPlanEntry.FlightCannotLaunch = false;
								theMasterFlightPlanEntry.FlightCannotLaunch_Feedback = "";
								mission_0.AddMasterFlight(ref theMasterFlightPlanEntry);
								num4 = 0;
							}
							else
							{
								num4 = 0;
							}
							bool flag6 = (byte)num4 != 0;
							if (strike_0.Type == Strike.StrikeType.Sub_Strike)
							{
								if (!flag)
								{
									flag6 = true;
								}
							}
							else
							{
								int num5;
								if (theMasterFlightPlanEntry.FlightPlan.Count() <= 0)
								{
									if (theMasterFlightPlanEntry.FlightPlan_Pathfinder_Ingress_1.Count() <= 0)
									{
										goto IL_0a84;
									}
									num5 = 1;
								}
								else
								{
									num5 = 1;
								}
								flag6 = (byte)num5 != 0;
							}
							goto IL_0a84;
							IL_0a84:
							foreach (Aircraft item7 in list_5)
							{
								if (((Operators.CompareString(item7.AirOps.CurrentHostUnit.ObjectID, closure$__181-.$VB$Local_theMissionAC.AirOps.CurrentHostUnit.ObjectID, false) == 0) & (item7.LoadoutDBID == closure$__181-.$VB$Local_theMissionAC.LoadoutDBID)) && flag6)
								{
									if (!list_2.Contains(item7))
									{
										list_2.Add(item7);
									}
									contact_0 = theTarget2;
									item7.AI.PrimaryTarget = contact_0;
								}
							}
						}
					}
					if (flag)
					{
						if (theMasterFlightPlanEntry == null)
						{
							_ = closure$__181-.$VB$Local_theMissionAC.AirOps;
							string theCallsign3 = ((strike_0.Type != Strike.StrikeType.Sub_Strike) ? ("Master Flightplan AircraftDBID: " + Conversions.ToString(closure$__181-.$VB$Local_theMissionAC.DBID) + " LoadoutDBID: " + Conversions.ToString(closure$__181-.$VB$Local_theMissionAC.LoadoutDBID)) : "Master Flightplan");
							Mission.Flight theFlightPlan = null;
							theMasterFlightPlanEntry = new Mission.Flight(ref scenario_0, ref mission_0, ref theFlightPlan, theCallsign3, null, closure$__181-.$VB$Local_theMissionAC, _FlightSize_0, theIsEscort: false);
							if (bool_5)
							{
								theMasterFlightPlanEntry.FlightCannotLaunch_Feedback = "No targets available.";
							}
						}
						if (!mission_0.MasterFlightList.Contains(theMasterFlightPlanEntry))
						{
							mission_0.AddMasterFlight(ref theMasterFlightPlanEntry);
							theMasterFlightPlanEntry.FlightCannotLaunch = true;
							if (!string.IsNullOrEmpty(string_6))
							{
								theMasterFlightPlanEntry.FlightCannotLaunch_Feedback = string_6;
							}
						}
					}
					pooledSet.Dispose();
				}
			}
			if (MissionPlanner.BeyondRange.Count > 0 && side_0.IsHumanControlled)
			{
				List<string> list6 = new List<string>();
				foreach (Mission.Flight item8 in MissionPlanner.BeyondRange)
				{
					list6.Add(item8.get_ReferenceUnit(scenario_0).Name);
				}
				list6 = (from x in list6.Distinct().ToList()
					orderby x
					select x).ToList();
				string text = "Aircrafts" + Environment.NewLine;
				foreach (string item9 in list6)
				{
					text = text + item9 + Environment.NewLine;
				}
				text += "are withing range but the mission profile requires too much fuel, adjust the flightplan accordingly";
				if (bool_5)
				{
					SendMessageBoxToUI(text, side_0, "WARNING", MessageBoxMessageType.Warning);
				}
				MissionPlanner.BeyondRange.Clear();
			}
			if (list2.Count <= 0)
			{
				return;
			}
			Strike strike = (Strike)mission_0;
			foreach (Contact item10 in list2)
			{
				strike.AddToSpecificTargets(item10, automaticallyAquired: true);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 987654654654654", "");
			WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static bool is_Target_Distance_Valid(Strike myStrike, Contact theC)
	{
		if (myStrike.MaxResponseRadius_Aircraft == 0)
		{
			return true;
		}
		bool result = false;
		foreach (KeyValuePair<ActiveUnit, ActiveUnit> item in myStrike.UnitsAssignedToMission)
		{
			if (item.Value.IsAircraft)
			{
				ActiveUnit activeUnit = ((Aircraft)item.Value).AirOps.get_AssignedHostUnit(PickNewAssignedHost: false);
				if (activeUnit != null && !(Math2.CalcDist(theC, activeUnit) > (float)myStrike.MaxResponseRadius_Aircraft))
				{
					result = true;
					break;
				}
			}
		}
		return result;
	}

	private static bool smethod_19(ref Mission mission_0, ref Aircraft aircraft_0, ref List<Aircraft> list_2, ref Contact contact_0, ref Mission.Flight flight_0, bool bool_1)
	{
		bool result;
		try
		{
			if (mission_0.MasterFlightList.Count != 0)
			{
				foreach (Mission.Flight masterFlight in mission_0.MasterFlightList)
				{
					if (!((aircraft_0.DBID != mission_0.MasterFlightList.ElementAtOrDefault(0).ReferenceUnit_DBID) | (aircraft_0.LoadoutDBID != mission_0.MasterFlightList.ElementAtOrDefault(0).int_1)))
					{
						if (Operators.CompareString(aircraft_0.AirOps.CurrentHostUnit.ObjectID, masterFlight.TakeOffLocation_HostUnitObjectID, false) != 0)
						{
							continue;
						}
						if (masterFlight.PathfinderRequestBeingProcessed_OnThisPulse)
						{
							result = true;
						}
						else if (masterFlight.FlightCannotLaunch)
						{
							result = true;
						}
						else if (masterFlight.FlightPlan.Count() > 0)
						{
							list_2.Add(aircraft_0);
							aircraft_0.AI.PrimaryTarget = contact_0;
							result = true;
						}
						else if (masterFlight.FlightPlan_Pathfinder_Ingress_1.Count() <= 0)
						{
							if (!masterFlight.Pathfinder_Ingress_RequestBeingProcessed)
							{
								break;
							}
							result = true;
						}
						else
						{
							if (masterFlight.FlightPlan_Pathfinder_Ingress_1[0].Type == Waypoint.WaypointType.PathfindingPoint)
							{
								flight_0 = masterFlight;
								break;
							}
							ref Scenario parentScen = ref aircraft_0.ParentScen;
							Mission.Flight flight;
							Waypoint[] theFlightPlan = (flight = masterFlight).FlightPlan_Pathfinder_Ingress_1;
							bool num = MissionPlanner.PackageTimeMakesSense(ref parentScen, ref theFlightPlan, bool_1);
							flight.FlightPlan_Pathfinder_Ingress_1 = theFlightPlan;
							if (!num)
							{
								theFlightPlan = masterFlight.FlightPlan_Pathfinder_Ingress_1;
								ArrayExtensions.Clear(ref theFlightPlan);
								masterFlight.FlightPlan_Pathfinder_Ingress_1 = theFlightPlan;
								masterFlight.FlightCannotLaunch = true;
								break;
							}
							list_2.Add(aircraft_0);
							aircraft_0.AI.PrimaryTarget = contact_0;
							result = true;
						}
					}
					else
					{
						result = false;
					}
					goto end_IL_0001;
				}
			}
			result = false;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 7457375373333", "");
			WriteExceptionsToLog(ex2);
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
		return result;
	}

	private static void smethod_20(ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, ref Patrol patrol_0, bool bool_1, ref Mission._FlightSize _FlightSize_0, ref List<Aircraft> list_2, ref List<Aircraft> list_3, ref string string_6, ref Doctrine._UseUnderwayRefuelAndReplenishment? nullable_0, bool bool_2, DateTime? nullable_1, DateTime? nullable_2, bool bool_3, bool bool_4)
	{
		try
		{
			double StationStart_Lat = default(double);
			double StationStart_Lon = default(double);
			double StationEnd_Lat = default(double);
			double StationEnd_Lon = default(double);
			foreach (Aircraft item in list_3)
			{
				Aircraft aircraft_ = item;
				Mission.Flight flight_ = null;
				Contact contact_ = null;
				if (smethod_19(ref mission_0, ref aircraft_, ref list_2, ref contact_, ref flight_, bool_2))
				{
					continue;
				}
				bool flag = true;
				aircraft_.Doctrine.get_ShootTourists(scenario_0, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
				if (Information.IsNothing((object)flight_))
				{
					_ = aircraft_.AirOps;
					string theCallsign = "Master Flightplan AircraftDBID: " + Conversions.ToString(aircraft_.DBID) + " LoadoutDBID: " + Conversions.ToString(aircraft_.LoadoutDBID);
					Mission.Flight theFlightPlan = null;
					flight_ = new Mission.Flight(ref scenario_0, ref mission_0, ref theFlightPlan, theCallsign, null, aircraft_, _FlightSize_0, theIsEscort: false);
				}
				float StationLength_nm = 50f;
				bool flag2;
				if (aircraft_.Navigator.PlotCourseToStationArea_FlightplanGenerator(ref StationStart_Lat, ref StationStart_Lon, ref StationEnd_Lat, ref StationEnd_Lon, ref StationLength_nm))
				{
					Aircraft_AI aI = aircraft_.AI;
					Doctrine._UseUnderwayRefuelAndReplenishment? tankerUsage = nullable_0;
					bool launchMissionWithoutTankersInPlace = mission_0.LaunchMissionWithoutTankersInPlace;
					float FuelQtyRequired = 0f;
					int num;
					if (!aI.CanReachStation(ref flight_, tankerUsage, launchMissionWithoutTankersInPlace, AttemptPathfinderFlightPlan: true, SeparateIngressEgressPathfinderFlightPlans: false, AircraftIsAirborne: false, ref FuelQtyRequired, ref string_6, bool_1, CreateFlightPlan: true, StationStart_Lat, StationStart_Lon, StationEnd_Lat, StationEnd_Lon, Waypoint.WaypointType.StationStart_Racetrack, Waypoint.TurnRateCategory.HalfStandardRateTurn, bool_2, nullable_1, nullable_2, bool_3, IsMFP: true))
					{
						num = 0;
					}
					else
					{
						flag = false;
						flight_.FlightCannotLaunch = false;
						flight_.FlightCannotLaunch_Feedback = "";
						mission_0.AddMasterFlight(ref flight_);
						num = 0;
					}
					flag2 = (byte)num != 0;
					int num2;
					if (flight_.FlightPlan.Count() <= 0)
					{
						if (flight_.FlightPlan_Pathfinder_Ingress_1.Count() <= 0)
						{
							goto IL_013b;
						}
						num2 = 1;
					}
					else
					{
						num2 = 1;
					}
					flag2 = (byte)num2 != 0;
					goto IL_013b;
				}
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				continue;
				IL_013b:
				if (flag2)
				{
					list_2.Add(aircraft_);
				}
				if (!flag)
				{
					continue;
				}
				if (Information.IsNothing((object)flight_))
				{
					string theCallsign2 = "Master Flightplan AircraftDBID: " + Conversions.ToString(aircraft_.DBID) + " LoadoutDBID: " + Conversions.ToString(aircraft_.LoadoutDBID);
					Mission.Flight theFlightPlan = null;
					flight_ = new Mission.Flight(ref scenario_0, ref mission_0, ref theFlightPlan, theCallsign2, null, aircraft_, _FlightSize_0, theIsEscort: false);
					if (bool_4)
					{
						flight_.FlightCannotLaunch_Feedback = "No targets available.";
					}
				}
				if (!mission_0.MasterFlightList.Contains(flight_))
				{
					mission_0.AddMasterFlight(ref flight_);
					flight_.FlightCannotLaunch = true;
					if (!string.IsNullOrEmpty(string_6))
					{
						flight_.FlightCannotLaunch_Feedback = string_6;
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 789222254242", "");
			WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void smethod_21(ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, ref SupportMission supportMission_0, bool bool_1, ref Mission._FlightSize _FlightSize_0, ref List<Aircraft> list_2, ref List<Aircraft> list_3, ref string string_6, ref Doctrine._UseUnderwayRefuelAndReplenishment? nullable_0, bool bool_2, DateTime? nullable_1, DateTime? nullable_2, bool bool_3, bool bool_4)
	{
		try
		{
			double StationStart_Lat = default(double);
			double StationStart_Lon = default(double);
			double StationEnd_Lat = default(double);
			double StationEnd_Lon = default(double);
			foreach (Aircraft item in list_3)
			{
				Aircraft aircraft_ = item;
				Mission.Flight flight_ = null;
				Contact contact_ = null;
				if (smethod_19(ref mission_0, ref aircraft_, ref list_2, ref contact_, ref flight_, bool_2))
				{
					continue;
				}
				bool flag = true;
				aircraft_.Doctrine.get_ShootTourists(scenario_0, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
				if (flight_ == null)
				{
					string theCallsign = "Master Flightplan AircraftDBID: " + Conversions.ToString(aircraft_.DBID) + " LoadoutDBID: " + Conversions.ToString(aircraft_.LoadoutDBID);
					Mission.Flight theFlightPlan = null;
					flight_ = new Mission.Flight(ref scenario_0, ref mission_0, ref theFlightPlan, theCallsign, null, aircraft_, _FlightSize_0, theIsEscort: false);
				}
				float StationLength_nm = 50f;
				if (!aircraft_.Navigator.PlotCourseToStationArea_FlightplanGenerator(ref StationStart_Lat, ref StationStart_Lon, ref StationEnd_Lat, ref StationEnd_Lon, ref StationLength_nm))
				{
					if (Debugger.IsAttached)
					{
					}
					continue;
				}
				Waypoint.WaypointType thePointType = (aircraft_.IsTanker ? Waypoint.WaypointType.StationStart_Area : Waypoint.WaypointType.StationStart_FigureEight);
				Aircraft_AI aI = aircraft_.AI;
				Doctrine._UseUnderwayRefuelAndReplenishment? tankerUsage = nullable_0;
				bool launchMissionWithoutTankersInPlace = mission_0.LaunchMissionWithoutTankersInPlace;
				float FuelQtyRequired = 0f;
				int num;
				if (aI.CanReachStation(ref flight_, tankerUsage, launchMissionWithoutTankersInPlace, AttemptPathfinderFlightPlan: true, SeparateIngressEgressPathfinderFlightPlans: false, AircraftIsAirborne: false, ref FuelQtyRequired, ref string_6, bool_1, CreateFlightPlan: true, StationStart_Lat, StationStart_Lon, StationEnd_Lat, StationEnd_Lon, thePointType, Waypoint.TurnRateCategory.FlatTurn, bool_2, nullable_1, nullable_2, bool_3, IsMFP: true))
				{
					flag = false;
					flight_.FlightCannotLaunch = false;
					flight_.FlightCannotLaunch_Feedback = "";
					mission_0.AddMasterFlight(ref flight_);
					num = 0;
				}
				else
				{
					num = 0;
				}
				bool flag2 = (byte)num != 0;
				int num2;
				if (flight_.FlightPlan.Count() <= 0)
				{
					if (flight_.FlightPlan_Pathfinder_Ingress_1.Count() <= 0)
					{
						goto IL_014e;
					}
					num2 = 1;
				}
				else
				{
					num2 = 1;
				}
				flag2 = (byte)num2 != 0;
				goto IL_014e;
				IL_014e:
				if (flag2)
				{
					list_2.Add(aircraft_);
				}
				if (!flag)
				{
					continue;
				}
				if (flight_ == null)
				{
					_ = aircraft_.AirOps;
					string theCallsign2 = "Master Flightplan AircraftDBID: " + Conversions.ToString(aircraft_.DBID) + " LoadoutDBID: " + Conversions.ToString(aircraft_.LoadoutDBID);
					Mission.Flight theFlightPlan = null;
					flight_ = new Mission.Flight(ref scenario_0, ref mission_0, ref theFlightPlan, theCallsign2, null, aircraft_, _FlightSize_0, theIsEscort: false);
					if (bool_4)
					{
						flight_.FlightCannotLaunch_Feedback = "No targets available.";
					}
				}
				if (!mission_0.MasterFlightList.Contains(flight_))
				{
					mission_0.AddMasterFlight(ref flight_);
					flight_.FlightCannotLaunch = true;
					if (!string.IsNullOrEmpty(string_6))
					{
						flight_.FlightCannotLaunch_Feedback = string_6;
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 757272724742742", "");
			WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static bool smethod_22(ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, bool bool_1, ref List<Aircraft> list_2, ref Mission._FlightSize _FlightSize_0, ref Mission._FlightSize _FlightSize_1, ref Mission._FlightSize _FlightSize_2, ref bool bool_2, ref bool bool_3, ref int int_0, ref int int_1, ref int int_2, ref int int_3, ref int int_4, ref int int_5, ref List<Aircraft> list_3, ref List<Aircraft> list_4, ref List<Aircraft> list_5, ref Doctrine._UseUnderwayRefuelAndReplenishment? nullable_0, ref bool bool_4, ref List<int> list_6, ref float float_2, ref float float_3, bool bool_5, ref List<Group> list_7, ref List<Aircraft> list_8, ref List<Aircraft> list_9, ref List<Aircraft> list_10, ref List<ActiveUnit> list_11, ref List<Aircraft> list_12, ref string string_6, double double_0, ref bool bool_6, bool bool_7, bool bool_8, bool bool_9, ref Mission.Flight flight_0, bool bool_10)
	{
		//IL_1640: Unknown result type (might be due to invalid IL or missing references)
		bool result = default(bool);
		try
		{
			_Closure$__186-5 closure$__186- = new _Closure$__186-5(closure$__186-);
			closure$__186-.$VB$Local_MissionDBID = (from x in list_2
				group x by x.DBID into y
				orderby y.Count()
				select y).FirstOrDefault().ElementAtOrDefault(0).DBID;
			int num3;
			if (mission_0.MissionClass == Mission._MissionClass.Strike)
			{
				if (!Information.IsNothing((object)int_0) && list_3.Count < int_0)
				{
					if (mission_0.TimeSincePlayerNotification == 1 || bool_10)
					{
						scenario_0.AddMessage("Mission " + mission_0.Name + " requires a minimum of " + Conversions.ToString(int_0) + " aircraft, however only " + Conversions.ToString(list_3.Count) + " are available. The mission will not launch.", mission_0.Name + " cannot launch (not enough AC)", LoggedMessage.MessageType.AirOps, 0, null, side_0);
					}
					int num;
					if (bool_10)
					{
						SendMessageBoxToUI("Mission " + mission_0.Name + " requires a minimum of " + Conversions.ToString(int_0) + " aircraft, however only " + Conversions.ToString(list_3.Count) + " are available. The mission will not launch.", side_0);
						num = 0;
					}
					else
					{
						num = 0;
					}
					result = (byte)num != 0;
				}
				else if (!Information.IsNothing((object)int_2) && list_4.Count < int_2)
				{
					if (mission_0.TimeSincePlayerNotification == 1 || bool_10)
					{
						scenario_0.AddMessage("Mission " + mission_0.Name + " requires a minimum of " + Conversions.ToString(int_2) + " shooting (armed) escorts, however only " + Conversions.ToString(list_4.Count) + " are available. The mission will not launch.", mission_0.Name + " not launching (not enough escorts)", LoggedMessage.MessageType.AirOps, 0, null, side_0);
					}
					int num2;
					if (bool_10)
					{
						SendMessageBoxToUI("Mission " + mission_0.Name + " requires a minimum of " + Conversions.ToString(int_2) + " shooting (armed) escorts, however only " + Conversions.ToString(list_4.Count) + " are available. The mission will not launch.", side_0);
						num2 = 0;
					}
					else
					{
						num2 = 0;
					}
					result = (byte)num2 != 0;
				}
				else
				{
					if (Information.IsNothing((object)int_4) || list_5.Count >= int_4)
					{
						goto IL_0519;
					}
					if (_FlightSize_2 == 0)
					{
						num3 = 0;
						goto IL_051a;
					}
					if (mission_0.TimeSincePlayerNotification == 1 || bool_10)
					{
						scenario_0.AddMessage("Mission " + mission_0.Name + " requires a minimum of " + Conversions.ToString(int_4) + " non-shooting escorts (unarmed), however only " + Conversions.ToString(list_5.Count) + " are available. The mission will not launch.", mission_0.Name + " not launching (not enough unarmed escorts)", LoggedMessage.MessageType.AirOps, 0, null, side_0);
					}
					int num4;
					if (bool_10)
					{
						SendMessageBoxToUI("Mission " + mission_0.Name + " requires a minimum of " + Conversions.ToString(int_4) + " non-shooting escorts (unarmed), however only " + Conversions.ToString(list_5.Count) + " are available. The mission will not launch.", side_0);
						num4 = 0;
					}
					else
					{
						num4 = 0;
					}
					result = (byte)num4 != 0;
				}
			}
			else
			{
				if (Information.IsNothing((object)int_0) || list_2.Count >= int_0)
				{
					goto IL_0519;
				}
				if (mission_0.TimeSincePlayerNotification == 1 || bool_10)
				{
					scenario_0.AddMessage("Mission " + mission_0.Name + " requires a minimum of " + Conversions.ToString(int_0) + " aircraft, however only " + Conversions.ToString(list_2.Count) + " are available. The mission will not launch.", mission_0.Name + " not launching (not enough AC)", LoggedMessage.MessageType.AirOps, 0, null, side_0);
				}
				int num5;
				if (bool_10)
				{
					SendMessageBoxToUI("Mission " + mission_0.Name + " requires a minimum of " + Conversions.ToString(int_0) + " aircraft, however only " + Conversions.ToString(list_2.Count) + " are available. The mission will not launch.", side_0);
					num5 = 0;
				}
				else
				{
					num5 = 0;
				}
				result = (byte)num5 != 0;
			}
			goto end_IL_0001;
			IL_1aa6:
			if (bool_5 && mission_0.MissionClass == Mission._MissionClass.Strike && ((!Information.IsNothing((object)int_0) && list_8.Count < int_0) || (!Information.IsNothing((object)int_2) && list_9.Count < int_2) || (!(_FlightSize_2 == 0) && !Information.IsNothing((object)int_4) && list_10.Count < int_4)))
			{
				foreach (Group item4 in list_7)
				{
					item4.Destroy(ScenEditAction: false, IsAimpointFacility: false, DestroyUnitNow: false, "Group destroyed by mission logic");
				}
				if (mission_0.TimeSincePlayerNotification == 1 || bool_10)
				{
					if (mission_0.Category != Mission.MissionCategory.Mission)
					{
						scenario_0.AddMessage(mission_0.Name + " does not fulfill the minimum aircraft requirements. Possible solutions would be to remove the aircraft from the package, change the flight size, or manually create the flight.", mission_0.Name + " cannot launch (not enough AC)", LoggedMessage.MessageType.AirOps, 0, null, side_0);
					}
					else
					{
						scenario_0.AddMessage("Mission " + mission_0.Name + " does not fulfill the minimum aircraft requirements. The mission will not launch. When divided by base/ship, aircraft type and loadout, there isn't enough aircraft to create the minimum number of flights. Possible solutions would be to add more strike aircraft and/or escorts, load aircraft with identical loadouts, or use aircraft from the same base/ship. Alternatively, re-configure the mission and reduce the minimum number of required strike aircraft and/or escorts, or reduce the flight size.", mission_0.Name + " cannot launch (not enough AC)", LoggedMessage.MessageType.AirOps, 0, null, side_0);
					}
				}
				if (bool_10)
				{
					if (mission_0.Category != Mission.MissionCategory.Mission)
					{
						SendMessageBoxToUI(mission_0.Name + " does not fulfill the minimum aircraft requirements. Possible solutions would be to remove the aircraft from the package, change the flight size, or manually create the flight.", side_0);
					}
					else
					{
						SendMessageBoxToUI("Mission " + mission_0.Name + " does not fulfill the minimum aircraft requirements. The mission will not launch. When divided by base/ship, aircraft type and loadout, there isn't enough aircraft to create the minimum number of flights. Possible solutions would be to add more strike aircraft and/or escorts, load aircraft with identical loadouts, or use aircraft from the same base/ship. Alternatively, re-configure the mission and reduce the minimum number of required strike aircraft and/or escorts, or reduce the flight size.", side_0);
					}
				}
			}
			else if (bool_5)
			{
				for (int num6 = list_7.Count - 1; num6 >= 0; num6 += -1)
				{
					Group obj = list_7[num6];
					if (Information.IsNothing((object)obj.Units.Values) || obj.Units.Values.Count <= 0)
					{
						continue;
					}
					ActiveUnit activeUnit = obj.Units.Values.ElementAtOrDefault(0);
					if (!activeUnit.Navigator.HasFlightPlan)
					{
						continue;
					}
					Waypoint waypoint = activeUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan[0];
					if (Information.IsNothing((object)waypoint.Time_Zulu) || !((waypoint.Time_Zulu.Value - scenario_0.Time).TotalSeconds - double_0 - 60.0 >= 0.0))
					{
						continue;
					}
					foreach (Aircraft value2 in obj.Units.Values)
					{
						if (list_8.Contains(value2))
						{
							list_8.Remove(value2);
						}
						else if (list_9.Contains(value2))
						{
							list_9.Remove(value2);
						}
						else if (list_10.Contains(value2))
						{
							list_10.Remove(value2);
						}
					}
					list_7.Remove(obj);
					obj.Destroy(ScenEditAction: false, IsAimpointFacility: false, DestroyUnitNow: false, "Group destroyed by mission logic");
				}
				List<Aircraft> list = new List<Aircraft>();
				list.AddRange(list_8);
				list.AddRange(list_9);
				list.AddRange(list_10);
				foreach (Aircraft item5 in list)
				{
					if (!item5.Navigator.HasFlightPlan)
					{
						continue;
					}
					Waypoint waypoint2 = ((ActiveUnit_Navigator)item5.Navigator).get_Flight(HierarchySearch: true).FlightPlan[0];
					if (Information.IsNothing((object)waypoint2.Time_Zulu) || !((waypoint2.Time_Zulu.Value - scenario_0.Time).TotalSeconds - double_0 - 60.0 >= 0.0))
					{
						continue;
					}
					if (!list_8.Contains(item5))
					{
						if (list_9.Contains(item5))
						{
							list_9.Remove(item5);
						}
						else if (list_10.Contains(item5))
						{
							list_10.Remove(item5);
						}
					}
					else
					{
						list_8.Remove(item5);
					}
				}
				if (list_8.Count == 0 && (list_9.Count > 0 || list_10.Count > 0))
				{
					for (int num7 = list_7.Count - 1; num7 >= 0; num7 += -1)
					{
						Group obj = list_7[num7];
						if (Information.IsNothing((object)obj.Units.Values) || obj.Units.Values.Count <= 0)
						{
							continue;
						}
						foreach (Aircraft value3 in obj.Units.Values)
						{
							if (!list_9.Contains(value3))
							{
								if (list_10.Contains(value3))
								{
									list_10.Remove(value3);
								}
							}
							else
							{
								list_9.Remove(value3);
							}
						}
						list_7.Remove(obj);
						obj.Destroy(ScenEditAction: false, IsAimpointFacility: false, DestroyUnitNow: false, "Group destroyed by mission logic");
					}
					list.AddRange(list_9);
					list.AddRange(list_10);
					foreach (Aircraft item6 in list)
					{
						if (!list_9.Contains(item6))
						{
							if (list_10.Contains(item6))
							{
								list_10.Remove(item6);
							}
						}
						else
						{
							list_9.Remove(item6);
						}
					}
				}
				if (!bool_6 && list_8.Count > 0)
				{
					bool_6 = true;
				}
				mission_0.OrderAircraftToTakeOff(ref scenario_0, list_7, list_8, list_9, list_10);
			}
			bool flag;
			if (mission_0.MissionClass == Mission._MissionClass.Ferry)
			{
				_Closure$__186-10 closure$__186-2 = default(_Closure$__186-10);
				_Closure$__186-9 closure$__186-3 = default(_Closure$__186-9);
				foreach (Mission.Flight flight in mission_0.FlightList)
				{
					Mission.Flight theMasterFlightPlanEntry = flight;
					if (Information.IsNothing((object)theMasterFlightPlanEntry) || theMasterFlightPlanEntry.get_Status(scenario_0) != Mission._FlightStatus.None)
					{
						continue;
					}
					theMasterFlightPlanEntry.DesiredAircraftQty = mission_0.FlightSize;
					if (mission_0.UseFlightSizeHardLimit)
					{
						theMasterFlightPlanEntry.MinimumAircraftQty = mission_0.FlightSize;
					}
					else
					{
						theMasterFlightPlanEntry.MinimumAircraftQty = 1;
					}
					using List<ActiveUnit>.Enumerator enumerator7 = list_11.GetEnumerator();
					while (enumerator7.MoveNext())
					{
						closure$__186-2 = new _Closure$__186-10(closure$__186-2);
						closure$__186-2.$VB$Local_theAircraftHost = enumerator7.Current;
						if (flag)
						{
							break;
						}
						using List<int>.Enumerator enumerator8 = list_6.GetEnumerator();
						while (enumerator8.MoveNext())
						{
							closure$__186-3 = new _Closure$__186-9(closure$__186-3);
							closure$__186-3.$VB$NonLocal_$VB$Closure_6 = closure$__186-2;
							closure$__186-3.$VB$Local_theLoadoutDBID = enumerator8.Current;
							if (flag)
							{
								break;
							}
							IEnumerable<Aircraft> enumerable = list_3.Where(closure$__186-3._Lambda$__14);
							foreach (Aircraft item7 in enumerable)
							{
								Aircraft theAC = item7;
								bool value = false;
								bool AttemptPathfinderFlightPlan = false;
								bool separateIngressEgressPathfinderFlightPlans = false;
								bool aircraftIsAirborne = false;
								float FuelQtyRequired = 0f;
								bool mustUseTanker = false;
								float distanceFromAircraftToPatrolArea = 0f;
								Waypoint.TurnRateCategory theStationTurnRate = Waypoint.TurnRateCategory.DoubleStandardRateTurn;
								if (theMasterFlightPlanEntry.DesiredAircraftQty > 6)
								{
									_ = (int)theMasterFlightPlanEntry.DesiredAircraftQty;
									_ = (int)theMasterFlightPlanEntry.MinimumAircraftQty;
									theMasterFlightPlanEntry.DesiredAircraftQty = 6;
									theMasterFlightPlanEntry.MinimumAircraftQty = 6;
								}
								bool? tankersFound = value;
								string FlightPlanFeedback = "";
								MissionPlanner.GenerateFlightPlan_Skeleton(ref scenario_0, ref side_0, ref mission_0, ref theMasterFlightPlanEntry, ref theAC, tankersFound, ref AttemptPathfinderFlightPlan, separateIngressEgressPathfinderFlightPlans, aircraftIsAirborne, ref FuelQtyRequired, ref FlightPlanFeedback, mustUseTanker, distanceFromAircraftToPatrolArea, theStationTurnRate, IsCreatedManually: true, mission_0.TakeOffTime, mission_0.TimeOnTarget, IsMFP: false);
							}
							if (FlightGroupFilter != FlightGroupFilterOptions.Equipment)
							{
								break;
							}
						}
					}
				}
			}
			result = true;
			goto end_IL_0001;
			IL_051a:
			int num8 = num3;
			flag = false;
			List<int> list2 = new List<int>();
			foreach (Aircraft item8 in list_2)
			{
				if (!list2.Contains(item8.DBID))
				{
					list2.Add(item8.DBID);
				}
			}
			if (!mission_0.UsesOneThirdRule())
			{
				using List<ActiveUnit>.Enumerator enumerator11 = list_11.GetEnumerator();
				_Closure$__186-4 closure$__186-4 = default(_Closure$__186-4);
				_Closure$__186-3 closure$__186-5 = default(_Closure$__186-3);
				IEnumerable<Aircraft> enumerable2 = default(IEnumerable<Aircraft>);
				_Closure$__186-6 closure$__186-6 = default(_Closure$__186-6);
				while (enumerator11.MoveNext())
				{
					closure$__186-4 = new _Closure$__186-4(closure$__186-4);
					closure$__186-4.$VB$NonLocal_$VB$Closure_2 = closure$__186-;
					closure$__186-4.$VB$Local_theAircraftHost = enumerator11.Current;
					if (flag)
					{
						break;
					}
					using List<int>.Enumerator enumerator12 = list_6.GetEnumerator();
					while (enumerator12.MoveNext())
					{
						closure$__186-5 = new _Closure$__186-3(closure$__186-5);
						closure$__186-5.$VB$NonLocal_$VB$Closure_3 = closure$__186-4;
						closure$__186-5.$VB$Local_theLoadoutDBID = enumerator12.Current;
						if (flag)
						{
							break;
						}
						int num9 = 0;
						if (FlightGroupFilter == FlightGroupFilterOptions.Equipment)
						{
							enumerable2 = list_3.Where(closure$__186-5._Lambda$__6);
							goto IL_0b79;
						}
						if (FlightGroupFilter == FlightGroupFilterOptions.FreeForAll)
						{
							enumerable2 = list_3.Where((closure$__186-5.$VB$NonLocal_$VB$Closure_3.$I7 != null) ? closure$__186-5.$VB$NonLocal_$VB$Closure_3.$I7 : (closure$__186-5.$VB$NonLocal_$VB$Closure_3.$I7 = [SpecialName] (Aircraft aircraft) => !Information.IsNothing((object)aircraft.AirOps.CurrentHostUnit) && aircraft.AirOps.CurrentHostUnit == closure$__186-5.$VB$NonLocal_$VB$Closure_3.$VB$Local_theAircraftHost));
							goto IL_0b79;
						}
						if (FlightGroupFilter == FlightGroupFilterOptions.Aircraft)
						{
							enumerable2 = list_3.Where((closure$__186-5.$VB$NonLocal_$VB$Closure_3.$I8 != null) ? closure$__186-5.$VB$NonLocal_$VB$Closure_3.$I8 : (closure$__186-5.$VB$NonLocal_$VB$Closure_3.$I8 = [SpecialName] (Aircraft aircraft) => ((aircraft.DBID == closure$__186-5.$VB$NonLocal_$VB$Closure_3.$VB$NonLocal_$VB$Closure_2.$VB$Local_MissionDBID) & !Information.IsNothing((object)aircraft.AirOps.CurrentHostUnit)) && aircraft.AirOps.CurrentHostUnit == closure$__186-5.$VB$NonLocal_$VB$Closure_3.$VB$Local_theAircraftHost));
							goto IL_0b79;
						}
						if (FlightGroupFilter != FlightGroupFilterOptions.Advanced)
						{
							goto IL_0b79;
						}
						closure$__186-6 = new _Closure$__186-6(closure$__186-6);
						closure$__186-6.$VB$NonLocal_$VB$Closure_4 = closure$__186-5;
						closure$__186-6.$VB$Local_GroupID = MissionPlanner.MostCommonGroup(list_3);
						if (closure$__186-6.$VB$Local_GroupID != -99)
						{
							enumerable2 = list_3.Where(closure$__186-6._Lambda$__9);
							goto IL_0b79;
						}
						if (bool_10)
						{
							SendMessageBoxToUI("No Group rule is defined for the assigned aircraft.", side_0);
						}
						goto end_IL_0001;
						IL_0b79:
						if (enumerable2.Count() > 0)
						{
							if ((enumerable2.Count() >= _FlightSize_0 || !bool_2) && !flag)
							{
								if (!(_FlightSize_0 > 1))
								{
									int num10 = 0;
									foreach (Aircraft item9 in enumerable2)
									{
										Aircraft aircraft_ = item9;
										if (bool_5)
										{
											list_8.Add(aircraft_);
										}
										if (!bool_5)
										{
											if (mission_0.MasterFlightList.Count > 0)
											{
												smethod_26(ref scenario_0, ref side_0, ref mission_0, ref aircraft_, ref list_12, ref bool_4, ref _FlightSize_0, ref nullable_0, ref string_6, ref float_2, ref float_3, ref bool_5, bool_3: false, bool_8, bool_9, ref flight_0);
												num10++;
											}
											else
											{
												smethod_27(ref scenario_0, ref mission_0, ref aircraft_, ref list_12, ref _FlightSize_0, ref bool_5, bool_2: false, bool_8, bool_9, ref flight_0);
												num10++;
											}
										}
										else if (mission_0.MasterFlightList.Count > 0)
										{
											smethod_26(ref scenario_0, ref side_0, ref mission_0, ref aircraft_, ref list_12, ref bool_4, ref _FlightSize_0, ref nullable_0, ref string_6, ref float_2, ref float_3, ref bool_5, bool_3: false, bool_8, bool_9, ref flight_0);
											num10++;
										}
										else
										{
											smethod_27(ref scenario_0, ref mission_0, ref aircraft_, ref list_12, ref _FlightSize_0, ref bool_5, bool_2: false, bool_8, bool_9, ref flight_0);
											num10++;
										}
										if (mission_0.MissionClass == Mission._MissionClass.Strike)
										{
											int num11 = Mission.FlightQty_To_ActualFlightQty(ref ((Strike)mission_0).MaxFlightNumber_Strike);
											if (num11 == 0)
											{
												num11 = int.MaxValue;
											}
											if (mission_0.FlightList.Count >= num11 || num10 >= enumerable2.Count())
											{
												break;
											}
										}
										num8++;
										if (mission_0.MissionClass == Mission._MissionClass.Strike && int_1 > 0 && num8 >= int_1)
										{
											flag = true;
											break;
										}
									}
								}
								else
								{
									int num12 = enumerable2.Count();
									while (true)
									{
										if (!bool_2)
										{
											if (num12 == 0)
											{
												break;
											}
										}
										else
										{
											if (mission_0.MissionClass == Mission._MissionClass.Strike && mission_0.MaximumFlighstQty_To_MaximumFlightsQtySelection((int)((Strike)mission_0).MaxFlightNumber_Strike, isNonShooter: false) != 0)
											{
												int num13 = mission_0.FlightList.Where([SpecialName] (Mission.Flight theF) => theF.IsEscort).Count();
												int num14 = 0;
												foreach (Mission.Flight flight2 in mission_0.FlightList)
												{
													if (!flight2.Departed)
													{
														foreach (ActiveUnit unit in side_0.Units)
														{
															if (unit.IsAircraft && unit.ActiveMissionOrPackage() != null && Operators.CompareString(unit.ActiveMissionOrPackage().ObjectID, mission_0.ObjectID, false) == 0 && unit.Navigator.get_Flight(HierarchySearch: true) != null && Operators.CompareString(unit.Navigator.get_Flight(HierarchySearch: true).ObjectID, flight2.ObjectID, false) == 0 && !(((Aircraft)unit).AirborneTime <= 0f))
															{
																flight2.Departed = true;
																break;
															}
														}
													}
													if (flight2.Departed)
													{
														foreach (ActiveUnit unit2 in side_0.Units)
														{
															flight2.Landed = true;
															if (unit2.IsAircraft && unit2.ActiveMissionOrPackage() != null && Operators.CompareString(unit2.ActiveMissionOrPackage().ObjectID, mission_0.ObjectID, false) == 0 && unit2.Navigator.get_Flight(HierarchySearch: true) != null && Operators.CompareString(unit2.Navigator.get_Flight(HierarchySearch: true).ObjectID, flight2.ObjectID, false) == 0)
															{
																flight2.Landed = false;
																break;
															}
														}
													}
													if (!flight2.Landed)
													{
														num14++;
													}
												}
												num14 -= num13;
												if (num14 >= mission_0.MaximumFlighstQty_To_MaximumFlightsQtySelection((int)((Strike)mission_0).MaxFlightNumber_Strike, isNonShooter: false))
												{
													break;
												}
											}
											if (num12 < _FlightSize_0)
											{
												break;
											}
										}
										List<ActiveUnit> list_13 = new List<ActiveUnit>();
										int num15 = _FlightSize_0;
										for (int num16 = 1; num16 <= num15; num16++)
										{
											if (num9 >= enumerable2.Count())
											{
												break;
											}
											if (!Information.IsNothing((object)enumerable2.ElementAtOrDefault(num9)))
											{
												list_13.Add(enumerable2.ElementAtOrDefault(num9));
												if (bool_5)
												{
													list_8.Add(enumerable2.ElementAtOrDefault(num9));
												}
												num8++;
												num12--;
												num9++;
											}
										}
										if (!bool_5)
										{
											if (mission_0.MasterFlightList.Count > 0 && list_13.Count > 0)
											{
												Group group_ = null;
												smethod_25(ref scenario_0, ref side_0, ref mission_0, ref list_13, ref group_, ref list_12, ref bool_4, ref _FlightSize_0, ref nullable_0, ref string_6, ref float_2, ref float_3, ref bool_5, bool_3: false, bool_8, bool_9, ref flight_0);
											}
											else
											{
												Group group_ = null;
												smethod_23(ref scenario_0, ref mission_0, ref list_13, ref group_, ref list_12, ref _FlightSize_0, ref bool_5, bool_2: false, bool_8, bool_9, ref flight_0);
											}
										}
										else
										{
											Group group_2 = new Group(ref scenario_0, ref side_0, list_13, UsingMissionPlanner: false, null, mission_0);
											list_7.Add(group_2);
											if (mission_0.MasterFlightList.Count > 0)
											{
												smethod_25(ref scenario_0, ref side_0, ref mission_0, ref list_13, ref group_2, ref list_12, ref bool_4, ref _FlightSize_0, ref nullable_0, ref string_6, ref float_2, ref float_3, ref bool_5, bool_3: false, bool_8, bool_9, ref flight_0);
											}
											else
											{
												smethod_23(ref scenario_0, ref mission_0, ref list_13, ref group_2, ref list_12, ref _FlightSize_0, ref bool_5, bool_2: false, bool_8, bool_9, ref flight_0);
											}
										}
									}
								}
							}
							else if (enumerable2.Count() < _FlightSize_0 && !flag)
							{
								if (mission_0.TimeSincePlayerNotification == 1 || bool_10)
								{
									if (mission_0.Category == Mission.MissionCategory.Mission)
									{
										scenario_0.AddMessage("Mission " + mission_0.Name + ", aircraft type " + enumerable2.ElementAtOrDefault(0).UnitClass + " with loadout " + enumerable2.ElementAtOrDefault(0).LoadoutName + " on host " + closure$__186-5.$VB$NonLocal_$VB$Closure_3.$VB$Local_theAircraftHost.Name + " cannot launch. When divided by base/ship, aircraft type and loadout, there isn't enough aircraft to create the minimum number of flights. Possible solutions would be to add more strike aircraft and/or escorts, load aircraft with identical loadouts, or use aircraft from the same base/ship. Alternatively, re-configure the mission and reduce the minimum number of required strike aircraft and/or escorts, or reduce the flight size.", mission_0.Name + " cannot launch", LoggedMessage.MessageType.AirOps, 0, null, side_0, new Geopoint_Struct(closure$__186-5.$VB$NonLocal_$VB$Closure_3.$VB$Local_theAircraftHost.get_Longitude((GlobalVariables.BooleanObject)null), closure$__186-5.$VB$NonLocal_$VB$Closure_3.$VB$Local_theAircraftHost.get_Latitude((GlobalVariables.BooleanObject)null)));
									}
									else
									{
										scenario_0.AddMessage(mission_0.Name + ", aircraft type " + enumerable2.ElementAtOrDefault(0).UnitClass + " with loadout " + enumerable2.ElementAtOrDefault(0).LoadoutName + " on host " + closure$__186-5.$VB$NonLocal_$VB$Closure_3.$VB$Local_theAircraftHost.Name + " has problems. One or more aircraft has not been assigned to a flight, and the aircraft will not launch. Possible solutions would be to remove the aircraft from the package, change the flight size, or manually create the flight.", mission_0.Name + " cannot launch", LoggedMessage.MessageType.AirOps, 0, null, side_0, new Geopoint_Struct(closure$__186-5.$VB$NonLocal_$VB$Closure_3.$VB$Local_theAircraftHost.get_Longitude((GlobalVariables.BooleanObject)null), closure$__186-5.$VB$NonLocal_$VB$Closure_3.$VB$Local_theAircraftHost.get_Latitude((GlobalVariables.BooleanObject)null)));
									}
								}
								if (bool_10)
								{
									if (mission_0.Category != Mission.MissionCategory.Mission)
									{
										SendMessageBoxToUI(mission_0.Name + ", aircraft type " + enumerable2.ElementAtOrDefault(0).UnitClass + " with loadout " + enumerable2.ElementAtOrDefault(0).LoadoutName + " on host " + closure$__186-5.$VB$NonLocal_$VB$Closure_3.$VB$Local_theAircraftHost.Name + " has problems. One or more aircraft has not been assigned to a flight, and the aircraft will not launch. Possible solutions would be to remove the aircraft from the package, change the flight size, or manually create the flight.", side_0);
									}
									else
									{
										SendMessageBoxToUI("Mission " + mission_0.Name + ", aircraft type " + enumerable2.ElementAtOrDefault(0).UnitClass + " with loadout " + enumerable2.ElementAtOrDefault(0).LoadoutName + " on host " + closure$__186-5.$VB$NonLocal_$VB$Closure_3.$VB$Local_theAircraftHost.Name + " cannot launch. When divided by base/ship, aircraft type and loadout, there isn't enough aircraft to create the minimum number of flights. Possible solutions would be to add more strike aircraft and/or escorts, load aircraft with identical loadouts, or use aircraft from the same base/ship. Alternatively, re-configure the mission and reduce the minimum number of required strike aircraft and/or escorts, or reduce the flight size.", side_0);
									}
								}
							}
						}
						if (FlightGroupFilter != FlightGroupFilterOptions.Equipment)
						{
							break;
						}
					}
				}
			}
			else
			{
				List<List<Aircraft>> list3 = new List<List<Aircraft>>();
				using (List<ActiveUnit>.Enumerator enumerator17 = list_11.GetEnumerator())
				{
					_Closure$__186-0 closure$__186-7 = default(_Closure$__186-0);
					_Closure$__186-1 closure$__186-9 = default(_Closure$__186-1);
					_Closure$__186-2 closure$__186-8 = default(_Closure$__186-2);
					while (enumerator17.MoveNext())
					{
						closure$__186-7 = new _Closure$__186-0(closure$__186-7);
						closure$__186-7.$VB$Local_theAircraftHost = enumerator17.Current;
						if (flag)
						{
							break;
						}
						List<Aircraft> list4 = list_3.Where(closure$__186-7._Lambda$__2).ToList();
						if (list4.Count == 0)
						{
							continue;
						}
						switch (mission_0.OneThirdGrouping)
						{
						case Mission.OneThirdGroupingType.ByLoadout:
						{
							using (List<int>.Enumerator enumerator19 = list_6.GetEnumerator())
							{
								while (enumerator19.MoveNext())
								{
									closure$__186-9 = new _Closure$__186-1(closure$__186-9);
									closure$__186-9.$VB$Local_dbid = enumerator19.Current;
									List<Aircraft> list6 = list4.Where(closure$__186-9._Lambda$__3).ToList();
									if (list6.Any())
									{
										list3.Add(list6);
									}
								}
							}
							break;
						}
						case Mission.OneThirdGroupingType.ByUnitClass:
						{
							using (List<int>.Enumerator enumerator18 = list2.GetEnumerator())
							{
								while (enumerator18.MoveNext())
								{
									closure$__186-8 = new _Closure$__186-2(closure$__186-8);
									closure$__186-8.$VB$Local_dbid = enumerator18.Current;
									List<Aircraft> list5 = list4.Where(closure$__186-8._Lambda$__4).ToList();
									if (list5.Any())
									{
										list3.Add(list5);
									}
								}
							}
							break;
						}
						case Mission.OneThirdGroupingType.NoGrouping:
							list3.Add(list4);
							break;
						}
					}
				}
				foreach (List<Aircraft> item10 in list3)
				{
					IEnumerable<IGrouping<Aircraft_AirOps._AirOpsCondition, Aircraft>> enumerable3 = from ac in item10
						group ac by ac.AirOps.Condition;
					foreach (IGrouping<Aircraft_AirOps._AirOpsCondition, Aircraft> item11 in enumerable3)
					{
						if (!bool_2 || !(item11.Count() < _FlightSize_0))
						{
							if (flag)
							{
								break;
							}
							if (item11.Count() < _FlightSize_0 && bool_2)
							{
								continue;
							}
							if (_FlightSize_0 > 1)
							{
								int num17 = 0;
								while (num17 < item11.Count() && (!bool_2 || !(item11.Count() - num17 < _FlightSize_0)))
								{
									List<ActiveUnit> list_14 = new List<ActiveUnit>();
									int num18 = _FlightSize_0;
									for (int num19 = 1; num19 <= num18; num19++)
									{
										if (num17 >= item11.Count())
										{
											break;
										}
										Aircraft item3 = item11.ElementAtOrDefault(num17);
										list_14.Add(item3);
										if (bool_5)
										{
											list_8.Add(item3);
										}
										num8++;
										num17++;
									}
									if (list_14.Count == 0)
									{
										break;
									}
									Group group_3 = null;
									if (bool_5)
									{
										group_3 = new Group(ref scenario_0, ref side_0, list_14, UsingMissionPlanner: false, null, mission_0);
										list_7.Add(group_3);
									}
									if (mission_0.MasterFlightList.Count > 0)
									{
										smethod_25(ref scenario_0, ref side_0, ref mission_0, ref list_14, ref group_3, ref list_12, ref bool_4, ref _FlightSize_0, ref nullable_0, ref string_6, ref float_2, ref float_3, ref bool_5, bool_3: false, bool_8, bool_9, ref flight_0);
									}
									else
									{
										smethod_23(ref scenario_0, ref mission_0, ref list_14, ref group_3, ref list_12, ref _FlightSize_0, ref bool_5, bool_2: false, bool_8, bool_9, ref flight_0);
									}
								}
								continue;
							}
							foreach (Aircraft item12 in item11)
							{
								Aircraft aircraft_2 = item12;
								if (bool_5)
								{
									list_8.Add(aircraft_2);
								}
								if (mission_0.MasterFlightList.Count > 0)
								{
									smethod_26(ref scenario_0, ref side_0, ref mission_0, ref aircraft_2, ref list_12, ref bool_4, ref _FlightSize_0, ref nullable_0, ref string_6, ref float_2, ref float_3, ref bool_5, bool_3: false, bool_8, bool_9, ref flight_0);
								}
								else
								{
									smethod_27(ref scenario_0, ref mission_0, ref aircraft_2, ref list_12, ref _FlightSize_0, ref bool_5, bool_2: false, bool_8, bool_9, ref flight_0);
								}
								num8++;
							}
							continue;
						}
						int num20;
						if (bool_10)
						{
							SendMessageBoxToUI("There are not enough aircraft in the same operational status for creating a coherent group, check aircraft status or 1/3 rule", side_0);
							num20 = 0;
						}
						else
						{
							scenario_0.AddMessage("Mission " + mission_0.Name + " does not have enough aircraft in the same operational state to create a coherent group, check aircraft status or 1/3 rule", mission_0.Name + " cannot launch", LoggedMessage.MessageType.AirOps, 0, null, side_0);
							num20 = 0;
						}
						result = (byte)num20 != 0;
						goto end_IL_0001;
					}
				}
			}
			DateTime dateTime = DateTime.MinValue;
			string text = "";
			DateTime? dateTime2 = default(DateTime?);
			if (mission_0.StartTime.HasValue || mission_0.TakeOffTime.HasValue)
			{
				if (!mission_0.TakeOffTime.HasValue)
				{
					dateTime2 = mission_0.StartTime.Value;
					text = "Start Time";
				}
				else
				{
					dateTime2 = mission_0.TakeOffTime.Value;
					text = "Take Off Time";
				}
			}
			foreach (Aircraft item13 in list_2)
			{
				if (dateTime2.HasValue)
				{
					DateTime t = scenario_0.Time.AddSeconds(item13.AirOps.ConditionTimer);
					if (DateTime.Compare(t, dateTime2.Value) > 0 && DateTime.Compare(t, dateTime) > 0)
					{
						dateTime = scenario_0.Time.AddSeconds(item13.AirOps.ConditionTimer);
					}
				}
			}
			bool? obj2 = (dateTime2.HasValue ? new bool?(DateTime.Compare(dateTime, dateTime2.GetValueOrDefault()) > 0) : ((bool?)null));
			int num21;
			if ((PlanningMission & obj2) != true)
			{
				num21 = 1;
			}
			else if (!bool_10)
			{
				scenario_0.AddMessage("One or more aircraft(s) from mission: " + mission_0.Name + " flying at " + dateTime2.Value.ToString("yyyy-MM-dd HH:mm:ss") + " will be ready after " + text, "Aircraft Readying for " + mission_0.Name, LoggedMessage.MessageType.AirOps, 0, null, side_0);
				num21 = 1;
			}
			else
			{
				DarkMessageBox.ShowWarning("One or more aircraft(s) from mission: " + mission_0.Name + " flying at " + dateTime2.Value.ToString("yyyy-MM-dd HH:mm:ss") + " will be ready after " + text, "Aircraft Readying");
				num21 = 1;
			}
			bool flag2 = (byte)num21 != 0;
			if (bool_3 && ((int_3 == 0) & (int_5 == 0)))
			{
				flag2 = false;
			}
			if (flag2 & !Information.IsNothing((object)list_8))
			{
				int num22;
				if (list_8.Count <= 0 && !bool_6)
				{
					if (!bool_7)
					{
						goto IL_1aa6;
					}
					num22 = 0;
				}
				else
				{
					num22 = 0;
				}
				int num23 = num22;
				int num24 = 0;
				bool flag3 = false;
				bool flag4 = false;
				using List<ActiveUnit>.Enumerator enumerator24 = list_11.GetEnumerator();
				_Closure$__186-8 closure$__186-10 = default(_Closure$__186-8);
				_Closure$__186-7 closure$__186-11 = default(_Closure$__186-7);
				while (enumerator24.MoveNext())
				{
					closure$__186-10 = new _Closure$__186-8(closure$__186-10);
					closure$__186-10.$VB$Local_theAircraftHost = enumerator24.Current;
					if (flag3 && flag4)
					{
						break;
					}
					using List<int>.Enumerator enumerator25 = list_6.GetEnumerator();
					while (enumerator25.MoveNext())
					{
						closure$__186-11 = new _Closure$__186-7(closure$__186-11);
						closure$__186-11.$VB$NonLocal_$VB$Closure_5 = closure$__186-10;
						closure$__186-11.$VB$Local_theLoadoutDBID = enumerator25.Current;
						int num25;
						if (!flag3)
						{
							num25 = 0;
						}
						else
						{
							if (flag4)
							{
								break;
							}
							num25 = 0;
						}
						int num26 = num25;
						List<Aircraft> list7;
						List<Aircraft> list8;
						int num27;
						if (!(_FlightSize_2 == 0))
						{
							list7 = list_4.Where(closure$__186-11._Lambda$__12).ToList();
							list8 = list_5.Where(closure$__186-11._Lambda$__13).ToList();
							num27 = 0;
						}
						else
						{
							list7 = list_4.Where(closure$__186-11._Lambda$__11).ToList();
							list8 = null;
							num27 = 0;
						}
						bool flag5 = (byte)num27 != 0;
						if (!Information.IsNothing((object)list7) && list7.Count > 0 && !bool_3)
						{
							flag5 = true;
						}
						else if (list7.Count >= _FlightSize_1 && !flag3)
						{
							flag5 = true;
						}
						if (flag5)
						{
							if (!(_FlightSize_1 > 1))
							{
								foreach (Aircraft item14 in list7)
								{
									Aircraft aircraft_3 = item14;
									if (bool_5)
									{
										list_9.Add(aircraft_3);
									}
									num23++;
									num8++;
									if (!bool_5)
									{
										Mission.Flight flight_1 = null;
										smethod_27(ref scenario_0, ref mission_0, ref aircraft_3, ref list_12, ref _FlightSize_1, ref bool_5, bool_2: true, bool_8, bool_4: false, ref flight_1);
									}
									else
									{
										Mission.Flight flight_1 = null;
										smethod_27(ref scenario_0, ref mission_0, ref aircraft_3, ref list_12, ref _FlightSize_1, ref bool_5, bool_2: true, bool_8, bool_4: false, ref flight_1);
									}
									if (int_3 > 0 && num23 >= int_3)
									{
										break;
									}
								}
							}
							else
							{
								int num28 = list7.Count;
								while (true)
								{
									if (!bool_3)
									{
										if (num28 == 0)
										{
											break;
										}
									}
									else if (num28 < _FlightSize_1)
									{
										break;
									}
									List<ActiveUnit> list_15 = new List<ActiveUnit>();
									int num29 = _FlightSize_1;
									for (int num30 = 1; num30 <= num29; num30++)
									{
										if (num26 >= list7.Count)
										{
											break;
										}
										if (!Information.IsNothing((object)list7[num26]))
										{
											list_15.Add(list7[num26]);
											if (bool_5)
											{
												list_9.Add(list7[num26]);
											}
											num23++;
											num28--;
											num26++;
										}
									}
									if (bool_5)
									{
										Group group_4 = new Group(ref scenario_0, ref side_0, list_15, UsingMissionPlanner: false, null, mission_0);
										list_7.Add(group_4);
										Mission.Flight flight_1 = null;
										smethod_23(ref scenario_0, ref mission_0, ref list_15, ref group_4, ref list_12, ref _FlightSize_1, ref bool_5, bool_2: true, bool_8, bool_4: false, ref flight_1);
									}
									else
									{
										Group group_ = null;
										Mission.Flight flight_1 = null;
										smethod_23(ref scenario_0, ref mission_0, ref list_15, ref group_, ref list_12, ref _FlightSize_1, ref bool_5, bool_2: true, bool_8, bool_4: false, ref flight_1);
									}
									if (mission_0.MissionClass == Mission._MissionClass.Strike && int_3 > 0 && num23 >= int_3)
									{
										flag3 = true;
										break;
									}
								}
							}
						}
						if (!Information.IsNothing((object)list8) && list8.Count > 0 && (!bool_3 || list8.Count >= _FlightSize_2) && !flag4 && !(_FlightSize_2 > 1))
						{
							foreach (Aircraft item15 in list8)
							{
								Aircraft aircraft_4 = item15;
								if (bool_5)
								{
									list_10.Add(aircraft_4);
								}
								num24++;
								num8++;
								if (bool_5)
								{
									Mission.Flight flight_1 = null;
									smethod_27(ref scenario_0, ref mission_0, ref aircraft_4, ref list_12, ref _FlightSize_2, ref bool_5, bool_2: true, bool_8, bool_4: false, ref flight_1);
								}
								else
								{
									Mission.Flight flight_1 = null;
									smethod_27(ref scenario_0, ref mission_0, ref aircraft_4, ref list_12, ref _FlightSize_2, ref bool_5, bool_2: true, bool_8, bool_4: false, ref flight_1);
								}
								if (int_5 > 0 && num24 >= int_5)
								{
									break;
								}
							}
						}
						if (FlightGroupFilter != FlightGroupFilterOptions.Equipment)
						{
							break;
						}
					}
				}
			}
			goto IL_1aa6;
			IL_0519:
			num3 = 0;
			goto IL_051a;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999934563456333939", "");
			WriteExceptionsToLog(ex2);
			int num31;
			if (!Debugger.IsAttached)
			{
				num31 = 0;
			}
			else
			{
				Debugger.Break();
				num31 = 0;
			}
			result = (byte)num31 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private static void smethod_23(ref Scenario scenario_0, ref Mission mission_0, ref List<ActiveUnit> list_2, ref Group group_0, ref List<Aircraft> list_3, ref Mission._FlightSize _FlightSize_0, ref bool bool_1, bool bool_2, bool bool_3, bool bool_4, ref Mission.Flight flight_0)
	{
		try
		{
			Aircraft theReferenceUnit = (Aircraft)list_2[0];
			Mission.Flight theFlightPlan = null;
			Mission.Flight theF = new Mission.Flight(ref scenario_0, ref mission_0, ref theFlightPlan, Callsigns.FetchCallsignBasedOnMissionType(ref mission_0), null, theReferenceUnit, _FlightSize_0, bool_2);
			if (mission_0.MissionClass == Mission._MissionClass.Strike)
			{
				if (list_2.Count > 0)
				{
					theF.PrimaryTarget = list_2[0].AI.PrimaryTarget;
				}
				int num = mission_0.FlightList.Where([SpecialName] (Mission.Flight flight) => flight.IsEscort).Count();
				if (mission_0.MaximumFlighstQty_To_MaximumFlightsQtySelection((int)((Strike)mission_0).MaxFlightNumber_Strike, isNonShooter: false) != 0)
				{
					int num2 = mission_0.FlightList.Count - num;
					if (!bool_2 && num2 >= mission_0.MaximumFlighstQty_To_MaximumFlightsQtySelection((int)((Strike)mission_0).MaxFlightNumber_Strike, isNonShooter: false))
					{
						return;
					}
				}
			}
			mission_0.AddFlight(ref theF);
			int num3 = 2;
			if (!bool_1)
			{
				foreach (ActiveUnit item in list_2)
				{
					if (!list_3.Contains((Aircraft)item))
					{
						item.SetFlight(theF, num3);
						num3++;
					}
					else
					{
						if (Information.IsNothing((object)mission_0.EmptySlotsList))
						{
							continue;
						}
						foreach (Mission.EmptyAircraftSlot emptySlots in mission_0.EmptySlotsList)
						{
							if (!Information.IsNothing((object)emptySlots.get_ReferenceUnit(scenario_0, (Mission)null)) && emptySlots.get_ReferenceUnit(scenario_0, (Mission)null) == item)
							{
								emptySlots.SetFlight(scenario_0, theF, num3);
								num3++;
								break;
							}
						}
					}
				}
			}
			else
			{
				foreach (ActiveUnit value in group_0.Units.Values)
				{
					if (value.IsGroupLead())
					{
						value.SetFlight(theF, 1);
						group_0.Name = "Flight " + theF.Callsign;
					}
					else
					{
						value.SetFlight(theF, num3);
						num3++;
					}
				}
			}
			if (bool_4)
			{
				flight_0 = theF;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 3334564357354356346", "");
			WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static bool smethod_24(object object_0, Mission.Flight flight_0)
	{
		bool flag = true;
		if (FlightGroupFilter == FlightGroupFilterOptions.Equipment)
		{
			return ((Aircraft)object_0).LoadoutDBID == flight_0.int_1;
		}
		if (FlightGroupFilter == FlightGroupFilterOptions.Aircraft)
		{
			return ((ActiveUnit)object_0).DBID == flight_0.ReferenceUnit_DBID;
		}
		if (FlightGroupFilter == FlightGroupFilterOptions.Advanced)
		{
			return MissionPlanner.CheckAdvancedGroupCompatibility(((ActiveUnit)object_0).DBID, ((Aircraft)object_0).LoadoutDBID, flight_0.ReferenceUnit_DBID, ((Aircraft)flight_0.get_ReferenceUnit(((ActiveUnit)object_0).ParentScen)).LoadoutDBID);
		}
		return true;
	}

	private static void smethod_25(ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, ref List<ActiveUnit> list_2, ref Group group_0, ref List<Aircraft> list_3, ref bool bool_1, ref Mission._FlightSize _FlightSize_0, ref Doctrine._UseUnderwayRefuelAndReplenishment? nullable_0, ref string string_6, ref float float_2, ref float float_3, ref bool bool_2, bool bool_3, bool bool_4, bool bool_5, ref Mission.Flight flight_0)
	{
		try
		{
			Mission.Flight NewFlight = new Mission.Flight();
			if (list_2.Count == 0)
			{
				return;
			}
			Aircraft aircraft = (Aircraft)list_2[0];
			List<Mission.Flight> list = new List<Mission.Flight>();
			foreach (Mission.Flight masterFlight in mission_0.MasterFlightList)
			{
				if (smethod_24(aircraft, masterFlight))
				{
					list.Add(masterFlight);
				}
			}
			if (list.Count > 1)
			{
				list = list.OrderBy([SpecialName] (Mission.Flight theF) => theF.UsedByFlightCount).ToList();
			}
			double StationStart_Lat = default(double);
			double StationStart_Lon = default(double);
			double StationEnd_Lat = default(double);
			double StationEnd_Lon = default(double);
			double StationStart_Lat2 = default(double);
			double StationStart_Lon2 = default(double);
			double StationEnd_Lat2 = default(double);
			double StationEnd_Lon2 = default(double);
			Strike strike2 = default(Strike);
			foreach (Mission.Flight item in list)
			{
				Mission.Flight OriginalFlight = item;
				if (!smethod_24(aircraft, OriginalFlight))
				{
					continue;
				}
				bool flag = false;
				if (Operators.CompareString(aircraft.AirOps.CurrentHostUnit.ObjectID, OriginalFlight.TakeOffLocation_HostUnitObjectID, false) != 0)
				{
					continue;
				}
				int EditedBy;
				int CreatedBy;
				if (OriginalFlight.FlightPlan_Pathfinder_Ingress_1.Count() == 0 && OriginalFlight.UsedByFlightCount != 0)
				{
					Mission.Flight flight = NewFlight;
					CreatedBy = 0;
					EditedBy = 0;
					flight.Copy(ref scenario_0, ref OriginalFlight, ref NewFlight, UseMissionSettings: false, ref mission_0, ref CreatedBy, ref EditedBy, AddEmptySlotsToMission: false, CopyErrors: false);
					OriginalFlight.UsedByFlightCount = 1;
					flag = true;
					NewFlight.AddMasterFlightPlanErrorsToFlightplanErrorList(ref scenario_0, ref OriginalFlight);
					int num;
					if (Information.IsNothing((object)OriginalFlight.NotificationList))
					{
						num = 2;
					}
					else
					{
						if (OriginalFlight.NotificationList.Count > 0)
						{
							ActiveUnit activeUnit = scenario_0.ActiveUnits[NewFlight.TakeOffLocation_HostUnitObjectID];
							foreach (string notification in OriginalFlight.NotificationList)
							{
								scenario_0.AddMessage(notification, OriginalFlight.Name + " notification", LoggedMessage.MessageType.AirOps, 0, "", side_0, new Geopoint_Struct(activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
							}
						}
						num = 2;
					}
					int num2 = num;
					foreach (ActiveUnit item2 in list_2)
					{
						if (bool_2)
						{
							if (Information.IsNothing((object)group_0))
							{
								continue;
							}
							foreach (ActiveUnit value in group_0.Units.Values)
							{
								if (value.IsGroupLead())
								{
									value.SetFlight(NewFlight, 1);
									group_0.Name = "Flight " + NewFlight.Callsign;
								}
								else
								{
									value.SetFlight(NewFlight, num2);
									num2++;
								}
							}
						}
						else if (!list_3.Contains((Aircraft)item2))
						{
							item2.SetFlight(NewFlight, num2);
							num2++;
						}
						else
						{
							if (Information.IsNothing((object)mission_0.EmptySlotsList))
							{
								continue;
							}
							foreach (Mission.EmptyAircraftSlot emptySlots in mission_0.EmptySlotsList)
							{
								if (!Information.IsNothing((object)emptySlots.get_ReferenceUnit(scenario_0, (Mission)null)) && emptySlots.get_ReferenceUnit(scenario_0, (Mission)null) == item2)
								{
									emptySlots.SetFlight(scenario_0, NewFlight, num2);
									num2++;
									break;
								}
							}
						}
					}
					if (bool_5)
					{
						flight_0 = NewFlight;
					}
				}
				if (!flag)
				{
					OriginalFlight.UsedByFlightCount++;
				}
				if (OriginalFlight.FlightPlan_Pathfinder_Ingress_1.Count() <= 0)
				{
					Mission.Flight theFlightPlan = null;
					NewFlight = new Mission.Flight(ref scenario_0, ref mission_0, ref theFlightPlan, Callsigns.FetchCallsignBasedOnMissionType(ref mission_0), OriginalFlight.PrimaryTarget, aircraft, _FlightSize_0, bool_3);
					if (mission_0.MissionClass != Mission._MissionClass.Strike)
					{
						if (mission_0.MissionClass == Mission._MissionClass.Patrol)
						{
							float StationLength_nm = 50f;
							if (!aircraft.Navigator.PlotCourseToStationArea_FlightplanGenerator(ref StationStart_Lat, ref StationStart_Lon, ref StationEnd_Lat, ref StationEnd_Lon, ref StationLength_nm))
							{
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								continue;
							}
							Aircraft_AI aI = aircraft.AI;
							Doctrine._UseUnderwayRefuelAndReplenishment? tankerUsage = nullable_0;
							bool launchMissionWithoutTankersInPlace = mission_0.LaunchMissionWithoutTankersInPlace;
							float FuelQtyRequired = 0f;
							aI.CanReachStation(ref NewFlight, tankerUsage, launchMissionWithoutTankersInPlace, AttemptPathfinderFlightPlan: false, SeparateIngressEgressPathfinderFlightPlans: false, AircraftIsAirborne: false, ref FuelQtyRequired, ref string_6, CallNavigatorImmediately: false, CreateFlightPlan: true, StationStart_Lat, StationStart_Lon, StationEnd_Lat, StationEnd_Lon, Waypoint.WaypointType.StationStart_Racetrack, Waypoint.TurnRateCategory.HalfStandardRateTurn, bool_4, mission_0.TakeOffTime, mission_0.TimeOnTarget, IsContinousCoverage: false, IsMFP: false);
						}
						else if (mission_0.MissionClass == Mission._MissionClass.Support)
						{
							float StationLength_nm2 = 50f;
							if (!aircraft.Navigator.PlotCourseToStationArea_FlightplanGenerator(ref StationStart_Lat2, ref StationStart_Lon2, ref StationEnd_Lat2, ref StationEnd_Lon2, ref StationLength_nm2))
							{
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								continue;
							}
							Aircraft_AI aI2 = aircraft.AI;
							Doctrine._UseUnderwayRefuelAndReplenishment? tankerUsage2 = nullable_0;
							bool launchMissionWithoutTankersInPlace2 = mission_0.LaunchMissionWithoutTankersInPlace;
							float FuelQtyRequired = 0f;
							aI2.CanReachStation(ref NewFlight, tankerUsage2, launchMissionWithoutTankersInPlace2, AttemptPathfinderFlightPlan: false, SeparateIngressEgressPathfinderFlightPlans: false, AircraftIsAirborne: false, ref FuelQtyRequired, ref string_6, CallNavigatorImmediately: false, CreateFlightPlan: true, StationStart_Lat2, StationStart_Lon2, StationEnd_Lat2, StationEnd_Lon2, Waypoint.WaypointType.StationStart_FigureEight, Waypoint.TurnRateCategory.FlatTurn, bool_4, mission_0.TakeOffTime, mission_0.TimeOnTarget, IsContinousCoverage: false, IsMFP: false);
						}
						else
						{
							Mission.Flight flight2 = NewFlight;
							int CreatedBy2 = 0;
							int EditedBy2 = 0;
							flight2.Copy(ref scenario_0, ref OriginalFlight, ref NewFlight, UseMissionSettings: false, ref mission_0, ref CreatedBy2, ref EditedBy2, AddEmptySlotsToMission: false, CopyErrors: false);
							NewFlight.AddMasterFlightPlanErrorsToFlightplanErrorList(ref scenario_0, ref OriginalFlight);
							if (!Information.IsNothing((object)OriginalFlight.NotificationList) && OriginalFlight.NotificationList.Count > 0)
							{
								ActiveUnit activeUnit2 = scenario_0.ActiveUnits[NewFlight.TakeOffLocation_HostUnitObjectID];
								foreach (string notification2 in OriginalFlight.NotificationList)
								{
									scenario_0.AddMessage(notification2, OriginalFlight.Name + " notification", LoggedMessage.MessageType.AirOps, 0, "", side_0, new Geopoint_Struct(activeUnit2.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit2.get_Latitude((GlobalVariables.BooleanObject)null)));
								}
							}
							int num3 = 1;
							foreach (ActiveUnit item3 in list_2)
							{
								if (!bool_2)
								{
									if (list_3.Contains((Aircraft)item3))
									{
										if (Information.IsNothing((object)mission_0.EmptySlotsList))
										{
											continue;
										}
										foreach (Mission.EmptyAircraftSlot emptySlots2 in mission_0.EmptySlotsList)
										{
											if (!Information.IsNothing((object)emptySlots2.get_ReferenceUnit(scenario_0, (Mission)null)) && emptySlots2.get_ReferenceUnit(scenario_0, (Mission)null) == item3)
											{
												emptySlots2.SetFlight(scenario_0, NewFlight, num3);
												num3++;
												break;
											}
										}
									}
									else
									{
										item3.SetFlight(NewFlight, num3);
										num3++;
									}
								}
								else
								{
									if (Information.IsNothing((object)group_0))
									{
										continue;
									}
									foreach (ActiveUnit value2 in group_0.Units.Values)
									{
										if (value2.IsGroupLead())
										{
											value2.SetFlight(NewFlight, 1);
											group_0.Name = "Flight " + NewFlight.Callsign;
										}
										else
										{
											value2.SetFlight(NewFlight, num3);
											num3++;
										}
									}
								}
							}
						}
					}
					else
					{
						Strike strike = (Strike)mission_0;
						Aircraft_AI aI3 = aircraft.AI;
						ref Contact primaryTarget = ref OriginalFlight.PrimaryTarget;
						int minResponseRadius_Aircraft = strike.MinResponseRadius_Aircraft;
						int maxResponseRadius_Aircraft = strike.MaxResponseRadius_Aircraft;
						Doctrine._UseUnderwayRefuelAndReplenishment? tankerUsage3 = nullable_0;
						bool launchMissionWithoutTankersInPlace3 = mission_0.LaunchMissionWithoutTankersInPlace;
						Mission._RadarBehaviour radarBehaviour = strike.RadarBehaviour;
						bool usePlanner = strike.UsePlanner;
						float FuelQtyRequired = 0f;
						aI3.CanReachTarget_Strike(ref scenario_0, ref side_0, ref mission_0, ref NewFlight, ref primaryTarget, minResponseRadius_Aircraft, maxResponseRadius_Aircraft, tankerUsage3, launchMissionWithoutTankersInPlace3, radarBehaviour, AttemptPathfinderFlightPlan: false, SeparateIngressEgressPathfinderFlightPlans: false, AircraftIsAirborne: false, usePlanner, ref FuelQtyRequired, ref string_6, CallNavigatorImmediately: false, ref bool_1, bool_1, ref float_2, ref float_3, CreateFlightPlan: true, null, bool_4, mission_0.TakeOffTime, mission_0.TimeOnTarget, IsContinousCoverage: false, IsMFP: false);
					}
					if (NewFlight.FlightPlan.Count() == 0)
					{
						Waypoint[] flightPlan = OriginalFlight.FlightPlan;
						for (int EditedBy2 = 0; EditedBy2 < flightPlan.Length; EditedBy2 = checked(EditedBy2 + 1))
						{
							Waypoint theOriginalWaypoint = flightPlan[EditedBy2];
							Mission.Flight flight3 = NewFlight;
							Waypoint[] theArray = flight3.FlightPlan;
							Doctrine FlightLeadDoctrine = null;
							ArrayExtensions.Add(ref theArray, Waypoint.CopyWaypoint(ref scenario_0, ref theOriginalWaypoint, CopyWingmanWaypoints: true, CopyFlightplanPointsList: true, ref FlightLeadDoctrine));
							flight3.FlightPlan = theArray;
						}
					}
					mission_0.AddFlight(ref NewFlight);
					int num4 = 2;
					if (!bool_2)
					{
						foreach (ActiveUnit item4 in list_2)
						{
							if (!list_3.Contains((Aircraft)item4))
							{
								item4.SetFlight(NewFlight, num4);
								num4++;
							}
							else
							{
								if (Information.IsNothing((object)mission_0.EmptySlotsList))
								{
									continue;
								}
								foreach (Mission.EmptyAircraftSlot emptySlots3 in mission_0.EmptySlotsList)
								{
									if (!Information.IsNothing((object)emptySlots3.get_ReferenceUnit(scenario_0, (Mission)null)) && emptySlots3.get_ReferenceUnit(scenario_0, (Mission)null) == item4)
									{
										emptySlots3.SetFlight(scenario_0, NewFlight, num4);
										num4++;
										break;
									}
								}
							}
						}
					}
					else
					{
						foreach (ActiveUnit value3 in group_0.Units.Values)
						{
							if (value3.IsGroupLead())
							{
								value3.SetFlight(NewFlight, 1);
								group_0.Name = "Flight " + NewFlight.Callsign;
							}
							else
							{
								value3.SetFlight(NewFlight, num4);
								num4++;
							}
						}
					}
					if (bool_5)
					{
						flight_0 = NewFlight;
					}
					break;
				}
				NewFlight = new Mission.Flight();
				Mission.Flight flight4 = NewFlight;
				EditedBy = 0;
				CreatedBy = 0;
				flight4.Copy(ref scenario_0, ref OriginalFlight, ref NewFlight, UseMissionSettings: false, ref mission_0, ref EditedBy, ref CreatedBy, AddEmptySlotsToMission: false, CopyErrors: false);
				NewFlight.AddMasterFlightPlanErrorsToFlightplanErrorList(ref scenario_0, ref OriginalFlight);
				if (!Information.IsNothing((object)OriginalFlight.NotificationList) && OriginalFlight.NotificationList.Count > 0)
				{
					ActiveUnit activeUnit3 = scenario_0.ActiveUnits[NewFlight.TakeOffLocation_HostUnitObjectID];
					foreach (string notification3 in OriginalFlight.NotificationList)
					{
						scenario_0.AddMessage(notification3, OriginalFlight.Name + " notification", LoggedMessage.MessageType.AirOps, 0, "", side_0, new Geopoint_Struct(activeUnit3.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit3.get_Latitude((GlobalVariables.BooleanObject)null)));
					}
				}
				if (mission_0.MissionClass == Mission._MissionClass.Strike)
				{
					strike2 = (Strike)mission_0;
					if (strike2.AttackMethod == Mission._AttackMethod.BananaSplit)
					{
						bool_1 = !bool_1;
					}
				}
				int num5;
				checked
				{
					if (mission_0.MissionClass == Mission._MissionClass.Strike && (Information.IsNothing((object)strike2) || (strike2.AttackMethod == Mission._AttackMethod.BananaSplit && !bool_1 && !Information.IsNothing((object)NewFlight.FlightPlan_Pathfinder_Ingress_2) && NewFlight.FlightPlan_Pathfinder_Ingress_2.Count() != 0)))
					{
						if (NewFlight.FlightPlan_Pathfinder_Ingress_2.Count() > 0 && NewFlight.FlightPlan.Count() == 0)
						{
							Waypoint[] flightPlan_Pathfinder_Ingress_ = NewFlight.FlightPlan_Pathfinder_Ingress_2;
							Waypoint[] flightPlan;
							for (EditedBy = 0; EditedBy < flightPlan_Pathfinder_Ingress_.Length; EditedBy++)
							{
								Waypoint theOriginalWaypoint2 = flightPlan_Pathfinder_Ingress_[EditedBy];
								Mission.Flight flight5 = NewFlight;
								flightPlan = flight5.FlightPlan;
								Doctrine FlightLeadDoctrine = null;
								ArrayExtensions.Add(ref flightPlan, Waypoint.CopyWaypoint(ref scenario_0, ref theOriginalWaypoint2, CopyWingmanWaypoints: true, CopyFlightplanPointsList: true, ref FlightLeadDoctrine));
								flight5.FlightPlan = flightPlan;
							}
							Mission.Flight flight6 = NewFlight;
							flightPlan = flight6.FlightPlan_Pathfinder_Ingress_2;
							ArrayExtensions.Clear(ref flightPlan);
							flight6.FlightPlan_Pathfinder_Ingress_2 = flightPlan;
							Mission.Flight flight7 = NewFlight;
							flightPlan = flight7.FlightPlan_Pathfinder_Egress_2;
							ArrayExtensions.Clear(ref flightPlan);
							flight7.FlightPlan_Pathfinder_Egress_2 = flightPlan;
							if (!Information.IsNothing((object)NewFlight.FlightPlan_Pathfinder_Ingress_1) || NewFlight.FlightPlan_Pathfinder_Ingress_1.Count() > 0)
							{
								Mission.Flight flight8 = NewFlight;
								flightPlan = flight8.FlightPlan_Pathfinder_Ingress_1;
								ArrayExtensions.Clear(ref flightPlan);
								flight8.FlightPlan_Pathfinder_Ingress_1 = flightPlan;
								Mission.Flight flight9 = NewFlight;
								flightPlan = flight9.FlightPlan_Pathfinder_Egress_1;
								ArrayExtensions.Clear(ref flightPlan);
								flight9.FlightPlan_Pathfinder_Egress_1 = flightPlan;
								num5 = 2;
								goto IL_0c46;
							}
						}
					}
					else if (NewFlight.FlightPlan_Pathfinder_Ingress_1.Count() > 0 && NewFlight.FlightPlan.Count() == 0)
					{
						Waypoint[] flightPlan_Pathfinder_Ingress_2 = NewFlight.FlightPlan_Pathfinder_Ingress_1;
						Waypoint[] flightPlan_Pathfinder_Ingress_;
						for (CreatedBy = 0; CreatedBy < flightPlan_Pathfinder_Ingress_2.Length; CreatedBy++)
						{
							Waypoint theOriginalWaypoint3 = flightPlan_Pathfinder_Ingress_2[CreatedBy];
							Mission.Flight flight10 = NewFlight;
							flightPlan_Pathfinder_Ingress_ = flight10.FlightPlan;
							Doctrine FlightLeadDoctrine = null;
							ArrayExtensions.Add(ref flightPlan_Pathfinder_Ingress_, Waypoint.CopyWaypoint(ref scenario_0, ref theOriginalWaypoint3, CopyWingmanWaypoints: true, CopyFlightplanPointsList: true, ref FlightLeadDoctrine));
							flight10.FlightPlan = flightPlan_Pathfinder_Ingress_;
						}
						Mission.Flight flight11 = NewFlight;
						flightPlan_Pathfinder_Ingress_ = flight11.FlightPlan_Pathfinder_Ingress_1;
						ArrayExtensions.Clear(ref flightPlan_Pathfinder_Ingress_);
						flight11.FlightPlan_Pathfinder_Ingress_1 = flightPlan_Pathfinder_Ingress_;
						Mission.Flight flight12 = NewFlight;
						flightPlan_Pathfinder_Ingress_ = flight12.FlightPlan_Pathfinder_Egress_1;
						ArrayExtensions.Clear(ref flightPlan_Pathfinder_Ingress_);
						flight12.FlightPlan_Pathfinder_Egress_1 = flightPlan_Pathfinder_Ingress_;
						if (!Information.IsNothing((object)NewFlight.FlightPlan_Pathfinder_Ingress_2) || NewFlight.FlightPlan_Pathfinder_Ingress_2.Count() > 0)
						{
							Mission.Flight flight13 = NewFlight;
							flightPlan_Pathfinder_Ingress_ = flight13.FlightPlan_Pathfinder_Ingress_2;
							ArrayExtensions.Clear(ref flightPlan_Pathfinder_Ingress_);
							flight13.FlightPlan_Pathfinder_Ingress_2 = flightPlan_Pathfinder_Ingress_;
							Mission.Flight flight14 = NewFlight;
							flightPlan_Pathfinder_Ingress_ = flight14.FlightPlan_Pathfinder_Egress_2;
							ArrayExtensions.Clear(ref flightPlan_Pathfinder_Ingress_);
							flight14.FlightPlan_Pathfinder_Egress_2 = flightPlan_Pathfinder_Ingress_;
							num5 = 2;
							goto IL_0c46;
						}
					}
					num5 = 2;
					goto IL_0c46;
				}
				IL_0c46:
				int num6 = num5;
				if (!bool_2)
				{
					foreach (ActiveUnit item5 in list_2)
					{
						if (!list_3.Contains((Aircraft)item5))
						{
							item5.SetFlight(NewFlight, num6);
							num6++;
						}
						else
						{
							if (Information.IsNothing((object)mission_0.EmptySlotsList))
							{
								continue;
							}
							foreach (Mission.EmptyAircraftSlot emptySlots4 in mission_0.EmptySlotsList)
							{
								if (!Information.IsNothing((object)emptySlots4.get_ReferenceUnit(scenario_0, (Mission)null)) && emptySlots4.get_ReferenceUnit(scenario_0, (Mission)null) == item5)
								{
									emptySlots4.SetFlight(scenario_0, NewFlight, num6);
									num6++;
									break;
								}
							}
						}
					}
				}
				else
				{
					foreach (ActiveUnit value4 in group_0.Units.Values)
					{
						if (value4.IsGroupLead())
						{
							value4.SetFlight(NewFlight, 1);
							group_0.Name = "Flight " + NewFlight.Callsign;
						}
						else
						{
							value4.SetFlight(NewFlight, num6);
							num6++;
						}
					}
				}
				if (bool_5)
				{
					flight_0 = NewFlight;
				}
				break;
			}
			List<Mission.Flight> list2 = new List<Mission.Flight>();
			foreach (Mission.Flight flight15 in mission_0.FlightList)
			{
				bool flag2 = false;
				foreach (KeyValuePair<ActiveUnit, ActiveUnit> item6 in mission_0.UnitsAssignedToMission)
				{
					if (item6.Value.Navigator.HasFlight && Operators.CompareString(item6.Value.Navigator.get_Flight(HierarchySearch: true).Callsign, flight15.Callsign, false) == 0)
					{
						flag2 = true;
					}
				}
				if (!flag2)
				{
					list2.Add(flight15);
				}
			}
			foreach (Mission.Flight item7 in list2)
			{
				mission_0.RemoveFlight(item7);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 54656546524", "");
			WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void smethod_26(ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, ref Aircraft aircraft_0, ref List<Aircraft> list_2, ref bool bool_1, ref Mission._FlightSize _FlightSize_0, ref Doctrine._UseUnderwayRefuelAndReplenishment? nullable_0, ref string string_6, ref float float_2, ref float float_3, ref bool bool_2, bool bool_3, bool bool_4, bool bool_5, ref Mission.Flight flight_0)
	{
		try
		{
			Mission.Flight NewFlight = new Mission.Flight();
			List<Mission.Flight> list = new List<Mission.Flight>();
			foreach (Mission.Flight masterFlight in mission_0.MasterFlightList)
			{
				if (aircraft_0.LoadoutDBID == masterFlight.int_1)
				{
					list.Add(masterFlight);
				}
			}
			if (list.Count > 1)
			{
				list = list.OrderBy([SpecialName] (Mission.Flight theF) => theF.UsedByFlightCount).ToList();
			}
			double StationStart_Lat = default(double);
			double StationStart_Lon = default(double);
			double StationEnd_Lat = default(double);
			double StationEnd_Lon = default(double);
			double StationStart_Lat2 = default(double);
			double StationStart_Lon2 = default(double);
			double StationEnd_Lat2 = default(double);
			double StationEnd_Lon2 = default(double);
			foreach (Mission.Flight item in list)
			{
				Mission.Flight OriginalFlight = item;
				if (aircraft_0.LoadoutDBID != OriginalFlight.int_1 || Operators.CompareString(aircraft_0.AirOps.CurrentHostUnit.ObjectID, OriginalFlight.TakeOffLocation_HostUnitObjectID, false) != 0)
				{
					continue;
				}
				bool flag = false;
				int EditedBy2;
				int CreatedBy;
				if (OriginalFlight.FlightPlan_Pathfinder_Ingress_1.Count() != 0 || OriginalFlight.UsedByFlightCount != 0)
				{
					if (!flag)
					{
						OriginalFlight.UsedByFlightCount++;
					}
					checked
					{
						if (OriginalFlight.FlightPlan_Pathfinder_Ingress_1.Count() <= 0)
						{
							Mission.Flight theFlightPlan = null;
							NewFlight = new Mission.Flight(ref scenario_0, ref mission_0, ref theFlightPlan, Callsigns.FetchCallsignBasedOnMissionType(ref mission_0), OriginalFlight.PrimaryTarget, aircraft_0, _FlightSize_0, bool_3);
							if (mission_0.MissionClass != Mission._MissionClass.Strike)
							{
								if (mission_0.MissionClass == Mission._MissionClass.Patrol)
								{
									float StationLength_nm = 50f;
									if (!aircraft_0.Navigator.PlotCourseToStationArea_FlightplanGenerator(ref StationStart_Lat, ref StationStart_Lon, ref StationEnd_Lat, ref StationEnd_Lon, ref StationLength_nm))
									{
										if (Debugger.IsAttached)
										{
											Debugger.Break();
										}
										continue;
									}
									Aircraft_AI aI = aircraft_0.AI;
									Doctrine._UseUnderwayRefuelAndReplenishment? tankerUsage = nullable_0;
									bool launchMissionWithoutTankersInPlace = mission_0.LaunchMissionWithoutTankersInPlace;
									float FuelQtyRequired = 0f;
									aI.CanReachStation(ref NewFlight, tankerUsage, launchMissionWithoutTankersInPlace, AttemptPathfinderFlightPlan: false, SeparateIngressEgressPathfinderFlightPlans: false, AircraftIsAirborne: false, ref FuelQtyRequired, ref string_6, CallNavigatorImmediately: false, CreateFlightPlan: true, StationStart_Lat, StationStart_Lon, StationEnd_Lat, StationEnd_Lon, Waypoint.WaypointType.StationStart_Racetrack, Waypoint.TurnRateCategory.HalfStandardRateTurn, bool_4, mission_0.TakeOffTime, mission_0.TimeOnTarget, IsContinousCoverage: false, IsMFP: false);
								}
								else if (mission_0.MissionClass == Mission._MissionClass.Support)
								{
									float StationLength_nm2 = 50f;
									if (!aircraft_0.Navigator.PlotCourseToStationArea_FlightplanGenerator(ref StationStart_Lat2, ref StationStart_Lon2, ref StationEnd_Lat2, ref StationEnd_Lon2, ref StationLength_nm2))
									{
										if (Debugger.IsAttached)
										{
											Debugger.Break();
										}
										continue;
									}
									Aircraft_AI aI2 = aircraft_0.AI;
									Doctrine._UseUnderwayRefuelAndReplenishment? tankerUsage2 = nullable_0;
									bool launchMissionWithoutTankersInPlace2 = mission_0.LaunchMissionWithoutTankersInPlace;
									float FuelQtyRequired = 0f;
									aI2.CanReachStation(ref NewFlight, tankerUsage2, launchMissionWithoutTankersInPlace2, AttemptPathfinderFlightPlan: false, SeparateIngressEgressPathfinderFlightPlans: false, AircraftIsAirborne: false, ref FuelQtyRequired, ref string_6, CallNavigatorImmediately: false, CreateFlightPlan: true, StationStart_Lat2, StationStart_Lon2, StationEnd_Lat2, StationEnd_Lon2, Waypoint.WaypointType.StationStart_FigureEight, Waypoint.TurnRateCategory.FlatTurn, bool_4, mission_0.TakeOffTime, mission_0.TimeOnTarget, IsContinousCoverage: false, IsMFP: true);
								}
								else
								{
									Mission.Flight flight = NewFlight;
									CreatedBy = 0;
									int EditedBy = 0;
									flight.Copy(ref scenario_0, ref OriginalFlight, ref NewFlight, UseMissionSettings: false, ref mission_0, ref CreatedBy, ref EditedBy, AddEmptySlotsToMission: false, CopyErrors: false);
									NewFlight.AddMasterFlightPlanErrorsToFlightplanErrorList(ref scenario_0, ref OriginalFlight);
									if (!Information.IsNothing((object)OriginalFlight.NotificationList) && OriginalFlight.NotificationList.Count > 0)
									{
										ActiveUnit activeUnit = scenario_0.ActiveUnits[NewFlight.TakeOffLocation_HostUnitObjectID];
										foreach (string notification in OriginalFlight.NotificationList)
										{
											scenario_0.AddMessage(notification, OriginalFlight.Name + " notification", LoggedMessage.MessageType.AirOps, 0, "", side_0, new Geopoint_Struct(activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
										}
									}
								}
							}
							else
							{
								Strike strike = (Strike)mission_0;
								Aircraft_AI aI3 = aircraft_0.AI;
								ref Contact primaryTarget = ref OriginalFlight.PrimaryTarget;
								int minResponseRadius_Aircraft = strike.MinResponseRadius_Aircraft;
								int maxResponseRadius_Aircraft = strike.MaxResponseRadius_Aircraft;
								Doctrine._UseUnderwayRefuelAndReplenishment? tankerUsage3 = nullable_0;
								bool launchMissionWithoutTankersInPlace3 = mission_0.LaunchMissionWithoutTankersInPlace;
								Mission._RadarBehaviour radarBehaviour = strike.RadarBehaviour;
								bool usePlanner = strike.UsePlanner;
								float FuelQtyRequired = 0f;
								aI3.CanReachTarget_Strike(ref scenario_0, ref side_0, ref mission_0, ref NewFlight, ref primaryTarget, minResponseRadius_Aircraft, maxResponseRadius_Aircraft, tankerUsage3, launchMissionWithoutTankersInPlace3, radarBehaviour, AttemptPathfinderFlightPlan: false, SeparateIngressEgressPathfinderFlightPlans: false, AircraftIsAirborne: false, usePlanner, ref FuelQtyRequired, ref string_6, CallNavigatorImmediately: false, ref bool_1, bool_1, ref float_2, ref float_3, CreateFlightPlan: true, null, bool_4, mission_0.TakeOffTime, mission_0.TimeOnTarget, IsContinousCoverage: false, IsMFP: false);
							}
							if (NewFlight.FlightPlan.Count() == 0)
							{
								Waypoint[] flightPlan = OriginalFlight.FlightPlan;
								for (int EditedBy = 0; EditedBy < flightPlan.Length; EditedBy++)
								{
									Waypoint theOriginalWaypoint = flightPlan[EditedBy];
									Mission.Flight flight2 = NewFlight;
									Waypoint[] theArray = flight2.FlightPlan;
									Doctrine FlightLeadDoctrine = null;
									ArrayExtensions.Add(ref theArray, Waypoint.CopyWaypoint(ref scenario_0, ref theOriginalWaypoint, CopyWingmanWaypoints: true, CopyFlightplanPointsList: true, ref FlightLeadDoctrine));
									flight2.FlightPlan = theArray;
								}
							}
							mission_0.AddFlight(ref NewFlight);
							if (!bool_2)
							{
								if (list_2.Contains(aircraft_0))
								{
									if (!Information.IsNothing((object)mission_0.EmptySlotsList))
									{
										foreach (Mission.EmptyAircraftSlot emptySlots in mission_0.EmptySlotsList)
										{
											if (!Information.IsNothing((object)emptySlots.get_ReferenceUnit(scenario_0, (Mission)null)) && emptySlots.get_ReferenceUnit(scenario_0, (Mission)null) == aircraft_0)
											{
												emptySlots.SetFlight(scenario_0, NewFlight, 0);
												break;
											}
										}
									}
								}
								else
								{
									aircraft_0.SetFlight(NewFlight, 0);
								}
							}
							else
							{
								aircraft_0.SetFlight(NewFlight, 0);
							}
							if (bool_5)
							{
								flight_0 = NewFlight;
							}
							break;
						}
						NewFlight = new Mission.Flight();
						Mission.Flight flight3 = NewFlight;
						CreatedBy = 0;
						EditedBy2 = 0;
						flight3.Copy(ref scenario_0, ref OriginalFlight, ref NewFlight, UseMissionSettings: false, ref mission_0, ref CreatedBy, ref EditedBy2, AddEmptySlotsToMission: false, CopyErrors: false);
						NewFlight.AddMasterFlightPlanErrorsToFlightplanErrorList(ref scenario_0, ref OriginalFlight);
						if (!Information.IsNothing((object)OriginalFlight.NotificationList) && OriginalFlight.NotificationList.Count > 0)
						{
							ActiveUnit activeUnit2 = scenario_0.ActiveUnits[NewFlight.TakeOffLocation_HostUnitObjectID];
							foreach (string notification2 in OriginalFlight.NotificationList)
							{
								scenario_0.AddMessage(notification2, OriginalFlight.Name + " notification", LoggedMessage.MessageType.AirOps, 0, "", side_0, new Geopoint_Struct(activeUnit2.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit2.get_Latitude((GlobalVariables.BooleanObject)null)));
							}
						}
						if (NewFlight.FlightPlan_Pathfinder_Ingress_1.Count() > 0 && NewFlight.FlightPlan.Count() == 0)
						{
							Waypoint[] flightPlan_Pathfinder_Ingress_ = NewFlight.FlightPlan_Pathfinder_Ingress_1;
							Waypoint[] flightPlan;
							for (EditedBy2 = 0; EditedBy2 < flightPlan_Pathfinder_Ingress_.Length; EditedBy2++)
							{
								Waypoint theOriginalWaypoint2 = flightPlan_Pathfinder_Ingress_[EditedBy2];
								Mission.Flight flight4 = NewFlight;
								flightPlan = flight4.FlightPlan;
								Doctrine FlightLeadDoctrine = null;
								ArrayExtensions.Add(ref flightPlan, Waypoint.CopyWaypoint(ref scenario_0, ref theOriginalWaypoint2, CopyWingmanWaypoints: true, CopyFlightplanPointsList: true, ref FlightLeadDoctrine));
								flight4.FlightPlan = flightPlan;
							}
							Mission.Flight flight5 = NewFlight;
							flightPlan = flight5.FlightPlan_Pathfinder_Ingress_1;
							ArrayExtensions.Clear(ref flightPlan);
							flight5.FlightPlan_Pathfinder_Ingress_1 = flightPlan;
							Mission.Flight flight6 = NewFlight;
							flightPlan = flight6.FlightPlan_Pathfinder_Egress_1;
							ArrayExtensions.Clear(ref flightPlan);
							flight6.FlightPlan_Pathfinder_Egress_1 = flightPlan;
							if (!Information.IsNothing((object)NewFlight.FlightPlan_Pathfinder_Ingress_2) || NewFlight.FlightPlan_Pathfinder_Ingress_2.Count() > 0)
							{
								Mission.Flight flight7 = NewFlight;
								flightPlan = flight7.FlightPlan_Pathfinder_Ingress_2;
								ArrayExtensions.Clear(ref flightPlan);
								flight7.FlightPlan_Pathfinder_Ingress_2 = flightPlan;
								Mission.Flight flight8 = NewFlight;
								flightPlan = flight8.FlightPlan_Pathfinder_Egress_2;
								ArrayExtensions.Clear(ref flightPlan);
								flight8.FlightPlan_Pathfinder_Egress_2 = flightPlan;
							}
						}
						if (bool_2)
						{
							aircraft_0.SetFlight(NewFlight, 0);
						}
						else if (!list_2.Contains(aircraft_0))
						{
							aircraft_0.SetFlight(NewFlight, 0);
						}
						else if (!Information.IsNothing((object)mission_0.EmptySlotsList))
						{
							foreach (Mission.EmptyAircraftSlot emptySlots2 in mission_0.EmptySlotsList)
							{
								if (!Information.IsNothing((object)emptySlots2.get_ReferenceUnit(scenario_0, (Mission)null)) && emptySlots2.get_ReferenceUnit(scenario_0, (Mission)null) == aircraft_0)
								{
									emptySlots2.SetFlight(scenario_0, NewFlight, 0);
									break;
								}
							}
						}
						if (bool_5)
						{
							flight_0 = NewFlight;
						}
						break;
					}
				}
				Mission.Flight flight9 = NewFlight;
				EditedBy2 = 0;
				CreatedBy = 0;
				flight9.Copy(ref scenario_0, ref OriginalFlight, ref NewFlight, UseMissionSettings: false, ref mission_0, ref EditedBy2, ref CreatedBy, AddEmptySlotsToMission: false, CopyErrors: false);
				NewFlight.AddMasterFlightPlanErrorsToFlightplanErrorList(ref scenario_0, ref OriginalFlight);
				OriginalFlight.UsedByFlightCount = 1;
				flag = true;
				if (!Information.IsNothing((object)OriginalFlight.NotificationList) && OriginalFlight.NotificationList.Count > 0)
				{
					ActiveUnit activeUnit3 = scenario_0.ActiveUnits[NewFlight.TakeOffLocation_HostUnitObjectID];
					foreach (string notification3 in OriginalFlight.NotificationList)
					{
						scenario_0.AddMessage(notification3, OriginalFlight.Name + " notification", LoggedMessage.MessageType.AirOps, 0, "", side_0, new Geopoint_Struct(activeUnit3.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit3.get_Latitude((GlobalVariables.BooleanObject)null)));
					}
				}
				if (!bool_2)
				{
					if (!list_2.Contains(aircraft_0))
					{
						aircraft_0.SetFlight(NewFlight, 0);
					}
					else if (!Information.IsNothing((object)mission_0.EmptySlotsList))
					{
						foreach (Mission.EmptyAircraftSlot emptySlots3 in mission_0.EmptySlotsList)
						{
							if (!Information.IsNothing((object)emptySlots3.get_ReferenceUnit(scenario_0, (Mission)null)) && emptySlots3.get_ReferenceUnit(scenario_0, (Mission)null) == aircraft_0)
							{
								emptySlots3.SetFlight(scenario_0, NewFlight, 0);
								break;
							}
						}
					}
				}
				else
				{
					aircraft_0.SetFlight(NewFlight, 0);
				}
				if (bool_5)
				{
					flight_0 = NewFlight;
				}
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 527257527257", "");
			WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void smethod_27(ref Scenario scenario_0, ref Mission mission_0, ref Aircraft aircraft_0, ref List<Aircraft> list_2, ref Mission._FlightSize _FlightSize_0, ref bool bool_1, bool bool_2, bool bool_3, bool bool_4, ref Mission.Flight flight_0)
	{
		try
		{
			Mission.Flight theFlightPlan = null;
			Mission.Flight theF = new Mission.Flight(ref scenario_0, ref mission_0, ref theFlightPlan, Callsigns.FetchCallsignBasedOnMissionType(ref mission_0), null, aircraft_0, _FlightSize_0, bool_2);
			mission_0.AddFlight(ref theF);
			if (bool_1)
			{
				aircraft_0.SetFlight(theF, 0);
			}
			else if (list_2.Contains(aircraft_0))
			{
				if (!Information.IsNothing((object)mission_0.EmptySlotsList))
				{
					foreach (Mission.EmptyAircraftSlot emptySlots in mission_0.EmptySlotsList)
					{
						if (!Information.IsNothing((object)emptySlots.get_ReferenceUnit(scenario_0, (Mission)null)) && emptySlots.get_ReferenceUnit(scenario_0, (Mission)null) == aircraft_0)
						{
							emptySlots.SetFlight(scenario_0, theF, 0);
							break;
						}
					}
				}
			}
			else
			{
				aircraft_0.SetFlight(theF, 0);
			}
			if (bool_4)
			{
				flight_0 = theF;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 25245245245245", "");
			WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static bool smethod_28(ref Scenario scenario_0, ref Side side_0, Mission mission_0, ref List<ActiveUnit> list_2, ref List<ActiveUnit> list_3)
	{
		_Closure$__192-1 closure$__192- = new _Closure$__192-1(closure$__192-);
		closure$__192-.$VB$Local_theMission = mission_0;
		int result;
		if (closure$__192-.$VB$Local_theMission == null)
		{
			result = 0;
		}
		else
		{
			if (closure$__192-.$VB$Local_theMission.MissionClass == Mission._MissionClass.Strike)
			{
				Strike theStrikeMission = (Strike)closure$__192-.$VB$Local_theMission;
				bool flag = theStrikeMission.TargetCount > 0;
				List<Contact> list = new List<Contact>();
				list_3.Clear();
				Strike.StrikeType type = theStrikeMission.Type;
				if ((uint)(type - 1) <= 2u)
				{
					if (theStrikeMission.RTB_When_Target_Destroyed)
					{
						return false;
					}
					using List<ActiveUnit>.Enumerator enumerator = list_2.GetEnumerator();
					_Closure$__192-0 closure$__192-2 = default(_Closure$__192-0);
					_Closure$__192-2 closure$__192-3 = default(_Closure$__192-2);
					while (enumerator.MoveNext())
					{
						closure$__192-2 = new _Closure$__192-0(closure$__192-2);
						closure$__192-2.$VB$NonLocal_$VB$Closure_2 = closure$__192-;
						closure$__192-2.$VB$Local_theMissionUnit = enumerator.Current;
						closure$__192-3 = new _Closure$__192-2(closure$__192-3);
						closure$__192-3.$VB$NonLocal_$VB$Closure_3 = closure$__192-2;
						if (theStrikeMission.get_FocusEntirelyOnStrikeTargets(closure$__192-3.$VB$NonLocal_$VB$Closure_3.$VB$Local_theMissionUnit) || (closure$__192-3.$VB$NonLocal_$VB$Closure_3.$VB$Local_theMissionUnit.DockingOps.get_AssignedHostUnit(PickNewAssignedHost: false) != null && !closure$__192-3.$VB$NonLocal_$VB$Closure_3.$VB$Local_theMissionUnit.AI.IsAllowedToRedeploy_AllChecks))
						{
							continue;
						}
						if (closure$__192-3.$VB$NonLocal_$VB$Closure_3.$VB$Local_theMissionUnit.AI.IsEscort)
						{
							list_3.Add(closure$__192-3.$VB$NonLocal_$VB$Closure_3.$VB$Local_theMissionUnit);
							continue;
						}
						double num = closure$__192-3.$VB$NonLocal_$VB$Closure_3.$VB$Local_theMissionUnit.Kinematics.TacticalRadius();
						closure$__192-3.$VB$Local_Doctrine_ShootTourists = closure$__192-3.$VB$NonLocal_$VB$Closure_3.$VB$Local_theMissionUnit.Doctrine.get_ShootTourists(scenario_0, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
						if (flag)
						{
							foreach (Contact contacts_ in side_0.Contacts_List)
							{
								if (contacts_.get_IsSpecificTargetForThisStrike(theStrikeMission) && closure$__192-3.$VB$NonLocal_$VB$Closure_3.$VB$Local_theMissionUnit.AI.CanMissionTargetThisContactBasedOnPostureStance(ref theStrikeMission, contacts_.get_Stance(side_0)))
								{
									Weapon longestRange_AGWeapon = closure$__192-3.$VB$NonLocal_$VB$Closure_3.$VB$Local_theMissionUnit.Weaponry.GetLongestRange_AGWeapon(ExcludeICBMs: false, contacts_);
									if (!Information.IsNothing((object)longestRange_AGWeapon))
									{
										num += (double)longestRange_AGWeapon.MaxLandRange;
									}
									if (!((double)closure$__192-3.$VB$NonLocal_$VB$Closure_3.$VB$Local_theMissionUnit.RangeToUnit_Horiz(contacts_) > num))
									{
										list_3.Add(closure$__192-3.$VB$NonLocal_$VB$Closure_3.$VB$Local_theMissionUnit);
										break;
									}
								}
							}
							continue;
						}
						List<Contact> list2 = side_0.Contacts_List.Where(closure$__192-3._Lambda$__0).ToList();
						foreach (Contact item in list2)
						{
							if (closure$__192-3.$VB$NonLocal_$VB$Closure_3.$VB$Local_theMissionUnit.AI.CanMissionTargetThisContactBasedOnPostureStance(ref theStrikeMission, item.get_Stance(side_0)) && (double)closure$__192-3.$VB$NonLocal_$VB$Closure_3.$VB$Local_theMissionUnit.RangeToUnit_Horiz(item) <= num)
							{
								list_3.Add(closure$__192-3.$VB$NonLocal_$VB$Closure_3.$VB$Local_theMissionUnit);
								if (!list.Contains(item))
								{
									list.Add(item);
								}
							}
						}
					}
				}
				if (list.Count > 0)
				{
					Strike strike = (Strike)closure$__192-.$VB$Local_theMission;
					foreach (Contact item2 in list)
					{
						strike.AddToSpecificTargets(item2, automaticallyAquired: true);
					}
				}
				return list_3.Count > 0;
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	private static bool smethod_29(ref Scenario scenario_0, ref Side side_0, Mission mission_0, bool bool_1, ref List<ActiveUnit> list_2, ref List<ActiveUnit> list_3, ref List<ActiveUnit> list_4, ref List<ActiveUnit> list_5, ref Mission._GroupSize _GroupSize_0, ref Mission._GroupSize _GroupSize_1, ref bool bool_2, ref bool bool_3, ref List<ActiveUnit> list_6, ref List<ActiveUnit> list_7, ref List<int> list_8)
	{
		_Closure$__193-1 closure$__193- = new _Closure$__193-1(closure$__193-);
		closure$__193-.$VB$Local_theMission = mission_0;
		bool result;
		try
		{
			_Closure$__193-0 closure$__193-2 = new _Closure$__193-0(closure$__193-2);
			closure$__193-2.$VB$NonLocal_$VB$Closure_2 = closure$__193-;
			List<Contact> list = new List<Contact>();
			int num = default(int);
			switch (closure$__193-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMission.MissionClass)
			{
			case Mission._MissionClass.Strike:
			{
				Strike strike = (Strike)closure$__193-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMission;
				strike = (Strike)closure$__193-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMission;
				bool flag = strike.TargetCount > 0;
				_GroupSize_0 = strike.GroupSize;
				_GroupSize_1 = strike.Escort_GroupSize;
				bool_2 = strike.UseGroupSizeHardLimit;
				bool_3 = strike.UseGroupSizeHardLimit_Escort;
				switch (strike.Type)
				{
				case Strike.StrikeType.Air_Intercept:
					foreach (ActiveUnit item in list_7)
					{
						closure$__193-2.$VB$Local_theMissionUnit = item;
						if (closure$__193-2.$VB$Local_theMissionUnit.DockingOps.get_AssignedHostUnit(PickNewAssignedHost: false) != null && !closure$__193-2.$VB$Local_theMissionUnit.AI.IsAllowedToRedeploy_AllChecks)
						{
							continue;
						}
						if (closure$__193-2.$VB$Local_theMissionUnit.AI.IsEscort)
						{
							list_3.Add(closure$__193-2.$VB$Local_theMissionUnit);
							continue;
						}
						double num11 = closure$__193-2.$VB$Local_theMissionUnit.Kinematics.TacticalRadius();
						Doctrine._UseShootTourists? canShootTourists = closure$__193-2.$VB$Local_theMissionUnit.Doctrine.get_ShootTourists(scenario_0, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
						foreach (Contact contacts_ in side_0.Contacts_List)
						{
							ActiveUnit_AI aI = closure$__193-2.$VB$Local_theMissionUnit.AI;
							Mission theMission = closure$__193-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMission;
							string Feedback = "";
							int FeedbackSeverity = 0;
							if (aI.ContactIsRelevantToFlightOrMission(contacts_, theMission, canShootTourists, IgnoreContacStance: false, MyUnitIsInsidePatrolArea: false, IgnoreNeutralContacts: true, null, ref Feedback, ref FeedbackSeverity, null, IgnoreMissionSpecificTargetList: true) && closure$__193-2.$VB$Local_theMissionUnit.AI.CanMissionTargetThisContactBasedOnPostureStance(ref strike, contacts_.get_Stance(closure$__193-2.$VB$Local_theMissionUnit.get_UnitSide(SetSideOnly: false))))
							{
								Weapon longestRange_AAWeapon = closure$__193-2.$VB$Local_theMissionUnit.Weaponry.GetLongestRange_AAWeapon(contacts_);
								if (!Information.IsNothing((object)longestRange_AAWeapon))
								{
									num11 += (double)longestRange_AAWeapon.MaxAirRange;
								}
								if ((double)closure$__193-2.$VB$Local_theMissionUnit.RangeToUnit_Horiz(contacts_) <= num11 && Module_Contact.IsPrimaryTargetForThesePlatforms(contacts_, side_0, GroupsOnly: false).Count < 2)
								{
									closure$__193-2.$VB$Local_theMissionUnit.AI.PrimaryTarget = contacts_;
									list_2.Add(closure$__193-2.$VB$Local_theMissionUnit);
									break;
								}
							}
						}
					}
					break;
				case Strike.StrikeType.Land_Strike:
				{
					_Closure$__193-2 closure$__193-8 = default(_Closure$__193-2);
					foreach (ActiveUnit item2 in list_7)
					{
						closure$__193-2.$VB$Local_theMissionUnit = item2;
						closure$__193-8 = new _Closure$__193-2(closure$__193-8);
						closure$__193-8.$VB$NonLocal_$VB$Closure_3 = closure$__193-2;
						if (closure$__193-8.$VB$NonLocal_$VB$Closure_3.$VB$Local_theMissionUnit.DockingOps.get_AssignedHostUnit(PickNewAssignedHost: false) != null && !closure$__193-8.$VB$NonLocal_$VB$Closure_3.$VB$Local_theMissionUnit.AI.IsAllowedToRedeploy_AllChecks)
						{
							continue;
						}
						if (!closure$__193-8.$VB$NonLocal_$VB$Closure_3.$VB$Local_theMissionUnit.AI.IsEscort)
						{
							double num10 = closure$__193-8.$VB$NonLocal_$VB$Closure_3.$VB$Local_theMissionUnit.Kinematics.TacticalRadius();
							closure$__193-8.$VB$Local_Doctrine_ShootTourists = closure$__193-8.$VB$NonLocal_$VB$Closure_3.$VB$Local_theMissionUnit.Doctrine.get_ShootTourists(scenario_0, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
							if (flag)
							{
								foreach (Contact contacts_2 in side_0.Contacts_List)
								{
									if (contacts_2.get_IsSpecificTargetForThisStrike(strike) && closure$__193-8.$VB$NonLocal_$VB$Closure_3.$VB$Local_theMissionUnit.AI.CanMissionTargetThisContactBasedOnPostureStance(ref strike, contacts_2.get_Stance(side_0)))
									{
										Weapon longestRange_AGWeapon = closure$__193-8.$VB$NonLocal_$VB$Closure_3.$VB$Local_theMissionUnit.Weaponry.GetLongestRange_AGWeapon(ExcludeICBMs: false, contacts_2);
										if (!Information.IsNothing((object)longestRange_AGWeapon))
										{
											num10 += (double)longestRange_AGWeapon.MaxLandRange;
										}
										if (!((double)closure$__193-8.$VB$NonLocal_$VB$Closure_3.$VB$Local_theMissionUnit.RangeToUnit_Horiz(contacts_2) > num10))
										{
											list_2.Add(closure$__193-8.$VB$NonLocal_$VB$Closure_3.$VB$Local_theMissionUnit);
											break;
										}
									}
								}
								continue;
							}
							List<Contact> list12 = side_0.Contacts_List.Where(closure$__193-8._Lambda$__0).ToList();
							foreach (Contact item3 in list12)
							{
								if (closure$__193-8.$VB$NonLocal_$VB$Closure_3.$VB$Local_theMissionUnit.AI.CanMissionTargetThisContactBasedOnPostureStance(ref strike, item3.get_Stance(side_0)) && (double)closure$__193-8.$VB$NonLocal_$VB$Closure_3.$VB$Local_theMissionUnit.RangeToUnit_Horiz(item3) <= num10)
								{
									list_2.Add(closure$__193-8.$VB$NonLocal_$VB$Closure_3.$VB$Local_theMissionUnit);
									if (!list.Contains(item3))
									{
										list.Add(item3);
									}
								}
							}
						}
						else
						{
							list_3.Add(closure$__193-8.$VB$NonLocal_$VB$Closure_3.$VB$Local_theMissionUnit);
						}
					}
					break;
				}
				case Strike.StrikeType.Maritime_Strike:
				{
					_Closure$__193-3 closure$__193-7 = default(_Closure$__193-3);
					foreach (ActiveUnit item4 in list_7)
					{
						closure$__193-2.$VB$Local_theMissionUnit = item4;
						closure$__193-7 = new _Closure$__193-3(closure$__193-7);
						closure$__193-7.$VB$NonLocal_$VB$Closure_4 = closure$__193-2;
						if (closure$__193-7.$VB$NonLocal_$VB$Closure_4.$VB$Local_theMissionUnit.DockingOps.get_AssignedHostUnit(PickNewAssignedHost: false) != null && !closure$__193-7.$VB$NonLocal_$VB$Closure_4.$VB$Local_theMissionUnit.AI.IsAllowedToRedeploy_AllChecks)
						{
							continue;
						}
						if (closure$__193-7.$VB$NonLocal_$VB$Closure_4.$VB$Local_theMissionUnit.AI.IsEscort)
						{
							list_3.Add(closure$__193-7.$VB$NonLocal_$VB$Closure_4.$VB$Local_theMissionUnit);
							continue;
						}
						double num9 = closure$__193-7.$VB$NonLocal_$VB$Closure_4.$VB$Local_theMissionUnit.Kinematics.TacticalRadius();
						closure$__193-7.$VB$Local_Doctrine_ShootTourists = closure$__193-7.$VB$NonLocal_$VB$Closure_4.$VB$Local_theMissionUnit.Doctrine.get_ShootTourists(scenario_0, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
						if (flag)
						{
							foreach (Contact contacts_3 in side_0.Contacts_List)
							{
								if (contacts_3.get_IsSpecificTargetForThisStrike(strike) && closure$__193-7.$VB$NonLocal_$VB$Closure_4.$VB$Local_theMissionUnit.AI.CanMissionTargetThisContactBasedOnPostureStance(ref strike, contacts_3.get_Stance(side_0)))
								{
									Weapon longestRange_ASWeapon = closure$__193-7.$VB$NonLocal_$VB$Closure_4.$VB$Local_theMissionUnit.Weaponry.GetLongestRange_ASWeapon(ExcludeICBMs: false, contacts_3);
									if (!Information.IsNothing((object)longestRange_ASWeapon))
									{
										num9 += (double)longestRange_ASWeapon.MaxSurfaceRange;
									}
									if (!((double)closure$__193-7.$VB$NonLocal_$VB$Closure_4.$VB$Local_theMissionUnit.RangeToUnit_Horiz(contacts_3) > num9))
									{
										list_2.Add(closure$__193-7.$VB$NonLocal_$VB$Closure_4.$VB$Local_theMissionUnit);
										break;
									}
								}
							}
							continue;
						}
						List<Contact> list11 = side_0.Contacts_List.Where(closure$__193-7._Lambda$__1).ToList();
						foreach (Contact item5 in list11)
						{
							if (closure$__193-7.$VB$NonLocal_$VB$Closure_4.$VB$Local_theMissionUnit.AI.CanMissionTargetThisContactBasedOnPostureStance(ref strike, item5.get_Stance(side_0)) && (double)closure$__193-7.$VB$NonLocal_$VB$Closure_4.$VB$Local_theMissionUnit.RangeToUnit_Horiz(item5) <= num9)
							{
								list_2.Add(closure$__193-7.$VB$NonLocal_$VB$Closure_4.$VB$Local_theMissionUnit);
								if (!list.Contains(item5))
								{
									list.Add(item5);
								}
							}
						}
					}
					break;
				}
				case Strike.StrikeType.Sub_Strike:
				{
					_Closure$__193-4 closure$__193-6 = default(_Closure$__193-4);
					foreach (ActiveUnit item6 in list_7)
					{
						closure$__193-2.$VB$Local_theMissionUnit = item6;
						closure$__193-6 = new _Closure$__193-4(closure$__193-6);
						closure$__193-6.$VB$NonLocal_$VB$Closure_5 = closure$__193-2;
						if (closure$__193-6.$VB$NonLocal_$VB$Closure_5.$VB$Local_theMissionUnit.DockingOps.get_AssignedHostUnit(PickNewAssignedHost: false) != null && !closure$__193-6.$VB$NonLocal_$VB$Closure_5.$VB$Local_theMissionUnit.AI.IsAllowedToRedeploy_AllChecks)
						{
							continue;
						}
						if (!closure$__193-6.$VB$NonLocal_$VB$Closure_5.$VB$Local_theMissionUnit.AI.IsEscort)
						{
							double num8 = closure$__193-6.$VB$NonLocal_$VB$Closure_5.$VB$Local_theMissionUnit.Kinematics.TacticalRadius();
							closure$__193-6.$VB$Local_Doctrine_ShootTourists = closure$__193-6.$VB$NonLocal_$VB$Closure_5.$VB$Local_theMissionUnit.Doctrine.get_ShootTourists(scenario_0, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
							if (flag)
							{
								foreach (Contact contacts_4 in side_0.Contacts_List)
								{
									if (!contacts_4.IsClassifiedFalseTarget && (!closure$__193-6.$VB$NonLocal_$VB$Closure_5.$VB$Local_theMissionUnit.IsShip || !SeaIceProvider.PointIsUnderIce(((Module_Unit.Unit)contacts_4).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contacts_4).get_Latitude((GlobalVariables.BooleanObject)null))) && contacts_4.get_IsSpecificTargetForThisStrike(strike) && closure$__193-6.$VB$NonLocal_$VB$Closure_5.$VB$Local_theMissionUnit.AI.CanMissionTargetThisContactBasedOnPostureStance(ref strike, contacts_4.get_Stance(side_0)))
									{
										Weapon longestRange_ASWWeapon = closure$__193-6.$VB$NonLocal_$VB$Closure_5.$VB$Local_theMissionUnit.Weaponry.GetLongestRange_ASWWeapon(contacts_4);
										if (!Information.IsNothing((object)longestRange_ASWWeapon))
										{
											num8 += (double)longestRange_ASWWeapon.MaxSubsurfaceRange;
										}
										if (!((double)closure$__193-6.$VB$NonLocal_$VB$Closure_5.$VB$Local_theMissionUnit.RangeToUnit_Horiz(contacts_4) > num8))
										{
											list_2.Add(closure$__193-6.$VB$NonLocal_$VB$Closure_5.$VB$Local_theMissionUnit);
											break;
										}
									}
								}
								continue;
							}
							List<Contact> list10 = side_0.Contacts_List.Where(closure$__193-6._Lambda$__2).ToList();
							foreach (Contact item7 in list10)
							{
								if (!item7.IsClassifiedFalseTarget && (!closure$__193-6.$VB$NonLocal_$VB$Closure_5.$VB$Local_theMissionUnit.IsShip || !SeaIceProvider.PointIsUnderIce(((Module_Unit.Unit)item7).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)item7).get_Latitude((GlobalVariables.BooleanObject)null))) && closure$__193-6.$VB$NonLocal_$VB$Closure_5.$VB$Local_theMissionUnit.AI.CanMissionTargetThisContactBasedOnPostureStance(ref strike, item7.get_Stance(side_0)) && (double)closure$__193-6.$VB$NonLocal_$VB$Closure_5.$VB$Local_theMissionUnit.RangeToUnit_Horiz(item7) <= num8)
								{
									list_2.Add(closure$__193-6.$VB$NonLocal_$VB$Closure_5.$VB$Local_theMissionUnit);
									if (!list.Contains(item7))
									{
										list.Add(item7);
									}
								}
							}
						}
						else
						{
							list_3.Add(closure$__193-6.$VB$NonLocal_$VB$Closure_5.$VB$Local_theMissionUnit);
						}
					}
					break;
				}
				}
				break;
			}
			case Mission._MissionClass.Patrol:
			{
				Patrol patrol = (Patrol)closure$__193-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMission;
				num = ((Patrol)closure$__193-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMission).MinimumNumberOnStation;
				bool oneThirdRule = ((Patrol)closure$__193-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMission).OneThirdRule;
				_GroupSize_0 = patrol.GroupSize;
				bool_2 = patrol.UseGroupSizeHardLimit;
				if (!oneThirdRule && num <= 0)
				{
					foreach (ActiveUnit item8 in list_7)
					{
						closure$__193-2.$VB$Local_theMissionUnit = item8;
						if (!Information.IsNothing((object)closure$__193-2.$VB$Local_theMissionUnit) && closure$__193-2.$VB$Local_theMissionUnit.AI.IsAllowedToRedeploy_AllChecks)
						{
							list_2.Add(closure$__193-2.$VB$Local_theMissionUnit);
						}
					}
					break;
				}
				Mission.OneThirdGroupingType oneThirdGrouping3 = closure$__193-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMission.OneThirdGrouping;
				if (oneThirdGrouping3 >= Mission.OneThirdGroupingType.ByLoadout && oneThirdGrouping3 <= Mission.OneThirdGroupingType.ByUnitClass)
				{
					using List<int>.Enumerator enumerator21 = list_8.GetEnumerator();
					_Closure$__193-10 closure$__193-11 = default(_Closure$__193-10);
					while (enumerator21.MoveNext())
					{
						closure$__193-11 = new _Closure$__193-10(closure$__193-11);
						closure$__193-11.$VB$Local_theDBID = enumerator21.Current;
						List<ActiveUnit> list19 = list_6.Where(closure$__193-11._Lambda$__17).ToList();
						if (oneThirdRule && num > 0)
						{
							num = (int)Math.Round(Math.Max(Math.Ceiling((double)list19.Count / 3.0), num));
						}
						else if (oneThirdRule && num == 0)
						{
							num = (int)Math.Ceiling((double)list19.Count / 3.0);
						}
						else if (!oneThirdRule && num > 0)
						{
							num = num;
						}
						List<ActiveUnit> list20 = list19.Where([SpecialName] (ActiveUnit theUnit) => !theUnit.IsParkedAndReady() && !theUnit.IsRTB).ToList();
						List<ActiveUnit> list21 = list_7.Where(closure$__193-11._Lambda$__19).ToList();
						if ((bool_2 && list21.Count < (int)_GroupSize_0) || list21.Count <= 0)
						{
							continue;
						}
						int num16 = num - list20.Count;
						if (num16 <= 0)
						{
							continue;
						}
						int num17 = 0;
						while (num16 > 0 && num17 < list21.Count)
						{
							closure$__193-2.$VB$Local_theMissionUnit = list21[num17];
							if (!Information.IsNothing((object)closure$__193-2.$VB$Local_theMissionUnit) && closure$__193-2.$VB$Local_theMissionUnit.AI.IsAllowedToRedeploy_AllChecks)
							{
								list_2.Add(closure$__193-2.$VB$Local_theMissionUnit);
								num16--;
							}
							num17++;
						}
					}
				}
				else
				{
					if (oneThirdGrouping3 != Mission.OneThirdGroupingType.NoGrouping)
					{
						break;
					}
					using List<int>.Enumerator enumerator22 = list_8.GetEnumerator();
					_Closure$__193-11 closure$__193-12 = default(_Closure$__193-11);
					while (enumerator22.MoveNext())
					{
						closure$__193-12 = new _Closure$__193-11(closure$__193-12);
						closure$__193-12.$VB$Local_theDBID = enumerator22.Current;
						List<ActiveUnit> list22 = list_6.Where(closure$__193-12._Lambda$__20).ToList();
						if (oneThirdRule && num > 0)
						{
							num = (int)Math.Round(Math.Max(Math.Ceiling((double)list22.Count / 3.0), num));
						}
						else if (oneThirdRule && num == 0)
						{
							num = (int)Math.Ceiling((double)list22.Count / 3.0);
						}
						else if (!oneThirdRule && num > 0)
						{
							num = num;
						}
						List<ActiveUnit> list23 = list22.Where([SpecialName] (ActiveUnit theUnit) => !theUnit.IsParkedAndReady() && !theUnit.IsRTB).ToList();
						List<ActiveUnit> list24 = list_7.Where(closure$__193-12._Lambda$__22).ToList();
						if ((bool_2 && list24.Count < (int)_GroupSize_0) || list24.Count <= 0)
						{
							continue;
						}
						int num18 = num - list23.Count;
						if (num18 <= 0)
						{
							continue;
						}
						int num19 = 0;
						while (num18 > 0 && num19 < list24.Count)
						{
							ActiveUnit activeUnit3 = list24[num19];
							if (activeUnit3 != null && activeUnit3.AI.IsAllowedToRedeploy_AllChecks)
							{
								list_2.Add(activeUnit3);
								num18--;
							}
							num19++;
						}
					}
				}
				break;
			}
			case Mission._MissionClass.Support:
			{
				SupportMission supportMission = (SupportMission)closure$__193-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMission;
				bool oneThirdRule = ((SupportMission)closure$__193-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMission).OneThirdRule;
				_GroupSize_0 = supportMission.GroupSize;
				bool_2 = supportMission.UseGroupSizeHardLimit;
				if (!oneThirdRule && num <= 0)
				{
					foreach (ActiveUnit item9 in list_7)
					{
						closure$__193-2.$VB$Local_theMissionUnit = item9;
						if (!Information.IsNothing((object)closure$__193-2.$VB$Local_theMissionUnit) && closure$__193-2.$VB$Local_theMissionUnit.AI.IsAllowedToRedeploy_AllChecks)
						{
							list_2.Add(closure$__193-2.$VB$Local_theMissionUnit);
						}
					}
					break;
				}
				Mission.OneThirdGroupingType oneThirdGrouping4 = closure$__193-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMission.OneThirdGrouping;
				if (oneThirdGrouping4 >= Mission.OneThirdGroupingType.ByLoadout && oneThirdGrouping4 <= Mission.OneThirdGroupingType.ByUnitClass)
				{
					using List<int>.Enumerator enumerator24 = list_8.GetEnumerator();
					_Closure$__193-12 closure$__193-13 = default(_Closure$__193-12);
					while (enumerator24.MoveNext())
					{
						closure$__193-13 = new _Closure$__193-12(closure$__193-13);
						closure$__193-13.$VB$Local_theDBID = enumerator24.Current;
						num = ((SupportMission)closure$__193-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMission).MinimumNumberOnStation;
						List<ActiveUnit> list25 = list_6.Where(closure$__193-13._Lambda$__23).ToList();
						if (oneThirdRule && num > 0)
						{
							num = (int)Math.Round(Math.Max(Math.Ceiling((double)list25.Count / 3.0), num));
						}
						else if (oneThirdRule && num == 0)
						{
							num = (int)Math.Ceiling((double)list25.Count / 3.0);
						}
						else if (!oneThirdRule && num > 0)
						{
							num = num;
						}
						List<ActiveUnit> list26 = list25.Where([SpecialName] (ActiveUnit theUnit) => !theUnit.IsParkedAndReady() && !theUnit.IsRTB).ToList();
						List<ActiveUnit> list27 = list_7.Where(closure$__193-13._Lambda$__25).ToList();
						if ((bool_2 && list27.Count < (int)_GroupSize_0) || list27.Count <= 0)
						{
							continue;
						}
						int num20 = num - list26.Count;
						if (num20 <= 0)
						{
							continue;
						}
						int num21 = 0;
						while (num20 > 0 && num21 < list27.Count)
						{
							closure$__193-2.$VB$Local_theMissionUnit = list27[num21];
							if (!Information.IsNothing((object)closure$__193-2.$VB$Local_theMissionUnit) && closure$__193-2.$VB$Local_theMissionUnit.AI.IsAllowedToRedeploy_AllChecks)
							{
								list_2.Add(closure$__193-2.$VB$Local_theMissionUnit);
								num20--;
							}
							num21++;
						}
					}
				}
				else
				{
					if (oneThirdGrouping4 != Mission.OneThirdGroupingType.NoGrouping)
					{
						break;
					}
					using List<int>.Enumerator enumerator25 = list_8.GetEnumerator();
					_Closure$__193-13 closure$__193-14 = default(_Closure$__193-13);
					while (enumerator25.MoveNext())
					{
						closure$__193-14 = new _Closure$__193-13(closure$__193-14);
						closure$__193-14.$VB$Local_theDBID = enumerator25.Current;
						List<ActiveUnit> list28 = list_6.Where(closure$__193-14._Lambda$__26).ToList();
						if (oneThirdRule && num > 0)
						{
							num = (int)Math.Round(Math.Max(Math.Ceiling((double)list28.Count / 3.0), num));
						}
						else if (oneThirdRule && num == 0)
						{
							num = (int)Math.Ceiling((double)list28.Count / 3.0);
						}
						else if (!oneThirdRule && num > 0)
						{
							num = num;
						}
						List<ActiveUnit> list29 = list28.Where([SpecialName] (ActiveUnit theUnit) => !theUnit.IsParkedAndReady() && !theUnit.IsRTB).ToList();
						List<ActiveUnit> list30 = list_7.Where(closure$__193-14._Lambda$__28).ToList();
						if ((bool_2 && list30.Count < (int)_GroupSize_0) || list30.Count <= 0)
						{
							continue;
						}
						int num22 = num - list29.Count;
						if (num22 <= 0)
						{
							continue;
						}
						int num23 = 0;
						while (num22 > 0 && num23 < list30.Count)
						{
							ActiveUnit activeUnit4 = list30[num23];
							if (activeUnit4 != null && activeUnit4.AI.IsAllowedToRedeploy_AllChecks)
							{
								list_2.Add(activeUnit4);
								num22--;
							}
							num23++;
						}
					}
				}
				break;
			}
			case Mission._MissionClass.Ferry:
				foreach (ActiveUnit item10 in list_7)
				{
					closure$__193-2.$VB$Local_theMissionUnit = item10;
					if (!Information.IsNothing((object)closure$__193-2.$VB$Local_theMissionUnit) && closure$__193-2.$VB$Local_theMissionUnit.AI.IsAllowedToRedeploy_AllChecks)
					{
						list_2.Add(closure$__193-2.$VB$Local_theMissionUnit);
					}
				}
				break;
			case Mission._MissionClass.Mining:
			{
				MiningMission miningMission = (MiningMission)closure$__193-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMission;
				bool oneThirdRule = ((MiningMission)closure$__193-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMission).OneThirdRule;
				_GroupSize_0 = miningMission.GroupSize;
				bool_2 = miningMission.UseGroupSizeHardLimit;
				if (oneThirdRule)
				{
					Mission.OneThirdGroupingType oneThirdGrouping2 = closure$__193-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMission.OneThirdGrouping;
					if (oneThirdGrouping2 >= Mission.OneThirdGroupingType.ByLoadout && oneThirdGrouping2 <= Mission.OneThirdGroupingType.ByUnitClass)
					{
						using List<int>.Enumerator enumerator17 = list_8.GetEnumerator();
						_Closure$__193-5 closure$__193-9 = default(_Closure$__193-5);
						while (enumerator17.MoveNext())
						{
							closure$__193-9 = new _Closure$__193-5(closure$__193-9);
							closure$__193-9.$VB$Local_theDBID = enumerator17.Current;
							List<ActiveUnit> list13 = list_6.Where(closure$__193-9._Lambda$__3).ToList();
							List<ActiveUnit> list14 = list_7.Where(closure$__193-9._Lambda$__4).ToList();
							if ((bool_2 && list14.Count < (int)_GroupSize_0) || list14.Count <= 0)
							{
								continue;
							}
							num = (int)Math.Ceiling((double)list13.Count / 3.0);
							List<ActiveUnit> list15 = list13.Where([SpecialName] (ActiveUnit theUnit) => !theUnit.IsParkedAndReady() && !theUnit.IsRTB).ToList();
							int num12 = num - list15.Count;
							if (num12 <= 0)
							{
								continue;
							}
							int num13 = 0;
							while (num12 > 0 && num13 < list14.Count)
							{
								closure$__193-2.$VB$Local_theMissionUnit = list14[num13];
								if (!Information.IsNothing((object)closure$__193-2.$VB$Local_theMissionUnit) && closure$__193-2.$VB$Local_theMissionUnit.AI.IsAllowedToRedeploy_AllChecks)
								{
									list_2.Add(closure$__193-2.$VB$Local_theMissionUnit);
									num12--;
								}
								num13++;
							}
						}
					}
					else
					{
						if (oneThirdGrouping2 != Mission.OneThirdGroupingType.NoGrouping)
						{
							break;
						}
						using List<int>.Enumerator enumerator18 = list_8.GetEnumerator();
						_Closure$__193-6 closure$__193-10 = default(_Closure$__193-6);
						while (enumerator18.MoveNext())
						{
							closure$__193-10 = new _Closure$__193-6(closure$__193-10);
							closure$__193-10.$VB$Local_theDBID = enumerator18.Current;
							List<ActiveUnit> list16 = list_6.Where(closure$__193-10._Lambda$__6).ToList();
							if (oneThirdRule && num > 0)
							{
								num = (int)Math.Round(Math.Max(Math.Ceiling((double)list16.Count / 3.0), num));
							}
							else if (oneThirdRule && num == 0)
							{
								num = (int)Math.Ceiling((double)list16.Count / 3.0);
							}
							else if (!oneThirdRule && num > 0)
							{
								num = num;
							}
							List<ActiveUnit> list17 = list16.Where([SpecialName] (ActiveUnit theUnit) => !theUnit.IsParkedAndReady() && !theUnit.IsRTB).ToList();
							List<ActiveUnit> list18 = list_7.Where(closure$__193-10._Lambda$__8).ToList();
							if ((bool_2 && list18.Count < (int)_GroupSize_0) || list18.Count <= 0)
							{
								continue;
							}
							int num14 = num - list17.Count;
							if (num14 <= 0)
							{
								continue;
							}
							int num15 = 0;
							while (num14 > 0 && num15 < list18.Count)
							{
								ActiveUnit activeUnit2 = list18[num15];
								if (activeUnit2 != null && activeUnit2.AI.IsAllowedToRedeploy_AllChecks)
								{
									list_2.Add(activeUnit2);
									num14--;
								}
								num15++;
							}
						}
					}
					break;
				}
				foreach (ActiveUnit item11 in list_7)
				{
					if (item11.AI.IsAllowedToRedeploy_AllChecks)
					{
						list_2.Add(item11);
					}
				}
				break;
			}
			case Mission._MissionClass.MineClearing:
			{
				MineClearingMission mineClearingMission = (MineClearingMission)closure$__193-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMission;
				bool oneThirdRule = ((MineClearingMission)closure$__193-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMission).OneThirdRule;
				_GroupSize_0 = mineClearingMission.GroupSize;
				bool_2 = mineClearingMission.UseGroupSizeHardLimit;
				if (!oneThirdRule)
				{
					List<ActiveUnit> list2 = new List<ActiveUnit>();
					List<int> list3 = new List<int>();
					foreach (ActiveUnit item12 in list_7)
					{
						if (item12.IsSubmarine && (((Submarine)item12).Type == Submarine._SubmarineType.ROV || ((Submarine)item12).Type == Submarine._SubmarineType.UUV))
						{
							list2.Add(item12);
							if (!list3.Contains(item12.DBID))
							{
								list3.Add(item12.DBID);
							}
						}
						else if (!Information.IsNothing((object)closure$__193-2.$VB$Local_theMissionUnit) && closure$__193-2.$VB$Local_theMissionUnit.AI.IsAllowedToRedeploy_AllChecks)
						{
							list_2.Add(closure$__193-2.$VB$Local_theMissionUnit);
						}
					}
					if (list2.Count <= 0)
					{
						break;
					}
					using (List<int>.Enumerator enumerator2 = list3.GetEnumerator())
					{
						_Closure$__193-9 closure$__193-3 = default(_Closure$__193-9);
						while (enumerator2.MoveNext())
						{
							closure$__193-3 = new _Closure$__193-9(closure$__193-3);
							closure$__193-3.$VB$Local_theDBID = enumerator2.Current;
							List<ActiveUnit> source = list_6.Where(closure$__193-3._Lambda$__15).ToList();
							IEnumerable<ActiveUnit> source2 = source.Where([SpecialName] (ActiveUnit theUnit) => !theUnit.IsParkedAndReady() && !theUnit.IsRTB).ToList();
							num = (int)Math.Ceiling((double)source.Count() / 3.0);
							int num2 = num - source2.Count();
							if (num2 <= 0)
							{
								continue;
							}
							int num3 = 0;
							while (num2 > 0 && num3 < list2.Count)
							{
								if (list2[num3].DockingOps.CurrentHostUnit.Navigator.IsInsideMissionArea(ref mineClearingMission.Area, ref mineClearingMission.Area_1nm_Buffered, ref mineClearingMission.Area_1nm_ChangeCheck, 1, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
								{
									if (!Information.IsNothing((object)list2[num3]))
									{
										list_2.Add(list2[num3]);
									}
									num2--;
								}
								num3++;
							}
						}
					}
					break;
				}
				Mission.OneThirdGroupingType oneThirdGrouping = closure$__193-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMission.OneThirdGrouping;
				if (oneThirdGrouping >= Mission.OneThirdGroupingType.ByLoadout && oneThirdGrouping <= Mission.OneThirdGroupingType.ByUnitClass)
				{
					using List<int>.Enumerator enumerator3 = list_8.GetEnumerator();
					_Closure$__193-7 closure$__193-4 = default(_Closure$__193-7);
					while (enumerator3.MoveNext())
					{
						closure$__193-4 = new _Closure$__193-7(closure$__193-4);
						closure$__193-4.$VB$Local_theDBID = enumerator3.Current;
						List<ActiveUnit> list4 = list_6.Where(closure$__193-4._Lambda$__9).ToList();
						List<ActiveUnit> list5 = list_7.Where(closure$__193-4._Lambda$__10).ToList();
						if ((bool_2 && list5.Count < (int)_GroupSize_0) || list5.Count <= 0)
						{
							continue;
						}
						num = (int)Math.Ceiling((double)list4.Count / 3.0);
						List<ActiveUnit> list6 = list4.Where([SpecialName] (ActiveUnit theUnit) => !theUnit.IsParkedAndReady() && !theUnit.IsRTB).ToList();
						int num4 = num - list6.Count;
						if (num4 <= 0)
						{
							continue;
						}
						int num5 = 0;
						while (num4 > 0 && num5 < list5.Count)
						{
							closure$__193-2.$VB$Local_theMissionUnit = list5[num5];
							if (!Information.IsNothing((object)closure$__193-2.$VB$Local_theMissionUnit))
							{
								if (closure$__193-2.$VB$Local_theMissionUnit.IsSubmarine && (((Submarine)closure$__193-2.$VB$Local_theMissionUnit).Type == Submarine._SubmarineType.ROV || ((Submarine)closure$__193-2.$VB$Local_theMissionUnit).Type == Submarine._SubmarineType.UUV))
								{
									try
									{
										if (closure$__193-2.$VB$Local_theMissionUnit.DockingOps.CurrentHostUnit.Navigator.IsInsideMissionArea(ref mineClearingMission.Area, ref mineClearingMission.Area_1nm_Buffered, ref mineClearingMission.Area_1nm_ChangeCheck, 1, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
										{
											list_2.Add(closure$__193-2.$VB$Local_theMissionUnit);
											num4--;
										}
									}
									catch (Exception ex)
									{
										ProjectData.SetProjectError(ex);
										Exception ex2 = ex;
										ex2?.Data.Add("Error at 200493", ex2.Message);
										WriteExceptionsToLog(ex2);
										if (Debugger.IsAttached)
										{
											Debugger.Break();
										}
										ProjectData.ClearProjectError();
									}
								}
								else if (!Information.IsNothing((object)closure$__193-2.$VB$Local_theMissionUnit) && closure$__193-2.$VB$Local_theMissionUnit.AI.IsAllowedToRedeploy_AllChecks)
								{
									list_2.Add(closure$__193-2.$VB$Local_theMissionUnit);
									num4--;
								}
							}
							num5++;
						}
					}
				}
				else
				{
					if (oneThirdGrouping != Mission.OneThirdGroupingType.NoGrouping)
					{
						break;
					}
					using List<int>.Enumerator enumerator4 = list_8.GetEnumerator();
					_Closure$__193-8 closure$__193-5 = default(_Closure$__193-8);
					while (enumerator4.MoveNext())
					{
						closure$__193-5 = new _Closure$__193-8(closure$__193-5);
						closure$__193-5.$VB$Local_theDBID = enumerator4.Current;
						List<ActiveUnit> list7 = list_6.Where(closure$__193-5._Lambda$__12).ToList();
						if (oneThirdRule && num > 0)
						{
							num = (int)Math.Round(Math.Max(Math.Ceiling((double)list7.Count / 3.0), num));
						}
						else if (oneThirdRule && num == 0)
						{
							num = (int)Math.Ceiling((double)list7.Count / 3.0);
						}
						else if (!oneThirdRule && num > 0)
						{
							num = num;
						}
						List<ActiveUnit> list8 = list7.Where([SpecialName] (ActiveUnit theUnit) => !theUnit.IsParkedAndReady() && !theUnit.IsRTB).ToList();
						List<ActiveUnit> list9 = list_7.Where(closure$__193-5._Lambda$__14).ToList();
						if ((bool_2 && list9.Count < (int)_GroupSize_0) || list9.Count <= 0)
						{
							continue;
						}
						int num6 = num - list8.Count;
						if (num6 <= 0)
						{
							continue;
						}
						int num7 = 0;
						while (num6 > 0 && num7 < list9.Count)
						{
							ActiveUnit activeUnit = list9[num7];
							if (activeUnit != null && activeUnit.AI.IsAllowedToRedeploy_AllChecks)
							{
								list_2.Add(activeUnit);
								num6--;
							}
							num7++;
						}
					}
				}
				break;
			}
			}
			if (closure$__193-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMission.MissionClass == Mission._MissionClass.Strike && list.Count > 0)
			{
				Strike strike2 = (Strike)closure$__193-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theMission;
				foreach (Contact item13 in list)
				{
					strike2.AddToSpecificTargets(item13, automaticallyAquired: true);
				}
			}
			result = true;
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 756736525345545", "");
			WriteExceptionsToLog(ex4);
			int num24;
			if (!Debugger.IsAttached)
			{
				num24 = 0;
			}
			else
			{
				Debugger.Break();
				num24 = 0;
			}
			result = (byte)num24 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private static bool smethod_30(ref Scenario scenario_0, ref Side side_0, object object_0, bool bool_1, ref List<ActiveUnit> list_2, ref List<ActiveUnit> list_3, ref List<ActiveUnit> list_4, ref List<ActiveUnit> list_5, ref Mission._GroupSize _GroupSize_0, ref Mission._GroupSize _GroupSize_1, ref bool bool_2, ref bool bool_3, ref List<ActiveUnit> list_6)
	{
		bool result;
		try
		{
			int num = 0;
			List<Group> list = new List<Group>();
			using (List<ActiveUnit>.Enumerator enumerator = list_6.GetEnumerator())
			{
				_Closure$__194-0 closure$__194- = default(_Closure$__194-0);
				while (enumerator.MoveNext())
				{
					closure$__194- = new _Closure$__194-0(closure$__194-);
					closure$__194-.$VB$Local_theShipSubtHost = enumerator.Current;
					int num2 = 0;
					int num3 = 0;
					IEnumerable<ActiveUnit> enumerable = list_2.Where(closure$__194-._Lambda$__0);
					IEnumerable<ActiveUnit> enumerable2 = list_3.Where(closure$__194-._Lambda$__1);
					if (enumerable.Count() > 0)
					{
						if (!(enumerable.Count() >= _GroupSize_0) && bool_2)
						{
							if (enumerable.Count() < _GroupSize_0 && ((Mission)object_0).TimeSincePlayerNotification == 1)
							{
								scenario_0.AddMessage("Mission " + ((ScenarioObject)object_0).Name + " ships and/or submarines on host " + closure$__194-.$VB$Local_theShipSubtHost.Name + " cannot deploy. When divided by base/ship there isn't enough vessels to create the minimum number of groups. A possible solution would be to add more vessels. Alternatively, re-configure the mission and reduce the minimum number of required vessels and/or escorts, or reduce the group size.", ((ScenarioObject)object_0).Name + " cannot deploy", LoggedMessage.MessageType.DockingOps, 0, null, side_0);
							}
						}
						else if (!(_GroupSize_0 > 1))
						{
							foreach (ActiveUnit item3 in enumerable)
							{
								list_4.Add(item3);
							}
						}
						else
						{
							int num4 = enumerable.Count();
							while (true)
							{
								if (!bool_2)
								{
									if (num4 == 0)
									{
										break;
									}
								}
								else if (num4 < _GroupSize_0)
								{
									break;
								}
								List<ActiveUnit> list2 = new List<ActiveUnit>();
								int num5 = _GroupSize_0;
								for (int i = 1; i <= num5; i++)
								{
									if (num2 >= enumerable.Count())
									{
										break;
									}
									if (!Information.IsNothing((object)enumerable.ElementAtOrDefault(num2)))
									{
										list2.Add(enumerable.ElementAtOrDefault(num2));
										list_4.Add(enumerable.ElementAtOrDefault(num2));
										num++;
										num4--;
										num2++;
									}
								}
								Group item = new Group(ref scenario_0, ref side_0, list2, UsingMissionPlanner: false, null, (Mission)object_0);
								list.Add(item);
							}
						}
					}
					if (Information.IsNothing((object)enumerable2) || enumerable2.Count() <= 0)
					{
						continue;
					}
					if (!(enumerable2.Count() >= _GroupSize_1) && bool_3)
					{
						if (enumerable2.Count() < _GroupSize_1 && ((Mission)object_0).TimeSincePlayerNotification == 1)
						{
							scenario_0.AddMessage("Mission " + ((ScenarioObject)object_0).Name + " ships and/or submarines on host " + closure$__194-.$VB$Local_theShipSubtHost.Name + " cannot deploy. When divided by base/ship there isn't enough vessels to create the minimum number of groups. A possible solution would be to add more vessels. Alternatively, re-configure the mission and reduce the minimum number of required vessels and/or escorts, or reduce the group size.", ((ScenarioObject)object_0).Name + " cannot deploy", LoggedMessage.MessageType.DockingOps, 0, null, side_0);
						}
						continue;
					}
					if (_GroupSize_1 > 1)
					{
						int num6 = enumerable2.Count();
						while (true)
						{
							if (!bool_3)
							{
								if (num6 == 0)
								{
									break;
								}
							}
							else if (num6 < _GroupSize_1)
							{
								break;
							}
							List<ActiveUnit> list3 = new List<ActiveUnit>();
							int num7 = _GroupSize_1;
							for (int j = 1; j <= num7; j++)
							{
								if (num3 >= enumerable2.Count())
								{
									break;
								}
								if (!Information.IsNothing((object)enumerable2.ElementAtOrDefault(num3)))
								{
									list3.Add(enumerable2.ElementAtOrDefault(num3));
									list_5.Add(enumerable2.ElementAtOrDefault(num3));
									num++;
									num6--;
									num3++;
								}
							}
							Group item2 = new Group(ref scenario_0, ref side_0, list3, UsingMissionPlanner: false, null, (Mission)object_0);
							list.Add(item2);
						}
						continue;
					}
					foreach (ActiveUnit item4 in enumerable2)
					{
						list_5.Add(item4);
					}
				}
			}
			foreach (Group item5 in list)
			{
				if (item5.Units.Values.Count == 1)
				{
					item5.Units.Values.ElementAtOrDefault(0).set_ParentGroup(UsingMissionPlanner: true, (Group)null);
					item5.Destroy(ScenEditAction: false, IsAimpointFacility: false, DestroyUnitNow: false, "Group destroyed by mission logic");
				}
			}
			foreach (ActiveUnit item6 in list_5)
			{
				if (item6.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.Docked)
				{
					item6.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.DeployingUnderway;
				}
			}
			foreach (ActiveUnit item7 in list_4)
			{
				if (item7.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.Docked)
				{
					item7.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.DeployingUnderway;
				}
			}
			result = true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 42323345666666", "");
			WriteExceptionsToLog(ex2);
			int num8;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num8 = 0;
			}
			else
			{
				num8 = 0;
			}
			result = (byte)num8 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private static bool smethod_31(ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, ref List<Aircraft> list_2, ref List<Aircraft> list_3, int? nullable_0, Mission._FlightSize _FlightSize_0)
	{
		if (list_2.Count != list_3.Count)
		{
			goto IL_0258;
		}
		if (nullable_0.HasValue)
		{
			int count = list_2.Count;
			if (((!nullable_0.HasValue) ? ((bool?)null) : new bool?(count < nullable_0.GetValueOrDefault())) == true)
			{
				Scenario obj = scenario_0;
				string[] obj2 = new string[7]
				{
					"***WARNING*** The total number of aircraft available for mission: ",
					mission_0.Name,
					" (",
					Conversions.ToString(list_2.Count),
					") is smaller than the minimum number of aircraft required to trigger mission (",
					null,
					null
				};
				int? num = nullable_0;
				obj2[5] = ((((!num.HasValue) ? ((bool?)null) : new bool?(num == int.MaxValue)) == true) ? "All" : nullable_0.ToString());
				obj2[6] = "). This mission will never take off. Removing aircraft from mission.";
				obj.AddMessage(string.Concat(obj2), mission_0.Name + " cannot launch; removes its AC", LoggedMessage.MessageType.SpecialMessage, 0, null, side_0);
				foreach (Aircraft item in list_2)
				{
					Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
					item.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: false, ref Result);
				}
				return false;
			}
		}
		int result;
		if (nullable_0.HasValue)
		{
			result = 1;
		}
		else
		{
			if (!(list_2.Count < _FlightSize_0))
			{
				goto IL_0258;
			}
			if (mission_0.UseFlightSizeHardLimit)
			{
				scenario_0.AddMessage("***WARNING*** The total number of aircraft available for mission: " + mission_0.Name + " (" + Conversions.ToString(list_2.Count) + ") is smaller than the specified flight size (" + _FlightSize_0.value + ") or minimum number of aircraft required to trigger mission. This mission will never take off. Removing aircraft from mission.", mission_0.Name + " cannot launch; removes its AC", LoggedMessage.MessageType.SpecialMessage, 0, null, side_0);
				foreach (Aircraft item2 in list_2)
				{
					Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
					item2.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: false, ref Result);
				}
				return false;
			}
			result = 1;
		}
		goto IL_0259;
		IL_0258:
		result = 1;
		goto IL_0259;
		IL_0259:
		return (byte)result != 0;
	}

	public static bool CanIssueOrdersToThisUnit(Side theSide, Module_Unit.Unit theUnit, bool IncludeSonobuoys, ref string ReasonWhyNot, string string_6)
	{
		bool result;
		try
		{
			int num;
			if (theUnit == null)
			{
				result = false;
			}
			else if (theUnit.IsActiveUnit)
			{
				if (!Module_Unit.IsRemoteSimEntity(theUnit))
				{
					if (theUnit.get_UnitSide(SetSideOnly: false) == null)
					{
						num = 0;
						goto IL_01d3;
					}
					if (theUnit.get_UnitSide(SetSideOnly: false) != theSide)
					{
						num = 0;
						goto IL_01d3;
					}
					if (Beta_PlatformComms && theUnit.get_UnitSide(SetSideOnly: false).ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.RealisticOrderChain) && theUnit.IsActiveUnit && theSide.ParentScen.GameContext.GameMode != Game._GameMode.ScenEdit && !SimConfiguration.DefaultGamePreferences.PersonalMapProfile.GodsEye && !((ActiveUnit)theUnit).CommStuff.CheckIfUnitIsInContactWithHQ(theSide, theUnit))
					{
						ReasonWhyNot = "No comms with HQ";
						result = false;
					}
					else if (!string.IsNullOrEmpty(string_6) && Operators.CompareString(theUnit.ObjectID, string_6, false) == 0)
					{
						result = true;
					}
					else if (((ActiveUnit)theUnit).CommStuff.IsConnectedToSideNetwork)
					{
						if (!theUnit.IsGroup)
						{
							if (!theUnit.IsWeapon)
							{
								goto IL_015b;
							}
							Weapon weapon = (Weapon)theUnit;
							if (!weapon.IsWeaponPallet)
							{
								if (weapon.DataLinkParent == null)
								{
									ReasonWhyNot = "Weapon does not have an active datalink";
									result = false;
								}
								else if (!IncludeSonobuoys && weapon.Type == Weapon._WeaponType.Sonobuoy)
								{
									result = false;
								}
								else if (weapon.isLoiterCapable)
								{
									result = true;
								}
								else
								{
									if (!weapon.IsAAWCapable)
									{
										goto IL_015b;
									}
									result = false;
								}
							}
							else
							{
								result = true;
							}
						}
						else
						{
							IEnumerator<KeyValuePair<string, ActiveUnit>> enumerator = ((Group)theUnit).Units.GetEnumerator();
							while (true)
							{
								if (enumerator.MoveNext())
								{
									ActiveUnit value = enumerator.Current.Value;
									string ReasonWhyNot2 = null;
									if (CanIssueOrdersToThisUnit(theSide, value, IncludeSonobuoys, ref ReasonWhyNot2, string_6))
									{
										result = true;
										break;
									}
									continue;
								}
								ReasonWhyNot = "Cannot issue orders to any member of this group";
								result = false;
								break;
							}
						}
					}
					else
					{
						ReasonWhyNot = "Unit is out of comms";
						result = false;
					}
				}
				else
				{
					result = false;
				}
			}
			else
			{
				result = false;
			}
			goto end_IL_0001;
			IL_015b:
			if (((ActiveUnit)theUnit).IsExhausted())
			{
				ReasonWhyNot = "Unit is exahusted and is RTB";
				result = false;
			}
			else
			{
				result = true;
			}
			goto end_IL_0001;
			IL_01d3:
			result = (byte)num != 0;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200361", ex2.Message);
			WriteExceptionsToLog(ex2);
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
		return result;
	}

	public static void PaddedTimeAndDateString(ref DateTime theDate, ref string theDateString)
	{
		PaddedDateString(ref theDate, ref theDateString, AddComma: true);
		PaddedTimeString(ref theDate, ref theDateString);
	}

	public static void PaddedTimeString(ref DateTime theDate, ref string theTimeString)
	{
		if (theDate.Hour < 10)
		{
			theTimeString = theTimeString + "0" + theDate.Hour + ":";
		}
		else
		{
			theTimeString = theTimeString + theDate.Hour + ":";
		}
		if (theDate.Minute < 10)
		{
			theTimeString = theTimeString + "0" + theDate.Minute + ":";
		}
		else
		{
			theTimeString = theTimeString + theDate.Minute + ":";
		}
		if (theDate.Second < 10)
		{
			theTimeString = theTimeString + "0" + theDate.Second;
		}
		else
		{
			theTimeString += theDate.Second;
		}
	}

	public static void PaddedDateString(ref DateTime theDate, ref string theDateString, bool AddComma)
	{
		theDateString = theDate.Year + "-";
		if (theDate.Month >= 10)
		{
			theDateString = theDateString + theDate.Month + "-";
		}
		else
		{
			theDateString = theDateString + "0" + theDate.Month + "-";
		}
		if (theDate.Day < 10)
		{
			theDateString = theDateString + "0" + theDate.Day;
		}
		else
		{
			theDateString += theDate.Day;
		}
		if (AddComma)
		{
			theDateString += ", ";
		}
	}

	public static string GetAllSideLosses_AsString(Scenario theScen)
	{
		string text = "";
		Side[] sides_ReadOnly = theScen.Sides_ReadOnly;
		foreach (Side theSide in sides_ReadOnly)
		{
			text += SideLosses_AsString(theSide, theScen);
		}
		return text;
	}

	public static string SideLosses_AsString(Side theSide, Scenario theScen)
	{
		_Closure$__203-0 arg = default(_Closure$__203-0);
		_Closure$__203-0 CS$<>8__locals8 = new _Closure$__203-0(arg);
		CS$<>8__locals8.$VB$Local_theScen = theScen;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("SIDE: " + theSide.Name + "\r\n===========================================================\r\n\r\n");
		stringBuilder.Append("LOSSES:\r\n-------------------------------\r\n");
		List<KeyValuePair<string, HashSet<string>>> list;
		try
		{
			list = theSide.AAR.Losses.OrderBy([SpecialName] (KeyValuePair<string, HashSet<string>> theKVP) => smethod_32(CS$<>8__locals8.$VB$Local_theScen, theKVP)).ToList();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			list = theSide.AAR.Losses.OrderBy([SpecialName] (KeyValuePair<string, HashSet<string>> theKVP) => smethod_32(CS$<>8__locals8.$VB$Local_theScen, theKVP)).ToList();
			ProjectData.ClearProjectError();
		}
		try
		{
			foreach (KeyValuePair<string, HashSet<string>> item in list)
			{
				if (item.Key.StartsWith("Custom_"))
				{
					stringBuilder.Append(item.Value.ElementAtOrDefault(0).ToString() + "x " + smethod_32(CS$<>8__locals8.$VB$Local_theScen, item) + "\r\n");
				}
				else
				{
					stringBuilder.Append(Conversions.ToString(item.Value.Count) + "x " + smethod_32(CS$<>8__locals8.$VB$Local_theScen, item) + "\r\n");
				}
			}
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			ProjectData.ClearProjectError();
		}
		stringBuilder.Append("\r\n\r\nEXPENDITURES:\r\n------------------\r\n");
		List<KeyValuePair<int, int>> list2;
		try
		{
			list2 = theSide.AAR.Expenditures.OrderBy([SpecialName] (KeyValuePair<int, int> theKVP) => smethod_33(CS$<>8__locals8.$VB$Local_theScen, theKVP)).ToList();
		}
		catch (Exception projectError3)
		{
			ProjectData.SetProjectError(projectError3);
			list2 = theSide.AAR.Expenditures.OrderBy([SpecialName] (KeyValuePair<int, int> theKVP) => smethod_33(CS$<>8__locals8.$VB$Local_theScen, theKVP)).ToList();
			ProjectData.ClearProjectError();
		}
		try
		{
			foreach (KeyValuePair<int, int> item2 in list2)
			{
				if (item2.Value > 0)
				{
					stringBuilder.Append(item2.Value + "x " + smethod_33(CS$<>8__locals8.$VB$Local_theScen, item2) + "\r\n");
				}
			}
		}
		catch (Exception projectError4)
		{
			ProjectData.SetProjectError(projectError4);
			ProjectData.ClearProjectError();
		}
		stringBuilder.Append("\r\n\r\n\r\n");
		return stringBuilder.ToString();
	}

	public static string SideLosses_AsCSV(Side theSide, Scenario theScen)
	{
		_Closure$__204-0 arg = default(_Closure$__204-0);
		_Closure$__204-0 CS$<>8__locals9 = new _Closure$__204-0(arg);
		CS$<>8__locals9.$VB$Local_theScen = theScen;
		StringBuilder stringBuilder = new StringBuilder();
		List<KeyValuePair<string, HashSet<string>>> list;
		try
		{
			list = theSide.AAR.Losses.OrderBy([SpecialName] (KeyValuePair<string, HashSet<string>> theKVP) => smethod_32(CS$<>8__locals9.$VB$Local_theScen, theKVP)).ToList();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			list = theSide.AAR.Losses.OrderBy([SpecialName] (KeyValuePair<string, HashSet<string>> theKVP) => smethod_32(CS$<>8__locals9.$VB$Local_theScen, theKVP)).ToList();
			ProjectData.ClearProjectError();
		}
		try
		{
			foreach (KeyValuePair<string, HashSet<string>> item in list)
			{
				stringBuilder.Append(CS$<>8__locals9.$VB$Local_theScen.TimelineID).Append(",\"").Append(SecurityElement.Escape(theSide.Name))
					.Append("\",");
				stringBuilder.Append(item.Value.Count).Append(",\"").Append(SecurityElement.Escape(smethod_32(CS$<>8__locals9.$VB$Local_theScen, item)));
				stringBuilder.Append("\"");
				stringBuilder.Append("\r\n");
			}
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			ProjectData.ClearProjectError();
		}
		List<KeyValuePair<int, int>> list2;
		try
		{
			list2 = theSide.AAR.Expenditures.OrderBy([SpecialName] (KeyValuePair<int, int> theKVP) => smethod_33(CS$<>8__locals9.$VB$Local_theScen, theKVP)).ToList();
		}
		catch (Exception projectError3)
		{
			ProjectData.SetProjectError(projectError3);
			list2 = theSide.AAR.Expenditures.OrderBy([SpecialName] (KeyValuePair<int, int> theKVP) => smethod_33(CS$<>8__locals9.$VB$Local_theScen, theKVP)).ToList();
			ProjectData.ClearProjectError();
		}
		try
		{
			foreach (KeyValuePair<int, int> item2 in list2)
			{
				stringBuilder.Append(CS$<>8__locals9.$VB$Local_theScen.TimelineID).Append(",\"").Append(SecurityElement.Escape(theSide.Name))
					.Append("\",");
				stringBuilder.Append(item2.Value.ToString()).Append(",\"").Append(SecurityElement.Escape(smethod_33(CS$<>8__locals9.$VB$Local_theScen, item2)));
				stringBuilder.Append("\"");
				stringBuilder.Append("\r\n");
			}
		}
		catch (Exception projectError4)
		{
			ProjectData.SetProjectError(projectError4);
			ProjectData.ClearProjectError();
		}
		return stringBuilder.ToString();
	}

	private static string smethod_32(Scenario scenario_0, KeyValuePair<string, HashSet<string>> keyValuePair_0)
	{
		string[] array = keyValuePair_0.Key.ToString().Split(new char[1] { '_' });
		string result = "";
		try
		{
			switch (array[0].ToString())
			{
			case "Aircraft":
			{
				DataRow[] array2 = scenario_0.Cache_Aircraft_DT.Select("ID=" + array[1]);
				if (array2 != null && array2.Count() > 0)
				{
					result = Misc.RemoveHiddenString(array2[0]["Name"].ToString());
				}
				break;
			}
			case "FacilityAimpointCargo":
			case "FacilityAimpoint":
				result = ((Operators.CompareString(array[1], "0", false) == 0) ? "Non-identifiable land aimpoint - sorry!" : Misc.RemoveHiddenString(DBFunctions.GetMountName(Conversions.ToInteger(array[1]), ref scenario_0)));
				break;
			case "Satellite":
			{
				DataRow[] array2 = scenario_0.Cache_Satellites_DT.Select("ID=" + array[1]);
				if (array2 != null && array2.Count() > 0)
				{
					result = Misc.RemoveHiddenString(array2[0]["Name"].ToString());
				}
				break;
			}
			case "Weapon":
			{
				DataRow[] array2 = scenario_0.Cache_Weapons_DT.Select("ID=" + array[1]);
				if (array2 != null && array2.Count() > 0)
				{
					result = Misc.RemoveHiddenString(array2[0]["Name"].ToString());
				}
				break;
			}
			case "Submarine":
			{
				DataRow[] array2 = scenario_0.Cache_Subs_DT.Select("ID=" + array[1]);
				if (array2 != null && array2.Count() > 0)
				{
					result = Misc.RemoveHiddenString(array2[0]["Name"].ToString());
				}
				break;
			}
			case "Ship":
			{
				DataRow[] array2 = scenario_0.Cache_Ships_DT.Select("ID=" + array[1]);
				if (array2 != null && array2.Count() > 0)
				{
					result = Misc.RemoveHiddenString(array2[0]["Name"].ToString());
				}
				break;
			}
			case "Container":
			{
				CargoContainer cargoContainer = DBFunctions.GetCargoContainer(Conversions.ToInteger(array[1]), ref scenario_0, LoadComponents: false);
				if (cargoContainer != null)
				{
					result = cargoContainer.Name;
				}
				break;
			}
			case "GroundUnit":
			case "Vehicle":
			{
				DataRow[] array2 = scenario_0.Cache_GroundUnits_DT.Select("ID=" + array[1]);
				if (array2 != null && array2.Count() > 0)
				{
					result = Misc.RemoveHiddenString(array2[0]["Name"].ToString());
				}
				break;
			}
			default:
				result = array[1].ToString();
				break;
			case "Facility":
			{
				DataRow[] array2 = scenario_0.Cache_Facilities_DT.Select("ID=" + array[1]);
				if (array2 != null && array2.Count() > 0)
				{
					result = Misc.RemoveHiddenString(array2[0]["Name"].ToString());
				}
				break;
			}
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 20036345354", ex2.Message);
			WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return "";
	}

	private static string smethod_33(Scenario scenario_0, KeyValuePair<int, int> keyValuePair_0)
	{
		DataRow[] array = scenario_0.Cache_Weapons_DT.Select("ID=" + Conversions.ToString(keyValuePair_0.Key));
		if (array.Count() > 0)
		{
			return Misc.RemoveHiddenString(array[0]["Name"].ToString());
		}
		return "Unknown Weapon";
	}

	internal static void ProcessAndTruncateMessageLog(Scenario theScen, bool WriteToLog = false, string LogFilePath = "")
	{
		_Closure$__210-0 arg = default(_Closure$__210-0);
		_Closure$__210-0 CS$<>8__locals10 = new _Closure$__210-0(arg);
		CS$<>8__locals10.$VB$Local_theScen = theScen;
		try
		{
			if (WriteToLog && CS$<>8__locals10.$VB$Local_theScen.SecondIsChangingOnThisPulse)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Clear();
				List<LoggedMessage> unprocessedMessages = GetUnprocessedMessages(CS$<>8__locals10.$VB$Local_theScen);
				int num = unprocessedMessages.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					try
					{
						LoggedMessage loggedMessage = unprocessedMessages[i];
						string text = ((loggedMessage.Side == null) ? "" : ("[" + loggedMessage.Side.Name + "] "));
						stringBuilder.Append(loggedMessage.Timestamp.ToString() + " - " + text + loggedMessage.Text + "\r\n\r\n");
						loggedMessage.ProcessedByClient = true;
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
				}
				StreamWriter streamWriter = ((!string.IsNullOrEmpty(LogFilePath)) ? File.AppendText(LogFilePath) : File.AppendText(Path.Combine(LogsPath, CS$<>8__locals10.$VB$Local_theScen.GameContext.AALog_Name + ".txt")));
				streamWriter.Write(stringBuilder.ToString());
				streamWriter.Close();
			}
			int count = CS$<>8__locals10.$VB$Local_theScen.MessageLog.Count;
			PooledList<LoggedMessage> pooledList = new PooledList<LoggedMessage>(count);
			int num2 = count - 1;
			for (int j = 0; j <= num2; j++)
			{
				try
				{
					LoggedMessage loggedMessage2 = CS$<>8__locals10.$VB$Local_theScen.MessageLog[j];
					if (loggedMessage2 != null)
					{
						pooledList.Add(loggedMessage2);
					}
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			pooledList.Sort(loggedMessageComparer_SortByTimestampDescendingAndIncrementDescending_0);
			count = pooledList.Count;
			hashSet_0.Clear();
			Side[] sides_ReadOnly = CS$<>8__locals10.$VB$Local_theScen.Sides_ReadOnly;
			int num3;
			foreach (Side side in sides_ReadOnly)
			{
				num3 = 0;
				int num4 = count - 1;
				for (int l = 0; l <= num4; l++)
				{
					LoggedMessage loggedMessage = pooledList[l];
					if (loggedMessage.Side != null && loggedMessage.Side == side)
					{
						num3++;
						if (num3 > 500)
						{
							hashSet_0.Add(loggedMessage);
						}
					}
				}
			}
			num3 = 0;
			int num5 = count - 1;
			for (int m = 0; m <= num5; m++)
			{
				LoggedMessage loggedMessage = pooledList[m];
				if (loggedMessage.Side == null && num3 > 500)
				{
					hashSet_0.Add(loggedMessage);
				}
			}
			pooledList.Dispose();
			concurrentQueue_0 = new ConcurrentQueue<int>();
			if (hashSet_0.Count <= 0)
			{
				return;
			}
			Parallel.ForEach(hashSet_0, [SpecialName] (LoggedMessage theMess) =>
			{
				int num6 = IndexOf_Fast(CS$<>8__locals10.$VB$Local_theScen.MessageLog, theMess);
				if (num6 >= 0)
				{
					concurrentQueue_0.Enqueue(num6);
				}
			});
			if (concurrentQueue_0.Count <= 0)
			{
				return;
			}
			List<int> list = new List<int>(concurrentQueue_0);
			list.Sort();
			list.Reverse();
			foreach (int item in list)
			{
				if (item < CS$<>8__locals10.$VB$Local_theScen.MessageLog.Count)
				{
					CS$<>8__locals10.$VB$Local_theScen.MessageLog.RemoveAt(item);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200367", ex2.Message);
			WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static int IndexOf_Fast(this List<LoggedMessage> theList, LoggedMessage theLM)
	{
		int num = theList.Count - 1;
		int num2 = 0;
		while (true)
		{
			if (num2 <= num)
			{
				if (theList[num2] == theLM)
				{
					break;
				}
				num2++;
				continue;
			}
			return -1;
		}
		return num2;
	}

	public static List<LoggedMessage> GetUnprocessedMessages(Scenario theScen)
	{
		int count = theScen.MessageLog.Count;
		list_1.Clear();
		int num = count - 1;
		for (int i = 0; i <= num; i++)
		{
			try
			{
				LoggedMessage loggedMessage = theScen.MessageLog[i];
				if (loggedMessage != null && !loggedMessage.ProcessedByClient)
				{
					list_1.Add(loggedMessage);
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
		return list_1;
	}
}
