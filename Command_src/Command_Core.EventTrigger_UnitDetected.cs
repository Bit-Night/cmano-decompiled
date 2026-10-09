using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EventTrigger_UnitDetected : EventTrigger
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
			DetectedInArea = null;
			bool flag;
			bool? flag2;
			Contact value;
			if (identificationStatus_0 >= MinimumClassificationLevel)
			{
				flag = false;
				flag2 = null;
				if (!theDetectingUnit.get_UnitSide(SetSideOnly: false).Contacts.TryGetValue(theDetectedUnit.ObjectID, out value))
				{
					value = theDetectingUnit.get_UnitSide(SetSideOnly: false).NewContactsQueue[theDetectedUnit.ObjectID];
				}
				if (Area.Count > 0)
				{
					if (value == null)
					{
						return false;
					}
					if (((Module_Unit.Unit)value).get_Latitude((GlobalVariables.BooleanObject)null) == 0.0 || ((Module_Unit.Unit)value).get_Longitude((GlobalVariables.BooleanObject)null) == 0.0)
					{
						if (value.ActualUnit.Latitude_LastReported.HasValue)
						{
							((Module_Unit.Unit)value).set_Latitude((GlobalVariables.BooleanObject)null, value.ActualUnit.Latitude_LastReported.Value);
						}
						if (value.ActualUnit.Longitude_LastReported.HasValue)
						{
							((Module_Unit.Unit)value).set_Longitude((GlobalVariables.BooleanObject)null, value.ActualUnit.Longitude_LastReported.Value);
						}
					}
					if (!((Module_Unit.Unit)value).get_IsInsideThisArea(Area, theDetectedUnit.ParentScen, UseCache: false))
					{
						flag2 = false;
						if (value.ActiveEnterAreaTriggers.Count > 0)
						{
							value.ActiveEnterAreaTriggers.Remove(ObjectID);
						}
					}
					else
					{
						flag2 = true;
					}
				}
				Side side = theDetectingUnit.get_UnitSide(SetSideOnly: false);
				if (Operators.CompareString(DetectorSideID, side.ObjectID, false) == 0)
				{
					if (TargetFilter.MatchesThisUnit(theDetectedUnit))
					{
						if (flag2.HasValue && !flag2 == true)
						{
							flag = false;
						}
						else if (Area.Count != 0)
						{
							if (value != null && value.ActiveEnterAreaTriggers.FirstOrDefault([SpecialName] (string s) => Operators.CompareString(s, ObjectID, false) == 0) == null)
							{
								flag = true;
							}
						}
						else if (ContactWasDetectedOnThisPulse)
						{
							flag = true;
						}
						else
						{
							int num;
							if (!PreviousIDStatus.HasValue)
							{
								num = 0;
							}
							else
							{
								short? num2 = (short?)PreviousIDStatus;
								short num3 = (short)identificationStatus_0;
								if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2.GetValueOrDefault() == num3)) != true)
								{
									num2 = (short?)PreviousIDStatus;
									num3 = (short)MinimumClassificationLevel;
									bool? flag3 = ((!num2.HasValue) ? ((bool?)null) : new bool?(num2.GetValueOrDefault() == num3));
									if ((flag3 ?? true) && MinimumClassificationLevel == Contact_Base.IdentificationStatus.Unknown && flag3.HasValue)
									{
										flag = true;
									}
									else
									{
										num2 = (short?)PreviousIDStatus;
										num3 = (short)MinimumClassificationLevel;
										flag = ((!num2.HasValue) ? ((bool?)null) : new bool?(num2.GetValueOrDefault() >= num3)) != true;
									}
									goto IL_035d;
								}
								num = 0;
							}
							flag = (byte)num != 0;
						}
					}
					else
					{
						flag = false;
					}
				}
				else
				{
					flag = false;
				}
				goto IL_035d;
			}
			return false;
			IL_035d:
			if (!flag)
			{
				DetectedAsContact = null;
				DetectedUnit = null;
				DetectingUnit = null;
				SensorsThatMadeDetection = null;
			}
			else
			{
				DetectedUnit = theDetectedUnit;
				theDetectedUnit.ParentScen.Scenario_LuaSandbox.UnitX = theDetectedUnit;
				DetectingUnit = theDetectingUnit;
				theDetectedUnit.ParentScen.Scenario_LuaSandbox.UnitY = theDetectingUnit;
				SensorsThatMadeDetection = theSensorsThatMadeDetection;
				if (flag2.HasValue)
				{
					bool? flag3 = flag2;
					flag3 = flag3;
					if (flag3 == true)
					{
						DetectedInArea = true;
					}
				}
				DetectedAsContact = value;
				if (value != null)
				{
					theDetectedUnit.ParentScen.Scenario_LuaSandbox.UnitC = value;
				}
			}
			return flag;
		}
	}

	public bool IsFulfilled
	{
		get
		{
			DetectedAsContact = null;
			DetectedUnit = null;
			DetectingUnit = null;
			SensorsThatMadeDetection = null;
			DetectedInArea = null;
			if (identificationStatus_0 < MinimumClassificationLevel)
			{
				return false;
			}
			bool flag = false;
			bool? flag2 = null;
			if (Area.Count > 0)
			{
				if (!((Module_Unit.Unit)theDetectedUnit).get_IsInsideThisArea(Area, theDetectingUnit.ParentScen, UseCache: false))
				{
					flag2 = false;
					if (theDetectedUnit.ActiveEnterAreaTriggers.Count > 0)
					{
						theDetectedUnit.ActiveEnterAreaTriggers.Remove(ObjectID);
					}
				}
				else
				{
					flag2 = true;
				}
			}
			Side side = theDetectingUnit.get_UnitSide(SetSideOnly: false);
			if (Operators.CompareString(DetectorSideID, side.ObjectID, false) == 0)
			{
				if (TargetFilter.MatchesThisUnit(theDetectedUnit))
				{
					if (!Information.IsNothing((object)flag2) && !flag2 == true)
					{
						flag = false;
					}
					else if (Area.Count != 0)
					{
						if (!Information.IsNothing((object)theDetectedUnit) && theDetectedUnit.ActiveEnterAreaTriggers.FirstOrDefault([SpecialName] (string s) => Operators.CompareString(s, ObjectID, false) == 0) == null)
						{
							flag = true;
						}
					}
					else if (!ContactWasDetectedOnThisPulse)
					{
						if (!Information.IsNothing((object)PreviousIDStatus))
						{
							short? num = (short?)PreviousIDStatus;
							short num2 = (short)identificationStatus_0;
							if (((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() == num2)) != true)
							{
								num = (short?)PreviousIDStatus;
								num2 = (short)MinimumClassificationLevel;
								bool? flag3 = ((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() == num2));
								if ((flag3 ?? true) && MinimumClassificationLevel == Contact_Base.IdentificationStatus.Unknown && flag3.HasValue)
								{
									flag = true;
								}
								else
								{
									num = (short?)PreviousIDStatus;
									num2 = (short)MinimumClassificationLevel;
									flag = ((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() >= num2)) != true;
								}
								goto IL_02a9;
							}
						}
						flag = false;
					}
					else
					{
						flag = true;
					}
				}
				else
				{
					flag = false;
				}
			}
			else
			{
				flag = false;
			}
			goto IL_02a9;
			IL_02a9:
			if (flag)
			{
				theDetectingUnit.ParentScen.Scenario_LuaSandbox.UnitX = theDetectedUnit;
				DetectingUnit = theDetectingUnit;
				theDetectingUnit.ParentScen.Scenario_LuaSandbox.UnitY = theDetectingUnit;
				SensorsThatMadeDetection = theSensorsThatMadeDetection;
				if (!Information.IsNothing((object)flag2))
				{
					bool? flag3 = flag2;
					flag3 = flag3;
					if (flag3 == true)
					{
						DetectedInArea = true;
					}
				}
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
	}

	public EventTrigger_UnitDetected()
	{
		TargetFilter = new UnitFilterObject();
		MinimumClassificationLevel = Contact_Base.IdentificationStatus.Unknown;
		Area = new List<ReferencePoint>();
		DetectedInArea = null;
		Type = EventTriggerType.UnitDetected;
	}

	public override void ToXML(XmlWriter theWriter, HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("EventTrigger_UnitDetected");
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

	public static EventTrigger_UnitDetected FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		EventTrigger_UnitDetected result;
		try
		{
			EventTrigger_UnitDetected eventTrigger_UnitDetected = new EventTrigger_UnitDetected();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "Description":
					eventTrigger_UnitDetected.Description = val.InnerText;
					break;
				case "TargetFilter":
					eventTrigger_UnitDetected.TargetFilter = UnitFilterObject.FromXML(val, theDictionary, theScen);
					break;
				case "MCL":
					eventTrigger_UnitDetected.MinimumClassificationLevel = (Contact_Base.IdentificationStatus)Conversions.ToShort(val.InnerText);
					break;
				case "DetectorSideID":
					eventTrigger_UnitDetected.DetectorSideID = val.InnerText;
					break;
				case "Area":
					foreach (XmlNode childNode2 in val.ChildNodes)
					{
						XmlNode theNode2 = childNode2;
						eventTrigger_UnitDetected.Area.Add(ReferencePoint.FromXML(ref theNode2, ref theDictionary, theScen));
					}
					break;
				case "ID":
					eventTrigger_UnitDetected.ObjectID_Set(val.InnerText);
					break;
				}
			}
			result = eventTrigger_UnitDetected;
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
			result = new EventTrigger_UnitDetected();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override EventTrigger Clone()
	{
		EventTrigger_UnitDetected obj = (EventTrigger_UnitDetected)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[CLONE] " + Description;
		obj.Name = "[CLONE] " + Name;
		obj.TargetFilter = TargetFilter.Clone();
		obj.Area = Area.GetRange(0, Area.Count);
		return obj;
	}

	static EventTrigger_UnitDetected()
	{
		Class72.smethod_20();
	}
}
