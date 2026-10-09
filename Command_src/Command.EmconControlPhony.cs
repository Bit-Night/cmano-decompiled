namespace Command;

public sealed class EmconControlPhony
{
	internal void RefreshPanel(bool v)
	{
		RightColumnPhony.Refresh(Client.SelectedUnit);
	}

	static EmconControlPhony()
	{
		Class72.smethod_20();
	}
}
