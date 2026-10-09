using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EventTrigger_UnitEntersArea : EventTrigger
{
	public UnitFilterObject TargetFilter;

	public List<ReferencePoint> Area;

	public DateTime dateTime_0;

	public DateTime dateTime_1;

	public bool Modifier_NOT;

	public bool Modifier_EXIT;

	public bool Modifer_ExcludeCargo;

	public ActiveUnit CulpritUnit;

	public bool LeavesArea;

	public bool NotInArea;

	public bool JustEnteredArea;

	public bool IsFulfilled
	{
		get
		{
			try
			{
				bool flag = false;
				LeavesArea = false;
				JustEnteredArea = false;
				NotInArea = true;
				if (theScen.Time.CompareTo(dateTime_0) < 0)
				{
					return false;
				}
				if (theScen.Time.CompareTo(dateTime_1) > 0)
				{
					return false;
				}
				ActiveUnit activeUnit = null;
				foreach (ActiveUnit activeUnits_ in theScen.ActiveUnits_List)
				{
					if (activeUnits_ == null || !TargetFilter.MatchesThisUnit(activeUnits_))
					{
						continue;
					}
					if (!((Module_Unit.Unit)activeUnits_).get_IsInsideThisArea(Area, theScen, UseCache: false))
					{
						activeUnits_.Longitude__UnitEntersAreaCheck = null;
						activeUnits_.Latitude__UnitEntersAreaCheck = null;
						if (activeUnits_.ActiveEnterAreaTriggers.FirstOrDefault([SpecialName] (string s) => Operators.CompareString(s, ObjectID, false) == 0) != null)
						{
							if (Modifier_EXIT)
							{
								activeUnit = activeUnits_;
								LeavesArea = true;
								break;
							}
							activeUnits_.ActiveEnterAreaTriggers.Remove(ObjectID);
						}
						continue;
					}
					NotInArea = false;
					bool flag2 = false;
					foreach (string activeEnterAreaTrigger in activeUnits_.ActiveEnterAreaTriggers)
					{
						if (string.CompareOrdinal(activeEnterAreaTrigger, ObjectID) == 0)
						{
							flag2 = true;
							break;
						}
					}
					if (!flag2 && activeUnits_.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.LoadedAsCargo)
					{
						continue;
					}
					if (flag2)
					{
						if (activeUnits_.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.LoadedAsCargo)
						{
							activeUnits_.Longitude__UnitEntersAreaCheck = null;
							activeUnits_.Latitude__UnitEntersAreaCheck = null;
							if (activeUnits_.ActiveEnterAreaTriggers.FirstOrDefault([SpecialName] (string s) => Operators.CompareString(s, ObjectID, false) == 0) != null)
							{
								if (Modifier_EXIT)
								{
									activeUnit = activeUnits_;
									LeavesArea = true;
									break;
								}
								activeUnits_.ActiveEnterAreaTriggers.Remove(ObjectID);
							}
							continue;
						}
						string[] array = activeUnits_.ActiveEnterAreaTriggers.ToArray();
						if (array.Count() <= 1)
						{
							continue;
						}
						string[] array2 = array;
						foreach (string text in array2)
						{
							if (!theScen.EventTriggers.ContainsKey(text))
							{
								activeUnits_.ActiveEnterAreaTriggers.Remove(text);
							}
						}
						continue;
					}
					JustEnteredArea = true;
					if (!activeUnits_.Longitude__UnitEntersAreaCheck.HasValue && !activeUnits_.Latitude__UnitEntersAreaCheck.HasValue)
					{
						activeUnit = activeUnits_;
						break;
					}
					activeUnits_.Longitude__UnitEntersAreaCheck = null;
					activeUnits_.Latitude__UnitEntersAreaCheck = null;
					break;
				}
				if (activeUnit != null)
				{
					flag = (Modifier_EXIT & LeavesArea) || (!Modifier_EXIT & JustEnteredArea) || ((Modifier_EXIT & JustEnteredArea) ? true : false);
				}
				else if (NotInArea && Modifier_NOT)
				{
					flag = true;
				}
				if (flag && activeUnit != null)
				{
					CulpritUnit = activeUnit;
					activeUnit.ParentScen.Scenario_LuaSandbox.UnitX = activeUnit;
				}
				else
				{
					CulpritUnit = null;
				}
				return flag;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100532", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return false;
		}
	}

	public EventTrigger_UnitEntersArea()
	{
		TargetFilter = new UnitFilterObject();
		Area = new List<ReferencePoint>();
		Modifer_ExcludeCargo = true;
		LeavesArea = false;
		NotInArea = false;
		JustEnteredArea = false;
		Type = EventTriggerType.UnitEntersArea;
	}

	public override void ToXML(XmlWriter theWriter, HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("EventTrigger_UnitEntersArea");
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
			theWriter.WriteElementString("ETOA", dateTime_0.ToBinary().ToString());
			theWriter.WriteElementString("LTOA", dateTime_1.ToBinary().ToString());
			if (Modifier_NOT)
			{
				theWriter.WriteElementString("NOT", 1.ToString());
			}
			if (Modifier_EXIT)
			{
				theWriter.WriteElementString("ExitArea", 1.ToString());
			}
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100533", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static EventTrigger_UnitEntersArea FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		EventTrigger_UnitEntersArea result = default(EventTrigger_UnitEntersArea);
		try
		{
			EventTrigger_UnitEntersArea eventTrigger_UnitEntersArea = new EventTrigger_UnitEntersArea();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "ID":
					eventTrigger_UnitEntersArea.ObjectID_Set(val.InnerText);
					break;
				case "LTOA":
					eventTrigger_UnitEntersArea.dateTime_1 = DateTime.FromBinary(Conversions.ToLong(val.InnerText));
					break;
				case "Area":
					foreach (XmlNode childNode2 in val.ChildNodes)
					{
						XmlNode theNode2 = childNode2;
						eventTrigger_UnitEntersArea.Area.Add(ReferencePoint.FromXML(ref theNode2, ref theDictionary, theScen));
					}
					break;
				case "ExitArea":
					eventTrigger_UnitEntersArea.Modifier_EXIT = true;
					break;
				case "TargetFilter":
					eventTrigger_UnitEntersArea.TargetFilter = UnitFilterObject.FromXML(val, theDictionary, theScen);
					break;
				case "ETOA":
					eventTrigger_UnitEntersArea.dateTime_0 = DateTime.FromBinary(Conversions.ToLong(val.InnerText));
					break;
				case "NOT":
					eventTrigger_UnitEntersArea.Modifier_NOT = true;
					break;
				case "Description":
					eventTrigger_UnitEntersArea.Description = val.InnerText;
					break;
				}
			}
			result = eventTrigger_UnitEntersArea;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100534", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override EventTrigger Clone()
	{
		EventTrigger_UnitEntersArea obj = (EventTrigger_UnitEntersArea)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[CLONE] " + Description;
		obj.Name = "[CLONE] " + Name;
		obj.TargetFilter = TargetFilter.Clone();
		obj.Area = Area.GetRange(0, Area.Count);
		return obj;
	}

	static EventTrigger_UnitEntersArea()
	{
		Class72.smethod_20();
	}
}
