namespace Command_Core;

public class Contact_Base : Module_Unit.Unit
{
	public enum ContactType : byte
	{
		Air,
		Missile,
		Surface,
		Submarine,
		UndeterminedNaval,
		Aimpoint,
		Orbital,
		Facility_Fixed,
		Facility_Mobile,
		Torpedo,
		Mine,
		Explosion,
		Undetermined,
		Decoy_Air,
		Decoy_Surface,
		Decoy_Land,
		Decoy_Sub,
		Sonobuoy,
		Installation,
		AirBase,
		NavalBase,
		MobileGroup,
		ActivationPoint,
		AggregateGroundUnit
	}

	public enum IdentificationStatus : short
	{
		Unknown,
		KnownDomain,
		KnownType,
		KnownClass,
		PreciseID
	}

	public ContactType Type;

	public bool SideIsKnown;

	protected int _AutoIncrement;

	protected IdentificationStatus _IDStatus;

	public Side OriginalDetectorSide;

	protected string _OriginalDetectorSide_Name;

	public string OriginalDetectorUnitID;

	public string ContactType_String => Type switch
	{
		ContactType.Air => "Air", 
		ContactType.Missile => "Missile", 
		ContactType.Surface => "Surface", 
		ContactType.Submarine => "Submarine", 
		ContactType.UndeterminedNaval => "Undetermined Naval", 
		ContactType.Aimpoint => "Aimpoint", 
		ContactType.Orbital => "Orbital", 
		ContactType.Facility_Fixed => "Fixed Facility", 
		ContactType.Facility_Mobile => "Mobile Unit", 
		ContactType.Torpedo => "Torpedo", 
		ContactType.Mine => "Mine", 
		ContactType.Explosion => "Explosion", 
		ContactType.Undetermined => "Undetermined", 
		ContactType.Decoy_Air => "Decoy (Air)", 
		ContactType.Decoy_Surface => "Decoy (Surface)", 
		ContactType.Decoy_Land => "Decoy (Land)", 
		ContactType.Decoy_Sub => "Decoy (Underwater)", 
		ContactType.Sonobuoy => "Sonobuoy", 
		ContactType.Installation => "Fixed Installation", 
		ContactType.AirBase => "AirBase", 
		ContactType.NavalBase => "Naval Base", 
		ContactType.MobileGroup => "Mobile Group", 
		ContactType.ActivationPoint => "Activation Point", 
		_ => Type.ToString(), 
	};

	static Contact_Base()
	{
		Class72.smethod_20();
	}
}
