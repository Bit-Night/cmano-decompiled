using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using Collections.Pooled;
using Command_Core.DAL;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class ActiveUnit_AirOps
{
	protected ActiveUnit myUnit;

	protected Aircraft[] _LandingQueue;

	protected string[] _LandingQueue_IDs;

	protected bool HasBeenReadied;

	public virtual GlobalVariables.RunwayLengthClass LongestRunwayLengthClass
	{
		get
		{
			GlobalVariables.RunwayLengthClass result;
			try
			{
				GlobalVariables.RunwayLengthClass runwayLengthClass = GlobalVariables.RunwayLengthClass.None;
				AirFacility[] airFacilities_ReadOnly = myUnit.AirFacilities_ReadOnly;
				foreach (AirFacility airFacility in airFacilities_ReadOnly)
				{
					if (airFacility.RunwayLength > runwayLengthClass)
					{
						runwayLengthClass = airFacility.RunwayLength;
					}
				}
				result = runwayLengthClass;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100074", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				int num;
				if (!Debugger.IsAttached)
				{
					num = 1001;
				}
				else
				{
					Debugger.Break();
					num = 1001;
				}
				result = (GlobalVariables.RunwayLengthClass)num;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public virtual GlobalVariables.AircraftSizeClass LargestAircraftSizeForTOL
	{
		get
		{
			GlobalVariables.AircraftSizeClass result;
			try
			{
				GlobalVariables.AircraftSizeClass aircraftSizeClass = GlobalVariables.AircraftSizeClass.None;
				AirFacility[] airFacilities_ReadOnly = myUnit.AirFacilities_ReadOnly;
				foreach (AirFacility airFacility in airFacilities_ReadOnly)
				{
					if ((airFacility.IsRunwayOrPad() || airFacility.IsCatapult()) && airFacility.MaxAircraftSize > aircraftSizeClass)
					{
						aircraftSizeClass = airFacility.MaxAircraftSize;
					}
				}
				result = aircraftSizeClass;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100075", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				int num;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
					num = 0;
				}
				else
				{
					num = 0;
				}
				result = (GlobalVariables.AircraftSizeClass)num;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public virtual PooledList<Aircraft> EmbarkedAircraft_ReadOnly
	{
		get
		{
			PooledList<Aircraft> result;
			try
			{
				PooledList<Aircraft> pooledList = new PooledList<Aircraft>();
				AirFacility[] airFacilities_ReadOnly = myUnit.AirFacilities_ReadOnly;
				for (int i = 0; i < airFacilities_ReadOnly.Length; i = checked(i + 1))
				{
					IEnumerator<KeyValuePair<string, Aircraft>> enumerator = airFacilities_ReadOnly[i].HostedAircraft.GetEnumerator();
					while (enumerator.MoveNext())
					{
						Aircraft value = enumerator.Current.Value;
						pooledList.Add(value);
					}
				}
				result = pooledList;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100076", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = new PooledList<Aircraft>();
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public IEnumerable<AirFacility> RunwayAccessPointsInOperationOnMe_myUnitSize
	{
		get
		{
			IEnumerable<AirFacility> result;
			try
			{
				List<AirFacility> list = new List<AirFacility>();
				AirFacility[] airFacilities_ReadOnly = theHost.AirFacilities_ReadOnly;
				foreach (AirFacility airFacility in airFacilities_ReadOnly)
				{
					if (airFacility.IsTransitFacility() && airFacility.Status == PlatformComponent._ComponentStatus.Operational && airFacility.IsTransitFacility())
					{
						list.Add(airFacility);
					}
				}
				result = list.AsReadOnly();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100079", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = new List<AirFacility>().AsReadOnly();
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public virtual ReadOnlyCollection<Aircraft> AssignedAircraft
	{
		get
		{
			ReadOnlyCollection<Aircraft> result;
			try
			{
				List<Aircraft> list = new List<Aircraft>();
				foreach (ActiveUnit activeUnits_ in myUnit.ParentScen.ActiveUnits_List)
				{
					if (!Information.IsNothing((object)activeUnits_) && activeUnits_.IsAircraft && ((Aircraft)activeUnits_).AirOps.get_AssignedHostUnit(PickNewAssignedHost: true) == myUnit)
					{
						list.Add((Aircraft)activeUnits_);
					}
				}
				result = list.AsReadOnly();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100082", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = new List<Aircraft>().AsReadOnly();
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public IEnumerable<Aircraft> ReadyAircraft
	{
		get
		{
			IEnumerable<Aircraft> result;
			try
			{
				result = EmbarkedAircraft_ReadOnly.Where([SpecialName] (Aircraft AC) =>
				{
					if (AC.AirOps.Condition == Aircraft_AirOps._AirOpsCondition.Parked && AC.AirOps.ConditionTimer == 0f)
					{
						string ReasonForNot = null;
						return AC.IsAvailableForOps(ref ReasonForNot) != 2;
					}
					return false;
				}).AsEnumerable();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100083", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = new List<Aircraft>().AsEnumerable();
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public Aircraft[] LandingQueue_ReadOnly => _LandingQueue;

	public Geopoint_Struct LandingQueueAssemblyPoint
	{
		get
		{
			Geopoint_Struct result2;
			try
			{
				float bearing = Math2.NormalizeBearing(myUnit.CurrentHeading + 180f);
				Geopoint_Struct result = default(Geopoint_Struct);
				Geodesic_EdWilliams.CalcPoint_Williams(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), ref result.Longitude, ref result.Latitude, DistanceToLandingQueueAssemblyPoint, bearing);
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100084", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result2 = new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), 0f);
				ProjectData.ClearProjectError();
			}
			return result2;
		}
	}

	public float DistanceToLandingQueueAssemblyPoint => 10f;

	public virtual void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
		try
		{
			theWriter.WriteStartElement("ActiveUnit_AirOps");
			if (_LandingQueue.Count() > 0)
			{
				theWriter.WriteStartElement("LandingQueue");
				Aircraft[] landingQueue = _LandingQueue;
				foreach (Aircraft aircraft in landingQueue)
				{
					if (aircraft != null)
					{
						theWriter.WriteElementString("ID", aircraft.ObjectID);
					}
				}
				theWriter.WriteEndElement();
			}
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100071", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static ActiveUnit_AirOps FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		ActiveUnit_AirOps result;
		try
		{
			ActiveUnit_AirOps activeUnit_AirOps = new ActiveUnit_AirOps();
			activeUnit_AirOps.myUnit = theAU;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				string name = val.Name;
				if (Operators.CompareString(name, "LandingQueue", false) != 0)
				{
					continue;
				}
				foreach (XmlNode childNode2 in val.ChildNodes)
				{
					XmlNode val2 = childNode2;
					ArrayExtensions.Add(ref activeUnit_AirOps._LandingQueue_IDs, val2.InnerText);
				}
			}
			result = activeUnit_AirOps;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100072", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new ActiveUnit_AirOps();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public virtual void PostDeserializationHousekeeping(ref Scenario theScen, ConcurrentDictionary<string, ScenarioObject> theDictionary, bool GameIsRunning)
	{
		string[] landingQueue_IDs = _LandingQueue_IDs;
		foreach (string text in landingQueue_IDs)
		{
			try
			{
				if (!Information.IsNothing((object)text))
				{
					Aircraft theAC = (Aircraft)theScen.ActiveUnits[text];
					ArrayExtensions.Add(ref _LandingQueue, theAC);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100073", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	private ActiveUnit_AirOps()
	{
		_LandingQueue = new Aircraft[0];
		_LandingQueue_IDs = new string[0];
	}

	internal List<Aircraft> AircraftCurrentlyLandingOnMe_ReadOnly()
	{
		List<Aircraft> list = new List<Aircraft>();
		ActiveUnit[] array;
		try
		{
			array = myUnit.ParentScen.ActiveUnits_List.InternalArray();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			array = myUnit.ParentScen.ActiveUnits_List.InternalArray();
			ProjectData.ClearProjectError();
		}
		List<Aircraft> result;
		if (array != null)
		{
			ActiveUnit[] array2 = array;
			try
			{
				if (array2 == null)
				{
					result = new List<Aircraft>();
				}
				else
				{
					ActiveUnit[] array3 = array2;
					foreach (ActiveUnit activeUnit in array3)
					{
						if (activeUnit == null || !activeUnit.IsAircraft)
						{
							continue;
						}
						Aircraft_AirOps airOps = ((Aircraft)activeUnit).AirOps;
						if (airOps.Condition == Aircraft_AirOps._AirOpsCondition.Landing_PreTouchdown)
						{
							if (airOps.ActualDestinationHost != null && airOps.ActualDestinationHost == myUnit)
							{
								list.Add((Aircraft)activeUnit);
							}
							else if ((airOps.ActualDestinationHost == null || airOps.ActualDestinationHost == myUnit) && airOps.get_AssignedHostUnit(PickNewAssignedHost: true) == myUnit)
							{
								list.Add((Aircraft)activeUnit);
							}
						}
					}
					result = list;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100077", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = new List<Aircraft>();
				ProjectData.ClearProjectError();
			}
		}
		else
		{
			result = new List<Aircraft>();
		}
		return result;
	}

	internal ReadOnlyCollection<AirFacility> RunwayAccessPointCapacityAvailableForThisAircraft_myUnitSize(bool? TakeOff, Aircraft Aircraft, ActiveUnit LandingHost, IEnumerable<AirFacility> OperatingRunwayAccessPoints)
	{
		ReadOnlyCollection<AirFacility> result;
		try
		{
			if (OperatingRunwayAccessPoints.Count() != 0)
			{
				DateTime time = LandingHost.ParentScen.Time;
				List<AirFacility> list = new List<AirFacility>();
				foreach (AirFacility OperatingRunwayAccessPoint in OperatingRunwayAccessPoints)
				{
					if (Aircraft.Size > OperatingRunwayAccessPoint.MaxAircraftSize)
					{
						continue;
					}
					int num = 0;
					num = ((OperatingRunwayAccessPoint.AirFacType == AirFacility._AirFacType.Elevator) ? OperatingRunwayAccessPoint.Capacity : ((Aircraft.Size == OperatingRunwayAccessPoint.MaxAircraftSize) ? 1 : ((Aircraft.Type != Aircraft._AircraftType.Fighter && Aircraft.Type != Aircraft._AircraftType.Attack && Aircraft.Type != Aircraft._AircraftType.Multirole && Aircraft.Type != Aircraft._AircraftType.OECM && Aircraft.Type != Aircraft._AircraftType.WildWeasel && Aircraft.Type != Aircraft._AircraftType.Trainer && Aircraft.Type != Aircraft._AircraftType.Recon) ? 1 : ((SunModule.GetTimeOfDay(LandingHost.ParentScen, time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second, UseCurrentScenarioTime: true, LandingHost.get_Latitude((GlobalVariables.BooleanObject)null), LandingHost.get_Longitude((GlobalVariables.BooleanObject)null), 0.0) != Weather.TTimeOfDayType.tod_Day) ? 1 : 2))));
					if (Information.IsNothing((object)TakeOff))
					{
						foreach (Aircraft value in OperatingRunwayAccessPoint.HostedAircraft.Values)
						{
							int num2;
							if (value.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.TaxyingToTakeOff)
							{
								if (value.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.TaxyingToPark)
								{
									num--;
									if (num == 0)
									{
										break;
									}
									continue;
								}
								num2 = 0;
							}
							else
							{
								num2 = 0;
							}
							num = num2;
							break;
						}
					}
					else if (((!TakeOff) ?? TakeOff) != true)
					{
						foreach (Aircraft value2 in OperatingRunwayAccessPoint.HostedAircraft.Values)
						{
							int num3;
							if (value2.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.TaxyingToPark)
							{
								if (value2.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.TaxyingToFlightDeck)
								{
									if (Aircraft.DBID == value2.DBID || OperatingRunwayAccessPoint.AirFacType == AirFacility._AirFacType.Elevator)
									{
										num--;
										if (num == 0)
										{
											break;
										}
										continue;
									}
									num = 0;
									break;
								}
								num3 = 0;
							}
							else
							{
								num3 = 0;
							}
							num = num3;
							break;
						}
					}
					else
					{
						foreach (Aircraft value3 in OperatingRunwayAccessPoint.HostedAircraft.Values)
						{
							int num4;
							if (value3.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.TaxyingToTakeOff)
							{
								if (value3.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.TaxyingToFlightDeck)
								{
									if (Aircraft.DBID == value3.DBID || OperatingRunwayAccessPoint.AirFacType == AirFacility._AirFacType.Elevator)
									{
										num--;
										if (num == 0)
										{
											break;
										}
										continue;
									}
									num = 0;
									break;
								}
								num4 = 0;
							}
							else
							{
								num4 = 0;
							}
							num = num4;
							break;
						}
					}
					if (num > 0)
					{
						list.Add(OperatingRunwayAccessPoint);
					}
				}
				result = list.AsReadOnly();
			}
			else
			{
				result = null;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100078", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new List<AirFacility>().AsReadOnly();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal ReadOnlyCollection<AirFacility> RunwayCapacityAvailableForThisAircraft_myUnitSize(bool TakeOff, bool TouchDown, Aircraft Aircraft, ActiveUnit LandingHost, bool VerticalTakeOff, IEnumerable<AirFacility> OperatingRunways)
	{
		ReadOnlyCollection<AirFacility> result;
		if (OperatingRunways.Count() == 0)
		{
			result = null;
		}
		else
		{
			DateTime time = LandingHost.ParentScen.Time;
			try
			{
				List<AirFacility> list = new List<AirFacility>();
				List<Aircraft> list2 = new List<Aircraft>();
				if (!TouchDown)
				{
					foreach (Aircraft item in LandingHost.AirOps.AircraftCurrentlyLandingOnMe_ReadOnly())
					{
						list2.Add(item);
					}
				}
				foreach (AirFacility OperatingRunway in OperatingRunways)
				{
					if (OperatingRunway.AirFacType == AirFacility._AirFacType.const_13 && (Aircraft.Type == Aircraft._AircraftType.UAV || Aircraft.Type == Aircraft._AircraftType.UCAV))
					{
						list.Add(OperatingRunway);
					}
					else
					{
						if (Aircraft.Size > OperatingRunway.MaxAircraftSize)
						{
							continue;
						}
						int num = 0;
						num = ((OperatingRunway.AirFacType != AirFacility._AirFacType.Runway) ? 1 : ((Aircraft.Size == OperatingRunway.EffectiveRunwaySize) ? 1 : ((Aircraft.Type != Aircraft._AircraftType.Fighter && Aircraft.Type != Aircraft._AircraftType.Attack && Aircraft.Type != Aircraft._AircraftType.Multirole && Aircraft.Type != Aircraft._AircraftType.OECM && Aircraft.Type != Aircraft._AircraftType.WildWeasel && Aircraft.Type != Aircraft._AircraftType.Trainer && Aircraft.Type != Aircraft._AircraftType.Recon) ? 1 : ((SunModule.GetTimeOfDay(LandingHost.ParentScen, time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second, UseCurrentScenarioTime: true, LandingHost.get_Latitude((GlobalVariables.BooleanObject)null), LandingHost.get_Longitude((GlobalVariables.BooleanObject)null), 0.0) != Weather.TTimeOfDayType.tod_Day) ? 1 : 2))));
						if (OperatingRunway.AirFacType == AirFacility._AirFacType.OpenParking)
						{
							list.Add(OperatingRunway);
							continue;
						}
						if (!TouchDown)
						{
							if (TakeOff)
							{
								foreach (Aircraft value in OperatingRunway.HostedAircraft.Values)
								{
									if (value.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.Landing_PostTouchdown)
									{
										if (Aircraft.DBID == value.DBID)
										{
											num--;
											if (num == 0)
											{
												break;
											}
										}
										else if (((Aircraft)myUnit).AirOps.CanTakeOffFromThisAirFac(OperatingRunway) == Aircraft_AirOps.TakeOffCheck.OK)
										{
											num = 0;
											break;
										}
										continue;
									}
									num = 0;
									break;
								}
							}
							else if (!TouchDown && !TakeOff)
							{
								foreach (Aircraft value2 in OperatingRunway.HostedAircraft.Values)
								{
									if (value2.AirOps.Condition == Aircraft_AirOps._AirOpsCondition.TakingOff)
									{
										num = 0;
										break;
									}
								}
								if (list2.Count > 0 && num > 0)
								{
									List<Aircraft> list3 = new List<Aircraft>();
									foreach (Aircraft item2 in list2)
									{
										if (Aircraft.DBID == item2.DBID)
										{
											list3.Add(item2);
											num--;
											if (num == 0)
											{
												break;
											}
										}
										else if (((Aircraft)myUnit).AirOps.CanLandOnThisAirFac(OperatingRunway, IgnoreOtherAircraft: true) == AirOpsAttemptResult.Success)
										{
											list3.Add(item2);
											num = 0;
											break;
										}
									}
									foreach (Aircraft item3 in list3)
									{
										list2.Remove(item3);
									}
								}
							}
							else if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
						}
						else
						{
							List<Aircraft> list4 = new List<Aircraft>();
							foreach (Aircraft value3 in OperatingRunway.HostedAircraft.Values)
							{
								if (Operators.CompareString(value3.ObjectID, Aircraft.ObjectID, false) == 0)
								{
									list4.Add(value3);
								}
							}
							foreach (Aircraft item4 in list4)
							{
								OperatingRunway.HostedAircraft.Remove(item4.ObjectID);
							}
							foreach (Aircraft value4 in OperatingRunway.HostedAircraft.Values)
							{
								if (value4.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.TakingOff)
								{
									if (Aircraft.DBID == value4.DBID)
									{
										num--;
										if (num == 0)
										{
											break;
										}
									}
									else if (((Aircraft)myUnit).AirOps.CanLandOnThisAirFac(OperatingRunway, IgnoreOtherAircraft: true) == AirOpsAttemptResult.Success)
									{
										num = 0;
										break;
									}
									continue;
								}
								num = 0;
								break;
							}
						}
						if (num > 0)
						{
							list.Add(OperatingRunway);
						}
					}
				}
				result = list.AsReadOnly();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100080", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = new List<AirFacility>().AsReadOnly();
				ProjectData.ClearProjectError();
			}
		}
		return result;
	}

	public ActiveUnit_AirOps(ref ActiveUnit theUnit)
	{
		_LandingQueue = new Aircraft[0];
		_LandingQueue_IDs = new string[0];
		myUnit = theUnit;
	}

	public void LandingQueue_AddAircraft(Aircraft theAircraft)
	{
		try
		{
			if (!_LandingQueue.Contains(theAircraft))
			{
				ArrayExtensions.Add(ref _LandingQueue, theAircraft);
				theAircraft.AirOps.Condition = Aircraft_AirOps._AirOpsCondition.HoldingOnLandingQueue;
				theAircraft.AirOps.ConditionTimer = 5f;
				ReSortLandingQueue();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100085", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void LandingQueue_RemoveAircraft(Aircraft theAircraft)
	{
		ArrayExtensions.Remove(ref _LandingQueue, theAircraft);
		ReSortLandingQueue();
	}

	public void LandingQueue_CleanUp()
	{
		try
		{
			if (_LandingQueue.Count() == 0)
			{
				return;
			}
			List<Aircraft> list = new List<Aircraft>();
			list.AddRange(_LandingQueue);
			foreach (Aircraft item in list)
			{
				if (Information.IsNothing((object)item))
				{
					LandingQueue_RemoveAircraft(item);
				}
				else if (item.IsMorituri)
				{
					LandingQueue_RemoveAircraft(item);
				}
				if (item.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.HoldingOnLandingQueue)
				{
					LandingQueue_RemoveAircraft(item);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100086", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public Aircraft HaveAircraftOnTouchdown()
	{
		Aircraft result;
		try
		{
			AirFacility[] airFacilities_ReadOnly = myUnit.AirFacilities_ReadOnly;
			int num = 0;
			while (true)
			{
				if (num < airFacilities_ReadOnly.Length)
				{
					AirFacility airFacility = airFacilities_ReadOnly[num];
					foreach (Aircraft value in airFacility.HostedAircraft.Values)
					{
						if (value.AirOps.Condition == Aircraft_AirOps._AirOpsCondition.Landing_PostTouchdown)
						{
							result = value;
							goto end_IL_006b;
						}
					}
					num = checked(num + 1);
					continue;
				}
				result = null;
				break;
				continue;
				end_IL_006b:
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100087", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void MakeWayForLandings()
	{
		try
		{
			if (myUnit.IsGroup && !myUnit.HasRunwaysOrPads)
			{
				return;
			}
			for (int i = myUnit.AirFacilities_ReadOnly.Length - 1; i >= 0; i += -1)
			{
				AirFacility airFacility = myUnit.AirFacilities_ReadOnly[i];
				if (!airFacility.IsTransitFacility())
				{
					continue;
				}
				foreach (Aircraft value in airFacility.HostedAircraft.Values)
				{
					if (value.AirOps.Condition == Aircraft_AirOps._AirOpsCondition.TaxyingToPark)
					{
						return;
					}
				}
			}
			int num = 0;
			for (int j = myUnit.AirFacilities_ReadOnly.Length - 1; j >= 0; j += -1)
			{
				AirFacility airFacility = myUnit.AirFacilities_ReadOnly[j];
				if (!airFacility.IsTransitFacility())
				{
					continue;
				}
				foreach (Aircraft value2 in airFacility.HostedAircraft.Values)
				{
					if (value2.AirOps.Condition == Aircraft_AirOps._AirOpsCondition.TaxyingToTakeOff || value2.AirOps.Condition == Aircraft_AirOps._AirOpsCondition.TaxyingToFlightDeck)
					{
						value2.AirOps.Condition = Aircraft_AirOps._AirOpsCondition.TaxyingToPark;
						num++;
						if (num >= airFacility.HostedAircraft.Values.Count)
						{
							return;
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100088", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ReSortLandingQueue()
	{
		if (_LandingQueue.Count() == 0)
		{
			return;
		}
		try
		{
			Aircraft[] landingQueue = (from theAC in _LandingQueue
				where !Information.IsNothing((object)theAC)
				orderby theAC.Kinematics.RemainingEndurance()
				select theAC).ToArray();
			_LandingQueue = landingQueue;
			Aircraft[] landingQueue2 = _LandingQueue;
			foreach (Aircraft aircraft in landingQueue2)
			{
				if (!((float)aircraft.Kinematics.RemainingEndurance(TotalRemainingEndurance: true) < 20f / aircraft.CurrentSpeed * 3600f + 180f))
				{
					break;
				}
				aircraft.AirOps.Condition = Aircraft_AirOps._AirOpsCondition.EmergencyLanding;
			}
			landingQueue = null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200113", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual bool AttemptToRTB(bool ManuallyOrdered, ActiveUnit._ActiveUnitStatus _ActiveUnitStatus_0, bool GroupMembersRTB, ActiveUnit._ActiveUnitStatus GroupMembersRTBStatus, bool DetachFromGroup, bool ClearPlottedCourse)
	{
		return false;
	}

	public void RepairAC(ref Aircraft theAC)
	{
		int num = theAC.AirOps.CalculateETIC();
		if (num > 0)
		{
			theAC.AddMessage(theAC.Name + " (" + theAC.UnitClass + ") has damage that requires an estimated " + Misc.TimeString(num) + " to restore. The repair time will be added to the aircraft's ready-time.", "Air operations", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(theAC.get_Longitude((GlobalVariables.BooleanObject)null), theAC.get_Latitude((GlobalVariables.BooleanObject)null)));
		}
		theAC.Damage.FireIntensity = ActiveUnit_Damage.FireIntensityLevel.NoFire;
		theAC.set_DamagePts(ScenEditAction: false, (Weapon)null, (float)theAC.InitialDP);
		foreach (PlatformComponent item in theAC.Components())
		{
			item.Repair();
		}
		theAC.AirOps.ConditionTimer += num;
	}

	public void RefuelAC_Simple(ref Aircraft theAC)
	{
		try
		{
			PooledList<FuelRec> fuel_ReadOnly = theAC.Fuel_ReadOnly;
			foreach (FuelRec item in fuel_ReadOnly)
			{
				item.CurrentQuantity = item.MaxQuantity;
			}
			fuel_ReadOnly.Dispose();
			theAC.Kinematics.DetermineReserveFuelQty();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100090", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void RefuelAC_Realistic(ref Aircraft theAircraft)
	{
		try
		{
			foreach (FuelRec item in theAircraft.Fuel_ReadOnly)
			{
				if (!(item.CurrentQuantity < (float)item.MaxQuantity))
				{
					continue;
				}
				double num = (float)item.MaxQuantity - item.CurrentQuantity;
				foreach (FuelRec item2 in myUnit.Fuel_ReadOnly)
				{
					if (item2.FuelType == item.FuelType)
					{
						if ((double)item2.CurrentQuantity >= num)
						{
							item.CurrentQuantity = item.MaxQuantity;
							item2.CurrentQuantity = (float)((double)item2.CurrentQuantity - num);
						}
						else
						{
							item.AddFuel(item2.CurrentQuantity);
							item2.CurrentQuantity = 0f;
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100091", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool EnoughOrdnanceInMagazines(ref Aircraft theAircraft, Loadout tempLoadout, int LoadoutID, bool ExcludeOptionalWeapons)
	{
		bool flag = true;
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		bool result;
		try
		{
			WeaponRec[] weapons = tempLoadout.Weapons;
			foreach (WeaponRec weaponRec in weapons)
			{
				int int_ = weaponRec.int_3;
				if (Weapon.WeaponIsNonRivalrous(weaponRec.int_3, ref myUnit.ParentScen))
				{
					continue;
				}
				int maxLoad = weaponRec.MaxLoad;
				if (!ExcludeOptionalWeapons || !weaponRec.OptionalWeapons)
				{
					if (!dictionary.ContainsKey(int_))
					{
						dictionary.Add(int_, maxLoad);
					}
					else
					{
						dictionary[int_] += maxLoad;
					}
				}
			}
			foreach (KeyValuePair<int, int> item in dictionary)
			{
				int num = theAircraft.AirOps.CurrentHostUnit.Weaponry.HowManyOfThisWeaponOnMagazines(item.Key);
				if (item.Value > num)
				{
					flag = false;
				}
			}
			result = flag;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100092", "");
			GameGeneral.WriteExceptionsToLog(ex2);
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

	public string OutfitAC(ref Aircraft theAircraft, int LoadoutID, int OldLoadoutID, bool ReadyImmediately, bool ExcludeOptionalWeapons, bool DrawWeaponsFromMagazine, bool ManualAction, bool PlayerFeedback)
	{
		string result;
		try
		{
			Aircraft_AirOps theAO = theAircraft.AirOps;
			bool flag = false;
			int num;
			if (Information.IsNothing((object)theAircraft.Loadout))
			{
				num = 1;
			}
			else
			{
				if (!Information.IsNothing((object)theAircraft.Loadout.Weapons))
				{
					theAO.UnloadStores();
				}
				if (theAircraft.Loadout.Weapons.Count() > 0)
				{
					flag = true;
					num = 1;
				}
				else
				{
					num = 1;
				}
			}
			bool flag2 = (byte)num != 0;
			if (LoadoutID != 0)
			{
				if (!flag)
				{
					theAircraft.Loadout = null;
					theAircraft.Weaponry.ClearCachedWeapons();
					if (DrawWeaponsFromMagazine)
					{
						Loadout theLoadout = new Loadout(LoadoutID, "tempLoadout", 1, 1, 1, 1, Loadout.LoadoutRole.None, Loadout._LoadoutDayNight.DayOnly, Loadout._LoadoutWeather.None, 0f, 0, 0, theReBuddyIllum: false, ExcludeOptionalWeapons, theQuickTurnaround: false, 0, 0, 0, 0, Loadout._LoadoutDayNight.DayNight, Doctrine._WeaponState.LoadoutSetting);
						DBFunctions.GetLoadoutWeapons(ref theAircraft.ParentScen, ref theLoadout, LoadoutID, ExcludeOptionalWeapons);
						if (!EnoughOrdnanceInMagazines(ref theAircraft, theLoadout, LoadoutID, ExcludeOptionalWeapons))
						{
							flag2 = false;
						}
						if (!ExcludeOptionalWeapons && !flag2)
						{
							ExcludeOptionalWeapons = true;
							theLoadout = null;
							theLoadout = new Loadout(LoadoutID, "tempLoadout", 1, 1, 1, 1, Loadout.LoadoutRole.None, Loadout._LoadoutDayNight.DayOnly, Loadout._LoadoutWeather.None, 0f, 0, 0, theReBuddyIllum: false, ExcludeOptionalWeapons: true, theQuickTurnaround: false, 0, 0, 0, 0, Loadout._LoadoutDayNight.DayNight, Doctrine._WeaponState.LoadoutSetting);
							DBFunctions.GetLoadoutWeapons(ref theAircraft.ParentScen, ref theLoadout, LoadoutID, ExcludeOptionalWeapons: true);
							if (!EnoughOrdnanceInMagazines(ref theAircraft, theLoadout, LoadoutID, ExcludeOptionalWeapons: true))
							{
								flag2 = false;
							}
							else
							{
								flag2 = true;
								string text = "";
								if (Operators.CompareString(theAircraft.Name, theAircraft.UnitClass, false) != 0)
								{
									text = " (" + theAircraft.UnitClass + ")";
								}
								if (ManualAction)
								{
									GameGeneral.SendMessageBoxToUI("Aircraft: " + theAircraft.Name + text + " was re-equipped without optional weapons because not enough weapons were available.", ((ActiveUnit)theAircraft).get_UnitSide(SetSideOnly: false));
								}
								theAircraft.AddMessage("Aircraft: " + theAircraft.Name + text + " was re-equipped without optional weapons because not enough weapons were available.", "Air operations", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(theAO.CurrentHostUnit.get_Longitude((GlobalVariables.BooleanObject)null), theAO.CurrentHostUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
							}
						}
						if (flag2)
						{
							WeaponRec[] weapons = theLoadout.Weapons;
							foreach (WeaponRec weaponRec in weapons)
							{
								int currentLoad = weaponRec.CurrentLoad;
								for (int j = 1; j <= currentLoad; j++)
								{
									if (!Weapon.WeaponIsNonRivalrous(weaponRec.int_3, ref myUnit.ParentScen))
									{
										ActiveUnit_Weaponry weaponry = myUnit.Weaponry;
										int int_ = weaponRec.int_3;
										float MagazineReloadTime = 0f;
										weaponry.RemoveWeaponFromMagazines(int_, LoadingAircraft: true, ref MagazineReloadTime);
									}
								}
							}
						}
					}
				}
			}
			else if (!ReadyImmediately)
			{
				theAO.Condition = Aircraft_AirOps._AirOpsCondition.Readying;
				if (theAO.ConditionTimer < 1800f)
				{
					theAO.ConditionTimer = 1800f;
				}
			}
			else
			{
				theAO.ConditionTimer = 0f;
			}
			foreach (Mount mount in theAircraft.Mounts)
			{
				foreach (WeaponRec mountWeapon in mount.MountWeapons)
				{
					mountWeapon.CurrentLoad = mountWeapon.MaxLoad;
				}
			}
			if (flag)
			{
				if (theAircraft.Loadout != null)
				{
					WeaponRec[] weapons2 = theAircraft.Loadout.Weapons;
					foreach (WeaponRec weaponRec2 in weapons2)
					{
						if (weaponRec2.CurrentLoad >= weaponRec2.MaxLoad)
						{
							continue;
						}
						int num2 = weaponRec2.MaxLoad - weaponRec2.CurrentLoad;
						for (int l = 1; l <= num2; l++)
						{
							if (weaponRec2.CurrentLoad >= weaponRec2.MaxLoad)
							{
								continue;
							}
							if (!Weapon.WeaponIsNonRivalrous(weaponRec2.int_3, ref myUnit.ParentScen))
							{
								ActiveUnit_Weaponry weaponry2 = myUnit.Weaponry;
								int int_2 = weaponRec2.int_3;
								float MagazineReloadTime = 0f;
								if (string.CompareOrdinal(weaponry2.RemoveWeaponFromMagazines(int_2, LoadingAircraft: true, ref MagazineReloadTime), "OK") == 0)
								{
									weaponRec2.CurrentLoad++;
								}
							}
							else
							{
								weaponRec2.CurrentLoad++;
							}
						}
						flag = false;
					}
				}
			}
			else if (flag2)
			{
				DBFunctions.GetLoadout(ref theAircraft, LoadoutID, ExcludeOptionalWeapons);
			}
			else
			{
				theAircraft.Loadout = DBFunctions.GetReserveLoadoutForThisAircraft(ref theAircraft.ParentScen, theAircraft.DBID);
				if (Information.IsNothing((object)theAircraft.Loadout))
				{
					theAircraft.Loadout = DBFunctions.GetMaintenanceLoadoutForThisAircraft(ref theAircraft.ParentScen, theAircraft.DBID);
				}
				theAO.UpdateQuickTurnaroundSettings_Reset(ref theAO);
			}
			if (ReadyImmediately)
			{
				theAO.ConditionTimer = 0f;
			}
			else if (LoadoutID == OldLoadoutID || !theAircraft.Loadout.HasIdenticalWeapons(theAircraft.ParentScen, OldLoadoutID, ExcludeOptionalWeapons))
			{
				if (!flag)
				{
					byte? b = (byte?)theAircraft.Doctrine.get_AirOpsTempo(theAircraft.ParentScen, MultipleUnits: false, UnitIsOperating: false, ViaDoctrineForm: false, ViaRightColumn: false);
					bool? flag3 = ((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0));
					if ((flag3 ?? true) && !theAO.QuickTurnaround_Enabled && flag3.HasValue)
					{
						if (LoadoutID != OldLoadoutID || !ManualAction)
						{
							float num3 = 0f;
							if (theAO.ConditionTimer > 0f)
							{
								if (OldLoadoutID != 0 && theAO.Condition == Aircraft_AirOps._AirOpsCondition.Readying)
								{
									int num4 = DBFunctions.GetLoadout(ref theAircraft.ParentScen, OldLoadoutID, ExcludeOptionalWeapons: false, GetPayloadWeight: false).ReadyTime * 60;
									if (theAO.ConditionTimer > (float)num4)
									{
										num3 = theAO.ConditionTimer - (float)num4;
									}
								}
								else if (theAO.Condition == Aircraft_AirOps._AirOpsCondition.Parked)
								{
									num3 = theAO.ConditionTimer;
								}
							}
							theAO.Condition = Aircraft_AirOps._AirOpsCondition.Readying;
							theAO.ConditionTimer = (float)(theAircraft.Loadout.ReadyTime * 60) + num3;
						}
					}
					else
					{
						b = (byte?)theAircraft.Doctrine.get_AirOpsTempo(theAircraft.ParentScen, MultipleUnits: false, UnitIsOperating: false, ViaDoctrineForm: false, ViaRightColumn: false);
						bool? flag5;
						bool? flag4 = (flag5 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)));
						flag3 = ((flag4.HasValue && flag5 != true) ? new bool?(false) : ((theAO.ConditionTimer < (float)(theAircraft.Loadout.ReadyTime_Sustained * 60)) & flag5));
						if ((flag3 ?? true) && !theAO.QuickTurnaround_Enabled && flag3.HasValue)
						{
							if (LoadoutID != OldLoadoutID || !ManualAction)
							{
								theAO.Condition = Aircraft_AirOps._AirOpsCondition.Readying;
								theAO.ConditionTimer = theAircraft.Loadout.ReadyTime_Sustained * 60;
							}
						}
						else if (theAO.QuickTurnaround_Enabled && (LoadoutID != OldLoadoutID || !ManualAction))
						{
							int? elementState = theAircraft.Doctrine.GetElementState(Doctrine.DoctrineItem_E.QuickTurnAroundForAircraft);
							if ((elementState.HasValue ? new bool?(elementState == 2) : ((bool?)null)) != true)
							{
								if (ManualAction)
								{
									if (theAO.QuickTurnaround_SortiesFlown >= theAircraft.Loadout.QuickTurnaround_MaxSorties)
									{
										theAO.UpdateQuickTurnaroundSettings_StepDown(ref theAO, ref theAircraft);
									}
									theAO.Condition = Aircraft_AirOps._AirOpsCondition.Readying;
									if (theAO.QuickTurnaround_SortiesFlown == 0)
									{
										b = (byte?)theAircraft.Doctrine.get_AirOpsTempo(theAircraft.ParentScen, MultipleUnits: false, UnitIsOperating: false, ViaDoctrineForm: false, ViaRightColumn: false);
										if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) != true)
										{
											theAO.ConditionTimer = theAircraft.Loadout.ReadyTime * 60;
										}
										else
										{
											theAO.ConditionTimer = theAircraft.Loadout.ReadyTime_Sustained * 60;
										}
									}
									else
									{
										theAO.ConditionTimer = theAircraft.Loadout.QuickTurnaround_ReadyTime * 60;
									}
								}
							}
							else
							{
								theAO.UpdateQuickTurnaroundSettings_StepDown(ref theAO, ref theAircraft);
								string text2 = "";
								if (Operators.CompareString(theAircraft.Name, theAircraft.UnitClass, false) != 0)
								{
									text2 = " (" + theAircraft.UnitClass + ")";
								}
								theAircraft.AddMessage(theAircraft.Name + text2 + " has flown " + Conversions.ToString(theAO.QuickTurnaround_SortiesFlown) + " of " + Conversions.ToString(theAircraft.Loadout.QuickTurnaround_MaxSorties) + " sorties. Total airborne time is " + Misc.TimeString((long)Math.Round(theAO.QuickTurnaround_AirborneTime_Flown)) + " of allowed " + Misc.TimeString(theAircraft.Loadout.QuickTurnaround_AirborneTime * 60) + ". The aircraft loadout is set up for Quick Turnaround however the Doctrine settings say No Quick Turnaround, and the aircraft stands down!", "Air operations", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(theAO.CurrentHostUnit.get_Longitude((GlobalVariables.BooleanObject)null), theAO.CurrentHostUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
								b = (byte?)theAircraft.Doctrine.get_AirOpsTempo(theAircraft.ParentScen, MultipleUnits: false, UnitIsOperating: false, ViaDoctrineForm: false, ViaRightColumn: false);
								if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) != true)
								{
									theAO.Condition = Aircraft_AirOps._AirOpsCondition.Readying;
									theAO.ConditionTimer = theAircraft.Loadout.ReadyTime_Sustained * 60;
								}
								else
								{
									theAO.Condition = Aircraft_AirOps._AirOpsCondition.Readying;
									theAO.ConditionTimer = theAircraft.Loadout.ReadyTime * 60;
								}
							}
						}
					}
					if (!ManualAction && theAO.QuickTurnaround_Enabled)
					{
						int? elementState2 = theAircraft.Doctrine.GetElementState(Doctrine.DoctrineItem_E.QuickTurnAroundForAircraft);
						int? elementState = elementState2;
						if ((elementState.HasValue ? new bool?(elementState.GetValueOrDefault() == 0) : ((bool?)null)) != true)
						{
							elementState = elementState2;
							if ((elementState.HasValue ? new bool?(elementState == 1) : ((bool?)null)) == true)
							{
								Loadout loadout = theAircraft.Loadout;
								if (loadout.IsAAW || loadout.IsSupportOrPatrol || loadout.IsASW)
								{
									UpdateQuickTurnaroundParams(ref theAO, ref theAircraft);
								}
							}
						}
						else
						{
							UpdateQuickTurnaroundParams(ref theAO, ref theAircraft);
						}
					}
				}
				else
				{
					theAO.Condition = Aircraft_AirOps._AirOpsCondition.Readying;
					theAO.ConditionTimer = 1800f;
				}
			}
			if (!ReadyImmediately && theAO.OverrideConditionTimer > -1f)
			{
				theAO.ConditionTimer = theAO.OverrideConditionTimer;
			}
			theAO.OverrideConditionTimer = -1f;
			theAircraft.AirborneTime = 0f;
			if (!flag2)
			{
				string text3 = "";
				if (Operators.CompareString(theAircraft.Name, theAircraft.UnitClass, false) != 0)
				{
					text3 = " (" + theAircraft.UnitClass + ")";
				}
				if (PlayerFeedback)
				{
					if (ManualAction)
					{
						GameGeneral.SendMessageBoxToUI("Aircraft: " + theAircraft.Name + text3 + " was not equipped with intended loadout as one or more of the primary stores for that loadout is not available. Reverting to reserve (clean) loadout.", ((ActiveUnit)theAircraft).get_UnitSide(SetSideOnly: false));
					}
					theAircraft.AddMessage("Aircraft: " + theAircraft.Name + text3 + " was not equipped with intended loadout as one or more of the primary stores for that loadout is not available. Reverting to reserve (clean) loadout.", "Air operations", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(theAO.CurrentHostUnit.get_Longitude((GlobalVariables.BooleanObject)null), theAO.CurrentHostUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				result = "Incomplete";
			}
			else
			{
				if (theAO.ConditionTimer > 0f)
				{
					theAO.Condition = Aircraft_AirOps._AirOpsCondition.Readying;
				}
				result = "OK";
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100093", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = "Error";
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void UpdateQuickTurnaroundParams(ref Aircraft_AirOps theAO, ref Aircraft theAC)
	{
		if (theAO.QuickTurnaround_SortiesFlown == 1)
		{
			byte? b = (byte?)theAC.Doctrine.get_AirOpsTempo(theAC.ParentScen, MultipleUnits: false, UnitIsOperating: false, ViaDoctrineForm: false, ViaRightColumn: false);
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) != true)
			{
				theAO.QuickTurnaround_TimePentalty += theAC.Loadout.ReadyTime;
			}
			else
			{
				theAO.QuickTurnaround_TimePentalty += theAC.Loadout.ReadyTime_Sustained;
			}
		}
		else
		{
			theAO.QuickTurnaround_TimePentalty += theAC.Loadout.QuickTurnaround_AdditionalTimePenalty;
		}
		DateTime time = theAC.ParentScen.Time;
		bool use_DST = theAC.ParentScen.Use_DST;
		string dST_Start = theAC.ParentScen.DST_Start;
		string dST_End = theAC.ParentScen.DST_End;
		Weather.TTimeOfDayType timeOfDay = SunModule.GetTimeOfDay(theAC.ParentScen, time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second, UseCurrentScenarioTime: true, theAO.CurrentHostUnit.get_Latitude((GlobalVariables.BooleanObject)null), theAO.CurrentHostUnit.get_Longitude((GlobalVariables.BooleanObject)null), theAO.CurrentHostUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
		if (theAO.QuickTurnaround_SortiesFlown >= theAO.QuickTurnaround_SortiesTotal)
		{
			theAO.UpdateQuickTurnaroundSettings_StepDown(ref theAO, ref theAC);
			string text = "";
			if (Operators.CompareString(theAC.Name, theAC.UnitClass, false) != 0)
			{
				text = " (" + theAC.UnitClass + ")";
			}
			theAC.AddMessage(theAC.Name + text + " has flown all available quick turnaround sorties and will stand down.", "Air operations", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(theAO.CurrentHostUnit.get_Longitude((GlobalVariables.BooleanObject)null), theAO.CurrentHostUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
		}
		else if ((double)(theAC.Loadout.QuickTurnaround_AirborneTime * 60) / (double)theAO.QuickTurnaround_SortiesTotal <= (double)(theAO.QuickTurnaround_AirborneTime_Flown / (float)theAO.QuickTurnaround_SortiesFlown))
		{
			bool flag = false;
			if (theAO.QuickTurnaround_SortiesFlown <= theAO.QuickTurnaround_SortiesTotal && theAO.QuickTurnaround_SortiesFlown > 0)
			{
				float num = theAO.QuickTurnaround_AirborneTime_Flown / (float)theAO.QuickTurnaround_SortiesFlown;
				if (num + theAO.QuickTurnaround_AirborneTime_Flown > (float)(theAC.Loadout.QuickTurnaround_AirborneTime * 60) && !Information.IsNothing((object)theAC.Loadout))
				{
					string text2 = "";
					if (Operators.CompareString(theAC.Name, theAC.UnitClass, false) != 0)
					{
						text2 = " (" + theAC.UnitClass + ")";
					}
					theAC.AddMessage(theAC.Name + text2 + " has flown " + Conversions.ToString(theAO.QuickTurnaround_SortiesFlown) + " of " + Conversions.ToString(theAC.Loadout.QuickTurnaround_MaxSorties) + " sorties. Total airborne time is " + Misc.TimeString((long)Math.Round(theAO.QuickTurnaround_AirborneTime_Flown)) + " of allowed " + Misc.TimeString(theAC.Loadout.QuickTurnaround_AirborneTime * 60) + ". Average airborne time for the completed sorties is " + Misc.TimeString((long)Math.Round(num)) + " which is greater than the remaining allowed airborne time. Because of this the aircraft needs to stand down.", "Air operations", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(theAO.CurrentHostUnit.get_Longitude((GlobalVariables.BooleanObject)null), theAO.CurrentHostUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
					theAO.UpdateQuickTurnaroundSettings_StepDown(ref theAO, ref theAC);
					flag = true;
				}
			}
			if (!flag)
			{
				theAO.UpdateQuickTurnaroundSettings_ContinueFlying(ref theAO, ref theAC);
			}
		}
		else if (theAC.Loadout.QuickTurnaround_TimeofDay == Loadout._LoadoutDayNight.DayOnly && timeOfDay == Weather.TTimeOfDayType.tod_Night)
		{
			string text3 = "";
			if (Operators.CompareString(theAC.Name, theAC.UnitClass, false) != 0)
			{
				text3 = " (" + theAC.UnitClass + ")";
			}
			theAC.AddMessage(theAC.Name + text3 + " has flown " + Conversions.ToString(theAO.QuickTurnaround_SortiesFlown) + " of " + Conversions.ToString(theAC.Loadout.QuickTurnaround_MaxSorties) + " sorties. Total airborne time is " + Misc.TimeString((long)Math.Round(theAO.QuickTurnaround_AirborneTime_Flown)) + " of allowed " + Misc.TimeString(theAC.Loadout.QuickTurnaround_AirborneTime * 60) + ". The loadout is day-only quick turnaround capable and it is currently night. Because of this the aircraft needs to stand down.", "Air operations", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(theAO.CurrentHostUnit.get_Longitude((GlobalVariables.BooleanObject)null), theAO.CurrentHostUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
			theAO.UpdateQuickTurnaroundSettings_StepDown(ref theAO, ref theAC);
		}
		else if (theAC.Loadout.QuickTurnaround_TimeofDay == Loadout._LoadoutDayNight.NightOnly && timeOfDay == Weather.TTimeOfDayType.tod_Day)
		{
			string text4 = "";
			if (Operators.CompareString(theAC.Name, theAC.UnitClass, false) != 0)
			{
				text4 = " (" + theAC.UnitClass + ")";
			}
			theAC.AddMessage(theAC.Name + text4 + " has flown " + Conversions.ToString(theAO.QuickTurnaround_SortiesFlown) + " of " + Conversions.ToString(theAC.Loadout.QuickTurnaround_MaxSorties) + " sorties. Total airborne time is " + Misc.TimeString((long)Math.Round(theAO.QuickTurnaround_AirborneTime_Flown)) + " of allowed " + Misc.TimeString(theAC.Loadout.QuickTurnaround_AirborneTime * 60) + ". The loadout is night-only quick turnaround capable and it is currently day. Because of this the aircraft needs to stand down.", "Air operations", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(theAO.CurrentHostUnit.get_Longitude((GlobalVariables.BooleanObject)null), theAO.CurrentHostUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
			theAO.UpdateQuickTurnaroundSettings_StepDown(ref theAO, ref theAC);
		}
		else if ((theAC.Loadout.QuickTurnaround_TimeofDay == Loadout._LoadoutDayNight.DayOnly || theAC.Loadout.QuickTurnaround_TimeofDay == Loadout._LoadoutDayNight.NightOnly) && timeOfDay == Weather.TTimeOfDayType.tod_Twilight)
		{
			if (theAC.Loadout.QuickTurnaround_TimeofDay == Loadout._LoadoutDayNight.NightOnly && Misc.LocalTime(time, theAO.CurrentHostUnit.get_Longitude((GlobalVariables.BooleanObject)null), use_DST, dST_Start, dST_End).Hour < 12)
			{
				string text5 = "";
				if (Operators.CompareString(theAC.Name, theAC.UnitClass, false) != 0)
				{
					text5 = " (" + theAC.UnitClass + ")";
				}
				theAC.AddMessage(theAC.Name + text5 + " has flown " + Conversions.ToString(theAO.QuickTurnaround_SortiesFlown) + " of " + Conversions.ToString(theAC.Loadout.QuickTurnaround_MaxSorties) + " sorties. Total airborne time is " + Misc.TimeString((long)Math.Round(theAO.QuickTurnaround_AirborneTime_Flown)) + " of allowed " + Misc.TimeString(theAC.Loadout.QuickTurnaround_AirborneTime * 60) + ". The loadout is night-only quick turnaround capable and it is currently dawn. Because of this the aircraft needs to stand down.", "Air operations", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(theAO.CurrentHostUnit.get_Longitude((GlobalVariables.BooleanObject)null), theAO.CurrentHostUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				theAO.UpdateQuickTurnaroundSettings_StepDown(ref theAO, ref theAC);
			}
			else if (theAC.Loadout.QuickTurnaround_TimeofDay == Loadout._LoadoutDayNight.DayOnly && Misc.LocalTime(time, theAO.CurrentHostUnit.get_Longitude((GlobalVariables.BooleanObject)null), use_DST, dST_Start, dST_End).Hour > 12)
			{
				string text6 = "";
				if (Operators.CompareString(theAC.Name, theAC.UnitClass, false) != 0)
				{
					text6 = " (" + theAC.UnitClass + ")";
				}
				theAC.AddMessage(theAC.Name + text6 + " has flown " + Conversions.ToString(theAO.QuickTurnaround_SortiesFlown) + " of " + Conversions.ToString(theAC.Loadout.QuickTurnaround_MaxSorties) + " sorties. Total airborne time is " + Misc.TimeString((long)Math.Round(theAO.QuickTurnaround_AirborneTime_Flown)) + " of allowed " + Misc.TimeString(theAC.Loadout.QuickTurnaround_AirborneTime * 60) + ". The loadout is day-only quick turnaround capable and it is currently dusk. Because of this the aircraft needs to stand down.", "Air operations", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(theAO.CurrentHostUnit.get_Longitude((GlobalVariables.BooleanObject)null), theAO.CurrentHostUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				theAO.UpdateQuickTurnaroundSettings_StepDown(ref theAO, ref theAC);
			}
			else
			{
				theAO.UpdateQuickTurnaroundSettings_ContinueFlying(ref theAO, ref theAC);
			}
		}
		else
		{
			theAO.UpdateQuickTurnaroundSettings_ContinueFlying(ref theAO, ref theAC);
		}
	}

	public bool TransitFacilitiesAreOperative()
	{
		bool result;
		try
		{
			AirFacility[] airFacilities_ReadOnly = myUnit.AirFacilities_ReadOnly;
			int num = 0;
			while (true)
			{
				if (num < airFacilities_ReadOnly.Length)
				{
					AirFacility airFacility = airFacilities_ReadOnly[num];
					if (!airFacility.IsTransitFacility() || airFacility.Status != PlatformComponent._ComponentStatus.Operational)
					{
						num = checked(num + 1);
						continue;
					}
					result = true;
					break;
				}
				result = false;
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100094", "");
			GameGeneral.WriteExceptionsToLog(ex2);
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

	public virtual AirOpsAttemptResult CanHostThisAircraft(Aircraft theAircraft)
	{
		AirOpsAttemptResult result;
		try
		{
			int num;
			if (theAircraft.RunwayLengthNeeded == GlobalVariables.RunwayLengthClass.ManualLaunch)
			{
				result = AirOpsAttemptResult.Success;
			}
			else if (!((theAircraft.RunwayLengthNeeded == GlobalVariables.RunwayLengthClass.CatapultLaunched) & (LongestRunwayLengthClass != GlobalVariables.RunwayLengthClass.None)))
			{
				if (!myUnit.IsShip)
				{
					num = 0;
					goto IL_0169;
				}
				Ship._ShipCategory category = ((Ship)myUnit).Category;
				if (category == Ship._ShipCategory.MobileOffshoreBase)
				{
					result = AirOpsAttemptResult.Success;
				}
				else if (theAircraft.Category == Aircraft._AircraftCategory.CarrierCapable && category != Ship._ShipCategory.AviationShip && category != Ship._ShipCategory.SurfaceCombatantAviation && theAircraft.Size > GlobalVariables.AircraftSizeClass.Small)
				{
					result = AirOpsAttemptResult.Too_large_for_carrier;
				}
				else if (theAircraft.RunwayLengthNeeded == GlobalVariables.RunwayLengthClass.VTOL && !theAircraft.IsHelicopter && !theAircraft.isUAV && theAircraft.Size != GlobalVariables.AircraftSizeClass.Small && !theAircraft.IsLighterThanAir && category != Ship._ShipCategory.AviationShip && category != Ship._ShipCategory.SurfaceCombatantAviation)
				{
					result = AirOpsAttemptResult.Unable_to_host_VTOL;
				}
				else
				{
					if (theAircraft.Category != Aircraft._AircraftCategory.FixedWing || theAircraft.RunwayLengthNeeded == GlobalVariables.RunwayLengthClass.VTOL || ((theAircraft.Type == Aircraft._AircraftType.UAV || theAircraft.Type == Aircraft._AircraftType.UCAV) && theAircraft.RunwayLengthNeeded <= LongestRunwayLengthClass))
					{
						goto IL_0168;
					}
					if (theAircraft.RunwayLengthNeeded == GlobalVariables.RunwayLengthClass.Between_1_250m)
					{
						if (myUnit.AirOps.ParkingSpace_Free(ref myUnit.ParentScen) > (double)(int)theAircraft.Size)
						{
							goto IL_0168;
						}
						result = AirOpsAttemptResult.No_operational_free_parking_space;
					}
					else
					{
						result = AirOpsAttemptResult.Unsufficient_runway_length;
					}
				}
			}
			else
			{
				result = AirOpsAttemptResult.Success;
			}
			goto end_IL_0001;
			IL_0169:
			bool flag = (byte)num != 0;
			int num2 = myUnit.AirFacilities_ReadOnly.Length - 1;
			while (true)
			{
				if (num2 >= 0)
				{
					AirFacility airFacility = myUnit.AirFacilities_ReadOnly[num2];
					if (airFacility.Status != PlatformComponent._ComponentStatus.Operational || !airFacility.IsParkingFacility() || airFacility.IsRunwayOrPad() || airFacility.CanHostThisAircraft_BySize(theAircraft) != AirOpsAttemptResult.Success)
					{
						num2 += -1;
						continue;
					}
					result = AirOpsAttemptResult.Success;
					break;
				}
				int num4;
				if (!flag)
				{
					int num3 = myUnit.AirFacilities_ReadOnly.Length - 1;
					while (true)
					{
						if (num3 >= 0)
						{
							AirFacility airFacility = myUnit.AirFacilities_ReadOnly[num3];
							if (airFacility.Status != PlatformComponent._ComponentStatus.Operational || !theAircraft.IsHelicopter || !airFacility.IsPad() || airFacility.CanHostThisAircraft_BySize(theAircraft) != AirOpsAttemptResult.Success)
							{
								num3 += -1;
								continue;
							}
							result = AirOpsAttemptResult.Success;
							goto end_IL_01b3;
						}
						num4 = 1;
						break;
					}
				}
				else
				{
					num4 = 1;
				}
				result = (AirOpsAttemptResult)num4;
				break;
				continue;
				end_IL_01b3:
				break;
			}
			goto end_IL_0001;
			IL_0168:
			num = 0;
			goto IL_0169;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100095", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num5;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num5 = 6;
			}
			else
			{
				num5 = 6;
			}
			result = (AirOpsAttemptResult)num5;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public virtual bool CanThisAircraftLandHere(Aircraft theAircraft)
	{
		bool result;
		try
		{
			int num = myUnit.AirFacilities_ReadOnly.Length - 1;
			while (true)
			{
				if (num >= 0)
				{
					AirFacility airFacility = myUnit.AirFacilities_ReadOnly[num];
					if (airFacility.Status != PlatformComponent._ComponentStatus.Operational || !airFacility.IsRunwayOrPad() || airFacility.ParkingSpace_Free < (int)theAircraft.Size)
					{
						num += -1;
						continue;
					}
					result = true;
					break;
				}
				result = false;
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100096", "");
			GameGeneral.WriteExceptionsToLog(ex2);
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

	public void AddThisAircraft(Aircraft theAircraft, bool GameIsRunning)
	{
		try
		{
			if (myUnit.AirOps.EmbarkedAircraft_ReadOnly.Contains(theAircraft))
			{
				return;
			}
			AirFacility airFacility = WhichFacilityCanHostThis(theAircraft);
			if (Information.IsNothing((object)airFacility))
			{
				if (!GameIsRunning)
				{
					GameGeneral.SendMessageBoxToUI("Aircraft parking facilities on " + myUnit.Name + " are overfilled. Please contact the scenario author and ask to have the number of aircraft reduced to match the actual parking capacity.", myUnit.get_UnitSide(SetSideOnly: false));
				}
				AirFacility[] airFacilities_ReadOnly = myUnit.AirFacilities_ReadOnly;
				foreach (AirFacility airFacility2 in airFacilities_ReadOnly)
				{
					if (airFacility2.IsParkingFacility())
					{
						airFacility = airFacility2;
						break;
					}
				}
			}
			theAircraft.AirOps.HostAirFacility = airFacility;
			theAircraft.AirOps.Condition = Aircraft_AirOps._AirOpsCondition.Parked;
			theAircraft.AirOps.set_AssignedHostUnit(PickNewAssignedHost: false, myUnit);
			theAircraft.AirOps.CurrentHostUnit = myUnit;
			theAircraft.ParentScen.list_8.Add(theAircraft);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100097", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public double ParkingSpace_Free(ref Scenario theScen)
	{
		double result;
		try
		{
			AirFacility[] airFacilities_ReadOnly = myUnit.AirFacilities_ReadOnly;
			int num = default(int);
			foreach (AirFacility airFacility in airFacilities_ReadOnly)
			{
				if (airFacility.Status == PlatformComponent._ComponentStatus.Operational)
				{
					num += airFacility.ParkingSpace_Free;
				}
			}
			result = num;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100098", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = 0.0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public bool IsParkingSpaceAvailable(ref Scenario theScen, Aircraft theAircraft)
	{
		return ParkingSpace_Free(ref theScen) >= (double)(int)theAircraft.Size;
	}

	internal AirFacility WhichFacilityCanHostThis(Aircraft theAircraft)
	{
		AirFacility result;
		try
		{
			List<AirFacility> list = new List<AirFacility>();
			AirFacility[] airFacilities_ReadOnly = myUnit.AirFacilities_ReadOnly;
			foreach (AirFacility airFacility in airFacilities_ReadOnly)
			{
				if (airFacility.IsParkingFacility() && airFacility.CanHostThisAircraft_BySize(theAircraft) == AirOpsAttemptResult.Success && airFacility.Status == PlatformComponent._ComponentStatus.Operational)
				{
					list.Add(airFacility);
				}
			}
			if (list.Count == 0)
			{
				AirFacility[] airFacilities_ReadOnly2 = myUnit.AirFacilities_ReadOnly;
				foreach (AirFacility airFacility2 in airFacilities_ReadOnly2)
				{
					if (airFacility2.Status == PlatformComponent._ComponentStatus.Operational && theAircraft.IsHelicopter && airFacility2.IsPad() && airFacility2.CanHostThisAircraft_BySize(theAircraft) == AirOpsAttemptResult.Success)
					{
						list.Add(airFacility2);
					}
				}
			}
			if (list.Count == 0 && (theAircraft.Type == Aircraft._AircraftType.UAV || theAircraft.Type == Aircraft._AircraftType.UCAV))
			{
				AirFacility airFacility3 = AirFacility.AddUAV_Class1_Hanger(myUnit);
				AirFacility[] airFacilities_ReadOnly3 = myUnit.AirFacilities_ReadOnly;
				foreach (AirFacility airFacility4 in airFacilities_ReadOnly3)
				{
					if (airFacility4.Status == PlatformComponent._ComponentStatus.Operational && airFacility4.CanHostThisAircraft_BySize(theAircraft) == AirOpsAttemptResult.Success && (airFacility3 == airFacility4 || (airFacility4.AirFacType == AirFacility._AirFacType.const_13 && theAircraft.Loadout != null)))
					{
						list.Add(airFacility4);
					}
				}
			}
			IEnumerable<AirFacility> source;
			if (list.Count > 0)
			{
				if (!myUnit.IsShip)
				{
					goto IL_0280;
				}
				Ship._ShipCategory category = ((Ship)myUnit).Category;
				if ((category != Ship._ShipCategory.AviationShip && category != Ship._ShipCategory.SurfaceCombatantAviation && category != Ship._ShipCategory.MobileOffshoreBase) || !(theAircraft.AirOps.ConditionTimer < 60f) || Information.IsNothing((object)theAircraft.Loadout) || theAircraft.Loadout.Role == Loadout.LoadoutRole.Reserve || theAircraft.Loadout.Role == Loadout.LoadoutRole.Unavailable || theAircraft.Loadout.Role == Loadout.LoadoutRole.PackedForCargo)
				{
					goto IL_0280;
				}
				source = from theAF in list
					orderby theAF.TypeString descending, theAF.ParkingSpace_Free
					select theAF;
				if (!((double)source.ElementAtOrDefault(0).ParkingSpace_Free / (double)(int)source.ElementAtOrDefault(0).MaxAircraftSize > 4.0))
				{
					goto IL_0280;
				}
				result = source.ElementAtOrDefault(0);
			}
			else
			{
				result = null;
			}
			goto end_IL_0001;
			IL_0280:
			if (theAircraft.Size < GlobalVariables.AircraftSizeClass.Small)
			{
				foreach (AirFacility item in list)
				{
					if (item.AirFacType != AirFacility._AirFacType.Hangar || item.MaxAircraftSize >= GlobalVariables.AircraftSizeClass.Small || theAircraft.Size > item.MaxAircraftSize)
					{
						continue;
					}
					result = item;
					goto end_IL_0001;
				}
			}
			source = from theAF in list
				orderby theAF.TypeString, theAF.ParkingSpace_Free
				select theAF;
			result = source.ElementAtOrDefault(0);
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100099", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	static ActiveUnit_AirOps()
	{
		Class72.smethod_20();
	}
}
