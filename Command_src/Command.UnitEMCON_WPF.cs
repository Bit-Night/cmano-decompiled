using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Markup;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using Command.My;
using CommandNetcode.RT;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotPruneType]
[DoNotPrune]
[DesignerGenerated]
[DoNotObfuscate]
public sealed class UnitEMCON_WPF : UserControl, INotifyPropertyChanged, IComponentConnector
{
	[CompilerGenerated]
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	[CompilerGenerated]
	[AccessedThroughProperty("btnRadarActive")]
	private ToggleButton toggleButton_0;

	[CompilerGenerated]
	[AccessedThroughProperty("btnRadarPassive")]
	private ToggleButton toggleButton_1;

	[AccessedThroughProperty("btnSonarActive")]
	[CompilerGenerated]
	private ToggleButton toggleButton_2;

	[AccessedThroughProperty("btnSonarPassive")]
	[CompilerGenerated]
	private ToggleButton toggleButton_3;

	[CompilerGenerated]
	[AccessedThroughProperty("btnOECMActive")]
	private ToggleButton toggleButton_4;

	[AccessedThroughProperty("btnOECMPassive")]
	[CompilerGenerated]
	private ToggleButton toggleButton_5;

	private bool bool_0;

	internal virtual ToggleButton btnRadarActive
	{
		[CompilerGenerated]
		get
		{
			return toggleButton_0;
		}
		[CompilerGenerated]
		set
		{
			toggleButton_0 = value;
		}
	}

	internal virtual ToggleButton btnRadarPassive
	{
		[CompilerGenerated]
		get
		{
			return toggleButton_1;
		}
		[CompilerGenerated]
		set
		{
			toggleButton_1 = value;
		}
	}

	internal virtual ToggleButton btnSonarActive
	{
		[CompilerGenerated]
		get
		{
			return toggleButton_2;
		}
		[CompilerGenerated]
		set
		{
			toggleButton_2 = value;
		}
	}

	internal virtual ToggleButton btnSonarPassive
	{
		[CompilerGenerated]
		get
		{
			return toggleButton_3;
		}
		[CompilerGenerated]
		set
		{
			toggleButton_3 = value;
		}
	}

	internal virtual ToggleButton btnOECMActive
	{
		[CompilerGenerated]
		get
		{
			return toggleButton_4;
		}
		[CompilerGenerated]
		set
		{
			toggleButton_4 = value;
		}
	}

