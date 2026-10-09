using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using Command.My;
using DarkUI.Collections;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class ReferencePointManager : CommandFormParent
{
	[DoNotPrune]
	[DoNotObfuscate]
	private sealed class TagComboboxItem
	{
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private ReferencePointFlag referencePointFlag_0;

		public string Name
		{
			[CompilerGenerated]
			get
			{
				return string_0;
			}
			[CompilerGenerated]
			set
			{
				string_0 = value;
			}
		}

		public ReferencePointFlag RedFlag
		{
			[CompilerGenerated]
			get
			{
				return referencePointFlag_0;
			}
			[CompilerGenerated]
			set
			{
				referencePointFlag_0 = value;
			}
		}

		public TagComboboxItem(string string_1, ReferencePointFlag referencePointFlag_1)
		{
			Name = string_1;
			RedFlag = referencePointFlag_1;
		}

		static TagComboboxItem()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_0;

	[AccessedThroughProperty("AddnewTagButton")]
	[CompilerGenerated]
	private DarkUIButton _AddnewTagButton;

	[CompilerGenerated]
	[AccessedThroughProperty("DeleteTagButton")]
	private DarkUIButton _DeleteTagButton;

	[AccessedThroughProperty("RemoveTagFromRef")]
	[CompilerGenerated]
	private DarkUIButton _RemoveTagFromRef;

	[CompilerGenerated]
	[AccessedThroughProperty("LV_Tags")]
	private DarkListView _LV_Tags;

	[AccessedThroughProperty("DeleteRefPoint")]
	[CompilerGenerated]
	private DarkUIButton _DeleteRefPoint;

	[AccessedThroughProperty("JumpToRefPointButton")]
	[CompilerGenerated]
	private DarkUIButton _JumpToRefPointButton;

	[CompilerGenerated]
	[AccessedThroughProperty("RefPointColorButton")]
	private Button _RefPointColorButton;

	[AccessedThroughProperty("AddTagToRefPointButton")]
	[CompilerGenerated]
	private DarkUIButton _AddTagToRefPointButton;

	[AccessedThroughProperty("LV_ReferencePoints")]
	[CompilerGenerated]
	private DarkListView _LV_ReferencePoints;

	[AccessedThroughProperty("ButtonRemoveRefPointToArea")]
	[CompilerGenerated]
	private DarkUIButton _ButtonRemoveRefPointToArea;

	[AccessedThroughProperty("ButtonAddRefPointToArea")]
	[CompilerGenerated]
	private DarkUIButton _ButtonAddRefPointToArea;

	[AccessedThroughProperty("ButtonCreateNewArea")]
	[CompilerGenerated]
	private DarkUIButton _ButtonCreateNewArea;

	[AccessedThroughProperty("ButtonDeleteArea")]
	[CompilerGenerated]
	private DarkUIButton _ButtonDeleteArea;

	[AccessedThroughProperty("TV_Zones")]
	[CompilerGenerated]
	private DarkTreeView _TV_Zones;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonTabZones")]
	private Button _ButtonTabZones;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonTabNoNavZones")]
	private Button _ButtonTabNoNavZones;

	[AccessedThroughProperty("ButtonTabExclusionZones")]
	[CompilerGenerated]
	private Button _ButtonTabExclusionZones;

	[CompilerGenerated]
	[AccessedThroughProperty("CBAppliesAircraft")]
	private DarkCheckBox _CBAppliesAircraft;

	[CompilerGenerated]
	[AccessedThroughProperty("CBAppliesSubmarines")]
	private DarkCheckBox darkCheckBox_0;

	[CompilerGenerated]
	[AccessedThroughProperty("CBAppliesShips")]
	private DarkCheckBox _CBAppliesShips;

	[CompilerGenerated]
	[AccessedThroughProperty("CBAppliesLandUnits")]
	private DarkCheckBox darkCheckBox_1;

	[CompilerGenerated]
	[AccessedThroughProperty("CBZoneIsLocked")]
	private DarkCheckBox _CBZoneIsLocked;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_AreaName")]
	private DarkUITextBox _TB_AreaName;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonImport")]
	private DarkUIButton _ButtonImport;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonExport")]
	private DarkUIButton _ButtonExport;

	[AccessedThroughProperty("ButtonSave")]
	[CompilerGenerated]
	private DarkUIButton _ButtonSave;

	[AccessedThroughProperty("DGV_ExclusionZone")]
	[CompilerGenerated]
	private DarkDataGridView _DGV_ExclusionZone;

	[AccessedThroughProperty("ButtonAddselectedRPtoArea")]
	[CompilerGenerated]
	private DarkUIButton _ButtonAddselectedRPtoArea;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ListUp")]
	private DarkButton _Button_ListUp;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ListDown")]
	private DarkButton _Button_ListDown;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonValidateArea")]
	private DarkUIButton _ButtonValidateArea;

	[CompilerGenerated]
	[AccessedThroughProperty("DGV_NoNavZone")]
	private DarkDataGridView _DGV_NoNavZone;

	[AccessedThroughProperty("BtnApproveTransformTo")]
	[CompilerGenerated]
	private DarkUIButton _BtnApproveTransformTo;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonZoneColorPicker")]
	private Button _ButtonZoneColorPicker;

	[AccessedThroughProperty("GBAppliesTo")]
	[CompilerGenerated]
	private DarkGroupBox darkGroupBox_0;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ViolatorNoChanges")]
	private DarkUIButton _Button_ViolatorNoChanges;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ViolatorUnfriendly")]
	private DarkUIButton _Button_ViolatorUnfriendly;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ViolatorHostile")]
	private DarkUIButton _Button_ViolatorHostile;

	[AccessedThroughProperty("ButtonTabCusEnvZones")]
	[CompilerGenerated]
	private Button _ButtonTabCusEnvZones;

	[CompilerGenerated]
	[AccessedThroughProperty("btnCEZDet")]
	private DarkUIButton darkUIButton_0;

	[CompilerGenerated]
	[AccessedThroughProperty("TV_CusEnvZones")]
	private DarkTreeView _TV_CusEnvZones;

	[AccessedThroughProperty("Num_ZoneOpacity")]
	[CompilerGenerated]
	private NumericUpDown _Num_ZoneOpacity;

	[AccessedThroughProperty("Button_MoveDownZonePriority")]
	[CompilerGenerated]
	private DarkButton _Button_MoveDownZonePriority;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_MoveUpZonePriority")]
	private DarkButton _Button_MoveUpZonePriority;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_NoFireZone")]
	private DarkCheckBox _CB_NoFireZone;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Enablers")]
	private DarkUIButton _Button_Enablers;

	[AccessedThroughProperty("CB_VisibleAreaRPs")]
	[CompilerGenerated]
	private DarkCheckBox _CB_VisibleAreaRPs;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_VisibleRP")]
	private DarkCheckBox _CB_VisibleRP;

	[CompilerGenerated]
	[AccessedThroughProperty("ExclusionZoneAltitudeEnvelopeMinTextBox")]
	private DarkUITextBox _ExclusionZoneAltitudeEnvelopeMinTextBox;

	[AccessedThroughProperty("ExclusionZoneAltitudeEnvelopeMaxTextBox")]
	[CompilerGenerated]
	private DarkUITextBox _ExclusionZoneAltitudeEnvelopeMaxTextBox;

	private Dictionary<int, ReferencePoint> dictionary_0;

	[AccessedThroughProperty("RefPoints")]
	[CompilerGenerated]
	private ObservableList<ReferencePoint> observableList_0;

	public Dictionary<ReferencePointFlag, bool> Filters;

	public bool EnableReferencePointEvents;

	[CompilerGenerated]
	private bool bool_1;

	private bool bool_2;

	private Zone.ZoneType zoneType_0;

	private Zone.ZoneType zoneType_1;

	private Zone zone_0;

	private float float_0;

	public List<ReferencePoint> AreaPoints;

	private ExclusionZone exclusionZone_0;

	[AccessedThroughProperty("FD_LoadExclusionZone")]
	[CompilerGenerated]
	private OpenFileDialog openFileDialog_0;

	[CompilerGenerated]
	[AccessedThroughProperty("FD_ExportExclusionZone")]
	private SaveFileDialog saveFileDialog_0;

	private Zone.ZoneType zoneType_2;

	private Zone zone_1;

	[AccessedThroughProperty("FD_LoadStandardZone")]
	[CompilerGenerated]
	private OpenFileDialog openFileDialog_1;

	[AccessedThroughProperty("FD_ExportStandardZone")]
	[CompilerGenerated]
	private SaveFileDialog saveFileDialog_1;

	private NoNavZone noNavZone_0;

	[AccessedThroughProperty("FD_LoadNoNavZone")]
	[CompilerGenerated]
	private OpenFileDialog openFileDialog_2;

	[AccessedThroughProperty("FD_ExportNoNavZone")]
	[CompilerGenerated]
	private SaveFileDialog saveFileDialog_2;

	private CustomEnvironmentZone customEnvironmentZone_0;

	[field: AccessedThroughProperty("RefPointEditorPanel")]
	internal virtual Panel RefPointEditorPanel { get; set; }

	internal virtual DarkUIButton AddnewTagButton
	{
		[CompilerGenerated]
		get
		{
			return _AddnewTagButton;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_9;
			DarkUIButton darkUIButton = _AddnewTagButton;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_AddnewTagButton = value;
			darkUIButton = _AddnewTagButton;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton DeleteTagButton
	{
		[CompilerGenerated]
		get
		{
			return _DeleteTagButton;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_10;
			DarkUIButton darkUIButton = _DeleteTagButton;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_DeleteTagButton = value;
			darkUIButton = _DeleteTagButton;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton RemoveTagFromRef
	{
		[CompilerGenerated]
		get
		{
			return _RemoveTagFromRef;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_15;
			DarkUIButton darkUIButton = _RemoveTagFromRef;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_RemoveTagFromRef = value;
			darkUIButton = _RemoveTagFromRef;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("RefPointTagListCombo")]
	internal virtual DarkUIComboBox RefPointTagListCombo { get; set; }

	internal virtual DarkListView LV_Tags
	{
		[CompilerGenerated]
		get
		{
			return _LV_Tags;
		}
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_11;
			DarkListView darkListView = _LV_Tags;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged -= value2;
			}
			_LV_Tags = value;
			darkListView = _LV_Tags;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged += value2;
			}
		}
	}

	internal virtual DarkUIButton DeleteRefPoint
	{
		[CompilerGenerated]
		get
		{
			return _DeleteRefPoint;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_8;
			DarkUIButton darkUIButton = _DeleteRefPoint;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_DeleteRefPoint = value;
			darkUIButton = _DeleteRefPoint;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("RefPointLongitude")]
	internal virtual DarkLabel RefPointLongitude { get; set; }

	[field: AccessedThroughProperty("RefPointLatitude")]
	internal virtual DarkLabel RefPointLatitude { get; set; }

	internal virtual DarkUIButton JumpToRefPointButton
	{
		[CompilerGenerated]
		get
		{
			return _JumpToRefPointButton;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_7;
			DarkUIButton darkUIButton = _JumpToRefPointButton;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_JumpToRefPointButton = value;
			darkUIButton = _JumpToRefPointButton;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Panel3")]
	internal virtual Panel Panel3 { get; set; }

	[field: AccessedThroughProperty("RefPointName")]
	internal virtual DarkUITextBox RefPointName { get; set; }

	internal virtual Button RefPointColorButton
	{
		[CompilerGenerated]
		get
		{
			return _RefPointColorButton;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_13;
			Button val = _RefPointColorButton;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_RefPointColorButton = value;
			val = _RefPointColorButton;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Tags")]
	internal virtual DarkLabel Tags { get; set; }

	internal virtual DarkUIButton AddTagToRefPointButton
	{
		[CompilerGenerated]
		get
		{
			return _AddTagToRefPointButton;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_14;
			DarkUIButton darkUIButton = _AddTagToRefPointButton;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_AddTagToRefPointButton = value;
			darkUIButton = _AddTagToRefPointButton;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("SelectedTagTextBox")]
	internal virtual DarkUITextBox SelectedTagTextBox { get; set; }

	[field: AccessedThroughProperty("FlowPanelTabTagsFilter")]
	internal virtual FlowLayoutPanel FlowPanelTabTagsFilter { get; set; }

	[field: AccessedThroughProperty("Button1")]
	internal virtual Button Button1 { get; set; }

	internal virtual DarkListView LV_ReferencePoints
	{
		[CompilerGenerated]
		get
		{
			return _LV_ReferencePoints;
		}
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler value2 = method_5;
			MouseEventHandler val = new MouseEventHandler(method_6);
			DarkListView darkListView = _LV_ReferencePoints;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged -= value2;
				((Control)darkListView).MouseDoubleClick -= val;
			}
			_LV_ReferencePoints = value;
			darkListView = _LV_ReferencePoints;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged += value2;
				((Control)darkListView).MouseDoubleClick += val;
			}
		}
	}

	internal virtual DarkUIButton ButtonRemoveRefPointToArea
	{
		[CompilerGenerated]
		get
		{
			return _ButtonRemoveRefPointToArea;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_51;
			DarkUIButton darkUIButton = _ButtonRemoveRefPointToArea;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonRemoveRefPointToArea = value;
			darkUIButton = _ButtonRemoveRefPointToArea;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton ButtonAddRefPointToArea
	{
		[CompilerGenerated]
		get
		{
			return _ButtonAddRefPointToArea;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_55;
			DarkUIButton darkUIButton = _ButtonAddRefPointToArea;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonAddRefPointToArea = value;
			darkUIButton = _ButtonAddRefPointToArea;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("LabelAreaEditor")]
	internal virtual DarkLabel LabelAreaEditor { get; set; }

	internal virtual DarkUIButton ButtonCreateNewArea
	{
		[CompilerGenerated]
		get
		{
			return _ButtonCreateNewArea;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_59;
			DarkUIButton darkUIButton = _ButtonCreateNewArea;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonCreateNewArea = value;
			darkUIButton = _ButtonCreateNewArea;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton ButtonDeleteArea
	{
		[CompilerGenerated]
		get
		{
			return _ButtonDeleteArea;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_34;
			DarkUIButton darkUIButton = _ButtonDeleteArea;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonDeleteArea = value;
			darkUIButton = _ButtonDeleteArea;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkTreeView TV_Zones
	{
		[CompilerGenerated]
		get
		{
			return _TV_Zones;
		}
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_37;
			DarkTreeView darkTreeView = _TV_Zones;
			if (darkTreeView != null)
			{
				darkTreeView.SelectedNodesChanged -= value2;
			}
			_TV_Zones = value;
			darkTreeView = _TV_Zones;
			if (darkTreeView != null)
			{
				darkTreeView.SelectedNodesChanged += value2;
			}
		}
	}

	internal virtual Button ButtonTabZones
	{
		[CompilerGenerated]
		get
		{
			return _ButtonTabZones;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_30;
			Button val = _ButtonTabZones;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_ButtonTabZones = value;
			val = _ButtonTabZones;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual Button ButtonTabNoNavZones
	{
		[CompilerGenerated]
		get
		{
			return _ButtonTabNoNavZones;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_31;
			Button val = _ButtonTabNoNavZones;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_ButtonTabNoNavZones = value;
			val = _ButtonTabNoNavZones;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual Button ButtonTabExclusionZones
	{
		[CompilerGenerated]
		get
		{
			return _ButtonTabExclusionZones;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_32;
			Button val = _ButtonTabExclusionZones;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_ButtonTabExclusionZones = value;
			val = _ButtonTabExclusionZones;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CBAppliesAircraft
	{
		[CompilerGenerated]
		get
		{
			return _CBAppliesAircraft;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			MouseEventHandler val = new MouseEventHandler(method_38);
			DarkCheckBox darkCheckBox = _CBAppliesAircraft;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).MouseClick -= val;
			}
			_CBAppliesAircraft = value;
			darkCheckBox = _CBAppliesAircraft;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).MouseClick += val;
			}
		}
	}

	[field: AccessedThroughProperty("GB_Violators")]
	internal virtual DarkGroupBox GB_Violators { get; set; }

	internal virtual DarkCheckBox CBAppliesSubmarines
	{
		[CompilerGenerated]
		get
		{
			return darkCheckBox_0;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			MouseEventHandler val = new MouseEventHandler(method_40);
			DarkCheckBox darkCheckBox = darkCheckBox_0;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).MouseClick -= val;
			}
			darkCheckBox_0 = value;
			darkCheckBox = darkCheckBox_0;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).MouseClick += val;
			}
		}
	}

	internal virtual DarkCheckBox CBAppliesShips
	{
		[CompilerGenerated]
		get
		{
			return _CBAppliesShips;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			MouseEventHandler val = new MouseEventHandler(method_39);
			DarkCheckBox darkCheckBox = _CBAppliesShips;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).MouseClick -= val;
			}
			_CBAppliesShips = value;
			darkCheckBox = _CBAppliesShips;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).MouseClick += val;
			}
		}
	}

	internal virtual DarkCheckBox CBAppliesLandUnits
	{
		[CompilerGenerated]
		get
		{
			return darkCheckBox_1;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			MouseEventHandler val = new MouseEventHandler(method_41);
			DarkCheckBox darkCheckBox = darkCheckBox_1;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).MouseClick -= val;
			}
			darkCheckBox_1 = value;
			darkCheckBox = darkCheckBox_1;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).MouseClick += val;
			}
		}
	}

	internal virtual DarkCheckBox CBZoneIsLocked
	{
		[CompilerGenerated]
		get
		{
			return _CBZoneIsLocked;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_75;
			DarkCheckBox darkCheckBox = _CBZoneIsLocked;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CBZoneIsLocked = value;
			darkCheckBox = _CBZoneIsLocked;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUITextBox TB_AreaName
	{
		[CompilerGenerated]
		get
		{
			return _TB_AreaName;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_28;
			DarkUITextBox darkUITextBox = _TB_AreaName;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).Leave -= eventHandler;
			}
			_TB_AreaName = value;
			darkUITextBox = _TB_AreaName;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).Leave += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton ButtonImport
	{
		[CompilerGenerated]
		get
		{
			return _ButtonImport;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_57;
			DarkUIButton darkUIButton = _ButtonImport;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonImport = value;
			darkUIButton = _ButtonImport;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton ButtonExport
	{
		[CompilerGenerated]
		get
		{
			return _ButtonExport;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_58;
			DarkUIButton darkUIButton = _ButtonExport;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonExport = value;
			darkUIButton = _ButtonExport;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton ButtonSave
	{
		[CompilerGenerated]
		get
		{
			return _ButtonSave;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_69;
			DarkUIButton darkUIButton = _ButtonSave;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonSave = value;
			darkUIButton = _ButtonSave;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkDataGridView DGV_ExclusionZone
	{
		[CompilerGenerated]
		get
		{
			return _DGV_ExclusionZone;
		}
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Expected O, but got Unknown
			EventHandler eventHandler = method_36;
			DataGridViewCellEventHandler val = new DataGridViewCellEventHandler(method_43);
			EventHandler eventHandler2 = method_62;
			DarkDataGridView darkDataGridView = _DGV_ExclusionZone;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).SelectionChanged -= eventHandler;
				((DataGridView)darkDataGridView).CellClick -= val;
				((DataGridView)darkDataGridView).RowHeadersDefaultCellStyleChanged -= eventHandler2;
			}
			_DGV_ExclusionZone = value;
			darkDataGridView = _DGV_ExclusionZone;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).SelectionChanged += eventHandler;
				((DataGridView)darkDataGridView).CellClick += val;
				((DataGridView)darkDataGridView).RowHeadersDefaultCellStyleChanged += eventHandler2;
			}
		}
	}

	[field: AccessedThroughProperty("CBTransformTo")]
	internal virtual DarkUIComboBox CBTransformTo { get; set; }

	[field: AccessedThroughProperty("LB_AreaRPs")]
	internal virtual DarkListView LB_AreaRPs { get; set; }

	internal virtual DarkUIButton ButtonAddselectedRPtoArea
	{
		[CompilerGenerated]
		get
		{
			return _ButtonAddselectedRPtoArea;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_46;
			DarkUIButton darkUIButton = _ButtonAddselectedRPtoArea;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonAddselectedRPtoArea = value;
			darkUIButton = _ButtonAddselectedRPtoArea;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkButton Button_ListUp
	{
		[CompilerGenerated]
		get
		{
			return _Button_ListUp;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_52;
			DarkButton darkButton = _Button_ListUp;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_ListUp = value;
			darkButton = _Button_ListUp;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkButton Button_ListDown
	{
		[CompilerGenerated]
		get
		{
			return _Button_ListDown;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_53;
			DarkButton darkButton = _Button_ListDown;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_ListDown = value;
			darkButton = _Button_ListDown;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton ButtonValidateArea
	{
		[CompilerGenerated]
		get
		{
			return _ButtonValidateArea;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_54;
			DarkUIButton darkUIButton = _ButtonValidateArea;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonValidateArea = value;
			darkUIButton = _ButtonValidateArea;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkDataGridView DGV_NoNavZone
	{
		[CompilerGenerated]
		get
		{
			return _DGV_NoNavZone;
		}
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = method_35;
			DataGridViewCellEventHandler val = new DataGridViewCellEventHandler(method_44);
			DarkDataGridView darkDataGridView = _DGV_NoNavZone;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).SelectionChanged -= eventHandler;
				((DataGridView)darkDataGridView).CellClick -= val;
			}
			_DGV_NoNavZone = value;
			darkDataGridView = _DGV_NoNavZone;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).SelectionChanged += eventHandler;
				((DataGridView)darkDataGridView).CellClick += val;
			}
		}
	}

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn1")]
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn1 { get; set; }

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn2")]
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn2 { get; set; }

	[field: AccessedThroughProperty("DataGridViewCheckBoxColumn1")]
	internal virtual DataGridViewCheckBoxColumn DataGridViewCheckBoxColumn1 { get; set; }

	internal virtual DarkUIButton BtnApproveTransformTo
	{
		[CompilerGenerated]
		get
		{
			return _BtnApproveTransformTo;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_61;
			DarkUIButton darkUIButton = _BtnApproveTransformTo;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_BtnApproveTransformTo = value;
			darkUIButton = _BtnApproveTransformTo;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel1")]
	internal virtual DarkLabel DarkLabel1 { get; set; }

	internal virtual Button ButtonZoneColorPicker
	{
		[CompilerGenerated]
		get
		{
			return _ButtonZoneColorPicker;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_63;
			Button val = _ButtonZoneColorPicker;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_ButtonZoneColorPicker = value;
			val = _ButtonZoneColorPicker;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label_ZoneColor")]
	internal virtual DarkLabel Label_ZoneColor { get; set; }

	[field: AccessedThroughProperty("LV_ViolatorSides")]
	internal virtual DarkListView LV_ViolatorSides { get; set; }

	internal virtual DarkGroupBox GBAppliesTo
	{
		[CompilerGenerated]
		get
		{
			return darkGroupBox_0;
		}
		[CompilerGenerated]
		set
		{
			darkGroupBox_0 = value;
		}
	}

	internal virtual DarkUIButton Button_ViolatorNoChanges
	{
		[CompilerGenerated]
		get
		{
			return _Button_ViolatorNoChanges;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_67;
			DarkUIButton darkUIButton = _Button_ViolatorNoChanges;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_ViolatorNoChanges = value;
			darkUIButton = _Button_ViolatorNoChanges;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_ViolatorUnfriendly
	{
		[CompilerGenerated]
		get
		{
			return _Button_ViolatorUnfriendly;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_66;
			DarkUIButton darkUIButton = _Button_ViolatorUnfriendly;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_ViolatorUnfriendly = value;
			darkUIButton = _Button_ViolatorUnfriendly;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_ViolatorHostile
	{
		[CompilerGenerated]
		get
		{
			return _Button_ViolatorHostile;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_65;
			DarkUIButton darkUIButton = _Button_ViolatorHostile;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_ViolatorHostile = value;
			darkUIButton = _Button_ViolatorHostile;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel3")]
	internal virtual DarkLabel DarkLabel3 { get; set; }

	[field: AccessedThroughProperty("DarkLabel4")]
	internal virtual DarkLabel DarkLabel4 { get; set; }

	[field: AccessedThroughProperty("ID")]
	internal virtual DataGridViewTextBoxColumn ID { get; set; }

	[field: AccessedThroughProperty("Description")]
	internal virtual DataGridViewTextBoxColumn Description { get; set; }

	[field: AccessedThroughProperty("Points")]
	internal virtual DataGridViewTextBoxColumn Points { get; set; }

	[field: AccessedThroughProperty("Active")]
	internal virtual DataGridViewCheckBoxColumn Active { get; set; }

	internal virtual Button ButtonTabCusEnvZones
	{
		[CompilerGenerated]
		get
		{
			return _ButtonTabCusEnvZones;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_33;
			Button val = _ButtonTabCusEnvZones;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_ButtonTabCusEnvZones = value;
			val = _ButtonTabCusEnvZones;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton btnCEZDet
	{
		[CompilerGenerated]
		get
		{
			return darkUIButton_0;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_60;
			DarkUIButton darkUIButton = darkUIButton_0;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			darkUIButton_0 = value;
			darkUIButton = darkUIButton_0;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkTreeView TV_CusEnvZones
	{
		[CompilerGenerated]
		get
		{
			return _TV_CusEnvZones;
		}
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_70;
			DarkTreeView darkTreeView = _TV_CusEnvZones;
			if (darkTreeView != null)
			{
				darkTreeView.SelectedNodesChanged -= value2;
			}
			_TV_CusEnvZones = value;
			darkTreeView = _TV_CusEnvZones;
			if (darkTreeView != null)
			{
				darkTreeView.SelectedNodesChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ZoneOpacity_Label")]
	internal virtual DarkLabel ZoneOpacity_Label { get; set; }

	internal virtual NumericUpDown Num_ZoneOpacity
	{
		[CompilerGenerated]
		get
		{
			return _Num_ZoneOpacity;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_71;
			NumericUpDown val = _Num_ZoneOpacity;
			if (val != null)
			{
				val.ValueChanged -= eventHandler;
			}
			_Num_ZoneOpacity = value;
			val = _Num_ZoneOpacity;
			if (val != null)
			{
				val.ValueChanged += eventHandler;
			}
		}
	}

	internal virtual DarkButton Button_MoveDownZonePriority
	{
		[CompilerGenerated]
		get
		{
			return _Button_MoveDownZonePriority;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_73;
			DarkButton darkButton = _Button_MoveDownZonePriority;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_MoveDownZonePriority = value;
			darkButton = _Button_MoveDownZonePriority;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkButton Button_MoveUpZonePriority
	{
		[CompilerGenerated]
		get
		{
			return _Button_MoveUpZonePriority;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_72;
			DarkButton darkButton = _Button_MoveUpZonePriority;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_MoveUpZonePriority = value;
			darkButton = _Button_MoveUpZonePriority;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_NoFireZone
	{
		[CompilerGenerated]
		get
		{
			return _CB_NoFireZone;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_74;
			DarkCheckBox darkCheckBox = _CB_NoFireZone;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_NoFireZone = value;
			darkCheckBox = _CB_NoFireZone;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_Enablers
	{
		[CompilerGenerated]
		get
		{
			return _Button_Enablers;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_76;
			DarkUIButton darkUIButton = _Button_Enablers;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_Enablers = value;
			darkUIButton = _Button_Enablers;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TagFilterGroupBox")]
	internal virtual DarkGroupBox TagFilterGroupBox { get; set; }

	[field: AccessedThroughProperty("RefPointsListTableLayout")]
	internal virtual TableLayoutPanel RefPointsListTableLayout { get; set; }

	internal virtual DarkCheckBox CB_VisibleAreaRPs
	{
		[CompilerGenerated]
		get
		{
			return _CB_VisibleAreaRPs;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_77;
			DarkCheckBox darkCheckBox = _CB_VisibleAreaRPs;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_VisibleAreaRPs = value;
			darkCheckBox = _CB_VisibleAreaRPs;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_VisibleRP
	{
		[CompilerGenerated]
		get
		{
			return _CB_VisibleRP;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_78;
			DarkCheckBox darkCheckBox = _CB_VisibleRP;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_VisibleRP = value;
			darkCheckBox = _CB_VisibleRP;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("ZoneConfigPanel")]
	internal virtual Panel ZoneConfigPanel { get; set; }

	[field: AccessedThroughProperty("lockedLabel")]
	internal virtual Label lockedLabel { get; set; }

	internal virtual DarkUITextBox ExclusionZoneAltitudeEnvelopeMinTextBox
	{
		[CompilerGenerated]
		get
		{
			return _ExclusionZoneAltitudeEnvelopeMinTextBox;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_81;
			DarkUITextBox darkUITextBox = _ExclusionZoneAltitudeEnvelopeMinTextBox;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).Leave -= eventHandler;
			}
			_ExclusionZoneAltitudeEnvelopeMinTextBox = value;
			darkUITextBox = _ExclusionZoneAltitudeEnvelopeMinTextBox;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).Leave += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("ExclusionZoneAltitudeEnvelopeTable")]
	internal virtual TableLayoutPanel ExclusionZoneAltitudeEnvelopeTable { get; set; }

	[field: AccessedThroughProperty("DarkLabel5")]
	internal virtual DarkLabel DarkLabel5 { get; set; }

	[field: AccessedThroughProperty("DarkLabel2")]
	internal virtual DarkLabel DarkLabel2 { get; set; }

	[field: AccessedThroughProperty("ExclusionZoneAltitudeEnvelopeMinUOMLabel")]
	internal virtual DarkLabel ExclusionZoneAltitudeEnvelopeMinUOMLabel { get; set; }

	[field: AccessedThroughProperty("ExclusionZoneAltitudeEnvelopeMaxUOMLabel")]
	internal virtual DarkLabel ExclusionZoneAltitudeEnvelopeMaxUOMLabel { get; set; }

	internal virtual DarkUITextBox ExclusionZoneAltitudeEnvelopeMaxTextBox
	{
		[CompilerGenerated]
		get
		{
			return _ExclusionZoneAltitudeEnvelopeMaxTextBox;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_82;
			DarkUITextBox darkUITextBox = _ExclusionZoneAltitudeEnvelopeMaxTextBox;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).Leave -= eventHandler;
			}
			_ExclusionZoneAltitudeEnvelopeMaxTextBox = value;
			darkUITextBox = _ExclusionZoneAltitudeEnvelopeMaxTextBox;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).Leave += eventHandler;
			}
		}
	}

	public virtual ObservableList<ReferencePoint> RefPoints
	{
		[CompilerGenerated]
		get
		{
			return observableList_0;
		}
		[CompilerGenerated]
		set
		{
			EventHandler<ObservableListModified<ReferencePoint>> value2 = method_1;
			EventHandler<ObservableListModified<ReferencePoint>> value3 = method_2;
			ObservableList<ReferencePoint> observableList = observableList_0;
			if (observableList != null)
			{
				observableList.ItemsRemoved -= value2;
				observableList.ItemsAdded -= value3;
			}
			observableList_0 = value;
			observableList = observableList_0;
			if (observableList != null)
			{
				observableList.ItemsRemoved += value2;
				observableList.ItemsAdded += value3;
			}
		}
	}

	protected override bool RTMPEnabled
	{
		[CompilerGenerated]
		get
		{
			return bool_1;
		}
		[CompilerGenerated]
		set
		{
			bool_1 = value;
		}
	}

	internal virtual OpenFileDialog FD_LoadExclusionZone
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

	internal virtual SaveFileDialog FD_ExportExclusionZone
	{
		[CompilerGenerated]
		get
		{
			return saveFileDialog_0;
		}
		[CompilerGenerated]
		set
		{
			saveFileDialog_0 = value;
		}
	}

	public ExclusionZone SelectedExclusionZone
	{
		get
		{
			return exclusionZone_0;
		}
		set
		{
			exclusionZone_0 = value;
			int mustRefreshMainForm;
			if (!Information.IsNothing((object)value))
			{
				method_21();
				method_18(exclusionZone_0.Area);
				mustRefreshMainForm = 1;
			}
			else
			{
				method_18(null);
				mustRefreshMainForm = 1;
			}
			Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
		}
	}

	internal virtual OpenFileDialog FD_LoadStandardZone
	{
		[CompilerGenerated]
		get
		{
			return openFileDialog_1;
		}
		[CompilerGenerated]
		set
		{
			openFileDialog_1 = value;
		}
	}

	internal virtual SaveFileDialog FD_ExportStandardZone
	{
		[CompilerGenerated]
		get
		{
			return saveFileDialog_1;
		}
		[CompilerGenerated]
		set
		{
			saveFileDialog_1 = value;
		}
	}

	public Zone SelectedStandardZone
	{
		get
		{
			return zone_1;
		}
		set
		{
			zone_1 = value;
			int mustRefreshMainForm;
			if (value == null)
			{
				((ButtonBase)ButtonZoneColorPicker).BackColor = Color.White;
				method_18(null);
				mustRefreshMainForm = 1;
			}
			else
			{
				TB_AreaName.Text = value.Description;
				((ButtonBase)ButtonZoneColorPicker).BackColor = zone_1.AreaColor;
				if (value.Area != null && value.Area.Count > 0)
				{
					((CheckBox)CB_VisibleAreaRPs).Checked = value.Area.First().IsVisible;
				}
				method_18(zone_1.Area);
				((CheckBox)CBZoneIsLocked).Checked = zone_1.IsLocked;
				method_45(bool_3: true, zone_1.IsLocked);
				if (string.IsNullOrEmpty(value.Name))
				{
					if (string.IsNullOrEmpty(value.Description))
					{
						mustRefreshMainForm = 1;
					}
					else
					{
						value.Name = value.Description;
						mustRefreshMainForm = 1;
					}
				}
				else
				{
					mustRefreshMainForm = 1;
				}
			}
			Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
		}
	}

	internal virtual OpenFileDialog FD_LoadNoNavZone
	{
		[CompilerGenerated]
		get
		{
			return openFileDialog_2;
		}
		[CompilerGenerated]
		set
		{
			openFileDialog_2 = value;
		}
	}

	internal virtual SaveFileDialog FD_ExportNoNavZone
	{
		[CompilerGenerated]
		get
		{
			return saveFileDialog_2;
		}
		[CompilerGenerated]
		set
		{
			saveFileDialog_2 = value;
		}
	}

	public NoNavZone SelectedStdZone
	{
		get
		{
			return noNavZone_0;
		}
		set
		{
			noNavZone_0 = value;
			int mustRefreshMainForm;
			if (Information.IsNothing((object)value))
			{
				method_18(null);
				mustRefreshMainForm = 1;
			}
			else
			{
				TB_AreaName.Text = value.Description;
				if (value.Area != null && value.Area.Count > 0)
				{
					((CheckBox)CB_VisibleAreaRPs).Checked = value.Area.First().IsVisible;
				}
				((CheckBox)CBAppliesAircraft).Checked = noNavZone_0.AffectedUnitTypes.Contains(GlobalVariables.ActiveUnitType.Aircraft);
				((CheckBox)CBAppliesShips).Checked = noNavZone_0.AffectedUnitTypes.Contains(GlobalVariables.ActiveUnitType.Ship);
				((CheckBox)CBAppliesSubmarines).Checked = noNavZone_0.AffectedUnitTypes.Contains(GlobalVariables.ActiveUnitType.Submarine);
				((CheckBox)CBAppliesLandUnits).Checked = noNavZone_0.AffectedUnitTypes.Contains(GlobalVariables.ActiveUnitType.Facility);
				((CheckBox)CBZoneIsLocked).Checked = noNavZone_0.IsLocked;
				((CheckBox)CB_NoFireZone).Checked = noNavZone_0.NoFireZone;
				method_45(bool_3: true, SelectedStdZone.IsLocked);
				method_18(noNavZone_0.Area);
				mustRefreshMainForm = 1;
			}
			Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
		}
	}

	public CustomEnvironmentZone SelectedCustomEnvironmentZone
	{
		get
		{
			return customEnvironmentZone_0;
		}
		set
		{
			customEnvironmentZone_0 = value;
			if (Information.IsNothing((object)value))
			{
				method_18(null);
			}
			else
			{
				TB_AreaName.Text = value.Description;
				method_18(customEnvironmentZone_0.Area);
			}
			int num;
			if (!Information.IsNothing((object)value))
			{
				TB_AreaName.Text = value.Description;
				((ButtonBase)ButtonZoneColorPicker).BackColor = customEnvironmentZone_0.AreaColor;
				method_18(customEnvironmentZone_0.Area);
				num = 0;
			}
			else
			{
				((ButtonBase)ButtonZoneColorPicker).BackColor = Color.White;
				method_18(null);
				num = 0;
			}
			bool flag = (byte)num != 0;
			Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
			int num2 = 0;
			int mustRefreshMainForm;
			while (true)
			{
				if (num2 < sides_ReadOnly.Length)
				{
					Side side = sides_ReadOnly[num2];
					foreach (NoNavZone noNavZone in side.NoNavZones)
					{
						if (noNavZone != SelectedStdZone)
						{
							continue;
						}
						foreach (ReferencePoint item in SelectedStdZone.Area)
						{
							if (side.RefPoints.Contains(item))
							{
								flag = true;
								break;
							}
						}
						if (flag)
						{
							break;
						}
					}
					if (!flag)
					{
						num2 = checked(num2 + 1);
						continue;
					}
					mustRefreshMainForm = 1;
					break;
				}
				mustRefreshMainForm = 1;
				break;
			}
			Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
		}
	}

	public ReferencePointManager()
	{
		((Form)this).Load += ReferencePointManager_Load;
		dictionary_0 = new Dictionary<int, ReferencePoint>();
		RefPoints = new ObservableList<ReferencePoint>();
		Filters = new Dictionary<ReferencePointFlag, bool>();
		EnableReferencePointEvents = true;
		RTMPEnabled = true;
		bool_2 = false;
		zoneType_0 = Zone.ZoneType.Zone;
		zoneType_1 = Zone.ZoneType.Zone;
		zone_0 = null;
		float_0 = 0f;
		zoneType_2 = Zone.ZoneType.Zone;
		InitializeComponent();
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && icontainer_0 != null)
			{
				icontainer_0.Dispose();
			}
		}
		finally
		{
			((Form)this).Dispose(disposing);
		}
	}

	private void InitializeComponent()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected O, but got Unknown
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected O, but got Unknown
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Expected O, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Expected O, but got Unknown
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected O, but got Unknown
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Expected O, but got Unknown
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Expected O, but got Unknown
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Expected O, but got Unknown
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Expected O, but got Unknown
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Expected O, but got Unknown
		//IL_0280: Unknown result type (might be due to invalid IL or missing references)
		//IL_028a: Expected O, but got Unknown
		//IL_0330: Unknown result type (might be due to invalid IL or missing references)
		//IL_033a: Expected O, but got Unknown
		//IL_0372: Unknown result type (might be due to invalid IL or missing references)
		//IL_037c: Expected O, but got Unknown
		//IL_0388: Unknown result type (might be due to invalid IL or missing references)
		//IL_0392: Expected O, but got Unknown
		//IL_0393: Unknown result type (might be due to invalid IL or missing references)
		//IL_039d: Expected O, but got Unknown
		//IL_03e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ea: Expected O, but got Unknown
		//IL_0771: Unknown result type (might be due to invalid IL or missing references)
		//IL_077b: Expected O, but got Unknown
		//IL_08ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_096e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a02: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a0c: Expected O, but got Unknown
		//IL_0abb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b23: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b2d: Expected O, but got Unknown
		//IL_0bae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb8: Expected O, but got Unknown
		//IL_0d4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d59: Expected O, but got Unknown
		//IL_0e6a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e74: Expected O, but got Unknown
		//IL_0f3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_105e: Unknown result type (might be due to invalid IL or missing references)
		//IL_10fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_11a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_16b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_16be: Expected O, but got Unknown
		//IL_176d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1777: Expected O, but got Unknown
		//IL_1a00: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a0a: Expected O, but got Unknown
		//IL_1a1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a24: Expected O, but got Unknown
		//IL_1a54: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a5e: Expected O, but got Unknown
		//IL_1a8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ad7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ae1: Expected O, but got Unknown
		//IL_1af1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1afb: Expected O, but got Unknown
		//IL_1b2b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b35: Expected O, but got Unknown
		//IL_1b62: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c98: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ca2: Expected O, but got Unknown
		//IL_1d5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d67: Expected O, but got Unknown
		//IL_22ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_2384: Unknown result type (might be due to invalid IL or missing references)
		//IL_2421: Unknown result type (might be due to invalid IL or missing references)
		//IL_2769: Unknown result type (might be due to invalid IL or missing references)
		//IL_2773: Expected O, but got Unknown
		//IL_2944: Unknown result type (might be due to invalid IL or missing references)
		//IL_29d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ad7: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ae1: Expected O, but got Unknown
		//IL_2b1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ba4: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bae: Expected O, but got Unknown
		//IL_2c89: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2db3: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f76: Unknown result type (might be due to invalid IL or missing references)
		//IL_300d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3076: Unknown result type (might be due to invalid IL or missing references)
		//IL_3080: Expected O, but got Unknown
		//IL_30ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_3123: Unknown result type (might be due to invalid IL or missing references)
		//IL_312d: Expected O, but got Unknown
		//IL_3167: Unknown result type (might be due to invalid IL or missing references)
		//IL_32a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_32b3: Expected O, but got Unknown
		//IL_32c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_32cd: Expected O, but got Unknown
		//IL_32fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_3307: Expected O, but got Unknown
		//IL_3335: Unknown result type (might be due to invalid IL or missing references)
		//IL_338e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3398: Expected O, but got Unknown
		//IL_33a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_33b2: Expected O, but got Unknown
		//IL_33e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_33ec: Expected O, but got Unknown
		//IL_341a: Unknown result type (might be due to invalid IL or missing references)
		//IL_34fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_359d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3613: Unknown result type (might be due to invalid IL or missing references)
		//IL_361d: Expected O, but got Unknown
		//IL_362f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3639: Expected O, but got Unknown
		//IL_36a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_36b3: Expected O, but got Unknown
		//IL_36c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_36cf: Expected O, but got Unknown
		//IL_36e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_36eb: Expected O, but got Unknown
		//IL_39f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a57: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a61: Expected O, but got Unknown
		//IL_3a73: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a7d: Expected O, but got Unknown
		//IL_3a8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a99: Expected O, but got Unknown
		//IL_3b6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b77: Expected O, but got Unknown
		//IL_3b89: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b93: Expected O, but got Unknown
		//IL_3c0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3cb9: Unknown result type (might be due to invalid IL or missing references)
		//IL_3da7: Unknown result type (might be due to invalid IL or missing references)
		//IL_3eeb: Unknown result type (might be due to invalid IL or missing references)
		//IL_3feb: Unknown result type (might be due to invalid IL or missing references)
		//IL_4093: Unknown result type (might be due to invalid IL or missing references)
		//IL_411a: Unknown result type (might be due to invalid IL or missing references)
		//IL_4124: Expected O, but got Unknown
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(ReferencePointManager));
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DataGridViewCellStyle val5 = new DataGridViewCellStyle();
		DataGridViewCellStyle val6 = new DataGridViewCellStyle();
		RefPointEditorPanel = new Panel();
		CB_VisibleRP = new DarkCheckBox();
		DarkLabel1 = new DarkLabel();
		RefPointColorButton = new Button();
		RefPointName = new DarkUITextBox();
		JumpToRefPointButton = new DarkUIButton();
		RemoveTagFromRef = new DarkUIButton();
		RefPointTagListCombo = new DarkUIComboBox();
		DeleteRefPoint = new DarkUIButton();
		RefPointLongitude = new DarkLabel();
		RefPointLatitude = new DarkLabel();
		Panel3 = new Panel();
		SelectedTagTextBox = new DarkUITextBox();
		Tags = new DarkLabel();
		AddTagToRefPointButton = new DarkUIButton();
		LV_Tags = new DarkListView();
		DeleteTagButton = new DarkUIButton();
		AddnewTagButton = new DarkUIButton();
		FlowPanelTabTagsFilter = new FlowLayoutPanel();
		Button1 = new Button();
		LV_ReferencePoints = new DarkListView();
		ButtonTabZones = new Button();
		ButtonTabNoNavZones = new Button();
		ButtonTabExclusionZones = new Button();
		ButtonZoneColorPicker = new Button();
		DarkLabel3 = new DarkLabel();
		Label_ZoneColor = new DarkLabel();
		DGV_NoNavZone = new DarkDataGridView();
		DataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
		DataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
		Button_ListDown = new DarkButton();
		Button_ListUp = new DarkButton();
		LB_AreaRPs = new DarkListView();
		DGV_ExclusionZone = new DarkDataGridView();
		ID = new DataGridViewTextBoxColumn();
		Description = new DataGridViewTextBoxColumn();
		Points = new DataGridViewTextBoxColumn();
		Active = new DataGridViewCheckBoxColumn();
		CBZoneIsLocked = new DarkCheckBox();
		GB_Violators = new DarkGroupBox();
		LV_ViolatorSides = new DarkListView();
		DarkLabel4 = new DarkLabel();
		Button_ViolatorNoChanges = new DarkUIButton();
		Button_ViolatorUnfriendly = new DarkUIButton();
		Button_ViolatorHostile = new DarkUIButton();
		GBAppliesTo = new DarkGroupBox();
		CBAppliesShips = new DarkCheckBox();
		CBAppliesAircraft = new DarkCheckBox();
		CBAppliesSubmarines = new DarkCheckBox();
		CBAppliesLandUnits = new DarkCheckBox();
		TV_Zones = new DarkTreeView();
		LabelAreaEditor = new DarkLabel();
		ButtonTabCusEnvZones = new Button();
		TV_CusEnvZones = new DarkTreeView();
		btnCEZDet = new DarkUIButton();
		BtnApproveTransformTo = new DarkUIButton();
		ButtonValidateArea = new DarkUIButton();
		ButtonAddselectedRPtoArea = new DarkUIButton();
		CBTransformTo = new DarkUIComboBox();
		ButtonSave = new DarkUIButton();
		ButtonExport = new DarkUIButton();
		ButtonImport = new DarkUIButton();
		TB_AreaName = new DarkUITextBox();
		ButtonDeleteArea = new DarkUIButton();
		ButtonCreateNewArea = new DarkUIButton();
		ButtonAddRefPointToArea = new DarkUIButton();
		ButtonRemoveRefPointToArea = new DarkUIButton();
		ZoneOpacity_Label = new DarkLabel();
		Num_ZoneOpacity = new NumericUpDown();
		Button_MoveDownZonePriority = new DarkButton();
		Button_MoveUpZonePriority = new DarkButton();
		CB_NoFireZone = new DarkCheckBox();
		Button_Enablers = new DarkUIButton();
		TagFilterGroupBox = new DarkGroupBox();
		RefPointsListTableLayout = new TableLayoutPanel();
		CB_VisibleAreaRPs = new DarkCheckBox();
		ZoneConfigPanel = new Panel();
		ExclusionZoneAltitudeEnvelopeTable = new TableLayoutPanel();
		ExclusionZoneAltitudeEnvelopeMaxUOMLabel = new DarkLabel();
		ExclusionZoneAltitudeEnvelopeMinUOMLabel = new DarkLabel();
		ExclusionZoneAltitudeEnvelopeMaxTextBox = new DarkUITextBox();
		ExclusionZoneAltitudeEnvelopeMinTextBox = new DarkUITextBox();
		DarkLabel5 = new DarkLabel();
		DarkLabel2 = new DarkLabel();
		lockedLabel = new Label();
		((Control)RefPointEditorPanel).SuspendLayout();
		((Control)Panel3).SuspendLayout();
		((Control)FlowPanelTabTagsFilter).SuspendLayout();
		((ISupportInitialize)(object)DGV_NoNavZone).BeginInit();
		((ISupportInitialize)(object)DGV_ExclusionZone).BeginInit();
		((Control)GB_Violators).SuspendLayout();
		((Control)GBAppliesTo).SuspendLayout();
		((ISupportInitialize)Num_ZoneOpacity).BeginInit();
		((Control)TagFilterGroupBox).SuspendLayout();
		((Control)RefPointsListTableLayout).SuspendLayout();
		((Control)ZoneConfigPanel).SuspendLayout();
		((Control)ExclusionZoneAltitudeEnvelopeTable).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)RefPointEditorPanel).Anchor = (AnchorStyles)6;
		((Control)RefPointEditorPanel).BackColor = Color.FromArgb(80, 80, 80);
		((Control)RefPointEditorPanel).Controls.Add((Control)(object)CB_VisibleRP);
		((Control)RefPointEditorPanel).Controls.Add((Control)(object)DarkLabel1);
		((Control)RefPointEditorPanel).Controls.Add((Control)(object)RefPointColorButton);
		((Control)RefPointEditorPanel).Controls.Add((Control)(object)RefPointName);
		((Control)RefPointEditorPanel).Controls.Add((Control)(object)JumpToRefPointButton);
		((Control)RefPointEditorPanel).Controls.Add((Control)(object)RemoveTagFromRef);
		((Control)RefPointEditorPanel).Controls.Add((Control)(object)RefPointTagListCombo);
		((Control)RefPointEditorPanel).Controls.Add((Control)(object)DeleteRefPoint);
		((Control)RefPointEditorPanel).Controls.Add((Control)(object)RefPointLongitude);
		((Control)RefPointEditorPanel).Controls.Add((Control)(object)RefPointLatitude);
		((Control)RefPointEditorPanel).Location = new Point(7, 391);
		((Control)RefPointEditorPanel).Name = "RefPointEditorPanel";
		((Control)RefPointEditorPanel).Size = new Size(314, 154);
		((Control)RefPointEditorPanel).TabIndex = 2;
		((Control)CB_VisibleRP).Anchor = (AnchorStyles)10;
		((ButtonBase)CB_VisibleRP).BackColor = Color.Gray;
		((Control)CB_VisibleRP).Location = new Point(6, 101);
		((Control)CB_VisibleRP).Name = "CB_VisibleRP";
		((Control)CB_VisibleRP).Size = new Size(137, 18);
		((Control)CB_VisibleRP).TabIndex = 50;
		((ButtonBase)CB_VisibleRP).Text = "Visible on map";
		DarkLabel1.AutoSize = true;
		((Control)DarkLabel1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel1).Location = new Point(3, 132);
		((Control)DarkLabel1).Name = "DarkLabel1";
		((Control)DarkLabel1).Size = new Size(49, 13);
		((Control)DarkLabel1).TabIndex = 12;
		((Label)DarkLabel1).Text = "RP Color";
		((ButtonBase)RefPointColorButton).BackColor = SystemColors.Control;
		((ButtonBase)RefPointColorButton).FlatAppearance.BorderSize = 0;
		((Control)RefPointColorButton).Location = new Point(60, 127);
		((Control)RefPointColorButton).Name = "RefPointColorButton";
		((Control)RefPointColorButton).Size = new Size(90, 22);
		((Control)RefPointColorButton).TabIndex = 11;
		((ButtonBase)RefPointColorButton).UseVisualStyleBackColor = false;
		RefPointName.AutoCompleteCustomSource = null;
		RefPointName.AutoCompleteMode = (AutoCompleteMode)0;
		RefPointName.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)RefPointName).BackColor = Color.Transparent;
		RefPointName.Font = new Font("Microsoft Sans Serif", 10f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)RefPointName).ForeColor = Color.FromArgb(189, 189, 189);
		RefPointName.Image = null;
		RefPointName.Lines = null;
		((Control)RefPointName).Location = new Point(15, 7);
		RefPointName.MaxLength = 32767;
		RefPointName.Multiline = false;
		((Control)RefPointName).Name = "RefPointName";
		RefPointName.ReadOnly = false;
		RefPointName.ScrollBars = (ScrollBars)0;
		RefPointName.SelectionStart = 0;
		((Control)RefPointName).Size = new Size(135, 21);
		((Control)RefPointName).TabIndex = 10;
		RefPointName.TextAlign = (HorizontalAlignment)2;
		RefPointName.UseSystemPasswordChar = false;
		RefPointName.WatermarkText = "";
		RefPointName.WordWrap = false;
		((Control)JumpToRefPointButton).Anchor = (AnchorStyles)6;
		((ButtonBase)JumpToRefPointButton).BackColor = Color.Transparent;
		((Control)JumpToRefPointButton).ForeColor = SystemColors.Control;
		((Control)JumpToRefPointButton).Location = new Point(156, 128);
		((Control)JumpToRefPointButton).Name = "JumpToRefPointButton";
		((Control)JumpToRefPointButton).Padding = new Padding(5);
		JumpToRefPointButton.RoundRadius = 0;
		((Control)JumpToRefPointButton).Size = new Size(151, 23);
		((Control)JumpToRefPointButton).TabIndex = 9;
		JumpToRefPointButton.Text = "Jump to ref point";
		((Control)RemoveTagFromRef).Anchor = (AnchorStyles)6;
		((ButtonBase)RemoveTagFromRef).BackColor = Color.Transparent;
		((Control)RemoveTagFromRef).ForeColor = SystemColors.Control;
		((Control)RemoveTagFromRef).Location = new Point(156, 34);
		((Control)RemoveTagFromRef).Name = "RemoveTagFromRef";
		((Control)RemoveTagFromRef).Padding = new Padding(5);
		RemoveTagFromRef.RoundRadius = 0;
		((Control)RemoveTagFromRef).Size = new Size(151, 23);
		((Control)RemoveTagFromRef).TabIndex = 6;
		RemoveTagFromRef.Text = "Remove Tag";
		((Control)RefPointTagListCombo).Anchor = (AnchorStyles)6;
		((ComboBox)RefPointTagListCombo).BackColor = Color.Transparent;
		((ComboBox)RefPointTagListCombo).DrawMode = (DrawMode)1;
		((ComboBox)RefPointTagListCombo).DropDownStyle = (ComboBoxStyle)2;
		((Control)RefPointTagListCombo).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)RefPointTagListCombo).FormattingEnabled = true;
		((Control)RefPointTagListCombo).Location = new Point(156, 7);
		((Control)RefPointTagListCombo).Name = "RefPointTagListCombo";
		((Control)RefPointTagListCombo).Size = new Size(151, 21);
		((Control)RefPointTagListCombo).TabIndex = 5;
		((Control)DeleteRefPoint).Anchor = (AnchorStyles)6;
		((ButtonBase)DeleteRefPoint).BackColor = Color.Transparent;
		((Control)DeleteRefPoint).ForeColor = SystemColors.Control;
		((Control)DeleteRefPoint).Location = new Point(156, 99);
		((Control)DeleteRefPoint).Name = "DeleteRefPoint";
		((Control)DeleteRefPoint).Padding = new Padding(5);
		DeleteRefPoint.RoundRadius = 0;
		((Control)DeleteRefPoint).Size = new Size(151, 23);
		((Control)DeleteRefPoint).TabIndex = 3;
		DeleteRefPoint.Text = "Delete ref point";
		RefPointLongitude.AutoSize = true;
		((Control)RefPointLongitude).Font = new Font("Microsoft Sans Serif", 10f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)RefPointLongitude).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)RefPointLongitude).Location = new Point(14, 49);
		((Control)RefPointLongitude).Name = "RefPointLongitude";
		((Control)RefPointLongitude).Size = new Size(0, 17);
		((Control)RefPointLongitude).TabIndex = 2;
		RefPointLatitude.AutoSize = true;
		((Control)RefPointLatitude).Font = new Font("Microsoft Sans Serif", 10f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)RefPointLatitude).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)RefPointLatitude).Location = new Point(14, 31);
		((Control)RefPointLatitude).Name = "RefPointLatitude";
		((Control)RefPointLatitude).Size = new Size(0, 17);
		((Control)RefPointLatitude).TabIndex = 1;
		((Control)Panel3).BackColor = Color.FromArgb(80, 80, 80);
		((Control)Panel3).Controls.Add((Control)(object)SelectedTagTextBox);
		((Control)Panel3).Controls.Add((Control)(object)Tags);
		((Control)Panel3).Controls.Add((Control)(object)AddTagToRefPointButton);
		((Control)Panel3).Controls.Add((Control)(object)LV_Tags);
		((Control)Panel3).Controls.Add((Control)(object)DeleteTagButton);
		((Control)Panel3).Controls.Add((Control)(object)AddnewTagButton);
		((Control)Panel3).Location = new Point(330, 396);
		((Control)Panel3).Name = "Panel3";
		((Control)Panel3).Size = new Size(219, 153);
		((Control)Panel3).TabIndex = 3;
		SelectedTagTextBox.AutoCompleteCustomSource = null;
		SelectedTagTextBox.AutoCompleteMode = (AutoCompleteMode)0;
		SelectedTagTextBox.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)SelectedTagTextBox).BackColor = Color.Transparent;
		SelectedTagTextBox.Font = new Font("Microsoft Sans Serif", 8f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)SelectedTagTextBox).ForeColor = Color.FromArgb(189, 189, 189);
		SelectedTagTextBox.Image = null;
		SelectedTagTextBox.Lines = null;
		((Control)SelectedTagTextBox).Location = new Point(45, 3);
		SelectedTagTextBox.MaxLength = 32767;
		SelectedTagTextBox.Multiline = false;
		((Control)SelectedTagTextBox).Name = "SelectedTagTextBox";
		SelectedTagTextBox.ReadOnly = false;
		SelectedTagTextBox.ScrollBars = (ScrollBars)0;
		SelectedTagTextBox.SelectionStart = 0;
		((Control)SelectedTagTextBox).Size = new Size(170, 17);
		((Control)SelectedTagTextBox).TabIndex = 12;
		SelectedTagTextBox.TextAlign = (HorizontalAlignment)2;
		SelectedTagTextBox.UseSystemPasswordChar = false;
		SelectedTagTextBox.WatermarkText = "";
		SelectedTagTextBox.WordWrap = false;
		Tags.AutoSize = true;
		((Control)Tags).Font = new Font("Microsoft Sans Serif", 10f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Tags).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Tags).Location = new Point(3, 3);
		((Control)Tags).Name = "Tags";
		((Control)Tags).Size = new Size(40, 17);
		((Control)Tags).TabIndex = 12;
		((Label)Tags).Text = "Tags";
		((Control)AddTagToRefPointButton).Anchor = (AnchorStyles)6;
		((ButtonBase)AddTagToRefPointButton).BackColor = Color.Transparent;
		((Control)AddTagToRefPointButton).ForeColor = SystemColors.Control;
		((Control)AddTagToRefPointButton).Location = new Point(3, 127);
		((Control)AddTagToRefPointButton).Name = "AddTagToRefPointButton";
		((Control)AddTagToRefPointButton).Padding = new Padding(5);
		AddTagToRefPointButton.RoundRadius = 0;
		((Control)AddTagToRefPointButton).Size = new Size(54, 23);
		((Control)AddTagToRefPointButton).TabIndex = 9;
		AddTagToRefPointButton.Text = "< Add";
		((Control)LV_Tags).Anchor = (AnchorStyles)6;
		((Control)LV_Tags).BackColor = Color.FromArgb(70, 70, 70);
		((Control)LV_Tags).Location = new Point(3, 29);
		((Control)LV_Tags).Name = "LV_Tags";
		LV_Tags.RelatedInfos = null;
		((Control)LV_Tags).Size = new Size(209, 93);
		((Control)LV_Tags).TabIndex = 4;
		((Control)LV_Tags).Text = "DarkListView2";
		((Control)DeleteTagButton).Anchor = (AnchorStyles)6;
		((ButtonBase)DeleteTagButton).BackColor = Color.Transparent;
		((Control)DeleteTagButton).ForeColor = SystemColors.Control;
		((Control)DeleteTagButton).Location = new Point(63, 127);
		((Control)DeleteTagButton).Name = "DeleteTagButton";
		((Control)DeleteTagButton).Padding = new Padding(5);
		DeleteTagButton.RoundRadius = 0;
		((Control)DeleteTagButton).Size = new Size(62, 23);
		((Control)DeleteTagButton).TabIndex = 7;
		DeleteTagButton.Text = "Delete";
		((Control)AddnewTagButton).Anchor = (AnchorStyles)6;
		((ButtonBase)AddnewTagButton).BackColor = Color.Transparent;
		((Control)AddnewTagButton).ForeColor = SystemColors.Control;
		((Control)AddnewTagButton).Location = new Point(130, 127);
		((Control)AddnewTagButton).Name = "AddnewTagButton";
		((Control)AddnewTagButton).Padding = new Padding(5);
		AddnewTagButton.RoundRadius = 0;
		((Control)AddnewTagButton).Size = new Size(81, 23);
		((Control)AddnewTagButton).TabIndex = 8;
		AddnewTagButton.Text = "Create New";
		((ScrollableControl)FlowPanelTabTagsFilter).AutoScroll = true;
		((ScrollableControl)FlowPanelTabTagsFilter).AutoScrollMinSize = new Size(10, 10);
		((Control)FlowPanelTabTagsFilter).Controls.Add((Control)(object)Button1);
		((Control)FlowPanelTabTagsFilter).Dock = (DockStyle)5;
		((Control)FlowPanelTabTagsFilter).Location = new Point(3, 16);
		((Control)FlowPanelTabTagsFilter).Margin = new Padding(0);
		((Control)FlowPanelTabTagsFilter).Name = "FlowPanelTabTagsFilter";
		((Control)FlowPanelTabTagsFilter).Size = new Size(536, 60);
		((Control)FlowPanelTabTagsFilter).TabIndex = 1;
		((ButtonBase)Button1).BackColor = Color.Gray;
		((ButtonBase)Button1).FlatStyle = (FlatStyle)0;
		((Control)Button1).ForeColor = SystemColors.ButtonFace;
		((Control)Button1).Location = new Point(3, 3);
		((Control)Button1).Name = "Button1";
		((Control)Button1).Size = new Size(75, 23);
		((Control)Button1).TabIndex = 0;
		((ButtonBase)Button1).Text = "Button1";
		((ButtonBase)Button1).UseVisualStyleBackColor = false;
		((Control)LV_ReferencePoints).BackColor = Color.FromArgb(70, 70, 70);
		((Control)LV_ReferencePoints).Dock = (DockStyle)5;
		((Control)LV_ReferencePoints).Location = new Point(3, 82);
		LV_ReferencePoints.MultiSelect = true;
		((Control)LV_ReferencePoints).Name = "LV_ReferencePoints";
		LV_ReferencePoints.RelatedInfos = null;
		((Control)LV_ReferencePoints).Size = new Size(536, 299);
		((Control)LV_ReferencePoints).TabIndex = 0;
		((Control)LV_ReferencePoints).Text = "LV_ReferencePoints";
		((ButtonBase)ButtonTabZones).BackColor = Color.Gray;
		((ButtonBase)ButtonTabZones).FlatStyle = (FlatStyle)0;
		((Control)ButtonTabZones).ForeColor = SystemColors.ActiveCaptionText;
		((Control)ButtonTabZones).Location = new Point(557, 24);
		((Control)ButtonTabZones).Name = "ButtonTabZones";
		((Control)ButtonTabZones).Size = new Size(69, 23);
		((Control)ButtonTabZones).TabIndex = 1;
		((ButtonBase)ButtonTabZones).Text = "Zones";
		((ButtonBase)ButtonTabZones).UseVisualStyleBackColor = false;
		((ButtonBase)ButtonTabNoNavZones).BackColor = Color.Gray;
		((ButtonBase)ButtonTabNoNavZones).FlatStyle = (FlatStyle)0;
		((Control)ButtonTabNoNavZones).ForeColor = SystemColors.ActiveCaptionText;
		((Control)ButtonTabNoNavZones).Location = new Point(632, 24);
		((Control)ButtonTabNoNavZones).Name = "ButtonTabNoNavZones";
		((Control)ButtonTabNoNavZones).Size = new Size(90, 23);
		((Control)ButtonTabNoNavZones).TabIndex = 12;
		((ButtonBase)ButtonTabNoNavZones).Text = "No-Nav Zones";
		((ButtonBase)ButtonTabNoNavZones).UseVisualStyleBackColor = false;
		((ButtonBase)ButtonTabExclusionZones).BackColor = Color.Gray;
		((ButtonBase)ButtonTabExclusionZones).FlatStyle = (FlatStyle)0;
		((Control)ButtonTabExclusionZones).ForeColor = SystemColors.ActiveCaptionText;
		((Control)ButtonTabExclusionZones).Location = new Point(728, 24);
		((Control)ButtonTabExclusionZones).Name = "ButtonTabExclusionZones";
		((Control)ButtonTabExclusionZones).Size = new Size(102, 23);
		((Control)ButtonTabExclusionZones).TabIndex = 13;
		((ButtonBase)ButtonTabExclusionZones).Text = "Exclusion Zones";
		((ButtonBase)ButtonTabExclusionZones).UseVisualStyleBackColor = false;
		((ButtonBase)ButtonZoneColorPicker).BackColor = SystemColors.Control;
		((ButtonBase)ButtonZoneColorPicker).FlatAppearance.BorderSize = 0;
		((Control)ButtonZoneColorPicker).Location = new Point(58, 213);
		((Control)ButtonZoneColorPicker).Name = "ButtonZoneColorPicker";
		((Control)ButtonZoneColorPicker).Size = new Size(51, 21);
		((Control)ButtonZoneColorPicker).TabIndex = 13;
		((ButtonBase)ButtonZoneColorPicker).UseVisualStyleBackColor = false;
		DarkLabel3.AutoSize = true;
		((Control)DarkLabel3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel3).Location = new Point(-1, 190);
		((Control)DarkLabel3).Name = "DarkLabel3";
		((Control)DarkLabel3).Size = new Size(41, 13);
		((Control)DarkLabel3).TabIndex = 35;
		((Label)DarkLabel3).Text = "Name :";
		Label_ZoneColor.AutoSize = true;
		((Control)Label_ZoneColor).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_ZoneColor).Location = new Point(-1, 217);
		((Control)Label_ZoneColor).Name = "Label_ZoneColor";
		((Control)Label_ZoneColor).Size = new Size(59, 13);
		((Control)Label_ZoneColor).TabIndex = 13;
		((Label)Label_ZoneColor).Text = "Zone Color";
		((DataGridView)DGV_NoNavZone).AllowUserToAddRows = false;
		((DataGridView)DGV_NoNavZone).AllowUserToDeleteRows = false;
		((DataGridView)DGV_NoNavZone).AllowUserToOrderColumns = true;
		((Control)DGV_NoNavZone).Anchor = (AnchorStyles)15;
		((DataGridView)DGV_NoNavZone).BackgroundColor = Color.FromArgb(60, 63, 65);
		((DataGridView)DGV_NoNavZone).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_NoNavZone).CellBorderStyle = (DataGridViewCellBorderStyle)8;
		((DataGridView)DGV_NoNavZone).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val.Alignment = (DataGridViewContentAlignment)16;
		val.BackColor = Color.FromArgb(66, 77, 95);
		val.Font = new Font("Segoe UI", 9f);
		val.ForeColor = Color.LightGray;
		val.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_NoNavZone).ColumnHeadersDefaultCellStyle = val;
		((DataGridView)DGV_NoNavZone).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		((DataGridView)DGV_NoNavZone).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[3]
		{
			(DataGridViewColumn)DataGridViewTextBoxColumn1,
			(DataGridViewColumn)DataGridViewTextBoxColumn2,
			(DataGridViewColumn)DataGridViewCheckBoxColumn1
		});
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = Color.FromArgb(60, 63, 65);
		val2.Font = new Font("Segoe UI", 9f);
		val2.ForeColor = SystemColors.ControlText;
		val2.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val2.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_NoNavZone).DefaultCellStyle = val2;
		((DataGridView)DGV_NoNavZone).EditMode = (DataGridViewEditMode)4;
		((DataGridView)DGV_NoNavZone).EnableHeadersVisualStyles = false;
		((Control)DGV_NoNavZone).Location = new Point(582, 54);
		((DataGridView)DGV_NoNavZone).MultiSelect = false;
		((Control)DGV_NoNavZone).Name = "DGV_NoNavZone";
		((DataGridView)DGV_NoNavZone).ReadOnly = true;
		((DataGridView)DGV_NoNavZone).RowHeadersVisible = false;
		((DataGridView)DGV_NoNavZone).RowHeadersWidth = 62;
		val3.BackColor = Color.FromArgb(60, 63, 65);
		val3.ForeColor = Color.LightGray;
		val3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val3.SelectionForeColor = Color.LightGray;
		((DataGridView)DGV_NoNavZone).RowsDefaultCellStyle = val3;
		((DataGridView)DGV_NoNavZone).SelectionMode = (DataGridViewSelectionMode)1;
		((DataGridView)DGV_NoNavZone).ShowCellToolTips = false;
		((DataGridView)DGV_NoNavZone).ShowEditingIcon = false;
		((DataGridView)DGV_NoNavZone).ShowRowErrors = false;
		((Control)DGV_NoNavZone).Size = new Size(556, 132);
		((Control)DGV_NoNavZone).TabIndex = 33;
		((DataGridViewColumn)DataGridViewTextBoxColumn1).DataPropertyName = "ID";
		((DataGridViewColumn)DataGridViewTextBoxColumn1).HeaderText = "ID";
		((DataGridViewColumn)DataGridViewTextBoxColumn1).MinimumWidth = 8;
		((DataGridViewColumn)DataGridViewTextBoxColumn1).Name = "DataGridViewTextBoxColumn1";
		((DataGridViewColumn)DataGridViewTextBoxColumn1).ReadOnly = true;
		((DataGridViewColumn)DataGridViewTextBoxColumn1).Visible = false;
		((DataGridViewColumn)DataGridViewTextBoxColumn1).Width = 150;
		((DataGridViewColumn)DataGridViewTextBoxColumn2).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)DataGridViewTextBoxColumn2).DataPropertyName = "Description";
		((DataGridViewColumn)DataGridViewTextBoxColumn2).HeaderText = "Description";
		((DataGridViewColumn)DataGridViewTextBoxColumn2).MinimumWidth = 8;
		((DataGridViewColumn)DataGridViewTextBoxColumn2).Name = "DataGridViewTextBoxColumn2";
		((DataGridViewColumn)DataGridViewTextBoxColumn2).ReadOnly = true;
		((DataGridViewColumn)DataGridViewCheckBoxColumn1).DataPropertyName = "IsActive";
		((DataGridViewColumn)DataGridViewCheckBoxColumn1).HeaderText = "Active";
		((DataGridViewColumn)DataGridViewCheckBoxColumn1).MinimumWidth = 8;
		((DataGridViewColumn)DataGridViewCheckBoxColumn1).Name = "DataGridViewCheckBoxColumn1";
		((DataGridViewColumn)DataGridViewCheckBoxColumn1).ReadOnly = true;
		((DataGridViewColumn)DataGridViewCheckBoxColumn1).Width = 150;
		((ButtonBase)Button_ListDown).BackColor = Color.Transparent;
		((Control)Button_ListDown).BackgroundImage = (Image)componentResourceManager.GetObject("Button_ListDown.BackgroundImage");
		((Control)Button_ListDown).Font = new Font("Segoe UI", 10f);
		((Control)Button_ListDown).ForeColor = Color.FromArgb(220, 220, 220);
		((ButtonBase)Button_ListDown).Image = (Image)componentResourceManager.GetObject("Button_ListDown.Image");
		((Control)Button_ListDown).Location = new Point(0, 160);
		((Control)Button_ListDown).Name = "Button_ListDown";
		((Control)Button_ListDown).Padding = new Padding(5);
		((Control)Button_ListDown).Size = new Size(19, 17);
		((Control)Button_ListDown).TabIndex = 31;
		((ButtonBase)Button_ListUp).BackColor = Color.Transparent;
		((Control)Button_ListUp).BackgroundImage = (Image)componentResourceManager.GetObject("Button_ListUp.BackgroundImage");
		((Control)Button_ListUp).Font = new Font("Segoe UI", 10f);
		((Control)Button_ListUp).ForeColor = Color.FromArgb(220, 220, 220);
		((ButtonBase)Button_ListUp).Image = (Image)componentResourceManager.GetObject("Button_ListUp.Image");
		((Control)Button_ListUp).Location = new Point(0, 138);
		((Control)Button_ListUp).Name = "Button_ListUp";
		((Control)Button_ListUp).Padding = new Padding(5);
		((Control)Button_ListUp).Size = new Size(19, 17);
		((Control)Button_ListUp).TabIndex = 30;
		((Control)LB_AreaRPs).BackColor = Color.FromArgb(80, 80, 80);
		((Control)LB_AreaRPs).Location = new Point(27, 24);
		LB_AreaRPs.MultiSelect = true;
		((Control)LB_AreaRPs).Name = "LB_AreaRPs";
		LB_AreaRPs.RelatedInfos = null;
		((Control)LB_AreaRPs).Size = new Size(246, 156);
		((Control)LB_AreaRPs).TabIndex = 28;
		((DataGridView)DGV_ExclusionZone).AllowUserToAddRows = false;
		((DataGridView)DGV_ExclusionZone).AllowUserToDeleteRows = false;
		((DataGridView)DGV_ExclusionZone).AllowUserToOrderColumns = true;
		((Control)DGV_ExclusionZone).Anchor = (AnchorStyles)15;
		((DataGridView)DGV_ExclusionZone).BackgroundColor = Color.FromArgb(60, 63, 65);
		((DataGridView)DGV_ExclusionZone).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_ExclusionZone).CellBorderStyle = (DataGridViewCellBorderStyle)8;
		((DataGridView)DGV_ExclusionZone).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val4.Alignment = (DataGridViewContentAlignment)32;
		val4.BackColor = Color.FromArgb(66, 77, 95);
		val4.Font = new Font("Segoe UI", 9f);
		val4.ForeColor = Color.LightGray;
		val4.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val4.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val4.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_ExclusionZone).ColumnHeadersDefaultCellStyle = val4;
		((DataGridView)DGV_ExclusionZone).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		((DataGridView)DGV_ExclusionZone).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[4]
		{
			(DataGridViewColumn)ID,
			(DataGridViewColumn)Description,
			(DataGridViewColumn)Points,
			(DataGridViewColumn)Active
		});
		val5.Alignment = (DataGridViewContentAlignment)16;
		val5.BackColor = Color.FromArgb(60, 63, 65);
		val5.Font = new Font("Segoe UI", 9f);
		val5.ForeColor = Color.LightGray;
		val5.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val5.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val5.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_ExclusionZone).DefaultCellStyle = val5;
		((DataGridView)DGV_ExclusionZone).EditMode = (DataGridViewEditMode)4;
		((DataGridView)DGV_ExclusionZone).EnableHeadersVisualStyles = false;
		((Control)DGV_ExclusionZone).Location = new Point(582, 53);
		((DataGridView)DGV_ExclusionZone).MultiSelect = false;
		((Control)DGV_ExclusionZone).Name = "DGV_ExclusionZone";
		((DataGridView)DGV_ExclusionZone).ReadOnly = true;
		((DataGridView)DGV_ExclusionZone).RowHeadersVisible = false;
		((DataGridView)DGV_ExclusionZone).RowHeadersWidth = 62;
		val6.BackColor = Color.FromArgb(60, 63, 65);
		val6.ForeColor = Color.LightGray;
		val6.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val6.SelectionForeColor = Color.LightGray;
		((DataGridView)DGV_ExclusionZone).RowsDefaultCellStyle = val6;
		((DataGridView)DGV_ExclusionZone).SelectionMode = (DataGridViewSelectionMode)1;
		((DataGridView)DGV_ExclusionZone).ShowCellToolTips = false;
		((DataGridView)DGV_ExclusionZone).ShowEditingIcon = false;
		((DataGridView)DGV_ExclusionZone).ShowRowErrors = false;
		((Control)DGV_ExclusionZone).Size = new Size(556, 132);
		((Control)DGV_ExclusionZone).TabIndex = 25;
		((DataGridViewColumn)ID).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)ID).DataPropertyName = "ID";
		((DataGridViewColumn)ID).HeaderText = "ID";
		((DataGridViewColumn)ID).MinimumWidth = 8;
		((DataGridViewColumn)ID).Name = "ID";
		((DataGridViewColumn)ID).ReadOnly = true;
		((DataGridViewColumn)ID).Visible = false;
		((DataGridViewColumn)Description).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)Description).DataPropertyName = "Description";
		((DataGridViewColumn)Description).HeaderText = "Name";
		((DataGridViewColumn)Description).MinimumWidth = 8;
		((DataGridViewColumn)Description).Name = "Description";
		((DataGridViewColumn)Description).ReadOnly = true;
		((DataGridViewColumn)Points).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)Points).DataPropertyName = "MarkViolatorAs";
		((DataGridViewColumn)Points).HeaderText = "Unknown violators are :";
		((DataGridViewColumn)Points).MinimumWidth = 8;
		((DataGridViewColumn)Points).Name = "Points";
		((DataGridViewColumn)Points).ReadOnly = true;
		((DataGridViewColumn)Active).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)Active).DataPropertyName = "IsActive";
		((DataGridViewColumn)Active).FillWeight = 70f;
		((DataGridViewColumn)Active).HeaderText = "Active";
		((DataGridViewColumn)Active).MinimumWidth = 8;
		((DataGridViewColumn)Active).Name = "Active";
		((DataGridViewColumn)Active).ReadOnly = true;
		((ButtonBase)CBZoneIsLocked).AutoSize = true;
		((Control)CBZoneIsLocked).Location = new Point(3, 310);
		((Control)CBZoneIsLocked).Name = "CBZoneIsLocked";
		((Control)CBZoneIsLocked).Size = new Size(186, 17);
		((Control)CBZoneIsLocked).TabIndex = 18;
		((ButtonBase)CBZoneIsLocked).Text = "Locked zone (non player-editable)";
		((Control)GB_Violators).Controls.Add((Control)(object)LV_ViolatorSides);
		((Control)GB_Violators).Controls.Add((Control)(object)DarkLabel4);
		((Control)GB_Violators).Controls.Add((Control)(object)Button_ViolatorNoChanges);
		((Control)GB_Violators).Controls.Add((Control)(object)Button_ViolatorUnfriendly);
		((Control)GB_Violators).Controls.Add((Control)(object)Button_ViolatorHostile);
		((Control)GB_Violators).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GB_Violators).Location = new Point(367, 2);
		((Control)GB_Violators).Name = "GB_Violators";
		((Control)GB_Violators).Size = new Size(214, 352);
		((Control)GB_Violators).TabIndex = 15;
		((GroupBox)GB_Violators).TabStop = false;
		((GroupBox)GB_Violators).Text = "Violators";
		((Control)LV_ViolatorSides).BackColor = Color.FromArgb(40, 43, 45);
		((Control)LV_ViolatorSides).Location = new Point(6, 19);
		LV_ViolatorSides.MultiSelect = true;
		((Control)LV_ViolatorSides).Name = "LV_ViolatorSides";
		LV_ViolatorSides.RelatedInfos = null;
		((Control)LV_ViolatorSides).Size = new Size(200, 286);
		((Control)LV_ViolatorSides).TabIndex = 18;
		((Control)LV_ViolatorSides).Text = "DarkListView1";
		DarkLabel4.AutoSize = true;
		((Control)DarkLabel4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel4).Location = new Point(5, 308);
		((Control)DarkLabel4).Name = "DarkLabel4";
		((Control)DarkLabel4).Size = new Size(51, 13);
		((Control)DarkLabel4).TabIndex = 36;
		((Label)DarkLabel4).Text = "Mark as :";
		((ButtonBase)Button_ViolatorNoChanges).BackColor = Color.Transparent;
		((Control)Button_ViolatorNoChanges).ForeColor = SystemColors.Control;
		((Control)Button_ViolatorNoChanges).Location = new Point(134, 323);
		((Control)Button_ViolatorNoChanges).Name = "Button_ViolatorNoChanges";
		((Control)Button_ViolatorNoChanges).Padding = new Padding(5);
		Button_ViolatorNoChanges.RoundRadius = 0;
		((Control)Button_ViolatorNoChanges).Size = new Size(72, 23);
		((Control)Button_ViolatorNoChanges).TabIndex = 21;
		Button_ViolatorNoChanges.Text = "No Change";
		((ButtonBase)Button_ViolatorUnfriendly).BackColor = Color.Transparent;
		((Control)Button_ViolatorUnfriendly).ForeColor = Color.Orange;
		((Control)Button_ViolatorUnfriendly).Location = new Point(62, 323);
		((Control)Button_ViolatorUnfriendly).Name = "Button_ViolatorUnfriendly";
		((Control)Button_ViolatorUnfriendly).Padding = new Padding(5);
		Button_ViolatorUnfriendly.RoundRadius = 0;
		((Control)Button_ViolatorUnfriendly).Size = new Size(66, 23);
		((Control)Button_ViolatorUnfriendly).TabIndex = 20;
		Button_ViolatorUnfriendly.Text = "Unfriendly";
		((ButtonBase)Button_ViolatorHostile).BackColor = Color.Transparent;
		((Control)Button_ViolatorHostile).ForeColor = Color.FromArgb(255, 70, 70);
		((Control)Button_ViolatorHostile).Location = new Point(6, 323);
		((Control)Button_ViolatorHostile).Name = "Button_ViolatorHostile";
		((Control)Button_ViolatorHostile).Padding = new Padding(5);
		Button_ViolatorHostile.RoundRadius = 0;
		((Control)Button_ViolatorHostile).Size = new Size(50, 23);
		((Control)Button_ViolatorHostile).TabIndex = 19;
		Button_ViolatorHostile.Text = "Hostile";
		((Control)GBAppliesTo).Controls.Add((Control)(object)CBAppliesShips);
		((Control)GBAppliesTo).Controls.Add((Control)(object)CBAppliesAircraft);
		((Control)GBAppliesTo).Controls.Add((Control)(object)CBAppliesSubmarines);
		((Control)GBAppliesTo).Controls.Add((Control)(object)CBAppliesLandUnits);
		((Control)GBAppliesTo).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GBAppliesTo).Location = new Point(231, 240);
		((Control)GBAppliesTo).Name = "GBAppliesTo";
		((Control)GBAppliesTo).Size = new Size(130, 115);
		((Control)GBAppliesTo).TabIndex = 36;
		((GroupBox)GBAppliesTo).TabStop = false;
		((GroupBox)GBAppliesTo).Text = "Applies to";
		((ButtonBase)CBAppliesShips).AutoSize = true;
		((Control)CBAppliesShips).Location = new Point(8, 63);
		((Control)CBAppliesShips).Name = "CBAppliesShips";
		((Control)CBAppliesShips).Size = new Size(47, 17);
		((Control)CBAppliesShips).TabIndex = 15;
		((ButtonBase)CBAppliesShips).Text = "Ship";
		((ButtonBase)CBAppliesAircraft).AutoSize = true;
		((Control)CBAppliesAircraft).Location = new Point(8, 17);
		((Control)CBAppliesAircraft).Name = "CBAppliesAircraft";
		((Control)CBAppliesAircraft).Size = new Size(59, 17);
		((Control)CBAppliesAircraft).TabIndex = 14;
		((ButtonBase)CBAppliesAircraft).Text = "Aircraft";
		((ButtonBase)CBAppliesSubmarines).AutoSize = true;
		((Control)CBAppliesSubmarines).Location = new Point(8, 41);
		((Control)CBAppliesSubmarines).Name = "CBAppliesSubmarines";
		((Control)CBAppliesSubmarines).Size = new Size(76, 17);
		((Control)CBAppliesSubmarines).TabIndex = 16;
		((ButtonBase)CBAppliesSubmarines).Text = "Submarine";
		((ButtonBase)CBAppliesLandUnits).AutoSize = true;
		((Control)CBAppliesLandUnits).Location = new Point(8, 86);
		((Control)CBAppliesLandUnits).Name = "CBAppliesLandUnits";
		((Control)CBAppliesLandUnits).Size = new Size(72, 17);
		((Control)CBAppliesLandUnits).TabIndex = 17;
		((ButtonBase)CBAppliesLandUnits).Text = "Land Unit";
		((Control)TV_Zones).BackColor = Color.FromArgb(70, 70, 70);
		((Control)TV_Zones).Location = new Point(582, 50);
		TV_Zones.MaxDragChange = 20;
		((Control)TV_Zones).Name = "TV_Zones";
		((Control)TV_Zones).Size = new Size(556, 141);
		((Control)TV_Zones).TabIndex = 11;
		((Control)TV_Zones).Text = "DarkTreeView1";
		LabelAreaEditor.AutoSize = true;
		((Control)LabelAreaEditor).Font = new Font("Microsoft Sans Serif", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LabelAreaEditor).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)LabelAreaEditor).Location = new Point(686, 2);
		((Control)LabelAreaEditor).Name = "LabelAreaEditor";
		((Control)LabelAreaEditor).Size = new Size(89, 20);
		((Control)LabelAreaEditor).TabIndex = 6;
		((Label)LabelAreaEditor).Text = "Area Editor";
		((Label)LabelAreaEditor).TextAlign = (ContentAlignment)32;
		((ButtonBase)ButtonTabCusEnvZones).BackColor = Color.Gray;
		((ButtonBase)ButtonTabCusEnvZones).FlatStyle = (FlatStyle)0;
		((Control)ButtonTabCusEnvZones).ForeColor = SystemColors.ActiveCaptionText;
		((Control)ButtonTabCusEnvZones).Location = new Point(834, 24);
		((Control)ButtonTabCusEnvZones).Name = "ButtonTabCusEnvZones";
		((Control)ButtonTabCusEnvZones).Size = new Size(102, 23);
		((Control)ButtonTabCusEnvZones).TabIndex = 38;
		((ButtonBase)ButtonTabCusEnvZones).Text = "Cust Env Zones";
		((ButtonBase)ButtonTabCusEnvZones).UseVisualStyleBackColor = false;
		((Control)TV_CusEnvZones).BackColor = Color.FromArgb(70, 70, 70);
		((Control)TV_CusEnvZones).Location = new Point(582, 54);
		TV_CusEnvZones.MaxDragChange = 20;
		((Control)TV_CusEnvZones).Name = "TV_CusEnvZones";
		((Control)TV_CusEnvZones).Size = new Size(556, 135);
		((Control)TV_CusEnvZones).TabIndex = 41;
		((ButtonBase)btnCEZDet).BackColor = Color.Transparent;
		((Control)btnCEZDet).ForeColor = SystemColors.Control;
		((Control)btnCEZDet).Location = new Point(279, 116);
		((Control)btnCEZDet).Name = "btnCEZDet";
		((Control)btnCEZDet).Padding = new Padding(5);
		btnCEZDet.RoundRadius = 0;
		((Control)btnCEZDet).Size = new Size(82, 20);
		((Control)btnCEZDet).TabIndex = 40;
		btnCEZDet.Text = "Edit CEZ";
		((ButtonBase)BtnApproveTransformTo).BackColor = Color.Transparent;
		((Control)BtnApproveTransformTo).ForeColor = SystemColors.Control;
		((Control)BtnApproveTransformTo).Location = new Point(2, 333);
		((Control)BtnApproveTransformTo).Name = "BtnApproveTransformTo";
		((Control)BtnApproveTransformTo).Padding = new Padding(5);
		BtnApproveTransformTo.RoundRadius = 0;
		((Control)BtnApproveTransformTo).Size = new Size(91, 22);
		((Control)BtnApproveTransformTo).TabIndex = 34;
		BtnApproveTransformTo.Text = "Transform into:";
		((ButtonBase)ButtonValidateArea).BackColor = Color.Transparent;
		((Control)ButtonValidateArea).ForeColor = SystemColors.Control;
		((Control)ButtonValidateArea).Location = new Point(279, 47);
		((Control)ButtonValidateArea).Name = "ButtonValidateArea";
		((Control)ButtonValidateArea).Padding = new Padding(5);
		ButtonValidateArea.RoundRadius = 0;
		((Control)ButtonValidateArea).Size = new Size(82, 20);
		((Control)ButtonValidateArea).TabIndex = 32;
		ButtonValidateArea.Text = "Validate";
		((ButtonBase)ButtonAddselectedRPtoArea).BackColor = Color.Transparent;
		((Control)ButtonAddselectedRPtoArea).Font = new Font("Microsoft Sans Serif", 8f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)ButtonAddselectedRPtoArea).ForeColor = SystemColors.Control;
		((Control)ButtonAddselectedRPtoArea).Location = new Point(115, 0);
		((Control)ButtonAddselectedRPtoArea).Name = "ButtonAddselectedRPtoArea";
		((Control)ButtonAddselectedRPtoArea).Padding = new Padding(5);
		ButtonAddselectedRPtoArea.RoundRadius = 0;
		((Control)ButtonAddselectedRPtoArea).Size = new Size(246, 20);
		((Control)ButtonAddselectedRPtoArea).TabIndex = 29;
		ButtonAddselectedRPtoArea.Text = "Add points highlighted on map";
		((ComboBox)CBTransformTo).BackColor = Color.Transparent;
		((ComboBox)CBTransformTo).DrawMode = (DrawMode)1;
		((ComboBox)CBTransformTo).DropDownStyle = (ComboBoxStyle)2;
		((Control)CBTransformTo).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)CBTransformTo).FormattingEnabled = true;
		((ComboBox)CBTransformTo).Items.AddRange(new object[4] { "Zone", "No-nav Zone", "Exclusion Zone", "Custom Environment Zone" });
		((Control)CBTransformTo).Location = new Point(99, 333);
		((Control)CBTransformTo).Name = "CBTransformTo";
		((Control)CBTransformTo).Size = new Size(126, 21);
		((Control)CBTransformTo).TabIndex = 27;
		((ButtonBase)ButtonSave).BackColor = Color.Transparent;
		((Control)ButtonSave).ForeColor = SystemColors.Control;
		((Control)ButtonSave).Location = new Point(279, 160);
		((Control)ButtonSave).Name = "ButtonSave";
		((Control)ButtonSave).Padding = new Padding(5);
		ButtonSave.RoundRadius = 0;
		((Control)ButtonSave).Size = new Size(82, 20);
		((Control)ButtonSave).TabIndex = 23;
		ButtonSave.Text = "Save";
		((ButtonBase)ButtonExport).BackColor = Color.Transparent;
		((Control)ButtonExport).ForeColor = SystemColors.Control;
		((Control)ButtonExport).Location = new Point(279, 93);
		((Control)ButtonExport).Name = "ButtonExport";
		((Control)ButtonExport).Padding = new Padding(5);
		ButtonExport.RoundRadius = 0;
		((Control)ButtonExport).Size = new Size(82, 20);
		((Control)ButtonExport).TabIndex = 22;
		ButtonExport.Text = "Export";
		((ButtonBase)ButtonImport).BackColor = Color.Transparent;
		((Control)ButtonImport).ForeColor = SystemColors.Control;
		((Control)ButtonImport).Location = new Point(279, 70);
		((Control)ButtonImport).Name = "ButtonImport";
		((Control)ButtonImport).Padding = new Padding(5);
		ButtonImport.RoundRadius = 0;
		((Control)ButtonImport).Size = new Size(82, 20);
		((Control)ButtonImport).TabIndex = 13;
		ButtonImport.Text = "Import";
		TB_AreaName.AutoCompleteCustomSource = null;
		TB_AreaName.AutoCompleteMode = (AutoCompleteMode)0;
		TB_AreaName.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TB_AreaName).BackColor = Color.Transparent;
		((Control)TB_AreaName).ForeColor = Color.FromArgb(189, 189, 189);
		TB_AreaName.Image = null;
		TB_AreaName.Lines = null;
		((Control)TB_AreaName).Location = new Point(46, 184);
		TB_AreaName.MaxLength = 32767;
		TB_AreaName.Multiline = false;
		((Control)TB_AreaName).Name = "TB_AreaName";
		TB_AreaName.ReadOnly = false;
		TB_AreaName.ScrollBars = (ScrollBars)0;
		TB_AreaName.SelectionStart = 0;
		((Control)TB_AreaName).Size = new Size(315, 24);
		((Control)TB_AreaName).TabIndex = 19;
		TB_AreaName.TextAlign = (HorizontalAlignment)0;
		TB_AreaName.UseSystemPasswordChar = false;
		TB_AreaName.WatermarkText = "Area name . . .";
		TB_AreaName.WordWrap = false;
		((ButtonBase)ButtonDeleteArea).BackColor = Color.Transparent;
		((Control)ButtonDeleteArea).ForeColor = SystemColors.Control;
		((Control)ButtonDeleteArea).Location = new Point(279, 24);
		((Control)ButtonDeleteArea).Name = "ButtonDeleteArea";
		((Control)ButtonDeleteArea).Padding = new Padding(5);
		ButtonDeleteArea.RoundRadius = 0;
		((Control)ButtonDeleteArea).Size = new Size(82, 20);
		((Control)ButtonDeleteArea).TabIndex = 8;
		ButtonDeleteArea.Text = "Delete Area";
		((ButtonBase)ButtonCreateNewArea).BackColor = Color.Transparent;
		((Control)ButtonCreateNewArea).ForeColor = SystemColors.Control;
		((Control)ButtonCreateNewArea).Location = new Point(559, 195);
		((Control)ButtonCreateNewArea).Name = "ButtonCreateNewArea";
		((Control)ButtonCreateNewArea).Padding = new Padding(5);
		ButtonCreateNewArea.RoundRadius = 0;
		((Control)ButtonCreateNewArea).Size = new Size(109, 20);
		((Control)ButtonCreateNewArea).TabIndex = 7;
		ButtonCreateNewArea.Text = "Create New Area";
		((ButtonBase)ButtonAddRefPointToArea).BackColor = Color.Transparent;
		((Control)ButtonAddRefPointToArea).Font = new Font("Microsoft Sans Serif", 18f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)ButtonAddRefPointToArea).ForeColor = SystemColors.Control;
		((Control)ButtonAddRefPointToArea).Location = new Point(0, 25);
		((Control)ButtonAddRefPointToArea).Name = "ButtonAddRefPointToArea";
		((Control)ButtonAddRefPointToArea).Padding = new Padding(5);
		ButtonAddRefPointToArea.RoundRadius = 0;
		((Control)ButtonAddRefPointToArea).Size = new Size(19, 51);
		((Control)ButtonAddRefPointToArea).TabIndex = 5;
		ButtonAddRefPointToArea.Text = ">";
		((ButtonBase)ButtonRemoveRefPointToArea).BackColor = Color.Transparent;
		((Control)ButtonRemoveRefPointToArea).Font = new Font("Microsoft Sans Serif", 18f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)ButtonRemoveRefPointToArea).ForeColor = SystemColors.Control;
		((Control)ButtonRemoveRefPointToArea).Location = new Point(0, 82);
		((Control)ButtonRemoveRefPointToArea).Name = "ButtonRemoveRefPointToArea";
		((Control)ButtonRemoveRefPointToArea).Padding = new Padding(5);
		ButtonRemoveRefPointToArea.RoundRadius = 0;
		((Control)ButtonRemoveRefPointToArea).Size = new Size(19, 50);
		((Control)ButtonRemoveRefPointToArea).TabIndex = 4;
		ButtonRemoveRefPointToArea.Text = "<";
		ZoneOpacity_Label.AutoSize = true;
		((Control)ZoneOpacity_Label).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)ZoneOpacity_Label).Location = new Point(115, 217);
		((Control)ZoneOpacity_Label).Name = "ZoneOpacity_Label";
		((Control)ZoneOpacity_Label).Size = new Size(54, 13);
		((Control)ZoneOpacity_Label).TabIndex = 42;
		((Label)ZoneOpacity_Label).Text = "Opacity %";
		((Control)Num_ZoneOpacity).Location = new Point(171, 215);
		((Control)Num_ZoneOpacity).Name = "Num_ZoneOpacity";
		((Control)Num_ZoneOpacity).Size = new Size(44, 20);
		((Control)Num_ZoneOpacity).TabIndex = 43;
		((Control)Button_MoveDownZonePriority).Anchor = (AnchorStyles)10;
		((ButtonBase)Button_MoveDownZonePriority).BackColor = Color.Transparent;
		((Control)Button_MoveDownZonePriority).BackgroundImage = (Image)componentResourceManager.GetObject("Button_MoveDownZonePriority.BackgroundImage");
		((Control)Button_MoveDownZonePriority).Font = new Font("Segoe UI", 10f);
		((Control)Button_MoveDownZonePriority).ForeColor = Color.FromArgb(220, 220, 220);
		((ButtonBase)Button_MoveDownZonePriority).Image = (Image)componentResourceManager.GetObject("Button_MoveDownZonePriority.Image");
		((Control)Button_MoveDownZonePriority).Location = new Point(559, 115);
		((Control)Button_MoveDownZonePriority).Name = "Button_MoveDownZonePriority";
		((Control)Button_MoveDownZonePriority).Padding = new Padding(5);
		((Control)Button_MoveDownZonePriority).Size = new Size(19, 17);
		((Control)Button_MoveDownZonePriority).TabIndex = 45;
		((Control)Button_MoveUpZonePriority).Anchor = (AnchorStyles)10;
		((ButtonBase)Button_MoveUpZonePriority).BackColor = Color.Transparent;
		((Control)Button_MoveUpZonePriority).BackgroundImage = (Image)componentResourceManager.GetObject("Button_MoveUpZonePriority.BackgroundImage");
		((Control)Button_MoveUpZonePriority).Font = new Font("Segoe UI", 10f);
		((Control)Button_MoveUpZonePriority).ForeColor = Color.FromArgb(220, 220, 220);
		((ButtonBase)Button_MoveUpZonePriority).Image = (Image)componentResourceManager.GetObject("Button_MoveUpZonePriority.Image");
		((Control)Button_MoveUpZonePriority).Location = new Point(559, 94);
		((Control)Button_MoveUpZonePriority).Name = "Button_MoveUpZonePriority";
		((Control)Button_MoveUpZonePriority).Padding = new Padding(5);
		((Control)Button_MoveUpZonePriority).Size = new Size(19, 17);
		((Control)Button_MoveUpZonePriority).TabIndex = 44;
		((ButtonBase)CB_NoFireZone).AutoSize = true;
		((Control)CB_NoFireZone).Location = new Point(2, 241);
		((Control)CB_NoFireZone).Name = "CB_NoFireZone";
		((Control)CB_NoFireZone).Size = new Size(226, 17);
		((Control)CB_NoFireZone).TabIndex = 46;
		((ButtonBase)CB_NoFireZone).Text = "No Fire Zone (drop targets inside this area)";
		((ButtonBase)Button_Enablers).BackColor = Color.Transparent;
		((Control)Button_Enablers).ForeColor = SystemColors.Control;
		((Control)Button_Enablers).Location = new Point(279, 138);
		((Control)Button_Enablers).Name = "Button_Enablers";
		((Control)Button_Enablers).Padding = new Padding(5);
		Button_Enablers.RoundRadius = 0;
		((Control)Button_Enablers).Size = new Size(82, 20);
		((Control)Button_Enablers).TabIndex = 47;
		Button_Enablers.Text = "Enablers";
		((Control)TagFilterGroupBox).Controls.Add((Control)(object)FlowPanelTabTagsFilter);
		((Control)TagFilterGroupBox).Dock = (DockStyle)5;
		((Control)TagFilterGroupBox).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)TagFilterGroupBox).Location = new Point(0, 0);
		((Control)TagFilterGroupBox).Margin = new Padding(0);
		((Control)TagFilterGroupBox).Name = "TagFilterGroupBox";
		((Control)TagFilterGroupBox).Size = new Size(542, 79);
		((Control)TagFilterGroupBox).TabIndex = 1;
		((GroupBox)TagFilterGroupBox).TabStop = false;
		((GroupBox)TagFilterGroupBox).Text = "Filter reference points by Tags";
		RefPointsListTableLayout.ColumnCount = 1;
		RefPointsListTableLayout.ColumnStyles.Add(new ColumnStyle((SizeType)2, 50f));
		RefPointsListTableLayout.ColumnStyles.Add(new ColumnStyle((SizeType)2, 50f));
		RefPointsListTableLayout.Controls.Add((Control)(object)TagFilterGroupBox, 0, 0);
		RefPointsListTableLayout.Controls.Add((Control)(object)LV_ReferencePoints, 0, 1);
		((Control)RefPointsListTableLayout).Location = new Point(7, 6);
		((Control)RefPointsListTableLayout).Name = "RefPointsListTableLayout";
		RefPointsListTableLayout.RowCount = 2;
		RefPointsListTableLayout.RowStyles.Add(new RowStyle((SizeType)2, 20.76923f));
		RefPointsListTableLayout.RowStyles.Add(new RowStyle((SizeType)2, 79.23077f));
		RefPointsListTableLayout.RowStyles.Add(new RowStyle((SizeType)1, 20f));
		((Control)RefPointsListTableLayout).Size = new Size(542, 384);
		((Control)RefPointsListTableLayout).TabIndex = 1;
		((Control)CB_VisibleAreaRPs).Location = new Point(224, 215);
		((Control)CB_VisibleAreaRPs).Name = "CB_VisibleAreaRPs";
		((Control)CB_VisibleAreaRPs).Size = new Size(137, 18);
		((Control)CB_VisibleAreaRPs).TabIndex = 49;
		((ButtonBase)CB_VisibleAreaRPs).Text = "Visible Reference Points";
		((Control)ZoneConfigPanel).Controls.Add((Control)(object)ExclusionZoneAltitudeEnvelopeTable);
		((Control)ZoneConfigPanel).Controls.Add((Control)(object)lockedLabel);
		((Control)ZoneConfigPanel).Controls.Add((Control)(object)ButtonAddselectedRPtoArea);
		((Control)ZoneConfigPanel).Controls.Add((Control)(object)CB_VisibleAreaRPs);
		((Control)ZoneConfigPanel).Controls.Add((Control)(object)ButtonRemoveRefPointToArea);
		((Control)ZoneConfigPanel).Controls.Add((Control)(object)ButtonAddRefPointToArea);
		((Control)ZoneConfigPanel).Controls.Add((Control)(object)Button_Enablers);
		((Control)ZoneConfigPanel).Controls.Add((Control)(object)CB_NoFireZone);
		((Control)ZoneConfigPanel).Controls.Add((Control)(object)ButtonDeleteArea);
		((Control)ZoneConfigPanel).Controls.Add((Control)(object)GB_Violators);
		((Control)ZoneConfigPanel).Controls.Add((Control)(object)CBZoneIsLocked);
		((Control)ZoneConfigPanel).Controls.Add((Control)(object)Num_ZoneOpacity);
		((Control)ZoneConfigPanel).Controls.Add((Control)(object)TB_AreaName);
		((Control)ZoneConfigPanel).Controls.Add((Control)(object)ZoneOpacity_Label);
		((Control)ZoneConfigPanel).Controls.Add((Control)(object)ButtonImport);
		((Control)ZoneConfigPanel).Controls.Add((Control)(object)ButtonExport);
		((Control)ZoneConfigPanel).Controls.Add((Control)(object)btnCEZDet);
		((Control)ZoneConfigPanel).Controls.Add((Control)(object)ButtonSave);
		((Control)ZoneConfigPanel).Controls.Add((Control)(object)CBTransformTo);
		((Control)ZoneConfigPanel).Controls.Add((Control)(object)DarkLabel3);
		((Control)ZoneConfigPanel).Controls.Add((Control)(object)LB_AreaRPs);
		((Control)ZoneConfigPanel).Controls.Add((Control)(object)GBAppliesTo);
		((Control)ZoneConfigPanel).Controls.Add((Control)(object)Button_ListUp);
		((Control)ZoneConfigPanel).Controls.Add((Control)(object)Label_ZoneColor);
		((Control)ZoneConfigPanel).Controls.Add((Control)(object)Button_ListDown);
		((Control)ZoneConfigPanel).Controls.Add((Control)(object)ButtonZoneColorPicker);
		((Control)ZoneConfigPanel).Controls.Add((Control)(object)ButtonValidateArea);
		((Control)ZoneConfigPanel).Controls.Add((Control)(object)BtnApproveTransformTo);
		((Control)ZoneConfigPanel).Location = new Point(559, 195);
		((Control)ZoneConfigPanel).Margin = new Padding(0);
		((Control)ZoneConfigPanel).Name = "ZoneConfigPanel";
		((Control)ZoneConfigPanel).Size = new Size(591, 358);
		((Control)ZoneConfigPanel).TabIndex = 50;
		ExclusionZoneAltitudeEnvelopeTable.ColumnCount = 3;
		ExclusionZoneAltitudeEnvelopeTable.ColumnStyles.Add(new ColumnStyle((SizeType)2, 51.89189f));
		ExclusionZoneAltitudeEnvelopeTable.ColumnStyles.Add(new ColumnStyle((SizeType)2, 48.10811f));
		ExclusionZoneAltitudeEnvelopeTable.ColumnStyles.Add(new ColumnStyle((SizeType)1, 43f));
		ExclusionZoneAltitudeEnvelopeTable.Controls.Add((Control)(object)ExclusionZoneAltitudeEnvelopeMaxUOMLabel, 2, 1);
		ExclusionZoneAltitudeEnvelopeTable.Controls.Add((Control)(object)ExclusionZoneAltitudeEnvelopeMinUOMLabel, 2, 0);
		ExclusionZoneAltitudeEnvelopeTable.Controls.Add((Control)(object)ExclusionZoneAltitudeEnvelopeMaxTextBox, 1, 1);
		ExclusionZoneAltitudeEnvelopeTable.Controls.Add((Control)(object)ExclusionZoneAltitudeEnvelopeMinTextBox, 1, 0);
		ExclusionZoneAltitudeEnvelopeTable.Controls.Add((Control)(object)DarkLabel5, 0, 1);
		ExclusionZoneAltitudeEnvelopeTable.Controls.Add((Control)(object)DarkLabel2, 0, 0);
		((Control)ExclusionZoneAltitudeEnvelopeTable).Location = new Point(0, 264);
		((Control)ExclusionZoneAltitudeEnvelopeTable).Name = "ExclusionZoneAltitudeEnvelopeTable";
		ExclusionZoneAltitudeEnvelopeTable.RowCount = 2;
		ExclusionZoneAltitudeEnvelopeTable.RowStyles.Add(new RowStyle((SizeType)2, 50f));
		ExclusionZoneAltitudeEnvelopeTable.RowStyles.Add(new RowStyle((SizeType)2, 50f));
		((Control)ExclusionZoneAltitudeEnvelopeTable).Size = new Size(225, 43);
		((Control)ExclusionZoneAltitudeEnvelopeTable).TabIndex = 54;
		ExclusionZoneAltitudeEnvelopeMaxUOMLabel.AutoSize = true;
		((Control)ExclusionZoneAltitudeEnvelopeMaxUOMLabel).Dock = (DockStyle)5;
		((Control)ExclusionZoneAltitudeEnvelopeMaxUOMLabel).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)ExclusionZoneAltitudeEnvelopeMaxUOMLabel).Location = new Point(181, 21);
		((Control)ExclusionZoneAltitudeEnvelopeMaxUOMLabel).Margin = new Padding(0);
		((Control)ExclusionZoneAltitudeEnvelopeMaxUOMLabel).Name = "ExclusionZoneAltitudeEnvelopeMaxUOMLabel";
		((Control)ExclusionZoneAltitudeEnvelopeMaxUOMLabel).Size = new Size(44, 22);
		((Control)ExclusionZoneAltitudeEnvelopeMaxUOMLabel).TabIndex = 57;
		((Label)ExclusionZoneAltitudeEnvelopeMaxUOMLabel).Text = "meters";
		((Label)ExclusionZoneAltitudeEnvelopeMaxUOMLabel).TextAlign = (ContentAlignment)16;
		ExclusionZoneAltitudeEnvelopeMinUOMLabel.AutoSize = true;
		((Control)ExclusionZoneAltitudeEnvelopeMinUOMLabel).Dock = (DockStyle)5;
		((Control)ExclusionZoneAltitudeEnvelopeMinUOMLabel).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)ExclusionZoneAltitudeEnvelopeMinUOMLabel).Location = new Point(181, 0);
		((Control)ExclusionZoneAltitudeEnvelopeMinUOMLabel).Margin = new Padding(0);
		((Control)ExclusionZoneAltitudeEnvelopeMinUOMLabel).Name = "ExclusionZoneAltitudeEnvelopeMinUOMLabel";
		((Control)ExclusionZoneAltitudeEnvelopeMinUOMLabel).Size = new Size(44, 21);
		((Control)ExclusionZoneAltitudeEnvelopeMinUOMLabel).TabIndex = 56;
		((Label)ExclusionZoneAltitudeEnvelopeMinUOMLabel).Text = "meters";
		((Label)ExclusionZoneAltitudeEnvelopeMinUOMLabel).TextAlign = (ContentAlignment)16;
		ExclusionZoneAltitudeEnvelopeMaxTextBox.AutoCompleteCustomSource = null;
		ExclusionZoneAltitudeEnvelopeMaxTextBox.AutoCompleteMode = (AutoCompleteMode)0;
		ExclusionZoneAltitudeEnvelopeMaxTextBox.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)ExclusionZoneAltitudeEnvelopeMaxTextBox).BackColor = Color.Transparent;
		((Control)ExclusionZoneAltitudeEnvelopeMaxTextBox).Dock = (DockStyle)5;
		((Control)ExclusionZoneAltitudeEnvelopeMaxTextBox).ForeColor = Color.FromArgb(189, 189, 189);
		ExclusionZoneAltitudeEnvelopeMaxTextBox.Image = null;
		ExclusionZoneAltitudeEnvelopeMaxTextBox.Lines = null;
		((Control)ExclusionZoneAltitudeEnvelopeMaxTextBox).Location = new Point(94, 21);
		((Control)ExclusionZoneAltitudeEnvelopeMaxTextBox).Margin = new Padding(0);
		ExclusionZoneAltitudeEnvelopeMaxTextBox.MaxLength = 32767;
		ExclusionZoneAltitudeEnvelopeMaxTextBox.Multiline = false;
		((Control)ExclusionZoneAltitudeEnvelopeMaxTextBox).Name = "ExclusionZoneAltitudeEnvelopeMaxTextBox";
		ExclusionZoneAltitudeEnvelopeMaxTextBox.ReadOnly = false;
		ExclusionZoneAltitudeEnvelopeMaxTextBox.ScrollBars = (ScrollBars)0;
		ExclusionZoneAltitudeEnvelopeMaxTextBox.SelectionStart = 0;
		((Control)ExclusionZoneAltitudeEnvelopeMaxTextBox).Size = new Size(87, 22);
		((Control)ExclusionZoneAltitudeEnvelopeMaxTextBox).TabIndex = 55;
		ExclusionZoneAltitudeEnvelopeMaxTextBox.TextAlign = (HorizontalAlignment)0;
		ExclusionZoneAltitudeEnvelopeMaxTextBox.UseSystemPasswordChar = false;
		ExclusionZoneAltitudeEnvelopeMaxTextBox.WatermarkText = "Area name . . .";
		ExclusionZoneAltitudeEnvelopeMaxTextBox.WordWrap = false;
		ExclusionZoneAltitudeEnvelopeMinTextBox.AutoCompleteCustomSource = null;
		ExclusionZoneAltitudeEnvelopeMinTextBox.AutoCompleteMode = (AutoCompleteMode)0;
		ExclusionZoneAltitudeEnvelopeMinTextBox.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)ExclusionZoneAltitudeEnvelopeMinTextBox).BackColor = Color.Transparent;
		((Control)ExclusionZoneAltitudeEnvelopeMinTextBox).Dock = (DockStyle)5;
		((Control)ExclusionZoneAltitudeEnvelopeMinTextBox).ForeColor = Color.FromArgb(189, 189, 189);
		ExclusionZoneAltitudeEnvelopeMinTextBox.Image = null;
		ExclusionZoneAltitudeEnvelopeMinTextBox.Lines = null;
		((Control)ExclusionZoneAltitudeEnvelopeMinTextBox).Location = new Point(94, 0);
		((Control)ExclusionZoneAltitudeEnvelopeMinTextBox).Margin = new Padding(0);
		ExclusionZoneAltitudeEnvelopeMinTextBox.MaxLength = 32767;
		ExclusionZoneAltitudeEnvelopeMinTextBox.Multiline = false;
		((Control)ExclusionZoneAltitudeEnvelopeMinTextBox).Name = "ExclusionZoneAltitudeEnvelopeMinTextBox";
		ExclusionZoneAltitudeEnvelopeMinTextBox.ReadOnly = false;
		ExclusionZoneAltitudeEnvelopeMinTextBox.ScrollBars = (ScrollBars)0;
		ExclusionZoneAltitudeEnvelopeMinTextBox.SelectionStart = 0;
		((Control)ExclusionZoneAltitudeEnvelopeMinTextBox).Size = new Size(87, 21);
		((Control)ExclusionZoneAltitudeEnvelopeMinTextBox).TabIndex = 51;
		ExclusionZoneAltitudeEnvelopeMinTextBox.TextAlign = (HorizontalAlignment)0;
		ExclusionZoneAltitudeEnvelopeMinTextBox.UseSystemPasswordChar = false;
		ExclusionZoneAltitudeEnvelopeMinTextBox.WatermarkText = "Area name . . .";
		ExclusionZoneAltitudeEnvelopeMinTextBox.WordWrap = false;
		DarkLabel5.AutoSize = true;
		((Control)DarkLabel5).Dock = (DockStyle)5;
		((Control)DarkLabel5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel5).Location = new Point(0, 21);
		((Control)DarkLabel5).Margin = new Padding(0);
		((Control)DarkLabel5).Name = "DarkLabel5";
		((Control)DarkLabel5).Size = new Size(94, 22);
		((Control)DarkLabel5).TabIndex = 53;
		((Label)DarkLabel5).Text = "Maximum Altitude:";
		((Label)DarkLabel5).TextAlign = (ContentAlignment)16;
		DarkLabel2.AutoSize = true;
		((Control)DarkLabel2).Dock = (DockStyle)5;
		((Control)DarkLabel2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel2).Location = new Point(0, 0);
		((Control)DarkLabel2).Margin = new Padding(0);
		((Control)DarkLabel2).Name = "DarkLabel2";
		((Control)DarkLabel2).Size = new Size(94, 21);
		((Control)DarkLabel2).TabIndex = 52;
		((Label)DarkLabel2).Text = "Mininum Altitude:";
		((Label)DarkLabel2).TextAlign = (ContentAlignment)16;
		lockedLabel.AutoSize = true;
		((Control)lockedLabel).BackColor = Color.DimGray;
		((Control)lockedLabel).Font = new Font("Microsoft Sans Serif", 27.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)lockedLabel).ForeColor = Color.White;
		((Control)lockedLabel).Location = new Point(60, 81);
		((Control)lockedLabel).Name = "lockedLabel";
		((Control)lockedLabel).Size = new Size(178, 42);
		((Control)lockedLabel).TabIndex = 50;
		lockedLabel.Text = "LOCKED";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).BackColor = Color.FromArgb(60, 63, 65);
		((Form)this).ClientSize = new Size(1145, 556);
		((Control)this).Controls.Add((Control)(object)ButtonCreateNewArea);
		((Control)this).Controls.Add((Control)(object)ZoneConfigPanel);
		((Control)this).Controls.Add((Control)(object)RefPointsListTableLayout);
		((Control)this).Controls.Add((Control)(object)Button_MoveDownZonePriority);
		((Control)this).Controls.Add((Control)(object)Button_MoveUpZonePriority);
		((Control)this).Controls.Add((Control)(object)TV_CusEnvZones);
		((Control)this).Controls.Add((Control)(object)ButtonTabCusEnvZones);
		((Control)this).Controls.Add((Control)(object)DGV_NoNavZone);
		((Control)this).Controls.Add((Control)(object)DGV_ExclusionZone);
		((Control)this).Controls.Add((Control)(object)ButtonTabExclusionZones);
		((Control)this).Controls.Add((Control)(object)ButtonTabNoNavZones);
		((Control)this).Controls.Add((Control)(object)TV_Zones);
		((Control)this).Controls.Add((Control)(object)ButtonTabZones);
		((Control)this).Controls.Add((Control)(object)LabelAreaEditor);
		((Control)this).Controls.Add((Control)(object)Panel3);
		((Control)this).Controls.Add((Control)(object)RefPointEditorPanel);
		((Form)this).MaximumSize = new Size(1161, 595);
		((Form)this).MinimumSize = new Size(1161, 595);
		((Control)this).Name = "ReferencePointManager";
		((Form)this).ShowIcon = false;
		((Form)this).Text = "Area & Reference Points Manager";
		((Control)RefPointEditorPanel).ResumeLayout(false);
		((Control)RefPointEditorPanel).PerformLayout();
		((Control)Panel3).ResumeLayout(false);
		((Control)Panel3).PerformLayout();
		((Control)FlowPanelTabTagsFilter).ResumeLayout(false);
		((ISupportInitialize)(object)DGV_NoNavZone).EndInit();
		((ISupportInitialize)(object)DGV_ExclusionZone).EndInit();
		((Control)GB_Violators).ResumeLayout(false);
		((Control)GB_Violators).PerformLayout();
		((Control)GBAppliesTo).ResumeLayout(false);
		((Control)GBAppliesTo).PerformLayout();
		((ISupportInitialize)Num_ZoneOpacity).EndInit();
		((Control)TagFilterGroupBox).ResumeLayout(false);
		((Control)RefPointsListTableLayout).ResumeLayout(false);
		((Control)ZoneConfigPanel).ResumeLayout(false);
		((Control)ZoneConfigPanel).PerformLayout();
		((Control)ExclusionZoneAltitudeEnvelopeTable).ResumeLayout(false);
		((Control)ExclusionZoneAltitudeEnvelopeTable).PerformLayout();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	public void ReleaseReferences()
	{
		try
		{
			if (((Control)this).Visible)
			{
				((Form)this).Close();
			}
			RefPoints.Clear();
			dictionary_0.Clear();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public void ShowWithZoneType(IWin32Window owner, Zone.ZoneType requestedZoneType)
	{
		zoneType_1 = requestedZoneType;
		zone_0 = null;
		((Form)this).Show(owner);
	}

	public void ShowWithZoneType(Zone.ZoneType requestedZoneType)
	{
		zoneType_1 = requestedZoneType;
		zone_0 = null;
		((Control)this).Show();
	}

	public void ShowWithSelectedZone(IWin32Window owner, Zone requestedSelectedZone)
	{
		zoneType_1 = requestedSelectedZone.Type;
		zone_0 = requestedSelectedZone;
		((Form)this).Show(owner);
	}

	private void ReferencePointManager_Load(object sender, EventArgs e)
	{
		if (Client.Realtime)
		{
			bool_2 = true;
		}
		RefPoints = Client.CurrentSide.RefPoints;
		method_0();
		method_16();
		method_12();
		Client.CurrentScenario.GetNatureSide();
		((Control)ButtonTabCusEnvZones).Visible = Client.CurrentGame.IsScenEditGameMode;
		if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
		{
			((Label)ExclusionZoneAltitudeEnvelopeMinUOMLabel).Text = "feet";
			((Label)ExclusionZoneAltitudeEnvelopeMaxUOMLabel).Text = "feet";
		}
		method_20(zoneType_1);
		if (zone_0 != null && zone_0.Type == zoneType_1)
		{
			switch (zoneType_1)
			{
			case Zone.ZoneType.NoNavZone:
				SelectedStdZone = (NoNavZone)zone_0;
				((DataGridView)DGV_NoNavZone).ClearSelection();
				((DataGridView)DGV_NoNavZone).Rows[Client.CurrentSide.NoNavZones.IndexOf(SelectedStdZone)].Selected = true;
				break;
			case Zone.ZoneType.ExclusionZone:
				SelectedExclusionZone = (ExclusionZone)zone_0;
				((DataGridView)DGV_ExclusionZone).ClearSelection();
				((DataGridView)DGV_ExclusionZone).Rows[Client.CurrentSide.ExclusionZones.IndexOf(SelectedExclusionZone)].Selected = true;
				break;
			}
		}
		zoneType_1 = Zone.ZoneType.Zone;
		zone_0 = null;
	}

	private void method_0(bool bool_3 = false)
	{
		List<int> list = new List<int>();
		foreach (int selectedIndex in LV_ReferencePoints.SelectedIndices)
		{
			list.Add(selectedIndex);
		}
		dictionary_0.Clear();
		LV_ReferencePoints.Items.Clear();
		List<ReferencePoint> list2 = Client.CurrentSide.RefPoints.OrderBy([SpecialName] (ReferencePoint x) => x.Name).ToList();
		foreach (ReferencePoint item in list2)
		{
			bool flag = false;
			if (item.Tags.Count > 0)
			{
				flag = true;
				foreach (KeyValuePair<ReferencePointFlag, ReferencePointFlag> tag in item.Tags)
				{
					if (Filters.ContainsKey(tag.Key) && Filters[tag.Key])
					{
						flag = false;
						break;
					}
				}
			}
			if (flag)
			{
				continue;
			}
			string text = "";
			if (!item.IsVisible)
			{
				text = "[hidden] ";
			}
			string text2 = "";
			if (item.Tags.Count > 0)
			{
				List<string> list3 = new List<string>();
				foreach (KeyValuePair<ReferencePointFlag, ReferencePointFlag> tag2 in item.Tags)
				{
					list3.Add(tag2.Value.Name);
				}
				text2 = "  [" + string.Join(",", list3) + "]";
			}
			LV_ReferencePoints.Items.Add(new DarkListItem(text + item.Name + text2));
			LV_ReferencePoints.Items.ElementAt(LV_ReferencePoints.Items.Count - 1).TextColor = item.color;
			if (!dictionary_0.ContainsKey(LV_ReferencePoints.Items.Count - 1))
			{
				dictionary_0.Add(LV_ReferencePoints.Items.Count - 1, item);
			}
		}
		if (dictionary_0.Count > 0)
		{
			if (!bool_3)
			{
				LV_ReferencePoints.SelectItem(dictionary_0.ElementAt(0).Key);
			}
			else
			{
				try
				{
					LV_ReferencePoints.SelectItems(list);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					LV_ReferencePoints.SelectItem(dictionary_0.ElementAt(0).Key);
					ProjectData.ClearProjectError();
				}
			}
		}
		method_3();
		method_17();
	}

	private void method_1(object object_0, ObservableListModified<ReferencePoint> observableListModified_0)
	{
		if (EnableReferencePointEvents)
		{
			method_0();
		}
	}

	private void method_2(object object_0, ObservableListModified<ReferencePoint> observableListModified_0)
	{
		if (EnableReferencePointEvents)
		{
			method_0();
		}
	}

	private void method_3()
	{
		if (LV_ReferencePoints.SelectedIndices.Count == 0)
		{
			method_4(bool_3: false);
			return;
		}
		ReferencePoint referencePoint = GetReferencePoint();
		if (referencePoint == null)
		{
			method_4(bool_3: false);
			return;
		}
		method_4(bool_3: true);
		referencePoint = dictionary_0[LV_ReferencePoints.SelectedIndices.ElementAt(0)];
		RefPointName.Text = referencePoint.Name;
		((Label)RefPointLatitude).Text = Misc.LatitudeToEnglish(referencePoint.Latitude);
		((Label)RefPointLongitude).Text = Misc.LongitudeToEnglish(referencePoint.Longitude);
		((ButtonBase)RefPointColorButton).BackColor = referencePoint.color;
		((CheckBox)CB_VisibleRP).Checked = referencePoint.IsVisible;
		Client.HighlightedRefPoints.Clear();
		Client.HighlightedRefPoints.Add(referencePoint);
		method_17();
	}

	private void method_4(bool bool_3)
	{
		((Control)RefPointLongitude).Visible = bool_3;
		((Control)RefPointEditorPanel).Visible = bool_3;
	}

	public ReferencePoint GetReferencePoint()
	{
		if (LV_ReferencePoints.SelectedIndices.Count != 0)
		{
			if (dictionary_0.ContainsKey(LV_ReferencePoints.SelectedIndices.ElementAt(0)))
			{
				return dictionary_0[LV_ReferencePoints.SelectedIndices.ElementAt(0)];
			}
			return null;
		}
		return null;
	}

	public List<ReferencePoint> GetReferencePointMultipleSelection()
	{
		if (LV_ReferencePoints.SelectedIndices.Count == 0)
		{
			return null;
		}
		List<ReferencePoint> list = new List<ReferencePoint>();
		foreach (int selectedIndex in LV_ReferencePoints.SelectedIndices)
		{
			if (dictionary_0.ContainsKey(selectedIndex))
			{
				list.Add(dictionary_0[selectedIndex]);
			}
		}
		return list;
	}

	private void method_5(object sender, EventArgs e)
	{
		method_3();
	}

	private void method_6(object sender, EventArgs e)
	{
		ReferencePoint referencePoint = GetReferencePoint();
		if (referencePoint != null)
		{
			MyProject.Forms.MainForm.set_MapCenter(MustRender: true, new GeoPoint(referencePoint.Longitude, referencePoint.Latitude));
		}
	}

	private void method_7(object sender, EventArgs e)
	{
		ReferencePoint referencePoint = GetReferencePoint();
		if (referencePoint != null)
		{
			MyProject.Forms.MainForm.set_MapCenter(MustRender: true, new GeoPoint(referencePoint.Longitude, referencePoint.Latitude));
		}
	}

	private void method_8(object sender, EventArgs e)
	{
		List<ReferencePoint> referencePointMultipleSelection = GetReferencePointMultipleSelection();
		if (referencePointMultipleSelection == null || referencePointMultipleSelection.Count == 0)
		{
			return;
		}
		EnableReferencePointEvents = false;
		foreach (ReferencePoint item in referencePointMultipleSelection)
		{
			if (Client.Realtime)
			{
				Client.RealtimeTerminal.SendDeleteReferencePoint(Client.CurrentSide, item);
			}
			Client.CurrentSide.RefPoints.Remove(item);
		}
		EnableReferencePointEvents = true;
		if (LV_ReferencePoints.Items.Count > 1)
		{
			LV_ReferencePoints.SelectItem(LV_ReferencePoints.SelectedIndices.ElementAt(0) - 1, ThrowE: false);
		}
		method_0();
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		if (((Message)(ref msg)).WParam.ToInt32() == 13)
		{
			method_29();
			List<ReferencePoint> referencePointMultipleSelection = GetReferencePointMultipleSelection();
			if (referencePointMultipleSelection != null && referencePointMultipleSelection.Count > 0)
			{
				foreach (ReferencePoint item in referencePointMultipleSelection)
				{
					item.Name = RefPointName.Text;
				}
				method_0(bool_3: true);
			}
			switch (zoneType_2)
			{
			case Zone.ZoneType.CustomEnvironmentZone:
				if (!Information.IsNothing((object)SelectedCustomEnvironmentZone))
				{
					SelectedCustomEnvironmentZone.AreaColor = Color.FromArgb((byte)Math.Round(Math.Min(Convert.ToDouble(Num_ZoneOpacity.Value) * 2.55, 255.0)), SelectedCustomEnvironmentZone.AreaColor.R, SelectedCustomEnvironmentZone.AreaColor.G, SelectedCustomEnvironmentZone.AreaColor.B);
				}
				break;
			case Zone.ZoneType.Zone:
				if (!Information.IsNothing((object)SelectedStandardZone))
				{
					SelectedStandardZone.AreaColor = Color.FromArgb((byte)Math.Round(Math.Min(Convert.ToDouble(Num_ZoneOpacity.Value) * 2.55, 255.0)), SelectedStandardZone.AreaColor.R, SelectedStandardZone.AreaColor.G, SelectedStandardZone.AreaColor.B);
				}
				break;
			}
			if (LV_Tags.SelectedItems.Count > 0)
			{
				ReferencePointFlag referencePointFlag = (ReferencePointFlag)LV_Tags.SelectedItems.ElementAt(0).Tag;
				if (Client.CurrentSide.RefPointsTag.ContainsKey(referencePointFlag))
				{
					referencePointFlag.Name = SelectedTagTextBox.Text;
				}
			}
			method_12();
			method_16();
			return true;
		}
		return ((Form)this).ProcessCmdKey(ref msg, keyData);
	}

	private void method_9(object sender, EventArgs e)
	{
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(SelectedTagTextBox.Text, "", true) != 0)
		{
			foreach (ReferencePointFlag key in Client.CurrentSide.RefPointsTag.Keys)
			{
				if (Operators.CompareString(key.Name, SelectedTagTextBox.Text, true) == 0)
				{
					DarkMessageBox.ShowError("Please select a different name", "A tag with the same name already exists");
					return;
				}
			}
		}
		Client.CurrentSide.TagsCumulativeCount++;
		string name = "Tag" + Client.CurrentSide.TagsCumulativeCount;
		if (Operators.CompareString(SelectedTagTextBox.Text, "", true) != 0)
		{
			name = SelectedTagTextBox.Text;
		}
		Client.CurrentSide.RefPointsTag.Add(new ReferencePointFlag(name), new Dictionary<ReferencePoint, ReferencePoint>());
		method_12();
		method_17();
		method_16();
	}

	private void method_10(object sender, EventArgs e)
	{
		if (LV_Tags.SelectedItems.Count == 0)
		{
			return;
		}
		ReferencePointFlag key = (ReferencePointFlag)LV_Tags.SelectedItems.ElementAt(0).Tag;
		if (!Client.CurrentSide.RefPointsTag.ContainsKey(key))
		{
			return;
		}
		foreach (KeyValuePair<ReferencePoint, ReferencePoint> item in Client.CurrentSide.RefPointsTag[key])
		{
			if (item.Key.Tags.ContainsKey(key))
			{
				item.Key.Tags.Remove(key);
			}
		}
		Client.CurrentSide.RefPointsTag.Remove(key);
		method_12();
		method_17();
		method_16();
		foreach (ReferencePoint refPoint in Client.CurrentSide.RefPoints)
		{
			if (refPoint.Tags.ContainsKey(key))
			{
				refPoint.Tags.Remove(key);
			}
		}
		method_0(bool_3: true);
	}

	private void method_11(object sender, EventArgs e)
	{
		if (LV_Tags.SelectedIndices.Count != 0)
		{
			SelectedTagTextBox.Text = LV_Tags.SelectedItems.ElementAt(0).Text;
		}
	}

	private void method_12()
	{
		LV_Tags.Items.Clear();
		if (Client.CurrentSide.RefPointsTag.Count == 0)
		{
			return;
		}
		foreach (KeyValuePair<ReferencePointFlag, Dictionary<ReferencePoint, ReferencePoint>> item in Client.CurrentSide.RefPointsTag)
		{
			DarkListItem darkListItem = new DarkListItem(item.Key.Name);
			darkListItem.Tag = item.Key;
			LV_Tags.Items.Add(darkListItem);
		}
		SelectedTagTextBox.Text = Client.CurrentSide.RefPointsTag.ElementAt(0).Key.Name;
		LV_Tags.SelectItem(LV_Tags.Items.Count - 1);
	}

	private void method_13(object sender, EventArgs e)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Invalid comparison between Unknown and I4
		List<ReferencePoint> referencePointMultipleSelection = GetReferencePointMultipleSelection();
		if (referencePointMultipleSelection.Count == 0)
		{
			return;
		}
		ColorDialog val = new ColorDialog();
		if ((int)((CommonDialog)val).ShowDialog() == 1)
		{
			foreach (ReferencePoint item in referencePointMultipleSelection)
			{
				item.color = val.Color;
				if (Client.Realtime)
				{
					Client.RealtimeTerminal.SendReferencePointUpdate(Client.CurrentSide, item);
				}
			}
		}
		method_0(bool_3: true);
	}

	private void method_14(object sender, EventArgs e)
	{
		if (LV_Tags.SelectedIndices.Count == 0)
		{
			return;
		}
		ReferencePointFlag referencePointFlag = (ReferencePointFlag)LV_Tags.SelectedItems.ElementAt(0).Tag;
		if (!Client.CurrentSide.RefPointsTag.ContainsKey(referencePointFlag))
		{
			return;
		}
		List<ReferencePoint> referencePointMultipleSelection = GetReferencePointMultipleSelection();
		if (referencePointMultipleSelection == null || referencePointMultipleSelection.Count == 0)
		{
			return;
		}
		foreach (ReferencePoint item in referencePointMultipleSelection)
		{
			if (!item.Tags.ContainsKey(referencePointFlag))
			{
				item.Tags.Add(referencePointFlag, referencePointFlag);
				continue;
			}
			return;
		}
		method_17();
		method_0(bool_3: true);
	}

	private void method_15(object sender, EventArgs e)
	{
		if (((ComboBox)RefPointTagListCombo).SelectedItem == null)
		{
			return;
		}
		ReferencePointFlag redFlag = ((TagComboboxItem)((ComboBox)RefPointTagListCombo).SelectedItem).RedFlag;
		bool flag = false;
		List<ReferencePoint> referencePointMultipleSelection = GetReferencePointMultipleSelection();
		if (referencePointMultipleSelection == null || referencePointMultipleSelection.Count == 0)
		{
			return;
		}
		foreach (ReferencePoint item in referencePointMultipleSelection)
		{
			if (item.Tags.ContainsKey(redFlag))
			{
				item.Tags.Remove(redFlag);
				flag = true;
			}
		}
		if (flag)
		{
			method_17();
			method_0(bool_3: true);
		}
	}

	public void TagFilterButtonClick(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		Button val = (Button)sender;
		ReferencePointFlag key = (ReferencePointFlag)((Control)val).Tag;
		Filters[key] = !Filters[key];
		if (Filters[key])
		{
			((ButtonBase)val).BackColor = Color.FromArgb(60, 90, 60);
		}
		else
		{
			((ButtonBase)val).BackColor = Color.FromArgb(90, 60, 60);
		}
		method_0();
	}

	private void method_16()
	{
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		if (float_0 == 0f)
		{
			float_0 = RefPointsListTableLayout.RowStyles[0].Height;
		}
		List<Button> list = new List<Button>();
		((Control)FlowPanelTabTagsFilter).Controls.Clear();
		foreach (KeyValuePair<ReferencePointFlag, Dictionary<ReferencePoint, ReferencePoint>> item in Client.CurrentSide.RefPointsTag)
		{
			list.Add(new Button());
			if (!Filters.ContainsKey(item.Key))
			{
				Filters.Add(item.Key, value: true);
			}
			Button val = list[list.Count - 1];
			((ButtonBase)val).Text = item.Key.Name;
			if (!Filters[item.Key])
			{
				((ButtonBase)val).BackColor = Color.FromArgb(90, 60, 60);
			}
			else
			{
				((ButtonBase)val).BackColor = Color.FromArgb(60, 90, 60);
			}
			((Control)val).ForeColor = Color.White;
			((ButtonBase)val).FlatStyle = (FlatStyle)0;
			((Control)val).Tag = item.Key;
			((Control)val).Click += TagFilterButtonClick;
			((Control)FlowPanelTabTagsFilter).Controls.Add((Control)(object)val);
		}
		if (Client.CurrentSide.RefPointsTag.Count > 0)
		{
			((Control)TagFilterGroupBox).Visible = true;
			RefPointsListTableLayout.RowStyles[0].Height = float_0;
		}
		else
		{
			((Control)TagFilterGroupBox).Visible = false;
			RefPointsListTableLayout.RowStyles[0].Height = 0f;
		}
		method_0(bool_3: true);
	}

	private void method_17()
	{
		ReferencePoint referencePoint = GetReferencePoint();
		if (referencePoint == null || LV_Tags.SelectedIndices.Count == 0)
		{
			return;
		}
		((ComboBox)RefPointTagListCombo).BeginUpdate();
		((ComboBox)RefPointTagListCombo).Items.Clear();
		((ListControl)RefPointTagListCombo).DisplayMember = "Name";
		((Control)RefPointTagListCombo).Tag = "RedFlag";
		foreach (KeyValuePair<ReferencePointFlag, ReferencePointFlag> tag in referencePoint.Tags)
		{
			if (Client.CurrentSide.RefPointsTag.ContainsKey(tag.Key))
			{
				((ComboBox)RefPointTagListCombo).Items.Add((object)new TagComboboxItem(tag.Key.Name, tag.Key));
			}
		}
		if (((ComboBox)RefPointTagListCombo).Items.Count > 0)
		{
			((ComboBox)RefPointTagListCombo).SelectedIndex = 0;
		}
		((ComboBox)RefPointTagListCombo).EndUpdate();
	}

	private void method_18(List<ReferencePoint> list_0)
	{
		AreaPoints = list_0;
		method_19();
	}

	private void method_19()
	{
		LB_AreaRPs.Items.Clear();
		if (Information.IsNothing((object)AreaPoints))
		{
			return;
		}
		foreach (ReferencePoint areaPoint in AreaPoints)
		{
			DarkListItem darkListItem = new DarkListItem(areaPoint.Name);
			darkListItem.Tag = areaPoint;
			LB_AreaRPs.Items.Add(darkListItem);
		}
	}

	private void method_20(Zone.ZoneType zoneType_3, bool bool_3 = true)
	{
		Num_ZoneOpacity.ValueChanged -= method_71;
		switch (zoneType_3)
		{
		case Zone.ZoneType.Zone:
			method_45(bool_3: true, bool_4: false);
			if (bool_3)
			{
				method_25();
			}
			((Label)LabelAreaEditor).Text = "Zones";
			((Control)GB_Violators).Visible = false;
			((Control)GBAppliesTo).Visible = false;
			((Control)Button_MoveDownZonePriority).Visible = true;
			((Control)Button_MoveUpZonePriority).Visible = true;
			zoneType_2 = Zone.ZoneType.Zone;
			((Control)TV_Zones).Visible = true;
			((Control)DGV_ExclusionZone).Visible = false;
			((Control)DGV_NoNavZone).Visible = false;
			((Control)ButtonImport).Visible = false;
			((Control)ButtonExport).Visible = false;
			((Control)ZoneOpacity_Label).Visible = true;
			((Control)Num_ZoneOpacity).Visible = true;
			((Control)CB_NoFireZone).Visible = false;
			((Control)ButtonZoneColorPicker).Visible = true;
			if (SelectedStandardZone != null)
			{
				((ButtonBase)ButtonZoneColorPicker).BackColor = SelectedStandardZone.AreaColor;
				Num_ZoneOpacity.Value = Math.Min(new decimal((float)(int)SelectedStandardZone.AreaColor.A / 255f * 100f), 100m);
			}
			else
			{
				((ButtonBase)ButtonZoneColorPicker).BackColor = Color.White;
				Num_ZoneOpacity.Value = 100m;
			}
			((Control)CB_VisibleAreaRPs).Visible = true;
			((Control)Label_ZoneColor).Visible = true;
			((Control)TV_CusEnvZones).Visible = false;
			((Control)btnCEZDet).Visible = false;
			((Control)Button_Enablers).Visible = SelectedStandardZone != null;
			((Control)CBTransformTo).Visible = true;
			((Control)BtnApproveTransformTo).Visible = true;
			((Control)ExclusionZoneAltitudeEnvelopeTable).Visible = false;
			break;
		case Zone.ZoneType.NoNavZone:
			method_45(bool_3: true, bool_4: false);
			if (bool_3)
			{
				method_24();
			}
			((Label)LabelAreaEditor).Text = "No-Nav Zones";
			((Control)GB_Violators).Visible = false;
			((Control)GBAppliesTo).Visible = true;
			zoneType_2 = Zone.ZoneType.NoNavZone;
			((Control)TV_Zones).Visible = false;
			((Control)DGV_ExclusionZone).Visible = false;
			((Control)DGV_NoNavZone).Visible = true;
			((Control)ButtonImport).Visible = true;
			((Control)ButtonExport).Visible = true;
			((Control)Button_MoveDownZonePriority).Visible = false;
			((Control)Button_MoveUpZonePriority).Visible = false;
			((Control)ButtonZoneColorPicker).Visible = false;
			((Control)CB_VisibleAreaRPs).Visible = true;
			((Control)Label_ZoneColor).Visible = false;
			((Control)TV_CusEnvZones).Visible = false;
			((Control)btnCEZDet).Visible = false;
			((Control)Button_Enablers).Visible = false;
			((Control)CBTransformTo).Visible = true;
			((Control)BtnApproveTransformTo).Visible = true;
			((Control)ZoneOpacity_Label).Visible = false;
			((Control)Num_ZoneOpacity).Visible = false;
			((Control)CB_NoFireZone).Visible = true;
			((Control)ExclusionZoneAltitudeEnvelopeTable).Visible = false;
			break;
		case Zone.ZoneType.ExclusionZone:
			method_45(bool_3: false, bool_4: false);
			if (bool_3)
			{
				method_23();
			}
			((Label)LabelAreaEditor).Text = "Exclusion Zones";
			((Control)GB_Violators).Visible = true;
			((Control)GBAppliesTo).Visible = true;
			((Control)CB_NoFireZone).Visible = false;
			zoneType_2 = Zone.ZoneType.ExclusionZone;
			((Control)TV_Zones).Visible = false;
			((Control)Button_MoveDownZonePriority).Visible = false;
			((Control)Button_MoveUpZonePriority).Visible = false;
			((Control)DGV_ExclusionZone).Visible = true;
			((Control)DGV_NoNavZone).Visible = false;
			((Control)ButtonImport).Visible = true;
			((Control)ButtonExport).Visible = true;
			((Control)ButtonZoneColorPicker).Visible = false;
			((Control)CB_VisibleAreaRPs).Visible = true;
			((Control)Label_ZoneColor).Visible = false;
			((Control)ZoneOpacity_Label).Visible = false;
			((Control)Num_ZoneOpacity).Visible = false;
			((Control)TV_CusEnvZones).Visible = false;
			((Control)btnCEZDet).Visible = false;
			((Control)Button_Enablers).Visible = false;
			((Control)CBTransformTo).Visible = true;
			((Control)BtnApproveTransformTo).Visible = true;
			((Control)ExclusionZoneAltitudeEnvelopeTable).Visible = true;
			break;
		case Zone.ZoneType.CustomEnvironmentZone:
			method_45(bool_3: false, bool_4: false);
			if (bool_3)
			{
				method_26();
			}
			((Label)LabelAreaEditor).Text = "Custom Environment Zones";
			((Control)GB_Violators).Visible = false;
			((Control)GBAppliesTo).Visible = false;
			zoneType_2 = Zone.ZoneType.CustomEnvironmentZone;
			((Control)TV_Zones).Visible = true;
			((Control)DGV_ExclusionZone).Visible = false;
			((Control)DGV_NoNavZone).Visible = false;
			((Control)TV_CusEnvZones).Visible = true;
			((Control)Button_MoveDownZonePriority).Visible = true;
			((Control)Button_MoveUpZonePriority).Visible = true;
			((Control)ButtonImport).Visible = false;
			((Control)ButtonExport).Visible = false;
			((Control)ButtonZoneColorPicker).Visible = true;
			((Control)CB_VisibleAreaRPs).Visible = false;
			((Control)Label_ZoneColor).Visible = true;
			((Control)btnCEZDet).Visible = true;
			((Control)Button_Enablers).Visible = false;
			((Control)CBTransformTo).Visible = false;
			((Control)BtnApproveTransformTo).Visible = false;
			if (Information.IsNothing((object)SelectedCustomEnvironmentZone))
			{
				((ButtonBase)ButtonZoneColorPicker).BackColor = Color.White;
				Num_ZoneOpacity.Value = 100m;
			}
			else
			{
				((ButtonBase)ButtonZoneColorPicker).BackColor = SelectedCustomEnvironmentZone.AreaColor;
				Num_ZoneOpacity.Value = Math.Min(new decimal((float)(int)SelectedCustomEnvironmentZone.AreaColor.A / 255f * 100f), 100m);
			}
			((Control)CB_NoFireZone).Visible = false;
			((Control)ExclusionZoneAltitudeEnvelopeTable).Visible = false;
			break;
		}
		Num_ZoneOpacity.ValueChanged += method_71;
	}

	private void method_21()
	{
		TB_AreaName.Text = SelectedExclusionZone.Description;
		if (SelectedExclusionZone.Area != null && SelectedExclusionZone.Area.Count > 0)
		{
			((CheckBox)CB_VisibleAreaRPs).Checked = SelectedExclusionZone.Area.First().IsVisible;
		}
		((CheckBox)CBAppliesAircraft).Checked = SelectedExclusionZone.AffectedUnitTypes.Contains(GlobalVariables.ActiveUnitType.Aircraft);
		((CheckBox)CBAppliesShips).Checked = SelectedExclusionZone.AffectedUnitTypes.Contains(GlobalVariables.ActiveUnitType.Ship);
		((CheckBox)CBAppliesSubmarines).Checked = SelectedExclusionZone.AffectedUnitTypes.Contains(GlobalVariables.ActiveUnitType.Submarine);
		((CheckBox)CBAppliesLandUnits).Checked = SelectedExclusionZone.AffectedUnitTypes.Contains(GlobalVariables.ActiveUnitType.Facility);
		method_79(SelectedExclusionZone.AltitudeEnvelopeMin, ExclusionZoneAltitudeEnvelopeMinTextBox);
		method_79(SelectedExclusionZone.AltitudeEnvelopeMax, ExclusionZoneAltitudeEnvelopeMaxTextBox);
		LV_ViolatorSides.Items.Clear();
		DarkListItem darkListItem = new DarkListItem();
		darkListItem.Text = "Unknown";
		SelectedExclusionZone.AddUnknownViolatorStanceIfNotContained();
		switch (SelectedExclusionZone.ViolatorsStance["UnknownContactSide"])
		{
		case Misc.PostureStance.Unfriendly:
			darkListItem.TextColor = Color.Orange;
			break;
		case Misc.PostureStance.Hostile:
			darkListItem.TextColor = Color.FromArgb(255, 70, 70);
			break;
		case Misc.PostureStance.Unknown:
			darkListItem.TextColor = Color.White;
			break;
		}
		darkListItem.Tag = "UnknownContactSide";
		LV_ViolatorSides.Items.Add(darkListItem);
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		foreach (Side side in sides_ReadOnly)
		{
			if (Operators.CompareString(side.ObjectID, Client.CurrentSide.ObjectID, true) != 0)
			{
				if (!SelectedExclusionZone.ViolatorsStance.ContainsKey(side.ObjectID))
				{
					SelectedExclusionZone.ViolatorsStance.Add(side.ObjectID, SelectedExclusionZone.MarkViolatorAs);
				}
				DarkListItem darkListItem2 = new DarkListItem();
				darkListItem2.Text = side.Name;
				switch (SelectedExclusionZone.ViolatorsStance[side.ObjectID])
				{
				case Misc.PostureStance.Unfriendly:
					darkListItem2.TextColor = Color.Orange;
					break;
				case Misc.PostureStance.Hostile:
					darkListItem2.TextColor = Color.FromArgb(255, 70, 70);
					break;
				case Misc.PostureStance.Unknown:
					darkListItem2.TextColor = Color.White;
					break;
				}
				darkListItem2.Tag = side.ObjectID;
				LV_ViolatorSides.Items.Add(darkListItem2);
			}
		}
	}

	private void method_22()
	{
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add("ID", typeof(string));
		dataTable.Columns.Add("Description", typeof(string));
		dataTable.Columns.Add("MarkViolatorAs", typeof(string));
		dataTable.Columns.Add("IsActive", typeof(bool));
		foreach (ExclusionZone exclusionZone in Client.CurrentSide.ExclusionZones)
		{
			DataRow dataRow = dataTable.NewRow();
			dataRow["ID"] = exclusionZone.ObjectID;
			dataRow["Description"] = exclusionZone.Description;
			if (!exclusionZone.ViolatorsStance.ContainsKey("UnknownContactSide"))
			{
				dataRow["MarkViolatorAs"] = exclusionZone.MarkViolatorAs.ToString();
			}
			else
			{
				dataRow["MarkViolatorAs"] = exclusionZone.ViolatorsStance["UnknownContactSide"].ToString();
			}
			dataRow["IsActive"] = exclusionZone.IsActive;
			dataTable.Rows.Add(dataRow);
		}
		((DataGridView)DGV_ExclusionZone).DataSource = dataTable;
		((Control)DGV_ExclusionZone).Refresh();
	}

	private void method_23()
	{
		zoneType_0 = Zone.ZoneType.ExclusionZone;
		method_22();
		if (Client.CurrentSide.ExclusionZones.Count <= 0)
		{
			SelectedExclusionZone = null;
		}
		else if (Information.IsNothing((object)SelectedExclusionZone))
		{
			SelectedExclusionZone = Client.CurrentSide.ExclusionZones[0];
		}
		if (((DataGridView)DGV_ExclusionZone).RowCount != 0)
		{
			((Control)ZoneConfigPanel).Visible = true;
		}
		else
		{
			((Control)ZoneConfigPanel).Visible = false;
		}
	}

	private void method_24()
	{
		zoneType_0 = Zone.ZoneType.NoNavZone;
		method_48();
		if (Client.CurrentSide.NoNavZones.Count <= 0)
		{
			SelectedStdZone = null;
		}
		else if (Information.IsNothing((object)SelectedStdZone))
		{
			SelectedStdZone = Client.CurrentSide.NoNavZones[0];
		}
		if (((DataGridView)DGV_NoNavZone).RowCount != 0)
		{
			((Control)ZoneConfigPanel).Visible = true;
		}
		else
		{
			((Control)ZoneConfigPanel).Visible = false;
		}
	}

	private void method_25()
	{
		zoneType_0 = Zone.ZoneType.Zone;
		method_49();
		if (Client.CurrentSide.StandardZones.Count > 0)
		{
			if (Information.IsNothing((object)SelectedStandardZone))
			{
				SelectedStandardZone = Client.CurrentSide.StandardZones[0];
			}
		}
		else
		{
			SelectedStandardZone = null;
		}
		if (TV_Zones.Nodes.Count == 0)
		{
			((Control)ZoneConfigPanel).Visible = false;
			return;
		}
		TV_Zones.SelectNode(TV_Zones.Nodes.First());
		((Control)ZoneConfigPanel).Visible = true;
	}

	private void method_26()
	{
		zoneType_0 = Zone.ZoneType.CustomEnvironmentZone;
		method_50();
		if (Client.CurrentScenario.NatureSideExists())
		{
			if (Client.CurrentScenario.GetNatureSide().CustomEnvironmentZones.Count() <= 0)
			{
				SelectedCustomEnvironmentZone = null;
			}
			else if (Information.IsNothing((object)SelectedCustomEnvironmentZone))
			{
				SelectedCustomEnvironmentZone = Client.CurrentScenario.GetNatureSide().CustomEnvironmentZones[0];
			}
		}
		if (TV_CusEnvZones.Nodes.Count == 0)
		{
			((Control)ZoneConfigPanel).Visible = false;
			return;
		}
		TV_CusEnvZones.SelectNode(TV_CusEnvZones.Nodes.First());
		((Control)ZoneConfigPanel).Visible = true;
	}

	private void method_27(object sender, EventArgs e)
	{
	}

	private void method_28(object sender, EventArgs e)
	{
		method_29();
	}

	private void method_29()
	{
		int num = -1;
		switch (zoneType_2)
		{
		case Zone.ZoneType.Zone:
			if (!Information.IsNothing((object)SelectedStandardZone))
			{
				SelectedStandardZone.Description = TB_AreaName.Text;
				method_49();
				if (Client.Realtime)
				{
					Client.RealtimeTerminal.SendZoneUpdate(Client.CurrentSide, SelectedStandardZone);
				}
				goto default;
			}
			break;
		case Zone.ZoneType.NoNavZone:
			if (!Information.IsNothing((object)SelectedStdZone))
			{
				SelectedStdZone.Description = TB_AreaName.Text;
				if (((BaseCollection)((DataGridView)DGV_NoNavZone).SelectedRows).Count > 0)
				{
					num = ((DataGridViewBand)((DataGridView)DGV_NoNavZone).SelectedRows[0]).Index;
				}
				method_48();
				if (num != -1)
				{
					((DataGridView)DGV_NoNavZone).Rows[num].Selected = true;
				}
				if (Client.Realtime)
				{
					Client.RealtimeTerminal.SendZoneUpdate(Client.CurrentSide, SelectedStdZone);
				}
				goto default;
			}
			break;
		case Zone.ZoneType.ExclusionZone:
			if (!Information.IsNothing((object)SelectedExclusionZone))
			{
				SelectedExclusionZone.Description = TB_AreaName.Text;
				if (((BaseCollection)((DataGridView)DGV_ExclusionZone).SelectedRows).Count > 0)
				{
					num = ((DataGridViewBand)((DataGridView)DGV_ExclusionZone).SelectedRows[0]).Index;
				}
				method_22();
				if (num != -1)
				{
					((DataGridView)DGV_ExclusionZone).Rows[num].Selected = true;
				}
				if (Client.Realtime)
				{
					Client.RealtimeTerminal.SendZoneUpdate(Client.CurrentSide, SelectedExclusionZone);
				}
				goto default;
			}
			break;
		default:
			method_47();
			break;
		}
	}

	private void method_30(object sender, EventArgs e)
	{
		method_20(Zone.ZoneType.Zone);
	}

	private void method_31(object sender, EventArgs e)
	{
		method_20(Zone.ZoneType.NoNavZone);
	}

	private void method_32(object sender, EventArgs e)
	{
		method_20(Zone.ZoneType.ExclusionZone);
	}

	private void method_33(object sender, EventArgs e)
	{
		method_20(Zone.ZoneType.CustomEnvironmentZone);
	}

	private void method_34(object sender, EventArgs e)
	{
		switch (zoneType_2)
		{
		case Zone.ZoneType.Zone:
			if (!Information.IsNothing((object)SelectedStandardZone))
			{
				Client.CurrentSide.StandardZones.Remove(SelectedStandardZone);
				if (Client.Realtime)
				{
					Client.RealtimeTerminal.SendDeleteZone(Client.CurrentSide, SelectedStandardZone);
				}
				SelectedStandardZone = null;
				method_49();
				goto default;
			}
			break;
		case Zone.ZoneType.NoNavZone:
			if (!Information.IsNothing((object)SelectedStdZone))
			{
				Client.CurrentSide.NoNavZones.Remove(SelectedStdZone);
				if (Client.Realtime)
				{
					Client.RealtimeTerminal.SendDeleteZone(Client.CurrentSide, SelectedStdZone);
				}
				SelectedStdZone = null;
				method_48();
				goto default;
			}
			break;
		case Zone.ZoneType.ExclusionZone:
			if (!Information.IsNothing((object)SelectedExclusionZone))
			{
				Client.CurrentSide.ExclusionZones.Remove(SelectedExclusionZone);
				if (Client.Realtime)
				{
					Client.RealtimeTerminal.SendDeleteZone(Client.CurrentSide, SelectedExclusionZone);
				}
				SelectedExclusionZone = null;
				method_22();
				goto default;
			}
			break;
		case Zone.ZoneType.CustomEnvironmentZone:
			if (!Information.IsNothing((object)SelectedCustomEnvironmentZone))
			{
				ArrayExtensions.Remove(ref Client.CurrentScenario.GetNatureSide().CustomEnvironmentZones, SelectedCustomEnvironmentZone);
				if (Client.Realtime)
				{
					Client.RealtimeTerminal.SendDeleteZone(Client.CurrentSide, SelectedCustomEnvironmentZone);
				}
				SelectedCustomEnvironmentZone = null;
				method_50();
				goto default;
			}
			break;
		default:
			method_20(zoneType_2);
			break;
		}
	}

	private void method_35(object sender, EventArgs e)
	{
		if (((BaseCollection)((DataGridView)DGV_NoNavZone).SelectedRows).Count != 0)
		{
			int num = ((DataGridView)DGV_NoNavZone).Rows.IndexOf(((DataGridView)DGV_NoNavZone).SelectedRows[0]);
			if (num != -1)
			{
				SelectedStdZone = Client.CurrentSide.NoNavZones[num];
				method_19();
			}
		}
	}

	private void method_36(object sender, EventArgs e)
	{
		if (((BaseCollection)((DataGridView)DGV_ExclusionZone).SelectedRows).Count != 0)
		{
			int num = ((DataGridView)DGV_ExclusionZone).Rows.IndexOf(((DataGridView)DGV_ExclusionZone).SelectedRows[0]);
			if (num != -1)
			{
				SelectedExclusionZone = Client.CurrentSide.ExclusionZones[num];
				method_19();
			}
		}
	}

	private void method_37(object sender, EventArgs e)
	{
		if (TV_Zones.SelectedNodes != null && TV_Zones.SelectedNodes.Count != 0)
		{
			if (!Information.IsNothing((object)SelectedStandardZone))
			{
				TB_AreaName.Text = SelectedStandardZone.Description;
				((ButtonBase)ButtonZoneColorPicker).BackColor = zone_1.AreaColor;
				method_18(zone_1.Area);
				method_20(zoneType_2, bool_3: false);
			}
			else
			{
				((ButtonBase)ButtonZoneColorPicker).BackColor = Color.White;
				method_18(null);
			}
			SelectedStandardZone = (Zone)TV_Zones.SelectedNodes.ElementAt(0).Tag;
			method_19();
		}
	}

	private void method_38(object sender, EventArgs e)
	{
		method_42();
	}

	private void method_39(object sender, EventArgs e)
	{
		method_42();
	}

	private void method_40(object sender, EventArgs e)
	{
		method_42();
	}

	private void method_41(object sender, EventArgs e)
	{
		method_42();
	}

	private void method_42()
	{
		switch (zoneType_2)
		{
		case Zone.ZoneType.NoNavZone:
			if (Information.IsNothing((object)SelectedStdZone))
			{
				if (Client.CurrentSide.NoNavZones.Count <= 0)
				{
					break;
				}
				SelectedStdZone = Client.CurrentSide.NoNavZones[0];
			}
			SelectedStdZone.AffectedUnitTypes.Clear();
			if (((CheckBox)CBAppliesAircraft).Checked)
			{
				SelectedStdZone.AffectedUnitTypes.Add(GlobalVariables.ActiveUnitType.Aircraft);
			}
			if (((CheckBox)CBAppliesShips).Checked)
			{
				SelectedStdZone.AffectedUnitTypes.Add(GlobalVariables.ActiveUnitType.Ship);
			}
			if (((CheckBox)CBAppliesSubmarines).Checked)
			{
				SelectedStdZone.AffectedUnitTypes.Add(GlobalVariables.ActiveUnitType.Submarine);
			}
			if (((CheckBox)CBAppliesLandUnits).Checked)
			{
				SelectedStdZone.AffectedUnitTypes.Add(GlobalVariables.ActiveUnitType.Facility);
			}
			goto default;
		case Zone.ZoneType.ExclusionZone:
			if (Information.IsNothing((object)SelectedExclusionZone))
			{
				if (Client.CurrentSide.ExclusionZones.Count <= 0)
				{
					break;
				}
				SelectedExclusionZone = Client.CurrentSide.ExclusionZones[0];
			}
			SelectedExclusionZone.AffectedUnitTypes.Clear();
			if (((CheckBox)CBAppliesAircraft).Checked)
			{
				SelectedExclusionZone.AffectedUnitTypes.Add(GlobalVariables.ActiveUnitType.Aircraft);
			}
			if (((CheckBox)CBAppliesShips).Checked)
			{
				SelectedExclusionZone.AffectedUnitTypes.Add(GlobalVariables.ActiveUnitType.Ship);
			}
			if (((CheckBox)CBAppliesSubmarines).Checked)
			{
				SelectedExclusionZone.AffectedUnitTypes.Add(GlobalVariables.ActiveUnitType.Submarine);
			}
			if (((CheckBox)CBAppliesLandUnits).Checked)
			{
				SelectedExclusionZone.AffectedUnitTypes.Add(GlobalVariables.ActiveUnitType.Facility);
			}
			goto default;
		default:
			method_47();
			break;
		}
	}

	private void method_43(object sender, DataGridViewCellEventArgs e)
	{
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		if (e.RowIndex == -1 || e.ColumnIndex == -1 || Operators.CompareString(((DataGridView)DGV_ExclusionZone).Columns[e.ColumnIndex].Name, "Active", true) != 0)
		{
			return;
		}
		DataGridViewCheckBoxCell val = (DataGridViewCheckBoxCell)((DataGridView)DGV_ExclusionZone)[e.ColumnIndex, e.RowIndex];
		ExclusionZone exclusionZone = null;
		string text = Conversions.ToString(((DataGridView)DGV_ExclusionZone).Rows[e.RowIndex].Cells["ID"].Value);
		foreach (ExclusionZone exclusionZone2 in Client.CurrentSide.ExclusionZones)
		{
			if (Operators.CompareString(exclusionZone2.ObjectID, text, true) == 0)
			{
				exclusionZone = exclusionZone2;
				break;
			}
		}
		if (exclusionZone != null)
		{
			int mustRefreshMainForm;
			if (!exclusionZone.IsActive)
			{
				((DataGridViewCell)val).Value = true;
				exclusionZone.IsActive = true;
				mustRefreshMainForm = 1;
			}
			else
			{
				((DataGridViewCell)val).Value = false;
				exclusionZone.IsActive = false;
				mustRefreshMainForm = 1;
			}
			Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
			method_22();
			method_47();
		}
	}

	private void method_44(object sender, DataGridViewCellEventArgs e)
	{
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		if (e.RowIndex == -1 || e.ColumnIndex == -1 || Operators.CompareString(((DataGridView)DGV_NoNavZone).Columns[e.ColumnIndex].Name, "DataGridViewCheckBoxColumn1", true) != 0)
		{
			return;
		}
		DataGridViewCheckBoxCell val = (DataGridViewCheckBoxCell)((DataGridView)DGV_NoNavZone)[e.ColumnIndex, e.RowIndex];
		NoNavZone noNavZone = null;
		string text = Conversions.ToString(((DataGridView)DGV_NoNavZone).Rows[e.RowIndex].Cells["DataGridViewTextBoxColumn1"].Value);
		foreach (NoNavZone noNavZone2 in Client.CurrentSide.NoNavZones)
		{
			if (Operators.CompareString(noNavZone2.ObjectID, text, true) == 0)
			{
				noNavZone = noNavZone2;
				break;
			}
		}
		if (noNavZone != null && (!noNavZone.IsLocked || Client.CurrentGame.GameMode == Game._GameMode.ScenEdit))
		{
			int mustRefreshMainForm;
			if (!noNavZone.IsActive)
			{
				((DataGridViewCell)val).Value = true;
				noNavZone.IsActive = true;
				mustRefreshMainForm = 1;
			}
			else
			{
				((DataGridViewCell)val).Value = false;
				noNavZone.IsActive = false;
				mustRefreshMainForm = 1;
			}
			Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
			method_48();
			method_47();
		}
	}

	private void method_45(bool bool_3, bool bool_4)
	{
		((Control)CBZoneIsLocked).Visible = bool_3 && (bool_4 || Client.CurrentGame.GameMode == Game._GameMode.ScenEdit);
		((Control)ZoneConfigPanel).Enabled = !bool_3 || !bool_4 || Client.CurrentGame.GameMode == Game._GameMode.ScenEdit;
		((Control)lockedLabel).Visible = !((Control)ZoneConfigPanel).Enabled;
	}

	private void method_46(object sender, EventArgs e)
	{
		string theDescription = "New Zone";
		if (Operators.CompareString(TB_AreaName.Text, "", true) != 0)
		{
			theDescription = TB_AreaName.Text;
		}
		AreaPoints = new List<ReferencePoint>();
		foreach (ReferencePoint refPoint in Client.CurrentSide.RefPoints)
		{
			if (refPoint.IsHighlighted && !Information.IsNothing((object)AreaPoints) && !AreaPoints.Contains(refPoint))
			{
				DarkListItem darkListItem = new DarkListItem(refPoint.Name);
				AreaPoints.Add(refPoint);
				darkListItem.Tag = refPoint;
				LB_AreaRPs.Items.Add(darkListItem);
			}
		}
		Zone zone = null;
		switch (zoneType_2)
		{
		case Zone.ZoneType.Zone:
		{
			if (SelectedStandardZone != null)
			{
				SelectedStandardZone.Area = new ObservableList<ReferencePoint>(AreaPoints);
				break;
			}
			Zone zone2 = new Zone("New Zone", AreaPoints);
			if (!Client.Realtime)
			{
				Client.CurrentSide.StandardZones.Add(new Zone("New Zone", new List<ReferencePoint>()));
				SelectedStandardZone = Client.CurrentSide.StandardZones.ElementAt(Client.CurrentSide.StandardZones.Count - 1);
				method_49();
			}
			else
			{
				zone = zone2;
			}
			break;
		}
		case Zone.ZoneType.NoNavZone:
			if (SelectedStdZone == null)
			{
				NoNavZone noNavZone = new NoNavZone("New Zone", AreaPoints, Client.CurrentScenario, Client.CurrentSide);
				if (Client.Realtime)
				{
					zone = noNavZone;
					break;
				}
				Client.CurrentSide.NoNavZones.Add(noNavZone);
				SelectedStdZone = Client.CurrentSide.NoNavZones.ElementAt(Client.CurrentSide.NoNavZones.Count - 1);
				method_48();
			}
			else
			{
				SelectedStdZone.Area = new ObservableList<ReferencePoint>(AreaPoints);
			}
			break;
		case Zone.ZoneType.ExclusionZone:
			if (SelectedExclusionZone == null)
			{
				ExclusionZone exclusionZone = new ExclusionZone("New Zone", Client.CurrentScenario, Client.CurrentSide, AreaPoints, Misc.PostureStance.Hostile);
				if (Client.Realtime)
				{
					zone = exclusionZone;
					break;
				}
				Client.CurrentSide.ExclusionZones.Add(exclusionZone);
				SelectedExclusionZone = Client.CurrentSide.ExclusionZones.ElementAt(Client.CurrentSide.ExclusionZones.Count - 1);
				method_22();
			}
			else
			{
				SelectedExclusionZone.Area = new ObservableList<ReferencePoint>(AreaPoints);
			}
			break;
		case Zone.ZoneType.CustomEnvironmentZone:
			Client.CurrentScenario.CreateNatureSideIfNeeded();
			method_56();
			if (SelectedCustomEnvironmentZone != null)
			{
				SelectedCustomEnvironmentZone.Area = new ObservableList<ReferencePoint>(AreaPoints);
				break;
			}
			method_56();
			ArrayExtensions.Add(ref Client.CurrentScenario.GetNatureSide().CustomEnvironmentZones, new CustomEnvironmentZone(theDescription, AreaPoints, Client.CurrentScenario, Client.CurrentScenario.GetNatureSide(), new Weather.WeatherProfile()));
			SelectedCustomEnvironmentZone = Client.CurrentScenario.GetNatureSide().CustomEnvironmentZones.Last();
			method_50();
			break;
		}
		foreach (ReferencePoint refPoint2 in Client.CurrentSide.RefPoints)
		{
			if (refPoint2.IsHighlighted && !Information.IsNothing((object)AreaPoints) && !AreaPoints.Contains(refPoint2))
			{
				DarkListItem darkListItem2 = new DarkListItem(refPoint2.Name);
				AreaPoints.Add(refPoint2);
				darkListItem2.Tag = refPoint2;
				LB_AreaRPs.Items.Add(darkListItem2);
			}
		}
		int mustRefreshMainForm;
		if (!Client.Realtime)
		{
			mustRefreshMainForm = 1;
		}
		else if (zone == null)
		{
			method_47();
			mustRefreshMainForm = 1;
		}
		else
		{
			zone.Area = new ObservableList<ReferencePoint>(AreaPoints);
			Client.RealtimeTerminal.SendCreateZone(Client.CurrentSide, zone, select: true);
			mustRefreshMainForm = 1;
		}
		Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
	}

	private void method_47()
	{
		if (Client.Realtime)
		{
			Client.RealtimeTerminal.SendZoneUpdate(Client.CurrentSide, SelectedExclusionZone);
			Client.RealtimeTerminal.SendZoneUpdate(Client.CurrentSide, SelectedStdZone);
			Client.RealtimeTerminal.SendZoneUpdate(Client.CurrentSide, SelectedStandardZone);
			Client.RealtimeTerminal.SendZoneUpdate(Client.CurrentSide, SelectedCustomEnvironmentZone);
		}
	}

	public void RefreshForm(string SelectedZoneID)
	{
		if (Client.CurrentSide == null)
		{
			return;
		}
		RefPoints = Client.CurrentSide.RefPoints;
		method_0();
		method_16();
		method_12();
		bool flag = false;
		if (!string.IsNullOrEmpty(SelectedZoneID))
		{
			foreach (Zone standardZone in Client.CurrentSide.StandardZones)
			{
				if (Operators.CompareString(standardZone.ObjectID, SelectedZoneID, true) == 0)
				{
					SelectedStandardZone = standardZone;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				foreach (NoNavZone noNavZone in Client.CurrentSide.NoNavZones)
				{
					if (Operators.CompareString(noNavZone.ObjectID, SelectedZoneID, true) == 0)
					{
						SelectedStdZone = noNavZone;
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				foreach (ExclusionZone exclusionZone in Client.CurrentSide.ExclusionZones)
				{
					if (Operators.CompareString(exclusionZone.ObjectID, SelectedZoneID, true) == 0)
					{
						SelectedExclusionZone = exclusionZone;
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				Side natureSide = Client.CurrentScenario.GetNatureSide();
				if (natureSide != null)
				{
					CustomEnvironmentZone[] customEnvironmentZones = natureSide.CustomEnvironmentZones;
					foreach (CustomEnvironmentZone customEnvironmentZone in customEnvironmentZones)
					{
						if (Operators.CompareString(customEnvironmentZone.ObjectID, SelectedZoneID, true) == 0)
						{
							SelectedCustomEnvironmentZone = customEnvironmentZone;
							flag = true;
							break;
						}
					}
				}
			}
		}
		method_20(zoneType_0);
	}

	private void method_48()
	{
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add("ID", typeof(string));
		dataTable.Columns.Add("Description", typeof(string));
		dataTable.Columns.Add("IsActive", typeof(bool));
		foreach (NoNavZone noNavZone in Client.CurrentSide.NoNavZones)
		{
			DataRow dataRow = dataTable.NewRow();
			dataRow["ID"] = noNavZone.ObjectID;
			dataRow["Description"] = noNavZone.Description;
			dataRow["IsActive"] = noNavZone.IsActive;
			dataTable.Rows.Add(dataRow);
		}
		((DataGridView)DGV_NoNavZone).DataSource = dataTable;
		((Control)DGV_NoNavZone).Refresh();
	}

	private void method_49()
	{
		TV_Zones.SelectedNodesChanged -= method_37;
		TV_Zones.Nodes.Clear();
		foreach (Zone standardZone in Client.CurrentSide.StandardZones)
		{
			if (standardZone.IsPlayerEditable(Client.CurrentSide))
			{
				DarkTreeNode darkTreeNode = new DarkTreeNode("[" + standardZone.get_Layer(Client.CurrentSide) + "] " + standardZone.Description);
				darkTreeNode.Tag = standardZone;
				TV_Zones.Nodes.Add(darkTreeNode);
			}
		}
		((Control)TV_Zones).Refresh();
		TV_Zones.SelectedNodesChanged += method_37;
	}

	private void method_50()
	{
		TV_CusEnvZones.SelectedNodesChanged -= method_70;
		TV_CusEnvZones.Nodes.Clear();
		if (Client.CurrentScenario.NatureSideExists())
		{
			CustomEnvironmentZone[] customEnvironmentZones = Client.CurrentScenario.GetNatureSide().CustomEnvironmentZones;
			foreach (CustomEnvironmentZone customEnvironmentZone in customEnvironmentZones)
			{
				if (customEnvironmentZone.IsPlayerEditable(Client.CurrentSide))
				{
					DarkTreeNode darkTreeNode = new DarkTreeNode("[" + ((Zone)customEnvironmentZone).get_Layer(Client.CurrentSide) + "] " + customEnvironmentZone.Description);
					darkTreeNode.Tag = customEnvironmentZone;
					TV_CusEnvZones.Nodes.Add(darkTreeNode);
				}
			}
		}
		TV_CusEnvZones.SelectedNodesChanged += method_70;
	}

	private void method_51(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)AreaPoints))
		{
			foreach (DarkListItem selectedItem in LB_AreaRPs.SelectedItems)
			{
				AreaPoints.Remove((ReferencePoint)selectedItem.Tag);
			}
			method_19();
			Client.MustRefreshMainForm = true;
		}
		method_68();
		method_47();
	}

	private void method_52(object sender, EventArgs e)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		if (LB_AreaRPs.SelectedItems.Count > 1)
		{
			DarkMessageBox.ShowError("Only one reference point can be re-arranged at a time", "One point a time!");
		}
		else if (LB_AreaRPs.SelectedIndices.Count != 0)
		{
			int num = LB_AreaRPs.SelectedIndices[0];
			if (num != -1 && num > 0)
			{
				DarkListItem item = LB_AreaRPs.Items[num];
				ReferencePoint item2 = AreaPoints[num];
				LB_AreaRPs.Items.RemoveAt(num);
				AreaPoints.RemoveAt(num);
				num--;
				AreaPoints.Insert(num, item2);
				LB_AreaRPs.Items.Insert(num, item);
				LB_AreaRPs.SelectItem(num);
				Client.MustRefreshMainForm = true;
			}
		}
	}

	private void method_53(object sender, EventArgs e)
	{
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		if (LB_AreaRPs.SelectedItems.Count <= 1)
		{
			if (LB_AreaRPs.SelectedIndices.Count != 0)
			{
				int num = LB_AreaRPs.SelectedIndices[0];
				if (num != -1 && num < LB_AreaRPs.Items.Count - 1)
				{
					DarkListItem item = LB_AreaRPs.Items[num];
					ReferencePoint item2 = AreaPoints[num];
					LB_AreaRPs.Items.RemoveAt(num);
					AreaPoints.RemoveAt(num);
					num++;
					AreaPoints.Insert(num, item2);
					LB_AreaRPs.Items.Insert(num, item);
					LB_AreaRPs.SelectItem(num);
					Client.MustRefreshMainForm = true;
				}
			}
		}
		else
		{
			DarkMessageBox.ShowError("Only one reference point can be re-arranged at a time", "One point a time!");
		}
	}

	private void method_54(object sender, EventArgs e)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		if (!Information.IsNothing((object)AreaPoints))
		{
			string UserFeedback = default(string);
			if (ActiveUnit_Navigator.ValidateArea(AreaPoints, ref UserFeedback, null, Client.CurrentScenario, ""))
			{
				DarkMessageBox.ShowInformation("Area validation OK.", "");
			}
			else
			{
				DarkMessageBox.ShowWarning(UserFeedback, "");
			}
		}
	}

	private void method_55(object sender, EventArgs e)
	{
		List<ReferencePoint> referencePointMultipleSelection = GetReferencePointMultipleSelection();
		if (referencePointMultipleSelection == null || referencePointMultipleSelection.Count == 0 || Information.IsNothing((object)AreaPoints))
		{
			return;
		}
		foreach (ReferencePoint item in referencePointMultipleSelection)
		{
			if (!AreaPoints.Contains(item))
			{
				DarkListItem darkListItem = new DarkListItem(item.Name);
				AreaPoints.Add(item);
				darkListItem.Tag = item;
				LB_AreaRPs.Items.Add(darkListItem);
			}
		}
		method_68();
		method_47();
	}

	private void method_56()
	{
		if (!Client.CurrentScenario.NatureSideExists())
		{
			return;
		}
		foreach (ReferencePoint areaPoint in AreaPoints)
		{
			if (!Client.CurrentScenario.GetNatureSide().RefPoints.Contains(areaPoint))
			{
				Client.CurrentScenario.GetNatureSide().RefPoints.Add(areaPoint);
				Client.CurrentSide.RefPoints.Remove(areaPoint);
			}
		}
	}

	private void method_57(object sender, EventArgs e)
	{
		//IL_051c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Invalid comparison between Unknown and I4
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Invalid comparison between Unknown and I4
		//IL_04ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c4: Expected O, but got Unknown
		//IL_04da: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e0: Invalid comparison between Unknown and I4
		//IL_04a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a9: Invalid comparison between Unknown and I4
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Invalid comparison between Unknown and I4
		//IL_04f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fe: Expected O, but got Unknown
		//IL_04ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b0: Invalid comparison between Unknown and I4
		//IL_0921: Unknown result type (might be due to invalid IL or missing references)
		//IL_043c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0589: Unknown result type (might be due to invalid IL or missing references)
		//IL_0590: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected O, but got Unknown
		//IL_05e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e9: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Expected O, but got Unknown
		switch (zoneType_2)
		{
		case Zone.ZoneType.NoNavZone:
			if (SelectedStdZone != null)
			{
				DialogResult val5 = DarkMessageBox.ShowInformation("Create as a New Zone", "No Navigation Zone", DarkDialogButton.YesNoCancel);
				if ((int)val5 == 2)
				{
					break;
				}
				if ((int)val5 == 6)
				{
					SelectedStdZone = null;
				}
			}
			FD_LoadNoNavZone = new OpenFileDialog();
			((FileDialog)FD_LoadNoNavZone).InitialDirectory = GameGeneral.ScenariosRootPath;
			if ((int)((CommonDialog)FD_LoadNoNavZone).ShowDialog() == 1)
			{
				FileStream fileStream2 = new FileStream(((FileDialog)FD_LoadNoNavZone).FileName, FileMode.Open, FileAccess.Read);
				XmlDocument val6 = new XmlDocument();
				try
				{
					using (fileStream2)
					{
						try
						{
							val6.Load((Stream)fileStream2);
						}
						catch (Exception projectError2)
						{
							ProjectData.SetProjectError(projectError2);
							DarkMessageBox.ShowError("File is improperly formatted, read failed!", "Read error");
							ProjectData.ClearProjectError();
						}
					}
					Zone zone2 = new Zone();
					bool isLocked = false;
					bool flag3 = true;
					XmlNode val7 = ((XmlNode)val6).SelectSingleNode("/NoNavZone");
					if (Information.IsNothing((object)val7))
					{
						val7 = ((XmlNode)val6).SelectSingleNode("/ExclusionZone");
						flag3 = false;
					}
					if (val7 != null)
					{
						foreach (XmlNode childNode in val7.ChildNodes)
						{
							XmlNode val8 = childNode;
							string name2 = val8.Name;
							if (Operators.CompareString(name2, "Description", true) != 0)
							{
								if (Operators.CompareString(name2, "Area", true) == 0)
								{
									foreach (XmlNode childNode2 in val8.ChildNodes)
									{
										XmlNode theNode2 = childNode2;
										ConcurrentDictionary<string, ScenarioObject> theDictionary = null;
										ReferencePoint referencePoint2 = ReferencePoint.FromXML(ref theNode2, ref theDictionary, Client.CurrentScenario);
										if (!flag3)
										{
											referencePoint2.ResetIDs();
										}
										zone2.Area.Add(referencePoint2);
									}
									continue;
								}
								if (Operators.CompareString(name2, "AffectedUnitTypes", true) != 0)
								{
									if (Operators.CompareString(name2, "IsLocked", true) == 0)
									{
										isLocked = Misc.ParseBool(val8.InnerText);
									}
									continue;
								}
								zone2.AffectedUnitTypes = new ObservableList<GlobalVariables.ActiveUnitType>();
								string[] array2 = val8.InnerText.Split(new char[1] { '_' });
								foreach (string text2 in array2)
								{
									if (Versioned.IsNumeric((object)text2))
									{
										int num4 = Conversions.ToInteger(text2);
										zone2.AffectedUnitTypes.Add((GlobalVariables.ActiveUnitType)num4);
									}
								}
							}
							else
							{
								zone2.Description = val8.InnerText;
							}
						}
						if (Information.IsNothing((object)zone2.AffectedUnitTypes))
						{
							zone2.AffectedUnitTypes = new ObservableList<GlobalVariables.ActiveUnitType>
							{
								GlobalVariables.ActiveUnitType.Aircraft,
								GlobalVariables.ActiveUnitType.Ship,
								GlobalVariables.ActiveUnitType.Submarine,
								GlobalVariables.ActiveUnitType.Facility
							};
						}
						if (SelectedStdZone == null)
						{
							NoNavZone noNavZone = new NoNavZone(zone2.Description, zone2.Area, Client.CurrentScenario, Client.CurrentSide, zone2.AffectedUnitTypes);
							noNavZone.IsLocked = isLocked;
							Client.CurrentSide.NoNavZones.Add(noNavZone);
							SelectedStdZone = noNavZone;
						}
						else
						{
							SelectedStdZone.Description = zone2.Description;
							SelectedStdZone.Area = zone2.Area;
							SelectedStdZone.AffectedUnitTypes = zone2.AffectedUnitTypes;
							SelectedStdZone.IsLocked = isLocked;
						}
						method_19();
						bool flag4 = false;
						Side[] sides_ReadOnly2 = Client.CurrentScenario.Sides_ReadOnly;
						foreach (Side side2 in sides_ReadOnly2)
						{
							foreach (NoNavZone noNavZone2 in side2.NoNavZones)
							{
								if (noNavZone2 != SelectedStdZone)
								{
									continue;
								}
								foreach (ReferencePoint item in SelectedStdZone.Area)
								{
									if (!side2.RefPoints.Contains(item))
									{
										side2.RefPoints.Add(item);
									}
								}
								flag4 = true;
								break;
							}
							if (flag4)
							{
								break;
							}
						}
						method_48();
					}
					else
					{
						DarkMessageBox.ShowError("No XML data found.", "Error");
					}
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					ex4?.Data.Add("Error at 101278", "");
					GameGeneral.WriteExceptionsToLog(ex4);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				Client.MustRefreshMainForm = true;
			}
			goto default;
		case Zone.ZoneType.ExclusionZone:
			if (SelectedExclusionZone != null)
			{
				DialogResult val = DarkMessageBox.ShowInformation("Create as a New Zone", "Exclusion Zone", DarkDialogButton.YesNoCancel);
				if ((int)val == 2)
				{
					break;
				}
				if ((int)val == 6)
				{
					SelectedExclusionZone = null;
				}
			}
			FD_LoadExclusionZone = new OpenFileDialog();
			((FileDialog)FD_LoadExclusionZone).InitialDirectory = GameGeneral.ScenariosRootPath;
			if ((int)((CommonDialog)FD_LoadExclusionZone).ShowDialog() == 1)
			{
				FileStream fileStream = new FileStream(((FileDialog)FD_LoadExclusionZone).FileName, FileMode.Open, FileAccess.Read);
				XmlDocument val2 = new XmlDocument();
				try
				{
					using (fileStream)
					{
						try
						{
							val2.Load((Stream)fileStream);
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							DarkMessageBox.ShowError("File is improperly formatted, read failed!", "Error");
							ProjectData.ClearProjectError();
						}
					}
					Zone zone = new Zone();
					bool flag = true;
					XmlNode val3 = ((XmlNode)val2).SelectSingleNode("/ExclusionZone");
					if (Information.IsNothing((object)val3))
					{
						val3 = ((XmlNode)val2).SelectSingleNode("/NoNavZone");
						flag = false;
					}
					if (val3 != null)
					{
						Misc.PostureStance postureStance = default(Misc.PostureStance);
						float? num2 = default(float?);
						float? num3 = default(float?);
						foreach (XmlNode childNode3 in val3.ChildNodes)
						{
							XmlNode val4 = childNode3;
							string name = val4.Name;
							if (Operators.CompareString(name, "Description", true) == 0)
							{
								zone.Description = val4.InnerText;
							}
							else if (Operators.CompareString(name, "Area", true) == 0)
							{
								foreach (XmlNode childNode4 in val4.ChildNodes)
								{
									XmlNode theNode = childNode4;
									ConcurrentDictionary<string, ScenarioObject> theDictionary = null;
									ReferencePoint referencePoint = ReferencePoint.FromXML(ref theNode, ref theDictionary, Client.CurrentScenario);
									if (!flag)
									{
										referencePoint.ResetIDs();
									}
									zone.Area.Add(referencePoint);
								}
							}
							else if (Operators.CompareString(name, "AffectedUnitTypes", true) == 0)
							{
								zone.AffectedUnitTypes = new ObservableList<GlobalVariables.ActiveUnitType>();
								string[] array = val4.InnerText.Split(new char[1] { '_' });
								foreach (string text in array)
								{
									if (Versioned.IsNumeric((object)text))
									{
										int num = Conversions.ToInteger(text);
										zone.AffectedUnitTypes.Add((GlobalVariables.ActiveUnitType)num);
									}
								}
							}
							else if (Operators.CompareString(name, "MarkViolatorAs", true) == 0)
							{
								postureStance = (Misc.PostureStance)Conversions.ToByte(val4.InnerText);
							}
							else if (Operators.CompareString(name, "AltitudeEnvelopeMin", true) == 0)
							{
								num2 = (string.IsNullOrEmpty(val4.InnerText) ? ((float?)null) : new float?(Conversions.ToSingle(val4.InnerText)));
							}
							else if (Operators.CompareString(name, "AltitudeEnvelopeMax", true) == 0 && !string.IsNullOrEmpty(val4.InnerText))
							{
								num3 = Conversions.ToSingle(val4.InnerText);
							}
						}
						if (Information.IsNothing((object)zone.AffectedUnitTypes))
						{
							zone.AffectedUnitTypes = new ObservableList<GlobalVariables.ActiveUnitType>
							{
								GlobalVariables.ActiveUnitType.Aircraft,
								GlobalVariables.ActiveUnitType.Ship,
								GlobalVariables.ActiveUnitType.Submarine,
								GlobalVariables.ActiveUnitType.Facility
							};
						}
						if (SelectedExclusionZone != null)
						{
							SelectedExclusionZone.Description = zone.Description;
							SelectedExclusionZone.Area = zone.Area;
							SelectedExclusionZone.AffectedUnitTypes = zone.AffectedUnitTypes;
							SelectedExclusionZone.MarkViolatorAs = postureStance;
							SelectedExclusionZone.AltitudeEnvelopeMin = num2;
							SelectedExclusionZone.AltitudeEnvelopeMax = num3;
						}
						else
						{
							ExclusionZone exclusionZone = new ExclusionZone(zone.Description, Client.CurrentScenario, Client.CurrentSide, zone.Area, postureStance, zone.AffectedUnitTypes, num2, num3);
							Client.CurrentSide.ExclusionZones.Add(exclusionZone);
							SelectedExclusionZone = exclusionZone;
						}
						method_19();
						bool flag2 = false;
						Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
						foreach (Side side in sides_ReadOnly)
						{
							foreach (ExclusionZone exclusionZone2 in side.ExclusionZones)
							{
								if (exclusionZone2 != SelectedExclusionZone)
								{
									continue;
								}
								foreach (ReferencePoint item2 in SelectedExclusionZone.Area)
								{
									if (!side.RefPoints.Contains(item2))
									{
										side.RefPoints.Add(item2);
									}
								}
								flag2 = true;
								break;
							}
							if (flag2)
							{
								break;
							}
						}
						method_22();
					}
					else
					{
						DarkMessageBox.ShowError("No XML data found.", "Error");
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 101276", "");
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				Client.MustRefreshMainForm = true;
			}
			goto default;
		default:
			method_47();
			break;
		}
	}

	private void method_58(object sender, EventArgs e)
	{
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Invalid comparison between Unknown and I4
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Expected O, but got Unknown
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Invalid comparison between Unknown and I4
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0276: Expected O, but got Unknown
		switch (zoneType_2)
		{
		case Zone.ZoneType.NoNavZone:
			if (!Information.IsNothing((object)SelectedStdZone))
			{
				FD_ExportNoNavZone = new SaveFileDialog();
				((FileDialog)FD_ExportNoNavZone).InitialDirectory = GameGeneral.ScenariosRootPath;
				if ((int)((CommonDialog)FD_ExportNoNavZone).ShowDialog() != 1)
				{
					break;
				}
				try
				{
					FileStream fileStream2 = File.Create(((FileDialog)FD_ExportNoNavZone).FileName);
					XmlWriterSettings val3 = new XmlWriterSettings();
					using MemoryStream memoryStream2 = RCMS.recyclableMemoryStreamManager_0.GetStream();
					XmlWriter val4 = XmlWriter.Create((Stream)memoryStream2, val3);
					try
					{
						val4.WriteStartElement("NoNavZone");
						val4.WriteElementString("Description", SelectedStdZone.Description);
						val4.WriteStartElement("Area");
						foreach (ReferencePoint item in SelectedStdZone.Area)
						{
							HashSet<string> ObjectsAlreadySerialized = null;
							val4.WriteRaw(item.ToXML(ref ObjectsAlreadySerialized));
							val4.Flush();
						}
						val4.WriteEndElement();
						val4.WriteElementString("AffectedUnitTypes", string.Join("_", SelectedStdZone.AffectedUnitTypes.Select([SpecialName] (GlobalVariables.ActiveUnitType theType) =>
						{
							int num = (int)theType;
							return num.ToString();
						})));
						val4.WriteElementString("IsLocked", SelectedStdZone.IsLocked.ToString());
						val4.WriteEndElement();
					}
					finally
					{
						((IDisposable)val4)?.Dispose();
					}
					fileStream2.Write(memoryStream2.ToArray(), 0, (int)memoryStream2.Position);
					fileStream2.Close();
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					ex4?.Data.Add("Error at 101279", "");
					GameGeneral.WriteExceptionsToLog(ex4);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				Client.MustRefreshMainForm = true;
			}
			else
			{
				DarkMessageBox.ShowError("Please select a No Novigation Zone.", "No zone selected");
			}
			break;
		case Zone.ZoneType.ExclusionZone:
			if (Information.IsNothing((object)SelectedExclusionZone))
			{
				DarkMessageBox.ShowError("Please select a Exclusion Zone.", "No zone selected");
				break;
			}
			FD_ExportExclusionZone = new SaveFileDialog();
			((FileDialog)FD_ExportExclusionZone).InitialDirectory = GameGeneral.ScenariosRootPath;
			if ((int)((CommonDialog)FD_ExportExclusionZone).ShowDialog() != 1)
			{
				break;
			}
			try
			{
				FileStream fileStream = File.Create(((FileDialog)FD_ExportExclusionZone).FileName);
				XmlWriterSettings val = new XmlWriterSettings();
				using MemoryStream memoryStream = RCMS.recyclableMemoryStreamManager_0.GetStream();
				XmlWriter val2 = XmlWriter.Create((Stream)memoryStream, val);
				try
				{
					val2.WriteStartElement("ExclusionZone");
					val2.WriteElementString("Description", SelectedExclusionZone.Description);
					val2.WriteStartElement("Area");
					foreach (ReferencePoint item2 in SelectedExclusionZone.Area)
					{
						HashSet<string> ObjectsAlreadySerialized = null;
						val2.WriteRaw(item2.ToXML(ref ObjectsAlreadySerialized));
						val2.Flush();
					}
					val2.WriteEndElement();
					val2.WriteElementString("AltitudeEnvelopeMin", SelectedExclusionZone.AltitudeEnvelopeMin.ToString());
					val2.WriteElementString("AltitudeEnvelopeMax", SelectedExclusionZone.AltitudeEnvelopeMax.ToString());
					byte markViolatorAs = (byte)SelectedExclusionZone.MarkViolatorAs;
					val2.WriteElementString("MarkViolatorAs", markViolatorAs.ToString());
					val2.WriteElementString("AffectedUnitTypes", string.Join("_", SelectedExclusionZone.AffectedUnitTypes.Select([SpecialName] (GlobalVariables.ActiveUnitType theType) =>
					{
						int num = (int)theType;
						return num.ToString();
					})));
					val2.WriteEndElement();
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
				fileStream.Write(memoryStream.ToArray(), 0, (int)memoryStream.Position);
				fileStream.Close();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101277", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			Client.MustRefreshMainForm = true;
			break;
		case Zone.ZoneType.Zone:
			break;
		}
	}

	private void method_59(object sender, EventArgs e)
	{
		string text = TB_AreaName.Text;
		Zone zone = null;
		if (string.IsNullOrEmpty(text))
		{
			text = "New Zone";
		}
		switch (zoneType_2)
		{
		case Zone.ZoneType.Zone:
		{
			Zone zone2 = new Zone(text, new List<ReferencePoint>());
			zone2.AreaColor = Color.FromArgb(60, 100, 100, 100);
			if (Client.Realtime)
			{
				zone = zone2;
				break;
			}
			Client.CurrentSide.StandardZones.Add(zone2);
			SelectedStandardZone = Client.CurrentSide.StandardZones.ElementAt(Client.CurrentSide.StandardZones.Count - 1);
			method_20(Zone.ZoneType.Zone);
			TV_Zones.SelectNode(TV_Zones.Nodes.Last());
			break;
		}
		case Zone.ZoneType.NoNavZone:
		{
			NoNavZone noNavZone = new NoNavZone(text, new List<ReferencePoint>(), Client.CurrentScenario, Client.CurrentSide);
			noNavZone.AreaColor = Color.FromArgb(60, 100, 100, 100);
			if (Client.Realtime)
			{
				zone = noNavZone;
				break;
			}
			Client.CurrentSide.NoNavZones.Add(noNavZone);
			SelectedStdZone = Client.CurrentSide.NoNavZones.ElementAt(Client.CurrentSide.NoNavZones.Count - 1);
			method_20(Zone.ZoneType.NoNavZone);
			((DataGridView)DGV_NoNavZone).ClearSelection();
			((DataGridView)DGV_NoNavZone).Rows[((DataGridView)DGV_NoNavZone).Rows.Count - 1].Selected = true;
			break;
		}
		case Zone.ZoneType.ExclusionZone:
		{
			ExclusionZone exclusionZone = new ExclusionZone(text, Client.CurrentScenario, Client.CurrentSide, new List<ReferencePoint>(), Misc.PostureStance.Hostile);
			exclusionZone.AreaColor = Color.FromArgb(60, 100, 100, 100);
			if (!Client.Realtime)
			{
				Client.CurrentSide.ExclusionZones.Add(exclusionZone);
				SelectedExclusionZone = Client.CurrentSide.ExclusionZones.ElementAt(Client.CurrentSide.ExclusionZones.Count - 1);
				method_20(Zone.ZoneType.ExclusionZone);
				((DataGridView)DGV_ExclusionZone).ClearSelection();
				((DataGridView)DGV_ExclusionZone).Rows[((DataGridView)DGV_ExclusionZone).Rows.Count - 1].Selected = true;
			}
			else
			{
				zone = exclusionZone;
			}
			break;
		}
		case Zone.ZoneType.CustomEnvironmentZone:
			if (!Client.Realtime)
			{
				Client.CurrentScenario.CreateNatureSideIfNeeded();
				ArrayExtensions.Add(ref Client.CurrentScenario.GetNatureSide().CustomEnvironmentZones, new CustomEnvironmentZone(TB_AreaName.Text, new List<ReferencePoint>(), Client.CurrentScenario, Client.CurrentScenario.GetNatureSide(), new Weather.WeatherProfile()));
				SelectedCustomEnvironmentZone = Client.CurrentScenario.GetNatureSide().CustomEnvironmentZones.Last();
				SelectedCustomEnvironmentZone.AreaColor = Color.FromArgb(60, 100, 100, 100);
				method_20(Zone.ZoneType.CustomEnvironmentZone);
				TV_CusEnvZones.SelectNode(TV_CusEnvZones.Nodes.Last());
			}
			break;
		}
		if (Client.Realtime)
		{
			if (zone == null)
			{
				method_47();
			}
			else
			{
				Client.RealtimeTerminal.SendCreateZone(Client.CurrentSide, zone, select: true);
			}
		}
	}

	private void method_60(object sender, EventArgs e)
	{
		if (SelectedCustomEnvironmentZone != null)
		{
			if (Operators.CompareString(TB_AreaName.Text, "", true) == 0)
			{
				TB_AreaName.Text = "TEMP";
			}
			SelectedCustomEnvironmentZone.Description = TB_AreaName.Text;
			EditCustomEnvironmentArea editCustomEnvironmentArea = new EditCustomEnvironmentArea();
			CustomEnvironmentZone selectedCustomEnvironmentZone = SelectedCustomEnvironmentZone;
			editCustomEnvironmentArea.SetWorkingCEZ(ref selectedCustomEnvironmentZone);
			SelectedCustomEnvironmentZone = selectedCustomEnvironmentZone;
			((Form)editCustomEnvironmentArea).TopMost = true;
			((Control)editCustomEnvironmentArea).Show();
		}
	}

	private void method_61(object sender, EventArgs e)
	{
		string text = ((ComboBox)CBTransformTo).Text;
		if (Operators.CompareString(text, "Zone", true) == 0)
		{
			switch (zoneType_2)
			{
			case Zone.ZoneType.NoNavZone:
				Zone.TransformTo(SelectedStdZone, Client.CurrentSide, Client.CurrentScenario);
				break;
			case Zone.ZoneType.ExclusionZone:
				Zone.TransformTo(SelectedExclusionZone, Client.CurrentSide, Client.CurrentScenario);
				break;
			case Zone.ZoneType.CustomEnvironmentZone:
				Zone.TransformTo(SelectedCustomEnvironmentZone, Client.CurrentSide, Client.CurrentScenario);
				break;
			}
			method_49();
		}
		else if (Operators.CompareString(text, "No-nav Zone", true) == 0)
		{
			switch (zoneType_2)
			{
			case Zone.ZoneType.Zone:
				NoNavZone.TransformTo(SelectedStandardZone, Client.CurrentSide, Client.CurrentScenario);
				break;
			case Zone.ZoneType.ExclusionZone:
				NoNavZone.TransformTo(SelectedExclusionZone, Client.CurrentSide, Client.CurrentScenario);
				break;
			case Zone.ZoneType.CustomEnvironmentZone:
				NoNavZone.TransformTo(SelectedCustomEnvironmentZone, Client.CurrentSide, Client.CurrentScenario);
				break;
			}
			method_48();
		}
		else if (Operators.CompareString(text, "Exclusion Zone", true) == 0)
		{
			switch (zoneType_2)
			{
			case Zone.ZoneType.Zone:
				ExclusionZone.TransformTo(SelectedStandardZone, Client.CurrentSide, Client.CurrentScenario);
				break;
			case Zone.ZoneType.NoNavZone:
				ExclusionZone.TransformTo(SelectedStdZone, Client.CurrentSide, Client.CurrentScenario);
				break;
			case Zone.ZoneType.CustomEnvironmentZone:
				ExclusionZone.TransformTo(SelectedCustomEnvironmentZone, Client.CurrentSide, Client.CurrentScenario);
				break;
			}
			method_22();
		}
		else if (Operators.CompareString(text, "Custom Environment Zone", true) == 0)
		{
			switch (zoneType_2)
			{
			case Zone.ZoneType.Zone:
				CustomEnvironmentZone.TransformTo(SelectedStandardZone, Client.CurrentSide, Client.CurrentScenario);
				break;
			case Zone.ZoneType.NoNavZone:
				CustomEnvironmentZone.TransformTo(SelectedStdZone, Client.CurrentSide, Client.CurrentScenario);
				break;
			case Zone.ZoneType.ExclusionZone:
				CustomEnvironmentZone.TransformTo(SelectedExclusionZone, Client.CurrentSide, Client.CurrentScenario);
				break;
			}
			method_22();
			method_49();
			method_48();
			method_50();
		}
		method_47();
	}

	private void method_62(object sender, EventArgs e)
	{
	}

	private void method_63(object sender, EventArgs e)
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Invalid comparison between Unknown and I4
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Invalid comparison between Unknown and I4
		switch (zoneType_2)
		{
		case Zone.ZoneType.CustomEnvironmentZone:
			if (!Information.IsNothing((object)SelectedCustomEnvironmentZone))
			{
				ColorDialog val2 = new ColorDialog();
				if ((int)((CommonDialog)val2).ShowDialog() == 1)
				{
					SelectedCustomEnvironmentZone.AreaColor = val2.Color;
					((ButtonBase)ButtonZoneColorPicker).BackColor = SelectedCustomEnvironmentZone.AreaColor;
				}
			}
			break;
		case Zone.ZoneType.Zone:
			if (!Information.IsNothing((object)SelectedStandardZone))
			{
				ColorDialog val = new ColorDialog();
				if ((int)((CommonDialog)val).ShowDialog() == 1)
				{
					SelectedStandardZone.AreaColor = val.Color;
					((ButtonBase)ButtonZoneColorPicker).BackColor = SelectedStandardZone.AreaColor;
				}
			}
			break;
		}
		method_47();
	}

	private void method_64(Misc.PostureStance postureStance_0)
	{
		if (LV_ViolatorSides.SelectedItems.Count == 0)
		{
			return;
		}
		int[] indexes = LV_ViolatorSides.SelectedIndices.ToArray();
		foreach (DarkListItem selectedItem in LV_ViolatorSides.SelectedItems)
		{
			string key = (string)selectedItem.Tag;
			if (SelectedExclusionZone.ViolatorsStance.ContainsKey(key))
			{
				SelectedExclusionZone.ViolatorsStance[key] = postureStance_0;
			}
		}
		int num = -1;
		if (((BaseCollection)((DataGridView)DGV_ExclusionZone).SelectedRows).Count > 0)
		{
			num = ((DataGridViewBand)((DataGridView)DGV_ExclusionZone).SelectedRows[0]).Index;
		}
		method_22();
		if (num != -1)
		{
			((DataGridView)DGV_ExclusionZone).Rows[num].Selected = true;
		}
		method_21();
		LV_ViolatorSides.SelectItems(indexes);
		method_47();
	}

	private void method_65(object sender, EventArgs e)
	{
		method_64(Misc.PostureStance.Hostile);
	}

	private void method_66(object sender, EventArgs e)
	{
		method_64(Misc.PostureStance.Unfriendly);
	}

	private void method_67(object sender, EventArgs e)
	{
		method_64(Misc.PostureStance.Unknown);
	}

	private void method_68()
	{
		if (AreaPoints == null)
		{
			return;
		}
		switch (zoneType_2)
		{
		case Zone.ZoneType.Zone:
			if (SelectedStandardZone != null)
			{
				SelectedStandardZone.Area = new ObservableList<ReferencePoint>(AreaPoints);
			}
			break;
		case Zone.ZoneType.NoNavZone:
			if (SelectedStdZone != null)
			{
				SelectedStdZone.Area = new ObservableList<ReferencePoint>(AreaPoints);
			}
			break;
		case Zone.ZoneType.ExclusionZone:
			if (SelectedExclusionZone != null)
			{
				SelectedExclusionZone.Area = new ObservableList<ReferencePoint>(AreaPoints);
			}
			break;
		case Zone.ZoneType.CustomEnvironmentZone:
			if (SelectedCustomEnvironmentZone != null)
			{
				SelectedCustomEnvironmentZone.Area = new ObservableList<ReferencePoint>(AreaPoints);
			}
			break;
		}
	}

	private void method_69(object sender, EventArgs e)
	{
		method_71(Num_ZoneOpacity, null);
		switch (zoneType_2)
		{
		case Zone.ZoneType.Zone:
			if (SelectedStandardZone != null)
			{
				SelectedStandardZone.Name = TB_AreaName.Text;
				SelectedStandardZone.Description = TB_AreaName.Text;
				SelectedStandardZone.Area = new ObservableList<ReferencePoint>(AreaPoints);
				int index3 = Client.CurrentSide.StandardZones.IndexOf(SelectedStandardZone);
				Client.CurrentSide.StandardZones[index3].Name = TB_AreaName.Text;
				Client.CurrentSide.StandardZones[index3].Description = TB_AreaName.Text;
				method_49();
			}
			break;
		case Zone.ZoneType.NoNavZone:
			if (SelectedStdZone != null)
			{
				SelectedStdZone.Name = TB_AreaName.Text;
				SelectedStdZone.Description = TB_AreaName.Text;
				SelectedStdZone.Area = new ObservableList<ReferencePoint>(AreaPoints);
				int index = Client.CurrentSide.NoNavZones.IndexOf(SelectedStdZone);
				Client.CurrentSide.NoNavZones[index].Name = TB_AreaName.Text;
				Client.CurrentSide.NoNavZones[index].Description = TB_AreaName.Text;
				method_48();
			}
			break;
		case Zone.ZoneType.ExclusionZone:
			if (SelectedExclusionZone != null)
			{
				SelectedExclusionZone.Name = TB_AreaName.Text;
				SelectedExclusionZone.Description = TB_AreaName.Text;
				SelectedExclusionZone.Area = new ObservableList<ReferencePoint>(AreaPoints);
				int index2 = Client.CurrentSide.ExclusionZones.IndexOf(SelectedExclusionZone);
				Client.CurrentSide.ExclusionZones[index2].Name = TB_AreaName.Text;
				Client.CurrentSide.ExclusionZones[index2].Description = TB_AreaName.Text;
				method_22();
			}
			break;
		case Zone.ZoneType.CustomEnvironmentZone:
			if (SelectedCustomEnvironmentZone != null)
			{
				Client.CurrentScenario.CreateNatureSideIfNeeded();
				SelectedCustomEnvironmentZone.Name = TB_AreaName.Text;
				SelectedCustomEnvironmentZone.Description = TB_AreaName.Text;
				SelectedCustomEnvironmentZone.Area = new ObservableList<ReferencePoint>(AreaPoints);
				int num = Array.IndexOf(Client.CurrentScenario.GetNatureSide().CustomEnvironmentZones, SelectedCustomEnvironmentZone);
				Client.CurrentScenario.GetNatureSide().CustomEnvironmentZones[num].Name = TB_AreaName.Text;
				Client.CurrentScenario.GetNatureSide().CustomEnvironmentZones[num].Description = TB_AreaName.Text;
				method_50();
			}
			break;
		}
		method_47();
	}

	private void method_70(object sender, EventArgs e)
	{
		if (TV_CusEnvZones.SelectedNodes != null && TV_CusEnvZones.SelectedNodes.Count != 0)
		{
			SelectedCustomEnvironmentZone = (CustomEnvironmentZone)TV_CusEnvZones.SelectedNodes.ElementAt(0).Tag;
			method_19();
			if (!Information.IsNothing((object)SelectedCustomEnvironmentZone))
			{
				TB_AreaName.Text = SelectedCustomEnvironmentZone.Description;
				((ButtonBase)ButtonZoneColorPicker).BackColor = SelectedCustomEnvironmentZone.AreaColor;
				method_18(SelectedCustomEnvironmentZone.Area);
				method_20(zoneType_2, bool_3: false);
			}
			else
			{
				((ButtonBase)ButtonZoneColorPicker).BackColor = Color.White;
				method_18(null);
			}
		}
	}

	private void method_71(object sender, EventArgs e)
	{
		switch (zoneType_2)
		{
		case Zone.ZoneType.Zone:
			if (!Information.IsNothing((object)SelectedStandardZone))
			{
				SelectedStandardZone.AreaColor = Color.FromArgb((byte)Math.Round(Math.Min(Convert.ToDouble(Num_ZoneOpacity.Value) * 2.55, 255.0)), SelectedStandardZone.AreaColor.R, SelectedStandardZone.AreaColor.G, SelectedStandardZone.AreaColor.B);
			}
			break;
		case Zone.ZoneType.CustomEnvironmentZone:
			if (!Information.IsNothing((object)SelectedCustomEnvironmentZone))
			{
				SelectedCustomEnvironmentZone.AreaColor = Color.FromArgb((byte)Math.Round(Math.Min(Convert.ToDouble(Num_ZoneOpacity.Value) * 2.55, 255.0)), SelectedCustomEnvironmentZone.AreaColor.R, SelectedCustomEnvironmentZone.AreaColor.G, SelectedCustomEnvironmentZone.AreaColor.B);
			}
			break;
		}
		method_47();
	}

	private void method_72(object sender, EventArgs e)
	{
		if (zoneType_2 == Zone.ZoneType.CustomEnvironmentZone)
		{
			if (TV_CusEnvZones.SelectedNodes == null || TV_CusEnvZones.SelectedNodes.Count == 0)
			{
				return;
			}
			SelectedCustomEnvironmentZone = (CustomEnvironmentZone)TV_CusEnvZones.SelectedNodes.ElementAt(0).Tag;
			if (!Information.IsNothing((object)SelectedCustomEnvironmentZone))
			{
				((Zone)SelectedCustomEnvironmentZone).get_Layer(Client.CurrentSide)--;
				method_20(zoneType_2);
			}
		}
		else if (zoneType_2 == Zone.ZoneType.Zone)
		{
			if (TV_Zones.SelectedNodes == null || TV_Zones.SelectedNodes.Count == 0)
			{
				return;
			}
			SelectedStandardZone = (Zone)TV_Zones.SelectedNodes.ElementAt(0).Tag;
			if (!Information.IsNothing((object)SelectedStandardZone))
			{
				SelectedStandardZone.get_Layer(Client.CurrentSide)--;
				method_20(zoneType_2);
			}
		}
		method_47();
	}

	private void method_73(object sender, EventArgs e)
	{
		if (zoneType_2 == Zone.ZoneType.CustomEnvironmentZone)
		{
			if (TV_CusEnvZones.SelectedNodes == null || TV_CusEnvZones.SelectedNodes.Count == 0)
			{
				return;
			}
			SelectedCustomEnvironmentZone = (CustomEnvironmentZone)TV_CusEnvZones.SelectedNodes.ElementAt(0).Tag;
			if (!Information.IsNothing((object)SelectedCustomEnvironmentZone))
			{
				((Zone)SelectedCustomEnvironmentZone).get_Layer(Client.CurrentSide)++;
				method_20(zoneType_2);
			}
		}
		else if (zoneType_2 == Zone.ZoneType.Zone)
		{
			if (TV_Zones.SelectedNodes == null || TV_Zones.SelectedNodes.Count == 0)
			{
				return;
			}
			SelectedStandardZone = (Zone)TV_Zones.SelectedNodes.ElementAt(0).Tag;
			if (!Information.IsNothing((object)SelectedStandardZone))
			{
				SelectedStandardZone.get_Layer(Client.CurrentSide)++;
				method_20(zoneType_2);
			}
		}
		method_47();
	}

	private void method_74(object sender, EventArgs e)
	{
		try
		{
			if (noNavZone_0 != null)
			{
				noNavZone_0.NoFireZone = ((CheckBox)CB_NoFireZone).Checked;
				method_47();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100965123444", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_75(object sender, EventArgs e)
	{
		try
		{
			Zone zone = null;
			if (zoneType_2 == Zone.ZoneType.NoNavZone && noNavZone_0 != null)
			{
				zone = noNavZone_0;
			}
			else if (zoneType_2 == Zone.ZoneType.Zone && zone_1 != null)
			{
				zone = zone_1;
			}
			if (zone == null)
			{
				return;
			}
			zone.IsLocked = ((CheckBox)CBZoneIsLocked).Checked;
			foreach (ReferencePoint item in zone.Area)
			{
				item.IsLocked = zone.IsLocked;
			}
			method_47();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100965122321", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_76(object sender, EventArgs e)
	{
		MyProject.Forms.EnablersForm.SelectedSide = Client.CurrentSide;
		MyProject.Forms.EnablersForm.SelectedZone = SelectedStandardZone;
		((Form)MyProject.Forms.EnablersForm).Show((IWin32Window)(object)this);
	}

	private void method_77(object sender, EventArgs e)
	{
		try
		{
			bool flag = ((CheckBox)CB_VisibleAreaRPs).Checked;
			Zone zone = default(Zone);
			switch (zoneType_2)
			{
			case Zone.ZoneType.Zone:
				zone = SelectedStandardZone;
				break;
			case Zone.ZoneType.NoNavZone:
				zone = SelectedStdZone;
				break;
			case Zone.ZoneType.ExclusionZone:
				zone = SelectedExclusionZone;
				break;
			case Zone.ZoneType.CustomEnvironmentZone:
				return;
			}
			if (zone == null)
			{
				return;
			}
			foreach (ReferencePoint item in zone.Area)
			{
				if (flag)
				{
					item.IsVisible = true;
				}
				else
				{
					item.IsVisible = false;
				}
			}
			Client.MustRefreshMainForm = true;
			method_0(bool_3: true);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100965122400", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_78(object sender, EventArgs e)
	{
		List<ReferencePoint> referencePointMultipleSelection = GetReferencePointMultipleSelection();
		if (referencePointMultipleSelection == null || referencePointMultipleSelection.Count == 0)
		{
			return;
		}
		bool isVisible = ((CheckBox)CB_VisibleRP).Checked;
		foreach (ReferencePoint item in referencePointMultipleSelection)
		{
			item.IsVisible = isVisible;
		}
		method_0(bool_3: true);
	}

	private void method_79(float? nullable_0, DarkUITextBox darkUITextBox_0)
	{
		if (!nullable_0.HasValue)
		{
			darkUITextBox_0.Text = null;
		}
		else if (!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
		{
			darkUITextBox_0.Text = nullable_0.Value.ToString();
		}
		else
		{
			darkUITextBox_0.Text = (nullable_0.Value * 3.28084f).ToString();
		}
	}

	private void method_80(string string_0, ref float? nullable_0, ref float? nullable_1, ref float? nullable_2)
	{
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		float result;
		if (string.IsNullOrWhiteSpace(string_0))
		{
			nullable_0 = null;
		}
		else if (float.TryParse(string_0, out result))
		{
			if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
			{
				nullable_0 = result * 0.3048f;
			}
			else
			{
				nullable_0 = result;
			}
		}
		else
		{
			MessageBox.Show("\"" + string_0 + "\" is not a valid altitude envelope value", "Please correct inserted value");
		}
		float? num = nullable_1;
		float? num2 = nullable_2;
		if (((num.HasValue & num2.HasValue) ? new bool?(num.GetValueOrDefault() == num2.GetValueOrDefault()) : ((bool?)null)) == true)
		{
			MessageBox.Show("Altitude envelope limits are equal", "Please correct inserted value");
			return;
		}
		num2 = nullable_1;
		num = nullable_2;
		if (((!(num2.HasValue & num.HasValue)) ? ((bool?)null) : new bool?(num2.GetValueOrDefault() > num.GetValueOrDefault())) == true)
		{
			MessageBox.Show("Altitude envelope lower limit is greater than higher limit", "Please correct inserted value");
		}
	}

	private void method_81(object sender, EventArgs e)
	{
		if (SelectedExclusionZone != null)
		{
			method_80(ExclusionZoneAltitudeEnvelopeMinTextBox.Text, ref SelectedExclusionZone.AltitudeEnvelopeMin, ref SelectedExclusionZone.AltitudeEnvelopeMin, ref SelectedExclusionZone.AltitudeEnvelopeMax);
		}
	}

	private void method_82(object sender, EventArgs e)
	{
		if (SelectedExclusionZone != null)
		{
			method_80(ExclusionZoneAltitudeEnvelopeMaxTextBox.Text, ref SelectedExclusionZone.AltitudeEnvelopeMax, ref SelectedExclusionZone.AltitudeEnvelopeMin, ref SelectedExclusionZone.AltitudeEnvelopeMax);
		}
	}

	static ReferencePointManager()
	{
		Class72.smethod_20();
	}
}
