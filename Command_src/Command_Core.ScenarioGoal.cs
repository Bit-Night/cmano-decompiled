using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public abstract class ScenarioGoal : ScenarioObject
{
	public string TargetSide;

	public GlobalVariables.ActiveUnitType TargetType;

	public int TargetSubType;

	public int SpecificUnitClass;

	public ActiveUnit SpecificUnit;

	public string Description;

	public bool NeedsToBeChecked;

	public bool IsRepeatable;

	public int GoalPoints;

	public ScenarioGoal()
	{
		NeedsToBeChecked = true;
	}

	public virtual void ToXML(XmlWriter theWriter, HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("ScenarioGoal");
			theWriter.WriteElementString("ID", ObjectID);
			theWriter.WriteElementString("Description", Description);
			theWriter.WriteElementString("NeedsToBeChecked", NeedsToBeChecked.ToString());
			theWriter.WriteElementString("IsRepeatable", IsRepeatable.ToString());
			theWriter.WriteElementString("GoalPoints", GoalPoints.ToString());
			if (!string.IsNullOrEmpty(TargetSide))
			{
				theWriter.WriteElementString("TargetSide", TargetSide);
			}
			XmlWriter obj = theWriter;
			int targetType = (int)TargetType;
			obj.WriteElementString("TargetType", targetType.ToString());
			theWriter.WriteElementString("TargetSubType", TargetSubType.ToString());
			if (!string.IsNullOrEmpty(Conversions.ToString(SpecificUnitClass)))
			{
				theWriter.WriteElementString("SpecificUnitClass", SpecificUnitClass.ToString());
			}
			if (!Information.IsNothing((object)SpecificUnit))
			{
				theWriter.WriteStartElement("SpecificUnit");
				SpecificUnit.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
				theWriter.WriteEndElement();
			}
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100759", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static ScenarioGoal FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen)
	{
		try
		{
			string name = theNode.Name;
			if (Operators.CompareString(name, "DestroyGoal", false) == 0)
			{
				return DestroyGoal.FromXML(theNode, theDictionary, theScen);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100760", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		throw new NotImplementedException();
	}

	public bool IsFulfilled()
	{
		throw new NotImplementedException();
	}

	static ScenarioGoal()
	{
		Class72.smethod_20();
	}
}
