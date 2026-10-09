using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[StandardModule]
public sealed class WindowPlacement
{
	public static Dictionary<string, Tuple<int, int, int, int>> WindowPlacementSettings;

	static WindowPlacement()
	{
		Class72.smethod_20();
		WindowPlacementSettings = new Dictionary<string, Tuple<int, int, int, int>>();
	}

	public static void UpdateWindowPlacementSetting(string FormName, int PosX, int PosY, int width, int height)
	{
		if (!WindowPlacementSettings.ContainsKey(FormName))
		{
			WindowPlacementSettings.Add(FormName, new Tuple<int, int, int, int>(PosX, PosY, width, height));
		}
		else
		{
			WindowPlacementSettings[FormName] = new Tuple<int, int, int, int>(PosX, PosY, width, height);
		}
	}

	public static void GetWindowPlacementSetting(CommandSecondaryFormBase theForm)
	{
		if (WindowPlacementSettings.ContainsKey(((Control)theForm).Name))
		{
			Tuple<int, int, int, int> tuple = WindowPlacementSettings[((Control)theForm).Name];
			if (theForm.ApplyStoredPositionSettings)
			{
				((Form)theForm).Location = new Point(tuple.Item1, tuple.Item2);
			}
			if (theForm.ApplyStoredSizeSettings)
			{
				if (((Form)theForm).MinimumSize.Width > tuple.Item3)
				{
					((Control)theForm).Width = ((Form)theForm).MinimumSize.Width;
				}
				else
				{
					((Control)theForm).Width = tuple.Item3;
				}
				if (((Form)theForm).MinimumSize.Height <= tuple.Item4)
				{
					((Control)theForm).Height = tuple.Item4;
				}
				else
				{
					((Control)theForm).Height = ((Form)theForm).MinimumSize.Height;
				}
			}
			return;
		}
		try
		{
			((Form)theForm).StartPosition = (FormStartPosition)2;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200488", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void GetWindowPlacementSetting(DarkSecondaryFormBase theForm)
	{
		if (WindowPlacementSettings.ContainsKey(((Control)theForm).Name))
		{
			Tuple<int, int, int, int> tuple = WindowPlacementSettings[((Control)theForm).Name];
			if (theForm.ApplyStoredPositionSettings)
			{
				((Form)theForm).Location = new Point(tuple.Item1, tuple.Item2);
			}
			if (theForm.ApplyStoredSizeSettings)
			{
				if (((Form)theForm).MinimumSize.Width > tuple.Item3)
				{
					((Control)theForm).Width = ((Form)theForm).MinimumSize.Width;
				}
				else if (((Control)theForm).Width != tuple.Item3)
				{
					((Control)theForm).Width = tuple.Item3;
				}
				if (((Form)theForm).MinimumSize.Height > tuple.Item4)
				{
					((Control)theForm).Height = ((Form)theForm).MinimumSize.Height;
				}
				else if (((Control)theForm).Height != tuple.Item4)
				{
					((Control)theForm).Height = tuple.Item4;
				}
			}
			return;
		}
		try
		{
			Point location = default(Point);
			location.X = (int)Math.Round((double)Screen.AllScreens[0].Bounds.Width / 2.0 - (double)((Control)theForm).Width / 2.0);
			location.Y = (int)Math.Round((double)Screen.AllScreens[0].Bounds.Height / 2.0 - (double)((Control)theForm).Height / 2.0);
			((Form)theForm).Location = location;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200488", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}
}
