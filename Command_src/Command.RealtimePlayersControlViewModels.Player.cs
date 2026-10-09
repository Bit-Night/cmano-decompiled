namespace Command.RealtimePlayersControlViewModels;

public class Player : CommandViewModel
{
	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private string string_4;

	private string string_5;

	private string string_6;

	private string string_7;

	public string Name
	{
		get
		{
			return string_0;
		}
		set
		{
			SetProperty(ref string_0, value, "Name");
		}
	}

	public string CurrentSide_Name
	{
		get
		{
			return string_1;
		}
		set
		{
			SetProperty(ref string_1, value, "CurrentSide_Name");
		}
	}

	public string Rights
	{
		get
		{
			return string_2;
		}
		set
		{
			SetProperty(ref string_2, value, "Rights");
		}
	}

	public string IP
	{
		get
		{
			return string_3;
		}
		set
		{
			SetProperty(ref string_3, value, "IP");
		}
	}

	public string SelectedUnit_Name
	{
		get
		{
			return string_4;
		}
		set
		{
			SetProperty(ref string_4, value, "SelectedUnit_Name");
		}
	}

	public string LastMessageType
	{
		get
		{
			return string_5;
		}
		set
		{
			SetProperty(ref string_5, value, "LastMessageType");
		}
	}

	public string LockedSide
	{
		get
		{
			return string_6;
		}
		set
		{
			SetProperty(ref string_6, value, "LockedSide");
		}
	}

	public string CPU
	{
		get
		{
			return string_7;
		}
		set
		{
			SetProperty(ref string_7, value, "CPU");
		}
	}

	static Player()
	{
		Class72.smethod_20();
	}
}
