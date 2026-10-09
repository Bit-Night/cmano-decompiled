using System;

namespace Command_Core;

public sealed class AltBand
{
	public float MaxAlt;

	public float MinAlt;

	public int Speed_Loiter;

	public int Speed_Cruise;

	public int? Speed_Full;

	public int? Speed_Flank;

	public float Consumption_Loiter;

	public float Consumption_Cruise;

	public float? Consumption_Full;

	public float? Consumption_Flank;

	public Lazy<int> MaxSpeed;

	private int method_0()
	{
		if (!Speed_Flank.HasValue)
		{
			if (!Speed_Full.HasValue)
			{
				return Speed_Cruise;
			}
			return Speed_Full.Value;
		}
		return Speed_Flank.Value;
	}

	private AltBand()
	{
		MaxSpeed = new Lazy<int>(method_0);
	}

	public AltBand(float theMaxAlt, float theMinAlt)
	{
		MaxSpeed = new Lazy<int>(method_0);
		MaxAlt = theMaxAlt;
		MinAlt = theMinAlt;
	}

	public AltBand Clone()
	{
		AltBand altBand = new AltBand();
		altBand.MaxAlt = MaxAlt;
		altBand.MinAlt = MinAlt;
		altBand.Speed_Loiter = Speed_Loiter;
		altBand.Speed_Cruise = Speed_Cruise;
		if (Speed_Full.HasValue)
		{
			altBand.Speed_Full = Speed_Full.Value;
		}
		if (Speed_Flank.HasValue)
		{
			altBand.Speed_Flank = Speed_Flank.Value;
		}
		altBand.Consumption_Loiter = Consumption_Loiter;
		altBand.Consumption_Cruise = Consumption_Cruise;
		if (Consumption_Full.HasValue)
		{
			altBand.Consumption_Full = Consumption_Full.Value;
		}
		if (Consumption_Flank.HasValue)
		{
			altBand.Consumption_Flank = Consumption_Flank.Value;
		}
		return altBand;
	}

	public bool CoversSameAltitudeEnvelopeAs(AltBand otherAltBand)
	{
		if (MinAlt == otherAltBand.MinAlt)
		{
			return MaxAlt == otherAltBand.MaxAlt;
		}
		return false;
	}

	static AltBand()
	{
		Class72.smethod_20();
	}
}
