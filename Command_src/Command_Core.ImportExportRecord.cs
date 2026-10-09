using System;
using System.Collections.Generic;

namespace Command_Core;

[Serializable]
public sealed class ImportExportRecord
{
	[Serializable]
	public sealed class MemberRecord
	{
		public int Member_DBID;

		public string Member_GUID;

		public string MemberType;

		public string MemberName;

		public string ParentGroupName;

		public string ParentGroupGUID;

		public double Longitude;

		public double Latitude;

		public double Altitude;

		public double Speed;

		public int LoadoutID;

		public float Orientation;

		public ActiveUnit_Navigator.FormationStation FormationStationPoint;

		public double FormationLatitude;

		public double FormationLongitude;

		public string LastFormationSet;

		public float LastFormationSpacing;

		public byte LastFormationSpacingUnits;

		public bool GroupLead;

		public List<HostedAircraftRecord> HostedAircraftRecords;

		public List<EmbarkedBoatRecord> EmbarkedBoatRecords;

		public List<MagazineRecord> MagazineRecords;

		public string Member_SBR;

		public MemberRecord()
		{
			ParentGroupName = null;
			ParentGroupGUID = null;
			FormationStationPoint = null;
			LastFormationSet = null;
			LastFormationSpacing = -1f;
			LastFormationSpacingUnits = 0;
			GroupLead = false;
			HostedAircraftRecords = new List<HostedAircraftRecord>();
			EmbarkedBoatRecords = new List<EmbarkedBoatRecord>();
			MagazineRecords = new List<MagazineRecord>();
		}

		static MemberRecord()
		{
			Class72.smethod_20();
		}
	}

	[Serializable]
	public sealed class HostedAircraftRecord
	{
		public string Name;

		public int AC_DBID;

		public int Loadout_ID;

		public int ReadyTime_Mins;

		public MemberRecord Member;

		public HostedAircraftRecord(string theName, int theAC_DBID, int theLoadout_ID, int theReadyTime_Mins)
		{
			Member = null;
			Name = theName;
			AC_DBID = theAC_DBID;
			Loadout_ID = theLoadout_ID;
			ReadyTime_Mins = theReadyTime_Mins;
		}

		public HostedAircraftRecord()
		{
			Member = null;
		}

		static HostedAircraftRecord()
		{
			Class72.smethod_20();
		}
	}

	[Serializable]
	public sealed class EmbarkedBoatRecord
	{
		public string Name;

		public int Boat_DBID;

		public int ReadyTime_Mins;

		public string Type;

		public MemberRecord Member;

		public EmbarkedBoatRecord(string theName, int theBoat_DBID, int theReadyTime_Mins, string theType)
		{
			Member = null;
			Name = theName;
			Boat_DBID = theBoat_DBID;
			ReadyTime_Mins = theReadyTime_Mins;
			Type = theType;
		}

		public EmbarkedBoatRecord()
		{
			Member = null;
		}

		static EmbarkedBoatRecord()
		{
			Class72.smethod_20();
		}
	}

	[Serializable]
	public sealed class WeaponRecord
	{
		public string Name;

		public int Weapon_DBID;

		public int Weapon_MaxLoad;

		public int Weapon_Multiple;

		public int Weapon_CurrentLoad;

		public int Weapon_ROF;

		public string Type;

		public WeaponRecord(string theName, int theWeapon_DBID, int theWeapon_MaxLoad, int theWeapon_Multiple, int theWeapon_CurrentLoad, int theWeapon_ROF)
		{
			Name = theName;
			Weapon_DBID = theWeapon_DBID;
			Weapon_MaxLoad = theWeapon_MaxLoad;
			Weapon_Multiple = theWeapon_Multiple;
			Weapon_CurrentLoad = theWeapon_CurrentLoad;
			Weapon_ROF = theWeapon_ROF;
		}

		public WeaponRecord()
		{
		}

		static WeaponRecord()
		{
			Class72.smethod_20();
		}
	}

	[Serializable]
	public sealed class MagazineRecord
	{
		public string Name;

		public int Mag_DBID;

		public int ReadyTime_Mins;

		public string Type;

		public List<WeaponRecord> WeaponRecords;

		public MagazineRecord(string theName, int theMag_DBID)
		{
			WeaponRecords = new List<WeaponRecord>();
			Name = theName;
			Mag_DBID = theMag_DBID;
		}

		public MagazineRecord()
		{
			WeaponRecords = new List<WeaponRecord>();
		}

		static MagazineRecord()
		{
			Class72.smethod_20();
		}
	}

	public int DB_ID;

	public int FormatVersion;

	public List<MemberRecord> MemberRecords;

	public string ValidFrom;

	public string ValidUntil;

	public string Name;

	public string Comments;

	public bool Template;

	public ImportExportRecord()
	{
		MemberRecords = new List<MemberRecord>();
	}

	static ImportExportRecord()
	{
		Class72.smethod_20();
	}
}
