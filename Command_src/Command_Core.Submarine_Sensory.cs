using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Submarine_Sensory : ActiveUnit_Sensory
{
	public new static Submarine_Sensory FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Expected O, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		Submarine_Sensory result = default(Submarine_Sensory);
		try
		{
			Submarine_Sensory submarine_Sensory = new Submarine_Sensory(ref theAU);
			submarine_Sensory.myUnit = theAU;
			string theObjectID = default(string);
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode theNode2 = childNode;
				switch (theNode2.Name)
				{
				case "ContactList_OffGrid":
					foreach (XmlNode childNode2 in theNode2.ChildNodes)
					{
						XmlNode theNode4 = childNode2;
						Contact contact = Contact.FromXML(ref theNode4, ref theDictionary);
						submarine_Sensory._ContactsList_OffGrid.Add(contact._ActualUnitID, contact);
					}
					break;
				case "EmissionInterval":
					submarine_Sensory.IntermittentEmission = ActiveEmissionInterval.FromXML(ref theNode2);
					submarine_Sensory.IntermittentEmission?.Initialize(submarine_Sensory);
					break;
				case "ContactList":
				case "ContactList_Local":
					foreach (XmlNode childNode3 in theNode2.ChildNodes)
					{
						XmlNode theNode3 = childNode3;
						ContactEntry_Local value = ContactEntry_Local.FromXML(ref theNode3, ref theDictionary, ref theObjectID);
						if (!Information.IsNothing((object)theObjectID) && !submarine_Sensory._ContactsList_Local.ContainsKey(theObjectID))
						{
							submarine_Sensory._ContactsList_Local.Add(theObjectID, value);
						}
					}
					break;
				case "ObE":
					submarine_Sensory._ObeysEMCON = Misc.ParseBool(theNode2.InnerText);
					break;
				}
			}
			result = submarine_Sensory;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100839", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public Submarine_Sensory(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
	}

	static Submarine_Sensory()
	{
		Class72.smethod_20();
	}
}
