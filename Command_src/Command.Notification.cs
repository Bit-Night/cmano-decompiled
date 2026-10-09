using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

public sealed class Notification
{
	public string Description;

	public string Title;

	public NotificationType Type;

	public DateTime TimeStamp;

	public float FadingTime;

	private int int_0;

	public List<string> ProcessedMultilines_Title;

	public List<string> ProcessedMultilines_Description;

	public int BoxWidth;

	public int HeightAllocatedByText;

	public int SidePadding;

	public Rectangle StringLengthTitle;

	public Rectangle StringLengthDescription;

	public float StringHeightTitle;

	public float StringHeightDescription;

	public int CharactersPerLineTitle;

	public int CharactersPerLineDescription;

	public int TransparencyCountDown
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = Math.Max(0, value);
		}
	}

	public Notification(string _Title, string _Description, NotificationType _Type, float _FadingTime = 10f)
	{
		ProcessedMultilines_Title = new List<string>();
		ProcessedMultilines_Description = new List<string>();
		Description = _Description;
		Title = _Title;
		Type = _Type;
		TransparencyCountDown = 200;
		FadingTime = _FadingTime;
		TimeStamp = DateTime.Now;
	}

	public void ProcessMultilines(bool ForceRefresh = false)
	{
		if (ProcessedMultilines_Title.Count <= 0 || ForceRefresh)
		{
			if (StringLengthTitle.IsEmpty && Operators.CompareString(Title, "", true) != 0)
			{
				StringLengthTitle = MyProject.Forms.MainForm.GetCommandLayer().MeasureString(Color.White, 20, 20, Title, 0.0, 34);
				CharactersPerLineTitle = (int)Math.Round((double)Title.Length / ((double)StringLengthTitle.Width / (double)(BoxWidth - SidePadding * 3)));
			}
			if (StringLengthDescription.IsEmpty && Operators.CompareString(Description, "", true) != 0)
			{
				StringLengthDescription = MyProject.Forms.MainForm.GetCommandLayer().MeasureString(Color.White, 20, 20, Description, 0.0, 30);
				CharactersPerLineDescription = (int)Math.Round((double)Description.Length / ((double)StringLengthDescription.Width / (double)(BoxWidth - SidePadding * 3)));
			}
			StringHeightTitle = StringLengthTitle.Height;
			StringHeightDescription = StringLengthDescription.Height;
			ProcessedMultilines_Title = Misc.FetchMultilineString(Title, CharactersPerLineTitle);
			ProcessedMultilines_Description = Misc.FetchMultilineString(Description, CharactersPerLineDescription);
			HeightAllocatedByText = StringLengthTitle.Height * ProcessedMultilines_Title.Count + StringLengthTitle.Height * ProcessedMultilines_Description.Count;
			if (Operators.CompareString(Description, "", true) != 0)
			{
				HeightAllocatedByText += StringLengthTitle.Height;
			}
		}
	}

	public bool HasExpired()
	{
		if (FadingTime == -1f)
		{
			return false;
		}
		if ((DateTime.Now - TimeStamp).TotalSeconds > (double)FadingTime)
		{
			return true;
		}
		return false;
	}

	public static void DeleteNotification()
	{
		if (GlobalSingleton.GetInstance().NotificationContainer.Count != 0)
		{
			GlobalSingleton.GetInstance().NotificationContainer.RemoveAt(0);
		}
	}

	public static void AddNotification(string Title, string Description, NotificationType Type, float FadingTime = 10f, bool ClearAll = true)
	{
		if (ClearAll)
		{
			GlobalSingleton.GetInstance().NotificationContainer.Clear();
		}
		GlobalSingleton.GetInstance().NotificationContainer.Add(new Notification(Title, Description, Type, FadingTime));
	}

	public static Notification FetchNotification()
	{
		if (GlobalSingleton.GetInstance().NotificationContainer.Count == 0)
		{
			return null;
		}
		return GlobalSingleton.GetInstance().NotificationContainer[0];
	}

	public static VisualIndicator AddIndicator(Module_Unit.Unit TargetUnit, bool IsAnimated = true, Color DesignColor = default(Color))
	{
		return MyProject.Forms.MainForm.AddNotificationIndicator(TargetUnit, IsAnimated, DesignColor);
	}

	public static VisualIndicator AddIndicator(Control ControlInstance, Point Position, Size Size, VisualIndicatorDesign Type = VisualIndicatorDesign.AnimatedCircle, Color DesignColor = default(Color))
	{
		return MyProject.Forms.MainForm.AddNotificationIndicator(ControlInstance, Position, Size, Type, DesignColor);
	}

	public static VisualIndicator AddIndicator(Control ControlInstance, ToolStrip Element, VisualIndicatorDesign Type = VisualIndicatorDesign.AnimatedCircle, Color DesignColor = default(Color))
	{
		return MyProject.Forms.MainForm.AddNotificationIndicator(ControlInstance, Element, Type, DesignColor);
	}

	public static VisualIndicator AddIndicator(Control ControlInstance, Control Element, bool SubmenuHighlight, VisualIndicatorDesign Type = VisualIndicatorDesign.AnimatedCircle, Color DesignColor = default(Color), bool IndicateAllParents = true)
	{
		return MyProject.Forms.MainForm.AddNotificationIndicator(ControlInstance, Element, SubmenuHighlight, Type, DesignColor, IndicateAllParents);
	}

	public static VisualIndicator AddIndicator(Control ControlInstance, ToolStripItem Element, bool SubmenuHighlight = true, VisualIndicatorDesign Type = VisualIndicatorDesign.AnimatedCircle, Color DesignColor = default(Color), bool IndicateAllParents = true)
	{
		return MyProject.Forms.MainForm.AddNotificationIndicator(ControlInstance, Element, SubmenuHighlight, Type, DesignColor, IndicateAllParents);
	}

	public static void RemoveIndicator(VisualIndicator Indicator)
	{
		MyProject.Forms.MainForm.RemoveIndicator(Indicator);
	}

	public static void RemoveIndicator(List<VisualIndicator> Indicator)
	{
		MyProject.Forms.MainForm.RemoveIndicator(Indicator);
	}

	static Notification()
	{
		Class72.smethod_20();
	}
}
