using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotObfuscate]
[DoNotPrune]
[DoNotPruneType]
public sealed class GClass5 : CommandViewModel
{
	private double double_0;

	private double double_1;

	private double double_2;

	private double double_3;

	private double double_4;

	private double double_5;

	private string string_0;

	private object object_0;

	private double double_6;

	private double double_7;

	private double double_8;

	private double double_9;

	private double double_10;

	private double double_11;

	private double double_12;

	private double double_13;

	private bool bool_0;

	private Color color_0;

	private double double_14;

	private string string_1;

	private Brush brush_0;

	private FastObservableCollection<MLDetailViewModel> fastObservableCollection_0;

	private DateTime dateTime_0;

	private bool bool_1;

	private string string_2;

	private MessageLogControlViewModel messageLogControlViewModel_0;

	private ICommand icommand_0;

	public double CanvasLeft
	{
		get
		{
			return double_0;
		}
		set
		{
			SetProperty(ref double_0, value, "CanvasLeft");
		}
	}

	public double CanvasTop
	{
		get
		{
			return double_1;
		}
		set
		{
			SetProperty(ref double_1, value, "CanvasTop");
		}
	}

	public double StemCanvasLeft
	{
		get
		{
			return double_2;
		}
		set
		{
			SetProperty(ref double_2, value, "StemCanvasLeft");
		}
	}

	public double StemCanvasTop
	{
		get
		{
			return double_3;
		}
		set
		{
			SetProperty(ref double_3, value, "StemCanvasTop");
		}
	}

	public double ObservedHeight
	{
		get
		{
			return double_4;
		}
		set
		{
			SetProperty(ref double_4, value, "ObservedHeight");
		}
	}

	public double ObservedWidth
	{
		get
		{
			return double_5;
		}
		set
		{
			SetProperty(ref double_5, value, "ObservedWidth");
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

	public object Tag
	{
		get
		{
			return object_0;
		}
		set
		{
			SetProperty(ref object_0, RuntimeHelpers.GetObjectValue(value), "Tag");
		}
	}

	public double Lat
	{
		get
		{
			return double_6;
		}
		set
		{
			SetProperty(ref double_6, value, "Lat");
		}
	}

	public double Opacity
	{
		get
		{
			return double_7;
		}
		set
		{
			SetProperty(ref double_7, value, "Opacity");
		}
	}

	public double X1
	{
		get
		{
			return double_8;
		}
		set
		{
			SetProperty(ref double_8, value, "X1");
		}
	}

	public double X2
	{
		get
		{
			return double_9;
		}
		set
		{
			SetProperty(ref double_9, value, "X2");
		}
	}

	public double Y1
	{
		get
		{
			return double_10;
		}
		set
		{
			SetProperty(ref double_10, value, "Y1");
		}
	}

	public double Y2
	{
		get
		{
			return double_11;
		}
		set
		{
			SetProperty(ref double_11, value, "Y2");
		}
	}

	public double Radius
	{
		get
		{
			return double_12;
		}
		set
		{
			SetProperty(ref double_12, value, "Radius");
		}
	}

	public double Theta
	{
		get
		{
			return double_13;
		}
		set
		{
			SetProperty(ref double_13, value, "Theta");
		}
	}

	public bool Hover
	{
		get
		{
			return bool_0;
		}
		set
		{
			SetProperty(ref bool_0, value, "Hover");
		}
	}

	public Color Color
	{
		get
		{
			return color_0;
		}
		set
		{
			SetProperty(ref color_0, value, "Color");
		}
	}

	public double Lon
	{
		get
		{
			return double_14;
		}
		set
		{
			SetProperty(ref double_14, value, "Lon");
		}
	}

	public string Header
	{
		get
		{
			return string_1;
		}
		set
		{
			SetProperty(ref string_1, value, "Header");
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

	public FastObservableCollection<MLDetailViewModel> Details
	{
		get
		{
			return fastObservableCollection_0;
		}
		set
		{
			SetProperty(ref fastObservableCollection_0, value, "Details");
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

	public bool Expanded
	{
		get
		{
			return bool_1;
		}
		set
		{
			SetProperty(ref bool_1, value, "Expanded");
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

	public MessageLogControlViewModel MessageLogVM
	{
		get
		{
			return messageLogControlViewModel_0;
		}
		set
		{
			SetProperty(ref messageLogControlViewModel_0, value, "MessageLogVM");
		}
	}

	public ICommand ClickMeCommand
	{
		get
		{
			return icommand_0;
		}
		set
		{
			SetProperty(ref icommand_0, value, "ClickMeCommand");
		}
	}

	public GClass5()
	{
		fastObservableCollection_0 = new FastObservableCollection<MLDetailViewModel>();
		bool_1 = false;
	}

	static GClass5()
	{
		Class72.smethod_20();
	}
}
