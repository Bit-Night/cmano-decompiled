using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;
using ThreadSafeCollections;

namespace Command;

[DesignerGenerated]
public class CommData : DarkSecondaryFormBase
{
	[CompilerGenerated]
	internal sealed class _Closure$__231-0
	{
		public object $VB$Local_sender;

		public NotifyCollectionChangedEventArgs $VB$Local_e;

		public CommData $VB$Me;

		public _Closure$__231-0(_Closure$__231-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_sender = arg0.$VB$Local_sender;
				$VB$Local_e = arg0.$VB$Local_e;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			$VB$Me.method_13(RuntimeHelpers.GetObjectValue($VB$Local_sender), $VB$Local_e);
		}

		static _Closure$__231-0()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("TabConnectionCheckTool")]
	private DarkUITabControl _TabConnectionCheckTool;

	[CompilerGenerated]
	[AccessedThroughProperty("TabNetworkManagement")]
	private TabPage dErXsockbq;

	[AccessedThroughProperty("DLV_Networks")]
	[CompilerGenerated]
	private DarkListView _DLV_Networks;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnDeleteNetwork")]
	private DarkUIButton _BtnDeleteNetwork;

	[AccessedThroughProperty("BtnDeselectAllNetworks")]
	[CompilerGenerated]
	private DarkUIButton _BtnDeselectAllNetworks;

	[CompilerGenerated]
	[AccessedThroughProperty("Btn_AddToNetwork")]
	private DarkUIButton _Btn_AddToNetwork;

	[CompilerGenerated]
	[AccessedThroughProperty("Btn_RemoveFromNetwork")]
	private DarkUIButton _Btn_RemoveFromNetwork;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnNetworkGeneration")]
	private DarkUIButton _BtnNetworkGeneration;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnCreateNetwork")]
	private DarkUIButton _BtnCreateNetwork;

	[AccessedThroughProperty("CB_Invalid")]
	[CompilerGenerated]
	private DarkUICheckBox _CB_Invalid;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_Discarded")]
	private DarkUICheckBox _CB_Discarded;

	[AccessedThroughProperty("CB_AllUnits")]
	[CompilerGenerated]
	private DarkUICheckBox _CB_AllUnits;

	[AccessedThroughProperty("CB_SelectedUnits")]
	[CompilerGenerated]
	private DarkUICheckBox QypuepttbU;

	[CompilerGenerated]
	[AccessedThroughProperty("btnSelectUnit1")]
	private DarkUIButton hDauPaTcfo;

	[CompilerGenerated]
	[AccessedThroughProperty("btnSelectUnit2")]
	private DarkUIButton _btnSelectUnit2;

	[CompilerGenerated]
	[AccessedThroughProperty("btnCommCheck")]
	private DarkUIButton _btnCommCheck;

	[AccessedThroughProperty("Timer1")]
	[CompilerGenerated]
	private Timer timer_0;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnNetworkRuleEditor")]
	private DarkUIButton _BtnNetworkRuleEditor;

	[CompilerGenerated]
	[AccessedThroughProperty("TabNetworkView")]
	private TabPage umCuiAtic8;

	private TDictionary<string, TList<Transmission>> tdictionary_0;

	private TList<TransmissionWithFeedback> tlist_0;

	private List<DarkListItem> list_0;

	private string string_0;

	private string string_1;

	private BindingSource bindingSource_0;

	private bool bool_2;

	[CompilerGenerated]
	private ActiveUnit activeUnit_0;

	[CompilerGenerated]
	private ActiveUnit activeUnit_1;

	private string string_2;

	public Dictionary<(CommDevice, CommDevice), ActiveUnit_CommStuff.CommConnectionChecklistEvaluation> CommDeviceFeedback;

	internal virtual DarkUITabControl TabConnectionCheckTool
	{
		[CompilerGenerated]
		get
		{
			return _TabConnectionCheckTool;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_33;
			DarkUITabControl darkUITabControl = _TabConnectionCheckTool;
			if (darkUITabControl != null)
			{
				((TabControl)darkUITabControl).SelectedIndexChanged -= eventHandler;
			}
			_TabConnectionCheckTool = value;
			darkUITabControl = _TabConnectionCheckTool;
			if (darkUITabControl != null)
			{
				((TabControl)darkUITabControl).SelectedIndexChanged += eventHandler;
			}
		}
	}

	internal virtual TabPage TabNetworkManagement
	{
		[CompilerGenerated]
		get
		{
			return dErXsockbq;
		}
		[CompilerGenerated]
		set
		{
			dErXsockbq = value;
		}
	}

	[field: AccessedThroughProperty("TLP_Networks")]
	internal virtual TableLayoutPanel TLP_Networks { get; set; }

	[field: AccessedThroughProperty("PNL_NetworkList")]
	internal virtual Panel PNL_NetworkList { get; set; }

