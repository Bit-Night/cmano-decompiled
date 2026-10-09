namespace Command;

public sealed class DoctrineControlPhony
{
	public void RefreshPanel(bool v)
	{
		RightColumnPhony.Refresh(Client.SelectedUnit);
	}

	static DoctrineControlPhony()
	{
		Class72.smethod_20();
	}
}
