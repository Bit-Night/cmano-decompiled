using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Posture : ScenarioObject
{
	public Misc.PostureStance PostureType;

	public Side PostureTarget;

	private string string_1;

	private string string_2;

	public void ToXML(ref XmlWriter theWriter)
	{
		try
		{
			theWriter.WriteStartElement("Posture");
			theWriter.WriteElementString("ID", ObjectID);
			XmlWriter obj = theWriter;
			int postureType = (int)PostureType;
			obj.WriteElementString("PostureType", postureType.ToString());
			theWriter.WriteElementString("PostureTarget", PostureTarget.ObjectID);
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101015", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private Posture()
	{
	}

	public static Posture FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		Posture result = default(Posture);
		try
		{
			Posture posture = new Posture();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "ID":
					if (!theDictionary.ContainsKey(val.InnerText))
					{
						posture.ObjectID_Set(val.InnerText);
						theDictionary.TryAdd(posture.ObjectID, posture);
						break;
					}
					result = (Posture)theDictionary[val.InnerText];
					return result;
				case "PostureTargetName":
					posture.string_2 = val.InnerText;
					break;
				case "PostureTarget":
					posture.string_1 = val.InnerText;
					break;
				case "PostureType":
					if (Versioned.IsNumeric((object)val.InnerText))
					{
						posture.PostureType = (Misc.PostureStance)Conversions.ToByte(val.InnerText);
					}
					else
					{
						posture.PostureType = (Misc.PostureStance)Enum.Parse(typeof(Misc.PostureStance), val.InnerText, ignoreCase: true);
					}
					break;
				}
			}
			result = posture;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101016", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public Posture(Side TargetSide, Misc.PostureStance thePosture)
	{
		PostureTarget = TargetSide;
		PostureType = thePosture;
	}

	public void PostDeserializationHousekeeping(ref Scenario theScen, ConcurrentDictionary<string, ScenarioObject> theDictionary)
	{
		if (Information.IsNothing((object)string_1))
		{
			return;
		}
		try
		{
			PostureTarget = (Side)theDictionary[string_1];
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101017", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	static Posture()
	{
		Class72.smethod_20();
	}
}
