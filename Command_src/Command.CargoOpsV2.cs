using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
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
public class CargoOpsV2 : DarkSecondaryFormBase, GInterface0
{
	protected enum CargoOpsMode
	{
		SingleUnitDisplay,
		SingleUnitUnloadToMap,
		SingleUnitTransferToNearbyUnits,
		HostUnitAndHostedUnit,
		SingleUnitPickupFromMap
	}

	protected class CargoMovementRecord
	{
		public Cargo cargo;

		public ActiveUnit source;

		public ActiveUnit destination;

		static CargoMovementRecord()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonConfirm")]
	private DarkUIButton _ButtonConfirm;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonCancel")]
	private DarkUIButton _ButtonCancel;

	[AccessedThroughProperty("DestinationCargoGridView")]
	[CompilerGenerated]
	private DarkDataGridView _DestinationCargoGridView;

	[CompilerGenerated]
	[AccessedThroughProperty("UnitCargoGridView")]
	private DarkDataGridView _UnitCargoGridView;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonUnloadOne")]
	private DarkUIButton _ButtonUnloadOne;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonUnloadAll")]
	private DarkUIButton _ButtonUnloadAll;

	[AccessedThroughProperty("ButtonLoadAll")]
	[CompilerGenerated]
	private DarkUIButton _ButtonLoadAll;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonLoadOne")]
	private DarkUIButton _ButtonLoadOne;

	[AccessedThroughProperty("ButtonUnloadMode")]
	[CompilerGenerated]
	private DarkUIButton _ButtonUnloadMode;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonTransferMode")]
	private DarkUIButton _ButtonTransferMode;

	[AccessedThroughProperty("ButtonContainerMode")]
	[CompilerGenerated]
	private DarkUIButton _ButtonContainerMode;

	[AccessedThroughProperty("Check_GroupByUnitType")]
	[CompilerGenerated]
	private DarkUICheckBox _Check_GroupByUnitType;

	[CompilerGenerated]
	[AccessedThroughProperty("ComboAircraftLoadout")]
	private DarkUIComboBox _ComboAircraftLoadout;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonPickupMode")]
	private DarkUIButton _ButtonPickupMode;

	public ActiveUnit HostUnit;

	public ActiveUnit CargoUnit;

	protected ActiveUnit SelectedHostUnit;

	protected CargoOpsMode Mode;

	protected bool GroupUnitsByType;

	protected float CargoUnitAvailableMass;

	protected float CargoUnitAvailableArea;

	protected float CargoUnitAvailableCrew;

	protected float HostUnitAvailableMass;

	protected float HostUnitAvailableArea;

	protected float HostUnitAvailableCrew;

	protected List<Cargo> CargoUnitWorkingCargoList;

	protected List<Cargo> HostUnitWorkingCargoList;

	protected List<Loadout> PossibleAircraftLoadouts;

	protected Loadout SelectedAircraftLoadout;

	protected List<CargoMovementRecord> CargoActions;

	protected int MarginWidth;

	protected int FormBorderWidth;

	[CompilerGenerated]
	private bool bool_2;

	protected bool RTMP;

	private int int_0;

	[field: AccessedThroughProperty("HostPanel")]
	internal virtual DarkSectionPanel HostPanel { get; set; }

	[field: AccessedThroughProperty("HostCrewBar")]
	internal virtual DarkUIProgressBar HostCrewBar { get; set; }

	[field: AccessedThroughProperty("HostAreaBar")]
	internal virtual DarkUIProgressBar HostAreaBar { get; set; }

	[field: AccessedThroughProperty("HostMassBar")]
	internal virtual DarkUIProgressBar HostMassBar { get; set; }

	[field: AccessedThroughProperty("TargetPanel")]
	internal virtual DarkSectionPanel TargetPanel { get; set; }

	[field: AccessedThroughProperty("TargetCrewBar")]
	internal virtual DarkUIProgressBar TargetCrewBar { get; set; }

	[field: AccessedThroughProperty("TargetAreaBar")]
	internal virtual DarkUIProgressBar TargetAreaBar { get; set; }

	[field: AccessedThroughProperty("TargetMassBar")]
	internal virtual DarkUIProgressBar TargetMassBar { get; set; }

	internal virtual DarkUIButton ButtonConfirm
	{
		[CompilerGenerated]
		get
		{
			return _ButtonConfirm;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_10;
			DarkUIButton darkUIButton = _ButtonConfirm;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonConfirm = value;
			darkUIButton = _ButtonConfirm;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton ButtonCancel
	{
		[CompilerGenerated]
		get
		{
			return _ButtonCancel;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_11;
			DarkUIButton darkUIButton = _ButtonCancel;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonCancel = value;
			darkUIButton = _ButtonCancel;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkDataGridView DestinationCargoGridView
	{
		[CompilerGenerated]
		get
		{
			return _DestinationCargoGridView;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_24;
			DarkDataGridView darkDataGridView = _DestinationCargoGridView;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).SelectionChanged -= eventHandler;
			}
			_DestinationCargoGridView = value;
			darkDataGridView = _DestinationCargoGridView;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).SelectionChanged += eventHandler;
			}
		}
	}

