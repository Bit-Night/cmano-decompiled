using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;
using Steamworks;

namespace Command;

[DesignerGenerated]
public sealed class SteamUpdateScenarioForm : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton _Button1;

	[AccessedThroughProperty("Button2")]
	[CompilerGenerated]
	private DarkUIButton _Button2;

	public static SteamUpdateScenarioForm CurrentForm;

	public static SteamWorkshop.SteamWorkshopScenario steam_scenario;

	internal virtual DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return _Button1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			DarkUIButton darkUIButton = _Button1;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button1 = value;
			darkUIButton = _Button1;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button2
	{
		[CompilerGenerated]
		get
		{
			return _Button2;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			DarkUIButton darkUIButton = _Button2;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button2 = value;
			darkUIButton = _Button2;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("ListView1")]
	internal virtual DarkListView ListView1 { get; set; }

	[field: AccessedThroughProperty("Panel_Loading")]
	internal virtual Panel Panel_Loading { get; set; }

	[field: AccessedThroughProperty("Label_Loading")]
	internal virtual DarkLabel Label_Loading { get; set; }

	public SteamUpdateScenarioForm()
	{
		((Form)this).Load += SteamUpdateScenarioForm_Load;
		((Form)this).Load += SteamUpdateScenarioForm_Load_1;
		((Form)this).Shown += SteamUpdateScenarioForm_Shown;
		((Form)this).Closed += SteamUpdateScenarioForm_Closed;
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
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Expected O, but got Unknown
		Button1 = new DarkUIButton();
		Button2 = new DarkUIButton();
		ListView1 = new DarkListView();
		Panel_Loading = new Panel();
		Label_Loading = new DarkLabel();
		((Control)Panel_Loading).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)Button1).Anchor = (AnchorStyles)6;
		((Control)Button1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button1).Location = new Point(6, 322);
		((Control)Button1).Name = "Button1";
		((Control)Button1).Padding = new Padding(5);
		Button1.RoundRadius = 0;
		((Control)Button1).Size = new Size(75, 23);
		((Control)Button1).TabIndex = 1;
		Button1.Text = "Update";
		((Control)Button2).Anchor = (AnchorStyles)10;
		((Control)Button2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button2).Location = new Point(359, 322);
		((Control)Button2).Name = "Button2";
		((Control)Button2).Padding = new Padding(5);
		Button2.RoundRadius = 0;
		((Control)Button2).Size = new Size(75, 23);
		((Control)Button2).TabIndex = 2;
		Button2.Text = "Cancel";
		((Control)ListView1).Anchor = (AnchorStyles)15;
		((Control)ListView1).Location = new Point(6, 5);
		((Control)ListView1).Name = "ListView1";
		ListView1.RelatedInfos = null;
		((Control)ListView1).Size = new Size(428, 311);
		((Control)ListView1).TabIndex = 3;
		((Control)Panel_Loading).Anchor = (AnchorStyles)15;
		((Control)Panel_Loading).Controls.Add((Control)(object)Label_Loading);
		((Control)Panel_Loading).Location = new Point(6, 5);
		((Control)Panel_Loading).Name = "Panel_Loading";
		((Control)Panel_Loading).Size = new Size(428, 340);
		((Control)Panel_Loading).TabIndex = 4;
		((Control)Label_Loading).Anchor = (AnchorStyles)15;
		Label_Loading.AutoSize = true;
		((Control)Label_Loading).Font = new Font("Segoe UI", 9f, (FontStyle)1);
		((Control)Label_Loading).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_Loading).Location = new Point(120, 161);
		((Control)Label_Loading).Name = "Label_Loading";
		((Control)Label_Loading).Size = new Size(199, 15);
		((Control)Label_Loading).TabIndex = 0;
		((Label)Label_Loading).Text = "Loading Steam workshop items . . .";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(437, 348);
		((Control)this).Controls.Add((Control)(object)Panel_Loading);
		((Control)this).Controls.Add((Control)(object)ListView1);
		((Control)this).Controls.Add((Control)(object)Button2);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "SteamUpdateScenarioForm";
		((Form)this).ShowIcon = false;
		((Form)this).Text = "Steam Workshop Update Selection";
		((Control)Panel_Loading).ResumeLayout(false);
		((Control)Panel_Loading).PerformLayout();
		((Control)this).ResumeLayout(false);
	}

	public void ReloadWorkshopItems()
	{
		((Control)Panel_Loading).Visible = false;
		ListView1.Items.Clear();
		SteamUGCDetails_t[] array = SteamWorkshop.UserScens.ToArray();
		for (int i = 0; i < array.Length; i = checked(i + 1))
		{
			SteamUGCDetails_t steamUGCDetails_t = array[i];
			try
			{
				ListView1.Items.Add(new DarkListItem(steamUGCDetails_t.m_rgchTitle)
				{
					Tag = steamUGCDetails_t
				});
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				GameGeneral.WriteExceptionsToLog(ex2);
				ProjectData.ClearProjectError();
			}
		}
	}

	private void SteamUpdateScenarioForm_Load(object sender, EventArgs e)
	{
		CurrentForm = this;
		((Control)Panel_Loading).Visible = true;
		SteamWorkshop.QueryUserUGC();
	}

	private void method_2(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void method_3(object sender, EventArgs e)
	{
		if (ListView1.SelectedItems.Count == 1)
		{
			object tag = ListView1.SelectedItems[0].Tag;
			SteamUGCDetails_t existing = ((tag == null) ? default(SteamUGCDetails_t) : ((SteamUGCDetails_t)tag));
			SteamWorkshop.Update(steam_scenario, existing);
		}
	}

	private void SteamUpdateScenarioForm_Load_1(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
	}

	private void SteamUpdateScenarioForm_Shown(object sender, EventArgs e)
	{
		if (!MyProject.Forms.MainForm.Timer_SteamWorkshop.Enabled)
		{
			MyProject.Forms.MainForm.Timer_SteamWorkshop.Start();
		}
	}

	private void SteamUpdateScenarioForm_Closed(object sender, EventArgs e)
	{
		if (MyProject.Forms.m_SteamPublishScenarioForm == null || !((Control)MyProject.Forms.SteamPublishScenarioForm).Visible)
		{
			MyProject.Forms.MainForm.Timer_SteamWorkshop.Stop();
		}
	}

	static SteamUpdateScenarioForm()
	{
		Class72.smethod_20();
	}
}
