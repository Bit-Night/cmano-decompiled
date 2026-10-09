using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class MapSettings : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("CP_ShowAU_Behaviour_Bark")]
	private DarkUIComboBox _CP_ShowAU_Behaviour_Bark;

	[CompilerGenerated]
	[AccessedThroughProperty("CP_ShowFlightPlans_Planned")]
	private DarkUIComboBox _CP_ShowFlightPlans_Planned;

	[AccessedThroughProperty("CP_ShowFlightPlans_Airborne")]
	[CompilerGenerated]
	private DarkUIComboBox _CP_ShowFlightPlans_Airborne;

	[AccessedThroughProperty("CP_ShowPlottedPaths")]
	[CompilerGenerated]
	private DarkUIComboBox _CP_ShowPlottedPaths;

	[AccessedThroughProperty("CP_ShowGhostedGroupMembers")]
	[CompilerGenerated]
	private DarkUIComboBox _CP_ShowGhostedGroupMembers;

	[AccessedThroughProperty("CB_MapSymbols")]
	[CompilerGenerated]
	private DarkUIComboBox _CB_MapSymbols;

	[AccessedThroughProperty("CB_MapCursorBox")]
	[CompilerGenerated]
	private DarkUIComboBox _CB_MapCursorBox;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_RefPointVisibility")]
	private DarkUIComboBox _CB_RefPointVisibility;

	[AccessedThroughProperty("CB_SonobuoyVisibility")]
	[CompilerGenerated]
	private DarkUIComboBox _CB_SonobuoyVisibility;

	[AccessedThroughProperty("AirSensorsCheckBox")]
	[CompilerGenerated]
	private DarkCheckBox _AirSensorsCheckBox;

	[AccessedThroughProperty("SurfaceSensorsCheckBox")]
	[CompilerGenerated]
	private DarkCheckBox _SurfaceSensorsCheckBox;

	[CompilerGenerated]
	[AccessedThroughProperty("UnderwaterSensorsCheckBox")]
	private DarkCheckBox _UnderwaterSensorsCheckBox;

	[CompilerGenerated]
	[AccessedThroughProperty("AircraftRangeCheckBox")]
	private DarkCheckBox _AircraftRangeCheckBox;

	[AccessedThroughProperty("UnderwaterWeaponsCheckBox")]
	[CompilerGenerated]
	private DarkCheckBox _UnderwaterWeaponsCheckBox;

	[CompilerGenerated]
	[AccessedThroughProperty("LandWeaponsCheckBox")]
	private DarkCheckBox _LandWeaponsCheckBox;

	[AccessedThroughProperty("SurfaceWeaponsCheckBox")]
	[CompilerGenerated]
	private DarkCheckBox _SurfaceWeaponsCheckBox;

	[AccessedThroughProperty("AirWeaponsCheckBox")]
	[CompilerGenerated]
	private DarkCheckBox _AirWeaponsCheckBox;

	[AccessedThroughProperty("CB_ShowRangeIndicators")]
	[CompilerGenerated]
	private DarkUIComboBox _CB_ShowRangeIndicators;

	[CompilerGenerated]
	[AccessedThroughProperty("MergeRangeSymbolsCheckBox")]
	private DarkCheckBox _MergeRangeSymbolsCheckBox;

	[CompilerGenerated]
	[AccessedThroughProperty("ShowNonFriendlyRangeSymbolsCheckBox")]
	private DarkCheckBox _ShowNonFriendlyRangeSymbolsCheckBox;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_DisplayDatablocks")]
	private DarkUIComboBox EvwHytyiuwh;

	[AccessedThroughProperty("CB_DisplayDatablockType")]
	[CompilerGenerated]
	private DarkUIComboBox _CB_DisplayDatablockType;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_ShowWakeAndCavitation")]
	private DarkUIComboBox _CB_ShowWakeAndCavitation;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_ShowContrail")]
	private DarkUIComboBox _CB_ShowContrail;

	[CompilerGenerated]
	[AccessedThroughProperty("ShowDynamicNoiseCheckBox")]
	private DarkCheckBox _ShowDynamicNoiseCheckBox;

	[CompilerGenerated]
	[AccessedThroughProperty("ColoredDatablocksCheckBox")]
	private DarkCheckBox _ColoredDatablocksCheckBox;

	[CompilerGenerated]
	[AccessedThroughProperty("ShowOutlinesCheckBox")]
	private DarkCheckBox _ShowOutlinesCheckBox;

	[AccessedThroughProperty("CB_GroupUnitView")]
	[CompilerGenerated]
	private DarkUIComboBox _CB_GroupUnitView;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_Flower_Zoom")]
	private TrackBar _TB_Flower_Zoom;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_GroundUnit_Zoom")]
	private TrackBar _TB_GroundUnit_Zoom;

	[AccessedThroughProperty("TB_Rectangle_Zoom")]
	[CompilerGenerated]
	private TrackBar _TB_Rectangle_Zoom;

	[AccessedThroughProperty("RectangleShapedIconZoomLabel")]
	[CompilerGenerated]
	private DarkLabel mstHyCsvhYe;

	[AccessedThroughProperty("TB_Diamond_Zoom")]
	[CompilerGenerated]
	private TrackBar _TB_Diamond_Zoom;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_MissionAreaCourseDisplay")]
	private DarkUIComboBox _CB_MissionAreaCourseDisplay;

	[CompilerGenerated]
	[AccessedThroughProperty("ColorDialog_Shade")]
	private ColorDialog colorDialog_0;

	[AccessedThroughProperty("CB_IlluminationVectors")]
	[CompilerGenerated]
	private DarkUIComboBox _CB_IlluminationVectors;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_ContactEmissionsDisplay")]
	private DarkUIComboBox _CB_ContactEmissionsDisplay;

	[AccessedThroughProperty("CB_Datalinks")]
	[CompilerGenerated]
	private DarkUIComboBox _CB_Datalinks;

	[AccessedThroughProperty("CB_TargetingVectors")]
	[CompilerGenerated]
	private DarkUIComboBox _CB_TargetingVectors;

	[AccessedThroughProperty("CB_DisplayEmissionsFor")]
	[CompilerGenerated]
	private DarkUIComboBox _CB_DisplayEmissionsFor;

	[AccessedThroughProperty("COMMSRangeCheckBox")]
	[CompilerGenerated]
	private DarkCheckBox darkCheckBox_0;

	[AccessedThroughProperty("COMMSRangeColor")]
	[CompilerGenerated]
	private PictureBox pictureBox_0;

	[AccessedThroughProperty("SetPersonalMapProfileButton")]
	[CompilerGenerated]
	private DarkUIButton _SetPersonalMapProfileButton;

	[CompilerGenerated]
	[AccessedThroughProperty("UsePersonalMapProfileCheckBox")]
	private DarkCheckBox _UsePersonalMapProfileCheckBox;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkLabel1")]
	private DarkLabel zGaHyhqNmcj;

	[AccessedThroughProperty("TB_GeneralIConZoom")]
	[CompilerGenerated]
	private TrackBar _TB_GeneralIConZoom;

	private Game.GamePreferences gamePreferences_0;

	private bool bool_2;

	[CompilerGenerated]
	private bool bool_3;

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
			EventHandler eventHandler = method_26;
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
			EventHandler eventHandler = method_40;
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
			EventHandler eventHandler = method_39;
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
			EventHandler eventHandler = method_38;
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
			EventHandler eventHandler = method_19;
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
			EventHandler eventHandler = method_20;
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
			EventHandler eventHandler = method_37;
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
			EventHandler eventHandler = method_36;
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
			EventHandler eventHandler = method_25;
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

	internal virtual DarkCheckBox AirSensorsCheckBox
	{
		[CompilerGenerated]
		get
		{
			return _AirSensorsCheckBox;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_7;
			EventHandler eventHandler2 = method_53;
			DarkCheckBox darkCheckBox = _AirSensorsCheckBox;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler2;
			}
			_AirSensorsCheckBox = value;
			darkCheckBox = _AirSensorsCheckBox;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler2;
			}
		}
	}

	internal virtual DarkCheckBox SurfaceSensorsCheckBox
	{
		[CompilerGenerated]
		get
		{
			return _SurfaceSensorsCheckBox;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_8;
			EventHandler eventHandler2 = method_54;
			DarkCheckBox darkCheckBox = _SurfaceSensorsCheckBox;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler2;
			}
			_SurfaceSensorsCheckBox = value;
			darkCheckBox = _SurfaceSensorsCheckBox;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler2;
			}
		}
	}

	internal virtual DarkCheckBox UnderwaterSensorsCheckBox
	{
		[CompilerGenerated]
		get
		{
			return _UnderwaterSensorsCheckBox;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_9;
			EventHandler eventHandler2 = method_57;
			DarkCheckBox darkCheckBox = _UnderwaterSensorsCheckBox;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler2;
			}
			_UnderwaterSensorsCheckBox = value;
			darkCheckBox = _UnderwaterSensorsCheckBox;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler2;
			}
		}
	}

	internal virtual DarkCheckBox AircraftRangeCheckBox
	{
		[CompilerGenerated]
		get
		{
			return _AircraftRangeCheckBox;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_14;
			EventHandler eventHandler2 = method_66;
			DarkCheckBox darkCheckBox = _AircraftRangeCheckBox;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler2;
			}
			_AircraftRangeCheckBox = value;
			darkCheckBox = _AircraftRangeCheckBox;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler2;
			}
		}
	}

	internal virtual DarkCheckBox UnderwaterWeaponsCheckBox
	{
		[CompilerGenerated]
		get
		{
			return _UnderwaterWeaponsCheckBox;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_13;
			EventHandler eventHandler2 = method_65;
			DarkCheckBox darkCheckBox = _UnderwaterWeaponsCheckBox;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler2;
			}
			_UnderwaterWeaponsCheckBox = value;
			darkCheckBox = _UnderwaterWeaponsCheckBox;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler2;
			}
		}
	}

	internal virtual DarkCheckBox LandWeaponsCheckBox
	{
		[CompilerGenerated]
		get
		{
			return _LandWeaponsCheckBox;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_12;
			DarkCheckBox darkCheckBox = _LandWeaponsCheckBox;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_LandWeaponsCheckBox = value;
			darkCheckBox = _LandWeaponsCheckBox;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox SurfaceWeaponsCheckBox
	{
		[CompilerGenerated]
		get
		{
			return _SurfaceWeaponsCheckBox;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_11;
			EventHandler eventHandler2 = method_62;
			DarkCheckBox darkCheckBox = _SurfaceWeaponsCheckBox;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler2;
			}
			_SurfaceWeaponsCheckBox = value;
			darkCheckBox = _SurfaceWeaponsCheckBox;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler2;
			}
		}
	}

	internal virtual DarkCheckBox AirWeaponsCheckBox
	{
		[CompilerGenerated]
		get
		{
			return _AirWeaponsCheckBox;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_10;
			EventHandler eventHandler2 = method_58;
			DarkCheckBox darkCheckBox = _AirWeaponsCheckBox;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler2;
			}
			_AirWeaponsCheckBox = value;
			darkCheckBox = _AirWeaponsCheckBox;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler2;
			}
		}
	}

	internal virtual DarkUIComboBox CB_ShowRangeIndicators
	{
		[CompilerGenerated]
		get
		{
			return _CB_ShowRangeIndicators;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_5;
			DarkUIComboBox darkUIComboBox = _CB_ShowRangeIndicators;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_ShowRangeIndicators = value;
			darkUIComboBox = _CB_ShowRangeIndicators;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox MergeRangeSymbolsCheckBox
	{
		[CompilerGenerated]
		get
		{
			return _MergeRangeSymbolsCheckBox;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_16;
			DarkCheckBox darkCheckBox = _MergeRangeSymbolsCheckBox;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_MergeRangeSymbolsCheckBox = value;
			darkCheckBox = _MergeRangeSymbolsCheckBox;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox ShowNonFriendlyRangeSymbolsCheckBox
	{
		[CompilerGenerated]
		get
		{
			return _ShowNonFriendlyRangeSymbolsCheckBox;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_15;
			DarkCheckBox darkCheckBox = _ShowNonFriendlyRangeSymbolsCheckBox;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_ShowNonFriendlyRangeSymbolsCheckBox = value;
			darkCheckBox = _ShowNonFriendlyRangeSymbolsCheckBox;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("ShowRangeIndicatorsLabel")]
	internal virtual DarkLabel ShowRangeIndicatorsLabel { get; set; }

	internal virtual DarkUIComboBox CB_DisplayDatablocks
	{
		[CompilerGenerated]
		get
		{
			return EvwHytyiuwh;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_21;
			DarkUIComboBox darkUIComboBox = EvwHytyiuwh;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			EvwHytyiuwh = value;
			darkUIComboBox = EvwHytyiuwh;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	internal virtual DarkUIComboBox CB_DisplayDatablockType
	{
		[CompilerGenerated]
		get
		{
			return _CB_DisplayDatablockType;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_22;
			DarkUIComboBox darkUIComboBox = _CB_DisplayDatablockType;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_DisplayDatablockType = value;
			darkUIComboBox = _CB_DisplayDatablockType;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	internal virtual DarkUIComboBox CB_ShowWakeAndCavitation
	{
		[CompilerGenerated]
		get
		{
			return _CB_ShowWakeAndCavitation;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_23;
			DarkUIComboBox darkUIComboBox = _CB_ShowWakeAndCavitation;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_ShowWakeAndCavitation = value;
			darkUIComboBox = _CB_ShowWakeAndCavitation;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	internal virtual DarkUIComboBox CB_ShowContrail
	{
		[CompilerGenerated]
		get
		{
			return _CB_ShowContrail;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_24;
			DarkUIComboBox darkUIComboBox = _CB_ShowContrail;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_ShowContrail = value;
			darkUIComboBox = _CB_ShowContrail;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox ShowDynamicNoiseCheckBox
	{
		[CompilerGenerated]
		get
		{
			return _ShowDynamicNoiseCheckBox;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_29;
			DarkCheckBox darkCheckBox = _ShowDynamicNoiseCheckBox;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_ShowDynamicNoiseCheckBox = value;
			darkCheckBox = _ShowDynamicNoiseCheckBox;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox ColoredDatablocksCheckBox
	{
		[CompilerGenerated]
		get
		{
			return _ColoredDatablocksCheckBox;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_28;
			DarkCheckBox darkCheckBox = _ColoredDatablocksCheckBox;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_ColoredDatablocksCheckBox = value;
			darkCheckBox = _ColoredDatablocksCheckBox;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox ShowOutlinesCheckBox
	{
		[CompilerGenerated]
		get
		{
			return _ShowOutlinesCheckBox;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_27;
			DarkCheckBox darkCheckBox = _ShowOutlinesCheckBox;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_ShowOutlinesCheckBox = value;
			darkCheckBox = _ShowOutlinesCheckBox;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIComboBox CB_GroupUnitView
	{
		[CompilerGenerated]
		get
		{
			return _CB_GroupUnitView;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_18;
			DarkUIComboBox darkUIComboBox = _CB_GroupUnitView;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_GroupUnitView = value;
			darkUIComboBox = _CB_GroupUnitView;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("GroundUnitZoomBox")]
	internal virtual DarkGroupBox GroundUnitZoomBox { get; set; }

	[field: AccessedThroughProperty("TableLayoutPanel1")]
	internal virtual TableLayoutPanel TableLayoutPanel1 { get; set; }

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
			EventHandler eventHandler = method_34;
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

	internal virtual TrackBar TB_GroundUnit_Zoom
	{
		[CompilerGenerated]
		get
		{
			return _TB_GroundUnit_Zoom;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_31;
			TrackBar val = _TB_GroundUnit_Zoom;
			if (val != null)
			{
				val.Scroll -= eventHandler;
			}
			_TB_GroundUnit_Zoom = value;
			val = _TB_GroundUnit_Zoom;
			if (val != null)
			{
				val.Scroll += eventHandler;
			}
		}
	}

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
			EventHandler eventHandler = method_33;
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

	internal virtual DarkLabel RectangleShapedIconZoomLabel
	{
		[CompilerGenerated]
		get
		{
			return mstHyCsvhYe;
		}
		[CompilerGenerated]
		set
		{
			mstHyCsvhYe = value;
		}
	}

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
			EventHandler eventHandler = method_32;
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

	[field: AccessedThroughProperty("lbl_GU_Zoom")]
	internal virtual DarkLabel lbl_GU_Zoom { get; set; }

	internal virtual DarkUIComboBox CB_MissionAreaCourseDisplay
	{
		[CompilerGenerated]
		get
		{
			return _CB_MissionAreaCourseDisplay;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_41;
			DarkUIComboBox darkUIComboBox = _CB_MissionAreaCourseDisplay;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_MissionAreaCourseDisplay = value;
			darkUIComboBox = _CB_MissionAreaCourseDisplay;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	internal virtual ColorDialog ColorDialog_Shade
	{
		[CompilerGenerated]
		get
		{
			return colorDialog_0;
		}
		[CompilerGenerated]
		set
		{
			colorDialog_0 = value;
		}
	}

	[field: AccessedThroughProperty("MapMarkerDisplayBox")]
	internal virtual DarkGroupBox MapMarkerDisplayBox { get; set; }

	[field: AccessedThroughProperty("SignalsDisplayBox")]
	internal virtual DarkGroupBox SignalsDisplayBox { get; set; }

	internal virtual DarkUIComboBox CB_IlluminationVectors
	{
		[CompilerGenerated]
		get
		{
			return _CB_IlluminationVectors;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_47;
			DarkUIComboBox darkUIComboBox = _CB_IlluminationVectors;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_IlluminationVectors = value;
			darkUIComboBox = _CB_IlluminationVectors;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	internal virtual DarkUIComboBox CB_ContactEmissionsDisplay
	{
		[CompilerGenerated]
		get
		{
			return _CB_ContactEmissionsDisplay;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_50;
			DarkUIComboBox darkUIComboBox = _CB_ContactEmissionsDisplay;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_ContactEmissionsDisplay = value;
			darkUIComboBox = _CB_ContactEmissionsDisplay;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	internal virtual DarkUIComboBox CB_Datalinks
	{
		[CompilerGenerated]
		get
		{
			return _CB_Datalinks;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_49;
			DarkUIComboBox darkUIComboBox = _CB_Datalinks;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_Datalinks = value;
			darkUIComboBox = _CB_Datalinks;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	internal virtual DarkUIComboBox CB_TargetingVectors
	{
		[CompilerGenerated]
		get
		{
			return _CB_TargetingVectors;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_48;
			DarkUIComboBox darkUIComboBox = _CB_TargetingVectors;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_TargetingVectors = value;
			darkUIComboBox = _CB_TargetingVectors;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	internal virtual DarkUIComboBox CB_DisplayEmissionsFor
	{
		[CompilerGenerated]
		get
		{
			return _CB_DisplayEmissionsFor;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_51;
			DarkUIComboBox darkUIComboBox = _CB_DisplayEmissionsFor;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_DisplayEmissionsFor = value;
			darkUIComboBox = _CB_DisplayEmissionsFor;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("LabelPlottedCourseColor")]
	internal virtual DarkLabel LabelPlottedCourseColor { get; set; }

	[field: AccessedThroughProperty("LabelSeaIceColor")]
	internal virtual DarkLabel LabelSeaIceColor { get; set; }

	[field: AccessedThroughProperty("LabelBorderColor")]
	internal virtual DarkLabel LabelBorderColor { get; set; }

	public virtual DarkCheckBox COMMSRangeCheckBox
	{
		[CompilerGenerated]
		get
		{
			return darkCheckBox_0;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_17;
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

	public virtual PictureBox COMMSRangeColor
	{
		[CompilerGenerated]
		get
		{
			return pictureBox_0;
		}
		[CompilerGenerated]
		set
		{
			pictureBox_0 = value;
		}
	}

	internal virtual DarkUIButton SetPersonalMapProfileButton
	{
		[CompilerGenerated]
		get
		{
			return _SetPersonalMapProfileButton;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_68;
			DarkUIButton darkUIButton = _SetPersonalMapProfileButton;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_SetPersonalMapProfileButton = value;
			darkUIButton = _SetPersonalMapProfileButton;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox UsePersonalMapProfileCheckBox
	{
		[CompilerGenerated]
		get
		{
			return _UsePersonalMapProfileCheckBox;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_67;
			DarkCheckBox darkCheckBox = _UsePersonalMapProfileCheckBox;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_UsePersonalMapProfileCheckBox = value;
			darkCheckBox = _UsePersonalMapProfileCheckBox;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DiamondShapedIconZoomLabel")]
	internal virtual DarkLabel DiamondShapedIconZoomLabel { get; set; }

	[field: AccessedThroughProperty("FlowerShapedIconZoomLabel")]
	internal virtual DarkLabel FlowerShapedIconZoomLabel { get; set; }

	internal virtual DarkLabel DarkLabel1
	{
		[CompilerGenerated]
		get
		{
			return zGaHyhqNmcj;
		}
		[CompilerGenerated]
		set
		{
			zGaHyhqNmcj = value;
		}
	}

	internal virtual TrackBar TB_GeneralIConZoom
	{
		[CompilerGenerated]
		get
		{
			return _TB_GeneralIConZoom;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_35;
			TrackBar val = _TB_GeneralIConZoom;
			if (val != null)
			{
				val.Scroll -= eventHandler;
			}
			_TB_GeneralIConZoom = value;
			val = _TB_GeneralIConZoom;
			if (val != null)
			{
				val.Scroll += eventHandler;
			}
		}
	}

	protected override bool RTMPEnabled
	{
		[CompilerGenerated]
		get
		{
			return bool_3;
		}
		[CompilerGenerated]
		set
		{
			bool_3 = value;
		}
	}

	public MapSettings()
	{
		((Form)this).Load += MapSettings_Load;
		gamePreferences_0 = SimConfiguration.DefaultGamePreferences;
		bool_2 = false;
		RTMPEnabled = true;
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
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Expected O, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Expected O, but got Unknown
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Expected O, but got Unknown
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected O, but got Unknown
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Expected O, but got Unknown
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Expected O, but got Unknown
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Expected O, but got Unknown
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Expected O, but got Unknown
		//IL_02db: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Expected O, but got Unknown
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Expected O, but got Unknown
		//IL_02e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f0: Expected O, but got Unknown
		//IL_02f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Expected O, but got Unknown
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0305: Expected O, but got Unknown
		//IL_0477: Unknown result type (might be due to invalid IL or missing references)
		//IL_0648: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0842: Unknown result type (might be due to invalid IL or missing references)
		//IL_088b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0895: Expected O, but got Unknown
		//IL_08f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_08fc: Expected O, but got Unknown
		//IL_095d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0967: Expected O, but got Unknown
		//IL_09c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d2: Expected O, but got Unknown
		//IL_0a33: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a3d: Expected O, but got Unknown
		//IL_0a9e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa8: Expected O, but got Unknown
		//IL_0b09: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b13: Expected O, but got Unknown
		//IL_0b74: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b7e: Expected O, but got Unknown
		//IL_0e31: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e3b: Expected O, but got Unknown
		//IL_100b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1015: Expected O, but got Unknown
		//IL_13f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_147b: Unknown result type (might be due to invalid IL or missing references)
		//IL_16d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1743: Unknown result type (might be due to invalid IL or missing references)
		//IL_174d: Expected O, but got Unknown
		//IL_179d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1805: Unknown result type (might be due to invalid IL or missing references)
		//IL_1880: Unknown result type (might be due to invalid IL or missing references)
		//IL_18f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1990: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a15: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a95: Expected O, but got Unknown
		//IL_1af0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b75: Unknown result type (might be due to invalid IL or missing references)
		//IL_1beb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bf5: Expected O, but got Unknown
		//IL_1c50: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cc6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cd0: Expected O, but got Unknown
		//IL_1d2b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1da1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dab: Expected O, but got Unknown
		//IL_1e03: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e88: Unknown result type (might be due to invalid IL or missing references)
		//IL_1efb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f05: Expected O, but got Unknown
		//IL_1f5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fd3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fdd: Expected O, but got Unknown
		//IL_203d: Unknown result type (might be due to invalid IL or missing references)
		//IL_20b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_20bd: Expected O, but got Unknown
		//IL_2115: Unknown result type (might be due to invalid IL or missing references)
		//IL_218b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2195: Expected O, but got Unknown
		//IL_21f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_22e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_25bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_2649: Unknown result type (might be due to invalid IL or missing references)
		//IL_26ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_26d8: Expected O, but got Unknown
		//IL_2795: Unknown result type (might be due to invalid IL or missing references)
		//IL_279f: Expected O, but got Unknown
		//IL_286f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2879: Expected O, but got Unknown
		//IL_2936: Unknown result type (might be due to invalid IL or missing references)
		//IL_2940: Expected O, but got Unknown
		//IL_29fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a07: Expected O, but got Unknown
		//IL_2b4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b58: Expected O, but got Unknown
		//IL_2c71: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c7b: Expected O, but got Unknown
		//IL_2c8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c97: Expected O, but got Unknown
		//IL_2ca9: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cb3: Expected O, but got Unknown
		//IL_2cc5: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ccf: Expected O, but got Unknown
		//IL_2ce1: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ceb: Expected O, but got Unknown
		//IL_2cfd: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d07: Expected O, but got Unknown
		//IL_2d19: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d23: Expected O, but got Unknown
		//IL_2d35: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d3f: Expected O, but got Unknown
		//IL_2d51: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d5b: Expected O, but got Unknown
		//IL_3151: Unknown result type (might be due to invalid IL or missing references)
		//IL_315b: Expected O, but got Unknown
		//IL_36c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_36cc: Expected O, but got Unknown
		//IL_378c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3796: Expected O, but got Unknown
		//IL_3853: Unknown result type (might be due to invalid IL or missing references)
		//IL_385d: Expected O, but got Unknown
		//IL_391a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3924: Expected O, but got Unknown
		//IL_39e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_39eb: Expected O, but got Unknown
		//IL_3ac1: Unknown result type (might be due to invalid IL or missing references)
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MapSettings));
		COMMSRangeCheckBox = new DarkCheckBox();
		COMMSRangeColor = new PictureBox();
		ShowRangeIndicatorsLabel = new DarkLabel();
		MergeRangeSymbolsCheckBox = new DarkCheckBox();
		ShowNonFriendlyRangeSymbolsCheckBox = new DarkCheckBox();
		CB_ShowRangeIndicators = new DarkUIComboBox();
		AircraftRangeCheckBox = new DarkCheckBox();
		UnderwaterWeaponsCheckBox = new DarkCheckBox();
		LandWeaponsCheckBox = new DarkCheckBox();
		SurfaceWeaponsCheckBox = new DarkCheckBox();
		AirWeaponsCheckBox = new DarkCheckBox();
		UnderwaterSensorsCheckBox = new DarkCheckBox();
		SurfaceSensorsCheckBox = new DarkCheckBox();
		AirSensorsCheckBox = new DarkCheckBox();
		CB_GroupUnitView = new DarkUIComboBox();
		ShowDynamicNoiseCheckBox = new DarkCheckBox();
		ColoredDatablocksCheckBox = new DarkCheckBox();
		ShowOutlinesCheckBox = new DarkCheckBox();
		CB_ShowContrail = new DarkUIComboBox();
		CP_ShowAU_Behaviour_Bark = new DarkUIComboBox();
		CB_ShowWakeAndCavitation = new DarkUIComboBox();
		CB_DisplayDatablockType = new DarkUIComboBox();
		CB_DisplayDatablocks = new DarkUIComboBox();
		CB_MapSymbols = new DarkUIComboBox();
		CP_ShowGhostedGroupMembers = new DarkUIComboBox();
		CB_SonobuoyVisibility = new DarkUIComboBox();
		CB_MapCursorBox = new DarkUIComboBox();
		CP_ShowFlightPlans_Planned = new DarkUIComboBox();
		CP_ShowFlightPlans_Airborne = new DarkUIComboBox();
		CP_ShowPlottedPaths = new DarkUIComboBox();
		CB_RefPointVisibility = new DarkUIComboBox();
		GroundUnitZoomBox = new DarkGroupBox();
		TableLayoutPanel1 = new TableLayoutPanel();
		TB_Flower_Zoom = new TrackBar();
		TB_GroundUnit_Zoom = new TrackBar();
		TB_Rectangle_Zoom = new TrackBar();
		RectangleShapedIconZoomLabel = new DarkLabel();
		TB_Diamond_Zoom = new TrackBar();
		lbl_GU_Zoom = new DarkLabel();
		CB_MissionAreaCourseDisplay = new DarkUIComboBox();
		ColorDialog_Shade = new ColorDialog();
		MapMarkerDisplayBox = new DarkGroupBox();
		LabelSeaIceColor = new DarkLabel();
		LabelBorderColor = new DarkLabel();
		LabelPlottedCourseColor = new DarkLabel();
		SignalsDisplayBox = new DarkGroupBox();
		CB_DisplayEmissionsFor = new DarkUIComboBox();
		CB_ContactEmissionsDisplay = new DarkUIComboBox();
		CB_Datalinks = new DarkUIComboBox();
		CB_TargetingVectors = new DarkUIComboBox();
		CB_IlluminationVectors = new DarkUIComboBox();
		SetPersonalMapProfileButton = new DarkUIButton();
		UsePersonalMapProfileCheckBox = new DarkCheckBox();
		DiamondShapedIconZoomLabel = new DarkLabel();
		FlowerShapedIconZoomLabel = new DarkLabel();
		DarkLabel1 = new DarkLabel();
		TB_GeneralIConZoom = new TrackBar();
		DarkLabel darkLabel = new DarkLabel();
		DarkLabel darkLabel2 = new DarkLabel();
		DarkLabel darkLabel3 = new DarkLabel();
		DarkLabel darkLabel4 = new DarkLabel();
		DarkLabel darkLabel5 = new DarkLabel();
		DarkLabel darkLabel6 = new DarkLabel();
		DarkLabel darkLabel7 = new DarkLabel();
		DarkLabel darkLabel8 = new DarkLabel();
		DarkLabel darkLabel9 = new DarkLabel();
		PictureBox val = new PictureBox();
		PictureBox val2 = new PictureBox();
		PictureBox val3 = new PictureBox();
		PictureBox val4 = new PictureBox();
		PictureBox val5 = new PictureBox();
		PictureBox val6 = new PictureBox();
		PictureBox val7 = new PictureBox();
		PictureBox val8 = new PictureBox();
		DarkGroupBox darkGroupBox = new DarkGroupBox();
		PictureBox val9 = new PictureBox();
		DarkUIButton darkUIButton = new DarkUIButton();
		DarkUIButton darkUIButton2 = new DarkUIButton();
		DarkGroupBox darkGroupBox2 = new DarkGroupBox();
		DarkLabel darkLabel10 = new DarkLabel();
		DarkLabel darkLabel11 = new DarkLabel();
		DarkLabel darkLabel12 = new DarkLabel();
		DarkLabel darkLabel13 = new DarkLabel();
		DarkLabel darkLabel14 = new DarkLabel();
		DarkLabel darkLabel15 = new DarkLabel();
		DarkUIButton darkUIButton3 = new DarkUIButton();
		DarkLabel darkLabel16 = new DarkLabel();
		DarkLabel darkLabel17 = new DarkLabel();
		DarkLabel darkLabel18 = new DarkLabel();
		DarkLabel darkLabel19 = new DarkLabel();
		DarkLabel darkLabel20 = new DarkLabel();
		DarkUIButton darkUIButton4 = new DarkUIButton();
		DarkUIButton darkUIButton5 = new DarkUIButton();
		((ISupportInitialize)val).BeginInit();
		((ISupportInitialize)val2).BeginInit();
		((ISupportInitialize)val3).BeginInit();
		((ISupportInitialize)val4).BeginInit();
		((ISupportInitialize)val5).BeginInit();
		((ISupportInitialize)val6).BeginInit();
		((ISupportInitialize)val7).BeginInit();
		((ISupportInitialize)val8).BeginInit();
		((Control)darkGroupBox).SuspendLayout();
		((ISupportInitialize)val9).BeginInit();
		((Control)darkGroupBox2).SuspendLayout();
		((Control)GroundUnitZoomBox).SuspendLayout();
		((Control)TableLayoutPanel1).SuspendLayout();
		((ISupportInitialize)TB_Flower_Zoom).BeginInit();
		((ISupportInitialize)TB_GroundUnit_Zoom).BeginInit();
		((ISupportInitialize)TB_Rectangle_Zoom).BeginInit();
		((ISupportInitialize)TB_Diamond_Zoom).BeginInit();
		((Control)MapMarkerDisplayBox).SuspendLayout();
		((Control)SignalsDisplayBox).SuspendLayout();
		((ISupportInitialize)TB_GeneralIConZoom).BeginInit();
		((Control)this).SuspendLayout();
		darkLabel.AutoSize = true;
		((Control)darkLabel).BackColor = Color.FromArgb(60, 63, 65);
		((Control)darkLabel).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)darkLabel).Location = new Point(6, 235);
		((Control)darkLabel).Margin = new Padding(1);
		((Control)darkLabel).Name = "ShowUnitBehaviorBarkLabel";
		((Control)darkLabel).Size = new Size(151, 15);
		((Control)darkLabel).TabIndex = 58;
		((Label)darkLabel).Text = "Show Units Behaviour Bark:";
		darkLabel2.AutoSize = true;
		((Control)darkLabel2).BackColor = Color.FromArgb(60, 63, 65);
		((Control)darkLabel2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)darkLabel2).Location = new Point(7, 135);
		((Control)darkLabel2).Name = "ShowFlightplansPlannedLabel";
		((Control)darkLabel2).Size = new Size(152, 15);
		((Control)darkLabel2).TabIndex = 56;
		((Label)darkLabel2).Text = "Show flightplans (planned):";
		darkLabel3.AutoSize = true;
		((Control)darkLabel3).BackColor = Color.FromArgb(60, 63, 65);
		((Control)darkLabel3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)darkLabel3).Location = new Point(7, 108);
		((Control)darkLabel3).Name = "ShowFlightplansAirborneLabel";
		((Control)darkLabel3).Size = new Size(173, 15);
		((Control)darkLabel3).TabIndex = 54;
		((Label)darkLabel3).Text = "Show flightplans (airborne a/c):";
		darkLabel4.AutoSize = true;
		((Control)darkLabel4).BackColor = Color.FromArgb(60, 63, 65);
		((Control)darkLabel4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)darkLabel4).Location = new Point(7, 81);
		((Control)darkLabel4).Name = "ShowPlottedPathsLabel";
		((Control)darkLabel4).Size = new Size(112, 15);
		((Control)darkLabel4).TabIndex = 51;
		((Label)darkLabel4).Text = "Show plotted paths:";
		darkLabel5.AutoSize = true;
		((Control)darkLabel5).BackColor = Color.FromArgb(60, 63, 65);
		((Control)darkLabel5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)darkLabel5).Location = new Point(6, 46);
		((Control)darkLabel5).Margin = new Padding(1);
		((Control)darkLabel5).Name = "ShowGhostedGroupMembersLabel";
		((Control)darkLabel5).Size = new Size(175, 15);
		((Control)darkLabel5).TabIndex = 50;
		((Label)darkLabel5).Text = "Show Ghosted Group Members:";
		darkLabel6.AutoSize = true;
		((Control)darkLabel6).BackColor = Color.FromArgb(60, 63, 65);
		((Control)darkLabel6).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)darkLabel6).Location = new Point(6, 73);
		((Control)darkLabel6).Margin = new Padding(1);
		((Control)darkLabel6).Name = "MapSymbolsLabel";
		((Control)darkLabel6).Size = new Size(82, 15);
		((Control)darkLabel6).TabIndex = 48;
		((Label)darkLabel6).Text = "Map Symbols:";
		darkLabel7.AutoSize = true;
		((Control)darkLabel7).BackColor = Color.FromArgb(60, 63, 65);
		((Control)darkLabel7).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)darkLabel7).Location = new Point(7, 54);
		((Control)darkLabel7).Name = "MapCursorDataboxVisLabel";
		((Control)darkLabel7).Size = new Size(165, 15);
		((Control)darkLabel7).TabIndex = 46;
		((Label)darkLabel7).Text = "Map Cursor Databox Visibility:";
		darkLabel8.AutoSize = true;
		((Control)darkLabel8).BackColor = Color.FromArgb(60, 63, 65);
		((Control)darkLabel8).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)darkLabel8).Location = new Point(7, 27);
		((Control)darkLabel8).Name = "ReferencePointVisLabel";
		((Control)darkLabel8).Size = new Size(140, 15);
		((Control)darkLabel8).TabIndex = 44;
		((Label)darkLabel8).Text = "Reference Point Visibility:";
		darkLabel9.AutoSize = true;
		((Control)darkLabel9).BackColor = Color.FromArgb(60, 63, 65);
		((Control)darkLabel9).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)darkLabel9).Location = new Point(6, 208);
		((Control)darkLabel9).Margin = new Padding(1);
		((Control)darkLabel9).Name = "SonobuoyVisLabel";
		((Control)darkLabel9).Size = new Size(111, 15);
		((Control)darkLabel9).TabIndex = 42;
		((Label)darkLabel9).Text = "Sonobuoy Visibility:";
		val.Image = (Image)componentResourceManager.GetObject("AirSensorsIcon.Image");
		((Control)val).Location = new Point(21, 118);
		((Control)val).Name = "AirSensorsIcon";
		((Control)val).Size = new Size(19, 19);
		val.TabIndex = 0;
		val.TabStop = false;
		((Control)val).Click += method_52;
		val2.Image = (Image)componentResourceManager.GetObject("SurfaceSensorsIcon.Image");
		((Control)val2).Location = new Point(21, 145);
		((Control)val2).Name = "SurfaceSensorsIcon";
		((Control)val2).Size = new Size(19, 19);
		val2.TabIndex = 60;
		val2.TabStop = false;
		((Control)val2).Click += method_55;
		val3.Image = (Image)componentResourceManager.GetObject("UnderwaterSensorsIcon.Image");
		((Control)val3).Location = new Point(21, 172);
		((Control)val3).Name = "UnderwaterSensorsIcon";
		((Control)val3).Size = new Size(19, 19);
		val3.TabIndex = 61;
		val3.TabStop = false;
		((Control)val3).Click += method_56;
		val4.Image = (Image)componentResourceManager.GetObject("AirWeaponsIcon.Image");
		((Control)val4).Location = new Point(21, 199);
		((Control)val4).Name = "AirWeaponsIcon";
		((Control)val4).Size = new Size(19, 19);
		val4.TabIndex = 62;
		val4.TabStop = false;
		((Control)val4).Click += method_59;
		val5.Image = (Image)componentResourceManager.GetObject("SurfaceWeaponsIcon.Image");
		((Control)val5).Location = new Point(21, 226);
		((Control)val5).Name = "SurfaceWeaponsIcon";
		((Control)val5).Size = new Size(19, 19);
		val5.TabIndex = 63;
		val5.TabStop = false;
		((Control)val5).Click += method_61;
		val6.Image = (Image)componentResourceManager.GetObject("LandWeaponsIcon.Image");
		((Control)val6).Location = new Point(21, 253);
		((Control)val6).Name = "LandWeaponsIcon";
		((Control)val6).Size = new Size(19, 19);
		val6.TabIndex = 64;
		val6.TabStop = false;
		((Control)val6).Click += method_63;
		val7.Image = (Image)componentResourceManager.GetObject("UnderwaterWeaponsIcon.Image");
		((Control)val7).Location = new Point(21, 279);
		((Control)val7).Name = "UnderwaterWeaponsIcon";
		((Control)val7).Size = new Size(19, 19);
		val7.TabIndex = 65;
		val7.TabStop = false;
		((Control)val7).Click += method_64;
		val8.Image = (Image)componentResourceManager.GetObject("AircraftRangeIcon.Image");
		((Control)val8).Location = new Point(21, 304);
		((Control)val8).Name = "AircraftRangeIcon";
		((Control)val8).Size = new Size(19, 19);
		val8.TabIndex = 66;
		val8.TabStop = false;
		((Control)darkGroupBox).Controls.Add((Control)(object)COMMSRangeCheckBox);
		((Control)darkGroupBox).Controls.Add((Control)(object)val9);
		((Control)darkGroupBox).Controls.Add((Control)(object)ShowRangeIndicatorsLabel);
		((Control)darkGroupBox).Controls.Add((Control)(object)MergeRangeSymbolsCheckBox);
		((Control)darkGroupBox).Controls.Add((Control)(object)ShowNonFriendlyRangeSymbolsCheckBox);
		((Control)darkGroupBox).Controls.Add((Control)(object)CB_ShowRangeIndicators);
		((Control)darkGroupBox).Controls.Add((Control)(object)AircraftRangeCheckBox);
		((Control)darkGroupBox).Controls.Add((Control)(object)UnderwaterWeaponsCheckBox);
		((Control)darkGroupBox).Controls.Add((Control)(object)LandWeaponsCheckBox);
		((Control)darkGroupBox).Controls.Add((Control)(object)SurfaceWeaponsCheckBox);
		((Control)darkGroupBox).Controls.Add((Control)(object)AirWeaponsCheckBox);
		((Control)darkGroupBox).Controls.Add((Control)(object)UnderwaterSensorsCheckBox);
		((Control)darkGroupBox).Controls.Add((Control)(object)SurfaceSensorsCheckBox);
		((Control)darkGroupBox).Controls.Add((Control)(object)AirSensorsCheckBox);
		((Control)darkGroupBox).Controls.Add((Control)(object)darkUIButton);
		((Control)darkGroupBox).Controls.Add((Control)(object)darkUIButton2);
		((Control)darkGroupBox).Controls.Add((Control)(object)val);
		((Control)darkGroupBox).Controls.Add((Control)(object)val2);
		((Control)darkGroupBox).Controls.Add((Control)(object)val3);
		((Control)darkGroupBox).Controls.Add((Control)(object)val4);
		((Control)darkGroupBox).Controls.Add((Control)(object)val5);
		((Control)darkGroupBox).Controls.Add((Control)(object)val6);
		((Control)darkGroupBox).Controls.Add((Control)(object)val7);
		((Control)darkGroupBox).Controls.Add((Control)(object)val8);
		((Control)darkGroupBox).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)darkGroupBox).Location = new Point(12, 12);
		((Control)darkGroupBox).Name = "RangeIndicatorsBox";
		((Control)darkGroupBox).Size = new Size(361, 399);
		((Control)darkGroupBox).TabIndex = 75;
		((GroupBox)darkGroupBox).TabStop = false;
		((GroupBox)darkGroupBox).Text = "Range Indicators";
		((Control)darkGroupBox).Enter += method_60;
		((ButtonBase)COMMSRangeCheckBox).AutoSize = true;
		((Control)COMMSRangeCheckBox).Location = new Point(50, 329);
		((Control)COMMSRangeCheckBox).Name = "COMMSRangeCheckBox";
		((Control)COMMSRangeCheckBox).Size = new Size(107, 19);
		((Control)COMMSRangeCheckBox).TabIndex = 89;
		((ButtonBase)COMMSRangeCheckBox).Text = "COMMS Range";
		val9.Image = (Image)componentResourceManager.GetObject("CommsRangeColor.Image");
		((Control)val9).Location = new Point(21, 328);
		((Control)val9).Name = "CommsRangeColor";
		((Control)val9).Size = new Size(19, 19);
		val9.TabIndex = 88;
		val9.TabStop = false;
		ShowRangeIndicatorsLabel.AutoSize = true;
		((Control)ShowRangeIndicatorsLabel).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)ShowRangeIndicatorsLabel).Location = new Point(19, 96);
		((Control)ShowRangeIndicatorsLabel).Name = "ShowRangeIndicatorsLabel";
		((Control)ShowRangeIndicatorsLabel).Size = new Size(145, 15);
		((Control)ShowRangeIndicatorsLabel).TabIndex = 87;
		((Label)ShowRangeIndicatorsLabel).Text = "Show Range Indicators for";
		((ButtonBase)MergeRangeSymbolsCheckBox).AutoSize = true;
		((Control)MergeRangeSymbolsCheckBox).Location = new Point(22, 376);
		((Control)MergeRangeSymbolsCheckBox).Name = "MergeRangeSymbolsCheckBox";
		((Control)MergeRangeSymbolsCheckBox).Size = new Size(144, 19);
		((Control)MergeRangeSymbolsCheckBox).TabIndex = 86;
		((ButtonBase)MergeRangeSymbolsCheckBox).Text = "Merge Range Symbols";
		((ButtonBase)ShowNonFriendlyRangeSymbolsCheckBox).AutoSize = true;
		((Control)ShowNonFriendlyRangeSymbolsCheckBox).Location = new Point(22, 355);
		((Control)ShowNonFriendlyRangeSymbolsCheckBox).Name = "ShowNonFriendlyRangeSymbolsCheckBox";
		((Control)ShowNonFriendlyRangeSymbolsCheckBox).Size = new Size(212, 19);
		((Control)ShowNonFriendlyRangeSymbolsCheckBox).TabIndex = 85;
		((ButtonBase)ShowNonFriendlyRangeSymbolsCheckBox).Text = "Show Non-Friendly Range Symbols";
		((ComboBox)CB_ShowRangeIndicators).BackColor = Color.Transparent;
		((ComboBox)CB_ShowRangeIndicators).DrawMode = (DrawMode)1;
		((ComboBox)CB_ShowRangeIndicators).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_ShowRangeIndicators).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)CB_ShowRangeIndicators).FormattingEnabled = true;
		((ComboBox)CB_ShowRangeIndicators).Items.AddRange(new object[3] { "All", "Selected Unit", "None" });
		((Control)CB_ShowRangeIndicators).Location = new Point(170, 93);
		((Control)CB_ShowRangeIndicators).Name = "CB_ShowRangeIndicators";
		((Control)CB_ShowRangeIndicators).Size = new Size(121, 21);
		((Control)CB_ShowRangeIndicators).TabIndex = 84;
		((ButtonBase)AircraftRangeCheckBox).AutoSize = true;
		((Control)AircraftRangeCheckBox).Location = new Point(50, 305);
		((Control)AircraftRangeCheckBox).Name = "AircraftRangeCheckBox";
		((Control)AircraftRangeCheckBox).Size = new Size(101, 19);
		((Control)AircraftRangeCheckBox).TabIndex = 83;
		((ButtonBase)AircraftRangeCheckBox).Text = "Aircraft Range";
		((ButtonBase)UnderwaterWeaponsCheckBox).AutoSize = true;
		((Control)UnderwaterWeaponsCheckBox).Location = new Point(50, 279);
		((Control)UnderwaterWeaponsCheckBox).Name = "UnderwaterWeaponsCheckBox";
		((Control)UnderwaterWeaponsCheckBox).Size = new Size(139, 19);
		((Control)UnderwaterWeaponsCheckBox).TabIndex = 82;
		((ButtonBase)UnderwaterWeaponsCheckBox).Text = "Underwater Weapons";
		((ButtonBase)LandWeaponsCheckBox).AutoSize = true;
		((Control)LandWeaponsCheckBox).Location = new Point(50, 254);
		((Control)LandWeaponsCheckBox).Name = "LandWeaponsCheckBox";
		((Control)LandWeaponsCheckBox).Size = new Size(104, 19);
		((Control)LandWeaponsCheckBox).TabIndex = 81;
		((ButtonBase)LandWeaponsCheckBox).Text = "Land Weapons";
		((ButtonBase)SurfaceWeaponsCheckBox).AutoSize = true;
		((Control)SurfaceWeaponsCheckBox).Location = new Point(50, 226);
		((Control)SurfaceWeaponsCheckBox).Name = "SurfaceWeaponsCheckBox";
		((Control)SurfaceWeaponsCheckBox).Size = new Size(117, 19);
		((Control)SurfaceWeaponsCheckBox).TabIndex = 80;
		((ButtonBase)SurfaceWeaponsCheckBox).Text = "Surface Weapons";
		((ButtonBase)AirWeaponsCheckBox).AutoSize = true;
		((Control)AirWeaponsCheckBox).Location = new Point(50, 199);
		((Control)AirWeaponsCheckBox).Name = "AirWeaponsCheckBox";
		((Control)AirWeaponsCheckBox).Size = new Size(93, 19);
		((Control)AirWeaponsCheckBox).TabIndex = 79;
		((ButtonBase)AirWeaponsCheckBox).Text = "Air Weapons";
		((ButtonBase)UnderwaterSensorsCheckBox).AutoSize = true;
		((Control)UnderwaterSensorsCheckBox).Location = new Point(50, 172);
		((Control)UnderwaterSensorsCheckBox).Name = "UnderwaterSensorsCheckBox";
		((Control)UnderwaterSensorsCheckBox).Size = new Size(130, 19);
		((Control)UnderwaterSensorsCheckBox).TabIndex = 78;
		((ButtonBase)UnderwaterSensorsCheckBox).Text = "Underwater Sensors";
		((ButtonBase)SurfaceSensorsCheckBox).AutoSize = true;
		((Control)SurfaceSensorsCheckBox).Location = new Point(50, 145);
		((Control)SurfaceSensorsCheckBox).Name = "SurfaceSensorsCheckBox";
		((Control)SurfaceSensorsCheckBox).Size = new Size(108, 19);
		((Control)SurfaceSensorsCheckBox).TabIndex = 77;
		((ButtonBase)SurfaceSensorsCheckBox).Text = "Surface Sensors";
		((ButtonBase)AirSensorsCheckBox).AutoSize = true;
		((Control)AirSensorsCheckBox).Location = new Point(50, 118);
		((Control)AirSensorsCheckBox).Name = "AirSensorsCheckBox";
		((Control)AirSensorsCheckBox).Size = new Size(84, 19);
		((Control)AirSensorsCheckBox).TabIndex = 76;
		((ButtonBase)AirSensorsCheckBox).Text = "Air Sensors";
		((Control)darkUIButton).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)darkUIButton).Location = new Point(15, 59);
		((Control)darkUIButton).Name = "DisableRangeIndicatorsButton";
		((Control)darkUIButton).Padding = new Padding(5);
		darkUIButton.RoundRadius = 0;
		((Control)darkUIButton).Size = new Size(166, 23);
		((Control)darkUIButton).TabIndex = 75;
		darkUIButton.Text = "Disable all Range Indicators";
		((Control)darkUIButton).Click += method_3;
		((Control)darkUIButton2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)darkUIButton2).Location = new Point(17, 26);
		((Control)darkUIButton2).Name = "RangeIndicatorsEnableButton";
		((Control)darkUIButton2).Padding = new Padding(5);
		darkUIButton2.RoundRadius = 0;
		((Control)darkUIButton2).Size = new Size(161, 23);
		((Control)darkUIButton2).TabIndex = 0;
		darkUIButton2.Text = "Enable all Range Indicators";
		((Control)darkUIButton2).Click += method_2;
		((Control)darkGroupBox2).Controls.Add((Control)(object)darkLabel10);
		((Control)darkGroupBox2).Controls.Add((Control)(object)CB_GroupUnitView);
		((Control)darkGroupBox2).Controls.Add((Control)(object)ShowDynamicNoiseCheckBox);
		((Control)darkGroupBox2).Controls.Add((Control)(object)ColoredDatablocksCheckBox);
		((Control)darkGroupBox2).Controls.Add((Control)(object)ShowOutlinesCheckBox);
		((Control)darkGroupBox2).Controls.Add((Control)(object)darkLabel11);
		((Control)darkGroupBox2).Controls.Add((Control)(object)darkLabel12);
		((Control)darkGroupBox2).Controls.Add((Control)(object)CB_ShowContrail);
		((Control)darkGroupBox2).Controls.Add((Control)(object)darkLabel13);
		((Control)darkGroupBox2).Controls.Add((Control)(object)CP_ShowAU_Behaviour_Bark);
		((Control)darkGroupBox2).Controls.Add((Control)(object)darkLabel);
		((Control)darkGroupBox2).Controls.Add((Control)(object)CB_ShowWakeAndCavitation);
		((Control)darkGroupBox2).Controls.Add((Control)(object)CB_DisplayDatablockType);
		((Control)darkGroupBox2).Controls.Add((Control)(object)darkLabel14);
		((Control)darkGroupBox2).Controls.Add((Control)(object)CB_DisplayDatablocks);
		((Control)darkGroupBox2).Controls.Add((Control)(object)darkLabel6);
		((Control)darkGroupBox2).Controls.Add((Control)(object)CB_MapSymbols);
		((Control)darkGroupBox2).Controls.Add((Control)(object)darkLabel5);
		((Control)darkGroupBox2).Controls.Add((Control)(object)CP_ShowGhostedGroupMembers);
		((Control)darkGroupBox2).Controls.Add((Control)(object)CB_SonobuoyVisibility);
		((Control)darkGroupBox2).Controls.Add((Control)(object)darkLabel9);
		((Control)darkGroupBox2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)darkGroupBox2).Location = new Point(12, 412);
		((Control)darkGroupBox2).Name = "UnitDesplayBox";
		((Control)darkGroupBox2).Size = new Size(361, 307);
		((Control)darkGroupBox2).TabIndex = 76;
		((GroupBox)darkGroupBox2).TabStop = false;
		((GroupBox)darkGroupBox2).Text = "Unit Display";
		darkLabel10.AutoSize = true;
		((Control)darkLabel10).BackColor = Color.FromArgb(60, 63, 65);
		((Control)darkLabel10).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)darkLabel10).Location = new Point(6, 19);
		((Control)darkLabel10).Margin = new Padding(1);
		((Control)darkLabel10).Name = "GroupUnitViewLabel";
		((Control)darkLabel10).Size = new Size(95, 15);
		((Control)darkLabel10).TabIndex = 87;
		((Label)darkLabel10).Text = "Group/Unit View";
		((ComboBox)CB_GroupUnitView).BackColor = Color.Transparent;
		((ComboBox)CB_GroupUnitView).DrawMode = (DrawMode)1;
		((ComboBox)CB_GroupUnitView).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_GroupUnitView).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_GroupUnitView).FormattingEnabled = true;
		((ComboBox)CB_GroupUnitView).Items.AddRange(new object[2] { "Group View", "Unit View" });
		((Control)CB_GroupUnitView).Location = new Point(181, 16);
		((Control)CB_GroupUnitView).Margin = new Padding(1);
		((Control)CB_GroupUnitView).Name = "CB_GroupUnitView";
		((Control)CB_GroupUnitView).Size = new Size(150, 21);
		((Control)CB_GroupUnitView).TabIndex = 88;
		((ButtonBase)ShowDynamicNoiseCheckBox).AutoSize = true;
		((Control)ShowDynamicNoiseCheckBox).Location = new Point(9, 280);
		((Control)ShowDynamicNoiseCheckBox).Margin = new Padding(1);
		((Control)ShowDynamicNoiseCheckBox).Name = "ShowDynamicNoiseCheckBox";
		((Control)ShowDynamicNoiseCheckBox).Size = new Size(338, 19);
		((Control)ShowDynamicNoiseCheckBox).TabIndex = 86;
		((ButtonBase)ShowDynamicNoiseCheckBox).Text = "Show dynamic noise values when ASW range rings enabled";
		((ButtonBase)ColoredDatablocksCheckBox).AutoSize = true;
		((Control)ColoredDatablocksCheckBox).Location = new Point(184, 259);
		((Control)ColoredDatablocksCheckBox).Margin = new Padding(1);
		((Control)ColoredDatablocksCheckBox).Name = "ColoredDatablocksCheckBox";
		((Control)ColoredDatablocksCheckBox).Size = new Size(151, 19);
		((Control)ColoredDatablocksCheckBox).TabIndex = 86;
		((ButtonBase)ColoredDatablocksCheckBox).Text = "Use Colored Datablocks";
		((ButtonBase)ShowOutlinesCheckBox).AutoSize = true;
		((Control)ShowOutlinesCheckBox).Location = new Point(9, 259);
		((Control)ShowOutlinesCheckBox).Margin = new Padding(1);
		((Control)ShowOutlinesCheckBox).Name = "ShowOutlinesCheckBox";
		((Control)ShowOutlinesCheckBox).Size = new Size(157, 19);
		((Control)ShowOutlinesCheckBox).TabIndex = 86;
		((ButtonBase)ShowOutlinesCheckBox).Text = "Draw text + icon outlines";
		darkLabel11.AutoSize = true;
		((Control)darkLabel11).BackColor = Color.FromArgb(60, 63, 65);
		((Control)darkLabel11).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)darkLabel11).Location = new Point(6, 181);
		((Control)darkLabel11).Margin = new Padding(1);
		((Control)darkLabel11).Name = "ShowContrailLabel";
		((Control)darkLabel11).Size = new Size(89, 15);
		((Control)darkLabel11).TabIndex = 79;
		((Label)darkLabel11).Text = "Show Contrails:";
		darkLabel12.AutoSize = true;
		((Control)darkLabel12).BackColor = Color.FromArgb(60, 63, 65);
		((Control)darkLabel12).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)darkLabel12).Location = new Point(6, 154);
		((Control)darkLabel12).Margin = new Padding(1);
		((Control)darkLabel12).Name = "ShowWakeAndCavitationLabel";
		((Control)darkLabel12).Size = new Size(151, 15);
		((Control)darkLabel12).TabIndex = 77;
		((Label)darkLabel12).Text = "Show Wake and Cavitation:";
		((ComboBox)CB_ShowContrail).BackColor = Color.Transparent;
		((ComboBox)CB_ShowContrail).DrawMode = (DrawMode)1;
		((ComboBox)CB_ShowContrail).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_ShowContrail).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_ShowContrail).FormattingEnabled = true;
		((ComboBox)CB_ShowContrail).Items.AddRange(new object[3] { "All", "Selected Unit", "None" });
		((Control)CB_ShowContrail).Location = new Point(181, 178);
		((Control)CB_ShowContrail).Margin = new Padding(1);
		((Control)CB_ShowContrail).Name = "CB_ShowContrail";
		((Control)CB_ShowContrail).Size = new Size(150, 21);
		((Control)CB_ShowContrail).TabIndex = 80;
		darkLabel13.AutoSize = true;
		((Control)darkLabel13).BackColor = Color.FromArgb(60, 63, 65);
		((Control)darkLabel13).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)darkLabel13).Location = new Point(6, 127);
		((Control)darkLabel13).Margin = new Padding(1);
		((Control)darkLabel13).Name = "ShowDatablockTypeLabel";
		((Control)darkLabel13).Size = new Size(161, 15);
		((Control)darkLabel13).TabIndex = 79;
		((Label)darkLabel13).Text = "Show Datablock Information:";
		((ComboBox)CP_ShowAU_Behaviour_Bark).BackColor = Color.Transparent;
		((ComboBox)CP_ShowAU_Behaviour_Bark).DrawMode = (DrawMode)1;
		((ComboBox)CP_ShowAU_Behaviour_Bark).DropDownStyle = (ComboBoxStyle)2;
		((Control)CP_ShowAU_Behaviour_Bark).Font = new Font("Segoe UI", 7f);
		((ListControl)CP_ShowAU_Behaviour_Bark).FormattingEnabled = true;
		((ComboBox)CP_ShowAU_Behaviour_Bark).Items.AddRange(new object[3] { "All", "Selected Unit", "Do not Show" });
		((Control)CP_ShowAU_Behaviour_Bark).Location = new Point(181, 232);
		((Control)CP_ShowAU_Behaviour_Bark).Margin = new Padding(1);
		((Control)CP_ShowAU_Behaviour_Bark).Name = "CP_ShowAU_Behaviour_Bark";
		((Control)CP_ShowAU_Behaviour_Bark).Size = new Size(150, 21);
		((Control)CP_ShowAU_Behaviour_Bark).TabIndex = 59;
		((ComboBox)CB_ShowWakeAndCavitation).BackColor = Color.Transparent;
		((ComboBox)CB_ShowWakeAndCavitation).DrawMode = (DrawMode)1;
		((ComboBox)CB_ShowWakeAndCavitation).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_ShowWakeAndCavitation).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_ShowWakeAndCavitation).FormattingEnabled = true;
		((ComboBox)CB_ShowWakeAndCavitation).Items.AddRange(new object[3] { "All", "Selected Unit", "None" });
		((Control)CB_ShowWakeAndCavitation).Location = new Point(181, 151);
		((Control)CB_ShowWakeAndCavitation).Margin = new Padding(1);
		((Control)CB_ShowWakeAndCavitation).Name = "CB_ShowWakeAndCavitation";
		((Control)CB_ShowWakeAndCavitation).Size = new Size(150, 21);
		((Control)CB_ShowWakeAndCavitation).TabIndex = 78;
		((ComboBox)CB_DisplayDatablockType).BackColor = Color.Transparent;
		((ComboBox)CB_DisplayDatablockType).DrawMode = (DrawMode)1;
		((ComboBox)CB_DisplayDatablockType).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_DisplayDatablockType).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_DisplayDatablockType).FormattingEnabled = true;
		((ComboBox)CB_DisplayDatablockType).Items.AddRange(new object[3] { "Only track number and class/ID", "Track number, class-ID and kinematic data", "Everything" });
		((Control)CB_DisplayDatablockType).Location = new Point(181, 124);
		((Control)CB_DisplayDatablockType).Margin = new Padding(1);
		((Control)CB_DisplayDatablockType).Name = "CB_DisplayDatablockType";
		((Control)CB_DisplayDatablockType).Size = new Size(150, 21);
		((Control)CB_DisplayDatablockType).TabIndex = 80;
		darkLabel14.AutoSize = true;
		((Control)darkLabel14).BackColor = Color.FromArgb(60, 63, 65);
		((Control)darkLabel14).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)darkLabel14).Location = new Point(6, 100);
		((Control)darkLabel14).Margin = new Padding(1);
		((Control)darkLabel14).Name = "DisplayDatablocksLabel";
		((Control)darkLabel14).Size = new Size(120, 15);
		((Control)darkLabel14).TabIndex = 77;
		((Label)darkLabel14).Text = "Show Datablocks For:";
		((ComboBox)CB_DisplayDatablocks).BackColor = Color.Transparent;
		((ComboBox)CB_DisplayDatablocks).DrawMode = (DrawMode)1;
		((ComboBox)CB_DisplayDatablocks).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_DisplayDatablocks).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_DisplayDatablocks).FormattingEnabled = true;
		((ComboBox)CB_DisplayDatablocks).Items.AddRange(new object[3] { "All", "Selected Unit", "Do not Show" });
		((Control)CB_DisplayDatablocks).Location = new Point(181, 97);
		((Control)CB_DisplayDatablocks).Margin = new Padding(1);
		((Control)CB_DisplayDatablocks).Name = "CB_DisplayDatablocks";
		((Control)CB_DisplayDatablocks).Size = new Size(150, 21);
		((Control)CB_DisplayDatablocks).TabIndex = 78;
		((ComboBox)CB_MapSymbols).BackColor = Color.Transparent;
		((ComboBox)CB_MapSymbols).DrawMode = (DrawMode)1;
		((ComboBox)CB_MapSymbols).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_MapSymbols).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_MapSymbols).FormattingEnabled = true;
		((ComboBox)CB_MapSymbols).Items.AddRange(new object[4] { "NTDS + APP-6", "Stylized", "Directional Stylized", "Full APP-6" });
		((Control)CB_MapSymbols).Location = new Point(181, 70);
		((Control)CB_MapSymbols).Margin = new Padding(1);
		((Control)CB_MapSymbols).Name = "CB_MapSymbols";
		((Control)CB_MapSymbols).Size = new Size(150, 21);
		((Control)CB_MapSymbols).TabIndex = 49;
		((ComboBox)CP_ShowGhostedGroupMembers).BackColor = Color.Transparent;
		((ComboBox)CP_ShowGhostedGroupMembers).DrawMode = (DrawMode)1;
		((ComboBox)CP_ShowGhostedGroupMembers).DropDownStyle = (ComboBoxStyle)2;
		((Control)CP_ShowGhostedGroupMembers).Font = new Font("Segoe UI", 7f);
		((ListControl)CP_ShowGhostedGroupMembers).FormattingEnabled = true;
		((ComboBox)CP_ShowGhostedGroupMembers).Items.AddRange(new object[3] { "All Groups", "Selected Groups", "Do not Show" });
		((Control)CP_ShowGhostedGroupMembers).Location = new Point(181, 43);
		((Control)CP_ShowGhostedGroupMembers).Margin = new Padding(1);
		((Control)CP_ShowGhostedGroupMembers).Name = "CP_ShowGhostedGroupMembers";
		((Control)CP_ShowGhostedGroupMembers).Size = new Size(150, 21);
		((Control)CP_ShowGhostedGroupMembers).TabIndex = 53;
		((ComboBox)CB_SonobuoyVisibility).BackColor = Color.Transparent;
		((ComboBox)CB_SonobuoyVisibility).DrawMode = (DrawMode)1;
		((ComboBox)CB_SonobuoyVisibility).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_SonobuoyVisibility).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_SonobuoyVisibility).FormattingEnabled = true;
		((ComboBox)CB_SonobuoyVisibility).Items.AddRange(new object[3] { "Normal", "Ghosted", "Do not show" });
		((Control)CB_SonobuoyVisibility).Location = new Point(181, 205);
		((Control)CB_SonobuoyVisibility).Margin = new Padding(1);
		((Control)CB_SonobuoyVisibility).Name = "CB_SonobuoyVisibility";
		((Control)CB_SonobuoyVisibility).Size = new Size(150, 21);
		((Control)CB_SonobuoyVisibility).TabIndex = 43;
		darkLabel15.AutoSize = true;
		((Control)darkLabel15).BackColor = Color.FromArgb(60, 63, 65);
		((Control)darkLabel15).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)darkLabel15).Location = new Point(7, 162);
		((Control)darkLabel15).Name = "MissionAreaCourseLabel";
		((Control)darkLabel15).Size = new Size(117, 15);
		((Control)darkLabel15).TabIndex = 80;
		((Label)darkLabel15).Text = "Mission Area/Course";
		((Control)darkUIButton3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)darkUIButton3).Location = new Point(42, 186);
		((Control)darkUIButton3).Name = "DefinePlottedCoursesColorButton";
		((Control)darkUIButton3).Padding = new Padding(5);
		darkUIButton3.RoundRadius = 0;
		((Control)darkUIButton3).Size = new Size(289, 23);
		((Control)darkUIButton3).TabIndex = 82;
		darkUIButton3.Text = "Set Plotted Course Color";
		((Control)darkUIButton3).Click += method_42;
		darkLabel16.AutoSize = true;
		((Control)darkLabel16).BackColor = Color.FromArgb(60, 63, 65);
		((Control)darkLabel16).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)darkLabel16).Location = new Point(4, 25);
		((Control)darkLabel16).Name = "IlluminationVectorsLabel";
		((Control)darkLabel16).Size = new Size(115, 15);
		((Control)darkLabel16).TabIndex = 83;
		((Label)darkLabel16).Text = "Illumination Vectors:";
		darkLabel17.AutoSize = true;
		((Control)darkLabel17).BackColor = Color.FromArgb(60, 63, 65);
		((Control)darkLabel17).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)darkLabel17).Location = new Point(4, 52);
		((Control)darkLabel17).Name = "TargetingVectorsLabel";
		((Control)darkLabel17).Size = new Size(101, 15);
		((Control)darkLabel17).TabIndex = 85;
		((Label)darkLabel17).Text = "Targeting Vectors:";
		darkLabel18.AutoSize = true;
		((Control)darkLabel18).BackColor = Color.FromArgb(60, 63, 65);
		((Control)darkLabel18).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)darkLabel18).Location = new Point(4, 79);
		((Control)darkLabel18).Name = "DatalinksLabel";
		((Control)darkLabel18).Size = new Size(58, 15);
		((Control)darkLabel18).TabIndex = 87;
		((Label)darkLabel18).Text = "Datalinks:";
		darkLabel19.AutoSize = true;
		((Control)darkLabel19).BackColor = Color.FromArgb(60, 63, 65);
		((Control)darkLabel19).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)darkLabel19).Location = new Point(4, 106);
		((Control)darkLabel19).Name = "ContactEmissionsLabel";
		((Control)darkLabel19).Size = new Size(154, 15);
		((Control)darkLabel19).TabIndex = 89;
		((Label)darkLabel19).Text = "Contact Emissions Visibility:";
		darkLabel20.AutoSize = true;
		((Control)darkLabel20).BackColor = Color.FromArgb(60, 63, 65);
		((Control)darkLabel20).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)darkLabel20).Location = new Point(5, 133);
		((Control)darkLabel20).Name = "DisplayEmissionsForLabel";
		((Control)darkLabel20).Size = new Size(173, 15);
		((Control)darkLabel20).TabIndex = 91;
		((Label)darkLabel20).Text = "Non Fire Control Emissions For:";
		((Control)darkUIButton4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)darkUIButton4).Location = new Point(42, 215);
		((Control)darkUIButton4).Name = "DefineBorderColorButton";
		((Control)darkUIButton4).Padding = new Padding(5);
		darkUIButton4.RoundRadius = 0;
		((Control)darkUIButton4).Size = new Size(289, 23);
		((Control)darkUIButton4).TabIndex = 86;
		darkUIButton4.Text = "Set Border Color";
		((Control)darkUIButton4).Click += method_43;
		((Control)darkUIButton5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)darkUIButton5).Location = new Point(42, 244);
		((Control)darkUIButton5).Name = "DefineSeaIceColorButton";
		((Control)darkUIButton5).Padding = new Padding(5);
		darkUIButton5.RoundRadius = 0;
		((Control)darkUIButton5).Size = new Size(289, 23);
		((Control)darkUIButton5).TabIndex = 88;
		darkUIButton5.Text = "Set Sea Ice Color";
		((Control)darkUIButton5).Click += method_44;
		((ComboBox)CB_MapCursorBox).BackColor = Color.Transparent;
		((ComboBox)CB_MapCursorBox).DrawMode = (DrawMode)1;
		((ComboBox)CB_MapCursorBox).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_MapCursorBox).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_MapCursorBox).FormattingEnabled = true;
		((ComboBox)CB_MapCursorBox).Items.AddRange(new object[3] { "Show on cursor", "Show on bottom", "Do not show" });
		((Control)CB_MapCursorBox).Location = new Point(182, 51);
		((Control)CB_MapCursorBox).Name = "CB_MapCursorBox";
		((Control)CB_MapCursorBox).Size = new Size(150, 21);
		((Control)CB_MapCursorBox).TabIndex = 47;
		((ComboBox)CP_ShowFlightPlans_Planned).BackColor = Color.Transparent;
		((ComboBox)CP_ShowFlightPlans_Planned).DrawMode = (DrawMode)1;
		((ComboBox)CP_ShowFlightPlans_Planned).DropDownStyle = (ComboBoxStyle)2;
		((Control)CP_ShowFlightPlans_Planned).Font = new Font("Segoe UI", 7f);
		((ListControl)CP_ShowFlightPlans_Planned).FormattingEnabled = true;
		((ComboBox)CP_ShowFlightPlans_Planned).Items.AddRange(new object[5] { "All", "Selected Task Pool ", "Selected Package", "Selected Flight", "Do not Show" });
		((Control)CP_ShowFlightPlans_Planned).Location = new Point(182, 132);
		((Control)CP_ShowFlightPlans_Planned).Name = "CP_ShowFlightPlans_Planned";
		((Control)CP_ShowFlightPlans_Planned).Size = new Size(150, 21);
		((Control)CP_ShowFlightPlans_Planned).TabIndex = 57;
		((ComboBox)CP_ShowFlightPlans_Airborne).BackColor = Color.Transparent;
		((ComboBox)CP_ShowFlightPlans_Airborne).DrawMode = (DrawMode)1;
		((ComboBox)CP_ShowFlightPlans_Airborne).DropDownStyle = (ComboBoxStyle)2;
		((Control)CP_ShowFlightPlans_Airborne).Font = new Font("Segoe UI", 7f);
		((ListControl)CP_ShowFlightPlans_Airborne).FormattingEnabled = true;
		((ComboBox)CP_ShowFlightPlans_Airborne).Items.AddRange(new object[3] { "All", "Selected Unit", "Do not Show" });
		((Control)CP_ShowFlightPlans_Airborne).Location = new Point(182, 105);
		((Control)CP_ShowFlightPlans_Airborne).Name = "CP_ShowFlightPlans_Airborne";
		((Control)CP_ShowFlightPlans_Airborne).Size = new Size(150, 21);
		((Control)CP_ShowFlightPlans_Airborne).TabIndex = 55;
		((ComboBox)CP_ShowPlottedPaths).BackColor = Color.Transparent;
		((ComboBox)CP_ShowPlottedPaths).DrawMode = (DrawMode)1;
		((ComboBox)CP_ShowPlottedPaths).DropDownStyle = (ComboBoxStyle)2;
		((Control)CP_ShowPlottedPaths).Font = new Font("Segoe UI", 7f);
		((ListControl)CP_ShowPlottedPaths).FormattingEnabled = true;
		((ComboBox)CP_ShowPlottedPaths).Items.AddRange(new object[3] { "All", "Selected Unit", "Do not Show" });
		((Control)CP_ShowPlottedPaths).Location = new Point(182, 78);
		((Control)CP_ShowPlottedPaths).Name = "CP_ShowPlottedPaths";
		((Control)CP_ShowPlottedPaths).Size = new Size(150, 21);
		((Control)CP_ShowPlottedPaths).TabIndex = 52;
		((ComboBox)CB_RefPointVisibility).BackColor = Color.Transparent;
		((ComboBox)CB_RefPointVisibility).DrawMode = (DrawMode)1;
		((ComboBox)CB_RefPointVisibility).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_RefPointVisibility).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_RefPointVisibility).FormattingEnabled = true;
		((ComboBox)CB_RefPointVisibility).Items.AddRange(new object[3] { "Normal", "Small", "Do not show" });
		((Control)CB_RefPointVisibility).Location = new Point(182, 24);
		((Control)CB_RefPointVisibility).Name = "CB_RefPointVisibility";
		((Control)CB_RefPointVisibility).Size = new Size(150, 21);
		((Control)CB_RefPointVisibility).TabIndex = 45;
		((Control)GroundUnitZoomBox).Controls.Add((Control)(object)TableLayoutPanel1);
		((Control)GroundUnitZoomBox).Controls.Add((Control)(object)lbl_GU_Zoom);
		((Control)GroundUnitZoomBox).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroundUnitZoomBox).Location = new Point(379, 12);
		((Control)GroundUnitZoomBox).Name = "GroundUnitZoomBox";
		((Control)GroundUnitZoomBox).Size = new Size(344, 243);
		((Control)GroundUnitZoomBox).TabIndex = 77;
		((GroupBox)GroundUnitZoomBox).TabStop = false;
		TableLayoutPanel1.ColumnCount = 1;
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle((SizeType)2, 100f));
		TableLayoutPanel1.Controls.Add((Control)(object)DarkLabel1, 0, 7);
		TableLayoutPanel1.Controls.Add((Control)(object)TB_GeneralIConZoom, 0, 8);
		TableLayoutPanel1.Controls.Add((Control)(object)FlowerShapedIconZoomLabel, 0, 5);
		TableLayoutPanel1.Controls.Add((Control)(object)TB_Flower_Zoom, 0, 6);
		TableLayoutPanel1.Controls.Add((Control)(object)TB_GroundUnit_Zoom, 0, 0);
		TableLayoutPanel1.Controls.Add((Control)(object)TB_Rectangle_Zoom, 0, 4);
		TableLayoutPanel1.Controls.Add((Control)(object)DiamondShapedIconZoomLabel, 0, 1);
		TableLayoutPanel1.Controls.Add((Control)(object)RectangleShapedIconZoomLabel, 0, 3);
		TableLayoutPanel1.Controls.Add((Control)(object)TB_Diamond_Zoom, 0, 2);
		((Control)TableLayoutPanel1).Location = new Point(3, 19);
		((Control)TableLayoutPanel1).Name = "TableLayoutPanel1";
		TableLayoutPanel1.RowCount = 7;
		TableLayoutPanel1.RowStyles.Add(new RowStyle((SizeType)1, 30f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle((SizeType)2, 33.33333f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle((SizeType)1, 27f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle((SizeType)2, 33.33333f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle((SizeType)1, 30f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle((SizeType)2, 33.33333f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle((SizeType)1, 34f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle((SizeType)1, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle((SizeType)1, 29f));
		((Control)TableLayoutPanel1).Size = new Size(338, 216);
		((Control)TableLayoutPanel1).TabIndex = 50;
		TB_Flower_Zoom.AutoSize = false;
		TB_Flower_Zoom.LargeChange = 20;
		((Control)TB_Flower_Zoom).Location = new Point(3, 132);
		TB_Flower_Zoom.Maximum = 100;
		TB_Flower_Zoom.Minimum = 10;
		((Control)TB_Flower_Zoom).Name = "TB_Flower_Zoom";
		((Control)TB_Flower_Zoom).Size = new Size(332, 28);
		TB_Flower_Zoom.SmallChange = 10;
		((Control)TB_Flower_Zoom).TabIndex = 48;
		TB_Flower_Zoom.TickFrequency = 10;
		TB_Flower_Zoom.Value = 20;
		TB_GroundUnit_Zoom.AutoSize = false;
		TB_GroundUnit_Zoom.LargeChange = 20;
		((Control)TB_GroundUnit_Zoom).Location = new Point(3, 3);
		TB_GroundUnit_Zoom.Maximum = 100;
		TB_GroundUnit_Zoom.Minimum = 10;
		((Control)TB_GroundUnit_Zoom).Name = "TB_GroundUnit_Zoom";
		((Control)TB_GroundUnit_Zoom).Size = new Size(332, 24);
		TB_GroundUnit_Zoom.SmallChange = 10;
		((Control)TB_GroundUnit_Zoom).TabIndex = 42;
		TB_GroundUnit_Zoom.TickFrequency = 10;
		TB_GroundUnit_Zoom.Value = 20;
		TB_Rectangle_Zoom.AutoSize = false;
		TB_Rectangle_Zoom.LargeChange = 20;
		((Control)TB_Rectangle_Zoom).Location = new Point(3, 88);
		TB_Rectangle_Zoom.Maximum = 100;
		TB_Rectangle_Zoom.Minimum = 10;
		((Control)TB_Rectangle_Zoom).Name = "TB_Rectangle_Zoom";
		((Control)TB_Rectangle_Zoom).Size = new Size(332, 24);
		TB_Rectangle_Zoom.SmallChange = 10;
		((Control)TB_Rectangle_Zoom).TabIndex = 46;
		TB_Rectangle_Zoom.TickFrequency = 10;
		TB_Rectangle_Zoom.Value = 20;
		RectangleShapedIconZoomLabel.AutoSize = true;
		((Control)RectangleShapedIconZoomLabel).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)RectangleShapedIconZoomLabel).Location = new Point(3, 71);
		((Control)RectangleShapedIconZoomLabel).Name = "RectangleShapedIconZoomLabel";
		((Control)RectangleShapedIconZoomLabel).Size = new Size(162, 14);
		((Control)RectangleShapedIconZoomLabel).TabIndex = 47;
		((Label)RectangleShapedIconZoomLabel).Text = "Rectangle Shaped Icon Zoom";
		((Label)RectangleShapedIconZoomLabel).TextAlign = (ContentAlignment)256;
		TB_Diamond_Zoom.AutoSize = false;
		TB_Diamond_Zoom.LargeChange = 20;
		((Control)TB_Diamond_Zoom).Location = new Point(3, 47);
		TB_Diamond_Zoom.Maximum = 100;
		TB_Diamond_Zoom.Minimum = 10;
		((Control)TB_Diamond_Zoom).Name = "TB_Diamond_Zoom";
		((Control)TB_Diamond_Zoom).Size = new Size(332, 21);
		TB_Diamond_Zoom.SmallChange = 10;
		((Control)TB_Diamond_Zoom).TabIndex = 44;
		TB_Diamond_Zoom.TickFrequency = 10;
		TB_Diamond_Zoom.Value = 20;
		lbl_GU_Zoom.AutoSize = true;
		((Control)lbl_GU_Zoom).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)lbl_GU_Zoom).Location = new Point(5, 3);
		((Control)lbl_GU_Zoom).Name = "lbl_GU_Zoom";
		((Control)lbl_GU_Zoom).Size = new Size(107, 15);
		((Control)lbl_GU_Zoom).TabIndex = 43;
		((Label)lbl_GU_Zoom).Text = "Ground Unit Zoom";
		((ComboBox)CB_MissionAreaCourseDisplay).BackColor = Color.Transparent;
		((ComboBox)CB_MissionAreaCourseDisplay).DrawMode = (DrawMode)1;
		((ComboBox)CB_MissionAreaCourseDisplay).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_MissionAreaCourseDisplay).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_MissionAreaCourseDisplay).FormattingEnabled = true;
		((ComboBox)CB_MissionAreaCourseDisplay).Items.AddRange(new object[3] { "All", "Selected", "Do not Show" });
		((Control)CB_MissionAreaCourseDisplay).Location = new Point(182, 159);
		((Control)CB_MissionAreaCourseDisplay).Name = "CB_MissionAreaCourseDisplay";
		((Control)CB_MissionAreaCourseDisplay).Size = new Size(150, 21);
		((Control)CB_MissionAreaCourseDisplay).TabIndex = 81;
		((Control)MapMarkerDisplayBox).Controls.Add((Control)(object)LabelSeaIceColor);
		((Control)MapMarkerDisplayBox).Controls.Add((Control)(object)darkUIButton5);
		((Control)MapMarkerDisplayBox).Controls.Add((Control)(object)LabelBorderColor);
		((Control)MapMarkerDisplayBox).Controls.Add((Control)(object)darkUIButton4);
		((Control)MapMarkerDisplayBox).Controls.Add((Control)(object)LabelPlottedCourseColor);
		((Control)MapMarkerDisplayBox).Controls.Add((Control)(object)darkLabel8);
		((Control)MapMarkerDisplayBox).Controls.Add((Control)(object)darkUIButton3);
		((Control)MapMarkerDisplayBox).Controls.Add((Control)(object)CB_RefPointVisibility);
		((Control)MapMarkerDisplayBox).Controls.Add((Control)(object)CB_MissionAreaCourseDisplay);
		((Control)MapMarkerDisplayBox).Controls.Add((Control)(object)darkLabel4);
		((Control)MapMarkerDisplayBox).Controls.Add((Control)(object)darkLabel15);
		((Control)MapMarkerDisplayBox).Controls.Add((Control)(object)CP_ShowPlottedPaths);
		((Control)MapMarkerDisplayBox).Controls.Add((Control)(object)darkLabel3);
		((Control)MapMarkerDisplayBox).Controls.Add((Control)(object)CP_ShowFlightPlans_Airborne);
		((Control)MapMarkerDisplayBox).Controls.Add((Control)(object)darkLabel2);
		((Control)MapMarkerDisplayBox).Controls.Add((Control)(object)darkLabel7);
		((Control)MapMarkerDisplayBox).Controls.Add((Control)(object)CP_ShowFlightPlans_Planned);
		((Control)MapMarkerDisplayBox).Controls.Add((Control)(object)CB_MapCursorBox);
		((Control)MapMarkerDisplayBox).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)MapMarkerDisplayBox).Location = new Point(382, 413);
		((Control)MapMarkerDisplayBox).Name = "MapMarkerDisplayBox";
		((Control)MapMarkerDisplayBox).Size = new Size(341, 275);
		((Control)MapMarkerDisplayBox).TabIndex = 83;
		((GroupBox)MapMarkerDisplayBox).TabStop = false;
		((GroupBox)MapMarkerDisplayBox).Text = "Map Marker Display";
		((Control)LabelSeaIceColor).BackColor = Color.White;
		((Control)LabelSeaIceColor).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)LabelSeaIceColor).Location = new Point(7, 244);
		((Control)LabelSeaIceColor).Name = "LabelSeaIceColor";
		((Control)LabelSeaIceColor).Size = new Size(19, 19);
		((Control)LabelSeaIceColor).TabIndex = 89;
		((Control)LabelBorderColor).BackColor = Color.White;
		((Control)LabelBorderColor).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)LabelBorderColor).Location = new Point(7, 215);
		((Control)LabelBorderColor).Name = "LabelBorderColor";
		((Control)LabelBorderColor).Size = new Size(19, 19);
		((Control)LabelBorderColor).TabIndex = 87;
		((Control)LabelPlottedCourseColor).BackColor = Color.White;
		((Control)LabelPlottedCourseColor).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)LabelPlottedCourseColor).Location = new Point(7, 186);
		((Control)LabelPlottedCourseColor).Name = "LabelPlottedCourseColor";
		((Control)LabelPlottedCourseColor).Size = new Size(19, 19);
		((Control)LabelPlottedCourseColor).TabIndex = 85;
		((Control)SignalsDisplayBox).Controls.Add((Control)(object)darkLabel20);
		((Control)SignalsDisplayBox).Controls.Add((Control)(object)CB_DisplayEmissionsFor);
		((Control)SignalsDisplayBox).Controls.Add((Control)(object)darkLabel19);
		((Control)SignalsDisplayBox).Controls.Add((Control)(object)CB_ContactEmissionsDisplay);
		((Control)SignalsDisplayBox).Controls.Add((Control)(object)darkLabel18);
		((Control)SignalsDisplayBox).Controls.Add((Control)(object)CB_Datalinks);
		((Control)SignalsDisplayBox).Controls.Add((Control)(object)darkLabel17);
		((Control)SignalsDisplayBox).Controls.Add((Control)(object)CB_TargetingVectors);
		((Control)SignalsDisplayBox).Controls.Add((Control)(object)darkLabel16);
		((Control)SignalsDisplayBox).Controls.Add((Control)(object)CB_IlluminationVectors);
		((Control)SignalsDisplayBox).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)SignalsDisplayBox).Location = new Point(382, 254);
		((Control)SignalsDisplayBox).Name = "SignalsDisplayBox";
		((Control)SignalsDisplayBox).Size = new Size(339, 157);
		((Control)SignalsDisplayBox).TabIndex = 84;
		((GroupBox)SignalsDisplayBox).TabStop = false;
		((GroupBox)SignalsDisplayBox).Text = "Signals Display";
		((ComboBox)CB_DisplayEmissionsFor).BackColor = Color.Transparent;
		((ComboBox)CB_DisplayEmissionsFor).DrawMode = (DrawMode)1;
		((ComboBox)CB_DisplayEmissionsFor).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_DisplayEmissionsFor).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_DisplayEmissionsFor).FormattingEnabled = true;
		((ComboBox)CB_DisplayEmissionsFor).Items.AddRange(new object[3] { "All", "None", "Selected Contact" });
		((Control)CB_DisplayEmissionsFor).Location = new Point(181, 130);
		((Control)CB_DisplayEmissionsFor).Name = "CB_DisplayEmissionsFor";
		((Control)CB_DisplayEmissionsFor).Size = new Size(149, 21);
		((Control)CB_DisplayEmissionsFor).TabIndex = 92;
		((ComboBox)CB_ContactEmissionsDisplay).BackColor = Color.Transparent;
		((ComboBox)CB_ContactEmissionsDisplay).DrawMode = (DrawMode)1;
		((ComboBox)CB_ContactEmissionsDisplay).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_ContactEmissionsDisplay).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_ContactEmissionsDisplay).FormattingEnabled = true;
		((ComboBox)CB_ContactEmissionsDisplay).Items.AddRange(new object[3] { "All", "Selected Contact", "Do not Show" });
		((Control)CB_ContactEmissionsDisplay).Location = new Point(179, 103);
		((Control)CB_ContactEmissionsDisplay).Name = "CB_ContactEmissionsDisplay";
		((Control)CB_ContactEmissionsDisplay).Size = new Size(150, 21);
		((Control)CB_ContactEmissionsDisplay).TabIndex = 90;
		((ComboBox)CB_Datalinks).BackColor = Color.Transparent;
		((ComboBox)CB_Datalinks).DrawMode = (DrawMode)1;
		((ComboBox)CB_Datalinks).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_Datalinks).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_Datalinks).FormattingEnabled = true;
		((ComboBox)CB_Datalinks).Items.AddRange(new object[3] { "All", "Selected Unit", "Do not Show" });
		((Control)CB_Datalinks).Location = new Point(179, 76);
		((Control)CB_Datalinks).Name = "CB_Datalinks";
		((Control)CB_Datalinks).Size = new Size(150, 21);
		((Control)CB_Datalinks).TabIndex = 88;
		((ComboBox)CB_TargetingVectors).BackColor = Color.Transparent;
		((ComboBox)CB_TargetingVectors).DrawMode = (DrawMode)1;
		((ComboBox)CB_TargetingVectors).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_TargetingVectors).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_TargetingVectors).FormattingEnabled = true;
		((ComboBox)CB_TargetingVectors).Items.AddRange(new object[3] { "All", "Selected Unit", "Do not Show" });
		((Control)CB_TargetingVectors).Location = new Point(179, 49);
		((Control)CB_TargetingVectors).Name = "CB_TargetingVectors";
		((Control)CB_TargetingVectors).Size = new Size(150, 21);
		((Control)CB_TargetingVectors).TabIndex = 86;
		((ComboBox)CB_IlluminationVectors).BackColor = Color.Transparent;
		((ComboBox)CB_IlluminationVectors).DrawMode = (DrawMode)1;
		((ComboBox)CB_IlluminationVectors).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_IlluminationVectors).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_IlluminationVectors).FormattingEnabled = true;
		((ComboBox)CB_IlluminationVectors).Items.AddRange(new object[3] { "All", "Selected Unit", "Do not Show" });
		((Control)CB_IlluminationVectors).Location = new Point(179, 22);
		((Control)CB_IlluminationVectors).Name = "CB_IlluminationVectors";
		((Control)CB_IlluminationVectors).Size = new Size(150, 21);
		((Control)CB_IlluminationVectors).TabIndex = 84;
		((ButtonBase)SetPersonalMapProfileButton).BackColor = Color.Transparent;
		((Control)SetPersonalMapProfileButton).ForeColor = SystemColors.Control;
		((Control)SetPersonalMapProfileButton).Location = new Point(381, 695);
		((Control)SetPersonalMapProfileButton).Name = "SetPersonalMapProfileButton";
		((Control)SetPersonalMapProfileButton).Padding = new Padding(5);
		SetPersonalMapProfileButton.RoundRadius = 0;
		((Control)SetPersonalMapProfileButton).Size = new Size(157, 23);
		((Control)SetPersonalMapProfileButton).TabIndex = 85;
		SetPersonalMapProfileButton.Text = "Save current as \"personal\"";
		((ButtonBase)UsePersonalMapProfileCheckBox).AutoSize = true;
		((Control)UsePersonalMapProfileCheckBox).Location = new Point(554, 698);
		((Control)UsePersonalMapProfileCheckBox).Name = "UsePersonalMapProfileCheckBox";
		((Control)UsePersonalMapProfileCheckBox).Size = new Size(157, 19);
		((Control)UsePersonalMapProfileCheckBox).TabIndex = 86;
		((ButtonBase)UsePersonalMapProfileCheckBox).Text = "Use personal map profile";
		DiamondShapedIconZoomLabel.AutoSize = true;
		((Control)DiamondShapedIconZoomLabel).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DiamondShapedIconZoomLabel).Location = new Point(3, 30);
		((Control)DiamondShapedIconZoomLabel).Name = "DiamondShapedIconZoomLabel";
		((Control)DiamondShapedIconZoomLabel).Size = new Size(159, 14);
		((Control)DiamondShapedIconZoomLabel).TabIndex = 45;
		((Label)DiamondShapedIconZoomLabel).Text = "Diamond Shaped Icon Zoom";
		((Label)DiamondShapedIconZoomLabel).TextAlign = (ContentAlignment)256;
		FlowerShapedIconZoomLabel.AutoSize = true;
		((Control)FlowerShapedIconZoomLabel).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)FlowerShapedIconZoomLabel).Location = new Point(3, 115);
		((Control)FlowerShapedIconZoomLabel).Name = "FlowerShapedIconZoomLabel";
		((Control)FlowerShapedIconZoomLabel).Size = new Size(145, 14);
		((Control)FlowerShapedIconZoomLabel).TabIndex = 51;
		((Label)FlowerShapedIconZoomLabel).Text = "Flower Shaped Icon Zoom";
		((Label)FlowerShapedIconZoomLabel).TextAlign = (ContentAlignment)256;
		DarkLabel1.AutoSize = true;
		((Control)DarkLabel1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel1).Location = new Point(3, 163);
		((Control)DarkLabel1).Name = "DarkLabel1";
		((Control)DarkLabel1).Size = new Size(108, 15);
		((Control)DarkLabel1).TabIndex = 53;
		((Label)DarkLabel1).Text = "General Icon Zoom";
		((Label)DarkLabel1).TextAlign = (ContentAlignment)256;
		TB_GeneralIConZoom.AutoSize = false;
		((Control)TB_GeneralIConZoom).Dock = (DockStyle)5;
		TB_GeneralIConZoom.LargeChange = 20;
		((Control)TB_GeneralIConZoom).Location = new Point(3, 188);
		TB_GeneralIConZoom.Maximum = 100;
		TB_GeneralIConZoom.Minimum = 10;
		((Control)TB_GeneralIConZoom).Name = "TB_GeneralIConZoom";
		((Control)TB_GeneralIConZoom).Size = new Size(332, 25);
		TB_GeneralIConZoom.SmallChange = 10;
		((Control)TB_GeneralIConZoom).TabIndex = 52;
		TB_GeneralIConZoom.TickFrequency = 10;
		TB_GeneralIConZoom.Value = 20;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(7f, 15f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).AutoScroll = true;
		((Form)this).ClientSize = new Size(744, 726);
		((Control)this).Controls.Add((Control)(object)UsePersonalMapProfileCheckBox);
		((Control)this).Controls.Add((Control)(object)SetPersonalMapProfileButton);
		((Control)this).Controls.Add((Control)(object)SignalsDisplayBox);
		((Control)this).Controls.Add((Control)(object)MapMarkerDisplayBox);
		((Control)this).Controls.Add((Control)(object)GroundUnitZoomBox);
		((Control)this).Controls.Add((Control)(object)darkGroupBox2);
		((Control)this).Controls.Add((Control)(object)darkGroupBox);
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MaximumSize = new Size(760, 770);
		((Form)this).MinimizeBox = false;
		((Form)this).MinimumSize = new Size(760, 100);
		((Control)this).Name = "MapSettings";
		((Form)this).ShowIcon = false;
		((Form)this).Text = "Map Settings";
		((ISupportInitialize)val).EndInit();
		((ISupportInitialize)val2).EndInit();
		((ISupportInitialize)val3).EndInit();
		((ISupportInitialize)val4).EndInit();
		((ISupportInitialize)val5).EndInit();
		((ISupportInitialize)val6).EndInit();
		((ISupportInitialize)val7).EndInit();
		((ISupportInitialize)val8).EndInit();
		((Control)darkGroupBox).ResumeLayout(false);
		((Control)darkGroupBox).PerformLayout();
		((ISupportInitialize)val9).EndInit();
		((Control)darkGroupBox2).ResumeLayout(false);
		((Control)darkGroupBox2).PerformLayout();
		((Control)GroundUnitZoomBox).ResumeLayout(false);
		((Control)GroundUnitZoomBox).PerformLayout();
		((Control)TableLayoutPanel1).ResumeLayout(false);
		((Control)TableLayoutPanel1).PerformLayout();
		((ISupportInitialize)TB_Flower_Zoom).EndInit();
		((ISupportInitialize)TB_GroundUnit_Zoom).EndInit();
		((ISupportInitialize)TB_Rectangle_Zoom).EndInit();
		((ISupportInitialize)TB_Diamond_Zoom).EndInit();
		((Control)MapMarkerDisplayBox).ResumeLayout(false);
		((Control)MapMarkerDisplayBox).PerformLayout();
		((Control)SignalsDisplayBox).ResumeLayout(false);
		((Control)SignalsDisplayBox).PerformLayout();
		((ISupportInitialize)TB_GeneralIConZoom).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MapSettings_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		RefreshMapSettings();
	}

	internal void RefreshMapSettings()
	{
		try
		{
			if (!Client.Realtime)
			{
				if (bool_2)
				{
					bool_2 = false;
					((ComboBox)CB_IlluminationVectors).Items.Insert(0, (object)"All");
					((ComboBox)CB_TargetingVectors).Items.Insert(0, (object)"All");
					((ComboBox)CB_DisplayDatablocks).Items.Insert(0, (object)"All");
					((ComboBox)CB_Datalinks).Items.Insert(0, (object)"All");
					((ComboBox)CP_ShowFlightPlans_Airborne).Items.Insert(0, (object)"All");
					((ComboBox)CB_ShowContrail).Items.Insert(0, (object)"All");
					((ComboBox)CB_ShowWakeAndCavitation).Items.Insert(0, (object)"All");
				}
			}
			else
			{
				bool_2 = true;
				((ComboBox)CB_IlluminationVectors).Items.Remove((object)"All");
				if (Client.CurrentMapProfile.ShowIlluminationVectors == MapProfile._ShowElement.All)
				{
					Client.CurrentMapProfile.ShowIlluminationVectors = MapProfile._ShowElement.SelectedUnit;
				}
				((ComboBox)CB_TargetingVectors).Items.Remove((object)"All");
				if (Client.CurrentMapProfile.ShowTargetingVectors == MapProfile._ShowElement.All)
				{
					Client.CurrentMapProfile.ShowTargetingVectors = MapProfile._ShowElement.SelectedUnit;
				}
				((ComboBox)CB_DisplayDatablocks).Items.Remove((object)"All");
				if (Client.CurrentMapProfile.ShowDatablocks == MapProfile._ShowElement.All)
				{
					Client.CurrentMapProfile.ShowDatablocks = MapProfile._ShowElement.SelectedUnit;
				}
				((ComboBox)CB_Datalinks).Items.Remove((object)"All");
				if (Client.CurrentMapProfile.ShowDatalinks == MapProfile._ShowElement.All)
				{
					Client.CurrentMapProfile.ShowDatalinks = MapProfile._ShowElement.SelectedUnit;
				}
				((ComboBox)CP_ShowFlightPlans_Airborne).Items.Remove((object)"All");
				if (gamePreferences_0.ShowFlightPlans_Airborne == Game.GamePreferences.FlightPlansVisibilitySetting_Airborne.All)
				{
					gamePreferences_0.ShowFlightPlans_Airborne = Game.GamePreferences.FlightPlansVisibilitySetting_Airborne.SelectedUnit;
				}
				((ComboBox)CB_ShowContrail).Items.Remove((object)"All");
				if (gamePreferences_0.ShowContrails == Game.GamePreferences.ContrailsVisibilitySetting.All)
				{
					gamePreferences_0.ShowContrails = Game.GamePreferences.ContrailsVisibilitySetting.SelectedUnit;
				}
				((ComboBox)CB_ShowWakeAndCavitation).Items.Remove((object)"All");
				if (gamePreferences_0.ShowWakeCavitation == Game.GamePreferences.WakeCavitationVisibilitySetting.All)
				{
					gamePreferences_0.ShowWakeCavitation = Game.GamePreferences.WakeCavitationVisibilitySetting.SelectedUnit;
				}
			}
			if (GameGeneral.Beta_PlatformComms)
			{
				((Control)COMMSRangeCheckBox).Visible = true;
				((Control)COMMSRangeColor).Visible = true;
			}
			else
			{
				((Control)COMMSRangeCheckBox).Visible = false;
				((Control)COMMSRangeColor).Visible = false;
				((CheckBox)COMMSRangeCheckBox).Checked = false;
				Client.CurrentMapProfile.RangeSymbol_COMMS = MapProfile._ShowElement.DontShow;
			}
			((ComboBox)CB_ShowRangeIndicators).SelectedIndex = (byte)Client.CurrentMapProfile.ShowRangeSymbols;
			((CheckBox)AirSensorsCheckBox).Checked = Client.CurrentMapProfile.RangeSymbol_AASensor != MapProfile._ShowElement.DontShow;
			((CheckBox)SurfaceSensorsCheckBox).Checked = Client.CurrentMapProfile.RangeSymbol_ASSensor != MapProfile._ShowElement.DontShow;
			((CheckBox)UnderwaterSensorsCheckBox).Checked = Client.CurrentMapProfile.RangeSymbol_ASWSensor != MapProfile._ShowElement.DontShow;
			((CheckBox)AirWeaponsCheckBox).Checked = Client.CurrentMapProfile.RangeSymbol_AAWeapon != MapProfile._ShowElement.DontShow;
			((CheckBox)SurfaceWeaponsCheckBox).Checked = Client.CurrentMapProfile.RangeSymbol_ASWeapon != MapProfile._ShowElement.DontShow;
			((CheckBox)LandWeaponsCheckBox).Checked = Client.CurrentMapProfile.RangeSymbol_AGWeapon != MapProfile._ShowElement.DontShow;
			((CheckBox)UnderwaterWeaponsCheckBox).Checked = Client.CurrentMapProfile.RangeSymbol_ASWWeapon != MapProfile._ShowElement.DontShow;
			((CheckBox)AircraftRangeCheckBox).Checked = Client.CurrentMapProfile.RangeSymbol_ACRange != MapProfile._ShowElement.DontShow;
			((CheckBox)COMMSRangeCheckBox).Checked = Client.CurrentMapProfile.RangeSymbol_COMMS != MapProfile._ShowElement.DontShow;
			((CheckBox)ShowNonFriendlyRangeSymbolsCheckBox).Checked = Client.CurrentMapProfile.ShowNonFriendly;
			((CheckBox)MergeRangeSymbolsCheckBox).Checked = Client.CurrentMapProfile.MergeRangeSymbols;
			((ComboBox)CB_GroupUnitView).SelectedIndex = (int)Client.CurrentMapProfile.ViewMode;
			((ComboBox)CP_ShowGhostedGroupMembers).SelectedIndex = (int)gamePreferences_0.ShowGhostedGroupMembers;
			((ComboBox)CB_MapSymbols).SelectedIndex = (int)gamePreferences_0.MapSymbolsSet;
			((ComboBox)CB_DisplayDatablocks).SelectedItem = method_46(Client.CurrentMapProfile.ShowDatablocks);
			((ComboBox)CB_DisplayDatablockType).SelectedIndex = (byte)Client.CurrentMapProfile.ShowDataBlockType;
			switch (gamePreferences_0.ShowWakeCavitation)
			{
			case Game.GamePreferences.WakeCavitationVisibilitySetting.All:
				((ComboBox)CB_ShowWakeAndCavitation).SelectedItem = "All";
				break;
			case Game.GamePreferences.WakeCavitationVisibilitySetting.SelectedUnit:
				((ComboBox)CB_ShowWakeAndCavitation).SelectedItem = "Selected Unit";
				break;
			case Game.GamePreferences.WakeCavitationVisibilitySetting.DontShow:
				((ComboBox)CB_ShowWakeAndCavitation).SelectedItem = "None";
				break;
			}
			switch (gamePreferences_0.ShowContrails)
			{
			case Game.GamePreferences.ContrailsVisibilitySetting.All:
				((ComboBox)CB_ShowContrail).SelectedItem = "All";
				break;
			case Game.GamePreferences.ContrailsVisibilitySetting.SelectedUnit:
				((ComboBox)CB_ShowContrail).SelectedItem = "Selected Unit";
				break;
			case Game.GamePreferences.ContrailsVisibilitySetting.DontShow:
				((ComboBox)CB_ShowContrail).SelectedItem = "None";
				break;
			}
			((ComboBox)CB_SonobuoyVisibility).SelectedIndex = (int)gamePreferences_0.SonobuoyVisibility;
			((ComboBox)CP_ShowAU_Behaviour_Bark).SelectedIndex = (int)gamePreferences_0.ShowAU_Behaviour_Bark;
			((CheckBox)ShowOutlinesCheckBox).Checked = gamePreferences_0.DrawOutlines;
			((CheckBox)ColoredDatablocksCheckBox).Checked = Client.CurrentMapProfile.ColorDatablocks;
			((CheckBox)ShowDynamicNoiseCheckBox).Checked = Client.CurrentMapProfile.ShowDynamicNoiseSignature;
			method_30(TB_GroundUnit_Zoom, gamePreferences_0.GroundUnitZoom);
			method_30(TB_Diamond_Zoom, gamePreferences_0.DiamondZoom);
			method_30(TB_Rectangle_Zoom, gamePreferences_0.RectangleZoom);
			method_30(TB_Flower_Zoom, gamePreferences_0.FlowerZoom);
			((ComboBox)CB_RefPointVisibility).SelectedIndex = (int)gamePreferences_0.RefPointVisibility;
			((ComboBox)CB_MapCursorBox).SelectedIndex = (int)gamePreferences_0.MapCursorBox;
			((ComboBox)CP_ShowPlottedPaths).SelectedIndex = (int)gamePreferences_0.ShowPlottedPaths;
			switch (gamePreferences_0.ShowFlightPlans_Airborne)
			{
			case Game.GamePreferences.FlightPlansVisibilitySetting_Airborne.All:
				((ComboBox)CP_ShowFlightPlans_Airborne).SelectedItem = "All";
				break;
			case Game.GamePreferences.FlightPlansVisibilitySetting_Airborne.SelectedUnit:
				((ComboBox)CP_ShowFlightPlans_Airborne).SelectedItem = "Selected Unit";
				break;
			case Game.GamePreferences.FlightPlansVisibilitySetting_Airborne.DontShow:
				((ComboBox)CP_ShowFlightPlans_Airborne).SelectedItem = "None";
				break;
			}
			((ComboBox)CP_ShowFlightPlans_Planned).SelectedIndex = (int)gamePreferences_0.ShowFlightPlans_Planned;
			((ComboBox)CB_MissionAreaCourseDisplay).SelectedIndex = (byte)gamePreferences_0.ShowMissionArea;
			((Control)LabelPlottedCourseColor).BackColor = Client.CurrentMapProfile.WPColor;
			((Control)LabelBorderColor).BackColor = Client.CurrentMapProfile.BorderColor;
			((Control)LabelSeaIceColor).BackColor = Client.CurrentMapProfile.SeaIceColor;
			((ComboBox)CB_IlluminationVectors).SelectedItem = method_46(Client.CurrentMapProfile.ShowIlluminationVectors);
			((ComboBox)CB_TargetingVectors).SelectedItem = method_46(Client.CurrentMapProfile.ShowTargetingVectors);
			((ComboBox)CB_Datalinks).SelectedItem = method_46(Client.CurrentMapProfile.ShowDatalinks);
			((ComboBox)CB_ContactEmissionsDisplay).SelectedIndex = (byte)Client.CurrentMapProfile.ShowContactEmissions;
			((ComboBox)CB_DisplayEmissionsFor).SelectedIndex = (byte)Client.CurrentMapProfile.ShowContactEmissions_Details;
			if (GameGeneral.Beta_PlatformComms)
			{
				((Control)COMMSRangeCheckBox).Visible = true;
				((Control)COMMSRangeColor).Visible = true;
			}
			else
			{
				((Control)COMMSRangeCheckBox).Visible = false;
				((Control)COMMSRangeColor).Visible = false;
			}
			((CheckBox)UsePersonalMapProfileCheckBox).Checked = gamePreferences_0.UsePersonalMapProfile;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 343367632", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_2(object sender, EventArgs e)
	{
		method_4(bool_4: true);
	}

	private void method_3(object sender, EventArgs e)
	{
		method_4(bool_4: false);
	}

	private void method_4(bool bool_4)
	{
		MyProject.Forms.MainForm.TSMI_AircraftRange.Checked = bool_4;
		((ToolStripMenuItem)MyProject.Forms.MainForm.AirSensorsToolStripMenuItem).Checked = bool_4;
		((ToolStripMenuItem)MyProject.Forms.MainForm.LandWeaponsToolStripMenuItem).Checked = bool_4;
		((ToolStripMenuItem)MyProject.Forms.MainForm.UnderwaterWeaponsToolStripMenuItem).Checked = bool_4;
		((ToolStripMenuItem)MyProject.Forms.MainForm.SurfaceWeaponsToolStripMenuItem).Checked = bool_4;
		((ToolStripMenuItem)MyProject.Forms.MainForm.AirWeaponsToolStripMenuItem).Checked = bool_4;
		((ToolStripMenuItem)MyProject.Forms.MainForm.UnderwaterSensorsToolStripMenuItem).Checked = bool_4;
		((ToolStripMenuItem)MyProject.Forms.MainForm.SurfaceSensorsToolStripMenuItem).Checked = bool_4;
		((ToolStripMenuItem)MyProject.Forms.MainForm.CommDevicesToolStripMenuItem).Checked = bool_4;
		((CheckBox)AirSensorsCheckBox).Checked = bool_4;
		((CheckBox)SurfaceSensorsCheckBox).Checked = bool_4;
		((CheckBox)UnderwaterSensorsCheckBox).Checked = bool_4;
		((CheckBox)AirWeaponsCheckBox).Checked = bool_4;
		((CheckBox)SurfaceWeaponsCheckBox).Checked = bool_4;
		((CheckBox)LandWeaponsCheckBox).Checked = bool_4;
		((CheckBox)UnderwaterWeaponsCheckBox).Checked = bool_4;
		((CheckBox)AircraftRangeCheckBox).Checked = bool_4;
		((CheckBox)COMMSRangeCheckBox).Checked = bool_4;
		if (!bool_4)
		{
			Client.CurrentMapProfile.RangeSymbol_ASWWeapon = MapProfile._ShowElement.DontShow;
			Client.CurrentMapProfile.RangeSymbol_AGWeapon = MapProfile._ShowElement.DontShow;
			Client.CurrentMapProfile.RangeSymbol_ASWeapon = MapProfile._ShowElement.DontShow;
			Client.CurrentMapProfile.RangeSymbol_AAWeapon = MapProfile._ShowElement.DontShow;
			Client.CurrentMapProfile.RangeSymbol_ASWSensor = MapProfile._ShowElement.DontShow;
			Client.CurrentMapProfile.RangeSymbol_ASSensor = MapProfile._ShowElement.DontShow;
			Client.CurrentMapProfile.RangeSymbol_AASensor = MapProfile._ShowElement.DontShow;
			Client.CurrentMapProfile.RangeSymbol_ACRange = MapProfile._ShowElement.DontShow;
		}
		else
		{
			Client.CurrentMapProfile.RangeSymbol_ACRange = MapProfile._ShowElement.SelectedUnit;
			if (Client.CurrentMapProfile.ShowRangeSymbols == MapProfile._ShowElement.SelectedUnit)
			{
				Client.CurrentMapProfile.RangeSymbol_ASWWeapon = MapProfile._ShowElement.SelectedUnit;
				Client.CurrentMapProfile.RangeSymbol_AGWeapon = MapProfile._ShowElement.SelectedUnit;
				Client.CurrentMapProfile.RangeSymbol_ASWeapon = MapProfile._ShowElement.SelectedUnit;
				Client.CurrentMapProfile.RangeSymbol_AAWeapon = MapProfile._ShowElement.SelectedUnit;
				Client.CurrentMapProfile.RangeSymbol_ASWSensor = MapProfile._ShowElement.SelectedUnit;
				Client.CurrentMapProfile.RangeSymbol_ASSensor = MapProfile._ShowElement.SelectedUnit;
				Client.CurrentMapProfile.RangeSymbol_AASensor = MapProfile._ShowElement.SelectedUnit;
			}
			else if (Client.CurrentMapProfile.ShowRangeSymbols == MapProfile._ShowElement.All)
			{
				Client.CurrentMapProfile.RangeSymbol_ASWWeapon = MapProfile._ShowElement.All;
				Client.CurrentMapProfile.RangeSymbol_AGWeapon = MapProfile._ShowElement.All;
				Client.CurrentMapProfile.RangeSymbol_ASWeapon = MapProfile._ShowElement.All;
				Client.CurrentMapProfile.RangeSymbol_AAWeapon = MapProfile._ShowElement.All;
				Client.CurrentMapProfile.RangeSymbol_ASWSensor = MapProfile._ShowElement.All;
				Client.CurrentMapProfile.RangeSymbol_ASSensor = MapProfile._ShowElement.All;
				Client.CurrentMapProfile.RangeSymbol_AASensor = MapProfile._ShowElement.All;
			}
		}
		MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
	}

	private void method_5(object sender, EventArgs e)
	{
		Client.CurrentMapProfile.ShowRangeSymbols = (MapProfile._ShowElement)((ComboBox)CB_ShowRangeIndicators).SelectedIndex;
		MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
		MyProject.Forms.Options.RefreshOptions();
	}

	private MapProfile._ShowElement method_6(bool bool_4)
	{
		if (!bool_4)
		{
			return MapProfile._ShowElement.DontShow;
		}
		return Client.CurrentMapProfile.ShowRangeSymbols;
	}

	private void method_7(object sender, EventArgs e)
	{
		Client.CurrentMapProfile.RangeSymbol_AASensor = method_6(((CheckBox)AirSensorsCheckBox).Checked);
		MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
	}

	private void method_8(object sender, EventArgs e)
	{
		Client.CurrentMapProfile.RangeSymbol_ASSensor = method_6(((CheckBox)SurfaceSensorsCheckBox).Checked);
		MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
	}

	private void method_9(object sender, EventArgs e)
	{
		Client.CurrentMapProfile.RangeSymbol_ASWSensor = method_6(((CheckBox)UnderwaterSensorsCheckBox).Checked);
		MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
	}

	private void method_10(object sender, EventArgs e)
	{
		Client.CurrentMapProfile.RangeSymbol_AAWeapon = method_6(((CheckBox)AirWeaponsCheckBox).Checked);
		MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
	}

	private void method_11(object sender, EventArgs e)
	{
		Client.CurrentMapProfile.RangeSymbol_ASWeapon = method_6(((CheckBox)SurfaceWeaponsCheckBox).Checked);
		MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
	}

	private void method_12(object sender, EventArgs e)
	{
		Client.CurrentMapProfile.RangeSymbol_AGWeapon = method_6(((CheckBox)LandWeaponsCheckBox).Checked);
		MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
	}

	private void method_13(object sender, EventArgs e)
	{
		Client.CurrentMapProfile.RangeSymbol_ASWWeapon = method_6(((CheckBox)UnderwaterWeaponsCheckBox).Checked);
		MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
	}

	private void method_14(object sender, EventArgs e)
	{
		if (!((CheckBox)AircraftRangeCheckBox).Checked)
		{
			Client.CurrentMapProfile.RangeSymbol_ACRange = MapProfile._ShowElement.DontShow;
		}
		else
		{
			Client.CurrentMapProfile.RangeSymbol_ACRange = MapProfile._ShowElement.SelectedUnit;
		}
		MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
	}

	private void method_15(object sender, EventArgs e)
	{
		Client.CurrentMapProfile.ShowNonFriendly = ((CheckBox)ShowNonFriendlyRangeSymbolsCheckBox).Checked;
		MyProject.Forms.Options.RefreshOptions();
		MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
	}

	private void method_16(object sender, EventArgs e)
	{
		Client.CurrentMapProfile.MergeRangeSymbols = ((CheckBox)MergeRangeSymbolsCheckBox).Checked;
		MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
	}

	private void method_17(object sender, EventArgs e)
	{
		Client.CurrentMapProfile.RangeSymbol_COMMS = method_6(((CheckBox)COMMSRangeCheckBox).Checked);
		MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
	}

	private void method_18(object sender, EventArgs e)
	{
		Client.CurrentMapProfile.ViewMode = (MapProfile.MapViewMode)((ComboBox)CB_GroupUnitView).SelectedIndex;
		Client.MustRefreshMainForm = true;
		MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
	}

	private void method_19(object sender, EventArgs e)
	{
		gamePreferences_0.ShowGhostedGroupMembers = (Game.GamePreferences.GhostedGroupMembersVisibilitySetting)((ComboBox)CP_ShowGhostedGroupMembers).SelectedIndex;
		Client.MustRefreshMainForm = true;
		MyProject.Forms.Options.RefreshOptions();
		MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
	}

	private void method_20(object sender, EventArgs e)
	{
		gamePreferences_0.MapSymbolsSet = (Game.GamePreferences.MapSymbolsSetting)((ComboBox)CB_MapSymbols).SelectedIndex;
		Client.CacheMapUnitSymbols();
		MyProject.Forms.Options.RefreshOptions();
		MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
	}

	private void method_21(object sender, EventArgs e)
	{
		Client.CurrentMapProfile.ShowDatablocks = method_45(((ComboBox)CB_DisplayDatablocks).SelectedItem.ToString());
		Client.MustRefreshMainForm = true;
		MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
	}

	private void method_22(object sender, EventArgs e)
	{
		Client.CurrentMapProfile.ShowDataBlockType = (MapProfile._ShowDataBlocksTypes)((ComboBox)CB_DisplayDatablockType).SelectedIndex;
		Client.MustRefreshMainForm = true;
		MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
	}

	private void method_23(object sender, EventArgs e)
	{
		string text = ((ComboBox)CB_ShowWakeAndCavitation).SelectedItem.ToString();
		int mustRefreshMainForm;
		if (Operators.CompareString(text, "All", true) == 0)
		{
			gamePreferences_0.ShowWakeCavitation = Game.GamePreferences.WakeCavitationVisibilitySetting.All;
			mustRefreshMainForm = 1;
		}
		else if (Operators.CompareString(text, "Selected Unit", true) == 0)
		{
			gamePreferences_0.ShowWakeCavitation = Game.GamePreferences.WakeCavitationVisibilitySetting.SelectedUnit;
			mustRefreshMainForm = 1;
		}
		else if (Operators.CompareString(text, "None", true) != 0)
		{
			mustRefreshMainForm = 1;
		}
		else
		{
			gamePreferences_0.ShowWakeCavitation = Game.GamePreferences.WakeCavitationVisibilitySetting.DontShow;
			mustRefreshMainForm = 1;
		}
		Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
		MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
	}

	private void method_24(object sender, EventArgs e)
	{
		string text = ((ComboBox)CB_ShowContrail).SelectedItem.ToString();
		int mustRefreshMainForm;
		if (Operators.CompareString(text, "All", true) == 0)
		{
			gamePreferences_0.ShowContrails = Game.GamePreferences.ContrailsVisibilitySetting.All;
			mustRefreshMainForm = 1;
		}
		else if (Operators.CompareString(text, "Selected Unit", true) != 0)
		{
			if (Operators.CompareString(text, "None", true) != 0)
			{
				mustRefreshMainForm = 1;
			}
			else
			{
				gamePreferences_0.ShowContrails = Game.GamePreferences.ContrailsVisibilitySetting.DontShow;
				mustRefreshMainForm = 1;
			}
		}
		else
		{
			gamePreferences_0.ShowContrails = Game.GamePreferences.ContrailsVisibilitySetting.SelectedUnit;
			mustRefreshMainForm = 1;
		}
		Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
		MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
	}

	private void method_25(object sender, EventArgs e)
	{
		gamePreferences_0.SonobuoyVisibility = (Game.GamePreferences.SonobuoyVisibilitySetting)((ComboBox)CB_SonobuoyVisibility).SelectedIndex;
		Client.MustRefreshMainForm = true;
		MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
		MyProject.Forms.Options.RefreshOptions();
	}

	private void method_26(object sender, EventArgs e)
	{
		gamePreferences_0.ShowAU_Behaviour_Bark = (Game.GamePreferences.Unit_Behaviour_Bark)((ComboBox)CP_ShowAU_Behaviour_Bark).SelectedIndex;
		Client.MustRefreshMainForm = true;
		MyProject.Forms.Options.RefreshOptions();
		MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
	}

	private void method_27(object sender, EventArgs e)
	{
		gamePreferences_0.DrawOutlines = ((CheckBox)ShowOutlinesCheckBox).Checked;
		MyProject.Forms.Options.RefreshOptions();
	}

	private void method_28(object sender, EventArgs e)
	{
		Client.CurrentMapProfile.ColorDatablocks = ((CheckBox)ColoredDatablocksCheckBox).Checked;
		MyProject.Forms.Options.RefreshOptions();
		Client.MustRefreshMainForm = true;
	}

	private void method_29(object sender, EventArgs e)
	{
		Client.CurrentMapProfile.ShowDynamicNoiseSignature = ((CheckBox)ShowDynamicNoiseCheckBox).Checked;
		MyProject.Forms.Options.RefreshOptions();
	}

	private void method_30(TrackBar trackBar_0, int int_0)
	{
		trackBar_0.Value = Math.Min(trackBar_0.Maximum, Math.Max(trackBar_0.Minimum, int_0));
	}

	private void method_31(object sender, EventArgs e)
	{
		int num = gamePreferences_0.GroundUnitZoom - TB_GroundUnit_Zoom.Value;
		gamePreferences_0.GroundUnitZoom = TB_GroundUnit_Zoom.Value;
		method_30(TB_Diamond_Zoom, gamePreferences_0.DiamondZoom - num);
		method_30(TB_Rectangle_Zoom, gamePreferences_0.RectangleZoom - num);
		method_30(TB_Flower_Zoom, gamePreferences_0.FlowerZoom - num);
		gamePreferences_0.DiamondZoom = TB_Diamond_Zoom.Value;
		gamePreferences_0.RectangleZoom = TB_Rectangle_Zoom.Value;
		gamePreferences_0.FlowerZoom = TB_Flower_Zoom.Value;
		Client.MustRefreshMainForm = true;
		MyProject.Forms.Options.RefreshOptions();
	}

	private void method_32(object sender, EventArgs e)
	{
		gamePreferences_0.DiamondZoom = TB_Diamond_Zoom.Value;
		Client.MustRefreshMainForm = true;
		MyProject.Forms.Options.RefreshOptions();
	}

	private void method_33(object sender, EventArgs e)
	{
		gamePreferences_0.RectangleZoom = TB_Rectangle_Zoom.Value;
		Client.MustRefreshMainForm = true;
		MyProject.Forms.Options.RefreshOptions();
	}

	private void method_34(object sender, EventArgs e)
	{
		gamePreferences_0.FlowerZoom = TB_Flower_Zoom.Value;
		Client.MustRefreshMainForm = true;
		MyProject.Forms.Options.RefreshOptions();
	}

	private void method_35(object sender, EventArgs e)
	{
		gamePreferences_0.IconZoom = TB_GeneralIConZoom.Value;
		Client.MustRefreshMainForm = true;
		MyProject.Forms.Options.RefreshOptions();
	}

	private void method_36(object sender, EventArgs e)
	{
		gamePreferences_0.RefPointVisibility = (Game.GamePreferences.RefPointVisibilitySetting)((ComboBox)CB_RefPointVisibility).SelectedIndex;
		Client.MustRefreshMainForm = true;
		MyProject.Forms.Options.RefreshOptions();
		MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
	}

	private void method_37(object sender, EventArgs e)
	{
		gamePreferences_0.MapCursorBox = (Game.GamePreferences.MapCursorBoxVisibilitySetting)((ComboBox)CB_MapCursorBox).SelectedIndex;
		MyProject.Forms.Options.RefreshOptions();
	}

	private void method_38(object sender, EventArgs e)
	{
		gamePreferences_0.ShowPlottedPaths = (Game.GamePreferences.PlottedPathsVisibilitySetting)((ComboBox)CP_ShowPlottedPaths).SelectedIndex;
		Client.MustRefreshMainForm = true;
		MyProject.Forms.Options.RefreshOptions();
		MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
	}

	private void method_39(object sender, EventArgs e)
	{
		string text = ((ComboBox)CP_ShowFlightPlans_Airborne).SelectedItem.ToString();
		if (Operators.CompareString(text, "All", true) != 0)
		{
			if (Operators.CompareString(text, "Selected Unit", true) == 0)
			{
				gamePreferences_0.ShowFlightPlans_Airborne = Game.GamePreferences.FlightPlansVisibilitySetting_Airborne.SelectedUnit;
			}
			else if (Operators.CompareString(text, "Do not Show", true) == 0)
			{
				gamePreferences_0.ShowFlightPlans_Airborne = Game.GamePreferences.FlightPlansVisibilitySetting_Airborne.DontShow;
			}
		}
		else
		{
			gamePreferences_0.ShowFlightPlans_Airborne = Game.GamePreferences.FlightPlansVisibilitySetting_Airborne.All;
		}
		MyProject.Forms.Options.RefreshOptions();
		MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
		Client.MustRefreshMainForm = true;
	}

	private void method_40(object sender, EventArgs e)
	{
		gamePreferences_0.ShowFlightPlans_Planned = (Game.GamePreferences.FlightPlansVisibilitySetting_Planned)((ComboBox)CP_ShowFlightPlans_Planned).SelectedIndex;
		Client.MustRefreshMainForm = true;
		MyProject.Forms.Options.RefreshOptions();
	}

	private void method_41(object sender, EventArgs e)
	{
		gamePreferences_0.ShowMissionArea = (Game.GamePreferences.ObjectVisibilitySetting)((ComboBox)CB_MissionAreaCourseDisplay).SelectedIndex;
		Client.MustRefreshMainForm = true;
		MyProject.Forms.Options.RefreshOptions();
		MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
	}

	private void method_42(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		ColorDialog_Shade = new ColorDialog();
		ColorDialog_Shade.Color = Client.Color_PC_WPShade;
		((CommonDialog)ColorDialog_Shade).ShowDialog();
		Client.Color_PC_WPShade = Color.FromArgb(255, ColorDialog_Shade.Color);
		Client.CurrentMapProfile.WPColor = Client.Color_PC_WPShade;
		((Control)LabelPlottedCourseColor).BackColor = Client.CurrentMapProfile.WPColor;
		Client.MustRefreshMainForm = true;
	}

	private void method_43(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		ColorDialog_Shade = new ColorDialog();
		ColorDialog_Shade.Color = Client.CurrentMapProfile.BorderColor;
		((CommonDialog)ColorDialog_Shade).ShowDialog();
		Client.CurrentMapProfile.BorderColor = Color.FromArgb(255, ColorDialog_Shade.Color);
		((Control)LabelBorderColor).BackColor = Client.CurrentMapProfile.BorderColor;
		MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
	}

	private void method_44(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		ColorDialog_Shade = new ColorDialog();
		ColorDialog_Shade.Color = Client.CurrentMapProfile.SeaIceColor;
		((CommonDialog)ColorDialog_Shade).ShowDialog();
		Client.CurrentMapProfile.SeaIceColor = Color.FromArgb(255, ColorDialog_Shade.Color);
		((Control)LabelSeaIceColor).BackColor = Client.CurrentMapProfile.SeaIceColor;
		MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
	}

	private MapProfile._ShowElement method_45(string string_0)
	{
		if (Operators.CompareString(string_0, "All", true) == 0)
		{
			return MapProfile._ShowElement.All;
		}
		if (Operators.CompareString(string_0, "Selected Unit", true) != 0)
		{
			if (Operators.CompareString(string_0, "Do not Show", true) == 0)
			{
				return MapProfile._ShowElement.DontShow;
			}
			MapProfile._ShowElement result = default(MapProfile._ShowElement);
			return result;
		}
		return MapProfile._ShowElement.SelectedUnit;
	}

	private string method_46(MapProfile._ShowElement _ShowElement_0)
	{
		string text = default(string);
		return _ShowElement_0 switch
		{
			MapProfile._ShowElement.All => "All", 
			MapProfile._ShowElement.SelectedUnit => "Selected Unit", 
			MapProfile._ShowElement.DontShow => "Do not Show", 
			_ => text, 
		};
	}

	private void method_47(object sender, EventArgs e)
	{
		Client.CurrentMapProfile.ShowIlluminationVectors = method_45(((ComboBox)CB_IlluminationVectors).SelectedItem.ToString());
		MyProject.Forms.Options.RefreshOptions();
		MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
		Client.MustRefreshMainForm = true;
	}

	private void method_48(object sender, EventArgs e)
	{
		Client.CurrentMapProfile.ShowTargetingVectors = method_45(((ComboBox)CB_TargetingVectors).SelectedItem.ToString());
		MyProject.Forms.Options.RefreshOptions();
		MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
	}

	private void method_49(object sender, EventArgs e)
	{
		Client.CurrentMapProfile.ShowDatalinks = method_45(((ComboBox)CB_Datalinks).SelectedItem.ToString());
		MyProject.Forms.Options.RefreshOptions();
		MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
	}

	private void method_50(object sender, EventArgs e)
	{
		Client.CurrentMapProfile.ShowContactEmissions = (MapProfile._ShowElement)((ComboBox)CB_ContactEmissionsDisplay).SelectedIndex;
		MyProject.Forms.Options.RefreshOptions();
		MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
	}

	private void method_51(object sender, EventArgs e)
	{
		Client.CurrentMapProfile.ShowContactEmissions_Details = (MapProfile._ShowEmissionTypes)((ComboBox)CB_DisplayEmissionsFor).SelectedIndex;
		MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
	}

	private void method_52(object sender, EventArgs e)
	{
	}

	private void method_53(object sender, EventArgs e)
	{
	}

	private void method_54(object sender, EventArgs e)
	{
	}

	private void method_55(object sender, EventArgs e)
	{
	}

	private void method_56(object sender, EventArgs e)
	{
	}

	private void method_57(object sender, EventArgs e)
	{
	}

	private void method_58(object sender, EventArgs e)
	{
	}

	private void method_59(object sender, EventArgs e)
	{
	}

	private void method_60(object sender, EventArgs e)
	{
	}

	private void method_61(object sender, EventArgs e)
	{
	}

	private void method_62(object sender, EventArgs e)
	{
	}

	private void method_63(object sender, EventArgs e)
	{
	}

	private void method_64(object sender, EventArgs e)
	{
	}

	private void method_65(object sender, EventArgs e)
	{
	}

	private void method_66(object sender, EventArgs e)
	{
	}

	private void method_67(object sender, EventArgs e)
	{
		gamePreferences_0.UsePersonalMapProfile = ((CheckBox)UsePersonalMapProfileCheckBox).Checked;
		if (gamePreferences_0.UsePersonalMapProfile && gamePreferences_0.PersonalMapProfile == null)
		{
			gamePreferences_0.PersonalMapProfile = Client.CurrentMapProfile;
		}
		MyProject.Forms.MainForm.HandleMapProfileSettingsChange();
		MyProject.Forms.Options.RefreshOptions();
	}

	private void method_68(object sender, EventArgs e)
	{
		gamePreferences_0.PersonalMapProfile = Client.CurrentMapProfile;
	}

	static MapSettings()
	{
		Class72.smethod_20();
	}
}
