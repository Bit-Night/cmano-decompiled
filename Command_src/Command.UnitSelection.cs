using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using Command.My.Resources;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class UnitSelection : Form
{
	public class UnitSelectionConfig
	{
		public enum Condition
		{
			IsAirbase,
			IsDock,
			IsMobileGroundUnit,
			IsFacility,
			IsAircraft,
			IsSatellite,
			IsShip,
			IsBoat,
			IsWeapon,
			IsGroup,
			IsAirbaseFacility,
			IsRP,
			IsStandardZone,
			IsDockFacility,
			IsCargoMissionDestination,
			IsAggregateGroundUnit,
			IsAggregateGroundUnit_HQ
		}

		private Dictionary<Condition, bool> Conditions;

		public List<ActiveUnit> SortUnits(List<ActiveUnit> UnitsToSort)
		{
			List<ActiveUnit> list = new List<ActiveUnit>();
			foreach (ActiveUnit item in UnitsToSort)
			{
				if (FulfillConditions(item))
				{
					list.Add(item);
				}
			}
			return list;
		}

		public bool FulfillConditions(ActiveUnit UnitToEvaluate)
		{
			foreach (KeyValuePair<Condition, bool> condition in Conditions)
			{
				switch (condition.Key)
				{
				case Condition.IsDock:
				{
					if (!condition.Value)
					{
						if (!UnitToEvaluate.HasDockFacilities)
						{
							break;
						}
						int result;
						if (!UnitToEvaluate.IsGroup)
						{
							if (!UnitToEvaluate.IsBoat)
							{
								if (!UnitToEvaluate.IsShip)
								{
									break;
								}
								result = 0;
							}
							else
							{
								result = 0;
							}
						}
						else
						{
							result = 0;
						}
						return (byte)result != 0;
					}
					int result2;
					if (UnitToEvaluate.HasDockFacilities)
					{
						if (UnitToEvaluate.IsGroup || UnitToEvaluate.IsBoat || UnitToEvaluate.IsShip)
						{
							break;
						}
						result2 = 0;
					}
					else
					{
						result2 = 0;
					}
					return (byte)result2 != 0;
				}
				case Condition.IsMobileGroundUnit:
					if (condition.Value)
					{
						if (!UnitToEvaluate.IsMobileGroundUnit)
						{
							return false;
						}
					}
					else if (UnitToEvaluate.IsMobileGroundUnit)
					{
						return false;
					}
					break;
				case Condition.IsFacility:
					if (!condition.Value)
					{
						if (UnitToEvaluate.IsFacility)
						{
							return false;
						}
					}
					else if (!UnitToEvaluate.IsFacility)
					{
						return false;
					}
					break;
				case Condition.IsAircraft:
					if (condition.Value)
					{
						if (!UnitToEvaluate.IsAircraft)
						{
							return false;
						}
					}
					else if (UnitToEvaluate.IsAircraft)
					{
						return false;
					}
					break;
				case Condition.IsSatellite:
					if (condition.Value)
					{
						if (!UnitToEvaluate.IsSatellite)
						{
							return false;
						}
					}
					else if (UnitToEvaluate.IsSatellite)
					{
						return false;
					}
					break;
				case Condition.IsShip:
					if (!condition.Value)
					{
						if (UnitToEvaluate.IsShip)
						{
							return false;
						}
					}
					else if (!UnitToEvaluate.IsShip)
					{
						return false;
					}
					break;
				case Condition.IsBoat:
					if (condition.Value)
					{
						if (!UnitToEvaluate.IsBoat)
						{
							return false;
						}
					}
					else if (UnitToEvaluate.IsBoat)
					{
						return false;
					}
					break;
				case Condition.IsWeapon:
					if (condition.Value)
					{
						if (!UnitToEvaluate.IsWeapon)
						{
							return false;
						}
					}
					else if (UnitToEvaluate.IsWeapon)
					{
						return false;
					}
					break;
				case Condition.IsGroup:
					if (!condition.Value)
					{
						if (UnitToEvaluate.IsGroup)
						{
							return false;
						}
					}
					else if (!UnitToEvaluate.IsGroup)
					{
						return false;
					}
					break;
				case Condition.IsAirbaseFacility:
					if (condition.Value)
					{
						if (!UnitToEvaluate.HasAirFacilities)
						{
							return false;
						}
					}
					else if (UnitToEvaluate.HasAirFacilities)
					{
						return false;
					}
					break;
				case Condition.IsDockFacility:
					if (!condition.Value)
					{
						if (UnitToEvaluate.HasDockFacilities)
						{
							return false;
						}
					}
					else if (!UnitToEvaluate.HasDockFacilities)
					{
						return false;
					}
					break;
				case Condition.IsCargoMissionDestination:
					if (condition.Value)
					{
						if (!CargoMission.IsValidDestinationUnit(UnitToEvaluate, IgnorePlayerSide: true))
						{
							return false;
						}
					}
					else if (CargoMission.IsValidDestinationUnit(UnitToEvaluate, IgnorePlayerSide: true))
					{
						return false;
					}
					break;
				case Condition.IsAggregateGroundUnit:
					if (condition.Value)
					{
						if (!UnitToEvaluate.IsAggregatedUnit)
						{
							return false;
						}
					}
					else if (UnitToEvaluate.IsAggregatedUnit)
					{
						return false;
					}
					break;
				case Condition.IsAggregateGroundUnit_HQ:
					if (condition.Value)
					{
						int result3;
						if (UnitToEvaluate.IsAggregatedUnit)
						{
							if (((AggregateGroundUnit)UnitToEvaluate).MobileUnitCategory == IMobileGroundUnit._MobileUnitCategory.Headquarters)
							{
								break;
							}
							result3 = 0;
						}
						else
						{
							result3 = 0;
						}
						return (byte)result3 != 0;
					}
					if (UnitToEvaluate.IsAggregatedUnit && ((AggregateGroundUnit)UnitToEvaluate).MobileUnitCategory == IMobileGroundUnit._MobileUnitCategory.Headquarters)
					{
						return false;
					}
					break;
				case Condition.IsAirbase:
				{
					bool flag = false;
					flag = (UnitToEvaluate.IsGroup ? (((Group)UnitToEvaluate).Type == Group.GroupType.AirBase) : (UnitToEvaluate.IsSingleUnitAirbase || (UnitToEvaluate.HasAirFacilities && (UnitToEvaluate.IsShip || UnitToEvaluate.IsBoat))));
					if (!condition.Value)
					{
						return !flag;
					}
					return flag;
				}
				}
			}
			return true;
		}

		public UnitSelectionConfig(Dictionary<Condition, bool> _Conditions = null)
		{
			Conditions = new Dictionary<Condition, bool>();
			if (_Conditions != null)
			{
				Conditions = _Conditions;
			}
		}

		public static UnitSelectionConfig DefaultUnitSelection()
		{
			Dictionary<Condition, bool> dictionary = new Dictionary<Condition, bool>();
			dictionary.Add(Condition.IsGroup, value: false);
			dictionary.Add(Condition.IsWeapon, value: false);
			return new UnitSelectionConfig(dictionary);
		}

		public static UnitSelectionConfig DefaultAirbase(bool IncFacilities = true)
		{
			Dictionary<Condition, bool> dictionary = new Dictionary<Condition, bool>();
			if (IncFacilities)
			{
				dictionary.Add(Condition.IsAirbaseFacility, value: true);
			}
			dictionary.Add(Condition.IsAirbase, value: true);
			return new UnitSelectionConfig(dictionary);
		}

		public static UnitSelectionConfig DefaultDock(bool IncFacilities = true)
		{
			Dictionary<Condition, bool> dictionary = new Dictionary<Condition, bool>();
			if (IncFacilities)
			{
				dictionary.Add(Condition.IsDockFacility, value: true);
			}
			dictionary.Add(Condition.IsDock, value: true);
			return new UnitSelectionConfig(dictionary);
		}

		public static UnitSelectionConfig DefaultZone()
		{
			Dictionary<Condition, bool> dictionary = new Dictionary<Condition, bool>();
			dictionary.Add(Condition.IsStandardZone, value: true);
			return new UnitSelectionConfig(dictionary);
		}

		public static UnitSelectionConfig DefaultRP()
		{
			Dictionary<Condition, bool> dictionary = new Dictionary<Condition, bool>();
			dictionary.Add(Condition.IsRP, value: true);
			return new UnitSelectionConfig(dictionary);
		}

		public static UnitSelectionConfig DefaultCargoMissionDestination()
		{
			Dictionary<Condition, bool> dictionary = new Dictionary<Condition, bool>();
			dictionary.Add(Condition.IsCargoMissionDestination, value: true);
			return new UnitSelectionConfig(dictionary);
		}

		public static UnitSelectionConfig DefaultGroup()
		{
			Dictionary<Condition, bool> dictionary = new Dictionary<Condition, bool>();
			dictionary.Add(Condition.IsGroup, value: true);
			return new UnitSelectionConfig(dictionary);
		}

		public bool? GetConditionValue(Condition _condition)
		{
			return Conditions.ContainsKey(_condition) ? new bool?(Conditions[_condition]) : ((bool?)null);
		}

		public void MustBe(Condition _condition)
		{
			if (!Conditions.ContainsKey(_condition))
			{
				Conditions.Add(_condition, value: true);
			}
			else
			{
				Conditions[_condition] = true;
			}
		}

		public void MustNotBe(Condition _condition)
		{
			if (Conditions.ContainsKey(_condition))
			{
				Conditions[_condition] = false;
			}
			else
			{
				Conditions.Add(_condition, value: false);
			}
		}

		public void NoCondition(Condition _condition)
		{
			if (Conditions.ContainsKey(_condition))
			{
				Conditions.Remove(_condition);
			}
		}

		static UnitSelectionConfig()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_0;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonToggle_ShowSpaceUnit_Unassigned")]
	private Button _ButtonToggle_ShowSpaceUnit_Unassigned;

	[AccessedThroughProperty("ButtonToggle_ShowLandUnit_Unassigned")]
	[CompilerGenerated]
	private Button _ButtonToggle_ShowLandUnit_Unassigned;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonToggle_ShowAirUnit_Unassigned")]
	private Button _ButtonToggle_ShowAirUnit_Unassigned;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonToggle_ShowNavalUnit_Unassigned")]
	private Button _ButtonToggle_ShowNavalUnit_Unassigned;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Confirm")]
	private DarkUIButton _Button_Confirm;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonCancel")]
	private DarkUIButton _ButtonCancel;

	[AccessedThroughProperty("LV_Units")]
	[CompilerGenerated]
	private DarkListView _LV_Units;

	[AccessedThroughProperty("Button_Filter")]
	[CompilerGenerated]
	private DarkUIButton _Button_Filter;

	[AccessedThroughProperty("Button_Action_Delete")]
	[CompilerGenerated]
	private DarkUIButton _Button_Action_Delete;

	[AccessedThroughProperty("ButtonToggle_ShowRP")]
	[CompilerGenerated]
	private Button _ButtonToggle_ShowRP;

	[AccessedThroughProperty("ButtonToggle_ShowStandardZone")]
	[CompilerGenerated]
	private Button _ButtonToggle_ShowStandardZone;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	public UnitSelectionConfig Configuration;

	private List<Side> list_0;

	internal virtual Button ButtonToggle_ShowSpaceUnit_Unassigned
	{
		[CompilerGenerated]
		get
		{
			return _ButtonToggle_ShowSpaceUnit_Unassigned;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_4;
			Button val = _ButtonToggle_ShowSpaceUnit_Unassigned;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_ButtonToggle_ShowSpaceUnit_Unassigned = value;
			val = _ButtonToggle_ShowSpaceUnit_Unassigned;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual Button ButtonToggle_ShowLandUnit_Unassigned
	{
		[CompilerGenerated]
		get
		{
			return _ButtonToggle_ShowLandUnit_Unassigned;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			Button val = _ButtonToggle_ShowLandUnit_Unassigned;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_ButtonToggle_ShowLandUnit_Unassigned = value;
			val = _ButtonToggle_ShowLandUnit_Unassigned;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual Button ButtonToggle_ShowAirUnit_Unassigned
	{
		[CompilerGenerated]
		get
		{
			return _ButtonToggle_ShowAirUnit_Unassigned;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			Button val = _ButtonToggle_ShowAirUnit_Unassigned;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_ButtonToggle_ShowAirUnit_Unassigned = value;
			val = _ButtonToggle_ShowAirUnit_Unassigned;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual Button ButtonToggle_ShowNavalUnit_Unassigned
	{
		[CompilerGenerated]
		get
		{
			return _ButtonToggle_ShowNavalUnit_Unassigned;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_1;
			Button val = _ButtonToggle_ShowNavalUnit_Unassigned;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_ButtonToggle_ShowNavalUnit_Unassigned = value;
			val = _ButtonToggle_ShowNavalUnit_Unassigned;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_Confirm
	{
		[CompilerGenerated]
		get
		{
			return _Button_Confirm;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_13;
			DarkUIButton darkUIButton = _Button_Confirm;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_Confirm = value;
			darkUIButton = _Button_Confirm;
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
			EventHandler eventHandler = method_14;
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

	internal virtual DarkListView LV_Units
	{
		[CompilerGenerated]
		get
		{
			return _LV_Units;
		}
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_11;
			DarkListView darkListView = _LV_Units;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged -= value2;
			}
			_LV_Units = value;
			darkListView = _LV_Units;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("TB_Filter")]
	internal virtual DarkUITextBox TB_Filter { get; set; }

	internal virtual DarkUIButton Button_Filter
	{
		[CompilerGenerated]
		get
		{
			return _Button_Filter;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_12;
			DarkUIButton darkUIButton = _Button_Filter;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_Filter = value;
			darkUIButton = _Button_Filter;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("FlowLayoutPanel1")]
	internal virtual FlowLayoutPanel FlowLayoutPanel1 { get; set; }

	[field: AccessedThroughProperty("FlowLayoutPanel2")]
	internal virtual FlowLayoutPanel FlowLayoutPanel2 { get; set; }

	internal virtual DarkUIButton Button_Action_Delete
	{
		[CompilerGenerated]
		get
		{
			return _Button_Action_Delete;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_15;
			DarkUIButton darkUIButton = _Button_Action_Delete;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_Action_Delete = value;
			darkUIButton = _Button_Action_Delete;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual Button ButtonToggle_ShowRP
	{
		[CompilerGenerated]
		get
		{
			return _ButtonToggle_ShowRP;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_16;
			Button val = _ButtonToggle_ShowRP;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_ButtonToggle_ShowRP = value;
			val = _ButtonToggle_ShowRP;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual Button ButtonToggle_ShowStandardZone
	{
		[CompilerGenerated]
		get
		{
			return _ButtonToggle_ShowStandardZone;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_17;
			Button val = _ButtonToggle_ShowStandardZone;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_ButtonToggle_ShowStandardZone = value;
			val = _ButtonToggle_ShowStandardZone;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	public UnitSelection()
	{
		bool_0 = true;
		bool_1 = true;
		bool_2 = true;
		bool_3 = true;
		bool_4 = true;
		bool_5 = true;
		bool_6 = true;
		list_0 = new List<Side>();
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
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		//IL_0425: Unknown result type (might be due to invalid IL or missing references)
		//IL_042f: Expected O, but got Unknown
		//IL_046d: Unknown result type (might be due to invalid IL or missing references)
		//IL_061b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0625: Expected O, but got Unknown
		//IL_065f: Unknown result type (might be due to invalid IL or missing references)
		//IL_06df: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e9: Expected O, but got Unknown
		//IL_0726: Unknown result type (might be due to invalid IL or missing references)
		//IL_0863: Unknown result type (might be due to invalid IL or missing references)
		//IL_086d: Expected O, but got Unknown
		//IL_0914: Unknown result type (might be due to invalid IL or missing references)
		//IL_091e: Expected O, but got Unknown
		//IL_0a71: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a7b: Expected O, but got Unknown
		//IL_0ab4: Unknown result type (might be due to invalid IL or missing references)
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(UnitSelection));
		ButtonToggle_ShowSpaceUnit_Unassigned = new Button();
		ButtonToggle_ShowLandUnit_Unassigned = new Button();
		ButtonToggle_ShowAirUnit_Unassigned = new Button();
		ButtonToggle_ShowNavalUnit_Unassigned = new Button();
		LV_Units = new DarkListView();
		Button_Filter = new DarkUIButton();
		TB_Filter = new DarkUITextBox();
		ButtonCancel = new DarkUIButton();
		Button_Confirm = new DarkUIButton();
		FlowLayoutPanel1 = new FlowLayoutPanel();
		ButtonToggle_ShowStandardZone = new Button();
		ButtonToggle_ShowRP = new Button();
		FlowLayoutPanel2 = new FlowLayoutPanel();
		Button_Action_Delete = new DarkUIButton();
		((Control)FlowLayoutPanel1).SuspendLayout();
		((Control)FlowLayoutPanel2).SuspendLayout();
		((Control)this).SuspendLayout();
		((ButtonBase)ButtonToggle_ShowSpaceUnit_Unassigned).BackColor = Color.FromArgb(64, 64, 64);
		((Control)ButtonToggle_ShowSpaceUnit_Unassigned).BackgroundImage = (Image)(object)Resources.sattelite;
		((Control)ButtonToggle_ShowSpaceUnit_Unassigned).BackgroundImageLayout = (ImageLayout)3;
		((ButtonBase)ButtonToggle_ShowSpaceUnit_Unassigned).FlatAppearance.BorderColor = Color.LimeGreen;
		((ButtonBase)ButtonToggle_ShowSpaceUnit_Unassigned).FlatStyle = (FlatStyle)0;
		((Control)ButtonToggle_ShowSpaceUnit_Unassigned).Location = new Point(159, 3);
		((Control)ButtonToggle_ShowSpaceUnit_Unassigned).Name = "ButtonToggle_ShowSpaceUnit_Unassigned";
		((Control)ButtonToggle_ShowSpaceUnit_Unassigned).Size = new Size(46, 19);
		((Control)ButtonToggle_ShowSpaceUnit_Unassigned).TabIndex = 36;
		((ButtonBase)ButtonToggle_ShowSpaceUnit_Unassigned).UseVisualStyleBackColor = false;
		((ButtonBase)ButtonToggle_ShowLandUnit_Unassigned).BackColor = Color.FromArgb(64, 64, 64);
		((Control)ButtonToggle_ShowLandUnit_Unassigned).BackgroundImage = (Image)(object)Resources.Tank1;
		((Control)ButtonToggle_ShowLandUnit_Unassigned).BackgroundImageLayout = (ImageLayout)3;
		((ButtonBase)ButtonToggle_ShowLandUnit_Unassigned).FlatAppearance.BorderColor = Color.LimeGreen;
		((ButtonBase)ButtonToggle_ShowLandUnit_Unassigned).FlatStyle = (FlatStyle)0;
		((Control)ButtonToggle_ShowLandUnit_Unassigned).Location = new Point(3, 3);
		((Control)ButtonToggle_ShowLandUnit_Unassigned).Name = "ButtonToggle_ShowLandUnit_Unassigned";
		((Control)ButtonToggle_ShowLandUnit_Unassigned).Size = new Size(46, 19);
		((Control)ButtonToggle_ShowLandUnit_Unassigned).TabIndex = 35;
		((ButtonBase)ButtonToggle_ShowLandUnit_Unassigned).UseVisualStyleBackColor = false;
		((ButtonBase)ButtonToggle_ShowAirUnit_Unassigned).BackColor = Color.FromArgb(64, 64, 64);
		((Control)ButtonToggle_ShowAirUnit_Unassigned).BackgroundImage = (Image)(object)Resources.Aircraft;
		((Control)ButtonToggle_ShowAirUnit_Unassigned).BackgroundImageLayout = (ImageLayout)3;
		((ButtonBase)ButtonToggle_ShowAirUnit_Unassigned).FlatAppearance.BorderColor = Color.LimeGreen;
		((ButtonBase)ButtonToggle_ShowAirUnit_Unassigned).FlatStyle = (FlatStyle)0;
		((Control)ButtonToggle_ShowAirUnit_Unassigned).Location = new Point(107, 3);
		((Control)ButtonToggle_ShowAirUnit_Unassigned).Name = "ButtonToggle_ShowAirUnit_Unassigned";
		((Control)ButtonToggle_ShowAirUnit_Unassigned).Size = new Size(46, 19);
		((Control)ButtonToggle_ShowAirUnit_Unassigned).TabIndex = 34;
		((ButtonBase)ButtonToggle_ShowAirUnit_Unassigned).UseVisualStyleBackColor = false;
		((ButtonBase)ButtonToggle_ShowNavalUnit_Unassigned).BackColor = Color.FromArgb(64, 64, 64);
		((Control)ButtonToggle_ShowNavalUnit_Unassigned).BackgroundImage = (Image)(object)Resources.Ship;
		((Control)ButtonToggle_ShowNavalUnit_Unassigned).BackgroundImageLayout = (ImageLayout)3;
		((ButtonBase)ButtonToggle_ShowNavalUnit_Unassigned).FlatAppearance.BorderColor = Color.LimeGreen;
		((ButtonBase)ButtonToggle_ShowNavalUnit_Unassigned).FlatStyle = (FlatStyle)0;
		((Control)ButtonToggle_ShowNavalUnit_Unassigned).Location = new Point(55, 3);
		((Control)ButtonToggle_ShowNavalUnit_Unassigned).Name = "ButtonToggle_ShowNavalUnit_Unassigned";
		((Control)ButtonToggle_ShowNavalUnit_Unassigned).Size = new Size(46, 19);
		((Control)ButtonToggle_ShowNavalUnit_Unassigned).TabIndex = 33;
		((ButtonBase)ButtonToggle_ShowNavalUnit_Unassigned).UseVisualStyleBackColor = false;
		((Control)LV_Units).Anchor = (AnchorStyles)13;
		((Control)LV_Units).BackColor = Color.FromArgb(40, 43, 45);
		((Control)LV_Units).Location = new Point(12, 37);
		((Control)LV_Units).MinimumSize = new Size(401, 268);
		((Control)LV_Units).Name = "LV_Units";
		LV_Units.RelatedInfos = null;
		((Control)LV_Units).Size = new Size(520, 268);
		((Control)LV_Units).TabIndex = 41;
		((Control)LV_Units).Text = "LV_Units";
		((Control)Button_Filter).Anchor = (AnchorStyles)9;
		((ButtonBase)Button_Filter).BackColor = Color.Transparent;
		((Control)Button_Filter).Font = new Font("Segoe UI", 8.25f);
		((Control)Button_Filter).ForeColor = SystemColors.Control;
		((Control)Button_Filter).Location = new Point(505, 12);
		((Control)Button_Filter).Name = "Button_Filter";
		((Control)Button_Filter).Padding = new Padding(5);
		Button_Filter.RoundRadius = 0;
		((Control)Button_Filter).Size = new Size(27, 19);
		((Control)Button_Filter).TabIndex = 43;
		Button_Filter.Text = "Go";
		TB_Filter.AutoCompleteCustomSource = null;
		TB_Filter.AutoCompleteMode = (AutoCompleteMode)0;
		TB_Filter.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TB_Filter).BackColor = Color.Transparent;
		((Control)TB_Filter).ForeColor = Color.FromArgb(189, 189, 189);
		TB_Filter.Image = null;
		TB_Filter.Lines = null;
		((Control)TB_Filter).Location = new Point(359, 12);
		TB_Filter.MaxLength = 32767;
		TB_Filter.Multiline = false;
		((Control)TB_Filter).Name = "TB_Filter";
		TB_Filter.ReadOnly = false;
		TB_Filter.ScrollBars = (ScrollBars)0;
		TB_Filter.SelectionStart = 0;
		((Control)TB_Filter).Size = new Size(140, 19);
		((Control)TB_Filter).TabIndex = 42;
		TB_Filter.TextAlign = (HorizontalAlignment)0;
		TB_Filter.UseSystemPasswordChar = false;
		TB_Filter.WatermarkText = "Filter by name, class, side.";
		TB_Filter.WordWrap = false;
		((Control)ButtonCancel).Anchor = (AnchorStyles)14;
		((ButtonBase)ButtonCancel).BackColor = Color.Transparent;
		((Button)ButtonCancel).DialogResult = (DialogResult)2;
		((Control)ButtonCancel).Font = new Font("Segoe UI", 8.25f);
		((Control)ButtonCancel).ForeColor = SystemColors.Control;
		((Control)ButtonCancel).Location = new Point(74, 3);
		((Control)ButtonCancel).Name = "ButtonCancel";
		((Control)ButtonCancel).Padding = new Padding(5);
		ButtonCancel.RoundRadius = 0;
		((Control)ButtonCancel).Size = new Size(75, 28);
		((Control)ButtonCancel).TabIndex = 40;
		ButtonCancel.Text = "Cancel";
		((Control)Button_Confirm).Anchor = (AnchorStyles)14;
		((ButtonBase)Button_Confirm).BackColor = Color.Transparent;
		((Button)Button_Confirm).DialogResult = (DialogResult)1;
		((Control)Button_Confirm).Font = new Font("Segoe UI", 8.25f);
		((Control)Button_Confirm).ForeColor = SystemColors.Control;
		((Control)Button_Confirm).Location = new Point(155, 3);
		((Control)Button_Confirm).Name = "Button_Confirm";
		((Control)Button_Confirm).Padding = new Padding(5);
		Button_Confirm.RoundRadius = 0;
		((Control)Button_Confirm).Size = new Size(352, 28);
		((Control)Button_Confirm).TabIndex = 38;
		Button_Confirm.Text = "Confirm";
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)ButtonToggle_ShowLandUnit_Unassigned);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)ButtonToggle_ShowNavalUnit_Unassigned);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)ButtonToggle_ShowAirUnit_Unassigned);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)ButtonToggle_ShowSpaceUnit_Unassigned);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)ButtonToggle_ShowStandardZone);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)ButtonToggle_ShowRP);
		((Control)FlowLayoutPanel1).Location = new Point(13, 10);
		((Control)FlowLayoutPanel1).Name = "FlowLayoutPanel1";
		((Control)FlowLayoutPanel1).Size = new Size(317, 25);
		((Control)FlowLayoutPanel1).TabIndex = 44;
		((ButtonBase)ButtonToggle_ShowStandardZone).BackColor = Color.FromArgb(64, 64, 64);
		((Control)ButtonToggle_ShowStandardZone).BackgroundImage = (Image)componentResourceManager.GetObject("ButtonToggle_ShowStandardZone.BackgroundImage");
		((Control)ButtonToggle_ShowStandardZone).BackgroundImageLayout = (ImageLayout)3;
		((ButtonBase)ButtonToggle_ShowStandardZone).FlatAppearance.BorderColor = Color.LimeGreen;
		((ButtonBase)ButtonToggle_ShowStandardZone).FlatStyle = (FlatStyle)0;
		((Control)ButtonToggle_ShowStandardZone).Location = new Point(211, 3);
		((Control)ButtonToggle_ShowStandardZone).Name = "ButtonToggle_ShowStandardZone";
		((Control)ButtonToggle_ShowStandardZone).Size = new Size(46, 19);
		((Control)ButtonToggle_ShowStandardZone).TabIndex = 38;
		((ButtonBase)ButtonToggle_ShowStandardZone).UseVisualStyleBackColor = false;
		((ButtonBase)ButtonToggle_ShowRP).BackColor = Color.FromArgb(64, 64, 64);
		((Control)ButtonToggle_ShowRP).BackgroundImage = (Image)componentResourceManager.GetObject("ButtonToggle_ShowRP.BackgroundImage");
		((Control)ButtonToggle_ShowRP).BackgroundImageLayout = (ImageLayout)3;
		((ButtonBase)ButtonToggle_ShowRP).FlatAppearance.BorderColor = Color.LimeGreen;
		((ButtonBase)ButtonToggle_ShowRP).FlatStyle = (FlatStyle)0;
		((Control)ButtonToggle_ShowRP).Location = new Point(263, 3);
		((Control)ButtonToggle_ShowRP).Name = "ButtonToggle_ShowRP";
		((Control)ButtonToggle_ShowRP).Size = new Size(47, 19);
		((Control)ButtonToggle_ShowRP).TabIndex = 37;
		((ButtonBase)ButtonToggle_ShowRP).UseVisualStyleBackColor = false;
		((Control)FlowLayoutPanel2).Anchor = (AnchorStyles)13;
		((Control)FlowLayoutPanel2).Controls.Add((Control)(object)Button_Action_Delete);
		((Control)FlowLayoutPanel2).Controls.Add((Control)(object)ButtonCancel);
		((Control)FlowLayoutPanel2).Controls.Add((Control)(object)Button_Confirm);
		((Control)FlowLayoutPanel2).Location = new Point(12, 311);
		((Control)FlowLayoutPanel2).Name = "FlowLayoutPanel2";
		((Control)FlowLayoutPanel2).Size = new Size(520, 33);
		((Control)FlowLayoutPanel2).TabIndex = 45;
		((Control)Button_Action_Delete).Anchor = (AnchorStyles)14;
		((ButtonBase)Button_Action_Delete).BackColor = Color.Transparent;
		((Button)Button_Action_Delete).DialogResult = (DialogResult)1;
		((Control)Button_Action_Delete).Font = new Font("Segoe UI", 8.25f);
		((Control)Button_Action_Delete).ForeColor = SystemColors.Control;
		((Control)Button_Action_Delete).Location = new Point(3, 3);
		((Control)Button_Action_Delete).Name = "Button_Action_Delete";
		((Control)Button_Action_Delete).Padding = new Padding(5);
		Button_Action_Delete.RoundRadius = 0;
		((Control)Button_Action_Delete).Size = new Size(65, 28);
		((Control)Button_Action_Delete).TabIndex = 41;
		Button_Action_Delete.Text = "Delete";
		((Form)this).AcceptButton = (IButtonControl)(object)Button_Confirm;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).BackColor = Color.FromArgb(60, 63, 65);
		((Form)this).CancelButton = (IButtonControl)(object)ButtonCancel;
		((Form)this).ClientSize = new Size(544, 356);
		((Control)this).Controls.Add((Control)(object)FlowLayoutPanel2);
		((Control)this).Controls.Add((Control)(object)FlowLayoutPanel1);
		((Control)this).Controls.Add((Control)(object)Button_Filter);
		((Control)this).Controls.Add((Control)(object)TB_Filter);
		((Control)this).Controls.Add((Control)(object)LV_Units);
		((Form)this).MinimumSize = new Size(441, 343);
		((Control)this).Name = "UnitSelection";
		((Form)this).Text = "Unit Selection";
		((Control)FlowLayoutPanel1).ResumeLayout(false);
		((Control)FlowLayoutPanel2).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
	}

	public static void CallDialogWithUnits(List<ActiveUnit> InitialUnits, bool MultipleSelection, ref List<ActiveUnit> SelectedUnits)
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Invalid comparison between Unknown and I4
		UnitSelection unitSelection = new UnitSelection();
		unitSelection.Configuration = UnitSelectionConfig.DefaultUnitSelection();
		((Control)unitSelection.Button_Action_Delete).Visible = false;
		unitSelection.LV_Units.MultiSelect = MultipleSelection;
		unitSelection.list_0.Add(Client.CurrentSide);
		unitSelection.RefreshFilter();
		unitSelection.RefreshUnitList(InitialUnits);
		if ((int)((Form)unitSelection).ShowDialog() == 1)
		{
			List<ReferencePoint> SelectedRP = null;
			List<Zone> SelectedZone = null;
			unitSelection.FetchSelectedUnits(ref SelectedUnits, ref SelectedRP, ref SelectedZone);
		}
	}

	public static void CallDialog(List<Side> _Side, ref ActiveUnit SelectedUnits, ref ReferencePoint referencePoint_0, ref Zone SelectedStandardZones, UnitSelectionConfig _Configuration = null, bool ShowDeleteButton = true)
	{
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Invalid comparison between Unknown and I4
		UnitSelection unitSelection = new UnitSelection();
		if (_Configuration != null)
		{
			unitSelection.Configuration = _Configuration;
		}
		else
		{
			unitSelection.Configuration = UnitSelectionConfig.DefaultUnitSelection();
		}
		((Control)unitSelection.Button_Action_Delete).Visible = Client.CurrentGame.GameMode == Game._GameMode.ScenEdit || Client.CurrentGame.GameMode == Game._GameMode.MultiplayerScenEdit;
		if (!ShowDeleteButton)
		{
			((Control)unitSelection.Button_Action_Delete).Visible = false;
		}
		unitSelection.LV_Units.MultiSelect = false;
		unitSelection.list_0 = _Side;
		unitSelection.RefreshFilter();
		unitSelection.RefreshUnitList();
		if ((int)((Form)unitSelection).ShowDialog() == 1)
		{
			unitSelection.FetchSelectedUnits(ref SelectedUnits, ref referencePoint_0, ref SelectedStandardZones);
		}
	}

	public static void CallDialog(List<Side> _Side, bool MultipleSelection, ref List<ActiveUnit> SelectedUnits, ref List<ReferencePoint> list_1, ref List<Zone> SelectedStandardZones, UnitSelectionConfig _Configuration = null, bool ShowDeleteButton = true)
	{
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Invalid comparison between Unknown and I4
		UnitSelection unitSelection = new UnitSelection();
		if (_Configuration == null)
		{
			unitSelection.Configuration = UnitSelectionConfig.DefaultUnitSelection();
		}
		else
		{
			unitSelection.Configuration = _Configuration;
		}
		((Control)unitSelection.Button_Action_Delete).Visible = Client.CurrentGame.GameMode == Game._GameMode.ScenEdit || Client.CurrentGame.GameMode == Game._GameMode.MultiplayerScenEdit;
		if (!ShowDeleteButton)
		{
			((Control)unitSelection.Button_Action_Delete).Visible = false;
		}
		unitSelection.LV_Units.MultiSelect = MultipleSelection;
		unitSelection.list_0 = _Side;
		unitSelection.RefreshFilter();
		unitSelection.RefreshUnitList();
		if ((int)((Form)unitSelection).ShowDialog() == 1)
		{
			unitSelection.FetchSelectedUnits(ref SelectedUnits, ref list_1, ref SelectedStandardZones);
		}
	}

	public static void CallDialog(Side _Side, bool MultipleSelection, ref List<ActiveUnit> SelectedUnits, ref List<ReferencePoint> list_1, ref List<Zone> SelectedStandardZones, UnitSelectionConfig _Configuration = null, bool ShowDeleteButton = true)
	{
		CallDialog(new List<Side> { _Side }, MultipleSelection, ref SelectedUnits, ref list_1, ref SelectedStandardZones, _Configuration, ShowDeleteButton);
	}

	public static void CallDialog(bool MultipleSelection, ref List<ActiveUnit> SelectedUnits, ref List<ReferencePoint> list_1, ref List<Zone> SelectedStandardZones, UnitSelectionConfig _Configuration = null, bool ShowDeleteButton = true)
	{
		CallDialog(new List<Side> { Client.CurrentSide }, MultipleSelection, ref SelectedUnits, ref list_1, ref SelectedStandardZones, _Configuration, ShowDeleteButton);
	}

	public void FetchSelectedUnits(ref List<ActiveUnit> SelectedActiveUnits, ref List<ReferencePoint> SelectedRP, ref List<Zone> SelectedZone)
	{
		SelectedActiveUnits = new List<ActiveUnit>();
		SelectedRP = new List<ReferencePoint>();
		SelectedZone = new List<Zone>();
		foreach (DarkListItem selectedItem in LV_Units.SelectedItems)
		{
			if (selectedItem.Tag == null)
			{
				continue;
			}
			if (selectedItem.Tag is ActiveUnit)
			{
				ActiveUnit activeUnit = (ActiveUnit)selectedItem.Tag;
				if (!activeUnit.IsMorituri)
				{
					SelectedActiveUnits.Add(activeUnit);
				}
			}
			else if (!(selectedItem.Tag is ReferencePoint))
			{
				if (selectedItem.Tag is Zone)
				{
					Zone item = (Zone)selectedItem.Tag;
					SelectedZone.Add(item);
				}
			}
			else
			{
				ReferencePoint item2 = (ReferencePoint)selectedItem.Tag;
				SelectedRP.Add(item2);
			}
		}
	}

	public void FetchSelectedUnits(ref ActiveUnit SelectedActiveUnit, ref ReferencePoint SelectedRP, ref Zone SelectedZone)
	{
		if (LV_Units.SelectedItems.Count == 0)
		{
			return;
		}
		DarkListItem darkListItem = LV_Units.SelectedItems[0];
		if (darkListItem.Tag != null)
		{
			if (darkListItem.Tag is ActiveUnit)
			{
				SelectedActiveUnit = (ActiveUnit)darkListItem.Tag;
			}
			else if (darkListItem.Tag is ReferencePoint)
			{
				SelectedRP = (ReferencePoint)darkListItem.Tag;
			}
			else if (darkListItem.Tag is Zone)
			{
				SelectedZone = (Zone)darkListItem.Tag;
			}
		}
	}

	private bool method_0(ActiveUnit activeUnit_0, string string_0, bool bool_7 = true)
	{
		if (string.IsNullOrEmpty(string_0))
		{
			return true;
		}
		if (bool_7)
		{
			string[] array = string_0.Split(new char[1] { ' ' });
			foreach (string value in array)
			{
				if (!string.IsNullOrWhiteSpace(value) && !activeUnit_0.Name.ToLower().Contains(value) && !activeUnit_0.UnitClass.ToLower().Contains(value) && !activeUnit_0.get_UnitSide(SetSideOnly: false).Name.ToLower().Contains(value))
				{
					return false;
				}
			}
			return true;
		}
		if (activeUnit_0.Name.ToLower().Contains(string_0))
		{
			return true;
		}
		if (!activeUnit_0.UnitClass.ToLower().Contains(string_0))
		{
			if (activeUnit_0.get_UnitSide(SetSideOnly: false).Name.ToLower().Contains(string_0))
			{
				return true;
			}
			return false;
		}
		return true;
	}

	public void RefreshFilter()
	{
		((Control)ButtonToggle_ShowLandUnit_Unassigned).Visible = false;
		((Control)ButtonToggle_ShowAirUnit_Unassigned).Visible = false;
		((Control)ButtonToggle_ShowNavalUnit_Unassigned).Visible = false;
		((Control)ButtonToggle_ShowSpaceUnit_Unassigned).Visible = false;
		((Control)ButtonToggle_ShowStandardZone).Visible = false;
		((Control)ButtonToggle_ShowRP).Visible = false;
		bool_0 = false;
		bool_1 = false;
		bool_2 = false;
		bool_3 = false;
		bool_4 = false;
		bool_5 = false;
		bool_6 = false;
		if (Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsAircraft) != true)
		{
			if (Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsBoat) != true && Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsShip) != true)
			{
				if (Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsFacility) != true && Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsMobileGroundUnit) != true)
				{
					if (Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsSatellite) != true)
					{
						if (Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsRP) == true)
						{
							((Control)ButtonToggle_ShowRP).Visible = true;
							bool_5 = true;
						}
						else if (Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsStandardZone) != true)
						{
							if (Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsGroup) != true)
							{
								if (Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsAirbase) == true)
								{
									bool_4 = true;
								}
								if (Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsAirbase) != true && Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsDock) != true)
								{
									if (Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsAggregateGroundUnit_HQ) != true)
									{
										if (Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsCargoMissionDestination) == true)
										{
											((Control)ButtonToggle_ShowNavalUnit_Unassigned).Visible = true;
											bool_2 = true;
											((Control)ButtonToggle_ShowLandUnit_Unassigned).Visible = true;
											bool_1 = true;
											return;
										}
										((Control)ButtonToggle_ShowLandUnit_Unassigned).Visible = true;
										((Control)ButtonToggle_ShowAirUnit_Unassigned).Visible = true;
										((Control)ButtonToggle_ShowNavalUnit_Unassigned).Visible = true;
										((Control)ButtonToggle_ShowSpaceUnit_Unassigned).Visible = true;
										((Control)ButtonToggle_ShowStandardZone).Visible = true;
										((Control)ButtonToggle_ShowRP).Visible = true;
										bool_0 = true;
										bool_1 = true;
										bool_2 = true;
										bool_3 = true;
										bool_5 = true;
										bool_6 = true;
										bool? conditionValue = Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsAircraft);
										if (((!conditionValue) ?? conditionValue) != true)
										{
											bool? conditionValue2 = Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsBoat);
											conditionValue = (!conditionValue2) ?? conditionValue2;
											if (conditionValue ?? true)
											{
												conditionValue2 = Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsShip);
												if (((!conditionValue2) ?? conditionValue2) == true && conditionValue.HasValue)
												{
													((Control)ButtonToggle_ShowNavalUnit_Unassigned).Visible = false;
													bool_2 = false;
													return;
												}
											}
											bool? conditionValue3 = Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsFacility);
											bool? flag;
											conditionValue3 = (flag = (!conditionValue3) ?? conditionValue3);
											bool? obj;
											bool? flag2;
											if (conditionValue3.HasValue && flag != true)
											{
												obj = false;
											}
											else
											{
												conditionValue3 = Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsMobileGroundUnit);
												conditionValue3 = (flag2 = (!conditionValue3) ?? conditionValue3);
												obj = ((!conditionValue3.HasValue) ? ((bool?)null) : ((flag2 == true) & flag));
											}
											conditionValue2 = obj;
											flag2 = obj;
											bool? obj2;
											if (flag2.HasValue && conditionValue2 != true)
											{
												obj2 = false;
											}
											else
											{
												flag2 = Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsAirbase);
												bool? flag3;
												flag2 = (flag3 = (!flag2) ?? flag2);
												obj2 = ((!flag2.HasValue) ? ((bool?)null) : ((flag3 == true) & conditionValue2));
											}
											conditionValue = obj2;
											if (conditionValue ?? true)
											{
												bool? flag3 = Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsDock);
												if (((!flag3) ?? flag3) == true && conditionValue.HasValue)
												{
													((Control)ButtonToggle_ShowLandUnit_Unassigned).Visible = false;
													bool_1 = false;
													return;
												}
											}
											conditionValue = Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsSatellite);
											if (((!conditionValue) ?? conditionValue) == true)
											{
												((Control)ButtonToggle_ShowSpaceUnit_Unassigned).Visible = false;
												bool_3 = false;
												return;
											}
											conditionValue = Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsStandardZone);
											if (((!conditionValue) ?? conditionValue) == true)
											{
												((Control)ButtonToggle_ShowStandardZone).Visible = false;
												bool_6 = false;
												return;
											}
											conditionValue = Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsRP);
											if (((!conditionValue) ?? conditionValue) != true)
											{
												conditionValue = Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsGroup);
												if (((!conditionValue) ?? conditionValue) == true)
												{
													bool_4 = false;
												}
											}
											else
											{
												((Control)ButtonToggle_ShowRP).Visible = false;
												bool_5 = false;
											}
										}
										else
										{
											((Control)ButtonToggle_ShowAirUnit_Unassigned).Visible = false;
											bool_0 = false;
										}
									}
									else
									{
										((Control)ButtonToggle_ShowLandUnit_Unassigned).Visible = true;
										bool_1 = true;
									}
								}
								else
								{
									((Control)ButtonToggle_ShowNavalUnit_Unassigned).Visible = true;
									bool_2 = true;
									((Control)ButtonToggle_ShowLandUnit_Unassigned).Visible = true;
									bool_1 = true;
								}
							}
							else
							{
								bool_4 = true;
							}
						}
						else
						{
							((Control)ButtonToggle_ShowStandardZone).Visible = true;
							bool_6 = true;
						}
					}
					else
					{
						((Control)ButtonToggle_ShowSpaceUnit_Unassigned).Visible = true;
						bool_3 = true;
					}
				}
				else
				{
					((Control)ButtonToggle_ShowLandUnit_Unassigned).Visible = true;
					bool_1 = true;
				}
			}
			else
			{
				((Control)ButtonToggle_ShowNavalUnit_Unassigned).Visible = true;
				bool_2 = true;
			}
		}
		else
		{
			((Control)ButtonToggle_ShowAirUnit_Unassigned).Visible = true;
			bool_0 = true;
		}
	}

	public void RefreshUnitList(List<ActiveUnit> Units)
	{
		LV_Units.Items.Clear();
		string text = TB_Filter.Text.ToLower();
		foreach (ActiveUnit Unit in Units)
		{
			if ((!Unit.IsAircraft || bool_0) && ((!Unit.IsFacility && !Unit.IsMobileGroundUnit) || bool_1) && ((!Unit.IsShip && !Unit.IsBoat) || bool_2) && (!Unit.IsSatellite || bool_3) && (string.IsNullOrWhiteSpace(text) || method_0(Unit, text)) && Configuration.FulfillConditions(Unit))
			{
				DarkListItem darkListItem = ((!Unit.IsGroup) ? new DarkListItem(Unit.Name + " - " + Unit.UnitClass) : new DarkListItem(Unit.Name + " - " + Unit.SubTypeDescription));
				darkListItem.Tag = Unit;
				LV_Units.Items.Add(darkListItem);
			}
		}
		((Control)this).Refresh();
	}

	public void RefreshUnitList()
	{
		LV_Units.Items.Clear();
		string text = TB_Filter.Text.ToLower();
		foreach (Side item in list_0)
		{
			foreach (ActiveUnit unit in item.Units)
			{
				if (unit.IsWeapon || (unit.IsAircraft && !bool_0) || ((unit.IsFacility || unit.IsMobileGroundUnit) && !bool_1) || ((unit.IsShip || unit.IsBoat) && !bool_2) || (unit.IsSatellite && !bool_3) || (unit.IsGroup && !bool_4) || (!string.IsNullOrWhiteSpace(text) && !method_0(unit, text)) || !Configuration.FulfillConditions(unit))
				{
					continue;
				}
				DarkListItem darkListItem;
				if (list_0.Count <= 1)
				{
					darkListItem = ((!unit.IsGroup) ? new DarkListItem(unit.Name + " - " + unit.UnitClass) : new DarkListItem(unit.Name + " - " + unit.SubTypeDescription));
				}
				else
				{
					darkListItem = new DarkListItem("[" + unit.get_UnitSide(SetSideOnly: false).Name + "] " + unit.Name + " - " + unit.UnitClass);
					if (unit.get_UnitSide(SetSideOnly: false).AssignedFixedColor.HasValue)
					{
						darkListItem.TextColor = unit.get_UnitSide(SetSideOnly: false).AssignedFixedColor.Value;
					}
				}
				darkListItem.Tag = unit;
				LV_Units.Items.Add(darkListItem);
			}
			if (bool_5)
			{
				foreach (ReferencePoint refPoint in item.RefPoints)
				{
					DarkListItem darkListItem2;
					if (list_0.Count > 1)
					{
						darkListItem2 = new DarkListItem("[" + item.Name + "] " + refPoint.Name);
						if (item.AssignedFixedColor.HasValue)
						{
							darkListItem2.TextColor = item.AssignedFixedColor.Value;
						}
					}
					else
					{
						darkListItem2 = new DarkListItem(refPoint.Name);
					}
					darkListItem2.Tag = refPoint;
					LV_Units.Items.Add(darkListItem2);
				}
			}
			if (!bool_6)
			{
				continue;
			}
			foreach (Zone standardZone in item.StandardZones)
			{
				DarkListItem darkListItem3;
				if (list_0.Count > 1)
				{
					darkListItem3 = new DarkListItem("[" + item.Name + "] " + standardZone.Description);
					if (item.AssignedFixedColor.HasValue)
					{
						darkListItem3.TextColor = item.AssignedFixedColor.Value;
					}
				}
				else
				{
					darkListItem3 = new DarkListItem(standardZone.Description);
				}
				darkListItem3.Tag = standardZone;
				LV_Units.Items.Add(darkListItem3);
			}
		}
		((Control)this).Refresh();
	}

	private void method_1(object sender, EventArgs e)
	{
		method_5();
	}

	private void method_2(object sender, EventArgs e)
	{
		method_6();
	}

	private void method_3(object sender, EventArgs e)
	{
		method_7();
	}

	private void method_4(object sender, EventArgs e)
	{
		method_8();
	}

	private void method_5(int int_0 = -1)
	{
		if (int_0 == -1)
		{
			bool_2 = !bool_2;
		}
		else
		{
			bool_2 = int_0 != 0;
		}
		if (bool_2)
		{
			((ButtonBase)ButtonToggle_ShowNavalUnit_Unassigned).FlatAppearance.BorderColor = Color.Lime;
		}
		else
		{
			((ButtonBase)ButtonToggle_ShowNavalUnit_Unassigned).FlatAppearance.BorderColor = Color.Red;
		}
		if (int_0 == -1)
		{
			RefreshUnitList();
		}
	}

	private void method_6(int int_0 = -1)
	{
		if (int_0 == -1)
		{
			bool_0 = !bool_0;
		}
		else
		{
			bool_0 = int_0 != 0;
		}
		if (!bool_0)
		{
			((ButtonBase)ButtonToggle_ShowAirUnit_Unassigned).FlatAppearance.BorderColor = Color.Red;
		}
		else
		{
			((ButtonBase)ButtonToggle_ShowAirUnit_Unassigned).FlatAppearance.BorderColor = Color.Lime;
		}
		if (int_0 == -1)
		{
			RefreshUnitList();
		}
	}

	private void method_7(int int_0 = -1)
	{
		if (int_0 == -1)
		{
			bool_1 = !bool_1;
		}
		else
		{
			bool_1 = int_0 != 0;
		}
		if (!bool_1)
		{
			((ButtonBase)ButtonToggle_ShowLandUnit_Unassigned).FlatAppearance.BorderColor = Color.Red;
		}
		else
		{
			((ButtonBase)ButtonToggle_ShowLandUnit_Unassigned).FlatAppearance.BorderColor = Color.Lime;
		}
		if (int_0 == -1)
		{
			RefreshUnitList();
		}
	}

	private void method_8(int int_0 = -1)
	{
		if (int_0 == -1)
		{
			bool_3 = !bool_3;
		}
		else
		{
			bool_3 = int_0 != 0;
		}
		if (bool_3)
		{
			((ButtonBase)ButtonToggle_ShowSpaceUnit_Unassigned).FlatAppearance.BorderColor = Color.Lime;
		}
		else
		{
			((ButtonBase)ButtonToggle_ShowSpaceUnit_Unassigned).FlatAppearance.BorderColor = Color.Red;
		}
		if (int_0 == -1)
		{
			RefreshUnitList();
		}
	}

	private void method_9(int int_0 = -1)
	{
		if (int_0 == -1)
		{
			bool_5 = !bool_5;
		}
		else
		{
			bool_5 = int_0 != 0;
		}
		if (bool_5)
		{
			((ButtonBase)ButtonToggle_ShowRP).FlatAppearance.BorderColor = Color.Lime;
		}
		else
		{
			((ButtonBase)ButtonToggle_ShowRP).FlatAppearance.BorderColor = Color.Red;
		}
		if (int_0 == -1)
		{
			RefreshUnitList();
		}
	}

	private void method_10(int int_0 = -1)
	{
		if (int_0 == -1)
		{
			bool_6 = !bool_6;
		}
		else
		{
			bool_6 = int_0 != 0;
		}
		if (bool_6)
		{
			((ButtonBase)ButtonToggle_ShowStandardZone).FlatAppearance.BorderColor = Color.Lime;
		}
		else
		{
			((ButtonBase)ButtonToggle_ShowStandardZone).FlatAppearance.BorderColor = Color.Red;
		}
		if (int_0 == -1)
		{
			RefreshUnitList();
		}
	}

	private void method_11(object sender, EventArgs e)
	{
		if (LV_Units.SelectedItems.Count == 0)
		{
			return;
		}
		if (!(LV_Units.SelectedItems.ElementAt(0).Tag is ActiveUnit))
		{
			if (LV_Units.SelectedItems.ElementAt(0).Tag is ReferencePoint)
			{
				ReferencePoint referencePoint = (ReferencePoint)LV_Units.SelectedItems.ElementAt(0).Tag;
				MyProject.Forms.MainForm.set_MapCenter(MustRender: true, new GeoPoint(referencePoint.Longitude, referencePoint.Latitude));
			}
			else if (LV_Units.SelectedItems.ElementAt(0).Tag is Zone)
			{
				Zone zone = (Zone)LV_Units.SelectedItems.ElementAt(0).Tag;
				if (zone.Area.Count > 0)
				{
					MyProject.Forms.MainForm.set_MapCenter(MustRender: true, new GeoPoint(zone.Area.ElementAt(0).Longitude, zone.Area.ElementAt(0).Latitude));
				}
			}
		}
		else
		{
			ActiveUnit activeUnit = (ActiveUnit)LV_Units.SelectedItems.ElementAt(0).Tag;
			MyProject.Forms.MainForm.set_MapCenter(MustRender: true, new GeoPoint(activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
		}
		Button_Confirm.Text = "Confirm (" + LV_Units.SelectedItems.Count + ")";
		((Control)this).Refresh();
	}

	private void method_12(object sender, EventArgs e)
	{
		RefreshUnitList();
	}

	private void method_13(object sender, EventArgs e)
	{
		((Form)this).DialogResult = (DialogResult)1;
	}

	private void method_14(object sender, EventArgs e)
	{
		((Form)this).DialogResult = (DialogResult)2;
	}

	private void method_15(object sender, EventArgs e)
	{
		List<ActiveUnit> SelectedActiveUnits = default(List<ActiveUnit>);
		List<ReferencePoint> SelectedRP = default(List<ReferencePoint>);
		List<Zone> SelectedZone = default(List<Zone>);
		FetchSelectedUnits(ref SelectedActiveUnits, ref SelectedRP, ref SelectedZone);
		foreach (ActiveUnit item in SelectedActiveUnits)
		{
			item.Destroy(ScenEditAction: true, Module_ActiveUnit.IsAimpointFacility(item), DestroyUnitNow: true, "Editor", null, RegisterAsLosses: false);
		}
		foreach (ReferencePoint item2 in SelectedRP)
		{
			_ = item2;
		}
		foreach (Zone item3 in SelectedZone)
		{
			_ = item3;
		}
		RefreshUnitList();
	}

	private void method_16(object sender, EventArgs e)
	{
		method_9();
	}

	private void method_17(object sender, EventArgs e)
	{
		method_10();
	}

	static UnitSelection()
	{
		Class72.smethod_20();
	}
}
