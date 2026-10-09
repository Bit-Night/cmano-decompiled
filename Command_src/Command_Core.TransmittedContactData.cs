using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml;

namespace Command_Core;

public class TransmittedContactData
{
	[CompilerGenerated]
	private Sensor sensor_0;

	[CompilerGenerated]
	private Contact contact_0;

	[CompilerGenerated]
	private ActiveUnit activeUnit_0;

	public Sensor TheSensor
	{
		[CompilerGenerated]
		get
		{
			return sensor_0;
		}
		[CompilerGenerated]
		set
		{
			sensor_0 = value;
		}
	}

	public Contact TheContact
	{
		[CompilerGenerated]
		get
		{
			return contact_0;
		}
		[CompilerGenerated]
		set
		{
			contact_0 = value;
		}
	}

	public ActiveUnit TheTransmittingUnit
	{
		[CompilerGenerated]
		get
		{
			return activeUnit_0;
		}
		[CompilerGenerated]
		set
		{
			activeUnit_0 = value;
		}
	}

	public TransmittedContactData(Sensor sensor, Contact contact, ActiveUnit TransmittingUnit)
	{
		if (sensor == null && Debugger.IsAttached)
		{
			Debugger.Break();
		}
		TheSensor = sensor;
		TheContact = contact;
		TheTransmittingUnit = TransmittingUnit;
	}

	internal void ToXML(XmlWriter theWriter, HashSet<string> ObjectsAlreadySerialized)
	{
		theWriter.WriteStartElement("TransmittedContactData");
		if (TheSensor != null)
		{
			theWriter.WriteElementString("TheSensorID", TheSensor.ObjectID);
		}
		if (TheTransmittingUnit != null)
		{
			theWriter.WriteElementString("TheTransmittingUnitID", TheTransmittingUnit.ObjectID);
		}
		if (TheContact != null)
		{
			theWriter.WriteStartElement("TheContact");
			theWriter.WriteRaw(TheContact.ToXML(ObjectsAlreadySerialized, TheTransmittingUnit.get_UnitSide(SetSideOnly: false)));
			theWriter.WriteEndElement();
		}
		theWriter.WriteEndElement();
	}

	internal static TransmittedContactData FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary)
	{
		XmlNode obj = theNode.SelectSingleNode("TheSensorID");
		string text = ((obj == null) ? null : obj.InnerText);
		XmlNode obj2 = theNode.SelectSingleNode("TheTransmittingUnitID");
		string text2 = ((obj2 == null) ? null : obj2.InnerText);
		Sensor sensor = null;
		if (!string.IsNullOrEmpty(text) && theDictionary.ContainsKey(text))
		{
			sensor = (Sensor)theDictionary[text];
		}
		ActiveUnit activeUnit = null;
		if (!string.IsNullOrEmpty(text2) && theDictionary.ContainsKey(text2))
		{
			activeUnit = (ActiveUnit)theDictionary[text2];
		}
		XmlNode theNode2 = theNode.SelectSingleNode("TheContact");
		Contact contact = null;
		if (theNode2 != null)
		{
			contact = Contact.FromXML(ref theNode2, ref theDictionary);
		}
		if (sensor != null && contact != null && activeUnit != null)
		{
			return new TransmittedContactData(sensor, contact, activeUnit);
		}
		return null;
	}

	static TransmittedContactData()
	{
		Class72.smethod_20();
	}
}
