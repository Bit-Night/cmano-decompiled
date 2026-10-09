using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class SplitUnit : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ToDestination")]
	private DarkUIButton _Button_ToDestination;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ToSource")]
	private DarkUIButton _Button_ToSource;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonRenameSource")]
	private DarkUIButton _ButtonRenameSource;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonSplit")]
	private DarkUIButton _ButtonSplit;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonBreakIntoIndividualUnits")]
	private DarkUIButton _ButtonBreakIntoIndividualUnits;

	public ActiveUnit SourceUnit;

	public Dictionary<Mount, Mount> TransferedMounts;

	[field: AccessedThroughProperty("LV_SourceUnit")]
	internal virtual DarkListView LV_SourceUnit { get; set; }

	[field: AccessedThroughProperty("LV_TargetUnit")]
	internal virtual DarkListView LV_TargetUnit { get; set; }

	internal virtual DarkUIButton Button_ToDestination
	{
		[CompilerGenerated]
		get
		{
			return _Button_ToDestination;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			DarkUIButton darkUIButton = _Button_ToDestination;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_ToDestination = value;
			darkUIButton = _Button_ToDestination;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_ToSource
	{
		[CompilerGenerated]
		get
		{
			return _Button_ToSource;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			DarkUIButton darkUIButton = _Button_ToSource;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_ToSource = value;
			darkUIButton = _Button_ToSource;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TB_RenameSource")]
	internal virtual DarkUITextBox TB_RenameSource { get; set; }

	internal virtual DarkUIButton ButtonRenameSource
	{
		[CompilerGenerated]
		get
		{
			return _ButtonRenameSource;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_4;
			DarkUIButton darkUIButton = _ButtonRenameSource;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonRenameSource = value;
			darkUIButton = _ButtonRenameSource;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TB_RenameDestination")]
	internal virtual DarkUITextBox TB_RenameDestination { get; set; }

	internal virtual DarkUIButton ButtonSplit
	{
		[CompilerGenerated]
		get
		{
			return _ButtonSplit;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_6;
			DarkUIButton darkUIButton = _ButtonSplit;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonSplit = value;
			darkUIButton = _ButtonSplit;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton ButtonBreakIntoIndividualUnits
	{
		[CompilerGenerated]
		get
		{
			return _ButtonBreakIntoIndividualUnits;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_7;
			DarkUIButton darkUIButton = _ButtonBreakIntoIndividualUnits;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonBreakIntoIndividualUnits = value;
			darkUIButton = _ButtonBreakIntoIndividualUnits;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	public SplitUnit()
	{
		((Form)this).Load += SplitUnit_Load;
		TransferedMounts = new Dictionary<Mount, Mount>();
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
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_03af: Unknown result type (might be due to invalid IL or missing references)
		//IL_0492: Unknown result type (might be due to invalid IL or missing references)
		//IL_0594: Unknown result type (might be due to invalid IL or missing references)
		//IL_063a: Unknown result type (might be due to invalid IL or missing references)
		//IL_06dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0817: Unknown result type (might be due to invalid IL or missing references)
		LV_SourceUnit = new DarkListView();
		LV_TargetUnit = new DarkListView();
		ButtonSplit = new DarkUIButton();
		TB_RenameDestination = new DarkUITextBox();
		ButtonRenameSource = new DarkUIButton();
		TB_RenameSource = new DarkUITextBox();
		Button_ToSource = new DarkUIButton();
		Button_ToDestination = new DarkUIButton();
		ButtonBreakIntoIndividualUnits = new DarkUIButton();
		((Control)this).SuspendLayout();
		((Control)LV_SourceUnit).BackColor = Color.FromArgb(50, 53, 55);
		((Control)LV_SourceUnit).Location = new Point(14, 48);
		((Control)LV_SourceUnit).Margin = new Padding(3, 4, 3, 4);
		((Control)LV_SourceUnit).Name = "LV_SourceUnit";
		((Control)LV_SourceUnit).Size = new Size(259, 288);
		((Control)LV_SourceUnit).TabIndex = 0;
		((Control)LV_SourceUnit).Text = "LV_SourceUnit";
		((Control)LV_TargetUnit).BackColor = Color.FromArgb(50, 53, 55);
		((Control)LV_TargetUnit).Location = new Point(338, 48);
		((Control)LV_TargetUnit).Margin = new Padding(3, 4, 3, 4);
		((Control)LV_TargetUnit).Name = "LV_TargetUnit";
		((Control)LV_TargetUnit).Size = new Size(259, 288);
		((Control)LV_TargetUnit).TabIndex = 1;
		((Control)LV_TargetUnit).Text = "LV_TargetUnit";
		((ButtonBase)ButtonSplit).BackColor = Color.Transparent;
		((Button)ButtonSplit).DialogResult = (DialogResult)0;
		((Control)ButtonSplit).ForeColor = SystemColors.Control;
		((Control)ButtonSplit).Location = new Point(338, 342);
		((Control)ButtonSplit).Margin = new Padding(3, 4, 3, 4);
		((Control)ButtonSplit).Name = "ButtonSplit";
		ButtonSplit.RoundRadius = 0;
		((Control)ButtonSplit).Size = new Size(259, 40);
		((Control)ButtonSplit).TabIndex = 8;
		ButtonSplit.Text = "SPLIT";
		TB_RenameDestination.AutoCompleteCustomSource = null;
		TB_RenameDestination.AutoCompleteMode = (AutoCompleteMode)0;
		TB_RenameDestination.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TB_RenameDestination).BackColor = Color.Transparent;
		((Control)TB_RenameDestination).ForeColor = Color.FromArgb(189, 189, 189);
		TB_RenameDestination.Image = null;
		TB_RenameDestination.Lines = null;
		((Control)TB_RenameDestination).Location = new Point(338, 11);
		((Control)TB_RenameDestination).Margin = new Padding(3, 4, 3, 4);
		TB_RenameDestination.MaxLength = 32767;
		TB_RenameDestination.Multiline = false;
		((Control)TB_RenameDestination).Name = "TB_RenameDestination";
		TB_RenameDestination.ReadOnly = false;
		TB_RenameDestination.ScrollBars = (ScrollBars)0;
		TB_RenameDestination.SelectionStart = 0;
		((Control)TB_RenameDestination).Size = new Size(258, 26);
		((Control)TB_RenameDestination).TabIndex = 6;
		TB_RenameDestination.Text = "---";
		TB_RenameDestination.TextAlign = (HorizontalAlignment)0;
		TB_RenameDestination.UseSystemPasswordChar = false;
		TB_RenameDestination.WatermarkText = "";
		((ButtonBase)ButtonRenameSource).BackColor = Color.Transparent;
		((Button)ButtonRenameSource).DialogResult = (DialogResult)0;
		((Control)ButtonRenameSource).ForeColor = SystemColors.Control;
		((Control)ButtonRenameSource).Location = new Point(196, 11);
		((Control)ButtonRenameSource).Margin = new Padding(3, 4, 3, 4);
		((Control)ButtonRenameSource).Name = "ButtonRenameSource";
		ButtonRenameSource.RoundRadius = 0;
		((Control)ButtonRenameSource).Size = new Size(76, 29);
		((Control)ButtonRenameSource).TabIndex = 5;
		ButtonRenameSource.Text = "Rename";
		TB_RenameSource.AutoCompleteCustomSource = null;
		TB_RenameSource.AutoCompleteMode = (AutoCompleteMode)0;
		TB_RenameSource.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TB_RenameSource).BackColor = Color.Transparent;
		((Control)TB_RenameSource).ForeColor = Color.FromArgb(189, 189, 189);
		TB_RenameSource.Image = null;
		TB_RenameSource.Lines = null;
		((Control)TB_RenameSource).Location = new Point(14, 11);
		((Control)TB_RenameSource).Margin = new Padding(3, 4, 3, 4);
		TB_RenameSource.MaxLength = 32767;
		TB_RenameSource.Multiline = false;
		((Control)TB_RenameSource).Name = "TB_RenameSource";
		TB_RenameSource.ReadOnly = false;
		TB_RenameSource.ScrollBars = (ScrollBars)0;
		TB_RenameSource.SelectionStart = 0;
		((Control)TB_RenameSource).Size = new Size(176, 26);
		((Control)TB_RenameSource).TabIndex = 4;
		TB_RenameSource.Text = "---";
		TB_RenameSource.TextAlign = (HorizontalAlignment)0;
		TB_RenameSource.UseSystemPasswordChar = false;
		TB_RenameSource.WatermarkText = "";
		((ButtonBase)Button_ToSource).BackColor = Color.Transparent;
		((Button)Button_ToSource).DialogResult = (DialogResult)0;
		((Control)Button_ToSource).ForeColor = SystemColors.Control;
		((Control)Button_ToSource).Location = new Point(280, 94);
		((Control)Button_ToSource).Margin = new Padding(3, 4, 3, 4);
		((Control)Button_ToSource).Name = "Button_ToSource";
		Button_ToSource.RoundRadius = 0;
		((Control)Button_ToSource).Size = new Size(51, 85);
		((Control)Button_ToSource).TabIndex = 3;
		Button_ToSource.Text = "<";
		((ButtonBase)Button_ToDestination).BackColor = Color.Transparent;
		((Button)Button_ToDestination).DialogResult = (DialogResult)0;
		((Control)Button_ToDestination).ForeColor = SystemColors.Control;
		((Control)Button_ToDestination).Location = new Point(280, 186);
		((Control)Button_ToDestination).Margin = new Padding(3, 4, 3, 4);
		((Control)Button_ToDestination).Name = "Button_ToDestination";
		Button_ToDestination.RoundRadius = 0;
		((Control)Button_ToDestination).Size = new Size(51, 85);
		((Control)Button_ToDestination).TabIndex = 2;
		Button_ToDestination.Text = ">";
		((ButtonBase)ButtonBreakIntoIndividualUnits).BackColor = Color.Transparent;
		((Button)ButtonBreakIntoIndividualUnits).DialogResult = (DialogResult)0;
		((Control)ButtonBreakIntoIndividualUnits).ForeColor = SystemColors.Control;
		((Control)ButtonBreakIntoIndividualUnits).Location = new Point(14, 342);
		((Control)ButtonBreakIntoIndividualUnits).Margin = new Padding(3, 4, 3, 4);
		((Control)ButtonBreakIntoIndividualUnits).Name = "ButtonBreakIntoIndividualUnits";
		ButtonBreakIntoIndividualUnits.RoundRadius = 0;
		((Control)ButtonBreakIntoIndividualUnits).Size = new Size(259, 40);
		((Control)ButtonBreakIntoIndividualUnits).TabIndex = 9;
		ButtonBreakIntoIndividualUnits.Text = "Break into individual units";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(9f, 20f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).BackColor = Color.FromArgb(60, 63, 65);
		((Form)this).ClientSize = new Size(609, 391);
		((Control)this).Controls.Add((Control)(object)ButtonBreakIntoIndividualUnits);
		((Control)this).Controls.Add((Control)(object)ButtonSplit);
		((Control)this).Controls.Add((Control)(object)TB_RenameDestination);
		((Control)this).Controls.Add((Control)(object)ButtonRenameSource);
		((Control)this).Controls.Add((Control)(object)TB_RenameSource);
		((Control)this).Controls.Add((Control)(object)Button_ToSource);
		((Control)this).Controls.Add((Control)(object)Button_ToDestination);
		((Control)this).Controls.Add((Control)(object)LV_TargetUnit);
		((Control)this).Controls.Add((Control)(object)LV_SourceUnit);
		((Form)this).Margin = new Padding(3, 4, 3, 4);
		((Form)this).MaximumSize = new Size(625, 430);
		((Form)this).MinimumSize = new Size(625, 430);
		((Control)this).Name = "SplitUnit";
		((Form)this).ShowIcon = false;
		((Form)this).Text = "SplitUnit";
		((Control)this).ResumeLayout(false);
	}

	private void SplitUnit_Load(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)SourceUnit))
		{
			RefreshSourceUnit();
			RefreshTargetUnit();
			if (LV_SourceUnit.Items.Count > 0)
			{
				LV_SourceUnit.SelectItem(0);
			}
			TB_RenameDestination.Text = "New Detachement";
			TB_RenameSource.Text = SourceUnit.Name;
		}
	}

	public void RefreshSourceUnit()
	{
		LV_SourceUnit.Items.Clear();
		foreach (Mount mount in SourceUnit.Mounts)
		{
			if (!TransferedMounts.ContainsKey(mount))
			{
				DarkListItem darkListItem = new DarkListItem();
				darkListItem.Text = mount.Name;
				darkListItem.Tag = mount;
				LV_SourceUnit.Items.Add(darkListItem);
			}
		}
	}

	public void RefreshTargetUnit()
	{
		LV_TargetUnit.Items.Clear();
		foreach (Mount mount in SourceUnit.Mounts)
		{
			if (TransferedMounts.ContainsKey(mount))
			{
				DarkListItem darkListItem = new DarkListItem();
				darkListItem.Text = mount.Name;
				darkListItem.Tag = mount;
				LV_TargetUnit.Items.Add(darkListItem);
			}
		}
	}

	public List<Mount> FetchTransferableMounts()
	{
		List<Mount> list = new List<Mount>();
		foreach (Mount mount in SourceUnit.Mounts)
		{
			if (!TransferedMounts.ContainsKey(mount))
			{
				list.Add(mount);
			}
		}
		return list;
	}

	private void method_2(object sender, EventArgs e)
	{
		if (LV_SourceUnit.SelectedItems.Count > 0)
		{
			Mount mount = (Mount)LV_SourceUnit.SelectedItems.ElementAt(0).Tag;
			if (!TransferedMounts.ContainsKey(mount))
			{
				TransferedMounts.Add(mount, mount);
			}
		}
		RefreshSourceUnit();
		RefreshTargetUnit();
	}

	private void method_3(object sender, EventArgs e)
	{
		if (LV_TargetUnit.SelectedItems.Count > 0)
		{
			Mount key = (Mount)LV_TargetUnit.SelectedItems.ElementAt(0).Tag;
			if (TransferedMounts.ContainsKey(key))
			{
				TransferedMounts.Remove(key);
			}
		}
		RefreshSourceUnit();
		RefreshTargetUnit();
	}

	private void method_4(object sender, EventArgs e)
	{
		SourceUnit.Name = TB_RenameSource.Text;
	}

	private void method_5(object sender, EventArgs e)
	{
	}

	private void method_6(object sender, EventArgs e)
	{
		if (SourceUnit.Mounts.Count < 2)
		{
			((Form)this).Close();
			return;
		}
		Cargo[] CargoList = new Cargo[0];
		for (int i = SourceUnit.Mounts.Count - 1; i >= 0; i += -1)
		{
			foreach (KeyValuePair<Mount, Mount> transferedMount in TransferedMounts)
			{
				if (SourceUnit.Mounts.ElementAt(i) == transferedMount.Key)
				{
					ArrayExtensions.Add(ref CargoList, new Cargo(SourceUnit, transferedMount.Key));
					SourceUnit.Mounts.RemoveAt(i);
					break;
				}
			}
		}
		List<ActiveUnit> list = Cargo.UnloadCargoAtLocation(SourceUnit, ref CargoList, null, SourceUnit.get_Latitude((GlobalVariables.BooleanObject)null), SourceUnit.get_Longitude((GlobalVariables.BooleanObject)null), SourceUnit.ParentScen, SourceUnit.get_UnitSide(SetSideOnly: false), paradropOnly: false, ByUser: true);
		if (list.Count > 0)
		{
			list.ElementAt(0).Name = TB_RenameDestination.Text;
		}
		((Form)this).Close();
	}

	private void method_7(object sender, EventArgs e)
	{
		Cargo[] theArray = new Cargo[0];
		if (SourceUnit.Mounts.Count >= 2)
		{
			for (int i = SourceUnit.Mounts.Count - 1; i >= 1; i += -1)
			{
				ArrayExtensions.Add(ref theArray, new Cargo(SourceUnit, SourceUnit.Mounts.ElementAt(i)));
				SourceUnit.Mounts.RemoveAt(i);
				List<ActiveUnit> list = Cargo.UnloadCargoAtLocation(SourceUnit, ref theArray, null, SourceUnit.get_Latitude((GlobalVariables.BooleanObject)null), SourceUnit.get_Longitude((GlobalVariables.BooleanObject)null), SourceUnit.ParentScen, SourceUnit.get_UnitSide(SetSideOnly: false), paradropOnly: false, ByUser: true);
				if (list.Count > 0)
				{
					list.ElementAt(0).Name = "New Detachment";
				}
			}
			((Form)this).Close();
		}
		else
		{
			((Form)this).Close();
		}
	}

	static SplitUnit()
	{
		Class72.smethod_20();
	}
}
