using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;
using Nini.Config;

namespace Command_Core;

[StandardModule]
public sealed class Exporter_General
{
	public static IEventExporter[] EventExporters_Interactive;

	public static IEventExporter[] EventExporters_MonteCarlo;

	public static string CurrentInteractiveOutputPath;

	public static Dictionary<string, string> HeaderSummaries;

	public static string EventExporter_ConfigFileName => Path.Combine(GameGeneral.ConfigFolderPath, "EventExport.ini");

	public static string EventExporter_ResultsRoot_Interactive
	{
		get
		{
			if (FileExistsNative.FileExistsFast(EventExporter_ConfigFileName))
			{
				string text = new IniConfigSource(EventExporter_ConfigFileName).Configs["General"].Get("OutputRoot", string.Empty);
				if (Operators.CompareString(text, string.Empty, false) != 0 && !Directory.Exists(text))
				{
					Directory.CreateDirectory(text);
				}
				if (Operators.CompareString(text, string.Empty, false) != 0 && Misc.Dir_WritePermission(text))
				{
					return Path.Combine(text, "Analysis_Int");
				}
				return Path.Combine(GameGeneral.TopLevelWritablePath, "Analysis_Int");
			}
			return Path.Combine(GameGeneral.TopLevelWritablePath, "Analysis_Int");
		}
		set
		{
			IniConfigSource iniConfigSource = new IniConfigSource(EventExporter_ConfigFileName);
			iniConfigSource.Configs["General"].Set("OutputRoot", value);
			iniConfigSource.Save();
		}
	}

	public static bool EventExporter_PartitionOutputs
	{
		get
		{
			if (!FileExistsNative.FileExistsFast(EventExporter_ConfigFileName))
			{
				return false;
			}
			return new IniConfigSource(EventExporter_ConfigFileName).Configs["General"].GetBoolean("OutputSeparated", defaultValue: false);
		}
		set
		{
			IniConfigSource iniConfigSource = new IniConfigSource(EventExporter_ConfigFileName);
			iniConfigSource.Configs["General"].Set("OutputSeparated", value);
			iniConfigSource.Save();
		}
	}

	public static bool SaveEndStateXML
	{
		get
		{
			return new IniConfigSource(EventExporter_ConfigFileName).Configs["General"].GetBoolean("SaveEndStateXML", defaultValue: true);
		}
		set
		{
			IniConfigSource iniConfigSource = new IniConfigSource(EventExporter_ConfigFileName);
			iniConfigSource.Configs["General"].Set("SaveEndStateXML", value);
			iniConfigSource.Save();
		}
	}

	public static string EventExporter_OutputRoot_MonteCarlo => Path.Combine(GameGeneral.TopLevelWritablePath, "Analysis_MC");

	public static bool AutoStartExporter
	{
		get
		{
			if (!FileExistsNative.FileExistsFast(EventExporter_ConfigFileName))
			{
				return false;
			}
			IniConfigSource iniConfigSource = new IniConfigSource(EventExporter_ConfigFileName);
			if (iniConfigSource.Configs["General"].Get("AutoStartExporter") == null)
			{
				iniConfigSource.Configs["General"].Set("AutoStartExporter", true);
				return true;
			}
			return iniConfigSource.Configs["General"].GetBoolean("AutoStartExporter", defaultValue: false);
		}
		set
		{
			if (FileExistsNative.FileExistsFast(EventExporter_ConfigFileName))
			{
				new IniConfigSource(EventExporter_ConfigFileName).Configs["General"].Set("AutoStartExporter", value);
			}
		}
	}

	static Exporter_General()
	{
		Class72.smethod_20();
		EventExporters_Interactive = new IEventExporter[0];
		EventExporters_MonteCarlo = new IEventExporter[0];
		CurrentInteractiveOutputPath = string.Empty;
		HeaderSummaries = new Dictionary<string, string>();
	}

	internal static bool HasAnyActiveExporters()
	{
		if (EventExporters_MonteCarlo.Count() <= 0)
		{
			return EventExporters_Interactive.Count() > 0;
		}
		return true;
	}

	internal static string GetCurrentActiveOutputPath()
	{
		if (EventExporters_MonteCarlo.Count() > 0)
		{
			return EventExporter_OutputRoot_MonteCarlo;
		}
		if (EventExporters_Interactive.Count() > 0 && (EventExporters_Interactive.Count() > 1 || !(EventExporters_Interactive[0] is EventExporter_TacviewPipe)))
		{
			return CurrentInteractiveOutputPath;
		}
		return "";
	}

