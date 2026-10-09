using System;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class QuickJumpSlot
{
	public int Index;

	public string LocationString;

	public int CameraAlt;

	public bool Tracking;

	public void ToXML(ref XmlWriter theWriter)
	{
		try
		{
			theWriter.WriteStartElement("QJS");
			theWriter.WriteElementString("I", Index.ToString());
			theWriter.WriteElementString("LS", LocationString);
			theWriter.WriteElementString("CA", CameraAlt.ToString());
			if (Tracking)
			{
				theWriter.WriteElementString("TR", "True");
			}
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101018", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static QuickJumpSlot FromXML(XmlNode theNode)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		QuickJumpSlot result = default(QuickJumpSlot);
		try
		{
			QuickJumpSlot quickJumpSlot = new QuickJumpSlot();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "I":
					quickJumpSlot.Index = Conversions.ToInteger(val.InnerText);
					break;
				case "CA":
					quickJumpSlot.CameraAlt = Conversions.ToInteger(val.InnerText);
					break;
				case "TR":
					quickJumpSlot.Tracking = true;
					break;
				case "LS":
					quickJumpSlot.LocationString = val.InnerText;
					break;
				}
			}
			result = quickJumpSlot;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101019", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	static QuickJumpSlot()
	{
		Class72.smethod_20();
	}
}
