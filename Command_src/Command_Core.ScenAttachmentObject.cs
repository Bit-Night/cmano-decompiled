using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class ScenAttachmentObject
{
	public enum AttachmentObjectType
	{
		MapOverlay_SingleImage,
		MapOverlay_Tiles,
		Audio,
		LocalVideo,
		LuaScript,
		Inst,
		localSound,
		const_7
	}

	protected string _GUID;

	public string Description;

	public AttachmentObjectType Type;

	public string ObjectID
	{
		get
		{
			if (string.IsNullOrEmpty(_GUID))
			{
				_GUID = Guid.NewGuid().ToString();
			}
			return _GUID;
		}
	}

	public string Name
	{
		get
		{
			return Description;
		}
		set
		{
			Description = value;
		}
	}

	public ScenAttachmentObject()
	{
	}

	public ScenAttachmentObject(string ObjectID)
	{
		_GUID = ObjectID;
	}

	public virtual void CopyToLocalRepository(string theFullFilePath)
	{
		throw new NotImplementedException();
	}

	public virtual void ToXML(XmlWriter theWriter, HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		throw new NotImplementedException();
	}

	public virtual void vmethod_0(string theFullPath)
	{
		throw new NotImplementedException();
	}

	public static ScenAttachmentObject FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen)
	{
		ScenAttachmentObject result;
		try
		{
			result = theNode.Name switch
			{
				"SAO_LuaScript" => SAO_LuaScript.FromXML(theNode, theDictionary, theScen), 
				"SAO_LocalHTML" => SAO_LocalHTML.FromXML(theNode, theDictionary, theScen), 
				"SAO_LocalSound" => SAO_LocalSound.FromXML(theNode, theDictionary, theScen), 
				"SAO_LocalVideo" => SAO_LocalVideo.FromXML(theNode, theDictionary, theScen), 
				"SAO_Inst" => SAO_Inst.FromXML(theNode, theDictionary, theScen), 
				"SAO_OverlaySingle" => SAO_OverlaySingle.FromXML(theNode, theDictionary, theScen), 
				_ => null, 
			};
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101310", "");
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

	public virtual bool UseAttachment(Scenario theScen)
	{
		throw new NotImplementedException();
	}

	public virtual bool UseAttachmentOnSide(Scenario theScen, Side theSide)
	{
		return UseAttachment(theScen);
	}

	public static ScenAttachmentObject ReadFromFolder(string theFolderName)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		ScenAttachmentObject scenAttachmentObject = null;
		if (Directory.GetFiles(theFolderName).Contains(Path.Combine(theFolderName, "desc.xml")))
		{
			XmlDocument val = new XmlDocument();
			val.Load(Path.Combine(theFolderName, "desc.xml"));
			string fileName = Path.GetFileName(theFolderName);
			AttachmentObjectType attachmentObjectType = (AttachmentObjectType)Conversions.ToInteger(((XmlNode)val).SelectSingleNode("/Attachment/Type").InnerText);
			string innerText = ((XmlNode)val).SelectSingleNode("/Attachment/Desc").InnerText;
			switch (attachmentObjectType)
			{
			case AttachmentObjectType.MapOverlay_SingleImage:
				scenAttachmentObject = new SAO_OverlaySingle(fileName);
				scenAttachmentObject.Name = innerText;
				((SAO_OverlaySingle)scenAttachmentObject).ImageFileName = ((XmlNode)val).SelectSingleNode("/Attachment/IFN").InnerText;
				break;
			case AttachmentObjectType.LocalVideo:
				scenAttachmentObject = new SAO_LocalVideo(fileName);
				scenAttachmentObject.Name = innerText;
				((SAO_LocalVideo)scenAttachmentObject).VideoFileName = ((XmlNode)val).SelectSingleNode("/Attachment/VFN").InnerText;
				break;
			case AttachmentObjectType.LuaScript:
				scenAttachmentObject = new SAO_LuaScript(fileName);
				scenAttachmentObject.Name = innerText;
				((SAO_LuaScript)scenAttachmentObject).ScriptFileName = ((XmlNode)val).SelectSingleNode("/Attachment/SFN").InnerText;
				break;
			case AttachmentObjectType.Inst:
				scenAttachmentObject = new SAO_Inst(fileName);
				scenAttachmentObject.Name = innerText;
				((SAO_Inst)scenAttachmentObject).InstFileName = ((XmlNode)val).SelectSingleNode("/Attachment/IFN").InnerText;
				break;
			case AttachmentObjectType.localSound:
				scenAttachmentObject = new SAO_LocalSound(fileName);
				scenAttachmentObject.Name = innerText;
				((SAO_LocalSound)scenAttachmentObject).SoundFileName = ((XmlNode)val).SelectSingleNode("/Attachment/FFN").InnerText;
				break;
			case AttachmentObjectType.const_7:
				scenAttachmentObject = new SAO_LocalHTML(fileName);
				scenAttachmentObject.Name = innerText;
				((SAO_LocalHTML)scenAttachmentObject).HTMLFileName = ((XmlNode)val).SelectSingleNode("/Attachment/HFN").InnerText;
				break;
			}
		}
		return scenAttachmentObject;
	}

	static ScenAttachmentObject()
	{
		Class72.smethod_20();
	}
}
