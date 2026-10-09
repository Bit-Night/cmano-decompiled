using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Ship_CommStuff : ActiveUnit_CommStuff
{
	public Ship_CommStuff(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
	}

	public new static Ship_CommStuff FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		Ship_CommStuff result;
		try
		{
			Ship_CommStuff ship_CommStuff = new Ship_CommStuff(ref theAU);
			ship_CommStuff.myUnit = theAU;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "OOC":
					if (Misc.ParseBool(val.InnerText))
					{
						ship_CommStuff._IsConnectedToSideNetwork = 0;
					}
					else
					{
						ship_CommStuff._IsConnectedToSideNetwork = 1;
					}
					break;
				case "ICS":
					ship_CommStuff._InternalCommsStatus = Misc.ParseBool(val.InnerText);
					break;
				case "CLE":
				{
					ship_CommStuff._CommLinksEstablished = new CommLink[val.ChildNodes.Count - 1 + 1];
					int num = val.ChildNodes.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						XmlNode theNode2 = val.ChildNodes[i];
						CommLink commLink = CommLink.FromXML(ref theNode2, ref theDictionary, ref theAU);
						ship_CommStuff._CommLinksEstablished[i] = commLink;
					}
					break;
				}
				}
			}
			result = ship_CommStuff;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100782", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Ship_CommStuff(ref theAU);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	static Ship_CommStuff()
	{
		Class72.smethod_20();
	}
}
