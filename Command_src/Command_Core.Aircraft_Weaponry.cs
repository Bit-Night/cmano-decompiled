using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using Collections.Pooled;
using DarkUI.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Aircraft_Weaponry : ActiveUnit_Weaponry
{
	private Aircraft aircraft_0;

	[SpecialName]
	private Aircraft method_32()
	{
		if (Information.IsNothing((object)aircraft_0))
		{
			aircraft_0 = (Aircraft)myUnit;
		}
		return aircraft_0;
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
			ex2?.Data.Add("Error at 100472", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static Aircraft_Weaponry FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		Aircraft_Weaponry result;
		try
		{
			Aircraft_Weaponry aircraft_Weaponry = new Aircraft_Weaponry(ref theAU);
			aircraft_Weaponry.myUnit = theAU;
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
							if (aircraft_Weaponry.WeaponAssignments == null)
							{
								aircraft_Weaponry.WeaponAssignments = new List<WeaponAssignment>();
							}
							aircraft_Weaponry.WeaponAssignments.Add(weaponAssignment);
						}
					}
					break;
				case "HF":
					if (theAU.Doctrine != null && Misc.ParseBool(val.InnerText))
					{
						theAU.Doctrine.set_WeaponControlStatus_Air(theAU.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._WCS?)Doctrine._WCS.Hold);
					}
					break;
				case "LCS":
					aircraft_Weaponry.LayChaffStream = true;
					break;
				case "IDLZ":
					aircraft_Weaponry.bool_3 = true;
					break;
				}
			}
			result = aircraft_Weaponry;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100473", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Aircraft_Weaponry(ref theAU);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public Aircraft_Weaponry(ref ActiveUnit theUnit)
		: base(theUnit)
	{
	}

	public void JettisonSpecificOrdnance(bool ExecuteImmediately, int int_0)
	{
		if (!ExecuteImmediately && !myUnit.ParentScen.FifthSecondIsChangingOnThisPulse)
		{
			return;
		}
		if (!Information.IsNothing((object)method_32().Loadout))
		{
			Dictionary<Weapon, int> dictionary = new Dictionary<Weapon, int>();
			WeaponRec[] weapons = method_32().Loadout.Weapons;
			foreach (WeaponRec weaponRec in weapons)
			{
				if (weaponRec.CurrentLoad != 0 && weaponRec.int_3 == int_0)
				{
					Weapon key = weaponRec.get_ReferenceWeapon(method_32().ParentScen);
					if (dictionary.ContainsKey(key))
					{
						dictionary[key] += weaponRec.CurrentLoad;
					}
					else
					{
						dictionary.Add(key, weaponRec.CurrentLoad);
					}
					weaponRec.CurrentLoad = 0;
				}
			}
			if (dictionary.Count > 0)
			{
				List<string> list = new List<string>();
				foreach (KeyValuePair<Weapon, int> item in dictionary)
				{
					((ActiveUnit)method_32()).get_UnitSide(SetSideOnly: false).AAR.AddToExpenditures(item.Key.DBID, item.Value);
					list.Add(Conversions.ToString(item.Value) + "x " + item.Key.Name);
				}
				string messageText = method_32().Name + " (" + method_32().UnitClass + ") has jettisoned stores (" + string.Join(", ", list) + ") ";
				string messageSummary = method_32().Name + " jettisoned stores";
				method_32().AddMessage(messageText, messageSummary, LoggedMessage.MessageType.UnitAI, 0, new Geopoint_Struct(method_32().get_Longitude((GlobalVariables.BooleanObject)null), method_32().get_Latitude((GlobalVariables.BooleanObject)null)));
				ClearCachedWeapons();
			}
		}
		if (method_32().Loadout.PayloadWeight > 0)
		{
			AdjustLoadoutPayloadWeight();
		}
	}

	public void JettisonOrdnance(bool ExecuteImmediately, bool JettisonDropTanks, bool JettisonUnguidedAG, bool JettisonGuidedAG, bool bool_12, bool JettisonPod, bool JettisonInternalWeapons)
	{
		if (!ExecuteImmediately && !myUnit.ParentScen.FifthSecondIsChangingOnThisPulse)
		{
			return;
		}
		if (!Information.IsNothing((object)method_32().Loadout))
		{
			Dictionary<Weapon, int> dictionary = new Dictionary<Weapon, int>();
			WeaponRec[] weapons = method_32().Loadout.Weapons;
			foreach (WeaponRec weaponRec in weapons)
			{
				if (weaponRec.CurrentLoad == 0 || (!JettisonInternalWeapons && weaponRec.InternalWeapons))
				{
					continue;
				}
				Weapon weapon = weaponRec.get_ReferenceWeapon(method_32().ParentScen);
				if (weapon.Type != Weapon._WeaponType.FerryTank && (bool_12 || !weapon.IsAAWCapable) && (JettisonPod || weapon.Type != Weapon._WeaponType.SensorPod) && (JettisonDropTanks || weapon.Type != Weapon._WeaponType.DropTank) && (JettisonUnguidedAG || !weapon.IsUnguidedBallisticWeapon) && (JettisonGuidedAG || !weapon.IsGuidedWeapon()))
				{
					if (dictionary.ContainsKey(weapon))
					{
						dictionary[weapon] += weaponRec.CurrentLoad;
					}
					else
					{
						dictionary.Add(weapon, weaponRec.CurrentLoad);
					}
					weaponRec.CurrentLoad = 0;
				}
			}
			if (dictionary.Count > 0)
			{
				List<string> list = new List<string>();
				foreach (KeyValuePair<Weapon, int> item in dictionary)
				{
					((ActiveUnit)method_32()).get_UnitSide(SetSideOnly: false).AAR.AddToWeaponsLost(item.Key.DBID, item.Value);
					list.Add(Conversions.ToString(item.Value) + "x " + item.Key.Name);
				}
				method_32().AddMessage(method_32().Name + " (" + method_32().UnitClass + ") has jettisoned external stores (" + string.Join(", ", list) + ") ", method_32().Name + " jettisoning", LoggedMessage.MessageType.UnitAI, 0, new Geopoint_Struct(method_32().get_Longitude((GlobalVariables.BooleanObject)null), method_32().get_Latitude((GlobalVariables.BooleanObject)null)));
				ClearCachedWeapons();
			}
		}
		Loadout loadout = method_32().Loadout;
		if (loadout != null && loadout.PayloadWeight > 0)
		{
			AdjustLoadoutPayloadWeight();
		}
	}

	public override void ReduceTimesToFire(float elapsedTime)
	{
		try
		{
			base.ReduceTimesToFire(elapsedTime);
			if ((object)myUnit.GetType() != typeof(Aircraft) || method_32().Loadout == null)
			{
				return;
			}
			WeaponRec[] weapons = method_32().Loadout.Weapons;
			foreach (WeaponRec weaponRec in weapons)
			{
				if (weaponRec.TimeToFire > 0f)
				{
					weaponRec.TimeToFire -= elapsedTime;
					if (weaponRec.TimeToFire < 0f)
					{
						weaponRec.TimeToFire = 0f;
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100474", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override List<Weapon> AllDistinctWeaponsAboard_Actual()
	{
		if (_AllDistinctWeaponsAboard_Actual == null)
		{
			List<Weapon> list = new List<Weapon>(myUnit.Mounts.Count);
			try
			{
				ObservableList<Mount> mounts = myUnit.Mounts;
				PooledDictionary<int, int> pooledDictionary = default(PooledDictionary<int, int>);
				if (mounts.Count > 0)
				{
					int num = mounts.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						Mount mount = mounts[i];
						ObservableList<WeaponRec> mountWeapons = mount.MountWeapons;
						int num2 = mountWeapons.Count - 1;
						for (int j = 0; j <= num2; j++)
						{
							WeaponRec weaponRec = mountWeapons[j];
							if (weaponRec.CurrentLoad > 0)
							{
								if (pooledDictionary == null)
								{
									pooledDictionary = new PooledDictionary<int, int>();
								}
								if (!pooledDictionary.ContainsKey(weaponRec.int_3))
								{
									pooledDictionary.Add(weaponRec.int_3, 0);
									list.Add(weaponRec.get_ReferenceWeapon(myUnit.ParentScen));
								}
							}
						}
						ObservableList<WeaponRec> weapons = mount.MountMagazine.Weapons;
						int num3 = weapons.Count - 1;
						for (int k = 0; k <= num3; k++)
						{
							WeaponRec weaponRec = weapons[k];
							if (weaponRec.CurrentLoad > 0)
							{
								if (pooledDictionary == null)
								{
									pooledDictionary = new PooledDictionary<int, int>();
								}
								if (!pooledDictionary.ContainsKey(weaponRec.int_3))
								{
									pooledDictionary.Add(weaponRec.int_3, 0);
									list.Add(weaponRec.get_ReferenceWeapon(myUnit.ParentScen));
								}
							}
						}
					}
				}
				Magazine[] sharedMagazines = myUnit.SharedMagazines;
				if (sharedMagazines != null)
				{
					int num4 = sharedMagazines.Length - 1;
					for (int l = 0; l <= num4; l++)
					{
						ObservableList<WeaponRec> weapons2 = sharedMagazines[l].Weapons;
						int num5 = weapons2.Count - 1;
						for (int m = 0; m <= num5; m++)
						{
							WeaponRec weaponRec = weapons2[m];
							if (weaponRec.CurrentLoad > 0)
							{
								if (pooledDictionary == null)
								{
									pooledDictionary = new PooledDictionary<int, int>();
								}
								if (!pooledDictionary.ContainsKey(weaponRec.int_3))
								{
									pooledDictionary.Add(weaponRec.int_3, 0);
									list.Add(weaponRec.get_ReferenceWeapon(myUnit.ParentScen));
								}
							}
						}
					}
				}
				if (method_32().Loadout != null)
				{
					WeaponRec[] weapons3 = method_32().Loadout.Weapons;
					int num6 = weapons3.Length - 1;
					for (int n = 0; n <= num6; n++)
					{
						WeaponRec weaponRec = weapons3[n];
						if (weaponRec.CurrentLoad > 0)
						{
							if (pooledDictionary == null)
							{
								pooledDictionary = new PooledDictionary<int, int>();
							}
							if (!pooledDictionary.ContainsKey(weaponRec.int_3))
							{
								pooledDictionary.Add(weaponRec.int_3, 0);
								list.Add(weaponRec.get_ReferenceWeapon(myUnit.ParentScen));
							}
						}
					}
				}
				pooledDictionary?.Dispose();
				_AllDistinctWeaponsAboard_Actual = list;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100288", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		return _AllDistinctWeaponsAboard_Actual;
	}

	public ActiveUnit._ActiveUnitWeaponState CheckWinchester(ref PooledList<WeaponRec> theLoadoutWR, bool AllowAirToAirGuns, bool ExcludeGunsFromWinchesterEvaluation)
	{
		int num;
		if (!myUnit.IsDrone())
		{
			num = 0;
		}
		else
		{
			if (myUnit.AutonomyLevel < ActiveUnit.DroneAutonomyLevel.FaultEventAdaptive && myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DroneAutonomyLevels) && !myUnit.CommStuff.IsConnectedToSideNetwork)
			{
				return ActiveUnit._ActiveUnitWeaponState.None;
			}
			num = 0;
		}
		bool flag = (byte)num != 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		float num6 = 0f;
		if (theLoadoutWR != null && theLoadoutWR.Count > 0)
		{
			foreach (WeaponRec item in theLoadoutWR)
			{
				if (ExcludeGunsFromWinchesterEvaluation && (!ExcludeGunsFromWinchesterEvaluation || item.get_ReferenceWeapon(myUnit.ParentScen).Type == Weapon._WeaponType.Gun))
				{
					if (AllowAirToAirGuns)
					{
						num2 += item.CurrentLoad;
						num4 += item.MaxLoad;
						float maxRange_NoTargetType = item.get_ReferenceWeapon(myUnit.ParentScen).MaxRange_NoTargetType;
						if (item.CurrentLoad > 0 && num6 < maxRange_NoTargetType)
						{
							num6 = maxRange_NoTargetType;
						}
					}
				}
				else
				{
					num3 += item.CurrentLoad;
					num5 += item.MaxLoad;
				}
			}
		}
		theLoadoutWR.Dispose();
		if (num2 == 0 && num3 == 0)
		{
			return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
		}
		if (num3 == 0)
		{
			flag = true;
		}
		if (!flag)
		{
			return ActiveUnit._ActiveUnitWeaponState.None;
		}
		if (myUnit.get_UnitSide(SetSideOnly: false).NumberOfAnyWeaponTypesOnThisUnitLeftToFireAtAnyTarget(ref myUnit) > 0)
		{
			return ActiveUnit._ActiveUnitWeaponState.None;
		}
		Contact[] targets_ReadOnly = myUnit.AI.Targets_ReadOnly;
		int num7 = 0;
		int result;
		while (true)
		{
			if (num7 < targets_ReadOnly.Length)
			{
				Contact theTarget = targets_ReadOnly[num7];
				switch (myUnit.AI.TargetingBehaviorForThisTarget(theTarget, null))
				{
				default:
					goto IL_01c1;
				case ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualWeaponAlloc:
					result = 2;
					break;
				case ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualTargeted:
					result = 2;
					break;
				}
				break;
			}
			float num8;
			switch (myUnit.AI.Targets_ReadOnly.Length)
			{
			case 0:
				num8 = float.MaxValue;
				break;
			case 1:
				num8 = myUnit.RangeToUnit_Horiz(myUnit.AI.Targets_ReadOnly[0]);
				break;
			default:
			{
				IEnumerable<Contact> source = myUnit.AI.Targets_ReadOnly.OrderBy([SpecialName] (Contact theUnit) => Module_Unit.RangeToUnit_Horiz_Angular(myUnit, theUnit));
				num8 = myUnit.RangeToUnit_Horiz(source.ElementAtOrDefault(0));
				break;
			}
			}
			if (num2 > 0 && num6 < 5f)
			{
				num6 = 5f;
			}
			if (num6 > 0f && (double)num8 > Math.Max((double)num6 * 1.2, num6 + 5f))
			{
				return ActiveUnit._ActiveUnitWeaponState.IsWinchester_EngagingToO;
			}
			int result2;
			if (myUnit.IsRTB)
			{
				result2 = 1;
			}
			else if (myUnit.FuelState != ActiveUnit._ActiveUnitFuelState.IsBingo)
			{
				if (myUnit.FuelState != ActiveUnit._ActiveUnitFuelState.IsJoker)
				{
					return ActiveUnit._ActiveUnitWeaponState.IsWinchester_EngagingToO;
				}
				result2 = 1;
			}
			else
			{
				result2 = 1;
			}
			return (ActiveUnit._ActiveUnitWeaponState)result2;
			IL_01c1:
			num7 = checked(num7 + 1);
		}
		return (ActiveUnit._ActiveUnitWeaponState)result;
	}

	public ActiveUnit._ActiveUnitWeaponState CheckShotgunBVR(ref PooledList<WeaponRec> theLoadoutWR, ref bool AntiAirWeapon, bool OneEngagementOnly, bool MandatoryWVR, bool AllowWVR, bool AllowAirToAirGuns, bool ExcludeGunsFromWinchesterEvaluation)
	{
		int num;
		if (myUnit.IsDrone() && myUnit.AutonomyLevel < ActiveUnit.DroneAutonomyLevel.FaultEventAdaptive && myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DroneAutonomyLevels))
		{
			if (!myUnit.CommStuff.IsConnectedToSideNetwork)
			{
				return ActiveUnit._ActiveUnitWeaponState.None;
			}
			num = 0;
		}
		else
		{
			num = 0;
		}
		bool flag = (byte)num != 0;
		bool flag2 = false;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		int num7 = 0;
		float num8 = 0f;
		float num9 = 0f;
		if (theLoadoutWR != null && theLoadoutWR.Count > 0)
		{
			foreach (WeaponRec item in theLoadoutWR)
			{
				if (!ExcludeGunsFromWinchesterEvaluation || (ExcludeGunsFromWinchesterEvaluation && item.get_ReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun))
				{
					num5 += item.CurrentLoad;
					num7 += item.MaxLoad;
				}
				if (AntiAirWeapon)
				{
					if (!item.get_ReferenceWeapon(myUnit.ParentScen).IsBVR() && (!MandatoryWVR || !item.get_ReferenceWeapon(myUnit.ParentScen).IsWVR()))
					{
						if (item.get_ReferenceWeapon(myUnit.ParentScen).Type == Weapon._WeaponType.Gun)
						{
							if (AllowAirToAirGuns)
							{
								num4 += item.CurrentLoad;
								float maxRange_NoTargetType = item.get_ReferenceWeapon(myUnit.ParentScen).MaxRange_NoTargetType;
								if (item.CurrentLoad > 0 && num9 < maxRange_NoTargetType)
								{
									num9 = maxRange_NoTargetType;
								}
							}
						}
						else if (AllowWVR)
						{
							num3 += item.CurrentLoad;
							float maxRange_NoTargetType2 = item.get_ReferenceWeapon(myUnit.ParentScen).MaxRange_NoTargetType;
							if (item.CurrentLoad > 0 && num9 < maxRange_NoTargetType2)
							{
								num9 = maxRange_NoTargetType2;
							}
						}
					}
					else
					{
						if (!OneEngagementOnly && item.CurrentLoad > 0)
						{
							return ActiveUnit._ActiveUnitWeaponState.None;
						}
						num2 += item.CurrentLoad;
						num6 += item.MaxLoad;
						float maxRange_NoTargetType3 = item.get_ReferenceWeapon(myUnit.ParentScen).MaxRange_NoTargetType;
						if (item.CurrentLoad > 0 && num8 < maxRange_NoTargetType3)
						{
							num8 = maxRange_NoTargetType3;
						}
					}
				}
				else if (!item.get_ReferenceWeapon(myUnit.ParentScen).IsStandOff() && (!MandatoryWVR || item.get_ReferenceWeapon(myUnit.ParentScen).Type == Weapon._WeaponType.Gun))
				{
					if (AllowWVR)
					{
						num3 += item.CurrentLoad;
						float maxRange_NoTargetType4 = item.get_ReferenceWeapon(myUnit.ParentScen).MaxRange_NoTargetType;
						if (item.CurrentLoad > 0 && num9 < maxRange_NoTargetType4)
						{
							num9 = maxRange_NoTargetType4;
						}
					}
				}
				else
				{
					if (!OneEngagementOnly && item.CurrentLoad > 0)
					{
						return ActiveUnit._ActiveUnitWeaponState.None;
					}
					num2 += item.CurrentLoad;
					num6 += item.MaxLoad;
					float maxRange_NoTargetType5 = item.get_ReferenceWeapon(myUnit.ParentScen).MaxRange_NoTargetType;
					if (item.CurrentLoad > 0 && num8 < maxRange_NoTargetType5)
					{
						num8 = maxRange_NoTargetType5;
					}
				}
			}
			theLoadoutWR.Dispose();
			if (num4 == 0 && num3 == 0 && num2 == 0)
			{
				return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
			}
			if (OneEngagementOnly)
			{
				if (num2 < num6)
				{
					flag2 = true;
				}
			}
			else if (num2 == 0)
			{
				flag2 = true;
			}
			if (num5 == 0)
			{
				flag = true;
			}
		}
		if (!flag && !flag2)
		{
			return ActiveUnit._ActiveUnitWeaponState.None;
		}
		if (myUnit.AI.Targets_ReadOnly.Length == 0)
		{
			return ActiveUnit._ActiveUnitWeaponState.IsShotgun;
		}
		if (myUnit.get_UnitSide(SetSideOnly: false).NumberOfAnyWeaponTypesOnThisUnitLeftToFireAtAnyTarget(ref myUnit) > 0)
		{
			return ActiveUnit._ActiveUnitWeaponState.IsShotgun_EngagingToO;
		}
		Contact[] targets_ReadOnly = myUnit.AI.Targets_ReadOnly;
		int num10 = 0;
		while (true)
		{
			if (num10 < targets_ReadOnly.Length)
			{
				Contact theTarget = targets_ReadOnly[num10];
				ActiveUnit_AI.TargetingEntry._TargetingBehavior targetingBehavior = myUnit.AI.TargetingBehaviorForThisTarget(theTarget, null);
				if (targetingBehavior == ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualTargeted || targetingBehavior == ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualWeaponAlloc)
				{
					if (flag)
					{
						break;
					}
					if (flag2)
					{
						return ActiveUnit._ActiveUnitWeaponState.IsShotgun_EngagingToO;
					}
				}
				num10 = checked(num10 + 1);
				continue;
			}
			float num11;
			if (myUnit.AI.Targets_ReadOnly.Length == 1)
			{
				num11 = myUnit.RangeToUnit_Horiz(myUnit.AI.Targets_ReadOnly[0]);
			}
			else
			{
				IEnumerable<Contact> source = myUnit.AI.Targets_ReadOnly.OrderBy([SpecialName] (Contact theUnit) => Module_Unit.RangeToUnit_Horiz_Angular(myUnit, theUnit));
				num11 = myUnit.RangeToUnit_Horiz(source.ElementAtOrDefault(0));
			}
			if ((AllowAirToAirGuns || (!MandatoryWVR && AllowWVR)) && (num3 > 0 || num4 > 0) && num9 < 5f)
			{
				num9 = 5f;
			}
			if (num2 > 0 && num8 > 0f)
			{
				if ((double)num11 > Math.Max((double)num8 * 1.2, num8 + 5f))
				{
					if (flag)
					{
						return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
					}
					if (flag2)
					{
						return ActiveUnit._ActiveUnitWeaponState.IsShotgun;
					}
				}
			}
			else
			{
				if (!(num9 > 0f))
				{
					if (!flag)
					{
						return ActiveUnit._ActiveUnitWeaponState.IsShotgun;
					}
					return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
				}
				if ((double)num11 > Math.Max((double)num9 * 1.2, num9 + 5f))
				{
					if (flag)
					{
						return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
					}
					if (flag2)
					{
						return ActiveUnit._ActiveUnitWeaponState.IsShotgun;
					}
				}
			}
			if (!myUnit.IsRTB && myUnit.FuelState != ActiveUnit._ActiveUnitFuelState.IsBingo && myUnit.FuelState != ActiveUnit._ActiveUnitFuelState.IsJoker)
			{
				if (!flag)
				{
					if (!myUnit.Doctrine.get_IsShotgunSingleEngagment(myUnit.ParentScen))
					{
						return ActiveUnit._ActiveUnitWeaponState.IsShotgun_EngagingToO;
					}
					return ActiveUnit._ActiveUnitWeaponState.IsShotgun;
				}
				return ActiveUnit._ActiveUnitWeaponState.IsWinchester_EngagingToO;
			}
			if (flag)
			{
				return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
			}
			return ActiveUnit._ActiveUnitWeaponState.IsShotgun;
		}
		return ActiveUnit._ActiveUnitWeaponState.IsWinchester_EngagingToO;
	}

	public ActiveUnit._ActiveUnitWeaponState CheckShotgunWVR(ref PooledList<WeaponRec> theLoadoutWR, ref bool AntiAirWeapon, bool OneEngagementOnly, bool AllowAirToAirGuns, bool ExcludeGunsFromWinchesterEvaluation)
	{
		int num;
		if (!myUnit.IsDrone())
		{
			num = 0;
		}
		else if (myUnit.AutonomyLevel < ActiveUnit.DroneAutonomyLevel.FaultEventAdaptive)
		{
			if (!myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DroneAutonomyLevels))
			{
				num = 0;
			}
			else
			{
				if (!myUnit.CommStuff.IsConnectedToSideNetwork)
				{
					return ActiveUnit._ActiveUnitWeaponState.None;
				}
				num = 0;
			}
		}
		else
		{
			num = 0;
		}
		bool flag = (byte)num != 0;
		bool flag2 = false;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		int num7 = 0;
		int num8 = 0;
		float num9 = 0f;
		float num10 = 0f;
		if (theLoadoutWR != null && theLoadoutWR.Count > 0)
		{
			foreach (WeaponRec item in theLoadoutWR)
			{
				if (!ExcludeGunsFromWinchesterEvaluation || (ExcludeGunsFromWinchesterEvaluation && item.get_ReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun))
				{
					num5 += item.CurrentLoad;
					num8 += item.MaxLoad;
				}
				if (AntiAirWeapon)
				{
					if (item.get_ReferenceWeapon(myUnit.ParentScen).IsAAW_GuidedMissile)
					{
						if (!OneEngagementOnly && item.CurrentLoad > 0)
						{
							return ActiveUnit._ActiveUnitWeaponState.None;
						}
						if (item.get_ReferenceWeapon(myUnit.ParentScen).IsBVR())
						{
							num2 += item.CurrentLoad;
							num6 += item.MaxLoad;
						}
						else
						{
							num3 += item.CurrentLoad;
							num7 += item.MaxLoad;
						}
						float maxRange_NoTargetType = item.get_ReferenceWeapon(myUnit.ParentScen).MaxRange_NoTargetType;
						if (num9 < maxRange_NoTargetType)
						{
							num9 = maxRange_NoTargetType;
						}
					}
					else if (AllowAirToAirGuns)
					{
						num4 += item.CurrentLoad;
						float maxRange_NoTargetType2 = item.get_ReferenceWeapon(myUnit.ParentScen).MaxRange_NoTargetType;
						if (item.CurrentLoad > 0 && num10 < maxRange_NoTargetType2)
						{
							num10 = maxRange_NoTargetType2;
						}
					}
				}
				else
				{
					if (!OneEngagementOnly && item.CurrentLoad > 0)
					{
						return ActiveUnit._ActiveUnitWeaponState.None;
					}
					if (!item.get_ReferenceWeapon(myUnit.ParentScen).IsStandOff())
					{
						num3 += item.CurrentLoad;
						num7 += item.MaxLoad;
					}
					else
					{
						num2 += item.CurrentLoad;
						num6 += item.MaxLoad;
					}
					float maxRange_NoTargetType3 = item.get_ReferenceWeapon(myUnit.ParentScen).MaxRange_NoTargetType;
					if (num9 < maxRange_NoTargetType3)
					{
						num9 = maxRange_NoTargetType3;
					}
				}
			}
			theLoadoutWR.Dispose();
			if (num4 == 0 && num3 == 0 && num2 == 0)
			{
				return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
			}
			if (!OneEngagementOnly)
			{
				if (num3 == 0)
				{
					flag2 = true;
				}
			}
			else if (num3 < num7)
			{
				flag2 = true;
			}
			if (num7 == 0 && num2 == 0)
			{
				flag = true;
			}
			if (num5 == 0)
			{
				flag = true;
			}
		}
		if (!flag && !flag2)
		{
			return ActiveUnit._ActiveUnitWeaponState.None;
		}
		if (myUnit.AI.Targets_ReadOnly.Length == 0)
		{
			return ActiveUnit._ActiveUnitWeaponState.IsShotgun;
		}
		if (myUnit.get_UnitSide(SetSideOnly: false).NumberOfAnyWeaponTypesOnThisUnitLeftToFireAtAnyTarget(ref myUnit) > 0)
		{
			return ActiveUnit._ActiveUnitWeaponState.IsShotgun_EngagingToO;
		}
		Contact[] targets_ReadOnly = myUnit.AI.Targets_ReadOnly;
		int num11 = 0;
		while (true)
		{
			if (num11 < targets_ReadOnly.Length)
			{
				Contact theTarget = targets_ReadOnly[num11];
				ActiveUnit_AI.TargetingEntry._TargetingBehavior targetingBehavior = myUnit.AI.TargetingBehaviorForThisTarget(theTarget, null);
				if (targetingBehavior == ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualTargeted || targetingBehavior == ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualWeaponAlloc)
				{
					if (flag)
					{
						break;
					}
					if (flag2)
					{
						return ActiveUnit._ActiveUnitWeaponState.IsShotgun_EngagingToO;
					}
				}
				num11 = checked(num11 + 1);
				continue;
			}
			float num12;
			if (myUnit.AI.Targets_ReadOnly.Length == 1)
			{
				num12 = myUnit.RangeToUnit_Horiz(myUnit.AI.Targets_ReadOnly[0]);
			}
			else
			{
				IEnumerable<Contact> source = myUnit.AI.Targets_ReadOnly.OrderBy([SpecialName] (Contact theUnit) => Module_Unit.RangeToUnit_Horiz_Angular(myUnit, theUnit));
				num12 = myUnit.RangeToUnit_Horiz(source.ElementAtOrDefault(0));
			}
			if (AllowAirToAirGuns && num4 > 0 && num10 < 5f)
			{
				num10 = 5f;
			}
			if (num3 > 0 && num9 < 5f)
			{
				num9 = 5f;
			}
			if ((num7 > 0 || num6 > 0) && num9 > 0f)
			{
				if ((double)num12 > Math.Max((double)num9 * 1.2, num9 + 5f))
				{
					if (flag)
					{
						return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
					}
					if (flag2)
					{
						return ActiveUnit._ActiveUnitWeaponState.IsShotgun;
					}
				}
			}
			else if (num10 > 0f && (double)num12 > Math.Max((double)num10 * 1.2, num10 + 5f))
			{
				if (flag)
				{
					return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
				}
				if (flag2)
				{
					return ActiveUnit._ActiveUnitWeaponState.IsShotgun;
				}
			}
			if (!myUnit.IsRTB && myUnit.FuelState != ActiveUnit._ActiveUnitFuelState.IsBingo && myUnit.FuelState != ActiveUnit._ActiveUnitFuelState.IsJoker)
			{
				if (flag)
				{
					return ActiveUnit._ActiveUnitWeaponState.IsWinchester_EngagingToO;
				}
				return ActiveUnit._ActiveUnitWeaponState.IsShotgun_EngagingToO;
			}
			if (!flag)
			{
				return ActiveUnit._ActiveUnitWeaponState.IsShotgun;
			}
			return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
		}
		return ActiveUnit._ActiveUnitWeaponState.IsWinchester_EngagingToO;
	}

	public ActiveUnit._ActiveUnitWeaponState CheckShotgunGun(ref PooledList<WeaponRec> theLoadoutWR, ref bool AntiAirWeapon, bool OneEngagementOnly, bool ExcludeGunsFromWinchesterEvaluation)
	{
		int num;
		if (!myUnit.IsDrone())
		{
			num = 0;
		}
		else
		{
			if (myUnit.AutonomyLevel < ActiveUnit.DroneAutonomyLevel.FaultEventAdaptive && myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DroneAutonomyLevels) && !myUnit.CommStuff.IsConnectedToSideNetwork)
			{
				return ActiveUnit._ActiveUnitWeaponState.None;
			}
			num = 0;
		}
		bool flag = (byte)num != 0;
		bool flag2 = false;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		int num7 = 0;
		float num8 = 0f;
		float num9 = 0f;
		if (theLoadoutWR != null && theLoadoutWR.Count > 0)
		{
			foreach (WeaponRec item in theLoadoutWR)
			{
				Weapon weapon = item.get_ReferenceWeapon(myUnit.ParentScen);
				if (!ExcludeGunsFromWinchesterEvaluation || (ExcludeGunsFromWinchesterEvaluation && weapon.Type != Weapon._WeaponType.Gun))
				{
					num4 += item.CurrentLoad;
					num7 += item.MaxLoad;
				}
				if (weapon.Type == Weapon._WeaponType.Gun)
				{
					num2 += item.CurrentLoad;
					num5 += item.MaxLoad;
					float maxRange_NoTargetType = weapon.MaxRange_NoTargetType;
					if (item.CurrentLoad > 0 && num8 < maxRange_NoTargetType)
					{
						num8 = maxRange_NoTargetType;
					}
				}
				else
				{
					num3 += item.CurrentLoad;
					num6 += item.MaxLoad;
					float maxRange_NoTargetType2 = weapon.MaxRange_NoTargetType;
					if (item.CurrentLoad > 0 && num9 < maxRange_NoTargetType2)
					{
						num9 = maxRange_NoTargetType2;
					}
				}
			}
			theLoadoutWR.Dispose();
			if (num2 == 0 && num3 == 0)
			{
				return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
			}
			if (num2 < num5)
			{
				flag2 = true;
			}
			if (num5 == 0 && num3 == 0)
			{
				flag = true;
			}
			if (num4 == 0)
			{
				flag = true;
			}
		}
		if (!flag && !flag2)
		{
			return ActiveUnit._ActiveUnitWeaponState.None;
		}
		if (myUnit.AI.Targets_ReadOnly.Length == 0)
		{
			return ActiveUnit._ActiveUnitWeaponState.IsShotgun;
		}
		if (myUnit.get_UnitSide(SetSideOnly: false).NumberOfAnyWeaponTypesOnThisUnitLeftToFireAtAnyTarget(ref myUnit) > 0)
		{
			return ActiveUnit._ActiveUnitWeaponState.IsShotgun_EngagingToO;
		}
		Contact[] targets_ReadOnly = myUnit.AI.Targets_ReadOnly;
		int num10 = 0;
		while (true)
		{
			if (num10 < targets_ReadOnly.Length)
			{
				Contact theTarget = targets_ReadOnly[num10];
				ActiveUnit_AI.TargetingEntry._TargetingBehavior targetingBehavior = myUnit.AI.TargetingBehaviorForThisTarget(theTarget, null);
				if (targetingBehavior == ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualTargeted || targetingBehavior == ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualWeaponAlloc)
				{
					if (flag)
					{
						break;
					}
					if (flag2)
					{
						return ActiveUnit._ActiveUnitWeaponState.IsShotgun_EngagingToO;
					}
				}
				num10 = checked(num10 + 1);
				continue;
			}
			float num11;
			if (myUnit.AI.Targets_ReadOnly.Length == 1)
			{
				num11 = myUnit.RangeToUnit_Horiz(myUnit.AI.Targets_ReadOnly[0]);
			}
			else
			{
				IEnumerable<Contact> source = myUnit.AI.Targets_ReadOnly.OrderBy([SpecialName] (Contact theUnit) => Module_Unit.RangeToUnit_Horiz_Angular(myUnit, theUnit));
				num11 = myUnit.RangeToUnit_Horiz(source.ElementAtOrDefault(0));
			}
			if (num2 > 0 && num8 < 5f)
			{
				num8 = 5f;
			}
			if (num9 > 0f)
			{
				if ((double)num11 > Math.Max((double)num9 * 1.2, num9 + 5f))
				{
					if (flag)
					{
						return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
					}
					if (flag2)
					{
						return ActiveUnit._ActiveUnitWeaponState.IsShotgun;
					}
				}
			}
			else if (num8 > 0f && (double)num11 > Math.Max((double)num8 * 1.2, num8 + 5f))
			{
				if (flag)
				{
					int result;
					if (ExcludeGunsFromWinchesterEvaluation)
					{
						if (!flag2)
						{
							return ActiveUnit._ActiveUnitWeaponState.IsWinchester_EngagingToO;
						}
						result = 1;
					}
					else
					{
						result = 1;
					}
					return (ActiveUnit._ActiveUnitWeaponState)result;
				}
				if (flag2)
				{
					return ActiveUnit._ActiveUnitWeaponState.IsShotgun;
				}
			}
			if (!myUnit.IsRTB && myUnit.FuelState != ActiveUnit._ActiveUnitFuelState.IsBingo && myUnit.FuelState != ActiveUnit._ActiveUnitFuelState.IsJoker)
			{
				if (flag)
				{
					return ActiveUnit._ActiveUnitWeaponState.IsWinchester_EngagingToO;
				}
				return ActiveUnit._ActiveUnitWeaponState.IsShotgun_EngagingToO;
			}
			if (!flag)
			{
				return ActiveUnit._ActiveUnitWeaponState.IsShotgun;
			}
			return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
		}
		return ActiveUnit._ActiveUnitWeaponState.IsWinchester_EngagingToO;
	}

	public ActiveUnit._ActiveUnitWeaponState CheckShotgunPercentage(ref PooledList<WeaponRec> theLoadoutWR, ref bool AntiAirWeapon, int Percentage, bool AllowTargetsOfOpportunity, bool ExcludeGunsFromWinchesterEvaluation)
	{
		int num;
		if (myUnit.IsDrone() && myUnit.AutonomyLevel < ActiveUnit.DroneAutonomyLevel.FaultEventAdaptive && myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DroneAutonomyLevels))
		{
			if (!myUnit.CommStuff.IsConnectedToSideNetwork)
			{
				return ActiveUnit._ActiveUnitWeaponState.None;
			}
			num = 0;
		}
		else
		{
			num = 0;
		}
		bool flag = (byte)num != 0;
		bool flag2 = false;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		int num7 = 0;
		float num8 = 0f;
		float num9 = 0f;
		PooledList<WeaponRec> obj = theLoadoutWR;
		if (obj != null && obj.Count > 0)
		{
			foreach (WeaponRec item in theLoadoutWR)
			{
				if (!ExcludeGunsFromWinchesterEvaluation || (ExcludeGunsFromWinchesterEvaluation && item.get_ReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun))
				{
					num4 += item.CurrentLoad;
					num7 += item.MaxLoad;
				}
				if (item.get_ReferenceWeapon(myUnit.ParentScen).Type == Weapon._WeaponType.Gun)
				{
					num2 += item.CurrentLoad;
					num5 += item.MaxLoad;
					if (AllowTargetsOfOpportunity)
					{
						float maxRange_NoTargetType = item.get_ReferenceWeapon(myUnit.ParentScen).MaxRange_NoTargetType;
						if (item.CurrentLoad > 0 && num8 < maxRange_NoTargetType)
						{
							num8 = maxRange_NoTargetType;
						}
					}
					continue;
				}
				num3 += item.CurrentLoad;
				num6 += item.MaxLoad;
				if (AllowTargetsOfOpportunity)
				{
					float maxRange_NoTargetType2 = item.get_ReferenceWeapon(myUnit.ParentScen).MaxRange_NoTargetType;
					if (item.CurrentLoad > 0 && num9 < maxRange_NoTargetType2)
					{
						num9 = maxRange_NoTargetType2;
					}
				}
			}
			theLoadoutWR.Dispose();
			if (num2 == 0 && num3 == 0)
			{
				return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
			}
			if (ExcludeGunsFromWinchesterEvaluation)
			{
				if (num6 > 1 && (float)num3 <= (float)num6 * ((float)Percentage / 100f))
				{
					flag2 = true;
				}
			}
			else if (num5 + num6 > 1 && (double)(num2 + num3) <= (double)(num5 + num6) * ((double)Percentage / 100.0))
			{
				flag2 = true;
			}
			if (num4 == 0)
			{
				flag = true;
			}
		}
		if (!flag && !flag2)
		{
			return ActiveUnit._ActiveUnitWeaponState.None;
		}
		if (AllowTargetsOfOpportunity)
		{
			if (myUnit.AI.Targets_ReadOnly.Length != 0)
			{
				if (myUnit.get_UnitSide(SetSideOnly: false).NumberOfAnyWeaponTypesOnThisUnitLeftToFireAtAnyTarget(ref myUnit) > 0)
				{
					return ActiveUnit._ActiveUnitWeaponState.IsShotgun_EngagingToO;
				}
				Contact[] targets_ReadOnly = myUnit.AI.Targets_ReadOnly;
				int num10 = 0;
				while (true)
				{
					if (num10 < targets_ReadOnly.Length)
					{
						Contact theTarget = targets_ReadOnly[num10];
						ActiveUnit_AI.TargetingEntry._TargetingBehavior targetingBehavior = myUnit.AI.TargetingBehaviorForThisTarget(theTarget, null);
						if (targetingBehavior == ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualTargeted || targetingBehavior == ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualWeaponAlloc)
						{
							if (flag)
							{
								break;
							}
							if (flag2)
							{
								return ActiveUnit._ActiveUnitWeaponState.IsShotgun_EngagingToO;
							}
						}
						num10 = checked(num10 + 1);
						continue;
					}
					float num11;
					if (myUnit.AI.Targets_ReadOnly.Length == 1)
					{
						num11 = myUnit.RangeToUnit_Horiz(myUnit.AI.Targets_ReadOnly[0]);
					}
					else
					{
						IEnumerable<Contact> source = myUnit.AI.Targets_ReadOnly.OrderBy([SpecialName] (Contact theUnit) => Module_Unit.RangeToUnit_Horiz_Angular(myUnit, theUnit));
						num11 = myUnit.RangeToUnit_Horiz(source.ElementAtOrDefault(0));
					}
					if (num2 > 0 && num8 < 5f)
					{
						num8 = 5f;
					}
					if (num9 > 0f)
					{
						if ((double)num11 > Math.Max((double)num9 * 1.2, num9 + 5f))
						{
							if (flag)
							{
								return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
							}
							if (flag2)
							{
								return ActiveUnit._ActiveUnitWeaponState.IsShotgun;
							}
						}
					}
					else if (num8 > 0f && (double)num11 > Math.Max((double)num8 * 1.2, num8 + 5f))
					{
						if (flag)
						{
							if (ExcludeGunsFromWinchesterEvaluation && !flag2)
							{
								return ActiveUnit._ActiveUnitWeaponState.IsWinchester_EngagingToO;
							}
							return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
						}
						if (flag2)
						{
							return ActiveUnit._ActiveUnitWeaponState.IsShotgun;
						}
					}
					if (!myUnit.IsRTB && myUnit.FuelState != ActiveUnit._ActiveUnitFuelState.IsBingo && myUnit.FuelState != ActiveUnit._ActiveUnitFuelState.IsJoker)
					{
						if (!flag)
						{
							return ActiveUnit._ActiveUnitWeaponState.IsShotgun_EngagingToO;
						}
						return ActiveUnit._ActiveUnitWeaponState.IsWinchester_EngagingToO;
					}
					if (flag)
					{
						return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
					}
					return ActiveUnit._ActiveUnitWeaponState.IsShotgun;
				}
				return ActiveUnit._ActiveUnitWeaponState.IsWinchester_EngagingToO;
			}
			return ActiveUnit._ActiveUnitWeaponState.IsShotgun;
		}
		if (!flag)
		{
			return ActiveUnit._ActiveUnitWeaponState.IsShotgun;
		}
		return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
	}

	private PooledList<WeaponRec> method_33(Loadout loadout_0, bool bool_12)
	{
		PooledList<WeaponRec> pooledList = new PooledList<WeaponRec>();
		if (bool_12)
		{
			WeaponRec[] weapons = loadout_0.Weapons;
			foreach (WeaponRec weaponRec in weapons)
			{
				if (weaponRec.get_ReferenceWeapon(myUnit.ParentScen).Type == Weapon._WeaponType.Gun)
				{
					pooledList.Add(weaponRec);
				}
			}
		}
		else
		{
			WeaponRec[] weapons2 = loadout_0.Weapons;
			foreach (WeaponRec weaponRec2 in weapons2)
			{
				if (weaponRec2.get_ReferenceWeapon(myUnit.ParentScen).IsAAWCapable)
				{
					pooledList.Add(weaponRec2);
				}
			}
		}
		int num = myUnit.Mounts.Count - 1;
		for (int k = 0; k <= num; k++)
		{
			Mount mount = myUnit.Mounts[k];
			if (mount.Status != PlatformComponent._ComponentStatus.Operational)
			{
				continue;
			}
			if (bool_12)
			{
				foreach (WeaponRec mountWeapon in mount.MountWeapons)
				{
					if (mountWeapon.get_ReferenceWeapon(myUnit.ParentScen).Type == Weapon._WeaponType.Gun)
					{
						pooledList.Add(mountWeapon);
					}
				}
				continue;
			}
			foreach (WeaponRec mountWeapon2 in mount.MountWeapons)
			{
				if (mountWeapon2.get_ReferenceWeapon(myUnit.ParentScen).IsAAWCapable)
				{
					pooledList.Add(mountWeapon2);
				}
			}
		}
		return pooledList;
	}

	public override ActiveUnit._ActiveUnitWeaponState IsWinchesterOrShotgun()
	{
		ActiveUnit._ActiveUnitWeaponState result;
		if (Cache_CurrentWeaponState != ActiveUnit._ActiveUnitWeaponState.Undefined)
		{
			result = Cache_CurrentWeaponState;
		}
		else
		{
			Loadout loadout = method_32().Loadout;
			if (loadout == null)
			{
				ActiveUnit._ActiveUnitWeaponState activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.None;
				Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.None;
				result = ActiveUnit._ActiveUnitWeaponState.None;
			}
			else
			{
				try
				{
					Doctrine._WeaponState? weaponState = myUnit.Doctrine.get_WinchesterShotgun(myUnit.ParentScen, MultipleUnits: false, UnitIsOperating: true, ViaDoctrineForm: false, ViaRightColumn: false);
					int? num = (int?)weaponState;
					bool flag;
					if (((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() == 0)) == true)
					{
						flag = true;
						weaponState = loadout.WinchesterShotgun;
					}
					else
					{
						flag = false;
					}
					Loadout.LoadoutRole role = loadout.Role;
					int num2;
					if (role <= Loadout.LoadoutRole.LandOnly_DEAD)
					{
						switch (role)
						{
						case Loadout.LoadoutRole.Intercept_BVR:
						case Loadout.LoadoutRole.Intercept_WVR:
						case Loadout.LoadoutRole.AirSuperiority_BVR:
						case Loadout.LoadoutRole.AirSuperiority_WVR:
						case Loadout.LoadoutRole.PointDefence_BVR:
						case Loadout.LoadoutRole.PointDefence_WVR:
						case Loadout.LoadoutRole.GunsOnly:
							goto IL_0128;
						case Loadout.LoadoutRole.LandNaval_Strike:
						case Loadout.LoadoutRole.LandOnly_Strike:
							goto IL_1763;
						case Loadout.LoadoutRole.LandNaval_Standoff:
						case Loadout.LoadoutRole.LandOnly_Standoff:
							goto IL_2a45;
						case Loadout.LoadoutRole.LandNaval_SEAD_TALD:
						case Loadout.LoadoutRole.LandOnly_SEAD_TALD:
							goto IL_3486;
						case Loadout.LoadoutRole.LandNaval_SEAD_ARM:
						case Loadout.LoadoutRole.LandNaval_DEAD:
						case Loadout.LoadoutRole.LandOnly_SEAD_ARM:
						case Loadout.LoadoutRole.LandOnly_DEAD:
							goto IL_34c5;
						}
						num2 = 0;
						goto IL_3f68;
					}
					if (role <= Loadout.LoadoutRole.BAI_CAS)
					{
						switch (role)
						{
						case Loadout.LoadoutRole.NavalOnly_Strike:
						case Loadout.LoadoutRole.BAI_CAS:
							goto IL_1763;
						case Loadout.LoadoutRole.NavalOnly_Standoff:
							goto IL_2a45;
						case Loadout.LoadoutRole.NavalOnly_SEAD_TALD:
							goto IL_3486;
						case Loadout.LoadoutRole.NavalOnly_SEAD_ARM:
						case Loadout.LoadoutRole.NavalOnly_DEAD:
							goto IL_34c5;
						}
						num2 = 0;
						goto IL_3f68;
					}
					ActiveUnit._ActiveUnitWeaponState activeUnitWeaponState;
					if (role != Loadout.LoadoutRole.NavalMineLaying)
					{
						if (role != Loadout.LoadoutRole.ASW_Patrol)
						{
							num2 = 0;
							goto IL_3f68;
						}
						bool flag2 = true;
						WeaponRec[] weapons = loadout.Weapons;
						for (int i = 0; i < weapons.Length; i = checked(i + 1))
						{
							if (weapons[i].get_ReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Sonobuoy)
							{
								flag2 = false;
								break;
							}
						}
						if (!flag2)
						{
							if (loadout.Weapons.Where([SpecialName] (WeaponRec WR) => WR.get_ReferenceWeapon(myUnit.ParentScen).IsASW && WR.CurrentLoad > 0).Count() == 0)
							{
								activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
								Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
								result = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
							}
							else
							{
								activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.None;
								Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.None;
								result = ActiveUnit._ActiveUnitWeaponState.None;
							}
						}
						else if (loadout.Weapons.Where([SpecialName] (WeaponRec WR) => WR.CurrentLoad > 0).Count() != 0)
						{
							activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.None;
							Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.None;
							result = ActiveUnit._ActiveUnitWeaponState.None;
						}
						else
						{
							activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
							Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
							result = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
						}
					}
					else if (loadout.Weapons.Where([SpecialName] (WeaponRec WR) => WR.CurrentLoad > 0 && WR.get_ReferenceWeapon(myUnit.ParentScen).IsMine).Count() == 0)
					{
						activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
						Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
						result = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
					}
					else
					{
						activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.None;
						Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.None;
						result = ActiveUnit._ActiveUnitWeaponState.None;
					}
					goto end_IL_0037;
					IL_09e9:
					bool flag3;
					bool flag4;
					PooledList<WeaponRec> theLoadoutWR;
					int num3;
					if (!flag3)
					{
						if (!flag4)
						{
							theLoadoutWR = method_33(loadout, flag3);
							num = (int?)weaponState;
							if (!((!num.HasValue) ? ((bool?)null) : new bool?(num == 5002)).Value)
							{
								num = (int?)weaponState;
								if (!((!num.HasValue) ? ((bool?)null) : new bool?(num == 5003)).Value)
								{
									num = (int?)weaponState;
									if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 5005)).Value)
									{
										num3 = 1;
									}
									else
									{
										num = (int?)weaponState;
										num3 = (((!num.HasValue) ? ((bool?)null) : new bool?(num == 5006)).Value ? 1 : 0);
									}
									goto IL_0b65;
								}
							}
							num3 = 1;
							goto IL_0b65;
						}
						if (myUnit.WeaponState != ActiveUnit._ActiveUnitWeaponState.IsWinchester || myUnit.ParentScen.MinuteIsChangingOnThisPulse)
						{
							string text = "";
							if (Operators.CompareString(myUnit.Name, myUnit.UnitClass, false) != 0)
							{
								text = " (" + myUnit.UnitClass + ")";
							}
							if (!myUnit.IsRTB)
							{
								myUnit.AddMessage("Shotgun weapon state has been set to one engagement with Beyond Visual Range (BVR) weapons, however aircraft " + myUnit.Name + text + " is only armed with Within Visual Range (WVR) weapons. The aircraft will therefore return to base immediately. Change the Shotgun weapon state to Guns or WVR, or use Winchester weapon state.", myUnit.Name + " RTBing immediately", LoggedMessage.MessageType.AirOps, 1, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
							}
						}
						if (!myUnit.IsOperating())
						{
							activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.None;
							Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.None;
							result = ActiveUnit._ActiveUnitWeaponState.None;
						}
						else
						{
							activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
							Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
							result = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
						}
					}
					else
					{
						if (myUnit.WeaponState != ActiveUnit._ActiveUnitWeaponState.IsWinchester || myUnit.ParentScen.MinuteIsChangingOnThisPulse)
						{
							string text2 = "";
							if (Operators.CompareString(myUnit.Name, myUnit.UnitClass, false) != 0)
							{
								text2 = " (" + myUnit.UnitClass + ")";
							}
							if (!myUnit.IsRTB)
							{
								myUnit.AddMessage("Shotgun weapon state has been set to one engagement with Beyond Visual Range (BVR) weapons, however aircraft " + myUnit.Name + text2 + " is only armed with guns. The aircraft will therefore return to base immediately. Change the Shotgun weapon state to Guns, or use Winchester weapon state.", myUnit.Name + " RTBing immediately", LoggedMessage.MessageType.AirOps, 1, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
							}
						}
						if (!myUnit.IsOperating())
						{
							activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.None;
							Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.None;
							result = ActiveUnit._ActiveUnitWeaponState.None;
						}
						else
						{
							activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
							Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
							result = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
						}
					}
					goto end_IL_0037;
					IL_1afc:
					int num4;
					activeUnitWeaponState = (ActiveUnit._ActiveUnitWeaponState)num4;
					Cache_CurrentWeaponState = activeUnitWeaponState;
					result = activeUnitWeaponState;
					goto end_IL_0037;
					IL_194b:
					int num5;
					activeUnitWeaponState = (ActiveUnit._ActiveUnitWeaponState)num5;
					Cache_CurrentWeaponState = activeUnitWeaponState;
					result = activeUnitWeaponState;
					goto end_IL_0037;
					IL_2a45:
					ActiveUnit._ActiveUnitWeaponState activeUnitWeaponState2;
					bool AntiAirWeapon;
					if (method_32().ParentScen.FeatureCompatibility.get_WeaponAGL_ASL(method_32().ParentScen.DBConnection) || !flag)
					{
						PooledList<WeaponRec> theLoadoutWR2 = new PooledList<WeaponRec>();
						WeaponRec[] weapons2 = loadout.Weapons;
						foreach (WeaponRec weaponRec in weapons2)
						{
							if (weaponRec.get_ReferenceWeapon(myUnit.ParentScen).IsStandOff())
							{
								theLoadoutWR2.Add(weaponRec);
							}
						}
						num = (int?)weaponState;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 2001)) != true)
						{
							num = (int?)weaponState;
							if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 2002)) != true)
							{
								num = (int?)weaponState;
								if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 3001)) != true)
								{
									num = (int?)weaponState;
									if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 3002)) != true)
									{
										num = (int?)weaponState;
										if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 3003)) != true)
										{
											num = (int?)weaponState;
											if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 5001)) != true)
											{
												num = (int?)weaponState;
												if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 5002)) != true)
												{
													num = (int?)weaponState;
													if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 5003)) != true)
													{
														num = (int?)weaponState;
														if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 5005)) != true)
														{
															num = (int?)weaponState;
															if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 5006)) != true)
															{
																num = (int?)weaponState;
																if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 5011)) != true)
																{
																	num = (int?)weaponState;
																	if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 5012)) != true)
																	{
																		num = (int?)weaponState;
																		if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 5021)) != true)
																		{
																			bool allowTargetsOfOpportunity = false;
																			num = (int?)weaponState;
																			int percentage;
																			if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 4001)) != true)
																			{
																				num = (int?)weaponState;
																				if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 4002)) != true)
																				{
																					num = (int?)weaponState;
																					if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 4011)) == true)
																					{
																						percentage = 50;
																					}
																					else
																					{
																						num = (int?)weaponState;
																						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 4012)) != true)
																						{
																							num = (int?)weaponState;
																							if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 4021)) != true)
																							{
																								percentage = 75;
																								allowTargetsOfOpportunity = true;
																							}
																							else
																							{
																								percentage = 75;
																							}
																						}
																						else
																						{
																							percentage = 50;
																							allowTargetsOfOpportunity = true;
																						}
																					}
																				}
																				else
																				{
																					percentage = 25;
																					allowTargetsOfOpportunity = true;
																				}
																			}
																			else
																			{
																				percentage = 25;
																			}
																			AntiAirWeapon = false;
																			activeUnitWeaponState2 = CheckShotgunPercentage(ref theLoadoutWR2, ref AntiAirWeapon, percentage, allowTargetsOfOpportunity, ExcludeGunsFromWinchesterEvaluation: true);
																		}
																		else
																		{
																			AntiAirWeapon = false;
																			activeUnitWeaponState2 = CheckShotgunGun(ref theLoadoutWR2, ref AntiAirWeapon, OneEngagementOnly: true, ExcludeGunsFromWinchesterEvaluation: true);
																		}
																		goto IL_334d;
																	}
																}
																AntiAirWeapon = false;
																activeUnitWeaponState2 = CheckShotgunWVR(ref theLoadoutWR2, ref AntiAirWeapon, OneEngagementOnly: true, AllowAirToAirGuns: false, ExcludeGunsFromWinchesterEvaluation: true);
																goto IL_334d;
															}
														}
														AntiAirWeapon = false;
														activeUnitWeaponState2 = CheckShotgunBVR(ref theLoadoutWR2, ref AntiAirWeapon, OneEngagementOnly: true, MandatoryWVR: true, AllowWVR: false, AllowAirToAirGuns: false, ExcludeGunsFromWinchesterEvaluation: true);
														goto IL_334d;
													}
												}
											}
											AntiAirWeapon = false;
											activeUnitWeaponState2 = CheckShotgunBVR(ref theLoadoutWR2, ref AntiAirWeapon, OneEngagementOnly: true, MandatoryWVR: false, AllowWVR: true, AllowAirToAirGuns: false, ExcludeGunsFromWinchesterEvaluation: true);
											goto IL_334d;
										}
									}
								}
								AntiAirWeapon = false;
								activeUnitWeaponState2 = CheckShotgunBVR(ref theLoadoutWR2, ref AntiAirWeapon, OneEngagementOnly: false, MandatoryWVR: false, AllowWVR: false, AllowAirToAirGuns: false, ExcludeGunsFromWinchesterEvaluation: true);
								goto IL_334d;
							}
						}
						activeUnitWeaponState2 = CheckWinchester(ref theLoadoutWR2, AllowAirToAirGuns: false, ExcludeGunsFromWinchesterEvaluation: true);
						goto IL_334d;
					}
					byte? b = (byte?)myUnit.Doctrine.get_GunStrafing(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
					bool flag5 = default(bool);
					if (((((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) == true) ? loadout.Weapons.Where([SpecialName] (WeaponRec WR) => WR.get_ReferenceWeapon(myUnit.ParentScen).IsStandOff() && WR.get_ReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun && WR.CurrentLoad > 0).Count() : loadout.Weapons.Where([SpecialName] (WeaponRec WR) => WR.get_ReferenceWeapon(myUnit.ParentScen).IsStandOff() && WR.CurrentLoad > 0).Count()) == 0)
					{
						flag5 = true;
					}
					b = (byte?)myUnit.Doctrine.get_GunStrafing(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
					int num7 = default(int);
					if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) != true)
					{
						num7 = myUnit.Mounts.Where([SpecialName] (Mount theM) =>
						{
							int result2;
							if (theM.Status == PlatformComponent._ComponentStatus.Operational)
							{
								if (theM.HasGuns)
								{
									return !theM.IsEmpty;
								}
								result2 = 0;
							}
							else
							{
								result2 = 0;
							}
							return (byte)result2 != 0;
						}).Count();
					}
					bool flag6 = default(bool);
					if (num7 == 0)
					{
						flag6 = true;
					}
					int num8;
					if (!flag5)
					{
						num8 = 0;
						goto IL_2bed;
					}
					if (!flag6)
					{
						num8 = 0;
						goto IL_2bed;
					}
					activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
					Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
					result = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
					goto end_IL_0037;
					IL_2a28:
					PooledList<WeaponRec> theLoadoutWR3;
					bool value;
					result = (Cache_CurrentWeaponState = CheckWinchester(ref theLoadoutWR3, AllowAirToAirGuns: false, !value));
					goto end_IL_0037;
					IL_0128:
					int num9;
					int num11;
					if (method_32().ParentScen.FeatureCompatibility.get_WeaponAGL_ASL(method_32().ParentScen.DBConnection))
					{
						num9 = 0;
					}
					else
					{
						if (flag)
						{
							int num12;
							int num10;
							switch (loadout.Role)
							{
							default:
								num11 = 0;
								break;
							case Loadout.LoadoutRole.AirSuperiority_BVR:
								if (!Information.IsNothing((object)myUnit.ActiveMissionOrPackage()))
								{
									bool flag7 = loadout.Weapons.Where([SpecialName] (WeaponRec WR) =>
									{
										int result2;
										if (!WR.get_ReferenceWeapon(myUnit.ParentScen).IsMissile)
										{
											result2 = 0;
										}
										else
										{
											if (WR.get_ReferenceWeapon(myUnit.ParentScen).IsBVR())
											{
												return WR.CurrentLoad > 0;
											}
											result2 = 0;
										}
										return (byte)result2 != 0;
									}).Count() > 0;
									switch (myUnit.ActiveMissionOrPackage().MissionClass)
									{
									default:
										num11 = 0;
										break;
									case Mission._MissionClass.Patrol:
										if (!flag7)
										{
											activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
											Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
											result = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
										}
										else
										{
											activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.None;
											Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.None;
											result = ActiveUnit._ActiveUnitWeaponState.None;
										}
										goto end_IL_0037;
									case Mission._MissionClass.Strike:
										if (((Strike)myUnit.ActiveMissionOrPackage()).Type != Strike.StrikeType.Air_Intercept)
										{
											num11 = 0;
											break;
										}
										if (loadout.Weapons.Where([SpecialName] (WeaponRec WR) => WR.get_ReferenceWeapon(myUnit.ParentScen).IsAAWCapable && WR.CurrentLoad > 0).Count() == 0)
										{
											flag5 = true;
										}
										if (myUnit.Mounts.Where([SpecialName] (Mount theM) =>
										{
											int result2;
											if (theM.Status != PlatformComponent._ComponentStatus.Operational)
											{
												result2 = 0;
											}
											else
											{
												if (theM.HasGuns)
												{
													return !theM.IsEmpty;
												}
												result2 = 0;
											}
											return (byte)result2 != 0;
										}).Count() == 0)
										{
											flag6 = true;
										}
										if (flag5 && flag6)
										{
											activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
											Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
											result = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
										}
										else
										{
											activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.None;
											Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.None;
											result = ActiveUnit._ActiveUnitWeaponState.None;
										}
										goto end_IL_0037;
									}
									break;
								}
								if (loadout.Weapons.Where([SpecialName] (WeaponRec WR) => WR.get_ReferenceWeapon(myUnit.ParentScen).IsAAWCapable && WR.CurrentLoad > 0).Count() == 0)
								{
									flag5 = true;
								}
								if (myUnit.Mounts.Where([SpecialName] (Mount theM) =>
								{
									int result2;
									if (theM.Status == PlatformComponent._ComponentStatus.Operational)
									{
										if (theM.HasGuns)
										{
											return !theM.IsEmpty;
										}
										result2 = 0;
									}
									else
									{
										result2 = 0;
									}
									return (byte)result2 != 0;
								}).Count() == 0)
								{
									flag6 = true;
								}
								if (flag5 && flag6)
								{
									activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
									Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
									result = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
								}
								else
								{
									activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.None;
									Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.None;
									result = ActiveUnit._ActiveUnitWeaponState.None;
								}
								goto end_IL_0037;
							case Loadout.LoadoutRole.Intercept_BVR:
							case Loadout.LoadoutRole.PointDefence_BVR:
								if (!Information.IsNothing((object)myUnit.ActiveMissionOrPackage()))
								{
									bool flag8 = loadout.Weapons.Where([SpecialName] (WeaponRec WR) => WR.get_ReferenceWeapon(myUnit.ParentScen).IsMissile && WR.CurrentLoad > 0).Count() > 0;
									int num13;
									switch (myUnit.ActiveMissionOrPackage().MissionClass)
									{
									default:
										num11 = 0;
										break;
									case Mission._MissionClass.Patrol:
										if (flag8)
										{
											activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.None;
											Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.None;
											result = ActiveUnit._ActiveUnitWeaponState.None;
										}
										else
										{
											activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
											Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
											result = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
										}
										goto end_IL_0037;
									case Mission._MissionClass.Strike:
										{
											if (((Strike)myUnit.ActiveMissionOrPackage()).Type != Strike.StrikeType.Air_Intercept)
											{
												num11 = 0;
												break;
											}
											if (loadout.Weapons.Where([SpecialName] (WeaponRec WR) => WR.get_ReferenceWeapon(myUnit.ParentScen).IsAAWCapable && WR.CurrentLoad > 0).Count() == 0)
											{
												flag5 = true;
											}
											if (myUnit.Mounts.Where([SpecialName] (Mount theM) =>
											{
												int result2;
												if (theM.Status == PlatformComponent._ComponentStatus.Operational)
												{
													if (theM.HasGuns)
													{
														return !theM.IsEmpty;
													}
													result2 = 0;
												}
												else
												{
													result2 = 0;
												}
												return (byte)result2 != 0;
											}).Count() == 0)
											{
												flag6 = true;
											}
											if (!flag5)
											{
												num13 = 0;
												goto IL_1600;
											}
											if (!flag6)
											{
												num13 = 0;
												goto IL_1600;
											}
											activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
											Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
											result = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
											goto end_IL_0037;
										}
										IL_1600:
										activeUnitWeaponState = (ActiveUnit._ActiveUnitWeaponState)num13;
										Cache_CurrentWeaponState = activeUnitWeaponState;
										result = activeUnitWeaponState;
										goto end_IL_0037;
									}
									break;
								}
								if (loadout.Weapons.Where([SpecialName] (WeaponRec WR) => WR.get_ReferenceWeapon(myUnit.ParentScen).IsAAWCapable && WR.CurrentLoad > 0).Count() == 0)
								{
									flag5 = true;
								}
								if (myUnit.Mounts.Where([SpecialName] (Mount theM) =>
								{
									int result2;
									if (theM.Status != PlatformComponent._ComponentStatus.Operational)
									{
										result2 = 0;
									}
									else
									{
										if (theM.HasGuns)
										{
											return !theM.IsEmpty;
										}
										result2 = 0;
									}
									return (byte)result2 != 0;
								}).Count() == 0)
								{
									flag6 = true;
								}
								if (!flag5)
								{
									num12 = 0;
									goto IL_168f;
								}
								if (!flag6)
								{
									num12 = 0;
									goto IL_168f;
								}
								activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
								Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
								result = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
								goto end_IL_0037;
							case Loadout.LoadoutRole.Intercept_WVR:
							case Loadout.LoadoutRole.AirSuperiority_WVR:
							case Loadout.LoadoutRole.PointDefence_WVR:
								{
									if (loadout.Weapons.Where([SpecialName] (WeaponRec WR) => WR.get_ReferenceWeapon(myUnit.ParentScen).IsAAWCapable && WR.CurrentLoad > 0).Count() == 0)
									{
										flag5 = true;
									}
									if (myUnit.Mounts.Where([SpecialName] (Mount theM) =>
									{
										int result2;
										if (theM.Status == PlatformComponent._ComponentStatus.Operational)
										{
											if (theM.HasGuns)
											{
												return !theM.IsEmpty;
											}
											result2 = 0;
										}
										else
										{
											result2 = 0;
										}
										return (byte)result2 != 0;
									}).Count() == 0)
									{
										flag6 = true;
									}
									if (!flag5)
									{
										num10 = 0;
										goto IL_1708;
									}
									if (!flag6)
									{
										num10 = 0;
										goto IL_1708;
									}
									activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
									Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
									result = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
									goto end_IL_0037;
								}
								IL_1708:
								activeUnitWeaponState = (ActiveUnit._ActiveUnitWeaponState)num10;
								Cache_CurrentWeaponState = activeUnitWeaponState;
								result = activeUnitWeaponState;
								goto end_IL_0037;
								IL_168f:
								activeUnitWeaponState = (ActiveUnit._ActiveUnitWeaponState)num12;
								Cache_CurrentWeaponState = activeUnitWeaponState;
								result = activeUnitWeaponState;
								goto end_IL_0037;
							}
							goto IL_3584;
						}
						num9 = 0;
					}
					flag3 = (byte)num9 != 0;
					flag4 = false;
					if (loadout.Role == Loadout.LoadoutRole.GunsOnly)
					{
						flag3 = true;
					}
					int num14;
					if (loadout.Role != Loadout.LoadoutRole.AirSuperiority_WVR && loadout.Role != Loadout.LoadoutRole.Intercept_WVR)
					{
						if (loadout.Role != Loadout.LoadoutRole.PointDefence_WVR)
						{
							goto IL_01a0;
						}
						num14 = 1;
					}
					else
					{
						num14 = 1;
					}
					flag4 = (byte)num14 != 0;
					goto IL_01a0;
					IL_3ed6:
					AntiAirWeapon = false;
					PooledList<WeaponRec> theLoadoutWR4;
					result = (Cache_CurrentWeaponState = CheckShotgunBVR(ref theLoadoutWR4, ref AntiAirWeapon, OneEngagementOnly: true, MandatoryWVR: true, AllowWVR: false, AllowAirToAirGuns: false, ExcludeGunsFromWinchesterEvaluation: true));
					goto end_IL_0037;
					IL_334d:
					if (myUnit.WeaponState != activeUnitWeaponState2)
					{
						b = (byte?)myUnit.Doctrine.get_GunStrafing(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
						if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
						{
							string text3 = "";
							if (Operators.CompareString(myUnit.Name, myUnit.UnitClass, false) != 0)
							{
								text3 = " (" + myUnit.UnitClass + ")";
							}
							if (!myUnit.IsRTB)
							{
								myUnit.AddMessage("Doctrine allows airto-ground strafing (gun), however aircraft " + myUnit.Name + text3 + " is only armed with stand-off weapons. The aircraft will therefore return to base immediately rather than risk a close-in attack with guns. If you wish to use guns, switch to a loadout with short-range weapons, or alternatively attack manually.", myUnit.Name + " RTBing immediately", LoggedMessage.MessageType.AirOps, 1, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
							}
						}
					}
					result = activeUnitWeaponState2;
					goto end_IL_0037;
					IL_3f39:
					result = (Cache_CurrentWeaponState = CheckWinchester(ref theLoadoutWR4, AllowAirToAirGuns: false, ExcludeGunsFromWinchesterEvaluation: true));
					goto end_IL_0037;
					IL_1763:
					int num17;
					if (!method_32().ParentScen.FeatureCompatibility.get_WeaponAGL_ASL(method_32().ParentScen.DBConnection) && flag)
					{
						Loadout.LoadoutRole role2 = loadout.Role;
						if (role2 <= Loadout.LoadoutRole.LandOnly_Strike)
						{
							if (role2 != Loadout.LoadoutRole.LandNaval_Strike)
							{
								if (role2 == Loadout.LoadoutRole.LandOnly_Strike)
								{
									goto IL_1975;
								}
								num11 = 0;
								goto IL_3584;
							}
							b = (byte?)myUnit.Doctrine.get_GunStrafing(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
							if (((((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) == true) ? loadout.Weapons.Where([SpecialName] (WeaponRec WR) => (WR.get_ReferenceWeapon(myUnit.ParentScen).IsASuW_Naval || WR.get_ReferenceWeapon(myUnit.ParentScen).IsASuW_Land) && WR.get_ReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun && WR.CurrentLoad > 0).Count() : loadout.Weapons.Where([SpecialName] (WeaponRec WR) => (WR.get_ReferenceWeapon(myUnit.ParentScen).IsASuW_Naval || WR.get_ReferenceWeapon(myUnit.ParentScen).IsASuW_Land) && WR.CurrentLoad > 0).Count()) == 0)
							{
								flag5 = true;
							}
							b = (byte?)myUnit.Doctrine.get_GunStrafing(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
							int num15 = default(int);
							if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) != true)
							{
								num15 = myUnit.Mounts.Where([SpecialName] (Mount theM) => theM.Status == PlatformComponent._ComponentStatus.Operational && theM.HasGuns && !theM.IsEmpty).Count();
							}
							if (num15 == 0)
							{
								flag6 = true;
							}
							if (!flag5)
							{
								num5 = 0;
								goto IL_194b;
							}
							if (!flag6)
							{
								num5 = 0;
								goto IL_194b;
							}
							activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
							Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
							result = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
						}
						else
						{
							if (role2 != Loadout.LoadoutRole.NavalOnly_Strike)
							{
								if (role2 == Loadout.LoadoutRole.BAI_CAS)
								{
									goto IL_1975;
								}
								num11 = 0;
								goto IL_3584;
							}
							b = (byte?)myUnit.Doctrine.get_GunStrafing(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
							if (((((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) == true) ? loadout.Weapons.Where([SpecialName] (WeaponRec WR) => WR.get_ReferenceWeapon(myUnit.ParentScen).IsASuW_Naval && WR.get_ReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun && WR.CurrentLoad > 0).Count() : loadout.Weapons.Where([SpecialName] (WeaponRec WR) => WR.get_ReferenceWeapon(myUnit.ParentScen).IsASuW_Naval && WR.CurrentLoad > 0).Count()) == 0)
							{
								flag5 = true;
							}
							b = (byte?)myUnit.Doctrine.get_GunStrafing(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
							int num16 = default(int);
							if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) != true)
							{
								num16 = myUnit.Mounts.Where([SpecialName] (Mount theM) =>
								{
									int result2;
									if (theM.Status != PlatformComponent._ComponentStatus.Operational)
									{
										result2 = 0;
									}
									else
									{
										if (theM.HasGuns)
										{
											return !theM.IsEmpty;
										}
										result2 = 0;
									}
									return (byte)result2 != 0;
								}).Count();
							}
							if (num16 == 0)
							{
								flag6 = true;
							}
							if (!flag5)
							{
								num17 = 0;
								goto IL_1c82;
							}
							if (!flag6)
							{
								num17 = 0;
								goto IL_1c82;
							}
							activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
							Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
							result = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
						}
					}
					else
					{
						b = (byte?)myUnit.Doctrine.get_GunStrafing(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
						value = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)).Value;
						theLoadoutWR3 = new PooledList<WeaponRec>();
						if (!value)
						{
							if (loadout.Role == Loadout.LoadoutRole.LandNaval_Strike)
							{
								WeaponRec[] weapons3 = loadout.Weapons;
								foreach (WeaponRec weaponRec2 in weapons3)
								{
									if ((weaponRec2.get_ReferenceWeapon(myUnit.ParentScen).IsASuW_Naval || weaponRec2.get_ReferenceWeapon(myUnit.ParentScen).IsASuW_Land) && weaponRec2.get_ReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun)
									{
										theLoadoutWR3.Add(weaponRec2);
									}
								}
							}
							else if (loadout.Role == Loadout.LoadoutRole.NavalOnly_Strike)
							{
								WeaponRec[] weapons4 = loadout.Weapons;
								foreach (WeaponRec weaponRec3 in weapons4)
								{
									if (weaponRec3.get_ReferenceWeapon(myUnit.ParentScen).IsASuW_Naval && weaponRec3.get_ReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun)
									{
										theLoadoutWR3.Add(weaponRec3);
									}
								}
							}
							else
							{
								WeaponRec[] weapons5 = loadout.Weapons;
								foreach (WeaponRec weaponRec4 in weapons5)
								{
									if (weaponRec4.get_ReferenceWeapon(myUnit.ParentScen).IsASuW_Land && weaponRec4.get_ReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun)
									{
										theLoadoutWR3.Add(weaponRec4);
									}
								}
							}
						}
						else
						{
							if (loadout.Role == Loadout.LoadoutRole.LandNaval_Strike)
							{
								WeaponRec[] weapons6 = loadout.Weapons;
								foreach (WeaponRec weaponRec5 in weapons6)
								{
									if (weaponRec5.get_ReferenceWeapon(myUnit.ParentScen).IsASuW_Naval || weaponRec5.get_ReferenceWeapon(myUnit.ParentScen).IsASuW_Land)
									{
										theLoadoutWR3.Add(weaponRec5);
									}
								}
							}
							else if (loadout.Role == Loadout.LoadoutRole.NavalOnly_Strike)
							{
								WeaponRec[] weapons7 = loadout.Weapons;
								foreach (WeaponRec weaponRec6 in weapons7)
								{
									if (weaponRec6.get_ReferenceWeapon(myUnit.ParentScen).IsASuW_Naval)
									{
										theLoadoutWR3.Add(weaponRec6);
									}
								}
							}
							else
							{
								WeaponRec[] weapons8 = loadout.Weapons;
								foreach (WeaponRec weaponRec7 in weapons8)
								{
									if (weaponRec7.get_ReferenceWeapon(myUnit.ParentScen).IsASuW_Land)
									{
										theLoadoutWR3.Add(weaponRec7);
									}
								}
							}
							foreach (Mount mount in myUnit.Mounts)
							{
								if (mount.Status != PlatformComponent._ComponentStatus.Operational)
								{
									continue;
								}
								List<WeaponRec> list = new List<WeaponRec>();
								if (loadout.Role == Loadout.LoadoutRole.LandNaval_Strike)
								{
									foreach (WeaponRec mountWeapon in mount.MountWeapons)
									{
										if (mountWeapon.get_ReferenceWeapon(myUnit.ParentScen).IsASuW_Naval || mountWeapon.get_ReferenceWeapon(myUnit.ParentScen).IsASuW_Land)
										{
											list.Add(mountWeapon);
										}
									}
								}
								else if (loadout.Role != Loadout.LoadoutRole.NavalOnly_Strike)
								{
									foreach (WeaponRec mountWeapon2 in mount.MountWeapons)
									{
										if (mountWeapon2.get_ReferenceWeapon(myUnit.ParentScen).IsASuW_Land)
										{
											list.Add(mountWeapon2);
										}
									}
								}
								else
								{
									foreach (WeaponRec mountWeapon3 in mount.MountWeapons)
									{
										if (mountWeapon3.get_ReferenceWeapon(myUnit.ParentScen).IsASuW_Naval)
										{
											list.Add(mountWeapon3);
										}
									}
								}
								if (list.Count > 0)
								{
									theLoadoutWR3.AddRange(list);
								}
							}
						}
						num = (int?)weaponState;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 2001)) == true)
						{
							goto IL_2a28;
						}
						num = (int?)weaponState;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 2002)) == true)
						{
							goto IL_2a28;
						}
						num = (int?)weaponState;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 3001)) == true)
						{
							goto IL_292e;
						}
						num = (int?)weaponState;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 3002)) == true)
						{
							goto IL_292e;
						}
						num = (int?)weaponState;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 3003)) == true)
						{
							goto IL_292e;
						}
						num = (int?)weaponState;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 5001)) == true)
						{
							goto IL_2834;
						}
						num = (int?)weaponState;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 5002)) == true)
						{
							goto IL_2834;
						}
						num = (int?)weaponState;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 5003)) == true)
						{
							goto IL_2834;
						}
						num = (int?)weaponState;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 5005)) == true)
						{
							goto IL_2812;
						}
						num = (int?)weaponState;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 5006)) == true)
						{
							goto IL_2812;
						}
						num = (int?)weaponState;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 5011)) == true)
						{
							goto IL_27ef;
						}
						num = (int?)weaponState;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 5012)) == true)
						{
							goto IL_27ef;
						}
						num = (int?)weaponState;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 5021)) != true)
						{
							bool allowTargetsOfOpportunity2 = false;
							num = (int?)weaponState;
							int percentage2;
							if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 4001)) == true)
							{
								percentage2 = 25;
							}
							else
							{
								num = (int?)weaponState;
								if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 4002)) == true)
								{
									percentage2 = 25;
									allowTargetsOfOpportunity2 = true;
								}
								else
								{
									num = (int?)weaponState;
									if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 4011)) != true)
									{
										num = (int?)weaponState;
										if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 4012)) == true)
										{
											percentage2 = 50;
											allowTargetsOfOpportunity2 = true;
										}
										else
										{
											num = (int?)weaponState;
											if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 4021)) == true)
											{
												percentage2 = 75;
											}
											else
											{
												percentage2 = 75;
												allowTargetsOfOpportunity2 = true;
											}
										}
									}
									else
									{
										percentage2 = 50;
									}
								}
							}
							AntiAirWeapon = false;
							result = (Cache_CurrentWeaponState = CheckShotgunPercentage(ref theLoadoutWR3, ref AntiAirWeapon, percentage2, allowTargetsOfOpportunity2, !value));
						}
						else
						{
							AntiAirWeapon = false;
							result = (Cache_CurrentWeaponState = CheckShotgunGun(ref theLoadoutWR3, ref AntiAirWeapon, OneEngagementOnly: true, !value));
						}
					}
					goto end_IL_0037;
					IL_3486:
					if (loadout.Weapons.Where([SpecialName] (WeaponRec WR) => WR.CurrentLoad > 0 && WR.get_ReferenceWeapon(myUnit.ParentScen).IsMobileDecoy).Count() == 0)
					{
						activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
						Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
						result = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
					}
					else
					{
						activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.None;
						Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.None;
						result = ActiveUnit._ActiveUnitWeaponState.None;
					}
					goto end_IL_0037;
					IL_3ef7:
					AntiAirWeapon = false;
					result = (Cache_CurrentWeaponState = CheckShotgunBVR(ref theLoadoutWR4, ref AntiAirWeapon, OneEngagementOnly: true, MandatoryWVR: false, AllowWVR: true, AllowAirToAirGuns: false, ExcludeGunsFromWinchesterEvaluation: true));
					goto end_IL_0037;
					IL_3f68:
					activeUnitWeaponState = (ActiveUnit._ActiveUnitWeaponState)num2;
					Cache_CurrentWeaponState = activeUnitWeaponState;
					result = activeUnitWeaponState;
					goto end_IL_0037;
					IL_1213:
					PooledList<WeaponRec> theLoadoutWR5 = method_33(loadout, flag3);
					if (myUnit.ActiveMissionOrPackage() == null)
					{
						goto IL_12a5;
					}
					Mission mission = myUnit.ActiveMissionOrPackage();
					bool? flag9 = ((mission == null) ? ((bool?)null) : new bool?(mission.MissionClass == Mission._MissionClass.Strike));
					if ((((!flag9) ?? false) || ((Strike)myUnit.ActiveMissionOrPackage()).Type != Strike.StrikeType.Air_Intercept || !flag9.HasValue) && !flag3)
					{
						goto IL_12a5;
					}
					result = (Cache_CurrentWeaponState = CheckWinchester(ref theLoadoutWR5, AllowAirToAirGuns: false, ExcludeGunsFromWinchesterEvaluation: false));
					goto end_IL_0037;
					IL_292e:
					if (myUnit.WeaponState != ActiveUnit._ActiveUnitWeaponState.IsWinchester || myUnit.ParentScen.MinuteIsChangingOnThisPulse)
					{
						string text4 = "";
						if (Operators.CompareString(myUnit.Name, myUnit.UnitClass, false) != 0)
						{
							text4 = " (" + myUnit.UnitClass + ")";
						}
						if (!myUnit.IsRTB)
						{
							myUnit.AddMessage("Shotgun weapon state has been set to one engagement with Stand-Off weapons, however aircraft " + myUnit.Name + text4 + " is only armed with short-range weapons. The aircraft will therefore return to base immediately. Change the Shotgun weapon state to Short-Range weapons or Guns, or use Winchester weapon state.", myUnit.Name + " RTBing immediately", LoggedMessage.MessageType.AirOps, 1, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
						}
					}
					if (!myUnit.IsOperating())
					{
						activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.None;
						Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.None;
						result = ActiveUnit._ActiveUnitWeaponState.None;
					}
					else
					{
						activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
						Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
						result = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
					}
					goto end_IL_0037;
					IL_3584:
					activeUnitWeaponState = (ActiveUnit._ActiveUnitWeaponState)num11;
					Cache_CurrentWeaponState = activeUnitWeaponState;
					result = activeUnitWeaponState;
					goto end_IL_0037;
					IL_3f18:
					AntiAirWeapon = false;
					result = (Cache_CurrentWeaponState = CheckShotgunBVR(ref theLoadoutWR4, ref AntiAirWeapon, OneEngagementOnly: false, MandatoryWVR: false, AllowWVR: false, AllowAirToAirGuns: false, ExcludeGunsFromWinchesterEvaluation: true));
					goto end_IL_0037;
					IL_2834:
					if (myUnit.WeaponState != ActiveUnit._ActiveUnitWeaponState.IsWinchester || myUnit.ParentScen.MinuteIsChangingOnThisPulse)
					{
						string text5 = "";
						if (Operators.CompareString(myUnit.Name, myUnit.UnitClass, false) != 0)
						{
							text5 = " (" + myUnit.UnitClass + ")";
						}
						if (!myUnit.IsRTB)
						{
							myUnit.AddMessage("Shotgun weapon state has been set to one engagement with Stand-Off weapons, however aircraft " + myUnit.Name + text5 + " is only armed with short-range weapons. The aircraft will therefore return to base immediately. Change the Shotgun weapon state to Short-Range weapons or Guns, or use Winchester weapon state.", myUnit.Name + " RTBing immediately", LoggedMessage.MessageType.AirOps, 1, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
						}
					}
					if (!myUnit.IsOperating())
					{
						activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.None;
						Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.None;
						result = ActiveUnit._ActiveUnitWeaponState.None;
					}
					else
					{
						activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
						Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
						result = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
					}
					goto end_IL_0037;
					IL_2bed:
					activeUnitWeaponState = (ActiveUnit._ActiveUnitWeaponState)num8;
					Cache_CurrentWeaponState = activeUnitWeaponState;
					result = activeUnitWeaponState;
					goto end_IL_0037;
					IL_2812:
					AntiAirWeapon = false;
					result = (Cache_CurrentWeaponState = CheckShotgunBVR(ref theLoadoutWR3, ref AntiAirWeapon, OneEngagementOnly: true, MandatoryWVR: true, AllowWVR: false, AllowAirToAirGuns: false, value));
					goto end_IL_0037;
					IL_3eb7:
					AntiAirWeapon = false;
					result = (Cache_CurrentWeaponState = CheckShotgunWVR(ref theLoadoutWR4, ref AntiAirWeapon, OneEngagementOnly: true, AllowAirToAirGuns: false, ExcludeGunsFromWinchesterEvaluation: true));
					goto end_IL_0037;
					IL_0866:
					if (!flag3)
					{
						num = (int?)weaponState;
						bool value2 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 3003)).Value;
						PooledList<WeaponRec> theLoadoutWR6 = method_33(loadout, flag3);
						AntiAirWeapon = true;
						result = (Cache_CurrentWeaponState = CheckShotgunWVR(ref theLoadoutWR6, ref AntiAirWeapon, OneEngagementOnly: true, value2, ExcludeGunsFromWinchesterEvaluation: true));
					}
					else
					{
						if (myUnit.WeaponState != ActiveUnit._ActiveUnitWeaponState.IsWinchester || myUnit.ParentScen.MinuteIsChangingOnThisPulse)
						{
							string text6 = "";
							if (Operators.CompareString(myUnit.Name, myUnit.UnitClass, false) != 0)
							{
								text6 = " (" + myUnit.UnitClass + ")";
							}
							if (!myUnit.IsRTB)
							{
								myUnit.AddMessage("Shotgun weapon state has been set to Beyond Visual Range (BVR) exhaustion, however aircraft " + myUnit.Name + text6 + " is only armed with guns. The aircraft will therefore return to base immediately. Change the Shotgun weapon state to Guns, or use Winchester weapon state.", myUnit.Name + " RTBing immediately", LoggedMessage.MessageType.AirOps, 1, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
							}
						}
						if (!myUnit.IsOperating())
						{
							activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.None;
							Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.None;
							result = ActiveUnit._ActiveUnitWeaponState.None;
						}
						else
						{
							activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
							Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
							result = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
						}
					}
					goto end_IL_0037;
					IL_0b65:
					bool allowWVR = (byte)num3 != 0;
					num = (int?)weaponState;
					int num24;
					if (!((!num.HasValue) ? ((bool?)null) : new bool?(num == 5003)).Value)
					{
						num = (int?)weaponState;
						num24 = (((!num.HasValue) ? ((bool?)null) : new bool?(num == 5006)).Value ? 1 : 0);
					}
					else
					{
						num24 = 1;
					}
					bool allowAirToAirGuns = (byte)num24 != 0;
					num = (int?)weaponState;
					int num25;
					if (!((!num.HasValue) ? ((bool?)null) : new bool?(num == 5005)).Value)
					{
						num = (int?)weaponState;
						num25 = (((!num.HasValue) ? ((bool?)null) : new bool?(num == 5006)).Value ? 1 : 0);
					}
					else
					{
						num25 = 1;
					}
					bool mandatoryWVR = (byte)num25 != 0;
					AntiAirWeapon = true;
					result = (Cache_CurrentWeaponState = CheckShotgunBVR(ref theLoadoutWR, ref AntiAirWeapon, OneEngagementOnly: true, mandatoryWVR, allowWVR, allowAirToAirGuns, ExcludeGunsFromWinchesterEvaluation: true));
					goto end_IL_0037;
					IL_01a0:
					num = (int?)weaponState;
					if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 2001)) == true)
					{
						goto IL_1213;
					}
					num = (int?)weaponState;
					if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 2002)) == true)
					{
						goto IL_1213;
					}
					num = (int?)weaponState;
					if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 3001)) == true)
					{
						goto IL_0edd;
					}
					num = (int?)weaponState;
					if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 3002)) == true)
					{
						goto IL_0edd;
					}
					num = (int?)weaponState;
					if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 3003)) == true)
					{
						goto IL_0edd;
					}
					num = (int?)weaponState;
					if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 5001)) == true)
					{
						goto IL_09e9;
					}
					num = (int?)weaponState;
					if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 5002)) == true)
					{
						goto IL_09e9;
					}
					num = (int?)weaponState;
					if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 5003)) == true)
					{
						goto IL_09e9;
					}
					num = (int?)weaponState;
					if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 5005)) == true)
					{
						goto IL_09e9;
					}
					num = (int?)weaponState;
					if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 5006)) == true)
					{
						goto IL_09e9;
					}
					num = (int?)weaponState;
					if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 5011)) == true)
					{
						goto IL_0866;
					}
					num = (int?)weaponState;
					if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 5012)) == true)
					{
						goto IL_0866;
					}
					num = (int?)weaponState;
					if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 5021)) == true)
					{
						PooledList<WeaponRec> theLoadoutWR7 = method_33(loadout, flag3);
						AntiAirWeapon = true;
						result = (Cache_CurrentWeaponState = CheckShotgunGun(ref theLoadoutWR7, ref AntiAirWeapon, OneEngagementOnly: true, !flag3));
					}
					else
					{
						PooledList<WeaponRec> theLoadoutWR8 = method_33(loadout, flag3);
						bool allowTargetsOfOpportunity3 = false;
						num = (int?)weaponState;
						int percentage3;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 4001)) != true)
						{
							num = (int?)weaponState;
							if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 4002)) != true)
							{
								num = (int?)weaponState;
								if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 4011)) != true)
								{
									num = (int?)weaponState;
									if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 4012)) == true)
									{
										percentage3 = 50;
										allowTargetsOfOpportunity3 = true;
									}
									else
									{
										num = (int?)weaponState;
										if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 4021)) == true)
										{
											percentage3 = 75;
										}
										else
										{
											percentage3 = 75;
											allowTargetsOfOpportunity3 = true;
										}
									}
								}
								else
								{
									percentage3 = 50;
								}
							}
							else
							{
								percentage3 = 25;
								allowTargetsOfOpportunity3 = true;
							}
						}
						else
						{
							percentage3 = 25;
						}
						AntiAirWeapon = true;
						result = (Cache_CurrentWeaponState = CheckShotgunPercentage(ref theLoadoutWR8, ref AntiAirWeapon, percentage3, allowTargetsOfOpportunity3, !flag3));
					}
					goto end_IL_0037;
					IL_27ef:
					AntiAirWeapon = false;
					result = (Cache_CurrentWeaponState = CheckShotgunWVR(ref theLoadoutWR3, ref AntiAirWeapon, OneEngagementOnly: true, AllowAirToAirGuns: false, !value));
					goto end_IL_0037;
					IL_1975:
					b = (byte?)myUnit.Doctrine.get_GunStrafing(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
					if (((((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) != true) ? loadout.Weapons.Where([SpecialName] (WeaponRec WR) => WR.get_ReferenceWeapon(myUnit.ParentScen).IsASuW_Land && WR.CurrentLoad > 0).Count() : loadout.Weapons.Where([SpecialName] (WeaponRec WR) => WR.get_ReferenceWeapon(myUnit.ParentScen).IsASuW_Land && WR.get_ReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun && WR.CurrentLoad > 0).Count()) == 0)
					{
						flag5 = true;
					}
					b = (byte?)myUnit.Doctrine.get_GunStrafing(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
					int num26 = default(int);
					if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) != true)
					{
						num26 = myUnit.Mounts.Where([SpecialName] (Mount theM) =>
						{
							int result2;
							if (theM.Status != PlatformComponent._ComponentStatus.Operational)
							{
								result2 = 0;
							}
							else
							{
								if (theM.HasGuns)
								{
									return !theM.IsEmpty;
								}
								result2 = 0;
							}
							return (byte)result2 != 0;
						}).Count();
					}
					if (num26 == 0)
					{
						flag6 = true;
					}
					if (!flag5)
					{
						num4 = 0;
						goto IL_1afc;
					}
					if (!flag6)
					{
						num4 = 0;
						goto IL_1afc;
					}
					activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
					Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
					result = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
					goto end_IL_0037;
					IL_35d2:
					if (loadout.Weapons.Where([SpecialName] (WeaponRec WR) =>
					{
						int result2;
						if (!WR.get_ReferenceWeapon(myUnit.ParentScen).IsASuW_Land && !WR.get_ReferenceWeapon(myUnit.ParentScen).IsAntiradar)
						{
							result2 = 0;
						}
						else
						{
							if (WR.get_ReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun)
							{
								return WR.CurrentLoad > 0;
							}
							result2 = 0;
						}
						return (byte)result2 != 0;
					}).Count() != 0)
					{
						activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.None;
						Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.None;
						result = ActiveUnit._ActiveUnitWeaponState.None;
					}
					else
					{
						activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
						Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
						result = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
					}
					goto end_IL_0037;
					IL_1c82:
					activeUnitWeaponState = (ActiveUnit._ActiveUnitWeaponState)num17;
					Cache_CurrentWeaponState = activeUnitWeaponState;
					result = activeUnitWeaponState;
					goto end_IL_0037;
					IL_12a5:
					num = (int?)weaponState;
					result = (Cache_CurrentWeaponState = CheckWinchester(ref theLoadoutWR5, (num.HasValue ? new bool?(num == 2002) : ((bool?)null)).Value, !flag3));
					goto end_IL_0037;
					IL_0edd:
					if (!flag3)
					{
						if (flag4)
						{
							if (myUnit.WeaponState != ActiveUnit._ActiveUnitWeaponState.IsWinchester || myUnit.ParentScen.MinuteIsChangingOnThisPulse)
							{
								string text7 = "";
								if (Operators.CompareString(myUnit.Name, myUnit.UnitClass, false) != 0)
								{
									text7 = " (" + myUnit.UnitClass + ")";
								}
								if (!myUnit.IsRTB)
								{
									myUnit.AddMessage("Shotgun weapon state has been set to Beyond Visual Range (BVR) exhaustion, however aircraft " + myUnit.Name + text7 + " is only armed with Within Visual Range (WVR) weapons. The aircraft will therefore return to base immediately. Change the Shotgun weapon state to Guns or WVR, or use Winchester weapon state.", myUnit.Name + " RTBing immediately", LoggedMessage.MessageType.AirOps, 1, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
								}
							}
							if (!myUnit.IsOperating())
							{
								activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.None;
								Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.None;
								result = ActiveUnit._ActiveUnitWeaponState.None;
							}
							else
							{
								activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
								Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
								result = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
							}
						}
						else
						{
							PooledList<WeaponRec> theLoadoutWR9 = method_33(loadout, flag3);
							num = (int?)weaponState;
							int num27;
							if (!((!num.HasValue) ? ((bool?)null) : new bool?(num == 3002)).Value)
							{
								num = (int?)weaponState;
								num27 = (((!num.HasValue) ? ((bool?)null) : new bool?(num == 3003)).Value ? 1 : 0);
							}
							else
							{
								num27 = 1;
							}
							bool allowWVR2 = (byte)num27 != 0;
							num = (int?)weaponState;
							bool value3 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 3003)).Value;
							AntiAirWeapon = true;
							result = (Cache_CurrentWeaponState = CheckShotgunBVR(ref theLoadoutWR9, ref AntiAirWeapon, OneEngagementOnly: false, MandatoryWVR: false, allowWVR2, value3, ExcludeGunsFromWinchesterEvaluation: true));
						}
					}
					else
					{
						if (myUnit.WeaponState != ActiveUnit._ActiveUnitWeaponState.IsWinchester || myUnit.ParentScen.MinuteIsChangingOnThisPulse)
						{
							string text8 = "";
							if (Operators.CompareString(myUnit.Name, myUnit.UnitClass, false) != 0)
							{
								text8 = " (" + myUnit.UnitClass + ")";
							}
							if (!myUnit.IsRTB)
							{
								myUnit.AddMessage("Shotgun weapon state has been set to Beyond Visual Range (BVR) exhaustion, however aircraft " + myUnit.Name + text8 + " is only armed with guns. The aircraft will therefore return to base immediately. Change the Shotgun weapon state to Guns, or use Winchester weapon state.", myUnit.Name + " RTBing immediately", LoggedMessage.MessageType.AirOps, 1, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
							}
						}
						if (myUnit.IsOperating())
						{
							activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
							Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
							result = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
						}
						else
						{
							activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.None;
							Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.None;
							result = ActiveUnit._ActiveUnitWeaponState.None;
						}
					}
					goto end_IL_0037;
					IL_34c5:
					if (!method_32().ParentScen.FeatureCompatibility.get_WeaponAGL_ASL(method_32().ParentScen.DBConnection) && flag)
					{
						Loadout.LoadoutRole role3 = loadout.Role;
						if (role3 <= Loadout.LoadoutRole.LandOnly_SEAD_ARM)
						{
							if (role3 != Loadout.LoadoutRole.LandNaval_SEAD_ARM && role3 != Loadout.LoadoutRole.LandNaval_DEAD)
							{
								if (role3 != Loadout.LoadoutRole.LandOnly_SEAD_ARM)
								{
									num11 = 0;
									goto IL_3584;
								}
								goto IL_35d2;
							}
							if (loadout.Weapons.Where([SpecialName] (WeaponRec WR) =>
							{
								int result2;
								if (!WR.get_ReferenceWeapon(myUnit.ParentScen).IsASuW_Naval && !WR.get_ReferenceWeapon(myUnit.ParentScen).IsASuW_Land && !WR.get_ReferenceWeapon(myUnit.ParentScen).IsAntiradar)
								{
									result2 = 0;
								}
								else
								{
									if (WR.get_ReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun)
									{
										return WR.CurrentLoad > 0;
									}
									result2 = 0;
								}
								return (byte)result2 != 0;
							}).Count() == 0)
							{
								activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
								Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
								result = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
							}
							else
							{
								activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.None;
								Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.None;
								result = ActiveUnit._ActiveUnitWeaponState.None;
							}
						}
						else
						{
							if (role3 == Loadout.LoadoutRole.LandOnly_DEAD)
							{
								goto IL_35d2;
							}
							if (role3 != Loadout.LoadoutRole.NavalOnly_SEAD_ARM && role3 != Loadout.LoadoutRole.NavalOnly_DEAD)
							{
								num11 = 0;
								goto IL_3584;
							}
							if (loadout.Weapons.Where([SpecialName] (WeaponRec WR) =>
							{
								int result2;
								if (!WR.get_ReferenceWeapon(myUnit.ParentScen).IsASuW_Naval && !WR.get_ReferenceWeapon(myUnit.ParentScen).IsAntiradar)
								{
									result2 = 0;
								}
								else
								{
									if (WR.get_ReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun)
									{
										return WR.CurrentLoad > 0;
									}
									result2 = 0;
								}
								return (byte)result2 != 0;
							}).Count() == 0)
							{
								activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
								Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
								result = ActiveUnit._ActiveUnitWeaponState.IsWinchester;
							}
							else
							{
								activeUnitWeaponState = ActiveUnit._ActiveUnitWeaponState.None;
								Cache_CurrentWeaponState = ActiveUnit._ActiveUnitWeaponState.None;
								result = ActiveUnit._ActiveUnitWeaponState.None;
							}
						}
					}
					else
					{
						theLoadoutWR4 = new PooledList<WeaponRec>();
						switch (loadout.Role)
						{
						case Loadout.LoadoutRole.LandNaval_SEAD_ARM:
						case Loadout.LoadoutRole.LandNaval_DEAD:
						{
							WeaponRec[] weapons10 = loadout.Weapons;
							foreach (WeaponRec weaponRec9 in weapons10)
							{
								if ((weaponRec9.get_ReferenceWeapon(myUnit.ParentScen).IsASuW_Naval || weaponRec9.get_ReferenceWeapon(myUnit.ParentScen).IsASuW_Land || weaponRec9.get_ReferenceWeapon(myUnit.ParentScen).IsAntiradar) && weaponRec9.get_ReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun)
								{
									theLoadoutWR4.Add(weaponRec9);
								}
							}
							break;
						}
						case Loadout.LoadoutRole.NavalOnly_SEAD_ARM:
						case Loadout.LoadoutRole.NavalOnly_DEAD:
						{
							WeaponRec[] weapons11 = loadout.Weapons;
							foreach (WeaponRec weaponRec10 in weapons11)
							{
								if ((weaponRec10.get_ReferenceWeapon(myUnit.ParentScen).IsASuW_Naval || weaponRec10.get_ReferenceWeapon(myUnit.ParentScen).IsAntiradar) && weaponRec10.get_ReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun)
								{
									theLoadoutWR4.Add(weaponRec10);
								}
							}
							break;
						}
						case Loadout.LoadoutRole.LandOnly_SEAD_ARM:
						case Loadout.LoadoutRole.LandOnly_DEAD:
						{
							WeaponRec[] weapons9 = loadout.Weapons;
							foreach (WeaponRec weaponRec8 in weapons9)
							{
								if ((weaponRec8.get_ReferenceWeapon(myUnit.ParentScen).IsASuW_Land || weaponRec8.get_ReferenceWeapon(myUnit.ParentScen).IsAntiradar) && weaponRec8.get_ReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun)
								{
									theLoadoutWR4.Add(weaponRec8);
								}
							}
							break;
						}
						}
						num = (int?)weaponState;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 2001)) == true)
						{
							goto IL_3f39;
						}
						num = (int?)weaponState;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 2002)) == true)
						{
							goto IL_3f39;
						}
						num = (int?)weaponState;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 3001)) == true)
						{
							goto IL_3f18;
						}
						num = (int?)weaponState;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 3002)) == true)
						{
							goto IL_3f18;
						}
						num = (int?)weaponState;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 3003)) == true)
						{
							goto IL_3f18;
						}
						num = (int?)weaponState;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 5001)) == true)
						{
							goto IL_3ef7;
						}
						num = (int?)weaponState;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 5002)) == true)
						{
							goto IL_3ef7;
						}
						num = (int?)weaponState;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 5003)) == true)
						{
							goto IL_3ef7;
						}
						num = (int?)weaponState;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 5005)) == true)
						{
							goto IL_3ed6;
						}
						num = (int?)weaponState;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 5006)) == true)
						{
							goto IL_3ed6;
						}
						num = (int?)weaponState;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 5011)) == true)
						{
							goto IL_3eb7;
						}
						num = (int?)weaponState;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 5012)) == true)
						{
							goto IL_3eb7;
						}
						num = (int?)weaponState;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 5021)) != true)
						{
							bool allowTargetsOfOpportunity4 = false;
							num = (int?)weaponState;
							int percentage4;
							if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 4001)) == true)
							{
								percentage4 = 25;
							}
							else
							{
								num = (int?)weaponState;
								if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 4002)) == true)
								{
									percentage4 = 25;
									allowTargetsOfOpportunity4 = true;
								}
								else
								{
									num = (int?)weaponState;
									if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 4011)) == true)
									{
										percentage4 = 50;
									}
									else
									{
										num = (int?)weaponState;
										if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 4012)) == true)
										{
											percentage4 = 50;
											allowTargetsOfOpportunity4 = true;
										}
										else
										{
											num = (int?)weaponState;
											if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 4021)) == true)
											{
												percentage4 = 75;
											}
											else
											{
												percentage4 = 75;
												allowTargetsOfOpportunity4 = true;
											}
										}
									}
								}
							}
							AntiAirWeapon = false;
							result = (Cache_CurrentWeaponState = CheckShotgunPercentage(ref theLoadoutWR4, ref AntiAirWeapon, percentage4, allowTargetsOfOpportunity4, ExcludeGunsFromWinchesterEvaluation: true));
						}
						else
						{
							AntiAirWeapon = false;
							result = (Cache_CurrentWeaponState = CheckShotgunGun(ref theLoadoutWR4, ref AntiAirWeapon, OneEngagementOnly: true, ExcludeGunsFromWinchesterEvaluation: true));
						}
					}
					end_IL_0037:;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 200295", ex2.Message);
					GameGeneral.WriteExceptionsToLog(ex2);
					int num31;
					if (Debugger.IsAttached)
					{
						Debugger.Break();
						num31 = 0;
					}
					else
					{
						num31 = 0;
					}
					result = (ActiveUnit._ActiveUnitWeaponState)num31;
					ProjectData.ClearProjectError();
				}
			}
		}
		return result;
	}

	public void DropSonobuoy(float elapsedTime, bool IsManual, ref string UserFeedback, SonarModel.PositionRelativeToThermocline? DepthSetting = null, bool? DropActive = null)
	{
		List<WeaponRec> list = new List<WeaponRec>();
		List<WeaponRec> list2 = new List<WeaponRec>();
		List<WeaponRec> list3 = new List<WeaponRec>();
		try
		{
			bool flag = false;
			CommDevice[] comms_ReadOnly = myUnit.Comms_ReadOnly;
			foreach (CommDevice commDevice in comms_ReadOnly)
			{
				if (commDevice.IsSonobuoyLink && commDevice.OccupiedChannels < commDevice.MaxChannels)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				UserFeedback = "Cannot drop anymore sonobuoys, no channel available";
				return;
			}
			if (SeaIceProvider.PointIsUnderIce(method_32().get_Longitude((GlobalVariables.BooleanObject)null), method_32().get_Latitude((GlobalVariables.BooleanObject)null)))
			{
				if (IsManual)
				{
					UserFeedback = "Cannot drop sonobuoy over ice!";
				}
				return;
			}
			foreach (Mount mount in method_32().Mounts)
			{
				foreach (WeaponRec mountWeapon in mount.MountWeapons)
				{
					mountWeapon.ParentMount = mount;
					if (mountWeapon.get_ReferenceWeapon(myUnit.ParentScen).Type == Weapon._WeaponType.Sonobuoy && mountWeapon.CurrentLoad != 0 && mount.Status == PlatformComponent._ComponentStatus.Operational && mount.TimeToFire == 0f && mountWeapon.TimeToFire == 0f)
					{
						list.Add(mountWeapon);
					}
				}
			}
			if (method_32().Loadout != null)
			{
				WeaponRec[] weapons = method_32().Loadout.Weapons;
				foreach (WeaponRec current2 in weapons)
				{
					current2.ParentMount = null;
					if (current2.get_ReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Sonobuoy || current2.CurrentLoad == 0 || current2.TimeToFire > 0f)
					{
						continue;
					}
					list.Add(current2);
					if (current2.get_ReferenceWeapon(myUnit.ParentScen).WeaponSensors().Count > 0)
					{
						if (current2.get_ReferenceWeapon(myUnit.ParentScen).WeaponSensors()[0].HasActiveModeOnly)
						{
							list2.Add(current2);
						}
						else
						{
							list3.Add(current2);
						}
					}
					else
					{
						list2.Add(current2);
						list3.Add(current2);
					}
				}
			}
			if (list.Count == 0)
			{
				if (IsManual)
				{
					UserFeedback = "No sonobuoys left!";
				}
				return;
			}
			bool flag2;
			if (flag2 = !IsManual && !DropActive.HasValue)
			{
				DropActive = false;
				Doctrine.EMCONSettings eMCONSettings = myUnit.Doctrine.EMCON(myUnit.ParentScen);
				DropActive = eMCONSettings != null && eMCONSettings.Sonar() == Doctrine.EMCONSettings._EMCONSetting.Active;
			}
			if (DropActive.HasValue)
			{
				list = (flag2 ? ((DropActive.Value && list2.Count > 0) ? list2 : ((DropActive.Value || list3.Count != 0) ? list3 : list2)) : ((!DropActive.Value) ? list3 : list2));
			}
			if (list.Count == 0)
			{
				if (IsManual)
				{
					UserFeedback = "No sonobuoy of desired type left!";
				}
				return;
			}
			WeaponRec theWeaponRec = ((list.Count != 1) ? list[GameGeneral.GlobalRNG.Next(0, list.Count)] : list[0]);
			if (!DepthSetting.HasValue)
			{
				DepthSetting = ((GameGeneral.GlobalRNG.Next(0, 1000) <= 500) ? new SonarModel.PositionRelativeToThermocline?(SonarModel.PositionRelativeToThermocline.Below) : new SonarModel.PositionRelativeToThermocline?(SonarModel.PositionRelativeToThermocline.Above));
			}
			int NumberOfWeaponsFired = 0;
			SonarModel.PositionRelativeToThermocline value = DepthSetting.Value;
			WeaponSalvo theWeaponSalvo = null;
			FireWeapon_Normal(elapsedTime, ref theWeaponRec, null, ref NumberOfWeaponsFired, 0, 0f, ActiveUnit.Throttle.Flank, null, value, 0L, ref theWeaponSalvo);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100476", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool IsGuidingStandoffWeaponOntoThisContact(Contact theContact)
	{
		int result;
		if (myUnit.ParentScen.GuidedWeaponsInAir == null)
		{
			result = 0;
		}
		else
		{
			if (myUnit.ParentScen.GuidedWeaponsInAir.Count > 0)
			{
				foreach (Weapon item in myUnit.ParentScen.GuidedWeaponsInAir)
				{
					if (item.AI.PrimaryTarget == theContact && item.FiringParent == myUnit)
					{
						if (item.Flags.TerminalIllumination || item.Flags.IlluminateAtLaunch)
						{
							return true;
						}
						if (item.Guidance == Weapon.WeaponGuidanceType.CommandGuided_Datalinked)
						{
							return true;
						}
					}
				}
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	static Aircraft_Weaponry()
	{
		Class72.smethod_20();
	}
}
