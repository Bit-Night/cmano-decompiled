using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;
using ThreadSafeCollections;

namespace Command_Core;

public sealed class Group_CommStuff : ActiveUnit_CommStuff
{
	public override bool IsConnectedToSideNetwork
	{
		get
		{
			TObservableDictionary<string, ActiveUnit> units = ((Group)myUnit).Units;
			if (units != null)
			{
				IEnumerator<KeyValuePair<string, ActiveUnit>> enumerator = units.GetEnumerator();
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Value.CommStuff.IsConnectedToSideNetwork)
					{
						return true;
					}
				}
				return false;
			}
			return false;
		}
	}

	public new static Group_CommStuff FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		Group_CommStuff result = default(Group_CommStuff);
		try
		{
			Group_CommStuff group_CommStuff = new Group_CommStuff(ref theAU);
			group_CommStuff.myUnit = theAU;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				string name = val.Name;
				if (Operators.CompareString(name, "CommLinksEstablished", false) == 0)
				{
					group_CommStuff._CommLinksEstablished = new CommLink[val.ChildNodes.Count - 1 + 1];
					int num = val.ChildNodes.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						XmlNode theNode2 = val.ChildNodes[i];
						CommLink commLink = CommLink.FromXML(ref theNode2, ref theDictionary, ref theAU);
						group_CommStuff._CommLinksEstablished[i] = commLink;
					}
				}
			}
			result = group_CommStuff;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100611", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public Group_CommStuff(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
	}

	static Group_CommStuff()
	{
		Class72.smethod_20();
	}
}
