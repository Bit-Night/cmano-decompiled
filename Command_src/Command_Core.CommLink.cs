using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class CommLink : ScenarioObject
{
	public ActiveUnit CommPartner;

	public string CommPartner_ObjectID;

	public CommDevice DeviceUsed;

	public void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		try
		{
			if (!Information.IsNothing((object)CommPartner))
			{
				theWriter.WriteStartElement("CommLink");
				theWriter.WriteElementString("ID", ObjectID);
				theWriter.WriteElementString("CommPartner", CommPartner.ObjectID);
				theWriter.WriteStartElement("DeviceUsed");
				theWriter.WriteRaw(DeviceUsed.ToXML(ref ObjectsAlreadySerialized));
				theWriter.WriteEndElement();
				theWriter.WriteEndElement();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100997", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static CommLink FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		CommLink result;
		try
		{
			CommLink commLink = new CommLink();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "ID":
					commLink.ObjectID_Set(val.InnerText);
					break;
				case "CommPartner":
					commLink.CommPartner_ObjectID = val.InnerText;
					break;
				case "DeviceUsed":
				{
					XmlNode theNode2 = val.ChildNodes[0];
					commLink.DeviceUsed = CommDevice.FromXML(ref theNode2, ref theDictionary, theAU);
					break;
				}
				}
			}
			result = commLink;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100998", "");
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

	private CommLink()
	{
	}

	public CommLink(ref ActiveUnit thePartner, ref CommDevice theDevice)
	{
		CommPartner = thePartner;
		DeviceUsed = theDevice;
	}

	public void PostDeserializationHousekeeping(ref ConcurrentDictionary<string, ScenarioObject> theDictionary)
	{
		if (theDictionary.TryGetValue(CommPartner_ObjectID, out var value))
		{
			CommPartner = (ActiveUnit)value;
		}
	}

	static CommLink()
	{
		Class72.smethod_20();
	}
}
