using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using Command_Core;
using Command.My;
using CoordinateSharp;
using DarkUI.Controls;
using DarkUI.Forms;
using DXRenderer;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using VectorTileRenderer;

namespace Command;

[DesignerGenerated]
public sealed class Options : DarkSecondaryFormBase
{
	public sealed class CoordinateComboMember
	{
		public Parse_Format_Type CoordType;

		public CoordinateComboMember(Parse_Format_Type _CoordType)
		{
			CoordType = _CoordType;
		}

		public override string ToString()
		{
			return CoordType switch
			{
				Parse_Format_Type.Signed_Degree => "Signed Degree", 
				Parse_Format_Type.Degree_Minute_Second => "Degrees", 
				Parse_Format_Type.UTM => "UTM", 
				Parse_Format_Type.MGRS => "MGRS", 
				Parse_Format_Type.Cartesian_ECEF => "ECEF", 
				_ => "ERROR - Not Found", 
			};
		}

		static CoordinateComboMember()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[AccessedThroughProperty("DataGridView1")]
	[CompilerGenerated]
	private DarkDataGridView _DataGridView1;

	[AccessedThroughProperty("CB_UseAutosave")]
	[CompilerGenerated]
	private DarkCheckBox _CB_UseAutosave;

	[AccessedThroughProperty("CB_MessageLogInWindow")]
	[CompilerGenerated]
	private DarkCheckBox _CB_MessageLogInWindow;

	[AccessedThroughProperty("CB_AltitudeInFeet")]
	[CompilerGenerated]
	private DarkCheckBox _CB_AltitudeInFeet;

	[AccessedThroughProperty("CB_ZoomOnCursor")]
	[CompilerGenerated]
	private DarkCheckBox _CB_ZoomOnCursor;

	[AccessedThroughProperty("CB_Sounds")]
	[CompilerGenerated]
	private DarkCheckBox _CB_Sounds;

	[AccessedThroughProperty("CB_Music")]
	[CompilerGenerated]
	private DarkCheckBox _CB_Music;

	[AccessedThroughProperty("Button_ResetWindowPlacement")]
	[CompilerGenerated]
	private DarkUIButton _Button_ResetWindowPlacement;

	[AccessedThroughProperty("CB_MapCursorBox")]
	[CompilerGenerated]
	private DarkUIComboBox _CB_MapCursorBox;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_RefPointVisibility")]
	private DarkUIComboBox _CB_RefPointVisibility;

	[AccessedThroughProperty("CB_SonobuoyVisibility")]
	[CompilerGenerated]
	private DarkUIComboBox _CB_SonobuoyVisibility;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_MapSymbols")]
	private DarkUIComboBox _CB_MapSymbols;

	[CompilerGenerated]
	[AccessedThroughProperty("CP_ShowPlottedPaths")]
	private DarkUIComboBox _CP_ShowPlottedPaths;

	[CompilerGenerated]
	[AccessedThroughProperty("CP_ShowGhostedGroupMembers")]
	private DarkUIComboBox _CP_ShowGhostedGroupMembers;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_UnitStatusImage")]
	private DarkCheckBox _CB_UnitStatusImage;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_AllowPowerScemeSwitch")]
	private DarkCheckBox _CB_AllowPowerScemeSwitch;

	[AccessedThroughProperty("TB_Navigation_ThresholdDistanceDeg")]
	[CompilerGenerated]
	private DarkUITextBox _TB_Navigation_ThresholdDistanceDeg;

	[AccessedThroughProperty("TB_Navigation_MaxDistanceNM")]
	[CompilerGenerated]
	private DarkUITextBox _TB_Navigation_MaxDistanceNM;

	[AccessedThroughProperty("CB_ShowDiagnostics")]
	[CompilerGenerated]
	private DarkCheckBox _CB_ShowDiagnostics;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_Autosave")]
	private DarkCheckBox _CB_Autosave;

	[AccessedThroughProperty("CB_FriendlyRangeSymbols")]
	[CompilerGenerated]
	private DarkCheckBox _CB_FriendlyRangeSymbols;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_DisplayIlluminationVectors")]
	private DarkCheckBox _CB_DisplayIlluminationVectors;

	[AccessedThroughProperty("CB_DisplayContactEmissions")]
	[CompilerGenerated]
	private DarkCheckBox _CB_DisplayContactEmissions;

	[AccessedThroughProperty("CB_DisplayTargetingVectors")]
	[CompilerGenerated]
	private DarkCheckBox _CB_DisplayTargetingVectors;

	[AccessedThroughProperty("CB_DisallowHighPerformancePowerScheme")]
	[CompilerGenerated]
	private DarkCheckBox _CB_DisallowHighPerformancePowerScheme;

	[AccessedThroughProperty("CB_ShowGhostedGroupMembers")]
	[CompilerGenerated]
	private DarkCheckBox _CB_ShowGhostedGroupMembers;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_DisplayDatalinks")]
	private DarkCheckBox _CB_DisplayDatalinks;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_DisplayMissionAreas")]
	private DarkCheckBox _CB_DisplayMissionAreas;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_DisplayCountryAndCityNames")]
	private DarkCheckBox _CB_DisplayCountryAndCityNames;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_CustomFineGrainedNavigation")]
	private DarkCheckBox _CB_CustomFineGrainedNavigation;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_NonFriendlyRangeSymbols")]
	private DarkCheckBox _CB_NonFriendlyRangeSymbols;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_LogDebugInfoToFile")]
	private DarkCheckBox _CB_LogDebugInfoToFile;

	[CompilerGenerated]
	[AccessedThroughProperty("CP_ShowFlightPlans")]
	private DarkUIComboBox darkUIComboBox_0;

	[CompilerGenerated]
	[AccessedThroughProperty("CP_ShowFlightPlans_Airborne")]
	private DarkUIComboBox _CP_ShowFlightPlans_Airborne;

	[CompilerGenerated]
	[AccessedThroughProperty("CP_ShowFlightPlans_Planned")]
	private DarkUIComboBox _CP_ShowFlightPlans_Planned;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_TacviewPath")]
	private DarkUIButton _Button_TacviewPath;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_SetPersonalMapProfile")]
	private DarkUIButton _Button_SetPersonalMapProfile;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_UsePersonalMapProfile")]
	private DarkCheckBox _CB_UsePersonalMapProfile;

	[AccessedThroughProperty("CB_ColorDatablocks")]
	[CompilerGenerated]
	private DarkCheckBox _CB_ColorDatablocks;

	internal HoverInfoOptions HoverInfoOptions1;

	[AccessedThroughProperty("TB_MusicVolumeBar")]
	[CompilerGenerated]
	private TrackBar _TB_MusicVolumeBar;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_SFXVolumeBar")]
	private TrackBar _TB_SFXVolumeBar;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_GroundSpeedUnit")]
	private DarkUIComboBox _Combo_GroundSpeedUnit;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_DVViewerPauseBehaviour")]
	private DarkUIComboBox _CB_DVViewerPauseBehaviour;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_AirDockPauseBehaviour")]
	private DarkUIComboBox _CB_AirDockPauseBehaviour;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_CoordinateUnit")]
	private DarkUIComboBox _Combo_CoordinateUnit;

	[AccessedThroughProperty("CB_RMB_MoveOrder")]
	[CompilerGenerated]
	private DarkCheckBox _CB_RMB_MoveOrder;

	[AccessedThroughProperty("CB_SlugTrail_Hostile")]
	[CompilerGenerated]
	private DarkCheckBox _CB_SlugTrail_Hostile;

	[AccessedThroughProperty("CB_SlugTrail_Neutral")]
	[CompilerGenerated]
	private DarkCheckBox _CB_SlugTrail_Neutral;

	[AccessedThroughProperty("CB_SlugTrail_Friendly")]
	[CompilerGenerated]
	private DarkCheckBox _CB_SlugTrail_Friendly;

	[AccessedThroughProperty("CB_SlugTrail_Own")]
	[CompilerGenerated]
	private DarkCheckBox _CB_SlugTrail_Own;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_SlugTrail_UseSlugTrail")]
	private DarkCheckBox _CB_SlugTrail_UseSlugTrail;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_SlugTrailFreq")]
	private DarkUIComboBox _Combo_SlugTrailFreq;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_SlugTrail_Unfriendly")]
	private DarkCheckBox _CB_SlugTrail_Unfriendly;

	[CompilerGenerated]
	[AccessedThroughProperty("Num_SlugTrailLifetime")]
	private NumericUpDown _Num_SlugTrailLifetime;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_SlugTrail_Unknown")]
	private DarkCheckBox _CB_SlugTrail_Unknown;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_CargoShowUSUnits")]
	private DarkCheckBox _CB_CargoShowUSUnits;

	[AccessedThroughProperty("ChkASWNoise")]
	[CompilerGenerated]
	private DarkCheckBox darkCheckBox_0;

	[CompilerGenerated]
	[AccessedThroughProperty("CP_ShowAU_Behaviour_Bark")]
	private DarkUIComboBox _CP_ShowAU_Behaviour_Bark;

	[CompilerGenerated]
	[AccessedThroughProperty("ClearSlugTrail")]
	private DarkUIButton _ClearSlugTrail;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_GrounUnit_Zoom")]
	private TrackBar _TB_GrounUnit_Zoom;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkLabel10")]
	private DarkLabel darkLabel_0;

	[AccessedThroughProperty("TB_Flower_Zoom")]
	[CompilerGenerated]
	private TrackBar _TB_Flower_Zoom;

	[AccessedThroughProperty("TB_Rectangle_Zoom")]
	[CompilerGenerated]
	private TrackBar _TB_Rectangle_Zoom;

	[AccessedThroughProperty("TB_Diamond_Zoom")]
	[CompilerGenerated]
	private TrackBar _TB_Diamond_Zoom;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_DrawOutlines")]
	private DarkCheckBox _CB_DrawOutlines;

	[AccessedThroughProperty("DetectStuckUnitPulsesCheckBox")]
	[CompilerGenerated]
	private DarkCheckBox _DetectStuckUnitPulsesCheckBox;

	[AccessedThroughProperty("DarkLabel11")]
	[CompilerGenerated]
	private DarkLabel darkLabel_1;

	[CompilerGenerated]
	[AccessedThroughProperty("StuckUnitPulseThresholdMillisecondsTextBox")]
	private DarkUITextBox _StuckUnitPulseThresholdMillisecondsTextBox;

	[AccessedThroughProperty("SaveScenarioCopyOnDetectedStuckUnitPulseCheckBox")]
	[CompilerGenerated]
	private DarkCheckBox _SaveScenarioCopyOnDetectedStuckUnitPulseCheckBox;

	[AccessedThroughProperty("PauseOnDetectedStuckUnitPulseCheckBox")]
	[CompilerGenerated]
	private DarkCheckBox _PauseOnDetectedStuckUnitPulseCheckBox;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkLabel12")]
	private DarkLabel darkLabel_2;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_TrueAltitudeRenderFromGroundInsteadOfSurface")]
	private DarkCheckBox _CB_TrueAltitudeRenderFromGroundInsteadOfSurface;

	[AccessedThroughProperty("CB_TrueAltitudeRenderForceGroundUnitsAtSurface")]
	[CompilerGenerated]
	private DarkCheckBox _CB_TrueAltitudeRenderForceGroundUnitsAtSurface;

	[AccessedThroughProperty("CB_DrawUnitsAtTrueAltitude")]
	[CompilerGenerated]
	private DarkCheckBox _CB_DrawUnitsAtTrueAltitude;

	[AccessedThroughProperty("CB_TrueAltitudeRenderForceSubsurfaceUnitsAtSurface")]
	[CompilerGenerated]
	private DarkCheckBox _CB_TrueAltitudeRenderForceSubsurfaceUnitsAtSurface;

	[AccessedThroughProperty("VerticalScalingMultiplierTrackBar")]
	[CompilerGenerated]
	private TrackBar _VerticalScalingMultiplierTrackBar;

	[AccessedThroughProperty("CB_Show3DTerrain")]
	[CompilerGenerated]
	private DarkCheckBox _CB_Show3DTerrain;

	[AccessedThroughProperty("OpenFileDialog1")]
	[CompilerGenerated]
	private OpenFileDialog openFileDialog_0;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_AggressiveTileManagement")]
	private DarkCheckBox _CB_AggressiveTileManagement;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_SmartRPPlacement")]
	private DarkCheckBox _CB_SmartRPPlacement;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_OSMstyle")]
	private DarkUIComboBox _CB_OSMstyle;

	[AccessedThroughProperty("DarkLabel13")]
	[CompilerGenerated]
	private DarkLabel darkLabel_3;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_Icon_Zoom")]
	private TrackBar _TB_Icon_Zoom;

	[CompilerGenerated]
	private bool bool_2;

	private Game.GamePreferences gamePreferences_0;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	[field: AccessedThroughProperty("TabPage2")]
	internal virtual TabPage TabPage2 { get; set; }

