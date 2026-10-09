using System;
using System.Collections.Generic;

namespace Command_Core;

[Serializable]
public struct CombatMatrixRules
{
	public List<CombatMatrixItem> Offence;

	public List<CombatMatrixItem> Defense;
}
