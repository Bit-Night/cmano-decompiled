using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Aced.Compression;
using LZ4;
using Microsoft.IO;
using Microsoft.VisualBasic.CompilerServices;
using SevenZip;

namespace Command_Core;

[Serializable]
public sealed class ScenContainer
{
	public string ScenTitle;

	public string ScenDescription;

	public string ScenAuthor;

	public short Complexity;

	public short Difficulty;

	public string ScenSetting;

	public short ScenDate;

	public string string_0;

	private Scenario scenario_0;

	public byte[] Scenario_Compressed;

	public int CompressVersion;

	[XmlElement("BuildNumber", IsNullable = true)]
	public string BuildNumber;

	[XmlElement("Version", IsNullable = true)]
	public string Version;

	public bool IsCampaignCheckpoint;

	public long SaveCurrentTime;

	public string CampaignID;

	public string CampaignSessionID;

	public static ScenContainer FromXML(string Xml)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		ScenContainer result;
		try
		{
			XmlSerializer val = new XmlSerializer(typeof(ScenContainer));
			StringReader stringReader = new StringReader(Xml);
			XmlTextReader val2 = new XmlTextReader((TextReader)stringReader);
			ScenContainer obj = (ScenContainer)val.Deserialize((XmlReader)(object)val2);
			val2.Close();
			stringReader.Close();
			result = obj;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101047", "");
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

	public static string QueryScenContainer(string theFileName, string theQuery)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Expected O, but got Unknown
		XmlTextReader val = new XmlTextReader(theFileName);
		XmlTextReader val2 = val;
		try
		{
			if (!((XmlReader)val).ReadToDescendant(theQuery))
			{
				return null;
			}
			return ((XmlReader)val).ReadElementContentAsString();
		}
		finally
		{
			((IDisposable)val2)?.Dispose();
		}
	}

