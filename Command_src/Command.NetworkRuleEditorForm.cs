using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using System.Xml;
using Command_Core;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
internal class NetworkRuleEditorForm : DarkSecondaryFormBase
{
	[CompilerGenerated]
	internal sealed class _Closure$__87-0
	{
		public NetworkRule $VB$Local_rule;

		public NetworkRuleEditorForm $VB$Me;

		[SpecialName]
		internal void _Lambda$__0(string v)
		{
			_Closure$__87-1 CS$<>8__locals2 = new _Closure$__87-1
			{
				$VB$NonLocal_$VB$Closure_2 = this,
				$VB$Local_v = v
			};
			$VB$Me.method_5([SpecialName] () =>
			{
				CS$<>8__locals2.$VB$NonLocal_$VB$Closure_2.$VB$Local_rule.Name = CS$<>8__locals2.$VB$Local_v;
			});
		}

		[SpecialName]
		internal void _Lambda$__2(bool v)
		{
			_Closure$__87-2 CS$<>8__locals2 = new _Closure$__87-2
			{
				$VB$NonLocal_$VB$Closure_3 = this,
				$VB$Local_v = v
			};
			$VB$Me.method_5([SpecialName] () =>
			{
				CS$<>8__locals2.$VB$NonLocal_$VB$Closure_3.$VB$Local_rule.Enabled = CS$<>8__locals2.$VB$Local_v;
			});
		}

		[SpecialName]
		internal void _Lambda$__4(string v)
		{
			_Closure$__87-3 CS$<>8__locals2 = new _Closure$__87-3
			{
				$VB$NonLocal_$VB$Closure_4 = this,
				$VB$Local_v = v
			};
			$VB$Me.method_5([SpecialName] () =>
			{
				CS$<>8__locals2.$VB$NonLocal_$VB$Closure_4.$VB$Local_rule.Description = CS$<>8__locals2.$VB$Local_v;
			});
		}

		[SpecialName]
		internal void _Lambda$__6(int v)
		{
			_Closure$__87-4 CS$<>8__locals2 = new _Closure$__87-4
			{
				$VB$NonLocal_$VB$Closure_5 = this,
				$VB$Local_v = v
			};
			$VB$Me.method_5([SpecialName] () =>
			{
				CS$<>8__locals2.$VB$NonLocal_$VB$Closure_5.$VB$Local_rule.Priority = CS$<>8__locals2.$VB$Local_v;
			});
		}

		[SpecialName]
		internal void _Lambda$__8(CommNetwork.NetworkCreationReason v)
		{
			_Closure$__87-5 CS$<>8__locals2 = new _Closure$__87-5
			{
				$VB$NonLocal_$VB$Closure_6 = this,
				$VB$Local_v = v
			};
			$VB$Me.method_5([SpecialName] () =>
			{
				CS$<>8__locals2.$VB$NonLocal_$VB$Closure_6.$VB$Local_rule.Reason = CS$<>8__locals2.$VB$Local_v;
			});
		}

