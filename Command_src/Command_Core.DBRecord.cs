using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using Command_Core.DAL;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class DBRecord
{
	public int DBID;

	public string Hash;

	public string DBName;

	public string FileName;

	public bool? IsSupportedByGame;

	public string ConnString;

	private List<string> list_0;

	public List<string> PlatFormIDs
	{
		get
		{
			if (list_0 == null)
			{
				list_0 = new List<string>();
				DataTable DT_Aircraft = new DataTable();
				DataTable DT_Ships = new DataTable();
				DataTable DT_Subs = new DataTable();
				DataTable DT_Facilities = new DataTable();
				DataTable DT_GroundUnits = new DataTable();
				DataTable DT_Satellites = new DataTable();
				DataTable DT_Weapons = new DataTable();
				SQLiteConnection sqliteConnection_ = new SQLiteConnection(ConnectionString);
				DBFunctions.GetPlatformLists(ref DT_Aircraft, ref DT_Ships, ref DT_Subs, ref DT_Facilities, ref DT_GroundUnits, ref DT_Satellites, ref DT_Weapons, ref sqliteConnection_, IncludeDeprecated: true);
				foreach (DataRow row in DT_Aircraft.Rows)
				{
					list_0.Add("Aircraft #" + row["ID"].ToString());
				}
				foreach (DataRow row2 in DT_Ships.Rows)
				{
					list_0.Add("Ship #" + row2["ID"].ToString());
				}
				foreach (DataRow row3 in DT_Subs.Rows)
				{
					list_0.Add("Submarine #" + row3["ID"].ToString());
				}
				foreach (DataRow row4 in DT_Facilities.Rows)
				{
					list_0.Add("Facility #" + row4["ID"].ToString());
				}
				foreach (DataRow row5 in DT_GroundUnits.Rows)
				{
					list_0.Add("GroundUnit #" + row5["ID"].ToString());
				}
				foreach (DataRow row6 in DT_Satellites.Rows)
				{
					list_0.Add("Satellite #" + row6["ID"].ToString());
				}
				foreach (DataRow row7 in DT_Weapons.Rows)
				{
					list_0.Add("Weapon #" + row7["ID"].ToString());
				}
			}
			return list_0;
		}
	}

	public bool IsRegistered => DBOps.RegisteredDBs().Contains(this);

	public bool LocalCopyExists => FileExistsNative.FileExistsFast(Path.Combine(GameGeneral.DBFolderPath, FileName));

	public string ConnectionString => "Data Source=" + Path.Combine(GameGeneral.DBFolderPath, FileName) + ";Version=3;Pooling=True;Max Pool Size=100;Read Only=True;";

	public bool IsTheLatestVersion => Operators.CompareString(DBOps.GetHashForMostRecentVersionOfThisDB(DBID), Hash, false) == 0;

	public DBRecord(int theDBID, string theHash, string string_0, string theFilename, bool IsSupported = false)
	{
		DBID = theDBID;
		Hash = theHash;
		DBName = string_0;
		FileName = theFilename;
		IsSupportedByGame = IsSupported;
	}

	public override string ToString()
	{
		return FileName.ToString() + " | " + DBName.ToString() + " | " + DBID + " | " + Hash.ToString() + " | Supported: " + IsSupportedByGame;
	}

	static DBRecord()
	{
		Class72.smethod_20();
	}
}
