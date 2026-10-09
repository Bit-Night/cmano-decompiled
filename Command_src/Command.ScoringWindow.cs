using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.My;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class ScoringWindow : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("NUD_Disaster")]
	private DarkNumericUpDown _NUD_Disaster;

	[AccessedThroughProperty("NUD_Triumph")]
	[CompilerGenerated]
	private DarkNumericUpDown _NUD_Triumph;

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

	[field: AccessedThroughProperty("Label8")]
	internal virtual DarkLabel Label8 { get; set; }

	[field: AccessedThroughProperty("Label_MajorVictory")]
	internal virtual DarkLabel Label_MajorVictory { get; set; }

	[field: AccessedThroughProperty("Label_MinorVictory")]
	internal virtual DarkLabel Label_MinorVictory { get; set; }

	[field: AccessedThroughProperty("Label_Average")]
	internal virtual DarkLabel Label_Average { get; set; }

	[field: AccessedThroughProperty("Label_MinorDefeat")]
	internal virtual DarkLabel Label_MinorDefeat { get; set; }

	[field: AccessedThroughProperty("Label_MajorDefeat")]
	internal virtual DarkLabel Label_MajorDefeat { get; set; }

	internal virtual DarkNumericUpDown NUD_Disaster
	{
		[CompilerGenerated]
		get
		{
			return _NUD_Disaster;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = [SpecialName] (object sender, EventArgs e) =>
			{
				method_2();
			};
			DarkNumericUpDown darkNumericUpDown = _NUD_Disaster;
			if (darkNumericUpDown != null)
			{
				((NumericUpDown)darkNumericUpDown).ValueChanged -= eventHandler;
			}
			_NUD_Disaster = value;
			darkNumericUpDown = _NUD_Disaster;
			if (darkNumericUpDown != null)
			{
				((NumericUpDown)darkNumericUpDown).ValueChanged += eventHandler;
			}
		}
	}

	internal virtual DarkNumericUpDown NUD_Triumph
	{
		[CompilerGenerated]
		get
		{
			return _NUD_Triumph;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = [SpecialName] (object sender, EventArgs e) =>
			{
				method_3();
			};
			DarkNumericUpDown darkNumericUpDown = _NUD_Triumph;
			if (darkNumericUpDown != null)
			{
				((NumericUpDown)darkNumericUpDown).ValueChanged -= eventHandler;
			}
			_NUD_Triumph = value;
			darkNumericUpDown = _NUD_Triumph;
			if (darkNumericUpDown != null)
			{
				((NumericUpDown)darkNumericUpDown).ValueChanged += eventHandler;
			}
		}
	}

	public ScoringWindow()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).Load += ScoringWindow_Load;
		((Control)this).KeyDown += new KeyEventHandler(ScoringWindow_KeyDown);
		((Form)this).FormClosing += new FormClosingEventHandler(ScoringWindow_FormClosing);
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
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		//IL_04c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cd: Expected O, but got Unknown
		//IL_0566: Unknown result type (might be due to invalid IL or missing references)
		//IL_0570: Expected O, but got Unknown
		Label1 = new DarkLabel();
		Label2 = new DarkLabel();
		Label8 = new DarkLabel();
		Label_MajorVictory = new DarkLabel();
		Label_MinorVictory = new DarkLabel();
		Label_Average = new DarkLabel();
		Label_MinorDefeat = new DarkLabel();
		Label_MajorDefeat = new DarkLabel();
		NUD_Disaster = new DarkNumericUpDown();
		NUD_Triumph = new DarkNumericUpDown();
		((ISupportInitialize)NUD_Disaster).BeginInit();
		((ISupportInitialize)NUD_Triumph).BeginInit();
		((Control)this).SuspendLayout();
		((Control)Label1).Font = new Font("Segoe UI", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(13, 13);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(217, 20);
		((Control)Label1).TabIndex = 0;
		((Label)Label1).Text = "Victory/Defeat Thresholds";
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(14, 56);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(56, 13);
		((Control)Label2).TabIndex = 1;
		((Label)Label2).Text = "Disaster:";
		((Control)Label8).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label8).Location = new Point(14, 228);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(56, 13);
		((Control)Label8).TabIndex = 11;
		((Label)Label8).Text = "Triumph:";
		Label_MajorVictory.AutoSize = true;
		((Control)Label_MajorVictory).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_MajorVictory).Location = new Point(14, 199);
		((Control)Label_MajorVictory).Name = "Label_MajorVictory";
		((Control)Label_MajorVictory).Size = new Size(81, 15);
		((Control)Label_MajorVictory).TabIndex = 10;
		((Label)Label_MajorVictory).Text = "Major Victory:";
		Label_MinorVictory.AutoSize = true;
		((Control)Label_MinorVictory).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_MinorVictory).Location = new Point(14, 171);
		((Control)Label_MinorVictory).Name = "Label_MinorVictory";
		((Control)Label_MinorVictory).Size = new Size(82, 15);
		((Control)Label_MinorVictory).TabIndex = 9;
		((Label)Label_MinorVictory).Text = "Minor Victory:";
		Label_Average.AutoSize = true;
		((Control)Label_Average).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_Average).Location = new Point(14, 142);
		((Control)Label_Average).Name = "Label_Average";
		((Control)Label_Average).Size = new Size(53, 15);
		((Control)Label_Average).TabIndex = 7;
		((Label)Label_Average).Text = "Average:";
		Label_MinorDefeat.AutoSize = true;
		((Control)Label_MinorDefeat).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_MinorDefeat).Location = new Point(14, 114);
		((Control)Label_MinorDefeat).Name = "Label_MinorDefeat";
		((Control)Label_MinorDefeat).Size = new Size(79, 15);
		((Control)Label_MinorDefeat).TabIndex = 5;
		((Label)Label_MinorDefeat).Text = "Minor Defeat:";
		Label_MajorDefeat.AutoSize = true;
		((Control)Label_MajorDefeat).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_MajorDefeat).Location = new Point(14, 87);
		((Control)Label_MajorDefeat).Name = "Label_MajorDefeat";
		((Control)Label_MajorDefeat).Size = new Size(78, 15);
		((Control)Label_MajorDefeat).TabIndex = 3;
		((Label)Label_MajorDefeat).Text = "Major Defeat:";
		((UpDownBase)NUD_Disaster).BackColor = Color.FromArgb(28, 28, 28);
		((UpDownBase)NUD_Disaster).BorderStyle = (BorderStyle)0;
		((Control)NUD_Disaster).Font = new Font("Segoe UI", 12f);
		((UpDownBase)NUD_Disaster).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)NUD_Disaster).Location = new Point(98, 52);
		((Control)NUD_Disaster).Name = "NUD_Disaster";
		((Control)NUD_Disaster).Size = new Size(132, 25);
		((Control)NUD_Disaster).TabIndex = 24;
		((UpDownBase)NUD_Triumph).BackColor = Color.FromArgb(28, 28, 28);
		((UpDownBase)NUD_Triumph).BorderStyle = (BorderStyle)0;
		((Control)NUD_Triumph).Font = new Font("Segoe UI", 12f);
		((UpDownBase)NUD_Triumph).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)NUD_Triumph).Location = new Point(98, 224);
		((Control)NUD_Triumph).Name = "NUD_Triumph";
		((Control)NUD_Triumph).Size = new Size(132, 25);
		((Control)NUD_Triumph).TabIndex = 25;
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(243, 260);
		((Control)this).Controls.Add((Control)(object)NUD_Triumph);
		((Control)this).Controls.Add((Control)(object)NUD_Disaster);
		((Control)this).Controls.Add((Control)(object)Label_MajorVictory);
		((Control)this).Controls.Add((Control)(object)Label_MinorVictory);
		((Control)this).Controls.Add((Control)(object)Label_Average);
		((Control)this).Controls.Add((Control)(object)Label_MinorDefeat);
		((Control)this).Controls.Add((Control)(object)Label_MajorDefeat);
		((Control)this).Controls.Add((Control)(object)Label8);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "ScoringWindow";
		((Form)this).ShowIcon = false;
		((Form)this).Text = "Scoring";
		((ISupportInitialize)NUD_Disaster).EndInit();
		((ISupportInitialize)NUD_Triumph).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void ScoringWindow_Load(object sender, EventArgs e)
	{
		((NumericUpDown)NUD_Disaster).Maximum = 2147483647m;
		((NumericUpDown)NUD_Disaster).Minimum = -2147483648m;
		((NumericUpDown)NUD_Triumph).Maximum = 2147483647m;
		((NumericUpDown)NUD_Triumph).Minimum = -2147483648m;
		if (!Client.CurrentSide.Scoring_Disaster.HasValue)
		{
			Client.CurrentSide.Scoring_Disaster = -100;
		}
		((NumericUpDown)NUD_Disaster).Value = new decimal(Client.CurrentSide.Scoring_Disaster.Value);
		if (!Client.CurrentSide.Scoring_Triumph.HasValue)
		{
			Client.CurrentSide.Scoring_Triumph = 100;
		}
		((NumericUpDown)NUD_Triumph).Value = new decimal(Client.CurrentSide.Scoring_Triumph.Value);
	}

	private void method_2()
	{
		if (Versioned.IsNumeric((object)((NumericUpDown)NUD_Disaster).Value))
		{
			Client.CurrentSide.Scoring_Disaster = Convert.ToInt32(((NumericUpDown)NUD_Disaster).Value);
			((Label)Label_MajorDefeat).Text = "Major Defeat: " + Conversions.ToString(Client.CurrentSide.Scoring_MajorDefeat);
			((Label)Label_MinorDefeat).Text = "Minor Defeat: " + Conversions.ToString(Client.CurrentSide.Scoring_MinorDefeat);
			((Label)Label_Average).Text = "Average: " + Conversions.ToString(Client.CurrentSide.Scoring_Average);
			((Label)Label_MinorVictory).Text = "Minor Victory: " + Conversions.ToString(Client.CurrentSide.Scoring_MinorVictory);
			((Label)Label_MajorVictory).Text = "Major Victory: " + Conversions.ToString(Client.CurrentSide.Scoring_MajorVictory);
		}
	}

	private void method_3()
	{
		if (Versioned.IsNumeric((object)((NumericUpDown)NUD_Triumph).Value))
		{
			Client.CurrentSide.Scoring_Triumph = Convert.ToInt32(((NumericUpDown)NUD_Triumph).Value);
			((Label)Label_MajorDefeat).Text = "Major Defeat: " + Conversions.ToString(Client.CurrentSide.Scoring_MajorDefeat);
			((Label)Label_MinorDefeat).Text = "Minor Defeat: " + Conversions.ToString(Client.CurrentSide.Scoring_MinorDefeat);
			((Label)Label_Average).Text = "Average: " + Conversions.ToString(Client.CurrentSide.Scoring_Average);
			((Label)Label_MinorVictory).Text = "Minor Victory: " + Conversions.ToString(Client.CurrentSide.Scoring_MinorVictory);
			((Label)Label_MajorVictory).Text = "Major Victory: " + Conversions.ToString(Client.CurrentSide.Scoring_MajorVictory);
		}
	}

	private void ScoringWindow_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Invalid comparison between Unknown and I4
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Invalid comparison between Unknown and I4
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Invalid comparison between Unknown and I4
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Invalid comparison between Unknown and I4
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Invalid comparison between Unknown and I4
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Invalid comparison between Unknown and I4
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Invalid comparison between Unknown and I4
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Invalid comparison between Unknown and I4
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Invalid comparison between Unknown and I4
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Invalid comparison between Unknown and I4
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Invalid comparison between Unknown and I4
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
		else if (!((Control)this).Visible || ((int)e.KeyCode != 37 && (int)e.KeyCode != 39 && (int)e.KeyCode != 33 && (int)e.KeyCode != 34 && (int)e.KeyCode != 35 && (int)e.KeyCode != 36 && ((int)e.KeyCode != 67 || (int)e.Modifiers != 131072) && ((int)e.KeyCode != 88 || (int)e.Modifiers != 131072) && ((int)e.KeyCode != 86 || (int)e.Modifiers != 131072)))
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void ScoringWindow_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	static ScoringWindow()
	{
		Class72.smethod_20();
	}
}
