using System.Runtime.CompilerServices;

namespace CommandNetcode;

public class RTMP_MultiplayerLicense
{
	[CompilerGenerated]
	private int int_0 = 2;

	[CompilerGenerated]
	private int int_1;

	public int MaxPlayers
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public int MaxExtraObservers
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	static RTMP_MultiplayerLicense()
	{
		Class72.smethod_20();
	}
}
