using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using Command_Core.SmartAssembly.Attributes;
using DarkUI.Collections;
using KeraLua;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NLua;
using NLua.Event;
using NLua.Exceptions;

namespace Command_Core.Lua;

[DoNotObfuscateType]
public sealed class LuaSandBox
{
	public delegate void LuaPrintEventHandler(object obj);

	public delegate void LuaPrintExceptionEventHandler(object obj);

	public delegate void actionUIwindowEventHandler(string window, bool mode);

	private bool bool_0;

	[AccessedThroughProperty("LuaMethods")]
	[CompilerGenerated]
	private static ObservableList<string> observableList_0;

	[CompilerGenerated]
	private LuaPrintEventHandler luaPrintEventHandler_0;

	[CompilerGenerated]
	private LuaPrintExceptionEventHandler luaPrintExceptionEventHandler_0;

	[CompilerGenerated]
	private actionUIwindowEventHandler vCsLzanfUo6;

	private NLua.Lua lua_0;

	private StringBuilder stringBuilder_0;

	private StringBuilder stringBuilder_1;

	private Scenario scenario_0;

	public object UnitX;

	public ActiveUnit UnitY;

	public Contact UnitC;

	public List<Sensor> SensorsThatMadeDetection;

	public SimEvent EventX;

	public LuaEnuNames enumTable;

	public static bool _lua_event;

	public static bool _lua_console;

	public string currentFunction;

	public int currentLine;

	public string lastError;

	public bool RunInteractive;

	public CMANO luaDynamicFunctions;

	private static LuaSandBox luaSandBox_0;

	private bool bool_1;

	private LockObject lockObject_0;

	public LockObject ScriptLockObj;

	public LockObject ScriptLock2Obj;

	public static ObservableList<string> LuaMethods
	{
		[CompilerGenerated]
		get
		{
			return observableList_0;
		}
		[CompilerGenerated]
		set
		{
			observableList_0 = value;
		}
	}

