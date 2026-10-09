using Command_Core;
using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotObfuscate]
[DoNotPrune]
[DoNotPruneType]
public sealed class CargoMissionMothershipUnitViewModel : CommandViewModel
{
	public ActiveUnit theUnit;

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

	public CargoMissionMothershipUnitViewModel(ActiveUnit theUnit)
	{
		this.theUnit = theUnit;
		Name = theUnit.Name;
	}

	static CargoMissionMothershipUnitViewModel()
	{
		Class72.smethod_20();
	}
}
