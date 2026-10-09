using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class MDSP_Error
{
	[ThreadStatic]
	private static StringBuilder stringBuilder_0;

	public string Mission;

	public string Flight;

	public string Message;

	public MDSP_Error()
	{
	}

	public MDSP_Error(string mission, string flight, string message)
	{
		Mission = mission;
		Flight = flight;
		Message = message;
	}

	public string ToXML(HashSet<string> ObjectsAlreadySerialized)
	{
		try
		{
			if (stringBuilder_0 == null)
			{
				stringBuilder_0 = new StringBuilder();
			}
			else
			{
				stringBuilder_0.Clear();
			}
			stringBuilder_0.Append("<MDSP_Error>");
			if (Operators.CompareString(Mission, string.Empty, false) != 0)
			{
				stringBuilder_0.Append("<Mission>").Append(Mission).Append("</Mission>");
			}
			if (Operators.CompareString(Flight, string.Empty, false) != 0)
			{
				stringBuilder_0.Append("<Flight>").Append(Flight).Append("</Flight>");
			}
			if (Operators.CompareString(Message, string.Empty, false) != 0)
			{
				stringBuilder_0.Append("<Message>").Append(Message).Append("</Message>");
			}
			stringBuilder_0.Append("</MDSP_Error>");
			return stringBuilder_0.ToString();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 1345145151451", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static MDSP_Error FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		MDSP_Error mDSP_Error = new MDSP_Error();
		MDSP_Error result;
		try
		{
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "Flight":
					mDSP_Error.Flight = val.InnerText;
					continue;
				case "Message":
					mDSP_Error.Message = val.InnerText;
					continue;
				case "Mission":
					mDSP_Error.Mission = val.InnerText;
					continue;
				default:
					result = smethod_0(val.InnerText);
					break;
				}
				goto end_IL_0006;
			}
			result = mDSP_Error;
			end_IL_0006:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 1312312314515", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private static MDSP_Error smethod_0(string string_0)
	{
		MDSP_Error mDSP_Error = new MDSP_Error();
		try
		{
			int num = string_0.IndexOf("! Mission") + 9;
			int num2 = string_0.IndexOf(", Flight") + 9;
			int num3 = string_0.IndexOf(":");
			if (num >= 0 && num2 > num)
			{
				mDSP_Error.Mission = string_0.Substring(num, num2 - num);
			}
			if (num2 >= 0 && num3 > num2)
			{
				mDSP_Error.Flight = string_0.Substring(num2, num3 - num2);
			}
			mDSP_Error.Message = string_0;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		return mDSP_Error;
	}

	static MDSP_Error()
	{
		Class72.smethod_20();
	}
}