	public event LuaPrintEventHandler LuaPrint
	{
		[CompilerGenerated]
		add
		{
			LuaPrintEventHandler luaPrintEventHandler = luaPrintEventHandler_0;
			LuaPrintEventHandler luaPrintEventHandler2;
			do
			{
				luaPrintEventHandler2 = luaPrintEventHandler;
				LuaPrintEventHandler value2 = (LuaPrintEventHandler)Delegate.Combine(luaPrintEventHandler2, value);
				luaPrintEventHandler = Interlocked.CompareExchange(ref luaPrintEventHandler_0, value2, luaPrintEventHandler2);
			}
			while ((object)luaPrintEventHandler != luaPrintEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			LuaPrintEventHandler luaPrintEventHandler = luaPrintEventHandler_0;
			LuaPrintEventHandler luaPrintEventHandler2;
			do
			{
				luaPrintEventHandler2 = luaPrintEventHandler;
				LuaPrintEventHandler value2 = (LuaPrintEventHandler)Delegate.Remove(luaPrintEventHandler2, value);
				luaPrintEventHandler = Interlocked.CompareExchange(ref luaPrintEventHandler_0, value2, luaPrintEventHandler2);
			}
			while ((object)luaPrintEventHandler != luaPrintEventHandler2);
		}
	}

	public event LuaPrintExceptionEventHandler LuaPrintException
	{
		[CompilerGenerated]
		add
		{
			LuaPrintExceptionEventHandler luaPrintExceptionEventHandler = luaPrintExceptionEventHandler_0;
			LuaPrintExceptionEventHandler luaPrintExceptionEventHandler2;
			do
			{
				luaPrintExceptionEventHandler2 = luaPrintExceptionEventHandler;
				LuaPrintExceptionEventHandler value2 = (LuaPrintExceptionEventHandler)Delegate.Combine(luaPrintExceptionEventHandler2, value);
				luaPrintExceptionEventHandler = Interlocked.CompareExchange(ref luaPrintExceptionEventHandler_0, value2, luaPrintExceptionEventHandler2);
			}
			while ((object)luaPrintExceptionEventHandler != luaPrintExceptionEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			LuaPrintExceptionEventHandler luaPrintExceptionEventHandler = luaPrintExceptionEventHandler_0;
			LuaPrintExceptionEventHandler luaPrintExceptionEventHandler2;
			do
			{
				luaPrintExceptionEventHandler2 = luaPrintExceptionEventHandler;
				LuaPrintExceptionEventHandler value2 = (LuaPrintExceptionEventHandler)Delegate.Remove(luaPrintExceptionEventHandler2, value);
				luaPrintExceptionEventHandler = Interlocked.CompareExchange(ref luaPrintExceptionEventHandler_0, value2, luaPrintExceptionEventHandler2);
			}
			while ((object)luaPrintExceptionEventHandler != luaPrintExceptionEventHandler2);
		}
	}

	public event actionUIwindowEventHandler actionUIwindow
	{
		[CompilerGenerated]
		add
		{
			actionUIwindowEventHandler actionUIwindowEventHandler = vCsLzanfUo6;
			actionUIwindowEventHandler actionUIwindowEventHandler2;
			do
			{
				actionUIwindowEventHandler2 = actionUIwindowEventHandler;
				actionUIwindowEventHandler value2 = (actionUIwindowEventHandler)Delegate.Combine(actionUIwindowEventHandler2, value);
				actionUIwindowEventHandler = Interlocked.CompareExchange(ref vCsLzanfUo6, value2, actionUIwindowEventHandler2);
			}
			while ((object)actionUIwindowEventHandler != actionUIwindowEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			actionUIwindowEventHandler actionUIwindowEventHandler = vCsLzanfUo6;
			actionUIwindowEventHandler actionUIwindowEventHandler2;
			do
			{
				actionUIwindowEventHandler2 = actionUIwindowEventHandler;
				actionUIwindowEventHandler value2 = (actionUIwindowEventHandler)Delegate.Remove(actionUIwindowEventHandler2, value);
				actionUIwindowEventHandler = Interlocked.CompareExchange(ref vCsLzanfUo6, value2, actionUIwindowEventHandler2);
			}
			while ((object)actionUIwindowEventHandler != actionUIwindowEventHandler2);
		}
	}

	static LuaSandBox()
	{
		Class72.smethod_20();
		LuaMethods = new ObservableList<string>();
		_lua_event = false;
		_lua_console = true;
	}

	public bool ScenarioContextHasBeenInitalized()
	{
		return scenario_0 != null;
	}

	public static LuaSandBox Singleton()
	{
		return luaSandBox_0;
	}

	public LuaTable CreateTable()
	{
		lock (lockObject_0)
		{
			return (LuaTable)lua_0.DoString("return {}").First();
		}
	}

	public int SB_Getinfo(string what, ref LuaDebug ld)
	{
		ld = default(LuaDebug);
		return 0;
	}

	public NLua.Lua SB_Lua()
	{
		return lua_0;
	}

	public LuaSandBox()
	{
		bool_0 = true;
		stringBuilder_0 = new StringBuilder();
		stringBuilder_1 = new StringBuilder();
		UnitX = null;
		UnitY = null;
		UnitC = null;
		SensorsThatMadeDetection = null;
		EventX = null;
		enumTable = null;
		currentFunction = "";
		currentLine = 0;
		lastError = "";
		luaDynamicFunctions = null;
		bool_1 = false;
		lockObject_0 = new LockObject();
		ScriptLockObj = new LockObject();
		ScriptLock2Obj = new LockObject();
		InitializeStats();
	}

	public void InitializeStats()
	{
		try
		{
			luaSandBox_0 = this;
			lua_0 = new NLua.Lua();
			lua_0.State.Encoding = Encoding.UTF8;
			lua_0.LoadCLRPackage();
			LuaPrint += LuaSandBox_LuaPrint;
			LuaPrintException += LuaSandBox_LuaPrintException;
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

	public void RefreshStats(Scenario theScen)
	{
		ScriptLockObj = new LockObject();
		scenario_0 = theScen;
		luaDynamicFunctions = new CMANO(scenario_0);
		stringBuilder_1.Clear();
		stringBuilder_0.Clear();
		if (!GameGeneral.PE_Lua_AllowIO)
		{
			stringBuilder_0.Append("io=nil").Append("\r\n");
		}
		if (!GameGeneral.PE_Lua_AllowCLRPackage)
		{
			stringBuilder_0.Append("rawget=nil").Append("\r\n");
		}
		if (!GameGeneral.PE_Lua_AllowPackageDepend)
		{
			stringBuilder_0.Append("require=nil").Append("\r\n");
			stringBuilder_0.Append("load=nil").Append("\r\n");
			stringBuilder_0.Append("dofile=nil").Append("\r\n");
			stringBuilder_0.Append("loadfile=nil").Append("\r\n");
		}
		stringBuilder_0.Append("loadstring=nil\r\nrawequal=nil\r\nrawset=nil\r\nmodule=nil\r\npackage.loaded=nil\r\npackage.loaders=nil\r\npackage.loadlib=nil\r\npackage.path=nil\r\npackage.cpath=nil\r\npackage.preload=nil\r\npackage.seeall=nil\r\nstring.dump=nil\r\nos.execute=nil\r\nos.exit=nil\r\nos.getenv=nil\r\nos.remove=nil\r\nos.rename=nil\r\nos.tmpname=nil\r\nnewproxy=nil\r\n");
		if (bool_0)
		{
			bool_0 = false;
			stringBuilder_0.Append("os.default_date = os.date;\r\n");
			stringBuilder_0.Append("local function date_override(format, x)\r\n");
			stringBuilder_0.Append("  local now = os.time()\r\n");
			stringBuilder_0.Append("  if format == nil or format == '' then\r\n");
			stringBuilder_0.Append("    format = '!%a %b %d %X %Y UTC';\r\n");
			stringBuilder_0.Append("  elseif string.sub(format,1,1) ~= '!' then\r\n");
			stringBuilder_0.Append("      format = '!' .. format;\r\n");
			stringBuilder_0.Append("  end\r\n");
			stringBuilder_0.Append("  if x ~= nil then\r\n");
			stringBuilder_0.Append("    return os.default_date(format,math.tointeger(x));\r\n");
			stringBuilder_0.Append("  else\r\n");
			stringBuilder_0.Append("    return os.default_date(format,math.tointeger(now));\r\n");
			stringBuilder_0.Append("  end\r\n");
			stringBuilder_0.Append("end\r\n");
			stringBuilder_0.Append("os.date = date_override;\r\n");
			stringBuilder_0.Append("math.default_random = math.random;\r\n");
			stringBuilder_0.Append("local function random_override(m,n)\r\n");
			stringBuilder_0.Append(" if m == nil and n == nil then\r\n");
			stringBuilder_0.Append("    return math.default_random();\r\n");
			stringBuilder_0.Append(" elseif n == nil then\r\n");
			stringBuilder_0.Append("    return math.default_random(math.floor(m));\r\n");
			stringBuilder_0.Append(" else \r\n");
			stringBuilder_0.Append("    return math.default_random(math.floor(m), math.floor(n));\r\n");
			stringBuilder_0.Append(" end\r\n");
			stringBuilder_0.Append("end;\r\n");
			stringBuilder_0.Append("math.random = random_override;\r\n");
			MethodInfo method = GetType().GetMethod("LUA_Echo");
			if (lua_0 == null)
			{
				InitializeStats();
			}
			lua_0.RegisterFunction("Echo", this, method);
			observableList_0.Clear();
			RegisterFunction("UI_SelectUnitsPrompt_FromSides", GetType().GetMethod("LUA_UI_SelectUnitsPrompt_FromSides"));
			observableList_0.Add("UI_SelectUnitsPrompt_FromSides(result,Sides ,MultipleSelect)");
			RegisterFunction("UI_SelectUnitsPrompt_OwnSide", GetType().GetMethod("LUA_UI_SelectUnitsPrompt_OwnSide"));
			observableList_0.Add("UI_SelectUnitsPrompt_OwnSide(result, MultipleSelect)");
			RegisterFunction("UI_CallAdvancedDialog", GetType().GetMethod("LUA_UI_CallAdvancedDialog"));
			observableList_0.Add("UI_CallAdvancedDialog(Title, Description, Interactions)");
			RegisterFunction("UI_CallAdvancedHTMLDialog", GetType().GetMethod("LUA_UI_CallAdvancedHTMLDialog"));
			observableList_0.Add("UI_CallAdvancedHTMLDialog(Title, Description, Interactions)");
			RegisterFunction("UI_SetCameraView", GetType().GetMethod("LUA_UI_SetCameraView"));
			observableList_0.Add("UI_SetCameraView(Latitude, Longitude,(optional) Altitude)");
			RegisterFunction("UI_OpenNewDatabaseWindow", GetType().GetMethod("LUA_UI_OpenNewDatabaseWindow"));
			observableList_0.Add("UI_OpenNewDatabaseWindow(SelectedObjectType,selectedObjectID)");
			RegisterFunction("UI_ShowWindow", GetType().GetMethod("LUA_UI_ShowWindow"));
			observableList_0.Add("UI_ShowWindow(Window,args)");
			RegisterFunction("UI_SelectThisUnit", GetType().GetMethod("LUA_UI_SelectThisUnit"));
			observableList_0.Add("UI_SelectThisUnit(NameOrGUID, ThisUnitOnly, (Optional) clearWaypointSelection)");
			RegisterFunction("GetScenarioTitle", GetType().GetMethod("LUA_GetScenarioTitle"));
			observableList_0.Add("GetScenarioTitle()");
			RegisterFunction("SetScenarioTitle", GetType().GetMethod("LUA_SetScenarioTitle"));
			observableList_0.Add("SetScenarioTitle(newTitle)");
			RegisterFunction("SetScenarioMessageLogPath", GetType().GetMethod("LUA_SetScenarioMessageLogPath"));
			observableList_0.Add("SetScenarioMessageLogPath(fullpath)");
			RegisterFunction("GetBuildNumber", GetType().GetMethod("LUA_GetBuildNumber"));
			observableList_0.Add("GetBuildNumber()");
			RegisterFunction("VP_SetTimeCompression", GetType().GetMethod("LUA_VP_SetTimeCompression"));
			observableList_0.Add("VP_SetTimeCompression(value)");
			RegisterFunction("VP_GetSides", GetType().GetMethod("LUA_VP_GetSides"));
			observableList_0.Add("VP_GetSides()");
			RegisterFunction("VP_GetSide", GetType().GetMethod("LUA_VP_GetSide"));
			observableList_0.Add("VP_GetSide(table)");
			RegisterFunction("VP_GetUnit", GetType().GetMethod("LUA_VP_GetUnit"));
			observableList_0.Add("VP_GetUnit(table)");
			RegisterFunction("VP_GetContact", GetType().GetMethod("LUA_VP_GetContact"));
			observableList_0.Add("VP_GetContact(table)");
			RegisterFunction("VP_ExportUnits", GetType().GetMethod("LUA_VP_ExportUnits"));
			RegisterFunction("ScenEdit_AddAircraft", GetType().GetMethod("LUA_ScenEdit_AddAircraft"));
			RegisterFunction("ScenEdit_AddShip", GetType().GetMethod("LUA_ScenEdit_AddShip"));
			RegisterFunction("ScenEdit_AddSubmarine", GetType().GetMethod("LUA_ScenEdit_AddSubmarine"));
			RegisterFunction("ScenEdit_AddFacility", GetType().GetMethod("LUA_ScenEdit_AddFacility"));
			RegisterFunction("ScenEdit_AssignUnitToMission", GetType().GetMethod("LUA_ScenEdit_AssignUnitToMission"));
			observableList_0.Add("ScenEdit_AssignUnitToMission('AUNameOrID', 'MissionNameOrID',[asEscort])");
			RegisterFunction("ScenEdit_SetWeather", GetType().GetMethod("LUA_ScenEdit_SetWeather"));
			observableList_0.Add("ScenEdit_SetWeather(AvgTemp, RainfallRate, FractionUnderRain, SeaState)");
			RegisterFunction("ScenEdit_GetWeather", GetType().GetMethod("LUA_ScenEdit_GetWeather"));
			observableList_0.Add("ScenEdit_GetWeather()");
			RegisterFunction("ScenEdit_TransformZone", GetType().GetMethod("LUA_ScenEdit_TransformZone"));
			observableList_0.Add("ScenEdit_TransformZone(SideNameOrID As String, ZoneNameOrID As String, TargetType As String)");
			RegisterFunction("ScenEdit_SetSidePosture", GetType().GetMethod("LUA_ScenEdit_SetSidePosture"));
			observableList_0.Add("ScenEdit_SetSidePosture('SideANameOrID', 'SideBNameOrID', 'PostureCode')");
			RegisterFunction("ScenEdit_GetSidePosture", GetType().GetMethod("LUA_ScenEdit_GetSidePosture"));
			observableList_0.Add("ScenEdit_GetSidePosture('SideANameOrID', 'SideBNameOrID')");
			RegisterFunction("ScenEdit_GetSideIsHuman", GetType().GetMethod("LUA_ScenEdit_GetSideIsHuman"));
			observableList_0.Add("ScenEdit_GetSideIsHuman('SideANameOrID')");
			RegisterFunction("ScenEdit_GetSideIsPlayer", GetType().GetMethod("LUA_ScenEdit_GetSideIsPlayer"));
			observableList_0.Add("ScenEdit_GetSideIsPlayer('SideANameOrID')");
			RegisterFunction("ScenEdit_GetScenHasStarted", GetType().GetMethod("LUA_ScenEdit_GetScenHasStarted"));
			observableList_0.Add("ScenEdit_GetScenHasStarted()");
			RegisterFunction("ScenEdit_GetGameIsRTMP", GetType().GetMethod("LUA_ScenEdit_GetGameIsRTMP"));
			observableList_0.Add("ScenEdit_GetGameIsRTMP()");
			RegisterFunction("ScenEdit_SetEMCON", GetType().GetMethod("LUA_ScenEdit_SetEMCON"));
			observableList_0.Add("ScenEdit_SetEMCON('EMCONSubjectType', 'EMCONSubjectNameOrID', 'EMCONSettings')");
			RegisterFunction("ScenEdit_MsgBox", GetType().GetMethod("LUA_ScenEdit_MsgBox"));
			observableList_0.Add("ScenEdit_MsgBox('str', style)");
			RegisterFunction("ScenEdit_RunScript", GetType().GetMethod("LUA_ScenEdit_RunScript"));
			observableList_0.Add("ScenEdit_RunScript('str', [useCustomPath: false/true])");
			RegisterFunction("ScenEdit_AddUnit", GetType().GetMethod("LUA_ScenEdit_AddUnit"));
			observableList_0.Add("ScenEdit_AddUnit(table)");
			RegisterFunction("ScenEdit_UpdateUnit", GetType().GetMethod("LUA_ScenEdit_UpdateUnit"));
			observableList_0.Add("ScenEdit_UpdateUnit(table)");
			RegisterFunction("ScenEdit_SetUnit", GetType().GetMethod("LUA_ScenEdit_SetUnit"));
			observableList_0.Add("ScenEdit_SetUnit(table)");
			RegisterFunction("ScenEdit_GetUnit", GetType().GetMethod("LUA_ScenEdit_GetUnit"));
			observableList_0.Add("ScenEdit_GetUnit(table)");
			RegisterFunction("ScenEdit_SetKeyValue", GetType().GetMethod("LUA_ScenEdit_SetKeyValue"));
			observableList_0.Add("ScenEdit_SetKeyValue('key', 'value' [, false/true])");
			RegisterFunction("ScenEdit_GetKeyValue", GetType().GetMethod("LUA_ScenEdit_GetKeyValue"));
			observableList_0.Add("ScenEdit_GetKeyValue('key' [,false/true])");
			RegisterFunction("ScenEdit_ClearKeyValue", GetType().GetMethod("LUA_ScenEdit_ClearKeyValue"));
			observableList_0.Add("ScenEdit_ClearKeyValue('key' [,false/true])");
			RegisterFunction("ScenEdit_GetKeyStore", GetType().GetMethod("LUA_ScenEdit_GetKeyStore"));
			observableList_0.Add("ScenEdit_GetKeyStore( [,false/true])");
			RegisterFunction("ScenEdit_DeleteUnit", GetType().GetMethod("LUA_ScenEdit_DeleteUnit"));
			observableList_0.Add("ScenEdit_DeleteUnit(table[, false/true])");
			RegisterFunction("ScenEdit_KillUnit", GetType().GetMethod("LUA_ScenEdit_KillUnit"));
			observableList_0.Add("ScenEdit_KillUnit(table)");
			RegisterFunction("ScenEdit_SetSpecialAction", GetType().GetMethod("LUA_ScenEdit_SetSpecialAction"));
			observableList_0.Add("ScenEdit_SetSpecialAction(table)");
			RegisterFunction("ScenEdit_AddSpecialAction", GetType().GetMethod("LUA_ScenEdit_AddSpecialAction"));
			observableList_0.Add("ScenEdit_AddSpecialAction(table)");
			RegisterFunction("ScenEdit_SetUnitSide", GetType().GetMethod("LUA_ScenEdit_SetUnitSide"));
			observableList_0.Add("ScenEdit_SetUnitSide(table)");
			RegisterFunction("ScenEdit_SetTime", GetType().GetMethod("LUA_ScenEdit_SetTime"));
			observableList_0.Add("ScenEdit_SetTime(table)");
			RegisterFunction("ScenEdit_SetStartTime", GetType().GetMethod("LUA_ScenEdit_SetStartTime"));
			observableList_0.Add("ScenEdit_SetStartTime(table)");
			RegisterFunction("ScenEdit_AddReferencePoint", GetType().GetMethod("LUA_ScenEdit_AddReferencePoint"));
			observableList_0.Add("ScenEdit_AddReferencePoint(table)");
			RegisterFunction("ScenEdit_AddExplosion", GetType().GetMethod("LUA_ScenEdit_AddExplosion"));
			observableList_0.Add("ScenEdit_AddExplosion(table)");
			RegisterFunction("ScenEdit_SetLoadoutAvailable", GetType().GetMethod("LUA_ScenEdit_SetLoadoutAvailable"));
			observableList_0.Add("ScenEdit_SetLoadoutAvailable(table)");
			RegisterFunction("ScenEdit_SetReferencePoint", GetType().GetMethod("LUA_ScenEdit_SetReferencePoint"));
			observableList_0.Add("ScenEdit_SetReferencePoint(table)");
			RegisterFunction("ScenEdit_GetReferencePoint", GetType().GetMethod("LUA_ScenEdit_GetReferencePoint"));
			observableList_0.Add("ScenEdit_GetReferencePoint(table)");
			RegisterFunction("ScenEdit_GetReferencePoints", GetType().GetMethod("LUA_ScenEdit_GetReferencePoints"));
			observableList_0.Add("ScenEdit_GetReferencePoints(table)");
			RegisterFunction("ScenEdit_DeleteReferencePoint", GetType().GetMethod("LUA_ScenEdit_DeleteReferencePoint"));
			observableList_0.Add("ScenEdit_DeleteReferencePoint(table)");
			RegisterFunction("print", GetType().GetMethod("LUA_ScenEdit_Print"));
			observableList_0.Add("print(obj)");
			RegisterFunction("print_exc", GetType().GetMethod("LUA_ScenEdit_PrintException"));
			RegisterFunction("print_escaped", GetType().GetMethod("LUA_ScenEdit_PrintEscaped"));
			observableList_0.Add("print_escaped(obj)");
			RegisterFunction("ScenEdit_SetDoctrine", GetType().GetMethod("LUA_ScenEdit_SetDoctrine"));
			observableList_0.Add("ScenEdit_SetDoctrine(table,doctrine)");
			RegisterFunction("ScenEdit_SetDoctrineWRA", GetType().GetMethod("LUA_ScenEdit_SetDoctrineWRA"));
			observableList_0.Add("ScenEdit_SetDoctrineWRA(table)");
			RegisterFunction("ScenEdit_GetDoctrine", GetType().GetMethod("LUA_ScenEdit_GetDoctrine"));
			observableList_0.Add("ScenEdit_GetDoctrine(table)");
			RegisterFunction("ScenEdit_GetDoctrineWRA", GetType().GetMethod("LUA_ScenEdit_GetDoctrineWRA"));
			observableList_0.Add("ScenEdit_GetDoctrineWRA(table)");
			RegisterFunction("ScenEdit_HostUnitToParent", GetType().GetMethod("LUA_ScenEdit_HostUnitToParent"));
			observableList_0.Add("ScenEdit_HostUnitToParent(table)");
			RegisterFunction("ScenEdit_CurrentTime", GetType().GetMethod("LUA_ScenEdit_CurrentTime"));
			observableList_0.Add("ScenEdit_CurrentTime()");
			RegisterFunction("EpochToUTC_Date", GetType().GetMethod("LUA_EpochToUTC_Date"));
			observableList_0.Add("EpochToUTC_Date()");
			RegisterFunction("EpochToUTC_Time", GetType().GetMethod("LUA_EpochToUTC_Time"));
			observableList_0.Add("EpochToUTC_Time()");
			RegisterFunction("ScenEdit_CurrentLocalTime", GetType().GetMethod("LUA_ScenEdit_CurrentLocalTime"));
			observableList_0.Add("ScenEdit_CurrentLocalTime()");
			RegisterFunction("Exporter_SetSetting", GetType().GetMethod("LUA_Exporter_SetSetting"));
			observableList_0.Add("Exporter_SetSetting(Category As String, Setting As String, Value As String)");
			RegisterFunction("ScenEdit_UnitX", GetType().GetMethod("LUA_ScenEdit_UnitX"));
			observableList_0.Add("ScenEdit_UnitX()");
			RunScript("UnitX = ScenEdit_UnitX", RunInteractively: false, "Initializing");
			RegisterFunction("ScenEdit_UnitY", GetType().GetMethod("LUA_ScenEdit_UnitY"));
			observableList_0.Add("ScenEdit_UnitY()");
			RunScript("UnitY = ScenEdit_UnitY", RunInteractively: false, "Initializing");
			RegisterFunction("ScenEdit_UnitC", GetType().GetMethod("LUA_ScenEdit_UnitC"));
			observableList_0.Add("ScenEdit_UnitC()");
			RunScript("UnitC = ScenEdit_UnitC", RunInteractively: false, "Initializing");
			RegisterFunction("ScenEdit_UseAttachment", GetType().GetMethod("LUA_ScenEdit_UseAttachment"));
			observableList_0.Add("ScenEdit_UseAttachment('AttachmentNameOrID')");
			RegisterFunction("ScenEdit_UseAttachmentOnSide", GetType().GetMethod("LUA_ScenEdit_UseAttachmentOnSide"));
			observableList_0.Add("ScenEdit_UseAttachmentOnSide('AttachmentNameOrID', 'SideNameOrID')");
			RegisterFunction("ScenEdit_GetScore", GetType().GetMethod("LUA_ScenEdit_GetScore"));
			observableList_0.Add("ScenEdit_GetScore('SideNameOrID')");
			RegisterFunction("ScenEdit_SetLoadout", GetType().GetMethod("LUA_ScenEdit_SetLoadout"));
			observableList_0.Add("ScenEdit_SetLoadout(table)");
			RegisterFunction("ScenEdit_SetScore", GetType().GetMethod("LUA_ScenEdit_SetScore"));
			observableList_0.Add("ScenEdit_SetScore('SideNameOrID',Score,'ReasonForChange')");
			RegisterFunction("ScenEdit_SpecialMessage", GetType().GetMethod("LUA_ScenEdit_SpecialMessage"));
			observableList_0.Add("ScenEdit_SpecialMessage('SideNameOrID','Text' [,{lat=,lon=}, forceMapRecenter])");
			RegisterFunction("ScenEdit_CustomUI", GetType().GetMethod("LUA_ScenEdit_CustomUI"));
			observableList_0.Add("ScenEdit_CustomUI('SideNameOrID','Text' [,{lat=,lon=}, forceMapRecenter])");
			RegisterFunction("ScenEdit_PlayerSide", GetType().GetMethod("LUA_ScenEdit_PlayerSide"));
			observableList_0.Add("ScenEdit_PlayerSide()");
			RegisterFunction("ScenEdit_EndScenario", GetType().GetMethod("LUA_ScenEdit_EndScenario"));
			observableList_0.Add("ScenEdit_EndScenario()");
			RegisterFunction("ScenEdit_ImportInst", GetType().GetMethod("LUA_ScenEdit_ImportInst"));
			observableList_0.Add("ScenEdit_ImportInst('SideNameOrID', 'InstFile')");
			RegisterFunction("ScenEdit_ExportInst", GetType().GetMethod("LUA_ScenEdit_ExportInst"));
			observableList_0.Add("ScenEdit_ExportInst('SideNameOrID', 'units', 'fileData')");
			RegisterFunction("ScenEdit_AddWeaponToUnitMagazine", GetType().GetMethod("LUA_ScenEdit_AddWeaponToUnitMagazine"));
			observableList_0.Add("ScenEdit_AddWeaponToUnitMagazine(table)");
			RegisterFunction("ScenEdit_AddReloadsToUnit", GetType().GetMethod("LUA_ScenEdit_AddReloadsToUnit"));
			observableList_0.Add("ScenEdit_AddReloadsToUnit(table)");
			RegisterFunction("ScenEdit_GetSideOptions", GetType().GetMethod("LUA_ScenEdit_GetSideOptions"));
			observableList_0.Add("ScenEdit_GetSideOptions(table)");
			RegisterFunction("ScenEdit_SetSideOptions", GetType().GetMethod("LUA_ScenEdit_SetSideOptions"));
			observableList_0.Add("ScenEdit_SetSideOptions(table)");
			RegisterFunction("ScenEdit_SetUnitDamage", GetType().GetMethod("LUA_ScenEdit_SetUnitDamage"));
			observableList_0.Add("ScenEdit_SetUnitDamage(table)");
			RegisterFunction("ScenEdit_GetMissions", GetType().GetMethod("LUA_ScenEdit_GetMissions"));
			observableList_0.Add("ScenEdit_GetMissions('SideNameOrID')");
			RegisterFunction("ScenEdit_GetMission", GetType().GetMethod("LUA_ScenEdit_GetMission"));
			observableList_0.Add("ScenEdit_GetMission('SideNameOrID', 'MissionNameOrID')");
			RegisterFunction("ScenEdit_SetMission", GetType().GetMethod("LUA_ScenEdit_SetMission"));
			observableList_0.Add("ScenEdit_SetMission('SideNameOrID', 'MissionNameOrID',table)");
			RegisterFunction("ScenEdit_AddMission", GetType().GetMethod("LUA_ScenEdit_AddMission"));
			observableList_0.Add("ScenEdit_AddMission('SideNameOrID', 'MissionNameOrID', 'MissionType', table)");
			RegisterFunction("ScenEdit_DeleteMission", GetType().GetMethod("LUA_ScenEdit_DeleteMission"));
			observableList_0.Add("ScenEdit_DeleteMission('SideNameOrID', 'MissionNameOrID')");
			RegisterFunction("ScenEdit_ImportMission", GetType().GetMethod("LUA_ScenEdit_ImportMission"));
			observableList_0.Add("ScenEdit_ImportMission('SideNameOrID', 'MissionNameOrID')");
			RegisterFunction("ScenEdit_ExportMission", GetType().GetMethod("LUA_ScenEdit_ExportMission"));
			observableList_0.Add("ScenEdit_ExportMission('SideNameOrID', 'MissionNameOrID')");
			RegisterFunction("ScenEdit_CreateMissionFlightPlan", GetType().GetMethod("LUA_ScenEdit_CreateMissionFlightPlan"));
			observableList_0.Add("ScenEdit_CreateMissionFlightPlan('AUNameOrID', 'MissionNameOrID', table)");
			RegisterFunction("ScenEdit_AssignUnitAsTarget", GetType().GetMethod("LUA_ScenEdit_AssignUnitAsTarget"));
			observableList_0.Add("ScenEdit_AssignUnitAsTarget('AUNameOrID', 'MissionNameOrID')");
			RegisterFunction("ScenEdit_RemoveUnitAsTarget", GetType().GetMethod("LUA_ScenEdit_RemoveUnitAsTarget"));
			observableList_0.Add("ScenEdit_RemoveUnitAsTarget('AUNameOrID', 'MissionNameOrID')");
			RegisterFunction("ScenEdit_RefuelUnit", GetType().GetMethod("LUA_ScenEdit_RefuelUnit"));
			observableList_0.Add("ScenEdit_RefuelUnit(table)");
			RegisterFunction("ScenEdit_ExecuteEventAction", GetType().GetMethod("LUA_ScenEdit_ExecuteEventAction"));
			observableList_0.Add("ScenEdit_ExecuteEventAction('EventNameOrId')");
			RegisterFunction("ScenEdit_SetEvent", GetType().GetMethod("LUA_ScenEdit_SetEvent"));
			observableList_0.Add("ScenEdit_SetEvent('EventNameOrId', table)");
			RegisterFunction("ScenEdit_SetTrigger", GetType().GetMethod("LUA_ScenEdit_SetTrigger"));
			observableList_0.Add("ScenEdit_SetTrigger( table)");
			RegisterFunction("ScenEdit_SetCondition", GetType().GetMethod("LUA_ScenEdit_SetCondition"));
			observableList_0.Add("ScenEdit_SetCondition( table)");
			RegisterFunction("ScenEdit_SetAction", GetType().GetMethod("LUA_ScenEdit_SetAction"));
			observableList_0.Add("ScenEdit_SetAction( table)");
			RegisterFunction("ScenEdit_GetUnitIntermittentEmissionConfig", GetType().GetMethod("LUA_ScenEdit_GetUnitIntermittentEmissionConfig"));
			observableList_0.Add("ScenEdit_GetUnitIntermittentEmissionConfig(PresetAlertID, AUNameOrID)");
			RegisterFunction("ScenEdit_SetUnitIntermittentEmissionConfig", GetType().GetMethod("LUA_ScenEdit_SetUnitIntermittentEmissionConfig"));
			observableList_0.Add("ScenEdit_SetUnitIntermittentEmissionConfig(AUNameOrID, PresetAlertID, ConfigurationTable)");
			RegisterFunction("ScenEdit_DuplicateEmconConfigToUnit", GetType().GetMethod("LUA_ScenEdit_DuplicateEmconConfigToUnit"));
			observableList_0.Add("ScenEdit_DuplicateEmconConfigToUnit(PresetAlertID, SourceAUNameOrID, TargetAUNameOrID)");
			RegisterFunction("ScenEdit_CreateBarkNotification_Geo_Bulk", GetType().GetMethod("LUA_ScenEdit_CreateBarkNotification_Geo_Bulk"));
			observableList_0.Add("ScenEdit_CreateBarkNotification_Geo_Bulk(Longitude, Latitude, text, R, G, B [, MoveUpward, Fades, Lifetime, FontSize])");
			RegisterFunction("ScenEdit_CreateBarkNotification_Unit_Bulk", GetType().GetMethod("LUA_ScenEdit_CreateBarkNotification_Unit_Bulk"));
			observableList_0.Add("ScenEdit_CreateBarkNotification_Unit_Bulk(AUNameOrID, text, R, G, B [, MoveUpward, Fades, Lifetime, FontSize])");
			RegisterFunction("ScenEdit_CreateBarkNotification_Geo", GetType().GetMethod("LUA_ScenEdit_CreateBarkNotification_Geo"));
			observableList_0.Add("ScenEdit_CreateBarkNotification_Geo(Longitude, Latitude, text, R, G, B [, MoveUpward, Fades, Lifetime, FontSize])");
			RegisterFunction("ScenEdit_CreateBarkNotification_Unit", GetType().GetMethod("LUA_ScenEdit_CreateBarkNotification_Unit"));
			observableList_0.Add("ScenEdit_CreateBarkNotification_Unit(AUNameOrID, text, R, G, B [, MoveUpward, Fades, Lifetime, FontSize])");
			RegisterFunction("ScenEdit_SwitchUnitIntermittentEmission", GetType().GetMethod("LUA_ScenEdit_SwitchUnitIntermittentEmission"));
			observableList_0.Add("ScenEdit_SwitchUnitIntermittentEmission(AUNameOrID, PresetAlertID, Switch)");
			RegisterFunction("ScenEdit_SetSideEmconAlertness", GetType().GetMethod("LUA_ScenEdit_SetSideEmconAlertness"));
			observableList_0.Add("ScenEdit_SetSideEmconAlertness(SideNameOrID, AlertID)");
			RegisterFunction("ScenEdit_ClearAllSideUnitsEmconConfigs", GetType().GetMethod("LUA_ScenEdit_ClearAllSideUnitsEmconConfigs"));
			observableList_0.Add("ScenEdit_ClearAllSideUnitsEmconConfigs(SideNameOrID)");
			RegisterFunction("ScenEdit_ClearUnitEmconConfigs", GetType().GetMethod("LUA_ScenEdit_ClearUnitEmconConfigs"));
			observableList_0.Add("ScenEdit_ClearUnitEmconConfigs(UnitNameorID)");
			RegisterFunction("ScenEdit_DuplicateEmconConfigToSide", GetType().GetMethod("LUA_ScenEdit_DuplicateEmconConfigToSide"));
			observableList_0.Add("ScenEdit_DuplicateEmconConfigToSide(PresetAlertID, SourceAUNameOrID, TargetSideNameOrID)");
			RegisterFunction("ScenEdit_SetEventTrigger", GetType().GetMethod("LUA_ScenEdit_SetEventTrigger"));
			observableList_0.Add("ScenEdit_SetEventTrigger('EventNameOrId', table)");
			RegisterFunction("ScenEdit_SetEventCondition", GetType().GetMethod("LUA_ScenEdit_SetEventCondition"));
			observableList_0.Add("ScenEdit_SetEventCondition('EventNameOrId', table)");
			RegisterFunction("ScenEdit_SetEventAction", GetType().GetMethod("LUA_ScenEdit_SetEventAction"));
			observableList_0.Add("ScenEdit_SetEventAction('EventNameOrId', table)");
			RegisterFunction("ScenEdit_GetEvent", GetType().GetMethod("LUA_ScenEdit_GetEvent"));
			observableList_0.Add("ScenEdit_GetEvent('EventNameOrId',[level])");
			RegisterFunction("ScenEdit_GetEvents", GetType().GetMethod("LUA_ScenEdit_GetEvents"));
			observableList_0.Add("ScenEdit_GetEvents(level)");
			RegisterFunction("ScenEdit_UpdateEvent", GetType().GetMethod("LUA_ScenEdit_UpdateEvent"));
			RegisterFunction("ScenEdit_GetSpecialAction", GetType().GetMethod("LUA_ScenEdit_GetSpecialAction"));
			observableList_0.Add("ScenEdit_GetSpecialAction(table)");
			RegisterFunction("ScenEdit_ExecuteSpecialAction", GetType().GetMethod("LUA_ScenEdit_ExecuteSpecialAction"));
			observableList_0.Add("ScenEdit_ExecuteSpecialAction('EventNameOrId')");
			RegisterFunction("ScenEdit_GetContacts", GetType().GetMethod("LUA_ScenEdit_GetContacts"));
			observableList_0.Add("ScenEdit_GetContacts('SideName')");
			RegisterFunction("ScenEdit_FillMagsForLoadout", GetType().GetMethod("LUA_ScenEdit_FillMagsForLoadout"));
			observableList_0.Add("ScenEdit_FillMagsForLoadout(table)");
			RegisterFunction("ScenEdit_GetContact", GetType().GetMethod("LUA_ScenEdit_GetContact"));
			observableList_0.Add("ScenEdit_GetContact(table)");
			RegisterFunction("ScenEdit_AttackContact", GetType().GetMethod("LUA_ScenEdit_AttackContact"));
			observableList_0.Add("ScenEdit_AttackContact('AttackerNameOrId','ContactNameOrId', table)");
			RegisterFunction("ScenEdit_AttackContact_Extra", GetType().GetMethod("LUA_ScenEdit_AttackContact_Extra"));
			observableList_0.Add("ScenEdit_AttackContact_Extra('AttackerNameOrId','ContactNameOrId', table)");
			RegisterFunction("ScenEdit_InputBox", GetType().GetMethod("LUA_ScenEdit_InputBox"));
			observableList_0.Add("ScenEdit_InputBox('str')");
			RegisterFunction("ScenEdit_AddSide", GetType().GetMethod("LUA_ScenEdit_AddSide"));
			observableList_0.Add("ScenEdit_AddSide(table)");
			RegisterFunction("ScenEdit_RemoveSide", GetType().GetMethod("LUA_ScenEdit_RemoveSide"));
			observableList_0.Add("ScenEdit_RemoveSide(table)");
			RegisterFunction("ScenEdit_AddZone", GetType().GetMethod("LUA_ScenEdit_AddZone"));
			observableList_0.Add("ScenEdit_AddZone(sideName, zoneType, table)");
			RegisterFunction("ScenEdit_GetZone", GetType().GetMethod("LUA_ScenEdit_GetZone"));
			observableList_0.Add("ScenEdit_GetZone(sideName, zoneName, zoneType)");
			RegisterFunction("ScenEdit_SetZone", GetType().GetMethod("LUA_ScenEdit_SetZone"));
			observableList_0.Add("ScenEdit_SetZone(sideName, zoneType, table)");
			RegisterFunction("ScenEdit_RemoveZone", GetType().GetMethod("LUA_ScenEdit_RemoveZone"));
			observableList_0.Add("ScenEdit_RemoveZone(sideName, zoneType, table)");
			RegisterFunction("ScenEdit_TransferCargo", GetType().GetMethod("LUA_ScenEdit_TransferCargo"));
			observableList_0.Add("ScenEdit_TransferCargo(from, to, table)");
			RegisterFunction("ScenEdit_UnloadCargo", GetType().GetMethod("LUA_ScenEdit_UnloadCargo"));
			observableList_0.Add("ScenEdit_UnloadCargo(from, [table])");
			RegisterFunction("ScenEdit_SelectedUnits", GetType().GetMethod("LUA_ScenEdit_SelectedUnits"));
			observableList_0.Add("ScenEdit_SelectedUnits()");
			RegisterFunction("ScenEdit_EventX", GetType().GetMethod("LUA_ScenEdit_EventX"));
			observableList_0.Add("ScenEdit_EventX()");
			RunScript("EventX = ScenEdit_EventX", RunInteractively: false, "Initializing");
			RegisterFunction("ScenEdit_GetFormation", GetType().GetMethod("LUA_ScenEdit_GetFormation"));
			observableList_0.Add("ScenEdit_GetFormation(table)");
			RegisterFunction("ScenEdit_SetFormation", GetType().GetMethod("LUA_ScenEdit_SetFormation"));
			observableList_0.Add("ScenEdit_SetFormation(table)");
			RegisterFunction("ScenEdit_GetLoadout", GetType().GetMethod("LUA_ScenEdit_GetLoadout"));
			observableList_0.Add("ScenEdit_GetLoadout(table)");
			RegisterFunction("ScenEdit_UpdateUnitCargo", GetType().GetMethod("LUA_ScenEdit_UpdateUnitCargo"));
			observableList_0.Add("ScenEdit_UpdateUnitCargo(table)");
			RegisterFunction("ScenEdit_GetTimeOfDay", GetType().GetMethod("LUA_ScenEdit_GetTimeOfDay"));
			observableList_0.Add("ScenEdit_GetTimeOfDay(table)");
			RegisterFunction("ScenEdit_QueryDB", GetType().GetMethod("LUA_ScenEdit_QueryDB"));
			observableList_0.Add("ScenEdit_QueryDB(type, DBID)");
			RegisterFunction("ScenEdit_PlaySound", GetType().GetMethod("LUA_ScenEdit_PlaySound"));
			observableList_0.Add("ScenEdit_PlaySound(file, delay)");
			RegisterFunction("ScenEdit_PlayVideo", GetType().GetMethod("LUA_ScenEdit_PlayVideo"));
			RegisterFunction("ScenEdit_ClearAllAircraft", GetType().GetMethod("LUA_ScenEdit_ClearAllAircraft"));
			observableList_0.Add("ScenEdit_ClearAllAircraft(table)");
			RegisterFunction("ScenEdit_AddMinefield", GetType().GetMethod("LUA_ScenEdit_AddMinefield"));
			observableList_0.Add("ScenEdit_AddMinefield(table)");
			RegisterFunction("ScenEdit_GetMinefield", GetType().GetMethod("LUA_ScenEdit_GetMinefield"));
			observableList_0.Add("ScenEdit_GetMinefield(table)");
			RegisterFunction("ScenEdit_DeleteMinefield", GetType().GetMethod("LUA_ScenEdit_DeleteMinefield"));
			observableList_0.Add("ScenEdit_DeleteMinefield(table)");
			RegisterFunction("ScenEdit_DistributeWeaponAtAirbase", GetType().GetMethod("LUA_ScenEdit_DistributeWeaponAtAirbase"));
			observableList_0.Add("ScenEdit_DistributeWeaponAtAirbase(table)");
			RegisterFunction("ScenEdit_SetMine", GetType().GetMethod("LUA_ScenEdit_SetMine"));
			observableList_0.Add("ScenEdit_SetMine(table)");
			RegisterFunction("ScenEdit_DeleteMine", GetType().GetMethod("LUA_ScenEdit_DeleteMine"));
			observableList_0.Add("ScenEdit_DeleteMine(table)");
			RegisterFunction("ScenEdit_ClearAllMagazines", GetType().GetMethod("LUA_ScenEdit_ClearAllMagazines"));
			observableList_0.Add("ScenEdit_ClearAllMagazines(table)");
			RegisterFunction("ScenEdit_AddCustomLoss", GetType().GetMethod("LUA_ScenEdit_AddCustomLoss"));
			observableList_0.Add("ScenEdit_AddCustomLoss(side, table)");
			RegisterFunction("ScenEdit_ClearAllAircraft", GetType().GetMethod("LUA_ScenEdit_ClearAllAircraft"));
			observableList_0.Add("ScenEdit_ClearAllAircraft(table)");
			RegisterFunction("ScenEdit_GetDateTimeTicks", GetType().GetMethod("LUA_ScenEdit_GetDateTimeTicks"));
			observableList_0.Add("ScenEdit_GetDateTimeTicks()");
			RegisterFunction("World_GetElevation", GetType().GetMethod("LUA_World_GetElevation"));
			observableList_0.Add("World_GetElevation(table)");
			RegisterFunction("World_GetLocation", GetType().GetMethod("LUA_World_GetLocation"));
			observableList_0.Add("World_GetLocation(table)");
			RegisterFunction("World_GetCircleFromPoint", GetType().GetMethod("LUA_World_GetCircleFromPoint"));
			observableList_0.Add("World_GetCircleFromPoint(table)");
			RegisterFunction("World_GetPointFromBearing", GetType().GetMethod("LUA_World_GetPointFromBearing"));
			observableList_0.Add("World_GetPointFromBearing(table)");
			RegisterFunction("Tool_DumpEvents", GetType().GetMethod("Tool_DumpEvents"));
			observableList_0.Add("Tool_DumpEvents()");
			RegisterFunction("Tool_EmulateNoConsole", GetType().GetMethod("Tool_EmulateNoConsole"));
			observableList_0.Add("Tool_EmulateNoConsole()");
			RegisterFunction("Tool_Range", GetType().GetMethod("Tool_Range"));
			observableList_0.Add("Tool_Range(from, To [, slantRange])");
			RegisterFunction("Tool_Bearing", GetType().GetMethod("Tool_Bearing"));
			observableList_0.Add("Tool_Bearing(from, To)");
			RegisterFunction("Tool_UIwindow", GetType().GetMethod("Tool_UIwindow"));
			observableList_0.Add("Tool_UIwindow(name [,mode])");
			RegisterFunction("Tool_LOS", GetType().GetMethod("Tool_LOS"));
			observableList_0.Add("Tool_LOS(table)");
			RegisterFunction("Tool_LOS_Points", GetType().GetMethod("Tool_LOS_Points"));
			observableList_0.Add("Tool_LOS_Points(table, table, HorizonType)");
			RegisterFunction("Tool_ResetMessageLog", GetType().GetMethod("LUA_Tool_ResetMessageLog"));
			observableList_0.Add("Tool_ResetMessageLog([dumpLogBeforeClearing])");
			RegisterFunction("Tool_Scen_Migration", GetType().GetMethod("LUA_Tool_Scen_Migration"));
			observableList_0.Add("Tool_Scen_Migration(table)");
			RegisterFunction("VP_GetScenario", GetType().GetMethod("LUA_VP_GetScenario"));
			observableList_0.Add("VP_GetScenario()");
			RegisterFunction("Command_SaveScen", GetType().GetMethod("LUA_Command_SaveScen"));
			observableList_0.Add("Command_SaveScen(FullPath)");
			RegisterFunction("ScenEdit_IsUnitInZone", GetType().GetMethod("LUA_ScenEdit_IsUnitInZone"));
			observableList_0.Add("ScenEdit_IsUnitInZone(TheUnit_NameOrID, TheZone_NameOrID, Side_NameOrID, ScenarioContext)");
			RegisterFunction("ScenEdit_SplitUnit", GetType().GetMethod("LUA_ScenEdit_SplitUnit"));
			observableList_0.Add("ScenEdit_SplitUnit(table)");
			RegisterFunction("ScenEdit_MergeUnits", GetType().GetMethod("LUA_ScenEdit_MergeUnits"));
			observableList_0.Add("ScenEdit_MergeUnits()");
			RegisterFunction("ScenEdit_TransferMount", GetType().GetMethod("LUA_ScenEdit_TransferMount"));
			observableList_0.Add("ScenEdit_TransferMount(from, to, table)");
			RegisterFunction("Tool_QueryRCS", GetType().GetMethod("LUA_Tool_QueryRCS"));
			observableList_0.Add("Tool_QueryRCS(table)");
			RegisterFunction("Tool_QuerySoundLevel", GetType().GetMethod("LUA_Tool_QuerySoundLevel"));
			observableList_0.Add("Tool_QuerySoundLevel(table)");
			RegisterFunction("ScenEdit_UpdateRSetting", GetType().GetMethod("LUA_ScenEdit_UpdateRSetting"));
			RegisterFunction("ScenEdit_WeaponAllocation", GetType().GetMethod("LUA_ScenEdit_WeaponAllocation"));
			observableList_0.Add("ScenEdit_WeaponAllocation( Attacker ,Contact)");
			RegisterFunction("Tool_BuildBlankScenario", GetType().GetMethod("LUA_Tool_BuildBlankScenario"));
			observableList_0.Add("Tool_BuildBlankScenario( [dbFilename])");
			RegisterFunction("Tool_ConvertDecimalDegreesToDMS", GetType().GetMethod("LUA_Tool_ConvertDecimalDegreesToDMS"));
			observableList_0.Add("Tool_ConvertDecimalDegreesToDMS( latitude, longitude)");
			RegisterFunction("Tool_DateTimeToSeconds", GetType().GetMethod("LUA_DateTimeToSeconds"));
			observableList_0.Add("Tool_DateTimeToSeconds(date_string)");
			RegisterFunction("Tool_SecondsToDateTime", GetType().GetMethod("LUA_SecondsToDateTime"));
			observableList_0.Add("Tool_SecondsToDateTime(seconds)");
		}
		lua_0.DoString("math.randomseed( os.time() )");
		lua_0["_errmsg_"] = "none";
		lua_0["_errfnc_"] = "none";
		lua_0["_scriptfolder_"] = "";
		lua_0["_scenariofolder_"] = "";
		lua_0["_outputfolder_"] = "";
		SetLuaPathGlobals("");
		enumTable = new LuaEnuNames();
		lua_0["_enumTable_"] = enumTable;
		lua_0["CMANO"] = luaDynamicFunctions;
		method_1();
		if (stringBuilder_1.Length > 0)
		{
			lua_0.DoString(stringBuilder_1.ToString());
		}
		lua_0.DoString(stringBuilder_0.ToString());
		string text = Path.Combine(GameGeneral.TopLevelWritablePath, "Defaults", ".startup.lua");
		if (FileExistsNative.FileExistsFast(text))
		{
			string str = File.ReadAllText(text);
			RunScript(str, RunInteractively: false, "Initializing", text);
		}
	}

	public void ClearStats()
	{
		luaDynamicFunctions = null;
		enumTable = null;
		scenario_0 = null;
		UnitX = null;
		UnitY = null;
		UnitC = null;
		SensorsThatMadeDetection = null;
		EventX = null;
		CMANO.HandleScenarioChanging();
		lua_0.State.GarbageCollector(LuaGC.Collect, 0);
	}

	private void LuaSandBox_LuaPrint(object object_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(LuaUtility.LuaInterpret(RuntimeHelpers.GetObjectValue(object_0)));
		try
		{
			string InfoText = "";
			object debugTextObject = stringBuilder.ToString();
			LuaUtility.AddToLuaHistoryFile(ref InfoText, ref debugTextObject);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void LuaSandBox_LuaPrintException(object object_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(LuaUtility.LuaInterpret(RuntimeHelpers.GetObjectValue(object_0)));
		try
		{
			GameGeneral.WriteLogDebugInfoToFile(stringBuilder.ToString());
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public void SetLuaPathGlobals(string scriptFullpath)
	{
		if (lua_0 != null)
		{
			if (!string.IsNullOrEmpty(scriptFullpath))
			{
				lua_0["_scriptfolder_"] = Path.GetDirectoryName(scriptFullpath);
			}
			else
			{
				lua_0["_scriptfolder_"] = "";
			}
			if (scenario_0 != null && !string.IsNullOrEmpty(scenario_0.FileNamePath))
			{
				lua_0["_scenariofolder_"] = scenario_0.FileNamePath;
			}
			else
			{
				lua_0["_scenariofolder_"] = "";
			}
			if (Exporter_General.HasAnyActiveExporters())
			{
				lua_0["_outputfolder_"] = Exporter_General.GetCurrentActiveOutputPath();
			}
			else
			{
				lua_0["_outputfolder_"] = "";
			}
		}
	}

	public void myDebugHook(object sender, DebugHookEventArgs e)
	{
		LuaDebug luaDebug = e.LuaDebug;
		string InfoText = sender.ToString();
		object debugTextObject = luaDebug.ToString();
		LuaUtility.AddToLuaHistoryFile(ref InfoText, ref debugTextObject);
	}

	public void myExceptionHook(object sender, HookExceptionEventArgs e)
	{
		_ = e.Exception;
		string InfoText = sender.ToString();
		object debugTextObject = e.ToString();
		LuaUtility.AddToLuaHistoryFile(ref InfoText, ref debugTextObject);
	}

	public void UnitTests()
	{
	}

	private void method_0(string string_0)
	{
		currentFunction = string_0;
		if (Operators.CompareString(lua_0["_errmsg_"].ToString(), "", false) != 0)
		{
			lua_0["_errmsg_"] = "";
			lua_0["_errfnc_"] = "";
			lua_0["_errnum_"] = 0;
		}
	}

	public void RegisterFunction(string functionName, MethodInfo method)
	{
		try
		{
			if (lua_0.Globals.Contains(functionName + ".Method.Attributes"))
			{
				return;
			}
			lua_0.RegisterFunction(functionName, this, method);
			List<string> list = new List<string>();
			ParameterInfo[] parameters = method.GetParameters();
			foreach (ParameterInfo parameterInfo in parameters)
			{
				if (Operators.CompareString(parameterInfo.Name, "CoordsFormat", false) == 0)
				{
					list.Add("'DEC'/'DEG'");
				}
				else if (parameterInfo.ParameterType == typeof(string))
				{
					list.Add("'" + parameterInfo.Name + "'");
				}
				else
				{
					list.Add(parameterInfo.Name);
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

	[DoNotPrune]
	[DoNotObfuscate]
	public void LUA_UI_SelectThisUnit(string string_0, bool ThisUnitOnly, bool clearWaypointSelection = true)
	{
		method_0("UI_SelectThisUnit");
		try
		{
			PrivateMethods.UI_SelectThisUnit(string_0, ThisUnitOnly, clearWaypointSelection);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public void LUA_UI_OpenNewDatabaseWindow(string SelectedObjectType, int selectedObjectID)
	{
		method_0("UI_OpenNewDatabaseWindow");
		try
		{
			PrivateMethods.UI_OpenNewDatabaseWindow(SelectedObjectType, selectedObjectID);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public void LUA_UI_ShowWindow(string Window, LuaTable Args)
	{
		method_0("UI_ShowWindow");
		try
		{
			PrivateMethods.UI_ShowWindow(Window, Args);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public void LUA_UI_SetCameraView(double latitude, double longitude, int zoom = -99999)
	{
		method_0("UI_SetCameraView");
		try
		{
			PrivateMethods.UI_SetCameraView(latitude, longitude, zoom);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaTable LUA_UI_CallAdvancedHTMLDialog(string Title, string Html, LuaTable Interactions)
	{
		method_0("UI_CallAdvancedHTMLDialog");
		LuaTable result;
		try
		{
			result = PrivateMethods.UI_CallAdvancedHTMLDialog(Title, Html, Interactions);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public string LUA_UI_CallAdvancedDialog(string Title, string Description, LuaTable interactions)
	{
		method_0("UI_CallAdvancedDialog");
		string result;
		try
		{
			result = PrivateMethods.UI_CallAdvancedDialog(Title, Description, interactions);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaTable LUA_UI_SelectUnitsPrompt_OwnSide(ref LuaTable result, bool MultipleSelect)
	{
		method_0("UI_SelectUnitsPrompt_OwnSide");
		LuaTable result2;
		try
		{
			result2 = PrivateMethods.UI_SelectUnitsPrompt_OwnSide(ref result, MultipleSelect);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result2 = null;
			ProjectData.ClearProjectError();
		}
		return result2;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaTable LUA_UI_SelectUnitsPrompt_FromSides(ref LuaTable result, LuaTable SidesNameOrID, bool MultipleSelect, LuaTable Conditions)
	{
		method_0("UI_SelectUnitsPrompt_FromSides");
		LuaTable result2;
		try
		{
			result2 = PrivateMethods.UI_SelectUnitsPrompt_FromSides(ref result, SidesNameOrID, MultipleSelect);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result2 = null;
			ProjectData.ClearProjectError();
		}
		return result2;
	}

	[ObfuscateControlFlow]
	[DoNotPrune]
	public void LUA_ScenEdit_Print(object obj)
	{
		luaPrintEventHandler_0?.Invoke(RuntimeHelpers.GetObjectValue(obj));
	}

	[ObfuscateControlFlow]
	[DoNotPrune]
	public void LUA_ScenEdit_PrintException(object obj)
	{
		luaPrintExceptionEventHandler_0?.Invoke(RuntimeHelpers.GetObjectValue(obj));
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public void LUA_Command_SaveScen(string FilePath)
	{
		try
		{
			PrivateMethods.Command_SaveScen(FilePath, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public void LUA_ScenEdit_LockSimulationFidelity(bool IsLocked)
	{
		try
		{
			PrivateMethods.ScenEdit_LockSimulationFidelity(IsLocked, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public string LUA_ScenEdit_SetSimulationFidelity(float Fidelity)
	{
		try
		{
			return PrivateMethods.ScenEdit_SetSimulationFidelity(Fidelity, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
		}
		return "";
	}

	[DoNotPrune]
	[ObfuscateControlFlow]
	public void LUA_ScenEdit_PrintEscaped(object obj)
	{
		string text = Conversions.ToString(obj);
		text = text.Replace("\"", "\\\"").Replace("'", "\\'");
		LUA_ScenEdit_Print(text);
	}

	public object[] RunScript(string str, bool RunInteractively, string script = null, string fullPath = null)
	{
		object[] result;
		lock (ScriptLockObj)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Clear();
			int num = str.IndexOf('(');
			if (num > -1)
			{
				str.Substring(0, num);
			}
			str = str.Replace("\ufffd", "");
			RunInteractive = RunInteractively;
			if ((luaSandBox_0 != null) & !RunInteractive)
			{
				stringBuilder.Append(str);
				if (lua_0 != null)
				{
					string text = null;
					try
					{
						text = lua_0.GetString("_lua_event");
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
					if (text != null)
					{
						bool? flag = LuaUtility.ParseBoolean(text);
						flag = flag;
						if (flag != true)
						{
							_lua_event = false;
						}
						else
						{
							_lua_event = true;
						}
					}
				}
				if (_lua_event)
				{
					string InfoText = "Script:" + script;
					object debugTextObject = stringBuilder.ToString();
					LuaUtility.AddToLuaHistoryFile(ref InfoText, ref debugTextObject, includeHeader: true);
				}
			}
			currentLine = 0;
			try
			{
				object[] array;
				if (Operators.CompareString(str, "_VERSION", false) == 0)
				{
					array = lua_0.DoString("return _VERSION");
				}
				else
				{
					SetLuaPathGlobals(fullPath);
					try
					{
						array = (RunInteractive ? lua_0.DoString(str, "Console") : LuaUtility.DoString_Optimized(lua_0, str));
					}
					catch (LuaScriptException ex)
					{
						ProjectData.SetProjectError((Exception)ex);
						LuaScriptException ex2 = ex;
						if (!(ex2.InnerException is LuaError))
						{
							throw;
						}
						int num2;
						if (RunInteractive)
						{
							if (((LuaError)ex2.InnerException).sFunctionName == null)
							{
								GameGeneral.SendMessageBoxToUI(((LuaError)ex2.InnerException).sMessage, null);
								num2 = 2;
							}
							else
							{
								GameGeneral.SendMessageBoxToUI(((LuaError)ex2.InnerException).sFunctionName + " " + ((LuaError)ex2.InnerException).sLine + " : " + ((LuaError)ex2.InnerException).sMessage, null);
								num2 = 2;
							}
						}
						else
						{
							num2 = 2;
						}
						array = new object[num2];
						array[1] = ((LuaError)ex2.InnerException).sMessage;
						array[0] = ((LuaError)ex2.InnerException).sFunctionName + " " + ((LuaError)ex2.InnerException).sLine + " : ";
						result = array;
						ProjectData.ClearProjectError();
						goto end_IL_0114;
					}
				}
				result = array;
				end_IL_0114:;
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				if (Debugger.IsAttached & !bool_1)
				{
					Debugger.Break();
					bool_1 = true;
				}
				if (!(RunInteractive & !ex4.Message.Contains("unfinished string near")))
				{
					if (!ex4.Message.Contains("unfinished string near"))
					{
						string InfoText = "";
						object debugTextObject = ex4;
						LuaUtility.AddToLuaHistoryFile(ref InfoText, ref debugTextObject);
					}
					throw;
				}
				result = new object[2] { ex4, null };
				ProjectData.ClearProjectError();
			}
		}
		return result;
	}

	public object[] RunScript2(string str, bool RunInteractively, string script = null, string fullPath = null)
	{
		object[] result;
		lock (ScriptLock2Obj)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Clear();
			int num = str.IndexOf('(');
			if (num > -1)
			{
				str.Substring(0, num);
			}
			str = str.Replace("\ufffd", "");
			RunInteractive = RunInteractively;
			if ((luaSandBox_0 != null) & !RunInteractive)
			{
				stringBuilder.Append(str);
				if (lua_0 != null)
				{
					string text = null;
					try
					{
						text = lua_0.GetString("_lua_event");
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
					if (text != null)
					{
						bool? flag = LuaUtility.ParseBoolean(text);
						flag = flag;
						if (flag == true)
						{
							_lua_event = true;
						}
						else
						{
							_lua_event = false;
						}
					}
				}
				if (_lua_event)
				{
					string InfoText = "Script:" + script;
					object debugTextObject = stringBuilder.ToString();
					LuaUtility.AddToLuaHistoryFile(ref InfoText, ref debugTextObject, includeHeader: true);
				}
			}
			currentLine = 0;
			try
			{
				object[] array;
				if (Operators.CompareString(str, "_VERSION", false) != 0)
				{
					SetLuaPathGlobals(fullPath);
					try
					{
						array = (RunInteractive ? lua_0.DoString(str, "Console") : LuaUtility.DoString_Optimized(lua_0, str));
					}
					catch (LuaScriptException ex)
					{
						ProjectData.SetProjectError((Exception)ex);
						LuaScriptException ex2 = ex;
						if (!(ex2.InnerException is LuaError))
						{
							throw;
						}
						int num2;
						if (!RunInteractive)
						{
							num2 = 2;
						}
						else if (((LuaError)ex2.InnerException).sFunctionName == null)
						{
							GameGeneral.SendMessageBoxToUI(((LuaError)ex2.InnerException).sMessage, null);
							num2 = 2;
						}
						else
						{
							GameGeneral.SendMessageBoxToUI(((LuaError)ex2.InnerException).sFunctionName + " " + ((LuaError)ex2.InnerException).sLine + " : " + ((LuaError)ex2.InnerException).sMessage, null);
							num2 = 2;
						}
						array = new object[num2];
						array[1] = ((LuaError)ex2.InnerException).sMessage;
						array[0] = ((LuaError)ex2.InnerException).sFunctionName + " " + ((LuaError)ex2.InnerException).sLine + " : ";
						result = array;
						ProjectData.ClearProjectError();
						goto end_IL_0114;
					}
				}
				else
				{
					array = lua_0.DoString("return _VERSION");
				}
				result = array;
				end_IL_0114:;
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				if (!(RunInteractive & !ex4.Message.Contains("unfinished string near")))
				{
					if (!ex4.Message.Contains("unfinished string near"))
					{
						string InfoText = "";
						object debugTextObject = ex4;
						LuaUtility.AddToLuaHistoryFile(ref InfoText, ref debugTextObject);
					}
					throw;
				}
				result = new object[2] { ex4, null };
				ProjectData.ClearProjectError();
			}
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaWrapper_ActiveUnit_SE LUA_ScenEdit_UnitX()
	{
		method_0("ScenEdit_UnitX");
		LuaWrapper_ActiveUnit_SE result;
		if (UnitX != null)
		{
			try
			{
				result = ((!UnitX.GetType().Equals(typeof(UnguidedWeapon))) ? new LuaWrapper_ActiveUnit_SE((ActiveUnit)UnitX, scenario_0) : new LuaWrapper_ActiveUnit_SE((UnguidedWeapon)UnitX, scenario_0));
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				if (RunInteractive)
				{
					throw;
				}
				result = null;
				ProjectData.ClearProjectError();
			}
		}
		else
		{
			result = null;
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaTable LUA_ScenEdit_UnitY()
	{
		method_0("ScenEdit_UnitY");
		LuaTable result;
		if (UnitY != null)
		{
			try
			{
				LuaTable luaTable = luaSandBox_0.CreateTable();
				LuaWrapper_ActiveUnit_SE value = new LuaWrapper_ActiveUnit_SE(UnitY, scenario_0);
				luaTable["unit"] = value;
				LuaTable luaTable2 = luaSandBox_0.CreateTable();
				if (SensorsThatMadeDetection == null)
				{
					result = luaTable;
				}
				else
				{
					foreach (Sensor item in SensorsThatMadeDetection)
					{
						LuaTable luaTable3 = luaSandBox_0.CreateTable();
						luaTable3["name"] = item.Name;
						luaTable3["type"] = item.Type.ToString();
						luaTable2[luaTable2.Keys.Count + 1] = luaTable3;
					}
					luaTable["sensor"] = luaTable2;
					result = luaTable;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				if (RunInteractive)
				{
					throw;
				}
				result = null;
				ProjectData.ClearProjectError();
			}
		}
		else
		{
			result = null;
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaWrapper_Contact LUA_ScenEdit_UnitC()
	{
		method_0("ScenEdit_UnitC");
		LuaWrapper_Contact result;
		if (UnitC != null)
		{
			try
			{
				result = new LuaWrapper_Contact(UnitC, scenario_0, UnitY.get_UnitSide(SetSideOnly: false));
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				if (RunInteractive)
				{
					throw;
				}
				result = null;
				ProjectData.ClearProjectError();
			}
		}
		else
		{
			result = null;
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaWrapper_Event LUA_ScenEdit_EventX()
	{
		method_0("ScenEdit_EventX");
		LuaWrapper_Event result;
		if (EventX == null)
		{
			result = null;
		}
		else
		{
			try
			{
				result = new LuaWrapper_Event(EventX, 0, xml: false, scenario_0);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				if (RunInteractive)
				{
					throw;
				}
				result = null;
				ProjectData.ClearProjectError();
			}
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public int LUA_ScenEdit_CurrentTime()
	{
		method_0("ScenEdit_CurrentTime");
		int result;
		try
		{
			result = (int)Math.Round((scenario_0.Time - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public string LUA_ScenEdit_TransformZone(string SideNameOrID, string ZoneNameOrID, string TargetType)
	{
		method_0("ScenEdit_TransformZone");
		string result;
		try
		{
			result = PrivateMethods.ScenEdit_TransformZone(SideNameOrID, ZoneNameOrID, TargetType, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaTable LUA_ScenEdit_GetUnitIntermittentEmissionConfig(string PresetAlertID, string string_0)
	{
		method_0("ScenEdit_GetUnitIntermittentEmissionConfig");
		LuaTable result;
		try
		{
			result = PrivateMethods.ScenEdit_GetUnitIntermittentEmissionConfig(PresetAlertID, string_0, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_ScenEdit_SetUnitIntermittentEmissionConfig(string string_0, string PresetAlertID, LuaTable ConfigurationTable)
	{
		method_0("ScenEdit_SetUnitIntermittentEmissionConfig");
		bool result;
		try
		{
			result = PrivateMethods.ScenEdit_SetUnitIntermittentEmissionConfig(string_0, PresetAlertID, ConfigurationTable, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_DuplicateEmconConfigToUnit(string PresetAlertID, string SourceAUNameOrID, string TargetAUNameOrID)
	{
		method_0("ScenEdit_DuplicateEmconConfigToUnit");
		bool result;
		try
		{
			result = PrivateMethods.ScenEdit_DuplicateEmconConfigToUnit(PresetAlertID, SourceAUNameOrID, TargetAUNameOrID, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_ScenEdit_CreateBarkNotification_Geo_Bulk(float Longitude, float Latitude, LuaTable text, int R, int G, int B, bool MoveUpward = true, bool Fades = true, float Lifetime = 1f, float FontSize = 18f)
	{
		method_0("LUA_ScenEdit_CreateBarkNotification_Geo_Bulk");
		bool result;
		try
		{
			result = PrivateMethods.ScenEdit_CreateBarkNotification_Geo_Bulk(Longitude, Latitude, text, R, G, B, MoveUpward, Fades, Lifetime, FontSize, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_ScenEdit_CreateBarkNotification_Geo(float Longitude, float Latitude, string text, int R, int G, int B, bool MoveUpward = true, bool Fades = true, float Lifetime = 1f, float FontSize = 18f)
	{
		method_0("ScenEdit_CreateBarkNotification_Geo");
		bool result;
		try
		{
			result = PrivateMethods.ScenEdit_CreateBarkNotification_Geo(Longitude, Latitude, text, R, G, B, MoveUpward, Fades, Lifetime, FontSize, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_CreateBarkNotification_Unit(string string_0, string text, int R, int G, int B, bool MoveUpward = true, bool Fades = true, float Lifetime = 1f, float FontSize = 18f)
	{
		method_0("ScenEdit_CreateBarkNotification_Unit");
		bool result;
		try
		{
			result = PrivateMethods.ScenEdit_CreateBarkNotification_Unit(string_0, text, R, G, B, MoveUpward, Fades, Lifetime, FontSize, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_CreateBarkNotification_Unit_Bulk(string string_0, LuaTable text, int R, int G, int B, bool MoveUpward = true, bool Fades = true, float Lifetime = 1f, float FontSize = 18f)
	{
		method_0("LUA_ScenEdit_CreateBarkNotification_Unit_Bulk");
		bool result;
		try
		{
			result = PrivateMethods.ScenEdit_CreateBarkNotification_Unit_Bulk(string_0, text, R, G, B, MoveUpward, Fades, Lifetime, FontSize, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_ScenEdit_SwitchUnitIntermittentEmission(string string_0, string PresetAlertID, float Switch)
	{
		method_0("ScenEdit_SwitchUnitIntermittentEmission");
		bool result;
		try
		{
			result = PrivateMethods.ScenEdit_SwitchUnitIntermittentEmission(string_0, PresetAlertID, Switch, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_SetSideEmconAlertness(string SideNameOrID, string AlertID)
	{
		method_0("ScenEdit_SetSideEmconAlertness");
		bool result;
		try
		{
			result = PrivateMethods.ScenEdit_SetSideEmconAlertness(SideNameOrID, AlertID, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_ClearAllSideUnitsEmconConfigs(string SideNameOrID)
	{
		method_0("ScenEdit_ClearAllSideUnitsEmconConfigs");
		bool result;
		try
		{
			result = PrivateMethods.ScenEdit_ClearAllSideUnitsEmconConfigs(SideNameOrID, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_DuplicateEmconConfigToSide(string PresetAlertID, string SourceAUNameOrID, string TargetSideNameOrID)
	{
		method_0("ScenEdit_DuplicateEmconConfigToSide");
		bool result;
		try
		{
			result = PrivateMethods.ScenEdit_DuplicateEmconConfigToSide(PresetAlertID, SourceAUNameOrID, TargetSideNameOrID, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_ClearUnitEmconConfigs(string UnitNameorID)
	{
		method_0("ScenEdit_SetSideEmconAlertness");
		bool result;
		try
		{
			result = PrivateMethods.ScenEdit_ClearUnitEmconConfigs(UnitNameorID, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_Exporter_SetSetting(string Category, string Setting, string Value)
	{
		method_0("Exporter_SetSetting");
		bool result = default(bool);
		try
		{
			result = PrivateMethods.Exporter_SetSetting(Category, Setting, Value, scenario_0);
			return result;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public string LUA_ScenEdit_CurrentLocalTime()
	{
		method_0("ScenEdit_CurrentLocalTime");
		string result;
		try
		{
			Side currentSide = scenario_0.GetCurrentSide();
			DateTime dateTime = Misc.LocalTime(theLon: ((currentSide != null) ? currentSide.MapCenter : new GeoPoint(0.0, 0.0)).Longitude, ZuluTime: scenario_0.Time, DaylightSavingTime: scenario_0.Use_DST, DaylightSavingTime_Start: scenario_0.DST_Start, DaylightSavingTime_End: scenario_0.DST_End);
			result = dateTime.Hour.ToString("D2") + ":" + dateTime.Minute.ToString("D2") + ":" + dateTime.Second.ToString("D2");
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public string LUA_Echo(string s)
	{
		return s;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public string LUA_GetBuildNumber()
	{
		method_0("GetBuildNumber");
		return "v1.10 - Build 1900.20";
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public void LUA_VP_SetTimeCompression(int value)
	{
		method_0("VP_SetTimeCompression");
		scenario_0.TimeCompression_Set((Scenario.enumTimeCompression)value);
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public void LUA_VP_PauseSimulation()
	{
		method_0("VP_PauseSimulation");
		scenario_0.GameContext.Pause();
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public void LUA_VP_RunSimulation()
	{
		method_0("VP_RunSimulation");
		scenario_0.GameContext.Run();
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public string LUA_VP_RunToTimeAndHalt(LuaTable table)
	{
		method_0("VP_RunToTimeAndHalt");
		string result = PrivateMethods.ScenEdit_RunToTimeAndHalt(table, scenario_0);
		scenario_0.GameContext.Run();
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public string LUA_VP_RunForTimeAndHalt(LuaTable table)
	{
		method_0("VP_RunForTimeAndHalt");
		string result = PrivateMethods.ScenEdit_RunForTimeAndHalt(table, scenario_0);
		scenario_0.GameContext.Run();
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public string LUA_GetScenarioTitle()
	{
		method_0("GetScenarioTitle");
		return scenario_0.Title;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_SetScenarioTitle(string newTitle)
	{
		method_0("SetScenarioTitle");
		scenario_0.Title = newTitle;
		return true;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_SetScenarioMessageLogPath(string thePath)
	{
		method_0("SetScenarioMessageLogpath");
		string fullPath = Path.GetFullPath(GameGeneral.LogsPath);
		if (!Path.IsPathRooted(thePath))
		{
			scenario_0.MessageLogFilePath = Path.GetFullPath(Path.Combine(fullPath, thePath));
		}
		else
		{
			scenario_0.MessageLogFilePath = Path.GetFullPath(thePath);
		}
		string directoryName = Path.GetDirectoryName(scenario_0.MessageLogFilePath);
		if (!Directory.Exists(directoryName))
		{
			try
			{
				Directory.CreateDirectory(directoryName);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				throw new LuaError(ex2.Message);
			}
		}
		return true;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public void LUA_ScenEdit_ClearAllMagazines(LuaTable table)
	{
		method_0("ScenEdit_ClearAllMagazines");
		try
		{
			PrivateMethods.ScenEdit_ClearAllMagazines(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public void LUA_ScenEdit_ClearAllAircraft(LuaTable table)
	{
		method_0("ScenEdit_ClearAllAircraft");
		try
		{
			PrivateMethods.ScenEdit_ClearAllAircraft(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaTable LUA_VP_GetSides()
	{
		method_0("VP_GetSides");
		LuaTable result;
		try
		{
			result = LuaSide.VP_GetSides(scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaWrapper_Side LUA_VP_GetSide(LuaTable table)
	{
		method_0("VP_GetSide");
		LuaWrapper_Side result;
		try
		{
			result = LuaSide.VP_GetSide(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaWrapper_ActiveUnit LUA_VP_GetUnit(LuaTable table)
	{
		method_0("VP_GetUnit");
		LuaWrapper_ActiveUnit result;
		try
		{
			result = PrivateMethods.VP_GetUnit(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaWrapper_Contact LUA_VP_GetContact(LuaTable table)
	{
		method_0("VP_GetContact");
		LuaWrapper_Contact result;
		try
		{
			result = PrivateMethods.VP_GetContact(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaWrapper_Scenario LUA_VP_GetScenario()
	{
		method_0("VP_GetScenario");
		LuaWrapper_Scenario result;
		try
		{
			result = PrivateMethods.VP_GetScenario(scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public string LUA_ScenEdit_AddAircraft(string SideNameOrID, string ACName, int DBID, int LoadoutID, string CoordsFormat, string Lat, string Lon)
	{
		method_0("ScenEdit_AddAircraft");
		return PrivateMethods.ScenEdit_AddAircraft(SideNameOrID, ACName, DBID, LoadoutID, CoordsFormat, Lat, Lon, scenario_0);
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public string LUA_ScenEdit_AddShip(string SideNameOrID, string ShipName, int DBID, string CoordsFormat, string Lat, string Lon)
	{
		method_0("ScenEdit_AddShip");
		return PrivateMethods.ScenEdit_AddShip(SideNameOrID, ShipName, DBID, CoordsFormat, Lat, Lon, scenario_0);
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public string LUA_ScenEdit_AddSubmarine(string SideNameOrID, string SubName, int DBID, string CoordsFormat, string Lat, string Lon)
	{
		method_0("ScenEdit_AddSubmarine");
		return PrivateMethods.ScenEdit_AddSubmarine(SideNameOrID, SubName, DBID, CoordsFormat, Lat, Lon, scenario_0);
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public string LUA_ScenEdit_AddFacility(string SideNameOrID, string FacName, int DBID, int FacilityOrientation, string CoordsFormat, string Lat, string Lon)
	{
		method_0("ScenEdit_AddFacility");
		return PrivateMethods.ScenEdit_AddFacility(SideNameOrID, FacName, DBID, FacilityOrientation, CoordsFormat, Lat, Lon, scenario_0);
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_ScenEdit_AssignUnitToMission(string string_0, string MissionNameOrID, bool Escort = false, bool MissionPlanner = false)
	{
		method_0("ScenEdit_AssignUnitToMission");
		bool value = LuaUtility.ParseBoolean(Escort).Value;
		bool value2 = LuaUtility.ParseBoolean(MissionPlanner).Value;
		bool result;
		try
		{
			result = PrivateMethods.ScenEdit_AssignUnitToMission(string_0, MissionNameOrID, scenario_0, (ActiveUnit)UnitX, value, value2);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public string LUA_SecondsToDateTime(long seconds, string format = null)
	{
		method_0("SecondsToDateTime");
		string result;
		try
		{
			result = LuaUtility.SecondsToDateTime(seconds, format);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public long LUA_DateTimeToSeconds(string theDate)
	{
		method_0("DateTimeToSeconds");
		long result;
		try
		{
			result = LuaUtility.DateTimeToSeconds(theDate);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = 0L;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public string LUA_EpochToUTC_Date(int epoch)
	{
		method_0("EpochToUTC_Date");
		string result;
		try
		{
			result = PrivateMethods.EpochToUTC_Date(epoch);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public string LUA_EpochToUTC_Time(int epoch)
	{
		method_0("EpochToUTC_Time");
		string result;
		try
		{
			result = PrivateMethods.EpochToUTC_Time(epoch);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public double LUA_ScenEdit_SetTime(LuaTable table)
	{
		method_0("ScenEdit_SetTime");
		double result;
		try
		{
			result = PrivateMethods.ScenEdit_SetTime(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = 0.0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public double LUA_ScenEdit_SetStartTime(LuaTable table)
	{
		method_0("ScenEdit_SetStartTime");
		double result;
		try
		{
			result = PrivateMethods.ScenEdit_SetStartTime(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = 0.0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_SetWeather(int AvgTemp, int RainfallRate, float FractionUnderRain, int SeaState)
	{
		method_0("ScenEdit_SetWeather");
		bool result;
		try
		{
			result = PrivateMethods.ScenEdit_SetWeather(AvgTemp, RainfallRate, FractionUnderRain, SeaState, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaTable LUA_ScenEdit_GetWeather()
	{
		method_0("ScenEdit_GetWeather");
		LuaTable result;
		try
		{
			result = PrivateMethods.ScenEdit_GetWeather(scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_SetSidePosture(string SideANameOrID, string SideBNameOrID, string PostureCode)
	{
		method_0("ScenEdit_SetSidePosture");
		bool result;
		try
		{
			result = LuaSide.ScenEdit_SetSidePosture(SideANameOrID, SideBNameOrID, PostureCode, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaTable LUA_ScenEdit_SetSideOptions(LuaTable table)
	{
		method_0("ScenEdit_SetSideOptions");
		LuaTable result;
		try
		{
			result = LuaSide.ScenEdit_SetSideOptions(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaTable LUA_ScenEdit_SetUnitDamage(LuaTable table)
	{
		method_0("ScenEdit_SetUnitDamage");
		LuaTable result;
		try
		{
			result = PrivateMethods.ScenEdit_SetUnitDamage(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_SetSpecialAction(LuaTable table)
	{
		method_0("ScenEdit_SetSpecialAction");
		bool result;
		try
		{
			result = LuaEvent.ScenEdit_SetSpecialAction(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_ScenEdit_AddSpecialAction(LuaTable table)
	{
		method_0("ScenEdit_AddSpecialAction");
		bool result;
		try
		{
			result = LuaEvent.ScenEdit_AddSpecialAction(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_ScenEdit_SetExportOutputRate(string exportType, string rate)
	{
		method_0("ScenEdit_SetExportOutputRate");
		bool result;
		try
		{
			result = PrivateMethods.ScenEdit_SetExportOutputRate(exportType, rate);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_ScenEdit_SetEMCON(string EMCONSubjectType, string string_0, string EMCONSettings)
	{
		method_0("ScenEdit_SetEMCON");
		bool result;
		try
		{
			result = PrivateMethods.ScenEdit_SetEMCON(EMCONSubjectType, string_0, EMCONSettings, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public string LUA_ScenEdit_MsgBox(string str, int style)
	{
		method_0("ScenEdit_MsgBox");
		return PrivateMethods.ScenEdit_MsgBox(str, style, scenario_0);
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public string LUA_ScenEdit_InputBox(string str)
	{
		method_0("ScenEdit_InputBox");
		return PrivateMethods.ScenEdit_InputBox(str, scenario_0);
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_RunScript(string str, bool useCustomPath = false)
	{
		method_0("ScenEdit_RunScript");
		string text = null;
		string text2 = Path.Combine(GameGeneral.TopLevelWritablePath, "Lua");
		string text3 = (useCustomPath ? str : (text2 + "\\" + str));
		bool result;
		try
		{
			if (FileExistsNative.FileExistsFast(text3))
			{
				text = File.ReadAllText(text3);
				SetLuaPathGlobals(text3);
				string InfoText = "Script";
				object debugTextObject = currentFunction + " executing Lua\\" + str;
				LuaUtility.AddToLuaHistoryFile(ref InfoText, ref debugTextObject, includeHeader: true);
			}
			else
			{
				if (!str.Contains(GameGeneral.AttachmentRepoPath))
				{
					throw new LuaError("File path '" + str + "' not found");
				}
				text = File.ReadAllText(str);
				SetLuaPathGlobals(str);
				string InfoText = "Script";
				object debugTextObject = currentFunction + " executing " + str;
				LuaUtility.AddToLuaHistoryFile(ref InfoText, ref debugTextObject, includeHeader: true);
			}
			LuaUtility.DoString_Optimized(lua_0, text, str);
			result = !(Conversions.ToDouble(lua_0["_errnum_"]) > 0.0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public string LUA_ScenEdit_SetKeyValue(string key, object value, bool forCampaign = false)
	{
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Expected O, but got Unknown
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected O, but got Unknown
		method_0("ScenEdit_SetKeyValue");
		key = Strings.Replace(key, " ", "_", 1, -1, (CompareMethod)0);
		if (scenario_0.IsRunningInCampaignMode && forCampaign)
		{
			if (string.IsNullOrWhiteSpace(scenario_0.LuaXmlPassed))
			{
				scenario_0.LuaXmlPassed = "<KeyValueDatastore></KeyValueDatastore>";
			}
			XElement val = XElement.Parse(scenario_0.LuaXmlPassed);
			XElement val2 = ((XContainer)val).Element(XName.op_Implicit(key));
			if (val2 == null)
			{
				val2 = new XElement(XName.op_Implicit(key), RuntimeHelpers.GetObjectValue(value));
				((XContainer)val).Add((object)val2);
			}
			else
			{
				val2.Value = value.ToString();
			}
			scenario_0.LuaXmlPassed = ((XNode)val).ToString();
		}
		else
		{
			if (forCampaign)
			{
				return "Not in campaign mode";
			}
			if (string.IsNullOrWhiteSpace(scenario_0.LuaXml))
			{
				scenario_0.LuaXml = "<KeyValueDatastore></KeyValueDatastore>";
			}
			XElement val = XElement.Parse(scenario_0.LuaXml);
			XElement val3 = ((XContainer)val).Element(XName.op_Implicit(key));
			if (val3 != null)
			{
				val3.Value = value.ToString();
			}
			else
			{
				val3 = new XElement(XName.op_Implicit(key), RuntimeHelpers.GetObjectValue(value));
				((XContainer)val).Add((object)val3);
			}
			scenario_0.LuaXml = ((XNode)val).ToString();
		}
		return "Saved";
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public string LUA_ScenEdit_GetKeyValue(string key, bool forCampaign = false)
	{
		method_0("ScenEdit_GetKeyValue");
		key = Strings.Replace(key, " ", "_", 1, -1, (CompareMethod)0);
		XElement val;
		if (scenario_0.IsRunningInCampaignMode && forCampaign)
		{
			if (string.IsNullOrWhiteSpace(scenario_0.LuaXmlPassed))
			{
				scenario_0.LuaXmlPassed = "<KeyValueDatastore></KeyValueDatastore>";
			}
			val = XElement.Parse(scenario_0.LuaXmlPassed);
		}
		else
		{
			if (string.IsNullOrWhiteSpace(scenario_0.LuaXml))
			{
				scenario_0.LuaXml = "<KeyValueDatastore></KeyValueDatastore>";
			}
			val = XElement.Parse(scenario_0.LuaXml);
		}
		XElement val2 = ((XContainer)val).Element(XName.op_Implicit(key));
		if (val2 != null)
		{
			return val2.Value;
		}
		return "";
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaTable LUA_ScenEdit_GetKeyStore(bool forCampaign = false)
	{
		method_0("ScenEdit_GetKeyStore");
		XElement val;
		if (scenario_0.IsRunningInCampaignMode && forCampaign)
		{
			if (string.IsNullOrWhiteSpace(scenario_0.LuaXmlPassed))
			{
				scenario_0.LuaXmlPassed = "<KeyValueDatastore></KeyValueDatastore>";
			}
			val = XElement.Parse(scenario_0.LuaXmlPassed);
		}
		else
		{
			if (string.IsNullOrWhiteSpace(scenario_0.LuaXml))
			{
				scenario_0.LuaXml = "<KeyValueDatastore></KeyValueDatastore>";
			}
			val = XElement.Parse(scenario_0.LuaXml);
		}
		LuaTable luaTable = luaSandBox_0.CreateTable();
		IEnumerable<XElement> enumerable = ((XContainer)val).Elements();
		foreach (XElement item in enumerable)
		{
			luaTable[item.Name.ToString()] = item.Value;
		}
		return luaTable;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_ScenEdit_ClearKeyValue(string key, bool forCampaign = false)
	{
		method_0("ScenEdit_ClearKeyValue");
		XElement val = null;
		key = Strings.Replace(key, " ", "_", 1, -1, (CompareMethod)0);
		if (scenario_0.IsRunningInCampaignMode && forCampaign)
		{
			if (Operators.CompareString(key, "", false) == 0)
			{
				scenario_0.LuaXmlPassed = null;
				return true;
			}
			if (string.IsNullOrWhiteSpace(scenario_0.LuaXmlPassed))
			{
				scenario_0.LuaXmlPassed = "<KeyValueDatastore></KeyValueDatastore>";
			}
			val = XElement.Parse(scenario_0.LuaXmlPassed);
		}
		else
		{
			if (forCampaign)
			{
				return false;
			}
			if (Operators.CompareString(key, "", false) == 0)
			{
				scenario_0.LuaXml = null;
				return true;
			}
			if (string.IsNullOrWhiteSpace(scenario_0.LuaXml))
			{
				scenario_0.LuaXml = "<KeyValueDatastore></KeyValueDatastore>";
			}
			val = XElement.Parse(scenario_0.LuaXml);
		}
		XElement val2 = ((XContainer)val).Element(XName.op_Implicit(key));
		if (val2 == null)
		{
			return false;
		}
		((XNode)val2).Remove();
		int result;
		if (forCampaign)
		{
			scenario_0.LuaXmlPassed = ((XNode)val).ToString();
			result = 1;
		}
		else
		{
			scenario_0.LuaXml = ((XNode)val).ToString();
			result = 1;
		}
		return (byte)result != 0;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaWrapper_ActiveUnit_SE LUA_ScenEdit_AddUnit(LuaTable table)
	{
		method_0("ScenEdit_AddUnit");
		LuaWrapper_ActiveUnit_SE result;
		try
		{
			result = PrivateMethods.ScenEdit_AddUnit(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaWrapper_ActiveUnit_SE LUA_ScenEdit_UpdateUnit(LuaTable table)
	{
		method_0("ScenEdit_UpdateUnit");
		LuaWrapper_ActiveUnit_SE result;
		try
		{
			result = PrivateMethods.ScenEdit_UpdateUnit(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaWrapper_ActiveUnit_SE LUA_ScenEdit_UpdateUnitCargo(LuaTable table)
	{
		method_0("ScenEdit_UpdateUnitCargo");
		LuaWrapper_ActiveUnit_SE result;
		try
		{
			result = PrivateMethods.ScenEdit_UpdateUnitCargo(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_ScenEdit_AddExplosion(LuaTable table)
	{
		method_0("ScenEdit_AddExplosion");
		bool result;
		try
		{
			result = PrivateMethods.ScenEdit_AddExplosion(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaWrapper_ActiveUnit_SE LUA_ScenEdit_SetUnit(LuaTable table)
	{
		method_0("ScenEdit_SetUnit");
		LuaWrapper_ActiveUnit_SE result;
		try
		{
			result = PrivateMethods.ScenEdit_SetUnit(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaTable LUA_ScenEdit_GetTimeOfDay(LuaTable table)
	{
		method_0("ScenEdit_GetTimeOfDay");
		LuaTable result;
		try
		{
			result = PrivateMethods.ScenEdit_GetTimeOfDay(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaWrapper_ActiveUnit_SE LUA_ScenEdit_GetUnit(LuaTable table)
	{
		method_0("ScenEdit_GetUnit");
		LuaWrapper_ActiveUnit_SE result;
		try
		{
			result = PrivateMethods.ScenEdit_GetUnit(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_ScenEdit_DeleteUnit(LuaTable table, bool withGroup = false)
	{
		method_0("ScenEdit_DeleteUnit");
		bool result;
		try
		{
			result = PrivateMethods.ScenEdit_DeleteUnit(table, withGroup, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_ScenEdit_KillUnit(LuaTable table)
	{
		method_0("ScenEdit_KillUnit");
		bool result;
		try
		{
			result = PrivateMethods.ScenEdit_KillUnit(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_ScenEdit_SetUnitSide(LuaTable table)
	{
		method_0("ScenEdit_SetUnitSide");
		bool result;
		try
		{
			result = PrivateMethods.ScenEdit_SetUnitSide(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaWrapper_ReferencePoint LUA_ScenEdit_AddReferencePoint(LuaTable table)
	{
		method_0("ScenEdit_AddReferencePoint");
		LuaWrapper_ReferencePoint result;
		try
		{
			result = LuaReferencePoint.ScenEdit_AddReferencePoint(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_SetLoadoutAvailable(LuaTable table)
	{
		method_0("ScenEdit_SetLoadoutAvailable");
		bool result;
		try
		{
			result = PrivateMethods.ScenEdit_SetLoadoutAvailable(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaWrapper_ReferencePoint LUA_ScenEdit_SetReferencePoint(LuaTable table)
	{
		method_0("ScenEdit_SetReferencePoint");
		LuaWrapper_ReferencePoint result;
		try
		{
			result = LuaReferencePoint.ScenEdit_SetReferencePoint(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaWrapper_ReferencePoint LUA_ScenEdit_GetReferencePoint(LuaTable table)
	{
		method_0("ScenEdit_GetReferencePoint");
		LuaWrapper_ReferencePoint result;
		try
		{
			result = LuaReferencePoint.ScenEdit_GetReferencePoint(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaTable LUA_ScenEdit_GetReferencePoints(LuaTable table)
	{
		method_0("ScenEdit_GetReferencePoints");
		LuaTable result;
		try
		{
			result = LuaReferencePoint.ScenEdit_GetReferencePoints(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_ScenEdit_DeleteReferencePoint(LuaTable table)
	{
		method_0("ScenEdit_DeleteReferencePoint");
		bool result;
		try
		{
			result = LuaReferencePoint.ScenEdit_DeleteReferencePoint(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaTable LUA_ScenEdit_SetDoctrine(LuaTable table, LuaTable d)
	{
		method_0("ScenEdit_SetDoctrine");
		LuaTable result;
		try
		{
			result = LuaDoctrine.ScenEdit_SetDoctrine(table, d, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaTable LUA_ScenEdit_SetDoctrineWRA(LuaTable table, LuaTable d)
	{
		method_0("ScenEdit_SetDoctrineWRA");
		LuaTable result;
		try
		{
			result = LuaDoctrine.ScenEdit_SetDoctrineWRA(table, d, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaTable LUA_ScenEdit_GetDoctrine(LuaTable table)
	{
		method_0("ScenEdit_GetDoctrine");
		LuaTable result;
		try
		{
			result = LuaDoctrine.ScenEdit_GetDoctrine(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public string LUA_ScenEdit_GetDBFileHash(LuaTable table)
	{
		method_0("ScenEdit_GetDBFileHash");
		string result;
		try
		{
			result = PrivateMethods.ScenEdit_GetDBFileHash(table);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaTable LUA_ScenEdit_GetSensorData(int DBID)
	{
		method_0("ScenEdit_GetSensorData");
		LuaTable result;
		try
		{
			result = PrivateMethods.ScenEdit_GetSensorData(DBID, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaTable LUA_ScenEdit_GetDoctrineWRA(LuaTable table)
	{
		method_0("ScenEdit_GetDoctrineWRA");
		LuaTable result;
		try
		{
			result = LuaDoctrine.ScenEdit_GetDoctrineWRA(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public object LUA_ScenEdit_HostUnitToParent(LuaTable table)
	{
		method_0("ScenEdit_HostUnitToParent");
		object result;
		try
		{
			result = PrivateMethods.ScenEdit_HostUnitToParent(table, scenario_0, (ActiveUnit)UnitX);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaTable LUA_ScenEdit_GetSideOptions(LuaTable table)
	{
		method_0("ScenEdit_GetSideOptions");
		LuaTable result;
		try
		{
			result = PrivateMethods.ScenEdit_GetSideOptions(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public string LUA_ScenEdit_GetSidePosture(string SideANameOrID, string SideBNameOrID)
	{
		method_0("ScenEdit_GetSidePosture");
		string result;
		try
		{
			result = PrivateMethods.ScenEdit_GetSidePosture(SideANameOrID, SideBNameOrID, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_ScenEdit_GetSideIsHuman(string SideANameOrID)
	{
		method_0("ScenEdit_GetSideIsHuman");
		bool result;
		try
		{
			result = LuaSide.ScenEdit_GetSideIsHuman(SideANameOrID, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_GetSideIsPlayer(string SideANameOrID)
	{
		method_0("ScenEdit_GetSideIsPlayer");
		bool result;
		try
		{
			result = LuaSide.ScenEdit_GetSideIsPlayer(SideANameOrID, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[ObfuscateControlFlow]
	[DoNotPrune]
	public bool LUA_ScenEdit_UseAttachment(string string_0)
	{
		method_0("ScenEdit_UseAttachment");
		bool result;
		try
		{
			result = LuaSAO.ScenEdit_UseAttachment(string_0, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[ObfuscateControlFlow]
	public bool LUA_ScenEdit_UseAttachmentOnSide(string string_0, string SideNameOrID)
	{
		method_0("ScenEdit_UseAttachmentOnSide");
		bool result;
		try
		{
			result = LuaSAO.ScenEdit_UseAttachmentOnSide(string_0, SideNameOrID, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[ObfuscateControlFlow]
	[DoNotPrune]
	public bool LUA_ScenEdit_PlaySound(string FileName, int delay = 0)
	{
		method_0("ScenEdit_PlaySound");
		bool result;
		try
		{
			result = PrivateMethods.ScenEdit_LocalSound(FileName, delay);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[ObfuscateControlFlow]
	[DoNotPrune]
	public string LUA_ScenEdit_PlayVideo(string FileName, bool FullScreen = true, int delay = 0)
	{
		method_0("ScenEdit_PlayVideo");
		string result;
		try
		{
			result = PrivateMethods.ScenEdit_LocalVideo(FileName, scenario_0, FullScreen, delay);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public int LUA_ScenEdit_GetScore(string SideNameOrID)
	{
		method_0("ScenEdit_GetScore");
		int result;
		try
		{
			result = PrivateMethods.ScenEdit_GetScore(SideNameOrID, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public int LUA_ScenEdit_SetScore(string SideNameOrID, int Score, string ReasonForChange = "No reason given")
	{
		method_0("ScenEdit_SetScore");
		int result;
		try
		{
			result = PrivateMethods.ScenEdit_SetScore(SideNameOrID, Score, scenario_0, ReasonForChange);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_GetScenHasStarted()
	{
		method_0("ScenEdit_GetScenHasStarted");
		return scenario_0.HasStarted;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_GetGameIsRTMP()
	{
		method_0("ScenEdit_GetGameIsRTMP");
		return scenario_0.RunningInRTMPHost;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_SetLoadout(LuaTable table)
	{
		method_0("ScenEdit_SetLoadout");
		bool result;
		try
		{
			result = PrivateMethods.ScenEdit_SetLoadout(table, scenario_0, (ActiveUnit)UnitX);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public int LUA_ScenEdit_SpecialMessage(string SideNameOrID, string Text, LuaTable location = null, bool ForceMapRecentre = false)
	{
		method_0("ScenEdit_SpecialMessage");
		int result;
		try
		{
			result = PrivateMethods.ScenEdit_SpecialMessage(SideNameOrID, Text, scenario_0, location, ForceMapRecentre);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public int LUA_ScenEdit_CustomUI(string SideNameOrID, string Text, LuaTable location = null, bool ForceMapRecentre = false)
	{
		method_0("ScenEdit_CustomUI");
		int result;
		try
		{
			result = PrivateMethods.ScenEdit_CustomUI(SideNameOrID, Text, scenario_0, location, ForceMapRecentre);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public string LUA_ScenEdit_PlayerSide()
	{
		method_0("ScenEdit_PlayerSide");
		return scenario_0.GetCurrentSide().Name;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public int LUA_ScenEdit_EndScenario()
	{
		method_0("ScenEdit_EndScenario");
		scenario_0.EndScenario();
		return 1;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public int LUA_ScenEdit_ExportInst(string SideNameOrID, LuaTable units, LuaTable fileData)
	{
		method_0("ScenEdit_ExportInst");
		int result;
		try
		{
			result = LuaImportExport.ScenEdit_ExportInst(SideNameOrID, units, fileData, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public int LUA_ScenEdit_ImportInst(string SideNameOrID, string InstFile)
	{
		method_0("ScenEdit_ImportInst");
		int result;
		try
		{
			result = LuaImportExport.ScenEdit_ImportInst(SideNameOrID, InstFile, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaWrapper_Side LUA_ScenEdit_AddSide(LuaTable table)
	{
		method_0("ScenEdit_AddSide");
		LuaWrapper_Side result;
		try
		{
			result = LuaSide.ScenEdit_AddSide(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaWrapper_Side LUA_ScenEdit_RemoveSide(LuaTable table)
	{
		method_0("ScenEdit_RemoveSide");
		LuaWrapper_Side result;
		try
		{
			result = LuaSide.ScenEdit_RemoveSide(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public int LUA_World_GetElevation(LuaTable table)
	{
		method_0("World_GetElevation");
		int result;
		try
		{
			result = PrivateMethods.World_GetElevation(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaTable LUA_World_GetLocation(LuaTable table)
	{
		method_0("World_GetLocation");
		LuaTable result;
		try
		{
			result = PrivateMethods.World_GetLocation(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaTable LUA_World_GetCircleFromPoint(LuaTable theTable)
	{
		method_0("World_GetCircleFromPoint");
		LuaTable result;
		try
		{
			result = PrivateMethods.World_GetCircleFromPoint(theTable);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaTable LUA_World_GetPointFromBearing(LuaTable theTable)
	{
		method_0("World_GetPointFromBearing");
		LuaTable result;
		try
		{
			result = PrivateMethods.World_GetPointFromBearing(theTable);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public int LUA_ScenEdit_AddReloadsToUnit(LuaTable table)
	{
		method_0("ScenEdit_AddReloadsToUnit");
		int result;
		try
		{
			result = PrivateMethods.ScenEdit_AddReloadsToUnit(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public int LUA_ScenEdit_AddWeaponToUnitMagazine(LuaTable table)
	{
		method_0("ScenEdit_AddWeaponToUnitMagazine");
		int result;
		try
		{
			result = PrivateMethods.ScenEdit_AddWeaponToUnitMagazine(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public void LUA_ScenEdit_DistributeWeaponAtAirbase(LuaTable table)
	{
		method_0("ScenEdit_DistributeWeaponAtAirbase");
		try
		{
			PrivateMethods.ScenEdit_DistributeWeaponAtAirbase(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public string LUA_ScenEdit_RefuelUnit(LuaTable table)
	{
		method_0("ScenEdit_RefuelUnit");
		string result;
		try
		{
			result = PrivateMethods.ScenEdit_RefuelUnit(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaWrapper_Mission LUA_ScenEdit_AddMission(string SideName, string MissionNameOrID, string MissionType, LuaTable table)
	{
		method_0("ScenEdit_AddMission");
		LuaWrapper_Mission result;
		try
		{
			result = LuaMission.ScenEdit_AddMission(SideName, MissionNameOrID, MissionType, table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaTable LUA_ScenEdit_GetMissions(string SideName)
	{
		method_0("ScenEdit_GetMissions");
		LuaTable result;
		try
		{
			result = LuaMission.ScenEdit_GetMissions(SideName, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaWrapper_Mission LUA_ScenEdit_GetMission(string SideName, string MissionNameOrID)
	{
		method_0("ScenEdit_GetMission");
		LuaWrapper_Mission result;
		try
		{
			result = LuaMission.ScenEdit_GetMission(SideName, MissionNameOrID, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_DeleteMission(string SideName, string MissionNameOrID)
	{
		method_0("ScenEdit_DeleteMission");
		bool result;
		try
		{
			result = LuaMission.ScenEdit_DeleteMission(SideName, MissionNameOrID, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaWrapper_Mission LUA_ScenEdit_SetMission(string SideName, string MissionNameOrID, LuaTable table)
	{
		method_0("ScenEdit_SetMission");
		LuaWrapper_Mission result;
		try
		{
			result = LuaMission.ScenEdit_SetMission(SideName, MissionNameOrID, table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaTable LUA_ScenEdit_ImportMission(string SideName, string MissionNameOrID)
	{
		method_0("ScenEdit_ImportMission");
		LuaTable result;
		try
		{
			result = LuaMission.ScenEdit_ImportMission(SideName, MissionNameOrID, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaTable LUA_ScenEdit_CreateMissionFlightPlan(string SideName, string MissionNameOrID, LuaTable table)
	{
		method_0("ScenEdit_CreateMissionFlightPlan");
		LuaTable result;
		try
		{
			result = LuaMission.ScenEdit_CreateMissionFlightPlan(SideName, MissionNameOrID, table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaTable LUA_ScenEdit_FillMagsForLoadout(LuaTable table)
	{
		method_0("ScenEdit_FillMagsForLoadout");
		LuaTable result;
		try
		{
			result = PrivateMethods.ScenEdit_FillMagsForLoadout(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaTable LUA_ScenEdit_ExportMission(string SideName, string MissionNameOrID)
	{
		method_0("ScenEdit_ExportMission");
		LuaTable result;
		try
		{
			result = LuaMission.ScenEdit_ExportMission(SideName, MissionNameOrID, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_ScenEdit_ImportScenarioFromXML(LuaTable theTable)
	{
		method_0("ScenEdit_ImportScenarioFromXML");
		try
		{
			throw new LuaError("This method is available only in Command PE.");
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			bool result = false;
			ProjectData.ClearProjectError();
			return result;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public string LUA_ScenEdit_ExportScenarioToXML(LuaTable theTable = null)
	{
		method_0("ScenEdit_ExportScenarioToXML");
		try
		{
			throw new LuaError("This method is available only in Command PE.");
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			string result = null;
			ProjectData.ClearProjectError();
			return result;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public string LUA_ScenEdit_ExportTagsToXML(string ParentNode)
	{
		method_0("ScenEdit_ExportTagsToXML");
		try
		{
			throw new LuaError("This method is available only in Command PE.");
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			string result = null;
			ProjectData.ClearProjectError();
			return result;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaTable LUA_ScenEdit_AssignUnitAsTarget(object AUNameOrIDOrTable, string MissionNameOrID)
	{
		method_0("ScenEdit_AssignUnitAsTarget");
		LuaTable result;
		try
		{
			result = LuaMission.ScenEdit_AssignUnitAsTarget((LuaTable)RuntimeHelpers.GetObjectValue(AUNameOrIDOrTable), MissionNameOrID, scenario_0, (ActiveUnit)UnitX);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaTable LUA_ScenEdit_RemoveUnitAsTarget(object AUNameOrIDOrTable, string MissionNameOrID)
	{
		method_0("ScenEdit_RemoveUnitAsTarget");
		LuaTable result;
		try
		{
			result = LuaMission.ScenEdit_RemoveUnitAsTarget((LuaTable)RuntimeHelpers.GetObjectValue(AUNameOrIDOrTable), MissionNameOrID, scenario_0, (ActiveUnit)UnitX);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaTable LUA_ScenEdit_GetContacts(string SideName)
	{
		method_0("ScenEdit_GetContacts");
		LuaTable result;
		try
		{
			result = PrivateMethods.ScenEdit_GetContacts(SideName, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaWrapper_Contact LUA_ScenEdit_GetContact(LuaTable table)
	{
		method_0("ScenEdit_Contact");
		LuaWrapper_Contact result;
		try
		{
			result = PrivateMethods.ScenEdit_GetContact(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public string LUA_ScenEdit_ExecuteEventAction(string eventName)
	{
		string text = null;
		method_0("ScenEdit_ExecuteEventAction");
		string result;
		try
		{
			text = LuaEvent.ScenEdit_ExecuteEventAction(eventName, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
			goto IL_008b;
		}
		if (text != null && Operators.CompareString(text, "", false) != 0)
		{
			try
			{
				SetLuaPathGlobals("");
				LuaUtility.DoString_Optimized(lua_0, text, eventName);
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				if (RunInteractive)
				{
					throw;
				}
				result = null;
				ProjectData.ClearProjectError();
				goto IL_008b;
			}
			result = "OK";
		}
		else
		{
			result = "";
		}
		goto IL_008b;
		IL_008b:
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public string LUA_ScenEdit_ExecuteSpecialAction(string eventName)
	{
		string text = null;
		method_0("ScenEdit_ExecuteSpecialAction");
		string result;
		try
		{
			text = LuaEvent.ScenEdit_ExecuteSpecialAction(eventName, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
			goto IL_008b;
		}
		if (text != null && Operators.CompareString(text, "", false) != 0)
		{
			try
			{
				SetLuaPathGlobals("");
				LuaUtility.DoString_Optimized(lua_0, text, eventName);
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				if (RunInteractive)
				{
					throw;
				}
				result = null;
				ProjectData.ClearProjectError();
				goto IL_008b;
			}
			result = "OK";
		}
		else
		{
			result = "";
		}
		goto IL_008b;
		IL_008b:
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaWrapper_Zone LUA_ScenEdit_AddZone(string sideName, int zoneType, LuaTable table)
	{
		method_0("ScenEdit_AddZone");
		LuaWrapper_Zone result;
		try
		{
			result = PrivateMethods.ScenEdit_AddZone(sideName, zoneType, table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaWrapper_Zone LUA_ScenEdit_RemoveZone(string sideName, int zoneType, LuaTable table)
	{
		method_0("ScenEdit_RemoveZone");
		LuaWrapper_Zone result;
		try
		{
			result = PrivateMethods.ScenEdit_RemoveZone(sideName, zoneType, table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaWrapper_Zone LUA_ScenEdit_SetZone(string sideName, int zoneType, LuaTable table)
	{
		method_0("ScenEdit_SetZone");
		LuaWrapper_Zone result;
		try
		{
			result = PrivateMethods.ScenEdit_SetZone(sideName, zoneType, table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaWrapper_Zone LUA_ScenEdit_GetZone(string sideName, string zoneNameId, int? zoneType)
	{
		method_0("ScenEdit_GetZone");
		LuaWrapper_Zone result;
		try
		{
			result = PrivateMethods.ScenEdit_GetZone(sideName, zoneNameId, zoneType, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public object LUA_ScenEdit_SetEvent(string eventName, LuaTable table)
	{
		method_0("ScenEdit_SetEvent");
		object result;
		try
		{
			result = LuaEvent.ScenEdit_SetEvent(eventName, table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public object LUA_ScenEdit_SetTrigger(LuaTable table)
	{
		method_0("ScenEdit_SetTrigger");
		object result;
		try
		{
			result = LuaEvent.ScenEdit_SetTrigger(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public object LUA_ScenEdit_SetCondition(LuaTable table)
	{
		method_0("ScenEdit_SetCondition");
		object result;
		try
		{
			result = LuaEvent.ScenEdit_SetCondition(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public object LUA_ScenEdit_SetAction(LuaTable table)
	{
		method_0("ScenEdit_SetAction");
		object result;
		try
		{
			result = LuaEvent.ScenEdit_SetAction(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public object LUA_ScenEdit_SetEventTrigger(string eventName, LuaTable table)
	{
		method_0("ScenEdit_SetEventTrigger");
		object result;
		try
		{
			result = LuaEvent.ScenEdit_SetEventTrigger(eventName, table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public object LUA_ScenEdit_SetEventCondition(string eventName, LuaTable table)
	{
		method_0("ScenEdit_SetEventCondition");
		object result;
		try
		{
			result = LuaEvent.ScenEdit_SetEventCondition(eventName, table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public object LUA_ScenEdit_SetEventAction(string eventName, LuaTable table)
	{
		method_0("ScenEdit_SetEventAction");
		object result;
		try
		{
			result = LuaEvent.ScenEdit_SetEventAction(eventName, table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaWrapper_Event LUA_ScenEdit_GetEvent(string eventName, int level = 0)
	{
		method_0("ScenEdit_GetEvent");
		LuaWrapper_Event result;
		try
		{
			result = LuaEvent.ScenEdit_GetEvent(eventName, level, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaTable LUA_ScenEdit_GetEvents(int level = 0)
	{
		method_0("ScenEdit_GetEvents");
		LuaTable result;
		try
		{
			result = LuaEvent.ScenEdit_GetEvents(level, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaTable LUA_ScenEdit_GetSpecialAction(LuaTable table)
	{
		method_0("ScenEdit_GetSpecialAction");
		LuaTable result;
		try
		{
			result = LuaEvent.ScenEdit_GetSpecialAction(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public object LUA_ScenEdit_UpdateEvent(string eventName, LuaTable table)
	{
		method_0("ScenEdit__UpdateEvent");
		object result;
		try
		{
			result = LuaEvent.ScenEdit_UpdateEvent(eventName, table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_ScenEdit_AttackContact(string attacker, string defender, LuaTable options)
	{
		method_0("ScenEdit_AttackContact");
		bool result;
		try
		{
			result = PrivateMethods.ScenEdit_AttackContact(attacker, defender, options, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public List<object> LUA_ScenEdit_AttackContact_Extra(string attacker, string defender, LuaTable options)
	{
		method_0("ScenEdit_AttackContact_Extra");
		List<object> result;
		try
		{
			result = PrivateMethods.ScenEdit_AttackContact_Extra(attacker, defender, options, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_IsUnitInZone(string TheUnit_NameOrID, string TheZone_NameOrID, string Side_NameOrID)
	{
		method_0("IsUnitInZone");
		bool result;
		try
		{
			result = PrivateMethods.ScenEdit_IsUnitInZone(TheUnit_NameOrID, TheZone_NameOrID, Side_NameOrID, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_ScenEdit_TransferCargo(string fromUnit, string toUnit, LuaTable cargo)
	{
		method_0("ScenEdit_TransferCargo");
		bool result;
		try
		{
			result = PrivateMethods.ScenEdit_TransferCargo(fromUnit, toUnit, cargo, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_ScenEdit_UnloadCargo(string fromUnit, LuaTable cargo = null)
	{
		method_0("ScenEdit_UnloadCargo");
		bool result;
		try
		{
			result = PrivateMethods.ScenEdit_UnloadCargo(fromUnit, cargo, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaTable LUA_ScenEdit_GetFormation(LuaTable table)
	{
		method_0("ScenEdit_GetFormation");
		LuaTable result;
		try
		{
			result = PrivateMethods.ScenEdit_GetFormation(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_ScenEdit_SetFormation(LuaTable table)
	{
		method_0("ScenEdit_SetFormation");
		bool result;
		try
		{
			result = PrivateMethods.ScenEdit_SetFormation(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaWrapper_Loadout LUA_ScenEdit_GetLoadout(LuaTable table)
	{
		method_0("ScenEdit_GetLoadout");
		LuaWrapper_Loadout result;
		try
		{
			result = PrivateMethods.ScenEdit_GetLoadout(table, scenario_0, (ActiveUnit)UnitX);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public object LUA_ScenEdit_QueryDB(string objectType, int DBID)
	{
		method_0("ScenEdit_QueryDB");
		object result;
		try
		{
			result = PrivateMethods.ScenEdit_QueryDB(objectType, DBID, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaTable LUA_ScenEdit_SelectedUnits()
	{
		method_0("ScenEdit_SelectedUnits");
		LuaTable result;
		try
		{
			result = PrivateMethods.ScenEdit_SelectedUnits(scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public int LUA_ScenEdit_AddMinefield(LuaTable table)
	{
		method_0("ScenEdit_AddMinefield");
		int result;
		try
		{
			result = PrivateMethods.ScenEdit_AddMinefield(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaTable LUA_ScenEdit_GetMinefield(LuaTable table)
	{
		method_0("ScenEdit_GetMinefield");
		LuaTable result;
		try
		{
			result = PrivateMethods.ScenEdit_GetMinefield(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public int LUA_ScenEdit_DeleteMinefield(LuaTable table)
	{
		method_0("ScenEdit_DeleteMinefield");
		int result;
		try
		{
			result = PrivateMethods.ScenEdit_DeleteMinefield(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_ScenEdit_SetMine(LuaTable table)
	{
		method_0("ScenEdit_SetMine");
		bool result;
		try
		{
			result = PrivateMethods.ScenEdit_SetMine(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_ScenEdit_DeleteMine(LuaTable table)
	{
		method_0("ScenEdit_DeleteMine");
		bool result;
		try
		{
			result = PrivateMethods.ScenEdit_DeleteMine(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public string LUA_ScenEdit_GetDateTimeTicks()
	{
		method_0("ScenEdit_GetDateTimeTicks");
		string result;
		try
		{
			result = PrivateMethods.ScenEdit_GetDateTimeTicks(scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_ScenEdit_AddCustomLoss(string Side, LuaTable table)
	{
		method_0("ScenEdit_AddCustomLoss");
		bool result;
		try
		{
			result = PrivateMethods.ScenEdit_AddCustomLoss(Side, table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public string LUA_ScenEdit_ExportDoctrineToXML(LuaTable table)
	{
		method_0("LUA_ScenEdit_ExportDoctrineToXML");
		string result;
		try
		{
			result = LuaDoctrine.ScenEdit_ExportDoctrineToXML(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public string LUA_ScenEdit_ImportDoctrineFromXML(LuaTable table)
	{
		method_0("LUA_ScenEdit_ImportDoctrineFromXML");
		string result;
		try
		{
			result = LuaDoctrine.ScenEdit_ImportDoctrineFromXML(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_VP_ExportUnits(LuaTable table, string fileName)
	{
		method_0("VP_ExportUnits");
		bool result;
		try
		{
			result = PrivateMethods.VP_ExportUnits(table, fileName, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaTable LUA_ScenEdit_SplitUnit(LuaTable table)
	{
		method_0("ScenEdit_SplitUnit");
		LuaTable result;
		try
		{
			result = PrivateMethods.ScenEdit_SplitUnit(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaWrapper_ActiveUnit_SE LUA_ScenEdit_MergeUnits()
	{
		method_0("ScenEdit_MergeUnits");
		LuaWrapper_ActiveUnit_SE result;
		try
		{
			result = PrivateMethods.ScenEdit_MergeUnits(scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_ScenEdit_TransferMount(string fromUnit, string toUnit, LuaTable mounts)
	{
		method_0("ScenEdit_TransferMount");
		bool result;
		try
		{
			result = PrivateMethods.ScenEdit_TransferMount(fromUnit, toUnit, mounts, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool? LUA_ScenEdit_UpdateRSetting(object theSetting, bool? theOption = null)
	{
		method_0("ScenEdit_UpdateRSetting");
		bool? result;
		try
		{
			return PrivateMethods.ScenEdit_UpdateRSetting(RuntimeHelpers.GetObjectValue(theSetting), theOption, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public object LUA_Tool_QuerySoundLevel(LuaTable table)
	{
		method_0("LUA_Tool_QuerySoundLevel");
		object result;
		try
		{
			result = PrivateMethods.Tool_QuerySoundLevel(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public float LUA_Tool_QueryRCS(LuaTable table)
	{
		method_0("LUA_Tool_QueryRCS");
		float result;
		try
		{
			result = PrivateMethods.Tool_QueryRCS(table, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = 0f;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_Tool_BuildBlankScenario(string useDBfilename = null)
	{
		method_0("LUA_Tool_BuildBlankScenario");
		string dbHash = null;
		bool result;
		try
		{
			if (useDBfilename != null)
			{
				DBRecord dBRecord = (from theDBR in DBOps.RegisteredDBs()
					where Operators.CompareString(theDBR.FileName, useDBfilename, false) == 0 && theDBR.LocalCopyExists
					select theDBR).FirstOrDefault();
				if (dBRecord == null)
				{
					throw new Exception("Error in finding DB  (" + useDBfilename + ")");
				}
				dbHash = dBRecord.Hash;
			}
			result = PrivateMethods.Tool_BuildBlankScenario(dbHash);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public string Tool_DumpEvents()
	{
		method_0("Tool_DumpEvents");
		string text = LuaEvent.ToXML_ViaStringBuilder(MinifyText: true, scenario_0);
		if (!Directory.Exists(GameGeneral.ScenariosRootPath))
		{
			Directory.CreateDirectory(GameGeneral.ScenariosRootPath);
		}
		StreamWriter streamWriter = new StreamWriter(GameGeneral.ScenariosRootPath + "\\" + scenario_0.FileName + " events.xml");
		using (streamWriter)
		{
			streamWriter.Write(text);
			return text;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool Tool_EmulateNoConsole(bool mode = true)
	{
		method_0("Tool_EmulateNoConsole");
		RunInteractive = !mode;
		return RunInteractive;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public double Tool_Range(object fromHere, object toHere, bool useSlant = false)
	{
		method_0("Tool_Range");
		double num = 0.0;
		Geopoint_Struct geopoint_Struct = default(Geopoint_Struct);
		Geopoint_Struct geopoint_Struct2 = default(Geopoint_Struct);
		geopoint_Struct.Latitude = 9999.0;
		geopoint_Struct2.Latitude = 9999.0;
		if (fromHere is LuaTable)
		{
			LuaTable luaTable = (LuaTable)fromHere;
			Dictionary<string, object> dict = LuaUtility.ToDictUpper(luaTable.GetEnumerator());
			double? num2 = LuaUtility.QueryLongitude(dict);
			double? num3 = LuaUtility.QueryLatitude(dict);
			float? num4 = LuaUtility.QueryAltitude(dict);
			if (!num2.HasValue || !num2.HasValue)
			{
				throw new LuaError("From table object " + LuaUtility.LuaInterpret(luaTable) + " needs latitude and longitude.");
			}
			geopoint_Struct = ((!num4.HasValue) ? new Geopoint_Struct(num2.Value, num3.Value) : new Geopoint_Struct(num2.Value, num3.Value, num4.Value));
		}
		if (toHere is LuaTable)
		{
			LuaTable luaTable2 = (LuaTable)toHere;
			Dictionary<string, object> dict2 = LuaUtility.ToDictUpper(luaTable2.GetEnumerator());
			double? num5 = LuaUtility.QueryLongitude(dict2);
			double? num6 = LuaUtility.QueryLatitude(dict2);
			float? num7 = LuaUtility.QueryAltitude(dict2);
			if (!num5.HasValue | !num5.HasValue)
			{
				throw new LuaError("To table object " + LuaUtility.LuaInterpret(luaTable2) + " needs latitude and longitude.");
			}
			geopoint_Struct2 = ((!num7.HasValue) ? new Geopoint_Struct(num5.Value, num6.Value) : new Geopoint_Struct(num5.Value, num6.Value, num7.Value));
		}
		if (fromHere is string)
		{
			string text = Conversions.ToString(fromHere);
			ActiveUnit activeUnit = null;
			Contact contact = null;
			try
			{
				activeUnit = scenario_0.ActiveUnits[text];
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			if (activeUnit == null)
			{
				try
				{
					contact = PrivateMethods.ValidateContactBySceanrio(text, scenario_0);
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					ProjectData.ClearProjectError();
				}
			}
			if (activeUnit == null && contact == null)
			{
				throw new LuaError("Can't find guid " + text);
			}
			if (activeUnit == null)
			{
				if (contact != null)
				{
					double theLon = ((Module_Unit.Unit)contact).get_Longitude((GlobalVariables.BooleanObject)null);
					double theLat = ((Module_Unit.Unit)contact).get_Latitude((GlobalVariables.BooleanObject)null);
					float theAlt = ((Module_Unit.Unit)contact).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
					geopoint_Struct = new Geopoint_Struct(theLon, theLat, theAlt);
				}
			}
			else
			{
				double theLon2 = activeUnit.get_Longitude((GlobalVariables.BooleanObject)null);
				double theLat2 = activeUnit.get_Latitude((GlobalVariables.BooleanObject)null);
				float theAlt2 = activeUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
				geopoint_Struct = new Geopoint_Struct(theLon2, theLat2, theAlt2);
			}
		}
		if (toHere is string)
		{
			string text2 = Conversions.ToString(toHere);
			ActiveUnit activeUnit2 = null;
			Contact contact2 = null;
			try
			{
				activeUnit2 = scenario_0.ActiveUnits[text2];
			}
			catch (Exception projectError3)
			{
				ProjectData.SetProjectError(projectError3);
				ProjectData.ClearProjectError();
			}
			if (activeUnit2 == null)
			{
				try
				{
					contact2 = PrivateMethods.ValidateContactBySceanrio(text2, scenario_0);
				}
				catch (Exception projectError4)
				{
					ProjectData.SetProjectError(projectError4);
					ProjectData.ClearProjectError();
				}
			}
			if (activeUnit2 == null && contact2 == null)
			{
				throw new LuaError("Can't find guid " + text2);
			}
			if (activeUnit2 == null)
			{
				if (contact2 != null)
				{
					double theLon3 = ((Module_Unit.Unit)contact2).get_Longitude((GlobalVariables.BooleanObject)null);
					double theLat3 = ((Module_Unit.Unit)contact2).get_Latitude((GlobalVariables.BooleanObject)null);
					float theAlt3 = ((Module_Unit.Unit)contact2).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
					geopoint_Struct2 = new Geopoint_Struct(theLon3, theLat3, theAlt3);
				}
			}
			else
			{
				double theLon4 = activeUnit2.get_Longitude((GlobalVariables.BooleanObject)null);
				double theLat4 = activeUnit2.get_Latitude((GlobalVariables.BooleanObject)null);
				float theAlt4 = activeUnit2.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
				geopoint_Struct2 = new Geopoint_Struct(theLon4, theLat4, theAlt4);
			}
		}
		if (geopoint_Struct.Latitude != 9999.0 && geopoint_Struct2.Latitude != 9999.0)
		{
			num = Geodesic_Haversine.Distance_Horiz_Approx_nm(geopoint_Struct.Latitude, geopoint_Struct.Longitude, geopoint_Struct2.Latitude, geopoint_Struct2.Longitude);
			if (!useSlant)
			{
				return num;
			}
			float num8 = (float)((double)Math.Abs(geopoint_Struct.Altitude - geopoint_Struct2.Altitude) * 0.000539957);
			if (num8 == 0f)
			{
				return num;
			}
			return (float)Math.Sqrt(num * num + (double)(num8 * num8));
		}
		throw new LuaError("No points have been set");
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public double Tool_Bearing(object fromHere, object toHere)
	{
		method_0("Tool_Bearing");
		GeoPoint geoPoint = null;
		GeoPoint geoPoint2 = null;
		if (fromHere is LuaTable)
		{
			LuaTable luaTable = (LuaTable)fromHere;
			Dictionary<string, object> dict = LuaUtility.ToDictUpper(luaTable.GetEnumerator());
			double? num = LuaUtility.QueryLongitude(dict);
			double? num2 = LuaUtility.QueryLatitude(dict);
			if (!num.HasValue | !num.HasValue)
			{
				throw new LuaError("From table object " + LuaUtility.LuaInterpret(luaTable) + " needs latitude and longitude.");
			}
			geoPoint = new GeoPoint(num.Value, num2.Value);
		}
		if (toHere is LuaTable)
		{
			LuaTable luaTable2 = (LuaTable)toHere;
			Dictionary<string, object> dict2 = LuaUtility.ToDictUpper(luaTable2.GetEnumerator());
			double? num3 = LuaUtility.QueryLongitude(dict2);
			double? num4 = LuaUtility.QueryLatitude(dict2);
			if (!num3.HasValue | !num3.HasValue)
			{
				throw new LuaError("To table object " + LuaUtility.LuaInterpret(luaTable2) + " needs latitude and longitude.");
			}
			geoPoint2 = new GeoPoint(num3.Value, num4.Value);
		}
		if (fromHere is string)
		{
			string text = Conversions.ToString(fromHere);
			ActiveUnit activeUnit = null;
			Contact contact = null;
			try
			{
				activeUnit = scenario_0.ActiveUnits[text];
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			if (activeUnit == null)
			{
				try
				{
					contact = PrivateMethods.ValidateContactBySceanrio(text, scenario_0);
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					ProjectData.ClearProjectError();
				}
			}
			if (activeUnit == null && contact == null)
			{
				throw new LuaError("Can't find guid " + text);
			}
			if (activeUnit != null)
			{
				double theLon = activeUnit.get_Longitude((GlobalVariables.BooleanObject)null);
				double theLat = activeUnit.get_Latitude((GlobalVariables.BooleanObject)null);
				geoPoint = new GeoPoint(theLon, theLat);
			}
			else if (contact != null)
			{
				double theLon2 = ((Module_Unit.Unit)contact).get_Longitude((GlobalVariables.BooleanObject)null);
				double theLat2 = ((Module_Unit.Unit)contact).get_Latitude((GlobalVariables.BooleanObject)null);
				geoPoint = new GeoPoint(theLon2, theLat2);
			}
		}
		if (toHere is string)
		{
			string text2 = Conversions.ToString(toHere);
			ActiveUnit activeUnit2 = null;
			Contact contact2 = null;
			try
			{
				activeUnit2 = scenario_0.ActiveUnits[text2];
			}
			catch (Exception projectError3)
			{
				ProjectData.SetProjectError(projectError3);
				ProjectData.ClearProjectError();
			}
			if (activeUnit2 == null)
			{
				try
				{
					contact2 = PrivateMethods.ValidateContactBySceanrio(text2, scenario_0);
				}
				catch (Exception projectError4)
				{
					ProjectData.SetProjectError(projectError4);
					ProjectData.ClearProjectError();
				}
			}
			if (activeUnit2 == null && contact2 == null)
			{
				throw new LuaError("Can't find guid " + text2);
			}
			if (activeUnit2 != null)
			{
				double theLon3 = activeUnit2.get_Longitude((GlobalVariables.BooleanObject)null);
				double theLat3 = activeUnit2.get_Latitude((GlobalVariables.BooleanObject)null);
				geoPoint2 = new GeoPoint(theLon3, theLat3);
			}
			else if (contact2 != null)
			{
				double theLon4 = ((Module_Unit.Unit)contact2).get_Longitude((GlobalVariables.BooleanObject)null);
				double theLat4 = ((Module_Unit.Unit)contact2).get_Latitude((GlobalVariables.BooleanObject)null);
				geoPoint2 = new GeoPoint(theLon4, theLat4);
			}
		}
		if (geoPoint == null || geoPoint2 == null)
		{
			throw new LuaError("No points have been set");
		}
		double result = Math2.CalcAzimuth(geoPoint.Latitude, geoPoint.Longitude, geoPoint2.Latitude, geoPoint2.Longitude);
		_ = (double)Math2.CalcDist(geoPoint.Latitude, geoPoint.Longitude, geoPoint2.Latitude, geoPoint2.Longitude);
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool Tool_UIwindow(string windowName, bool mode = true)
	{
		method_0("Tool_UIwindow");
		bool result;
		try
		{
			if (!((windowName == null) | (Operators.CompareString(windowName, "", false) == 0)))
			{
				vCsLzanfUo6?.Invoke(windowName, mode);
				goto IL_0047;
			}
			result = false;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = false;
			ProjectData.ClearProjectError();
		}
		goto IL_0049;
		IL_0047:
		result = true;
		goto IL_0049;
		IL_0049:
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_Tool_ResetMessageLog(bool dumpToFile = false)
	{
		method_0("Tool_ResetMessageLog");
		bool result;
		try
		{
			result = PrivateMethods.Tool_ResetMessageLog(dumpToFile, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public object Tool_LOS(LuaTable table)
	{
		method_0("Tool_LOS");
		float num = -1f;
		float num2 = -1f;
		object obj = 0;
		object obj2 = 0;
		byte b = 0;
		byte b2 = 0;
		ActiveUnit activeUnit = null;
		ActiveUnit activeUnit2 = null;
		bool flag = true;
		double? num3 = null;
		double? num4 = null;
		double? num5 = null;
		double? num6 = null;
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(table.GetEnumerator());
		try
		{
			if (dictionary.ContainsKey("MODE"))
			{
				b = Conversions.ToByte(dictionary["MODE"]);
			}
			if (dictionary.ContainsKey("HORIZON"))
			{
				b2 = Conversions.ToByte(dictionary["HORIZON"]);
			}
			if (dictionary.ContainsKey("USERANGELIMITS"))
			{
				flag = Conversions.ToBoolean(dictionary["USERANGELIMITS"]);
			}
			if (dictionary.ContainsKey("OBSERVER"))
			{
				obj = RuntimeHelpers.GetObjectValue(dictionary["OBSERVER"]);
			}
			if (dictionary.ContainsKey("TARGET"))
			{
				obj2 = RuntimeHelpers.GetObjectValue(dictionary["TARGET"]);
			}
			float? num7 = default(float?);
			float? num8 = default(float?);
			if (!(obj is float))
			{
				if (!(obj is long))
				{
					if (!(obj is double))
					{
						if (!(obj is LuaTable))
						{
							if (obj is string)
							{
								string text = Conversions.ToString(obj).ToUpper();
								if (text.Contains("FT"))
								{
									num = float.Parse(text.Replace("FT", "").Replace("M", "").Trim(), CultureInfo.InvariantCulture) * 0.3048f;
								}
								else if (text.Contains("M"))
								{
									num = float.Parse(text.Replace("FT", "").Replace("M", "").Trim(), CultureInfo.InvariantCulture);
								}
							}
						}
						else
						{
							Dictionary<string, object> dictionary2 = LuaUtility.ToDictUpper(((LuaTable)obj).GetEnumerator());
							if (dictionary2.ContainsKey("ALTITUDE"))
							{
								string text2 = Conversions.ToString(dictionary2["ALTITUDE"]).ToUpper();
								num = (text2.Contains("FT") ? (float.Parse(text2.Replace("FT", "").Replace("M", "").Trim(), CultureInfo.InvariantCulture) * 0.3048f) : (text2.Contains("M") ? float.Parse(text2.Replace("FT", "").Replace("M", "").Trim(), CultureInfo.InvariantCulture) : float.Parse(text2.Trim(), CultureInfo.InvariantCulture)));
							}
							else if (!dictionary2.ContainsKey("GUID"))
							{
								if (dictionary2.ContainsKey("LOCATION"))
								{
									LuaTable luaTable = (LuaTable)dictionary2["LOCATION"];
									Dictionary<string, object> dict = LuaUtility.ToDictUpper(luaTable.GetEnumerator());
									num3 = LuaUtility.QueryLongitude(dict);
									num4 = LuaUtility.QueryLatitude(dict);
									if (!num3.HasValue || !num3.HasValue)
									{
										throw new LuaError("Observer table object " + LuaUtility.LuaInterpret(luaTable) + " needs latitude and longitude.");
									}
								}
							}
							else
							{
								string key = Conversions.ToString(dictionary2["GUID"]);
								activeUnit = scenario_0.ActiveUnits[key];
								if (activeUnit != null)
								{
									switch (b2)
									{
									case 1:
										num = activeUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + (float)((Module_Unit.Unit)activeUnit).get_MastHeight_Visual((Sensor)null);
										break;
									case 0:
										num = activeUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + (float)((Module_Unit.Unit)activeUnit).get_MastHeight_Radar((Sensor)null);
										break;
									}
									num3 = activeUnit.get_Longitude((GlobalVariables.BooleanObject)null);
									num4 = activeUnit.get_Latitude((GlobalVariables.BooleanObject)null);
									if (flag && activeUnit.Sensors_Cached.Length > 0)
									{
										Sensor[] sensors_Cached = activeUnit.Sensors_Cached;
										foreach (Sensor sensor in sensors_Cached)
										{
											num7 = ((!num7.HasValue) ? Math.Max(0f, sensor.maxRange) : Math.Max(num7.Value, sensor.maxRange));
											num8 = (num8.HasValue ? Math.Max(num8.Value, sensor.minRange) : Math.Max(0f, sensor.minRange));
										}
									}
								}
							}
						}
					}
					else
					{
						num = Conversions.ToSingle(obj);
					}
				}
				else
				{
					num = Conversions.ToSingle(obj);
				}
			}
			else
			{
				num = Conversions.ToSingle(obj);
			}
			if (!(obj2 is float))
			{
				if (!(obj2 is long))
				{
					if (!(obj2 is double))
					{
						if (!(obj2 is LuaTable))
						{
							if (obj2 is string)
							{
								string text3 = Conversions.ToString(obj2).ToUpper();
								if (text3.Contains("FT"))
								{
									num2 = float.Parse(text3.Replace("FT", "").Replace("M", "").Trim(), CultureInfo.InvariantCulture) * 0.3048f;
								}
								else if (text3.Contains("M"))
								{
									num2 = float.Parse(text3.Replace("FT", "").Replace("M", "").Trim(), CultureInfo.InvariantCulture);
								}
							}
						}
						else
						{
							Dictionary<string, object> dictionary3 = LuaUtility.ToDictUpper(((LuaTable)obj2).GetEnumerator());
							if (!dictionary3.ContainsKey("ALTITUDE"))
							{
								if (dictionary3.ContainsKey("GUID"))
								{
									string text4 = Conversions.ToString(dictionary3["GUID"]);
									if (scenario_0.ActiveUnits.ContainsKey(text4))
									{
										activeUnit2 = scenario_0.ActiveUnits[text4];
										num2 = activeUnit2.CurrentAltitude_AGL;
										num6 = activeUnit2.get_Latitude((GlobalVariables.BooleanObject)null);
										num5 = activeUnit2.get_Longitude((GlobalVariables.BooleanObject)null);
									}
									else if (activeUnit != null)
									{
										Contact contact = PrivateMethods.ValidateContactBySide(text4, 0, activeUnit.get_UnitSide(SetSideOnly: false));
										if (contact != null)
										{
											activeUnit2 = scenario_0.ActiveUnits[contact.ActualUnit.ObjectID];
											num2 = contact.CurrentAltitude_AGL;
											num6 = ((Module_Unit.Unit)contact).get_Latitude((GlobalVariables.BooleanObject)null);
											num5 = ((Module_Unit.Unit)contact).get_Longitude((GlobalVariables.BooleanObject)null);
										}
									}
								}
								else if (dictionary3.ContainsKey("LOCATION"))
								{
									LuaTable luaTable2 = (LuaTable)dictionary3["LOCATION"];
									Dictionary<string, object> dict2 = LuaUtility.ToDictUpper(luaTable2.GetEnumerator());
									num5 = LuaUtility.QueryLongitude(dict2);
									num6 = LuaUtility.QueryLatitude(dict2);
									if (!num5.HasValue || !num5.HasValue)
									{
										throw new LuaError("Observer table object " + LuaUtility.LuaInterpret(luaTable2) + " needs latitude and longitude.");
									}
								}
							}
							else
							{
								string text5 = Conversions.ToString(dictionary3["ALTITUDE"]).ToUpper();
								num2 = (text5.Contains("FT") ? (float.Parse(text5.Replace("FT", "").Replace("M", "").Trim(), CultureInfo.InvariantCulture) * 0.3048f) : (text5.Contains("M") ? float.Parse(text5.Replace("FT", "").Replace("M", "").Trim(), CultureInfo.InvariantCulture) : float.Parse(text5.Trim(), CultureInfo.InvariantCulture)));
							}
						}
					}
					else
					{
						num2 = Conversions.ToSingle(obj2);
					}
				}
				else
				{
					num2 = Conversions.ToSingle(obj2);
				}
			}
			else
			{
				num2 = Conversions.ToSingle(obj2);
			}
			if (!(num < 0f) && num2 >= 0f)
			{
				double num9 = default(double);
				switch (b2)
				{
				case 1:
					num9 = Horizon.VisualHorizonNM(num, num2);
					if (num7.HasValue)
					{
						double num10 = num9;
						double? num11 = num7;
						if (((!num11.HasValue) ? ((bool?)null) : new bool?(num10 > num11.GetValueOrDefault())) == true)
						{
							num9 = num7.Value;
						}
					}
					break;
				case 2:
					switch (b)
					{
					case 1:
						return LOS.DetermineLOS(num4.Value, num3.Value, num, num6.Value, num5.Value, num2, LandMassCheck: false, activeUnit.ParentScen);
					case 0:
						num9 = Horizon.ESMHorizonNM(num, num2);
						if (num7.HasValue)
						{
							double num10 = num9;
							double? num11 = num7;
							if (((!num11.HasValue) ? ((bool?)null) : new bool?(num10 > num11.GetValueOrDefault())) == true)
							{
								num9 = num7.Value;
							}
						}
						if (num8.HasValue)
						{
							double num10 = num9;
							double? num11 = num8;
							if (((!num11.HasValue) ? ((bool?)null) : new bool?(num10 < num11.GetValueOrDefault())) == true)
							{
								num9 = 0.0;
							}
						}
						break;
					}
					break;
				case 0:
					switch (b)
					{
					case 0:
						num9 = Horizon.RadarHorizonNM(num, num2);
						if (num7.HasValue)
						{
							double num10 = num9;
							double? num11 = num7;
							if (((!num11.HasValue) ? ((bool?)null) : new bool?(num10 > num11.GetValueOrDefault())) == true)
							{
								num9 = num7.Value;
							}
						}
						if (num8.HasValue)
						{
							double num10 = num9;
							double? num11 = num8;
							if (((!num11.HasValue) ? ((bool?)null) : new bool?(num10 < num11.GetValueOrDefault())) == true)
							{
								num9 = 0.0;
							}
						}
						break;
					case 1:
						return LOS.DetermineLOS(num4.Value, num3.Value, num, num6.Value, num5.Value, num2, LandMassCheck: false, activeUnit.ParentScen);
					}
					break;
				}
				return num9;
			}
			return null;
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
		return null;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public string Tool_LOS_Points(LuaTable fromHere, LuaTable toHere, byte HorizonType)
	{
		method_0("Tool_LOS_Points");
		Dictionary<string, object> dict = LuaUtility.ToDictUpper(fromHere.GetEnumerator());
		double? num = LuaUtility.QueryLongitude(dict);
		if (num.HasValue)
		{
			double? num2 = LuaUtility.QueryLatitude(dict);
			if (!num2.HasValue)
			{
				throw new LuaError("Error in determining the source latitude!");
			}
			float? num3 = LuaUtility.QueryAltitude(dict);
			if (num3.HasValue)
			{
				Dictionary<string, object> dict2 = LuaUtility.ToDictUpper(toHere.GetEnumerator());
				double? num4 = LuaUtility.QueryLongitude(dict2);
				if (!num4.HasValue)
				{
					throw new LuaError("Error in determining the target longitude!");
				}
				double? num5 = LuaUtility.QueryLatitude(dict2);
				if (!num5.HasValue)
				{
					throw new LuaError("Error in determining the target latitude!");
				}
				float? num6 = LuaUtility.QueryAltitude(dict2);
				if (!num6.HasValue)
				{
					throw new LuaError("Error in determining the target altitude!");
				}
				float num7 = Math2.CalcDist(num2.Value, num.Value, num5.Value, num4.Value);
				try
				{
					float num8 = default(float);
					switch (HorizonType)
					{
					case 0:
						num8 = Horizon.RadarHorizonNM(num3.Value, num6.Value);
						break;
					case 1:
						num8 = Horizon.VisualHorizonNM(num3.Value, num6.Value);
						break;
					case 2:
						num8 = Horizon.ESMHorizonNM(num3.Value, num6.Value);
						break;
					}
					if (num8 < num7)
					{
						return "FAIL_BEYONDHORIZON";
					}
					if (LOS.DetermineLOS(num2.Value, num.Value, num3.Value, num5.Value, num4.Value, num6.Value, LandMassCheck: false, scenario_0))
					{
						return "SUCCESS";
					}
					return "FAIL_TERRAINBLOCK";
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("Error: " + ex2.Message);
				}
			}
			throw new LuaError("Error in determining the source altitude!");
		}
		throw new LuaError("Error in determining the source longitude!");
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_Tool_Scen_Migration(LuaTable parameters)
	{
		method_0("LUA_Tool_Scen_Migration");
		string text = "";
		string text2 = "";
		bool flag = false;
		(DBRecord, DBOps.DBFileCheckResult) tuple = default((DBRecord, DBOps.DBFileCheckResult));
		string theFileName = DBOps.GetDBRecordByHash(DBOps.GetHashForMostRecentVersionOfThisDB(1), ref tuple.Item2).FileName;
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(parameters.GetEnumerator());
		bool result;
		try
		{
			if (dictionary.ContainsKey("SCENARIO"))
			{
				text = Conversions.ToString(dictionary["SCENARIO"]);
			}
			if (dictionary.ContainsKey("CONFIG"))
			{
				text2 = Conversions.ToString(dictionary["CONFIG"]);
			}
			int num;
			if (!dictionary.ContainsKey("DBFILE"))
			{
				num = 0;
			}
			else
			{
				theFileName = Conversions.ToString(dictionary["DBFILE"]);
				num = 0;
			}
			bool flag2 = (byte)num != 0;
			tuple = DBOps.GetDBRecordByFilename(theFileName, flag2);
			if (tuple.Item2 == DBOps.DBFileCheckResult.DBFileNotPresent)
			{
				throw new LuaError("The DB file you have requested cannot be found!");
			}
			if (DBOps.DBHasBeenTampered(tuple.Item1))
			{
				throw new LuaError("The registered DB file you have selected has been tampered with!");
			}
			if (tuple.Item2 != DBOps.DBFileCheckResult.AllOK)
			{
				throw new LuaError("An unspecified error has occured!");
			}
			if (!FileExistsNative.FileExistsFast(text))
			{
				throw new LuaError("Scenario " + text + " not found!");
			}
			if (!string.IsNullOrEmpty(text2))
			{
				if (string.Compare(text2, "batch", ignoreCase: true) == 0)
				{
					flag = true;
				}
				else if (!FileExistsNative.FileExistsFast(text2))
				{
					throw new LuaError("Scenario INI " + text2 + " not found!");
				}
			}
			result = ((!flag) ? PrivateMethods.Tool_Scen_Migration(text, text2, tuple.Item1) : SBR.AllInOne(text, tuple.Item1));
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaTable LUA_ScenEdit_WeaponAllocation(string attacker, string contact, string side = null)
	{
		method_0("ScenEdit_WeaponAllocation");
		LuaTable result;
		try
		{
			result = PrivateMethods.ScenEdit_WeaponAllocation(attacker, contact, side, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public string LUA_Tool_ConvertDecimalDegreesToDMS(double myLat, double myLon)
	{
		method_0("Tool_ConvertDecimalDegreesToDMS");
		string result;
		try
		{
			result = PrivateMethods.Tool_ConvertToDMS(myLat, myLon);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void method_1()
	{
		stringBuilder_1.Append("SE_GetUnit=ScenEdit_GetUnit\r\nSE_SetUnit=ScenEdit_SetUnit");
	}

	public ActiveUnit MakeActiveUnitOfUnguidedWeapon(UnguidedWeapon theUW)
	{
		Weapon obj = new Weapon(scenario_0)
		{
			ObjectID = theUW.ObjectID,
			UnitClass = theUW.UnitClass,
			[false] = theUW.get_UnitSide(SetSideOnly: false)
		};
		obj.Type = theUW.Type;
		obj.DBID = Conversions.ToInteger(Strings.Split(theUW.AnnexAndDBID, "_", -1, (CompareMethod)0)[1]);
		obj.Name = theUW.Name;
		((ActiveUnit)obj).set_Latitude((GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)theUW).get_Latitude((GlobalVariables.BooleanObject)null));
		((ActiveUnit)obj).set_Longitude((GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)theUW).get_Longitude((GlobalVariables.BooleanObject)null));
		((ActiveUnit)obj).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)theUW).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
		return obj;
	}
}
