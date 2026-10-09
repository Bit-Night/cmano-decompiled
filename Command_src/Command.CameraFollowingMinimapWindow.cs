using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Threading;
using Command.My;
using Command.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotObfuscate]
[DoNotPrune]
[DoNotPruneType]
[DesignerGenerated]
public sealed class CameraFollowingMinimapWindow : Window, IComponentConnector
{
	private CameraFollowingMinimapViewModel cameraFollowingMinimapViewModel_0;

	private Thread thread_0;

	private bool bool_0;

	private Thread thread_1;

	private bool bool_1;

	private bool bool_2;

	[CompilerGenerated]
	[AccessedThroughProperty("MainGrid")]
	private Grid grid_0;

	[AccessedThroughProperty("TerrainImage")]
	[CompilerGenerated]
	private Image kZdHehpsltt;

	[CompilerGenerated]
	[AccessedThroughProperty("UnitsImage")]
	private Image image_0;

	private bool bool_3;

	internal virtual Grid MainGrid
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

	internal virtual Image TerrainImage
	{
		[CompilerGenerated]
		get
		{
			return kZdHehpsltt;
		}
		[CompilerGenerated]
		set
		{
			kZdHehpsltt = value;
		}
	}

	internal virtual Image UnitsImage
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

	public CameraFollowingMinimapWindow()
	{
		bool_0 = false;
		bool_1 = false;
		bool_2 = false;
		InitializeComponent();
	}

	private void method_0(object sender, RoutedEventArgs e)
	{
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		if (bool_0 && Debugger.IsAttached)
		{
			Debugger.Break();
		}
		if (bool_1 && Debugger.IsAttached)
		{
			Debugger.Break();
		}
		cameraFollowingMinimapViewModel_0 = new CameraFollowingMinimapViewModel();
		cameraFollowingMinimapViewModel_0.Dispatcher = ((DispatcherObject)this).Dispatcher;
		cameraFollowingMinimapViewModel_0.GridControl = MainGrid;
		((FrameworkElement)this).DataContext = cameraFollowingMinimapViewModel_0;
		thread_0 = new Thread(method_1);
		thread_0.Name = "Minimap Terrain Thread";
		thread_0.Priority = ThreadPriority.Lowest;
		thread_0.Start();
		thread_1 = new Thread(method_2);
		thread_1.Name = "Minimap Unit Thread";
		thread_1.Priority = ThreadPriority.Lowest;
		thread_1.Start();
		new WindowInteropHelper((Window)(object)this).Owner = ((Control)MyProject.Forms.MainForm).Handle;
	}

	private void method_1()
	{
		bool_0 = true;
		while (!bool_2)
		{
			cameraFollowingMinimapViewModel_0.UpdateTerrain();
			Thread.Sleep(5000);
		}
		bool_0 = false;
	}

	private void method_2()
	{
		bool_1 = true;
		while (!bool_2)
		{
			cameraFollowingMinimapViewModel_0.UpdateUnits();
			Thread.Sleep(5000);
		}
		bool_1 = false;
	}

	private void method_3(object sender, EventArgs e)
	{
		bool_2 = true;
	}

	private void method_4(object sender, MouseButtonEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.ChangedButton != 0)
		{
			CameraFollowingMinimapViewModel cameraFollowingMinimapViewModel = cameraFollowingMinimapViewModel_0;
			Point position = ((MouseEventArgs)e).GetPosition((IInputElement)sender);
			int xprime = (int)Math.Round(((Point)(ref position)).X);
			position = ((MouseEventArgs)e).GetPosition((IInputElement)sender);
			cameraFollowingMinimapViewModel.PanMapToPixel(xprime, (int)Math.Round(((Point)(ref position)).Y));
		}
	}

	private void method_5(object sender, MouseButtonEventArgs e)
	{
		((UIElement)this).OnMouseLeftButtonDown(e);
		((Window)this).DragMove();
	}

	private void method_6(object sender, MouseEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.RightButton == 1)
		{
			CameraFollowingMinimapViewModel cameraFollowingMinimapViewModel = cameraFollowingMinimapViewModel_0;
			Point position = e.GetPosition((IInputElement)sender);
			int xprime = (int)Math.Round(((Point)(ref position)).X);
			position = e.GetPosition((IInputElement)sender);
			cameraFollowingMinimapViewModel.PanMapToPixel(xprime, (int)Math.Round(((Point)(ref position)).Y));
		}
	}

	private void method_7(object sender, RoutedEventArgs e)
	{
		MyProject.Forms.MainForm.CameraMinimapToolStripMenuItem_Click(this, null);
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!bool_3)
		{
			bool_3 = true;
			Uri uri = new Uri("/Command;component/forms/minimap/camerafollowingminimapwindow.xaml", UriKind.Relative);
			Application.LoadComponent((object)this, uri);
		}
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected O, but got Unknown
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			((FrameworkElement)(CameraFollowingMinimapWindow)target).Loaded += new RoutedEventHandler(method_0);
			((Window)(CameraFollowingMinimapWindow)target).Closed += method_3;
			((UIElement)(CameraFollowingMinimapWindow)target).MouseLeftButtonDown += new MouseButtonEventHandler(method_5);
			break;
		case 2:
			((ButtonBase)(Button)target).Click += new RoutedEventHandler(method_7);
			break;
		case 3:
			MainGrid = (Grid)target;
			break;
		case 4:
			TerrainImage = (Image)target;
			break;
		case 5:
			UnitsImage = (Image)target;
			((UIElement)UnitsImage).MouseDown += new MouseButtonEventHandler(method_4);
			((UIElement)UnitsImage).MouseMove += new MouseEventHandler(method_6);
			break;
		default:
			bool_3 = true;
			break;
		}
	}

	static CameraFollowingMinimapWindow()
	{
		Class72.smethod_20();
	}
}
