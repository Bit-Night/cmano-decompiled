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
public class RealtimeAdminControl : UserControl, IComponentConnector
{
	[CompilerGenerated]
	[AccessedThroughProperty("ThreadGrid")]
	private Grid grid_0;

	[AccessedThroughProperty("ThreadDeltaTimeLabel")]
	[CompilerGenerated]
	private Label label_0;

	[CompilerGenerated]
	[AccessedThroughProperty("TrafficWaitingForLockLabel")]
	private Label label_1;

	[CompilerGenerated]
	[AccessedThroughProperty("NetworkGrid")]
	private Grid grid_1;

	[CompilerGenerated]
	[AccessedThroughProperty("LatencyLabel")]
	private Label label_2;

	[CompilerGenerated]
	[AccessedThroughProperty("LocalTrafficWaitingForLockLabel")]
	private Label label_3;

	[CompilerGenerated]
	[AccessedThroughProperty("RequestACButton")]
	private Button button_0;

	[CompilerGenerated]
	[AccessedThroughProperty("ReleaseACButton")]
	private Button button_1;

	private bool bool_0;

	internal virtual Grid ThreadGrid
	{
		[CompilerGenerated]
		get
		{
			return grid_0;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			RoutedEventHandler val = new RoutedEventHandler(method_0);
			Grid val2 = grid_0;
			if (val2 != null)
			{
				((FrameworkElement)val2).Loaded -= val;
			}
			grid_0 = value;
			val2 = grid_0;
			if (val2 != null)
			{
				((FrameworkElement)val2).Loaded += val;
			}
		}
	}

	internal virtual Label ThreadDeltaTimeLabel
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

	internal virtual Label TrafficWaitingForLockLabel
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

	internal virtual Grid NetworkGrid
	{
		[CompilerGenerated]
		get
		{
			return grid_1;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			RoutedEventHandler val = new RoutedEventHandler(method_1);
			Grid val2 = grid_1;
			if (val2 != null)
			{
				((FrameworkElement)val2).Loaded -= val;
			}
			grid_1 = value;
			val2 = grid_1;
			if (val2 != null)
			{
				((FrameworkElement)val2).Loaded += val;
			}
		}
	}

	internal virtual Label LatencyLabel
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

	internal virtual Label LocalTrafficWaitingForLockLabel
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

	internal virtual Button RequestACButton
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

	internal virtual Button ReleaseACButton
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

	public RealtimeAdminControl()
	{
		InitializeComponent();
	}

	private void method_0(object sender, EventArgs e)
	{
	}

	private void method_1(object sender, EventArgs e)
	{
	}

	private void method_2(object sender, RoutedEventArgs e)
	{
		MyProject.Forms.MainForm.RealtimeTerminal.SendAbsoluteControlRequest();
	}

	private void method_3(object sender, RoutedEventArgs e)
	{
		string objectID = default(string);
		if (Client.CurrentSide != null)
		{
			objectID = Client.CurrentSide.ObjectID;
		}
		MyProject.Forms.MainForm.RealtimeTerminal.SendAbsoluteControlRelease(objectID);
	}

	public void StatusEvent(StatusMessage msg)
	{
		((ContentControl)TrafficWaitingForLockLabel).Content = $"{msg.TrafficWaitingForLock} messages";
		((ContentControl)ThreadDeltaTimeLabel).Content = $"{msg.ThreadDeltaTime_milliseconds} milliseconds";
		((ContentControl)LocalTrafficWaitingForLockLabel).Content = $"{Client.RealtimeTerminal.TrafficWaitingForLock} messages";
		if (Client.RealtimeTerminal.LoopbackMode)
		{
			((ContentControl)LatencyLabel).Content = "loopback";
		}
		else
		{
			((ContentControl)LatencyLabel).Content = $"{Client.RealtimeTerminal.Latency.Milliseconds} milliseconds";
		}
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!bool_0)
		{
			bool_0 = true;
			Uri uri = new Uri("/Command;component/forms/multiplayer/rtmp/mainrealtimecontrol/realtimeadmincontrol.xaml", UriKind.Relative);
			Application.LoadComponent((object)this, uri);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			ThreadGrid = (Grid)target;
			break;
		case 2:
			ThreadDeltaTimeLabel = (Label)target;
			break;
		case 3:
			TrafficWaitingForLockLabel = (Label)target;
			break;
		case 4:
			NetworkGrid = (Grid)target;
			break;
		case 5:
			LatencyLabel = (Label)target;
			break;
		case 6:
			LocalTrafficWaitingForLockLabel = (Label)target;
			break;
		case 7:
			RequestACButton = (Button)target;
			((ButtonBase)RequestACButton).Click += new RoutedEventHandler(method_2);
			break;
		case 8:
			ReleaseACButton = (Button)target;
			((ButtonBase)ReleaseACButton).Click += new RoutedEventHandler(method_3);
			break;
		default:
			bool_0 = true;
			break;
		}
	}

	static RealtimeAdminControl()
	{
		Class72.smethod_20();
	}
}
