using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EventCondition_SidePosture : EventCondition
{
	public string ObserverSide_ID;

	public string TargetSide_ID;

	public Misc.PostureStance TargetPosture;

	public bool Modifier_NOT;

	public override bool IsTrue
	{
		get
		{
			bool result;
			try
			{
				Side side = null;
				Side side2 = null;
				Side[] sides_ReadOnly = theScen.Sides_ReadOnly;
				foreach (Side side3 in sides_ReadOnly)
				{
					if (Operators.CompareString(side3.ObjectID, ObserverSide_ID, false) == 0)
					{
						side = side3;
					}
					if (Operators.CompareString(side3.ObjectID, TargetSide_ID, false) == 0)
					{
						side2 = side3;
					}
				}
				int num;
				if (Information.IsNothing((object)side))
				{
					num = 0;
					goto IL_00b3;
				}
				if (Information.IsNothing((object)side2))
				{
					num = 0;
					goto IL_00b3;
				}
				bool? flag = side.get_ConsidersThisSideToBe(side2, (Scenario)null) == TargetPosture;
				result = !Information.IsNothing((object)flag) && ((!Modifier_NOT) ? flag.Value : (!flag.Value));
				goto end_IL_0001;
				IL_00b3:
				result = (byte)num != 0;
				end_IL_0001:;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100516", "");
				GameGeneral.WriteExceptionsToLog(ex2);
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
	}

	public EventCondition_SidePosture()
	{
		Type = EventConditionType.SidePosture;
	}

	public override void ToXML(XmlWriter theWriter, HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("EventCondition_SidePosture");
			theWriter.WriteElementString("ID", ObjectID);
			theWriter.WriteElementString("Description", Description);
			theWriter.WriteElementString("ObserverSideID", ObserverSide_ID);
			theWriter.WriteElementString("TargetSideID", TargetSide_ID);
			if (!Information.IsNothing((object)TargetPosture))
			{
				theWriter.WriteElementString("TargetPosture", Conversions.ToString((int)TargetPosture));
			}
			if (Modifier_NOT)
			{
				theWriter.WriteElementString("NOT", 1.ToString());
			}
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100517", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static EventCondition_SidePosture FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		EventCondition_SidePosture result;
		try
		{
			EventCondition_SidePosture eventCondition_SidePosture = new EventCondition_SidePosture();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "ID":
					eventCondition_SidePosture.ObjectID_Set(val.InnerText);
					break;
				case "ObserverSideID":
					eventCondition_SidePosture.ObserverSide_ID = val.InnerText;
					break;
				case "TargetSideID":
					eventCondition_SidePosture.TargetSide_ID = val.InnerText;
					break;
				case "TargetPosture":
					eventCondition_SidePosture.TargetPosture = (Misc.PostureStance)Conversions.ToByte(val.InnerText);
					break;
				case "NOT":
					eventCondition_SidePosture.Modifier_NOT = true;
					break;
				case "Description":
					eventCondition_SidePosture.Description = val.InnerText;
					break;
				}
			}
			result = eventCondition_SidePosture;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100518", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new EventCondition_SidePosture();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override EventCondition Clone()
	{
		EventCondition_SidePosture obj = (EventCondition_SidePosture)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[CLONE] " + Description;
		obj.Name = "[CLONE] " + Name;
		return obj;
	}

	static EventCondition_SidePosture()
	{
		Class72.smethod_20();
	}
}
