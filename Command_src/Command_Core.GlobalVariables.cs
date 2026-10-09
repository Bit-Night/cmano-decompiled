using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class GlobalVariables
{
	public class BooleanObject
	{
		public bool ToBoolean()
		{
			return this == ObjectTrue;
		}

		static BooleanObject()
		{
			Class72.smethod_20();
		}
	}

	public enum ProficiencyLevel
	{
		Novice,
		Cadet,
		Regular,
		Veteran,
		Ace
	}

	public enum WeaponFragilityClass : short
	{
		VeryFragile,
		Fragile,
		Medium,
		Tough
	}

	public enum ArmorRating : short
	{
		Undefined = 0,
		None = 1001,
		Armor_Handgun = 1005,
		Armor_Rifle = 1010,
		Armor_HMG = 1015,
		RHA_20mm = 1020,
		RHA_25mm = 1025,
		RHA_30mm = 1030,
		RHA_35mm = 1035,
		Light = 2001,
		Medium = 2002,
		Heavy = 2003,
		Special = 2004
	}

	public enum PatrolType : byte
	{
		ASW,
		ASuW_Naval,
		AAW,
		ASuW_Land,
		ASuW_Mixed,
		SEAD,
		SeaControl
	}

	public enum TargetVisualSizeClass : byte
	{
		Stealthy,
		VSmall,
		Small,
		Medium,
		Large,
		VLarge,
		Unknown
	}

	public enum UnitNoiseLevelClass : byte
	{
		Loud,
		Noisy,
		Quiet,
		VQuiet,
		ExQuiet
	}

	public enum ActiveUnitType : byte
	{
		None,
		Aircraft,
		Ship,
		Submarine,
		Facility,
		Aimpoint,
		Weapon,
		Satellite,
		Vehicle,
		Personnel,
		AggregateGroundUnit
	}

	public enum AircraftSizeClass : byte
	{
		None = 0,
		UAS_Class1_Micro = 1,
		UAS_Class1_Mini = 2,
		UAS_Class1_Small = 3,
		UAS_Class2 = 4,
		Small = 10,
		Medium = 20,
		Large = 30,
		VLarge = 40
	}

	public enum RunwayLengthClass
	{
		None = 1001,
		ManualLaunch = 1002,
		CatapultLaunched = 1101,
		VTOL = 2001,
		Between_1_250m = 3002,
		Between_1_450m = 3004,
		Between_451_900m = 3009,
		Between_901_1400m = 3014,
		Between_1401_2000m = 3020,
		Between_2001_2600m = 3026,
		Between_2601_3200m = 3032,
		Between_3201_4000m = 3040,
		Between_4000_5600m = 3056
	}

	public enum TechGenerationClass
	{
		None = 1001,
		NotApplicable = 1002,
		const_2 = 2001,
		const_3 = 2002,
		const_4 = 2003,
		const_5 = 2004,
		const_6 = 2005,
		const_7 = 2006,
		const_8 = 2007,
		const_9 = 2008,
		const_10 = 2009,
		const_11 = 2010,
		const_12 = 2011,
		const_13 = 2012,
		const_14 = 2013,
		const_15 = 2014,
		const_16 = 2015,
		const_17 = 2016,
		Visual = 2501,
		Visual_Gen1 = 2601,
		Visual_Gen2 = 2602,
		Visual_Gen3 = 2603,
		LLTV_Gen1 = 2701,
		LLTV_Gen2 = 2702,
		LLTV_Gen3 = 2703,
		IR_NonImaging = 2801,
		IR_Imaging_Gen1 = 2802,
		IR_Imaging_Gen2 = 2803,
		IR_Imaging_Gen3 = 2804,
		IR_SingleSpectral = 3001,
		IR_DualSpectral = 3002,
		IR_Imaging_FPA = 3003
	}

	public static string ApplicationStartupPath;

	public static long TimerCount;

	public static string FileDBConnString;

	public static string InMemoryConnString;

	public static bool Headless;

	public static BooleanObject ObjectTrue;

	public static BooleanObject ObjectFalse;

	public static bool AI_REWORK;

	public const bool USE_REWORK_AircractEvaluateUnitStatusDecisionChecklist = false;

	static GlobalVariables()
	{
		Class72.smethod_20();
		ApplicationStartupPath = Application.StartupPath;
		Headless = false;
		ObjectTrue = new BooleanObject();
		ObjectFalse = new BooleanObject();
		AI_REWORK = true;
	}
}
