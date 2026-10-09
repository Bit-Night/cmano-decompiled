using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Aircraft_Sensory : ActiveUnit_Sensory
{
	public bool HasLDSDRadar
	{
		get
		{
			bool result;
			try
			{
				Sensor[] sensors_Cached = myUnit.Sensors_Cached;
				int num = 0;
				while (true)
				{
					if (num < sensors_Cached.Length)
					{
						Sensor sensor = sensors_Cached[num];
						if (sensor.Type == Sensor.Sensor_Type.Radar)
						{
							int num2;
							if (!sensor.Codes.Doppler_LDSD_Full)
							{
								if (!sensor.Codes.Doppler_LDSD_Limited)
								{
									goto IL_003c;
								}
								num2 = 1;
							}
							else
							{
								num2 = 1;
							}
							result = (byte)num2 != 0;
							break;
						}
						goto IL_003c;
					}
					result = false;
					break;
					IL_003c:
					num = checked(num + 1);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100470", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				int num3;
				if (!Debugger.IsAttached)
				{
					num3 = 0;
				}
				else
				{
					Debugger.Break();
					num3 = 0;
				}
				result = (byte)num3 != 0;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public new static Aircraft_Sensory FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		Aircraft_Sensory result;
		try
		{
			Aircraft_Sensory aircraft_Sensory = new Aircraft_Sensory(ref theAU);
			new ActiveEmissionInterval();
			aircraft_Sensory.myUnit = theAU;
			string theObjectID = default(string);
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode theNode2 = childNode;
				switch (theNode2.Name)
				{
				case "EmissionInterval":
					aircraft_Sensory.IntermittentEmission = ActiveEmissionInterval.FromXML(ref theNode2);
					aircraft_Sensory.IntermittentEmission?.Initialize(aircraft_Sensory);
					break;
				case "ContactList_OffGrid":
					foreach (XmlNode childNode2 in theNode2.ChildNodes)
					{
						XmlNode theNode4 = childNode2;
						Contact contact = Contact.FromXML(ref theNode4, ref theDictionary);
						aircraft_Sensory._ContactsList_OffGrid.Add(contact._ActualUnitID, contact);
					}
					break;
				case "ContactList_Local":
				case "ContactList":
					foreach (XmlNode childNode3 in theNode2.ChildNodes)
					{
						XmlNode theNode3 = childNode3;
						ContactEntry_Local value = ContactEntry_Local.FromXML(ref theNode3, ref theDictionary, ref theObjectID);
						if (!Information.IsNothing((object)theObjectID) && !aircraft_Sensory._ContactsList_Local.ContainsKey(theObjectID))
						{
							aircraft_Sensory._ContactsList_Local.Add(theObjectID, value);
						}
					}
					break;
				case "ObeysEMCON":
				case "ObE":
					aircraft_Sensory._ObeysEMCON = Misc.ParseBool(theNode2.InnerText);
					break;
				}
			}
			result = aircraft_Sensory;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100469", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Aircraft_Sensory(ref theAU);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public Aircraft_Sensory(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
	}

	public override void vmethod_2(Sensor[] SensorsList)
	{
		try
		{
			if (myUnit == null)
			{
				return;
			}
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
			ex2?.Data.Add("Error at 100471", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	static Aircraft_Sensory()
	{
		Class72.smethod_20();
	}
}
