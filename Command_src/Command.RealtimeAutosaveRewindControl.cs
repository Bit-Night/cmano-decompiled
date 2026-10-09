using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using Command.My;
using CommandNetcode.RT;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class RealtimeAutosaveRewindControl : UserControl, IComponentConnector
{
	[CompilerGenerated]
	[AccessedThroughProperty("AutosaveCountLabel")]
	private Label label_0;

	[AccessedThroughProperty("TimeSinceLastAutosaveLabel")]
	[CompilerGenerated]
	private Label label_1;

	[AccessedThroughProperty("SaveButton")]
	[CompilerGenerated]
	private Button mxeHlfeRjTR;

	[CompilerGenerated]
	[AccessedThroughProperty("AutosaveTagTextBox")]
	private TextBox textBox_0;

	[CompilerGenerated]
	[AccessedThroughProperty("LoadButton")]
	private Button button_0;

	[AccessedThroughProperty("RefreshButton")]
	[CompilerGenerated]
	private Button button_1;

	[CompilerGenerated]
	[AccessedThroughProperty("DownloadAmountComboBox")]
	private ComboBox comboBox_0;

	[AccessedThroughProperty("HistoryListBox")]
	[CompilerGenerated]
	private ListBox listBox_0;

	private bool bool_0;

	internal virtual Label AutosaveCountLabel
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

	internal virtual Label TimeSinceLastAutosaveLabel
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

	internal virtual Button SaveButton
	{
		[CompilerGenerated]
		get
		{
			return mxeHlfeRjTR;
		}
		[CompilerGenerated]
		set
		{
			mxeHlfeRjTR = value;
		}
	}

	internal virtual TextBox AutosaveTagTextBox
	{
		[CompilerGenerated]
		get
		{
			return textBox_0;
		}
		[CompilerGenerated]
		set
		{
			textBox_0 = value;
		}
	}

	internal virtual Button LoadButton
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

	internal virtual Button RefreshButton
	{
		[CompilerGenerated]
		get
		{
			return button_1;
		}
		[CompilerGenerated]
		set
		{
			button_1 = value;
		}
	}

	internal virtual ComboBox DownloadAmountComboBox
	{
		[CompilerGenerated]
		get
		{
			return comboBox_0;
		}
		[CompilerGenerated]
		set
		{
			comboBox_0 = value;
		}
	}

	internal virtual ListBox HistoryListBox
	{
		[CompilerGenerated]
		get
		{
			return listBox_0;
		}
		[CompilerGenerated]
		set
		{
			listBox_0 = value;
		}
	}

	public RealtimeAutosaveRewindControl()
	{
		InitializeComponent();
	}

	public void UpdateForUserLevel()
	{
		if (Client.RealtimeTerminal != null)
		{
			((UIElement)SaveButton).IsEnabled = false;
			((UIElement)LoadButton).IsEnabled = false;
			((UIElement)RefreshButton).IsEnabled = false;
			((UIElement)DownloadAmountComboBox).IsEnabled = false;
			((UIElement)AutosaveTagTextBox).IsEnabled = false;
		}
	}

	private void method_0(object sender, RoutedEventArgs e)
	{
		RealtimeTerminal realtimeTerminal = MyProject.Forms.MainForm.RealtimeTerminal;
		if (realtimeTerminal != null)
		{
			TextBox autosaveTagTextBox = AutosaveTagTextBox;
			realtimeTerminal.SendAutosaveRequest((autosaveTagTextBox != null) ? autosaveTagTextBox.Text : null);
		}
	}

	private void method_1(object sender, RoutedEventArgs e)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		MyProject.Forms.MainForm.RealtimeTerminal?.SendAutosavesListRequest(Conversions.ToInteger(((FrameworkElement)(ComboBoxItem)((Selector)DownloadAmountComboBox).SelectedItem).Tag));
	}

	private void method_2(object sender, RoutedEventArgs e)
	{
		string text = Conversions.ToString(((Selector)HistoryListBox).SelectedItem);
		if (!string.IsNullOrEmpty(text))
		{
			MyProject.Forms.MainForm.RealtimeTerminal?.SendRewindRequest(text);
		}
	}

	private void method_3(object sender, SelectionChangedEventArgs e)
	{
		method_1(RuntimeHelpers.GetObjectValue(sender), null);
	}

	public void AutosavesListReplyEvent(AutosavesListReplyMessage msg)
	{
		((ItemsControl)HistoryListBox).ItemsSource = msg.AutosaveFilenames;
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!bool_0)
		{
			bool_0 = true;
			Uri uri = new Uri("/Command;component/forms/multiplayer/rtmp/mainrealtimecontrol/realtimeautosaverewindcontrol.xaml", UriKind.Relative);
			Application.LoadComponent((object)this, uri);
		}
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected O, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			AutosaveCountLabel = (Label)target;
			break;
		case 2:
			TimeSinceLastAutosaveLabel = (Label)target;
			break;
		case 3:
			SaveButton = (Button)target;
			((ButtonBase)SaveButton).Click += new RoutedEventHandler(method_0);
			break;
		case 4:
			AutosaveTagTextBox = (TextBox)target;
			break;
		case 5:
			LoadButton = (Button)target;
			((ButtonBase)LoadButton).Click += new RoutedEventHandler(method_2);
			break;
		case 6:
			RefreshButton = (Button)target;
			((ButtonBase)RefreshButton).Click += new RoutedEventHandler(method_1);
			break;
		case 7:
			DownloadAmountComboBox = (ComboBox)target;
			((Selector)DownloadAmountComboBox).SelectionChanged += new SelectionChangedEventHandler(method_3);
			break;
		case 8:
			HistoryListBox = (ListBox)target;
			break;
		default:
			bool_0 = true;
			break;
		}
	}

	static RealtimeAutosaveRewindControl()
	{
		Class72.smethod_20();
	}
}
