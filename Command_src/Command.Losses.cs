using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command_Core.DAL;
using Command.My;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class Losses : DarkSecondaryFormBase
{
	public enum DecoyRetrieval
	{
		All,
		DecoyOnly,
		NotDecoy
	}

	private IContainer icontainer_1;

	[AccessedThroughProperty("TSB_ResetAll")]
	[CompilerGenerated]
	private ToolStripButton _TSB_ResetAll;

	[AccessedThroughProperty("TSMI_ResetScore")]
	[CompilerGenerated]
	private ToolStripButton _TSMI_ResetScore;

	[CompilerGenerated]
	private bool bool_2;

	[field: AccessedThroughProperty("TextBox1")]
	internal virtual DarkUITextBox TextBox1 { get; set; }

	[field: AccessedThroughProperty("TS1")]
	internal virtual DarkToolStrip TS1 { get; set; }

	internal virtual ToolStripButton TSB_ResetAll
	{
		[CompilerGenerated]
		get
		{
			return _TSB_ResetAll;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			ToolStripButton val = _TSB_ResetAll;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_TSB_ResetAll = value;
			val = _TSB_ResetAll;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripButton TSMI_ResetScore
	{
		[CompilerGenerated]
		get
		{
			return _TSMI_ResetScore;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			ToolStripButton val = _TSMI_ResetScore;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_TSMI_ResetScore = value;
			val = _TSMI_ResetScore;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TSDD_Export")]
	internal virtual ToolStripDropDownButton TSDD_Export { get; set; }

	[field: AccessedThroughProperty("txtCSVSeparator")]
	internal virtual ToolStripTextBox txtCSVSeparator { get; set; }

	[field: AccessedThroughProperty("ExportDesignSeparator")]
	internal virtual ToolStripSeparator ExportDesignSeparator { get; set; }

	[field: AccessedThroughProperty("lblCSVSeparator")]
	internal virtual ToolStripLabel lblCSVSeparator { get; set; }

	[field: AccessedThroughProperty("DTSMI_XML")]
	internal virtual DarkToolStripMenuItem DTSMI_XML { get; set; }

	[field: AccessedThroughProperty("DTSMI_CSV")]
	internal virtual DarkToolStripMenuItem DTSMI_CSV { get; set; }

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

	public Losses()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).Load += Losses_Load;
		((Control)this).KeyDown += new KeyEventHandler(Losses_KeyDown);
		((Form)this).FormClosing += new FormClosingEventHandler(Losses_FormClosing);
		RTMPEnabled = true;
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
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_033e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0348: Expected O, but got Unknown
		//IL_03e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03eb: Expected O, but got Unknown
		//IL_0471: Unknown result type (might be due to invalid IL or missing references)
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Losses));
		TextBox1 = new DarkUITextBox();
		TS1 = new DarkToolStrip();
		TSB_ResetAll = new ToolStripButton();
		TSMI_ResetScore = new ToolStripButton();
		ExportDesignSeparator = new ToolStripSeparator();
		lblCSVSeparator = new ToolStripLabel();
		txtCSVSeparator = new ToolStripTextBox();
		TSDD_Export = new ToolStripDropDownButton();
		DTSMI_XML = new DarkToolStripMenuItem();
		DTSMI_CSV = new DarkToolStripMenuItem();
		((Control)TS1).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)TextBox1).Anchor = (AnchorStyles)15;
		TextBox1.AutoCompleteCustomSource = null;
		TextBox1.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox1.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox1).BackColor = Color.Transparent;
		TextBox1.Font = new Font("Segoe UI", 10f);
		((Control)TextBox1).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox1.Image = null;
		TextBox1.Lines = null;
		((Control)TextBox1).Location = new Point(0, 28);
		TextBox1.MaxLength = 32767;
		TextBox1.Multiline = true;
		((Control)TextBox1).Name = "TextBox1";
		TextBox1.ReadOnly = false;
		TextBox1.ScrollBars = (ScrollBars)2;
		TextBox1.SelectionStart = 0;
		((Control)TextBox1).Size = new Size(500, 316);
		((Control)TextBox1).TabIndex = 0;
		TextBox1.TextAlign = (HorizontalAlignment)0;
		TextBox1.UseSystemPasswordChar = false;
		TextBox1.WatermarkText = "";
		((ToolStrip)TS1).AutoSize = false;
		((ToolStrip)TS1).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStrip)TS1).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStrip)TS1).GripStyle = (ToolStripGripStyle)0;
		((ToolStrip)TS1).ImageScalingSize = new Size(24, 24);
		((ToolStrip)TS1).Items.AddRange((ToolStripItem[])(object)new ToolStripItem[6]
		{
			(ToolStripItem)TSB_ResetAll,
			(ToolStripItem)TSMI_ResetScore,
			(ToolStripItem)ExportDesignSeparator,
			(ToolStripItem)lblCSVSeparator,
			(ToolStripItem)txtCSVSeparator,
			(ToolStripItem)TSDD_Export
		});
		((Control)TS1).Location = new Point(0, 0);
		((Control)TS1).Name = "TS1";
		((Control)TS1).Padding = new Padding(5, 0, 1, 0);
		((Control)TS1).Size = new Size(500, 25);
		((Control)TS1).TabIndex = 1;
		((Control)TS1).Text = "ToolStrip1";
		((ToolStripItem)TSB_ResetAll).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_ResetAll).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)TSB_ResetAll).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_ResetAll).Image = (Image)componentResourceManager.GetObject("TSB_ResetAll.Image");
		((ToolStripItem)TSB_ResetAll).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_ResetAll).Name = "TSB_ResetAll";
		((ToolStripItem)TSB_ResetAll).Size = new Size(248, 20);
		((ToolStripItem)TSB_ResetAll).Text = "Reset All Losses/Expenditures";
		((ToolStripItem)TSMI_ResetScore).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSMI_ResetScore).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)TSMI_ResetScore).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSMI_ResetScore).Image = (Image)componentResourceManager.GetObject("TSMI_ResetScore.Image");
		((ToolStripItem)TSMI_ResetScore).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSMI_ResetScore).Name = "TSMI_ResetScore";
		((ToolStripItem)TSMI_ResetScore).Size = new Size(179, 20);
		((ToolStripItem)TSMI_ResetScore).Text = "Reset All Side Scores";
		((ToolStripItem)ExportDesignSeparator).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)ExportDesignSeparator).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)ExportDesignSeparator).Margin = new Padding(0, 0, 2, 0);
		((ToolStripItem)ExportDesignSeparator).Name = "ExportDesignSeparator";
		((ToolStripItem)ExportDesignSeparator).Size = new Size(6, 25);
		((ToolStripItem)lblCSVSeparator).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)lblCSVSeparator).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)lblCSVSeparator).Name = "lblCSVSeparator";
		((ToolStripItem)lblCSVSeparator).Size = new Size(126, 25);
		((ToolStripItem)lblCSVSeparator).Text = "CSV Separator";
		((ToolStripControlHost)txtCSVSeparator).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripControlHost)txtCSVSeparator).ForeColor = Color.FromArgb(220, 220, 220);
		txtCSVSeparator.MaxLength = 1;
		((ToolStripItem)txtCSVSeparator).Name = "txtCSVSeparator";
		((ToolStripControlHost)txtCSVSeparator).Size = new Size(25, 31);
		((ToolStripControlHost)txtCSVSeparator).Text = ",";
		((ToolStripItem)TSDD_Export).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripDropDownItem)TSDD_Export).DropDownItems.AddRange((ToolStripItem[])(object)new ToolStripItem[2]
		{
			(ToolStripItem)DTSMI_XML,
			(ToolStripItem)DTSMI_CSV
		});
		((ToolStripItem)TSDD_Export).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSDD_Export).Name = "TSDD_Export";
		((ToolStripItem)TSDD_Export).Size = new Size(81, 29);
		((ToolStripItem)TSDD_Export).Text = "Export";
		((ToolStripItem)DTSMI_XML).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)DTSMI_XML).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)DTSMI_XML).Name = "DTSMI_XML";
		((ToolStripItem)DTSMI_XML).Size = new Size(169, 34);
		((ToolStripItem)DTSMI_XML).Text = "To Xml";
		((ToolStripItem)DTSMI_CSV).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)DTSMI_CSV).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)DTSMI_CSV).Name = "DTSMI_CSV";
		((ToolStripItem)DTSMI_CSV).Size = new Size(169, 34);
		((ToolStripItem)DTSMI_CSV).Text = "To CSV";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(500, 344);
		((Control)this).Controls.Add((Control)(object)TS1);
		((Control)this).Controls.Add((Control)(object)TextBox1);
		((Form)this).FormBorderStyle = (FormBorderStyle)6;
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "Losses";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Losses & Expenditures";
		((Control)TS1).ResumeLayout(false);
		((Control)TS1).PerformLayout();
		((Control)this).ResumeLayout(false);
	}

	public void ShowLossesFromString(string theLosses)
	{
		if (((Control)this).InvokeRequired)
		{
			((Control)this).BeginInvoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
			{
				TextBox1.Text = theLosses;
			}));
		}
		else
		{
			TextBox1.Text = theLosses;
		}
	}

	private void Losses_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		if (Client.CurrentGame.GameMode != Game._GameMode.MultiplayerScenEdit || Client.Realtime || Client.RealtimeAC)
		{
			((Control)TS1).Visible = Client.AllowGodModeActions;
			TextBox1.Text = "AS OF: " + Client.CurrentScenario.Time.ToString() + "\r\n\r\n" + GameGeneral.GetAllSideLosses_AsString(Client.CurrentScenario);
		}
		if (Client.Realtime && Client.RealtimeTerminal.LastGameSpeed > 0)
		{
			Client.RealtimeTerminal.SendLossesUpdateRequest();
		}
		((ToolStripItem)TSDD_Export).Visible = false;
		((ToolStripItem)TSDD_Export).Enabled = false;
		((ToolStripItem)DTSMI_XML).Visible = false;
		((ToolStripMenuItem)DTSMI_XML).Enabled = false;
		((ToolStripItem)DTSMI_CSV).Visible = false;
		((ToolStripMenuItem)DTSMI_CSV).Enabled = false;
		((ToolStripItem)txtCSVSeparator).Visible = false;
		((ToolStripControlHost)txtCSVSeparator).Enabled = false;
		((ToolStripItem)lblCSVSeparator).Visible = false;
		((ToolStripItem)lblCSVSeparator).Enabled = false;
		((ToolStripItem)ExportDesignSeparator).Visible = false;
		ExportDesignSeparator.Enabled = false;
	}

	private static string smethod_0(Scenario scenario_0, KeyValuePair<string, HashSet<string>> keyValuePair_0, DecoyRetrieval decoyRetrieval_0)
	{
		string[] array = keyValuePair_0.Key.ToString().Split(new char[1] { '_' });
		string text = "";
		string text2 = "";
		bool flag = false;
		if (Conversions.ToDouble(array[1]) < 0.0)
		{
			array[1] = (Conversions.ToInteger(array[1]) * -1).ToString();
			flag = true;
			if ((((decoyRetrieval_0 == DecoyRetrieval.NotDecoy) ? 1u : 0u) & 1u) != 0)
			{
				goto IL_026c;
			}
			text2 = "[DECOY] ";
		}
		if (!(!flag && decoyRetrieval_0 == DecoyRetrieval.DecoyOnly))
		{
			string text3 = array[0].ToString();
			if (Operators.CompareString(text3, "Aircraft", true) != 0)
			{
				if (Operators.CompareString(text3, "Ship", true) == 0)
				{
					text = Misc.RemoveHiddenString(scenario_0.Cache_Ships_DT.Select("ID=" + array[1])[0]["Name"].ToString());
				}
				else if (Operators.CompareString(text3, "Submarine", true) != 0)
				{
					if (Operators.CompareString(text3, "Facility", true) != 0)
					{
						if (Operators.CompareString(text3, "Weapon", true) != 0)
						{
							if (Operators.CompareString(text3, "GroundUnit", true) == 0)
							{
								text = Misc.RemoveHiddenString(scenario_0.Cache_GroundUnits_DT.Select("ID=" + array[1])[0]["Name"].ToString());
							}
							else if (Operators.CompareString(text3, "FacilityAimpoint", true) == 0)
							{
								if (Operators.CompareString(array[1], "0", true) == 0)
								{
									text = "Non-identifiable land aimpoint - sorry!";
								}
								else
								{
									int int_ = Conversions.ToInteger(array[1]);
									Scenario theScen = Client.CurrentScenario;
									text = Misc.RemoveHiddenString(DBFunctions.GetMountName(int_, ref theScen));
								}
							}
						}
						else
						{
							text = Misc.RemoveHiddenString(scenario_0.Cache_Weapons_DT.Select("ID=" + array[1])[0]["Name"].ToString());
						}
					}
					else
					{
						text = Misc.RemoveHiddenString(scenario_0.Cache_Facilities_DT.Select("ID=" + array[1])[0]["Name"].ToString());
					}
				}
				else
				{
					text = Misc.RemoveHiddenString(scenario_0.Cache_Subs_DT.Select("ID=" + array[1])[0]["Name"].ToString());
				}
			}
			else
			{
				text = Misc.RemoveHiddenString(scenario_0.Cache_Aircraft_DT.Select("ID=" + array[1])[0]["Name"].ToString());
			}
			return text2 + text;
		}
		goto IL_026c;
		IL_026c:
		string result = default(string);
		return result;
	}

	private static string smethod_1(Scenario scenario_0, KeyValuePair<int, int> keyValuePair_0)
	{
		return Misc.RemoveHiddenString(scenario_0.Cache_Weapons_DT.Select("ID=" + Conversions.ToString(keyValuePair_0.Key))[0]["Name"].ToString());
	}

	private void method_2(object sender, EventArgs e)
	{
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		foreach (Side obj in sides_ReadOnly)
		{
			obj.AAR.Losses.Clear();
			obj.AAR.Expenditures.Clear();
			obj.AAR.WeaponsLost.Clear();
		}
		TextBox1.Text = GameGeneral.GetAllSideLosses_AsString(Client.CurrentScenario);
		if (Client.Realtime)
		{
			Client.RealtimeTerminal.SendLossesUpdateRequest();
		}
	}

	private void Losses_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Invalid comparison between Unknown and I4
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Invalid comparison between Unknown and I4
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Invalid comparison between Unknown and I4
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Invalid comparison between Unknown and I4
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Invalid comparison between Unknown and I4
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Invalid comparison between Unknown and I4
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Invalid comparison between Unknown and I4
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Invalid comparison between Unknown and I4
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Invalid comparison between Unknown and I4
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
		else if (!((Control)this).Visible || ((int)e.KeyCode != 33 && (int)e.KeyCode != 34 && (int)e.KeyCode != 35 && (int)e.KeyCode != 36 && ((int)e.KeyCode != 67 || (int)e.Modifiers != 131072) && ((int)e.KeyCode != 88 || (int)e.Modifiers != 131072) && ((int)e.KeyCode != 86 || (int)e.Modifiers != 131072)))
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void Losses_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void method_3(object sender, EventArgs e)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		foreach (Side obj in sides_ReadOnly)
		{
			obj.set_TotalScore(Client.CurrentScenario, (string)null, 0);
			obj.ScoringLog.Clear();
		}
		DarkMessageBox.ShowInformation("Score points for all sides have been reset to 0.", "");
	}

	static Losses()
	{
		Class72.smethod_20();
	}
}
