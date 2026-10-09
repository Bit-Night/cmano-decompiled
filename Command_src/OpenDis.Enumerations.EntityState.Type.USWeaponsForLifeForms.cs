using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Type;

[Serializable]
public enum USWeaponsForLifeForms : byte
{
	[Description("Assault machine pistol, KF-AMP.")]
	AssaultMachinePistolKFAMP = 1,
	[Description("Automatic model 1911A1 .45.")]
	AutomaticModel1911A145 = 2,
	[Description("Combat Master Mark VI .45, Detronics.")]
	CombatMasterMarkVI45Detronics = 3,
	[Description("De-cocker KP90DC .45.")]
	DeCockerKP90DC45 = 4,
	[Description("De-cocker KP91DC .40.")]
	DeCockerKP91DC40 = 5,
	[Description("General officer's Model 15 .45.")]
	GeneralOfficerSModel1545 = 6,
	[Description("Nova 9-mm, LaFrance.")]
	Nova9MmLaFrance = 7,
	[Description("Personal Defense Weapon MP5K-PDW 9-mm.")]
	PersonalDefenseWeaponMP5KPDW9Mm = 8,
	[Description("Silenced Colt .45, LaFrance.")]
	SilencedColt45LaFrance = 9,
	[Description("5900-series 9-mm, Smith &amp; Wesson (S&amp;W).")]
	_5900Series9MmSmithWessonSW = 10,
	[Description("M9.")]
	M9 = 11,
	[Description("Model 1911A1, Springfield Armory.")]
	Model1911A1SpringfieldArmory = 12,
	[Description("Model 2000 9-mm.")]
	Model20009Mm = 13,
	[Description("P-9 9-mm, Springfield Armory.")]
	P99MmSpringfieldArmory = 14,
	[Description("P-12 9-mm.")]
	P129Mm = 15,
	[Description("P-85 Mark II 9-mm, Ruger.")]
	P85MarkII9MmRuger = 16,
	[Description("Advanced Combat Rifle 5.56-mm, AAI.")]
	AdvancedCombatRifle556MmAAI = 17,
	[Description("Commando assault rifle, Model 733 5.56-mm, Colt.")]
	CommandoAssaultRifleModel733556MmColt = 18,
	[Description("Infantry rifle, Mini-14/20 GB 5.56-mm, Ruger.")]
	InfantryRifleMini1420GB556MmRuger = 19,
	[Description("Mini-14 5.56-mm, Ruger.")]
	Mini14556MmRuger = 20,
	[Description("Mini Thirty 7.62-mm, Ruger.")]
	const_20 = 21,
	[Description("Semi-automatic model 82A2 .50, Barrett.")]
	SemiAutomaticModel82A250Barrett = 22,
	[Description("Sniper Weapon System M24 7.62-mm.")]
	SniperWeaponSystemM24762Mm = 23,
	[Description("Sniping rifle M21, Springfield Armory.")]
	SnipingRifleM21SpringfieldArmory = 24,
	[Description("Sniping rifle M40A1 7.62-mm.")]
	SnipingRifleM40A1762Mm = 25,
	[Description("Sniping rifle M600 7.62-mm.")]
	SnipingRifleM600762Mm = 26,
	[Description("AR-15 (M16) 5.56-mm.")]
	AR15M16556Mm = 27,
	[Description("M1 .30.")]
	M130 = 28,
	[Description("M14 7.62-mm, NATO.")]
	M14762MmNATO = 29,
	[Description("M14 (M1A, M1A1-A1), Springfield Armory.")]
	M14M1AM1A1A1SpringfieldArmory = 30,
	[Description("M14K assault rifle, LaFrance.")]
	M14KAssaultRifleLaFrance = 31,
	[Description("M16A2 assault rifle 5.56-mm, Colt.")]
	M16A2AssaultRifle556MmColt = 32,
	[Description("M21 7.62-mm, U.S.")]
	const_32 = 33,
	[Description("M77 Mark II 5.56-mm, Ruger.")]
	const_33 = 34,
	[Description("M77V 7.62-mm, Ruger.")]
	M77V762MmRuger = 35,
	[Description("S-16 7.62 x 36-mm, Grendel.")]
	const_35 = 36,
	[Description("SAR-8 7.62-mm.")]
	const_36 = 37,
	[Description("SAR-4800 7.62-mm.")]
	SAR4800762Mm = 38,
	[Description("Assault carbine M16K, LaFrance.")]
	AssaultCarbineM16KLaFrance = 39,
	[Description("M1 .30.")]
	M130_40 = 40,
	[Description("M4 (Model 720) 5.56-mm, Colt.")]
	const_40 = 41,
	[Description("M-900 9-mm, Calico.")]
	M9009MmCalico = 42,
	[Description("AC-556F 5.56-mm, Ruger.")]
	AC556F556MmRuger = 43,
	[Description("M3 .45.")]
	M345 = 44,
	[Description("M11, Cobray.")]
	const_44 = 45,
	[Description("M951 9-mm, Calico.")]
	M9519MmCalico = 46,
	[Description("MP5/10 10-mm.")]
	const_46 = 47,
	[Description("9-mm, Colt.")]
	_9MmColt = 48,
	[Description("Ingram.")]
	Ingram = 49,
	[Description("Externally powered (EPG) 7.62-mm, Ares.")]
	ExternallyPoweredEPG762MmAres = 50,
	[Description("GECAL 50.")]
	GECAL50 = 51,
	[Description("General purpose M60 7.62-mm.")]
	GeneralPurposeM60762Mm = 52,
	[Description("Heavy M2HB-QCB .50, RAMO.")]
	const_52 = 53,
	[Description("Light assault M60E3 (Enhanced) 7.62-mm.")]
	LightAssaultM60E3Enhanced762Mm = 54,
	[Description("Light M16A2 5.56-mm, Colt.")]
	const_54 = 55,
	[Description("Light 5.56-mm, Ares.")]
	Light556MmAres = 56,
	[Description("Lightweight M2 .50, RAMO.")]
	const_56 = 57,
	[Description("Lightweight assault M60E3 7.62-mm.")]
	LightweightAssaultM60E3762Mm = 58,
	[Description("Minigun M134 7.62-mm, General Electric.")]
	MinigunM134762MmGeneralElectric = 59,
	[Description("MG system MK19 Mod 3, 40-mm.")]
	const_59 = 60,
	[Description("MG system (or kit) M2HB QCB .50, Saco Defense.")]
	MGSystemOrKitM2HBQCB50SacoDefense = 61,
	[Description("M1919A4 .30-cal, Browning.")]
	const_61 = 62,
	[Description(".50-cal, Browning.")]
	_50CalBrowning = 63,
	[Description("Colored-smoke hand grenade M18.")]
	ColoredSmokeHandGrenadeM18 = 64,
	[Description("Colored-smoke grenades, Federal Laboratories.")]
	ColoredSmokeGrenadesFederalLaboratories = 65,
	[Description("Infrared smoke grenade M76.")]
	InfraredSmokeGrenadeM76 = 66,
	[Description("Smoke hand grenade AN-M8 HC.")]
	SmokeHandGrenadeANM8HC = 67,
	[Description("Delay fragmentation hand grenade M61.")]
	DelayFragmentationHandGrenadeM61 = 68,
	[Description("Delay fragmentation hand grenade M67.")]
	DelayFragmentationHandGrenadeM67 = 69,
	[Description("Impact fragmentation hand grenade M57.")]
	ImpactFragmentationHandGrenadeM57 = 70,
	[Description("Impact fragmentation hand grenade M68.")]
	ImpactFragmentationHandGrenadeM68 = 71,
	[Description("Incendiary hand grenade AN-M14 TH3.")]
	IncendiaryHandGrenadeANM14TH3 = 72,
	[Description("Launcher I-M203 40-mm.")]
	LauncherIM20340Mm = 73,
	[Description("Launcher M79 40-mm.")]
	LauncherM7940Mm = 74,
	[Description("Multiple grenade launcher MM-1 40-mm.")]
	MultipleGrenadeLauncherMM140Mm = 75,
	[Description("Multi-shot portable flame weapon M202A2 66-mm.")]
	MultiShotPortableFlameWeaponM202A266Mm = 76,
	[Description("Portable ABC-M9-7.")]
	PortableABCM97 = 77,
	[Description("Portable M2A1-7.")]
	PortableM2A17 = 78,
	[Description("Portable M9E1-7.")]
	PortableM9E17 = 79,
	[Description("Dragon medium anti-armor missile, M47, FGM-77A.")]
	DragonMediumAntiArmorMissileM47FGM77A = 80,
	[Description("Javelin AAWS-M.")]
	JavelinAAWSM = 81,
	[Description("Light Antitank Weapon M72 (LAW II).")]
	LightAntitankWeaponM72LAWII = 82,
	[Description("Redeye, FIM-43, General Dynamics.")]
	RedeyeFIM43GeneralDynamics = 83,
	[Description("Saber dual-purpose missile system.")]
	SaberDualPurposeMissileSystem = 84,
	[Description("Stinger, FIM-92, General Dynamics.")]
	StingerFIM92GeneralDynamics = 85,
	[Description("TOW heavy antitank weapon.")]
	TOWHeavyAntitankWeapon = 86,
	[Description("Bear Trap AP device, Pancor.")]
	BearTrapAPDevicePancor = 87,
	[Description("Chain Gun automatic weapon EX-34 7.62-mm.")]
	ChainGunAutomaticWeaponEX34762Mm = 88,
	[Description("Close Assault Weapon System (CAWS), AAI.")]
	CloseAssaultWeaponSystemCAWSAAI = 89,
	[Description("CAWS, Olin/Heckler and Koch.")]
	CAWSOlinHecklerAndKoch = 90,
	[Description("Crossfire SAM Model 88.")]
	const_90 = 91,
	[Description("Dragon and M16.")]
	DragonAndM16 = 92,
	[Description("Firing port weapon M231, 5.56-mm, Colt.")]
	FiringPortWeaponM231556MmColt = 93,
	[Description("Foxhole Digger Explosive Kit (EXFODA).")]
	FoxholeDiggerExplosiveKitEXFODA = 94,
	[Description("Infantry Support Weapon ASP-30 {RM} 30-mm.")]
	InfantrySupportWeaponASP30RM30Mm = 95,
	[Description("Jackhammer Mk 3-A2, Pancor.")]
	JackhammerMk3A2Pancor = 96,
	[Description("Light anti-armor weapon M136 (AT4).")]
	LightAntiArmorWeaponM136AT4 = 97,
	[Description("M26A2.")]
	M26A2 = 98,
	[Description("Master Key S.")]
	MasterKeyS = 99,
	[Description("Minigun 5.56-mm.")]
	Minigun556Mm = 100,
	[Description("Multipurpose Individual Munition (MPIM), Marquardt.")]
	MultipurposeIndividualMunitionMPIMMarquardt = 101,
	[Description("Multipurpose weapon AT8.")]
	MultipurposeWeaponAT8 = 102,
	[Description("Recoilless rifle M40, M40A2, and M40A4; 106-mm.")]
	RecoillessRifleM40M40A2AndM40A4106Mm = 103,
	[Description("Recoilless rifle M67, 90-mm.")]
	RecoillessRifleM6790Mm = 104,
	[Description("Revolver, SP 101.")]
	RevolverSP101 = 105,
	[Description("Revolver, Super Redhawk .44 magnum, Ruger.")]
	RevolverSuperRedhawk44MagnumRuger = 106,
	[Description("RAW rocket, 140-mm, Brunswick.")]
	RAWRocket140MmBrunswick = 107,
	[Description("Rifle-launcher Anti-Armor Munition (RAAM), Olin.")]
	RifleLauncherAntiArmorMunitionRAAMOlin = 108,
	[Description("Rocket launcher M-20 3.5-in.")]
	RocketLauncherM2035In = 109,
	[Description("Rocket launcher, Enhanced M72 E series HEAT, 66-mm.")]
	RocketLauncherEnhancedM72ESeriesHEAT66Mm = 110,
	[Description("Selective fire weapon AC-556 5.56-mm, Ruger.")]
	SelectiveFireWeaponAC556556MmRuger = 111,
	[Description("Selective fire weapon AC-556F 5.56-mm, Ruger.")]
	SelectiveFireWeaponAC556F556MmRuger = 112,
	[Description("Shotgun M870 Mk 1 (U.S. Marine Corps), Remington.")]
	ShotgunM870Mk1USMarineCorpsRemington = 113,
	[Description("SMAW Mk 193, 83-mm, McDonnell-Douglas.")]
	SMAWMk19383MmMcDonnellDouglas = 114,
	[Description("SMAW-D: Disposable SMAW.")]
	const_114 = 115,
	[Description("Squad Automatic Weapon (SAW) M249 5.56-mm.")]
	SquadAutomaticWeaponSAWM249556Mm = 116,
	[Description("Tactical Support Weapon 50/12, .50-cal, Peregrine.")]
	TacticalSupportWeapon501250CalPeregrine = 117,
	[Description("Telescoped Ammunition Revolver Gun (TARG) .50-cal, Ares.")]
	TelescopedAmmunitionRevolverGunTARG50CalAres = 118,
	[Description("Ultimate over-under combination, Ciener.")]
	UltimateOverUnderCombinationCiener = 119,
	[Description("M18A1 Claymore mine.")]
	M18A1ClaymoreMine = 120,
	[Description("Mortar 81-mm.")]
	const_120 = 121,
	[Description("Machinegun M240 7.62mm.")]
	const_121 = 134
}
