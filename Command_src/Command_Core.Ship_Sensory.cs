using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Ship_Sensory : ActiveUnit_Sensory
{
	public new static Ship_Sensory FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Expected O, but got Unknown
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		Ship_Sensory result = default(Ship_Sensory);
		try
		{
			Ship_Sensory ship_Sensory = new Ship_Sensory(ref theAU);
			ship_Sensory.myUnit = theAU;
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
						ship_Sensory._ContactsList_OffGrid.Add(contact._ActualUnitID, contact);
					}
					break;
				case "EmissionInterval":
					ship_Sensory.IntermittentEmission = ActiveEmissionInterval.FromXML(ref theNode2);
					ship_Sensory.IntermittentEmission?.Initialize(ship_Sensory);
					break;
				case "ContactList":
				case "ContactList_Local":
					foreach (XmlNode childNode3 in theNode2.ChildNodes)
					{
						XmlNode theNode3 = childNode3;
						ContactEntry_Local value = ContactEntry_Local.FromXML(ref theNode3, ref theDictionary, ref theObjectID);
						if (!Information.IsNothing((object)theObjectID) && !ship_Sensory._ContactsList_Local.ContainsKey(theObjectID))
						{
							ship_Sensory._ContactsList_Local.Add(theObjectID, value);
						}
					}
					break;
				case "ObeysEMCON":
				case "ObE":
					ship_Sensory._ObeysEMCON = Misc.ParseBool(theNode2.InnerText);
					break;
				}
			}
			result = ship_Sensory;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100795", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public Ship_Sensory(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
	}

	public override void vmethod_2(Sensor[] sensorsList)
	{
		try
		{
			byte? b = (byte?)myUnit.Doctrine.get_IgnoreEMCONunderAttack(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
			bool? flag = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
			if ((flag ?? true) && myUnit.AI.get_ConsidersToBeUnderAttack(IgnoreThreatIfNoSensor: false) && flag.HasValue)
			{
				foreach (Sensor sensor in sensorsList)
				{
					if (sensor.CanBeActive)
					{
						sensor.GoActive();
					}
				}
			}
			else
			{
				base.vmethod_2(sensorsList);
				ActivateSensorsToHelpDatalinkedOrSemiActiveGuidedWeapons(sensorsList);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100796", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	static Ship_Sensory()
	{
		Class72.smethod_20();
	}
}
