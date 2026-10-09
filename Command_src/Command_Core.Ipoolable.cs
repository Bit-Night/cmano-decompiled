namespace Command_Core;

public interface Ipoolable
{
	PoolableObjectType PoolableType { get; }

	void Reinitialize();
}
