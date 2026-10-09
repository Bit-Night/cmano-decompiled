using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using Command_Core;
using Command.My;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class StartGameMenuWindow : Window, IComponentConnector
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _Closure$__
	{
		public static readonly _Closure$__ $I;

		public static Action $I4-0;

		public static Action $I5-0;

		public static Action $I6-0;

		public static VB$AnonymousDelegate_4<Image> $I7-0;

		static _Closure$__()
		{
			Class72.smethod_20();
			$I = new _Closure$__();
		}

		[SpecialName]
		internal void _Lambda$__4-0()
		{
		}

		[SpecialName]
		internal void _Lambda$__5-0()
		{
			if (!((UIElement)Client.startGameMenuWindow_0).IsVisible)
			{
				((Window)Client.startGameMenuWindow_0).WindowState = (WindowState)0;
				((Window)Client.startGameMenuWindow_0).WindowStyle = (WindowStyle)0;
				((Window)Client.startGameMenuWindow_0).Show();
			}
			((UIElement)Client.startGameMenuWindow_0).Focus();
		}

		[SpecialName]
		internal void _Lambda$__6-0()
		{
			if (((UIElement)Client.startGameMenuWindow_0).IsVisible)
			{
				((Window)Client.startGameMenuWindow_0).Hide();
			}
		}

		[SpecialName]
		internal void _Lambda$__7-0(Image myImage)
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Expected O, but got Unknown
			myImage.Source = (ImageSource)new BitmapImage(new Uri(Path.GetFullPath(Conversions.ToString(((FrameworkElement)myImage).Tag))));
		}
	}

	public static Thread StartGameWindowThread;

	public static Dispatcher StartGameWindowThreadDispatcher;

	[CompilerGenerated]
	[AccessedThroughProperty("Label_ProgramTitle")]
	private Label label_0;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_NewGame")]
	private Button button_0;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_QuickBattle")]
	private Button button_1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Campaign")]
	private Button button_2;

	[CompilerGenerated]
	[AccessedThroughProperty("Divider1")]
	private Rectangle rectangle_0;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_LoadGame")]
	private Button button_3;

	[AccessedThroughProperty("Button_ResumeGame")]
	[CompilerGenerated]
	private Button button_4;

	[AccessedThroughProperty("Divider2")]
	[CompilerGenerated]
	private Rectangle rectangle_1;

	[AccessedThroughProperty("Button_CreateScenario")]
	[CompilerGenerated]
	private Button button_5;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_LoadScenario")]
	private Button button_6;

	[CompilerGenerated]
	[AccessedThroughProperty("Divider3")]
	private Rectangle rectangle_2;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_WEGOMultiplayer")]
	private Button button_7;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_JoinRTMPMultiplayer")]
	private Button button_8;

	[CompilerGenerated]
	[AccessedThroughProperty("Divider4")]
	private Rectangle rectangle_3;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_RAMDB")]
	private Button button_9;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Exit")]
	private Button button_10;

	[CompilerGenerated]
	[AccessedThroughProperty("LeftPanel")]
	private StackPanel stackPanel_0;

	[AccessedThroughProperty("GraphicImage")]
	[CompilerGenerated]
	private Image image_0;

	[CompilerGenerated]
	[AccessedThroughProperty("Label_Loading")]
	private Label label_1;

	[AccessedThroughProperty("ClientInfoPanel")]
	[CompilerGenerated]
	private StackPanel stackPanel_1;

	[AccessedThroughProperty("ClientInfoTextBlock")]
	[CompilerGenerated]
	private TextBlock textBlock_0;

	[AccessedThroughProperty("TechSupportTextBlock")]
	[CompilerGenerated]
	private TextBlock textBlock_1;

	private bool bool_0;

	internal virtual Label Label_ProgramTitle
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

	internal virtual Button Button_NewGame
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

	internal virtual Button Button_QuickBattle
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

	internal virtual Button Button_Campaign
	{
		[CompilerGenerated]
		get
		{
			return button_2;
		}
		[CompilerGenerated]
		set
		{
			button_2 = value;
		}
	}

	internal virtual Rectangle Divider1
	{
		[CompilerGenerated]
		get
		{
			return rectangle_0;
		}
		[CompilerGenerated]
		set
		{
			rectangle_0 = value;
		}
	}

	internal virtual Button Button_LoadGame
	{
		[CompilerGenerated]
		get
		{
			return button_3;
		}
		[CompilerGenerated]
		set
		{
			button_3 = value;
		}
	}

	internal virtual Button Button_ResumeGame
	{
		[CompilerGenerated]
		get
		{
			return button_4;
		}
		[CompilerGenerated]
		set
		{
			button_4 = value;
		}
	}

	internal virtual Rectangle Divider2
	{
		[CompilerGenerated]
		get
		{
			return rectangle_1;
		}
		[CompilerGenerated]
		set
		{
			rectangle_1 = value;
		}
	}

	internal virtual Button Button_CreateScenario
	{
		[CompilerGenerated]
		get
		{
			return button_5;
		}
		[CompilerGenerated]
		set
		{
			button_5 = value;
		}
	}

	internal virtual Button Button_LoadScenario
	{
		[CompilerGenerated]
		get
		{
			return button_6;
		}
		[CompilerGenerated]
		set
		{
			button_6 = value;
		}
	}

	internal virtual Rectangle Divider3
	{
		[CompilerGenerated]
		get
		{
			return rectangle_2;
		}
		[CompilerGenerated]
		set
		{
			rectangle_2 = value;
		}
	}

	internal virtual Button Button_WEGOMultiplayer
	{
		[CompilerGenerated]
		get
		{
			return button_7;
		}
		[CompilerGenerated]
		set
		{
			button_7 = value;
		}
	}

	internal virtual Button Button_JoinRTMPMultiplayer
	{
		[CompilerGenerated]
		get
		{
			return button_8;
		}
		[CompilerGenerated]
		set
		{
			button_8 = value;
		}
	}

	internal virtual Rectangle Divider4
	{
		[CompilerGenerated]
		get
		{
			return rectangle_3;
		}
		[CompilerGenerated]
		set
		{
			rectangle_3 = value;
		}
	}

	internal virtual Button Button_RAMDB
	{
		[CompilerGenerated]
		get
		{
			return button_9;
		}
		[CompilerGenerated]
		set
		{
			button_9 = value;
		}
	}

	internal virtual Button Button_Exit
	{
		[CompilerGenerated]
		get
		{
			return button_10;
		}
		[CompilerGenerated]
		set
		{
			button_10 = value;
		}
	}

	internal virtual StackPanel LeftPanel
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

	internal virtual Image GraphicImage
	{
		[CompilerGenerated]
		get
		{
			return image_0;
		}
		[CompilerGenerated]
		set
		{
			image_0 = value;
		}
	}

	internal virtual Label Label_Loading
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

	internal virtual StackPanel ClientInfoPanel
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

	internal virtual TextBlock ClientInfoTextBlock
	{
		[CompilerGenerated]
		get
		{
			return textBlock_0;
		}
		[CompilerGenerated]
		set
		{
			textBlock_0 = value;
		}
	}

	internal virtual TextBlock TechSupportTextBlock
	{
		[CompilerGenerated]
		get
		{
			return textBlock_1;
		}
		[CompilerGenerated]
		set
		{
			textBlock_1 = value;
		}
	}

	public StartGameMenuWindow()
	{
		((Window)this).Closing += StartGameMenuWindow_Closing;
		InitializeComponent();
	}

	private static void smethod_0()
	{
		Client.startGameMenuWindow_0 = new StartGameMenuWindow();
		StartGameWindowThreadDispatcher = Dispatcher.CurrentDispatcher;
		Dispatcher.Run();
	}

	public static void UpdateStartWindow()
	{
		StartGameWindowThreadDispatcher.InvokeAsync((Action)([SpecialName] () =>
		{
		}));
	}

	public static void ShowStartWindow()
	{
		try
		{
			if (StartGameWindowThread == null)
			{
				StartGameWindowThread = new Thread(smethod_0);
				StartGameWindowThread.Name = "StartGameWindowThread";
				StartGameWindowThread.SetApartmentState(ApartmentState.STA);
				StartGameWindowThread.IsBackground = true;
				StartGameWindowThread.Start();
				while (StartGameWindowThreadDispatcher == null)
				{
					Thread.Sleep(1);
				}
			}
			if (Client.startGameMenuWindow_0 == null && Debugger.IsAttached)
			{
				Debugger.Break();
				throw new InvalidOperationException("StartGameWindowWPF failed init.");
			}
			StartGameWindowThreadDispatcher.InvokeAsync((Action)([SpecialName] () =>
			{
				if (!((UIElement)Client.startGameMenuWindow_0).IsVisible)
				{
					((Window)Client.startGameMenuWindow_0).WindowState = (WindowState)0;
					((Window)Client.startGameMenuWindow_0).WindowStyle = (WindowStyle)0;
					((Window)Client.startGameMenuWindow_0).Show();
				}
				((UIElement)Client.startGameMenuWindow_0).Focus();
			}));
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void HideStartWindow()
	{
		StartGameWindowThreadDispatcher.InvokeAsync((Action)([SpecialName] () =>
		{
			if (((UIElement)Client.startGameMenuWindow_0).IsVisible)
			{
				((Window)Client.startGameMenuWindow_0).Hide();
			}
		}));
	}

	private void method_0(object sender, RoutedEventArgs e)
	{
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Expected O, but got Unknown
		((UIElement)Client.startGameMenuWindow_0).Focus();
		((ContentControl)Label_Loading).Content = "Loading, please wait...";
		((UIElement)Button_Campaign).Visibility = (Visibility)1;
		((UIElement)Button_QuickBattle).Visibility = (Visibility)1;
		((UIElement)Button_NewGame).Visibility = (Visibility)1;
		((UIElement)Button_LoadGame).Visibility = (Visibility)1;
		((UIElement)Button_ResumeGame).Visibility = (Visibility)1;
		((UIElement)Button_CreateScenario).Visibility = (Visibility)1;
		((UIElement)Button_LoadScenario).Visibility = (Visibility)1;
		((UIElement)Button_JoinRTMPMultiplayer).Visibility = (Visibility)1;
		((UIElement)Button_RAMDB).Visibility = (Visibility)1;
		((UIElement)Button_Exit).Visibility = (Visibility)1;
		((UIElement)Divider1).Visibility = (Visibility)1;
		((UIElement)Divider2).Visibility = (Visibility)1;
		((UIElement)Divider3).Visibility = (Visibility)1;
		((UIElement)Divider4).Visibility = (Visibility)1;
		((UIElement)Button_WEGOMultiplayer).Visibility = (Visibility)2;
		((UIElement)Divider3).Visibility = (Visibility)2;
		((ContentControl)Label_ProgramTitle).Content = GameGeneral.ProgramTitle;
		if (_Closure$__.$I7-0 == null)
		{
			_Closure$__.$I7-0 = [SpecialName] (Image myImage) =>
			{
				//IL_0016: Unknown result type (might be due to invalid IL or missing references)
				//IL_0020: Expected O, but got Unknown
				myImage.Source = (ImageSource)new BitmapImage(new Uri(Path.GetFullPath(Conversions.ToString(((FrameworkElement)myImage).Tag))));
			};
		}
		GraphicImage.Source = (ImageSource)new BitmapImage(new Uri(Path.GetFullPath("Symbols\\StartMenu\\CMO_logo.jpg")));
		((FrameworkElement)this).DataContext = new StartGameMenuWindowViewModel(this);
		((Window)this).ShowInTaskbar = true;
	}

	public void ShowButtons()
	{
		StartGameWindowThreadDispatcher.InvokeAsync((Action)([SpecialName] () =>
		{
			((UIElement)Label_Loading).Visibility = (Visibility)1;
			((UIElement)Button_Campaign).Visibility = (Visibility)0;
			((UIElement)Button_Campaign).IsEnabled = !GameGeneral.PE_MPOnly;
			((UIElement)Button_QuickBattle).Visibility = (Visibility)0;
			((UIElement)Button_QuickBattle).IsEnabled = !GameGeneral.PE_MPOnly;
			((UIElement)Button_NewGame).Visibility = (Visibility)0;
			((UIElement)Button_NewGame).IsEnabled = !GameGeneral.PE_MPOnly;
			((UIElement)Button_LoadGame).Visibility = (Visibility)0;
			((UIElement)Button_LoadGame).IsEnabled = !GameGeneral.PE_MPOnly;
			((UIElement)Button_ResumeGame).Visibility = (Visibility)0;
			((UIElement)Button_ResumeGame).IsEnabled = !GameGeneral.PE_MPOnly;
			((UIElement)Button_CreateScenario).Visibility = (Visibility)0;
			((UIElement)Button_CreateScenario).IsEnabled = !GameGeneral.PE_MPOnly;
			((UIElement)Button_LoadScenario).Visibility = (Visibility)0;
			((UIElement)Button_LoadScenario).IsEnabled = !GameGeneral.PE_MPOnly;
			((UIElement)Button_Exit).Visibility = (Visibility)0;
			((UIElement)Divider1).Visibility = (Visibility)0;
			((UIElement)Divider2).Visibility = (Visibility)0;
			((UIElement)Divider4).Visibility = (Visibility)0;
			((UIElement)Button_JoinRTMPMultiplayer).Visibility = (Visibility)0;
			((UIElement)Button_WEGOMultiplayer).Visibility = (Visibility)2;
			((UIElement)Divider3).Visibility = (Visibility)2;
			if (!GameGeneral.Beta_CivRTMP)
			{
				((UIElement)Button_JoinRTMPMultiplayer).IsEnabled = false;
				((UIElement)Button_JoinRTMPMultiplayer).Visibility = (Visibility)2;
			}
			((UIElement)Button_RAMDB).Visibility = (Visibility)2;
			((ContentControl)Label_ProgramTitle).Content = GameGeneral.ProgramTitle;
			((Window)this).WindowState = (WindowState)0;
			if (SimConfiguration.DefaultGamePreferences.GameMusic)
			{
				Sound.StartMusic();
			}
			if (SimConfiguration.DefaultGamePreferences.ShowProbanner)
			{
				((Control)MyProject.Forms.CPEBannerForm).Show();
			}
		}));
	}

	private void StartGameMenuWindow_Closing(object sender, CancelEventArgs e)
	{
		e.Cancel = true;
		((Window)this).Hide();
	}

	private void method_1(object sender, DependencyPropertyChangedEventArgs e)
	{
	}

	public static void MainFormShown(IntPtr MainFormHandle)
	{
		StartGameWindowThreadDispatcher.InvokeAsync((Action)([SpecialName] () =>
		{
			//IL_0005: Unknown result type (might be due to invalid IL or missing references)
			new WindowInteropHelper((Window)(object)Client.startGameMenuWindow_0).Owner = MainFormHandle;
		}));
	}

	private void method_2(object sender, MouseButtonEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Invalid comparison between Unknown and I4
		if (((int)e.ChangedButton == 0) & ((int)e.ButtonState == 1))
		{
			((Window)this).DragMove();
		}
	}

	private void method_3(object sender, MouseButtonEventArgs e)
	{
		((Window)this).Close();
	}

	private void method_4(object sender, RoutedEventArgs e)
	{
		try
		{
			Process.Start("https://www.matrixprosims.com/member/helpdesk");
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!bool_0)
		{
			bool_0 = true;
			Uri uri = new Uri("/Command;component/forms/startgamemenu/startgamemenuwindow.xaml", UriKind.Relative);
			Application.LoadComponent((object)this, uri);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected O, but got Unknown
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected O, but got Unknown
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected O, but got Unknown
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected O, but got Unknown
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Expected O, but got Unknown
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Expected O, but got Unknown
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected O, but got Unknown
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Expected O, but got Unknown
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Expected O, but got Unknown
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Expected O, but got Unknown
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Expected O, but got Unknown
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Expected O, but got Unknown
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			((FrameworkElement)(StartGameMenuWindow)target).Loaded += new RoutedEventHandler(method_0);
			((UIElement)(StartGameMenuWindow)target).IsVisibleChanged += new DependencyPropertyChangedEventHandler(method_1);
			break;
		case 2:
			((UIElement)(Grid)target).MouseDown += new MouseButtonEventHandler(method_2);
			break;
		case 3:
			Label_ProgramTitle = (Label)target;
			break;
		case 4:
			((UIElement)(Path)target).MouseDown += new MouseButtonEventHandler(method_3);
			break;
		case 5:
			Button_NewGame = (Button)target;
			break;
		case 6:
			Button_QuickBattle = (Button)target;
			break;
		case 7:
			Button_Campaign = (Button)target;
			break;
		case 8:
			Divider1 = (Rectangle)target;
			break;
		case 9:
			Button_LoadGame = (Button)target;
			break;
		case 10:
			Button_ResumeGame = (Button)target;
			break;
		case 11:
			Divider2 = (Rectangle)target;
			break;
		case 12:
			Button_CreateScenario = (Button)target;
			break;
		case 13:
			Button_LoadScenario = (Button)target;
			break;
		case 14:
			Divider3 = (Rectangle)target;
			break;
		case 15:
			Button_WEGOMultiplayer = (Button)target;
			break;
		case 16:
			Button_JoinRTMPMultiplayer = (Button)target;
			break;
		case 17:
			Divider4 = (Rectangle)target;
			break;
		case 18:
			Button_RAMDB = (Button)target;
			break;
		case 19:
			Button_Exit = (Button)target;
			break;
		case 20:
			LeftPanel = (StackPanel)target;
			break;
		case 21:
			GraphicImage = (Image)target;
			break;
		case 22:
			Label_Loading = (Label)target;
			break;
		case 23:
			ClientInfoPanel = (StackPanel)target;
			break;
		case 24:
			ClientInfoTextBlock = (TextBlock)target;
			break;
		case 25:
			TechSupportTextBlock = (TextBlock)target;
			break;
		case 26:
			((Hyperlink)target).Click += new RoutedEventHandler(method_4);
			break;
		default:
			bool_0 = true;
			break;
		}
	}

	static StartGameMenuWindow()
	{
		Class72.smethod_20();
	}
}
