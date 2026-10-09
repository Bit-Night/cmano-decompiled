using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml;

namespace Command_Core;

public class Transmission
{
	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private Side side_0;

	[CompilerGenerated]
	private List<TransmittedContactData> list_0;

	[CompilerGenerated]
	private ActiveUnit activeUnit_0;

	[CompilerGenerated]
	private List<string> list_1;

	[CompilerGenerated]
	private DateTime dateTime_0;

	[CompilerGenerated]
	private double double_0;

	[CompilerGenerated]
	private double double_1;

	[CompilerGenerated]
	private List<ActiveUnit> list_2;

	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private double double_2;

	[CompilerGenerated]
	private CommDevice commDevice_0;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private string string_2;

	public int ID
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public Side Side
	{
		[CompilerGenerated]
		get
		{
			return side_0;
		}
		[CompilerGenerated]
		set
		{
			side_0 = value;
		}
	}

	public List<TransmittedContactData> ContactsData
	{
		[CompilerGenerated]
		get
		{
			return list_0;
		}
		[CompilerGenerated]
		set
		{
			list_0 = value;
		}
	}

	public ActiveUnit OriginalDetector
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

	public List<string> DestinationUnitIDList
	{
		[CompilerGenerated]
		get
		{
			return list_1;
		}
		[CompilerGenerated]
		set
		{
			list_1 = value;
		}
	}

	public DateTime OriginalTransmissionTime
	{
		[CompilerGenerated]
		get
		{
			return dateTime_0;
		}
		[CompilerGenerated]
		set
		{
			dateTime_0 = value;
		}
	}

	public double TransitTime
	{
		[CompilerGenerated]
		get
		{
			return double_0;
		}
		[CompilerGenerated]
		set
		{
			double_0 = value;
		}
	}

	public double TransmissionDelay
	{
		[CompilerGenerated]
		get
		{
			return double_1;
		}
		[CompilerGenerated]
		set
		{
			double_1 = value;
		}
	}

	public List<ActiveUnit> SenderUnitList
	{
		[CompilerGenerated]
		get
		{
			return list_2;
		}
		[CompilerGenerated]
		set
		{
			list_2 = value;
		}
	}

	public string DetectionSensorID
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public double TransmissionDuration
	{
		[CompilerGenerated]
		get
		{
			return double_2;
		}
		[CompilerGenerated]
		set
		{
			double_2 = value;
		}
	}

	public CommDevice TheCommDevice
	{
		[CompilerGenerated]
		get
		{
			return commDevice_0;
		}
		[CompilerGenerated]
		set
		{
			commDevice_0 = value;
		}
	}

