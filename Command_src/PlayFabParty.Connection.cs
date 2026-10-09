using System;
using System.Net;

namespace PlayFabParty;

public class Connection
{
	public static int MyUserID;

	public int OtherUserID;

	public ConnectionInfo ConnectionInfo;

	public static PlayFabPartyClient playFabPartyClient;

	public Connection(uint otherID)
	{
		OtherUserID = (int)otherID;
		ConnectionInfo = new ConnectionInfo();
	}

	public static void StartListening(ConnectionType type, IPEndPoint ip, string serializedNetworkDescriptor = "", string InviteCode = "")
	{
		if (playFabPartyClient != null)
		{
			throw new Exception();
		}
		playFabPartyClient = new PlayFabPartyClient(serializedNetworkDescriptor, InviteCode, MyUserID);
		playFabPartyClient.Connect();
	}

	public static void StopListening()
	{
		if (playFabPartyClient != null)
		{
			playFabPartyClient.Disconnect();
		}
	}

	public void CloseConnection(bool b)
	{
		if (playFabPartyClient != null)
		{
			playFabPartyClient.OnClientDisconnect((uint)OtherUserID);
			playFabPartyClient.Disconnect();
		}
	}

	static Connection()
	{
		Class72.smethod_20();
	}
}
