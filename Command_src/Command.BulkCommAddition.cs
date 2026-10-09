using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Command_Core;
using Command_Core.DAL;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class BulkCommAddition : DarkSecondaryFormBase
{
	[CompilerGenerated]
	internal sealed class _Closure$__90-0
	{
		public List<DarkListItem> $VB$Local_newlySelectedItems;

		public BulkCommAddition $VB$Me;

		public _Closure$__90-0(_Closure$__90-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_newlySelectedItems = arg0.$VB$Local_newlySelectedItems;
			}
		}

		[SpecialName]
		internal void _Lambda$__1()
		{
			$VB$Me.method_5($VB$Local_newlySelectedItems);
		}

		static _Closure$__90-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__91-0
	{
		public List<DarkListItem> $VB$Local_items;

		public Color $VB$Local_NotTooFlashyGreen;

		public BulkCommAddition $VB$Me;

		public _Closure$__91-0(_Closure$__91-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_items = arg0.$VB$Local_items;
				$VB$Local_NotTooFlashyGreen = arg0.$VB$Local_NotTooFlashyGreen;
			}
		}

		[SpecialName]
		internal void _Lambda$__1()
		{
			foreach (DarkListItem item in $VB$Local_items)
			{
				item.TextColor = $VB$Local_NotTooFlashyGreen;
			}
			((Control)$VB$Me.DLV_Units).Refresh();
		}

		static _Closure$__91-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__91-1
	{
		public Color $VB$Local_c;

		public _Closure$__91-0 $VB$NonLocal_$VB$Closure_2;

		public _Closure$__91-1(_Closure$__91-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_c = arg0.$VB$Local_c;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			foreach (DarkListItem item in $VB$NonLocal_$VB$Closure_2.$VB$Local_items)
			{
				item.TextColor = $VB$Local_c;
			}
			((Control)$VB$NonLocal_$VB$Closure_2.$VB$Me.DLV_Units).Refresh();
		}

		static _Closure$__91-1()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("DLV_Units")]
	private DarkListView _DLV_Units;

	[CompilerGenerated]
	[AccessedThroughProperty("TLPCommList")]
	private TableLayoutPanel tableLayoutPanel_0;

	[AccessedThroughProperty("CB_OnlyEraAppropriate")]
	[CompilerGenerated]
	private DarkUICheckBox _CB_OnlyEraAppropriate;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_Find")]
	private DarkUITextBox _TB_Find;

	[CompilerGenerated]
	[AccessedThroughProperty("VListComm")]
	private VirtualCommList virtualCommList_0;

	[CompilerGenerated]
	[AccessedThroughProperty("DLV_CommsOnUnit")]
	private DarkListView _DLV_CommsOnUnit;

	[AccessedThroughProperty("btnAllUnits")]
	[CompilerGenerated]
	private DarkUIButton _btnAllUnits;

	[CompilerGenerated]
	[AccessedThroughProperty("btn_AddComms")]
	private DarkUIButton _btn_AddComms;

	[AccessedThroughProperty("btnApply")]
	[CompilerGenerated]
	private DarkUIButton _btnApply;

	private List<ActiveUnit> list_0;

	public List<ActiveUnit> SelectedUnits;

	public List<CommDevice> AllCommDevices;

	public List<CommDevice> SelectedComms;

	public Dictionary<ActiveUnit, List<CommDevice>> DictUnitComms;

	private bool bool_2;

	private DataTable dataTable_0;

	private DataView dataView_0;

	private bool bool_3;

	private bool bool_4;

	private Dictionary<int, int> dictionary_0;

	private bool bool_5;

	private ActiveUnit activeUnit_0;

	[field: AccessedThroughProperty("TableLayoutPanel1")]
	internal virtual TableLayoutPanel TableLayoutPanel1 { get; set; }

	[field: AccessedThroughProperty("PNL_UnitsHeader")]
	internal virtual TableLayoutPanel PNL_UnitsHeader { get; set; }

	[field: AccessedThroughProperty("lblUnits")]
	internal virtual DarkLabel lblUnits { get; set; }

	internal virtual DarkListView DLV_Units
	{
		[CompilerGenerated]
		get
		{
			return _DLV_Units;
		}
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_3;
			DarkListView darkListView = _DLV_Units;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged -= value2;
			}
			_DLV_Units = value;
			darkListView = _DLV_Units;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged += value2;
			}
		}
	}

	internal virtual TableLayoutPanel TLPCommList
	{
		[CompilerGenerated]
		get
		{
			return tableLayoutPanel_0;
		}
		[CompilerGenerated]
		set
		{
			tableLayoutPanel_0 = value;
		}
	}

	[field: AccessedThroughProperty("PNL_CommHeader")]
	internal virtual TableLayoutPanel PNL_CommHeader { get; set; }

	internal virtual DarkUICheckBox CB_OnlyEraAppropriate
	{
		[CompilerGenerated]
		get
		{
			return _CB_OnlyEraAppropriate;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_15;
			DarkUICheckBox darkUICheckBox = _CB_OnlyEraAppropriate;
			if (darkUICheckBox != null)
			{
				((CheckBox)darkUICheckBox).CheckedChanged -= eventHandler;
			}
			_CB_OnlyEraAppropriate = value;
			darkUICheckBox = _CB_OnlyEraAppropriate;
			if (darkUICheckBox != null)
			{
				((CheckBox)darkUICheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("CB_FilterByType")]
	internal virtual DarkCheckBox CB_FilterByType { get; set; }

	internal virtual DarkUITextBox TB_Find
	{
		[CompilerGenerated]
		get
		{
			return _TB_Find;
		}
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = method_14;
			DarkUITextBox darkUITextBox = _TB_Find;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged -= value2;
			}
			_TB_Find = value;
			darkUITextBox = _TB_Find;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged += value2;
			}
		}
	}

	internal virtual VirtualCommList VListComm
	{
		[CompilerGenerated]
		get
		{
			return virtualCommList_0;
		}
		[CompilerGenerated]
		set
		{
			virtualCommList_0 = value;
		}
	}

	[field: AccessedThroughProperty("PNL_SummaryHeader")]
	internal virtual Panel PNL_SummaryHeader { get; set; }

	[field: AccessedThroughProperty("lblSummary")]
	internal virtual DarkLabel lblSummary { get; set; }

	internal virtual DarkListView DLV_CommsOnUnit
	{
		[CompilerGenerated]
		get
		{
			return _DLV_CommsOnUnit;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			MouseEventHandler val = new MouseEventHandler(method_18);
			DarkListView darkListView = _DLV_CommsOnUnit;
			if (darkListView != null)
			{
				((Control)darkListView).MouseClick -= val;
			}
			_DLV_CommsOnUnit = value;
			darkListView = _DLV_CommsOnUnit;
			if (darkListView != null)
			{
				((Control)darkListView).MouseClick += val;
			}
		}
	}

	[field: AccessedThroughProperty("PNL_Buttons")]
	internal virtual TableLayoutPanel PNL_Buttons { get; set; }

	internal virtual DarkUIButton btnAllUnits
	{
		[CompilerGenerated]
		get
		{
			return _btnAllUnits;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_4;
			DarkUIButton darkUIButton = _btnAllUnits;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_btnAllUnits = value;
			darkUIButton = _btnAllUnits;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton btn_AddComms
	{
		[CompilerGenerated]
		get
		{
			return _btn_AddComms;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_16;
			DarkUIButton darkUIButton = _btn_AddComms;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_btn_AddComms = value;
			darkUIButton = _btn_AddComms;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton btnApply
	{
		[CompilerGenerated]
		get
		{
			return _btnApply;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_21;
			DarkUIButton darkUIButton = _btnApply;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_btnApply = value;
			darkUIButton = _btnApply;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
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
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Expected O, but got Unknown
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected O, but got Unknown
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Expected O, but got Unknown
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Expected O, but got Unknown
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Expected O, but got Unknown
		//IL_029d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a7: Expected O, but got Unknown
		//IL_02eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f5: Expected O, but got Unknown
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		//IL_036d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0377: Expected O, but got Unknown
		//IL_03b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c1: Expected O, but got Unknown
		//IL_040c: Unknown result type (might be due to invalid IL or missing references)
		//IL_047f: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f2: Expected O, but got Unknown
		//IL_0567: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ba: Expected O, but got Unknown
		//IL_05cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d6: Expected O, but got Unknown
		//IL_05e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f2: Expected O, but got Unknown
		//IL_0637: Unknown result type (might be due to invalid IL or missing references)
		//IL_0641: Expected O, but got Unknown
		//IL_0653: Unknown result type (might be due to invalid IL or missing references)
		//IL_065d: Expected O, but got Unknown
		//IL_06d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e3: Expected O, but got Unknown
		//IL_073b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0745: Expected O, but got Unknown
		//IL_07b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c0: Expected O, but got Unknown
		//IL_086e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0878: Expected O, but got Unknown
		//IL_08cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a3d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a97: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa1: Expected O, but got Unknown
		//IL_0aec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b63: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bde: Unknown result type (might be due to invalid IL or missing references)
		//IL_0be8: Expected O, but got Unknown
		//IL_0bfa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c04: Expected O, but got Unknown
		//IL_0c16: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c20: Expected O, but got Unknown
		//IL_0c95: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ccc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cd6: Expected O, but got Unknown
		//IL_0d42: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d63: Unknown result type (might be due to invalid IL or missing references)
		//IL_0df7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e18: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ecd: Unknown result type (might be due to invalid IL or missing references)
		TableLayoutPanel1 = new TableLayoutPanel();
		PNL_UnitsHeader = new TableLayoutPanel();
		lblUnits = new DarkLabel();
		DLV_Units = new DarkListView();
		TLPCommList = new TableLayoutPanel();
		PNL_CommHeader = new TableLayoutPanel();
		CB_OnlyEraAppropriate = new DarkUICheckBox();
		CB_FilterByType = new DarkCheckBox();
		TB_Find = new DarkUITextBox();
		VListComm = new VirtualCommList();
		PNL_SummaryHeader = new Panel();
		lblSummary = new DarkLabel();
		DLV_CommsOnUnit = new DarkListView();
		PNL_Buttons = new TableLayoutPanel();
		btnAllUnits = new DarkUIButton();
		btn_AddComms = new DarkUIButton();
		btnApply = new DarkUIButton();
		((Control)TableLayoutPanel1).SuspendLayout();
		((Control)PNL_UnitsHeader).SuspendLayout();
		((Control)TLPCommList).SuspendLayout();
		((Control)PNL_CommHeader).SuspendLayout();
		((Control)PNL_SummaryHeader).SuspendLayout();
		((Control)PNL_Buttons).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)TableLayoutPanel1).BackColor = Color.FromArgb(38, 38, 38);
		TableLayoutPanel1.ColumnCount = 3;
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle((SizeType)2, 25f));
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle((SizeType)2, 45f));
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle((SizeType)2, 30f));
		TableLayoutPanel1.Controls.Add((Control)(object)PNL_UnitsHeader, 0, 0);
		TableLayoutPanel1.Controls.Add((Control)(object)DLV_Units, 0, 1);
		TableLayoutPanel1.Controls.Add((Control)(object)TLPCommList, 1, 0);
		TableLayoutPanel1.Controls.Add((Control)(object)PNL_SummaryHeader, 2, 0);
		TableLayoutPanel1.Controls.Add((Control)(object)DLV_CommsOnUnit, 2, 1);
		TableLayoutPanel1.Controls.Add((Control)(object)PNL_Buttons, 0, 2);
		((Control)TableLayoutPanel1).Dock = (DockStyle)5;
		((Control)TableLayoutPanel1).Location = new Point(0, 0);
		((Control)TableLayoutPanel1).Name = "TableLayoutPanel1";
		((Control)TableLayoutPanel1).Padding = new Padding(8);
		TableLayoutPanel1.RowCount = 3;
		TableLayoutPanel1.RowStyles.Add(new RowStyle((SizeType)1, 48f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle((SizeType)2, 100f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle((SizeType)1, 48f));
		((Control)TableLayoutPanel1).Size = new Size(1400, 800);
		((Control)TableLayoutPanel1).TabIndex = 0;
		PNL_UnitsHeader.ColumnCount = 1;
		PNL_UnitsHeader.ColumnStyles.Add(new ColumnStyle((SizeType)2, 100f));
		PNL_UnitsHeader.Controls.Add((Control)(object)lblUnits, 0, 0);
		((Control)PNL_UnitsHeader).Dock = (DockStyle)5;
		((Control)PNL_UnitsHeader).Location = new Point(8, 8);
		((Control)PNL_UnitsHeader).Margin = new Padding(0, 0, 4, 4);
		((Control)PNL_UnitsHeader).Name = "PNL_UnitsHeader";
		PNL_UnitsHeader.RowCount = 1;
		PNL_UnitsHeader.RowStyles.Add(new RowStyle((SizeType)2, 100f));
		((Control)PNL_UnitsHeader).Size = new Size(342, 44);
		((Control)PNL_UnitsHeader).TabIndex = 0;
		((Control)lblUnits).Dock = (DockStyle)5;
		((Control)lblUnits).Font = new Font("Segoe UI", 9f);
		((Control)lblUnits).ForeColor = Color.FromArgb(180, 180, 180);
		((Control)lblUnits).Location = new Point(3, 0);
		((Control)lblUnits).Name = "lblUnits";
		((Control)lblUnits).Padding = new Padding(4, 0, 0, 0);
		((Control)lblUnits).Size = new Size(336, 44);
		((Control)lblUnits).TabIndex = 0;
		((Label)lblUnits).Text = "UNITS WITH NO COMMS";
		((Label)lblUnits).TextAlign = (ContentAlignment)32;
		((Control)DLV_Units).Dock = (DockStyle)5;
		((Control)DLV_Units).Location = new Point(8, 56);
		((Control)DLV_Units).Margin = new Padding(0, 0, 4, 4);
		((Control)DLV_Units).Name = "DLV_Units";
		DLV_Units.RelatedInfos = null;
		((Control)DLV_Units).Size = new Size(342, 684);
		((Control)DLV_Units).TabIndex = 0;
		TLPCommList.ColumnCount = 1;
		TLPCommList.ColumnStyles.Add(new ColumnStyle((SizeType)2, 100f));
		TLPCommList.Controls.Add((Control)(object)PNL_CommHeader, 0, 0);
		TLPCommList.Controls.Add((Control)(object)TB_Find, 0, 1);
		TLPCommList.Controls.Add((Control)(object)VListComm, 0, 2);
		((Control)TLPCommList).Dock = (DockStyle)5;
		((Control)TLPCommList).Location = new Point(358, 8);
		((Control)TLPCommList).Margin = new Padding(4, 0, 4, 4);
		((Control)TLPCommList).Name = "TLPCommList";
		TLPCommList.RowCount = 3;
		TableLayoutPanel1.SetRowSpan((Control)(object)TLPCommList, 2);
		TLPCommList.RowStyles.Add(new RowStyle((SizeType)1, 48f));
		TLPCommList.RowStyles.Add(new RowStyle((SizeType)1, 36f));
		TLPCommList.RowStyles.Add(new RowStyle((SizeType)2, 100f));
		((Control)TLPCommList).Size = new Size(614, 732);
		((Control)TLPCommList).TabIndex = 9;
		PNL_CommHeader.ColumnCount = 2;
		PNL_CommHeader.ColumnStyles.Add(new ColumnStyle((SizeType)2, 50f));
		PNL_CommHeader.ColumnStyles.Add(new ColumnStyle((SizeType)2, 50f));
		PNL_CommHeader.Controls.Add((Control)(object)CB_OnlyEraAppropriate, 0, 0);
		PNL_CommHeader.Controls.Add((Control)(object)CB_FilterByType, 1, 0);
		((Control)PNL_CommHeader).Dock = (DockStyle)5;
		((Control)PNL_CommHeader).Location = new Point(3, 3);
		((Control)PNL_CommHeader).Name = "PNL_CommHeader";
		PNL_CommHeader.RowCount = 1;
		PNL_CommHeader.RowStyles.Add(new RowStyle((SizeType)2, 100f));
		((Control)PNL_CommHeader).Size = new Size(608, 42);
		((Control)PNL_CommHeader).TabIndex = 0;
		((CheckBox)CB_OnlyEraAppropriate).Checked = true;
		((CheckBox)CB_OnlyEraAppropriate).CheckState = (CheckState)1;
		((Control)CB_OnlyEraAppropriate).Dock = (DockStyle)5;
		((Control)CB_OnlyEraAppropriate).Font = new Font("Segoe UI", 8.5f);
		((Control)CB_OnlyEraAppropriate).Location = new Point(3, 3);
		((Control)CB_OnlyEraAppropriate).Name = "CB_OnlyEraAppropriate";
		((Control)CB_OnlyEraAppropriate).Size = new Size(298, 36);
		((Control)CB_OnlyEraAppropriate).TabIndex = 6;
		((ButtonBase)CB_OnlyEraAppropriate).Text = "Era Appropriate Only";
		((Control)CB_FilterByType).Dock = (DockStyle)5;
		((Control)CB_FilterByType).Font = new Font("Segoe UI", 8.5f);
		((Control)CB_FilterByType).Location = new Point(307, 3);
		((Control)CB_FilterByType).Name = "CB_FilterByType";
		((Control)CB_FilterByType).Size = new Size(298, 36);
		((Control)CB_FilterByType).TabIndex = 17;
		((ButtonBase)CB_FilterByType).Text = "Filter by type";
		TB_Find.AutoCompleteCustomSource = null;
		TB_Find.AutoCompleteMode = (AutoCompleteMode)0;
		TB_Find.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TB_Find).BackColor = Color.Transparent;
		((Control)TB_Find).Dock = (DockStyle)5;
		TB_Find.Font = new Font("Segoe UI", 9f);
		((Control)TB_Find).ForeColor = Color.FromArgb(189, 189, 189);
		TB_Find.Image = null;
		TB_Find.Lines = null;
		((Control)TB_Find).Location = new Point(0, 50);
		((Control)TB_Find).Margin = new Padding(0, 2, 0, 2);
		TB_Find.MaxLength = 32767;
		TB_Find.Multiline = false;
		((Control)TB_Find).Name = "TB_Find";
		TB_Find.ReadOnly = false;
		TB_Find.ScrollBars = (ScrollBars)0;
		TB_Find.SelectionStart = 0;
		((Control)TB_Find).Size = new Size(614, 32);
		((Control)TB_Find).TabIndex = 16;
		TB_Find.TextAlign = (HorizontalAlignment)0;
		TB_Find.UseSystemPasswordChar = false;
		TB_Find.WatermarkText = "Search comm devices...";
		TB_Find.WordWrap = false;
		((Control)VListComm).BackColor = Color.FromArgb(45, 45, 48);
		((Control)VListComm).Dock = (DockStyle)5;
		((Control)VListComm).Location = new Point(0, 84);
		((Control)VListComm).Margin = new Padding(0);
		((Control)VListComm).Name = "VListComm";
		((Control)VListComm).Size = new Size(614, 648);
		((Control)VListComm).TabIndex = 18;
		((Control)PNL_SummaryHeader).Controls.Add((Control)(object)lblSummary);
		((Control)PNL_SummaryHeader).Dock = (DockStyle)5;
		((Control)PNL_SummaryHeader).Location = new Point(980, 8);
		((Control)PNL_SummaryHeader).Margin = new Padding(4, 0, 0, 4);
		((Control)PNL_SummaryHeader).Name = "PNL_SummaryHeader";
		((Control)PNL_SummaryHeader).Size = new Size(412, 44);
		((Control)PNL_SummaryHeader).TabIndex = 10;
		((Control)lblSummary).Dock = (DockStyle)5;
		((Control)lblSummary).Font = new Font("Segoe UI", 9f);
		((Control)lblSummary).ForeColor = Color.FromArgb(180, 180, 180);
		((Control)lblSummary).Location = new Point(0, 0);
		((Control)lblSummary).Name = "lblSummary";
		((Control)lblSummary).Padding = new Padding(4, 0, 0, 0);
		((Control)lblSummary).Size = new Size(412, 44);
		((Control)lblSummary).TabIndex = 0;
		((Label)lblSummary).Text = "ASSIGNED COMMS";
		((Label)lblSummary).TextAlign = (ContentAlignment)32;
		((Control)DLV_CommsOnUnit).Dock = (DockStyle)5;
		((Control)DLV_CommsOnUnit).Location = new Point(980, 56);
		((Control)DLV_CommsOnUnit).Margin = new Padding(4, 0, 0, 4);
		((Control)DLV_CommsOnUnit).Name = "DLV_CommsOnUnit";
		DLV_CommsOnUnit.RelatedInfos = null;
		((Control)DLV_CommsOnUnit).Size = new Size(412, 684);
		((Control)DLV_CommsOnUnit).TabIndex = 2;
		PNL_Buttons.ColumnCount = 3;
		TableLayoutPanel1.SetColumnSpan((Control)(object)PNL_Buttons, 3);
		PNL_Buttons.ColumnStyles.Add(new ColumnStyle((SizeType)2, 25f));
		PNL_Buttons.ColumnStyles.Add(new ColumnStyle((SizeType)2, 45f));
		PNL_Buttons.ColumnStyles.Add(new ColumnStyle((SizeType)2, 30f));
		PNL_Buttons.Controls.Add((Control)(object)btnAllUnits, 0, 0);
		PNL_Buttons.Controls.Add((Control)(object)btn_AddComms, 1, 0);
		PNL_Buttons.Controls.Add((Control)(object)btnApply, 2, 0);
		((Control)PNL_Buttons).Dock = (DockStyle)5;
		((Control)PNL_Buttons).Location = new Point(8, 748);
		((Control)PNL_Buttons).Margin = new Padding(0, 4, 0, 0);
		((Control)PNL_Buttons).Name = "PNL_Buttons";
		PNL_Buttons.RowCount = 1;
		PNL_Buttons.RowStyles.Add(new RowStyle((SizeType)2, 100f));
		((Control)PNL_Buttons).Size = new Size(1384, 44);
		((Control)PNL_Buttons).TabIndex = 11;
		((Control)btnAllUnits).Dock = (DockStyle)5;
		((Control)btnAllUnits).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)btnAllUnits).Location = new Point(0, 0);
		((Control)btnAllUnits).Margin = new Padding(0, 0, 4, 0);
		((Control)btnAllUnits).Name = "btnAllUnits";
		((Control)btnAllUnits).Padding = new Padding(5);
		btnAllUnits.RoundRadius = 0;
		((Control)btnAllUnits).Size = new Size(342, 44);
		((Control)btnAllUnits).TabIndex = 8;
		btnAllUnits.Text = "Select all copies of this unit";
		((Control)btn_AddComms).Dock = (DockStyle)5;
		((Control)btn_AddComms).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)btn_AddComms).Location = new Point(350, 0);
		((Control)btn_AddComms).Margin = new Padding(4, 0, 4, 0);
		((Control)btn_AddComms).Name = "btn_AddComms";
		((Control)btn_AddComms).Padding = new Padding(5);
		btn_AddComms.RoundRadius = 0;
		((Control)btn_AddComms).Size = new Size(614, 44);
		((Control)btn_AddComms).TabIndex = 4;
		btn_AddComms.Text = "Add Comms";
		((Control)btnApply).Dock = (DockStyle)5;
		((Control)btnApply).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)btnApply).Location = new Point(972, 0);
		((Control)btnApply).Margin = new Padding(4, 0, 0, 0);
		((Control)btnApply).Name = "btnApply";
		((Control)btnApply).Padding = new Padding(5);
		btnApply.RoundRadius = 0;
		((Control)btnApply).Size = new Size(412, 44);
		((Control)btnApply).TabIndex = 3;
		btnApply.Text = "Apply";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(10f, 25f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(1400, 800);
		((Control)this).Controls.Add((Control)(object)TableLayoutPanel1);
		((Form)this).MinimumSize = new Size(900, 600);
		((Control)this).Name = "BulkCommAddition";
		((Form)this).Text = "Bulk Comm Assignment";
		((Control)TableLayoutPanel1).ResumeLayout(false);
		((Control)PNL_UnitsHeader).ResumeLayout(false);
		((Control)TLPCommList).ResumeLayout(false);
		((Control)PNL_CommHeader).ResumeLayout(false);
		((Control)PNL_SummaryHeader).ResumeLayout(false);
		((Control)PNL_Buttons).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
	}

	public BulkCommAddition()
	{
		((Form)this).Load += BulkCommAddition_Load;
		((Control)this).VisibleChanged += BulkCommAddition_VisibleChanged;
		list_0 = new List<ActiveUnit>();
		SelectedUnits = new List<ActiveUnit>();
		AllCommDevices = new List<CommDevice>();
		SelectedComms = new List<CommDevice>();
		DictUnitComms = new Dictionary<ActiveUnit, List<CommDevice>>();
		bool_2 = false;
		bool_3 = false;
		bool_4 = false;
		dictionary_0 = new Dictionary<int, int>();
		bool_5 = true;
		activeUnit_0 = null;
		InitializeComponent_1();
	}

	public BulkCommAddition(List<ActiveUnit> listTheUnitsWithNoComms)
	{
		((Form)this).Load += BulkCommAddition_Load;
		((Control)this).VisibleChanged += BulkCommAddition_VisibleChanged;
		list_0 = new List<ActiveUnit>();
		SelectedUnits = new List<ActiveUnit>();
		AllCommDevices = new List<CommDevice>();
		SelectedComms = new List<CommDevice>();
		DictUnitComms = new Dictionary<ActiveUnit, List<CommDevice>>();
		bool_2 = false;
		bool_3 = false;
		bool_4 = false;
		dictionary_0 = new Dictionary<int, int>();
		bool_5 = true;
		activeUnit_0 = null;
		bool_2 = true;
		list_0 = listTheUnitsWithNoComms;
		InitializeComponent_1();
		bool_2 = false;
	}

	private void BulkCommAddition_Load(object sender, EventArgs e)
	{
		VListComm.SelectionChanged += method_13;
	}

	private void BulkCommAddition_VisibleChanged(object sender, EventArgs e)
	{
		if (((Control)this).Visible)
		{
			method_2();
		}
	}

	private void method_2()
	{
		bool_2 = true;
		if (DLV_Units != null && DLV_Units.Items.Count > 0)
		{
			DLV_Units.Items.Clear();
		}
		foreach (ActiveUnit item in list_0)
		{
			if (item == null || item.IsGroup || (item.IsFacility && item.MaxSpeed == 0f && item.IsGroupMember() && !item.IsGroupLead()))
			{
				continue;
			}
			int num;
			string text;
			if (!DictUnitComms.ContainsKey(item))
			{
				num = 0;
			}
			else
			{
				num = ((DictUnitComms[item].Count > 0) ? 1 : 0);
				if (num != 0)
				{
					text = "☑ " + item.Name;
					goto IL_00d2;
				}
			}
			text = "☐ " + item.Name;
			goto IL_00d2;
			IL_00d2:
			string text2 = text;
			DarkListItem darkListItem = new DarkListItem(text2)
			{
				Tag = item
			};
			if (num != 0)
			{
				darkListItem.TextColor = Color.FromArgb(100, 220, 130);
			}
			DLV_Units.Items.Add(darkListItem);
		}
		bool_2 = false;
		if (DLV_Units == null || DLV_Units.Items == null || DLV_Units.Items.Count == 0)
		{
			((Control)this).Hide();
		}
	}

	private void method_3(object sender, EventArgs e)
	{
		bool_3 = true;
		SelectedUnits.Clear();
		if (DLV_Units.SelectedItems != null && DLV_Units.SelectedItems.Count > 0)
		{
			foreach (DarkListItem selectedItem in DLV_Units.SelectedItems)
			{
				ActiveUnit item = (ActiveUnit)selectedItem.Tag;
				SelectedUnits.Add(item);
			}
		}
		method_6();
	}

	private void method_4(object sender, EventArgs e)
	{
		_Closure$__90-0 arg = default(_Closure$__90-0);
		_Closure$__90-0 CS$<>8__locals6 = new _Closure$__90-0(arg);
		CS$<>8__locals6.$VB$Me = this;
		if (SelectedUnits.Count == 0)
		{
			return;
		}
		HashSet<int> hashSet = new HashSet<int>(SelectedUnits.Select([SpecialName] (ActiveUnit u) => u.DBID));
		List<int> list = new List<int>();
		CS$<>8__locals6.$VB$Local_newlySelectedItems = new List<DarkListItem>();
		int num = DLV_Units.Items.Count - 1;
		for (int num2 = 0; num2 <= num; num2++)
		{
			ActiveUnit activeUnit = (ActiveUnit)DLV_Units.Items[num2].Tag;
			if (hashSet.Contains(activeUnit.DBID))
			{
				list.Add(num2);
				if (!SelectedUnits.Contains(activeUnit))
				{
					CS$<>8__locals6.$VB$Local_newlySelectedItems.Add(DLV_Units.Items[num2]);
				}
			}
		}
		DLV_Units.SelectedIndices.Clear();
		foreach (int item in list)
		{
			DLV_Units.SelectedIndices.Add(item);
		}
		SelectedUnits.Clear();
		foreach (int item2 in list)
		{
			SelectedUnits.Add((ActiveUnit)DLV_Units.Items[item2].Tag);
		}
		method_6();
		if (CS$<>8__locals6.$VB$Local_newlySelectedItems.Count > 0)
		{
			Task.Run([SpecialName] () =>
			{
				CS$<>8__locals6.$VB$Me.method_5(CS$<>8__locals6.$VB$Local_newlySelectedItems);
			});
		}
	}

	private void method_5(List<DarkListItem> list_1)
	{
		_Closure$__91-0 arg = default(_Closure$__91-0);
		_Closure$__91-0 CS$<>8__locals7 = new _Closure$__91-0(arg);
		CS$<>8__locals7.$VB$Me = this;
		CS$<>8__locals7.$VB$Local_items = list_1;
		CS$<>8__locals7.$VB$Local_NotTooFlashyGreen = Color.FromArgb(0, 200, 120);
		int num = 10;
		int millisecondsTimeout = 30;
		int num2 = 10;
		_Closure$__91-1 closure$__91- = default(_Closure$__91-1);
		for (int i = 1; i <= num2; i++)
		{
			closure$__91- = new _Closure$__91-1(closure$__91-);
			closure$__91-.$VB$NonLocal_$VB$Closure_2 = CS$<>8__locals7;
			byte alpha = (byte)(255 * i / num);
			closure$__91-.$VB$Local_c = Color.FromArgb(alpha, closure$__91-.$VB$NonLocal_$VB$Closure_2.$VB$Local_NotTooFlashyGreen);
			((Control)this).Invoke((Delegate)new VB$AnonymousDelegate_0(closure$__91-._Lambda$__0));
			Thread.Sleep(millisecondsTimeout);
		}
		((Control)this).Invoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
		{
			foreach (DarkListItem item in CS$<>8__locals7.$VB$Local_items)
			{
				item.TextColor = CS$<>8__locals7.$VB$Local_NotTooFlashyGreen;
			}
			((Control)CS$<>8__locals7.$VB$Me.DLV_Units).Refresh();
		}));
	}

	private void method_6()
	{
		method_7();
		method_8();
	}

	private void method_7()
	{
		SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
		dataTable_0 = DBFunctions.GetAllCommDevices(ref sqliteConnection_, Client.CurrentScenario);
	}

	private void method_8()
	{
		if (Operators.CompareString(TB_Find.Text, "", true) != 0)
		{
			method_9();
		}
		else if (bool_5)
		{
			if (!method_10())
			{
				method_11();
			}
		}
		else
		{
			method_11();
		}
	}

	private void method_9()
	{
		dataView_0 = new DataView(dataTable_0);
		dataView_0.RowFilter = "Name LIKE '%" + Misc.EscapeLikeValue(TB_Find.Text) + "%'";
		method_12(dataView_0);
	}

	private bool method_10()
	{
		int result;
		if (Client.SelectedUnit != null)
		{
			if (SelectedUnits.Count != 0)
			{
				List<GlobalVariables.TechGenerationClass> list = new List<GlobalVariables.TechGenerationClass>();
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					(string, string, string) operatorCountryAndYears = DBFunctions.GetOperatorCountryAndYears(selectedUnit.UnitType, selectedUnit.DBID, Client.CurrentScenario);
					List<GlobalVariables.TechGenerationClass> techGenForYear = ActiveUnit.GetTechGenForYear(int.Parse(operatorCountryAndYears.Item2), int.Parse(operatorCountryAndYears.Item3));
					if (techGenForYear.Count == 1 && techGenForYear[0] == GlobalVariables.TechGenerationClass.NotApplicable)
					{
						return false;
					}
					foreach (GlobalVariables.TechGenerationClass item2 in techGenForYear)
					{
						if (!list.Contains(item2))
						{
							list.Add(item2);
						}
					}
				}
				if (dataTable_0 == null)
				{
					method_7();
				}
				List<(int, string)> list2 = new List<(int, string)>();
				foreach (DataRowView item3 in dataTable_0.DefaultView)
				{
					int num = Conversions.ToInteger(item3["ID"]);
					ActiveUnit theParentPlatform = SelectedUnits.FirstOrDefault();
					CommDevice commDevice = DBFunctions.GetCommDevice(num, ref theParentPlatform);
					if (commDevice != null)
					{
						GlobalVariables.TechGenerationClass item = CommDevice.InferCommDeviceTechGeneration(commDevice);
						if (list.Contains(item))
						{
							list2.Add((num, item3["Name"].ToString()));
						}
					}
				}
				VListComm.LoadFilteredRows(list2);
				VListComm.RestoreSelections(dictionary_0);
				return true;
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	private void method_11()
	{
		if (dataTable_0 == null)
		{
			method_7();
		}
		if (bool_4)
		{
			bool_3 = true;
			DateTime t = DateTime.Now.AddMilliseconds(500.0);
			while (bool_4 && DateTime.Compare(DateTime.Now, t) < 0)
			{
				Application.DoEvents();
			}
		}
		((Control)this).Invoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
		{
			if (Operators.CompareString(TB_Find.Text, "", true) == 0)
			{
				method_12(dataTable_0.DefaultView);
			}
			else
			{
				method_9();
			}
		}));
	}

	private void method_12(DataView dataView_1)
	{
		VListComm.LoadRows(dataView_1);
		VListComm.RestoreSelections(dictionary_0);
	}

	private void method_13(int int_0, bool bool_6, int int_1)
	{
		if (bool_6)
		{
			dictionary_0[int_0] = int_1;
		}
		else
		{
			dictionary_0.Remove(int_0);
		}
	}

	private void method_14(object object_0)
	{
		method_8();
	}

	private void method_15(object sender, EventArgs e)
	{
		bool_5 = ((CheckBox)CB_OnlyEraAppropriate).Checked;
		if (!bool_2)
		{
			method_6();
		}
	}

	private void method_16(object sender, EventArgs e)
	{
		if (SelectedUnits.Count == 0 || dictionary_0.Count == 0)
		{
			return;
		}
		SelectedComms.Clear();
		Dictionary<int, int>.Enumerator enumerator = dictionary_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			KeyValuePair<int, int> current = enumerator.Current;
			int value = current.Value;
			for (int i = 1; i <= value; i++)
			{
				int key = current.Key;
				ActiveUnit theParentPlatform = SelectedUnits.First();
				CommDevice commDevice = DBFunctions.GetCommDevice(key, ref theParentPlatform);
				if (commDevice != null)
				{
					SelectedComms.Add(commDevice);
				}
			}
		}
		if (DictUnitComms == null)
		{
			DictUnitComms = new Dictionary<ActiveUnit, List<CommDevice>>();
		}
		List<ActiveUnit>.Enumerator enumerator2 = SelectedUnits.GetEnumerator();
		while (enumerator2.MoveNext())
		{
			ActiveUnit current2 = enumerator2.Current;
			if (!DictUnitComms.ContainsKey(current2))
			{
				DictUnitComms.Add(current2, new List<CommDevice>());
			}
			DictUnitComms[current2].Clear();
			DictUnitComms[current2] = new List<CommDevice>(SelectedComms);
		}
		method_17();
		method_2();
	}

	private void method_17()
	{
		int num;
		if (DLV_Units.Items == null)
		{
			num = 1;
		}
		else
		{
			DLV_CommsOnUnit.Items.Clear();
			num = 1;
		}
		int num2 = num;
		foreach (ActiveUnit key in DictUnitComms.Keys)
		{
			string text = "";
			int num3 = DictUnitComms[key].Count + 1;
			if (num3 > num2)
			{
				num2 = num3;
			}
			foreach (CommDevice item in DictUnitComms[key])
			{
				text = text + Environment.NewLine + item.Name;
			}
			DarkListItem darkListItem = new DarkListItem(key.Name + " COMMS:" + text);
			darkListItem.Tag = key;
			DLV_CommsOnUnit.Items.Add(darkListItem);
		}
		DLV_CommsOnUnit.ItemHeight = num2 * 16;
	}

	private void method_18(object sender, MouseEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected O, but got Unknown
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected O, but got Unknown
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.Button != 2097152)
		{
			return;
		}
		DarkListItem darkListItem = null;
		foreach (DarkListItem item in DLV_CommsOnUnit.Items)
		{
			if (item.Area.Contains(e.Location))
			{
				darkListItem = item;
				break;
			}
		}
		if (darkListItem != null)
		{
			activeUnit_0 = (ActiveUnit)darkListItem.Tag;
			ContextMenuStrip val = new ContextMenuStrip
			{
				BackColor = Color.FromArgb(45, 45, 48),
				ForeColor = Color.FromArgb(200, 200, 200),
				RenderMode = (ToolStripRenderMode)1
			};
			ToolStripMenuItem val2 = new ToolStripMenuItem("Remove comms from " + activeUnit_0.Name);
			((ToolStripItem)val2).Image = null;
			((ToolStripItem)val2).Click += method_19;
			((ToolStrip)val).Items.Add((ToolStripItem)(object)val2);
			ToolStripMenuItem val3 = new ToolStripMenuItem("Clear all assigned comms");
			((ToolStripItem)val3).ForeColor = Color.FromArgb(220, 80, 80);
			((ToolStripItem)val3).Click += method_20;
			((ToolStrip)val).Items.Add((ToolStripItem)(object)val3);
			((ToolStripDropDown)val).Show((Control)(object)DLV_CommsOnUnit, e.Location);
		}
	}

	private void method_19(object sender, EventArgs e)
	{
		if (activeUnit_0 == null)
		{
			return;
		}
		if (DictUnitComms.ContainsKey(activeUnit_0))
		{
			DictUnitComms.Remove(activeUnit_0);
		}
		foreach (DarkListItem item in DLV_Units.Items)
		{
			ActiveUnit activeUnit = (ActiveUnit)item.Tag;
			if (activeUnit == activeUnit_0)
			{
				SelectedUnits.Remove(activeUnit);
				break;
			}
		}
		activeUnit_0 = null;
		method_17();
		method_2();
	}

	private void method_20(object sender, EventArgs e)
	{
		DictUnitComms.Clear();
		SelectedUnits.Clear();
		activeUnit_0 = null;
		method_17();
		method_2();
	}

	private void method_21(object sender, EventArgs e)
	{
		foreach (ActiveUnit key in DictUnitComms.Keys)
		{
			foreach (CommDevice item in DictUnitComms[key])
			{
				item.ParentPlatform = key;
				key.AddCommDevice(item);
			}
		}
		((Control)this).Hide();
	}

	static BulkCommAddition()
	{
		Class72.smethod_20();
	}
}
