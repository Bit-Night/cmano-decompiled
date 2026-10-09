using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class TaskPool : Mission
{
	public List<Mission> PackageList;

	public List<string> PackageList_IDs;

	public override string DescriptionString => "Task Pool";

	internal override void Reinitialize()
	{
		base.Reinitialize();
		PackageList.Clear();
		PackageList_IDs.Clear();
	}

	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized, ref Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("TaskPool");
			theWriter.WriteElementString("ID", ObjectID);
			theWriter.WriteElementString("Name", Name);
			theWriter.WriteElementString("Category", ((byte)Category).ToString());
			method_0(ref theWriter, ref ObjectsAlreadySerialized, ref theScen);
			theWriter.WriteStartElement("Packages");
			foreach (Mission package in PackageList)
			{
				if (!Information.IsNothing((object)package))
				{
					theWriter.WriteElementString("ID", package.ObjectID);
				}
			}
			theWriter.WriteEndElement();
			if (_StartTime.HasValue)
			{
				theWriter.WriteElementString("START", _StartTime.Value.ToBinary().ToString());
			}
			if (_EndTime.HasValue)
			{
				theWriter.WriteElementString("END", _EndTime.Value.ToBinary().ToString());
			}
			if (_TakeOffTime.HasValue)
			{
				theWriter.WriteElementString("TakeOffTime", _TakeOffTime.Value.ToBinary().ToString());
			}
			if (_TimeOnTarget.HasValue)
			{
				theWriter.WriteElementString("TimeOnTarget", _TimeOnTarget.Value.ToBinary().ToString());
			}
			theWriter.WriteElementString("Deactivation_UnassignUnits", Deactivation_UnassignUnits.ToString());
			theWriter.WriteElementString("CheckBox_OrderRTB", Deactivation_OrderRTB.ToString());
			theWriter.WriteElementString("CheckBox_DeleteMission", Deactivation_DeleteMission.ToString());
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200648", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static TaskPool FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref Scenario theScen, Mission existingObject = null)
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Expected O, but got Unknown
		TaskPool result = default(TaskPool);
		try
		{
			bool flag;
			TaskPool taskPool;
			if (flag = existingObject != null)
			{
				taskPool = (TaskPool)existingObject;
				taskPool.Reinitialize();
			}
			else
			{
				Side theSide = null;
				taskPool = new TaskPool(ref theSide, ref theScen, "", MissionCategory.Mission);
			}
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				Mission.FromXMLCommon(taskPool, val);
				switch (val.Name)
				{
				case "ID":
					if (!theDictionary.ContainsKey(val.InnerText))
					{
						taskPool.ObjectID_Set(val.InnerText);
						theDictionary.TryAdd(taskPool.ObjectID, taskPool);
						break;
					}
					result = (TaskPool)theDictionary[val.InnerText];
					return result;
				case "Name":
					taskPool.Name = val.InnerText;
					break;
				case "Category":
					taskPool.Category = (MissionCategory)Conversions.ToInteger(val.InnerText);
					break;
				case "Packages":
					if (flag)
					{
						taskPool.PackageList.Clear();
						taskPool.PackageList_IDs.Clear();
					}
					foreach (XmlNode childNode2 in val.ChildNodes)
					{
						XmlNode val2 = childNode2;
						taskPool.PackageList_IDs.Add(val2.InnerText);
					}
					break;
				}
			}
			result = taskPool;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200649", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public TaskPool(ref Side theSide, ref Scenario theScen, string theName, MissionCategory theCategory)
		: base(theSide, theScen, theName)
	{
		PackageList = new List<Mission>();
		PackageList_IDs = new List<string>();
		IsMission = true;
		Name = theName;
		Category = theCategory;
	}

	public override void Printout(StringBuilder PrintoutStringBuilder)
	{
		throw new NotImplementedException();
	}

	public override void PostDeserializationHousekeeping(ref Scenario theScen, Side theSide, bool GameIsRunning, ref ConcurrentDictionary<string, ScenarioObject> ObjectsDictionary)
	{
		try
		{
			foreach (string packageList_ID in PackageList_IDs)
			{
				Side[] sides_ReadOnly = theScen.Sides_ReadOnly;
				foreach (Side side in sides_ReadOnly)
				{
					foreach (Mission mission in side.Missions)
					{
						if (Operators.CompareString(mission.ObjectID, packageList_ID, false) == 0)
						{
							PackageList.Add(mission);
						}
					}
				}
			}
			base.PostDeserializationHousekeeping(ref theScen, theSide, GameIsRunning, ref ObjectsDictionary);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200650", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	static TaskPool()
	{
		Class72.smethod_20();
	}
}
