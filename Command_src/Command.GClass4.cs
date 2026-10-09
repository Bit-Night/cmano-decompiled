using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media;
using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotObfuscate]
[DoNotPrune]
[DoNotPruneType]
public sealed class GClass4 : CommandViewModel
{
	private string string_0;

	private Brush brush_0;

	private FastObservableCollection<MLDetailViewModel> fastObservableCollection_0;

	private DateTime dateTime_0;

	private bool bool_0;

	private string string_1;

	private MessageLogControlViewModel messageLogControlViewModel_0;

	private ICommand icommand_0;

	private ICommand icommand_1;

	public string Header
	{
		get
		{
			return string_0;
		}
		set
		{
			SetProperty(ref string_0, value, "Header");
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
			return bool_0;
		}
		set
		{
			SetProperty(ref bool_0, value, "Expanded");
		}
	}

	public string Summary
	{
		get
		{
			return string_1;
		}
		set
		{
			SetProperty(ref string_1, value, "Summary");
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

	public Brush BackGroundColor
	{
		get
		{
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Expected O, but got Unknown
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Expected O, but got Unknown
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Expected O, but got Unknown
			if (MessageLogVM.HeaderToShow[Summary])
			{
				return (Brush)new SolidColorBrush(Color.FromArgb(byte.MaxValue, (byte)63, (byte)83, (byte)63));
			}
			if (!MessageLogVM.HeaderToShow[Summary])
			{
				return (Brush)new SolidColorBrush(Color.FromArgb(byte.MaxValue, (byte)83, (byte)63, (byte)63));
			}
			return (Brush)new SolidColorBrush(Color.FromArgb(byte.MaxValue, (byte)63, (byte)63, (byte)63));
		}
	}

	public GClass4()
	{
		fastObservableCollection_0 = new FastObservableCollection<MLDetailViewModel>();
		bool_0 = false;
		ClickMeCommand = new RelayCommand([SpecialName] (object a0) =>
		{
			method_0();
		});
	}

	private void method_0()
	{
		MessageLogVM.HeaderToShow[Summary] = !MessageLogVM.HeaderToShow[Summary];
		MessageLogVM.RefreshLoggedMessages();
	}

	static GClass4()
	{
		Class72.smethod_20();
	}
}
