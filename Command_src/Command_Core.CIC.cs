using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class CIC : PlatformComponent
{
	public void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("CIC");
			theWriter.WriteElementString("ID", ObjectID);
			if (ObjectsAlreadySerialized.Contains(ObjectID))
			{
				theWriter.WriteEndElement();
				return;
			}
			ObjectsAlreadySerialized.Add(ObjectID);
			XmlWriter obj = theWriter;
			byte status = (byte)_Status;
			obj.WriteElementString("Status", status.ToString());
			theWriter.WriteElementString("Name", Name);
			if (base.DamageSeverity != _DamageSeverityFactor.Light)
			{
				theWriter.WriteElementString("DamageSeverity", ((byte)base.DamageSeverity).ToString());
			}
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100660", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static CIC FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ActiveUnit theParentPlatform)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		CIC result = default(CIC);
		try
		{
			CIC cIC = new CIC("");
			cIC.ParentPlatform = theParentPlatform;
			foreach (XmlNode childNode in theNode.ChildNodes[0].ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "DamageSeverity":
					cIC.DamageSeverity = (_DamageSeverityFactor)Conversions.ToByte(val.InnerText);
					break;
				case "Name":
					cIC.Name = val.InnerText;
					break;
				case "Status":
					switch (val.InnerText)
					{
					case "Destroyed":
						cIC._Status = _ComponentStatus.Destroyed;
						break;
					default:
						cIC._Status = (_ComponentStatus)Conversions.ToByte(val.InnerText);
						break;
					case "Damaged":
						cIC._Status = _ComponentStatus.Damaged;
						break;
					case "Operational":
						cIC._Status = _ComponentStatus.Operational;
						break;
					}
					break;
				case "ID":
					if (!theDictionary.ContainsKey(val.InnerText))
					{
						cIC.ObjectID_Set(val.InnerText);
						theDictionary.TryAdd(cIC.ObjectID, cIC);
						break;
					}
					result = (CIC)theDictionary[val.InnerText];
					return result;
				}
			}
			result = cIC;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100661", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private CIC(string Name)
	{
	}

	public CIC(ActiveUnit theParent, string theName)
		: base(theParent)
	{
		Name = theName;
	}

	static CIC()
	{
		Class72.smethod_20();
	}
}
