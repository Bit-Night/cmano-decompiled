using System;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class LuaSAO
{
	public static bool ScenEdit_UseAttachment(string string_0, Scenario ScenarioContext)
	{
		bool result = false;
		try
		{
			if (!Information.IsNothing((object)ScenarioContext))
			{
				foreach (ScenAttachmentObject value in ScenarioContext.ScenAttachments.Values)
				{
					if (Operators.CompareString(value.ObjectID, string_0, false) == 0 || Operators.CompareString(value.Name, string_0, false) == 0)
					{
						value.UseAttachment(ScenarioContext);
						result = true;
						break;
					}
				}
			}
			else
			{
				string[] directories = Directory.GetDirectories(GameGeneral.AttachmentRepoPath);
				foreach (string text in directories)
				{
					if (Operators.CompareString(Path.GetFileName(text), string_0, false) == 0)
					{
						ScenAttachmentObject scenAttachmentObject = ScenAttachmentObject.ReadFromFolder(text);
						if (!Information.IsNothing((object)scenAttachmentObject))
						{
							scenAttachmentObject.UseAttachment(null);
							result = true;
						}
						break;
					}
				}
			}
			return result;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static bool ScenEdit_UseAttachmentOnSide(string string_0, string SideNameOrID, Scenario ScenarioContext)
	{
		bool result = false;
		try
		{
			Side side = null;
			Side[] sides_ReadOnly = ScenarioContext.Sides_ReadOnly;
			foreach (Side side2 in sides_ReadOnly)
			{
				if (Operators.CompareString(side2.Name, SideNameOrID, false) == 0 || Operators.CompareString(side2.ObjectID, SideNameOrID, false) == 0)
				{
					side = side2;
					break;
				}
			}
			if (side == null)
			{
				throw new LuaError("Unknown side " + SideNameOrID + " for " + string_0);
			}
			foreach (ScenAttachmentObject value in ScenarioContext.ScenAttachments.Values)
			{
				if (Operators.CompareString(value.ObjectID, string_0, false) == 0 || Operators.CompareString(value.Name, string_0, false) == 0)
				{
					value.UseAttachmentOnSide(ScenarioContext, side);
					result = true;
					break;
				}
			}
			return result;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	static LuaSAO()
	{
		Class72.smethod_20();
	}
}