	internal virtual DarkListView DLV_Networks
	{
		[CompilerGenerated]
		get
		{
			return _DLV_Networks;
		}
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_23;
			DarkListView darkListView = _DLV_Networks;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged -= value2;
			}
			_DLV_Networks = value;
			darkListView = _DLV_Networks;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("PNL_NetworkListFooter")]
	internal virtual Panel PNL_NetworkListFooter { get; set; }

	internal virtual DarkUIButton BtnDeleteNetwork
	{
		[CompilerGenerated]
		get
		{
			return _BtnDeleteNetwork;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_20;
			DarkUIButton darkUIButton = _BtnDeleteNetwork;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_BtnDeleteNetwork = value;
			darkUIButton = _BtnDeleteNetwork;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton BtnDeselectAllNetworks
	{
		[CompilerGenerated]
		get
		{
			return _BtnDeselectAllNetworks;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_25;
			DarkUIButton darkUIButton = _BtnDeselectAllNetworks;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_BtnDeselectAllNetworks = value;
			darkUIButton = _BtnDeselectAllNetworks;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("PNL_Transfer")]
	internal virtual Panel PNL_Transfer { get; set; }

	internal virtual DarkUIButton Btn_AddToNetwork
	{
		[CompilerGenerated]
		get
		{
			return _Btn_AddToNetwork;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_21;
			DarkUIButton darkUIButton = _Btn_AddToNetwork;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Btn_AddToNetwork = value;
			darkUIButton = _Btn_AddToNetwork;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Btn_RemoveFromNetwork
	{
		[CompilerGenerated]
		get
		{
			return _Btn_RemoveFromNetwork;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_22;
			DarkUIButton darkUIButton = _Btn_RemoveFromNetwork;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Btn_RemoveFromNetwork = value;
			darkUIButton = _Btn_RemoveFromNetwork;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton BtnNetworkGeneration
	{
		[CompilerGenerated]
		get
		{
			return _BtnNetworkGeneration;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_24;
			DarkUIButton darkUIButton = _BtnNetworkGeneration;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_BtnNetworkGeneration = value;
			darkUIButton = _BtnNetworkGeneration;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("PNL_UnitList")]
	internal virtual Panel PNL_UnitList { get; set; }

	[field: AccessedThroughProperty("DLV_Units")]
	internal virtual DarkListView DLV_Units { get; set; }

	[field: AccessedThroughProperty("PNL_CreateNetwork")]
	internal virtual Panel PNL_CreateNetwork { get; set; }

	[field: AccessedThroughProperty("LblNetworkName")]
	internal virtual DarkLabel LblNetworkName { get; set; }

	[field: AccessedThroughProperty("txtNetworkName")]
	internal virtual DarkUITextBox txtNetworkName { get; set; }

	internal virtual DarkUIButton BtnCreateNetwork
	{
		[CompilerGenerated]
		get
		{
			return _BtnCreateNetwork;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_19;
			DarkUIButton darkUIButton = _BtnCreateNetwork;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_BtnCreateNetwork = value;
			darkUIButton = _BtnCreateNetwork;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TabCommDataTable")]
	internal virtual TabPage TabCommDataTable { get; set; }

	[field: AccessedThroughProperty("TLP_CommData")]
	internal virtual TableLayoutPanel TLP_CommData { get; set; }

	[field: AccessedThroughProperty("PNL_CommToolbar")]
	internal virtual Panel PNL_CommToolbar { get; set; }

	[field: AccessedThroughProperty("LblShowInTable")]
	internal virtual DarkLabel LblShowInTable { get; set; }

	internal virtual DarkUICheckBox CB_Invalid
	{
		[CompilerGenerated]
		get
		{
			return _CB_Invalid;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_14;
			DarkUICheckBox darkUICheckBox = _CB_Invalid;
			if (darkUICheckBox != null)
			{
				((CheckBox)darkUICheckBox).CheckedChanged -= eventHandler;
			}
			_CB_Invalid = value;
			darkUICheckBox = _CB_Invalid;
			if (darkUICheckBox != null)
			{
				((CheckBox)darkUICheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkUICheckBox CB_Discarded
	{
		[CompilerGenerated]
		get
		{
			return _CB_Discarded;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_15;
			DarkUICheckBox darkUICheckBox = _CB_Discarded;
			if (darkUICheckBox != null)
			{
				((CheckBox)darkUICheckBox).CheckedChanged -= eventHandler;
			}
			_CB_Discarded = value;
			darkUICheckBox = _CB_Discarded;
			if (darkUICheckBox != null)
			{
				((CheckBox)darkUICheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("LblCommFilter")]
	internal virtual DarkLabel LblCommFilter { get; set; }

	[field: AccessedThroughProperty("LblShowOnMap")]
	internal virtual DarkLabel LblShowOnMap { get; set; }

	internal virtual DarkUICheckBox CB_AllUnits
	{
		[CompilerGenerated]
		get
		{
			return _CB_AllUnits;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_16;
			DarkUICheckBox darkUICheckBox = _CB_AllUnits;
			if (darkUICheckBox != null)
			{
				((CheckBox)darkUICheckBox).CheckedChanged -= eventHandler;
			}
			_CB_AllUnits = value;
			darkUICheckBox = _CB_AllUnits;
			if (darkUICheckBox != null)
			{
				((CheckBox)darkUICheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkUICheckBox CB_SelectedUnits
	{
		[CompilerGenerated]
		get
		{
			return QypuepttbU;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_17;
			DarkUICheckBox darkUICheckBox = QypuepttbU;
			if (darkUICheckBox != null)
			{
				((CheckBox)darkUICheckBox).CheckedChanged -= eventHandler;
			}
			QypuepttbU = value;
			darkUICheckBox = QypuepttbU;
			if (darkUICheckBox != null)
			{
				((CheckBox)darkUICheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("CommDataGridView")]
	internal virtual DarkDataGridView CommDataGridView { get; set; }

	[field: AccessedThroughProperty("tabCommCheckTool")]
	internal virtual TabPage tabCommCheckTool { get; set; }

	[field: AccessedThroughProperty("TLP_CommCheck")]
	internal virtual TableLayoutPanel TLP_CommCheck { get; set; }

	[field: AccessedThroughProperty("PNL_Unit1")]
	internal virtual Panel PNL_Unit1 { get; set; }

	[field: AccessedThroughProperty("LblUnit1Header")]
	internal virtual DarkLabel LblUnit1Header { get; set; }

	[field: AccessedThroughProperty("lblUnit1")]
	internal virtual DarkLabel lblUnit1 { get; set; }

	internal virtual DarkUIButton btnSelectUnit1
	{
		[CompilerGenerated]
		get
		{
			return hDauPaTcfo;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_27;
			DarkUIButton darkUIButton = hDauPaTcfo;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			hDauPaTcfo = value;
			darkUIButton = hDauPaTcfo;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("PNL_Unit2")]
	internal virtual Panel PNL_Unit2 { get; set; }

	[field: AccessedThroughProperty("LblUnit2Header")]
	internal virtual DarkLabel LblUnit2Header { get; set; }

	[field: AccessedThroughProperty("lblUnit2")]
	internal virtual DarkLabel lblUnit2 { get; set; }

	internal virtual DarkUIButton btnSelectUnit2
	{
		[CompilerGenerated]
		get
		{
			return _btnSelectUnit2;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_28;
			DarkUIButton darkUIButton = _btnSelectUnit2;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_btnSelectUnit2 = value;
			darkUIButton = _btnSelectUnit2;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton btnCommCheck
	{
		[CompilerGenerated]
		get
		{
			return _btnCommCheck;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_26;
			DarkUIButton darkUIButton = _btnCommCheck;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_btnCommCheck = value;
			darkUIButton = _btnCommCheck;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("ComNetworkLog")]
	internal virtual TabPage ComNetworkLog { get; set; }

	[field: AccessedThroughProperty("TLP_Log")]
	internal virtual TableLayoutPanel TLP_Log { get; set; }

	[field: AccessedThroughProperty("DDGV_NetworkLog")]
	internal virtual DarkDataGridView DDGV_NetworkLog { get; set; }

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
			EventHandler eventHandler = method_18;
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

	[field: AccessedThroughProperty("DTV_CommResults")]
	internal virtual DarkTreeView DTV_CommResults { get; set; }

	internal virtual DarkUIButton BtnNetworkRuleEditor
	{
		[CompilerGenerated]
		get
		{
			return _BtnNetworkRuleEditor;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_32;
			DarkUIButton darkUIButton = _BtnNetworkRuleEditor;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_BtnNetworkRuleEditor = value;
			darkUIButton = _BtnNetworkRuleEditor;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual TabPage TabNetworkView
	{
		[CompilerGenerated]
		get
		{
			return umCuiAtic8;
		}
		[CompilerGenerated]
		set
		{
			umCuiAtic8 = value;
		}
	}

	[field: AccessedThroughProperty("NetworkViewTab")]
	internal virtual CommNetworkTab NetworkViewTab { get; set; }

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
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected O, but got Unknown
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected O, but got Unknown
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected O, but got Unknown
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Expected O, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Expected O, but got Unknown
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Expected O, but got Unknown
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Expected O, but got Unknown
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected O, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected O, but got Unknown
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Expected O, but got Unknown
		//IL_0476: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04dd: Expected O, but got Unknown
		//IL_04ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f9: Expected O, but got Unknown
		//IL_050b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0515: Expected O, but got Unknown
		//IL_05c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cd: Expected O, but got Unknown
		//IL_05df: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e9: Expected O, but got Unknown
		//IL_07e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0882: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a58: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0feb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1048: Unknown result type (might be due to invalid IL or missing references)
		//IL_1052: Expected O, but got Unknown
		//IL_10d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_10da: Expected O, but got Unknown
		//IL_10ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_10f6: Expected O, but got Unknown
		//IL_15fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1606: Expected O, but got Unknown
		//IL_167f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1689: Expected O, but got Unknown
		//IL_17f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1868: Unknown result type (might be due to invalid IL or missing references)
		//IL_1872: Expected O, but got Unknown
		//IL_1884: Unknown result type (might be due to invalid IL or missing references)
		//IL_188e: Expected O, but got Unknown
		//IL_193c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1946: Expected O, but got Unknown
		//IL_1958: Unknown result type (might be due to invalid IL or missing references)
		//IL_1962: Expected O, but got Unknown
		//IL_1974: Unknown result type (might be due to invalid IL or missing references)
		//IL_197e: Expected O, but got Unknown
		//IL_1a28: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a71: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a7b: Expected O, but got Unknown
		//IL_1b09: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b13: Expected O, but got Unknown
		//IL_1bce: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c9e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ce7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cf1: Expected O, but got Unknown
		//IL_1d7f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d89: Expected O, but got Unknown
		//IL_1e44: Unknown result type (might be due to invalid IL or missing references)
		//IL_1eed: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2032: Unknown result type (might be due to invalid IL or missing references)
		//IL_208f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2099: Expected O, but got Unknown
		//IL_20ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_2109: Expected O, but got Unknown
		//IL_21be: Unknown result type (might be due to invalid IL or missing references)
		//IL_21c8: Expected O, but got Unknown
		//IL_2244: Unknown result type (might be due to invalid IL or missing references)
		//IL_224e: Expected O, but got Unknown
		icontainer_1 = new Container();
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DataGridViewCellStyle val5 = new DataGridViewCellStyle();
		DataGridViewCellStyle val6 = new DataGridViewCellStyle();
		TabConnectionCheckTool = new DarkUITabControl();
		TabNetworkManagement = new TabPage();
		TLP_Networks = new TableLayoutPanel();
		PNL_NetworkList = new Panel();
		DLV_Networks = new DarkListView();
		PNL_NetworkListFooter = new Panel();
		BtnDeselectAllNetworks = new DarkUIButton();
		BtnDeleteNetwork = new DarkUIButton();
		PNL_Transfer = new Panel();
		BtnNetworkRuleEditor = new DarkUIButton();
		Btn_AddToNetwork = new DarkUIButton();
		Btn_RemoveFromNetwork = new DarkUIButton();
		BtnNetworkGeneration = new DarkUIButton();
		PNL_UnitList = new Panel();
		DLV_Units = new DarkListView();
		PNL_CreateNetwork = new Panel();
		LblNetworkName = new DarkLabel();
		txtNetworkName = new DarkUITextBox();
		BtnCreateNetwork = new DarkUIButton();
		TabCommDataTable = new TabPage();
		TLP_CommData = new TableLayoutPanel();
		PNL_CommToolbar = new Panel();
		LblShowInTable = new DarkLabel();
		CB_Invalid = new DarkUICheckBox();
		CB_Discarded = new DarkUICheckBox();
		LblShowOnMap = new DarkLabel();
		CB_AllUnits = new DarkUICheckBox();
		CB_SelectedUnits = new DarkUICheckBox();
		LblCommFilter = new DarkLabel();
		CommDataGridView = new DarkDataGridView();
		tabCommCheckTool = new TabPage();
		TLP_CommCheck = new TableLayoutPanel();
		PNL_Unit1 = new Panel();
		LblUnit1Header = new DarkLabel();
		lblUnit1 = new DarkLabel();
		btnSelectUnit1 = new DarkUIButton();
		PNL_Unit2 = new Panel();
		LblUnit2Header = new DarkLabel();
		lblUnit2 = new DarkLabel();
		btnSelectUnit2 = new DarkUIButton();
		btnCommCheck = new DarkUIButton();
		DTV_CommResults = new DarkTreeView();
		ComNetworkLog = new TabPage();
		TLP_Log = new TableLayoutPanel();
		DDGV_NetworkLog = new DarkDataGridView();
		TabNetworkView = new TabPage();
		NetworkViewTab = new CommNetworkTab();
		Timer1 = new Timer(icontainer_1);
		((Control)TabConnectionCheckTool).SuspendLayout();
		((Control)TabNetworkManagement).SuspendLayout();
		((Control)TLP_Networks).SuspendLayout();
		((Control)PNL_NetworkList).SuspendLayout();
		((Control)PNL_NetworkListFooter).SuspendLayout();
		((Control)PNL_Transfer).SuspendLayout();
		((Control)PNL_UnitList).SuspendLayout();
		((Control)PNL_CreateNetwork).SuspendLayout();
		((Control)TabCommDataTable).SuspendLayout();
		((Control)TLP_CommData).SuspendLayout();
		((Control)PNL_CommToolbar).SuspendLayout();
		((ISupportInitialize)(object)CommDataGridView).BeginInit();
		((Control)tabCommCheckTool).SuspendLayout();
		((Control)TLP_CommCheck).SuspendLayout();
		((Control)PNL_Unit1).SuspendLayout();
		((Control)PNL_Unit2).SuspendLayout();
		((Control)ComNetworkLog).SuspendLayout();
		((Control)TLP_Log).SuspendLayout();
		((ISupportInitialize)(object)DDGV_NetworkLog).BeginInit();
		((Control)TabNetworkView).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)TabConnectionCheckTool).Controls.Add((Control)(object)TabNetworkManagement);
		((Control)TabConnectionCheckTool).Controls.Add((Control)(object)TabNetworkView);
		((Control)TabConnectionCheckTool).Controls.Add((Control)(object)TabCommDataTable);
		((Control)TabConnectionCheckTool).Controls.Add((Control)(object)tabCommCheckTool);
		((Control)TabConnectionCheckTool).Controls.Add((Control)(object)ComNetworkLog);
		((Control)TabConnectionCheckTool).Cursor = Cursors.Hand;
		((Control)TabConnectionCheckTool).Dock = (DockStyle)5;
		((TabControl)TabConnectionCheckTool).ItemSize = new Size(160, 24);
		((Control)TabConnectionCheckTool).Location = new Point(0, 0);
		((Control)TabConnectionCheckTool).Name = "TabConnectionCheckTool";
		((TabControl)TabConnectionCheckTool).SelectedIndex = 0;
		((Control)TabConnectionCheckTool).Size = new Size(957, 540);
		((Control)TabConnectionCheckTool).TabIndex = 0;
		TabNetworkManagement.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabNetworkManagement).Controls.Add((Control)(object)TLP_Networks);
		TabNetworkManagement.Location = new Point(4, 28);
		((Control)TabNetworkManagement).Name = "TabNetworkManagement";
		((Control)TabNetworkManagement).Padding = new Padding(10);
		((Control)TabNetworkManagement).Size = new Size(949, 508);
		TabNetworkManagement.TabIndex = 0;
		TabNetworkManagement.Text = "Network Management";
		TLP_Networks.ColumnCount = 3;
		TLP_Networks.ColumnStyles.Add(new ColumnStyle((SizeType)2, 45f));
		TLP_Networks.ColumnStyles.Add(new ColumnStyle((SizeType)1, 140f));
		TLP_Networks.ColumnStyles.Add(new ColumnStyle((SizeType)2, 55f));
		TLP_Networks.Controls.Add((Control)(object)PNL_NetworkList, 0, 0);
		TLP_Networks.Controls.Add((Control)(object)PNL_Transfer, 1, 0);
		TLP_Networks.Controls.Add((Control)(object)PNL_UnitList, 2, 0);
		TLP_Networks.Controls.Add((Control)(object)PNL_CreateNetwork, 0, 1);
		((Control)TLP_Networks).Dock = (DockStyle)5;
		((Control)TLP_Networks).Location = new Point(10, 10);
		((Control)TLP_Networks).Name = "TLP_Networks";
		TLP_Networks.RowCount = 2;
		TLP_Networks.RowStyles.Add(new RowStyle((SizeType)2, 100f));
		TLP_Networks.RowStyles.Add(new RowStyle((SizeType)1, 46f));
		((Control)TLP_Networks).Size = new Size(929, 488);
		((Control)TLP_Networks).TabIndex = 0;
		((Control)PNL_NetworkList).Controls.Add((Control)(object)DLV_Networks);
		((Control)PNL_NetworkList).Controls.Add((Control)(object)PNL_NetworkListFooter);
		((Control)PNL_NetworkList).Dock = (DockStyle)5;
		((Control)PNL_NetworkList).Location = new Point(3, 3);
		((Control)PNL_NetworkList).Name = "PNL_NetworkList";
		((Control)PNL_NetworkList).Size = new Size(349, 436);
		((Control)PNL_NetworkList).TabIndex = 0;
		((Control)DLV_Networks).Dock = (DockStyle)5;
		((Control)DLV_Networks).Location = new Point(0, 0);
		DLV_Networks.MultiSelect = true;
		((Control)DLV_Networks).Name = "DLV_Networks";
		DLV_Networks.RelatedInfos = null;
		((Control)DLV_Networks).Size = new Size(349, 396);
		((Control)DLV_Networks).TabIndex = 0;
		((Control)DLV_Networks).Text = "Networks";
		((Control)PNL_NetworkListFooter).Controls.Add((Control)(object)BtnDeselectAllNetworks);
		((Control)PNL_NetworkListFooter).Controls.Add((Control)(object)BtnDeleteNetwork);
		((Control)PNL_NetworkListFooter).Dock = (DockStyle)2;
		((Control)PNL_NetworkListFooter).Location = new Point(0, 396);
		((Control)PNL_NetworkListFooter).Name = "PNL_NetworkListFooter";
		((Control)PNL_NetworkListFooter).Size = new Size(349, 40);
		((Control)PNL_NetworkListFooter).TabIndex = 1;
		((Control)BtnDeselectAllNetworks).Dock = (DockStyle)3;
		((Control)BtnDeselectAllNetworks).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)BtnDeselectAllNetworks).Location = new Point(0, 0);
		((Control)BtnDeselectAllNetworks).Name = "BtnDeselectAllNetworks";
		((Control)BtnDeselectAllNetworks).Padding = new Padding(4);
		BtnDeselectAllNetworks.RoundRadius = 0;
		((Control)BtnDeselectAllNetworks).Size = new Size(180, 40);
		((Control)BtnDeselectAllNetworks).TabIndex = 0;
		BtnDeselectAllNetworks.Text = "Deselect all";
		((Control)BtnDeleteNetwork).Dock = (DockStyle)4;
		((Control)BtnDeleteNetwork).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)BtnDeleteNetwork).Location = new Point(169, 0);
		((Control)BtnDeleteNetwork).Name = "BtnDeleteNetwork";
		((Control)BtnDeleteNetwork).Padding = new Padding(4);
		BtnDeleteNetwork.RoundRadius = 0;
		((Control)BtnDeleteNetwork).Size = new Size(180, 40);
		((Control)BtnDeleteNetwork).TabIndex = 1;
		BtnDeleteNetwork.Text = "Delete selected network";
		((Control)PNL_Transfer).Controls.Add((Control)(object)BtnNetworkRuleEditor);
		((Control)PNL_Transfer).Controls.Add((Control)(object)Btn_AddToNetwork);
		((Control)PNL_Transfer).Controls.Add((Control)(object)Btn_RemoveFromNetwork);
		((Control)PNL_Transfer).Controls.Add((Control)(object)BtnNetworkGeneration);
		((Control)PNL_Transfer).Dock = (DockStyle)5;
		((Control)PNL_Transfer).Location = new Point(358, 3);
		((Control)PNL_Transfer).Name = "PNL_Transfer";
		((Control)PNL_Transfer).Size = new Size(134, 436);
		((Control)PNL_Transfer).TabIndex = 1;
		((Control)BtnNetworkRuleEditor).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)BtnNetworkRuleEditor).Location = new Point(0, 3);
		((Control)BtnNetworkRuleEditor).Name = "BtnNetworkRuleEditor";
		((Control)BtnNetworkRuleEditor).Padding = new Padding(5);
		BtnNetworkRuleEditor.RoundRadius = 0;
		((Control)BtnNetworkRuleEditor).Size = new Size(131, 59);
		((Control)BtnNetworkRuleEditor).TabIndex = 3;
		BtnNetworkRuleEditor.Text = "Network Rule Editor";
		((Control)Btn_AddToNetwork).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Btn_AddToNetwork).Location = new Point(7, 160);
		((Control)Btn_AddToNetwork).Name = "Btn_AddToNetwork";
		((Control)Btn_AddToNetwork).Padding = new Padding(4);
		Btn_AddToNetwork.RoundRadius = 0;
		((Control)Btn_AddToNetwork).Size = new Size(120, 36);
		((Control)Btn_AddToNetwork).TabIndex = 0;
		Btn_AddToNetwork.Text = "Add to network >>";
		((Control)Btn_RemoveFromNetwork).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Btn_RemoveFromNetwork).Location = new Point(7, 204);
		((Control)Btn_RemoveFromNetwork).Name = "Btn_RemoveFromNetwork";
		((Control)Btn_RemoveFromNetwork).Padding = new Padding(4);
		Btn_RemoveFromNetwork.RoundRadius = 0;
		((Control)Btn_RemoveFromNetwork).Size = new Size(120, 36);
		((Control)Btn_RemoveFromNetwork).TabIndex = 1;
		Btn_RemoveFromNetwork.Text = "<< Remove";
		((Control)BtnNetworkGeneration).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)BtnNetworkGeneration).Location = new Point(7, 268);
		((Control)BtnNetworkGeneration).Name = "BtnNetworkGeneration";
		((Control)BtnNetworkGeneration).Padding = new Padding(4);
		BtnNetworkGeneration.RoundRadius = 0;
		((Control)BtnNetworkGeneration).Size = new Size(120, 48);
		((Control)BtnNetworkGeneration).TabIndex = 2;
		BtnNetworkGeneration.Text = "Auto-generate networks";
		((Control)PNL_UnitList).Controls.Add((Control)(object)DLV_Units);
		((Control)PNL_UnitList).Dock = (DockStyle)5;
		((Control)PNL_UnitList).Location = new Point(498, 3);
		((Control)PNL_UnitList).Name = "PNL_UnitList";
		((Control)PNL_UnitList).Size = new Size(428, 436);
		((Control)PNL_UnitList).TabIndex = 2;
		((Control)DLV_Units).Dock = (DockStyle)5;
		((Control)DLV_Units).Location = new Point(0, 0);
		DLV_Units.MultiSelect = true;
		((Control)DLV_Units).Name = "DLV_Units";
		DLV_Units.RelatedInfos = null;
		((Control)DLV_Units).Size = new Size(428, 436);
		((Control)DLV_Units).TabIndex = 0;
		((Control)DLV_Units).Text = "Available Units";
		TLP_Networks.SetColumnSpan((Control)(object)PNL_CreateNetwork, 3);
		((Control)PNL_CreateNetwork).Controls.Add((Control)(object)LblNetworkName);
		((Control)PNL_CreateNetwork).Controls.Add((Control)(object)txtNetworkName);
		((Control)PNL_CreateNetwork).Controls.Add((Control)(object)BtnCreateNetwork);
		((Control)PNL_CreateNetwork).Dock = (DockStyle)5;
		((Control)PNL_CreateNetwork).Location = new Point(3, 445);
		((Control)PNL_CreateNetwork).Name = "PNL_CreateNetwork";
		((Control)PNL_CreateNetwork).Size = new Size(923, 40);
		((Control)PNL_CreateNetwork).TabIndex = 3;
		LblNetworkName.AutoSize = true;
		((Control)LblNetworkName).ForeColor = Color.FromArgb(180, 180, 180);
		((Control)LblNetworkName).Location = new Point(0, 11);
		((Control)LblNetworkName).Name = "LblNetworkName";
		((Control)LblNetworkName).Size = new Size(105, 15);
		((Control)LblNetworkName).TabIndex = 0;
		((Label)LblNetworkName).Text = "New network name:";
		txtNetworkName.AutoCompleteCustomSource = null;
		txtNetworkName.AutoCompleteMode = (AutoCompleteMode)0;
		txtNetworkName.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)txtNetworkName).BackColor = Color.FromArgb(49, 51, 53);
		((Control)txtNetworkName).ForeColor = Color.FromArgb(220, 220, 220);
		txtNetworkName.Image = null;
		txtNetworkName.Lines = null;
		((Control)txtNetworkName).Location = new Point(120, 6);
		txtNetworkName.MaxLength = 64;
		txtNetworkName.Multiline = false;
		((Control)txtNetworkName).Name = "txtNetworkName";
		txtNetworkName.ReadOnly = false;
		txtNetworkName.ScrollBars = (ScrollBars)0;
		txtNetworkName.SelectionStart = 0;
		((Control)txtNetworkName).Size = new Size(600, 28);
		((Control)txtNetworkName).TabIndex = 1;
		txtNetworkName.TextAlign = (HorizontalAlignment)0;
		txtNetworkName.UseSystemPasswordChar = false;
		txtNetworkName.WatermarkText = "Enter a name for the new network…";
		txtNetworkName.WordWrap = false;
		((Control)BtnCreateNetwork).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)BtnCreateNetwork).Location = new Point(732, 6);
		((Control)BtnCreateNetwork).Name = "BtnCreateNetwork";
		((Control)BtnCreateNetwork).Padding = new Padding(4);
		BtnCreateNetwork.RoundRadius = 0;
		((Control)BtnCreateNetwork).Size = new Size(188, 28);
		((Control)BtnCreateNetwork).TabIndex = 2;
		BtnCreateNetwork.Text = "Create network";
		TabCommDataTable.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabCommDataTable).Controls.Add((Control)(object)TLP_CommData);
		TabCommDataTable.Location = new Point(4, 28);
		((Control)TabCommDataTable).Name = "TabCommDataTable";
		((Control)TabCommDataTable).Padding = new Padding(10);
		((Control)TabCommDataTable).Size = new Size(949, 508);
		TabCommDataTable.TabIndex = 1;
		TabCommDataTable.Text = "Comm Data Table";
		TLP_CommData.ColumnCount = 1;
		TLP_CommData.ColumnStyles.Add(new ColumnStyle((SizeType)2, 100f));
		TLP_CommData.Controls.Add((Control)(object)PNL_CommToolbar, 0, 0);
		TLP_CommData.Controls.Add((Control)(object)CommDataGridView, 0, 1);
		((Control)TLP_CommData).Dock = (DockStyle)5;
		((Control)TLP_CommData).Location = new Point(10, 10);
		((Control)TLP_CommData).Name = "TLP_CommData";
		TLP_CommData.RowCount = 2;
		TLP_CommData.RowStyles.Add(new RowStyle((SizeType)1, 60f));
		TLP_CommData.RowStyles.Add(new RowStyle((SizeType)2, 100f));
		((Control)TLP_CommData).Size = new Size(929, 488);
		((Control)TLP_CommData).TabIndex = 0;
		((Control)PNL_CommToolbar).Controls.Add((Control)(object)LblShowInTable);
		((Control)PNL_CommToolbar).Controls.Add((Control)(object)CB_Invalid);
		((Control)PNL_CommToolbar).Controls.Add((Control)(object)CB_Discarded);
		((Control)PNL_CommToolbar).Controls.Add((Control)(object)LblShowOnMap);
		((Control)PNL_CommToolbar).Controls.Add((Control)(object)CB_AllUnits);
		((Control)PNL_CommToolbar).Controls.Add((Control)(object)CB_SelectedUnits);
		((Control)PNL_CommToolbar).Controls.Add((Control)(object)LblCommFilter);
		((Control)PNL_CommToolbar).Dock = (DockStyle)5;
		((Control)PNL_CommToolbar).Location = new Point(3, 3);
		((Control)PNL_CommToolbar).Name = "PNL_CommToolbar";
		((Control)PNL_CommToolbar).Size = new Size(923, 54);
		((Control)PNL_CommToolbar).TabIndex = 0;
		LblShowInTable.AutoSize = true;
		((Control)LblShowInTable).ForeColor = Color.FromArgb(180, 180, 180);
		((Control)LblShowInTable).Location = new Point(0, 4);
		((Control)LblShowInTable).Name = "LblShowInTable";
		((Control)LblShowInTable).Size = new Size(135, 15);
		((Control)LblShowInTable).TabIndex = 0;
		((Label)LblShowInTable).Text = "Show messages in table:";
		((ButtonBase)CB_Invalid).AutoSize = true;
		((Control)CB_Invalid).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)CB_Invalid).Location = new Point(0, 30);
		((Control)CB_Invalid).Name = "CB_Invalid";
		((Control)CB_Invalid).Size = new Size(103, 19);
		((Control)CB_Invalid).TabIndex = 1;
		((ButtonBase)CB_Invalid).Text = "Include invalid";
		((ButtonBase)CB_Discarded).AutoSize = true;
		((Control)CB_Discarded).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)CB_Discarded).Location = new Point(120, 30);
		((Control)CB_Discarded).Name = "CB_Discarded";
		((Control)CB_Discarded).Size = new Size(119, 19);
		((Control)CB_Discarded).TabIndex = 2;
		((ButtonBase)CB_Discarded).Text = "Include discarded";
		LblShowOnMap.AutoSize = true;
		((Control)LblShowOnMap).ForeColor = Color.FromArgb(180, 180, 180);
		((Control)LblShowOnMap).Location = new Point(280, 4);
		((Control)LblShowOnMap).Name = "LblShowOnMap";
		((Control)LblShowOnMap).Size = new Size(104, 15);
		((Control)LblShowOnMap).TabIndex = 4;
		((Label)LblShowOnMap).Text = "Highlight on map:";
		((ButtonBase)CB_AllUnits).AutoSize = true;
		((Control)CB_AllUnits).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)CB_AllUnits).Location = new Point(280, 30);
		((Control)CB_AllUnits).Name = "CB_AllUnits";
		((Control)CB_AllUnits).Size = new Size(69, 19);
		((Control)CB_AllUnits).TabIndex = 5;
		((ButtonBase)CB_AllUnits).Text = "All units";
		((ButtonBase)CB_SelectedUnits).AutoSize = true;
		((Control)CB_SelectedUnits).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)CB_SelectedUnits).Location = new Point(370, 30);
		((Control)CB_SelectedUnits).Name = "CB_SelectedUnits";
		((Control)CB_SelectedUnits).Size = new Size(125, 19);
		((Control)CB_SelectedUnits).TabIndex = 6;
		((ButtonBase)CB_SelectedUnits).Text = "Selected units only";
		((Label)LblCommFilter).BorderStyle = (BorderStyle)1;
		((Control)LblCommFilter).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)LblCommFilter).Location = new Point(268, 6);
		((Control)LblCommFilter).Name = "LblCommFilter";
		((Control)LblCommFilter).Size = new Size(1, 42);
		((Control)LblCommFilter).TabIndex = 3;
		((DataGridView)CommDataGridView).AllowUserToAddRows = false;
		((DataGridView)CommDataGridView).AllowUserToDeleteRows = false;
		((DataGridView)CommDataGridView).AllowUserToOrderColumns = true;
		((DataGridView)CommDataGridView).BackgroundColor = Color.FromArgb(60, 63, 65);
		((DataGridView)CommDataGridView).BorderStyle = (BorderStyle)0;
		((DataGridView)CommDataGridView).CellBorderStyle = (DataGridViewCellBorderStyle)8;
		((DataGridView)CommDataGridView).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val.Alignment = (DataGridViewContentAlignment)16;
		val.BackColor = Color.FromArgb(66, 77, 95);
		val.Font = new Font("Segoe UI", 9f);
		val.ForeColor = Color.LightGray;
		val.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val.WrapMode = (DataGridViewTriState)1;
		((DataGridView)CommDataGridView).ColumnHeadersDefaultCellStyle = val;
		((DataGridView)CommDataGridView).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = Color.FromArgb(60, 63, 65);
		val2.Font = new Font("Segoe UI", 9f);
		val2.ForeColor = Color.LightGray;
		val2.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val2.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)CommDataGridView).DefaultCellStyle = val2;
		((Control)CommDataGridView).Dock = (DockStyle)5;
		((DataGridView)CommDataGridView).EnableHeadersVisualStyles = false;
		((Control)CommDataGridView).Location = new Point(3, 63);
		((Control)CommDataGridView).Name = "CommDataGridView";
		((DataGridView)CommDataGridView).RowHeadersWidth = 32;
		val3.BackColor = Color.FromArgb(60, 63, 65);
		val3.ForeColor = Color.LightGray;
		val3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val3.SelectionForeColor = Color.LightGray;
		((DataGridView)CommDataGridView).RowsDefaultCellStyle = val3;
		((DataGridView)CommDataGridView).RowTemplate.Height = 28;
		((Control)CommDataGridView).Size = new Size(923, 422);
		((Control)CommDataGridView).TabIndex = 0;
		tabCommCheckTool.BackColor = Color.FromArgb(60, 63, 65);
		((Control)tabCommCheckTool).Controls.Add((Control)(object)TLP_CommCheck);
		tabCommCheckTool.Location = new Point(4, 28);
		((Control)tabCommCheckTool).Name = "tabCommCheckTool";
		((Control)tabCommCheckTool).Padding = new Padding(14);
		((Control)tabCommCheckTool).Size = new Size(949, 508);
		tabCommCheckTool.TabIndex = 2;
		tabCommCheckTool.Text = "Comm Check Tool";
		((Control)TLP_CommCheck).BackColor = Color.FromArgb(60, 63, 65);
		TLP_CommCheck.ColumnCount = 2;
		TLP_CommCheck.ColumnStyles.Add(new ColumnStyle((SizeType)2, 50f));
		TLP_CommCheck.ColumnStyles.Add(new ColumnStyle((SizeType)2, 50f));
		TLP_CommCheck.Controls.Add((Control)(object)PNL_Unit1, 0, 0);
		TLP_CommCheck.Controls.Add((Control)(object)PNL_Unit2, 1, 0);
		TLP_CommCheck.Controls.Add((Control)(object)btnCommCheck, 0, 2);
		TLP_CommCheck.Controls.Add((Control)(object)DTV_CommResults, 0, 1);
		((Control)TLP_CommCheck).Dock = (DockStyle)5;
		((Control)TLP_CommCheck).Location = new Point(14, 14);
		((Control)TLP_CommCheck).Name = "TLP_CommCheck";
		TLP_CommCheck.RowCount = 3;
		TLP_CommCheck.RowStyles.Add(new RowStyle((SizeType)1, 110f));
		TLP_CommCheck.RowStyles.Add(new RowStyle((SizeType)2, 100f));
		TLP_CommCheck.RowStyles.Add(new RowStyle((SizeType)1, 50f));
		((Control)TLP_CommCheck).Size = new Size(921, 480);
		((Control)TLP_CommCheck).TabIndex = 0;
		PNL_Unit1.BorderStyle = (BorderStyle)1;
		((Control)PNL_Unit1).Controls.Add((Control)(object)LblUnit1Header);
		((Control)PNL_Unit1).Controls.Add((Control)(object)lblUnit1);
		((Control)PNL_Unit1).Controls.Add((Control)(object)btnSelectUnit1);
		((Control)PNL_Unit1).Dock = (DockStyle)5;
		((Control)PNL_Unit1).Location = new Point(3, 3);
		((Control)PNL_Unit1).Name = "PNL_Unit1";
		((Control)PNL_Unit1).Padding = new Padding(8);
		((Control)PNL_Unit1).Size = new Size(454, 104);
		((Control)PNL_Unit1).TabIndex = 0;
		LblUnit1Header.AutoSize = true;
		((Control)LblUnit1Header).Font = new Font("Segoe UI", 8f);
		((Control)LblUnit1Header).ForeColor = Color.FromArgb(160, 160, 160);
		((Control)LblUnit1Header).Location = new Point(8, 8);
		((Control)LblUnit1Header).Name = "LblUnit1Header";
		((Control)LblUnit1Header).Size = new Size(61, 13);
		((Control)LblUnit1Header).TabIndex = 0;
		((Label)LblUnit1Header).Text = "FIRST UNIT";
		lblUnit1.AutoSize = true;
		((Control)lblUnit1).Font = new Font("Segoe UI", 11f, (FontStyle)1);
		((Control)lblUnit1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)lblUnit1).Location = new Point(8, 28);
		((Control)lblUnit1).Name = "lblUnit1";
		((Control)lblUnit1).Size = new Size(123, 20);
		((Control)lblUnit1).TabIndex = 1;
		((Label)lblUnit1).Text = "No unit selected";
		((Control)btnSelectUnit1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)btnSelectUnit1).Location = new Point(8, 66);
		((Control)btnSelectUnit1).Name = "btnSelectUnit1";
		((Control)btnSelectUnit1).Padding = new Padding(4);
		btnSelectUnit1.RoundRadius = 0;
		((Control)btnSelectUnit1).Size = new Size(160, 30);
		((Control)btnSelectUnit1).TabIndex = 2;
		btnSelectUnit1.Text = "Select unit…";
		PNL_Unit2.BorderStyle = (BorderStyle)1;
		((Control)PNL_Unit2).Controls.Add((Control)(object)LblUnit2Header);
		((Control)PNL_Unit2).Controls.Add((Control)(object)lblUnit2);
		((Control)PNL_Unit2).Controls.Add((Control)(object)btnSelectUnit2);
		((Control)PNL_Unit2).Dock = (DockStyle)5;
		((Control)PNL_Unit2).Location = new Point(463, 3);
		((Control)PNL_Unit2).Name = "PNL_Unit2";
		((Control)PNL_Unit2).Padding = new Padding(8);
		((Control)PNL_Unit2).Size = new Size(455, 104);
		((Control)PNL_Unit2).TabIndex = 1;
		LblUnit2Header.AutoSize = true;
		((Control)LblUnit2Header).Font = new Font("Segoe UI", 8f);
		((Control)LblUnit2Header).ForeColor = Color.FromArgb(160, 160, 160);
		((Control)LblUnit2Header).Location = new Point(8, 8);
		((Control)LblUnit2Header).Name = "LblUnit2Header";
		((Control)LblUnit2Header).Size = new Size(78, 13);
		((Control)LblUnit2Header).TabIndex = 0;
		((Label)LblUnit2Header).Text = "SECOND UNIT";
		lblUnit2.AutoSize = true;
		((Control)lblUnit2).Font = new Font("Segoe UI", 11f, (FontStyle)1);
		((Control)lblUnit2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)lblUnit2).Location = new Point(8, 28);
		((Control)lblUnit2).Name = "lblUnit2";
		((Control)lblUnit2).Size = new Size(123, 20);
		((Control)lblUnit2).TabIndex = 1;
		((Label)lblUnit2).Text = "No unit selected";
		((Control)btnSelectUnit2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)btnSelectUnit2).Location = new Point(8, 66);
		((Control)btnSelectUnit2).Name = "btnSelectUnit2";
		((Control)btnSelectUnit2).Padding = new Padding(4);
		btnSelectUnit2.RoundRadius = 0;
		((Control)btnSelectUnit2).Size = new Size(160, 30);
		((Control)btnSelectUnit2).TabIndex = 2;
		btnSelectUnit2.Text = "Select unit…";
		TLP_CommCheck.SetColumnSpan((Control)(object)btnCommCheck, 2);
		((Control)btnCommCheck).Dock = (DockStyle)5;
		((Control)btnCommCheck).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)btnCommCheck).Location = new Point(60, 433);
		((Control)btnCommCheck).Margin = new Padding(60, 3, 60, 3);
		((Control)btnCommCheck).Name = "btnCommCheck";
		((Control)btnCommCheck).Padding = new Padding(5);
		btnCommCheck.RoundRadius = 0;
		((Control)btnCommCheck).Size = new Size(801, 44);
		((Control)btnCommCheck).TabIndex = 4;
		btnCommCheck.Text = "Run comm check";
		TLP_CommCheck.SetColumnSpan((Control)(object)DTV_CommResults, 2);
		((Control)DTV_CommResults).Dock = (DockStyle)5;
		((Control)DTV_CommResults).Location = new Point(3, 113);
		DTV_CommResults.MaxDragChange = 20;
		((Control)DTV_CommResults).Name = "DTV_CommResults";
		((Control)DTV_CommResults).Size = new Size(915, 314);
		((Control)DTV_CommResults).TabIndex = 5;
		((Control)DTV_CommResults).Text = "DarkTreeView1";
		ComNetworkLog.BackColor = Color.FromArgb(60, 63, 65);
		((Control)ComNetworkLog).Controls.Add((Control)(object)TLP_Log);
		ComNetworkLog.Location = new Point(4, 28);
		((Control)ComNetworkLog).Name = "ComNetworkLog";
		((Control)ComNetworkLog).Padding = new Padding(10);
		((Control)ComNetworkLog).Size = new Size(949, 508);
		ComNetworkLog.TabIndex = 3;
		ComNetworkLog.Text = "Network Log";
		TLP_Log.ColumnCount = 1;
		TLP_Log.ColumnStyles.Add(new ColumnStyle((SizeType)2, 100f));
		TLP_Log.Controls.Add((Control)(object)DDGV_NetworkLog, 0, 0);
		((Control)TLP_Log).Dock = (DockStyle)5;
		((Control)TLP_Log).Location = new Point(10, 10);
		((Control)TLP_Log).Name = "TLP_Log";
		TLP_Log.RowCount = 1;
		TLP_Log.RowStyles.Add(new RowStyle((SizeType)2, 100f));
		((Control)TLP_Log).Size = new Size(929, 488);
		((Control)TLP_Log).TabIndex = 0;
		((DataGridView)DDGV_NetworkLog).AllowUserToAddRows = false;
		((DataGridView)DDGV_NetworkLog).AllowUserToDeleteRows = false;
		((DataGridView)DDGV_NetworkLog).AllowUserToOrderColumns = true;
		((DataGridView)DDGV_NetworkLog).AllowUserToResizeRows = false;
		((DataGridView)DDGV_NetworkLog).BackgroundColor = Color.FromArgb(60, 63, 65);
		((DataGridView)DDGV_NetworkLog).BorderStyle = (BorderStyle)0;
		((DataGridView)DDGV_NetworkLog).CellBorderStyle = (DataGridViewCellBorderStyle)8;
		((DataGridView)DDGV_NetworkLog).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val4.Alignment = (DataGridViewContentAlignment)16;
		val4.BackColor = Color.FromArgb(66, 77, 95);
		val4.Font = new Font("Segoe UI", 9f);
		val4.ForeColor = Color.LightGray;
		val4.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val4.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val4.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DDGV_NetworkLog).ColumnHeadersDefaultCellStyle = val4;
		((DataGridView)DDGV_NetworkLog).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		val5.Alignment = (DataGridViewContentAlignment)16;
		val5.BackColor = Color.FromArgb(60, 63, 65);
		val5.Font = new Font("Segoe UI", 9f);
		val5.ForeColor = Color.LightGray;
		val5.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val5.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val5.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DDGV_NetworkLog).DefaultCellStyle = val5;
		((Control)DDGV_NetworkLog).Dock = (DockStyle)5;
		((DataGridView)DDGV_NetworkLog).EnableHeadersVisualStyles = false;
		((Control)DDGV_NetworkLog).Location = new Point(3, 3);
		((Control)DDGV_NetworkLog).Name = "DDGV_NetworkLog";
		((DataGridView)DDGV_NetworkLog).RowHeadersVisible = false;
		((DataGridView)DDGV_NetworkLog).RowHeadersWidth = 32;
		val6.BackColor = Color.FromArgb(60, 63, 65);
		val6.ForeColor = Color.LightGray;
		val6.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val6.SelectionForeColor = Color.LightGray;
		((DataGridView)DDGV_NetworkLog).RowsDefaultCellStyle = val6;
		((DataGridView)DDGV_NetworkLog).RowTemplate.Height = 28;
		((Control)DDGV_NetworkLog).Size = new Size(923, 482);
		((Control)DDGV_NetworkLog).TabIndex = 0;
		TabNetworkView.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabNetworkView).Controls.Add((Control)(object)NetworkViewTab);
		TabNetworkView.Location = new Point(4, 28);
		((Control)TabNetworkView).Name = "TabNetworkView";
		((Control)TabNetworkView).Size = new Size(949, 508);
		TabNetworkView.TabIndex = 4;
		TabNetworkView.Text = "Network View";
		((Control)NetworkViewTab).BackColor = Color.FromArgb(38, 38, 42);
		((Control)NetworkViewTab).Dock = (DockStyle)5;
		((Control)NetworkViewTab).Location = new Point(0, 0);
		((Control)NetworkViewTab).Name = "NetworkViewTab";
		((Control)NetworkViewTab).Size = new Size(949, 508);
		((Control)NetworkViewTab).TabIndex = 0;
		Timer1.Interval = 1000;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(7f, 15f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(957, 540);
		((Control)this).Controls.Add((Control)(object)TabConnectionCheckTool);
		((Control)this).Name = "CommData";
		((Form)this).Text = "Comm Data";
		((Control)TabConnectionCheckTool).ResumeLayout(false);
		((Control)TabNetworkManagement).ResumeLayout(false);
		((Control)TLP_Networks).ResumeLayout(false);
		((Control)PNL_NetworkList).ResumeLayout(false);
		((Control)PNL_NetworkListFooter).ResumeLayout(false);
		((Control)PNL_Transfer).ResumeLayout(false);
		((Control)PNL_UnitList).ResumeLayout(false);
		((Control)PNL_CreateNetwork).ResumeLayout(false);
		((Control)PNL_CreateNetwork).PerformLayout();
		((Control)TabCommDataTable).ResumeLayout(false);
		((Control)TLP_CommData).ResumeLayout(false);
		((Control)PNL_CommToolbar).ResumeLayout(false);
		((Control)PNL_CommToolbar).PerformLayout();
		((ISupportInitialize)(object)CommDataGridView).EndInit();
		((Control)tabCommCheckTool).ResumeLayout(false);
		((Control)TLP_CommCheck).ResumeLayout(false);
		((Control)PNL_Unit1).ResumeLayout(false);
		((Control)PNL_Unit1).PerformLayout();
		((Control)PNL_Unit2).ResumeLayout(false);
		((Control)PNL_Unit2).PerformLayout();
		((Control)ComNetworkLog).ResumeLayout(false);
		((Control)TLP_Log).ResumeLayout(false);
		((ISupportInitialize)(object)DDGV_NetworkLog).EndInit();
		((Control)TabNetworkView).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
	}

	[SpecialName]
	[CompilerGenerated]
	private ActiveUnit method_2()
	{
		return activeUnit_0;
	}

	[SpecialName]
	[CompilerGenerated]
	private void method_3(ActiveUnit activeUnit_2)
	{
		activeUnit_0 = activeUnit_2;
	}

	[SpecialName]
	private ActiveUnit method_4()
	{
		return method_2();
	}

	[SpecialName]
	private void method_5(ActiveUnit activeUnit_2)
	{
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			method_3(activeUnit_2);
			if (method_2() == null)
			{
				changelblUnit(lblUnit2, string_0);
			}
			else
			{
				changelblUnit(lblUnit1, method_2().Name);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while setting the first comm tool unit." + Environment.NewLine + ex2.Message, "Error32135465132113");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private ActiveUnit LfaXqCmreL()
	{
		return activeUnit_1;
	}

	[SpecialName]
	[CompilerGenerated]
	private void method_6(ActiveUnit activeUnit_2)
	{
		activeUnit_1 = activeUnit_2;
	}

	[SpecialName]
	private ActiveUnit method_7()
	{
		return LfaXqCmreL();
	}

	[SpecialName]
	private void method_8(ActiveUnit activeUnit_2)
	{
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			method_6(activeUnit_2);
			if (LfaXqCmreL() == null)
			{
				changelblUnit(lblUnit2, string_1);
			}
			else
			{
				changelblUnit(lblUnit2, LfaXqCmreL().Name);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while setting the second comm tool unit." + Environment.NewLine + ex2.Message, "Error32135465132114");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	[SpecialName]
	private string method_9()
	{
		return string_2;
	}

	[SpecialName]
	private void method_10(string string_3)
	{
		string_2 = string_3;
	}

	public void changelblUnit(DarkLabel theLbl, string theText)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			((Label)theLbl).Text = theText;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while updating a unit label." + Environment.NewLine + ex2.Message, "Error32135465132115");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public CommData(TDictionary<string, TList<Transmission>> queue, TList<TransmissionWithFeedback> feedback)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		((Control)this).VisibleChanged += CommData_VisibleChanged;
		list_0 = new List<DarkListItem>();
		string_0 = "Select First Unit";
		string_1 = "Select Second Unit";
		bindingSource_0 = new BindingSource();
		bool_2 = false;
		CommDeviceFeedback = new Dictionary<(CommDevice, CommDevice), ActiveUnit_CommStuff.CommConnectionChecklistEvaluation>();
		try
		{
			InitializeComponent_1();
			ReloadData(queue, feedback);
			Timer1 = new Timer();
			Timer1.Interval = 1000;
			Timer1.Enabled = true;
			ReloadNetworks();
			Client.CurrentSide.CommNetworks.DictionaryChanged += method_11;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while initializing the Comm Data form." + Environment.NewLine + ex2.Message, "Error32135465132116");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_11(object sender, NotifyDictionaryChangedEventArgs<string, CommNetwork> e)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (((Control)this).IsHandleCreated)
			{
				((Control)this).BeginInvoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
				{
					ReloadNetworks();
				}));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while handling a comm networks change." + Environment.NewLine + ex2.Message, "Error32135465132117");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void BeginNetworkUpdate()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			bool_2 = true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while beginning a network update." + Environment.NewLine + ex2.Message, "Error32135465132118");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void EndNetworkUpdate()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			bool_2 = false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while ending a network update." + Environment.NewLine + ex2.Message, "Error32135465132119");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ReloadNetworks(bool FromDeselection = false)
	{
		if (Client.CurrentSide == null)
		{
			return;
		}
		try
		{
			List<DarkListItem> list = null;
			if (list_0 != null && list_0.Count > 0)
			{
				list = new List<DarkListItem>(list_0);
			}
			CommNetwork[] array;
			lock (Client.CurrentSide.CommNetworks)
			{
				array = Client.CurrentSide.CommNetworks.Values.ToArray();
			}
			bool_2 = true;
			DLV_Networks.Items.Clear();
			DLV_Units.Items.Clear();
			CommNetwork[] array2 = array;
			foreach (CommNetwork commNetwork in array2)
			{
				DarkListItem darkListItem = new DarkListItem(commNetwork.Name);
				darkListItem.Tag = commNetwork;
				DLV_Networks.Items.Add(darkListItem);
			}
			bool_2 = false;
			if (!FromDeselection && DLV_Networks.Items.Count > 0)
			{
				if (list == null || list.Count == 0)
				{
					DLV_Networks.SelectItem(0);
					return;
				}
				List<int> list2 = new List<int>();
				foreach (DarkListItem item in list)
				{
					if (item.Tag == null || !(item.Tag is CommNetwork commNetwork2))
					{
						continue;
					}
					foreach (DarkListItem item2 in DLV_Networks.Items)
					{
						if (item2.Tag != null && item2.Tag is CommNetwork commNetwork3 && Operators.CompareString(commNetwork3.ID, commNetwork2.ID, true) == 0)
						{
							list2.Add(DLV_Networks.Items.IndexOf(item2));
						}
					}
				}
				if (list2.Count > 0)
				{
					DLV_Networks.SelectItems(list2.ToArray());
				}
				else
				{
					DLV_Networks.SelectItem(0);
				}
			}
			method_12();
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
		finally
		{
			bool_2 = false;
		}
	}

	private void method_12()
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (((TabControl)TabConnectionCheckTool).SelectedTab == TabNetworkView)
			{
				NetworkViewTab.LoadFromCurrentSide();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while refreshing the network view." + Environment.NewLine + ex2.Message, "Error32135465132119");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ReloadData(TDictionary<string, TList<Transmission>> queue, TList<TransmissionWithFeedback> feedback)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			tdictionary_0 = queue;
			tlist_0 = feedback;
			LoadDataDesign();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while reloading data." + Environment.NewLine + ex2.Message, "Error32135465132120");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void LoadDataDesign()
	{
		//IL_054f: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a8: Expected O, but got Unknown
		try
		{
			DateTime dateTime = DateTime.MinValue;
			string text = "";
			if (((BaseCollection)((DataGridView)CommDataGridView).SelectedRows).Count > 0 && ((DataGridView)CommDataGridView).SelectedRows[0].DataBoundItem is TransmissionTableData transmissionTableData)
			{
				dateTime = transmissionTableData.theTimeSent;
				text = transmissionTableData.theSenderName;
			}
			ConcurrentDictionary<Transmission, List<TransmissionWithFeedback>> concurrentDictionary = new ConcurrentDictionary<Transmission, List<TransmissionWithFeedback>>();
			List<TList<Transmission>> list = tdictionary_0.Values.ToList();
			List<TransmissionWithFeedback> list2 = tlist_0.ToList();
			foreach (TList<Transmission> item in list)
			{
				List<Transmission> list3 = item.ToList();
				foreach (Transmission item2 in list3)
				{
					List<TransmissionWithFeedback> list4 = new List<TransmissionWithFeedback>();
					foreach (TransmissionWithFeedback item3 in list2)
					{
						if (item3 != null && item3.theTransmission.ID == item2.ID)
						{
							list4.Add(item3);
						}
					}
					if (list4.Count > 0)
					{
						concurrentDictionary.TryAdd(item2, list4);
					}
				}
			}
			List<TransmissionTableData> list5 = new List<TransmissionTableData>();
			foreach (KeyValuePair<Transmission, List<TransmissionWithFeedback>> item4 in concurrentDictionary)
			{
				string name = item4.Key.SenderUnitList.First().Name;
				string name2 = item4.Key.TheCommDevice.Name;
				string descriptionASSlide = item4.Key.TheCommDevice.QualityGradeinfo.GetDescriptionASSlide();
				string descriptionASSlide2 = item4.Key.TheCommDevice.LatencyGradenfo.GetDescriptionASSlide();
				DateTime originalTransmissionTime = item4.Key.OriginalTransmissionTime;
				string text2 = "";
				foreach (TransmissionWithFeedback item5 in item4.Value)
				{
					if ((item5.result != TransmissionFeedbacResult.Invalid) & (item5.result != TransmissionFeedbacResult.Discarded))
					{
						text2 = text2 + " " + item5.receiver.Name + " " + item5.result;
					}
					else if (((CheckBox)CB_Discarded).Checked & (item5.result == TransmissionFeedbacResult.Discarded))
					{
						text2 = text2 + " " + item5.receiver.Name + " " + item5.result;
					}
					else
					{
						if (!(((CheckBox)CB_Invalid).Checked & (item5.result == TransmissionFeedbacResult.Invalid)))
						{
							continue;
						}
						text2 = text2 + " " + item5.receiver.Name + " " + item5.result;
					}
					text2 += Environment.NewLine;
				}
				if (Operators.CompareString(text2, "", true) != 0)
				{
					list5.Add(new TransmissionTableData(name, name2, descriptionASSlide, descriptionASSlide2, originalTransmissionTime, text2));
				}
			}
			list5 = (from data in list5
				orderby data.theTimeSent descending, data.theSenderName, data.theCommDeviceName
				select data).ToList();
			((DataGridView)CommDataGridView).DataSource = list5;
			((DataGridView)CommDataGridView).AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)16;
			((DataGridView)CommDataGridView).RowsDefaultCellStyle.WrapMode = (DataGridViewTriState)1;
			((DataGridView)CommDataGridView).AutoSizeRowsMode = (DataGridViewAutoSizeRowsMode)7;
			DataGridViewColumn val = ((DataGridView)CommDataGridView).Columns["TheTimeSent"];
			if (val != null)
			{
				val.DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss";
				val.HeaderText = "Time Sent";
			}
			if (DateTime.Compare(dateTime, DateTime.MinValue) != 0)
			{
				foreach (DataGridViewRow item6 in (IEnumerable)((DataGridView)CommDataGridView).Rows)
				{
					DataGridViewRow val2 = item6;
					if (val2.DataBoundItem is TransmissionTableData transmissionTableData2 && DateTime.Compare(transmissionTableData2.theTimeSent, dateTime) == 0 && Operators.CompareString(transmissionTableData2.theSenderName, text, true) == 0)
					{
						val2.Selected = true;
						((DataGridView)CommDataGridView).FirstDisplayedScrollingRowIndex = ((DataGridViewBand)val2).Index;
						break;
					}
				}
			}
			((Control)CommDataGridView).Refresh();
			SetupLogBinding();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while loading the data design." + Environment.NewLine + ex2.Message, "Error32135465132121");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void SetupLogBinding()
	{
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		try
		{
			((DataGridView)DDGV_NetworkLog).Rows.Clear();
			((DataGridView)DDGV_NetworkLog).Columns.Clear();
			DataGridViewTextBoxColumn val = new DataGridViewTextBoxColumn();
			((DataGridViewColumn)val).HeaderText = Client.CurrentSide.Name + " Network's Log";
			((DataGridViewColumn)val).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
			((DataGridView)DDGV_NetworkLog).Columns.Add((DataGridViewColumn)(object)val);
			Client.CurrentSide.NetworkLog.CollectionChanged -= method_13;
			Client.CurrentSide.NetworkLog.CollectionChanged += method_13;
			foreach (string item in Client.CurrentSide.NetworkLog)
			{
				((DataGridView)DDGV_NetworkLog).Rows.Add(new object[1] { item });
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while setting up the log binding." + Environment.NewLine + ex2.Message, "Error32135465132122");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_13(object sender, NotifyCollectionChangedEventArgs e)
	{
		_Closure$__231-0 arg = default(_Closure$__231-0);
		_Closure$__231-0 CS$<>8__locals11 = new _Closure$__231-0(arg);
		CS$<>8__locals11.$VB$Me = this;
		CS$<>8__locals11.$VB$Local_sender = sender;
		CS$<>8__locals11.$VB$Local_e = e;
		try
		{
			if (((DataGridView)DDGV_NetworkLog).Columns == null || ((BaseCollection)((DataGridView)DDGV_NetworkLog).Columns).Count == 0)
			{
				return;
			}
			if (!((Control)DDGV_NetworkLog).InvokeRequired)
			{
				switch (CS$<>8__locals11.$VB$Local_e.Action)
				{
				case NotifyCollectionChangedAction.Add:
					foreach (object newItem in CS$<>8__locals11.$VB$Local_e.NewItems)
					{
						string text = Conversions.ToString(newItem);
						((DataGridView)DDGV_NetworkLog).Rows.Add(new object[1] { text });
					}
					if (DDGV_NetworkLog != null && ((DataGridView)DDGV_NetworkLog).RowCount > 0 && ((Control)DDGV_NetworkLog).IsHandleCreated)
					{
						((DataGridView)DDGV_NetworkLog).FirstDisplayedScrollingRowIndex = ((DataGridView)DDGV_NetworkLog).RowCount - 1;
					}
					break;
				case NotifyCollectionChangedAction.Remove:
					if (CS$<>8__locals11.$VB$Local_e.OldStartingIndex >= 0 && CS$<>8__locals11.$VB$Local_e.OldStartingIndex < ((DataGridView)DDGV_NetworkLog).Rows.Count)
					{
						((DataGridView)DDGV_NetworkLog).Rows.RemoveAt(CS$<>8__locals11.$VB$Local_e.OldStartingIndex);
					}
					break;
				case NotifyCollectionChangedAction.Reset:
					((DataGridView)DDGV_NetworkLog).Rows.Clear();
					break;
				case NotifyCollectionChangedAction.Replace:
				case NotifyCollectionChangedAction.Move:
					break;
				}
			}
			else
			{
				((Control)DDGV_NetworkLog).Invoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
				{
					CS$<>8__locals11.$VB$Me.method_13(RuntimeHelpers.GetObjectValue(CS$<>8__locals11.$VB$Local_sender), CS$<>8__locals11.$VB$Local_e);
				}));
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ReloadNetworks();
			ProjectData.ClearProjectError();
		}
	}

	private void method_14(object sender, EventArgs e)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			LoadDataDesign();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while updating the Invalid filter." + Environment.NewLine + ex2.Message, "Error32135465132123");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_15(object sender, EventArgs e)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			LoadDataDesign();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while updating the Discarded filter." + Environment.NewLine + ex2.Message, "Error32135465132124");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_16(object sender, EventArgs e)
	{
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (((CheckBox)CB_AllUnits).Checked)
			{
				((CheckBox)CB_SelectedUnits).Checked = false;
				GameGeneral.ViewTransmissionFeedbacks.Clear();
				GameGeneral.ViewTransmissionFeedbacks.AddRange(Client.CurrentSide.Units);
			}
			else
			{
				GameGeneral.ViewTransmissionFeedbacks.Clear();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while updating the All Units selection." + Environment.NewLine + ex2.Message, "Error32135465132125");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_17(object sender, EventArgs e)
	{
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (!((CheckBox)CB_SelectedUnits).Checked)
			{
				GameGeneral.ViewTransmissionFeedbacks.Clear();
				return;
			}
			((CheckBox)CB_AllUnits).Checked = false;
			GameGeneral.ViewTransmissionFeedbacks.Clear();
			GameGeneral.ViewTransmissionFeedbacks.AddRange(Client.CurrentSide.SelectedUnits.ToList());
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while updating the Selected Units selection." + Environment.NewLine + ex2.Message, "Error32135465132126");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_18(object sender, EventArgs e)
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (Client.CurrentGame.Status != Game._GameStatus.Paused)
			{
				ReloadData(Client.CurrentSide.MinuteTransmissionQueue, Client.CurrentSide.MinuteFeedbackList);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred during the periodic data refresh." + Environment.NewLine + ex2.Message, "Error32135465132126");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_19(object sender, EventArgs e)
	{
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			BeginNetworkUpdate();
			string nextCommNetworkID = Client.CurrentSide.GetNextCommNetworkID();
			if (Operators.CompareString(txtNetworkName.Text, "", true) != 0)
			{
				Client.CurrentSide.AddCommNetwork(new CommNetwork(Client.CurrentSide, nextCommNetworkID.ToString(), txtNetworkName.Text, new HashSet<Module_Unit.Unit>(), CommNetwork.NetworkCreationReason.NewNetwork));
				EndNetworkUpdate();
				ReloadNetworks();
			}
			else
			{
				DarkMessageBox.ShowWarning("Please enter a name for the network before creating it.", "Network Name Required");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			EndNetworkUpdate();
			DarkMessageBox.ShowError("An error occurred while creating the network." + Environment.NewLine + ex2.Message, "Error32135465132127");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_20(object sender, EventArgs e)
	{
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (DLV_Networks.SelectedItems != null && DLV_Networks.SelectedItems.Count > 0)
			{
				string iD = ((CommNetwork)DLV_Networks.SelectedItems.First().Tag).ID;
				Client.CurrentSide.RemoveCommNetwork(iD);
			}
			ReloadNetworks();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while deleting the network." + Environment.NewLine + ex2.Message, "Error32135465132128");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_21(object sender, EventArgs e)
	{
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (DLV_Networks.SelectedItems != null && DLV_Networks.SelectedItems.Count > 0)
			{
				string iD = ((CommNetwork)DLV_Networks.SelectedItems.First().Tag).ID;
				Client.CurrentSide.AddUnitsToNetwork(iD, Client.CurrentSide.SelectedUnits.ToList());
			}
			if (DLV_Networks.SelectedItems != null && DLV_Networks.SelectedItems.Count > 0)
			{
				list_0.Clear();
				foreach (DarkListItem selectedItem in DLV_Networks.SelectedItems)
				{
					list_0.Add(selectedItem);
				}
			}
			ReloadNetworks();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while adding units to the network." + Environment.NewLine + ex2.Message, "Error32135465132129");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_22(object sender, EventArgs e)
	{
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (DLV_Units.SelectedItems != null && DLV_Units.SelectedItems.Count > 0)
			{
				List<ActiveUnit> list = new List<ActiveUnit>();
				foreach (DarkListItem selectedItem in DLV_Units.SelectedItems)
				{
					list.Add((ActiveUnit)selectedItem.Tag);
				}
				string iD = ((CommNetwork)DLV_Networks.SelectedItems.First().Tag).ID;
				foreach (ActiveUnit item in list)
				{
					Client.CurrentSide.RemoveUnitFromNetwork(iD, item);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while removing units from the network." + Environment.NewLine + ex2.Message, "Error32135465132130");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		ReloadNetworks();
	}

	private void method_23(object sender, EventArgs e)
	{
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (bool_2)
			{
				return;
			}
			DLV_Units.Items.Clear();
			Client.CurrentSide.SelectedNetworks.Clear();
			if (list_0 != null)
			{
				list_0.Clear();
			}
			if (DLV_Networks.SelectedItems != null && DLV_Networks.SelectedItems.Count > 0)
			{
				foreach (DarkListItem selectedItem in DLV_Networks.SelectedItems)
				{
					CommNetwork commNetwork = (CommNetwork)selectedItem.Tag;
					string iD = commNetwork.ID;
					CommNetwork commNetwork2 = Client.CurrentSide.CommNetworks[iD];
					if (commNetwork2.Members == null)
					{
						continue;
					}
					foreach (Module_Unit.Unit member in commNetwork2.Members)
					{
						if (member != null)
						{
							DarkListItem darkListItem = new DarkListItem(member.Name);
							darkListItem.Tag = member;
							DLV_Units.Items.Add(darkListItem);
						}
					}
					if (!Client.CurrentSide.NetworkColorMap.ContainsKey(iD))
					{
						int red = GameGeneral.GlobalRNG.Next(0, 256);
						int green = GameGeneral.GlobalRNG.Next(0, 256);
						int blue = GameGeneral.GlobalRNG.Next(0, 256);
						Color value = Color.FromArgb(255, red, green, blue);
						Client.CurrentSide.NetworkColorMap.Add(iD, value);
					}
					else
					{
						Color value = Client.CurrentSide.NetworkColorMap[iD];
					}
					if (list_0 == null)
					{
						list_0 = new List<DarkListItem>();
					}
					list_0.Add(selectedItem);
					Client.CurrentSide.SelectedNetworks.Add(commNetwork);
				}
				if (Client.CurrentSide.SelectedNetworks != null && Client.CurrentSide.SelectedNetworks.Count > 0)
				{
					Module_Unit.Unit unit = Client.CurrentSide.SelectedNetworks.LastOrDefault().Members.FirstOrDefault();
					if (unit != null)
					{
						MyProject.Forms.MainForm.set_MapCenter(MustRender: true, new GeoPoint(unit.get_Longitude((GlobalVariables.BooleanObject)null), unit.get_Latitude((GlobalVariables.BooleanObject)null)));
					}
				}
			}
			else
			{
				DLV_Units.Items.Clear();
				if (list_0 != null)
				{
					list_0.Clear();
				}
				Client.CurrentSide.SelectedNetworks.Clear();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while changing the selected networks." + Environment.NewLine + ex2.Message, "Error32135465132131");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_24(object sender, EventArgs e)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Client.CurrentScenario.FullNetworkGeneration(Client.CurrentSide);
			ReloadNetworks();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred during network generation." + Environment.NewLine + ex2.Message, "Error32135465132132");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_25(object sender, EventArgs e)
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			DLV_Networks.SelectedItems.Clear();
			Client.CurrentSide.SelectedNetworks.Clear();
			ReloadNetworks(FromDeselection: true);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while deselecting all networks." + Environment.NewLine + ex2.Message, "Error32135465132133");
			ProjectData.ClearProjectError();
		}
	}

	private void method_26(object sender, EventArgs e)
	{
		//IL_0328: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			method_30();
			if (method_4() == null || method_7() == null || Operators.CompareString(method_4().ObjectID, method_7().ObjectID, true) == 0)
			{
				return;
			}
			CommDeviceFeedback.Clear();
			CommDevice[] comms_ReadOnly = method_4().Comms_ReadOnly;
			foreach (CommDevice commDevice in comms_ReadOnly)
			{
				CommDevice[] comms_ReadOnly2 = method_7().Comms_ReadOnly;
				foreach (CommDevice commDevice2 in comms_ReadOnly2)
				{
					ActiveUnit_CommStuff.CommConnectionChecklistEvaluation item = ActiveUnit_CommStuff.CommDeviceToConnectToThisUnit(method_4(), method_4().Comms_ReadOnly, method_7(), IgnoreChannelCount: false, commDevice, commDevice2, onlyOneRequired: true).EvaluationEnum;
					(CommDevice, CommDevice) key = (commDevice, commDevice2);
					if (!CommDeviceFeedback.ContainsKey(key))
					{
						CommDeviceFeedback.Add(key, item);
					}
				}
			}
			Dictionary<string, DarkTreeNode> dictionary = new Dictionary<string, DarkTreeNode>();
			foreach (KeyValuePair<(CommDevice, CommDevice), ActiveUnit_CommStuff.CommConnectionChecklistEvaluation> item2 in CommDeviceFeedback)
			{
				string name = item2.Key.Item1.Name;
				string name2 = item2.Key.Item2.Name;
				DarkTreeNode darkTreeNode;
				if (!dictionary.ContainsKey(name))
				{
					darkTreeNode = new DarkTreeNode(name);
					DTV_CommResults.Nodes.Add(darkTreeNode);
					dictionary.Add(name, darkTreeNode);
				}
				else
				{
					darkTreeNode = dictionary[name];
				}
				string text = name2 + " : ";
				bool flag;
				if (flag = item2.Value == ActiveUnit_CommStuff.CommConnectionChecklistEvaluation.OK)
				{
					CommDevice.QualityGradeDetail qualityGradeDetail = new List<CommDevice.QualityGradeDetail>
					{
						item2.Key.Item1.QualityGradeinfo,
						item2.Key.Item2.QualityGradeinfo
					}.OrderBy([SpecialName] (CommDevice.QualityGradeDetail q) => q.ID).First();
					CommDevice.LatencyGradeDetail latencyGradeDetail = new List<CommDevice.LatencyGradeDetail>
					{
						item2.Key.Item1.LatencyGradenfo,
						item2.Key.Item2.LatencyGradenfo
					}.OrderByDescending([SpecialName] (CommDevice.LatencyGradeDetail l) => l.ID).First();
					text = text + " SUCCESS (Quality: " + qualityGradeDetail.GetDescriptionASSlide() + ", Latency: " + latencyGradeDetail.GetDescriptionASSlide() + ")";
				}
				else
				{
					text = text + " FAIL: " + ActiveUnit_CommStuff.GetCommConnectionChecklistEvaluationToHumanString(item2.Value);
				}
				DarkTreeNode darkTreeNode2 = new DarkTreeNode(text);
				if (flag)
				{
					darkTreeNode2.ForeColor = Color.LimeGreen;
				}
				else
				{
					darkTreeNode2.ForeColor = Color.Red;
				}
				darkTreeNode.Nodes.Add(darkTreeNode2);
			}
			Module1.ExpandAll(DTV_CommResults);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while running the comm check." + Environment.NewLine + ex2.Message, "Error 32135465132134");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_27(object sender, EventArgs e)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (Client.SelectedUnit != null && Client.SelectedUnit.IsActiveUnit)
			{
				method_5((ActiveUnit)Client.SelectedUnit);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while selecting the first unit." + Environment.NewLine + ex2.Message, "Error32135465132135");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_28(object sender, EventArgs e)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (Client.SelectedUnit != null && Client.SelectedUnit.IsActiveUnit)
			{
				method_8((ActiveUnit)Client.SelectedUnit);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while selecting the second unit." + Environment.NewLine + ex2.Message, "Error32135465132136");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_29()
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			method_5(null);
			method_8(null);
			method_30();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while resetting the comm tool." + Environment.NewLine + ex2.Message, "Error32135465132137");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_30()
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			DTV_CommResults.Nodes.Clear();
			CommDeviceFeedback.Clear();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while resetting the results view." + Environment.NewLine + ex2.Message, "Error32135465132138");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_31()
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			list_0 = null;
			DLV_Networks.Items.Clear();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while resetting the network working copy." + Environment.NewLine + ex2.Message, "Error32135465132139");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void CommData_VisibleChanged(object sender, EventArgs e)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			method_29();
			if (!((Control)this).Visible)
			{
				method_31();
				return;
			}
			ReloadNetworks();
			if (((TabControl)TabConnectionCheckTool).SelectedTab == TabNetworkView)
			{
				NetworkViewTab.LoadFromCurrentSide();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while handling the visibility change." + Environment.NewLine + ex2.Message, "Error32135465132140");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_32(object sender, EventArgs e)
	{
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (Client.CurrentSide.NetworkRuleRegistry == null)
			{
				Client.CurrentSide.NetworkRuleRegistry = NetworkRuleRegistry.BuildDefaults();
			}
			NetworkRuleEditorForm networkRuleEditorForm = new NetworkRuleEditorForm(Client.CurrentSide.NetworkRuleRegistry);
			try
			{
				((Form)networkRuleEditorForm).ShowDialog();
			}
			finally
			{
				((IDisposable)networkRuleEditorForm)?.Dispose();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while opening the Network Rule Editor." + Environment.NewLine + ex2.Message, "Error32135465132141");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_33(object sender, EventArgs e)
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (((TabControl)TabConnectionCheckTool).SelectedTab == TabNetworkView)
			{
				NetworkViewTab.LoadFromCurrentSide();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while changing tabs." + Environment.NewLine + ex2.Message, "Error32135465132142");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	static CommData()
	{
		Class72.smethod_20();
	}
}
