using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[StandardModule]
internal sealed class ErrorManagement
{
	public static Dictionary<string, string> ErrorMessages;

	static ErrorManagement()
	{
		Class72.smethod_20();
		ErrorMessages = new Dictionary<string, string>();
	}

	public static void EnqueueErrorMessage(Exception theExc)
	{
		if (theExc != null)
		{
			string text = "";
			try
			{
				new StackTrace(fNeedFileInfo: true);
				StackTrace stackTrace = new StackTrace(theExc, fNeedFileInfo: true);
				StackFrame frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);
				text = frame.GetFileName() + " " + frame.GetFileLineNumber();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				text = "";
				ProjectData.ClearProjectError();
			}
			if (Operators.CompareString(text, "", true) != 0 && !Enumerable.Contains(ErrorMessages.Keys, text))
			{
				string text2 = "";
				text2 += theExc.Message;
				ErrorMessages.Add(text, text2);
			}
		}
	}

	public static void ShowErrorMessages()
	{
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		if (ErrorMessages == null || ErrorMessages.Count <= 0)
		{
			return;
		}
		string text = "";
		foreach (KeyValuePair<string, string> errorMessage in ErrorMessages)
		{
			text += Environment.NewLine;
			text = text + errorMessage.Value + Environment.NewLine + Environment.NewLine + errorMessage.Key;
			text += Environment.NewLine;
			text += Environment.NewLine;
		}
		MessageBox.Show(text, "ERROR detected");
	}
}
