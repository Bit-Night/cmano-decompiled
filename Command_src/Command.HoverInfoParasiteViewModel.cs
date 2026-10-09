using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotPruneType]
[DoNotPrune]
[DoNotObfuscate]
public sealed class HoverInfoParasiteViewModel : CommandViewModel
{
	private string string_0;

	private string string_1;

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

	public string Ready
	{
		get
		{
			return string_1;
		}
		set
		{
			SetProperty(ref string_1, value, "Ready");
		}
	}

	static HoverInfoParasiteViewModel()
	{
		Class72.smethod_20();
	}
}
