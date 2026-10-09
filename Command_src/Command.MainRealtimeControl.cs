using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using Command.My;
using CommandNetcode.RT;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Odyssey.Controls;

namespace Command;

[DesignerGenerated]
public class MainRealtimeControl : UserControl, IComponentConnector
{
	public bool TempExpandedForAC;

	public bool Expanded;

	public HostState PreviousHostState;

	[AccessedThroughProperty("UpperGrid")]
	[CompilerGenerated]
	private Grid grid_0;

	[CompilerGenerated]
	[AccessedThroughProperty("StatusLabel")]
	private Label label_0;

	[CompilerGenerated]
	[AccessedThroughProperty("ExpandButton")]
	private Button button_0;

	[CompilerGenerated]
	[AccessedThroughProperty("ErrorLabel")]
	private Label label_1;

	[AccessedThroughProperty("LowerGrid")]
	[CompilerGenerated]
	private Grid grid_1;

	[AccessedThroughProperty("RecoveryAlertPanel")]
	[CompilerGenerated]
	private StackPanel stackPanel_0;

	[CompilerGenerated]
	[AccessedThroughProperty("RecoveryAlertLabel")]
	private Label label_2;

	[CompilerGenerated]
	[AccessedThroughProperty("NoInputAlertPanel")]
	private StackPanel stackPanel_1;

	[CompilerGenerated]
	[AccessedThroughProperty("NoInputAlertLabel")]
	private Label label_3;

	[AccessedThroughProperty("AdminExpander")]
	[CompilerGenerated]
	private OdcExpander odcExpander_0;

	[CompilerGenerated]
	[AccessedThroughProperty("RealtimeAdminControl")]
	private RealtimeAdminControl realtimeAdminControl_0;

	[CompilerGenerated]
	[AccessedThroughProperty("RewindExpander")]
	private OdcExpander odcExpander_1;

	[CompilerGenerated]
	[AccessedThroughProperty("RealtimeAutosaveRewindControl")]
	private RealtimeAutosaveRewindControl realtimeAutosaveRewindControl_0;

	[CompilerGenerated]
	[AccessedThroughProperty("PlayersExpander")]
	private OdcExpander odcExpander_2;

	[AccessedThroughProperty("RealtimePlayersControl")]
	[CompilerGenerated]
	private RealtimePlayersControl realtimePlayersControl_0;

	private bool bool_0;

	internal virtual Grid UpperGrid
	{
		[CompilerGenerated]
		get
		{
			return grid_0;
		}
		[CompilerGenerated]
		set
		{
			grid_0 = value;
		}
	}

	internal virtual Label StatusLabel
	{
		[CompilerGenerated]
		get
		{
			return label_0;
		}
		[CompilerGenerated]
		set
		{
			label_0 = value;
		}
	}

	internal virtual Button ExpandButton
	{
		[CompilerGenerated]
		get
		{
			return button_0;
		}
		[CompilerGenerated]
		set
		{
			button_0 = value;
		}
	}

	internal virtual Label ErrorLabel
	{
		[CompilerGenerated]
		get
		{
			return label_1;
		}
		[CompilerGenerated]
		set
		{
			label_1 = value;
		}
	}

	internal virtual Grid LowerGrid
	{
		[CompilerGenerated]
		get
		{
			return grid_1;
		}
		[CompilerGenerated]
		set
		{
			grid_1 = value;
		}
	}

	internal virtual StackPanel RecoveryAlertPanel
	{
		[CompilerGenerated]
		get
		{
			return stackPanel_0;
		}
		[CompilerGenerated]
		set
		{
			stackPanel_0 = value;
		}
	}

	internal virtual Label RecoveryAlertLabel
	{
		[CompilerGenerated]
		get
		{
			return label_2;
		}
		[CompilerGenerated]
		set
		{
			label_2 = value;
		}
	}

