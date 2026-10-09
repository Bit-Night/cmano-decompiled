using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotPrune]
[DoNotObfuscate]
[DoNotPruneType]
public sealed class MLDetailViewModel : CommandViewModel
{
	private long long_0;

	private bool bool_0;

	private LoggedMessage loggedMessage_0;

	private string string_0;

	private string string_1;

	private string string_2;

	private DateTime dateTime_0;

	private double double_0;

	private double double_1;

	private bool bool_1;

	private Brush brush_0;

	private Visibility visibility_0;

	private bool bool_2;

	[CompilerGenerated]
	private RelayCommand relayCommand_0;

	[CompilerGenerated]
	private RelayCommand relayCommand_1;

	public long Increment
	{
		get
		{
			return long_0;
		}
		set
		{
			SetProperty(ref long_0, value, "Increment");
		}
	}

	public bool IsSideMessage
	{
		get
		{
			return bool_0;
		}
		set
		{
			SetProperty(ref bool_0, value, "IsSideMessage");
		}
	}

	public LoggedMessage LoggedMessage
	{
		get
		{
			return loggedMessage_0;
		}
		set
		{
			SetProperty(ref loggedMessage_0, value, "LoggedMessage");
		}
	}

	public string Text
	{
		get
		{
			return string_0;
		}
		set
		{
			SetProperty(ref string_0, value, "Text");
		}
	}

	public string LongText
	{
		get
		{
			return string_1;
		}
		set
		{
			SetProperty(ref string_1, value, "LongText");
		}
	}

	public string Summary
	{
		get
		{
			return string_2;
		}
		set
		{
			SetProperty(ref string_2, value, "Summary");
		}
	}

	public DateTime Timestamp
	{
		get
		{
			return dateTime_0;
		}
		set
		{
			SetProperty(ref dateTime_0, value, "Timestamp");
		}
	}

	public double Lat
	{
		get
		{
			return double_0;
		}
		set
		{
			SetProperty(ref double_0, value, "Lat");
		}
	}

	public double Lon
	{
		get
		{
			return double_1;
		}
		set
		{
			SetProperty(ref double_1, value, "Lon");
		}
	}

	public bool Read
	{
		get
		{
			return bool_1;
		}
		set
		{
			SetProperty(ref bool_1, value, "Read");
		}
	}

	public Brush Brush
	{
		get
		{
			return brush_0;
		}
		set
		{
			SetProperty(ref brush_0, value, "Brush");
		}
	}

	public Visibility PlusVisibility
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return visibility_0;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			SetProperty(ref visibility_0, value, "PlusVisibility");
		}
	}

	public bool Expanded
	{
		get
		{
			return bool_2;
		}
		set
		{
			SetProperty(ref bool_2, value, "Expanded");
		}
	}

	public RelayCommand ExpandCommand
	{
		[CompilerGenerated]
		get
		{
			return relayCommand_0;
		}
		[CompilerGenerated]
		set
		{
			relayCommand_0 = value;
		}
	}

	public RelayCommand OpenHyperlinkCommand
	{
		[CompilerGenerated]
		get
		{
			return relayCommand_1;
		}
		[CompilerGenerated]
		set
		{
			relayCommand_1 = value;
		}
	}

	public string RawDisplay
	{
		get
		{
			string text = "";
			if (LoggedMessage.Side != null)
			{
				text = LoggedMessage.Side.ObjectID;
			}
			if (!string.IsNullOrEmpty(text) && Operators.CompareString(text, Client.CurrentSide.ObjectID, true) != 0)
			{
				return Timestamp.ToLongTimeString() + " - [" + LoggedMessage.Side.Name + "] " + Text;
			}
			return Timestamp.ToLongTimeString() + " - " + LongText;
		}
	}

	public MLDetailViewModel()
	{
		ExpandCommand = new RelayCommand([SpecialName] (object a0) =>
		{
			moaHfXdvolQ();
		});
		OpenHyperlinkCommand = new RelayCommand([SpecialName] (object a0) =>
		{
			method_0();
		});
	}

	private void method_0()
	{
		Client.CurrentScenario.UnhandledPopUpMessages.Enqueue(LoggedMessage);
	}

	private void moaHfXdvolQ()
	{
		if (Expanded)
		{
			PlusVisibility = (Visibility)0;
			Expanded = false;
			Text = StripHTML.StripTagsRegex(Summary);
		}
		else
		{
			PlusVisibility = (Visibility)2;
			Expanded = true;
			Text = StripHTML.StripTagsRegex(LongText);
		}
	}

	static MLDetailViewModel()
	{
		Class72.smethod_20();
	}
}
