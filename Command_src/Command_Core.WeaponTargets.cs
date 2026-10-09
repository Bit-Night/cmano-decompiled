using System;
using System.Collections;
using System.Data.SQLite;
using System.Diagnostics;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class WeaponTargets
{
	public bool SurfaceVessel;

	public bool Submarine;

	public bool Aircraft;

	public bool Missile;

	public bool Satellite;

	public bool Radar;

	public bool Runway;

	public bool LandStructure_Soft;

	public bool LandStructure_Hard;

	public bool MobileTarget_Personnel;

	public bool Torpedo;

	public bool Mine;

	public bool Helicopter;

	public bool MobileTarget_Soft;

	public bool MobileTarget_Hard;

	public bool UnderwaterStructure;

	public bool AerostatMooring;

	public bool AirBaseSingleUnit;

	public bool RAMB;

	public bool MultipleTypes;

	public void ToXML(ref XmlWriter theWriter)
	{
		try
		{
			theWriter.WriteStartElement("WeaponTargets");
			if (SurfaceVessel)
			{
				theWriter.WriteElementString("SurfaceVessel", true.ToString());
			}
			if (Submarine)
			{
				theWriter.WriteElementString("Submarine", true.ToString());
			}
			if (Aircraft)
			{
				theWriter.WriteElementString("Aircraft", true.ToString());
			}
			if (Missile)
			{
				theWriter.WriteElementString("Missile", true.ToString());
			}
			if (Radar)
			{
				theWriter.WriteElementString("Radar", true.ToString());
			}
			if (Runway)
			{
				theWriter.WriteElementString("Runway", true.ToString());
			}
			if (LandStructure_Soft)
			{
				theWriter.WriteElementString("LandStructure_Soft", true.ToString());
			}
			if (LandStructure_Hard)
			{
				theWriter.WriteElementString("LandStructure_Hard", true.ToString());
			}
			if (Torpedo)
			{
				theWriter.WriteElementString("Torpedo", true.ToString());
			}
			if (Mine)
			{
				theWriter.WriteElementString("Mine", true.ToString());
			}
			if (Helicopter)
			{
				theWriter.WriteElementString("Helicopter", true.ToString());
			}
			if (MobileTarget_Soft)
			{
				theWriter.WriteElementString("MobileTarget_Soft", true.ToString());
			}
			if (MobileTarget_Hard)
			{
				theWriter.WriteElementString("MobileTarget_Hard", true.ToString());
			}
			if (MobileTarget_Personnel)
			{
				theWriter.WriteElementString("MobileTarget_Personnel", true.ToString());
			}
			if (UnderwaterStructure)
			{
				theWriter.WriteElementString("UnderwaterStructure", true.ToString());
			}
			if (AerostatMooring)
			{
				theWriter.WriteElementString("AerostatMooring", true.ToString());
			}
			if (AirBaseSingleUnit)
			{
				theWriter.WriteElementString("AirBaseSingleUnit", true.ToString());
			}
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101077", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static WeaponTargets FromXML(XmlNode theNode)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		WeaponTargets result;
		try
		{
			WeaponTargets weaponTargets = new WeaponTargets();
			IEnumerator enumerator = theNode.ChildNodes.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					switch (((XmlNode)enumerator.Current).Name)
					{
					case "MobileTarget_Hard":
						weaponTargets.MobileTarget_Hard = true;
						break;
					case "Runway":
						weaponTargets.Runway = true;
						break;
					case "AirBaseSingleUnit As":
						weaponTargets.AirBaseSingleUnit = true;
						break;
					case "Radar":
						weaponTargets.Radar = true;
						break;
					case "MobileTarget_Personnel":
						weaponTargets.MobileTarget_Personnel = true;
						break;
					case "Missile":
						weaponTargets.Missile = true;
						break;
					case "Submarine":
						weaponTargets.Submarine = true;
						break;
					case "MobileTarget_Soft":
						weaponTargets.MobileTarget_Soft = true;
						break;
					case "Torpedo":
						weaponTargets.Torpedo = true;
						break;
					case "UnderwaterStructure":
						weaponTargets.UnderwaterStructure = true;
						break;
					case "Aircraft":
						weaponTargets.Aircraft = true;
						break;
					case "AerostatMooring As":
						weaponTargets.AerostatMooring = true;
						break;
					case "Mine":
						weaponTargets.Mine = true;
						break;
					case "LandStructure_Soft":
						weaponTargets.LandStructure_Soft = true;
						break;
					case "LandStructure_Hard":
						weaponTargets.LandStructure_Hard = true;
						break;
					case "Helicopter":
						weaponTargets.Helicopter = true;
						break;
					case "SurfaceVessel":
						weaponTargets.SurfaceVessel = true;
						break;
					}
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
			if (theNode.ChildNodes.Count > 1)
			{
				weaponTargets.MultipleTypes = true;
			}
			result = weaponTargets;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101078", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new WeaponTargets();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private WeaponTargets()
	{
		MultipleTypes = false;
	}

	public WeaponTargets(int WeaponID, ref SQLiteConnection sqliteConnection_0)
	{
		MultipleTypes = false;
		WeaponTargets theWeaponTargets = this;
		DBFunctions.PopulateWeaponTargets(ref theWeaponTargets, WeaponID, ref sqliteConnection_0);
	}

	public bool FixedFacility()
	{
		int result;
		if (!LandStructure_Hard)
		{
			if (LandStructure_Soft)
			{
				result = 1;
			}
			else
			{
				if (!Runway)
				{
					return Radar;
				}
				result = 1;
			}
		}
		else
		{
			result = 1;
		}
		return (byte)result != 0;
	}

	public bool MobileFacility()
	{
		int result;
		if (MobileTarget_Hard)
		{
			result = 1;
		}
		else if (MobileTarget_Soft)
		{
			result = 1;
		}
		else
		{
			if (!MobileTarget_Personnel)
			{
				return Radar;
			}
			result = 1;
		}
		return (byte)result != 0;
	}

	static WeaponTargets()
	{
		Class72.smethod_20();
	}
}
