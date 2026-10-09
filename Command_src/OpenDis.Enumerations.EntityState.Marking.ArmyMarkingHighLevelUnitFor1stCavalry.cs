using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Marking;

[Serializable]
public enum ArmyMarkingHighLevelUnitFor1stCavalry : byte
{
	[Description("1-7CAV.  unit: 1-7 Cavalry.")]
	_17CAVUnit17Cavalry = 1,
	[Description("2-5CAV.  unit: 2-5 Cavalry.")]
	_25CAVUnit25Cavalry = 2,
	[Description("2-8CAV.  unit: 2-8 Cavalry.")]
	_28CAVUnit28Cavalry = 3,
	[Description("3-32AR.  unit: 3-32 Armor Reg.")]
	_332ARUnit332ArmorReg = 4,
	[Description("1-5CAV.  unit: 1-5 Cavalry.")]
	_15CAVUnit15Cavalry = 5,
	[Description("1-8CAV.  unit: 1-8 Cavalry.")]
	_18CAVUnit18Cavalry = 6,
	[Description("1-32AR.  unit: 1-32 Armor Reg.")]
	_132ARUnit132ArmorReg = 7,
	[Description("1-67AR.  unit: 1-67 Armor Reg.")]
	_167ARUnit167ArmorReg = 8,
	[Description("3-67AR.  unit: 3-67 Armor Reg.")]
	_367ARUnit367ArmorReg = 9,
	[Description("3-41INF.  unit: 3-41 Infantry.")]
	_341INFUnit341Infantry = 10,
	[Description("1-82F.  unit: 1-82 Field Art.")]
	_182FUnit182FieldArt = 20,
	[Description("3-82F.  unit: 3-82 Field Art.")]
	_382FUnit382FieldArt = 21,
	[Description("1-3F.  unit: 1-3 Field Art.")]
	_13FUnit13FieldArt = 22,
	[Description("21F.  unit: 21 Field Art.")]
	_21FUnit21FieldArt = 23,
	[Description("92F.  unit: 92 Field Art.")]
	_92FUnit92FieldArt = 24,
	[Description("8E.  unit: 8 Engineer.")]
	_8EUnit8Engineer = 30,
	[Description("20E.  unit: 20 Engineer.")]
	_20EUnit20Engineer = 31,
	[Description("91E.  unit: 91 Engineer.")]
	_91EUnit91Engineer = 32,
	[Description("1-227AVN.  unit: 1-227 Aviation.")]
	_1227AVNUnit1227Aviation = 34,
	[Description("4-227AVN.  unit: 4-227 Aviation.")]
	_4227AVNUnit4227Aviation = 35,
	[Description("F-227AVN.  unit: F-227 Aviation.")]
	F227AVNUnitF227Aviation = 36,
	[Description("4-5ADA.  unit: 4-5 Air Def Art.")]
	_45ADAUnit45AirDefArt = 37,
	[Description("15MSB.  unit: 15 Main Supp.")]
	_15MSBUnit15MainSupp = 40,
	[Description("27FSB.  unit: 27 Forward Supp.")]
	_27FSBUnit27ForwardSupp = 41,
	[Description("115FSB.  unit: 115 Forward Supp.")]
	_115FSBUnit115ForwardSupp = 42,
	[Description("215FSB.  unit: 215 Forward Supp.")]
	_215FSBUnit215ForwardSupp = 43,
	[Description("312MI.  unit: 312 Mil Intell..")]
	_312MIUnit312MilIntell = 45,
	[Description("13S.  unit: 13 Signal.")]
	_13SUnit13Signal = 46,
	[Description("545MP.  unit: 545 Mil Police.")]
	_545MPUnit545MilPolice = 47,
	[Description("68CML.  unit: 68 Chemical.")]
	_68CMLUnit68Chemical = 48,
	[Description("1CAV.  unit: HHC 1st Cavalry.")]
	_1CAVUnitHHC1stCavalry = 50,
	[Description("HHC 1 BDE")]
	HHC_1_BDE = 51,
	[Description("HHC 2 BDE")]
	HHC_2_BDE = 52,
	[Description("HHC 3 BDE")]
	HHC_3_BDE = 53,
	[Description("HHC 4 BDE")]
	HHC_4_BDE = 54,
	[Description("AVNBDE.  unit: HHC AVN BDE.")]
	const_35 = 55,
	[Description("E.  unit: HHD EN BDE.")]
	EUnitHHDENBDE = 56,
	[Description("F.  unit: HHB DIVARTY.")]
	FUnitHHBDIVARTY = 57,
	[Description("DSC.  unit: DISCOM.")]
	DSCUnitDISCOM = 58
}
