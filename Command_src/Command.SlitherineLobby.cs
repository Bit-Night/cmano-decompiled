using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Command.SlitherinePBEM3.Models;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

internal class SlitherineLobby
{
	public delegate void OnPlayerInfoUpdatedEventHandler(int PlayerID, string PlayerName, int PlayerStatus, string HostedScenarioName, string HostedScenarioBrief);

	public delegate void OnPlayerDisconnectedEventHandler(int PlayerID);

	public delegate void OnPlayerInfoRequestEventHandler(int RequesterID);

	public delegate void OnPlayerJoinRequestEventHandler(int JoinerID);

	public delegate void OnPlayerJoinAcceptEventHandler(int HostID, string ServerName, string InviteCode);

	public delegate void OnPlayerJoinDeclineEventHandler(int HostID);

	public delegate void OnRoutingServerErrorEventHandler(int DestinationPlayerID, int ErrorCode);

	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected struct RoutingMessageHeaderStruct
	{
		[FieldOffset(0)]
		public uint magic;

		[FieldOffset(4)]
		public byte version;

		[FieldOffset(5)]
		public byte flags;

		[FieldOffset(6)]
		public byte command;

		[FieldOffset(7)]
		public byte reserved;

		[FieldOffset(8)]
		public uint additionalDataSize;

		[FieldOffset(12)]
		public int userID;
	}

	[StructLayout(LayoutKind.Explicit, Size = 80)]
	protected struct RoutingMessageConnectStruct
	{
		[FieldOffset(0)]
		public RoutingMessageHeaderStruct header;

		[FieldOffset(16)]
		public int userID;

		[FieldOffset(20)]
		public uint reserved1;

		[FieldOffset(24)]
		public uint reserved2;

		[FieldOffset(28)]
		public uint reserved3;

		[FieldOffset(32)]
		public uint reserved4;

		[FieldOffset(36)]
		public uint reserved5;

		[FieldOffset(40)]
		public uint reserved6;

		[FieldOffset(44)]
		public uint reserved7;

		[FieldOffset(48)]
		public uint reserved8;

		[FieldOffset(52)]
		public uint reserved9;

		[FieldOffset(56)]
		public uint uint_0;

		[FieldOffset(60)]
		public uint uint_1;

		[FieldOffset(64)]
		public uint uint_2;

		[FieldOffset(68)]
		public uint uint_3;

		[FieldOffset(72)]
		public uint uint_4;

		[FieldOffset(76)]
		public uint uint_5;
	}

	[StructLayout(LayoutKind.Explicit, Size = 20)]
	protected struct RoutingMessageErrorStruct
	{
		[FieldOffset(0)]
		public RoutingMessageHeaderStruct header;

		[FieldOffset(16)]
		public int targetID;
	}

	[StructLayout(LayoutKind.Explicit, Size = 20)]
	protected struct RoutingMessagePlayerMessageStruct
	{
		[FieldOffset(0)]
		public RoutingMessageHeaderStruct header;

