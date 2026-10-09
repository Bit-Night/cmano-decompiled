using System;

namespace Zeptomoby.OrbitTools;

public interface IOrbit
{
	OrbitalElements Elements { get; }

	double SemiMajorRec { get; }

	double SemiMinorRec { get; }

	double MajorRec { get; }

	double MinorRec { get; }

	double MeanMotionRec { get; }

	double PerigeeKmRec { get; }

	double ApogeeKmRec { get; }

	string SatName { get; }

	string SatNameLong { get; }

	string SatNoradId { get; }

	string SatDesignator { get; }

	WgsModel WgsModel { get; }

	TimeSpan Period { get; }

	DateTime EpochTime { get; }

	EciTime PositionEci(double minutesPastEpoch);

	EciTime PositionEci(DateTimeOffset time);

	[Obsolete("Use overloaded method PositionEci(DateTimeOffset)")]
	EciTime PositionEci(DateTime utc);
}
