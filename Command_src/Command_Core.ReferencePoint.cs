using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security;
using System.Xml;
using Cysharp.Text;
using DarkUI.Collections;
using Easy.Common;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class ReferencePoint : GeoPoint
{
	public enum OrientationType : byte
	{
		Fixed,
		Rotating
	}

	private bool bool_0;

	private bool bool_1;

	private ScenarioObject scenarioObject_0;

	internal string _IsRelativeTo_String;

	public float RelativeBearing;

	private float float_1;

	public OrientationType BearingType;

	public bool IsLocked;

	public Dictionary<ReferencePointFlag, ReferencePointFlag> Tags;

	public HashSet<string> TagsByGuid_Raw;

	public Color color;

	public ReferencePoint_Group RenderGroup;

	public DateTime? CreationDate;

	public DateTime? Expiration;

	public bool Fades;

	public bool ForceMinimize;

	public bool IsVisible
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
			if (!bool_0)
			{
				bool_1 = false;
			}
		}
	}

	public ScenarioObject IsRelativeTo
	{
		get
		{
			return scenarioObject_0;
		}
		set
		{
			scenarioObject_0 = value;
		}
	}

	public float RelativeDistance
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	public bool IsHighlighted
	{
		get
		{
			return bool_1;
		}
		set
		{
			if (IsVisible)
			{
				bool_1 = value;
			}
			else
			{
				bool_1 = false;
			}
		}
	}

	public string ToXML([Optional][DefaultParameterValue(null)] ref HashSet<string> ObjectsAlreadySerialized)
	{
		Utf16ValueStringBuilder utf16ValueStringBuilder = ZString.CreateStringBuilder();
		string result = default(string);
		try
		{
			utf16ValueStringBuilder.Clear();
			utf16ValueStringBuilder.Append("<RPoint>");
			if (string.IsNullOrEmpty(ObjectID))
			{
				ObjectID = IDGenerator.Instance.Next;
			}
			utf16ValueStringBuilder.Append("<ID>");
			utf16ValueStringBuilder.Append(ObjectID);
			utf16ValueStringBuilder.Append("</ID>");
			utf16ValueStringBuilder.Append("<Vis>");
			utf16ValueStringBuilder.Append(XmlConvert.ToString(IsVisible));
			utf16ValueStringBuilder.Append("</Vis>");
			if (ObjectsAlreadySerialized != null)
			{
				if (ObjectsAlreadySerialized.Contains(ObjectID))
				{
					utf16ValueStringBuilder.Append("</RPoint>");
					result = utf16ValueStringBuilder.ToString();
					return result;
				}
				ObjectsAlreadySerialized.Add(ObjectID);
			}
			utf16ValueStringBuilder.Append("<Lon>");
			utf16ValueStringBuilder.Append(XmlConvert.ToString(base.Longitude));
			utf16ValueStringBuilder.Append("</Lon>");
			utf16ValueStringBuilder.Append("<Lat>");
			utf16ValueStringBuilder.Append(XmlConvert.ToString(base.Latitude));
			utf16ValueStringBuilder.Append("</Lat>");
			if (base.Altitude != 0f)
			{
				utf16ValueStringBuilder.Append("<Alt>");
				utf16ValueStringBuilder.Append(XmlConvert.ToString(base.Altitude));
				utf16ValueStringBuilder.Append("</Alt>");
			}
			utf16ValueStringBuilder.Append("<Name>");
			utf16ValueStringBuilder.Append(SecurityElement.Escape(Name));
			utf16ValueStringBuilder.Append("</Name>");
			if (bool_1)
			{
				utf16ValueStringBuilder.Append("<IH>True</IH>");
			}
			if (IsRelativeTo != null)
			{
				utf16ValueStringBuilder.Append("<IRT>");
				utf16ValueStringBuilder.Append(IsRelativeTo.ObjectID);
				utf16ValueStringBuilder.Append("</IRT>");
				utf16ValueStringBuilder.Append("<RB>");
				utf16ValueStringBuilder.Append(XmlConvert.ToString(RelativeBearing));
				utf16ValueStringBuilder.Append("</RB>");
				utf16ValueStringBuilder.Append("<RD>");
				utf16ValueStringBuilder.Append(XmlConvert.ToString(RelativeDistance));
				utf16ValueStringBuilder.Append("</RD>");
			}
			if (BearingType != OrientationType.Fixed)
			{
				utf16ValueStringBuilder.Append("<BT>");
				byte bearingType = (byte)BearingType;
				utf16ValueStringBuilder.Append(bearingType.ToString());
				utf16ValueStringBuilder.Append("</BT>");
			}
			utf16ValueStringBuilder.Append("<ColorR>");
			utf16ValueStringBuilder.Append(XmlConvert.ToString(color.R));
			utf16ValueStringBuilder.Append("</ColorR>");
			utf16ValueStringBuilder.Append("<ColorG>");
			utf16ValueStringBuilder.Append(XmlConvert.ToString(color.G));
			utf16ValueStringBuilder.Append("</ColorG>");
			utf16ValueStringBuilder.Append("<ColorB>");
			utf16ValueStringBuilder.Append(XmlConvert.ToString(color.B));
			utf16ValueStringBuilder.Append("</ColorB>");
			if (Tags.Count > 0)
			{
				foreach (ReferencePointFlag key in Tags.Keys)
				{
					utf16ValueStringBuilder.Append("<Tag>");
					utf16ValueStringBuilder.Append(key.ObjectID);
					utf16ValueStringBuilder.Append("</Tag>");
				}
			}
			if (IsLocked)
			{
				utf16ValueStringBuilder.Append("<IsLocked>True</IsLocked>");
			}
			if (CreationDate.HasValue)
			{
				utf16ValueStringBuilder.Append("<CreationDate>" + CreationDate.Value.ToBinary() + "</CreationDate>");
			}
			if (Expiration.HasValue)
			{
				utf16ValueStringBuilder.Append("<Expiration>" + Expiration.Value.ToBinary() + "</Expiration>");
			}
			if (Fades)
			{
				utf16ValueStringBuilder.Append("<Fades>True</Fades>");
			}
			if (ForceMinimize)
			{
				utf16ValueStringBuilder.Append("<ForceMinimize>True</ForceMinimize>");
			}
			utf16ValueStringBuilder.Append("<RGroup>");
			utf16ValueStringBuilder.Append(((byte)RenderGroup).ToString());
			utf16ValueStringBuilder.Append("</RGroup>");
			utf16ValueStringBuilder.Append("</RPoint>");
			string text = utf16ValueStringBuilder.ToString();
			utf16ValueStringBuilder.Dispose();
			result = text;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100584", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static ReferencePoint FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario ParentScen)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		ReferencePoint result2;
		try
		{
			ReferencePoint referencePoint = new ReferencePoint();
			byte red = byte.MaxValue;
			byte green = byte.MaxValue;
			byte blue = byte.MaxValue;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "Expiration":
					referencePoint.Expiration = DateTime.FromBinary(Conversions.ToLong(val.InnerText));
					break;
				case "BT":
					referencePoint.BearingType = (OrientationType)Conversions.ToByte(val.InnerText);
					break;
				case "Name":
					referencePoint.Name = val.InnerText;
					break;
				case "ColorR":
					red = XmlConvert.ToByte(val.InnerText);
					break;
				case "ColorB":
					blue = XmlConvert.ToByte(val.InnerText);
					break;
				case "IsLocked":
					referencePoint.IsLocked = true;
					break;
				case "ColorG":
					green = XmlConvert.ToByte(val.InnerText);
					break;
				case "ID":
					if (Information.IsNothing((object)theDictionary) || !theDictionary.ContainsKey(val.InnerText))
					{
						referencePoint.ObjectID_Set(val.InnerText);
						if (!Information.IsNothing((object)theDictionary))
						{
							theDictionary.TryAdd(referencePoint.ObjectID, referencePoint);
						}
						break;
					}
					result2 = (ReferencePoint)theDictionary[val.InnerText];
					goto end_IL_0001;
				case "RelativeDistance":
				case "RD":
					referencePoint.RelativeDistance = XmlConvert.ToSingle(val.InnerText.Replace(",", "."));
					break;
				case "Alt":
				case "Altitude":
					referencePoint.Altitude = XmlConvert.ToSingle(val.InnerText);
					break;
				case "RelativeBearing":
				case "RB":
					referencePoint.RelativeBearing = XmlConvert.ToSingle(val.InnerText.Replace(",", "."));
					break;
				case "CreationDate":
					referencePoint.CreationDate = DateTime.FromBinary(Conversions.ToLong(val.InnerText));
					break;
				case "Longitude":
				case "Lon":
					referencePoint.Longitude = XmlConvert.ToDouble(val.InnerText);
					break;
				case "IsRelativeTo":
				case "IRT":
					referencePoint._IsRelativeTo_String = val.InnerText;
					break;
				case "Latitude":
				case "Lat":
					referencePoint.Latitude = XmlConvert.ToDouble(val.InnerText);
					break;
				case "Visible":
				case "Vis":
				{
					string innerText = val.InnerText;
					ReferencePoint referencePoint2;
					bool result = (referencePoint2 = referencePoint).IsVisible;
					bool.TryParse(innerText, out result);
					referencePoint2.IsVisible = result;
					break;
				}
				case "IH":
				case "IsSelected":
					referencePoint.bool_1 = Misc.ParseBool(val.InnerText);
					break;
				case "Tag":
					if (!referencePoint.TagsByGuid_Raw.Contains(val.InnerText))
					{
						referencePoint.TagsByGuid_Raw.Add(val.InnerText);
					}
					break;
				case "ForceMinimize":
					referencePoint.ForceMinimize = true;
					break;
				case "Fades":
					referencePoint.Fades = true;
					break;
				case "RGroup":
					referencePoint.RenderGroup = (ReferencePoint_Group)Conversions.ToInteger(val.InnerText);
					break;
				}
			}
			referencePoint.color = Color.FromArgb(red, green, blue);
			result2 = referencePoint;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100585", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int assignObjectID;
			if (!Debugger.IsAttached)
			{
				assignObjectID = 1;
			}
			else
			{
				Debugger.Break();
				assignObjectID = 1;
			}
			result2 = new ReferencePoint((byte)assignObjectID != 0);
			ProjectData.ClearProjectError();
		}
		return result2;
	}

	public void PostDeserializationHousekeeping(ConcurrentDictionary<string, ScenarioObject> theDictionary)
	{
		if (Operators.CompareString(_IsRelativeTo_String, "", false) == 0 || !theDictionary.ContainsKey(_IsRelativeTo_String))
		{
			return;
		}
		if (!theDictionary[_IsRelativeTo_String].IsActiveUnit)
		{
			if (theDictionary[_IsRelativeTo_String].IsContact())
			{
				IsRelativeTo = (Contact)theDictionary[_IsRelativeTo_String];
			}
			else if (theDictionary[_IsRelativeTo_String].IsReferencePoint())
			{
				IsRelativeTo = (ReferencePoint)theDictionary[_IsRelativeTo_String];
			}
		}
		else
		{
			IsRelativeTo = (Module_Unit.Unit)theDictionary[_IsRelativeTo_String];
		}
	}

	public void Cycle_1sec_RemoveIfNecessary(Scenario Scen, List<ReferencePoint> ParentList)
	{
		Cycle_1sec(Scen);
		if (ShouldbeRemoved(Scen))
		{
			ParentList.Remove(this);
		}
	}

	public bool ShouldbeRemoved(Scenario Scen)
	{
		if (!Expiration.HasValue)
		{
			return false;
		}
		return DateTime.Compare(Scen.Time, Expiration.GetValueOrDefault()) > 0;
	}

	public void Cycle_1sec(Scenario Scen)
	{
		if (Expiration.HasValue && Fades)
		{
			TimeSpan? timeSpan = Expiration - CreationDate;
			DateTime time = Scen.Time;
			DateTime? creationDate = CreationDate;
			double num = (time - creationDate).Value.TotalSeconds / timeSpan.Value.TotalSeconds;
			double num2 = 255.0 * (1.0 - num);
			if (Math.Min(num2, 0.0) == num2)
			{
				num2 = 0.0;
			}
			if (Math.Max(num2, 255.0) == num2)
			{
				num2 = 255.0;
			}
			color = Color.FromArgb((int)Math.Round(num2), color.R, color.G, color.B);
		}
	}

	public static ObservableList<ReferencePoint> FetchReferencePointsFromID(Side side, List<string> RPIDS)
	{
		ObservableList<ReferencePoint> observableList = new ObservableList<ReferencePoint>();
		Dictionary<string, ReferencePoint> dictionary = new Dictionary<string, ReferencePoint>();
		foreach (ReferencePoint refPoint in side.RefPoints)
		{
			dictionary.Add(refPoint.ObjectID, refPoint);
		}
		if (dictionary.Count > 0)
		{
			foreach (string RPID in RPIDS)
			{
				if (dictionary.ContainsKey(RPID))
				{
					observableList.Add(dictionary[RPID]);
				}
			}
		}
		return observableList;
	}

	public static List<string> FetchIDFromReferencePoints(Side side, List<ReferencePoint> RPIDS)
	{
		List<string> list = new List<string>();
		Dictionary<string, ReferencePoint> dictionary = new Dictionary<string, ReferencePoint>();
		foreach (ReferencePoint refPoint in side.RefPoints)
		{
			dictionary.Add(refPoint.ObjectID, refPoint);
		}
		if (dictionary.Count > 0)
		{
			foreach (ReferencePoint RPID in RPIDS)
			{
				if (dictionary.ContainsKey(RPID.ObjectID))
				{
					list.Add(RPID.ObjectID);
				}
			}
		}
		return list;
	}

	public static List<string> FetchIDFromReferencePoints(Side side, ObservableList<ReferencePoint> RPIDS)
	{
		List<string> list = new List<string>();
		Dictionary<string, ReferencePoint> dictionary = new Dictionary<string, ReferencePoint>();
		foreach (ReferencePoint refPoint in side.RefPoints)
		{
			dictionary.Add(refPoint.ObjectID, refPoint);
		}
		if (dictionary.Count > 0)
		{
			foreach (ReferencePoint RPID in RPIDS)
			{
				if (dictionary.ContainsKey(RPID.ObjectID))
				{
					list.Add(RPID.ObjectID);
				}
			}
		}
		return list;
	}

	public static List<string> FetchIDFromReferencePoints(List<ReferencePoint> RPIDS)
	{
		List<string> list = new List<string>();
		if (RPIDS.Count > 0)
		{
			foreach (ReferencePoint RPID in RPIDS)
			{
				list.Add(RPID.ObjectID);
			}
		}
		return list;
	}

	public static ReferencePoint CreateNew(Scenario Scen, string Name, double theLon, double theLat, Side _Side, DateTime? _ExpirationDate, Color _Color, bool _Fades = false, bool _ForceShrink = false)
	{
		ReferencePoint referencePoint = new ReferencePoint(Name, theLon, theLat);
		referencePoint.Expiration = _ExpirationDate;
		referencePoint.color = _Color;
		referencePoint.Fades = _Fades;
		referencePoint.ForceMinimize = _ForceShrink;
		referencePoint.CreationDate = Scen.Time;
		referencePoint.RenderGroup = ReferencePoint_Group.Generic;
		_Side.RefPoints.Add(referencePoint);
		return referencePoint;
	}

	public static void CreateNewSlugTrailPoint(Scenario Scen, string AssociatedUnitID, double theLon, double theLat, float theAlt, Side _Side, DateTime? _ExpirationDate, Color _Color, bool _Fades = false, bool _ForceShrink = false)
	{
		ReferencePoint referencePoint = new ReferencePoint("", theLon, theLat, theAlt);
		referencePoint.Expiration = _ExpirationDate;
		referencePoint.color = _Color;
		referencePoint.Fades = _Fades;
		referencePoint.ForceMinimize = _ForceShrink;
		referencePoint.CreationDate = Scen.Time;
		referencePoint.RenderGroup = ReferencePoint_Group.Slugtrail;
		if (!_Side.PerUnitSlugtrail.ContainsKey(AssociatedUnitID))
		{
			_Side.PerUnitSlugtrail.Add(AssociatedUnitID, new Side.SlugTrail());
		}
		_Side.PerUnitSlugtrail[AssociatedUnitID].refPoints.Enqueue(referencePoint);
	}

	public void AdjustForRelativeHooking()
	{
		if (Information.IsNothing((object)IsRelativeTo))
		{
			return;
		}
		if (IsRelativeTo.IsUnit() | IsRelativeTo.IsActiveUnit)
		{
			try
			{
				Module_Unit.Unit unit = (Module_Unit.Unit)IsRelativeTo;
				switch (BearingType)
				{
				case OrientationType.Rotating:
					RelativeBearing = MathFunctions.AngularDifference(unit.CurrentHeading, Math2.CalcAzimuth(unit.get_Latitude((GlobalVariables.BooleanObject)null), unit.get_Longitude((GlobalVariables.BooleanObject)null), base.Latitude, base.Longitude));
					break;
				case OrientationType.Fixed:
					RelativeBearing = Math2.CalcAzimuth(unit.get_Latitude((GlobalVariables.BooleanObject)null), unit.get_Longitude((GlobalVariables.BooleanObject)null), base.Latitude, base.Longitude);
					break;
				}
				RelativeDistance = Math2.CalcDist(unit.get_Latitude((GlobalVariables.BooleanObject)null), unit.get_Longitude((GlobalVariables.BooleanObject)null), base.Latitude, base.Longitude);
				return;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100586", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return;
			}
		}
		if (IsRelativeTo.IsContact())
		{
			try
			{
				Contact contact = (Contact)IsRelativeTo;
				switch (BearingType)
				{
				case OrientationType.Fixed:
					RelativeBearing = Math2.CalcAzimuth(((Module_Unit.Unit)contact).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact).get_Longitude((GlobalVariables.BooleanObject)null), base.Latitude, base.Longitude);
					break;
				case OrientationType.Rotating:
					RelativeBearing = MathFunctions.AngularDifference(contact.CurrentHeading, Math2.CalcAzimuth(((Module_Unit.Unit)contact).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact).get_Longitude((GlobalVariables.BooleanObject)null), base.Latitude, base.Longitude));
					break;
				}
				RelativeDistance = Math2.CalcDist(((Module_Unit.Unit)contact).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact).get_Longitude((GlobalVariables.BooleanObject)null), base.Latitude, base.Longitude);
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at 100586", "");
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		if (!IsRelativeTo.IsReferencePoint())
		{
			return;
		}
		try
		{
			GeoPoint geoPoint = (GeoPoint)IsRelativeTo;
			switch (BearingType)
			{
			case OrientationType.Fixed:
				RelativeBearing = Math2.CalcAzimuth(geoPoint.Latitude, geoPoint.Longitude, base.Latitude, base.Longitude);
				break;
			case OrientationType.Rotating:
				BearingType = OrientationType.Fixed;
				RelativeBearing = Math2.CalcAzimuth(geoPoint.Latitude, geoPoint.Longitude, base.Latitude, base.Longitude);
				break;
			}
			RelativeDistance = Math2.CalcDist(geoPoint.Latitude, geoPoint.Longitude, base.Latitude, base.Longitude);
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			ex6?.Data.Add("Error at 100586", "");
			GameGeneral.WriteExceptionsToLog(ex6);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public ReferencePoint(double theLon, double theLat, bool AssignObjectID = true)
		: base(AssignObjectID)
	{
		bool_0 = true;
		Tags = new Dictionary<ReferencePointFlag, ReferencePointFlag>();
		TagsByGuid_Raw = new HashSet<string>();
		color = default(Color);
		color = Color.White;
		base.Longitude = theLon;
		base.Latitude = theLat;
	}

	public ReferencePoint(string Name, double theLon, double theLat, bool AssignObjectID = true)
		: base(AssignObjectID)
	{
		bool_0 = true;
		Tags = new Dictionary<ReferencePointFlag, ReferencePointFlag>();
		TagsByGuid_Raw = new HashSet<string>();
		color = default(Color);
		color = Color.White;
		base.Longitude = theLon;
		base.Latitude = theLat;
		this.Name = Name;
	}

	public ReferencePoint(string Name, double theLon, double theLat, float theAlt, bool AssignObjectID = true)
		: base(AssignObjectID)
	{
		bool_0 = true;
		Tags = new Dictionary<ReferencePointFlag, ReferencePointFlag>();
		TagsByGuid_Raw = new HashSet<string>();
		color = default(Color);
		color = Color.White;
		base.Longitude = theLon;
		base.Latitude = theLat;
		base.Altitude = theAlt;
		this.Name = Name;
	}

	public ReferencePoint(bool AssignObjectID = true)
		: base(AssignObjectID)
	{
		bool_0 = true;
		Tags = new Dictionary<ReferencePointFlag, ReferencePointFlag>();
		TagsByGuid_Raw = new HashSet<string>();
		color = default(Color);
		color = Color.White;
	}

	public static ReferencePoint CopyRefPoint(ref ReferencePoint theOriginalRefPoint, Side Side = null)
	{
		ReferencePoint referencePoint = new ReferencePoint(AssignObjectID: false);
		referencePoint.Name = theOriginalRefPoint.Name;
		referencePoint.ObjectID = theOriginalRefPoint.ObjectID;
		referencePoint.Latitude = theOriginalRefPoint.Latitude;
		referencePoint.Longitude = theOriginalRefPoint.Longitude;
		referencePoint.Altitude = theOriginalRefPoint.Altitude;
		referencePoint.bool_1 = theOriginalRefPoint.bool_1;
		referencePoint._IsRelativeTo_String = theOriginalRefPoint._IsRelativeTo_String;
		referencePoint.RelativeBearing = theOriginalRefPoint.RelativeBearing;
		referencePoint.RelativeDistance = theOriginalRefPoint.RelativeDistance;
		referencePoint.BearingType = theOriginalRefPoint.BearingType;
		referencePoint.IsLocked = theOriginalRefPoint.IsLocked;
		referencePoint.RenderGroup = theOriginalRefPoint.RenderGroup;
		referencePoint.color = theOriginalRefPoint.color;
		referencePoint.Tags = theOriginalRefPoint.Tags;
		referencePoint.TagsByGuid_Raw = theOriginalRefPoint.TagsByGuid_Raw;
		Side?.RefPoints.Add(referencePoint);
		return referencePoint;
	}

	internal List<ReferencePoint> CopyRefArea(ref List<ReferencePoint> theOriginalRefArea, bool DeepCopy = false)
	{
		try
		{
			List<ReferencePoint> list = new List<ReferencePoint>();
			if (theOriginalRefArea.Count > 0)
			{
				foreach (ReferencePoint item in theOriginalRefArea)
				{
					ReferencePoint theOriginalRefPoint = item;
					if (!DeepCopy)
					{
						list.Add(theOriginalRefPoint);
					}
					else
					{
						list.Add(CopyRefPoint(ref theOriginalRefPoint));
					}
				}
			}
			return list;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public ReferencePoint(string theName, string theObjectID, double theLatitude, double theLongitude, float theAltitude, bool theIsHighlighted, string theIsRelativeTo_String, float theRelativeBearing, float theRelativeDistance, OrientationType theBearingType, bool theIsLocked)
	{
		bool_0 = true;
		Tags = new Dictionary<ReferencePointFlag, ReferencePointFlag>();
		TagsByGuid_Raw = new HashSet<string>();
		color = default(Color);
		Name = theName;
		ObjectID_Set(theObjectID);
		base.Latitude = theLatitude;
		base.Longitude = theLongitude;
		base.Altitude = theAltitude;
		bool_1 = theIsHighlighted;
		_IsRelativeTo_String = theIsRelativeTo_String;
		RelativeBearing = theRelativeBearing;
		RelativeDistance = theRelativeDistance;
		BearingType = theBearingType;
		IsLocked = theIsLocked;
	}

	internal static bool SameArea(List<ReferencePoint> Area1, List<ReferencePoint> Area2)
	{
		foreach (ReferencePoint item in Area1)
		{
			if (!Area2.Contains(item))
			{
				return false;
			}
		}
		return true;
	}

	static ReferencePoint()
	{
		Class72.smethod_20();
	}
}
