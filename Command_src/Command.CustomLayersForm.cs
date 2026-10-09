using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.My;
using DarkUI.Controls;
using DXRenderer;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class CustomLayersForm : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolStripButton1")]
	private ToolStripButton _ToolStripButton1;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_DisplayHide")]
	private ToolStripButton _TSB_DisplayHide;

	[CompilerGenerated]
	[AccessedThroughProperty("MoveUp")]
	private ToolStripButton _MoveUp;

	[CompilerGenerated]
	[AccessedThroughProperty("MoveDown")]
	private ToolStripButton _MoveDown;

	[CompilerGenerated]
	[AccessedThroughProperty("RemoveSelected")]
	private ToolStripButton _RemoveSelected;

	[CompilerGenerated]
	private bool bool_2;

	[field: AccessedThroughProperty("ToolStrip1")]
	internal virtual DarkToolStrip ToolStrip1 { get; set; }

	internal virtual ToolStripButton ToolStripButton1
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripButton1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			ToolStripButton val = _ToolStripButton1;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_ToolStripButton1 = value;
			val = _ToolStripButton1;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripButton TSB_DisplayHide
	{
		[CompilerGenerated]
		get
		{
			return _TSB_DisplayHide;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_4;
			ToolStripButton val = _TSB_DisplayHide;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_TSB_DisplayHide = value;
			val = _TSB_DisplayHide;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("ListBox1")]
	internal virtual DarkListView ListBox1 { get; set; }

	internal virtual ToolStripButton MoveUp
	{
		[CompilerGenerated]
		get
		{
			return _MoveUp;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_5;
			ToolStripButton val = _MoveUp;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_MoveUp = value;
			val = _MoveUp;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripButton MoveDown
	{
		[CompilerGenerated]
		get
		{
			return _MoveDown;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_6;
			ToolStripButton val = _MoveDown;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_MoveDown = value;
			val = _MoveDown;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripButton RemoveSelected
	{
		[CompilerGenerated]
		get
		{
			return _RemoveSelected;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			ToolStripButton val = _RemoveSelected;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_RemoveSelected = value;
			val = _RemoveSelected;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

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

	public CustomLayersForm()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).Shown += CustomLayersForm_Shown;
		((Control)this).KeyDown += new KeyEventHandler(CustomLayersForm_KeyDown);
		((Form)this).FormClosing += new FormClosingEventHandler(CustomLayersForm_FormClosing);
		((Form)this).Load += CustomLayersForm_Load;
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
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		//IL_0241: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Expected O, but got Unknown
		//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Expected O, but got Unknown
		//IL_0369: Unknown result type (might be due to invalid IL or missing references)
		//IL_0373: Expected O, but got Unknown
		//IL_03fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0407: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(CustomLayersForm));
		ToolStrip1 = new DarkToolStrip();
		ToolStripButton1 = new ToolStripButton();
		RemoveSelected = new ToolStripButton();
		TSB_DisplayHide = new ToolStripButton();
		MoveUp = new ToolStripButton();
		MoveDown = new ToolStripButton();
		ListBox1 = new DarkListView();
		((Control)ToolStrip1).SuspendLayout();
		((Control)this).SuspendLayout();
		((ToolStrip)ToolStrip1).AutoSize = false;
		((ToolStrip)ToolStrip1).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStrip)ToolStrip1).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStrip)ToolStrip1).GripStyle = (ToolStripGripStyle)0;
		((ToolStrip)ToolStrip1).Items.AddRange((ToolStripItem[])(object)new ToolStripItem[5]
		{
			(ToolStripItem)ToolStripButton1,
			(ToolStripItem)RemoveSelected,
			(ToolStripItem)TSB_DisplayHide,
			(ToolStripItem)MoveUp,
			(ToolStripItem)MoveDown
		});
		((Control)ToolStrip1).Location = new Point(0, 0);
		((Control)ToolStrip1).Name = "ToolStrip1";
		((Control)ToolStrip1).Padding = new Padding(5, 0, 1, 0);
		((Control)ToolStrip1).Size = new Size(560, 25);
		((Control)ToolStrip1).TabIndex = 0;
		((Control)ToolStrip1).Text = "ToolStrip1";
		((ToolStripItem)ToolStripButton1).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)ToolStripButton1).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)ToolStripButton1).Image = (Image)componentResourceManager.GetObject("ToolStripButton1.Image");
		((ToolStripItem)ToolStripButton1).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)ToolStripButton1).Name = "ToolStripButton1";
		((ToolStripItem)ToolStripButton1).Size = new Size(80, 22);
		((ToolStripItem)ToolStripButton1).Text = "Add Layer";
		((ToolStripItem)RemoveSelected).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)RemoveSelected).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)RemoveSelected).Image = (Image)componentResourceManager.GetObject("RemoveSelected.Image");
		((ToolStripItem)RemoveSelected).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)RemoveSelected).Name = "RemoveSelected";
		((ToolStripItem)RemoveSelected).Size = new Size(117, 22);
		((ToolStripItem)RemoveSelected).Text = "Remove Selected";
		((ToolStripItem)TSB_DisplayHide).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_DisplayHide).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_DisplayHide).Image = (Image)componentResourceManager.GetObject("TSB_DisplayHide.Image");
		((ToolStripItem)TSB_DisplayHide).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_DisplayHide).Name = "TSB_DisplayHide";
		((ToolStripItem)TSB_DisplayHide).Size = new Size(95, 22);
		((ToolStripItem)TSB_DisplayHide).Text = "Display/Hide";
		((ToolStripItem)MoveUp).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)MoveUp).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)MoveUp).Image = (Image)componentResourceManager.GetObject("MoveUp.Image");
		((ToolStripItem)MoveUp).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)MoveUp).Name = "MoveUp";
		((ToolStripItem)MoveUp).Size = new Size(74, 22);
		((ToolStripItem)MoveUp).Text = "Move up";
		((ToolStripItem)MoveDown).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)MoveDown).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)MoveDown).Image = (Image)componentResourceManager.GetObject("MoveDown.Image");
		((ToolStripItem)MoveDown).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)MoveDown).Name = "MoveDown";
		((ToolStripItem)MoveDown).Size = new Size(91, 22);
		((ToolStripItem)MoveDown).Text = "Move Down";
		((Control)ListBox1).Dock = (DockStyle)5;
		((Control)ListBox1).Location = new Point(0, 25);
		((Control)ListBox1).Name = "ListBox1";
		ListBox1.RelatedInfos = null;
		((Control)ListBox1).Size = new Size(560, 331);
		((Control)ListBox1).TabIndex = 1;
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(560, 356);
		((Control)this).Controls.Add((Control)(object)ListBox1);
		((Control)this).Controls.Add((Control)(object)ToolStrip1);
		((Form)this).FormBorderStyle = (FormBorderStyle)6;
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "CustomLayersForm";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Custom Layer Manager";
		((Control)ToolStrip1).ResumeLayout(false);
		((Control)ToolStrip1).PerformLayout();
		((Control)this).ResumeLayout(false);
	}

	public void RefreshCustomLayers()
	{
		Main instance = Main.Instance;
		_ = Client.CurrentMapProfile;
		ListBox1.Items.Clear();
		string[] array = Main.Instance.CustomOverlayNames();
		foreach (string text in array)
		{
			DarkListItem darkListItem = new DarkListItem(text);
			darkListItem.Tag = text;
			if (!instance.IsVisibleCustomOverlay(darkListItem.Tag.ToString()))
			{
				darkListItem.TextColor = Color.DarkGray;
			}
			else
			{
				darkListItem.TextColor = Color.White;
			}
			ListBox1.Items.Add(darkListItem);
		}
	}

	private void CustomLayersForm_Shown(object sender, EventArgs e)
	{
		RefreshCustomLayers();
	}

	private void method_2(object sender, EventArgs e)
	{
		Client.LoadCustomLayer_Dialog();
		RefreshCustomLayers();
	}

	private void method_3(object sender, EventArgs e)
	{
		Main instance = Main.Instance;
		_ = Client.CurrentMapProfile;
		foreach (DarkListItem selectedItem in ListBox1.SelectedItems)
		{
			instance?.RemoveCustomOverlay(selectedItem.Tag.ToString());
		}
		RefreshCustomLayers();
		MyProject.Forms.MainForm.MapRender_Geo();
	}

	private void method_4(object sender, EventArgs e)
	{
		Main instance = Main.Instance;
		_ = Client.CurrentMapProfile;
		foreach (DarkListItem selectedItem in ListBox1.SelectedItems)
		{
			instance.ToggleCustomOverlay(selectedItem.Tag.ToString());
		}
		RefreshCustomLayers();
		MyProject.Forms.MainForm.MapRender_Geo();
	}

	private void CustomLayersForm_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
		else
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void CustomLayersForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void CustomLayersForm_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
	}

	private void method_5(object sender, EventArgs e)
	{
		if (ListBox1.SelectedItems.Count != 0)
		{
			DarkListItem darkListItem = ListBox1.SelectedItems.ElementAt(0);
			Main instance = Main.Instance;
			_ = Client.CurrentMapProfile;
			instance?.MoveUpCustomOverlay(darkListItem.Tag.ToString());
			RefreshCustomLayers();
			MyProject.Forms.MainForm.MapRender_Geo();
		}
	}

	private void method_6(object sender, EventArgs e)
	{
		if (ListBox1.SelectedItems.Count != 0)
		{
			DarkListItem darkListItem = ListBox1.SelectedItems.ElementAt(0);
			Main instance = Main.Instance;
			_ = Client.CurrentMapProfile;
			instance?.MoveDownCustomOverlay(darkListItem.Tag.ToString());
			RefreshCustomLayers();
			MyProject.Forms.MainForm.MapRender_Geo();
		}
	}

	static CustomLayersForm()
	{
		Class72.smethod_20();
	}
}
