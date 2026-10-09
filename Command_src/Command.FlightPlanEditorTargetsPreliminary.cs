using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class FlightPlanEditorTargetsPreliminary : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	[field: AccessedThroughProperty("ComboBox1")]
	internal virtual DarkUIComboBox ComboBox1 { get; set; }

	[field: AccessedThroughProperty("Combo_Strike_MinimumContactStanceToTrigger")]
	internal virtual DarkUIComboBox Combo_Strike_MinimumContactStanceToTrigger { get; set; }

	[field: AccessedThroughProperty("Label7")]
	internal virtual DarkLabel Label7 { get; set; }

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

	[field: AccessedThroughProperty("TextBox1")]
	internal virtual DarkUITextBox TextBox1 { get; set; }

	[field: AccessedThroughProperty("Button1")]
	internal virtual DarkButton Button1 { get; set; }

	[field: AccessedThroughProperty("UnitFilter_UnitDestroyed")]
	internal virtual UnitFilter UnitFilter_UnitDestroyed { get; set; }

	public FlightPlanEditorTargetsPreliminary()
	{
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
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Expected O, but got Unknown
		//IL_04e9: Unknown result type (might be due to invalid IL or missing references)
		Label1 = new DarkLabel();
		ComboBox1 = new DarkUIComboBox();
		Combo_Strike_MinimumContactStanceToTrigger = new DarkUIComboBox();
		Label7 = new DarkLabel();
		Label2 = new DarkLabel();
		TextBox1 = new DarkUITextBox();
		Button1 = new DarkButton();
		UnitFilter_UnitDestroyed = new UnitFilter();
		((Control)this).SuspendLayout();
		Label1.AutoSize = true;
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(28, 61);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(220, 15);
		((Control)Label1).TabIndex = 0;
		((Label)Label1).Text = "Aquire mission-relevant contacts within:";
		((ComboBox)ComboBox1).BackColor = Color.Transparent;
		((ComboBox)ComboBox1).DrawMode = (DrawMode)1;
		((ComboBox)ComboBox1).DropDownStyle = (ComboBoxStyle)2;
		((Control)ComboBox1).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)ComboBox1).FormattingEnabled = true;
		((ComboBox)ComboBox1).Items.AddRange(new object[6] { "2 nm", "5 nm", "10 nm", "50 nm", "200 nm", "unlimited distance" });
		((Control)ComboBox1).Location = new Point(321, 55);
		((Control)ComboBox1).Name = "ComboBox1";
		((Control)ComboBox1).Size = new Size(183, 21);
		((Control)ComboBox1).TabIndex = 1;
		((ComboBox)Combo_Strike_MinimumContactStanceToTrigger).BackColor = Color.Transparent;
		((ComboBox)Combo_Strike_MinimumContactStanceToTrigger).DrawMode = (DrawMode)1;
		((ComboBox)Combo_Strike_MinimumContactStanceToTrigger).DropDownStyle = (ComboBoxStyle)2;
		((Control)Combo_Strike_MinimumContactStanceToTrigger).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)Combo_Strike_MinimumContactStanceToTrigger).FormattingEnabled = true;
		((ComboBox)Combo_Strike_MinimumContactStanceToTrigger).Items.AddRange(new object[3] { "Unknown", "Unfriendly", "Hostile" });
		((Control)Combo_Strike_MinimumContactStanceToTrigger).Location = new Point(321, 90);
		((Control)Combo_Strike_MinimumContactStanceToTrigger).Name = "Combo_Strike_MinimumContactStanceToTrigger";
		((Control)Combo_Strike_MinimumContactStanceToTrigger).Size = new Size(183, 21);
		((Control)Combo_Strike_MinimumContactStanceToTrigger).TabIndex = 10;
		Label7.AutoSize = true;
		((Control)Label7).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label7).Location = new Point(28, 96);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(198, 15);
		((Control)Label7).TabIndex = 9;
		((Label)Label7).Text = "Contact is targeted when minimum:";
		Label2.AutoSize = true;
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(28, 26);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(150, 15);
		((Control)Label2).TabIndex = 11;
		((Label)Label2).Text = "Preliminary target location:";
		TextBox1.AutoCompleteCustomSource = null;
		TextBox1.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox1.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox1).BackColor = Color.Transparent;
		((Control)TextBox1).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox1.Image = null;
		TextBox1.Lines = null;
		((Control)TextBox1).Location = new Point(321, 20);
		TextBox1.MaxLength = 32767;
		TextBox1.Multiline = false;
		((Control)TextBox1).Name = "TextBox1";
		TextBox1.ReadOnly = false;
		TextBox1.ScrollBars = (ScrollBars)0;
		TextBox1.SelectionStart = 0;
		((Control)TextBox1).Size = new Size(183, 21);
		((Control)TextBox1).TabIndex = 12;
		TextBox1.TextAlign = (HorizontalAlignment)0;
		TextBox1.UseSystemPasswordChar = false;
		TextBox1.WatermarkText = "";
		((Control)Button1).Location = new Point(527, 15);
		((Control)Button1).Name = "Button1";
		((Control)Button1).Padding = new Padding(5);
		((Control)Button1).Size = new Size(140, 26);
		((Control)Button1).TabIndex = 13;
		Button1.Text = "Get point from map";
		((Control)UnitFilter_UnitDestroyed).BackColor = Color.FromArgb(60, 63, 65);
		UnitFilter_UnitDestroyed.FilterObject = null;
		((Control)UnitFilter_UnitDestroyed).Location = new Point(9, 144);
		((Control)UnitFilter_UnitDestroyed).MinimumSize = new Size(311, 177);
		((Control)UnitFilter_UnitDestroyed).Name = "UnitFilter_UnitDestroyed";
		((Control)UnitFilter_UnitDestroyed).Size = new Size(413, 211);
		((Control)UnitFilter_UnitDestroyed).TabIndex = 14;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(7f, 15f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(685, 348);
		((Control)this).Controls.Add((Control)(object)UnitFilter_UnitDestroyed);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Control)this).Controls.Add((Control)(object)TextBox1);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)Combo_Strike_MinimumContactStanceToTrigger);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)ComboBox1);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "FlightPlanEditorTargetsPreliminary";
		((Form)this).ShowIcon = false;
		((Form)this).Text = "FlightPlanEditorTargetsPreliminary";
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	static FlightPlanEditorTargetsPreliminary()
	{
		Class72.smethod_20();
	}
}
