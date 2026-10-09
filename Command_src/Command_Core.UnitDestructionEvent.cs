using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
internal sealed class UnitDestructionEvent
{
	public const string Impact = "Impact / Detonation";

	public const string Miss = "Missed";

	public const string Weapon = "Weapon Interaction";

	public const string Fuel = "Out of Fuel";

	public const string Spoofed = "Spoofed";

	public const string Jammed = "JammingInfo";

	public const string Malfunction = "Malfunction";

	public const string Submunitions = "Sub-munitions Expended";

	public const string Self = "Self-destruct";

	public const string Secondary = "Fire / Flooding";

	public const string Facilities = "Host Destruction";

	static UnitDestructionEvent()
	{
		Class72.smethod_20();
	}
}