	internal virtual StackPanel NoInputAlertPanel
	{
		[CompilerGenerated]
		get
		{
			return stackPanel_1;
		}
		[CompilerGenerated]
		set
		{
			stackPanel_1 = value;
		}
	}

	internal virtual Label NoInputAlertLabel
	{
		[CompilerGenerated]
		get
		{
			return label_3;
		}
		[CompilerGenerated]
		set
		{
			label_3 = value;
		}
	}

	internal virtual OdcExpander AdminExpander
	{
		[CompilerGenerated]
		get
		{
			return odcExpander_0;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			RoutedEventHandler val = new RoutedEventHandler(method_3);
			OdcExpander odcExpander = odcExpander_0;
			if (odcExpander != null)
			{
				((FrameworkElement)odcExpander).Loaded -= val;
			}
			odcExpander_0 = value;
			odcExpander = odcExpander_0;
			if (odcExpander != null)
			{
				((FrameworkElement)odcExpander).Loaded += val;
			}
		}
	}

	internal virtual RealtimeAdminControl RealtimeAdminControl
	{
		[CompilerGenerated]
		get
		{
			return realtimeAdminControl_0;
		}
		[CompilerGenerated]
		set
		{
			realtimeAdminControl_0 = value;
		}
	}

	internal virtual OdcExpander RewindExpander
	{
		[CompilerGenerated]
		get
		{
			return odcExpander_1;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			RoutedEventHandler val = new RoutedEventHandler(method_4);
			OdcExpander odcExpander = odcExpander_1;
			if (odcExpander != null)
			{
				((FrameworkElement)odcExpander).Loaded -= val;
			}
			odcExpander_1 = value;
			odcExpander = odcExpander_1;
			if (odcExpander != null)
			{
				((FrameworkElement)odcExpander).Loaded += val;
			}
		}
	}

	internal virtual RealtimeAutosaveRewindControl RealtimeAutosaveRewindControl
	{
		[CompilerGenerated]
		get
		{
			return realtimeAutosaveRewindControl_0;
		}
		[CompilerGenerated]
		set
		{
			realtimeAutosaveRewindControl_0 = value;
		}
	}

	internal virtual OdcExpander PlayersExpander
	{
		[CompilerGenerated]
		get
		{
			return odcExpander_2;
		}
		[CompilerGenerated]
		set
		{
			odcExpander_2 = value;
		}
	}

	internal virtual RealtimePlayersControl RealtimePlayersControl
	{
		[CompilerGenerated]
		get
		{
			return realtimePlayersControl_0;
		}
		[CompilerGenerated]
		set
		{
			realtimePlayersControl_0 = value;
		}
	}

	public MainRealtimeControl()
	{
		InitializeComponent();
	}

	private void method_0(object sender, RoutedEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		int speed = Conversions.ToInteger(((FrameworkElement)(Control)sender).Tag);
		MyProject.Forms.MainForm.RealtimeTerminal.SendSpeedRequest(speed);
	}

	private void method_1(object sender, RoutedEventArgs e)
	{
		MyProject.Forms.MainForm.RealtimeTerminal.SendAutosaveRequest(null);
	}

	private void method_2(object sender, RoutedEventArgs e)
	{
		string tag = Interaction.InputBox("Tag for autosave?", "", "", -1, -1);
		MyProject.Forms.MainForm.RealtimeTerminal.SendAutosaveRequest(tag);
	}

