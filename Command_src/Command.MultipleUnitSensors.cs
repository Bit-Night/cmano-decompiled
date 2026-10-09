using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
public sealed class MultipleUnitSensors : DarkSecondaryFormBase, GInterface0
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_radar")]
	private DarkCheckBox _CB_radar;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_Sonar")]
	private DarkCheckBox _CB_Sonar;

	[AccessedThroughProperty("CB_ECM")]
	[CompilerGenerated]
	private DarkCheckBox _CB_ECM;

	[CompilerGenerated]
	private bool bool_2;

	public List<Module_Unit.Unit> SelectedUnits;

	private List<Sensor> list_0;

	private List<Sensor> list_1;

	private List<Sensor> list_2;

	private IEnumerable<Module_Unit.Unit> ienumerable_0;

	private bool bool_3;

	private Keys[] keys_0;

	private bool bool_4;

	internal virtual DarkCheckBox CB_radar
	{
		[CompilerGenerated]
		get
		{
			return _CB_radar;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_5;
			DarkCheckBox darkCheckBox = _CB_radar;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_radar = value;
			darkCheckBox = _CB_radar;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_Sonar
	{
		[CompilerGenerated]
		get
		{
			return _CB_Sonar;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_6;
			DarkCheckBox darkCheckBox = _CB_Sonar;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_Sonar = value;
			darkCheckBox = _CB_Sonar;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_ECM
	{
		[CompilerGenerated]
		get
		{
			return _CB_ECM;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_7;
			DarkCheckBox darkCheckBox = _CB_ECM;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click -= eventHandler;
			}
			_CB_ECM = value;
			darkCheckBox = _CB_ECM;
			if (darkCheckBox != null)
			{
				((Control)darkCheckBox).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

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

	public MultipleUnitSensors()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).Load += MultipleUnitSensors_Load;
		((Control)this).KeyDown += new KeyEventHandler(MultipleUnitSensors_KeyDown);
		((Form)this).FormClosing += new FormClosingEventHandler(MultipleUnitSensors_FormClosing);
		RTMPEnabled = true;
		list_0 = new List<Sensor>();
		list_1 = new List<Sensor>();
		list_2 = new List<Sensor>();
		bool_3 = false;
		keys_0 = (Keys[])(object)new Keys[2]
		{
			(Keys)120,
			(Keys)27
		};
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
		CB_radar = new DarkCheckBox();
		CB_Sonar = new DarkCheckBox();
		CB_ECM = new DarkCheckBox();
		Label1 = new DarkLabel();
		((Control)this).SuspendLayout();
		((ButtonBase)CB_radar).AutoSize = true;
		((CheckBox)CB_radar).CheckAlign = (ContentAlignment)64;
		((Control)CB_radar).Location = new Point(8, 31);
		((Control)CB_radar).Name = "CB_radar";
		((Control)CB_radar).RightToLeft = (RightToLeft)1;
		((Control)CB_radar).Size = new Size(61, 19);
		((Control)CB_radar).TabIndex = 4;
		((ButtonBase)CB_radar).Text = "Radars";
		((ButtonBase)CB_Sonar).AutoSize = true;
		((CheckBox)CB_Sonar).CheckAlign = (ContentAlignment)64;
		((Control)CB_Sonar).Location = new Point(83, 31);
		((Control)CB_Sonar).Name = "CB_Sonar";
		((Control)CB_Sonar).RightToLeft = (RightToLeft)1;
		((Control)CB_Sonar).Size = new Size(61, 19);
		((Control)CB_Sonar).TabIndex = 5;
		((ButtonBase)CB_Sonar).Text = "Sonars";
		((ButtonBase)CB_ECM).AutoSize = true;
		((CheckBox)CB_ECM).CheckAlign = (ContentAlignment)64;
		((Control)CB_ECM).Location = new Point(151, 31);
		((Control)CB_ECM).Name = "CB_ECM";
		((Control)CB_ECM).RightToLeft = (RightToLeft)1;
		((Control)CB_ECM).Size = new Size(104, 19);
		((Control)CB_ECM).TabIndex = 6;
		((ButtonBase)CB_ECM).Text = "Offensive ECM";
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(5, 5);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(115, 23);
		((Control)Label1).TabIndex = 7;
		((Label)Label1).Text = "(Checked = Active)";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(260, 69);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)CB_ECM);
		((Control)this).Controls.Add((Control)(object)CB_radar);
		((Control)this).Controls.Add((Control)(object)CB_Sonar);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Form)this).Location = new Point(0, 0);
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Form)this).MinimumSize = new Size(276, 108);
		((Control)this).Name = "MultipleUnitSensors";
		((Form)this).ShowIcon = false;
		((Form)this).ShowInTaskbar = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Multiple unit sensors";
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void method_2()
	{
		Client.ForceReFetchOfSelectedUnit();
		if (SelectedUnits == null)
		{
			return;
		}
		List<Module_Unit.Unit> list = new List<Module_Unit.Unit>();
		foreach (Module_Unit.Unit selectedUnit in SelectedUnits)
		{
			ActiveUnit value = null;
			if (Client.CurrentScenario.ActiveUnits.TryGetValue(selectedUnit.ObjectID, out value))
			{
				list.Add(value);
			}
		}
		SelectedUnits = list;
	}

	public void RefreshForm()
	{
		if (bool_4)
		{
			return;
		}
		bool_4 = true;
		try
		{
			if (bool_3)
			{
				method_2();
			}
			list_0.Clear();
			list_1.Clear();
			list_2.Clear();
			if (!Information.IsNothing((object)Client.SelectedWaypoint))
			{
				if (Operators.CompareString(Client.SelectedWaypoint.Name, "", true) != 0)
				{
					((Form)this).Text = "Sensors for: " + Client.SelectedWaypoint.Name;
				}
				else
				{
					((Form)this).Text = "Sensors for: Navigation Waypoint";
				}
			}
			else if (Client.SelectedUnit.IsActiveUnit)
			{
				((Form)this).Text = "Multiple sensors for: " + Client.SelectedUnit.Name;
			}
			if (!Information.IsNothing((object)Client.SelectedWaypoint))
			{
				if (Client.SelectedWaypoint.GetDoctrine(Client.CurrentScenario).EMCON_Inherits)
				{
					((CheckBox)CB_radar).CheckState = (CheckState)2;
				}
				else if (Client.SelectedWaypoint.GetDoctrine(Client.CurrentScenario).EMCON(Client.CurrentScenario).Radar() == Doctrine.EMCONSettings._EMCONSetting.Active)
				{
					((CheckBox)CB_radar).Checked = true;
				}
				else if (Client.SelectedWaypoint.GetDoctrine(Client.CurrentScenario).EMCON(Client.CurrentScenario).Radar() == Doctrine.EMCONSettings._EMCONSetting.NotConfigured)
				{
					((CheckBox)CB_radar).CheckState = (CheckState)2;
				}
				else
				{
					((CheckBox)CB_radar).Checked = false;
				}
				if (!Client.SelectedWaypoint.GetDoctrine(Client.CurrentScenario).EMCON_Inherits)
				{
					if (Client.SelectedWaypoint.GetDoctrine(Client.CurrentScenario).EMCON(Client.CurrentScenario).Sonar() == Doctrine.EMCONSettings._EMCONSetting.Active)
					{
						((CheckBox)CB_Sonar).Checked = true;
					}
					else if (Client.SelectedWaypoint.GetDoctrine(Client.CurrentScenario).EMCON(Client.CurrentScenario).Sonar() == Doctrine.EMCONSettings._EMCONSetting.NotConfigured)
					{
						((CheckBox)CB_Sonar).CheckState = (CheckState)2;
					}
					else
					{
						((CheckBox)CB_Sonar).Checked = false;
					}
				}
				else
				{
					((CheckBox)CB_Sonar).CheckState = (CheckState)2;
				}
				if (!Client.SelectedWaypoint.GetDoctrine(Client.CurrentScenario).EMCON_Inherits)
				{
					if (Client.SelectedWaypoint.GetDoctrine(Client.CurrentScenario).EMCON(Client.CurrentScenario).OECM() == Doctrine.EMCONSettings._EMCONSetting.Active)
					{
						((CheckBox)CB_ECM).Checked = true;
					}
					else if (Client.SelectedWaypoint.GetDoctrine(Client.CurrentScenario).EMCON(Client.CurrentScenario).OECM() == Doctrine.EMCONSettings._EMCONSetting.NotConfigured)
					{
						((CheckBox)CB_ECM).CheckState = (CheckState)2;
					}
					else
					{
						((CheckBox)CB_ECM).Checked = false;
					}
				}
				else
				{
					((CheckBox)CB_ECM).CheckState = (CheckState)2;
				}
			}
			else if (SelectedUnits != null)
			{
				ienumerable_0 = SelectedUnits.Where([SpecialName] (Module_Unit.Unit theAU) => theAU.IsActiveUnit & (theAU.get_UnitSide(SetSideOnly: false) == Client.CurrentSide));
				List<Sensor> list = new List<Sensor>();
				foreach (ActiveUnit item in ienumerable_0)
				{
					Sensor[] collection = item.Sensors_ReadOnly();
					list.AddRange(collection);
				}
				foreach (Sensor item2 in list)
				{
					if (item2.Type == Sensor.Sensor_Type.Radar)
					{
						list_0.Add(item2);
					}
					else if (item2.IsSonar)
					{
						list_1.Add(item2);
					}
					else if (item2.IsOECM)
					{
						list_2.Add(item2);
					}
				}
				IEnumerable<Sensor> source = list_0.Where([SpecialName] (Sensor theS) => theS.IsActive());
				if (source.Count() != 0)
				{
					if (source.Count() == list_0.Count)
					{
						((CheckBox)CB_radar).Checked = true;
					}
					else
					{
						((CheckBox)CB_radar).CheckState = (CheckState)2;
					}
				}
				else
				{
					((CheckBox)CB_radar).Checked = false;
				}
				IEnumerable<Sensor> source2 = list_1.Where([SpecialName] (Sensor theS) => theS.IsActive());
				if (source2.Count() != 0)
				{
					if (source2.Count() == list_1.Count)
					{
						((CheckBox)CB_Sonar).Checked = true;
					}
					else
					{
						((CheckBox)CB_Sonar).CheckState = (CheckState)2;
					}
				}
				else
				{
					((CheckBox)CB_Sonar).Checked = false;
				}
				IEnumerable<Sensor> source3 = list_2.Where([SpecialName] (Sensor theS) => theS.IsActive());
				if (source3.Count() != 0)
				{
					if (source3.Count() == list_2.Count)
					{
						((CheckBox)CB_ECM).Checked = true;
					}
					else
					{
						((CheckBox)CB_ECM).CheckState = (CheckState)2;
					}
				}
				else
				{
					((CheckBox)CB_ECM).Checked = false;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 200107", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		bool_4 = false;
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		Keys[] array = keys_0;
		if (0 < array.Length)
		{
			int result;
			if (!((Control)this).Visible)
			{
				((Form)this).Activate();
				result = 1;
			}
			else
			{
				((Form)this).Close();
				result = 1;
			}
			return (byte)result != 0;
		}
		return false;
	}

	private void MultipleUnitSensors_Load(object sender, EventArgs e)
	{
		bool_3 = Client.Realtime;
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		RefreshForm();
	}

	private bool method_3()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Invalid comparison between Unknown and I4
		bool result = (int)DarkMessageBox.ShowWarning("Override strict obedience to EMCON settings if present?", "Override EMCON?", DarkDialogButton.YesNo) == 6;
		try
		{
			string text = "";
			foreach (Module_Unit.Unit selectedUnit in SelectedUnits)
			{
				if (!selectedUnit.IsActiveUnit || !((ActiveUnit)selectedUnit).IsGroupMember())
				{
					continue;
				}
				if (Operators.CompareString(text, "", true) != 0)
				{
					if (Operators.CompareString(text, ((ActiveUnit)selectedUnit).get_ParentGroup(UsingMissionPlanner: false).ObjectID, true) != 0)
					{
						text = "NO";
					}
				}
				else
				{
					text = ((ActiveUnit)selectedUnit).get_ParentGroup(UsingMissionPlanner: false).ObjectID;
				}
			}
			if ((Operators.CompareString(text, "", true) != 0) & (Operators.CompareString(text, "NO", true) != 0))
			{
				((ActiveUnit)SelectedUnits[0]).get_ParentGroup(UsingMissionPlanner: false).Sensory.ObeysEMCON = false;
				((ActiveUnit)SelectedUnits[0]).get_ParentGroup(UsingMissionPlanner: false).Doctrine.EMCON_Inherits = false;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 564654321657", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void method_4(List<Module_Unit.Unit> list_3, bool bool_5, List<Sensor> list_4, bool bool_6)
	{
		if (bool_3)
		{
			if (list_3.Count > 0)
			{
				RTMPPendingUIEvent = Client.RealtimeTerminal.SendMultipleSensorEMCONUpdate(list_3, bool_5);
			}
			if (list_4.Count > 0)
			{
				RTMPPendingUIEvent = Client.RealtimeTerminal.SendMultipleSensorActivation(list_4, bool_6);
			}
		}
	}

	private void method_5(object sender, EventArgs e)
	{
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Expected I4, but got Unknown
		bool_4 = true;
		if (Information.IsNothing((object)Client.SelectedWaypoint))
		{
			bool flag = method_3();
			bool bool_ = ((CheckBox)CB_radar).Checked;
			List<Module_Unit.Unit> list = default(List<Module_Unit.Unit>);
			List<Sensor> list2 = default(List<Sensor>);
			if (bool_3)
			{
				list = new List<Module_Unit.Unit>();
				list2 = new List<Sensor>();
			}
			bool flag2;
			if (!(flag2 = ((CheckBox)CB_radar).Checked))
			{
				foreach (Sensor item in list_0)
				{
					if (item.ParentPlatform.Sensory.ObeysEMCON && !flag)
					{
						continue;
					}
					item.ParentPlatform.Sensory.ObeysEMCON = false;
					if (bool_3 && !list.Contains(item.ParentPlatform))
					{
						list.Add(item.ParentPlatform);
					}
					if (!item.IsPureIlluminator && item.IsActive())
					{
						item.GoPassive();
						if (bool_3)
						{
							list2.Add(item);
						}
					}
				}
			}
			else if (flag2)
			{
				foreach (Sensor item2 in list_0)
				{
					if (item2.ParentPlatform.Sensory.ObeysEMCON && !flag)
					{
						continue;
					}
					item2.ParentPlatform.Sensory.ObeysEMCON = false;
					if (bool_3 && !list.Contains(item2.ParentPlatform))
					{
						list.Add(item2.ParentPlatform);
					}
					if (!item2.IsPureIlluminator && !item2.IsActive())
					{
						item2.GoActive();
						if (bool_3)
						{
							list2.Add(item2);
						}
					}
				}
			}
			int mustRefreshMainForm;
			if (!bool_3)
			{
				mustRefreshMainForm = 1;
			}
			else
			{
				method_4(list, bool_5: false, list2, bool_);
				mustRefreshMainForm = 1;
			}
			Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
			MyProject.Forms.MainForm.RefreshRightColumn();
		}
		else
		{
			CB_radar.ThreeState = true;
			CheckState checkState = ((CheckBox)CB_radar).CheckState;
			switch ((int)checkState)
			{
			case 0:
				Client.SelectedWaypoint.GetDoctrine(Client.CurrentScenario).EMCON_Inherits = false;
				Client.SelectedWaypoint.GetDoctrine(Client.CurrentScenario).SetEMCON_Radar(Doctrine.EMCONSettings._EMCONSetting.Passive, Client.CurrentScenario);
				break;
			case 1:
				Client.SelectedWaypoint.GetDoctrine(Client.CurrentScenario).EMCON_Inherits = false;
				Client.SelectedWaypoint.GetDoctrine(Client.CurrentScenario).SetEMCON_Radar(Doctrine.EMCONSettings._EMCONSetting.Active, Client.CurrentScenario);
				break;
			case 2:
				if (Client.SelectedWaypoint.GetDoctrine(Client.CurrentScenario).EMCON(Client.CurrentScenario).Sonar() == Doctrine.EMCONSettings._EMCONSetting.NotConfigured && Client.SelectedWaypoint.GetDoctrine(Client.CurrentScenario).EMCON(Client.CurrentScenario).OECM() == Doctrine.EMCONSettings._EMCONSetting.NotConfigured)
				{
					Client.SelectedWaypoint.GetDoctrine(Client.CurrentScenario).EMCON_Inherits = true;
				}
				Client.SelectedWaypoint.GetDoctrine(Client.CurrentScenario).SetEMCON_Radar(Doctrine.EMCONSettings._EMCONSetting.NotConfigured, Client.CurrentScenario);
				break;
			}
			if (bool_3)
			{
				Client.RealtimeTerminal.SendWaypointSensorChangeRadar(Client.SelectedUnit, Client.SelectedWaypoint);
			}
		}
		bool_4 = false;
	}

	private void method_6(object sender, EventArgs e)
	{
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Expected I4, but got Unknown
		bool_4 = true;
		if (Information.IsNothing((object)Client.SelectedWaypoint))
		{
			bool flag = method_3();
			bool bool_ = ((CheckBox)CB_Sonar).Checked;
			List<Module_Unit.Unit> list = default(List<Module_Unit.Unit>);
			List<Sensor> list2 = default(List<Sensor>);
			if (bool_3)
			{
				list = new List<Module_Unit.Unit>();
				list2 = new List<Sensor>();
			}
			bool flag2;
			if (!(flag2 = ((CheckBox)CB_Sonar).Checked))
			{
				foreach (Sensor item in list_1)
				{
					if (item.ParentPlatform.Sensory.ObeysEMCON && !flag)
					{
						continue;
					}
					item.ParentPlatform.Sensory.ObeysEMCON = false;
					if (bool_3 && !list.Contains(item.ParentPlatform))
					{
						list.Add(item.ParentPlatform);
					}
					if (!item.IsPureIlluminator && item.IsActive())
					{
						item.GoPassive();
						if (bool_3)
						{
							list2.Add(item);
						}
					}
				}
			}
			else if (flag2)
			{
				foreach (Sensor item2 in list_1)
				{
					if (item2.ParentPlatform.Sensory.ObeysEMCON && !flag)
					{
						continue;
					}
					item2.ParentPlatform.Sensory.ObeysEMCON = false;
					if (bool_3 && !list.Contains(item2.ParentPlatform))
					{
						list.Add(item2.ParentPlatform);
					}
					if (!item2.IsPureIlluminator && !item2.IsActive() && item2.CanBeActive)
					{
						item2.GoActive();
						if (bool_3)
						{
							list2.Add(item2);
						}
					}
				}
			}
			int mustRefreshMainForm;
			if (bool_3)
			{
				method_4(list, bool_5: false, list2, bool_);
				mustRefreshMainForm = 1;
			}
			else
			{
				mustRefreshMainForm = 1;
			}
			Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
			MyProject.Forms.MainForm.RefreshRightColumn();
		}
		else
		{
			CB_Sonar.ThreeState = true;
			CheckState checkState = ((CheckBox)CB_Sonar).CheckState;
			switch ((int)checkState)
			{
			case 0:
				Client.SelectedWaypoint.GetDoctrine(Client.CurrentScenario).EMCON_Inherits = false;
				Client.SelectedWaypoint.GetDoctrine(Client.CurrentScenario).SetEMCON_Sonar(Doctrine.EMCONSettings._EMCONSetting.Passive, Client.CurrentScenario);
				break;
			case 1:
				Client.SelectedWaypoint.GetDoctrine(Client.CurrentScenario).EMCON_Inherits = false;
				Client.SelectedWaypoint.GetDoctrine(Client.CurrentScenario).SetEMCON_Sonar(Doctrine.EMCONSettings._EMCONSetting.Active, Client.CurrentScenario);
				break;
			case 2:
				if (Client.SelectedWaypoint.GetDoctrine(Client.CurrentScenario).EMCON(Client.CurrentScenario).Radar() == Doctrine.EMCONSettings._EMCONSetting.NotConfigured && Client.SelectedWaypoint.GetDoctrine(Client.CurrentScenario).EMCON(Client.CurrentScenario).OECM() == Doctrine.EMCONSettings._EMCONSetting.NotConfigured)
				{
					Client.SelectedWaypoint.GetDoctrine(Client.CurrentScenario).EMCON_Inherits = true;
				}
				Client.SelectedWaypoint.GetDoctrine(Client.CurrentScenario).SetEMCON_Sonar(Doctrine.EMCONSettings._EMCONSetting.NotConfigured, Client.CurrentScenario);
				break;
			}
			if (bool_3)
			{
				Client.RealtimeTerminal.SendWaypointSensorChangeSonar(Client.SelectedUnit, Client.SelectedWaypoint);
			}
		}
		bool_4 = false;
	}

	private void method_7(object sender, EventArgs e)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected I4, but got Unknown
		bool_4 = true;
		if (!Information.IsNothing((object)Client.SelectedWaypoint))
		{
			CB_ECM.ThreeState = true;
			CheckState checkState = ((CheckBox)CB_ECM).CheckState;
			switch ((int)checkState)
			{
			case 0:
				Client.SelectedWaypoint.GetDoctrine(Client.CurrentScenario).EMCON_Inherits = false;
				Client.SelectedWaypoint.GetDoctrine(Client.CurrentScenario).SetEMCON_OECM(Doctrine.EMCONSettings._EMCONSetting.Passive, Client.CurrentScenario);
				break;
			case 1:
				Client.SelectedWaypoint.GetDoctrine(Client.CurrentScenario).EMCON_Inherits = false;
				Client.SelectedWaypoint.GetDoctrine(Client.CurrentScenario).SetEMCON_OECM(Doctrine.EMCONSettings._EMCONSetting.Active, Client.CurrentScenario);
				break;
			case 2:
				if (Client.SelectedWaypoint.GetDoctrine(Client.CurrentScenario).EMCON(Client.CurrentScenario).Radar() == Doctrine.EMCONSettings._EMCONSetting.NotConfigured && Client.SelectedWaypoint.GetDoctrine(Client.CurrentScenario).EMCON(Client.CurrentScenario).Sonar() == Doctrine.EMCONSettings._EMCONSetting.NotConfigured)
				{
					Client.SelectedWaypoint.GetDoctrine(Client.CurrentScenario).EMCON_Inherits = true;
				}
				Client.SelectedWaypoint.GetDoctrine(Client.CurrentScenario).SetEMCON_OECM(Doctrine.EMCONSettings._EMCONSetting.NotConfigured, Client.CurrentScenario);
				break;
			}
			if (bool_3)
			{
				Client.RealtimeTerminal.SendWaypointSensorChangeOECM(Client.SelectedUnit, Client.SelectedWaypoint);
			}
		}
		else
		{
			bool flag = method_3();
			bool bool_ = ((CheckBox)CB_ECM).Checked;
			List<Module_Unit.Unit> list_ = default(List<Module_Unit.Unit>);
			List<Sensor> list = default(List<Sensor>);
			if (bool_3)
			{
				list_ = new List<Module_Unit.Unit>();
				list = new List<Sensor>();
			}
			bool flag2;
			if (!(flag2 = ((CheckBox)CB_ECM).Checked))
			{
				foreach (Sensor item in list_2)
				{
					if (!(item.ParentPlatform.Sensory.ObeysEMCON && !flag) && item.IsActive())
					{
						item.GoPassive();
						if (bool_3)
						{
							list.Add(item);
						}
					}
				}
			}
			else if (flag2)
			{
				foreach (Sensor item2 in list_2)
				{
					if (!(item2.ParentPlatform.Sensory.ObeysEMCON && !flag) && !item2.IsActive())
					{
						item2.GoActive();
						if (bool_3)
						{
							list.Add(item2);
						}
					}
				}
			}
			int mustRefreshMainForm;
			if (!bool_3)
			{
				mustRefreshMainForm = 1;
			}
			else
			{
				method_4(list_, bool_5: false, list, bool_);
				mustRefreshMainForm = 1;
			}
			Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
			MyProject.Forms.MainForm.RefreshRightColumn();
		}
		bool_4 = false;
	}

	private void MultipleUnitSensors_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Invalid comparison between Unknown and I4
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Invalid comparison between Unknown and I4
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Invalid comparison between Unknown and I4
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Invalid comparison between Unknown and I4
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Invalid comparison between Unknown and I4
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
		else if ((int)e.KeyCode == 120 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
		else if (!((Control)this).Visible || ((int)e.KeyCode != 38 && (int)e.KeyCode != 40 && (int)e.KeyCode != 37 && (int)e.KeyCode != 39 && (int)e.KeyCode != 32))
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void MultipleUnitSensors_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	static MultipleUnitSensors()
	{
		Class72.smethod_20();
	}
}
