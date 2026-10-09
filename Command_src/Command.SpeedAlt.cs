using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using Command.My.Resources;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.PowerPacks;

namespace Command;

[DesignerGenerated]
public sealed class SpeedAlt : DarkSecondaryFormBase
{
	protected enum SpeedAltMode
	{
		None,
		Waypoint,
		FlightplanWaypoint,
		ActiveUnit
	}

	private IContainer icontainer_1;

	[AccessedThroughProperty("TrackBar_Throttle")]
	[CompilerGenerated]
	private TrackBar _TrackBar_Throttle;

	[CompilerGenerated]
	[AccessedThroughProperty("Timer1")]
	private Timer timer_0;

	[CompilerGenerated]
	[AccessedThroughProperty("TrackBar_Altitude")]
	private TrackBar _TrackBar_Altitude;

	[AccessedThroughProperty("CB_AltOverride")]
	[CompilerGenerated]
	private DarkCheckBox _CB_AltOverride;

	[AccessedThroughProperty("CB_SpeedOverride")]
	[CompilerGenerated]
	private DarkCheckBox _CB_SpeedOverride;

	[CompilerGenerated]
	[AccessedThroughProperty("RB_MaxDepth")]
	private DarkRadioButton _RB_MaxDepth;

	[CompilerGenerated]
	[AccessedThroughProperty("RB_UnderLayer")]
	private DarkRadioButton _RB_UnderLayer;

	[AccessedThroughProperty("RB_OverLayer")]
	[CompilerGenerated]
	private DarkRadioButton _RB_OverLayer;

	[CompilerGenerated]
	[AccessedThroughProperty("RB_Periscope")]
	private DarkRadioButton _RB_Periscope;

	[AccessedThroughProperty("RB_Shallow")]
	[CompilerGenerated]
	private DarkRadioButton _RB_Shallow;

	[CompilerGenerated]
	[AccessedThroughProperty("RB_MediumAltitude12000")]
	private DarkRadioButton _RB_MediumAltitude12000;

	[CompilerGenerated]
	[AccessedThroughProperty("RB_LowAltitude2000")]
	private DarkRadioButton _RB_LowAltitude2000;

	[CompilerGenerated]
	[AccessedThroughProperty("RB_MinAltitude")]
	private DarkRadioButton _RB_MinAltitude;

	[AccessedThroughProperty("RB_LowAltitude1000")]
	[CompilerGenerated]
	private DarkRadioButton _RB_LowAltitude1000;

	[AccessedThroughProperty("RB_HighAltitude25000")]
	[CompilerGenerated]
	private DarkRadioButton _RB_HighAltitude25000;

	[CompilerGenerated]
	[AccessedThroughProperty("RB_HighAltitude36000")]
	private DarkRadioButton _RB_HighAltitude36000;

	[AccessedThroughProperty("RB_MaxAltitude")]
	[CompilerGenerated]
	private DarkRadioButton _RB_MaxAltitude;

	[CompilerGenerated]
	[AccessedThroughProperty("RB_Surface")]
	private DarkRadioButton _RB_Surface;

	[AccessedThroughProperty("TextBox_EnterSpeed")]
	[CompilerGenerated]
	private DarkUITextBox _TextBox_EnterSpeed;

	[CompilerGenerated]
	[AccessedThroughProperty("TextBox_EnterAltitude")]
	private DarkUITextBox _TextBox_EnterAltitude;

	[CompilerGenerated]
	[AccessedThroughProperty("RB_Full")]
	private DarkRadioButton _RB_Full;

	[AccessedThroughProperty("RB_Cruise")]
	[CompilerGenerated]
	private DarkRadioButton _RB_Cruise;

	[CompilerGenerated]
	[AccessedThroughProperty("RB_Creep")]
	private DarkRadioButton _RB_Creep;

	[CompilerGenerated]
	[AccessedThroughProperty("RB_Stop")]
	private DarkRadioButton _RB_Stop;

	[CompilerGenerated]
	[AccessedThroughProperty("RB_Flank")]
	private DarkRadioButton _RB_Flank;

	[AccessedThroughProperty("TextBox_WaypointDescription")]
	[CompilerGenerated]
	private DarkUITextBox _TextBox_WaypointDescription;

	[AccessedThroughProperty("CB_WaypointType")]
	[CompilerGenerated]
	private DarkUIComboBox _CB_WaypointType;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_TerrainFollowing")]
	private DarkCheckBox _CB_TerrainFollowing;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_UseLandCoverMasking")]
	private DarkCheckBox _CB_UseLandCoverMasking;

	[AccessedThroughProperty("RB_NoThrottlePreset")]
	[CompilerGenerated]
	private DarkRadioButton _RB_NoThrottlePreset;

	[CompilerGenerated]
	[AccessedThroughProperty("RB_NoAltitudePreset")]
	private DarkRadioButton _RB_NoAltitudePreset;

	[CompilerGenerated]
	[AccessedThroughProperty("RB_NoDepthPreset")]
	private DarkRadioButton _RB_NoDepthPreset;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_SprintDrift")]
	private DarkCheckBox _CB_SprintDrift;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_AvoidCavitation")]
	private DarkCheckBox _CB_AvoidCavitation;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Previous")]
	private DarkButton _Button_Previous;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Next")]
	private DarkButton _Button_Next;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_EventAction")]
	private DarkUIComboBox _CB_EventAction;

	[CompilerGenerated]
	private bool bool_2;

	public ActiveUnit SpeedAlt_SelectedUnit;

	public Waypoint SpeedAlt_FlightPlanWaypoint;

	public Mission.Flight SpeedAlt_Flight;

	public Mission SpeedAlt_Mission;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private Keys[] keys_0;

	private Keys[] keys_1;

	private Keys[] keys_2;

	private bool bool_7;

	private bool bool_8;

	private bool bool_9;

