using System.Runtime.CompilerServices;
using System.Windows.Media;
using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotObfuscate]
[DoNotPruneType]
[DoNotPrune]
public sealed class UnitWeaponElementViewModel : CommandViewModel
{
	private int int_0;

	private string string_0;

	private int int_1;

	private int int_2;

	private SolidColorBrush solidColorBrush_0;

	private SolidColorBrush solidColorBrush_1;

	private SolidColorBrush solidColorBrush_2;

	private SolidColorBrush solidColorBrush_3;

	private string string_1;

	[CompilerGenerated]
	private RelayCommand relayCommand_0;

	public int WeaponDBID
	{
		get
		{
			return int_0;
		}
		set
		{
			SetProperty(ref int_0, value, "WeaponDBID");
		}
	}

	public string Name
	{
		get
		{
			return string_0;
		}
		set
		{
			SetProperty(ref string_0, value, "Name");
		}
	}

	public int Qty
	{
		get
		{
			return int_1;
		}
		set
		{
			SetProperty(ref int_1, value, "Qty");
		}
	}

	public int Type
	{
		get
		{
			return int_2;
		}
		set
		{
			SetProperty(ref int_2, value, "Type");
		}
	}

	public SolidColorBrush TypeColor
	{
		get
		{
			return solidColorBrush_0;
		}
		set
		{
			SetProperty(ref solidColorBrush_0, value, "TypeColor");
		}
	}

	public SolidColorBrush Type2Color
	{
		get
		{
			return solidColorBrush_1;
		}
		set
		{
			SetProperty(ref solidColorBrush_1, value, "Type2Color");
		}
	}

	public SolidColorBrush Type3Color
	{
		get
		{
			return solidColorBrush_2;
		}
		set
		{
			SetProperty(ref solidColorBrush_2, value, "Type3Color");
		}
	}

	public SolidColorBrush Type4Color
	{
		get
		{
			return solidColorBrush_3;
		}
		set
		{
			SetProperty(ref solidColorBrush_3, value, "Type4Color");
		}
	}

	public string Details
	{
		get
		{
			return string_1;
		}
		set
		{
			SetProperty(ref string_1, value, "Details");
		}
	}

	public RelayCommand OpenDBViewerCommand
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

	public UnitWeaponElementViewModel()
	{
		OpenDBViewerCommand = new RelayCommand([SpecialName] (object a0) =>
		{
			OpenDBViewer();
		});
	}

	public void OpenDBViewer()
	{
		Client.smethod_17("Weapon", WeaponDBID);
	}

	static UnitWeaponElementViewModel()
	{
		Class72.smethod_20();
	}
}
