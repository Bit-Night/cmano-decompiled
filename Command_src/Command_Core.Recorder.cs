using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Recorder
{
	public static bool SnapshotProcessingIsInProgress;

	public static string VCR_ScratchFilePath => GameGeneral.TempPath;

	[SpecialName]
	private static string smethod_0()
	{
		return Path.Combine(GameGeneral.TopLevelWritablePath, "Recordings" + Conversions.ToString(Path.DirectorySeparatorChar));
	}

	public static RecorderTape CreateNewTape(string CustomSavePath, string CustomName)
	{
		RecorderTape result;
		try
		{
			string text = (string.IsNullOrEmpty(CustomName) ? Guid.NewGuid().ToString() : CustomName);
			RecorderTape recorderTape = new RecorderTape();
			if (string.IsNullOrEmpty(CustomSavePath))
			{
				File.Copy(smethod_0() + "Sample.rec", smethod_0() + text + ".rec");
				recorderTape.FileName = smethod_0() + text + ".rec";
			}
			else
			{
				File.Copy(smethod_0() + "Sample.rec", Path.Combine(CustomSavePath, text) + ".rec");
				recorderTape.FileName = Path.Combine(CustomSavePath, text) + ".rec";
			}
			recorderTape.CreationTime = DateAndTime.Now;
			result = recorderTape;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101125", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new RecorderTape();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static string FilenameOfMostRecentTape()
	{
		IEnumerable<string> source = from theF in Directory.GetFiles(smethod_0())
			select (theF) into theF
			where Operators.CompareString(theF, "Sample.rec", false) != 0
			orderby Directory.GetLastWriteTimeUtc(theF) descending
			select theF;
		if (source.Count() > 0)
		{
			return source.ElementAtOrDefault(0);
		}
		return null;
	}

	public static RecorderTape GetTape(string theFileName)
	{
		RecorderTape result;
		try
		{
			RecorderTape recorderTape = new RecorderTape();
			recorderTape.FileName = theFileName;
			string connectionString = "Data Source=" + theFileName + ";Version=3";
			SQLiteConnection theConn = new SQLiteConnection(connectionString);
			SQLiteDataReader sQLiteDataReader = new SQLiteHelper(theConn).ExecuteReader("SELECT ID, ScenarioTime from Snapshots order by ID ASC");
			while (sQLiteDataReader.Read())
			{
				recorderTape.SnapshotList.Add((Conversions.ToInteger(sQLiteDataReader["ID"]), DateTime.FromBinary(Conversions.ToLong(sQLiteDataReader["ScenarioTime"]))));
			}
			sQLiteDataReader.Close();
			result = recorderTape;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101126", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new RecorderTape();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	static Recorder()
	{
		Class72.smethod_20();
	}
}
