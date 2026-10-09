using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.Office.Interop.Access.Dao;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[StandardModule]
public sealed class Common
{
	public enum DatabaseCategory : short
	{
		DB_1980_2020,
		DB_1946_1979,
		DB_1939_1945
	}

	public static Database theSourceDB;

	public static Database theTargetDB;

	public static string theSourceMsAccessFileName;

	public static string theTargetMsAccessFileName;

	public static OleDbConnection mySourceDB_Conn;

	public static OleDbConnection myTargetDB_Conn;

	public static MSAccessHelper mySourceDB_Helper;

	public static MSAccessHelper myTargetDB_Helper;

	public static DatabaseCategory? mySourceDB_Category;

	public static DatabaseCategory? myTargetDB_Category;

	public static string StatusString;

	public static string QueryValidateAircraftPropulsion;

	public static string QueryValidateFuelDuplicates;

	public static string QueryValidateMountStdArcs;

	public static string QueryValidateShipPropulsion;

	public static string QueryValidateWeaponPropulsion;

	public static string QueryValidateHelicopterPropulsion;

	public static string QueryValidateAircraftFacilityDuplicates;

	public static string QueryValidateDockingFacilityDuplicates;

	public static string QueryValidateSensorStdArcs;

	public static string QueryValidateSubmarinePropulsion;

	public static string QueryValidateWarheadWeaponLink;

	public static string QueryValidateWarheadDP;

	public static string QueryValidateWeaponHasNoDirector;

	public static string QueryValidateWeaponRecordDuplicates;

	private static DataTable dataTable_0;

	private static DataTable dataTable_1;

	private static DataTable dataTable_2;

	private static DataTable dataTable_3;

	private static DataTable dataTable_4;

	private static DataTable dataTable_5;

	private static DataTable dataTable_6;

	private static DataTable dataTable_7;

	private static DataTable dataTable_8;

	private static DataTable dataTable_9;

	private static DataTable dataTable_10;

	private static DataTable dataTable_11;

	private static DataTable dataTable_12;

	private static DataTable dataTable_13;

	private static DataTable dataTable_14;

	private static DataTable dataTable_15;

	private static DataTable dataTable_16;

	private static DataTable dataTable_17;

	private static DataTable dataTable_18;

	private static DataTable dataTable_19;

	private static DataTable dataTable_20;

	private static DataTable dataTable_21;

	private static DataTable dataTable_22;

	private static DataTable dataTable_23;

	private static DataTable dataTable_24;

	private static DataTable dataTable_25;

	private static DataTable dataTable_26;

	private static DataTable dataTable_27;

	private static DataTable dataTable_28;

	private static DataTable dataTable_29;

	private static DataTable dataTable_30;

	private static DataTable dataTable_31;

	private static DataTable dataTable_32;

	private static DataTable dataTable_33;

	private static DataTable dataTable_34;

	private static DataTable dataTable_35;

	private static DataTable dataTable_36;

	private static DataTable dataTable_37;

	private static DataTable dataTable_38;

	private static DataTable dataTable_39;

	private static DataTable dataTable_40;

	private static DataTable dataTable_41;

	private static DataTable TeaFkxInht;

	private static DataTable dataTable_42;

	private static DataTable dataTable_43;

	private static DataTable dataTable_44;

	private static DataTable dataTable_45;

	private static DataTable dataTable_46;

	private static DataTable dataTable_47;

	private static DataTable dataTable_48;

	private static DataTable dataTable_49;

	private static DataTable dataTable_50;

	private static DataTable dataTable_51;

	private static DataTable dataTable_52;

	private static DataTable dataTable_53;

	private static DataTable dataTable_54;

	private static DataTable dataTable_55;

	private static DataTable dataTable_56;

	private static DataTable dataTable_57;

	private static DataTable dataTable_58;

	private static DataTable dataTable_59;

	private static DataTable dataTable_60;

	private static DataTable dataTable_61;

	private static DataTable dataTable_62;

	private static DataTable dataTable_63;

	private static DataTable dataTable_64;

	private static DataTable dataTable_65;

	private static DataTable dataTable_66;

	private static DataTable dataTable_67;

	private static DataTable dataTable_68;

	private static DataTable dataTable_69;

	private static DataTable EDHFKGLOXJ;

	private static DataTable dataTable_70;

	private static DataTable dataTable_71;

	private static DataTable dataTable_72;

	private static DataTable dataTable_73;

	private static DataTable dataTable_74;

	private static DataTable dataTable_75;

	private static DataTable dataTable_76;

	private static DataTable dataTable_77;

	private static DataTable dataTable_78;

	private static DataTable dataTable_79;

