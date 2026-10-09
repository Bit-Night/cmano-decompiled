using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ServiceStack.Text;

namespace Command_Core;

public class Operation : ScenarioObject
{
	public DateTime _HHour;

	public DateTime _LHour;

	public string _HHourMissionID;

	public Mission HHourMission;

	public DateTime HHourEffectiveStartTime;

	public DateTime LHourEffectiveStartTime;

	public bool H_LHourAreRelative;

	public string _LHourMissionID;

	public Mission LHourMission;

	private Side side_0;

	private Scenario scenario_0;

	public bool PhasesValidation;

	private Dictionary<Mission, MissionPhase> dictionary_0;

	private Dictionary<Mission, int> dictionary_1;

	private DateTime dateTime_0;

	private DateTime dateTime_1;

	private DateTime dateTime_2;

	public bool LHourLocked => DateTime.Compare(LHourEffectiveStartTime, DateTime.MinValue) != 0;

	public bool HHourLocked => DateTime.Compare(HHourEffectiveStartTime, DateTime.MinValue) != 0;

	public DateTime LHour
	{
		get
		{
			return _LHour;
		}
		set
		{
			_LHour = value;
		}
	}

	public DateTime HHour
	{
		get
		{
			return _HHour;
		}
		set
		{
			if (H_LHourAreRelative)
			{
				TimeSpan timeSpan = value - _HHour;
				LHour += timeSpan;
			}
			_HHour = value;
		}
	}

	public Operation(Side _ParentSide)
	{
		_HHour = DateTime.MinValue;
		_LHour = DateTime.MinValue;
		_HHourMissionID = "";
		HHourEffectiveStartTime = DateTime.MinValue;
		LHourEffectiveStartTime = DateTime.MinValue;
		_LHourMissionID = "";
		PhasesValidation = false;
		dictionary_0 = new Dictionary<Mission, MissionPhase>();
		dictionary_1 = new Dictionary<Mission, int>();
		dateTime_2 = DateTime.MinValue;
		side_0 = _ParentSide;
		HHour = GameGeneral.ScenarioLastGoodClone_DateTime;
		LHour = GameGeneral.ScenarioLastGoodClone_DateTime;
	}

	internal int ComputeEstimatedTimeOfExecution(Scenario TheScen, int SimulationIncrement = 1)
	{
		int num;
		if (HHourMission == null)
		{
			foreach (Mission mission in side_0.Missions)
			{
				mission.EstimatedExecutionTime = 0;
			}
			num = 0;
		}
		else
		{
			dictionary_0.Clear();
			dictionary_1.Clear();
			foreach (Mission mission2 in side_0.Missions)
			{
				dictionary_0.Add(mission2, MissionPhase.OnHold);
				dictionary_1.Add(mission2, 0);
			}
			if (DateTime.Compare(TheScen.Time, HHour) > 0)
			{
				dateTime_1 = TheScen.Time;
			}
			else
			{
				dateTime_1 = HHour;
			}
			dateTime_2 = dateTime_1;
			HHourMission.EstimatedExecutionTime = 0;
			dateTime_0 = dateTime_1;
			dictionary_0[HHourMission] = MissionPhase.Active;
			num = 0;
		}
		int i;
		for (i = num; EstimationSimulationTick(SimulationIncrement, i) && i < 2592000; i += SimulationIncrement)
		{
		}
		if (i >= 2592000)
		{
			foreach (KeyValuePair<Mission, MissionPhase> item in dictionary_0)
			{
				item.Key.EstimatedExecutionTime = -500;
			}
		}
		return i;
	}

	internal bool EstimationSimulationTick(int Increment = 1, int TEST = 0)
	{
		bool result = false;
		for (int i = dictionary_0.Count - 1; i >= 0; i += -1)
		{
			Mission key = dictionary_0.ElementAt(i).Key;
			List<Mission.TriggerOperationWrapper> list = new List<Mission.TriggerOperationWrapper>();
			if (dictionary_0[key] == MissionPhase.OnHold)
			{
				result = true;
				bool value = true;
				if (key.MissionStartTrigger_MissionCompleted_Enabled)
				{
					foreach (KeyValuePair<Mission, Mission> item in key.MissionStartTrigger_MissionCompleted)
					{
						if (dictionary_0[item.Key] != MissionPhase.Completed)
						{
							value = false;
							break;
						}
					}
					list.Add(new Mission.TriggerOperationWrapper(value, key.MissionStartTrigger_MissionCompleted_Operator));
				}
				int num;
				if (key.MissionStartTrigger_Time_Enabled && DateTime.Compare(dateTime_2, DateTime.MinValue) != 0)
				{
					list.Add(new Mission.TriggerOperationWrapper(DateTime.Compare(dateTime_0, dateTime_2.AddSeconds(key.MissionStartTrigger_Time)) > 0, key.MissionStartTrigger_Time_Operator));
					num = 0;
				}
				else
				{
					num = 0;
				}
				bool flag = (byte)num != 0;
				foreach (Mission.TriggerOperationWrapper item2 in list)
				{
					if (item2.Value)
					{
						if (!item2.ConditionalOperator)
						{
							flag = true;
							break;
						}
						flag = true;
					}
					else if (item2.ConditionalOperator)
					{
						flag = false;
						break;
					}
				}
				if (flag || list.Count == 0)
				{
					dictionary_0[key] = MissionPhase.Active;
					key.EstimatedExecutionTime = TEST;
				}
			}
			else if (dictionary_0[key] == MissionPhase.Active)
			{
				dictionary_1[key] += Increment;
				if ((float)dictionary_1[key] > key.MissionCompletedTrigger_ElapsedTime)
				{
					dictionary_0[key] = MissionPhase.Completed;
				}
			}
		}
		dateTime_0 = dateTime_0.AddSeconds(Increment);
		return result;
	}

