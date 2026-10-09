using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Facility_CommStuff : ActiveUnit_CommStuff
{
	public new static Facility_CommStuff FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		Facility_CommStuff result = default(Facility_CommStuff);
		try
		{
			Facility_CommStuff facility_CommStuff = new Facility_CommStuff(ref theAU);
			facility_CommStuff.myUnit = theAU;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "CLE":
				{
					facility_CommStuff._CommLinksEstablished = new CommLink[val.ChildNodes.Count - 1 + 1];
					int num = val.ChildNodes.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						XmlNode theNode2 = val.ChildNodes[i];
						CommLink commLink = CommLink.FromXML(ref theNode2, ref theDictionary, ref theAU);
						facility_CommStuff._CommLinksEstablished[i] = commLink;
					}
					break;
				}
				case "OOC":
					if (!Misc.ParseBool(val.InnerText))
					{
						facility_CommStuff._IsConnectedToSideNetwork = 1;
					}
					else
					{
						facility_CommStuff._IsConnectedToSideNetwork = 0;
					}
					break;
				case "ICS":
					facility_CommStuff._InternalCommsStatus = Misc.ParseBool(val.InnerText);
					break;
				}
			}
			result = facility_CommStuff;
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

	public Facility_CommStuff(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
	}

	static Facility_CommStuff()
	{
		Class72.smethod_20();
	}
}
