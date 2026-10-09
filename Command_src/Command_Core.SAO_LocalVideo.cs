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

public sealed class SAO_LocalVideo : ScenAttachmentObject
{
	[DoNotObfuscate]
	public string VideoFileName;

	private bool bool_0;

	private int int_0;

	public bool FullScreen
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

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

	public SAO_LocalVideo(string theObjectID)
		: base(theObjectID)
	{
		bool_0 = true;
		Type = AttachmentObjectType.LocalVideo;
	}

	public SAO_LocalVideo()
	{
		bool_0 = true;
		Type = AttachmentObjectType.LocalVideo;
	}

	public override void ToXML(XmlWriter theWriter, HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("SAO_LocalVideo");
			theWriter.WriteElementString("ID", base.ObjectID);
			theWriter.WriteElementString("Desc", Description);
			theWriter.WriteElementString("VFN", VideoFileName);
			if (FullScreen)
			{
				theWriter.WriteElementString("FS", FullScreen.ToString());
			}
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

	public new static SAO_LocalVideo FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		SAO_LocalVideo result;
		try
		{
			SAO_LocalVideo sAO_LocalVideo = new SAO_LocalVideo();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "ID":
					sAO_LocalVideo._GUID = val.InnerText;
					break;
				case "Delay":
					sAO_LocalVideo.Delay = Conversions.ToInteger(val.InnerText);
					break;
				case "FS":
					sAO_LocalVideo.FullScreen = Misc.ParseBool(val.InnerText);
					break;
				case "VFN":
					sAO_LocalVideo.VideoFileName = val.InnerText;
					break;
				case "Desc":
					sAO_LocalVideo.Description = val.InnerText;
					break;
				}
			}
			result = sAO_LocalVideo;
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
			result = new SAO_LocalVideo();
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
		File.Copy(theFullFileName, Path.Combine(GameGeneral.AttachmentRepoPath, base.ObjectID, VideoFileName), overwrite: true);
	}

	public override bool UseAttachment(Scenario theScen)
	{
		PrivateMethods.ScenEdit_LocalVideo(Path.Combine(GameGeneral.AttachmentRepoPath, base.ObjectID, VideoFileName), theScen, FullScreen, Delay);
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
		obj.WriteElementString("VFN", VideoFileName);
		obj.WriteEndElement();
		obj.Close();
	}

	static SAO_LocalVideo()
	{
		Class72.smethod_20();
	}
}
