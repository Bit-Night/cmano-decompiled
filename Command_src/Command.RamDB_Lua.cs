using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Command.My;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command;

public class RamDB_Lua
{
	public enum LuaMethodCategory
	{
		Direct_DB_Edition,
		RamDB_Edition,
		RamDB_Information,
		Others
	}

	private Lua lua_0;

	private Dictionary<string, string> dictionary_0;

	public RamDB_Lua()
	{
		lua_0 = new Lua();
		dictionary_0 = new Dictionary<string, string>();
		LuaLoading();
	}

	public void ExecuteCode(string Code)
	{
		try
		{
			lua_0.DoString(((RichTextBox)MyProject.Forms.DBToolsForm.RT_LuaInput).Text);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkRichTextBox tB_LuaOutput;
			((RichTextBox)(tB_LuaOutput = MyProject.Forms.DBToolsForm.TB_LuaOutput)).Text = ((RichTextBox)tB_LuaOutput).Text + Environment.NewLine;
			((RichTextBox)(tB_LuaOutput = MyProject.Forms.DBToolsForm.TB_LuaOutput)).Text = ((RichTextBox)tB_LuaOutput).Text + ex2.Message;
			ProjectData.ClearProjectError();
		}
	}

	public void LuaLoading()
	{
		lua_0.LoadCLRPackage();
		RegisterFunction("Print", "(string Text) Prints text to the console.");
		RegisterFunction("ExecuteQuery", "(string SQL_Query) Executes a SQL query to the DB being modified. return bool");
		RegisterFunction("FetchSimilarNodeEntry", "(string TheDatabase, int DBID, string TableNode, float SimilarityThreshold, bool OpenWindow) return LuaTable");
		RegisterFunction("FetchMethods", "()");
	}

	public bool SanityCheck_RamDBInstance()
	{
		if (MyProject.Forms.DBToolsForm.copyoverins != null && MyProject.Forms.DBToolsForm.copyoverins.SourceDB_Ram != null)
		{
			return true;
		}
		Print("Error executing method : No RamDB instance");
		return false;
	}

	public void RegisterFunction(string MethodName, string Description)
	{
		lua_0.RegisterFunction(MethodName, this, GetType().GetMethod(MethodName));
		dictionary_0.Add(MethodName, Description);
	}

	public void FetchMethods()
	{
		foreach (KeyValuePair<string, string> item in dictionary_0)
		{
			Print(item.Key + " " + item.Value);
		}
	}

	public void Print(string Text)
	{
		if (!string.IsNullOrEmpty(Text))
		{
			DarkRichTextBox tB_LuaOutput;
			((RichTextBox)(tB_LuaOutput = MyProject.Forms.DBToolsForm.TB_LuaOutput)).Text = ((RichTextBox)tB_LuaOutput).Text + Environment.NewLine;
			((RichTextBox)(tB_LuaOutput = MyProject.Forms.DBToolsForm.TB_LuaOutput)).Text = ((RichTextBox)tB_LuaOutput).Text + Text;
		}
	}

	public void ExecuteQuery(string SQL_Query)
	{
		if (SanityCheck_RamDBInstance())
		{
			Common.mySourceDB_Helper.ExecuteNonQuery(SQL_Query, CloseConnectionWhenDone: false, LogQuery: true);
			Print("Executed : " + SQL_Query);
		}
	}

	public LuaTable FetchSimilarNodeEntry(string TheDatabase, int DBID, string TableNode, float SimilarityThreshold, bool OpenWindow)
	{
		if (!SanityCheck_RamDBInstance())
		{
			return null;
		}
		Ram_Database sourceDB_Ram = MyProject.Forms.DBToolsForm.copyoverins.SourceDB_Ram;
		Ram_Database targetDB_Ram = MyProject.Forms.DBToolsForm.copyoverins.TargetDB_Ram;
		bool flag = false;
		if (!sourceDB_Ram.Tables_Node.ContainsKey(TableNode))
		{
			Print("Error executing method : the node " + TableNode + " does not exist.");
			return null;
		}
		string text = TheDatabase.ToLower();
		if (Operators.CompareString(text, "source", true) != 0)
		{
			if (Operators.CompareString(text, "target", true) != 0)
			{
				Print("Error executing method : specify 'source' or 'target' for the database argument.");
				return null;
			}
			flag = false;
		}
		else
		{
			flag = true;
		}
		Ram_Database ram_Database = sourceDB_Ram;
		if (!flag)
		{
			ram_Database = targetDB_Ram;
		}
		if (ram_Database.Tables_Node[TableNode].ParentHashtable.GetRowsByID(DBID.ToString()).Count == 0)
		{
			Print("Error executing method : ID #" + DBID + " was not found.");
			return null;
		}
		HashTable_Pair hashTable_Pair = new HashTable_Pair(sourceDB_Ram.Tables_Node[TableNode].ParentHashtable, targetDB_Ram.Tables_Node[TableNode].ParentHashtable);
		foreach (KeyValuePair<HashTable_Row, float> item in hashTable_Pair.FetchSimilarRows(DBID.ToString()))
		{
			Print(item.Key.Name + "(ID#" + item.Key.GetID() + ")  similar at " + (item.Value * 100f).ToString("0.#") + "%");
		}
		LuaTable result = default(LuaTable);
		return result;
	}

	static RamDB_Lua()
	{
		Class72.smethod_20();
	}
}
