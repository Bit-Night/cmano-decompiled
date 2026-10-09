using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Entity.Information.Minefield;

[Serializable]
public enum OpticalSensor : uint
{
	[Description("Unaided Eye, Actively Searching.")]
	UnaidedEyeActivelySearching,
	[Description("Unaided Eye, Not Actively Searching.")]
	UnaidedEyeNotActivelySearching,
	[Description("Binoculars.")]
	Binoculars,
	[Description("Image Intensifier.")]
	ImageIntensifier,
	[Description("HMMWV occupant, Actively Searching.")]
	HMMWVOccupantActivelySearching,
	[Description("HMMWV occupant, Not Actively Searching.")]
	HMMWVOccupantNotActivelySearching,
	[Description("Truck occupant, Actively Searching.")]
	TruckOccupantActivelySearching,
	[Description("Truck occupant, Not Actively Searching.")]
	TruckOccupantNotActivelySearching,
	[Description("Tracked vehicle occupant, closed hatch, Actively Searching.")]
	TrackedVehicleOccupantClosedHatchActivelySearching,
	[Description("Tracked vehicle occupant, closed hatch, Not Actively Searching.")]
	TrackedVehicleOccupantClosedHatchNotActivelySearching,
	[Description("Tracked vehicle occupant, open hatch, Actively Searching.")]
	TrackedVehicleOccupantOpenHatchActivelySearching,
	[Description("Tracked vehicle occupant, open hatch, Not Actively Searching.")]
	TrackedVehicleOccupantOpenHatchNotActivelySearching
}
