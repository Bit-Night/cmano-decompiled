using System.Runtime.CompilerServices;

namespace PlayFabParty;

public class ConnectionInfo
{
	[CompilerGenerated]
	private ConnectionState connectionState_0;

	public ConnectionState ConnectionState
	{
		[CompilerGenerated]
		get
		{
			return connectionState_0;
		}
		[CompilerGenerated]
		set
		{
			connectionState_0 = value;
		}
	}

	public ConnectionInfo()
	{
		ConnectionState = ConnectionState.Established;
	}

	static ConnectionInfo()
	{
		Class72.smethod_20();
	}
}
