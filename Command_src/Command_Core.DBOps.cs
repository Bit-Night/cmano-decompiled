using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class DBOps
{
	public delegate void DBLoadingCompleteEventHandler();

	public enum DatabaseMatchToleranceLevel : short
	{
		Undefined,
		ExactVersion,
		SameFamily,
		CompletelyNoMatch,
		UnableToCompare
	}

	public enum DBFileCheckResult
	{
		Undefined = 0,
		AllOK = 1,
		DBFileNotPresent = 2,
		DBIsUnregistered = 3,
		DBFileIsTampered = 4,
		UnspecifiedError = 9999
	}

	[CompilerGenerated]
	internal sealed class _Closure$__30-0
	{
		public int $VB$Local_theDB;

		public _Closure$__30-0(_Closure$__30-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theDB = arg0.$VB$Local_theDB;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(DBRecord theDBR)
		{
			if (theDBR.DBID == $VB$Local_theDB)
			{
				return theDBR.LocalCopyExists;
			}
			return false;
		}

		static _Closure$__30-0()
		{
			Class72.smethod_20();
		}
	}

	private static DataRow dataRow_0;

	private static DataRow dataRow_1;

	public static SQLiteConnection Conn_FileDB;

	[CompilerGenerated]
	[AccessedThroughProperty("_RegisteredDBs")]
	private static ObservableDictionary<string, DBRecord> observableDictionary_0;

	public static bool DBScanComplete_Registered;

	[CompilerGenerated]
	private static DBLoadingCompleteEventHandler dbloadingCompleteEventHandler_0;

	public static bool DBHasLegacyRunwayLengthEnum;

	private static XmlDocument xmlDocument_0;

	private static FileSystemWatcher fileSystemWatcher_0;

	public static bool DisableLongRunningDBCheck;

	public static event DBLoadingCompleteEventHandler DBLoadingComplete
	{
		[CompilerGenerated]
		add
		{
			DBLoadingCompleteEventHandler dBLoadingCompleteEventHandler = dbloadingCompleteEventHandler_0;
			DBLoadingCompleteEventHandler dBLoadingCompleteEventHandler2;
			do
			{
				dBLoadingCompleteEventHandler2 = dBLoadingCompleteEventHandler;
				DBLoadingCompleteEventHandler value2 = (DBLoadingCompleteEventHandler)Delegate.Combine(dBLoadingCompleteEventHandler2, value);
				dBLoadingCompleteEventHandler = Interlocked.CompareExchange(ref dbloadingCompleteEventHandler_0, value2, dBLoadingCompleteEventHandler2);
			}
			while ((object)dBLoadingCompleteEventHandler != dBLoadingCompleteEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			DBLoadingCompleteEventHandler dBLoadingCompleteEventHandler = dbloadingCompleteEventHandler_0;
			DBLoadingCompleteEventHandler dBLoadingCompleteEventHandler2;
			do
			{
				dBLoadingCompleteEventHandler2 = dBLoadingCompleteEventHandler;
				DBLoadingCompleteEventHandler value2 = (DBLoadingCompleteEventHandler)Delegate.Remove(dBLoadingCompleteEventHandler2, value);
				dBLoadingCompleteEventHandler = Interlocked.CompareExchange(ref dbloadingCompleteEventHandler_0, value2, dBLoadingCompleteEventHandler2);
			}
			while ((object)dBLoadingCompleteEventHandler != dBLoadingCompleteEventHandler2);
		}
	}

	static DBOps()
	{
		Class72.smethod_20();
		smethod_0(new ObservableDictionary<string, DBRecord>());
		DBScanComplete_Registered = false;
		DBHasLegacyRunwayLengthEnum = false;
		DisableLongRunningDBCheck = false;
	}

	[SpecialName]
	[CompilerGenerated]
	private static void smethod_0(ObservableDictionary<string, DBRecord> observableDictionary_1)
	{
		INotifyDictionaryChanged<string, DBRecord>.DictionaryChangedEventHandler obj = smethod_2;
		ObservableDictionary<string, DBRecord> observableDictionary = observableDictionary_0;
		if (observableDictionary != null)
		{
			observableDictionary.DictionaryChanged -= obj;
		}
		observableDictionary_0 = observableDictionary_1;
		observableDictionary = observableDictionary_0;
		if (observableDictionary != null)
		{
			observableDictionary.DictionaryChanged += obj;
		}
	}

	public static DatabaseMatchToleranceLevel smethod_1(string DBHash1, string DBHash2)
	{
		if (Operators.CompareString(DBHash1, DBHash2, false) != 0)
		{
			DBFileCheckResult theResult = default(DBFileCheckResult);
			DBRecord dBRecordByHash = GetDBRecordByHash(DBHash1, ref theResult, CheckLocalFileExists: false, CheckForTampering: false);
			if (dBRecordByHash != null)
			{
				DBRecord dBRecordByHash2 = GetDBRecordByHash(DBHash2, ref theResult, CheckLocalFileExists: false, CheckForTampering: false);
				if (dBRecordByHash2 == null)
				{
					return DatabaseMatchToleranceLevel.UnableToCompare;
				}
				if (dBRecordByHash.DBID == dBRecordByHash2.DBID)
				{
					return DatabaseMatchToleranceLevel.SameFamily;
				}
				return DatabaseMatchToleranceLevel.CompletelyNoMatch;
			}
			return DatabaseMatchToleranceLevel.UnableToCompare;
		}
		return DatabaseMatchToleranceLevel.ExactVersion;
	}

	public static ReadOnlyCollection<DBRecord> RegisteredDBs()
	{
		return new List<DBRecord>(observableDictionary_0.Values).AsReadOnly();
	}

	public static ReadOnlyCollection<DBRecord> UnregisteredDBs()
	{
		ReadOnlyCollection<DBRecord> result = default(ReadOnlyCollection<DBRecord>);
		return result;
	}

	public static void AddUnregisteredDB(string theHash, DBRecord theRecord)
	{
	}

	private static void smethod_2(object sender, NotifyDictionaryChangedEventArgs<string, DBRecord> e)
	{
	}

	public static void ScanDatabases()
	{
		GameGeneral.WriteLogDebugInfoToFile("Scanning DBs");
		smethod_12();
		GameGeneral.WriteLogDebugInfoToFile("Populated Registered DBs");
		DBScanComplete_Registered = true;
		smethod_6();
		dbloadingCompleteEventHandler_0?.Invoke();
	}

	internal static string EnglishMessageString(this DBFileCheckResult theResult)
	{
		switch (theResult)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return theResult.ToString();
		case DBFileCheckResult.UnspecifiedError:
			return "Unspecified error";
		case DBFileCheckResult.Undefined:
			return "Undefined result";
		case DBFileCheckResult.AllOK:
			return "Everything OK";
		case DBFileCheckResult.DBFileNotPresent:
			return "Database file was not found - Please contact the database author to obtain a copy of this version of the database";
		case DBFileCheckResult.DBIsUnregistered:
			return "Database is unregistered";
		case DBFileCheckResult.DBFileIsTampered:
			return "The database file has been tampered";
		}
	}

	private static XmlDocument smethod_3()
	{
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_0066: Expected O, but got Unknown
		if (xmlDocument_0 == null)
		{
			if (FileExistsNative.FileExistsFast(Path.Combine(GameGeneral.DBFolderPath, "DBInfo.dat")))
			{
				StreamReader streamReader = new StreamReader(Path.Combine(GameGeneral.DBFolderPath, "DBInfo.dat"));
				string cipherText;
				using (streamReader)
				{
					cipherText = streamReader.ReadToEnd();
				}
				cipherText = Crypto.DecryptStringAES(cipherText);
				XmlDocument val = new XmlDocument();
				val.LoadXml(cipherText);
				xmlDocument_0 = val;
				return val;
			}
			return null;
		}
		return xmlDocument_0;
	}

	internal static bool DBHasBeenTampered(DBRecord theDBR)
	{
		string fileHashFromFilename = Crypto.GetFileHashFromFilename(Path.Combine(GameGeneral.DBFolderPath, theDBR.FileName));
		string hash = theDBR.Hash;
		return Operators.CompareString(fileHashFromFilename, hash, false) != 0;
	}

	public static DBRecord GetDBRecordByHash(string theHash, ref DBFileCheckResult theResult, bool CheckLocalFileExists = true, bool CheckForTampering = true)
	{
		DBRecord result;
		try
		{
			DBRecord dBRecord = null;
			if (observableDictionary_0.ContainsKey(theHash))
			{
				dBRecord = observableDictionary_0[theHash];
				if (CheckLocalFileExists && !dBRecord.LocalCopyExists)
				{
					theResult = DBFileCheckResult.DBFileNotPresent;
					result = null;
				}
				else if (CheckForTampering && DBHasBeenTampered(dBRecord))
				{
					theResult = DBFileCheckResult.DBFileIsTampered;
					result = null;
				}
				else
				{
					if (dBRecord.DBID == 0)
					{
						SQLiteConnection theConn = new SQLiteConnection(smethod_4(Application.StartupPath, theHash));
						SQLiteHelper sQLiteHelper = new SQLiteHelper(theConn);
						string string_ = "SELECT Name FROM DataComm where ID = 3";
						DataTable dataTable = sQLiteHelper.ExecuteDataTable(string_);
						string text = "";
						if (dataTable.Rows.Count != 0)
						{
							text = dataTable.Rows[0][0].ToString();
						}
						else
						{
							dBRecord.DBID = 3;
						}
						if (Operators.CompareString(text, "AS.20 Command Datalink", false) == 0)
						{
							dBRecord.DBID = 2;
						}
						else if (Operators.CompareString(text, "SA-10 Missile Datalink", false) == 0)
						{
							dBRecord.DBID = 1;
						}
					}
					theResult = DBFileCheckResult.AllOK;
					result = dBRecord;
				}
			}
			else
			{
				result = null;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			theResult = DBFileCheckResult.UnspecifiedError;
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static (DBRecord, DBFileCheckResult) GetDBRecordByFilename(string theFileName, bool bool_0)
	{
		(DBRecord, DBFileCheckResult) result;
		try
		{
			DBRecord dBRecord = null;
			foreach (DBRecord value in observableDictionary_0.Values)
			{
				if (string.Equals(value.FileName, Path.GetFileName(theFileName), StringComparison.OrdinalIgnoreCase))
				{
					return (value, DBFileCheckResult.AllOK);
				}
			}
			return (null, DBFileCheckResult.DBFileNotPresent);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = (null, DBFileCheckResult.UnspecifiedError);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static bool DBIsRegistered(string theHash)
	{
		return observableDictionary_0.ContainsKey(theHash);
	}

	public static string GetHashForMostRecentVersionOfThisDB(int theDB)
	{
		_Closure$__30-0 arg = default(_Closure$__30-0);
		_Closure$__30-0 CS$<>8__locals3 = new _Closure$__30-0(arg);
		CS$<>8__locals3.$VB$Local_theDB = theDB;
		int num = 0;
		while (observableDictionary_0.Count == 0)
		{
			if (!DBScanComplete_Registered)
			{
				Thread.Sleep(100);
				num += 100;
				if (num >= 10000)
				{
					GameGeneral.WriteLogDebugInfoToFile("Waited 10 seconds for Registered DBs to load.");
					num = 0;
				}
				continue;
			}
			throw new Exception("Error: Scan completed but Registered DBs list contains no items");
		}
		try
		{
			DBRecord dBRecord = (from theDBR in RegisteredDBs()
				where theDBR.DBID == CS$<>8__locals3.$VB$Local_theDB && theDBR.LocalCopyExists
				select theDBR).FirstOrDefault();
			if (dBRecord != null)
			{
				GameGeneral.WriteLogDebugInfoToFile("Latest Registered DB hash fetched.");
				return dBRecord.Hash;
			}
			Dictionary<string, DBRecord> dictionary = new Dictionary<string, DBRecord>();
			foreach (KeyValuePair<string, DBRecord> item in observableDictionary_0)
			{
				dictionary.Add(item.Key, item.Value);
			}
			IOrderedEnumerable<KeyValuePair<string, DBRecord>> orderedEnumerable = dictionary.OrderByDescending([SpecialName] (KeyValuePair<string, DBRecord> theKVP) => new FileInfo(Path.Combine(GameGeneral.DBFolderPath, theKVP.Value.FileName)).LastWriteTime);
			foreach (KeyValuePair<string, DBRecord> item2 in orderedEnumerable)
			{
				if (item2.Value.DBID == CS$<>8__locals3.$VB$Local_theDB && item2.Value.LocalCopyExists)
				{
					GameGeneral.WriteLogDebugInfoToFile("Specific DB hash fetched.");
					return item2.Key;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 281343", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		throw new Exception("No DB versions were found for this ID number!");
	}

	public static string smethod_4(string ApplicationPath, string desiredDB_Hash)
	{
		bool flag = false;
		DBRecord dBRecord = null;
		try
		{
			if (observableDictionary_0.ContainsKey(desiredDB_Hash))
			{
				flag = true;
				dBRecord = observableDictionary_0[desiredDB_Hash];
			}
			if (dBRecord == null)
			{
				throw new DBFileNotFoundException("You have (explicitly or implicitly) attempted to load a database that does not exist on the DB folder.");
			}
			if (!dBRecord.LocalCopyExists)
			{
				string text = "You have (explicitly or implicitly) attempted to load a database (" + dBRecord.DBName + ") that does not exist on the DB folder. ";
				text = ((!flag) ? (text + "The database is unregistered, and has the file hash: " + desiredDB_Hash + ". Please contact the DB authors to see if any of their DB versions corresponds to this hash, in order to obtain it.") : (text + "The database is registered under the name: " + dBRecord.DBName + ". Please contact the author of this database for a copy."));
				throw new DBFileNotFoundException(text);
			}
			return dBRecord.ConnectionString;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private static void smethod_5()
	{
	}

	private static void smethod_6()
	{
		fileSystemWatcher_0 = new FileSystemWatcher();
		fileSystemWatcher_0.Path = GameGeneral.DBFolderPath;
		fileSystemWatcher_0.IncludeSubdirectories = false;
		fileSystemWatcher_0.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite;
		fileSystemWatcher_0.Filter = "*.db3";
		fileSystemWatcher_0.Changed += smethod_9;
		fileSystemWatcher_0.Created += smethod_8;
		fileSystemWatcher_0.Renamed += smethod_7;
		fileSystemWatcher_0.Deleted += smethod_10;
		fileSystemWatcher_0.EnableRaisingEvents = true;
	}

	private static void smethod_7(object sender, FileSystemEventArgs e)
	{
		smethod_11(e.Name);
	}

	private static void smethod_8(object sender, FileSystemEventArgs e)
	{
		smethod_11(e.Name);
	}

	private static void smethod_9(object sender, FileSystemEventArgs e)
	{
		smethod_11(e.Name);
	}

	private static void smethod_10(object object_0, object object_1)
	{
	}

	private static void smethod_11(string string_0)
	{
		if (!string_0.EndsWith(".db3"))
		{
			return;
		}
		List<DBRecord> list = observableDictionary_0.Values.ToList();
		foreach (DBRecord item in list)
		{
			if (Operators.CompareString(item.FileName, Path.GetFileName(string_0), false) == 0)
			{
				string text;
				try
				{
					text = Crypto.GetFileHashFromFilename(Path.Combine(GameGeneral.DBFolderPath, item.FileName));
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					text = Crypto.GetFileHashViaTempCopy(Path.Combine(GameGeneral.DBFolderPath, item.FileName));
					ProjectData.ClearProjectError();
				}
				if (Operators.CompareString(text, item.Hash, false) != 0)
				{
					GameGeneral.WriteExceptionsToLog(new Exception("DB integrity check failed for DB file: " + item.FileName + ". Program will now exit."));
					Environment.Exit(0);
				}
			}
		}
	}

	private static void smethod_12()
	{
		//IL_0aad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab3: Expected O, but got Unknown
		observableDictionary_0.Clear();
		observableDictionary_0.Add("8a8e994942940448e5d80c4ed83771539b4c1d82", new DBRecord(1, "8a8e994942940448e5d80c4ed83771539b4c1d82", "DB3000 v519", "DB3K_519.db3", IsSupported: true));
		observableDictionary_0.Add("7a4122d374b8aa45a965a6359499ff12f1c162b9", new DBRecord(2, "7a4122d374b8aa45a965a6359499ff12f1c162b9", "Cold War DB v519", "CWDB_519.db3", IsSupported: true));
		observableDictionary_0.Add("0e272cc4f0d65864391bfdd1144a72359eb40265", new DBRecord(1, "0e272cc4f0d65864391bfdd1144a72359eb40265", "DB3000 v518", "DB3K_518.db3", IsSupported: true));
		observableDictionary_0.Add("b5142a35aef766ad1b8e48833b7a2453f8037cad", new DBRecord(2, "b5142a35aef766ad1b8e48833b7a2453f8037cad", "Cold War DB v518", "CWDB_518.db3", IsSupported: true));
		observableDictionary_0.Add("043954351a1eda4b3c1f596e9f1d8981c03ed6ed", new DBRecord(1, "043954351a1eda4b3c1f596e9f1d8981c03ed6ed", "DB3000 v517", "DB3K_517.db3", IsSupported: true));
		observableDictionary_0.Add("4ed8f255ea12a45fbecd13acd2b0c3619b98884c", new DBRecord(2, "4ed8f255ea12a45fbecd13acd2b0c3619b98884c", "Cold War DB v517", "CWDB_517.db3", IsSupported: true));
		observableDictionary_0.Add("4331ad536d5e41fd0c3dfae5752d100c8c43ceac", new DBRecord(1, "4331ad536d5e41fd0c3dfae5752d100c8c43ceac", "DB3000 v516", "DB3K_516.db3", IsSupported: true));
		observableDictionary_0.Add("9539891be24ae2e29e1b6718d77f95df7781c0fb", new DBRecord(2, "9539891be24ae2e29e1b6718d77f95df7781c0fb", "Cold War DB v516", "CWDB_516.db3", IsSupported: true));
		observableDictionary_0.Add("e67bf455a6c97c6e2c7ac83379e8ccb66ac4d69d", new DBRecord(1, "e67bf455a6c97c6e2c7ac83379e8ccb66ac4d69d", "DB3000 v515", "DB3K_515.db3", IsSupported: true));
		observableDictionary_0.Add("335571675b5beff61639640e7f1f7822f9cedf7a", new DBRecord(2, "335571675b5beff61639640e7f1f7822f9cedf7a", "Cold War DB v514", "CWDB_514.db3", IsSupported: true));
		observableDictionary_0.Add("2fe4bc37289e9a7cafe2c36bc2e80627d3c1b8f7", new DBRecord(1, "2fe4bc37289e9a7cafe2c36bc2e80627d3c1b8f7", "DB3000 v514", "DB3K_514.db3", IsSupported: true));
		observableDictionary_0.Add("e94e9b2baa841faca2d22990fb57015b0fe9c296", new DBRecord(2, "e94e9b2baa841faca2d22990fb57015b0fe9c296", "Cold War DB v513", "CWDB_513.db3", IsSupported: true));
		observableDictionary_0.Add("1e2411214a728732dc32ab037535ac7d3f1230ab", new DBRecord(1, "1e2411214a728732dc32ab037535ac7d3f1230ab", "DB3000 v513", "DB3K_513.db3", IsSupported: true));
		observableDictionary_0.Add("9fcee9e9c2b82a67c1e5361c54158688b4d54b58", new DBRecord(2, "9fcee9e9c2b82a67c1e5361c54158688b4d54b58", "Cold War DB v512", "CWDB_512.db3", IsSupported: true));
		observableDictionary_0.Add("57334daf25e33862c175b267a67b3b66b3ff82c7", new DBRecord(1, "57334daf25e33862c175b267a67b3b66b3ff82c7", "DB3000 v512", "DB3K_512.db3", IsSupported: true));
		observableDictionary_0.Add("bf33a33b45406c639bdb124619413372cef7a683", new DBRecord(1, "bf33a33b45406c639bdb124619413372cef7a683", "DB3000 v511", "DB3K_511.db3", IsSupported: true));
		observableDictionary_0.Add("5f78b73f9529b5fdd60d8e0cc41c7997dd053886", new DBRecord(1, "5f78b73f9529b5fdd60d8e0cc41c7997dd053886", "DB3000 v510", "DB3K_510.db3", IsSupported: true));
		observableDictionary_0.Add("d8d52c62e51511d6e2c3c17efb0001cb4f567c2b", new DBRecord(2, "d8d52c62e51511d6e2c3c17efb0001cb4f567c2b", "Cold War DB v509", "CWDB_509.db3", IsSupported: true));
		observableDictionary_0.Add("51ecc8af7f3cd15ba50b8e8869f6a05ff7ec5284", new DBRecord(1, "51ecc8af7f3cd15ba50b8e8869f6a05ff7ec5284", "DB3000 v509", "DB3K_509.db3", IsSupported: true));
		observableDictionary_0.Add("6264f3d6e682f1746371c0cb40b8246e157a5328", new DBRecord(2, "6264f3d6e682f1746371c0cb40b8246e157a5328", "Cold War DB v508", "CWDB_508.db3", IsSupported: true));
		observableDictionary_0.Add("3d5b62bb8cd754dc35c2fe6f13c037c38a632257", new DBRecord(1, "3d5b62bb8cd754dc35c2fe6f13c037c38a632257", "DB3000 v508", "DB3K_508.db3", IsSupported: true));
		observableDictionary_0.Add("c9924f21ae451ca2aa6133ccd3a64db23e4b2ea3", new DBRecord(2, "c9924f21ae451ca2aa6133ccd3a64db23e4b2ea3", "Cold War DB v507", "CWDB_507.db3", IsSupported: true));
		observableDictionary_0.Add("eeaeb37cc92aa6b380b7f2099557abcc6c844940", new DBRecord(1, "eeaeb37cc92aa6b380b7f2099557abcc6c844940", "DB3000 v507", "DB3K_507.db3", IsSupported: true));
		observableDictionary_0.Add("e968d2845a98cd34db919d5c0f30820b998f4d41", new DBRecord(2, "e968d2845a98cd34db919d5c0f30820b998f4d41", "Cold War DB v506", "CWDB_506.db3", IsSupported: true));
		observableDictionary_0.Add("e14918aac497207883402eda77765f7a93f1b132", new DBRecord(1, "e14918aac497207883402eda77765f7a93f1b132", "DB3000 v506", "DB3K_506.db3", IsSupported: true));
		observableDictionary_0.Add("bf56914414bfb6c27f358cd41cac597388604ce4", new DBRecord(2, "bf56914414bfb6c27f358cd41cac597388604ce4", "Cold War DB v505", "CWDB_505.db3", IsSupported: true));
		observableDictionary_0.Add("e6f46f4b1497aea6fd75bbb2aaafc5e155906700", new DBRecord(1, "e6f46f4b1497aea6fd75bbb2aaafc5e155906700", "DB3000 v505", "DB3K_505.db3", IsSupported: true));
		observableDictionary_0.Add("24ac7c450f8fe53cb8702aeae422aa6ed6f1d569", new DBRecord(2, "24ac7c450f8fe53cb8702aeae422aa6ed6f1d569", "Cold War DB v504", "CWDB_504.db3", IsSupported: true));
		observableDictionary_0.Add("1e0f7bd989b26b132f7ba0ba01b8c12da819ca64", new DBRecord(1, "1e0f7bd989b26b132f7ba0ba01b8c12da819ca64", "DB3000 v504", "DB3K_504.db3", IsSupported: true));
		observableDictionary_0.Add("b19034375a41170519b8282bc14a87038d47d585", new DBRecord(2, "b19034375a41170519b8282bc14a87038d47d585", "Cold War DB v503", "CWDB_503.db3", IsSupported: true));
		observableDictionary_0.Add("ae3ab5a26ebbd32ff52b97e61d86e897c13545ce", new DBRecord(1, "ae3ab5a26ebbd32ff52b97e61d86e897c13545ce", "DB3000 v503", "DB3K_503.db3", IsSupported: true));
		observableDictionary_0.Add("72afb353ac2e805a593386198ea8cf7c7ebab6f1", new DBRecord(2, "72afb353ac2e805a593386198ea8cf7c7ebab6f1", "Cold War DB v502", "CWDB_502.db3", IsSupported: true));
		observableDictionary_0.Add("9808e0c1b7d8384f5e3a55e97b22a047fc23056c", new DBRecord(1, "9808e0c1b7d8384f5e3a55e97b22a047fc23056c", "DB3000 v502", "DB3K_502.db3", IsSupported: true));
		observableDictionary_0.Add("2d8b74305f86e13fe1ac0c8c450e14ea9993f616", new DBRecord(2, "2d8b74305f86e13fe1ac0c8c450e14ea9993f616", "Cold War DB v501", "CWDB_501.db3", IsSupported: true));
		observableDictionary_0.Add("4bd100793c6128c6ab2524e20b6ac0abcf45219c", new DBRecord(1, "4bd100793c6128c6ab2524e20b6ac0abcf45219c", "DB3000 v501", "DB3K_501.db3", IsSupported: true));
		observableDictionary_0.Add("0287bd975dc24ff6dedf2eaf32a2b6ea7ca194b3", new DBRecord(2, "0287bd975dc24ff6dedf2eaf32a2b6ea7ca194b3", "Cold War DB v500", "CWDB_500.db3", IsSupported: true));
		observableDictionary_0.Add("32b334eca811cd7277b8ff04a1329a76164c5cd6", new DBRecord(1, "32b334eca811cd7277b8ff04a1329a76164c5cd6", "DB3000 v500", "DB3K_500.db3", IsSupported: true));
		observableDictionary_0.Add("6167e080e25a1e1d717e190ebade2b8d493dea35", new DBRecord(2, "6167e080e25a1e1d717e190ebade2b8d493dea35", "Cold War DB v499", "CWDB_499.db3", IsSupported: true));
		observableDictionary_0.Add("4eb6c0374fe9544093cc3709590504659a760b63", new DBRecord(1, "4eb6c0374fe9544093cc3709590504659a760b63", "DB3000 v499", "DB3K_499.db3", IsSupported: true));
		observableDictionary_0.Add("dd2e1df88867fe83c69f2dab4d3613f1280bd86e", new DBRecord(1, "dd2e1df88867fe83c69f2dab4d3613f1280bd86e", "DB3000 v498a", "DB3K_498a.db3", IsSupported: true));
		observableDictionary_0.Add("dee1efb6e712e11f8ab23a375288072110f55e5c", new DBRecord(2, "dee1efb6e712e11f8ab23a375288072110f55e5c", "Cold War DB v498", "CWDB_498.db3", IsSupported: true));
		observableDictionary_0.Add("1707b7612750553b77917fecb3ed84bcbab4b92e", new DBRecord(1, "1707b7612750553b77917fecb3ed84bcbab4b92e", "DB3000 v498", "DB3K_498.db3", IsSupported: true));
		observableDictionary_0.Add("6f5f4f94b0810006008398394f161d3e5833e539", new DBRecord(1, "6f5f4f94b0810006008398394f161d3e5833e539", "DB3000 v497a", "DB3K_497a.db3", IsSupported: true));
		observableDictionary_0.Add("ed5b39742437472aa6ff43c02ed56fd6eff65511", new DBRecord(1, "ed5b39742437472aa6ff43c02ed56fd6eff65511", "DB3000 v497", "DB3K_497.db3", IsSupported: true));
		observableDictionary_0.Add("25194d37a18c34bc5dc5dfa69b48e9b2d5584b86", new DBRecord(2, "25194d37a18c34bc5dc5dfa69b48e9b2d5584b86", "Cold War DB v497", "CWDB_497.db3", IsSupported: true));
		observableDictionary_0.Add("0512e27f11561bdd39b6aa189d792d115ca03f51", new DBRecord(1, "0512e27f11561bdd39b6aa189d792d115ca03f51", "DB3000 v496", "DB3K_496.db3", IsSupported: true));
		observableDictionary_0.Add("d565fe1f16dd3c3a7b652efbbff10ad4654b45da", new DBRecord(2, "d565fe1f16dd3c3a7b652efbbff10ad4654b45da", "Cold War DB v496", "CWDB_496.db3", IsSupported: true));
		observableDictionary_0.Add("b383294e8525920ba56f90cc4c61d6a3d86781e0", new DBRecord(1, "b383294e8525920ba56f90cc4c61d6a3d86781e0", "DB3000 v495", "DB3K_495.db3", IsSupported: true));
		observableDictionary_0.Add("07230c2d0242787a5f69888b8296dd7a39d3eaf2", new DBRecord(2, "07230c2d0242787a5f69888b8296dd7a39d3eaf2", "Cold War DB v495", "CWDB_495.db3", IsSupported: true));
		observableDictionary_0.Add("ec989b5b028a2f53b0013f7e5d8d56a040cd704c", new DBRecord(1, "ec989b5b028a2f53b0013f7e5d8d56a040cd704c", "DB3000 v494", "DB3K_494.db3", IsSupported: true));
		observableDictionary_0.Add("2e0e362f0b590f0f44cb6b12cb6086890afebd8e", new DBRecord(2, "2e0e362f0b590f0f44cb6b12cb6086890afebd8e", "Cold War DB v494", "CWDB_494.db3", IsSupported: true));
		observableDictionary_0.Add("b233518914717e121a7f8c9a9fd86245a688a6d0", new DBRecord(1, "b233518914717e121a7f8c9a9fd86245a688a6d0", "DB3000 v493", "DB3K_493.db3", IsSupported: true));
		observableDictionary_0.Add("2479ac0d01508bfbb1b77802f8c1a65933adc8db", new DBRecord(2, "2479ac0d01508bfbb1b77802f8c1a65933adc8db", "Cold War DB v493", "CWDB_493.db3", IsSupported: true));
		observableDictionary_0.Add("9f67f26e2bf6ac67de804217463545cfc9c28fef", new DBRecord(2, "9f67f26e2bf6ac67de804217463545cfc9c28fef", "Cold War DB v492", "CWDB_492.db3", IsSupported: true));
		observableDictionary_0.Add("6b038bcf7388e314a700292ccb7a5599e5b566eb", new DBRecord(1, "6b038bcf7388e314a700292ccb7a5599e5b566eb", "DB3000 v492", "DB3K_492.db3", IsSupported: true));
		observableDictionary_0.Add("a416d385c7d7b12c4e3ba2ad3acb3c7cae9ee44f", new DBRecord(2, "a416d385c7d7b12c4e3ba2ad3acb3c7cae9ee44f", "Cold War DB v491", "CWDB_491.db3", IsSupported: true));
		observableDictionary_0.Add("c7974674be0ba1ea5b751fb0240fbeb4261ea86b", new DBRecord(1, "c7974674be0ba1ea5b751fb0240fbeb4261ea86b", "DB3000 v491", "DB3K_491.db3", IsSupported: true));
		observableDictionary_0.Add("9cccd1313526d354281216a13d6336badb34fb50", new DBRecord(2, "9cccd1313526d354281216a13d6336badb34fb50", "Cold War DB v490", "CWDB_490.db3", IsSupported: true));
		observableDictionary_0.Add("80c442a52212456cfc52a0c3d4407293bc4fd540", new DBRecord(1, "80c442a52212456cfc52a0c3d4407293bc4fd540", "DB3000 v490", "DB3K_490.db3", IsSupported: true));
		observableDictionary_0.Add("c74ad04cb177789c1233b3ae8435c800d7f057cf", new DBRecord(1, "c74ad04cb177789c1233b3ae8435c800d7f057cf", "DB3000 v489", "DB3K_489.db3", IsSupported: true));
		observableDictionary_0.Add("b32f460e36fa1db6c450ae79bd15dfff82c885ad", new DBRecord(1, "b32f460e36fa1db6c450ae79bd15dfff82c885ad", "DB3000 v488", "DB3K_488.db3", IsSupported: true));
		observableDictionary_0.Add("7affd98881d0ad7b5eba7c2864786d248c2cd2ec", new DBRecord(1, "7affd98881d0ad7b5eba7c2864786d248c2cd2ec", "DB3000 v487", "DB3K_487.db3", IsSupported: true));
		observableDictionary_0.Add("73dff9040defc1d403c731b633e133b21ccd8529", new DBRecord(1, "73dff9040defc1d403c731b633e133b21ccd8529", "DB3000 v486", "DB3K_486.db3", IsSupported: true));
		observableDictionary_0.Add("d41e66e4221108cfd310b65d6fe9b4025a05f96e", new DBRecord(1, "d41e66e4221108cfd310b65d6fe9b4025a05f96e", "DB3000 v486 RC1", "DB3K_486_RC1.db3", IsSupported: true));
		observableDictionary_0.Add("fc92021b44f60672f0f5cf0ffb0d4ae391e307ef", new DBRecord(1, "fc92021b44f60672f0f5cf0ffb0d4ae391e307ef", "DB3000 v485", "DB3K_485.db3", IsSupported: true));
		observableDictionary_0.Add("51dd2d405f26ac32b145a367abf2f60f63b56994", new DBRecord(1, "51dd2d405f26ac32b145a367abf2f60f63b56994", "DB3000 v484", "DB3K_484.db3", IsSupported: true));
		observableDictionary_0.Add("22fe77d8f42ed779a83fe53ee7bc91d4487c8477", new DBRecord(1, "22fe77d8f42ed779a83fe53ee7bc91d4487c8477", "DB3000 v483", "DB3K_483.db3", IsSupported: true));
		observableDictionary_0.Add("3f3b638febee9b0e6ae0c526644988f5d63507f3", new DBRecord(1, "3f3b638febee9b0e6ae0c526644988f5d63507f3", "DB3000 v482", "DB3K_482.db3", IsSupported: true));
		observableDictionary_0.Add("71b78d3037b0f4e610b9772136517ef14817d4a0", new DBRecord(1, "71b78d3037b0f4e610b9772136517ef14817d4a0", "DB3000 v481a", "DB3K_481a.db3", IsSupported: true));
		observableDictionary_0.Add("b439f8334b9767c4b6e6f9b2ca93c86f2d773a30", new DBRecord(1, "b439f8334b9767c4b6e6f9b2ca93c86f2d773a30", "DB3000 v480", "DB3K_480.db3", IsSupported: true));
		observableDictionary_0.Add("59b67f39e1a31b6f6ee843b9acfa8d1e368133c9", new DBRecord(2, "59b67f39e1a31b6f6ee843b9acfa8d1e368133c9", "Cold War DB v478", "CWDB_478.db3", IsSupported: true));
		observableDictionary_0.Add("e37e2e6e6522b3ba52a20b791dc854ce3e54d9f1", new DBRecord(1, "e37e2e6e6522b3ba52a20b791dc854ce3e54d9f1", "DB3000 v479", "DB3K_479.db3", IsSupported: true));
		GameGeneral.WriteLogDebugInfoToFile("Populated static Registered DBs");
		XmlDocument val = smethod_3();
		if (val == null)
		{
			return;
		}
		XmlNode val2 = ((XmlNode)val).SelectSingleNode("/DBFiles");
		foreach (XmlNode childNode in val2.ChildNodes)
		{
			XmlNode val3 = childNode;
			DBRecord dBRecord = new DBRecord(Conversions.ToInteger(val3.SelectSingleNode("DBID").InnerText), val3.SelectSingleNode("Hash").InnerText, val3.SelectSingleNode("Name").InnerText, val3.SelectSingleNode("File").InnerText, Conversions.ToBoolean(val3.SelectSingleNode("Supported").InnerText));
			if (FileExistsNative.FileExistsFast(Path.Combine(GameGeneral.DBFolderPath, dBRecord.FileName)) && !observableDictionary_0.ContainsKey(dBRecord.Hash))
			{
				observableDictionary_0.Add(dBRecord.Hash, dBRecord);
			}
		}
	}
}
