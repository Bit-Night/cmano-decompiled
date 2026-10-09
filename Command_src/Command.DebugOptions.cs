using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class DebugOptions : Form
{
	private IContainer icontainer_0;

	[AccessedThroughProperty("Combo_Compression")]
	[CompilerGenerated]
	private DarkUIComboBox _Combo_Compression;

	[AccessedThroughProperty("ComboReolution")]
	[CompilerGenerated]
	private DarkUIComboBox _ComboReolution;

	[AccessedThroughProperty("CN_DiscriminateTime")]
	[CompilerGenerated]
	private DarkCheckBox _CN_DiscriminateTime;

	[field: AccessedThroughProperty("GB_SimRes")]
	internal virtual DarkGroupBox GB_SimRes { get; set; }

	[field: AccessedThroughProperty("DarkLabel2")]
	internal virtual DarkLabel DarkLabel2 { get; set; }

	[field: AccessedThroughProperty("DarkLabel1")]
	internal virtual DarkLabel DarkLabel1 { get; set; }

	internal virtual DarkUIComboBox Combo_Compression
	{
		[CompilerGenerated]
		get
		{
			return _Combo_Compression;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_1;
			DarkUIComboBox darkUIComboBox = _Combo_Compression;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_Combo_Compression = value;
			darkUIComboBox = _Combo_Compression;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	internal virtual DarkUIComboBox ComboReolution
	{
		[CompilerGenerated]
		get
		{
			return _ComboReolution;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_0;
			DarkUIComboBox darkUIComboBox = _ComboReolution;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_ComboReolution = value;
			darkUIComboBox = _ComboReolution;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CN_DiscriminateTime
	{
		[CompilerGenerated]
		get
		{
			return _CN_DiscriminateTime;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			DarkCheckBox darkCheckBox = _CN_DiscriminateTime;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CN_DiscriminateTime = value;
			darkCheckBox = _CN_DiscriminateTime;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel3")]
	internal virtual DarkLabel DarkLabel3 { get; set; }

	[field: AccessedThroughProperty("DarkLabel6")]
	internal virtual DarkLabel DarkLabel6 { get; set; }

	[field: AccessedThroughProperty("DarkLabel5")]
	internal virtual DarkLabel DarkLabel5 { get; set; }

	[field: AccessedThroughProperty("DarkLabel4")]
	internal virtual DarkLabel DarkLabel4 { get; set; }

	public DebugOptions()
	{
		((Form)this).Load += DebugOptions_Load;
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
		//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d0: Expected O, but got Unknown
		//IL_045f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0469: Expected O, but got Unknown
		CN_DiscriminateTime = new DarkCheckBox();
		GB_SimRes = new DarkGroupBox();
		DarkLabel3 = new DarkLabel();
		DarkLabel2 = new DarkLabel();
		DarkLabel1 = new DarkLabel();
		Combo_Compression = new DarkUIComboBox();
		ComboReolution = new DarkUIComboBox();
		DarkLabel4 = new DarkLabel();
		DarkLabel5 = new DarkLabel();
		DarkLabel6 = new DarkLabel();
		((Control)GB_SimRes).SuspendLayout();
		((Control)this).SuspendLayout();
		((ButtonBase)CN_DiscriminateTime).AutoSize = true;
		((Control)CN_DiscriminateTime).Location = new Point(20, 10);
		((Control)CN_DiscriminateTime).Name = "CN_DiscriminateTime";
		((Control)CN_DiscriminateTime).Size = new Size(197, 17);
		((Control)CN_DiscriminateTime).TabIndex = 1;
		((ButtonBase)CN_DiscriminateTime).Text = "Enabled Time & Compression options ";
		((Control)GB_SimRes).Controls.Add((Control)(object)DarkLabel6);
		((Control)GB_SimRes).Controls.Add((Control)(object)DarkLabel5);
		((Control)GB_SimRes).Controls.Add((Control)(object)DarkLabel4);
		((Control)GB_SimRes).Controls.Add((Control)(object)DarkLabel3);
		((Control)GB_SimRes).Controls.Add((Control)(object)DarkLabel2);
		((Control)GB_SimRes).Controls.Add((Control)(object)DarkLabel1);
		((Control)GB_SimRes).Controls.Add((Control)(object)Combo_Compression);
		((Control)GB_SimRes).Controls.Add((Control)(object)ComboReolution);
		((Control)GB_SimRes).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GB_SimRes).Location = new Point(12, 12);
		((Control)GB_SimRes).Name = "GB_SimRes";
		((Control)GB_SimRes).Size = new Size(277, 166);
		((Control)GB_SimRes).TabIndex = 0;
		((GroupBox)GB_SimRes).TabStop = false;
		DarkLabel3.AutoSize = true;
		((Control)DarkLabel3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel3).Location = new Point(23, 72);
		((Control)DarkLabel3).Name = "DarkLabel3";
		((Control)DarkLabel3).Size = new Size(248, 13);
		((Control)DarkLabel3).TabIndex = 5;
		((Label)DarkLabel3).Text = "Note : Actual compression is at largest denominator";
		DarkLabel2.AutoSize = true;
		((Control)DarkLabel2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel2).Location = new Point(20, 52);
		((Control)DarkLabel2).Name = "DarkLabel2";
		((Control)DarkLabel2).Size = new Size(67, 13);
		((Control)DarkLabel2).TabIndex = 4;
		((Label)DarkLabel2).Text = "Compression";
		DarkLabel1.AutoSize = true;
		((Control)DarkLabel1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel1).Location = new Point(20, 25);
		((Control)DarkLabel1).Name = "DarkLabel1";
		((Control)DarkLabel1).Size = new Size(57, 13);
		((Control)DarkLabel1).TabIndex = 3;
		((Label)DarkLabel1).Text = "Resolution";
		((ComboBox)Combo_Compression).BackColor = Color.Transparent;
		((ComboBox)Combo_Compression).DrawMode = (DrawMode)1;
		((ComboBox)Combo_Compression).DropDownStyle = (ComboBoxStyle)2;
		((Control)Combo_Compression).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)Combo_Compression).FormattingEnabled = true;
		((Control)Combo_Compression).Location = new Point(86, 48);
		((Control)Combo_Compression).Name = "Combo_Compression";
		((Control)Combo_Compression).Size = new Size(121, 21);
		((Control)Combo_Compression).TabIndex = 2;
		((ComboBox)ComboReolution).BackColor = Color.Transparent;
		((ComboBox)ComboReolution).DrawMode = (DrawMode)1;
		((ComboBox)ComboReolution).DropDownStyle = (ComboBoxStyle)2;
		((Control)ComboReolution).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)ComboReolution).FormattingEnabled = true;
		((Control)ComboReolution).Location = new Point(86, 21);
		((Control)ComboReolution).Name = "ComboReolution";
		((Control)ComboReolution).Size = new Size(121, 21);
		((Control)ComboReolution).TabIndex = 1;
		DarkLabel4.AutoSize = true;
		((Control)DarkLabel4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel4).Location = new Point(20, 99);
		((Control)DarkLabel4).Name = "DarkLabel4";
		((Control)DarkLabel4).Size = new Size(165, 13);
		((Control)DarkLabel4).TabIndex = 6;
		((Label)DarkLabel4).Text = "CTRL + SPACEBAR ITERATION";
		DarkLabel5.AutoSize = true;
		((Control)DarkLabel5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel5).Location = new Point(20, 113);
		((Control)DarkLabel5).Name = "DarkLabel5";
		((Control)DarkLabel5).Size = new Size(106, 13);
		((Control)DarkLabel5).TabIndex = 7;
		((Label)DarkLabel5).Text = "Step by step iteration";
		DarkLabel6.AutoSize = true;
		((Control)DarkLabel6).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel6).Location = new Point(20, 129);
		((Control)DarkLabel6).Name = "DarkLabel6";
		((Control)DarkLabel6).Size = new Size(164, 13);
		((Control)DarkLabel6).TabIndex = 8;
		((Label)DarkLabel6).Text = "Hold keys for continuous iteration";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).BackColor = Color.FromArgb(65, 65, 65);
		((Form)this).ClientSize = new Size(306, 190);
		((Control)this).Controls.Add((Control)(object)CN_DiscriminateTime);
		((Control)this).Controls.Add((Control)(object)GB_SimRes);
		((Control)this).Name = "DebugOptions";
		((Form)this).Text = "DebugOptions";
		((Control)GB_SimRes).ResumeLayout(false);
		((Control)GB_SimRes).PerformLayout();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void DebugOptions_Load(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)Client.CurrentScenario))
		{
			RefreshAll();
		}
	}

	public void RefreshAll()
	{
		RefreshDiscriminateTime();
	}

	public void RefreshDiscriminateTime()
	{
		((CheckBox)CN_DiscriminateTime).Checked = Client.CurrentScenario.DEBUG_DiscriminateResolutionAndCompression;
		((Control)GB_SimRes).Visible = Client.CurrentScenario.DEBUG_DiscriminateResolutionAndCompression;
		((ComboBox)Combo_Compression).Items.Clear();
		((ComboBox)ComboReolution).Items.Clear();
		foreach (object value in Enum.GetValues(typeof(Scenario.enumTimeCompression)))
		{
			object objectValue = RuntimeHelpers.GetObjectValue(value);
			((ComboBox)Combo_Compression).Items.Add((object)Conversions.ToInteger(objectValue));
		}
		((ComboBox)Combo_Compression).Items.Add((object)"NO OVERRIDE");
		((ComboBox)Combo_Compression).SelectedItem = RuntimeHelpers.GetObjectValue(((ComboBox)Combo_Compression).Items[((ComboBox)Combo_Compression).Items.Count - 1]);
		((ComboBox)ComboReolution).Items.Add((object)0.1);
		((ComboBox)ComboReolution).Items.Add((object)1);
		((ComboBox)ComboReolution).Items.Add((object)5);
		((ComboBox)ComboReolution).Items.Add((object)"NO OVERRIDE");
		((ComboBox)ComboReolution).SelectedItem = RuntimeHelpers.GetObjectValue(((ComboBox)ComboReolution).Items[((ComboBox)ComboReolution).Items.Count - 1]);
	}

	private void method_0(object sender, EventArgs e)
	{
		if (((ComboBox)ComboReolution).SelectedIndex == ((ComboBox)ComboReolution).Items.Count - 1)
		{
			Client.CurrentScenario.DEBUG_CustomResolution = null;
		}
		else
		{
			Client.CurrentScenario.DEBUG_CustomResolution = Conversions.ToSingle(((ComboBox)ComboReolution).SelectedItem);
		}
	}

	private void method_1(object sender, EventArgs e)
	{
		if (((ComboBox)Combo_Compression).SelectedIndex == ((ComboBox)Combo_Compression).Items.Count - 1)
		{
			Client.CurrentScenario.DEBUG_CustomCompression = null;
		}
		else
		{
			Client.CurrentScenario.DEBUG_CustomCompression = (Scenario.enumTimeCompression)Conversions.ToByte(((ComboBox)Combo_Compression).SelectedItem);
		}
	}

	private void method_2(object sender, EventArgs e)
	{
		Client.CurrentScenario.DEBUG_DiscriminateResolutionAndCompression = ((CheckBox)CN_DiscriminateTime).Checked;
		RefreshDiscriminateTime();
	}

	static DebugOptions()
	{
		Class72.smethod_20();
	}
}