		static _Closure$__87-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__87-1
	{
		public string $VB$Local_v;

		public _Closure$__87-0 $VB$NonLocal_$VB$Closure_2;

		[SpecialName]
		internal void _Lambda$__1()
		{
			$VB$NonLocal_$VB$Closure_2.$VB$Local_rule.Name = $VB$Local_v;
		}

		static _Closure$__87-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__87-19
	{
		public LuaPredicateRule $VB$Local_r;

		public RichTextBox $VB$Local_txtLua;

		public _Closure$__87-0 $VB$NonLocal_$VB$Closure_20;

		public Action $I33;

		[SpecialName]
		internal void _Lambda$__30(int v)
		{
			_Closure$__87-20 CS$<>8__locals2 = new _Closure$__87-20
			{
				$VB$NonLocal_$VB$Closure_21 = this,
				$VB$Local_v = v
			};
			$VB$NonLocal_$VB$Closure_20.$VB$Me.method_5([SpecialName] () =>
			{
				CS$<>8__locals2.$VB$NonLocal_$VB$Closure_21.$VB$Local_r.MinUnitsPerGroup = CS$<>8__locals2.$VB$Local_v;
			});
		}

		[SpecialName]
		internal void _Lambda$__R1(object sender, EventArgs e)
		{
			_Lambda$__32();
		}

		[SpecialName]
		internal void _Lambda$__32()
		{
			$VB$NonLocal_$VB$Closure_20.$VB$Me.method_5(($I33 != null) ? $I33 : ($I33 = [SpecialName] () =>
			{
				$VB$Local_r.LuaBody = $VB$Local_txtLua.Text;
			}));
		}

		[SpecialName]
		internal void _Lambda$__33()
		{
			$VB$Local_r.LuaBody = $VB$Local_txtLua.Text;
		}

		static _Closure$__87-19()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__87-2
	{
		public bool $VB$Local_v;

		public _Closure$__87-0 $VB$NonLocal_$VB$Closure_3;

		[SpecialName]
		internal void _Lambda$__3()
		{
			$VB$NonLocal_$VB$Closure_3.$VB$Local_rule.Enabled = $VB$Local_v;
		}

		static _Closure$__87-2()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__87-20
	{
		public int $VB$Local_v;

		public _Closure$__87-19 $VB$NonLocal_$VB$Closure_21;

		[SpecialName]
		internal void _Lambda$__31()
		{
			$VB$NonLocal_$VB$Closure_21.$VB$Local_r.MinUnitsPerGroup = $VB$Local_v;
		}

		static _Closure$__87-20()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__87-3
	{
		public string $VB$Local_v;

		public _Closure$__87-0 $VB$NonLocal_$VB$Closure_4;

		[SpecialName]
		internal void _Lambda$__5()
		{
			$VB$NonLocal_$VB$Closure_4.$VB$Local_rule.Description = $VB$Local_v;
		}

		static _Closure$__87-3()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__87-4
	{
		public int $VB$Local_v;

		public _Closure$__87-0 $VB$NonLocal_$VB$Closure_5;

		[SpecialName]
		internal void _Lambda$__7()
		{
			$VB$NonLocal_$VB$Closure_5.$VB$Local_rule.Priority = $VB$Local_v;
		}

		static _Closure$__87-4()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__87-5
	{
		public CommNetwork.NetworkCreationReason $VB$Local_v;

		public _Closure$__87-0 $VB$NonLocal_$VB$Closure_6;

		[SpecialName]
		internal void _Lambda$__9()
		{
			$VB$NonLocal_$VB$Closure_6.$VB$Local_rule.Reason = $VB$Local_v;
		}

		static _Closure$__87-5()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__90-0
	{
		public Action<string> $VB$Local_setter;

		static _Closure$__90-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__90-1
	{
		public TextBox $VB$Local_tb;

		public _Closure$__90-0 $VB$NonLocal_$VB$Closure_2;

		[SpecialName]
		internal void _Lambda$__R2(object sender, EventArgs e)
		{
			_Lambda$__0();
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			$VB$NonLocal_$VB$Closure_2.$VB$Local_setter($VB$Local_tb.Text);
		}

		static _Closure$__90-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__91-0
	{
		public Action<bool> $VB$Local_setter;

		static _Closure$__91-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__91-1
	{
		public CheckBox $VB$Local_cb;

		public _Closure$__91-0 $VB$NonLocal_$VB$Closure_2;

		[SpecialName]
		internal void _Lambda$__R3(object sender, EventArgs e)
		{
			_Lambda$__0();
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			$VB$NonLocal_$VB$Closure_2.$VB$Local_setter($VB$Local_cb.Checked);
		}

		static _Closure$__91-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__92-0
	{
		public Action<int> $VB$Local_setter;

		static _Closure$__92-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__92-1
	{
		public NumericUpDown $VB$Local_n;

		public _Closure$__92-0 $VB$NonLocal_$VB$Closure_2;

		[SpecialName]
		internal void _Lambda$__R4(object sender, EventArgs e)
		{
			_Lambda$__0();
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			$VB$NonLocal_$VB$Closure_2.$VB$Local_setter(Convert.ToInt32($VB$Local_n.Value));
		}

		static _Closure$__92-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__93-0
	{
		public Action<double> $VB$Local_setter;

		static _Closure$__93-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__93-1
	{
		public NumericUpDown $VB$Local_n;

		public _Closure$__93-0 $VB$NonLocal_$VB$Closure_2;

		[SpecialName]
		internal void _Lambda$__R5(object sender, EventArgs e)
		{
			_Lambda$__0();
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			$VB$NonLocal_$VB$Closure_2.$VB$Local_setter(Convert.ToDouble($VB$Local_n.Value));
		}

		static _Closure$__93-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__94-0
	{
		public ComboBox $VB$Local_cb;

		public _Closure$__94-1 $VB$NonLocal_$VB$Closure_2;

		[SpecialName]
		internal void _Lambda$__R6(object sender, EventArgs e)
		{
			_Lambda$__0();
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			if ($VB$Local_cb.SelectedItem != null)
			{
				$VB$NonLocal_$VB$Closure_2.$VB$Local_setter($VB$Local_cb.SelectedItem.ToString());
			}
		}

		static _Closure$__94-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__94-1
	{
		public Action<string> $VB$Local_setter;

		static _Closure$__94-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__95-0<$CLS0> where $CLS0 : struct
	{
		public ComboBox $VB$Local_cb;

		public _Closure$__95-1<$CLS0> $VB$NonLocal_$VB$Closure_2;

		private static object object_0;

		public _Closure$__95-0(_Closure$__95-0<$CLS0> arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_cb = arg0.$VB$Local_cb;
			}
		}

		[SpecialName]
		internal void _Lambda$__R7(object sender, EventArgs e)
		{
			_Lambda$__0();
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			if ($VB$Local_cb.SelectedItem != null)
			{
				$CLS0 obj = ($CLS0)Enum.Parse(typeof($CLS0), $VB$Local_cb.SelectedItem.ToString());
				$VB$NonLocal_$VB$Closure_2.$VB$Local_setter(obj);
			}
		}

		static _Closure$__95-0()
		{
			Class72.smethod_20();
		}

		internal static bool smethod_0()
		{
			return object_0 == null;
		}

		internal static object smethod_1()
		{
			return object_0;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__95-1<$CLS0> where $CLS0 : struct
	{
		public Action<$CLS0> $VB$Local_setter;

		internal static object object_0;

		public _Closure$__95-1(_Closure$__95-1<$CLS0> arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_setter = arg0.$VB$Local_setter;
			}
		}

		static _Closure$__95-1()
		{
			Class72.smethod_20();
		}

		internal static bool smethod_0()
		{
			return object_0 == null;
		}

		internal static object smethod_1()
		{
			return object_0;
		}
	}

	private IContainer icontainer_1;

	[AccessedThroughProperty("btnOK")]
	[CompilerGenerated]
	private DarkUIButton YjvbTmdZpj;

	[AccessedThroughProperty("btnResetRules")]
	[CompilerGenerated]
	private DarkUIButton _btnResetRules;

	private NetworkRuleRegistry networkRuleRegistry_0;

	private NetworkRule networkRule_0;

	private bool bool_2;

	[field: AccessedThroughProperty("splitter")]
	internal virtual SplitContainer splitter { get; set; }

	[field: AccessedThroughProperty("lblRulesHeader")]
	internal virtual DarkLabel lblRulesHeader { get; set; }

	[field: AccessedThroughProperty("pnlMoveRow")]
	internal virtual TableLayoutPanel pnlMoveRow { get; set; }

	[field: AccessedThroughProperty("btnMoveUp")]
	internal virtual DarkUIButton btnMoveUp { get; set; }

	[field: AccessedThroughProperty("btnMoveDown")]
	internal virtual DarkUIButton btnMoveDown { get; set; }

	[field: AccessedThroughProperty("lstRules")]
	internal virtual DarkListView lstRules { get; set; }

	[field: AccessedThroughProperty("pnlAddRemove")]
	internal virtual TableLayoutPanel pnlAddRemove { get; set; }

	[field: AccessedThroughProperty("btnAddRule")]
	internal virtual DarkUIButton btnAddRule { get; set; }

	[field: AccessedThroughProperty("btnRemoveRule")]
	internal virtual DarkUIButton btnRemoveRule { get; set; }

	[field: AccessedThroughProperty("pnlDetail")]
	internal virtual Panel pnlDetail { get; set; }

	[field: AccessedThroughProperty("pnlBottom")]
	internal virtual Panel pnlBottom { get; set; }

	[field: AccessedThroughProperty("flowLeft")]
	internal virtual FlowLayoutPanel flowLeft { get; set; }

	[field: AccessedThroughProperty("btnImport")]
	internal virtual DarkUIButton btnImport { get; set; }

	[field: AccessedThroughProperty("btnExport")]
	internal virtual DarkUIButton btnExport { get; set; }

	[field: AccessedThroughProperty("lblStatus")]
	internal virtual DarkLabel lblStatus { get; set; }

	[field: AccessedThroughProperty("flowRight")]
	internal virtual FlowLayoutPanel flowRight { get; set; }

	[field: AccessedThroughProperty("btnCancel")]
	internal virtual DarkUIButton btnCancel { get; set; }

	internal virtual DarkUIButton btnOK
	{
		[CompilerGenerated]
		get
		{
			return YjvbTmdZpj;
		}
		[CompilerGenerated]
		set
		{
			YjvbTmdZpj = value;
		}
	}

	internal virtual DarkUIButton btnResetRules
	{
		[CompilerGenerated]
		get
		{
			return _btnResetRules;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_15;
			DarkUIButton darkUIButton = _btnResetRules;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_btnResetRules = value;
			darkUIButton = _btnResetRules;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
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
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0309: Unknown result type (might be due to invalid IL or missing references)
		//IL_0313: Expected O, but got Unknown
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_032f: Expected O, but got Unknown
		//IL_0395: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ba: Expected O, but got Unknown
		//IL_03cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d6: Expected O, but got Unknown
		//IL_043f: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0562: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c6: Expected O, but got Unknown
		//IL_05d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e2: Expected O, but got Unknown
		//IL_05f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fe: Expected O, but got Unknown
		//IL_067d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0698: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a2: Expected O, but got Unknown
		//IL_070b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0797: Unknown result type (might be due to invalid IL or missing references)
		//IL_0826: Unknown result type (might be due to invalid IL or missing references)
		//IL_0944: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b73: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c82: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d23: Unknown result type (might be due to invalid IL or missing references)
		splitter = new SplitContainer();
		lstRules = new DarkListView();
		pnlMoveRow = new TableLayoutPanel();
		btnMoveUp = new DarkUIButton();
		btnMoveDown = new DarkUIButton();
		lblRulesHeader = new DarkLabel();
		pnlAddRemove = new TableLayoutPanel();
		btnAddRule = new DarkUIButton();
		btnRemoveRule = new DarkUIButton();
		btnResetRules = new DarkUIButton();
		pnlDetail = new Panel();
		pnlBottom = new Panel();
		flowLeft = new FlowLayoutPanel();
		btnImport = new DarkUIButton();
		btnExport = new DarkUIButton();
		lblStatus = new DarkLabel();
		flowRight = new FlowLayoutPanel();
		btnCancel = new DarkUIButton();
		btnOK = new DarkUIButton();
		((ISupportInitialize)splitter).BeginInit();
		((Control)splitter.Panel1).SuspendLayout();
		((Control)splitter.Panel2).SuspendLayout();
		((Control)splitter).SuspendLayout();
		((Control)pnlMoveRow).SuspendLayout();
		((Control)pnlAddRemove).SuspendLayout();
		((Control)pnlBottom).SuspendLayout();
		((Control)flowLeft).SuspendLayout();
		((Control)flowRight).SuspendLayout();
		((Control)this).SuspendLayout();
		splitter.Dock = (DockStyle)5;
		((Control)splitter).Location = new Point(0, 0);
		((Control)splitter).Name = "splitter";
		((Control)splitter.Panel1).Controls.Add((Control)(object)lstRules);
		((Control)splitter.Panel1).Controls.Add((Control)(object)pnlMoveRow);
		((Control)splitter.Panel1).Controls.Add((Control)(object)lblRulesHeader);
		((Control)splitter.Panel1).Controls.Add((Control)(object)pnlAddRemove);
		((Control)splitter.Panel1).Padding = new Padding(4);
		splitter.Panel1MinSize = 200;
		((Control)splitter.Panel2).Controls.Add((Control)(object)pnlDetail);
		((Control)splitter.Panel2).Padding = new Padding(8, 4, 8, 4);
		splitter.Panel2MinSize = 300;
		((Control)splitter).Size = new Size(880, 576);
		splitter.SplitterDistance = 334;
		((Control)splitter).TabIndex = 0;
		((Control)lstRules).Dock = (DockStyle)5;
		lstRules.ItemHeight = 36;
		((Control)lstRules).Location = new Point(4, 64);
		((Control)lstRules).Name = "lstRules";
		lstRules.RelatedInfos = null;
		((Control)lstRules).Size = new Size(326, 472);
		((Control)lstRules).TabIndex = 2;
		pnlMoveRow.ColumnCount = 2;
		pnlMoveRow.ColumnStyles.Add(new ColumnStyle((SizeType)2, 50f));
		pnlMoveRow.ColumnStyles.Add(new ColumnStyle((SizeType)2, 50f));
		((ControlCollection)pnlMoveRow.Controls).Add((Control)(object)btnMoveUp);
		((ControlCollection)pnlMoveRow.Controls).Add((Control)(object)btnMoveDown);
		((Control)pnlMoveRow).Dock = (DockStyle)1;
		((Control)pnlMoveRow).Location = new Point(4, 32);
		((Control)pnlMoveRow).Name = "pnlMoveRow";
		((Control)pnlMoveRow).Padding = new Padding(2, 2, 2, 0);
		pnlMoveRow.RowStyles.Add(new RowStyle((SizeType)1, 30f));
		pnlMoveRow.RowStyles.Add(new RowStyle((SizeType)1, 30f));
		((Control)pnlMoveRow).Size = new Size(326, 32);
		((Control)pnlMoveRow).TabIndex = 1;
		((Control)btnMoveUp).Dock = (DockStyle)5;
		((Control)btnMoveUp).ForeColor = Color.Gainsboro;
		((Control)btnMoveUp).Location = new Point(5, 5);
		((Control)btnMoveUp).Name = "btnMoveUp";
		((Control)btnMoveUp).Padding = new Padding(5);
		btnMoveUp.RoundRadius = 0;
		((Control)btnMoveUp).Size = new Size(155, 24);
		((Control)btnMoveUp).TabIndex = 0;
		btnMoveUp.Text = "▲  Up";
		((Control)btnMoveDown).Dock = (DockStyle)5;
		((Control)btnMoveDown).ForeColor = Color.Gainsboro;
		((Control)btnMoveDown).Location = new Point(166, 5);
		((Control)btnMoveDown).Name = "btnMoveDown";
		((Control)btnMoveDown).Padding = new Padding(5);
		btnMoveDown.RoundRadius = 0;
		((Control)btnMoveDown).Size = new Size(155, 24);
		((Control)btnMoveDown).TabIndex = 1;
		btnMoveDown.Text = "▼  Down";
		((Control)lblRulesHeader).Dock = (DockStyle)1;
		((Control)lblRulesHeader).ForeColor = Color.Gainsboro;
		((Control)lblRulesHeader).Location = new Point(4, 4);
		((Control)lblRulesHeader).Name = "lblRulesHeader";
		((Control)lblRulesHeader).Padding = new Padding(4, 6, 0, 0);
		((Control)lblRulesHeader).Size = new Size(326, 28);
		((Control)lblRulesHeader).TabIndex = 0;
		((Label)lblRulesHeader).Text = "RULES";
		pnlAddRemove.ColumnCount = 3;
		pnlAddRemove.ColumnStyles.Add(new ColumnStyle((SizeType)2, 33.44481f));
		pnlAddRemove.ColumnStyles.Add(new ColumnStyle((SizeType)2, 33.44482f));
		pnlAddRemove.ColumnStyles.Add(new ColumnStyle((SizeType)2, 33.11037f));
		((ControlCollection)pnlAddRemove.Controls).Add((Control)(object)btnAddRule);
		((ControlCollection)pnlAddRemove.Controls).Add((Control)(object)btnRemoveRule);
		((ControlCollection)pnlAddRemove.Controls).Add((Control)(object)btnResetRules);
		((Control)pnlAddRemove).Dock = (DockStyle)2;
		((Control)pnlAddRemove).Location = new Point(4, 536);
		((Control)pnlAddRemove).Name = "pnlAddRemove";
		((Control)pnlAddRemove).Padding = new Padding(2, 4, 2, 0);
		pnlAddRemove.RowStyles.Add(new RowStyle((SizeType)2, 100f));
		((Control)pnlAddRemove).Size = new Size(326, 36);
		((Control)pnlAddRemove).TabIndex = 3;
		((Control)btnAddRule).Dock = (DockStyle)5;
		((Control)btnAddRule).ForeColor = Color.Gainsboro;
		((Control)btnAddRule).Location = new Point(5, 7);
		((Control)btnAddRule).Name = "btnAddRule";
		((Control)btnAddRule).Padding = new Padding(5);
		btnAddRule.RoundRadius = 0;
		((Control)btnAddRule).Size = new Size(101, 26);
		((Control)btnAddRule).TabIndex = 0;
		btnAddRule.Text = "+  Add rule";
		((Control)btnRemoveRule).Dock = (DockStyle)5;
		((Control)btnRemoveRule).ForeColor = Color.Gainsboro;
		((Control)btnRemoveRule).Location = new Point(112, 7);
		((Control)btnRemoveRule).Name = "btnRemoveRule";
		((Control)btnRemoveRule).Padding = new Padding(5);
		btnRemoveRule.RoundRadius = 0;
		((Control)btnRemoveRule).Size = new Size(101, 26);
		((Control)btnRemoveRule).TabIndex = 1;
		btnRemoveRule.Text = "Remove";
		((Control)btnResetRules).Dock = (DockStyle)5;
		((Control)btnResetRules).ForeColor = Color.Gainsboro;
		((Control)btnResetRules).Location = new Point(219, 7);
		((Control)btnResetRules).Name = "btnResetRules";
		((Control)btnResetRules).Padding = new Padding(5);
		btnResetRules.RoundRadius = 0;
		((Control)btnResetRules).Size = new Size(102, 26);
		((Control)btnResetRules).TabIndex = 2;
		btnResetRules.Text = "Reset Rules";
		((ScrollableControl)pnlDetail).AutoScroll = true;
		((Control)pnlDetail).Dock = (DockStyle)5;
		((Control)pnlDetail).ForeColor = Color.Gainsboro;
		((Control)pnlDetail).Location = new Point(8, 4);
		((Control)pnlDetail).Name = "pnlDetail";
		((Control)pnlDetail).Size = new Size(526, 568);
		((Control)pnlDetail).TabIndex = 0;
		((Control)pnlBottom).Controls.Add((Control)(object)flowLeft);
		((Control)pnlBottom).Controls.Add((Control)(object)flowRight);
		((Control)pnlBottom).Dock = (DockStyle)2;
		((Control)pnlBottom).Location = new Point(0, 576);
		((Control)pnlBottom).Name = "pnlBottom";
		((Control)pnlBottom).Padding = new Padding(8, 6, 8, 6);
		((Control)pnlBottom).Size = new Size(880, 44);
		((Control)pnlBottom).TabIndex = 1;
		((Control)flowLeft).Controls.Add((Control)(object)btnImport);
		((Control)flowLeft).Controls.Add((Control)(object)btnExport);
		((Control)flowLeft).Controls.Add((Control)(object)lblStatus);
		((Control)flowLeft).Dock = (DockStyle)5;
		((Control)flowLeft).Location = new Point(8, 6);
		((Control)flowLeft).Name = "flowLeft";
		((Control)flowLeft).Size = new Size(664, 32);
		((Control)flowLeft).TabIndex = 0;
		flowLeft.WrapContents = false;
		((Control)btnImport).ForeColor = Color.Gainsboro;
		((Control)btnImport).Location = new Point(0, 3);
		((Control)btnImport).Margin = new Padding(0, 3, 4, 3);
		((Control)btnImport).Name = "btnImport";
		((Control)btnImport).Padding = new Padding(5);
		btnImport.RoundRadius = 0;
		((Control)btnImport).Size = new Size(96, 26);
		((Control)btnImport).TabIndex = 0;
		btnImport.Text = "Import XML…";
		((Control)btnExport).ForeColor = Color.Gainsboro;
		((Control)btnExport).Location = new Point(100, 3);
		((Control)btnExport).Margin = new Padding(0, 3, 4, 3);
		((Control)btnExport).Name = "btnExport";
		((Control)btnExport).Padding = new Padding(5);
		btnExport.RoundRadius = 0;
		((Control)btnExport).Size = new Size(96, 26);
		((Control)btnExport).TabIndex = 1;
		btnExport.Text = "Export XML…";
		lblStatus.AutoSize = true;
		((Control)lblStatus).ForeColor = Color.Gainsboro;
		((Control)lblStatus).Location = new Point(204, 8);
		((Control)lblStatus).Margin = new Padding(4, 8, 0, 0);
		((Control)lblStatus).Name = "lblStatus";
		((Control)lblStatus).Size = new Size(60, 25);
		((Control)lblStatus).TabIndex = 2;
		((Label)lblStatus).Text = "Ready";
		((Control)flowRight).Controls.Add((Control)(object)btnCancel);
		((Control)flowRight).Controls.Add((Control)(object)btnOK);
		((Control)flowRight).Dock = (DockStyle)4;
		((Control)flowRight).Location = new Point(672, 6);
		((Control)flowRight).Name = "flowRight";
		((Control)flowRight).Size = new Size(200, 32);
		((Control)flowRight).TabIndex = 1;
		flowRight.WrapContents = false;
		((Button)btnCancel).DialogResult = (DialogResult)2;
		((Control)btnCancel).ForeColor = Color.Gainsboro;
		((Control)btnCancel).Location = new Point(3, 3);
		((Control)btnCancel).Margin = new Padding(3, 3, 4, 3);
		((Control)btnCancel).Name = "btnCancel";
		((Control)btnCancel).Padding = new Padding(5);
		btnCancel.RoundRadius = 0;
		((Control)btnCancel).Size = new Size(76, 26);
		((Control)btnCancel).TabIndex = 0;
		btnCancel.Text = "Cancel";
		((Control)btnOK).ForeColor = Color.Gainsboro;
		((Control)btnOK).Location = new Point(86, 3);
		((Control)btnOK).Name = "btnOK";
		((Control)btnOK).Padding = new Padding(5);
		btnOK.RoundRadius = 0;
		((Control)btnOK).Size = new Size(110, 26);
		((Control)btnOK).TabIndex = 1;
		btnOK.Text = "Save Changes";
		((Form)this).AcceptButton = (IButtonControl)(object)btnOK;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(10f, 25f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).CancelButton = (IButtonControl)(object)btnCancel;
		((Form)this).ClientSize = new Size(880, 620);
		((Control)this).Controls.Add((Control)(object)splitter);
		((Control)this).Controls.Add((Control)(object)pnlBottom);
		((Form)this).MinimumSize = new Size(720, 480);
		((Control)this).Name = "NetworkRuleEditorForm";
		((Form)this).StartPosition = (FormStartPosition)4;
		((Form)this).Text = "Network Rule Editor";
		((Control)splitter.Panel1).ResumeLayout(false);
		((Control)splitter.Panel2).ResumeLayout(false);
		((ISupportInitialize)splitter).EndInit();
		((Control)splitter).ResumeLayout(false);
		((Control)pnlMoveRow).ResumeLayout(false);
		((Control)pnlAddRemove).ResumeLayout(false);
		((Control)pnlBottom).ResumeLayout(false);
		((Control)flowLeft).ResumeLayout(false);
		((Control)flowLeft).PerformLayout();
		((Control)flowRight).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
	}

	public NetworkRuleEditorForm(NetworkRuleRegistry registry)
	{
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		lblRulesHeader = new DarkLabel();
		btnMoveUp = new DarkUIButton();
		btnMoveDown = new DarkUIButton();
		lstRules = new DarkListView();
		btnAddRule = new DarkUIButton();
		btnRemoveRule = new DarkUIButton();
		btnImport = new DarkUIButton();
		btnExport = new DarkUIButton();
		lblStatus = new DarkLabel();
		btnCancel = new DarkUIButton();
		btnOK = new DarkUIButton();
		networkRule_0 = null;
		bool_2 = false;
		try
		{
			InitializeComponent_1();
			if (registry != null)
			{
				networkRuleRegistry_0 = registry;
			}
			else
			{
				networkRuleRegistry_0 = NetworkRuleRegistry.BuildDefaults();
			}
			lstRules.MultiSelect = false;
			lstRules.SelectedIndicesChanged += method_3;
			((Control)btnAddRule).Click += method_7;
			((Control)btnRemoveRule).Click += method_9;
			((Control)btnMoveUp).Click += method_10;
			((Control)btnMoveDown).Click += method_11;
			((Control)btnOK).Click += method_12;
			((Control)btnExport).Click += method_13;
			((Control)btnImport).Click += method_14;
			method_2();
			method_6("Ready");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while initializing the Network Rule Editor." + Environment.NewLine + ex2.Message, "Error 3216868731531231200");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	protected override void OnLoad(EventArgs e)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		((Form)this).OnLoad(e);
		try
		{
			splitter.SplitterDistance = 280;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while loading the Network Rule Editor." + Environment.NewLine + ex2.Message, "Error 3216868731531231201");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_2()
	{
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (networkRuleRegistry_0 == null)
			{
				return;
			}
			int num = -1;
			if (lstRules.SelectedIndices.Count > 0)
			{
				num = lstRules.SelectedIndices.First();
			}
			lstRules.Items.Clear();
			foreach (NetworkRule rule in networkRuleRegistry_0.Rules)
			{
				DarkListItem darkListItem = new DarkListItem(rule.Name);
				darkListItem.Tag = rule;
				lstRules.Items.Add(darkListItem);
			}
			if (num >= 0 && num < lstRules.Items.Count)
			{
				lstRules.SelectItem(num);
			}
			else if (lstRules.Items.Count > 0)
			{
				lstRules.SelectItem(0);
			}
			((Control)lstRules).Invalidate();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while refreshing the rules list." + Environment.NewLine + ex2.Message, "Error 3216868731531231202");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_3(object sender, EventArgs e)
	{
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (networkRuleRegistry_0 != null)
			{
				int num = -1;
				if (lstRules.SelectedIndices.Count > 0)
				{
					num = lstRules.SelectedIndices.First();
				}
				if (num >= 0 && num < networkRuleRegistry_0.Rules.Count)
				{
					networkRule_0 = networkRuleRegistry_0.Rules[num];
					method_4(networkRule_0);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while selecting a rule." + Environment.NewLine + ex2.Message, "Error 3216868731531231202");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static string smethod_0(object object_0)
	{
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		string result;
		try
		{
			bool flag = true;
			result = ((object_0 is SameMissionRule) ? "[mission]" : ((flag == object_0 is WithinDistanceRule) ? "[distance]" : ((flag == object_0 is SameUnitTypeRule) ? "[type]" : ((flag != object_0 is LuaPredicateRule) ? "[rule]" : "[lua]"))));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while determining the rule type." + Environment.NewLine + ex2.Message, "Error 3216868731531231203");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = "[rule]";
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void method_4(NetworkRule networkRule_1)
	{
		//IL_081b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected O, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_0309: Unknown result type (might be due to invalid IL or missing references)
		//IL_030e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Expected O, but got Unknown
		//IL_0723: Unknown result type (might be due to invalid IL or missing references)
		//IL_0728: Unknown result type (might be due to invalid IL or missing references)
		//IL_0733: Unknown result type (might be due to invalid IL or missing references)
		//IL_073a: Unknown result type (might be due to invalid IL or missing references)
		//IL_073f: Unknown result type (might be due to invalid IL or missing references)
		//IL_074b: Expected O, but got Unknown
		//IL_0769: Unknown result type (might be due to invalid IL or missing references)
		//IL_076e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0780: Unknown result type (might be due to invalid IL or missing references)
		//IL_078b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0792: Unknown result type (might be due to invalid IL or missing references)
		//IL_0799: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a5: Expected O, but got Unknown
		_Closure$__87-0 CS$<>8__locals37 = new _Closure$__87-0();
		CS$<>8__locals37.$VB$Me = this;
		CS$<>8__locals37.$VB$Local_rule = networkRule_1;
		try
		{
			((Control)pnlDetail).Controls.Clear();
			((ScrollableControl)pnlDetail).AutoScroll = true;
			TableLayoutPanel val = new TableLayoutPanel
			{
				Dock = (DockStyle)1,
				AutoSize = true,
				AutoSizeMode = (AutoSizeMode)0,
				ColumnCount = 2,
				Padding = new Padding(0, 4, 0, 8)
			};
			val.ColumnStyles.Add(new ColumnStyle((SizeType)1, 160f));
			val.ColumnStyles.Add(new ColumnStyle((SizeType)2, 100f));
			int num = 0;
			Label val2 = new Label
			{
				Text = smethod_0(CS$<>8__locals37.$VB$Local_rule).Replace("[", "").Replace("]", "").ToUpper() + " RULE",
				AutoSize = true,
				Margin = new Padding(0, 0, 0, 8)
			};
			val.Controls.Add((Control)(object)val2, 0, 0);
			val.SetColumnSpan((Control)(object)val2, 2);
			num = 1;
			smethod_1(val, 1, "Name", (Control)(object)smethod_3(CS$<>8__locals37.$VB$Local_rule.Name, [SpecialName] (string v) =>
			{
				_Closure$__87-0 closure$__87-4 = CS$<>8__locals37;
				CS$<>8__locals37.$VB$Me.method_5([SpecialName] () =>
				{
					closure$__87-4.$VB$Local_rule.Name = v;
				});
			}));
			num = 2;
			smethod_1(val, 2, "Enabled", (Control)(object)smethod_4(CS$<>8__locals37.$VB$Local_rule.Enabled, [SpecialName] (bool v) =>
			{
				_Closure$__87-0 closure$__87-4 = CS$<>8__locals37;
				CS$<>8__locals37.$VB$Me.method_5([SpecialName] () =>
				{
					closure$__87-4.$VB$Local_rule.Enabled = v;
				});
			}));
			num = 3;
			smethod_1(val, 3, "Description", (Control)(object)smethod_3(CS$<>8__locals37.$VB$Local_rule.Description, [SpecialName] (string v) =>
			{
				_Closure$__87-0 closure$__87-4 = CS$<>8__locals37;
				CS$<>8__locals37.$VB$Me.method_5([SpecialName] () =>
				{
					closure$__87-4.$VB$Local_rule.Description = v;
				});
			}));
			num = 4;
			smethod_1(val, 4, "Priority", (Control)(object)smethod_5(CS$<>8__locals37.$VB$Local_rule.Priority, 0, 999, [SpecialName] (int v) =>
			{
				_Closure$__87-0 closure$__87-4 = CS$<>8__locals37;
				CS$<>8__locals37.$VB$Me.method_5([SpecialName] () =>
				{
					closure$__87-4.$VB$Local_rule.Priority = v;
				});
			}));
			num = 5;
			smethod_1(val, 5, "Network reason", (Control)(object)smethod_8(CS$<>8__locals37.$VB$Local_rule.Reason, [SpecialName] (CommNetwork.NetworkCreationReason v) =>
			{
				_Closure$__87-0 closure$__87-4 = CS$<>8__locals37;
				CS$<>8__locals37.$VB$Me.method_5([SpecialName] () =>
				{
					closure$__87-4.$VB$Local_rule.Reason = v;
				});
			}));
			num = 6;
			bool flag = true;
			if (CS$<>8__locals37.$VB$Local_rule is SameMissionRule)
			{
				_Closure$__87-0 closure$__87- = CS$<>8__locals37;
				SameMissionRule sameMissionRule = (SameMissionRule)closure$__87-.$VB$Local_rule;
				val.Controls.Add((Control)(object)smethod_2("Mission filter"), 0, num);
				val.SetColumnSpan(((ControlCollection)val.Controls)[((ArrangedElementCollection)val.Controls).Count - 1], 2);
				num++;
				smethod_1(val, num, "Mission name filter", (Control)(object)smethod_3(sameMissionRule.MissionNameFilter, [SpecialName] (string v) =>
				{
					closure$__87-.$VB$Me.method_5([SpecialName] () =>
					{
						sameMissionRule.MissionNameFilter = v;
					});
				}));
				num++;
				smethod_1(val, num, "Min units to network", (Control)(object)smethod_5(sameMissionRule.MinUnitsToNetwork, 1, 100, [SpecialName] (int v) =>
				{
					closure$__87-.$VB$Me.method_5([SpecialName] () =>
					{
						sameMissionRule.MinUnitsToNetwork = v;
					});
				}));
				num++;
			}
			else if (flag == CS$<>8__locals37.$VB$Local_rule is SameGroupRule)
			{
				val.Controls.Add((Control)(object)smethod_2("No additional parameters"), 0, num);
				val.SetColumnSpan(((ControlCollection)val.Controls)[((ArrangedElementCollection)val.Controls).Count - 1], 2);
				num++;
				Label val3 = new Label
				{
					Text = "Network units by their parent Group",
					AutoSize = true,
					Margin = new Padding(0, 4, 0, 0)
				};
				val.Controls.Add((Control)(object)val3, 0, num);
				val.SetColumnSpan((Control)(object)val3, 2);
				num++;
			}
			else if (flag == CS$<>8__locals37.$VB$Local_rule is WithinDistanceRule)
			{
				_Closure$__87-0 closure$__87-2 = CS$<>8__locals37;
				WithinDistanceRule withinDistanceRule = (WithinDistanceRule)closure$__87-2.$VB$Local_rule;
				val.Controls.Add((Control)(object)smethod_2("Distance parameters"), 0, num);
				val.SetColumnSpan(((ControlCollection)val.Controls)[((ArrangedElementCollection)val.Controls).Count - 1], 2);
				num++;
				smethod_1(val, num, "Radius (NM)", (Control)(object)smethod_6(withinDistanceRule.RadiusNM, 1.0, 5000.0, [SpecialName] (double v) =>
				{
					closure$__87-2.$VB$Me.method_5([SpecialName] () =>
					{
						withinDistanceRule.RadiusNM = v;
					});
				}));
				num++;
				smethod_1(val, num, "Hub unit (name or GUID)", (Control)(object)smethod_3(withinDistanceRule.HubUnitNameOrGuid, [SpecialName] (string v) =>
				{
					closure$__87-2.$VB$Me.method_5([SpecialName] () =>
					{
						withinDistanceRule.HubUnitNameOrGuid = v;
					});
				}));
				num++;
				smethod_1(val, num, "Hub type filter", (Control)(object)smethod_7(new string[7] { "", "Aircraft", "Ship", "Submarine", "Facility", "AEW", "Tanker" }, withinDistanceRule.HUBtTypeFilter, [SpecialName] (string v) =>
				{
					closure$__87-2.$VB$Me.method_5([SpecialName] () =>
					{
						withinDistanceRule.HUBtTypeFilter = v;
					});
				}));
				num++;
				smethod_1(val, num, "Unit type filter", (Control)(object)smethod_7(new string[7] { "", "Aircraft", "Ship", "Submarine", "Facility", "AEW", "Tanker" }, withinDistanceRule.UnitTypeFilter, [SpecialName] (string v) =>
				{
					closure$__87-2.$VB$Me.method_5([SpecialName] () =>
					{
						withinDistanceRule.UnitTypeFilter = v;
					});
				}));
				num++;
				smethod_1(val, num, "Require comm check", (Control)(object)smethod_4(withinDistanceRule.RequireCommCheck, [SpecialName] (bool v) =>
				{
					closure$__87-2.$VB$Me.method_5([SpecialName] () =>
					{
						withinDistanceRule.RequireCommCheck = v;
					});
				}));
				num++;
				smethod_1(val, num, "Can claim already networked", (Control)(object)smethod_4(withinDistanceRule.CanClaimAlreadyNetworked, [SpecialName] (bool v) =>
				{
					closure$__87-2.$VB$Me.method_5([SpecialName] () =>
					{
						withinDistanceRule.CanClaimAlreadyNetworkedOverride = v;
					});
				}));
				num++;
			}
			else if (flag == CS$<>8__locals37.$VB$Local_rule is SameUnitTypeRule)
			{
				_Closure$__87-0 closure$__87-3 = CS$<>8__locals37;
				SameUnitTypeRule sameUnitTypeRule = (SameUnitTypeRule)closure$__87-3.$VB$Local_rule;
				val.Controls.Add((Control)(object)smethod_2("Type filter"), 0, num);
				val.SetColumnSpan(((ControlCollection)val.Controls)[((ArrangedElementCollection)val.Controls).Count - 1], 2);
				num++;
				smethod_1(val, num, "Target unit type", (Control)(object)smethod_7(new string[6] { "Aircraft", "Ship", "Submarine", "Facility", "AEW", "Tanker" }, sameUnitTypeRule.TargetType, [SpecialName] (string v) =>
				{
					closure$__87-3.$VB$Me.method_5([SpecialName] () =>
					{
						sameUnitTypeRule.TargetType = v;
					});
				}));
				num++;
				smethod_1(val, num, "Split by subtype", (Control)(object)smethod_4(sameUnitTypeRule.SplitBySubtype, [SpecialName] (bool v) =>
				{
					closure$__87-3.$VB$Me.method_5([SpecialName] () =>
					{
						sameUnitTypeRule.SplitBySubtype = v;
					});
				}));
				num++;
			}
			else if (flag == CS$<>8__locals37.$VB$Local_rule is LuaPredicateRule)
			{
				_Closure$__87-19 CS$<>8__locals40 = new _Closure$__87-19();
				CS$<>8__locals40.$VB$NonLocal_$VB$Closure_20 = CS$<>8__locals37;
				CS$<>8__locals40.$VB$Local_r = (LuaPredicateRule)CS$<>8__locals40.$VB$NonLocal_$VB$Closure_20.$VB$Local_rule;
				val.Controls.Add((Control)(object)smethod_2("Lua predicate"), 0, num);
				val.SetColumnSpan(((ControlCollection)val.Controls)[((ArrangedElementCollection)val.Controls).Count - 1], 2);
				num++;
				smethod_1(val, num, "Min units per group", (Control)(object)smethod_5(CS$<>8__locals40.$VB$Local_r.MinUnitsPerGroup, 1, 100, [SpecialName] (int v) =>
				{
					_Closure$__87-19 closure$__87-4 = CS$<>8__locals40;
					CS$<>8__locals40.$VB$NonLocal_$VB$Closure_20.$VB$Me.method_5([SpecialName] () =>
					{
						closure$__87-4.$VB$Local_r.MinUnitsPerGroup = v;
					});
				}));
				num++;
				Label val4 = new Label
				{
					Text = "Lua body",
					AutoSize = true,
					Margin = new Padding(0, 6, 0, 2)
				};
				val.Controls.Add((Control)(object)val4, 0, num);
				val.SetColumnSpan((Control)(object)val4, 2);
				num++;
				CS$<>8__locals40.$VB$Local_txtLua = new RichTextBox
				{
					Text = CS$<>8__locals40.$VB$Local_r.LuaBody,
					Height = 180,
					ScrollBars = (RichTextBoxScrollBars)2,
					BorderStyle = (BorderStyle)1,
					Dock = (DockStyle)5
				};
				((Control)CS$<>8__locals40.$VB$Local_txtLua).TextChanged += [SpecialName] (object sender, EventArgs e) =>
				{
					CS$<>8__locals40._Lambda$__32();
				};
				val.Controls.Add((Control)(object)CS$<>8__locals40.$VB$Local_txtLua, 0, num);
				val.SetColumnSpan((Control)(object)CS$<>8__locals40.$VB$Local_txtLua, 2);
				num++;
			}
			((Control)pnlDetail).Controls.Add((Control)(object)val);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while building the rule detail panel." + Environment.NewLine + ex2.Message, "Error 3216868731531231204");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void smethod_1(TableLayoutPanel tableLayoutPanel_0, int int_0, string string_0, Control control_0)
	{
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		try
		{
			tableLayoutPanel_0.RowStyles.Add(new RowStyle((SizeType)0));
			tableLayoutPanel_0.Controls.Add((Control)new Label
			{
				Text = string_0,
				AutoSize = true,
				Margin = new Padding(0, 7, 8, 0)
			}, 0, int_0);
			control_0.Dock = (DockStyle)5;
			tableLayoutPanel_0.Controls.Add(control_0, 1, int_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while adding a detail row." + Environment.NewLine + ex2.Message, "Error 3216868731531231205");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static Label smethod_2(string string_0)
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		Label result;
		try
		{
			result = new Label
			{
				Text = string_0.ToUpper(),
				AutoSize = true,
				Margin = new Padding(0, 14, 0, 2)
			};
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while creating a section label." + Environment.NewLine + ex2.Message, "Error 3216868731531231206");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Label();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private static TextBox smethod_3(string string_0, Action<string> action_0)
	{
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected O, but got Unknown
		_Closure$__90-0 closure$__90- = new _Closure$__90-0();
		closure$__90-.$VB$Local_setter = action_0;
		TextBox result;
		try
		{
			_Closure$__90-1 CS$<>8__locals5 = new _Closure$__90-1();
			CS$<>8__locals5.$VB$NonLocal_$VB$Closure_2 = closure$__90-;
			CS$<>8__locals5.$VB$Local_tb = new TextBox
			{
				Text = string_0
			};
			((Control)CS$<>8__locals5.$VB$Local_tb).TextChanged += [SpecialName] (object sender, EventArgs e) =>
			{
				CS$<>8__locals5._Lambda$__0();
			};
			result = CS$<>8__locals5.$VB$Local_tb;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while creating a text box." + Environment.NewLine + ex2.Message, "Error 3216868731531231207");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new TextBox();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private static CheckBox smethod_4(bool bool_3, Action<bool> action_0)
	{
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected O, but got Unknown
		_Closure$__91-0 closure$__91- = new _Closure$__91-0();
		closure$__91-.$VB$Local_setter = action_0;
		CheckBox result;
		try
		{
			_Closure$__91-1 CS$<>8__locals5 = new _Closure$__91-1();
			CS$<>8__locals5.$VB$NonLocal_$VB$Closure_2 = closure$__91-;
			CS$<>8__locals5.$VB$Local_cb = new CheckBox
			{
				Checked = bool_3,
				AutoSize = true,
				Text = ""
			};
			CS$<>8__locals5.$VB$Local_cb.CheckedChanged += [SpecialName] (object sender, EventArgs e) =>
			{
				CS$<>8__locals5._Lambda$__0();
			};
			result = CS$<>8__locals5.$VB$Local_cb;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while creating a check box." + Environment.NewLine + ex2.Message, "Error 3216868731531231208");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new CheckBox();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private static NumericUpDown smethod_5(int int_0, int int_1, int int_2, Action<int> action_0)
	{
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		_Closure$__92-0 closure$__92- = new _Closure$__92-0();
		closure$__92-.$VB$Local_setter = action_0;
		NumericUpDown result;
		try
		{
			_Closure$__92-1 CS$<>8__locals5 = new _Closure$__92-1();
			CS$<>8__locals5.$VB$NonLocal_$VB$Closure_2 = closure$__92-;
			CS$<>8__locals5.$VB$Local_n = new NumericUpDown
			{
				Minimum = new decimal(int_1),
				Maximum = new decimal(int_2),
				Value = new decimal(int_0)
			};
			CS$<>8__locals5.$VB$Local_n.ValueChanged += [SpecialName] (object sender, EventArgs e) =>
			{
				CS$<>8__locals5._Lambda$__0();
			};
			result = CS$<>8__locals5.$VB$Local_n;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while creating a numeric control." + Environment.NewLine + ex2.Message, "Error 3216868731531231209");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new NumericUpDown();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private static NumericUpDown smethod_6(double double_0, double double_1, double double_2, Action<double> action_0)
	{
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected O, but got Unknown
		_Closure$__93-0 closure$__93- = new _Closure$__93-0();
		closure$__93-.$VB$Local_setter = action_0;
		NumericUpDown result;
		try
		{
			_Closure$__93-1 CS$<>8__locals9 = new _Closure$__93-1();
			CS$<>8__locals9.$VB$NonLocal_$VB$Closure_2 = closure$__93-;
			double value = Math.Min(Math.Max(double_0, double_1), double_2);
			decimal value2 = new decimal(value);
			CS$<>8__locals9.$VB$Local_n = new NumericUpDown();
			CS$<>8__locals9.$VB$Local_n.Minimum = new decimal(double_1);
			CS$<>8__locals9.$VB$Local_n.Maximum = new decimal(double_2);
			CS$<>8__locals9.$VB$Local_n.DecimalPlaces = 1;
			CS$<>8__locals9.$VB$Local_n.Value = value2;
			CS$<>8__locals9.$VB$Local_n.ValueChanged += [SpecialName] (object sender, EventArgs e) =>
			{
				CS$<>8__locals9._Lambda$__0();
			};
			result = CS$<>8__locals9.$VB$Local_n;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while creating a numeric control." + Environment.NewLine + ex2.Message, "Error 3216868731531231209");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new NumericUpDown();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private static ComboBox smethod_7(object[] object_0, object object_1, Action<string> action_0)
	{
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected O, but got Unknown
		_Closure$__94-1 closure$__94- = new _Closure$__94-1();
		closure$__94-.$VB$Local_setter = action_0;
		ComboBox result;
		try
		{
			_Closure$__94-0 CS$<>8__locals9 = new _Closure$__94-0();
			CS$<>8__locals9.$VB$NonLocal_$VB$Closure_2 = closure$__94-;
			CS$<>8__locals9.$VB$Local_cb = new ComboBox();
			CS$<>8__locals9.$VB$Local_cb.DropDownStyle = (ComboBoxStyle)2;
			CS$<>8__locals9.$VB$Local_cb.Items.AddRange(object_0);
			int num = Array.IndexOf((string[])object_0, (string)object_1);
			if (num < 0)
			{
				CS$<>8__locals9.$VB$Local_cb.SelectedIndex = 0;
			}
			else
			{
				CS$<>8__locals9.$VB$Local_cb.SelectedIndex = num;
			}
			CS$<>8__locals9.$VB$Local_cb.SelectedIndexChanged += [SpecialName] (object sender, EventArgs e) =>
			{
				CS$<>8__locals9._Lambda$__0();
			};
			result = CS$<>8__locals9.$VB$Local_cb;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while creating a combo box." + Environment.NewLine + ex2.Message, "Error 32168687315312312010");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new ComboBox();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private static ComboBox smethod_8<T>(T gparam_0, Action<T> action_0) where T : struct
	{
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		_Closure$__95-1<T> closure$__95- = new _Closure$__95-1<T>(closure$__95-);
		closure$__95-.$VB$Local_setter = action_0;
		ComboBox result;
		try
		{
			_Closure$__95-0<T> arg = default(_Closure$__95-0<T>);
			_Closure$__95-0<T> CS$<>8__locals8 = new _Closure$__95-0<T>(arg);
			CS$<>8__locals8.$VB$NonLocal_$VB$Closure_2 = closure$__95-;
			CS$<>8__locals8.$VB$Local_cb = new ComboBox();
			CS$<>8__locals8.$VB$Local_cb.DropDownStyle = (ComboBoxStyle)2;
			string[] names = Enum.GetNames(typeof(T));
			foreach (string text in names)
			{
				CS$<>8__locals8.$VB$Local_cb.Items.Add((object)text);
			}
			CS$<>8__locals8.$VB$Local_cb.SelectedItem = gparam_0.ToString();
			CS$<>8__locals8.$VB$Local_cb.SelectedIndexChanged += [SpecialName] (object sender, EventArgs e) =>
			{
				CS$<>8__locals8._Lambda$__0();
			};
			result = CS$<>8__locals8.$VB$Local_cb;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while creating an enum combo box." + Environment.NewLine + ex2.Message, "Error 32168687315312312011");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new ComboBox();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void method_5(Action action_0)
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			action_0();
			bool_2 = true;
			method_6("Unsaved changes");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while applying a change." + Environment.NewLine + ex2.Message, "Error 32168687315312312012");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_6(string string_0)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			((Label)lblStatus).Text = string_0;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while updating the status." + Environment.NewLine + ex2.Message, "Error 32168687315312312013");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_7(object sender, EventArgs e)
	{
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Expected O, but got Unknown
		try
		{
			ContextMenuStrip val = new ContextMenuStrip();
			((ToolStrip)val).Items.Add("Same mission", (Image)null, (EventHandler)([SpecialName] (object obj, EventArgs e2) =>
			{
				_Lambda$__98-0();
			}));
			((ToolStrip)val).Items.Add("Within distance", (Image)null, (EventHandler)([SpecialName] (object obj, EventArgs e2) =>
			{
				_Lambda$__98-1();
			}));
			((ToolStrip)val).Items.Add("Same unit type", (Image)null, (EventHandler)([SpecialName] (object obj, EventArgs e2) =>
			{
				_Lambda$__98-2();
			}));
			((ToolStrip)val).Items.Add("Custom Lua predicate", (Image)null, (EventHandler)([SpecialName] (object obj, EventArgs e2) =>
			{
				_Lambda$__98-3();
			}));
			((ToolStrip)val).Items.Add("Same Group", (Image)null, (EventHandler)([SpecialName] (object obj, EventArgs e2) =>
			{
				_Lambda$__98-4();
			}));
			((ToolStripDropDown)val).Show((Control)(object)btnAddRule, new Point(0, -((Control)val).Height - 4));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while showing the add-rule menu." + Environment.NewLine + ex2.Message, "Error 32168687315312312014");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_8(NetworkRule networkRule_1)
	{
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			networkRule_1.Priority = networkRuleRegistry_0.Rules.Count;
			networkRule_1.Name = "New " + smethod_0(networkRule_1).Replace("[", "").Replace("]", "") + " rule";
			networkRuleRegistry_0.Add(networkRule_1);
			bool_2 = true;
			method_2();
			int num = networkRuleRegistry_0.IndexOf(networkRule_1);
			if (num >= 0)
			{
				lstRules.SelectItem(num);
			}
			method_6("Rule added");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while adding the rule." + Environment.NewLine + ex2.Message, "Error 32168687315312312015");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_9(object sender, EventArgs e)
	{
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Invalid comparison between Unknown and I4
		try
		{
			if (networkRule_0 != null && (int)MessageBox.Show("Remove rule \"" + networkRule_0.Name + "\"?", "Confirm remove", (MessageBoxButtons)4, (MessageBoxIcon)32) == 6)
			{
				networkRuleRegistry_0.Remove(networkRule_0);
				networkRule_0 = null;
				((Control)pnlDetail).Controls.Clear();
				bool_2 = true;
				method_2();
				method_6("Rule removed");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while removing the rule." + Environment.NewLine + ex2.Message, "Error 32168687315312312016");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_10(object sender, EventArgs e)
	{
		if (networkRule_0 != null)
		{
			networkRuleRegistry_0.MoveUp(networkRule_0);
			bool_2 = true;
			method_2();
		}
	}

	private void method_11(object sender, EventArgs e)
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (networkRule_0 != null)
			{
				networkRuleRegistry_0.MoveDown(networkRule_0);
				bool_2 = true;
				method_2();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while moving the rule down." + Environment.NewLine + ex2.Message, "Error 32168687315312312018");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_12(object sender, EventArgs e)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			bool_2 = false;
			method_6("Saved");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while saving." + Environment.NewLine + ex2.Message, "Error 32168687315312312019");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_13(object sender, EventArgs e)
	{
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Invalid comparison between Unknown and I4
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		try
		{
			SaveFileDialog val = new SaveFileDialog
			{
				Title = "Export network rules",
				Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*",
				DefaultExt = "xml",
				FileName = "NetworkRules"
			};
			try
			{
				if ((int)((CommonDialog)val).ShowDialog() != 1)
				{
					return;
				}
				try
				{
					XmlWriterSettings val2 = new XmlWriterSettings
					{
						Indent = true,
						IndentChars = "  ",
						Encoding = Encoding.UTF8
					};
					XmlWriter val3 = XmlWriter.Create(((FileDialog)val).FileName, val2);
					try
					{
						networkRuleRegistry_0.ToXML(val3);
					}
					finally
					{
						((IDisposable)val3)?.Dispose();
					}
					method_6("Exported to " + Path.GetFileName(((FileDialog)val).FileName));
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					MessageBox.Show("Export failed: " + ex2.Message, "Error", (MessageBoxButtons)0, (MessageBoxIcon)16);
					ProjectData.ClearProjectError();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			DarkMessageBox.ShowError("An error occurred while exporting the network rules." + Environment.NewLine + ex4.Message, "Error 32168687315312312020");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_14(object sender, EventArgs e)
	{
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Invalid comparison between Unknown and I4
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Invalid comparison between Unknown and I4
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			OpenFileDialog val = new OpenFileDialog
			{
				Title = "Import network rules",
				Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*",
				DefaultExt = "xml"
			};
			try
			{
				if ((int)((CommonDialog)val).ShowDialog() != 1)
				{
					return;
				}
				try
				{
					XmlDocument val2 = new XmlDocument();
					val2.Load(((FileDialog)val).FileName);
					XmlNode val3 = ((XmlNode)val2).SelectSingleNode("NetworkRules");
					if (val3 == null)
					{
						MessageBox.Show("File does not contain a valid NetworkRules element.", "Import error", (MessageBoxButtons)0, (MessageBoxIcon)48);
					}
					else if ((int)MessageBox.Show("This will replace all current rules. Continue?", "Confirm import", (MessageBoxButtons)4, (MessageBoxIcon)32) == 6)
					{
						networkRuleRegistry_0.FromXML(val3);
						networkRule_0 = null;
						((Control)pnlDetail).Controls.Clear();
						bool_2 = true;
						method_2();
						method_6("Imported from " + Path.GetFileName(((FileDialog)val).FileName));
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					MessageBox.Show("Import failed: " + ex2.Message, "Error", (MessageBoxButtons)0, (MessageBoxIcon)16);
					ProjectData.ClearProjectError();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			DarkMessageBox.ShowError("An error occurred while importing the network rules." + Environment.NewLine + ex4.Message, "Error 32168687315312312021");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	protected override void OnFormClosing(FormClosingEventArgs e)
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Invalid comparison between Unknown and I4
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Invalid comparison between Unknown and I4
		try
		{
			if (bool_2 && (int)((Form)this).DialogResult != 1 && (int)MessageBox.Show("You have unsaved changes. Close anyway?", "Unsaved changes", (MessageBoxButtons)4, (MessageBoxIcon)32) == 7)
			{
				((CancelEventArgs)(object)e).Cancel = true;
				return;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while closing the form." + Environment.NewLine + ex2.Message, "Error 32168687315312312022");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		((Form)this).OnFormClosing(e);
	}

	private void method_15(object sender, EventArgs e)
	{
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Invalid comparison between Unknown and I4
		try
		{
			if ((int)MessageBox.Show("All your rules will be deleted and default Network Rules will be created, are you sure about that?", "Confirm Reset", (MessageBoxButtons)4, (MessageBoxIcon)32) == 6)
			{
				networkRuleRegistry_0.Clear();
				networkRule_0 = null;
				((Control)pnlDetail).Controls.Clear();
				networkRuleRegistry_0 = NetworkRuleRegistry.BuildDefaults();
				bool_2 = true;
				method_2();
				method_6("Rules reset to default");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while resetting the rules." + Environment.NewLine + ex2.Message, "Error 32168687315312312023");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private void _Lambda$__98-0()
	{
		method_8(new SameMissionRule());
	}

	[SpecialName]
	[CompilerGenerated]
	private void _Lambda$__98-1()
	{
		method_8(new WithinDistanceRule());
	}

	[SpecialName]
	[CompilerGenerated]
	private void _Lambda$__98-2()
	{
		method_8(new SameUnitTypeRule());
	}

	[SpecialName]
	[CompilerGenerated]
	private void _Lambda$__98-3()
	{
		method_8(new LuaPredicateRule());
	}

	[SpecialName]
	[CompilerGenerated]
	private void _Lambda$__98-4()
	{
		method_8(new SameGroupRule());
	}

	static NetworkRuleEditorForm()
	{
		Class72.smethod_20();
	}
}
