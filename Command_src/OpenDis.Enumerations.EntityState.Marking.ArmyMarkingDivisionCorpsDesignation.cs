using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Marking;

[Serializable]
public enum ArmyMarkingDivisionCorpsDesignation : byte
{
	[Description("NA case.")]
	NACase,
	[Description("1st Cavalry.")]
	_1stCavalry,
	[Description("1st Infantry.")]
	_1stInfantry,
	[Description("Corps Assets.")]
	CorpsAssets
}
