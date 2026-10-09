using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Type;

[Serializable]
public enum UKWeaponsForLifeForms : byte
{
	[Description("LAW 80.")]
	LAW80 = 1,
	[Description("Blowpipe.")]
	Blowpipe,
	[Description("Javelin.")]
	Javelin,
	[Description("51-mm mortar.")]
	_51MmMortar,
	[Description("SLR 7.62-mm rifle.")]
	SLR762MmRifle,
	[Description("Sterling 9-mm submachine gun.")]
	Sterling9MmSubmachineGun,
	[Description("L7A2 general purpose MG.")]
	const_6,
	[Description("L6 Wombat Recoilless rifle,.")]
	L6WombatRecoillessRifle,
	[Description("Carl Gustav 89-mm recoilless rifle.")]
	CarlGustav89MmRecoillessRifle,
	[Description("SA80 Individual/light support weapon.")]
	SA80IndividualLightSupportWeapon,
	[Description("Trigat.")]
	Trigat,
	[Description("Milan AT missile.")]
	MilanATMissile
}
