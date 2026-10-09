using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EventAction_TeleportInArea : EventAction
{
	public HashSet<string> UnitIDs;

	public List<ReferencePoint> Area;

	public EventAction_TeleportInArea()
	{
		UnitIDs = new HashSet<string>();
		Area = new List<ReferencePoint>();
		Type = EventActionType.TeleportInArea;
	}

	public override void ToXML(XmlWriter theWriter, HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("EventAction_TeleportInArea");
			theWriter.WriteElementString("ID", ObjectID);
			theWriter.WriteElementString("Description", Description);
			theWriter.WriteStartElement("UnitIDs");
			foreach (string unitID in UnitIDs)
			{
				theWriter.WriteElementString("ID", unitID);
			}
			theWriter.WriteEndElement();
			theWriter.WriteStartElement("Area");
			foreach (ReferencePoint item in Area)
			{
				theWriter.WriteRaw(item.ToXML(ref ObjectsAlreadySerialized));
			}
			theWriter.WriteEndElement();
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100513", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static EventAction_TeleportInArea FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		EventAction_TeleportInArea result;
		try
		{
			EventAction_TeleportInArea eventAction_TeleportInArea = new EventAction_TeleportInArea();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "Area":
					foreach (XmlNode childNode2 in val.ChildNodes)
					{
						XmlNode theNode2 = childNode2;
						eventAction_TeleportInArea.Area.Add(ReferencePoint.FromXML(ref theNode2, ref theDictionary, theScen));
					}
					break;
				case "UnitIDs":
					foreach (XmlNode childNode3 in val.ChildNodes)
					{
						XmlNode val2 = childNode3;
						eventAction_TeleportInArea.UnitIDs.Add(val2.InnerText);
					}
					break;
				case "Description":
					eventAction_TeleportInArea.Description = val.InnerText;
					break;
				case "ID":
					eventAction_TeleportInArea.ObjectID_Set(val.InnerText);
					break;
				}
			}
			result = eventAction_TeleportInArea;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100514", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new EventAction_TeleportInArea();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override void Execute(Scenario thescen, SimEvent theEv)
	{
		Geopoint_Struct geopoint_Struct = default(Geopoint_Struct);
		try
		{
			List<ActiveUnit> ProvidedPiers = default(List<ActiveUnit>);
			foreach (string unitID in UnitIDs)
			{
				if (!thescen.ActiveUnits.TryGetValue(unitID, out var value) || value == null)
				{
					continue;
				}
				int num = 0;
				while (num < 1000)
				{
					geopoint_Struct = Math2.RandomPointWithinThisArea(Area);
					if (!geopoint_Struct.HasZeroCoords)
					{
						try
						{
							num++;
							ActiveUnit activeUnit = value;
							double latitude = geopoint_Struct.Latitude;
							double longitude = geopoint_Struct.Longitude;
							int MovementCost = 0;
							bool CheckNoNavZones = true;
							bool CheckForMines = true;
							string UserFeedback = "";
							bool AllowBounce = false;
							if (activeUnit.CanMoveToThisLocation(latitude, longitude, ref MovementCost, IsPathfindingQuery: true, UsePathfindingBufferDistance: true, IgnoreMinesBehindUs: false, ref CheckNoNavZones, CheckForIcepack: true, ref CheckForMines, null, null, ref ProvidedPiers, 0f, CheckIfTargetIsOutsideProsecutionArea: false, CheckDistanceToNoNavZones: false, ref UserFeedback, ref AllowBounce))
							{
								value.Teleport(ref thescen, geopoint_Struct.Longitude, geopoint_Struct.Latitude);
								break;
							}
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception ex2 = ex;
							ex2?.Data.Add("Error at 200460", ex2.Message);
							GameGeneral.WriteExceptionsToLog(ex2);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
						continue;
					}
					string text = "";
					if (value.IsAircraft && Operators.CompareString(value.Name, value.UnitClass, false) != 0)
					{
						text = " (" + value.UnitClass + ")";
					}
					value.AddMessage(value.Name + text + " is unable to pick a suitable point inside area defined by Ref. Points: " + string.Join(" - ", Area.Select([SpecialName] (ReferencePoint theP) => theP.Name)), value.Name + " cannot pick suitable point", LoggedMessage.MessageType.UnitAI, 1, new Geopoint_Struct(value.get_Longitude((GlobalVariables.BooleanObject)null), value.get_Latitude((GlobalVariables.BooleanObject)null)));
					return;
				}
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 100515", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override EventAction Clone()
	{
		EventAction_TeleportInArea obj = (EventAction_TeleportInArea)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[CLONE] " + Description;
		obj.Name = "[CLONE] " + Name;
		return obj;
	}

	static EventAction_TeleportInArea()
	{
		Class72.smethod_20();
	}
}
