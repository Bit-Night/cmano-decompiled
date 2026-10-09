using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Command_Core;
using Command.My;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class MessageLogControl : UserControl, IComponentConnector, IStyleConnector
{
	[AccessedThroughProperty("ShowAllButton")]
	[CompilerGenerated]
	private Button button_0;

	[AccessedThroughProperty("ToggleRawModeButton")]
	[CompilerGenerated]
	private Button button_1;

	[CompilerGenerated]
	[AccessedThroughProperty("RawLOGsv")]
	private ScrollViewer scrollViewer_0;

	[CompilerGenerated]
	[AccessedThroughProperty("InteractiveLOGsv")]
	private ScrollViewer scrollViewer_1;

	private bool bool_0;

	public MessageLogControlViewModel VM => (MessageLogControlViewModel)((FrameworkElement)this).DataContext;

	public string DisplayModeString => VM.DisplayModeString;

	public bool RawModeVisibility
	{
		get
		{
			if (!VM.RawMode)
			{
				return true;
			}
			return false;
		}
	}

	public bool InteractiveModeVisibility
	{
		get
		{
			if (!VM.RawMode)
			{
				return false;
			}
			return true;
		}
	}

	internal virtual Button ShowAllButton
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

	internal virtual Button ToggleRawModeButton
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

	internal virtual ScrollViewer RawLOGsv
	{
		[CompilerGenerated]
		get
		{
			return scrollViewer_0;
		}
		[CompilerGenerated]
		set
		{
			scrollViewer_0 = value;
		}
	}

	internal virtual ScrollViewer InteractiveLOGsv
	{
		[CompilerGenerated]
		get
		{
			return scrollViewer_1;
		}
		[CompilerGenerated]
		set
		{
			scrollViewer_1 = value;
		}
	}

	public MessageLogControl()
	{
		InitializeComponent();
	}

	private void method_0(object sender, MouseEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		TextBlock val = (TextBlock)sender;
		if (val != null)
		{
			MLDetailViewModel mLDetailViewModel = (MLDetailViewModel)((FrameworkElement)val).Tag;
			if (VM != null && SimConfiguration.DefaultGamePreferences.MessageLogSettings[mLDetailViewModel.LoggedMessage.Type].ShowBaloon)
			{
				VM.GenerateBalloon(mLDetailViewModel);
			}
		}
	}

	private void method_1(object sender, MouseEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		object objectValue = RuntimeHelpers.GetObjectValue(((FrameworkElement)(TextBlock)sender).Tag);
		if (VM == null)
		{
			return;
		}
		GClass5[] array = VM.Balloons.ToArray();
		foreach (GClass5 gClass in array)
		{
			if (gClass.Tag == objectValue)
			{
				gClass.Hover = false;
			}
		}
	}

	private void method_2(object sender, MouseButtonEventArgs e)
	{
		_ = (MLDetailViewModel)NewLateBinding.LateGet(sender, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null);
	}

	private void method_3(object sender, MouseButtonEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			MLDetailViewModel mLDetailViewModel = (MLDetailViewModel)((FrameworkElement)(Grid)sender).DataContext;
			if (mLDetailViewModel.Lon != 0.0 || mLDetailViewModel.Lat != 0.0)
			{
				MyProject.Forms.MainForm.set_MapCenter(MustRender: true, new GeoPoint(mLDetailViewModel.Lon, mLDetailViewModel.Lat));
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void method_4(object sender, RoutedEventArgs e)
	{
		VM.RawMode = !VM.RawMode;
		((UIElement)InteractiveLOGsv).Visibility = (Visibility)(byte)(0 - (InteractiveModeVisibility ? 1 : 0));
		((UIElement)RawLOGsv).Visibility = (Visibility)(byte)(0 - (RawModeVisibility ? 1 : 0));
	}

	private void method_5(object sender, RoutedEventArgs e)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		VM.ShowAll = !VM.ShowAll;
		if (VM.ShowAll)
		{
			((Control)ShowAllButton).Background = (Brush)new SolidColorBrush(Color.FromArgb(byte.MaxValue, (byte)115, (byte)115, (byte)115));
		}
		else
		{
			((Control)ShowAllButton).Background = (Brush)new SolidColorBrush(Color.FromArgb(byte.MaxValue, (byte)63, (byte)63, (byte)63));
		}
		short num = (short)(VM.HeaderToShow.Count - 1);
		for (short num2 = 0; num2 <= num; num2++)
		{
			VM.HeaderToShow[VM.HeaderToShow.ElementAt(num2).Key] = VM.ShowAll;
		}
		VM.RefreshLoggedMessages();
	}

	private void method_6(object sender, RoutedEventArgs e)
	{
		MyProject.Forms.MainForm.ToggleMessageLogInSeparateWindow();
	}

	public BitmapImage ConvertBitmap(Bitmap bitmap)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		using MemoryStream memoryStream = RCMS.recyclableMemoryStreamManager_0.GetStream();
		((Image)bitmap).Save((Stream)memoryStream, ImageFormat.Bmp);
		BitmapImage val = new BitmapImage();
		val.BeginInit();
		memoryStream.Seek(0L, SeekOrigin.Begin);
		val.StreamSource = memoryStream;
		val.EndInit();
		return val;
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!bool_0)
		{
			bool_0 = true;
			Uri uri = new Uri("/Command;component/forms/messagelog/messagelogcontrol.xaml", UriKind.Relative);
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
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			ShowAllButton = (Button)target;
			((ButtonBase)ShowAllButton).Click += new RoutedEventHandler(method_5);
			break;
		case 2:
			ToggleRawModeButton = (Button)target;
			((ButtonBase)ToggleRawModeButton).Click += new RoutedEventHandler(method_4);
			break;
		case 3:
			((ButtonBase)(Button)target).Click += new RoutedEventHandler(method_6);
			break;
		case 4:
			RawLOGsv = (ScrollViewer)target;
			break;
		case 5:
			InteractiveLOGsv = (ScrollViewer)target;
			break;
		default:
			bool_0 = true;
			break;
		}
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void System_Windows_Markup_IStyleConnector_Connect(int connectionId, object target)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected O, but got Unknown
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
		if (connectionId == 6)
		{
			((UIElement)(Grid)target).MouseLeftButtonDown += new MouseButtonEventHandler(method_3);
		}
		if (connectionId == 7)
		{
			((UIElement)(TextBlock)target).MouseEnter += new MouseEventHandler(method_0);
			((UIElement)(TextBlock)target).MouseLeave += new MouseEventHandler(method_1);
			((UIElement)(TextBlock)target).MouseDown += new MouseButtonEventHandler(method_2);
		}
		if (connectionId == 8)
		{
			((UIElement)(TextBlock)target).MouseEnter += new MouseEventHandler(method_0);
			((UIElement)(TextBlock)target).MouseLeave += new MouseEventHandler(method_1);
			((UIElement)(TextBlock)target).MouseDown += new MouseButtonEventHandler(method_2);
		}
	}

	static MessageLogControl()
	{
		Class72.smethod_20();
	}
}
