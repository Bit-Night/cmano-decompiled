using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class RecorderTape
{
	public string FileName;

	public DateTime CreationTime;

	public Queue<(DateTime, string)> UnsavedSnapshots;

	public List<(int, DateTime)> SnapshotList;

	public long LastSnapshotDateTime;

	public RecorderTape()
	{
		UnsavedSnapshots = new Queue<(DateTime, string)>();
		SnapshotList = new List<(int, DateTime)>();
	}

	public void QueueSnapshotToSave(DateTime ScenarioTime, MemoryStream theSnapshot, bool closeStream = true)
	{
		LastSnapshotDateTime = ScenarioTime.ToBinary();
		method_0(ScenarioTime, theSnapshot);
		if (closeStream)
		{
			theSnapshot.Dispose();
			theSnapshot = null;
		}
		if (UnsavedSnapshots.Count > 0 && !Recorder.SnapshotProcessingIsInProgress)
		{
			ProcessUnsavedSnapshots();
		}
	}

	private void method_0(DateTime dateTime_0, Stream stream_0)
	{
		string text = Guid.NewGuid().ToString();
		ScenContainer scenContainer = new ScenContainer();
		scenContainer.BuildNumber = "v1.10 - Build 1900.20";
		scenContainer.Version = GameGeneral.ProgramTitle;
		scenContainer.AttachAndCompressScenarioObject(stream_0);
		if (!Directory.Exists(Recorder.VCR_ScratchFilePath))
		{
			Directory.CreateDirectory(Recorder.VCR_ScratchFilePath);
		}
		scenContainer.SaveToFile(Recorder.VCR_ScratchFilePath + "\\" + text);
		UnsavedSnapshots.Enqueue((dateTime_0, text));
	}

	private string method_1(string string_0)
	{
		return ScenContainer.LoadFromFile(Recorder.VCR_ScratchFilePath + "\\" + string_0).ToString();
	}

	private void method_2(string string_0)
	{
		File.Delete(Recorder.VCR_ScratchFilePath + "\\" + string_0);
	}

	public void ProcessUnsavedSnapshots()
	{
		Recorder.SnapshotProcessingIsInProgress = true;
		while (UnsavedSnapshots.Count > 0)
		{
			(DateTime, string) tuple = UnsavedSnapshots.Dequeue();
			var (dateTime_, _) = tuple;
			string string_;
			try
			{
				string_ = method_1(tuple.Item2);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200100", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				break;
			}
			method_3(dateTime_, string_);
			method_2(tuple.Item2);
			tuple = default((DateTime, string));
			string_ = null;
		}
		Recorder.SnapshotProcessingIsInProgress = false;
	}

	private void method_3(DateTime dateTime_0, string string_0)
	{
		string connectionString = "Data Source=" + FileName + ";Version=3";
		SQLiteConnection sQLiteConnection = new SQLiteConnection(connectionString);
		sQLiteConnection.Open();
		SQLiteCommand sQLiteCommand = new SQLiteCommand(sQLiteConnection);
		sQLiteCommand.CommandText = "INSERT INTO Snapshots (ScenarioTime, ScenarioObject) Values (" + dateTime_0.ToBinary() + ", @theString)";
		sQLiteCommand.Parameters.AddWithValue("@theString", string_0);
		sQLiteCommand.ExecuteNonQuery();
		sQLiteConnection.Close();
	}

	public Scenario GetSnapshot(int SnapshotID, Action<double> PercentageComplete)
	{
		if (PercentageComplete == null)
		{
			PercentageComplete = [SpecialName] (double d) =>
			{
			};
		}
		string connectionString = "Data Source=" + FileName + ";Version=3";
		SQLiteConnection theConn = new SQLiteConnection(connectionString);
		ScenContainer scenContainer = ScenContainer.FromXML(new SQLiteHelper(theConn).ExecuteScalar("SELECT ScenarioObject from Snapshots where ID = " + Conversions.ToString(SnapshotID)));
		string ErrorFeedback = "";
		return scenContainer.GetScenarioObject(ref ErrorFeedback, PercentageComplete, ForceDeepRebuild: false);
	}

	static RecorderTape()
	{
		Class72.smethod_20();
	}
}
