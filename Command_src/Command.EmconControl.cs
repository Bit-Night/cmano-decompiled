using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Salamander.Windows.Forms;

namespace Command;

[DesignerGenerated]
public sealed class EmconControl : DarkUserControl
{
	public delegate void SensorsFormRequestedEventHandler();

	private IContainer icontainer_1;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkButton _Button1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button2")]
	private DarkButton _Button2;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_EMCON_Radar")]
	private DarkUIComboBox _CB_EMCON_Radar;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_EMCON_OECM")]
	private DarkUIComboBox _CB_EMCON_OECM;

	[AccessedThroughProperty("CB_EMCON_Sonar")]
	[CompilerGenerated]
	private DarkUIComboBox _CB_EMCON_Sonar;

	private ScenarioObject scenarioObject_0;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private int ActualWidth;

	[CompilerGenerated]
	private static SensorsFormRequestedEventHandler sensorsFormRequestedEventHandler_0;

	internal virtual DarkButton Button1
	{
		[CompilerGenerated]
		get
		{
			return _Button1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_4;
			DarkButton darkButton = _Button1;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button1 = value;
			darkButton = _Button1;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkButton Button2
	{
		[CompilerGenerated]
		get
		{
			return _Button2;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_5;
			DarkButton darkButton = _Button2;
			if (darkButton != null)
			{
				((Control)darkButton).Click -= eventHandler;
			}
			_Button2 = value;
			darkButton = _Button2;
			if (darkButton != null)
			{
				((Control)darkButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("CB_EMCON_Inherits")]
	internal virtual DarkCheckBox CB_EMCON_Inherits { get; set; }

	internal virtual DarkUIComboBox CB_EMCON_Radar
	{
		[CompilerGenerated]
		get
		{
			return _CB_EMCON_Radar;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_6;
			DarkUIComboBox darkUIComboBox = _CB_EMCON_Radar;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_EMCON_Radar = value;
			darkUIComboBox = _CB_EMCON_Radar;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TableLayoutPanel1")]
	internal virtual TableLayoutPanel TableLayoutPanel1 { get; set; }

	internal virtual DarkUIComboBox CB_EMCON_OECM
	{
		[CompilerGenerated]
		get
		{
			return _CB_EMCON_OECM;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_7;
			DarkUIComboBox darkUIComboBox = _CB_EMCON_OECM;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_EMCON_OECM = value;
			darkUIComboBox = _CB_EMCON_OECM;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	internal virtual DarkUIComboBox CB_EMCON_Sonar
	{
		[CompilerGenerated]
		get
		{
			return _CB_EMCON_Sonar;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_8;
			DarkUIComboBox darkUIComboBox = _CB_EMCON_Sonar;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_EMCON_Sonar = value;
			darkUIComboBox = _CB_EMCON_Sonar;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

	[field: AccessedThroughProperty("Label3")]
	internal virtual DarkLabel Label3 { get; set; }

	public static event SensorsFormRequestedEventHandler SensorsFormRequested
	{
		[CompilerGenerated]
		add
		{
			SensorsFormRequestedEventHandler sensorsFormRequestedEventHandler = sensorsFormRequestedEventHandler_0;
			SensorsFormRequestedEventHandler sensorsFormRequestedEventHandler2;
			do
			{
				sensorsFormRequestedEventHandler2 = sensorsFormRequestedEventHandler;
				SensorsFormRequestedEventHandler value2 = (SensorsFormRequestedEventHandler)Delegate.Combine(sensorsFormRequestedEventHandler2, value);
				sensorsFormRequestedEventHandler = Interlocked.CompareExchange(ref sensorsFormRequestedEventHandler_0, value2, sensorsFormRequestedEventHandler2);
			}
			while ((object)sensorsFormRequestedEventHandler != sensorsFormRequestedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			SensorsFormRequestedEventHandler sensorsFormRequestedEventHandler = sensorsFormRequestedEventHandler_0;
			SensorsFormRequestedEventHandler sensorsFormRequestedEventHandler2;
			do
			{
				sensorsFormRequestedEventHandler2 = sensorsFormRequestedEventHandler;
				SensorsFormRequestedEventHandler value2 = (SensorsFormRequestedEventHandler)Delegate.Remove(sensorsFormRequestedEventHandler2, value);
				sensorsFormRequestedEventHandler = Interlocked.CompareExchange(ref sensorsFormRequestedEventHandler_0, value2, sensorsFormRequestedEventHandler2);
			}
			while ((object)sensorsFormRequestedEventHandler != sensorsFormRequestedEventHandler2);
		}
	}

	public EmconControl()
	{
		((UserControl)this).Load += EmconControl_Load;
		((Control)this).VisibleChanged += EmconControl_VisibleChanged;
		bool_0 = true;
		bool_1 = true;
		bool_2 = false;
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
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Expected O, but got Unknown
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Expected O, but got Unknown
		//IL_0345: Unknown result type (might be due to invalid IL or missing references)
		//IL_037c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0386: Expected O, but got Unknown
		//IL_0398: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a2: Expected O, but got Unknown
		//IL_03b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03be: Expected O, but got Unknown
		//IL_03d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03da: Expected O, but got Unknown
		//IL_043d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0447: Expected O, but got Unknown
		//IL_0471: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f4: Expected O, but got Unknown
		//IL_051e: Unknown result type (might be due to invalid IL or missing references)
		//IL_059f: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0645: Unknown result type (might be due to invalid IL or missing references)
		//IL_0669: Unknown result type (might be due to invalid IL or missing references)
		//IL_06eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_070f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0796: Unknown result type (might be due to invalid IL or missing references)
		Button1 = new DarkButton();
		Button2 = new DarkButton();
		CB_EMCON_Inherits = new DarkCheckBox();
		CB_EMCON_Radar = new DarkUIComboBox();
		TableLayoutPanel1 = new TableLayoutPanel();
		CB_EMCON_OECM = new DarkUIComboBox();
		CB_EMCON_Sonar = new DarkUIComboBox();
		Label1 = new DarkLabel();
		Label2 = new DarkLabel();
		Label3 = new DarkLabel();
		((Control)TableLayoutPanel1).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)Button1).Location = new Point(0, 0);
		((Control)Button1).Name = "Button1";
		((Control)Button1).Padding = new Padding(5);
		((Control)Button1).Size = new Size(231, 21);
		((Control)Button1).TabIndex = 0;
		Button1.Text = "EMCON Window (Ctrl + F9)";
		((Control)Button2).Location = new Point(0, 21);
		((Control)Button2).Name = "Button2";
		((Control)Button2).Padding = new Padding(5);
		((Control)Button2).Size = new Size(231, 21);
		((Control)Button2).TabIndex = 1;
		Button2.Text = "Sensors Window (F9)";
		((ButtonBase)CB_EMCON_Inherits).AutoSize = true;
		((Control)CB_EMCON_Inherits).Location = new Point(3, 43);
		((Control)CB_EMCON_Inherits).Name = "CB_EMCON_Inherits";
		((Control)CB_EMCON_Inherits).Size = new Size(111, 17);
		((Control)CB_EMCON_Inherits).TabIndex = 2;
		((ButtonBase)CB_EMCON_Inherits).Text = "Inherit from parent";
		((ComboBox)CB_EMCON_Radar).BackColor = Color.Transparent;
		((ComboBox)CB_EMCON_Radar).DrawMode = (DrawMode)1;
		((ComboBox)CB_EMCON_Radar).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_EMCON_Radar).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)CB_EMCON_Radar).FormattingEnabled = true;
		((Control)CB_EMCON_Radar).Location = new Point(111, 0);
		((Control)CB_EMCON_Radar).Margin = new Padding(0, 0, 3, 3);
		((Control)CB_EMCON_Radar).Name = "CB_EMCON_Radar";
		((Control)CB_EMCON_Radar).Size = new Size(118, 21);
		((Control)CB_EMCON_Radar).TabIndex = 3;
		TableLayoutPanel1.ColumnCount = 2;
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle((SizeType)1, 111f));
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle((SizeType)1, 121f));
		TableLayoutPanel1.Controls.Add((Control)(object)CB_EMCON_Radar, 1, 0);
		TableLayoutPanel1.Controls.Add((Control)(object)CB_EMCON_OECM, 1, 1);
		TableLayoutPanel1.Controls.Add((Control)(object)CB_EMCON_Sonar, 1, 2);
		TableLayoutPanel1.Controls.Add((Control)(object)Label1, 0, 0);
		TableLayoutPanel1.Controls.Add((Control)(object)Label2, 0, 1);
		TableLayoutPanel1.Controls.Add((Control)(object)Label3, 0, 2);
		((Control)TableLayoutPanel1).Location = new Point(0, 62);
		((Control)TableLayoutPanel1).Margin = new Padding(0);
		((Control)TableLayoutPanel1).Name = "TableLayoutPanel1";
		TableLayoutPanel1.RowCount = 4;
		TableLayoutPanel1.RowStyles.Add(new RowStyle((SizeType)1, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle((SizeType)1, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle((SizeType)1, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle((SizeType)1, 22f));
		((Control)TableLayoutPanel1).Size = new Size(232, 67);
		((Control)TableLayoutPanel1).TabIndex = 4;
		((ComboBox)CB_EMCON_OECM).BackColor = Color.Transparent;
		((ComboBox)CB_EMCON_OECM).DrawMode = (DrawMode)1;
		((ComboBox)CB_EMCON_OECM).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_EMCON_OECM).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)CB_EMCON_OECM).FormattingEnabled = true;
		((Control)CB_EMCON_OECM).Location = new Point(111, 22);
		((Control)CB_EMCON_OECM).Margin = new Padding(0, 0, 3, 3);
		((Control)CB_EMCON_OECM).Name = "CB_EMCON_OECM";
		((Control)CB_EMCON_OECM).Size = new Size(118, 21);
		((Control)CB_EMCON_OECM).TabIndex = 4;
		((ComboBox)CB_EMCON_Sonar).BackColor = Color.Transparent;
		((ComboBox)CB_EMCON_Sonar).DrawMode = (DrawMode)1;
		((ComboBox)CB_EMCON_Sonar).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_EMCON_Sonar).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)CB_EMCON_Sonar).FormattingEnabled = true;
		((Control)CB_EMCON_Sonar).Location = new Point(111, 44);
		((Control)CB_EMCON_Sonar).Margin = new Padding(0, 0, 3, 3);
		((Control)CB_EMCON_Sonar).Name = "CB_EMCON_Sonar";
		((Control)CB_EMCON_Sonar).Size = new Size(118, 21);
		((Control)CB_EMCON_Sonar).TabIndex = 5;
		Label1.AutoSize = true;
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(0, 0);
		((Control)Label1).Margin = new Padding(0, 0, 3, 0);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Padding = new Padding(0, 6, 0, 0);
		((Control)Label1).Size = new Size(39, 19);
		((Control)Label1).TabIndex = 6;
		((Label)Label1).Text = "Radar:";
		Label2.AutoSize = true;
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(0, 22);
		((Control)Label2).Margin = new Padding(0, 0, 3, 0);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Padding = new Padding(0, 6, 0, 0);
		((Control)Label2).Size = new Size(41, 19);
		((Control)Label2).TabIndex = 7;
		((Label)Label2).Text = "OECM:";
		Label3.AutoSize = true;
		((Control)Label3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label3).Location = new Point(0, 44);
		((Control)Label3).Margin = new Padding(0, 0, 3, 0);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Padding = new Padding(0, 6, 0, 0);
		((Control)Label3).Size = new Size(38, 19);
		((Control)Label3).TabIndex = 8;
		((Label)Label3).Text = "Sonar:";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Control)this).Controls.Add((Control)(object)TableLayoutPanel1);
		((Control)this).Controls.Add((Control)(object)CB_EMCON_Inherits);
		((Control)this).Controls.Add((Control)(object)Button2);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Control)this).Margin = new Padding(0);
		((Control)this).Name = "EmconControl";
		((Control)this).Size = new Size(232, 142);
		((Control)TableLayoutPanel1).ResumeLayout(false);
		((Control)TableLayoutPanel1).PerformLayout();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void EmconControl_Load(object sender, EventArgs e)
	{
		Doctrine.EmconChanged += method_1;
		Client.SelectedUnitChanged += method_2;
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
	}

	private void method_1(ScenarioObject scenarioObject_1, bool? nullable_0, bool bool_3, bool bool_4, bool bool_5, bool bool_6)
	{
		if (bool_5 || bool_6 || Information.IsNothing((object)scenarioObject_1) || !scenarioObject_1.IsActiveUnit || (bool_3 && scenarioObject_1 != Client.SelectedUnit) || !bool_1 || Information.IsNothing((object)nullable_0) || (object)((object)((Control)this).Parent).GetType() != typeof(CollapsiblePanel) || ((CollapsiblePanel)(object)((Control)this).Parent).PanelState != PanelState.Expanded)
		{
			return;
		}
		Form[] ownedForms = ((Form)MyProject.Forms.MainForm).OwnedForms;
		int num = 0;
		while (true)
		{
			if (num < ownedForms.Length)
			{
				if ((object)((object)ownedForms[num]).GetType() == typeof(DoctrineForm))
				{
					break;
				}
				num = checked(num + 1);
				continue;
			}
			return;
		}
		MyProject.Forms.MainForm.RightColumn1.AdjustToSelectionChange(Client.SelectedUnit, Client.SelectedUnit);
	}

	private void method_2(Module_Unit.Unit unit_0)
	{
		scenarioObject_0 = unit_0;
		bool_0 = true;
	}

	[SpecialName]
	private Doctrine method_3()
	{
		if (Information.IsNothing((object)scenarioObject_0))
		{
			scenarioObject_0 = Client.SelectedUnit;
			if (Information.IsNothing((object)scenarioObject_0))
			{
				bool_2 = false;
				return null;
			}
		}
		if ((object)scenarioObject_0.GetType() == typeof(Side))
		{
			bool_2 = false;
			return ((Side)scenarioObject_0).Doctrine;
		}
		if (scenarioObject_0.IsMission)
		{
			bool_2 = false;
			return ((Mission)scenarioObject_0).Doctrine;
		}
		if (!scenarioObject_0.IsGroup)
		{
			if (scenarioObject_0.IsActiveUnit)
			{
				bool_2 = ((ActiveUnit)Client.SelectedUnit).AI.IsEscort;
				return ((ActiveUnit)scenarioObject_0).Doctrine;
			}
			bool_2 = false;
			return null;
		}
		Group obj = (Group)Client.SelectedUnit;
		if (Information.IsNothing((object)obj.GroupLead))
		{
			bool_2 = false;
		}
		else
		{
			bool_2 = obj.GroupLead.AI.IsEscort;
		}
		return ((Group)scenarioObject_0).Doctrine;
	}

	public void RefreshPanel(bool RePopulateComboBoxes)
	{
		if (Information.IsNothing((object)Client.SelectedUnit) || Information.IsNothing((object)method_3()))
		{
			return;
		}
		if (Client.DPI_scale != 1f)
		{
			if (ActualWidth == 0)
			{
				ActualWidth = ((Control)this).Width;
			}
			if (ActualWidth == ((Control)this).Width)
			{
				((Control)this).Width = (int)Math.Round((float)((Control)this).Width * Client.DPI_scale);
			}
		}
		((Control)this).Enabled = Client.SelectedUnit.get_UnitSide(SetSideOnly: false) == Client.CurrentSide;
		((Control)Button1).Visible = !Information.IsNothing((object)scenarioObject_0);
		((Control)Button2).Visible = !Information.IsNothing((object)scenarioObject_0);
		if (RePopulateComboBoxes)
		{
			Doctrine doctrine = method_3();
			DarkCheckBox cB_EMCON_Inherits = CB_EMCON_Inherits;
			ref ScenarioObject subject = ref scenarioObject_0;
			Doctrine theDoc = method_3();
			doctrine.Set_Checkbox_EMCON_Inherit((CheckBox)(object)cB_EMCON_Inherits, ref subject, ref theDoc);
			Doctrine doctrine2 = method_3();
			DarkUIComboBox cB_EMCON_Radar = CB_EMCON_Radar;
			Scenario CurrentScenario = Client.CurrentScenario;
			theDoc = method_3();
			doctrine2.Populate_Combo_EMCON_Radar((ComboBox)(object)cB_EMCON_Radar, ref CurrentScenario, ref theDoc);
			Doctrine doctrine3 = method_3();
			DarkUIComboBox cB_EMCON_OECM = CB_EMCON_OECM;
			CurrentScenario = Client.CurrentScenario;
			theDoc = method_3();
			doctrine3.Populate_Combo_EMCON_OECM((ComboBox)(object)cB_EMCON_OECM, ref CurrentScenario, ref theDoc);
			Doctrine doctrine4 = method_3();
			DarkUIComboBox cB_EMCON_Sonar = CB_EMCON_Sonar;
			CurrentScenario = Client.CurrentScenario;
			theDoc = method_3();
			doctrine4.Populate_Combo_EMCON_Sonar((ComboBox)(object)cB_EMCON_Sonar, ref CurrentScenario, ref theDoc);
		}
		bool_0 = false;
	}

	private void EmconControl_VisibleChanged(object sender, EventArgs e)
	{
		if (bool_0)
		{
			RefreshPanel(RePopulateComboBoxes: false);
		}
		CustomPanelsEventRaiser.FireChangeEvent();
	}

	private void method_4(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)scenarioObject_0))
		{
			DoctrineForm obj = new DoctrineForm
			{
				Subject = scenarioObject_0,
				isEscorts = bool_2
			};
			((TabControl)obj.TabControl1A).SelectedIndex = 1;
			((Control)obj).Show();
		}
	}

	private void method_5(object sender, EventArgs e)
	{
		sensorsFormRequestedEventHandler_0?.Invoke();
	}

	private void method_6(object sender, EventArgs e)
	{
		DarkUIComboBox cB_EMCON_Radar = CB_EMCON_Radar;
		Scenario CurrentScenario = Client.CurrentScenario;
		Doctrine thedoc = method_3();
		bool AskObedience = true;
		SelectionChanged_Combo_EMCON_Radar((ComboBox)(object)cB_EMCON_Radar, ref CurrentScenario, ref thedoc, MultipleUnits: false, ref AskObedience, ref bool_2, ViaDoctrineForm: false, ViaRightColumn: true);
		((Control)MyProject.Forms.MainForm.WorldWindow1).Focus();
		MyProject.Forms.MainForm.MapRender_Tactical();
	}

	private void method_7(object sender, EventArgs e)
	{
		DarkUIComboBox cB_EMCON_OECM = CB_EMCON_OECM;
		Scenario CurrentScenario = Client.CurrentScenario;
		Doctrine thedoc = method_3();
		bool AskObedience = true;
		SelectionChanged_Combo_EMCON_OECM((ComboBox)(object)cB_EMCON_OECM, ref CurrentScenario, ref thedoc, MultipleUnits: false, ref AskObedience, ref bool_2, ViaDoctrineForm: false, ViaRightColumn: true);
		((Control)MyProject.Forms.MainForm.WorldWindow1).Focus();
		MyProject.Forms.MainForm.MapRender_Tactical();
	}

	private void method_8(object sender, EventArgs e)
	{
		DarkUIComboBox cB_EMCON_Sonar = CB_EMCON_Sonar;
		Scenario CurrentScenario = Client.CurrentScenario;
		Doctrine thedoc = method_3();
		bool AskObedience = true;
		SelectionChanged_Combo_EMCON_Sonar((ComboBox)(object)cB_EMCON_Sonar, ref CurrentScenario, ref thedoc, MultipleUnits: false, ref AskObedience, ref bool_2, ViaDoctrineForm: false, ViaRightColumn: true);
		((Control)MyProject.Forms.MainForm.WorldWindow1).Focus();
		MyProject.Forms.MainForm.MapRender_Tactical();
	}

	public static void SelectionChanged_Combo_EMCON_Radar(ComboBox combobox, ref Scenario CurrentScenario, ref Doctrine thedoc, bool MultipleUnits, ref bool AskObedience, ref bool MissionEscorts, bool ViaDoctrineForm, bool ViaRightColumn)
	{
		thedoc.SetEMCON_Radar(Doctrine.EMCONSettings.EMCONSettingSelection_To_EMCONSetting(combobox.SelectedIndex), CurrentScenario);
		if (!Information.IsNothing((object)thedoc.SelectedUnits))
		{
			foreach (ActiveUnit selectedUnit in thedoc.SelectedUnits)
			{
				selectedUnit.Doctrine.SetEMCON_Radar((Doctrine.EMCONSettings._EMCONSetting)combobox.SelectedIndex, CurrentScenario);
			}
		}
		if (AskObedience && !Client.Realtime)
		{
			AskEMCONObedience(ref CurrentScenario, ref thedoc, ref MissionEscorts, ViaDoctrineForm, ViaRightColumn);
		}
		Doctrine.RaiseEvent_EMCONChanged(thedoc.Subject, false, MultipleUnits, ViaDoctrineForm, ViaRightColumn, viaFlightPlanEditor: false);
	}

	public static void SelectionChanged_Combo_EMCON_OECM(ComboBox combobox, ref Scenario CurrentScenario, ref Doctrine thedoc, bool MultipleUnits, ref bool AskObedience, ref bool MissionEscorts, bool ViaDoctrineForm, bool ViaRightColumn)
	{
		thedoc.SetEMCON_OECM(Doctrine.EMCONSettings.EMCONSettingSelection_To_EMCONSetting(combobox.SelectedIndex), CurrentScenario);
		if (!Information.IsNothing((object)thedoc.SelectedUnits))
		{
			foreach (ActiveUnit selectedUnit in thedoc.SelectedUnits)
			{
				selectedUnit.Doctrine.SetEMCON_OECM((Doctrine.EMCONSettings._EMCONSetting)combobox.SelectedIndex, CurrentScenario);
			}
		}
		if (AskObedience && !Client.Realtime)
		{
			AskEMCONObedience(ref CurrentScenario, ref thedoc, ref MissionEscorts, ViaDoctrineForm, ViaRightColumn);
		}
		Doctrine.RaiseEvent_EMCONChanged(thedoc.Subject, false, MultipleUnits, ViaDoctrineForm, ViaRightColumn, viaFlightPlanEditor: false);
	}

	public static void SelectionChanged_Combo_EMCON_Sonar(ComboBox combobox, ref Scenario CurrentScenario, ref Doctrine thedoc, bool MultipleUnits, ref bool AskObedience, ref bool MissionEscorts, bool ViaDoctrineForm, bool ViaRightColumn)
	{
		thedoc.SetEMCON_Sonar(Doctrine.EMCONSettings.EMCONSettingSelection_To_EMCONSetting(combobox.SelectedIndex), CurrentScenario);
		if (!Information.IsNothing((object)thedoc.SelectedUnits))
		{
			foreach (ActiveUnit selectedUnit in thedoc.SelectedUnits)
			{
				selectedUnit.Doctrine.SetEMCON_Sonar((Doctrine.EMCONSettings._EMCONSetting)combobox.SelectedIndex, CurrentScenario);
			}
		}
		if (AskObedience && !Client.Realtime)
		{
			AskEMCONObedience(ref CurrentScenario, ref thedoc, ref MissionEscorts, ViaDoctrineForm, ViaRightColumn);
		}
		Doctrine.RaiseEvent_EMCONChanged(thedoc.Subject, false, MultipleUnits, ViaDoctrineForm, ViaRightColumn, viaFlightPlanEditor: false);
	}

	public static void AskEMCONObedience(ref Scenario CurrentScenario, ref Doctrine thedoc, ref bool MissionEscorts, bool ViaDoctrineForm, bool ViaRightColumn)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Invalid comparison between Unknown and I4
		if ((object)thedoc.SubjectType == typeof(Waypoint))
		{
			return;
		}
		if ((int)DarkMessageBox.ShowInformation("Enforce EMCON obedience on all affected units? \r\n\r\nYes: Manual sensor settings for affected missions, groups and/or units will be reset to use the above EMCON settings.\r\nNo: Affected units retain customized EMCON (if any) and will not use the specified EMCON settings.", "EMCON obedience", DarkDialogButton.YesNo) == 6)
		{
			if (thedoc == null)
			{
				return;
			}
			if (!Information.IsNothing((object)thedoc.SelectedUnits))
			{
				List<ActiveUnit>.Enumerator enumerator = thedoc.SelectedUnits.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ActiveUnit current = enumerator.Current;
					List<ActiveUnit>.Enumerator enumerator2 = current.Doctrine.AffectedUnits(CurrentScenario, MissionEscorts).GetEnumerator();
					while (enumerator2.MoveNext())
					{
						enumerator2.Current.Sensory.ObeysEMCON = true;
					}
				}
			}
			else
			{
				List<ActiveUnit>.Enumerator enumerator3 = thedoc.AffectedUnits(CurrentScenario, MissionEscorts).GetEnumerator();
				while (enumerator3.MoveNext())
				{
					enumerator3.Current.Sensory.ObeysEMCON = true;
				}
			}
		}
		else
		{
			if (thedoc == null)
			{
				return;
			}
			if (!Information.IsNothing((object)thedoc.SelectedUnits))
			{
				List<ActiveUnit>.Enumerator enumerator4 = thedoc.SelectedUnits.GetEnumerator();
				while (enumerator4.MoveNext())
				{
					ActiveUnit current2 = enumerator4.Current;
					List<ActiveUnit>.Enumerator enumerator5 = current2.Doctrine.AffectedUnits(CurrentScenario, MissionEscorts).GetEnumerator();
					while (enumerator5.MoveNext())
					{
						enumerator5.Current.Sensory.vmethod_2(current2.Sensors_Cached);
					}
				}
			}
			else
			{
				List<ActiveUnit>.Enumerator enumerator6 = thedoc.AffectedUnits(CurrentScenario, MissionEscorts).GetEnumerator();
				while (enumerator6.MoveNext())
				{
					ActiveUnit current3 = enumerator6.Current;
					current3.Sensory.vmethod_2(current3.Sensors_Cached);
				}
			}
		}
		if (!Information.IsNothing((object)thedoc.SelectedUnits))
		{
			List<ActiveUnit>.Enumerator enumerator7 = thedoc.SelectedUnits.GetEnumerator();
			while (enumerator7.MoveNext())
			{
				Doctrine.RaiseEvent_EMCONChanged(enumerator7.Current, false, MultipleUnits: true, ViaDoctrineForm, ViaRightColumn, viaFlightPlanEditor: false);
			}
		}
		else
		{
			Doctrine.RaiseEvent_EMCONChanged(thedoc.Subject, false, MultipleUnits: false, ViaDoctrineForm, ViaRightColumn, viaFlightPlanEditor: false);
		}
	}

	static EmconControl()
	{
		Class72.smethod_20();
	}
}
