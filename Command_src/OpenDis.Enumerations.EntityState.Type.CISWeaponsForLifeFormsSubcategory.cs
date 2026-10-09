using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Type;

[Serializable]
public enum CISWeaponsForLifeFormsSubcategory : byte
{
	[Description("Automatic (APS) 9-mm, Stechkin.")]
	AutomaticAPS9MmStechkin = 201,
	[Description("PSM 5.45-mm.")]
	PSM545Mm = 202,
	[Description("Self-loading (PM) 9-mm, Makarov.")]
	SelfLoadingPM9MmMakarov = 203,
	[Description("TT-33 7.62-mm, Tokarev.")]
	TT33762MmTokarev = 204,
	[Description("Assault rifle AK and AKM, 7.62-mm.")]
	AssaultRifleAKAndAKM762Mm = 205,
	[Description("Assault rifle AK-74 and AKS-74, 5.45-mm.")]
	AssaultRifleAK74AndAKS74545Mm = 206,
	[Description("Self-loading rifle (SKS), 7.62-mm, Simonov.")]
	SelfLoadingRifleSKS762MmSimonov = 207,
	[Description("Sniper rifle SVD 7.62-mm, Dragunov.")]
	SniperRifleSVD762MmDragunov = 208,
	[Description("AKSU-74 5.45-mm.")]
	const_8 = 209,
	[Description("PPS-43 7.62-mm.")]
	const_9 = 210,
	[Description("PPSh-41 7.62-mm.")]
	const_10 = 211,
	[Description("General purpose PK 7.62-mm.")]
	GeneralPurposePK762Mm = 212,
	[Description("Heavy DShK-38 and Model 38/46 12.7-mm, Degtyarev.")]
	HeavyDShK38AndModel3846127MmDegtyarev = 213,
	[Description("Heavy NSV 12.7-mm.")]
	HeavyNSV127Mm = 214,
	[Description("Light RPD 7.62-mm.")]
	LightRPD762Mm = 215,
	[Description("Light RPK 7.62-mm.")]
	LightRPK762Mm = 216,
	[Description("Light RPK-74 5.45-mm.")]
	LightRPK74545Mm = 217,
	[Description("Hand grenade M75.")]
	HandGrenadeM75 = 218,
	[Description("Hand grenade RGD-5.")]
	HandGrenadeRGD5 = 219,
	[Description("AP hand grenade F1.")]
	APHandGrenadeF1 = 220,
	[Description("AT hand grenade RKG-3.")]
	ATHandGrenadeRKG3 = 221,
	[Description("AT hand grenade RKG-3M.")]
	const_21 = 222,
	[Description("AT hand grenade RKG-3T.")]
	const_22 = 223,
	[Description("Fragmentation hand grenade RGN.")]
	FragmentationHandGrenadeRGN = 224,
	[Description("Fragmentation hand grenade RGO.")]
	FragmentationHandGrenadeRGO = 225,
	[Description("Smoke hand grenade RDG-1.")]
	const_25 = 226,
	[Description("Plamya launcher, 30-mm AGS-17.")]
	PlamyaLauncher30MmAGS17 = 227,
	[Description("Rifle-mounted launcher, BG-15 40-mm.")]
	RifleMountedLauncherBG1540Mm = 228,
	[Description("LPO-50.")]
	LPO50 = 229,
	[Description("ROKS-3.")]
	ROKS3 = 230,
	[Description("Cart-mounted TPO-50.")]
	CartMountedTPO50 = 231,
	[Description("Gimlet SA-16.")]
	const_31 = 232,
	[Description("Grail SA-7.")]
	GrailSA7 = 233,
	[Description("Gremlin SA-14.")]
	const_33 = 234,
	[Description("Sagger AT-3 (MCLOS).")]
	SaggerAT3MCLOS = 235,
	[Description("Saxhorn AT-7.")]
	const_35 = 236,
	[Description("Spigot A/B AT-14.")]
	SpigotABAT14 = 237,
	[Description("SA-18.")]
	SA18 = 238,
	[Description("SA-19.")]
	SA19 = 239,
	[Description("Grad-1P manportable tripod rocket launcher, 122-mm (for Spesnatz and other specialists; aka 9P132).")]
	Grad1PManportableTripodRocketLauncher122MmForSpesnatzAndOtherSpecialistsAka9P132 = 240,
	[Description("Light anti-armor weapon RPG-18.")]
	LightAntiArmorWeaponRPG18 = 241,
	[Description("Light antitank weapon RPG-22.")]
	LightAntitankWeaponRPG22 = 242,
	[Description("MG &amp; RPG.")]
	MGRPG = 243,
	[Description("Portable rocket launcher RPG-16.")]
	PortableRocketLauncherRPG16 = 244,
	[Description("Recoilless gun 73-mm SPG-9.")]
	RecoillessGun73MmSPG9 = 245,
	[Description("VAT rocket launcher RPG-7.")]
	VATRocketLauncherRPG7 = 246,
	[Description("Mon-50 antipersonnel mine.")]
	Mon50AntipersonnelMine = 248
}
