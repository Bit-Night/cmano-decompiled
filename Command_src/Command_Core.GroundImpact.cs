using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class GroundImpact : Module_Unit.Unit
{
	public float MaxRadius;

	public float CurrentRadius;

	public float SpreadSpeed;

	public bool IsIncendiary;

	public GroundImpact(ref Scenario theScen, double theLongitude, double theLatitude, float theMaxRadius, bool theIsIncendiary, float _SpreadSpeed = 1f)
	{
		SpreadSpeed = 1f;
		((Module_Unit.Unit)this).set_Longitude((GlobalVariables.BooleanObject)null, theLongitude);
		((Module_Unit.Unit)this).set_Latitude((GlobalVariables.BooleanObject)null, theLatitude);
		MaxRadius = theMaxRadius;
		IsIncendiary = theIsIncendiary;
		SpreadSpeed = _SpreadSpeed;
		theScen.GroundImpacts.Add(this);
	}

	public GroundImpact(ref Scenario theScen, Geopoint_Struct position, float theMaxRadius, bool theIsIncendiary, float _SpreadSpeed = 1f)
		: this(ref theScen, position.Longitude, position.Latitude, theMaxRadius, theIsIncendiary, _SpreadSpeed)
	{
	}

	public override void ToXML(ref XmlWriter Writer, ref HashSet<string> ObjectsAlreadySerialized)
	{
		try
		{
			Writer.WriteStartElement("GroundImpact");
			Writer.WriteElementString("ID", ObjectID);
			if (!ObjectsAlreadySerialized.Contains(ObjectID))
			{
				ObjectsAlreadySerialized.Add(ObjectID);
				Writer.WriteElementString("Lon", XmlConvert.ToString(((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null)));
				Writer.WriteElementString("Lat", XmlConvert.ToString(((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null)));
				Writer.WriteElementString("MR", MaxRadius.ToString());
				Writer.WriteElementString("CR", CurrentRadius.ToString());
				Writer.WriteElementString("SP", SpreadSpeed.ToString());
				Writer.WriteEndElement();
			}
			else
			{
				Writer.WriteEndElement();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101337", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private GroundImpact()
	{
		SpreadSpeed = 1f;
	}

	public static GroundImpact FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		GroundImpact result;
		try
		{
			GroundImpact groundImpact = new GroundImpact();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "ID":
					if (!theDictionary.ContainsKey(val.InnerText))
					{
						groundImpact.ObjectID_Set(val.InnerText);
						theDictionary.TryAdd(groundImpact.ObjectID, groundImpact);
						break;
					}
					result = (GroundImpact)theDictionary[val.InnerText];
					goto end_IL_0001;
				case "Lat":
					((Module_Unit.Unit)groundImpact).set_Latitude((GlobalVariables.BooleanObject)null, XmlConvert.ToDouble(val.InnerText));
					break;
				case "SP":
					groundImpact.SpreadSpeed = XmlConvert.ToSingle(val.InnerText);
					break;
				case "CR":
					groundImpact.CurrentRadius = XmlConvert.ToSingle(val.InnerText);
					break;
				case "MR":
					groundImpact.MaxRadius = XmlConvert.ToSingle(val.InnerText);
					break;
				case "Lon":
					((Module_Unit.Unit)groundImpact).set_Longitude((GlobalVariables.BooleanObject)null, XmlConvert.ToDouble(val.InnerText));
					break;
				}
			}
			result = groundImpact;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101336", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new GroundImpact();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void Spread(Scenario theScen, float elapsedTime)
	{
		CurrentRadius += elapsedTime * SpreadSpeed * Math.Max(MaxRadius / 50f, (MaxRadius - CurrentRadius) / 5f);
		if (CurrentRadius > MaxRadius)
		{
			theScen.GroundImpacts.Remove(this);
		}
	}

	static GroundImpact()
	{
		Class72.smethod_20();
	}
}
