using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class CargoOpsContainer : DarkSecondaryFormBase
{
	public enum CargoOpsContainerMode
	{
		None,
		Munitions,
		Fuel
	}

	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("UnloadButton")]
	private DarkUIButton _UnloadButton;

	[CompilerGenerated]
	[AccessedThroughProperty("LoadButton")]
	private DarkUIButton _LoadButton;

	[CompilerGenerated]
	[AccessedThroughProperty("ContainerCargoGridView")]
	private DarkDataGridView _ContainerCargoGridView;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonCancel")]
	private DarkUIButton _ButtonCancel;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonConfirm")]
	private DarkUIButton _ButtonConfirm;

	[AccessedThroughProperty("HostCargoGridView")]
	[CompilerGenerated]
	private DarkDataGridView _HostCargoGridView;

	public CargoContainer SelectedContainer;

	public ActiveUnit SelectedHost;

	public ICargoHost SelectedHostCargoHost;

	protected List<Cargo> ContainerWorkingContents;

	protected List<Cargo> HostWorkingContents;

	protected float ContainerAvailableMass;

	protected float ContainerAvailableArea;

	protected float ContainerAvailableCrew;

	protected float ContainerAvailableVolume;

	[CompilerGenerated]
	private bool bool_2;

	protected bool RTMP;

	protected int Mode;

	[field: AccessedThroughProperty("TableLayoutPanel1")]
	internal virtual TableLayoutPanel TableLayoutPanel1 { get; set; }

	[field: AccessedThroughProperty("ContainerPanel")]
	internal virtual DarkSectionPanel ContainerPanel { get; set; }

	[field: AccessedThroughProperty("CrewBar")]
	internal virtual DarkUIProgressBar CrewBar { get; set; }

	[field: AccessedThroughProperty("AreaBar")]
	internal virtual DarkUIProgressBar AreaBar { get; set; }

	[field: AccessedThroughProperty("MassBar")]
	internal virtual DarkUIProgressBar MassBar { get; set; }

	[field: AccessedThroughProperty("SizeLabel")]
	internal virtual DarkLabel SizeLabel { get; set; }

	internal virtual DarkUIButton UnloadButton
	{
		[CompilerGenerated]
		get
		{
			return _UnloadButton;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_16;
			DarkUIButton darkUIButton = _UnloadButton;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_UnloadButton = value;
			darkUIButton = _UnloadButton;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("UnloadCounter")]
	internal virtual DarkNumericUpDown UnloadCounter { get; set; }

	[field: AccessedThroughProperty("HostPanel")]
	internal virtual DarkSectionPanel HostPanel { get; set; }

	internal virtual DarkUIButton LoadButton
	{
		[CompilerGenerated]
		get
		{
			return _LoadButton;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_17;
			DarkUIButton darkUIButton = _LoadButton;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_LoadButton = value;
			darkUIButton = _LoadButton;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("LoadCounter")]
	internal virtual DarkNumericUpDown LoadCounter { get; set; }

	internal virtual DarkDataGridView ContainerCargoGridView
	{
		[CompilerGenerated]
		get
		{
			return _ContainerCargoGridView;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_20;
			DarkDataGridView darkDataGridView = _ContainerCargoGridView;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).SelectionChanged -= eventHandler;
			}
			_ContainerCargoGridView = value;
			darkDataGridView = _ContainerCargoGridView;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).SelectionChanged += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton ButtonCancel
	{
		[CompilerGenerated]
		get
		{
			return _ButtonCancel;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_13;
			DarkUIButton darkUIButton = _ButtonCancel;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonCancel = value;
			darkUIButton = _ButtonCancel;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton ButtonConfirm
	{
		[CompilerGenerated]
		get
		{
			return _ButtonConfirm;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_12;
			DarkUIButton darkUIButton = _ButtonConfirm;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonConfirm = value;
			darkUIButton = _ButtonConfirm;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkDataGridView HostCargoGridView
	{
		[CompilerGenerated]
		get
		{
			return _HostCargoGridView;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_21;
			DarkDataGridView darkDataGridView = _HostCargoGridView;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).SelectionChanged -= eventHandler;
			}
			_HostCargoGridView = value;
			darkDataGridView = _HostCargoGridView;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).SelectionChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TargetColName")]
	internal virtual DataGridViewTextBoxColumn TargetColName { get; set; }

	[field: AccessedThroughProperty("TargetColSize")]
	internal virtual DataGridViewTextBoxColumn TargetColSize { get; set; }

	[field: AccessedThroughProperty("TargetColMass")]
	internal virtual DataGridViewTextBoxColumn TargetColMass { get; set; }

	[field: AccessedThroughProperty("TargetColArea")]
	internal virtual DataGridViewTextBoxColumn TargetColArea { get; set; }

	[field: AccessedThroughProperty("TargetColPax")]
	internal virtual DataGridViewTextBoxColumn TargetColPax { get; set; }

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn1")]
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn1 { get; set; }

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn2")]
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn2 { get; set; }

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn3")]
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn3 { get; set; }

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn4")]
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn4 { get; set; }

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn5")]
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn5 { get; set; }

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

	public CargoOpsContainer()
	{
		((Form)this).Load += CargoOpsContainer_Load;
		RTMPEnabled = true;
		RTMP = false;
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
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected O, but got Unknown
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected O, but got Unknown
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Expected O, but got Unknown
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected O, but got Unknown
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected O, but got Unknown
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Expected O, but got Unknown
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Expected O, but got Unknown
		//IL_0343: Unknown result type (might be due to invalid IL or missing references)
		//IL_042e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0438: Expected O, but got Unknown
		//IL_04f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fe: Expected O, but got Unknown
		//IL_0aa6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b34: Expected O, but got Unknown
		//IL_0c58: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d43: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d4d: Expected O, but got Unknown
		//IL_0e0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e16: Expected O, but got Unknown
		//IL_10f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1177: Unknown result type (might be due to invalid IL or missing references)
		//IL_1181: Expected O, but got Unknown
		//IL_11be: Unknown result type (might be due to invalid IL or missing references)
		//IL_12a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_134b: Unknown result type (might be due to invalid IL or missing references)
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DataGridViewCellStyle val5 = new DataGridViewCellStyle();
		DataGridViewCellStyle val6 = new DataGridViewCellStyle();
		TableLayoutPanel1 = new TableLayoutPanel();
		ContainerPanel = new DarkSectionPanel();
		ContainerCargoGridView = new DarkDataGridView();
		TargetColName = new DataGridViewTextBoxColumn();
		TargetColSize = new DataGridViewTextBoxColumn();
		TargetColMass = new DataGridViewTextBoxColumn();
		TargetColArea = new DataGridViewTextBoxColumn();
		TargetColPax = new DataGridViewTextBoxColumn();
		CrewBar = new DarkUIProgressBar();
		AreaBar = new DarkUIProgressBar();
		MassBar = new DarkUIProgressBar();
		SizeLabel = new DarkLabel();
		UnloadButton = new DarkUIButton();
		UnloadCounter = new DarkNumericUpDown();
		HostPanel = new DarkSectionPanel();
		HostCargoGridView = new DarkDataGridView();
		DataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
		LoadButton = new DarkUIButton();
		LoadCounter = new DarkNumericUpDown();
		ButtonCancel = new DarkUIButton();
		ButtonConfirm = new DarkUIButton();
		((Control)TableLayoutPanel1).SuspendLayout();
		((Control)ContainerPanel).SuspendLayout();
		((ISupportInitialize)(object)ContainerCargoGridView).BeginInit();
		((ISupportInitialize)UnloadCounter).BeginInit();
		((Control)HostPanel).SuspendLayout();
		((ISupportInitialize)(object)HostCargoGridView).BeginInit();
		((ISupportInitialize)LoadCounter).BeginInit();
		((Control)this).SuspendLayout();
		TableLayoutPanel1.ColumnCount = 2;
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle((SizeType)1, 412f));
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle((SizeType)1, 424f));
		TableLayoutPanel1.Controls.Add((Control)(object)ContainerPanel, 0, 0);
		TableLayoutPanel1.Controls.Add((Control)(object)HostPanel, 1, 0);
		((Control)TableLayoutPanel1).Location = new Point(4, 3);
		((Control)TableLayoutPanel1).Margin = new Padding(0);
		((Control)TableLayoutPanel1).Name = "TableLayoutPanel1";
		TableLayoutPanel1.RowCount = 1;
		TableLayoutPanel1.RowStyles.Add(new RowStyle((SizeType)2, 100f));
		((Control)TableLayoutPanel1).Size = new Size(836, 464);
		((Control)TableLayoutPanel1).TabIndex = 10;
		((Control)ContainerPanel).Anchor = (AnchorStyles)15;
		((Control)ContainerPanel).Controls.Add((Control)(object)ContainerCargoGridView);
		((Control)ContainerPanel).Controls.Add((Control)(object)CrewBar);
		((Control)ContainerPanel).Controls.Add((Control)(object)AreaBar);
		((Control)ContainerPanel).Controls.Add((Control)(object)MassBar);
		((Control)ContainerPanel).Controls.Add((Control)(object)SizeLabel);
		((Control)ContainerPanel).Controls.Add((Control)(object)UnloadButton);
		((Control)ContainerPanel).Controls.Add((Control)(object)UnloadCounter);
		((Control)ContainerPanel).Location = new Point(0, 0);
		((Control)ContainerPanel).Margin = new Padding(0);
		((Control)ContainerPanel).Name = "ContainerPanel";
		ContainerPanel.SectionHeader = "Container Contents:";
		((Control)ContainerPanel).Size = new Size(412, 464);
		((Control)ContainerPanel).TabIndex = 0;
		((DataGridView)ContainerCargoGridView).AllowUserToAddRows = false;
		((DataGridView)ContainerCargoGridView).AllowUserToDeleteRows = false;
		((DataGridView)ContainerCargoGridView).AllowUserToOrderColumns = true;
		((Control)ContainerCargoGridView).Anchor = (AnchorStyles)15;
		((DataGridView)ContainerCargoGridView).BackgroundColor = Color.FromArgb(60, 63, 65);
		((DataGridView)ContainerCargoGridView).BorderStyle = (BorderStyle)0;
		((DataGridView)ContainerCargoGridView).CellBorderStyle = (DataGridViewCellBorderStyle)8;
		((DataGridView)ContainerCargoGridView).ClipboardCopyMode = (DataGridViewClipboardCopyMode)0;
		((DataGridView)ContainerCargoGridView).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val.Alignment = (DataGridViewContentAlignment)16;
		val.BackColor = Color.FromArgb(66, 77, 95);
		val.Font = new Font("Segoe UI", 9f);
		val.ForeColor = Color.LightGray;
		val.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val.WrapMode = (DataGridViewTriState)1;
		((DataGridView)ContainerCargoGridView).ColumnHeadersDefaultCellStyle = val;
		((DataGridView)ContainerCargoGridView).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		((DataGridView)ContainerCargoGridView).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[5]
		{
			(DataGridViewColumn)TargetColName,
			(DataGridViewColumn)TargetColSize,
			(DataGridViewColumn)TargetColMass,
			(DataGridViewColumn)TargetColArea,
			(DataGridViewColumn)TargetColPax
		});
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = Color.FromArgb(60, 63, 65);
		val2.Font = new Font("Segoe UI", 9f);
		val2.ForeColor = Color.LightGray;
		val2.SelectionBackColor = SystemColors.Highlight;
		val2.SelectionForeColor = SystemColors.HighlightText;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)ContainerCargoGridView).DefaultCellStyle = val2;
		((DataGridView)ContainerCargoGridView).EnableHeadersVisualStyles = false;
		((Control)ContainerCargoGridView).Location = new Point(0, 28);
		((Control)ContainerCargoGridView).Name = "ContainerCargoGridView";
		((DataGridView)ContainerCargoGridView).ReadOnly = true;
		((DataGridView)ContainerCargoGridView).RowHeadersVisible = false;
		((DataGridView)ContainerCargoGridView).RowHeadersWidth = 51;
		val3.BackColor = Color.FromArgb(60, 63, 65);
		val3.ForeColor = Color.LightGray;
		val3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val3.SelectionForeColor = Color.LightGray;
		((DataGridView)ContainerCargoGridView).RowsDefaultCellStyle = val3;
		((DataGridView)ContainerCargoGridView).SelectionMode = (DataGridViewSelectionMode)1;
		((Control)ContainerCargoGridView).Size = new Size(412, 312);
		((Control)ContainerCargoGridView).TabIndex = 25;
		((DataGridViewColumn)TargetColName).HeaderText = "Name";
		((DataGridViewColumn)TargetColName).MinimumWidth = 6;
		((DataGridViewColumn)TargetColName).Name = "TargetColName";
		((DataGridViewColumn)TargetColName).ReadOnly = true;
		TargetColName.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)TargetColName).Width = 192;
		((DataGridViewColumn)TargetColSize).HeaderText = "Size";
		((DataGridViewColumn)TargetColSize).MinimumWidth = 6;
		((DataGridViewColumn)TargetColSize).Name = "TargetColSize";
		((DataGridViewColumn)TargetColSize).ReadOnly = true;
		((DataGridViewColumn)TargetColSize).Width = 64;
		((DataGridViewColumn)TargetColMass).HeaderText = "Mass";
		((DataGridViewColumn)TargetColMass).MinimumWidth = 6;
		((DataGridViewColumn)TargetColMass).Name = "TargetColMass";
		((DataGridViewColumn)TargetColMass).ReadOnly = true;
		((DataGridViewColumn)TargetColMass).Width = 50;
		((DataGridViewColumn)TargetColArea).HeaderText = "Area";
		((DataGridViewColumn)TargetColArea).MinimumWidth = 6;
		((DataGridViewColumn)TargetColArea).Name = "TargetColArea";
		((DataGridViewColumn)TargetColArea).ReadOnly = true;
		((DataGridViewColumn)TargetColArea).Width = 56;
		((DataGridViewColumn)TargetColPax).HeaderText = "PAX";
		((DataGridViewColumn)TargetColPax).MinimumWidth = 6;
		((DataGridViewColumn)TargetColPax).Name = "TargetColPax";
		((DataGridViewColumn)TargetColPax).ReadOnly = true;
		((DataGridViewColumn)TargetColPax).Width = 30;
		((Control)CrewBar).Anchor = (AnchorStyles)14;
		((Control)CrewBar).BackColor = Color.Transparent;
		CrewBar.CustomForeColor = Color.Transparent;
		((Control)CrewBar).Location = new Point(8, 412);
		CrewBar.Maximum = 100;
		((Control)CrewBar).Name = "CrewBar";
		CrewBar.ShowProgressLines = false;
		CrewBar.ShowProgressValue = false;
		CrewBar.ShowText = true;
		((Control)CrewBar).Size = new Size(396, 20);
		((Control)CrewBar).TabIndex = 16;
		((Control)CrewBar).Text = "PAX:";
		CrewBar.Value = 0;
		((Control)AreaBar).Anchor = (AnchorStyles)14;
		((Control)AreaBar).BackColor = Color.Transparent;
		AreaBar.CustomForeColor = Color.Transparent;
		((Control)AreaBar).Location = new Point(8, 389);
		AreaBar.Maximum = 100;
		((Control)AreaBar).Name = "AreaBar";
		AreaBar.ShowProgressLines = false;
		AreaBar.ShowProgressValue = false;
		AreaBar.ShowText = true;
		((Control)AreaBar).Size = new Size(396, 20);
		((Control)AreaBar).TabIndex = 15;
		((Control)AreaBar).Text = "Area:";
		AreaBar.Value = 0;
		((Control)MassBar).Anchor = (AnchorStyles)14;
		((Control)MassBar).BackColor = Color.Transparent;
		MassBar.CustomForeColor = Color.Transparent;
		((Control)MassBar).Location = new Point(8, 366);
		MassBar.Maximum = 100;
		((Control)MassBar).Name = "MassBar";
		MassBar.ShowProgressLines = false;
		MassBar.ShowProgressValue = false;
		MassBar.ShowText = true;
		((Control)MassBar).Size = new Size(396, 20);
		((Control)MassBar).TabIndex = 14;
		((Control)MassBar).Text = "Mass:";
		MassBar.Value = 0;
		((Control)SizeLabel).Anchor = (AnchorStyles)14;
		((Control)SizeLabel).ForeColor = Color.White;
		((Control)SizeLabel).Location = new Point(8, 343);
		((Control)SizeLabel).Name = "SizeLabel";
		((Control)SizeLabel).Size = new Size(396, 20);
		((Control)SizeLabel).TabIndex = 13;
		((Label)SizeLabel).Text = "Max Size:";
		((Label)SizeLabel).TextAlign = (ContentAlignment)16;
		((Control)UnloadButton).Anchor = (AnchorStyles)6;
		((ButtonBase)UnloadButton).BackColor = Color.Transparent;
		((Button)UnloadButton).DialogResult = (DialogResult)0;
		((Control)UnloadButton).ForeColor = SystemColors.Control;
		((Control)UnloadButton).Location = new Point(162, 438);
		((Control)UnloadButton).Name = "UnloadButton";
		((Control)UnloadButton).Padding = new Padding(5);
		UnloadButton.RoundRadius = 0;
		((Control)UnloadButton).Size = new Size(124, 23);
		((Control)UnloadButton).TabIndex = 2;
		UnloadButton.Text = "Unload Selected";
		((Control)UnloadCounter).Anchor = (AnchorStyles)6;
		((UpDownBase)UnloadCounter).BackColor = Color.FromArgb(43, 43, 43);
		((UpDownBase)UnloadCounter).BorderStyle = (BorderStyle)0;
		((Control)UnloadCounter).Font = new Font("Segoe UI", 12f);
		((UpDownBase)UnloadCounter).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)UnloadCounter).Location = new Point(93, 436);
		((NumericUpDown)UnloadCounter).Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		((NumericUpDown)UnloadCounter).Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		((Control)UnloadCounter).Name = "UnloadCounter";
		((Control)UnloadCounter).Size = new Size(64, 25);
		((Control)UnloadCounter).TabIndex = 3;
		((NumericUpDown)UnloadCounter).Value = new decimal(new int[4] { 1, 0, 0, 0 });
		((Control)HostPanel).Anchor = (AnchorStyles)15;
		((Control)HostPanel).Controls.Add((Control)(object)HostCargoGridView);
		((Control)HostPanel).Controls.Add((Control)(object)LoadButton);
		((Control)HostPanel).Controls.Add((Control)(object)LoadCounter);
		((Control)HostPanel).Location = new Point(412, 0);
		((Control)HostPanel).Margin = new Padding(0);
		((Control)HostPanel).Name = "HostPanel";
		HostPanel.SectionHeader = "Host Contents:";
		((Control)HostPanel).Size = new Size(424, 464);
		((Control)HostPanel).TabIndex = 1;
		((DataGridView)HostCargoGridView).AllowUserToAddRows = false;
		((DataGridView)HostCargoGridView).AllowUserToDeleteRows = false;
		((DataGridView)HostCargoGridView).AllowUserToOrderColumns = true;
		((Control)HostCargoGridView).Anchor = (AnchorStyles)15;
		((DataGridView)HostCargoGridView).BackgroundColor = Color.FromArgb(60, 63, 65);
		((DataGridView)HostCargoGridView).BorderStyle = (BorderStyle)0;
		((DataGridView)HostCargoGridView).CellBorderStyle = (DataGridViewCellBorderStyle)8;
		((DataGridView)HostCargoGridView).ClipboardCopyMode = (DataGridViewClipboardCopyMode)0;
		((DataGridView)HostCargoGridView).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val4.Alignment = (DataGridViewContentAlignment)16;
		val4.BackColor = Color.FromArgb(66, 77, 95);
		val4.Font = new Font("Segoe UI", 9f);
		val4.ForeColor = Color.LightGray;
		val4.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val4.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val4.WrapMode = (DataGridViewTriState)1;
		((DataGridView)HostCargoGridView).ColumnHeadersDefaultCellStyle = val4;
		((DataGridView)HostCargoGridView).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		((DataGridView)HostCargoGridView).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[5]
		{
			(DataGridViewColumn)DataGridViewTextBoxColumn1,
			(DataGridViewColumn)DataGridViewTextBoxColumn2,
			(DataGridViewColumn)DataGridViewTextBoxColumn3,
			(DataGridViewColumn)DataGridViewTextBoxColumn4,
			(DataGridViewColumn)DataGridViewTextBoxColumn5
		});
		val5.Alignment = (DataGridViewContentAlignment)16;
		val5.BackColor = Color.FromArgb(60, 63, 65);
		val5.Font = new Font("Segoe UI", 9f);
		val5.ForeColor = Color.LightGray;
		val5.SelectionBackColor = SystemColors.Highlight;
		val5.SelectionForeColor = SystemColors.HighlightText;
		val5.WrapMode = (DataGridViewTriState)2;
		((DataGridView)HostCargoGridView).DefaultCellStyle = val5;
		((DataGridView)HostCargoGridView).EnableHeadersVisualStyles = false;
		((Control)HostCargoGridView).Location = new Point(5, 27);
		((Control)HostCargoGridView).Name = "HostCargoGridView";
		((DataGridView)HostCargoGridView).ReadOnly = true;
		((DataGridView)HostCargoGridView).RowHeadersVisible = false;
		((DataGridView)HostCargoGridView).RowHeadersWidth = 51;
		val6.BackColor = Color.FromArgb(60, 63, 65);
		val6.ForeColor = Color.LightGray;
		val6.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val6.SelectionForeColor = Color.LightGray;
		((DataGridView)HostCargoGridView).RowsDefaultCellStyle = val6;
		((DataGridView)HostCargoGridView).SelectionMode = (DataGridViewSelectionMode)1;
		((Control)HostCargoGridView).Size = new Size(412, 382);
		((Control)HostCargoGridView).TabIndex = 27;
		((DataGridViewColumn)DataGridViewTextBoxColumn1).HeaderText = "Name";
		((DataGridViewColumn)DataGridViewTextBoxColumn1).MinimumWidth = 6;
		((DataGridViewColumn)DataGridViewTextBoxColumn1).Name = "DataGridViewTextBoxColumn1";
		((DataGridViewColumn)DataGridViewTextBoxColumn1).ReadOnly = true;
		DataGridViewTextBoxColumn1.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)DataGridViewTextBoxColumn1).Width = 192;
		((DataGridViewColumn)DataGridViewTextBoxColumn2).HeaderText = "Size";
		((DataGridViewColumn)DataGridViewTextBoxColumn2).MinimumWidth = 6;
		((DataGridViewColumn)DataGridViewTextBoxColumn2).Name = "DataGridViewTextBoxColumn2";
		((DataGridViewColumn)DataGridViewTextBoxColumn2).ReadOnly = true;
		((DataGridViewColumn)DataGridViewTextBoxColumn2).Width = 64;
		((DataGridViewColumn)DataGridViewTextBoxColumn3).HeaderText = "Mass";
		((DataGridViewColumn)DataGridViewTextBoxColumn3).MinimumWidth = 6;
		((DataGridViewColumn)DataGridViewTextBoxColumn3).Name = "DataGridViewTextBoxColumn3";
		((DataGridViewColumn)DataGridViewTextBoxColumn3).ReadOnly = true;
		((DataGridViewColumn)DataGridViewTextBoxColumn3).Width = 50;
		((DataGridViewColumn)DataGridViewTextBoxColumn4).HeaderText = "Area";
		((DataGridViewColumn)DataGridViewTextBoxColumn4).MinimumWidth = 6;
		((DataGridViewColumn)DataGridViewTextBoxColumn4).Name = "DataGridViewTextBoxColumn4";
		((DataGridViewColumn)DataGridViewTextBoxColumn4).ReadOnly = true;
		((DataGridViewColumn)DataGridViewTextBoxColumn4).Width = 56;
		((DataGridViewColumn)DataGridViewTextBoxColumn5).HeaderText = "PAX";
		((DataGridViewColumn)DataGridViewTextBoxColumn5).MinimumWidth = 6;
		((DataGridViewColumn)DataGridViewTextBoxColumn5).Name = "DataGridViewTextBoxColumn5";
		((DataGridViewColumn)DataGridViewTextBoxColumn5).ReadOnly = true;
		((DataGridViewColumn)DataGridViewTextBoxColumn5).Width = 30;
		((Control)LoadButton).Anchor = (AnchorStyles)6;
		((ButtonBase)LoadButton).BackColor = Color.Transparent;
		((Button)LoadButton).DialogResult = (DialogResult)0;
		((Control)LoadButton).ForeColor = SystemColors.Control;
		((Control)LoadButton).Location = new Point(177, 438);
		((Control)LoadButton).Name = "LoadButton";
		((Control)LoadButton).Padding = new Padding(5);
		LoadButton.RoundRadius = 0;
		((Control)LoadButton).Size = new Size(124, 23);
		((Control)LoadButton).TabIndex = 5;
		LoadButton.Text = "Load Selected";
		((Control)LoadCounter).Anchor = (AnchorStyles)6;
		((UpDownBase)LoadCounter).BackColor = Color.FromArgb(43, 43, 43);
		((UpDownBase)LoadCounter).BorderStyle = (BorderStyle)0;
		((Control)LoadCounter).Font = new Font("Segoe UI", 12f);
		((UpDownBase)LoadCounter).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)LoadCounter).Location = new Point(107, 436);
		((Control)LoadCounter).Margin = new Padding(0);
		((NumericUpDown)LoadCounter).Maximum = new decimal(new int[4] { 9999999, 0, 0, 0 });
		((NumericUpDown)LoadCounter).Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		((Control)LoadCounter).Name = "LoadCounter";
		((Control)LoadCounter).Size = new Size(64, 25);
		((Control)LoadCounter).TabIndex = 6;
		((NumericUpDown)LoadCounter).Value = new decimal(new int[4] { 1, 0, 0, 0 });
		((ButtonBase)ButtonCancel).BackColor = Color.Transparent;
		((Button)ButtonCancel).DialogResult = (DialogResult)0;
		((Control)ButtonCancel).ForeColor = SystemColors.Control;
		((Control)ButtonCancel).Location = new Point(433, 487);
		((Control)ButtonCancel).Name = "ButtonCancel";
		((Control)ButtonCancel).Padding = new Padding(5);
		ButtonCancel.RoundRadius = 0;
		((Control)ButtonCancel).Size = new Size(91, 23);
		((Control)ButtonCancel).TabIndex = 32;
		ButtonCancel.Text = "Cancel";
		((ButtonBase)ButtonConfirm).BackColor = Color.Transparent;
		((Button)ButtonConfirm).DialogResult = (DialogResult)0;
		((Control)ButtonConfirm).ForeColor = SystemColors.Control;
		((Control)ButtonConfirm).Location = new Point(317, 487);
		((Control)ButtonConfirm).Name = "ButtonConfirm";
		((Control)ButtonConfirm).Padding = new Padding(5);
		ButtonConfirm.RoundRadius = 0;
		((Control)ButtonConfirm).Size = new Size(91, 23);
		((Control)ButtonConfirm).TabIndex = 31;
		ButtonConfirm.Text = "Confirm";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(7f, 15f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(843, 523);
		((Control)this).Controls.Add((Control)(object)ButtonCancel);
		((Control)this).Controls.Add((Control)(object)ButtonConfirm);
		((Control)this).Controls.Add((Control)(object)TableLayoutPanel1);
		((Control)this).Name = "CargoOpsContainer";
		((Form)this).Text = "Cargo Operations - Container";
		((Control)TableLayoutPanel1).ResumeLayout(false);
		((Control)ContainerPanel).ResumeLayout(false);
		((ISupportInitialize)(object)ContainerCargoGridView).EndInit();
		((ISupportInitialize)UnloadCounter).EndInit();
		((Control)HostPanel).ResumeLayout(false);
		((ISupportInitialize)(object)HostCargoGridView).EndInit();
		((ISupportInitialize)LoadCounter).EndInit();
		((Control)this).ResumeLayout(false);
	}

	private void method_2(List<Cargo> list_0, List<Cargo> list_1)
	{
		list_0.Clear();
		Cargo[] cargoArray = SelectedContainer.CargoArray;
		foreach (Cargo cargo in cargoArray)
		{
			if (cargo.CargoObjectContainerContents == null)
			{
				if (cargo.CargoObjectActiveUnit != null)
				{
					list_0.Add(cargo);
				}
			}
			else
			{
				CargoContainerContent cargoContainerContent = null;
				Cargo item = new Cargo(null, cargo.CargoObjectContainerContents.ContentType switch
				{
					CargoContainerContent.CargoContainerContentType.LiquidFuel => new CargoLiquidFuel((CargoLiquidFuel)cargo.CargoObjectContainerContents), 
					CargoContainerContent.CargoContainerContentType.Ammunition => new CargoAmmunition((CargoAmmunition)cargo.CargoObjectContainerContents), 
					_ => new CargoContainerContent(cargo.CargoObjectContainerContents), 
				}, SelectedContainer);
				list_0.Add(item);
			}
		}
		list_1.Clear();
		if (SelectedContainer.ContainerType == CargoContainer.CargoContainerType.Tank)
		{
			Mode = 2;
			method_5(SelectedHost, list_1);
		}
		else
		{
			Mode = 1;
			method_6(SelectedHost, list_1);
			method_7(SelectedHost, list_1);
		}
	}

	private void CargoOpsContainer_Load(object sender, EventArgs e)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		RTMP = Client.Realtime;
		if (SelectedContainer == null)
		{
			DarkMessageBox.ShowWarning("No container selected.", "Cargo Operations - Container");
			((Form)this).Close();
		}
		if (SelectedHost == null || !(SelectedHost is ICargoHost))
		{
			DarkMessageBox.ShowWarning("No container host selected.", "Cargo Operations - Container");
			((Form)this).Close();
		}
		if (!SelectedHost.IsFixedFacility)
		{
			DarkMessageBox.ShowWarning("Manual container management can only be done when the container is at a fixed facility.", "Cargo Operations - Container");
			((Form)this).Close();
		}
		SelectedHostCargoHost = (ICargoHost)SelectedHost;
		ContainerWorkingContents = new List<Cargo>();
		HostWorkingContents = new List<Cargo>();
		method_2(ContainerWorkingContents, HostWorkingContents);
		method_9();
	}

	private void method_3()
	{
		ContainerAvailableMass = SelectedContainer.GetCargo_Mass();
		ContainerAvailableArea = SelectedContainer.GetCargo_Area();
		ContainerAvailableCrew = SelectedContainer.GetCargo_Crew();
		ContainerAvailableVolume = SelectedContainer.PayloadVolume * 1000f;
		foreach (Cargo containerWorkingContent in ContainerWorkingContents)
		{
			if (containerWorkingContent.CargoObjectContainerContents != null)
			{
				CargoContainerContent cargoObjectContainerContents = containerWorkingContent.CargoObjectContainerContents;
				ContainerAvailableMass -= cargoObjectContainerContents.GetRequiredMass();
				ContainerAvailableArea -= cargoObjectContainerContents.GetRequiredArea();
				ContainerAvailableCrew -= cargoObjectContainerContents.GetRequiredCrewSpace();
				if (cargoObjectContainerContents is CargoLiquidFuel)
				{
					ContainerAvailableVolume -= ((CargoLiquidFuel)cargoObjectContainerContents).CurrentQuantity;
				}
			}
			else
			{
				ContainerAvailableMass -= containerWorkingContent.RequiredMass;
				ContainerAvailableArea -= containerWorkingContent.RequiredArea;
				ContainerAvailableCrew -= containerWorkingContent.RequiredCrewSpace;
			}
		}
	}

	private void method_4(DarkDataGridView darkDataGridView_0, ICargoHost icargoHost_0, List<Cargo> list_0)
	{
		int num = -1;
		if (((BaseCollection)((DataGridView)darkDataGridView_0).SelectedRows).Count > 0)
		{
			num = ((DataGridViewBand)((DataGridView)darkDataGridView_0).SelectedRows[0]).Index;
		}
		((DataGridView)darkDataGridView_0).Rows.Clear();
		if (list_0 == null || list_0.Count < 1)
		{
			return;
		}
		int num2 = 0;
		int num3 = 0;
		int num4 = 1;
		int num5 = 1;
		int num6 = 2;
		int num7 = 3;
		bool flag;
		if (flag = ((DataGridView)darkDataGridView_0).ColumnCount > 4)
		{
			num5++;
			num6++;
			num7++;
		}
		if (Mode == 2)
		{
			((DataGridView)darkDataGridView_0).Columns[num6].HeaderText = "Volume";
		}
		else
		{
			((DataGridView)darkDataGridView_0).Columns[num6].HeaderText = "Area";
		}
		CargoContainerContent cargoContainerContent = null;
		foreach (Cargo item in list_0)
		{
			num2 = ((DataGridView)darkDataGridView_0).Rows.Add();
			DataGridViewRow val = ((DataGridView)darkDataGridView_0).Rows[num2];
			if (item.CargoObjectContainerContents != null)
			{
				cargoContainerContent = item.CargoObjectContainerContents;
				val.Cells[num3].Value = cargoContainerContent.GetCargoName();
				val.Cells[num3].ToolTipText = cargoContainerContent.GetCargoName();
				if (SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo)
				{
					val.Cells[num5].Value = Cargo.DisplayValueMass(cargoContainerContent.GetRequiredMass(), USUnits: true).ToString("N");
				}
				else
				{
					val.Cells[num5].Value = cargoContainerContent.GetRequiredMass().ToString("N");
				}
				if (Mode == 2)
				{
					CargoLiquidFuel cargoLiquidFuel = (CargoLiquidFuel)cargoContainerContent;
					if (SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo)
					{
						val.Cells[num6].Value = Cargo.DisplayValueLiquidVolume(cargoLiquidFuel.CurrentQuantity, USUnits: true).ToString("N");
					}
					else
					{
						val.Cells[num6].Value = cargoLiquidFuel.CurrentQuantity.ToString("N");
					}
				}
				else if (!SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo)
				{
					val.Cells[num6].Value = cargoContainerContent.GetRequiredArea().ToString("N");
				}
				else
				{
					val.Cells[num6].Value = Cargo.DisplayValueArea(cargoContainerContent.GetRequiredArea(), USUnits: true).ToString("N");
				}
				val.Cells[num7].Value = cargoContainerContent.GetRequiredCrewSpace().ToString();
				if (flag)
				{
					val.Cells[num4].Value = CargoUICommon.GetSizeString((int)cargoContainerContent.GetRequiredCargoType());
					val.Cells[num4].Tag = (int)cargoContainerContent.GetRequiredCargoType();
				}
				((DataGridViewBand)val).Tag = item;
			}
			else
			{
				val.Cells[num3].Value = item.CargoObjectName;
				val.Cells[num3].ToolTipText = item.CargoObjectName;
				if (!SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo)
				{
					val.Cells[num5].Value = item.RequiredMass.ToString("N");
				}
				else
				{
					val.Cells[num5].Value = Cargo.DisplayValueMass(item.RequiredMass, USUnits: true).ToString("N");
				}
				if (!SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo)
				{
					val.Cells[num6].Value = item.RequiredArea.ToString("N");
				}
				else
				{
					val.Cells[num6].Value = Cargo.DisplayValueArea(item.RequiredArea, USUnits: true).ToString("N");
				}
				val.Cells[num7].Value = item.RequiredCrewSpace.ToString();
				if (flag)
				{
					val.Cells[num4].Value = CargoUICommon.GetSizeString((int)item.RequiredCargoType);
					val.Cells[num4].Tag = (int)item.RequiredCargoType;
				}
				((DataGridViewBand)val).Tag = item;
			}
		}
		((Control)darkDataGridView_0).Refresh();
		if (((DataGridView)darkDataGridView_0).Rows.Count > 0 && num > -1)
		{
			((DataGridView)darkDataGridView_0).ClearSelection();
			if (num >= ((DataGridView)darkDataGridView_0).Rows.Count)
			{
				num = ((DataGridView)darkDataGridView_0).Rows.Count - 1;
			}
			((DataGridView)darkDataGridView_0).Rows[num].Selected = true;
		}
	}

	public void UpdateCapacityLabels(CargoContainer theContainer, DarkLabel SizeLabel, DarkUIProgressBar MassBar, float AvailableMass, DarkUIProgressBar AreaBar, float AvailableArea, DarkUIProgressBar CrewBar, float AvailableCrew)
	{
		if (theContainer == null)
		{
			if (SizeLabel != null)
			{
				((Label)SizeLabel).Text = "Max Size: Unlimted";
			}
			((Control)MassBar).Text = "Mass: " + AvailableMass.ToString("N") + " " + Cargo.CargoMassLabel(SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
			((Control)MassBar).ForeColor = Color.White;
			((Control)AreaBar).Text = "Area: " + AvailableArea.ToString("N") + " " + Cargo.CargoAreaLabel(SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
			((Control)AreaBar).ForeColor = Color.White;
			((Control)CrewBar).Text = "PAX: " + AvailableCrew + " Pers.";
			((Control)CrewBar).ForeColor = Color.White;
			return;
		}
		float num = (float)((ICargoHost)theContainer).GetCargo_Type();
		float cargo_Mass = ((ICargoHost)theContainer).GetCargo_Mass();
		float cargo_Crew = ((ICargoHost)theContainer).GetCargo_Crew();
		float num2 = ((Mode != 2) ? ((ICargoHost)theContainer).GetCargo_Area() : (theContainer.PayloadVolume * 1000f));
		if (SizeLabel != null)
		{
			((Label)SizeLabel).Text = "Max Size: ";
			float num3 = num;
			if (num3 == 0f)
			{
				((Label)SizeLabel).Text = ((Label)SizeLabel).Text + CargoHostHelper.c0000;
			}
			else if (num3 == 1000f)
			{
				((Label)SizeLabel).Text = ((Label)SizeLabel).Text + CargoHostHelper.c1000;
			}
			else if (num3 == 2000f)
			{
				((Label)SizeLabel).Text = ((Label)SizeLabel).Text + CargoHostHelper.c2000;
			}
			else if (num3 == 3000f)
			{
				((Label)SizeLabel).Text = ((Label)SizeLabel).Text + CargoHostHelper.c3000;
			}
			else if (num3 == 4000f)
			{
				((Label)SizeLabel).Text = ((Label)SizeLabel).Text + CargoHostHelper.c4000;
			}
			else if (num3 == 5000f)
			{
				((Label)SizeLabel).Text = ((Label)SizeLabel).Text + CargoHostHelper.c5000;
			}
		}
		float num4 = cargo_Mass;
		float num5 = Cargo.DisplayValueMass(num4 - AvailableMass, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
		float num6 = Cargo.DisplayValueMass(num4, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
		((Control)MassBar).Text = "Mass: " + num5.ToString("N") + " / " + num6.ToString("N") + " " + Cargo.CargoMassLabel(SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
		if (num4 == 0f)
		{
			MassBar.Value = 100;
		}
		else
		{
			MassBar.Value = (int)Math.Round(100f * ((num4 - AvailableMass) / num4));
		}
		if (AvailableMass == 0f)
		{
			((Control)MassBar).ForeColor = Color.LightGray;
			((Control)MassBar).Text = "[FULL] " + ((Control)MassBar).Text;
		}
		else
		{
			((Control)MassBar).ForeColor = Color.White;
		}
		num4 = num2;
		num5 = Cargo.DisplayValueArea(num4 - AvailableArea, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
		num6 = Cargo.DisplayValueArea(num4, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
		if (Mode == 2)
		{
			((Control)AreaBar).Text = "Volume: " + num5.ToString("N") + " / " + num6.ToString("N") + " " + Cargo.CargoLiquidVolumeLabel(SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
		}
		else
		{
			((Control)AreaBar).Text = "Area: " + num5.ToString("N") + " / " + num6.ToString("N") + " " + Cargo.CargoAreaLabel(SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
		}
		if (num4 == 0f)
		{
			AreaBar.Value = 100;
		}
		else
		{
			AreaBar.Value = (int)Math.Round(100f * ((num4 - AvailableArea) / num4));
		}
		if (AvailableArea == 0f)
		{
			((Control)AreaBar).ForeColor = Color.LightGray;
			((Control)AreaBar).Text = "[FULL] " + ((Control)AreaBar).Text;
		}
		else
		{
			((Control)AreaBar).ForeColor = Color.White;
		}
		num4 = cargo_Crew;
		((Control)CrewBar).Text = "PAX: " + (num4 - AvailableCrew) + " / " + num4.ToString("N0") + " Pers.";
		if (num4 == 0f)
		{
			CrewBar.Value = 100;
		}
		else
		{
			CrewBar.Value = (int)Math.Round(100f * ((num4 - AvailableCrew) / num4));
		}
		if (AvailableCrew == 0f)
		{
			((Control)CrewBar).ForeColor = Color.LightGray;
			((Control)CrewBar).Text = "[FULL] " + ((Control)CrewBar).Text;
		}
		else
		{
			((Control)CrewBar).ForeColor = Color.White;
		}
	}

	private void method_5(ActiveUnit activeUnit_0, List<Cargo> list_0)
	{
		list_0.Clear();
		if (activeUnit_0 == null)
		{
			return;
		}
		foreach (FuelRec item2 in activeUnit_0.Fuel_ReadOnly)
		{
			CargoLiquidFuel cargoLiquidFuel = new CargoLiquidFuel();
			cargoLiquidFuel.FuelType = item2.FuelType;
			cargoLiquidFuel.Mass = item2.CurrentQuantity;
			cargoLiquidFuel.CurrentQuantity = cargoLiquidFuel.GetVolumeForMass(item2.CurrentQuantity);
			Cargo item = new Cargo(null, cargoLiquidFuel, null);
			list_0.Add(item);
		}
	}

	private void method_6(ActiveUnit activeUnit_0, List<Cargo> list_0)
	{
		list_0.Clear();
		if (activeUnit_0 == null)
		{
			return;
		}
		Magazine[] totalMagazines = activeUnit_0.TotalMagazines;
		foreach (Magazine magazine in totalMagazines)
		{
			foreach (WeaponRec weapon in magazine.Weapons)
			{
				if (weapon.CurrentLoad > 0)
				{
					CargoAmmunition theContents = new CargoAmmunition(weapon.int_3, weapon.CurrentLoad, activeUnit_0.ParentScen);
					Cargo item = new Cargo(null, theContents, null);
					list_0.Add(item);
				}
			}
		}
	}

	private void method_7(ActiveUnit activeUnit_0, List<Cargo> list_0)
	{
		if (activeUnit_0 == null)
		{
			return;
		}
		Cargo[] onboardCargo = activeUnit_0.OnboardCargo;
		foreach (Cargo cargo in onboardCargo)
		{
			if (cargo.CargoObjectActiveUnit != null)
			{
				new Cargo(activeUnit_0, cargo.CargoObjectActiveUnit);
				list_0.Add(cargo);
			}
		}
	}

	private void method_8(DarkDataGridView darkDataGridView_0, float float_0, float float_1, float float_2, float float_3)
	{
	}

	private void method_9()
	{
		method_3();
		if (Mode == 2)
		{
			UpdateCapacityLabels(SelectedContainer, SizeLabel, MassBar, ContainerAvailableMass, AreaBar, ContainerAvailableVolume, CrewBar, ContainerAvailableCrew);
		}
		else
		{
			UpdateCapacityLabels(SelectedContainer, SizeLabel, MassBar, ContainerAvailableMass, AreaBar, ContainerAvailableArea, CrewBar, ContainerAvailableCrew);
		}
		method_4(ContainerCargoGridView, SelectedContainer, ContainerWorkingContents);
		method_20(null, null);
		method_4(HostCargoGridView, SelectedHostCargoHost, HostWorkingContents);
		method_21(null, null);
		method_8(HostCargoGridView, ContainerAvailableMass, ContainerAvailableArea, ContainerAvailableVolume, ContainerAvailableCrew);
	}

	private void method_10(List<Cargo> list_0, List<Cargo> list_1, List<Cargo> list_2)
	{
		foreach (Cargo item2 in list_0)
		{
			if (item2.CargoObjectContainerContents == null)
			{
				if (!list_1.Contains(item2))
				{
					list_2.Add(item2);
				}
				continue;
			}
			CargoContainerContent cargoObjectContainerContents = item2.CargoObjectContainerContents;
			CargoContainerContent cargoContainerContent = null;
			CargoContainerContent cargoContainerContent2 = null;
			foreach (Cargo item3 in list_1)
			{
				if (item3.CargoObjectContainerContents != null)
				{
					cargoContainerContent = item3.CargoObjectContainerContents;
					if (cargoObjectContainerContents.isMatch(cargoContainerContent))
					{
						cargoContainerContent2 = cargoContainerContent;
						break;
					}
				}
			}
			if (cargoContainerContent2 == null)
			{
				list_2.Add(item2);
			}
			else if (!cargoObjectContainerContents.isExactMatch(cargoContainerContent2))
			{
				float quantityDifference = cargoObjectContainerContents.GetQuantityDifference(cargoContainerContent2);
				if (quantityDifference > 0f)
				{
					CargoContainerContent theContents = cargoObjectContainerContents.CreateNewContentMatching(quantityDifference);
					Cargo item = new Cargo(null, theContents, null);
					list_2.Add(item);
				}
			}
		}
	}

	private bool method_11()
	{
		List<Cargo> list = new List<Cargo>();
		List<Cargo> list2 = new List<Cargo>();
		List<Cargo> list3 = new List<Cargo>();
		List<Cargo> list_ = new List<Cargo>();
		method_2(list3, list_);
		method_10(HostWorkingContents, list_, list);
		method_10(ContainerWorkingContents, list3, list2);
		if (list.Count > 0)
		{
			if (RTMP)
			{
				Client.RealtimeTerminal.SendCargoContainerOpsAction(SelectedContainer, list, SelectedHost, SourceIsContainer: true);
			}
			else if (!Cargo.UnloadContainerContentsToUnit(SelectedContainer, list, SelectedHost))
			{
				return false;
			}
		}
		int result;
		if (list2.Count > 0)
		{
			if (!RTMP)
			{
				if (!Cargo.LoadContainerContentsFromUnit(SelectedHost, SelectedContainer, list2))
				{
					return false;
				}
				result = 1;
			}
			else
			{
				Client.RealtimeTerminal.SendCargoContainerOpsAction(SelectedContainer, list2, SelectedHost, SourceIsContainer: false);
				result = 1;
			}
		}
		else
		{
			result = 1;
		}
		return (byte)result != 0;
	}

	private void method_12(object sender, EventArgs e)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		if (!method_11())
		{
			DarkMessageBox.ShowWarning("One or more cargo items could not be moved due to capacity limitations.", "Cargo Operations");
		}
		MyProject.Forms.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, Client.SelectedUnit, v: false);
		((Form)this).DialogResult = (DialogResult)1;
		((Form)this).Close();
	}

	private void method_13(object sender, EventArgs e)
	{
		((Form)this).DialogResult = (DialogResult)2;
		((Form)this).Close();
	}

	private void method_14(List<Cargo> list_0, List<Cargo> list_1, Cargo cargo_0, int int_0, ICargoHost icargoHost_0)
	{
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		if (icargoHost_0 == null || cargo_0 == null)
		{
			return;
		}
		if (icargoHost_0.GetCargo_Type() >= cargo_0.RequiredCargoType)
		{
			float num = icargoHost_0.GetCargo_Mass();
			float num2 = icargoHost_0.GetCargo_Area();
			float num3 = icargoHost_0.GetCargo_Crew();
			foreach (Cargo item in list_1)
			{
				num -= item.RequiredMass;
				num2 -= item.RequiredArea;
				num3 -= item.RequiredCrewSpace;
			}
			if (!(num - cargo_0.RequiredMass < 0f) && !(num2 - cargo_0.RequiredArea < 0f) && num3 - cargo_0.RequiredCrewSpace >= 0f)
			{
				list_0.Remove(cargo_0);
				list_1.Add(cargo_0);
			}
			else
			{
				DarkMessageBox.ShowWarning("The requested cargo could not be moved due to destination capacity limits.", "Cargo Operations - Container");
			}
		}
		else
		{
			DarkMessageBox.ShowWarning("The requested cargo could not be moved due to destination cargo size limit.", "Cargo Operations - Container");
		}
	}

	private void method_15(List<Cargo> list_0, List<Cargo> list_1, Cargo cargo_0, int int_0, CargoContainer cargoContainer_0)
	{
		//IL_0384: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0414: Unknown result type (might be due to invalid IL or missing references)
		//IL_0402: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		if (int_0 < 1)
		{
			return;
		}
		CargoContainerContent cargoObjectContainerContents = cargo_0.CargoObjectContainerContents;
		if (cargoObjectContainerContents == null)
		{
			return;
		}
		if (int_0 > cargoObjectContainerContents.GetCargoQuantity())
		{
			int_0 = cargoObjectContainerContents.GetCargoQuantity();
		}
		if (!(cargoObjectContainerContents is CargoLiquidFuel))
		{
			if (!(cargoObjectContainerContents is CargoAmmunition))
			{
				return;
			}
			CargoAmmunition cargoAmmunition = (CargoAmmunition)cargoObjectContainerContents;
			CargoAmmunition cargoAmmunition2 = null;
			foreach (Cargo item3 in list_1)
			{
				if (item3.CargoObjectContainerContents != null && item3.CargoObjectContainerContents is CargoAmmunition)
				{
					CargoAmmunition cargoAmmunition3 = (CargoAmmunition)item3.CargoObjectContainerContents;
					if (cargoAmmunition3.int_1 == cargoAmmunition.int_1)
					{
						cargoAmmunition2 = cargoAmmunition3;
						break;
					}
				}
			}
			if (cargoContainer_0 != null)
			{
				if (cargoAmmunition.GetRequiredCargoType() > cargoContainer_0.GetCargo_Type())
				{
					DarkMessageBox.ShowWarning("The size of the requested munition is too large for the container.", "Cargo Operations - Container");
					return;
				}
				float num = cargoAmmunition.Area * (float)int_0;
				float num2 = cargoAmmunition.Mass * (float)int_0;
				if (ContainerAvailableArea < num)
				{
					bool flag = false;
					if (cargoAmmunition.IsStackable() && cargoContainer_0.CanStackCargo())
					{
						int num3 = 0;
						float num4 = 0f;
						if (cargoAmmunition2 != null)
						{
							num3 = cargoAmmunition2.GetCargoQuantity();
							num4 = cargoAmmunition2.GetRequiredArea();
						}
						if (ContainerAvailableArea + num4 < cargoAmmunition.GetRequiredAreaStacked(cargoContainer_0, int_0 + num3))
						{
							bool flag2 = false;
							for (int i = int_0 - 1; i >= 1; i += -1)
							{
								if (!(ContainerAvailableArea + num4 < cargoAmmunition.GetRequiredAreaStacked(cargoContainer_0, i + num3)))
								{
									int_0 = i;
									flag2 = true;
									break;
								}
							}
							if (!flag2)
							{
								int_0 = 0;
							}
						}
						else
						{
							flag = true;
						}
					}
					else
					{
						int_0 = (int)Math.Floor(ContainerAvailableArea / cargoAmmunition.Area);
					}
					if (!flag)
					{
						if (int_0 < 1)
						{
							DarkMessageBox.ShowWarning("The requested munitions could not be loaded. The container area limit has been reached.", "Cargo Operations - Container");
							return;
						}
						DarkMessageBox.ShowWarning("Only some of the requested munitions could be loaded due to container area limit.", "Cargo Operations - Container");
					}
				}
				if (ContainerAvailableMass < num2)
				{
					int_0 = (int)Math.Round(Math.Min(Math.Floor(ContainerAvailableMass / cargoAmmunition.Mass), int_0));
					if (int_0 < 1)
					{
						DarkMessageBox.ShowWarning("The requested munitions could not be loaded. The container mass limit has been reached.", "Cargo Operations - Container");
						return;
					}
					DarkMessageBox.ShowWarning("Only some of the requested munitions could be loaded due to container mass limit.", "Cargo Operations - Container");
				}
			}
			if (cargoAmmunition2 != null)
			{
				cargoAmmunition2.WeaponQuantity += int_0;
				cargoAmmunition.WeaponQuantity -= int_0;
				if (cargoAmmunition.WeaponQuantity <= 0)
				{
					list_0.Remove(cargo_0);
				}
			}
			else if (cargoAmmunition.WeaponQuantity <= int_0)
			{
				cargoAmmunition.Parent = cargoContainer_0;
				list_0.Remove(cargo_0);
				list_1.Add(cargo_0);
			}
			else
			{
				cargoAmmunition2 = new CargoAmmunition(cargoAmmunition.int_1, int_0, SelectedHost.ParentScen);
				cargoAmmunition2.Parent = cargoContainer_0;
				Cargo item = new Cargo(null, cargoAmmunition2, null);
				list_1.Add(item);
				cargoAmmunition.WeaponQuantity -= int_0;
			}
			return;
		}
		CargoLiquidFuel cargoLiquidFuel = (CargoLiquidFuel)cargoObjectContainerContents;
		CargoLiquidFuel cargoLiquidFuel2 = null;
		float num5 = Math.Min(int_0, cargoLiquidFuel.CurrentQuantity);
		foreach (Cargo item4 in list_1)
		{
			if (item4.CargoObjectContainerContents != null && item4.CargoObjectContainerContents is CargoLiquidFuel)
			{
				CargoLiquidFuel cargoLiquidFuel3 = (CargoLiquidFuel)item4.CargoObjectContainerContents;
				if (cargoLiquidFuel3.FuelType == cargoLiquidFuel.FuelType)
				{
					cargoLiquidFuel2 = cargoLiquidFuel3;
					break;
				}
			}
		}
		if (cargoContainer_0 != null)
		{
			if (cargoLiquidFuel2 == null && list_1.Count > 0)
			{
				DarkMessageBox.ShowWarning("The type of fuel does not match the fuel already in the container.", "Cargo Operations - Container");
				return;
			}
			if (ContainerAvailableVolume < cargoLiquidFuel.CurrentQuantity)
			{
				num5 = ContainerAvailableVolume;
				if (num5 <= 0f)
				{
					DarkMessageBox.ShowWarning("The requested fuel could not be loaded. The container volume is already full.", "Cargo Operations - Container");
					return;
				}
				DarkMessageBox.ShowWarning("Only some of the requested fuel could be loaded due to container volume limit.", "Cargo Operations - Container");
			}
			if (ContainerAvailableMass < cargoLiquidFuel.GetRequiredMass())
			{
				num5 = 1000f * cargoLiquidFuel.GetVolumeForMass(ContainerAvailableMass);
				if (num5 <= 0f)
				{
					DarkMessageBox.ShowWarning("The requested fuel could not be loaded. The container is already at maximum mass.", "Cargo Operations - Container");
					return;
				}
				DarkMessageBox.ShowWarning("Only some of the requested fuel could be loaded due to container mass limit.", "Cargo Operations - Container");
			}
		}
		if (cargoLiquidFuel2 != null)
		{
			cargoLiquidFuel2.CurrentQuantity += num5;
			cargoLiquidFuel2.Mass = cargoLiquidFuel2.GetMassForVolume(cargoLiquidFuel2.CurrentQuantity);
			cargoLiquidFuel.CurrentQuantity -= num5;
			if (cargoLiquidFuel.CurrentQuantity > 0f)
			{
				cargoLiquidFuel.Mass = cargoLiquidFuel.GetMassForVolume(cargoLiquidFuel.CurrentQuantity);
			}
			else
			{
				list_0.Remove(cargo_0);
			}
		}
		else if (cargoLiquidFuel.CurrentQuantity <= num5)
		{
			cargoLiquidFuel.Parent = cargoContainer_0;
			list_0.Remove(cargo_0);
			list_1.Add(cargo_0);
		}
		else
		{
			cargoLiquidFuel2 = new CargoLiquidFuel();
			cargoLiquidFuel2.Parent = cargoContainer_0;
			cargoLiquidFuel2.FuelType = cargoLiquidFuel.FuelType;
			cargoLiquidFuel2.CurrentQuantity = num5;
			cargoLiquidFuel2.Mass = cargoLiquidFuel2.GetMassForVolume(cargoLiquidFuel2.CurrentQuantity);
			Cargo item2 = new Cargo(null, cargoLiquidFuel2, null);
			list_1.Add(item2);
			cargoLiquidFuel.CurrentQuantity -= num5;
			cargoLiquidFuel.Mass = cargoLiquidFuel.GetMassForVolume(cargoLiquidFuel.CurrentQuantity);
		}
	}

	private void method_16(object sender, EventArgs e)
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		if (decimal.Compare(((NumericUpDown)UnloadCounter).Value, 1m) < 0)
		{
			return;
		}
		int int_ = Convert.ToInt32(((NumericUpDown)UnloadCounter).Value);
		foreach (DataGridViewRow item in (BaseCollection)((DataGridView)ContainerCargoGridView).SelectedRows)
		{
			DataGridViewRow val = item;
			if (((DataGridViewBand)val).Tag != null)
			{
				Cargo cargo = (Cargo)((DataGridViewBand)val).Tag;
				if (cargo.CargoObjectContainerContents == null)
				{
					method_14(ContainerWorkingContents, HostWorkingContents, cargo, int_, SelectedHostCargoHost);
				}
				else
				{
					method_15(ContainerWorkingContents, HostWorkingContents, cargo, int_, null);
				}
			}
		}
		method_9();
	}

	private void method_17(object sender, EventArgs e)
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		if (decimal.Compare(((NumericUpDown)LoadCounter).Value, 1m) < 0)
		{
			return;
		}
		int int_ = Convert.ToInt32(((NumericUpDown)LoadCounter).Value);
		foreach (DataGridViewRow item in (BaseCollection)((DataGridView)HostCargoGridView).SelectedRows)
		{
			DataGridViewRow val = item;
			if (((DataGridViewBand)val).Tag != null)
			{
				Cargo cargo = (Cargo)((DataGridViewBand)val).Tag;
				if (cargo.CargoObjectContainerContents == null)
				{
					method_14(HostWorkingContents, ContainerWorkingContents, cargo, int_, SelectedContainer);
				}
				else
				{
					method_15(HostWorkingContents, ContainerWorkingContents, cargo, int_, SelectedContainer);
				}
			}
		}
		method_9();
	}

	private void method_18(DarkNumericUpDown darkNumericUpDown_0, DarkDataGridView darkDataGridView_0)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		((NumericUpDown)darkNumericUpDown_0).Minimum = 0m;
		((NumericUpDown)darkNumericUpDown_0).Maximum = 0m;
		((NumericUpDown)darkNumericUpDown_0).Value = 0m;
		foreach (DataGridViewRow item in (BaseCollection)((DataGridView)darkDataGridView_0).SelectedRows)
		{
			DataGridViewRow val = item;
			if (((DataGridViewBand)val).Tag == null)
			{
				continue;
			}
			Cargo cargo = (Cargo)((DataGridViewBand)val).Tag;
			if (cargo.CargoObjectContainerContents == null)
			{
				if (decimal.Compare(((NumericUpDown)darkNumericUpDown_0).Maximum, 1m) < 0)
				{
					((NumericUpDown)darkNumericUpDown_0).Maximum = 1m;
				}
				continue;
			}
			int cargoQuantity = cargo.CargoObjectContainerContents.GetCargoQuantity();
			if (decimal.Compare(new decimal(cargoQuantity), ((NumericUpDown)darkNumericUpDown_0).Maximum) > 0)
			{
				((NumericUpDown)darkNumericUpDown_0).Maximum = new decimal(cargoQuantity);
			}
		}
		if (decimal.Compare(((NumericUpDown)darkNumericUpDown_0).Maximum, 0m) > 0)
		{
			((NumericUpDown)darkNumericUpDown_0).Minimum = 1m;
			((NumericUpDown)darkNumericUpDown_0).Value = ((NumericUpDown)darkNumericUpDown_0).Maximum;
		}
	}

	private void method_19()
	{
		UnloadButton.Enabled = decimal.Compare(((NumericUpDown)UnloadCounter).Maximum, 0m) > 0;
		LoadButton.Enabled = decimal.Compare(((NumericUpDown)LoadCounter).Maximum, 0m) > 0;
	}

	private void method_20(object sender, EventArgs e)
	{
		method_18(UnloadCounter, ContainerCargoGridView);
		method_19();
	}

	private void method_21(object sender, EventArgs e)
	{
		method_18(LoadCounter, HostCargoGridView);
		method_19();
	}

	static CargoOpsContainer()
	{
		Class72.smethod_20();
	}
}
