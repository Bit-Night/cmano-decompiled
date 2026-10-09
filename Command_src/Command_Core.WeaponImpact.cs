using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Collections.Pooled;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class WeaponImpact : Module_Unit.Unit
{
	public enum ImpactType : short
	{
		Kinetic,
		Electronic
	}

	public ImpactType Type;

	public float Age;

	public int int_1;

	public WeaponImpact(ref Scenario theScen, double theLongitude, double theLatitude, float theAltitude, ImpactType theType, int theWeaponDBID)
	{
		((Module_Unit.Unit)this).set_Longitude((GlobalVariables.BooleanObject)null, theLongitude);
		((Module_Unit.Unit)this).set_Latitude((GlobalVariables.BooleanObject)null, theLatitude);
		((Module_Unit.Unit)this).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, theAltitude);
		Type = theType;
		int_1 = theWeaponDBID;
		if (!Information.IsNothing((object)theScen))
		{
			theScen.WeaponImpacts.Add(this);
		}
	}

	public override void ToXML(ref XmlWriter Writer, ref HashSet<string> ObjectsAlreadySerialized)
	{
		try
		{
			Writer.WriteStartElement("WeaponImpact");
			Writer.WriteElementString("ID", ObjectID);
			if (ObjectsAlreadySerialized.Contains(ObjectID))
			{
				Writer.WriteEndElement();
				return;
			}
			ObjectsAlreadySerialized.Add(ObjectID);
			Writer.WriteElementString("Name", Name);
			Writer.WriteElementString("CurrentAltitude", XmlConvert.ToString(((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)));
			Writer.WriteElementString("Longitude", XmlConvert.ToString(((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null)));
			Writer.WriteElementString("Latitude", XmlConvert.ToString(((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null)));
			XmlWriter obj = Writer;
			short type = (short)Type;
			obj.WriteElementString("Type", type.ToString());
			Writer.WriteElementString("Age", XmlConvert.ToString(Age));
			Writer.WriteElementString("Message", Message);
			Writer.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101328", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private WeaponImpact()
	{
	}

	public void Progress(ref Scenario theScen, float elapsedTime)
	{
		if (Age == 0f)
		{
			Age = 0.1f;
		}
		else
		{
			Age += elapsedTime;
		}
	}

	public static WeaponImpact FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		WeaponImpact result;
		try
		{
			WeaponImpact weaponImpact = new WeaponImpact();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "CurrentAltitude":
					((Module_Unit.Unit)weaponImpact).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, XmlConvert.ToSingle(val.InnerText));
					break;
				case "Name":
					weaponImpact.Name = val.InnerText;
					break;
				case "Latitude":
					((Module_Unit.Unit)weaponImpact).set_Latitude((GlobalVariables.BooleanObject)null, XmlConvert.ToDouble(val.InnerText));
					break;
				case "Longitude":
					((Module_Unit.Unit)weaponImpact).set_Longitude((GlobalVariables.BooleanObject)null, XmlConvert.ToDouble(val.InnerText));
					break;
				case "ID":
					if (!theDictionary.ContainsKey(val.InnerText))
					{
						weaponImpact.ObjectID_Set(val.InnerText);
						theDictionary.TryAdd(weaponImpact.ObjectID, weaponImpact);
						break;
					}
					result = (WeaponImpact)theDictionary[val.InnerText];
					goto end_IL_0001;
				case "Message":
					weaponImpact.Message = val.InnerText;
					break;
				case "Age":
					weaponImpact.Age = XmlConvert.ToSingle(val.InnerText);
					break;
				case "CurrentHeading":
					weaponImpact.CurrentHeading = (float)XmlConvert.ToDouble(val.InnerText);
					break;
				case "Type":
					if (val.InnerText.Contains("Kinetic"))
					{
						weaponImpact.Type = ImpactType.Kinetic;
					}
					else
					{
						weaponImpact.Type = (ImpactType)Conversions.ToShort(val.InnerText);
					}
					break;
				case "CurrentSpeed":
					weaponImpact.CurrentSpeed = (float)XmlConvert.ToDouble(val.InnerText);
					break;
				}
			}
			result = weaponImpact;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100880", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new WeaponImpact();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static void ExportWeaponImpactEvent(WeaponImpact theImpact, Scenario theScen)
	{
		IEventExporter[] applicableEventExporters = theScen.ApplicableEventExporters;
		foreach (IEventExporter eventExporter in applicableEventExporters)
		{
			if (eventExporter.IsOperating && eventExporter.ExportExplosions)
			{
				PooledDictionary<string, IEventExporter.EventNotificationParameter> pooledDictionary = new PooledDictionary<string, IEventExporter.EventNotificationParameter>(30, ClearMode.Always);
				if (theScen.MonteCarloIteration > 0)
				{
					pooledDictionary.Add("Scenario", new IEventExporter.EventNotificationParameter(theScen.Title, typeof(string), 500));
					pooledDictionary.Add("MC_Run", new IEventExporter.EventNotificationParameter(theScen.MonteCarloIteration, typeof(int)));
				}
				pooledDictionary.Add("TimelineID", new IEventExporter.EventNotificationParameter(theScen.TimelineID, typeof(string), 40));
				if (!eventExporter.UseZeroHour)
				{
					pooledDictionary.Add("Time", new IEventExporter.EventNotificationParameter(theScen.Time.ToString("MM/dd/yyyy HH:mm:ss") + "." + theScen.Time.Millisecond.ToString("D3"), typeof(DateTime)));
				}
				else
				{
					pooledDictionary.Add("Time", new IEventExporter.EventNotificationParameter(theScen.Time.Subtract(theScen.ZeroHour).ToString("c"), typeof(TimeSpan), 30));
				}
				pooledDictionary.Add("UnitID", new IEventExporter.EventNotificationParameter(theImpact.ObjectID, typeof(string), 40));
				pooledDictionary.Add("UnitLongitude", new IEventExporter.EventNotificationParameter(((Module_Unit.Unit)theImpact).get_Longitude((GlobalVariables.BooleanObject)null), typeof(double)));
				pooledDictionary.Add("UnitLatitude", new IEventExporter.EventNotificationParameter(((Module_Unit.Unit)theImpact).get_Latitude((GlobalVariables.BooleanObject)null), typeof(double)));
				pooledDictionary.Add("UnitCourse", new IEventExporter.EventNotificationParameter(theImpact.CurrentHeading, typeof(float)));
				pooledDictionary.Add("UnitSpeed_kts", new IEventExporter.EventNotificationParameter(theImpact.CurrentSpeed, typeof(float)));
				pooledDictionary.Add("UnitAltitude_m", new IEventExporter.EventNotificationParameter(((Module_Unit.Unit)theImpact).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), typeof(float)));
				eventExporter.ExportEvent(IEventExporter.ExportedEventType.WeaponImpact, pooledDictionary, theScen);
			}
		}
		ISimConnector[] activeSimConnectors = SimConnect_General.ActiveSimConnectors;
		for (int j = 0; j < activeSimConnectors.Length; j = checked(j + 1))
		{
			_ = activeSimConnectors[j].ExportWeaponImpactOrDetonation;
		}
	}

	static WeaponImpact()
	{
		Class72.smethod_20();
	}
}
