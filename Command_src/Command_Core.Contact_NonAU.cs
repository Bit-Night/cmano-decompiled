using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Contact_NonAU : Contact_Base
{
	public Module_Unit.Unit ActualUnit;

	protected string _ActualUnitID;

	internal new void Reinitialize()
	{
		ActualUnit = null;
		Type = ContactType.Air;
		OriginalDetectorSide = null;
	}

	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
		try
		{
			theWriter.WriteStartElement("Contact_NonAU");
			theWriter.WriteElementString("ID", ObjectID);
			if (!Information.IsNothing((object)ActualUnit))
			{
				theWriter.WriteElementString("ActualUnitID", ActualUnit.ObjectID);
			}
			XmlWriter obj = theWriter;
			int iDStatus = (int)_IDStatus;
			obj.WriteElementString("IDStatus", iDStatus.ToString());
			theWriter.WriteElementString("SIK", SideIsKnown.ToString());
			if (!Information.IsNothing((object)Type))
			{
				XmlWriter obj2 = theWriter;
				iDStatus = (int)Type;
				obj2.WriteElementString("Type", iDStatus.ToString());
			}
			theWriter.WriteElementString("AInc", _AutoIncrement.ToString());
			if (!Information.IsNothing((object)OriginalDetectorSide))
			{
				theWriter.WriteElementString("ODS", OriginalDetectorSide.Name);
			}
			if (!Information.IsNothing((object)OriginalDetectorUnitID))
			{
				theWriter.WriteElementString("ODU", OriginalDetectorUnitID);
			}
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100499", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static Contact_NonAU FromXML(ref XmlNode theNode, Contact_NonAU existingObject = null)
	{
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		Contact_NonAU contact_NonAU = new Contact_NonAU();
		if (existingObject != null)
		{
			contact_NonAU = existingObject;
			contact_NonAU.Reinitialize();
		}
		else
		{
			contact_NonAU = new Contact_NonAU();
		}
		Contact_NonAU result;
		try
		{
			string innerText = Misc.GetNodeByName(theNode.ChildNodes, "ID").InnerText;
			if (Misc.ContainsChar(innerText, ' '))
			{
				innerText = innerText.Replace(" ", "-");
			}
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "Type":
					if (!Versioned.IsNumeric((object)val.InnerText))
					{
						contact_NonAU.Type = (ContactType)Enum.Parse(typeof(ContactType), val.InnerText, ignoreCase: true);
					}
					else
					{
						contact_NonAU.Type = (ContactType)Conversions.ToByte(val.InnerText);
					}
					break;
				case "IDStatus":
					if (Versioned.IsNumeric((object)val.InnerText))
					{
						contact_NonAU._IDStatus = (IdentificationStatus)Conversions.ToShort(val.InnerText);
					}
					else
					{
						contact_NonAU._IDStatus = (IdentificationStatus)Enum.Parse(typeof(IdentificationStatus), val.InnerText, ignoreCase: true);
					}
					break;
				case "ID":
					if (theNode.ChildNodes.Count != 1)
					{
						contact_NonAU.ObjectID_Set(val.InnerText);
						break;
					}
					result = null;
					goto end_IL_001c;
				case "OriginalDetectorSide":
				case "ODS":
					contact_NonAU._OriginalDetectorSide_Name = val.InnerText;
					break;
				case "ActualUnitID":
					contact_NonAU._ActualUnitID = val.InnerText;
					break;
				case "AInc":
				case "AutoIncrement":
					contact_NonAU._AutoIncrement = Conversions.ToInteger(val.InnerText);
					break;
				case "SideIsKnown":
				case "SIK":
					contact_NonAU.SideIsKnown = Misc.ParseBool(val.InnerText);
					break;
				}
			}
			result = contact_NonAU;
			end_IL_001c:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100500", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Contact_NonAU();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	static Contact_NonAU()
	{
		Class72.smethod_20();
	}
}
