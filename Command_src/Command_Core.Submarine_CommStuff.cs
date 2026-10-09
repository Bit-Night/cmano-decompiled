using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Submarine_CommStuff : ActiveUnit_CommStuff
{
	public new static Submarine_CommStuff FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		Submarine_CommStuff result;
		try
		{
			Submarine_CommStuff submarine_CommStuff = new Submarine_CommStuff(ref theAU);
			submarine_CommStuff.myUnit = theAU;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "CLE":
				{
					submarine_CommStuff._CommLinksEstablished = new CommLink[val.ChildNodes.Count - 1 + 1];
					int num = val.ChildNodes.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						XmlNode theNode2 = val.ChildNodes[i];
						CommLink commLink = CommLink.FromXML(ref theNode2, ref theDictionary, ref theAU);
						submarine_CommStuff._CommLinksEstablished[i] = commLink;
					}
					break;
				}
				case "OOC":
					if (!Misc.ParseBool(val.InnerText))
					{
						submarine_CommStuff._IsConnectedToSideNetwork = 1;
					}
					else
					{
						submarine_CommStuff._IsConnectedToSideNetwork = 0;
					}
					break;
				case "ICS":
					submarine_CommStuff._InternalCommsStatus = Misc.ParseBool(val.InnerText);
					break;
				}
			}
			result = submarine_CommStuff;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100827", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Submarine_CommStuff(ref theAU);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public Submarine_CommStuff(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
	}

	static Submarine_CommStuff()
	{
		Class72.smethod_20();
	}
}
