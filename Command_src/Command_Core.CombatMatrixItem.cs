using System;

namespace Command_Core;

[Serializable]
public struct CombatMatrixItem
{
	public string Type;

	public float NoArmor;

	public float LightArmor;

	public float HeavyArmor;
}
