using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class InsufficientLicenseWindow : DarkForm
{
	private IContainer icontainer_0;

	private List<Licensing.ModuleLicense> list_0;

	private string string_0;

	[CompilerGenerated]
	[AccessedThroughProperty("theButton")]
	private Button button_0;

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	[field: AccessedThroughProperty("SplitContainer1")]
	internal virtual SplitContainer SplitContainer1 { get; set; }

	[field: AccessedThroughProperty("FlowLayoutPanel1")]
	internal virtual FlowLayoutPanel FlowLayoutPanel1 { get; set; }

	public List<Licensing.ModuleLicense> theNeededModules
	{
		get
		{
			return list_0;
		}
		set
		{
			list_0 = value;
		}
	}

	public InsufficientLicenseWindow()
	{
		((Form)this).Shown += InsufficientLicenseWindow_Shown;
		((Form)this).Load += InsufficientLicenseWindow_Load;
		((Form)this).Closing += InsufficientLicenseWindow_Closing;
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
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		Label1 = new DarkLabel();
		SplitContainer1 = new SplitContainer();
		FlowLayoutPanel1 = new FlowLayoutPanel();
		((ISupportInitialize)SplitContainer1).BeginInit();
		((Control)SplitContainer1.Panel1).SuspendLayout();
		((Control)SplitContainer1.Panel2).SuspendLayout();
		((Control)SplitContainer1).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Dock = (DockStyle)5;
		((Control)Label1).Font = new Font("Arial", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Label1).ForeColor = Color.White;
		((Control)Label1).Location = new Point(0, 0);
		((Control)Label1).MaximumSize = new Size(700, 0);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(374, 85);
		((Control)Label1).TabIndex = 3;
		((Label)Label1).Text = "To perform the requested action you need a license for the product below. Click on the product icon to obtain a license for it.";
		SplitContainer1.Dock = (DockStyle)5;
		SplitContainer1.FixedPanel = (FixedPanel)1;
		((Control)SplitContainer1).Location = new Point(0, 0);
		((Control)SplitContainer1).Name = "SplitContainer1";
		SplitContainer1.Orientation = (Orientation)0;
		((Control)SplitContainer1.Panel1).BackColor = Color.FromArgb(32, 32, 32);
		((Control)SplitContainer1.Panel1).Controls.Add((Control)(object)Label1);
		((Control)SplitContainer1.Panel2).Controls.Add((Control)(object)FlowLayoutPanel1);
		((Control)SplitContainer1).Size = new Size(374, 292);
		SplitContainer1.SplitterDistance = 85;
		((Control)SplitContainer1).TabIndex = 4;
		((ScrollableControl)FlowLayoutPanel1).AutoScroll = true;
		((Control)FlowLayoutPanel1).BackColor = SystemColors.ControlDark;
		((Control)FlowLayoutPanel1).Dock = (DockStyle)5;
		FlowLayoutPanel1.FlowDirection = (FlowDirection)1;
		((Control)FlowLayoutPanel1).Location = new Point(0, 0);
		((Control)FlowLayoutPanel1).Name = "FlowLayoutPanel1";
		((Control)FlowLayoutPanel1).Size = new Size(374, 203);
		((Control)FlowLayoutPanel1).TabIndex = 0;
		FlowLayoutPanel1.WrapContents = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Control)this).BackgroundImageLayout = (ImageLayout)2;
		((Form)this).ClientSize = new Size(374, 292);
		((Control)this).Controls.Add((Control)(object)SplitContainer1);
		((Form)this).FormBorderStyle = (FormBorderStyle)5;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "InsufficientLicenseWindow";
		((Form)this).ShowIcon = false;
		((Form)this).SizeGripStyle = (SizeGripStyle)2;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).TopMost = true;
		((Control)SplitContainer1.Panel1).ResumeLayout(false);
		((Control)SplitContainer1.Panel2).ResumeLayout(false);
		((ISupportInitialize)SplitContainer1).EndInit();
		((Control)SplitContainer1).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
	}

	[SpecialName]
	[CompilerGenerated]
	private virtual Button vmethod_0()
	{
		return button_0;
	}

	[SpecialName]
	[CompilerGenerated]
	private virtual void vmethod_1(Button WithEventsValue)
	{
		button_0 = WithEventsValue;
	}

	private void InsufficientLicenseWindow_Shown(object sender, EventArgs e)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		List<Licensing.ModuleLicenseRecord> selectedLicenseRecords = Licensing.GetSelectedLicenseRecords(theNeededModules);
		string text = "To perform the requested action you need a license for ";
		text = ((selectedLicenseRecords.Count != 1) ? (text + "any of the products below. Click on any of the product icons to obtain a license for it.") : (text + "the product below. Click on the product icon to obtain a license for it."));
		((Label)Label1).Text = text;
		int num = 0;
		foreach (Licensing.ModuleLicenseRecord item in selectedLicenseRecords)
		{
			vmethod_1(new Button());
			((Control)vmethod_0()).Height = 161;
			((Control)vmethod_0()).Width = 345;
			num += ((Control)vmethod_0()).Height + 30;
			try
			{
				Bitmap image = (Bitmap)Image.FromFile(Application.StartupPath + "\\Symbols\\Menu\\" + item.NoLicenseImage);
				image = Module1.ResizeImage(image, new Size(345, 161));
				((ButtonBase)vmethod_0()).Image = (Image)(object)image;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			string_0 = item.DestinationURL_MG;
			if (Client.RunningInSteamMode)
			{
				string_0 = "http://store.steampowered.com/app/" + Conversions.ToString(item.SteamID_CMO.m_AppId);
			}
			((Control)vmethod_0()).Tag = string_0;
			((Control)FlowLayoutPanel1).Controls.Add((Control)(object)vmethod_0());
			((Control)vmethod_0()).Click += method_0;
			((Control)vmethod_0()).MouseEnter += method_1;
			((Control)vmethod_0()).MouseLeave += method_2;
		}
		((Control)this).Height = SplitContainer1.Panel1.Height + num;
		if (((Control)this).Height < 300)
		{
			((Control)this).Height = 300;
		}
		Module1.ShowScrollBar(((Control)FlowLayoutPanel1).Handle, 1, bShow: true);
	}

	private void InsufficientLicenseWindow_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
	}

	private void method_0(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		Process.Start(Conversions.ToString(((Control)(Button)sender).Tag));
	}

	private void method_1(object sender, EventArgs e)
	{
		((Control)this).Cursor = Cursors.Hand;
	}

	private void method_2(object sender, EventArgs e)
	{
		((Control)this).Cursor = Cursors.Arrow;
	}

	private void InsufficientLicenseWindow_Closing(object sender, CancelEventArgs e)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		foreach (object control in ((Control)FlowLayoutPanel1).Controls)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(control);
			vmethod_1((Button)objectValue);
			((Control)vmethod_0()).Click -= method_0;
			((Control)vmethod_0()).MouseEnter -= method_1;
			((Control)vmethod_0()).MouseLeave -= method_2;
		}
	}

	static InsufficientLicenseWindow()
	{
		Class72.smethod_20();
	}
}