	public string Bandwidth
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
		[CompilerGenerated]
		set
		{
			string_1 = value;
		}
	}

	public string RefreshGrade
	{
		[CompilerGenerated]
		get
		{
			return string_2;
		}
		[CompilerGenerated]
		set
		{
			string_2 = value;
		}
	}

	public Transmission()
	{
		DestinationUnitIDList = new List<string>();
		TransitTime = 0.0;
		TransmissionDelay = 0.0;
		SenderUnitList = new List<ActiveUnit>();
		TransmissionDuration = 0.0;
	}

	public Transmission(ActiveUnit SenderUnit, CommDevice theCommDevice, List<TransmittedContactData> theContactsData, ActiveUnit originalDetector, string DetectionSensorID, string destinationUnitID, DateTime originalTransmissionTime, double transitTime, double transmissionDelay, double transmissionDuration)
		: this(SenderUnit, theCommDevice, theContactsData, originalDetector, DetectionSensorID, new List<string> { destinationUnitID }, originalTransmissionTime, transitTime, transmissionDelay, transmissionDuration)
	{
	}

	public Transmission(ActiveUnit SenderUnit, CommDevice theCommDevice, List<TransmittedContactData> theContactsData, ActiveUnit originalDetector, string DetectionSensorID, List<string> destinationUnitID, DateTime originalTransmissionTime, double transitTime, double transmissionDelay, double transmissionDuration)
	{
		DestinationUnitIDList = new List<string>();
		TransitTime = 0.0;
		TransmissionDelay = 0.0;
		SenderUnitList = new List<ActiveUnit>();
		TransmissionDuration = 0.0;
		ID = SenderUnit.ParentScen.GetNextTransmissionID();
		DestinationUnitIDList = destinationUnitID;
		TheCommDevice = theCommDevice;
		ContactsData = theContactsData;
		OriginalTransmissionTime = originalTransmissionTime;
		TransitTime = transitTime;
		OriginalDetector = originalDetector;
		SenderUnitList = new List<ActiveUnit> { SenderUnit };
		TransmissionDelay = transmissionDelay;
		this.DetectionSensorID = DetectionSensorID;
		TransmissionDuration = transmissionDuration;
		Bandwidth = TheCommDevice.QualityGradeinfo.Description;
		RefreshGrade = TheCommDevice.LatencyGradenfo.Description;
	}

	internal static Transmission FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary)
	{
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected O, but got Unknown
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Expected O, but got Unknown
		Transmission transmission = new Transmission();
		ActiveUnit activeUnit = null;
		XmlNode obj = theNode.SelectSingleNode("ID");
		int.Parse((obj != null) ? obj.InnerText : null);
		XmlNode obj2 = theNode.SelectSingleNode("OriginalDetectorID");
		string text = ((obj2 == null) ? null : obj2.InnerText);
		if (!string.IsNullOrEmpty(text) && theDictionary.ContainsKey(text))
		{
			activeUnit = (ActiveUnit)theDictionary[text];
		}
		if (activeUnit != null)
		{
			transmission.OriginalDetector = activeUnit;
		}
		XmlNode theNode2 = theNode.SelectSingleNode("TheCommDevice");
		if (theNode2 != null)
		{
			transmission.TheCommDevice = CommDevice.FromXML(ref theNode2, ref theDictionary, activeUnit);
		}
		XmlNode val = theNode.SelectSingleNode("DestinationUnitIDList");
		if (val != null)
		{
			foreach (XmlNode item in val.SelectNodes("DestinationUnitID"))
			{
				XmlNode val2 = item;
				transmission.DestinationUnitIDList.Add(val2.InnerText);
			}
		}
		XmlNode val3 = theNode.SelectSingleNode("SenderUnitList");
		if (val3 != null)
		{
			foreach (XmlNode item2 in val3.SelectNodes("SenderUnitID"))
			{
				string innerText = item2.InnerText;
				if (theDictionary.ContainsKey(innerText) && theDictionary[innerText] is ActiveUnit)
				{
					transmission.SenderUnitList.Add((ActiveUnit)theDictionary[innerText]);
				}
			}
		}
		XmlNodeList val4 = theNode.SelectNodes("ContactsData/TransmittedContactData");
		if (val4 != null)
		{
			foreach (XmlNode item3 in val4)
			{
				TransmittedContactData transmittedContactData = TransmittedContactData.FromXML(item3, theDictionary);
				if (transmittedContactData != null)
				{
					transmission.ContactsData.Add(transmittedContactData);
				}
			}
		}
		XmlNode obj3 = theNode.SelectSingleNode("OriginalTransmissionTime");
		transmission.OriginalTransmissionTime = DateTime.Parse((obj3 != null) ? obj3.InnerText : null);
		XmlNode obj4 = theNode.SelectSingleNode("TransitTime");
		transmission.TransitTime = double.Parse((obj4 == null) ? null : obj4.InnerText);
		XmlNode obj5 = theNode.SelectSingleNode("TransmissionDelay");
		transmission.TransmissionDelay = double.Parse((obj5 == null) ? null : obj5.InnerText);
		XmlNode obj6 = theNode.SelectSingleNode("TransmissionDuration");
		transmission.TransmissionDuration = double.Parse((obj6 != null) ? obj6.InnerText : null);
		XmlNode obj7 = theNode.SelectSingleNode("DetectionSensorID");
		transmission.DetectionSensorID = ((obj7 == null) ? null : obj7.InnerText);
		transmission.Bandwidth = transmission.TheCommDevice.QualityGradeinfo.Description;
		transmission.RefreshGrade = transmission.TheCommDevice.LatencyGradenfo.Description;
		return transmission;
	}

	internal void ToXML(XmlWriter theWriter)
	{
		HashSet<string> ObjectsAlreadySerialized = new HashSet<string>();
		theWriter.WriteStartElement("ContactTransmission");
		theWriter.WriteElementString("ID", ID.ToString());
		if (TheCommDevice != null)
		{
			theWriter.WriteStartElement("TheCommDevice");
			theWriter.WriteRaw(TheCommDevice.ToXML(ref ObjectsAlreadySerialized));
			theWriter.WriteEndElement();
		}
		theWriter.WriteStartElement("DestinationUnitIDList");
		if (DestinationUnitIDList != null)
		{
			foreach (string destinationUnitID in DestinationUnitIDList)
			{
				theWriter.WriteElementString("DestinationUnitID", destinationUnitID);
			}
		}
		theWriter.WriteEndElement();
		theWriter.WriteStartElement("SenderUnitList");
		if (SenderUnitList != null)
		{
			foreach (ActiveUnit senderUnit in SenderUnitList)
			{
				theWriter.WriteElementString("SenderUnitID", senderUnit.ObjectID);
			}
		}
		theWriter.WriteEndElement();
		if (OriginalDetector != null)
		{
			theWriter.WriteElementString("OriginalDetectorID", OriginalDetector.ObjectID);
		}
		theWriter.WriteStartElement("ContactsData");
		if (ContactsData != null)
		{
			foreach (TransmittedContactData contactsDatum in ContactsData)
			{
				contactsDatum.ToXML(theWriter, ObjectsAlreadySerialized);
			}
		}
		theWriter.WriteEndElement();
		theWriter.WriteElementString("OriginalTransmissionTime", OriginalTransmissionTime.ToString("o"));
		theWriter.WriteElementString("TransitTime", TransitTime.ToString());
		theWriter.WriteElementString("TransmissionDelay", TransmissionDelay.ToString());
		theWriter.WriteElementString("TransmissionDuration", TransmissionDuration.ToString());
		theWriter.WriteElementString("DetectionSensorID", DetectionSensorID);
		theWriter.WriteElementString("Bandwidth", Bandwidth);
		theWriter.WriteElementString("RefreshGrade", RefreshGrade);
		theWriter.WriteEndElement();
	}

	static Transmission()
	{
		Class72.smethod_20();
	}
}
