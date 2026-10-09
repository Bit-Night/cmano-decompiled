using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core.LoadSave;

[StandardModule]
public sealed class LoadSave
{
	private static BinaryFormatter binaryFormatter_0;

	private static FileStream uuoyybsjayD;

	public static void UnloadScenario(Scenario theScen)
	{
		if (theScen != null)
		{
			theScen.ThreadedOpsMustStop = true;
		}
	}

	public static void SaveScenario(Scenario theScen, Side theCurrentSide, string thePath, bool SBR, bool MarkAsCampaignCheckpoint = false)
	{
		try
		{
			if (theScen.Sides_ReadOnly.Length != 0)
			{
				theScen.GameVersion = GameGeneral.ProgramTitle;
				if (!SBR && theCurrentSide == null)
				{
					theScen.SetCurrentSide(theScen.Sides_ReadOnly[0]);
				}
				ScenContainer scenContainer = new ScenContainer(theScen);
				if (MarkAsCampaignCheckpoint)
				{
					scenContainer.IsCampaignCheckpoint = true;
				}
				scenContainer.SaveToFile(thePath);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101087", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static object smethod_0(string string_0, ref long long_0)
	{
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		object objectValue = RuntimeHelpers.GetObjectValue(new object());
		using (new FileStream(string_0, FileMode.Open, FileAccess.Read))
		{
			if (long_0 < uuoyybsjayD.Length)
			{
				uuoyybsjayD.Seek(long_0, SeekOrigin.Begin);
				objectValue = RuntimeHelpers.GetObjectValue(binaryFormatter.Deserialize(uuoyybsjayD));
				long_0 = uuoyybsjayD.Position;
			}
		}
		return objectValue;
	}

	private static void smethod_1(string string_0, object object_0)
	{
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		FileStream fileStream = new FileStream(string_0, FileMode.Create, FileAccess.Write);
		using (fileStream)
		{
			binaryFormatter.Serialize(fileStream, object_0);
		}
	}

	public static void SaveScenario_XML(string path, MemoryStream theScenarioAsStream)
	{
		try
		{
			FileStream fileStream = File.Create(path);
			fileStream.Write(theScenarioAsStream.ToArray(), 0, (int)theScenarioAsStream.Position);
			fileStream.Close();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static Scenario smethod_2(string string_0)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		new FileInfo(string_0);
		Scenario scenario = new Scenario(null);
		FileStream fileStream = new FileStream(string_0, FileMode.Open);
		scenario = (Scenario)new XmlSerializer(scenario.GetType()).Deserialize((Stream)fileStream);
		fileStream.Close();
		return scenario;
	}

	private static Scenario smethod_3(string string_0)
	{
		new Scenario(null);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		FileStream fileStream = new FileStream(string_0, FileMode.Open, FileAccess.Read);
		Scenario result = (Scenario)binaryFormatter.Deserialize(fileStream);
		fileStream.Close();
		fileStream = null;
		return result;
	}

	static LoadSave()
	{
		Class72.smethod_20();
	}
}
