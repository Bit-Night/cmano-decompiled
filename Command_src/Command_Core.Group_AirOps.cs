using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Collections.Pooled;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Group_AirOps : ActiveUnit_AirOps
{
	public override PooledList<Aircraft> EmbarkedAircraft_ReadOnly
	{
		get
		{
			PooledList<Aircraft> result = default(PooledList<Aircraft>);
			try
			{
				PooledList<Aircraft> pooledList = new PooledList<Aircraft>();
				IEnumerator<KeyValuePair<string, ActiveUnit>> enumerator = ((Group)myUnit).Units.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ActiveUnit value = enumerator.Current.Value;
					foreach (Aircraft item in value.AirOps.EmbarkedAircraft_ReadOnly)
					{
						pooledList.Add(item);
					}
				}
				result = pooledList;
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100610", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
		try
		{
			theWriter.WriteStartElement("Group_AirOps");
			theWriter.WriteStartElement("LandingQueue");
			Aircraft[] landingQueue = _LandingQueue;
			foreach (Aircraft aircraft in landingQueue)
			{
				if (!Information.IsNothing((object)aircraft))
				{
					theWriter.WriteElementString("ID", aircraft.ObjectID);
				}
			}
			theWriter.WriteEndElement();
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100608", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static Group_AirOps FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		Group_AirOps result = default(Group_AirOps);
		try
		{
			Group_AirOps group_AirOps = new Group_AirOps();
			group_AirOps.myUnit = theAU;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				string name = val.Name;
				if (Operators.CompareString(name, "LandingQueue", false) == 0)
				{
					int num = val.ChildNodes.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						ArrayExtensions.Add(ref group_AirOps._LandingQueue_IDs, val.ChildNodes[i].InnerText);
					}
				}
			}
			result = group_AirOps;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100609", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private Group_AirOps()
	{
		ActiveUnit theUnit = null;
		base..ctor(ref theUnit);
	}

	public Group_AirOps(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
	}

	static Group_AirOps()
	{
		Class72.smethod_20();
	}
}