		[FieldOffset(16)]
		public int CustomCommand;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4, Size = 2048)]
	protected struct RoutingMessagePlayerInfoStruct
	{
		public RoutingMessageHeaderStruct header;

		public int CustomCommand;

		public int PlayerID;

		public int PlayerState;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string PlayerName;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string ScenarioName;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1956)]
		public string ScenarioBrief;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4, Size = 36)]
	protected struct RoutingMessagePlayerJoinStruct
	{
		public RoutingMessageHeaderStruct header;

		public int CustomCommand;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		public string PlayFabInvite;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 450)]
		public string PlayFabNetworkID;
	}

	public static string string_0;

	public static LoginModel UserLoginInfo;

	public static List<RoutingServerModel> RoutingServerInfo;

	public const int SCENARIO_DESC_MAX_LENGTH = 1956;

	public const int PlayFabInviteCodeMax = 128;

	public const int int_0 = 450;

	protected const int SLITHERINE_ROUTING_HEADER_SIZE = 16;

	protected const int SLITHERINE_ROUTING_MAX_PACKET_SIZE = 2048;

	protected const uint SLITHERINE_ROUTING_SEND_HEADER_MAGIC = 825709139u;

	protected const uint SLITHERINE_ROUTING_RECV_HEADER_MAGIC = 1262833747u;

	protected const byte SLITHERINE_ROUTING_FLAGS_DEFAULT = 0;

	protected const byte SLITHERINE_ROUTING_COMMAND_DATA_RECV = 0;

	protected const byte SLITHERINE_ROUTING_COMMAND_DATA_SEND = 1;

	protected const byte SLITHERINE_ROUTING_COMMAND_DATA_LOGIN = 16;

	protected const byte SLITHERINE_ROUTING_COMMAND_DATA_CONNECT_CHECK = 17;

	protected const byte SLITHERINE_ROUTING_COMMAND_DATA_ERROR = 18;

	protected const byte CMO_CUSTOM_ROUTING_COMMAND_PLAYER_INFO = 112;

	protected const byte CMO_CUSTOM_ROUTING_COMMAND_PLAYER_DISCONNECT = 113;

	protected const byte CMO_CUSTOM_ROUTING_COMMAND_REQUEST_PLAYER_INFO = 116;

	protected const byte CMO_CUSTOM_ROUTING_COMMAND_REQUEST_JOIN_GAME = 117;

	protected const byte CMO_CUSTOM_ROUTING_COMMAND_REQUEST_JOIN_ACCEPT = 118;

	protected const byte CMO_CUSTOM_ROUTING_COMMAND_REQUEST_JOIN_DECLINE = 119;

	private static byte[] _PendingMessageHeader;

	public static event OnPlayerInfoUpdatedEventHandler OnPlayerInfoUpdated;

	public static event OnPlayerDisconnectedEventHandler OnPlayerDisconnected;

	public static event OnPlayerInfoRequestEventHandler OnPlayerInfoRequest;

	public static event OnPlayerJoinRequestEventHandler OnPlayerJoinRequest;

	public static event OnPlayerJoinAcceptEventHandler OnPlayerJoinAccept;

	public static event OnPlayerJoinDeclineEventHandler OnPlayerJoinDecline;

	public static event OnRoutingServerErrorEventHandler OnRoutingServerError;

	static SlitherineLobby()
	{
		Class72.smethod_20();
		string_0 = "https://pbem32.slitherine.com";
		_PendingMessageHeader = new byte[16];
	}

	public static bool SendRoutingServerConnectMessage(int UserID, Socket socket)
	{
		RoutingMessageConnectStruct routingMessageConnectStruct = default(RoutingMessageConnectStruct);
		int num = Marshal.SizeOf(routingMessageConnectStruct);
		byte[] aArray = new byte[num - 1 + 1];
		routingMessageConnectStruct.header.magic = 825709139u;
		routingMessageConnectStruct.header.command = 16;
		routingMessageConnectStruct.header.userID = 0;
		routingMessageConnectStruct.header.additionalDataSize = (uint)(num - 16);
		routingMessageConnectStruct.userID = UserID;
		StructureToArray(routingMessageConnectStruct, ref aArray);
		return SendRoutingServerMessage(aArray, num, socket);
	}

	public static bool SendRoutingServerUserInfoMessage(int UserID, string UserName, int UserState, string HostedScenarioName, string HostedScenarioBrief, Socket socket)
	{
		RoutingMessagePlayerInfoStruct routingMessagePlayerInfoStruct = default(RoutingMessagePlayerInfoStruct);
		int num = Marshal.SizeOf(routingMessagePlayerInfoStruct);
		byte[] aArray = new byte[num - 1 + 1];
		routingMessagePlayerInfoStruct.header.magic = 825709139u;
		routingMessagePlayerInfoStruct.header.command = 1;
		routingMessagePlayerInfoStruct.header.userID = 0;
		routingMessagePlayerInfoStruct.header.additionalDataSize = (uint)(num - 16);
		routingMessagePlayerInfoStruct.CustomCommand = 112;
		routingMessagePlayerInfoStruct.PlayerID = UserID;
		routingMessagePlayerInfoStruct.PlayerName = UserName;
		routingMessagePlayerInfoStruct.PlayerState = UserState;
		routingMessagePlayerInfoStruct.ScenarioName = HostedScenarioName;
		routingMessagePlayerInfoStruct.ScenarioBrief = HostedScenarioBrief;
		StructureToArray(routingMessagePlayerInfoStruct, ref aArray);
		return SendRoutingServerMessage(aArray, num, socket);
	}

	public static bool SendRoutingServerJoinRequestMessage(int HostUserID, Socket socket)
	{
		RoutingMessagePlayerMessageStruct routingMessagePlayerMessageStruct = default(RoutingMessagePlayerMessageStruct);
		int num = Marshal.SizeOf(routingMessagePlayerMessageStruct);
		byte[] aArray = new byte[num - 1 + 1];
		routingMessagePlayerMessageStruct.header.magic = 825709139u;
		routingMessagePlayerMessageStruct.header.command = 1;
		routingMessagePlayerMessageStruct.header.userID = HostUserID;
		routingMessagePlayerMessageStruct.header.additionalDataSize = (uint)(num - 16);
		routingMessagePlayerMessageStruct.CustomCommand = 117;
		StructureToArray(routingMessagePlayerMessageStruct, ref aArray);
		return SendRoutingServerMessage(aArray, num, socket);
	}

	public static bool SendRoutingServerJoinAcceptMessage(int OpponentID, string NetworkID, string InviteCode, Socket socket)
	{
		RoutingMessagePlayerJoinStruct routingMessagePlayerJoinStruct = default(RoutingMessagePlayerJoinStruct);
		int num = Marshal.SizeOf(routingMessagePlayerJoinStruct);
		byte[] aArray = new byte[num - 1 + 1];
		routingMessagePlayerJoinStruct.header.magic = 825709139u;
		routingMessagePlayerJoinStruct.header.command = 1;
		routingMessagePlayerJoinStruct.header.userID = OpponentID;
		routingMessagePlayerJoinStruct.header.additionalDataSize = (uint)(num - 16);
		routingMessagePlayerJoinStruct.CustomCommand = 118;
		routingMessagePlayerJoinStruct.PlayFabInvite = InviteCode;
		routingMessagePlayerJoinStruct.PlayFabNetworkID = NetworkID;
		StructureToArray(routingMessagePlayerJoinStruct, ref aArray);
		return SendRoutingServerMessage(aArray, num, socket);
	}

	public static bool SendRoutingServerJoinDeclineMessage(int OpponentID, Socket socket)
	{
		RoutingMessagePlayerMessageStruct routingMessagePlayerMessageStruct = default(RoutingMessagePlayerMessageStruct);
		int num = Marshal.SizeOf(routingMessagePlayerMessageStruct);
		byte[] aArray = new byte[num - 1 + 1];
		routingMessagePlayerMessageStruct.header.magic = 825709139u;
		routingMessagePlayerMessageStruct.header.command = 1;
		routingMessagePlayerMessageStruct.header.userID = OpponentID;
		routingMessagePlayerMessageStruct.header.additionalDataSize = (uint)(num - 16);
		routingMessagePlayerMessageStruct.CustomCommand = 119;
		StructureToArray(routingMessagePlayerMessageStruct, ref aArray);
		return SendRoutingServerMessage(aArray, num, socket);
	}

	public static bool SendRoutingServerDisconnectMessage(int UserID, Socket socket)
	{
		RoutingMessagePlayerMessageStruct routingMessagePlayerMessageStruct = default(RoutingMessagePlayerMessageStruct);
		int num = Marshal.SizeOf(routingMessagePlayerMessageStruct);
		byte[] aArray = new byte[num - 1 + 1];
		routingMessagePlayerMessageStruct.header.magic = 825709139u;
		routingMessagePlayerMessageStruct.header.command = 1;
		routingMessagePlayerMessageStruct.header.userID = 0;
		routingMessagePlayerMessageStruct.header.additionalDataSize = (uint)(num - 16);
		routingMessagePlayerMessageStruct.CustomCommand = 113;
		StructureToArray(routingMessagePlayerMessageStruct, ref aArray);
		return SendRoutingServerMessage(aArray, num, socket);
	}

	public static bool SendRoutingServerUserInfoRequestMessage(int UserID, Socket socket)
	{
		RoutingMessagePlayerMessageStruct routingMessagePlayerMessageStruct = default(RoutingMessagePlayerMessageStruct);
		int num = Marshal.SizeOf(routingMessagePlayerMessageStruct);
		byte[] aArray = new byte[num - 1 + 1];
		routingMessagePlayerMessageStruct.header.magic = 825709139u;
		routingMessagePlayerMessageStruct.header.command = 1;
		routingMessagePlayerMessageStruct.header.userID = 0;
		routingMessagePlayerMessageStruct.header.additionalDataSize = (uint)(num - 16);
		routingMessagePlayerMessageStruct.CustomCommand = 116;
		StructureToArray(routingMessagePlayerMessageStruct, ref aArray);
		return SendRoutingServerMessage(aArray, num, socket);
	}

	public static Socket ConnectToRoutingServer()
	{
		try
		{
			if (RoutingServerInfo != null && RoutingServerInfo.Count >= 1)
			{
				int socketType;
				int protocolType;
				string ipString = default(string);
				int portNumber = default(int);
				if (RoutingServerInfo.Count <= 0)
				{
					socketType = 1;
					protocolType = 6;
				}
				else
				{
					ipString = RoutingServerInfo[0].string_0;
					portNumber = RoutingServerInfo[0].PortNumber;
					socketType = 1;
					protocolType = 6;
				}
				Socket socket = new Socket((SocketType)socketType, (ProtocolType)protocolType);
				if (socket != null)
				{
					socket.NoDelay = true;
					IPAddress address = IPAddress.Parse(ipString);
					socket.Connect(address, portNumber);
				}
				return socket;
			}
			return null;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		return null;
	}

	public static int GetCommandHostUserID(int hostPlayerID)
	{
		return hostPlayerID | 0x10000000;
	}

	public static bool SendRoutingServerMessage(byte[] buffer, int bufferSize, Socket socket)
	{
		int num;
		bool result;
		if (buffer.Length <= 0)
		{
			num = 0;
		}
		else
		{
			if (socket != null && socket.Connected)
			{
				try
				{
					socket.Send(buffer, bufferSize, SocketFlags.None);
					result = true;
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					result = false;
					ProjectData.ClearProjectError();
				}
				goto IL_0038;
			}
			num = 0;
		}
		result = (byte)num != 0;
		goto IL_0038;
		IL_0038:
		return result;
	}

	public static bool PollRoutingServerSocket(Socket socket)
	{
		int num;
		bool result;
		if (socket == null)
		{
			num = 0;
		}
		else
		{
			if (socket.Connected)
			{
				try
				{
					byte[] array = new byte[2048];
					int num2 = 0;
					bool flag = false;
					while (socket.Available > 0 && !flag)
					{
						if (_PendingMessageHeader[0] == 0)
						{
							num2 = socket.Receive(array, 0, 16, SocketFlags.None);
						}
						else
						{
							num2 = 16;
							_PendingMessageHeader.CopyTo(array, 0);
							_PendingMessageHeader[0] = 0;
						}
						if (num2 > 0)
						{
							RoutingMessageHeaderStruct routingMessageHeaderStruct = ArrayToStructure<RoutingMessageHeaderStruct>(array);
							if ((long)routingMessageHeaderStruct.additionalDataSize == 0L)
							{
								HandleRoutingServerMessage(array, 16);
								continue;
							}
							if (socket.Available >= routingMessageHeaderStruct.additionalDataSize)
							{
								num2 = socket.Receive(array, 16, (int)routingMessageHeaderStruct.additionalDataSize, SocketFlags.None);
								HandleRoutingServerMessage(array, (int)(16L + (long)routingMessageHeaderStruct.additionalDataSize));
								continue;
							}
							int num3 = 0;
							do
							{
								_PendingMessageHeader[num3] = array[num3];
								num3++;
							}
							while (num3 <= 15);
							flag = true;
						}
						else
						{
							flag = true;
						}
					}
					result = true;
				}
				catch (IOException projectError)
				{
					ProjectData.SetProjectError((Exception)projectError);
					result = true;
					ProjectData.ClearProjectError();
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					_PendingMessageHeader[0] = 0;
					result = false;
					ProjectData.ClearProjectError();
				}
				goto IL_0123;
			}
			num = 0;
		}
		result = (byte)num != 0;
		goto IL_0123;
		IL_0123:
		return result;
	}

	public static bool HandleRoutingServerMessage(byte[] buffer, int bufferSize)
	{
		RoutingMessageHeaderStruct routingMessageHeaderStruct;
		int result;
		if (bufferSize > 0)
		{
			routingMessageHeaderStruct = ArrayToStructure<RoutingMessageHeaderStruct>(buffer);
			if (routingMessageHeaderStruct.magic == 1262833747)
			{
				byte command = routingMessageHeaderStruct.command;
				if (command != 0)
				{
					if (command == 18)
					{
						if ((long)routingMessageHeaderStruct.additionalDataSize >= 4L)
						{
							RoutingMessageErrorStruct routingMessageErrorStruct = ArrayToStructure<RoutingMessageErrorStruct>(buffer);
							OnRoutingServerErrorEventHandler onRoutingServerErrorEvent = OnRoutingServerError;
							if (onRoutingServerErrorEvent != null)
							{
								onRoutingServerErrorEvent(routingMessageErrorStruct.targetID, routingMessageHeaderStruct.command);
								result = 1;
								goto IL_01cc;
							}
						}
						goto IL_0169;
					}
					result = 1;
				}
				else if ((long)routingMessageHeaderStruct.additionalDataSize < 4L)
				{
					result = 1;
				}
				else
				{
					switch (ArrayToStructure<RoutingMessagePlayerMessageStruct>(buffer).CustomCommand)
					{
					case 112:
						goto IL_00cb;
					case 113:
						goto IL_011f;
					case 116:
						goto IL_0143;
					case 117:
						goto IL_015e;
					case 114:
					case 115:
						goto IL_0169;
					case 118:
						goto IL_017c;
					case 119:
						goto IL_01b0;
					}
					result = 1;
				}
				goto IL_01cc;
			}
		}
		return false;
		IL_0169:
		result = 1;
		goto IL_01cc;
		IL_017c:
		RoutingMessagePlayerJoinStruct routingMessagePlayerJoinStruct = ArrayToStructure<RoutingMessagePlayerJoinStruct>(buffer);
		OnPlayerJoinAcceptEventHandler onPlayerJoinAcceptEvent = OnPlayerJoinAccept;
		if (onPlayerJoinAcceptEvent == null)
		{
			result = 1;
		}
		else
		{
			onPlayerJoinAcceptEvent(routingMessageHeaderStruct.userID, routingMessagePlayerJoinStruct.PlayFabNetworkID, routingMessagePlayerJoinStruct.PlayFabInvite);
			result = 1;
		}
		goto IL_01cc;
		IL_0143:
		OnPlayerInfoRequestEventHandler onPlayerInfoRequestEvent = OnPlayerInfoRequest;
		if (onPlayerInfoRequestEvent == null)
		{
			goto IL_0169;
		}
		onPlayerInfoRequestEvent(routingMessageHeaderStruct.userID);
		result = 1;
		goto IL_01cc;
		IL_015e:
		OnPlayerJoinRequestEventHandler onPlayerJoinRequestEvent = OnPlayerJoinRequest;
		if (onPlayerJoinRequestEvent == null)
		{
			goto IL_0169;
		}
		onPlayerJoinRequestEvent(routingMessageHeaderStruct.userID);
		result = 1;
		goto IL_01cc;
		IL_01b0:
		OnPlayerJoinDeclineEventHandler onPlayerJoinDeclineEvent = OnPlayerJoinDecline;
		if (onPlayerJoinDeclineEvent == null)
		{
			result = 1;
		}
		else
		{
			onPlayerJoinDeclineEvent(routingMessageHeaderStruct.userID);
			result = 1;
		}
		goto IL_01cc;
		IL_00cb:
		RoutingMessagePlayerInfoStruct routingMessagePlayerInfoStruct = ArrayToStructure<RoutingMessagePlayerInfoStruct>(buffer);
		int userID = routingMessagePlayerInfoStruct.header.userID;
		int playerState = routingMessagePlayerInfoStruct.PlayerState;
		string playerName = routingMessagePlayerInfoStruct.PlayerName;
		string scenarioName = routingMessagePlayerInfoStruct.ScenarioName;
		string scenarioBrief = routingMessagePlayerInfoStruct.ScenarioBrief;
		OnPlayerInfoUpdatedEventHandler onPlayerInfoUpdatedEvent = OnPlayerInfoUpdated;
		if (onPlayerInfoUpdatedEvent == null)
		{
			goto IL_0169;
		}
		onPlayerInfoUpdatedEvent(userID, playerName, playerState, scenarioName, scenarioBrief);
		result = 1;
		goto IL_01cc;
		IL_01cc:
		return (byte)result != 0;
		IL_011f:
		OnPlayerDisconnectedEventHandler onPlayerDisconnectedEvent = OnPlayerDisconnected;
		if (onPlayerDisconnectedEvent == null)
		{
			result = 1;
		}
		else
		{
			onPlayerDisconnectedEvent(routingMessageHeaderStruct.userID);
			result = 1;
		}
		goto IL_01cc;
	}

	protected static S ArrayToStructure<S>(Array aData) where S : struct
	{
		GCHandle gCHandle = default(GCHandle);
		try
		{
			gCHandle = GCHandle.Alloc(aData, GCHandleType.Pinned);
			return Marshal.PtrToStructure<S>(gCHandle.AddrOfPinnedObject());
		}
		finally
		{
			gCHandle.Free();
		}
	}

	protected static void StructureToArray<S, E>(S rStruct, ref E[] aArray) where S : struct where E : struct
	{
		GCHandle gCHandle = default(GCHandle);
		try
		{
			gCHandle = GCHandle.Alloc(aArray, GCHandleType.Pinned);
			Marshal.StructureToPtr(rStruct, gCHandle.AddrOfPinnedObject(), fDeleteOld: false);
		}
		finally
		{
			gCHandle.Free();
		}
	}

	public static RoutingServerModel GetRoutingServerInfo(string ServerName)
	{
		RoutingServerModel result = null;
		if (RoutingServerInfo != null)
		{
			IEnumerable<RoutingServerModel> source = RoutingServerInfo.Where([SpecialName] (RoutingServerModel s) => string.Compare(s.Title, ServerName) == 0);
			if (source.Count() > 0)
			{
				result = source.FirstOrDefault();
			}
		}
		return result;
	}

	public static string GetDefaultRoutingServerName(int HostID)
	{
		string result = "";
		if (RoutingServerInfo != null)
		{
			List<RoutingServerModel> list = RoutingServerInfo.Where([SpecialName] (RoutingServerModel rsInfo) => rsInfo.Active).ToList();
			if (list.Count == 1)
			{
				result = list[0].Title;
			}
			else
			{
				if (string.Compare(list[0].Title, "lobby", ignoreCase: true) == 0)
				{
					list.RemoveAt(0);
				}
				int index = HostID % list.Count;
				result = list[index].Title;
			}
		}
		return result;
	}
}
