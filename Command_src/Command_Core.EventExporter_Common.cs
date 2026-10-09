using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;
using Nini.Config;

namespace Command_Core;

public sealed class EventExporter_Common
{
	private ConcurrentDictionary<Module_Unit.Unit, double> concurrentDictionary_0;

	private ConcurrentDictionary<string, UnitExporterState> concurrentDictionary_1;

	private IEventExporter ieventExporter_0;

	public Dictionary<string, float> EligibleUnitWithExportLocationFrequency;

	[CompilerGenerated]
	private bool bool_0;

	[CompilerGenerated]
	private float float_0;

	[CompilerGenerated]
	private float float_1;

	[CompilerGenerated]
	private float float_2;

	[CompilerGenerated]
	private float float_3;

	[CompilerGenerated]
	private float float_4;

	[CompilerGenerated]
	private float float_5;

	[CompilerGenerated]
	private float float_6;

	[CompilerGenerated]
	private float float_7;

	[CompilerGenerated]
	private float float_8;

	[CompilerGenerated]
	private float float_9;

	public bool UseCustomUnitExportFrequency
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public float SpeedBandFrequency0To20
	{
		[CompilerGenerated]
		get
		{
			return float_0;
		}
		[CompilerGenerated]
		set
		{
			float_0 = value;
		}
	}

	public float SpeedBandFrequency20To40
	{
		[CompilerGenerated]
		get
		{
			return float_1;
		}
		[CompilerGenerated]
		set
		{
			float_1 = value;
		}
	}

	public float SpeedBandFrequency40To80
	{
		[CompilerGenerated]
		get
		{
			return float_2;
		}
		[CompilerGenerated]
		set
		{
			float_2 = value;
		}
	}

	public float SpeedBandFrequency80To160
	{
		[CompilerGenerated]
		get
		{
			return float_3;
		}
		[CompilerGenerated]
		set
		{
			float_3 = value;
		}
	}

	public float SpeedBandFrequency160To320
	{
		[CompilerGenerated]
		get
		{
			return float_4;
		}
		[CompilerGenerated]
		set
		{
			float_4 = value;
		}
	}

	public float SpeedBandFrequency320To640
	{
		[CompilerGenerated]
		get
		{
			return float_5;
		}
		[CompilerGenerated]
		set
		{
			float_5 = value;
		}
	}

	public float SpeedBandFrequency640To1280
	{
		[CompilerGenerated]
		get
		{
			return float_6;
		}
		[CompilerGenerated]
		set
		{
			float_6 = value;
		}
	}

	public float SpeedBandFrequency1280To2560
	{
		[CompilerGenerated]
		get
		{
			return float_7;
		}
		[CompilerGenerated]
		set
		{
			float_7 = value;
		}
	}

	public float SpeedBandFrequencyOver2560
	{
		[CompilerGenerated]
		get
		{
			return float_8;
		}
		[CompilerGenerated]
		set
		{
			float_8 = value;
		}
	}

	public float SpeedBandFrequencyDynamic
	{
		[CompilerGenerated]
		get
		{
			return float_9;
		}
		[CompilerGenerated]
		set
		{
			float_9 = value;
		}
	}

	public EventExporter_Common(IEventExporter Exporter)
	{
		concurrentDictionary_0 = new ConcurrentDictionary<Module_Unit.Unit, double>();
		concurrentDictionary_1 = new ConcurrentDictionary<string, UnitExporterState>();
		EligibleUnitWithExportLocationFrequency = new Dictionary<string, float>();
		ieventExporter_0 = Exporter;
	}

