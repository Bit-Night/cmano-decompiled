using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Facility_Sensory : ActiveUnit_Sensory
{
	public new static Facility_Sensory FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Expected O, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		Facility_Sensory result;
		try
		{
			Facility_Sensory facility_Sensory = new Facility_Sensory(ref theAU);
			facility_Sensory.myUnit = theAU;
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
						facility_Sensory._ContactsList_OffGrid.Add(contact._ActualUnitID, contact);
					}
					break;
				case "EmissionInterval":
					facility_Sensory.IntermittentEmission = ActiveEmissionInterval.FromXML(ref theNode2);
					facility_Sensory.IntermittentEmission?.Initialize(facility_Sensory);
					break;
				case "ContactList":
				case "ContactList_Local":
					foreach (XmlNode childNode3 in theNode2.ChildNodes)
					{
						XmlNode theNode3 = childNode3;
						ContactEntry_Local value = ContactEntry_Local.FromXML(ref theNode3, ref theDictionary, ref theObjectID);
						if (!Information.IsNothing((object)theObjectID) && !facility_Sensory._ContactsList_Local.ContainsKey(theObjectID))
						{
							facility_Sensory._ContactsList_Local.Add(theObjectID, value);
						}
					}
					break;
				case "ObeysEMCON":
				case "ObE":
					facility_Sensory._ObeysEMCON = Misc.ParseBool(theNode2.InnerText);
					break;
				}
			}
			result = facility_Sensory;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100566", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Facility_Sensory(ref theAU);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public Facility_Sensory(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
	}

	public override void vmethod_2(Sensor[] SensorsList)
	{
		try
		{
			byte? b = (byte?)myUnit.Doctrine.get_IgnoreEMCONunderAttack(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
			bool? flag = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
			if ((flag ?? true) && myUnit.AI.get_ConsidersToBeUnderAttack(IgnoreThreatIfNoSensor: false) && flag.HasValue)
			{
				foreach (Sensor sensor in SensorsList)
				{
					if (sensor.CanBeActive)
					{
						sensor.GoActive();
					}
				}
			}
			else
			{
				base.vmethod_2(SensorsList);
				ActivateSensorsToHelpDatalinkedOrSemiActiveGuidedWeapons(SensorsList);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100567", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	static Facility_Sensory()
	{
		Class72.smethod_20();
	}
}
