using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[StandardModule]
internal sealed class DB_Enums
{
	public enum ModifierShipPassiveSonar
	{
		Mod_No_Signature_Modifiers = 1001,
		Mod_0_to_500T_Diesel_or_Gas_Turbines_PTM = 2001,
		Mod_0_to_500T_Diesel_Quiet_Propeller_MCM = 2002,
		Mod_501_to_1500T_Diesel_or_Gas_Turbines_FFL = 2003,
		Mod_501_to_1500T_Steam_FFL = 2004,
		Mod_501_to_1500T_Diesel_Quiet_Propeller_MCM = 2005,
		Mod_1501_to_5000T_Gas_Turbines_PM_FF = 3001,
		Mod_1501_to_5000T_Gas_Turbines_FF = 3002,
		Mod_1501_to_5000T_Diesel_PM_FF = 3003,
		Mod_1501_to_5000T_Diesel_FF = 3004,
		Mod_1501_to_5000T_Steam_Turbines_FF = 3005,
		Mod_1501_to_5000T_Steam_Turbines_PM_FF = 3006,
		Mod_1501_to_5000T_Diesel_Advanced_Silencing_and_Electric_Drive = 3007,
		Mod_5001_to_10000T_Gas_Turbines_PM_DD = 4001,
		Mod_5001_to_10000T_Gas_Turbines_DD = 4002,
		Mod_5001_to_10000T_Diesel_PM_DD = 4003,
		Mod_5001_to_10000T_Diesel_DD = 4004,
		Mod_5001_to_10000T_Steam_Turbines_DD = 4005,
		Mod_5001_to_10000T_Nuclear_DD = 4006,
		Mod_5001_to_10000T_Diesel_Advanced_Silencing_and_Electric_Drive = 4007,
		Mod_10001_to_25000T_Gas_Turbines_PM_CG = 5001,
		Mod_10001_to_25000T_Gas_Turbines_CG = 5002,
		Mod_10001_to_25000T_Diesel_PM_CG = 5003,
		Mod_10001_to_25000T_Diesel_CG = 5004,
		Mod_10001_to_25000T_Steam_Turbines_CG = 5005,
		Mod_10001_to_25000T_Nuclear_CG = 5006,
		Mod_25001_to_45000T_Gas_Turbines_LHA_or_LHD = 6002,
		Mod_25001_to_45000T_Diesel_LHA_or_LHD = 6003,
		Mod_25001_to_45000T_Steam_Turbines_CVH = 6004,
		Mod_25001_to_45000T_Nuclear_CVN = 6005,
		Mod_45001_to_95000T_Gas_Turbines_T_to_AKR = 7002,
		Mod_45001_to_95000T_Diesel_CV = 7003,
		Mod_45001_to_95000T_Steam_Turbines_CV_BB = 7004,
		Mod_45001_to_95000T_Nuclear_CVN = 7005,
		Mod_0_to_500T_Civilian = 8001,
		Mod_501_to_1500T_Civilian = 8002,
		Mod_1501_to_5000T_Civilian = 8003,
		Mod_5001_to_10000T_Civilian = 8004,
		Mod_10001_to_25000T_Civilian = 8005,
		Mod_25001_to_45000T_Civilian = 8006,
		Mod_45001_to_95000T_Civilian = 8007,
		Mod_95000T_Civilian = 8008,
		Mod_0_to_1500T_Air_Cushion_LCAC = 8901,
		Mod_Ship_Is_Not_Detectable = 9001
	}

	static DB_Enums()
	{
		Class72.smethod_20();
	}
}