	public void LoadPerUnitExportSettings()
	{
		string path = Path.Combine(GameGeneral.ConfigFolderPath, "ExportUnitLocationFrequencySettings.csv");
		if (!File.Exists(path))
		{
			FileStream fileStream = File.Create(path);
			byte[] bytes = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true).GetBytes("Unit's GUID,Override");
			fileStream.Write(bytes, 0, bytes.Length);
			fileStream.Close();
			return;
		}
		string[] source = File.ReadAllLines(path);
		foreach (string item in source.Skip(1))
		{
			string[] array = item.Split(new char[1] { ',' });
			if (!EligibleUnitWithExportLocationFrequency.ContainsKey(array[0]))
			{
				EligibleUnitWithExportLocationFrequency.Add(array[0], Conversions.ToSingle(array[1]));
			}
		}
	}

	internal string GetExporterTypeAsCategoryString()
	{
		return ieventExporter_0.ExporterType switch
		{
			IEventExporter.EventExporterType.XMLFile => "XML Settings", 
			IEventExporter.EventExporterType.CSVFile => "CSV Settings", 
			IEventExporter.EventExporterType.MSAccess => "MSAccess Settings", 
			IEventExporter.EventExporterType.const_4 => "Tacview Settings", 
			IEventExporter.EventExporterType.const_5 => "Tacview Settings", 
			IEventExporter.EventExporterType.TacviewRealtime => "", 
			IEventExporter.EventExporterType.const_7 => "SQLServer Settings", 
			IEventExporter.EventExporterType.SQLite => "SQLite Settings", 
			IEventExporter.EventExporterType.TacviewPipe => "", 
			IEventExporter.EventExporterType.SIMDIS => "", 
			_ => "ERROR", 
		};
	}

	public void GetCommonConfig(string Exporter)
	{
		if (!string.IsNullOrEmpty(Exporter))
		{
			IniConfigSource iniConfigSource;
			if (!File.Exists(Exporter_General.EventExporter_ConfigFileName))
			{
				iniConfigSource = new IniConfigSource();
				iniConfigSource.Save(Exporter_General.EventExporter_ConfigFileName);
			}
			else
			{
				iniConfigSource = new IniConfigSource(Exporter_General.EventExporter_ConfigFileName);
			}
			iniConfigSource.AutoSave = true;
			if (iniConfigSource.Configs[Exporter] == null)
			{
				iniConfigSource.AddConfig(Exporter);
			}
			GetCommonConfig(iniConfigSource.Configs[Exporter]);
		}
	}

	public void GetCommonConfig(IConfig coll)
	{
		try
		{
			UseCustomUnitExportFrequency = Conversions.ToBoolean(coll.Get("UseCustomUnitExportFrequency"));
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			coll.Set("UseCustomUnitExportFrequency", false);
			ProjectData.ClearProjectError();
		}
		try
		{
			SpeedBandFrequency0To20 = coll.GetFloat("SpeedBandFrequency0To20");
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			coll.Set("SpeedBandFrequency0To20", 0);
			ProjectData.ClearProjectError();
		}
		try
		{
			SpeedBandFrequency20To40 = coll.GetFloat("SpeedBandFrequency20To40");
		}
		catch (Exception projectError3)
		{
			ProjectData.SetProjectError(projectError3);
			coll.Set("SpeedBandFrequency20To40", 0);
			ProjectData.ClearProjectError();
		}
		try
		{
			SpeedBandFrequency40To80 = coll.GetFloat("SpeedBandFrequency40To80");
		}
		catch (Exception projectError4)
		{
			ProjectData.SetProjectError(projectError4);
			coll.Set("SpeedBandFrequency40To80", 0);
			ProjectData.ClearProjectError();
		}
		try
		{
			SpeedBandFrequency80To160 = coll.GetFloat("SpeedBandFrequency80To160");
		}
		catch (Exception projectError5)
		{
			ProjectData.SetProjectError(projectError5);
			coll.Set("SpeedBandFrequency80To160", 0);
			ProjectData.ClearProjectError();
		}
		try
		{
			SpeedBandFrequency160To320 = coll.GetFloat("SpeedBandFrequency160To320");
		}
		catch (Exception projectError6)
		{
			ProjectData.SetProjectError(projectError6);
			coll.Set("SpeedBandFrequency160To320", 0);
			ProjectData.ClearProjectError();
		}
		try
		{
			SpeedBandFrequency320To640 = coll.GetFloat("SpeedBandFrequency320To640");
		}
		catch (Exception projectError7)
		{
			ProjectData.SetProjectError(projectError7);
			coll.Set("SpeedBandFrequency320To640", 0);
			ProjectData.ClearProjectError();
		}
		try
		{
			SpeedBandFrequency640To1280 = coll.GetFloat("SpeedBandFrequency640To1280");
		}
		catch (Exception projectError8)
		{
			ProjectData.SetProjectError(projectError8);
			coll.Set("SpeedBandFrequency640To1280", 0);
			ProjectData.ClearProjectError();
		}
		try
		{
			SpeedBandFrequency1280To2560 = coll.GetFloat("SpeedBandFrequency1280To2560");
		}
		catch (Exception projectError9)
		{
			ProjectData.SetProjectError(projectError9);
			coll.Set("SpeedBandFrequency1280To2560", 0);
			ProjectData.ClearProjectError();
		}
		try
		{
			SpeedBandFrequencyOver2560 = coll.GetFloat("SpeedBandFrequencyOver2560");
		}
		catch (Exception projectError10)
		{
			ProjectData.SetProjectError(projectError10);
			coll.Set("SpeedBandFrequencyOver2560", 0);
			ProjectData.ClearProjectError();
		}
		try
		{
			SpeedBandFrequencyDynamic = coll.GetFloat("SpeedBandFrequencyDynamic");
		}
		catch (Exception projectError11)
		{
			ProjectData.SetProjectError(projectError11);
			coll.Set("SpeedBandFrequencyDynamic", 0);
			ProjectData.ClearProjectError();
		}
	}

	public void ApplyLastExportLocation(Module_Unit.Unit Unit)
	{
		try
		{
			if (concurrentDictionary_1.ContainsKey(Unit.ObjectID))
			{
				concurrentDictionary_1[Unit.ObjectID] = new UnitExporterState(Unit);
			}
			else
			{
				concurrentDictionary_1.TryAdd(Unit.ObjectID, new UnitExporterState(Unit));
			}
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

	internal bool PreviousLocationExportIsIdentical(Scenario Scen, Module_Unit.Unit Unit)
	{
		if (!concurrentDictionary_1.ContainsKey(Unit.ObjectID))
		{
			return false;
		}
		if (concurrentDictionary_1[Unit.ObjectID].IsEqual(Unit))
		{
			return true;
		}
		return false;
	}

	internal bool LocationExportPossibleThisTick(Scenario Scen, Module_Unit.Unit Unit)
	{
		if (ieventExporter_0 != null && ieventExporter_0.RequiresHeartbeatForStaticUnits)
		{
			return true;
		}
		if (concurrentDictionary_1.ContainsKey(Unit.ObjectID))
		{
			if (concurrentDictionary_1[Unit.ObjectID].IsEqual(Unit))
			{
				return false;
			}
			if (UseCustomUnitExportFrequency)
			{
				float num = 0f;
				num = ((EligibleUnitWithExportLocationFrequency.Count <= 0 || !EligibleUnitWithExportLocationFrequency.ContainsKey(Unit.ObjectID)) ? GetLocationExportFrequencyFromUnitSpeed(Unit) : ((EligibleUnitWithExportLocationFrequency[Unit.ObjectID] != 0f) ? EligibleUnitWithExportLocationFrequency[Unit.ObjectID] : GetLocationExportFrequencyFromUnitSpeed(Unit)));
				double? locationTimeElapsedSinceUpdate = GetLocationTimeElapsedSinceUpdate(Scen, Unit);
				double num2 = num;
				if ((locationTimeElapsedSinceUpdate.HasValue ? new bool?(locationTimeElapsedSinceUpdate.GetValueOrDefault() < num2) : ((bool?)null)) == true)
				{
					return false;
				}
				ApplyLocationFrequencyTimestamp(Scen.Time, Unit);
				return true;
			}
			return true;
		}
		return true;
	}

	public void ApplyLocationFrequencyTimestamp(DateTime Timestamp, Module_Unit.Unit Unit)
	{
		double totalMilliseconds = (Timestamp - new DateTime(1970, 1, 1)).TotalMilliseconds;
		if (concurrentDictionary_0.ContainsKey(Unit))
		{
			concurrentDictionary_0[Unit] = totalMilliseconds;
		}
		else
		{
			concurrentDictionary_0.TryAdd(Unit, totalMilliseconds);
		}
	}

	internal double? GetLocationTimeElapsedSinceUpdate(Scenario Scen, Module_Unit.Unit Unit)
	{
		if (!concurrentDictionary_0.ContainsKey(Unit))
		{
			ApplyLocationFrequencyTimestamp(Scen.Time, Unit);
		}
		return (Scen.Time - new DateTime(1970, 1, 1)).TotalMilliseconds - concurrentDictionary_0[Unit];
	}

	public float GetLocationExportFrequencyFromUnitSpeed(Module_Unit.Unit Unit)
	{
		if (Unit.CurrentSpeed == 0f)
		{
			return 0f;
		}
		if (SpeedBandFrequencyDynamic != 0f)
		{
			return SpeedBandFrequencyDynamic / Unit.CurrentSpeed * 1000f;
		}
		if (Unit.CurrentSpeed > 2560f)
		{
			return SpeedBandFrequencyOver2560;
		}
		if (Unit.CurrentSpeed >= 1280f)
		{
			return SpeedBandFrequency1280To2560;
		}
		if (Unit.CurrentSpeed >= 640f)
		{
			return SpeedBandFrequency640To1280;
		}
		if (Unit.CurrentSpeed >= 320f)
		{
			return SpeedBandFrequency320To640;
		}
		if (Unit.CurrentSpeed >= 160f)
		{
			return SpeedBandFrequency160To320;
		}
		if (Unit.CurrentSpeed >= 80f)
		{
			return SpeedBandFrequency80To160;
		}
		if (Unit.CurrentSpeed >= 40f)
		{
			return SpeedBandFrequency40To80;
		}
		if (Unit.CurrentSpeed >= 20f)
		{
			return SpeedBandFrequency20To40;
		}
		return SpeedBandFrequency0To20;
	}

	static EventExporter_Common()
	{
		Class72.smethod_20();
	}
}
