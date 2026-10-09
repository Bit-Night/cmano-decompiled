using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Group_Sensory : ActiveUnit_Sensory
{
	public override bool ObeysEMCON
	{
		get
		{
			return base.ObeysEMCON;
		}
		set
		{
			try
			{
				base.ObeysEMCON = value;
				foreach (ActiveUnit value2 in ((Group)myUnit).Units.Values)
				{
					value2.Sensory.ObeysEMCON = value;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100624", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public new static Group_Sensory FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected O, but got Unknown
		Group_Sensory result;
		try
		{
			Group_Sensory group_Sensory = new Group_Sensory(ref theAU);
			group_Sensory.myUnit = theAU;
			string theObjectID = default(string);
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode theNode2 = childNode;
				switch (theNode2.Name)
				{
				case "ContactList":
				case "ContactList_Local":
					foreach (XmlNode childNode2 in theNode2.ChildNodes)
					{
						XmlNode theNode3 = childNode2;
						ContactEntry_Local value = ContactEntry_Local.FromXML(ref theNode3, ref theDictionary, ref theObjectID);
						if (!Information.IsNothing((object)theObjectID) && !group_Sensory._ContactsList_Local.ContainsKey(theObjectID))
						{
							group_Sensory._ContactsList_Local.Add(theObjectID, value);
						}
					}
					break;
				case "ContactList_OffGrid":
					foreach (XmlNode childNode3 in theNode2.ChildNodes)
					{
						XmlNode theNode4 = childNode3;
						Contact contact = Contact.FromXML(ref theNode4, ref theDictionary);
						group_Sensory._ContactsList_OffGrid.Add(contact._ActualUnitID, contact);
					}
					break;
				case "EmissionInterval":
					group_Sensory.IntermittentEmission = ActiveEmissionInterval.FromXML(ref theNode2);
					group_Sensory.IntermittentEmission?.Initialize(group_Sensory);
					break;
				case "ObeysEMCON":
				case "ObE":
					group_Sensory._ObeysEMCON = Misc.ParseBool(theNode2.InnerText);
					break;
				}
			}
			result = group_Sensory;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100235", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Group_Sensory(ref theAU);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public Group_Sensory(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
	}

	static Group_Sensory()
	{
		Class72.smethod_20();
	}
}
