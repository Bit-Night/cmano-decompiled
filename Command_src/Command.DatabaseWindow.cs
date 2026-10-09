using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Threading;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using Command.My;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
[DoNotObfuscate]
[DoNotPruneType]
[DoNotPrune]
public sealed class DatabaseWindow : Window, IComponentConnector
{
	private Thread thread_0;

	private static List<Thread> list_0;

	public Dispatcher ThreadDispatcher;

	private static string OwHcaqCvXI;

	private static int int_0;

	private static int int_1;

	private static string string_0;

	private static LockObject lockObject_0;

	[AccessedThroughProperty("DatabaseControl1")]
	[CompilerGenerated]
	private DatabaseControl databaseControl_0;

	private bool bool_0;

	internal virtual DatabaseControl DatabaseControl1
	{
		[CompilerGenerated]
		get
		{
			return databaseControl_0;
		}
		[CompilerGenerated]
		set
		{
			databaseControl_0 = value;
		}
	}

	static DatabaseWindow()
	{
		Class72.smethod_20();
		list_0 = new List<Thread>();
		lockObject_0 = new LockObject();
	}

	public DatabaseWindow()
	{
		InitializeComponent();
	}

	public static void OpenNewDatabaseWindow(string SelectedObjectType, int selectedObjectID, string HighlightTarget = null)
	{
		lock (lockObject_0)
		{
			OwHcaqCvXI = SelectedObjectType;
			int_0 = selectedObjectID;
			string_0 = HighlightTarget;
			int_1 = (int)((Control)MyProject.Forms.MainForm).Handle;
			Thread thread = new Thread(smethod_0);
			list_0.Add(thread);
			thread.Name = "Database Viewer Thread";
			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
		}
	}

	private static void smethod_0()
	{
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		DatabaseControlViewModel databaseControlViewModel;
		lock (lockObject_0)
		{
			databaseControlViewModel = new DatabaseControlViewModel();
			databaseControlViewModel.SelectedObjectType = OwHcaqCvXI;
			databaseControlViewModel.SelectedObjectID = int_0;
			databaseControlViewModel.HighlightTarget = string_0;
		}
		DatabaseWindow databaseWindow = new DatabaseWindow();
		new WindowInteropHelper((Window)(object)databaseWindow).Owner = (IntPtr)int_1;
		databaseWindow.thread_0 = Thread.CurrentThread;
		((FrameworkElement)databaseWindow.DatabaseControl1).DataContext = databaseControlViewModel;
		((FrameworkElement)databaseWindow).DataContext = databaseControlViewModel;
		databaseControlViewModel.DatabaseControl = databaseWindow.DatabaseControl1;
		databaseControlViewModel.Populate();
		((Window)databaseWindow).Show();
		databaseWindow.ThreadDispatcher = Dispatcher.CurrentDispatcher;
		Dispatcher.Run();
	}

	private void method_0(object sender, EventArgs e)
	{
		ThreadDispatcher.InvokeShutdown();
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!bool_0)
		{
			bool_0 = true;
			Uri uri = new Uri("/Command;component/forms/dbviewer/databasewindow.xaml", UriKind.Relative);
			Application.LoadComponent((object)this, uri);
		}
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
	{
		switch (connectionId)
		{
		case 1:
			((Window)(DatabaseWindow)target).Closed += method_0;
			break;
		case 2:
			DatabaseControl1 = (DatabaseControl)target;
			break;
		default:
			bool_0 = true;
			break;
		}
	}
}
