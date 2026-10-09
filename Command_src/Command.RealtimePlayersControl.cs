using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Command.RealtimePlayersControlViewModels;
using CommandNetcode.RT;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class RealtimePlayersControl : UserControl, IComponentConnector
{
	[CompilerGenerated]
	[AccessedThroughProperty("PlayerDataGrid")]
	private DataGrid dataGrid_0;

	private bool bool_0;

	internal virtual DataGrid PlayerDataGrid
	{
		[CompilerGenerated]
		get
		{
			return dataGrid_0;
		}
		[CompilerGenerated]
		set
		{
			EventHandler<DataGridAutoGeneratingColumnEventArgs> eventHandler = method_0;
			DataGrid val = dataGrid_0;
			if (val != null)
			{
				val.AutoGeneratingColumn -= eventHandler;
			}
			dataGrid_0 = value;
			val = dataGrid_0;
			if (val != null)
			{
				val.AutoGeneratingColumn += eventHandler;
			}
		}
	}

	public RealtimePlayersControl()
	{
		InitializeComponent();
	}

	public void PeerListEvent(PeerListMessage msg)
	{
		int count = msg.Names.Count;
		PlayerList playerList = null;
		if (((FrameworkElement)PlayerDataGrid).DataContext != null)
		{
			playerList = (PlayerList)((FrameworkElement)PlayerDataGrid).DataContext;
			if (playerList != null && playerList.Players.Count != count)
			{
				playerList = null;
			}
			else
			{
				playerList.Players.Clear();
			}
		}
		if (playerList == null)
		{
			playerList = new PlayerList();
			playerList.Players = new List<Player>(count);
		}
		int num = count - 1;
		for (int i = 0; i <= num; i++)
		{
			Player player = new Player();
			player.Name = msg.Names[i];
			player.CurrentSide_Name = msg.CurrentSide_Names[i];
			player.Rights = Enum.GetName(typeof(TerminalRights), msg.TerminalRights[i]);
			player.IP = msg.IPs[i];
			player.SelectedUnit_Name = "";
			player.LastMessageType = "";
			player.LockedSide = player.CurrentSide_Name;
			player.CPU = "";
			playerList.Players.Add(player);
		}
		((FrameworkElement)PlayerDataGrid).DataContext = null;
		((FrameworkElement)PlayerDataGrid).DataContext = playerList;
	}

	private void method_0(object sender, DataGridAutoGeneratingColumnEventArgs e)
	{
		string text = e.Column.Header.ToString();
		if (Operators.CompareString(text, "Name", true) != 0 && Operators.CompareString(text, "Rights", true) != 0 && Operators.CompareString(text, "IP", true) != 0)
		{
			if (Operators.CompareString(text, "CurrentSide_Name", true) == 0)
			{
				e.Column.Header = "Side";
			}
			else
			{
				e.Cancel = true;
			}
		}
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!bool_0)
		{
			bool_0 = true;
			Uri uri = new Uri("/Command;component/forms/multiplayer/rtmp/mainrealtimecontrol/realtimeplayerscontrol.xaml", UriKind.Relative);
			Application.LoadComponent((object)this, uri);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		if (connectionId == 1)
		{
			PlayerDataGrid = (DataGrid)target;
		}
		else
		{
			bool_0 = true;
		}
	}

	static RealtimePlayersControl()
	{
		Class72.smethod_20();
	}
}
