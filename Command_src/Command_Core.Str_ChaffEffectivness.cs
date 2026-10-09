using System.Collections.Generic;

namespace Command_Core;

public sealed class Str_ChaffEffectivness
{
	public Dictionary<GlobalVariables.TargetVisualSizeClass, float> ShipSize;

	public Str_ChaffEffectivness(float _VSmallTarget, float _SmallTarget, float _MediumTarget, float _LargeTarget, float _VLargeTarget, float _StealthyTarget)
	{
		ShipSize = new Dictionary<GlobalVariables.TargetVisualSizeClass, float>();
		ShipSize.Add(GlobalVariables.TargetVisualSizeClass.VSmall, _VSmallTarget);
		ShipSize.Add(GlobalVariables.TargetVisualSizeClass.Small, _SmallTarget);
		ShipSize.Add(GlobalVariables.TargetVisualSizeClass.Medium, _MediumTarget);
		ShipSize.Add(GlobalVariables.TargetVisualSizeClass.Large, _LargeTarget);
		ShipSize.Add(GlobalVariables.TargetVisualSizeClass.VLarge, _VLargeTarget);
		ShipSize.Add(GlobalVariables.TargetVisualSizeClass.Stealthy, _StealthyTarget);
	}

	static Str_ChaffEffectivness()
	{
		Class72.smethod_20();
	}
}