	public void StatusEvent(StatusMessage msg)
	{
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ee: Expected O, but got Unknown
		bool isEnabled = false;
		RealtimeAutosaveRewindControl.UpdateForUserLevel();
		MyProject.Forms.MainForm.GameControlBar1.Realtime_ServerSetSpeed = true;
		switch (msg.Speed)
		{
		case 15:
			((Selector)MyProject.Forms.MainForm.GameControlBar1.TimeComboBox).SelectedItem = MyProject.Forms.MainForm.GameControlBar1.TimeItem15x;
			break;
		case 1:
			((Selector)MyProject.Forms.MainForm.GameControlBar1.TimeComboBox).SelectedItem = MyProject.Forms.MainForm.GameControlBar1.TimeItem1x;
			break;
		case 2:
			((Selector)MyProject.Forms.MainForm.GameControlBar1.TimeComboBox).SelectedItem = MyProject.Forms.MainForm.GameControlBar1.TimeItem2x;
			break;
		case 5:
			((Selector)MyProject.Forms.MainForm.GameControlBar1.TimeComboBox).SelectedItem = MyProject.Forms.MainForm.GameControlBar1.TimeItem5x;
			break;
		case 60:
			((Selector)MyProject.Forms.MainForm.GameControlBar1.TimeComboBox).SelectedItem = MyProject.Forms.MainForm.GameControlBar1.TimeItemDoubleFlame;
			break;
		case 30:
			((Selector)MyProject.Forms.MainForm.GameControlBar1.TimeComboBox).SelectedItem = MyProject.Forms.MainForm.GameControlBar1.TimeItemTurbo;
			break;
		}
		MyProject.Forms.MainForm.GameControlBar1.Realtime_ServerSetSpeed = false;
		string text = "";
		if (msg.HostState == HostState.Running)
		{
			switch (msg.SpeedDecision)
			{
			case 1:
				text = " (Speed: Umpire)";
				break;
			case 2:
				text = " (Speed: Agreed)";
				break;
			case 3:
				text = " (Speed: Lowest)";
				break;
			}
		}
		((ContentControl)StatusLabel).Content = string.Format("{0} {1}{2}{3}", msg.Text, msg.HostState.ToString(), text, Interaction.IIf(msg.AC_Requester_Name == null, (object)"", (object)$" {msg.AC_Requester_Name} has absolute control"));
		((ContentControl)RealtimeAutosaveRewindControl.TimeSinceLastAutosaveLabel).Content = $"{Math.Round(msg.TimeSinceLastAutosave.TotalSeconds)} seconds";
		((ContentControl)RealtimeAutosaveRewindControl.AutosaveCountLabel).Content = $"{msg.AutosaveCount} autosaves";
		RealtimeAdminControl.StatusEvent(msg);
		switch (msg.HostState)
		{
		case HostState.Paused:
			((Panel)UpperGrid).Background = (Brush)new SolidColorBrush(Color.FromRgb((byte)58, (byte)61, (byte)64));
			((UIElement)MyProject.Forms.MainForm.GameControlBar1.PlayButton).Visibility = (Visibility)0;
			((UIElement)MyProject.Forms.MainForm.GameControlBar1.PauseButton).Visibility = (Visibility)2;
			((UIElement)RealtimeAdminControl.RequestACButton).IsEnabled = isEnabled;
			((UIElement)RealtimeAdminControl.ReleaseACButton).IsEnabled = false;
			break;
		case HostState.AC:
			((UIElement)RealtimeAdminControl.RequestACButton).IsEnabled = false;
			if (Operators.CompareString(msg.AC_Requester_Name, Client.RealtimeTerminal.ClientName, true) == 0)
			{
				((Panel)UpperGrid).Background = (Brush)(object)Brushes.Red;
				((UIElement)RealtimeAdminControl.ReleaseACButton).IsEnabled = true;
				break;
			}
			((Panel)UpperGrid).Background = (Brush)(object)Brushes.CornflowerBlue;
			((ContentControl)NoInputAlertLabel).Content = "SCENARIO IS READ ONLY";
			((UIElement)NoInputAlertPanel).Visibility = (Visibility)0;
			((UIElement)RealtimeAdminControl.ReleaseACButton).IsEnabled = false;
			break;
		case HostState.Running:
			((Panel)UpperGrid).Background = (Brush)(object)Brushes.ForestGreen;
			((UIElement)MyProject.Forms.MainForm.GameControlBar1.PlayButton).Visibility = (Visibility)2;
			((UIElement)MyProject.Forms.MainForm.GameControlBar1.PauseButton).Visibility = (Visibility)0;
			((UIElement)RealtimeAdminControl.RequestACButton).IsEnabled = isEnabled;
			((UIElement)RealtimeAdminControl.ReleaseACButton).IsEnabled = false;
			break;
		}
		if (((PreviousHostState != HostState.AC) & (msg.HostState == HostState.AC)) && !Expanded && Operators.CompareString(msg.AC_Requester_Name, Client.RealtimeTerminal.ClientName, true) != 0)
		{
			ExpandButton_OnClick(null, null);
			TempExpandedForAC = true;
		}
		if ((PreviousHostState == HostState.AC) & (msg.HostState != HostState.AC))
		{
			if (Expanded & TempExpandedForAC)
			{
				ExpandButton_OnClick(null, null);
			}
			((UIElement)NoInputAlertPanel).Visibility = (Visibility)2;
		}
		PreviousHostState = msg.HostState;
	}

