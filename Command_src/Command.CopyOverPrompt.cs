using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class CopyOverPrompt : DarkSecondaryFormBase
{
	public class CheckBoxWrapper
	{
		public Field_Delta FieldDelta;

		public Row_Delta RowDelta;

		public CheckBoxWrapper(Field_Delta _FieldDelta)
		{
			FieldDelta = _FieldDelta;
		}

		public CheckBoxWrapper(Row_Delta _RowDelta)
		{
			RowDelta = _RowDelta;
		}

		static CheckBoxWrapper()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[AccessedThroughProperty("LabelDBID")]
	[CompilerGenerated]
	private DarkLabel darkLabel_0;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckBox10")]
	private DarkCheckBox darkCheckBox_0;

	[AccessedThroughProperty("CheckBox11")]
	[CompilerGenerated]
	private DarkCheckBox darkCheckBox_1;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckBox12")]
	private DarkCheckBox zyCxeNnKva;

	[AccessedThroughProperty("CheckBox13")]
	[CompilerGenerated]
	private DarkCheckBox darkCheckBox_2;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckBox14")]
	private DarkCheckBox darkCheckBox_3;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_SelectAll_Sub")]
	private DarkButton _Button_SelectAll_Sub;

	[AccessedThroughProperty("Button_DeselectAll_Sub")]
	[CompilerGenerated]
	private DarkButton _Button_DeselectAll_Sub;

	[AccessedThroughProperty("Button_DeselectAll_Main")]
	[CompilerGenerated]
	private DarkButton _Button_DeselectAll_Main;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_SelectAll_Main")]
	private DarkButton _Button_SelectAll_Main;

	public Dictionary<CheckBoxWrapper, DeltaCopyOverElement> Checkboxes;

	public Dictionary<CheckBoxWrapper, DeltaCopyOverElement_Component> Checkboxes_Secondary;

	[field: AccessedThroughProperty("CheckBox1")]
	internal virtual DarkCheckBox CheckBox1 { get; set; }

	[field: AccessedThroughProperty("Panel_Deltas")]
	internal virtual FlowLayoutPanel Panel_Deltas { get; set; }

	[field: AccessedThroughProperty("CheckBox2")]
	internal virtual DarkCheckBox CheckBox2 { get; set; }

	[field: AccessedThroughProperty("CheckBox3")]
	internal virtual DarkCheckBox CheckBox3 { get; set; }

	[field: AccessedThroughProperty("CheckBox4")]
	internal virtual DarkCheckBox CheckBox4 { get; set; }

	[field: AccessedThroughProperty("CheckBox5")]
	internal virtual DarkCheckBox CheckBox5 { get; set; }

	internal virtual DarkLabel LabelDBID
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

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

	[field: AccessedThroughProperty("Label3")]
	internal virtual DarkLabel Label3 { get; set; }

	[field: AccessedThroughProperty("Button_Commit")]
	internal virtual DarkButton Button_Commit { get; set; }

	[field: AccessedThroughProperty("Button_Skip")]
	internal virtual DarkButton Button_Skip { get; set; }

	[field: AccessedThroughProperty("CheckBox6")]
	internal virtual DarkCheckBox CheckBox6 { get; set; }

	[field: AccessedThroughProperty("CheckBox7")]
	internal virtual DarkCheckBox CheckBox7 { get; set; }

	[field: AccessedThroughProperty("Label_MainTable")]
	internal virtual DarkLabel Label_MainTable { get; set; }

	[field: AccessedThroughProperty("Panel_Deltas_Associated")]
	internal virtual FlowLayoutPanel Panel_Deltas_Associated { get; set; }

	[field: AccessedThroughProperty("CheckBox8")]
	internal virtual DarkCheckBox CheckBox8 { get; set; }

	[field: AccessedThroughProperty("CheckBox9")]
	internal virtual DarkCheckBox CheckBox9 { get; set; }

	internal virtual DarkCheckBox CheckBox10
	{
		[CompilerGenerated]
		get
		{
			return darkCheckBox_0;
		}
		[CompilerGenerated]
		set
		{
			darkCheckBox_0 = value;
		}
	}

	internal virtual DarkCheckBox CheckBox11
	{
		[CompilerGenerated]
		get
		{
			return darkCheckBox_1;
		}
		[CompilerGenerated]
		set
		{
			darkCheckBox_1 = value;
		}
	}

	internal virtual DarkCheckBox CheckBox12
	{
		[CompilerGenerated]
		get
		{
			return zyCxeNnKva;
		}
		[CompilerGenerated]
		set
		{
			zyCxeNnKva = value;
		}
	}

	internal virtual DarkCheckBox CheckBox13
	{
		[CompilerGenerated]
		get
		{
			return darkCheckBox_2;
		}
		[CompilerGenerated]
		set
		{
			darkCheckBox_2 = value;
		}
	}

	internal virtual DarkCheckBox CheckBox14
	{
		[CompilerGenerated]
		get
		{
			return darkCheckBox_3;
		}
		[CompilerGenerated]
		set
		{
			darkCheckBox_3 = value;
		}
	}

	[field: AccessedThroughProperty("Label_AssociatedTables")]
	internal virtual DarkLabel Label_AssociatedTables { get; set; }

	internal virtual DarkButton Button_SelectAll_Sub
	{
		[CompilerGenerated]
		get
		{
			return _Button_SelectAll_Sub;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_5;
			DarkButton darkButton = _Button_SelectAll_Sub;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_SelectAll_Sub = value;
			darkButton = _Button_SelectAll_Sub;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkButton Button_DeselectAll_Sub
	{
		[CompilerGenerated]
		get
		{
			return _Button_DeselectAll_Sub;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_4;
			DarkButton darkButton = _Button_DeselectAll_Sub;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_DeselectAll_Sub = value;
			darkButton = _Button_DeselectAll_Sub;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkButton Button_DeselectAll_Main
	{
		[CompilerGenerated]
		get
		{
			return _Button_DeselectAll_Main;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			DarkButton darkButton = _Button_DeselectAll_Main;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_DeselectAll_Main = value;
			darkButton = _Button_DeselectAll_Main;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkButton Button_SelectAll_Main
	{
		[CompilerGenerated]
		get
		{
			return _Button_SelectAll_Main;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			DarkButton darkButton = _Button_SelectAll_Main;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_SelectAll_Main = value;
			darkButton = _Button_SelectAll_Main;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	public CopyOverPrompt()
	{
		Checkboxes = new Dictionary<CheckBoxWrapper, DeltaCopyOverElement>();
		Checkboxes_Secondary = new Dictionary<CheckBoxWrapper, DeltaCopyOverElement_Component>();
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
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_0541: Unknown result type (might be due to invalid IL or missing references)
		//IL_054b: Expected O, but got Unknown
		//IL_070d: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0802: Unknown result type (might be due to invalid IL or missing references)
		//IL_080c: Expected O, but got Unknown
		//IL_0c73: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c7d: Expected O, but got Unknown
		//IL_0d53: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ded: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e78: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f03: Unknown result type (might be due to invalid IL or missing references)
		CheckBox1 = new DarkCheckBox();
		Panel_Deltas = new FlowLayoutPanel();
		CheckBox2 = new DarkCheckBox();
		CheckBox3 = new DarkCheckBox();
		CheckBox4 = new DarkCheckBox();
		CheckBox5 = new DarkCheckBox();
		CheckBox6 = new DarkCheckBox();
		CheckBox7 = new DarkCheckBox();
		LabelDBID = new DarkLabel();
		Label2 = new DarkLabel();
		Label3 = new DarkLabel();
		Button_Commit = new DarkButton();
		Button_Skip = new DarkButton();
		Label_MainTable = new DarkLabel();
		Panel_Deltas_Associated = new FlowLayoutPanel();
		CheckBox8 = new DarkCheckBox();
		CheckBox9 = new DarkCheckBox();
		CheckBox10 = new DarkCheckBox();
		CheckBox11 = new DarkCheckBox();
		CheckBox12 = new DarkCheckBox();
		CheckBox13 = new DarkCheckBox();
		CheckBox14 = new DarkCheckBox();
		Label_AssociatedTables = new DarkLabel();
		Button_SelectAll_Sub = new DarkButton();
		Button_DeselectAll_Sub = new DarkButton();
		Button_DeselectAll_Main = new DarkButton();
		Button_SelectAll_Main = new DarkButton();
		((Control)Panel_Deltas).SuspendLayout();
		((Control)Panel_Deltas_Associated).SuspendLayout();
		((Control)this).SuspendLayout();
		((ButtonBase)CheckBox1).AutoSize = true;
		((Control)CheckBox1).Location = new Point(3, 3);
		((Control)CheckBox1).Name = "CheckBox1";
		((Control)CheckBox1).Size = new Size(164, 19);
		((Control)CheckBox1).TabIndex = 0;
		((ButtonBase)CheckBox1).Text = "RangeMax (80.0 ---> 95.0)";
		((Control)Panel_Deltas).Anchor = (AnchorStyles)1;
		((ScrollableControl)Panel_Deltas).AutoScroll = true;
		((Control)Panel_Deltas).BackColor = Color.FromArgb(60, 63, 65);
		((Control)Panel_Deltas).Controls.Add((Control)(object)CheckBox1);
		((Control)Panel_Deltas).Controls.Add((Control)(object)CheckBox2);
		((Control)Panel_Deltas).Controls.Add((Control)(object)CheckBox3);
		((Control)Panel_Deltas).Controls.Add((Control)(object)CheckBox4);
		((Control)Panel_Deltas).Controls.Add((Control)(object)CheckBox5);
		((Control)Panel_Deltas).Controls.Add((Control)(object)CheckBox6);
		((Control)Panel_Deltas).Controls.Add((Control)(object)CheckBox7);
		Panel_Deltas.FlowDirection = (FlowDirection)1;
		((Control)Panel_Deltas).Location = new Point(17, 83);
		((Control)Panel_Deltas).Name = "Panel_Deltas";
		((Control)Panel_Deltas).Size = new Size(877, 169);
		((Control)Panel_Deltas).TabIndex = 1;
		Panel_Deltas.WrapContents = false;
		((ButtonBase)CheckBox2).AutoSize = true;
		((Control)CheckBox2).Location = new Point(3, 28);
		((Control)CheckBox2).Name = "CheckBox2";
		((Control)CheckBox2).Size = new Size(172, 19);
		((Control)CheckBox2).TabIndex = 1;
		((ButtonBase)CheckBox2).Text = "ScanInterval (10.0 ---> 12.0)";
		((ButtonBase)CheckBox3).AutoSize = true;
		((Control)CheckBox3).Location = new Point(3, 53);
		((Control)CheckBox3).Name = "CheckBox3";
		((Control)CheckBox3).Size = new Size(214, 19);
		((Control)CheckBox3).TabIndex = 2;
		((ButtonBase)CheckBox3).Text = "Name (IBAS ---> IBAS [TV Camera])";
		((ButtonBase)CheckBox4).AutoSize = true;
		((Control)CheckBox4).Location = new Point(3, 78);
		((Control)CheckBox4).Name = "CheckBox4";
		((Control)CheckBox4).Size = new Size(645, 19);
		((Control)CheckBox4).TabIndex = 3;
		((ButtonBase)CheckBox4).Text = "Type (Visual, 2nd Generation TV Camera (1980s/1990s, AXX-1 TCS) ---> 3rd Generation TV Camera (2000s/2010s, CCD))";
		((ButtonBase)CheckBox5).AutoSize = true;
		((Control)CheckBox5).Location = new Point(3, 103);
		((Control)CheckBox5).Name = "CheckBox5";
		((Control)CheckBox5).Size = new Size(283, 19);
		((Control)CheckBox5).TabIndex = 4;
		((ButtonBase)CheckBox5).Text = "[DataSensorCapabilities] Air Search ---> Nothing";
		((ButtonBase)CheckBox6).AutoSize = true;
		((Control)CheckBox6).Location = new Point(3, 128);
		((Control)CheckBox6).Name = "CheckBox6";
		((Control)CheckBox6).Size = new Size(373, 19);
		((Control)CheckBox6).TabIndex = 5;
		((ButtonBase)CheckBox6).Text = "[DataSensorCapabilities] Land Search - Fixed Facility ---> Nothing";
		((ButtonBase)CheckBox7).AutoSize = true;
		((Control)CheckBox7).Location = new Point(3, 153);
		((Control)CheckBox7).Name = "CheckBox7";
		((Control)CheckBox7).Size = new Size(373, 19);
		((Control)CheckBox7).TabIndex = 6;
		((ButtonBase)CheckBox7).Text = "[DataSensorCapabilities] Land Search - Fixed Facility ---> Nothing";
		LabelDBID.AutoSize = true;
		((Control)LabelDBID).Font = new Font("Microsoft Sans Serif", 10f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)LabelDBID).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)LabelDBID).Location = new Point(12, 9);
		((Control)LabelDBID).Name = "LabelDBID";
		((Control)LabelDBID).Size = new Size(129, 17);
		((Control)LabelDBID).TabIndex = 2;
		((Label)LabelDBID).Text = "Sensor ID #6427";
		Label2.AutoSize = true;
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(14, 40);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(0, 15);
		((Control)Label2).TabIndex = 3;
		Label3.AutoSize = true;
		((Control)Label3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label3).Location = new Point(14, 27);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(401, 15);
		((Control)Label3).TabIndex = 5;
		((Label)Label3).Text = "exists in the target DB but has discrepancies. Select the entries to copy over";
		((Button)Button_Commit).DialogResult = (DialogResult)1;
		((Control)Button_Commit).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_Commit).Location = new Point(739, 502);
		((Control)Button_Commit).Name = "Button_Commit";
		((Control)Button_Commit).Padding = new Padding(5);
		((Control)Button_Commit).Size = new Size(150, 23);
		((Control)Button_Commit).TabIndex = 6;
		Button_Commit.Text = "Commit";
		((Button)Button_Skip).DialogResult = (DialogResult)3;
		((Control)Button_Skip).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_Skip).Location = new Point(575, 502);
		((Control)Button_Skip).Name = "Button_Skip";
		((Control)Button_Skip).Padding = new Padding(5);
		((Control)Button_Skip).Size = new Size(158, 23);
		((Control)Button_Skip).TabIndex = 7;
		Button_Skip.Text = "Skip";
		Label_MainTable.AutoSize = true;
		((Control)Label_MainTable).Font = new Font("Microsoft Sans Serif", 14f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label_MainTable).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_MainTable).Location = new Point(15, 56);
		((Control)Label_MainTable).Name = "Label_MainTable";
		((Control)Label_MainTable).Size = new Size(106, 24);
		((Control)Label_MainTable).TabIndex = 8;
		((Label)Label_MainTable).Text = "Main table";
		((ScrollableControl)Panel_Deltas_Associated).AutoScroll = true;
		((Control)Panel_Deltas_Associated).BackColor = Color.FromArgb(60, 63, 65);
		((Control)Panel_Deltas_Associated).Controls.Add((Control)(object)CheckBox8);
		((Control)Panel_Deltas_Associated).Controls.Add((Control)(object)CheckBox9);
		((Control)Panel_Deltas_Associated).Controls.Add((Control)(object)CheckBox10);
		((Control)Panel_Deltas_Associated).Controls.Add((Control)(object)CheckBox11);
		((Control)Panel_Deltas_Associated).Controls.Add((Control)(object)CheckBox12);
		((Control)Panel_Deltas_Associated).Controls.Add((Control)(object)CheckBox13);
		((Control)Panel_Deltas_Associated).Controls.Add((Control)(object)CheckBox14);
		Panel_Deltas_Associated.FlowDirection = (FlowDirection)1;
		((Control)Panel_Deltas_Associated).Location = new Point(15, 297);
		((Control)Panel_Deltas_Associated).Name = "Panel_Deltas_Associated";
		((Control)Panel_Deltas_Associated).Size = new Size(877, 177);
		((Control)Panel_Deltas_Associated).TabIndex = 9;
		Panel_Deltas_Associated.WrapContents = false;
		((ButtonBase)CheckBox8).AutoSize = true;
		((Control)CheckBox8).Location = new Point(3, 3);
		((Control)CheckBox8).Name = "CheckBox8";
		((Control)CheckBox8).Size = new Size(164, 19);
		((Control)CheckBox8).TabIndex = 0;
		((ButtonBase)CheckBox8).Text = "RangeMax (80.0 ---> 95.0)";
		((ButtonBase)CheckBox9).AutoSize = true;
		((Control)CheckBox9).Location = new Point(3, 28);
		((Control)CheckBox9).Name = "CheckBox9";
		((Control)CheckBox9).Size = new Size(172, 19);
		((Control)CheckBox9).TabIndex = 1;
		((ButtonBase)CheckBox9).Text = "ScanInterval (10.0 ---> 12.0)";
		((ButtonBase)CheckBox10).AutoSize = true;
		((Control)CheckBox10).Location = new Point(3, 53);
		((Control)CheckBox10).Name = "CheckBox10";
		((Control)CheckBox10).Size = new Size(214, 19);
		((Control)CheckBox10).TabIndex = 2;
		((ButtonBase)CheckBox10).Text = "Name (IBAS ---> IBAS [TV Camera])";
		((ButtonBase)CheckBox11).AutoSize = true;
		((Control)CheckBox11).Location = new Point(3, 78);
		((Control)CheckBox11).Name = "CheckBox11";
		((Control)CheckBox11).Size = new Size(645, 19);
		((Control)CheckBox11).TabIndex = 3;
		((ButtonBase)CheckBox11).Text = "Type (Visual, 2nd Generation TV Camera (1980s/1990s, AXX-1 TCS) ---> 3rd Generation TV Camera (2000s/2010s, CCD))";
		((ButtonBase)CheckBox12).AutoSize = true;
		((Control)CheckBox12).Location = new Point(3, 103);
		((Control)CheckBox12).Name = "CheckBox12";
		((Control)CheckBox12).Size = new Size(283, 19);
		((Control)CheckBox12).TabIndex = 4;
		((ButtonBase)CheckBox12).Text = "[DataSensorCapabilities] Air Search ---> Nothing";
		((ButtonBase)CheckBox13).AutoSize = true;
		((Control)CheckBox13).Location = new Point(3, 128);
		((Control)CheckBox13).Name = "CheckBox13";
		((Control)CheckBox13).Size = new Size(373, 19);
		((Control)CheckBox13).TabIndex = 5;
		((ButtonBase)CheckBox13).Text = "[DataSensorCapabilities] Land Search - Fixed Facility ---> Nothing";
		((ButtonBase)CheckBox14).AutoSize = true;
		((Control)CheckBox14).Location = new Point(3, 153);
		((Control)CheckBox14).Name = "CheckBox14";
		((Control)CheckBox14).Size = new Size(373, 19);
		((Control)CheckBox14).TabIndex = 6;
		((ButtonBase)CheckBox14).Text = "[DataSensorCapabilities] Land Search - Fixed Facility ---> Nothing";
		Label_AssociatedTables.AutoSize = true;
		((Control)Label_AssociatedTables).Font = new Font("Microsoft Sans Serif", 14f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label_AssociatedTables).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_AssociatedTables).Location = new Point(14, 270);
		((Control)Label_AssociatedTables).Name = "Label_AssociatedTables";
		((Control)Label_AssociatedTables).Size = new Size(181, 24);
		((Control)Label_AssociatedTables).TabIndex = 10;
		((Label)Label_AssociatedTables).Text = "Associated Tables";
		((Control)Button_SelectAll_Sub).Anchor = (AnchorStyles)0;
		((Control)Button_SelectAll_Sub).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_SelectAll_Sub).Location = new Point(741, 268);
		((Control)Button_SelectAll_Sub).Name = "Button_SelectAll_Sub";
		((Control)Button_SelectAll_Sub).Padding = new Padding(5);
		((Control)Button_SelectAll_Sub).Size = new Size(154, 23);
		((Control)Button_SelectAll_Sub).TabIndex = 11;
		Button_SelectAll_Sub.Text = "Select all";
		((Control)Button_DeselectAll_Sub).Anchor = (AnchorStyles)0;
		((Control)Button_DeselectAll_Sub).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_DeselectAll_Sub).Location = new Point(581, 268);
		((Control)Button_DeselectAll_Sub).Name = "Button_DeselectAll_Sub";
		((Control)Button_DeselectAll_Sub).Padding = new Padding(5);
		((Control)Button_DeselectAll_Sub).Size = new Size(154, 23);
		((Control)Button_DeselectAll_Sub).TabIndex = 12;
		Button_DeselectAll_Sub.Text = "Deselect all";
		((Control)Button_DeselectAll_Main).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_DeselectAll_Main).Location = new Point(580, 54);
		((Control)Button_DeselectAll_Main).Name = "Button_DeselectAll_Main";
		((Control)Button_DeselectAll_Main).Padding = new Padding(5);
		((Control)Button_DeselectAll_Main).Size = new Size(154, 23);
		((Control)Button_DeselectAll_Main).TabIndex = 14;
		Button_DeselectAll_Main.Text = "Deselect all";
		((Control)Button_SelectAll_Main).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_SelectAll_Main).Location = new Point(740, 54);
		((Control)Button_SelectAll_Main).Name = "Button_SelectAll_Main";
		((Control)Button_SelectAll_Main).Padding = new Padding(5);
		((Control)Button_SelectAll_Main).Size = new Size(154, 23);
		((Control)Button_SelectAll_Main).TabIndex = 13;
		Button_SelectAll_Main.Text = "Select all";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(7f, 15f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(906, 537);
		((Control)this).Controls.Add((Control)(object)Button_DeselectAll_Main);
		((Control)this).Controls.Add((Control)(object)Button_SelectAll_Main);
		((Control)this).Controls.Add((Control)(object)Button_DeselectAll_Sub);
		((Control)this).Controls.Add((Control)(object)Button_SelectAll_Sub);
		((Control)this).Controls.Add((Control)(object)Label_AssociatedTables);
		((Control)this).Controls.Add((Control)(object)Panel_Deltas_Associated);
		((Control)this).Controls.Add((Control)(object)Label_MainTable);
		((Control)this).Controls.Add((Control)(object)Button_Skip);
		((Control)this).Controls.Add((Control)(object)Button_Commit);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)LabelDBID);
		((Control)this).Controls.Add((Control)(object)Panel_Deltas);
		((Form)this).Location = new Point(0, 0);
		((Control)this).Name = "CopyOverPrompt";
		((Form)this).Text = "Sensor #6427 copy over";
		((Control)Panel_Deltas).ResumeLayout(false);
		((Control)Panel_Deltas).PerformLayout();
		((Control)Panel_Deltas_Associated).ResumeLayout(false);
		((Control)Panel_Deltas_Associated).PerformLayout();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	public void Refresh(Dictionary<string, Table_Delta> Delta, HashTableNode_Pair Pair, string ID, CopyOver CopyoverInstance)
	{
		//IL_032a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0330: Invalid comparison between Unknown and I4
		((Form)this).Text = Pair.ReadableName + " ID #" + ID + " copyover";
		((Label)LabelDBID).Text = Pair.ReadableName + " ID #" + ID;
		((Control)Panel_Deltas).Controls.Clear();
		((Control)Panel_Deltas_Associated).Controls.Clear();
		((Label)Label_MainTable).Text = "Main table (" + Pair.DataSource.ParentHashtable.Name + ")";
		foreach (KeyValuePair<string, Table_Delta> Deltum in Delta)
		{
			foreach (Field_Delta fieldDelta in Deltum.Value.FieldDeltas)
			{
				DeltaCopyOverElement deltaCopyOverElement = new DeltaCopyOverElement();
				deltaCopyOverElement.CB.Checked = true;
				deltaCopyOverElement.TB_Name.Text = fieldDelta.Column;
				deltaCopyOverElement.TB_SourceValue.Text = fieldDelta.OriginalValue;
				deltaCopyOverElement.TB_TargetValue.Text = fieldDelta.TargetValue;
				((Control)deltaCopyOverElement).BackColor = Color.SandyBrown;
				((Control)Panel_Deltas).Controls.Add((Control)(object)deltaCopyOverElement);
				Checkboxes.Add(new CheckBoxWrapper(fieldDelta), deltaCopyOverElement);
			}
			foreach (Row_Delta rowDelta in Deltum.Value.RowDeltas)
			{
				DeltaCopyOverElement_Component deltaCopyOverElement_Component = new DeltaCopyOverElement_Component();
				deltaCopyOverElement_Component.CB.Checked = true;
				deltaCopyOverElement_Component.TB_Table.Text = rowDelta.Table.Name;
				string componentOrCodeID = rowDelta.Value.GetComponentOrCodeID();
				HashTable_Row hashTable_Row = null;
				if (!string.IsNullOrEmpty(componentOrCodeID) && rowDelta.Value.ParentHashTable != null)
				{
					hashTable_Row = rowDelta.Table.GetComponentData(componentOrCodeID);
				}
				if (Information.IsNothing((object)hashTable_Row))
				{
					string text = "";
					foreach (KeyValuePair<string, HashTable_Field> fieldsByColumn in rowDelta.Value.FieldsByColumns)
					{
						text = text + fieldsByColumn.Key + " : " + fieldsByColumn.Value.Value + " | ";
					}
					deltaCopyOverElement_Component.TB_ActualName.Text = text;
				}
				else
				{
					deltaCopyOverElement_Component.TB_ActualName.Text = hashTable_Row.Name;
				}
				deltaCopyOverElement_Component.TB_Method.Text = rowDelta.Method.ToString();
				((Control)Panel_Deltas_Associated).Controls.Add((Control)(object)deltaCopyOverElement_Component);
				Checkboxes_Secondary.Add(new CheckBoxWrapper(rowDelta), deltaCopyOverElement_Component);
				if (rowDelta.Method == MethodDelta.Addition)
				{
					((Control)deltaCopyOverElement_Component).BackColor = Color.LightGreen;
				}
				else if (rowDelta.Method == MethodDelta.Deletion)
				{
					((Control)deltaCopyOverElement_Component).BackColor = Color.Salmon;
				}
			}
		}
		if ((int)((Form)this).ShowDialog() == 1)
		{
			Commit(CopyoverInstance, Delta);
		}
	}

	public void Commit(CopyOver CopyoverInstance, Dictionary<string, Table_Delta> Table_Deltas)
	{
		foreach (Table_Delta value in Table_Deltas.Values)
		{
			Table_Delta table_Delta = new Table_Delta();
			foreach (KeyValuePair<CheckBoxWrapper, DeltaCopyOverElement> checkbox in Checkboxes)
			{
				if (checkbox.Value.CB.Checked && !Information.IsNothing((object)checkbox.Key.FieldDelta))
				{
					table_Delta.ModifyField(checkbox.Key.FieldDelta.ID, checkbox.Key.FieldDelta.Table, checkbox.Key.FieldDelta.Column, checkbox.Value.TB_TargetValue.Text);
				}
			}
			foreach (KeyValuePair<CheckBoxWrapper, DeltaCopyOverElement_Component> item in Checkboxes_Secondary)
			{
				if (item.Value.CB.Checked && !Information.IsNothing((object)item.Key.RowDelta))
				{
					Row_Delta rowDelta = item.Key.RowDelta;
					if (rowDelta.Method == MethodDelta.Addition)
					{
						table_Delta.AddRow(item.Key.RowDelta.Table, item.Key.RowDelta.ID, item.Key.RowDelta.Value);
					}
					else if (rowDelta.Method == MethodDelta.Deletion)
					{
						table_Delta.DeleteRow(rowDelta.Table, rowDelta.ID, rowDelta.Editable, rowDelta.Value);
					}
				}
			}
			value.Commit(CopyoverInstance);
		}
	}

	private void method_2(object sender, EventArgs e)
	{
		method_6(Panel_Deltas, bool_2: false);
	}

	private void method_3(object sender, EventArgs e)
	{
		method_6(Panel_Deltas, bool_2: true);
	}

	private void method_4(object sender, EventArgs e)
	{
		method_6(Panel_Deltas_Associated, bool_2: false);
	}

	private void method_5(object sender, EventArgs e)
	{
		method_6(Panel_Deltas_Associated, bool_2: true);
	}

	private void method_6(FlowLayoutPanel flowLayoutPanel_0, bool bool_2)
	{
		foreach (object control in ((Control)flowLayoutPanel_0).Controls)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(control);
			if ((object)objectValue.GetType() == typeof(DeltaCopyOverElement))
			{
				((DeltaCopyOverElement)objectValue).CB.Checked = bool_2;
			}
			else if ((object)objectValue.GetType() == typeof(DeltaCopyOverElement_Component))
			{
				((DeltaCopyOverElement_Component)objectValue).CB.Checked = bool_2;
			}
		}
	}

	static CopyOverPrompt()
	{
		Class72.smethod_20();
	}
}
