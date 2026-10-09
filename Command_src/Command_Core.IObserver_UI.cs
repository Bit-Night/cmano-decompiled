namespace Command_Core;

public interface IObserver_UI
{
	bool IsDisposed { get; }

	void Refresh_FromEvent();
}
