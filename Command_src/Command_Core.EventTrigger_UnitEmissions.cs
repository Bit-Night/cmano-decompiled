using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EventTrigger_UnitEmissions : EventTrigger
{
	public UnitFilterObject TargetFilter;

	public string DetectorSideID;

	public Contact_Base.IdentificationStatus MinimumClassificationLevel;

	public ActiveUnit DetectedUnit;

	public ActiveUnit DetectingUnit;

	public Contact DetectedAsContact;

	public List<ReferencePoint> Area;

	public List<Sensor> SensorsThatMadeDetection;

	public bool? DetectedInArea;

	public bool IsFulfilled
	{
		get
		{
			DetectedAsContact = null;
			DetectedUnit = null;
			DetectingUnit = null;
			SensorsThatMadeDetection = null;
			bool flag = false;
			Contact contact = theDetectingUnit.get_UnitSide(SetSideOnly: false).Contacts[theDetectedUnit.ObjectID];
			if (Information.IsNothing((object)contact))
			{
				contact = theDetectingUnit.get_UnitSide(SetSideOnly: false).NewContactsQueue[theDetectedUnit.ObjectID];
			}
			if (contact.DetectedEmissions != null && !contact.DetectedEmissions.Equals(contact._DetectedEmissionsPrevious))
			{
				if (contact.DetectedEmissions.Count == 0)
				{
					return false;
				}
				Side side = theDetectingUnit.get_UnitSide(SetSideOnly: false);
				flag = Operators.CompareString(DetectorSideID, side.ObjectID, false) == 0 && (TargetFilter.MatchesThisUnit(theDetectedUnit) ? true : false);
				if (flag)
				{
					DetectedUnit = theDetectedUnit;
					theDetectedUnit.ParentScen.Scenario_LuaSandbox.UnitX = theDetectedUnit;
					DetectingUnit = theDetectingUnit;
					theDetectedUnit.ParentScen.Scenario_LuaSandbox.UnitY = theDetectingUnit;
					SensorsThatMadeDetection = theSensorsThatMadeDetection;
					DetectedAsContact = contact;
					if (!Information.IsNothing((object)contact))
					{
						theDetectedUnit.ParentScen.Scenario_LuaSandbox.UnitC = contact;
					}
					contact._DetectedEmissionsPrevious = contact.DetectedEmissions;
				}
				else
				{
					DetectedAsContact = null;
					DetectedUnit = null;
					DetectingUnit = null;
					SensorsThatMadeDetection = null;
				}
				return flag;
			}
			return false;
		}
	}

	public EventTrigger_UnitEmissions()
	{
		TargetFilter = new UnitFilterObject();
		MinimumClassificationLevel = Contact_Base.IdentificationStatus.Unknown;
		Area = new List<ReferencePoint>();
		DetectedInArea = null;
		Type = EventTriggerType.UnitEmissions;
	}

	public override void ToXML(XmlWriter theWriter, HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("EventTrigger_UnitEmissions");
			theWriter.WriteElementString("ID", ObjectID);
			theWriter.WriteElementString("Description", Description);
			theWriter.WriteStartElement("TargetFilter");
			TargetFilter.ToXML(theWriter, ObjectsAlreadySerialized, theScen);
			theWriter.WriteEndElement();
			theWriter.WriteStartElement("Area");
			foreach (ReferencePoint item in Area)
			{
				theWriter.WriteRaw(item.ToXML(ref ObjectsAlreadySerialized));
			}
			theWriter.WriteEndElement();
			theWriter.WriteElementString("DetectorSideID", DetectorSideID);
			short minimumClassificationLevel = (short)MinimumClassificationLevel;
			theWriter.WriteElementString("MCL", minimumClassificationLevel.ToString());
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100530", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static EventTrigger_UnitEmissions FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		EventTrigger_UnitEmissions result;
		try
		{
			EventTrigger_UnitEmissions eventTrigger_UnitEmissions = new EventTrigger_UnitEmissions();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "Description":
					eventTrigger_UnitEmissions.Description = val.InnerText;
					break;
				case "Area":
					foreach (XmlNode childNode2 in val.ChildNodes)
					{
						XmlNode theNode2 = childNode2;
						eventTrigger_UnitEmissions.Area.Add(ReferencePoint.FromXML(ref theNode2, ref theDictionary, theScen));
					}
					break;
				case "DetectorSideID":
					eventTrigger_UnitEmissions.DetectorSideID = val.InnerText;
					break;
				case "MCL":
					eventTrigger_UnitEmissions.MinimumClassificationLevel = (Contact_Base.IdentificationStatus)Conversions.ToShort(val.InnerText);
					break;
				case "TargetFilter":
					eventTrigger_UnitEmissions.TargetFilter = UnitFilterObject.FromXML(val, theDictionary, theScen);
					break;
				case "ID":
					eventTrigger_UnitEmissions.ObjectID_Set(val.InnerText);
					break;
				}
			}
			result = eventTrigger_UnitEmissions;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100531", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new EventTrigger_UnitEmissions();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override EventTrigger Clone()
	{
		EventTrigger_UnitEmissions obj = (EventTrigger_UnitEmissions)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[CLONE] " + Description;
		obj.Name = "[CLONE] " + Name;
		obj.TargetFilter = TargetFilter.Clone();
		obj.Area = Area.GetRange(0, Area.Count);
		return obj;
	}

	static EventTrigger_UnitEmissions()
	{
		Class72.smethod_20();
	}
}
