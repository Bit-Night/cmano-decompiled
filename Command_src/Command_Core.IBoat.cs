namespace Command_Core;

public interface IBoat
{
	float Displacement_Empty { get; set; }

	float Displacement_Standard { get; set; }

	float Displacement_Full { get; set; }

	bool IsDedicatedTankerOrUNREP { get; }

	bool IsCavitating();
}
