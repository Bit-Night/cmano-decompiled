using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;
using Command_Core.Lua;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class SAO_LocalSound : ScenAttachmentObject
{
	[DoNotObfuscate]
	public string SoundFileName;

	private bool bool_0;

	private int int_0;

	public int Delay
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

	public SAO_LocalSound(string theObjectID)
		: base(theObjectID)
	{
		bool_0 = true;
		Type = AttachmentObjectType.localSound;
	}

	public SAO_LocalSound()
	{
		bool_0 = true;
		Type = AttachmentObjectType.localSound;
	}

	public override void ToXML(XmlWriter theWriter, HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("SAO_LocalSound");
			theWriter.WriteElementString("ID", base.ObjectID);
			theWriter.WriteElementString("Desc", Description);
			theWriter.WriteElementString("FFN", SoundFileName);
			if (Delay > 0)
			{
				theWriter.WriteElementString("Delay", Delay.ToString());
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

	public new static SAO_LocalSound FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		SAO_LocalSound result;
		try
		{
			SAO_LocalSound sAO_LocalSound = new SAO_LocalSound();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "ID":
					sAO_LocalSound._GUID = val.InnerText;
					break;
				case "Desc":
					sAO_LocalSound.Description = val.InnerText;
					break;
				case "FFN":
					sAO_LocalSound.SoundFileName = val.InnerText;
					break;
				case "Delay":
					sAO_LocalSound.Delay = Conversions.ToInteger(val.InnerText);
					break;
				}
			}
			result = sAO_LocalSound;
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
			result = new SAO_LocalSound();
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
		File.Copy(theFullFileName, Path.Combine(GameGeneral.AttachmentRepoPath, base.ObjectID, SoundFileName), overwrite: true);
	}

	public override bool UseAttachment(Scenario theScen)
	{
		PrivateMethods.ScenEdit_LocalSound(Path.Combine(GameGeneral.AttachmentRepoPath, base.ObjectID, SoundFileName), Delay);
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
		obj.WriteElementString("FFN", SoundFileName);
		obj.WriteEndElement();
		obj.Close();
	}

	static SAO_LocalSound()
	{
		Class72.smethod_20();
	}
}