	internal virtual ToggleButton btnOECMPassive
	{
		[CompilerGenerated]
		get
		{
			return toggleButton_5;
		}
		[CompilerGenerated]
		set
		{
			toggleButton_5 = value;
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

	public UnitEMCON_WPF()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += new RoutedEventHandler(UnitEMCON_WPF_Loaded);
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

	private void UnitEMCON_WPF_Loaded(object sender, RoutedEventArgs e)
	{
		Doctrine.EmconChanged += method_0;
	}

	private void method_0(ScenarioObject scenarioObject_0, bool? nullable_0, bool bool_1, bool bool_2, bool bool_3, bool bool_4)
	{
		if (!bool_3 && Client.SelectedUnit != null && Client.SelectedUnit.IsActiveUnit)
		{
			Refresh((ActiveUnit)Client.SelectedUnit);
		}
	}

	public void Refresh(ActiveUnit theUnit)
	{
		if (theUnit != null)
		{
			((UIElement)this).IsEnabled = true;
			if (!theUnit.CommStuff.IsConnectedToSideNetwork && !Module1.IsSelectedForIsolatedPOV(theUnit) && !Client.CurrentMapProfile.GodsEye && Client.CurrentSide.AwarenessLevel != Side.AwarenessLevel_Enum.Omniscient)
			{
				((UIElement)this).Visibility = (Visibility)2;
				return;
			}
			((UIElement)this).Visibility = (Visibility)0;
			if (((FrameworkElement)this).DataContext != null)
			{
				GClass3 gClass = (GClass3)((FrameworkElement)this).DataContext;
				if (gClass.theUnit == theUnit)
				{
					gClass.Refresh();
					return;
				}
				gClass.theUnit = theUnit;
				gClass.Refresh();
			}
			else
			{
				((FrameworkElement)this).DataContext = new GClass3(theUnit);
			}
		}
		else
		{
			((FrameworkElement)this).DataContext = null;
			((UIElement)this).IsEnabled = false;
		}
	}

	private void method_1(object sender, RoutedEventArgs e)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		if (Client.SelectedUnit == null || !Client.SelectedUnit.IsActiveUnit)
		{
			return;
		}
		ActiveUnit activeUnit = (ActiveUnit)Client.SelectedUnit;
		activeUnit.Doctrine.EMCON_Inherits = ((ToggleButton)(CheckBox)sender).IsChecked.Value;
		if (Client.Realtime)
		{
			if (!activeUnit.Doctrine.EMCON_Inherits)
			{
				Client.RealtimeTerminal.SendSensorEMCONUpdate(Client.SelectedUnit, activeUnit.Sensory.ObeysEMCON, SensorEMCONUpdateMessage.EMCON_Inherit_Change.INHERIT_NO);
			}
			else
			{
				Client.RealtimeTerminal.SendSensorEMCONUpdate(Client.SelectedUnit, activeUnit.Sensory.ObeysEMCON, SensorEMCONUpdateMessage.EMCON_Inherit_Change.INHERIT_YES);
			}
		}
		Refresh((ActiveUnit)Client.SelectedUnit);
	}

	private void method_2(object sender, RoutedEventArgs e)
	{
		if (Client.SelectedUnit == null)
		{
			return;
		}
		Sensor[] sensors_Cached = ((ActiveUnit)Client.SelectedUnit).Sensors_Cached;
		foreach (Sensor sensor in sensors_Cached)
		{
			if (sensor.Type == Sensor.Sensor_Type.Radar && !sensor.IsPureIlluminator && (!sensor.IsActive() & sensor.CanBeActive))
			{
				sensor.GoActive();
				if (Client.Realtime)
				{
					Client.RealtimeTerminal.SendSensorActivation(sensor.ParentPlatform, sensor, activate: true);
				}
			}
		}
		Client.MustRefreshMainForm = true;
		((Control)MyProject.Forms.MainForm.WorldWindow1).Focus();
	}

	private void method_3(object sender, RoutedEventArgs e)
	{
		if (Client.SelectedUnit == null)
		{
			return;
		}
		Sensor[] sensors_Cached = ((ActiveUnit)Client.SelectedUnit).Sensors_Cached;
		foreach (Sensor sensor in sensors_Cached)
		{
			if (sensor.Type == Sensor.Sensor_Type.Radar && !sensor.IsPureIlluminator && sensor.IsActive())
			{
				sensor.GoPassive();
				if (Client.Realtime)
				{
					Client.RealtimeTerminal.SendSensorActivation(sensor.ParentPlatform, sensor, activate: false);
				}
			}
		}
		Client.MustRefreshMainForm = true;
		((Control)MyProject.Forms.MainForm.WorldWindow1).Focus();
	}

	private void method_4(object sender, RoutedEventArgs e)
	{
		if (Client.SelectedUnit == null)
		{
			return;
		}
		Sensor[] sensors_Cached = ((ActiveUnit)Client.SelectedUnit).Sensors_Cached;
		foreach (Sensor sensor in sensors_Cached)
		{
			if (sensor.IsSonar && !sensor.IsPureIlluminator && (!sensor.IsActive() & sensor.CanBeActive))
			{
				sensor.GoActive();
				if (Client.Realtime)
				{
					Client.RealtimeTerminal.SendSensorActivation(sensor.ParentPlatform, sensor, activate: true);
				}
			}
		}
		Client.MustRefreshMainForm = true;
		((Control)MyProject.Forms.MainForm.WorldWindow1).Focus();
	}

	private void method_5(object sender, RoutedEventArgs e)
	{
		if (Client.SelectedUnit == null)
		{
			return;
		}
		Sensor[] sensors_Cached = ((ActiveUnit)Client.SelectedUnit).Sensors_Cached;
		foreach (Sensor sensor in sensors_Cached)
		{
			if (sensor.IsSonar && !sensor.IsPureIlluminator && sensor.IsActive())
			{
				sensor.GoPassive();
				if (Client.Realtime)
				{
					Client.RealtimeTerminal.SendSensorActivation(sensor.ParentPlatform, sensor, activate: false);
				}
			}
		}
		Client.MustRefreshMainForm = true;
		((Control)MyProject.Forms.MainForm.WorldWindow1).Focus();
	}

	private void method_6(object sender, RoutedEventArgs e)
	{
		if (Client.SelectedUnit == null)
		{
			return;
		}
		Sensor[] sensors_Cached = ((ActiveUnit)Client.SelectedUnit).Sensors_Cached;
		foreach (Sensor sensor in sensors_Cached)
		{
			if (sensor.IsOECM && !sensor.IsPureIlluminator && (!sensor.IsActive() & sensor.CanBeActive))
			{
				sensor.GoActive();
				if (Client.Realtime)
				{
					Client.RealtimeTerminal.SendSensorActivation(sensor.ParentPlatform, sensor, activate: true);
				}
			}
		}
		Client.MustRefreshMainForm = true;
		((Control)MyProject.Forms.MainForm.WorldWindow1).Focus();
	}

	private void method_7(object sender, RoutedEventArgs e)
	{
		if (Client.SelectedUnit == null)
		{
			return;
		}
		Sensor[] sensors_Cached = ((ActiveUnit)Client.SelectedUnit).Sensors_Cached;
		foreach (Sensor sensor in sensors_Cached)
		{
			if (sensor.IsOECM && !sensor.IsPureIlluminator && sensor.IsActive())
			{
				sensor.GoPassive();
				if (Client.Realtime)
				{
					Client.RealtimeTerminal.SendSensorActivation(sensor.ParentPlatform, sensor, activate: false);
				}
			}
		}
		Client.MustRefreshMainForm = true;
		((Control)MyProject.Forms.MainForm.WorldWindow1).Focus();
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!bool_0)
		{
			bool_0 = true;
			Uri uri = new Uri("/Command;component/customcontrols/rightcolumn/unitemcon_wpf.xaml", UriKind.Relative);
			Application.LoadComponent((object)this, uri);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected O, but got Unknown
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Expected O, but got Unknown
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			((ButtonBase)(CheckBox)target).Click += new RoutedEventHandler(method_1);
			break;
		case 2:
			btnRadarActive = (ToggleButton)target;
			((ButtonBase)btnRadarActive).Click += new RoutedEventHandler(method_2);
			break;
		case 3:
			btnRadarPassive = (ToggleButton)target;
			((ButtonBase)btnRadarPassive).Click += new RoutedEventHandler(method_3);
			break;
		case 4:
			btnSonarActive = (ToggleButton)target;
			((ButtonBase)btnSonarActive).Click += new RoutedEventHandler(method_4);
			break;
		case 5:
			btnSonarPassive = (ToggleButton)target;
			((ButtonBase)btnSonarPassive).Click += new RoutedEventHandler(method_5);
			break;
		case 6:
			btnOECMActive = (ToggleButton)target;
			((ButtonBase)btnOECMActive).Click += new RoutedEventHandler(method_6);
			break;
		case 7:
			btnOECMPassive = (ToggleButton)target;
			((ButtonBase)btnOECMPassive).Click += new RoutedEventHandler(method_7);
			break;
		default:
			bool_0 = true;
			break;
		}
	}

	static UnitEMCON_WPF()
	{
		Class72.smethod_20();
	}
}
