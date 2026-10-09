using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using Command_Core;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class OrbitAnchor : Window, IComponentConnector
{
	public Satellite SelectedSatellite;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_Longitude")]
	private TextBox textBox_0;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_Latitude")]
	private TextBox textBox_1;

	[AccessedThroughProperty("TB_Altitude")]
	[CompilerGenerated]
	private TextBox textBox_2;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_UseCurrent")]
	private Button button_0;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_OK")]
	private Button button_1;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_ApplyAnchor")]
	private CheckBox checkBox_0;

	private bool bool_0;

	internal virtual TextBox TB_Longitude
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

	internal virtual TextBox TB_Latitude
	{
		[CompilerGenerated]
		get
		{
			return textBox_1;
		}
		[CompilerGenerated]
		set
		{
			textBox_1 = value;
		}
	}

	internal virtual TextBox TB_Altitude
	{
		[CompilerGenerated]
		get
		{
			return textBox_2;
		}
		[CompilerGenerated]
		set
		{
			textBox_2 = value;
		}
	}

	internal virtual Button Button_UseCurrent
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

	internal virtual Button Button_OK
	{
		[CompilerGenerated]
		get
		{
			return button_1;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			RoutedEventHandler val = new RoutedEventHandler(method_0);
			Button val2 = button_1;
			if (val2 != null)
			{
				((ButtonBase)val2).Click -= val;
			}
			button_1 = value;
			val2 = button_1;
			if (val2 != null)
			{
				((ButtonBase)val2).Click += val;
			}
		}
	}

	internal virtual CheckBox CB_ApplyAnchor
	{
		[CompilerGenerated]
		get
		{
			return checkBox_0;
		}
		[CompilerGenerated]
		set
		{
			checkBox_0 = value;
		}
	}

	public OrbitAnchor()
	{
		((Window)this).ContentRendered += OrbitAnchor_ContentRendered;
		InitializeComponent();
	}

	private void method_0(object sender, RoutedEventArgs e)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		if (((ToggleButton)CB_ApplyAnchor).IsChecked == true)
		{
			if (!Versioned.IsNumeric((object)TB_Longitude.Text))
			{
				DarkMessageBox.ShowError("Longitude is not valid!", "Error");
				return;
			}
			if (!Math2.ValidateLongitude(Conversions.ToDouble(TB_Longitude.Text)))
			{
				DarkMessageBox.ShowError("Longitude is not valid!", "Error");
				return;
			}
			if (!Versioned.IsNumeric((object)TB_Latitude.Text))
			{
				DarkMessageBox.ShowError("Latitude is not valid!", "Error");
				return;
			}
			if (!Math2.ValidateLatitude(Conversions.ToDouble(TB_Latitude.Text)))
			{
				DarkMessageBox.ShowError("Latitude is not valid!", "Error");
				return;
			}
			if (!Versioned.IsNumeric((object)TB_Altitude.Text))
			{
				DarkMessageBox.ShowError("Altitude is not valid!", "Error");
				return;
			}
			Satellite.SatelliteOrbitAnchor satelliteOrbitAnchor = new Satellite.SatelliteOrbitAnchor();
			satelliteOrbitAnchor.Longitude = Conversions.ToDouble(TB_Longitude.Text);
			satelliteOrbitAnchor.Latitude = Conversions.ToDouble(TB_Latitude.Text);
			satelliteOrbitAnchor.Altitude = Conversions.ToSingle(TB_Altitude.Text) * 1000f;
			SelectedSatellite.OrbitAnchor = satelliteOrbitAnchor;
		}
		else
		{
			SelectedSatellite.OrbitAnchor = null;
		}
		((Window)this).Close();
	}

	private void method_1(object sender, RoutedEventArgs e)
	{
		TB_Longitude.Text = Conversions.ToString(((ActiveUnit)SelectedSatellite).get_Longitude((GlobalVariables.BooleanObject)null));
		TB_Latitude.Text = Conversions.ToString(((ActiveUnit)SelectedSatellite).get_Latitude((GlobalVariables.BooleanObject)null));
		TB_Altitude.Text = Conversions.ToString(((ActiveUnit)SelectedSatellite).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) / 1000f);
	}

	private void OrbitAnchor_ContentRendered(object sender, EventArgs e)
	{
		((Window)this).WindowStartupLocation = (WindowStartupLocation)1;
		if (SelectedSatellite.OrbitAnchor != null)
		{
			((ToggleButton)CB_ApplyAnchor).IsChecked = true;
			TB_Longitude.Text = Conversions.ToString(SelectedSatellite.OrbitAnchor.Longitude);
			TB_Latitude.Text = Conversions.ToString(SelectedSatellite.OrbitAnchor.Latitude);
			TB_Altitude.Text = Conversions.ToString(SelectedSatellite.OrbitAnchor.Altitude / 1000f);
		}
		else
		{
			((ToggleButton)CB_ApplyAnchor).IsChecked = false;
			TB_Longitude.Text = "";
			TB_Latitude.Text = "";
			TB_Altitude.Text = "";
		}
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!bool_0)
		{
			bool_0 = true;
			Uri uri = new Uri("/Command;component/forms/units/orbitanchor.xaml", UriKind.Relative);
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
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			TB_Longitude = (TextBox)target;
			break;
		case 2:
			TB_Latitude = (TextBox)target;
			break;
		case 3:
			TB_Altitude = (TextBox)target;
			break;
		case 4:
			Button_UseCurrent = (Button)target;
			((ButtonBase)Button_UseCurrent).Click += new RoutedEventHandler(method_1);
			break;
		case 5:
			Button_OK = (Button)target;
			((ButtonBase)Button_OK).Click += new RoutedEventHandler(method_0);
			break;
		case 6:
			CB_ApplyAnchor = (CheckBox)target;
			break;
		default:
			bool_0 = true;
			break;
		}
	}

	static OrbitAnchor()
	{
		Class72.smethod_20();
	}
}