	private void method_3(object sender, EventArgs e)
	{
	}

	private void method_4(object sender, EventArgs e)
	{
	}

	public void ExpandButton_OnClick(object sender, RoutedEventArgs e)
	{
		TempExpandedForAC = false;
		if (!Expanded)
		{
			((Control)MyProject.Forms.MainForm.RealtimeControlElementHost).Height = 600;
			((UIElement)LowerGrid).Visibility = (Visibility)0;
			((UIElement)LowerGrid).UpdateLayout();
			Client.RealtimeTerminal.SendHealth();
			Client.RealtimeTerminal.SendPeerListRequest();
		}
		else
		{
			((Control)MyProject.Forms.MainForm.RealtimeControlElementHost).Height = 30;
			((UIElement)LowerGrid).Visibility = (Visibility)2;
		}
		Expanded = !Expanded;
	}

	private void method_5(object sender, MouseButtonEventArgs e)
	{
		ExpandButton_OnClick(null, null);
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!bool_0)
		{
			bool_0 = true;
			Uri uri = new Uri("/Command;component/forms/multiplayer/rtmp/mainrealtimecontrol/mainrealtimecontrol.xaml", UriKind.Relative);
			Application.LoadComponent((object)this, uri);
		}
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected O, but got Unknown
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected O, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			UpperGrid = (Grid)target;
			((UIElement)UpperGrid).MouseDown += new MouseButtonEventHandler(method_5);
			break;
		case 2:
			StatusLabel = (Label)target;
			break;
		case 3:
			ExpandButton = (Button)target;
			((ButtonBase)ExpandButton).Click += new RoutedEventHandler(ExpandButton_OnClick);
			break;
		case 4:
			ErrorLabel = (Label)target;
			break;
		case 5:
			LowerGrid = (Grid)target;
			break;
		case 6:
			RecoveryAlertPanel = (StackPanel)target;
			break;
		case 7:
			RecoveryAlertLabel = (Label)target;
			break;
		case 8:
			NoInputAlertPanel = (StackPanel)target;
			break;
		case 9:
			NoInputAlertLabel = (Label)target;
			break;
		case 10:
			AdminExpander = (OdcExpander)target;
			break;
		case 11:
			RealtimeAdminControl = (RealtimeAdminControl)target;
			break;
		case 12:
			RewindExpander = (OdcExpander)target;
			break;
		case 13:
			RealtimeAutosaveRewindControl = (RealtimeAutosaveRewindControl)target;
			break;
		case 14:
			PlayersExpander = (OdcExpander)target;
			break;
		case 15:
			RealtimePlayersControl = (RealtimePlayersControl)target;
			break;
		default:
			bool_0 = true;
			break;
		}
	}

	static MainRealtimeControl()
	{
		Class72.smethod_20();
	}
}
