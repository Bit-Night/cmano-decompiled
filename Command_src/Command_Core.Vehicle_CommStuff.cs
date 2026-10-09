using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Vehicle_CommStuff : ActiveUnit_CommStuff
{
	public new static Vehicle_CommStuff FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		Vehicle_CommStuff result = default(Vehicle_CommStuff);
		try
		{
			Vehicle_CommStuff vehicle_CommStuff = new Vehicle_CommStuff(ref theAU);
			vehicle_CommStuff.myUnit = theAU;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "ICS":
					vehicle_CommStuff._InternalCommsStatus = Misc.ParseBool(val.InnerText);
					break;
				case "OOC":
					if (Misc.ParseBool(val.InnerText))
					{
						vehicle_CommStuff._IsConnectedToSideNetwork = 0;
					}
					else
					{
						vehicle_CommStuff._IsConnectedToSideNetwork = 1;
					}
					break;
				case "CLE":
				{
					vehicle_CommStuff._CommLinksEstablished = new CommLink[val.ChildNodes.Count - 1 + 1];
					int num = val.ChildNodes.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						XmlNode theNode2 = val.ChildNodes[i];
						CommLink commLink = CommLink.FromXML(ref theNode2, ref theDictionary, ref theAU);
						vehicle_CommStuff._CommLinksEstablished[i] = commLink;
					}
					break;
				}
				}
			}
			result = vehicle_CommStuff;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100552", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public Vehicle_CommStuff(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
	}

	static Vehicle_CommStuff()
	{
		Class72.smethod_20();
	}
}
