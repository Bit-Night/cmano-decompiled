using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class AreaEditor : DarkUserControl, GInterface0
{
	private IContainer icontainer_1;

	[AccessedThroughProperty("Button_AddHighlighted")]
	[CompilerGenerated]
	private DarkUIButton _Button_AddHighlighted;

	[AccessedThroughProperty("Button_ListUp")]
	[CompilerGenerated]
	private DarkButton MviHvqtdiYP;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ListDown")]
	private DarkButton _Button_ListDown;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_RemoveSelected")]
	private DarkUIButton _Button_RemoveSelected;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_HighLightCenterOnSelected")]
	private DarkUIButton _Button_HighLightCenterOnSelected;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ValidateArea")]
	private DarkUIButton _Button_ValidateArea;

	[AccessedThroughProperty("ButtonPickArea")]
	[CompilerGenerated]
	private DarkUIButton _ButtonPickArea;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_CreateArea")]
	private DarkUIButton _Button_CreateArea;

	public List<ReferencePoint> AreaPoints;

	private string string_0;

	[field: AccessedThroughProperty("GroupBox1")]
	internal virtual DarkGroupBox GroupBox1 { get; set; }

	[field: AccessedThroughProperty("ListBox1")]
	internal virtual DarkListView ListBox1 { get; set; }

	internal virtual DarkUIButton Button_AddHighlighted
	{
		[CompilerGenerated]
		get
		{
			return _Button_AddHighlighted;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			DarkUIButton darkUIButton = _Button_AddHighlighted;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_AddHighlighted = value;
			darkUIButton = _Button_AddHighlighted;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkButton Button_ListUp
	{
		[CompilerGenerated]
		get
		{
			return MviHvqtdiYP;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_4;
			DarkButton darkButton = MviHvqtdiYP;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			MviHvqtdiYP = value;
			darkButton = MviHvqtdiYP;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkButton Button_ListDown
	{
		[CompilerGenerated]
		get
		{
			return _Button_ListDown;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_5;
			DarkButton darkButton = _Button_ListDown;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button_ListDown = value;
			darkButton = _Button_ListDown;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_RemoveSelected
	{
		[CompilerGenerated]
		get
		{
			return _Button_RemoveSelected;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			DarkUIButton darkUIButton = _Button_RemoveSelected;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_RemoveSelected = value;
			darkUIButton = _Button_RemoveSelected;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_HighLightCenterOnSelected
	{
		[CompilerGenerated]
		get
		{
			return _Button_HighLightCenterOnSelected;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_6;
			DarkUIButton darkUIButton = _Button_HighLightCenterOnSelected;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_HighLightCenterOnSelected = value;
			darkUIButton = _Button_HighLightCenterOnSelected;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_ValidateArea
	{
		[CompilerGenerated]
		get
		{
			return _Button_ValidateArea;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_7;
			DarkUIButton darkUIButton = _Button_ValidateArea;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_ValidateArea = value;
			darkUIButton = _Button_ValidateArea;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton ButtonPickArea
	{
		[CompilerGenerated]
		get
		{
			return _ButtonPickArea;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_9;
			DarkUIButton darkUIButton = _ButtonPickArea;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonPickArea = value;
			darkUIButton = _ButtonPickArea;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkGroupBox2")]
	internal virtual DarkGroupBox DarkGroupBox2 { get; set; }

	internal virtual DarkUIButton Button_CreateArea
	{
		[CompilerGenerated]
		get
		{
			return _Button_CreateArea;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_8;
			DarkUIButton darkUIButton = _Button_CreateArea;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_CreateArea = value;
			darkUIButton = _Button_CreateArea;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	public string Title
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
			((GroupBox)GroupBox1).Text = value;
		}
	}

	public AreaEditor()
	{
		((UserControl)this).Load += AbrHvaQmri7;
		InitializeComponent();
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

	private void InitializeComponent()
	{
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b7: Expected O, but got Unknown
		//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Expected O, but got Unknown
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Expected O, but got Unknown
		//IL_031a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0371: Unknown result type (might be due to invalid IL or missing references)
		//IL_037b: Expected O, but got Unknown
		//IL_038b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0395: Expected O, but got Unknown
		//IL_03a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b0: Expected O, but got Unknown
		//IL_03de: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d0: Expected O, but got Unknown
		//IL_0572: Unknown result type (might be due to invalid IL or missing references)
		//IL_057c: Expected O, but got Unknown
		//IL_061e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0628: Expected O, but got Unknown
		//IL_0666: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f6: Expected O, but got Unknown
		//IL_0734: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c4: Expected O, but got Unknown
		//IL_0802: Unknown result type (might be due to invalid IL or missing references)
		//IL_0888: Unknown result type (might be due to invalid IL or missing references)
		//IL_0892: Expected O, but got Unknown
		//IL_08d0: Unknown result type (might be due to invalid IL or missing references)
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(AreaEditor));
		GroupBox1 = new DarkGroupBox();
		DarkGroupBox2 = new DarkGroupBox();
		Button_ListDown = new DarkButton();
		Button_ListUp = new DarkButton();
		ListBox1 = new DarkListView();
		Button_CreateArea = new DarkUIButton();
		ButtonPickArea = new DarkUIButton();
		Button_ValidateArea = new DarkUIButton();
		Button_HighLightCenterOnSelected = new DarkUIButton();
		Button_RemoveSelected = new DarkUIButton();
		Button_AddHighlighted = new DarkUIButton();
		((Control)GroupBox1).SuspendLayout();
		((Control)DarkGroupBox2).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)GroupBox1).Controls.Add((Control)(object)DarkGroupBox2);
		((Control)GroupBox1).Controls.Add((Control)(object)Button_ValidateArea);
		((Control)GroupBox1).Controls.Add((Control)(object)Button_HighLightCenterOnSelected);
		((Control)GroupBox1).Controls.Add((Control)(object)Button_RemoveSelected);
		((Control)GroupBox1).Controls.Add((Control)(object)Button_ListDown);
		((Control)GroupBox1).Controls.Add((Control)(object)Button_ListUp);
		((Control)GroupBox1).Controls.Add((Control)(object)Button_AddHighlighted);
		((Control)GroupBox1).Controls.Add((Control)(object)ListBox1);
		((Control)GroupBox1).Dock = (DockStyle)5;
		((Control)GroupBox1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroupBox1).Location = new Point(0, 0);
		((Control)GroupBox1).Name = "GroupBox1";
		((Control)GroupBox1).Size = new Size(351, 124);
		((Control)GroupBox1).TabIndex = 0;
		((GroupBox)GroupBox1).TabStop = false;
		((GroupBox)GroupBox1).Text = "Title";
		((Control)DarkGroupBox2).Controls.Add((Control)(object)Button_CreateArea);
		((Control)DarkGroupBox2).Controls.Add((Control)(object)ButtonPickArea);
		((Control)DarkGroupBox2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkGroupBox2).Location = new Point(6, 13);
		((Control)DarkGroupBox2).Name = "DarkGroupBox2";
		((Control)DarkGroupBox2).Size = new Size(115, 105);
		((Control)DarkGroupBox2).TabIndex = 9;
		((GroupBox)DarkGroupBox2).TabStop = false;
		((GroupBox)DarkGroupBox2).Text = "Area / RP manager";
		((ButtonBase)Button_ListDown).BackColor = Color.Transparent;
		((Control)Button_ListDown).BackgroundImage = (Image)componentResourceManager.GetObject("Button_ListDown.BackgroundImage");
		((Control)Button_ListDown).Font = new Font("Segoe UI", 10f);
		((ButtonBase)Button_ListDown).Image = (Image)componentResourceManager.GetObject("Button_ListDown.Image");
		((Control)Button_ListDown).Location = new Point(222, 63);
		((Control)Button_ListDown).Name = "Button_ListDown";
		((Control)Button_ListDown).Padding = new Padding(5);
		((Control)Button_ListDown).Size = new Size(15, 24);
		((Control)Button_ListDown).TabIndex = 3;
		((Control)Button_ListDown).Anchor = (AnchorStyles)8;
		((ButtonBase)Button_ListUp).BackColor = Color.Transparent;
		((Control)Button_ListUp).BackgroundImage = (Image)componentResourceManager.GetObject("Button_ListUp.BackgroundImage");
		((Control)Button_ListUp).Font = new Font("Segoe UI", 10f);
		((ButtonBase)Button_ListUp).Image = (Image)componentResourceManager.GetObject("Button_ListUp.Image");
		((Control)Button_ListUp).Location = new Point(222, 33);
		((Control)Button_ListUp).Name = "Button_ListUp";
		((Control)Button_ListUp).Padding = new Padding(5);
		((Control)Button_ListUp).Size = new Size(15, 24);
		((Control)Button_ListUp).TabIndex = 2;
		((Control)Button_ListUp).Anchor = (AnchorStyles)8;
		((Control)ListBox1).BackColor = Color.FromArgb(70, 73, 75);
		((Control)ListBox1).Location = new Point(127, 11);
		ListBox1.MultiSelect = true;
		((Control)ListBox1).Name = "ListBox1";
		ListBox1.RelatedInfos = null;
		((Control)ListBox1).Size = new Size(90, 105);
		((Control)ListBox1).TabIndex = 0;
		((Control)ListBox1).Anchor = (AnchorStyles)15;
		((ButtonBase)Button_CreateArea).BackColor = Color.Transparent;
		((Button)Button_CreateArea).DialogResult = (DialogResult)0;
		((Control)Button_CreateArea).Font = new Font("Segoe UI", 8f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button_CreateArea).ForeColor = SystemColors.Control;
		((Control)Button_CreateArea).Location = new Point(3, 70);
		((Control)Button_CreateArea).Name = "Button_CreateArea";
		Button_CreateArea.RoundRadius = 0;
		((Control)Button_CreateArea).Size = new Size(106, 29);
		((Control)Button_CreateArea).TabIndex = 8;
		Button_CreateArea.Text = "Create area";
		((ButtonBase)ButtonPickArea).BackColor = Color.Transparent;
		((Button)ButtonPickArea).DialogResult = (DialogResult)0;
		((Control)ButtonPickArea).Font = new Font("Segoe UI", 8f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)ButtonPickArea).ForeColor = SystemColors.Control;
		((Control)ButtonPickArea).Location = new Point(3, 19);
		((Control)ButtonPickArea).Name = "ButtonPickArea";
		ButtonPickArea.RoundRadius = 0;
		((Control)ButtonPickArea).Size = new Size(106, 45);
		((Control)ButtonPickArea).TabIndex = 7;
		ButtonPickArea.Text = "Pick area";
		((ButtonBase)Button_ValidateArea).BackColor = Color.Transparent;
		((Button)Button_ValidateArea).DialogResult = (DialogResult)0;
		((Control)Button_ValidateArea).Font = new Font("Segoe UI", 8f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button_ValidateArea).ForeColor = SystemColors.Control;
		((Control)Button_ValidateArea).Location = new Point(241, 102);
		((Control)Button_ValidateArea).Name = "Button_ValidateArea";
		((Control)Button_ValidateArea).Padding = new Padding(1);
		Button_ValidateArea.RoundRadius = 0;
		((Control)Button_ValidateArea).Size = new Size(107, 18);
		((Control)Button_ValidateArea).TabIndex = 6;
		Button_ValidateArea.Text = "Validate Area";
		((Control)Button_ValidateArea).Anchor = (AnchorStyles)9;
		((ButtonBase)Button_HighLightCenterOnSelected).BackColor = Color.Transparent;
		((Button)Button_HighLightCenterOnSelected).DialogResult = (DialogResult)0;
		((Control)Button_HighLightCenterOnSelected).Font = new Font("Segoe UI", 8f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button_HighLightCenterOnSelected).ForeColor = SystemColors.Control;
		((Control)Button_HighLightCenterOnSelected).Location = new Point(241, 56);
		((Control)Button_HighLightCenterOnSelected).Name = "Button_HighLightCenterOnSelected";
		((Control)Button_HighLightCenterOnSelected).Padding = new Padding(1);
		Button_HighLightCenterOnSelected.RoundRadius = 0;
		((Control)Button_HighLightCenterOnSelected).Size = new Size(107, 28);
		((Control)Button_HighLightCenterOnSelected).TabIndex = 5;
		Button_HighLightCenterOnSelected.Text = "Highlight + center";
		((Control)Button_HighLightCenterOnSelected).Anchor = (AnchorStyles)9;
		((ButtonBase)Button_RemoveSelected).BackColor = Color.Transparent;
		((Button)Button_RemoveSelected).DialogResult = (DialogResult)0;
		((Control)Button_RemoveSelected).Font = new Font("Segoe UI", 8f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button_RemoveSelected).ForeColor = SystemColors.Control;
		((Control)Button_RemoveSelected).Location = new Point(241, 85);
		((Control)Button_RemoveSelected).Name = "Button_RemoveSelected";
		((Control)Button_RemoveSelected).Padding = new Padding(1);
		Button_RemoveSelected.RoundRadius = 0;
		((Control)Button_RemoveSelected).Size = new Size(107, 16);
		((Control)Button_RemoveSelected).TabIndex = 4;
		Button_RemoveSelected.Text = "Delete";
		((Control)Button_RemoveSelected).Anchor = (AnchorStyles)9;
		((ButtonBase)Button_AddHighlighted).BackColor = Color.Transparent;
		((Button)Button_AddHighlighted).DialogResult = (DialogResult)0;
		((Control)Button_AddHighlighted).Font = new Font("Segoe UI", 8f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Button_AddHighlighted).ForeColor = SystemColors.Control;
		((Control)Button_AddHighlighted).Location = new Point(241, 11);
		((Control)Button_AddHighlighted).Name = "Button_AddHighlighted";
		((Control)Button_AddHighlighted).Padding = new Padding(1);
		Button_AddHighlighted.RoundRadius = 0;
		((Control)Button_AddHighlighted).Size = new Size(107, 43);
		((Control)Button_AddHighlighted).TabIndex = 1;
		Button_AddHighlighted.Text = "Add points highlighted on map";
		((Control)Button_AddHighlighted).Anchor = (AnchorStyles)9;
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Control)this).Controls.Add((Control)(object)GroupBox1);
		((Control)this).Name = "AreaEditor";
		((Control)this).Size = new Size(351, 124);
		((Control)GroupBox1).ResumeLayout(false);
		((Control)DarkGroupBox2).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
	}

	public void ReleaseReferences()
	{
		try
		{
			AreaPoints = null;
			ListBox1.Items.Clear();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public void RefreshForm()
	{
		method_1();
	}

	private void method_1()
	{
		if (Information.IsNothing((object)AreaPoints))
		{
			return;
		}
		ListBox1.Items.Clear();
		foreach (ReferencePoint item in AreaPoints.ToList())
		{
			DarkListItem darkListItem = new DarkListItem(item.Name);
			darkListItem.Tag = item;
			ListBox1.Items.Add(darkListItem);
		}
	}

	private void method_2(object sender, EventArgs e)
	{
		bool isVisible = true;
		if (AreaPoints.Count > 0)
		{
			isVisible = AreaPoints[0].IsVisible;
		}
		foreach (ReferencePoint refPoint in Client.CurrentSide.RefPoints)
		{
			if (refPoint.IsHighlighted && !Information.IsNothing((object)AreaPoints) && !AreaPoints.Contains(refPoint))
			{
				DarkListItem darkListItem = new DarkListItem(refPoint.Name);
				refPoint.IsVisible = isVisible;
				AreaPoints.Add(refPoint);
				darkListItem.Tag = refPoint;
				ListBox1.Items.Add(darkListItem);
			}
		}
		Client.MustRefreshMainForm = true;
	}

	private void method_3(object sender, EventArgs e)
	{
		if (Information.IsNothing((object)AreaPoints))
		{
			return;
		}
		foreach (DarkListItem selectedItem in ListBox1.SelectedItems)
		{
			AreaPoints.Remove((ReferencePoint)selectedItem.Tag);
		}
		method_1();
		Client.MustRefreshMainForm = true;
	}

	private void method_4(object sender, EventArgs e)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		if (ListBox1.SelectedItems.Count > 1)
		{
			DarkMessageBox.ShowError("Only one reference point can be re-arranged at a time", "One point a time!");
		}
		else if (ListBox1.SelectedIndices.Count != 0)
		{
			int num = ListBox1.SelectedIndices[0];
			if (num != -1 && num > 0)
			{
				DarkListItem item = ListBox1.Items[num];
				ReferencePoint item2 = AreaPoints[num];
				ListBox1.Items.RemoveAt(num);
				AreaPoints.RemoveAt(num);
				num--;
				AreaPoints.Insert(num, item2);
				ListBox1.Items.Insert(num, item);
				ListBox1.SelectItem(num);
				Client.MustRefreshMainForm = true;
			}
		}
	}

	private void method_5(object sender, EventArgs e)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		if (ListBox1.SelectedItems.Count > 1)
		{
			DarkMessageBox.ShowError("Only one reference point can be re-arranged at a time", "One point a time!");
		}
		else if (ListBox1.SelectedIndices.Count != 0)
		{
			int num = ListBox1.SelectedIndices[0];
			if (num != -1 && num < ListBox1.Items.Count - 1)
			{
				DarkListItem item = ListBox1.Items[num];
				ReferencePoint item2 = AreaPoints[num];
				ListBox1.Items.RemoveAt(num);
				AreaPoints.RemoveAt(num);
				num++;
				AreaPoints.Insert(num, item2);
				ListBox1.Items.Insert(num, item);
				ListBox1.SelectItem(num);
				Client.MustRefreshMainForm = true;
			}
		}
	}

	private void method_6(object sender, EventArgs e)
	{
		List<ReferencePoint> list = new List<ReferencePoint>();
		if (Information.IsNothing((object)AreaPoints))
		{
			return;
		}
		foreach (DarkListItem selectedItem in ListBox1.SelectedItems)
		{
			list.Add((ReferencePoint)selectedItem.Tag);
		}
		switch (list.Count)
		{
		case 1:
			MyProject.Forms.MainForm.set_MapCenter(MustRender: true, (GeoPoint)list[0]);
			break;
		default:
		{
			GeoPoint value = Misc.Center(list).ToGeoPoint();
			MyProject.Forms.MainForm.set_MapCenter(MustRender: true, value);
			break;
		}
		case 0:
			return;
		}
		foreach (ReferencePoint item in list)
		{
			if (Client.Realtime)
			{
				Client.RealtimeTerminal.SetLocalReferencePointHighlightState(Client.CurrentSide, item, highLight: true);
			}
			else
			{
				item.IsHighlighted = true;
			}
		}
		Client.MustRefreshMainForm = true;
	}

	private void method_7(object sender, EventArgs e)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		if (!Information.IsNothing((object)AreaPoints))
		{
			string UserFeedback = default(string);
			if (!ActiveUnit_Navigator.ValidateArea(AreaPoints, ref UserFeedback, null, Client.CurrentScenario, ""))
			{
				DarkMessageBox.ShowWarning(UserFeedback, "");
			}
			else
			{
				DarkMessageBox.ShowInformation("Area validation OK.", "");
			}
		}
	}

	private void AbrHvaQmri7(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
	}

	private void method_8(object sender, EventArgs e)
	{
		((Control)MyProject.Forms.ReferencePointManager).Show();
	}

	private void method_9(object sender, EventArgs e)
	{
		List<Zone> SelectedStandardZones = new List<Zone>();
		if (!Information.IsNothing((object)AreaPoints))
		{
			List<ActiveUnit> SelectedUnits = null;
			List<ReferencePoint> list_ = null;
			UnitSelection.CallDialog(MultipleSelection: false, ref SelectedUnits, ref list_, ref SelectedStandardZones, UnitSelection.UnitSelectionConfig.DefaultZone());
			if (SelectedStandardZones != null && SelectedStandardZones.Count > 0)
			{
				AreaPoints.Clear();
				AreaPoints.AddRange(SelectedStandardZones.ElementAt(0).Area);
				method_1();
				Client.MustRefreshMainForm = true;
			}
		}
	}

	static AreaEditor()
	{
		Class72.smethod_20();
	}
}
