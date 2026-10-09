using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EventTrigger_UnitRemainsInArea : EventTrigger
{
	public UnitFilterObject TargetFilter;

	public List<ReferencePoint> Area;

	public long TimeDuration;

	private double double_0;

	public ActiveUnit CulpritUnit;

	public DateTime? URIA_StartTime;

	public bool IsFulfilled
	{
		get
		{
			bool result;
			try
			{
				bool flag = false;
				ActiveUnit activeUnit = null;
				List<ActiveUnit> list = new List<ActiveUnit>();
				foreach (ActiveUnit activeUnits_ in theScen.ActiveUnits_List)
				{
					if (activeUnits_ != null)
					{
						if (activeUnits_.DockingOps.Condition != ActiveUnit_DockingOps._DockingOpsCondition.LoadedAsCargo && TargetFilter.MatchesThisUnit(activeUnits_) && ((Module_Unit.Unit)activeUnits_).get_IsInsideThisArea(Area, theScen, UseCache: false))
						{
							activeUnit = activeUnits_;
							list.Add(activeUnits_);
						}
						if ((activeUnit == null || Operators.CompareString(activeUnit.ObjectID, activeUnits_.ObjectID, false) != 0) && activeUnits_.ActiveRemainAreaTriggers.ContainsKey(ObjectID))
						{
							activeUnits_.ActiveRemainAreaTriggers.Remove(ObjectID);
						}
					}
				}
				if (list.Count > 1)
				{
					Misc.Shuffle(list);
					activeUnit = list[0];
				}
				if (activeUnit != null)
				{
					if (!activeUnit.ActiveRemainAreaTriggers.ContainsKey(ObjectID))
					{
						URIA_StartTime = null;
					}
					else
					{
						URIA_StartTime = activeUnit.ActiveRemainAreaTriggers[ObjectID];
					}
					if (!URIA_StartTime.HasValue)
					{
						if (double_0 > 0.0)
						{
							URIA_StartTime = new DateTime(theScen.Time.Year, theScen.Time.Month, theScen.Time.Day, theScen.Time.Hour, theScen.Time.Minute, theScen.Time.Second).AddSeconds(-1.0 * double_0);
						}
						else
						{
							URIA_StartTime = theScen.Time;
						}
						activeUnit.ActiveRemainAreaTriggers.AddIfNotExistsElseUpdate(ObjectID, URIA_StartTime.Value);
					}
					double_0 = (theScen.Time - URIA_StartTime.Value).TotalSeconds;
					if (double_0 >= (double)TimeDuration)
					{
						double_0 = 0.0;
						activeUnit.ActiveRemainAreaTriggers.Remove(ObjectID);
						URIA_StartTime = null;
						flag = true;
					}
					else
					{
						double_0 = 0.0;
						flag = false;
					}
				}
				else
				{
					double_0 = 0.0;
					URIA_StartTime = null;
					flag = false;
				}
				if (!(flag & !Information.IsNothing((object)activeUnit)))
				{
					CulpritUnit = null;
				}
				else
				{
					CulpritUnit = activeUnit;
					activeUnit.ParentScen.Scenario_LuaSandbox.UnitX = activeUnit;
				}
				result = flag;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100535", "");
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
				result = (byte)num != 0;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public EventTrigger_UnitRemainsInArea()
	{
		TargetFilter = new UnitFilterObject();
		Area = new List<ReferencePoint>();
		URIA_StartTime = null;
		Type = EventTriggerType.UnitRemainsInArea;
	}

	public override void ToXML(XmlWriter theWriter, HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("EventTrigger_UnitRemainsInArea");
			theWriter.WriteElementString("ID", ObjectID);
			theWriter.WriteElementString("Description", Description);
			theWriter.WriteStartElement("TargetFilter");
			TargetFilter.ToXML(theWriter, ObjectsAlreadySerialized, theScen);
			theWriter.WriteEndElement();
			theWriter.WriteStartElement("Area");
			foreach (ReferencePoint item in Area)
			{
				theWriter.WriteRaw(item.ToXML(ref ObjectsAlreadySerialized));
			}
			theWriter.WriteEndElement();
			theWriter.WriteElementString("TD", TimeDuration.ToString());
			theWriter.WriteElementString("TA", double_0.ToString());
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100536", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static EventTrigger_UnitRemainsInArea FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected O, but got Unknown
		EventTrigger_UnitRemainsInArea result;
		try
		{
			EventTrigger_UnitRemainsInArea eventTrigger_UnitRemainsInArea = new EventTrigger_UnitRemainsInArea();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "ID":
					eventTrigger_UnitRemainsInArea.ObjectID_Set(val.InnerText);
					break;
				case "Description":
					eventTrigger_UnitRemainsInArea.Description = val.InnerText;
					break;
				case "TargetFilter":
					eventTrigger_UnitRemainsInArea.TargetFilter = UnitFilterObject.FromXML(val, theDictionary, theScen);
					break;
				case "Area":
					foreach (XmlNode childNode2 in val.ChildNodes)
					{
						XmlNode theNode2 = childNode2;
						eventTrigger_UnitRemainsInArea.Area.Add(ReferencePoint.FromXML(ref theNode2, ref theDictionary, theScen));
					}
					break;
				case "TD":
					eventTrigger_UnitRemainsInArea.TimeDuration = XmlConvert.ToInt64(val.InnerText);
					break;
				case "TA":
					eventTrigger_UnitRemainsInArea.double_0 = XmlConvert.ToDouble(val.InnerText.Replace(",", "."));
					break;
				}
			}
			result = eventTrigger_UnitRemainsInArea;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100537", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new EventTrigger_UnitRemainsInArea();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override EventTrigger Clone()
	{
		EventTrigger_UnitRemainsInArea obj = (EventTrigger_UnitRemainsInArea)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[CLONE] " + Description;
		obj.Name = "[CLONE] " + Name;
		obj.TargetFilter = TargetFilter.Clone();
		obj.Area = Area.GetRange(0, Area.Count);
		return obj;
	}

	static EventTrigger_UnitRemainsInArea()
	{
		Class72.smethod_20();
	}
}
