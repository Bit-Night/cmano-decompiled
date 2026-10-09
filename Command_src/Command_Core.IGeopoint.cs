namespace Command_Core;

public interface IGeopoint
{
	double Longitude { get; set; }

	double Latitude { get; set; }

	float Altitude { get; set; }
}
