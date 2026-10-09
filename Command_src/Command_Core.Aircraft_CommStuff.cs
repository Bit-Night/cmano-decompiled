using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Aircraft_CommStuff : ActiveUnit_CommStuff
{
	public new static Aircraft_CommStuff FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Aircraft_CommStuff result;
		try
		{
			Aircraft_CommStuff aircraft_CommStuff = new Aircraft_CommStuff(ref theAU);
			aircraft_CommStuff.myUnit = theAU;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "CLE":
				{
					aircraft_CommStuff._CommLinksEstablished = new CommLink[val.ChildNodes.Count - 1 + 1];
					int num = val.ChildNodes.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						XmlNode theNode2 = val.ChildNodes[i];
						CommLink commLink = CommLink.FromXML(ref theNode2, ref theDictionary, ref theAU);
						aircraft_CommStuff._CommLinksEstablished[i] = commLink;
					}
					break;
				}
				case "ICS":
					aircraft_CommStuff._InternalCommsStatus = Misc.ParseBool(val.InnerText);
					break;
				case "OOC":
					if (Misc.ParseBool(val.InnerText))
					{
						aircraft_CommStuff._IsConnectedToSideNetwork = 0;
					}
					else
					{
						aircraft_CommStuff._IsConnectedToSideNetwork = 1;
					}
					break;
				}
			}
			result = aircraft_CommStuff;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101192", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Aircraft_CommStuff(ref theAU);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public Aircraft_CommStuff(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
	}

	static Aircraft_CommStuff()
	{
		Class72.smethod_20();
	}
}
