using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Forms;
using Command_Core.SmartAssembly.Attributes;
using Command.My;

namespace Command;

[DoNotObfuscate]
[DoNotPrune]
[DoNotPruneType]
public sealed class UnitSpeedAltViewModel : CommandViewModel
{
	private ObservableCollection<UnitSpeedAltRadioButtonWrapperViewModel> observableCollection_0;

	private ObservableCollection<UnitSpeedAltRadioButtonWrapperViewModel> observableCollection_1;

	private Visibility visibility_0;

	private Visibility visibility_1;

	private Visibility visibility_2;

	private RelayCommand relayCommand_0;

	private RelayCommand relayCommand_1;

	private bool bool_0;

	private bool bool_1;

	private string string_0;

	private string string_1;

	private Visibility visibility_3;

	private Visibility visibility_4;

	private RelayCommand relayCommand_2;

	private string string_2;

	private RelayCommand relayCommand_3;

	public ObservableCollection<UnitSpeedAltRadioButtonWrapperViewModel> Alts
	{
		get
		{
			return observableCollection_0;
		}
		set
		{
			SetProperty(ref observableCollection_0, value, "Alts");
		}
	}

	public ObservableCollection<UnitSpeedAltRadioButtonWrapperViewModel> Speeds
	{
		get
		{
			return observableCollection_1;
		}
		set
		{
			SetProperty(ref observableCollection_1, value, "Speeds");
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

	public Visibility SpeedVis
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return visibility_1;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			SetProperty(ref visibility_1, value, "SpeedVis");
		}
	}

