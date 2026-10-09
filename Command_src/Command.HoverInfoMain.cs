using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using Command.My;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotPruneType]
[DoNotObfuscate]
[DoNotPrune]
[DesignerGenerated]
public sealed class HoverInfoMain : UserControl, INotifyPropertyChanged, IComponentConnector
{
	[CompilerGenerated]
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	private HoverInfoViewModel hoverInfoViewModel_0;

	[AccessedThroughProperty("MyContentControl")]
	[CompilerGenerated]
	private ContentControl contentControl_0;

	private bool bool_0;

	public HoverInfoViewModel VM
	{
		get
		{
			return (HoverInfoViewModel)((FrameworkElement)this).DataContext;
		}
		set
		{
			SetProperty(ref hoverInfoViewModel_0, value, "VM");
		}
	}

	internal virtual ContentControl MyContentControl
	{
		[CompilerGenerated]
		get
		{
			return contentControl_0;
		}
		[CompilerGenerated]
		set
		{
			contentControl_0 = value;
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		[CompilerGenerated]
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = propertyChangedEventHandler_0;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref propertyChangedEventHandler_0, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = propertyChangedEventHandler_0;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref propertyChangedEventHandler_0, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public HoverInfoMain()
	{
		InitializeComponent();
	}

	protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		propertyChangedEventHandler_0?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
	{
		if (EqualityComparer<T>.Default.Equals(field, value))
		{
			return false;
		}
		field = value;
		OnPropertyChanged(propertyName);
		return true;
	}

	public void Update(Module_Unit.Unit unit)
	{
		HoverInfoViewModel hoverInfoViewModel = new HoverInfoViewModel(MyContentControl, MyProject.Forms.MainForm.HoverInfoElementHost);
		hoverInfoViewModel.Update(Client.MouseHoveredUnit);
		VM = hoverInfoViewModel;
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!bool_0)
		{
			bool_0 = true;
			Uri uri = new Uri("/Command;component/forms/hoverinfo/hoverinfomain.xaml", UriKind.Relative);
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
			MyContentControl = (ContentControl)target;
		}
		else
		{
			bool_0 = true;
		}
	}

	static HoverInfoMain()
	{
		Class72.smethod_20();
	}
}
