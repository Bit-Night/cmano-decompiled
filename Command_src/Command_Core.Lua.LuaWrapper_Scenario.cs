using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[DoNotPrune]
[DoNotPruneType]
[DoNotObfuscateType]
public sealed class LuaWrapper_Scenario
{
	private Scenario scenario_0;

	private byte byte_0;

	private byte byte_1;

	[DoNotPrune]
	public object fields
	{
		get
		{
			Type type = GetType();
			int num = 0;
			PropertyInfo[] properties = type.GetProperties();
			MethodInfo[] methods = type.GetMethods();
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			PropertyInfo[] array = properties;
			foreach (PropertyInfo propertyInfo in array)
			{
				if (propertyInfo.Name.StartsWith("__") || propertyInfo.Name.StartsWith("fields"))
				{
					continue;
				}
				string text = "";
				bool flag = false;
				if (propertyInfo.MemberType == MemberTypes.Method)
				{
					text = ":";
				}
				else if (propertyInfo.MemberType == MemberTypes.Property)
				{
					text = ".";
				}
				MethodInfo[] array2 = methods;
				foreach (MethodInfo obj in array2)
				{
					string text2 = "set_" + propertyInfo.Name;
					if (Operators.CompareString(obj.Name, text2, false) == 0)
					{
						flag = true;
					}
				}
				num++;
				dictionary.Add("property_" + num, text + propertyInfo.Name + " , " + propertyInfo.PropertyType.Name + " , " + flag + " , " + propertyInfo.CanRead);
			}
			num = 0;
			MethodInfo[] array3 = methods;
			foreach (MethodInfo methodInfo in array3)
			{
				if (!methodInfo.Name.StartsWith("get_") && !methodInfo.Name.StartsWith("set_") && !methodInfo.Name.StartsWith("ToString") && !methodInfo.IsHideBySig)
				{
					string text3 = "";
					if (methodInfo.MemberType == MemberTypes.Method)
					{
						text3 = ":";
					}
					else if (methodInfo.MemberType == MemberTypes.Property)
					{
						text3 = ".";
					}
					num++;
					dictionary.Add("method_" + num, text3 + methodInfo.Name + " , " + methodInfo.ReturnType.ToString());
				}
			}
			if (dictionary.Count == 0)
			{
				return null;
			}
			LuaUtility.FromDict(dictionary, luaTable);
			return luaTable;
		}
	}

	[DoNotPrune]
	public object __obj => scenario_0;

	[DoNotPrune]
	public string guid => scenario_0.ObjectID;

	[DoNotPrune]
	public string TimelineID => scenario_0.TimelineID;

	[DoNotPrune]
	public string Duration => scenario_0.Duration.ToString();

	[DoNotPrune]
	public long DurationNum => (long)Math.Round(scenario_0.Duration.TotalSeconds);

	[DoNotPrune]
	public string StartTime => scenario_0.StartTime.ToString();

