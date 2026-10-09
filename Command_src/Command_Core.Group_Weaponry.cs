using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Group_Weaponry : ActiveUnit_Weaponry
{
	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
		try
		{
			theWriter.WriteStartElement("Group_Weaponry");
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
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100625", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static Group_Weaponry FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		Group_Weaponry result;
		try
		{
			Group_Weaponry group_Weaponry = new Group_Weaponry(ref theAU);
			group_Weaponry.myUnit = theAU;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				string name = val.Name;
				if (Operators.CompareString(name, "WeaponAssignments", false) != 0)
				{
					if (Operators.CompareString(name, "HF", false) == 0 && theAU.Doctrine != null && Misc.ParseBool(val.InnerText))
					{
						theAU.Doctrine.set_WeaponControlStatus_Air(theAU.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._WCS?)Doctrine._WCS.Hold);
					}
					continue;
				}
				foreach (XmlNode childNode2 in val.ChildNodes)
				{
					XmlNode theNode2 = childNode2;
					WeaponAssignment weaponAssignment = WeaponAssignment.FromXML(ref theNode2, theDictionary, ref theAU.ParentScen);
					if (weaponAssignment.Target != null)
					{
						if (group_Weaponry.WeaponAssignments == null)
						{
							group_Weaponry.WeaponAssignments = new List<WeaponAssignment>();
						}
						group_Weaponry.WeaponAssignments.Add(weaponAssignment);
					}
				}
			}
			result = group_Weaponry;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100626", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Group_Weaponry(ref theAU);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public Group_Weaponry(ref ActiveUnit theUnit)
		: base(theUnit)
	{
	}

	public override int HowManyOfThisWeaponOnMagazines(int int_0)
	{
		int num = 0;
		int result;
		try
		{
			foreach (Platform value in ((Group)myUnit).Units.Values)
			{
				Magazine[] magazines = value.Magazines;
				foreach (Magazine magazine in magazines)
				{
					foreach (WeaponRec weapon in magazine.Weapons)
					{
						if (weapon.get_ReferenceWeapon(myUnit.ParentScen).DBID == int_0)
						{
							num += weapon.CurrentLoad;
						}
					}
				}
			}
			result = num;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100628", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num2;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num2 = 0;
			}
			else
			{
				num2 = 0;
			}
			result = num2;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override string RemoveWeaponFromMagazines(int int_0, bool LoadingAircraft, ref float MagazineReloadTime)
	{
		string result;
		if (myUnit == null)
		{
			result = "Error";
		}
		else if (!Information.IsNothing((object)myUnit.ParentScen))
		{
			try
			{
				if (LoadingAircraft && myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines))
				{
					result = "OK";
				}
				else
				{
					if (!Information.IsNothing((object)((Group)myUnit).SharedMagazines))
					{
						Magazine[] sharedMagazines = ((Group)myUnit).SharedMagazines;
						int num = 0;
						while (num < sharedMagazines.Length)
						{
							Magazine magazine = sharedMagazines[num];
							if (Information.IsNothing((object)magazine) || Operators.CompareString(magazine.RemoveWeapon(int_0, LoadingAircraft, ref MagazineReloadTime), "OK", false) != 0)
							{
								num = checked(num + 1);
								continue;
							}
							result = "OK";
							goto end_IL_002a;
						}
					}
					result = "Weapon not found in magazines";
				}
				end_IL_002a:;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100629", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = "Error";
				ProjectData.ClearProjectError();
			}
		}
		else
		{
			result = "Error";
		}
		return result;
	}

	public override string AddWeaponToMagazines(int int_0, bool PriorityToAviationMags, bool AllowCreatingNewWeaponRecOnMagazines, bool allowOverfill = false)
	{
		string result;
		try
		{
			if (!Information.IsNothing((object)((Group)myUnit).SharedMagazines))
			{
				Magazine[] sharedMagazines = ((Group)myUnit).SharedMagazines;
				int num = 0;
				while (true)
				{
					if (num < sharedMagazines.Length)
					{
						if (Operators.CompareString(sharedMagazines[num].AddWeapon(int_0), "OK", false) != 0)
						{
							num = checked(num + 1);
							continue;
						}
						result = "OK";
						break;
					}
					if (((Group)myUnit).SharedMagazines.Length <= 0)
					{
						result = "Failure";
						break;
					}
					((Group)myUnit).SharedMagazines[0].Weapons.Add(new WeaponRec(ref myUnit.ParentScen, int_0, 1, 10000, 1, 1, ExcludeOptionalWeapons: false, AircraftInternalWeapons: false));
					result = "OK";
					break;
				}
			}
			else
			{
				result = "Failure";
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100630", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = "Failure";
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override ActiveUnit._ActiveUnitWeaponState IsWinchesterOrShotgun()
	{
		Group obj = (Group)myUnit;
		try
		{
			int result;
			if (obj.Units.Count > 0)
			{
				Doctrine._WeaponStateRTB? nullable_ = obj.Doctrine.WinchesterShotgunRTB;
				if (!nullable_.HasValue)
				{
					return ActiveUnit._ActiveUnitWeaponState.None;
				}
				ActiveUnit._ActiveUnitWeaponState activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.None;
				bool flag = true;
				bool flag2 = false;
				List<ActiveUnit> list = new List<ActiveUnit>(obj.Units.Values);
				byte? b;
				foreach (ActiveUnit item in list)
				{
					if (item == null)
					{
						continue;
					}
					switch (item.IsAircraft ? ((Aircraft)item).Weaponry.IsWinchesterOrShotgun() : item.Weaponry.IsWinchesterOrShotgun())
					{
					case ActiveUnit._ActiveUnitWeaponState.IsWinchester:
						b = (byte?)nullable_;
						if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)) == true)
						{
							return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
						}
						break;
					case ActiveUnit._ActiveUnitWeaponState.IsShotgun:
						flag2 = true;
						break;
					case ActiveUnit._ActiveUnitWeaponState.None:
					case ActiveUnit._ActiveUnitWeaponState.IsWinchester_EngagingToO:
					case ActiveUnit._ActiveUnitWeaponState.IsShotgun_EngagingToO:
						flag = false;
						break;
					}
				}
				b = (byte?)nullable_;
				if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
				{
					if (flag)
					{
						if (!flag2)
						{
							return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
						}
						return ActiveUnit._ActiveUnitWeaponState.IsShotgun;
					}
					result = 0;
				}
				else
				{
					b = (byte?)nullable_;
					if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)) != true)
					{
						result = 0;
					}
					else
					{
						if (flag2)
						{
							return ActiveUnit._ActiveUnitWeaponState.IsShotgun;
						}
						result = 0;
					}
				}
			}
			else
			{
				result = 0;
			}
			return (ActiveUnit._ActiveUnitWeaponState)result;
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

	static Group_Weaponry()
	{
		Class72.smethod_20();
	}
}
