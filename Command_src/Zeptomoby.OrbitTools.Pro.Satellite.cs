using System;
using System.Runtime.CompilerServices;

namespace Zeptomoby.OrbitTools.Pro;

public class Satellite : IEciObject
{
	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private IOrbit iorbit_0;

	public string Name
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		private set
		{
			string_0 = value;
		}
	}

	public IOrbit Orbit
	{
		[CompilerGenerated]
		get
		{
			return iorbit_0;
		}
		[CompilerGenerated]
		private set
		{
			iorbit_0 = value;
		}
	}

	public Satellite(OrbitalElements elem, WgsModel ellipsoid, string name = "")
	{
		Orbit = new Orbit(elem, ellipsoid);
		Name = ((!(name == "")) ? name : Orbit.SatName);
	}

	public Satellite(IOrbit orbit, string name = "")
	{
		Orbit = orbit;
		Name = ((!(name == "")) ? name : Orbit.SatName);
	}

	public EciTime PositionEci(double mpe)
	{
		return Orbit.PositionEci(mpe);
	}

	public EciTime PositionEci(DateTimeOffset time)
	{
		return Orbit.PositionEci(time);
	}

	[Obsolete("Use overloaded method PositionEci(DateTimeOffset")]
	public EciTime PositionEci(DateTime utc)
	{
		return Orbit.PositionEci(utc);
	}

	static Satellite()
	{
		Class72.smethod_20();
	}
}
