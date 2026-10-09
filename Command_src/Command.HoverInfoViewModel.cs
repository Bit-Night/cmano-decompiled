using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using Command.My;
using ExWorldWind;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotObfuscate]
[DoNotPrune]
[DoNotPruneType]
public sealed class HoverInfoViewModel : CommandViewModel
{
	[CompilerGenerated]
	internal sealed class _Closure$__290-0
	{
		public int $VB$Local_temp_AIR_LR;

		public int $VB$Local_temp_AIR_MR;

		public int $VB$Local_temp_AIR_SR;

		public int $VB$Local_temp_SURF_LR;

		public int $VB$Local_temp_SURF_MR;

		public int $VB$Local_temp_SURF_SR;

		public int $VB$Local_temp_LAND_LR;

		public int $VB$Local_temp_LAND_MR;

		public int $VB$Local_temp_LAND_SR;

		public int $VB$Local_temp_SUB_LR;

		public int $VB$Local_temp_SUB_MR;

		public int $VB$Local_temp_SUB_SR;

		public _Closure$__290-0(_Closure$__290-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_temp_AIR_LR = arg0.$VB$Local_temp_AIR_LR;
				$VB$Local_temp_AIR_MR = arg0.$VB$Local_temp_AIR_MR;
				$VB$Local_temp_AIR_SR = arg0.$VB$Local_temp_AIR_SR;
				$VB$Local_temp_SURF_LR = arg0.$VB$Local_temp_SURF_LR;
				$VB$Local_temp_SURF_MR = arg0.$VB$Local_temp_SURF_MR;
				$VB$Local_temp_SURF_SR = arg0.$VB$Local_temp_SURF_SR;
				$VB$Local_temp_LAND_LR = arg0.$VB$Local_temp_LAND_LR;
				$VB$Local_temp_LAND_MR = arg0.$VB$Local_temp_LAND_MR;
				$VB$Local_temp_LAND_SR = arg0.$VB$Local_temp_LAND_SR;
				$VB$Local_temp_SUB_LR = arg0.$VB$Local_temp_SUB_LR;
				$VB$Local_temp_SUB_MR = arg0.$VB$Local_temp_SUB_MR;
				$VB$Local_temp_SUB_SR = arg0.$VB$Local_temp_SUB_SR;
			}
		}

		[SpecialName]
		internal void _Lambda$__0(Weapon myWeapon, int myCount)
		{
			if (myWeapon.IsAAWCapable)
			{
				if (myWeapon.MaxAirRange > 25f)
				{
					$VB$Local_temp_AIR_LR += myCount;
				}
				else if (myWeapon.MaxAirRange > 5f)
				{
					$VB$Local_temp_AIR_MR += myCount;
				}
				else
				{
					$VB$Local_temp_AIR_SR += myCount;
				}
			}
			if (myWeapon.IsASuW_Naval)
			{
				if (myWeapon.MaxSurfaceRange > 25f)
				{
					$VB$Local_temp_SURF_LR += myCount;
				}
				else if (myWeapon.MaxSurfaceRange > 5f)
				{
					$VB$Local_temp_SURF_MR += myCount;
				}
				else
				{
					$VB$Local_temp_SURF_SR += myCount;
				}
			}
			if (myWeapon.IsASuW_Land)
			{
				if (myWeapon.MaxLandRange > 25f)
				{
					$VB$Local_temp_LAND_LR += myCount;
				}
				else if (myWeapon.MaxLandRange > 5f)
				{
					$VB$Local_temp_LAND_MR += myCount;
				}
				else
				{
					$VB$Local_temp_LAND_SR += myCount;
				}
			}
			if (myWeapon.IsASW)
			{
				if (myWeapon.MaxSubsurfaceRange > 25f)
				{
					$VB$Local_temp_SUB_LR += myCount;
				}
				else if (myWeapon.MaxSubsurfaceRange > 5f)
				{
					$VB$Local_temp_SUB_MR += myCount;
				}
				else
				{
					$VB$Local_temp_SUB_SR += myCount;
				}
			}
		}

