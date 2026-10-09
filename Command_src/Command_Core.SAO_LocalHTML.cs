using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class SAO_LocalHTML : ScenAttachmentObject
{
	[DoNotObfuscate]
	public string HTMLFileName;

	private int int_0;

	private int int_1;

	public int SizeX
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public int SizeY
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public SAO_LocalHTML(string theObjectID)
		: base(theObjectID)
	{
		Type = AttachmentObjectType.const_7;
	}

	public SAO_LocalHTML()
	{
		Type = AttachmentObjectType.const_7;
	}

	public override void ToXML(XmlWriter theWriter, HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("SAO_LocalHTML");
			theWriter.WriteElementString("ID", base.ObjectID);
			theWriter.WriteElementString("Desc", Description);
			theWriter.WriteElementString("HFN", HTMLFileName);
			if (SizeX > 0)
			{
				theWriter.WriteElementString("WindowSizeX", SizeX.ToString());
			}
			if (SizeY > 0)
			{
				theWriter.WriteElementString("WindowSizeY", SizeY.ToString());
			}
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101304", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static SAO_LocalHTML FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		SAO_LocalHTML result;
		try
		{
			SAO_LocalHTML sAO_LocalHTML = new SAO_LocalHTML();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "Desc":
					sAO_LocalHTML.Description = val.InnerText;
					break;
				case "HFN":
					sAO_LocalHTML.HTMLFileName = val.InnerText;
					break;
				case "WindowSizeX":
					sAO_LocalHTML.SizeX = Conversions.ToInteger(val.InnerText);
					break;
				case "WindowSizeY":
					sAO_LocalHTML.SizeY = Conversions.ToInteger(val.InnerText);
					break;
				case "ID":
					sAO_LocalHTML._GUID = val.InnerText;
					break;
				}
			}
			result = sAO_LocalHTML;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101305", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new SAO_LocalHTML();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override void CopyToLocalRepository(string theFullFileName)
	{
		if (!Directory.Exists(GameGeneral.AttachmentRepoPath))
		{
			Directory.CreateDirectory(GameGeneral.AttachmentRepoPath);
		}
		Directory.CreateDirectory(Path.Combine(GameGeneral.AttachmentRepoPath, base.ObjectID));
		File.Copy(theFullFileName, Path.Combine(GameGeneral.AttachmentRepoPath, base.ObjectID, HTMLFileName), overwrite: true);
	}

	internal string GetLOADDOCString()
	{
		string text = "[LOADDOC";
		if (SizeX > 0)
		{
			text = text + " SizeX=" + SizeX;
		}
		int num;
		if (SizeY > 0)
		{
			text = text + " SizeY=" + SizeY;
			num = 6;
		}
		else
		{
			num = 6;
		}
		string[] array = new string[num];
		array[0] = text;
		array[1] = "]";
		array[2] = _GUID.ToString();
		array[3] = "\\";
		array[4] = HTMLFileName;
		array[5] = "[/LOADDOC]";
		return string.Concat(array);
	}

	public override bool UseAttachment(Scenario theScen)
	{
		theScen.AddMessage(GetLOADDOCString(), "Special Message", LoggedMessage.MessageType.SpecialMessage, 0, "", theScen.GetCurrentSide());
		return true;
	}

	public override bool UseAttachmentOnSide(Scenario theScen, Side theSide)
	{
		theScen.AddMessage(GetLOADDOCString(), "Special Message", LoggedMessage.MessageType.SpecialMessage, 0, "", theSide);
		return true;
	}

	public override void vmethod_0(string theFullPath)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		XmlWriterSettings val = new XmlWriterSettings();
		val.Indent = true;
		val.IndentChars = "    ";
		XmlWriter val2 = XmlWriter.Create(Path.Combine(theFullPath, "desc.xml"), val);
		val2.WriteStartElement("Attachment");
		val2.WriteElementString("Type", Conversions.ToString((int)Type));
		val2.WriteElementString("Desc", Description);
		val2.WriteElementString("HFN", HTMLFileName);
		if (SizeX > 0)
		{
			val2.WriteElementString("WindowSizeX", SizeX.ToString());
		}
		if (SizeY > 0)
		{
			val2.WriteElementString("WindowSizeY", SizeY.ToString());
		}
		val2.WriteEndElement();
		val2.Close();
	}

	static SAO_LocalHTML()
	{
		Class72.smethod_20();
	}
}
