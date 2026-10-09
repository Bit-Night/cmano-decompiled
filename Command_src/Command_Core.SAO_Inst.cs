using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class SAO_Inst : ScenAttachmentObject
{
	[DoNotObfuscate]
	public string InstFileName;

	public SAO_Inst(string theObjectID)
		: base(theObjectID)
	{
		Type = AttachmentObjectType.Inst;
	}

	public SAO_Inst()
	{
		Type = AttachmentObjectType.Inst;
	}

	public override void ToXML(XmlWriter theWriter, HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("SAO_Inst");
			theWriter.WriteElementString("ID", base.ObjectID);
			theWriter.WriteElementString("Desc", Description);
			theWriter.WriteElementString("IFN", InstFileName);
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101302", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static SAO_Inst FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		SAO_Inst result;
		try
		{
			SAO_Inst sAO_Inst = new SAO_Inst();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "ID":
					sAO_Inst._GUID = val.InnerText;
					break;
				case "IFN":
					sAO_Inst.InstFileName = val.InnerText;
					break;
				case "Desc":
					sAO_Inst.Description = val.InnerText;
					break;
				}
			}
			result = sAO_Inst;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101303", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = null;
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
		File.Copy(theFullFileName, Path.Combine(GameGeneral.AttachmentRepoPath, base.ObjectID, InstFileName), overwrite: true);
	}

	public override bool UseAttachment(Scenario theScen)
	{
		return UseAttachmentOnSide(theScen, theScen.GetCurrentSide());
	}

	public override bool UseAttachmentOnSide(Scenario theScen, Side theSide)
	{
		theScen.ImportUnitsFromFile(Path.Combine(GameGeneral.AttachmentRepoPath, base.ObjectID, InstFileName), theSide);
		return true;
	}

	public override void vmethod_0(string theFullPath)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		XmlWriterSettings val = new XmlWriterSettings();
		val.Indent = true;
		val.IndentChars = "    ";
		XmlWriter obj = XmlWriter.Create(Path.Combine(theFullPath, "desc.xml"), val);
		obj.WriteStartElement("Attachment");
		obj.WriteElementString("Type", Conversions.ToString((int)Type));
		obj.WriteElementString("Desc", Description);
		obj.WriteElementString("IFN", InstFileName);
		obj.WriteEndElement();
		obj.Close();
	}

	static SAO_Inst()
	{
		Class72.smethod_20();
	}
}
