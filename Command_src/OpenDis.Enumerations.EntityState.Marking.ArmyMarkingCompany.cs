using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Marking;

[Serializable]
public enum ArmyMarkingCompany : byte
{
	[Description("Value A")]
	A = 66,
	[Description("Value B")]
	B = 67,
	[Description("Value C")]
	C = 68,
	[Description("Value D")]
	D = 69,
	[Description("Value E")]
	E = 70,
	[Description("Value F")]
	F = 71,
	[Description("Value G")]
	G = 72,
	[Description("Value H")]
	H = 73,
	[Description("Value I")]
	I = 74,
	[Description("Value J")]
	J = 75,
	[Description("Value K")]
	K = 76,
	[Description("Value L")]
	L = 77,
	[Description("HQ.")]
	HQ = 113,
	[Description("HHB.")]
	HHB = 98,
	[Description("HHC.")]
	HHC = 99,
	[Description("HHD.")]
	HHD = 100,
	[Description("HHT.")]
	HHT = 116
}
