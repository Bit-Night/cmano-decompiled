using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotObfuscate]
[DoNotPrune]
[DoNotPruneType]
public sealed class DatabaseControlTypeViewModel : CommandViewModel
{
	private string string_0;

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

	static DatabaseControlTypeViewModel()
	{
		Class72.smethod_20();
	}
}
