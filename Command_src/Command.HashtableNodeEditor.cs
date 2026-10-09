using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.My;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class HashtableNodeEditor : DarkSecondaryFormBase
{
	public class NavigationHistoryItem
	{
		public HashtableNodeEditor ParentUI;

		public Hashtable AssociatedTable;

		public HashtableNode AssociatedNode;

		public HashTable_Row AssociatedRow;

		public static void Add(IRamDBHash _Assoc, HashtableNodeEditor _ParentUI)
		{
			NavigationHistoryItem navigationHistoryItem = new NavigationHistoryItem();
			navigationHistoryItem.ParentUI = _ParentUI;
			navigationHistoryItem.AssociatedTable = _Assoc.TableInstance;
			navigationHistoryItem.AssociatedNode = _Assoc.NodeInstance;
			navigationHistoryItem.AssociatedRow = _Assoc.RowInstance;
			_ParentUI.NavigationHistory.Add(navigationHistoryItem);
			_ParentUI.NavigationHistoryCurrentIndex = _ParentUI.NavigationHistory.Count - 1;
			_ParentUI.RefreshHistoryButtons();
		}

		public void ExecuteHistory()
		{
			if (AssociatedNode == null)
			{
				if (AssociatedTable == null)
				{
					if (AssociatedRow != null)
					{
						ParentUI.SelectedRow = AssociatedRow;
					}
				}
				else
				{
					ParentUI.SelectedTable = AssociatedTable;
				}
			}
			else
			{
				ParentUI.SelectedNode = AssociatedNode;
			}
		}

		static NavigationHistoryItem()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[AccessedThroughProperty("Button_Target")]
	[CompilerGenerated]
	private DarkButton _Button_Target;

	[AccessedThroughProperty("Button_Source")]
	[CompilerGenerated]
	private DarkButton _Button_Source;

	[AccessedThroughProperty("DGVMain")]
	[CompilerGenerated]
	private DataGridView _DGVMain;

	[AccessedThroughProperty("DuplicateWindow")]
	[CompilerGenerated]
	private DarkButton _DuplicateWindow;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonHistoryBack")]
	private DarkButton _ButtonHistoryBack;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonHistoryNext")]
	private DarkButton _ButtonHistoryNext;

	[AccessedThroughProperty("ButtonCopyOver")]
	[CompilerGenerated]
	private DarkButton _ButtonCopyOver;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonFetchSimilar")]
	private DarkButton _ButtonFetchSimilar;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonFetchSimilarExternal")]
	private DarkButton _ButtonFetchSimilarExternal;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_SImilarityThreshold")]
	private TrackBar _TB_SImilarityThreshold;

	private CopyOver copyOver_0;

	private HashTable_Row hashTable_Row_0;

	public List<NavigationHistoryItem> NavigationHistory;

	public int _NavigationHistoryCurrentIndex;

	public Ram_Database RamDb;

	private Hashtable hashtable_0;

	private HashtableNode hashtableNode_0;

	[field: AccessedThroughProperty("NodesList")]
	internal virtual FlowLayoutPanel NodesList { get; set; }

	[field: AccessedThroughProperty("GroupBox1")]
	internal virtual DarkGroupBox GroupBox1 { get; set; }

	internal virtual DarkButton Button_Target
	{
		[CompilerGenerated]
		get
		{
			return _Button_Target;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_4;
			DarkButton darkButton = _Button_Target;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_Target = value;
			darkButton = _Button_Target;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkButton Button_Source
	{
		[CompilerGenerated]
		get
		{
			return _Button_Source;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			DarkButton darkButton = _Button_Source;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_Source = value;
			darkButton = _Button_Source;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("GroupBox2")]
	internal virtual DarkGroupBox GroupBox2 { get; set; }

	[field: AccessedThroughProperty("TableList")]
	internal virtual FlowLayoutPanel TableList { get; set; }

	[field: AccessedThroughProperty("Button3")]
	internal virtual DarkButton Button3 { get; set; }

	[field: AccessedThroughProperty("Button4")]
	internal virtual DarkButton Button4 { get; set; }

	[field: AccessedThroughProperty("Button5")]
	internal virtual DarkButton Button5 { get; set; }

	[field: AccessedThroughProperty("Button6")]
	internal virtual DarkButton Button6 { get; set; }

	[field: AccessedThroughProperty("Button7")]
	internal virtual DarkButton Button7 { get; set; }

	[field: AccessedThroughProperty("Button8")]
	internal virtual DarkButton Button8 { get; set; }

	[field: AccessedThroughProperty("Button9")]
	internal virtual DarkButton Button9 { get; set; }

	[field: AccessedThroughProperty("Button10")]
	internal virtual DarkButton Button10 { get; set; }

	[field: AccessedThroughProperty("Button11")]
	internal virtual DarkButton Button11 { get; set; }

	[field: AccessedThroughProperty("Button12")]
	internal virtual DarkButton Button12 { get; set; }

	[field: AccessedThroughProperty("Button13")]
	internal virtual DarkButton Button13 { get; set; }

	[field: AccessedThroughProperty("Button14")]
	internal virtual DarkButton Button14 { get; set; }

	[field: AccessedThroughProperty("Button15")]
	internal virtual DarkButton Button15 { get; set; }

	[field: AccessedThroughProperty("Button16")]
	internal virtual DarkButton Button16 { get; set; }

	[field: AccessedThroughProperty("Button17")]
	internal virtual DarkButton Button17 { get; set; }

	[field: AccessedThroughProperty("Button18")]
	internal virtual DarkButton Button18 { get; set; }

	internal virtual DataGridView DGVMain
	{
		[CompilerGenerated]
		get
		{
			return _DGVMain;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			DataGridViewCellEventHandler val = new DataGridViewCellEventHandler(method_2);
			DataGridView val2 = _DGVMain;
			if (val2 != null)
			{
				val2.CellContentClick -= val;
			}
			_DGVMain = value;
			val2 = _DGVMain;
			if (val2 != null)
			{
				val2.CellContentClick += val;
			}
		}
	}

	[field: AccessedThroughProperty("FlowLayoutPanel3")]
	internal virtual FlowLayoutPanel FlowLayoutPanel3 { get; set; }

	internal virtual DarkButton DuplicateWindow
	{
		[CompilerGenerated]
		get
		{
			return _DuplicateWindow;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_7;
			DarkButton darkButton = _DuplicateWindow;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_DuplicateWindow = value;
			darkButton = _DuplicateWindow;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("GroupBox3")]
	internal virtual DarkGroupBox GroupBox3 { get; set; }

	[field: AccessedThroughProperty("RowView")]
	internal virtual FlowLayoutPanel RowView { get; set; }

	[field: AccessedThroughProperty("RamDBPairLabel")]
	internal virtual DarkLabel RamDBPairLabel { get; set; }

	[field: AccessedThroughProperty("SelectedNodeLabel")]
	internal virtual DarkLabel SelectedNodeLabel { get; set; }

	[field: AccessedThroughProperty("SelectedRowLabel")]
	internal virtual DarkLabel SelectedRowLabel { get; set; }

	[field: AccessedThroughProperty("GroupBox4")]
	internal virtual DarkGroupBox GroupBox4 { get; set; }

	[field: AccessedThroughProperty("SelectedTableLabel")]
	internal virtual DarkLabel SelectedTableLabel { get; set; }

	[field: AccessedThroughProperty("DGV_Row")]
	internal virtual DataGridView DGV_Row { get; set; }

	internal virtual DarkButton ButtonHistoryBack
	{
		[CompilerGenerated]
		get
		{
			return _ButtonHistoryBack;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_5;
			DarkButton darkButton = _ButtonHistoryBack;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_ButtonHistoryBack = value;
			darkButton = _ButtonHistoryBack;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkButton ButtonHistoryNext
	{
		[CompilerGenerated]
		get
		{
			return _ButtonHistoryNext;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_6;
			DarkButton darkButton = _ButtonHistoryNext;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_ButtonHistoryNext = value;
			darkButton = _ButtonHistoryNext;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkButton ButtonCopyOver
	{
		[CompilerGenerated]
		get
		{
			return _ButtonCopyOver;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_8;
			DarkButton darkButton = _ButtonCopyOver;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_ButtonCopyOver = value;
			darkButton = _ButtonCopyOver;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkButton ButtonFetchSimilar
	{
		[CompilerGenerated]
		get
		{
			return _ButtonFetchSimilar;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_9;
			DarkButton darkButton = _ButtonFetchSimilar;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_ButtonFetchSimilar = value;
			darkButton = _ButtonFetchSimilar;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkButton ButtonFetchSimilarExternal
	{
		[CompilerGenerated]
		get
		{
			return _ButtonFetchSimilarExternal;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_10;
			DarkButton darkButton = _ButtonFetchSimilarExternal;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_ButtonFetchSimilarExternal = value;
			darkButton = _ButtonFetchSimilarExternal;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("ToggleComparisonResolution")]
	internal virtual DarkLabel ToggleComparisonResolution { get; set; }

	internal virtual TrackBar TB_SImilarityThreshold
	{
		[CompilerGenerated]
		get
		{
			return _TB_SImilarityThreshold;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_12;
			TrackBar val = _TB_SImilarityThreshold;
			if (val != null)
			{
				val.Scroll -= eventHandler;
			}
			_TB_SImilarityThreshold = value;
			val = _TB_SImilarityThreshold;
			if (val != null)
			{
				val.Scroll += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label_SimilarityThreshold")]
	internal virtual DarkLabel Label_SimilarityThreshold { get; set; }

	public int NavigationHistoryCurrentIndex
	{
		get
		{
			return _NavigationHistoryCurrentIndex;
		}
		set
		{
			if (value < 0)
			{
				_NavigationHistoryCurrentIndex = NavigationHistory.Count - 1;
			}
			else if (value > NavigationHistory.Count - 1)
			{
				_NavigationHistoryCurrentIndex = 0;
			}
			if (value > 0 && value < NavigationHistory.Count)
			{
				NavigationHistory.ElementAt(value).ExecuteHistory();
			}
			_NavigationHistoryCurrentIndex = value;
		}
	}

	public HashTable_Row SelectedRow
	{
		get
		{
			return hashTable_Row_0;
		}
		set
		{
			if (hashTable_Row_0 != value)
			{
				hashTable_Row_0 = value;
				Refresh_Row(hashTable_Row_0);
			}
		}
	}

	public Hashtable SelectedTable
	{
		get
		{
			return hashtable_0;
		}
		set
		{
			if (hashtable_0 != value)
			{
				hashtable_0 = value;
				if (hashtable_0 != null)
				{
					SelectedNode = hashtable_0.Node;
				}
				Refresh_Table(hashtable_0);
			}
		}
	}

	public HashtableNode SelectedNode
	{
		get
		{
			return hashtableNode_0;
		}
		set
		{
			if (hashtableNode_0 != value)
			{
				hashtableNode_0 = value;
				Refresh_Node(hashtableNode_0);
			}
		}
	}

	public HashtableNodeEditor()
	{
		((Form)this).Load += HashtableNodeEditor_Load;
		NavigationHistory = new List<NavigationHistoryItem>();
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
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Expected O, but got Unknown
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Expected O, but got Unknown
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Expected O, but got Unknown
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Expected O, but got Unknown
		//IL_0303: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0567: Unknown result type (might be due to invalid IL or missing references)
		//IL_0818: Unknown result type (might be due to invalid IL or missing references)
		//IL_0822: Expected O, but got Unknown
		//IL_0ba6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c29: Unknown result type (might be due to invalid IL or missing references)
		//IL_0caf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d35: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dbb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ec3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fd3: Unknown result type (might be due to invalid IL or missing references)
		//IL_105b: Unknown result type (might be due to invalid IL or missing references)
		//IL_10df: Unknown result type (might be due to invalid IL or missing references)
		//IL_1164: Unknown result type (might be due to invalid IL or missing references)
		//IL_11ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_1274: Unknown result type (might be due to invalid IL or missing references)
		//IL_12fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1419: Unknown result type (might be due to invalid IL or missing references)
		//IL_149d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1524: Unknown result type (might be due to invalid IL or missing references)
		//IL_16f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_17b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_17bd: Expected O, but got Unknown
		//IL_1903: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b16: Unknown result type (might be due to invalid IL or missing references)
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		NodesList = new FlowLayoutPanel();
		Button18 = new DarkButton();
		GroupBox1 = new DarkGroupBox();
		RamDBPairLabel = new DarkLabel();
		Button_Target = new DarkButton();
		Button_Source = new DarkButton();
		GroupBox2 = new DarkGroupBox();
		GroupBox4 = new DarkGroupBox();
		SelectedTableLabel = new DarkLabel();
		DGVMain = new DataGridView();
		SelectedNodeLabel = new DarkLabel();
		TableList = new FlowLayoutPanel();
		Button3 = new DarkButton();
		Button4 = new DarkButton();
		Button5 = new DarkButton();
		Button6 = new DarkButton();
		Button7 = new DarkButton();
		Button8 = new DarkButton();
		Button9 = new DarkButton();
		Button10 = new DarkButton();
		Button11 = new DarkButton();
		Button12 = new DarkButton();
		Button13 = new DarkButton();
		Button14 = new DarkButton();
		Button15 = new DarkButton();
		Button16 = new DarkButton();
		Button17 = new DarkButton();
		FlowLayoutPanel3 = new FlowLayoutPanel();
		DuplicateWindow = new DarkButton();
		ButtonHistoryBack = new DarkButton();
		ButtonHistoryNext = new DarkButton();
		GroupBox3 = new DarkGroupBox();
		ButtonCopyOver = new DarkButton();
		DGV_Row = new DataGridView();
		ButtonFetchSimilarExternal = new DarkButton();
		SelectedRowLabel = new DarkLabel();
		ToggleComparisonResolution = new DarkLabel();
		TB_SImilarityThreshold = new TrackBar();
		ButtonFetchSimilar = new DarkButton();
		RowView = new FlowLayoutPanel();
		Label_SimilarityThreshold = new DarkLabel();
		((Control)NodesList).SuspendLayout();
		((Control)GroupBox1).SuspendLayout();
		((Control)GroupBox2).SuspendLayout();
		((Control)GroupBox4).SuspendLayout();
		((ISupportInitialize)DGVMain).BeginInit();
		((Control)TableList).SuspendLayout();
		((Control)FlowLayoutPanel3).SuspendLayout();
		((Control)GroupBox3).SuspendLayout();
		((ISupportInitialize)DGV_Row).BeginInit();
		((ISupportInitialize)TB_SImilarityThreshold).BeginInit();
		((Control)this).SuspendLayout();
		((Control)NodesList).Anchor = (AnchorStyles)15;
		((ScrollableControl)NodesList).AutoScroll = true;
		((Control)NodesList).Controls.Add((Control)(object)Button18);
		((Control)NodesList).Location = new Point(6, 52);
		((Control)NodesList).Name = "NodesList";
		((Control)NodesList).Size = new Size(227, 487);
		((Control)NodesList).TabIndex = 1;
		((Control)Button18).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button18).Location = new Point(3, 3);
		((Control)Button18).Name = "Button18";
		((Control)Button18).Padding = new Padding(5);
		((Control)Button18).Size = new Size(194, 27);
		((Control)Button18).TabIndex = 5;
		Button18.Text = "Target";
		((Control)GroupBox1).Controls.Add((Control)(object)RamDBPairLabel);
		((Control)GroupBox1).Controls.Add((Control)(object)Button_Target);
		((Control)GroupBox1).Controls.Add((Control)(object)NodesList);
		((Control)GroupBox1).Controls.Add((Control)(object)Button_Source);
		((Control)GroupBox1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroupBox1).Location = new Point(12, 3);
		((Control)GroupBox1).Name = "GroupBox1";
		((Control)GroupBox1).Size = new Size(239, 545);
		((Control)GroupBox1).TabIndex = 2;
		((GroupBox)GroupBox1).TabStop = false;
		((GroupBox)GroupBox1).Text = "Nodes";
		RamDBPairLabel.AutoSize = true;
		((Control)RamDBPairLabel).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)RamDBPairLabel).Location = new Point(100, 0);
		((Control)RamDBPairLabel).Name = "RamDBPairLabel";
		((Control)RamDBPairLabel).Size = new Size(22, 15);
		((Control)RamDBPairLabel).TabIndex = 5;
		((Label)RamDBPairLabel).Text = "---";
		((Control)Button_Target).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_Target).Location = new Point(122, 19);
		((Control)Button_Target).Name = "Button_Target";
		((Control)Button_Target).Padding = new Padding(5);
		((Control)Button_Target).Size = new Size(111, 27);
		((Control)Button_Target).TabIndex = 4;
		Button_Target.Text = "FROM";
		((Control)Button_Source).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_Source).Location = new Point(6, 19);
		((Control)Button_Source).Name = "Button_Source";
		((Control)Button_Source).Padding = new Padding(5);
		((Control)Button_Source).Size = new Size(111, 27);
		((Control)Button_Source).TabIndex = 3;
		Button_Source.Text = "TO";
		((Control)GroupBox2).Controls.Add((Control)(object)GroupBox4);
		((Control)GroupBox2).Controls.Add((Control)(object)SelectedNodeLabel);
		((Control)GroupBox2).Controls.Add((Control)(object)TableList);
		((Control)GroupBox2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroupBox2).Location = new Point(257, 3);
		((Control)GroupBox2).Name = "GroupBox2";
		((Control)GroupBox2).Size = new Size(648, 545);
		((Control)GroupBox2).TabIndex = 5;
		((GroupBox)GroupBox2).TabStop = false;
		((GroupBox)GroupBox2).Text = "Node";
		((Control)GroupBox4).Controls.Add((Control)(object)SelectedTableLabel);
		((Control)GroupBox4).Controls.Add((Control)(object)DGVMain);
		((Control)GroupBox4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroupBox4).Location = new Point(6, 126);
		((Control)GroupBox4).Name = "GroupBox4";
		((Control)GroupBox4).Size = new Size(636, 413);
		((Control)GroupBox4).TabIndex = 7;
		((GroupBox)GroupBox4).TabStop = false;
		((GroupBox)GroupBox4).Text = "Table";
		SelectedTableLabel.AutoSize = true;
		((Control)SelectedTableLabel).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)SelectedTableLabel).Location = new Point(293, 0);
		((Control)SelectedTableLabel).Name = "SelectedTableLabel";
		((Control)SelectedTableLabel).Size = new Size(22, 15);
		((Control)SelectedTableLabel).TabIndex = 6;
		((Label)SelectedTableLabel).Text = "---";
		DGVMain.AllowUserToAddRows = false;
		DGVMain.AllowUserToDeleteRows = false;
		DGVMain.AllowUserToResizeColumns = false;
		DGVMain.AllowUserToResizeRows = false;
		((Control)DGVMain).Anchor = (AnchorStyles)15;
		DGVMain.BackgroundColor = Color.FromArgb(60, 63, 65);
		DGVMain.ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		val.Alignment = (DataGridViewContentAlignment)32;
		val.BackColor = SystemColors.Window;
		val.Font = new Font("Segoe UI", 9f);
		val.ForeColor = Color.FromArgb(220, 220, 220);
		val.SelectionBackColor = SystemColors.Highlight;
		val.SelectionForeColor = SystemColors.ControlText;
		val.WrapMode = (DataGridViewTriState)2;
		DGVMain.DefaultCellStyle = val;
		DGVMain.EditMode = (DataGridViewEditMode)0;
		((Control)DGVMain).Location = new Point(6, 17);
		((Control)DGVMain).Name = "DGVMain";
		DGVMain.RowHeadersVisible = false;
		DGVMain.RowHeadersWidth = 62;
		DGVMain.RowTemplate.DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
		DGVMain.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
		DGVMain.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Black;
		((Control)DGVMain).Size = new Size(624, 390);
		((Control)DGVMain).TabIndex = 3;
		SelectedNodeLabel.AutoSize = true;
		((Control)SelectedNodeLabel).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)SelectedNodeLabel).Location = new Point(293, 0);
		((Control)SelectedNodeLabel).Name = "SelectedNodeLabel";
		((Control)SelectedNodeLabel).Size = new Size(22, 15);
		((Control)SelectedNodeLabel).TabIndex = 6;
		((Label)SelectedNodeLabel).Text = "---";
		((Control)TableList).Anchor = (AnchorStyles)15;
		((ScrollableControl)TableList).AutoScroll = true;
		((Control)TableList).BackColor = Color.FromArgb(60, 63, 65);
		((Control)TableList).Controls.Add((Control)(object)Button3);
		((Control)TableList).Controls.Add((Control)(object)Button4);
		((Control)TableList).Controls.Add((Control)(object)Button5);
		((Control)TableList).Controls.Add((Control)(object)Button6);
		((Control)TableList).Controls.Add((Control)(object)Button7);
		((Control)TableList).Controls.Add((Control)(object)Button8);
		((Control)TableList).Controls.Add((Control)(object)Button9);
		((Control)TableList).Controls.Add((Control)(object)Button10);
		((Control)TableList).Controls.Add((Control)(object)Button11);
		((Control)TableList).Controls.Add((Control)(object)Button12);
		((Control)TableList).Controls.Add((Control)(object)Button13);
		((Control)TableList).Controls.Add((Control)(object)Button14);
		((Control)TableList).Controls.Add((Control)(object)Button15);
		((Control)TableList).Controls.Add((Control)(object)Button16);
		((Control)TableList).Controls.Add((Control)(object)Button17);
		((Control)TableList).Location = new Point(6, 19);
		((Control)TableList).Name = "TableList";
		((Control)TableList).Size = new Size(634, 101);
		((Control)TableList).TabIndex = 2;
		((Control)Button3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button3).Location = new Point(3, 3);
		((Control)Button3).Name = "Button3";
		((Control)Button3).Padding = new Padding(5);
		((Control)Button3).Size = new Size(111, 27);
		((Control)Button3).TabIndex = 4;
		Button3.Text = "Source";
		((Control)Button4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button4).Location = new Point(120, 3);
		((Control)Button4).Name = "Button4";
		((Control)Button4).Padding = new Padding(5);
		((Control)Button4).Size = new Size(111, 27);
		((Control)Button4).TabIndex = 5;
		Button4.Text = "Source";
		((Control)Button5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button5).Location = new Point(237, 3);
		((Control)Button5).Name = "Button5";
		((Control)Button5).Padding = new Padding(5);
		((Control)Button5).Size = new Size(111, 27);
		((Control)Button5).TabIndex = 6;
		Button5.Text = "Source";
		((Control)Button6).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button6).Location = new Point(354, 3);
		((Control)Button6).Name = "Button6";
		((Control)Button6).Padding = new Padding(5);
		((Control)Button6).Size = new Size(111, 27);
		((Control)Button6).TabIndex = 7;
		Button6.Text = "Source";
		((Control)Button7).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button7).Location = new Point(471, 3);
		((Control)Button7).Name = "Button7";
		((Control)Button7).Padding = new Padding(5);
		((Control)Button7).Size = new Size(111, 27);
		((Control)Button7).TabIndex = 8;
		Button7.Text = "Source";
		((Control)Button8).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button8).Location = new Point(3, 36);
		((Control)Button8).Name = "Button8";
		((Control)Button8).Padding = new Padding(5);
		((Control)Button8).Size = new Size(111, 27);
		((Control)Button8).TabIndex = 9;
		Button8.Text = "Source";
		((Control)Button9).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button9).Location = new Point(120, 36);
		((Control)Button9).Name = "Button9";
		((Control)Button9).Padding = new Padding(5);
		((Control)Button9).Size = new Size(111, 27);
		((Control)Button9).TabIndex = 10;
		Button9.Text = "Source";
		((Control)Button10).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button10).Location = new Point(237, 36);
		((Control)Button10).Name = "Button10";
		((Control)Button10).Padding = new Padding(5);
		((Control)Button10).Size = new Size(111, 27);
		((Control)Button10).TabIndex = 11;
		Button10.Text = "Source";
		((Control)Button11).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button11).Location = new Point(354, 36);
		((Control)Button11).Name = "Button11";
		((Control)Button11).Padding = new Padding(5);
		((Control)Button11).Size = new Size(111, 27);
		((Control)Button11).TabIndex = 12;
		Button11.Text = "Source";
		((Control)Button12).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button12).Location = new Point(471, 36);
		((Control)Button12).Name = "Button12";
		((Control)Button12).Padding = new Padding(5);
		((Control)Button12).Size = new Size(111, 27);
		((Control)Button12).TabIndex = 13;
		Button12.Text = "Source";
		((Control)Button13).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button13).Location = new Point(3, 69);
		((Control)Button13).Name = "Button13";
		((Control)Button13).Padding = new Padding(5);
		((Control)Button13).Size = new Size(111, 27);
		((Control)Button13).TabIndex = 14;
		Button13.Text = "Source";
		((Control)Button14).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button14).Location = new Point(120, 69);
		((Control)Button14).Name = "Button14";
		((Control)Button14).Padding = new Padding(5);
		((Control)Button14).Size = new Size(111, 27);
		((Control)Button14).TabIndex = 15;
		Button14.Text = "Source";
		((Control)Button15).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button15).Location = new Point(237, 69);
		((Control)Button15).Name = "Button15";
		((Control)Button15).Padding = new Padding(5);
		((Control)Button15).Size = new Size(111, 27);
		((Control)Button15).TabIndex = 16;
		Button15.Text = "Source";
		((Control)Button16).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button16).Location = new Point(354, 69);
		((Control)Button16).Name = "Button16";
		((Control)Button16).Padding = new Padding(5);
		((Control)Button16).Size = new Size(111, 27);
		((Control)Button16).TabIndex = 17;
		Button16.Text = "Source";
		((Control)Button17).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button17).Location = new Point(471, 69);
		((Control)Button17).Name = "Button17";
		((Control)Button17).Padding = new Padding(5);
		((Control)Button17).Size = new Size(111, 27);
		((Control)Button17).TabIndex = 18;
		Button17.Text = "Source";
		((Control)FlowLayoutPanel3).Anchor = (AnchorStyles)15;
		((Control)FlowLayoutPanel3).Controls.Add((Control)(object)DuplicateWindow);
		((Control)FlowLayoutPanel3).Controls.Add((Control)(object)ButtonHistoryBack);
		((Control)FlowLayoutPanel3).Controls.Add((Control)(object)ButtonHistoryNext);
		((Control)FlowLayoutPanel3).Location = new Point(12, 554);
		((Control)FlowLayoutPanel3).Name = "FlowLayoutPanel3";
		((Control)FlowLayoutPanel3).Size = new Size(885, 39);
		((Control)FlowLayoutPanel3).TabIndex = 19;
		((Control)DuplicateWindow).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DuplicateWindow).Location = new Point(3, 3);
		((Control)DuplicateWindow).Name = "DuplicateWindow";
		((Control)DuplicateWindow).Padding = new Padding(5);
		((Control)DuplicateWindow).Size = new Size(111, 27);
		((Control)DuplicateWindow).TabIndex = 13;
		DuplicateWindow.Text = "Duplicate window";
		((Control)ButtonHistoryBack).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)ButtonHistoryBack).Location = new Point(120, 3);
		((Control)ButtonHistoryBack).Name = "ButtonHistoryBack";
		((Control)ButtonHistoryBack).Padding = new Padding(5);
		((Control)ButtonHistoryBack).Size = new Size(111, 27);
		((Control)ButtonHistoryBack).TabIndex = 14;
		ButtonHistoryBack.Text = "Back";
		((Control)ButtonHistoryNext).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)ButtonHistoryNext).Location = new Point(237, 3);
		((Control)ButtonHistoryNext).Name = "ButtonHistoryNext";
		((Control)ButtonHistoryNext).Padding = new Padding(5);
		((Control)ButtonHistoryNext).Size = new Size(111, 27);
		((Control)ButtonHistoryNext).TabIndex = 15;
		ButtonHistoryNext.Text = "Next";
		((Control)GroupBox3).Controls.Add((Control)(object)ButtonCopyOver);
		((Control)GroupBox3).Controls.Add((Control)(object)DGV_Row);
		((Control)GroupBox3).Controls.Add((Control)(object)ButtonFetchSimilarExternal);
		((Control)GroupBox3).Controls.Add((Control)(object)SelectedRowLabel);
		((Control)GroupBox3).Controls.Add((Control)(object)ToggleComparisonResolution);
		((Control)GroupBox3).Controls.Add((Control)(object)TB_SImilarityThreshold);
		((Control)GroupBox3).Controls.Add((Control)(object)ButtonFetchSimilar);
		((Control)GroupBox3).Controls.Add((Control)(object)RowView);
		((Control)GroupBox3).Controls.Add((Control)(object)Label_SimilarityThreshold);
		((Control)GroupBox3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroupBox3).Location = new Point(911, 3);
		((Control)GroupBox3).Name = "GroupBox3";
		((Control)GroupBox3).Size = new Size(558, 590);
		((Control)GroupBox3).TabIndex = 5;
		((GroupBox)GroupBox3).TabStop = false;
		((GroupBox)GroupBox3).Text = "Row";
		((Control)ButtonCopyOver).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)ButtonCopyOver).Location = new Point(6, 501);
		((Control)ButtonCopyOver).Name = "ButtonCopyOver";
		((Control)ButtonCopyOver).Padding = new Padding(5);
		((Control)ButtonCopyOver).Size = new Size(543, 26);
		((Control)ButtonCopyOver).TabIndex = 13;
		ButtonCopyOver.Text = "Copy over to source";
		DGV_Row.AllowUserToAddRows = false;
		DGV_Row.AllowUserToDeleteRows = false;
		DGV_Row.AllowUserToResizeColumns = false;
		DGV_Row.AllowUserToResizeRows = false;
		((Control)DGV_Row).Anchor = (AnchorStyles)13;
		DGV_Row.BackgroundColor = Color.FromArgb(60, 63, 65);
		DGV_Row.ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		val2.Alignment = (DataGridViewContentAlignment)32;
		val2.BackColor = SystemColors.Window;
		val2.Font = new Font("Segoe UI", 9f);
		val2.ForeColor = Color.FromArgb(220, 220, 220);
		val2.SelectionBackColor = SystemColors.Highlight;
		val2.SelectionForeColor = SystemColors.ControlText;
		val2.WrapMode = (DataGridViewTriState)2;
		DGV_Row.DefaultCellStyle = val2;
		DGV_Row.EditMode = (DataGridViewEditMode)0;
		((Control)DGV_Row).Location = new Point(6, 16);
		((Control)DGV_Row).Name = "DGV_Row";
		DGV_Row.RowHeadersVisible = false;
		DGV_Row.RowHeadersWidth = 62;
		DGV_Row.RowTemplate.DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
		DGV_Row.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
		DGV_Row.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Black;
		((Control)DGV_Row).Size = new Size(546, 75);
		((Control)DGV_Row).TabIndex = 8;
		((Control)ButtonFetchSimilarExternal).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)ButtonFetchSimilarExternal).Location = new Point(9, 531);
		((Control)ButtonFetchSimilarExternal).Name = "ButtonFetchSimilarExternal";
		((Control)ButtonFetchSimilarExternal).Padding = new Padding(5);
		((Control)ButtonFetchSimilarExternal).Size = new Size(152, 27);
		((Control)ButtonFetchSimilarExternal).TabIndex = 16;
		ButtonFetchSimilarExternal.Text = "Fetch Similar in External DB";
		SelectedRowLabel.AutoSize = true;
		((Control)SelectedRowLabel).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)SelectedRowLabel).Location = new Point(253, 0);
		((Control)SelectedRowLabel).Name = "SelectedRowLabel";
		((Control)SelectedRowLabel).Size = new Size(22, 15);
		((Control)SelectedRowLabel).TabIndex = 7;
		((Label)SelectedRowLabel).Text = "---";
		ToggleComparisonResolution.AutoSize = true;
		((Control)ToggleComparisonResolution).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)ToggleComparisonResolution).Location = new Point(268, 558);
		((Control)ToggleComparisonResolution).Name = "ToggleComparisonResolution";
		((Control)ToggleComparisonResolution).Size = new Size(37, 15);
		((Control)ToggleComparisonResolution).TabIndex = 21;
		((Label)ToggleComparisonResolution).Text = "------";
		((Control)ToggleComparisonResolution).Visible = false;
		((Control)TB_SImilarityThreshold).Location = new Point(299, 540);
		TB_SImilarityThreshold.Maximum = 100;
		TB_SImilarityThreshold.Minimum = 10;
		((Control)TB_SImilarityThreshold).Name = "TB_SImilarityThreshold";
		((Control)TB_SImilarityThreshold).Size = new Size(255, 45);
		((Control)TB_SImilarityThreshold).TabIndex = 19;
		TB_SImilarityThreshold.Value = 10;
		((Control)ButtonFetchSimilar).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)ButtonFetchSimilar).Location = new Point(9, 560);
		((Control)ButtonFetchSimilar).Name = "ButtonFetchSimilar";
		((Control)ButtonFetchSimilar).Padding = new Padding(5);
		((Control)ButtonFetchSimilar).Size = new Size(152, 27);
		((Control)ButtonFetchSimilar).TabIndex = 15;
		ButtonFetchSimilar.Text = "Fetch Similar in own DB";
		((Control)RowView).Anchor = (AnchorStyles)13;
		((ScrollableControl)RowView).AutoScroll = true;
		((Control)RowView).BackColor = Color.FromArgb(60, 63, 65);
		((Control)RowView).Location = new Point(6, 97);
		((Control)RowView).Name = "RowView";
		((Control)RowView).Size = new Size(546, 401);
		((Control)RowView).TabIndex = 6;
		Label_SimilarityThreshold.AutoSize = true;
		((Control)Label_SimilarityThreshold).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_SimilarityThreshold).Location = new Point(192, 542);
		((Control)Label_SimilarityThreshold).Name = "Label_SimilarityThreshold";
		((Control)Label_SimilarityThreshold).Size = new Size(117, 15);
		((Control)Label_SimilarityThreshold).TabIndex = 20;
		((Label)Label_SimilarityThreshold).Text = "Similarities threshold";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(7f, 15f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(1477, 605);
		((Control)this).Controls.Add((Control)(object)GroupBox3);
		((Control)this).Controls.Add((Control)(object)GroupBox2);
		((Control)this).Controls.Add((Control)(object)GroupBox1);
		((Control)this).Controls.Add((Control)(object)FlowLayoutPanel3);
		((Form)this).Location = new Point(0, 0);
		((Control)this).Name = "HashtableNodeEditor";
		((Form)this).Text = "HashtableNodeEditor";
		((Control)NodesList).ResumeLayout(false);
		((Control)GroupBox1).ResumeLayout(false);
		((Control)GroupBox1).PerformLayout();
		((Control)GroupBox2).ResumeLayout(false);
		((Control)GroupBox2).PerformLayout();
		((Control)GroupBox4).ResumeLayout(false);
		((Control)GroupBox4).PerformLayout();
		((ISupportInitialize)DGVMain).EndInit();
		((Control)TableList).ResumeLayout(false);
		((Control)FlowLayoutPanel3).ResumeLayout(false);
		((Control)GroupBox3).ResumeLayout(false);
		((Control)GroupBox3).PerformLayout();
		((ISupportInitialize)DGV_Row).EndInit();
		((ISupportInitialize)TB_SImilarityThreshold).EndInit();
		((Control)this).ResumeLayout(false);
	}

	public void Refresh_Row(HashTable_Row Row)
	{
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		((Control)RowView).Controls.Clear();
		((Label)SelectedRowLabel).Text = Row.Name;
		DGV_Row.Rows.Clear();
		DGV_Row.Columns.Clear();
		DGV_Row.AutoGenerateColumns = false;
		((Control)ButtonCopyOver).Visible = copyOver_0.TargetDB_Ram == RamDb && Row.ParentHashTable.Node != null;
		foreach (KeyValuePair<string, HashTable_Field> fieldsByColumn in Row.FieldsByColumns)
		{
			DataGridViewTextBoxColumn val = new DataGridViewTextBoxColumn();
			((DataGridViewColumn)val).HeaderText = fieldsByColumn.Key;
			((DataGridViewColumn)val).Name = fieldsByColumn.Key;
			((DataGridViewColumn)val).ReadOnly = true;
			((DataGridViewColumn)val).Resizable = (DataGridViewTriState)(-1);
			DGV_Row.Columns.Add((DataGridViewColumn)(object)val);
		}
		int num = DGV_Row.Rows.Add();
		DataGridViewRow val2 = DGV_Row.Rows[num];
		foreach (KeyValuePair<string, HashTable_Field> fieldsByColumn2 in Row.FieldsByColumns)
		{
			val2.Cells[fieldsByColumn2.Key].Value = fieldsByColumn2.Value.Value;
		}
		foreach (string component in Row.ParentHashTable.Node.Components)
		{
			NodeEditorRowItem nodeEditorRowItem = new NodeEditorRowItem();
			nodeEditorRowItem.ParentUI = this;
			nodeEditorRowItem.RefreshRow(Row.ParentHashTable.Node.Hashtables[component], Row.GetID(), this);
			((Control)RowView).Controls.Add((Control)(object)nodeEditorRowItem);
		}
	}

	private void method_2(object sender, DataGridViewCellEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		DataGridView val = (DataGridView)sender;
		if (val.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
		{
			DataGridViewRow val2 = val.Rows[e.RowIndex];
			object obj = null;
			if (DGVMain.Columns.Contains("ID"))
			{
				obj = (HashTable_Row)val2.Cells["ID"].Tag;
			}
			else if (DGVMain.Columns.Contains("ComponentID"))
			{
				obj = (HashTable_Row)val2.Cells["ComponentID"].Tag;
			}
			if (obj != null)
			{
				Refresh_Row((HashTable_Row)obj);
				NavigationHistoryItem.Add((IRamDBHash)obj, this);
			}
		}
	}

	public void Refresh_Table(Hashtable hashtable, HashSet<string> hashSet_0 = null)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected O, but got Unknown
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		DGVMain.Rows.Clear();
		DGVMain.Columns.Clear();
		if (hashtable != null)
		{
			((Label)SelectedTableLabel).Text = hashtable.Name;
			DGVMain.AutoGenerateColumns = false;
			bool flag = default(bool);
			bool flag2 = default(bool);
			foreach (string item in hashtable.ColumnsHeader)
			{
				if (Operators.CompareString(item, "ID", true) == 0)
				{
					DataGridViewButtonColumn val = new DataGridViewButtonColumn();
					((DataGridViewColumn)val).HeaderText = item;
					((DataGridViewColumn)val).Name = item;
					((DataGridViewColumn)val).ReadOnly = true;
					((DataGridViewColumn)val).Resizable = (DataGridViewTriState)(-1);
					DGVMain.Columns.Add((DataGridViewColumn)(object)val);
					flag = true;
				}
				else if (Operators.CompareString(item, "ComponentID", true) == 0)
				{
					DataGridViewButtonColumn val2 = new DataGridViewButtonColumn();
					((DataGridViewColumn)val2).HeaderText = item;
					((DataGridViewColumn)val2).Name = item;
					((DataGridViewColumn)val2).ReadOnly = true;
					((DataGridViewColumn)val2).Resizable = (DataGridViewTriState)(-1);
					DGVMain.Columns.Add((DataGridViewColumn)(object)val2);
					flag2 = true;
				}
				else
				{
					DataGridViewTextBoxColumn val3 = new DataGridViewTextBoxColumn();
					((DataGridViewColumn)val3).HeaderText = item;
					((DataGridViewColumn)val3).Name = item;
					((DataGridViewColumn)val3).ReadOnly = true;
					((DataGridViewColumn)val3).Resizable = (DataGridViewTriState)(-1);
					DGVMain.Columns.Add((DataGridViewColumn)(object)val3);
				}
			}
			{
				foreach (KeyValuePair<string, List<HashTable_Row>> row in hashtable.Rows)
				{
					if (hashSet_0 != null && !hashSet_0.Contains(row.Key))
					{
						continue;
					}
					foreach (HashTable_Row item2 in row.Value)
					{
						int num = DGVMain.Rows.Add();
						DataGridViewRow val4 = DGVMain.Rows[num];
						foreach (KeyValuePair<string, HashTable_Field> fieldsByColumn in item2.FieldsByColumns)
						{
							val4.Cells[fieldsByColumn.Key].Value = fieldsByColumn.Value.Value;
						}
						if (flag)
						{
							val4.Cells["ID"].Tag = item2;
						}
						if (flag2)
						{
							HashTable_Row componentData = item2.ParentHashTable.GetComponentData(item2.GetComponentOrCodeID());
							if (componentData != null)
							{
								val4.Cells["ComponentID"].Tag = componentData;
								val4.Cells["ComponentID"].Value = componentData.Name;
							}
						}
					}
				}
				return;
			}
		}
		((Label)SelectedRowLabel).Text = "";
	}

	public void Refresh_Node(HashtableNode Node)
	{
		((Control)TableList).Controls.Clear();
		if (Node == null)
		{
			((Label)SelectedNodeLabel).Text = "";
			return;
		}
		((Label)SelectedNodeLabel).Text = Node.DisplayName;
		foreach (KeyValuePair<string, Hashtable> hashtable in Node.Hashtables)
		{
			NodeItem nodeItem = new NodeItem();
			nodeItem.ParentUI = this;
			nodeItem.AssociatedTable = hashtable.Value;
			((Control)TableList).Controls.Add((Control)(object)nodeItem);
		}
		if (Node.Hashtables.Count > 0)
		{
			Refresh_Table(Node.Hashtables.ElementAt(0).Value);
		}
	}

	public void Refresh_AllNodes(bool ShowSource)
	{
		RamDb = copyOver_0.SourceDB_Ram;
		((Label)RamDBPairLabel).Text = "TO (" + copyOver_0.SourceDB_Ram.Name + ")";
		if (!ShowSource)
		{
			RamDb = copyOver_0.TargetDB_Ram;
			((Label)RamDBPairLabel).Text = "FROM (" + copyOver_0.TargetDB_Ram.Name + ")";
		}
		((Control)NodesList).Controls.Clear();
		foreach (KeyValuePair<string, HashtableNode> item in RamDb.Tables_Node)
		{
			if (item.Value.ParentType == Table_Type.Primary)
			{
				NodeItem nodeItem = new NodeItem();
				nodeItem.ParentUI = this;
				nodeItem.AssociatedNode = item.Value;
				((Control)NodesList).Controls.Add((Control)(object)nodeItem);
			}
		}
		if (RamDb.Tables_Node.Count > 0)
		{
			Refresh_Node(RamDb.Tables_Node.ElementAt(0).Value);
		}
	}

	public void Refresh_Global(CopyOver RamDbCO, bool ShowSource = true)
	{
		copyOver_0 = RamDbCO;
		((Control)NodesList).Controls.Clear();
		((Control)TableList).Controls.Clear();
		DGVMain.Rows.Clear();
		Refresh_AllNodes(ShowSource);
	}

	private void method_3(object sender, EventArgs e)
	{
		Refresh_AllNodes(ShowSource: true);
	}

	private void method_4(object sender, EventArgs e)
	{
		Refresh_AllNodes(ShowSource: false);
	}

	public void RefreshHistoryButtons()
	{
	}

	private void method_5(object sender, EventArgs e)
	{
		NavigationHistoryCurrentIndex--;
	}

	private void method_6(object sender, EventArgs e)
	{
		NavigationHistoryCurrentIndex++;
	}

	private void method_7(object sender, EventArgs e)
	{
		HashtableNodeEditor hashtableNodeEditor = new HashtableNodeEditor();
		hashtableNodeEditor.Refresh_Global(copyOver_0);
		hashtableNodeEditor.SelectedRow = SelectedRow;
		hashtableNodeEditor.SelectedTable = SelectedTable;
		((Control)hashtableNodeEditor).Show();
	}

	private void method_8(object sender, EventArgs e)
	{
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Invalid comparison between Unknown and I4
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		if (SelectedRow != null)
		{
			string name = SelectedRow.ParentHashTable.Node.ParentHashtable.Name;
			HashTableNode_Pair hashTableNode_Pair = new HashTableNode_Pair(copyOver_0.SourceDB_Ram.Tables_Node[name], copyOver_0.TargetDB_Ram.Tables_Node[name], SelectedRow.ParentHashTable.Node.DisplayName, copyOver_0.SourceDB_Ram, copyOver_0.TargetDB_Ram);
			int num = -1;
			num = hashTableNode_Pair.CopyOver(MyProject.Forms.DBToolsForm.MergeMethod, SelectedRow.RowInstance.GetID(), copyOver_0, null, IgnoreDoublePointerHandling: false, PerformDuplicatePrompt: true, InvertedSimilarityQuery: false, IncludePrimaryInsertion: true, IsExplicitCopyOver: true);
			if (num == -1)
			{
				MessageBox.Show("The node's row copy-over has failed ", "ERROR", (MessageBoxButtons)0, (MessageBoxIcon)16);
			}
			else if ((int)MessageBox.Show("The selected node's row and children has been copied over to ID #" + num + ", would you like display it ?", "Copy over successful", (MessageBoxButtons)4, (MessageBoxIcon)64) == 6)
			{
				HashtableNodeEditor hashtableNodeEditor = new HashtableNodeEditor();
				hashtableNodeEditor.Refresh_Global(copyOver_0);
				hashtableNodeEditor.SelectedRow = copyOver_0.SourceDB_Ram.Tables_Node[name].ParentHashtable.GetRowsByID(num.ToString()).ElementAt(0);
				((Control)hashtableNodeEditor).Show();
			}
		}
	}

	private void method_9(object sender, EventArgs e)
	{
		if (SelectedRow == null)
		{
			return;
		}
		string name = SelectedRow.ParentHashTable.Name;
		Dictionary<HashTable_Row, float> dictionary = new HashTable_Pair(SelectedRow.ParentHashTable, copyOver_0.TargetDB_Ram.Tables[name]).FetchSimilarRows(SelectedRow, SearchInSource: true, (float)TB_SImilarityThreshold.Value / 100f);
		HashSet<string> hashSet = new HashSet<string>();
		foreach (KeyValuePair<HashTable_Row, float> item in dictionary)
		{
			hashSet.Add(item.Key.GetID());
		}
		Refresh_Table(SelectedRow.ParentHashTable, hashSet);
	}

	private void method_10(object sender, EventArgs e)
	{
		if (SelectedRow == null)
		{
			return;
		}
		string name = SelectedRow.ParentHashTable.Name;
		Dictionary<HashTable_Row, float> dictionary = new HashTable_Pair(SelectedRow.ParentHashTable, copyOver_0.TargetDB_Ram.Tables[name]).FetchSimilarRows(SelectedRow, SearchInSource: false, (float)TB_SImilarityThreshold.Value / 100f);
		HashSet<string> hashSet = new HashSet<string>();
		foreach (KeyValuePair<HashTable_Row, float> item in dictionary)
		{
			hashSet.Add(item.Key.GetID());
		}
		Refresh_Table(copyOver_0.TargetDB_Ram.Tables[name], hashSet);
	}

	private void method_11()
	{
		((Label)Label_SimilarityThreshold).Text = "Similarities threshold " + TB_SImilarityThreshold.Value + " %";
	}

	private void HashtableNodeEditor_Load(object sender, EventArgs e)
	{
		((Label)ToggleComparisonResolution).Text = TB_SImilarityThreshold.ToString() + "%";
		TB_SImilarityThreshold.Value = 80;
	}

	private void method_12(object sender, EventArgs e)
	{
		method_11();
	}

	static HashtableNodeEditor()
	{
		Class72.smethod_20();
	}
}
