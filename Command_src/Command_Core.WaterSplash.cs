using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class WaterSplash : Module_Unit.Unit
{
	public float MaxRadius;

	public float CurrentRadius;

	public WaterSplash(ref Scenario theScen, double theLongitude, double theLatitude, float theMaxRadius)
	{
		((Module_Unit.Unit)this).set_Longitude((GlobalVariables.BooleanObject)null, theLongitude);
		((Module_Unit.Unit)this).set_Latitude((GlobalVariables.BooleanObject)null, theLatitude);
		MaxRadius = theMaxRadius;
		if (!Information.IsNothing((object)theScen))
		{
			theScen.WaterSplashes.Add(this);
		}
	}

	public override void ToXML(ref XmlWriter Writer, ref HashSet<string> ObjectsAlreadySerialized)
	{
		try
		{
			Writer.WriteStartElement("WaterSplash");
			Writer.WriteElementString("ID", ObjectID);
			if (!ObjectsAlreadySerialized.Contains(ObjectID))
			{
				ObjectsAlreadySerialized.Add(ObjectID);
				Writer.WriteElementString("Lon", XmlConvert.ToString(((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null)));
				Writer.WriteElementString("Lat", XmlConvert.ToString(((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null)));
				Writer.WriteElementString("MR", XmlConvert.ToString(MaxRadius));
				Writer.WriteElementString("CR", XmlConvert.ToString(CurrentRadius));
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
			ex2?.Data.Add("Error at 100877", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private WaterSplash()
	{
	}

	public static WaterSplash FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		WaterSplash result;
		try
		{
			WaterSplash waterSplash = new WaterSplash();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "ID":
					if (!theDictionary.ContainsKey(val.InnerText))
					{
						waterSplash.ObjectID_Set(val.InnerText);
						theDictionary.TryAdd(waterSplash.ObjectID, waterSplash);
						break;
					}
					result = (WaterSplash)theDictionary[val.InnerText];
					goto end_IL_0001;
				case "Lon":
					((Module_Unit.Unit)waterSplash).set_Longitude((GlobalVariables.BooleanObject)null, XmlConvert.ToDouble(val.InnerText));
					break;
				case "CR":
					waterSplash.CurrentRadius = XmlConvert.ToSingle(val.InnerText);
					break;
				case "MR":
					waterSplash.MaxRadius = XmlConvert.ToSingle(val.InnerText);
					break;
				case "Lat":
					((Module_Unit.Unit)waterSplash).set_Latitude((GlobalVariables.BooleanObject)null, XmlConvert.ToDouble(val.InnerText));
					break;
				}
			}
			result = waterSplash;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100878", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new WaterSplash();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void Spread(Scenario theScen, float elapsedTime)
	{
		CurrentRadius += elapsedTime * Math.Max(MaxRadius / 50f, (MaxRadius - CurrentRadius) / 5f);
		if (CurrentRadius > MaxRadius)
		{
			theScen.WaterSplashes.Remove(this);
		}
	}

	private static void smethod_1(object object_0, object object_1)
	{
	}

	static WaterSplash()
	{
		Class72.smethod_20();
	}
}