	[DoNotPrune]
	public long StartTimeNum => (long)Math.Round((scenario_0.StartTime - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds);

	[DoNotPrune]
	public string CurrentTime => scenario_0.Time.ToString();

	[DoNotPrune]
	public long CurrentTimeNum => (long)Math.Round((scenario_0.Time - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds);

	[DoNotPrune]
	public string DBUsed
	{
		get
		{
			string dBUsed = scenario_0.DBUsed;
			DBOps.DBFileCheckResult theResult = DBOps.DBFileCheckResult.Undefined;
			DBRecord dBRecordByHash = DBOps.GetDBRecordByHash(dBUsed, ref theResult);
			if (dBRecordByHash == null)
			{
				return scenario_0.DBUsed;
			}
			return dBRecordByHash.FileName;
		}
	}

	[DoNotPrune]
	public short Complexity => scenario_0.Meta_Complexity;

	[DoNotPrune]
	public short Difficulty => scenario_0.Meta_Difficulty;

	[DoNotPrune]
	public string ScenSetting => scenario_0.Meta_ScenSetting;

	[DoNotPrune]
	public int ScenDate => (short)scenario_0.StartTime.Year;

	[DoNotPrune]
	public string Title
	{
		get
		{
			return scenario_0.Title;
		}
		set
		{
			scenario_0.Title = value;
		}
	}

	[DoNotPrune]
	public string ContentTag => scenario_0.ContentTag;

	[DoNotPrune]
	public string CampaignID
	{
		get
		{
			if (!string.IsNullOrEmpty(scenario_0.CampaignID))
			{
				return scenario_0.CampaignID;
			}
			return null;
		}
	}

	[DoNotPrune]
	public string CampaignSessionID
	{
		get
		{
			if (!string.IsNullOrEmpty(scenario_0.CampaignSessionID))
			{
				return scenario_0.CampaignSessionID;
			}
			return null;
		}
	}

	[DoNotPrune]
	public int CampaignScore
	{
		get
		{
			if (!string.IsNullOrEmpty(scenario_0.CampaignID))
			{
				return scenario_0.CampaignScore;
			}
			return 0;
		}
	}

	[DoNotPrune]
	public bool InCampaignMode => scenario_0.IsRunningInCampaignMode;

	[DoNotPrune]
	public byte GameMode
	{
		get
		{
			return byte_0;
		}
		set
		{
			if (byte_0 == 0)
			{
				byte_0 = value;
			}
		}
	}

	[DoNotPrune]
	public byte GameStatus
	{
		get
		{
			return byte_1;
		}
		set
		{
			if (Operators.CompareString(Status, (string)null, false) == 0)
			{
				byte_1 = value;
			}
		}
	}

	[DoNotPrune]
	public string FileName => scenario_0.FileName;

	[DoNotPrune]
	public string FileNamePath => scenario_0.FileNamePath;

	[DoNotPrune]
	public string SaveVersion => scenario_0.GameVersion;

	[DoNotPrune]
	public int Sides => scenario_0.Sides_ReadOnly.Count();

	[DoNotPrune]
	public bool HasStarted => scenario_0.HasStarted;

	[DoNotPrune]
	public string Status
	{
		get
		{
			if (scenario_0.GameContext == null)
			{
				return "Undefined";
			}
			switch (scenario_0.GameContext.Status)
			{
			case Game._GameStatus.Paused:
				return "Paused";
			default:
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				return "Undefined";
			case Game._GameStatus.Running:
				return "Running";
			}
		}
	}

	[DoNotPrune]
	public string PlayerSide
	{
		get
		{
			Side currentSide = scenario_0.GetCurrentSide();
			if (currentSide != null)
			{
				return currentSide.ObjectID;
			}
			return string.Empty;
		}
	}

	[DoNotPrune]
	public int TimeCompression => scenario_0.TimeCompression_SimSeconds;

	public LuaWrapper_Scenario(Scenario theScen)
	{
		byte_0 = 0;
		byte_1 = 0;
		scenario_0 = theScen;
	}

	[DoNotPrune]
	public bool ResetLossExp()
	{
		Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
		foreach (Side obj in sides_ReadOnly)
		{
			obj.AAR.Losses.Clear();
			obj.AAR.Expenditures.Clear();
		}
		return true;
	}

	[DoNotPrune]
	public bool ResetScore()
	{
		Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
		foreach (Side obj in sides_ReadOnly)
		{
			obj.set_TotalScore(scenario_0, (string)null, 0);
			obj.ScoringLog.Clear();
		}
		return true;
	}

	[DoNotPrune]
	public override string ToString()
	{
		return "scenario {\r\n FileName = '" + FileName + "', \r\n Title = '" + Title + "', \r\n ScenSetting = '" + ScenSetting + "', \r\n ScenDate = '" + ScenDate + "', \r\n Difficulty = '" + Difficulty + "', \r\n Complexity = '" + Complexity + "', \r\n StartTime = '" + StartTime + "', \r\n Duration = '" + Duration + "', \r\n CurrentTime = '" + CurrentTime + "', \r\n DBUsed = '" + DBUsed + "', \r\n SaveVersion = '" + SaveVersion + "', \r\n CampaignScore = '" + CampaignScore + "', \r\n CampaignSessionID = '" + CampaignSessionID + "', \r\n CampaignID = '" + CampaignID + "', \r\n InCampaignMode = '" + InCampaignMode + "', \r\n ContentTag = '" + ContentTag + "', \r\n StartTimeNum = '" + StartTimeNum + "', \r\n DurationNum = '" + DurationNum + "', \r\n CurrentTimeNum = '" + CurrentTimeNum + "', \r\n guid = '" + guid + "', \r\n PlayerSide = '" + PlayerSide + "', \r\n HasStarted = '" + HasStarted + "', \r\n Status = '" + Status + "', \r\n TimeCompression = '" + TimeCompression + "', \r\n GameMode = '" + GameMode + "', \r\n GameStatus = '" + GameStatus + "', \r\n}";
	}

	static LuaWrapper_Scenario()
	{
		Class72.smethod_20();
	}
}