	internal virtual DarkDataGridView DataGridView1
	{
		[CompilerGenerated]
		get
		{
			return _DataGridView1;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			DataGridViewCellEventHandler val = new DataGridViewCellEventHandler(method_52);
			DarkDataGridView darkDataGridView = _DataGridView1;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).CellContentClick -= val;
			}
			_DataGridView1 = value;
			darkDataGridView = _DataGridView1;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).CellContentClick += val;
			}
		}
	}

	[field: AccessedThroughProperty("TabPage1")]
	internal virtual TabPage TabPage1 { get; set; }

	internal virtual DarkCheckBox CB_UseAutosave
	{
		[CompilerGenerated]
		get
		{
			return _CB_UseAutosave;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_23;
			DarkCheckBox darkCheckBox = _CB_UseAutosave;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_UseAutosave = value;
			darkCheckBox = _CB_UseAutosave;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TabControl1")]
	internal virtual DarkUITabControl TabControl1 { get; set; }

	internal virtual DarkCheckBox CB_MessageLogInWindow
	{
		[CompilerGenerated]
		get
		{
			return _CB_MessageLogInWindow;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_33;
			DarkCheckBox darkCheckBox = _CB_MessageLogInWindow;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_MessageLogInWindow = value;
			darkCheckBox = _CB_MessageLogInWindow;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_AltitudeInFeet
	{
		[CompilerGenerated]
		get
		{
			return _CB_AltitudeInFeet;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_34;
			DarkCheckBox darkCheckBox = _CB_AltitudeInFeet;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_AltitudeInFeet = value;
			darkCheckBox = _CB_AltitudeInFeet;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_ZoomOnCursor
	{
		[CompilerGenerated]
		get
		{
			return _CB_ZoomOnCursor;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_36;
			DarkCheckBox darkCheckBox = _CB_ZoomOnCursor;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_ZoomOnCursor = value;
			darkCheckBox = _CB_ZoomOnCursor;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TabPage3")]
	internal virtual TabPage TabPage3 { get; set; }

	internal virtual DarkCheckBox CB_Sounds
	{
		[CompilerGenerated]
		get
		{
			return _CB_Sounds;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_48;
			DarkCheckBox darkCheckBox = _CB_Sounds;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_Sounds = value;
			darkCheckBox = _CB_Sounds;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_Music
	{
		[CompilerGenerated]
		get
		{
			return _CB_Music;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_49;
			DarkCheckBox darkCheckBox = _CB_Music;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_Music = value;
			darkCheckBox = _CB_Music;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_ResetWindowPlacement
	{
		[CompilerGenerated]
		get
		{
			return _Button_ResetWindowPlacement;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			DarkUIButton darkUIButton = _Button_ResetWindowPlacement;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_ResetWindowPlacement = value;
			darkUIButton = _Button_ResetWindowPlacement;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TabPage4")]
	internal virtual TabPage TabPage4 { get; set; }

	internal virtual DarkUIComboBox CB_MapCursorBox
	{
		[CompilerGenerated]
		get
		{
			return _CB_MapCursorBox;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_41;
			DarkUIComboBox darkUIComboBox = _CB_MapCursorBox;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_MapCursorBox = value;
			darkUIComboBox = _CB_MapCursorBox;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	internal virtual DarkUIComboBox CB_RefPointVisibility
	{
		[CompilerGenerated]
		get
		{
			return _CB_RefPointVisibility;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_40;
			DarkUIComboBox darkUIComboBox = _CB_RefPointVisibility;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_RefPointVisibility = value;
			darkUIComboBox = _CB_RefPointVisibility;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

	internal virtual DarkUIComboBox CB_SonobuoyVisibility
	{
		[CompilerGenerated]
		get
		{
			return _CB_SonobuoyVisibility;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_38;
			DarkUIComboBox darkUIComboBox = _CB_SonobuoyVisibility;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_SonobuoyVisibility = value;
			darkUIComboBox = _CB_SonobuoyVisibility;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	internal virtual DarkUIComboBox CB_MapSymbols
	{
		[CompilerGenerated]
		get
		{
			return _CB_MapSymbols;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_42;
			DarkUIComboBox darkUIComboBox = _CB_MapSymbols;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_MapSymbols = value;
			darkUIComboBox = _CB_MapSymbols;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label4")]
	internal virtual DarkLabel Label4 { get; set; }

	internal virtual DarkUIComboBox CP_ShowPlottedPaths
	{
		[CompilerGenerated]
		get
		{
			return _CP_ShowPlottedPaths;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_43;
			DarkUIComboBox darkUIComboBox = _CP_ShowPlottedPaths;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CP_ShowPlottedPaths = value;
			darkUIComboBox = _CP_ShowPlottedPaths;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label6")]
	internal virtual DarkLabel Label6 { get; set; }

	internal virtual DarkUIComboBox CP_ShowGhostedGroupMembers
	{
		[CompilerGenerated]
		get
		{
			return _CP_ShowGhostedGroupMembers;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_25;
			DarkUIComboBox darkUIComboBox = _CP_ShowGhostedGroupMembers;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CP_ShowGhostedGroupMembers = value;
			darkUIComboBox = _CP_ShowGhostedGroupMembers;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label5")]
	internal virtual DarkLabel Label5 { get; set; }

	[field: AccessedThroughProperty("Label3")]
	internal virtual DarkLabel Label3 { get; set; }

	internal virtual DarkCheckBox CB_UnitStatusImage
	{
		[CompilerGenerated]
		get
		{
			return _CB_UnitStatusImage;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_37;
			DarkCheckBox darkCheckBox = _CB_UnitStatusImage;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_UnitStatusImage = value;
			darkCheckBox = _CB_UnitStatusImage;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_AllowPowerScemeSwitch
	{
		[CompilerGenerated]
		get
		{
			return _CB_AllowPowerScemeSwitch;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_22;
			DarkCheckBox darkCheckBox = _CB_AllowPowerScemeSwitch;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_AllowPowerScemeSwitch = value;
			darkCheckBox = _CB_AllowPowerScemeSwitch;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUITextBox TB_Navigation_ThresholdDistanceDeg
	{
		[CompilerGenerated]
		get
		{
			return _TB_Navigation_ThresholdDistanceDeg;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_6;
			EventHandler eventHandler2 = method_7;
			DarkUITextBox darkUITextBox = _TB_Navigation_ThresholdDistanceDeg;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).Enter -= eventHandler;
				((Control)darkUITextBox).Leave -= eventHandler2;
			}
			_TB_Navigation_ThresholdDistanceDeg = value;
			darkUITextBox = _TB_Navigation_ThresholdDistanceDeg;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).Enter += eventHandler;
				((Control)darkUITextBox).Leave += eventHandler2;
			}
		}
	}

	internal virtual DarkUITextBox TB_Navigation_MaxDistanceNM
	{
		[CompilerGenerated]
		get
		{
			return _TB_Navigation_MaxDistanceNM;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_4;
			EventHandler eventHandler2 = method_5;
			DarkUITextBox darkUITextBox = _TB_Navigation_MaxDistanceNM;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).Enter -= eventHandler;
				((Control)darkUITextBox).Leave -= eventHandler2;
			}
			_TB_Navigation_MaxDistanceNM = value;
			darkUITextBox = _TB_Navigation_MaxDistanceNM;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).Enter += eventHandler;
				((Control)darkUITextBox).Leave += eventHandler2;
			}
		}
	}

	[field: AccessedThroughProperty("Label8")]
	internal virtual DarkLabel Label8 { get; set; }

	[field: AccessedThroughProperty("Label7")]
	internal virtual DarkLabel Label7 { get; set; }

	internal virtual DarkCheckBox CB_ShowDiagnostics
	{
		[CompilerGenerated]
		get
		{
			return _CB_ShowDiagnostics;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_44;
			DarkCheckBox darkCheckBox = _CB_ShowDiagnostics;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_ShowDiagnostics = value;
			darkCheckBox = _CB_ShowDiagnostics;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TabPage5")]
	internal virtual TabPage TabPage5 { get; set; }

	[field: AccessedThroughProperty("GroupBox3")]
	internal virtual DarkGroupBox GroupBox3 { get; set; }

	internal virtual DarkCheckBox CB_Autosave
	{
		[CompilerGenerated]
		get
		{
			return _CB_Autosave;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_20;
			DarkCheckBox darkCheckBox = _CB_Autosave;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_Autosave = value;
			darkCheckBox = _CB_Autosave;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("GroupBox2")]
	internal virtual DarkGroupBox GroupBox2 { get; set; }

	internal virtual DarkCheckBox CB_FriendlyRangeSymbols
	{
		[CompilerGenerated]
		get
		{
			return _CB_FriendlyRangeSymbols;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_17;
			DarkCheckBox darkCheckBox = _CB_FriendlyRangeSymbols;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_FriendlyRangeSymbols = value;
			darkCheckBox = _CB_FriendlyRangeSymbols;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_DisplayIlluminationVectors
	{
		[CompilerGenerated]
		get
		{
			return _CB_DisplayIlluminationVectors;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_18;
			DarkCheckBox darkCheckBox = _CB_DisplayIlluminationVectors;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_DisplayIlluminationVectors = value;
			darkCheckBox = _CB_DisplayIlluminationVectors;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_DisplayContactEmissions
	{
		[CompilerGenerated]
		get
		{
			return _CB_DisplayContactEmissions;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_19;
			DarkCheckBox darkCheckBox = _CB_DisplayContactEmissions;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_DisplayContactEmissions = value;
			darkCheckBox = _CB_DisplayContactEmissions;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("GroupBox1")]
	internal virtual DarkGroupBox GroupBox1 { get; set; }

	internal virtual DarkCheckBox CB_DisplayTargetingVectors
	{
		[CompilerGenerated]
		get
		{
			return _CB_DisplayTargetingVectors;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_14;
			DarkCheckBox darkCheckBox = _CB_DisplayTargetingVectors;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_DisplayTargetingVectors = value;
			darkCheckBox = _CB_DisplayTargetingVectors;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_DisallowHighPerformancePowerScheme
	{
		[CompilerGenerated]
		get
		{
			return _CB_DisallowHighPerformancePowerScheme;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_16;
			DarkCheckBox darkCheckBox = _CB_DisallowHighPerformancePowerScheme;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_DisallowHighPerformancePowerScheme = value;
			darkCheckBox = _CB_DisallowHighPerformancePowerScheme;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_ShowGhostedGroupMembers
	{
		[CompilerGenerated]
		get
		{
			return _CB_ShowGhostedGroupMembers;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_21;
			DarkCheckBox darkCheckBox = _CB_ShowGhostedGroupMembers;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_ShowGhostedGroupMembers = value;
			darkCheckBox = _CB_ShowGhostedGroupMembers;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_DisplayDatalinks
	{
		[CompilerGenerated]
		get
		{
			return _CB_DisplayDatalinks;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_15;
			DarkCheckBox darkCheckBox = _CB_DisplayDatalinks;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_DisplayDatalinks = value;
			darkCheckBox = _CB_DisplayDatalinks;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_DisplayMissionAreas
	{
		[CompilerGenerated]
		get
		{
			return _CB_DisplayMissionAreas;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_13;
			DarkCheckBox darkCheckBox = _CB_DisplayMissionAreas;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_DisplayMissionAreas = value;
			darkCheckBox = _CB_DisplayMissionAreas;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_DisplayCountryAndCityNames
	{
		[CompilerGenerated]
		get
		{
			return _CB_DisplayCountryAndCityNames;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_12;
			DarkCheckBox darkCheckBox = _CB_DisplayCountryAndCityNames;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_DisplayCountryAndCityNames = value;
			darkCheckBox = _CB_DisplayCountryAndCityNames;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_CustomFineGrainedNavigation
	{
		[CompilerGenerated]
		get
		{
			return _CB_CustomFineGrainedNavigation;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_11;
			DarkCheckBox darkCheckBox = _CB_CustomFineGrainedNavigation;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_CustomFineGrainedNavigation = value;
			darkCheckBox = _CB_CustomFineGrainedNavigation;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_NonFriendlyRangeSymbols
	{
		[CompilerGenerated]
		get
		{
			return _CB_NonFriendlyRangeSymbols;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_10;
			DarkCheckBox darkCheckBox = _CB_NonFriendlyRangeSymbols;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_NonFriendlyRangeSymbols = value;
			darkCheckBox = _CB_NonFriendlyRangeSymbols;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label9")]
	internal virtual DarkLabel Label9 { get; set; }

	internal virtual DarkCheckBox CB_LogDebugInfoToFile
	{
		[CompilerGenerated]
		get
		{
			return _CB_LogDebugInfoToFile;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_26;
			DarkCheckBox darkCheckBox = _CB_LogDebugInfoToFile;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_LogDebugInfoToFile = value;
			darkCheckBox = _CB_LogDebugInfoToFile;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("CB_ExtraMemoryProtection")]
	internal virtual DarkCheckBox CB_ExtraMemoryProtection { get; set; }

	internal virtual DarkUIComboBox CP_ShowFlightPlans
	{
		[CompilerGenerated]
		get
		{
			return darkUIComboBox_0;
		}
		[CompilerGenerated]
		set
		{
			darkUIComboBox_0 = value;
		}
	}

	internal virtual DarkUIComboBox CP_ShowFlightPlans_Airborne
	{
		[CompilerGenerated]
		get
		{
			return _CP_ShowFlightPlans_Airborne;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_45;
			DarkUIComboBox darkUIComboBox = _CP_ShowFlightPlans_Airborne;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CP_ShowFlightPlans_Airborne = value;
			darkUIComboBox = _CP_ShowFlightPlans_Airborne;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label20")]
	internal virtual DarkLabel Label20 { get; set; }

	internal virtual DarkUIComboBox CP_ShowFlightPlans_Planned
	{
		[CompilerGenerated]
		get
		{
			return _CP_ShowFlightPlans_Planned;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_46;
			DarkUIComboBox darkUIComboBox = _CP_ShowFlightPlans_Planned;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CP_ShowFlightPlans_Planned = value;
			darkUIComboBox = _CP_ShowFlightPlans_Planned;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label11")]
	internal virtual DarkLabel Label11 { get; set; }

	[field: AccessedThroughProperty("TabPage6")]
	internal virtual TabPage TabPage6 { get; set; }

	[field: AccessedThroughProperty("DarkLabel1")]
	internal virtual DarkLabel DarkLabel1 { get; set; }

	[field: AccessedThroughProperty("TB_TacviewPath")]
	internal virtual DarkUITextBox TB_TacviewPath { get; set; }

	internal virtual DarkUIButton Button_TacviewPath
	{
		[CompilerGenerated]
		get
		{
			return _Button_TacviewPath;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_53;
			DarkUIButton darkUIButton = _Button_TacviewPath;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_TacviewPath = value;
			darkUIButton = _Button_TacviewPath;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_SetPersonalMapProfile
	{
		[CompilerGenerated]
		get
		{
			return _Button_SetPersonalMapProfile;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_55;
			DarkUIButton darkUIButton = _Button_SetPersonalMapProfile;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_SetPersonalMapProfile = value;
			darkUIButton = _Button_SetPersonalMapProfile;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_UsePersonalMapProfile
	{
		[CompilerGenerated]
		get
		{
			return _CB_UsePersonalMapProfile;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_54;
			DarkCheckBox darkCheckBox = _CB_UsePersonalMapProfile;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_UsePersonalMapProfile = value;
			darkCheckBox = _CB_UsePersonalMapProfile;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_ColorDatablocks
	{
		[CompilerGenerated]
		get
		{
			return _CB_ColorDatablocks;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_56;
			DarkCheckBox darkCheckBox = _CB_ColorDatablocks;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_ColorDatablocks = value;
			darkCheckBox = _CB_ColorDatablocks;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TabPage7")]
	internal virtual TabPage TabPage7 { get; set; }

	[field: AccessedThroughProperty("ElementHost1")]
	internal virtual ElementHost ElementHost1 { get; set; }

	internal virtual TrackBar TB_MusicVolumeBar
	{
		[CompilerGenerated]
		get
		{
			return _TB_MusicVolumeBar;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_50;
			TrackBar val = _TB_MusicVolumeBar;
			if (val != null)
			{
				val.Scroll -= eventHandler;
			}
			_TB_MusicVolumeBar = value;
			val = _TB_MusicVolumeBar;
			if (val != null)
			{
				val.Scroll += eventHandler;
			}
		}
	}

	internal virtual TrackBar TB_SFXVolumeBar
	{
		[CompilerGenerated]
		get
		{
			return _TB_SFXVolumeBar;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_51;
			TrackBar val = _TB_SFXVolumeBar;
			if (val != null)
			{
				val.Scroll -= eventHandler;
			}
			_TB_SFXVolumeBar = value;
			val = _TB_SFXVolumeBar;
			if (val != null)
			{
				val.Scroll += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("MusicVolumeLabel")]
	internal virtual DarkLabel MusicVolumeLabel { get; set; }

	[field: AccessedThroughProperty("SFXVolumeLabel")]
	internal virtual DarkLabel SFXVolumeLabel { get; set; }

	[field: AccessedThroughProperty("MessageType_Hidden")]
	internal virtual DataGridViewTextBoxColumn MessageType_Hidden { get; set; }

	[field: AccessedThroughProperty("MessageType")]
	internal virtual DataGridViewTextBoxColumn MessageType { get; set; }

	[field: AccessedThroughProperty("MessageLog")]
	internal virtual DataGridViewCheckBoxColumn MessageLog { get; set; }

	[field: AccessedThroughProperty("PopUp")]
	internal virtual DataGridViewCheckBoxColumn PopUp { get; set; }

	[field: AccessedThroughProperty("Column_ShowBalloon")]
	internal virtual DataGridViewCheckBoxColumn Column_ShowBalloon { get; set; }

	[field: AccessedThroughProperty("Timescale_X1")]
	internal virtual DataGridViewCheckBoxColumn Timescale_X1 { get; set; }

	internal virtual DarkUIComboBox Combo_GroundSpeedUnit
	{
		[CompilerGenerated]
		get
		{
			return _Combo_GroundSpeedUnit;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_57;
			DarkUIComboBox darkUIComboBox = _Combo_GroundSpeedUnit;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_Combo_GroundSpeedUnit = value;
			darkUIComboBox = _Combo_GroundSpeedUnit;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel2")]
	internal virtual DarkLabel DarkLabel2 { get; set; }

	[field: AccessedThroughProperty("GB_PauseBehaviour")]
	internal virtual DarkGroupBox GB_PauseBehaviour { get; set; }

	internal virtual DarkUIComboBox CB_DVViewerPauseBehaviour
	{
		[CompilerGenerated]
		get
		{
			return _CB_DVViewerPauseBehaviour;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_59;
			DarkUIComboBox darkUIComboBox = _CB_DVViewerPauseBehaviour;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged -= eventHandler;
			}
			_CB_DVViewerPauseBehaviour = value;
			darkUIComboBox = _CB_DVViewerPauseBehaviour;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged += eventHandler;
			}
		}
	}

	internal virtual DarkUIComboBox CB_AirDockPauseBehaviour
	{
		[CompilerGenerated]
		get
		{
			return _CB_AirDockPauseBehaviour;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_58;
			DarkUIComboBox darkUIComboBox = _CB_AirDockPauseBehaviour;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged -= eventHandler;
			}
			_CB_AirDockPauseBehaviour = value;
			darkUIComboBox = _CB_AirDockPauseBehaviour;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel4")]
	internal virtual DarkLabel DarkLabel4 { get; set; }

	[field: AccessedThroughProperty("DarkLabel3")]
	internal virtual DarkLabel DarkLabel3 { get; set; }

	[field: AccessedThroughProperty("DarkGroupBox1")]
	internal virtual DarkGroupBox DarkGroupBox1 { get; set; }

	internal virtual DarkUIComboBox Combo_CoordinateUnit
	{
		[CompilerGenerated]
		get
		{
			return _Combo_CoordinateUnit;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_60;
			DarkUIComboBox darkUIComboBox = _Combo_CoordinateUnit;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_Combo_CoordinateUnit = value;
			darkUIComboBox = _Combo_CoordinateUnit;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("GeocentricCoordLabel")]
	internal virtual DarkLabel GeocentricCoordLabel { get; set; }

	internal virtual DarkCheckBox CB_RMB_MoveOrder
	{
		[CompilerGenerated]
		get
		{
			return _CB_RMB_MoveOrder;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_61;
			DarkCheckBox darkCheckBox = _CB_RMB_MoveOrder;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_RMB_MoveOrder = value;
			darkCheckBox = _CB_RMB_MoveOrder;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkGroupBox2")]
	internal virtual DarkGroupBox DarkGroupBox2 { get; set; }

	[field: AccessedThroughProperty("DarkLabel5")]
	internal virtual DarkLabel DarkLabel5 { get; set; }

	internal virtual DarkCheckBox CB_SlugTrail_Hostile
	{
		[CompilerGenerated]
		get
		{
			return _CB_SlugTrail_Hostile;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_64;
			DarkCheckBox darkCheckBox = _CB_SlugTrail_Hostile;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_SlugTrail_Hostile = value;
			darkCheckBox = _CB_SlugTrail_Hostile;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_SlugTrail_Neutral
	{
		[CompilerGenerated]
		get
		{
			return _CB_SlugTrail_Neutral;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_67;
			DarkCheckBox darkCheckBox = _CB_SlugTrail_Neutral;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_SlugTrail_Neutral = value;
			darkCheckBox = _CB_SlugTrail_Neutral;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_SlugTrail_Friendly
	{
		[CompilerGenerated]
		get
		{
			return _CB_SlugTrail_Friendly;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_63;
			DarkCheckBox darkCheckBox = _CB_SlugTrail_Friendly;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_SlugTrail_Friendly = value;
			darkCheckBox = _CB_SlugTrail_Friendly;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_SlugTrail_Own
	{
		[CompilerGenerated]
		get
		{
			return _CB_SlugTrail_Own;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_68;
			DarkCheckBox darkCheckBox = _CB_SlugTrail_Own;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_SlugTrail_Own = value;
			darkCheckBox = _CB_SlugTrail_Own;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_SlugTrail_UseSlugTrail
	{
		[CompilerGenerated]
		get
		{
			return _CB_SlugTrail_UseSlugTrail;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_62;
			DarkCheckBox darkCheckBox = _CB_SlugTrail_UseSlugTrail;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_SlugTrail_UseSlugTrail = value;
			darkCheckBox = _CB_SlugTrail_UseSlugTrail;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIComboBox Combo_SlugTrailFreq
	{
		[CompilerGenerated]
		get
		{
			return _Combo_SlugTrailFreq;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_69;
			DarkUIComboBox darkUIComboBox = _Combo_SlugTrailFreq;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_Combo_SlugTrailFreq = value;
			darkUIComboBox = _Combo_SlugTrailFreq;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkRichTextBox1")]
	internal virtual DarkRichTextBox DarkRichTextBox1 { get; set; }

	internal virtual DarkCheckBox CB_SlugTrail_Unfriendly
	{
		[CompilerGenerated]
		get
		{
			return _CB_SlugTrail_Unfriendly;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_65;
			DarkCheckBox darkCheckBox = _CB_SlugTrail_Unfriendly;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_SlugTrail_Unfriendly = value;
			darkCheckBox = _CB_SlugTrail_Unfriendly;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel6")]
	internal virtual DarkLabel DarkLabel6 { get; set; }

	private virtual NumericUpDown Num_SlugTrailLifetime
	{
		[CompilerGenerated]
		get
		{
			return _Num_SlugTrailLifetime;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_70;
			EventHandler eventHandler2 = method_71;
			NumericUpDown val = _Num_SlugTrailLifetime;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
				((Control)val).LostFocus -= eventHandler2;
			}
			_Num_SlugTrailLifetime = value;
			val = _Num_SlugTrailLifetime;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
				((Control)val).LostFocus += eventHandler2;
			}
		}
	}

	internal virtual DarkCheckBox CB_SlugTrail_Unknown
	{
		[CompilerGenerated]
		get
		{
			return _CB_SlugTrail_Unknown;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_66;
			DarkCheckBox darkCheckBox = _CB_SlugTrail_Unknown;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_SlugTrail_Unknown = value;
			darkCheckBox = _CB_SlugTrail_Unknown;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_CargoShowUSUnits
	{
		[CompilerGenerated]
		get
		{
			return _CB_CargoShowUSUnits;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_35;
			DarkCheckBox darkCheckBox = _CB_CargoShowUSUnits;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_CargoShowUSUnits = value;
			darkCheckBox = _CB_CargoShowUSUnits;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox ChkASWNoise
	{
		[CompilerGenerated]
		get
		{
			return darkCheckBox_0;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_72;
			DarkCheckBox darkCheckBox = darkCheckBox_0;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			darkCheckBox_0 = value;
			darkCheckBox = darkCheckBox_0;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIComboBox CP_ShowAU_Behaviour_Bark
	{
		[CompilerGenerated]
		get
		{
			return _CP_ShowAU_Behaviour_Bark;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_47;
			DarkUIComboBox darkUIComboBox = _CP_ShowAU_Behaviour_Bark;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CP_ShowAU_Behaviour_Bark = value;
			darkUIComboBox = _CP_ShowAU_Behaviour_Bark;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel7")]
	internal virtual DarkLabel DarkLabel7 { get; set; }

	internal virtual DarkUIButton ClearSlugTrail
	{
		[CompilerGenerated]
		get
		{
			return _ClearSlugTrail;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_73;
			DarkUIButton darkUIButton = _ClearSlugTrail;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ClearSlugTrail = value;
			darkUIButton = _ClearSlugTrail;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("lbl_GU_Zoom")]
	internal virtual DarkLabel lbl_GU_Zoom { get; set; }

	internal virtual TrackBar TB_GrounUnit_Zoom
	{
		[CompilerGenerated]
		get
		{
			return _TB_GrounUnit_Zoom;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_75;
			TrackBar val = _TB_GrounUnit_Zoom;
			if (val != null)
			{
				val.Scroll -= eventHandler;
			}
			_TB_GrounUnit_Zoom = value;
			val = _TB_GrounUnit_Zoom;
			if (val != null)
			{
				val.Scroll += eventHandler;
			}
		}
	}

	internal virtual DarkLabel DarkLabel10
	{
		[CompilerGenerated]
		get
		{
			return darkLabel_0;
		}
		[CompilerGenerated]
		set
		{
			darkLabel_0 = value;
		}
	}

	internal virtual TrackBar TB_Flower_Zoom
	{
		[CompilerGenerated]
		get
		{
			return _TB_Flower_Zoom;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_78;
			TrackBar val = _TB_Flower_Zoom;
			if (val != null)
			{
				val.Scroll -= eventHandler;
			}
			_TB_Flower_Zoom = value;
			val = _TB_Flower_Zoom;
			if (val != null)
			{
				val.Scroll += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel9")]
	internal virtual DarkLabel DarkLabel9 { get; set; }

	internal virtual TrackBar TB_Rectangle_Zoom
	{
		[CompilerGenerated]
		get
		{
			return _TB_Rectangle_Zoom;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_77;
			TrackBar val = _TB_Rectangle_Zoom;
			if (val != null)
			{
				val.Scroll -= eventHandler;
			}
			_TB_Rectangle_Zoom = value;
			val = _TB_Rectangle_Zoom;
			if (val != null)
			{
				val.Scroll += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel8")]
	internal virtual DarkLabel DarkLabel8 { get; set; }

	internal virtual TrackBar TB_Diamond_Zoom
	{
		[CompilerGenerated]
		get
		{
			return _TB_Diamond_Zoom;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_76;
			TrackBar val = _TB_Diamond_Zoom;
			if (val != null)
			{
				val.Scroll -= eventHandler;
			}
			_TB_Diamond_Zoom = value;
			val = _TB_Diamond_Zoom;
			if (val != null)
			{
				val.Scroll += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_DrawOutlines
	{
		[CompilerGenerated]
		get
		{
			return _CB_DrawOutlines;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_79;
			DarkCheckBox darkCheckBox = _CB_DrawOutlines;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_DrawOutlines = value;
			darkCheckBox = _CB_DrawOutlines;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox DetectStuckUnitPulsesCheckBox
	{
		[CompilerGenerated]
		get
		{
			return _DetectStuckUnitPulsesCheckBox;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_27;
			EventHandler eventHandler2 = method_28;
			DarkCheckBox darkCheckBox = _DetectStuckUnitPulsesCheckBox;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler2;
			}
			_DetectStuckUnitPulsesCheckBox = value;
			darkCheckBox = _DetectStuckUnitPulsesCheckBox;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler2;
			}
		}
	}

	internal virtual DarkLabel DarkLabel11
	{
		[CompilerGenerated]
		get
		{
			return darkLabel_1;
		}
		[CompilerGenerated]
		set
		{
			darkLabel_1 = value;
		}
	}

	internal virtual DarkUITextBox StuckUnitPulseThresholdMillisecondsTextBox
	{
		[CompilerGenerated]
		get
		{
			return _StuckUnitPulseThresholdMillisecondsTextBox;
		}
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = method_32;
			DarkUITextBox darkUITextBox = _StuckUnitPulseThresholdMillisecondsTextBox;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged -= value2;
			}
			_StuckUnitPulseThresholdMillisecondsTextBox = value;
			darkUITextBox = _StuckUnitPulseThresholdMillisecondsTextBox;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged += value2;
			}
		}
	}

	internal virtual DarkCheckBox SaveScenarioCopyOnDetectedStuckUnitPulseCheckBox
	{
		[CompilerGenerated]
		get
		{
			return _SaveScenarioCopyOnDetectedStuckUnitPulseCheckBox;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_30;
			DarkCheckBox darkCheckBox = _SaveScenarioCopyOnDetectedStuckUnitPulseCheckBox;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_SaveScenarioCopyOnDetectedStuckUnitPulseCheckBox = value;
			darkCheckBox = _SaveScenarioCopyOnDetectedStuckUnitPulseCheckBox;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox PauseOnDetectedStuckUnitPulseCheckBox
	{
		[CompilerGenerated]
		get
		{
			return _PauseOnDetectedStuckUnitPulseCheckBox;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_29;
			DarkCheckBox darkCheckBox = _PauseOnDetectedStuckUnitPulseCheckBox;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_PauseOnDetectedStuckUnitPulseCheckBox = value;
			darkCheckBox = _PauseOnDetectedStuckUnitPulseCheckBox;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DetectStuckUnitPulsesSettingsPanel")]
	internal virtual Panel DetectStuckUnitPulsesSettingsPanel { get; set; }

	internal virtual DarkLabel DarkLabel12
	{
		[CompilerGenerated]
		get
		{
			return darkLabel_2;
		}
		[CompilerGenerated]
		set
		{
			darkLabel_2 = value;
		}
	}

	[field: AccessedThroughProperty("AdditionalAltitudeOptionsPanel")]
	internal virtual FlowLayoutPanel AdditionalAltitudeOptionsPanel { get; set; }

	internal virtual DarkCheckBox CB_TrueAltitudeRenderFromGroundInsteadOfSurface
	{
		[CompilerGenerated]
		get
		{
			return _CB_TrueAltitudeRenderFromGroundInsteadOfSurface;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_84;
			DarkCheckBox darkCheckBox = _CB_TrueAltitudeRenderFromGroundInsteadOfSurface;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_TrueAltitudeRenderFromGroundInsteadOfSurface = value;
			darkCheckBox = _CB_TrueAltitudeRenderFromGroundInsteadOfSurface;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_TrueAltitudeRenderForceGroundUnitsAtSurface
	{
		[CompilerGenerated]
		get
		{
			return _CB_TrueAltitudeRenderForceGroundUnitsAtSurface;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_82;
			DarkCheckBox darkCheckBox = _CB_TrueAltitudeRenderForceGroundUnitsAtSurface;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_TrueAltitudeRenderForceGroundUnitsAtSurface = value;
			darkCheckBox = _CB_TrueAltitudeRenderForceGroundUnitsAtSurface;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkGroupBox3")]
	internal virtual DarkGroupBox DarkGroupBox3 { get; set; }

	internal virtual DarkCheckBox CB_DrawUnitsAtTrueAltitude
	{
		[CompilerGenerated]
		get
		{
			return _CB_DrawUnitsAtTrueAltitude;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_80;
			DarkCheckBox darkCheckBox = _CB_DrawUnitsAtTrueAltitude;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_DrawUnitsAtTrueAltitude = value;
			darkCheckBox = _CB_DrawUnitsAtTrueAltitude;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_TrueAltitudeRenderForceSubsurfaceUnitsAtSurface
	{
		[CompilerGenerated]
		get
		{
			return _CB_TrueAltitudeRenderForceSubsurfaceUnitsAtSurface;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_83;
			DarkCheckBox darkCheckBox = _CB_TrueAltitudeRenderForceSubsurfaceUnitsAtSurface;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_TrueAltitudeRenderForceSubsurfaceUnitsAtSurface = value;
			darkCheckBox = _CB_TrueAltitudeRenderForceSubsurfaceUnitsAtSurface;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkGroupBox4")]
	internal virtual DarkGroupBox DarkGroupBox4 { get; set; }

	[field: AccessedThroughProperty("TableLayoutPanel1")]
	internal virtual TableLayoutPanel TableLayoutPanel1 { get; set; }

	[field: AccessedThroughProperty("TerrainRenderingOptionsPanel")]
	internal virtual FlowLayoutPanel TerrainRenderingOptionsPanel { get; set; }

	[field: AccessedThroughProperty("TerrainDeformationGroupBox")]
	internal virtual DarkGroupBox TerrainDeformationGroupBox { get; set; }

	internal virtual TrackBar VerticalScalingMultiplierTrackBar
	{
		[CompilerGenerated]
		get
		{
			return _VerticalScalingMultiplierTrackBar;
		}
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = method_85;
			MouseEventHandler val = new MouseEventHandler(method_86);
			TrackBar val2 = _VerticalScalingMultiplierTrackBar;
			if (val2 != null)
			{
				val2.ValueChanged -= eventHandler;
				((Control)val2).MouseUp -= val;
			}
			_VerticalScalingMultiplierTrackBar = value;
			val2 = _VerticalScalingMultiplierTrackBar;
			if (val2 != null)
			{
				val2.ValueChanged += eventHandler;
				((Control)val2).MouseUp += val;
			}
		}
	}

	internal virtual DarkCheckBox CB_Show3DTerrain
	{
		[CompilerGenerated]
		get
		{
			return _CB_Show3DTerrain;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_81;
			DarkCheckBox darkCheckBox = _CB_Show3DTerrain;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_Show3DTerrain = value;
			darkCheckBox = _CB_Show3DTerrain;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("verticalScalingTextBox")]
	internal virtual DarkTextBox verticalScalingTextBox { get; set; }

	[field: AccessedThroughProperty("DarkTextBox1")]
	internal virtual DarkTextBox DarkTextBox1 { get; set; }

	[field: AccessedThroughProperty("DarkTextBox2")]
	internal virtual DarkTextBox DarkTextBox2 { get; set; }

	[field: AccessedThroughProperty("AltitudeAndTerrainOptionsPanel")]
	internal virtual Panel AltitudeAndTerrainOptionsPanel { get; set; }

	[field: AccessedThroughProperty("FlowLayoutPanel1")]
	internal virtual FlowLayoutPanel FlowLayoutPanel1 { get; set; }

	internal virtual OpenFileDialog OpenFileDialog1
	{
		[CompilerGenerated]
		get
		{
			return openFileDialog_0;
		}
		[CompilerGenerated]
		set
		{
			openFileDialog_0 = value;
		}
	}

	internal virtual DarkCheckBox CB_AggressiveTileManagement
	{
		[CompilerGenerated]
		get
		{
			return _CB_AggressiveTileManagement;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_87;
			DarkCheckBox darkCheckBox = _CB_AggressiveTileManagement;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_AggressiveTileManagement = value;
			darkCheckBox = _CB_AggressiveTileManagement;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_SmartRPPlacement
	{
		[CompilerGenerated]
		get
		{
			return _CB_SmartRPPlacement;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_88;
			DarkCheckBox darkCheckBox = _CB_SmartRPPlacement;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_SmartRPPlacement = value;
			darkCheckBox = _CB_SmartRPPlacement;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkUIComboBox CB_OSMstyle
	{
		[CompilerGenerated]
		get
		{
			return _CB_OSMstyle;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_39;
			DarkUIComboBox darkUIComboBox = _CB_OSMstyle;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_OSMstyle = value;
			darkUIComboBox = _CB_OSMstyle;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	internal virtual DarkLabel DarkLabel13
	{
		[CompilerGenerated]
		get
		{
			return darkLabel_3;
		}
		[CompilerGenerated]
		set
		{
			darkLabel_3 = value;
		}
	}

	[field: AccessedThroughProperty("DarkGroupBox5")]
	internal virtual DarkGroupBox DarkGroupBox5 { get; set; }

	[field: AccessedThroughProperty("TableLayoutPanel2")]
	internal virtual TableLayoutPanel TableLayoutPanel2 { get; set; }

	internal virtual TrackBar TB_Icon_Zoom
	{
		[CompilerGenerated]
		get
		{
			return _TB_Icon_Zoom;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_89;
			TrackBar val = _TB_Icon_Zoom;
			if (val != null)
			{
				val.Scroll -= eventHandler;
			}
			_TB_Icon_Zoom = value;
			val = _TB_Icon_Zoom;
			if (val != null)
			{
				val.Scroll += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("lblIconZoom")]
	internal virtual DarkLabel lblIconZoom { get; set; }

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

	public Options()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).Load += Options_Load;
		((Control)this).KeyDown += new KeyEventHandler(Options_KeyDown);
		((Form)this).FormClosing += new FormClosingEventHandler(Options_FormClosing);
		RTMPEnabled = true;
		gamePreferences_0 = SimConfiguration.DefaultGamePreferences;
		bool_3 = false;
		bool_4 = false;
		bool_5 = true;
		InitializeComponent_1();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_1 != null)
		{
			icontainer_1.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent_1()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Expected O, but got Unknown
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Expected O, but got Unknown
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Expected O, but got Unknown
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Expected O, but got Unknown
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Expected O, but got Unknown
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected O, but got Unknown
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Expected O, but got Unknown
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Expected O, but got Unknown
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Expected O, but got Unknown
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Expected O, but got Unknown
		//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b1: Expected O, but got Unknown
		//IL_030a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Expected O, but got Unknown
		//IL_045f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0469: Expected O, but got Unknown
		//IL_0475: Unknown result type (might be due to invalid IL or missing references)
		//IL_047f: Expected O, but got Unknown
		//IL_0480: Unknown result type (might be due to invalid IL or missing references)
		//IL_048a: Expected O, but got Unknown
		//IL_048b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0495: Expected O, but got Unknown
		//IL_0496: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a0: Expected O, but got Unknown
		//IL_04a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ab: Expected O, but got Unknown
		//IL_04ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b6: Expected O, but got Unknown
		//IL_04b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c1: Expected O, but got Unknown
		//IL_04d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e2: Expected O, but got Unknown
		//IL_04e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ed: Expected O, but got Unknown
		//IL_0504: Unknown result type (might be due to invalid IL or missing references)
		//IL_050e: Expected O, but got Unknown
		//IL_05d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05df: Expected O, but got Unknown
		//IL_0601: Unknown result type (might be due to invalid IL or missing references)
		//IL_060b: Expected O, but got Unknown
		//IL_060c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0616: Expected O, but got Unknown
		//IL_0617: Unknown result type (might be due to invalid IL or missing references)
		//IL_0621: Expected O, but got Unknown
		//IL_062d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0637: Expected O, but got Unknown
		//IL_0638: Unknown result type (might be due to invalid IL or missing references)
		//IL_0642: Expected O, but got Unknown
		//IL_0890: Unknown result type (might be due to invalid IL or missing references)
		//IL_089a: Expected O, but got Unknown
		//IL_0ab8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d46: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d50: Expected O, but got Unknown
		//IL_11bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_11c9: Expected O, but got Unknown
		//IL_13c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_13cc: Expected O, but got Unknown
		//IL_156a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1574: Expected O, but got Unknown
		//IL_1637: Unknown result type (might be due to invalid IL or missing references)
		//IL_1641: Expected O, but got Unknown
		//IL_186f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1879: Expected O, but got Unknown
		//IL_19b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_19c1: Expected O, but got Unknown
		//IL_1cb2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cbc: Expected O, but got Unknown
		//IL_1cf9: Unknown result type (might be due to invalid IL or missing references)
		//IL_214f: Unknown result type (might be due to invalid IL or missing references)
		//IL_21c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_21d1: Expected O, but got Unknown
		//IL_2369: Unknown result type (might be due to invalid IL or missing references)
		//IL_2373: Expected O, but got Unknown
		//IL_2468: Unknown result type (might be due to invalid IL or missing references)
		//IL_2472: Expected O, but got Unknown
		//IL_2484: Unknown result type (might be due to invalid IL or missing references)
		//IL_248e: Expected O, but got Unknown
		//IL_24a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_24aa: Expected O, but got Unknown
		//IL_24bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_24c6: Expected O, but got Unknown
		//IL_24d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_24e2: Expected O, but got Unknown
		//IL_24f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_24fe: Expected O, but got Unknown
		//IL_2510: Unknown result type (might be due to invalid IL or missing references)
		//IL_251a: Expected O, but got Unknown
		//IL_252c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2536: Expected O, but got Unknown
		//IL_2548: Unknown result type (might be due to invalid IL or missing references)
		//IL_2552: Expected O, but got Unknown
		//IL_2b82: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c9e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2df4: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e84: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f52: Unknown result type (might be due to invalid IL or missing references)
		//IL_3011: Unknown result type (might be due to invalid IL or missing references)
		//IL_3145: Unknown result type (might be due to invalid IL or missing references)
		//IL_31bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_3233: Unknown result type (might be due to invalid IL or missing references)
		//IL_33c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_33d3: Expected O, but got Unknown
		//IL_3728: Unknown result type (might be due to invalid IL or missing references)
		//IL_3cce: Unknown result type (might be due to invalid IL or missing references)
		//IL_3cd8: Expected O, but got Unknown
		//IL_3e11: Unknown result type (might be due to invalid IL or missing references)
		//IL_3efd: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f07: Expected O, but got Unknown
		//IL_405c: Unknown result type (might be due to invalid IL or missing references)
		//IL_4066: Expected O, but got Unknown
		//IL_420f: Unknown result type (might be due to invalid IL or missing references)
		//IL_4219: Expected O, but got Unknown
		//IL_435b: Unknown result type (might be due to invalid IL or missing references)
		//IL_4365: Expected O, but got Unknown
		//IL_44aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_44b4: Expected O, but got Unknown
		//IL_45f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_4602: Expected O, but got Unknown
		//IL_4741: Unknown result type (might be due to invalid IL or missing references)
		//IL_474b: Expected O, but got Unknown
		//IL_488a: Unknown result type (might be due to invalid IL or missing references)
		//IL_4894: Expected O, but got Unknown
		//IL_49ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_4ac8: Unknown result type (might be due to invalid IL or missing references)
		//IL_4ad2: Expected O, but got Unknown
		//IL_4b97: Unknown result type (might be due to invalid IL or missing references)
		//IL_4ba1: Expected O, but got Unknown
		//IL_52c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_5c5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_5e15: Unknown result type (might be due to invalid IL or missing references)
		//IL_5f32: Unknown result type (might be due to invalid IL or missing references)
		//IL_60b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_60bb: Expected O, but got Unknown
		//IL_6120: Unknown result type (might be due to invalid IL or missing references)
		//IL_612a: Expected O, but got Unknown
		//IL_613c: Unknown result type (might be due to invalid IL or missing references)
		//IL_6146: Expected O, but got Unknown
		//IL_6158: Unknown result type (might be due to invalid IL or missing references)
		//IL_6162: Expected O, but got Unknown
		//IL_6174: Unknown result type (might be due to invalid IL or missing references)
		//IL_617e: Expected O, but got Unknown
		//IL_6190: Unknown result type (might be due to invalid IL or missing references)
		//IL_619a: Expected O, but got Unknown
		//IL_61ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_61b6: Expected O, but got Unknown
		//IL_61c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_61d2: Expected O, but got Unknown
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		TabControl1 = new DarkUITabControl();
		TabPage1 = new TabPage();
		CB_SmartRPPlacement = new DarkCheckBox();
		DetectStuckUnitPulsesSettingsPanel = new Panel();
		DarkLabel12 = new DarkLabel();
		SaveScenarioCopyOnDetectedStuckUnitPulseCheckBox = new DarkCheckBox();
		StuckUnitPulseThresholdMillisecondsTextBox = new DarkUITextBox();
		PauseOnDetectedStuckUnitPulseCheckBox = new DarkCheckBox();
		DarkLabel11 = new DarkLabel();
		DetectStuckUnitPulsesCheckBox = new DarkCheckBox();
		CB_RMB_MoveOrder = new DarkCheckBox();
		DarkGroupBox1 = new DarkGroupBox();
		CB_CargoShowUSUnits = new DarkCheckBox();
		Combo_CoordinateUnit = new DarkUIComboBox();
		GeocentricCoordLabel = new DarkLabel();
		DarkLabel2 = new DarkLabel();
		CB_AltitudeInFeet = new DarkCheckBox();
		Combo_GroundSpeedUnit = new DarkUIComboBox();
		GB_PauseBehaviour = new DarkGroupBox();
		CB_DVViewerPauseBehaviour = new DarkUIComboBox();
		CB_AirDockPauseBehaviour = new DarkUIComboBox();
		DarkLabel4 = new DarkLabel();
		DarkLabel3 = new DarkLabel();
		CB_LogDebugInfoToFile = new DarkCheckBox();
		TB_Navigation_ThresholdDistanceDeg = new DarkUITextBox();
		TB_Navigation_MaxDistanceNM = new DarkUITextBox();
		Label8 = new DarkLabel();
		Label7 = new DarkLabel();
		CB_AllowPowerScemeSwitch = new DarkCheckBox();
		CB_UnitStatusImage = new DarkCheckBox();
		Button_ResetWindowPlacement = new DarkUIButton();
		CB_ZoomOnCursor = new DarkCheckBox();
		CB_MessageLogInWindow = new DarkCheckBox();
		CB_UseAutosave = new DarkCheckBox();
		TabPage4 = new TabPage();
		CB_OSMstyle = new DarkUIComboBox();
		DarkLabel13 = new DarkLabel();
		DarkGroupBox4 = new DarkGroupBox();
		TableLayoutPanel1 = new TableLayoutPanel();
		TB_Flower_Zoom = new TrackBar();
		DarkLabel10 = new DarkLabel();
		TB_GrounUnit_Zoom = new TrackBar();
		TB_Rectangle_Zoom = new TrackBar();
		DarkLabel8 = new DarkLabel();
		DarkLabel9 = new DarkLabel();
		TB_Diamond_Zoom = new TrackBar();
		lbl_GU_Zoom = new DarkLabel();
		DarkGroupBox3 = new DarkGroupBox();
		AltitudeAndTerrainOptionsPanel = new Panel();
		TerrainDeformationGroupBox = new DarkGroupBox();
		CB_Show3DTerrain = new DarkCheckBox();
		TerrainRenderingOptionsPanel = new FlowLayoutPanel();
		verticalScalingTextBox = new DarkTextBox();
		VerticalScalingMultiplierTrackBar = new TrackBar();
		DarkTextBox1 = new DarkTextBox();
		DarkTextBox2 = new DarkTextBox();
		AdditionalAltitudeOptionsPanel = new FlowLayoutPanel();
		CB_TrueAltitudeRenderForceSubsurfaceUnitsAtSurface = new DarkCheckBox();
		CB_TrueAltitudeRenderForceGroundUnitsAtSurface = new DarkCheckBox();
		CB_TrueAltitudeRenderFromGroundInsteadOfSurface = new DarkCheckBox();
		FlowLayoutPanel1 = new FlowLayoutPanel();
		CB_DrawUnitsAtTrueAltitude = new DarkCheckBox();
		CB_DrawOutlines = new DarkCheckBox();
		CP_ShowAU_Behaviour_Bark = new DarkUIComboBox();
		DarkLabel7 = new DarkLabel();
		ChkASWNoise = new DarkCheckBox();
		DarkGroupBox2 = new DarkGroupBox();
		ClearSlugTrail = new DarkUIButton();
		CB_SlugTrail_Unknown = new DarkCheckBox();
		Num_SlugTrailLifetime = new NumericUpDown();
		DarkLabel6 = new DarkLabel();
		CB_SlugTrail_Unfriendly = new DarkCheckBox();
		DarkRichTextBox1 = new DarkRichTextBox();
		DarkLabel5 = new DarkLabel();
		CB_SlugTrail_Hostile = new DarkCheckBox();
		CB_SlugTrail_Neutral = new DarkCheckBox();
		CB_SlugTrail_Friendly = new DarkCheckBox();
		CB_SlugTrail_Own = new DarkCheckBox();
		CB_SlugTrail_UseSlugTrail = new DarkCheckBox();
		Combo_SlugTrailFreq = new DarkUIComboBox();
		CB_ColorDatablocks = new DarkCheckBox();
		Button_SetPersonalMapProfile = new DarkUIButton();
		CB_UsePersonalMapProfile = new DarkCheckBox();
		CP_ShowFlightPlans_Planned = new DarkUIComboBox();
		Label11 = new DarkLabel();
		CP_ShowFlightPlans_Airborne = new DarkUIComboBox();
		Label20 = new DarkLabel();
		CB_ShowDiagnostics = new DarkCheckBox();
		CP_ShowPlottedPaths = new DarkUIComboBox();
		Label6 = new DarkLabel();
		CP_ShowGhostedGroupMembers = new DarkUIComboBox();
		Label5 = new DarkLabel();
		CB_MapSymbols = new DarkUIComboBox();
		Label4 = new DarkLabel();
		CB_MapCursorBox = new DarkUIComboBox();
		Label3 = new DarkLabel();
		CB_RefPointVisibility = new DarkUIComboBox();
		Label2 = new DarkLabel();
		CB_SonobuoyVisibility = new DarkUIComboBox();
		Label1 = new DarkLabel();
		TabPage2 = new TabPage();
		DataGridView1 = new DarkDataGridView();
		MessageType_Hidden = new DataGridViewTextBoxColumn();
		MessageType = new DataGridViewTextBoxColumn();
		MessageLog = new DataGridViewCheckBoxColumn();
		PopUp = new DataGridViewCheckBoxColumn();
		Column_ShowBalloon = new DataGridViewCheckBoxColumn();
		Timescale_X1 = new DataGridViewCheckBoxColumn();
		TabPage3 = new TabPage();
		SFXVolumeLabel = new DarkLabel();
		MusicVolumeLabel = new DarkLabel();
		TB_SFXVolumeBar = new TrackBar();
		TB_MusicVolumeBar = new TrackBar();
		CB_Music = new DarkCheckBox();
		CB_Sounds = new DarkCheckBox();
		TabPage5 = new TabPage();
		GroupBox3 = new DarkGroupBox();
		CB_Autosave = new DarkCheckBox();
		GroupBox2 = new DarkGroupBox();
		CB_FriendlyRangeSymbols = new DarkCheckBox();
		CB_DisplayIlluminationVectors = new DarkCheckBox();
		CB_DisplayContactEmissions = new DarkCheckBox();
		GroupBox1 = new DarkGroupBox();
		CB_AggressiveTileManagement = new DarkCheckBox();
		CB_ExtraMemoryProtection = new DarkCheckBox();
		CB_DisplayTargetingVectors = new DarkCheckBox();
		CB_DisallowHighPerformancePowerScheme = new DarkCheckBox();
		CB_ShowGhostedGroupMembers = new DarkCheckBox();
		CB_DisplayDatalinks = new DarkCheckBox();
		CB_DisplayMissionAreas = new DarkCheckBox();
		CB_DisplayCountryAndCityNames = new DarkCheckBox();
		CB_CustomFineGrainedNavigation = new DarkCheckBox();
		CB_NonFriendlyRangeSymbols = new DarkCheckBox();
		Label9 = new DarkLabel();
		TabPage6 = new TabPage();
		TB_TacviewPath = new DarkUITextBox();
		Button_TacviewPath = new DarkUIButton();
		DarkLabel1 = new DarkLabel();
		TabPage7 = new TabPage();
		ElementHost1 = new ElementHost();
		OpenFileDialog1 = new OpenFileDialog();
		DarkGroupBox5 = new DarkGroupBox();
		TableLayoutPanel2 = new TableLayoutPanel();
		TB_Icon_Zoom = new TrackBar();
		lblIconZoom = new DarkLabel();
		((Control)TabControl1).SuspendLayout();
		((Control)TabPage1).SuspendLayout();
		((Control)DetectStuckUnitPulsesSettingsPanel).SuspendLayout();
		((Control)DarkGroupBox1).SuspendLayout();
		((Control)GB_PauseBehaviour).SuspendLayout();
		((Control)TabPage4).SuspendLayout();
		((Control)DarkGroupBox4).SuspendLayout();
		((Control)TableLayoutPanel1).SuspendLayout();
		((ISupportInitialize)TB_Flower_Zoom).BeginInit();
		((ISupportInitialize)TB_GrounUnit_Zoom).BeginInit();
		((ISupportInitialize)TB_Rectangle_Zoom).BeginInit();
		((ISupportInitialize)TB_Diamond_Zoom).BeginInit();
		((Control)DarkGroupBox3).SuspendLayout();
		((Control)AltitudeAndTerrainOptionsPanel).SuspendLayout();
		((Control)TerrainDeformationGroupBox).SuspendLayout();
		((Control)TerrainRenderingOptionsPanel).SuspendLayout();
		((ISupportInitialize)VerticalScalingMultiplierTrackBar).BeginInit();
		((Control)AdditionalAltitudeOptionsPanel).SuspendLayout();
		((Control)DarkGroupBox2).SuspendLayout();
		((ISupportInitialize)Num_SlugTrailLifetime).BeginInit();
		((Control)TabPage2).SuspendLayout();
		((ISupportInitialize)(object)DataGridView1).BeginInit();
		((Control)TabPage3).SuspendLayout();
		((ISupportInitialize)TB_SFXVolumeBar).BeginInit();
		((ISupportInitialize)TB_MusicVolumeBar).BeginInit();
		((Control)TabPage5).SuspendLayout();
		((Control)GroupBox3).SuspendLayout();
		((Control)GroupBox2).SuspendLayout();
		((Control)GroupBox1).SuspendLayout();
		((Control)TabPage6).SuspendLayout();
		((Control)TabPage7).SuspendLayout();
		((Control)DarkGroupBox5).SuspendLayout();
		((Control)TableLayoutPanel2).SuspendLayout();
		((ISupportInitialize)TB_Icon_Zoom).BeginInit();
		((Control)this).SuspendLayout();
		((Control)TabControl1).Anchor = (AnchorStyles)15;
		((Control)TabControl1).Controls.Add((Control)(object)TabPage1);
		((Control)TabControl1).Controls.Add((Control)(object)TabPage4);
		((Control)TabControl1).Controls.Add((Control)(object)TabPage2);
		((Control)TabControl1).Controls.Add((Control)(object)TabPage3);
		((Control)TabControl1).Controls.Add((Control)(object)TabPage5);
		((Control)TabControl1).Controls.Add((Control)(object)TabPage6);
		((Control)TabControl1).Controls.Add((Control)(object)TabPage7);
		((Control)TabControl1).Cursor = Cursors.Hand;
		((Control)TabControl1).Font = new Font("Segoe UI", 8f);
		((TabControl)TabControl1).ItemSize = new Size(80, 20);
		((Control)TabControl1).Location = new Point(0, 0);
		((Control)TabControl1).Name = "TabControl1";
		((TabControl)TabControl1).SelectedIndex = 0;
		((Control)TabControl1).Size = new Size(702, 669);
		((Control)TabControl1).TabIndex = 0;
		TabPage1.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage1).Controls.Add((Control)(object)CB_SmartRPPlacement);
		((Control)TabPage1).Controls.Add((Control)(object)DetectStuckUnitPulsesSettingsPanel);
		((Control)TabPage1).Controls.Add((Control)(object)DetectStuckUnitPulsesCheckBox);
		((Control)TabPage1).Controls.Add((Control)(object)CB_RMB_MoveOrder);
		((Control)TabPage1).Controls.Add((Control)(object)DarkGroupBox1);
		((Control)TabPage1).Controls.Add((Control)(object)GB_PauseBehaviour);
		((Control)TabPage1).Controls.Add((Control)(object)CB_LogDebugInfoToFile);
		((Control)TabPage1).Controls.Add((Control)(object)TB_Navigation_ThresholdDistanceDeg);
		((Control)TabPage1).Controls.Add((Control)(object)TB_Navigation_MaxDistanceNM);
		((Control)TabPage1).Controls.Add((Control)(object)Label8);
		((Control)TabPage1).Controls.Add((Control)(object)Label7);
		((Control)TabPage1).Controls.Add((Control)(object)CB_AllowPowerScemeSwitch);
		((Control)TabPage1).Controls.Add((Control)(object)CB_UnitStatusImage);
		((Control)TabPage1).Controls.Add((Control)(object)Button_ResetWindowPlacement);
		((Control)TabPage1).Controls.Add((Control)(object)CB_ZoomOnCursor);
		((Control)TabPage1).Controls.Add((Control)(object)CB_MessageLogInWindow);
		((Control)TabPage1).Controls.Add((Control)(object)CB_UseAutosave);
		TabPage1.Location = new Point(4, 24);
		((Control)TabPage1).Name = "TabPage1";
		((Control)TabPage1).Padding = new Padding(3);
		((Control)TabPage1).Size = new Size(694, 641);
		TabPage1.TabIndex = 1;
		TabPage1.Text = "General";
		((ButtonBase)CB_SmartRPPlacement).AutoSize = true;
		((Control)CB_SmartRPPlacement).Location = new Point(6, 404);
		((Control)CB_SmartRPPlacement).Name = "CB_SmartRPPlacement";
		((Control)CB_SmartRPPlacement).Size = new Size(169, 17);
		((Control)CB_SmartRPPlacement).TabIndex = 36;
		((ButtonBase)CB_SmartRPPlacement).Text = "Enable Smart RPs Placement";
		((Control)DetectStuckUnitPulsesSettingsPanel).Controls.Add((Control)(object)DarkLabel12);
		((Control)DetectStuckUnitPulsesSettingsPanel).Controls.Add((Control)(object)SaveScenarioCopyOnDetectedStuckUnitPulseCheckBox);
		((Control)DetectStuckUnitPulsesSettingsPanel).Controls.Add((Control)(object)StuckUnitPulseThresholdMillisecondsTextBox);
		((Control)DetectStuckUnitPulsesSettingsPanel).Controls.Add((Control)(object)PauseOnDetectedStuckUnitPulseCheckBox);
		((Control)DetectStuckUnitPulsesSettingsPanel).Controls.Add((Control)(object)DarkLabel11);
		((Control)DetectStuckUnitPulsesSettingsPanel).Location = new Point(151, 141);
		((Control)DetectStuckUnitPulsesSettingsPanel).Name = "DetectStuckUnitPulsesSettingsPanel";
		((Control)DetectStuckUnitPulsesSettingsPanel).Size = new Size(494, 17);
		((Control)DetectStuckUnitPulsesSettingsPanel).TabIndex = 35;
		DarkLabel12.AutoSize = true;
		((Control)DarkLabel12).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel12).Location = new Point(-1, 2);
		((Control)DarkLabel12).Name = "DarkLabel12";
		((Control)DarkLabel12).Size = new Size(10, 13);
		((Control)DarkLabel12).TabIndex = 33;
		((Label)DarkLabel12).Text = "(";
		((ButtonBase)SaveScenarioCopyOnDetectedStuckUnitPulseCheckBox).AutoSize = true;
		((Control)SaveScenarioCopyOnDetectedStuckUnitPulseCheckBox).Location = new Point(245, 0);
		((Control)SaveScenarioCopyOnDetectedStuckUnitPulseCheckBox).Name = "SaveScenarioCopyOnDetectedStuckUnitPulseCheckBox";
		((Control)SaveScenarioCopyOnDetectedStuckUnitPulseCheckBox).Size = new Size(173, 17);
		((Control)SaveScenarioCopyOnDetectedStuckUnitPulseCheckBox).TabIndex = 34;
		((ButtonBase)SaveScenarioCopyOnDetectedStuckUnitPulseCheckBox).Text = "save pre-pulse scenario copy";
		StuckUnitPulseThresholdMillisecondsTextBox.AutoCompleteCustomSource = null;
		StuckUnitPulseThresholdMillisecondsTextBox.AutoCompleteMode = (AutoCompleteMode)0;
		StuckUnitPulseThresholdMillisecondsTextBox.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)StuckUnitPulseThresholdMillisecondsTextBox).BackColor = Color.Transparent;
		StuckUnitPulseThresholdMillisecondsTextBox.Font = new Font("Segoe UI", 8f);
		((Control)StuckUnitPulseThresholdMillisecondsTextBox).ForeColor = Color.FromArgb(189, 189, 189);
		StuckUnitPulseThresholdMillisecondsTextBox.Image = null;
		StuckUnitPulseThresholdMillisecondsTextBox.Lines = null;
		((Control)StuckUnitPulseThresholdMillisecondsTextBox).Location = new Point(6, 0);
		StuckUnitPulseThresholdMillisecondsTextBox.MaxLength = 32767;
		StuckUnitPulseThresholdMillisecondsTextBox.Multiline = false;
		((Control)StuckUnitPulseThresholdMillisecondsTextBox).Name = "StuckUnitPulseThresholdMillisecondsTextBox";
		StuckUnitPulseThresholdMillisecondsTextBox.ReadOnly = false;
		StuckUnitPulseThresholdMillisecondsTextBox.ScrollBars = (ScrollBars)0;
		StuckUnitPulseThresholdMillisecondsTextBox.SelectionStart = 0;
		((Control)StuckUnitPulseThresholdMillisecondsTextBox).Size = new Size(36, 20);
		((Control)StuckUnitPulseThresholdMillisecondsTextBox).TabIndex = 31;
		StuckUnitPulseThresholdMillisecondsTextBox.Text = "5000";
		StuckUnitPulseThresholdMillisecondsTextBox.TextAlign = (HorizontalAlignment)1;
		StuckUnitPulseThresholdMillisecondsTextBox.UseSystemPasswordChar = false;
		StuckUnitPulseThresholdMillisecondsTextBox.WatermarkText = "";
		StuckUnitPulseThresholdMillisecondsTextBox.WordWrap = false;
		((ButtonBase)PauseOnDetectedStuckUnitPulseCheckBox).AutoSize = true;
		((Control)PauseOnDetectedStuckUnitPulseCheckBox).Location = new Point(178, 0);
		((Control)PauseOnDetectedStuckUnitPulseCheckBox).Name = "PauseOnDetectedStuckUnitPulseCheckBox";
		((Control)PauseOnDetectedStuckUnitPulseCheckBox).Size = new Size(57, 17);
		((Control)PauseOnDetectedStuckUnitPulseCheckBox).TabIndex = 33;
		((ButtonBase)PauseOnDetectedStuckUnitPulseCheckBox).Text = "pause";
		DarkLabel11.AutoSize = true;
		((Control)DarkLabel11).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel11).Location = new Point(39, 2);
		((Control)DarkLabel11).Name = "DarkLabel11";
		((Control)DarkLabel11).Size = new Size(126, 13);
		((Control)DarkLabel11).TabIndex = 32;
		((Label)DarkLabel11).Text = "milliseconds threshold)";
		((ButtonBase)DetectStuckUnitPulsesCheckBox).AutoSize = true;
		((CheckBox)DetectStuckUnitPulsesCheckBox).Checked = true;
		((CheckBox)DetectStuckUnitPulsesCheckBox).CheckState = (CheckState)1;
		((Control)DetectStuckUnitPulsesCheckBox).Location = new Point(8, 142);
		((Control)DetectStuckUnitPulsesCheckBox).Name = "DetectStuckUnitPulsesCheckBox";
		((Control)DetectStuckUnitPulsesCheckBox).Size = new Size(149, 17);
		((Control)DetectStuckUnitPulsesCheckBox).TabIndex = 30;
		((ButtonBase)DetectStuckUnitPulsesCheckBox).Text = "Detect stuck unit pulses";
		((ButtonBase)CB_RMB_MoveOrder).AutoSize = true;
		((Control)CB_RMB_MoveOrder).Location = new Point(6, 386);
		((Control)CB_RMB_MoveOrder).Name = "CB_RMB_MoveOrder";
		((Control)CB_RMB_MoveOrder).Size = new Size(218, 17);
		((Control)CB_RMB_MoveOrder).TabIndex = 29;
		((ButtonBase)CB_RMB_MoveOrder).Text = "Enable Right Mouse Click move order";
		((Control)DarkGroupBox1).Controls.Add((Control)(object)CB_CargoShowUSUnits);
		((Control)DarkGroupBox1).Controls.Add((Control)(object)Combo_CoordinateUnit);
		((Control)DarkGroupBox1).Controls.Add((Control)(object)GeocentricCoordLabel);
		((Control)DarkGroupBox1).Controls.Add((Control)(object)DarkLabel2);
		((Control)DarkGroupBox1).Controls.Add((Control)(object)CB_AltitudeInFeet);
		((Control)DarkGroupBox1).Controls.Add((Control)(object)Combo_GroundSpeedUnit);
		((Control)DarkGroupBox1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkGroupBox1).Location = new Point(6, 190);
		((Control)DarkGroupBox1).Name = "DarkGroupBox1";
		((Control)DarkGroupBox1).Size = new Size(346, 111);
		((Control)DarkGroupBox1).TabIndex = 28;
		((GroupBox)DarkGroupBox1).TabStop = false;
		((GroupBox)DarkGroupBox1).Text = "Unit System";
		((ButtonBase)CB_CargoShowUSUnits).AutoSize = true;
		((Control)CB_CargoShowUSUnits).Location = new Point(8, 87);
		((Control)CB_CargoShowUSUnits).Name = "CB_CargoShowUSUnits";
		((Control)CB_CargoShowUSUnits).Size = new Size(180, 17);
		((Control)CB_CargoShowUSUnits).TabIndex = 29;
		((ButtonBase)CB_CargoShowUSUnits).Text = "Show US units in cargo editor";
		((ComboBox)Combo_CoordinateUnit).BackColor = Color.Transparent;
		((ComboBox)Combo_CoordinateUnit).DrawMode = (DrawMode)1;
		((ComboBox)Combo_CoordinateUnit).DropDownStyle = (ComboBoxStyle)2;
		((Control)Combo_CoordinateUnit).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)Combo_CoordinateUnit).FormattingEnabled = true;
		((Control)Combo_CoordinateUnit).Location = new Point(230, 65);
		((Control)Combo_CoordinateUnit).Name = "Combo_CoordinateUnit";
		((Control)Combo_CoordinateUnit).Size = new Size(110, 21);
		((Control)Combo_CoordinateUnit).TabIndex = 28;
		GeocentricCoordLabel.AutoSize = true;
		((Control)GeocentricCoordLabel).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GeocentricCoordLabel).Location = new Point(6, 65);
		((Control)GeocentricCoordLabel).Name = "GeocentricCoordLabel";
		((Control)GeocentricCoordLabel).Size = new Size(170, 13);
		((Control)GeocentricCoordLabel).TabIndex = 27;
		((Label)GeocentricCoordLabel).Text = "Geocentric Coordinate System : ";
		DarkLabel2.AutoSize = true;
		((Control)DarkLabel2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel2).Location = new Point(6, 43);
		((Control)DarkLabel2).Name = "DarkLabel2";
		((Control)DarkLabel2).Size = new Size(218, 13);
		((Control)DarkLabel2).TabIndex = 25;
		((Label)DarkLabel2).Text = "Show speed of ground units/contacts in:";
		((ButtonBase)CB_AltitudeInFeet).AutoSize = true;
		((Control)CB_AltitudeInFeet).Location = new Point(8, 20);
		((Control)CB_AltitudeInFeet).Name = "CB_AltitudeInFeet";
		((Control)CB_AltitudeInFeet).Size = new Size(136, 17);
		((Control)CB_AltitudeInFeet).TabIndex = 6;
		((ButtonBase)CB_AltitudeInFeet).Text = "Show altitude in Feet";
		((ComboBox)Combo_GroundSpeedUnit).BackColor = Color.Transparent;
		((ComboBox)Combo_GroundSpeedUnit).DrawMode = (DrawMode)1;
		((ComboBox)Combo_GroundSpeedUnit).DropDownStyle = (ComboBoxStyle)2;
		((Control)Combo_GroundSpeedUnit).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)Combo_GroundSpeedUnit).FormattingEnabled = true;
		((ComboBox)Combo_GroundSpeedUnit).Items.AddRange(new object[3] { "Knots", "KPH", "MPH" });
		((Control)Combo_GroundSpeedUnit).Location = new Point(230, 41);
		((Control)Combo_GroundSpeedUnit).Name = "Combo_GroundSpeedUnit";
		((Control)Combo_GroundSpeedUnit).Size = new Size(110, 21);
		((Control)Combo_GroundSpeedUnit).TabIndex = 26;
		((Control)GB_PauseBehaviour).Controls.Add((Control)(object)CB_DVViewerPauseBehaviour);
		((Control)GB_PauseBehaviour).Controls.Add((Control)(object)CB_AirDockPauseBehaviour);
		((Control)GB_PauseBehaviour).Controls.Add((Control)(object)DarkLabel4);
		((Control)GB_PauseBehaviour).Controls.Add((Control)(object)DarkLabel3);
		((Control)GB_PauseBehaviour).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GB_PauseBehaviour).Location = new Point(6, 307);
		((Control)GB_PauseBehaviour).Name = "GB_PauseBehaviour";
		((Control)GB_PauseBehaviour).Size = new Size(346, 77);
		((Control)GB_PauseBehaviour).TabIndex = 27;
		((GroupBox)GB_PauseBehaviour).TabStop = false;
		((GroupBox)GB_PauseBehaviour).Text = "Window Opening Behaviour";
		((ComboBox)CB_DVViewerPauseBehaviour).BackColor = Color.Transparent;
		((ComboBox)CB_DVViewerPauseBehaviour).DrawMode = (DrawMode)1;
		((ComboBox)CB_DVViewerPauseBehaviour).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_DVViewerPauseBehaviour).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)CB_DVViewerPauseBehaviour).FormattingEnabled = true;
		((ComboBox)CB_DVViewerPauseBehaviour).Items.AddRange(new object[3] { "Auto-Pause", "Slow to Real-Time", "Current Time Compression" });
		((Control)CB_DVViewerPauseBehaviour).Location = new Point(163, 45);
		((Control)CB_DVViewerPauseBehaviour).Name = "CB_DVViewerPauseBehaviour";
		((Control)CB_DVViewerPauseBehaviour).Size = new Size(176, 21);
		((Control)CB_DVViewerPauseBehaviour).TabIndex = 3;
		((ComboBox)CB_AirDockPauseBehaviour).BackColor = Color.Transparent;
		((ComboBox)CB_AirDockPauseBehaviour).DrawMode = (DrawMode)1;
		((ComboBox)CB_AirDockPauseBehaviour).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_AirDockPauseBehaviour).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)CB_AirDockPauseBehaviour).FormattingEnabled = true;
		((ComboBox)CB_AirDockPauseBehaviour).Items.AddRange(new object[3] { "Auto-Pause", "Slow to Real-Time", "Current Time Compression" });
		((Control)CB_AirDockPauseBehaviour).Location = new Point(164, 18);
		((Control)CB_AirDockPauseBehaviour).Name = "CB_AirDockPauseBehaviour";
		((Control)CB_AirDockPauseBehaviour).Size = new Size(175, 21);
		((Control)CB_AirDockPauseBehaviour).TabIndex = 2;
		DarkLabel4.AutoSize = true;
		((Control)DarkLabel4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel4).Location = new Point(6, 47);
		((Control)DarkLabel4).Name = "DarkLabel4";
		((Control)DarkLabel4).Size = new Size(93, 13);
		((Control)DarkLabel4).TabIndex = 1;
		((Label)DarkLabel4).Text = "Database Viewer";
		DarkLabel3.AutoSize = true;
		((Control)DarkLabel3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel3).Location = new Point(6, 20);
		((Control)DarkLabel3).Name = "DarkLabel3";
		((Control)DarkLabel3).Size = new Size(155, 13);
		((Control)DarkLabel3).TabIndex = 0;
		((Label)DarkLabel3).Text = "Air Ops / Docking Ops Menu";
		((ButtonBase)CB_LogDebugInfoToFile).AutoSize = true;
		((Control)CB_LogDebugInfoToFile).Location = new Point(8, 119);
		((Control)CB_LogDebugInfoToFile).Name = "CB_LogDebugInfoToFile";
		((Control)CB_LogDebugInfoToFile).Size = new Size(289, 17);
		((Control)CB_LogDebugInfoToFile).TabIndex = 24;
		((ButtonBase)CB_LogDebugInfoToFile).Text = "Log debug information to file (only for debugging)";
		TB_Navigation_ThresholdDistanceDeg.AutoCompleteCustomSource = null;
		TB_Navigation_ThresholdDistanceDeg.AutoCompleteMode = (AutoCompleteMode)0;
		TB_Navigation_ThresholdDistanceDeg.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TB_Navigation_ThresholdDistanceDeg).BackColor = Color.Transparent;
		TB_Navigation_ThresholdDistanceDeg.Font = new Font("Segoe UI", 8f);
		((Control)TB_Navigation_ThresholdDistanceDeg).ForeColor = Color.FromArgb(189, 189, 189);
		TB_Navigation_ThresholdDistanceDeg.Image = null;
		TB_Navigation_ThresholdDistanceDeg.Lines = null;
		((Control)TB_Navigation_ThresholdDistanceDeg).Location = new Point(414, 164);
		TB_Navigation_ThresholdDistanceDeg.MaxLength = 32767;
		TB_Navigation_ThresholdDistanceDeg.Multiline = false;
		((Control)TB_Navigation_ThresholdDistanceDeg).Name = "TB_Navigation_ThresholdDistanceDeg";
		TB_Navigation_ThresholdDistanceDeg.ReadOnly = false;
		TB_Navigation_ThresholdDistanceDeg.ScrollBars = (ScrollBars)0;
		TB_Navigation_ThresholdDistanceDeg.SelectionStart = 0;
		((Control)TB_Navigation_ThresholdDistanceDeg).Size = new Size(30, 20);
		((Control)TB_Navigation_ThresholdDistanceDeg).TabIndex = 22;
		TB_Navigation_ThresholdDistanceDeg.TextAlign = (HorizontalAlignment)0;
		TB_Navigation_ThresholdDistanceDeg.UseSystemPasswordChar = false;
		TB_Navigation_ThresholdDistanceDeg.WatermarkText = "";
		TB_Navigation_ThresholdDistanceDeg.WordWrap = false;
		TB_Navigation_MaxDistanceNM.AutoCompleteCustomSource = null;
		TB_Navigation_MaxDistanceNM.AutoCompleteMode = (AutoCompleteMode)0;
		TB_Navigation_MaxDistanceNM.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TB_Navigation_MaxDistanceNM).BackColor = Color.Transparent;
		TB_Navigation_MaxDistanceNM.Font = new Font("Segoe UI", 8f);
		((Control)TB_Navigation_MaxDistanceNM).ForeColor = Color.FromArgb(189, 189, 189);
		TB_Navigation_MaxDistanceNM.Image = null;
		TB_Navigation_MaxDistanceNM.Lines = null;
		((Control)TB_Navigation_MaxDistanceNM).Location = new Point(239, 164);
		TB_Navigation_MaxDistanceNM.MaxLength = 32767;
		TB_Navigation_MaxDistanceNM.Multiline = false;
		((Control)TB_Navigation_MaxDistanceNM).Name = "TB_Navigation_MaxDistanceNM";
		TB_Navigation_MaxDistanceNM.ReadOnly = false;
		TB_Navigation_MaxDistanceNM.ScrollBars = (ScrollBars)0;
		TB_Navigation_MaxDistanceNM.SelectionStart = 0;
		((Control)TB_Navigation_MaxDistanceNM).Size = new Size(41, 20);
		((Control)TB_Navigation_MaxDistanceNM).TabIndex = 22;
		TB_Navigation_MaxDistanceNM.TextAlign = (HorizontalAlignment)0;
		TB_Navigation_MaxDistanceNM.UseSystemPasswordChar = false;
		TB_Navigation_MaxDistanceNM.WatermarkText = "";
		TB_Navigation_MaxDistanceNM.WordWrap = false;
		Label8.AutoSize = true;
		((Control)Label8).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label8).Location = new Point(281, 167);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(136, 13);
		((Control)Label8).TabIndex = 21;
		((Label)Label8).Text = "Threshold distance (deg):";
		Label7.AutoSize = true;
		((Control)Label7).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label7).Location = new Point(6, 165);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(231, 13);
		((Control)Label7).TabIndex = 20;
		((Label)Label7).Text = "Fine-grained navigation, max distance (nm):";
		((ButtonBase)CB_AllowPowerScemeSwitch).AutoSize = true;
		((Control)CB_AllowPowerScemeSwitch).Location = new Point(8, 96);
		((Control)CB_AllowPowerScemeSwitch).Name = "CB_AllowPowerScemeSwitch";
		((Control)CB_AllowPowerScemeSwitch).Size = new Size(295, 17);
		((Control)CB_AllowPowerScemeSwitch).TabIndex = 18;
		((ButtonBase)CB_AllowPowerScemeSwitch).Text = "Allow switching to High-Performance power scheme";
		((ButtonBase)CB_UnitStatusImage).AutoSize = true;
		((Control)CB_UnitStatusImage).Location = new Point(8, 74);
		((Control)CB_UnitStatusImage).Name = "CB_UnitStatusImage";
		((Control)CB_UnitStatusImage).Size = new Size(155, 17);
		((Control)CB_UnitStatusImage).TabIndex = 17;
		((ButtonBase)CB_UnitStatusImage).Text = "Display unit status image";
		((ButtonBase)Button_ResetWindowPlacement).BackColor = Color.Transparent;
		((Control)Button_ResetWindowPlacement).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button_ResetWindowPlacement).ForeColor = SystemColors.Control;
		((Control)Button_ResetWindowPlacement).Location = new Point(7, 427);
		((Control)Button_ResetWindowPlacement).Name = "Button_ResetWindowPlacement";
		((Control)Button_ResetWindowPlacement).Padding = new Padding(5);
		Button_ResetWindowPlacement.RoundRadius = 0;
		((Control)Button_ResetWindowPlacement).Size = new Size(202, 23);
		((Control)Button_ResetWindowPlacement).TabIndex = 11;
		Button_ResetWindowPlacement.Text = "Reset positions of secondary windows";
		((ButtonBase)CB_ZoomOnCursor).AutoSize = true;
		((Control)CB_ZoomOnCursor).Location = new Point(8, 52);
		((Control)CB_ZoomOnCursor).Name = "CB_ZoomOnCursor";
		((Control)CB_ZoomOnCursor).Size = new Size(174, 17);
		((Control)CB_ZoomOnCursor).TabIndex = 7;
		((ButtonBase)CB_ZoomOnCursor).Text = "Map zooms on mouse cursor";
		((ButtonBase)CB_MessageLogInWindow).AutoSize = true;
		((Control)CB_MessageLogInWindow).Location = new Point(8, 29);
		((Control)CB_MessageLogInWindow).Name = "CB_MessageLogInWindow";
		((Control)CB_MessageLogInWindow).Size = new Size(285, 17);
		((Control)CB_MessageLogInWindow).TabIndex = 4;
		((ButtonBase)CB_MessageLogInWindow).Text = "Message log in separate window [Ctrl + Shift + M]";
		((ButtonBase)CB_UseAutosave).AutoSize = true;
		((ButtonBase)CB_UseAutosave).BackColor = Color.FromArgb(39, 39, 39);
		((Control)CB_UseAutosave).Location = new Point(8, 7);
		((Control)CB_UseAutosave).Name = "CB_UseAutosave";
		((Control)CB_UseAutosave).Size = new Size(95, 17);
		((Control)CB_UseAutosave).TabIndex = 0;
		((ButtonBase)CB_UseAutosave).Text = "Use Autosave";
		TabPage4.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage4).Controls.Add((Control)(object)CB_OSMstyle);
		((Control)TabPage4).Controls.Add((Control)(object)DarkLabel13);
		((Control)TabPage4).Controls.Add((Control)(object)DarkGroupBox5);
		((Control)TabPage4).Controls.Add((Control)(object)DarkGroupBox4);
		((Control)TabPage4).Controls.Add((Control)(object)DarkGroupBox3);
		((Control)TabPage4).Controls.Add((Control)(object)CB_DrawOutlines);
		((Control)TabPage4).Controls.Add((Control)(object)CP_ShowAU_Behaviour_Bark);
		((Control)TabPage4).Controls.Add((Control)(object)DarkLabel7);
		((Control)TabPage4).Controls.Add((Control)(object)ChkASWNoise);
		((Control)TabPage4).Controls.Add((Control)(object)DarkGroupBox2);
		((Control)TabPage4).Controls.Add((Control)(object)CB_ColorDatablocks);
		((Control)TabPage4).Controls.Add((Control)(object)Button_SetPersonalMapProfile);
		((Control)TabPage4).Controls.Add((Control)(object)CB_UsePersonalMapProfile);
		((Control)TabPage4).Controls.Add((Control)(object)CP_ShowFlightPlans_Planned);
		((Control)TabPage4).Controls.Add((Control)(object)Label11);
		((Control)TabPage4).Controls.Add((Control)(object)CP_ShowFlightPlans_Airborne);
		((Control)TabPage4).Controls.Add((Control)(object)Label20);
		((Control)TabPage4).Controls.Add((Control)(object)CB_ShowDiagnostics);
		((Control)TabPage4).Controls.Add((Control)(object)CP_ShowPlottedPaths);
		((Control)TabPage4).Controls.Add((Control)(object)Label6);
		((Control)TabPage4).Controls.Add((Control)(object)CP_ShowGhostedGroupMembers);
		((Control)TabPage4).Controls.Add((Control)(object)Label5);
		((Control)TabPage4).Controls.Add((Control)(object)CB_MapSymbols);
		((Control)TabPage4).Controls.Add((Control)(object)Label4);
		((Control)TabPage4).Controls.Add((Control)(object)CB_MapCursorBox);
		((Control)TabPage4).Controls.Add((Control)(object)Label3);
		((Control)TabPage4).Controls.Add((Control)(object)CB_RefPointVisibility);
		((Control)TabPage4).Controls.Add((Control)(object)Label2);
		((Control)TabPage4).Controls.Add((Control)(object)CB_SonobuoyVisibility);
		((Control)TabPage4).Controls.Add((Control)(object)Label1);
		TabPage4.Location = new Point(4, 24);
		((Control)TabPage4).Name = "TabPage4";
		((Control)TabPage4).Padding = new Padding(3);
		((Control)TabPage4).Size = new Size(694, 641);
		TabPage4.TabIndex = 4;
		TabPage4.Text = "Map Display";
		((ComboBox)CB_OSMstyle).BackColor = Color.Transparent;
		((ComboBox)CB_OSMstyle).DrawMode = (DrawMode)1;
		((ComboBox)CB_OSMstyle).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_OSMstyle).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_OSMstyle).FormattingEnabled = true;
		((Control)CB_OSMstyle).Location = new Point(182, 11);
		((Control)CB_OSMstyle).Name = "CB_OSMstyle";
		((Control)CB_OSMstyle).Size = new Size(149, 21);
		((Control)CB_OSMstyle).TabIndex = 58;
		DarkLabel13.AutoSize = true;
		((Control)DarkLabel13).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel13).Location = new Point(7, 13);
		((Control)DarkLabel13).Name = "DarkLabel13";
		((Control)DarkLabel13).Size = new Size(88, 13);
		((Control)DarkLabel13).TabIndex = 57;
		((Label)DarkLabel13).Text = "OSM layer style:";
		((Control)DarkGroupBox4).Controls.Add((Control)(object)TableLayoutPanel1);
		((Control)DarkGroupBox4).Controls.Add((Control)(object)lbl_GU_Zoom);
		((Control)DarkGroupBox4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkGroupBox4).Location = new Point(348, 79);
		((Control)DarkGroupBox4).Name = "DarkGroupBox4";
		((Control)DarkGroupBox4).Size = new Size(334, 237);
		((Control)DarkGroupBox4).TabIndex = 56;
		((GroupBox)DarkGroupBox4).TabStop = false;
		TableLayoutPanel1.ColumnCount = 1;
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle((SizeType)2, 100f));
		TableLayoutPanel1.Controls.Add((Control)(object)TB_Flower_Zoom, 0, 6);
		TableLayoutPanel1.Controls.Add((Control)(object)DarkLabel10, 0, 5);
		TableLayoutPanel1.Controls.Add((Control)(object)TB_GrounUnit_Zoom, 0, 0);
		TableLayoutPanel1.Controls.Add((Control)(object)TB_Rectangle_Zoom, 0, 4);
		TableLayoutPanel1.Controls.Add((Control)(object)DarkLabel8, 0, 1);
		TableLayoutPanel1.Controls.Add((Control)(object)DarkLabel9, 0, 3);
		TableLayoutPanel1.Controls.Add((Control)(object)TB_Diamond_Zoom, 0, 2);
		((Control)TableLayoutPanel1).Dock = (DockStyle)5;
		((Control)TableLayoutPanel1).Location = new Point(3, 18);
		((Control)TableLayoutPanel1).Name = "TableLayoutPanel1";
		TableLayoutPanel1.RowCount = 7;
		TableLayoutPanel1.RowStyles.Add(new RowStyle((SizeType)1, 30f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle((SizeType)2, 33.33333f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle((SizeType)1, 30f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle((SizeType)2, 33.33333f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle((SizeType)1, 30f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle((SizeType)2, 33.33333f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle((SizeType)1, 30f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle((SizeType)1, 20f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle((SizeType)1, 20f));
		((Control)TableLayoutPanel1).Size = new Size(328, 216);
		((Control)TableLayoutPanel1).TabIndex = 50;
		TB_Flower_Zoom.AutoSize = false;
		((Control)TB_Flower_Zoom).Dock = (DockStyle)5;
		TB_Flower_Zoom.LargeChange = 20;
		((Control)TB_Flower_Zoom).Location = new Point(3, 189);
		TB_Flower_Zoom.Maximum = 100;
		TB_Flower_Zoom.Minimum = 10;
		((Control)TB_Flower_Zoom).Name = "TB_Flower_Zoom";
		((Control)TB_Flower_Zoom).Size = new Size(322, 24);
		TB_Flower_Zoom.SmallChange = 10;
		((Control)TB_Flower_Zoom).TabIndex = 48;
		TB_Flower_Zoom.TickFrequency = 10;
		TB_Flower_Zoom.Value = 20;
		DarkLabel10.AutoSize = true;
		((Control)DarkLabel10).Dock = (DockStyle)5;
		((Control)DarkLabel10).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel10).Location = new Point(3, 154);
		((Control)DarkLabel10).Name = "DarkLabel10";
		((Control)DarkLabel10).Size = new Size(322, 32);
		((Control)DarkLabel10).TabIndex = 49;
		((Label)DarkLabel10).Text = "Flower Shaped Icon Zoom";
		((Label)DarkLabel10).TextAlign = (ContentAlignment)256;
		TB_GrounUnit_Zoom.AutoSize = false;
		((Control)TB_GrounUnit_Zoom).Dock = (DockStyle)5;
		TB_GrounUnit_Zoom.LargeChange = 20;
		((Control)TB_GrounUnit_Zoom).Location = new Point(3, 3);
		TB_GrounUnit_Zoom.Maximum = 100;
		TB_GrounUnit_Zoom.Minimum = 10;
		((Control)TB_GrounUnit_Zoom).Name = "TB_GrounUnit_Zoom";
		((Control)TB_GrounUnit_Zoom).Size = new Size(322, 24);
		TB_GrounUnit_Zoom.SmallChange = 10;
		((Control)TB_GrounUnit_Zoom).TabIndex = 42;
		TB_GrounUnit_Zoom.TickFrequency = 10;
		TB_GrounUnit_Zoom.Value = 20;
		TB_Rectangle_Zoom.AutoSize = false;
		((Control)TB_Rectangle_Zoom).Dock = (DockStyle)5;
		TB_Rectangle_Zoom.LargeChange = 20;
		((Control)TB_Rectangle_Zoom).Location = new Point(3, 127);
		TB_Rectangle_Zoom.Maximum = 100;
		TB_Rectangle_Zoom.Minimum = 10;
		((Control)TB_Rectangle_Zoom).Name = "TB_Rectangle_Zoom";
		((Control)TB_Rectangle_Zoom).Size = new Size(322, 24);
		TB_Rectangle_Zoom.SmallChange = 10;
		((Control)TB_Rectangle_Zoom).TabIndex = 46;
		TB_Rectangle_Zoom.TickFrequency = 10;
		TB_Rectangle_Zoom.Value = 20;
		DarkLabel8.AutoSize = true;
		((Control)DarkLabel8).Dock = (DockStyle)5;
		((Control)DarkLabel8).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel8).Location = new Point(3, 30);
		((Control)DarkLabel8).Name = "DarkLabel8";
		((Control)DarkLabel8).Size = new Size(322, 32);
		((Control)DarkLabel8).TabIndex = 45;
		((Label)DarkLabel8).Text = "Diamond Shaped Icon Zoom";
		((Label)DarkLabel8).TextAlign = (ContentAlignment)256;
		DarkLabel9.AutoSize = true;
		((Control)DarkLabel9).Dock = (DockStyle)5;
		((Control)DarkLabel9).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel9).Location = new Point(3, 92);
		((Control)DarkLabel9).Name = "DarkLabel9";
		((Control)DarkLabel9).Size = new Size(322, 32);
		((Control)DarkLabel9).TabIndex = 47;
		((Label)DarkLabel9).Text = "Rectangle Shaped Icon Zoom";
		((Label)DarkLabel9).TextAlign = (ContentAlignment)256;
		TB_Diamond_Zoom.AutoSize = false;
		((Control)TB_Diamond_Zoom).Dock = (DockStyle)5;
		TB_Diamond_Zoom.LargeChange = 20;
		((Control)TB_Diamond_Zoom).Location = new Point(3, 65);
		TB_Diamond_Zoom.Maximum = 100;
		TB_Diamond_Zoom.Minimum = 10;
		((Control)TB_Diamond_Zoom).Name = "TB_Diamond_Zoom";
		((Control)TB_Diamond_Zoom).Size = new Size(322, 24);
		TB_Diamond_Zoom.SmallChange = 10;
		((Control)TB_Diamond_Zoom).TabIndex = 44;
		TB_Diamond_Zoom.TickFrequency = 10;
		TB_Diamond_Zoom.Value = 20;
		lbl_GU_Zoom.AutoSize = true;
		((Control)lbl_GU_Zoom).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)lbl_GU_Zoom).Location = new Point(5, 1);
		((Control)lbl_GU_Zoom).Name = "lbl_GU_Zoom";
		((Control)lbl_GU_Zoom).Size = new Size(104, 13);
		((Control)lbl_GU_Zoom).TabIndex = 43;
		((Label)lbl_GU_Zoom).Text = "Ground Unit Zoom";
		((Control)DarkGroupBox3).Controls.Add((Control)(object)AltitudeAndTerrainOptionsPanel);
		((Control)DarkGroupBox3).Controls.Add((Control)(object)CB_DrawUnitsAtTrueAltitude);
		((Control)DarkGroupBox3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkGroupBox3).Location = new Point(10, 364);
		((Control)DarkGroupBox3).Name = "DarkGroupBox3";
		((Control)DarkGroupBox3).Size = new Size(677, 132);
		((Control)DarkGroupBox3).TabIndex = 55;
		((GroupBox)DarkGroupBox3).TabStop = false;
		((Control)AltitudeAndTerrainOptionsPanel).Controls.Add((Control)(object)TerrainDeformationGroupBox);
		((Control)AltitudeAndTerrainOptionsPanel).Controls.Add((Control)(object)AdditionalAltitudeOptionsPanel);
		((Control)AltitudeAndTerrainOptionsPanel).Dock = (DockStyle)5;
		((Control)AltitudeAndTerrainOptionsPanel).Location = new Point(3, 18);
		((Control)AltitudeAndTerrainOptionsPanel).Margin = new Padding(0);
		((Control)AltitudeAndTerrainOptionsPanel).Name = "AltitudeAndTerrainOptionsPanel";
		((Control)AltitudeAndTerrainOptionsPanel).Size = new Size(671, 111);
		((Control)AltitudeAndTerrainOptionsPanel).TabIndex = 54;
		((Control)TerrainDeformationGroupBox).Controls.Add((Control)(object)CB_Show3DTerrain);
		((Control)TerrainDeformationGroupBox).Controls.Add((Control)(object)TerrainRenderingOptionsPanel);
		((Control)TerrainDeformationGroupBox).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)TerrainDeformationGroupBox).Location = new Point(4, 2);
		((Control)TerrainDeformationGroupBox).Name = "TerrainDeformationGroupBox";
		((Control)TerrainDeformationGroupBox).Size = new Size(324, 104);
		((Control)TerrainDeformationGroupBox).TabIndex = 53;
		((GroupBox)TerrainDeformationGroupBox).TabStop = false;
		((ButtonBase)CB_Show3DTerrain).AutoSize = true;
		((CheckBox)CB_Show3DTerrain).Checked = true;
		((CheckBox)CB_Show3DTerrain).CheckState = (CheckState)1;
		((Control)CB_Show3DTerrain).Location = new Point(10, 0);
		((Control)CB_Show3DTerrain).Margin = new Padding(3, 0, 3, 3);
		((Control)CB_Show3DTerrain).Name = "CB_Show3DTerrain";
		((Control)CB_Show3DTerrain).Size = new Size(131, 17);
		((Control)CB_Show3DTerrain).TabIndex = 53;
		((ButtonBase)CB_Show3DTerrain).Text = "3D Terrain rendering";
		((Control)TerrainRenderingOptionsPanel).Controls.Add((Control)(object)verticalScalingTextBox);
		((Control)TerrainRenderingOptionsPanel).Controls.Add((Control)(object)VerticalScalingMultiplierTrackBar);
		((Control)TerrainRenderingOptionsPanel).Controls.Add((Control)(object)DarkTextBox1);
		((Control)TerrainRenderingOptionsPanel).Controls.Add((Control)(object)DarkTextBox2);
		((Control)TerrainRenderingOptionsPanel).Dock = (DockStyle)5;
		((Control)TerrainRenderingOptionsPanel).Location = new Point(3, 18);
		((Control)TerrainRenderingOptionsPanel).Name = "TerrainRenderingOptionsPanel";
		((Control)TerrainRenderingOptionsPanel).Size = new Size(318, 83);
		((Control)TerrainRenderingOptionsPanel).TabIndex = 53;
		((TextBoxBase)verticalScalingTextBox).BackColor = Color.FromArgb(60, 63, 65);
		((TextBoxBase)verticalScalingTextBox).BorderStyle = (BorderStyle)0;
		((TextBoxBase)verticalScalingTextBox).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)verticalScalingTextBox).Location = new Point(5, 3);
		((Control)verticalScalingTextBox).Margin = new Padding(5, 3, 0, 0);
		((Control)verticalScalingTextBox).Name = "verticalScalingTextBox";
		verticalScalingTextBox.PlaceholderText = "";
		((TextBoxBase)verticalScalingTextBox).ReadOnly = true;
		((Control)verticalScalingTextBox).Size = new Size(100, 15);
		((Control)verticalScalingTextBox).TabIndex = 57;
		((TextBox)verticalScalingTextBox).Text = "Vertical scaling: x1";
		VerticalScalingMultiplierTrackBar.AutoSize = false;
		((Control)VerticalScalingMultiplierTrackBar).Location = new Point(3, 18);
		((Control)VerticalScalingMultiplierTrackBar).Margin = new Padding(3, 0, 3, 3);
		VerticalScalingMultiplierTrackBar.Maximum = 25;
		VerticalScalingMultiplierTrackBar.Minimum = 1;
		((Control)VerticalScalingMultiplierTrackBar).Name = "VerticalScalingMultiplierTrackBar";
		((Control)VerticalScalingMultiplierTrackBar).Size = new Size(315, 24);
		((Control)VerticalScalingMultiplierTrackBar).TabIndex = 52;
		VerticalScalingMultiplierTrackBar.TickFrequency = 0;
		VerticalScalingMultiplierTrackBar.Value = 10;
		((TextBoxBase)DarkTextBox1).BackColor = Color.FromArgb(60, 63, 65);
		((TextBoxBase)DarkTextBox1).BorderStyle = (BorderStyle)0;
		((TextBoxBase)DarkTextBox1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkTextBox1).Location = new Point(5, 45);
		((Control)DarkTextBox1).Margin = new Padding(5, 0, 0, 0);
		((Control)DarkTextBox1).Name = "DarkTextBox1";
		DarkTextBox1.PlaceholderText = "";
		((TextBoxBase)DarkTextBox1).ReadOnly = true;
		((Control)DarkTextBox1).Size = new Size(306, 15);
		((Control)DarkTextBox1).TabIndex = 58;
		((TextBox)DarkTextBox1).Text = "Vertical scaling will also apply to rendered units";
		((TextBoxBase)DarkTextBox2).BackColor = Color.FromArgb(60, 63, 65);
		((TextBoxBase)DarkTextBox2).BorderStyle = (BorderStyle)0;
		((TextBoxBase)DarkTextBox2).ForeColor = Color.FromArgb(120, 120, 120);
		((Control)DarkTextBox2).Location = new Point(5, 60);
		((Control)DarkTextBox2).Margin = new Padding(5, 0, 0, 0);
		((Control)DarkTextBox2).Name = "DarkTextBox2";
		DarkTextBox2.PlaceholderText = "";
		((TextBoxBase)DarkTextBox2).ReadOnly = true;
		((Control)DarkTextBox2).Size = new Size(303, 15);
		((Control)DarkTextBox2).TabIndex = 59;
		((TextBox)DarkTextBox2).Text = "please allow a few seconds for world mesh to update";
		((Control)AdditionalAltitudeOptionsPanel).Controls.Add((Control)(object)CB_TrueAltitudeRenderForceSubsurfaceUnitsAtSurface);
		((Control)AdditionalAltitudeOptionsPanel).Controls.Add((Control)(object)CB_TrueAltitudeRenderForceGroundUnitsAtSurface);
		((Control)AdditionalAltitudeOptionsPanel).Controls.Add((Control)(object)CB_TrueAltitudeRenderFromGroundInsteadOfSurface);
		((Control)AdditionalAltitudeOptionsPanel).Controls.Add((Control)(object)FlowLayoutPanel1);
		((Control)AdditionalAltitudeOptionsPanel).Location = new Point(331, 7);
		((Control)AdditionalAltitudeOptionsPanel).Name = "AdditionalAltitudeOptionsPanel";
		((Control)AdditionalAltitudeOptionsPanel).Size = new Size(333, 99);
		((Control)AdditionalAltitudeOptionsPanel).TabIndex = 52;
		((ButtonBase)CB_TrueAltitudeRenderForceSubsurfaceUnitsAtSurface).AutoSize = true;
		((Control)CB_TrueAltitudeRenderForceSubsurfaceUnitsAtSurface).Location = new Point(3, 0);
		((Control)CB_TrueAltitudeRenderForceSubsurfaceUnitsAtSurface).Margin = new Padding(3, 0, 3, 3);
		((Control)CB_TrueAltitudeRenderForceSubsurfaceUnitsAtSurface).Name = "CB_TrueAltitudeRenderForceSubsurfaceUnitsAtSurface";
		((Control)CB_TrueAltitudeRenderForceSubsurfaceUnitsAtSurface).Size = new Size(196, 17);
		((Control)CB_TrueAltitudeRenderForceSubsurfaceUnitsAtSurface).TabIndex = 54;
		((ButtonBase)CB_TrueAltitudeRenderForceSubsurfaceUnitsAtSurface).Text = "Show subsurface units at surface";
		((ButtonBase)CB_TrueAltitudeRenderForceGroundUnitsAtSurface).AutoSize = true;
		((Control)CB_TrueAltitudeRenderForceGroundUnitsAtSurface).Location = new Point(3, 20);
		((Control)CB_TrueAltitudeRenderForceGroundUnitsAtSurface).Margin = new Padding(3, 0, 3, 3);
		((Control)CB_TrueAltitudeRenderForceGroundUnitsAtSurface).Name = "CB_TrueAltitudeRenderForceGroundUnitsAtSurface";
		((Control)CB_TrueAltitudeRenderForceGroundUnitsAtSurface).Size = new Size(179, 17);
		((Control)CB_TrueAltitudeRenderForceGroundUnitsAtSurface).TabIndex = 53;
		((ButtonBase)CB_TrueAltitudeRenderForceGroundUnitsAtSurface).Text = "Show ground units at surface";
		((ButtonBase)CB_TrueAltitudeRenderFromGroundInsteadOfSurface).AutoSize = true;
		((Control)CB_TrueAltitudeRenderFromGroundInsteadOfSurface).Location = new Point(3, 40);
		((Control)CB_TrueAltitudeRenderFromGroundInsteadOfSurface).Margin = new Padding(3, 0, 3, 3);
		((Control)CB_TrueAltitudeRenderFromGroundInsteadOfSurface).Name = "CB_TrueAltitudeRenderFromGroundInsteadOfSurface";
		((Control)CB_TrueAltitudeRenderFromGroundInsteadOfSurface).Size = new Size(316, 17);
		((Control)CB_TrueAltitudeRenderFromGroundInsteadOfSurface).TabIndex = 52;
		((ButtonBase)CB_TrueAltitudeRenderFromGroundInsteadOfSurface).Text = "Use ground (terrain) instead of surface (sea) as reference";
		((Control)FlowLayoutPanel1).Location = new Point(3, 63);
		((Control)FlowLayoutPanel1).Name = "FlowLayoutPanel1";
		((Control)FlowLayoutPanel1).Size = new Size(200, 100);
		((Control)FlowLayoutPanel1).TabIndex = 55;
		((ButtonBase)CB_DrawUnitsAtTrueAltitude).AutoSize = true;
		((Control)CB_DrawUnitsAtTrueAltitude).Location = new Point(9, 0);
		((Control)CB_DrawUnitsAtTrueAltitude).Name = "CB_DrawUnitsAtTrueAltitude";
		((Control)CB_DrawUnitsAtTrueAltitude).Size = new Size(138, 17);
		((Control)CB_DrawUnitsAtTrueAltitude).TabIndex = 1;
		((ButtonBase)CB_DrawUnitsAtTrueAltitude).Text = "Draw units at altitude";
		((ButtonBase)CB_DrawOutlines).AutoSize = true;
		((Control)CB_DrawOutlines).Location = new Point(10, 280);
		((Control)CB_DrawOutlines).Name = "CB_DrawOutlines";
		((Control)CB_DrawOutlines).Size = new Size(193, 17);
		((Control)CB_DrawOutlines).TabIndex = 50;
		((ButtonBase)CB_DrawOutlines).Text = "Draw text+icon outlines (slower)";
		((ComboBox)CP_ShowAU_Behaviour_Bark).BackColor = Color.Transparent;
		((ComboBox)CP_ShowAU_Behaviour_Bark).DrawMode = (DrawMode)1;
		((ComboBox)CP_ShowAU_Behaviour_Bark).DropDownStyle = (ComboBoxStyle)2;
		((Control)CP_ShowAU_Behaviour_Bark).Font = new Font("Segoe UI", 7f);
		((ListControl)CP_ShowAU_Behaviour_Bark).FormattingEnabled = true;
		((ComboBox)CP_ShowAU_Behaviour_Bark).Items.AddRange(new object[3] { "All", "Selected Unit", "Do not Show" });
		((Control)CP_ShowAU_Behaviour_Bark).Location = new Point(182, 253);
		((Control)CP_ShowAU_Behaviour_Bark).Name = "CP_ShowAU_Behaviour_Bark";
		((Control)CP_ShowAU_Behaviour_Bark).Size = new Size(150, 21);
		((Control)CP_ShowAU_Behaviour_Bark).TabIndex = 41;
		DarkLabel7.AutoSize = true;
		((Control)DarkLabel7).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel7).Location = new Point(7, 256);
		((Control)DarkLabel7).Name = "DarkLabel7";
		((Control)DarkLabel7).Size = new Size(146, 13);
		((Control)DarkLabel7).TabIndex = 40;
		((Label)DarkLabel7).Text = "Show units behaviour bark";
		((ButtonBase)ChkASWNoise).AutoSize = true;
		((Control)ChkASWNoise).Location = new Point(10, 326);
		((Control)ChkASWNoise).Name = "ChkASWNoise";
		((Control)ChkASWNoise).Size = new Size(332, 17);
		((Control)ChkASWNoise).TabIndex = 39;
		((ButtonBase)ChkASWNoise).Text = "Show dynamic noise values when ASW range rings enabled";
		((Control)DarkGroupBox2).Controls.Add((Control)(object)ClearSlugTrail);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)CB_SlugTrail_Unknown);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)Num_SlugTrailLifetime);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)DarkLabel6);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)CB_SlugTrail_Unfriendly);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)DarkRichTextBox1);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)DarkLabel5);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)CB_SlugTrail_Hostile);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)CB_SlugTrail_Neutral);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)CB_SlugTrail_Friendly);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)CB_SlugTrail_Own);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)CB_SlugTrail_UseSlugTrail);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)Combo_SlugTrailFreq);
		((Control)DarkGroupBox2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkGroupBox2).Location = new Point(10, 503);
		((Control)DarkGroupBox2).Name = "DarkGroupBox2";
		((Control)DarkGroupBox2).Size = new Size(677, 100);
		((Control)DarkGroupBox2).TabIndex = 38;
		((GroupBox)DarkGroupBox2).TabStop = false;
		((ButtonBase)ClearSlugTrail).BackColor = Color.Transparent;
		((Control)ClearSlugTrail).ForeColor = SystemColors.Control;
		((Control)ClearSlugTrail).Location = new Point(172, -1);
		((Control)ClearSlugTrail).Name = "ClearSlugTrail";
		((Control)ClearSlugTrail).Padding = new Padding(5);
		ClearSlugTrail.RoundRadius = 0;
		((Control)ClearSlugTrail).Size = new Size(130, 19);
		((Control)ClearSlugTrail).TabIndex = 42;
		ClearSlugTrail.Text = "Clear all existing trails";
		((ButtonBase)CB_SlugTrail_Unknown).AutoSize = true;
		((Control)CB_SlugTrail_Unknown).Location = new Point(325, 67);
		((Control)CB_SlugTrail_Unknown).Name = "CB_SlugTrail_Unknown";
		((Control)CB_SlugTrail_Unknown).Size = new Size(77, 17);
		((Control)CB_SlugTrail_Unknown).TabIndex = 44;
		((ButtonBase)CB_SlugTrail_Unknown).Text = "Unknown";
		((UpDownBase)Num_SlugTrailLifetime).BackColor = Color.FromArgb(34, 34, 34);
		((UpDownBase)Num_SlugTrailLifetime).ForeColor = SystemColors.Info;
		((Control)Num_SlugTrailLifetime).Location = new Point(87, 63);
		Num_SlugTrailLifetime.Maximum = new decimal(new int[4] { 1000000, 0, 0, 0 });
		Num_SlugTrailLifetime.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		((Control)Num_SlugTrailLifetime).Name = "Num_SlugTrailLifetime";
		((Control)Num_SlugTrailLifetime).Size = new Size(132, 22);
		((Control)Num_SlugTrailLifetime).TabIndex = 43;
		Num_SlugTrailLifetime.ThousandsSeparator = true;
		Num_SlugTrailLifetime.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		DarkLabel6.AutoSize = true;
		((Control)DarkLabel6).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel6).Location = new Point(9, 65);
		((Control)DarkLabel6).Name = "DarkLabel6";
		((Control)DarkLabel6).Size = new Size(72, 13);
		((Control)DarkLabel6).TabIndex = 42;
		((Label)DarkLabel6).Text = "Lifetime (sec)";
		((ButtonBase)CB_SlugTrail_Unfriendly).AutoSize = true;
		((Control)CB_SlugTrail_Unfriendly).Location = new Point(325, 21);
		((Control)CB_SlugTrail_Unfriendly).Name = "CB_SlugTrail_Unfriendly";
		((Control)CB_SlugTrail_Unfriendly).Size = new Size(80, 17);
		((Control)CB_SlugTrail_Unfriendly).TabIndex = 40;
		((ButtonBase)CB_SlugTrail_Unfriendly).Text = "Unfriendly";
		((TextBoxBase)DarkRichTextBox1).BackColor = Color.FromArgb(60, 63, 65);
		((RichTextBox)DarkRichTextBox1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkRichTextBox1).Location = new Point(411, 13);
		((Control)DarkRichTextBox1).Name = "DarkRichTextBox1";
		((TextBoxBase)DarkRichTextBox1).ReadOnly = true;
		((Control)DarkRichTextBox1).Size = new Size(260, 81);
		((Control)DarkRichTextBox1).TabIndex = 39;
		((RichTextBox)DarkRichTextBox1).Text = "Creates a trail of reference points on detected units to provide a visual history on their trajectories and last know positions.";
		DarkLabel5.AutoSize = true;
		((Control)DarkLabel5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel5).Location = new Point(9, 29);
		((Control)DarkLabel5).Name = "DarkLabel5";
		((Control)DarkLabel5).Size = new Size(60, 13);
		((Control)DarkLabel5).TabIndex = 8;
		((Label)DarkLabel5).Text = "Frequency";
		((ButtonBase)CB_SlugTrail_Hostile).AutoSize = true;
		((Control)CB_SlugTrail_Hostile).Location = new Point(325, 44);
		((Control)CB_SlugTrail_Hostile).Name = "CB_SlugTrail_Hostile";
		((Control)CB_SlugTrail_Hostile).Size = new Size(62, 17);
		((Control)CB_SlugTrail_Hostile).TabIndex = 6;
		((ButtonBase)CB_SlugTrail_Hostile).Text = "Hostile";
		((ButtonBase)CB_SlugTrail_Neutral).AutoSize = true;
		((Control)CB_SlugTrail_Neutral).Location = new Point(229, 67);
		((Control)CB_SlugTrail_Neutral).Name = "CB_SlugTrail_Neutral";
		((Control)CB_SlugTrail_Neutral).Size = new Size(64, 17);
		((Control)CB_SlugTrail_Neutral).TabIndex = 5;
		((ButtonBase)CB_SlugTrail_Neutral).Text = "Neutral";
		((ButtonBase)CB_SlugTrail_Friendly).AutoSize = true;
		((Control)CB_SlugTrail_Friendly).Location = new Point(229, 44);
		((Control)CB_SlugTrail_Friendly).Name = "CB_SlugTrail_Friendly";
		((Control)CB_SlugTrail_Friendly).Size = new Size(67, 17);
		((Control)CB_SlugTrail_Friendly).TabIndex = 4;
		((ButtonBase)CB_SlugTrail_Friendly).Text = "Friendly";
		((ButtonBase)CB_SlugTrail_Own).AutoSize = true;
		((Control)CB_SlugTrail_Own).Location = new Point(229, 21);
		((Control)CB_SlugTrail_Own).Name = "CB_SlugTrail_Own";
		((Control)CB_SlugTrail_Own).Size = new Size(90, 17);
		((Control)CB_SlugTrail_Own).TabIndex = 2;
		((ButtonBase)CB_SlugTrail_Own).Text = "Own / Allied";
		((ButtonBase)CB_SlugTrail_UseSlugTrail).AutoSize = true;
		((Control)CB_SlugTrail_UseSlugTrail).Location = new Point(9, -1);
		((Control)CB_SlugTrail_UseSlugTrail).Name = "CB_SlugTrail_UseSlugTrail";
		((Control)CB_SlugTrail_UseSlugTrail).Size = new Size(151, 17);
		((Control)CB_SlugTrail_UseSlugTrail).TabIndex = 1;
		((ButtonBase)CB_SlugTrail_UseSlugTrail).Text = "Contacts and units trails";
		((ComboBox)Combo_SlugTrailFreq).BackColor = Color.Transparent;
		((ComboBox)Combo_SlugTrailFreq).DrawMode = (DrawMode)1;
		((ComboBox)Combo_SlugTrailFreq).DropDownStyle = (ComboBoxStyle)2;
		((Control)Combo_SlugTrailFreq).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)Combo_SlugTrailFreq).FormattingEnabled = true;
		((ComboBox)Combo_SlugTrailFreq).Items.AddRange(new object[3] { "Every 5 seconds", "Every 15 seconds", "Every 60 seconds" });
		((Control)Combo_SlugTrailFreq).Location = new Point(87, 27);
		((Control)Combo_SlugTrailFreq).Name = "Combo_SlugTrailFreq";
		((Control)Combo_SlugTrailFreq).Size = new Size(132, 21);
		((Control)Combo_SlugTrailFreq).TabIndex = 0;
		((ButtonBase)CB_ColorDatablocks).AutoSize = true;
		((Control)CB_ColorDatablocks).Location = new Point(10, 303);
		((Control)CB_ColorDatablocks).Name = "CB_ColorDatablocks";
		((Control)CB_ColorDatablocks).Size = new Size(146, 17);
		((Control)CB_ColorDatablocks).TabIndex = 37;
		((ButtonBase)CB_ColorDatablocks).Text = "Use colored datablocks";
		((ButtonBase)Button_SetPersonalMapProfile).BackColor = Color.Transparent;
		((Control)Button_SetPersonalMapProfile).ForeColor = SystemColors.Control;
		((Control)Button_SetPersonalMapProfile).Location = new Point(492, 610);
		((Control)Button_SetPersonalMapProfile).Name = "Button_SetPersonalMapProfile";
		((Control)Button_SetPersonalMapProfile).Padding = new Padding(5);
		Button_SetPersonalMapProfile.RoundRadius = 0;
		((Control)Button_SetPersonalMapProfile).Size = new Size(195, 23);
		((Control)Button_SetPersonalMapProfile).TabIndex = 36;
		Button_SetPersonalMapProfile.Text = "Save current map profile as \"personal\"";
		((ButtonBase)CB_UsePersonalMapProfile).AutoSize = true;
		((Control)CB_UsePersonalMapProfile).Location = new Point(331, 613);
		((Control)CB_UsePersonalMapProfile).Name = "CB_UsePersonalMapProfile";
		((Control)CB_UsePersonalMapProfile).Size = new Size(155, 17);
		((Control)CB_UsePersonalMapProfile).TabIndex = 35;
		((ButtonBase)CB_UsePersonalMapProfile).Text = "Use personal map profile";
		((ComboBox)CP_ShowFlightPlans_Planned).BackColor = Color.Transparent;
		((ComboBox)CP_ShowFlightPlans_Planned).DrawMode = (DrawMode)1;
		((ComboBox)CP_ShowFlightPlans_Planned).DropDownStyle = (ComboBoxStyle)2;
		((Control)CP_ShowFlightPlans_Planned).Font = new Font("Segoe UI", 7f);
		((ListControl)CP_ShowFlightPlans_Planned).FormattingEnabled = true;
		((ComboBox)CP_ShowFlightPlans_Planned).Items.AddRange(new object[5] { "All", "Selected Task Pool ", "Selected Package", "Selected Flight", "Do not Show" });
		((Control)CP_ShowFlightPlans_Planned).Location = new Point(182, 226);
		((Control)CP_ShowFlightPlans_Planned).Name = "CP_ShowFlightPlans_Planned";
		((Control)CP_ShowFlightPlans_Planned).Size = new Size(150, 21);
		((Control)CP_ShowFlightPlans_Planned).TabIndex = 34;
		Label11.AutoSize = true;
		((Control)Label11).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label11).Location = new Point(7, 229);
		((Control)Label11).Name = "Label11";
		((Control)Label11).Size = new Size(150, 13);
		((Control)Label11).TabIndex = 33;
		((Label)Label11).Text = "Show flightplans (planned):";
		((ComboBox)CP_ShowFlightPlans_Airborne).BackColor = Color.Transparent;
		((ComboBox)CP_ShowFlightPlans_Airborne).DrawMode = (DrawMode)1;
		((ComboBox)CP_ShowFlightPlans_Airborne).DropDownStyle = (ComboBoxStyle)2;
		((Control)CP_ShowFlightPlans_Airborne).Font = new Font("Segoe UI", 7f);
		((ListControl)CP_ShowFlightPlans_Airborne).FormattingEnabled = true;
		((ComboBox)CP_ShowFlightPlans_Airborne).Items.AddRange(new object[3] { "All", "Selected Unit", "Do not Show" });
		((Control)CP_ShowFlightPlans_Airborne).Location = new Point(182, 199);
		((Control)CP_ShowFlightPlans_Airborne).Name = "CP_ShowFlightPlans_Airborne";
		((Control)CP_ShowFlightPlans_Airborne).Size = new Size(150, 21);
		((Control)CP_ShowFlightPlans_Airborne).TabIndex = 32;
		Label20.AutoSize = true;
		((Control)Label20).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label20).Location = new Point(7, 202);
		((Control)Label20).Name = "Label20";
		((Control)Label20).Size = new Size(169, 13);
		((Control)Label20).TabIndex = 31;
		((Label)Label20).Text = "Show flightplans (airborne a/c):";
		((ButtonBase)CB_ShowDiagnostics).AutoSize = true;
		((Control)CB_ShowDiagnostics).Location = new Point(10, 613);
		((Control)CB_ShowDiagnostics).Name = "CB_ShowDiagnostics";
		((Control)CB_ShowDiagnostics).Size = new Size(118, 17);
		((Control)CB_ShowDiagnostics).TabIndex = 29;
		((ButtonBase)CB_ShowDiagnostics).Text = "Show Diagnostics";
		((ComboBox)CP_ShowPlottedPaths).BackColor = Color.Transparent;
		((ComboBox)CP_ShowPlottedPaths).DrawMode = (DrawMode)1;
		((ComboBox)CP_ShowPlottedPaths).DropDownStyle = (ComboBoxStyle)2;
		((Control)CP_ShowPlottedPaths).Font = new Font("Segoe UI", 7f);
		((ListControl)CP_ShowPlottedPaths).FormattingEnabled = true;
		((ComboBox)CP_ShowPlottedPaths).Items.AddRange(new object[3] { "All", "Selected Unit", "Do not Show" });
		((Control)CP_ShowPlottedPaths).Location = new Point(182, 172);
		((Control)CP_ShowPlottedPaths).Name = "CP_ShowPlottedPaths";
		((Control)CP_ShowPlottedPaths).Size = new Size(150, 21);
		((Control)CP_ShowPlottedPaths).TabIndex = 26;
		Label6.AutoSize = true;
		((Control)Label6).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label6).Location = new Point(7, 175);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(112, 13);
		((Control)Label6).TabIndex = 25;
		((Label)Label6).Text = "Show plotted paths:";
		((ComboBox)CP_ShowGhostedGroupMembers).BackColor = Color.Transparent;
		((ComboBox)CP_ShowGhostedGroupMembers).DrawMode = (DrawMode)1;
		((ComboBox)CP_ShowGhostedGroupMembers).DropDownStyle = (ComboBoxStyle)2;
		((Control)CP_ShowGhostedGroupMembers).Font = new Font("Segoe UI", 7f);
		((ListControl)CP_ShowGhostedGroupMembers).FormattingEnabled = true;
		((ComboBox)CP_ShowGhostedGroupMembers).Items.AddRange(new object[3] { "All Groups", "Selected Groups", "Do not Show" });
		((Control)CP_ShowGhostedGroupMembers).Location = new Point(182, 145);
		((Control)CP_ShowGhostedGroupMembers).Name = "CP_ShowGhostedGroupMembers";
		((Control)CP_ShowGhostedGroupMembers).Size = new Size(150, 21);
		((Control)CP_ShowGhostedGroupMembers).TabIndex = 27;
		Label5.AutoSize = true;
		((Control)Label5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label5).Location = new Point(7, 148);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(169, 13);
		((Control)Label5).TabIndex = 24;
		((Label)Label5).Text = "Show ghosted group members:";
		((ComboBox)CB_MapSymbols).BackColor = Color.Transparent;
		((ComboBox)CB_MapSymbols).DrawMode = (DrawMode)1;
		((ComboBox)CB_MapSymbols).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_MapSymbols).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_MapSymbols).FormattingEnabled = true;
		((ComboBox)CB_MapSymbols).Items.AddRange(new object[4] { "NTDS + APP-6", "Stylized", "Directional Stylized", "Full APP-6" });
		((Control)CB_MapSymbols).Location = new Point(182, 118);
		((Control)CB_MapSymbols).Name = "CB_MapSymbols";
		((Control)CB_MapSymbols).Size = new Size(150, 21);
		((Control)CB_MapSymbols).TabIndex = 23;
		Label4.AutoSize = true;
		((Control)Label4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label4).Location = new Point(7, 121);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(78, 13);
		((Control)Label4).TabIndex = 22;
		((Label)Label4).Text = "Map Symbols:";
		((ComboBox)CB_MapCursorBox).BackColor = Color.Transparent;
		((ComboBox)CB_MapCursorBox).DrawMode = (DrawMode)1;
		((ComboBox)CB_MapCursorBox).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_MapCursorBox).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_MapCursorBox).FormattingEnabled = true;
		((ComboBox)CB_MapCursorBox).Items.AddRange(new object[3] { "Show on cursor", "Show on bottom", "Do not show" });
		((Control)CB_MapCursorBox).Location = new Point(182, 91);
		((Control)CB_MapCursorBox).Name = "CB_MapCursorBox";
		((Control)CB_MapCursorBox).Size = new Size(150, 21);
		((Control)CB_MapCursorBox).TabIndex = 21;
		Label3.AutoSize = true;
		((Control)Label3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label3).Location = new Point(7, 94);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(162, 13);
		((Control)Label3).TabIndex = 20;
		((Label)Label3).Text = "Map Cursor Databox Visibility:";
		((ComboBox)CB_RefPointVisibility).BackColor = Color.Transparent;
		((ComboBox)CB_RefPointVisibility).DrawMode = (DrawMode)1;
		((ComboBox)CB_RefPointVisibility).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_RefPointVisibility).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_RefPointVisibility).FormattingEnabled = true;
		((ComboBox)CB_RefPointVisibility).Items.AddRange(new object[3] { "Normal", "Small", "Do not show" });
		((Control)CB_RefPointVisibility).Location = new Point(182, 64);
		((Control)CB_RefPointVisibility).Name = "CB_RefPointVisibility";
		((Control)CB_RefPointVisibility).Size = new Size(150, 21);
		((Control)CB_RefPointVisibility).TabIndex = 19;
		Label2.AutoSize = true;
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(7, 67);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(137, 13);
		((Control)Label2).TabIndex = 18;
		((Label)Label2).Text = "Reference Point Visibility:";
		((ComboBox)CB_SonobuoyVisibility).BackColor = Color.Transparent;
		((ComboBox)CB_SonobuoyVisibility).DrawMode = (DrawMode)1;
		((ComboBox)CB_SonobuoyVisibility).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_SonobuoyVisibility).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_SonobuoyVisibility).FormattingEnabled = true;
		((ComboBox)CB_SonobuoyVisibility).Items.AddRange(new object[3] { "Normal", "Ghosted", "Do not show" });
		((Control)CB_SonobuoyVisibility).Location = new Point(182, 37);
		((Control)CB_SonobuoyVisibility).Name = "CB_SonobuoyVisibility";
		((Control)CB_SonobuoyVisibility).Size = new Size(150, 21);
		((Control)CB_SonobuoyVisibility).TabIndex = 17;
		Label1.AutoSize = true;
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(7, 40);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(109, 13);
		((Control)Label1).TabIndex = 16;
		((Label)Label1).Text = "Sonobuoy Visibility:";
		TabPage2.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage2).Controls.Add((Control)(object)DataGridView1);
		TabPage2.Location = new Point(4, 24);
		((Control)TabPage2).Name = "TabPage2";
		((Control)TabPage2).Padding = new Padding(3);
		((Control)TabPage2).Size = new Size(694, 641);
		TabPage2.TabIndex = 2;
		TabPage2.Text = "Message Log";
		((DataGridView)DataGridView1).AllowUserToAddRows = false;
		((DataGridView)DataGridView1).AllowUserToDeleteRows = false;
		((DataGridView)DataGridView1).AllowUserToOrderColumns = true;
		((DataGridView)DataGridView1).AllowUserToResizeColumns = false;
		((DataGridView)DataGridView1).AllowUserToResizeRows = false;
		((DataGridView)DataGridView1).BackgroundColor = Color.FromArgb(60, 63, 65);
		((DataGridView)DataGridView1).BorderStyle = (BorderStyle)0;
		((DataGridView)DataGridView1).CellBorderStyle = (DataGridViewCellBorderStyle)8;
		((DataGridView)DataGridView1).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val.Alignment = (DataGridViewContentAlignment)16;
		val.BackColor = Color.FromArgb(66, 77, 95);
		val.Font = new Font("Segoe UI", 8f);
		val.ForeColor = Color.LightGray;
		val.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DataGridView1).ColumnHeadersDefaultCellStyle = val;
		((DataGridView)DataGridView1).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		((DataGridView)DataGridView1).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[6]
		{
			(DataGridViewColumn)MessageType_Hidden,
			(DataGridViewColumn)MessageType,
			(DataGridViewColumn)MessageLog,
			(DataGridViewColumn)PopUp,
			(DataGridViewColumn)Column_ShowBalloon,
			(DataGridViewColumn)Timescale_X1
		});
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = Color.FromArgb(60, 63, 65);
		val2.Font = new Font("Segoe UI", 8f);
		val2.ForeColor = Color.LightGray;
		val2.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val2.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DataGridView1).DefaultCellStyle = val2;
		((Control)DataGridView1).Dock = (DockStyle)5;
		((DataGridView)DataGridView1).EnableHeadersVisualStyles = false;
		((Control)DataGridView1).Location = new Point(3, 3);
		((Control)DataGridView1).Name = "DataGridView1";
		((DataGridView)DataGridView1).RowHeadersVisible = false;
		((DataGridView)DataGridView1).RowHeadersWidth = 62;
		val3.BackColor = Color.FromArgb(60, 63, 65);
		val3.ForeColor = Color.LightGray;
		val3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val3.SelectionForeColor = Color.LightGray;
		((DataGridView)DataGridView1).RowsDefaultCellStyle = val3;
		((Control)DataGridView1).Size = new Size(688, 635);
		((Control)DataGridView1).TabIndex = 0;
		((DataGridViewColumn)MessageType_Hidden).DataPropertyName = "MessageType_Hidden";
		((DataGridViewColumn)MessageType_Hidden).HeaderText = "MessageType_Hidden";
		((DataGridViewColumn)MessageType_Hidden).MinimumWidth = 8;
		((DataGridViewColumn)MessageType_Hidden).Name = "MessageType_Hidden";
		((DataGridViewColumn)MessageType_Hidden).ReadOnly = true;
		((DataGridViewColumn)MessageType_Hidden).Visible = false;
		((DataGridViewColumn)MessageType_Hidden).Width = 150;
		((DataGridViewColumn)MessageType).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)MessageType).DataPropertyName = "MessageType";
		((DataGridViewColumn)MessageType).HeaderText = "Message Type";
		((DataGridViewColumn)MessageType).MinimumWidth = 8;
		((DataGridViewColumn)MessageType).Name = "MessageType";
		((DataGridViewColumn)MessageType).ReadOnly = true;
		((DataGridViewColumn)MessageType).Width = 92;
		((DataGridViewColumn)MessageLog).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)MessageLog).DataPropertyName = "MessageLog";
		((DataGridViewColumn)MessageLog).HeaderText = "Show on Message Log";
		((DataGridViewColumn)MessageLog).MinimumWidth = 8;
		((DataGridViewColumn)MessageLog).Name = "MessageLog";
		((DataGridViewColumn)PopUp).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)PopUp).DataPropertyName = "PopUp";
		((DataGridViewColumn)PopUp).HeaderText = "Raise Pop-Up";
		((DataGridViewColumn)PopUp).MinimumWidth = 8;
		((DataGridViewColumn)PopUp).Name = "PopUp";
		((DataGridViewColumn)Column_ShowBalloon).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)Column_ShowBalloon).DataPropertyName = "ShowBalloon";
		((DataGridViewColumn)Column_ShowBalloon).HeaderText = "Show Balloon";
		((DataGridViewColumn)Column_ShowBalloon).MinimumWidth = 8;
		((DataGridViewColumn)Column_ShowBalloon).Name = "Column_ShowBalloon";
		((DataGridViewColumn)Timescale_X1).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)Timescale_X1).DataPropertyName = "TimescaleX1";
		((DataGridViewColumn)Timescale_X1).HeaderText = "Timescale X1";
		((DataGridViewColumn)Timescale_X1).MinimumWidth = 8;
		((DataGridViewColumn)Timescale_X1).Name = "Timescale_X1";
		TabPage3.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage3).Controls.Add((Control)(object)SFXVolumeLabel);
		((Control)TabPage3).Controls.Add((Control)(object)MusicVolumeLabel);
		((Control)TabPage3).Controls.Add((Control)(object)TB_SFXVolumeBar);
		((Control)TabPage3).Controls.Add((Control)(object)TB_MusicVolumeBar);
		((Control)TabPage3).Controls.Add((Control)(object)CB_Music);
		((Control)TabPage3).Controls.Add((Control)(object)CB_Sounds);
		TabPage3.Location = new Point(4, 24);
		((Control)TabPage3).Name = "TabPage3";
		((Control)TabPage3).Size = new Size(694, 641);
		TabPage3.TabIndex = 3;
		TabPage3.Text = "Sounds/Music";
		SFXVolumeLabel.AutoSize = true;
		((Control)SFXVolumeLabel).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)SFXVolumeLabel).Location = new Point(278, 67);
		((Control)SFXVolumeLabel).Name = "SFXVolumeLabel";
		((Control)SFXVolumeLabel).Size = new Size(119, 13);
		((Control)SFXVolumeLabel).TabIndex = 17;
		((Label)SFXVolumeLabel).Text = "Game Sounds Volume";
		((Label)SFXVolumeLabel).TextAlign = (ContentAlignment)2;
		MusicVolumeLabel.AutoSize = true;
		((Control)MusicVolumeLabel).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)MusicVolumeLabel).Location = new Point(296, 167);
		((Control)MusicVolumeLabel).Name = "MusicVolumeLabel";
		((Control)MusicVolumeLabel).Size = new Size(78, 13);
		((Control)MusicVolumeLabel).TabIndex = 16;
		((Label)MusicVolumeLabel).Text = "Music Volume";
		((Label)MusicVolumeLabel).TextAlign = (ContentAlignment)2;
		((Control)TB_SFXVolumeBar).Location = new Point(8, 35);
		TB_SFXVolumeBar.Maximum = 100;
		((Control)TB_SFXVolumeBar).Name = "TB_SFXVolumeBar";
		((Control)TB_SFXVolumeBar).Size = new Size(678, 45);
		((Control)TB_SFXVolumeBar).TabIndex = 15;
		TB_SFXVolumeBar.TickFrequency = 5;
		((Control)TB_MusicVolumeBar).Location = new Point(8, 135);
		TB_MusicVolumeBar.Maximum = 100;
		((Control)TB_MusicVolumeBar).Name = "TB_MusicVolumeBar";
		((Control)TB_MusicVolumeBar).Size = new Size(678, 45);
		((Control)TB_MusicVolumeBar).TabIndex = 14;
		TB_MusicVolumeBar.TickFrequency = 5;
		((ButtonBase)CB_Music).AutoSize = true;
		((Control)CB_Music).Location = new Point(8, 112);
		((Control)CB_Music).Name = "CB_Music";
		((Control)CB_Music).Size = new Size(143, 17);
		((Control)CB_Music).TabIndex = 7;
		((ButtonBase)CB_Music).Text = "Use background music";
		((ButtonBase)CB_Sounds).AutoSize = true;
		((Control)CB_Sounds).Location = new Point(8, 12);
		((Control)CB_Sounds).Name = "CB_Sounds";
		((Control)CB_Sounds).Size = new Size(117, 17);
		((Control)CB_Sounds).TabIndex = 6;
		((ButtonBase)CB_Sounds).Text = "Use game sounds";
		TabPage5.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage5).Controls.Add((Control)(object)GroupBox3);
		((Control)TabPage5).Controls.Add((Control)(object)GroupBox2);
		((Control)TabPage5).Controls.Add((Control)(object)GroupBox1);
		((Control)TabPage5).Controls.Add((Control)(object)Label9);
		TabPage5.Location = new Point(4, 24);
		((Control)TabPage5).Name = "TabPage5";
		((Control)TabPage5).Padding = new Padding(3);
		((Control)TabPage5).Size = new Size(694, 641);
		TabPage5.TabIndex = 5;
		TabPage5.Text = "Game Speed";
		((Control)GroupBox3).Anchor = (AnchorStyles)13;
		((Control)GroupBox3).Controls.Add((Control)(object)CB_Autosave);
		((Control)GroupBox3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroupBox3).Location = new Point(0, 378);
		((Control)GroupBox3).Name = "GroupBox3";
		((Control)GroupBox3).Size = new Size(688, 46);
		((Control)GroupBox3).TabIndex = 7;
		((GroupBox)GroupBox3).TabStop = false;
		((GroupBox)GroupBox3).Text = "Optional: These are pretty useful features that will free up additional CPU cycles for game execution when disabled";
		((Control)CB_Autosave).Location = new Point(10, 18);
		((Control)CB_Autosave).Name = "CB_Autosave";
		((Control)CB_Autosave).Size = new Size(660, 17);
		((Control)CB_Autosave).TabIndex = 0;
		((ButtonBase)CB_Autosave).Text = "Autosave: Saves the current scenario at 20 second intervals in Scenarios/Autosaves/\"current scenario name\"";
		((Control)GroupBox2).Anchor = (AnchorStyles)13;
		((Control)GroupBox2).Controls.Add((Control)(object)CB_FriendlyRangeSymbols);
		((Control)GroupBox2).Controls.Add((Control)(object)CB_DisplayIlluminationVectors);
		((Control)GroupBox2).Controls.Add((Control)(object)CB_DisplayContactEmissions);
		((Control)GroupBox2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroupBox2).Location = new Point(0, 294);
		((Control)GroupBox2).Name = "GroupBox2";
		((Control)GroupBox2).Size = new Size(688, 78);
		((Control)GroupBox2).TabIndex = 6;
		((GroupBox)GroupBox2).TabStop = false;
		((GroupBox)GroupBox2).Text = "Recommended: Disabling these will improve speed in large scenarios or in small scenarios running at high time-accel";
		((ButtonBase)CB_FriendlyRangeSymbols).AutoSize = true;
		((Control)CB_FriendlyRangeSymbols).Location = new Point(10, 17);
		((Control)CB_FriendlyRangeSymbols).Name = "CB_FriendlyRangeSymbols";
		((Control)CB_FriendlyRangeSymbols).Size = new Size(144, 17);
		((Control)CB_FriendlyRangeSymbols).TabIndex = 0;
		((ButtonBase)CB_FriendlyRangeSymbols).Text = "Friendly range symbols";
		((ButtonBase)CB_DisplayIlluminationVectors).AutoSize = true;
		((Control)CB_DisplayIlluminationVectors).Location = new Point(10, 36);
		((Control)CB_DisplayIlluminationVectors).Name = "CB_DisplayIlluminationVectors";
		((Control)CB_DisplayIlluminationVectors).Size = new Size(167, 17);
		((Control)CB_DisplayIlluminationVectors).TabIndex = 0;
		((ButtonBase)CB_DisplayIlluminationVectors).Text = "Display illumination vectors";
		((ButtonBase)CB_DisplayContactEmissions).AutoSize = true;
		((Control)CB_DisplayContactEmissions).Location = new Point(10, 55);
		((Control)CB_DisplayContactEmissions).Name = "CB_DisplayContactEmissions";
		((Control)CB_DisplayContactEmissions).Size = new Size(172, 17);
		((Control)CB_DisplayContactEmissions).TabIndex = 0;
		((ButtonBase)CB_DisplayContactEmissions).Text = "Display all contact emissions";
		((Control)GroupBox1).Anchor = (AnchorStyles)13;
		((Control)GroupBox1).Controls.Add((Control)(object)CB_AggressiveTileManagement);
		((Control)GroupBox1).Controls.Add((Control)(object)CB_ExtraMemoryProtection);
		((Control)GroupBox1).Controls.Add((Control)(object)CB_DisplayTargetingVectors);
		((Control)GroupBox1).Controls.Add((Control)(object)CB_DisallowHighPerformancePowerScheme);
		((Control)GroupBox1).Controls.Add((Control)(object)CB_ShowGhostedGroupMembers);
		((Control)GroupBox1).Controls.Add((Control)(object)CB_DisplayDatalinks);
		((Control)GroupBox1).Controls.Add((Control)(object)CB_DisplayMissionAreas);
		((Control)GroupBox1).Controls.Add((Control)(object)CB_DisplayCountryAndCityNames);
		((Control)GroupBox1).Controls.Add((Control)(object)CB_CustomFineGrainedNavigation);
		((Control)GroupBox1).Controls.Add((Control)(object)CB_NonFriendlyRangeSymbols);
		((Control)GroupBox1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroupBox1).Location = new Point(0, 31);
		((Control)GroupBox1).Name = "GroupBox1";
		((Control)GroupBox1).Size = new Size(688, 257);
		((Control)GroupBox1).TabIndex = 5;
		((GroupBox)GroupBox1).TabStop = false;
		((GroupBox)GroupBox1).Text = "Highly recommended: These settings have huge impact on speed and should be deselected";
		((ButtonBase)CB_AggressiveTileManagement).AutoSize = true;
		((Control)CB_AggressiveTileManagement).Location = new Point(10, 205);
		((Control)CB_AggressiveTileManagement).Name = "CB_AggressiveTileManagement";
		((Control)CB_AggressiveTileManagement).Size = new Size(381, 17);
		((Control)CB_AggressiveTileManagement).TabIndex = 2;
		((ButtonBase)CB_AggressiveTileManagement).Text = "Aggressive tile management (greater load on RAM / GPU / download)";
		((ButtonBase)CB_ExtraMemoryProtection).AutoSize = true;
		((Control)CB_ExtraMemoryProtection).Location = new Point(10, 21);
		((Control)CB_ExtraMemoryProtection).Name = "CB_ExtraMemoryProtection";
		((Control)CB_ExtraMemoryProtection).Size = new Size(151, 17);
		((Control)CB_ExtraMemoryProtection).TabIndex = 1;
		((ButtonBase)CB_ExtraMemoryProtection).Text = "Extra memory protection";
		((ButtonBase)CB_DisplayTargetingVectors).AutoSize = true;
		((Control)CB_DisplayTargetingVectors).Location = new Point(10, 136);
		((Control)CB_DisplayTargetingVectors).Name = "CB_DisplayTargetingVectors";
		((Control)CB_DisplayTargetingVectors).Size = new Size(171, 17);
		((Control)CB_DisplayTargetingVectors).TabIndex = 0;
		((ButtonBase)CB_DisplayTargetingVectors).Text = "Display all targeting vectors ";
		((ButtonBase)CB_DisallowHighPerformancePowerScheme).AutoSize = true;
		((Control)CB_DisallowHighPerformancePowerScheme).Location = new Point(10, 228);
		((Control)CB_DisallowHighPerformancePowerScheme).Name = "CB_DisallowHighPerformancePowerScheme";
		((Control)CB_DisallowHighPerformancePowerScheme).Size = new Size(310, 17);
		((Control)CB_DisallowHighPerformancePowerScheme).TabIndex = 0;
		((ButtonBase)CB_DisallowHighPerformancePowerScheme).Text = "Disallow switching to High-Performance power scheme";
		((ButtonBase)CB_ShowGhostedGroupMembers).AutoSize = true;
		((Control)CB_ShowGhostedGroupMembers).Location = new Point(10, 182);
		((Control)CB_ShowGhostedGroupMembers).Name = "CB_ShowGhostedGroupMembers";
		((Control)CB_ShowGhostedGroupMembers).Size = new Size(185, 17);
		((Control)CB_ShowGhostedGroupMembers).TabIndex = 0;
		((ButtonBase)CB_ShowGhostedGroupMembers).Text = "Show ghosted group members";
		((ButtonBase)CB_DisplayDatalinks).AutoSize = true;
		((Control)CB_DisplayDatalinks).Location = new Point(10, 159);
		((Control)CB_DisplayDatalinks).Name = "CB_DisplayDatalinks";
		((Control)CB_DisplayDatalinks).Size = new Size(128, 17);
		((Control)CB_DisplayDatalinks).TabIndex = 0;
		((ButtonBase)CB_DisplayDatalinks).Text = "Display all datalinks";
		((ButtonBase)CB_DisplayMissionAreas).AutoSize = true;
		((Control)CB_DisplayMissionAreas).Location = new Point(10, 113);
		((Control)CB_DisplayMissionAreas).Name = "CB_DisplayMissionAreas";
		((Control)CB_DisplayMissionAreas).Size = new Size(202, 17);
		((Control)CB_DisplayMissionAreas).TabIndex = 0;
		((ButtonBase)CB_DisplayMissionAreas).Text = "Display all mission areas / courses ";
		((ButtonBase)CB_DisplayCountryAndCityNames).AutoSize = true;
		((Control)CB_DisplayCountryAndCityNames).Location = new Point(10, 90);
		((Control)CB_DisplayCountryAndCityNames).Name = "CB_DisplayCountryAndCityNames";
		((Control)CB_DisplayCountryAndCityNames).Size = new Size(184, 17);
		((Control)CB_DisplayCountryAndCityNames).TabIndex = 0;
		((ButtonBase)CB_DisplayCountryAndCityNames).Text = "Display country and city names";
		((ButtonBase)CB_CustomFineGrainedNavigation).AutoSize = true;
		((Control)CB_CustomFineGrainedNavigation).Location = new Point(10, 67);
		((Control)CB_CustomFineGrainedNavigation).Name = "CB_CustomFineGrainedNavigation";
		((Control)CB_CustomFineGrainedNavigation).Size = new Size(234, 17);
		((Control)CB_CustomFineGrainedNavigation).TabIndex = 0;
		((ButtonBase)CB_CustomFineGrainedNavigation).Text = "Custom fine-grained navigation settings";
		((ButtonBase)CB_NonFriendlyRangeSymbols).AutoSize = true;
		((Control)CB_NonFriendlyRangeSymbols).Location = new Point(10, 44);
		((Control)CB_NonFriendlyRangeSymbols).Name = "CB_NonFriendlyRangeSymbols";
		((Control)CB_NonFriendlyRangeSymbols).Size = new Size(168, 17);
		((Control)CB_NonFriendlyRangeSymbols).TabIndex = 0;
		((ButtonBase)CB_NonFriendlyRangeSymbols).Text = "Non-friendly range symbols";
		Label9.AutoSize = true;
		((Control)Label9).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label9).Location = new Point(5, 10);
		((Control)Label9).Name = "Label9";
		((Control)Label9).Size = new Size(513, 13);
		((Control)Label9).TabIndex = 4;
		((Label)Label9).Text = "Deselect CPU-intensive features to reduce computer workload and improve game execution speed:";
		TabPage6.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage6).Controls.Add((Control)(object)TB_TacviewPath);
		((Control)TabPage6).Controls.Add((Control)(object)Button_TacviewPath);
		((Control)TabPage6).Controls.Add((Control)(object)DarkLabel1);
		TabPage6.Location = new Point(4, 24);
		((Control)TabPage6).Name = "TabPage6";
		((Control)TabPage6).Padding = new Padding(3);
		((Control)TabPage6).Size = new Size(694, 641);
		TabPage6.TabIndex = 6;
		TabPage6.Text = "Tacview";
		TB_TacviewPath.AutoCompleteCustomSource = null;
		TB_TacviewPath.AutoCompleteMode = (AutoCompleteMode)0;
		TB_TacviewPath.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TB_TacviewPath).BackColor = Color.Transparent;
		((Control)TB_TacviewPath).ForeColor = Color.FromArgb(189, 189, 189);
		TB_TacviewPath.Image = null;
		TB_TacviewPath.Lines = null;
		((Control)TB_TacviewPath).Location = new Point(140, 11);
		TB_TacviewPath.MaxLength = 32767;
		TB_TacviewPath.Multiline = false;
		((Control)TB_TacviewPath).Name = "TB_TacviewPath";
		TB_TacviewPath.ReadOnly = false;
		TB_TacviewPath.ScrollBars = (ScrollBars)0;
		TB_TacviewPath.SelectionStart = 0;
		((Control)TB_TacviewPath).Size = new Size(467, 20);
		((Control)TB_TacviewPath).TabIndex = 3;
		TB_TacviewPath.TextAlign = (HorizontalAlignment)0;
		TB_TacviewPath.UseSystemPasswordChar = false;
		TB_TacviewPath.WatermarkText = "";
		TB_TacviewPath.WordWrap = false;
		((ButtonBase)Button_TacviewPath).BackColor = Color.Transparent;
		((Control)Button_TacviewPath).ForeColor = SystemColors.Control;
		((Control)Button_TacviewPath).Location = new Point(613, 11);
		((Control)Button_TacviewPath).Name = "Button_TacviewPath";
		((Control)Button_TacviewPath).Padding = new Padding(5);
		Button_TacviewPath.RoundRadius = 0;
		((Control)Button_TacviewPath).Size = new Size(75, 20);
		((Control)Button_TacviewPath).TabIndex = 4;
		Button_TacviewPath.Text = "Select...";
		DarkLabel1.AutoSize = true;
		((Control)DarkLabel1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel1).Location = new Point(6, 14);
		((Control)DarkLabel1).Name = "DarkLabel1";
		((Control)DarkLabel1).Size = new Size(133, 13);
		((Control)DarkLabel1).TabIndex = 0;
		((Label)DarkLabel1).Text = "Tacview executable path:";
		TabPage7.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage7).Controls.Add((Control)(object)ElementHost1);
		TabPage7.Location = new Point(4, 24);
		((Control)TabPage7).Name = "TabPage7";
		((Control)TabPage7).Padding = new Padding(3);
		((Control)TabPage7).Size = new Size(694, 641);
		TabPage7.TabIndex = 7;
		TabPage7.Text = "Hover Info";
		((Control)ElementHost1).Dock = (DockStyle)5;
		((Control)ElementHost1).Location = new Point(3, 3);
		((Control)ElementHost1).Name = "ElementHost1";
		((Control)ElementHost1).Size = new Size(688, 635);
		((Control)ElementHost1).TabIndex = 0;
		((Control)ElementHost1).Text = "ElementHost1";
		ElementHost1.Child = null;
		((FileDialog)OpenFileDialog1).FileName = "OpenFileDialog1";
		((Control)DarkGroupBox5).Controls.Add((Control)(object)TableLayoutPanel2);
		((Control)DarkGroupBox5).Controls.Add((Control)(object)lblIconZoom);
		((Control)DarkGroupBox5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkGroupBox5).Location = new Point(348, 9);
		((Control)DarkGroupBox5).Name = "DarkGroupBox5";
		((Control)DarkGroupBox5).Size = new Size(334, 68);
		((Control)DarkGroupBox5).TabIndex = 57;
		((GroupBox)DarkGroupBox5).TabStop = false;
		TableLayoutPanel2.ColumnCount = 1;
		TableLayoutPanel2.ColumnStyles.Add(new ColumnStyle((SizeType)2, 100f));
		TableLayoutPanel2.Controls.Add((Control)(object)TB_Icon_Zoom, 0, 0);
		((Control)TableLayoutPanel2).Dock = (DockStyle)5;
		((Control)TableLayoutPanel2).Location = new Point(3, 18);
		((Control)TableLayoutPanel2).Name = "TableLayoutPanel2";
		TableLayoutPanel2.RowCount = 1;
		TableLayoutPanel2.RowStyles.Add(new RowStyle((SizeType)1, 30f));
		TableLayoutPanel2.RowStyles.Add(new RowStyle((SizeType)1, 20f));
		TableLayoutPanel2.RowStyles.Add(new RowStyle((SizeType)1, 20f));
		TableLayoutPanel2.RowStyles.Add(new RowStyle((SizeType)1, 20f));
		TableLayoutPanel2.RowStyles.Add(new RowStyle((SizeType)1, 20f));
		TableLayoutPanel2.RowStyles.Add(new RowStyle((SizeType)1, 20f));
		TableLayoutPanel2.RowStyles.Add(new RowStyle((SizeType)1, 20f));
		((Control)TableLayoutPanel2).Size = new Size(328, 47);
		((Control)TableLayoutPanel2).TabIndex = 50;
		TB_Icon_Zoom.AutoSize = false;
		((Control)TB_Icon_Zoom).Dock = (DockStyle)5;
		TB_Icon_Zoom.LargeChange = 20;
		((Control)TB_Icon_Zoom).Location = new Point(3, 3);
		TB_Icon_Zoom.Maximum = 100;
		TB_Icon_Zoom.Minimum = 10;
		((Control)TB_Icon_Zoom).Name = "TB_Icon_Zoom";
		((Control)TB_Icon_Zoom).Size = new Size(322, 41);
		TB_Icon_Zoom.SmallChange = 10;
		((Control)TB_Icon_Zoom).TabIndex = 48;
		TB_Icon_Zoom.TickFrequency = 10;
		TB_Icon_Zoom.Value = 20;
		lblIconZoom.AutoSize = true;
		((Control)lblIconZoom).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)lblIconZoom).Location = new Point(5, 1);
		((Control)lblIconZoom).Name = "lblIconZoom";
		((Control)lblIconZoom).Size = new Size(61, 13);
		((Control)lblIconZoom).TabIndex = 43;
		((Label)lblIconZoom).Text = "Icon Zoom";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(702, 669);
		((Control)this).Controls.Add((Control)(object)TabControl1);
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Form)this).MinimumSize = new Size(718, 708);
		((Control)this).Name = "Options";
		((Form)this).ShowIcon = false;
		((Form)this).Text = "Options";
		((Control)TabControl1).ResumeLayout(false);
		((Control)TabPage1).ResumeLayout(false);
		((Control)TabPage1).PerformLayout();
		((Control)DetectStuckUnitPulsesSettingsPanel).ResumeLayout(false);
		((Control)DetectStuckUnitPulsesSettingsPanel).PerformLayout();
		((Control)DarkGroupBox1).ResumeLayout(false);
		((Control)DarkGroupBox1).PerformLayout();
		((Control)GB_PauseBehaviour).ResumeLayout(false);
		((Control)GB_PauseBehaviour).PerformLayout();
		((Control)TabPage4).ResumeLayout(false);
		((Control)TabPage4).PerformLayout();
		((Control)DarkGroupBox4).ResumeLayout(false);
		((Control)DarkGroupBox4).PerformLayout();
		((Control)TableLayoutPanel1).ResumeLayout(false);
		((Control)TableLayoutPanel1).PerformLayout();
		((ISupportInitialize)TB_Flower_Zoom).EndInit();
		((ISupportInitialize)TB_GrounUnit_Zoom).EndInit();
		((ISupportInitialize)TB_Rectangle_Zoom).EndInit();
		((ISupportInitialize)TB_Diamond_Zoom).EndInit();
		((Control)DarkGroupBox3).ResumeLayout(false);
		((Control)DarkGroupBox3).PerformLayout();
		((Control)AltitudeAndTerrainOptionsPanel).ResumeLayout(false);
		((Control)TerrainDeformationGroupBox).ResumeLayout(false);
		((Control)TerrainDeformationGroupBox).PerformLayout();
		((Control)TerrainRenderingOptionsPanel).ResumeLayout(false);
		((Control)TerrainRenderingOptionsPanel).PerformLayout();
		((ISupportInitialize)VerticalScalingMultiplierTrackBar).EndInit();
		((Control)AdditionalAltitudeOptionsPanel).ResumeLayout(false);
		((Control)AdditionalAltitudeOptionsPanel).PerformLayout();
		((Control)DarkGroupBox2).ResumeLayout(false);
		((Control)DarkGroupBox2).PerformLayout();
		((ISupportInitialize)Num_SlugTrailLifetime).EndInit();
		((Control)TabPage2).ResumeLayout(false);
		((ISupportInitialize)(object)DataGridView1).EndInit();
		((Control)TabPage3).ResumeLayout(false);
		((Control)TabPage3).PerformLayout();
		((ISupportInitialize)TB_SFXVolumeBar).EndInit();
		((ISupportInitialize)TB_MusicVolumeBar).EndInit();
		((Control)TabPage5).ResumeLayout(false);
		((Control)TabPage5).PerformLayout();
		((Control)GroupBox3).ResumeLayout(false);
		((Control)GroupBox2).ResumeLayout(false);
		((Control)GroupBox2).PerformLayout();
		((Control)GroupBox1).ResumeLayout(false);
		((Control)GroupBox1).PerformLayout();
		((Control)TabPage6).ResumeLayout(false);
		((Control)TabPage6).PerformLayout();
		((Control)TabPage7).ResumeLayout(false);
		((Control)DarkGroupBox5).ResumeLayout(false);
		((Control)DarkGroupBox5).PerformLayout();
		((Control)TableLayoutPanel2).ResumeLayout(false);
		((ISupportInitialize)TB_Icon_Zoom).EndInit();
		((Control)this).ResumeLayout(false);
	}

	private void Options_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		if (!GameGeneral.TacviewPipeEnabled)
		{
			((TabControl)TabControl1).TabPages.RemoveAt(5);
		}
		HoverInfoOptions1 = new HoverInfoOptions();
		ElementHost1.Child = (UIElement)(object)HoverInfoOptions1;
		RefreshOptions();
	}

	internal void RefreshOptions()
	{
		bool_5 = true;
		try
		{
			((CheckBox)CB_UseAutosave).Checked = gamePreferences_0.UseAutosave;
			((CheckBox)CB_ShowDiagnostics).Checked = gamePreferences_0.ShowDiagnostics;
			((CheckBox)CB_MessageLogInWindow).Checked = gamePreferences_0.MessageLogInWindow;
			((CheckBox)CB_Sounds).Checked = gamePreferences_0.GameSounds;
			((CheckBox)CB_Music).Checked = gamePreferences_0.GameMusic;
			((CheckBox)CB_RMB_MoveOrder).Checked = gamePreferences_0.RMB_MoveOrder_Enabled;
			TB_SFXVolumeBar.Value = gamePreferences_0.SFXVolume;
			TB_MusicVolumeBar.Value = gamePreferences_0.MusicVolume;
			((CheckBox)CB_AltitudeInFeet).Checked = gamePreferences_0.ShowAltitudeInFeet;
			((CheckBox)CB_CargoShowUSUnits).Checked = gamePreferences_0.ShowUSUnitsForEditCargo;
			((CheckBox)CB_SmartRPPlacement).Checked = gamePreferences_0.AllowSmartRPPlacement;
			((ComboBox)Combo_GroundSpeedUnit).SelectedIndex = (int)gamePreferences_0.GroundUnitsSpeedUnit;
			((Control)Combo_CoordinateUnit).Visible = false;
			((Control)GeocentricCoordLabel).Visible = false;
			((CheckBox)CB_ZoomOnCursor).Checked = gamePreferences_0.ZoomOnCursor;
			((ComboBox)CB_SonobuoyVisibility).SelectedIndex = (int)gamePreferences_0.SonobuoyVisibility;
			((ComboBox)CB_RefPointVisibility).SelectedIndex = (int)gamePreferences_0.RefPointVisibility;
			((ComboBox)CB_MapSymbols).SelectedIndex = (int)gamePreferences_0.MapSymbolsSet;
			((ComboBox)CB_MapCursorBox).SelectedIndex = (int)gamePreferences_0.MapCursorBox;
			((ComboBox)CP_ShowGhostedGroupMembers).SelectedIndex = (int)gamePreferences_0.ShowGhostedGroupMembers;
			((ComboBox)CP_ShowPlottedPaths).SelectedIndex = (int)gamePreferences_0.ShowPlottedPaths;
			((ComboBox)CP_ShowFlightPlans_Airborne).SelectedIndex = (int)gamePreferences_0.ShowFlightPlans_Airborne;
			((ComboBox)CP_ShowFlightPlans_Planned).SelectedIndex = (int)gamePreferences_0.ShowFlightPlans_Planned;
			((ComboBox)CP_ShowAU_Behaviour_Bark).SelectedIndex = (int)gamePreferences_0.ShowAU_Behaviour_Bark;
			TB_Navigation_MaxDistanceNM.Text = Conversions.ToString(gamePreferences_0.NavigationMaxDistanceNMSetting);
			TB_Navigation_ThresholdDistanceDeg.Text = Conversions.ToString(gamePreferences_0.NavigationThresholdDistanceDegSetting);
			((CheckBox)CB_LogDebugInfoToFile).Checked = gamePreferences_0.LogDebugInfoToFile;
			((CheckBox)DetectStuckUnitPulsesCheckBox).Checked = gamePreferences_0.DetectStuckUnitPulses;
			StuckUnitPulseThresholdMillisecondsTextBox.Text = gamePreferences_0.StuckUnitPulseThresholdMilliseconds.ToString();
			((CheckBox)PauseOnDetectedStuckUnitPulseCheckBox).Checked = gamePreferences_0.PauseOnDetectedStuckUnitPulse;
			((CheckBox)SaveScenarioCopyOnDetectedStuckUnitPulseCheckBox).Checked = gamePreferences_0.SaveScenarioCopyOnDetectedStuckUnitPulse;
			((CheckBox)CB_UnitStatusImage).Checked = gamePreferences_0.UnitStatusImage;
			((CheckBox)CB_RMB_MoveOrder).Checked = gamePreferences_0.RMB_MoveOrder_Enabled;
			((CheckBox)CB_DrawOutlines).Checked = gamePreferences_0.DrawOutlines;
			((CheckBox)CB_TrueAltitudeRenderForceSubsurfaceUnitsAtSurface).Checked = gamePreferences_0.AltitudeRender.Unrectified_ForOptionsUIAndIni.ShowSubsurfaceUnitsAtSurface;
			((CheckBox)CB_TrueAltitudeRenderForceGroundUnitsAtSurface).Checked = gamePreferences_0.AltitudeRender.Unrectified_ForOptionsUIAndIni.ShowGroundUnitsAtSurface;
			((CheckBox)CB_TrueAltitudeRenderFromGroundInsteadOfSurface).Checked = gamePreferences_0.AltitudeRender.Unrectified_ForOptionsUIAndIni.UseGroundInsteadOfSurfaceAsRenderReference;
			VerticalScalingMultiplierTrackBar.Value = Math.Max(VerticalScalingMultiplierTrackBar.Minimum, Math.Min(VerticalScalingMultiplierTrackBar.Maximum, gamePreferences_0.AltitudeRender.Unrectified_ForOptionsUIAndIni.VerticalScaling));
			((CheckBox)CB_Show3DTerrain).Checked = gamePreferences_0.AltitudeRender.Unrectified_ForOptionsUIAndIni.Show3DTerrain;
			((CheckBox)CB_DrawUnitsAtTrueAltitude).Checked = gamePreferences_0.AltitudeRender.Unrectified_ForOptionsUIAndIni.UnitsAtAltitude;
			((Control)CB_AllowPowerScemeSwitch).Enabled = PowerManagement.IsSupportedByOS();
			((CheckBox)CB_AllowPowerScemeSwitch).Checked = gamePreferences_0.AllowPowerPlanSwitch && PowerManagement.IsSupportedByOS();
			((CheckBox)CB_UsePersonalMapProfile).Checked = gamePreferences_0.UsePersonalMapProfile;
			((CheckBox)CB_ColorDatablocks).Checked = Client.CurrentMapProfile.ColorDatablocks;
			TB_GrounUnit_Zoom.Value = gamePreferences_0.GroundUnitZoom;
			((ComboBox)CB_AirDockPauseBehaviour).SelectedIndex = (byte)gamePreferences_0.PauseOnAirDockOps;
			((ComboBox)CB_DVViewerPauseBehaviour).SelectedIndex = (byte)gamePreferences_0.PauseOnDBView;
			gamePreferences_0.PauseOnAirDockOps = (SimConfiguration.WindowPauseBehaviour)((ComboBox)CB_AirDockPauseBehaviour).SelectedIndex;
			((CheckBox)CB_SlugTrail_UseSlugTrail).Checked = gamePreferences_0.SlugTrail_Use;
			((CheckBox)CB_SlugTrail_Friendly).Checked = gamePreferences_0.SlugTrail_Friendly;
			((CheckBox)CB_SlugTrail_Hostile).Checked = gamePreferences_0.SlugTrail_Hostile;
			try
			{
				Num_SlugTrailLifetime.Value = new decimal(gamePreferences_0.SlugTrail_LifeTime);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				Num_SlugTrailLifetime.Value = 1m;
				ProjectData.ClearProjectError();
			}
			((CheckBox)CB_SlugTrail_Unfriendly).Checked = gamePreferences_0.SlugTrail_Unfriendly;
			((CheckBox)CB_SlugTrail_Unknown).Checked = gamePreferences_0.SlugTrail_UnKnown;
			((CheckBox)CB_SlugTrail_Neutral).Checked = gamePreferences_0.SlugTrail_Neutral;
			((CheckBox)CB_SlugTrail_Own).Checked = gamePreferences_0.SlugTrail_OwnAndAllied;
			((ComboBox)Combo_SlugTrailFreq).SelectedIndex = (int)gamePreferences_0.SlugTrailTimeFrequency;
			((CheckBox)ChkASWNoise).Checked = Client.CurrentMapProfile.ShowDynamicNoiseSignature;
			method_2();
			((CheckBox)CB_NonFriendlyRangeSymbols).Checked = Client.CurrentMapProfile.ShowNonFriendly;
			if (gamePreferences_0.NavigationMaxDistanceNMSetting == 8f && (double)gamePreferences_0.NavigationThresholdDistanceDegSetting == 0.5)
			{
				((CheckBox)CB_CustomFineGrainedNavigation).Checked = false;
				((ButtonBase)CB_CustomFineGrainedNavigation).Text = "Custom fine-grained navigation settings [CUSTOM VALUES ARE ALREADY EQUIVALENT TO DEFAULT ONES]";
				((Control)CB_CustomFineGrainedNavigation).Enabled = false;
			}
			else
			{
				((CheckBox)CB_CustomFineGrainedNavigation).Checked = true;
				((ButtonBase)CB_CustomFineGrainedNavigation).Text = "Custom fine-grained navigation settings ";
				((Control)CB_CustomFineGrainedNavigation).Enabled = true;
			}
			((CheckBox)CB_DisplayCountryAndCityNames).Checked = gamePreferences_0.DrawOutlines;
			if (SimConfiguration.DefaultGamePreferences.ShowMissionArea == Game.GamePreferences.ObjectVisibilitySetting.All)
			{
				((CheckBox)CB_DisplayMissionAreas).Checked = true;
				((ButtonBase)CB_DisplayMissionAreas).Text = "Display all mission areas / courses ";
				((Control)CB_DisplayMissionAreas).Enabled = true;
			}
			else
			{
				((CheckBox)CB_DisplayMissionAreas).Checked = false;
				((ButtonBase)CB_DisplayMissionAreas).Text = "Display all mission areas / courses [CUSTOM VALUE SET IN 'MAP DISPLAY' IS ALREADY EQUIVALENT TO DEFAULT ONE]";
				((Control)CB_DisplayMissionAreas).Enabled = false;
			}
			((CheckBox)CB_DisplayTargetingVectors).Checked = Client.CurrentMapProfile.ShowTargetingVectors == MapProfile._ShowElement.All;
			((CheckBox)CB_DisplayDatalinks).Checked = Client.CurrentMapProfile.ShowDatalinks == MapProfile._ShowElement.All;
			if (gamePreferences_0.ShowGhostedGroupMembers != Game.GamePreferences.GhostedGroupMembersVisibilitySetting.All && gamePreferences_0.ShowGhostedGroupMembers != Game.GamePreferences.GhostedGroupMembersVisibilitySetting.SelectedUnit)
			{
				((CheckBox)CB_ShowGhostedGroupMembers).Checked = false;
				((ButtonBase)CB_ShowGhostedGroupMembers).Text = "Show ghosted group members [CUSTOM VALUE SET IN 'MAP DISPLAY' IS ALREADY EQUIVALENT TO DEFAULT ONE]";
				((Control)CB_ShowGhostedGroupMembers).Enabled = false;
			}
			else
			{
				((CheckBox)CB_ShowGhostedGroupMembers).Checked = true;
				((ButtonBase)CB_ShowGhostedGroupMembers).Text = "Show ghosted group members";
				((Control)CB_ShowGhostedGroupMembers).Enabled = true;
			}
			((Control)CB_DisallowHighPerformancePowerScheme).Enabled = PowerManagement.IsSupportedByOS();
			((CheckBox)CB_DisallowHighPerformancePowerScheme).Checked = !gamePreferences_0.AllowPowerPlanSwitch && PowerManagement.IsSupportedByOS();
			((CheckBox)CB_AggressiveTileManagement).Checked = gamePreferences_0.AggressiveTileManagement;
			((CheckBox)CB_FriendlyRangeSymbols).Checked = Client.CurrentMapProfile.ShowRangeSymbols == MapProfile._ShowElement.All;
			((CheckBox)CB_DisplayIlluminationVectors).Checked = Client.CurrentMapProfile.ShowIlluminationVectors == MapProfile._ShowElement.All;
			((CheckBox)CB_DisplayContactEmissions).Checked = Client.CurrentMapProfile.ShowContactEmissions == MapProfile._ShowElement.All;
			((CheckBox)CB_Autosave).Checked = gamePreferences_0.UseAutosave;
			if (!string.IsNullOrEmpty(SimConfiguration.DefaultGamePreferences.TacviewExePath))
			{
				TB_TacviewPath.Text = SimConfiguration.DefaultGamePreferences.TacviewExePath;
			}
			if (Directory.Exists(Client.OSMstylesFolder))
			{
				((ComboBox)CB_OSMstyle).Items.Clear();
				string[] files = Directory.GetFiles(Client.OSMstylesFolder);
				for (int i = 0; i < files.Length; i = checked(i + 1))
				{
					GlMapStyle glMapStyle = GlMapStyle.FromFile(files[i]);
					((ComboBox)CB_OSMstyle).Items.Add((object)glMapStyle.Name);
				}
				((ComboBox)CB_OSMstyle).SelectedIndex = 0;
			}
			method_74(TB_GrounUnit_Zoom, gamePreferences_0.GroundUnitZoom);
			method_74(TB_Diamond_Zoom, gamePreferences_0.DiamondZoom);
			method_74(TB_Rectangle_Zoom, gamePreferences_0.RectangleZoom);
			method_74(TB_Flower_Zoom, gamePreferences_0.FlowerZoom);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 28193", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		finally
		{
			bool_5 = false;
		}
	}

	private void method_2()
	{
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add("MessageType_Hidden", typeof(string));
		dataTable.Columns.Add("MessageType", typeof(string));
		dataTable.Columns.Add("MessageLog", typeof(bool));
		dataTable.Columns.Add("PopUp", typeof(bool));
		dataTable.Columns.Add("ShowBalloon", typeof(bool));
		dataTable.Columns.Add("TimescaleX1", typeof(bool));
		foreach (LoggedMessage.MessageType key in SimConfiguration.DefaultGamePreferences.MessageLogSettings.Keys)
		{
			if (key != LoggedMessage.MessageType.CustomUI && (key != LoggedMessage.MessageType.CommsIsolatedMessage || Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.CommsDisruption)) && key != LoggedMessage.MessageType.UnguidedWeaponModifiers)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow["MessageType_Hidden"] = key.ToString();
				dataRow["MessageType"] = Misc.ToEnglishString(key);
				dataRow["MessageLog"] = SimConfiguration.DefaultGamePreferences.MessageLogSettings[key].ShowOnMessageLog;
				dataRow["PopUp"] = SimConfiguration.DefaultGamePreferences.MessageLogSettings[key].PopUp;
				dataRow["ShowBalloon"] = SimConfiguration.DefaultGamePreferences.MessageLogSettings[key].ShowBaloon;
				dataRow["TimescaleX1"] = SimConfiguration.DefaultGamePreferences.MessageLogSettings[key].bool_0;
				dataTable.Rows.Add(dataRow);
			}
		}
		DataView dataView = new DataView(dataTable);
		dataView.Sort = "MessageType";
		((DataGridView)DataGridView1).DataSource = dataView;
	}

	private void Options_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
		else
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void method_3(object sender, EventArgs e)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		WindowPlacement.WindowPlacementSettings.Clear();
		SimConfiguration.SaveSettings(WindowPlacement.WindowPlacementSettings, Client.RecentFilenames);
		DarkMessageBox.ShowInformation("Positions & sizes of secondary windows have been reset to default values", "");
	}

	private void Options_FormClosing(object sender, FormClosingEventArgs e)
	{
		method_8();
		method_9();
		SimConfiguration.SaveSettings(WindowPlacement.WindowPlacementSettings, Client.RecentFilenames);
		((Control)this).Hide();
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void method_4(object sender, EventArgs e)
	{
		bool_3 = true;
		RefreshOptions();
	}

	private void method_5(object sender, EventArgs e)
	{
		method_8();
		RefreshOptions();
	}

	private void method_6(object sender, EventArgs e)
	{
		bool_4 = true;
		RefreshOptions();
	}

	private void method_7(object sender, EventArgs e)
	{
		method_9();
		RefreshOptions();
	}

	private void method_8()
	{
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		if (bool_3)
		{
			bool_3 = false;
			if (!string.IsNullOrEmpty(TB_Navigation_MaxDistanceNM.Text) && Versioned.IsNumeric((object)TB_Navigation_MaxDistanceNM.Text))
			{
				if (Conversions.ToSingle(TB_Navigation_MaxDistanceNM.Text) != Client.CurrentScenario.Navigation_FinegrainedMaxDistance)
				{
					DarkMessageBox.ShowWarning("IMPORTANT NOTE! You have selected to use fine-grained navigation for distances up to " + TB_Navigation_MaxDistanceNM.Text + " nm, and look for paths up to " + TB_Navigation_ThresholdDistanceDeg.Text + " degrees lat/lon outside the start and end points. Fine-grained navigation is extremely CPU intensive, and for instance a 50 nm course with 2 degrees lat/lon search area outside the start and end points may take up to five minutes to compute since it involves checking nearly one million (!) points. Do not alter these settings unless you know what you do. The default setting is 8 nm and 0.5 degrees.", "");
				}
				gamePreferences_0.NavigationMaxDistanceNMSetting = Conversions.ToSingle(TB_Navigation_MaxDistanceNM.Text);
				if (!Information.IsNothing((object)Client.CurrentScenario))
				{
					Client.CurrentScenario.Navigation_FinegrainedMaxDistance = Conversions.ToSingle(TB_Navigation_MaxDistanceNM.Text);
				}
			}
			else
			{
				gamePreferences_0.NavigationMaxDistanceNMSetting = 0f;
				if (!Information.IsNothing((object)Client.CurrentScenario))
				{
					Client.CurrentScenario.Navigation_FinegrainedMaxDistance = 0f;
				}
				TB_Navigation_MaxDistanceNM.Text = "0";
			}
		}
		else
		{
			bool_3 = false;
		}
	}

	private void method_9()
	{
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		if (!bool_4)
		{
			bool_4 = false;
			return;
		}
		bool_4 = false;
		if (!string.IsNullOrEmpty(TB_Navigation_ThresholdDistanceDeg.Text) && Versioned.IsNumeric((object)TB_Navigation_ThresholdDistanceDeg.Text))
		{
			if (Conversions.ToSingle(TB_Navigation_ThresholdDistanceDeg.Text) != Client.CurrentScenario.Navigation_FinegrainedThresholdDistance)
			{
				DarkMessageBox.ShowWarning("IMPORTANT NOTE! You have selected to use fine-grained navigation for distances up to " + TB_Navigation_MaxDistanceNM.Text + " nm, and look for paths up to " + TB_Navigation_ThresholdDistanceDeg.Text + " degrees lat/lon outside the start and end points. Fine-grained navigation is extremely CPU intensive, and for instance a 50 nm course with 2 degrees lat/lon search area outside the start and end points may take up to five minutes to compute since it involves checking nearly one million (!) points. Do not alter these settings unless you know what you do. The default setting is 8 nm and 0.5 degrees.", "");
			}
			gamePreferences_0.NavigationThresholdDistanceDegSetting = Conversions.ToSingle(TB_Navigation_ThresholdDistanceDeg.Text);
			if (!Information.IsNothing((object)Client.CurrentScenario))
			{
				Client.CurrentScenario.Navigation_FinegrainedThresholdDistance = Conversions.ToSingle(TB_Navigation_ThresholdDistanceDeg.Text);
			}
		}
		else
		{
			gamePreferences_0.NavigationThresholdDistanceDegSetting = 0f;
			if (!Information.IsNothing((object)Client.CurrentScenario))
			{
				Client.CurrentScenario.Navigation_FinegrainedThresholdDistance = 0f;
			}
			TB_Navigation_ThresholdDistanceDeg.Text = "0";
		}
	}

	private void method_10(object sender, EventArgs e)
	{
		int mustRefreshMainForm;
		if (((CheckBox)CB_NonFriendlyRangeSymbols).Checked)
		{
			mustRefreshMainForm = 1;
		}
		else
		{
			Client.CurrentMapProfile.ShowNonFriendly = false;
			MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
			mustRefreshMainForm = 1;
		}
		Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
		RefreshOptions();
	}

	private void method_11(object sender, EventArgs e)
	{
		int mustRefreshMainForm;
		if (!((CheckBox)CB_CustomFineGrainedNavigation).Checked)
		{
			gamePreferences_0.NavigationMaxDistanceNMSetting = 8f;
			gamePreferences_0.NavigationThresholdDistanceDegSetting = 0.5f;
			Client.CurrentScenario.Navigation_FinegrainedMaxDistance = 8f;
			Client.CurrentScenario.Navigation_FinegrainedThresholdDistance = 0.5f;
			mustRefreshMainForm = 1;
		}
		else
		{
			mustRefreshMainForm = 1;
		}
		Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
		RefreshOptions();
	}

	private void method_12(object sender, EventArgs e)
	{
		gamePreferences_0.DrawOutlines = ((CheckBox)CB_DisplayCountryAndCityNames).Checked;
		Client.MustRefreshMainForm = true;
		RefreshOptions();
	}

	private void method_13(object sender, EventArgs e)
	{
		int mustRefreshMainForm;
		if (((CheckBox)CB_DisplayMissionAreas).Checked)
		{
			mustRefreshMainForm = 1;
		}
		else
		{
			gamePreferences_0.ShowMissionArea = Game.GamePreferences.ObjectVisibilitySetting.DontShow;
			MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
			mustRefreshMainForm = 1;
		}
		Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
		RefreshOptions();
	}

	private void method_14(object sender, EventArgs e)
	{
		int mustRefreshMainForm;
		if (((CheckBox)CB_DisplayTargetingVectors).Checked)
		{
			Client.CurrentMapProfile.ShowTargetingVectors = MapProfile._ShowElement.All;
			mustRefreshMainForm = 1;
		}
		else
		{
			Client.CurrentMapProfile.ShowTargetingVectors = MapProfile._ShowElement.DontShow;
			MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
			mustRefreshMainForm = 1;
		}
		Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
		RefreshOptions();
	}

	private void method_15(object sender, EventArgs e)
	{
		int mustRefreshMainForm;
		if (((CheckBox)CB_DisplayDatalinks).Checked)
		{
			Client.CurrentMapProfile.ShowDatalinks = MapProfile._ShowElement.All;
			mustRefreshMainForm = 1;
		}
		else
		{
			Client.CurrentMapProfile.ShowDatalinks = MapProfile._ShowElement.DontShow;
			MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
			mustRefreshMainForm = 1;
		}
		Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
		RefreshOptions();
	}

	private void method_16(object sender, EventArgs e)
	{
		gamePreferences_0.AllowPowerPlanSwitch = !((CheckBox)CB_DisallowHighPerformancePowerScheme).Checked;
		Client.MustRefreshMainForm = true;
		RefreshOptions();
	}

	private void method_17(object sender, EventArgs e)
	{
		int mustRefreshMainForm;
		if (((CheckBox)CB_FriendlyRangeSymbols).Checked)
		{
			Client.CurrentMapProfile.ShowRangeSymbols = MapProfile._ShowElement.All;
			mustRefreshMainForm = 1;
		}
		else
		{
			Client.CurrentMapProfile.ShowRangeSymbols = MapProfile._ShowElement.DontShow;
			MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
			mustRefreshMainForm = 1;
		}
		Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
		RefreshOptions();
	}

	private void method_18(object sender, EventArgs e)
	{
		int mustRefreshMainForm;
		if (!((CheckBox)CB_DisplayIlluminationVectors).Checked)
		{
			Client.CurrentMapProfile.ShowIlluminationVectors = MapProfile._ShowElement.DontShow;
			MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
			mustRefreshMainForm = 1;
		}
		else
		{
			Client.CurrentMapProfile.ShowIlluminationVectors = MapProfile._ShowElement.All;
			mustRefreshMainForm = 1;
		}
		Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
		RefreshOptions();
	}

	private void method_19(object sender, EventArgs e)
	{
		int mustRefreshMainForm;
		if (!((CheckBox)CB_DisplayContactEmissions).Checked)
		{
			Client.CurrentMapProfile.ShowContactEmissions = MapProfile._ShowElement.DontShow;
			MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
			mustRefreshMainForm = 1;
		}
		else
		{
			Client.CurrentMapProfile.ShowContactEmissions = MapProfile._ShowElement.All;
			mustRefreshMainForm = 1;
		}
		Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
		RefreshOptions();
	}

	private void method_20(object sender, EventArgs e)
	{
		gamePreferences_0.UseAutosave = ((CheckBox)CB_Autosave).Checked;
		Client.MustRefreshMainForm = true;
		RefreshOptions();
	}

	private void method_21(object sender, EventArgs e)
	{
		int mustRefreshMainForm;
		if (((CheckBox)CB_ShowGhostedGroupMembers).Checked)
		{
			mustRefreshMainForm = 1;
		}
		else
		{
			gamePreferences_0.ShowGhostedGroupMembers = Game.GamePreferences.GhostedGroupMembersVisibilitySetting.DontShow;
			MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
			mustRefreshMainForm = 1;
		}
		Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
		RefreshOptions();
	}

	private void method_22(object sender, EventArgs e)
	{
		bool num = gamePreferences_0.AllowPowerPlanSwitch != ((CheckBox)CB_AllowPowerScemeSwitch).Checked;
		gamePreferences_0.AllowPowerPlanSwitch = ((CheckBox)CB_AllowPowerScemeSwitch).Checked;
		int mustRefreshMainForm;
		if (!num)
		{
			mustRefreshMainForm = 1;
		}
		else if (!gamePreferences_0.AllowPowerPlanSwitch)
		{
			PowerManagement.ResetToOriginalSetting();
			mustRefreshMainForm = 1;
		}
		else
		{
			PowerManagement.SwitchToHighPerformance();
			mustRefreshMainForm = 1;
		}
		Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
		RefreshOptions();
	}

	private void method_23(object sender, EventArgs e)
	{
		gamePreferences_0.UseAutosave = ((CheckBox)CB_UseAutosave).Checked;
		Client.MustRefreshMainForm = true;
		RefreshOptions();
	}

	private void method_24(object sender, EventArgs e)
	{
		gamePreferences_0.DrawOutlines = ((CheckBox)CB_DrawOutlines).Checked;
		Client.MustRefreshMainForm = true;
		RefreshOptions();
	}

	private void method_25(object sender, EventArgs e)
	{
		gamePreferences_0.ShowGhostedGroupMembers = (Game.GamePreferences.GhostedGroupMembersVisibilitySetting)((ComboBox)CP_ShowGhostedGroupMembers).SelectedIndex;
		Client.MustRefreshMainForm = true;
		RefreshOptions();
	}

	private void method_26(object sender, EventArgs e)
	{
		gamePreferences_0.LogDebugInfoToFile = ((CheckBox)CB_LogDebugInfoToFile).Checked;
	}

	private void method_27(object sender, EventArgs e)
	{
		gamePreferences_0.DetectStuckUnitPulses = ((CheckBox)DetectStuckUnitPulsesCheckBox).Checked;
		method_31();
	}

	private void method_28(object sender, EventArgs e)
	{
		((Control)DetectStuckUnitPulsesSettingsPanel).Visible = ((CheckBox)DetectStuckUnitPulsesCheckBox).Checked;
	}

	private void method_29(object sender, EventArgs e)
	{
		gamePreferences_0.PauseOnDetectedStuckUnitPulse = ((CheckBox)PauseOnDetectedStuckUnitPulseCheckBox).Checked;
		method_31();
	}

	private void method_30(object sender, EventArgs e)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		gamePreferences_0.SaveScenarioCopyOnDetectedStuckUnitPulse = ((CheckBox)SaveScenarioCopyOnDetectedStuckUnitPulseCheckBox).Checked;
		if (gamePreferences_0.DetectStuckUnitPulses && gamePreferences_0.SaveScenarioCopyOnDetectedStuckUnitPulse)
		{
			DarkMessageBox.ShowWarning("This option heavily affects performance, please enable only if you know what youa re doing and actually need it", "");
		}
		method_31();
	}

	private void method_31()
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		if (gamePreferences_0.DetectStuckUnitPulses && !gamePreferences_0.PauseOnDetectedStuckUnitPulse && gamePreferences_0.SaveScenarioCopyOnDetectedStuckUnitPulse)
		{
			DarkMessageBox.ShowWarning("Stuck unit pulses might not recover right away, please be aware that having the pause option OFF and the save option ON might cause save spam of scerio copies", "");
		}
	}

	private void method_32(object object_0)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		if (gamePreferences_0 == null)
		{
			return;
		}
		if (!string.IsNullOrEmpty(StuckUnitPulseThresholdMillisecondsTextBox.Text))
		{
			if (!int.TryParse(StuckUnitPulseThresholdMillisecondsTextBox.Text, out var result))
			{
				DarkMessageBox.ShowWarning("Inserted value for stuck pulse detection threshold is not valid", "");
			}
			else
			{
				gamePreferences_0.StuckUnitPulseThresholdMilliseconds = result;
			}
		}
		else
		{
			gamePreferences_0.StuckUnitPulseThresholdMilliseconds = 0;
		}
	}

	private void method_33(object sender, EventArgs e)
	{
		MyProject.Forms.MainForm.ToggleMessageLogInSeparateWindow();
	}

	private void method_34(object sender, EventArgs e)
	{
		gamePreferences_0.ShowAltitudeInFeet = ((CheckBox)CB_AltitudeInFeet).Checked;
	}

	private void method_35(object sender, EventArgs e)
	{
		gamePreferences_0.ShowUSUnitsForEditCargo = ((CheckBox)CB_CargoShowUSUnits).Checked;
		if (((Control)MyProject.Forms.EditCargoV2).Visible)
		{
			MyProject.Forms.EditCargoV2.RefreshForm();
		}
		if (((Control)MyProject.Forms.EditCargoContainer).Visible)
		{
			MyProject.Forms.EditCargoContainer.RefreshForm();
		}
	}

	private void method_36(object sender, EventArgs e)
	{
		gamePreferences_0.ZoomOnCursor = ((CheckBox)CB_ZoomOnCursor).Checked;
	}

	private void method_37(object sender, EventArgs e)
	{
		gamePreferences_0.UnitStatusImage = ((CheckBox)CB_UnitStatusImage).Checked;
	}

	private void method_38(object sender, EventArgs e)
	{
		gamePreferences_0.SonobuoyVisibility = (Game.GamePreferences.SonobuoyVisibilitySetting)((ComboBox)CB_SonobuoyVisibility).SelectedIndex;
		MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
		Client.MustRefreshMainForm = true;
	}

	private void method_39(object sender, EventArgs e)
	{
		if (TileCache.theVectorTileSource == null)
		{
			TileCache.InstantiateVectorTileSource();
		}
		string path = Directory.GetFiles(Client.OSMstylesFolder)[((ComboBox)CB_OSMstyle).SelectedIndex];
		TileCache.theVectorTileSource.Style = GlMapStyle.FromFile(path);
		Client.CurrentMapProfile.SelectedVectorMapStyle = Path.GetFileName(path);
		MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
		Main.Instance.ClearTiles();
		Client.MustRefreshMainForm = true;
	}

	private void method_40(object sender, EventArgs e)
	{
		gamePreferences_0.RefPointVisibility = (Game.GamePreferences.RefPointVisibilitySetting)((ComboBox)CB_RefPointVisibility).SelectedIndex;
		MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
		Client.MustRefreshMainForm = true;
	}

	private void method_41(object sender, EventArgs e)
	{
		gamePreferences_0.MapCursorBox = (Game.GamePreferences.MapCursorBoxVisibilitySetting)((ComboBox)CB_MapCursorBox).SelectedIndex;
	}

	private void method_42(object sender, EventArgs e)
	{
		gamePreferences_0.MapSymbolsSet = (Game.GamePreferences.MapSymbolsSetting)((ComboBox)CB_MapSymbols).SelectedIndex;
		Client.CacheMapUnitSymbols();
	}

	private void method_43(object sender, EventArgs e)
	{
		gamePreferences_0.ShowPlottedPaths = (Game.GamePreferences.PlottedPathsVisibilitySetting)((ComboBox)CP_ShowPlottedPaths).SelectedIndex;
		MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
		Client.MustRefreshMainForm = true;
	}

	private void method_44(object sender, EventArgs e)
	{
		gamePreferences_0.ShowDiagnostics = ((CheckBox)CB_ShowDiagnostics).Checked;
	}

	private void method_45(object sender, EventArgs e)
	{
		gamePreferences_0.ShowFlightPlans_Airborne = (Game.GamePreferences.FlightPlansVisibilitySetting_Airborne)((ComboBox)CP_ShowFlightPlans_Airborne).SelectedIndex;
		MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
		Client.MustRefreshMainForm = true;
	}

	private void method_46(object sender, EventArgs e)
	{
		gamePreferences_0.ShowFlightPlans_Planned = (Game.GamePreferences.FlightPlansVisibilitySetting_Planned)((ComboBox)CP_ShowFlightPlans_Planned).SelectedIndex;
		Client.MustRefreshMainForm = true;
	}

	private void method_47(object sender, EventArgs e)
	{
		gamePreferences_0.ShowAU_Behaviour_Bark = (Game.GamePreferences.Unit_Behaviour_Bark)((ComboBox)CP_ShowAU_Behaviour_Bark).SelectedIndex;
		MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
		Client.MustRefreshMainForm = true;
	}

	private void method_48(object sender, EventArgs e)
	{
		gamePreferences_0.GameSounds = ((CheckBox)CB_Sounds).Checked;
	}

	private void method_49(object sender, EventArgs e)
	{
		gamePreferences_0.GameMusic = ((CheckBox)CB_Music).Checked;
		if (!gamePreferences_0.GameMusic)
		{
			Sound.MusicHandler.StopPlayingMusic();
		}
		else
		{
			Sound.StartMusic();
		}
	}

	private void method_50(object sender, EventArgs e)
	{
		Sound.MusicHandler.Volume = TB_MusicVolumeBar.Value;
	}

	private void method_51(object sender, EventArgs e)
	{
		Sound.SoundEffectsHandler.Volume = TB_SFXVolumeBar.Value;
	}

	private void method_52(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex != -1 && e.ColumnIndex >= 2)
		{
			DataGridViewRow val = ((DataGridView)DataGridView1).Rows[e.RowIndex];
			val.Cells[e.ColumnIndex].Value = !Conversions.ToBoolean(val.Cells[e.ColumnIndex].Value);
			string value = Conversions.ToString(val.Cells[0].Value);
			LoggedMessage.MessageType key = (LoggedMessage.MessageType)Conversions.ToByte(Enum.Parse(typeof(LoggedMessage.MessageType), value, ignoreCase: true));
			LoggedMessage.MessageSettings messageSettings = SimConfiguration.DefaultGamePreferences.MessageLogSettings[key];
			messageSettings.ShowOnMessageLog = Conversions.ToBoolean(val.Cells[2].Value);
			messageSettings.PopUp = Conversions.ToBoolean(val.Cells[3].Value);
			messageSettings.ShowBaloon = Conversions.ToBoolean(val.Cells[4].Value);
			messageSettings.bool_0 = Conversions.ToBoolean(val.Cells[5].Value);
		}
	}

	private void method_53(object sender, EventArgs e)
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Invalid comparison between Unknown and I4
		((FileDialog)OpenFileDialog1).InitialDirectory = Application.StartupPath;
		((FileDialog)OpenFileDialog1).Title = "Please locate the Tacview executable:";
		((FileDialog)OpenFileDialog1).DefaultExt = "*.exe";
		((FileDialog)OpenFileDialog1).FileName = "*.exe";
		if ((int)((CommonDialog)OpenFileDialog1).ShowDialog() == 1)
		{
			SimConfiguration.DefaultGamePreferences.TacviewExePath = ((FileDialog)OpenFileDialog1).FileName;
			TB_TacviewPath.Text = ((FileDialog)OpenFileDialog1).FileName;
		}
	}

	private void method_54(object sender, EventArgs e)
	{
		gamePreferences_0.UsePersonalMapProfile = ((CheckBox)CB_UsePersonalMapProfile).Checked;
		if (gamePreferences_0.UsePersonalMapProfile && gamePreferences_0.PersonalMapProfile == null)
		{
			gamePreferences_0.PersonalMapProfile = Client.CurrentMapProfile;
		}
		MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
		MyProject.Forms.MapSettings.RefreshMapSettings();
	}

	private void method_55(object sender, EventArgs e)
	{
		gamePreferences_0.PersonalMapProfile = Client.CurrentMapProfile;
	}

	private void method_56(object sender, EventArgs e)
	{
		Client.CurrentMapProfile.ColorDatablocks = ((CheckBox)CB_ColorDatablocks).Checked;
		Client.MustRefreshMainForm = true;
		MyProject.Forms.MapSettings.RefreshMapSettings();
	}

	private void method_57(object sender, EventArgs e)
	{
		gamePreferences_0.GroundUnitsSpeedUnit = (Game.GamePreferences.SpeedUnitSetting)((ComboBox)Combo_GroundSpeedUnit).SelectedIndex;
		Client.MustRefreshMainForm = true;
	}

	private void method_58(object sender, EventArgs e)
	{
		gamePreferences_0.PauseOnAirDockOps = (SimConfiguration.WindowPauseBehaviour)((ComboBox)CB_AirDockPauseBehaviour).SelectedIndex;
	}

	private void method_59(object sender, EventArgs e)
	{
		gamePreferences_0.PauseOnDBView = (SimConfiguration.WindowPauseBehaviour)((ComboBox)CB_DVViewerPauseBehaviour).SelectedIndex;
	}

	private void method_60(object sender, EventArgs e)
	{
		int mustRefreshMainForm;
		if (((ComboBox)Combo_CoordinateUnit).SelectedItem == null)
		{
			mustRefreshMainForm = 1;
		}
		else
		{
			CoordinateComboMember coordinateComboMember = (CoordinateComboMember)((ComboBox)Combo_CoordinateUnit).SelectedItem;
			gamePreferences_0.GeoCoordinateType = coordinateComboMember.CoordType;
			mustRefreshMainForm = 1;
		}
		Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
	}

	private void method_61(object sender, EventArgs e)
	{
		gamePreferences_0.RMB_MoveOrder_Enabled = ((CheckBox)CB_RMB_MoveOrder).Checked;
		Client.MustRefreshMainForm = true;
	}

	private void method_62(object sender, EventArgs e)
	{
		gamePreferences_0.SlugTrail_Use = ((CheckBox)CB_SlugTrail_UseSlugTrail).Checked;
	}

	private void method_63(object sender, EventArgs e)
	{
		gamePreferences_0.SlugTrail_Friendly = ((CheckBox)CB_SlugTrail_Friendly).Checked;
	}

	private void method_64(object sender, EventArgs e)
	{
		gamePreferences_0.SlugTrail_Hostile = ((CheckBox)CB_SlugTrail_Hostile).Checked;
	}

	private void method_65(object sender, EventArgs e)
	{
		gamePreferences_0.SlugTrail_Unfriendly = ((CheckBox)CB_SlugTrail_Unfriendly).Checked;
	}

	private void method_66(object sender, EventArgs e)
	{
		gamePreferences_0.SlugTrail_UnKnown = ((CheckBox)CB_SlugTrail_Unknown).Checked;
	}

	private void method_67(object sender, EventArgs e)
	{
		gamePreferences_0.SlugTrail_Neutral = ((CheckBox)CB_SlugTrail_Neutral).Checked;
	}

	private void method_68(object sender, EventArgs e)
	{
		gamePreferences_0.SlugTrail_OwnAndAllied = ((CheckBox)CB_SlugTrail_Own).Checked;
	}

	private void method_69(object sender, EventArgs e)
	{
		gamePreferences_0.SlugTrailTimeFrequency = (SlugTrailTimeFrequency)((ComboBox)Combo_SlugTrailFreq).SelectedIndex;
	}

	private void method_70(object sender, EventArgs e)
	{
		gamePreferences_0.SlugTrail_LifeTime = Convert.ToInt32(Num_SlugTrailLifetime.Value);
	}

	private void method_71(object sender, EventArgs e)
	{
		gamePreferences_0.SlugTrail_LifeTime = Convert.ToInt32(Num_SlugTrailLifetime.Value);
	}

	private void method_72(object sender, EventArgs e)
	{
		Client.CurrentMapProfile.ShowDynamicNoiseSignature = ((CheckBox)ChkASWNoise).Checked;
		MyProject.Forms.MapSettings.RefreshMapSettings();
	}

	private void method_73(object sender, EventArgs e)
	{
		Client.CurrentSide.PerUnitSlugtrail.Clear();
	}

	private void method_74(TrackBar trackBar_0, int int_0)
	{
		trackBar_0.Value = Math.Min(trackBar_0.Maximum, Math.Max(trackBar_0.Minimum, int_0));
	}

	private void method_75(object sender, EventArgs e)
	{
		int num = gamePreferences_0.GroundUnitZoom - TB_GrounUnit_Zoom.Value;
		gamePreferences_0.GroundUnitZoom = TB_GrounUnit_Zoom.Value;
		method_74(TB_Diamond_Zoom, gamePreferences_0.DiamondZoom - num);
		method_74(TB_Rectangle_Zoom, gamePreferences_0.RectangleZoom - num);
		method_74(TB_Flower_Zoom, gamePreferences_0.FlowerZoom - num);
		gamePreferences_0.DiamondZoom = TB_Diamond_Zoom.Value;
		gamePreferences_0.RectangleZoom = TB_Rectangle_Zoom.Value;
		gamePreferences_0.FlowerZoom = TB_Flower_Zoom.Value;
		MyProject.Forms.MapSettings.RefreshMapSettings();
		Client.MustRefreshMainForm = true;
	}

	private void method_76(object sender, EventArgs e)
	{
		gamePreferences_0.DiamondZoom = TB_Diamond_Zoom.Value;
		MyProject.Forms.MapSettings.RefreshMapSettings();
		Client.MustRefreshMainForm = true;
	}

	private void method_77(object sender, EventArgs e)
	{
		gamePreferences_0.RectangleZoom = TB_Rectangle_Zoom.Value;
		MyProject.Forms.MapSettings.RefreshMapSettings();
		Client.MustRefreshMainForm = true;
	}

	private void method_78(object sender, EventArgs e)
	{
		gamePreferences_0.FlowerZoom = TB_Flower_Zoom.Value;
		MyProject.Forms.MapSettings.RefreshMapSettings();
		Client.MustRefreshMainForm = true;
	}

	private void method_79(object sender, EventArgs e)
	{
		gamePreferences_0.DrawOutlines = ((CheckBox)CB_DrawOutlines).Checked;
		MyProject.Forms.MapSettings.RefreshMapSettings();
	}

	private void method_80(object sender, EventArgs e)
	{
		if (!bool_5 && gamePreferences_0 != null)
		{
			gamePreferences_0.AltitudeRender.Unrectified_ForOptionsUIAndIni.UnitsAtAltitude = ((CheckBox)CB_DrawUnitsAtTrueAltitude).Checked;
			Main.Instance.requestMeshRebuild(gamePreferences_0.AltitudeRender.Show3DTerrain, gamePreferences_0.AltitudeRender.VerticalScaling);
		}
		((Control)AltitudeAndTerrainOptionsPanel).Enabled = ((CheckBox)CB_DrawUnitsAtTrueAltitude).Checked;
	}

	private void method_81(object sender, EventArgs e)
	{
		if (!bool_5 && gamePreferences_0 != null)
		{
			gamePreferences_0.AltitudeRender.Unrectified_ForOptionsUIAndIni.Show3DTerrain = ((CheckBox)CB_Show3DTerrain).Checked;
			Main.Instance.requestMeshRebuild(gamePreferences_0.AltitudeRender.Show3DTerrain, gamePreferences_0.AltitudeRender.VerticalScaling);
		}
		((Control)TerrainRenderingOptionsPanel).Enabled = ((CheckBox)CB_Show3DTerrain).Checked;
		((Control)AdditionalAltitudeOptionsPanel).Enabled = !((CheckBox)CB_Show3DTerrain).Checked;
	}

	private void method_82(object sender, EventArgs e)
	{
		gamePreferences_0.AltitudeRender.Unrectified_ForOptionsUIAndIni.ShowGroundUnitsAtSurface = ((CheckBox)CB_TrueAltitudeRenderForceGroundUnitsAtSurface).Checked;
	}

	private void method_83(object sender, EventArgs e)
	{
		gamePreferences_0.AltitudeRender.Unrectified_ForOptionsUIAndIni.ShowSubsurfaceUnitsAtSurface = ((CheckBox)CB_TrueAltitudeRenderForceSubsurfaceUnitsAtSurface).Checked;
	}

	private void method_84(object sender, EventArgs e)
	{
		gamePreferences_0.AltitudeRender.Unrectified_ForOptionsUIAndIni.UseGroundInsteadOfSurfaceAsRenderReference = ((CheckBox)CB_TrueAltitudeRenderFromGroundInsteadOfSurface).Checked;
	}

	private void method_85(object sender, EventArgs e)
	{
		ushort num = (ushort)VerticalScalingMultiplierTrackBar.Value;
		((TextBox)verticalScalingTextBox).Text = "Vertical scaling: x" + num;
	}

	private void method_86(object sender, EventArgs e)
	{
		gamePreferences_0.AltitudeRender.Unrectified_ForOptionsUIAndIni.VerticalScaling = (ushort)VerticalScalingMultiplierTrackBar.Value;
		Main.Instance.requestMeshRebuild(gamePreferences_0.AltitudeRender.Show3DTerrain, gamePreferences_0.AltitudeRender.VerticalScaling);
	}

	private void method_87(object sender, EventArgs e)
	{
		gamePreferences_0.AggressiveTileManagement = !((CheckBox)CB_AggressiveTileManagement).Checked;
		Main.AggressiveTileManagement = gamePreferences_0.AggressiveTileManagement;
		Client.MustRefreshMainForm = true;
	}

	private void method_88(object sender, EventArgs e)
	{
		gamePreferences_0.AllowSmartRPPlacement = ((CheckBox)CB_SmartRPPlacement).Checked;
	}

	private void method_89(object sender, EventArgs e)
	{
		gamePreferences_0.IconZoom = TB_Icon_Zoom.Value;
		MyProject.Forms.MapSettings.RefreshMapSettings();
		Client.MustRefreshMainForm = true;
	}

	static Options()
	{
		Class72.smethod_20();
	}
}
