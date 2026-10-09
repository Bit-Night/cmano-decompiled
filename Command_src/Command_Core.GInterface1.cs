using System.Collections.Generic;

namespace Command_Core;

public interface GInterface1
{
	float DegreeInterval_Coarse { get; }

	float DegreeInterval_Finegrained { get; }

	List<Waypoint> SolvePF_Finegrained(ActiveUnit theUnit, double StartLat, double StartLon, double EndLat, double EndLon, float CurrentHeading, float DegreeBuffer, float ProximityThreshold_Deg, ref List<ActiveUnit> ProvidedPiers, ref float PercentComplete, bool IsMissionPlannerRequest);

	List<Waypoint> SolvePF_Coarse(ActiveUnit theUnit, double StartLat, double StartLon, double EndLat, double EndLon, float CurrentHeading, float DegreeBuffer, float ProximityThreshold_Deg, ref List<ActiveUnit> ProvidedPiers, ref float PercentComplete, bool IsMissionPlannerRequest, bool AllowFineGrainedNav);
}
