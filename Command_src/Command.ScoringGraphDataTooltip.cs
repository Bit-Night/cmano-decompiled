using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Command_Core.SmartAssembly.Attributes;
using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotObfuscate]
[DoNotPrune]
[DesignerGenerated]
[DoNotPruneType]
public sealed class ScoringGraphDataTooltip : UserControl, IChartTooltip, IComponentConnector
{
	private TooltipData tooltipData_0;

	[CompilerGenerated]
	private TooltipSelectionMode? nullable_0;

	[CompilerGenerated]
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_1")]
	private TextBlock textBlock_0;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_2")]
	private TextBlock textBlock_1;

	[AccessedThroughProperty("TB_3")]
	[CompilerGenerated]
	private TextBlock textBlock_2;

	private bool bool_0;

	public TooltipData Data
	{
		get
		{
			return tooltipData_0;
		}
		set
		{
			tooltipData_0 = value;
			method_0("Data");
			ScoringDatapointViewModel scoringDatapointViewModel = (ScoringDatapointViewModel)tooltipData_0.Points.First().ChartPoint.Instance;
			TB_2.Text = scoringDatapointViewModel.Reason;
			TB_1.Text = "Score: " + scoringDatapointViewModel.ScoreValue;
			TB_3.Text = scoringDatapointViewModel.DateTime.ToString();
		}
	}

	public TooltipSelectionMode? SelectionMode
	{
		[CompilerGenerated]
		get
		{
			return nullable_0;
		}
		[CompilerGenerated]
		set
		{
			nullable_0 = value;
		}
	}

	internal virtual TextBlock TB_1
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

	internal virtual TextBlock TB_2
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

	internal virtual TextBlock TB_3
	{
		[CompilerGenerated]
		get
		{
			return textBlock_2;
		}
		[CompilerGenerated]
		set
		{
			textBlock_2 = value;
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

	public ScoringGraphDataTooltip()
	{
		InitializeComponent();
	}

	private void method_0(string string_0)
	{
		propertyChangedEventHandler_0?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!bool_0)
		{
			bool_0 = true;
			Uri uri = new Uri("/Command;component/forms/scenario/scoringgraphdatatooltip.xaml", UriKind.Relative);
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
		switch (connectionId)
		{
		case 1:
			TB_1 = (TextBlock)target;
			break;
		case 2:
			TB_2 = (TextBlock)target;
			break;
		case 3:
			TB_3 = (TextBlock)target;
			break;
		default:
			bool_0 = true;
			break;
		}
	}

	static ScoringGraphDataTooltip()
	{
		Class72.smethod_20();
	}
}