	internal virtual TrackBar TrackBar_Throttle
	{
		[CompilerGenerated]
		get
		{
			return _TrackBar_Throttle;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_15;
			TrackBar val = _TrackBar_Throttle;
			if (val != null)
			{
				val.Scroll -= eventHandler;
			}
			_TrackBar_Throttle = value;
			val = _TrackBar_Throttle;
			if (val != null)
			{
				val.Scroll += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label_MinSpeed")]
	internal virtual DarkLabel Label_MinSpeed { get; set; }

	[field: AccessedThroughProperty("Label_MaxSpeed")]
	internal virtual DarkLabel Label_MaxSpeed { get; set; }

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

	[field: AccessedThroughProperty("Label_DesiredSpeed")]
	internal virtual DarkLabel Label_DesiredSpeed { get; set; }

	[field: AccessedThroughProperty("Label3")]
	internal virtual DarkLabel Label3 { get; set; }

	[field: AccessedThroughProperty("Label_ActualSpeed")]
	internal virtual DarkLabel Label_ActualSpeed { get; set; }

	internal virtual Timer Timer1
	{
		[CompilerGenerated]
		get
		{
			return timer_0;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_7;
			Timer val = timer_0;
			if (val != null)
			{
				val.Tick -= eventHandler;
			}
			timer_0 = value;
			val = timer_0;
			if (val != null)
			{
				val.Tick += eventHandler;
			}
		}
	}

	internal virtual TrackBar TrackBar_Altitude
	{
		[CompilerGenerated]
		get
		{
			return _TrackBar_Altitude;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_16;
			TrackBar val = _TrackBar_Altitude;
			if (val != null)
			{
				val.Scroll -= eventHandler;
			}
			_TrackBar_Altitude = value;
			val = _TrackBar_Altitude;
			if (val != null)
			{
				val.Scroll += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label5")]
	internal virtual DarkLabel Label5 { get; set; }

	[field: AccessedThroughProperty("Label6")]
	internal virtual DarkLabel Label6 { get; set; }

	[field: AccessedThroughProperty("Label_MaxAlt")]
	internal virtual DarkLabel Label_MaxAlt { get; set; }

	[field: AccessedThroughProperty("Label_MinAlt")]
	internal virtual DarkLabel Label_MinAlt { get; set; }

	[field: AccessedThroughProperty("Label_DesiredAlt")]
	internal virtual DarkLabel Label_DesiredAlt { get; set; }

	[field: AccessedThroughProperty("Label_CurrentAlt")]
	internal virtual DarkLabel Label_CurrentAlt { get; set; }

	[field: AccessedThroughProperty("GroupBox_Speed")]
	internal virtual DarkGroupBox GroupBox_Speed { get; set; }

	[field: AccessedThroughProperty("GroupBox_Altitude")]
	internal virtual DarkGroupBox GroupBox_Altitude { get; set; }

	[field: AccessedThroughProperty("GroupBox_SpeedPresets")]
	internal virtual DarkGroupBox GroupBox_SpeedPresets { get; set; }

	internal virtual DarkCheckBox CB_AltOverride
	{
		[CompilerGenerated]
		get
		{
			return _CB_AltOverride;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = CB_AltOverride_Click;
			DarkCheckBox darkCheckBox = _CB_AltOverride;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_AltOverride = value;
			darkCheckBox = _CB_AltOverride;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_SpeedOverride
	{
		[CompilerGenerated]
		get
		{
			return _CB_SpeedOverride;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = CB_SpeedOverride_Click;
			DarkCheckBox darkCheckBox = _CB_SpeedOverride;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_SpeedOverride = value;
			darkCheckBox = _CB_SpeedOverride;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("GroupBox_SubDepthPreset")]
	internal virtual DarkGroupBox GroupBox_SubDepthPreset { get; set; }

	internal virtual DarkRadioButton RB_MaxDepth
	{
		[CompilerGenerated]
		get
		{
			return _RB_MaxDepth;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_24;
			DarkRadioButton darkRadioButton = _RB_MaxDepth;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged -= eventHandler;
			}
			_RB_MaxDepth = value;
			darkRadioButton = _RB_MaxDepth;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkRadioButton RB_UnderLayer
	{
		[CompilerGenerated]
		get
		{
			return _RB_UnderLayer;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = HofLeFobUhR;
			DarkRadioButton darkRadioButton = _RB_UnderLayer;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged -= eventHandler;
			}
			_RB_UnderLayer = value;
			darkRadioButton = _RB_UnderLayer;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkRadioButton RB_OverLayer
	{
		[CompilerGenerated]
		get
		{
			return _RB_OverLayer;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_23;
			DarkRadioButton darkRadioButton = _RB_OverLayer;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged -= eventHandler;
			}
			_RB_OverLayer = value;
			darkRadioButton = _RB_OverLayer;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkRadioButton RB_Periscope
	{
		[CompilerGenerated]
		get
		{
			return _RB_Periscope;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_21;
			DarkRadioButton darkRadioButton = _RB_Periscope;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged -= eventHandler;
			}
			_RB_Periscope = value;
			darkRadioButton = _RB_Periscope;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkRadioButton RB_Shallow
	{
		[CompilerGenerated]
		get
		{
			return _RB_Shallow;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_22;
			DarkRadioButton darkRadioButton = _RB_Shallow;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged -= eventHandler;
			}
			_RB_Shallow = value;
			darkRadioButton = _RB_Shallow;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("GroupBox_AltitudePresets")]
	internal virtual DarkGroupBox GroupBox_AltitudePresets { get; set; }

	internal virtual DarkRadioButton RB_MediumAltitude12000
	{
		[CompilerGenerated]
		get
		{
			return _RB_MediumAltitude12000;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_31;
			DarkRadioButton darkRadioButton = _RB_MediumAltitude12000;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged -= eventHandler;
			}
			_RB_MediumAltitude12000 = value;
			darkRadioButton = _RB_MediumAltitude12000;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkRadioButton RB_LowAltitude2000
	{
		[CompilerGenerated]
		get
		{
			return _RB_LowAltitude2000;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_32;
			DarkRadioButton darkRadioButton = _RB_LowAltitude2000;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged -= eventHandler;
			}
			_RB_LowAltitude2000 = value;
			darkRadioButton = _RB_LowAltitude2000;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkRadioButton RB_MinAltitude
	{
		[CompilerGenerated]
		get
		{
			return _RB_MinAltitude;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_34;
			DarkRadioButton darkRadioButton = _RB_MinAltitude;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged -= eventHandler;
			}
			_RB_MinAltitude = value;
			darkRadioButton = _RB_MinAltitude;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkRadioButton RB_LowAltitude1000
	{
		[CompilerGenerated]
		get
		{
			return _RB_LowAltitude1000;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_33;
			DarkRadioButton darkRadioButton = _RB_LowAltitude1000;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged -= eventHandler;
			}
			_RB_LowAltitude1000 = value;
			darkRadioButton = _RB_LowAltitude1000;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkRadioButton RB_HighAltitude25000
	{
		[CompilerGenerated]
		get
		{
			return _RB_HighAltitude25000;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_30;
			DarkRadioButton darkRadioButton = _RB_HighAltitude25000;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged -= eventHandler;
			}
			_RB_HighAltitude25000 = value;
			darkRadioButton = _RB_HighAltitude25000;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkRadioButton RB_HighAltitude36000
	{
		[CompilerGenerated]
		get
		{
			return _RB_HighAltitude36000;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_29;
			DarkRadioButton darkRadioButton = _RB_HighAltitude36000;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged -= eventHandler;
			}
			_RB_HighAltitude36000 = value;
			darkRadioButton = _RB_HighAltitude36000;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkRadioButton RB_MaxAltitude
	{
		[CompilerGenerated]
		get
		{
			return _RB_MaxAltitude;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_27;
			DarkRadioButton darkRadioButton = _RB_MaxAltitude;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged -= eventHandler;
			}
			_RB_MaxAltitude = value;
			darkRadioButton = _RB_MaxAltitude;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkRadioButton RB_Surface
	{
		[CompilerGenerated]
		get
		{
			return _RB_Surface;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_20;
			DarkRadioButton darkRadioButton = _RB_Surface;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged -= eventHandler;
			}
			_RB_Surface = value;
			darkRadioButton = _RB_Surface;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkUITextBox TextBox_EnterSpeed
	{
		[CompilerGenerated]
		get
		{
			return _TextBox_EnterSpeed;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_35;
			EventHandler eventHandler2 = method_36;
			DarkUITextBox darkUITextBox = _TextBox_EnterSpeed;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).Enter -= eventHandler;
				((Control)darkUITextBox).Leave -= eventHandler2;
			}
			_TextBox_EnterSpeed = value;
			darkUITextBox = _TextBox_EnterSpeed;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).Enter += eventHandler;
				((Control)darkUITextBox).Leave += eventHandler2;
			}
		}
	}

	[field: AccessedThroughProperty("Label_Speed")]
	internal virtual DarkLabel Label_Speed { get; set; }

	internal virtual DarkUITextBox TextBox_EnterAltitude
	{
		[CompilerGenerated]
		get
		{
			return _TextBox_EnterAltitude;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_37;
			EventHandler eventHandler2 = method_39;
			DarkUITextBox darkUITextBox = _TextBox_EnterAltitude;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).Enter -= eventHandler;
				((Control)darkUITextBox).Leave -= eventHandler2;
			}
			_TextBox_EnterAltitude = value;
			darkUITextBox = _TextBox_EnterAltitude;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).Enter += eventHandler;
				((Control)darkUITextBox).Leave += eventHandler2;
			}
		}
	}

	[field: AccessedThroughProperty("Label_Altitude")]
	internal virtual DarkLabel Label_Altitude { get; set; }

	internal virtual DarkRadioButton RB_Full
	{
		[CompilerGenerated]
		get
		{
			return _RB_Full;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_12;
			DarkRadioButton darkRadioButton = _RB_Full;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged -= eventHandler;
			}
			_RB_Full = value;
			darkRadioButton = _RB_Full;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkRadioButton RB_Cruise
	{
		[CompilerGenerated]
		get
		{
			return _RB_Cruise;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_11;
			DarkRadioButton darkRadioButton = _RB_Cruise;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged -= eventHandler;
			}
			_RB_Cruise = value;
			darkRadioButton = _RB_Cruise;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkRadioButton RB_Creep
	{
		[CompilerGenerated]
		get
		{
			return _RB_Creep;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_9;
			DarkRadioButton darkRadioButton = _RB_Creep;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged -= eventHandler;
			}
			_RB_Creep = value;
			darkRadioButton = _RB_Creep;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkRadioButton RB_Stop
	{
		[CompilerGenerated]
		get
		{
			return _RB_Stop;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_8;
			DarkRadioButton darkRadioButton = _RB_Stop;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged -= eventHandler;
			}
			_RB_Stop = value;
			darkRadioButton = _RB_Stop;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkRadioButton RB_Flank
	{
		[CompilerGenerated]
		get
		{
			return _RB_Flank;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_14;
			DarkRadioButton darkRadioButton = _RB_Flank;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged -= eventHandler;
			}
			_RB_Flank = value;
			darkRadioButton = _RB_Flank;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("FlowLayoutPanel_Presets")]
	internal virtual FlowLayoutPanel FlowLayoutPanel_Presets { get; set; }

	[field: AccessedThroughProperty("Label_WaypointName")]
	internal virtual DarkLabel Label_WaypointName { get; set; }

	[field: AccessedThroughProperty("GroupBox_Waypoint")]
	internal virtual DarkGroupBox GroupBox_Waypoint { get; set; }

	[field: AccessedThroughProperty("Label_TTG")]
	internal virtual DarkLabel Label_TTG { get; set; }

	[field: AccessedThroughProperty("Label_DTG")]
	internal virtual DarkLabel Label_DTG { get; set; }

	[field: AccessedThroughProperty("Label_Fuel")]
	internal virtual DarkLabel Label_Fuel { get; set; }

	internal virtual DarkUITextBox TextBox_WaypointDescription
	{
		[CompilerGenerated]
		get
		{
			return _TextBox_WaypointDescription;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_43;
			EventHandler eventHandler2 = method_44;
			DarkUITextBox darkUITextBox = _TextBox_WaypointDescription;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).Enter -= eventHandler;
				((Control)darkUITextBox).Leave -= eventHandler2;
			}
			_TextBox_WaypointDescription = value;
			darkUITextBox = _TextBox_WaypointDescription;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).Enter += eventHandler;
				((Control)darkUITextBox).Leave += eventHandler2;
			}
		}
	}

	internal virtual DarkUIComboBox CB_WaypointType
	{
		[CompilerGenerated]
		get
		{
			return _CB_WaypointType;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_41;
			EventHandler eventHandler2 = method_42;
			DarkUIComboBox darkUIComboBox = _CB_WaypointType;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).DropDown -= eventHandler;
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler2;
			}
			_CB_WaypointType = value;
			darkUIComboBox = _CB_WaypointType;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).DropDown += eventHandler;
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler2;
			}
		}
	}

	[field: AccessedThroughProperty("Label4")]
	internal virtual DarkLabel Label4 { get; set; }

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	[field: AccessedThroughProperty("LayerTopPictureBox")]
	internal virtual PictureBox LayerTopPictureBox { get; set; }

	[field: AccessedThroughProperty("LayerBottomPictureBox")]
	internal virtual PictureBox LayerBottomPictureBox { get; set; }

	[field: AccessedThroughProperty("SeaFloorPictureBox")]
	internal virtual PictureBox SeaFloorPictureBox { get; set; }

	[field: AccessedThroughProperty("CloudHighTopPictureBox")]
	internal virtual PictureBox CloudHighTopPictureBox { get; set; }

	[field: AccessedThroughProperty("GroundLevelPictureBox")]
	internal virtual PictureBox GroundLevelPictureBox { get; set; }

	[field: AccessedThroughProperty("Label7")]
	internal virtual DarkLabel Label7 { get; set; }

	[field: AccessedThroughProperty("Label8")]
	internal virtual DarkLabel Label8 { get; set; }

	[field: AccessedThroughProperty("Label9")]
	internal virtual DarkLabel Label9 { get; set; }

	[field: AccessedThroughProperty("Label10")]
	internal virtual DarkLabel Label10 { get; set; }

	[field: AccessedThroughProperty("CloudLowTopPictureBox")]
	internal virtual PictureBox CloudLowTopPictureBox { get; set; }

	[field: AccessedThroughProperty("CloudLowBottomPictureBox")]
	internal virtual PictureBox CloudLowBottomPictureBox { get; set; }

	[field: AccessedThroughProperty("CloudHighBottomPictureBox")]
	internal virtual PictureBox CloudHighBottomPictureBox { get; set; }

	[field: AccessedThroughProperty("Label12")]
	internal virtual DarkLabel Label12 { get; set; }

	[field: AccessedThroughProperty("Label11")]
	internal virtual DarkLabel Label11 { get; set; }

	[field: AccessedThroughProperty("Label14")]
	internal virtual DarkLabel Label14 { get; set; }

	[field: AccessedThroughProperty("Label13")]
	internal virtual DarkLabel Label13 { get; set; }

	[field: AccessedThroughProperty("Label_Cavitation")]
	internal virtual DarkLabel Label_Cavitation { get; set; }

	internal virtual DarkCheckBox CB_TerrainFollowing
	{
		[CompilerGenerated]
		get
		{
			return _CB_TerrainFollowing;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_47;
			DarkCheckBox darkCheckBox = _CB_TerrainFollowing;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_TerrainFollowing = value;
			darkCheckBox = _CB_TerrainFollowing;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_UseLandCoverMasking
	{
		[CompilerGenerated]
		get
		{
			return _CB_UseLandCoverMasking;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_49;
			DarkCheckBox darkCheckBox = _CB_UseLandCoverMasking;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_UseLandCoverMasking = value;
			darkCheckBox = _CB_UseLandCoverMasking;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("ShapeContainer1")]
	private virtual ShapeContainer ShapeContainer1 { get; set; }

	[field: AccessedThroughProperty("LineShape2")]
	private virtual LineShape LineShape2 { get; set; }

	[field: AccessedThroughProperty("LineShape1")]
	private virtual LineShape LineShape1 { get; set; }

	internal virtual DarkRadioButton RB_NoThrottlePreset
	{
		[CompilerGenerated]
		get
		{
			return _RB_NoThrottlePreset;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_13;
			DarkRadioButton darkRadioButton = _RB_NoThrottlePreset;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged -= eventHandler;
			}
			_RB_NoThrottlePreset = value;
			darkRadioButton = _RB_NoThrottlePreset;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkRadioButton RB_NoAltitudePreset
	{
		[CompilerGenerated]
		get
		{
			return _RB_NoAltitudePreset;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_28;
			DarkRadioButton darkRadioButton = _RB_NoAltitudePreset;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged -= eventHandler;
			}
			_RB_NoAltitudePreset = value;
			darkRadioButton = _RB_NoAltitudePreset;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkRadioButton RB_NoDepthPreset
	{
		[CompilerGenerated]
		get
		{
			return _RB_NoDepthPreset;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_25;
			DarkRadioButton darkRadioButton = _RB_NoDepthPreset;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged -= eventHandler;
			}
			_RB_NoDepthPreset = value;
			darkRadioButton = _RB_NoDepthPreset;
			if (darkRadioButton != null)
			{
				((RadioButton)darkRadioButton).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_SprintDrift
	{
		[CompilerGenerated]
		get
		{
			return _CB_SprintDrift;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_50;
			DarkCheckBox darkCheckBox = _CB_SprintDrift;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_SprintDrift = value;
			darkCheckBox = _CB_SprintDrift;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_AvoidCavitation
	{
		[CompilerGenerated]
		get
		{
			return _CB_AvoidCavitation;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_51;
			DarkCheckBox darkCheckBox = _CB_AvoidCavitation;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_AvoidCavitation = value;
			darkCheckBox = _CB_AvoidCavitation;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("FlowLayoutPanel2")]
	internal virtual FlowLayoutPanel FlowLayoutPanel2 { get; set; }

	[field: AccessedThroughProperty("Label_X")]
	internal virtual DarkLabel Label_X { get; set; }

	[field: AccessedThroughProperty("FlowLayoutPanel_SettingsFor")]
	internal virtual FlowLayoutPanel FlowLayoutPanel_SettingsFor { get; set; }

	[field: AccessedThroughProperty("Label_SettingsFor")]
	internal virtual DarkLabel Label_SettingsFor { get; set; }

	internal virtual DarkButton Button_Previous
	{
		[CompilerGenerated]
		get
		{
			return _Button_Previous;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = Button_Previous_Click;
			DarkButton darkButton = _Button_Previous;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_Previous = value;
			darkButton = _Button_Previous;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkButton Button_Next
	{
		[CompilerGenerated]
		get
		{
			return _Button_Next;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = Button_Next_Click;
			DarkButton darkButton = _Button_Next;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_Next = value;
			darkButton = _Button_Next;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("LblWeatherWarning")]
	internal virtual DarkLabel LblWeatherWarning { get; set; }

	[field: AccessedThroughProperty("EventActionLabel")]
	internal virtual DarkLabel EventActionLabel { get; set; }

	internal virtual DarkUIComboBox CB_EventAction
	{
		[CompilerGenerated]
		get
		{
			return _CB_EventAction;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_52;
			EventHandler eventHandler2 = method_53;
			DarkUIComboBox darkUIComboBox = _CB_EventAction;
			if (darkUIComboBox != null)
			{
				((Control)darkUIComboBox).Enter -= eventHandler;
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler2;
			}
			_CB_EventAction = value;
			darkUIComboBox = _CB_EventAction;
			if (darkUIComboBox != null)
			{
				((Control)darkUIComboBox).Enter += eventHandler;
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler2;
			}
		}
	}

	protected override bool RTMPEnabled
	{
		[CompilerGenerated]
		get
		{
			return bool_2;
		}
		[CompilerGenerated]
		set
		{
			bool_2 = value;
		}
	}

	protected SpeedAltMode SpeedAltUIMode
	{
		get
		{
			if (Client.SelectedWaypoint != null && SpeedAlt_FlightPlanWaypoint == null)
			{
				return SpeedAltMode.Waypoint;
			}
			if (SpeedAlt_FlightPlanWaypoint == null)
			{
				if (SpeedAlt_SelectedUnit != null)
				{
					return SpeedAltMode.ActiveUnit;
				}
				return SpeedAltMode.None;
			}
			return SpeedAltMode.FlightplanWaypoint;
		}
	}

	protected string SelectedUnitObjectID
	{
		get
		{
			if (SpeedAlt_SelectedUnit != null && Client.SelectedWaypoint == null && SpeedAlt_FlightPlanWaypoint == null)
			{
				return SpeedAlt_SelectedUnit.ObjectID;
			}
			return string.Empty;
		}
	}

	protected string SelectedWaypointObjectID
	{
		get
		{
			if (Client.SelectedWaypoint == null)
			{
				if (SpeedAlt_FlightPlanWaypoint != null)
				{
					return SpeedAlt_FlightPlanWaypoint.ObjectID;
				}
				return string.Empty;
			}
			return Client.SelectedWaypoint.ObjectID;
		}
	}

	protected string SelectedFlightObjectID
	{
		get
		{
			if (SpeedAlt_Flight != null)
			{
				return SpeedAlt_Flight.ObjectID;
			}
			return string.Empty;
		}
	}

	public SpeedAlt()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		((Form)this).Load += SpeedAlt_Load;
		((Control)this).KeyDown += new KeyEventHandler(SpeedAlt_KeyDown);
		((Form)this).FormClosing += new FormClosingEventHandler(SpeedAlt_FormClosing);
		((Form)this).FormClosed += new FormClosedEventHandler(SpeedAlt_FormClosed);
		RTMPEnabled = true;
		bool_3 = false;
		bool_4 = false;
		bool_5 = false;
		bool_6 = true;
		keys_0 = (Keys[])(object)new Keys[1] { (Keys)69 };
		keys_1 = (Keys[])(object)new Keys[1] { (Keys)81 };
		keys_2 = (Keys[])(object)new Keys[2]
		{
			(Keys)113,
			(Keys)27
		};
		bool_7 = false;
		bool_8 = false;
		bool_9 = false;
		InitializeComponent_1();
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && icontainer_1 != null)
			{
				icontainer_1.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	private void InitializeComponent_1()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Expected O, but got Unknown
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Expected O, but got Unknown
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Expected O, but got Unknown
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Expected O, but got Unknown
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Expected O, but got Unknown
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Expected O, but got Unknown
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Expected O, but got Unknown
		//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c0: Expected O, but got Unknown
		//IL_03a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b2: Expected O, but got Unknown
		//IL_0672: Unknown result type (might be due to invalid IL or missing references)
		//IL_067c: Expected O, but got Unknown
		//IL_070e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0718: Expected O, but got Unknown
		//IL_07be: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c8: Expected O, but got Unknown
		//IL_07f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0850: Unknown result type (might be due to invalid IL or missing references)
		//IL_085a: Expected O, but got Unknown
		//IL_0887: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b59: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b63: Expected O, but got Unknown
		//IL_0c8e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c98: Expected O, but got Unknown
		//IL_12e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_12ec: Expected O, but got Unknown
		//IL_1577: Unknown result type (might be due to invalid IL or missing references)
		//IL_1581: Expected O, but got Unknown
		//IL_1627: Unknown result type (might be due to invalid IL or missing references)
		//IL_1631: Expected O, but got Unknown
		//IL_16d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_16e1: Expected O, but got Unknown
		//IL_1787: Unknown result type (might be due to invalid IL or missing references)
		//IL_1791: Expected O, but got Unknown
		//IL_1837: Unknown result type (might be due to invalid IL or missing references)
		//IL_1841: Expected O, but got Unknown
		//IL_18e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_18ee: Expected O, but got Unknown
		//IL_2cc9: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cd3: Expected O, but got Unknown
		//IL_2d7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d85: Expected O, but got Unknown
		//IL_2e2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e34: Expected O, but got Unknown
		//IL_2ed9: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ee3: Expected O, but got Unknown
		//IL_2f8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f95: Expected O, but got Unknown
		//IL_303a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3044: Expected O, but got Unknown
		//IL_30e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_30f3: Expected O, but got Unknown
		//IL_3198: Unknown result type (might be due to invalid IL or missing references)
		//IL_31a2: Expected O, but got Unknown
		//IL_3369: Unknown result type (might be due to invalid IL or missing references)
		//IL_3373: Expected O, but got Unknown
		//IL_341b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3425: Expected O, but got Unknown
		//IL_34cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_34d5: Expected O, but got Unknown
		//IL_357a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3584: Expected O, but got Unknown
		//IL_362c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3636: Expected O, but got Unknown
		//IL_36db: Unknown result type (might be due to invalid IL or missing references)
		//IL_36e5: Expected O, but got Unknown
		//IL_378a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3794: Expected O, but got Unknown
		//IL_38d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_38de: Expected O, but got Unknown
		//IL_3c56: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e79: Expected O, but got Unknown
		icontainer_1 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(SpeedAlt));
		Timer1 = new Timer(icontainer_1);
		FlowLayoutPanel2 = new FlowLayoutPanel();
		FlowLayoutPanel_SettingsFor = new FlowLayoutPanel();
		Label_X = new DarkLabel();
		Label_SettingsFor = new DarkLabel();
		Button_Previous = new DarkButton();
		Button_Next = new DarkButton();
		GroupBox_Waypoint = new DarkGroupBox();
		Label4 = new DarkLabel();
		Label1 = new DarkLabel();
		TextBox_WaypointDescription = new DarkUITextBox();
		CB_WaypointType = new DarkUIComboBox();
		Label_Fuel = new DarkLabel();
		Label_TTG = new DarkLabel();
		Label_DTG = new DarkLabel();
		Label_WaypointName = new DarkLabel();
		GroupBox_Speed = new DarkGroupBox();
		LblWeatherWarning = new DarkLabel();
		CB_AvoidCavitation = new DarkCheckBox();
		CB_SprintDrift = new DarkCheckBox();
		TextBox_EnterSpeed = new DarkUITextBox();
		CB_SpeedOverride = new DarkCheckBox();
		GroupBox_SpeedPresets = new DarkGroupBox();
		RB_NoThrottlePreset = new DarkRadioButton();
		RB_Flank = new DarkRadioButton();
		RB_Full = new DarkRadioButton();
		RB_Cruise = new DarkRadioButton();
		RB_Creep = new DarkRadioButton();
		RB_Stop = new DarkRadioButton();
		Label_Speed = new DarkLabel();
		Label_MinSpeed = new DarkLabel();
		TrackBar_Throttle = new TrackBar();
		Label_MaxSpeed = new DarkLabel();
		Label2 = new DarkLabel();
		Label_DesiredSpeed = new DarkLabel();
		Label3 = new DarkLabel();
		Label_ActualSpeed = new DarkLabel();
		Label_Cavitation = new DarkLabel();
		GroupBox_Altitude = new DarkGroupBox();
		Label_DesiredAlt = new DarkLabel();
		CB_TerrainFollowing = new DarkCheckBox();
		CB_UseLandCoverMasking = new DarkCheckBox();
		Label14 = new DarkLabel();
		Label13 = new DarkLabel();
		Label12 = new DarkLabel();
		Label11 = new DarkLabel();
		CloudLowTopPictureBox = new PictureBox();
		CloudLowBottomPictureBox = new PictureBox();
		CloudHighBottomPictureBox = new PictureBox();
		Label7 = new DarkLabel();
		Label10 = new DarkLabel();
		Label9 = new DarkLabel();
		Label8 = new DarkLabel();
		GroundLevelPictureBox = new PictureBox();
		CloudHighTopPictureBox = new PictureBox();
		SeaFloorPictureBox = new PictureBox();
		LayerBottomPictureBox = new PictureBox();
		LayerTopPictureBox = new PictureBox();
		Label_MaxAlt = new DarkLabel();
		Label_MinAlt = new DarkLabel();
		FlowLayoutPanel_Presets = new FlowLayoutPanel();
		GroupBox_AltitudePresets = new DarkGroupBox();
		RB_NoAltitudePreset = new DarkRadioButton();
		RB_MediumAltitude12000 = new DarkRadioButton();
		RB_LowAltitude2000 = new DarkRadioButton();
		RB_MinAltitude = new DarkRadioButton();
		RB_LowAltitude1000 = new DarkRadioButton();
		RB_HighAltitude25000 = new DarkRadioButton();
		RB_HighAltitude36000 = new DarkRadioButton();
		RB_MaxAltitude = new DarkRadioButton();
		GroupBox_SubDepthPreset = new DarkGroupBox();
		RB_NoDepthPreset = new DarkRadioButton();
		RB_Surface = new DarkRadioButton();
		RB_Shallow = new DarkRadioButton();
		RB_MaxDepth = new DarkRadioButton();
		RB_UnderLayer = new DarkRadioButton();
		RB_OverLayer = new DarkRadioButton();
		RB_Periscope = new DarkRadioButton();
		Label_Altitude = new DarkLabel();
		TextBox_EnterAltitude = new DarkUITextBox();
		CB_AltOverride = new DarkCheckBox();
		Label6 = new DarkLabel();
		TrackBar_Altitude = new TrackBar();
		Label_CurrentAlt = new DarkLabel();
		Label5 = new DarkLabel();
		ShapeContainer1 = new ShapeContainer();
		LineShape2 = new LineShape();
		LineShape1 = new LineShape();
		EventActionLabel = new DarkLabel();
		CB_EventAction = new DarkUIComboBox();
		((Control)FlowLayoutPanel2).SuspendLayout();
		((Control)FlowLayoutPanel_SettingsFor).SuspendLayout();
		((Control)GroupBox_Waypoint).SuspendLayout();
		((Control)GroupBox_Speed).SuspendLayout();
		((Control)GroupBox_SpeedPresets).SuspendLayout();
		((ISupportInitialize)TrackBar_Throttle).BeginInit();
		((Control)GroupBox_Altitude).SuspendLayout();
		((ISupportInitialize)CloudLowTopPictureBox).BeginInit();
		((ISupportInitialize)CloudLowBottomPictureBox).BeginInit();
		((ISupportInitialize)CloudHighBottomPictureBox).BeginInit();
		((ISupportInitialize)GroundLevelPictureBox).BeginInit();
		((ISupportInitialize)CloudHighTopPictureBox).BeginInit();
		((ISupportInitialize)SeaFloorPictureBox).BeginInit();
		((ISupportInitialize)LayerBottomPictureBox).BeginInit();
		((ISupportInitialize)LayerTopPictureBox).BeginInit();
		((Control)FlowLayoutPanel_Presets).SuspendLayout();
		((Control)GroupBox_AltitudePresets).SuspendLayout();
		((Control)GroupBox_SubDepthPreset).SuspendLayout();
		((ISupportInitialize)TrackBar_Altitude).BeginInit();
		((Control)this).SuspendLayout();
		Timer1.Interval = 1000;
		((Control)FlowLayoutPanel2).Controls.Add((Control)(object)FlowLayoutPanel_SettingsFor);
		((Control)FlowLayoutPanel2).Controls.Add((Control)(object)GroupBox_Waypoint);
		((Control)FlowLayoutPanel2).Controls.Add((Control)(object)GroupBox_Speed);
		((Control)FlowLayoutPanel2).Controls.Add((Control)(object)GroupBox_Altitude);
		((Control)FlowLayoutPanel2).Dock = (DockStyle)5;
		FlowLayoutPanel2.FlowDirection = (FlowDirection)1;
		((Control)FlowLayoutPanel2).Location = new Point(0, 0);
		((Control)FlowLayoutPanel2).Name = "FlowLayoutPanel2";
		((Control)FlowLayoutPanel2).Size = new Size(419, 693);
		((Control)FlowLayoutPanel2).TabIndex = 19;
		FlowLayoutPanel2.WrapContents = false;
		((Control)FlowLayoutPanel_SettingsFor).Anchor = (AnchorStyles)12;
		((Control)FlowLayoutPanel_SettingsFor).Controls.Add((Control)(object)Label_X);
		((Control)FlowLayoutPanel_SettingsFor).Controls.Add((Control)(object)Label_SettingsFor);
		((Control)FlowLayoutPanel_SettingsFor).Controls.Add((Control)(object)Button_Previous);
		((Control)FlowLayoutPanel_SettingsFor).Controls.Add((Control)(object)Button_Next);
		((Control)FlowLayoutPanel_SettingsFor).Location = new Point(3, 3);
		((Control)FlowLayoutPanel_SettingsFor).Name = "FlowLayoutPanel_SettingsFor";
		((Control)FlowLayoutPanel_SettingsFor).Size = new Size(409, 27);
		((Control)FlowLayoutPanel_SettingsFor).TabIndex = 20;
		Label_X.AutoSize = true;
		((Control)Label_X).Font = new Font("Segoe UI", 14f);
		((Control)Label_X).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_X).Location = new Point(3, 0);
		((Control)Label_X).Name = "Label_X";
		((Control)Label_X).Size = new Size(142, 32);
		((Control)Label_X).TabIndex = 19;
		((Label)Label_X).Text = "Settings for:";
		Label_SettingsFor.AutoSize = true;
		((Control)Label_SettingsFor).Font = new Font("Segoe UI", 14f, (FontStyle)1);
		((Control)Label_SettingsFor).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_SettingsFor).Location = new Point(151, 0);
		((Control)Label_SettingsFor).Name = "Label_SettingsFor";
		((Control)Label_SettingsFor).Size = new Size(72, 32);
		((Control)Label_SettingsFor).TabIndex = 20;
		((Label)Label_SettingsFor).Text = "UNIT";
		((Control)Button_Previous).ForeColor = Color.FromArgb(220, 220, 220);
		((ButtonBase)Button_Previous).Image = (Image)componentResourceManager.GetObject("Button_Previous.Image");
		((Control)Button_Previous).Location = new Point(229, 3);
		((Control)Button_Previous).Name = "Button_Previous";
		((Control)Button_Previous).Padding = new Padding(5);
		((Control)Button_Previous).Size = new Size(15, 23);
		((Control)Button_Previous).TabIndex = 21;
		((Control)Button_Next).ForeColor = Color.FromArgb(220, 220, 220);
		((ButtonBase)Button_Next).Image = (Image)componentResourceManager.GetObject("Button_Next.Image");
		((Control)Button_Next).Location = new Point(250, 3);
		((Control)Button_Next).Name = "Button_Next";
		((Control)Button_Next).Padding = new Padding(5);
		((Control)Button_Next).Size = new Size(15, 23);
		((Control)Button_Next).TabIndex = 22;
		((Control)GroupBox_Waypoint).Controls.Add((Control)(object)CB_EventAction);
		((Control)GroupBox_Waypoint).Controls.Add((Control)(object)EventActionLabel);
		((Control)GroupBox_Waypoint).Controls.Add((Control)(object)Label4);
		((Control)GroupBox_Waypoint).Controls.Add((Control)(object)Label1);
		((Control)GroupBox_Waypoint).Controls.Add((Control)(object)TextBox_WaypointDescription);
		((Control)GroupBox_Waypoint).Controls.Add((Control)(object)CB_WaypointType);
		((Control)GroupBox_Waypoint).Controls.Add((Control)(object)Label_Fuel);
		((Control)GroupBox_Waypoint).Controls.Add((Control)(object)Label_TTG);
		((Control)GroupBox_Waypoint).Controls.Add((Control)(object)Label_DTG);
		((Control)GroupBox_Waypoint).Controls.Add((Control)(object)Label_WaypointName);
		((Control)GroupBox_Waypoint).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroupBox_Waypoint).Location = new Point(3, 36);
		((Control)GroupBox_Waypoint).Name = "GroupBox_Waypoint";
		((Control)GroupBox_Waypoint).Size = new Size(409, 165);
		((Control)GroupBox_Waypoint).TabIndex = 18;
		((GroupBox)GroupBox_Waypoint).TabStop = false;
		((GroupBox)GroupBox_Waypoint).Text = "WAYPOINT";
		Label4.AutoSize = true;
		((Control)Label4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label4).Location = new Point(5, 106);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(43, 20);
		((Control)Label4).TabIndex = 21;
		((Label)Label4).Text = "Type:";
		Label1.AutoSize = true;
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(5, 84);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(88, 20);
		((Control)Label1).TabIndex = 20;
		((Label)Label1).Text = "Description:";
		TextBox_WaypointDescription.AutoCompleteCustomSource = null;
		TextBox_WaypointDescription.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox_WaypointDescription.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox_WaypointDescription).BackColor = Color.Transparent;
		TextBox_WaypointDescription.Font = new Font("Segoe UI", 8f);
		((Control)TextBox_WaypointDescription).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_WaypointDescription.Image = null;
		TextBox_WaypointDescription.Lines = null;
		((Control)TextBox_WaypointDescription).Location = new Point(77, 80);
		TextBox_WaypointDescription.MaxLength = 32767;
		TextBox_WaypointDescription.Multiline = false;
		((Control)TextBox_WaypointDescription).Name = "TextBox_WaypointDescription";
		TextBox_WaypointDescription.ReadOnly = false;
		TextBox_WaypointDescription.ScrollBars = (ScrollBars)0;
		TextBox_WaypointDescription.SelectionStart = 0;
		((Control)TextBox_WaypointDescription).Size = new Size(325, 20);
		((Control)TextBox_WaypointDescription).TabIndex = 19;
		TextBox_WaypointDescription.TextAlign = (HorizontalAlignment)0;
		TextBox_WaypointDescription.UseSystemPasswordChar = false;
		TextBox_WaypointDescription.WatermarkText = "";
		TextBox_WaypointDescription.WordWrap = false;
		((ComboBox)CB_WaypointType).BackColor = Color.Transparent;
		((ComboBox)CB_WaypointType).DrawMode = (DrawMode)1;
		((ComboBox)CB_WaypointType).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_WaypointType).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_WaypointType).FormattingEnabled = true;
		((ComboBox)CB_WaypointType).Items.AddRange(new object[16]
		{
			"Form-Up ", "Plotted Course / Navigation", "Target", "Turning Point", "Initial Point", "Ingress", "Egress", "TakeOff", "Hold (Start)", "Hold (End)",
			"Turning Point", "Landing Marshall", "Land", "Patrol Station", "Localization Run", "Refuel"
		});
		((Control)CB_WaypointType).Location = new Point(77, 102);
		((Control)CB_WaypointType).Name = "CB_WaypointType";
		((Control)CB_WaypointType).Size = new Size(325, 24);
		((Control)CB_WaypointType).TabIndex = 18;
		Label_Fuel.AutoSize = true;
		((Control)Label_Fuel).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_Fuel).Location = new Point(5, 61);
		((Control)Label_Fuel).Name = "Label_Fuel";
		((Control)Label_Fuel).Size = new Size(78, 20);
		((Control)Label_Fuel).TabIndex = 17;
		((Label)Label_Fuel).Text = "Label_Fuel";
		Label_TTG.AutoSize = true;
		((Control)Label_TTG).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_TTG).Location = new Point(88, 43);
		((Control)Label_TTG).Name = "Label_TTG";
		((Control)Label_TTG).Size = new Size(76, 20);
		((Control)Label_TTG).TabIndex = 16;
		((Label)Label_TTG).Text = "Label_TTG";
		Label_DTG.AutoSize = true;
		((Control)Label_DTG).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_DTG).Location = new Point(5, 43);
		((Control)Label_DTG).Name = "Label_DTG";
		((Control)Label_DTG).Size = new Size(78, 20);
		((Control)Label_DTG).TabIndex = 15;
		((Label)Label_DTG).Text = "Label_DTG";
		Label_WaypointName.AutoSize = true;
		((Control)Label_WaypointName).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_WaypointName).Location = new Point(5, 20);
		((Control)Label_WaypointName).Name = "Label_WaypointName";
		((Control)Label_WaypointName).Size = new Size(112, 20);
		((Control)Label_WaypointName).TabIndex = 11;
		((Label)Label_WaypointName).Text = "WaypointName";
		((Control)GroupBox_Speed).Controls.Add((Control)(object)LblWeatherWarning);
		((Control)GroupBox_Speed).Controls.Add((Control)(object)CB_AvoidCavitation);
		((Control)GroupBox_Speed).Controls.Add((Control)(object)CB_SprintDrift);
		((Control)GroupBox_Speed).Controls.Add((Control)(object)TextBox_EnterSpeed);
		((Control)GroupBox_Speed).Controls.Add((Control)(object)CB_SpeedOverride);
		((Control)GroupBox_Speed).Controls.Add((Control)(object)GroupBox_SpeedPresets);
		((Control)GroupBox_Speed).Controls.Add((Control)(object)Label_Speed);
		((Control)GroupBox_Speed).Controls.Add((Control)(object)Label_MinSpeed);
		((Control)GroupBox_Speed).Controls.Add((Control)(object)TrackBar_Throttle);
		((Control)GroupBox_Speed).Controls.Add((Control)(object)Label_MaxSpeed);
		((Control)GroupBox_Speed).Controls.Add((Control)(object)Label2);
		((Control)GroupBox_Speed).Controls.Add((Control)(object)Label_DesiredSpeed);
		((Control)GroupBox_Speed).Controls.Add((Control)(object)Label3);
		((Control)GroupBox_Speed).Controls.Add((Control)(object)Label_ActualSpeed);
		((Control)GroupBox_Speed).Controls.Add((Control)(object)Label_Cavitation);
		((Control)GroupBox_Speed).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroupBox_Speed).Location = new Point(3, 207);
		((Control)GroupBox_Speed).Name = "GroupBox_Speed";
		((Control)GroupBox_Speed).Size = new Size(409, 181);
		((Control)GroupBox_Speed).TabIndex = 16;
		((GroupBox)GroupBox_Speed).TabStop = false;
		((GroupBox)GroupBox_Speed).Text = "THROTTLE";
		LblWeatherWarning.AutoSize = true;
		((Control)LblWeatherWarning).ForeColor = Color.Orange;
		((Control)LblWeatherWarning).Location = new Point(8, 19);
		((Control)LblWeatherWarning).Name = "LblWeatherWarning";
		((Control)LblWeatherWarning).Size = new Size(161, 20);
		((Control)LblWeatherWarning).TabIndex = 14;
		((Label)LblWeatherWarning).Text = "WeatherSpeedWarning";
		((ButtonBase)CB_AvoidCavitation).AutoSize = true;
		((Control)CB_AvoidCavitation).Location = new Point(294, 81);
		((Control)CB_AvoidCavitation).Name = "CB_AvoidCavitation";
		((Control)CB_AvoidCavitation).Size = new Size(141, 24);
		((Control)CB_AvoidCavitation).TabIndex = 13;
		((ButtonBase)CB_AvoidCavitation).Text = "Avoid Cavitation";
		((ButtonBase)CB_SprintDrift).AutoSize = true;
		((Control)CB_SprintDrift).Location = new Point(294, 39);
		((Control)CB_SprintDrift).Name = "CB_SprintDrift";
		((Control)CB_SprintDrift).Size = new Size(135, 24);
		((Control)CB_SprintDrift).TabIndex = 12;
		((ButtonBase)CB_SprintDrift).Text = "Sprint And Drift";
		TextBox_EnterSpeed.AutoCompleteCustomSource = null;
		TextBox_EnterSpeed.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox_EnterSpeed.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox_EnterSpeed).BackColor = Color.Transparent;
		TextBox_EnterSpeed.Font = new Font("Segoe UI", 8f);
		((Control)TextBox_EnterSpeed).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_EnterSpeed.Image = null;
		TextBox_EnterSpeed.Lines = null;
		((Control)TextBox_EnterSpeed).Location = new Point(119, 37);
		TextBox_EnterSpeed.MaxLength = 32767;
		TextBox_EnterSpeed.Multiline = false;
		((Control)TextBox_EnterSpeed).Name = "TextBox_EnterSpeed";
		TextBox_EnterSpeed.ReadOnly = false;
		TextBox_EnterSpeed.ScrollBars = (ScrollBars)0;
		TextBox_EnterSpeed.SelectionStart = 0;
		((Control)TextBox_EnterSpeed).Size = new Size(60, 20);
		((Control)TextBox_EnterSpeed).TabIndex = 2;
		TextBox_EnterSpeed.TextAlign = (HorizontalAlignment)0;
		TextBox_EnterSpeed.UseSystemPasswordChar = false;
		TextBox_EnterSpeed.WatermarkText = "";
		TextBox_EnterSpeed.WordWrap = false;
		((ButtonBase)CB_SpeedOverride).AutoSize = true;
		((Control)CB_SpeedOverride).Location = new Point(9, 39);
		((Control)CB_SpeedOverride).Name = "CB_SpeedOverride";
		((Control)CB_SpeedOverride).Size = new Size(141, 24);
		((Control)CB_SpeedOverride).TabIndex = 1;
		((ButtonBase)CB_SpeedOverride).Text = "Manual Override";
		((Control)GroupBox_SpeedPresets).Controls.Add((Control)(object)RB_NoThrottlePreset);
		((Control)GroupBox_SpeedPresets).Controls.Add((Control)(object)RB_Flank);
		((Control)GroupBox_SpeedPresets).Controls.Add((Control)(object)RB_Full);
		((Control)GroupBox_SpeedPresets).Controls.Add((Control)(object)RB_Cruise);
		((Control)GroupBox_SpeedPresets).Controls.Add((Control)(object)RB_Creep);
		((Control)GroupBox_SpeedPresets).Controls.Add((Control)(object)RB_Stop);
		((Control)GroupBox_SpeedPresets).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroupBox_SpeedPresets).Location = new Point(6, 132);
		((Control)GroupBox_SpeedPresets).Name = "GroupBox_SpeedPresets";
		((Control)GroupBox_SpeedPresets).Size = new Size(397, 44);
		((Control)GroupBox_SpeedPresets).TabIndex = 10;
		((GroupBox)GroupBox_SpeedPresets).TabStop = false;
		((GroupBox)GroupBox_SpeedPresets).Text = "Throttle Presets";
		((ButtonBase)RB_NoThrottlePreset).BackColor = Color.Transparent;
		((Control)RB_NoThrottlePreset).Cursor = Cursors.Hand;
		((Control)RB_NoThrottlePreset).Font = new Font("Segoe UI", 9f);
		((Control)RB_NoThrottlePreset).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)RB_NoThrottlePreset).Location = new Point(339, 20);
		((Control)RB_NoThrottlePreset).Name = "RB_NoThrottlePreset";
		((Control)RB_NoThrottlePreset).Size = new Size(51, 21);
		((Control)RB_NoThrottlePreset).TabIndex = 5;
		((ButtonBase)RB_NoThrottlePreset).Text = "None";
		((ButtonBase)RB_Flank).BackColor = Color.Transparent;
		((Control)RB_Flank).Cursor = Cursors.Hand;
		((Control)RB_Flank).Font = new Font("Segoe UI", 9f);
		((Control)RB_Flank).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)RB_Flank).Location = new Point(261, 20);
		((Control)RB_Flank).Name = "RB_Flank";
		((Control)RB_Flank).Size = new Size(80, 21);
		((Control)RB_Flank).TabIndex = 0;
		((ButtonBase)RB_Flank).Text = "Flank";
		((ButtonBase)RB_Full).BackColor = Color.Transparent;
		((Control)RB_Full).Cursor = Cursors.Hand;
		((Control)RB_Full).Font = new Font("Segoe UI", 9f);
		((Control)RB_Full).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)RB_Full).Location = new Point(201, 20);
		((Control)RB_Full).Name = "RB_Full";
		((Control)RB_Full).Size = new Size(70, 21);
		((Control)RB_Full).TabIndex = 4;
		((ButtonBase)RB_Full).Text = "Full";
		((ButtonBase)RB_Cruise).BackColor = Color.Transparent;
		((Control)RB_Cruise).Cursor = Cursors.Hand;
		((Control)RB_Cruise).Font = new Font("Segoe UI", 9f);
		((Control)RB_Cruise).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)RB_Cruise).Location = new Point(131, 20);
		((Control)RB_Cruise).Name = "RB_Cruise";
		((Control)RB_Cruise).Size = new Size(60, 21);
		((Control)RB_Cruise).TabIndex = 3;
		((ButtonBase)RB_Cruise).Text = "Cruise";
		((ButtonBase)RB_Creep).BackColor = Color.Transparent;
		((Control)RB_Creep).Cursor = Cursors.Hand;
		((Control)RB_Creep).Font = new Font("Segoe UI", 9f);
		((Control)RB_Creep).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)RB_Creep).Location = new Point(70, 20);
		((Control)RB_Creep).Name = "RB_Creep";
		((Control)RB_Creep).Size = new Size(60, 21);
		((Control)RB_Creep).TabIndex = 2;
		((ButtonBase)RB_Creep).Text = "Creep";
		((ButtonBase)RB_Stop).BackColor = Color.Transparent;
		((Control)RB_Stop).Cursor = Cursors.Hand;
		((Control)RB_Stop).Font = new Font("Segoe UI", 9f);
		((Control)RB_Stop).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)RB_Stop).Location = new Point(10, 20);
		((Control)RB_Stop).Name = "RB_Stop";
		((Control)RB_Stop).Size = new Size(59, 21);
		((Control)RB_Stop).TabIndex = 1;
		((ButtonBase)RB_Stop).Text = "Stop";
		Label_Speed.AutoSize = true;
		((Control)Label_Speed).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_Speed).Location = new Point(183, 40);
		((Control)Label_Speed).Name = "Label_Speed";
		((Control)Label_Speed).Size = new Size(21, 20);
		((Control)Label_Speed).TabIndex = 3;
		((Label)Label_Speed).Text = "kt";
		Label_MinSpeed.AutoSize = true;
		((Control)Label_MinSpeed).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_MinSpeed).Location = new Point(3, 102);
		((Control)Label_MinSpeed).Name = "Label_MinSpeed";
		((Control)Label_MinSpeed).RightToLeft = (RightToLeft)0;
		((Control)Label_MinSpeed).Size = new Size(76, 20);
		((Control)Label_MinSpeed).TabIndex = 4;
		((Label)Label_MinSpeed).Text = "MinSpeed";
		((Label)Label_MinSpeed).TextAlign = (ContentAlignment)64;
		TrackBar_Throttle.AutoSize = false;
		TrackBar_Throttle.LargeChange = 10;
		((Control)TrackBar_Throttle).Location = new Point(55, 98);
		((Control)TrackBar_Throttle).Name = "TrackBar_Throttle";
		((Control)TrackBar_Throttle).Size = new Size(290, 31);
		TrackBar_Throttle.SmallChange = 5;
		((Control)TrackBar_Throttle).TabIndex = 0;
		TrackBar_Throttle.TickFrequency = 100;
		Label_MaxSpeed.AutoSize = true;
		((Control)Label_MaxSpeed).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_MaxSpeed).Location = new Point(343, 102);
		((Control)Label_MaxSpeed).Name = "Label_MaxSpeed";
		((Control)Label_MaxSpeed).Size = new Size(79, 20);
		((Control)Label_MaxSpeed).TabIndex = 3;
		((Label)Label_MaxSpeed).Text = "MaxSpeed";
		((Label)Label_MaxSpeed).TextAlign = (ContentAlignment)16;
		Label2.AutoSize = true;
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(5, 62);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(109, 20);
		((Control)Label2).TabIndex = 4;
		((Label)Label2).Text = "Desired Speed:";
		Label_DesiredSpeed.AutoSize = true;
		((Control)Label_DesiredSpeed).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_DesiredSpeed).Location = new Point(116, 61);
		((Control)Label_DesiredSpeed).Name = "Label_DesiredSpeed";
		((Control)Label_DesiredSpeed).Size = new Size(102, 20);
		((Control)Label_DesiredSpeed).TabIndex = 5;
		((Label)Label_DesiredSpeed).Text = "DesiredSpeed";
		Label3.AutoSize = true;
		((Control)Label3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label3).Location = new Point(5, 80);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(106, 20);
		((Control)Label3).TabIndex = 6;
		((Label)Label3).Text = "Current Speed:";
		Label_ActualSpeed.AutoSize = true;
		((Control)Label_ActualSpeed).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_ActualSpeed).Location = new Point(116, 80);
		((Control)Label_ActualSpeed).Name = "Label_ActualSpeed";
		((Control)Label_ActualSpeed).Size = new Size(99, 20);
		((Control)Label_ActualSpeed).TabIndex = 7;
		((Label)Label_ActualSpeed).Text = "CurrentSpeed";
		Label_Cavitation.AutoSize = true;
		((Control)Label_Cavitation).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_Cavitation).Location = new Point(220, 61);
		((Control)Label_Cavitation).Name = "Label_Cavitation";
		((Control)Label_Cavitation).Size = new Size(116, 20);
		((Control)Label_Cavitation).TabIndex = 11;
		((Label)Label_Cavitation).Text = "Label Cavitation";
		((Control)GroupBox_Altitude).Controls.Add((Control)(object)Label_DesiredAlt);
		((Control)GroupBox_Altitude).Controls.Add((Control)(object)CB_TerrainFollowing);
		((Control)GroupBox_Altitude).Controls.Add((Control)(object)CB_UseLandCoverMasking);
		((Control)GroupBox_Altitude).Controls.Add((Control)(object)Label14);
		((Control)GroupBox_Altitude).Controls.Add((Control)(object)Label13);
		((Control)GroupBox_Altitude).Controls.Add((Control)(object)Label12);
		((Control)GroupBox_Altitude).Controls.Add((Control)(object)Label11);
		((Control)GroupBox_Altitude).Controls.Add((Control)(object)CloudLowTopPictureBox);
		((Control)GroupBox_Altitude).Controls.Add((Control)(object)CloudLowBottomPictureBox);
		((Control)GroupBox_Altitude).Controls.Add((Control)(object)CloudHighBottomPictureBox);
		((Control)GroupBox_Altitude).Controls.Add((Control)(object)Label7);
		((Control)GroupBox_Altitude).Controls.Add((Control)(object)Label10);
		((Control)GroupBox_Altitude).Controls.Add((Control)(object)Label9);
		((Control)GroupBox_Altitude).Controls.Add((Control)(object)Label8);
		((Control)GroupBox_Altitude).Controls.Add((Control)(object)GroundLevelPictureBox);
		((Control)GroupBox_Altitude).Controls.Add((Control)(object)CloudHighTopPictureBox);
		((Control)GroupBox_Altitude).Controls.Add((Control)(object)SeaFloorPictureBox);
		((Control)GroupBox_Altitude).Controls.Add((Control)(object)LayerBottomPictureBox);
		((Control)GroupBox_Altitude).Controls.Add((Control)(object)LayerTopPictureBox);
		((Control)GroupBox_Altitude).Controls.Add((Control)(object)Label_MaxAlt);
		((Control)GroupBox_Altitude).Controls.Add((Control)(object)Label_MinAlt);
		((Control)GroupBox_Altitude).Controls.Add((Control)(object)FlowLayoutPanel_Presets);
		((Control)GroupBox_Altitude).Controls.Add((Control)(object)Label_Altitude);
		((Control)GroupBox_Altitude).Controls.Add((Control)(object)TextBox_EnterAltitude);
		((Control)GroupBox_Altitude).Controls.Add((Control)(object)CB_AltOverride);
		((Control)GroupBox_Altitude).Controls.Add((Control)(object)Label6);
		((Control)GroupBox_Altitude).Controls.Add((Control)(object)TrackBar_Altitude);
		((Control)GroupBox_Altitude).Controls.Add((Control)(object)Label_CurrentAlt);
		((Control)GroupBox_Altitude).Controls.Add((Control)(object)Label5);
		((Control)GroupBox_Altitude).Controls.Add((Control)(object)ShapeContainer1);
		((Control)GroupBox_Altitude).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroupBox_Altitude).Location = new Point(3, 394);
		((Control)GroupBox_Altitude).Name = "GroupBox_Altitude";
		((Control)GroupBox_Altitude).Size = new Size(409, 303);
		((Control)GroupBox_Altitude).TabIndex = 17;
		((GroupBox)GroupBox_Altitude).TabStop = false;
		((GroupBox)GroupBox_Altitude).Text = "ALTITUDE / DEPTH";
		Label_DesiredAlt.AutoSize = true;
		((Control)Label_DesiredAlt).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_DesiredAlt).Location = new Point(109, 43);
		((Control)Label_DesiredAlt).Name = "Label_DesiredAlt";
		((Control)Label_DesiredAlt).Size = new Size(79, 20);
		((Control)Label_DesiredAlt).TabIndex = 14;
		((Label)Label_DesiredAlt).Text = "DesiredAlt";
		((Control)CB_TerrainFollowing).Location = new Point(9, 276);
		((Control)CB_TerrainFollowing).Name = "CB_TerrainFollowing";
		((Control)CB_TerrainFollowing).Size = new Size(261, 20);
		((Control)CB_TerrainFollowing).TabIndex = 44;
		((ButtonBase)CB_TerrainFollowing).Text = "Terrain Following - Above Ground Level (AGL)";
		((Control)CB_UseLandCoverMasking).Location = new Point(275, 276);
		((Control)CB_UseLandCoverMasking).Name = "CB_UseLandCoverMasking";
		((Control)CB_UseLandCoverMasking).Size = new Size(133, 20);
		((Control)CB_UseLandCoverMasking).TabIndex = 45;
		((ButtonBase)CB_UseLandCoverMasking).Text = "Land Cover Masking";
		Label14.AutoSize = true;
		((Control)Label14).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label14).Location = new Point(311, 61);
		((Control)Label14).Name = "Label14";
		((Control)Label14).Size = new Size(61, 20);
		((Control)Label14).TabIndex = 42;
		((Label)Label14).Text = "Label14";
		Label13.AutoSize = true;
		((Control)Label13).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label13).Location = new Point(311, 124);
		((Control)Label13).Name = "Label13";
		((Control)Label13).Size = new Size(61, 20);
		((Control)Label13).TabIndex = 41;
		((Label)Label13).Text = "Label13";
		Label12.AutoSize = true;
		((Control)Label12).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label12).Location = new Point(311, 216);
		((Control)Label12).Name = "Label12";
		((Control)Label12).Size = new Size(61, 20);
		((Control)Label12).TabIndex = 40;
		((Label)Label12).Text = "Label12";
		Label11.AutoSize = true;
		((Control)Label11).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label11).Location = new Point(311, 194);
		((Control)Label11).Name = "Label11";
		((Control)Label11).Size = new Size(61, 20);
		((Control)Label11).TabIndex = 39;
		((Label)Label11).Text = "Label11";
		CloudLowTopPictureBox.Image = (Image)(object)Resources.CloudTop;
		((Control)CloudLowTopPictureBox).Location = new Point(256, 121);
		((Control)CloudLowTopPictureBox).Name = "CloudLowTopPictureBox";
		((Control)CloudLowTopPictureBox).Size = new Size(28, 12);
		CloudLowTopPictureBox.TabIndex = 38;
		CloudLowTopPictureBox.TabStop = false;
		CloudLowBottomPictureBox.Image = (Image)(object)Resources.CloudTop;
		((Control)CloudLowBottomPictureBox).Location = new Point(256, 226);
		((Control)CloudLowBottomPictureBox).Name = "CloudLowBottomPictureBox";
		((Control)CloudLowBottomPictureBox).Size = new Size(28, 12);
		CloudLowBottomPictureBox.TabIndex = 37;
		CloudLowBottomPictureBox.TabStop = false;
		CloudHighBottomPictureBox.Image = (Image)(object)Resources.CloudTop;
		((Control)CloudHighBottomPictureBox).Location = new Point(256, 208);
		((Control)CloudHighBottomPictureBox).Name = "CloudHighBottomPictureBox";
		((Control)CloudHighBottomPictureBox).Size = new Size(28, 12);
		CloudHighBottomPictureBox.TabIndex = 36;
		CloudHighBottomPictureBox.TabStop = false;
		Label7.AutoSize = true;
		((Control)Label7).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label7).Location = new Point(311, 81);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(53, 20);
		((Control)Label7).TabIndex = 32;
		((Label)Label7).Text = "Label7";
		((Label)Label7).TextAlign = (ContentAlignment)16;
		Label10.AutoSize = true;
		((Control)Label10).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label10).Location = new Point(311, 168);
		((Control)Label10).Name = "Label10";
		((Control)Label10).Size = new Size(61, 20);
		((Control)Label10).TabIndex = 35;
		((Label)Label10).Text = "Label10";
		Label9.AutoSize = true;
		((Control)Label9).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label9).Location = new Point(311, 146);
		((Control)Label9).Name = "Label9";
		((Control)Label9).Size = new Size(53, 20);
		((Control)Label9).TabIndex = 34;
		((Label)Label9).Text = "Label9";
		Label8.AutoSize = true;
		((Control)Label8).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label8).Location = new Point(311, 104);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(53, 20);
		((Control)Label8).TabIndex = 33;
		((Label)Label8).Text = "Label8";
		GroundLevelPictureBox.Image = (Image)(object)Resources.GroudLevel;
		((Control)GroundLevelPictureBox).Location = new Point(256, 168);
		((Control)GroundLevelPictureBox).Name = "GroundLevelPictureBox";
		((Control)GroundLevelPictureBox).Size = new Size(28, 12);
		GroundLevelPictureBox.TabIndex = 30;
		GroundLevelPictureBox.TabStop = false;
		CloudHighTopPictureBox.Image = (Image)(object)Resources.CloudTop;
		((Control)CloudHighTopPictureBox).Location = new Point(256, 190);
		((Control)CloudHighTopPictureBox).Name = "CloudHighTopPictureBox";
		((Control)CloudHighTopPictureBox).Size = new Size(28, 12);
		CloudHighTopPictureBox.TabIndex = 28;
		CloudHighTopPictureBox.TabStop = false;
		SeaFloorPictureBox.Image = (Image)(object)Resources.SeaFloor;
		((Control)SeaFloorPictureBox).Location = new Point(256, 146);
		((Control)SeaFloorPictureBox).Name = "SeaFloorPictureBox";
		((Control)SeaFloorPictureBox).Size = new Size(28, 12);
		SeaFloorPictureBox.TabIndex = 27;
		SeaFloorPictureBox.TabStop = false;
		LayerBottomPictureBox.Image = (Image)(object)Resources.LayerBottom;
		((Control)LayerBottomPictureBox).Location = new Point(256, 103);
		((Control)LayerBottomPictureBox).Name = "LayerBottomPictureBox";
		((Control)LayerBottomPictureBox).Size = new Size(28, 12);
		LayerBottomPictureBox.TabIndex = 26;
		LayerBottomPictureBox.TabStop = false;
		LayerTopPictureBox.Image = (Image)(object)Resources.LayerTop;
		((Control)LayerTopPictureBox).Location = new Point(256, 80);
		((Control)LayerTopPictureBox).Name = "LayerTopPictureBox";
		((Control)LayerTopPictureBox).Size = new Size(28, 12);
		LayerTopPictureBox.TabIndex = 25;
		LayerTopPictureBox.TabStop = false;
		Label_MaxAlt.AutoSize = true;
		((Control)Label_MaxAlt).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_MaxAlt).Location = new Point(317, 16);
		((Control)Label_MaxAlt).Name = "Label_MaxAlt";
		((Control)Label_MaxAlt).RightToLeft = (RightToLeft)0;
		((Control)Label_MaxAlt).Size = new Size(56, 20);
		((Control)Label_MaxAlt).TabIndex = 12;
		((Label)Label_MaxAlt).Text = "MaxAlt";
		((Label)Label_MaxAlt).TextAlign = (ContentAlignment)64;
		Label_MinAlt.AutoSize = true;
		((Control)Label_MinAlt).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_MinAlt).Location = new Point(317, 247);
		((Control)Label_MinAlt).Name = "Label_MinAlt";
		((Control)Label_MinAlt).RightToLeft = (RightToLeft)0;
		((Control)Label_MinAlt).Size = new Size(53, 20);
		((Control)Label_MinAlt).TabIndex = 13;
		((Label)Label_MinAlt).Text = "MinAlt";
		((Label)Label_MinAlt).TextAlign = (ContentAlignment)64;
		((Control)FlowLayoutPanel_Presets).Controls.Add((Control)(object)GroupBox_AltitudePresets);
		((Control)FlowLayoutPanel_Presets).Controls.Add((Control)(object)GroupBox_SubDepthPreset);
		((Control)FlowLayoutPanel_Presets).Location = new Point(8, 77);
		((Control)FlowLayoutPanel_Presets).Name = "FlowLayoutPanel_Presets";
		((Control)FlowLayoutPanel_Presets).Size = new Size(214, 196);
		((Control)FlowLayoutPanel_Presets).TabIndex = 24;
		((Control)GroupBox_AltitudePresets).Controls.Add((Control)(object)RB_NoAltitudePreset);
		((Control)GroupBox_AltitudePresets).Controls.Add((Control)(object)RB_MediumAltitude12000);
		((Control)GroupBox_AltitudePresets).Controls.Add((Control)(object)RB_LowAltitude2000);
		((Control)GroupBox_AltitudePresets).Controls.Add((Control)(object)RB_MinAltitude);
		((Control)GroupBox_AltitudePresets).Controls.Add((Control)(object)RB_LowAltitude1000);
		((Control)GroupBox_AltitudePresets).Controls.Add((Control)(object)RB_HighAltitude25000);
		((Control)GroupBox_AltitudePresets).Controls.Add((Control)(object)RB_HighAltitude36000);
		((Control)GroupBox_AltitudePresets).Controls.Add((Control)(object)RB_MaxAltitude);
		((Control)GroupBox_AltitudePresets).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroupBox_AltitudePresets).Location = new Point(3, 3);
		((Control)GroupBox_AltitudePresets).Name = "GroupBox_AltitudePresets";
		((Control)GroupBox_AltitudePresets).Size = new Size(210, 193);
		((Control)GroupBox_AltitudePresets).TabIndex = 21;
		((GroupBox)GroupBox_AltitudePresets).TabStop = false;
		((GroupBox)GroupBox_AltitudePresets).Text = "Altitude Presets";
		((ButtonBase)RB_NoAltitudePreset).BackColor = Color.Transparent;
		((Control)RB_NoAltitudePreset).Cursor = Cursors.Hand;
		((Control)RB_NoAltitudePreset).Font = new Font("Segoe UI", 9f);
		((Control)RB_NoAltitudePreset).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)RB_NoAltitudePreset).Location = new Point(6, 169);
		((Control)RB_NoAltitudePreset).Name = "RB_NoAltitudePreset";
		((Control)RB_NoAltitudePreset).Size = new Size(200, 21);
		((Control)RB_NoAltitudePreset).TabIndex = 7;
		((ButtonBase)RB_NoAltitudePreset).Text = "None";
		((ButtonBase)RB_MediumAltitude12000).BackColor = Color.Transparent;
		((Control)RB_MediumAltitude12000).Cursor = Cursors.Hand;
		((Control)RB_MediumAltitude12000).Font = new Font("Segoe UI", 9f);
		((Control)RB_MediumAltitude12000).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)RB_MediumAltitude12000).Location = new Point(6, 83);
		((Control)RB_MediumAltitude12000).Name = "RB_MediumAltitude12000";
		((Control)RB_MediumAltitude12000).Size = new Size(200, 21);
		((Control)RB_MediumAltitude12000).TabIndex = 6;
		((ButtonBase)RB_MediumAltitude12000).Text = "Medium Altitude (12000 ft)";
		((ButtonBase)RB_LowAltitude2000).BackColor = Color.Transparent;
		((Control)RB_LowAltitude2000).Cursor = Cursors.Hand;
		((Control)RB_LowAltitude2000).Font = new Font("Segoe UI", 9f);
		((Control)RB_LowAltitude2000).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)RB_LowAltitude2000).Location = new Point(6, 105);
		((Control)RB_LowAltitude2000).Name = "RB_LowAltitude2000";
		((Control)RB_LowAltitude2000).Size = new Size(200, 21);
		((Control)RB_LowAltitude2000).TabIndex = 5;
		((ButtonBase)RB_LowAltitude2000).Text = "Low Altitude (2000 ft)";
		((ButtonBase)RB_MinAltitude).BackColor = Color.Transparent;
		((Control)RB_MinAltitude).Cursor = Cursors.Hand;
		((Control)RB_MinAltitude).Font = new Font("Segoe UI", 9f);
		((Control)RB_MinAltitude).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)RB_MinAltitude).Location = new Point(6, 149);
		((Control)RB_MinAltitude).Name = "RB_MinAltitude";
		((Control)RB_MinAltitude).Size = new Size(200, 21);
		((Control)RB_MinAltitude).TabIndex = 4;
		((ButtonBase)RB_MinAltitude).Text = "Min Altitude";
		((ButtonBase)RB_LowAltitude1000).BackColor = Color.Transparent;
		((Control)RB_LowAltitude1000).Cursor = Cursors.Hand;
		((Control)RB_LowAltitude1000).Font = new Font("Segoe UI", 9f);
		((Control)RB_LowAltitude1000).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)RB_LowAltitude1000).Location = new Point(6, 127);
		((Control)RB_LowAltitude1000).Name = "RB_LowAltitude1000";
		((Control)RB_LowAltitude1000).Size = new Size(200, 21);
		((Control)RB_LowAltitude1000).TabIndex = 3;
		((ButtonBase)RB_LowAltitude1000).Text = "Low Altitude (1000 ft)";
		((ButtonBase)RB_HighAltitude25000).BackColor = Color.Transparent;
		((Control)RB_HighAltitude25000).Cursor = Cursors.Hand;
		((Control)RB_HighAltitude25000).Font = new Font("Segoe UI", 9f);
		((Control)RB_HighAltitude25000).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)RB_HighAltitude25000).Location = new Point(6, 61);
		((Control)RB_HighAltitude25000).Name = "RB_HighAltitude25000";
		((Control)RB_HighAltitude25000).Size = new Size(200, 21);
		((Control)RB_HighAltitude25000).TabIndex = 2;
		((ButtonBase)RB_HighAltitude25000).Text = "High Altitude (25000 ft)";
		((ButtonBase)RB_HighAltitude36000).BackColor = Color.Transparent;
		((Control)RB_HighAltitude36000).Cursor = Cursors.Hand;
		((Control)RB_HighAltitude36000).Font = new Font("Segoe UI", 9f);
		((Control)RB_HighAltitude36000).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)RB_HighAltitude36000).Location = new Point(6, 39);
		((Control)RB_HighAltitude36000).Name = "RB_HighAltitude36000";
		((Control)RB_HighAltitude36000).Size = new Size(200, 21);
		((Control)RB_HighAltitude36000).TabIndex = 1;
		((ButtonBase)RB_HighAltitude36000).Text = "High Altitude (36000 ft)";
		((ButtonBase)RB_MaxAltitude).BackColor = Color.Transparent;
		((Control)RB_MaxAltitude).Cursor = Cursors.Hand;
		((Control)RB_MaxAltitude).Font = new Font("Segoe UI", 9f);
		((Control)RB_MaxAltitude).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)RB_MaxAltitude).Location = new Point(6, 17);
		((Control)RB_MaxAltitude).Name = "RB_MaxAltitude";
		((Control)RB_MaxAltitude).Size = new Size(200, 21);
		((Control)RB_MaxAltitude).TabIndex = 0;
		((ButtonBase)RB_MaxAltitude).Text = "Max Altitude";
		((Control)GroupBox_SubDepthPreset).Controls.Add((Control)(object)RB_NoDepthPreset);
		((Control)GroupBox_SubDepthPreset).Controls.Add((Control)(object)RB_Surface);
		((Control)GroupBox_SubDepthPreset).Controls.Add((Control)(object)RB_Shallow);
		((Control)GroupBox_SubDepthPreset).Controls.Add((Control)(object)RB_MaxDepth);
		((Control)GroupBox_SubDepthPreset).Controls.Add((Control)(object)RB_UnderLayer);
		((Control)GroupBox_SubDepthPreset).Controls.Add((Control)(object)RB_OverLayer);
		((Control)GroupBox_SubDepthPreset).Controls.Add((Control)(object)RB_Periscope);
		((Control)GroupBox_SubDepthPreset).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroupBox_SubDepthPreset).Location = new Point(3, 202);
		((Control)GroupBox_SubDepthPreset).Name = "GroupBox_SubDepthPreset";
		((Control)GroupBox_SubDepthPreset).Size = new Size(210, 193);
		((Control)GroupBox_SubDepthPreset).TabIndex = 17;
		((GroupBox)GroupBox_SubDepthPreset).TabStop = false;
		((GroupBox)GroupBox_SubDepthPreset).Text = "Depth Presets";
		((ButtonBase)RB_NoDepthPreset).BackColor = Color.Transparent;
		((Control)RB_NoDepthPreset).Cursor = Cursors.Hand;
		((Control)RB_NoDepthPreset).Font = new Font("Segoe UI", 9f);
		((Control)RB_NoDepthPreset).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)RB_NoDepthPreset).Location = new Point(6, 151);
		((Control)RB_NoDepthPreset).Name = "RB_NoDepthPreset";
		((Control)RB_NoDepthPreset).Size = new Size(200, 21);
		((Control)RB_NoDepthPreset).TabIndex = 7;
		((ButtonBase)RB_NoDepthPreset).Text = "None";
		((ButtonBase)RB_Surface).BackColor = Color.Transparent;
		((Control)RB_Surface).Cursor = Cursors.Hand;
		((Control)RB_Surface).Font = new Font("Segoe UI", 9f);
		((Control)RB_Surface).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)RB_Surface).Location = new Point(6, 19);
		((Control)RB_Surface).Name = "RB_Surface";
		((Control)RB_Surface).Size = new Size(200, 21);
		((Control)RB_Surface).TabIndex = 18;
		((ButtonBase)RB_Surface).Text = "Surface";
		((ButtonBase)RB_Shallow).BackColor = Color.Transparent;
		((Control)RB_Shallow).Cursor = Cursors.Hand;
		((Control)RB_Shallow).Font = new Font("Segoe UI", 9f);
		((Control)RB_Shallow).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)RB_Shallow).Location = new Point(6, 63);
		((Control)RB_Shallow).Name = "RB_Shallow";
		((Control)RB_Shallow).Size = new Size(200, 21);
		((Control)RB_Shallow).TabIndex = 4;
		((ButtonBase)RB_Shallow).Text = "Shallow";
		((ButtonBase)RB_MaxDepth).BackColor = Color.Transparent;
		((Control)RB_MaxDepth).Cursor = Cursors.Hand;
		((Control)RB_MaxDepth).Font = new Font("Segoe UI", 9f);
		((Control)RB_MaxDepth).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)RB_MaxDepth).Location = new Point(6, 129);
		((Control)RB_MaxDepth).Name = "RB_MaxDepth";
		((Control)RB_MaxDepth).Size = new Size(200, 21);
		((Control)RB_MaxDepth).TabIndex = 3;
		((ButtonBase)RB_MaxDepth).Text = "As deep as possible";
		((ButtonBase)RB_UnderLayer).BackColor = Color.Transparent;
		((Control)RB_UnderLayer).Cursor = Cursors.Hand;
		((Control)RB_UnderLayer).Font = new Font("Segoe UI", 9f);
		((Control)RB_UnderLayer).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)RB_UnderLayer).Location = new Point(6, 107);
		((Control)RB_UnderLayer).Name = "RB_UnderLayer";
		((Control)RB_UnderLayer).Size = new Size(200, 21);
		((Control)RB_UnderLayer).TabIndex = 2;
		((ButtonBase)RB_UnderLayer).Text = "Just under the layer";
		((ButtonBase)RB_OverLayer).BackColor = Color.Transparent;
		((Control)RB_OverLayer).Cursor = Cursors.Hand;
		((Control)RB_OverLayer).Font = new Font("Segoe UI", 9f);
		((Control)RB_OverLayer).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)RB_OverLayer).Location = new Point(6, 85);
		((Control)RB_OverLayer).Name = "RB_OverLayer";
		((Control)RB_OverLayer).Size = new Size(200, 21);
		((Control)RB_OverLayer).TabIndex = 1;
		((ButtonBase)RB_OverLayer).Text = "Just over the layer";
		((ButtonBase)RB_Periscope).BackColor = Color.Transparent;
		((Control)RB_Periscope).Cursor = Cursors.Hand;
		((Control)RB_Periscope).Font = new Font("Segoe UI", 9f);
		((Control)RB_Periscope).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)RB_Periscope).Location = new Point(6, 41);
		((Control)RB_Periscope).Name = "RB_Periscope";
		((Control)RB_Periscope).Size = new Size(200, 21);
		((Control)RB_Periscope).TabIndex = 0;
		((ButtonBase)RB_Periscope).Text = "Periscope depth";
		Label_Altitude.AutoSize = true;
		((Control)Label_Altitude).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_Altitude).Location = new Point(188, 21);
		((Control)Label_Altitude).Name = "Label_Altitude";
		((Control)Label_Altitude).Size = new Size(104, 20);
		((Control)Label_Altitude).TabIndex = 23;
		((Label)Label_Altitude).Text = "Label_Altitude";
		TextBox_EnterAltitude.AutoCompleteCustomSource = null;
		TextBox_EnterAltitude.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox_EnterAltitude.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox_EnterAltitude).BackColor = Color.Transparent;
		TextBox_EnterAltitude.Font = new Font("Segoe UI", 8f);
		((Control)TextBox_EnterAltitude).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_EnterAltitude.Image = null;
		TextBox_EnterAltitude.Lines = null;
		((Control)TextBox_EnterAltitude).Location = new Point(119, 17);
		TextBox_EnterAltitude.MaxLength = 32767;
		TextBox_EnterAltitude.Multiline = false;
		((Control)TextBox_EnterAltitude).Name = "TextBox_EnterAltitude";
		TextBox_EnterAltitude.ReadOnly = false;
		TextBox_EnterAltitude.ScrollBars = (ScrollBars)0;
		TextBox_EnterAltitude.SelectionStart = 0;
		((Control)TextBox_EnterAltitude).Size = new Size(60, 20);
		((Control)TextBox_EnterAltitude).TabIndex = 20;
		TextBox_EnterAltitude.TextAlign = (HorizontalAlignment)0;
		TextBox_EnterAltitude.UseSystemPasswordChar = false;
		TextBox_EnterAltitude.WatermarkText = "";
		TextBox_EnterAltitude.WordWrap = false;
		((ButtonBase)CB_AltOverride).AutoSize = true;
		((Control)CB_AltOverride).Location = new Point(9, 20);
		((Control)CB_AltOverride).Name = "CB_AltOverride";
		((Control)CB_AltOverride).Size = new Size(141, 24);
		((Control)CB_AltOverride).TabIndex = 16;
		((ButtonBase)CB_AltOverride).Text = "Manual Override";
		Label6.AutoSize = true;
		((Control)Label6).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label6).Location = new Point(5, 43);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(120, 20);
		((Control)Label6).TabIndex = 10;
		((Label)Label6).Text = "Desired Altitude:";
		TrackBar_Altitude.LargeChange = 10;
		((Control)TrackBar_Altitude).Location = new Point(287, 9);
		((Control)TrackBar_Altitude).Name = "TrackBar_Altitude";
		TrackBar_Altitude.Orientation = (Orientation)1;
		((Control)TrackBar_Altitude).RightToLeft = (RightToLeft)0;
		((Control)TrackBar_Altitude).Size = new Size(56, 272);
		TrackBar_Altitude.SmallChange = 5;
		((Control)TrackBar_Altitude).TabIndex = 9;
		TrackBar_Altitude.TickFrequency = 305;
		Label_CurrentAlt.AutoSize = true;
		((Control)Label_CurrentAlt).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_CurrentAlt).Location = new Point(109, 61);
		((Control)Label_CurrentAlt).Name = "Label_CurrentAlt";
		((Control)Label_CurrentAlt).Size = new Size(76, 20);
		((Control)Label_CurrentAlt).TabIndex = 15;
		((Label)Label_CurrentAlt).Text = "CurrentAlt";
		Label5.AutoSize = true;
		((Control)Label5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label5).Location = new Point(5, 61);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(117, 20);
		((Control)Label5).TabIndex = 11;
		((Label)Label5).Text = "Current Altitude:";
		((Control)ShapeContainer1).Location = new Point(3, 23);
		((Control)ShapeContainer1).Margin = new Padding(0);
		((Control)ShapeContainer1).Name = "ShapeContainer1";
		ShapeContainer1.Shapes.AddRange(new Shape[2] { LineShape2, LineShape1 });
		((Control)ShapeContainer1).Size = new Size(403, 277);
		((Control)ShapeContainer1).TabIndex = 43;
		((Control)ShapeContainer1).TabStop = false;
		LineShape2.BorderColor = Color.FromArgb(64, 64, 64);
		LineShape2.BorderWidth = 3;
		LineShape2.Name = "LineShape2";
		LineShape2.X1 = 256;
		LineShape2.X2 = 256;
		LineShape2.Y1 = 33;
		LineShape2.Y2 = 179;
		LineShape1.BorderColor = Color.FromArgb(64, 64, 64);
		LineShape1.BorderWidth = 3;
		LineShape1.Name = "LineShape1";
		LineShape1.X1 = 256;
		LineShape1.X2 = 256;
		LineShape1.Y1 = 70;
		LineShape1.Y2 = 216;
		EventActionLabel.AutoSize = true;
		((Control)EventActionLabel).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)EventActionLabel).Location = new Point(7, 133);
		((Control)EventActionLabel).Name = "EventActionLabel";
		((Control)EventActionLabel).Size = new Size(55, 20);
		((Control)EventActionLabel).TabIndex = 22;
		((Label)EventActionLabel).Text = "Action:";
		((Control)EventActionLabel).Visible = false;
		((ComboBox)CB_EventAction).BackColor = Color.Transparent;
		((ComboBox)CB_EventAction).DrawMode = (DrawMode)1;
		((ComboBox)CB_EventAction).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_EventAction).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_EventAction).FormattingEnabled = true;
		((Control)CB_EventAction).Location = new Point(76, 129);
		((Control)CB_EventAction).Name = "CB_EventAction";
		((Control)CB_EventAction).Size = new Size(325, 24);
		((Control)CB_EventAction).TabIndex = 23;
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(419, 693);
		((Control)this).Controls.Add((Control)(object)FlowLayoutPanel2);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Form)this).Location = new Point(0, 0);
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Form)this).MinimumSize = new Size(435, 150);
		((Control)this).Name = "SpeedAlt";
		((Form)this).ShowIcon = false;
		((Form)this).SizeGripStyle = (SizeGripStyle)1;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Throttle & Altitude for:";
		((Control)FlowLayoutPanel2).ResumeLayout(false);
		((Control)FlowLayoutPanel_SettingsFor).ResumeLayout(false);
		((Control)FlowLayoutPanel_SettingsFor).PerformLayout();
		((Control)GroupBox_Waypoint).ResumeLayout(false);
		((Control)GroupBox_Waypoint).PerformLayout();
		((Control)GroupBox_Speed).ResumeLayout(false);
		((Control)GroupBox_Speed).PerformLayout();
		((Control)GroupBox_SpeedPresets).ResumeLayout(false);
		((ISupportInitialize)TrackBar_Throttle).EndInit();
		((Control)GroupBox_Altitude).ResumeLayout(false);
		((Control)GroupBox_Altitude).PerformLayout();
		((ISupportInitialize)CloudLowTopPictureBox).EndInit();
		((ISupportInitialize)CloudLowBottomPictureBox).EndInit();
		((ISupportInitialize)CloudHighBottomPictureBox).EndInit();
		((ISupportInitialize)GroundLevelPictureBox).EndInit();
		((ISupportInitialize)CloudHighTopPictureBox).EndInit();
		((ISupportInitialize)SeaFloorPictureBox).EndInit();
		((ISupportInitialize)LayerBottomPictureBox).EndInit();
		((ISupportInitialize)LayerTopPictureBox).EndInit();
		((Control)FlowLayoutPanel_Presets).ResumeLayout(false);
		((Control)GroupBox_AltitudePresets).ResumeLayout(false);
		((Control)GroupBox_SubDepthPreset).ResumeLayout(false);
		((ISupportInitialize)TrackBar_Altitude).EndInit();
		((Control)this).ResumeLayout(false);
	}

	private void method_2()
	{
		((RadioButton)RB_MaxAltitude).Checked = false;
		((RadioButton)RB_HighAltitude36000).Checked = false;
		((RadioButton)RB_HighAltitude25000).Checked = false;
		((RadioButton)RB_MediumAltitude12000).Checked = false;
		((RadioButton)RB_LowAltitude2000).Checked = false;
		((RadioButton)RB_LowAltitude1000).Checked = false;
		((RadioButton)RB_MinAltitude).Checked = false;
	}

	private void method_3()
	{
		((RadioButton)RB_Surface).Checked = false;
		((RadioButton)RB_Periscope).Checked = false;
		((RadioButton)RB_Shallow).Checked = false;
		((RadioButton)RB_OverLayer).Checked = false;
		((RadioButton)RB_UnderLayer).Checked = false;
		((RadioButton)RB_MaxDepth).Checked = false;
	}

	private void method_4()
	{
		((RadioButton)RB_Stop).Checked = false;
		((RadioButton)RB_Creep).Checked = false;
		((RadioButton)RB_Cruise).Checked = false;
		((RadioButton)RB_Full).Checked = false;
		((RadioButton)RB_Flank).Checked = false;
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Invalid comparison between Unknown and I4
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		if ((int)keyData == 13 && ((object)((ContainerControl)this).ActiveControl.Parent == TextBox_EnterAltitude || (object)((ContainerControl)this).ActiveControl.Parent == TextBox_EnterSpeed))
		{
			SendKeys.Send("{TAB}");
		}
		Keys[] array = keys_2;
		int num = 0;
		while (true)
		{
			if (num < array.Length)
			{
				Keys val = array[num];
				if (keyData == val)
				{
					break;
				}
				num = checked(num + 1);
				continue;
			}
			if (keyData == keys_0.First())
			{
				Button_Next_Click(null, null);
				return true;
			}
			if (keyData == keys_1.First())
			{
				Button_Previous_Click(null, null);
				return true;
			}
			return false;
		}
		int result;
		if (!((Control)this).Visible)
		{
			((Form)this).Activate();
			result = 1;
		}
		else
		{
			((Form)this).Close();
			result = 1;
		}
		return (byte)result != 0;
	}

	private void SpeedAlt_Load(object sender, EventArgs e)
	{
		bool_7 = Client.Realtime;
		LoadForm();
		Timer1.Interval = 250;
		Timer1.Start();
	}

	public void LoadForm()
	{
		try
		{
			RefreshForm(RefreshEvenIfNotVisible: true);
			bool_6 = false;
			if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
			{
				((Label)Label_Altitude).Text = "ft";
			}
			else
			{
				((Label)Label_Altitude).Text = "m";
				((ButtonBase)RB_HighAltitude36000).Text = "High Altitude (10973 m)";
				((ButtonBase)RB_HighAltitude25000).Text = "High Altitude (7620 m)";
				((ButtonBase)RB_MediumAltitude12000).Text = "Medium Altitude (3658 m)";
				((ButtonBase)RB_LowAltitude2000).Text = "Low Altitude (610 m)";
				((ButtonBase)RB_LowAltitude1000).Text = "Low Altitude (305 m)";
			}
			if (!Information.IsNothing((object)SpeedAlt_SelectedUnit))
			{
				if (!SpeedAlt_SelectedUnit.UseAerialUnitUI)
				{
					((ButtonBase)RB_Stop).Text = "Stop";
					((ButtonBase)RB_Creep).Text = "Creep";
					((ButtonBase)RB_Full).Text = "Full";
					((ButtonBase)RB_Flank).Text = "Flank";
				}
				else
				{
					((ButtonBase)RB_Stop).Text = "Hover";
					((ButtonBase)RB_Creep).Text = "Loiter";
					((ButtonBase)RB_Full).Text = "Military";
					((ButtonBase)RB_Flank).Text = "Afterburner";
				}
			}
			else if (!Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint))
			{
				((ButtonBase)RB_Stop).Text = "Hover";
				((ButtonBase)RB_Creep).Text = "Loiter";
				((ButtonBase)RB_Full).Text = "Military";
				((ButtonBase)RB_Flank).Text = "Afterburner";
			}
			((Control)Label_Altitude).Visible = false;
			((Control)TextBox_EnterAltitude).Visible = false;
			((Control)CB_AltOverride).Visible = false;
			((Control)Label5).Visible = false;
			((Control)Label6).Visible = false;
			((Control)Label_DesiredAlt).Visible = false;
			((Control)Label_CurrentAlt).Visible = false;
			((Control)Label3).Visible = true;
			((Control)Label_ActualSpeed).Visible = true;
			((Control)RB_HighAltitude36000).Enabled = true;
			((Control)RB_HighAltitude25000).Enabled = true;
			((Control)RB_MediumAltitude12000).Enabled = true;
			((Control)RB_LowAltitude2000).Enabled = true;
			((Control)RB_LowAltitude1000).Enabled = true;
			((Control)RB_Periscope).Enabled = true;
			((Control)RB_Shallow).Enabled = true;
			((Control)RB_OverLayer).Enabled = true;
			((Control)RB_UnderLayer).Enabled = true;
			((Control)RB_Stop).Enabled = true;
			((Control)CB_TerrainFollowing).Enabled = true;
			((Control)CB_WaypointType).Enabled = false;
			((Control)TextBox_WaypointDescription).Enabled = false;
			float maximumAltitude = default(float);
			float minimumAltitude = default(float);
			if (!Information.IsNothing((object)SpeedAlt_SelectedUnit))
			{
				maximumAltitude = SpeedAlt_SelectedUnit.Kinematics.GetMaximumAltitude();
				minimumAltitude = SpeedAlt_SelectedUnit.Kinematics.GetMinimumAltitude();
			}
			if (TrackBar_Altitude.Maximum != (int)Math.Round(maximumAltitude))
			{
				TrackBar_Altitude.Maximum = (int)Math.Round(maximumAltitude);
			}
			TrackBar_Altitude.Minimum = (int)Math.Round(minimumAltitude);
			if (!Information.IsNothing((object)SpeedAlt_SelectedUnit))
			{
				if (SpeedAlt_SelectedUnit.UseAerialUnitUI)
				{
					if (maximumAltitude * 3.28084f < 36000f)
					{
						((Control)RB_HighAltitude36000).Enabled = false;
					}
					if (maximumAltitude * 3.28084f < 25000f)
					{
						((Control)RB_HighAltitude25000).Enabled = false;
					}
					if (maximumAltitude * 3.28084f < 12000f)
					{
						((Control)RB_MediumAltitude12000).Enabled = false;
					}
					if (maximumAltitude * 3.28084f < 2000f)
					{
						((Control)RB_LowAltitude2000).Enabled = false;
					}
					if (maximumAltitude * 3.28084f < 1000f)
					{
						((Control)RB_LowAltitude1000).Enabled = false;
					}
				}
				else if (SpeedAlt_SelectedUnit.IsSubmarine || (SpeedAlt_SelectedUnit.IsGroup && ((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.SubGroup))
				{
					if (minimumAltitude > -20f)
					{
						((Control)RB_Periscope).Enabled = false;
					}
					if (minimumAltitude > -40f)
					{
						((Control)RB_Shallow).Enabled = false;
					}
					if ((minimumAltitude > Submarine_AI.OverLayerDepth(SpeedAlt_SelectedUnit) && SpeedAlt_SelectedUnit.IsSubmarine) | (minimumAltitude > Group_AI.OverLayerDepth(SpeedAlt_SelectedUnit) && SpeedAlt_SelectedUnit.IsGroup))
					{
						((Control)RB_OverLayer).Enabled = false;
					}
					if ((minimumAltitude > Submarine_AI.UnderLayerDepth(SpeedAlt_SelectedUnit) && SpeedAlt_SelectedUnit.IsSubmarine) | (minimumAltitude > Group_AI.UnderLayerDepth(SpeedAlt_SelectedUnit) && SpeedAlt_SelectedUnit.IsGroup))
					{
						((Control)RB_UnderLayer).Enabled = false;
					}
				}
			}
			if (Information.IsNothing((object)Client.SelectedWaypoint) && Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint))
			{
				if (!Information.IsNothing((object)SpeedAlt_SelectedUnit))
				{
					if (!SpeedAlt_SelectedUnit.IsSubmarine)
					{
						if (SpeedAlt_SelectedUnit.IsGroup && ((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.SubGroup)
						{
							((Control)GroupBox_SubDepthPreset).Visible = true;
							((Control)GroupBox_SubDepthPreset).Enabled = true;
						}
						else
						{
							((Control)GroupBox_SubDepthPreset).Visible = false;
							((Control)GroupBox_SubDepthPreset).Enabled = false;
						}
					}
					else
					{
						((Control)GroupBox_SubDepthPreset).Visible = true;
						((Control)GroupBox_SubDepthPreset).Enabled = true;
					}
					if (!SpeedAlt_SelectedUnit.UseAerialUnitUI)
					{
						((Control)GroupBox_AltitudePresets).Visible = false;
						((Control)GroupBox_AltitudePresets).Enabled = false;
						((Control)CB_TerrainFollowing).Enabled = false;
					}
					else
					{
						((Control)GroupBox_AltitudePresets).Visible = true;
						((Control)GroupBox_AltitudePresets).Enabled = true;
						((Control)CB_TerrainFollowing).Enabled = true;
					}
					if (SpeedAlt_SelectedUnit.IsFacility)
					{
						TrackBar_Throttle.Minimum = 0;
						int maximumSpeed = SpeedAlt_SelectedUnit.Kinematics.GetMaximumSpeed();
						if (TrackBar_Throttle.Maximum != maximumSpeed)
						{
							TrackBar_Throttle.Maximum = maximumSpeed;
						}
						if (SpeedAlt_SelectedUnit.DesiredSpeed > (float)TrackBar_Throttle.Maximum)
						{
							TrackBar_Throttle.Value = TrackBar_Throttle.Maximum;
						}
						else
						{
							TrackBar_Throttle.Value = (int)Math.Round(SpeedAlt_SelectedUnit.DesiredSpeed);
						}
					}
					else if (SpeedAlt_SelectedUnit.SupportsAltitude_Control)
					{
						((Control)Label_Altitude).Visible = true;
						((Control)TextBox_EnterAltitude).Visible = true;
						((Control)Label_DesiredAlt).Visible = true;
						((Control)Label_CurrentAlt).Visible = true;
						((Control)CB_AltOverride).Visible = true;
						((Control)Label5).Visible = true;
						((Control)Label6).Visible = true;
						if (!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
						{
							((Label)Label_MaxAlt).Text = Conversions.ToString(maximumAltitude) + " m";
							((Label)Label_MinAlt).Text = Conversions.ToString(minimumAltitude) + " m";
						}
						else
						{
							((Label)Label_MaxAlt).Text = Conversions.ToString((int)Math.Round(maximumAltitude * 3.28084f)) + " ft";
							((Label)Label_MinAlt).Text = Conversions.ToString((int)Math.Round(minimumAltitude * 3.28084f)) + " ft";
						}
					}
					((Control)RB_NoThrottlePreset).Visible = false;
					((Control)RB_NoDepthPreset).Visible = false;
					((Control)RB_NoAltitudePreset).Visible = false;
					if (SpeedAlt_SelectedUnit.IsWeapon && ((Weapon)SpeedAlt_SelectedUnit).Flags.TerrainFollowing)
					{
						((Control)CB_TerrainFollowing).Enabled = true;
					}
				}
			}
			else
			{
				method_3();
				method_2();
				method_4();
				((RadioButton)RB_NoThrottlePreset).Checked = false;
				((RadioButton)RB_NoDepthPreset).Checked = false;
				((RadioButton)RB_NoAltitudePreset).Checked = false;
				if (!Information.IsNothing((object)SpeedAlt_SelectedUnit))
				{
					if (SpeedAlt_SelectedUnit.IsFacility)
					{
						((Control)Label_Altitude).Visible = false;
						((Control)TextBox_EnterAltitude).Visible = false;
					}
					else if (!SpeedAlt_SelectedUnit.SupportsAltitude_Control)
					{
						((Control)Label_Altitude).Visible = false;
						((Control)TextBox_EnterAltitude).Visible = false;
					}
					else
					{
						((Control)Label_Altitude).Visible = true;
						((Control)TextBox_EnterAltitude).Visible = true;
					}
				}
				if (!bool_7)
				{
					((Control)TextBox_WaypointDescription).Enabled = true;
				}
				Waypoint waypoint = null;
				waypoint = ((Information.IsNothing((object)Client.SelectedWaypoint) || !Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint)) ? SpeedAlt_FlightPlanWaypoint : Client.SelectedWaypoint);
				if (waypoint != null)
				{
					switch (waypoint.ThrottlePreset)
					{
					case ActiveUnit_Kinematics.UnitThrottlePreset.FullStop:
						((RadioButton)RB_Stop).Checked = true;
						break;
					case ActiveUnit_Kinematics.UnitThrottlePreset.Loiter:
						((RadioButton)RB_Creep).Checked = true;
						break;
					case ActiveUnit_Kinematics.UnitThrottlePreset.Cruise:
						((RadioButton)RB_Cruise).Checked = true;
						break;
					case ActiveUnit_Kinematics.UnitThrottlePreset.Full:
						((RadioButton)RB_Full).Checked = true;
						break;
					case ActiveUnit_Kinematics.UnitThrottlePreset.Flank:
						((RadioButton)RB_Flank).Checked = true;
						break;
					}
					switch (waypoint.AltitudePreset)
					{
					case ActiveUnit_AI.AircraftAltitudePreset.MinAltitude:
						((RadioButton)RB_MinAltitude).Checked = true;
						break;
					case ActiveUnit_AI.AircraftAltitudePreset.Low1000:
						((RadioButton)RB_LowAltitude1000).Checked = true;
						break;
					case ActiveUnit_AI.AircraftAltitudePreset.Low2000:
						((RadioButton)RB_LowAltitude2000).Checked = true;
						break;
					case ActiveUnit_AI.AircraftAltitudePreset.const_4:
						((RadioButton)RB_MediumAltitude12000).Checked = true;
						break;
					case ActiveUnit_AI.AircraftAltitudePreset.const_5:
						((RadioButton)RB_HighAltitude25000).Checked = true;
						break;
					case ActiveUnit_AI.AircraftAltitudePreset.const_6:
						((RadioButton)RB_HighAltitude36000).Checked = true;
						break;
					case ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude:
						((RadioButton)RB_MaxAltitude).Checked = true;
						break;
					}
					switch (waypoint.DepthPreset)
					{
					case ActiveUnit_AI.SubmarineDepthPreset.Periscope:
						((RadioButton)RB_Periscope).Checked = true;
						break;
					case ActiveUnit_AI.SubmarineDepthPreset.Shallow:
						((RadioButton)RB_Shallow).Checked = true;
						break;
					case ActiveUnit_AI.SubmarineDepthPreset.OverLayer:
						((RadioButton)RB_OverLayer).Checked = true;
						break;
					case ActiveUnit_AI.SubmarineDepthPreset.UnderLayer:
						((RadioButton)RB_UnderLayer).Checked = true;
						break;
					case ActiveUnit_AI.SubmarineDepthPreset.MaxDepth:
						((RadioButton)RB_MaxDepth).Checked = true;
						break;
					case ActiveUnit_AI.SubmarineDepthPreset.Surface:
						((RadioButton)RB_Surface).Checked = true;
						break;
					}
				}
				if (!Information.IsNothing((object)SpeedAlt_SelectedUnit))
				{
					if (SpeedAlt_SelectedUnit.SupportsAltitude_Control)
					{
						((Control)Label6).Visible = true;
						((Control)Label_DesiredAlt).Visible = true;
						((Control)Label_CurrentAlt).Visible = true;
						((Control)Label_Altitude).Visible = true;
						((Control)TextBox_EnterAltitude).Visible = true;
						((Control)CB_AltOverride).Visible = true;
						((Control)Label5).Visible = true;
						((Control)Label6).Visible = true;
					}
				}
				else if (!Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint))
				{
					((Control)Label6).Visible = true;
					((Control)Label_DesiredAlt).Visible = true;
					((Control)Label_Altitude).Visible = true;
					((Control)TextBox_EnterAltitude).Visible = true;
					((Control)CB_AltOverride).Visible = true;
					((Control)Label6).Visible = true;
					((Control)Label3).Visible = false;
					((Control)Label_ActualSpeed).Visible = false;
				}
				if (Information.IsNothing((object)waypoint.DesiredSpeedOverride))
				{
					if (waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None)
					{
						((Control)RB_NoThrottlePreset).Visible = true;
					}
					else
					{
						((Control)RB_NoThrottlePreset).Visible = false;
					}
				}
				else
				{
					((Control)RB_NoThrottlePreset).Visible = false;
				}
				((Control)RB_NoDepthPreset).Visible = false;
				((Control)RB_NoAltitudePreset).Visible = false;
				if (Information.IsNothing((object)SpeedAlt_SelectedUnit))
				{
					if (!Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint))
					{
						((Control)GroupBox_SubDepthPreset).Visible = false;
						((Control)GroupBox_SubDepthPreset).Enabled = false;
					}
				}
				else if (!SpeedAlt_SelectedUnit.IsSubmarine && (!SpeedAlt_SelectedUnit.IsGroup || ((Group)SpeedAlt_SelectedUnit).Type != Group.GroupType.SubGroup))
				{
					((Control)GroupBox_SubDepthPreset).Visible = false;
					((Control)GroupBox_SubDepthPreset).Enabled = false;
				}
				else
				{
					((Control)GroupBox_SubDepthPreset).Visible = true;
					((Control)GroupBox_SubDepthPreset).Enabled = true;
				}
				if (Information.IsNothing((object)SpeedAlt_SelectedUnit))
				{
					if (SpeedAlt_FlightPlanWaypoint != null)
					{
						((Control)GroupBox_AltitudePresets).Visible = true;
						((Control)GroupBox_AltitudePresets).Enabled = true;
					}
				}
				else if (!SpeedAlt_SelectedUnit.UseAerialUnitUI)
				{
					((Control)GroupBox_AltitudePresets).Visible = false;
					((Control)GroupBox_AltitudePresets).Enabled = false;
				}
				else
				{
					((Control)GroupBox_AltitudePresets).Visible = true;
					((Control)GroupBox_AltitudePresets).Enabled = true;
					if (SpeedAlt_SelectedUnit.IsAircraft && !((Aircraft)SpeedAlt_SelectedUnit).get_CanHover(bool_7: false))
					{
						((Control)RB_Stop).Enabled = false;
					}
					if (SpeedAlt_SelectedUnit.IsGroup)
					{
						if (Information.IsNothing((object)((Group)SpeedAlt_SelectedUnit).GroupLead))
						{
							return;
						}
						if (!((Aircraft)((Group)SpeedAlt_SelectedUnit).GroupLead).get_CanHover(bool_7: false))
						{
							((Control)RB_Stop).Enabled = false;
						}
					}
					((Control)CB_TerrainFollowing).Enabled = true;
				}
				if (!Information.IsNothing((object)SpeedAlt_SelectedUnit) && SpeedAlt_SelectedUnit.IsWeapon)
				{
					Weapon weapon = (Weapon)SpeedAlt_SelectedUnit;
					((Control)RB_Stop).Enabled = false;
					((Control)RB_Creep).Enabled = weapon.Kinematics.CanApplyLoiterThrottle();
					if (weapon.Flags.TerrainFollowing)
					{
						((Control)CB_TerrainFollowing).Enabled = true;
					}
				}
				((ComboBox)CB_EventAction).BeginUpdate();
				((ComboBox)CB_EventAction).Items.Clear();
				((ComboBox)CB_EventAction).Items.Add((object)"None");
				foreach (EventAction value in Client.CurrentScenario.EventActions.Values)
				{
					if (value.Type == EventAction.EventActionType.LuaScript)
					{
						((ComboBox)CB_EventAction).Items.Add((object)value.Description);
						if (!string.IsNullOrEmpty(Client.SelectedWaypoint.EventActionID) && Operators.CompareString(value.ObjectID, Client.SelectedWaypoint.EventActionID, true) == 0)
						{
							((ComboBox)CB_EventAction).SelectedItem = value.Description;
						}
					}
				}
				((ComboBox)CB_EventAction).EndUpdate();
			}
			if (SpeedAlt_SelectedUnit != null && SpeedAlt_SelectedUnit.IsAircraft && !((Aircraft)SpeedAlt_SelectedUnit).get_CanHover(bool_7: false))
			{
				((Control)RB_Stop).Enabled = false;
			}
			if (!bool_8)
			{
				Client.SelectedUnitPreChange += HandleSelectedObjectChanged;
				Client.SelectedWaypointPreChange += HandleSelectedObjectChanged;
				bool_8 = true;
			}
			bool_6 = true;
			((Control)LblWeatherWarning).Visible = false;
			if (SpeedAlt_SelectedUnit != null && SpeedAlt_SelectedUnit.IsShip)
			{
				Ship ship = (Ship)SpeedAlt_SelectedUnit;
				Weather.WeatherProfile weatherProfile = Weather.get_WeatherAtThisTimeAndPlace(ship.ParentScen, ((ActiveUnit)ship).get_Latitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)ship).get_Longitude((GlobalVariables.BooleanObject)null), 0);
				if (ship.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.WeatherAffectsShipSpeed) && ship.Kinematics.GetMaximumSpeed() > Ship_Kinematics.GetMaximumSpeedForThisSeaState(ship, weatherProfile.SeaState))
				{
					((Control)LblWeatherWarning).Visible = true;
					((Label)LblWeatherWarning).Text = "MAX Speed for Sea State " + weatherProfile.SeaState + " : " + Conversions.ToString(Ship_Kinematics.GetMaximumSpeedForThisSeaState(ship, weatherProfile.SeaState)) + " kts";
				}
			}
			MyProject.Forms.MainForm.RightColumnWPF1.WPFControl_AltSpeed.Refresh(TriggeredBySpeedAltForm: true);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void HandleSelectedObjectChanged()
	{
		try
		{
			if (!Information.IsNothing((object)Client.SelectedWaypoint) && Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint))
			{
				method_46(bool_10: false);
				if (bool_3)
				{
					bool_3 = false;
				}
				if (bool_4)
				{
					bool_4 = false;
				}
			}
			else if (!Information.IsNothing((object)Client.SelectedWaypoint) && !Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint))
			{
				method_46(bool_10: false);
				if (bool_3)
				{
					bool_3 = false;
				}
				if (bool_4)
				{
					bool_4 = false;
				}
			}
			else
			{
				if (Information.IsNothing((object)SpeedAlt_SelectedUnit) || !SpeedAlt_SelectedUnit.IsActiveUnit)
				{
					return;
				}
				Side currentSide = Client.CurrentSide;
				ActiveUnit speedAlt_SelectedUnit = SpeedAlt_SelectedUnit;
				string ReasonWhyNot = null;
				if (GameGeneral.CanIssueOrdersToThisUnit(currentSide, speedAlt_SelectedUnit, IncludeSonobuoys: false, ref ReasonWhyNot, Client.CurrentMapProfile.IsolatedPOVObjectID))
				{
					method_46(bool_10: false);
					if (bool_3)
					{
						bool_3 = false;
					}
					if (bool_4)
					{
						bool_4 = false;
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 200636", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ReleaseReferences()
	{
		try
		{
			if (((Control)this).Visible)
			{
				((Form)this).Close();
			}
			SpeedAlt_Flight = null;
			SpeedAlt_FlightPlanWaypoint = null;
			SpeedAlt_Mission = null;
			SpeedAlt_SelectedUnit = null;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public void RefreshForm(bool RefreshEvenIfNotVisible = false)
	{
		//IL_0661: Unknown result type (might be due to invalid IL or missing references)
		//IL_066b: Expected O, but got Unknown
		//IL_0701: Unknown result type (might be due to invalid IL or missing references)
		//IL_070b: Expected O, but got Unknown
		//IL_06b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bc: Expected O, but got Unknown
		bool_7 = Client.Realtime;
		bool_6 = false;
		try
		{
			if (Client.SelectedWaypoint != null)
			{
				((Control)GroupBox_Waypoint).Visible = true;
				if (Client.SelectedUnit != null && Client.SelectedUnit.IsActiveUnit)
				{
					if (SpeedAlt_FlightPlanWaypoint != null)
					{
						if (SpeedAlt_Flight == null)
						{
							((Label)Label_SettingsFor).Text = "";
							Button_Next.Enabled = false;
						}
						else
						{
							Mission.Flight speedAlt_Flight = SpeedAlt_Flight;
							int num = Array.IndexOf(SpeedAlt_Flight.FlightPlan, SpeedAlt_FlightPlanWaypoint);
							((Label)Label_WaypointName).Text = "Waypoint  for " + speedAlt_Flight.Callsign + " (" + speedAlt_Flight.ParentMissionOrPackageName + ")";
							((Label)Label_SettingsFor).Text = "WAYPOINT #" + Conversions.ToString(num + 1);
							if (num == SpeedAlt_Flight.FlightPlan.Count() - 1)
							{
								Button_Next.Enabled = false;
							}
							else
							{
								Button_Next.Enabled = true;
							}
						}
					}
					else
					{
						int num2 = Array.IndexOf(((ActiveUnit)Client.SelectedUnit).Navigator.PlottedCourse, Client.SelectedWaypoint);
						((Label)Label_SettingsFor).Text = "WAYPOINT #" + Conversions.ToString(num2 + 1);
						if (num2 == ((ActiveUnit)Client.SelectedUnit).Navigator.PlottedCourse.Count() - 1)
						{
							Button_Next.Enabled = false;
						}
						else
						{
							Button_Next.Enabled = true;
						}
					}
				}
				else
				{
					((Label)Label_SettingsFor).Text = "WAYPOINT";
				}
				Button_Previous.Enabled = true;
			}
			else
			{
				((Control)GroupBox_Waypoint).Visible = false;
				if (SpeedAlt_FlightPlanWaypoint != null)
				{
					SpeedAlt_FlightPlanWaypoint = null;
					SpeedAlt_Flight = null;
					SpeedAlt_Mission = null;
					((Control)this).Visible = false;
					((Form)this).Close();
				}
				if (Client.SelectedUnit == null)
				{
					((Label)Label_SettingsFor).Text = "Nothing";
					Button_Next.Enabled = false;
					Button_Previous.Enabled = false;
					return;
				}
				if (Client.SelectedUnit.IsGroup)
				{
					((Label)Label_SettingsFor).Text = "GROUP";
				}
				else
				{
					((Label)Label_SettingsFor).Text = "UNIT";
				}
				Button_Next.Enabled = true;
				Button_Previous.Enabled = false;
				if (SpeedAlt_SelectedUnit == null && Client.SelectedUnit.IsActiveUnit)
				{
					SpeedAlt_SelectedUnit = (ActiveUnit)Client.SelectedUnit;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 200637A", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			if (Client.SelectedWaypoint == null)
			{
				if (Client.SelectedUnit == null)
				{
					((Control)CB_AvoidCavitation).Visible = false;
				}
				else
				{
					CB_AvoidCavitation.ThreeState = false;
					((CheckBox)CB_AvoidCavitation).CheckState = (CheckState)1;
					if (!(Client.SelectedUnit.IsShip | Client.SelectedUnit.IsSubmarine))
					{
						if (!Client.SelectedUnit.IsGroup)
						{
							((Control)CB_AvoidCavitation).Visible = false;
						}
						else
						{
							Group obj = (Group)Client.SelectedUnit;
							if (obj.Units.Count > 0 && (obj.Units.Values.ElementAtOrDefault(0).IsShip | obj.Units.Values.ElementAtOrDefault(0).IsSubmarine))
							{
								((Control)CB_AvoidCavitation).Visible = true;
								((CheckBox)CB_AvoidCavitation).Checked = ((ActiveUnit)Client.SelectedUnit).Navigator.AvoidCavitation;
							}
							else
							{
								((Control)CB_AvoidCavitation).Visible = false;
							}
						}
					}
					else
					{
						((Control)CB_AvoidCavitation).Visible = true;
						((CheckBox)CB_AvoidCavitation).Checked = ((ActiveUnit)Client.SelectedUnit).Navigator.AvoidCavitation;
					}
				}
			}
			else
			{
				CB_AvoidCavitation.ThreeState = true;
				if (Client.SelectedUnit != null && (Client.SelectedUnit.IsShip | Client.SelectedUnit.IsSubmarine))
				{
					((Control)CB_AvoidCavitation).Visible = true;
					if (Client.SelectedWaypoint.AvoidCavitation.HasValue)
					{
						((CheckBox)CB_AvoidCavitation).Checked = Client.SelectedWaypoint.AvoidCavitation.Value;
					}
					else
					{
						((CheckBox)CB_AvoidCavitation).CheckState = (CheckState)2;
					}
				}
				else
				{
					((Control)CB_AvoidCavitation).Visible = false;
				}
			}
			if (Client.SelectedWaypoint == null)
			{
				if (Client.SelectedUnit == null)
				{
					((Control)CB_SprintDrift).Visible = false;
				}
				else
				{
					CB_SprintDrift.ThreeState = false;
					((CheckBox)CB_SprintDrift).CheckState = (CheckState)1;
					if (Client.SelectedUnit.IsShip | Client.SelectedUnit.IsSubmarine)
					{
						((Control)CB_SprintDrift).Visible = true;
						((CheckBox)CB_SprintDrift).Checked = ((ActiveUnit)Client.SelectedUnit).Navigator.SprintDrift;
					}
					else
					{
						((Control)CB_SprintDrift).Visible = false;
					}
				}
			}
			else
			{
				CB_SprintDrift.ThreeState = true;
				if (Client.SelectedUnit != null && (Client.SelectedUnit.IsShip | Client.SelectedUnit.IsSubmarine))
				{
					((Control)CB_SprintDrift).Visible = true;
					if (Client.SelectedWaypoint.SprintDrift.HasValue)
					{
						((CheckBox)CB_SprintDrift).Checked = Client.SelectedWaypoint.SprintDrift.Value;
					}
					else
					{
						((CheckBox)CB_SprintDrift).CheckState = (CheckState)2;
					}
				}
				else
				{
					((Control)CB_SprintDrift).Visible = false;
				}
			}
			if (((SpeedAlt_SelectedUnit == null) & (Client.SelectedWaypoint == null) & (SpeedAlt_FlightPlanWaypoint == null)) || (SpeedAlt_SelectedUnit != null && SpeedAlt_SelectedUnit.IsGroup && ((Group)SpeedAlt_SelectedUnit).GroupLead == null))
			{
				return;
			}
			if (Information.IsNothing((object)Client.SelectedWaypoint) && Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint))
			{
				if (!SpeedAlt_SelectedUnit.IsShip && !SpeedAlt_SelectedUnit.IsSubmarine)
				{
					((Control)Label_Cavitation).Visible = false;
				}
				else
				{
					((Control)Label_Cavitation).Visible = true;
					int num3 = SpeedAlt_SelectedUnit.Kinematics.CavitationSpeed(SpeedAlt_SelectedUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
					if (num3 == int.MaxValue)
					{
						((Control)Label_Cavitation).Font = new Font(((Control)Label_Cavitation).Font, (FontStyle)0);
						((Control)Label_Cavitation).ForeColor = Color.LightGray;
						((Label)Label_Cavitation).Text = "Cavitation impossible";
					}
					else if (SpeedAlt_SelectedUnit.CurrentSpeed >= (float)num3)
					{
						((Control)Label_Cavitation).Font = new Font(((Control)Label_Cavitation).Font, (FontStyle)1);
						((Control)Label_Cavitation).ForeColor = Color.IndianRed;
						((Label)Label_Cavitation).Text = "Cavitating!!! (" + Conversions.ToString(num3) + " kts)";
					}
					else
					{
						((Control)Label_Cavitation).Font = new Font(((Control)Label_Cavitation).Font, (FontStyle)0);
						((Control)Label_Cavitation).ForeColor = Color.LightGray;
						((Label)Label_Cavitation).Text = "Cavitation at " + Conversions.ToString(num3) + " kts";
					}
				}
			}
			else
			{
				((Control)Label_Cavitation).Visible = false;
			}
			if (!Information.IsNothing((object)Client.SelectedWaypoint) && Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint))
			{
				if (Operators.CompareString(Client.SelectedWaypoint.Name, "", true) != 0)
				{
					((Form)this).Text = "Throttle & Altitude settings for: " + Client.SelectedWaypoint.Name;
				}
				else
				{
					((Form)this).Text = "Throttle & Altitude settings for: Navigation Waypoint";
				}
			}
			else if (!Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint))
			{
				((Form)this).Text = "Throttle & Altitude settings for: " + SpeedAlt_FlightPlanWaypoint.Name + " (Type: " + Waypoint.get_WaypointTypeString(SpeedAlt_FlightPlanWaypoint.Type) + ")";
			}
			else if (!Information.IsNothing((object)SpeedAlt_SelectedUnit) && SpeedAlt_SelectedUnit.IsActiveUnit)
			{
				((Form)this).Text = "Throttle & Altitude settings for: " + SpeedAlt_SelectedUnit.Name;
			}
			if (Client.SelectedWaypoint != null)
			{
				((Control)EventActionLabel).Visible = true;
				((Control)CB_EventAction).Visible = true;
			}
			else
			{
				((Control)EventActionLabel).Visible = false;
				((Control)CB_EventAction).Visible = false;
			}
			if (!Information.IsNothing((object)SpeedAlt_SelectedUnit))
			{
				ActiveUnit.Throttle minPossibleThrottleSetting = SpeedAlt_SelectedUnit.MinPossibleThrottleSetting;
				ActiveUnit.Throttle maxPossibleThrottleSetting = SpeedAlt_SelectedUnit.MaxPossibleThrottleSetting;
				((Control)RB_Flank).Enabled = maxPossibleThrottleSetting >= ActiveUnit.Throttle.Flank && minPossibleThrottleSetting <= ActiveUnit.Throttle.Flank;
				((Control)RB_Full).Enabled = maxPossibleThrottleSetting >= ActiveUnit.Throttle.Full && minPossibleThrottleSetting <= ActiveUnit.Throttle.Full;
				((Control)RB_Cruise).Enabled = maxPossibleThrottleSetting >= ActiveUnit.Throttle.Cruise && minPossibleThrottleSetting <= ActiveUnit.Throttle.Cruise;
				((Control)RB_Creep).Enabled = maxPossibleThrottleSetting >= ActiveUnit.Throttle.Loiter && minPossibleThrottleSetting <= ActiveUnit.Throttle.Loiter;
				((Control)RB_Stop).Enabled = maxPossibleThrottleSetting >= ActiveUnit.Throttle.FullStop && minPossibleThrottleSetting == ActiveUnit.Throttle.FullStop;
			}
			if (!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
			{
				((Label)Label_MaxAlt).Text = Conversions.ToString(TrackBar_Altitude.Maximum) + " m";
				((Label)Label_MinAlt).Text = Conversions.ToString(TrackBar_Altitude.Minimum) + " m";
			}
			else
			{
				((Label)Label_MaxAlt).Text = Conversions.ToString((int)Math.Round((float)TrackBar_Altitude.Maximum * 3.28084f)) + " ft";
				((Label)Label_MinAlt).Text = Conversions.ToString((int)Math.Round((float)TrackBar_Altitude.Minimum * 3.28084f)) + " ft";
			}
			if (Information.IsNothing((object)Client.SelectedWaypoint) && Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint))
			{
				if (SpeedAlt_SelectedUnit.IsTorpedo && ((Torpedo)SpeedAlt_SelectedUnit).DataLinkParent != null)
				{
					if (!((Control)TrackBar_Altitude).Visible)
					{
						((Control)TrackBar_Altitude).Visible = true;
						((Control)Label_MaxAlt).Visible = true;
						((Control)Label_MinAlt).Visible = true;
					}
				}
				else
				{
					if (!((Control)TrackBar_Throttle).Visible)
					{
						((Control)TrackBar_Throttle).Visible = true;
						((Control)Label_MaxSpeed).Visible = true;
						((Control)Label_MinSpeed).Visible = true;
					}
					if (SpeedAlt_SelectedUnit.SupportsAltitude_Control)
					{
						if (!((Control)TrackBar_Altitude).Visible)
						{
							((Control)TrackBar_Altitude).Visible = true;
							((Control)Label_MaxAlt).Visible = true;
							((Control)Label_MinAlt).Visible = true;
						}
					}
					else if (((Control)TrackBar_Altitude).Visible)
					{
						((Control)TrackBar_Altitude).Visible = false;
						((Control)Label_MaxAlt).Visible = false;
						((Control)Label_MinAlt).Visible = false;
					}
				}
			}
			else
			{
				if (((Control)TrackBar_Throttle).Visible)
				{
					((Control)TrackBar_Throttle).Visible = false;
					((Control)Label_MaxSpeed).Visible = false;
					((Control)Label_MinSpeed).Visible = false;
				}
				if (((Control)TrackBar_Altitude).Visible)
				{
					((Control)TrackBar_Altitude).Visible = false;
					((Control)Label_MaxAlt).Visible = false;
					((Control)Label_MinAlt).Visible = false;
				}
			}
			double num4 = 0.0;
			double num5 = 0.0;
			float num6 = 0f;
			float num7 = 0f;
			float num8 = 0f;
			float num9 = 0f;
			float maximumAltitude = default(float);
			float minimumAltitude = default(float);
			if (!Information.IsNothing((object)SpeedAlt_SelectedUnit))
			{
				maximumAltitude = SpeedAlt_SelectedUnit.Kinematics.GetMaximumAltitude();
				minimumAltitude = SpeedAlt_SelectedUnit.Kinematics.GetMinimumAltitude();
			}
			if (Information.IsNothing((object)Client.SelectedWaypoint) && Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint))
			{
				if (SpeedAlt_SelectedUnit != null)
				{
					int num10 = Math.Max(SpeedAlt_SelectedUnit.Kinematics.GetMaximumSpeed(SpeedAlt_SelectedUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.MaxPossibleThrottle, ValidateAndFixAltitude: false), SpeedAlt_SelectedUnit.Kinematics.GetMaximumSpeed(SpeedAlt_SelectedUnit.DesiredAltitude));
					if (TrackBar_Throttle.Maximum != num10)
					{
						TrackBar_Throttle.Maximum = num10;
					}
					if (SpeedAlt_SelectedUnit.DesiredSpeed > (float)num10)
					{
						SpeedAlt_SelectedUnit.DesiredSpeed = num10;
					}
					if (!SpeedAlt_SelectedUnit.Navigator.SprintDrift)
					{
						((Label)Label2).Text = "Desired Speed:";
						((Control)GroupBox_SpeedPresets).Enabled = true;
					}
					else
					{
						((Label)Label2).Text = "Desired Avg Speed:";
						((Control)GroupBox_SpeedPresets).Enabled = false;
					}
					if (!SpeedAlt_SelectedUnit.IsGroup)
					{
						if (SpeedAlt_SelectedUnit.Navigator.SprintDrift)
						{
							((Label)Label_DesiredSpeed).Text = $"{SpeedAlt_SelectedUnit.Navigator.SprintDrift_AverageSpeed.Value:0} kt";
						}
						else
						{
							((Label)Label_DesiredSpeed).Text = $"{SpeedAlt_SelectedUnit.DesiredSpeed:0} kt";
						}
						((Label)Label_ActualSpeed).Text = $"{SpeedAlt_SelectedUnit.CurrentSpeed:0.0}" + " kt (Throttle: " + method_6() + ")";
					}
					else if (SpeedAlt_SelectedUnit.Navigator.SprintDrift)
					{
						((Label)Label_DesiredSpeed).Text = $"{SpeedAlt_SelectedUnit.Navigator.SprintDrift_AverageSpeed.Value:0} kt";
						((Label)Label_ActualSpeed).Text = $"{SpeedAlt_SelectedUnit.CurrentSpeed:0} kt";
					}
					else
					{
						((Label)Label_DesiredSpeed).Text = $"{SpeedAlt_SelectedUnit.DesiredSpeed:0} kt";
						((Label)Label_ActualSpeed).Text = $"{SpeedAlt_SelectedUnit.CurrentSpeed:0} kt";
					}
					if (SpeedAlt_SelectedUnit.UseAerialUnitUI)
					{
						bool flag;
						float desiredAltitude_AGL;
						if (SpeedAlt_SelectedUnit.IsGroupWingman() && !Information.IsNothing((object)SpeedAlt_SelectedUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead) && !SpeedAlt_SelectedUnit.Kinematics.DesiredAltitudeOverride)
						{
							flag = SpeedAlt_SelectedUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.get_DesiredAltitude_UseTerrainFollowing(SpeedAlt_SelectedUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead);
							desiredAltitude_AGL = SpeedAlt_SelectedUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.DesiredAltitude_AGL;
						}
						else
						{
							flag = SpeedAlt_SelectedUnit.get_DesiredAltitude_UseTerrainFollowing(SpeedAlt_SelectedUnit);
							desiredAltitude_AGL = SpeedAlt_SelectedUnit.DesiredAltitude_AGL;
						}
						if (!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
						{
							if (!flag)
							{
								((Label)Label_DesiredAlt).Text = $"{SpeedAlt_SelectedUnit.DesiredAltitude:0.0}" + " m ASL";
							}
							else
							{
								((Label)Label_DesiredAlt).Text = $"{desiredAltitude_AGL:0.0}" + " m AGL";
							}
							if (Module_Unit.IsOverLand(SpeedAlt_SelectedUnit))
							{
								((Label)Label_CurrentAlt).Text = $"{SpeedAlt_SelectedUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null):0.0}" + " m ASL (" + $"{SpeedAlt_SelectedUnit.CurrentAltitude_AGL:0.0}" + " m AGL)";
							}
							else
							{
								((Label)Label_CurrentAlt).Text = $"{SpeedAlt_SelectedUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null):0.0}" + " m ASL";
							}
						}
						else
						{
							if (!flag)
							{
								((Label)Label_DesiredAlt).Text = $"{SpeedAlt_SelectedUnit.DesiredAltitude * 3.28084f:0}" + " ft ASL";
							}
							else
							{
								((Label)Label_DesiredAlt).Text = $"{desiredAltitude_AGL * 3.28084f:0}" + " ft AGL";
							}
							if (Module_Unit.IsOverLand(SpeedAlt_SelectedUnit))
							{
								((Label)Label_CurrentAlt).Text = $"{SpeedAlt_SelectedUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) * 3.28084f:0}" + " ft ASL (" + $"{SpeedAlt_SelectedUnit.CurrentAltitude_AGL * 3.28084f:0}" + " ft AGL)";
							}
							else
							{
								((Label)Label_CurrentAlt).Text = $"{SpeedAlt_SelectedUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) * 3.28084f:0}" + " ft ASL";
							}
						}
					}
					else if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
					{
						((Label)Label_DesiredAlt).Text = string.Format("{0:0}", SpeedAlt_SelectedUnit.DesiredAltitude * 3.28084f, 0) + " ft";
						((Label)Label_CurrentAlt).Text = string.Format("{0:0}", SpeedAlt_SelectedUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) * 3.28084f, 0) + " ft";
					}
					else
					{
						((Label)Label_DesiredAlt).Text = string.Format("{0:0.0}", SpeedAlt_SelectedUnit.DesiredAltitude, 0) + " m";
						((Label)Label_CurrentAlt).Text = string.Format("{0:0.0}", SpeedAlt_SelectedUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), 0) + " m";
					}
					if (SpeedAlt_SelectedUnit.IsGroup)
					{
						Group obj2 = (Group)SpeedAlt_SelectedUnit;
						if (!Information.IsNothing((object)obj2.GroupLead))
						{
							((CheckBox)CB_TerrainFollowing).Checked = obj2.GroupLead.get_DesiredAltitude_UseTerrainFollowing(obj2.GroupLead);
							method_48();
						}
					}
					else
					{
						((CheckBox)CB_TerrainFollowing).Checked = SpeedAlt_SelectedUnit.get_DesiredAltitude_UseTerrainFollowing(SpeedAlt_SelectedUnit);
						method_48();
					}
					if (!bool_4)
					{
						bool flag2;
						float desiredAltitude_AGL2;
						if (SpeedAlt_SelectedUnit.IsGroupWingman() && !Information.IsNothing((object)SpeedAlt_SelectedUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead) && !SpeedAlt_SelectedUnit.Kinematics.DesiredAltitudeOverride)
						{
							flag2 = SpeedAlt_SelectedUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.get_DesiredAltitude_UseTerrainFollowing(SpeedAlt_SelectedUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead);
							desiredAltitude_AGL2 = SpeedAlt_SelectedUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.DesiredAltitude_AGL;
						}
						else
						{
							flag2 = SpeedAlt_SelectedUnit.get_DesiredAltitude_UseTerrainFollowing(SpeedAlt_SelectedUnit);
							desiredAltitude_AGL2 = SpeedAlt_SelectedUnit.DesiredAltitude_AGL;
						}
						if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
						{
							if (SpeedAlt_SelectedUnit.IsGroup && ((((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.AirGroup) | (((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.SubGroup)))
							{
								if (!flag2)
								{
									TextBox_EnterAltitude.Text = Conversions.ToString((int)Math.Round(SpeedAlt_SelectedUnit.DesiredAltitude * 3.28084f));
								}
								else
								{
									TextBox_EnterAltitude.Text = Conversions.ToString((int)Math.Round(desiredAltitude_AGL2 * 3.28084f));
								}
							}
							else if (SpeedAlt_SelectedUnit.IsAircraft | SpeedAlt_SelectedUnit.IsSubmarine)
							{
								if (!flag2)
								{
									TextBox_EnterAltitude.Text = Conversions.ToString((int)Math.Round(SpeedAlt_SelectedUnit.DesiredAltitude * 3.28084f));
								}
								else
								{
									TextBox_EnterAltitude.Text = Conversions.ToString((int)Math.Round(desiredAltitude_AGL2 * 3.28084f));
								}
							}
						}
						else if (SpeedAlt_SelectedUnit.IsGroup && ((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.AirGroup)
						{
							if (!SpeedAlt_SelectedUnit.get_DesiredAltitude_UseTerrainFollowing(SpeedAlt_SelectedUnit))
							{
								TextBox_EnterAltitude.Text = Conversions.ToString((int)Math.Round(SpeedAlt_SelectedUnit.DesiredAltitude));
							}
							else
							{
								TextBox_EnterAltitude.Text = Conversions.ToString((int)Math.Round(SpeedAlt_SelectedUnit.DesiredAltitude_AGL));
							}
						}
						else if (SpeedAlt_SelectedUnit.IsAircraft | SpeedAlt_SelectedUnit.IsSubmarine)
						{
							if (SpeedAlt_SelectedUnit.get_DesiredAltitude_UseTerrainFollowing(SpeedAlt_SelectedUnit))
							{
								TextBox_EnterAltitude.Text = Conversions.ToString(SpeedAlt_SelectedUnit.DesiredAltitude_AGL);
							}
							else
							{
								TextBox_EnterAltitude.Text = Conversions.ToString(SpeedAlt_SelectedUnit.DesiredAltitude);
							}
						}
						if (!bool_3)
						{
							if (((CheckBox)CB_SprintDrift).Checked & (SpeedAlt_SelectedUnit != null))
							{
								float? sprintDrift_AverageSpeed = SpeedAlt_SelectedUnit.Navigator.SprintDrift_AverageSpeed;
								if (((!sprintDrift_AverageSpeed.HasValue) ? ((bool?)null) : new bool?(sprintDrift_AverageSpeed.GetValueOrDefault() != 0f)) == true)
								{
									TextBox_EnterSpeed.Text = Conversions.ToString(SpeedAlt_SelectedUnit.Navigator.SprintDrift_AverageSpeed.Value);
									goto IL_158b;
								}
							}
							TextBox_EnterSpeed.Text = Conversions.ToString(SpeedAlt_SelectedUnit.DesiredSpeed);
						}
					}
					goto IL_158b;
				}
			}
			else
			{
				Waypoint waypoint = ((Information.IsNothing((object)Client.SelectedWaypoint) || !Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint)) ? SpeedAlt_FlightPlanWaypoint : Client.SelectedWaypoint);
				if (waypoint.SprintDrift == true)
				{
					((Label)Label2).Text = "Desired Avg Speed:";
					((Control)GroupBox_SpeedPresets).Enabled = false;
				}
				else
				{
					((Label)Label2).Text = "Desired Speed:";
					((Control)GroupBox_SpeedPresets).Enabled = true;
				}
				if (!Information.IsNothing((object)waypoint) && !Information.IsNothing((object)waypoint.SprintDrift) && waypoint.SprintDrift == true)
				{
					if (!Information.IsNothing((object)waypoint.SprintDrift_AverageSpeed))
					{
						((Label)Label_DesiredSpeed).Text = $"{waypoint.SprintDrift_AverageSpeed.Value:0} kt";
					}
					else
					{
						((Label)Label_DesiredSpeed).Text = "Avg sprint-drift speed not entered!";
					}
				}
				else if (!waypoint.DesiredSpeedOverride.HasValue)
				{
					((Label)Label_DesiredSpeed).Text = "Not Set";
				}
				else if (Information.IsNothing((object)waypoint.DesiredSpeed))
				{
					if (waypoint.ThrottlePreset == ActiveUnit_Kinematics.UnitThrottlePreset.FullStop)
					{
						((Label)Label_DesiredSpeed).Text = "Full Stop";
					}
					if (waypoint.ThrottlePreset == ActiveUnit_Kinematics.UnitThrottlePreset.Loiter)
					{
						if (SpeedAlt_FlightPlanWaypoint == null && !SpeedAlt_SelectedUnit.UseAerialUnitUI)
						{
							((Label)Label_DesiredSpeed).Text = "Creep";
						}
						else
						{
							((Label)Label_DesiredSpeed).Text = "Loiter";
						}
					}
					if (waypoint.ThrottlePreset == ActiveUnit_Kinematics.UnitThrottlePreset.Cruise)
					{
						((Label)Label_DesiredSpeed).Text = "Cruise";
					}
					if (waypoint.ThrottlePreset == ActiveUnit_Kinematics.UnitThrottlePreset.Full)
					{
						if (SpeedAlt_FlightPlanWaypoint == null && !SpeedAlt_SelectedUnit.UseAerialUnitUI)
						{
							((Label)Label_DesiredSpeed).Text = "Full";
						}
						else
						{
							((Label)Label_DesiredSpeed).Text = "Military";
						}
					}
					if (waypoint.ThrottlePreset == ActiveUnit_Kinematics.UnitThrottlePreset.Flank)
					{
						if (SpeedAlt_FlightPlanWaypoint == null && !SpeedAlt_SelectedUnit.UseAerialUnitUI)
						{
							((Label)Label_DesiredSpeed).Text = "Flank";
						}
						else
						{
							((Label)Label_DesiredSpeed).Text = "Afterburner";
						}
					}
				}
				else
				{
					((Label)Label_DesiredSpeed).Text = $"{waypoint.DesiredSpeed.Value:0}" + " kt";
				}
				if (waypoint.DesiredAltitudeOverride && !Information.IsNothing((object)waypoint.DesiredAltitude))
				{
					if (Information.IsNothing((object)waypoint.DesiredAltitude) && Information.IsNothing((object)waypoint.DesiredAltitude_TerrainFollowing))
					{
						if (!Information.IsNothing((object)SpeedAlt_SelectedUnit))
						{
							if (SpeedAlt_SelectedUnit.UseSubmerisbleUnitUI && waypoint.DepthPreset == ActiveUnit_AI.SubmarineDepthPreset.MaxDepth)
							{
								((Label)Label_DesiredAlt).Text = "Max Depth";
							}
							if (SpeedAlt_SelectedUnit.UseAerialUnitUI)
							{
								if (waypoint.AltitudePreset == ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude)
								{
									((Label)Label_DesiredAlt).Text = "Max Altitude";
								}
								if (waypoint.AltitudePreset == ActiveUnit_AI.AircraftAltitudePreset.MinAltitude)
								{
									((Label)Label_DesiredAlt).Text = "Min Altitude";
								}
							}
						}
						else if (SpeedAlt_FlightPlanWaypoint != null)
						{
							if (waypoint.AltitudePreset == ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude)
							{
								((Label)Label_DesiredAlt).Text = "Max Altitude";
							}
							if (waypoint.AltitudePreset == ActiveUnit_AI.AircraftAltitudePreset.MinAltitude)
							{
								((Label)Label_DesiredAlt).Text = "Min Altitude";
							}
						}
					}
					else if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
					{
						if (SpeedAlt_FlightPlanWaypoint == null && (SpeedAlt_SelectedUnit == null || !SpeedAlt_SelectedUnit.UseAerialUnitUI))
						{
							((Label)Label_DesiredAlt).Text = Conversions.ToString((int)Math.Round((waypoint.DesiredAltitude * 3.28084f).Value)) + " ft";
						}
						else if (waypoint.TerrainFollowing && !Information.IsNothing((object)waypoint.DesiredAltitude_TerrainFollowing))
						{
							((Label)Label_DesiredAlt).Text = Conversions.ToString((int)Math.Round((waypoint.DesiredAltitude_TerrainFollowing * 3.28084f).Value)) + " ft AGL";
						}
						else if (!Information.IsNothing((object)waypoint.DesiredAltitude))
						{
							((Label)Label_DesiredAlt).Text = Conversions.ToString((int)Math.Round((waypoint.DesiredAltitude * 3.28084f).Value)) + " ft ASL";
						}
					}
					else if (SpeedAlt_FlightPlanWaypoint == null && (SpeedAlt_SelectedUnit == null || !SpeedAlt_SelectedUnit.UseAerialUnitUI))
					{
						((Label)Label_DesiredAlt).Text = Conversions.ToString((int)Math.Round(waypoint.DesiredAltitude.Value)) + " m";
					}
					else if (waypoint.TerrainFollowing && !Information.IsNothing((object)waypoint.DesiredAltitude_TerrainFollowing))
					{
						((Label)Label_DesiredAlt).Text = Conversions.ToString((int)Math.Round(waypoint.DesiredAltitude_TerrainFollowing.Value)) + " m AGL";
					}
					else if (!Information.IsNothing((object)waypoint.DesiredAltitude))
					{
						((Label)Label_DesiredAlt).Text = Conversions.ToString((int)Math.Round(waypoint.DesiredAltitude.Value)) + " m ASL";
					}
				}
				else
				{
					((Label)Label_DesiredAlt).Text = "Not Set";
				}
				if (!bool_3)
				{
					TextBox_EnterSpeed.Text = ((Label)Label_DesiredSpeed).Text;
				}
				if (!bool_4)
				{
					TextBox_EnterAltitude.Text = ((Label)Label_DesiredAlt).Text;
				}
				((CheckBox)CB_TerrainFollowing).Checked = waypoint.TerrainFollowing;
				method_48();
				if (SpeedAlt_SelectedUnit != null)
				{
					if (!SpeedAlt_SelectedUnit.IsGroup)
					{
						((Label)Label_ActualSpeed).Text = $"{SpeedAlt_SelectedUnit.CurrentSpeed:0} kt (Throttle: {method_6()})";
					}
					else
					{
						((Label)Label_ActualSpeed).Text = $"{((Group)SpeedAlt_SelectedUnit).GroupLead.CurrentSpeed:0} kt";
					}
				}
				if (SpeedAlt_SelectedUnit != null)
				{
					if (!SpeedAlt_SelectedUnit.UseAerialUnitUI)
					{
						if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
						{
							((Label)Label_CurrentAlt).Text = Conversions.ToString((int)Math.Round(SpeedAlt_SelectedUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) * 3.28084f)) + " ft";
						}
						else
						{
							((Label)Label_CurrentAlt).Text = $"{SpeedAlt_SelectedUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null):0.0}" + " m";
						}
					}
					else if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
					{
						if (Module_Unit.IsOverLand(SpeedAlt_SelectedUnit))
						{
							((Label)Label_CurrentAlt).Text = Conversions.ToString((int)Math.Round(SpeedAlt_SelectedUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) * 3.28084f)) + " ft ASL (" + Conversions.ToString((int)Math.Round(SpeedAlt_SelectedUnit.CurrentAltitude_AGL * 3.28084f)) + " ft AGL)";
						}
						else
						{
							((Label)Label_CurrentAlt).Text = Conversions.ToString((int)Math.Round(SpeedAlt_SelectedUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) * 3.28084f)) + " ft ASL";
						}
					}
					else if (!Module_Unit.IsOverLand(SpeedAlt_SelectedUnit))
					{
						((Label)Label_CurrentAlt).Text = $"{SpeedAlt_SelectedUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null):0.0}" + " m ASL";
					}
					else
					{
						((Label)Label_CurrentAlt).Text = $"{SpeedAlt_SelectedUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null):0.0}" + " m ASL (" + $"{SpeedAlt_SelectedUnit.CurrentAltitude_AGL:0.0}" + " m AGL)";
					}
				}
				if (!bool_4)
				{
					if (waypoint.DesiredAltitude.HasValue || waypoint.DesiredAltitude_TerrainFollowing.HasValue || waypoint.AltitudePreset == ActiveUnit_AI.AircraftAltitudePreset.None || waypoint.DepthPreset == ActiveUnit_AI.SubmarineDepthPreset.None)
					{
						if (!waypoint.DesiredAltitudeOverride)
						{
							TextBox_EnterAltitude.Text = "";
						}
						else if (waypoint.DesiredAltitude.HasValue || waypoint.DesiredAltitude_TerrainFollowing.HasValue)
						{
							if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
							{
								if (waypoint.TerrainFollowing && !Information.IsNothing((object)waypoint.DesiredAltitude_TerrainFollowing))
								{
									TextBox_EnterAltitude.Text = Conversions.ToString((int)Math.Round((waypoint.DesiredAltitude_TerrainFollowing * 3.28084f).Value));
								}
								else if (!Information.IsNothing((object)waypoint.DesiredAltitude))
								{
									TextBox_EnterAltitude.Text = Conversions.ToString((int)Math.Round((waypoint.DesiredAltitude * 3.28084f).Value));
								}
							}
							else if (waypoint.TerrainFollowing && !Information.IsNothing((object)waypoint.DesiredAltitude_TerrainFollowing))
							{
								TextBox_EnterAltitude.Text = Conversions.ToString((int)Math.Round(waypoint.DesiredAltitude_TerrainFollowing.Value));
							}
							else if (!Information.IsNothing((object)waypoint.DesiredAltitude))
							{
								TextBox_EnterAltitude.Text = Conversions.ToString((int)Math.Round(waypoint.DesiredAltitude.Value));
							}
						}
					}
					if (waypoint.ThrottlePreset == ActiveUnit_Kinematics.UnitThrottlePreset.None)
					{
						bool? flag3 = (Information.IsNothing((object)waypoint.SprintDrift) ? new bool?(false) : waypoint.SprintDrift);
						if ((flag3 ?? true) && !Information.IsNothing((object)waypoint.SprintDrift_AverageSpeed) && flag3.HasValue)
						{
							if (!bool_3)
							{
								TextBox_EnterSpeed.Text = Conversions.ToString(waypoint.SprintDrift_AverageSpeed.Value);
							}
						}
						else if (!waypoint.DesiredSpeedOverride.HasValue)
						{
							if (!bool_3)
							{
								TextBox_EnterSpeed.Text = "";
							}
						}
						else if (waypoint.DesiredSpeed.HasValue && !bool_3)
						{
							TextBox_EnterSpeed.Text = Conversions.ToString(waypoint.DesiredSpeed.Value);
						}
					}
				}
				((CheckBox)CB_SpeedOverride).Checked = waypoint.DesiredSpeedOverride.HasValue;
				((CheckBox)CB_AltOverride).Checked = waypoint.DesiredAltitudeOverride;
				if (Information.IsNothing((object)waypoint.DesiredSpeedOverride))
				{
					if (waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None)
					{
						((Control)RB_NoThrottlePreset).Visible = true;
					}
					else
					{
						((Control)RB_NoThrottlePreset).Visible = false;
					}
				}
				else
				{
					((Control)RB_NoThrottlePreset).Visible = false;
				}
				if (waypoint.DesiredAltitudeOverride)
				{
					if (waypoint.AltitudePreset == ActiveUnit_AI.AircraftAltitudePreset.None)
					{
						((Control)RB_NoAltitudePreset).Visible = false;
					}
					else
					{
						((Control)RB_NoAltitudePreset).Visible = true;
					}
					if (waypoint.DepthPreset == ActiveUnit_AI.SubmarineDepthPreset.None)
					{
						((Control)RB_NoDepthPreset).Visible = false;
					}
					else
					{
						((Control)RB_NoDepthPreset).Visible = true;
					}
					if (SpeedAlt_SelectedUnit == null)
					{
						method_3();
						method_2();
						((Control)RB_NoDepthPreset).Visible = false;
						((Control)RB_NoAltitudePreset).Visible = false;
					}
					else if (SpeedAlt_SelectedUnit.UseAerialUnitUI)
					{
						if (Client.SelectedWaypoint.AltitudePreset == ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude)
						{
							((RadioButton)RB_MaxAltitude).Checked = true;
						}
						else
						{
							((RadioButton)RB_MaxAltitude).Checked = false;
						}
						if (Client.SelectedWaypoint.AltitudePreset == ActiveUnit_AI.AircraftAltitudePreset.const_6)
						{
							((RadioButton)RB_HighAltitude36000).Checked = true;
						}
						else
						{
							((RadioButton)RB_HighAltitude36000).Checked = false;
						}
						if (Client.SelectedWaypoint.AltitudePreset == ActiveUnit_AI.AircraftAltitudePreset.const_5)
						{
							((RadioButton)RB_HighAltitude25000).Checked = true;
						}
						else
						{
							((RadioButton)RB_HighAltitude25000).Checked = false;
						}
						if (Client.SelectedWaypoint.AltitudePreset == ActiveUnit_AI.AircraftAltitudePreset.const_4)
						{
							((RadioButton)RB_MediumAltitude12000).Checked = true;
						}
						else
						{
							((RadioButton)RB_MediumAltitude12000).Checked = false;
						}
						if (Client.SelectedWaypoint.AltitudePreset == ActiveUnit_AI.AircraftAltitudePreset.Low2000)
						{
							((RadioButton)RB_LowAltitude2000).Checked = true;
						}
						else
						{
							((RadioButton)RB_LowAltitude2000).Checked = false;
						}
						if (Client.SelectedWaypoint.AltitudePreset == ActiveUnit_AI.AircraftAltitudePreset.Low1000)
						{
							((RadioButton)RB_LowAltitude1000).Checked = true;
						}
						else
						{
							((RadioButton)RB_LowAltitude1000).Checked = false;
						}
						if (Client.SelectedWaypoint.AltitudePreset == ActiveUnit_AI.AircraftAltitudePreset.MinAltitude)
						{
							((RadioButton)RB_MinAltitude).Checked = true;
						}
						else
						{
							((RadioButton)RB_MinAltitude).Checked = false;
						}
						if (Client.SelectedWaypoint.AltitudePreset != ActiveUnit_AI.AircraftAltitudePreset.None)
						{
							Client.SelectedWaypoint.FollowAltitudePreset();
						}
					}
					else if (SpeedAlt_SelectedUnit.UseSubmerisbleUnitUI)
					{
						if (Client.SelectedWaypoint.DepthPreset == ActiveUnit_AI.SubmarineDepthPreset.Surface)
						{
							((RadioButton)RB_Surface).Checked = true;
						}
						else
						{
							((RadioButton)RB_Surface).Checked = false;
						}
						if (Client.SelectedWaypoint.DepthPreset == ActiveUnit_AI.SubmarineDepthPreset.Periscope)
						{
							((RadioButton)RB_Periscope).Checked = true;
						}
						else
						{
							((RadioButton)RB_Periscope).Checked = false;
						}
						if (Client.SelectedWaypoint.DepthPreset == ActiveUnit_AI.SubmarineDepthPreset.Shallow)
						{
							((RadioButton)RB_Shallow).Checked = true;
						}
						else
						{
							((RadioButton)RB_Shallow).Checked = false;
						}
						if (Client.SelectedWaypoint.DepthPreset == ActiveUnit_AI.SubmarineDepthPreset.OverLayer)
						{
							((RadioButton)RB_OverLayer).Checked = true;
						}
						else
						{
							((RadioButton)RB_OverLayer).Checked = false;
						}
						if (Client.SelectedWaypoint.DepthPreset == ActiveUnit_AI.SubmarineDepthPreset.UnderLayer)
						{
							((RadioButton)RB_UnderLayer).Checked = true;
						}
						else
						{
							((RadioButton)RB_UnderLayer).Checked = false;
						}
						if (Client.SelectedWaypoint.DepthPreset == ActiveUnit_AI.SubmarineDepthPreset.MaxDepth)
						{
							((RadioButton)RB_MaxDepth).Checked = true;
						}
						else
						{
							((RadioButton)RB_MaxDepth).Checked = false;
						}
						if (Client.SelectedWaypoint.AltitudePreset != ActiveUnit_AI.AircraftAltitudePreset.None)
						{
							Client.SelectedWaypoint.FollowDepthPreset(Client.CurrentScenario);
						}
						if (Client.SelectedWaypoint.DepthPreset == ActiveUnit_AI.SubmarineDepthPreset.MaxDepth)
						{
							Client.SelectedWaypoint.DesiredAltitude = SpeedAlt_SelectedUnit.Kinematics.GetMinimumAltitude();
						}
					}
				}
				if (!Information.IsNothing((object)waypoint.ThrottlePreset))
				{
					switch (waypoint.ThrottlePreset)
					{
					default:
						if (((RadioButton)RB_Stop).Checked)
						{
							((RadioButton)RB_Stop).Checked = false;
						}
						if (((RadioButton)RB_Creep).Checked)
						{
							((RadioButton)RB_Creep).Checked = false;
						}
						if (((RadioButton)RB_Cruise).Checked)
						{
							((RadioButton)RB_Cruise).Checked = false;
						}
						if (((RadioButton)RB_Full).Checked)
						{
							((RadioButton)RB_Full).Checked = false;
						}
						if (((RadioButton)RB_Flank).Checked)
						{
							((RadioButton)RB_Flank).Checked = false;
						}
						if (((RadioButton)RB_NoThrottlePreset).Checked)
						{
							((RadioButton)RB_NoThrottlePreset).Checked = false;
						}
						break;
					case ActiveUnit_Kinematics.UnitThrottlePreset.FullStop:
						if (!((RadioButton)RB_Stop).Checked)
						{
							((RadioButton)RB_Stop).Checked = true;
						}
						((CheckBox)CB_SpeedOverride).Checked = true;
						break;
					case ActiveUnit_Kinematics.UnitThrottlePreset.Loiter:
						if (!((RadioButton)RB_Creep).Checked)
						{
							((RadioButton)RB_Creep).Checked = true;
						}
						((CheckBox)CB_SpeedOverride).Checked = true;
						break;
					case ActiveUnit_Kinematics.UnitThrottlePreset.Cruise:
						if (!((RadioButton)RB_Cruise).Checked)
						{
							((RadioButton)RB_Cruise).Checked = true;
						}
						((CheckBox)CB_SpeedOverride).Checked = true;
						break;
					case ActiveUnit_Kinematics.UnitThrottlePreset.Full:
						if (!((RadioButton)RB_Full).Checked)
						{
							((RadioButton)RB_Full).Checked = true;
						}
						((CheckBox)CB_SpeedOverride).Checked = true;
						break;
					case ActiveUnit_Kinematics.UnitThrottlePreset.Flank:
						if (!((RadioButton)RB_Flank).Checked)
						{
							((RadioButton)RB_Flank).Checked = true;
						}
						((CheckBox)CB_SpeedOverride).Checked = true;
						break;
					case ActiveUnit_Kinematics.UnitThrottlePreset.None:
						if (!((RadioButton)RB_NoThrottlePreset).Checked)
						{
							((RadioButton)RB_NoThrottlePreset).Checked = true;
						}
						break;
					}
				}
				else
				{
					method_4();
					((RadioButton)RB_NoThrottlePreset).Checked = false;
				}
				if (!Information.IsNothing((object)SpeedAlt_SelectedUnit) && SpeedAlt_FlightPlanWaypoint == null)
				{
					int num11 = Array.IndexOf(SpeedAlt_SelectedUnit.Navigator.PlottedCourse, Client.SelectedWaypoint);
					bool flag4 = false;
					if (num11 >= 0)
					{
						if (SpeedAlt_SelectedUnit.IsAircraft || SpeedAlt_SelectedUnit.IsShip || SpeedAlt_SelectedUnit.IsSubmarine)
						{
							flag4 = true;
						}
						if (!flag4 && SpeedAlt_SelectedUnit.IsGroup && ((((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.AirGroup) | (((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.SurfaceGroup) | (((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.SubGroup)))
						{
							flag4 = true;
						}
					}
					if (flag4)
					{
						int num13 = default(int);
						int num14 = default(int);
						try
						{
							int num12 = num11;
							float num15 = default(float);
							float num16 = default(float);
							for (int i = 0; i <= num12; i++)
							{
								if (i == 0)
								{
									num13 = (int)Math.Round(SpeedAlt_SelectedUnit.CurrentSpeed);
									num14 = (int)Math.Round(SpeedAlt_SelectedUnit.DesiredSpeed);
									num15 = SpeedAlt_SelectedUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
									num16 = SpeedAlt_SelectedUnit.DesiredAltitude;
									num4 = Module_Unit.RangeToPoint_Horiz(SpeedAlt_SelectedUnit, SpeedAlt_SelectedUnit.Navigator.PlottedCourse[0]);
									ActiveUnit activeUnit = ((!SpeedAlt_SelectedUnit.IsGroup) ? SpeedAlt_SelectedUnit : ((Group)SpeedAlt_SelectedUnit).GroupLead);
									if (num13 > 0 && num6 < float.MaxValue && num8 < float.MaxValue)
									{
										num6 = (float)(num4 / (double)num13 * 3600.0);
										num8 = num6 * activeUnit.FuelConsumption(activeUnit.Kinematics.GetThrottleSuitableForThisSpeed(num15, num13), null, num13, num15, BingoFuelCheck: false, ReserveFuelQtyCalc: false, ExcludeDroppablePayload: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false);
									}
									else
									{
										num6 = float.MaxValue;
										num8 = float.MaxValue;
									}
									if (num14 > 0 && num7 < float.MaxValue && num9 < float.MaxValue)
									{
										num7 = (float)(num4 / (double)num14 * 3600.0);
										num9 = num7 * activeUnit.FuelConsumption(activeUnit.ThrottleSetting, null, num14, num16, BingoFuelCheck: false, ReserveFuelQtyCalc: false, ExcludeDroppablePayload: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false);
									}
									else
									{
										num7 = float.MaxValue;
										num9 = float.MaxValue;
									}
								}
								else
								{
									if (SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i].Latitude == SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i - 1].Latitude || SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i].Longitude == SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i - 1].Longitude)
									{
										continue;
									}
									num5 = Math2.CalcDist(SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i].Latitude, SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i].Longitude, SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i - 1].Latitude, SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i - 1].Longitude);
									if (SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i - 1].DesiredAltitudeOverride)
									{
										if (!Information.IsNothing((object)SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i - 1].DesiredAltitude))
										{
											num15 = SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i - 1].DesiredAltitude.Value;
											num16 = SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i - 1].DesiredAltitude.Value;
											if (num15 < minimumAltitude)
											{
												num15 = minimumAltitude;
											}
											if (num15 > maximumAltitude)
											{
												num15 = maximumAltitude;
											}
											if (num16 < minimumAltitude)
											{
												num16 = minimumAltitude;
											}
											if (num16 > maximumAltitude)
											{
												num16 = maximumAltitude;
											}
										}
										else if (SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i - 1].DepthPreset != ActiveUnit_AI.SubmarineDepthPreset.None)
										{
											if (SpeedAlt_SelectedUnit.IsSubmarine || (SpeedAlt_SelectedUnit.IsGroup && ((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.SubGroup))
											{
												if (SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i - 1].DepthPreset == ActiveUnit_AI.SubmarineDepthPreset.Surface)
												{
													num15 = 0f;
													num16 = 0f;
												}
												if (SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i - 1].DepthPreset == ActiveUnit_AI.SubmarineDepthPreset.MaxDepth)
												{
													num15 = minimumAltitude;
													num16 = minimumAltitude;
												}
											}
										}
										else if (SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i - 1].AltitudePreset != ActiveUnit_AI.AircraftAltitudePreset.None && SpeedAlt_SelectedUnit.UseAerialUnitUI)
										{
											if (SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i - 1].AltitudePreset == ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude)
											{
												num15 = maximumAltitude;
												num16 = maximumAltitude;
											}
											if (SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i - 1].AltitudePreset == ActiveUnit_AI.AircraftAltitudePreset.MinAltitude)
											{
												num15 = minimumAltitude;
												num16 = minimumAltitude;
											}
										}
									}
									if (SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i - 1].DesiredSpeedOverride.HasValue)
									{
										if (!Information.IsNothing((object)SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i - 1].DesiredSpeed))
										{
											num13 = (int)Math.Round(SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i - 1].DesiredSpeed.Value);
											num14 = (int)Math.Round(SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i - 1].DesiredSpeed.Value);
											if (num13 > SpeedAlt_SelectedUnit.Kinematics.GetMaximumSpeed(num15))
											{
												num13 = SpeedAlt_SelectedUnit.Kinematics.GetMaximumSpeed(num15);
											}
											if (num14 > SpeedAlt_SelectedUnit.Kinematics.GetMaximumSpeed(num16))
											{
												num14 = SpeedAlt_SelectedUnit.Kinematics.GetMaximumSpeed(num16);
											}
											if (SpeedAlt_SelectedUnit.IsAircraft)
											{
												if (!((Aircraft)SpeedAlt_SelectedUnit).get_CanHover(bool_7: false))
												{
													if (num13 < ((Aircraft)SpeedAlt_SelectedUnit).Kinematics.GetMaximumSpeed(num15, ActiveUnit.Throttle.Loiter, ValidateAndFixAltitude: false))
													{
														num13 = ((Aircraft)SpeedAlt_SelectedUnit).Kinematics.GetMaximumSpeed(num15, ActiveUnit.Throttle.Loiter, ValidateAndFixAltitude: false);
													}
													if (num14 < ((Aircraft)SpeedAlt_SelectedUnit).Kinematics.GetMaximumSpeed(num16, ActiveUnit.Throttle.Loiter, ValidateAndFixAltitude: false))
													{
														num14 = ((Aircraft)SpeedAlt_SelectedUnit).Kinematics.GetMaximumSpeed(num16, ActiveUnit.Throttle.Loiter, ValidateAndFixAltitude: false);
													}
												}
											}
											else if (!SpeedAlt_SelectedUnit.IsWeapon)
											{
												if (SpeedAlt_SelectedUnit.IsGroup && ((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.AirGroup)
												{
													if (Information.IsNothing((object)((Group)SpeedAlt_SelectedUnit).GroupLead))
													{
														return;
													}
													Aircraft aircraft = (Aircraft)((Group)SpeedAlt_SelectedUnit).GroupLead;
													if (!aircraft.get_CanHover(bool_7: false))
													{
														if (num13 < aircraft.Kinematics.GetMaximumSpeed(num15, ActiveUnit.Throttle.Loiter, ValidateAndFixAltitude: false))
														{
															num13 = aircraft.Kinematics.GetMaximumSpeed(num15, ActiveUnit.Throttle.Loiter, ValidateAndFixAltitude: false);
														}
														if (num14 < aircraft.Kinematics.GetMaximumSpeed(num16, ActiveUnit.Throttle.Loiter, ValidateAndFixAltitude: false))
														{
															num14 = aircraft.Kinematics.GetMaximumSpeed(num16, ActiveUnit.Throttle.Loiter, ValidateAndFixAltitude: false);
														}
													}
												}
												else
												{
													if (num13 < (int)Math.Round(SpeedAlt_SelectedUnit.Kinematics.GetMinimumSpeed_Total(num15, ValidateAndFixAltitude: false)))
													{
														num13 = (int)Math.Round(SpeedAlt_SelectedUnit.Kinematics.GetMinimumSpeed_Total(SpeedAlt_SelectedUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ValidateAndFixAltitude: false));
													}
													if (num14 < (int)Math.Round(SpeedAlt_SelectedUnit.Kinematics.GetMinimumSpeed_Total(num16, ValidateAndFixAltitude: false)))
													{
														num14 = (int)Math.Round(SpeedAlt_SelectedUnit.Kinematics.GetMinimumSpeed_Total(SpeedAlt_SelectedUnit.DesiredAltitude, ValidateAndFixAltitude: false));
													}
												}
											}
											else
											{
												if (num13 < ((Weapon)SpeedAlt_SelectedUnit).Kinematics.GetMaximumSpeed(num15, ActiveUnit.Throttle.Cruise, ValidateAndFixAltitude: false))
												{
													num13 = ((Weapon)SpeedAlt_SelectedUnit).Kinematics.GetMaximumSpeed(num15, ActiveUnit.Throttle.Cruise, ValidateAndFixAltitude: false);
												}
												if (num14 < ((Weapon)SpeedAlt_SelectedUnit).Kinematics.GetMaximumSpeed(num16, ActiveUnit.Throttle.Cruise, ValidateAndFixAltitude: false))
												{
													num14 = ((Weapon)SpeedAlt_SelectedUnit).Kinematics.GetMaximumSpeed(num16, ActiveUnit.Throttle.Cruise, ValidateAndFixAltitude: false);
												}
											}
										}
									}
									else if (SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i - 1].ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None)
									{
										num13 = SpeedAlt_SelectedUnit.Kinematics.GetMaximumSpeed(num15, (ActiveUnit.Throttle)SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i - 1].ThrottlePreset, ValidateAndFixAltitude: false);
										num14 = SpeedAlt_SelectedUnit.Kinematics.GetMaximumSpeed(num16, (ActiveUnit.Throttle)SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i - 1].ThrottlePreset, ValidateAndFixAltitude: false);
									}
									if (num13 <= 0 || num14 <= 0)
									{
										break;
									}
									num4 += num5;
									ActiveUnit activeUnit2 = (SpeedAlt_SelectedUnit.IsGroup ? ((Group)SpeedAlt_SelectedUnit).GroupLead : SpeedAlt_SelectedUnit);
									if (num13 > 0 && num6 < float.MaxValue && num8 < float.MaxValue)
									{
										num6 = (float)((double)num6 + num5 / (double)num13 * 3600.0);
										num8 = (float)((double)num8 + num5 / (double)num13 * 3600.0 * (double)activeUnit2.FuelConsumption(activeUnit2.Kinematics.GetThrottleSuitableForThisSpeed(num15, num13), null, num13, num15, BingoFuelCheck: false, ReserveFuelQtyCalc: false, ExcludeDroppablePayload: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false));
									}
									if (num14 > 0 && num7 < float.MaxValue && num9 < float.MaxValue)
									{
										num7 = (float)((double)num7 + num5 / (double)num14 * 3600.0);
										num9 = (float)((double)num9 + num5 / (double)num14 * 3600.0 * (double)activeUnit2.FuelConsumption(activeUnit2.Kinematics.GetThrottleSuitableForThisSpeed(num15, num13), null, num14, num16, BingoFuelCheck: false, ReserveFuelQtyCalc: false, ExcludeDroppablePayload: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false));
									}
								}
							}
						}
						catch (Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							Exception ex4 = ex3;
							ex4.Data.Add("Error at 200412", ex4.Message);
							GameGeneral.WriteExceptionsToLog(ex4);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
						try
						{
							if (num13 > 0 && num14 > 0 && num7 > 0f && num6 > 0f && (float)num13 < float.MaxValue && (float)num14 < float.MaxValue && num7 < float.MaxValue && num6 < float.MaxValue)
							{
								((Label)Label_DTG).Text = "DTG: " + $"{num4:0} nm";
								if ((int)Math.Round(num7) != (int)Math.Round(num6))
								{
									((Label)Label_TTG).Text = "TTG: " + Misc.TimeString((long)Math.Round(num6)) + " (Current), " + Misc.TimeString((long)Math.Round(num7)) + " (Desired) ";
									((Label)Label_Fuel).Text = "Fuel qty required: " + $"{num8:0.0}" + " kg (Current), " + $"{num9:0.0}" + " kg (Desired) ";
								}
								else
								{
									((Label)Label_TTG).Text = "TTG: " + Misc.TimeString((long)Math.Round(num7));
									((Label)Label_Fuel).Text = "Fuel qty required: " + $"{num9:0.0}" + " kg";
								}
								((Label)Label_WaypointName).Text = "Waypoint #" + Conversions.ToString(num11 + 1) + " for " + SpeedAlt_SelectedUnit.Name;
							}
							else
							{
								((Label)Label_WaypointName).Text = "One or more speed order is 0kt, can not estimate DTG/TTG/Fuel qty";
								((Label)Label_DTG).Text = "";
								((Label)Label_TTG).Text = "";
								((Label)Label_Fuel).Text = "";
							}
						}
						catch (Exception ex5)
						{
							ProjectData.SetProjectError(ex5);
							Exception ex6 = ex5;
							ex6.Data.Add("Error at 200413", ex6.Message);
							GameGeneral.WriteExceptionsToLog(ex6);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					else
					{
						((Label)Label_WaypointName).Text = "";
						((Label)Label_DTG).Text = "";
						((Label)Label_TTG).Text = "";
						((Label)Label_Fuel).Text = "";
					}
				}
				else
				{
					((Label)Label_DTG).Text = "";
					((Label)Label_TTG).Text = "";
					((Label)Label_Fuel).Text = "";
				}
				if (!bool_5)
				{
					TextBox_WaypointDescription.Text = waypoint.Description;
					switch (waypoint.Type)
					{
					case Waypoint.WaypointType.ManualPlottedCourseWaypoint:
						((ComboBox)CB_WaypointType).SelectedIndex = 1;
						break;
					case Waypoint.WaypointType.PatrolStation:
						((ComboBox)CB_WaypointType).SelectedIndex = 13;
						break;
					case Waypoint.WaypointType.LocalizationRun:
						((ComboBox)CB_WaypointType).SelectedIndex = 14;
						break;
					case Waypoint.WaypointType.Assemble:
						((ComboBox)CB_WaypointType).SelectedIndex = 0;
						break;
					case Waypoint.WaypointType.TurningPoint:
						((ComboBox)CB_WaypointType).SelectedIndex = 3;
						break;
					case Waypoint.WaypointType.InitialPoint:
						((ComboBox)CB_WaypointType).SelectedIndex = 4;
						break;
					case Waypoint.WaypointType.LandingMarshal:
						((ComboBox)CB_WaypointType).SelectedIndex = 11;
						break;
					case Waypoint.WaypointType.StrikeIngress:
						((ComboBox)CB_WaypointType).SelectedIndex = 5;
						break;
					case Waypoint.WaypointType.StrikeEgress:
						((ComboBox)CB_WaypointType).SelectedIndex = 6;
						break;
					case Waypoint.WaypointType.Refuel:
						((ComboBox)CB_WaypointType).SelectedIndex = 15;
						break;
					case Waypoint.WaypointType.TakeOff:
						((ComboBox)CB_WaypointType).SelectedIndex = 7;
						break;
					case Waypoint.WaypointType.Land:
						((ComboBox)CB_WaypointType).SelectedIndex = 12;
						break;
					case Waypoint.WaypointType.Target:
					case Waypoint.WaypointType.WeaponTarget:
						((ComboBox)CB_WaypointType).SelectedIndex = 2;
						break;
					case Waypoint.WaypointType.HoldStart:
						((ComboBox)CB_WaypointType).SelectedIndex = 8;
						break;
					case Waypoint.WaypointType.HoldEnd:
						((ComboBox)CB_WaypointType).SelectedIndex = 9;
						break;
					}
				}
			}
			goto IL_4c50;
			IL_158b:
			if (SpeedAlt_SelectedUnit.IsGroup)
			{
				if (Information.IsNothing((object)((Group)SpeedAlt_SelectedUnit).GroupLead))
				{
					return;
				}
				((CheckBox)CB_SpeedOverride).Checked = SpeedAlt_SelectedUnit.Kinematics.DesiredSpeedOverride.HasValue;
				((CheckBox)CB_AltOverride).Checked = SpeedAlt_SelectedUnit.Kinematics.DesiredAltitudeOverride;
			}
			else
			{
				((CheckBox)CB_SpeedOverride).Checked = SpeedAlt_SelectedUnit.Kinematics.DesiredSpeedOverride.HasValue;
				((CheckBox)CB_AltOverride).Checked = SpeedAlt_SelectedUnit.Kinematics.DesiredAltitudeOverride;
			}
			((Label)Label_MinSpeed).Text = TrackBar_Throttle.Minimum + " kt";
			((Label)Label_MaxSpeed).Text = TrackBar_Throttle.Maximum + " kt";
			if (SpeedAlt_SelectedUnit.Navigator.SprintDrift && !Information.IsNothing((object)SpeedAlt_SelectedUnit.Navigator.SprintDrift_AverageSpeed))
			{
				if (SpeedAlt_SelectedUnit.Navigator.SprintDrift_AverageSpeed.Value > (float)TrackBar_Throttle.Maximum)
				{
					TrackBar_Throttle.Value = TrackBar_Throttle.Maximum;
				}
				else if (SpeedAlt_SelectedUnit.Navigator.SprintDrift_AverageSpeed.Value < (float)TrackBar_Throttle.Minimum)
				{
					TrackBar_Throttle.Value = TrackBar_Throttle.Minimum;
				}
				else
				{
					TrackBar_Throttle.Value = (int)Math.Round(SpeedAlt_SelectedUnit.Navigator.SprintDrift_AverageSpeed.Value);
				}
			}
			else if (SpeedAlt_SelectedUnit.DesiredSpeed > (float)TrackBar_Throttle.Maximum)
			{
				TrackBar_Throttle.Value = TrackBar_Throttle.Maximum;
			}
			else if (SpeedAlt_SelectedUnit.DesiredSpeed < (float)TrackBar_Throttle.Minimum)
			{
				TrackBar_Throttle.Value = TrackBar_Throttle.Minimum;
			}
			else
			{
				TrackBar_Throttle.Value = (int)Math.Round(SpeedAlt_SelectedUnit.DesiredSpeed);
			}
			int num17;
			if (SpeedAlt_SelectedUnit.DesiredAltitude > (float)TrackBar_Altitude.Maximum)
			{
				TrackBar_Altitude.Value = TrackBar_Altitude.Maximum;
				num17 = 0;
			}
			else if (SpeedAlt_SelectedUnit.DesiredAltitude < (float)TrackBar_Altitude.Minimum)
			{
				TrackBar_Altitude.Value = TrackBar_Altitude.Minimum;
				num17 = 0;
			}
			else
			{
				TrackBar_Altitude.Value = (int)Math.Round(SpeedAlt_SelectedUnit.DesiredAltitude);
				num17 = 0;
			}
			bool flag5 = (byte)num17 != 0;
			if (SpeedAlt_SelectedUnit.IsAircraft | SpeedAlt_SelectedUnit.IsShip | SpeedAlt_SelectedUnit.IsSubmarine)
			{
				flag5 = true;
			}
			if (SpeedAlt_SelectedUnit.IsGroup && ((((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.AirGroup) | (((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.SurfaceGroup) | (((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.SubGroup)))
			{
				flag5 = true;
			}
			if (flag5 && SpeedAlt_SelectedUnit.Navigator.PlottedCourse.Count() > 0)
			{
				try
				{
					if (SpeedAlt_SelectedUnit.CurrentSpeed > 0f && SpeedAlt_SelectedUnit.DesiredSpeed > 0f)
					{
						num4 = Module_Unit.RangeToPoint_Horiz(SpeedAlt_SelectedUnit, SpeedAlt_SelectedUnit.Navigator.PlottedCourse[0]);
						num6 = (float)(num4 / (double)SpeedAlt_SelectedUnit.CurrentSpeed * 3600.0);
						num7 = (float)(num4 / (double)SpeedAlt_SelectedUnit.DesiredSpeed * 3600.0);
						ActiveUnit activeUnit3 = ((!SpeedAlt_SelectedUnit.IsGroup) ? SpeedAlt_SelectedUnit : ((Group)SpeedAlt_SelectedUnit).GroupLead);
						num8 = num6 * activeUnit3.FuelConsumption(activeUnit3.Kinematics.GetThrottleSuitableForThisSpeed(activeUnit3.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (int)Math.Round(activeUnit3.CurrentSpeed)), null, (int)Math.Round(activeUnit3.CurrentSpeed), activeUnit3.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), BingoFuelCheck: false, ReserveFuelQtyCalc: false, ExcludeDroppablePayload: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false);
						num9 = num7 * activeUnit3.FuelConsumption(activeUnit3.ThrottleSetting, null, (int)Math.Round(activeUnit3.DesiredSpeed), activeUnit3.DesiredAltitude, BingoFuelCheck: false, ReserveFuelQtyCalc: false, ExcludeDroppablePayload: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false);
						((Label)Label_DTG).Text = "DTG: " + $"{num4:0} nm";
						if ((int)Math.Round(num7) != (int)Math.Round(num6))
						{
							((Label)Label_TTG).Text = "TTG: " + Misc.TimeString((long)Math.Round(num6)) + " (Current), " + Misc.TimeString((long)Math.Round(num7)) + " (Desired) ";
							((Label)Label_Fuel).Text = "Fuel qty required: " + string.Format("{0:0.0}", num8, 1) + " kg (Current), " + string.Format("{0:0.0}", num9, 1) + " kg (Desired) ";
						}
						else
						{
							((Label)Label_TTG).Text = "TTG: " + Misc.TimeString((long)Math.Round(num7));
							((Label)Label_Fuel).Text = "Fuel qty required: " + string.Format("{0:0.0}", num9, 1) + " kg";
						}
						if (SpeedAlt_SelectedUnit.Navigator.PlottedCourse.Count() > 0)
						{
							if (Operators.CompareString(SpeedAlt_SelectedUnit.Navigator.PlottedCourse[0].Name, "", true) == 0)
							{
								((Label)Label_WaypointName).Text = "Next waypoint: Navigation Waypoint ";
							}
							else
							{
								((Label)Label_WaypointName).Text = "Next waypoint: " + SpeedAlt_SelectedUnit.Navigator.PlottedCourse[0].Name;
							}
						}
					}
					else
					{
						((Label)Label_WaypointName).Text = "One or more speed order is 0kt, can not estimate DTG/TTG/Fuel qty";
						((Label)Label_DTG).Text = "";
						((Label)Label_TTG).Text = "";
						((Label)Label_Fuel).Text = "";
					}
					if (SpeedAlt_SelectedUnit.Navigator.PlottedCourse.Count() > 0)
					{
						TextBox_WaypointDescription.Text = SpeedAlt_SelectedUnit.Navigator.PlottedCourse[0].Description;
					}
					switch (SpeedAlt_SelectedUnit.Navigator.PlottedCourse[0].Type)
					{
					case Waypoint.WaypointType.ManualPlottedCourseWaypoint:
						((ComboBox)CB_WaypointType).SelectedIndex = 1;
						break;
					case Waypoint.WaypointType.PatrolStation:
						((ComboBox)CB_WaypointType).SelectedIndex = 13;
						break;
					case Waypoint.WaypointType.LocalizationRun:
						((ComboBox)CB_WaypointType).SelectedIndex = 14;
						break;
					case Waypoint.WaypointType.Assemble:
						((ComboBox)CB_WaypointType).SelectedIndex = 0;
						break;
					case Waypoint.WaypointType.TurningPoint:
						((ComboBox)CB_WaypointType).SelectedIndex = 3;
						break;
					case Waypoint.WaypointType.InitialPoint:
						((ComboBox)CB_WaypointType).SelectedIndex = 4;
						break;
					case Waypoint.WaypointType.LandingMarshal:
						((ComboBox)CB_WaypointType).SelectedIndex = 11;
						break;
					case Waypoint.WaypointType.StrikeIngress:
						((ComboBox)CB_WaypointType).SelectedIndex = 5;
						break;
					case Waypoint.WaypointType.StrikeEgress:
						((ComboBox)CB_WaypointType).SelectedIndex = 6;
						break;
					case Waypoint.WaypointType.Refuel:
						((ComboBox)CB_WaypointType).SelectedIndex = 15;
						break;
					case Waypoint.WaypointType.TakeOff:
						((ComboBox)CB_WaypointType).SelectedIndex = 7;
						break;
					case Waypoint.WaypointType.Land:
						((ComboBox)CB_WaypointType).SelectedIndex = 12;
						break;
					case Waypoint.WaypointType.Target:
					case Waypoint.WaypointType.WeaponTarget:
						((ComboBox)CB_WaypointType).SelectedIndex = 2;
						break;
					case Waypoint.WaypointType.HoldStart:
						((ComboBox)CB_WaypointType).SelectedIndex = 8;
						break;
					case Waypoint.WaypointType.HoldEnd:
						((ComboBox)CB_WaypointType).SelectedIndex = 9;
						break;
					case Waypoint.WaypointType.TerminalPoint:
					case Waypoint.WaypointType.PathfindingPoint:
					case Waypoint.WaypointType.Split:
					case Waypoint.WaypointType.Formate:
					case Waypoint.WaypointType.Marshal:
					case Waypoint.WaypointType.WeaponLaunch:
					case Waypoint.WaypointType.StationStart_Racetrack:
					case Waypoint.WaypointType.StationStart_FigureEight:
					case Waypoint.WaypointType.StationStart_Area:
					case Waypoint.WaypointType.StationStart_RaceTrackRandom:
					case Waypoint.WaypointType.StationEnd:
					case Waypoint.WaypointType.PickupPoint:
						break;
					}
				}
				catch (Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					Exception ex8 = ex7;
					ex8.Data.Add("Error at 200414", ex8.Message);
					GameGeneral.WriteExceptionsToLog(ex8);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			else
			{
				((Label)Label_WaypointName).Text = "";
				((Label)Label_DTG).Text = "";
				((Label)Label_TTG).Text = "";
				((Label)Label_Fuel).Text = "";
				TextBox_WaypointDescription.Text = "";
				((ComboBox)CB_WaypointType).SelectedIndex = -1;
			}
			if (TrackBar_Altitude.Maximum != (int)Math.Round(maximumAltitude))
			{
				TrackBar_Altitude.Maximum = (int)Math.Round(maximumAltitude);
			}
			TrackBar_Altitude.Minimum = (int)Math.Round(minimumAltitude);
			if (SpeedAlt_SelectedUnit.IsAircraft)
			{
				if (!((Aircraft)SpeedAlt_SelectedUnit).get_CanHover(bool_7: false))
				{
					TrackBar_Throttle.Minimum = ((Aircraft)SpeedAlt_SelectedUnit).Kinematics.GetMaximumSpeed(SpeedAlt_SelectedUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Loiter, ValidateAndFixAltitude: false);
					((Control)RB_Stop).Enabled = false;
				}
				((Control)RB_Cruise).Enabled = true;
				((Control)RB_Creep).Enabled = true;
			}
			else if (SpeedAlt_SelectedUnit.IsShip)
			{
				TrackBar_Throttle.Minimum = 0;
				((Control)RB_Cruise).Enabled = true;
				((Control)RB_Creep).Enabled = true;
				((Control)RB_Stop).Enabled = true;
			}
			else if (!SpeedAlt_SelectedUnit.IsSubmarine)
			{
				if (!SpeedAlt_SelectedUnit.IsFacility)
				{
					if (SpeedAlt_SelectedUnit.IsWeapon)
					{
						Weapon weapon = (Weapon)SpeedAlt_SelectedUnit;
						if (weapon.Kinematics.CanApplyLoiterThrottle())
						{
							TrackBar_Throttle.Minimum = weapon.Kinematics.GetMaximumSpeed(SpeedAlt_SelectedUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Loiter, ValidateAndFixAltitude: false);
							((Control)RB_Creep).Enabled = true;
						}
						else
						{
							TrackBar_Throttle.Minimum = weapon.Kinematics.GetMaximumSpeed(SpeedAlt_SelectedUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Cruise, ValidateAndFixAltitude: false);
							((Control)RB_Creep).Enabled = false;
						}
						((Control)RB_Stop).Enabled = false;
						((Control)RB_Cruise).Enabled = true;
					}
					else if (SpeedAlt_SelectedUnit.IsGroup && ((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.AirGroup)
					{
						Group obj3 = (Group)SpeedAlt_SelectedUnit;
						if (obj3.GroupLead != null)
						{
							Aircraft aircraft2 = (Aircraft)((Group)SpeedAlt_SelectedUnit).GroupLead;
							if (aircraft2 != null)
							{
								if (obj3.CompositionType != Group.E_CompositionType.Homogenous_DBIDandLoadout && obj3.CompositionType != Group.E_CompositionType.Homogenous_DBID)
								{
									TrackBar_Throttle.Minimum = (int)Math.Round(obj3.GetMinimumCohesiveSpeed(ActiveUnit.Throttle.MinPossibleThrottle, aircraft2.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)));
								}
								else
								{
									if (Information.IsNothing((object)((Group)SpeedAlt_SelectedUnit).GroupLead))
									{
										return;
									}
									if (!aircraft2.get_CanHover(bool_7: false))
									{
										TrackBar_Throttle.Minimum = aircraft2.Kinematics.GetMaximumSpeed(aircraft2.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Loiter, ValidateAndFixAltitude: false);
										((Control)RB_Stop).Enabled = false;
									}
									((Control)RB_Creep).Enabled = true;
									((Control)RB_Cruise).Enabled = true;
								}
							}
						}
					}
					else
					{
						TrackBar_Throttle.Minimum = (int)Math.Round(SpeedAlt_SelectedUnit.Kinematics.GetMinimumSpeed_Total(SpeedAlt_SelectedUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ValidateAndFixAltitude: false));
					}
				}
				else
				{
					TrackBar_Throttle.Minimum = 0;
					if (!SpeedAlt_SelectedUnit.IsFixedFacility)
					{
						((Control)RB_Creep).Enabled = true;
						((Control)RB_Cruise).Enabled = true;
						((Control)RB_Stop).Enabled = true;
					}
					else
					{
						((Control)RB_Creep).Enabled = false;
						((Control)RB_Cruise).Enabled = false;
						((Control)RB_Stop).Enabled = true;
					}
				}
			}
			else
			{
				TrackBar_Throttle.Minimum = 0;
				((Control)RB_Cruise).Enabled = true;
				((Control)RB_Creep).Enabled = true;
				((Control)RB_Stop).Enabled = true;
			}
			if (SpeedAlt_SelectedUnit.IsSubmarine && !Information.IsNothing((object)SpeedAlt_SelectedUnit.Kinematics.ThrottlePreset) && SpeedAlt_SelectedUnit.DesiredSpeed != (float)SpeedAlt_SelectedUnit.Kinematics.GetMaximumSpeed(SpeedAlt_SelectedUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (ActiveUnit.Throttle)SpeedAlt_SelectedUnit.Kinematics.ThrottlePreset, ValidateAndFixAltitude: false))
			{
				method_4();
				switch (SpeedAlt_SelectedUnit.Kinematics.ThrottlePreset)
				{
				case ActiveUnit_Kinematics.UnitThrottlePreset.FullStop:
					((RadioButton)RB_Stop).Checked = true;
					break;
				case ActiveUnit_Kinematics.UnitThrottlePreset.Loiter:
					((RadioButton)RB_Creep).Checked = true;
					break;
				case ActiveUnit_Kinematics.UnitThrottlePreset.Cruise:
					((RadioButton)RB_Cruise).Checked = true;
					break;
				case ActiveUnit_Kinematics.UnitThrottlePreset.Full:
					((RadioButton)RB_Full).Checked = true;
					break;
				case ActiveUnit_Kinematics.UnitThrottlePreset.Flank:
					((RadioButton)RB_Flank).Checked = true;
					break;
				}
			}
			if (Information.IsNothing((object)SpeedAlt_SelectedUnit.Kinematics.ThrottlePreset))
			{
				method_4();
				((RadioButton)RB_NoThrottlePreset).Checked = false;
			}
			else
			{
				switch (SpeedAlt_SelectedUnit.Kinematics.ThrottlePreset)
				{
				default:
					if (((RadioButton)RB_Stop).Checked)
					{
						((RadioButton)RB_Stop).Checked = false;
					}
					if (((RadioButton)RB_Creep).Checked)
					{
						((RadioButton)RB_Creep).Checked = false;
					}
					if (((RadioButton)RB_Cruise).Checked)
					{
						((RadioButton)RB_Cruise).Checked = false;
					}
					if (((RadioButton)RB_Full).Checked)
					{
						((RadioButton)RB_Full).Checked = false;
					}
					if (((RadioButton)RB_Flank).Checked)
					{
						((RadioButton)RB_Flank).Checked = false;
					}
					if (((RadioButton)RB_NoThrottlePreset).Checked)
					{
						((RadioButton)RB_NoThrottlePreset).Checked = false;
					}
					break;
				case ActiveUnit_Kinematics.UnitThrottlePreset.FullStop:
					if (!((RadioButton)RB_Stop).Checked)
					{
						((RadioButton)RB_Stop).Checked = true;
					}
					break;
				case ActiveUnit_Kinematics.UnitThrottlePreset.Loiter:
					if (!((RadioButton)RB_Creep).Checked)
					{
						((RadioButton)RB_Creep).Checked = true;
					}
					break;
				case ActiveUnit_Kinematics.UnitThrottlePreset.Cruise:
					if (!((RadioButton)RB_Cruise).Checked)
					{
						((RadioButton)RB_Cruise).Checked = true;
					}
					break;
				case ActiveUnit_Kinematics.UnitThrottlePreset.Full:
					if (!((RadioButton)RB_Full).Checked)
					{
						((RadioButton)RB_Full).Checked = true;
					}
					break;
				case ActiveUnit_Kinematics.UnitThrottlePreset.Flank:
					if (!((RadioButton)RB_Flank).Checked)
					{
						((RadioButton)RB_Flank).Checked = true;
					}
					break;
				case ActiveUnit_Kinematics.UnitThrottlePreset.None:
					if (!((RadioButton)RB_NoThrottlePreset).Checked)
					{
						((RadioButton)RB_NoThrottlePreset).Checked = true;
					}
					break;
				}
			}
			if (!SpeedAlt_SelectedUnit.IsAircraft)
			{
				if (SpeedAlt_SelectedUnit.IsGroup && ((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.AirGroup)
				{
					switch (((Aircraft_AI)((Group)SpeedAlt_SelectedUnit).GroupLead.AI).AltitudePreset)
					{
					default:
						if (((RadioButton)RB_MaxAltitude).Checked)
						{
							((RadioButton)RB_MaxAltitude).Checked = false;
						}
						if (((RadioButton)RB_HighAltitude36000).Checked)
						{
							((RadioButton)RB_HighAltitude36000).Checked = false;
						}
						if (((RadioButton)RB_HighAltitude25000).Checked)
						{
							((RadioButton)RB_HighAltitude25000).Checked = false;
						}
						if (((RadioButton)RB_MediumAltitude12000).Checked)
						{
							((RadioButton)RB_MediumAltitude12000).Checked = false;
						}
						if (((RadioButton)RB_LowAltitude2000).Checked)
						{
							((RadioButton)RB_LowAltitude2000).Checked = false;
						}
						if (((RadioButton)RB_LowAltitude1000).Checked)
						{
							((RadioButton)RB_LowAltitude1000).Checked = false;
						}
						if (((RadioButton)RB_MinAltitude).Checked)
						{
							((RadioButton)RB_MinAltitude).Checked = false;
						}
						if (((RadioButton)RB_NoAltitudePreset).Checked)
						{
							((RadioButton)RB_NoAltitudePreset).Checked = false;
						}
						break;
					case ActiveUnit_AI.AircraftAltitudePreset.None:
						if (!((RadioButton)RB_NoAltitudePreset).Checked)
						{
							((RadioButton)RB_NoAltitudePreset).Checked = true;
						}
						break;
					case ActiveUnit_AI.AircraftAltitudePreset.MinAltitude:
						if (!((RadioButton)RB_MinAltitude).Checked)
						{
							((RadioButton)RB_MinAltitude).Checked = true;
						}
						break;
					case ActiveUnit_AI.AircraftAltitudePreset.Low1000:
						if (!((RadioButton)RB_LowAltitude1000).Checked)
						{
							((RadioButton)RB_LowAltitude1000).Checked = true;
						}
						break;
					case ActiveUnit_AI.AircraftAltitudePreset.Low2000:
						if (!((RadioButton)RB_LowAltitude2000).Checked)
						{
							((RadioButton)RB_LowAltitude2000).Checked = true;
						}
						break;
					case ActiveUnit_AI.AircraftAltitudePreset.const_4:
						if (!((RadioButton)RB_MediumAltitude12000).Checked)
						{
							((RadioButton)RB_MediumAltitude12000).Checked = true;
						}
						break;
					case ActiveUnit_AI.AircraftAltitudePreset.const_5:
						if (!((RadioButton)RB_HighAltitude25000).Checked)
						{
							((RadioButton)RB_HighAltitude25000).Checked = true;
						}
						break;
					case ActiveUnit_AI.AircraftAltitudePreset.const_6:
						if (!((RadioButton)RB_HighAltitude36000).Checked)
						{
							((RadioButton)RB_HighAltitude36000).Checked = true;
						}
						break;
					case ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude:
						if (!((RadioButton)RB_MaxAltitude).Checked)
						{
							((RadioButton)RB_MaxAltitude).Checked = true;
						}
						break;
					}
				}
			}
			else
			{
				switch (((Aircraft)SpeedAlt_SelectedUnit).AI.AltitudePreset)
				{
				default:
					if (((RadioButton)RB_MaxAltitude).Checked)
					{
						((RadioButton)RB_MaxAltitude).Checked = false;
					}
					if (((RadioButton)RB_HighAltitude36000).Checked)
					{
						((RadioButton)RB_HighAltitude36000).Checked = false;
					}
					if (((RadioButton)RB_HighAltitude25000).Checked)
					{
						((RadioButton)RB_HighAltitude25000).Checked = false;
					}
					if (((RadioButton)RB_MediumAltitude12000).Checked)
					{
						((RadioButton)RB_MediumAltitude12000).Checked = false;
					}
					if (((RadioButton)RB_LowAltitude2000).Checked)
					{
						((RadioButton)RB_LowAltitude2000).Checked = false;
					}
					if (((RadioButton)RB_LowAltitude1000).Checked)
					{
						((RadioButton)RB_LowAltitude1000).Checked = false;
					}
					if (((RadioButton)RB_MinAltitude).Checked)
					{
						((RadioButton)RB_MinAltitude).Checked = false;
					}
					if (((RadioButton)RB_NoAltitudePreset).Checked)
					{
						((RadioButton)RB_NoAltitudePreset).Checked = false;
					}
					break;
				case ActiveUnit_AI.AircraftAltitudePreset.None:
					if (!((RadioButton)RB_NoAltitudePreset).Checked)
					{
						((RadioButton)RB_NoAltitudePreset).Checked = true;
					}
					break;
				case ActiveUnit_AI.AircraftAltitudePreset.MinAltitude:
					if (!((RadioButton)RB_MinAltitude).Checked)
					{
						((RadioButton)RB_MinAltitude).Checked = true;
					}
					break;
				case ActiveUnit_AI.AircraftAltitudePreset.Low1000:
					if (!((RadioButton)RB_LowAltitude1000).Checked)
					{
						((RadioButton)RB_LowAltitude1000).Checked = true;
					}
					break;
				case ActiveUnit_AI.AircraftAltitudePreset.Low2000:
					if (!((RadioButton)RB_LowAltitude2000).Checked)
					{
						((RadioButton)RB_LowAltitude2000).Checked = true;
					}
					break;
				case ActiveUnit_AI.AircraftAltitudePreset.const_4:
					if (!((RadioButton)RB_MediumAltitude12000).Checked)
					{
						((RadioButton)RB_MediumAltitude12000).Checked = true;
					}
					break;
				case ActiveUnit_AI.AircraftAltitudePreset.const_5:
					if (!((RadioButton)RB_HighAltitude25000).Checked)
					{
						((RadioButton)RB_HighAltitude25000).Checked = true;
					}
					break;
				case ActiveUnit_AI.AircraftAltitudePreset.const_6:
					if (!((RadioButton)RB_HighAltitude36000).Checked)
					{
						((RadioButton)RB_HighAltitude36000).Checked = true;
					}
					break;
				case ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude:
					if (!((RadioButton)RB_MaxAltitude).Checked)
					{
						((RadioButton)RB_MaxAltitude).Checked = true;
					}
					break;
				}
			}
			if (!SpeedAlt_SelectedUnit.IsSubmarine)
			{
				if (SpeedAlt_SelectedUnit.IsGroup && ((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.SubGroup)
				{
					switch (((Submarine_AI)((Group)SpeedAlt_SelectedUnit).GroupLead.AI).DepthPreset)
					{
					default:
						if (((RadioButton)RB_Surface).Checked)
						{
							((RadioButton)RB_Surface).Checked = false;
						}
						if (((RadioButton)RB_Periscope).Checked)
						{
							((RadioButton)RB_Periscope).Checked = false;
						}
						if (((RadioButton)RB_Shallow).Checked)
						{
							((RadioButton)RB_Shallow).Checked = false;
						}
						if (((RadioButton)RB_OverLayer).Checked)
						{
							((RadioButton)RB_OverLayer).Checked = false;
						}
						if (((RadioButton)RB_UnderLayer).Checked)
						{
							((RadioButton)RB_UnderLayer).Checked = false;
						}
						if (((RadioButton)RB_MaxDepth).Checked)
						{
							((RadioButton)RB_MaxDepth).Checked = false;
						}
						if (((RadioButton)RB_NoDepthPreset).Checked)
						{
							((RadioButton)RB_NoDepthPreset).Checked = false;
						}
						break;
					case ActiveUnit_AI.SubmarineDepthPreset.None:
						if (!((RadioButton)RB_NoDepthPreset).Checked)
						{
							((RadioButton)RB_NoDepthPreset).Checked = true;
						}
						break;
					case ActiveUnit_AI.SubmarineDepthPreset.Periscope:
						if (!((RadioButton)RB_Periscope).Checked)
						{
							((RadioButton)RB_Periscope).Checked = true;
						}
						break;
					case ActiveUnit_AI.SubmarineDepthPreset.Shallow:
						if (!((RadioButton)RB_Shallow).Checked)
						{
							((RadioButton)RB_Shallow).Checked = true;
						}
						break;
					case ActiveUnit_AI.SubmarineDepthPreset.OverLayer:
						if (!((RadioButton)RB_OverLayer).Checked)
						{
							((RadioButton)RB_OverLayer).Checked = true;
						}
						break;
					case ActiveUnit_AI.SubmarineDepthPreset.UnderLayer:
						if (!((RadioButton)RB_UnderLayer).Checked)
						{
							((RadioButton)RB_UnderLayer).Checked = true;
						}
						break;
					case ActiveUnit_AI.SubmarineDepthPreset.MaxDepth:
						if (!((RadioButton)RB_MaxDepth).Checked)
						{
							((RadioButton)RB_MaxDepth).Checked = true;
						}
						break;
					case ActiveUnit_AI.SubmarineDepthPreset.Surface:
						if (!((RadioButton)RB_Surface).Checked)
						{
							((RadioButton)RB_Surface).Checked = true;
						}
						break;
					}
				}
			}
			else
			{
				switch (((Submarine)SpeedAlt_SelectedUnit).AI.DepthPreset)
				{
				default:
					if (((RadioButton)RB_Surface).Checked)
					{
						((RadioButton)RB_Surface).Checked = false;
					}
					if (((RadioButton)RB_Periscope).Checked)
					{
						((RadioButton)RB_Periscope).Checked = false;
					}
					if (((RadioButton)RB_Shallow).Checked)
					{
						((RadioButton)RB_Shallow).Checked = false;
					}
					if (((RadioButton)RB_OverLayer).Checked)
					{
						((RadioButton)RB_OverLayer).Checked = false;
					}
					if (((RadioButton)RB_UnderLayer).Checked)
					{
						((RadioButton)RB_UnderLayer).Checked = false;
					}
					if (((RadioButton)RB_MaxDepth).Checked)
					{
						((RadioButton)RB_MaxDepth).Checked = false;
					}
					if (((RadioButton)RB_NoDepthPreset).Checked)
					{
						((RadioButton)RB_NoDepthPreset).Checked = false;
					}
					break;
				case ActiveUnit_AI.SubmarineDepthPreset.None:
					if (!((RadioButton)RB_NoDepthPreset).Checked)
					{
						((RadioButton)RB_NoDepthPreset).Checked = true;
					}
					break;
				case ActiveUnit_AI.SubmarineDepthPreset.Periscope:
					if (!((RadioButton)RB_Periscope).Checked)
					{
						((RadioButton)RB_Periscope).Checked = true;
					}
					break;
				case ActiveUnit_AI.SubmarineDepthPreset.Shallow:
					if (!((RadioButton)RB_Shallow).Checked)
					{
						((RadioButton)RB_Shallow).Checked = true;
					}
					break;
				case ActiveUnit_AI.SubmarineDepthPreset.OverLayer:
					if (!((RadioButton)RB_OverLayer).Checked)
					{
						((RadioButton)RB_OverLayer).Checked = true;
					}
					break;
				case ActiveUnit_AI.SubmarineDepthPreset.UnderLayer:
					if (!((RadioButton)RB_UnderLayer).Checked)
					{
						((RadioButton)RB_UnderLayer).Checked = true;
					}
					break;
				case ActiveUnit_AI.SubmarineDepthPreset.MaxDepth:
					if (!((RadioButton)RB_MaxDepth).Checked)
					{
						((RadioButton)RB_MaxDepth).Checked = true;
					}
					break;
				case ActiveUnit_AI.SubmarineDepthPreset.Surface:
					if (!((RadioButton)RB_Surface).Checked)
					{
						((RadioButton)RB_Surface).Checked = true;
					}
					break;
				}
			}
			goto IL_4c50;
			IL_4c50:
			method_5();
			MyProject.Forms.MainForm.RightColumnWPF1.WPFControl_AltSpeed.Refresh(TriggeredBySpeedAltForm: true);
			bool_6 = true;
		}
		catch (Exception ex9)
		{
			ProjectData.SetProjectError(ex9);
			Exception ex10 = ex9;
			ex10.Data.Add("Error at 200637", ex10.Message);
			GameGeneral.WriteExceptionsToLog(ex10);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		if (((Control)GroupBox_Waypoint).Visible)
		{
			if (SpeedAlt_SelectedUnit != null && (SpeedAlt_SelectedUnit.IsShip || SpeedAlt_SelectedUnit.IsFacility))
			{
				((Control)this).Height = ((Control)FlowLayoutPanel_SettingsFor).Height + ((Control)GroupBox_Speed).Height + 60 + ((Control)GroupBox_Waypoint).Height;
				((Control)GroupBox_Altitude).Visible = false;
			}
			else
			{
				((Control)this).Height = ((Control)FlowLayoutPanel_SettingsFor).Height + ((Control)GroupBox_Speed).Height + ((Control)GroupBox_Altitude).Height + 70 + ((Control)GroupBox_Waypoint).Height;
				((Control)GroupBox_Altitude).Visible = true;
			}
		}
		else if (SpeedAlt_SelectedUnit != null && (SpeedAlt_SelectedUnit.IsShip || SpeedAlt_SelectedUnit.IsFacility))
		{
			((Control)this).Height = ((Control)FlowLayoutPanel_SettingsFor).Height + ((Control)GroupBox_Speed).Height + 60;
			((Control)GroupBox_Altitude).Visible = false;
		}
		else
		{
			((Control)this).Height = ((Control)FlowLayoutPanel_SettingsFor).Height + ((Control)GroupBox_Speed).Height + ((Control)GroupBox_Altitude).Height + 60;
			((Control)GroupBox_Altitude).Visible = true;
		}
	}

	private void method_5()
	{
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		if (((Control)TrackBar_Altitude).Visible)
		{
			ActiveUnit activeUnit = SpeedAlt_SelectedUnit;
			if (activeUnit.IsGroup)
			{
				activeUnit = ((Group)activeUnit).GroupLead;
			}
			float num = ((Module_Unit.Unit)activeUnit).get_LandElevation(AGL: false, RequestIsFromGUI: true, Force: false, Client.CurrentScenario);
			Weather.WeatherProfile weatherProfile = Weather.get_WeatherAtThisTimeAndPlace(activeUnit.ParentScen, activeUnit.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), (int)Math.Round(activeUnit.get_CurrentAltitude(DoSanityCheck: true, (GlobalVariables.BooleanObject)null)));
			int LayerCeiling = default(int);
			int LayerFloor = default(int);
			float LayerStrengthPercentage = default(float);
			SonarModel.GetThermalLayerAtThisLocation(activeUnit.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), (int)Math.Round(activeUnit.get_CurrentAltitude(DoSanityCheck: true, (GlobalVariables.BooleanObject)null)), ref LayerCeiling, ref LayerFloor, ref LayerStrengthPercentage, RequestIsFromGUI: true, Client.CurrentScenario);
			int top = ((Control)TrackBar_Altitude).Top;
			Padding margin = ((Control)TrackBar_Altitude).Margin;
			double num2 = top + ((Padding)(ref margin)).Top + 10;
			int num3 = ((Control)TrackBar_Altitude).Top + ((Control)TrackBar_Altitude).Height;
			margin = ((Control)TrackBar_Altitude).Margin;
			int num4 = num3 - ((Padding)(ref margin)).Top;
			margin = ((Control)TrackBar_Altitude).Margin;
			double num5 = num4 - ((Padding)(ref margin)).Bottom - 7;
			double num6 = TrackBar_Altitude.Maximum;
			double num7 = TrackBar_Altitude.Minimum;
			double num8 = num6;
			double num9 = num7;
			double num10 = num2;
			double num11 = num5;
			double num12;
			double a;
			if (activeUnit.UnitType == GlobalVariables.ActiveUnitType.Aircraft)
			{
				LineShape1.Visible = true;
				LineShape2.Visible = true;
				if (!(num < 0f || (double)num > num6 || (double)num < num7))
				{
					num12 = num;
					a = num10 + (num11 - num10) * ((num12 - num8) / (num9 - num8));
					((Control)GroundLevelPictureBox).Top = (int)Math.Round((double)(int)Math.Round(a) - (double)((Control)GroundLevelPictureBox).Height / 2.0);
					((Control)GroundLevelPictureBox).Visible = true;
					if (Math.Min(Math.Abs((double)(int)Math.Round(a) - num2), Math.Abs((double)(int)Math.Round(a) - num5)) > 20.0)
					{
						((Control)Label10).Visible = true;
						((Control)Label10).Top = (int)Math.Round((double)(int)Math.Round(a) - (double)((Control)Label10).Height / 2.0 - 1.0);
						((Label)Label10).Text = "Ground Level";
					}
					else
					{
						((Control)Label10).Visible = false;
					}
				}
				else
				{
					((Control)Label10).Visible = false;
					((Control)GroundLevelPictureBox).Visible = false;
				}
				double num13 = 0.0;
				double num14 = 0.0;
				double num15 = 0.0;
				double num16 = 0.0;
				float num17 = (float)((double)weatherProfile.FractionUnderRain - 0.001);
				if (weatherProfile.FractionUnderRain == 0f)
				{
					num17 = 0f;
				}
				if ((double)num17 > 0.9)
				{
					num13 = 36000.0;
					num14 = 7000.0;
					num15 = 2000.0;
					num16 = 1.0;
					((Label)Label11).Text = "Solid Cloud";
					((Label)Label12).Text = "Solid Cloud";
					((Label)Label13).Text = "Thick Fog";
					((Label)Label14).Text = "Thick Fog";
				}
				else if ((double)num17 > 0.8)
				{
					num13 = 36000.0;
					num14 = 7000.0;
					num15 = 2000.0;
					num16 = 1.0;
					((Label)Label11).Text = "Solid Cloud";
					((Label)Label12).Text = "Solid Cloud";
					((Label)Label13).Text = "Thin Fog";
					((Label)Label14).Text = "Thin Fog";
				}
				else if ((double)num17 > 0.7)
				{
					num13 = 36000.0;
					num14 = 30000.0;
					num15 = 16000.0;
					num16 = 7000.0;
					((Label)Label11).Text = "Mod. Cloud";
					((Label)Label12).Text = "Mod. Cloud";
					((Label)Label13).Text = "Solid Cloud";
					((Label)Label14).Text = "Solid Cloud";
				}
				else if ((double)num17 > 0.6)
				{
					num13 = 30000.0;
					num14 = 27000.0;
					num15 = 16000.0;
					num16 = 7000.0;
					((Label)Label11).Text = "Light Cloud";
					((Label)Label12).Text = "Light Cloud";
					((Label)Label13).Text = "Mod. Cloud";
					((Label)Label14).Text = "Mod. Cloud";
				}
				else if ((double)num17 > 0.5)
				{
					num13 = 0.0;
					num14 = 0.0;
					num15 = 28000.0;
					num16 = 25000.0;
					((Label)Label11).Text = "";
					((Label)Label12).Text = "";
					((Label)Label13).Text = "Mod. Cloud";
					((Label)Label14).Text = "Mod. Cloud";
				}
				else if ((double)num17 > 0.4)
				{
					num13 = 0.0;
					num14 = 0.0;
					num15 = 16000.0;
					num16 = 7000.0;
					((Label)Label11).Text = "";
					((Label)Label12).Text = "";
					((Label)Label13).Text = "Mod. Cloud";
					((Label)Label14).Text = "Mod. Cloud";
				}
				else if ((double)num17 > 0.3)
				{
					num13 = 0.0;
					num14 = 0.0;
					num15 = 7000.0;
					num16 = 2000.0;
					((Label)Label11).Text = "";
					((Label)Label12).Text = "";
					((Label)Label13).Text = "Mod. Cloud";
					((Label)Label14).Text = "Mod. Cloud";
				}
				else if ((double)num17 > 0.2)
				{
					num13 = 0.0;
					num14 = 0.0;
					num15 = 23000.0;
					num16 = 20000.0;
					((Label)Label11).Text = "";
					((Label)Label12).Text = "";
					((Label)Label13).Text = "Light Cloud";
					((Label)Label14).Text = "Light Cloud";
				}
				else if ((double)num17 > 0.1)
				{
					num13 = 0.0;
					num14 = 0.0;
					num15 = 16000.0;
					num16 = 10000.0;
					((Label)Label11).Text = "";
					((Label)Label12).Text = "";
					((Label)Label13).Text = "Light Cloud";
					((Label)Label14).Text = "Light Cloud";
				}
				else if ((double)num17 > 0.0)
				{
					num13 = 0.0;
					num14 = 0.0;
					num15 = 7000.0;
					num16 = 5000.0;
					((Label)Label11).Text = "";
					((Label)Label12).Text = "";
					((Label)Label13).Text = "Light Cloud";
					((Label)Label14).Text = "Light Cloud";
				}
				else
				{
					num13 = 0.0;
					num14 = 0.0;
					num15 = 0.0;
					num16 = 0.0;
					((Label)Label11).Text = "";
					((Label)Label12).Text = "";
					((Label)Label12).Text = "";
					((Label)Label13).Text = "";
				}
				double num18 = num13 / 3.2808399200439453;
				double num19 = num14 / 3.2808399200439453;
				double num20 = num15 / 3.2808399200439453;
				double num21 = num16 / 3.2808399200439453;
				num12 = num18;
				a = num10 + (num11 - num10) * ((num12 - num8) / (num9 - num8));
				LineShape1.Y1 = (int)Math.Round(a - (double)((Control)CloudHighTopPictureBox).Height);
				num12 = num19;
				a = num10 + (num11 - num10) * ((num12 - num8) / (num9 - num8));
				LineShape1.Y2 = (int)Math.Round(a - (double)((Control)CloudHighBottomPictureBox).Height);
				num12 = num20;
				a = num10 + (num11 - num10) * ((num12 - num8) / (num9 - num8));
				LineShape2.Y1 = (int)Math.Round(a - (double)((Control)CloudLowTopPictureBox).Height);
				num12 = num21;
				a = num10 + (num11 - num10) * ((num12 - num8) / (num9 - num8));
				LineShape2.Y2 = (int)Math.Round(a - (double)((Control)CloudLowBottomPictureBox).Height);
				if (!(num18 == 0.0 || num18 < (double)num || num18 > num6 || num18 < num7))
				{
					num12 = num18;
					a = num10 + (num11 - num10) * ((num12 - num8) / (num9 - num8));
					((Control)CloudHighTopPictureBox).Top = (int)Math.Round((double)(int)Math.Round(a) - (double)((Control)CloudHighTopPictureBox).Height / 2.0);
					((Control)CloudHighTopPictureBox).Visible = true;
					if (Math.Min(Math.Abs((double)(int)Math.Round(a) - num2), Math.Abs((double)(int)Math.Round(a) - num5)) > 20.0)
					{
						((Control)Label11).Visible = true;
						((Control)Label11).Top = (int)Math.Round((double)(int)Math.Round(a) - (double)((Control)Label11).Height / 2.0 - 1.0);
					}
					else
					{
						((Control)Label11).Visible = false;
					}
				}
				else
				{
					((Control)CloudHighTopPictureBox).Visible = false;
					((Control)Label11).Visible = false;
				}
				if (num19 == 0.0 || num19 < (double)num || num19 > num6 || num19 < num7)
				{
					((Control)CloudHighBottomPictureBox).Visible = false;
					((Control)Label12).Visible = false;
				}
				else
				{
					num12 = num19;
					a = num10 + (num11 - num10) * ((num12 - num8) / (num9 - num8));
					((Control)CloudHighBottomPictureBox).Top = (int)Math.Round((double)(int)Math.Round(a) - (double)((Control)CloudHighBottomPictureBox).Height / 2.0);
					((Control)CloudHighBottomPictureBox).Visible = true;
					if (Math.Min(Math.Abs((double)(int)Math.Round(a) - num2), Math.Abs((double)(int)Math.Round(a) - num5)) > 20.0)
					{
						((Control)Label12).Visible = true;
						((Control)Label12).Top = (int)Math.Round((double)(int)Math.Round(a) - (double)((Control)Label12).Height / 2.0 - 1.0);
					}
					else
					{
						((Control)Label12).Visible = false;
					}
				}
				if (!(num20 == 0.0 || num20 < (double)num || num20 > num6 || num20 < num7))
				{
					num12 = num20;
					a = num10 + (num11 - num10) * ((num12 - num8) / (num9 - num8));
					((Control)CloudLowTopPictureBox).Top = (int)Math.Round((double)(int)Math.Round(a) - (double)((Control)CloudLowTopPictureBox).Height / 2.0);
					((Control)CloudLowTopPictureBox).Visible = true;
					if (Math.Min(Math.Abs((double)(int)Math.Round(a) - num2), Math.Abs((double)(int)Math.Round(a) - num5)) > 20.0)
					{
						((Control)Label13).Visible = true;
						((Control)Label13).Top = (int)Math.Round((double)(int)Math.Round(a) - (double)((Control)Label11).Height / 2.0 - 1.0);
					}
					else
					{
						((Control)Label13).Visible = false;
					}
				}
				else
				{
					((Control)CloudLowTopPictureBox).Visible = false;
					((Control)Label13).Visible = false;
				}
				if (!(num21 == 0.0 || num21 < (double)num || num21 > num6 || num21 < num7))
				{
					num12 = num21;
					a = num10 + (num11 - num10) * ((num12 - num8) / (num9 - num8));
					((Control)CloudLowBottomPictureBox).Top = (int)Math.Round((double)(int)Math.Round(a) - (double)((Control)CloudLowBottomPictureBox).Height / 2.0);
					((Control)CloudLowBottomPictureBox).Visible = true;
					if (Math.Min(Math.Abs((double)(int)Math.Round(a) - num2), Math.Abs((double)(int)Math.Round(a) - num5)) > 20.0)
					{
						((Control)Label14).Visible = true;
						((Control)Label14).Top = (int)Math.Round((double)(int)Math.Round(a) - (double)((Control)Label14).Height / 2.0 - 1.0);
					}
					else
					{
						((Control)Label14).Visible = false;
					}
				}
				else
				{
					((Control)CloudLowBottomPictureBox).Visible = false;
					((Control)Label14).Visible = false;
				}
			}
			else
			{
				((Control)CloudHighBottomPictureBox).Visible = false;
				((Control)CloudHighTopPictureBox).Visible = false;
				((Control)CloudLowBottomPictureBox).Visible = false;
				((Control)CloudLowTopPictureBox).Visible = false;
				((Control)GroundLevelPictureBox).Visible = false;
				LineShape1.Visible = false;
				LineShape2.Visible = false;
				((Control)Label11).Visible = false;
				((Control)Label12).Visible = false;
				((Control)Label10).Visible = false;
				((Control)Label13).Visible = false;
				((Control)Label14).Visible = false;
			}
			if (activeUnit.UnitType != GlobalVariables.ActiveUnitType.Submarine && (activeUnit.UnitType != GlobalVariables.ActiveUnitType.Weapon || !activeUnit.IsTorpedo))
			{
				((Control)SeaFloorPictureBox).Visible = false;
				((Control)LayerTopPictureBox).Visible = false;
				((Control)LayerBottomPictureBox).Visible = false;
				((Control)Label7).Visible = false;
				((Control)Label8).Visible = false;
				((Control)Label9).Visible = false;
				return;
			}
			if (LayerStrengthPercentage == 0f)
			{
				((Control)LayerTopPictureBox).Visible = false;
				((Control)LayerBottomPictureBox).Visible = false;
				((Control)Label7).Visible = false;
				((Control)Label8).Visible = false;
			}
			else
			{
				if (!((float)LayerCeiling < num || (double)LayerCeiling > num6 || (double)LayerCeiling < num7))
				{
					num12 = LayerCeiling;
					a = num10 + (num11 - num10) * ((num12 - num8) / (num9 - num8));
					((Control)LayerTopPictureBox).Top = (int)Math.Round((double)(int)Math.Round(a) - (double)((Control)LayerTopPictureBox).Height / 2.0);
					((Control)LayerTopPictureBox).Visible = true;
					if (Math.Min(Math.Abs((double)(int)Math.Round(a) - num2), Math.Abs((double)(int)Math.Round(a) - num5)) > 20.0)
					{
						((Control)Label7).Visible = true;
						((Control)Label7).Top = (int)Math.Round((double)(int)Math.Round(a) - (double)((Control)Label7).Height / 2.0 - 1.0);
						((Label)Label7).Text = "Layer Ceiling";
					}
					else
					{
						((Control)Label7).Visible = false;
					}
				}
				else
				{
					((Control)LayerTopPictureBox).Visible = false;
					((Control)Label7).Visible = false;
				}
				if (!((float)LayerFloor < num || (double)LayerFloor > num6 || (double)LayerFloor < num7))
				{
					num12 = LayerFloor;
					a = num10 + (num11 - num10) * ((num12 - num8) / (num9 - num8));
					((Control)LayerBottomPictureBox).Top = (int)Math.Round((double)(int)Math.Round(a) - (double)((Control)LayerBottomPictureBox).Height / 2.0);
					((Control)LayerBottomPictureBox).Visible = true;
					if (Math.Min(Math.Abs((double)(int)Math.Round(a) - num2), Math.Abs((double)(int)Math.Round(a) - num5)) > 20.0)
					{
						((Control)Label8).Visible = true;
						((Control)Label8).Top = (int)Math.Round((double)(int)Math.Round(a) - (double)((Control)Label8).Height / 2.0 - 1.0);
						((Label)Label8).Text = "Layer Floor";
					}
					else
					{
						((Control)Label8).Visible = false;
					}
				}
				else
				{
					((Control)LayerBottomPictureBox).Visible = false;
					((Control)Label8).Visible = false;
				}
			}
			if ((double)num < num7 || (double)num > num6 || (double)num < num7)
			{
				((Control)SeaFloorPictureBox).Visible = false;
				((Control)Label9).Visible = false;
				return;
			}
			num12 = num;
			a = num10 + (num11 - num10) * ((num12 - num8) / (num9 - num8));
			((Control)SeaFloorPictureBox).Top = (int)Math.Round((double)(int)Math.Round(a) - (double)((Control)SeaFloorPictureBox).Height / 2.0);
			((Control)SeaFloorPictureBox).Visible = true;
			if (Math.Min(Math.Abs((double)(int)Math.Round(a) - num2), Math.Abs((double)(int)Math.Round(a) - num5)) > 20.0)
			{
				((Control)Label9).Visible = true;
				((Control)Label9).Top = (int)Math.Round((double)(int)Math.Round(a) - (double)((Control)Label9).Height / 2.0 - 1.0);
				((Label)Label9).Text = "Sea Floor";
			}
			else
			{
				((Control)Label9).Visible = false;
			}
		}
		else
		{
			((Control)CloudHighBottomPictureBox).Visible = false;
			((Control)CloudHighTopPictureBox).Visible = false;
			((Control)CloudLowBottomPictureBox).Visible = false;
			((Control)CloudLowTopPictureBox).Visible = false;
			((Control)GroundLevelPictureBox).Visible = false;
			LineShape1.Visible = false;
			LineShape2.Visible = false;
			((Control)Label11).Visible = false;
			((Control)Label12).Visible = false;
			((Control)Label10).Visible = false;
			((Control)Label13).Visible = false;
			((Control)Label14).Visible = false;
			((Control)SeaFloorPictureBox).Visible = false;
			((Control)LayerTopPictureBox).Visible = false;
			((Control)LayerBottomPictureBox).Visible = false;
			((Control)Label7).Visible = false;
			((Control)Label8).Visible = false;
			((Control)Label9).Visible = false;
		}
	}

	private string method_6()
	{
		if (!Information.IsNothing((object)SpeedAlt_SelectedUnit))
		{
			switch (SpeedAlt_SelectedUnit.ThrottleSetting)
			{
			case ActiveUnit.Throttle.FullStop:
				return "Full Stop";
			case ActiveUnit.Throttle.Loiter:
				if (SpeedAlt_SelectedUnit.UseAerialUnitUI)
				{
					return "Loiter";
				}
				return "Creep";
			case ActiveUnit.Throttle.Cruise:
				return "Cruise";
			case ActiveUnit.Throttle.Full:
				if (!SpeedAlt_SelectedUnit.UseAerialUnitUI)
				{
					return "Full";
				}
				return "Military";
			case ActiveUnit.Throttle.Flank:
				if (!SpeedAlt_SelectedUnit.UseAerialUnitUI)
				{
					return "Flank";
				}
				return "Afterburner";
			default:
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				return SpeedAlt_SelectedUnit.ThrottleSetting.ToString();
			case ActiveUnit.Throttle.MaxPossibleThrottle:
			case ActiveUnit.Throttle.MinPossibleThrottle:
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				string result = default(string);
				return result;
			}
			}
		}
		return "-";
	}

	private void method_7(object sender, EventArgs e)
	{
		if (!Client.ShutdownInitiated)
		{
			RefreshForm();
		}
	}

	public void SetThrottlePreset(ActiveUnit_Kinematics.UnitThrottlePreset theThrottle, DarkRadioButton theBox)
	{
		try
		{
			switch (SpeedAltUIMode)
			{
			case SpeedAltMode.Waypoint:
				if (bool_7)
				{
					Client.RealtimeTerminal.SendThrottleAltUI(SelectedUnitObjectID, SelectedWaypointObjectID, SelectedFlightObjectID, null, (byte)theThrottle);
				}
				CoreClientCode.SetWaypointThrottlePreset_Core(Client.SelectedWaypoint, theThrottle);
				break;
			case SpeedAltMode.FlightplanWaypoint:
				if (method_10(ref SpeedAlt_FlightPlanWaypoint))
				{
					if (bool_7)
					{
						Client.RealtimeTerminal.SendThrottleAltUI(SelectedUnitObjectID, SelectedWaypointObjectID, SelectedFlightObjectID, null, (byte)theThrottle);
					}
					CoreClientCode.SetFlightplanWaypointThrottlePreset_Core(SpeedAlt_FlightPlanWaypoint, Client.CurrentScenario, SpeedAlt_Flight, theThrottle);
					Client.MustRefreshMainForm = true;
					if (((Control)Client.FlightPlanEditorWindow).Visible)
					{
						Client.FlightPlanEditorWindow.RefreshGrid();
						Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DisplayLocks();
					}
					break;
				}
				((RadioButton)theBox).Checked = false;
				return;
			case SpeedAltMode.ActiveUnit:
				if (bool_7)
				{
					Client.RealtimeTerminal.SendThrottleAltUI(SelectedUnitObjectID, SelectedWaypointObjectID, SelectedFlightObjectID, null, (byte)theThrottle);
				}
				CoreClientCode.SetUnitThrottlePreset_Core(SpeedAlt_SelectedUnit, theThrottle);
				if (Math.Max(SpeedAlt_SelectedUnit.DesiredSpeed, TrackBar_Throttle.Minimum) > (float)TrackBar_Throttle.Maximum)
				{
					TrackBar_Throttle.Value = TrackBar_Throttle.Maximum;
				}
				else
				{
					TrackBar_Throttle.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredSpeed, TrackBar_Throttle.Minimum));
				}
				break;
			}
			if (!bool_7)
			{
				MyProject.Forms.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, SpeedAlt_SelectedUnit, v: false);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 200637B", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_8(object sender, EventArgs e)
	{
		if (Information.IsNothing((object)SpeedAlt_SelectedUnit) || !bool_6 || !((RadioButton)RB_Stop).Checked)
		{
			return;
		}
		SetThrottlePreset(ActiveUnit_Kinematics.UnitThrottlePreset.FullStop, RB_Stop);
		if (!Information.IsNothing((object)Client.SelectedWaypoint) && Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint))
		{
			Client.SelectedWaypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.FullStop;
			Client.SelectedWaypoint.DesiredSpeed = null;
			Client.SelectedWaypoint.DesiredSpeedOverride = null;
			Client.SelectedWaypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
		}
		else if (!Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint))
		{
			if (!method_10(ref SpeedAlt_FlightPlanWaypoint))
			{
				((RadioButton)RB_Stop).Checked = false;
				return;
			}
			SpeedAlt_FlightPlanWaypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.FullStop;
			SpeedAlt_FlightPlanWaypoint.DesiredSpeed = null;
			SpeedAlt_FlightPlanWaypoint.DesiredSpeedOverride = null;
			SpeedAlt_FlightPlanWaypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
			Scenario currentScenario = Client.CurrentScenario;
			Mission speedAlt_Mission = SpeedAlt_Mission;
			ActiveUnit theAU = SpeedAlt_Flight.get_ReferenceUnit(Client.CurrentScenario);
			Mission.Flight speedAlt_Flight = SpeedAlt_Flight;
			Mission.Flight speedAlt_Flight2;
			Waypoint[] theFlightplan = (speedAlt_Flight2 = SpeedAlt_Flight).FlightPlan;
			float NecessaryFuel = 0f;
			float MissionFuel = 0f;
			MissionPlanner.CalculateFuelQtyAndTimes_And_CheckIfEnoughFuelForFlightPlan(currentScenario, speedAlt_Mission, theAU, speedAlt_Flight, ref theFlightplan, ref NecessaryFuel, ref MissionFuel, RangeCheck: false, RunValidation: true, RunFreeSpeedChecks: true, SetWaypointTimes: true, NewFlightPlan: false, EditLeadWaypoints: true, EditWingmanWaypoints: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, AircraftIsAirborne: false, BananaSplitRedSection: false, SpeedAlt_Mission.TakeOffTime, SpeedAlt_Mission.TimeOnTarget, IsMFP: false);
			speedAlt_Flight2.FlightPlan = theFlightplan;
			Client.MustRefreshMainForm = true;
			if (((Control)Client.FlightPlanEditorWindow).Visible)
			{
				Client.FlightPlanEditorWindow.RefreshGrid();
				Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DisplayLocks();
			}
		}
		else if (!Information.IsNothing((object)SpeedAlt_SelectedUnit))
		{
			SpeedAlt_SelectedUnit.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.FullStop;
			SpeedAlt_SelectedUnit.Kinematics.FollowSpeedPreset();
			TrackBar_Throttle.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredSpeed, TrackBar_Throttle.Minimum));
			SpeedAlt_SelectedUnit.AI.UpdateSpeedAlt_MatchGroupLead();
			MyProject.Forms.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, SpeedAlt_SelectedUnit, v: false);
			SpeedAlt_SelectedUnit.Kinematics.DesiredSpeedOverride = SpeedAlt_SelectedUnit.DesiredSpeed;
		}
	}

	private void method_9(object sender, EventArgs e)
	{
		try
		{
			if (!bool_6 || !((RadioButton)RB_Creep).Checked)
			{
				return;
			}
			SetThrottlePreset(ActiveUnit_Kinematics.UnitThrottlePreset.Loiter, RB_Creep);
			if (!Information.IsNothing((object)Client.SelectedWaypoint) && Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint))
			{
				Client.SelectedWaypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Loiter;
				Client.SelectedWaypoint.DesiredSpeed = null;
				Client.SelectedWaypoint.DesiredSpeedOverride = null;
				Client.SelectedWaypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
			}
			else if (Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint))
			{
				if (!Information.IsNothing((object)SpeedAlt_SelectedUnit))
				{
					SpeedAlt_SelectedUnit.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Loiter;
					SpeedAlt_SelectedUnit.Kinematics.FollowSpeedPreset();
					if (Math.Max(SpeedAlt_SelectedUnit.DesiredSpeed, TrackBar_Throttle.Minimum) > (float)TrackBar_Throttle.Maximum)
					{
						TrackBar_Throttle.Value = TrackBar_Throttle.Maximum;
					}
					else
					{
						TrackBar_Throttle.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredSpeed, TrackBar_Throttle.Minimum));
					}
					SpeedAlt_SelectedUnit.AI.UpdateSpeedAlt_MatchGroupLead();
					MyProject.Forms.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, SpeedAlt_SelectedUnit, v: false);
					SpeedAlt_SelectedUnit.Kinematics.DesiredSpeedOverride = SpeedAlt_SelectedUnit.DesiredSpeed;
				}
			}
			else if (method_10(ref SpeedAlt_FlightPlanWaypoint))
			{
				SpeedAlt_FlightPlanWaypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Loiter;
				SpeedAlt_FlightPlanWaypoint.DesiredSpeed = null;
				SpeedAlt_FlightPlanWaypoint.DesiredSpeedOverride = null;
				SpeedAlt_FlightPlanWaypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
				Scenario currentScenario = Client.CurrentScenario;
				Mission speedAlt_Mission = SpeedAlt_Mission;
				ActiveUnit theAU = SpeedAlt_Flight.get_ReferenceUnit(Client.CurrentScenario);
				Mission.Flight speedAlt_Flight = SpeedAlt_Flight;
				Mission.Flight speedAlt_Flight2;
				Waypoint[] theFlightplan = (speedAlt_Flight2 = SpeedAlt_Flight).FlightPlan;
				float NecessaryFuel = 0f;
				float MissionFuel = 0f;
				MissionPlanner.CalculateFuelQtyAndTimes_And_CheckIfEnoughFuelForFlightPlan(currentScenario, speedAlt_Mission, theAU, speedAlt_Flight, ref theFlightplan, ref NecessaryFuel, ref MissionFuel, RangeCheck: false, RunValidation: true, RunFreeSpeedChecks: true, SetWaypointTimes: true, NewFlightPlan: false, EditLeadWaypoints: true, EditWingmanWaypoints: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, AircraftIsAirborne: false, BananaSplitRedSection: false, SpeedAlt_Mission.TakeOffTime, SpeedAlt_Mission.TimeOnTarget, IsMFP: false);
				speedAlt_Flight2.FlightPlan = theFlightplan;
				Client.MustRefreshMainForm = true;
				if (((Control)Client.FlightPlanEditorWindow).Visible)
				{
					Client.FlightPlanEditorWindow.RefreshGrid();
					Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DisplayLocks();
				}
			}
			else
			{
				((RadioButton)RB_Creep).Checked = false;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 200637D", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private bool method_10(ref Waypoint waypoint_0)
	{
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		int result;
		if (waypoint_0.Category == Waypoint.WaypointCategory.FlightPlan)
		{
			Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
			foreach (Side side in sides_ReadOnly)
			{
				foreach (Mission mission in side.Missions)
				{
					foreach (Mission.Flight flight in mission.FlightList)
					{
						if (flight.FlightPlan.Contains(waypoint_0) && flight.ReferenceUnit_DBID == 0)
						{
							DarkMessageBox.ShowWarning("Waypoints for flightplans with no aircraft type set cannot use throttle presets, only fixed speeds.", string.Empty);
							return false;
						}
					}
				}
			}
			result = 1;
		}
		else
		{
			result = 1;
		}
		return (byte)result != 0;
	}

	private void method_11(object sender, EventArgs e)
	{
		if (bool_6 && ((RadioButton)RB_Cruise).Checked)
		{
			SetThrottlePreset(ActiveUnit_Kinematics.UnitThrottlePreset.Cruise, RB_Cruise);
		}
	}

	private void method_12(object sender, EventArgs e)
	{
		try
		{
			if (!bool_6 || !((RadioButton)RB_Full).Checked)
			{
				return;
			}
			SetThrottlePreset(ActiveUnit_Kinematics.UnitThrottlePreset.Full, RB_Full);
			if (!Information.IsNothing((object)Client.SelectedWaypoint) && Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint))
			{
				Client.SelectedWaypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Full;
				Client.SelectedWaypoint.DesiredSpeed = null;
				Client.SelectedWaypoint.DesiredSpeedOverride = null;
				Client.SelectedWaypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
				return;
			}
			if (Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint))
			{
				if (!Information.IsNothing((object)SpeedAlt_SelectedUnit))
				{
					SpeedAlt_SelectedUnit.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Full;
					SpeedAlt_SelectedUnit.Kinematics.FollowSpeedPreset();
					if (Math.Max(SpeedAlt_SelectedUnit.DesiredSpeed, TrackBar_Throttle.Minimum) > (float)TrackBar_Throttle.Maximum)
					{
						TrackBar_Throttle.Value = TrackBar_Throttle.Maximum;
					}
					else
					{
						TrackBar_Throttle.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredSpeed, TrackBar_Throttle.Minimum));
					}
					SpeedAlt_SelectedUnit.AI.UpdateSpeedAlt_MatchGroupLead();
					MyProject.Forms.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, SpeedAlt_SelectedUnit, v: false);
					SpeedAlt_SelectedUnit.Kinematics.DesiredSpeedOverride = SpeedAlt_SelectedUnit.DesiredSpeed;
				}
				return;
			}
			if (!method_10(ref SpeedAlt_FlightPlanWaypoint))
			{
				((RadioButton)RB_Full).Checked = false;
				return;
			}
			SpeedAlt_FlightPlanWaypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Full;
			SpeedAlt_FlightPlanWaypoint.DesiredSpeed = null;
			SpeedAlt_FlightPlanWaypoint.DesiredSpeedOverride = null;
			SpeedAlt_FlightPlanWaypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
			Scenario currentScenario = Client.CurrentScenario;
			Mission speedAlt_Mission = SpeedAlt_Mission;
			ActiveUnit theAU = SpeedAlt_Flight.get_ReferenceUnit(Client.CurrentScenario);
			Mission.Flight speedAlt_Flight = SpeedAlt_Flight;
			Mission.Flight speedAlt_Flight2;
			Waypoint[] theFlightplan = (speedAlt_Flight2 = SpeedAlt_Flight).FlightPlan;
			float NecessaryFuel = 0f;
			float MissionFuel = 0f;
			MissionPlanner.CalculateFuelQtyAndTimes_And_CheckIfEnoughFuelForFlightPlan(currentScenario, speedAlt_Mission, theAU, speedAlt_Flight, ref theFlightplan, ref NecessaryFuel, ref MissionFuel, RangeCheck: false, RunValidation: true, RunFreeSpeedChecks: true, SetWaypointTimes: true, NewFlightPlan: false, EditLeadWaypoints: true, EditWingmanWaypoints: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, AircraftIsAirborne: false, BananaSplitRedSection: false, SpeedAlt_Mission.TakeOffTime, SpeedAlt_Mission.TimeOnTarget, IsMFP: false);
			speedAlt_Flight2.FlightPlan = theFlightplan;
			Client.MustRefreshMainForm = true;
			if (((Control)Client.FlightPlanEditorWindow).Visible)
			{
				Client.FlightPlanEditorWindow.RefreshGrid();
				Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DisplayLocks();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 200637E", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_13(object sender, EventArgs e)
	{
		if (bool_6 && ((RadioButton)RB_NoThrottlePreset).Checked)
		{
			SetThrottlePreset(ActiveUnit_Kinematics.UnitThrottlePreset.None, RB_NoThrottlePreset);
		}
	}

	private void method_14(object sender, EventArgs e)
	{
		try
		{
			if (!bool_6 || !((RadioButton)RB_Flank).Checked)
			{
				return;
			}
			SetThrottlePreset(ActiveUnit_Kinematics.UnitThrottlePreset.Flank, RB_Flank);
			if (!Information.IsNothing((object)Client.SelectedWaypoint) && Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint))
			{
				Client.SelectedWaypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Flank;
				Client.SelectedWaypoint.DesiredSpeed = null;
				Client.SelectedWaypoint.DesiredSpeedOverride = null;
				Client.SelectedWaypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
			}
			else if (!Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint))
			{
				if (method_10(ref SpeedAlt_FlightPlanWaypoint))
				{
					SpeedAlt_FlightPlanWaypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Flank;
					SpeedAlt_FlightPlanWaypoint.DesiredSpeed = null;
					SpeedAlt_FlightPlanWaypoint.DesiredSpeedOverride = null;
					SpeedAlt_FlightPlanWaypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
					Scenario currentScenario = Client.CurrentScenario;
					Mission speedAlt_Mission = SpeedAlt_Mission;
					ActiveUnit theAU = SpeedAlt_Flight.get_ReferenceUnit(Client.CurrentScenario);
					Mission.Flight speedAlt_Flight = SpeedAlt_Flight;
					Mission.Flight speedAlt_Flight2;
					Waypoint[] theFlightplan = (speedAlt_Flight2 = SpeedAlt_Flight).FlightPlan;
					float NecessaryFuel = 0f;
					float MissionFuel = 0f;
					MissionPlanner.CalculateFuelQtyAndTimes_And_CheckIfEnoughFuelForFlightPlan(currentScenario, speedAlt_Mission, theAU, speedAlt_Flight, ref theFlightplan, ref NecessaryFuel, ref MissionFuel, RangeCheck: false, RunValidation: true, RunFreeSpeedChecks: true, SetWaypointTimes: true, NewFlightPlan: false, EditLeadWaypoints: true, EditWingmanWaypoints: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, AircraftIsAirborne: false, BananaSplitRedSection: false, SpeedAlt_Mission.TakeOffTime, SpeedAlt_Mission.TimeOnTarget, IsMFP: false);
					speedAlt_Flight2.FlightPlan = theFlightplan;
					Client.MustRefreshMainForm = true;
					if (((Control)Client.FlightPlanEditorWindow).Visible)
					{
						Client.FlightPlanEditorWindow.RefreshGrid();
						Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DisplayLocks();
					}
				}
				else
				{
					((RadioButton)RB_Flank).Checked = false;
				}
			}
			else if (!Information.IsNothing((object)SpeedAlt_SelectedUnit))
			{
				SpeedAlt_SelectedUnit.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Flank;
				SpeedAlt_SelectedUnit.Kinematics.FollowSpeedPreset();
				if (Math.Max(SpeedAlt_SelectedUnit.DesiredSpeed, TrackBar_Throttle.Minimum) > (float)TrackBar_Throttle.Maximum)
				{
					TrackBar_Throttle.Value = TrackBar_Throttle.Maximum;
				}
				else
				{
					TrackBar_Throttle.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredSpeed, TrackBar_Throttle.Minimum));
				}
				SpeedAlt_SelectedUnit.AI.UpdateSpeedAlt_MatchGroupLead();
				MyProject.Forms.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, SpeedAlt_SelectedUnit, v: false);
				SpeedAlt_SelectedUnit.Kinematics.DesiredSpeedOverride = SpeedAlt_SelectedUnit.DesiredSpeed;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 200637F", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_15(object sender, EventArgs e)
	{
		try
		{
			if (SpeedAlt_SelectedUnit != null)
			{
				if (bool_7)
				{
					Client.RealtimeTerminal.SendThrottleAltUI(SelectedUnitObjectID, null, "", TrackBar_Throttle.Value);
				}
				CoreClientCode.SetUnitDesiredSpeed_Core(SpeedAlt_SelectedUnit, TrackBar_Throttle.Value);
				UpdateSpeedValues();
				MyProject.Forms.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, SpeedAlt_SelectedUnit, v: false);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 200637G", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_16(object sender, EventArgs e)
	{
		try
		{
			if (SpeedAlt_SelectedUnit != null)
			{
				if (bool_7)
				{
					Client.RealtimeTerminal.SendThrottleAltUI(SelectedUnitObjectID, null, "", null, null, null, null, TrackBar_Altitude.Value);
				}
				CoreClientCode.SetUnitDesiredAltitude_Core(SpeedAlt_SelectedUnit, TrackBar_Altitude.Value);
				UpdateAltitudeDepthValues();
				MyProject.Forms.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, SpeedAlt_SelectedUnit, v: false);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 200637H", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal void UpdateAltitudeDepthValues(bool usePreset = false)
	{
		if ((Information.IsNothing((object)SpeedAlt_SelectedUnit) & Information.IsNothing((object)Client.SelectedWaypoint)) && Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint))
		{
			return;
		}
		if (SpeedAlt_SelectedUnit == null && SpeedAlt_FlightPlanWaypoint == null)
		{
			Module_Unit.Unit selectedUnit = Client.SelectedUnit;
			if (selectedUnit != null && selectedUnit.IsActiveUnit)
			{
				SpeedAlt_SelectedUnit = (ActiveUnit)Client.SelectedUnit;
			}
		}
		if (usePreset && SpeedAlt_SelectedUnit != null)
		{
			if (Information.IsNothing((object)Client.SelectedWaypoint))
			{
				if (!Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint))
				{
					if (((RadioButton)RB_MaxAltitude).Checked)
					{
						Client.SelectedWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude;
					}
					if (((RadioButton)RB_HighAltitude36000).Checked)
					{
						Client.SelectedWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.const_6;
					}
					if (((RadioButton)RB_HighAltitude25000).Checked)
					{
						Client.SelectedWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.const_5;
					}
					if (((RadioButton)RB_MediumAltitude12000).Checked)
					{
						Client.SelectedWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.const_4;
					}
					if (((RadioButton)RB_LowAltitude2000).Checked)
					{
						Client.SelectedWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.Low2000;
					}
					if (((RadioButton)RB_LowAltitude1000).Checked)
					{
						Client.SelectedWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.Low1000;
					}
					if (((RadioButton)RB_MinAltitude).Checked)
					{
						Client.SelectedWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.MinAltitude;
					}
					SpeedAlt_FlightPlanWaypoint.DesiredAltitudeOverride = false;
				}
			}
			else if (!SpeedAlt_SelectedUnit.UseAerialUnitUI)
			{
				if (SpeedAlt_SelectedUnit.UseSubmerisbleUnitUI)
				{
					if (((RadioButton)RB_Surface).Checked)
					{
						Client.SelectedWaypoint.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.Surface;
					}
					if (((RadioButton)RB_Periscope).Checked)
					{
						Client.SelectedWaypoint.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.Periscope;
					}
					if (((RadioButton)RB_Shallow).Checked)
					{
						Client.SelectedWaypoint.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.Shallow;
					}
					if (((RadioButton)RB_OverLayer).Checked)
					{
						Client.SelectedWaypoint.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.OverLayer;
					}
					if (((RadioButton)RB_UnderLayer).Checked)
					{
						Client.SelectedWaypoint.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.UnderLayer;
					}
					if (((RadioButton)RB_MaxDepth).Checked)
					{
						Client.SelectedWaypoint.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.MaxDepth;
					}
					Client.SelectedWaypoint.FollowDepthPreset(Client.CurrentScenario);
					if (Client.SelectedWaypoint.DepthPreset == ActiveUnit_AI.SubmarineDepthPreset.MaxDepth)
					{
						Client.SelectedWaypoint.DesiredAltitude = SpeedAlt_SelectedUnit.Kinematics.GetMinimumAltitude();
					}
				}
			}
			else
			{
				if (((RadioButton)RB_MaxAltitude).Checked)
				{
					Client.SelectedWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude;
				}
				if (((RadioButton)RB_HighAltitude36000).Checked)
				{
					Client.SelectedWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.const_6;
				}
				if (((RadioButton)RB_HighAltitude25000).Checked)
				{
					Client.SelectedWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.const_5;
				}
				if (((RadioButton)RB_MediumAltitude12000).Checked)
				{
					Client.SelectedWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.const_4;
				}
				if (((RadioButton)RB_LowAltitude2000).Checked)
				{
					Client.SelectedWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.Low2000;
				}
				if (((RadioButton)RB_LowAltitude1000).Checked)
				{
					Client.SelectedWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.Low1000;
				}
				if (((RadioButton)RB_MinAltitude).Checked)
				{
					Client.SelectedWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.MinAltitude;
				}
				Client.SelectedWaypoint.FollowAltitudePreset();
			}
		}
		if (!Information.IsNothing((object)Client.SelectedWaypoint) && Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint))
		{
			Client.SelectedWaypoint.DesiredAltitudeOverride = true;
		}
		else if (Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint))
		{
			if (!Information.IsNothing((object)SpeedAlt_SelectedUnit))
			{
				SpeedAlt_SelectedUnit.Kinematics.DesiredAltitudeOverride = true;
			}
		}
		else
		{
			SpeedAlt_FlightPlanWaypoint.DesiredAltitudeOverride = true;
		}
		if (!Information.IsNothing((object)SpeedAlt_SelectedUnit))
		{
			SpeedAlt_SelectedUnit.AI.UpdateSpeedAlt_MatchGroupLead();
		}
		((CheckBox)CB_AltOverride).Checked = true;
		if (!Information.IsNothing((object)SpeedAlt_SelectedUnit))
		{
			MyProject.Forms.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, SpeedAlt_SelectedUnit, v: false);
		}
	}

	internal void UpdateSpeedValues()
	{
		method_17();
		((CheckBox)CB_SpeedOverride).Checked = true;
		if (!Information.IsNothing((object)SpeedAlt_SelectedUnit))
		{
			MyProject.Forms.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, SpeedAlt_SelectedUnit, v: false);
		}
	}

	private void method_17()
	{
		method_4();
	}

	private void method_18()
	{
		method_3();
		method_2();
	}

	public void SetDepthPreset(ActiveUnit_AI.SubmarineDepthPreset theDepth)
	{
		try
		{
			if (bool_7)
			{
				Client.RealtimeTerminal.SendThrottleAltUI(SelectedUnitObjectID, SelectedWaypointObjectID, SelectedFlightObjectID, null, null, null, (byte)theDepth);
			}
			switch (SpeedAltUIMode)
			{
			case SpeedAltMode.Waypoint:
				CoreClientCode.SetWaypointDepthPreset_Core(Client.SelectedWaypoint, Client.CurrentScenario, SpeedAlt_SelectedUnit, theDepth);
				break;
			case SpeedAltMode.FlightplanWaypoint:
				CoreClientCode.SetFlightplanWaypointDepthPreset_Core(SpeedAlt_FlightPlanWaypoint, Client.CurrentScenario, theDepth);
				break;
			case SpeedAltMode.ActiveUnit:
				CoreClientCode.SetUnitDepthPreset_Core(SpeedAlt_SelectedUnit, theDepth);
				TrackBar_Altitude.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredAltitude, TrackBar_Altitude.Minimum));
				break;
			}
			MyProject.Forms.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, SpeedAlt_SelectedUnit, v: false);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 200637J", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_19()
	{
		try
		{
			if (bool_7)
			{
				Client.RealtimeTerminal.SendThrottleAltUI(SelectedUnitObjectID, SelectedWaypointObjectID, SelectedFlightObjectID, null, null, null, 0);
			}
			switch (SpeedAltUIMode)
			{
			case SpeedAltMode.FlightplanWaypoint:
				CoreClientCode.ClearWaypointDepthPreset_Core(SpeedAlt_FlightPlanWaypoint);
				break;
			case SpeedAltMode.Waypoint:
				CoreClientCode.ClearWaypointDepthPreset_Core(Client.SelectedWaypoint);
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 200637K", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_20(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)SpeedAlt_SelectedUnit) && bool_6 && (!Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint) || SpeedAlt_SelectedUnit.IsSubmarine || (SpeedAlt_SelectedUnit.IsGroup && ((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.SubGroup)) && ((RadioButton)RB_Surface).Checked)
		{
			SetDepthPreset(ActiveUnit_AI.SubmarineDepthPreset.Surface);
		}
	}

	private void method_21(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)SpeedAlt_SelectedUnit) && bool_6 && (!Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint) || SpeedAlt_SelectedUnit.IsSubmarine || (SpeedAlt_SelectedUnit.IsGroup && ((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.SubGroup)) && ((RadioButton)RB_Periscope).Checked)
		{
			SetDepthPreset(ActiveUnit_AI.SubmarineDepthPreset.Periscope);
		}
	}

	private void method_22(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)SpeedAlt_SelectedUnit) && bool_6 && (!Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint) || SpeedAlt_SelectedUnit.IsSubmarine || (SpeedAlt_SelectedUnit.IsGroup && ((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.SubGroup)) && ((RadioButton)RB_Shallow).Checked)
		{
			SetDepthPreset(ActiveUnit_AI.SubmarineDepthPreset.Shallow);
		}
	}

	private void method_23(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)SpeedAlt_SelectedUnit) && bool_6 && (!Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint) || SpeedAlt_SelectedUnit.IsSubmarine || (SpeedAlt_SelectedUnit.IsGroup && ((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.SubGroup)) && ((RadioButton)RB_OverLayer).Checked)
		{
			SetDepthPreset(ActiveUnit_AI.SubmarineDepthPreset.OverLayer);
		}
	}

	private void HofLeFobUhR(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)SpeedAlt_SelectedUnit) && bool_6 && (!Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint) || SpeedAlt_SelectedUnit.IsSubmarine || (SpeedAlt_SelectedUnit.IsGroup && ((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.SubGroup)) && ((RadioButton)RB_UnderLayer).Checked)
		{
			SetDepthPreset(ActiveUnit_AI.SubmarineDepthPreset.UnderLayer);
		}
	}

	private void method_24(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)SpeedAlt_SelectedUnit) && bool_6 && (!Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint) || SpeedAlt_SelectedUnit.IsSubmarine || (SpeedAlt_SelectedUnit.IsGroup && ((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.SubGroup)) && ((RadioButton)RB_MaxDepth).Checked)
		{
			SetDepthPreset(ActiveUnit_AI.SubmarineDepthPreset.MaxDepth);
		}
	}

	private void method_25(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)SpeedAlt_SelectedUnit) && bool_6 && (!Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint) || SpeedAlt_SelectedUnit.IsSubmarine || (SpeedAlt_SelectedUnit.IsGroup && ((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.SubGroup)) && ((RadioButton)RB_NoDepthPreset).Checked)
		{
			method_19();
		}
	}

	public void SetAltitudePreset(ActiveUnit_AI.AircraftAltitudePreset theAltitude)
	{
		try
		{
			if (bool_7)
			{
				Client.RealtimeTerminal.SendThrottleAltUI(SelectedUnitObjectID, SelectedWaypointObjectID, SelectedFlightObjectID, null, null, (byte)theAltitude);
			}
			switch (SpeedAltUIMode)
			{
			case SpeedAltMode.Waypoint:
				CoreClientCode.SetWaypointAltitudePreset_Core(Client.SelectedWaypoint, SpeedAlt_SelectedUnit, theAltitude);
				break;
			case SpeedAltMode.FlightplanWaypoint:
				CoreClientCode.SetFlightplanWaypointAltitudePreset_Core(SpeedAlt_FlightPlanWaypoint, theAltitude);
				break;
			case SpeedAltMode.ActiveUnit:
				CoreClientCode.SetUnitAltitudePreset_Core(SpeedAlt_SelectedUnit, theAltitude);
				TrackBar_Altitude.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredAltitude, TrackBar_Altitude.Minimum));
				break;
			}
			MyProject.Forms.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, SpeedAlt_SelectedUnit, v: false);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 200637M", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_26()
	{
		try
		{
			if (bool_7)
			{
				Client.RealtimeTerminal.SendThrottleAltUI(SelectedUnitObjectID, SelectedWaypointObjectID, SelectedFlightObjectID, null, null, 0);
			}
			switch (SpeedAltUIMode)
			{
			case SpeedAltMode.FlightplanWaypoint:
				CoreClientCode.ClearWaypointAltitudePreset_Core(SpeedAlt_FlightPlanWaypoint);
				break;
			case SpeedAltMode.Waypoint:
				CoreClientCode.ClearWaypointAltitudePreset_Core(Client.SelectedWaypoint);
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 200637N", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_27(object sender, EventArgs e)
	{
		if ((!Information.IsNothing((object)SpeedAlt_SelectedUnit) || !Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint)) && bool_6 && (SpeedAlt_FlightPlanWaypoint != null || SpeedAlt_SelectedUnit.SupportsAltitude_Control) && ((RadioButton)RB_MaxAltitude).Checked)
		{
			SetAltitudePreset(ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude);
		}
	}

	private void method_28(object sender, EventArgs e)
	{
		if ((!Information.IsNothing((object)SpeedAlt_SelectedUnit) || !Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint)) && bool_6 && (SpeedAlt_FlightPlanWaypoint != null || SpeedAlt_SelectedUnit.SupportsAltitude_Control) && ((RadioButton)RB_NoAltitudePreset).Checked)
		{
			method_26();
		}
	}

	private void method_29(object sender, EventArgs e)
	{
		if ((!Information.IsNothing((object)SpeedAlt_SelectedUnit) || !Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint)) && bool_6 && (SpeedAlt_FlightPlanWaypoint != null || SpeedAlt_SelectedUnit.SupportsAltitude_Control) && ((RadioButton)RB_HighAltitude36000).Checked)
		{
			SetAltitudePreset(ActiveUnit_AI.AircraftAltitudePreset.const_6);
		}
	}

	private void method_30(object sender, EventArgs e)
	{
		if ((!Information.IsNothing((object)SpeedAlt_SelectedUnit) || !Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint)) && bool_6 && (SpeedAlt_FlightPlanWaypoint != null || SpeedAlt_SelectedUnit.SupportsAltitude_Control) && ((RadioButton)RB_HighAltitude25000).Checked)
		{
			SetAltitudePreset(ActiveUnit_AI.AircraftAltitudePreset.const_5);
		}
	}

	private void method_31(object sender, EventArgs e)
	{
		if ((!Information.IsNothing((object)SpeedAlt_SelectedUnit) || !Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint)) && bool_6 && (SpeedAlt_FlightPlanWaypoint != null || SpeedAlt_SelectedUnit.SupportsAltitude_Control) && ((RadioButton)RB_MediumAltitude12000).Checked)
		{
			SetAltitudePreset(ActiveUnit_AI.AircraftAltitudePreset.const_4);
		}
	}

	private void method_32(object sender, EventArgs e)
	{
		if ((SpeedAlt_SelectedUnit != null || !Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint)) && bool_6 && (SpeedAlt_FlightPlanWaypoint != null || SpeedAlt_SelectedUnit.SupportsAltitude_Control) && ((RadioButton)RB_LowAltitude2000).Checked)
		{
			SetAltitudePreset(ActiveUnit_AI.AircraftAltitudePreset.Low2000);
		}
	}

	private void method_33(object sender, EventArgs e)
	{
		if ((!Information.IsNothing((object)SpeedAlt_SelectedUnit) || !Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint)) && bool_6 && (SpeedAlt_FlightPlanWaypoint != null || SpeedAlt_SelectedUnit.SupportsAltitude_Control) && ((RadioButton)RB_LowAltitude1000).Checked)
		{
			SetAltitudePreset(ActiveUnit_AI.AircraftAltitudePreset.Low1000);
		}
	}

	private void method_34(object sender, EventArgs e)
	{
		if ((!Information.IsNothing((object)SpeedAlt_SelectedUnit) || !Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint)) && bool_6 && (SpeedAlt_FlightPlanWaypoint != null || SpeedAlt_SelectedUnit.SupportsAltitude_Control) && ((RadioButton)RB_MinAltitude).Checked)
		{
			SetAltitudePreset(ActiveUnit_AI.AircraftAltitudePreset.MinAltitude);
		}
	}

	private void method_35(object sender, EventArgs e)
	{
		bool_3 = true;
	}

	private void method_36(object sender, EventArgs e)
	{
		method_38();
	}

	private void method_37(object sender, EventArgs e)
	{
		bool_4 = true;
	}

	private void method_38()
	{
		try
		{
			if (bool_3)
			{
				method_17();
				bool flag = Operators.CompareString(TextBox_EnterSpeed.Text, "", true) == 0;
				bool flag2 = false;
				float num = 0f;
				if (Versioned.IsNumeric((object)TextBox_EnterSpeed.Text))
				{
					int result = 0;
					if (int.TryParse(TextBox_EnterSpeed.Text, out result))
					{
						flag2 = true;
						num = result;
					}
				}
				if (bool_7)
				{
					if (!flag)
					{
						if (flag2)
						{
							Client.RealtimeTerminal.SendThrottleAltUI(SelectedUnitObjectID, SelectedWaypointObjectID, SelectedFlightObjectID, num);
						}
					}
					else
					{
						Client.RealtimeTerminal.SendThrottleAltUI(SelectedUnitObjectID, SelectedWaypointObjectID, SelectedFlightObjectID, null, null, null, null, null, null, null, null, null, null, null, null, true);
					}
				}
				if (flag)
				{
					switch (SpeedAltUIMode)
					{
					case SpeedAltMode.FlightplanWaypoint:
						CoreClientCode.ClearWaypointDesiredSpeed_Core(SpeedAlt_FlightPlanWaypoint);
						((CheckBox)CB_SpeedOverride).Checked = false;
						break;
					case SpeedAltMode.Waypoint:
						CoreClientCode.ClearWaypointDesiredSpeed_Core(Client.SelectedWaypoint);
						((CheckBox)CB_SpeedOverride).Checked = false;
						break;
					}
				}
				else if (flag2)
				{
					switch (SpeedAltUIMode)
					{
					case SpeedAltMode.Waypoint:
						CoreClientCode.SetWaypointDesiredSpeed_Core(Client.SelectedWaypoint, num);
						break;
					case SpeedAltMode.FlightplanWaypoint:
						CoreClientCode.SetFlightplanWaypointDesiredSpeed_Core(SpeedAlt_FlightPlanWaypoint, Client.CurrentScenario, SpeedAlt_Flight, num);
						break;
					case SpeedAltMode.ActiveUnit:
						CoreClientCode.SetUnitDesiredSpeed_Core(SpeedAlt_SelectedUnit, num);
						break;
					}
				}
			}
			bool_3 = false;
			RefreshForm();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 200637P", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_39(object sender, EventArgs e)
	{
		method_40();
	}

	private void method_40()
	{
		//IL_0408: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (bool_4)
			{
				method_18();
				bool flag = Operators.CompareString(TextBox_EnterAltitude.Text, "", true) == 0;
				bool flag2 = false;
				float num = 0f;
				if (!flag && Versioned.IsNumeric((object)TextBox_EnterAltitude.Text))
				{
					int result = 0;
					if (int.TryParse(TextBox_EnterAltitude.Text, out result))
					{
						flag2 = true;
						num = result;
						if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
						{
							num *= 0.3048f;
						}
					}
				}
				if (bool_7)
				{
					if (flag)
					{
						Client.RealtimeTerminal.SendThrottleAltUI(SelectedUnitObjectID, SelectedWaypointObjectID, SelectedFlightObjectID, null, null, null, null, null, null, null, null, null, null, null, null, null, true);
					}
					else if (flag2)
					{
						Client.RealtimeTerminal.SendThrottleAltUI(SelectedUnitObjectID, SelectedWaypointObjectID, SelectedFlightObjectID, null, null, null, null, num);
					}
				}
				if (flag)
				{
					switch (SpeedAltUIMode)
					{
					case SpeedAltMode.FlightplanWaypoint:
						CoreClientCode.ClearWaypointDesiredAltitude_Core(SpeedAlt_FlightPlanWaypoint);
						break;
					case SpeedAltMode.Waypoint:
						CoreClientCode.ClearWaypointDesiredAltitude_Core(Client.SelectedWaypoint);
						break;
					}
				}
				else if (flag2)
				{
					string text = "";
					if (Client.SelectedWaypoint != null && ((Client.SelectedWaypoint.Type == Waypoint.WaypointType.InitialPoint) | ((Client.SelectedWaypoint.Type == Waypoint.WaypointType.Target) & (Client.SelectedWaypoint.ReferenceWeapon_ID != 0))) && SpeedAlt_Mission != null && SpeedAlt_Mission.MissionClass == Mission._MissionClass.Strike)
					{
						Scenario theScen = Client.CurrentScenario;
						Weapon newWeapon = Weapon.GetNewWeapon(ref theScen, Client.SelectedWaypoint.ReferenceWeapon_ID, bool_5: false);
						string text2 = "m";
						float num2 = 1f;
						if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
						{
							num2 = 3.28084f;
							text2 = "ft";
						}
						if (num < newWeapon.MinLaunchAlt_AGL)
						{
							text = " Weapon " + newWeapon.Name + " cannot be launch at " + Math.Round(num * num2) + " " + text2 + " minimum launch altitude is " + Math.Round(newWeapon.MinLaunchAlt_AGL * num2) + " " + text2;
						}
						else if ((num > newWeapon.MaxLaunchAlt_AGL) & (newWeapon.MaxLaunchAlt_AGL != 0f))
						{
							text = " Weapon " + newWeapon.Name + " cannot be launch at " + Math.Round(num * num2) + " " + text2 + " maximum launch altitude is " + Math.Round(newWeapon.MaxLaunchAlt_AGL * num2) + " " + text2;
						}
					}
					if (Operators.CompareString(text, "", true) != 0)
					{
						DarkMessageBox.ShowWarning(text, "Weapon Altitude Error");
						TextBox_EnterAltitude.Focus();
						bool_9 = true;
						return;
					}
					switch (SpeedAltUIMode)
					{
					case SpeedAltMode.Waypoint:
						CoreClientCode.SetWaypointDesiredAltitude_Core(Client.SelectedWaypoint, num);
						break;
					case SpeedAltMode.FlightplanWaypoint:
						CoreClientCode.SetWaypointDesiredAltitude_Core(SpeedAlt_FlightPlanWaypoint, num);
						break;
					case SpeedAltMode.ActiveUnit:
						CoreClientCode.SetUnitDesiredAltitude_Core(SpeedAlt_SelectedUnit, num);
						break;
					}
				}
			}
			bool_4 = false;
			RefreshForm();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 200637Q", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void SpeedAlt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Invalid comparison between Unknown and I4
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Invalid comparison between Unknown and I4
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Invalid comparison between Unknown and I4
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Invalid comparison between Unknown and I4
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Invalid comparison between Unknown and I4
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Invalid comparison between Unknown and I4
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Invalid comparison between Unknown and I4
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Invalid comparison between Unknown and I4
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Invalid comparison between Unknown and I4
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Invalid comparison between Unknown and I4
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Invalid comparison between Unknown and I4
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Invalid comparison between Unknown and I4
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Invalid comparison between Unknown and I4
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Invalid comparison between Unknown and I4
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Invalid comparison between Unknown and I4
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Invalid comparison between Unknown and I4
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Invalid comparison between Unknown and I4
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
		else if ((int)e.KeyCode == 113 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
		else if (!((Control)this).Visible || ((int)e.KeyCode != 38 && (int)e.KeyCode != 40 && (int)e.KeyCode != 37 && (int)e.KeyCode != 39 && (int)e.KeyCode != 32))
		{
			if ((bool_3 || bool_4 || bool_5) && ((int)e.KeyCode == 112 || (int)e.KeyCode == 113 || (int)e.KeyCode == 114 || (int)e.KeyCode == 115 || (int)e.KeyCode == 116 || (int)e.KeyCode == 117 || (int)e.KeyCode == 118 || (int)e.KeyCode == 119 || (int)e.KeyCode == 120 || (int)e.KeyCode == 121 || (int)e.KeyCode == 122 || (int)e.KeyCode == 123))
			{
				MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
			}
			if (!bool_4 && !bool_3 && !bool_5)
			{
				MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
			}
		}
	}

	public void CB_AltOverride_Click(object sender, EventArgs e)
	{
		try
		{
			if (bool_6 && (!Information.IsNothing((object)SpeedAlt_SelectedUnit) || !Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint)))
			{
				if (bool_7)
				{
					Client.RealtimeTerminal.SendThrottleAltUI(SelectedUnitObjectID, SelectedWaypointObjectID, SelectedFlightObjectID, null, null, null, null, null, null, null, null, null, ((CheckBox)CB_AltOverride).Checked);
				}
				switch (SpeedAltUIMode)
				{
				case SpeedAltMode.Waypoint:
					CoreClientCode.SetWaypointAltitudeOverride_Core(Client.SelectedWaypoint, ((CheckBox)CB_AltOverride).Checked);
					break;
				case SpeedAltMode.FlightplanWaypoint:
					CoreClientCode.SetWaypointAltitudeOverride_Core(SpeedAlt_FlightPlanWaypoint, ((CheckBox)CB_AltOverride).Checked);
					break;
				case SpeedAltMode.ActiveUnit:
					CoreClientCode.SetUnitAltitudeOverride_Core(SpeedAlt_SelectedUnit, ((CheckBox)CB_AltOverride).Checked);
					MyProject.Forms.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, SpeedAlt_SelectedUnit, v: false);
					break;
				}
				RefreshForm();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 200637R", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void CB_SpeedOverride_Click(object sender, EventArgs e)
	{
		try
		{
			if (!bool_6 || (Information.IsNothing((object)SpeedAlt_SelectedUnit) && Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint)))
			{
				return;
			}
			if (bool_7)
			{
				Client.RealtimeTerminal.SendThrottleAltUI(SelectedUnitObjectID, SelectedWaypointObjectID, SelectedFlightObjectID, null, null, null, null, null, null, null, null, ((CheckBox)CB_SpeedOverride).Checked);
			}
			bool flag;
			if (!(flag = ((CheckBox)CB_SpeedOverride).Checked))
			{
				method_17();
			}
			switch (SpeedAltUIMode)
			{
			case SpeedAltMode.Waypoint:
				CoreClientCode.SetWaypointSpeedOverride_Core(Client.SelectedWaypoint, flag);
				break;
			case SpeedAltMode.FlightplanWaypoint:
				CoreClientCode.SetFlightplanWaypointSpeedOverride_Core(SpeedAlt_FlightPlanWaypoint, Client.CurrentScenario, SpeedAlt_Flight, flag);
				if (!flag)
				{
					Client.MustRefreshMainForm = true;
					if (((Control)Client.FlightPlanEditorWindow).Visible)
					{
						Client.FlightPlanEditorWindow.RefreshGrid();
						Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DisplayLocks();
					}
				}
				break;
			case SpeedAltMode.ActiveUnit:
				CoreClientCode.SetUnitSpeedOverride_Core(SpeedAlt_SelectedUnit, flag);
				MyProject.Forms.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, SpeedAlt_SelectedUnit, v: false);
				break;
			}
			RefreshForm();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 200637S", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_41(object sender, EventArgs e)
	{
		bool_5 = true;
	}

	private void method_42(object sender, EventArgs e)
	{
		if (!bool_7)
		{
			switch (((ComboBox)CB_WaypointType).SelectedIndex)
			{
			case 0:
				Client.SelectedWaypoint.Type = Waypoint.WaypointType.Assemble;
				break;
			case 1:
				Client.SelectedWaypoint.Type = Waypoint.WaypointType.ManualPlottedCourseWaypoint;
				break;
			case 2:
				Client.SelectedWaypoint.Type = Waypoint.WaypointType.Target;
				break;
			case 3:
				Client.SelectedWaypoint.Type = Waypoint.WaypointType.TurningPoint;
				break;
			case 4:
				Client.SelectedWaypoint.Type = Waypoint.WaypointType.InitialPoint;
				break;
			case 5:
				Client.SelectedWaypoint.Type = Waypoint.WaypointType.StrikeIngress;
				break;
			case 6:
				Client.SelectedWaypoint.Type = Waypoint.WaypointType.StrikeEgress;
				break;
			case 7:
				Client.SelectedWaypoint.Type = Waypoint.WaypointType.TakeOff;
				break;
			case 8:
				Client.SelectedWaypoint.Type = Waypoint.WaypointType.HoldStart;
				break;
			case 9:
				Client.SelectedWaypoint.Type = Waypoint.WaypointType.HoldEnd;
				break;
			case 10:
				Client.SelectedWaypoint.Type = Waypoint.WaypointType.TurningPoint;
				break;
			case 11:
				Client.SelectedWaypoint.Type = Waypoint.WaypointType.LandingMarshal;
				break;
			case 12:
				Client.SelectedWaypoint.Type = Waypoint.WaypointType.Land;
				break;
			case 13:
				Client.SelectedWaypoint.Type = Waypoint.WaypointType.PatrolStation;
				break;
			case 14:
				Client.SelectedWaypoint.Type = Waypoint.WaypointType.LocalizationRun;
				break;
			case 15:
				Client.SelectedWaypoint.Type = Waypoint.WaypointType.Refuel;
				break;
			}
			bool_5 = false;
		}
	}

	private void method_43(object sender, EventArgs e)
	{
		bool_5 = true;
	}

	private void method_44(object sender, EventArgs e)
	{
		method_45();
	}

	private void method_45()
	{
		try
		{
			if (bool_7)
			{
				return;
			}
			if (bool_5)
			{
				if (Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint) && !Information.IsNothing((object)Client.SelectedWaypoint))
				{
					Client.SelectedWaypoint.Description = TextBox_WaypointDescription.Text;
				}
				else if (!Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint))
				{
					SpeedAlt_FlightPlanWaypoint.Description = TextBox_WaypointDescription.Text;
				}
			}
			bool_5 = false;
			RefreshForm();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 200637T", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void SpeedAlt_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (method_46(bool_10: true))
		{
			((Control)MyProject.Forms.MainForm).BringToFront();
			((CancelEventArgs)(object)e).Cancel = true;
			((Control)this).Hide();
		}
		else
		{
			((CancelEventArgs)(object)e).Cancel = true;
		}
	}

	private bool method_46(bool bool_10)
	{
		bool result = default(bool);
		try
		{
			if (TextBox_EnterAltitude.Focused || bool_10)
			{
				method_40();
				if (bool_9)
				{
					bool_9 = false;
					result = false;
					return result;
				}
			}
			if (TextBox_EnterSpeed.Focused || bool_10)
			{
				method_38();
			}
			if (TextBox_WaypointDescription.Focused || bool_10)
			{
				method_45();
			}
			if (SpeedAlt_FlightPlanWaypoint != null || Client.SelectedWaypoint != null)
			{
				bool flag = false;
				Waypoint waypoint = ((SpeedAlt_FlightPlanWaypoint == null) ? Client.SelectedWaypoint : SpeedAlt_FlightPlanWaypoint);
				if (waypoint.Category == Waypoint.WaypointCategory.FlightPlan)
				{
					Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
					foreach (Side side in sides_ReadOnly)
					{
						foreach (Mission mission in side.Missions)
						{
							foreach (Mission.Flight flight in mission.FlightList)
							{
								if (!flight.FlightPlan.Contains(waypoint))
								{
									continue;
								}
								AMP_General.RefreshFlightPlanErrorWindow();
								flag = true;
								if (((Control)Client.FlightPlanEditorWindow).Visible)
								{
									Client.FlightPlanEditorWindow.RefreshGrid();
									if (Client.FlightPlanEditorWindow.SelectedFlight != null)
									{
										Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DisplayLocks();
									}
								}
								break;
							}
							if (flag)
							{
								break;
							}
						}
					}
					if (((Control)Client.FlightPlanEditorWindow).Visible)
					{
						Client.FlightPlanEditorWindow.RefreshStats(RefreshAircraftNameAndLoadout: false);
						Client.FlightPlanEditorWindow.RefreshGrid();
						if (Client.FlightPlanEditorWindow.theFlightPlanWaypoints != null)
						{
							Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DisplayLocks();
						}
					}
					if (((Control)Client.AirTaskingOrderWindow).Visible)
					{
						Client.AirTaskingOrderWindow.RefreshWindow();
					}
				}
			}
			((Control)CB_SpeedOverride).Select();
			result = true;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 200637U", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void SpeedAlt_FormClosed(object sender, FormClosedEventArgs e)
	{
		try
		{
			if (bool_8)
			{
				Client.SelectedUnitPreChange -= HandleSelectedObjectChanged;
				Client.SelectedWaypointPreChange -= HandleSelectedObjectChanged;
			}
			bool_8 = false;
			SpeedAlt_FlightPlanWaypoint = null;
			SpeedAlt_SelectedUnit = null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 200637V", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_47(object sender, EventArgs e)
	{
		try
		{
			if (bool_6)
			{
				if (Information.IsNothing((object)SpeedAlt_SelectedUnit) && Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint))
				{
					return;
				}
				if (bool_7)
				{
					Client.RealtimeTerminal.SendThrottleAltUI(SelectedUnitObjectID, SelectedWaypointObjectID, SelectedFlightObjectID, null, null, null, null, null, null, null, null, null, null, ((CheckBox)CB_TerrainFollowing).Checked);
				}
				switch (SpeedAltUIMode)
				{
				case SpeedAltMode.Waypoint:
					CoreClientCode.SetWaypointTerrainFollowing_Core(Client.SelectedWaypoint, ((CheckBox)CB_TerrainFollowing).Checked);
					break;
				case SpeedAltMode.FlightplanWaypoint:
					CoreClientCode.SetWaypointTerrainFollowing_Core(SpeedAlt_FlightPlanWaypoint, ((CheckBox)CB_TerrainFollowing).Checked);
					break;
				case SpeedAltMode.ActiveUnit:
					CoreClientCode.SetUnitTerrainFollowing_Core(SpeedAlt_SelectedUnit, ((CheckBox)CB_TerrainFollowing).Checked);
					break;
				}
			}
			method_48();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 200637W", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_48()
	{
		try
		{
			bool flag = false;
			bool visible;
			if (visible = ((CheckBox)CB_TerrainFollowing).Checked)
			{
				if (!Information.IsNothing((object)Client.SelectedWaypoint) && Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint))
				{
					flag = Client.SelectedWaypoint.TerrainFollowingType == ActiveUnit.TerrainFollowMode.WithinLandCover;
					if (SpeedAlt_SelectedUnit != null)
					{
						if (SpeedAlt_SelectedUnit.IsGroup)
						{
							Group obj = (Group)SpeedAlt_SelectedUnit;
							int num;
							if (obj.GroupLead == null)
							{
								num = 0;
							}
							else
							{
								if (obj.GroupLead.LandCoverMaskingCapability)
								{
									goto IL_0192;
								}
								num = 0;
							}
							visible = (byte)num != 0;
						}
						else if (!SpeedAlt_SelectedUnit.LandCoverMaskingCapability)
						{
							visible = false;
						}
					}
				}
				else if (!Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint))
				{
					flag = SpeedAlt_FlightPlanWaypoint.TerrainFollowingType == ActiveUnit.TerrainFollowMode.WithinLandCover;
					if (SpeedAlt_SelectedUnit != null)
					{
						if (!SpeedAlt_SelectedUnit.IsGroup)
						{
							if (!SpeedAlt_SelectedUnit.LandCoverMaskingCapability)
							{
								visible = false;
							}
						}
						else
						{
							Group obj2 = (Group)SpeedAlt_SelectedUnit;
							int num2;
							if (obj2.GroupLead == null)
							{
								num2 = 0;
							}
							else
							{
								if (obj2.GroupLead.LandCoverMaskingCapability)
								{
									goto IL_0192;
								}
								num2 = 0;
							}
							visible = (byte)num2 != 0;
						}
					}
				}
				else if (!Information.IsNothing((object)SpeedAlt_SelectedUnit))
				{
					if (!SpeedAlt_SelectedUnit.IsGroup)
					{
						if (!SpeedAlt_SelectedUnit.LandCoverMaskingCapability)
						{
							visible = false;
						}
						else
						{
							flag = SpeedAlt_SelectedUnit.TerrainFollowingType == ActiveUnit.TerrainFollowMode.WithinLandCover;
						}
					}
					else
					{
						Group obj3 = (Group)SpeedAlt_SelectedUnit;
						int num3;
						if (!Information.IsNothing((object)obj3.GroupLead))
						{
							if (obj3.GroupLead.LandCoverMaskingCapability)
							{
								flag = obj3.GroupLead.TerrainFollowingType == ActiveUnit.TerrainFollowMode.WithinLandCover;
								goto IL_0192;
							}
							num3 = 0;
						}
						else
						{
							num3 = 0;
						}
						visible = (byte)num3 != 0;
					}
				}
				else
				{
					visible = false;
				}
			}
			goto IL_0192;
			IL_0192:
			((CheckBox)CB_UseLandCoverMasking).Checked = flag;
			((Control)CB_UseLandCoverMasking).Visible = visible;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 200637X", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_49(object sender, EventArgs e)
	{
		try
		{
			if (bool_6 && (!Information.IsNothing((object)SpeedAlt_SelectedUnit) || !Information.IsNothing((object)SpeedAlt_FlightPlanWaypoint)))
			{
				ActiveUnit.TerrainFollowMode terrainFollowMode = (((CheckBox)CB_UseLandCoverMasking).Checked ? ActiveUnit.TerrainFollowMode.WithinLandCover : ActiveUnit.TerrainFollowMode.IgnoreLandCover);
				if (bool_7)
				{
					Client.RealtimeTerminal.SendThrottleAltUI(SelectedUnitObjectID, SelectedWaypointObjectID, SelectedFlightObjectID, null, null, null, null, null, null, null, null, null, null, null, (byte)terrainFollowMode);
				}
				switch (SpeedAltUIMode)
				{
				case SpeedAltMode.Waypoint:
					CoreClientCode.SetWaypointTerrainFollowingMode_Core(Client.SelectedWaypoint, terrainFollowMode);
					break;
				case SpeedAltMode.FlightplanWaypoint:
					CoreClientCode.SetWaypointTerrainFollowingMode_Core(SpeedAlt_FlightPlanWaypoint, terrainFollowMode);
					break;
				case SpeedAltMode.ActiveUnit:
					CoreClientCode.SetUnitTerrainFollowingMode_Core(SpeedAlt_SelectedUnit, terrainFollowMode);
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 200637Y", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_50(object sender, EventArgs e)
	{
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Invalid comparison between Unknown and I4
		try
		{
			if (bool_7)
			{
				Client.RealtimeTerminal.SendThrottleAltUI(SelectedUnitObjectID, SelectedWaypointObjectID, SelectedFlightObjectID, null, null, null, null, null, null, ((CheckBox)CB_SprintDrift).Checked);
			}
			switch (SpeedAltUIMode)
			{
			case SpeedAltMode.Waypoint:
				if ((int)((CheckBox)CB_SprintDrift).CheckState == 2)
				{
					CoreClientCode.ClearWaypointSprintDrift_Core(Client.SelectedWaypoint);
				}
				else
				{
					CoreClientCode.SetWaypointSprintDrift_Core(Client.SelectedWaypoint, ((CheckBox)CB_SprintDrift).Checked);
				}
				break;
			case SpeedAltMode.ActiveUnit:
				CoreClientCode.SetUnitSprintDrift_Core(SpeedAlt_SelectedUnit, ((CheckBox)CB_SprintDrift).Checked);
				RefreshForm();
				break;
			case SpeedAltMode.FlightplanWaypoint:
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 200637Z", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_51(object sender, EventArgs e)
	{
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Invalid comparison between Unknown and I4
		try
		{
			if (bool_7)
			{
				Client.RealtimeTerminal.SendThrottleAltUI(SelectedUnitObjectID, SelectedWaypointObjectID, SelectedFlightObjectID, null, null, null, null, null, null, null, ((CheckBox)CB_AvoidCavitation).Checked);
			}
			switch (SpeedAltUIMode)
			{
			case SpeedAltMode.Waypoint:
				if ((int)((CheckBox)CB_AvoidCavitation).CheckState == 2)
				{
					CoreClientCode.ClearWaypointAvoidCavitation_Core(Client.SelectedWaypoint);
				}
				else
				{
					CoreClientCode.SetWaypointAvoidCavitation_Core(Client.SelectedWaypoint, ((CheckBox)CB_AvoidCavitation).Checked);
				}
				break;
			case SpeedAltMode.ActiveUnit:
				CoreClientCode.SetUnitAvoidCavitation_Core(SpeedAlt_SelectedUnit, ((CheckBox)CB_AvoidCavitation).Checked);
				RefreshForm();
				break;
			case SpeedAltMode.FlightplanWaypoint:
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 200636B", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void Button_Previous_Click(object sender, EventArgs e)
	{
		try
		{
			if (Client.SelectedUnit == null || Client.SelectedWaypoint == null)
			{
				return;
			}
			if (SpeedAlt_FlightPlanWaypoint != null)
			{
				int num = Array.IndexOf(SpeedAlt_Flight.FlightPlan, SpeedAlt_FlightPlanWaypoint);
				if (num <= 0)
				{
					return;
				}
				SpeedAlt_FlightPlanWaypoint = SpeedAlt_Flight.FlightPlan[num - 1];
			}
			else
			{
				int num2 = Array.IndexOf(((ActiveUnit)Client.SelectedUnit).Navigator.PlottedCourse, Client.SelectedWaypoint);
				if (num2 <= 0)
				{
					Client.SelectedWaypoint = null;
					RefreshForm(RefreshEvenIfNotVisible: true);
					return;
				}
				Client.SelectedWaypoint = ((ActiveUnit)Client.SelectedUnit).Navigator.PlottedCourse[num2 - 1];
			}
			RefreshForm(RefreshEvenIfNotVisible: true);
			MyProject.Forms.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, SpeedAlt_SelectedUnit, v: false);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 200636C", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void Button_Next_Click(object sender, EventArgs e)
	{
		try
		{
			if (Client.SelectedUnit == null)
			{
				return;
			}
			if (Client.SelectedWaypoint == null)
			{
				if (((ActiveUnit)Client.SelectedUnit).Navigator.HasPlottedCourse())
				{
					Client.SelectedWaypoint = ((ActiveUnit)Client.SelectedUnit).Navigator.PlottedCourse[0];
				}
			}
			else if (SpeedAlt_FlightPlanWaypoint == null)
			{
				int num = Array.IndexOf(((ActiveUnit)Client.SelectedUnit).Navigator.PlottedCourse, Client.SelectedWaypoint);
				if (num == ((ActiveUnit)Client.SelectedUnit).Navigator.PlottedCourse.Count() - 1)
				{
					return;
				}
				Client.SelectedWaypoint = ((ActiveUnit)Client.SelectedUnit).Navigator.PlottedCourse[num + 1];
			}
			else
			{
				int num2 = Array.IndexOf(SpeedAlt_Flight.FlightPlan, SpeedAlt_FlightPlanWaypoint);
				if (num2 == SpeedAlt_Flight.FlightPlan.Count() - 1)
				{
					return;
				}
				SpeedAlt_FlightPlanWaypoint = SpeedAlt_Flight.FlightPlan[num2 + 1];
			}
			RefreshForm(RefreshEvenIfNotVisible: true);
			MyProject.Forms.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, SpeedAlt_SelectedUnit, v: false);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 200636D", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_52(object sender, EventArgs e)
	{
		((ComboBox)CB_EventAction).BeginUpdate();
		((ComboBox)CB_EventAction).Items.Clear();
		((ComboBox)CB_EventAction).Items.Add((object)"None");
		foreach (EventAction value in Client.CurrentScenario.EventActions.Values)
		{
			if (value.Type == EventAction.EventActionType.LuaScript && ((EventAction_LuaScript)value).ScriptForType != EventAction_LuaScript.EventAction_LuaScript_Type.EventAction)
			{
				((ComboBox)CB_EventAction).Items.Add((object)value.Description);
				if (!string.IsNullOrEmpty(Client.SelectedWaypoint.EventActionID) && Operators.CompareString(value.ObjectID, Client.SelectedWaypoint.EventActionID, true) == 0)
				{
					((ComboBox)CB_EventAction).SelectedItem = value.Description;
				}
			}
		}
		((ComboBox)CB_EventAction).EndUpdate();
	}

	private void method_53(object sender, EventArgs e)
	{
		if (!((string?)((ComboBox)CB_EventAction).SelectedItem == "None"))
		{
			foreach (EventAction value in Client.CurrentScenario.EventActions.Values)
			{
				if (value.Type == EventAction.EventActionType.LuaScript && ((ComboBox)CB_EventAction).SelectedItem == value.Description)
				{
					Client.SelectedWaypoint.EventActionID = value.ObjectID;
				}
			}
			return;
		}
		Client.SelectedWaypoint.EventActionID = null;
	}

	static SpeedAlt()
	{
		Class72.smethod_20();
	}
}
