using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Warfare;

[Serializable]
public enum Warhead : ushort
{
	[Description("Other.")]
	Other = 0,
	[Description("Cargo (Variable Submunitions).")]
	CargoVariableSubmunitions = 10,
	[Description("Fuel/Air Explosive.")]
	FuelAirExplosive = 20,
	[Description("Glass Beads.")]
	GlassBeads = 30,
	[Description("1 um.")]
	_1Um = 31,
	[Description("5 um.")]
	_5Um = 32,
	[Description("10 um.")]
	_10Um = 33,
	[Description("High Explosive (HE).")]
	HighExplosiveHE = 1000,
	[Description("HE, Plastic.")]
	const_8 = 1100,
	[Description("HE, Incendiary.")]
	HEIncendiary = 1200,
	[Description("HE, Fragmentation.")]
	HEFragmentation = 1300,
	[Description("HE, Antitank.")]
	const_11 = 1400,
	[Description("HE, Bomblets.")]
	const_12 = 1500,
	[Description("HE, Shaped Charge.")]
	HEShapedCharge = 1600,
	[Description("HE, Continuous Rod.")]
	HEContinuousRod = 1610,
	[Description("HE, Tungsten Ball.")]
	HETungstenBall = 1615,
	[Description("HE, Blast Fragmentation.")]
	const_16 = 1620,
	[Description("HE, Steerable Darts with HE.")]
	HESteerableDartsWithHE = 1625,
	[Description("HE, Darts.")]
	HEDarts = 1630,
	[Description("HE, Flechettes.")]
	HEFlechettes = 1635,
	[Description("HE, Directed Fragmentation.")]
	HEDirectedFragmentation = 1640,
	[Description("HE, Semi-Armor Piercing (SAP).")]
	HESemiArmorPiercingSAP = 1645,
	[Description("HE, Shaped Charge Fragmentation.")]
	HEShapedChargeFragmentation = 1650,
	[Description("HE, Semi-Armor Piercing, Fragmentation.")]
	HESemiArmorPiercingFragmentation = 1655,
	[Description("HE, Hollow Charge.")]
	HEHollowCharge = 1660,
	[Description("HE, Double Hollow Charge.")]
	const_25 = 1665,
	[Description("HE, General Purpose.")]
	HEGeneralPurpose = 1670,
	[Description("HE, Blast Penetrator.")]
	HEBlastPenetrator = 1675,
	[Description("HE, Rod Penetrator.")]
	HERodPenetrator = 1680,
	[Description("HE, Antipersonnel.")]
	HEAntipersonnel = 1685,
	[Description("Smoke.")]
	Smoke = 2000,
	[Description("Illumination.")]
	Illumination = 3000,
	[Description("Practice.")]
	Practice = 4000,
	[Description("Kinetic.")]
	Kinetic = 5000,
	[Description("Mines.")]
	Mines = 6000,
	[Description("Nuclear.")]
	Nuclear = 7000,
	[Description("Nuclear, IMT.")]
	const_36 = 7010,
	[Description("Chemical, General.")]
	ChemicalGeneral = 8000,
	[Description("Chemical, Blister Agent.")]
	ChemicalBlisterAgent = 8100,
	[Description("HD (Mustard).")]
	const_39 = 8110,
	[Description("Thickened HD (Mustard).")]
	const_40 = 8115,
	[Description("Dusty HD (Mustard).")]
	DustyHDMustard = 8120,
	[Description("Chemical, Blood Agent.")]
	ChemicalBloodAgent = 8200,
	[Description("AC (HCN).")]
	ACHCN = 8210,
	[Description("CK (CNCI).")]
	CKCNCI = 8215,
	[Description("CG (Phosgene).")]
	const_45 = 8220,
	[Description("Chemical, Nerve Agent.")]
	ChemicalNerveAgent = 8300,
	[Description("VX.")]
	VX = 8310,
	[Description("Thickened VX.")]
	ThickenedVX = 8315,
	[Description("Dusty VX.")]
	DustyVX = 8320,
	[Description("GA (Tabun).")]
	GATabun = 8325,
	[Description("Thickened GA (Tabun).")]
	ThickenedGATabun = 8330,
	[Description("Dusty GA (Tabun).")]
	DustyGATabun = 8335,
	[Description("GB (Sarin).")]
	GBSarin = 8340,
	[Description("Thickened GB (Sarin).")]
	ThickenedGBSarin = 8345,
	[Description("Dusty GB (Sarin).")]
	DustyGBSarin = 8350,
	[Description("GD (Soman).")]
	GDSoman = 8355,
	[Description("Thickened GD (Soman).")]
	ThickenedGDSoman = 8360,
	[Description("Dusty GD (Soman).")]
	DustyGDSoman = 8365,
	[Description("GF.")]
	GF = 8370,
	[Description("Thickened GF.")]
	ThickenedGF = 8375,
	[Description("Dusty GF.")]
	DustyGF = 8380,
	[Description("Biological.")]
	Biological = 9000,
	[Description("Biological, Virus.")]
	BiologicalVirus = 9100,
	[Description("Biological, Bacteria.")]
	BiologicalBacteria = 9200,
	[Description("Biological, Rickettsia.")]
	BiologicalRickettsia = 9300,
	[Description("Biological, Genetically Modified Micro-organisms.")]
	BiologicalGeneticallyModifiedMicroOrganisms = 9400,
	[Description("Biological, Toxin.")]
	BiologicalToxin = 9500
}
