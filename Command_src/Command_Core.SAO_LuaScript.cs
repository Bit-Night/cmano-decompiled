using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class SAO_LuaScript : ScenAttachmentObject
{
	[DoNotObfuscate]
	public string ScriptFileName;

	public SAO_LuaScript(string theObjectID)
		: base(theObjectID)
	{
		Type = AttachmentObjectType.LuaScript;
	}

	public SAO_LuaScript()
	{
		Type = AttachmentObjectType.LuaScript;
	}

	public override void ToXML(XmlWriter theWriter, HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("SAO_LuaScript");
			theWriter.WriteElementString("ID", base.ObjectID);
			theWriter.WriteElementString("Desc", Description);
			theWriter.WriteElementString("SFN", ScriptFileName);
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101306", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static SAO_LuaScript FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		SAO_LuaScript result;
		try
		{
			SAO_LuaScript sAO_LuaScript = new SAO_LuaScript();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "ID":
					sAO_LuaScript._GUID = val.InnerText;
					break;
				case "SFN":
					sAO_LuaScript.ScriptFileName = val.InnerText;
					break;
				case "Desc":
					sAO_LuaScript.Description = val.InnerText;
					break;
				}
			}
			result = sAO_LuaScript;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101307", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new SAO_LuaScript();
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
		File.Copy(theFullFileName, Path.Combine(GameGeneral.AttachmentRepoPath, base.ObjectID, ScriptFileName), overwrite: true);
	}

	public override bool UseAttachment(Scenario theScen)
	{
		theScen.Scenario_LuaSandbox.LUA_ScenEdit_RunScript(Path.Combine(GameGeneral.AttachmentRepoPath, base.ObjectID, ScriptFileName));
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
		obj.WriteElementString("SFN", ScriptFileName);
		obj.WriteEndElement();
		obj.Close();
	}

	static SAO_LuaScript()
	{
		Class72.smethod_20();
	}
}
