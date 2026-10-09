using System;
using System.Text;
using Command_Core.Lua;
using KeraLua;

namespace Command_Core;

public sealed class LuaError : Exception
{
	public string sMessage;

	public string sFunctionName;

	public int sLine;

	private LuaDebug luaDebug_0;

	public LuaError(string m, string f = null)
	{
		luaDebug_0 = default(LuaDebug);
		sMessage = m;
		if (f == null)
		{
			sFunctionName = LuaSandBox.Singleton().currentFunction;
		}
		else
		{
			sFunctionName = f;
		}
		LuaSandBox.Singleton().lastError = sFunctionName + "/" + m;
		LuaSandBox.Singleton().SB_Getinfo("nSl", ref luaDebug_0);
		sLine = luaDebug_0.CurrentLine;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Clear();
		stringBuilder.Append("Function:" + sFunctionName).Append(" (" + sLine + ") ").Append(" Error:" + sMessage);
		string InfoText = "... ";
		object debugTextObject = stringBuilder.ToString();
		LuaUtility.AddToLuaHistoryFile(ref InfoText, ref debugTextObject);
		LuaSandBox.Singleton().SB_Lua()["_errmsg_"] = m;
		LuaSandBox.Singleton().SB_Lua()["_errfnc_"] = sFunctionName;
		LuaSandBox.Singleton().SB_Lua()["_errnum_"] = 1;
	}

	static LuaError()
	{
		Class72.smethod_20();
	}
}
