namespace Command_Core;

public sealed class Trajectory_Str
{
	public float MeanSpeed;

	public float AltitudeDeltaPerSecond;

	public float MeanHeading;

	public Trajectory_Str()
	{
	}

	public Trajectory_Str(float _MeanSpeed, float _MeanHeading, float _AltitudeDeltaPerSecond)
	{
		MeanSpeed = _MeanSpeed;
		MeanHeading = _MeanHeading;
		AltitudeDeltaPerSecond = _AltitudeDeltaPerSecond;
	}

	static Trajectory_Str()
	{
		Class72.smethod_20();
	}
}
