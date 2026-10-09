using System;

namespace Command_Core;

public struct P2PContacSnaphot
{
	public double Latitude;

	public double Longitude;

	public float Altitude;

	public float Heading;

	public float Speed;

	public float Age;

	public bool KnownThroughComms;

	public DateTime FrozenAt;
}
