using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotPrune]
[DoNotPruneType]
[DesignerGenerated]
[DoNotObfuscate]
public sealed class EditCargoControl : UserControl, IComponentConnector
{
	[AccessedThroughProperty("MyDataGrid")]
	[CompilerGenerated]
	private DataGrid dataGrid_0;

	[AccessedThroughProperty("InventoryList")]
	[CompilerGenerated]
	private ListBox listBox_0;

	private bool bool_0;

	internal virtual DataGrid MyDataGrid
	{
		[CompilerGenerated]
		get
		{
			return dataGrid_0;
		}
		[CompilerGenerated]
		set
		{
			dataGrid_0 = value;
		}
	}

	internal virtual ListBox InventoryList
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

	public EditCargoControl()
	{
		InitializeComponent();
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!bool_0)
		{
			bool_0 = true;
			Uri uri = new Uri("/Command;component/forms/cargo/editcargocontrol.xaml", UriKind.Relative);
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
		switch (connectionId)
		{
		case 1:
			MyDataGrid = (DataGrid)target;
			break;
		case 2:
			InventoryList = (ListBox)target;
			break;
		default:
			bool_0 = true;
			break;
		}
	}

	static EditCargoControl()
	{
		Class72.smethod_20();
	}
}
