using System.Collections.Generic;
using Command_Core;

namespace Command;

public class LandingPlan_ImportWrapper
{
	public Dictionary<Zone, LandingZoneWrapper> LandingZones;

	public ActiveUnit Mothership;

	public List<ActiveUnit> AllowedTransports;

	public HashSet<string> AllowedTransportClasses;

	public List<Chalk> Serials;

	public Dictionary<Chalk, Zone> SerialToZoneAssociation;

	public Dictionary<Chalk, int> SerialToPriority;

	public Dictionary<string, HashSet<string>> SerialAllowedTransportClasses;

	public Dictionary<ActiveUnit, Zone> Preboated;

	public LandingPlan_ImportWrapper()
	{
		LandingZones = new Dictionary<Zone, LandingZoneWrapper>();
		AllowedTransports = new List<ActiveUnit>();
		AllowedTransportClasses = new HashSet<string>();
		Serials = new List<Chalk>();
		SerialToZoneAssociation = new Dictionary<Chalk, Zone>();
		SerialToPriority = new Dictionary<Chalk, int>();
		SerialAllowedTransportClasses = new Dictionary<string, HashSet<string>>();
		Preboated = new Dictionary<ActiveUnit, Zone>();
	}

	public LandingPlan_ImportWrapper(ActiveUnit Mothership, List<ActiveUnit> AllowedTransports, List<Chalk> Serials, Dictionary<Zone, LandingZoneWrapper> LandingZones, Dictionary<Chalk, Zone> SerialToZoneAssociation)
	{
		this.LandingZones = new Dictionary<Zone, LandingZoneWrapper>();
		this.AllowedTransports = new List<ActiveUnit>();
		AllowedTransportClasses = new HashSet<string>();
		this.Serials = new List<Chalk>();
		this.SerialToZoneAssociation = new Dictionary<Chalk, Zone>();
		SerialToPriority = new Dictionary<Chalk, int>();
		SerialAllowedTransportClasses = new Dictionary<string, HashSet<string>>();
		Preboated = new Dictionary<ActiveUnit, Zone>();
		this.Mothership = Mothership;
		this.AllowedTransports = AllowedTransports;
		this.Serials = Serials;
		this.LandingZones = LandingZones;
		this.SerialToZoneAssociation = SerialToZoneAssociation;
	}

	static LandingPlan_ImportWrapper()
	{
		Class72.smethod_20();
	}
}
