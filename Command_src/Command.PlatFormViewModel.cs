using Command_Core;
using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotObfuscate]
[DoNotPrune]
[DoNotPruneType]
public class PlatFormViewModel : CommandViewModel
{
	private string string_0;

	public ActiveUnit theUnit;

	public string UnitName
	{
		get
		{
			return string_0;
		}
		set
		{
			SetProperty(ref string_0, value, "UnitName");
		}
	}

	static PlatFormViewModel()
	{
		Class72.smethod_20();
	}
}
