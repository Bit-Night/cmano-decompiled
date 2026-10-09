using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Marking;

[Serializable]
public enum ArmyMarkingHighLevelUnitFor1stInfantry : byte
{
	[Description("1-16INF.  unit: 1-16 Infantry.")]
	_116INFUnit116Infantry = 1,
	[Description("2-16INF.  unit: 2-16 Infantry.")]
	_216INFUnit216Infantry = 2,
	[Description("1-34AR.  unit: 1-34 Armor.")]
	_134ARUnit134Armor = 3,
	[Description("2-34AR.  unit: 2-34 Armor.")]
	_234ARUnit234Armor = 4,
	[Description("3-37AR.  unit: 3-37 Armor.")]
	_337ARUnit337Armor = 5,
	[Description("4-37AR.  unit: 4-37 Armor.")]
	_437ARUnit437Armor = 6,
	[Description("1-118INF.  unit: 1-118 Infantry.")]
	_1118INFUnit1118Infantry = 7,
	[Description("4-118INF.  unit: 4-118 Infantry.")]
	_4118INFUnit4118Infantry = 8,
	[Description("2-265AR.  unit: 2-263 Armor.")]
	_2265ARUnit2263Armor = 9,
	[Description("2-136IF.  unit: 2-136 Infantry.")]
	_2136IFUnit2136Infantry = 10,
	[Description("1-5F.  unit: 1-5 Field Art.")]
	_15FUnit15FieldArt = 20,
	[Description("4-5F.  unit: 4-5 Field Art.")]
	_45FUnit45FieldArt = 21,
	[Description("1-178F.  unit: 1-178 Field Art.")]
	_1178FUnit1178FieldArt = 22,
	[Description("6F.  unit: B/6 Field Art.")]
	_6FUnitB6FieldArt = 23,
	[Description("25F.  unit: D/25 Field Art.")]
	_25FUnitD25FieldArt = 24,
	[Description("1E.  unit: 1 Engineer.")]
	_1EUnit1Engineer = 30,
	[Description("70E.  unit: 70 Engineer.")]
	_70EUnit70Engineer = 31,
	[Description("4-1AVN.  unit: 4-1 Aviation.")]
	_41AVNUnit41Aviation = 32,
	[Description("1-1AVN.  unit: 1-1 Aviation.")]
	_11AVNUnit11Aviation = 33,
	[Description("2-3ADA.  unit: 2-3 Air Def Art.")]
	_23ADAUnit23AirDefArt = 34,
	[Description("1-4CAV.  unit: 1-4 Cavalry.")]
	_14CAVUnit14Cavalry = 35,
	[Description("701MSB.  unit: 701 Main Supp.")]
	_701MSBUnit701MainSupp = 40,
	[Description("101FSB.  unit: 101 Forward Supp.")]
	_101FSBUnit101ForwardSupp = 41,
	[Description("201FSB.  unit: 201 Forward Supp.")]
	_201FSBUnit201ForwardSupp = 42,
	[Description("163FSB.  unit: 163 Forward Supp.")]
	_163FSBUnit163ForwardSupp = 43,
	[Description("101MI.  unit: 101 Mil Intell.")]
	_101MIUnit101MilIntell = 45,
	[Description("121S.  unit: 121 Signal.")]
	_121SUnit121Signal = 46,
	[Description("1MP.  unit: 1st Mil Police.")]
	_1MPUnit1stMilPolice = 47,
	[Description("12CML.  unit: 12 Chemical.")]
	_12CMLUnit12Chemical = 48,
	[Description("1INF.  unit: HHC 1st Infantry.")]
	_1INFUnitHHC1stInfantry = 50,
	[Description("HHC 1 BDE")]
	HHC_1_BDE = 51,
	[Description("HHC 2 BDE")]
	HHC_2_BDE = 52,
	[Description("HHC 3 BDE")]
	HHC_3_BDE = 53,
	[Description("HHC 4 BDE")]
	HHC_4_BDE = 54,
	[Description("AVNBDE.  unit: HHC AVN BDE.")]
	const_34 = 55,
	[Description("E.  unit: HHD EN BDE.")]
	EUnitHHDENBDE = 56,
	[Description("F.  unit: HHB DIVARTY.")]
	FUnitHHBDIVARTY = 57,
	[Description("DSC.  unit: DISCOM.")]
	DSCUnitDISCOM = 58
}