	public Visibility AltVis
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return visibility_2;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			SetProperty(ref visibility_2, value, "AltVis");
		}
	}

	public RelayCommand ManualSpeedCommand
	{
		get
		{
			return relayCommand_0;
		}
		set
		{
			SetProperty(ref relayCommand_0, value, "ManualSpeedCommand");
		}
	}

	public RelayCommand ManualAltCommand
	{
		get
		{
			return relayCommand_1;
		}
		set
		{
			SetProperty(ref relayCommand_1, value, "ManualAltCommand");
		}
	}

	public bool ManualAltChecked
	{
		get
		{
			return bool_0;
		}
		set
		{
			SetProperty(ref bool_0, value, "ManualAltChecked");
		}
	}

	public bool ManualSpeedChecked
	{
		get
		{
			return bool_1;
		}
		set
		{
			SetProperty(ref bool_1, value, "ManualSpeedChecked");
		}
	}

	public string ManualAltText
	{
		get
		{
			return string_0;
		}
		set
		{
			SetProperty(ref string_0, value, "ManualAltText");
		}
	}

	public string ManualSpeedText
	{
		get
		{
			return string_1;
		}
		set
		{
			SetProperty(ref string_1, value, "ManualSpeedText");
		}
	}

	public Visibility ManualAltVis
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return visibility_3;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			SetProperty(ref visibility_3, value, "ManualAltVis");
		}
	}

	public Visibility ManualSpeedVis
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return visibility_4;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			SetProperty(ref visibility_4, value, "ManualSpeedVis");
		}
	}

	public RelayCommand PreviousWaypointCommand
	{
		get
		{
			return relayCommand_2;
		}
		set
		{
			SetProperty(ref relayCommand_2, value, "PreviousWaypointCommand");
		}
	}

	public string CurrentWaypointString
	{
		get
		{
			return string_2;
		}
		set
		{
			SetProperty(ref string_2, value, "CurrentWaypointString");
		}
	}

	public RelayCommand NextWaypointCommand
	{
		get
		{
			return relayCommand_3;
		}
		set
		{
			SetProperty(ref relayCommand_3, value, "NextWaypointCommand");
		}
	}

	private void method_0()
	{
		MyProject.Forms.SpeedAlt.Button_Previous_Click(null, null);
		Refresh(TriggeredBySpeedAltForm: false);
	}

	private void method_1()
	{
		MyProject.Forms.SpeedAlt.Button_Next_Click(null, null);
		Refresh(TriggeredBySpeedAltForm: false);
	}

	public UnitSpeedAltViewModel(bool TriggeredBySpeedAltForm)
	{
		Alts = new ObservableCollection<UnitSpeedAltRadioButtonWrapperViewModel>(new List<UnitSpeedAltRadioButtonWrapperViewModel>
		{
			new UnitSpeedAltRadioButtonWrapperViewModel(this, MyProject.Forms.SpeedAlt.RB_MaxAltitude, 1, 7),
			new UnitSpeedAltRadioButtonWrapperViewModel(this, MyProject.Forms.SpeedAlt.RB_HighAltitude36000, 1, 6),
			new UnitSpeedAltRadioButtonWrapperViewModel(this, MyProject.Forms.SpeedAlt.RB_HighAltitude25000, 1, 5),
			new UnitSpeedAltRadioButtonWrapperViewModel(this, MyProject.Forms.SpeedAlt.RB_MediumAltitude12000, 1, 4),
			new UnitSpeedAltRadioButtonWrapperViewModel(this, MyProject.Forms.SpeedAlt.RB_LowAltitude2000, 1, 3),
			new UnitSpeedAltRadioButtonWrapperViewModel(this, MyProject.Forms.SpeedAlt.RB_LowAltitude1000, 1, 2),
			new UnitSpeedAltRadioButtonWrapperViewModel(this, MyProject.Forms.SpeedAlt.RB_MinAltitude, 1, 1),
			new UnitSpeedAltRadioButtonWrapperViewModel(this, MyProject.Forms.SpeedAlt.RB_Surface, 2, 6),
			new UnitSpeedAltRadioButtonWrapperViewModel(this, MyProject.Forms.SpeedAlt.RB_Periscope, 2, 1),
			new UnitSpeedAltRadioButtonWrapperViewModel(this, MyProject.Forms.SpeedAlt.RB_Shallow, 2, 2),
			new UnitSpeedAltRadioButtonWrapperViewModel(this, MyProject.Forms.SpeedAlt.RB_OverLayer, 2, 3),
			new UnitSpeedAltRadioButtonWrapperViewModel(this, MyProject.Forms.SpeedAlt.RB_UnderLayer, 2, 4),
			new UnitSpeedAltRadioButtonWrapperViewModel(this, MyProject.Forms.SpeedAlt.RB_MaxDepth, 2, 5)
		});
		Speeds = new ObservableCollection<UnitSpeedAltRadioButtonWrapperViewModel>(new List<UnitSpeedAltRadioButtonWrapperViewModel>
		{
			new UnitSpeedAltRadioButtonWrapperViewModel(this, MyProject.Forms.SpeedAlt.RB_Stop, 0, 0),
			new UnitSpeedAltRadioButtonWrapperViewModel(this, MyProject.Forms.SpeedAlt.RB_Creep, 0, 1),
			new UnitSpeedAltRadioButtonWrapperViewModel(this, MyProject.Forms.SpeedAlt.RB_Cruise, 0, 2),
			new UnitSpeedAltRadioButtonWrapperViewModel(this, MyProject.Forms.SpeedAlt.RB_Full, 0, 3),
			new UnitSpeedAltRadioButtonWrapperViewModel(this, MyProject.Forms.SpeedAlt.RB_Flank, 0, 4)
		});
		Visible = (Visibility)2;
		ManualSpeedCommand = new RelayCommand([SpecialName] (object a0) =>
		{
			method_2();
		});
		ManualAltCommand = new RelayCommand([SpecialName] (object a0) =>
		{
			method_3();
		});
		PreviousWaypointCommand = new RelayCommand([SpecialName] (object a0) =>
		{
			method_0();
		});
		NextWaypointCommand = new RelayCommand([SpecialName] (object a0) =>
		{
			method_1();
		});
		Refresh(TriggeredBySpeedAltForm);
	}

	private void method_2()
	{
		((CheckBox)MyProject.Forms.SpeedAlt.CB_SpeedOverride).Checked = false;
		MyProject.Forms.SpeedAlt.CB_SpeedOverride_Click(null, null);
		Refresh(TriggeredBySpeedAltForm: false);
	}

	private void method_3()
	{
		((CheckBox)MyProject.Forms.SpeedAlt.CB_AltOverride).Checked = false;
		MyProject.Forms.SpeedAlt.CB_AltOverride_Click(null, null);
		Refresh(TriggeredBySpeedAltForm: false);
	}

	public void Refresh(bool TriggeredBySpeedAltForm)
	{
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Invalid comparison between Unknown and I4
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Invalid comparison between Unknown and I4
		if (Client.SelectedUnit == null)
		{
			Visible = (Visibility)2;
			return;
		}
		Visible = (Visibility)0;
		foreach (UnitSpeedAltRadioButtonWrapperViewModel speed in Speeds)
		{
			speed.Refresh();
		}
		foreach (UnitSpeedAltRadioButtonWrapperViewModel alt in Alts)
		{
			alt.Refresh();
		}
		if (Speeds.Any([SpecialName] (UnitSpeedAltRadioButtonWrapperViewModel F) => (int)F.Visible == 0))
		{
			SpeedVis = (Visibility)0;
		}
		else
		{
			SpeedVis = (Visibility)2;
		}
		if (!Alts.Any([SpecialName] (UnitSpeedAltRadioButtonWrapperViewModel F) => (int)F.Visible == 0))
		{
			AltVis = (Visibility)2;
		}
		else
		{
			AltVis = (Visibility)0;
		}
		if (!TriggeredBySpeedAltForm)
		{
			MyProject.Forms.SpeedAlt.RefreshForm(RefreshEvenIfNotVisible: true);
		}
		ManualSpeedChecked = ((CheckBox)MyProject.Forms.SpeedAlt.CB_SpeedOverride).Checked;
		ManualAltChecked = ((CheckBox)MyProject.Forms.SpeedAlt.CB_AltOverride).Checked;
		CurrentWaypointString = ((Label)MyProject.Forms.SpeedAlt.Label_SettingsFor).Text;
		if (!ManualSpeedChecked)
		{
			ManualSpeedVis = (Visibility)1;
			ManualSpeedText = "";
		}
		else
		{
			ManualSpeedVis = (Visibility)0;
			ManualSpeedText = "Manual - Set Auto";
		}
		if (ManualAltChecked)
		{
			ManualAltVis = (Visibility)0;
			ManualAltText = "Manual - Set Auto";
		}
		else
		{
			ManualAltVis = (Visibility)1;
			ManualAltText = "";
		}
		if ((int)AltVis == 2)
		{
			ManualAltVis = (Visibility)2;
		}
		if ((int)SpeedVis == 2)
		{
			ManualSpeedVis = (Visibility)2;
		}
	}

	static UnitSpeedAltViewModel()
	{
		Class72.smethod_20();
	}
}
