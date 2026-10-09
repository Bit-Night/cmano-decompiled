using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Logistics;

[Serializable]
public enum AuxilaryCraftRepairCode : ushort
{
	[Description("life boats.")]
	LifeBoats = 10000,
	[Description("landing craft.")]
	LandingCraft = 10010,
	[Description("ejection seats.")]
	EjectionSeats = 10020
}
