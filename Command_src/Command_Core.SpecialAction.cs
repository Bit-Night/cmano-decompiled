using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class SpecialAction : ScenarioObject
{
	public string Description;

	public bool IsActive;

	public bool IsRepeatable;

	public string ScriptText;

	public bool? ShowResults;

	public void ToXML(XmlWriter theWriter, HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("SpecialAction");
			theWriter.WriteElementString("ID", ObjectID);
			theWriter.WriteElementString("Name", Name);
			theWriter.WriteElementString("Description", Description);
			theWriter.WriteElementString("IsRepeatable", IsRepeatable.ToString());
			theWriter.WriteElementString("IsActive", IsActive.ToString());
			theWriter.WriteElementString("ScriptText", ScriptText);
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200654", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static SpecialAction FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		SpecialAction result = default(SpecialAction);
		try
		{
			SpecialAction specialAction = new SpecialAction();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "ID":
					specialAction.ObjectID_Set(val.InnerText);
					break;
				case "Name":
					specialAction.Name = val.InnerText;
					break;
				case "Description":
					specialAction.Description = val.InnerText;
					break;
				case "IsRepeatable":
					specialAction.IsRepeatable = Misc.ParseBool(val.InnerText);
					break;
				case "IsActive":
					specialAction.IsActive = Misc.ParseBool(val.InnerText);
					break;
				case "ScriptText":
					specialAction.ScriptText = val.InnerText;
					break;
				}
			}
			result = specialAction;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101324", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public SpecialAction()
	{
		IsActive = true;
		IsRepeatable = false;
		ShowResults = null;
	}

	internal string Execute(Scenario thescen)
	{
		try
		{
			if (!IsRepeatable)
			{
				IsActive = false;
			}
			object[] array = thescen.Scenario_LuaSandbox.RunScript(ScriptText, RunInteractively: false, Name);
			if (array != null && array.Length != 0)
			{
				if (array.Length == 2 && array[1] != null)
				{
					bool result = false;
					if (bool.TryParse(Conversions.ToString(array[1]), out result))
					{
						ShowResults = result;
					}
					else
					{
						ShowResults = null;
					}
				}
				return array[0].ToString();
			}
			return "Special Action '" + Name + "' has been executed.";
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			GameGeneral.SendMessageBoxToUI("Error in Execute: " + ex2.Message + "\r\nStack:" + ex2.StackTrace, null);
			ex2?.Data.Add("Error at 101325", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return null;
	}

	public SpecialAction Clone()
	{
		SpecialAction obj = (SpecialAction)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[CLONE] " + Description;
		obj.Name = "[CLONE] " + Name;
		return obj;
	}

	static SpecialAction()
	{
		Class72.smethod_20();
	}
}
