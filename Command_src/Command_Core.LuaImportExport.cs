using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.CompilerServices;
using Command_Core.Lua;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core;

[StandardModule]
public sealed class LuaImportExport
{
	public static int ScenEdit_ImportInst(string SideNameOrID, string InstFile, Scenario ScenarioContext)
	{
		Side side = null;
		side = PrivateMethods.ValidateSide(SideNameOrID, ScenarioContext);
		if (!Information.IsNothing((object)side))
		{
			InstFile = InstFile.Replace("..", "");
			return ScenarioContext.ImportUnitsFromFile(GameGeneral.TopLevelWritablePath + Conversions.ToString(Path.DirectorySeparatorChar) + "ImportExport" + Conversions.ToString(Path.DirectorySeparatorChar) + InstFile, side).Count;
		}
		return 0;
	}

	public static int ScenEdit_ExportInst(string SideNameOrID, LuaTable units, LuaTable fileData, Scenario ScenarioContext)
	{
		Side side = null;
		Collection<ActiveUnit> collection = new Collection<ActiveUnit>();
		side = PrivateMethods.ValidateSide(SideNameOrID, ScenarioContext);
		if (Information.IsNothing((object)side))
		{
			return 0;
		}
		Dictionary<string, object> dict = LuaUtility.ToDictUpper(fileData.GetEnumerator());
		LuaUtility.ParseUnitDict(ref dict);
		string text = "";
		string instname = "";
		string instComment = "";
		int instDBID = -1;
		DBOps.DBFileCheckResult theResult = DBOps.DBFileCheckResult.Undefined;
		if (dict.ContainsKey("FILENAME"))
		{
			try
			{
				text = Conversions.ToString(dict["FILENAME"]);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw new LuaError("filename must be a string");
			}
			if (dict.ContainsKey("NAME"))
			{
				try
				{
					instname = Conversions.ToString(dict["NAME"]);
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					throw new LuaError("name must be a string");
				}
			}
			if (dict.ContainsKey("COMMENT"))
			{
				try
				{
					instComment = Conversions.ToString(dict["COMMENT"]);
				}
				catch (Exception projectError3)
				{
					ProjectData.SetProjectError(projectError3);
					throw new LuaError("comment must be a string");
				}
			}
			text = text.Replace("..", "");
			text = GameGeneral.TopLevelWritablePath + Conversions.ToString(Path.DirectorySeparatorChar) + "ImportExport" + Conversions.ToString(Path.DirectorySeparatorChar) + text;
			List<object> list = LuaUtility.ToArray(units.GetEnumerator());
			foreach (object item2 in list)
			{
				ActiveUnit item = PrivateMethods.ValidateAUBySide(Conversions.ToString(RuntimeHelpers.GetObjectValue(item2)), side);
				collection.Add(item);
			}
			DBRecord dBRecordByHash = DBOps.GetDBRecordByHash(ScenarioContext.DBUsed, ref theResult, CheckLocalFileExists: false, CheckForTampering: false);
			if (dBRecordByHash != null)
			{
				instDBID = dBRecordByHash.DBID;
			}
			ScenarioContext.ExportUnitsToFile(text, instname, instComment, instDBID, side, collection);
			return collection.Count;
		}
		throw new LuaError("no filename key defined");
	}

	static LuaImportExport()
	{
		Class72.smethod_20();
	}
}
