using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotPrune]
[DoNotPruneType]
[DoNotObfuscate]
public sealed class HoverInfoCargoViewModel : CommandViewModel
{
	private string string_0;

	private int int_0;

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

	public int Quantity
	{
		get
		{
			return int_0;
		}
		set
		{
			SetProperty(ref int_0, value, "Quantity");
		}
	}

	static HoverInfoCargoViewModel()
	{
		Class72.smethod_20();
	}
}
