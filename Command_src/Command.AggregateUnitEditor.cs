using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command_Core.DAL;
using Command.My;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class AggregateUnitEditor : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_AddComponent")]
	private DarkButton _Button_AddComponent;

	[AccessedThroughProperty("Button_RemoveUnit")]
	[CompilerGenerated]
	private DarkButton _Button_RemoveUnit;

	[AccessedThroughProperty("DarkNumericUpDown1")]
	[CompilerGenerated]
	private DarkNumericUpDown _DarkNumericUpDown1;

	[AccessedThroughProperty("DarkTextBox1")]
	[CompilerGenerated]
	private DarkTextBox _DarkTextBox1;

	[AccessedThroughProperty("DDL_Category")]
	[CompilerGenerated]
	private DarkDropdownList _DDL_Category;

	[AccessedThroughProperty("DDL_Echelon")]
	[CompilerGenerated]
	private DarkDropdownList _DDL_Echelon;

	[AccessedThroughProperty("Button_PlaceUnit")]
	[CompilerGenerated]
	private DarkButton _Button_PlaceUnit;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Cancel")]
	private DarkButton _Button_Cancel;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_LoadTemplate")]
	private DarkButton _Button_LoadTemplate;

	[AccessedThroughProperty("Button_SaveTemplate")]
	[CompilerGenerated]
	private DarkButton _Button_SaveTemplate;

	[CompilerGenerated]
	[AccessedThroughProperty("TabControl_Assets")]
	private DarkUITabControl _TabControl_Assets;

	[AccessedThroughProperty("DarkButton1")]
	[CompilerGenerated]
	private DarkButton _DarkButton1;

	[CompilerGenerated]
	[AccessedThroughProperty("FrictionSelector")]
	private DarkNumericUpDown _FrictionSelector;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonParentEchelon")]
	private DarkUIButton _ButtonParentEchelon;

	[AccessedThroughProperty("Button_DEBUG_Retreat")]
	[CompilerGenerated]
	private DarkUIButton _Button_DEBUG_Retreat;

	[CompilerGenerated]
	[AccessedThroughProperty("DisplayFrontlineMask")]
	private DarkUIButton _DisplayFrontlineMask;

	[CompilerGenerated]
	[AccessedThroughProperty("DisplayHostileMask")]
	private DarkUIButton _DisplayHostileMask;

	[CompilerGenerated]
	[AccessedThroughProperty("DisplayEscapeMask")]
	private DarkUIButton _DisplayEscapeMask;

	[AccessedThroughProperty("LVAssignedDetached")]
	[CompilerGenerated]
	private DarkListView darkListView_0;

	private AggregateGroundUnit aggregateGroundUnit_0;

	[AccessedThroughProperty("FD_ImportTemplate")]
	[CompilerGenerated]
	private OpenFileDialog openFileDialog_0;

	[AccessedThroughProperty("FD_ExportTemplate")]
	[CompilerGenerated]
	private SaveFileDialog saveFileDialog_0;

	private DarkListView[] darkListView_1;

	internal virtual DarkButton Button_AddComponent
	{
		[CompilerGenerated]
		get
		{
			return _Button_AddComponent;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			DarkButton darkButton = _Button_AddComponent;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_AddComponent = value;
			darkButton = _Button_AddComponent;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("ListView_AssignedAssets")]
	internal virtual DarkListView ListView_AssignedAssets { get; set; }

	internal virtual DarkButton Button_RemoveUnit
	{
		[CompilerGenerated]
		get
		{
			return _Button_RemoveUnit;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_10;
			DarkButton darkButton = _Button_RemoveUnit;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_RemoveUnit = value;
			darkButton = _Button_RemoveUnit;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkNumericUpDown DarkNumericUpDown1
	{
		[CompilerGenerated]
		get
		{
			return _DarkNumericUpDown1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_8;
			DarkNumericUpDown darkNumericUpDown = _DarkNumericUpDown1;
			if (darkNumericUpDown != null)
			{
				((NumericUpDown)darkNumericUpDown).ValueChanged -= eventHandler;
			}
			_DarkNumericUpDown1 = value;
			darkNumericUpDown = _DarkNumericUpDown1;
			if (darkNumericUpDown != null)
			{
				((NumericUpDown)darkNumericUpDown).ValueChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel1")]
	internal virtual DarkLabel DarkLabel1 { get; set; }

	internal virtual DarkTextBox DarkTextBox1
	{
		[CompilerGenerated]
		get
		{
			return _DarkTextBox1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_13;
			DarkTextBox darkTextBox = _DarkTextBox1;
			if (darkTextBox != null)
			{
				((Control)darkTextBox).TextChanged -= eventHandler;
			}
			_DarkTextBox1 = value;
			darkTextBox = _DarkTextBox1;
			if (darkTextBox != null)
			{
				((Control)darkTextBox).TextChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel2")]
	internal virtual DarkLabel DarkLabel2 { get; set; }

	internal virtual DarkDropdownList DDL_Category
	{
		[CompilerGenerated]
		get
		{
			return _DDL_Category;
		}
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_14;
			DarkDropdownList darkDropdownList = _DDL_Category;
			if (darkDropdownList != null)
			{
				darkDropdownList.SelectedItemChanged -= value2;
			}
			_DDL_Category = value;
			darkDropdownList = _DDL_Category;
			if (darkDropdownList != null)
			{
				darkDropdownList.SelectedItemChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel3")]
	internal virtual DarkLabel DarkLabel3 { get; set; }

	internal virtual DarkDropdownList DDL_Echelon
	{
		[CompilerGenerated]
		get
		{
			return _DDL_Echelon;
		}
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_15;
			DarkDropdownList darkDropdownList = _DDL_Echelon;
			if (darkDropdownList != null)
			{
				darkDropdownList.SelectedItemChanged -= value2;
			}
			_DDL_Echelon = value;
			darkDropdownList = _DDL_Echelon;
			if (darkDropdownList != null)
			{
				darkDropdownList.SelectedItemChanged += value2;
			}
		}
	}

	internal virtual DarkButton Button_PlaceUnit
	{
		[CompilerGenerated]
		get
		{
			return _Button_PlaceUnit;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_11;
			DarkButton darkButton = _Button_PlaceUnit;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_PlaceUnit = value;
			darkButton = _Button_PlaceUnit;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkButton Button_Cancel
	{
		[CompilerGenerated]
		get
		{
			return _Button_Cancel;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_12;
			DarkButton darkButton = _Button_Cancel;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_Cancel = value;
			darkButton = _Button_Cancel;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkButton Button_LoadTemplate
	{
		[CompilerGenerated]
		get
		{
			return _Button_LoadTemplate;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = Button_LoadTemplate_Click;
			DarkButton darkButton = _Button_LoadTemplate;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_LoadTemplate = value;
			darkButton = _Button_LoadTemplate;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkButton Button_SaveTemplate
	{
		[CompilerGenerated]
		get
		{
			return _Button_SaveTemplate;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = Button_SaveTemplate_Click;
			DarkButton darkButton = _Button_SaveTemplate;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_SaveTemplate = value;
			darkButton = _Button_SaveTemplate;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel4")]
	internal virtual DarkLabel DarkLabel4 { get; set; }

	internal virtual DarkUITabControl TabControl_Assets
	{
		[CompilerGenerated]
		get
		{
			return _TabControl_Assets;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_6;
			DarkUITabControl darkUITabControl = _TabControl_Assets;
			if (darkUITabControl != null)
			{
				((TabControl)darkUITabControl).SelectedIndexChanged -= eventHandler;
			}
			_TabControl_Assets = value;
			darkUITabControl = _TabControl_Assets;
			if (darkUITabControl != null)
			{
				((TabControl)darkUITabControl).SelectedIndexChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TabPage1")]
	internal virtual TabPage TabPage1 { get; set; }

	[field: AccessedThroughProperty("TabPage2")]
	internal virtual TabPage TabPage2 { get; set; }

	[field: AccessedThroughProperty("ListView_ActualAssets")]
	internal virtual DarkListView ListView_ActualAssets { get; set; }

	internal virtual DarkButton DarkButton1
	{
		[CompilerGenerated]
		get
		{
			return _DarkButton1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_16;
			DarkButton darkButton = _DarkButton1;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_DarkButton1 = value;
			darkButton = _DarkButton1;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("FrictionLabel")]
	internal virtual DarkLabel FrictionLabel { get; set; }

	internal virtual DarkNumericUpDown FrictionSelector
	{
		[CompilerGenerated]
		get
		{
			return _FrictionSelector;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			MouseEventHandler val = new MouseEventHandler(method_17);
			EventHandler eventHandler = method_23;
			DarkNumericUpDown darkNumericUpDown = _FrictionSelector;
			if (darkNumericUpDown != null)
			{
				((Control)darkNumericUpDown).MouseClick -= val;
				((NumericUpDown)darkNumericUpDown).ValueChanged -= eventHandler;
			}
			_FrictionSelector = value;
			darkNumericUpDown = _FrictionSelector;
			if (darkNumericUpDown != null)
			{
				((Control)darkNumericUpDown).MouseClick += val;
				((NumericUpDown)darkNumericUpDown).ValueChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkGroupBox1")]
	internal virtual DarkGroupBox DarkGroupBox1 { get; set; }

	[field: AccessedThroughProperty("LV_Offence")]
	internal virtual DarkListView LV_Offence { get; set; }

	[field: AccessedThroughProperty("DarkGroupBox2")]
	internal virtual DarkGroupBox DarkGroupBox2 { get; set; }

	[field: AccessedThroughProperty("LV_Defence")]
	internal virtual DarkListView LV_Defence { get; set; }

	[field: AccessedThroughProperty("DarkGroupBox3")]
	internal virtual DarkGroupBox DarkGroupBox3 { get; set; }

	[field: AccessedThroughProperty("LV_General")]
	internal virtual DarkListView LV_General { get; set; }

	internal virtual DarkUIButton ButtonParentEchelon
	{
		[CompilerGenerated]
		get
		{
			return _ButtonParentEchelon;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_18;
			DarkUIButton darkUIButton = _ButtonParentEchelon;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonParentEchelon = value;
			darkUIButton = _ButtonParentEchelon;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("GBDebugRuntime")]
	internal virtual DarkGroupBox GBDebugRuntime { get; set; }

	[field: AccessedThroughProperty("FlowLayoutPanel1")]
	internal virtual FlowLayoutPanel FlowLayoutPanel1 { get; set; }

	internal virtual DarkUIButton Button_DEBUG_Retreat
	{
		[CompilerGenerated]
		get
		{
			return _Button_DEBUG_Retreat;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_19;
			DarkUIButton darkUIButton = _Button_DEBUG_Retreat;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_DEBUG_Retreat = value;
			darkUIButton = _Button_DEBUG_Retreat;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton DisplayFrontlineMask
	{
		[CompilerGenerated]
		get
		{
			return _DisplayFrontlineMask;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_20;
			DarkUIButton darkUIButton = _DisplayFrontlineMask;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_DisplayFrontlineMask = value;
			darkUIButton = _DisplayFrontlineMask;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton DisplayHostileMask
	{
		[CompilerGenerated]
		get
		{
			return _DisplayHostileMask;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_21;
			DarkUIButton darkUIButton = _DisplayHostileMask;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_DisplayHostileMask = value;
			darkUIButton = _DisplayHostileMask;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton DisplayEscapeMask
	{
		[CompilerGenerated]
		get
		{
			return _DisplayEscapeMask;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_22;
			DarkUIButton darkUIButton = _DisplayEscapeMask;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_DisplayEscapeMask = value;
			darkUIButton = _DisplayEscapeMask;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkButton2")]
	internal virtual DarkButton DarkButton2 { get; set; }

	[field: AccessedThroughProperty("FlowLayoutPanel3")]
	internal virtual FlowLayoutPanel FlowLayoutPanel3 { get; set; }

	[field: AccessedThroughProperty("tab_DetachedAssigned")]
	internal virtual TabPage tab_DetachedAssigned { get; set; }

	internal virtual DarkListView LVAssignedDetached
	{
		[CompilerGenerated]
		get
		{
			return darkListView_0;
		}
		[CompilerGenerated]
		set
		{
			darkListView_0 = value;
		}
	}

	[field: AccessedThroughProperty("TB_Report")]
	internal virtual RichTextBox TB_Report { get; set; }

	private virtual OpenFileDialog FD_ImportTemplate
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

	private virtual SaveFileDialog FD_ExportTemplate
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

	public AggregateGroundUnit myUnit
	{
		get
		{
			return aggregateGroundUnit_0;
		}
		set
		{
			AggregateGroundUnit aggregateGroundUnit = aggregateGroundUnit_0;
			aggregateGroundUnit_0 = value;
			if (aggregateGroundUnit_0 != aggregateGroundUnit)
			{
				method_9();
			}
		}
	}

	public AggregateUnitEditor()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		((Form)this).Load += AggregateUnitEditor_Load;
		((Form)this).FormClosing += new FormClosingEventHandler(AggregateUnitEditor_FormClosing);
		((Form)this).Shown += AggregateUnitEditor_Shown;
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
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Expected O, but got Unknown
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_044d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0457: Expected O, but got Unknown
		//IL_0551: Unknown result type (might be due to invalid IL or missing references)
		//IL_055b: Expected O, but got Unknown
		//IL_0606: Unknown result type (might be due to invalid IL or missing references)
		//IL_0665: Unknown result type (might be due to invalid IL or missing references)
		//IL_066f: Expected O, but got Unknown
		//IL_0791: Unknown result type (might be due to invalid IL or missing references)
		//IL_0825: Unknown result type (might be due to invalid IL or missing references)
		//IL_088c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0896: Expected O, but got Unknown
		//IL_08e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_094d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0957: Expected O, but got Unknown
		//IL_09a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cd1: Expected O, but got Unknown
		//IL_0d70: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d7a: Expected O, but got Unknown
		//IL_0dbb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f49: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f53: Expected O, but got Unknown
		//IL_1376: Unknown result type (might be due to invalid IL or missing references)
		//IL_1580: Unknown result type (might be due to invalid IL or missing references)
		//IL_1612: Unknown result type (might be due to invalid IL or missing references)
		//IL_16a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1736: Unknown result type (might be due to invalid IL or missing references)
		//IL_1796: Unknown result type (might be due to invalid IL or missing references)
		//IL_17a0: Expected O, but got Unknown
		//IL_17da: Unknown result type (might be due to invalid IL or missing references)
		DarkButton1 = new DarkButton();
		TabControl_Assets = new DarkUITabControl();
		TabPage1 = new TabPage();
		ListView_AssignedAssets = new DarkListView();
		tab_DetachedAssigned = new TabPage();
		LVAssignedDetached = new DarkListView();
		TabPage2 = new TabPage();
		ListView_ActualAssets = new DarkListView();
		DarkLabel4 = new DarkLabel();
		Button_SaveTemplate = new DarkButton();
		Button_LoadTemplate = new DarkButton();
		Button_Cancel = new DarkButton();
		Button_PlaceUnit = new DarkButton();
		DDL_Echelon = new DarkDropdownList();
		DarkLabel3 = new DarkLabel();
		DDL_Category = new DarkDropdownList();
		DarkLabel2 = new DarkLabel();
		DarkTextBox1 = new DarkTextBox();
		DarkLabel1 = new DarkLabel();
		DarkNumericUpDown1 = new DarkNumericUpDown();
		Button_RemoveUnit = new DarkButton();
		Button_AddComponent = new DarkButton();
		FrictionLabel = new DarkLabel();
		FrictionSelector = new DarkNumericUpDown();
		DarkGroupBox1 = new DarkGroupBox();
		LV_Offence = new DarkListView();
		DarkGroupBox2 = new DarkGroupBox();
		LV_Defence = new DarkListView();
		DarkGroupBox3 = new DarkGroupBox();
		LV_General = new DarkListView();
		ButtonParentEchelon = new DarkUIButton();
		GBDebugRuntime = new DarkGroupBox();
		FlowLayoutPanel1 = new FlowLayoutPanel();
		Button_DEBUG_Retreat = new DarkUIButton();
		DisplayFrontlineMask = new DarkUIButton();
		DisplayHostileMask = new DarkUIButton();
		DisplayEscapeMask = new DarkUIButton();
		DarkButton2 = new DarkButton();
		FlowLayoutPanel3 = new FlowLayoutPanel();
		TB_Report = new RichTextBox();
		((Control)TabControl_Assets).SuspendLayout();
		((Control)TabPage1).SuspendLayout();
		((Control)tab_DetachedAssigned).SuspendLayout();
		((Control)TabPage2).SuspendLayout();
		((ISupportInitialize)DarkNumericUpDown1).BeginInit();
		((ISupportInitialize)FrictionSelector).BeginInit();
		((Control)DarkGroupBox1).SuspendLayout();
		((Control)DarkGroupBox2).SuspendLayout();
		((Control)DarkGroupBox3).SuspendLayout();
		((Control)GBDebugRuntime).SuspendLayout();
		((Control)FlowLayoutPanel1).SuspendLayout();
		((Control)FlowLayoutPanel3).SuspendLayout();
		((Control)this).SuspendLayout();
		((Button)DarkButton1).DialogResult = (DialogResult)7;
		((Control)DarkButton1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkButton1).Location = new Point(304, 3);
		((Control)DarkButton1).Name = "DarkButton1";
		((Control)DarkButton1).Padding = new Padding(5);
		((Control)DarkButton1).Size = new Size(288, 23);
		((Control)DarkButton1).TabIndex = 42;
		DarkButton1.Text = "Copy from assigned to actual";
		((Control)TabControl_Assets).Controls.Add((Control)(object)TabPage1);
		((Control)TabControl_Assets).Controls.Add((Control)(object)tab_DetachedAssigned);
		((Control)TabControl_Assets).Controls.Add((Control)(object)TabPage2);
		((Control)TabControl_Assets).Cursor = Cursors.Hand;
		((TabControl)TabControl_Assets).ItemSize = new Size(80, 20);
		((Control)TabControl_Assets).Location = new Point(15, 156);
		((Control)TabControl_Assets).Name = "TabControl_Assets";
		((TabControl)TabControl_Assets).SelectedIndex = 0;
		((Control)TabControl_Assets).Size = new Size(288, 244);
		((Control)TabControl_Assets).TabIndex = 41;
		TabPage1.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage1).Controls.Add((Control)(object)ListView_AssignedAssets);
		TabPage1.Location = new Point(4, 24);
		((Control)TabPage1).Name = "TabPage1";
		((Control)TabPage1).Padding = new Padding(3);
		((Control)TabPage1).Size = new Size(280, 216);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "Assigned";
		((Control)ListView_AssignedAssets).Dock = (DockStyle)5;
		((Control)ListView_AssignedAssets).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)ListView_AssignedAssets).Location = new Point(3, 3);
		((Control)ListView_AssignedAssets).Name = "ListView_AssignedAssets";
		ListView_AssignedAssets.RelatedInfos = null;
		((Control)ListView_AssignedAssets).Size = new Size(274, 210);
		((Control)ListView_AssignedAssets).TabIndex = 24;
		tab_DetachedAssigned.BackColor = Color.FromArgb(60, 63, 65);
		((Control)tab_DetachedAssigned).Controls.Add((Control)(object)LVAssignedDetached);
		tab_DetachedAssigned.Location = new Point(4, 24);
		((Control)tab_DetachedAssigned).Name = "tab_DetachedAssigned";
		((Control)tab_DetachedAssigned).Size = new Size(280, 216);
		tab_DetachedAssigned.TabIndex = 2;
		tab_DetachedAssigned.Text = "Assigned (Detached)";
		((Control)LVAssignedDetached).Anchor = (AnchorStyles)15;
		((Control)LVAssignedDetached).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LVAssignedDetached).Location = new Point(3, 3);
		((Control)LVAssignedDetached).Name = "LVAssignedDetached";
		LVAssignedDetached.RelatedInfos = null;
		((Control)LVAssignedDetached).Size = new Size(274, 210);
		((Control)LVAssignedDetached).TabIndex = 25;
		TabPage2.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage2).Controls.Add((Control)(object)ListView_ActualAssets);
		TabPage2.Location = new Point(4, 24);
		((Control)TabPage2).Name = "TabPage2";
		((Control)TabPage2).Padding = new Padding(3);
		((Control)TabPage2).Size = new Size(280, 216);
		TabPage2.TabIndex = 1;
		TabPage2.Text = "Actual";
		((Control)ListView_ActualAssets).Dock = (DockStyle)5;
		((Control)ListView_ActualAssets).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)ListView_ActualAssets).Location = new Point(3, 3);
		((Control)ListView_ActualAssets).Name = "ListView_ActualAssets";
		ListView_ActualAssets.RelatedInfos = null;
		((Control)ListView_ActualAssets).Size = new Size(274, 210);
		((Control)ListView_ActualAssets).TabIndex = 25;
		((Control)DarkLabel4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel4).Location = new Point(15, 118);
		((Control)DarkLabel4).Name = "DarkLabel4";
		((Control)DarkLabel4).Size = new Size(70, 20);
		((Control)DarkLabel4).TabIndex = 39;
		((Label)DarkLabel4).Text = "Parent:";
		((Button)Button_SaveTemplate).DialogResult = (DialogResult)7;
		((Control)Button_SaveTemplate).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_SaveTemplate).Location = new Point(331, 46);
		((Control)Button_SaveTemplate).Name = "Button_SaveTemplate";
		((Control)Button_SaveTemplate).Padding = new Padding(5);
		((Control)Button_SaveTemplate).Size = new Size(300, 26);
		((Control)Button_SaveTemplate).TabIndex = 38;
		Button_SaveTemplate.Text = "Save to template...";
		((Button)Button_LoadTemplate).DialogResult = (DialogResult)7;
		((Control)Button_LoadTemplate).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_LoadTemplate).Location = new Point(15, 46);
		((Control)Button_LoadTemplate).Name = "Button_LoadTemplate";
		((Control)Button_LoadTemplate).Padding = new Padding(5);
		((Control)Button_LoadTemplate).Size = new Size(310, 26);
		((Control)Button_LoadTemplate).TabIndex = 37;
		Button_LoadTemplate.Text = "Load from template...";
		((Control)Button_Cancel).Anchor = (AnchorStyles)13;
		((Button)Button_Cancel).DialogResult = (DialogResult)7;
		((Control)Button_Cancel).Font = new Font("Segoe UI", 12f);
		((Control)Button_Cancel).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_Cancel).Location = new Point(377, 484);
		((Control)Button_Cancel).Name = "Button_Cancel";
		((Control)Button_Cancel).Padding = new Padding(5);
		((Control)Button_Cancel).Size = new Size(257, 26);
		((Control)Button_Cancel).TabIndex = 36;
		Button_Cancel.Text = "CANCEL";
		((Control)Button_PlaceUnit).Anchor = (AnchorStyles)13;
		((Button)Button_PlaceUnit).DialogResult = (DialogResult)7;
		((Control)Button_PlaceUnit).Font = new Font("Segoe UI", 12f);
		((Control)Button_PlaceUnit).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_PlaceUnit).Location = new Point(12, 484);
		((Control)Button_PlaceUnit).Name = "Button_PlaceUnit";
		((Control)Button_PlaceUnit).Padding = new Padding(5);
		((Control)Button_PlaceUnit).Size = new Size(255, 26);
		((Control)Button_PlaceUnit).TabIndex = 35;
		Button_PlaceUnit.Text = "PLACE UNIT";
		DDL_Echelon.AutoResizeOnItemChange = false;
		((Control)DDL_Echelon).Location = new Point(433, 83);
		((Control)DDL_Echelon).Name = "DDL_Echelon";
		((Control)DDL_Echelon).Size = new Size(198, 26);
		((Control)DDL_Echelon).TabIndex = 34;
		((Control)DDL_Echelon).Text = "DarkDropdownList2";
		((Control)DarkLabel3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel3).Location = new Point(359, 86);
		((Control)DarkLabel3).Name = "DarkLabel3";
		((Control)DarkLabel3).Size = new Size(70, 20);
		((Control)DarkLabel3).TabIndex = 33;
		((Label)DarkLabel3).Text = "Echelon:";
		DDL_Category.AutoResizeOnItemChange = false;
		((Control)DDL_Category).Location = new Point(74, 83);
		((Control)DDL_Category).Name = "DDL_Category";
		((Control)DDL_Category).Size = new Size(222, 26);
		((Control)DDL_Category).TabIndex = 32;
		((Control)DDL_Category).Text = "DarkDropdownList1";
		((Control)DarkLabel2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel2).Location = new Point(14, 89);
		((Control)DarkLabel2).Name = "DarkLabel2";
		((Control)DarkLabel2).Size = new Size(72, 20);
		((Control)DarkLabel2).TabIndex = 31;
		((Label)DarkLabel2).Text = "Category:";
		((TextBoxBase)DarkTextBox1).BackColor = Color.FromArgb(69, 73, 74);
		((TextBoxBase)DarkTextBox1).BorderStyle = (BorderStyle)1;
		((TextBoxBase)DarkTextBox1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkTextBox1).Location = new Point(83, 12);
		((Control)DarkTextBox1).Name = "DarkTextBox1";
		((Control)DarkTextBox1).Size = new Size(548, 23);
		((Control)DarkTextBox1).TabIndex = 30;
		((Control)DarkLabel1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel1).Location = new Point(14, 15);
		((Control)DarkLabel1).Name = "DarkLabel1";
		((Control)DarkLabel1).Size = new Size(72, 20);
		((Control)DarkLabel1).TabIndex = 29;
		((Label)DarkLabel1).Text = "Unit name:";
		((UpDownBase)DarkNumericUpDown1).BackColor = Color.FromArgb(43, 43, 43);
		((UpDownBase)DarkNumericUpDown1).BorderStyle = (BorderStyle)0;
		((Control)DarkNumericUpDown1).Font = new Font("Segoe UI", 11f);
		((UpDownBase)DarkNumericUpDown1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkNumericUpDown1).Location = new Point(17, 409);
		((NumericUpDown)DarkNumericUpDown1).Maximum = new decimal(new int[4] { 10000, 0, 0, 0 });
		((Control)DarkNumericUpDown1).Name = "DarkNumericUpDown1";
		((Control)DarkNumericUpDown1).Size = new Size(168, 23);
		((Control)DarkNumericUpDown1).TabIndex = 28;
		((Control)Button_RemoveUnit).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button_RemoveUnit).ForeColor = Color.Red;
		((Control)Button_RemoveUnit).Location = new Point(191, 409);
		((Control)Button_RemoveUnit).Name = "Button_RemoveUnit";
		((Control)Button_RemoveUnit).Padding = new Padding(5);
		((Control)Button_RemoveUnit).Size = new Size(108, 23);
		((Control)Button_RemoveUnit).TabIndex = 27;
		Button_RemoveUnit.Text = "Remove";
		((Button)Button_AddComponent).DialogResult = (DialogResult)7;
		((Control)Button_AddComponent).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_AddComponent).Location = new Point(3, 3);
		((Control)Button_AddComponent).Name = "Button_AddComponent";
		((Control)Button_AddComponent).Padding = new Padding(5);
		((Control)Button_AddComponent).Size = new Size(295, 23);
		((Control)Button_AddComponent).TabIndex = 23;
		Button_AddComponent.Text = "Add component";
		((Control)FrictionLabel).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)FrictionLabel).Location = new Point(359, 115);
		((Control)FrictionLabel).Name = "FrictionLabel";
		((Control)FrictionLabel).Size = new Size(70, 20);
		((Control)FrictionLabel).TabIndex = 43;
		((Label)FrictionLabel).Text = "Friction:";
		((Control)FrictionSelector).Anchor = (AnchorStyles)7;
		((UpDownBase)FrictionSelector).BackColor = Color.FromArgb(43, 43, 43);
		((UpDownBase)FrictionSelector).BorderStyle = (BorderStyle)0;
		((NumericUpDown)FrictionSelector).DecimalPlaces = 2;
		((Control)FrictionSelector).Font = new Font("Segoe UI", 11f);
		((UpDownBase)FrictionSelector).ForeColor = Color.FromArgb(220, 220, 220);
		((NumericUpDown)FrictionSelector).Increment = new decimal(new int[4] { 1, 0, 0, 131072 });
		((Control)FrictionSelector).Location = new Point(433, 115);
		((NumericUpDown)FrictionSelector).Maximum = new decimal(new int[4] { 1, 0, 0, 0 });
		((Control)FrictionSelector).Name = "FrictionSelector";
		((Control)FrictionSelector).Size = new Size(198, 23);
		((Control)FrictionSelector).TabIndex = 44;
		((Control)DarkGroupBox1).Controls.Add((Control)(object)LV_Offence);
		((Control)DarkGroupBox1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkGroupBox1).Location = new Point(452, 158);
		((Control)DarkGroupBox1).Name = "DarkGroupBox1";
		((Control)DarkGroupBox1).Size = new Size(182, 139);
		((Control)DarkGroupBox1).TabIndex = 46;
		((GroupBox)DarkGroupBox1).TabStop = false;
		((GroupBox)DarkGroupBox1).Text = "Offense";
		((Control)LV_Offence).Dock = (DockStyle)5;
		((Control)LV_Offence).Location = new Point(3, 19);
		((Control)LV_Offence).Name = "LV_Offence";
		LV_Offence.RelatedInfos = null;
		((Control)LV_Offence).Size = new Size(176, 117);
		((Control)LV_Offence).TabIndex = 0;
		((Control)LV_Offence).Text = "DarkListView1";
		((Control)DarkGroupBox2).Controls.Add((Control)(object)LV_Defence);
		((Control)DarkGroupBox2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkGroupBox2).Location = new Point(452, 303);
		((Control)DarkGroupBox2).Name = "DarkGroupBox2";
		((Control)DarkGroupBox2).Size = new Size(179, 135);
		((Control)DarkGroupBox2).TabIndex = 47;
		((GroupBox)DarkGroupBox2).TabStop = false;
		((GroupBox)DarkGroupBox2).Text = "Defense";
		((Control)LV_Defence).Dock = (DockStyle)5;
		((Control)LV_Defence).Location = new Point(3, 19);
		((Control)LV_Defence).Name = "LV_Defence";
		LV_Defence.RelatedInfos = null;
		((Control)LV_Defence).Size = new Size(173, 113);
		((Control)LV_Defence).TabIndex = 1;
		((Control)LV_Defence).Text = "DarkListView2";
		((Control)DarkGroupBox3).Controls.Add((Control)(object)LV_General);
		((Control)DarkGroupBox3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkGroupBox3).Location = new Point(309, 158);
		((Control)DarkGroupBox3).Name = "DarkGroupBox3";
		((Control)DarkGroupBox3).Size = new Size(137, 280);
		((Control)DarkGroupBox3).TabIndex = 47;
		((GroupBox)DarkGroupBox3).TabStop = false;
		((GroupBox)DarkGroupBox3).Text = "General";
		((Control)LV_General).Dock = (DockStyle)5;
		((Control)LV_General).Location = new Point(3, 19);
		((Control)LV_General).Name = "LV_General";
		LV_General.RelatedInfos = null;
		((Control)LV_General).Size = new Size(131, 258);
		((Control)LV_General).TabIndex = 0;
		((Control)LV_General).Text = "DarkListView1";
		((Control)ButtonParentEchelon).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)ButtonParentEchelon).Location = new Point(74, 117);
		((Control)ButtonParentEchelon).Name = "ButtonParentEchelon";
		((Control)ButtonParentEchelon).Padding = new Padding(5);
		ButtonParentEchelon.RoundRadius = 0;
		((Control)ButtonParentEchelon).Size = new Size(222, 23);
		((Control)ButtonParentEchelon).TabIndex = 48;
		ButtonParentEchelon.Text = "Select HQ";
		((Control)GBDebugRuntime).Controls.Add((Control)(object)FlowLayoutPanel1);
		((Control)GBDebugRuntime).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GBDebugRuntime).Location = new Point(637, 12);
		((Control)GBDebugRuntime).Name = "GBDebugRuntime";
		((Control)GBDebugRuntime).Size = new Size(260, 496);
		((Control)GBDebugRuntime).TabIndex = 48;
		((GroupBox)GBDebugRuntime).TabStop = false;
		((GroupBox)GBDebugRuntime).Text = "DEBUG RUNTIME";
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)Button_DEBUG_Retreat);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)DisplayFrontlineMask);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)DisplayHostileMask);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)DisplayEscapeMask);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)DarkButton2);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)TB_Report);
		((Control)FlowLayoutPanel1).Dock = (DockStyle)5;
		((Control)FlowLayoutPanel1).Location = new Point(3, 19);
		((Control)FlowLayoutPanel1).Name = "FlowLayoutPanel1";
		((Control)FlowLayoutPanel1).Size = new Size(254, 474);
		((Control)FlowLayoutPanel1).TabIndex = 0;
		((Control)Button_DEBUG_Retreat).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_DEBUG_Retreat).Location = new Point(3, 3);
		((Control)Button_DEBUG_Retreat).Name = "Button_DEBUG_Retreat";
		((Control)Button_DEBUG_Retreat).Padding = new Padding(5);
		Button_DEBUG_Retreat.RoundRadius = 0;
		((Control)Button_DEBUG_Retreat).Size = new Size(248, 23);
		((Control)Button_DEBUG_Retreat).TabIndex = 0;
		Button_DEBUG_Retreat.Text = "Order_Fallback";
		((Control)DisplayFrontlineMask).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DisplayFrontlineMask).Location = new Point(3, 32);
		((Control)DisplayFrontlineMask).Name = "DisplayFrontlineMask";
		((Control)DisplayFrontlineMask).Padding = new Padding(5);
		DisplayFrontlineMask.RoundRadius = 0;
		((Control)DisplayFrontlineMask).Size = new Size(248, 23);
		((Control)DisplayFrontlineMask).TabIndex = 1;
		DisplayFrontlineMask.Text = "Display Mask frontline";
		((Control)DisplayHostileMask).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DisplayHostileMask).Location = new Point(3, 61);
		((Control)DisplayHostileMask).Name = "DisplayHostileMask";
		((Control)DisplayHostileMask).Padding = new Padding(5);
		DisplayHostileMask.RoundRadius = 0;
		((Control)DisplayHostileMask).Size = new Size(248, 23);
		((Control)DisplayHostileMask).TabIndex = 2;
		DisplayHostileMask.Text = "Display Mask hostile";
		((Control)DisplayEscapeMask).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DisplayEscapeMask).Location = new Point(3, 90);
		((Control)DisplayEscapeMask).Name = "DisplayEscapeMask";
		((Control)DisplayEscapeMask).Padding = new Padding(5);
		DisplayEscapeMask.RoundRadius = 0;
		((Control)DisplayEscapeMask).Size = new Size(248, 23);
		((Control)DisplayEscapeMask).TabIndex = 3;
		DisplayEscapeMask.Text = "Display Mask Escape";
		((Control)DarkButton2).Font = new Font("Segoe UI", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)DarkButton2).ForeColor = Color.Red;
		((Control)DarkButton2).Location = new Point(3, 119);
		((Control)DarkButton2).Name = "DarkButton2";
		((Control)DarkButton2).Padding = new Padding(5);
		((Control)DarkButton2).Size = new Size(248, 23);
		((Control)DarkButton2).TabIndex = 49;
		DarkButton2.Text = "Remove selected";
		((Control)FlowLayoutPanel3).Anchor = (AnchorStyles)13;
		((Control)FlowLayoutPanel3).Controls.Add((Control)(object)Button_AddComponent);
		((Control)FlowLayoutPanel3).Controls.Add((Control)(object)DarkButton1);
		((Control)FlowLayoutPanel3).Location = new Point(12, 444);
		((Control)FlowLayoutPanel3).Name = "FlowLayoutPanel3";
		((Control)FlowLayoutPanel3).Size = new Size(622, 32);
		((Control)FlowLayoutPanel3).TabIndex = 49;
		((TextBoxBase)TB_Report).BackColor = Color.FromArgb(63, 63, 63);
		TB_Report.ForeColor = SystemColors.Window;
		((Control)TB_Report).Location = new Point(3, 148);
		((Control)TB_Report).Name = "TB_Report";
		((Control)TB_Report).Size = new Size(248, 323);
		((Control)TB_Report).TabIndex = 50;
		TB_Report.Text = "";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(909, 519);
		((Control)this).Controls.Add((Control)(object)Button_RemoveUnit);
		((Control)this).Controls.Add((Control)(object)DarkNumericUpDown1);
		((Control)this).Controls.Add((Control)(object)FlowLayoutPanel3);
		((Control)this).Controls.Add((Control)(object)GBDebugRuntime);
		((Control)this).Controls.Add((Control)(object)ButtonParentEchelon);
		((Control)this).Controls.Add((Control)(object)DarkGroupBox3);
		((Control)this).Controls.Add((Control)(object)DarkGroupBox2);
		((Control)this).Controls.Add((Control)(object)DarkGroupBox1);
		((Control)this).Controls.Add((Control)(object)FrictionSelector);
		((Control)this).Controls.Add((Control)(object)FrictionLabel);
		((Control)this).Controls.Add((Control)(object)TabControl_Assets);
		((Control)this).Controls.Add((Control)(object)DarkLabel4);
		((Control)this).Controls.Add((Control)(object)Button_SaveTemplate);
		((Control)this).Controls.Add((Control)(object)Button_LoadTemplate);
		((Control)this).Controls.Add((Control)(object)Button_Cancel);
		((Control)this).Controls.Add((Control)(object)Button_PlaceUnit);
		((Control)this).Controls.Add((Control)(object)DDL_Echelon);
		((Control)this).Controls.Add((Control)(object)DarkLabel3);
		((Control)this).Controls.Add((Control)(object)DDL_Category);
		((Control)this).Controls.Add((Control)(object)DarkLabel2);
		((Control)this).Controls.Add((Control)(object)DarkTextBox1);
		((Control)this).Controls.Add((Control)(object)DarkLabel1);
		((Form)this).Location = new Point(0, 0);
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "AggregateUnitEditor";
		((Form)this).Text = "Aggregate Unit Editor";
		((Control)TabControl_Assets).ResumeLayout(false);
		((Control)TabPage1).ResumeLayout(false);
		((Control)tab_DetachedAssigned).ResumeLayout(false);
		((Control)TabPage2).ResumeLayout(false);
		((ISupportInitialize)DarkNumericUpDown1).EndInit();
		((ISupportInitialize)FrictionSelector).EndInit();
		((Control)DarkGroupBox1).ResumeLayout(false);
		((Control)DarkGroupBox2).ResumeLayout(false);
		((Control)DarkGroupBox3).ResumeLayout(false);
		((Control)GBDebugRuntime).ResumeLayout(false);
		((Control)FlowLayoutPanel1).ResumeLayout(false);
		((Control)FlowLayoutPanel3).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void AggregateUnitEditor_Load(object sender, EventArgs e)
	{
		darkListView_1 = new DarkListView[Enum.GetValues(typeof(RosterType)).Length - 1 + 1];
		darkListView_1[0] = ListView_AssignedAssets;
		darkListView_1[2] = ListView_ActualAssets;
		darkListView_1[1] = LVAssignedDetached;
		Array values = Enum.GetValues(typeof(AggregateGroundUnit.GroundEchelonLevel));
		foreach (object item in values)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(item);
			DarkDropdownItem darkDropdownItem = new DarkDropdownItem();
			darkDropdownItem.Text = objectValue.ToString();
			darkDropdownItem.Value = Conversions.ToString(Conversions.ToInteger(objectValue));
			DDL_Echelon.Items.Add(darkDropdownItem);
		}
		DDL_Echelon.ResizeMenu(setWidth: true, setHeight: true);
		Array values2 = Enum.GetValues(typeof(IMobileGroundUnit._MobileUnitCategory));
		List<object> list = new List<object>();
		foreach (object item2 in values2)
		{
			object objectValue2 = RuntimeHelpers.GetObjectValue(item2);
			list.Add(RuntimeHelpers.GetObjectValue(objectValue2));
		}
		list = list.OrderBy([SpecialName] (object theEnum) => theEnum.ToString()).ToList();
		foreach (object item3 in list)
		{
			object objectValue3 = RuntimeHelpers.GetObjectValue(item3);
			DarkDropdownItem darkDropdownItem2 = new DarkDropdownItem();
			darkDropdownItem2.Text = objectValue3.ToString();
			darkDropdownItem2.Value = Conversions.ToString(Conversions.ToInteger(objectValue3));
			DDL_Category.Items.Add(darkDropdownItem2);
		}
		DDL_Category.ResizeMenu(setWidth: true, setHeight: true);
		ListView_AssignedAssets.SelectedIndicesChanged += method_7;
		LVAssignedDetached.SelectedIndicesChanged += method_7;
		ListView_ActualAssets.SelectedIndicesChanged += method_7;
	}

	private void method_2(object sender, EventArgs e)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Invalid comparison between Unknown and I4
		if ((int)((Form)MyProject.Forms.AddUnit).ShowDialog() != 1)
		{
			return;
		}
		int selectedDBID = MyProject.Forms.AddUnit.SelectedDBID;
		GlobalVariables.ActiveUnitType selectedUnitType = MyProject.Forms.AddUnit.SelectedUnitType;
		string annexAndDBID = AggregateGroundUnit.GetAnnexAndDBID(selectedDBID, selectedUnitType);
		switch (((TabControl)TabControl_Assets).SelectedIndex)
		{
		case 0:
			if (myUnit.GetAssignedRoster_Readonly().ContainsKey(annexAndDBID))
			{
				myUnit.GetAssignedRoster_Readonly()[annexAndDBID]++;
			}
			else
			{
				myUnit.GetAssignedRoster_Readonly().Add(annexAndDBID, 1);
			}
			break;
		case 1:
			if (myUnit.GetAssignedDetachedRoster_Readonly().ContainsKey(annexAndDBID))
			{
				myUnit.GetAssignedDetachedRoster_Readonly()[annexAndDBID]++;
			}
			else
			{
				myUnit.GetAssignedDetachedRoster_Readonly().Add(annexAndDBID, 1);
			}
			break;
		case 2:
			myUnit.AddOrRemoveActualRoster(annexAndDBID, 1, AutomaticallyAlignAssignedRoster: true);
			break;
		}
		RefreshRosterList(ClearAndRebuild: true);
	}

	public void RefreshRosterList(bool ClearAndRebuild)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_04ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f6: Expected O, but got Unknown
		((Control)ListView_ActualAssets).MouseMove -= new MouseEventHandler(method_4);
		if (ClearAndRebuild)
		{
			ListView_AssignedAssets.Items.Clear();
			foreach (KeyValuePair<string, int> item in myUnit.GetAssignedRoster_Readonly())
			{
				DarkListItem darkListItem = new DarkListItem();
				darkListItem.Tag = item.Key;
				darkListItem.Text = Conversions.ToString(item.Value) + "x " + method_3(item.Key);
				ListView_AssignedAssets.Items.Add(darkListItem);
			}
			ListView_ActualAssets.Items.Clear();
			foreach (KeyValuePair<string, (ActiveUnit, int)> item2 in myUnit.GetActualRoster_Readonly())
			{
				DarkListItem darkListItem2 = new DarkListItem();
				darkListItem2.Tag = item2.Key;
				darkListItem2.Text = Conversions.ToString(item2.Value.Item2) + "x " + method_3(item2.Key);
				ListView_ActualAssets.Items.Add(darkListItem2);
			}
			Dictionary<string, int> actualDetachedRoster = myUnit.GetActualDetachedRoster();
			if (actualDetachedRoster != null)
			{
				foreach (KeyValuePair<string, int> item3 in actualDetachedRoster)
				{
					DarkListItem darkListItem3 = new DarkListItem();
					darkListItem3.Tag = null;
					darkListItem3.Text = "[DETACHED] " + Conversions.ToString(item3.Value) + "x " + method_3(item3.Key);
					ListView_ActualAssets.Items.Add(darkListItem3);
				}
			}
			LVAssignedDetached.Items.Clear();
			foreach (KeyValuePair<string, int> item4 in myUnit.GetAssignedDetachedRoster_Readonly())
			{
				DarkListItem darkListItem4 = new DarkListItem();
				darkListItem4.Tag = item4.Key;
				darkListItem4.Text = Conversions.ToString(item4.Value) + "x " + method_3(item4.Key);
				LVAssignedDetached.Items.Add(darkListItem4);
			}
		}
		else
		{
			foreach (DarkListItem item5 in ListView_AssignedAssets.Items)
			{
				string text = Conversions.ToString(item5.Tag);
				item5.Text = Conversions.ToString(myUnit.GetAssignedRoster_Readonly()[text]) + "x " + method_3(text);
			}
			int num = -1;
			if (ListView_ActualAssets.SelectedIndices.Count > 0)
			{
				num = ListView_ActualAssets.SelectedIndices[0];
			}
			ListView_ActualAssets.Items.Clear();
			foreach (KeyValuePair<string, (ActiveUnit, int)> item6 in myUnit.GetActualRoster_Readonly())
			{
				DarkListItem darkListItem5 = new DarkListItem();
				darkListItem5.Tag = item6.Key;
				darkListItem5.Text = Conversions.ToString(item6.Value.Item2) + "x " + method_3(item6.Key);
				ListView_ActualAssets.Items.Add(darkListItem5);
			}
			Dictionary<string, int> actualDetachedRoster2 = myUnit.GetActualDetachedRoster();
			if (actualDetachedRoster2 != null)
			{
				foreach (KeyValuePair<string, int> item7 in actualDetachedRoster2)
				{
					DarkListItem darkListItem6 = new DarkListItem();
					darkListItem6.Tag = null;
					darkListItem6.Text = "[DETACHED] " + Conversions.ToString(item7.Value) + "x " + method_3(item7.Key);
					ListView_ActualAssets.Items.Add(darkListItem6);
				}
			}
			if (num >= 0 && num < ListView_ActualAssets.Items.Count)
			{
				ListView_ActualAssets.SelectItem(num);
				((Control)ListView_ActualAssets).Select();
			}
			foreach (DarkListItem item8 in LVAssignedDetached.Items)
			{
				string text2 = Conversions.ToString(item8.Tag);
				item8.Text = Conversions.ToString(myUnit.GetAssignedDetachedRoster_Readonly()[text2]) + "x " + method_3(text2);
			}
		}
		((Control)ListView_ActualAssets).MouseMove += new MouseEventHandler(method_4);
		RefreshRosterCharacteristics();
	}

	private string method_3(string string_0)
	{
		string text = string_0.Split(new char[1] { '_' })[0];
		if (Operators.CompareString(text, "Facility", true) != 0)
		{
			int theType;
			if (Operators.CompareString(text, "Vehicle", true) != 0)
			{
				if (Operators.CompareString(text, "GroundUnit", true) != 0)
				{
					return "ERROR";
				}
				theType = 8;
			}
			else
			{
				theType = 8;
			}
			return DBFunctions.GetActiveUnitName((GlobalVariables.ActiveUnitType)theType, Conversions.ToInteger(string_0.Split(new char[1] { '_' })[1]), Client.CurrentScenario.DBConnection);
		}
		return DBFunctions.GetActiveUnitName(GlobalVariables.ActiveUnitType.Facility, Conversions.ToInteger(string_0.Split(new char[1] { '_' })[1]), Client.CurrentScenario.DBConnection);
	}

	public void RefreshRosterCharacteristics()
	{
		LV_Defence.Items.Clear();
		LV_Offence.Items.Clear();
		LV_General.Items.Clear();
		LV_General.Items.Add(new DarkListItem("Hit Points " + myUnit.GetHitPoints()));
		LV_General.Items.Add(new DarkListItem("Speed (Kts) " + myUnit.Kinematics.GetMaximumSpeed(0f, ActiveUnit.Throttle.MaxPossibleThrottle, ValidateAndFixAltitude: false, ConsiderDamage: false).ToString("0.0")));
		float[] array = new float[Enum.GetValues(typeof(CombatPowerType)).Length - 1 + 1];
		myUnit.GetCombatPower(array);
		int num = array.Length - 1;
		for (int i = 0; i <= num; i++)
		{
			LV_Offence.Items.Add(new DarkListItem(Helper.GetReadableEnum((CombatPowerType)i) + " " + array[i].ToString("0.##") + " DP"));
		}
		float antiAirPower = myUnit.GetAntiAirPower();
		if (antiAirPower > 0f)
		{
			LV_Offence.Items.Add(new DarkListItem("Anti-Air (MANPADs) " + antiAirPower.ToString("0.##")));
		}
		myUnit.GetCombatProtection(array);
		int num2 = array.Length - 1;
		for (int j = 0; j <= num2; j++)
		{
			LV_Defence.Items.Add(new DarkListItem(Helper.GetReadableEnum((CombatPowerType)j) + " " + (array[j] * 100f).ToString("0.##") + "%"));
		}
	}

	public string GetTooltipDescription_RosterItem((ActiveUnit, int) item)
	{
		ActiveUnit item2 = item.Item1;
		IAGUInteractable iAGUInteractable = (IAGUInteractable)item2;
		string text = "";
		text = text + "Hit Points (per unit) " + Conversions.ToString(AggregateGroundUnit.GetUnitHitPoint(item2) * (float)item.Item2) + " (" + Conversions.ToString(AggregateGroundUnit.GetUnitHitPoint(item2)) + ")\r\n";
		text = text + "Speed " + item2.Kinematics.GetMaximumSpeed(0f, ActiveUnit.Throttle.MaxPossibleThrottle, ValidateAndFixAltitude: false, ConsiderDamage: false).ToString("0.0") + " kts\r\n";
		float[] array = new float[Enum.GetValues(typeof(CombatPowerType)).Length - 1 + 1];
		text += "\r\nCOMBAT POWER (Per unit)\r\n";
		iAGUInteractable.GetCombatPower(array);
		int num = array.Length - 1;
		for (int i = 0; i <= num; i++)
		{
			text = text + Helper.GetReadableEnum((CombatPowerType)i) + " " + (array[i] * (float)item.Item2).ToString("0.0") + " DP (" + array[i].ToString("0.0") + ")\r\n";
		}
		text += "\r\nDEFENSE POWER (Per unit)\r\n";
		iAGUInteractable.GetCombatProtection(array);
		int num2 = array.Length - 1;
		for (int j = 0; j <= num2; j++)
		{
			text = text + Helper.GetReadableEnum((CombatPowerType)j) + " " + array[j] * (float)item.Item2 + " DP (" + array[j].ToString("0.0") + ")\r\n";
		}
		float antiAirPower = iAGUInteractable.GetAntiAirPower();
		if (antiAirPower > 0f)
		{
			text += "\r\nANTI-AIR POWER (Per unit)";
			LV_Offence.Items.Add(new DarkListItem("Anti-Air (MANPADs) " + (antiAirPower * (float)item.Item2).ToString("0.0") + " (" + antiAirPower.ToString("0.0") + ")"));
		}
		return text;
	}

	private void method_4(object sender, MouseEventArgs e)
	{
		if (myUnit == null)
		{
			return;
		}
		DarkListView darkListView = (DarkListView)sender;
		DarkListItem darkListItem = method_5(darkListView, e.Location);
		if (darkListItem != null && darkListItem.Tag != null)
		{
			string tooltipDescription_RosterItem = GetTooltipDescription_RosterItem(myUnit.GetActualRoster_Readonly()[Conversions.ToString(darkListItem.Tag)]);
			if (Operators.CompareString(AGU_CONFIG.Instance.toolTip.GetToolTip((Control)(object)darkListView), tooltipDescription_RosterItem, true) != 0)
			{
				AGU_CONFIG.Instance.toolTip.SetToolTip((Control)(object)darkListView, tooltipDescription_RosterItem);
			}
		}
		else
		{
			AGU_CONFIG.Instance.toolTip.SetToolTip((Control)(object)darkListView, "");
		}
	}

	private DarkListItem method_5(DarkListView darkListView_2, Point point_0)
	{
		foreach (DarkListItem item in darkListView_2.Items)
		{
			if (item.Area.Contains(point_0))
			{
				return item;
			}
		}
		return null;
	}

	private void Button_SaveTemplate_Click(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Invalid comparison between Unknown and I4
		FD_ExportTemplate = new SaveFileDialog();
		((FileDialog)FD_ExportTemplate).InitialDirectory = AGU_CONFIG.HannibalDatabasePath;
		((FileDialog)FD_ExportTemplate).Filter = "Template file (*.template)|*.template|All Files (*.*)|*.*";
		if ((int)((CommonDialog)FD_ExportTemplate).ShowDialog() == 1)
		{
			new AggregateUnitTemplate(myUnit).SaveToFile(RebuildAGUatabase: true);
		}
	}

	private void method_6(object sender, EventArgs e)
	{
		method_7(null, null);
	}

	private void method_7(object sender, EventArgs e)
	{
		DarkListView darkListView = darkListView_1[((TabControl)TabControl_Assets).SelectedIndex];
		if (darkListView.SelectedItems.Count != 0 && darkListView.SelectedItems[0].Tag != null)
		{
			((Control)Button_RemoveUnit).Visible = true;
			((Control)DarkNumericUpDown1).Visible = true;
			string key = Conversions.ToString(darkListView.SelectedItems[0].Tag);
			switch (((TabControl)TabControl_Assets).SelectedIndex)
			{
			case 0:
				((NumericUpDown)DarkNumericUpDown1).Value = new decimal(myUnit.GetAssignedRoster_Readonly()[key]);
				break;
			case 1:
				((NumericUpDown)DarkNumericUpDown1).Value = new decimal(myUnit.GetAssignedDetachedRoster_Readonly()[key]);
				break;
			case 2:
				((NumericUpDown)DarkNumericUpDown1).Value = new decimal(myUnit.GetActualRoster_Readonly()[key].Item2);
				break;
			}
		}
		else
		{
			((Control)Button_RemoveUnit).Visible = false;
			((Control)DarkNumericUpDown1).Visible = false;
		}
	}

	private void method_8(object sender, EventArgs e)
	{
		try
		{
			DarkListView darkListView = darkListView_1[((TabControl)TabControl_Assets).SelectedIndex];
			if (darkListView.SelectedItems.Count != 0 && darkListView.SelectedItems[0].Tag != null)
			{
				((Control)DarkNumericUpDown1).Visible = true;
				string text = Conversions.ToString(darkListView.SelectedItems[0].Tag);
				switch (((TabControl)TabControl_Assets).SelectedIndex)
				{
				case 0:
					myUnit.GetAssignedRoster_Readonly()[text] = Convert.ToInt32(((NumericUpDown)DarkNumericUpDown1).Value);
					break;
				case 1:
					myUnit.GetAssignedDetachedRoster_Readonly()[text] = Convert.ToInt32(((NumericUpDown)DarkNumericUpDown1).Value);
					break;
				case 2:
					myUnit.SetActualRoster(text, Convert.ToInt32(((NumericUpDown)DarkNumericUpDown1).Value));
					break;
				}
				RefreshRosterList(ClearAndRebuild: false);
			}
			else
			{
				((Control)DarkNumericUpDown1).Visible = false;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void method_9()
	{
		if (myUnit == null)
		{
			return;
		}
		((TextBox)DarkTextBox1).Text = myUnit.Name;
		foreach (DarkDropdownItem item in DDL_Category.Items)
		{
			if (Conversions.ToInteger(item.Value) == (int)myUnit.MobileUnitCategory)
			{
				DDL_Category.SelectedItem = item;
				break;
			}
		}
		foreach (DarkDropdownItem item2 in DDL_Echelon.Items)
		{
			if (Conversions.ToInteger(item2.Value) == (int)myUnit.Echelon)
			{
				DDL_Echelon.SelectedItem = item2;
				break;
			}
		}
		((NumericUpDown)FrictionSelector).Value = new decimal(myUnit.FrictionModifier);
		RefreshRosterList(ClearAndRebuild: true);
		RefreshParentEchelon();
		if (!Information.IsNothing((object)myUnit.GC_LastCombatRound))
		{
			TB_Report.Text = myUnit.GC_LastCombatRound.ToString();
		}
	}

	private void Button_LoadTemplate_Click(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Invalid comparison between Unknown and I4
		FD_ImportTemplate = new OpenFileDialog();
		((FileDialog)FD_ImportTemplate).InitialDirectory = AGU_CONFIG.HannibalDatabasePath;
		((FileDialog)FD_ImportTemplate).Filter = "Template file (*.template)|*.template|All Files (*.*)|*.*";
		if ((int)((CommonDialog)FD_ImportTemplate).ShowDialog() == 1)
		{
			AggregateUnitTemplate aggregateUnitTemplate = AggregateUnitTemplate.LoadFromFile(Path.GetFileNameWithoutExtension(((FileDialog)FD_ImportTemplate).FileName), bool_0: true);
			if (aggregateUnitTemplate != null)
			{
				myUnit = aggregateUnitTemplate.ToAggregateUnit(Client.CurrentScenario);
			}
			method_9();
			Client.MustRefreshMainForm = true;
		}
	}

	private void method_10(object sender, EventArgs e)
	{
		DarkListView darkListView = darkListView_1[((TabControl)TabControl_Assets).SelectedIndex];
		if (darkListView.SelectedItems.Count != 0 && darkListView.SelectedItems[0].Tag != null)
		{
			string text = Conversions.ToString(darkListView.SelectedItems[0].Tag);
			switch (((TabControl)TabControl_Assets).SelectedIndex)
			{
			case 0:
				myUnit.GetAssignedRoster_Readonly().Remove(text);
				break;
			case 1:
				myUnit.GetAssignedDetachedRoster_Readonly().Remove(text);
				break;
			case 2:
				myUnit.SetActualRoster(text, 0);
				break;
			}
			RefreshRosterList(ClearAndRebuild: true);
		}
	}

	private void method_11(object sender, EventArgs e)
	{
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		if (myUnit.Echelon != AggregateGroundUnit.GroundEchelonLevel.Undefined)
		{
			if (myUnit.MobileUnitCategory == IMobileGroundUnit._MobileUnitCategory.None)
			{
				DarkMessageBox.ShowError("You must set a category for this unit", "Error");
				return;
			}
			int currentUserAction;
			switch (Client.CurrentUserAction)
			{
			default:
				currentUserAction = 0;
				break;
			case Client.UserAction.EditingAggregateUnit:
				currentUserAction = 0;
				break;
			case Client.UserAction.AddingAggregateUnit:
			{
				Geopoint_Struct mapClickWorldPoint = MyProject.Forms.MainForm.MapClickWorldPoint;
				Client.CurrentScenario.AddAggregateUnit(myUnit, Client.CurrentSide, mapClickWorldPoint.Longitude, mapClickWorldPoint.Latitude);
				currentUserAction = 0;
				break;
			}
			}
			Client.CurrentUserAction = (Client.UserAction)currentUserAction;
			((Form)this).Close();
		}
		else
		{
			DarkMessageBox.ShowError("You must set an echelon level for this unit", "Error");
		}
	}

	private void method_12(object sender, EventArgs e)
	{
		Client.CurrentUserAction = Client.UserAction.None;
		((Form)this).Close();
	}

	private void method_13(object sender, EventArgs e)
	{
		myUnit.Name = ((TextBox)DarkTextBox1).Text;
	}

	private void method_14(object sender, EventArgs e)
	{
		if (DDL_Category.SelectedItem != null)
		{
			IMobileGroundUnit._MobileUnitCategory mobileUnitCategory = (IMobileGroundUnit._MobileUnitCategory)Conversions.ToInteger(DDL_Category.SelectedItem.Value);
			if (myUnit != null)
			{
				myUnit.MobileUnitCategory = mobileUnitCategory;
			}
		}
	}

	private void method_15(object sender, EventArgs e)
	{
		if (DDL_Echelon.SelectedItem != null)
		{
			AggregateGroundUnit.GroundEchelonLevel echelon = (AggregateGroundUnit.GroundEchelonLevel)Conversions.ToInteger(DDL_Echelon.SelectedItem.Value);
			if (myUnit != null)
			{
				myUnit.Echelon = echelon;
			}
		}
	}

	private void AggregateUnitEditor_FormClosing(object sender, FormClosingEventArgs e)
	{
		Client.CurrentUserAction = Client.UserAction.None;
		((Control)MyProject.Forms.MainForm).Enabled = true;
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void method_16(object sender, EventArgs e)
	{
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		myUnit.ClearActualRoster();
		foreach (KeyValuePair<string, int> item in myUnit.GetAssignedRoster_Readonly().ToList())
		{
			myUnit.AddOrRemoveActualRoster(item.Key, item.Value, AutomaticallyAlignAssignedRoster: true);
		}
		foreach (KeyValuePair<string, int> item2 in myUnit.GetAssignedDetachedRoster_Readonly().ToList())
		{
			myUnit.AddActualDetachedRoster(item2.Key, item2.Value);
		}
		DarkMessageBox.ShowInformation("Assets copied from assigned to actual roster", "Copy assets", DarkDialogButton.Close);
		RefreshRosterList(ClearAndRebuild: true);
	}

	private void AggregateUnitEditor_Shown(object sender, EventArgs e)
	{
		switch (Client.CurrentUserAction)
		{
		case Client.UserAction.EditingAggregateUnit:
			Button_PlaceUnit.Text = "FINISH";
			method_9();
			break;
		case Client.UserAction.AddingAggregateUnit:
			Button_PlaceUnit.Text = "PLACE UNIT";
			break;
		}
	}

	private void method_17(object sender, EventArgs e)
	{
		myUnit.FrictionModifier = Convert.ToSingle(((NumericUpDown)FrictionSelector).Value);
	}

	private void method_18(object sender, EventArgs e)
	{
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		List<ActiveUnit> SelectedUnits = new List<ActiveUnit>();
		List<Side> side = new List<Side> { Client.CurrentSide };
		Dictionary<UnitSelection.UnitSelectionConfig.Condition, bool> conditions = new Dictionary<UnitSelection.UnitSelectionConfig.Condition, bool> { 
		{
			UnitSelection.UnitSelectionConfig.Condition.IsAggregateGroundUnit_HQ,
			true
		} };
		List<ReferencePoint> list_ = null;
		List<Zone> SelectedStandardZones = null;
		UnitSelection.CallDialog(side, MultipleSelection: false, ref SelectedUnits, ref list_, ref SelectedStandardZones, new UnitSelection.UnitSelectionConfig(conditions), ShowDeleteButton: false);
		if (SelectedUnits.Count > 0)
		{
			AggregateGroundUnit aggregateGroundUnit = (AggregateGroundUnit)SelectedUnits.ElementAt(0);
			if (aggregateGroundUnit != myUnit && aggregateGroundUnit.Echelon >= myUnit.Echelon)
			{
				myUnit.HQ = aggregateGroundUnit;
			}
			else
			{
				DarkMessageBox.ShowError("You must select a headquarters of equal or higher echelon.", "Error");
			}
		}
		else
		{
			myUnit.HQ = null;
		}
		RefreshParentEchelon();
	}

	public void RefreshParentEchelon()
	{
		if (myUnit.HQ != null)
		{
			ButtonParentEchelon.Text = myUnit.HQ.Name + "(" + myUnit.HQ.Echelon.ToString() + ")";
		}
		else
		{
			ButtonParentEchelon.Text = "Select HQ";
		}
	}

	private void method_19(object sender, EventArgs e)
	{
		try
		{
			myUnit.Order_Fallback(10f);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void method_20(object sender, EventArgs e)
	{
		myUnit.DEBUG_DISPLAYMASK("frontline");
	}

	private void method_21(object sender, EventArgs e)
	{
		myUnit.DEBUG_DISPLAYMASK("");
	}

	private void method_22(object sender, EventArgs e)
	{
		myUnit.DEBUG_DISPLAYMASK("mobility");
	}

	private void method_23(object sender, EventArgs e)
	{
		if (myUnit != null)
		{
			myUnit.FrictionModifier = Convert.ToSingle(((NumericUpDown)FrictionSelector).Value);
		}
	}

	static AggregateUnitEditor()
	{
		Class72.smethod_20();
	}
}