	internal virtual DarkDataGridView UnitCargoGridView
	{
		[CompilerGenerated]
		get
		{
			return _UnitCargoGridView;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_23;
			DarkDataGridView darkDataGridView = _UnitCargoGridView;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).SelectionChanged -= eventHandler;
			}
			_UnitCargoGridView = value;
			darkDataGridView = _UnitCargoGridView;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).SelectionChanged += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton ButtonUnloadOne
	{
		[CompilerGenerated]
		get
		{
			return _ButtonUnloadOne;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_21;
			DarkUIButton darkUIButton = _ButtonUnloadOne;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonUnloadOne = value;
			darkUIButton = _ButtonUnloadOne;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton ButtonUnloadAll
	{
		[CompilerGenerated]
		get
		{
			return _ButtonUnloadAll;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_22;
			DarkUIButton darkUIButton = _ButtonUnloadAll;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonUnloadAll = value;
			darkUIButton = _ButtonUnloadAll;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton ButtonLoadAll
	{
		[CompilerGenerated]
		get
		{
			return _ButtonLoadAll;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_19;
			DarkUIButton darkUIButton = _ButtonLoadAll;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonLoadAll = value;
			darkUIButton = _ButtonLoadAll;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton ButtonLoadOne
	{
		[CompilerGenerated]
		get
		{
			return _ButtonLoadOne;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_20;
			DarkUIButton darkUIButton = _ButtonLoadOne;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonLoadOne = value;
			darkUIButton = _ButtonLoadOne;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton ButtonUnloadMode
	{
		[CompilerGenerated]
		get
		{
			return _ButtonUnloadMode;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_13;
			DarkUIButton darkUIButton = _ButtonUnloadMode;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonUnloadMode = value;
			darkUIButton = _ButtonUnloadMode;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton ButtonTransferMode
	{
		[CompilerGenerated]
		get
		{
			return _ButtonTransferMode;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_15;
			DarkUIButton darkUIButton = _ButtonTransferMode;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonTransferMode = value;
			darkUIButton = _ButtonTransferMode;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton ButtonContainerMode
	{
		[CompilerGenerated]
		get
		{
			return _ButtonContainerMode;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = qllPubeVf4;
			DarkUIButton darkUIButton = _ButtonContainerMode;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonContainerMode = value;
			darkUIButton = _ButtonContainerMode;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUICheckBox Check_GroupByUnitType
	{
		[CompilerGenerated]
		get
		{
			return _Check_GroupByUnitType;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_12;
			DarkUICheckBox darkUICheckBox = _Check_GroupByUnitType;
			if (darkUICheckBox != null)
			{
				((CheckBox)darkUICheckBox).CheckedChanged -= eventHandler;
			}
			_Check_GroupByUnitType = value;
			darkUICheckBox = _Check_GroupByUnitType;
			if (darkUICheckBox != null)
			{
				((CheckBox)darkUICheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("HostSizeLabel")]
	internal virtual DarkLabel HostSizeLabel { get; set; }

	[field: AccessedThroughProperty("TargetSizeLabel")]
	internal virtual DarkLabel TargetSizeLabel { get; set; }

	[field: AccessedThroughProperty("HostColName")]
	internal virtual DataGridViewTextBoxColumn HostColName { get; set; }

	[field: AccessedThroughProperty("HostColSize")]
	internal virtual DataGridViewTextBoxColumn HostColSize { get; set; }

	[field: AccessedThroughProperty("HostColMass")]
	internal virtual DataGridViewTextBoxColumn HostColMass { get; set; }

	[field: AccessedThroughProperty("HostColArea")]
	internal virtual DataGridViewTextBoxColumn HostColArea { get; set; }

	[field: AccessedThroughProperty("HostColCrew")]
	internal virtual DataGridViewTextBoxColumn HostColCrew { get; set; }

	[field: AccessedThroughProperty("TargetColName")]
	internal virtual DataGridViewTextBoxColumn TargetColName { get; set; }

	[field: AccessedThroughProperty("TargetColSize")]
	internal virtual DataGridViewTextBoxColumn TargetColSize { get; set; }

	[field: AccessedThroughProperty("TargetColMass")]
	internal virtual DataGridViewTextBoxColumn TargetColMass { get; set; }

	[field: AccessedThroughProperty("TargetColArea")]
	internal virtual DataGridViewTextBoxColumn TargetColArea { get; set; }

	[field: AccessedThroughProperty("TargetColPax")]
	internal virtual DataGridViewTextBoxColumn TargetColPax { get; set; }

	internal virtual DarkUIComboBox ComboAircraftLoadout
	{
		[CompilerGenerated]
		get
		{
			return _ComboAircraftLoadout;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_26;
			DarkUIComboBox darkUIComboBox = _ComboAircraftLoadout;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged -= eventHandler;
			}
			_ComboAircraftLoadout = value;
			darkUIComboBox = _ComboAircraftLoadout;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("LabelAircraftLoadout")]
	internal virtual DarkLabel LabelAircraftLoadout { get; set; }

	internal virtual DarkUIButton ButtonPickupMode
	{
		[CompilerGenerated]
		get
		{
			return _ButtonPickupMode;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_14;
			DarkUIButton darkUIButton = _ButtonPickupMode;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonPickupMode = value;
			darkUIButton = _ButtonPickupMode;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
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

	public bool TransferModeEnable
	{
		get
		{
			if (CargoUnit != null)
			{
				if (CargoUnit.IsFixedFacility)
				{
					return true;
				}
				return CargoUnit.IsVehicle;
			}
			return false;
		}
	}

	public bool UnloadModeEnable
	{
		get
		{
			if (CargoUnit == null)
			{
				return false;
			}
			return CargoUnit.HasCargo;
		}
	}

	public bool PickupModeEnabled
	{
		get
		{
			int result2;
			if (!CargoUnit.IsAircraft)
			{
				if (CargoUnit.IsShip)
				{
					int result;
					if (CargoUnit.DockingOps.CanUnloadCargoOverBeach())
					{
						result = 1;
					}
					else
					{
						if (CargoUnit.GetHostedUnitsThatCanBeLoadedAsCargo().Count <= 0)
						{
							goto IL_007d;
						}
						result = 1;
					}
					return (byte)result != 0;
				}
				if (!CargoUnit.IsVehicle && !CargoUnit.IsFixedFacility)
				{
					result2 = 0;
					goto IL_007e;
				}
				return true;
			}
			if (((Aircraft)CargoUnit).IsHelicopter)
			{
				return true;
			}
			goto IL_007d;
			IL_007e:
			return (byte)result2 != 0;
			IL_007d:
			result2 = 0;
			goto IL_007e;
		}
	}

	public bool ContainerModeEnable
	{
		get
		{
			if (CargoUnit != null && CargoUnit.IsFixedFacility && ((BaseCollection)((DataGridView)UnitCargoGridView).SelectedRows).Count > 0 && ((DataGridViewBand)((DataGridView)UnitCargoGridView).SelectedRows[0]).Tag != null)
			{
				if (((DataGridViewBand)((DataGridView)UnitCargoGridView).SelectedRows[0]).Tag is Cargo)
				{
					return ((Cargo)((DataGridViewBand)((DataGridView)UnitCargoGridView).SelectedRows[0]).Tag).CurrentType == Cargo.CargoObjectType.CargoContainer;
				}
				if (((DataGridViewBand)((DataGridView)UnitCargoGridView).SelectedRows[0]).Tag is CargoManifestItem)
				{
					return ((CargoManifestItem)((DataGridViewBand)((DataGridView)UnitCargoGridView).SelectedRows[0]).Tag).objectType == Cargo.CargoObjectType.CargoContainer;
				}
			}
			return false;
		}
	}

	public bool LoadingButtonsEnable
	{
		get
		{
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Expected O, but got Unknown
			if (((BaseCollection)((DataGridView)DestinationCargoGridView).SelectedRows).Count > 0)
			{
				foreach (DataGridViewRow item in (BaseCollection)((DataGridView)DestinationCargoGridView).SelectedRows)
				{
					DataGridViewRow val = item;
					if (((DataGridViewBand)val).Tag != null && !(((DataGridViewBand)val).Tag is ActiveUnit))
					{
						return true;
					}
				}
			}
			return false;
		}
	}

	public bool UnloadingButtonsEnable
	{
		get
		{
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Expected O, but got Unknown
			if (((BaseCollection)((DataGridView)UnitCargoGridView).SelectedRows).Count > 0)
			{
				foreach (DataGridViewRow item in (BaseCollection)((DataGridView)UnitCargoGridView).SelectedRows)
				{
					DataGridViewRow val = item;
					if (((DataGridViewBand)val).Tag != null && !(((DataGridViewBand)val).Tag is ActiveUnit))
					{
						return true;
					}
				}
			}
			return false;
		}
	}

	public CargoOpsV2()
	{
		((Form)this).Load += CargoOpsV2_Load;
		Mode = CargoOpsMode.SingleUnitDisplay;
		GroupUnitsByType = false;
		CargoActions = new List<CargoMovementRecord>();
		MarginWidth = 0;
		FormBorderWidth = 0;
		RTMPEnabled = true;
		RTMP = false;
		int_0 = -1;
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
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected O, but got Unknown
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected O, but got Unknown
		//IL_03cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d6: Expected O, but got Unknown
		//IL_0497: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a1: Expected O, but got Unknown
		//IL_0b1d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b27: Expected O, but got Unknown
		//IL_0be6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf0: Expected O, but got Unknown
		//IL_10e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1186: Unknown result type (might be due to invalid IL or missing references)
		//IL_122b: Unknown result type (might be due to invalid IL or missing references)
		//IL_12d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1374: Unknown result type (might be due to invalid IL or missing references)
		//IL_1418: Unknown result type (might be due to invalid IL or missing references)
		//IL_14bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1562: Unknown result type (might be due to invalid IL or missing references)
		//IL_1607: Unknown result type (might be due to invalid IL or missing references)
		//IL_174a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1754: Expected O, but got Unknown
		//IL_1891: Unknown result type (might be due to invalid IL or missing references)
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DataGridViewCellStyle val5 = new DataGridViewCellStyle();
		DataGridViewCellStyle val6 = new DataGridViewCellStyle();
		HostPanel = new DarkSectionPanel();
		HostSizeLabel = new DarkLabel();
		DestinationCargoGridView = new DarkDataGridView();
		HostColName = new DataGridViewTextBoxColumn();
		HostColSize = new DataGridViewTextBoxColumn();
		HostColMass = new DataGridViewTextBoxColumn();
		HostColArea = new DataGridViewTextBoxColumn();
		HostColCrew = new DataGridViewTextBoxColumn();
		HostCrewBar = new DarkUIProgressBar();
		HostAreaBar = new DarkUIProgressBar();
		HostMassBar = new DarkUIProgressBar();
		TargetPanel = new DarkSectionPanel();
		TargetSizeLabel = new DarkLabel();
		UnitCargoGridView = new DarkDataGridView();
		TargetColName = new DataGridViewTextBoxColumn();
		TargetColSize = new DataGridViewTextBoxColumn();
		TargetColMass = new DataGridViewTextBoxColumn();
		TargetColArea = new DataGridViewTextBoxColumn();
		TargetColPax = new DataGridViewTextBoxColumn();
		TargetCrewBar = new DarkUIProgressBar();
		TargetAreaBar = new DarkUIProgressBar();
		TargetMassBar = new DarkUIProgressBar();
		ButtonConfirm = new DarkUIButton();
		ButtonCancel = new DarkUIButton();
		ButtonUnloadOne = new DarkUIButton();
		ButtonUnloadAll = new DarkUIButton();
		ButtonLoadAll = new DarkUIButton();
		ButtonLoadOne = new DarkUIButton();
		ButtonUnloadMode = new DarkUIButton();
		ButtonTransferMode = new DarkUIButton();
		ButtonContainerMode = new DarkUIButton();
		Check_GroupByUnitType = new DarkUICheckBox();
		ComboAircraftLoadout = new DarkUIComboBox();
		LabelAircraftLoadout = new DarkLabel();
		ButtonPickupMode = new DarkUIButton();
		((Control)HostPanel).SuspendLayout();
		((ISupportInitialize)(object)DestinationCargoGridView).BeginInit();
		((Control)TargetPanel).SuspendLayout();
		((ISupportInitialize)(object)UnitCargoGridView).BeginInit();
		((Control)this).SuspendLayout();
		((Control)HostPanel).Anchor = (AnchorStyles)7;
		((Panel)HostPanel).BorderStyle = (BorderStyle)1;
		((Control)HostPanel).Controls.Add((Control)(object)HostSizeLabel);
		((Control)HostPanel).Controls.Add((Control)(object)DestinationCargoGridView);
		((Control)HostPanel).Controls.Add((Control)(object)HostCrewBar);
		((Control)HostPanel).Controls.Add((Control)(object)HostAreaBar);
		((Control)HostPanel).Controls.Add((Control)(object)HostMassBar);
		((Control)HostPanel).Location = new Point(0, 0);
		((Control)HostPanel).Name = "HostPanel";
		HostPanel.SectionHeader = "Host/Destination Cargo";
		((Control)HostPanel).Size = new Size(412, 465);
		((Control)HostPanel).TabIndex = 23;
		((Control)HostSizeLabel).ForeColor = Color.White;
		((Control)HostSizeLabel).Location = new Point(48, 25);
		((Control)HostSizeLabel).Name = "HostSizeLabel";
		((Control)HostSizeLabel).Size = new Size(298, 20);
		((Control)HostSizeLabel).TabIndex = 24;
		((Label)HostSizeLabel).Text = "Max Size:";
		((Label)HostSizeLabel).TextAlign = (ContentAlignment)16;
		((DataGridView)DestinationCargoGridView).AllowUserToAddRows = false;
		((DataGridView)DestinationCargoGridView).AllowUserToDeleteRows = false;
		((DataGridView)DestinationCargoGridView).AllowUserToOrderColumns = true;
		((Control)DestinationCargoGridView).Anchor = (AnchorStyles)15;
		((DataGridView)DestinationCargoGridView).BackgroundColor = Color.FromArgb(60, 63, 65);
		((DataGridView)DestinationCargoGridView).BorderStyle = (BorderStyle)0;
		((DataGridView)DestinationCargoGridView).CellBorderStyle = (DataGridViewCellBorderStyle)8;
		((DataGridView)DestinationCargoGridView).ClipboardCopyMode = (DataGridViewClipboardCopyMode)0;
		((DataGridView)DestinationCargoGridView).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val.Alignment = (DataGridViewContentAlignment)16;
		val.BackColor = Color.FromArgb(66, 77, 95);
		val.Font = new Font("Segoe UI", 9f);
		val.ForeColor = Color.LightGray;
		val.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DestinationCargoGridView).ColumnHeadersDefaultCellStyle = val;
		((DataGridView)DestinationCargoGridView).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		((DataGridView)DestinationCargoGridView).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[5]
		{
			(DataGridViewColumn)HostColName,
			(DataGridViewColumn)HostColSize,
			(DataGridViewColumn)HostColMass,
			(DataGridViewColumn)HostColArea,
			(DataGridViewColumn)HostColCrew
		});
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = Color.FromArgb(60, 63, 65);
		val2.Font = new Font("Segoe UI", 9f);
		val2.ForeColor = Color.LightGray;
		val2.SelectionBackColor = SystemColors.Highlight;
		val2.SelectionForeColor = SystemColors.HighlightText;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DestinationCargoGridView).DefaultCellStyle = val2;
		((DataGridView)DestinationCargoGridView).EnableHeadersVisualStyles = false;
		((Control)DestinationCargoGridView).Location = new Point(0, 126);
		((Control)DestinationCargoGridView).Name = "DestinationCargoGridView";
		((DataGridView)DestinationCargoGridView).ReadOnly = true;
		((DataGridView)DestinationCargoGridView).RowHeadersVisible = false;
		((DataGridView)DestinationCargoGridView).RowHeadersWidth = 51;
		val3.BackColor = Color.FromArgb(60, 63, 65);
		val3.ForeColor = Color.LightGray;
		val3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val3.SelectionForeColor = Color.LightGray;
		((DataGridView)DestinationCargoGridView).RowsDefaultCellStyle = val3;
		((DataGridView)DestinationCargoGridView).SelectionMode = (DataGridViewSelectionMode)1;
		((Control)DestinationCargoGridView).Size = new Size(412, 353);
		((Control)DestinationCargoGridView).TabIndex = 23;
		((DataGridViewColumn)HostColName).HeaderText = "Name";
		((DataGridViewColumn)HostColName).MinimumWidth = 6;
		((DataGridViewColumn)HostColName).Name = "HostColName";
		((DataGridViewColumn)HostColName).ReadOnly = true;
		HostColName.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)HostColName).Width = 192;
		((DataGridViewColumn)HostColSize).HeaderText = "Size";
		((DataGridViewColumn)HostColSize).MinimumWidth = 6;
		((DataGridViewColumn)HostColSize).Name = "HostColSize";
		((DataGridViewColumn)HostColSize).ReadOnly = true;
		((DataGridViewColumn)HostColSize).Width = 64;
		((DataGridViewColumn)HostColMass).HeaderText = "Mass";
		((DataGridViewColumn)HostColMass).MinimumWidth = 6;
		((DataGridViewColumn)HostColMass).Name = "HostColMass";
		((DataGridViewColumn)HostColMass).ReadOnly = true;
		((DataGridViewColumn)HostColMass).Width = 50;
		((DataGridViewColumn)HostColArea).HeaderText = "Area";
		((DataGridViewColumn)HostColArea).MinimumWidth = 6;
		((DataGridViewColumn)HostColArea).Name = "HostColArea";
		((DataGridViewColumn)HostColArea).ReadOnly = true;
		((DataGridViewColumn)HostColArea).Width = 50;
		((DataGridViewColumn)HostColCrew).HeaderText = "PAX";
		((DataGridViewColumn)HostColCrew).MinimumWidth = 6;
		((DataGridViewColumn)HostColCrew).Name = "HostColCrew";
		((DataGridViewColumn)HostColCrew).ReadOnly = true;
		((DataGridViewColumn)HostColCrew).Width = 36;
		((Control)HostCrewBar).BackColor = Color.Transparent;
		HostCrewBar.CustomForeColor = Color.Transparent;
		((Control)HostCrewBar).Location = new Point(48, 94);
		HostCrewBar.Maximum = 100;
		((Control)HostCrewBar).Name = "HostCrewBar";
		HostCrewBar.ShowProgressLines = false;
		HostCrewBar.ShowProgressValue = false;
		HostCrewBar.ShowText = true;
		((Control)HostCrewBar).Size = new Size(290, 20);
		((Control)HostCrewBar).TabIndex = 22;
		((Control)HostCrewBar).Text = "PAX:";
		HostCrewBar.Value = 0;
		((Control)HostAreaBar).BackColor = Color.Transparent;
		HostAreaBar.CustomForeColor = Color.Transparent;
		((Control)HostAreaBar).Location = new Point(48, 71);
		HostAreaBar.Maximum = 100;
		((Control)HostAreaBar).Name = "HostAreaBar";
		HostAreaBar.ShowProgressLines = false;
		HostAreaBar.ShowProgressValue = false;
		HostAreaBar.ShowText = true;
		((Control)HostAreaBar).Size = new Size(290, 20);
		((Control)HostAreaBar).TabIndex = 21;
		((Control)HostAreaBar).Text = "Area:";
		HostAreaBar.Value = 0;
		((Control)HostMassBar).BackColor = Color.Transparent;
		HostMassBar.CustomForeColor = Color.Transparent;
		((Control)HostMassBar).Location = new Point(48, 48);
		HostMassBar.Maximum = 100;
		((Control)HostMassBar).Name = "HostMassBar";
		HostMassBar.ShowProgressLines = false;
		HostMassBar.ShowProgressValue = false;
		HostMassBar.ShowText = true;
		((Control)HostMassBar).Size = new Size(290, 20);
		((Control)HostMassBar).TabIndex = 20;
		((Control)HostMassBar).Text = "Mass:";
		HostMassBar.Value = 0;
		((Control)TargetPanel).Anchor = (AnchorStyles)7;
		((Panel)TargetPanel).BorderStyle = (BorderStyle)1;
		((Control)TargetPanel).Controls.Add((Control)(object)TargetSizeLabel);
		((Control)TargetPanel).Controls.Add((Control)(object)UnitCargoGridView);
		((Control)TargetPanel).Controls.Add((Control)(object)TargetCrewBar);
		((Control)TargetPanel).Controls.Add((Control)(object)TargetAreaBar);
		((Control)TargetPanel).Controls.Add((Control)(object)TargetMassBar);
		((Control)TargetPanel).Location = new Point(414, 0);
		((Control)TargetPanel).Name = "TargetPanel";
		TargetPanel.SectionHeader = "Selected Unit Cargo";
		((Control)TargetPanel).Size = new Size(412, 465);
		((Control)TargetPanel).TabIndex = 24;
		((Control)TargetSizeLabel).ForeColor = Color.White;
		((Control)TargetSizeLabel).Location = new Point(45, 25);
		((Control)TargetSizeLabel).Name = "TargetSizeLabel";
		((Control)TargetSizeLabel).Size = new Size(298, 20);
		((Control)TargetSizeLabel).TabIndex = 25;
		((Label)TargetSizeLabel).Text = "Max Size:";
		((Label)TargetSizeLabel).TextAlign = (ContentAlignment)16;
		((DataGridView)UnitCargoGridView).AllowUserToAddRows = false;
		((DataGridView)UnitCargoGridView).AllowUserToDeleteRows = false;
		((DataGridView)UnitCargoGridView).AllowUserToOrderColumns = true;
		((Control)UnitCargoGridView).Anchor = (AnchorStyles)15;
		((DataGridView)UnitCargoGridView).BackgroundColor = Color.FromArgb(60, 63, 65);
		((DataGridView)UnitCargoGridView).BorderStyle = (BorderStyle)0;
		((DataGridView)UnitCargoGridView).CellBorderStyle = (DataGridViewCellBorderStyle)8;
		((DataGridView)UnitCargoGridView).ClipboardCopyMode = (DataGridViewClipboardCopyMode)0;
		((DataGridView)UnitCargoGridView).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val4.Alignment = (DataGridViewContentAlignment)16;
		val4.BackColor = Color.FromArgb(66, 77, 95);
		val4.Font = new Font("Segoe UI", 9f);
		val4.ForeColor = Color.LightGray;
		val4.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val4.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val4.WrapMode = (DataGridViewTriState)1;
		((DataGridView)UnitCargoGridView).ColumnHeadersDefaultCellStyle = val4;
		((DataGridView)UnitCargoGridView).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		((DataGridView)UnitCargoGridView).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[5]
		{
			(DataGridViewColumn)TargetColName,
			(DataGridViewColumn)TargetColSize,
			(DataGridViewColumn)TargetColMass,
			(DataGridViewColumn)TargetColArea,
			(DataGridViewColumn)TargetColPax
		});
		val5.Alignment = (DataGridViewContentAlignment)16;
		val5.BackColor = Color.FromArgb(60, 63, 65);
		val5.Font = new Font("Segoe UI", 9f);
		val5.ForeColor = Color.LightGray;
		val5.SelectionBackColor = SystemColors.Highlight;
		val5.SelectionForeColor = SystemColors.HighlightText;
		val5.WrapMode = (DataGridViewTriState)2;
		((DataGridView)UnitCargoGridView).DefaultCellStyle = val5;
		((DataGridView)UnitCargoGridView).EnableHeadersVisualStyles = false;
		((Control)UnitCargoGridView).Location = new Point(0, 126);
		((Control)UnitCargoGridView).Name = "UnitCargoGridView";
		((DataGridView)UnitCargoGridView).ReadOnly = true;
		((DataGridView)UnitCargoGridView).RowHeadersVisible = false;
		((DataGridView)UnitCargoGridView).RowHeadersWidth = 51;
		val6.BackColor = Color.FromArgb(60, 63, 65);
		val6.ForeColor = Color.LightGray;
		val6.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val6.SelectionForeColor = Color.LightGray;
		((DataGridView)UnitCargoGridView).RowsDefaultCellStyle = val6;
		((DataGridView)UnitCargoGridView).SelectionMode = (DataGridViewSelectionMode)1;
		((Control)UnitCargoGridView).Size = new Size(412, 353);
		((Control)UnitCargoGridView).TabIndex = 24;
		((DataGridViewColumn)TargetColName).HeaderText = "Name";
		((DataGridViewColumn)TargetColName).MinimumWidth = 6;
		((DataGridViewColumn)TargetColName).Name = "TargetColName";
		((DataGridViewColumn)TargetColName).ReadOnly = true;
		TargetColName.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)TargetColName).Width = 192;
		((DataGridViewColumn)TargetColSize).HeaderText = "Size";
		((DataGridViewColumn)TargetColSize).MinimumWidth = 6;
		((DataGridViewColumn)TargetColSize).Name = "TargetColSize";
		((DataGridViewColumn)TargetColSize).ReadOnly = true;
		((DataGridViewColumn)TargetColSize).Width = 64;
		((DataGridViewColumn)TargetColMass).HeaderText = "Mass";
		((DataGridViewColumn)TargetColMass).MinimumWidth = 6;
		((DataGridViewColumn)TargetColMass).Name = "TargetColMass";
		((DataGridViewColumn)TargetColMass).ReadOnly = true;
		((DataGridViewColumn)TargetColMass).Width = 50;
		((DataGridViewColumn)TargetColArea).HeaderText = "Area";
		((DataGridViewColumn)TargetColArea).MinimumWidth = 6;
		((DataGridViewColumn)TargetColArea).Name = "TargetColArea";
		((DataGridViewColumn)TargetColArea).ReadOnly = true;
		((DataGridViewColumn)TargetColArea).Width = 50;
		((DataGridViewColumn)TargetColPax).HeaderText = "PAX";
		((DataGridViewColumn)TargetColPax).MinimumWidth = 6;
		((DataGridViewColumn)TargetColPax).Name = "TargetColPax";
		((DataGridViewColumn)TargetColPax).ReadOnly = true;
		((DataGridViewColumn)TargetColPax).Width = 36;
		((Control)TargetCrewBar).BackColor = Color.Transparent;
		TargetCrewBar.CustomForeColor = Color.Transparent;
		((Control)TargetCrewBar).Location = new Point(48, 94);
		TargetCrewBar.Maximum = 100;
		((Control)TargetCrewBar).Name = "TargetCrewBar";
		TargetCrewBar.ShowProgressLines = false;
		TargetCrewBar.ShowProgressValue = false;
		TargetCrewBar.ShowText = true;
		((Control)TargetCrewBar).Size = new Size(290, 20);
		((Control)TargetCrewBar).TabIndex = 22;
		((Control)TargetCrewBar).Text = "PAX:";
		TargetCrewBar.Value = 0;
		((Control)TargetAreaBar).BackColor = Color.Transparent;
		TargetAreaBar.CustomForeColor = Color.Transparent;
		((Control)TargetAreaBar).Location = new Point(48, 71);
		TargetAreaBar.Maximum = 100;
		((Control)TargetAreaBar).Name = "TargetAreaBar";
		TargetAreaBar.ShowProgressLines = false;
		TargetAreaBar.ShowProgressValue = false;
		TargetAreaBar.ShowText = true;
		((Control)TargetAreaBar).Size = new Size(290, 20);
		((Control)TargetAreaBar).TabIndex = 21;
		((Control)TargetAreaBar).Text = "Area:";
		TargetAreaBar.Value = 0;
		((Control)TargetMassBar).BackColor = Color.Transparent;
		TargetMassBar.CustomForeColor = Color.Transparent;
		((Control)TargetMassBar).Location = new Point(48, 48);
		TargetMassBar.Maximum = 100;
		((Control)TargetMassBar).Name = "TargetMassBar";
		TargetMassBar.ShowProgressLines = false;
		TargetMassBar.ShowProgressValue = false;
		TargetMassBar.ShowText = true;
		((Control)TargetMassBar).Size = new Size(290, 20);
		((Control)TargetMassBar).TabIndex = 20;
		((Control)TargetMassBar).Text = "Mass:";
		TargetMassBar.Value = 0;
		((Control)ButtonConfirm).Anchor = (AnchorStyles)14;
		((ButtonBase)ButtonConfirm).BackColor = Color.Transparent;
		((Control)ButtonConfirm).ForeColor = SystemColors.Control;
		((Control)ButtonConfirm).Location = new Point(310, 505);
		((Control)ButtonConfirm).Name = "ButtonConfirm";
		((Control)ButtonConfirm).Padding = new Padding(5);
		ButtonConfirm.RoundRadius = 0;
		((Control)ButtonConfirm).Size = new Size(91, 23);
		((Control)ButtonConfirm).TabIndex = 29;
		ButtonConfirm.Text = "Confirm";
		((Control)ButtonCancel).Anchor = (AnchorStyles)14;
		((ButtonBase)ButtonCancel).BackColor = Color.Transparent;
		((Control)ButtonCancel).ForeColor = SystemColors.Control;
		((Control)ButtonCancel).Location = new Point(426, 505);
		((Control)ButtonCancel).Name = "ButtonCancel";
		((Control)ButtonCancel).Padding = new Padding(5);
		ButtonCancel.RoundRadius = 0;
		((Control)ButtonCancel).Size = new Size(91, 23);
		((Control)ButtonCancel).TabIndex = 30;
		ButtonCancel.Text = "Cancel";
		((Control)ButtonUnloadOne).Anchor = (AnchorStyles)10;
		((ButtonBase)ButtonUnloadOne).BackColor = Color.Transparent;
		((Control)ButtonUnloadOne).ForeColor = SystemColors.Control;
		((Control)ButtonUnloadOne).Location = new Point(534, 476);
		((Control)ButtonUnloadOne).Name = "ButtonUnloadOne";
		((Control)ButtonUnloadOne).Padding = new Padding(5);
		ButtonUnloadOne.RoundRadius = 0;
		((Control)ButtonUnloadOne).Size = new Size(91, 23);
		((Control)ButtonUnloadOne).TabIndex = 32;
		ButtonUnloadOne.Text = "< Unload One";
		((Control)ButtonUnloadAll).Anchor = (AnchorStyles)10;
		((ButtonBase)ButtonUnloadAll).BackColor = Color.Transparent;
		((Control)ButtonUnloadAll).ForeColor = SystemColors.Control;
		((Control)ButtonUnloadAll).Location = new Point(437, 476);
		((Control)ButtonUnloadAll).Name = "ButtonUnloadAll";
		((Control)ButtonUnloadAll).Padding = new Padding(5);
		ButtonUnloadAll.RoundRadius = 0;
		((Control)ButtonUnloadAll).Size = new Size(91, 23);
		((Control)ButtonUnloadAll).TabIndex = 31;
		ButtonUnloadAll.Text = "<< Unload All";
		((Control)ButtonLoadAll).Anchor = (AnchorStyles)6;
		((ButtonBase)ButtonLoadAll).BackColor = Color.Transparent;
		((Control)ButtonLoadAll).ForeColor = SystemColors.Control;
		((Control)ButtonLoadAll).Location = new Point(298, 476);
		((Control)ButtonLoadAll).Name = "ButtonLoadAll";
		((Control)ButtonLoadAll).Padding = new Padding(5);
		ButtonLoadAll.RoundRadius = 0;
		((Control)ButtonLoadAll).Size = new Size(91, 23);
		((Control)ButtonLoadAll).TabIndex = 30;
		ButtonLoadAll.Text = "Load All >>";
		((Control)ButtonLoadOne).Anchor = (AnchorStyles)6;
		((ButtonBase)ButtonLoadOne).BackColor = Color.Transparent;
		((Control)ButtonLoadOne).ForeColor = SystemColors.Control;
		((Control)ButtonLoadOne).Location = new Point(201, 475);
		((Control)ButtonLoadOne).Name = "ButtonLoadOne";
		((Control)ButtonLoadOne).Padding = new Padding(5);
		ButtonLoadOne.RoundRadius = 0;
		((Control)ButtonLoadOne).Size = new Size(91, 23);
		((Control)ButtonLoadOne).TabIndex = 29;
		ButtonLoadOne.Text = "Load One >";
		((Control)ButtonUnloadMode).Anchor = (AnchorStyles)10;
		((ButtonBase)ButtonUnloadMode).BackColor = Color.Transparent;
		((Control)ButtonUnloadMode).ForeColor = SystemColors.Control;
		((Control)ButtonUnloadMode).Location = new Point(623, 505);
		((Control)ButtonUnloadMode).Name = "ButtonUnloadMode";
		((Control)ButtonUnloadMode).Padding = new Padding(5);
		ButtonUnloadMode.RoundRadius = 0;
		((Control)ButtonUnloadMode).Size = new Size(96, 23);
		((Control)ButtonUnloadMode).TabIndex = 34;
		ButtonUnloadMode.Text = "Unload Cargo";
		((Control)ButtonTransferMode).Anchor = (AnchorStyles)10;
		((ButtonBase)ButtonTransferMode).BackColor = Color.Transparent;
		((Control)ButtonTransferMode).ForeColor = SystemColors.Control;
		((Control)ButtonTransferMode).Location = new Point(523, 505);
		((Control)ButtonTransferMode).Name = "ButtonTransferMode";
		((Control)ButtonTransferMode).Padding = new Padding(5);
		ButtonTransferMode.RoundRadius = 0;
		((Control)ButtonTransferMode).Size = new Size(96, 23);
		((Control)ButtonTransferMode).TabIndex = 35;
		ButtonTransferMode.Text = "Transfer Cargo";
		((Control)ButtonContainerMode).Anchor = (AnchorStyles)10;
		((ButtonBase)ButtonContainerMode).BackColor = Color.Transparent;
		((Control)ButtonContainerMode).ForeColor = SystemColors.Control;
		((Control)ButtonContainerMode).Location = new Point(423, 505);
		((Control)ButtonContainerMode).Name = "ButtonContainerMode";
		((Control)ButtonContainerMode).Padding = new Padding(5);
		ButtonContainerMode.RoundRadius = 0;
		((Control)ButtonContainerMode).Size = new Size(96, 23);
		((Control)ButtonContainerMode).TabIndex = 36;
		ButtonContainerMode.Text = "Container...";
		((Control)Check_GroupByUnitType).Anchor = (AnchorStyles)10;
		((ButtonBase)Check_GroupByUnitType).BackColor = Color.Transparent;
		((Control)Check_GroupByUnitType).Cursor = Cursors.Hand;
		((Control)Check_GroupByUnitType).ForeColor = Color.FromArgb(209, 209, 209);
		((Control)Check_GroupByUnitType).Location = new Point(689, 477);
		((Control)Check_GroupByUnitType).Name = "Check_GroupByUnitType";
		((Control)Check_GroupByUnitType).Size = new Size(132, 18);
		((Control)Check_GroupByUnitType).TabIndex = 37;
		((ButtonBase)Check_GroupByUnitType).Text = "Group by Unit Type";
		((Control)ComboAircraftLoadout).Anchor = (AnchorStyles)10;
		((ComboBox)ComboAircraftLoadout).BackColor = Color.FromArgb(60, 63, 65);
		((ComboBox)ComboAircraftLoadout).DrawMode = (DrawMode)1;
		((ComboBox)ComboAircraftLoadout).DropDownStyle = (ComboBoxStyle)2;
		((Control)ComboAircraftLoadout).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)ComboAircraftLoadout).FormattingEnabled = true;
		((Control)ComboAircraftLoadout).Location = new Point(638, 505);
		((Control)ComboAircraftLoadout).Name = "ComboAircraftLoadout";
		((Control)ComboAircraftLoadout).Size = new Size(183, 21);
		((Control)ComboAircraftLoadout).TabIndex = 38;
		((Control)LabelAircraftLoadout).Anchor = (AnchorStyles)10;
		((Control)LabelAircraftLoadout).ForeColor = Color.White;
		((Control)LabelAircraftLoadout).Location = new Point(546, 505);
		((Control)LabelAircraftLoadout).Name = "LabelAircraftLoadout";
		((Control)LabelAircraftLoadout).Size = new Size(86, 20);
		((Control)LabelAircraftLoadout).TabIndex = 39;
		((Label)LabelAircraftLoadout).Text = "Loadout:";
		((Label)LabelAircraftLoadout).TextAlign = (ContentAlignment)64;
		((Control)ButtonPickupMode).Anchor = (AnchorStyles)10;
		((ButtonBase)ButtonPickupMode).BackColor = Color.Transparent;
		((Control)ButtonPickupMode).ForeColor = SystemColors.Control;
		((Control)ButtonPickupMode).Location = new Point(723, 505);
		((Control)ButtonPickupMode).Name = "ButtonPickupMode";
		((Control)ButtonPickupMode).Padding = new Padding(5);
		ButtonPickupMode.RoundRadius = 0;
		((Control)ButtonPickupMode).Size = new Size(96, 23);
		((Control)ButtonPickupMode).TabIndex = 40;
		ButtonPickupMode.Text = "Pickup Units";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(7f, 15f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(827, 535);
		((Control)this).Controls.Add((Control)(object)ButtonPickupMode);
		((Control)this).Controls.Add((Control)(object)LabelAircraftLoadout);
		((Control)this).Controls.Add((Control)(object)ComboAircraftLoadout);
		((Control)this).Controls.Add((Control)(object)ButtonUnloadOne);
		((Control)this).Controls.Add((Control)(object)Check_GroupByUnitType);
		((Control)this).Controls.Add((Control)(object)ButtonUnloadAll);
		((Control)this).Controls.Add((Control)(object)ButtonContainerMode);
		((Control)this).Controls.Add((Control)(object)ButtonLoadOne);
		((Control)this).Controls.Add((Control)(object)ButtonLoadAll);
		((Control)this).Controls.Add((Control)(object)ButtonTransferMode);
		((Control)this).Controls.Add((Control)(object)ButtonUnloadMode);
		((Control)this).Controls.Add((Control)(object)ButtonCancel);
		((Control)this).Controls.Add((Control)(object)ButtonConfirm);
		((Control)this).Controls.Add((Control)(object)TargetPanel);
		((Control)this).Controls.Add((Control)(object)HostPanel);
		((Form)this).Location = new Point(0, 0);
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "CargoOpsV2";
		((Form)this).Text = "Cargo Operations";
		((Control)HostPanel).ResumeLayout(false);
		((ISupportInitialize)(object)DestinationCargoGridView).EndInit();
		((Control)TargetPanel).ResumeLayout(false);
		((ISupportInitialize)(object)UnitCargoGridView).EndInit();
		((Control)this).ResumeLayout(false);
	}

	private void method_2()
	{
		PossibleAircraftLoadouts = null;
		SelectedAircraftLoadout = null;
		((ComboBox)ComboAircraftLoadout).Items.Clear();
		if (Mode != CargoOpsMode.HostUnitAndHostedUnit || CargoUnit == null || !CargoUnit.IsAircraft)
		{
			return;
		}
		Aircraft aircraft = (Aircraft)CargoUnit;
		List<Loadout> list = DBFunctions.LoadoutsForThisAircraft(aircraft.DBID, aircraft.ParentScen);
		int num = 0;
		PossibleAircraftLoadouts = new List<Loadout>();
		if (aircraft.Loadout != null && (aircraft.Loadout.IsCargo || aircraft.Loadout.Cargo_Mass + (float)aircraft.Loadout.Cargo_Crew > 0f))
		{
			num = aircraft.Loadout.DBID;
		}
		foreach (Loadout item in list)
		{
			if (num == item.DBID)
			{
				PossibleAircraftLoadouts.Add(item);
				SelectedAircraftLoadout = item;
			}
			else if (item.IsCargo)
			{
				PossibleAircraftLoadouts.Add(item);
			}
		}
		if (SelectedAircraftLoadout == null)
		{
			float num2 = 0f;
			float num3 = 0f;
			foreach (Loadout possibleAircraftLoadout in PossibleAircraftLoadouts)
			{
				num3 = possibleAircraftLoadout.GetCargoMass() / (float)possibleAircraftLoadout.CombatRadius;
				if (num3 > num2)
				{
					SelectedAircraftLoadout = possibleAircraftLoadout;
					num2 = num3;
				}
			}
		}
		if (SelectedAircraftLoadout == null)
		{
			return;
		}
		foreach (Loadout possibleAircraftLoadout2 in PossibleAircraftLoadouts)
		{
			GClass0 gClass = new GClass0(possibleAircraftLoadout2.Name, possibleAircraftLoadout2);
			int selectedIndex = ((ComboBox)ComboAircraftLoadout).Items.Add((object)gClass);
			if (possibleAircraftLoadout2.DBID == SelectedAircraftLoadout.DBID)
			{
				((Control)ComboAircraftLoadout).Enabled = false;
				((ComboBox)ComboAircraftLoadout).SelectedIndex = selectedIndex;
				((Control)ComboAircraftLoadout).Enabled = true;
			}
		}
	}

	private void method_3()
	{
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		CargoUnitWorkingCargoList = new List<Cargo>();
		HostUnitWorkingCargoList = new List<Cargo>();
		if (!CargoUnit.IsGroup)
		{
			CargoUnitWorkingCargoList.AddRange(CargoUnit.OnboardCargo);
		}
		else
		{
			bool flag = false;
			foreach (ActiveUnit value in ((Group)CargoUnit).Units.Values)
			{
				if (value is ICargoHost)
				{
					CargoUnitWorkingCargoList.AddRange(value.OnboardCargo);
					flag = true;
				}
			}
			if (!flag)
			{
				DarkMessageBox.ShowWarning("Cannot perform cargo operations on the selected group. The group contains no cargo hosts.", "Cargo Operations");
				((Form)this).Close();
			}
		}
		SelectedHostUnit = HostUnit;
		if (HostUnit == null)
		{
			Mode = CargoOpsMode.SingleUnitDisplay;
			return;
		}
		Mode = CargoOpsMode.HostUnitAndHostedUnit;
		if (!HostUnit.IsGroup)
		{
			if (HostUnit is ICargoHost)
			{
				HostUnitWorkingCargoList.AddRange(HostUnit.OnboardCargo);
				return;
			}
			DarkMessageBox.ShowWarning("Cannot perform cargo operations. The selected unit's host is not a cargo host.", "Cargo Operations");
			((Form)this).Close();
			return;
		}
		bool flag2 = false;
		foreach (ActiveUnit value2 in ((Group)HostUnit).Units.Values)
		{
			if (value2 is ICargoHost)
			{
				HostUnitWorkingCargoList.AddRange(value2.OnboardCargo);
				flag2 = true;
			}
		}
		if (!flag2)
		{
			DarkMessageBox.ShowWarning("Cannot perform cargo operations. The selected unit's host group does not contain a cargo host.", "Cargo Operations");
			((Form)this).Close();
		}
	}

	private void CargoOpsV2_Load(object sender, EventArgs e)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		RTMP = Client.Realtime;
		if (CargoUnit == null)
		{
			DarkMessageBox.ShowWarning("No unit selected for cargo operations.", "Cargo Operations");
			((Form)this).Close();
		}
		else if (!(CargoUnit is ICargoHost) && !CargoUnit.IsGroup)
		{
			DarkMessageBox.ShowWarning("Cannot perform cargo operations on the selected unit. The unit is not a cargo host.", "Cargo Operations");
			((Form)this).Close();
		}
		method_3();
		method_2();
		MarginWidth = ((Control)TargetPanel).Left - (((Control)HostPanel).Left + ((Control)HostPanel).Width);
		FormBorderWidth = ((Control)this).Width - ((Form)this).ClientSize.Width;
		ResetUI();
		method_7();
	}

	public void RefreshForm()
	{
		method_3();
		ResetUI();
		method_7();
	}

	public void ResetUI()
	{
		if (((CheckBox)Check_GroupByUnitType).Checked != GroupUnitsByType)
		{
			((CheckBox)Check_GroupByUnitType).Checked = GroupUnitsByType;
		}
		string name = CargoUnit.Name;
		name = (CargoUnit.IsGroup ? (name + " [Selected Group]") : (name + " [Selected Unit]"));
		TargetPanel.SectionHeader = name;
		((Control)LabelAircraftLoadout).Visible = false;
		((Control)ComboAircraftLoadout).Visible = false;
		if (Mode == CargoOpsMode.SingleUnitDisplay)
		{
			HostPanel.SectionHeader = "";
			((Control)HostPanel).Visible = false;
			((Control)ButtonLoadOne).Visible = false;
			((Control)ButtonLoadAll).Visible = false;
			((Control)ButtonUnloadOne).Visible = false;
			((Control)ButtonUnloadAll).Visible = false;
			((Control)ButtonConfirm).Visible = false;
			((Control)ButtonCancel).Visible = false;
			((Control)ButtonContainerMode).Visible = true;
			((Control)ButtonTransferMode).Visible = true;
			((Control)ButtonUnloadMode).Visible = true;
			((Control)ButtonPickupMode).Visible = true;
			ButtonContainerMode.Enabled = ContainerModeEnable;
			ButtonTransferMode.Enabled = TransferModeEnable;
			ButtonUnloadMode.Enabled = UnloadModeEnable;
			ButtonPickupMode.Enabled = PickupModeEnabled;
			((Control)this).Width = ((Control)TargetPanel).Width + FormBorderWidth;
			((Control)TargetPanel).Left = 0;
			return;
		}
		switch (Mode)
		{
		case CargoOpsMode.SingleUnitUnloadToMap:
			HostPanel.SectionHeader = "[Cargo to Unload]";
			break;
		case CargoOpsMode.SingleUnitTransferToNearbyUnits:
			name = SelectedHostUnit.Name;
			name = ((!SelectedHostUnit.IsGroup) ? (name + " [Transfer to Unit]") : (name + " [Trasnfer to Group]"));
			HostPanel.SectionHeader = name;
			break;
		case CargoOpsMode.HostUnitAndHostedUnit:
			name = SelectedHostUnit.Name;
			name = ((!SelectedHostUnit.IsGroup) ? (name + " [Hosting Unit]") : (name + " [Hosting Group]"));
			HostPanel.SectionHeader = name;
			if (SelectedAircraftLoadout == null || PossibleAircraftLoadouts.Count <= 1)
			{
				break;
			}
			((Control)LabelAircraftLoadout).Visible = true;
			((Control)ComboAircraftLoadout).Visible = true;
			if (CargoUnit.IsAircraft)
			{
				Aircraft aircraft = (Aircraft)CargoUnit;
				if (aircraft.Loadout != null && aircraft.Loadout.DBID == SelectedAircraftLoadout.DBID)
				{
					((Label)LabelAircraftLoadout).Text = "Loadout:";
					((Control)LabelAircraftLoadout).ForeColor = Color.White;
				}
				else
				{
					((Label)LabelAircraftLoadout).Text = "New Loadout:";
					((Control)LabelAircraftLoadout).ForeColor = Color.Yellow;
				}
			}
			break;
		case CargoOpsMode.SingleUnitPickupFromMap:
			HostPanel.SectionHeader = "[Pickup Nearby / Hosted Units]";
			break;
		}
		((Control)HostPanel).Visible = true;
		((Control)ButtonLoadOne).Visible = true;
		((Control)ButtonLoadAll).Visible = true;
		((Control)ButtonUnloadOne).Visible = true;
		((Control)ButtonUnloadAll).Visible = true;
		((Control)ButtonConfirm).Visible = true;
		((Control)ButtonCancel).Visible = true;
		((Control)ButtonContainerMode).Visible = false;
		((Control)ButtonTransferMode).Visible = false;
		((Control)ButtonUnloadMode).Visible = false;
		((Control)ButtonPickupMode).Visible = false;
		method_4();
		((Control)this).Width = ((Control)HostPanel).Left + ((Control)HostPanel).Width + MarginWidth + ((Control)TargetPanel).Width + FormBorderWidth;
		((Control)TargetPanel).Left = ((Control)HostPanel).Left + ((Control)HostPanel).Width + MarginWidth;
	}

	private void method_4()
	{
		ButtonLoadOne.Enabled = LoadingButtonsEnable;
		ButtonLoadAll.Enabled = ButtonLoadOne.Enabled;
		ButtonUnloadOne.Enabled = UnloadingButtonsEnable;
		ButtonUnloadAll.Enabled = ButtonUnloadOne.Enabled;
		if (((Control)ButtonContainerMode).Visible)
		{
			ButtonContainerMode.Enabled = ContainerModeEnable;
		}
	}

	private void method_5()
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		CargoUnitAvailableMass = 0f;
		CargoUnitAvailableArea = 0f;
		CargoUnitAvailableCrew = 0f;
		if (CargoUnit.IsAircraft && SelectedAircraftLoadout != null)
		{
			CargoUnitAvailableMass = SelectedAircraftLoadout.GetCargoMass();
			CargoUnitAvailableArea = SelectedAircraftLoadout.GetCargoArea();
			CargoUnitAvailableCrew = SelectedAircraftLoadout.Cargo_Crew;
		}
		else
		{
			if (!CargoUnit.IsGroup)
			{
				list.Add(CargoUnit);
			}
			else
			{
				list.AddRange(((Group)CargoUnit).Units.Values.ToList());
			}
			foreach (ICargoHost item in list)
			{
				CargoUnitAvailableMass += item.GetCargo_Mass();
				CargoUnitAvailableArea += item.GetCargo_Area();
				CargoUnitAvailableCrew += item.GetCargo_Crew();
			}
		}
		foreach (Cargo cargoUnitWorkingCargo in CargoUnitWorkingCargoList)
		{
			CargoUnitAvailableMass -= cargoUnitWorkingCargo.RequiredMass;
			CargoUnitAvailableArea -= cargoUnitWorkingCargo.RequiredArea;
			CargoUnitAvailableCrew -= cargoUnitWorkingCargo.RequiredCrewSpace;
		}
		if (SelectedHostUnit == null)
		{
			if (Mode != CargoOpsMode.SingleUnitUnloadToMap && Mode != CargoOpsMode.SingleUnitPickupFromMap)
			{
				return;
			}
			{
				foreach (Cargo hostUnitWorkingCargo in HostUnitWorkingCargoList)
				{
					HostUnitAvailableMass += hostUnitWorkingCargo.RequiredMass;
					HostUnitAvailableArea += hostUnitWorkingCargo.RequiredArea;
					HostUnitAvailableCrew += hostUnitWorkingCargo.RequiredCrewSpace;
				}
				return;
			}
		}
		list.Clear();
		HostUnitAvailableMass = 0f;
		HostUnitAvailableArea = 0f;
		HostUnitAvailableCrew = 0f;
		if (SelectedHostUnit.IsGroup)
		{
			list.AddRange(((Group)SelectedHostUnit).Units.Values.ToList());
		}
		else
		{
			list.Add(SelectedHostUnit);
		}
		foreach (ICargoHost item2 in list)
		{
			HostUnitAvailableMass += item2.GetCargo_Mass();
			HostUnitAvailableArea += item2.GetCargo_Area();
			HostUnitAvailableCrew += item2.GetCargo_Crew();
		}
		foreach (Cargo hostUnitWorkingCargo2 in HostUnitWorkingCargoList)
		{
			HostUnitAvailableMass -= hostUnitWorkingCargo2.RequiredMass;
			HostUnitAvailableArea -= hostUnitWorkingCargo2.RequiredArea;
			HostUnitAvailableCrew -= hostUnitWorkingCargo2.RequiredCrewSpace;
		}
	}

	private void method_6(DarkDataGridView darkDataGridView_0, ActiveUnit activeUnit_0, float float_0, float float_1, float float_2)
	{
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		int num = 1;
		int num2 = 2;
		int num3 = 3;
		int num4 = 4;
		int num5 = 5000;
		if (activeUnit_0 != null)
		{
			if (activeUnit_0.IsAircraft && SelectedAircraftLoadout != null)
			{
				num5 = (int)SelectedAircraftLoadout.Cargo_Type;
			}
			else if (activeUnit_0 is ICargoHost)
			{
				num5 = (int)((ICargoHost)activeUnit_0).GetCargo_Type();
			}
		}
		foreach (DataGridViewRow item in (IEnumerable)((DataGridView)darkDataGridView_0).Rows)
		{
			DataGridViewRow val = item;
			if (activeUnit_0 != null)
			{
				if (((DataGridViewBand)val).Tag is ActiveUnit)
				{
					continue;
				}
				int num6;
				if (!(((DataGridViewBand)val).Tag is Cargo))
				{
					if (!(((DataGridViewBand)val).Tag is CargoManifestItem))
					{
						continue;
					}
					num6 = 1;
				}
				else
				{
					num6 = 1;
				}
				bool flag = (byte)num6 != 0;
				if (Conversions.ToInteger(val.Cells[num].Tag) > num5)
				{
					flag = false;
				}
				else if (Cargo.InputValueMass(Conversions.ToSingle(val.Cells[num2].Value), SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo) > float_0)
				{
					flag = false;
				}
				else if (Cargo.InputValueArea(Conversions.ToSingle(val.Cells[num3].Value), SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo) > float_1)
				{
					flag = false;
				}
				else if (Conversions.ToSingle(val.Cells[num4].Value) > float_2)
				{
					flag = false;
				}
				if (flag)
				{
					val.DefaultCellStyle.ForeColor = ((DataGridView)darkDataGridView_0).DefaultCellStyle.ForeColor;
					val.DefaultCellStyle.SelectionForeColor = ((DataGridView)darkDataGridView_0).DefaultCellStyle.SelectionForeColor;
				}
				else
				{
					val.DefaultCellStyle.ForeColor = Color.Red;
					val.DefaultCellStyle.SelectionForeColor = Color.Red;
				}
			}
			else
			{
				val.DefaultCellStyle.ForeColor = ((DataGridView)darkDataGridView_0).DefaultCellStyle.ForeColor;
				val.DefaultCellStyle.SelectionForeColor = ((DataGridView)darkDataGridView_0).DefaultCellStyle.SelectionForeColor;
			}
		}
	}

	private void method_7()
	{
		if (CargoUnit == null || (!(CargoUnit is ICargoHost) && !CargoUnit.IsGroup))
		{
			return;
		}
		method_5();
		new List<ActiveUnit>(new ActiveUnit[1] { CargoUnit });
		CargoUICommon.PopulateGridViewCargoInventory(UnitCargoGridView, CargoUnit, CargoUnitWorkingCargoList, GroupUnitsByType);
		CargoUICommon.UpdateCapacityLabels(CargoUnit, TargetSizeLabel, TargetMassBar, CargoUnitAvailableMass, TargetAreaBar, CargoUnitAvailableArea, TargetCrewBar, CargoUnitAvailableCrew, SelectedAircraftLoadout);
		switch (Mode)
		{
		default:
			((DataGridView)DestinationCargoGridView).Rows.Clear();
			break;
		case CargoOpsMode.SingleUnitUnloadToMap:
			CargoUICommon.PopulateGridViewCargoInventory(DestinationCargoGridView, null, HostUnitWorkingCargoList, GroupUnitsByType);
			CargoUICommon.UpdateCapacityLabels(null, HostSizeLabel, HostMassBar, HostUnitAvailableMass, HostAreaBar, HostUnitAvailableArea, HostCrewBar, HostUnitAvailableCrew);
			break;
		case CargoOpsMode.SingleUnitTransferToNearbyUnits:
		case CargoOpsMode.HostUnitAndHostedUnit:
			if (SelectedHostUnit != null)
			{
				CargoUICommon.PopulateGridViewCargoInventory(DestinationCargoGridView, SelectedHostUnit, HostUnitWorkingCargoList, GroupUnitsByType);
				CargoUICommon.UpdateCapacityLabels(SelectedHostUnit, HostSizeLabel, HostMassBar, HostUnitAvailableMass, HostAreaBar, HostUnitAvailableArea, HostCrewBar, HostUnitAvailableCrew);
			}
			break;
		case CargoOpsMode.SingleUnitPickupFromMap:
			CargoUICommon.PopulateGridViewCargoInventory(DestinationCargoGridView, null, HostUnitWorkingCargoList, GroupUnitsByType);
			CargoUICommon.UpdateCapacityLabels(null, HostSizeLabel, HostMassBar, HostUnitAvailableMass, HostAreaBar, HostUnitAvailableArea, HostCrewBar, HostUnitAvailableCrew);
			break;
		}
		method_6(UnitCargoGridView, SelectedHostUnit, HostUnitAvailableMass, HostUnitAvailableArea, HostUnitAvailableCrew);
		method_6(DestinationCargoGridView, CargoUnit, CargoUnitAvailableMass, CargoUnitAvailableArea, CargoUnitAvailableCrew);
		method_23(null, null);
		method_24(null, null);
	}

	private bool method_8()
	{
		List<Cargo> list = new List<Cargo>();
		List<Cargo> list2 = new List<Cargo>();
		List<ActiveUnit> list3 = new List<ActiveUnit>();
		int result;
		if (Mode == CargoOpsMode.SingleUnitUnloadToMap)
		{
			if (CargoUnit.IsGroup)
			{
				list3.AddRange(((Group)CargoUnit).Units.Values);
			}
			else
			{
				list3.Add(CargoUnit);
			}
			if (RTMP)
			{
				Client.RealtimeTerminal.SendCargoOpsAction(list3, null, HostUnitWorkingCargoList);
				result = 1;
			}
			else
			{
				CoreClientCode.CargoOpsAction_Core(list3, null, HostUnitWorkingCargoList);
				result = 1;
			}
		}
		else if (Mode == CargoOpsMode.SingleUnitPickupFromMap)
		{
			List<Cargo> list4 = new List<Cargo>();
			foreach (Cargo hostUnitWorkingCargo in HostUnitWorkingCargoList)
			{
				if (CargoUnit.OnboardCargo.Contains(hostUnitWorkingCargo))
				{
					list4.Add(hostUnitWorkingCargo);
				}
			}
			if (list4.Count > 0)
			{
				list3.Add(CargoUnit);
				if (RTMP)
				{
					Client.RealtimeTerminal.SendCargoOpsAction(list3, null, list4);
				}
				else
				{
					CoreClientCode.CargoOpsAction_Core(list3, null, list4);
				}
			}
			list4.Clear();
			foreach (Cargo cargoUnitWorkingCargo in CargoUnitWorkingCargoList)
			{
				if (!CargoUnit.OnboardCargo.Contains(cargoUnitWorkingCargo))
				{
					list4.Add(cargoUnitWorkingCargo);
				}
			}
			if (list4.Count <= 0)
			{
				result = 1;
			}
			else
			{
				List<Cargo> list5 = new List<Cargo>();
				list3.Clear();
				foreach (Cargo item in list4)
				{
					ActiveUnit cargoObjectActiveUnit = item.CargoObjectActiveUnit;
					if (cargoObjectActiveUnit != null)
					{
						list3.Add(cargoObjectActiveUnit);
					}
				}
				if (RTMP)
				{
					Client.RealtimeTerminal.SendCargoOpsAction(list3, CargoUnit, list5);
					result = 1;
				}
				else
				{
					CoreClientCode.CargoOpsAction_Core(list3, CargoUnit, list5);
					result = 1;
				}
			}
		}
		else
		{
			List<Cargo> list6 = ((!CargoUnit.IsGroup) ? CargoUnit.OnboardCargo.ToList() : CargoUICommon.GetGroupCargo(CargoUnit));
			foreach (Cargo cargoUnitWorkingCargo2 in CargoUnitWorkingCargoList)
			{
				if (!list6.Contains(cargoUnitWorkingCargo2))
				{
					list2.Add(cargoUnitWorkingCargo2);
				}
			}
			List<Cargo> list7 = ((!SelectedHostUnit.IsGroup) ? SelectedHostUnit.OnboardCargo.ToList() : CargoUICommon.GetGroupCargo(SelectedHostUnit));
			foreach (Cargo hostUnitWorkingCargo2 in HostUnitWorkingCargoList)
			{
				if (!list7.Contains(hostUnitWorkingCargo2))
				{
					list.Add(hostUnitWorkingCargo2);
				}
			}
			CargoOpsMode mode = Mode;
			if (mode != CargoOpsMode.SingleUnitTransferToNearbyUnits)
			{
				if (mode == CargoOpsMode.HostUnitAndHostedUnit)
				{
					if (list.Count > 0)
					{
						list3.Clear();
						list3.Add(CargoUnit);
						if (!RTMP)
						{
							CoreClientCode.CargoOpsAction_Core(list3, SelectedHostUnit, list);
						}
						else
						{
							Client.RealtimeTerminal.SendCargoOpsAction(list3, SelectedHostUnit, list);
						}
					}
					if (list2.Count > 0)
					{
						list3.Clear();
						if (SelectedHostUnit.IsGroup)
						{
							list3.AddRange(((Group)SelectedHostUnit).Units.Values);
						}
						else
						{
							list3.Add(SelectedHostUnit);
						}
						if (RTMP)
						{
							Client.RealtimeTerminal.SendCargoOpsAction(list3, CargoUnit, list2);
							result = 1;
						}
						else
						{
							CoreClientCode.CargoOpsAction_Core(list3, CargoUnit, list2);
							result = 1;
						}
						goto IL_0487;
					}
				}
			}
			else
			{
				if (list.Count > 0)
				{
					if (!CargoUnit.IsGroup)
					{
						list3.Add(CargoUnit);
					}
					else
					{
						list3.AddRange(((Group)CargoUnit).Units.Values);
					}
					if (!RTMP)
					{
						CoreClientCode.CargoOpsAction_Core(list3, SelectedHostUnit, list);
					}
					else
					{
						Client.RealtimeTerminal.SendCargoOpsAction(list3, SelectedHostUnit, list);
					}
				}
				if (list2.Count > 0)
				{
					list3.Clear();
					list3.Add(SelectedHostUnit);
					if (!RTMP)
					{
						CoreClientCode.CargoOpsAction_Core(list3, CargoUnit, list2);
						result = 1;
					}
					else
					{
						Client.RealtimeTerminal.SendCargoOpsAction(list3, CargoUnit, list2);
						result = 1;
					}
					goto IL_0487;
				}
			}
			result = 1;
		}
		goto IL_0487;
		IL_0487:
		return (byte)result != 0;
	}

	private void method_9(Aircraft aircraft_0, int int_1)
	{
		if (!RTMP)
		{
			ActiveUnit currentHostUnit = aircraft_0.AirOps.CurrentHostUnit;
			if (currentHostUnit != null)
			{
				currentHostUnit.AirOps.OutfitAC(ref aircraft_0, int_1, aircraft_0.LoadoutDBID, ReadyImmediately: false, ExcludeOptionalWeapons: false, DrawWeaponsFromMagazine: true, ManualAction: true, PlayerFeedback: true);
				currentHostUnit.AirOps.RefuelAC_Simple(ref aircraft_0);
				currentHostUnit.AirOps.RepairAC(ref aircraft_0);
			}
		}
		else
		{
			List<Aircraft> list = new List<Aircraft>();
			list.Add(aircraft_0);
			Client.RealtimeTerminal.SendRearmAircraftMessage(list, ReadyImmediately: false, ManualAction: true, ExcludeOptionalWeapons: false, DrawWeaponsFromMagazine: true, int_1, CB_QuickTurnaround_Checked: false);
		}
	}

	private void method_10(object sender, EventArgs e)
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		if (CargoUnit != null && SelectedAircraftLoadout != null && CargoUnit.IsAircraft)
		{
			Aircraft aircraft = (Aircraft)CargoUnit;
			if (aircraft.Loadout == null || aircraft.Loadout.DBID != SelectedAircraftLoadout.DBID)
			{
				method_9(aircraft, SelectedAircraftLoadout.DBID);
			}
		}
		if (!method_8())
		{
			DarkMessageBox.ShowWarning("One or more cargo items could not be moved due to capacity limitations.", "Cargo Operations");
		}
		MyProject.Forms.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, Client.SelectedUnit, v: false);
		if (((Control)MyProject.Forms.AirOps).Visible)
		{
			MyProject.Forms.AirOps.RefreshForm();
		}
		((Form)this).Close();
	}

	private void method_11(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void method_12(object sender, EventArgs e)
	{
		GroupUnitsByType = ((CheckBox)Check_GroupByUnitType).Checked;
		method_7();
	}

	private void method_13(object sender, EventArgs e)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		string text = Cargo.CanUnloadToMap(CargoUnit);
		if (Operators.CompareString(text, "Ok", true) != 0)
		{
			DarkMessageBox.ShowWarning(text, "Cargo Operations");
			return;
		}
		Mode = CargoOpsMode.SingleUnitUnloadToMap;
		ResetUI();
	}

	private void method_14(object sender, EventArgs e)
	{
		HostUnitWorkingCargoList.Clear();
		List<ActiveUnit> hostedUnitsThatCanBeLoadedAsCargo = CargoUnit.GetHostedUnitsThatCanBeLoadedAsCargo();
		hostedUnitsThatCanBeLoadedAsCargo.AddRange(CargoUnit.GetNearbyUnitsThatCanBeLoadedAsCargo());
		foreach (ActiveUnit item2 in hostedUnitsThatCanBeLoadedAsCargo)
		{
			Cargo item = new Cargo(null, item2);
			HostUnitWorkingCargoList.Add(item);
		}
		Mode = CargoOpsMode.SingleUnitPickupFromMap;
		ResetUI();
		method_7();
	}

	private void method_15(object sender, EventArgs e)
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		List<ActiveUnit> possibleTransferDestinations = Cargo.GetPossibleTransferDestinations(CargoUnit);
		SelectedHostUnit = null;
		if (possibleTransferDestinations.Count == 1)
		{
			SelectedHostUnit = possibleTransferDestinations[0];
		}
		else if (possibleTransferDestinations.Count > 0)
		{
			List<ActiveUnit> SelectedUnits = new List<ActiveUnit>();
			UnitSelection.CallDialogWithUnits(possibleTransferDestinations, MultipleSelection: false, ref SelectedUnits);
			if (SelectedUnits.Count > 0)
			{
				SelectedHostUnit = SelectedUnits[0];
			}
		}
		else
		{
			DarkMessageBox.ShowWarning("No valid destination units are nearby (less than 2nm distance.)", "Cargo Operations");
		}
		HostUnit = SelectedHostUnit;
		if (SelectedHostUnit != null)
		{
			Mode = CargoOpsMode.SingleUnitTransferToNearbyUnits;
			if (SelectedHostUnit.IsGroup)
			{
				HostUnitWorkingCargoList = CargoUICommon.GetGroupCargo(SelectedHostUnit);
			}
			else
			{
				HostUnitWorkingCargoList = SelectedHostUnit.OnboardCargo.ToList();
			}
			ResetUI();
			method_7();
		}
	}

	private void qllPubeVf4(object sender, EventArgs e)
	{
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Invalid comparison between Unknown and I4
		if (((BaseCollection)((DataGridView)UnitCargoGridView).SelectedRows).Count <= 0 || ((DataGridViewBand)((DataGridView)UnitCargoGridView).SelectedRows[0]).Tag == null)
		{
			return;
		}
		Cargo cargo = null;
		if (((DataGridViewBand)((DataGridView)UnitCargoGridView).SelectedRows[0]).Tag is Cargo)
		{
			if (((Cargo)((DataGridViewBand)((DataGridView)UnitCargoGridView).SelectedRows[0]).Tag).CurrentType == Cargo.CargoObjectType.CargoContainer)
			{
				cargo = (Cargo)((DataGridViewBand)((DataGridView)UnitCargoGridView).SelectedRows[0]).Tag;
			}
		}
		else if (((DataGridViewBand)((DataGridView)UnitCargoGridView).SelectedRows[0]).Tag is CargoManifestItem)
		{
			CargoManifestItem cargoManifestItem = (CargoManifestItem)((DataGridViewBand)((DataGridView)UnitCargoGridView).SelectedRows[0]).Tag;
			if (cargoManifestItem.objectType == Cargo.CargoObjectType.CargoContainer)
			{
				cargo = CargoHostHelper.FindMatchingCargo(CargoUnitWorkingCargoList, cargoManifestItem);
			}
		}
		if (cargo == null)
		{
			return;
		}
		if (CargoUnit.IsFixedFacility)
		{
			MyProject.Forms.CargoOpsContainer.SelectedContainer = cargo.CargoObjectContainer;
			MyProject.Forms.CargoOpsContainer.SelectedHost = CargoUnit;
			if ((int)((Form)MyProject.Forms.CargoOpsContainer).ShowDialog() == 1)
			{
				method_7();
			}
		}
		else
		{
			DarkMessageBox.ShowWarning("Container contents can only be loaded or unloaded while the container is in a fixed facility.", "Cargo Operations");
		}
	}

	private List<Cargo> method_16(DarkDataGridView darkDataGridView_0, List<Cargo> list_0, bool bool_3)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		List<Cargo> list = new List<Cargo>();
		foreach (DataGridViewRow item2 in (BaseCollection)((DataGridView)darkDataGridView_0).SelectedRows)
		{
			DataGridViewRow val = item2;
			if (((DataGridViewBand)val).Tag == null || ((DataGridViewBand)val).Tag is ActiveUnit)
			{
				continue;
			}
			if (((DataGridViewBand)val).Tag is CargoManifestItem)
			{
				CargoManifestItem cargoManifestItem = (CargoManifestItem)((DataGridViewBand)val).Tag;
				int num = 1;
				if (bool_3)
				{
					num = cargoManifestItem.quantity;
				}
				foreach (Cargo item3 in list_0)
				{
					if (cargoManifestItem.IsMatch(item3) && !list.Contains(item3))
					{
						list.Add(item3);
						num--;
					}
					if (num < 1)
					{
						break;
					}
				}
			}
			else if (((DataGridViewBand)val).Tag is Cargo)
			{
				Cargo item = (Cargo)((DataGridViewBand)val).Tag;
				if (list_0.Contains(item) && !list.Contains(item))
				{
					list.Add(item);
				}
			}
		}
		return list;
	}

	public int GetGroupCargoSizeMaximum(ActiveUnit theUnit)
	{
		int num = 0;
		if (theUnit.IsGroup)
		{
			List<ActiveUnit> list = ((Group)theUnit).Units.Values.ToList();
			foreach (ActiveUnit item in list)
			{
				if (item is ICargoHost)
				{
					ICargoHost cargoHost = (ICargoHost)item;
					if ((int)cargoHost.GetCargo_Type() > num)
					{
						num = (int)cargoHost.GetCargo_Type();
					}
				}
			}
		}
		return num;
	}

	private void method_17(bool bool_3, bool bool_4, Loadout loadout_0 = null)
	{
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		List<Cargo> list = method_16(DestinationCargoGridView, HostUnitWorkingCargoList, bool_3);
		if (bool_4)
		{
			List<Cargo> list2 = new List<Cargo>();
			float num = CargoUnitAvailableMass;
			float num2 = CargoUnitAvailableArea;
			float num3 = CargoUnitAvailableCrew;
			int num4 = 0;
			num4 = ((int?)loadout_0?.Cargo_Type) ?? ((!CargoUnit.IsGroup) ? ((int)((ICargoHost)CargoUnit).GetCargo_Type()) : GetGroupCargoSizeMaximum(CargoUnit));
			foreach (Cargo item in list)
			{
				if ((int)item.RequiredCargoType <= num4)
				{
					if (!(num - item.RequiredMass < 0f) && !(num2 - item.RequiredArea < 0f) && num3 - item.RequiredCrewSpace >= 0f)
					{
						num -= item.RequiredMass;
						num2 -= item.RequiredArea;
						num3 -= item.RequiredCrewSpace;
					}
					else
					{
						list2.Add(item);
					}
				}
				else
				{
					list2.Add(item);
				}
			}
			if (list2.Count > 0)
			{
				list = list.Except(list2).ToList();
				DarkMessageBox.ShowWarning("One or more of the selected cargo items could not be loaded due to cargo size category, mass, area, or PAX capacity limits.", "Cargo Operations");
			}
		}
		if (list.Count > 0)
		{
			HostUnitWorkingCargoList = HostUnitWorkingCargoList.Except(list).ToList();
			CargoUnitWorkingCargoList.AddRange(list);
			method_7();
		}
	}

	private void method_18(bool bool_3, bool bool_4)
	{
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		List<Cargo> list = method_16(UnitCargoGridView, CargoUnitWorkingCargoList, bool_3);
		if (bool_4)
		{
			List<Cargo> list2 = new List<Cargo>();
			float num = HostUnitAvailableMass;
			float num2 = HostUnitAvailableArea;
			float num3 = HostUnitAvailableCrew;
			int num4 = 0;
			num4 = ((SelectedHostUnit == null) ? 5000 : (SelectedHostUnit.IsGroup ? GetGroupCargoSizeMaximum(SelectedHostUnit) : ((int)((ICargoHost)SelectedHostUnit).GetCargo_Type())));
			foreach (Cargo item in list)
			{
				if ((int)item.RequiredCargoType <= num4)
				{
					if (!(num - item.RequiredMass < 0f) && !(num2 - item.RequiredArea < 0f) && num3 - item.RequiredCrewSpace >= 0f)
					{
						num -= item.RequiredMass;
						num2 -= item.RequiredArea;
						num3 -= item.RequiredCrewSpace;
					}
					else
					{
						list2.Add(item);
					}
				}
				else
				{
					list2.Add(item);
				}
			}
			if (list2.Count > 0)
			{
				list = list.Except(list2).ToList();
				DarkMessageBox.ShowWarning("One or more of the selected cargo items could not be transferred due to cargo size category, mass, area, or PAX capacity limits.", "Cargo Operations");
			}
		}
		if (list.Count > 0)
		{
			CargoUnitWorkingCargoList = CargoUnitWorkingCargoList.Except(list).ToList();
			HostUnitWorkingCargoList.AddRange(list);
			method_7();
		}
	}

	private void method_19(object sender, EventArgs e)
	{
		bool bool_ = Mode != CargoOpsMode.SingleUnitUnloadToMap;
		method_17(bool_3: true, bool_, SelectedAircraftLoadout);
	}

	private void method_20(object sender, EventArgs e)
	{
		bool bool_ = Mode != CargoOpsMode.SingleUnitUnloadToMap;
		method_17(bool_3: false, bool_, SelectedAircraftLoadout);
	}

	private void method_21(object sender, EventArgs e)
	{
		bool bool_ = Mode != CargoOpsMode.SingleUnitUnloadToMap;
		method_18(bool_3: false, bool_);
	}

	private void method_22(object sender, EventArgs e)
	{
		bool bool_ = Mode != CargoOpsMode.SingleUnitUnloadToMap;
		method_18(bool_3: true, bool_);
	}

	private void method_23(object sender, EventArgs e)
	{
		method_4();
	}

	private void method_24(object sender, EventArgs e)
	{
		method_4();
	}

	private bool method_25(List<Cargo> list_0, Loadout loadout_0)
	{
		int num = 1000;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		foreach (Cargo item in list_0)
		{
			if ((int)item.RequiredCargoType > num)
			{
				num = (int)item.RequiredCargoType;
			}
			num2 += item.RequiredMass;
			num3 += item.RequiredArea;
			num4 += item.RequiredCrewSpace;
		}
		int result;
		if (num <= (int)loadout_0.Cargo_Type && !(num2 > loadout_0.GetCargoMass()) && !(num3 > loadout_0.GetCargoArea()))
		{
			if (!(num4 > (float)loadout_0.Cargo_Crew))
			{
				return true;
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	private void method_26(object sender, EventArgs e)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		if (((Control)ComboAircraftLoadout).Enabled && ((ComboBox)ComboAircraftLoadout).SelectedIndex >= 0)
		{
			Loadout loadout = (Loadout)((GClass0)((ComboBox)ComboAircraftLoadout).Items[((ComboBox)ComboAircraftLoadout).SelectedIndex]).Value;
			if (!method_25(CargoUnitWorkingCargoList, loadout))
			{
				DarkMessageBox.ShowError("The aircraft can't use the new loadout due to cargo already aboard.", "Cargo Ops");
				((ComboBox)ComboAircraftLoadout).SelectedIndex = int_0;
				return;
			}
			SelectedAircraftLoadout = loadout;
			ResetUI();
			method_7();
		}
		int_0 = ((ComboBox)ComboAircraftLoadout).SelectedIndex;
	}

	static CargoOpsV2()
	{
		Class72.smethod_20();
	}
}
