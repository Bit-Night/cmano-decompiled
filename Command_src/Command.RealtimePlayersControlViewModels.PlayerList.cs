using System.Collections.Generic;

namespace Command.RealtimePlayersControlViewModels;

public class PlayerList : CommandViewModel
{
	private List<Player> list_0;

	public List<Player> Players
	{
		get
		{
			return list_0;
		}
		set
		{
			SetProperty(ref list_0, value, "Players");
		}
	}

	public PlayerList()
	{
		list_0 = new List<Player>();
	}

	static PlayerList()
	{
		Class72.smethod_20();
	}
}
