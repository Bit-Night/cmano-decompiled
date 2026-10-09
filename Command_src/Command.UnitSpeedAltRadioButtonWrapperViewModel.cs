using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Forms;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using Command.My;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotPrune]
[DoNotObfuscate]
[DoNotPruneType]
public sealed class UnitSpeedAltRadioButtonWrapperViewModel : CommandViewModel
{
	private DarkRadioButton darkRadioButton_0;

	private UnitSpeedAltViewModel unitSpeedAltViewModel_0;

	private string string_0;

	private RelayCommand relayCommand_0;

	private Visibility visibility_0;

	private bool bool_0;

	private bool bool_1;

	private byte byte_0;

	private byte byte_1;

	public string Content
	{
		get
		{
			return string_0;
		}
		set
		{
			SetProperty(ref string_0, value, "Content");
		}
	}

	public RelayCommand Command
	{
		get
		{
			return relayCommand_0;
		}
		set
		{
			SetProperty(ref relayCommand_0, value, "Command");
		}
	}

	public Visibility Visible
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return visibility_0;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			SetProperty(ref visibility_0, value, "Visible");
		}
	}

	public bool Enabled
	{
		get
		{
			return bool_0;
		}
		set
		{
			SetProperty(ref bool_0, value, "Enabled");
		}
	}

	public bool Checked
	{
		get
		{
			return bool_1;
		}
		set
		{
			SetProperty(ref bool_1, value, "Checked");
		}
	}

	private void method_0()
	{
		if (!MyProject.Forms.MainForm.Realtime)
		{
			((RadioButton)darkRadioButton_0).Checked = true;
			if (Operators.CompareString(((Control)darkRadioButton_0).Parent.Name, "GroupBox_SpeedPresets", true) != 0)
			{
				if (MyProject.Forms.SpeedAlt.SpeedAlt_SelectedUnit == null)
				{
					MyProject.Forms.SpeedAlt.SpeedAlt_SelectedUnit = (ActiveUnit)Client.SelectedUnit;
				}
				switch (byte_0)
				{
				case 0:
					MyProject.Forms.SpeedAlt.SetThrottlePreset((ActiveUnit_Kinematics.UnitThrottlePreset)byte_1, darkRadioButton_0);
					break;
				case 1:
					MyProject.Forms.SpeedAlt.SetAltitudePreset((ActiveUnit_AI.AircraftAltitudePreset)byte_1);
					break;
				case 2:
					MyProject.Forms.SpeedAlt.SetDepthPreset((ActiveUnit_AI.SubmarineDepthPreset)byte_1);
					break;
				}
				unitSpeedAltViewModel_0.Refresh(TriggeredBySpeedAltForm: false);
			}
			return;
		}
		if (Client.SelectedUnit == null && MyProject.Forms.SpeedAlt.SpeedAlt_SelectedUnit != null)
		{
			Client.SelectThisUnit(MyProject.Forms.SpeedAlt.SpeedAlt_SelectedUnit, ThisUnitOnly: true);
		}
		if (Client.SelectedUnit != null)
		{
			switch (byte_0)
			{
			case 0:
				MyProject.Forms.MainForm.RealtimeTerminal.SendThrottleAltUI(Client.SelectedUnit.ObjectID, MyProject.Forms.MainForm.SelectedCourseWaypointID, "", null, byte_1);
				break;
			case 1:
				MyProject.Forms.MainForm.RealtimeTerminal.SendThrottleAltUI(Client.SelectedUnit.ObjectID, MyProject.Forms.MainForm.SelectedCourseWaypointID, "", null, null, byte_1);
				break;
			case 2:
				MyProject.Forms.MainForm.RealtimeTerminal.SendThrottleAltUI(Client.SelectedUnit.ObjectID, MyProject.Forms.MainForm.SelectedCourseWaypointID, "", null, null, null, byte_1);
				break;
			}
		}
	}

	public UnitSpeedAltRadioButtonWrapperViewModel(UnitSpeedAltViewModel UnitSpeedAltViewModel, DarkRadioButton RadioButton, byte EnumType, byte EnumByte)
	{
		byte_1 = EnumByte;
		byte_0 = EnumType;
		Command = new RelayCommand([SpecialName] (object a0) =>
		{
			method_0();
		});
		darkRadioButton_0 = RadioButton;
		unitSpeedAltViewModel_0 = UnitSpeedAltViewModel;
		Refresh();
	}

	public void Refresh()
	{
		Content = ((ButtonBase)darkRadioButton_0).Text;
		Checked = ((RadioButton)darkRadioButton_0).Checked;
		if (((Control)darkRadioButton_0).Parent.Enabled)
		{
			Visible = (Visibility)0;
		}
		else
		{
			Visible = (Visibility)2;
		}
		Enabled = ((Control)darkRadioButton_0).Enabled;
	}

	static UnitSpeedAltRadioButtonWrapperViewModel()
	{
		Class72.smethod_20();
	}
}
