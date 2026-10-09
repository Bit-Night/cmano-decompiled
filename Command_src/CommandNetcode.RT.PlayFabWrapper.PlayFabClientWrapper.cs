using System.Threading;
using System.Threading.Tasks;
using CMORTMP;
using PlayFab;
using PlayFab.ClientModels;

namespace CommandNetcode.RT.PlayFabWrapper;

public static class PlayFabClientWrapper
{
	public const string TITLE_ID = "162CA5";

	public const string API_END_POINT = "";

	public const string PLAYER_NAMESPACE = "6F54997FF258F889";

	public static string EntityToken;

	public static string EntityID;

	public static string LastErrorMessage;

	public static CMORTMP.PlayFabParty _party;

	public static bool isLoggedIn;

	public static bool isInitialized;

	public static bool isLocalUserCreated;

	public static bool LoginWithCustomID(int SlitherineLobbyUserID, bool isHost = false)
	{
		isLoggedIn = false;
		EntityToken = string.Empty;
		EntityID = string.Empty;
		LastErrorMessage = string.Empty;
		PlayFabSettings.staticSettings.TitleId = "162CA5";
		string empty = string.Empty;
		empty = ((!isHost) ? ("CMORTMPUser_" + SlitherineLobbyUserID) : ("CMORTMPHost_" + SlitherineLobbyUserID));
		Task<PlayFabResult<LoginResult>> task = PlayFabClientAPI.LoginWithCustomIDAsync(new LoginWithCustomIDRequest
		{
			CustomId = empty,
			CreateAccount = true
		});
		if (task != null)
		{
			while (!task.IsCompleted)
			{
				Thread.Sleep(1);
			}
			if (task.Result != null)
			{
				PlayFabError error = task.Result.Error;
				LoginResult result = task.Result.Result;
				if (error != null)
				{
					LastErrorMessage = error.ErrorMessage;
					return false;
				}
				if (result != null)
				{
					EntityID = result.EntityToken.Entity.Id;
					EntityToken = result.EntityToken.EntityToken;
					isLoggedIn = true;
					return true;
				}
			}
		}
		LastErrorMessage = "Unknown error";
		return false;
	}

	public static bool CreateNewNetwork()
	{
		_party = PlayFabPartyManager.GetInstance();
		int num;
		if (isInitialized)
		{
			num = 1;
		}
		else
		{
			if (!_party.Initialize())
			{
				LastErrorMessage = "Error during initialization: ";
				goto IL_007c;
			}
			num = 1;
		}
		isInitialized = (byte)num != 0;
		int num2;
		if (isLocalUserCreated)
		{
			num2 = 1;
		}
		else
		{
			if (!_party.CreateLocalUser(EntityID, EntityToken))
			{
				LastErrorMessage = "Error creating local user: ";
				goto IL_007c;
			}
			num2 = 1;
		}
		isLocalUserCreated = (byte)num2 != 0;
		if (_party.CreateNewNetwork())
		{
			return true;
		}
		LastErrorMessage = "Error creating network: ";
		goto IL_007c;
		IL_007c:
		LastErrorMessage += _party.LastErrorCode;
		_party = null;
		return false;
	}

	public static string GetSerializedNetworkDescriptor()
	{
		string result = string.Empty;
		if (_party != null)
		{
			result = _party.GetSerializedNetworkDescriptor();
		}
		return result;
	}

	public static string GetInviteCode()
	{
		string result = string.Empty;
		if (_party != null)
		{
			result = _party.GetInviteCode();
		}
		return result;
	}

	public static bool Connect(int userID, string serializedNetworkDescriptor, string inviteCode)
	{
		if (_party == null)
		{
			_party = PlayFabPartyManager.GetInstance();
		}
		int num;
		int result;
		if (isInitialized)
		{
			num = 1;
		}
		else
		{
			if (!_party.Initialize())
			{
				LastErrorMessage = "Error during initialization: " + _party.LastErrorCode;
				result = 0;
				goto IL_00c2;
			}
			num = 1;
		}
		isInitialized = (byte)num != 0;
		if (!isLocalUserCreated && !_party.CreateLocalUser(EntityID, EntityToken))
		{
			LastErrorMessage = "Error creating local user: " + _party.LastErrorCode;
			result = 0;
		}
		else
		{
			isLocalUserCreated = true;
			if (_party.ConnectToNetwork(serializedNetworkDescriptor, inviteCode, userID))
			{
				return true;
			}
			LastErrorMessage = "Error connecting to network: " + _party.LastErrorCode;
			result = 0;
		}
		goto IL_00c2;
		IL_00c2:
		return (byte)result != 0;
	}

	public static bool SendMessage(int userID, byte[] data, uint datasize)
	{
		if (_party != null)
		{
			if (_party.SendMessage(userID, data, datasize))
			{
				return true;
			}
			return false;
		}
		LastErrorMessage = "Error not initialized: 0";
		return false;
	}

	public static bool Process()
	{
		if (_party == null)
		{
			return false;
		}
		if (!_party.ProcessStateChanges())
		{
			int result;
			if (_party == null)
			{
				result = 0;
			}
			else
			{
				LastErrorMessage = "Error while processing state changes: " + _party.LastErrorCode;
				result = 0;
			}
			return (byte)result != 0;
		}
		return true;
	}

	public static bool Logout()
	{
		if (_party != null)
		{
			_party.Disconnect();
			_party = null;
		}
		PlayFabClientAPI.ForgetAllCredentials();
		EntityToken = string.Empty;
		EntityID = string.Empty;
		isInitialized = false;
		isLocalUserCreated = false;
		isLoggedIn = false;
		LastErrorMessage = "";
		return true;
	}

	static PlayFabClientWrapper()
	{
		Class72.smethod_20();
		EntityToken = "";
		EntityID = "";
		LastErrorMessage = "";
		isLoggedIn = false;
		isInitialized = false;
		isLocalUserCreated = false;
	}
}
