using System.Collections.Generic;
using Command_Core;

namespace CommandNetcode.RT;

public static class Helper
{
	public static GeoPoint ToGeoPoint(ContactStatusMessage.UncertaintyElement ue)
	{
		return new GeoPoint(ue.Lon, ue.Lat);
	}

	public static ContactStatusMessage.UncertaintyElement ToUncertaintyElement(GeoPoint geopoint)
	{
		return new ContactStatusMessage.UncertaintyElement
		{
			Lat = geopoint.Latitude,
			Lon = geopoint.Longitude
		};
	}

	public static Geopoint_Struct ToGeoPointStruct(ContactStatusMessage.UncertaintyElement ue)
	{
		return new Geopoint_Struct(ue.Lon, ue.Lat);
	}

	public static ContactStatusMessage.UncertaintyElement ToUncertaintyElement(Geopoint_Struct geopointStruct)
	{
		return new ContactStatusMessage.UncertaintyElement
		{
			Lat = geopointStruct.Latitude,
			Lon = geopointStruct.Longitude
		};
	}

	public static List<Contact> GetSideContactsByID(Side side, List<string> list_0)
	{
		List<Contact> list = new List<Contact>();
		if (side != null && list_0 != null)
		{
			foreach (string item in list_0)
			{
				Contact contact = side.Contacts[item];
				if (contact == null)
				{
					contact = side.BaseContacts[item];
				}
				if (contact != null)
				{
					list.Add(contact);
				}
			}
		}
		return list;
	}

	public static Waypoint ToWaypoint(CourseUpdateMessage.CourseElement ce)
	{
		Waypoint waypoint = new Waypoint(ce.Lon, ce.Lat, ce.Alt, (Waypoint.WaypointType)ce.Type, (Waypoint.WaypointCreator)ce.Creator, (Waypoint.WaypointCategory)ce.Categroy);
		waypoint?.ObjectID_Set(ce.ObjectID);
		return waypoint;
	}

	public static CourseUpdateMessage.CourseElement ToCourseElement(Waypoint waypoint)
	{
		return new CourseUpdateMessage.CourseElement
		{
			ObjectID = waypoint.ObjectID,
			Alt = waypoint.Altitude,
			Lat = waypoint.Latitude,
			Lon = waypoint.Longitude,
			Type = (short)waypoint.Type,
			Creator = (short)waypoint.Creator,
			Categroy = (short)waypoint.Category
		};
	}

	static Helper()
	{
		Class72.smethod_20();
	}
}
