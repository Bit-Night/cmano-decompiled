using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class ChaffCorridorCloud : Module_Unit.Unit
{
	private double double_0;

	public const int MaxLength = 6000;

	public int CoverageLength => Math.Min(100 + (int)Math.Round(double_0 * 100.0), 6000);

	public int CoverageWidth => Math.Min(40 + (int)Math.Round(double_0 * 50.0), 1500);

	public int CurtainCeiling
	{
		get
		{
			float num = (float)(double_0 * 0.6);
			return Math.Max(0, (int)Math.Round((double)((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + (double)num * 0.5));
		}
	}

	public int CurtainFloor
	{
		get
		{
			float num = (float)(double_0 * 0.6);
			return Math.Max(0, (int)Math.Round((double)((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - (double)num * 1.5));
		}
	}

	public ChaffCorridorCloud(double theLat, double theLon, float theAlt, float theHeading)
	{
		((Module_Unit.Unit)this).set_Latitude((GlobalVariables.BooleanObject)null, theLat);
		((Module_Unit.Unit)this).set_Longitude((GlobalVariables.BooleanObject)null, theLon);
		((Module_Unit.Unit)this).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, theAlt);
		CurrentHeading = theHeading;
	}

	public void Progress(float elapsedTime)
	{
		double_0 += elapsedTime;
		((Module_Unit.Unit)this).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)((double)((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - 0.6 * (double)elapsedTime));
	}

	public override void ToXML(ref XmlWriter Writer, ref HashSet<string> ObjectsAlreadySerialized)
	{
		try
		{
			Writer.WriteStartElement("ChaffCloud");
			Writer.WriteElementString("ID", ObjectID);
			if (!ObjectsAlreadySerialized.Contains(ObjectID))
			{
				ObjectsAlreadySerialized.Add(ObjectID);
				Writer.WriteElementString("CH", XmlConvert.ToString(CurrentHeading));
				Writer.WriteElementString("Age", XmlConvert.ToString(double_0));
				Writer.WriteElementString("Lon", XmlConvert.ToString(((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null)));
				Writer.WriteElementString("Lat", XmlConvert.ToString(((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null)));
				Writer.WriteElementString("Alt", XmlConvert.ToString(((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)));
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
			ex2?.Data.Add("Error at 112340-231495090911", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private ChaffCorridorCloud()
	{
	}

	public static ChaffCorridorCloud FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		ChaffCorridorCloud result;
		try
		{
			ChaffCorridorCloud chaffCorridorCloud = new ChaffCorridorCloud();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "ID":
					if (!theDictionary.ContainsKey(val.InnerText))
					{
						chaffCorridorCloud.ObjectID_Set(val.InnerText);
						theDictionary.TryAdd(chaffCorridorCloud.ObjectID, chaffCorridorCloud);
						break;
					}
					result = (ChaffCorridorCloud)theDictionary[val.InnerText];
					goto end_IL_0001;
				case "Lon":
					((Module_Unit.Unit)chaffCorridorCloud).set_Longitude((GlobalVariables.BooleanObject)null, XmlConvert.ToDouble(val.InnerText));
					break;
				case "Alt":
					((Module_Unit.Unit)chaffCorridorCloud).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, XmlConvert.ToSingle(val.InnerText));
					break;
				case "Lat":
					((Module_Unit.Unit)chaffCorridorCloud).set_Latitude((GlobalVariables.BooleanObject)null, XmlConvert.ToDouble(val.InnerText));
					break;
				case "Age":
					chaffCorridorCloud.double_0 = XmlConvert.ToSingle(val.InnerText);
					break;
				case "CH":
					chaffCorridorCloud.CurrentHeading = XmlConvert.ToSingle(val.InnerText);
					break;
				}
			}
			result = chaffCorridorCloud;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 10213412354093409922", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new ChaffCorridorCloud();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	static ChaffCorridorCloud()
	{
		Class72.smethod_20();
	}
}
