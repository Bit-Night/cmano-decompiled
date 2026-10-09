using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class PressureHull : PlatformComponent
{
	public void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("PressureHull");
			theWriter.WriteElementString("ID", ObjectID);
			if (!ObjectsAlreadySerialized.Contains(ObjectID))
			{
				ObjectsAlreadySerialized.Add(ObjectID);
				XmlWriter obj = theWriter;
				byte status = (byte)_Status;
				obj.WriteElementString("Status", status.ToString());
				theWriter.WriteElementString("DamageSeverity", ((byte)base.DamageSeverity).ToString());
				theWriter.WriteElementString("Name", Name);
				theWriter.WriteEndElement();
			}
			else
			{
				theWriter.WriteEndElement();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100689", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static PressureHull FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ActiveUnit theParentPlatform)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		PressureHull result = default(PressureHull);
		try
		{
			PressureHull pressureHull = new PressureHull();
			pressureHull.ParentPlatform = theParentPlatform;
			foreach (XmlNode childNode in theNode.ChildNodes[0].ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "Status":
					switch (val.InnerText)
					{
					case "Operational":
						pressureHull._Status = _ComponentStatus.Operational;
						break;
					case "Destroyed":
						pressureHull._Status = _ComponentStatus.Destroyed;
						break;
					default:
						pressureHull._Status = (_ComponentStatus)Conversions.ToByte(val.InnerText);
						break;
					case "Damaged":
						pressureHull._Status = _ComponentStatus.Damaged;
						break;
					}
					break;
				case "DamageSeverity":
					pressureHull.DamageSeverity = (_DamageSeverityFactor)Conversions.ToByte(val.InnerText);
					break;
				case "Name":
					pressureHull.Name = val.InnerText;
					break;
				case "ID":
					if (!theDictionary.ContainsKey(val.InnerText))
					{
						pressureHull.ObjectID_Set(val.InnerText);
						theDictionary.TryAdd(pressureHull.ObjectID, pressureHull);
						break;
					}
					result = (PressureHull)theDictionary[val.InnerText];
					return result;
				}
			}
			result = pressureHull;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100690", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private PressureHull()
	{
	}

	public PressureHull(ActiveUnit theParent)
		: base(theParent)
	{
	}

	static PressureHull()
	{
		Class72.smethod_20();
	}
}