	public static DatabaseCategory? GetDatabaseCategory
	{
		get
		{
			DatabaseCategory? result = default(DatabaseCategory?);
			try
			{
				if (!DoesTableExist(ref theDatabase, "ManagementMisc"))
				{
					theMSAccessHelper.ExecuteNonQuery("CREATE TABLE ManagementMisc ([ID] INTEGER, [Description] CHAR, [Value] SMALLINT, [Comment] CHAR);");
					theMSAccessHelper.ExecuteNonQuery("INSERT INTO ManagementMisc ([ID], [Description], [Value], [Comment]) VALUES (1, 'OperatingMode', 0, 'Developer (0) or Customer (1)');");
					theMSAccessHelper.ExecuteNonQuery("INSERT INTO ManagementMisc ([ID], [Description], [Value], [Comment]) VALUES (2, 'DatabaseCategory', 0, '1980-2020+ (0), 1946-1979 (1), 1939-1945 (2)');");
				}
				DataTable dataTable = theMSAccessHelper.ExecuteDataTable("Select [Value] from ManagementMisc WHERE [Description] = 'DatabaseCategory';");
				IEnumerator enumerator = dataTable.Rows.GetEnumerator();
				try
				{
					if (enumerator.MoveNext())
					{
						object objectValue = RuntimeHelpers.GetObjectValue(enumerator.Current);
						result = (DatabaseCategory)Conversions.ToShort(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Value" }, (string[])null));
						return result;
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400141", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
			return result;
		}
	}

	public static string theSourceDBConnectionString
	{
		get
		{
			try
			{
				return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + theSourceMsAccessFileName + ";Persist Security Info=False";
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400142", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static string theTargetDBConnectionString
	{
		get
		{
			try
			{
				return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + theTargetMsAccessFileName + ";Persist Security Info=False";
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400143", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable Validation
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_0))
				{
					dataTable_0 = theMSAccessHelper.ExecuteDataTable("Select * from Validation");
				}
				return dataTable_0;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400147", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataWarhead
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_1))
				{
					dataTable_1 = theMSAccessHelper.ExecuteDataTable("Select * from DataWarhead");
					dataTable_1.PrimaryKey = new DataColumn[1] { dataTable_1.Columns["ID"] };
				}
				return dataTable_1;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400147", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataWeapon
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_2))
				{
					dataTable_2 = theMSAccessHelper.ExecuteDataTable("Select * from DataWeapon");
					dataTable_2.PrimaryKey = new DataColumn[1] { dataTable_2.Columns["ID"] };
				}
				return dataTable_2;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400148", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataSatellite
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_3))
				{
					dataTable_3 = theMSAccessHelper.ExecuteDataTable("Select * from DataSatellite");
					dataTable_3.PrimaryKey = new DataColumn[1] { dataTable_3.Columns["ID"] };
				}
				return dataTable_3;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400149", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataSatelliteSensors
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_4))
				{
					dataTable_4 = theMSAccessHelper.ExecuteDataTable("Select * from DataSatelliteSensors");
					dataTable_4.PrimaryKey = new DataColumn[2]
					{
						dataTable_4.Columns["ID"],
						dataTable_4.Columns["ComponentNumber"]
					};
				}
				return dataTable_4;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400150", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataSatelliteOrbits
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_5))
				{
					dataTable_5 = theMSAccessHelper.ExecuteDataTable("Select * from DataSatelliteOrbits");
					dataTable_5.PrimaryKey = new DataColumn[2]
					{
						dataTable_5.Columns["ID"],
						dataTable_5.Columns["ComponentNumber"]
					};
				}
				return dataTable_5;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400151", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataAircraft
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_6))
				{
					dataTable_6 = theMSAccessHelper.ExecuteDataTable("Select * from DataAircraft");
					dataTable_6.PrimaryKey = new DataColumn[1] { dataTable_6.Columns["ID"] };
				}
				return dataTable_6;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400152", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataAircraftFacility
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_7))
				{
					dataTable_7 = theMSAccessHelper.ExecuteDataTable("Select * from DataAircraftFacility");
					dataTable_7.PrimaryKey = new DataColumn[1] { dataTable_7.Columns["ID"] };
				}
				return dataTable_7;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400153", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataSensor
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_8))
				{
					dataTable_8 = theMSAccessHelper.ExecuteDataTable("Select * from DataSensor");
					dataTable_8.PrimaryKey = new DataColumn[1] { dataTable_8.Columns["ID"] };
				}
				return dataTable_8;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400154", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataSensorCapabilities
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_9))
				{
					dataTable_9 = theMSAccessHelper.ExecuteDataTable("Select * from DataSensorCapabilities");
					dataTable_9.PrimaryKey = new DataColumn[2]
					{
						dataTable_9.Columns["ID"],
						dataTable_9.Columns["CodeID"]
					};
				}
				return dataTable_9;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400155", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataSensorCodes
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_10))
				{
					dataTable_10 = theMSAccessHelper.ExecuteDataTable("Select * from DataSensorCodes");
					dataTable_10.PrimaryKey = new DataColumn[2]
					{
						dataTable_10.Columns["ID"],
						dataTable_10.Columns["CodeID"]
					};
				}
				return dataTable_10;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400156", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataSensorFrequencySearchAndTrack
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_11))
				{
					dataTable_11 = theMSAccessHelper.ExecuteDataTable("Select * from DataSensorFrequencySearchAndTrack");
					dataTable_11.PrimaryKey = new DataColumn[2]
					{
						dataTable_11.Columns["ID"],
						dataTable_11.Columns["Frequency"]
					};
				}
				return dataTable_11;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400157", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataSensorFrequencyIlluminate
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_12))
				{
					dataTable_12 = theMSAccessHelper.ExecuteDataTable("Select * from DataSensorFrequencyIlluminate");
					dataTable_12.PrimaryKey = new DataColumn[2]
					{
						dataTable_12.Columns["ID"],
						dataTable_12.Columns["Frequency"]
					};
				}
				return dataTable_12;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400158", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataSensorSensorGroups
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_13))
				{
					dataTable_13 = theMSAccessHelper.ExecuteDataTable("Select * from DataSensorSensorGroups");
					dataTable_13.PrimaryKey = new DataColumn[2]
					{
						dataTable_13.Columns["ID"],
						dataTable_13.Columns["ComponentNumber"]
					};
				}
				return dataTable_13;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400159", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataShip
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_14))
				{
					dataTable_14 = theMSAccessHelper.ExecuteDataTable("Select * from DataShip");
					dataTable_14.PrimaryKey = new DataColumn[1] { dataTable_14.Columns["ID"] };
				}
				return dataTable_14;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400160", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataShipAircraftFacilities
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_15))
				{
					dataTable_15 = theMSAccessHelper.ExecuteDataTable("Select * from DataShipAircraftFacilities");
					dataTable_15.PrimaryKey = new DataColumn[2]
					{
						dataTable_15.Columns["ID"],
						dataTable_15.Columns["ComponentNumber"]
					};
				}
				return dataTable_15;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400161", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataShipCodes
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_16))
				{
					dataTable_16 = theMSAccessHelper.ExecuteDataTable("Select * from DataShipCodes");
					dataTable_16.PrimaryKey = new DataColumn[2]
					{
						dataTable_16.Columns["ID"],
						dataTable_16.Columns["CodeID"]
					};
				}
				return dataTable_16;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400162", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataShipComms
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_17))
				{
					dataTable_17 = theMSAccessHelper.ExecuteDataTable("Select * from DataShipComms");
					dataTable_17.PrimaryKey = new DataColumn[2]
					{
						dataTable_17.Columns["ID"],
						dataTable_17.Columns["ComponentNumber"]
					};
				}
				return dataTable_17;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400163", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataShipFuel
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_18))
				{
					dataTable_18 = theMSAccessHelper.ExecuteDataTable("Select * from DataShipFuel");
					dataTable_18.PrimaryKey = new DataColumn[2]
					{
						dataTable_18.Columns["ID"],
						dataTable_18.Columns["ComponentNumber"]
					};
				}
				return dataTable_18;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400164", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataShipMounts
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_19))
				{
					dataTable_19 = theMSAccessHelper.ExecuteDataTable("Select * from DataShipMounts");
					dataTable_19.PrimaryKey = new DataColumn[2]
					{
						dataTable_19.Columns["ID"],
						dataTable_19.Columns["ComponentNumber"]
					};
				}
				return dataTable_19;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400165", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataShipMagazines
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_20))
				{
					dataTable_20 = theMSAccessHelper.ExecuteDataTable("Select * from DataShipMagazines");
					dataTable_20.PrimaryKey = new DataColumn[2]
					{
						dataTable_20.Columns["ID"],
						dataTable_20.Columns["ComponentNumber"]
					};
				}
				return dataTable_20;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400166", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataShipPropulsion
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_21))
				{
					dataTable_21 = theMSAccessHelper.ExecuteDataTable("Select * from DataShipPropulsion");
					dataTable_21.PrimaryKey = new DataColumn[2]
					{
						dataTable_21.Columns["ID"],
						dataTable_21.Columns["ComponentNumber"]
					};
				}
				return dataTable_21;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400167", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataShipSensors
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_22))
				{
					dataTable_22 = theMSAccessHelper.ExecuteDataTable("Select * from DataShipSensors");
					dataTable_22.PrimaryKey = new DataColumn[2]
					{
						dataTable_22.Columns["ID"],
						dataTable_22.Columns["ComponentNumber"]
					};
				}
				return dataTable_22;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400168", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataSubmarine
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_23))
				{
					dataTable_23 = theMSAccessHelper.ExecuteDataTable("Select * from DataSubmarine");
					dataTable_23.PrimaryKey = new DataColumn[1] { dataTable_23.Columns["ID"] };
				}
				return dataTable_23;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400169", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataSubmarineAircraftFacilities
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_24))
				{
					dataTable_24 = theMSAccessHelper.ExecuteDataTable("Select * from DataSubmarineAircraftFacilities");
					dataTable_24.PrimaryKey = new DataColumn[2]
					{
						dataTable_24.Columns["ID"],
						dataTable_24.Columns["ComponentNumber"]
					};
				}
				return dataTable_24;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400170", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataSubmarineComms
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_25))
				{
					dataTable_25 = theMSAccessHelper.ExecuteDataTable("Select * from DataSubmarineComms");
					dataTable_25.PrimaryKey = new DataColumn[2]
					{
						dataTable_25.Columns["ID"],
						dataTable_25.Columns["ComponentNumber"]
					};
				}
				return dataTable_25;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400171", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataSubmarineFuel
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_26))
				{
					dataTable_26 = theMSAccessHelper.ExecuteDataTable("Select * from DataSubmarineFuel");
					dataTable_26.PrimaryKey = new DataColumn[2]
					{
						dataTable_26.Columns["ID"],
						dataTable_26.Columns["ComponentNumber"]
					};
				}
				return dataTable_26;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400172", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataSubmarineMounts
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_27))
				{
					dataTable_27 = theMSAccessHelper.ExecuteDataTable("Select * from DataSubmarineMounts");
					dataTable_27.PrimaryKey = new DataColumn[2]
					{
						dataTable_27.Columns["ID"],
						dataTable_27.Columns["ComponentNumber"]
					};
				}
				return dataTable_27;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400173", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataSubmarinePropulsion
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_28))
				{
					dataTable_28 = theMSAccessHelper.ExecuteDataTable("Select * from DataSubmarinePropulsion");
					dataTable_28.PrimaryKey = new DataColumn[2]
					{
						dataTable_28.Columns["ID"],
						dataTable_28.Columns["ComponentNumber"]
					};
				}
				return dataTable_28;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400174", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataSubmarineSensors
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_29))
				{
					dataTable_29 = theMSAccessHelper.ExecuteDataTable("Select * from DataSubmarineSensors");
					dataTable_29.PrimaryKey = new DataColumn[2]
					{
						dataTable_29.Columns["ID"],
						dataTable_29.Columns["ComponentNumber"]
					};
				}
				return dataTable_29;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400175", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataAircraftSensors
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_30))
				{
					dataTable_30 = theMSAccessHelper.ExecuteDataTable("Select * from DataAircraftSensors");
					dataTable_30.PrimaryKey = new DataColumn[2]
					{
						dataTable_30.Columns["ID"],
						dataTable_30.Columns["ComponentNumber"]
					};
				}
				return dataTable_30;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400176", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataAircraftMounts
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_31))
				{
					dataTable_31 = theMSAccessHelper.ExecuteDataTable("Select * from DataAircraftMounts");
					dataTable_31.PrimaryKey = new DataColumn[2]
					{
						dataTable_31.Columns["ID"],
						dataTable_31.Columns["ComponentNumber"]
					};
				}
				return dataTable_31;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400177", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataAircraftPropulsion
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_32))
				{
					dataTable_32 = theMSAccessHelper.ExecuteDataTable("Select * from DataAircraftPropulsion");
					dataTable_32.PrimaryKey = new DataColumn[2]
					{
						dataTable_32.Columns["ID"],
						dataTable_32.Columns["ComponentNumber"]
					};
				}
				return dataTable_32;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400178", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataPropulsion
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_33))
				{
					dataTable_33 = theMSAccessHelper.ExecuteDataTable("Select * from DataPropulsion");
					dataTable_33.PrimaryKey = new DataColumn[1] { dataTable_33.Columns["ID"] };
				}
				return dataTable_33;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400179", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataPropulsionPerformance
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_34))
				{
					dataTable_34 = theMSAccessHelper.ExecuteDataTable("Select * from DataPropulsionPerformance");
					dataTable_34.PrimaryKey = new DataColumn[3]
					{
						dataTable_34.Columns["ID"],
						dataTable_34.Columns["AltitudeBand"],
						dataTable_34.Columns["Throttle"]
					};
				}
				return dataTable_34;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400180", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable EnumLoadoutMissionProfile
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_35))
				{
					dataTable_35 = theMSAccessHelper.ExecuteDataTable("Select * from EnumLoadoutMissionProfile");
					dataTable_35.PrimaryKey = new DataColumn[1] { dataTable_35.Columns["ID"] };
				}
				return dataTable_35;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400181", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable EnumOperatorCountry
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_36))
				{
					dataTable_36 = theMSAccessHelper.ExecuteDataTable("Select * from EnumOperatorCountry");
					dataTable_36.PrimaryKey = new DataColumn[1] { dataTable_36.Columns["ID"] };
				}
				return dataTable_36;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400181", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataComm
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_37))
				{
					dataTable_37 = theMSAccessHelper.ExecuteDataTable("Select * from DataComm");
					dataTable_37.PrimaryKey = new DataColumn[1] { dataTable_37.Columns["ID"] };
				}
				return dataTable_37;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400182", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataCommDirectors
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_38))
				{
					dataTable_38 = theMSAccessHelper.ExecuteDataTable("Select * from DataCommDirectors");
					dataTable_38.PrimaryKey = new DataColumn[2]
					{
						dataTable_38.Columns["ID"],
						dataTable_38.Columns["ComponentNumber"]
					};
				}
				return dataTable_38;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400182", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataFacility
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_39))
				{
					dataTable_39 = theMSAccessHelper.ExecuteDataTable("Select * from DataFacility");
					dataTable_39.PrimaryKey = new DataColumn[1] { dataTable_39.Columns["ID"] };
				}
				return dataTable_39;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400183", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataFacilityAircraftFacilities
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_40))
				{
					dataTable_40 = theMSAccessHelper.ExecuteDataTable("Select * from DataFacilityAircraftFacilities");
					dataTable_40.PrimaryKey = new DataColumn[2]
					{
						dataTable_40.Columns["ID"],
						dataTable_40.Columns["ComponentNumber"]
					};
				}
				return dataTable_40;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400184", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataFacilityComms
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_41))
				{
					dataTable_41 = theMSAccessHelper.ExecuteDataTable("Select * from DataFacilityComms");
					dataTable_41.PrimaryKey = new DataColumn[2]
					{
						dataTable_41.Columns["ID"],
						dataTable_41.Columns["ComponentNumber"]
					};
				}
				return dataTable_41;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400185", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataFacilityMounts
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)TeaFkxInht))
				{
					TeaFkxInht = theMSAccessHelper.ExecuteDataTable("Select * from DataFacilityMounts");
					TeaFkxInht.PrimaryKey = new DataColumn[2]
					{
						TeaFkxInht.Columns["ID"],
						TeaFkxInht.Columns["ComponentNumber"]
					};
				}
				return TeaFkxInht;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400186", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataFacilitySensors
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_42))
				{
					dataTable_42 = theMSAccessHelper.ExecuteDataTable("Select * from DataFacilitySensors");
					dataTable_42.PrimaryKey = new DataColumn[2]
					{
						dataTable_42.Columns["ID"],
						dataTable_42.Columns["ComponentNumber"]
					};
				}
				return dataTable_42;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400187", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataFuel
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_43))
				{
					dataTable_43 = theMSAccessHelper.ExecuteDataTable("Select * from DataFuel");
					dataTable_43.PrimaryKey = new DataColumn[1] { dataTable_43.Columns["ID"] };
				}
				return dataTable_43;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400188", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataMagazine
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_44))
				{
					dataTable_44 = theMSAccessHelper.ExecuteDataTable("Select * from DataMagazine");
					dataTable_44.PrimaryKey = new DataColumn[1] { dataTable_44.Columns["ID"] };
				}
				return dataTable_44;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400189", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataMagazineWeapons
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_45))
				{
					dataTable_45 = theMSAccessHelper.ExecuteDataTable("Select * from DataMagazineWeapons");
					dataTable_45.PrimaryKey = new DataColumn[2]
					{
						dataTable_45.Columns["ID"],
						dataTable_45.Columns["ComponentNumber"]
					};
				}
				return dataTable_45;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400190", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataMount
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_46))
				{
					dataTable_46 = theMSAccessHelper.ExecuteDataTable("Select * from DataMount");
					dataTable_46.PrimaryKey = new DataColumn[1] { dataTable_46.Columns["ID"] };
				}
				return dataTable_46;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400191", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataMountComms
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_47))
				{
					dataTable_47 = theMSAccessHelper.ExecuteDataTable("Select * from DataMountComms");
					dataTable_47.PrimaryKey = new DataColumn[2]
					{
						dataTable_47.Columns["ID"],
						dataTable_47.Columns["ComponentNumber"]
					};
				}
				return dataTable_47;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400192", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataMountDirectors
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_48))
				{
					dataTable_48 = theMSAccessHelper.ExecuteDataTable("Select * from DataMountDirectors");
					dataTable_48.PrimaryKey = new DataColumn[2]
					{
						dataTable_48.Columns["ID"],
						dataTable_48.Columns["ComponentNumber"]
					};
				}
				return dataTable_48;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400193", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataMountMagazineWeapons
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_49))
				{
					dataTable_49 = theMSAccessHelper.ExecuteDataTable("Select * from DataMountMagazineWeapons");
					dataTable_49.PrimaryKey = new DataColumn[2]
					{
						dataTable_49.Columns["ID"],
						dataTable_49.Columns["ComponentNumber"]
					};
				}
				return dataTable_49;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400194", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataMountSensors
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_50))
				{
					dataTable_50 = theMSAccessHelper.ExecuteDataTable("Select * from DataMountSensors");
					dataTable_50.PrimaryKey = new DataColumn[2]
					{
						dataTable_50.Columns["ID"],
						dataTable_50.Columns["ComponentNumber"]
					};
				}
				return dataTable_50;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400195", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataMountWeapons
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_51))
				{
					dataTable_51 = theMSAccessHelper.ExecuteDataTable("Select * from DataMountWeapons");
					dataTable_51.PrimaryKey = new DataColumn[2]
					{
						dataTable_51.Columns["ID"],
						dataTable_51.Columns["ComponentNumber"]
					};
				}
				return dataTable_51;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400196", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataWeaponFuel
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_52))
				{
					dataTable_52 = theMSAccessHelper.ExecuteDataTable("Select * from DataWeaponFuel");
					dataTable_52.PrimaryKey = new DataColumn[2]
					{
						dataTable_52.Columns["ID"],
						dataTable_52.Columns["ComponentNumber"]
					};
				}
				return dataTable_52;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400197", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataWeaponPropulsion
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_53))
				{
					dataTable_53 = theMSAccessHelper.ExecuteDataTable("Select * from DataWeaponPropulsion");
					dataTable_53.PrimaryKey = new DataColumn[2]
					{
						dataTable_53.Columns["ID"],
						dataTable_53.Columns["ComponentNumber"]
					};
				}
				return dataTable_53;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400198", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataWeaponRecord
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_54))
				{
					dataTable_54 = theMSAccessHelper.ExecuteDataTable("Select * from DataWeaponRecord");
					dataTable_54.PrimaryKey = new DataColumn[1] { dataTable_54.Columns["ID"] };
				}
				return dataTable_54;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400199", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable MiscAircraft
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_55))
				{
					dataTable_55 = theMSAccessHelper.ExecuteDataTable("Select * from MiscAircraft");
					dataTable_55.PrimaryKey = new DataColumn[1] { dataTable_55.Columns["ID"] };
				}
				return dataTable_55;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400200", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable MiscComm
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_56))
				{
					dataTable_56 = theMSAccessHelper.ExecuteDataTable("Select * from MiscComm");
					dataTable_56.PrimaryKey = new DataColumn[1] { dataTable_56.Columns["ID"] };
				}
				return dataTable_56;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400201", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable MiscFacility
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_57))
				{
					dataTable_57 = theMSAccessHelper.ExecuteDataTable("Select * from MiscFacility");
					dataTable_57.PrimaryKey = new DataColumn[1] { dataTable_57.Columns["ID"] };
				}
				return dataTable_57;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400202", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable MiscLoadout
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_58))
				{
					dataTable_58 = theMSAccessHelper.ExecuteDataTable("Select * from MiscLoadout");
					dataTable_58.PrimaryKey = new DataColumn[1] { dataTable_58.Columns["ID"] };
				}
				return dataTable_58;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400203", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable MiscMountDefault
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_59))
				{
					dataTable_59 = theMSAccessHelper.ExecuteDataTable("Select * from MiscMountDefault");
					dataTable_59.PrimaryKey = new DataColumn[2]
					{
						dataTable_59.Columns["ID"],
						dataTable_59.Columns["ComponentNumber"]
					};
				}
				return dataTable_59;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400204", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable MiscSensor
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_60))
				{
					dataTable_60 = theMSAccessHelper.ExecuteDataTable("Select * from MiscSensor");
					dataTable_60.PrimaryKey = new DataColumn[1] { dataTable_60.Columns["ID"] };
				}
				return dataTable_60;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400205", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable MiscShip
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_61))
				{
					dataTable_61 = theMSAccessHelper.ExecuteDataTable("Select * from MiscShip");
					dataTable_61.PrimaryKey = new DataColumn[1] { dataTable_61.Columns["ID"] };
				}
				return dataTable_61;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400206", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable MiscSubmarine
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_62))
				{
					dataTable_62 = theMSAccessHelper.ExecuteDataTable("Select * from MiscSubmarine");
					dataTable_62.PrimaryKey = new DataColumn[1] { dataTable_62.Columns["ID"] };
				}
				return dataTable_62;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400207", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable MiscSensorDefault
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_63))
				{
					dataTable_63 = theMSAccessHelper.ExecuteDataTable("Select * from MiscSensorDefault");
					dataTable_63.PrimaryKey = new DataColumn[2]
					{
						dataTable_63.Columns["ID"],
						dataTable_63.Columns["ComponentNumber"]
					};
				}
				return dataTable_63;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400208", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable MiscWeapon
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_64))
				{
					dataTable_64 = theMSAccessHelper.ExecuteDataTable("Select * from MiscWeapon");
					dataTable_64.PrimaryKey = new DataColumn[1] { dataTable_64.Columns["ID"] };
				}
				return dataTable_64;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400209", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable MiscWeaponRecord
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_65))
				{
					dataTable_65 = theMSAccessHelper.ExecuteDataTable("Select * from MiscWeaponRecord");
					dataTable_65.PrimaryKey = new DataColumn[1] { dataTable_65.Columns["ID"] };
				}
				return dataTable_65;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400210", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataWeaponCodes
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_66))
				{
					dataTable_66 = theMSAccessHelper.ExecuteDataTable("Select * from DataWeaponCodes");
					dataTable_66.PrimaryKey = new DataColumn[2]
					{
						dataTable_66.Columns["ID"],
						dataTable_66.Columns["CodeID"]
					};
				}
				return dataTable_66;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400211", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataWeaponWRA
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_67))
				{
					dataTable_67 = theMSAccessHelper.ExecuteDataTable("Select * from DataWeaponWRA");
					dataTable_67.PrimaryKey = new DataColumn[2]
					{
						dataTable_67.Columns["ID"],
						dataTable_67.Columns["CodeID"]
					};
				}
				return dataTable_67;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400212", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataWeaponComms
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_68))
				{
					dataTable_68 = theMSAccessHelper.ExecuteDataTable("Select * from DataWeaponComms");
					dataTable_68.PrimaryKey = new DataColumn[2]
					{
						dataTable_68.Columns["ID"],
						dataTable_68.Columns["ComponentNumber"]
					};
				}
				return dataTable_68;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400213", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataWeaponDirectors
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_69))
				{
					dataTable_69 = theMSAccessHelper.ExecuteDataTable("Select * from DataWeaponDirectors");
					dataTable_69.PrimaryKey = new DataColumn[2]
					{
						dataTable_69.Columns["ID"],
						dataTable_69.Columns["ComponentNumber"]
					};
				}
				return dataTable_69;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400214", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataWeaponSensors
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)EDHFKGLOXJ))
				{
					EDHFKGLOXJ = theMSAccessHelper.ExecuteDataTable("Select * from DataWeaponSensors");
					EDHFKGLOXJ.PrimaryKey = new DataColumn[2]
					{
						EDHFKGLOXJ.Columns["ID"],
						EDHFKGLOXJ.Columns["ComponentNumber"]
					};
				}
				return EDHFKGLOXJ;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400215", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataWeaponTargets
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_70))
				{
					dataTable_70 = theMSAccessHelper.ExecuteDataTable("Select * from DataWeaponTargets");
					dataTable_70.PrimaryKey = new DataColumn[2]
					{
						dataTable_70.Columns["ID"],
						dataTable_70.Columns["CodeID"]
					};
				}
				return dataTable_70;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400216", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataWeaponWarheads
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_71))
				{
					dataTable_71 = theMSAccessHelper.ExecuteDataTable("Select * from DataWeaponWarheads");
					dataTable_71.PrimaryKey = new DataColumn[2]
					{
						dataTable_71.Columns["ID"],
						dataTable_71.Columns["ComponentNumber"]
					};
				}
				return dataTable_71;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400217", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataAircraftCodes
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_72))
				{
					dataTable_72 = theMSAccessHelper.ExecuteDataTable("Select * from DataAircraftCodes");
					dataTable_72.PrimaryKey = new DataColumn[2]
					{
						dataTable_72.Columns["ID"],
						dataTable_72.Columns["CodeID"]
					};
				}
				return dataTable_72;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400218", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataAircraftComms
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_73))
				{
					dataTable_73 = theMSAccessHelper.ExecuteDataTable("Select * from DataAircraftComms");
					dataTable_73.PrimaryKey = new DataColumn[2]
					{
						dataTable_73.Columns["ID"],
						dataTable_73.Columns["ComponentNumber"]
					};
				}
				return dataTable_73;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400219", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataAircraftFuel
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_74))
				{
					dataTable_74 = theMSAccessHelper.ExecuteDataTable("Select * from DataAircraftFuel");
					dataTable_74.PrimaryKey = new DataColumn[2]
					{
						dataTable_74.Columns["ID"],
						dataTable_74.Columns["ComponentNumber"]
					};
				}
				return dataTable_74;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400220", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataAircraftLoadouts
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_75))
				{
					dataTable_75 = theMSAccessHelper.ExecuteDataTable("Select * from DataAircraftLoadouts");
					dataTable_75.PrimaryKey = new DataColumn[2]
					{
						dataTable_75.Columns["ID"],
						dataTable_75.Columns["ComponentID"]
					};
				}
				return dataTable_75;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400221", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataLoadout
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_76))
				{
					dataTable_76 = theMSAccessHelper.ExecuteDataTable("Select * from DataLoadout");
					dataTable_76.PrimaryKey = new DataColumn[1] { dataTable_76.Columns["ID"] };
				}
				return dataTable_76;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400222", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable Capabilities
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_77))
				{
					dataTable_77 = theMSAccessHelper.ExecuteDataTable("Select * from Capabilities");
					dataTable_77.PrimaryKey = new DataColumn[1] { dataTable_77.Columns["ID"] };
				}
				return dataTable_77;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400223", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable ManagementMisc
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_78))
				{
					dataTable_78 = theMSAccessHelper.ExecuteDataTable("Select * from Capabilities");
					dataTable_78.PrimaryKey = new DataColumn[1] { dataTable_78.Columns["ID"] };
				}
				return dataTable_77;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400224", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static DataTable DataLoadoutWeapons
	{
		get
		{
			try
			{
				if (Information.IsNothing((object)dataTable_79))
				{
					dataTable_79 = theMSAccessHelper.ExecuteDataTable("Select * from DataLoadoutWeapons");
					dataTable_79.PrimaryKey = new DataColumn[2]
					{
						dataTable_79.Columns["ID"],
						dataTable_79.Columns["ComponentNumber"]
					};
				}
				return dataTable_79;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Common 400225", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	static Common()
	{
		Class72.smethod_20();
		QueryValidateAircraftPropulsion = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) SELECT DataAircraftPropulsion.ID AS ComponentID, 'Aircraft' AS SourceAnnex, 'Primary propulsion type ' & [ValidationPropulsionType]![Description] & ' Is non-standard For planes.' AS ErrorText FROM ValidationPropulsionType INNER JOIN (DataAircraftPropulsion INNER JOIN DataPropulsion ON DataAircraftPropulsion.ComponentID = DataPropulsion.ID) ON ValidationPropulsionType.ID = DataPropulsion.Type WHERE (((DataAircraftPropulsion.ID) Not In (SELECT DataAircraft.ID FROM DataAircraft WHERE (((DataAircraft.Category)=1001 OR  (DataAircraft.Category)=2003 OR (DataAircraft.Category)=2004 OR (DataAircraft.Category)=2005));)) AND ((ValidationPropulsionType.Aircraft)=False));";
		QueryValidateFuelDuplicates = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) SELECT DataFuel.ID, 'Fuel' AS Dimpidung, 'Item #' & Format$([DataFuel_1]![ID],'0') & ' is an exact duplicate.' AS Expr2 FROM DataFuel INNER JOIN DataFuel AS DataFuel_1 ON DataFuel.Type = DataFuel_1.Type WHERE (((DataFuel_1.ID)>[DataFuel]![ID]) AND ((DataFuel.Capacity)=[DataFuel_1]![Capacity]));";
		QueryValidateMountStdArcs = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) SELECT MiscMountDefault.ID, 'Mount' AS Dimpidung, 'Default Mount Arcs have arcs with identical names' AS Expr2 FROM MiscMountDefault INNER JOIN MiscMountDefault AS MiscMountDefault_1 ON MiscMountDefault.ID = MiscMountDefault_1.ID WHERE (((MiscMountDefault_1.ComponentNumber)>[MiscMountDefault]![ComponentNumber]) AND ((MiscMountDefault.Comments)=[MiscMountDefault_1]![Comments] And (MiscMountDefault.Comments)<>\")) ORDER BY MiscMountDefault.ID;";
		QueryValidateShipPropulsion = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) SELECT DataShipPropulsion.ID, 'Ship' AS Dimpidung, 'Primary propulsion type ' & [ValidationPropulsionType]![Description] & ' is non-standard for ships.' AS [Text] FROM ValidationPropulsionType INNER JOIN (DataShipPropulsion INNER JOIN DataPropulsion ON DataShipPropulsion.ComponentID = DataPropulsion.ID) ON ValidationPropulsionType.ID = DataPropulsion.Type WHERE (((ValidationPropulsionType.Ship)=False));";
		QueryValidateWeaponPropulsion = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) SELECT DataWeapon.ID, 'Weapon' AS Dimpidung, 'Propulsion type ' & [ValidationPropulsionType]![Description] & ' is non-standard for weapons.' AS [Text] FROM DataWeapon INNER JOIN (ValidationPropulsionType INNER JOIN (DataWeaponPropulsion INNER JOIN DataPropulsion ON DataWeaponPropulsion.ComponentID = DataPropulsion.ID) ON ValidationPropulsionType.ID = DataPropulsion.Type) ON DataWeapon.ID = DataWeaponPropulsion.ID WHERE (((DataWeapon.Type)<>4001) AND ((ValidationPropulsionType.Weapon)=False)) OR ((DataWeapon.Type<>4001 AND DataWeapon.Type<>4007 AND DataWeapon.Type<>4008) AND ((DataPropulsion.Type)=5002));";
		QueryValidateHelicopterPropulsion = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) SELECT DataAircraftPropulsion.ID, 'Aircraft' AS Dimpidung, 'Primary propulsion type ' & [ValidationPropulsionType]![Description] & ' is non-standard for helicopters.' AS [Text] FROM ValidationPropulsionType INNER JOIN (DataAircraftPropulsion INNER JOIN DataPropulsion ON DataAircraftPropulsion.ComponentID = DataPropulsion.ID) ON ValidationPropulsionType.ID = DataPropulsion.Type WHERE (((DataAircraftPropulsion.ID) In (SELECT DataAircraft.ID FROM DataAircraft WHERE (((DataAircraft.Category)=2003 OR (DataAircraft.Category)=2004));)) AND ((ValidationPropulsionType.Helicopter)=False));";
		QueryValidateAircraftFacilityDuplicates = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) SELECT DataAircraftFacility.ID, 'Aircraft Fac' AS Dimpidung, 'Item #' & Format$([DataAircraftFacility_1]![ID],'0') & ' is an exact duplicate.' AS Expr2 FROM DataAircraftFacility INNER JOIN DataAircraftFacility AS DataAircraftFacility_1 ON DataAircraftFacility.Type = DataAircraftFacility_1.Type WHERE (((DataAircraftFacility_1.ID)>[DataAircraftFacility]![ID]) AND ((DataAircraftFacility.PhysicalSize)=[DataAircraftFacility_1]![PhysicalSize]) AND ((DataAircraftFacility.Capacity)=[DataAircraftFacility_1]![Capacity]) AND (([DataAircraftFacility].[RunwayLength])=[DataAircraftFacility_1]![RunwayLength]));";
		QueryValidateDockingFacilityDuplicates = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) SELECT DataDockingFacility.ID, 'Docking Fac' AS Dimpidung, 'Item #' & Format$([DataDockingFacility_1]![ID],'0') & ' is an exact duplicate.' AS Expr2 FROM DataDockingFacility INNER JOIN DataDockingFacility AS DataDockingFacility_1 ON DataDockingFacility.Type = DataDockingFacility_1.Type WHERE (((DataDockingFacility_1.ID)>[DataDockingFacility]![ID]) AND ((DataDockingFacility.PhysicalSize)=[DataDockingFacility_1]![PhysicalSize]) AND ((DataDockingFacility.Capacity)=[DataDockingFacility_1]![Capacity]));";
		QueryValidateSensorStdArcs = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) SELECT MiscSensorDefault.ID, 'Sensor' AS Dimpidung, 'Default Sensor Arcs have arcs with identical names' AS Expr2 FROM MiscSensorDefault INNER JOIN MiscSensorDefault AS MiscSensorDefault_1 ON MiscSensorDefault.ID = MiscSensorDefault_1.ID WHERE (((MiscSensorDefault_1.ComponentNumber)>[MiscSensorDefault]![ComponentNumber]) AND ((MiscSensorDefault.Comments)=[MiscSensorDefault_1]![Comments] And (MiscSensorDefault.Comments)<>'' And (MiscSensorDefault.Comments)<>'-')) ORDER BY MiscSensorDefault.ID;";
		QueryValidateSubmarinePropulsion = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) SELECT DataSubmarinePropulsion.ID, 'Submarine' AS Dimpidung, 'Primary propulsion type ' & [ValidationPropulsionType]![Description] & ' is non-standard for submarines.' AS [Text] FROM ValidationPropulsionType INNER JOIN (DataSubmarinePropulsion INNER JOIN DataPropulsion ON DataSubmarinePropulsion.ComponentID = DataPropulsion.ID) ON ValidationPropulsionType.ID = DataPropulsion.Type WHERE (((ValidationPropulsionType.Submarine)=False));";
		QueryValidateWarheadWeaponLink = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) SELECT DataWarhead.ID AS ComponentID, 'Warhead' AS SourceAnnex, 'Warhead with weapon does not refer to an existing weapon.' AS ErrorText FROM DataWarhead WHERE ((([DataWarhead].[Type])=5002) AND (([DataWarhead].[DamagePoints]) Not In (SELECT DISTINCT DataWeapon.ID FROM DataWeapon;)));";
		QueryValidateWarheadDP = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) SELECT DataWarhead.ID AS ComponentID, 'Warhead' AS SourceAnnex, 'Damage points value is invallid.' AS ErrorText FROM DataWarhead WHERE ( (DataWarhead.DamagePoints)<=0);";
		QueryValidateWeaponHasNoDirector = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) SELECT DataWeapon.ID AS ComponentID, 'Weapon' AS SourceAnnex, 'Weapon requires an illuminator.' AS ErrorText FROM DataWeapon WHERE ((([DataWeapon].[ID]) Not In (SELECT DataWeaponDirectors.ID FROM DataWeaponDirectors;) And ([DataWeapon].[ID]) In (SELECT DISTINCT DataWeaponCodes.ID FROM DataWeaponCodes WHERE (((DataWeaponCodes.CodeID)=1001 Or (DataWeaponCodes.CodeID)=1002));)));";
		QueryValidateWeaponRecordDuplicates = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) SELECT DataWeaponRecord.ID, 'Weapon Rec' AS Dimpidung, 'Item #' & Format$([DataWeaponRecord_1]![ID],'0') & ' is an exact duplicate.' AS Expr2 FROM DataWeaponRecord INNER JOIN DataWeaponRecord AS DataWeaponRecord_1 ON DataWeaponRecord.ComponentID = DataWeaponRecord_1.ComponentID WHERE (((DataWeaponRecord_1.ID)>[DataWeaponRecord]![ID]) AND ((DataWeaponRecord.DefaultLoad)=[DataWeaponRecord_1]![DefaultLoad]) AND ((DataWeaponRecord.MaxLoad)=[DataWeaponRecord_1]![MaxLoad]) AND ((DataWeaponRecord.ROF)=[DataWeaponRecord_1]![ROF]) AND ((DataWeaponRecord.Multiple)=[DataWeaponRecord_1]![Multiple]));";
	}

	public static bool DoesTableExist(ref Database theDatabase, string TableName)
	{
		foreach (TableDef tableDef in theDatabase.TableDefs)
		{
			if (Operators.CompareString(tableDef.Name, TableName, true) == 0)
			{
				return true;
			}
		}
		return false;
	}

	public static bool DoesTableColumnExist(ref Database theDatabase, string TableName, string ColumnName)
	{
		foreach (TableDef tableDef in theDatabase.TableDefs)
		{
			if (Operators.CompareString(tableDef.Name, TableName, true) != 0)
			{
				continue;
			}
			foreach (object field in tableDef.Fields)
			{
				if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(RuntimeHelpers.GetObjectValue(field), (Type)null, "name", new object[0], (string[])null, (Type[])null, (bool[])null), (object)ColumnName, true))
				{
					return true;
				}
			}
		}
		return false;
	}

	public static void RemoveAllNulls(ref Database theDatabase, MSAccessHelper theMSAccessHelper)
	{
		foreach (TableDef tableDef in theDatabase.TableDefs)
		{
			if (!tableDef.Name.Contains("Data") && !tableDef.Name.Contains("Misc") && !tableDef.Name.Contains("Text"))
			{
				continue;
			}
			foreach (object field in tableDef.Fields)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(field);
				if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(objectValue, (Type)null, "name", new object[0], (string[])null, (Type[])null, (bool[])null), (object)"3DMesh", true) || Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(objectValue, (Type)null, "name", new object[0], (string[])null, (Type[])null, (bool[])null), (object)"SymbolMesh", true))
				{
					continue;
				}
				if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(objectValue, (Type)null, "Type", new object[0], (string[])null, (Type[])null, (bool[])null), (object)10, true))
				{
					if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, (Type)null, "DefaultValue", new object[0], (string[])null, (Type[])null, (bool[])null))))
					{
						string text = Conversions.ToString(NewLateBinding.LateGet(objectValue, (Type)null, "DefaultValue", new object[0], (string[])null, (Type[])null, (bool[])null));
						if (!string.IsNullOrEmpty(text) && Operators.CompareString(text, "", true) != 0)
						{
							theMSAccessHelper.ExecuteDataTable(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE " + tableDef.Name + " SET " + tableDef.Name + "."), NewLateBinding.LateGet(objectValue, (Type)null, "Name", new object[0], (string[])null, (Type[])null, (bool[])null)), (object)" = '"), (object)text), (object)"' WHERE "), (object)tableDef.Name), (object)"."), NewLateBinding.LateGet(objectValue, (Type)null, "Name", new object[0], (string[])null, (Type[])null, (bool[])null)), (object)" IS NULL;")));
						}
						else
						{
							theMSAccessHelper.ExecuteDataTable(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE " + tableDef.Name + " SET " + tableDef.Name + "."), NewLateBinding.LateGet(objectValue, (Type)null, "Name", new object[0], (string[])null, (Type[])null, (bool[])null)), (object)" = '-' WHERE "), (object)tableDef.Name), (object)"."), NewLateBinding.LateGet(objectValue, (Type)null, "Name", new object[0], (string[])null, (Type[])null, (bool[])null)), (object)" IS NULL;")));
						}
					}
					else
					{
						theMSAccessHelper.ExecuteDataTable(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE " + tableDef.Name + " SET " + tableDef.Name + "."), NewLateBinding.LateGet(objectValue, (Type)null, "Name", new object[0], (string[])null, (Type[])null, (bool[])null)), (object)" = '-' WHERE "), (object)tableDef.Name), (object)"."), NewLateBinding.LateGet(objectValue, (Type)null, "Name", new object[0], (string[])null, (Type[])null, (bool[])null)), (object)" IS NULL;")));
					}
				}
				else if (Information.IsNothing(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, (Type)null, "DefaultValue", new object[0], (string[])null, (Type[])null, (bool[])null))))
				{
					theMSAccessHelper.ExecuteDataTable(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE " + tableDef.Name + " SET " + tableDef.Name + "."), NewLateBinding.LateGet(objectValue, (Type)null, "Name", new object[0], (string[])null, (Type[])null, (bool[])null)), (object)" = '0' WHERE "), (object)tableDef.Name), (object)"."), NewLateBinding.LateGet(objectValue, (Type)null, "Name", new object[0], (string[])null, (Type[])null, (bool[])null)), (object)" IS NULL;")));
				}
				else
				{
					string text2 = Conversions.ToString(NewLateBinding.LateGet(objectValue, (Type)null, "DefaultValue", new object[0], (string[])null, (Type[])null, (bool[])null));
					if (!string.IsNullOrEmpty(text2) && Operators.CompareString(text2, "", true) != 0)
					{
						theMSAccessHelper.ExecuteDataTable(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE " + tableDef.Name + " SET " + tableDef.Name + "."), NewLateBinding.LateGet(objectValue, (Type)null, "Name", new object[0], (string[])null, (Type[])null, (bool[])null)), (object)" = '"), (object)text2), (object)"' WHERE "), (object)tableDef.Name), (object)"."), NewLateBinding.LateGet(objectValue, (Type)null, "Name", new object[0], (string[])null, (Type[])null, (bool[])null)), (object)" IS NULL;")));
					}
					else
					{
						theMSAccessHelper.ExecuteDataTable(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE " + tableDef.Name + " SET " + tableDef.Name + "."), NewLateBinding.LateGet(objectValue, (Type)null, "Name", new object[0], (string[])null, (Type[])null, (bool[])null)), (object)" = '0' WHERE "), (object)tableDef.Name), (object)"."), NewLateBinding.LateGet(objectValue, (Type)null, "Name", new object[0], (string[])null, (Type[])null, (bool[])null)), (object)" IS NULL;")));
					}
				}
			}
		}
	}

	public static void ValidateMissingComponentInSubTable(MSAccessHelper theMSAccessHelper, string AnnexName, string TableName, string LookupTbl, string MsgFrag)
	{
		try
		{
			StatusString = "ValidateMissingComponentInSubTable(" + AnnexName + "," + TableName + "," + LookupTbl + "," + MsgFrag + ")";
			string string_ = "INSERT INTO Validation (ComponentID, SourceAnnex, ErrorText ) SELECT " + TableName + ".ID, " + Conversions.ToString(Convert.ToChar(34)) + AnnexName + Conversions.ToString(Convert.ToChar(34)) + " AS Dingdong, " + Conversions.ToString(Convert.ToChar(34)) + MsgFrag + " " + Conversions.ToString(Convert.ToChar(34)) + " & Format$(" + TableName + ".ComponentID) & " + Conversions.ToString(Convert.ToChar(34)) + " does not exist." + Conversions.ToString(Convert.ToChar(34)) + " AS Dongdingign FROM " + TableName + " WHERE (((" + TableName + ".ComponentID) Not In (SELECT " + LookupTbl + ".ID FROM " + LookupTbl + ";)));";
			theMSAccessHelper.ExecuteNonQuery(string_);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Common 400144", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateMissingComponent(MSAccessHelper theMSAccessHelper, string AnnexName, string TableName, string LookupTbl, string MsgFrag)
	{
		try
		{
			StatusString = "ValidateMissingComponent(" + AnnexName + "," + TableName + "," + LookupTbl + "," + MsgFrag + ")";
			string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) SELECT DISTINCTROW " + TableName + ".ID, " + Conversions.ToString(Convert.ToChar(34)) + AnnexName + Conversions.ToString(Convert.ToChar(34)) + " AS Dingdong, " + Conversions.ToString(Convert.ToChar(34)) + "Item has no " + MsgFrag + "." + Conversions.ToString(Convert.ToChar(34)) + "AS Dongdingign FROM " + TableName + " WHERE (((" + TableName + ".ID) Not In (SELECT " + LookupTbl + ".ID FROM " + LookupTbl + ";)));";
			theMSAccessHelper.ExecuteNonQuery(string_);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Common 400145", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static bool DeleteTableContent(MSAccessHelper theMSAccessHelper, string TableName)
	{
		bool result;
		try
		{
			theMSAccessHelper.ExecuteNonQuery("DELETE * FROM " + TableName + ";");
			result = true;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static void PreCacheDataTables(MSAccessHelper theMSAccessHelper)
	{
		try
		{
			DataValidateAircraft.Cache_SensorCapabilities = new ConcurrentDictionary<int, DataRow[]>();
			DataValidateWeapon.Cache_CommsPerWeapon = new ConcurrentDictionary<int, DataRow[]>();
			DataValidateWeapon.Cache_WarheadsPerWeapon = new ConcurrentDictionary<int, DataRow[]>();
			DataValidateWeapon.Cache_CodesPerWeapon = new ConcurrentDictionary<int, DataRow[]>();
			DataValidateWeapon.Cache_TargetsPerWeapon = new ConcurrentDictionary<int, DataRow[]>();
			DataValidateWeapon.Cache_SensorsPerWeapon = new ConcurrentDictionary<int, DataRow[]>();
			dataTable_6 = null;
			dataTable_72 = null;
			dataTable_73 = null;
			dataTable_7 = null;
			dataTable_74 = null;
			dataTable_75 = null;
			dataTable_31 = null;
			dataTable_32 = null;
			dataTable_30 = null;
			dataTable_37 = null;
			dataTable_38 = null;
			dataTable_39 = null;
			TeaFkxInht = null;
			dataTable_42 = null;
			dataTable_43 = null;
			dataTable_76 = null;
			dataTable_79 = null;
			dataTable_44 = null;
			dataTable_45 = null;
			dataTable_46 = null;
			dataTable_47 = null;
			dataTable_48 = null;
			dataTable_49 = null;
			dataTable_50 = null;
			dataTable_51 = null;
			dataTable_33 = null;
			dataTable_34 = null;
			dataTable_3 = null;
			dataTable_5 = null;
			dataTable_4 = null;
			dataTable_8 = null;
			dataTable_9 = null;
			dataTable_10 = null;
			dataTable_12 = null;
			dataTable_11 = null;
			dataTable_13 = null;
			dataTable_14 = null;
			dataTable_15 = null;
			dataTable_16 = null;
			dataTable_17 = null;
			dataTable_18 = null;
			dataTable_20 = null;
			dataTable_19 = null;
			dataTable_21 = null;
			dataTable_22 = null;
			dataTable_23 = null;
			dataTable_25 = null;
			dataTable_26 = null;
			dataTable_27 = null;
			dataTable_28 = null;
			dataTable_29 = null;
			dataTable_1 = null;
			dataTable_2 = null;
			dataTable_66 = null;
			dataTable_68 = null;
			dataTable_69 = null;
			dataTable_52 = null;
			dataTable_54 = null;
			EDHFKGLOXJ = null;
			dataTable_70 = null;
			dataTable_71 = null;
			dataTable_35 = null;
			dataTable_36 = null;
			dataTable_55 = null;
			dataTable_56 = null;
			dataTable_57 = null;
			dataTable_58 = null;
			dataTable_59 = null;
			dataTable_60 = null;
			dataTable_63 = null;
			dataTable_61 = null;
			dataTable_62 = null;
			dataTable_64 = null;
			dataTable_65 = null;
			Common.get_DataAircraft(theMSAccessHelper);
			Common.get_DataAircraftCodes(theMSAccessHelper);
			Common.get_DataAircraftComms(theMSAccessHelper);
			Common.get_DataAircraftFacility(theMSAccessHelper);
			Common.get_DataAircraftFuel(theMSAccessHelper);
			Common.get_DataAircraftLoadouts(theMSAccessHelper);
			Common.get_DataAircraftMounts(theMSAccessHelper);
			Common.get_DataAircraftPropulsion(theMSAccessHelper);
			Common.get_DataAircraftSensors(theMSAccessHelper);
			Common.get_DataComm(theMSAccessHelper);
			Common.get_DataCommDirectors(theMSAccessHelper);
			Common.get_DataFacility(theMSAccessHelper);
			Common.get_DataFacilityMounts(theMSAccessHelper);
			Common.get_DataFacilitySensors(theMSAccessHelper);
			Common.get_DataFuel(theMSAccessHelper);
			Common.get_DataLoadout(theMSAccessHelper);
			Common.get_DataLoadoutWeapons(theMSAccessHelper);
			Common.get_DataMagazine(theMSAccessHelper);
			Common.get_DataMagazineWeapons(theMSAccessHelper);
			Common.get_DataMount(theMSAccessHelper);
			Common.get_DataMountComms(theMSAccessHelper);
			Common.get_DataMountDirectors(theMSAccessHelper);
			Common.get_DataMountMagazineWeapons(theMSAccessHelper);
			Common.get_DataMountSensors(theMSAccessHelper);
			Common.get_DataMountWeapons(theMSAccessHelper);
			Common.get_DataPropulsion(theMSAccessHelper);
			Common.get_DataPropulsionPerformance(theMSAccessHelper);
			Common.get_DataSatellite(theMSAccessHelper);
			Common.get_DataSatelliteOrbits(theMSAccessHelper);
			Common.get_DataSatelliteSensors(theMSAccessHelper);
			Common.get_DataSensor(theMSAccessHelper);
			Common.get_DataSensorCapabilities(theMSAccessHelper);
			Common.get_DataSensorCodes(theMSAccessHelper);
			Common.get_DataSensorFrequencyIlluminate(theMSAccessHelper);
			Common.get_DataSensorFrequencySearchAndTrack(theMSAccessHelper);
			Common.get_DataSensorSensorGroups(theMSAccessHelper);
			Common.get_DataShip(theMSAccessHelper);
			Common.get_DataShipAircraftFacilities(theMSAccessHelper);
			Common.get_DataShipCodes(theMSAccessHelper);
			Common.get_DataShipComms(theMSAccessHelper);
			Common.get_DataShipFuel(theMSAccessHelper);
			Common.get_DataShipMagazines(theMSAccessHelper);
			Common.get_DataShipMounts(theMSAccessHelper);
			Common.get_DataShipPropulsion(theMSAccessHelper);
			Common.get_DataShipSensors(theMSAccessHelper);
			Common.get_DataSubmarine(theMSAccessHelper);
			Common.get_DataSubmarineComms(theMSAccessHelper);
			Common.get_DataSubmarineFuel(theMSAccessHelper);
			Common.get_DataSubmarineMounts(theMSAccessHelper);
			Common.get_DataSubmarinePropulsion(theMSAccessHelper);
			Common.get_DataSubmarineSensors(theMSAccessHelper);
			Common.get_DataWarhead(theMSAccessHelper);
			Common.get_DataWeapon(theMSAccessHelper);
			Common.get_DataWeaponCodes(theMSAccessHelper);
			Common.get_DataWeaponComms(theMSAccessHelper);
			Common.get_DataWeaponDirectors(theMSAccessHelper);
			Common.get_DataWeaponFuel(theMSAccessHelper);
			Common.get_DataWeaponRecord(theMSAccessHelper);
			Common.get_DataWeaponSensors(theMSAccessHelper);
			Common.get_DataWeaponTargets(theMSAccessHelper);
			Common.get_DataWeaponWarheads(theMSAccessHelper);
			Common.get_EnumLoadoutMissionProfile(theMSAccessHelper);
			Common.get_EnumOperatorCountry(theMSAccessHelper);
			Common.get_MiscAircraft(theMSAccessHelper);
			Common.get_MiscComm(theMSAccessHelper);
			Common.get_MiscFacility(theMSAccessHelper);
			Common.get_MiscLoadout(theMSAccessHelper);
			Common.get_MiscMountDefault(theMSAccessHelper);
			Common.get_MiscSensor(theMSAccessHelper);
			Common.get_MiscSensorDefault(theMSAccessHelper);
			Common.get_MiscShip(theMSAccessHelper);
			Common.get_MiscSubmarine(theMSAccessHelper);
			Common.get_MiscWeapon(theMSAccessHelper);
			Common.get_MiscWeaponRecord(theMSAccessHelper);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Common 400146", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}
}
