using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Command_Core.DAL;
using Command_Core.LoadSave;
using DarkUI.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class SBR
{
	[CompilerGenerated]
	internal sealed class _Closure$__15-0
	{
		public Cargo $VB$Local_theCargo;

		public _Closure$__15-0(_Closure$__15-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theCargo = arg0.$VB$Local_theCargo;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(Cargo CARGO)
		{
			return Operators.CompareString(CARGO.ObjectID, $VB$Local_theCargo.ObjectID, false) == 0;
		}

		static _Closure$__15-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__22-0
	{
		public Cargo $VB$Local_theCargo;

		public _Closure$__22-0(_Closure$__22-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theCargo = arg0.$VB$Local_theCargo;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(Cargo CARGO)
		{
			return Operators.CompareString(CARGO.ObjectID, $VB$Local_theCargo.ObjectID, false) == 0;
		}

		static _Closure$__22-0()
		{
			Class72.smethod_20();
		}
	}

	public static bool InProgress;

	static SBR()
	{
		Class72.smethod_20();
		InProgress = false;
	}

	public static void GenerateTemplate(Scenario theScen, Stream theStream, ref bool Success)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Expected O, but got Unknown
		Success = true;
		XmlWriterSettings val = new XmlWriterSettings();
		val.Indent = true;
		val.IndentChars = "    ";
		try
		{
			XmlWriter val2 = XmlWriter.Create(theStream, val);
			try
			{
				val2.WriteStartElement("ScenarioUnits");
				foreach (ActiveUnit value in theScen.ActiveUnits.Values)
				{
					val2.WriteStartElement("Unit_" + value.ObjectID);
					val2.WriteComment(value.Name + " (" + value.UnitClass + " [" + Conversions.ToString(value.DBID) + "])");
					val2.WriteEndElement();
				}
				val2.WriteEndElement();
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101113", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Success = false;
			ProjectData.ClearProjectError();
		}
	}

	public static void CloneHostedAircraftToUnit(ActiveUnit Source, ref ActiveUnit Destination)
	{
		AirFacility[] airFacilities_ReadOnly = Source.AirFacilities_ReadOnly;
		foreach (AirFacility airFacility in airFacilities_ReadOnly)
		{
			foreach (Aircraft value in airFacility.HostedAircraft.Values)
			{
				ActiveUnit activeUnit = CloneModifiedUnit(value, value.get_Latitude((GlobalVariables.BooleanObject)null), value.get_Longitude((GlobalVariables.BooleanObject)null));
				if (activeUnit != null)
				{
					Destination.AirOps.AddThisAircraft((Aircraft)activeUnit, GameIsRunning: true);
				}
			}
		}
	}

	public static void CloneHostedBoatToUnit(ActiveUnit Source, ref ActiveUnit Destination)
	{
		DockFacility[] dockFacilities_ReadOnly = Source.DockFacilities_ReadOnly;
		foreach (DockFacility dockFacility in dockFacilities_ReadOnly)
		{
			foreach (ActiveUnit value in dockFacility.GetHostedBoats().Values)
			{
				ActiveUnit theBoat = CloneModifiedUnit(value, value.get_Latitude((GlobalVariables.BooleanObject)null), value.get_Longitude((GlobalVariables.BooleanObject)null));
				Destination.DockingOps.AddThisBoat(theBoat);
			}
		}
	}

	public static ActiveUnit CloneModifiedUnit(ActiveUnit OriginalUnit, double destLat, double destLon)
	{
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Expected O, but got Unknown
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Expected O, but got Unknown
		ActiveUnit result;
		try
		{
			ActiveUnit Destination = default(ActiveUnit);
			try
			{
				switch (OriginalUnit.UnitType)
				{
				case GlobalVariables.ActiveUnitType.Aircraft:
					Destination = ((((Aircraft)OriginalUnit).Loadout == null) ? OriginalUnit.ParentScen.AddNewAircraft(OriginalUnit.get_UnitSide(SetSideOnly: false), OriginalUnit.Name, destLon, destLat, OriginalUnit.DBID, 0, OriginalUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) : OriginalUnit.ParentScen.AddNewAircraft(OriginalUnit.get_UnitSide(SetSideOnly: false), OriginalUnit.Name, destLon, destLat, OriginalUnit.DBID, ((Aircraft)OriginalUnit).Loadout.DBID, OriginalUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)));
					break;
				case GlobalVariables.ActiveUnitType.Ship:
					Destination = OriginalUnit.ParentScen.AddNewShip(OriginalUnit.get_UnitSide(SetSideOnly: false), OriginalUnit.DBID, OriginalUnit.Name, destLon, destLat);
					CloneHostedAircraftToUnit(OriginalUnit, ref Destination);
					CloneHostedBoatToUnit(OriginalUnit, ref Destination);
					break;
				case GlobalVariables.ActiveUnitType.Submarine:
					Destination = OriginalUnit.ParentScen.AddNewSubmarine(OriginalUnit.get_UnitSide(SetSideOnly: false), OriginalUnit.DBID, OriginalUnit.Name, destLon, destLat);
					CloneHostedBoatToUnit(OriginalUnit, ref Destination);
					break;
				case GlobalVariables.ActiveUnitType.Facility:
					Destination = OriginalUnit.ParentScen.AddNewFacility(OriginalUnit.get_UnitSide(SetSideOnly: false), OriginalUnit.DBID, OriginalUnit.Name, destLon, destLat);
					CloneHostedAircraftToUnit(OriginalUnit, ref Destination);
					break;
				case GlobalVariables.ActiveUnitType.Weapon:
					Destination = OriginalUnit.ParentScen.AddNewWeapon(OriginalUnit.get_UnitSide(SetSideOnly: false), OriginalUnit.Name + " - CLONE", destLon, destLat, OriginalUnit.DBID, OriginalUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
					Destination.CurrentHeading = OriginalUnit.CurrentHeading;
					Destination.Attitude_Pitch = OriginalUnit.Attitude_Pitch;
					result = Destination;
					goto end_IL_0001;
				case GlobalVariables.ActiveUnitType.Vehicle:
					Destination = OriginalUnit.ParentScen.AddNewVehicle(OriginalUnit.get_UnitSide(SetSideOnly: false), OriginalUnit.DBID, OriginalUnit.Name, destLon, destLat);
					CloneHostedAircraftToUnit(OriginalUnit, ref Destination);
					break;
				case GlobalVariables.ActiveUnitType.AggregateGroundUnit:
				{
					AggregateGroundUnit theUnit = ((AggregateGroundUnit)OriginalUnit).Clone();
					OriginalUnit.ParentScen.AddAggregateUnit(theUnit, OriginalUnit.get_UnitSide(SetSideOnly: false), destLon, destLat);
					break;
				}
				case GlobalVariables.ActiveUnitType.Aimpoint:
				case GlobalVariables.ActiveUnitType.Satellite:
				case GlobalVariables.ActiveUnitType.Personnel:
					break;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				GameGeneral.SendMessageBoxToUI("Error: " + ex2.Message, OriginalUnit.get_UnitSide(SetSideOnly: false));
				ProjectData.ClearProjectError();
			}
			XmlWriterSettings val = new XmlWriterSettings();
			val.Indent = true;
			val.IndentChars = "    ";
			val.ConformanceLevel = (ConformanceLevel)0;
			MemoryStream stream = RCMS.recyclableMemoryStreamManager_0.GetStream();
			XmlDocument val2 = new XmlDocument();
			using (stream)
			{
				XmlWriter val3 = XmlWriter.Create((Stream)stream, val);
				val3.WriteStartElement("ScenarioUnits");
				StreamWriter logFileWriter = default(StreamWriter);
				int ErrorCount = default(int);
				GenerateDeltaFragmentForThisUnit(OriginalUnit, OriginalUnit.ParentScen, val3, logFileWriter, ref ErrorCount);
				val3.WriteEndElement();
				val3.Flush();
				if (stream.Length > 60L)
				{
					val3.Flush();
					stream.Seek(0L, SeekOrigin.Begin);
					val2.Load((Stream)stream);
					RenameNode(((XmlNode)val2).SelectSingleNode("/ScenarioUnits").ChildNodes[0], "", "Unit_" + Destination.ObjectID);
					goto end_IL_0270;
				}
				result = Destination;
				goto end_IL_0001;
				end_IL_0270:;
			}
			stream = RCMS.recyclableMemoryStreamManager_0.GetStream();
			using (stream)
			{
				val2.Save((Stream)stream);
				stream.Seek(0L, SeekOrigin.Begin);
				ApplyScriptToScenario(OriginalUnit.ParentScen, null, IsUnitCloningOperation: true, stream);
			}
			switch (OriginalUnit.UnitType)
			{
			case GlobalVariables.ActiveUnitType.Submarine:
				foreach (ActiveUnit assignedBoat in Destination.DockingOps.AssignedBoats)
				{
					if (assignedBoat.DockingOps.HostDockFacility == null)
					{
						Destination.DockingOps.AddThisBoat(assignedBoat);
					}
				}
				break;
			}
			Destination.CurrentHeading = OriginalUnit.CurrentHeading;
			Destination.Attitude_Pitch = OriginalUnit.Attitude_Pitch;
			result = Destination;
			end_IL_0001:;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static XmlNode RenameNode(XmlNode node, string namespaceURI, string qualifiedName)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		if ((int)node.NodeType == 1)
		{
			XmlElement val = (XmlElement)node;
			XmlElement val2 = node.OwnerDocument.CreateElement(qualifiedName, namespaceURI);
			while (val.HasAttributes)
			{
				val2.SetAttributeNode(val.RemoveAttributeNode(val.Attributes[0]));
			}
			while (((XmlNode)val).HasChildNodes)
			{
				((XmlNode)val2).AppendChild(((XmlNode)val).FirstChild);
			}
			if (val.ParentNode != null)
			{
				val.ParentNode.ReplaceChild((XmlNode)(object)val2, (XmlNode)(object)val);
			}
			return (XmlNode)(object)val2;
		}
		return null;
	}

	public static void GenerateDeltaTemplate(Scenario theScen, Stream theStream, string IniFilename, ActiveUnit SpecificUnitToClone)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Invalid comparison between Unknown and I4
		XmlWriterSettings val = new XmlWriterSettings();
		val.Indent = true;
		val.IndentChars = "    ";
		try
		{
			string text = "Scenario: " + theScen.Title + "\r\nScenario file: " + GameGeneral.TopLevelWritablePath + Conversions.ToString(Path.DirectorySeparatorChar) + "Scenarios" + Conversions.ToString(Path.DirectorySeparatorChar) + theScen.FileName + ".scen\r\nConfig file:   " + IniFilename;
			StreamWriter streamWriter = File.AppendText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR INI template log file.txt");
			streamWriter.Write("\r\n\r\n" + text);
			streamWriter.Close();
			int ErrorCount = 0;
			XmlWriter val2 = XmlWriter.Create(theStream, val);
			try
			{
				val2.WriteStartElement("ScenarioUnits");
				if (Information.IsNothing((object)SpecificUnitToClone))
				{
					foreach (ActiveUnit value in theScen.ActiveUnits.Values)
					{
						GenerateDeltaFragmentForThisUnit(value, theScen, val2, streamWriter, ref ErrorCount);
						if ((int)val2.WriteState == 6)
						{
							if (ErrorCount == 0)
							{
								ErrorCount = -1;
							}
							break;
						}
					}
				}
				else
				{
					GenerateDeltaFragmentForThisUnit(SpecificUnitToClone, theScen, val2, streamWriter, ref ErrorCount);
				}
				val2.WriteEndElement();
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
			if (Information.IsNothing((object)SpecificUnitToClone))
			{
				if (ErrorCount == 0)
				{
					GameGeneral.SendMessageBoxToUI("INI template completed, no errors detected.", null);
				}
				else
				{
					GameGeneral.SendMessageBoxToUI("INI template completed with errors.\r\n\r\nNUMBER OF ERRORS FOUND: " + Conversions.ToString(ErrorCount) + "\r\n\r\n Please check '" + GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR INI template log file.txt' for details.", null);
				}
			}
			text = "Export Completed";
			streamWriter = File.AppendText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR INI template log file.txt");
			streamWriter.Write("\r\n" + text);
			streamWriter.Close();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101114", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			GameGeneral.SendMessageBoxToUI("INI delta template failed.\r\n\r\n Please check Exception Log for details.", null);
			ProjectData.ClearProjectError();
		}
	}

	public static void GenerateDeltaFragmentForThisUnit(ActiveUnit theAU, Scenario theScen, XmlWriter DeltaWriter, StreamWriter LogFileWriter, ref int ErrorCount, bool IsUnitCloningOperation = false)
	{
		try
		{
			SQLiteHelper sQLiteHelper = new SQLiteHelper(theScen.DBConnection);
			string text = "";
			string text2 = "";
			DataTable dataTable = null;
			ActiveUnit activeUnit = null;
			int num;
			string string_ = default(string);
			string string_2 = default(string);
			string text3 = default(string);
			string string_4 = default(string);
			string string_3 = default(string);
			switch (theAU.UnitType)
			{
			default:
				num = 0;
				break;
			case GlobalVariables.ActiveUnitType.Aircraft:
				string_ = "select ComponentID, Name, SB1, SB2, SMF1, SMF2, SMA1, SMA2, SS1, SS2, PB1, PB2, PMF1, PMF2, PMA1, PMA2, PS1, PS2 from DataAircraftMounts as dsm, DataMount as dm  where (dsm.ID = " + Conversions.ToString(theAU.DBID) + " and  dsm.ComponentID = dm.ID) ORDER BY dm.Name ASC";
				string_2 = "select ComponentID, Name, Type, SB1, SB2, SMF1, SMF2, SMA1, SMA2, SS1, SS2, PB1, PB2, PMF1, PMF2, PMA1, PMA2, PS1, PS2, SB1Max, SB2Max, SMF1Max, SMF2Max, SMA1Max, SMA2Max, SS1Max, SS2Max, PB1Max, PB2Max, PMF1Max, PMF2Max, PMA1Max, PMA2Max, PS1Max, PS2Max from DataAircraftSensors as dsm, DataSensor as dm where (dsm.ID = " + Conversions.ToString(theAU.DBID) + " and dsm.ComponentID = dm.ID) and Type <> 9001 and (Type < 6000 or Type > 6999) ORDER BY dm.Type, dm.Name ASC";
				text3 = "select ComponentID, Name, Type, SB1, SB2, SMF1, SMF2, SMA1, SMA2, SS1, SS2, PB1, PB2, PMF1, PMF2, PMA1, PMA2, PS1, PS2, SB1Max, SB2Max, SMF1Max, SMF2Max, SMA1Max, SMA2Max, SS1Max, SS2Max, PB1Max, PB2Max, PMF1Max, PMF2Max, PMA1Max, PMA2Max, PS1Max, PS2Max from DataAircraftSensors as dsm, DataSensor as dm where (dsm.ID = " + Conversions.ToString(theAU.DBID) + " and dsm.ComponentID = dm.ID) and Type <> 9001 and (Type > 6000 and Type < 7000) ORDER BY dm.Type, dm.Name ASC";
				string_4 = "select ComponentID, Name from DataAircraftComms as dsm, DataComm as dm  where (dsm.ID = " + Conversions.ToString(theAU.DBID) + " and  dsm.ComponentID = dm.ID)";
				activeUnit = new Aircraft(ref theScen);
				num = 0;
				break;
			case GlobalVariables.ActiveUnitType.Ship:
				string_ = "select ComponentID, Name, SB1, SB2, SMF1, SMF2, SMA1, SMA2, SS1, SS2, PB1, PB2, PMF1, PMF2, PMA1, PMA2, PS1, PS2 from DataShipMounts as dsm, DataMount as dm  where (dsm.ID = " + Conversions.ToString(theAU.DBID) + " and  dsm.ComponentID = dm.ID) ORDER BY dm.Name ASC";
				string_3 = "select ComponentID, Name from DataShipMagazines as dsmag, DataMagazine as dmag  where (dsmag.ID = " + Conversions.ToString(theAU.DBID) + " and  dsmag.ComponentID = dmag.ID) ORDER BY dmag.Name ASC";
				string_2 = "select ComponentID, Name, Type, SB1, SB2, SMF1, SMF2, SMA1, SMA2, SS1, SS2, PB1, PB2, PMF1, PMF2, PMA1, PMA2, PS1, PS2, SB1Max, SB2Max, SMF1Max, SMF2Max, SMA1Max, SMA2Max, SS1Max, SS2Max, PB1Max, PB2Max, PMF1Max, PMF2Max, PMA1Max, PMA2Max, PS1Max, PS2Max from DataShipSensors as dsm, DataSensor as dm where (dsm.ID = " + Conversions.ToString(theAU.DBID) + " and dsm.ComponentID = dm.ID) and (Type < 6000 or Type > 6999) ORDER BY dm.Type, dm.Name ASC";
				text3 = "select ComponentID, Name, Type, SB1, SB2, SMF1, SMF2, SMA1, SMA2, SS1, SS2, PB1, PB2, PMF1, PMF2, PMA1, PMA2, PS1, PS2, SB1Max, SB2Max, SMF1Max, SMF2Max, SMA1Max, SMA2Max, SS1Max, SS2Max, PB1Max, PB2Max, PMF1Max, PMF2Max, PMA1Max, PMA2Max, PS1Max, PS2Max from DataShipSensors as dsm, DataSensor as dm where (dsm.ID = " + Conversions.ToString(theAU.DBID) + " and dsm.ComponentID = dm.ID) and Type <> 9001 and (Type > 6000 and Type < 7000) ORDER BY dm.Type, dm.Name ASC";
				string_4 = "select ComponentID, Name from DataShipComms as dsm, DataComm as dm  where (dsm.ID = " + Conversions.ToString(theAU.DBID) + " and  dsm.ComponentID = dm.ID)";
				text2 = "select * from DataShipDockingFacilities where id = " + Conversions.ToString(theAU.DBID);
				text = "select * from DataShipAircraftFacilities where id = " + Conversions.ToString(theAU.DBID);
				activeUnit = new Ship(ref theScen);
				num = 0;
				break;
			case GlobalVariables.ActiveUnitType.Submarine:
				string_ = "select ComponentID, Name, SB1, SB2, SMF1, SMF2, SMA1, SMA2, SS1, SS2, PB1, PB2, PMF1, PMF2, PMA1, PMA2, PS1, PS2 from DataSubmarineMounts as dsm, DataMount as dm  where (dsm.ID = " + Conversions.ToString(theAU.DBID) + " and  dsm.ComponentID = dm.ID) ORDER BY dm.Name ASC";
				string_3 = "select ComponentID, Name from DataSubmarineMagazines as dsmag, DataMagazine as dmag  where (dsmag.ID = " + Conversions.ToString(theAU.DBID) + " and  dsmag.ComponentID = dmag.ID) ORDER BY dmag.Name ASC";
				string_2 = "select ComponentID, Name, Type, SB1, SB2, SMF1, SMF2, SMA1, SMA2, SS1, SS2, PB1, PB2, PMF1, PMF2, PMA1, PMA2, PS1, PS2, SB1Max, SB2Max, SMF1Max, SMF2Max, SMA1Max, SMA2Max, SS1Max, SS2Max, PB1Max, PB2Max, PMF1Max, PMF2Max, PMA1Max, PMA2Max, PS1Max, PS2Max from DataSubmarineSensors as dsm, DataSensor as dm where (dsm.ID = " + Conversions.ToString(theAU.DBID) + " and dsm.ComponentID = dm.ID) and Type <> 9001 and (Type < 6000 or Type > 6999) ORDER BY dm.Type, dm.Name ASC";
				text3 = "select ComponentID, Name, Type, SB1, SB2, SMF1, SMF2, SMA1, SMA2, SS1, SS2, PB1, PB2, PMF1, PMF2, PMA1, PMA2, PS1, PS2, SB1Max, SB2Max, SMF1Max, SMF2Max, SMA1Max, SMA2Max, SS1Max, SS2Max, PB1Max, PB2Max, PMF1Max, PMF2Max, PMA1Max, PMA2Max, PS1Max, PS2Max from DataSubmarineSensors as dsm, DataSensor as dm where (dsm.ID = " + Conversions.ToString(theAU.DBID) + " and dsm.ComponentID = dm.ID) and Type <> 9001 and (Type > 6000 and Type < 7000) ORDER BY dm.Type, dm.Name ASC";
				string_4 = "select ComponentID, Name from DataSubmarineComms as dsm, DataComm as dm  where (dsm.ID = " + Conversions.ToString(theAU.DBID) + " and  dsm.ComponentID = dm.ID)";
				text2 = "select * from DataSubmarineDockingFacilities where id = " + Conversions.ToString(theAU.DBID);
				text = "select * from DataSubmarineAircraftFacilities where id = " + Conversions.ToString(theAU.DBID);
				activeUnit = new Submarine(ref theScen);
				num = 0;
				break;
			case GlobalVariables.ActiveUnitType.Facility:
				string_ = "select ComponentID, Name, SB1, SB2, SMF1, SMF2, SMA1, SMA2, SS1, SS2, PB1, PB2, PMF1, PMF2, PMA1, PMA2, PS1, PS2 from DataFacilityMounts as dsm, DataMount as dm  where (dsm.ID = " + Conversions.ToString(theAU.DBID) + " and  dsm.ComponentID = dm.ID) ORDER BY dm.Name ASC";
				string_3 = "select ComponentID, Name from DataFacilityMagazines as dsmag, DataMagazine as dmag  where (dsmag.ID = " + Conversions.ToString(theAU.DBID) + " and  dsmag.ComponentID = dmag.ID) ORDER BY dmag.Name ASC";
				string_2 = "select ComponentID, Name, Type, SB1, SB2, SMF1, SMF2, SMA1, SMA2, SS1, SS2, PB1, PB2, PMF1, PMF2, PMA1, PMA2, PS1, PS2, SB1Max, SB2Max, SMF1Max, SMF2Max, SMA1Max, SMA2Max, SS1Max, SS2Max, PB1Max, PB2Max, PMF1Max, PMF2Max, PMA1Max, PMA2Max, PS1Max, PS2Max from DataFacilitySensors as dsm, DataSensor as dm where (dsm.ID = " + Conversions.ToString(theAU.DBID) + " and dsm.ComponentID = dm.ID) and Type <> 9001 and (Type < 6000 or Type > 6999) ORDER BY dm.Type, dm.Name ASC";
				text3 = "select ComponentID, Name, Type, SB1, SB2, SMF1, SMF2, SMA1, SMA2, SS1, SS2, PB1, PB2, PMF1, PMF2, PMA1, PMA2, PS1, PS2, SB1Max, SB2Max, SMF1Max, SMF2Max, SMA1Max, SMA2Max, SS1Max, SS2Max, PB1Max, PB2Max, PMF1Max, PMF2Max, PMA1Max, PMA2Max, PS1Max, PS2Max from DataFacilitySensors as dsm, DataSensor as dm where (dsm.ID = " + Conversions.ToString(theAU.DBID) + " and dsm.ComponentID = dm.ID) and Type <> 9001 and (Type > 6000 and Type < 7000) ORDER BY dm.Type, dm.Name ASC";
				string_4 = "select ComponentID, Name from DataFacilityComms as dsm, DataComm as dm  where (dsm.ID = " + Conversions.ToString(theAU.DBID) + " and  dsm.ComponentID = dm.ID)";
				text2 = "select * from DataFacilityDockingFacilities where id = " + Conversions.ToString(theAU.DBID);
				text = "select * from DataFacilityAircraftFacilities where id = " + Conversions.ToString(theAU.DBID);
				activeUnit = new Facility(ref theScen);
				num = 0;
				break;
			case GlobalVariables.ActiveUnitType.Aimpoint:
			case GlobalVariables.ActiveUnitType.Weapon:
				num = 0;
				break;
			case GlobalVariables.ActiveUnitType.Satellite:
				string_ = "select ComponentID, Name, SB1, SB2, SMF1, SMF2, SMA1, SMA2, SS1, SS2, PB1, PB2, PMF1, PMF2, PMA1, PMA2, PS1, PS2 from DataSatelliteMounts as dsm, DataMount as dm  where (dsm.ID = " + Conversions.ToString(theAU.DBID) + " and  dsm.ComponentID = dm.ID) ORDER BY dm.Name ASC";
				string_2 = "select ComponentID, Name, Type, SB1, SB2, SMF1, SMF2, SMA1, SMA2, SS1, SS2, PB1, PB2, PMF1, PMF2, PMA1, PMA2, PS1, PS2, SB1Max, SB2Max, SMF1Max, SMF2Max, SMA1Max, SMA2Max, SS1Max, SS2Max, PB1Max, PB2Max, PMF1Max, PMF2Max, PMA1Max, PMA2Max, PS1Max, PS2Max from DataSatelliteSensors as dsm, DataSensor as dm where (dsm.ID = " + Conversions.ToString(theAU.DBID) + " and dsm.ComponentID = dm.ID) and Type <> 9001 and (Type < 6000 or Type > 6999) ORDER BY dm.Type, dm.Name ASC";
				text3 = "select ComponentID, Name, Type, SB1, SB2, SMF1, SMF2, SMA1, SMA2, SS1, SS2, PB1, PB2, PMF1, PMF2, PMA1, PMA2, PS1, PS2, SB1Max, SB2Max, SMF1Max, SMF2Max, SMA1Max, SMA2Max, SS1Max, SS2Max, PB1Max, PB2Max, PMF1Max, PMF2Max, PMA1Max, PMA2Max, PS1Max, PS2Max from DataSatelliteSensors as dsm, DataSensor as dm where (dsm.ID = " + Conversions.ToString(theAU.DBID) + " and dsm.ComponentID = dm.ID) and Type <> 9001 and (Type > 6000 and Type < 7000) ORDER BY dm.Type, dm.Name ASC";
				string_4 = "select ComponentID, Name from DataSatelliteComms as dsm, DataComm as dm  where (dsm.ID = " + Conversions.ToString(theAU.DBID) + " and  dsm.ComponentID = dm.ID)";
				activeUnit = new Satellite(ref theScen);
				num = 0;
				break;
			case GlobalVariables.ActiveUnitType.Vehicle:
				string_ = "select ComponentID, Name, SB1, SB2, SMF1, SMF2, SMA1, SMA2, SS1, SS2, PB1, PB2, PMF1, PMF2, PMA1, PMA2, PS1, PS2 from DataGroundUnitMounts as dsm, DataMount as dm  where (dsm.ID = " + Conversions.ToString(theAU.DBID) + " and  dsm.ComponentID = dm.ID) ORDER BY dm.Name ASC";
				string_2 = "select ComponentID, Name, Type, SB1, SB2, SMF1, SMF2, SMA1, SMA2, SS1, SS2, PB1, PB2, PMF1, PMF2, PMA1, PMA2, PS1, PS2, SB1Max, SB2Max, SMF1Max, SMF2Max, SMA1Max, SMA2Max, SS1Max, SS2Max, PB1Max, PB2Max, PMF1Max, PMF2Max, PMA1Max, PMA2Max, PS1Max, PS2Max from DataGroundUnitSensors as dsm, DataSensor as dm where (dsm.ID = " + Conversions.ToString(theAU.DBID) + " and dsm.ComponentID = dm.ID) and Type <> 9001 and (Type < 6000 or Type > 6999) ORDER BY dm.Type, dm.Name ASC";
				string_3 = "select ComponentID, Name from DataGroundUnitMagazines as dsmag, DataMagazine as dmag  where (dsmag.ID = " + Conversions.ToString(theAU.DBID) + " and  dsmag.ComponentID = dmag.ID) ORDER BY dmag.Name ASC";
				text3 = "select ComponentID, Name, Type, SB1, SB2, SMF1, SMF2, SMA1, SMA2, SS1, SS2, PB1, PB2, PMF1, PMF2, PMA1, PMA2, PS1, PS2, SB1Max, SB2Max, SMF1Max, SMF2Max, SMA1Max, SMA2Max, SS1Max, SS2Max, PB1Max, PB2Max, PMF1Max, PMF2Max, PMA1Max, PMA2Max, PS1Max, PS2Max from DataGroundUnitSensors as dsm, DataSensor as dm where (dsm.ID = " + Conversions.ToString(theAU.DBID) + " and dsm.ComponentID = dm.ID) and Type <> 9001 and (Type > 6000 and Type < 7000) ORDER BY dm.Type, dm.Name ASC";
				string_4 = "select ComponentID, Name from DataGroundUnitComms as dsm, DataComm as dm  where (dsm.ID = " + Conversions.ToString(theAU.DBID) + " and  dsm.ComponentID = dm.ID)";
				activeUnit = new Vehicle(ref theScen);
				num = 0;
				break;
			}
			bool flag = (byte)num != 0;
			if (!(theAU.IsAircraft | theAU.IsFacility | theAU.IsShip | theAU.IsSubmarine | theAU.IsSatellite | theAU.IsVehicle))
			{
				return;
			}
			if (theAU.IsAircraft)
			{
				Aircraft aircraft = (Aircraft)theAU;
				if (aircraft.FuelCapacityMax != aircraft.FuelCapacityCurrent)
				{
					flag = true;
				}
			}
			else if (!theAU.IsFacility && (theAU.IsShip || theAU.IsSubmarine) && theAU.FuelCapacityMax != theAU.FuelCapacityCurrent)
			{
				flag = true;
			}
			DataTable dataTable2 = new DataTable();
			if (!dataTable2.Columns.Contains("DBID"))
			{
				dataTable2.Columns.Add("DBID", typeof(int));
			}
			if (!dataTable2.Columns.Contains("Name"))
			{
				dataTable2.Columns.Add("Name", typeof(string));
			}
			if (!theAU.Sensory.ObeysEMCON)
			{
				Sensor[] sensors_Cached = theAU.Sensors_Cached;
				foreach (Sensor sensor in sensors_Cached)
				{
					if (sensor.IsActive())
					{
						dataTable2.Rows.Add(sensor.DBID, sensor.Name);
					}
				}
			}
			DataTable dataTable3 = sQLiteHelper.ExecuteDataTable(string_);
			if (!dataTable3.Columns.Contains("MountIndex"))
			{
				dataTable3.Columns.Add("MountIndex", typeof(int));
			}
			int num2 = dataTable3.Rows.Count - 1;
			for (int j = 0; j <= num2; j++)
			{
				dataTable3.Rows[j]["MountIndex"] = j;
			}
			DataTable dataTable4 = new DataTable();
			dataTable4.Columns.Add("ID", typeof(int));
			dataTable4.Columns.Add("Name", typeof(string));
			dataTable4.Columns.Add("SB1", typeof(bool));
			dataTable4.Columns.Add("SB2", typeof(bool));
			dataTable4.Columns.Add("SMF1", typeof(bool));
			dataTable4.Columns.Add("SMF2", typeof(bool));
			dataTable4.Columns.Add("SMA1", typeof(bool));
			dataTable4.Columns.Add("SMA2", typeof(bool));
			dataTable4.Columns.Add("SS1", typeof(bool));
			dataTable4.Columns.Add("SS2", typeof(bool));
			dataTable4.Columns.Add("PB1", typeof(bool));
			dataTable4.Columns.Add("PB2", typeof(bool));
			dataTable4.Columns.Add("PMF1", typeof(bool));
			dataTable4.Columns.Add("PMF2", typeof(bool));
			dataTable4.Columns.Add("PMA1", typeof(bool));
			dataTable4.Columns.Add("PMA2", typeof(bool));
			dataTable4.Columns.Add("PS1", typeof(bool));
			dataTable4.Columns.Add("PS2", typeof(bool));
			dataTable4.Columns.Add("Has360Coverage", typeof(bool));
			DataTable dataTable5 = new DataTable();
			dataTable5.Columns.Add("MountID", typeof(int));
			dataTable5.Columns.Add("MountIndex", typeof(int));
			dataTable5.Columns.Add("MountName", typeof(string));
			DataTable dataTable6 = new DataTable();
			dataTable6.Columns.Add("MountID", typeof(int));
			dataTable6.Columns.Add("MountIndex", typeof(int));
			dataTable6.Columns.Add("WeaponID", typeof(int));
			dataTable6.Columns.Add("WeaponQty", typeof(int));
			dataTable6.Columns.Add("WeaponName", typeof(string));
			DataTable dataTable7 = new DataTable();
			dataTable7.Columns.Add("MountID", typeof(int));
			dataTable7.Columns.Add("MountIndex", typeof(int));
			dataTable7.Columns.Add("WeapRecID", typeof(int));
			dataTable7.Columns.Add("WeaponName", typeof(string));
			dataTable7.Columns.Add("WeaponID", typeof(string));
			DataTable dataTable8 = new DataTable();
			dataTable8.Columns.Add("MountID", typeof(int));
			dataTable8.Columns.Add("MountIndex", typeof(int));
			dataTable8.Columns.Add("WeaponID", typeof(int));
			dataTable8.Columns.Add("WeaponName", typeof(string));
			new DataTable
			{
				Columns = 
				{
					{
						"MountID",
						typeof(int)
					},
					{
						"MountIndex",
						typeof(int)
					},
					{
						"MountName",
						typeof(string)
					}
				}
			};
			DataTable dataTable9 = new DataTable();
			dataTable9.Columns.Add("MountID", typeof(int));
			dataTable9.Columns.Add("MountIndex", typeof(int));
			dataTable9.Columns.Add("WeaponID", typeof(int));
			dataTable9.Columns.Add("WeaponQty", typeof(int));
			dataTable9.Columns.Add("WeaponName", typeof(string));
			DataTable dataTable10 = new DataTable();
			dataTable10.Columns.Add("MountID", typeof(int));
			dataTable10.Columns.Add("MountIndex", typeof(int));
			dataTable10.Columns.Add("WeapRecID", typeof(int));
			dataTable10.Columns.Add("WeaponName", typeof(string));
			dataTable10.Columns.Add("WeaponID", typeof(string));
			DataTable dataTable11 = new DataTable();
			dataTable11.Columns.Add("MountID", typeof(int));
			dataTable11.Columns.Add("MountIndex", typeof(int));
			dataTable11.Columns.Add("WeaponID", typeof(int));
			dataTable11.Columns.Add("WeaponName", typeof(string));
			DataTable dataTable12 = new DataTable();
			dataTable12.Columns.Add("MountID", typeof(int));
			dataTable12.Columns.Add("MountIndex", typeof(int));
			dataTable12.Columns.Add("SensorID", typeof(int));
			dataTable12.Columns.Add("Name", typeof(string));
			dataTable12.Columns.Add("Remove", typeof(bool));
			new DataTable
			{
				Columns = 
				{
					{
						"MountID",
						typeof(int)
					},
					{
						"MountIndex",
						typeof(int)
					},
					{
						"CommsID",
						typeof(int)
					},
					{
						"Name",
						typeof(string)
					},
					{
						"Remove",
						typeof(bool)
					}
				}
			};
			DataTable dataTable13 = new DataTable();
			dataTable13.Columns.Add("MagID", typeof(int));
			dataTable13.Columns.Add("MagIndex", typeof(int));
			dataTable13.Columns.Add("MagName", typeof(string));
			DataTable dataTable14 = new DataTable();
			dataTable14.Columns.Add("MagID", typeof(int));
			dataTable14.Columns.Add("MagIndex", typeof(int));
			dataTable14.Columns.Add("WeaponID", typeof(int));
			dataTable14.Columns.Add("WeaponQty", typeof(int));
			dataTable14.Columns.Add("WeaponName", typeof(string));
			DataTable dataTable15 = new DataTable();
			dataTable15.Columns.Add("MagID", typeof(int));
			dataTable15.Columns.Add("MagIndex", typeof(int));
			dataTable15.Columns.Add("WeapRecID", typeof(int));
			dataTable15.Columns.Add("WeaponName", typeof(string));
			dataTable15.Columns.Add("WeaponID", typeof(string));
			DataTable dataTable16 = new DataTable();
			dataTable16.Columns.Add("MagID", typeof(int));
			dataTable16.Columns.Add("MagIndex", typeof(int));
			dataTable16.Columns.Add("WeaponID", typeof(int));
			dataTable16.Columns.Add("WeaponName", typeof(string));
			int num3 = dataTable3.Rows.Count - 1;
			bool flag2 = default(bool);
			int num5 = default(int);
			foreach (Mount mount in theAU.Mounts)
			{
				flag2 = false;
				foreach (DataRow row in dataTable3.Rows)
				{
					int num4 = Conversions.ToInteger(row["ComponentID"]);
					if ((num4 == mount.DBID) & (mount.Coverage.SB1 == Conversions.ToBoolean(row["SB1"])) & (mount.Coverage.SB2 == Conversions.ToBoolean(row["SB2"])) & (mount.Coverage.SMF1 == Conversions.ToBoolean(row["SMF1"])) & (mount.Coverage.SMF2 == Conversions.ToBoolean(row["SMF2"])) & (mount.Coverage.SMA1 == Conversions.ToBoolean(row["SMA1"])) & (mount.Coverage.SMA2 == Conversions.ToBoolean(row["SMA2"])) & (mount.Coverage.SS1 == Conversions.ToBoolean(row["SS1"])) & (mount.Coverage.SS2 == Conversions.ToBoolean(row["SS2"])) & (mount.Coverage.PB1 == Conversions.ToBoolean(row["PB1"])) & (mount.Coverage.PB2 == Conversions.ToBoolean(row["PB2"])) & (mount.Coverage.PMF1 == Conversions.ToBoolean(row["PMF1"])) & (mount.Coverage.PMF2 == Conversions.ToBoolean(row["PMF2"])) & (mount.Coverage.PMA1 == Conversions.ToBoolean(row["PMA1"])) & (mount.Coverage.PMA2 == Conversions.ToBoolean(row["PMA2"])) & (mount.Coverage.PS1 == Conversions.ToBoolean(row["PS1"])) & (mount.Coverage.PS2 == Conversions.ToBoolean(row["PS2"])))
					{
						num5 = Conversions.ToInteger(row["MountIndex"].ToString());
						row.Delete();
						flag2 = true;
						break;
					}
				}
				if (!flag2 && !flag2)
				{
					num5 = num3 + 1;
					num3++;
				}
				if (!flag2)
				{
					dataTable4.Rows.Add(mount.DBID, mount.Name, mount.Coverage.SB1, mount.Coverage.SB2, mount.Coverage.SMF1, mount.Coverage.SMF2, mount.Coverage.SMA1, mount.Coverage.SMA2, mount.Coverage.SS1, mount.Coverage.SS2, mount.Coverage.PB1, mount.Coverage.PB2, mount.Coverage.PMF1, mount.Coverage.PMF2, mount.Coverage.PMA1, mount.Coverage.PMA2, mount.Coverage.PS1, mount.Coverage.PS2, mount.Coverage.Has360Coverage.Value);
				}
				Mount theMount = new Mount();
				DBFunctions.PopulateMountSensors(ref theMount, mount.DBID, theScen.DBConnection);
				if (mount.Sensors_ReadOnly.Count() != theMount.Sensors_ReadOnly.Count())
				{
					if (mount.Sensors_ReadOnly.Count() == 0)
					{
						Sensor[] sensors_ReadOnly = theMount.Sensors_ReadOnly;
						foreach (Sensor sensor2 in sensors_ReadOnly)
						{
							dataTable12.Rows.Add(mount.DBID, num5, sensor2.DBID, sensor2.Name, true);
						}
					}
					else
					{
						Sensor[] sensors_ReadOnly2 = theMount.Sensors_ReadOnly;
						foreach (Sensor sensor3 in sensors_ReadOnly2)
						{
							dataTable12.Rows.Add(mount.DBID, num5, sensor3.DBID, sensor3.Name, true);
						}
						Sensor[] sensors_ReadOnly3 = mount.Sensors_ReadOnly;
						foreach (Sensor sensor4 in sensors_ReadOnly3)
						{
							dataTable12.Rows.Add(mount.DBID, num5, sensor4.DBID, sensor4.Name, false);
						}
					}
				}
				string string_5 = "select dwr.ComponentID, DefaultLoad, MaxLoad, Multiple, Name from DataWeaponRecord dwr, DataMountWeapons dmw, DataWeapon dw where dmw.ID = " + Conversions.ToString(mount.DBID) + " and  dmw.ComponentID = dwr.ID and dw.ID = dwr.ComponentID;";
				DataTable dataTable17 = sQLiteHelper.ExecuteDataTable(string_5);
				bool flag3 = false;
				foreach (WeaponRec mountWeapon in mount.MountWeapons)
				{
					bool flag4 = false;
					foreach (DataRow row2 in dataTable17.Rows)
					{
						int num6 = Conversions.ToInteger(row2["ComponentID"]);
						string text4 = Conversions.ToString(row2["Name"]);
						int num7 = Conversions.ToInteger(row2["DefaultLoad"]);
						int num8 = Conversions.ToInteger(row2["MaxLoad"]);
						int num9 = Conversions.ToInteger(row2["Multiple"]);
						if ((num6 == mountWeapon.int_3) & (num8 == mountWeapon.MaxLoad) & (num9 == mountWeapon.Multiple))
						{
							row2.Delete();
							flag4 = true;
							if (num7 != mountWeapon.CurrentLoad)
							{
								dataTable6.Rows.Add(mount.DBID, num5, mountWeapon.int_3, mountWeapon.CurrentLoad, text4);
								flag3 = true;
							}
							break;
						}
					}
					if (!flag4)
					{
						mountWeapon.ResetTimeToFire();
						string_5 = "select dwr.ID, dw.Name from DataWeaponRecord dwr, DataWeapon dw where dwr.ComponentID = " + Conversions.ToString(mountWeapon.int_3) + " and DefaultLoad = " + Conversions.ToString(mountWeapon.CurrentLoad) + " and MaxLoad = " + Conversions.ToString(mountWeapon.MaxLoad) + " and Multiple = " + Conversions.ToString(mountWeapon.Multiple) + " and ROF = " + Conversions.ToString(mountWeapon.TimeToFire) + " and dw.ID = dwr.ComponentID;";
						DataTable dataTable18 = sQLiteHelper.ExecuteDataTable(string_5);
						int num11;
						if (dataTable18.Rows.Count > 0)
						{
							DataRow dataRow3 = dataTable18.Rows[0];
							int num10 = Conversions.ToInteger(dataRow3["ID"]);
							string text4 = Conversions.ToString(dataRow3["Name"]);
							dataTable7.Rows.Add(mount.DBID, num5, num10, text4, mountWeapon.int_3);
							flag4 = true;
							flag3 = true;
							num11 = 11;
						}
						else
						{
							num11 = 11;
						}
						string[] array = new string[num11];
						array[0] = "select dwr.ID, dw.Name from DataWeaponRecord dwr, DataWeapon dw where dwr.ComponentID = ";
						array[1] = Conversions.ToString(mountWeapon.int_3);
						array[2] = " and DefaultLoad = ";
						array[3] = Conversions.ToString(mountWeapon.DefaultLoad);
						array[4] = " and MaxLoad = ";
						array[5] = Conversions.ToString(mountWeapon.MaxLoad);
						array[6] = " and Multiple = ";
						array[7] = Conversions.ToString(mountWeapon.Multiple);
						array[8] = " and ROF = ";
						array[9] = Conversions.ToString(mountWeapon.TimeToFire);
						array[10] = " and dw.ID = dwr.ComponentID;";
						string_5 = string.Concat(array);
						dataTable18 = sQLiteHelper.ExecuteDataTable(string_5);
						int num12;
						if (dataTable18.Rows.Count > 0 && !flag4)
						{
							DataRow dataRow4 = dataTable18.Rows[0];
							int num10 = Conversions.ToInteger(dataRow4["ID"]);
							string text4 = Conversions.ToString(dataRow4["Name"]);
							dataTable7.Rows.Add(mount.DBID, num5, num10, text4, mountWeapon.int_3);
							dataTable6.Rows.Add(mount.DBID, num5, mountWeapon.int_3, mountWeapon.CurrentLoad, text4);
							flag4 = true;
							flag3 = true;
							num12 = 9;
						}
						else
						{
							num12 = 9;
						}
						string[] array2 = new string[num12];
						array2[0] = "select dwr.ID, dw.Name from DataWeaponRecord dwr, DataWeapon dw where dwr.ComponentID = ";
						array2[1] = Conversions.ToString(mountWeapon.int_3);
						array2[2] = " and DefaultLoad = ";
						array2[3] = Conversions.ToString(mountWeapon.CurrentLoad);
						array2[4] = " and MaxLoad = ";
						array2[5] = Conversions.ToString(mountWeapon.MaxLoad);
						array2[6] = " and Multiple = ";
						array2[7] = Conversions.ToString(mountWeapon.Multiple);
						array2[8] = " and dw.ID = dwr.ComponentID;";
						string_5 = string.Concat(array2);
						dataTable18 = sQLiteHelper.ExecuteDataTable(string_5);
						int num13;
						if (dataTable18.Rows.Count > 0 && !flag4)
						{
							DataRow dataRow5 = dataTable18.Rows[0];
							int num10 = Conversions.ToInteger(dataRow5["ID"]);
							string text4 = Conversions.ToString(dataRow5["Name"]);
							dataTable7.Rows.Add(mount.DBID, num5, num10, text4, mountWeapon.int_3);
							dataTable6.Rows.Add(mount.DBID, num5, mountWeapon.int_3, mountWeapon.CurrentLoad, text4);
							flag4 = true;
							flag3 = true;
							num13 = 9;
						}
						else
						{
							num13 = 9;
						}
						string[] array3 = new string[num13];
						array3[0] = "select dwr.ID, dw.Name from DataWeaponRecord dwr, DataWeapon dw where dwr.ComponentID = ";
						array3[1] = Conversions.ToString(mountWeapon.int_3);
						array3[2] = " and DefaultLoad = ";
						array3[3] = Conversions.ToString(mountWeapon.DefaultLoad);
						array3[4] = " and MaxLoad = ";
						array3[5] = Conversions.ToString(mountWeapon.MaxLoad);
						array3[6] = " and Multiple = ";
						array3[7] = Conversions.ToString(mountWeapon.Multiple);
						array3[8] = " and dw.ID = dwr.ComponentID;";
						string_5 = string.Concat(array3);
						dataTable18 = sQLiteHelper.ExecuteDataTable(string_5);
						int num14;
						if (dataTable18.Rows.Count > 0 && !flag4)
						{
							DataRow dataRow6 = dataTable18.Rows[0];
							int num10 = Conversions.ToInteger(dataRow6["ID"]);
							string text4 = Conversions.ToString(dataRow6["Name"]);
							dataTable7.Rows.Add(mount.DBID, num5, num10, text4, mountWeapon.int_3);
							dataTable6.Rows.Add(mount.DBID, num5, mountWeapon.int_3, mountWeapon.CurrentLoad, text4);
							flag4 = true;
							flag3 = true;
							num14 = 7;
						}
						else
						{
							num14 = 7;
						}
						string[] array4 = new string[num14];
						array4[0] = "select dwr.ID, dw.Name from DataWeaponRecord dwr, DataWeapon dw where dwr.ComponentID = ";
						array4[1] = Conversions.ToString(mountWeapon.int_3);
						array4[2] = " and MaxLoad = ";
						array4[3] = Conversions.ToString(mountWeapon.MaxLoad);
						array4[4] = " and Multiple = ";
						array4[5] = Conversions.ToString(mountWeapon.Multiple);
						array4[6] = " and dw.ID = dwr.ComponentID;";
						string_5 = string.Concat(array4);
						dataTable18 = sQLiteHelper.ExecuteDataTable(string_5);
						if (dataTable18.Rows.Count > 0 && !flag4)
						{
							DataRow dataRow7 = dataTable18.Rows[0];
							int num10 = Conversions.ToInteger(dataRow7["ID"]);
							string text4 = Conversions.ToString(dataRow7["Name"]);
							dataTable7.Rows.Add(mount.DBID, num5, num10, text4, mountWeapon.int_3);
							dataTable6.Rows.Add(mount.DBID, num5, mountWeapon.int_3, mountWeapon.CurrentLoad, text4);
							flag4 = true;
							flag3 = true;
						}
						if (!flag4 && Information.IsNothing((object)mountWeapon.WRecDBID) && mountWeapon.MaxLoad == 10000)
						{
							int num10 = 0;
							string text4 = ((!Information.IsNothing((object)mountWeapon.get_ReferenceWeapon(theScen))) ? mountWeapon.get_ReferenceWeapon(theScen).Name : "ERROR: Name not found");
							dataTable7.Rows.Add(mount.DBID, num5, num10, text4, mountWeapon.int_3);
							dataTable6.Rows.Add(mount.DBID, num5, mountWeapon.int_3, mountWeapon.CurrentLoad, text4);
							flag4 = true;
							flag3 = true;
						}
						if (!flag4)
						{
							string text5 = "WARNING: Mount " + mount.Name + " (ID: " + Conversions.ToString(mount.DBID) + ") has a new weapons added to it, however a good match could not be found in the database! Weapon ID: " + Conversions.ToString(mountWeapon.int_3) + " Default Load: " + Conversions.ToString(mountWeapon.DefaultLoad) + " Max Load: " + Conversions.ToString(mountWeapon.MaxLoad) + " Multiple: " + Conversions.ToString(mountWeapon.Multiple);
							LogFileWriter = File.AppendText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR INI template log file.txt");
							LogFileWriter.Write("\r\n      " + text5);
							LogFileWriter.Close();
							ErrorCount++;
						}
					}
				}
				if (dataTable17.Rows.Count > 0)
				{
					foreach (DataRow row3 in dataTable17.Rows)
					{
						int num6 = Conversions.ToInteger(row3["ComponentID"]);
						string text4 = Conversions.ToString(row3["Name"]);
						dataTable8.Rows.Add(mount.DBID, num5, num6, text4);
					}
					flag3 = true;
				}
				string_5 = "select dwr.ComponentID, DefaultLoad, MaxLoad, Multiple, Name from DataWeaponRecord dwr, DataMountMagazineWeapons dmw, DataWeapon dw where dmw.ID = " + Conversions.ToString(mount.DBID) + " and  dmw.ComponentID = dwr.ID and dw.ID = dwr.ComponentID;";
				dataTable17 = sQLiteHelper.ExecuteDataTable(string_5);
				flag2 = false;
				Magazine mountMagazine = mount.MountMagazine;
				foreach (WeaponRec weapon in mountMagazine.Weapons)
				{
					bool flag4 = false;
					foreach (DataRow row4 in dataTable17.Rows)
					{
						int num15 = Conversions.ToInteger(row4["ComponentID"]);
						string text6 = Conversions.ToString(row4["Name"]);
						int num16 = Conversions.ToInteger(row4["DefaultLoad"]);
						int num17 = Conversions.ToInteger(row4["MaxLoad"]);
						int num18 = Conversions.ToInteger(row4["Multiple"]);
						if ((num15 == weapon.int_3) & (num17 == weapon.MaxLoad) & (num18 == weapon.Multiple))
						{
							row4.Delete();
							flag4 = true;
							if (num16 != weapon.CurrentLoad)
							{
								dataTable9.Rows.Add(mount.DBID, num5, weapon.int_3, weapon.CurrentLoad, text6);
								flag3 = true;
							}
							break;
						}
					}
					if (!flag4)
					{
						weapon.ResetTimeToFire();
						string_5 = "select dwr.ID, dw.Name from DataWeaponRecord dwr, DataWeapon dw where dwr.ComponentID = " + Conversions.ToString(weapon.int_3) + " and DefaultLoad = " + Conversions.ToString(weapon.CurrentLoad) + " and MaxLoad = " + Conversions.ToString(weapon.MaxLoad) + " and Multiple = " + Conversions.ToString(weapon.Multiple) + " and ROF = " + Conversions.ToString(weapon.TimeToFire) + " and dw.ID = dwr.ComponentID;";
						DataTable dataTable18 = sQLiteHelper.ExecuteDataTable(string_5);
						int num20;
						if (dataTable18.Rows.Count > 0)
						{
							DataRow dataRow9 = dataTable18.Rows[0];
							int num19 = Conversions.ToInteger(dataRow9["ID"]);
							string text6 = Conversions.ToString(dataRow9["Name"]);
							dataTable10.Rows.Add(mount.DBID, num5, num19, text6, weapon.int_3);
							flag4 = true;
							flag3 = true;
							num20 = 11;
						}
						else
						{
							num20 = 11;
						}
						string[] array5 = new string[num20];
						array5[0] = "select dwr.ID, dw.Name from DataWeaponRecord dwr, DataWeapon dw where dwr.ComponentID = ";
						array5[1] = Conversions.ToString(weapon.int_3);
						array5[2] = " and DefaultLoad = ";
						array5[3] = Conversions.ToString(weapon.DefaultLoad);
						array5[4] = " and MaxLoad = ";
						array5[5] = Conversions.ToString(weapon.MaxLoad);
						array5[6] = " and Multiple = ";
						array5[7] = Conversions.ToString(weapon.Multiple);
						array5[8] = " and ROF = ";
						array5[9] = Conversions.ToString(weapon.TimeToFire);
						array5[10] = " and dw.ID = dwr.ComponentID;";
						string_5 = string.Concat(array5);
						dataTable18 = sQLiteHelper.ExecuteDataTable(string_5);
						int num21;
						if (!(dataTable18.Rows.Count > 0 && !flag4))
						{
							num21 = 9;
						}
						else
						{
							DataRow dataRow10 = dataTable18.Rows[0];
							int num19 = Conversions.ToInteger(dataRow10["ID"]);
							string text6 = Conversions.ToString(dataRow10["Name"]);
							dataTable10.Rows.Add(mount.DBID, num5, num19, text6, weapon.int_3);
							dataTable9.Rows.Add(mount.DBID, num5, weapon.int_3, weapon.CurrentLoad, text6);
							flag4 = true;
							flag3 = true;
							num21 = 9;
						}
						string[] array6 = new string[num21];
						array6[0] = "select dwr.ID, dw.Name from DataWeaponRecord dwr, DataWeapon dw where dwr.ComponentID = ";
						array6[1] = Conversions.ToString(weapon.int_3);
						array6[2] = " and DefaultLoad = ";
						array6[3] = Conversions.ToString(weapon.CurrentLoad);
						array6[4] = " and MaxLoad = ";
						array6[5] = Conversions.ToString(weapon.MaxLoad);
						array6[6] = " and Multiple = ";
						array6[7] = Conversions.ToString(weapon.Multiple);
						array6[8] = " and dw.ID = dwr.ComponentID;";
						string_5 = string.Concat(array6);
						dataTable18 = sQLiteHelper.ExecuteDataTable(string_5);
						int num22;
						if (dataTable18.Rows.Count > 0 && !flag4)
						{
							DataRow dataRow11 = dataTable18.Rows[0];
							int num19 = Conversions.ToInteger(dataRow11["ID"]);
							string text6 = Conversions.ToString(dataRow11["Name"]);
							dataTable10.Rows.Add(mount.DBID, num5, num19, text6, weapon.int_3);
							dataTable9.Rows.Add(mount.DBID, num5, weapon.int_3, weapon.CurrentLoad, text6);
							flag4 = true;
							flag3 = true;
							num22 = 9;
						}
						else
						{
							num22 = 9;
						}
						string[] array7 = new string[num22];
						array7[0] = "select dwr.ID, dw.Name from DataWeaponRecord dwr, DataWeapon dw where dwr.ComponentID = ";
						array7[1] = Conversions.ToString(weapon.int_3);
						array7[2] = " and DefaultLoad = ";
						array7[3] = Conversions.ToString(weapon.DefaultLoad);
						array7[4] = " and MaxLoad = ";
						array7[5] = Conversions.ToString(weapon.MaxLoad);
						array7[6] = " and Multiple = ";
						array7[7] = Conversions.ToString(weapon.Multiple);
						array7[8] = " and dw.ID = dwr.ComponentID;";
						string_5 = string.Concat(array7);
						dataTable18 = sQLiteHelper.ExecuteDataTable(string_5);
						int num23;
						if (!(dataTable18.Rows.Count > 0 && !flag4))
						{
							num23 = 7;
						}
						else
						{
							DataRow dataRow12 = dataTable18.Rows[0];
							int num19 = Conversions.ToInteger(dataRow12["ID"]);
							string text6 = Conversions.ToString(dataRow12["Name"]);
							dataTable10.Rows.Add(mount.DBID, num5, num19, text6, weapon.int_3);
							dataTable9.Rows.Add(mount.DBID, num5, weapon.int_3, weapon.CurrentLoad, text6);
							flag4 = true;
							flag3 = true;
							num23 = 7;
						}
						string[] array8 = new string[num23];
						array8[0] = "select dwr.ID, dw.Name from DataWeaponRecord dwr, DataWeapon dw where dwr.ComponentID = ";
						array8[1] = Conversions.ToString(weapon.int_3);
						array8[2] = " and MaxLoad = ";
						array8[3] = Conversions.ToString(weapon.MaxLoad);
						array8[4] = " and Multiple = ";
						array8[5] = Conversions.ToString(weapon.Multiple);
						array8[6] = " and dw.ID = dwr.ComponentID;";
						string_5 = string.Concat(array8);
						dataTable18 = sQLiteHelper.ExecuteDataTable(string_5);
						if (dataTable18.Rows.Count > 0 && !flag4)
						{
							DataRow dataRow13 = dataTable18.Rows[0];
							int num19 = Conversions.ToInteger(dataRow13["ID"]);
							string text6 = Conversions.ToString(dataRow13["Name"]);
							dataTable10.Rows.Add(mount.DBID, num5, num19, text6, weapon.int_3);
							dataTable9.Rows.Add(mount.DBID, num5, weapon.int_3, weapon.CurrentLoad, text6);
							flag4 = true;
							flag3 = true;
						}
						if (!flag4 && Information.IsNothing((object)weapon.WRecDBID) && weapon.MaxLoad == 10000)
						{
							int num19 = 0;
							string text6 = (Information.IsNothing((object)weapon.get_ReferenceWeapon(theScen)) ? "ERROR: Name not found" : weapon.get_ReferenceWeapon(theScen).Name);
							dataTable10.Rows.Add(mount.DBID, num5, num19, text6, weapon.int_3);
							dataTable9.Rows.Add(mount.DBID, num5, weapon.int_3, weapon.CurrentLoad, text6);
							flag4 = true;
							flag3 = true;
						}
						if (!flag4)
						{
							string text5 = "WARNING: Mount " + mount.Name + " (ID: " + Conversions.ToString(mount.DBID) + ") has a new mount magazine weapons added to it, however a good match could not be found in the database! Weapon ID: " + Conversions.ToString(weapon.int_3) + " Default Load: " + Conversions.ToString(weapon.DefaultLoad) + " Max Load: " + Conversions.ToString(weapon.MaxLoad) + " Multiple: " + Conversions.ToString(weapon.Multiple);
							LogFileWriter = File.AppendText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR INI template log file.txt");
							LogFileWriter.Write("\r\n      " + text5);
							LogFileWriter.Close();
							ErrorCount++;
						}
					}
				}
				if (dataTable17.Rows.Count > 0)
				{
					foreach (DataRow row5 in dataTable17.Rows)
					{
						int num15 = Conversions.ToInteger(row5["ComponentID"]);
						string text6 = Conversions.ToString(row5["Name"]);
						dataTable11.Rows.Add(mount.DBID, num5, num15, text6);
					}
					flag3 = true;
				}
				if (flag3)
				{
					dataTable5.Rows.Add(mount.DBID, num5, mount.Name);
				}
			}
			int num24 = 0;
			if (!Information.IsNothing((object)theAU.OnboardCargo))
			{
				num24 = theAU.OnboardCargo.Count();
			}
			DataTable dataTable19 = default(DataTable);
			DataTable dataTable20 = default(DataTable);
			if (theAU.IsFacility | theAU.IsShip | theAU.IsSubmarine | theAU.IsVehicle)
			{
				dataTable19 = sQLiteHelper.ExecuteDataTable(string_3);
				if (!dataTable19.Columns.Contains("MagIndex"))
				{
					dataTable19.Columns.Add("MagIndex", typeof(int));
				}
				int num25 = dataTable19.Rows.Count - 1;
				for (int n = 0; n <= num25; n++)
				{
					dataTable19.Rows[n]["MagIndex"] = n;
				}
				dataTable20 = new DataTable();
				dataTable20.Columns.Add("ID", typeof(int));
				dataTable20.Columns.Add("Name", typeof(string));
				int num26 = dataTable19.Rows.Count - 1;
				Magazine[] sharedMagazines = theAU.SharedMagazines;
				int num29 = default(int);
				foreach (Magazine magazine in sharedMagazines)
				{
					bool flag5 = false;
					foreach (DataRow row6 in dataTable19.Rows)
					{
						int num28 = Conversions.ToInteger(row6["ComponentID"]);
						if (num28 == magazine.DBID)
						{
							num29 = Conversions.ToInteger(row6["MagIndex"].ToString());
							row6.Delete();
							flag5 = true;
							break;
						}
					}
					if (!flag5 && !flag2)
					{
						num29 = num26 + 1;
						num26++;
					}
					if (!flag5)
					{
						dataTable20.Rows.Add(magazine.DBID, magazine.Name);
					}
					string string_5 = "select dwr.ComponentID, DefaultLoad, MaxLoad, Multiple, Name from DataWeaponRecord dwr, DataMagazineWeapons dmw, DataWeapon dw where dmw.ID = " + Conversions.ToString(magazine.DBID) + " and  dmw.ComponentID = dwr.ID and dw.ID = dwr.ComponentID;";
					DataTable dataTable17 = sQLiteHelper.ExecuteDataTable(string_5);
					bool flag3 = false;
					foreach (WeaponRec weapon2 in magazine.Weapons)
					{
						bool flag4 = false;
						foreach (DataRow row7 in dataTable17.Rows)
						{
							int num30 = Conversions.ToInteger(row7["ComponentID"]);
							string text7 = Conversions.ToString(row7["Name"]);
							int num31 = Conversions.ToInteger(row7["DefaultLoad"]);
							int num32 = Conversions.ToInteger(row7["MaxLoad"]);
							int num33 = Conversions.ToInteger(row7["Multiple"]);
							if ((num30 == weapon2.int_3) & (num32 == weapon2.MaxLoad) & (num33 == weapon2.Multiple))
							{
								row7.Delete();
								flag4 = true;
								if (num31 != weapon2.CurrentLoad)
								{
									dataTable14.Rows.Add(magazine.DBID, num29, weapon2.int_3, weapon2.CurrentLoad, text7);
									flag3 = true;
								}
								break;
							}
						}
						if (!flag4)
						{
							weapon2.ResetTimeToFire();
							string_5 = "select dwr.ID, dw.Name from DataWeaponRecord dwr, DataWeapon dw where dwr.ComponentID = " + Conversions.ToString(weapon2.int_3) + " and DefaultLoad = " + Conversions.ToString(weapon2.CurrentLoad) + " and MaxLoad = " + Conversions.ToString(weapon2.MaxLoad) + " and Multiple = " + Conversions.ToString(weapon2.Multiple) + " and ROF = " + Conversions.ToString(weapon2.TimeToFire) + " and dw.ID = dwr.ComponentID;";
							DataTable dataTable18 = sQLiteHelper.ExecuteDataTable(string_5);
							int num35;
							if (dataTable18.Rows.Count > 0)
							{
								DataRow dataRow16 = dataTable18.Rows[0];
								int num34 = Conversions.ToInteger(dataRow16["ID"]);
								string text7 = Conversions.ToString(dataRow16["Name"]);
								dataTable15.Rows.Add(magazine.DBID, num29, num34, text7, weapon2.int_3);
								flag4 = true;
								flag3 = true;
								num35 = 11;
							}
							else
							{
								num35 = 11;
							}
							string[] array9 = new string[num35];
							array9[0] = "select dwr.ID, dw.Name from DataWeaponRecord dwr, DataWeapon dw where dwr.ComponentID = ";
							array9[1] = Conversions.ToString(weapon2.int_3);
							array9[2] = " and DefaultLoad = ";
							array9[3] = Conversions.ToString(weapon2.DefaultLoad);
							array9[4] = " and MaxLoad = ";
							array9[5] = Conversions.ToString(weapon2.MaxLoad);
							array9[6] = " and Multiple = ";
							array9[7] = Conversions.ToString(weapon2.Multiple);
							array9[8] = " and ROF = ";
							array9[9] = Conversions.ToString(weapon2.TimeToFire);
							array9[10] = " and dw.ID = dwr.ComponentID;";
							string_5 = string.Concat(array9);
							dataTable18 = sQLiteHelper.ExecuteDataTable(string_5);
							int num36;
							if (!(dataTable18.Rows.Count > 0 && !flag4))
							{
								num36 = 9;
							}
							else
							{
								DataRow dataRow17 = dataTable18.Rows[0];
								int num34 = Conversions.ToInteger(dataRow17["ID"]);
								string text7 = Conversions.ToString(dataRow17["Name"]);
								dataTable15.Rows.Add(magazine.DBID, num29, num34, text7, weapon2.int_3);
								dataTable14.Rows.Add(magazine.DBID, num29, weapon2.int_3, weapon2.CurrentLoad, text7);
								flag4 = true;
								flag3 = true;
								num36 = 9;
							}
							string[] array10 = new string[num36];
							array10[0] = "select dwr.ID, dw.Name from DataWeaponRecord dwr, DataWeapon dw where dwr.ComponentID = ";
							array10[1] = Conversions.ToString(weapon2.int_3);
							array10[2] = " and DefaultLoad = ";
							array10[3] = Conversions.ToString(weapon2.CurrentLoad);
							array10[4] = " and MaxLoad = ";
							array10[5] = Conversions.ToString(weapon2.MaxLoad);
							array10[6] = " and Multiple = ";
							array10[7] = Conversions.ToString(weapon2.Multiple);
							array10[8] = " and dw.ID = dwr.ComponentID;";
							string_5 = string.Concat(array10);
							dataTable18 = sQLiteHelper.ExecuteDataTable(string_5);
							int num37;
							if (dataTable18.Rows.Count > 0 && !flag4)
							{
								DataRow dataRow18 = dataTable18.Rows[0];
								int num34 = Conversions.ToInteger(dataRow18["ID"]);
								string text7 = Conversions.ToString(dataRow18["Name"]);
								dataTable15.Rows.Add(magazine.DBID, num29, num34, text7, weapon2.int_3);
								dataTable14.Rows.Add(magazine.DBID, num29, weapon2.int_3, weapon2.CurrentLoad, text7);
								flag4 = true;
								flag3 = true;
								num37 = 9;
							}
							else
							{
								num37 = 9;
							}
							string[] array11 = new string[num37];
							array11[0] = "select dwr.ID, dw.Name from DataWeaponRecord dwr, DataWeapon dw where dwr.ComponentID = ";
							array11[1] = Conversions.ToString(weapon2.int_3);
							array11[2] = " and DefaultLoad = ";
							array11[3] = Conversions.ToString(weapon2.DefaultLoad);
							array11[4] = " and MaxLoad = ";
							array11[5] = Conversions.ToString(weapon2.MaxLoad);
							array11[6] = " and Multiple = ";
							array11[7] = Conversions.ToString(weapon2.Multiple);
							array11[8] = " and dw.ID = dwr.ComponentID;";
							string_5 = string.Concat(array11);
							dataTable18 = sQLiteHelper.ExecuteDataTable(string_5);
							int num38;
							if (!(dataTable18.Rows.Count > 0 && !flag4))
							{
								num38 = 7;
							}
							else
							{
								DataRow dataRow19 = dataTable18.Rows[0];
								int num34 = Conversions.ToInteger(dataRow19["ID"]);
								string text7 = Conversions.ToString(dataRow19["Name"]);
								dataTable15.Rows.Add(magazine.DBID, num29, num34, text7, weapon2.int_3);
								dataTable14.Rows.Add(magazine.DBID, num29, weapon2.int_3, weapon2.CurrentLoad, text7);
								flag4 = true;
								flag3 = true;
								num38 = 7;
							}
							string[] array12 = new string[num38];
							array12[0] = "select dwr.ID, dw.Name from DataWeaponRecord dwr, DataWeapon dw where dwr.ComponentID = ";
							array12[1] = Conversions.ToString(weapon2.int_3);
							array12[2] = " and MaxLoad = ";
							array12[3] = Conversions.ToString(weapon2.MaxLoad);
							array12[4] = " and Multiple = ";
							array12[5] = Conversions.ToString(weapon2.Multiple);
							array12[6] = " and dw.ID = dwr.ComponentID;";
							string_5 = string.Concat(array12);
							dataTable18 = sQLiteHelper.ExecuteDataTable(string_5);
							if (dataTable18.Rows.Count > 0 && !flag4)
							{
								DataRow dataRow20 = dataTable18.Rows[0];
								int num34 = Conversions.ToInteger(dataRow20["ID"]);
								string text7 = Conversions.ToString(dataRow20["Name"]);
								dataTable15.Rows.Add(magazine.DBID, num29, num34, text7, weapon2.int_3);
								dataTable14.Rows.Add(magazine.DBID, num29, weapon2.int_3, weapon2.CurrentLoad, text7);
								flag4 = true;
								flag3 = true;
							}
							if (!flag4 && Information.IsNothing((object)weapon2.WRecDBID) && weapon2.MaxLoad == 10000)
							{
								int num34 = 0;
								string text7 = ((!Information.IsNothing((object)weapon2.get_ReferenceWeapon(theScen))) ? weapon2.get_ReferenceWeapon(theScen).Name : "ERROR: Name not found");
								dataTable15.Rows.Add(magazine.DBID, num29, num34, text7, weapon2.int_3);
								dataTable14.Rows.Add(magazine.DBID, num29, weapon2.int_3, weapon2.CurrentLoad, text7);
								flag4 = true;
								flag3 = true;
							}
							if (!flag4)
							{
								string text5 = "WARNING: Magazine " + magazine.Name + " (ID: " + Conversions.ToString(magazine.DBID) + ") has a new weapons added to it, however a good match could not be found in the database! Weapon ID: " + Conversions.ToString(weapon2.int_3) + " Default Load: " + Conversions.ToString(weapon2.DefaultLoad) + " Max Load: " + Conversions.ToString(weapon2.MaxLoad) + " Multiple: " + Conversions.ToString(weapon2.Multiple);
								LogFileWriter = File.AppendText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR INI template log file.txt");
								LogFileWriter.Write("\r\n      " + text5);
								LogFileWriter.Close();
								ErrorCount++;
							}
						}
					}
					if (dataTable17.Rows.Count > 0)
					{
						foreach (DataRow row8 in dataTable17.Rows)
						{
							int num30 = Conversions.ToInteger(row8["ComponentID"]);
							string text7 = Conversions.ToString(row8["Name"]);
							dataTable16.Rows.Add(magazine.DBID, num29, num30, text7);
						}
						flag3 = true;
					}
					if (flag3)
					{
						dataTable13.Rows.Add(magazine.DBID, num29, magazine.Name);
					}
				}
			}
			else
			{
				if (!Information.IsNothing((object)dataTable19))
				{
					dataTable19.Rows.Clear();
				}
				if (!Information.IsNothing((object)dataTable20))
				{
					dataTable20.Rows.Clear();
				}
			}
			DataTable dataTable21 = new DataTable();
			dataTable21.Columns.Add("ComponentID", typeof(int));
			dataTable21.Columns.Add("Name", typeof(string));
			dataTable21.Columns.Add("Type", typeof(int));
			dataTable21.Columns.Add("SB1", typeof(bool));
			dataTable21.Columns.Add("SB2", typeof(bool));
			dataTable21.Columns.Add("SMF1", typeof(bool));
			dataTable21.Columns.Add("SMF2", typeof(bool));
			dataTable21.Columns.Add("SMA1", typeof(bool));
			dataTable21.Columns.Add("SMA2", typeof(bool));
			dataTable21.Columns.Add("SS1", typeof(bool));
			dataTable21.Columns.Add("SS2", typeof(bool));
			dataTable21.Columns.Add("PB1", typeof(bool));
			dataTable21.Columns.Add("PB2", typeof(bool));
			dataTable21.Columns.Add("PMF1", typeof(bool));
			dataTable21.Columns.Add("PMF2", typeof(bool));
			dataTable21.Columns.Add("PMA1", typeof(bool));
			dataTable21.Columns.Add("PMA2", typeof(bool));
			dataTable21.Columns.Add("PS1", typeof(bool));
			dataTable21.Columns.Add("PS2", typeof(bool));
			dataTable21.Columns.Add("SB1Max", typeof(bool));
			dataTable21.Columns.Add("SB2Max", typeof(bool));
			dataTable21.Columns.Add("SMF1Max", typeof(bool));
			dataTable21.Columns.Add("SMF2Max", typeof(bool));
			dataTable21.Columns.Add("SMA1Max", typeof(bool));
			dataTable21.Columns.Add("SMA2Max", typeof(bool));
			dataTable21.Columns.Add("SS1Max", typeof(bool));
			dataTable21.Columns.Add("SS2Max", typeof(bool));
			dataTable21.Columns.Add("PB1Max", typeof(bool));
			dataTable21.Columns.Add("PB2Max", typeof(bool));
			dataTable21.Columns.Add("PMF1Max", typeof(bool));
			dataTable21.Columns.Add("PMF2Max", typeof(bool));
			dataTable21.Columns.Add("PMA1Max", typeof(bool));
			dataTable21.Columns.Add("PMA2Max", typeof(bool));
			dataTable21.Columns.Add("PS1Max", typeof(bool));
			dataTable21.Columns.Add("PS2Max", typeof(bool));
			dataTable21.Columns.Add("SensorGroup", typeof(int));
			DBFunctions.PopulateSensors(activeUnit, theAU.DBID);
			Sensor[] sensors_Cached2 = activeUnit.Sensors_Cached;
			foreach (Sensor sensor5 in sensors_Cached2)
			{
				dataTable21.Rows.Add(sensor5.DBID, sensor5.Name, sensor5.Type, sensor5.Coverage.SB1, sensor5.Coverage.SB2, sensor5.Coverage.SMF1, sensor5.Coverage.SMF2, sensor5.Coverage.SMA1, sensor5.Coverage.SMA2, sensor5.Coverage.SS1, sensor5.Coverage.SS2, sensor5.Coverage.PB1, sensor5.Coverage.PB2, sensor5.Coverage.PMF1, sensor5.Coverage.PMF2, sensor5.Coverage.PMA1, sensor5.Coverage.PMA2, sensor5.Coverage.PS1, sensor5.Coverage.PS2, sensor5.Coverage_Illuminate.SB1, sensor5.Coverage_Illuminate.SB2, sensor5.Coverage_Illuminate.SMF1, sensor5.Coverage_Illuminate.SMF2, sensor5.Coverage_Illuminate.SMA1, sensor5.Coverage_Illuminate.SMA2, sensor5.Coverage_Illuminate.SS1, sensor5.Coverage_Illuminate.SS2, sensor5.Coverage_Illuminate.PB1, sensor5.Coverage_Illuminate.PB2, sensor5.Coverage_Illuminate.PMF1, sensor5.Coverage_Illuminate.PMF2, sensor5.Coverage_Illuminate.PMA1, sensor5.Coverage_Illuminate.PMA2, sensor5.Coverage_Illuminate.PS1, sensor5.Coverage_Illuminate.PS2, sensor5.IsSensorInGroup);
			}
			if (!dataTable21.Columns.Contains("SensorIndex"))
			{
				dataTable21.Columns.Add("SensorIndex", typeof(int));
			}
			int num40 = dataTable21.Rows.Count - 1;
			for (int num41 = 0; num41 <= num40; num41++)
			{
				dataTable21.Rows[num41]["SensorIndex"] = num41;
			}
			DataTable dataTable22 = new DataTable();
			dataTable22.Columns.Add("ID", typeof(int));
			dataTable22.Columns.Add("Name", typeof(string));
			dataTable22.Columns.Add("Type", typeof(int));
			dataTable22.Columns.Add("SB1", typeof(bool));
			dataTable22.Columns.Add("SB2", typeof(bool));
			dataTable22.Columns.Add("SMF1", typeof(bool));
			dataTable22.Columns.Add("SMF2", typeof(bool));
			dataTable22.Columns.Add("SMA1", typeof(bool));
			dataTable22.Columns.Add("SMA2", typeof(bool));
			dataTable22.Columns.Add("SS1", typeof(bool));
			dataTable22.Columns.Add("SS2", typeof(bool));
			dataTable22.Columns.Add("PB1", typeof(bool));
			dataTable22.Columns.Add("PB2", typeof(bool));
			dataTable22.Columns.Add("PMF1", typeof(bool));
			dataTable22.Columns.Add("PMF2", typeof(bool));
			dataTable22.Columns.Add("PMA1", typeof(bool));
			dataTable22.Columns.Add("PMA2", typeof(bool));
			dataTable22.Columns.Add("PS1", typeof(bool));
			dataTable22.Columns.Add("PS2", typeof(bool));
			dataTable22.Columns.Add("SB1Max", typeof(bool));
			dataTable22.Columns.Add("SB2Max", typeof(bool));
			dataTable22.Columns.Add("SMF1Max", typeof(bool));
			dataTable22.Columns.Add("SMF2Max", typeof(bool));
			dataTable22.Columns.Add("SMA1Max", typeof(bool));
			dataTable22.Columns.Add("SMA2Max", typeof(bool));
			dataTable22.Columns.Add("SS1Max", typeof(bool));
			dataTable22.Columns.Add("SS2Max", typeof(bool));
			dataTable22.Columns.Add("PB1Max", typeof(bool));
			dataTable22.Columns.Add("PB2Max", typeof(bool));
			dataTable22.Columns.Add("PMF1Max", typeof(bool));
			dataTable22.Columns.Add("PMF2Max", typeof(bool));
			dataTable22.Columns.Add("PMA1Max", typeof(bool));
			dataTable22.Columns.Add("PMA2Max", typeof(bool));
			dataTable22.Columns.Add("PS1Max", typeof(bool));
			dataTable22.Columns.Add("PS2Max", typeof(bool));
			dataTable22.Columns.Add("Has360Coverage", typeof(bool));
			dataTable22.Columns.Add("Has360CoverageMax", typeof(bool));
			Sensor[] sensors_Cached3 = theAU.Sensors_Cached;
			foreach (Sensor sensor6 in sensors_Cached3)
			{
				bool flag6 = false;
				foreach (DataRow row9 in dataTable21.Rows)
				{
					int num43 = Conversions.ToInteger(row9["ComponentID"]);
					if ((num43 == sensor6.DBID) & (sensor6.Coverage.SB1 == Conversions.ToBoolean(row9["SB1"])) & (sensor6.Coverage.SB2 == Conversions.ToBoolean(row9["SB2"])) & (sensor6.Coverage.SMF1 == Conversions.ToBoolean(row9["SMF1"])) & (sensor6.Coverage.SMF2 == Conversions.ToBoolean(row9["SMF2"])) & (sensor6.Coverage.SMA1 == Conversions.ToBoolean(row9["SMA1"])) & (sensor6.Coverage.SMA2 == Conversions.ToBoolean(row9["SMA2"])) & (sensor6.Coverage.SS1 == Conversions.ToBoolean(row9["SS1"])) & (sensor6.Coverage.SS2 == Conversions.ToBoolean(row9["SS2"])) & (sensor6.Coverage.PB1 == Conversions.ToBoolean(row9["PB1"])) & (sensor6.Coverage.PB2 == Conversions.ToBoolean(row9["PB2"])) & (sensor6.Coverage.PMF1 == Conversions.ToBoolean(row9["PMF1"])) & (sensor6.Coverage.PMF2 == Conversions.ToBoolean(row9["PMF2"])) & (sensor6.Coverage.PMA1 == Conversions.ToBoolean(row9["PMA1"])) & (sensor6.Coverage.PMA2 == Conversions.ToBoolean(row9["PMA2"])) & (sensor6.Coverage.PS1 == Conversions.ToBoolean(row9["PS1"])) & (sensor6.Coverage.PS2 == Conversions.ToBoolean(row9["PS2"])) & (sensor6.Coverage_Illuminate.SB1 == Conversions.ToBoolean(row9["SB1Max"])) & (sensor6.Coverage_Illuminate.SB2 == Conversions.ToBoolean(row9["SB2Max"])) & (sensor6.Coverage_Illuminate.SMF1 == Conversions.ToBoolean(row9["SMF1Max"])) & (sensor6.Coverage_Illuminate.SMF2 == Conversions.ToBoolean(row9["SMF2Max"])) & (sensor6.Coverage_Illuminate.SMA1 == Conversions.ToBoolean(row9["SMA1Max"])) & (sensor6.Coverage_Illuminate.SMA2 == Conversions.ToBoolean(row9["SMA2Max"])) & (sensor6.Coverage_Illuminate.SS1 == Conversions.ToBoolean(row9["SS1Max"])) & (sensor6.Coverage_Illuminate.SS2 == Conversions.ToBoolean(row9["SS2Max"])) & (sensor6.Coverage_Illuminate.PB1 == Conversions.ToBoolean(row9["PB1Max"])) & (sensor6.Coverage_Illuminate.PB2 == Conversions.ToBoolean(row9["PB2Max"])) & (sensor6.Coverage_Illuminate.PMF1 == Conversions.ToBoolean(row9["PMF1Max"])) & (sensor6.Coverage_Illuminate.PMF2 == Conversions.ToBoolean(row9["PMF2Max"])) & (sensor6.Coverage_Illuminate.PMA1 == Conversions.ToBoolean(row9["PMA1Max"])) & (sensor6.Coverage_Illuminate.PMA2 == Conversions.ToBoolean(row9["PMA2Max"])) & (sensor6.Coverage_Illuminate.PS1 == Conversions.ToBoolean(row9["PS1Max"])) & (sensor6.Coverage_Illuminate.PS2 == Conversions.ToBoolean(row9["PS2Max"])) & !sensor6.IsSensorInMount)
					{
						row9.Delete();
						flag6 = true;
						break;
					}
				}
				if (sensor6.IsSensorInMount)
				{
					flag6 = true;
				}
				if (flag6)
				{
					continue;
				}
				if (!flag6 & (theAU.UnitType == GlobalVariables.ActiveUnitType.Aircraft))
				{
					string_2 = "SELECT dws.ComponentID from DataWeaponSensors dws where dws.ID in (Select dw.ComponentID from DataWeaponRecord dw where dw.ID in (Select dlw.ComponentID from DataLoadoutWeapons dlw where dlw.ID in (Select dal.ComponentID from DataAircraftLoadouts dal where dal.ID = " + Conversions.ToString(theAU.DBID) + ")))";
					DataTable dataTable17 = sQLiteHelper.ExecuteDataTable(string_2);
					foreach (DataRow row10 in dataTable17.Rows)
					{
						int num44 = Conversions.ToInteger(row10["ComponentID"]);
						if (sensor6.DBID == num44)
						{
							flag6 = true;
							break;
						}
					}
				}
				if (!flag6 && dataTable4.Rows.Count > 0)
				{
					int count = dataTable4.Rows.Count;
					int num45 = count - 1;
					for (int num46 = 0; num46 <= num45; num46++)
					{
						DataRow dataRow22 = dataTable4.Rows[num46];
						int num4 = Conversions.ToInteger(dataRow22["ID"].ToString());
						string_2 = "SELECT ComponentID from DataMountSensors where  ID = " + Conversions.ToString(num4);
						DataTable dataTable17 = sQLiteHelper.ExecuteDataTable(string_2);
						foreach (DataRow row11 in dataTable17.Rows)
						{
							int num44 = Conversions.ToInteger(row11["ComponentID"]);
							if (sensor6.DBID == num44 && sensor6.IsSensorInMount)
							{
								flag6 = true;
								break;
							}
						}
					}
				}
				if (!flag6 & !sensor6.IsMk1Eyeball)
				{
					dataTable22.Rows.Add(sensor6.DBID, sensor6.Name, sensor6.Type, sensor6.Coverage.SB1, sensor6.Coverage.SB2, sensor6.Coverage.SMF1, sensor6.Coverage.SMF2, sensor6.Coverage.SMA1, sensor6.Coverage.SMA2, sensor6.Coverage.SS1, sensor6.Coverage.SS2, sensor6.Coverage.PB1, sensor6.Coverage.PB2, sensor6.Coverage.PMF1, sensor6.Coverage.PMF2, sensor6.Coverage.PMA1, sensor6.Coverage.PMA2, sensor6.Coverage.PS1, sensor6.Coverage.PS2, sensor6.Coverage_Illuminate.SB1, sensor6.Coverage_Illuminate.SB2, sensor6.Coverage_Illuminate.SMF1, sensor6.Coverage_Illuminate.SMF2, sensor6.Coverage_Illuminate.SMA1, sensor6.Coverage_Illuminate.SMA2, sensor6.Coverage_Illuminate.SS1, sensor6.Coverage_Illuminate.SS2, sensor6.Coverage_Illuminate.PB1, sensor6.Coverage_Illuminate.PB2, sensor6.Coverage_Illuminate.PMF1, sensor6.Coverage_Illuminate.PMF2, sensor6.Coverage_Illuminate.PMA1, sensor6.Coverage_Illuminate.PMA2, sensor6.Coverage_Illuminate.PS1, sensor6.Coverage_Illuminate.PS2, sensor6.Coverage.Has360Coverage.Value, sensor6.Coverage_Illuminate.Has360Coverage.Value);
				}
			}
			if (text3.Length > 0)
			{
				dataTable = new DataTable();
				dataTable.Columns.Add("ComponentID", typeof(int));
				dataTable.Columns.Add("Name", typeof(string));
				dataTable.Columns.Add("Type", typeof(int));
				dataTable.Columns.Add("SB1", typeof(bool));
				dataTable.Columns.Add("SB2", typeof(bool));
				dataTable.Columns.Add("SMF1", typeof(bool));
				dataTable.Columns.Add("SMF2", typeof(bool));
				dataTable.Columns.Add("SMA1", typeof(bool));
				dataTable.Columns.Add("SMA2", typeof(bool));
				dataTable.Columns.Add("SS1", typeof(bool));
				dataTable.Columns.Add("SS2", typeof(bool));
				dataTable.Columns.Add("PB1", typeof(bool));
				dataTable.Columns.Add("PB2", typeof(bool));
				dataTable.Columns.Add("PMF1", typeof(bool));
				dataTable.Columns.Add("PMF2", typeof(bool));
				dataTable.Columns.Add("PMA1", typeof(bool));
				dataTable.Columns.Add("PMA2", typeof(bool));
				dataTable.Columns.Add("PS1", typeof(bool));
				dataTable.Columns.Add("PS2", typeof(bool));
				dataTable.Columns.Add("SB1Max", typeof(bool));
				dataTable.Columns.Add("SB2Max", typeof(bool));
				dataTable.Columns.Add("SMF1Max", typeof(bool));
				dataTable.Columns.Add("SMF2Max", typeof(bool));
				dataTable.Columns.Add("SMA1Max", typeof(bool));
				dataTable.Columns.Add("SMA2Max", typeof(bool));
				dataTable.Columns.Add("SS1Max", typeof(bool));
				dataTable.Columns.Add("SS2Max", typeof(bool));
				dataTable.Columns.Add("PB1Max", typeof(bool));
				dataTable.Columns.Add("PB2Max", typeof(bool));
				dataTable.Columns.Add("PMF1Max", typeof(bool));
				dataTable.Columns.Add("PMF2Max", typeof(bool));
				dataTable.Columns.Add("PMA1Max", typeof(bool));
				dataTable.Columns.Add("PMA2Max", typeof(bool));
				dataTable.Columns.Add("PS1Max", typeof(bool));
				dataTable.Columns.Add("PS2Max", typeof(bool));
				dataTable.Columns.Add("SensorGroup", typeof(int));
				foreach (Sensor mineCountermeasure in activeUnit.MineCountermeasures)
				{
					dataTable.Rows.Add(mineCountermeasure.DBID, mineCountermeasure.Name, mineCountermeasure.Type, mineCountermeasure.Coverage.SB1, mineCountermeasure.Coverage.SB2, mineCountermeasure.Coverage.SMF1, mineCountermeasure.Coverage.SMF2, mineCountermeasure.Coverage.SMA1, mineCountermeasure.Coverage.SMA2, mineCountermeasure.Coverage.SS1, mineCountermeasure.Coverage.SS2, mineCountermeasure.Coverage.PB1, mineCountermeasure.Coverage.PB2, mineCountermeasure.Coverage.PMF1, mineCountermeasure.Coverage.PMF2, mineCountermeasure.Coverage.PMA1, mineCountermeasure.Coverage.PMA2, mineCountermeasure.Coverage.PS1, mineCountermeasure.Coverage.PS2, mineCountermeasure.Coverage_Illuminate.SB1, mineCountermeasure.Coverage_Illuminate.SB2, mineCountermeasure.Coverage_Illuminate.SMF1, mineCountermeasure.Coverage_Illuminate.SMF2, mineCountermeasure.Coverage_Illuminate.SMA1, mineCountermeasure.Coverage_Illuminate.SMA2, mineCountermeasure.Coverage_Illuminate.SS1, mineCountermeasure.Coverage_Illuminate.SS2, mineCountermeasure.Coverage_Illuminate.PB1, mineCountermeasure.Coverage_Illuminate.PB2, mineCountermeasure.Coverage_Illuminate.PMF1, mineCountermeasure.Coverage_Illuminate.PMF2, mineCountermeasure.Coverage_Illuminate.PMA1, mineCountermeasure.Coverage_Illuminate.PMA2, mineCountermeasure.Coverage_Illuminate.PS1, mineCountermeasure.Coverage_Illuminate.PS2, mineCountermeasure.IsSensorInGroup);
				}
				if (!dataTable.Columns.Contains("SensorIndex"))
				{
					dataTable.Columns.Add("SensorIndex", typeof(int));
				}
				int num47 = dataTable.Rows.Count - 1;
				for (int num48 = 0; num48 <= num47; num48++)
				{
					dataTable.Rows[num48]["SensorIndex"] = num48;
				}
				foreach (Sensor mineCountermeasure2 in theAU.MineCountermeasures)
				{
					bool flag6 = false;
					foreach (DataRow row12 in dataTable.Rows)
					{
						int num43 = Conversions.ToInteger(row12["ComponentID"]);
						if ((num43 == mineCountermeasure2.DBID) & (mineCountermeasure2.Coverage.SB1 == Conversions.ToBoolean(row12["SB1"])) & (mineCountermeasure2.Coverage.SB2 == Conversions.ToBoolean(row12["SB2"])) & (mineCountermeasure2.Coverage.SMF1 == Conversions.ToBoolean(row12["SMF1"])) & (mineCountermeasure2.Coverage.SMF2 == Conversions.ToBoolean(row12["SMF2"])) & (mineCountermeasure2.Coverage.SMA1 == Conversions.ToBoolean(row12["SMA1"])) & (mineCountermeasure2.Coverage.SMA2 == Conversions.ToBoolean(row12["SMA2"])) & (mineCountermeasure2.Coverage.SS1 == Conversions.ToBoolean(row12["SS1"])) & (mineCountermeasure2.Coverage.SS2 == Conversions.ToBoolean(row12["SS2"])) & (mineCountermeasure2.Coverage.PB1 == Conversions.ToBoolean(row12["PB1"])) & (mineCountermeasure2.Coverage.PB2 == Conversions.ToBoolean(row12["PB2"])) & (mineCountermeasure2.Coverage.PMF1 == Conversions.ToBoolean(row12["PMF1"])) & (mineCountermeasure2.Coverage.PMF2 == Conversions.ToBoolean(row12["PMF2"])) & (mineCountermeasure2.Coverage.PMA1 == Conversions.ToBoolean(row12["PMA1"])) & (mineCountermeasure2.Coverage.PMA2 == Conversions.ToBoolean(row12["PMA2"])) & (mineCountermeasure2.Coverage.PS1 == Conversions.ToBoolean(row12["PS1"])) & (mineCountermeasure2.Coverage.PS2 == Conversions.ToBoolean(row12["PS2"])) & (mineCountermeasure2.Coverage_Illuminate.SB1 == Conversions.ToBoolean(row12["SB1Max"])) & (mineCountermeasure2.Coverage_Illuminate.SB2 == Conversions.ToBoolean(row12["SB2Max"])) & (mineCountermeasure2.Coverage_Illuminate.SMF1 == Conversions.ToBoolean(row12["SMF1Max"])) & (mineCountermeasure2.Coverage_Illuminate.SMF2 == Conversions.ToBoolean(row12["SMF2Max"])) & (mineCountermeasure2.Coverage_Illuminate.SMA1 == Conversions.ToBoolean(row12["SMA1Max"])) & (mineCountermeasure2.Coverage_Illuminate.SMA2 == Conversions.ToBoolean(row12["SMA2Max"])) & (mineCountermeasure2.Coverage_Illuminate.SS1 == Conversions.ToBoolean(row12["SS1Max"])) & (mineCountermeasure2.Coverage_Illuminate.SS2 == Conversions.ToBoolean(row12["SS2Max"])) & (mineCountermeasure2.Coverage_Illuminate.PB1 == Conversions.ToBoolean(row12["PB1Max"])) & (mineCountermeasure2.Coverage_Illuminate.PB2 == Conversions.ToBoolean(row12["PB2Max"])) & (mineCountermeasure2.Coverage_Illuminate.PMF1 == Conversions.ToBoolean(row12["PMF1Max"])) & (mineCountermeasure2.Coverage_Illuminate.PMF2 == Conversions.ToBoolean(row12["PMF2Max"])) & (mineCountermeasure2.Coverage_Illuminate.PMA1 == Conversions.ToBoolean(row12["PMA1Max"])) & (mineCountermeasure2.Coverage_Illuminate.PMA2 == Conversions.ToBoolean(row12["PMA2Max"])) & (mineCountermeasure2.Coverage_Illuminate.PS1 == Conversions.ToBoolean(row12["PS1Max"])) & (mineCountermeasure2.Coverage_Illuminate.PS2 == Conversions.ToBoolean(row12["PS2Max"])))
						{
							row12.Delete();
							flag6 = true;
							break;
						}
					}
					if (mineCountermeasure2.IsSensorInMount)
					{
						flag6 = true;
					}
					if (flag6)
					{
						continue;
					}
					if (!flag6 & (theAU.UnitType == GlobalVariables.ActiveUnitType.Aircraft))
					{
						string_2 = "SELECT dws.ComponentID from DataWeaponSensors dws where dws.ID in (Select dw.ComponentID from DataWeaponRecord dw where dw.ID in (Select dlw.ComponentID from DataLoadoutWeapons dlw where dlw.ID in (Select dal.ComponentID from DataAircraftLoadouts dal where dal.ID = " + Conversions.ToString(theAU.DBID) + ")))";
						DataTable dataTable17 = sQLiteHelper.ExecuteDataTable(string_2);
						foreach (DataRow row13 in dataTable17.Rows)
						{
							int num44 = Conversions.ToInteger(row13["ComponentID"]);
							if (mineCountermeasure2.DBID == num44)
							{
								flag6 = true;
								break;
							}
						}
					}
					if (!flag6 && dataTable4.Rows.Count > 0)
					{
						int count = dataTable4.Rows.Count;
						int num49 = count - 1;
						for (int num50 = 0; num50 <= num49; num50++)
						{
							DataRow dataRow22 = dataTable4.Rows[num50];
							int num4 = Conversions.ToInteger(dataRow22["ID"].ToString());
							string_2 = "SELECT ComponentID from DataMountSensors where  ID = " + Conversions.ToString(num4);
							DataTable dataTable17 = sQLiteHelper.ExecuteDataTable(string_2);
							foreach (DataRow row14 in dataTable17.Rows)
							{
								int num44 = Conversions.ToInteger(row14["ComponentID"]);
								if (mineCountermeasure2.DBID == num44)
								{
									flag6 = true;
									break;
								}
							}
						}
					}
					if (!flag6)
					{
						dataTable22.Rows.Add(mineCountermeasure2.DBID, mineCountermeasure2.Name, mineCountermeasure2.Type, mineCountermeasure2.Coverage.SB1, mineCountermeasure2.Coverage.SB2, mineCountermeasure2.Coverage.SMF1, mineCountermeasure2.Coverage.SMF2, mineCountermeasure2.Coverage.SMA1, mineCountermeasure2.Coverage.SMA2, mineCountermeasure2.Coverage.SS1, mineCountermeasure2.Coverage.SS2, mineCountermeasure2.Coverage.PB1, mineCountermeasure2.Coverage.PB2, mineCountermeasure2.Coverage.PMF1, mineCountermeasure2.Coverage.PMF2, mineCountermeasure2.Coverage.PMA1, mineCountermeasure2.Coverage.PMA2, mineCountermeasure2.Coverage.PS1, mineCountermeasure2.Coverage.PS2, mineCountermeasure2.Coverage_Illuminate.SB1, mineCountermeasure2.Coverage_Illuminate.SB2, mineCountermeasure2.Coverage_Illuminate.SMF1, mineCountermeasure2.Coverage_Illuminate.SMF2, mineCountermeasure2.Coverage_Illuminate.SMA1, mineCountermeasure2.Coverage_Illuminate.SMA2, mineCountermeasure2.Coverage_Illuminate.SS1, mineCountermeasure2.Coverage_Illuminate.SS2, mineCountermeasure2.Coverage_Illuminate.PB1, mineCountermeasure2.Coverage_Illuminate.PB2, mineCountermeasure2.Coverage_Illuminate.PMF1, mineCountermeasure2.Coverage_Illuminate.PMF2, mineCountermeasure2.Coverage_Illuminate.PMA1, mineCountermeasure2.Coverage_Illuminate.PMA2, mineCountermeasure2.Coverage_Illuminate.PS1, mineCountermeasure2.Coverage_Illuminate.PS2, mineCountermeasure2.Coverage.Has360Coverage, mineCountermeasure2.Coverage_Illuminate.Has360Coverage.Value);
					}
				}
			}
			DataTable dataTable23 = sQLiteHelper.ExecuteDataTable(string_4);
			if (!dataTable23.Columns.Contains("CommIndex"))
			{
				dataTable23.Columns.Add("CommIndex", typeof(int));
			}
			int num51 = dataTable23.Rows.Count - 1;
			for (int num52 = 0; num52 <= num51; num52++)
			{
				dataTable23.Rows[num52]["CommIndex"] = num52;
			}
			DataTable dataTable24 = new DataTable();
			dataTable24.Columns.Add("ID", typeof(int));
			dataTable24.Columns.Add("Name", typeof(string));
			CommDevice[] comms_ReadOnly = theAU.Comms_ReadOnly;
			foreach (CommDevice commDevice in comms_ReadOnly)
			{
				bool flag7 = false;
				foreach (DataRow row15 in dataTable23.Rows)
				{
					int num54 = Conversions.ToInteger(row15["ComponentID"]);
					if (num54 == commDevice.DBID && !commDevice.IsCommsInMount)
					{
						row15.Delete();
						flag7 = true;
						break;
					}
				}
				if (commDevice.IsCommsInMount)
				{
					flag7 = true;
				}
				if (!flag7)
				{
					switch (theAU.UnitType)
					{
					case GlobalVariables.ActiveUnitType.Aircraft:
						string_2 = "SELECT ComponentID from DataMountComms where  ID in (Select ComponentID from DataAircraftMounts where ID = " + Conversions.ToString(theAU.DBID) + ")";
						break;
					case GlobalVariables.ActiveUnitType.Ship:
						string_2 = "SELECT ComponentID from DataMountComms where  ID in (Select ComponentID from DataShipMounts where ID = " + Conversions.ToString(theAU.DBID) + ")";
						break;
					case GlobalVariables.ActiveUnitType.Submarine:
						string_2 = "SELECT ComponentID from DataMountComms where  ID in (Select ComponentID from DataSubmarineMounts where ID = " + Conversions.ToString(theAU.DBID) + ")";
						break;
					case GlobalVariables.ActiveUnitType.Facility:
						string_2 = "SELECT ComponentID from DataMountComms where  ID in (Select ComponentID from DataFacilityMounts where ID = " + Conversions.ToString(theAU.DBID) + ")";
						break;
					case GlobalVariables.ActiveUnitType.Satellite:
						string_2 = "SELECT ComponentID from DataMountComms where  ID in (Select ComponentID from DataSatelliteMounts where ID = " + Conversions.ToString(theAU.DBID) + ")";
						break;
					case GlobalVariables.ActiveUnitType.Vehicle:
						string_2 = "SELECT ComponentID from DataMountComms where  ID in (Select ComponentID from DataGroundUnitSensors where ID = " + Conversions.ToString(theAU.DBID) + ")";
						break;
					}
					DataTable dataTable17 = sQLiteHelper.ExecuteDataTable(string_2);
					foreach (DataRow row16 in dataTable17.Rows)
					{
						int num54 = Conversions.ToInteger(row16["ComponentID"]);
						if (commDevice.DBID == num54 && commDevice.IsCommsInMount)
						{
							flag7 = true;
							break;
						}
					}
				}
				if (!flag7)
				{
					dataTable24.Rows.Add(commDevice.DBID, commDevice.Name);
				}
			}
			DataTable dataTable25 = new DataTable();
			dataTable25.Columns.Add("ID", typeof(int));
			dataTable25.Columns.Add("Name", typeof(string));
			DataTable dataTable26 = new DataTable();
			dataTable26.Columns.Add("ID", typeof(int));
			dataTable26.Columns.Add("Name", typeof(string));
			DataTable dataTable27 = new DataTable();
			DataTable dataTable28 = new DataTable();
			if (text2.Length > 0)
			{
				dataTable27 = sQLiteHelper.ExecuteDataTable(text2);
			}
			if (!dataTable27.Columns.Contains("FacilityIndex"))
			{
				dataTable27.Columns.Add("FacilityIndex", typeof(int));
			}
			int num55 = dataTable27.Rows.Count - 1;
			for (int num56 = 0; num56 <= num55; num56++)
			{
				dataTable27.Rows[num56]["FacilityIndex"] = num56;
			}
			if (theAU.DockFacilities_ReadOnly.Length > 0)
			{
				DockFacility[] dockFacilities_ReadOnly = theAU.DockFacilities_ReadOnly;
				foreach (DockFacility dockFacility in dockFacilities_ReadOnly)
				{
					bool flag8 = false;
					foreach (DataRow row17 in dataTable27.Rows)
					{
						if (Conversions.ToInteger(row17["ComponentID"].ToString()) == dockFacility.DBID)
						{
							row17.Delete();
							flag8 = true;
							break;
						}
					}
					if (!flag8)
					{
						dataTable25.Rows.Add(dockFacility.DBID, dockFacility.Name);
					}
				}
			}
			if (dataTable27.Rows.Count > 0)
			{
				if (!dataTable27.Columns.Contains("Name"))
				{
					dataTable27.Columns.Add("Name", typeof(string));
				}
				int num58 = dataTable27.Rows.Count - 1;
				for (int num59 = 0; num59 <= num58; num59++)
				{
					int facilityDBID = Conversions.ToInteger(dataTable27.Rows[num59]["ComponentID"].ToString());
					SQLiteConnection sqliteConnection_ = theScen.DBConnection;
					DockFacility dockFacility2 = DBFunctions.GetDockFacility(facilityDBID, ref sqliteConnection_);
					dataTable27.Rows[num59]["Name"] = dockFacility2.Name;
				}
			}
			if (text.Length > 0)
			{
				dataTable28 = sQLiteHelper.ExecuteDataTable(text);
			}
			if (!dataTable28.Columns.Contains("FacilityIndex"))
			{
				dataTable28.Columns.Add("FacilityIndex", typeof(int));
			}
			int num60 = dataTable28.Rows.Count - 1;
			for (int num61 = 0; num61 <= num60; num61++)
			{
				dataTable28.Rows[num61]["FacilityIndex"] = num61;
			}
			if (theAU.AirFacilities_ReadOnly.Length > 0)
			{
				AirFacility[] airFacilities_ReadOnly = theAU.AirFacilities_ReadOnly;
				foreach (AirFacility airFacility in airFacilities_ReadOnly)
				{
					bool flag9 = false;
					foreach (DataRow row18 in dataTable28.Rows)
					{
						if (Conversions.ToInteger(row18["ComponentID"].ToString()) == airFacility.DBID)
						{
							row18.Delete();
							flag9 = true;
							break;
						}
					}
					if (!flag9)
					{
						dataTable26.Rows.Add(airFacility.DBID, airFacility.Name);
					}
				}
			}
			if (dataTable28.Rows.Count > 0)
			{
				if (!dataTable28.Columns.Contains("Name"))
				{
					dataTable28.Columns.Add("Name", typeof(string));
				}
				int num63 = dataTable28.Rows.Count - 1;
				for (int num64 = 0; num64 <= num63; num64++)
				{
					int facilityDBID2 = Conversions.ToInteger(dataTable28.Rows[num64]["ComponentID"].ToString());
					SQLiteConnection sqliteConnection_ = theScen.DBConnection;
					AirFacility airFacility2 = DBFunctions.GetAirFacility(facilityDBID2, ref sqliteConnection_);
					dataTable28.Rows[num64]["Name"] = airFacility2.Name;
				}
			}
			DataTable dataTable29 = new DataTable();
			dataTable29.Columns.Add("ID", typeof(string));
			dataTable29.Columns.Add("Type", typeof(string));
			dataTable29.Columns.Add("Status", typeof(int));
			dataTable29.Columns.Add("DamageSeverity", typeof(int));
			dataTable29.Columns.Add("Name", typeof(string));
			if (theAU.get_DamagePts(ScenEditAction: false, (Weapon)null) != (float)theAU.InitialDP)
			{
				dataTable29.Rows.Add("", "DamagePts", theAU.get_DamagePts(ScenEditAction: false, (Weapon)null));
			}
			if ((int)theAU.Damage.FireIntensity > 0)
			{
				dataTable29.Rows.Add("", "Fire", (byte)theAU.Damage.FireIntensity);
			}
			if ((int)theAU.Damage.FloodIntensity > 0)
			{
				dataTable29.Rows.Add("", "Flood", (byte)theAU.Damage.FloodIntensity);
			}
			switch (theAU.UnitType)
			{
			case GlobalVariables.ActiveUnitType.Ship:
			{
				Ship ship = (Ship)theAU;
				if (ship.CIC.Status != PlatformComponent._ComponentStatus.Operational || ship.CIC.DamageSeverity != PlatformComponent._DamageSeverityFactor.Light)
				{
					dataTable29.Rows.Add("", "CIC", (byte)ship.CIC.Status, (byte)ship.CIC.DamageSeverity);
				}
				if (ship.Rudder.Status != PlatformComponent._ComponentStatus.Operational || ship.Rudder.DamageSeverity != PlatformComponent._DamageSeverityFactor.Light)
				{
					dataTable29.Rows.Add("", "Rudder", (byte)ship.Rudder.Status, (byte)ship.Rudder.DamageSeverity);
				}
				break;
			}
			case GlobalVariables.ActiveUnitType.Submarine:
			{
				Submarine submarine = (Submarine)theAU;
				if (submarine.CIC.Status != PlatformComponent._ComponentStatus.Operational || submarine.CIC.DamageSeverity != PlatformComponent._DamageSeverityFactor.Light)
				{
					dataTable29.Rows.Add("", "CIC", (byte)submarine.CIC.Status, (byte)submarine.CIC.DamageSeverity);
				}
				if (submarine.Rudder.Status != PlatformComponent._ComponentStatus.Operational || submarine.Rudder.DamageSeverity != PlatformComponent._DamageSeverityFactor.Light)
				{
					dataTable29.Rows.Add("", "Rudder", (byte)submarine.Rudder.Status, (byte)submarine.Rudder.DamageSeverity);
				}
				if (submarine.PressureHull.Status != PlatformComponent._ComponentStatus.Operational || submarine.PressureHull.DamageSeverity != PlatformComponent._DamageSeverityFactor.Light)
				{
					dataTable29.Rows.Add("", "PressureHull", (byte)submarine.PressureHull.Status, (byte)submarine.PressureHull.DamageSeverity);
				}
				if (submarine.Cargo.Status != PlatformComponent._ComponentStatus.Operational || submarine.Cargo.DamageSeverity != PlatformComponent._DamageSeverityFactor.Light)
				{
					dataTable29.Rows.Add("", "Cargo", (byte)submarine.Cargo.Status, (byte)submarine.Cargo.DamageSeverity);
				}
				break;
			}
			case GlobalVariables.ActiveUnitType.Facility:
			{
				Facility facility = (Facility)theAU;
				if (facility.CIC.Status != PlatformComponent._ComponentStatus.Operational || facility.CIC.DamageSeverity != PlatformComponent._DamageSeverityFactor.Light)
				{
					dataTable29.Rows.Add("", "CIC", (byte)facility.CIC.Status, (byte)facility.CIC.DamageSeverity);
				}
				if (facility.Cargo.Status != PlatformComponent._ComponentStatus.Operational || facility.Cargo.DamageSeverity != PlatformComponent._DamageSeverityFactor.Light)
				{
					dataTable29.Rows.Add("", "Cargo", (byte)facility.Cargo.Status, (byte)facility.Cargo.DamageSeverity);
				}
				break;
			}
			}
			Sensor[] sensors_Cached4 = theAU.Sensors_Cached;
			foreach (Sensor sensor7 in sensors_Cached4)
			{
				if (sensor7.Status != PlatformComponent._ComponentStatus.Operational || sensor7.DamageSeverity != PlatformComponent._DamageSeverityFactor.Light)
				{
					dataTable29.Rows.Add(sensor7.ObjectID, "Sensor", (byte)sensor7.Status, (byte)sensor7.DamageSeverity, sensor7.Name);
				}
			}
			CommDevice[] comms_ReadOnly2 = theAU.Comms_ReadOnly;
			foreach (CommDevice commDevice2 in comms_ReadOnly2)
			{
				if (commDevice2.Status != PlatformComponent._ComponentStatus.Operational || commDevice2.DamageSeverity != PlatformComponent._DamageSeverityFactor.Light)
				{
					dataTable29.Rows.Add(commDevice2.ObjectID, "Comm", (byte)commDevice2.Status, (byte)commDevice2.DamageSeverity, commDevice2.Name);
				}
			}
			foreach (Engine item in theAU.Propulsion)
			{
				if (item.Status != PlatformComponent._ComponentStatus.Operational || item.DamageSeverity != PlatformComponent._DamageSeverityFactor.Light)
				{
					dataTable29.Rows.Add(item.ObjectID, "Engine", (byte)item.Status, (byte)item.DamageSeverity, item.Name);
				}
			}
			foreach (Mount mount2 in theAU.Mounts)
			{
				if (mount2.Status != PlatformComponent._ComponentStatus.Operational || mount2.DamageSeverity != PlatformComponent._DamageSeverityFactor.Light)
				{
					dataTable29.Rows.Add(mount2.ObjectID, "Mount", (byte)mount2.Status, (byte)mount2.DamageSeverity, mount2.Name);
				}
			}
			Magazine[] sharedMagazines2 = theAU.SharedMagazines;
			foreach (Magazine magazine2 in sharedMagazines2)
			{
				if (magazine2.Status != PlatformComponent._ComponentStatus.Operational || magazine2.DamageSeverity != PlatformComponent._DamageSeverityFactor.Light)
				{
					dataTable29.Rows.Add(magazine2.ObjectID, "Mag", (byte)magazine2.Status, (byte)magazine2.DamageSeverity, magazine2.Name);
				}
			}
			Cargo[] onboardCargo = theAU.OnboardCargo;
			foreach (Cargo cargo in onboardCargo)
			{
				if (cargo.Status != PlatformComponent._ComponentStatus.Operational || cargo.DamageSeverity != PlatformComponent._DamageSeverityFactor.Light)
				{
					dataTable29.Rows.Add(cargo.ObjectID, "Cargo", (byte)cargo.Status, (byte)cargo.DamageSeverity, cargo.Name);
				}
			}
			AirFacility[] airFacilities_ReadOnly2 = theAU.AirFacilities_ReadOnly;
			foreach (AirFacility airFacility3 in airFacilities_ReadOnly2)
			{
				if (airFacility3.Status != PlatformComponent._ComponentStatus.Operational || airFacility3.DamageSeverity != PlatformComponent._DamageSeverityFactor.Light)
				{
					dataTable29.Rows.Add(airFacility3.ObjectID, "AirFacility", (byte)airFacility3.Status, (byte)airFacility3.DamageSeverity, airFacility3.Name);
				}
			}
			DockFacility[] dockFacilities_ReadOnly2 = theAU.DockFacilities_ReadOnly;
			foreach (DockFacility dockFacility3 in dockFacilities_ReadOnly2)
			{
				if (dockFacility3.Status != PlatformComponent._ComponentStatus.Operational || dockFacility3.DamageSeverity != PlatformComponent._DamageSeverityFactor.Light)
				{
					dataTable29.Rows.Add(dockFacility3.ObjectID, "DockFacility", (byte)dockFacility3.Status, (byte)dockFacility3.DamageSeverity, dockFacility3.Name);
				}
			}
			bool flag10 = false;
			if (num24 > 0)
			{
				goto IL_7122;
			}
			int num71;
			if (flag)
			{
				num71 = 1;
			}
			else
			{
				if (dataTable2.Rows.Count > 0)
				{
					goto IL_7122;
				}
				if (dataTable29.Rows.Count <= 0)
				{
					int num75;
					if (dataTable3.Rows.Count <= 0 && dataTable4.Rows.Count <= 0 && (Information.IsNothing((object)dataTable19) || dataTable19.Rows.Count <= 0))
					{
						if (Information.IsNothing((object)dataTable20) || dataTable20.Rows.Count <= 0)
						{
							int num74;
							if (dataTable.Rows.Count <= 0 && dataTable21.Rows.Count <= 0 && dataTable22.Rows.Count <= 0 && dataTable23.Rows.Count <= 0)
							{
								if (dataTable24.Rows.Count <= 0)
								{
									int num73;
									if (dataTable8.Rows.Count <= 0 && dataTable7.Rows.Count <= 0 && dataTable6.Rows.Count <= 0 && dataTable11.Rows.Count <= 0 && dataTable10.Rows.Count <= 0 && dataTable9.Rows.Count <= 0 && dataTable16.Rows.Count <= 0 && dataTable15.Rows.Count <= 0)
									{
										if (dataTable14.Rows.Count <= 0)
										{
											int num72;
											if (dataTable27.Rows.Count <= 0 && dataTable25.Rows.Count <= 0 && dataTable28.Rows.Count <= 0)
											{
												if (dataTable26.Rows.Count <= 0)
												{
													if (dataTable12.Rows.Count > 0)
													{
														flag10 = true;
													}
													goto IL_7125;
												}
												num72 = 1;
											}
											else
											{
												num72 = 1;
											}
											flag10 = (byte)num72 != 0;
											goto IL_7125;
										}
										num73 = 1;
									}
									else
									{
										num73 = 1;
									}
									flag10 = (byte)num73 != 0;
									goto IL_7125;
								}
								num74 = 1;
							}
							else
							{
								num74 = 1;
							}
							flag10 = (byte)num74 != 0;
							goto IL_7125;
						}
						num75 = 1;
					}
					else
					{
						num75 = 1;
					}
					flag10 = (byte)num75 != 0;
					goto IL_7125;
				}
				num71 = 1;
			}
			goto IL_7123;
			IL_7122:
			num71 = 1;
			goto IL_7123;
			IL_7123:
			flag10 = (byte)num71 != 0;
			goto IL_7125;
			IL_7125:
			if (!flag10)
			{
				return;
			}
			DeltaWriter.WriteStartElement("Unit_" + theAU.ObjectID);
			DeltaWriter.WriteComment(theAU.Name + " (" + theAU.UnitClass + " [" + Conversions.ToString(theAU.DBID) + "])");
			Cargo[] onboardCargo2 = theAU.OnboardCargo;
			foreach (Cargo cargo2 in onboardCargo2)
			{
				DeltaWriter.WriteStartElement("CargoAdd");
				DeltaWriter.WriteRaw(cargo2.ToXML(null, theAU.ParentScen));
				DeltaWriter.WriteEndElement();
			}
			if (flag)
			{
				if (theAU.IsAircraft)
				{
					float num77 = ((Aircraft)theAU).FuelCapacityCurrent;
					DeltaWriter.WriteStartElement("SetFuel_" + Conversions.ToString(num77));
					DeltaWriter.WriteEndElement();
				}
				else if (!theAU.IsFacility && (theAU.IsShip || theAU.IsSubmarine))
				{
					foreach (FuelRec item2 in theAU.Fuel_ReadOnly)
					{
						if (item2.CurrentQuantity < (float)item2.MaxQuantity)
						{
							DeltaWriter.WriteStartElement("SetFuel_" + Conversions.ToString((int)item2.FuelType) + "_" + item2.CurrentQuantity.ToString("F3", CultureInfo.InvariantCulture));
							DeltaWriter.WriteEndElement();
						}
					}
				}
			}
			if (dataTable4.Rows.Count > 0)
			{
				int count = dataTable4.Rows.Count;
				int num78 = count - 1;
				for (int num79 = 0; num79 <= num78; num79++)
				{
					DataRow dataRow22 = dataTable4.Rows[num79];
					int num4 = Conversions.ToInteger(dataRow22["ID"].ToString());
					string text8 = Conversions.ToString(dataRow22["Name"]);
					DeltaWriter.WriteStartElement("MountAdd_" + Conversions.ToString(num4));
					DeltaWriter.WriteComment(text8);
					string text5 = smethod_0(DeltaWriter, bool_0: false, dataRow22, theAU, text8);
					if (Operators.CompareString(text5, "", false) != 0)
					{
						LogFileWriter = File.AppendText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR INI template log file.txt");
						LogFileWriter.Write("\r\n      " + text5);
						LogFileWriter.Close();
						ErrorCount++;
					}
				}
			}
			if (dataTable5.Rows.Count > 0)
			{
				int count = dataTable5.Rows.Count;
				int num80 = count - 1;
				for (int num81 = 0; num81 <= num80; num81++)
				{
					DataRow dataRow22 = dataTable5.Rows[num81];
					int num4 = Conversions.ToInteger(dataRow22["MountID"].ToString());
					num5 = Conversions.ToInteger(dataRow22["MountIndex"].ToString());
					string text8 = Conversions.ToString(dataRow22["MountName"]);
					DeltaWriter.WriteStartElement("Mount_" + Conversions.ToString(num5 + 1) + "_" + Conversions.ToString(num4));
					DeltaWriter.WriteComment(text8);
					if (dataTable8.Rows.Count > 0)
					{
						int num82 = dataTable8.Rows.Count - 1;
						for (int num83 = 0; num83 <= num82; num83++)
						{
							dataRow22 = dataTable8.Rows[num83];
							int num84 = Conversions.ToInteger(dataRow22["MountID"].ToString());
							int num85 = Conversions.ToInteger(dataRow22["MountIndex"].ToString());
							int num6 = Conversions.ToInteger(dataRow22["WeaponID"].ToString());
							string text4 = Conversions.ToString(dataRow22["WeaponName"]);
							if (num84 == num4 && num85 == num5)
							{
								DeltaWriter.WriteStartElement("WeaponRemove_" + Conversions.ToString(num6));
								DeltaWriter.WriteEndElement();
								DeltaWriter.WriteComment(text4);
							}
						}
					}
					if (dataTable7.Rows.Count > 0)
					{
						int num86 = dataTable7.Rows.Count - 1;
						for (int num87 = 0; num87 <= num86; num87++)
						{
							dataRow22 = dataTable7.Rows[num87];
							int num88 = Conversions.ToInteger(dataRow22["MountID"].ToString());
							int num85 = Conversions.ToInteger(dataRow22["MountIndex"].ToString());
							int num10 = Conversions.ToInteger(dataRow22["WeapRecID"].ToString());
							string text4 = Conversions.ToString(dataRow22["WeaponName"]);
							int num6 = Conversions.ToInteger(dataRow22["WeaponID"].ToString());
							if (num88 == num4 && num85 == num5)
							{
								DeltaWriter.WriteStartElement("WeaponRecAdd_" + Conversions.ToString(num10) + "_" + Conversions.ToString(num6));
								DeltaWriter.WriteEndElement();
								DeltaWriter.WriteComment(text4);
							}
						}
					}
					if (dataTable6.Rows.Count > 0)
					{
						int num89 = dataTable6.Rows.Count - 1;
						for (int num90 = 0; num90 <= num89; num90++)
						{
							dataRow22 = dataTable6.Rows[num90];
							int num91 = Conversions.ToInteger(dataRow22["MountID"].ToString());
							int num85 = Conversions.ToInteger(dataRow22["MountIndex"].ToString());
							int num6 = Conversions.ToInteger(dataRow22["WeaponID"].ToString());
							int num7 = Conversions.ToInteger(dataRow22["WeaponQty"].ToString());
							string text4 = Conversions.ToString(dataRow22["WeaponName"]);
							if (num91 == num4 && num85 == num5)
							{
								DeltaWriter.WriteStartElement("WeaponEdit_" + Conversions.ToString(num6) + "_" + Conversions.ToString(num7));
								DeltaWriter.WriteEndElement();
								DeltaWriter.WriteComment(text4);
							}
						}
					}
					if ((dataTable11.Rows.Count > 0) | (dataTable10.Rows.Count > 0) | (dataTable9.Rows.Count > 0))
					{
						DeltaWriter.WriteStartElement("MountMag");
						if (dataTable11.Rows.Count > 0)
						{
							int num92 = dataTable11.Rows.Count - 1;
							for (int num93 = 0; num93 <= num92; num93++)
							{
								DataRow dataRow27 = dataTable11.Rows[num93];
								int num94 = Conversions.ToInteger(dataRow27["MountID"].ToString());
								int num95 = Conversions.ToInteger(dataRow27["MountIndex"].ToString());
								int num15 = Conversions.ToInteger(dataRow27["WeaponID"].ToString());
								string text6 = Conversions.ToString(dataRow27["WeaponName"]);
								if (num94 == num4 && num95 == num5)
								{
									DeltaWriter.WriteStartElement("WeaponRemove_" + Conversions.ToString(num15));
									DeltaWriter.WriteEndElement();
									DeltaWriter.WriteComment(text6);
								}
							}
						}
						if (dataTable10.Rows.Count > 0)
						{
							int num96 = dataTable10.Rows.Count - 1;
							for (int num97 = 0; num97 <= num96; num97++)
							{
								DataRow dataRow28 = dataTable10.Rows[num97];
								int num94 = Conversions.ToInteger(dataRow28["MountID"].ToString());
								int num95 = Conversions.ToInteger(dataRow28["MountIndex"].ToString());
								int num19 = Conversions.ToInteger(dataRow28["WeapRecID"].ToString());
								string text6 = Conversions.ToString(dataRow28["WeaponName"]);
								int num15 = Conversions.ToInteger(dataRow28["WeaponID"].ToString());
								if (num94 == num4 && num95 == num5)
								{
									DeltaWriter.WriteStartElement("WeaponRecAdd_" + Conversions.ToString(num19) + "_" + Conversions.ToString(num15));
									DeltaWriter.WriteEndElement();
									DeltaWriter.WriteComment(text6);
								}
							}
						}
						if (dataTable9.Rows.Count > 0)
						{
							int num98 = dataTable9.Rows.Count - 1;
							for (int num99 = 0; num99 <= num98; num99++)
							{
								DataRow dataRow29 = dataTable9.Rows[num99];
								int num94 = Conversions.ToInteger(dataRow29["MountID"].ToString());
								int num95 = Conversions.ToInteger(dataRow29["MountIndex"].ToString());
								int num15 = Conversions.ToInteger(dataRow29["WeaponID"].ToString());
								int num16 = Conversions.ToInteger(dataRow29["WeaponQty"].ToString());
								string text6 = Conversions.ToString(dataRow29["WeaponName"]);
								if (num94 == num4 && num95 == num5)
								{
									DeltaWriter.WriteStartElement("WeaponEdit_" + Conversions.ToString(num15) + "_" + Conversions.ToString(num16));
									DeltaWriter.WriteEndElement();
									DeltaWriter.WriteComment(text6);
								}
							}
						}
						DeltaWriter.WriteEndElement();
					}
					DeltaWriter.WriteEndElement();
				}
			}
			if (dataTable3.Rows.Count > 0)
			{
				int count = dataTable3.Rows.Count;
				int num100 = count - 1;
				for (int num101 = 0; num101 <= num100; num101++)
				{
					DataRow dataRow22 = dataTable3.Rows[count - 1 - num101];
					int num4 = Conversions.ToInteger(dataRow22["ComponentID"].ToString());
					string text8 = Conversions.ToString(dataRow22["Name"]);
					num5 = Conversions.ToInteger(dataRow22["MountIndex"].ToString());
					DeltaWriter.WriteStartElement("MountRemove_" + Conversions.ToString(num5 + 1) + "_" + Conversions.ToString(num4));
					DeltaWriter.WriteEndElement();
					DeltaWriter.WriteComment(text8);
				}
			}
			if (theAU.IsFacility | theAU.IsShip | theAU.IsSubmarine | theAU.IsVehicle)
			{
				if (dataTable19.Rows.Count > 0)
				{
					int count = dataTable19.Rows.Count;
					int num102 = count - 1;
					for (int num103 = 0; num103 <= num102; num103++)
					{
						DataRow dataRow30 = dataTable19.Rows[count - 1 - num103];
						int num28 = Conversions.ToInteger(dataRow30["ComponentID"].ToString());
						string text9 = Conversions.ToString(dataRow30["Name"]);
						int num29 = Conversions.ToInteger(dataRow30["MagIndex"].ToString());
						DeltaWriter.WriteStartElement("MagRemove_" + Conversions.ToString(num29 + 1) + "_" + Conversions.ToString(num28));
						DeltaWriter.WriteEndElement();
						DeltaWriter.WriteComment(text9);
					}
				}
				if (dataTable20.Rows.Count > 0)
				{
					int count = dataTable20.Rows.Count;
					int num104 = count - 1;
					for (int num105 = 0; num105 <= num104; num105++)
					{
						DataRow dataRow31 = dataTable20.Rows[num105];
						int num28 = Conversions.ToInteger(dataRow31["ID"].ToString());
						string text9 = Conversions.ToString(dataRow31["Name"]);
						DeltaWriter.WriteStartElement("MagAdd_" + Conversions.ToString(num28));
						DeltaWriter.WriteEndElement();
						DeltaWriter.WriteComment(text9);
					}
				}
				if (dataTable13.Rows.Count > 0)
				{
					int count = dataTable13.Rows.Count;
					int num106 = count - 1;
					for (int num107 = 0; num107 <= num106; num107++)
					{
						DataRow dataRow32 = dataTable13.Rows[num107];
						int num28 = Conversions.ToInteger(dataRow32["MagID"].ToString());
						int num29 = Conversions.ToInteger(dataRow32["MagIndex"].ToString());
						string text9 = Conversions.ToString(dataRow32["MagName"]);
						DeltaWriter.WriteStartElement("Mag_" + Conversions.ToString(num29 + 1) + "_" + Conversions.ToString(num28));
						DeltaWriter.WriteComment(text9);
						if (dataTable16.Rows.Count > 0)
						{
							int num108 = dataTable16.Rows.Count - 1;
							for (int num109 = 0; num109 <= num108; num109++)
							{
								DataRow dataRow33 = dataTable16.Rows[num109];
								int num110 = Conversions.ToInteger(dataRow33["MagID"].ToString());
								int num111 = Conversions.ToInteger(dataRow33["MagIndex"].ToString());
								int num30 = Conversions.ToInteger(dataRow33["WeaponID"].ToString());
								string text7 = Conversions.ToString(dataRow33["WeaponName"]);
								if (num110 == num28 && num111 == num29)
								{
									DeltaWriter.WriteStartElement("WeaponRemove_" + Conversions.ToString(num30));
									DeltaWriter.WriteEndElement();
									DeltaWriter.WriteComment(text7);
								}
							}
						}
						if (dataTable15.Rows.Count > 0)
						{
							int num112 = dataTable15.Rows.Count - 1;
							for (int num113 = 0; num113 <= num112; num113++)
							{
								DataRow dataRow34 = dataTable15.Rows[num113];
								int num110 = Conversions.ToInteger(dataRow34["MagID"].ToString());
								int num111 = Conversions.ToInteger(dataRow34["MagIndex"].ToString());
								int num34 = Conversions.ToInteger(dataRow34["WeapRecID"].ToString());
								int num30 = Conversions.ToInteger(dataRow34["WeaponID"].ToString());
								string text7 = Conversions.ToString(dataRow34["WeaponName"]);
								if (num110 == num28 && num111 == num29)
								{
									DeltaWriter.WriteStartElement("WeaponRecAdd_" + Conversions.ToString(num34) + "_" + Conversions.ToString(num30));
									DeltaWriter.WriteEndElement();
									DeltaWriter.WriteComment(text7);
								}
							}
						}
						if (dataTable14.Rows.Count > 0)
						{
							int num114 = dataTable14.Rows.Count - 1;
							for (int num115 = 0; num115 <= num114; num115++)
							{
								DataRow dataRow35 = dataTable14.Rows[num115];
								int num110 = Conversions.ToInteger(dataRow35["MagID"].ToString());
								int num111 = Conversions.ToInteger(dataRow35["MagIndex"].ToString());
								int num30 = Conversions.ToInteger(dataRow35["WeaponID"].ToString());
								int num31 = Conversions.ToInteger(dataRow35["WeaponQty"].ToString());
								string text7 = Conversions.ToString(dataRow35["WeaponName"]);
								if (num110 == num28 && num111 == num29)
								{
									DeltaWriter.WriteStartElement("WeaponEdit_" + Conversions.ToString(num30) + "_" + Conversions.ToString(num31));
									DeltaWriter.WriteEndElement();
									DeltaWriter.WriteComment(text7);
								}
							}
						}
						DeltaWriter.WriteEndElement();
					}
				}
			}
			if (dataTable21.Rows.Count > 0 || dataTable12.Rows.Count > 0)
			{
				if (dataTable21.Rows.Count > 0)
				{
					int count = dataTable21.Rows.Count;
					int num116 = count - 1;
					for (int num117 = 0; num117 <= num116; num117++)
					{
						DataRow dataRow36 = dataTable21.Rows[count - 1 - num117];
						int num43 = Conversions.ToInteger(dataRow36["ComponentID"].ToString());
						string text10 = Conversions.ToString(dataRow36["Name"]);
						int num118 = Conversions.ToInteger(dataRow36["SensorIndex"].ToString());
						DeltaWriter.WriteStartElement("SensorRemove_" + Conversions.ToString(num118 + 1) + "_" + Conversions.ToString(num43));
						DeltaWriter.WriteEndElement();
						DeltaWriter.WriteComment(text10);
					}
				}
				if (dataTable12.Rows.Count > 0)
				{
					int count = dataTable12.Rows.Count;
					int num119 = count - 1;
					for (int num120 = 0; num120 <= num119; num120++)
					{
						DataRow dataRow36 = dataTable12.Rows[count - 1 - num120];
						int num43 = Conversions.ToInteger(dataRow36["SensorID"].ToString());
						string text10 = Conversions.ToString(dataRow36["Name"]);
						num5 = Conversions.ToInteger(dataRow36["MountIndex"].ToString());
						int num4 = Conversions.ToInteger(dataRow36["MountID"].ToString());
						if (Conversions.ToBoolean(dataRow36["Remove"]))
						{
							DeltaWriter.WriteStartElement("SensorMountRemove_" + Conversions.ToString(num5 + 1) + "_" + Conversions.ToString(num4) + "_" + Conversions.ToString(num43));
						}
						else
						{
							DeltaWriter.WriteStartElement("SensorMountAdd_" + Conversions.ToString(num5 + 1) + "_" + Conversions.ToString(num4) + "_" + Conversions.ToString(num43));
						}
						DeltaWriter.WriteEndElement();
						DeltaWriter.WriteComment(text10);
					}
				}
			}
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				int count = dataTable.Rows.Count;
				int num121 = count - 1;
				for (int num122 = 0; num122 <= num121; num122++)
				{
					DataRow dataRow36 = dataTable.Rows[count - 1 - num122];
					int num43 = Conversions.ToInteger(dataRow36["ComponentID"].ToString());
					string text10 = Conversions.ToString(dataRow36["Name"]);
					int num118 = Conversions.ToInteger(dataRow36["SensorIndex"].ToString());
					DeltaWriter.WriteStartElement("MCMRemove_" + Conversions.ToString(num118 + 1) + "_" + Conversions.ToString(num43));
					DeltaWriter.WriteEndElement();
					DeltaWriter.WriteComment(text10);
				}
			}
			if (dataTable23.Rows.Count > 0)
			{
				int count = dataTable23.Rows.Count;
				int num123 = count - 1;
				for (int num124 = 0; num124 <= num123; num124++)
				{
					DataRow dataRow37 = dataTable23.Rows[count - 1 - num124];
					int num54 = Conversions.ToInteger(dataRow37["ComponentID"].ToString());
					string text11 = Conversions.ToString(dataRow37["Name"]);
					int num125 = Conversions.ToInteger(dataRow37["CommIndex"].ToString());
					DeltaWriter.WriteStartElement("CommRemove_" + Conversions.ToString(num125 + 1) + "_" + Conversions.ToString(num54));
					DeltaWriter.WriteEndElement();
					DeltaWriter.WriteComment(text11);
				}
			}
			if (dataTable22.Rows.Count > 0)
			{
				int count = dataTable22.Rows.Count;
				int num126 = count - 1;
				for (int num127 = 0; num127 <= num126; num127++)
				{
					DataRow dataRow36 = dataTable22.Rows[num127];
					int num43 = Conversions.ToInteger(dataRow36["ID"].ToString());
					string text10 = Conversions.ToString((!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow36["Name"]))) ? dataRow36["Name"] : "");
					DeltaWriter.WriteStartElement("SensorAdd_" + Conversions.ToString(num43));
					DeltaWriter.WriteComment(text10);
					smethod_0(DeltaWriter, bool_0: true, dataRow36, theAU, text10);
				}
			}
			if (dataTable24.Rows.Count > 0)
			{
				int count = dataTable24.Rows.Count;
				int num128 = count - 1;
				for (int num129 = 0; num129 <= num128; num129++)
				{
					DataRow dataRow38 = dataTable24.Rows[num129];
					int num54 = Conversions.ToInteger(dataRow38["ID"].ToString());
					string text11 = Conversions.ToString(dataRow38["Name"]);
					DeltaWriter.WriteStartElement("CommAdd_" + Conversions.ToString(num54));
					DeltaWriter.WriteEndElement();
					DeltaWriter.WriteComment(text11);
				}
			}
			if (dataTable2.Rows.Count > 0)
			{
				int count = dataTable2.Rows.Count;
				int num130 = count - 1;
				for (int num131 = 0; num131 <= num130; num131++)
				{
					DataRow dataRow39 = dataTable2.Rows[count - 1 - num131];
					int num43 = Conversions.ToInteger(dataRow39["DBID"]);
					string text10 = dataRow39["Name"].ToString();
					DeltaWriter.WriteStartElement("SensorActive_" + Conversions.ToString(num43));
					DeltaWriter.WriteEndElement();
					DeltaWriter.WriteComment(text10);
				}
				dataTable2.Clear();
			}
			if (dataTable27 != null && dataTable27.Rows.Count > 0)
			{
				int count = dataTable27.Rows.Count;
				int num132 = count - 1;
				for (int num133 = 0; num133 <= num132; num133++)
				{
					DataRow dataRow40 = dataTable27.Rows[count - 1 - num133];
					int num54 = Conversions.ToInteger(dataRow40["ComponentID"].ToString());
					string text11 = Conversions.ToString(dataRow40["Name"]);
					int num125 = Conversions.ToInteger(dataRow40["FacilityIndex"].ToString());
					DeltaWriter.WriteStartElement("DockRemove_" + Conversions.ToString(num125 + 1) + "_" + Conversions.ToString(num54));
					DeltaWriter.WriteEndElement();
					DeltaWriter.WriteComment(text11);
				}
			}
			if (dataTable25 != null && dataTable25.Rows.Count > 0)
			{
				int count = dataTable25.Rows.Count;
				int num134 = count - 1;
				for (int num135 = 0; num135 <= num134; num135++)
				{
					DataRow dataRow41 = dataTable25.Rows[num135];
					int num54 = Conversions.ToInteger(dataRow41["ID"].ToString());
					string text11 = Conversions.ToString(dataRow41["Name"]);
					DeltaWriter.WriteStartElement("DockAdd_" + Conversions.ToString(num54));
					DeltaWriter.WriteEndElement();
					DeltaWriter.WriteComment(text11);
				}
			}
			if (dataTable28 != null && dataTable28.Rows.Count > 0)
			{
				int count = dataTable28.Rows.Count;
				int num136 = count - 1;
				for (int num137 = 0; num137 <= num136; num137++)
				{
					DataRow dataRow42 = dataTable28.Rows[count - 1 - num137];
					int num54 = Conversions.ToInteger(dataRow42["ComponentID"].ToString());
					string text11 = Conversions.ToString(dataRow42["Name"]);
					int num125 = Conversions.ToInteger(dataRow42["FacilityIndex"].ToString());
					DeltaWriter.WriteStartElement("AirOpsRemove_" + Conversions.ToString(num125 + 1) + "_" + Conversions.ToString(num54));
					DeltaWriter.WriteEndElement();
					DeltaWriter.WriteComment(text11);
				}
			}
			if (dataTable26 != null && dataTable26.Rows.Count > 0)
			{
				int count = dataTable26.Rows.Count;
				int num138 = count - 1;
				for (int num139 = 0; num139 <= num138; num139++)
				{
					DataRow dataRow43 = dataTable26.Rows[num139];
					int num54 = Conversions.ToInteger(dataRow43["ID"].ToString());
					string text11 = Conversions.ToString(dataRow43["Name"]);
					DeltaWriter.WriteStartElement("AirOpsAdd_" + Conversions.ToString(num54));
					DeltaWriter.WriteEndElement();
					DeltaWriter.WriteComment(text11);
				}
			}
			if (dataTable29.Rows.Count > 0)
			{
				int count = dataTable29.Rows.Count;
				DeltaWriter.WriteStartElement("Damage");
				int num140 = count - 1;
				for (int num141 = 0; num141 <= num140; num141++)
				{
					DataRow dataRow44 = dataTable29.Rows[num141];
					string text12 = Conversions.ToString(dataRow44["ID"]);
					string text13 = Conversions.ToString(dataRow44["Type"]);
					string text14 = dataRow44["Status"].ToString();
					string text15 = dataRow44["DamageSeverity"].ToString();
					string text16 = dataRow44["Name"].ToString();
					if (Operators.CompareString(text12, "", false) == 0)
					{
						DeltaWriter.WriteElementString(text13, text14);
						continue;
					}
					DeltaWriter.WriteStartElement(text13 + "_" + text12);
					DeltaWriter.WriteComment(text16);
					DeltaWriter.WriteElementString("Status", text14);
					DeltaWriter.WriteElementString("Severity", text15);
					DeltaWriter.WriteEndElement();
				}
				DeltaWriter.WriteEndElement();
				dataTable29.Clear();
			}
			if (theAU.HasCustomOODA)
			{
				DeltaWriter.WriteStartElement("CustomOODA");
				DeltaWriter.WriteElementString("Detection", theAU.OODA_Detection.ToString());
				DeltaWriter.WriteElementString("Targeting", theAU.OODA_Targeting.ToString());
				DeltaWriter.WriteElementString("Evasion", theAU.OODA_Evasion.ToString());
				DeltaWriter.WriteEndElement();
			}
			DeltaWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101417", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static string smethod_0(XmlWriter xmlWriter_0, bool bool_0, DataRow dataRow_0, object object_0, object object_1)
	{
		string result;
		try
		{
			xmlWriter_0.WriteStartElement("Cov");
			if (Conversions.ToBoolean(dataRow_0["Has360Coverage"]))
			{
				xmlWriter_0.WriteElementString("Seg", "360");
			}
			else
			{
				StringBuilder stringBuilder = new StringBuilder();
				if (Conversions.ToBoolean(dataRow_0["PB1"]))
				{
					stringBuilder.Append("PB1,");
				}
				if (Conversions.ToBoolean(dataRow_0["PB2"]))
				{
					stringBuilder.Append("PB2,");
				}
				if (Conversions.ToBoolean(dataRow_0["PMA1"]))
				{
					stringBuilder.Append("PMA1,");
				}
				if (Conversions.ToBoolean(dataRow_0["PMA2"]))
				{
					stringBuilder.Append("PMA2,");
				}
				if (Conversions.ToBoolean(dataRow_0["PMF1"]))
				{
					stringBuilder.Append("PMF1,");
				}
				if (Conversions.ToBoolean(dataRow_0["PMF2"]))
				{
					stringBuilder.Append("PMF2,");
				}
				if (Conversions.ToBoolean(dataRow_0["PS1"]))
				{
					stringBuilder.Append("PS1,");
				}
				if (Conversions.ToBoolean(dataRow_0["PS2"]))
				{
					stringBuilder.Append("PS2,");
				}
				if (Conversions.ToBoolean(dataRow_0["SB1"]))
				{
					stringBuilder.Append("SB1,");
				}
				if (Conversions.ToBoolean(dataRow_0["SB2"]))
				{
					stringBuilder.Append("SB2,");
				}
				if (Conversions.ToBoolean(dataRow_0["SMA1"]))
				{
					stringBuilder.Append("SMA1,");
				}
				if (Conversions.ToBoolean(dataRow_0["SMA2"]))
				{
					stringBuilder.Append("SMA2,");
				}
				if (Conversions.ToBoolean(dataRow_0["SMF1"]))
				{
					stringBuilder.Append("SMF1,");
				}
				if (Conversions.ToBoolean(dataRow_0["SMF2"]))
				{
					stringBuilder.Append("SMF2,");
				}
				if (Conversions.ToBoolean(dataRow_0["SS2"]))
				{
					stringBuilder.Append("SS2,");
				}
				if (Conversions.ToBoolean(dataRow_0["SS1"]))
				{
					stringBuilder.Append("SS1,");
				}
				xmlWriter_0.WriteElementString("Seg", stringBuilder.ToString());
			}
			xmlWriter_0.WriteEndElement();
			string text = default(string);
			if (!Conversions.ToBoolean(dataRow_0["PB1"]) & !Conversions.ToBoolean(dataRow_0["PB2"]) & !Conversions.ToBoolean(dataRow_0["PMA1"]) & !Conversions.ToBoolean(dataRow_0["PMA2"]) & !Conversions.ToBoolean(dataRow_0["PMF1"]) & !Conversions.ToBoolean(dataRow_0["PMF2"]) & !Conversions.ToBoolean(dataRow_0["PS1"]) & !Conversions.ToBoolean(dataRow_0["PS2"]) & !Conversions.ToBoolean(dataRow_0["SB1"]) & !Conversions.ToBoolean(dataRow_0["SB2"]) & !Conversions.ToBoolean(dataRow_0["SMA1"]) & !Conversions.ToBoolean(dataRow_0["SMA2"]) & !Conversions.ToBoolean(dataRow_0["SMF1"]) & !Conversions.ToBoolean(dataRow_0["SMF2"]) & !Conversions.ToBoolean(dataRow_0["SS1"]) & !Conversions.ToBoolean(dataRow_0["SS2"]))
			{
				text = "ERROR: Component " + (string)object_1 + " on unit " + ((ActiveUnit)object_0).Name + " (" + ((Module_Unit.Unit)object_0).UnitClass + " [" + Conversions.ToString(((ActiveUnit)object_0).DBID) + "]) does not have a valid arc!";
			}
			if (bool_0)
			{
				xmlWriter_0.WriteStartElement("Cov_Ill");
				if (Conversions.ToBoolean(dataRow_0["Has360CoverageMax"]))
				{
					xmlWriter_0.WriteElementString("Seg", "360");
				}
				else
				{
					StringBuilder stringBuilder2 = new StringBuilder();
					if (Conversions.ToBoolean(dataRow_0["PB1Max"]))
					{
						stringBuilder2.Append("PB1,");
					}
					if (Conversions.ToBoolean(dataRow_0["PB2Max"]))
					{
						stringBuilder2.Append("PB2,");
					}
					if (Conversions.ToBoolean(dataRow_0["PMA1Max"]))
					{
						stringBuilder2.Append("PMA1,");
					}
					if (Conversions.ToBoolean(dataRow_0["PMA2Max"]))
					{
						stringBuilder2.Append("PMA2,");
					}
					if (Conversions.ToBoolean(dataRow_0["PMF1Max"]))
					{
						stringBuilder2.Append("PMF1,");
					}
					if (Conversions.ToBoolean(dataRow_0["PMF2Max"]))
					{
						stringBuilder2.Append("PMF2,");
					}
					if (Conversions.ToBoolean(dataRow_0["PS1Max"]))
					{
						stringBuilder2.Append("PS1,");
					}
					if (Conversions.ToBoolean(dataRow_0["PS2Max"]))
					{
						stringBuilder2.Append("PS2,");
					}
					if (Conversions.ToBoolean(dataRow_0["SB1Max"]))
					{
						stringBuilder2.Append("SB1,");
					}
					if (Conversions.ToBoolean(dataRow_0["SB2Max"]))
					{
						stringBuilder2.Append("SB2,");
					}
					if (Conversions.ToBoolean(dataRow_0["SMA1Max"]))
					{
						stringBuilder2.Append("SMA1,");
					}
					if (Conversions.ToBoolean(dataRow_0["SMA2Max"]))
					{
						stringBuilder2.Append("SMA2,");
					}
					if (Conversions.ToBoolean(dataRow_0["SMF1Max"]))
					{
						stringBuilder2.Append("SMF1,");
					}
					if (Conversions.ToBoolean(dataRow_0["SMF2Max"]))
					{
						stringBuilder2.Append("SMF2,");
					}
					if (Conversions.ToBoolean(dataRow_0["SS2Max"]))
					{
						stringBuilder2.Append("SS2,");
					}
					if (Conversions.ToBoolean(dataRow_0["SS1Max"]))
					{
						stringBuilder2.Append("SS1,");
					}
					xmlWriter_0.WriteElementString("Seg", stringBuilder2.ToString());
				}
				xmlWriter_0.WriteEndElement();
				if (!Conversions.ToBoolean(dataRow_0["PB1Max"]) & !Conversions.ToBoolean(dataRow_0["PB2Max"]) & !Conversions.ToBoolean(dataRow_0["PMA1Max"]) & !Conversions.ToBoolean(dataRow_0["PMA2Max"]) & !Conversions.ToBoolean(dataRow_0["PMF1Max"]) & !Conversions.ToBoolean(dataRow_0["PMF2Max"]) & !Conversions.ToBoolean(dataRow_0["PS1Max"]) & !Conversions.ToBoolean(dataRow_0["PS2Max"]) & !Conversions.ToBoolean(dataRow_0["PS1Max"]) & !Conversions.ToBoolean(dataRow_0["SB2Max"]) & !Conversions.ToBoolean(dataRow_0["SMA1Max"]) & !Conversions.ToBoolean(dataRow_0["SMA2Max"]) & !Conversions.ToBoolean(dataRow_0["SMF1Max"]) & !Conversions.ToBoolean(dataRow_0["SMF2Max"]) & !Conversions.ToBoolean(dataRow_0["SS1Max"]) & !Conversions.ToBoolean(dataRow_0["SS2Max"]))
				{
					text = "ERROR: Component " + (string)object_1 + " on unit " + ((ActiveUnit)object_0).Name + " (" + ((Module_Unit.Unit)object_0).UnitClass + " [" + Conversions.ToString(((ActiveUnit)object_0).DBID) + "]) does not have a valid Max/Illuminate arc!";
				}
			}
			xmlWriter_0.WriteEndElement();
			result = text;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101115", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = "Error!";
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private static int smethod_1(Scenario scenario_0, ref Mount mount_0, XmlNode xmlNode_0, int int_0)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		int result = default(int);
		try
		{
			bool flag = false;
			bool flag2 = false;
			int num3 = default(int);
			foreach (XmlNode childNode in xmlNode_0.ChildNodes)
			{
				XmlNode val = childNode;
				string[] array = val.Name.Split(new char[1] { '_' });
				switch (array[0])
				{
				case "WeaponEdit":
				{
					int num = Conversions.ToInteger(array[1]);
					int num2 = Conversions.ToInteger(array[2]);
					bool flag3 = false;
					foreach (WeaponRec mountWeapon in mount_0.MountWeapons)
					{
						if (mountWeapon.int_3 == num)
						{
							flag3 = true;
							mountWeapon.CurrentLoad = num2;
							if (int_0 == 0)
							{
								flag = true;
							}
							string innerText = "Updated Weapon with DBID " + Conversions.ToString(num) + ", Qty: " + Conversions.ToString(num2);
							StreamWriter streamWriter = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter.Write("\r\n      " + innerText);
							streamWriter.Close();
							num3++;
							break;
						}
					}
					if (!flag3 && int_0 != 0)
					{
						string innerText = "ERROR: WEAPON QTY COULD NOT BE UPDATED, WEAPON WITH DBID " + Conversions.ToString(num) + " NOT FOUND ON MOUNT!";
						StreamWriter streamWriter = File.AppendText(GameGeneral.SBRLogFilePath);
						streamWriter.Write("\r\n      " + innerText);
						streamWriter.Close();
					}
					break;
				}
				case "WeaponRemove":
				{
					int num = Conversions.ToInteger(array[1]);
					bool flag3 = false;
					List<WeaponRec> list = new List<WeaponRec>();
					foreach (WeaponRec mountWeapon2 in mount_0.MountWeapons)
					{
						if (mountWeapon2.int_3 == num)
						{
							list.Add(mountWeapon2);
						}
					}
					foreach (WeaponRec item in list)
					{
						mount_0.MountWeapons.Remove(item);
						flag3 = true;
						if (int_0 == 0)
						{
							flag = true;
						}
						string innerText = "Removed Weapon with DBID " + Conversions.ToString(num);
						StreamWriter streamWriter = File.AppendText(GameGeneral.SBRLogFilePath);
						streamWriter.Write("\r\n      " + innerText);
						streamWriter.Close();
						num3++;
					}
					if (!flag3 && int_0 != 0)
					{
						string innerText = "ERROR: WEAPON WITH DBID " + Conversions.ToString(num) + " COULD NOT BE REMOVED, NOT FOUND ON MOUNT!";
						StreamWriter streamWriter = File.AppendText(GameGeneral.SBRLogFilePath);
						streamWriter.Write("\r\n      " + innerText);
						streamWriter.Close();
					}
					break;
				}
				case "MountMag":
				{
					Magazine magazine_ = mount_0.MountMagazine;
					smethod_2(scenario_0, ref magazine_, val, int_0, bool_0: true);
					break;
				}
				case "WeaponRecAdd":
				{
					int num4 = Conversions.ToInteger(array[1]);
					int num = ((array.Length > 2) ? Conversions.ToInteger(array[2]) : 0);
					string innerText;
					StreamWriter streamWriter;
					if (num4 == 0)
					{
						WeaponRec weaponRec = new WeaponRec(ref scenario_0, num, 0, 10000, 1, 1, ExcludeOptionalWeapons: false, AircraftInternalWeapons: false);
						mount_0.MountWeapons.Add(weaponRec);
						if (int_0 == 0)
						{
							flag = true;
						}
						innerText = "Added non-database 0/10000 WeaponRec, Weapon DBID " + Conversions.ToString(weaponRec.int_3) + " to magazine " + mount_0.Name;
						streamWriter = File.AppendText(GameGeneral.SBRLogFilePath);
						streamWriter.Write("\r\n      " + innerText);
						streamWriter.Close();
						num3++;
						break;
					}
					SQLiteHelper theHelper = new SQLiteHelper(scenario_0.DBConnection);
					string theQuery = "SELECT * from DataWeaponRecord where ID = " + Conversions.ToString(num4);
					if (DBCache.GetDatatable(theHelper, theQuery).Rows.Count == 0)
					{
						if (int_0 != 0)
						{
							innerText = "ERROR: WEAPON RECORD " + Conversions.ToString(num4) + " COULD NOT BE ADDED, NOT FOUND IN DATABASE!";
							streamWriter = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter.Write("\r\n      " + innerText);
							streamWriter.Close();
						}
						break;
					}
					WeaponRec weaponRec2 = DBFunctions.GetWeaponRec(num4, mount_0.ParentPlatform.ParentScen);
					mount_0.MountWeapons.Add(weaponRec2);
					int num5;
					if (int_0 == 0)
					{
						flag = true;
						num5 = 6;
					}
					else
					{
						num5 = 6;
					}
					string[] array2 = new string[num5];
					array2[0] = "Added WeaponRec ";
					array2[1] = Conversions.ToString(num4);
					array2[2] = ", Weapon DBID ";
					array2[3] = Conversions.ToString(weaponRec2.int_3);
					array2[4] = " to mount ";
					array2[5] = mount_0.Name;
					innerText = string.Concat(array2);
					streamWriter = File.AppendText(GameGeneral.SBRLogFilePath);
					streamWriter.Write("\r\n      " + innerText);
					streamWriter.Close();
					num3++;
					break;
				}
				case "#comment":
				{
					string innerText = val.InnerText;
					StreamWriter streamWriter = File.AppendText(GameGeneral.SBRLogFilePath);
					if (!flag2 && int_0 != 0)
					{
						flag2 = true;
						streamWriter.Write("\r\n    " + innerText);
					}
					else if ((flag2 && int_0 != 0) || (int_0 == 0 && flag))
					{
						streamWriter.Write(" -- " + innerText);
					}
					streamWriter.Close();
					break;
				}
				}
			}
			result = num3;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101116", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private static int smethod_2(Scenario scenario_0, ref Magazine magazine_0, XmlNode xmlNode_0, int int_0, bool bool_0)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		bool flag = false;
		bool flag2 = false;
		if (bool_0)
		{
			flag2 = true;
		}
		string text = (bool_0 ? "    " : "");
		int result = default(int);
		try
		{
			int num3 = default(int);
			foreach (XmlNode childNode in xmlNode_0.ChildNodes)
			{
				XmlNode val = childNode;
				string[] array = val.Name.Split(new char[1] { '_' });
				switch (array[0])
				{
				case "WeaponRecAdd":
				{
					int num4 = Conversions.ToInteger(array[1]);
					int num = ((array.Length > 2) ? Conversions.ToInteger(array[2]) : 0);
					if (num4 == 0)
					{
						WeaponRec weaponRec = new WeaponRec(ref scenario_0, num, 0, 10000, 1, 1, ExcludeOptionalWeapons: false, AircraftInternalWeapons: false);
						magazine_0.Weapons.Add(weaponRec);
						if (int_0 == 0)
						{
							flag = true;
						}
						string innerText = "Added non-database 0/10000 WeaponRec, Weapon DBID " + Conversions.ToString(weaponRec.int_3) + " to magazine " + magazine_0.Name;
						StreamWriter streamWriter = File.AppendText(GameGeneral.SBRLogFilePath);
						streamWriter.Write("\r\n      " + text + innerText);
						streamWriter.Close();
						num3++;
						break;
					}
					SQLiteHelper theHelper = new SQLiteHelper(scenario_0.DBConnection);
					string theQuery = "SELECT * from DataWeaponRecord where ID = " + Conversions.ToString(num4);
					if (DBCache.GetDatatable(theHelper, theQuery).Rows.Count != 0)
					{
						WeaponRec weaponRec2 = DBFunctions.GetWeaponRec(num4, magazine_0.ParentPlatform.ParentScen);
						magazine_0.Weapons.Add(weaponRec2);
						int num5;
						if (int_0 != 0)
						{
							num5 = 6;
						}
						else
						{
							flag = true;
							num5 = 6;
						}
						string[] array2 = new string[num5];
						array2[0] = "Added WeaponRec ";
						array2[1] = Conversions.ToString(num4);
						array2[2] = ", Weapon DBID ";
						array2[3] = Conversions.ToString(weaponRec2.int_3);
						array2[4] = " to magazine ";
						array2[5] = magazine_0.Name;
						string innerText = string.Concat(array2);
						StreamWriter streamWriter = File.AppendText(GameGeneral.SBRLogFilePath);
						streamWriter.Write("\r\n      " + text + innerText);
						streamWriter.Close();
						num3++;
					}
					else if (int_0 != 0)
					{
						string innerText = "ERROR: WEAPON RECORD " + Conversions.ToString(num4) + " COULD NOT BE ADDED, NOT FOUND IN DATABASE!";
						StreamWriter streamWriter = File.AppendText(GameGeneral.SBRLogFilePath);
						streamWriter.Write("\r\n      " + text + innerText);
						streamWriter.Close();
					}
					break;
				}
				case "WeaponRemove":
				{
					int num = Conversions.ToInteger(array[1]);
					bool flag3 = false;
					List<WeaponRec> list = new List<WeaponRec>();
					foreach (WeaponRec weapon in magazine_0.Weapons)
					{
						if (weapon.int_3 == num)
						{
							list.Add(weapon);
						}
					}
					foreach (WeaponRec item in list)
					{
						magazine_0.Weapons.Remove(item);
						flag3 = true;
						if (int_0 == 0)
						{
							flag = true;
						}
						string innerText = "Removed Weapon DBID " + Conversions.ToString(num);
						StreamWriter streamWriter = File.AppendText(GameGeneral.SBRLogFilePath);
						streamWriter.Write("\r\n      " + text + innerText);
						streamWriter.Close();
						num3++;
					}
					if (!flag3 && int_0 != 0)
					{
						string innerText = "ERROR: WEAPON WITH DBID " + Conversions.ToString(num) + " COULD NOT BE REMOVED, NOT FOUND ON MOUNT!";
						StreamWriter streamWriter = File.AppendText(GameGeneral.SBRLogFilePath);
						streamWriter.Write("\r\n      " + text + innerText);
						streamWriter.Close();
					}
					break;
				}
				case "WeaponEdit":
				{
					bool flag3 = false;
					int num = Conversions.ToInteger(array[1]);
					int num2 = Conversions.ToInteger(array[2]);
					foreach (WeaponRec weapon2 in magazine_0.Weapons)
					{
						if (weapon2.int_3 == num)
						{
							flag3 = true;
							weapon2.CurrentLoad = num2;
							if (int_0 == 0)
							{
								flag = true;
							}
							string innerText = "Updated Weapon with DBID " + Conversions.ToString(num) + ", Qty: " + Conversions.ToString(num2);
							StreamWriter streamWriter = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter.Write("\r\n      " + text + innerText);
							streamWriter.Close();
							num3++;
						}
					}
					if (!flag3 && int_0 != 0)
					{
						string innerText = "ERROR: WEAPON QTY COULD NOT BE UPDATED, WEAPON WITH DBID " + Conversions.ToString(num) + " NOT FOUND IN MAGAZINE!";
						StreamWriter streamWriter = File.AppendText(GameGeneral.SBRLogFilePath);
						streamWriter.Write("\r\n      " + text + innerText);
						streamWriter.Close();
					}
					break;
				}
				case "#comment":
				{
					string innerText = val.InnerText;
					StreamWriter streamWriter = File.AppendText(GameGeneral.SBRLogFilePath);
					if (!flag2 && int_0 != 0)
					{
						flag2 = true;
						streamWriter.Write("\r\n   " + innerText);
					}
					else if ((flag2 && int_0 != 0) || (int_0 == 0 && flag))
					{
						streamWriter.Write(" -- " + innerText);
					}
					streamWriter.Close();
					break;
				}
				}
			}
			result = num3;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101117", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static PlatformComponent FindComponentByIDOrNameUndamaged(PlatformComponent[] theArray, string theID, string theName)
	{
		PlatformComponent platformComponent = null;
		foreach (PlatformComponent platformComponent2 in theArray)
		{
			if (Operators.CompareString(platformComponent2.ObjectID, theID, false) != 0)
			{
				if (platformComponent == null && Operators.CompareString(platformComponent2.Name, theName, false) == 0 && platformComponent2.Status == PlatformComponent._ComponentStatus.Operational)
				{
					platformComponent = platformComponent2;
				}
				continue;
			}
			return platformComponent2;
		}
		return platformComponent;
	}

	public static void ApplyComponentDamage(PlatformComponent theC, XmlNode theDamage)
	{
		if (theC == null || theDamage == null)
		{
			return;
		}
		PlatformComponent._ComponentStatus componentStatus = PlatformComponent._ComponentStatus.Operational;
		PlatformComponent._DamageSeverityFactor damageSeverityFactor = PlatformComponent._DamageSeverityFactor.Light;
		if (theDamage.SelectSingleNode("Severity") != null)
		{
			damageSeverityFactor = (PlatformComponent._DamageSeverityFactor)Conversions.ToByte(theDamage.SelectSingleNode("Severity").InnerText);
			if (theC.DamageSeverity != damageSeverityFactor)
			{
				theC.Damage(damageSeverityFactor);
			}
			else
			{
				damageSeverityFactor = PlatformComponent._DamageSeverityFactor.Light;
			}
		}
		if (theDamage.SelectSingleNode("Status") == null)
		{
			return;
		}
		componentStatus = (PlatformComponent._ComponentStatus)Conversions.ToByte(theDamage.SelectSingleNode("Status").InnerText);
		if (theC.Status == componentStatus)
		{
			return;
		}
		switch (componentStatus)
		{
		case PlatformComponent._ComponentStatus.Operational:
			theC.Repair();
			break;
		case PlatformComponent._ComponentStatus.Damaged:
			if (damageSeverityFactor == PlatformComponent._DamageSeverityFactor.Light)
			{
				theC.Damage(theC.DamageSeverity);
			}
			break;
		case PlatformComponent._ComponentStatus.Destroyed:
			theC.Destroy(theC.ParentPlatform.get_UnitSide(SetSideOnly: false), ScenEditAction: true, IsAimpointFacility: false);
			break;
		}
	}

	public static void ApplyDeltaToThisUnit(XmlNode theNode, ActiveUnit theAU, Scenario theScen, XmlWriter DeltaWriter, StreamWriter LogFileWriter, bool IsUnitCloningOperation, ref int ErrorCount)
	{
		//IL_0457: Unknown result type (might be due to invalid IL or missing references)
		//IL_045e: Expected O, but got Unknown
		//IL_1350: Unknown result type (might be due to invalid IL or missing references)
		//IL_1355: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa9: Expected O, but got Unknown
		//IL_1fa3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1faa: Expected O, but got Unknown
		//IL_078f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0796: Expected O, but got Unknown
		string text = theNode.Name.Split(new char[1] { '_' })[1];
		if (theAU == null && theScen.ActiveUnits.ContainsKey(text))
		{
			theAU = theScen.ActiveUnits[text];
		}
		if (theAU != null)
		{
			SQLiteHelper theHelper = new SQLiteHelper(theScen.DBConnection);
			string theQuery = default(string);
			string theQuery2 = default(string);
			string theQuery3 = default(string);
			switch (theAU.UnitType)
			{
			case GlobalVariables.ActiveUnitType.Aircraft:
				theQuery = "Select YearCommissioned, YearDecommissioned from DataAircraft where ID = " + Conversions.ToString(theAU.DBID);
				theQuery2 = "Select Description from EnumOperatorCountry where ID in (Select OperatorCountry from DataAircraft where ID = " + Conversions.ToString(theAU.DBID) + ")";
				theQuery3 = "Select Description from EnumOperatorService where ID in (Select OperatorService from DataAircraft where ID = " + Conversions.ToString(theAU.DBID) + ")";
				break;
			case GlobalVariables.ActiveUnitType.Ship:
				theQuery = "Select YearCommissioned, YearDecommissioned from DataShip where ID = " + Conversions.ToString(theAU.DBID);
				theQuery2 = "Select Description from EnumOperatorCountry where ID in (Select OperatorCountry from DataShip where ID = " + Conversions.ToString(theAU.DBID) + ")";
				theQuery3 = "Select Description from EnumOperatorService where ID in (Select OperatorService from DataShip where ID = " + Conversions.ToString(theAU.DBID) + ")";
				break;
			case GlobalVariables.ActiveUnitType.Submarine:
				theQuery = "Select YearCommissioned, YearDecommissioned from DataSubmarine where ID = " + Conversions.ToString(theAU.DBID);
				theQuery2 = "Select Description from EnumOperatorCountry where ID in (Select OperatorCountry from DataSubmarine where ID = " + Conversions.ToString(theAU.DBID) + ")";
				theQuery3 = "Select Description from EnumOperatorService where ID in (Select OperatorService from DataSubmarine where ID = " + Conversions.ToString(theAU.DBID) + ")";
				break;
			case GlobalVariables.ActiveUnitType.Facility:
				theQuery = "Select YearCommissioned, YearDecommissioned from DataFacility where ID = " + Conversions.ToString(theAU.DBID);
				theQuery2 = "Select Description from EnumOperatorCountry where ID in (Select OperatorCountry from DataFacility where ID = " + Conversions.ToString(theAU.DBID) + ")";
				theQuery3 = "Select Description from EnumOperatorService where ID in (Select OperatorService from DataFacility where ID = " + Conversions.ToString(theAU.DBID) + ")";
				break;
			case GlobalVariables.ActiveUnitType.Satellite:
				theQuery = "Select YearCommissioned, YearDecommissioned from DataSatellite where ID = " + Conversions.ToString(theAU.DBID);
				theQuery2 = "Select Description from EnumOperatorCountry where ID in (Select OperatorCountry from DataSatellite where ID = " + Conversions.ToString(theAU.DBID) + ")";
				theQuery3 = "Select Description from EnumOperatorService where ID in (Select OperatorService from DataSatellite where ID = " + Conversions.ToString(theAU.DBID) + ")";
				break;
			case GlobalVariables.ActiveUnitType.Vehicle:
				theQuery = "Select YearCommissioned, YearDecommissioned from DataGroundUnit where ID = " + Conversions.ToString(theAU.DBID);
				theQuery2 = "Select Description from EnumOperatorCountry where ID in (Select OperatorCountry from DataGroundUnit where ID = " + Conversions.ToString(theAU.DBID) + ")";
				theQuery3 = "Select Description from EnumOperatorService where ID in (Select OperatorService from DataGroundUnit where ID = " + Conversions.ToString(theAU.DBID) + ")";
				break;
			}
			if (!(theAU.IsAircraft | theAU.IsFacility | theAU.IsShip | theAU.IsSubmarine | theAU.IsSatellite | theAU.IsVehicle))
			{
				return;
			}
			DataTable datatable = DBCache.GetDatatable(theHelper, theQuery);
			DataTable datatable2 = DBCache.GetDatatable(theHelper, theQuery2);
			DataTable datatable3 = DBCache.GetDatatable(theHelper, theQuery3);
			string text6;
			if ((datatable.Rows.Count != 0) & (datatable2.Rows.Count != 0) & (datatable3.Rows.Count != 0))
			{
				DataRow dataRow = datatable.Rows[0];
				DataRow dataRow2 = datatable2.Rows[0];
				DataRow dataRow3 = datatable3.Rows[0];
				string text2 = Strings.Trim(dataRow2["Description"].ToString());
				string text3 = Strings.Trim(dataRow3["Description"].ToString());
				string text4 = Conversions.ToString(Conversions.ToInteger(dataRow["YearCommissioned"].ToString()));
				string text5 = Conversions.ToString(Conversions.ToInteger(dataRow["YearDecommissioned"].ToString()));
				text6 = Conversions.ToString(theAU.DBID) + " -- " + theAU.Name + "  ----  " + theAU.UnitClass + " -- " + text2 + " (" + text3 + "), " + text4 + "-" + text5 + "  ----  " + theAU.ObjectID;
				StreamWriter streamWriter = File.AppendText(GameGeneral.SBRLogFilePath);
				streamWriter.Write("\r\n  " + text6);
				streamWriter.Close();
				List<(string, int, int, string)> list = new List<(string, int, int, string)>();
				list.Clear();
				_Closure$__15-0 closure$__15- = default(_Closure$__15-0);
				int num4 = default(int);
				foreach (XmlNode childNode in theNode.ChildNodes)
				{
					XmlNode val = childNode;
					string text7 = val.Name.Split(new char[1] { '_' })[0];
					switch (text7)
					{
					case "AirOpsAdd":
					{
						int num = Conversions.ToInteger(val.Name.Split(new char[1] { '_' })[1]);
						if (num > 0)
						{
							int facilityDBID2 = num;
							SQLiteConnection sqliteConnection_ = theScen.DBConnection;
							AirFacility airFacility = DBFunctions.GetAirFacility(facilityDBID2, ref sqliteConnection_);
							if (airFacility == null)
							{
								text6 = "ERROR: AIR FACILITY WITH DBID " + Conversions.ToString(num) + " COULD NOT BE ADDED, NOT FOUND IN DATABASE!";
								StreamWriter streamWriter30 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter30.Write("\r\n    " + text6);
								streamWriter30.Close();
							}
							else
							{
								theAU.AddAirFacility(airFacility);
								airFacility.ParentPlatform = theAU;
								text6 = "Added Air Facility, DBID: " + Conversions.ToString(num) + " Name: " + airFacility.Name;
								StreamWriter streamWriter31 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter31.Write("\r\n    " + text6);
								streamWriter31.Close();
							}
						}
						else if (num == -1)
						{
							AirFacility airFacility2 = AirFacility.AddUAV_Class1_Hanger(theAU);
							if (airFacility2 != null)
							{
								text6 = "Added Air Facility, DBID: " + Conversions.ToString(num) + " Name: " + airFacility2.Name;
								StreamWriter streamWriter32 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter32.Write("\r\n    " + text6);
								streamWriter32.Close();
							}
						}
						break;
					}
					case "SensorActive":
					{
						if (theAU.Sensory.ObeysEMCON)
						{
							theAU.Sensory.ObeysEMCON = false;
						}
						float num7 = Conversions.ToInteger(val.Name.Split(new char[1] { '_' })[1]);
						Sensor[] sensors_Cached = theAU.Sensors_Cached;
						foreach (Sensor sensor2 in sensors_Cached)
						{
							if ((float)sensor2.DBID == num7 && !sensor2.IsActive())
							{
								sensor2.GoActive();
								text6 = "Activate sensor [" + Conversions.ToString(num7) + "]";
								StreamWriter streamWriter14 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter14.Write("\r\n    " + text6);
								streamWriter14.Close();
							}
						}
						break;
					}
					case "MountAdd":
					{
						int num6 = Conversions.ToInteger(val.Name.Split(new char[1] { '_' })[1]);
						bool flag = false;
						if (num6 <= 0)
						{
							break;
						}
						string theQuery5 = "SELECT Name from DataMount where ID = " + Conversions.ToString(num6);
						if (DBCache.GetDatatable(theHelper, theQuery5).Rows.Count != 0)
						{
							Mount mount2 = DBFunctions.GetMount(num6, ref theScen);
							theAU.Mounts.Add(mount2);
							mount2.ParentPlatform = theAU;
							foreach (XmlNode childNode2 in val.ChildNodes)
							{
								XmlNode theNode3 = childNode2;
								string name3 = theNode3.Name;
								if (Operators.CompareString(name3, "Coverage", false) == 0 || Operators.CompareString(name3, "Cov", false) == 0)
								{
									mount2.Coverage = PlatformComponent._Coverage.FromXML(ref theNode3);
									flag = true;
								}
							}
							if (flag && mount2.Sensors_ReadOnly.Count() > 0)
							{
								Sensor[] sensors_ReadOnly2 = mount2.Sensors_ReadOnly;
								foreach (Sensor obj in sensors_ReadOnly2)
								{
									obj.ParentPlatform = theAU;
									obj.Coverage.PB1 = mount2.Coverage.PB1;
									obj.Coverage.PB2 = mount2.Coverage.PB2;
									obj.Coverage.PMA1 = mount2.Coverage.PMA1;
									obj.Coverage.PMA2 = mount2.Coverage.PMA2;
									obj.Coverage.PMF1 = mount2.Coverage.PMF1;
									obj.Coverage.PMF2 = mount2.Coverage.PMF2;
									obj.Coverage.PS1 = mount2.Coverage.PS1;
									obj.Coverage.PS2 = mount2.Coverage.PS2;
									obj.Coverage.SB1 = mount2.Coverage.SB1;
									obj.Coverage.SB2 = mount2.Coverage.SB2;
									obj.Coverage.SMA1 = mount2.Coverage.SMA1;
									obj.Coverage.SMA2 = mount2.Coverage.SMA2;
									obj.Coverage.SMF1 = mount2.Coverage.SMF1;
									obj.Coverage.SMF2 = mount2.Coverage.SMF2;
									obj.Coverage.SS1 = mount2.Coverage.SS1;
									obj.Coverage.SS2 = mount2.Coverage.SS2;
								}
							}
							text6 = "Added mount, DBID: " + Conversions.ToString(num6) + " Name " + mount2.Name;
							StreamWriter streamWriter15 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter15.Write("\r\n    " + text6);
							streamWriter15.Close();
							if (!flag)
							{
								text6 = "ERROR: MOUNT WITH DBID " + Conversions.ToString(num6) + " HAS NO ARCS SET!";
								StreamWriter streamWriter16 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter16.Write("\r\n    " + text6);
								streamWriter16.Close();
								ErrorCount++;
							}
						}
						else
						{
							text6 = "ERROR: MOUNT WITH DBID " + Conversions.ToString(num6) + " COULD NOT BE ADDED, NOT FOUND IN DATABASE!";
							StreamWriter streamWriter17 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter17.Write("\r\n    " + text6);
							streamWriter17.Close();
							ErrorCount++;
						}
						break;
					}
					case "Damage":
						foreach (XmlNode childNode3 in val.ChildNodes)
						{
							XmlNode val3 = childNode3;
							switch (val3.Name.Split(new char[1] { '_' })[0])
							{
							case "Cargo":
							{
								string theID = val3.Name.Split(new char[1] { '_' })[1];
								string innerText = val3.ChildNodes[0].InnerText;
								Cargo cargo = (Cargo)FindComponentByIDOrNameUndamaged(theAU.OnboardCargo, theID, innerText);
								if (cargo != null)
								{
									ApplyComponentDamage(cargo, val3);
								}
								break;
							}
							case "Fire":
								theAU.Damage.FireIntensity = (ActiveUnit_Damage.FireIntensityLevel)Conversions.ToByte(val3.InnerText);
								break;
							case "Mag":
							{
								string theID = val3.Name.Split(new char[1] { '_' })[1];
								string innerText = val3.ChildNodes[0].InnerText;
								Magazine magazine2 = (Magazine)FindComponentByIDOrNameUndamaged(theAU.SharedMagazines, theID, innerText);
								if (magazine2 != null)
								{
									ApplyComponentDamage(magazine2, val3);
								}
								break;
							}
							case "Mount":
							{
								string theID = val3.Name.Split(new char[1] { '_' })[1];
								string innerText = val3.ChildNodes[0].InnerText;
								Mount mount3 = (Mount)FindComponentByIDOrNameUndamaged(theAU.Mounts.ToArray(), theID, innerText);
								if (mount3 != null)
								{
									ApplyComponentDamage(mount3, val3);
								}
								break;
							}
							case "DamagePts":
								theAU.set_DamagePts(ScenEditAction: false, (Weapon)null, (float)Conversions.ToInteger(val3.InnerText));
								break;
							case "Comm":
							{
								string theID = val3.Name.Split(new char[1] { '_' })[1];
								string innerText = val3.ChildNodes[0].InnerText;
								CommDevice commDevice2 = (CommDevice)FindComponentByIDOrNameUndamaged(theAU.Comms_ReadOnly, theID, innerText);
								if (commDevice2 != null)
								{
									ApplyComponentDamage(commDevice2, val3);
								}
								break;
							}
							case "Flood":
								theAU.Damage.FloodIntensity = (ActiveUnit_Damage.FloodingIntensityLevel)Conversions.ToByte(val3.InnerText);
								break;
							case "DockFacility":
							{
								string theID = val3.Name.Split(new char[1] { '_' })[1];
								string innerText = val3.ChildNodes[0].InnerText;
								DockFacility dockFacility2 = (DockFacility)FindComponentByIDOrNameUndamaged(theAU.DockFacilities_ReadOnly, theID, innerText);
								if (dockFacility2 != null)
								{
									ApplyComponentDamage(dockFacility2, val3);
								}
								break;
							}
							case "Engine":
							{
								string theID = val3.Name.Split(new char[1] { '_' })[1];
								string innerText = val3.ChildNodes[0].InnerText;
								Engine engine = (Engine)FindComponentByIDOrNameUndamaged(theAU.Propulsion.ToArray(), theID, innerText);
								if (engine != null)
								{
									ApplyComponentDamage(engine, val3);
								}
								break;
							}
							case "Sensor":
							{
								string theID = val3.Name.Split(new char[1] { '_' })[1];
								string innerText = val3.ChildNodes[0].InnerText;
								Sensor sensor4 = (Sensor)FindComponentByIDOrNameUndamaged(theAU.Sensors_Cached, theID, innerText);
								if (sensor4 != null)
								{
									ApplyComponentDamage(sensor4, val3);
								}
								break;
							}
							case "AirFacility":
							{
								string theID = val3.Name.Split(new char[1] { '_' })[1];
								string innerText = val3.ChildNodes[0].InnerText;
								AirFacility airFacility3 = (AirFacility)FindComponentByIDOrNameUndamaged(theAU.AirFacilities_ReadOnly, theID, innerText);
								if (airFacility3 != null)
								{
									ApplyComponentDamage(airFacility3, val3);
								}
								break;
							}
							}
						}
						break;
					case "MagAdd":
					{
						int num2 = Conversions.ToInteger(val.Name.Split(new char[1] { '_' })[1]);
						if (num2 > 0)
						{
							string theQuery4 = "SELECT Name from DataMagazine where ID = " + Conversions.ToString(num2);
							if (DBCache.GetDatatable(theHelper, theQuery4).Rows.Count == 0)
							{
								text6 = "ERROR: MAGAZINE WITH DBID " + Conversions.ToString(num2) + " COULD NOT BE ADDED, NOT FOUND IN DATABASE!";
								StreamWriter streamWriter4 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter4.Write("\r\n    " + text6);
								streamWriter4.Close();
								ErrorCount++;
							}
							else
							{
								Magazine magazine = DBFunctions.GetMagazine(num2, ref theScen);
								((Platform)theAU).AddSharedMagazine(magazine);
								magazine.ParentPlatform = theAU;
								text6 = "Added magazine, DBID: " + Conversions.ToString(num2) + " Name " + magazine.Name;
								StreamWriter streamWriter5 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter5.Write("\r\n    " + text6);
								streamWriter5.Close();
							}
						}
						break;
					}
					case "Mount":
					{
						int num5 = Conversions.ToInteger(val.Name.Split(new char[1] { '_' })[1]);
						int num6;
						try
						{
							num6 = Conversions.ToInteger(val.Name.Split(new char[1] { '_' })[2]);
						}
						catch (Exception projectError15)
						{
							ProjectData.SetProjectError(projectError15);
							num6 = 0;
							if (num5 != 0)
							{
								text6 = "ERROR: MOUNT WITH INDEX " + Conversions.ToString(num5) + " HAS NO DBID LISTED (Example: <Mount_<MountIndex>_<MountDBID>> ). THIS MAY CAUSE THE WRONG MOUNT TO BE UPDATED IN CASE A DATABASE UPDATE ALTERS THE MOUNT INDEX!";
								StreamWriter streamWriter41 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter41.Write("\r\n    " + text6);
								streamWriter41.Close();
								ErrorCount++;
							}
							ProjectData.ClearProjectError();
						}
						try
						{
							int num11;
							if (num5 != 0)
							{
								if (theAU.Mounts[num5 - 1].DBID == num6 || num6 == 0)
								{
									Scenario scenario_ = theScen;
									ObservableList<Mount> mounts;
									int l;
									Mount mount_ = (mounts = theAU.Mounts)[l = num5 - 1];
									int num15 = smethod_1(scenario_, ref mount_, val, num5);
									mounts[l] = mount_;
									num11 = num15;
									break;
								}
								text6 = "ERROR: MOUNT WITH INDEX " + Conversions.ToString(num5) + " DOES NOT MATCH DBID " + Conversions.ToString(num6) + "! A DATABASE UPDATE MAY HAVE ALTERED THE MOUNT INDEX, YOU NEED TO CHANGE THE MOUNT INDEX TO THE CORRECT VALUE!";
								StreamWriter streamWriter42 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter42.Write("\r\n    " + text6);
								streamWriter42.Close();
								ErrorCount++;
								break;
							}
							num11 = 0;
							text6 = "Updating all relevant Mounts:";
							StreamWriter streamWriter43 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter43.Write("\r\n    " + text6);
							streamWriter43.Close();
							foreach (Mount mount4 in theAU.Mounts)
							{
								Mount mount_2 = mount4;
								int num12 = smethod_1(theScen, ref mount_2, val, num5);
								num11 += num12;
							}
							if (num11 == 0)
							{
								text6 = "ERROR: ATTEMPTING TO UPDATE ALL RELEVANT MOUNTS, COULD NOT FIND ANY MOUNTS TO UPDATE!";
								StreamWriter streamWriter44 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter44.Write("\r\n      " + text6);
								streamWriter44.Close();
								ErrorCount++;
							}
						}
						catch (Exception projectError16)
						{
							ProjectData.SetProjectError(projectError16);
							text6 = "ERROR: MOUNT WITH INDEX " + Conversions.ToString(num5) + " DOES NOT EXIST ON UNIT!";
							StreamWriter streamWriter45 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter45.Write("\r\n    " + text6);
							streamWriter45.Close();
							ErrorCount++;
							ProjectData.ClearProjectError();
						}
						break;
					}
					case "CustomOODA":
					{
						short result = 0;
						foreach (XmlNode childNode4 in val.ChildNodes)
						{
							text7 = childNode4.Name;
							if (short.TryParse(childNode4.InnerText, out result))
							{
								switch (text7)
								{
								case "Evasion":
									theAU.HasCustomOODA = true;
									theAU.OODA_Evasion = result;
									break;
								case "Targeting":
									theAU.HasCustomOODA = true;
									theAU.OODA_Targeting = result;
									break;
								case "Detection":
									theAU.HasCustomOODA = true;
									theAU.OODA_Detection = result;
									break;
								}
							}
						}
						break;
					}
					case "CargoAdd":
					{
						closure$__15- = new _Closure$__15-0(closure$__15-);
						_Closure$__15-0 closure$__15-2 = closure$__15-;
						XmlNode theNode2 = val.FirstChild;
						ConcurrentDictionary<string, ScenarioObject> theDictionary = null;
						closure$__15-2.$VB$Local_theCargo = Cargo.FromXML(ref theNode2, ref theDictionary, theScen, theAU);
						if (IsUnitCloningOperation)
						{
							closure$__15-.$VB$Local_theCargo.ResetIDs();
						}
						if (theAU.OnboardCargo.FirstOrDefault(closure$__15-._Lambda$__0) == null)
						{
							ArrayExtensions.Add(ref theAU.OnboardCargo, closure$__15-.$VB$Local_theCargo);
							closure$__15-.$VB$Local_theCargo.PostDeserializationHousekeeping_General(ref theAU.ParentScen, null, GameIsRunning: false);
							text6 = "added cargo " + closure$__15-.$VB$Local_theCargo.CargoObjectName;
							StreamWriter streamWriter6 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter6.Write("\r\n      " + text6);
							streamWriter6.Close();
						}
						break;
					}
					case "CommAdd":
					{
						int num14 = Conversions.ToInteger(val.Name.Split(new char[1] { '_' })[1]);
						if (num14 > 0)
						{
							string theQuery6 = "SELECT Name from DataComm where ID = " + Conversions.ToString(num14);
							if (DBCache.GetDatatable(theHelper, theQuery6).Rows.Count != 0)
							{
								CommDevice commDevice = DBFunctions.GetCommDevice(num14, ref theAU);
								theAU.AddCommDevice(commDevice);
								commDevice.ParentPlatform = theAU;
								text6 = "Added comms gear, DBID: " + Conversions.ToString(num14) + " Name: " + commDevice.Name;
								StreamWriter streamWriter49 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter49.Write("\r\n    " + text6);
								streamWriter49.Close();
							}
							else
							{
								text6 = "ERROR: COMM WITH DBID " + Conversions.ToString(num14) + " COULD NOT BE ADDED, NOT FOUND IN DATABASE!";
								StreamWriter streamWriter50 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter50.Write("\r\n    " + text6);
								streamWriter50.Close();
								ErrorCount++;
							}
						}
						break;
					}
					case "Mag":
					{
						int num9 = Conversions.ToInteger(val.Name.Split(new char[1] { '_' })[1]);
						int num2;
						try
						{
							num2 = Conversions.ToInteger(val.Name.Split(new char[1] { '_' })[2]);
						}
						catch (Exception projectError11)
						{
							ProjectData.SetProjectError(projectError11);
							num2 = 0;
							if (num9 != 0)
							{
								text6 = "ERROR: MAGAZINE WITH INDEX " + Conversions.ToString(num9) + " HAS NO DBID LISTED (Example: <Mag_<MagIndex>_<MagDBID>> ). THIS MAY CAUSE THE WRONG MAGAZINE TO BE UPDATED IN CASE A DATABASE UPDATE ALTERS THE MAGAZINE INDEX!";
								StreamWriter streamWriter33 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter33.Write("\r\n    " + text6);
								streamWriter33.Close();
								ErrorCount++;
							}
							ProjectData.ClearProjectError();
						}
						try
						{
							if (num9 == 0)
							{
								int num11 = 0;
								text6 = "Updating all relevant Magazines:";
								StreamWriter streamWriter34 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter34.Write("\r\n    " + text6);
								streamWriter34.Close();
								Magazine[] sharedMagazines = theAU.SharedMagazines;
								for (int l = 0; l < sharedMagazines.Length; l = checked(l + 1))
								{
									Magazine magazine_ = sharedMagazines[l];
									int num12 = smethod_2(theScen, ref magazine_, val, num9, bool_0: false);
									num11 += num12;
								}
								if (num11 == 0)
								{
									text6 = "ERROR: COULD NOT FIND ANY MAGAZINES TO UPDATE!";
									StreamWriter streamWriter35 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter35.Write("\r\n      " + text6);
									streamWriter35.Close();
									ErrorCount++;
								}
							}
							else if (theAU.SharedMagazines[num9 - 1].DBID == num2 || num2 == 0)
							{
								int num11 = smethod_2(theScen, ref theAU.SharedMagazines[num9 - 1], val, num9, bool_0: false);
							}
							else
							{
								text6 = "ERROR: MAGAZINE WITH INDEX " + Conversions.ToString(num9) + " DOES NOT MATCH DBID " + Conversions.ToString(num2) + "! A DATABASE UPDATE MAY HAVE ALTERED THE MAGAZINE INDEX, YOU NEED TO CHANGE THE MOUNT INDEX TO THE CORRECT VALUE!";
								StreamWriter streamWriter36 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter36.Write("\r\n    " + text6);
								streamWriter36.Close();
								ErrorCount++;
							}
						}
						catch (Exception projectError12)
						{
							ProjectData.SetProjectError(projectError12);
							text6 = "ERROR: MAGAZINE WITH INDEX " + Conversions.ToString(num9 - 1) + " DOES NOT EXIST ON UNIT!";
							StreamWriter streamWriter37 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter37.Write("\r\n    " + text6);
							streamWriter37.Close();
							ErrorCount++;
							ProjectData.ClearProjectError();
						}
						break;
					}
					case "MCMRemove":
					{
						int num3 = Conversions.ToInteger(val.Name.Split(new char[1] { '_' })[1]);
						try
						{
							num4 = Conversions.ToInteger(val.Name.Split(new char[1] { '_' })[2]);
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							num4 = 0;
							if (num3 != 0)
							{
								text6 = "ERROR: SENSOR WITH INDEX " + Conversions.ToString(num3) + " HAS NO DBID LISTED (Example: <SensorRemove_<SensorIndex>_<SensorDBID> ). THIS MAY CAUSE THE WRONG SENSOR TO BE DELETED IN CASE A DATABASE UPDATE ALTERS THE SENSOR INDEX!";
								StreamWriter streamWriter7 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter7.Write("\r\n    " + text6);
								streamWriter7.Close();
								ErrorCount++;
							}
							ProjectData.ClearProjectError();
						}
						if (num3 <= 0)
						{
							break;
						}
						try
						{
							if (num4 == theAU.MineCountermeasures[num3 - 1].DBID)
							{
								string name = theAU.MineCountermeasures[num3 - 1].Name;
								list.Add((text7, num3, num4, name));
								break;
							}
							text6 = "ERROR: SENSOR WITH INDEX " + Conversions.ToString(num3) + " ON THE UNIT DOES NOT HAVE A DBID OF " + Conversions.ToString(num4);
							StreamWriter streamWriter8 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter8.Write("\r\n    " + text6);
							streamWriter8.Close();
							ErrorCount++;
						}
						catch (Exception projectError2)
						{
							ProjectData.SetProjectError(projectError2);
							text6 = "ERROR: SENSOR WITH INDEX " + Conversions.ToString(num3) + " AND DBID " + Conversions.ToString(num4) + " COULD NOT BE DELETED, NOT FOUND ON UNIT!";
							StreamWriter streamWriter9 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter9.Write("\r\n    " + text6);
							streamWriter9.Close();
							ErrorCount++;
							ProjectData.ClearProjectError();
						}
						break;
					}
					case "MagRemove":
					{
						int num9 = Conversions.ToInteger(val.Name.Split(new char[1] { '_' })[1]);
						int num2;
						try
						{
							num2 = Conversions.ToInteger(val.Name.Split(new char[1] { '_' })[2]);
						}
						catch (Exception projectError7)
						{
							ProjectData.SetProjectError(projectError7);
							num2 = 0;
							if (num9 != 0)
							{
								text6 = "ERROR: MAGAZINE WITH INDEX " + Conversions.ToString(num9) + " HAS NO DBID LISTED (Example: <MagRemove_<MagIndex>_<MagDBID> ). THIS MAY CAUSE THE WRONG MAGAZINE TO BE DELETED IN CASE A DATABASE UPDATE ALTERS THE MAGAZINE INDEX!";
								StreamWriter streamWriter21 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter21.Write("\r\n    " + text6);
								streamWriter21.Close();
								ErrorCount++;
							}
							ProjectData.ClearProjectError();
						}
						if (num9 <= 0)
						{
							break;
						}
						try
						{
							if (theAU.SharedMagazines[num9 - 1].DBID == num2)
							{
								string name5 = theAU.SharedMagazines[num9 - 1].Name;
								list.Add((text7, num9, num2, name5));
								break;
							}
							text6 = "ERROR: MAG WITH INDEX " + Conversions.ToString(num9) + " ON THE UNIT DOES NOT HAVE A DBID OF " + Conversions.ToString(num2);
							StreamWriter streamWriter22 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter22.Write("\r\n    " + text6);
							streamWriter22.Close();
							ErrorCount++;
						}
						catch (Exception projectError8)
						{
							ProjectData.SetProjectError(projectError8);
							text6 = "ERROR: MAGAZINE WITH INDEX " + Conversions.ToString(num9) + " AND DBID " + Conversions.ToString(num2) + " COULD NOT BE DELETED, NOT FOUND ON UNIT!";
							StreamWriter streamWriter23 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter23.Write("\r\n    " + text6);
							streamWriter23.Close();
							ErrorCount++;
							ProjectData.ClearProjectError();
						}
						break;
					}
					case "DockRemove":
					{
						int num8 = Conversions.ToInteger(val.Name.Split(new char[1] { '_' })[1]);
						int num;
						try
						{
							num = Conversions.ToInteger(val.Name.Split(new char[1] { '_' })[2]);
						}
						catch (Exception projectError19)
						{
							ProjectData.SetProjectError(projectError19);
							num = 0;
							if (num8 != 0)
							{
								text6 = "ERROR: DOCK FACILITY WITH INDEX " + Conversions.ToString(num8) + " HAS NO DBID LISTED (Example: <DockRemove_<Index>_<DBID> ). THIS MAY CAUSE THE WRONG FACILITY TO BE DELETED IN CASE A DATABASE UPDATE ALTERS THE INDEX!";
								StreamWriter streamWriter51 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter51.Write("\r\n    " + text6);
								streamWriter51.Close();
								ErrorCount++;
							}
							ProjectData.ClearProjectError();
						}
						if (num8 <= 0)
						{
							break;
						}
						try
						{
							if (num == theAU.DockFacilities_ReadOnly[num8 - 1].DBID)
							{
								string name4 = theAU.DockFacilities_ReadOnly[num8 - 1].Name;
								list.Add((text7, num8, num, name4));
								break;
							}
							text6 = "ERROR: DOCK FACILITY WITH INDEX " + Conversions.ToString(num8) + " ON THE UNIT DOES NOT HAVE A DBID OF " + Conversions.ToString(num);
							StreamWriter streamWriter52 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter52.Write("\r\n    " + text6);
							streamWriter52.Close();
							ErrorCount++;
						}
						catch (Exception projectError20)
						{
							ProjectData.SetProjectError(projectError20);
							text6 = "ERROR: DOCK FACILITY WITH INDEX " + Conversions.ToString(num8) + " AND DBID " + Conversions.ToString(num) + " COULD NOT BE DELETED, NOT FOUND ON UNIT!";
							StreamWriter streamWriter53 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter53.Write("\r\n    " + text6);
							streamWriter53.Close();
							ErrorCount++;
							ProjectData.ClearProjectError();
						}
						break;
					}
					case "SetFuel":
					{
						float num10 = 0f;
						if (theAU.IsAircraft)
						{
							num10 = float.Parse(val.Name.Split(new char[1] { '_' })[1].Replace(",", "."), CultureInfo.InvariantCulture);
							((Aircraft)theAU).FuelCapacitySet(num10);
							text6 = "Set Fuel: " + Conversions.ToString(num10);
							StreamWriter streamWriter24 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter24.Write("\r\n    " + text6);
							streamWriter24.Close();
						}
						else if (!theAU.IsFacility && (theAU.IsShip || theAU.IsSubmarine))
						{
							FuelRec._FuelType theType = (FuelRec._FuelType)Conversions.ToShort(val.Name.Split(new char[1] { '_' })[1].Replace(",", "."));
							num10 = float.Parse(val.Name.Split(new char[1] { '_' })[2].Replace(",", "."), CultureInfo.InvariantCulture);
							theAU.FuelCapacitySet(num10, theType);
							text6 = "Set Fuel: " + theType.ToString() + " to " + Conversions.ToString(num10);
							StreamWriter streamWriter25 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter25.Write("\r\n    " + text6);
							streamWriter25.Close();
						}
						break;
					}
					case "SensorAdd":
					{
						num4 = Conversions.ToInteger(val.Name.Split(new char[1] { '_' })[1]);
						bool flag2 = false;
						bool flag3 = false;
						if (num4 <= 0)
						{
							break;
						}
						string theQuery7 = "SELECT Name from DataSensor where ID = " + Conversions.ToString(num4);
						if (DBCache.GetDatatable(theHelper, theQuery7).Rows.Count != 0)
						{
							int int_ = num4;
							SQLiteConnection sqliteConnection_ = theAU.ParentScen.DBConnection;
							Sensor sensor3 = DBFunctions.GetSensor(int_, ref sqliteConnection_);
							theAU.AddSensor(sensor3);
							sensor3.ParentPlatform = theAU;
							foreach (XmlNode childNode5 in val.ChildNodes)
							{
								XmlNode theNode4 = childNode5;
								switch (theNode4.Name)
								{
								case "Coverage_Illuminate":
								case "Cov_Ill":
									sensor3.Coverage_Illuminate = PlatformComponent._Coverage.FromXML(ref theNode4);
									flag3 = true;
									break;
								case "Coverage":
								case "Cov":
									sensor3.Coverage = PlatformComponent._Coverage.FromXML(ref theNode4);
									flag2 = true;
									break;
								}
							}
							text6 = "Added sensor, DBID: " + Conversions.ToString(num4) + " Name: " + sensor3.Name;
							StreamWriter streamWriter54 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter54.Write("\r\n    " + text6);
							streamWriter54.Close();
							if (!flag2)
							{
								text6 = "ERROR: SENSOR WITH DBID " + Conversions.ToString(num4) + " HAS NO ARCS SET!";
								StreamWriter streamWriter55 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter55.Write("\r\n    " + text6);
								streamWriter55.Close();
								ErrorCount++;
							}
							if (!flag3)
							{
								text6 = "ERROR: SENSOR WITH DBID " + Conversions.ToString(num4) + " HAS NO ILLUMINATION ARCS SET!";
								StreamWriter streamWriter56 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter56.Write("\r\n    " + text6);
								streamWriter56.Close();
								ErrorCount++;
							}
						}
						else
						{
							text6 = "ERROR: MAGAZINE WITH DBID " + Conversions.ToString(num4) + " COULD NOT BE ADDED, NOT FOUND IN DATABASE!";
							StreamWriter streamWriter57 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter57.Write("\r\n    " + text6);
							streamWriter57.Close();
							ErrorCount++;
						}
						break;
					}
					case "MountRemove":
					{
						int num5 = Conversions.ToInteger(val.Name.Split(new char[1] { '_' })[1]);
						int num6;
						try
						{
							num6 = Conversions.ToInteger(val.Name.Split(new char[1] { '_' })[2]);
						}
						catch (Exception projectError17)
						{
							ProjectData.SetProjectError(projectError17);
							num6 = 0;
							if (num5 != 0)
							{
								text6 = "ERROR: MOUNT WITH INDEX " + Conversions.ToString(num5) + " HAS NO DBID LISTED (Example: <MountRemove_<MountIndex>_<MountDBID> ). THIS MAY CAUSE THE WRONG MOUNT TO BE DELETED IN CASE A DATABASE UPDATE ALTERS THE MOUNT INDEX!";
								StreamWriter streamWriter46 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter46.Write("\r\n    " + text6);
								streamWriter46.Close();
								ErrorCount++;
							}
							ProjectData.ClearProjectError();
						}
						if (num5 <= 0)
						{
							break;
						}
						try
						{
							if (theAU.Mounts[num5 - 1].DBID == num6)
							{
								string name2 = theAU.Mounts[num5 - 1].Name;
								list.Add((text7, num5, num6, name2));
								break;
							}
							text6 = "ERROR: MOUNT WITH INDEX " + Conversions.ToString(num5) + " ON THE UNIT DOES NOT HAVE A DBID OF " + Conversions.ToString(num6);
							StreamWriter streamWriter47 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter47.Write("\r\n    " + text6);
							streamWriter47.Close();
							ErrorCount++;
						}
						catch (Exception projectError18)
						{
							ProjectData.SetProjectError(projectError18);
							text6 = "ERROR: MOUNT WITH INDEX " + Conversions.ToString(num5) + " AND DBID " + Conversions.ToString(num6) + " COULD NOT BE DELETED, NOT FOUND ON UNIT!";
							StreamWriter streamWriter48 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter48.Write("\r\n    " + text6);
							streamWriter48.Close();
							ErrorCount++;
							ProjectData.ClearProjectError();
						}
						break;
					}
					case "CommRemove":
					{
						int num13 = Conversions.ToInteger(val.Name.Split(new char[1] { '_' })[1]);
						int num14;
						try
						{
							num14 = Conversions.ToInteger(val.Name.Split(new char[1] { '_' })[2]);
						}
						catch (Exception projectError13)
						{
							ProjectData.SetProjectError(projectError13);
							num14 = 0;
							if (num13 != 0)
							{
								text6 = "ERROR: COMM WITH INDEX " + Conversions.ToString(num13) + " HAS NO DBID LISTED (Example: <CommRemove_<CommIndex>_<CommDBID> ). THIS MAY CAUSE THE WRONG COMM GEAR TO BE DELETED IN CASE A DATABASE UPDATE ALTERS THE COMM INDEX!";
								StreamWriter streamWriter38 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter38.Write("\r\n    " + text6);
								streamWriter38.Close();
								ErrorCount++;
							}
							ProjectData.ClearProjectError();
						}
						if (num13 <= 0)
						{
							break;
						}
						try
						{
							if (num14 == theAU.Comms_ReadOnly[num13 - 1].DBID)
							{
								string name6 = theAU.Comms_ReadOnly[num13 - 1].Name;
								list.Add((text7, num13, num14, name6));
								break;
							}
							text6 = "ERROR: COMM GEAR WITH INDEX " + Conversions.ToString(num13) + " ON THE UNIT DOES NOT HAVE A DBID OF " + Conversions.ToString(num14);
							StreamWriter streamWriter39 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter39.Write("\r\n    " + text6);
							streamWriter39.Close();
							ErrorCount++;
						}
						catch (Exception projectError14)
						{
							ProjectData.SetProjectError(projectError14);
							text6 = "ERROR: COMM GEAR WITH INDEX " + Conversions.ToString(num13) + " AND DBID " + Conversions.ToString(num14) + " COULD NOT BE DELETED, NOT FOUND ON UNIT!";
							StreamWriter streamWriter40 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter40.Write("\r\n    " + text6);
							streamWriter40.Close();
							ErrorCount++;
							ProjectData.ClearProjectError();
						}
						break;
					}
					case "SensorRemove":
					{
						int num3 = Conversions.ToInteger(val.Name.Split(new char[1] { '_' })[1]);
						try
						{
							num4 = Conversions.ToInteger(val.Name.Split(new char[1] { '_' })[2]);
						}
						catch (Exception projectError9)
						{
							ProjectData.SetProjectError(projectError9);
							num4 = 0;
							if (num3 != 0)
							{
								text6 = "ERROR: SENSOR WITH INDEX " + Conversions.ToString(num3) + " HAS NO DBID LISTED (Example: <SensorRemove_<SensorIndex>_<SensorDBID> ). THIS MAY CAUSE THE WRONG SENSOR TO BE DELETED IN CASE A DATABASE UPDATE ALTERS THE SENSOR INDEX!";
								StreamWriter streamWriter27 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter27.Write("\r\n    " + text6);
								streamWriter27.Close();
								ErrorCount++;
							}
							ProjectData.ClearProjectError();
						}
						if (num3 <= 0)
						{
							break;
						}
						try
						{
							if (num4 == theAU.Sensors_Cached[num3 - 1].DBID)
							{
								string name = theAU.Sensors_Cached[num3 - 1].Name;
								list.Add((text7, num3, num4, name));
								break;
							}
							text6 = "ERROR: SENSOR WITH INDEX " + Conversions.ToString(num3) + " ON THE UNIT DOES NOT HAVE A DBID OF " + Conversions.ToString(num4);
							StreamWriter streamWriter28 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter28.Write("\r\n    " + text6);
							streamWriter28.Close();
							ErrorCount++;
						}
						catch (Exception projectError10)
						{
							ProjectData.SetProjectError(projectError10);
							text6 = "ERROR: SENSOR WITH INDEX " + Conversions.ToString(num3) + " AND DBID " + Conversions.ToString(num4) + " COULD NOT BE DELETED, NOT FOUND ON UNIT!";
							StreamWriter streamWriter29 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter29.Write("\r\n    " + text6);
							streamWriter29.Close();
							ErrorCount++;
							ProjectData.ClearProjectError();
						}
						break;
					}
					case "#comment":
					{
						text6 = val.InnerText;
						StreamWriter streamWriter26 = File.AppendText(GameGeneral.SBRLogFilePath);
						streamWriter26.Write("  --  " + text6);
						streamWriter26.Close();
						break;
					}
					case "AirOpsRemove":
					{
						int num8 = Conversions.ToInteger(val.Name.Split(new char[1] { '_' })[1]);
						int num;
						try
						{
							num = Conversions.ToInteger(val.Name.Split(new char[1] { '_' })[2]);
						}
						catch (Exception projectError5)
						{
							ProjectData.SetProjectError(projectError5);
							num = 0;
							if (num8 != 0)
							{
								text6 = "ERROR: AIR FACILITY WITH INDEX " + Conversions.ToString(num8) + " HAS NO DBID LISTED (Example: <AirOpsRemove_<Index>_<DBID> ). THIS MAY CAUSE THE WRONG FACILITY TO BE DELETED IN CASE A DATABASE UPDATE ALTERS THE INDEX!";
								StreamWriter streamWriter18 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter18.Write("\r\n    " + text6);
								streamWriter18.Close();
								ErrorCount++;
							}
							ProjectData.ClearProjectError();
						}
						if (num8 <= 0)
						{
							break;
						}
						try
						{
							if (num == theAU.AirFacilities_ReadOnly[num8 - 1].DBID)
							{
								string name4 = theAU.AirFacilities_ReadOnly[num8 - 1].Name;
								list.Add((text7, num8, num, name4));
								break;
							}
							text6 = "ERROR: AIR FACILITY WITH INDEX " + Conversions.ToString(num8) + " ON THE UNIT DOES NOT HAVE A DBID OF " + Conversions.ToString(num);
							StreamWriter streamWriter19 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter19.Write("\r\n    " + text6);
							streamWriter19.Close();
							ErrorCount++;
						}
						catch (Exception projectError6)
						{
							ProjectData.SetProjectError(projectError6);
							text6 = "ERROR: AIR FACILITY WITH INDEX " + Conversions.ToString(num8) + " AND DBID " + Conversions.ToString(num) + " COULD NOT BE DELETED, NOT FOUND ON UNIT!";
							StreamWriter streamWriter20 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter20.Write("\r\n    " + text6);
							streamWriter20.Close();
							ErrorCount++;
							ProjectData.ClearProjectError();
						}
						break;
					}
					case "SensorMountRemove":
					{
						int num5 = Conversions.ToInteger(val.Name.Split(new char[1] { '_' })[1]);
						int num6;
						try
						{
							num6 = Conversions.ToInteger(val.Name.Split(new char[1] { '_' })[2]);
							num4 = Conversions.ToInteger(val.Name.Split(new char[1] { '_' })[3]);
						}
						catch (Exception projectError3)
						{
							ProjectData.SetProjectError(projectError3);
							num6 = 0;
							if (num5 != 0)
							{
								text6 = "ERROR: MOUNT WITH INDEX " + Conversions.ToString(num5) + " HAS NO DBID LISTED (Example: <MountRemove_<MountIndex>_<MountDBID> ). THIS MAY CAUSE THE WRONG MOUNT TO BE DELETED IN CASE A DATABASE UPDATE ALTERS THE MOUNT INDEX!";
								StreamWriter streamWriter10 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter10.Write("\r\n    " + text6);
								streamWriter10.Close();
								ErrorCount++;
							}
							ProjectData.ClearProjectError();
						}
						if (num5 <= 0)
						{
							break;
						}
						try
						{
							if (theAU.Mounts[num5 - 1].DBID == num6)
							{
								Mount mount = theAU.Mounts[num5 - 1];
								string name2 = mount.Name;
								if (mount.Sensors_ReadOnly.Count() <= 0)
								{
									break;
								}
								Sensor[] sensors_ReadOnly = mount.Sensors_ReadOnly;
								foreach (Sensor sensor in sensors_ReadOnly)
								{
									if (sensor.DBID == num4)
									{
										mount.RemoveSensor(sensor);
										text6 = "Removed sensor from mount (" + mount.Name + "), DBID: " + Conversions.ToString(num4) + " Name: " + sensor.Name;
										StreamWriter streamWriter11 = File.AppendText(GameGeneral.SBRLogFilePath);
										streamWriter11.Write("\r\n    " + text6);
										streamWriter11.Close();
										break;
									}
								}
								break;
							}
							text6 = "ERROR: MOUNT WITH INDEX " + Conversions.ToString(num5) + " ON THE UNIT DOES NOT HAVE A DBID OF " + Conversions.ToString(num6);
							StreamWriter streamWriter12 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter12.Write("\r\n    " + text6);
							streamWriter12.Close();
							ErrorCount++;
						}
						catch (Exception projectError4)
						{
							ProjectData.SetProjectError(projectError4);
							text6 = "ERROR: MOUNT WITH INDEX " + Conversions.ToString(num5) + " AND DBID " + Conversions.ToString(num6) + " COULD NOT BE DELETED, NOT FOUND ON UNIT!";
							StreamWriter streamWriter13 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter13.Write("\r\n    " + text6);
							streamWriter13.Close();
							ErrorCount++;
							ProjectData.ClearProjectError();
						}
						break;
					}
					case "DockAdd":
					{
						int num = Conversions.ToInteger(val.Name.Split(new char[1] { '_' })[1]);
						if (num > 0)
						{
							int facilityDBID = num;
							SQLiteConnection sqliteConnection_ = theScen.DBConnection;
							DockFacility dockFacility = DBFunctions.GetDockFacility(facilityDBID, ref sqliteConnection_);
							if (dockFacility == null)
							{
								text6 = "ERROR: DOCK FACILITY WITH DBID " + Conversions.ToString(num) + " COULD NOT BE ADDED, NOT FOUND IN DATABASE!";
								StreamWriter streamWriter2 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter2.Write("\r\n    " + text6);
								streamWriter2.Close();
							}
							else
							{
								theAU.AddDockFacility(dockFacility);
								dockFacility.ParentPlatform = theAU;
								text6 = "Added dock facility, DBID: " + Conversions.ToString(num) + " Name: " + dockFacility.Name;
								StreamWriter streamWriter3 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter3.Write("\r\n    " + text6);
								streamWriter3.Close();
							}
						}
						break;
					}
					}
				}
				if (list.Count <= 0)
				{
					return;
				}
				{
					foreach (var item in list)
					{
						switch (item.Item1)
						{
						case "MagRemove":
						{
							int num9 = item.Item2;
							int num2 = item.Item3;
							if (num9 > 0)
							{
								if (theAU.SharedMagazines[num9 - 1].DBID == num2)
								{
									string name5 = theAU.SharedMagazines[num9 - 1].Name;
									((Platform)theAU).RemoveSharedMagazine(theAU.SharedMagazines[num9 - 1]);
									text6 = "Removed Mag with index " + Conversions.ToString(num9) + ", DBID: " + Conversions.ToString(num2) + " Name: " + name5;
									StreamWriter streamWriter69 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter69.Write("\r\n    " + text6);
									streamWriter69.Close();
								}
								else
								{
									text6 = "ERROR: MAG WITH INDEX " + Conversions.ToString(num9) + " ON THE UNIT DOES NOT HAVE A DBID OF " + Conversions.ToString(num2);
									StreamWriter streamWriter70 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter70.Write("\r\n    " + text6);
									streamWriter70.Close();
									ErrorCount++;
								}
							}
							break;
						}
						case "DockRemove":
						{
							int num8 = item.Item2;
							int num = item.Item3;
							if (num8 > 0)
							{
								if (num == theAU.DockFacilities_ReadOnly[num8 - 1].DBID)
								{
									string name4 = theAU.DockFacilities_ReadOnly[num8 - 1].Name;
									theAU.RemoveDockFacility(theAU.DockFacilities_ReadOnly[num8 - 1]);
									text6 = "Removed Dock Facility with index " + Conversions.ToString(num8) + ", DBID: " + Conversions.ToString(num) + " Name: " + name4;
									StreamWriter streamWriter67 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter67.Write("\r\n    " + text6);
									streamWriter67.Close();
								}
								else
								{
									text6 = "ERROR: DOCK FACILITY WITH INDEX " + Conversions.ToString(num8) + " ON THE UNIT DOES NOT HAVE A DBID OF " + Conversions.ToString(num);
									StreamWriter streamWriter68 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter68.Write("\r\n    " + text6);
									streamWriter68.Close();
									ErrorCount++;
								}
							}
							break;
						}
						case "MCMRemove":
						{
							int num3 = item.Item2;
							num4 = item.Item3;
							if (num3 > 0)
							{
								if (num4 == theAU.MineCountermeasures[num3 - 1].DBID)
								{
									string name = theAU.MineCountermeasures[num3 - 1].Name;
									theAU.RemoveSensor(theAU.MineCountermeasures[num3 - 1]);
									text6 = "Removed MCM Sensor with index " + Conversions.ToString(num3) + ", DBID: " + Conversions.ToString(num4) + " Name: " + name;
									StreamWriter streamWriter63 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter63.Write("\r\n    " + text6);
									streamWriter63.Close();
								}
								else
								{
									text6 = "ERROR: SENSOR WITH INDEX " + Conversions.ToString(num3) + " ON THE UNIT DOES NOT HAVE A DBID OF " + Conversions.ToString(num4);
									StreamWriter streamWriter64 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter64.Write("\r\n    " + text6);
									streamWriter64.Close();
									ErrorCount++;
								}
							}
							break;
						}
						case "SensorRemove":
						{
							int num3 = item.Item2;
							num4 = item.Item3;
							if (num3 > 0)
							{
								if (num4 == theAU.Sensors_Cached[num3 - 1].DBID)
								{
									string name = theAU.Sensors_Cached[num3 - 1].Name;
									theAU.RemoveSensor(theAU.Sensors_Cached[num3 - 1]);
									text6 = "Removed Sensor with index " + Conversions.ToString(num3) + ", DBID: " + Conversions.ToString(num4) + " Name: " + name;
									StreamWriter streamWriter60 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter60.Write("\r\n    " + text6);
									streamWriter60.Close();
								}
								else
								{
									text6 = "ERROR: SENSOR WITH INDEX " + Conversions.ToString(num3) + " ON THE UNIT DOES NOT HAVE A DBID OF " + Conversions.ToString(num4);
									StreamWriter streamWriter61 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter61.Write("\r\n    " + text6);
									streamWriter61.Close();
									ErrorCount++;
								}
							}
							break;
						}
						case "MountRemove":
						{
							int num5 = item.Item2;
							int num6 = item.Item3;
							if (num5 > 0)
							{
								string name2 = theAU.Mounts[num5 - 1].Name;
								theAU.Mounts.Remove(theAU.Mounts[num5 - 1]);
								text6 = ("Removed Mount with index " + Conversions.ToString(num5) + ", DBID: " + Conversions.ToString(num6) + " Name: " + name2) ?? "";
								StreamWriter streamWriter62 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter62.Write("\r\n    " + text6);
								streamWriter62.Close();
							}
							break;
						}
						case "AirOpsRemove":
						{
							int num8 = item.Item2;
							int num = item.Item3;
							if (num8 > 0)
							{
								if (num == theAU.AirFacilities_ReadOnly[num8 - 1].DBID)
								{
									string name4 = theAU.AirFacilities_ReadOnly[num8 - 1].Name;
									theAU.RemoveAirFacility(theAU.AirFacilities_ReadOnly[num8 - 1]);
									text6 = "Removed Air Facility with index " + Conversions.ToString(num8) + ", DBID: " + Conversions.ToString(num) + " Name: " + name4;
									StreamWriter streamWriter65 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter65.Write("\r\n    " + text6);
									streamWriter65.Close();
								}
								else
								{
									text6 = "ERROR: AIR FACILITY WITH INDEX " + Conversions.ToString(num8) + " ON THE UNIT DOES NOT HAVE A DBID OF " + Conversions.ToString(num);
									StreamWriter streamWriter66 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter66.Write("\r\n    " + text6);
									streamWriter66.Close();
									ErrorCount++;
								}
							}
							break;
						}
						case "CommRemove":
						{
							int num13 = item.Item2;
							int num14 = item.Item3;
							if (num13 > 0)
							{
								if (num14 == theAU.Comms_ReadOnly[num13 - 1].DBID)
								{
									string name6 = theAU.Comms_ReadOnly[num13 - 1].Name;
									theAU.RemoveCommDevice(theAU.Comms_ReadOnly[num13 - 1]);
									text6 = "Removed Comm with index " + Conversions.ToString(num13) + ", DBID: " + Conversions.ToString(num14) + " Name: " + name6;
									StreamWriter streamWriter58 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter58.Write("\r\n    " + text6);
									streamWriter58.Close();
								}
								else
								{
									text6 = "ERROR: COMM GEAR WITH INDEX " + Conversions.ToString(num13) + " ON THE UNIT DOES NOT HAVE A DBID OF " + Conversions.ToString(num14);
									StreamWriter streamWriter59 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter59.Write("\r\n    " + text6);
									streamWriter59.Close();
									ErrorCount++;
								}
							}
							break;
						}
						}
					}
					return;
				}
			}
			text6 = "  ERROR: NO UNIT WITH DBID " + Conversions.ToString(theAU.DBID) + " FOUND IN DATABASE!\r\n";
			StreamWriter streamWriter71 = File.AppendText(GameGeneral.SBRLogFilePath);
			streamWriter71.Write("\r\n  " + text6);
			streamWriter71.Close();
			ErrorCount++;
		}
		else
		{
			string text6 = "ERROR: UNIT # " + text + " DOES NOT EXIST IN SCENARIO!";
			StreamWriter streamWriter72 = File.AppendText(GameGeneral.SBRLogFilePath);
			streamWriter72.Write("\r\n  " + text6);
			streamWriter72.Close();
			ErrorCount++;
		}
	}

	public static void ApplyScriptToScenario(Scenario theScen, string theFileName, bool IsUnitCloningOperation, Stream theStream = null)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected O, but got Unknown
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		int num;
		if (theStream == null)
		{
			theStream = new FileStream(theFileName, FileMode.Open, FileAccess.Read);
			num = 0;
		}
		else
		{
			num = 0;
		}
		int ErrorCount = num;
		XmlDocument val = new XmlDocument();
		try
		{
			using (theStream)
			{
				try
				{
					val.Load(theStream);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					GameGeneral.SendMessageBoxToUI("XML file " + theFileName + " is improperly formatted, read failed!", null);
					ProjectData.ClearProjectError();
				}
			}
			XmlNode val2 = ((XmlNode)val).SelectSingleNode("/ScenarioUnits");
			string value;
			if (val2 != null)
			{
				value = "\r\nPlatform list: \r\n  DBID -- Unit name  ----  Class Info  ----  ObjectID";
				StreamWriter streamWriter = File.AppendText(GameGeneral.SBRLogFilePath);
				streamWriter.Write(value);
				streamWriter.Close();
				XmlNodeList childNodes = val2.ChildNodes;
				{
					foreach (XmlNode item in childNodes)
					{
						XmlNode val3 = item;
						string text = val3.Name.Split(new char[1] { '_' })[1];
						ActiveUnit activeUnit = ((!theScen.ActiveUnits.ContainsKey(text)) ? null : theScen.ActiveUnits[text]);
						if (activeUnit == null)
						{
							value = "ERROR: UNIT # " + text + " DOES NOT EXIST IN SCENARIO!";
							StreamWriter streamWriter2 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter2.Write("\r\n  " + value);
							streamWriter2.Close();
						}
						else
						{
							ApplyDeltaToThisUnit(val3, activeUnit, theScen, null, null, IsUnitCloningOperation, ref ErrorCount);
						}
					}
					return;
				}
			}
			value = "ERROR: NO INI CONFIGURATION FILE FOUND!";
			StreamWriter streamWriter3 = File.AppendText(GameGeneral.SBRLogFilePath);
			streamWriter3.Write("\r\n  " + value);
			streamWriter3.Close();
			GameGeneral.SendMessageBoxToUI("No XML data found.", null);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101118", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void GenerateScenarioContentsList(Scenario theScen)
	{
		HashSet<string> hashSet = new HashSet<string>();
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		try
		{
			string value = "\r\nPlatform list: \r\n  DBID -- Unit name  ----  Class Info  ----  ObjectID\r\n";
			StreamWriter streamWriter = File.AppendText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR plaform list.txt");
			streamWriter.Write(value);
			streamWriter.Close();
			string theQuery = default(string);
			string theQuery2 = default(string);
			string theQuery3 = default(string);
			foreach (ActiveUnit value2 in theScen.ActiveUnits.Values)
			{
				SQLiteHelper theHelper = new SQLiteHelper(theScen.DBConnection);
				switch (value2.UnitType)
				{
				case GlobalVariables.ActiveUnitType.Aircraft:
					theQuery = "Select YearCommissioned, YearDecommissioned from DataAircraft where ID = " + Conversions.ToString(value2.DBID);
					theQuery2 = "Select Description from EnumOperatorCountry where ID in (Select OperatorCountry from DataAircraft where ID = " + Conversions.ToString(value2.DBID) + ")";
					theQuery3 = "Select Description from EnumOperatorService where ID in (Select OperatorService from DataAircraft where ID = " + Conversions.ToString(value2.DBID) + ")";
					break;
				case GlobalVariables.ActiveUnitType.Ship:
					theQuery = "Select YearCommissioned, YearDecommissioned from DataShip where ID = " + Conversions.ToString(value2.DBID);
					theQuery2 = "Select Description from EnumOperatorCountry where ID in (Select OperatorCountry from DataShip where ID = " + Conversions.ToString(value2.DBID) + ")";
					theQuery3 = "Select Description from EnumOperatorService where ID in (Select OperatorService from DataShip where ID = " + Conversions.ToString(value2.DBID) + ")";
					break;
				case GlobalVariables.ActiveUnitType.Submarine:
					theQuery = "Select YearCommissioned, YearDecommissioned from DataSubmarine where ID = " + Conversions.ToString(value2.DBID);
					theQuery2 = "Select Description from EnumOperatorCountry where ID in (Select OperatorCountry from DataSubmarine where ID = " + Conversions.ToString(value2.DBID) + ")";
					theQuery3 = "Select Description from EnumOperatorService where ID in (Select OperatorService from DataSubmarine where ID = " + Conversions.ToString(value2.DBID) + ")";
					break;
				case GlobalVariables.ActiveUnitType.Facility:
					theQuery = "Select YearCommissioned, YearDecommissioned from DataFacility where ID = " + Conversions.ToString(value2.DBID);
					theQuery2 = "Select Description from EnumOperatorCountry where ID in (Select OperatorCountry from DataFacility where ID = " + Conversions.ToString(value2.DBID) + ")";
					theQuery3 = "Select Description from EnumOperatorService where ID in (Select OperatorService from DataFacility where ID = " + Conversions.ToString(value2.DBID) + ")";
					break;
				case GlobalVariables.ActiveUnitType.Satellite:
					theQuery = "Select YearCommissioned, YearDecommissioned from DataSatellite where ID = " + Conversions.ToString(value2.DBID);
					theQuery2 = "Select Description from EnumOperatorCountry where ID in (Select OperatorCountry from DataSatellite where ID = " + Conversions.ToString(value2.DBID) + ")";
					theQuery3 = "Select Description from EnumOperatorService where ID in (Select OperatorService from DataSatellite where ID = " + Conversions.ToString(value2.DBID) + ")";
					break;
				case GlobalVariables.ActiveUnitType.Vehicle:
					theQuery = "Select YearCommissioned, YearDecommissioned from DataGroundUnit where ID = " + Conversions.ToString(value2.DBID);
					theQuery2 = "Select Description from EnumOperatorCountry where ID in (Select OperatorCountry from DataGroundUnit where ID = " + Conversions.ToString(value2.DBID) + ")";
					theQuery3 = "Select Description from EnumOperatorService where ID in (Select OperatorService from DataGroundUnit where ID = " + Conversions.ToString(value2.DBID) + ")";
					break;
				}
				if (!(value2.IsAircraft | value2.IsFacility | value2.IsShip | value2.IsSubmarine | value2.IsSatellite))
				{
					continue;
				}
				DataTable datatable = DBCache.GetDatatable(theHelper, theQuery);
				DataTable datatable2 = DBCache.GetDatatable(theHelper, theQuery2);
				DataTable datatable3 = DBCache.GetDatatable(theHelper, theQuery3);
				if ((datatable.Rows.Count != 0) & (datatable2.Rows.Count != 0) & (datatable3.Rows.Count != 0))
				{
					DataRow dataRow = datatable.Rows[0];
					DataRow dataRow2 = datatable2.Rows[0];
					DataRow dataRow3 = datatable3.Rows[0];
					string text = Strings.Trim(dataRow2["Description"].ToString());
					string text2 = Strings.Trim(dataRow3["Description"].ToString());
					string text3 = Conversions.ToString(Conversions.ToInteger(dataRow["YearCommissioned"].ToString()));
					string text4 = Conversions.ToString(Conversions.ToInteger(dataRow["YearDecommissioned"].ToString()));
					if (value2.IsOperating())
					{
						if (!hashSet.Contains(value2.ObjectID))
						{
							hashSet.Add(value2.ObjectID);
						}
						if (!value2.IsAircraft)
						{
							value = "  " + Conversions.ToString(value2.DBID) + " -- " + value2.Name + "  ----  " + value2.UnitClass + " -- " + text + " (" + text2 + "), " + text3 + "-" + text4 + "  ----  " + value2.ObjectID + "\r\n";
						}
						else
						{
							Aircraft aircraft = (Aircraft)value2;
							value = "  " + Conversions.ToString(aircraft.DBID) + " -- " + aircraft.Name + " -- " + aircraft.UnitClass + " -- " + text + " (" + text2 + "), " + text3 + "-" + text4 + " : " + Conversions.ToString(aircraft.LoadoutDBID) + " -- " + aircraft.LoadoutName + "  ----  " + aircraft.ObjectID + "\r\n";
						}
						streamWriter = File.AppendText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR plaform list.txt");
						streamWriter.Write(value);
						streamWriter.Close();
						try
						{
							AirFacility[] airFacilities_ReadOnly = value2.AirFacilities_ReadOnly;
							foreach (AirFacility airFacility in airFacilities_ReadOnly)
							{
								foreach (Aircraft value3 in airFacility.HostedAircraft.Values)
								{
									theQuery = "Select YearCommissioned, YearDecommissioned from DataAircraft where ID = " + Conversions.ToString(value3.DBID);
									theQuery2 = "Select Description from EnumOperatorCountry where ID in (Select OperatorCountry from DataAircraft where ID = " + Conversions.ToString(value3.DBID) + ")";
									theQuery3 = "Select Description from EnumOperatorService where ID in (Select OperatorService from DataAircraft where ID = " + Conversions.ToString(value3.DBID) + ")";
									datatable = DBCache.GetDatatable(theHelper, theQuery);
									datatable2 = DBCache.GetDatatable(theHelper, theQuery2);
									datatable3 = DBCache.GetDatatable(theHelper, theQuery3);
									if ((datatable.Rows.Count != 0) & (datatable2.Rows.Count != 0) & (datatable3.Rows.Count != 0))
									{
										DataRow dataRow4 = datatable.Rows[0];
										DataRow dataRow5 = datatable2.Rows[0];
										DataRow dataRow6 = datatable3.Rows[0];
										text = Strings.Trim(dataRow5["Description"].ToString());
										text2 = Strings.Trim(dataRow6["Description"].ToString());
										text3 = dataRow4["YearCommissioned"].ToString();
										text4 = dataRow4["YearDecommissioned"].ToString();
										int num;
										if (!hashSet.Contains(value3.ObjectID))
										{
											hashSet.Add(value3.ObjectID);
											num = 21;
										}
										else
										{
											num = 21;
										}
										string[] array = new string[num];
										array[0] = "    ";
										array[1] = Conversions.ToString(value3.DBID);
										array[2] = " -- ";
										array[3] = value3.UnitClass;
										array[4] = " -- ";
										array[5] = text;
										array[6] = " (";
										array[7] = text2;
										array[8] = "), ";
										array[9] = text3;
										array[10] = "-";
										array[11] = text4;
										array[12] = " : ";
										array[13] = Conversions.ToString(value3.LoadoutDBID);
										array[14] = " -- ";
										array[15] = value3.LoadoutName;
										array[16] = "  ----  ";
										array[17] = value3.Name;
										array[18] = "  ----  ";
										array[19] = value3.ObjectID;
										array[20] = "\r\n";
										value = string.Concat(array);
										streamWriter = File.AppendText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR plaform list.txt");
										streamWriter.Write(value);
										streamWriter.Close();
										continue;
									}
									value = "  ERROR: NO AIRCRAFT WITH ID " + Conversions.ToString(value3.DBID) + " BASED ON " + value2.Name + " (" + value2.UnitClass + ") WAS FOUND IN DATABASE!\r\n";
									streamWriter = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter.Write("\r\n  " + value);
									streamWriter.Close();
									return;
								}
							}
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception ex2 = ex;
							ex2?.Data.Add("Error at 200097", ex2.Message);
							GameGeneral.WriteExceptionsToLog(ex2);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
						try
						{
							DockFacility[] dockFacilities_ReadOnly = value2.DockFacilities_ReadOnly;
							foreach (DockFacility dockFacility in dockFacilities_ReadOnly)
							{
								foreach (ActiveUnit value4 in dockFacility.HostedBoats.Values)
								{
									switch (value4.UnitType)
									{
									case GlobalVariables.ActiveUnitType.Submarine:
										theQuery = "Select YearCommissioned, YearDecommissioned from DataSubmarine where ID = " + Conversions.ToString(value4.DBID);
										theQuery2 = "Select Description from EnumOperatorCountry where ID in (Select OperatorCountry from DataSubmarine where ID = " + Conversions.ToString(value4.DBID) + ")";
										theQuery3 = "Select Description from EnumOperatorService where ID in (Select OperatorService from DataSubmarine where ID = " + Conversions.ToString(value4.DBID) + ")";
										break;
									case GlobalVariables.ActiveUnitType.Ship:
										theQuery = "Select YearCommissioned, YearDecommissioned from DataShip where ID = " + Conversions.ToString(value4.DBID);
										theQuery2 = "Select Description from EnumOperatorCountry where ID in (Select OperatorCountry from DataShip where ID = " + Conversions.ToString(value4.DBID) + ")";
										theQuery3 = "Select Description from EnumOperatorService where ID in (Select OperatorService from DataShip where ID = " + Conversions.ToString(value4.DBID) + ")";
										break;
									}
									datatable = DBCache.GetDatatable(theHelper, theQuery);
									datatable2 = DBCache.GetDatatable(theHelper, theQuery2);
									datatable3 = DBCache.GetDatatable(theHelper, theQuery3);
									if ((datatable.Rows.Count != 0) & (datatable2.Rows.Count != 0) & (datatable3.Rows.Count != 0))
									{
										DataRow dataRow7 = datatable.Rows[0];
										DataRow dataRow8 = datatable2.Rows[0];
										DataRow dataRow9 = datatable3.Rows[0];
										text = Strings.Trim(dataRow8["Description"].ToString());
										text2 = Strings.Trim(dataRow9["Description"].ToString());
										text3 = Conversions.ToString(Conversions.ToInteger(dataRow7["YearCommissioned"].ToString()));
										text4 = Conversions.ToString(Conversions.ToInteger(dataRow7["YearDecommissioned"].ToString()));
										int num2;
										if (!hashSet.Contains(value4.ObjectID))
										{
											hashSet.Add(value4.ObjectID);
											num2 = 17;
										}
										else
										{
											num2 = 17;
										}
										string[] array2 = new string[num2];
										array2[0] = "    ";
										array2[1] = Conversions.ToString(value4.DBID);
										array2[2] = " -- ";
										array2[3] = value4.Name;
										array2[4] = " -- ";
										array2[5] = text;
										array2[6] = " (";
										array2[7] = text2;
										array2[8] = "), ";
										array2[9] = text3;
										array2[10] = "-";
										array2[11] = text4;
										array2[12] = "  ----  ";
										array2[13] = value4.UnitClass;
										array2[14] = "  ----  ";
										array2[15] = value4.ObjectID;
										array2[16] = "\r\n";
										value = string.Concat(array2);
										streamWriter = File.AppendText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR plaform list.txt");
										streamWriter.Write(value);
										streamWriter.Close();
										continue;
									}
									value = "  ERROR: NO SHIP WITH ID " + Conversions.ToString(value4.DBID) + " BASED ON " + value2.Name + " (" + value2.UnitClass + ") WAS FOUND IN DATABASE!\r\n";
									streamWriter = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter.Write("\r\n  " + value);
									streamWriter.Close();
									return;
								}
							}
						}
						catch (Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							Exception ex4 = ex3;
							ex4?.Data.Add("Error at 200098", ex4.Message);
							GameGeneral.WriteExceptionsToLog(ex4);
							ProjectData.ClearProjectError();
						}
					}
					else
					{
						if (value2.IsAircraft)
						{
							Aircraft aircraft2 = (Aircraft)value2;
							value = "  " + Conversions.ToString(aircraft2.DBID) + " -- " + aircraft2.Name + " -- " + aircraft2.UnitClass + " -- " + text + " (" + text2 + "), " + text3 + "-" + text4 + " : " + Conversions.ToString(aircraft2.LoadoutDBID) + " -- " + aircraft2.LoadoutName + "  ----  " + aircraft2.ObjectID + "\r\n";
						}
						else
						{
							value = "  " + Conversions.ToString(value2.DBID) + " -- " + value2.Name + "  ----  " + value2.UnitClass + " -- " + text + " (" + text2 + "), " + text3 + "-" + text4 + "  ----  " + value2.ObjectID + "\r\n";
						}
						dictionary.Add(value2.ObjectID, value);
					}
					continue;
				}
				value = "  ERROR: NO UNIT WITH ID " + Conversions.ToString(value2.DBID) + " FOUND IN DATABASE!\r\n";
				streamWriter = File.AppendText(GameGeneral.SBRLogFilePath);
				streamWriter.Write("\r\n  " + value);
				streamWriter.Close();
				return;
			}
			streamWriter = File.AppendText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR plaform list.txt");
			foreach (KeyValuePair<string, string> item in dictionary)
			{
				if (!hashSet.Contains(item.Key))
				{
					streamWriter.Write(item.Value);
				}
			}
			streamWriter.Close();
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			ex6?.Data.Add("Error at 101119", "");
			GameGeneral.WriteExceptionsToLog(ex6);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void ApplyEMCON_ToScenario(ref Scenario scenario_0)
	{
		foreach (ActiveUnit activeUnits_ in scenario_0.ActiveUnits_List)
		{
			if (activeUnits_ == null)
			{
				continue;
			}
			if (activeUnits_.IsAircraft)
			{
				((Aircraft)activeUnits_).Sensory.vmethod_2(activeUnits_.Sensors_Cached);
			}
			else if (!activeUnits_.IsFacility)
			{
				if (!activeUnits_.IsShip)
				{
					if (activeUnits_.IsSubmarine)
					{
						((Submarine)activeUnits_).Sensory.vmethod_2(activeUnits_.Sensors_Cached);
					}
					else if (activeUnits_.IsSatellite)
					{
						((Satellite)activeUnits_).Sensory.vmethod_2(activeUnits_.Sensors_Cached);
					}
				}
				else
				{
					((Ship)activeUnits_).Sensory.vmethod_2(activeUnits_.Sensors_Cached);
				}
			}
			else
			{
				((Facility)activeUnits_).Sensory.vmethod_2(activeUnits_.Sensors_Cached);
			}
		}
	}

	public static bool AllInOne(string theFileName, DBRecord useThisDB = null)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Expected O, but got Unknown
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Expected O, but got Unknown
		//IL_07e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Expected O, but got Unknown
		FileStream fileStream = new FileStream(theFileName, FileMode.Open, FileAccess.Read);
		Scenario scenario = null;
		int num = 0;
		XmlDocument val = new XmlDocument();
		try
		{
			using (fileStream)
			{
				try
				{
					val.Load((Stream)fileStream);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					GameGeneral.SendMessageBoxToUI("Scenario List file is improperly formatted, read failed!.", null);
					ProjectData.ClearProjectError();
				}
			}
			XmlNode val2 = ((XmlNode)val).SelectSingleNode("/ScenarioList");
			if (val2 == null)
			{
				GameGeneral.SendMessageBoxToUI("Scenario List file is improperly formatted, read failed!.", null);
			}
			else
			{
				string text = "-------------------------------------------\r\nBatch file: " + theFileName + "\r\nDB:   " + useThisDB.FileName + "\r\n";
				File.AppendAllText(GameGeneral.SBRLogFilePath, "\r\n\r\n" + text);
				File.AppendAllText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR plaform list.txt", "\r\n" + text);
				XmlNodeList childNodes = val2.ChildNodes;
				Scenario theScen = scenario;
				string text3 = default(string);
				int num2 = default(int);
				DBOps.DBFileCheckResult theResult = default(DBOps.DBFileCheckResult);
				foreach (XmlNode item in childNodes)
				{
					XmlNode val3 = item;
					StreamWriter streamWriter;
					try
					{
						string text2 = "";
						text3 = "";
						foreach (XmlNode childNode in val3.ChildNodes)
						{
							XmlNode val4 = childNode;
							string text4 = val4.Name.Split(new char[1] { '_' })[0];
							if (Operators.CompareString(text4, "ScenarioFilePath", false) == 0)
							{
								try
								{
									foreach (XmlNode childNode2 in val4.ChildNodes)
									{
										XmlNode val5 = childNode2;
										string text5 = val5.Name.Split(new char[1] { '_' })[0];
										if (Operators.CompareString(text5, "#comment", false) == 0)
										{
											text3 = val5.InnerText;
											text3 = text3.Trim();
										}
									}
								}
								catch (Exception projectError2)
								{
									ProjectData.SetProjectError(projectError2);
									GameGeneral.SendMessageBoxToUI("No scenario file path found!.", null);
									ProjectData.ClearProjectError();
								}
							}
							else
							{
								if (Operators.CompareString(text4, "ConfigFilePath", false) != 0)
								{
									continue;
								}
								try
								{
									foreach (XmlNode childNode3 in val4.ChildNodes)
									{
										XmlNode val6 = childNode3;
										string text5 = val6.Name.Split(new char[1] { '_' })[0];
										if (Operators.CompareString(text5, "#comment", false) == 0)
										{
											text2 = val6.InnerText;
											text2 = text2.Trim();
										}
									}
								}
								catch (Exception projectError3)
								{
									ProjectData.SetProjectError(projectError3);
									GameGeneral.SendMessageBoxToUI("No config file path found!.", null);
									ProjectData.ClearProjectError();
								}
							}
						}
						num2++;
						if (!FileExistsNative.FileExistsFast(text3))
						{
							text = "Scenario " + Conversions.ToString(num2) + " File: " + text3 + " ERROR! LOAD FAILED!";
							streamWriter = File.AppendText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR log file.txt");
							streamWriter.Write("\r\n\r\n" + text);
							streamWriter.Close();
							streamWriter = File.AppendText(GameGeneral.LogsPath + "SBR plaform list.txt");
							streamWriter.Write("\r\n\r\n" + text);
							streamWriter.Close();
							goto IL_086e;
						}
						if (theScen != null)
						{
							GameGeneral.DestroyPreviousScenario(ref theScen, ClearLuaSandbox: true);
						}
						ScenContainer scenContainer = ScenContainer.LoadFromFile(text3);
						string ErrorFeedback = "";
						scenario = scenContainer.GetScenarioObject(ref ErrorFeedback, null, ForceDeepRebuild: false);
						GameGeneral.Debug_LastLoadedScenario = scenario.Title;
						text = "Scenario " + Conversions.ToString(num2) + ": " + scenario.Title + "\r\nScenario file: " + text3 + "\r\nConfig file:   " + text2;
						streamWriter = File.AppendText(GameGeneral.SBRLogFilePath);
						streamWriter.Write("\r\n\r\n" + text);
						streamWriter.Close();
						streamWriter = File.AppendText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR plaform list.txt");
						streamWriter.Write("\r\n\r\n" + text);
						streamWriter.Close();
						DBRecord dBRecordByHash = DBOps.GetDBRecordByHash(scenario.DBUsed, ref theResult);
						if (dBRecordByHash != null)
						{
							_ = scenario.DBUsed;
							string dBHash = (scenario.DBUsed = ((useThisDB == null) ? DBOps.GetHashForMostRecentVersionOfThisDB(dBRecordByHash.DBID) : useThisDB.Hash));
							List<string> list = CheckForPlatFormsMissingFromDB(scenario, dBHash, IncludeWeapons: false);
							if (list.Count <= 0)
							{
								scenario.LastSavedInScenEdit = true;
								Command_Core.LoadSave.LoadSave.SaveScenario(scenario, scenario.Sides_ReadOnly[0], text3, SBR: true);
								scenario = null;
								theScen = scenario;
								ScenContainer scenContainer2 = ScenContainer.LoadFromFile(text3);
								ErrorFeedback = "";
								scenario = scenContainer2.GetScenarioObject(ref ErrorFeedback, null, ForceDeepRebuild: true);
								List<string> list2 = CheckForAircraftCarryingIllegalLoadouts(scenario);
								if (list2.Count > 0)
								{
									text = "  ERROR: ONE OR MORE AIRCRAFT FEATURED IN THIS SCENARIO CARRY A LOADOUT THAT IS NOT IN THE AIRCRAFT'S LOADOUT LIST.\r\n  PLATFORMS ARE AS FOLLOWS:\r\n";
									foreach (string item2 in list2)
									{
										text = text + "  " + item2 + "\r\n";
									}
									text += "  Please contact the author of this DB in order to have this problem rectified.";
									streamWriter = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter.Write("\r\n" + text);
									streamWriter.Close();
								}
								if (!string.IsNullOrEmpty(text2))
								{
									ApplyScriptToScenario(scenario, text2, IsUnitCloningOperation: false);
								}
								foreach (ActiveUnit activeUnits_ in scenario.ActiveUnits_List)
								{
									if (!Information.IsNothing((object)activeUnits_))
									{
										activeUnits_.RestoreOldComponentIDs();
									}
								}
								GenerateScenarioContentsList(scenario);
								foreach (ActiveUnit activeUnits_2 in scenario.ActiveUnits_List)
								{
									activeUnits_2.Sensory.vmethod_2(activeUnits_2.Sensors_Cached);
								}
								scenario.LastSavedInScenEdit = true;
								Command_Core.LoadSave.LoadSave.SaveScenario(scenario, scenario.Sides_ReadOnly[0], text3, SBR: true);
								text = "Scenario " + Conversions.ToString(num2) + ": Rebuild Completed\r\n";
								streamWriter = File.AppendText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR log file.txt");
								streamWriter.Write("\r\n" + text);
								streamWriter.Close();
								streamWriter = File.AppendText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR plaform list.txt");
								streamWriter.Write(text);
								streamWriter.Close();
								num++;
								Application.DoEvents();
								goto IL_086e;
							}
							text = "  ERROR: ONE OR MORE PLATFORMS FEATURED IN THIS SCENARIO IS MISSING FROM THE DATABASE YOU ARE ATTEMPTING TO MIGRATE TO.\r\n  THE MISSING PLATFORMS ARE AS FOLLOWS:\r\n";
							foreach (string item3 in list)
							{
								text = text + "  " + item3 + "\r\n";
							}
							text += "  Please contact the author of this DB in order to have this problem rectified. The unit(s) have to be deleted and replaced with units that actually exist in the database.\r\n";
							text += "  MIGRATION ABORTED!";
							streamWriter = File.AppendText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR log file.txt");
							streamWriter.Close();
							text = "Scenario " + Conversions.ToString(num2) + ": ERROR! REBUILD FAILED!";
							streamWriter = File.AppendText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR log file.txt");
							streamWriter.Write("\r\n\r\n" + text);
							streamWriter.Close();
							continue;
						}
						Interaction.MsgBox((object)("Error: " + DBOps.EnglishMessageString(theResult) + "\r\nAborting..."), (MsgBoxStyle)0, (object)null);
						return false;
					}
					catch (Exception projectError4)
					{
						ProjectData.SetProjectError(projectError4);
						text = "Scenario " + Conversions.ToString(num2) + " File: " + text3 + " ERROR! LOAD FAILED!";
						streamWriter = File.AppendText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR log file.txt");
						streamWriter.Write("\r\n\r\n" + text);
						streamWriter.Close();
						ProjectData.ClearProjectError();
						goto IL_086e;
					}
					IL_086e:
					streamWriter.Dispose();
					streamWriter = null;
				}
				if (num > 0)
				{
					return true;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101120", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return false;
	}

	public static List<string> CheckForPlatFormsMissingFromDB(Scenario theScen, string DBHash, bool IncludeWeapons)
	{
		HashSet<string> hashSet = new HashSet<string>();
		List<string> list = new List<string>();
		List<string> result;
		try
		{
			DBOps.DBFileCheckResult theResult = default(DBOps.DBFileCheckResult);
			DBRecord dBRecordByHash = DBOps.GetDBRecordByHash(DBHash, ref theResult);
			if (dBRecordByHash == null)
			{
				throw new Exception(DBOps.EnglishMessageString(theResult));
			}
			List<string> list_ = dBRecordByHash.PlatFormIDs;
			Weapon[] theArray = default(Weapon[]);
			foreach (ActiveUnit activeUnits_ in theScen.ActiveUnits_List)
			{
				if (activeUnits_ == null || activeUnits_.IsAggregatedUnit)
				{
					continue;
				}
				if (!activeUnits_.IsAircraft)
				{
					if (!activeUnits_.IsShip)
					{
						if (!activeUnits_.IsSubmarine)
						{
							if (!activeUnits_.IsFacility)
							{
								if (!activeUnits_.IsMobileGroundUnit)
								{
									if (activeUnits_.IsWeapon)
									{
										if (hashSet.Contains("Weapon #" + Conversions.ToString(activeUnits_.DBID)))
										{
											continue;
										}
										hashSet.Add("Weapon #" + Conversions.ToString(activeUnits_.DBID));
										if (!list_.Contains("Weapon #" + Conversions.ToString(activeUnits_.DBID)))
										{
											list.Add("Weapon #" + Conversions.ToString(activeUnits_.DBID) + ", " + activeUnits_.Name);
										}
									}
									else if (activeUnits_.IsSatellite)
									{
										if (hashSet.Contains("Satellite #" + Conversions.ToString(activeUnits_.DBID)))
										{
											continue;
										}
										hashSet.Add("Satellite #" + Conversions.ToString(activeUnits_.DBID));
										if (!list_.Contains("Satellite #" + Conversions.ToString(activeUnits_.DBID)))
										{
											list.Add("Satellite #" + Conversions.ToString(activeUnits_.DBID) + ", " + activeUnits_.UnitClass);
										}
									}
									else if (!activeUnits_.IsGroup)
									{
										throw new NotImplementedException();
									}
								}
								else
								{
									if (hashSet.Contains("GroundUnit #" + Conversions.ToString(activeUnits_.DBID)))
									{
										continue;
									}
									hashSet.Add("GroundUnit #" + Conversions.ToString(activeUnits_.DBID));
									if (!list_.Contains("GroundUnit #" + Conversions.ToString(activeUnits_.DBID)))
									{
										list.Add("GroundUnit #" + Conversions.ToString(activeUnits_.DBID) + ", " + activeUnits_.UnitClass);
									}
								}
							}
							else
							{
								if (hashSet.Contains("Facility #" + Conversions.ToString(activeUnits_.DBID)))
								{
									continue;
								}
								hashSet.Add("Facility #" + Conversions.ToString(activeUnits_.DBID));
								if (!list_.Contains("Facility #" + Conversions.ToString(activeUnits_.DBID)))
								{
									list.Add("Facility #" + Conversions.ToString(activeUnits_.DBID) + ", " + activeUnits_.UnitClass);
								}
							}
						}
						else
						{
							if (hashSet.Contains("Submarine #" + Conversions.ToString(activeUnits_.DBID)))
							{
								continue;
							}
							hashSet.Add("Submarine #" + Conversions.ToString(activeUnits_.DBID));
							if (!list_.Contains("Submarine #" + Conversions.ToString(activeUnits_.DBID)))
							{
								list.Add("Submarine #" + Conversions.ToString(activeUnits_.DBID) + ", " + activeUnits_.UnitClass);
							}
						}
					}
					else
					{
						if (hashSet.Contains("Ship #" + Conversions.ToString(activeUnits_.DBID)))
						{
							continue;
						}
						hashSet.Add("Ship #" + Conversions.ToString(activeUnits_.DBID));
						if (!list_.Contains("Ship #" + Conversions.ToString(activeUnits_.DBID)))
						{
							list.Add("Ship #" + Conversions.ToString(activeUnits_.DBID) + ", " + activeUnits_.UnitClass);
						}
					}
				}
				else
				{
					if (hashSet.Contains("Aircraft #" + Conversions.ToString(activeUnits_.DBID)))
					{
						continue;
					}
					hashSet.Add("Aircraft #" + Conversions.ToString(activeUnits_.DBID));
					if (!list_.Contains("Aircraft #" + Conversions.ToString(activeUnits_.DBID)))
					{
						list.Add("Aircraft #" + Conversions.ToString(activeUnits_.DBID) + ", " + activeUnits_.UnitClass);
					}
				}
				if (!IncludeWeapons)
				{
					continue;
				}
				theArray = activeUnits_.Weaponry.AllDistinctWeaponsAboard_Actual().ToArray();
				Weapon[] array = theArray;
				foreach (Weapon weapon in array)
				{
					if (!hashSet.Contains("Weapon #" + Conversions.ToString(weapon.DBID)))
					{
						hashSet.Add("Weapon #" + Conversions.ToString(weapon.DBID));
						if (!list_.Contains("Weapon #" + Conversions.ToString(weapon.DBID)))
						{
							list.Add("Weapon #" + Conversions.ToString(weapon.DBID) + ", " + weapon.Name);
						}
					}
				}
			}
			if (!Information.IsNothing((object)theArray))
			{
				ArrayExtensions.Clear(ref theArray);
			}
			theArray = null;
			if (!Information.IsNothing((object)hashSet))
			{
				hashSet.Clear();
			}
			hashSet = null;
			result = list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101121", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new List<string>();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static List<string> CheckForAircraftCarryingIllegalLoadouts(Scenario theScen)
	{
		SQLiteHelper sQLiteHelper = new SQLiteHelper(theScen.DBConnection);
		List<string> list = new List<string>();
		List<string> result;
		try
		{
			foreach (ActiveUnit value in theScen.ActiveUnits.Values)
			{
				if (!value.IsAircraft)
				{
					continue;
				}
				Aircraft aircraft = (Aircraft)value;
				string string_ = "Select ID from DataAircraftLoadouts where ID = " + Conversions.ToString(aircraft.DBID) + " and ComponentID = " + Conversions.ToString(aircraft.LoadoutDBID);
				if (!((sQLiteHelper.ExecuteDataTable(string_).Rows.Count == 0) & (aircraft.LoadoutDBID > 0)))
				{
					continue;
				}
				Aircraft_AirOps airOps = aircraft.AirOps;
				string text;
				if (!value.IsOperating())
				{
					text = "Aircraft: " + aircraft.UnitClass + ", Callsign: " + aircraft.Name + ", DBID: " + Conversions.ToString(aircraft.DBID) + ", Loadout: " + aircraft.Loadout.Name + ", DBID: " + Conversions.ToString(aircraft.Loadout.DBID);
					if (airOps.CurrentHostUnit != null)
					{
						text = text + " (Parked on " + airOps.CurrentHostUnit.UnitClass + ")";
					}
				}
				else
				{
					text = "Aircraft: " + aircraft.UnitClass + ", DBID: " + Conversions.ToString(aircraft.DBID) + ", Loadout: " + aircraft.Loadout.Name + ", DBID: " + Conversions.ToString(aircraft.Loadout.DBID) + " (Airborne)";
				}
				list.Add(text);
			}
			result = list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101122", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new List<string>();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static void ProcessUnit(Scenario theScen, XmlDocument theXML, [Optional][DefaultParameterValue(null)] ref ActiveUnit theActiveUnit)
	{
		//IL_054f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0556: Expected O, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_0b85: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b8c: Expected O, but got Unknown
		//IL_1e5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e61: Expected O, but got Unknown
		//IL_0881: Unknown result type (might be due to invalid IL or missing references)
		//IL_0888: Expected O, but got Unknown
		if (((XmlNode)theXML).FirstChild == null)
		{
			return;
		}
		try
		{
			XmlNode val = ((XmlNode)theXML).SelectSingleNode("/DeltaUnit");
			string text;
			if (val == null)
			{
				text = "ERROR: NO INI CONFIGURATION FILE FOUND!";
				StreamWriter streamWriter = File.AppendText(GameGeneral.SBRLogFilePath);
				streamWriter.Write("\r\n  " + text);
				streamWriter.Close();
				GameGeneral.SendMessageBoxToUI("No XML data found.", null);
				return;
			}
			text = "\r\nPlatform list: \r\n  DBID -- Unit name  ----  Class Info  ----  ObjectID";
			StreamWriter streamWriter2 = File.AppendText(GameGeneral.SBRLogFilePath);
			streamWriter2.Write(text);
			streamWriter2.Close();
			XmlNodeList childNodes = val.ChildNodes;
			IEnumerator enumerator = childNodes.GetEnumerator();
			try
			{
				ActiveUnit theParentPlatform;
				string theQuery = default(string);
				string theQuery2 = default(string);
				string theQuery3 = default(string);
				_Closure$__22-0 closure$__22- = default(_Closure$__22-0);
				int num6 = default(int);
				while (true)
				{
					if (!enumerator.MoveNext())
					{
						return;
					}
					XmlNode val2 = (XmlNode)enumerator.Current;
					string text2 = val2.Name.Split(new char[1] { '_' })[1];
					theParentPlatform = ((theActiveUnit != null || !theScen.ActiveUnits.ContainsKey(text2)) ? theActiveUnit : theScen.ActiveUnits[text2]);
					if (theParentPlatform == null)
					{
						text = "ERROR: UNIT # " + text2 + " DOES NOT EXIST IN SCENARIO!";
						StreamWriter streamWriter3 = File.AppendText(GameGeneral.SBRLogFilePath);
						streamWriter3.Write("\r\n  " + text);
						streamWriter3.Close();
						continue;
					}
					SQLiteHelper theHelper = new SQLiteHelper(theScen.DBConnection);
					switch (theParentPlatform.UnitType)
					{
					case GlobalVariables.ActiveUnitType.Aircraft:
						theQuery = "Select YearCommissioned, YearDecommissioned from DataAircraft where ID = " + Conversions.ToString(theParentPlatform.DBID);
						theQuery2 = "Select Description from EnumOperatorCountry where ID in (Select OperatorCountry from DataAircraft where ID = " + Conversions.ToString(theParentPlatform.DBID) + ")";
						theQuery3 = "Select Description from EnumOperatorService where ID in (Select OperatorService from DataAircraft where ID = " + Conversions.ToString(theParentPlatform.DBID) + ")";
						break;
					case GlobalVariables.ActiveUnitType.Ship:
						theQuery = "Select YearCommissioned, YearDecommissioned from DataShip where ID = " + Conversions.ToString(theParentPlatform.DBID);
						theQuery2 = "Select Description from EnumOperatorCountry where ID in (Select OperatorCountry from DataShip where ID = " + Conversions.ToString(theParentPlatform.DBID) + ")";
						theQuery3 = "Select Description from EnumOperatorService where ID in (Select OperatorService from DataShip where ID = " + Conversions.ToString(theParentPlatform.DBID) + ")";
						break;
					case GlobalVariables.ActiveUnitType.Submarine:
						theQuery = "Select YearCommissioned, YearDecommissioned from DataSubmarine where ID = " + Conversions.ToString(theParentPlatform.DBID);
						theQuery2 = "Select Description from EnumOperatorCountry where ID in (Select OperatorCountry from DataSubmarine where ID = " + Conversions.ToString(theParentPlatform.DBID) + ")";
						theQuery3 = "Select Description from EnumOperatorService where ID in (Select OperatorService from DataSubmarine where ID = " + Conversions.ToString(theParentPlatform.DBID) + ")";
						break;
					case GlobalVariables.ActiveUnitType.Facility:
						theQuery = "Select YearCommissioned, YearDecommissioned from DataFacility where ID = " + Conversions.ToString(theParentPlatform.DBID);
						theQuery2 = "Select Description from EnumOperatorCountry where ID in (Select OperatorCountry from DataFacility where ID = " + Conversions.ToString(theParentPlatform.DBID) + ")";
						theQuery3 = "Select Description from EnumOperatorService where ID in (Select OperatorService from DataFacility where ID = " + Conversions.ToString(theParentPlatform.DBID) + ")";
						break;
					case GlobalVariables.ActiveUnitType.Satellite:
						theQuery = "Select YearCommissioned, YearDecommissioned from DataSatellite where ID = " + Conversions.ToString(theParentPlatform.DBID);
						theQuery2 = "Select Description from EnumOperatorCountry where ID in (Select OperatorCountry from DataSatellite where ID = " + Conversions.ToString(theParentPlatform.DBID) + ")";
						theQuery3 = "Select Description from EnumOperatorService where ID in (Select OperatorService from DataSatellite where ID = " + Conversions.ToString(theParentPlatform.DBID) + ")";
						break;
					case GlobalVariables.ActiveUnitType.Vehicle:
						theQuery = "Select YearCommissioned, YearDecommissioned from DataGroundUnit where ID = " + Conversions.ToString(theParentPlatform.DBID);
						theQuery2 = "Select Description from EnumOperatorCountry where ID in (Select OperatorCountry from DataGroundUnit where ID = " + Conversions.ToString(theParentPlatform.DBID) + ")";
						theQuery3 = "Select Description from EnumOperatorService where ID in (Select OperatorService from DataGroundUnit where ID = " + Conversions.ToString(theParentPlatform.DBID) + ")";
						break;
					}
					List<(string, int, int, string)> list = new List<(string, int, int, string)>();
					if (!(theParentPlatform.IsAircraft | theParentPlatform.IsFacility | theParentPlatform.IsShip | theParentPlatform.IsSubmarine | theParentPlatform.IsSatellite))
					{
						continue;
					}
					DataTable datatable = DBCache.GetDatatable(theHelper, theQuery);
					DataTable datatable2 = DBCache.GetDatatable(theHelper, theQuery2);
					DataTable datatable3 = DBCache.GetDatatable(theHelper, theQuery3);
					if (!((datatable.Rows.Count != 0) & (datatable2.Rows.Count != 0) & (datatable3.Rows.Count != 0)))
					{
						break;
					}
					DataRow dataRow = datatable.Rows[0];
					DataRow dataRow2 = datatable2.Rows[0];
					DataRow dataRow3 = datatable3.Rows[0];
					string text3 = Strings.Trim(dataRow2["Description"].ToString());
					string text4 = Strings.Trim(dataRow3["Description"].ToString());
					string text5 = Conversions.ToString(Conversions.ToInteger(dataRow["YearCommissioned"].ToString()));
					string text6 = Conversions.ToString(Conversions.ToInteger(dataRow["YearDecommissioned"].ToString()));
					text = Conversions.ToString(theParentPlatform.DBID) + " -- " + theParentPlatform.Name + "  ----  " + theParentPlatform.UnitClass + " -- " + text3 + " (" + text4 + "), " + text5 + "-" + text6 + "  ----  " + theParentPlatform.ObjectID;
					StreamWriter streamWriter4 = File.AppendText(GameGeneral.SBRLogFilePath);
					streamWriter4.Write("\r\n  " + text);
					streamWriter4.Close();
					list.Clear();
					foreach (XmlNode childNode in val2.ChildNodes)
					{
						XmlNode val3 = childNode;
						string text7 = val3.Name.Split(new char[1] { '_' })[0];
						switch (text7)
						{
						case "AirOpsAdd":
						{
							int num = Conversions.ToInteger(val3.Name.Split(new char[1] { '_' })[1]);
							if (num > 0)
							{
								int facilityDBID2 = num;
								SQLiteConnection sqliteConnection_ = theScen.DBConnection;
								AirFacility airFacility = DBFunctions.GetAirFacility(facilityDBID2, ref sqliteConnection_);
								if (airFacility == null)
								{
									text = "ERROR: AIROPS WITH DBID " + Conversions.ToString(num) + " COULD NOT BE ADDED, NOT FOUND IN DATABASE!";
									StreamWriter streamWriter26 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter26.Write("\r\n    " + text);
									streamWriter26.Close();
								}
								else
								{
									theParentPlatform.AddAirFacility(airFacility);
									airFacility.ParentPlatform = theParentPlatform;
									text = "Added AirOps, DBID: " + Conversions.ToString(num) + " Name: " + airFacility.Name;
									StreamWriter streamWriter27 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter27.Write("\r\n    " + text);
									streamWriter27.Close();
								}
							}
							else if (num == -1)
							{
								AirFacility airFacility2 = AirFacility.AddUAV_Class1_Hanger(theParentPlatform);
								text = "Added AirOps, DBID: " + Conversions.ToString(num) + " Name: " + airFacility2.Name;
								StreamWriter streamWriter28 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter28.Write("\r\n    " + text);
								streamWriter28.Close();
							}
							break;
						}
						case "SensorActive":
						{
							if (theParentPlatform.Sensory.ObeysEMCON)
							{
								theParentPlatform.Sensory.ObeysEMCON = false;
							}
							float num7 = Conversions.ToInteger(val3.Name.Split(new char[1] { '_' })[1]);
							Sensor[] sensors_Cached = theParentPlatform.Sensors_Cached;
							foreach (Sensor sensor2 in sensors_Cached)
							{
								if ((float)sensor2.DBID == num7 && !sensor2.IsActive())
								{
									sensor2.GoActive();
									text = "Activate sensor [" + Conversions.ToString(num7) + "]";
									StreamWriter streamWriter19 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter19.Write("\r\n    " + text);
									streamWriter19.Close();
								}
							}
							break;
						}
						case "MountAdd":
						{
							int num3 = Conversions.ToInteger(val3.Name.Split(new char[1] { '_' })[1]);
							bool flag = false;
							if (num3 <= 0)
							{
								break;
							}
							string theQuery5 = "SELECT Name from DataMount where ID = " + Conversions.ToString(num3);
							if (DBCache.GetDatatable(theHelper, theQuery5).Rows.Count != 0)
							{
								Mount mount = DBFunctions.GetMount(num3, ref theScen);
								theParentPlatform.Mounts.Add(mount);
								mount.ParentPlatform = theParentPlatform;
								foreach (XmlNode childNode2 in val3.ChildNodes)
								{
									XmlNode theNode = childNode2;
									string name = theNode.Name;
									if (Operators.CompareString(name, "Coverage", false) == 0 || Operators.CompareString(name, "Cov", false) == 0)
									{
										mount.Coverage = PlatformComponent._Coverage.FromXML(ref theNode);
										flag = true;
									}
								}
								if (flag && mount.Sensors_ReadOnly.Count() > 0)
								{
									Sensor[] sensors_ReadOnly = mount.Sensors_ReadOnly;
									foreach (Sensor obj in sensors_ReadOnly)
									{
										obj.ParentPlatform = theParentPlatform;
										obj.Coverage.PB1 = mount.Coverage.PB1;
										obj.Coverage.PB2 = mount.Coverage.PB2;
										obj.Coverage.PMA1 = mount.Coverage.PMA1;
										obj.Coverage.PMA2 = mount.Coverage.PMA2;
										obj.Coverage.PMF1 = mount.Coverage.PMF1;
										obj.Coverage.PMF2 = mount.Coverage.PMF2;
										obj.Coverage.PS1 = mount.Coverage.PS1;
										obj.Coverage.PS2 = mount.Coverage.PS2;
										obj.Coverage.SB1 = mount.Coverage.SB1;
										obj.Coverage.SB2 = mount.Coverage.SB2;
										obj.Coverage.SMA1 = mount.Coverage.SMA1;
										obj.Coverage.SMA2 = mount.Coverage.SMA2;
										obj.Coverage.SMF1 = mount.Coverage.SMF1;
										obj.Coverage.SMF2 = mount.Coverage.SMF2;
										obj.Coverage.SS1 = mount.Coverage.SS1;
										obj.Coverage.SS2 = mount.Coverage.SS2;
									}
								}
								text = "Added mount, DBID: " + Conversions.ToString(num3) + " Name " + mount.Name;
								StreamWriter streamWriter9 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter9.Write("\r\n    " + text);
								streamWriter9.Close();
								if (!flag)
								{
									text = "ERROR: MOUNT WITH DBID " + Conversions.ToString(num3) + " HAS NO ARCS SET!";
									StreamWriter streamWriter10 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter10.Write("\r\n    " + text);
									streamWriter10.Close();
								}
							}
							else
							{
								text = "ERROR: MOUNT WITH DBID " + Conversions.ToString(num3) + " COULD NOT BE ADDED, NOT FOUND IN DATABASE!";
								StreamWriter streamWriter11 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter11.Write("\r\n    " + text);
								streamWriter11.Close();
							}
							break;
						}
						case "Damage":
							foreach (XmlNode childNode3 in val3.ChildNodes)
							{
								XmlNode val4 = childNode3;
								switch (val4.Name.Split(new char[1] { '_' })[0])
								{
								case "Cargo":
								{
									string theID = val4.Name.Split(new char[1] { '_' })[1];
									string innerText = val4.ChildNodes[0].InnerText;
									Cargo cargo = (Cargo)FindComponentByIDOrNameUndamaged(theParentPlatform.OnboardCargo, theID, innerText);
									if (cargo != null)
									{
										ApplyComponentDamage(cargo, val4);
									}
									break;
								}
								case "Fire":
									theParentPlatform.Damage.FireIntensity = (ActiveUnit_Damage.FireIntensityLevel)Conversions.ToByte(val4.InnerText);
									break;
								case "Mag":
								{
									string theID = val4.Name.Split(new char[1] { '_' })[1];
									string innerText = val4.ChildNodes[0].InnerText;
									Magazine magazine2 = (Magazine)FindComponentByIDOrNameUndamaged(theParentPlatform.SharedMagazines, theID, innerText);
									if (magazine2 != null)
									{
										ApplyComponentDamage(magazine2, val4);
									}
									break;
								}
								case "Mount":
								{
									string theID = val4.Name.Split(new char[1] { '_' })[1];
									string innerText = val4.ChildNodes[0].InnerText;
									Mount mount3 = (Mount)FindComponentByIDOrNameUndamaged(theParentPlatform.Mounts.ToArray(), theID, innerText);
									if (mount3 != null)
									{
										ApplyComponentDamage(mount3, val4);
									}
									break;
								}
								case "DamagePts":
									theParentPlatform.set_DamagePts(ScenEditAction: false, (Weapon)null, (float)Conversions.ToInteger(val4.InnerText));
									break;
								case "Comm":
								{
									string theID = val4.Name.Split(new char[1] { '_' })[1];
									string innerText = val4.ChildNodes[0].InnerText;
									CommDevice commDevice = (CommDevice)FindComponentByIDOrNameUndamaged(theParentPlatform.Comms_ReadOnly, theID, innerText);
									if (commDevice != null)
									{
										ApplyComponentDamage(commDevice, val4);
									}
									break;
								}
								case "Flood":
									theParentPlatform.Damage.FloodIntensity = (ActiveUnit_Damage.FloodingIntensityLevel)Conversions.ToByte(val4.InnerText);
									break;
								case "DockFacility":
								{
									string theID = val4.Name.Split(new char[1] { '_' })[1];
									string innerText = val4.ChildNodes[0].InnerText;
									DockFacility dockFacility2 = (DockFacility)FindComponentByIDOrNameUndamaged(theParentPlatform.DockFacilities_ReadOnly, theID, innerText);
									if (dockFacility2 != null)
									{
										ApplyComponentDamage(dockFacility2, val4);
									}
									break;
								}
								case "Engine":
								{
									string theID = val4.Name.Split(new char[1] { '_' })[1];
									string innerText = val4.ChildNodes[0].InnerText;
									Engine engine = (Engine)FindComponentByIDOrNameUndamaged(theParentPlatform.Propulsion.ToArray(), theID, innerText);
									if (engine != null)
									{
										ApplyComponentDamage(engine, val4);
									}
									break;
								}
								case "Sensor":
								{
									string theID = val4.Name.Split(new char[1] { '_' })[1];
									string innerText = val4.ChildNodes[0].InnerText;
									Sensor sensor3 = (Sensor)FindComponentByIDOrNameUndamaged(theParentPlatform.Sensors_Cached, theID, innerText);
									if (sensor3 != null)
									{
										ApplyComponentDamage(sensor3, val4);
									}
									break;
								}
								case "AirFacility":
								{
									string theID = val4.Name.Split(new char[1] { '_' })[1];
									string innerText = val4.ChildNodes[0].InnerText;
									AirFacility airFacility3 = (AirFacility)FindComponentByIDOrNameUndamaged(theParentPlatform.AirFacilities_ReadOnly, theID, innerText);
									if (airFacility3 != null)
									{
										ApplyComponentDamage(airFacility3, val4);
									}
									break;
								}
								}
							}
							break;
						case "MagAdd":
						{
							int num2 = Conversions.ToInteger(val3.Name.Split(new char[1] { '_' })[1]);
							if (num2 > 0)
							{
								string theQuery4 = "SELECT Name from DataMagazine where ID = " + Conversions.ToString(num2);
								if (DBCache.GetDatatable(theHelper, theQuery4).Rows.Count != 0)
								{
									Magazine magazine = DBFunctions.GetMagazine(num2, ref theScen);
									((Platform)theParentPlatform).AddSharedMagazine(magazine);
									magazine.ParentPlatform = theParentPlatform;
									text = "Added magazine, DBID: " + Conversions.ToString(num2) + " Name " + magazine.Name;
									StreamWriter streamWriter7 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter7.Write("\r\n    " + text);
									streamWriter7.Close();
								}
								else
								{
									text = "ERROR: MAGAZINE WITH DBID " + Conversions.ToString(num2) + " COULD NOT BE ADDED, NOT FOUND IN DATABASE!";
									StreamWriter streamWriter8 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter8.Write("\r\n    " + text);
									streamWriter8.Close();
								}
							}
							break;
						}
						case "Mount":
						{
							int num5 = Conversions.ToInteger(val3.Name.Split(new char[1] { '_' })[1]);
							int num3;
							try
							{
								num3 = Conversions.ToInteger(val3.Name.Split(new char[1] { '_' })[2]);
							}
							catch (Exception projectError11)
							{
								ProjectData.SetProjectError(projectError11);
								num3 = 0;
								if (num5 != 0)
								{
									text = "ERROR: MOUNT WITH INDEX " + Conversions.ToString(num5) + " HAS NO DBID LISTED (Example: <Mount_<MountIndex>_<MountDBID>> ). THIS MAY CAUSE THE WRONG MOUNT TO BE UPDATED IN CASE A DATABASE UPDATE ALTERS THE MOUNT INDEX!";
									StreamWriter streamWriter34 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter34.Write("\r\n    " + text);
									streamWriter34.Close();
								}
								ProjectData.ClearProjectError();
							}
							try
							{
								if (num5 == 0)
								{
									int num11 = 0;
									text = "Updating all relevant Mounts:";
									StreamWriter streamWriter35 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter35.Write("\r\n    " + text);
									streamWriter35.Close();
									foreach (Mount mount4 in theParentPlatform.Mounts)
									{
										Mount mount_ = mount4;
										int num12 = smethod_1(theScen, ref mount_, val3, num5);
										num11 += num12;
									}
									if (num11 == 0)
									{
										text = "ERROR: ATTEMPTING TO UPDATE ALL RELEVANT MOUNTS, COULD NOT FIND ANY MOUNTS TO UPDATE!";
										StreamWriter streamWriter36 = File.AppendText(GameGeneral.SBRLogFilePath);
										streamWriter36.Write("\r\n      " + text);
										streamWriter36.Close();
									}
								}
								else if (!(theParentPlatform.Mounts[num5 - 1].DBID == num3 || num3 == 0))
								{
									text = "ERROR: MOUNT WITH INDEX " + Conversions.ToString(num5) + " DOES NOT MATCH DBID " + Conversions.ToString(num3) + "! A DATABASE UPDATE MAY HAVE ALTERED THE MOUNT INDEX, YOU NEED TO CHANGE THE MOUNT INDEX TO THE CORRECT VALUE!";
									StreamWriter streamWriter37 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter37.Write("\r\n    " + text);
									streamWriter37.Close();
								}
								else
								{
									Scenario scenario_ = theScen;
									ObservableList<Mount> mounts;
									int index;
									Mount mount_2 = (mounts = theParentPlatform.Mounts)[index = num5 - 1];
									int num13 = smethod_1(scenario_, ref mount_2, val3, num5);
									mounts[index] = mount_2;
									int num11 = num13;
								}
							}
							catch (Exception projectError12)
							{
								ProjectData.SetProjectError(projectError12);
								text = "ERROR: MOUNT WITH INDEX " + Conversions.ToString(num5) + " DOES NOT EXIST ON UNIT!";
								StreamWriter streamWriter38 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter38.Write("\r\n    " + text);
								streamWriter38.Close();
								ProjectData.ClearProjectError();
							}
							break;
						}
						case "CargoAdd":
						{
							closure$__22- = new _Closure$__22-0(closure$__22-);
							_Closure$__22-0 closure$__22-2 = closure$__22-;
							XmlNode theNode2 = val3.FirstChild;
							ConcurrentDictionary<string, ScenarioObject> theDictionary = null;
							closure$__22-2.$VB$Local_theCargo = Cargo.FromXML(ref theNode2, ref theDictionary, theScen, theParentPlatform);
							if (theParentPlatform.OnboardCargo.FirstOrDefault(closure$__22-._Lambda$__0) == null)
							{
								ArrayExtensions.Add(ref theParentPlatform.OnboardCargo, closure$__22-.$VB$Local_theCargo);
							}
							break;
						}
						case "CommAdd":
						{
							int num15 = Conversions.ToInteger(val3.Name.Split(new char[1] { '_' })[1]);
							if (num15 > 0)
							{
								string theQuery6 = "SELECT Name from DataComm where ID = " + Conversions.ToString(num15);
								if (DBCache.GetDatatable(theHelper, theQuery6).Rows.Count == 0)
								{
									text = "ERROR: COMM WITH DBID " + Conversions.ToString(num15) + " COULD NOT BE ADDED, NOT FOUND IN DATABASE!";
									StreamWriter streamWriter50 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter50.Write("\r\n    " + text);
									streamWriter50.Close();
								}
								else
								{
									CommDevice commDevice2 = DBFunctions.GetCommDevice(num15, ref theParentPlatform);
									theParentPlatform.AddCommDevice(commDevice2);
									commDevice2.ParentPlatform = theParentPlatform;
									text = "Added comms gear, DBID: " + Conversions.ToString(num15) + " Name: " + commDevice2.Name;
									StreamWriter streamWriter51 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter51.Write("\r\n    " + text);
									streamWriter51.Close();
								}
							}
							break;
						}
						case "Mag":
						{
							int num4 = Conversions.ToInteger(val3.Name.Split(new char[1] { '_' })[1]);
							int num2;
							try
							{
								num2 = Conversions.ToInteger(val3.Name.Split(new char[1] { '_' })[2]);
							}
							catch (Exception projectError15)
							{
								ProjectData.SetProjectError(projectError15);
								num2 = 0;
								if (num4 != 0)
								{
									text = "ERROR: MAGAZINE WITH INDEX " + Conversions.ToString(num4) + " HAS NO DBID LISTED (Example: <Mag_<MagIndex>_<MagDBID>> ). THIS MAY CAUSE THE WRONG MAGAZINE TO BE UPDATED IN CASE A DATABASE UPDATE ALTERS THE MAGAZINE INDEX!";
									StreamWriter streamWriter42 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter42.Write("\r\n    " + text);
									streamWriter42.Close();
								}
								ProjectData.ClearProjectError();
							}
							try
							{
								int num11;
								if (num4 != 0)
								{
									if (theParentPlatform.SharedMagazines[num4 - 1].DBID == num2 || num2 == 0)
									{
										num11 = smethod_2(theScen, ref theParentPlatform.SharedMagazines[num4 - 1], val3, num4, bool_0: false);
										break;
									}
									text = "ERROR: MAGAZINE WITH INDEX " + Conversions.ToString(num4) + " DOES NOT MATCH DBID " + Conversions.ToString(num2) + "! A DATABASE UPDATE MAY HAVE ALTERED THE MAGAZINE INDEX, YOU NEED TO CHANGE THE MOUNT INDEX TO THE CORRECT VALUE!";
									StreamWriter streamWriter43 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter43.Write("\r\n    " + text);
									streamWriter43.Close();
									break;
								}
								num11 = 0;
								text = "Updating all relevant Magazines:";
								StreamWriter streamWriter44 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter44.Write("\r\n    " + text);
								streamWriter44.Close();
								Magazine[] sharedMagazines = theParentPlatform.SharedMagazines;
								for (int index = 0; index < sharedMagazines.Length; index = checked(index + 1))
								{
									Magazine magazine_ = sharedMagazines[index];
									int num12 = smethod_2(theScen, ref magazine_, val3, num4, bool_0: false);
									num11 += num12;
								}
								if (num11 == 0)
								{
									text = "ERROR: COULD NOT FIND ANY MAGAZINES TO UPDATE!";
									StreamWriter streamWriter45 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter45.Write("\r\n      " + text);
									streamWriter45.Close();
								}
							}
							catch (Exception projectError16)
							{
								ProjectData.SetProjectError(projectError16);
								text = "ERROR: MAGAZINE WITH INDEX " + Conversions.ToString(num4 - 1) + " DOES NOT EXIST ON UNIT!";
								StreamWriter streamWriter46 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter46.Write("\r\n    " + text);
								streamWriter46.Close();
								ProjectData.ClearProjectError();
							}
							break;
						}
						case "MCMRemove":
						{
							int num8 = Conversions.ToInteger(val3.Name.Split(new char[1] { '_' })[1]);
							try
							{
								num6 = Conversions.ToInteger(val3.Name.Split(new char[1] { '_' })[2]);
							}
							catch (Exception projectError5)
							{
								ProjectData.SetProjectError(projectError5);
								num6 = 0;
								if (num8 != 0)
								{
									text = "ERROR: SENSOR WITH INDEX " + Conversions.ToString(num8) + " HAS NO DBID LISTED (Example: <SensorRemove_<SensorIndex>_<SensorDBID> ). THIS MAY CAUSE THE WRONG SENSOR TO BE DELETED IN CASE A DATABASE UPDATE ALTERS THE SENSOR INDEX!";
									StreamWriter streamWriter20 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter20.Write("\r\n    " + text);
									streamWriter20.Close();
								}
								ProjectData.ClearProjectError();
							}
							if (num8 <= 0)
							{
								break;
							}
							try
							{
								if (num6 == theParentPlatform.MineCountermeasures[num8 - 1].DBID)
								{
									string name4 = theParentPlatform.MineCountermeasures[num8 - 1].Name;
									list.Add((text7, num8, num6, name4));
									break;
								}
								text = "ERROR: SENSOR WITH INDEX " + Conversions.ToString(num8) + " ON THE UNIT DOES NOT HAVE A DBID OF " + Conversions.ToString(num6);
								StreamWriter streamWriter21 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter21.Write("\r\n    " + text);
								streamWriter21.Close();
							}
							catch (Exception projectError6)
							{
								ProjectData.SetProjectError(projectError6);
								text = "ERROR: SENSOR WITH INDEX " + Conversions.ToString(num8) + " AND DBID " + Conversions.ToString(num6) + " COULD NOT BE DELETED, NOT FOUND ON UNIT!";
								StreamWriter streamWriter22 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter22.Write("\r\n    " + text);
								streamWriter22.Close();
								ProjectData.ClearProjectError();
							}
							break;
						}
						case "MagRemove":
						{
							int num4 = Conversions.ToInteger(val3.Name.Split(new char[1] { '_' })[1]);
							int num2;
							try
							{
								num2 = Conversions.ToInteger(val3.Name.Split(new char[1] { '_' })[2]);
							}
							catch (Exception projectError)
							{
								ProjectData.SetProjectError(projectError);
								num2 = 0;
								if (num4 != 0)
								{
									text = "ERROR: MAGAZINE WITH INDEX " + Conversions.ToString(num4) + " HAS NO DBID LISTED (Example: <MagRemove_<MagIndex>_<MagDBID> ). THIS MAY CAUSE THE WRONG MAGAZINE TO BE DELETED IN CASE A DATABASE UPDATE ALTERS THE MAGAZINE INDEX!";
									StreamWriter streamWriter12 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter12.Write("\r\n    " + text);
									streamWriter12.Close();
								}
								ProjectData.ClearProjectError();
							}
							if (num4 <= 0)
							{
								break;
							}
							try
							{
								if (theParentPlatform.SharedMagazines[num4 - 1].DBID == num2)
								{
									string name2 = theParentPlatform.SharedMagazines[num4 - 1].Name;
									list.Add((text7, num4, num2, name2));
									break;
								}
								text = "ERROR: MAG WITH INDEX " + Conversions.ToString(num4) + " ON THE UNIT DOES NOT HAVE A DBID OF " + Conversions.ToString(num2);
								StreamWriter streamWriter13 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter13.Write("\r\n    " + text);
								streamWriter13.Close();
							}
							catch (Exception projectError2)
							{
								ProjectData.SetProjectError(projectError2);
								text = "ERROR: MAGAZINE WITH INDEX " + Conversions.ToString(num4) + " AND DBID " + Conversions.ToString(num2) + " COULD NOT BE DELETED, NOT FOUND ON UNIT!";
								StreamWriter streamWriter14 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter14.Write("\r\n    " + text);
								streamWriter14.Close();
								ProjectData.ClearProjectError();
							}
							break;
						}
						case "DockRemove":
						{
							int num9 = Conversions.ToInteger(val3.Name.Split(new char[1] { '_' })[1]);
							int num;
							try
							{
								num = Conversions.ToInteger(val3.Name.Split(new char[1] { '_' })[2]);
							}
							catch (Exception projectError19)
							{
								ProjectData.SetProjectError(projectError19);
								num = 0;
								if (num9 != 0)
								{
									text = "ERROR: DOCK FACILITY WITH INDEX " + Conversions.ToString(num9) + " HAS NO DBID LISTED (Example: <DockRemove_<Index>_<DBID> ). THIS MAY CAUSE THE WRONG FACILITY TO BE DELETED IN CASE A DATABASE UPDATE ALTERS THE INDEX!";
									StreamWriter streamWriter52 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter52.Write("\r\n    " + text);
									streamWriter52.Close();
								}
								ProjectData.ClearProjectError();
							}
							if (num9 <= 0)
							{
								break;
							}
							try
							{
								if (num == theParentPlatform.DockFacilities_ReadOnly[num9 - 1].DBID)
								{
									string name5 = theParentPlatform.DockFacilities_ReadOnly[num9 - 1].Name;
									list.Add((text7, num9, num, name5));
									break;
								}
								text = "ERROR: DOCK FACILITY WITH INDEX " + Conversions.ToString(num9) + " ON THE UNIT DOES NOT HAVE A DBID OF " + Conversions.ToString(num);
								StreamWriter streamWriter53 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter53.Write("\r\n    " + text);
								streamWriter53.Close();
							}
							catch (Exception projectError20)
							{
								ProjectData.SetProjectError(projectError20);
								text = "ERROR: DOCK FACILITY WITH INDEX " + Conversions.ToString(num9) + " AND DBID " + Conversions.ToString(num) + " COULD NOT BE DELETED, NOT FOUND ON UNIT!";
								StreamWriter streamWriter54 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter54.Write("\r\n    " + text);
								streamWriter54.Close();
								ProjectData.ClearProjectError();
							}
							break;
						}
						case "SetFuel":
						{
							float num10 = float.Parse(val3.Name.Split(new char[1] { '_' })[1].Replace(",", "."), CultureInfo.InvariantCulture);
							if (theParentPlatform.IsAircraft)
							{
								((Aircraft)theParentPlatform).FuelCapacitySet(num10);
								text = "Set Fuel: " + Conversions.ToString(num10);
								StreamWriter streamWriter33 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter33.Write("\r\n    " + text);
								streamWriter33.Close();
							}
							else if (!theParentPlatform.IsFacility && !theParentPlatform.IsShip && !theParentPlatform.IsSubmarine)
							{
							}
							break;
						}
						case "SensorAdd":
						{
							num6 = Conversions.ToInteger(val3.Name.Split(new char[1] { '_' })[1]);
							bool flag2 = false;
							bool flag3 = false;
							if (num6 <= 0)
							{
								break;
							}
							string theQuery7 = "SELECT Name from DataSensor where ID = " + Conversions.ToString(num6);
							if (DBCache.GetDatatable(theHelper, theQuery7).Rows.Count == 0)
							{
								text = "ERROR: MAGAZINE WITH DBID " + Conversions.ToString(num6) + " COULD NOT BE ADDED, NOT FOUND IN DATABASE!";
								StreamWriter streamWriter55 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter55.Write("\r\n    " + text);
								streamWriter55.Close();
								break;
							}
							int int_ = num6;
							SQLiteConnection sqliteConnection_ = theParentPlatform.ParentScen.DBConnection;
							Sensor sensor4 = DBFunctions.GetSensor(int_, ref sqliteConnection_);
							theParentPlatform.AddSensor(sensor4);
							sensor4.ParentPlatform = theParentPlatform;
							foreach (XmlNode childNode4 in val3.ChildNodes)
							{
								XmlNode theNode3 = childNode4;
								switch (theNode3.Name)
								{
								case "Coverage_Illuminate":
								case "Cov_Ill":
									sensor4.Coverage_Illuminate = PlatformComponent._Coverage.FromXML(ref theNode3);
									flag3 = true;
									break;
								case "Coverage":
								case "Cov":
									sensor4.Coverage = PlatformComponent._Coverage.FromXML(ref theNode3);
									flag2 = true;
									break;
								}
							}
							text = "Added sensor, DBID: " + Conversions.ToString(num6) + " Name: " + sensor4.Name;
							StreamWriter streamWriter56 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter56.Write("\r\n    " + text);
							streamWriter56.Close();
							if (!flag2)
							{
								text = "ERROR: SENSOR WITH DBID " + Conversions.ToString(num6) + " HAS NO ARCS SET!";
								StreamWriter streamWriter57 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter57.Write("\r\n    " + text);
								streamWriter57.Close();
							}
							if (!flag3)
							{
								text = "ERROR: SENSOR WITH DBID " + Conversions.ToString(num6) + " HAS NO ILLUMINATION ARCS SET!";
								StreamWriter streamWriter58 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter58.Write("\r\n    " + text);
								streamWriter58.Close();
							}
							break;
						}
						case "MountRemove":
						{
							int num5 = Conversions.ToInteger(val3.Name.Split(new char[1] { '_' })[1]);
							int num3;
							try
							{
								num3 = Conversions.ToInteger(val3.Name.Split(new char[1] { '_' })[2]);
							}
							catch (Exception projectError17)
							{
								ProjectData.SetProjectError(projectError17);
								num3 = 0;
								if (num5 != 0)
								{
									text = "ERROR: MOUNT WITH INDEX " + Conversions.ToString(num5) + " HAS NO DBID LISTED (Example: <MountRemove_<MountIndex>_<MountDBID> ). THIS MAY CAUSE THE WRONG MOUNT TO BE DELETED IN CASE A DATABASE UPDATE ALTERS THE MOUNT INDEX!";
									StreamWriter streamWriter47 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter47.Write("\r\n    " + text);
									streamWriter47.Close();
								}
								ProjectData.ClearProjectError();
							}
							if (num5 <= 0)
							{
								break;
							}
							try
							{
								if (theParentPlatform.Mounts[num5 - 1].DBID == num3)
								{
									string name3 = theParentPlatform.Mounts[num5 - 1].Name;
									list.Add((text7, num5, num3, name3));
									break;
								}
								text = "ERROR: MOUNT WITH INDEX " + Conversions.ToString(num5) + " ON THE UNIT DOES NOT HAVE A DBID OF " + Conversions.ToString(num3);
								StreamWriter streamWriter48 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter48.Write("\r\n    " + text);
								streamWriter48.Close();
							}
							catch (Exception projectError18)
							{
								ProjectData.SetProjectError(projectError18);
								text = "ERROR: MOUNT WITH INDEX " + Conversions.ToString(num5) + " AND DBID " + Conversions.ToString(num3) + " COULD NOT BE DELETED, NOT FOUND ON UNIT!";
								StreamWriter streamWriter49 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter49.Write("\r\n    " + text);
								streamWriter49.Close();
								ProjectData.ClearProjectError();
							}
							break;
						}
						case "CommRemove":
						{
							int num14 = Conversions.ToInteger(val3.Name.Split(new char[1] { '_' })[1]);
							int num15;
							try
							{
								num15 = Conversions.ToInteger(val3.Name.Split(new char[1] { '_' })[2]);
							}
							catch (Exception projectError13)
							{
								ProjectData.SetProjectError(projectError13);
								num15 = 0;
								if (num14 != 0)
								{
									text = "ERROR: COMM WITH INDEX " + Conversions.ToString(num14) + " HAS NO DBID LISTED (Example: <CommRemove_<CommIndex>_<CommDBID> ). THIS MAY CAUSE THE WRONG COMM GEAR TO BE DELETED IN CASE A DATABASE UPDATE ALTERS THE COMM INDEX!";
									StreamWriter streamWriter39 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter39.Write("\r\n    " + text);
									streamWriter39.Close();
								}
								ProjectData.ClearProjectError();
							}
							if (num14 <= 0)
							{
								break;
							}
							try
							{
								if (num15 == theParentPlatform.Comms_ReadOnly[num14 - 1].DBID)
								{
									string name6 = theParentPlatform.Comms_ReadOnly[num14 - 1].Name;
									list.Add((text7, num14, num15, name6));
									break;
								}
								text = "ERROR: COMM GEAR WITH INDEX " + Conversions.ToString(num14) + " ON THE UNIT DOES NOT HAVE A DBID OF " + Conversions.ToString(num15);
								StreamWriter streamWriter40 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter40.Write("\r\n    " + text);
								streamWriter40.Close();
							}
							catch (Exception projectError14)
							{
								ProjectData.SetProjectError(projectError14);
								text = "ERROR: COMM GEAR WITH INDEX " + Conversions.ToString(num14) + " AND DBID " + Conversions.ToString(num15) + " COULD NOT BE DELETED, NOT FOUND ON UNIT!";
								StreamWriter streamWriter41 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter41.Write("\r\n    " + text);
								streamWriter41.Close();
								ProjectData.ClearProjectError();
							}
							break;
						}
						case "SensorRemove":
						{
							int num8 = Conversions.ToInteger(val3.Name.Split(new char[1] { '_' })[1]);
							try
							{
								num6 = Conversions.ToInteger(val3.Name.Split(new char[1] { '_' })[2]);
							}
							catch (Exception projectError9)
							{
								ProjectData.SetProjectError(projectError9);
								num6 = 0;
								if (num8 != 0)
								{
									text = "ERROR: SENSOR WITH INDEX " + Conversions.ToString(num8) + " HAS NO DBID LISTED (Example: <SensorRemove_<SensorIndex>_<SensorDBID> ). THIS MAY CAUSE THE WRONG SENSOR TO BE DELETED IN CASE A DATABASE UPDATE ALTERS THE SENSOR INDEX!";
									StreamWriter streamWriter30 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter30.Write("\r\n    " + text);
									streamWriter30.Close();
								}
								ProjectData.ClearProjectError();
							}
							if (num8 <= 0)
							{
								break;
							}
							try
							{
								if (num6 == theParentPlatform.Sensors_Cached[num8 - 1].DBID)
								{
									string name4 = theParentPlatform.Sensors_Cached[num8 - 1].Name;
									list.Add((text7, num8, num6, name4));
									break;
								}
								text = "ERROR: SENSOR WITH INDEX " + Conversions.ToString(num8) + " ON THE UNIT DOES NOT HAVE A DBID OF " + Conversions.ToString(num6);
								StreamWriter streamWriter31 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter31.Write("\r\n    " + text);
								streamWriter31.Close();
							}
							catch (Exception projectError10)
							{
								ProjectData.SetProjectError(projectError10);
								text = "ERROR: SENSOR WITH INDEX " + Conversions.ToString(num8) + " AND DBID " + Conversions.ToString(num6) + " COULD NOT BE DELETED, NOT FOUND ON UNIT!";
								StreamWriter streamWriter32 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter32.Write("\r\n    " + text);
								streamWriter32.Close();
								ProjectData.ClearProjectError();
							}
							break;
						}
						case "#comment":
						{
							text = val3.InnerText;
							StreamWriter streamWriter29 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter29.Write("  --  " + text);
							streamWriter29.Close();
							break;
						}
						case "AirOpsRemove":
						{
							int num9 = Conversions.ToInteger(val3.Name.Split(new char[1] { '_' })[1]);
							int num;
							try
							{
								num = Conversions.ToInteger(val3.Name.Split(new char[1] { '_' })[2]);
							}
							catch (Exception projectError7)
							{
								ProjectData.SetProjectError(projectError7);
								num = 0;
								if (num9 != 0)
								{
									text = "ERROR: AIR FACILITY WITH INDEX " + Conversions.ToString(num9) + " HAS NO DBID LISTED (Example: <AirOpsRemove_<Index>_<DBID> ). THIS MAY CAUSE THE WRONG FACILITY TO BE DELETED IN CASE A DATABASE UPDATE ALTERS THE INDEX!";
									StreamWriter streamWriter23 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter23.Write("\r\n    " + text);
									streamWriter23.Close();
								}
								ProjectData.ClearProjectError();
							}
							if (num9 <= 0)
							{
								break;
							}
							try
							{
								if (num == theParentPlatform.AirFacilities_ReadOnly[num9 - 1].DBID)
								{
									string name5 = theParentPlatform.AirFacilities_ReadOnly[num9 - 1].Name;
									list.Add((text7, num9, num, name5));
									break;
								}
								text = "ERROR: AIR FACILITY WITH INDEX " + Conversions.ToString(num9) + " ON THE UNIT DOES NOT HAVE A DBID OF " + Conversions.ToString(num);
								StreamWriter streamWriter24 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter24.Write("\r\n    " + text);
								streamWriter24.Close();
							}
							catch (Exception projectError8)
							{
								ProjectData.SetProjectError(projectError8);
								text = "ERROR: AIR FACILITY WITH INDEX " + Conversions.ToString(num9) + " AND DBID " + Conversions.ToString(num) + " COULD NOT BE DELETED, NOT FOUND ON UNIT!";
								StreamWriter streamWriter25 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter25.Write("\r\n    " + text);
								streamWriter25.Close();
								ProjectData.ClearProjectError();
							}
							break;
						}
						case "SensorMountRemove":
						{
							int num5 = Conversions.ToInteger(val3.Name.Split(new char[1] { '_' })[1]);
							int num3;
							try
							{
								num3 = Conversions.ToInteger(val3.Name.Split(new char[1] { '_' })[2]);
								num6 = Conversions.ToInteger(val3.Name.Split(new char[1] { '_' })[3]);
							}
							catch (Exception projectError3)
							{
								ProjectData.SetProjectError(projectError3);
								num3 = 0;
								if (num5 != 0)
								{
									text = "ERROR: MOUNT WITH INDEX " + Conversions.ToString(num5) + " HAS NO DBID LISTED (Example: <MountRemove_<MountIndex>_<MountDBID> ). THIS MAY CAUSE THE WRONG MOUNT TO BE DELETED IN CASE A DATABASE UPDATE ALTERS THE MOUNT INDEX!";
									StreamWriter streamWriter15 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter15.Write("\r\n    " + text);
									streamWriter15.Close();
								}
								ProjectData.ClearProjectError();
							}
							if (num5 <= 0)
							{
								break;
							}
							try
							{
								if (theParentPlatform.Mounts[num5 - 1].DBID == num3)
								{
									Mount mount2 = theParentPlatform.Mounts[num5 - 1];
									string name3 = mount2.Name;
									if (mount2.Sensors_ReadOnly.Count() <= 0)
									{
										break;
									}
									Sensor[] sensors_ReadOnly2 = mount2.Sensors_ReadOnly;
									foreach (Sensor sensor in sensors_ReadOnly2)
									{
										if (sensor.DBID == num6)
										{
											mount2.RemoveSensor(sensor);
											text = "Removed sensor from mount (" + mount2.Name + "), DBID: " + Conversions.ToString(num6) + " Name: " + sensor.Name;
											StreamWriter streamWriter16 = File.AppendText(GameGeneral.SBRLogFilePath);
											streamWriter16.Write("\r\n    " + text);
											streamWriter16.Close();
											break;
										}
									}
									break;
								}
								text = "ERROR: MOUNT WITH INDEX " + Conversions.ToString(num5) + " ON THE UNIT DOES NOT HAVE A DBID OF " + Conversions.ToString(num3);
								StreamWriter streamWriter17 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter17.Write("\r\n    " + text);
								streamWriter17.Close();
							}
							catch (Exception projectError4)
							{
								ProjectData.SetProjectError(projectError4);
								text = "ERROR: MOUNT WITH INDEX " + Conversions.ToString(num5) + " AND DBID " + Conversions.ToString(num3) + " COULD NOT BE DELETED, NOT FOUND ON UNIT!";
								StreamWriter streamWriter18 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter18.Write("\r\n    " + text);
								streamWriter18.Close();
								ProjectData.ClearProjectError();
							}
							break;
						}
						case "DockAdd":
						{
							int num = Conversions.ToInteger(val3.Name.Split(new char[1] { '_' })[1]);
							if (num > 0)
							{
								int facilityDBID = num;
								SQLiteConnection sqliteConnection_ = theScen.DBConnection;
								DockFacility dockFacility = DBFunctions.GetDockFacility(facilityDBID, ref sqliteConnection_);
								if (dockFacility == null)
								{
									text = "ERROR: DOCK WITH DBID " + Conversions.ToString(num) + " COULD NOT BE ADDED, NOT FOUND IN DATABASE!";
									StreamWriter streamWriter5 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter5.Write("\r\n    " + text);
									streamWriter5.Close();
								}
								else
								{
									theParentPlatform.AddDockFacility(dockFacility);
									dockFacility.ParentPlatform = theParentPlatform;
									text = "Added dock, DBID: " + Conversions.ToString(num) + " Name: " + dockFacility.Name;
									StreamWriter streamWriter6 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter6.Write("\r\n    " + text);
									streamWriter6.Close();
								}
							}
							break;
						}
						}
					}
					if (list.Count <= 0)
					{
						continue;
					}
					foreach (var item in list)
					{
						switch (item.Item1)
						{
						case "MagRemove":
						{
							int num4 = item.Item2;
							int num2 = item.Item3;
							if (num4 > 0)
							{
								if (theParentPlatform.SharedMagazines[num4 - 1].DBID == num2)
								{
									string name2 = theParentPlatform.SharedMagazines[num4 - 1].Name;
									((Platform)theParentPlatform).RemoveSharedMagazine(theParentPlatform.SharedMagazines[num4 - 1]);
									text = "Removed Mag with index " + Conversions.ToString(num4) + ", DBID: " + Conversions.ToString(num2) + " Name: " + name2;
									StreamWriter streamWriter70 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter70.Write("\r\n    " + text);
									streamWriter70.Close();
								}
								else
								{
									text = "ERROR: MAG WITH INDEX " + Conversions.ToString(num4) + " ON THE UNIT DOES NOT HAVE A DBID OF " + Conversions.ToString(num2);
									StreamWriter streamWriter71 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter71.Write("\r\n    " + text);
									streamWriter71.Close();
								}
							}
							break;
						}
						case "DockRemove":
						{
							int num9 = item.Item2;
							int num = item.Item3;
							if (num9 > 0)
							{
								if (num == theParentPlatform.DockFacilities_ReadOnly[num9 - 1].DBID)
								{
									string name5 = theParentPlatform.DockFacilities_ReadOnly[num9 - 1].Name;
									theParentPlatform.RemoveDockFacility(theParentPlatform.DockFacilities_ReadOnly[num9 - 1]);
									text = "Removed Dock Facility with index " + Conversions.ToString(num9) + ", DBID: " + Conversions.ToString(num) + " Name: " + name5;
									StreamWriter streamWriter68 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter68.Write("\r\n    " + text);
									streamWriter68.Close();
								}
								else
								{
									text = "ERROR: DOCK FACILITY WITH INDEX " + Conversions.ToString(num9) + " ON THE UNIT DOES NOT HAVE A DBID OF " + Conversions.ToString(num);
									StreamWriter streamWriter69 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter69.Write("\r\n    " + text);
									streamWriter69.Close();
								}
							}
							break;
						}
						case "MCMRemove":
						{
							int num8 = item.Item2;
							num6 = item.Item3;
							if (num8 > 0)
							{
								if (num6 == theParentPlatform.MineCountermeasures[num8 - 1].DBID)
								{
									string name4 = theParentPlatform.MineCountermeasures[num8 - 1].Name;
									theParentPlatform.RemoveSensor(theParentPlatform.MineCountermeasures[num8 - 1]);
									text = "Removed MCM Sensor with index " + Conversions.ToString(num8) + ", DBID: " + Conversions.ToString(num6) + " Name: " + name4;
									StreamWriter streamWriter64 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter64.Write("\r\n    " + text);
									streamWriter64.Close();
								}
								else
								{
									text = "ERROR: SENSOR WITH INDEX " + Conversions.ToString(num8) + " ON THE UNIT DOES NOT HAVE A DBID OF " + Conversions.ToString(num6);
									StreamWriter streamWriter65 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter65.Write("\r\n    " + text);
									streamWriter65.Close();
								}
							}
							break;
						}
						case "SensorRemove":
						{
							int num8 = item.Item2;
							num6 = item.Item3;
							if (num8 > 0)
							{
								if (num6 == theParentPlatform.Sensors_Cached[num8 - 1].DBID)
								{
									string name4 = theParentPlatform.Sensors_Cached[num8 - 1].Name;
									theParentPlatform.RemoveSensor(theParentPlatform.Sensors_Cached[num8 - 1]);
									text = "Removed Sensor with index " + Conversions.ToString(num8) + ", DBID: " + Conversions.ToString(num6) + " Name: " + name4;
									StreamWriter streamWriter61 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter61.Write("\r\n    " + text);
									streamWriter61.Close();
								}
								else
								{
									text = "ERROR: SENSOR WITH INDEX " + Conversions.ToString(num8) + " ON THE UNIT DOES NOT HAVE A DBID OF " + Conversions.ToString(num6);
									StreamWriter streamWriter62 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter62.Write("\r\n    " + text);
									streamWriter62.Close();
								}
							}
							break;
						}
						case "MountRemove":
						{
							int num5 = item.Item2;
							int num3 = item.Item3;
							if (num5 > 0)
							{
								string name3 = theParentPlatform.Mounts[num5 - 1].Name;
								theParentPlatform.Mounts.Remove(theParentPlatform.Mounts[num5 - 1]);
								text = ("Removed Mount with index " + Conversions.ToString(num5) + ", DBID: " + Conversions.ToString(num3) + " Name: " + name3) ?? "";
								StreamWriter streamWriter63 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter63.Write("\r\n    " + text);
								streamWriter63.Close();
							}
							break;
						}
						case "AirOpsRemove":
						{
							int num9 = item.Item2;
							int num = item.Item3;
							if (num9 > 0)
							{
								if (num == theParentPlatform.AirFacilities_ReadOnly[num9 - 1].DBID)
								{
									string name5 = theParentPlatform.AirFacilities_ReadOnly[num9 - 1].Name;
									theParentPlatform.RemoveAirFacility(theParentPlatform.AirFacilities_ReadOnly[num9 - 1]);
									text = "Removed Air Facility with index " + Conversions.ToString(num9) + ", DBID: " + Conversions.ToString(num) + " Name: " + name5;
									StreamWriter streamWriter66 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter66.Write("\r\n    " + text);
									streamWriter66.Close();
								}
								else
								{
									text = "ERROR: AIR FACILITY WITH INDEX " + Conversions.ToString(num9) + " ON THE UNIT DOES NOT HAVE A DBID OF " + Conversions.ToString(num);
									StreamWriter streamWriter67 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter67.Write("\r\n    " + text);
									streamWriter67.Close();
								}
							}
							break;
						}
						case "CommRemove":
						{
							int num14 = item.Item2;
							int num15 = item.Item3;
							if (num14 > 0)
							{
								if (num15 == theParentPlatform.Comms_ReadOnly[num14 - 1].DBID)
								{
									string name6 = theParentPlatform.Comms_ReadOnly[num14 - 1].Name;
									theParentPlatform.RemoveCommDevice(theParentPlatform.Comms_ReadOnly[num14 - 1]);
									text = "Removed Comm with index " + Conversions.ToString(num14) + ", DBID: " + Conversions.ToString(num15) + " Name: " + name6;
									StreamWriter streamWriter59 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter59.Write("\r\n    " + text);
									streamWriter59.Close();
								}
								else
								{
									text = "ERROR: COMM GEAR WITH INDEX " + Conversions.ToString(num14) + " ON THE UNIT DOES NOT HAVE A DBID OF " + Conversions.ToString(num15);
									StreamWriter streamWriter60 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter60.Write("\r\n    " + text);
									streamWriter60.Close();
								}
							}
							break;
						}
						}
					}
				}
				text = "  ERROR: NO UNIT WITH DBID " + Conversions.ToString(theParentPlatform.DBID) + " FOUND IN DATABASE!\r\n";
				StreamWriter streamWriter72 = File.AppendText(GameGeneral.SBRLogFilePath);
				streamWriter72.Write("\r\n  " + text);
				streamWriter72.Close();
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
			ex2?.Data.Add("Error at 101118", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static object MigrateScenario(string scenarioFilePath, string configuFilePath, DBRecord useDB)
	{
		string text;
		if (!FileExistsNative.FileExistsFast(scenarioFilePath))
		{
			text = "Scenario " + scenarioFilePath + ": ERROR: FILE NOT FOUND!";
			File.AppendAllText(GameGeneral.SBRLogFilePath, "\r\n\r\n" + text);
			File.AppendAllText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR plaform list.txt", "\r\n\r\n" + text);
			return false;
		}
		ScenContainer scenContainer = ScenContainer.LoadFromFile(scenarioFilePath);
		string ErrorFeedback = "";
		Scenario scenarioObject = scenContainer.GetScenarioObject(ref ErrorFeedback, null, ForceDeepRebuild: false);
		text = "Scenario file: " + scenarioFilePath + "\r\nConfig file:   " + configuFilePath + "\r\nDB:   " + useDB.FileName + "\r\n";
		File.AppendAllText(GameGeneral.SBRLogFilePath, "\r\n\r\n" + text);
		File.AppendAllText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR plaform list.txt", "\r\n\r\n" + text);
		DBOps.DBFileCheckResult theResult = default(DBOps.DBFileCheckResult);
		if (DBOps.GetDBRecordByHash(scenarioObject.DBUsed, ref theResult) != null)
		{
			_ = scenarioObject.DBUsed;
			string dBHash = (scenarioObject.DBUsed = useDB.Hash);
			List<string> list = CheckForPlatFormsMissingFromDB(scenarioObject, dBHash, IncludeWeapons: false);
			if (list.Count <= 0)
			{
				scenarioObject.LastSavedInScenEdit = true;
				Command_Core.LoadSave.LoadSave.SaveScenario(scenarioObject, scenarioObject.Sides_ReadOnly[0], scenarioFilePath + ".temp", SBR: true);
				Scenario theScen = scenarioObject;
				if (theScen != null)
				{
					GameGeneral.DestroyPreviousScenario(ref theScen, ClearLuaSandbox: false);
				}
				scenarioObject = null;
				theScen = null;
				ScenContainer scenContainer2 = ScenContainer.LoadFromFile(scenarioFilePath + ".temp");
				ErrorFeedback = "";
				scenarioObject = scenContainer2.GetScenarioObject(ref ErrorFeedback, null, ForceDeepRebuild: true);
				List<string> list2 = CheckForAircraftCarryingIllegalLoadouts(scenarioObject);
				if (list2.Count > 0)
				{
					text = "  ERROR: ONE OR MORE AIRCRAFT FEATURED IN THIS SCENARIO CARRY A LOADOUT THAT IS NOT IN THE AIRCRAFT'S LOADOUT LIST.\r\n  PLATFORMS ARE AS FOLLOWS:\r\n";
					foreach (string item in list2)
					{
						text = text + "  " + item + "\r\n";
					}
					text += "  Please contact the author of this DB in order to have this problem rectified.";
					File.AppendAllText(GameGeneral.SBRLogFilePath, "\r\n" + text);
				}
				if (FileExistsNative.FileExistsFast(configuFilePath))
				{
					ApplyScriptToScenario(scenarioObject, configuFilePath, IsUnitCloningOperation: false);
				}
				foreach (ActiveUnit activeUnits_ in scenarioObject.ActiveUnits_List)
				{
					if (!Information.IsNothing((object)activeUnits_))
					{
						activeUnits_.RestoreOldComponentIDs();
					}
				}
				GenerateScenarioContentsList(scenarioObject);
				foreach (ActiveUnit activeUnits_2 in scenarioObject.ActiveUnits_List)
				{
					activeUnits_2?.Sensory.vmethod_2(activeUnits_2.Sensors_Cached);
				}
				scenarioObject.LastSavedInScenEdit = true;
				Command_Core.LoadSave.LoadSave.SaveScenario(scenarioObject, scenarioObject.Sides_ReadOnly[0], scenarioFilePath, SBR: true);
				text = "Scenario " + scenarioFilePath + ": Rebuild Completed";
				File.AppendAllText(GameGeneral.SBRLogFilePath, "\r\n" + text);
				File.AppendAllText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR plaform list.txt", text);
				if (theScen != null)
				{
					GameGeneral.DestroyPreviousScenario(ref theScen, ClearLuaSandbox: false);
				}
				try
				{
					File.Delete(scenarioFilePath + ".temp");
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
				return true;
			}
			text = "  ERROR: ONE OR MORE PLATFORMS FEATURED IN THIS SCENARIO IS MISSING FROM THE DATABASE YOU ARE ATTEMPTING TO MIGRATE TO.\r\n  THE MISSING PLATFORMS ARE AS FOLLOWS:\r\n";
			foreach (string item2 in list)
			{
				text = text + "  " + item2 + "\r\n";
			}
			text += "  Please contact the author of this DB in order to have this problem rectified. The unit(s) have to be deleted and replaced with units that actually exist in the database.\r\n";
			text += "  MIGRATION ABORTED!";
			File.AppendAllText(GameGeneral.SBRLogFilePath, text);
			text = "Scenario " + scenarioFilePath + ": ERROR: REBUILD FAILED!";
			File.AppendAllText(GameGeneral.SBRLogFilePath, "\r\n\r\n" + text);
			return false;
		}
		text = "Error: " + DBOps.EnglishMessageString(theResult) + "\r\n";
		File.AppendAllText(GameGeneral.SBRLogFilePath, "\r\n\r\n" + text);
		return false;
	}
}
