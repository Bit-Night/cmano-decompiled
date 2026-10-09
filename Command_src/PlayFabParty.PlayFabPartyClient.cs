using System;
using System.Runtime.CompilerServices;
using System.Threading;
using CMORTMP;
using Command_Core;
using CommandNetcode.RT.PlayFabWrapper;

namespace PlayFabParty;

public class PlayFabPartyClient : IDisposable
{
	private string string_0;

	private string string_1;

	private int int_0;

	private int int_1;

	private bool bool_0;

	private bool bool_1;

	private Thread thread_0;

	[CompilerGenerated]
	private EventHandler<ByteArrayMessageEventArgs> eventHandler_0;

	[CompilerGenerated]
	private EventHandler<uint> eventHandler_1;

	[CompilerGenerated]
	private EventHandler<uint> eventHandler_2;

	public event EventHandler<ByteArrayMessageEventArgs> MessageReceived
	{
		[CompilerGenerated]
		add
		{
			EventHandler<ByteArrayMessageEventArgs> eventHandler = eventHandler_0;
			EventHandler<ByteArrayMessageEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ByteArrayMessageEventArgs> value2 = (EventHandler<ByteArrayMessageEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<ByteArrayMessageEventArgs> eventHandler = eventHandler_0;
			EventHandler<ByteArrayMessageEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ByteArrayMessageEventArgs> value2 = (EventHandler<ByteArrayMessageEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<uint> PeerConnected
	{
		[CompilerGenerated]
		add
		{
			EventHandler<uint> eventHandler = eventHandler_1;
			EventHandler<uint> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<uint> value2 = (EventHandler<uint>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<uint> eventHandler = eventHandler_1;
			EventHandler<uint> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<uint> value2 = (EventHandler<uint>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<uint> PeerDisconnected
	{
		[CompilerGenerated]
		add
		{
			EventHandler<uint> eventHandler = eventHandler_2;
			EventHandler<uint> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<uint> value2 = (EventHandler<uint>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_2, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<uint> eventHandler = eventHandler_2;
			EventHandler<uint> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<uint> value2 = (EventHandler<uint>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_2, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public PlayFabPartyClient(string NetworkDescriptor, string InviteCode, int UserID, int RemoteUserID = 0)
	{
		string_0 = NetworkDescriptor;
		string_1 = InviteCode;
		int_0 = UserID;
		int_1 = RemoteUserID;
		bool_0 = RemoteUserID == 0;
	}

	public void Connect()
	{
		bool flag = false;
		flag = PlayFabClientWrapper.isLoggedIn || PlayFabClientWrapper.LoginWithCustomID(int_0, bool_0);
		if (flag && (flag = PlayFabClientWrapper.Connect(int_0, string_0, string_1)))
		{
			method_0();
		}
	}

	public void Disconnect()
	{
		if (PlayFabClientWrapper._party != null)
		{
			PlayFabClientWrapper._party.PeerConnected -= OnPartyPeerConnected;
			PlayFabClientWrapper._party.PeerDisconnected -= OnPartyPeerDisconnected;
			PlayFabClientWrapper._party.MessageReceived -= OnPartyMessageReceived;
		}
		method_1();
		PlayFabClientWrapper.Logout();
	}

	private void method_0()
	{
		if (PlayFabClientWrapper._party != null)
		{
			PlayFabClientWrapper._party.PeerConnected += OnPartyPeerConnected;
			PlayFabClientWrapper._party.PeerDisconnected += OnPartyPeerDisconnected;
			PlayFabClientWrapper._party.MessageReceived += OnPartyMessageReceived;
		}
		bool_1 = true;
		thread_0 = new Thread(method_2);
		thread_0.Start();
	}

	private void method_1()
	{
		if (bool_1)
		{
			bool_1 = false;
			thread_0?.Join(1000);
		}
	}

	public void OnPartyPeerConnected(object sender, int userID)
	{
		eventHandler_1?.Invoke(this, (uint)userID);
	}

	public void OnPartyPeerDisconnected(object sender, int userID)
	{
		eventHandler_2?.Invoke(this, (uint)userID);
	}

	public void OnPartyMessageReceived(object sender, CMORTMP.PlayFabParty.MessageReceivedEventArgs e)
	{
		eventHandler_0?.Invoke(this, new ByteArrayMessageEventArgs((uint)e.SenderId, e.Message));
	}

	private void method_2()
	{
		try
		{
			while (bool_1)
			{
				PlayFabClientWrapper.Process();
				Thread.Sleep(1);
			}
		}
		catch (Exception ex)
		{
			GameGeneral.WriteExceptionsToLog(ex, RegisterThisException: false);
		}
	}

	public void OnClientDisconnect(uint userID)
	{
		eventHandler_2?.Invoke(this, userID);
	}

	public void SendMessage(int targetUserId, byte[] message)
	{
		if (message == null)
		{
			throw new ArgumentNullException("message");
		}
		PlayFabClientWrapper.SendMessage(targetUserId, message, (uint)message.Length);
	}

	public void SendMessageToGroup(uint[] targetUserIds, byte[] message)
	{
		if (message != null && targetUserIds != null)
		{
			for (int i = 0; i < targetUserIds.Length; i++)
			{
				PlayFabClientWrapper.SendMessage((int)targetUserIds[i], message, (uint)message.Length);
			}
			return;
		}
		throw new ArgumentNullException("message");
	}

	public void BroadcastMessage(byte[] message)
	{
		if (message == null)
		{
			throw new ArgumentNullException("message");
		}
		PlayFabClientWrapper.SendMessage(0, message, (uint)message.Length);
	}

	public void Dispose()
	{
		method_1();
	}

	static PlayFabPartyClient()
	{
		Class72.smethod_20();
	}
}
