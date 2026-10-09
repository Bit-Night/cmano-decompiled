using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using Command_Core;
using Command_Core.SendFileTo;
using Command.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

public sealed class CustomExceptionHandler
{
	public void ThreadExceptionHandler(object sender, ThreadExceptionEventArgs e)
	{
		try
		{
			Exception exception = e.Exception;
			if (!MyProject.Forms.DebugForm.isInitialised())
			{
				ShowAndLogExceptionMessage(exception);
				return;
			}
			MyProject.Forms.DebugForm.Write("OnThreadException");
			if (exception != null)
			{
				MyProject.Forms.DebugForm.Write("theEx != null");
				MyProject.Forms.DebugForm.Write("e.Exception.GetType().Name: " + e.Exception.GetType().Name);
				MyProject.Forms.DebugForm.Write("theEx.Message: " + exception.Message);
				MyProject.Forms.DebugForm.Write("theEx.StackTrace: " + exception.StackTrace);
				if (!Information.IsNothing((object)exception.InnerException))
				{
					MyProject.Forms.DebugForm.Write("theEx.InnerException.GetType().Name: " + exception.InnerException.GetType().Name);
				}
				if (Information.IsNothing((object)GameGeneral.CatastrophicCoreException))
				{
					return;
				}
				string text = "This is probably a bug. Please save a screenshot of this and submit it, along with the autosave files, for investigation.\r\n\r\nException: " + exception.Message + "\r\n\r\nStack Trace: " + exception.StackTrace + "\r\n\r\n";
				if (!Information.IsNothing((object)exception.InnerException))
				{
					text = text + "Inner Exception: " + exception.InnerException.Message + "\r\n\r\nInner StackTrace: " + exception.InnerException.StackTrace + "\r\n\r\n";
				}
				if (exception.Data.Count > 0)
				{
					text += "Call Stack & Error details: ";
					IDictionaryEnumerator enumerator = exception.Data.GetEnumerator();
					while (enumerator.MoveNext())
					{
						object current = enumerator.Current;
						DictionaryEntry dictionaryEntry = ((current != null) ? ((DictionaryEntry)current) : default(DictionaryEntry));
						text = text + "\r\n" + smethod_0(RuntimeHelpers.GetObjectValue(dictionaryEntry.Key)) + ", " + smethod_0(RuntimeHelpers.GetObjectValue(dictionaryEntry.Value));
					}
				}
				MyProject.Forms.DebugForm.Write(text);
			}
			else
			{
				MyProject.Forms.DebugForm.Write("theEx == null");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception theEx = ex;
			ShowAndLogExceptionMessage(theEx);
			ProjectData.ClearProjectError();
		}
	}

	public static void ShowAndLogExceptionMessage(Exception theEx)
	{
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("Error in Exception Handler! OnThreadException");
			if (theEx != null)
			{
				stringBuilder.AppendLine("theEx != null");
				stringBuilder.AppendLine("Exception Type: " + smethod_0(theEx.GetType()));
				stringBuilder.AppendLine("Message: " + smethod_0(theEx.Message));
				stringBuilder.AppendLine("StackTrace: " + smethod_0(theEx.StackTrace));
				if (theEx.InnerException != null)
				{
					stringBuilder.AppendLine("Inner Type: " + smethod_0(theEx.InnerException.GetType()));
					stringBuilder.AppendLine("Inner Message: " + smethod_0(theEx.InnerException.Message));
					stringBuilder.AppendLine("Inner StackTrace: " + smethod_0(theEx.InnerException.StackTrace));
				}
				if (theEx.Data != null && theEx.Data.Count > 0)
				{
					stringBuilder.AppendLine("Exception.Data:");
					IDictionaryEnumerator enumerator = theEx.Data.GetEnumerator();
					while (enumerator.MoveNext())
					{
						object current = enumerator.Current;
						DictionaryEntry dictionaryEntry = ((current == null) ? default(DictionaryEntry) : ((DictionaryEntry)current));
						stringBuilder.AppendLine("  " + smethod_0(RuntimeHelpers.GetObjectValue(dictionaryEntry.Key)) + " , " + smethod_0(RuntimeHelpers.GetObjectValue(dictionaryEntry.Value)));
					}
				}
			}
			else
			{
				stringBuilder.AppendLine("theEx == null");
			}
			GameGeneral.WriteLogDebugInfoToFile(stringBuilder.ToString());
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			GameGeneral.WriteLogDebugInfoToFile("FATAL: Exception handler failed: " + ex2.GetType().Name + " - " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	private static string smethod_0(object object_0)
	{
		string result;
		if (object_0 != null)
		{
			try
			{
				result = object_0.ToString();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				result = "<ToString threw " + ex2.GetType().Name + ">";
				ProjectData.ClearProjectError();
			}
		}
		else
		{
			result = "<null>";
		}
		return result;
	}

	private void method_0(Exception exception_0)
	{
		new StringBuilder();
		MAPI mAPI = new MAPI();
		mAPI.AddAttachment("c:\\\\temp\\\\file1.txt");
		mAPI.AddAttachment("c:\\\\temp\\\\file2.txt");
		mAPI.AddRecipientTo("person1@somewhere.com");
		mAPI.AddRecipientTo("person2@somewhere.com");
		mAPI.SendMailPopup("testing", "body text");
	}

	static CustomExceptionHandler()
	{
		Class72.smethod_20();
	}
}
