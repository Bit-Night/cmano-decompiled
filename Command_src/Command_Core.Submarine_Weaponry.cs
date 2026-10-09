using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using Collections.Pooled;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Submarine_Weaponry : ActiveUnit_Weaponry
{
	public enum TorpedoWireBreakReason
	{
		None,
		ExcessiveTurnRate,
		ExcessiveSpeed
	}

	private Submarine submarine_0;

	public override Weapon PrimaryAttackWeapon_Default
	{
		get
		{
			List<WeaponRec> list = AllDistinctWeaponsAboard_Default_WeaponRecs(IncludeAviationMags: false);
			List<Weapon> list2 = new List<Weapon>();
			foreach (WeaponRec item in list)
			{
				if (item.DefaultLoad == 0)
				{
					continue;
				}
				Weapon weapon = item.get_ReferenceWeapon(myUnit.ParentScen);
				Submarine._SubmarineType type = method_32().Type;
				if ((uint)(type - 2004) > 3u)
				{
					if (weapon.IsTorpedo)
					{
						list2.Add(weapon);
					}
				}
				else if (weapon.IsMissile)
				{
					list2.Add(weapon);
				}
			}
			if (list2.Count <= 0)
			{
				return null;
			}
			return list2.OrderByDescending([SpecialName] (Weapon theWpn) => theWpn.MaxRange_NoTargetType).ElementAtOrDefault(0);
		}
	}

	public override Weapon PrimaryAttackWeapon_Actual
	{
		get
		{
			List<Weapon> list = new List<Weapon>();
			List<Weapon> list2 = AllDistinctWeaponsAboard_Actual();
			foreach (Weapon item in list2)
			{
				Submarine._SubmarineType type = method_32().Type;
				if ((uint)(type - 2004) <= 3u)
				{
					if (item.IsMissile)
					{
						list.Add(item);
					}
				}
				else if (item.IsTorpedo)
				{
					list.Add(item);
				}
			}
			if (list.Count <= 0)
			{
				return null;
			}
			return list.OrderByDescending([SpecialName] (Weapon theW) => theW.MaxRange_NoTargetType).ElementAtOrDefault(0);
		}
	}

	public override Weapon PrimaryDefenceWeapon_Actual
	{
		get
		{
			List<Weapon> list = (from theW in AllDistinctWeaponsAboard_Actual()
				where theW.IsTorpedo
				select theW).ToList();
			if (list.Count > 0)
			{
				return list.OrderByDescending([SpecialName] (Weapon theW) => theW.MaxRange_NoTargetType).ElementAtOrDefault(0);
			}
			return null;
		}
	}

	public override Weapon PrimaryDefenceWeapon_Default
	{
		get
		{
			List<WeaponRec> list = AllDistinctWeaponsAboard_Default_WeaponRecs(IncludeAviationMags: false);
			List<Weapon> list2 = new List<Weapon>();
			foreach (WeaponRec item in list)
			{
				if (item.DefaultLoad != 0)
				{
					Weapon weapon = item.get_ReferenceWeapon(myUnit.ParentScen);
					if (weapon.IsTorpedo)
					{
						list2.Add(weapon);
					}
				}
			}
			if (list2.Count > 0)
			{
				return list2.OrderByDescending([SpecialName] (Weapon theWpn) => theWpn.MaxRange_NoTargetType).ElementAtOrDefault(0);
			}
			return null;
		}
	}

	public bool IsGuidingWireTorpedoes
	{
		get
		{
			bool result;
			try
			{
				if (myUnit == null)
				{
					goto IL_00c1;
				}
				int num;
				if (myUnit.ParentScen == null)
				{
					num = 0;
					goto IL_00c2;
				}
				if (myUnit.ParentScen.GuidedWeaponsInAir == null)
				{
					goto IL_00c1;
				}
				PooledList<Weapon> guidedWeaponsInAir = myUnit.ParentScen.GuidedWeaponsInAir;
				int num2;
				if (guidedWeaponsInAir == null)
				{
					num2 = 0;
					goto IL_00be;
				}
				Weapon[] array = guidedWeaponsInAir.InternalArray();
				int num3 = guidedWeaponsInAir.Count - 1;
				int num4 = 0;
				while (true)
				{
					if (num4 <= num3)
					{
						Weapon weapon;
						try
						{
							weapon = array[num4];
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							ProjectData.ClearProjectError();
							goto IL_00aa;
						}
						if (weapon != null && weapon.IsTorpedo && weapon.FiringParent == myUnit && weapon.DataLinkParent == myUnit)
						{
							result = true;
							break;
						}
						goto IL_00aa;
					}
					num2 = 0;
					goto IL_00be;
					IL_00aa:
					num4++;
				}
				goto end_IL_0001;
				IL_00c2:
				result = (byte)num != 0;
				goto end_IL_0001;
				IL_00be:
				result = (byte)num2 != 0;
				goto end_IL_0001;
				IL_00c1:
				num = 0;
				goto IL_00c2;
				end_IL_0001:;
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				int num5;
				if (!Debugger.IsAttached)
				{
					num5 = 0;
				}
				else
				{
					Debugger.Break();
					num5 = 0;
				}
				result = (byte)num5 != 0;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	[SpecialName]
	private Submarine method_32()
	{
		if (Information.IsNothing((object)submarine_0))
		{
			submarine_0 = (Submarine)myUnit;
		}
		return submarine_0;
	}

	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
		try
		{
			theWriter.WriteStartElement("Submarine_Weaponry");
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
			ex2?.Data.Add("Error at 100840", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static Submarine_Weaponry FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		Submarine_Weaponry result;
		try
		{
			Submarine_Weaponry submarine_Weaponry = new Submarine_Weaponry(ref theAU);
			submarine_Weaponry.myUnit = theAU;
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
							if (submarine_Weaponry.WeaponAssignments == null)
							{
								submarine_Weaponry.WeaponAssignments = new List<WeaponAssignment>();
							}
							submarine_Weaponry.WeaponAssignments.Add(weaponAssignment);
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
					submarine_Weaponry.bool_3 = true;
					break;
				}
			}
			result = submarine_Weaponry;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100841", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Submarine_Weaponry(ref theAU);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public Submarine_Weaponry(ref ActiveUnit theUnit)
		: base(theUnit)
	{
	}

	public void BreakTorpedoWires(TorpedoWireBreakReason theReason)
	{
		foreach (Weapon item in myUnit.ParentScen.GuidedWeaponsInAir)
		{
			if (item.IsTorpedo && item.FiringParent == myUnit && item.DataLinkParent == myUnit)
			{
				switch (theReason)
				{
				case TorpedoWireBreakReason.ExcessiveSpeed:
					myUnit.AddMessage(myUnit.Name + " has broken the guidance wire for " + item.Name + " (excessive speed)", "Torpedo wire broken", LoggedMessage.MessageType.UnitAI, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
					break;
				case TorpedoWireBreakReason.ExcessiveTurnRate:
					myUnit.AddMessage(myUnit.Name + " has broken the guidance wire for " + item.Name + " (excessive turn rate)", "Torpedo wire broken", LoggedMessage.MessageType.UnitAI, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
					break;
				}
				item.GoAutonomous(clearPrimaryTarget: false, clearDatalink: true, clearPlottedCourse: true);
			}
		}
	}

	static Submarine_Weaponry()
	{
		Class72.smethod_20();
	}
}