	public void Tick(Scenario _TheScen, float elapsedTime)
	{
		try
		{
			scenario_0 = _TheScen;
			if (scenario_0.SecondIsChangingOnThisPulse)
			{
				CheckH_Hour(scenario_0);
				CheckL_Hour(scenario_0);
			}
			foreach (Mission mission in side_0.Missions)
			{
				if (mission.MissionCompletedTrigger_ElapsedTime_Enabled && mission.get_Phase(scenario_0, side_0) == MissionPhase.Active)
				{
					mission.MissionCompletedTrigger_ElapsedTime_Current += elapsedTime;
				}
				if (scenario_0.SecondIsChangingOnThisPulse)
				{
					if (mission.get_Phase(scenario_0, side_0) == MissionPhase.OnHold && mission.EvaluatePhaseStartTriggers(scenario_0, side_0))
					{
						mission.set_Phase(scenario_0, side_0, MissionPhase.Active);
					}
					else if (mission.get_Phase(scenario_0, side_0) == MissionPhase.Active && mission.EvaluatePhaseCompletedTriggers(scenario_0, side_0))
					{
						mission.set_Phase(scenario_0, side_0, MissionPhase.Completed);
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at OM_1654612314", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void CheckH_Hour(Scenario TheScen, bool ForceStart = false)
	{
		if (!Information.IsNothing((object)HHourMission) && HHourMission.get_Phase(TheScen, side_0) == MissionPhase.OnHold && (DateTime.Compare(TheScen.Time, HHour) > 0 || ForceStart))
		{
			HHourMission.set_Phase(TheScen, side_0, MissionPhase.Active);
		}
	}

	public void CheckL_Hour(Scenario TheScen, bool ForceStart = false)
	{
		if (!Information.IsNothing((object)LHourMission) && LHourMission.get_Phase(TheScen, side_0) == MissionPhase.OnHold && (DateTime.Compare(TheScen.Time, LHour) > 0 || ForceStart))
		{
			LHourMission.set_Phase(TheScen, side_0, MissionPhase.Active);
		}
	}

	public string ToXML([Optional][DefaultParameterValue(null)] ref HashSet<string> ObjectsAlreadySerialized)
	{
		string result = default(string);
		try
		{
			StringBuilder stringBuilder = StringBuilderCache.Allocate();
			stringBuilder.Clear();
			stringBuilder.Append("<Operation>");
			stringBuilder.Append("<ID>").Append(ObjectID).Append("</ID>");
			if (HHourMission != null)
			{
				stringBuilder.Append("<HHourMissionID>").Append(HHourMission.ObjectID).Append("</HHourMissionID>");
			}
			if (LHourMission != null)
			{
				stringBuilder.Append("<LHourMissionID>").Append(LHourMission.ObjectID).Append("</LHourMissionID>");
			}
			stringBuilder.Append("<HHourMissionTime>").Append(HHour.Ticks.ToString()).Append("</HHourMissionTime>");
			stringBuilder.Append("<LHourMissionTime>").Append(LHour.Ticks.ToString()).Append("</LHourMissionTime>");
			stringBuilder.Append("<HHourEffectiveStartTime>").Append(HHourEffectiveStartTime.Ticks.ToString()).Append("</HHourEffectiveStartTime>");
			stringBuilder.Append("<LHourEffectiveStartTime>").Append(LHourEffectiveStartTime.Ticks.ToString()).Append("</LHourEffectiveStartTime>");
			stringBuilder.Append("<H_LHourAreRelative>").Append(H_LHourAreRelative).Append("</H_LHourAreRelative>");
			stringBuilder.Append("</Operation>");
			string text = stringBuilder.ToString();
			StringBuilderCache.Free(stringBuilder);
			result = text;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 1005845_c", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static Operation FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, Side TheParentSide)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		Operation result;
		try
		{
			Operation operation = new Operation(TheParentSide);
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "ID":
					operation.ObjectID = val.InnerText;
					break;
				case "HHourMissionID":
					operation._HHourMissionID = val.InnerText;
					break;
				case "HHourMissionTime":
					operation.HHour = new DateTime(Conversions.ToLong(val.InnerText));
					break;
				case "LHourMissionTime":
					operation.LHour = new DateTime(Conversions.ToLong(val.InnerText));
					break;
				case "LHourMissionID":
					operation._LHourMissionID = val.InnerText;
					break;
				case "H_LHourAreRelative":
					operation.H_LHourAreRelative = Misc.ParseBool(val.InnerText);
					break;
				case "HHourEffectiveStartTime":
					operation.HHourEffectiveStartTime = new DateTime(Conversions.ToLong(val.InnerText));
					break;
				case "LHourEffectiveStartTime":
					operation.LHourEffectiveStartTime = new DateTime(Conversions.ToLong(val.InnerText));
					break;
				}
			}
			result = operation;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 1005855_c", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Operation(TheParentSide);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	static Operation()
	{
		Class72.smethod_20();
	}
}
