using Command_Core;
using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotPrune]
[DoNotObfuscate]
[DoNotPruneType]
public sealed class CargoMissionAssignedUnitViewModel
{
	public ActiveUnit theUnit;

	public CargoMissionAssignedUnitViewModel(ActiveUnit theUnit)
	{
		this.theUnit = theUnit;
	}

	static CargoMissionAssignedUnitViewModel()
	{
		Class72.smethod_20();
	}
}