	private string method_0()
	{
		try
		{
			AcedInflator acedInflator = new AcedInflator();
			byte[] array = new byte[Scenario_Compressed.Length + 1];
			array = Scenario_Compressed;
			byte[] array2 = acedInflator.Decompress(array, 0, 0, 0);
			array = null;
			int num = array2.Length - 1;
			while (array2[num] == 0)
			{
				num--;
			}
			byte[] array3 = new byte[num + 1 + 1];
			Array.Copy(array2, array3, num + 1);
			array2 = array3;
			array2 = Misc.CleanUpXML_Headers(array2);
			array2 = Misc.CleanUpXML_IllegalCharacters(array2);
			string result = Encoding.UTF8.GetString(array2);
			array2 = null;
			return result;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private string method_1()
	{
		using MemoryStream archiveStream = RCMS.recyclableMemoryStreamManager_0.GetStream(Scenario_Compressed);
		using MemoryStream memoryStream = RCMS.recyclableMemoryStreamManager_0.GetStream();
		new SevenZipExtractor(archiveStream, GameGeneral.SZPW).ExtractFile(0, memoryStream);
		memoryStream.Seek(0L, SeekOrigin.Begin);
		byte[] byte_ = memoryStream.ToArray();
		byte_ = Misc.CleanUpXML_Headers(byte_);
		byte_ = Misc.CleanUpXML_IllegalCharacters(byte_);
		string result = Encoding.UTF8.GetString(byte_);
		byte_ = null;
		return result;
	}

	public void CompressScenario_Aced()
	{
		using MemoryStream theStream = GameGeneral.GetScenarioClone(scenario_0);
		CompressVersion = 1;
		Scenario_Compressed = Compression.CompressStream_Aced(theStream, AcedCompressionLevel.Maximum);
	}

	public void CompressScenario_Aced(Stream theStream)
	{
		CompressVersion = 1;
		Scenario_Compressed = Compression.CompressStream_Aced(theStream, AcedCompressionLevel.Maximum);
	}

	public void CompressScenario_7z()
	{
		using MemoryStream theStream = GameGeneral.GetScenarioClone(scenario_0);
		CompressVersion = 2;
		using MemoryStream memoryStream = Compression.CompressStream_7z(theStream, CompressionLevel.High);
		Scenario_Compressed = memoryStream.ToArray();
	}

	public void CompressScenario_7z(Stream theStream)
	{
		CompressVersion = 2;
		using MemoryStream memoryStream = Compression.CompressStream_7z(theStream, CompressionLevel.High);
		Scenario_Compressed = memoryStream.ToArray();
	}

	public void AttachAndCompressScenarioObject(Stream MemStream_ScenarioObject)
	{
		try
		{
			CompressScenario_LZ(MemStream_ScenarioObject);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200055", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			ProjectData.ClearProjectError();
		}
	}

	public void SaveToFile(string theFileName, bool PreserveOriginalTimestamps = false)
	{
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		if (Scenario_Compressed == null)
		{
			try
			{
				try
				{
					CompressScenario_LZ();
				}
				catch (OutOfMemoryException projectError)
				{
					ProjectData.SetProjectError((Exception)projectError);
					CompressScenario_LZ();
					ProjectData.ClearProjectError();
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				CompressScenario_Aced();
				ex2?.Data.Add("Error at 200056", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				ProjectData.ClearProjectError();
			}
		}
		scenario_0 = null;
		bool flag = false;
		DateTime creationTime = default(DateTime);
		DateTime lastWriteTime = default(DateTime);
		DateTime lastAccessTime = default(DateTime);
		if (PreserveOriginalTimestamps && FileExistsNative.FileExistsFast(theFileName))
		{
			flag = true;
			FileInfo fileInfo = new FileInfo(theFileName);
			creationTime = fileInfo.CreationTime;
			lastWriteTime = fileInfo.LastWriteTime;
			lastAccessTime = fileInfo.LastAccessTime;
		}
		if (!Directory.Exists(Path.GetDirectoryName(theFileName)))
		{
			Directory.CreateDirectory(Path.GetDirectoryName(theFileName));
		}
		FileStream fileStream = new FileStream(theFileName, FileMode.Create);
		new XmlSerializer(GetType()).Serialize((Stream)fileStream, (object)this);
		fileStream.Close();
		fileStream = null;
		if (PreserveOriginalTimestamps && flag)
		{
			new FileInfo(theFileName)
			{
				CreationTime = creationTime,
				LastWriteTime = lastWriteTime,
				LastAccessTime = lastAccessTime
			};
		}
	}

	public override string ToString()
	{
		MemoryStream memoryStream = method_2();
		using (memoryStream)
		{
			return Misc.ConvertToString(memoryStream);
		}
	}

	private MemoryStream method_2()
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		if (Scenario_Compressed == null)
		{
			try
			{
				CompressScenario_LZ();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				CompressScenario_Aced();
				ex2?.Data.Add("Error at 200057", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		scenario_0 = null;
		MemoryStream stream = RCMS.recyclableMemoryStreamManager_0.GetStream();
		new XmlSerializer(typeof(ScenContainer)).Serialize((Stream)stream, (object)this);
		return stream;
	}

	public static ScenContainer LoadFromFile(string theFileName)
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (!Directory.Exists(Path.GetDirectoryName(theFileName)))
			{
				Directory.CreateDirectory(Path.GetDirectoryName(theFileName));
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
		try
		{
			using FileStream fileStream = new FileStream(theFileName, FileMode.Open);
			return (ScenContainer)new XmlSerializer(typeof(ScenContainer)).Deserialize((Stream)fileStream);
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public string GetScenarioObject_AsXML()
	{
		string result = "";
		try
		{
			switch (CompressVersion)
			{
			case 1:
				result = method_0();
				break;
			case 2:
				result = method_1();
				break;
			case 3:
				result = Crypto.DecryptStringAES(method_0(), GameGeneral.SZPW);
				break;
			case 5:
				result = DecompressScenarioObjectToXML_LZ();
				break;
			}
			return result;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public Scenario GetScenarioObject(ref string ErrorFeedback, Action<double> PercentageComplete, bool ForceDeepRebuild, bool IgnoreCachedScenObject = true)
	{
		if (scenario_0 == null || IgnoreCachedScenObject)
		{
			if (PercentageComplete == null)
			{
				PercentageComplete = [SpecialName] (double d) =>
				{
				};
			}
			Scenario scenario = Scenario.FromXmlText(GetScenarioObject_AsXML(), ref ErrorFeedback, PercentageComplete, ForceDeepRebuild);
			scenario_0 = scenario;
		}
		return scenario_0;
	}

	public ScenContainer(Scenario theScen)
	{
		CompressVersion = 1;
		IsCampaignCheckpoint = false;
		scenario_0 = theScen;
		if (theScen == null)
		{
			Complexity = 1;
			Difficulty = 1;
			ScenSetting = "Not set";
		}
		else
		{
			if (!string.IsNullOrEmpty(theScen.Title))
			{
				ScenTitle = theScen.Title.ToString();
			}
			if (!string.IsNullOrEmpty(theScen.Description))
			{
				ScenDescription = theScen.Description.ToString();
			}
			if (!string.IsNullOrEmpty(theScen.Description))
			{
				ScenDescription = theScen.Description.ToString();
			}
			ScenTitle = theScen.Title;
			ScenDescription = theScen.Description;
			Complexity = theScen.Meta_Complexity;
			Difficulty = theScen.Meta_Difficulty;
			ScenSetting = theScen.Meta_ScenSetting;
			ScenDate = (short)theScen.StartTime.Year;
			SaveCurrentTime = theScen.Time.ToBinary();
			CampaignID = theScen.CampaignID;
			CampaignSessionID = theScen.CampaignSessionID;
			string dBUsed = theScen.DBUsed;
			DBOps.DBFileCheckResult theResult = DBOps.DBFileCheckResult.Undefined;
			DBRecord dBRecordByHash = DBOps.GetDBRecordByHash(dBUsed, ref theResult, CheckLocalFileExists: true, CheckForTampering: false);
			if (dBRecordByHash != null)
			{
				string_0 = dBRecordByHash.FileName;
			}
		}
		BuildNumber = "v1.10 - Build 1900.20";
		Version = GameGeneral.ProgramTitle;
	}

	public ScenContainer()
	{
		CompressVersion = 1;
		IsCampaignCheckpoint = false;
	}

	public void CompressScenario_LZ()
	{
		CompressVersion = 5;
		RijndaelManaged rijndaelManaged = smethod_0();
		using MemoryStream theStream = GameGeneral.GetScenarioClone(scenario_0);
		using MemoryTributary memoryTributary = Compression.CompressStream_LZ(theStream);
		memoryTributary.Seek(0L, SeekOrigin.Begin);
		ICryptoTransform transform = rijndaelManaged.CreateEncryptor(rijndaelManaged.Key, rijndaelManaged.IV);
		using MemoryTributary memoryTributary2 = new MemoryTributary();
		memoryTributary2.Write(BitConverter.GetBytes(rijndaelManaged.IV.Length), 0, 4);
		memoryTributary2.Write(rijndaelManaged.IV, 0, rijndaelManaged.IV.Length);
		using (CryptoStream destination = new CryptoStream(memoryTributary2, transform, CryptoStreamMode.Write))
		{
			memoryTributary.CopyTo(destination);
		}
		Scenario_Compressed = memoryTributary2.ToArray();
	}

	public void CompressScenario_LZ(Stream MemStream_ScenarioObject)
	{
		CompressVersion = 5;
		RijndaelManaged rijndaelManaged = smethod_0();
		using (MemStream_ScenarioObject)
		{
			using MemoryTributary memoryTributary = Compression.CompressStream_LZ(MemStream_ScenarioObject);
			memoryTributary.Seek(0L, SeekOrigin.Begin);
			ICryptoTransform transform = rijndaelManaged.CreateEncryptor(rijndaelManaged.Key, rijndaelManaged.IV);
			using MemoryTributary memoryTributary2 = new MemoryTributary();
			memoryTributary2.Write(BitConverter.GetBytes(rijndaelManaged.IV.Length), 0, 4);
			memoryTributary2.Write(rijndaelManaged.IV, 0, rijndaelManaged.IV.Length);
			using (CryptoStream destination = new CryptoStream(memoryTributary2, transform, CryptoStreamMode.Write))
			{
				memoryTributary.CopyTo(destination);
			}
			Scenario_Compressed = memoryTributary2.ToArray();
		}
	}

	private static RijndaelManaged smethod_0()
	{
		byte[] bytes = Encoding.ASCII.GetBytes("Eg:ù2à[kÝB{ãÞ¬KîâÉ{µ\\µ¥¤4\u00b4J»ãvaWÀó±òÈV:£W-(Èª|cêI¹");
		string password = "âcI}\u00b4EjÆãoµËÛÞwÿë6ØçÌP«4lWT¶-áòêªÓb¶þ×r2Z,¬}¶üÿTYá^¦\u00afH%ÿºÂOð=_Û^&¬oÚýª~ÁtÂRëg{Ñ§kA«Õº½Ë¥PÊ+jbo<_ù\u00a8xKUíTïBGÙøªçäð(tX`íÅuÉù³l(¶WØ$ëèw¬¦ÇJ|Z©*.¼ÏÒ_<·UP=W²üßå3ÂOºÃo_¤«ì8G2¶/R¬mo;>YwsÿJS}W£1ãC?ÍREÚâÙLK¬ä%¡X>ÀZÉUïdp¿o/uÕfé>ÄC©ñ)á6T~åÜ¡9>/ÚÑ«Wl£ÈÄëw{úupU®1ìU%0µõ\u00a8";
		Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, bytes);
		RijndaelManaged rijndaelManaged = null;
		rijndaelManaged = new RijndaelManaged();
		rijndaelManaged.KeySize = 256;
		rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes((int)Math.Round((double)rijndaelManaged.KeySize / 8.0));
		return rijndaelManaged;
	}

	public string DecompressScenarioObjectToXML_LZ()
	{
		if (RCMS.recyclableMemoryStreamManager_0 == null)
		{
			RCMS.recyclableMemoryStreamManager_0 = new RecyclableMemoryStreamManager();
		}
		using MemoryTributary memoryTributary = new MemoryTributary(Scenario_Compressed);
		if (RCMS.recyclableMemoryStreamManager_0 == null)
		{
			RCMS.recyclableMemoryStreamManager_0 = new RecyclableMemoryStreamManager();
		}
		using MemoryStream memoryStream = RCMS.recyclableMemoryStreamManager_0.GetStream();
		RijndaelManaged rijndaelManaged = smethod_0();
		byte[] array = new byte[4];
		memoryTributary.Read(array, 0, array.Length);
		byte[] array2 = new byte[BitConverter.ToInt32(array, 0) - 1 + 1];
		memoryTributary.Read(array2, 0, array2.Length);
		rijndaelManaged.IV = array2;
		ICryptoTransform transform = rijndaelManaged.CreateDecryptor(rijndaelManaged.Key, rijndaelManaged.IV);
		using (CryptoStream innerStream = new CryptoStream(memoryTributary, transform, CryptoStreamMode.Read))
		{
			using LZ4Stream lZ4Stream = new LZ4Stream(innerStream, LZ4StreamMode.Decompress, LZ4StreamFlags.IsolateInnerStream);
			lZ4Stream.CopyTo(memoryStream);
		}
		memoryStream.Seek(0L, SeekOrigin.Begin);
		byte[] byte_ = memoryStream.ToArray();
		byte_ = Misc.CleanUpXML_Headers(byte_);
		byte_ = Misc.CleanUpXML_IllegalCharacters(byte_);
		return Encoding.UTF8.GetString(byte_);
	}

	static ScenContainer()
	{
		Class72.smethod_20();
	}
}