	internal static string PerIterationOutputSubfolder(Scenario theScen, DateTime theCurrentTime)
	{
		if (EventExporter_PartitionOutputs && theScen != null)
		{
			return Path.Combine(path2: ((!string.IsNullOrEmpty(theScen.Title)) ? Misc.ReplaceIllegalCharacters(theScen.Title, "_") : "Untitled") + " - " + theCurrentTime.ToString("MMMM dd, yyyy - HH.mm"), path1: EventExporter_ResultsRoot_Interactive);
		}
		return string.Empty;
	}

	public static void ClearEventExporter_Interactive()
	{
		if (EventExporters_Interactive.Count() != 0)
		{
			int num = EventExporters_Interactive.Count() - 1;
			for (int i = 0; i <= num; i++)
			{
				RemoveExporter(i);
			}
			ArrayExtensions.Clear(ref EventExporters_Interactive);
		}
	}

	internal static IEventExporter.EventExportOutputRate ParseOutputRateString(string theRate)
	{
		string text = theRate.ToUpper();
		uint num = <PrivateImplementationDetails>{A835D9A0-0EE4-445E-BC69-5FEB38C502A4}.ComputeStringHash(text);
		int result;
		int result2;
		int result3;
		int result4;
		int result5;
		int result6;
		int result7;
		int result8;
		if (num > 1066842209)
		{
			if (num > 1871351683)
			{
				if (num > 2925622362u)
				{
					if (num > 3687172845u)
					{
						if (num != 3923226626u)
						{
							if (num != 4183254760u)
							{
								result = -1;
							}
							else
							{
								if (Operators.CompareString(text, "5MINUTE", false) == 0)
								{
									goto IL_031c;
								}
								result = -1;
							}
						}
						else
						{
							if (Operators.CompareString(text, "30MINUTE", false) == 0)
							{
								goto IL_014f;
							}
							result = -1;
						}
						goto IL_03a3;
					}
					if (num != 3302857376u)
					{
						if (num != 3687172845u)
						{
							result = -1;
							goto IL_03a3;
						}
						if (Operators.CompareString(text, "5SECONDS", false) == 0)
						{
							result2 = 3;
							goto IL_017f;
						}
					}
					else if (Operators.CompareString(text, "15SECONDS", false) == 0)
					{
						result3 = 4;
						goto IL_0197;
					}
				}
				else if (num != 2392453434u)
				{
					if (num != 2857881683u)
					{
						if (num != 2925622362u)
						{
							result = -1;
							goto IL_03a3;
						}
						if (Operators.CompareString(text, "24HOURS", false) == 0)
						{
							result4 = 13;
							goto IL_02dc;
						}
					}
					else if (Operators.CompareString(text, "15MINUTE", false) == 0)
					{
						result5 = 8;
						goto IL_0241;
					}
				}
				else if (Operators.CompareString(text, "2SECONDS", false) == 0)
				{
					result6 = 2;
					goto IL_0335;
				}
				goto IL_03a2;
			}
			if (num > 1739802530)
			{
				if (num == 1757355699)
				{
					if (Operators.CompareString(text, "15SECOND", false) == 0)
					{
						result3 = 4;
						goto IL_0197;
					}
					goto IL_03a2;
				}
				if (num != 1856484488)
				{
					if (num != 1871351683)
					{
						result = -1;
					}
					else
					{
						if (Operators.CompareString(text, "30MINUTES", false) == 0)
						{
							goto IL_014f;
						}
						result = -1;
					}
				}
				else
				{
					if (Operators.CompareString(text, "MATCHSIMSPEED", false) == 0)
					{
						return IEventExporter.EventExportOutputRate.SimSpeed;
					}
					result = -1;
				}
			}
			else
			{
				if (num != 1374681224)
				{
					if (num != 1410650412)
					{
						if (num != 1739802530)
						{
							result = -1;
							goto IL_03a3;
						}
						if (Operators.CompareString(text, "30SECOND", false) == 0)
						{
							result7 = 5;
							goto IL_039f;
						}
					}
					else if (Operators.CompareString(text, "5SECOND", false) == 0)
					{
						result2 = 3;
						goto IL_017f;
					}
					goto IL_03a2;
				}
				if (Operators.CompareString(text, "1SECOND", false) == 0)
				{
					return IEventExporter.EventExportOutputRate.Secondx1;
				}
				result = -1;
			}
		}
		else if (num <= 675049472)
		{
			if (num <= 483558130)
			{
				if (num != 12671533)
				{
					if (num != 465381052)
					{
						if (num != 483558130)
						{
							result = -1;
						}
						else
						{
							if (Operators.CompareString(text, "1HOUR", false) == 0)
							{
								return IEventExporter.EventExportOutputRate.Hourx1;
							}
							result = -1;
						}
						goto IL_03a3;
					}
					if (Operators.CompareString(text, "1MINUTE", false) == 0)
					{
						return IEventExporter.EventExportOutputRate.Minutex1;
					}
				}
				else if (Operators.CompareString(text, "24HOUR", false) == 0)
				{
					result4 = 13;
					goto IL_02dc;
				}
				goto IL_03a2;
			}
			if (num != 549638592)
			{
				if (num != 648806163)
				{
					if (num == 675049472)
					{
						if (Operators.CompareString(text, "15MINUTES", false) == 0)
						{
							result5 = 8;
							goto IL_0241;
						}
						goto IL_03a2;
					}
					result = -1;
				}
				else
				{
					if (Operators.CompareString(text, "6HOUR", false) == 0)
					{
						goto IL_026f;
					}
					result = -1;
				}
			}
			else
			{
				if (Operators.CompareString(text, "6HOURS", false) == 0)
				{
					goto IL_026f;
				}
				result = -1;
			}
		}
		else
		{
			if (num <= 894325201)
			{
				if (num != 809123939)
				{
					if (num != 881003992)
					{
						if (num != 894325201)
						{
							result = -1;
						}
						else
						{
							if (Operators.CompareString(text, "12HOURS", false) == 0)
							{
								result8 = 12;
								goto IL_038d;
							}
							result = -1;
						}
						goto IL_03a3;
					}
					if (Operators.CompareString(text, "12HOUR", false) == 0)
					{
						result8 = 12;
						goto IL_038d;
					}
				}
				else if (Operators.CompareString(text, "30SECONDS", false) == 0)
				{
					result7 = 5;
					goto IL_039f;
				}
				goto IL_03a2;
			}
			if (num != 992649378)
			{
				if (num != 1017149005)
				{
					if (num != 1066842209)
					{
						result = -1;
					}
					else
					{
						if (Operators.CompareString(text, "5MINUTES", false) == 0)
						{
							goto IL_031c;
						}
						result = -1;
					}
				}
				else
				{
					if (Operators.CompareString(text, "2SECOND", false) == 0)
					{
						result6 = 2;
						goto IL_0335;
					}
					result = -1;
				}
			}
			else
			{
				if (Operators.CompareString(text, "CONTINUOUS", false) == 0)
				{
					return IEventExporter.EventExportOutputRate.Continuous;
				}
				result = -1;
			}
		}
		goto IL_03a3;
		IL_03a2:
		result = -1;
		goto IL_03a3;
		IL_02dc:
		return (IEventExporter.EventExportOutputRate)result4;
		IL_026f:
		return IEventExporter.EventExportOutputRate.Hourx6;
		IL_014f:
		return IEventExporter.EventExportOutputRate.const_10;
		IL_03a3:
		return (IEventExporter.EventExportOutputRate)result;
		IL_017f:
		return (IEventExporter.EventExportOutputRate)result2;
		IL_039f:
		return (IEventExporter.EventExportOutputRate)result7;
		IL_0335:
		return (IEventExporter.EventExportOutputRate)result6;
		IL_0241:
		return (IEventExporter.EventExportOutputRate)result5;
		IL_031c:
		return IEventExporter.EventExportOutputRate.Minutex5;
		IL_0197:
		return (IEventExporter.EventExportOutputRate)result3;
		IL_038d:
		return (IEventExporter.EventExportOutputRate)result8;
	}

