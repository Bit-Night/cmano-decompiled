namespace Command_Core;

public interface IMobileGroundUnit
{
	public enum _MobileUnitCategory
	{
		None = 0,
		Infantry = 1000,
		Infantry_Old = 1001,
		Marines = 1010,
		Air_Assault = 1020,
		Mountain = 1030,
		Airborne = 1040,
		Special_Forces = 1100,
		Combined_Arms = 1500,
		Armor = 2000,
		Armor_Recon = 2500,
		Artillery_Gun = 3000,
		Artillery_Towed = 3010,
		Artillery_SP = 3020,
		Artillery_Rocket_Wheeled = 3110,
		Artillery_Rocket_Tracked = 3120,
		Artillery_Mortar = 3200,
		Artillery_SSM = 4000,
		AAA = 5000,
		SAM = 6000,
		Engineer = 7000,
		Supply = 8000,
		Surveillance = 9000,
		Recon = 10000,
		Amphibious_Recon = 10010,
		MechInfantry = 11000,
		MechMarines = 11010,
		MechAirborne = 11040,
		MechWheeled = 11500,
		Motorized_Infantry = 12000,
		Anti_Tank = 13000,
		Radar = 14000,
		ElectronicWarfare = 14100,
		Headquarters = 15000
	}

	_MobileUnitCategory MobileUnitCategory { get; set; }

	GlobalVariables.ArmorRating Armor_General { get; set; }

	bool IsArtillery();
}
