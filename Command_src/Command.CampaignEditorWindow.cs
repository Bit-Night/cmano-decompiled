using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Command_Core;
using Command_Core.LoadSave;
using Command.My;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class CampaignEditorWindow : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[AccessedThroughProperty("DGV_CampaignItems")]
	[CompilerGenerated]
	private DarkDataGridView _DGV_CampaignItems;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_AddScenario")]
	private ToolStripButton _TSB_AddScenario;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_RemoveSelected")]
	private ToolStripButton _TSB_RemoveSelected;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_MoveUp")]
	private ToolStripButton _TSB_MoveUp;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_MoveDown")]
	private ToolStripButton _TSB_MoveDown;

	[AccessedThroughProperty("TSB_Save")]
	[CompilerGenerated]
	private ToolStripButton _TSB_Save;

	[CompilerGenerated]
	[AccessedThroughProperty("OpenFileDialog_AddScen")]
	private OpenFileDialog openFileDialog_0;

	[AccessedThroughProperty("SaveFileDialog_SaveCampaign")]
	[CompilerGenerated]
	private SaveFileDialog saveFileDialog_0;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_Description")]
	private ToolStripButton _TSB_Description;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_AddAttachment")]
	private ToolStripButton _TSB_AddAttachment;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_CampaignEnding")]
	private ToolStripButton _TSB_CampaignEnding;

	[AccessedThroughProperty("TSL_SetScore")]
	[CompilerGenerated]
	private ToolStripButton _TSL_SetScore;

	public Campaign theCampaign;

	public string CampaignFileName;

	private Keys[] keys_0;

	internal virtual DarkDataGridView DGV_CampaignItems
	{
		[CompilerGenerated]
		get
		{
			return _DGV_CampaignItems;
		}
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = method_9;
			DataGridViewCellEventHandler val = new DataGridViewCellEventHandler(method_13);
			DarkDataGridView darkDataGridView = _DGV_CampaignItems;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).SelectionChanged -= eventHandler;
				((DataGridView)darkDataGridView).CellContentClick -= val;
			}
			_DGV_CampaignItems = value;
			darkDataGridView = _DGV_CampaignItems;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).SelectionChanged += eventHandler;
				((DataGridView)darkDataGridView).CellContentClick += val;
			}
		}
	}

	internal virtual ToolStripButton TSB_AddScenario
	{
		[CompilerGenerated]
		get
		{
			return _TSB_AddScenario;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			ToolStripButton val = _TSB_AddScenario;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_TSB_AddScenario = value;
			val = _TSB_AddScenario;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripButton TSB_RemoveSelected
	{
		[CompilerGenerated]
		get
		{
			return _TSB_RemoveSelected;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_4;
			ToolStripButton val = _TSB_RemoveSelected;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_TSB_RemoveSelected = value;
			val = _TSB_RemoveSelected;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripButton TSB_MoveUp
	{
		[CompilerGenerated]
		get
		{
			return _TSB_MoveUp;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_5;
			ToolStripButton val = _TSB_MoveUp;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_TSB_MoveUp = value;
			val = _TSB_MoveUp;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripButton TSB_MoveDown
	{
		[CompilerGenerated]
		get
		{
			return _TSB_MoveDown;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_6;
			ToolStripButton val = _TSB_MoveDown;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_TSB_MoveDown = value;
			val = _TSB_MoveDown;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripButton TSB_Save
	{
		[CompilerGenerated]
		get
		{
			return _TSB_Save;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_7;
			ToolStripButton val = _TSB_Save;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_TSB_Save = value;
			val = _TSB_Save;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual OpenFileDialog OpenFileDialog_AddScen
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

	internal virtual SaveFileDialog SaveFileDialog_SaveCampaign
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

	internal virtual ToolStripButton TSB_Description
	{
		[CompilerGenerated]
		get
		{
			return _TSB_Description;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_8;
			ToolStripButton val = _TSB_Description;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_TSB_Description = value;
			val = _TSB_Description;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripButton TSB_AddAttachment
	{
		[CompilerGenerated]
		get
		{
			return _TSB_AddAttachment;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_10;
			ToolStripButton val = _TSB_AddAttachment;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_TSB_AddAttachment = value;
			val = _TSB_AddAttachment;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripButton TSB_CampaignEnding
	{
		[CompilerGenerated]
		get
		{
			return _TSB_CampaignEnding;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_11;
			ToolStripButton val = _TSB_CampaignEnding;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_TSB_CampaignEnding = value;
			val = _TSB_CampaignEnding;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TS_PassScore")]
	internal virtual DarkToolStrip TS_PassScore { get; set; }

	[field: AccessedThroughProperty("TSL_PassScore")]
	internal virtual ToolStripLabel TSL_PassScore { get; set; }

	[field: AccessedThroughProperty("TSTB_PassScore")]
	internal virtual ToolStripTextBox TSTB_PassScore { get; set; }

	internal virtual ToolStripButton TSL_SetScore
	{
		[CompilerGenerated]
		get
		{
			return _TSL_SetScore;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_12;
			ToolStripButton val = _TSL_SetScore;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_TSL_SetScore = value;
			val = _TSL_SetScore;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Column1")]
	internal virtual DataGridViewTextBoxColumn Column1 { get; set; }

	[field: AccessedThroughProperty("Column2")]
	internal virtual DataGridViewTextBoxColumn Column2 { get; set; }

	[field: AccessedThroughProperty("ScenarioID")]
	internal virtual DataGridViewTextBoxColumn ScenarioID { get; set; }

	[field: AccessedThroughProperty("ChangeScenID")]
	internal virtual DataGridViewButtonColumn ChangeScenID { get; set; }

	[field: AccessedThroughProperty("ToolStrip1")]
	internal virtual DarkToolStrip ToolStrip1 { get; set; }

	public CampaignEditorWindow()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		((Form)this).FormClosing += new FormClosingEventHandler(CampaignEditorWindow_FormClosing);
		((Control)this).VisibleChanged += CampaignEditorWindow_VisibleChanged;
		((Form)this).Load += CampaignEditorWindow_Load;
		keys_0 = (Keys[])(object)new Keys[1] { (Keys)27 };
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
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected O, but got Unknown
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Expected O, but got Unknown
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Expected O, but got Unknown
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected O, but got Unknown
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Expected O, but got Unknown
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected O, but got Unknown
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Expected O, but got Unknown
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Expected O, but got Unknown
		//IL_058b: Unknown result type (might be due to invalid IL or missing references)
		//IL_077a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0784: Expected O, but got Unknown
		//IL_080e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0818: Expected O, but got Unknown
		//IL_08a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ac: Expected O, but got Unknown
		//IL_0936: Unknown result type (might be due to invalid IL or missing references)
		//IL_0940: Expected O, but got Unknown
		//IL_09ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d4: Expected O, but got Unknown
		//IL_0ad2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c27: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c31: Expected O, but got Unknown
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(CampaignEditorWindow));
		DGV_CampaignItems = new DarkDataGridView();
		Column1 = new DataGridViewTextBoxColumn();
		Column2 = new DataGridViewTextBoxColumn();
		ScenarioID = new DataGridViewTextBoxColumn();
		ChangeScenID = new DataGridViewButtonColumn();
		ToolStrip1 = new DarkToolStrip();
		TSB_AddScenario = new ToolStripButton();
		TSB_AddAttachment = new ToolStripButton();
		TSB_RemoveSelected = new ToolStripButton();
		TSB_MoveUp = new ToolStripButton();
		TSB_MoveDown = new ToolStripButton();
		TSB_Description = new ToolStripButton();
		TSB_CampaignEnding = new ToolStripButton();
		TSB_Save = new ToolStripButton();
		OpenFileDialog_AddScen = new OpenFileDialog();
		SaveFileDialog_SaveCampaign = new SaveFileDialog();
		TS_PassScore = new DarkToolStrip();
		TSL_PassScore = new ToolStripLabel();
		TSTB_PassScore = new ToolStripTextBox();
		TSL_SetScore = new ToolStripButton();
		((ISupportInitialize)(object)DGV_CampaignItems).BeginInit();
		((Control)ToolStrip1).SuspendLayout();
		((Control)TS_PassScore).SuspendLayout();
		((Control)this).SuspendLayout();
		((DataGridView)DGV_CampaignItems).AllowUserToAddRows = false;
		((DataGridView)DGV_CampaignItems).AllowUserToDeleteRows = false;
		((DataGridView)DGV_CampaignItems).AllowUserToResizeRows = false;
		((Control)DGV_CampaignItems).Anchor = (AnchorStyles)15;
		((DataGridView)DGV_CampaignItems).BackgroundColor = Color.FromArgb(60, 63, 65);
		((DataGridView)DGV_CampaignItems).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_CampaignItems).CellBorderStyle = (DataGridViewCellBorderStyle)8;
		((DataGridView)DGV_CampaignItems).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val.Alignment = (DataGridViewContentAlignment)16;
		val.BackColor = Color.FromArgb(66, 77, 95);
		val.Font = new Font(Client.CommandDefaultFont.FontFamily, 8f);
		val.ForeColor = Color.LightGray;
		val.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_CampaignItems).ColumnHeadersDefaultCellStyle = val;
		((DataGridView)DGV_CampaignItems).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		((DataGridView)DGV_CampaignItems).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[4]
		{
			(DataGridViewColumn)Column1,
			(DataGridViewColumn)Column2,
			(DataGridViewColumn)ScenarioID,
			(DataGridViewColumn)ChangeScenID
		});
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = Color.FromArgb(60, 63, 65);
		val2.Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val2.ForeColor = Color.LightGray;
		val2.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val2.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_CampaignItems).DefaultCellStyle = val2;
		((DataGridView)DGV_CampaignItems).EditMode = (DataGridViewEditMode)0;
		((DataGridView)DGV_CampaignItems).EnableHeadersVisualStyles = false;
		((DataGridView)DGV_CampaignItems).GridColor = SystemColors.ControlText;
		((Control)DGV_CampaignItems).Location = new Point(2, 28);
		((DataGridView)DGV_CampaignItems).MultiSelect = false;
		((Control)DGV_CampaignItems).Name = "DGV_CampaignItems";
		((DataGridView)DGV_CampaignItems).RowHeadersVisible = false;
		((DataGridView)DGV_CampaignItems).RowHeadersWidth = 10;
		val3.BackColor = Color.FromArgb(60, 63, 65);
		val3.ForeColor = Color.LightGray;
		val3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val3.SelectionForeColor = Color.LightGray;
		((DataGridView)DGV_CampaignItems).RowsDefaultCellStyle = val3;
		((DataGridView)DGV_CampaignItems).SelectionMode = (DataGridViewSelectionMode)1;
		((Control)DGV_CampaignItems).Size = new Size(905, 376);
		((Control)DGV_CampaignItems).TabIndex = 9;
		((DataGridViewColumn)Column1).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Column1).HeaderText = "Name";
		((DataGridViewColumn)Column1).Name = "Column1";
		((DataGridViewColumn)Column1).ReadOnly = true;
		((DataGridViewColumn)Column1).Width = 58;
		((DataGridViewColumn)Column2).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)Column2).HeaderText = "Pass Score";
		((DataGridViewColumn)Column2).Name = "Column2";
		((DataGridViewColumn)Column2).ReadOnly = true;
		((DataGridViewColumn)Column2).Width = 84;
		((DataGridViewColumn)ScenarioID).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		((DataGridViewColumn)ScenarioID).HeaderText = "Scenario ID";
		((DataGridViewColumn)ScenarioID).Name = "ScenarioID";
		((DataGridViewColumn)ScenarioID).ReadOnly = true;
		((DataGridViewColumn)ChangeScenID).HeaderText = "Change ID";
		((DataGridViewColumn)ChangeScenID).Name = "ChangeScenID";
		ChangeScenID.Text = "Change ID";
		((ToolStrip)ToolStrip1).AutoSize = false;
		((ToolStrip)ToolStrip1).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStrip)ToolStrip1).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStrip)ToolStrip1).GripStyle = (ToolStripGripStyle)0;
		((ToolStrip)ToolStrip1).Items.AddRange((ToolStripItem[])(object)new ToolStripItem[8]
		{
			(ToolStripItem)TSB_AddScenario,
			(ToolStripItem)TSB_AddAttachment,
			(ToolStripItem)TSB_RemoveSelected,
			(ToolStripItem)TSB_MoveUp,
			(ToolStripItem)TSB_MoveDown,
			(ToolStripItem)TSB_Description,
			(ToolStripItem)TSB_CampaignEnding,
			(ToolStripItem)TSB_Save
		});
		((Control)ToolStrip1).Location = new Point(0, 0);
		((Control)ToolStrip1).Name = "ToolStrip1";
		((Control)ToolStrip1).Padding = new Padding(5, 0, 1, 0);
		((Control)ToolStrip1).Size = new Size(907, 25);
		((Control)ToolStrip1).TabIndex = 10;
		((Control)ToolStrip1).Text = "ToolStrip1";
		((ToolStripItem)TSB_AddScenario).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_AddScenario).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_AddScenario).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_AddScenario).Name = "TSB_AddScenario";
		((ToolStripItem)TSB_AddScenario).Size = new Size(81, 22);
		((ToolStripItem)TSB_AddScenario).Text = "Add Scenario";
		((ToolStripItem)TSB_AddAttachment).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_AddAttachment).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_AddAttachment).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_AddAttachment).Name = "TSB_AddAttachment";
		((ToolStripItem)TSB_AddAttachment).Size = new Size(99, 22);
		((ToolStripItem)TSB_AddAttachment).Text = "Add Attachment";
		((ToolStripItem)TSB_RemoveSelected).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_RemoveSelected).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_RemoveSelected).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_RemoveSelected).Name = "TSB_RemoveSelected";
		((ToolStripItem)TSB_RemoveSelected).Size = new Size(101, 22);
		((ToolStripItem)TSB_RemoveSelected).Text = "Remove Selected";
		((ToolStripItem)TSB_MoveUp).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_MoveUp).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_MoveUp).Image = (Image)componentResourceManager.GetObject("TSB_MoveUp.Image");
		((ToolStripItem)TSB_MoveUp).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_MoveUp).Name = "TSB_MoveUp";
		((ToolStripItem)TSB_MoveUp).Size = new Size(75, 22);
		((ToolStripItem)TSB_MoveUp).Text = "Move Up";
		((ToolStripItem)TSB_MoveDown).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_MoveDown).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_MoveDown).Image = (Image)componentResourceManager.GetObject("TSB_MoveDown.Image");
		((ToolStripItem)TSB_MoveDown).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_MoveDown).Name = "TSB_MoveDown";
		((ToolStripItem)TSB_MoveDown).Size = new Size(91, 22);
		((ToolStripItem)TSB_MoveDown).Text = "Move Down";
		((ToolStripItem)TSB_Description).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_Description).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_Description).Image = (Image)componentResourceManager.GetObject("TSB_Description.Image");
		((ToolStripItem)TSB_Description).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_Description).Name = "TSB_Description";
		((ToolStripItem)TSB_Description).Size = new Size(124, 22);
		((ToolStripItem)TSB_Description).Text = "Title + Description";
		((ToolStripItem)TSB_CampaignEnding).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_CampaignEnding).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_CampaignEnding).Image = (Image)componentResourceManager.GetObject("TSB_CampaignEnding.Image");
		((ToolStripItem)TSB_CampaignEnding).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_CampaignEnding).Name = "TSB_CampaignEnding";
		((ToolStripItem)TSB_CampaignEnding).Size = new Size(88, 22);
		((ToolStripItem)TSB_CampaignEnding).Text = "Ending Text";
		((ToolStripItem)TSB_Save).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_Save).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_Save).Image = (Image)componentResourceManager.GetObject("TSB_Save.Image");
		((ToolStripItem)TSB_Save).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_Save).Name = "TSB_Save";
		((ToolStripItem)TSB_Save).Size = new Size(109, 22);
		((ToolStripItem)TSB_Save).Text = "Save Campaign";
		((ToolStrip)TS_PassScore).AutoSize = false;
		((ToolStrip)TS_PassScore).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStrip)TS_PassScore).Dock = (DockStyle)2;
		((ToolStrip)TS_PassScore).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStrip)TS_PassScore).GripStyle = (ToolStripGripStyle)0;
		((ToolStrip)TS_PassScore).Items.AddRange((ToolStripItem[])(object)new ToolStripItem[3]
		{
			(ToolStripItem)TSL_PassScore,
			(ToolStripItem)TSTB_PassScore,
			(ToolStripItem)TSL_SetScore
		});
		((Control)TS_PassScore).Location = new Point(0, 407);
		((Control)TS_PassScore).Name = "TS_PassScore";
		((Control)TS_PassScore).Padding = new Padding(5, 0, 1, 0);
		((Control)TS_PassScore).Size = new Size(907, 25);
		((Control)TS_PassScore).TabIndex = 12;
		((Control)TS_PassScore).Text = "ToolStrip2";
		((ToolStripItem)TSL_PassScore).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSL_PassScore).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSL_PassScore).Name = "TSL_PassScore";
		((ToolStripItem)TSL_PassScore).Size = new Size(160, 22);
		((ToolStripItem)TSL_PassScore).Text = "Selected scenario pass-score:";
		((ToolStripControlHost)TSTB_PassScore).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripControlHost)TSTB_PassScore).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSTB_PassScore).Name = "TSTB_PassScore";
		((ToolStripControlHost)TSTB_PassScore).Size = new Size(100, 25);
		((ToolStripItem)TSL_SetScore).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSL_SetScore).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)TSL_SetScore).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSL_SetScore).Image = (Image)componentResourceManager.GetObject("TSL_SetScore.Image");
		((ToolStripItem)TSL_SetScore).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSL_SetScore).Name = "TSL_SetScore";
		((ToolStripItem)TSL_SetScore).Size = new Size(30, 22);
		((ToolStripItem)TSL_SetScore).Text = "SET";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(907, 432);
		((Control)this).Controls.Add((Control)(object)DGV_CampaignItems);
		((Control)this).Controls.Add((Control)(object)TS_PassScore);
		((Control)this).Controls.Add((Control)(object)ToolStrip1);
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "CampaignEditorWindow";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Campaign Editor";
		((ISupportInitialize)(object)DGV_CampaignItems).EndInit();
		((Control)ToolStrip1).ResumeLayout(false);
		((Control)ToolStrip1).PerformLayout();
		((Control)TS_PassScore).ResumeLayout(false);
		((Control)TS_PassScore).PerformLayout();
		((Control)this).ResumeLayout(false);
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		Keys[] array = keys_0;
		foreach (Keys val in array)
		{
			if (keyData == val)
			{
				int result;
				if (((Control)this).Visible)
				{
					((Form)this).Close();
					result = 1;
				}
				else
				{
					result = 1;
				}
				return (byte)result != 0;
			}
		}
		return false;
	}

	private void method_2()
	{
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		object objectValue = default(object);
		if (((BaseCollection)((DataGridView)DGV_CampaignItems).SelectedRows).Count > 0)
		{
			objectValue = RuntimeHelpers.GetObjectValue(((DataGridViewBand)((DataGridView)DGV_CampaignItems).SelectedRows[0]).Tag);
		}
		((DataGridView)DGV_CampaignItems).Rows.Clear();
		foreach (Campaign.CampaignItem campaignItem in theCampaign.CampaignItems)
		{
			DataGridViewRow val = new DataGridViewRow();
			val.ReadOnly = false;
			val.CreateCells((DataGridView)(object)DGV_CampaignItems);
			Type type = campaignItem.GetType();
			if (type == typeof(Campaign.ScenarioRecord))
			{
				val.Cells[0].Value = "Scenario: " + campaignItem.Name;
				val.Cells[1].Value = ((Campaign.ScenarioRecord)campaignItem).PassScore;
				val.Cells[2].Value = ((Campaign.ScenarioRecord)campaignItem).ID;
			}
			else if (type == typeof(Campaign.AttachmentRecord))
			{
				val.Cells[0].Value = "Attachment: " + campaignItem.Name;
				val.Cells[1].Value = "";
			}
			((DataGridViewBand)val).Tag = campaignItem;
			((DataGridView)DGV_CampaignItems).Rows.Add(val);
		}
		if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
		{
			return;
		}
		IEnumerator enumerator2 = ((IEnumerable)((DataGridView)DGV_CampaignItems).Rows).GetEnumerator();
		try
		{
			DataGridViewRow val2;
			do
			{
				if (enumerator2.MoveNext())
				{
					val2 = (DataGridViewRow)enumerator2.Current;
					continue;
				}
				return;
			}
			while (Information.IsNothing(RuntimeHelpers.GetObjectValue(((DataGridViewBand)val2).Tag)) || objectValue != ((DataGridViewBand)val2).Tag);
			val2.Selected = true;
		}
		finally
		{
			IDisposable disposable = enumerator2 as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	private void CampaignEditorWindow_FormClosing(object sender, FormClosingEventArgs e)
	{
		((CancelEventArgs)(object)e).Cancel = true;
		((Control)this).Hide();
	}

	private void method_3(object sender, EventArgs e)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Invalid comparison between Unknown and I4
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		((FileDialog)OpenFileDialog_AddScen).Filter = "Command scenario file (*.scen)|*.scen";
		if ((int)((CommonDialog)OpenFileDialog_AddScen).ShowDialog() != 1)
		{
			return;
		}
		try
		{
			ScenContainer scenContainer = ScenContainer.LoadFromFile(((FileDialog)OpenFileDialog_AddScen).FileName);
			string ErrorFeedback = null;
			Scenario scenarioObject = scenContainer.GetScenarioObject(ref ErrorFeedback, null, ForceDeepRebuild: false);
			scenarioObject.CampaignID = theCampaign.ID;
			LoadSave.SaveScenario(scenarioObject, scenarioObject.Sides_ReadOnly[0], ((FileDialog)OpenFileDialog_AddScen).FileName, SBR: false);
			Campaign.ScenarioRecord scenarioRecord = new Campaign.ScenarioRecord();
			scenarioRecord.Name = scenarioObject.Title;
			scenarioRecord.ID = scenarioObject.ObjectID;
			scenarioRecord.FileName = Path.GetFileName(((FileDialog)OpenFileDialog_AddScen).FileName);
			theCampaign.CampaignItems.Add(scenarioRecord);
			method_2();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			DarkMessageBox.ShowError("Unable to load selected scenario. The error was: " + ex2.Message, "Error");
			ProjectData.ClearProjectError();
		}
	}

	private void method_4(object sender, EventArgs e)
	{
		if (((BaseCollection)((DataGridView)DGV_CampaignItems).SelectedRows).Count <= 0)
		{
			return;
		}
		foreach (object item in (BaseCollection)((DataGridView)DGV_CampaignItems).SelectedRows)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(item);
			theCampaign.CampaignItems.Remove((Campaign.CampaignItem)NewLateBinding.LateGet(objectValue, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null));
		}
		method_2();
	}

	private void method_5(object sender, EventArgs e)
	{
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		if (((BaseCollection)((DataGridView)DGV_CampaignItems).SelectedRows).Count == 0)
		{
			return;
		}
		if (((BaseCollection)((DataGridView)DGV_CampaignItems).SelectedRows).Count <= 1)
		{
			Campaign.CampaignItem item = (Campaign.CampaignItem)((DataGridViewBand)((DataGridView)DGV_CampaignItems).SelectedRows[0]).Tag;
			int num = theCampaign.CampaignItems.IndexOf(item);
			if (num != 0)
			{
				theCampaign.CampaignItems.Remove(item);
				theCampaign.CampaignItems.Insert(num - 1, item);
				method_2();
			}
		}
		else
		{
			DarkMessageBox.ShowError("Only one item can be re-arranged at a time", "One item a time!");
		}
	}

	private void method_6(object sender, EventArgs e)
	{
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		if (((BaseCollection)((DataGridView)DGV_CampaignItems).SelectedRows).Count == 0)
		{
			return;
		}
		if (((BaseCollection)((DataGridView)DGV_CampaignItems).SelectedRows).Count <= 1)
		{
			Campaign.CampaignItem item = (Campaign.CampaignItem)((DataGridViewBand)((DataGridView)DGV_CampaignItems).SelectedRows[0]).Tag;
			int num = theCampaign.CampaignItems.IndexOf(item);
			if (num != theCampaign.CampaignItems.Count - 1)
			{
				theCampaign.CampaignItems.Remove(item);
				theCampaign.CampaignItems.Insert(num + 1, item);
				method_2();
			}
		}
		else
		{
			DarkMessageBox.ShowError("Only one item can be re-arranged at a time", "One item a time!");
		}
	}

	private void method_7(object sender, EventArgs e)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Invalid comparison between Unknown and I4
		if (!Information.IsNothing((object)CampaignFileName))
		{
			theCampaign.Save(CampaignFileName);
			return;
		}
		((FileDialog)SaveFileDialog_SaveCampaign).Filter = "Command campaign file (*.campaign)|*.campaign";
		if ((int)((CommonDialog)SaveFileDialog_SaveCampaign).ShowDialog() == 1)
		{
			theCampaign.Save(((FileDialog)SaveFileDialog_SaveCampaign).FileName);
			CampaignFileName = ((FileDialog)SaveFileDialog_SaveCampaign).FileName;
		}
	}

	private void CampaignEditorWindow_VisibleChanged(object sender, EventArgs e)
	{
		if (((Control)this).Visible)
		{
			method_2();
		}
	}

	private void method_8(object sender, EventArgs e)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Invalid comparison between Unknown and I4
		MyProject.Forms.TitleAndDescription.Title = theCampaign.Name;
		MyProject.Forms.TitleAndDescription.Description = theCampaign.Description;
		if ((int)((Form)MyProject.Forms.TitleAndDescription).ShowDialog() == 1)
		{
			theCampaign.Name = MyProject.Forms.TitleAndDescription.Title;
			theCampaign.Description = MyProject.Forms.TitleAndDescription.Description;
		}
	}

	private void method_9(object sender, EventArgs e)
	{
		if (((BaseCollection)((DataGridView)DGV_CampaignItems).SelectedRows).Count != 0)
		{
			Campaign.CampaignItem campaignItem = (Campaign.CampaignItem)((DataGridViewBand)((DataGridView)DGV_CampaignItems).SelectedRows[0]).Tag;
			if ((object)campaignItem.GetType() == typeof(Campaign.ScenarioRecord))
			{
				((Control)TS_PassScore).Visible = true;
				((ToolStripControlHost)TSTB_PassScore).Text = Conversions.ToString(((Campaign.ScenarioRecord)campaignItem).PassScore);
			}
			else
			{
				((Control)TS_PassScore).Visible = false;
			}
		}
	}

	private void method_10(object sender, EventArgs e)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Invalid comparison between Unknown and I4
		if ((int)((Form)MyProject.Forms.SelectSAO).ShowDialog() != 1)
		{
			return;
		}
		foreach (ScenAttachmentObject selectedSAO in MyProject.Forms.SelectSAO.SelectedSAOs)
		{
			Campaign.AttachmentRecord attachmentRecord = new Campaign.AttachmentRecord();
			attachmentRecord.Name = selectedSAO.Name;
			attachmentRecord.ID = selectedSAO.ObjectID;
			theCampaign.CampaignItems.Add(attachmentRecord);
		}
		if (MyProject.Forms.SelectSAO.SelectedSAOs.Count > 0)
		{
			method_2();
		}
	}

	private void method_11(object sender, EventArgs e)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Invalid comparison between Unknown and I4
		MyProject.Forms.TitleAndDescription.Title = "Ending Text";
		MyProject.Forms.TitleAndDescription.Description = theCampaign.EndingText;
		if ((int)((Form)MyProject.Forms.TitleAndDescription).ShowDialog() == 1)
		{
			theCampaign.EndingText = MyProject.Forms.TitleAndDescription.Description;
		}
	}

	private void method_12(object sender, EventArgs e)
	{
		if (((BaseCollection)((DataGridView)DGV_CampaignItems).SelectedRows).Count <= 0)
		{
			return;
		}
		foreach (object item in (BaseCollection)((DataGridView)DGV_CampaignItems).SelectedRows)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(item);
			if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, (Type)null, "tag", new object[0], (string[])null, (Type[])null, (bool[])null))) && (object)NewLateBinding.LateGet(objectValue, (Type)null, "tag", new object[0], (string[])null, (Type[])null, (bool[])null).GetType() == typeof(Campaign.ScenarioRecord))
			{
				((Campaign.ScenarioRecord)NewLateBinding.LateGet(objectValue, (Type)null, "Tag", new object[0], (string[])null, (Type[])null, (bool[])null)).PassScore = Conversions.ToInteger(((ToolStripControlHost)TSTB_PassScore).Text);
				method_2();
			}
		}
	}

	private void CampaignEditorWindow_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
	}

	private void method_13(object sender, DataGridViewCellEventArgs e)
	{
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (e.RowIndex == -1 || (object)((DataGridView)DGV_CampaignItems).Columns[e.ColumnIndex].CellType != typeof(DataGridViewButtonCell))
			{
				return;
			}
			Campaign.CampaignItem campaignItem = (Campaign.CampaignItem)((DataGridViewBand)((DataGridView)DGV_CampaignItems).Rows[e.RowIndex]).Tag;
			if (campaignItem.Type == Campaign.CampaignItemType.ScenarioRecord)
			{
				string text = Guid.NewGuid().ToString();
				Task.Factory.StartNew([SpecialName] () =>
				{
					string text2 = Path.Combine(Path.GetDirectoryName(Campaign.GetCampaignFilename(theCampaign.ID)), ((Campaign.ScenarioRecord)campaignItem).FileName);
					ScenContainer scenContainer = ScenContainer.LoadFromFile(text2);
					string ErrorFeedback = null;
					Scenario scenarioObject = scenContainer.GetScenarioObject(ref ErrorFeedback, null, ForceDeepRebuild: false);
					scenarioObject.ObjectID = text;
					File.Move(text2, text2 + ".OLD");
					LoadSave.SaveScenario(scenarioObject, scenarioObject.GetCurrentSide(), text2, SBR: false);
					File.Delete(text2 + ".OLD");
				});
				((Campaign.ScenarioRecord)campaignItem).ID = text;
				method_2();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			DarkMessageBox.ShowError(ex2.Message, "Failed to load the scenario file");
			ProjectData.ClearProjectError();
		}
	}

	static CampaignEditorWindow()
	{
		Class72.smethod_20();
	}
}
