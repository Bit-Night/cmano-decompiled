using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class SAO_OverlaySingle : ScenAttachmentObject
{
	public delegate void UseMapOverlayEventHandler(string theFullFileName);

	[DoNotObfuscate]
	public string ImageFileName;

	[CompilerGenerated]
	private static UseMapOverlayEventHandler useMapOverlayEventHandler_0;

	public static event UseMapOverlayEventHandler UseMapOverlay
	{
		[CompilerGenerated]
		add
		{
			UseMapOverlayEventHandler useMapOverlayEventHandler = useMapOverlayEventHandler_0;
			UseMapOverlayEventHandler useMapOverlayEventHandler2;
			do
			{
				useMapOverlayEventHandler2 = useMapOverlayEventHandler;
				UseMapOverlayEventHandler value2 = (UseMapOverlayEventHandler)Delegate.Combine(useMapOverlayEventHandler2, value);
				useMapOverlayEventHandler = Interlocked.CompareExchange(ref useMapOverlayEventHandler_0, value2, useMapOverlayEventHandler2);
			}
			while ((object)useMapOverlayEventHandler != useMapOverlayEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			UseMapOverlayEventHandler useMapOverlayEventHandler = useMapOverlayEventHandler_0;
			UseMapOverlayEventHandler useMapOverlayEventHandler2;
			do
			{
				useMapOverlayEventHandler2 = useMapOverlayEventHandler;
				UseMapOverlayEventHandler value2 = (UseMapOverlayEventHandler)Delegate.Remove(useMapOverlayEventHandler2, value);
				useMapOverlayEventHandler = Interlocked.CompareExchange(ref useMapOverlayEventHandler_0, value2, useMapOverlayEventHandler2);
			}
			while ((object)useMapOverlayEventHandler != useMapOverlayEventHandler2);
		}
	}

	public SAO_OverlaySingle(string theObjectID)
		: base(theObjectID)
	{
		Type = AttachmentObjectType.MapOverlay_SingleImage;
	}

	public SAO_OverlaySingle()
	{
		Type = AttachmentObjectType.MapOverlay_SingleImage;
	}

	public override void ToXML(XmlWriter theWriter, HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("SAO_OverlaySingle");
			theWriter.WriteElementString("ID", base.ObjectID);
			theWriter.WriteElementString("Desc", Description);
			theWriter.WriteElementString("IFN", ImageFileName);
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101308", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static SAO_OverlaySingle FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		SAO_OverlaySingle result = default(SAO_OverlaySingle);
		try
		{
			SAO_OverlaySingle sAO_OverlaySingle = new SAO_OverlaySingle();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "ID":
					sAO_OverlaySingle._GUID = val.InnerText;
					break;
				case "Desc":
					sAO_OverlaySingle.Description = val.InnerText;
					break;
				case "IFN":
					sAO_OverlaySingle.ImageFileName = val.InnerText;
					break;
				}
			}
			result = sAO_OverlaySingle;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101309", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
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
		string text = Misc.GeoreferenceFileForThisImageFile(theFullFileName);
		if (!string.IsNullOrEmpty(text))
		{
			Directory.CreateDirectory(Path.Combine(GameGeneral.AttachmentRepoPath, base.ObjectID));
			File.Copy(theFullFileName, Path.Combine(GameGeneral.AttachmentRepoPath, base.ObjectID, ImageFileName), overwrite: true);
			File.Copy(text, Path.Combine(GameGeneral.AttachmentRepoPath, base.ObjectID, Path.GetFileName(text)), overwrite: true);
		}
		else
		{
			GameGeneral.SendMessageBoxToUI("No suitable geo-reference file found for image!", null);
		}
	}

	public override bool UseAttachment(Scenario theScen)
	{
		useMapOverlayEventHandler_0?.Invoke(Path.Combine(GameGeneral.AttachmentRepoPath, base.ObjectID, ImageFileName));
		bool result = default(bool);
		return result;
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
		obj.WriteElementString("IFN", ImageFileName);
		obj.WriteEndElement();
		obj.Close();
	}

	static SAO_OverlaySingle()
	{
		Class72.smethod_20();
	}
}
