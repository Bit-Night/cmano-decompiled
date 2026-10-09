using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Vehicle_Weaponry : ActiveUnit_Weaponry
{
	private Vehicle vehicle_0;

	[SpecialName]
	private Vehicle method_32()
	{
		if (Information.IsNothing((object)vehicle_0))
		{
			vehicle_0 = (Vehicle)myUnit;
		}
		return vehicle_0;
	}

	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
		try
		{
			theWriter.WriteStartElement("Weaponry");
			List<WeaponAssignment> weaponAssignments = WeaponAssignments;
			if (weaponAssignments != null && weaponAssignments.Count > 0)
			{
				theWriter.WriteStartElement("WeaponAssignments");
				foreach (WeaponAssignment weaponAssignment in WeaponAssignments)
				{
					weaponAssignment.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
				}
				theWriter.WriteEndElement();
			}
			if (LayChaffStream)
			{
				theWriter.WriteElementString("LCS", "True");
			}
			if (bool_3)
			{
				theWriter.WriteElementString("IDLZ", "True");
			}
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100568", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static Vehicle_Weaponry FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		Vehicle_Weaponry result;
		try
		{
			Vehicle_Weaponry vehicle_Weaponry = new Vehicle_Weaponry(ref theAU);
			vehicle_Weaponry.myUnit = theAU;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "WeaponAssignments":
					foreach (XmlNode childNode2 in val.ChildNodes)
					{
						XmlNode theNode2 = childNode2;
						WeaponAssignment weaponAssignment = WeaponAssignment.FromXML(ref theNode2, theDictionary, ref theAU.ParentScen);
						if (weaponAssignment.Target != null)
						{
							if (vehicle_Weaponry.WeaponAssignments == null)
							{
								vehicle_Weaponry.WeaponAssignments = new List<WeaponAssignment>();
							}
							vehicle_Weaponry.WeaponAssignments.Add(weaponAssignment);
						}
					}
					break;
				case "HF":
					if (theAU.Doctrine != null && Misc.ParseBool(val.InnerText))
					{
						theAU.Doctrine.set_WeaponControlStatus_Air(theAU.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._WCS?)Doctrine._WCS.Hold);
					}
					break;
				case "IDLZ":
					vehicle_Weaponry.bool_3 = true;
					break;
				case "LCS":
					vehicle_Weaponry.LayChaffStream = true;
					break;
				}
			}
			result = vehicle_Weaponry;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100569", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Vehicle_Weaponry(ref theAU);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override string RemoveWeaponFromMagazines(int int_0, bool LoadingAircraft, ref float MagazineReloadTime)
	{
		string result;
		try
		{
			if (LoadingAircraft && myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines))
			{
				result = "OK";
			}
			else
			{
				Magazine[] magazines = ((Platform)myUnit).Magazines;
				int num = 0;
				while (true)
				{
					if (num < magazines.Length)
					{
						Magazine magazine = magazines[num];
						if (magazine.Status == PlatformComponent._ComponentStatus.Destroyed || Operators.CompareString(magazine.RemoveWeapon(int_0, LoadingAircraft, ref MagazineReloadTime), "OK", false) != 0)
						{
							num = checked(num + 1);
							continue;
						}
						result = "OK";
						break;
					}
					if (myUnit.IsGroupMember() && !Information.IsNothing((object)myUnit.get_ParentGroup(UsingMissionPlanner: false).SharedMagazines))
					{
						Magazine[] sharedMagazines = myUnit.get_ParentGroup(UsingMissionPlanner: false).SharedMagazines;
						foreach (Magazine magazine2 in sharedMagazines)
						{
							if (magazine2.Status != PlatformComponent._ComponentStatus.Destroyed && Operators.CompareString(magazine2.RemoveWeapon(int_0, LoadingAircraft, ref MagazineReloadTime), "OK", false) == 0)
							{
								result = "OK";
								goto end_IL_0066;
							}
						}
					}
					result = "Weapon not found in magazines";
					break;
					continue;
					end_IL_0066:
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100570", "");
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

	public Vehicle_Weaponry(ref ActiveUnit theUnit)
		: base(theUnit)
	{
	}

	public override void ExecuteWeaponAssignments(float elapsedTime)
	{
		try
		{
			if ((int)Math.Round(method_32().CurrentSpeed) <= 0 || method_32().CanFireOnTheMove)
			{
				base.ExecuteWeaponAssignments(elapsedTime);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100571", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void ExecuteWeaponSalvos(float elapsedTime)
	{
		try
		{
			if ((int)Math.Round(method_32().CurrentSpeed) <= 0 || method_32().CanFireOnTheMove)
			{
				base.ExecuteWeaponSalvos(elapsedTime);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101209", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	static Vehicle_Weaponry()
	{
		Class72.smethod_20();
	}
}