	public static void SetEventOutputRate(IEventExporter.ExportedEventType eventType, IEventExporter.EventExportOutputRate rate)
	{
		IEventExporter[] eventExporters_Interactive = EventExporters_Interactive;
		checked
		{
			for (int i = 0; i < eventExporters_Interactive.Length; i++)
			{
				eventExporters_Interactive[i].SetOutputRate(eventType, rate);
			}
			IEventExporter[] eventExporters_MonteCarlo = EventExporters_MonteCarlo;
			for (int j = 0; j < eventExporters_MonteCarlo.Length; j++)
			{
				eventExporters_MonteCarlo[j].SetOutputRate(eventType, rate);
			}
		}
	}

	public static void StartEventExporters_Interactive(Scenario theScen, bool HotAdjunctionMode = false)
	{
		try
		{
			if (!HotAdjunctionMode)
			{
				ClearEventExporter_Interactive();
			}
			if (!FileExistsNative.FileExistsFast(EventExporter_ConfigFileName))
			{
				return;
			}
			if (theScen != null)
			{
				CurrentInteractiveOutputPath = PerIterationOutputSubfolder(theScen, DateTime.Now);
			}
			else
			{
				CurrentInteractiveOutputPath = EventExporter_ResultsRoot_Interactive;
			}
			if (string.IsNullOrEmpty(CurrentInteractiveOutputPath))
			{
				CurrentInteractiveOutputPath = EventExporter_ResultsRoot_Interactive;
			}
			if (!Directory.Exists(CurrentInteractiveOutputPath))
			{
				Directory.CreateDirectory(CurrentInteractiveOutputPath);
			}
			if (HeaderSummaries.Count == 0)
			{
				smethod_1();
			}
			Dictionary<IEventExporter.EventExporterType, IEventExporter.EventExporterType> dictionary = new Dictionary<IEventExporter.EventExporterType, IEventExporter.EventExporterType>();
			if (!FileExistsNative.FileExistsFast(EventExporter_ConfigFileName))
			{
				return;
			}
			string[] array = new IniConfigSource(EventExporter_ConfigFileName).Configs["General"].Get("ActiveExporter").ToString().Split(Conversions.ToCharArrayRankOne(","));
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				string text = array[i].Trim();
				if (Operators.CompareString(text, "Tacview2x", false) == 0 && !dictionary.ContainsKey(IEventExporter.EventExporterType.const_5))
				{
					dictionary.Add(IEventExporter.EventExporterType.const_5, IEventExporter.EventExporterType.const_5);
				}
			}
			Dictionary<IEventExporter.EventExporterType, int> dictionary2 = new Dictionary<IEventExporter.EventExporterType, int>();
			IEventExporter[] eventExporters_Interactive = EventExporters_Interactive;
			foreach (IEventExporter eventExporter in eventExporters_Interactive)
			{
				dictionary2.Add(eventExporter.ExporterType, 0);
			}
			foreach (KeyValuePair<IEventExporter.EventExporterType, IEventExporter.EventExporterType> item in dictionary)
			{
				if (!dictionary2.ContainsKey(item.Key))
				{
					smethod_0(item.Key, IEventExporter.EventExporterRunMode.Interactive, CurrentInteractiveOutputPath);
				}
			}
			if (EventExporters_Interactive.Count() <= 0)
			{
				return;
			}
			for (int k = EventExporters_Interactive.Count() - 1; k >= 0; k += -1)
			{
				if (!dictionary.ContainsKey(EventExporters_Interactive.ElementAt(k).ExporterType))
				{
					RemoveExporter(k);
				}
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

	public static void RemoveExporter(int index)
	{
		if (index >= EventExporters_Interactive.Count() - 1)
		{
			EventExporters_Interactive.ElementAt(index);
			ArrayExtensions.RemoveAT(ref EventExporters_Interactive, index);
		}
	}

	private static void smethod_0(IEventExporter.EventExporterType eventExporterType_0, IEventExporter.EventExporterRunMode eventExporterRunMode_0, string string_0)
	{
		switch (eventExporterType_0)
		{
		case IEventExporter.EventExporterType.TacviewPipe:
			ArrayExtensions.Add(ref EventExporters_Interactive, new EventExporter_TacviewPipe(eventExporterRunMode_0));
			break;
		case IEventExporter.EventExporterType.const_5:
			ArrayExtensions.Add(ref EventExporters_Interactive, new EventExporter_Tacview2x(eventExporterRunMode_0, string_0));
			break;
		}
	}

	public static void StartEventExporters_MonteCarlo()
	{
		if (HeaderSummaries.Count == 0)
		{
			smethod_1();
		}
		if (!FileExistsNative.FileExistsFast(EventExporter_ConfigFileName))
		{
			return;
		}
		string[] array = new IniConfigSource(EventExporter_ConfigFileName).Configs["General"].Get("ActiveExporter").ToString().Split(Conversions.ToCharArrayRankOne(","));
		for (int i = 0; i < array.Length; i = checked(i + 1))
		{
			string text = array[i].Trim();
			if (Operators.CompareString(text, "Tacview2x", false) == 0)
			{
				ArrayExtensions.Add(ref EventExporters_MonteCarlo, new EventExporter_Tacview2x(IEventExporter.EventExporterRunMode.NonInteractive, EventExporter_OutputRoot_MonteCarlo));
			}
		}
	}

	private static void smethod_1()
	{
	}
}
