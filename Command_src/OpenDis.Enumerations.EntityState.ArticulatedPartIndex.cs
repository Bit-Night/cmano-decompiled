using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState;

[Serializable]
public enum ArticulatedPartIndex : uint
{
	[Description("rudder.")]
	Rudder = 1024u,
	[Description("left flap.")]
	LeftFlap = 1056u,
	[Description("right flap.")]
	RightFlap = 1088u,
	[Description("left aileron.")]
	LeftAileron = 1120u,
	[Description("right aileron.")]
	RightAileron = 1152u,
	[Description("helicopter - main rotor.")]
	HelicopterMainRotor = 1184u,
	[Description("helicopter - tail rotor.")]
	HelicopterTailRotor = 1216u,
	[Description("other Aircraft Control Surfaces defined as needed.")]
	OtherAircraftControlSurfacesDefinedAsNeeded = 1248u,
	[Description("periscope.")]
	Periscope = 2048u,
	[Description("generic antenna.")]
	GenericAntenna = 2080u,
	[Description("snorkel.")]
	Snorkel = 2112u,
	[Description("other extendible parts defined as needed.")]
	OtherExtendiblePartsDefinedAsNeeded = 2144u,
	[Description("landing gear.")]
	LandingGear = 3072u,
	[Description("tail hook.")]
	TailHook = 3104u,
	[Description("speed brake.")]
	SpeedBrake = 3136u,
	[Description("left weapon bay door.")]
	LeftWeaponBayDoor = 3168u,
	[Description("right weapon bay doors.")]
	RightWeaponBayDoors = 3200u,
	[Description("tank or APC hatch.")]
	TankOrAPCHatch = 3232u,
	[Description("wingsweep.")]
	Wingsweep = 3264u,
	[Description("Bridge launcher.")]
	BridgeLauncher = 3296u,
	[Description("Bridge section 1.")]
	BridgeSection1 = 3328u,
	[Description("Bridge section 2.")]
	BridgeSection2 = 3360u,
	[Description("Bridge section 3.")]
	BridgeSection3 = 3392u,
	[Description("Primary blade 1.")]
	PrimaryBlade1 = 3424u,
	[Description("Primary blade 2.")]
	PrimaryBlade2 = 3456u,
	[Description("Primary boom.")]
	PrimaryBoom = 3488u,
	[Description("Primary launcher arm.")]
	PrimaryLauncherArm = 3520u,
	[Description("other fixed position parts defined as needed.")]
	OtherFixedPositionPartsDefinedAsNeeded = 3552u,
	[Description("Primary turret number 1.")]
	PrimaryTurretNumber1 = 4096u,
	[Description("Primary turret number 2.")]
	PrimaryTurretNumber2 = 4128u,
	[Description("Primary turret number 3.")]
	PrimaryTurretNumber3 = 4160u,
	[Description("Primary turret number 4.")]
	PrimaryTurretNumber4 = 4192u,
	[Description("Primary turret number 5.")]
	PrimaryTurretNumber5 = 4224u,
	[Description("Primary turret number 6.")]
	PrimaryTurretNumber6 = 4256u,
	[Description("Primary turret number 7.")]
	PrimaryTurretNumber7 = 4288u,
	[Description("Primary turret number 8.")]
	PrimaryTurretNumber8 = 4320u,
	[Description("Primary turret number 9.")]
	PrimaryTurretNumber9 = 4352u,
	[Description("Primary turret number 10.")]
	PrimaryTurretNumber10 = 4384u,
	[Description("Primary gun number 1.")]
	PrimaryGunNumber1 = 4416u,
	[Description("Primary gun number 2.")]
	PrimaryGunNumber2 = 4448u,
	[Description("Primary gun number 3.")]
	PrimaryGunNumber3 = 4480u,
	[Description("Primary gun number 4.")]
	PrimaryGunNumber4 = 4512u,
	[Description("Primary gun number 5.")]
	PrimaryGunNumber5 = 4544u,
	[Description("Primary gun number 6.")]
	PrimaryGunNumber6 = 4576u,
	[Description("Primary gun number 7.")]
	PrimaryGunNumber7 = 4608u,
	[Description("Primary gun number 8.")]
	PrimaryGunNumber8 = 4640u,
	[Description("Primary gun number 9.")]
	PrimaryGunNumber9 = 4672u,
	[Description("Primary gun number 10.")]
	const_47 = 4704u,
	[Description("Primary launcher 1.")]
	PrimaryLauncher1 = 4736u,
	[Description("Primary launcher 2.")]
	PrimaryLauncher2 = 4768u,
	[Description("Primary launcher 3.")]
	PrimaryLauncher3 = 4800u,
	[Description("Primary launcher 4.")]
	PrimaryLauncher4 = 4832u,
	[Description("Primary launcher 5.")]
	PrimaryLauncher5 = 4864u,
	[Description("Primary launcher 6.")]
	PrimaryLauncher6 = 4896u,
	[Description("Primary launcher 7.")]
	PrimaryLauncher7 = 4928u,
	[Description("Primary launcher 8.")]
	PrimaryLauncher8 = 4960u,
	[Description("Primary launcher 9.")]
	PrimaryLauncher9 = 4992u,
	[Description("Primary launcher 10.")]
	PrimaryLauncher10 = 5024u,
	[Description("Primary defense systems 1.")]
	PrimaryDefenseSystems1 = 5056u,
	[Description("Primary defense systems 2.")]
	PrimaryDefenseSystems2 = 5088u,
	[Description("Primary defense systems 3.")]
	PrimaryDefenseSystems3 = 5120u,
	[Description("Primary defense systems 4.")]
	PrimaryDefenseSystems4 = 5152u,
	[Description("Primary defense systems 5.")]
	PrimaryDefenseSystems5 = 5184u,
	[Description("Primary defense systems 6.")]
	PrimaryDefenseSystems6 = 5216u,
	[Description("Primary defense systems 7.")]
	PrimaryDefenseSystems7 = 5248u,
	[Description("Primary defense systems 8.")]
	PrimaryDefenseSystems8 = 5280u,
	[Description("Primary defense systems 9.")]
	PrimaryDefenseSystems9 = 5312u,
	[Description("Primary defense systems 10.")]
	PrimaryDefenseSystems10 = 5344u,
	[Description("Primary radar 1.")]
	PrimaryRadar1 = 5376u,
	[Description("Primary radar 2.")]
	PrimaryRadar2 = 5408u,
	[Description("Primary radar 3.")]
	PrimaryRadar3 = 5440u,
	[Description("Primary radar 4.")]
	PrimaryRadar4 = 5472u,
	[Description("Primary radar 5.")]
	PrimaryRadar5 = 5504u,
	[Description("Primary radar 6.")]
	PrimaryRadar6 = 5536u,
	[Description("Primary radar 7.")]
	PrimaryRadar7 = 5568u,
	[Description("Primary radar 8.")]
	PrimaryRadar8 = 5600u,
	[Description("Primary radar 9.")]
	PrimaryRadar9 = 5632u,
	[Description("Primary radar 10.")]
	PrimaryRadar10 = 5664u,
	[Description("Secondary turret number 1.")]
	SecondaryTurretNumber1 = 5696u,
	[Description("Secondary turret number 2.")]
	SecondaryTurretNumber2 = 5728u,
	[Description("Secondary turret number 3.")]
	SecondaryTurretNumber3 = 5760u,
	[Description("Secondary turret number 4.")]
	SecondaryTurretNumber4 = 5792u,
	[Description("Secondary turret number 5.")]
	SecondaryTurretNumber5 = 5824u,
	[Description("Secondary turret number 6.")]
	SecondaryTurretNumber6 = 5856u,
	[Description("Secondary turret number 7.")]
	SecondaryTurretNumber7 = 5888u,
	[Description("Secondary turret number 8.")]
	SecondaryTurretNumber8 = 5920u,
	[Description("Secondary turret number 9.")]
	SecondaryTurretNumber9 = 5952u,
	[Description("Secondary turret number 10.")]
	SecondaryTurretNumber10 = 5984u,
	[Description("Secondary gun number 1.")]
	SecondaryGunNumber1 = 6016u,
	[Description("Secondary gun number 2.")]
	SecondaryGunNumber2 = 6048u,
	[Description("Secondary gun number 3.")]
	SecondaryGunNumber3 = 6080u,
	[Description("Secondary gun number 4.")]
	SecondaryGunNumber4 = 6112u,
	[Description("Secondary gun number 5.")]
	SecondaryGunNumber5 = 6144u,
	[Description("Secondary gun number 6.")]
	SecondaryGunNumber6 = 6176u,
	[Description("Secondary gun number 7.")]
	SecondaryGunNumber7 = 6208u,
	[Description("Secondary gun number 8.")]
	SecondaryGunNumber8 = 6240u,
	[Description("Secondary gun number 9.")]
	SecondaryGunNumber9 = 6272u,
	[Description("Secondary gun number 10.")]
	const_97 = 6304u,
	[Description("Secondary launcher 1.")]
	SecondaryLauncher1 = 6336u,
	[Description("Secondary launcher 2.")]
	SecondaryLauncher2 = 6368u,
	[Description("Secondary launcher 3.")]
	SecondaryLauncher3 = 6400u,
	[Description("Secondary launcher 4.")]
	SecondaryLauncher4 = 6432u,
	[Description("Secondary launcher 5.")]
	SecondaryLauncher5 = 6464u,
	[Description("Secondary launcher 6.")]
	SecondaryLauncher6 = 6496u,
	[Description("Secondary launcher 7.")]
	SecondaryLauncher7 = 6528u,
	[Description("Secondary launcher 8.")]
	SecondaryLauncher8 = 6560u,
	[Description("Secondary launcher 9.")]
	SecondaryLauncher9 = 6592u,
	[Description("Secondary launcher 10.")]
	const_107 = 6624u,
	[Description("Secondary defense systems 1.")]
	SecondaryDefenseSystems1 = 6656u,
	[Description("Secondary defense systems 2.")]
	SecondaryDefenseSystems2 = 6688u,
	[Description("Secondary defense systems 3.")]
	SecondaryDefenseSystems3 = 6720u,
	[Description("Secondary defense systems 4.")]
	SecondaryDefenseSystems4 = 6752u,
	[Description("Secondary defense systems 5.")]
	SecondaryDefenseSystems5 = 6784u,
	[Description("Secondary defense systems 6.")]
	SecondaryDefenseSystems6 = 6816u,
	[Description("Secondary defense systems 7.")]
	SecondaryDefenseSystems7 = 6848u,
	[Description("Secondary defense systems 8.")]
	SecondaryDefenseSystems8 = 6880u,
	[Description("Secondary defense systems 9.")]
	SecondaryDefenseSystems9 = 6912u,
	[Description("Secondary defense systems 10.")]
	SecondaryDefenseSystems10 = 6944u,
	[Description("Secondary radar 1.")]
	SecondaryRadar1 = 6976u,
	[Description("Secondary radar 2.")]
	SecondaryRadar2 = 7008u,
	[Description("Secondary radar 3.")]
	SecondaryRadar3 = 7040u,
	[Description("Secondary radar 4.")]
	SecondaryRadar4 = 7072u,
	[Description("Secondary radar 5.")]
	SecondaryRadar5 = 7104u,
	[Description("Secondary radar 6.")]
	SecondaryRadar6 = 7136u,
	[Description("Secondary radar 7.")]
	SecondaryRadar7 = 7168u,
	[Description("Secondary radar 8.")]
	SecondaryRadar8 = 7200u,
	[Description("Secondary radar 9.")]
	SecondaryRadar9 = 7232u,
	[Description("Secondary radar 10.")]
	SecondaryRadar10 = 7264u,
	[Description("Deck Elevator #1.")]
	DeckElevator1 = 7296u,
	[Description("Deck Elevator #2.")]
	DeckElevator2 = 7328u,
	[Description("Catapult #1.")]
	Catapult1 = 7360u,
	[Description("Catapult #2.")]
	Catapult2 = 7392u,
	[Description("Jet Blast Deflector #1.")]
	JetBlastDeflector1 = 7424u,
	[Description("Jet Blast Deflector #2.")]
	JetBlastDeflector2 = 7456u,
	[Description("Arrestor Wires #1.")]
	ArrestorWires1 = 7488u,
	[Description("Arrestor Wires #2.")]
	ArrestorWires2 = 7520u,
	[Description("Arrestor Wires #3.")]
	ArrestorWires3 = 7552u,
	[Description("Wing (or rotor) fold.")]
	WingOrRotorFold = 7584u,
	[Description("Fuselage fold.")]
	FuselageFold = 7616u
}