		static _Closure$__290-0()
		{
			Class72.smethod_20();
		}
	}

	private Module_Unit.Unit unit_0;

	private string efkzUtwhEn;

	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private string string_4;

	private string string_5;

	private string string_6;

	private BitmapImage bitmapImage_0;

	private List<BitmapImage> list_0;

	private Visibility visibility_0;

	private List<HoverInfoGroupMemberViewModel> list_1;

	private Visibility visibility_1;

	private string string_7;

	private string string_8;

	private string string_9;

	private string string_10;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private int int_6;

	private int int_7;

	private int int_8;

	private int int_9;

	private int int_10;

	private int int_11;

	private Visibility visibility_2;

	private Visibility visibility_3;

	private Visibility visibility_4;

	private Visibility visibility_5;

	private Visibility visibility_6;

	private Visibility visibility_7;

	private Visibility visibility_8;

	private Visibility visibility_9;

	private List<HoverInfoParasiteViewModel> list_2;

	private Visibility visibility_10;

	private List<HoverInfoParasiteViewModel> list_3;

	private Visibility visibility_11;

	private List<HoverInfoCargoViewModel> list_4;

	private Visibility visibility_12;

	private Visibility visibility_13;

	private Visibility visibility_14;

	private List<HoverInfoWeaponViewModel> list_5;

	private Visibility wAjHtfalqIc;

	private List<HoverInfoMountViewModel> list_6;

	private string string_11;

	private string string_12;

	private FuelViewModel fuelViewModel_0;

	private Visibility visibility_15;

	private Visibility visibility_16;

	private Visibility visibility_17;

	private Visibility visibility_18;

	private Visibility visibility_19;

	private Visibility visibility_20;

	private Visibility visibility_21;

	private GridLength gridLength_0;

	private GridLength gridLength_1;

	private GridLength gridLength_2;

	private GridLength gridLength_3;

	private GridLength gridLength_4;

	private int int_12;

	private int int_13;

	private int int_14;

	private static DispatcherTimer dispatcherTimer_0;

	private ContentControl MyContentControl;

	private ElementHost elementHost_0;

	public Module_Unit.Unit Unit
	{
		get
		{
			return unit_0;
		}
		set
		{
			SetProperty(ref unit_0, value, "Unit");
		}
	}

	public string UnitName
	{
		get
		{
			return efkzUtwhEn;
		}
		set
		{
			SetProperty(ref efkzUtwhEn, value, "UnitName");
		}
	}

	public string UnitType
	{
		get
		{
			return string_0;
		}
		set
		{
			SetProperty(ref string_0, value, "UnitType");
		}
	}

	public string SideString
	{
		get
		{
			return string_1;
		}
		set
		{
			SetProperty(ref string_1, value, "SideString");
		}
	}

	public string CourseString
	{
		get
		{
			return string_2;
		}
		set
		{
			SetProperty(ref string_2, value, "CourseString");
		}
	}

	public string SpeedString
	{
		get
		{
			return string_3;
		}
		set
		{
			SetProperty(ref string_3, value, "SpeedString");
		}
	}

	public string AltString
	{
		get
		{
			return string_4;
		}
		set
		{
			SetProperty(ref string_4, value, "AltString");
		}
	}

	public string StatusString
	{
		get
		{
			return string_5;
		}
		set
		{
			SetProperty(ref string_5, value, "StatusString");
		}
	}

	public string LoadoutString
	{
		get
		{
			return string_6;
		}
		set
		{
			SetProperty(ref string_6, value, "LoadoutString");
		}
	}

	public BitmapImage ImageSource
	{
		get
		{
			return bitmapImage_0;
		}
		set
		{
			SetProperty(ref bitmapImage_0, value, "ImageSource");
		}
	}

	public List<BitmapImage> GroupImages
	{
		get
		{
			return list_0;
		}
		set
		{
			SetProperty(ref list_0, value, "GroupImages");
		}
	}

	public Visibility GroupMembersVisibility
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return visibility_0;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			SetProperty(ref visibility_0, value, "GroupMembersVisibility");
		}
	}

	public List<HoverInfoGroupMemberViewModel> GroupMembers
	{
		get
		{
			return list_1;
		}
		set
		{
			SetProperty(ref list_1, value, "GroupMembers");
		}
	}

	public Visibility MissionVisibility
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return visibility_1;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			SetProperty(ref visibility_1, value, "MissionVisibility");
		}
	}

	public string MissionName
	{
		get
		{
			return string_7;
		}
		set
		{
			SetProperty(ref string_7, value, "MissionName");
		}
	}

	public string MissionClass
	{
		get
		{
			return string_8;
		}
		set
		{
			SetProperty(ref string_8, value, "MissionClass");
		}
	}

	public string MissionStatus
	{
		get
		{
			return string_9;
		}
		set
		{
			SetProperty(ref string_9, value, "MissionStatus");
		}
	}

	public string TypeString
	{
		get
		{
			return string_10;
		}
		set
		{
			SetProperty(ref string_10, value, "TypeString");
		}
	}

	public int AIR_LR
	{
		get
		{
			return int_0;
		}
		set
		{
			SetProperty(ref int_0, value, "AIR_LR");
		}
	}

	public int SURF_LR
	{
		get
		{
			return int_1;
		}
		set
		{
			SetProperty(ref int_1, value, "SURF_LR");
		}
	}

	public int LAND_LR
	{
		get
		{
			return int_2;
		}
		set
		{
			SetProperty(ref int_2, value, "LAND_LR");
		}
	}

	public int SUB_LR
	{
		get
		{
			return int_3;
		}
		set
		{
			SetProperty(ref int_3, value, "SUB_LR");
		}
	}

	public int AIR_MR
	{
		get
		{
			return int_4;
		}
		set
		{
			SetProperty(ref int_4, value, "AIR_MR");
		}
	}

	public int SURF_MR
	{
		get
		{
			return int_5;
		}
		set
		{
			SetProperty(ref int_5, value, "SURF_MR");
		}
	}

	public int LAND_MR
	{
		get
		{
			return int_6;
		}
		set
		{
			SetProperty(ref int_6, value, "LAND_MR");
		}
	}

	public int SUB_MR
	{
		get
		{
			return int_7;
		}
		set
		{
			SetProperty(ref int_7, value, "SUB_MR");
		}
	}

	public int AIR_SR
	{
		get
		{
			return int_8;
		}
		set
		{
			SetProperty(ref int_8, value, "AIR_SR");
		}
	}

	public int SURF_SR
	{
		get
		{
			return int_9;
		}
		set
		{
			SetProperty(ref int_9, value, "SURF_SR");
		}
	}

	public int LAND_SR
	{
		get
		{
			return int_10;
		}
		set
		{
			SetProperty(ref int_10, value, "LAND_SR");
		}
	}

	public int SUB_SR
	{
		get
		{
			return int_11;
		}
		set
		{
			SetProperty(ref int_11, value, "SUB_SR");
		}
	}

	public Visibility RadarOnVisibility
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return visibility_2;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			SetProperty(ref visibility_2, value, "RadarOnVisibility");
		}
	}

	public Visibility SonarOnVisibility
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return visibility_3;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			SetProperty(ref visibility_3, value, "SonarOnVisibility");
		}
	}

	public Visibility OECMOnVisibility
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return visibility_4;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			SetProperty(ref visibility_4, value, "OECMOnVisibility");
		}
	}

	public Visibility RadarOffVisibility
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return visibility_5;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			SetProperty(ref visibility_5, value, "RadarOffVisibility");
		}
	}

	public Visibility SonarOffVisibility
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return visibility_6;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			SetProperty(ref visibility_6, value, "SonarOffVisibility");
		}
	}

	public Visibility OECMOffVisibility
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return visibility_7;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			SetProperty(ref visibility_7, value, "OECMOffVisibility");
		}
	}

	public Visibility SensorVisibility
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return visibility_8;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			SetProperty(ref visibility_8, value, "SensorVisibility");
		}
	}

	public Visibility AirParasiteVisibility
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return visibility_9;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			SetProperty(ref visibility_9, value, "AirParasiteVisibility");
		}
	}

	public List<HoverInfoParasiteViewModel> AirParasites
	{
		get
		{
			return list_2;
		}
		set
		{
			SetProperty(ref list_2, value, "AirParasites");
		}
	}

	public Visibility BoatParasiteVisibility
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return visibility_10;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			SetProperty(ref visibility_10, value, "BoatParasiteVisibility");
		}
	}

	public List<HoverInfoParasiteViewModel> BoatParasites
	{
		get
		{
			return list_3;
		}
		set
		{
			SetProperty(ref list_3, value, "BoatParasites");
		}
	}

	public Visibility CargoVisibility
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return visibility_11;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			SetProperty(ref visibility_11, value, "CargoVisibility");
		}
	}

	public List<HoverInfoCargoViewModel> Cargo
	{
		get
		{
			return list_4;
		}
		set
		{
			SetProperty(ref list_4, value, "Cargo");
		}
	}

	public Visibility WeaponSummaryVisibility
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return visibility_12;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			SetProperty(ref visibility_12, value, "WeaponSummaryVisibility");
		}
	}

	public Visibility WeaponDetailsVisibility
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return visibility_13;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			SetProperty(ref visibility_13, value, "WeaponDetailsVisibility");
		}
	}

	public Visibility WeaponVisibility
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return visibility_14;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			SetProperty(ref visibility_14, value, "WeaponVisibility");
		}
	}

	public List<HoverInfoWeaponViewModel> WeaponsDetails
	{
		get
		{
			return list_5;
		}
		set
		{
			SetProperty(ref list_5, value, "WeaponsDetails");
		}
	}

	public Visibility MountsDetailsVisibility
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return wAjHtfalqIc;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			SetProperty(ref wAjHtfalqIc, value, "MountsDetailsVisibility");
		}
	}

	public List<HoverInfoMountViewModel> MountsDetails
	{
		get
		{
			return list_6;
		}
		set
		{
			SetProperty(ref list_6, value, "MountsDetails");
		}
	}

	public string ContactClass
	{
		get
		{
			return string_11;
		}
		set
		{
			SetProperty(ref string_11, value, "ContactClass");
		}
	}

	public string UnitDamage
	{
		get
		{
			return string_12;
		}
		set
		{
			SetProperty(ref string_12, value, "UnitDamage");
		}
	}

	public FuelViewModel FuelViewModel
	{
		get
		{
			return fuelViewModel_0;
		}
		set
		{
			SetProperty(ref fuelViewModel_0, value, "FuelViewModel");
		}
	}

	public Visibility FuelSummaryVisibility
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return visibility_15;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			SetProperty(ref visibility_15, value, "FuelSummaryVisibility");
		}
	}

	public Visibility FuelDetailsVisibility
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return visibility_16;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			SetProperty(ref visibility_16, value, "FuelDetailsVisibility");
		}
	}

	public Visibility DamageVisibility
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return visibility_17;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			SetProperty(ref visibility_17, value, "DamageVisibility");
		}
	}

	public Visibility DamageComponentVisibility
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return visibility_18;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			SetProperty(ref visibility_18, value, "DamageComponentVisibility");
		}
	}

	public Visibility DamageFireVisibility
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return visibility_19;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			SetProperty(ref visibility_19, value, "DamageFireVisibility");
		}
	}

	public Visibility DamageFloodVisibility
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return visibility_20;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			SetProperty(ref visibility_20, value, "DamageFloodVisibility");
		}
	}

	public Visibility DamagePointsVisibility
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return visibility_21;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			SetProperty(ref visibility_21, value, "DamagePointsVisibility");
		}
	}

	public GridLength DamageComponentOK
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return gridLength_0;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			SetProperty(ref gridLength_0, value, "DamageComponentOK");
		}
	}

	public GridLength DamageComponentLight
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return gridLength_1;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			SetProperty(ref gridLength_1, value, "DamageComponentLight");
		}
	}

	public GridLength DamageComponentMedium
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return gridLength_2;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			SetProperty(ref gridLength_2, value, "DamageComponentMedium");
		}
	}

	public GridLength DamageComponentHeavy
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return gridLength_3;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			SetProperty(ref gridLength_3, value, "DamageComponentHeavy");
		}
	}

	public GridLength DamageComponentDestroyed
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return gridLength_4;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			SetProperty(ref gridLength_4, value, "DamageComponentDestroyed");
		}
	}

	public int DamageFlood
	{
		get
		{
			return int_12;
		}
		set
		{
			SetProperty(ref int_12, value, "DamageFlood");
		}
	}

	public int DamageFire
	{
		get
		{
			return int_13;
		}
		set
		{
			SetProperty(ref int_13, value, "DamageFire");
		}
	}

	public int DamagePoints
	{
		get
		{
			return int_14;
		}
		set
		{
			SetProperty(ref int_14, value, "DamagePoints");
		}
	}

	static HoverInfoViewModel()
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		Class72.smethod_20();
		dispatcherTimer_0 = new DispatcherTimer();
	}

	public HoverInfoViewModel(ContentControl MyContentControl, ElementHost theElementHost)
	{
		this.MyContentControl = MyContentControl;
		elementHost_0 = theElementHost;
		MyContentControl.Content = this;
	}

	public void Update(Module_Unit.Unit theUnit)
	{
		Unit = theUnit;
		UnitName = theUnit.Name;
		UnitType = theUnit.UnitClass;
		if (!theUnit.IsContact())
		{
			SideString = $"Side: {theUnit.get_UnitSide(SetSideOnly: false).Name}";
			CourseString = $"Course: {theUnit.CurrentHeading:00}°";
			SpeedString = $"Speed: {theUnit.CurrentSpeed:0} kts";
		}
		WorldWindow worldWindow = MyProject.Forms.MainForm.WorldWindow1;
		DrawArgs wW_DrawArgs = Module1.WW_DrawArgs;
		Module_Unit.Unit unit;
		double Latitude = (unit = theUnit).get_Latitude((GlobalVariables.BooleanObject)null);
		Module_Unit.Unit unit2;
		double Longitude = (unit2 = theUnit).get_Longitude((GlobalVariables.BooleanObject)null);
		int ScreenX = default(int);
		int ScreenY = default(int);
		WWC.WWC_WorldToScreen(worldWindow, wW_DrawArgs, ref Latitude, ref Longitude, ref ScreenX, ref ScreenY);
		unit2.set_Longitude((GlobalVariables.BooleanObject)null, Longitude);
		unit.set_Latitude((GlobalVariables.BooleanObject)null, Latitude);
		((Control)elementHost_0).Top = 0;
		((Control)elementHost_0).Left = -1000;
		((Control)elementHost_0).Height = 1000;
		if (theUnit is Weapon)
		{
			Weapon weapon = (Weapon)theUnit;
			StatusString = "Status: " + Misc.ToEnglishString(weapon.Status, weapon);
			LoadoutString = "";
			method_13();
		}
		else if (!(theUnit is Contact))
		{
			if (!(theUnit is Group))
			{
				if (theUnit is ActiveUnit)
				{
					ActiveUnit activeUnit = (ActiveUnit)theUnit;
					StatusString = "Status: " + Misc.ToEnglishString(activeUnit.Status, activeUnit);
					if (activeUnit.UnitType == GlobalVariables.ActiveUnitType.Aircraft)
					{
						LoadoutString = ((Aircraft)activeUnit).LoadoutName;
					}
					method_5();
					method_13();
					method_16();
					method_1();
					method_6();
					method_11();
					method_14();
					method_15();
					method_4();
					method_0();
				}
			}
			else
			{
				Group obj = (Group)theUnit;
				StatusString = "Status: " + Misc.ToEnglishString(obj.Status, obj);
				LoadoutString = "";
				if (obj.Units.Values.Any([SpecialName] (ActiveUnit F) => F.UnitType == GlobalVariables.ActiveUnitType.Aircraft))
				{
					LoadoutString = ((Aircraft)obj.Units.Values.First()).LoadoutName;
				}
				method_16();
				method_7();
				method_12();
				method_10();
				method_11();
				method_14();
				method_15();
				method_4();
				method_0();
			}
		}
		else
		{
			method_2();
		}
		dispatcherTimer_0.Interval = TimeSpan.FromMilliseconds(1.0);
		dispatcherTimer_0.Tick += method_3;
		dispatcherTimer_0.Start();
	}

	private void method_0()
	{
		ActiveUnit activeUnit = (ActiveUnit)Unit;
		if (activeUnit.IsShip && ((Ship)activeUnit).IsNuke)
		{
			FuelSummaryVisibility = (Visibility)2;
			FuelDetailsVisibility = (Visibility)2;
		}
		else if (activeUnit.IsSubmarine && (((Submarine)activeUnit).IsNuke || ((Submarine)activeUnit).Fuel_ReadOnly.Count == 0))
		{
			FuelSummaryVisibility = (Visibility)2;
			FuelDetailsVisibility = (Visibility)2;
		}
		else if (activeUnit.IsFacility)
		{
			FuelSummaryVisibility = (Visibility)2;
			FuelDetailsVisibility = (Visibility)2;
		}
		else if (activeUnit.IsWeapon)
		{
			FuelSummaryVisibility = (Visibility)2;
			FuelDetailsVisibility = (Visibility)2;
		}
		else if (!activeUnit.IsSatellite)
		{
			FuelViewModel = new FuelViewModel(activeUnit);
			FuelSummaryVisibility = (Visibility)0;
			FuelDetailsVisibility = (Visibility)0;
		}
		else
		{
			FuelSummaryVisibility = (Visibility)2;
			FuelDetailsVisibility = (Visibility)2;
		}
		if (HoverInfoOptionsViewModel.Singleton.Fuel != HoverInfoEnableDetailedEnum.ShowDetailed)
		{
			if (HoverInfoOptionsViewModel.Singleton.Fuel == HoverInfoEnableDetailedEnum.ShowSummary)
			{
				FuelDetailsVisibility = (Visibility)2;
				return;
			}
			FuelSummaryVisibility = (Visibility)2;
			FuelDetailsVisibility = (Visibility)2;
		}
		else
		{
			FuelSummaryVisibility = (Visibility)2;
		}
	}

	private void method_1()
	{
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		ActiveUnit activeUnit = (ActiveUnit)Unit;
		int num5 = default(int);
		int num4 = default(int);
		int num3 = default(int);
		int num2 = default(int);
		int num = default(int);
		int num6 = default(int);
		foreach (PlatformComponent item in activeUnit.Components())
		{
			switch (item.Status)
			{
			case PlatformComponent._ComponentStatus.Operational:
				num5++;
				break;
			case PlatformComponent._ComponentStatus.Damaged:
				switch (item.DamageSeverity)
				{
				case PlatformComponent._DamageSeverityFactor.Light:
					num4++;
					break;
				case PlatformComponent._DamageSeverityFactor.Medium:
					num3++;
					break;
				case PlatformComponent._DamageSeverityFactor.Heavy:
					num2++;
					break;
				}
				break;
			case PlatformComponent._ComponentStatus.Destroyed:
				num++;
				break;
			}
			num6++;
		}
		DamageComponentOK = new GridLength((double)num5, (GridUnitType)2);
		DamageComponentLight = new GridLength((double)num4, (GridUnitType)2);
		DamageComponentMedium = new GridLength((double)num3, (GridUnitType)2);
		DamageComponentHeavy = new GridLength((double)num2, (GridUnitType)2);
		DamageComponentDestroyed = new GridLength((double)num, (GridUnitType)2);
		switch (activeUnit.Damage.FloodIntensity)
		{
		case ActiveUnit_Damage.FloodingIntensityLevel.NoFlooding:
			DamageFlood = 0;
			break;
		case ActiveUnit_Damage.FloodingIntensityLevel.Minor:
			DamageFlood = 25;
			break;
		case ActiveUnit_Damage.FloodingIntensityLevel.Major:
			DamageFlood = 50;
			break;
		case ActiveUnit_Damage.FloodingIntensityLevel.Severe:
			DamageFlood = 75;
			break;
		case ActiveUnit_Damage.FloodingIntensityLevel.Capsizing:
			DamageFlood = 100;
			break;
		}
		switch (activeUnit.Damage.FireIntensity)
		{
		case ActiveUnit_Damage.FireIntensityLevel.NoFire:
			DamageFire = 0;
			break;
		case ActiveUnit_Damage.FireIntensityLevel.Minor:
			DamageFire = 25;
			break;
		case ActiveUnit_Damage.FireIntensityLevel.Major:
			DamageFire = 50;
			break;
		case ActiveUnit_Damage.FireIntensityLevel.Severe:
			DamageFire = 75;
			break;
		case ActiveUnit_Damage.FireIntensityLevel.Conflagration:
			DamageFire = 100;
			break;
		}
		DamagePoints = (int)Math.Round(activeUnit.Damage.DamagePercent);
		if (HoverInfoOptionsViewModel.Singleton.Damage == HoverInfoEnableEnum.Hide)
		{
			DamageVisibility = (Visibility)2;
			DamageComponentVisibility = (Visibility)2;
			DamageFireVisibility = (Visibility)2;
			DamageFloodVisibility = (Visibility)2;
			DamagePointsVisibility = (Visibility)2;
			return;
		}
		DamageVisibility = (Visibility)2;
		if (DamageFire <= 1)
		{
			DamageFireVisibility = (Visibility)2;
		}
		else
		{
			DamageVisibility = (Visibility)0;
			DamageFireVisibility = (Visibility)0;
		}
		if (DamageFlood > 1)
		{
			DamageVisibility = (Visibility)0;
			DamageFloodVisibility = (Visibility)0;
		}
		else
		{
			DamageFloodVisibility = (Visibility)2;
		}
		if (DamagePoints > 1)
		{
			DamageVisibility = (Visibility)0;
			DamagePointsVisibility = (Visibility)0;
		}
		else
		{
			DamagePointsVisibility = (Visibility)2;
		}
		if (num6 != num5)
		{
			DamageVisibility = (Visibility)0;
			DamageComponentVisibility = (Visibility)0;
		}
		else
		{
			DamageComponentVisibility = (Visibility)2;
		}
	}

	private void method_2()
	{
		Contact contact = (Contact)Unit;
		if (contact.IDStatus > Contact_Base.IdentificationStatus.KnownType)
		{
			ContactClass = Misc.RemoveHiddenString(contact.ActualUnit.UnitClass);
			if (SimConfiguration.DefaultGamePreferences.UnitStatusImage)
			{
				ImageSource = UnitImageCaching.getCachedBitmapImage(UnitImageCaching.getMainImageFileString(contact.ActualUnit));
			}
		}
		else
		{
			ContactClass = "Unknown class";
		}
		CourseString = $"Course: {contact.HeadingString()}";
		if (((contact.Type == Contact_Base.ContactType.Air) | (contact.Type == Contact_Base.ContactType.Missile)) & contact.AltitudeIsKnown)
		{
			SpeedString = "Speed: " + Conversions.ToString((int)Math.Round(contact.CurrentSpeed)) + " kts (M " + $"{Physics.ComputeMach(((Module_Unit.Unit)contact).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), contact.CurrentSpeed):0.00}" + ")";
		}
		else
		{
			SpeedString = "Speed: " + contact.SpeedString(SimConfiguration.DefaultGamePreferences.GroundUnitsSpeedUnit, "Unknown");
		}
		if (!contact.SideIsKnown)
		{
			SideString = "Side: Unknown";
		}
		else if (!Information.IsNothing((object)contact.ActualUnit.get_UnitSide(SetSideOnly: false)))
		{
			SideString = "Side: " + contact.ActualUnit.get_UnitSide(SetSideOnly: false).Name;
		}
		UnitDamage = "BDA: " + Misc.ToEnglishString(contact.BDA_StructuralIntegrity);
	}

	private void method_3(object sender, EventArgs e)
	{
		dispatcherTimer_0.Stop();
		dispatcherTimer_0.Tick -= method_3;
		WorldWindow worldWindow = MyProject.Forms.MainForm.WorldWindow1;
		DrawArgs wW_DrawArgs = Module1.WW_DrawArgs;
		Module_Unit.Unit unit;
		double Latitude = (unit = Unit).get_Latitude((GlobalVariables.BooleanObject)null);
		Module_Unit.Unit unit2;
		double Longitude = (unit2 = Unit).get_Longitude((GlobalVariables.BooleanObject)null);
		int ScreenX = default(int);
		int ScreenY = default(int);
		WWC.WWC_WorldToScreen(worldWindow, wW_DrawArgs, ref Latitude, ref Longitude, ref ScreenX, ref ScreenY);
		unit2.set_Longitude((GlobalVariables.BooleanObject)null, Longitude);
		unit.set_Latitude((GlobalVariables.BooleanObject)null, Latitude);
		((Control)elementHost_0).Left = ScreenX + 25;
		((Control)elementHost_0).Height = (int)Math.Round(((FrameworkElement)MyContentControl).ActualHeight + 25.0);
		((Control)elementHost_0).Top = (int)Math.Round(Math.Max(0.0, (double)ScreenY - (double)((Control)elementHost_0).Height / 2.0));
		((Control)elementHost_0).BringToFront();
	}

	private void method_4()
	{
		Cargo = (from F in method_8().SelectMany([SpecialName] (ActiveUnit F) => F.OnboardCargo)
			group F by F.CargoObjectName into F
			select new HoverInfoCargoViewModel
			{
				Header = F.Key,
				Quantity = F.Count()
			}).ToList();
		if (Cargo.Any())
		{
			CargoVisibility = (Visibility)0;
		}
		else
		{
			CargoVisibility = (Visibility)2;
		}
		if (HoverInfoOptionsViewModel.Singleton.Cargo == HoverInfoEnableEnum.Hide)
		{
			CargoVisibility = (Visibility)2;
		}
	}

	private void method_5()
	{
		_ = (ActiveUnit)Unit;
		if (HoverInfoOptionsViewModel.Singleton.Sensor != HoverInfoEnableEnum.Show)
		{
			SensorVisibility = (Visibility)2;
		}
		else
		{
			SensorVisibility = (Visibility)0;
		}
	}

	private void method_6()
	{
		ActiveUnit activeUnit = (ActiveUnit)Unit;
		MountsDetails = (from F in activeUnit.Mounts
			select F.Name into F
			group F by F into F
			select new HoverInfoMountViewModel
			{
				Header = F.Key,
				Quantity = F.Count()
			} into F
			orderby F.Header
			select F).ToList();
		if (!MountsDetails.Any())
		{
			MountsDetailsVisibility = (Visibility)2;
		}
		else if (HoverInfoOptionsViewModel.Singleton.Vehicles != HoverInfoEnableEnum.Show)
		{
			MountsDetailsVisibility = (Visibility)2;
		}
		else
		{
			MountsDetailsVisibility = (Visibility)0;
		}
	}

	private void method_7()
	{
		Group obj = (Group)Unit;
		if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
		{
			if (obj.CurrentAltitude_AGL > 3048f)
			{
				if (obj.Type != Group.GroupType.AirGroup)
				{
					AltString = "Altitude: " + $"{obj.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) * 3.28084f:0}".ToString() + " ft";
				}
				else
				{
					AltString = "Altitude: " + $"{obj.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) * 3.28084f:0}".ToString() + " ft ASL";
				}
			}
			else if (obj.Type == Group.GroupType.AirGroup)
			{
				if (!Module_Unit.IsOverLand(obj))
				{
					AltString = "Altitude: " + $"{obj.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) * 3.28084f:0}" + " ft ASL";
					return;
				}
				AltString = "Altitude: " + $"{obj.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) * 3.28084f:0}" + " ft ASL (" + $"{obj.CurrentAltitude_AGL * 3.28084f:0}" + " ft AGL)";
			}
			else
			{
				AltString = "Altitude: " + $"{obj.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) * 3.28084f:0}".ToString() + " ft";
			}
		}
		else if (obj.CurrentAltitude_AGL > 3048f)
		{
			if (obj.Type != Group.GroupType.AirGroup)
			{
				AltString = "Altitude: " + string.Format("{0:0.0}", obj.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), 0).ToString() + " m";
			}
			else
			{
				AltString = "Altitude: " + string.Format("{0:0.0}", obj.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), 0).ToString() + " m ASL";
			}
		}
		else if (obj.Type != Group.GroupType.AirGroup)
		{
			AltString = "Altitude: " + string.Format("{0:0.0}", obj.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), 0).ToString() + " m";
		}
		else if (Module_Unit.IsOverLand(obj))
		{
			AltString = "Altitude: " + string.Format("{0:0.0}", obj.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), 0) + " m ASL (" + string.Format("{0:0.0}", obj.CurrentAltitude_AGL, 0) + " m AGL)";
		}
		else
		{
			AltString = "Altitude: " + string.Format("{0:0.0}", obj.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), 0) + " m ASL";
		}
	}

	private IEnumerable<ActiveUnit> method_8()
	{
		if (!(Unit is Group))
		{
			return new List<ActiveUnit> { (ActiveUnit)Unit };
		}
		return ((Group)Unit).Units.Values;
	}

	private string method_9(string string_13, bool bool_0 = true)
	{
		if (!string.IsNullOrWhiteSpace(string_13))
		{
			StringBuilder stringBuilder = new StringBuilder(string_13.Length * 2);
			stringBuilder.Append(string_13[0]);
			int num = string_13.Length - 1;
			for (int i = 1; i <= num; i++)
			{
				if (char.IsUpper(string_13[i]) && ((string_13[i - 1] != ' ' && !char.IsUpper(string_13[i - 1])) || (bool_0 && char.IsUpper(string_13[i - 1]) && i < string_13.Length - 1 && !char.IsUpper(string_13[i + 1]))))
				{
					stringBuilder.Append(' ');
				}
				stringBuilder.Append(string_13[i]);
			}
			return stringBuilder.Replace('_', ' ').Replace("  ", " ").Replace("  ", " ")
				.ToString();
		}
		return string.Empty;
	}

	private string blBzIvLkSe(ActiveUnit activeUnit_0)
	{
		if (!(activeUnit_0 is Ship))
		{
			if (!(activeUnit_0 is Aircraft))
			{
				if (activeUnit_0 is Submarine)
				{
					Submarine submarine = (Submarine)activeUnit_0;
					return method_9(submarine.Type.ToString());
				}
				if (activeUnit_0 is Facility)
				{
					Facility facility = (Facility)activeUnit_0;
					return method_9(facility.Category.ToString());
				}
				if (!(activeUnit_0 is Weapon))
				{
					if (activeUnit_0 is Satellite)
					{
						Satellite satellite = (Satellite)activeUnit_0;
						return method_9(satellite.Type.ToString());
					}
					return "Unit";
				}
				return Misc.ToEnglishString(((Weapon)activeUnit_0).Type);
			}
			Aircraft aircraft = (Aircraft)activeUnit_0;
			return method_9(aircraft.Type.ToString());
		}
		Ship ship = (Ship)activeUnit_0;
		return method_9(ship.Type.ToString());
	}

	private void method_10()
	{
		Group obj = (Group)Unit;
		GroupMembers = (from F in obj.Units.Values.GroupBy(blBzIvLkSe)
			select new HoverInfoGroupMemberViewModel
			{
				Header = F.Key,
				Quantity = F.Count()
			} into F
			orderby F.Header
			select F).ToList();
		if (HoverInfoOptionsViewModel.Singleton.GroupMembers != HoverInfoEnableEnum.Show)
		{
			GroupMembersVisibility = (Visibility)2;
		}
		else
		{
			GroupMembersVisibility = (Visibility)0;
		}
	}

	private void method_11()
	{
		AirParasites = method_8().SelectMany([SpecialName] (ActiveUnit F) => F.AirOps.EmbarkedAircraft_ReadOnly).GroupBy(blBzIvLkSe).Select([SpecialName] (IGrouping<string, Aircraft> F) =>
		{
			Aircraft[] source = F.ToArray();
			int num = source.Count();
			int num2 = source.Count([SpecialName] (Aircraft O) => O.AirOps.ConditionTimer <= 0f);
			return new HoverInfoParasiteViewModel
			{
				Header = F.Key,
				Ready = $"{num2}/{num}"
			};
		})
			.ToList();
		BoatParasites = method_8().SelectMany([SpecialName] (ActiveUnit F) => F.DockingOps.EmbarkedBoats_ReadOnly).GroupBy(blBzIvLkSe).Select([SpecialName] (IGrouping<string, ActiveUnit> F) =>
		{
			ActiveUnit[] source = F.ToArray();
			int num = source.Count();
			int num2 = source.Count([SpecialName] (ActiveUnit O) => O.DockingOps.ConditionTimer <= 0f);
			return new HoverInfoParasiteViewModel
			{
				Header = F.Key,
				Ready = $"{num2}/{num}"
			};
		})
			.ToList();
		if (AirParasites.Any())
		{
			AirParasiteVisibility = (Visibility)0;
		}
		else
		{
			AirParasiteVisibility = (Visibility)2;
		}
		if (!BoatParasites.Any())
		{
			BoatParasiteVisibility = (Visibility)2;
		}
		else
		{
			BoatParasiteVisibility = (Visibility)0;
		}
		if (HoverInfoOptionsViewModel.Singleton.AirParasite == HoverInfoEnableEnum.Hide)
		{
			AirParasiteVisibility = (Visibility)2;
		}
		if (HoverInfoOptionsViewModel.Singleton.BoatParasite == HoverInfoEnableEnum.Hide)
		{
			BoatParasiteVisibility = (Visibility)2;
		}
	}

	private void method_12()
	{
		Group obj = (Group)Unit;
		if (SimConfiguration.DefaultGamePreferences.UnitStatusImage)
		{
			GroupImages = (from F in obj.Units
				select UnitImageCaching.getCachedBitmapImage(UnitImageCaching.getMainImageFileString(F.Value)) into F
				where F != null
				select F).ToList();
		}
	}

	private void method_13()
	{
		ActiveUnit theAU = (ActiveUnit)Unit;
		if (SimConfiguration.DefaultGamePreferences.UnitStatusImage)
		{
			ImageSource = UnitImageCaching.getCachedBitmapImage(UnitImageCaching.getMainImageFileString(theAU));
		}
	}

	private void method_14()
	{
		ActiveUnit activeUnit = (ActiveUnit)Unit;
		if (activeUnit.ActiveMissionOrPackage() == null)
		{
			MissionVisibility = (Visibility)2;
			return;
		}
		MissionName = $"{activeUnit.ActiveMissionOrPackage().Name}";
		MissionClass = $"{activeUnit.ActiveMissionOrPackage().MissionClass}";
		MissionStatus = $"{activeUnit.ActiveMissionOrPackage().get_Status(Client.CurrentScenario)}";
		if (HoverInfoOptionsViewModel.Singleton.Mission == HoverInfoEnableEnum.Hide)
		{
			MissionVisibility = (Visibility)2;
		}
		if (HoverInfoOptionsViewModel.Singleton.Mission == HoverInfoEnableEnum.Show)
		{
			MissionVisibility = (Visibility)0;
		}
	}

	private void method_15()
	{
		_Closure$__290-0 arg = default(_Closure$__290-0);
		_Closure$__290-0 CS$<>8__locals36 = new _Closure$__290-0(arg);
		CS$<>8__locals36.$VB$Local_temp_AIR_LR = 0;
		CS$<>8__locals36.$VB$Local_temp_AIR_MR = 0;
		CS$<>8__locals36.$VB$Local_temp_AIR_SR = 0;
		CS$<>8__locals36.$VB$Local_temp_SURF_LR = 0;
		CS$<>8__locals36.$VB$Local_temp_SURF_MR = 0;
		CS$<>8__locals36.$VB$Local_temp_SURF_SR = 0;
		CS$<>8__locals36.$VB$Local_temp_LAND_LR = 0;
		CS$<>8__locals36.$VB$Local_temp_LAND_MR = 0;
		CS$<>8__locals36.$VB$Local_temp_LAND_SR = 0;
		CS$<>8__locals36.$VB$Local_temp_SUB_LR = 0;
		CS$<>8__locals36.$VB$Local_temp_SUB_MR = 0;
		CS$<>8__locals36.$VB$Local_temp_SUB_SR = 0;
		List<(Weapon, int)> list = new List<(Weapon, int)>();
		VB$AnonymousDelegate_1<Weapon, int> vB$AnonymousDelegate_ = [SpecialName] (Weapon myWeapon, int myCount) =>
		{
			if (myWeapon.IsAAWCapable)
			{
				if (myWeapon.MaxAirRange > 25f)
				{
					CS$<>8__locals36.$VB$Local_temp_AIR_LR += myCount;
				}
				else if (myWeapon.MaxAirRange > 5f)
				{
					CS$<>8__locals36.$VB$Local_temp_AIR_MR += myCount;
				}
				else
				{
					CS$<>8__locals36.$VB$Local_temp_AIR_SR += myCount;
				}
			}
			if (myWeapon.IsASuW_Naval)
			{
				if (myWeapon.MaxSurfaceRange > 25f)
				{
					CS$<>8__locals36.$VB$Local_temp_SURF_LR += myCount;
				}
				else if (myWeapon.MaxSurfaceRange > 5f)
				{
					CS$<>8__locals36.$VB$Local_temp_SURF_MR += myCount;
				}
				else
				{
					CS$<>8__locals36.$VB$Local_temp_SURF_SR += myCount;
				}
			}
			if (myWeapon.IsASuW_Land)
			{
				if (myWeapon.MaxLandRange > 25f)
				{
					CS$<>8__locals36.$VB$Local_temp_LAND_LR += myCount;
				}
				else if (myWeapon.MaxLandRange > 5f)
				{
					CS$<>8__locals36.$VB$Local_temp_LAND_MR += myCount;
				}
				else
				{
					CS$<>8__locals36.$VB$Local_temp_LAND_SR += myCount;
				}
			}
			if (myWeapon.IsASW)
			{
				if (myWeapon.MaxSubsurfaceRange > 25f)
				{
					CS$<>8__locals36.$VB$Local_temp_SUB_LR += myCount;
				}
				else if (myWeapon.MaxSubsurfaceRange > 5f)
				{
					CS$<>8__locals36.$VB$Local_temp_SUB_MR += myCount;
				}
				else
				{
					CS$<>8__locals36.$VB$Local_temp_SUB_SR += myCount;
				}
			}
		};
		foreach (ActiveUnit item in method_8())
		{
			foreach (Mount mount in item.Mounts)
			{
				foreach (WeaponRec mountWeapon in mount.MountWeapons)
				{
					Weapon weapon = Client.CurrentScenario.Cache_GetWeapon(mountWeapon.int_3);
					int currentLoad = mountWeapon.CurrentLoad;
					list.Add((weapon, currentLoad));
					vB$AnonymousDelegate_(weapon, currentLoad);
				}
			}
			Magazine[] totalMagazines = item.TotalMagazines;
			foreach (Magazine magazine in totalMagazines)
			{
				foreach (WeaponRec weapon4 in magazine.Weapons)
				{
					Weapon weapon2 = Client.CurrentScenario.Cache_GetWeapon(weapon4.int_3);
					int currentLoad2 = weapon4.CurrentLoad;
					list.Add((weapon2, currentLoad2));
					vB$AnonymousDelegate_(weapon2, currentLoad2);
				}
			}
			if (item.IsAircraft && ((Aircraft)item).Loadout != null)
			{
				WeaponRec[] weapons = ((Aircraft)item).Loadout.Weapons;
				foreach (WeaponRec weaponRec in weapons)
				{
					Weapon weapon3 = Client.CurrentScenario.Cache_GetWeapon(weaponRec.int_3);
					int currentLoad3 = weaponRec.CurrentLoad;
					list.Add((weapon3, currentLoad3));
					vB$AnonymousDelegate_(weapon3, currentLoad3);
				}
			}
		}
		AIR_LR = CS$<>8__locals36.$VB$Local_temp_AIR_LR;
		AIR_MR = CS$<>8__locals36.$VB$Local_temp_AIR_MR;
		AIR_SR = CS$<>8__locals36.$VB$Local_temp_AIR_SR;
		SURF_LR = CS$<>8__locals36.$VB$Local_temp_SURF_LR;
		SURF_MR = CS$<>8__locals36.$VB$Local_temp_SURF_MR;
		SURF_SR = CS$<>8__locals36.$VB$Local_temp_SURF_SR;
		LAND_LR = CS$<>8__locals36.$VB$Local_temp_LAND_LR;
		LAND_MR = CS$<>8__locals36.$VB$Local_temp_LAND_MR;
		LAND_SR = CS$<>8__locals36.$VB$Local_temp_LAND_SR;
		SUB_LR = CS$<>8__locals36.$VB$Local_temp_SUB_LR;
		SUB_MR = CS$<>8__locals36.$VB$Local_temp_SUB_MR;
		SUB_SR = CS$<>8__locals36.$VB$Local_temp_SUB_SR;
		WeaponsDetails = (from F in list
			group F by blBzIvLkSe(F.Item1) into F
			select new HoverInfoWeaponViewModel
			{
				Header = F.Key,
				Quantity = F.Sum([SpecialName] ((Weapon, int) O) => O.Item2)
			} into F
			where F.Quantity > 0
			orderby F.Header
			select F).ToList();
		if (!WeaponsDetails.Any())
		{
			WeaponDetailsVisibility = (Visibility)2;
			WeaponSummaryVisibility = (Visibility)2;
			WeaponVisibility = (Visibility)2;
			return;
		}
		WeaponVisibility = (Visibility)0;
		if (HoverInfoOptionsViewModel.Singleton.Weapons == HoverInfoEnableDetailedEnum.ShowDetailed)
		{
			WeaponDetailsVisibility = (Visibility)0;
			WeaponSummaryVisibility = (Visibility)2;
		}
		if (HoverInfoOptionsViewModel.Singleton.Weapons == HoverInfoEnableDetailedEnum.ShowSummary)
		{
			WeaponDetailsVisibility = (Visibility)2;
			WeaponSummaryVisibility = (Visibility)0;
		}
	}

	private void method_16()
	{
		ActiveUnit obj = (ActiveUnit)Unit;
		bool flag = false;
		bool flag2 = false;
		flag = obj.Sensors_ReadOnly().Any([SpecialName] (Sensor F) => (F.Type == Sensor.Sensor_Type.Radar) & F.IsActive());
		flag2 = obj.Sensors_ReadOnly().Any([SpecialName] (Sensor F) => F.IsSonar & F.IsActive());
		bool num = obj.Sensors_ReadOnly().Any([SpecialName] (Sensor F) => F.IsOECM & F.IsActive());
		if (flag)
		{
			RadarOnVisibility = (Visibility)0;
			RadarOffVisibility = (Visibility)2;
		}
		else
		{
			RadarOnVisibility = (Visibility)2;
			RadarOffVisibility = (Visibility)0;
		}
		if (!flag2)
		{
			SonarOnVisibility = (Visibility)2;
			SonarOffVisibility = (Visibility)0;
		}
		else
		{
			SonarOnVisibility = (Visibility)0;
			SonarOffVisibility = (Visibility)2;
		}
		if (!num)
		{
			OECMOnVisibility = (Visibility)2;
			OECMOffVisibility = (Visibility)0;
		}
		else
		{
			OECMOnVisibility = (Visibility)0;
			OECMOffVisibility = (Visibility)2;
		}
	}
}
