using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Campaign
{
	public class CampaignItem
	{
		public string Name;

		public CampaignItemType Type;

		static CampaignItem()
		{
			Class72.smethod_20();
		}
	}

	public enum CampaignItemType
	{
		ScenarioRecord,
		AttachmentRecord
	}

	public sealed class ScenarioRecord : CampaignItem
	{
		public string ID;

		public string FileName;

		private int int_0;

		public int PassScore
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

		public ScenarioRecord()
		{
			Type = CampaignItemType.ScenarioRecord;
		}

		static ScenarioRecord()
		{
			Class72.smethod_20();
		}
	}

	public sealed class AttachmentRecord : CampaignItem
	{
		public string ID;

		public AttachmentRecord()
		{
			Type = CampaignItemType.AttachmentRecord;
		}

		static AttachmentRecord()
		{
			Class72.smethod_20();
		}
	}

	public string ID;

	public string Name;

	public string Description;

	public List<CampaignItem> CampaignItems;

	public string EndingText;

	public string FolderPath;

	public string LuaXml;

	private void method_0(ref XmlWriter xmlWriter_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("Campaign");
			xmlWriter_0.WriteElementString("ID", ID);
			xmlWriter_0.WriteElementString("Name", Name);
			xmlWriter_0.WriteElementString("Description", Description);
			xmlWriter_0.WriteElementString("EndingText", EndingText);
			if (CampaignItems.Count > 0)
			{
				xmlWriter_0.WriteStartElement("Items");
				foreach (CampaignItem campaignItem in CampaignItems)
				{
					Type type = campaignItem.GetType();
					if (!(type == typeof(ScenarioRecord)))
					{
						if (type == typeof(AttachmentRecord))
						{
							xmlWriter_0.WriteStartElement("Attachment");
							AttachmentRecord attachmentRecord = (AttachmentRecord)campaignItem;
							xmlWriter_0.WriteElementString("Name", attachmentRecord.Name);
							xmlWriter_0.WriteElementString("ID", attachmentRecord.ID);
							xmlWriter_0.WriteEndElement();
						}
					}
					else
					{
						ScenarioRecord scenarioRecord = (ScenarioRecord)campaignItem;
						xmlWriter_0.WriteStartElement("Scenario");
						xmlWriter_0.WriteElementString("Name", scenarioRecord.Name);
						xmlWriter_0.WriteElementString("ID", scenarioRecord.ID);
						xmlWriter_0.WriteElementString("File", scenarioRecord.FileName);
						xmlWriter_0.WriteElementString("PassScore", Conversions.ToString(scenarioRecord.PassScore));
						xmlWriter_0.WriteEndElement();
					}
				}
				xmlWriter_0.WriteEndElement();
			}
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101311", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static Campaign smethod_0(ref XmlNode xmlNode_0)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		Campaign result = default(Campaign);
		try
		{
			Campaign campaign = new Campaign();
			foreach (XmlNode childNode in xmlNode_0.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "ID":
					campaign.ID = val.InnerText;
					break;
				case "Description":
					campaign.Description = val.InnerText;
					break;
				case "EndingText":
					campaign.EndingText = val.InnerText;
					break;
				case "Items":
					foreach (XmlNode childNode2 in val.ChildNodes)
					{
						XmlNode val2 = childNode2;
						string name = val2.Name;
						if (Operators.CompareString(name, "Scenario", false) != 0)
						{
							if (Operators.CompareString(name, "Attachment", false) != 0)
							{
								continue;
							}
							AttachmentRecord attachmentRecord = new AttachmentRecord();
							foreach (XmlNode childNode3 in val2.ChildNodes)
							{
								XmlNode val3 = childNode3;
								string name2 = val3.Name;
								if (Operators.CompareString(name2, "Name", false) == 0)
								{
									attachmentRecord.Name = val3.InnerText;
								}
								else if (Operators.CompareString(name2, "ID", false) == 0)
								{
									attachmentRecord.ID = val3.InnerText;
								}
							}
							campaign.CampaignItems.Add(attachmentRecord);
							continue;
						}
						ScenarioRecord scenarioRecord = new ScenarioRecord();
						foreach (XmlNode childNode4 in val2.ChildNodes)
						{
							XmlNode val4 = childNode4;
							switch (val4.Name)
							{
							case "ID":
								scenarioRecord.ID = val4.InnerText;
								break;
							case "PassScore":
								scenarioRecord.PassScore = Conversions.ToInteger(val4.InnerText);
								break;
							case "File":
								scenarioRecord.FileName = val4.InnerText;
								break;
							case "Name":
								scenarioRecord.Name = val4.InnerText;
								break;
							}
						}
						campaign.CampaignItems.Add(scenarioRecord);
					}
					break;
				case "Name":
					campaign.Name = val.InnerText;
					break;
				}
			}
			result = campaign;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101312", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public Campaign()
	{
		CampaignItems = new List<CampaignItem>();
		ID = Guid.NewGuid().ToString();
	}

	public static Campaign ReadFromFile(string theFileName)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		FileStream fileStream = new FileStream(theFileName, FileMode.Open, FileAccess.Read);
		XmlDocument val = new XmlDocument();
		using (fileStream)
		{
			val.Load((Stream)fileStream);
		}
		XmlNode xmlNode_ = ((XmlNode)val).ChildNodes[1];
		Campaign campaign = smethod_0(ref xmlNode_);
		campaign.FolderPath = Path.GetDirectoryName(theFileName);
		return campaign;
	}

	public void Save(string FileName)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		FileStream fileStream = new FileStream(FileName, FileMode.Create, FileAccess.Write);
		using (fileStream)
		{
			XmlWriterSettings val = new XmlWriterSettings();
			val.Indent = true;
			val.IndentChars = "    ";
			XmlWriter xmlWriter_ = XmlWriter.Create((Stream)fileStream, val);
			method_0(ref xmlWriter_);
			xmlWriter_.Flush();
			fileStream.Flush();
		}
	}

	public static Campaign GetCampaignByID(string RootFolderToSearch, string theCampaignID)
	{
		List<string> list = new List<string>();
		GetCampaignsInFolder(RootFolderToSearch, list);
		foreach (string item in list)
		{
			Campaign campaign = ReadFromFile(item);
			if (Operators.CompareString(campaign.ID, theCampaignID, false) == 0)
			{
				return campaign;
			}
		}
		return null;
	}

	public static void GetCampaignsInFolder(string theFolder, List<string> theList)
	{
		if (!theFolder.Equals(GameGeneral.ScenariosRootPath))
		{
			string[] files = Directory.GetFiles(theFolder);
			foreach (string text in files)
			{
				if (Operators.CompareString(Path.GetExtension(text), ".campaign", false) == 0)
				{
					theList.Add(text);
				}
			}
		}
		string[] directories = Directory.GetDirectories(theFolder);
		for (int j = 0; j < directories.Length; j = checked(j + 1))
		{
			GetCampaignsInFolder(directories[j], theList);
		}
	}

	public ScenarioRecord GetScenarioRecord(string ScenarioGUID)
	{
		foreach (CampaignItem campaignItem in CampaignItems)
		{
			if ((object)campaignItem.GetType() == typeof(ScenarioRecord) && Operators.CompareString(((ScenarioRecord)campaignItem).ID, ScenarioGUID, false) == 0)
			{
				return (ScenarioRecord)campaignItem;
			}
		}
		return null;
	}

	public static string GetCampaignFilename(string theCampaignID)
	{
		List<string> list = new List<string>();
		GetCampaignsInFolder(GameGeneral.ScenariosRootPath, list);
		foreach (string item in list)
		{
			if (Operators.CompareString(ReadFromFile(item).ID, theCampaignID, false) == 0)
			{
				return item;
			}
		}
		return null;
	}

	public static int? GetCampaignScenarioPassScore(Scenario theScen)
	{
		int? result = null;
		List<string> list = new List<string>();
		GetCampaignsInFolder(GameGeneral.ScenariosRootPath, list);
		foreach (string item in list)
		{
			Campaign campaign = ReadFromFile(item);
			if (Operators.CompareString(campaign.ID, theScen.CampaignID, false) == 0)
			{
				ScenarioRecord scenarioRecord = campaign.GetScenarioRecord(theScen.ObjectID);
				if (scenarioRecord != null)
				{
					result = scenarioRecord.PassScore;
					return result;
				}
			}
		}
		return result;
	}

	public string GetFirstScenarioFilename(string CampaignFileName)
	{
		foreach (CampaignItem campaignItem in CampaignItems)
		{
			if ((object)campaignItem.GetType() == typeof(ScenarioRecord))
			{
				return Path.GetDirectoryName(CampaignFileName) + "\\" + ((ScenarioRecord)campaignItem).FileName;
			}
		}
		return null;
	}

	public static void UpdateHistory(string theFileName, Campaign theCampaign, Scenario CurrentScenario)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		int passScore = theCampaign.GetScenarioRecord(CurrentScenario.ObjectID).PassScore;
		_ = DateAndTime.Today;
		string path = Path.GetDirectoryName(theFileName) + "\\" + CurrentScenario.CampaignSessionID + ".xml";
		FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
		XmlDocument val = new XmlDocument();
		using (fileStream)
		{
			XmlNode val2;
			XmlNode val3;
			if (fileStream.Length <= 0L)
			{
				val2 = (XmlNode)(object)val.CreateElement("Campaign");
				((XmlNode)val).AppendChild(val2);
				val3 = (XmlNode)(object)val.CreateElement("ID");
				val3.AppendChild((XmlNode)(object)val.CreateTextNode(theCampaign.ID));
				val2.AppendChild(val3);
				val3 = (XmlNode)(object)val.CreateElement("Name");
				val3.AppendChild((XmlNode)(object)val.CreateTextNode(theCampaign.Name));
				val2.AppendChild(val3);
				val3 = (XmlNode)(object)val.CreateElement("Scenarios");
				val2.AppendChild(val3);
			}
			else
			{
				val.Load((Stream)fileStream);
			}
			val2 = ((XmlNode)val).SelectSingleNode("descendant::Scenarios");
			XmlNode val4 = (XmlNode)(object)val.CreateElement("Scenario");
			val2.AppendChild(val4);
			val3 = (XmlNode)(object)val.CreateElement("Name");
			val3.AppendChild((XmlNode)(object)val.CreateTextNode(CurrentScenario.Title));
			val4.AppendChild(val3);
			val3 = (XmlNode)(object)val.CreateElement("FileName");
			val3.AppendChild((XmlNode)(object)val.CreateTextNode(theCampaign.GetScenarioRecord(CurrentScenario.ObjectID).FileName));
			val4.AppendChild(val3);
			val3 = (XmlNode)(object)val.CreateElement("ID");
			val3.AppendChild((XmlNode)(object)val.CreateTextNode(CurrentScenario.ObjectID));
			val4.AppendChild(val3);
			val3 = (XmlNode)(object)val.CreateElement("Score");
			val3.AppendChild((XmlNode)(object)val.CreateTextNode(CurrentScenario.GetCurrentSide().get_TotalScore(CurrentScenario, (string)null).ToString()));
			val4.AppendChild(val3);
			val3 = (XmlNode)(object)val.CreateElement("PassScore");
			val3.AppendChild((XmlNode)(object)val.CreateTextNode(passScore.ToString()));
			val4.AppendChild(val3);
			val3 = (XmlNode)(object)val.CreateElement("CompletedOn");
			val3.AppendChild((XmlNode)(object)val.CreateTextNode(DateAndTime.Today.ToLocalTime().ToString()));
			val4.AppendChild(val3);
			fileStream.Position = 0L;
			val.Save((Stream)fileStream);
			fileStream.Flush();
		}
		fileStream.Close();
	}

	static Campaign()
	{
		Class72.smethod_20();
	}
}
