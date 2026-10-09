namespace Command_Core;

public sealed class CargoTracker
{
	public Cargo _cargo;

	public int _loaded;

	public int _unloaded;

	public CargoTracker(Cargo c, int l, int u)
	{
		_cargo = c;
		_loaded = l;
		_unloaded = u;
	}

	static CargoTracker()
	{
		Class72.smethod_20();
	}
}
