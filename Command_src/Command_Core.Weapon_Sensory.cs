using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ThreadSafeCollections;

namespace Command_Core;

public sealed class Weapon_Sensory : ActiveUnit_Sensory
{
	private Weapon weapon_0;

	internal float TerminalSensorMaxRange;

	[SpecialName]
	private Weapon method_33()
	{
		if (weapon_0 == null)
		{
			weapon_0 = (Weapon)myUnit;
		}
		return weapon_0;
	}

	public override void ToXML(ref XmlWriter theWriter)
	{
		try
		{
			theWriter.WriteStartElement("Weapon_Sensory");
			theWriter.WriteElementString("ObE", ObeysEMCON.ToString());
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100988", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void PerformDetections(Sensor[] SensorsList, List<ActiveUnit> OffGridUnits, float elapsedTime)
	{
		if (!(method_33().TimeToReseek > 0f) && (!method_33().IsMissile || !method_33().Navigator.HasPlottedCourse()))
		{
			base.PerformDetections(SensorsList, OffGridUnits, elapsedTime);
		}
	}

	public new static Weapon_Sensory FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		Weapon_Sensory result;
		try
		{
			Weapon_Sensory weapon_Sensory = new Weapon_Sensory(ref theAU);
			weapon_Sensory.myUnit = theAU;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				string name = val.Name;
				if (Operators.CompareString(name, "ObeysEMCON", false) == 0 || Operators.CompareString(name, "ObE", false) == 0)
				{
					weapon_Sensory.ObeysEMCON = Misc.ParseBool(val.InnerText);
				}
			}
			result = weapon_Sensory;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100990", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Weapon_Sensory(ref theAU);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public Weapon_Sensory(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
		TerminalSensorMaxRange = -1f;
		ObeysEMCON = false;
	}

	public float GetTerminalSensorMaxRange()
	{
		float[] array = new float[method_33().WeaponSensors().Count + 1];
		if (method_33().WeaponSensors().Count == 0)
		{
			Warhead[] warheads = method_33().Warheads;
			foreach (Warhead warhead in warheads)
			{
				if (warhead.Type != Warhead.WarheadType.Weapon)
				{
					continue;
				}
				Weapon weapon = warhead.get_CarriedWeapon(method_33().ParentScen);
				int num = weapon.WeaponSensors().Count - 1;
				for (int j = 0; j <= num; j++)
				{
					if (weapon.WeaponSensors()[j].Type != Sensor.Sensor_Type.ESM || method_33().ValidTargets.Radar)
					{
						array[j] = weapon.WeaponSensors()[j].maxRange;
					}
				}
			}
		}
		else
		{
			int num2 = method_33().WeaponSensors().Count - 1;
			for (int k = 0; k <= num2; k++)
			{
				if (method_33().WeaponSensors()[k].Type != Sensor.Sensor_Type.ESM || method_33().ValidTargets.Radar)
				{
					array[k] = method_33().WeaponSensors()[k].maxRange;
				}
			}
		}
		float[] array2 = array;
		float num4 = default(float);
		foreach (float num3 in array2)
		{
			if (num3 > num4)
			{
				num4 = num3;
			}
		}
		return num4;
	}

	public void ActivateTerminalSensors()
	{
		Sensor[] sensors_Cached = method_33().Sensors_Cached;
		foreach (Sensor sensor in sensors_Cached)
		{
			if (sensor.CanBeActive)
			{
				sensor.GoActive();
			}
		}
	}

	internal bool HasAnyCurrentLocalTrackOnThisContact(Contact theContact)
	{
		if (base._ContactsList_Local.Count == 0)
		{
			return false;
		}
		int result2;
		if (theContact != null)
		{
			if (theContact.ActualUnit != null)
			{
				ContactEntry_Local value = null;
				int result;
				if (base._ContactsList_Local.TryGetValue(theContact.ActualUnit.ObjectID, out value))
				{
					if (method_33().IsBrilliantWeapon)
					{
						return true;
					}
					Sensor[] sensors_Cached = myUnit.Sensors_Cached;
					foreach (Sensor obj in sensors_Cached)
					{
						int scanInterval = obj.ScanInterval;
						switch (obj.Type)
						{
						case Sensor.Sensor_Type.ESM:
							if (!value.TimeSinceDetection_ESM.HasValue)
							{
								break;
							}
							if (!method_33().Flags.ARMTargetMemory)
							{
								float? timeSinceDetection_SonarPassive = value.TimeSinceDetection_ESM;
								float num = scanInterval;
								if ((timeSinceDetection_SonarPassive.HasValue ? new bool?(timeSinceDetection_SonarPassive.GetValueOrDefault() <= num) : ((bool?)null)) != true)
								{
									break;
								}
							}
							return true;
						case Sensor.Sensor_Type.Radar:
						case Sensor.Sensor_Type.SemiActive:
							if (value.TimeSinceDetection_Radar.HasValue)
							{
								float? timeSinceDetection_SonarPassive = value.TimeSinceDetection_Radar;
								float num = scanInterval;
								if ((timeSinceDetection_SonarPassive.HasValue ? new bool?(timeSinceDetection_SonarPassive.GetValueOrDefault() <= num) : ((bool?)null)) == true)
								{
									return true;
								}
							}
							break;
						case Sensor.Sensor_Type.Visual:
							if (value.TimeSinceDetection_Visual.HasValue)
							{
								float? timeSinceDetection_SonarPassive = value.TimeSinceDetection_Visual;
								float num = scanInterval;
								if (((!timeSinceDetection_SonarPassive.HasValue) ? ((bool?)null) : new bool?(timeSinceDetection_SonarPassive.GetValueOrDefault() <= num)) == true)
								{
									return true;
								}
							}
							break;
						case Sensor.Sensor_Type.Infrared:
							if (value.TimeSinceDetection_Infrared.HasValue)
							{
								float? timeSinceDetection_SonarPassive = value.TimeSinceDetection_Infrared;
								float num = scanInterval;
								if (((!timeSinceDetection_SonarPassive.HasValue) ? ((bool?)null) : new bool?(timeSinceDetection_SonarPassive.GetValueOrDefault() <= num)) == true)
								{
									return true;
								}
							}
							break;
						case Sensor.Sensor_Type.HullSonar_ActivePassive:
						case Sensor.Sensor_Type.HullSonar_ActiveOnly:
						case Sensor.Sensor_Type.TowedArray_ActivePassive:
						case Sensor.Sensor_Type.TowedArray_ActiveOnly:
						case Sensor.Sensor_Type.VDS_ActivePassive:
						case Sensor.Sensor_Type.VDS_ActiveOnly:
						case Sensor.Sensor_Type.DippingSonar_ActivePassive:
						case Sensor.Sensor_Type.DippingSonar_ActiveOnly:
							if (value.TimeSinceDetection_SonarActive.HasValue)
							{
								float? timeSinceDetection_SonarPassive = value.TimeSinceDetection_SonarActive;
								float num = scanInterval;
								if (((!timeSinceDetection_SonarPassive.HasValue) ? ((bool?)null) : new bool?(timeSinceDetection_SonarPassive.GetValueOrDefault() <= num)) == true)
								{
									return true;
								}
							}
							break;
						case Sensor.Sensor_Type.HullSonar_PassiveOnly:
						case Sensor.Sensor_Type.TowedArray_PassiveOnly:
						case Sensor.Sensor_Type.VDS_PassiveOnly:
						case Sensor.Sensor_Type.DippingSonar_PassiveOnly:
						case Sensor.Sensor_Type.BottomFixedSonar_PassiveOnly:
							if (value.TimeSinceDetection_SonarPassive.HasValue)
							{
								float? timeSinceDetection_SonarPassive = value.TimeSinceDetection_SonarPassive;
								float num = scanInterval;
								if (((!timeSinceDetection_SonarPassive.HasValue) ? ((bool?)null) : new bool?(timeSinceDetection_SonarPassive.GetValueOrDefault() <= num)) == true)
								{
									return true;
								}
							}
							break;
						}
					}
					result = 0;
				}
				else
				{
					result = 0;
				}
				return (byte)result != 0;
			}
			result2 = 0;
		}
		else
		{
			result2 = 0;
		}
		return (byte)result2 != 0;
	}

	public override void HandleDetectedContact_OnGrid(ActiveUnit theSensorUnit, Side theSide, (Contact, ActiveUnit, List<Sensor>, float, SpecialDetectionMode, DateTime, List<Geopoint_Struct>) theDetectionRecord, bool IgnoreLuaHook = false)
	{
		var (contact, activeUnit, list, num, _, _, _) = theDetectionRecord;
		try
		{
			if (((Weapon_CommStuff)theSensorUnit.CommStuff).CanSendDataToParent)
			{
				base.HandleDetectedContact_OnGrid(theSensorUnit, theSide, theDetectionRecord, IgnoreLuaHook);
				return;
			}
			Contact myContact = null;
			Contact[] targets_ReadOnly = theSensorUnit.AI.Targets_ReadOnly;
			Weapon weapon = (Weapon)theSensorUnit;
			TObservableDictionary<int, EmissionContainer> detectedEmissions = contact.DetectedEmissions;
			bool flag = default(bool);
			int num2;
			if (!weapon.ValidTargets.Radar)
			{
				foreach (Sensor item in list)
				{
					if (ActiveUnit_Sensory.DetectionIsPrecise(item, item.ParentPlatform.RangeToUnit_Horiz(contact, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue)))
					{
						flag = true;
						break;
					}
				}
				num2 = 0;
			}
			else
			{
				flag = true;
				num2 = 0;
			}
			bool flag2 = (byte)num2 != 0;
			for (int i = targets_ReadOnly.Count() - 1; i >= 0; i += -1)
			{
				if (targets_ReadOnly[i].ActualUnit == activeUnit)
				{
					flag2 = true;
					if (flag || targets_ReadOnly[i].RemainingContinousTrackTime_Precise > 0f)
					{
						targets_ReadOnly[i].IsPreciselyLocatedOnThisPulse = true;
					}
					ActiveUnit_Sensory.UpdateContactData(ref myUnit, ref targets_ReadOnly[i], activeUnit, ContactIsNew: false);
					ActiveUnit_Sensory.MergeDetectedEmissions(targets_ReadOnly[i], detectedEmissions);
					myContact = targets_ReadOnly[i];
					break;
				}
			}
			if (!flag2)
			{
				myContact = Contact.Instantiate(activeUnit);
				if (flag)
				{
					myContact.IsPreciselyLocatedOnThisPulse = true;
				}
				ActiveUnit_Sensory.UpdateContactData(ref myUnit, ref myContact, activeUnit, ContactIsNew: true);
				if (detectedEmissions.Count != 0)
				{
					myContact.DetectedEmissions = detectedEmissions;
				}
			}
			Contact primaryTarget = myUnit.AI.PrimaryTarget;
			if (!weapon.Is_LOAL_capable && primaryTarget != null && primaryTarget.ActualUnit != null && Operators.CompareString(primaryTarget.ActualUnit.ObjectID, myContact.ActualUnit.ObjectID, false) == 0 && !primaryTarget.ActualUnit.IsFixedFacility)
			{
				myUnit.AI.PrimaryTarget = myContact;
			}
			if (num < 5f)
			{
				foreach (Sensor item2 in list)
				{
					_ = item2;
					myContact.RemainingContinousTrackTime = Math.Max(myContact.RemainingContinousTrackTime, 15f);
				}
				if (primaryTarget != null && primaryTarget.ActualUnit != null && Operators.CompareString(primaryTarget.ActualUnit.ObjectID, myContact.ActualUnit.ObjectID, false) == 0)
				{
					foreach (Sensor item3 in list)
					{
						myContact.RemainingContinousTrackTime = Math.Max(myContact.RemainingContinousTrackTime, 15f);
						if (ActiveUnit_Sensory.DetectionIsPrecise(item3, Module_Unit.RangeToUnit_Slant(item3.ParentPlatform, myContact)))
						{
							myContact.RemainingContinousTrackTime_Precise = Math.Max(myContact.RemainingContinousTrackTime_Precise, 15f);
						}
					}
				}
			}
			else
			{
				foreach (Sensor item4 in list)
				{
					myContact.RemainingContinousTrackTime = Math.Max(myContact.RemainingContinousTrackTime, item4.ScanInterval);
				}
				if (primaryTarget != null && primaryTarget.ActualUnit != null && Operators.CompareString(primaryTarget.ActualUnit.ObjectID, myContact.ActualUnit.ObjectID, false) == 0)
				{
					foreach (Sensor item5 in list)
					{
						myContact.RemainingContinousTrackTime = Math.Max(myContact.RemainingContinousTrackTime, item5.ScanInterval);
						if (ActiveUnit_Sensory.DetectionIsPrecise(item5, Module_Unit.RangeToUnit_Slant(item5.ParentPlatform, myContact)))
						{
							myContact.RemainingContinousTrackTime_Precise = Math.Max(myContact.RemainingContinousTrackTime_Precise, item5.ScanInterval);
						}
					}
				}
			}
			if (list.Count != 0)
			{
				foreach (Sensor item6 in list)
				{
					if (item6.Capabilities.HeadingInfo)
					{
						myContact.HeadingIsKnown = true;
					}
					if (item6.Capabilities.SpeedInfo)
					{
						myContact.SpeedIsKnown = true;
					}
					if (item6.Capabilities.AltitudeInfo || (item6.IsSonar && item6.IsActive()))
					{
						myContact.AltitudeIsKnown = true;
					}
				}
			}
			if (primaryTarget != null && (primaryTarget.ActualUnit == null || ActiveUnit_Sensory.ContactsAreOfSameActualUnit(primaryTarget, myContact)) && theSensorUnit.Navigator.HasPlottedCourse())
			{
				theSensorUnit.Navigator.ClearPlottedCourse();
			}
			if (weapon.ValidTargets.Radar)
			{
				if (!weapon.ARM_SpecifiedEmissionIsMandatory)
				{
					theSensorUnit.AI.TargetThisContact(myContact, AddedManually: false, PriorityTarget: false, ActiveUnit_AI.TargetingEntry._TargetingBehavior.AutoTargeted);
					TObservableDictionary<int, EmissionContainer> detectedEmissions2 = contact.DetectedEmissions;
					Side theSide2 = ((ActiveUnit)weapon).get_UnitSide(SetSideOnly: false);
					Random theRNG = GameGeneral.GlobalRNG;
					if (weapon.ARM_DetermineEmissionToTrack(detectedEmissions2, theSide2, contact, ShootAtTurnedOffRadar: false, ref theRNG))
					{
						weapon.ARM_SpecifiedEmissionIsMandatory = true;
					}
					return;
				}
				bool flag3 = false;
				foreach (int key in myContact.DetectedEmissions.Keys)
				{
					if (key == weapon.ARM_SpecifiedEMission.Key)
					{
						flag3 = true;
						if (!Information.IsNothing((object)primaryTarget) && myContact == primaryTarget)
						{
							weapon.ARM_SpecifiedEMission.Value.Age = 0f;
							weapon.ARM_SpecifiedEMission.Value.IsIllumination = myContact.DetectedEmissions[key].IsIllumination;
						}
					}
				}
				if (flag3)
				{
					theSensorUnit.AI.TargetThisContact(myContact, AddedManually: false, PriorityTarget: false, ActiveUnit_AI.TargetingEntry._TargetingBehavior.AutoTargeted);
				}
			}
			else if (myUnit.AI.IsTargetingThisContact(myContact))
			{
				if (myUnit.AI.PrimaryTarget == myContact)
				{
					myUnit.AI.TargetThisContact(myContact, AddedManually: false, PriorityTarget: false, ActiveUnit_AI.TargetingEntry._TargetingBehavior.AutoTargeted);
				}
			}
			else
			{
				Weapon obj = (Weapon)myUnit;
				ActiveUnit theAttackingUnit = myUnit;
				GlobalVariables.BooleanObject TargetIsDestroyed = null;
				if (obj.IsNominallySuitableForThisTarget(theAttackingUnit, ref myContact, ref TargetIsDestroyed))
				{
					myUnit.AI.TargetThisContact(myContact, AddedManually: false, PriorityTarget: false, ActiveUnit_AI.TargetingEntry._TargetingBehavior.AutoTargeted);
					string text = myUnit.Name + " detected new potential target " + activeUnit.Name;
					string text2 = text;
					if (list.Count == 1)
					{
						text2 = list[0].Name + " on " + text2;
					}
					else if (list.Count > 1)
					{
						text2 = "Multiple sensors on " + text2;
					}
					myUnit.Message = text2;
					myUnit.AddMessage(text2, text, LoggedMessage.MessageType.WeaponLogic, 1, new Geopoint_Struct(activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)myContact).get_Latitude((GlobalVariables.BooleanObject)null)));
				}
			}
			if (!myUnit.Sensory.Contacts_Local_ReadOnly.ContainsKey(activeUnit.ObjectID))
			{
				NewContactsQueue_Local.AddIfNotExistsElseUpdate(activeUnit.ObjectID, myContact);
				UpdateContactData_Local(ref activeUnit.ObjectID, list);
			}
			else
			{
				UpdateContactData_Local(ref activeUnit.ObjectID, list);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100989", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void HandleDetections_OnGrid()
	{
		bool flag = false;
		ActiveUnit activeUnit = null;
		if (myUnit.IsWeapon)
		{
			activeUnit = ((Weapon)myUnit).DataLinkParent;
			if (!Information.IsNothing((object)activeUnit) && !activeUnit.CommStuff.IsConnectedToSideNetwork)
			{
				flag = true;
			}
		}
		if (!flag)
		{
			base.HandleDetections_OnGrid();
			return;
		}
		if (!Information.IsNothing((object)SuccessfulDetectionsOnThisPulse) && SuccessfulDetectionsOnThisPulse.Count > 0)
		{
			if (Information.IsNothing((object)activeUnit.Sensory.SuccessfulDetectionsOnThisPulse))
			{
				activeUnit.Sensory.SuccessfulDetectionsOnThisPulse = new ConcurrentQueue<(Contact, ActiveUnit, List<Sensor>, float, SpecialDetectionMode, DateTime, List<Geopoint_Struct>)>();
			}
			foreach (var item in SuccessfulDetectionsOnThisPulse)
			{
				if (!Information.IsNothing((object)item))
				{
					activeUnit.Sensory.SuccessfulDetectionsOnThisPulse.Enqueue(item);
				}
			}
		}
		if (SuccessfulNonAUDetectionsOnThisPulse != null && SuccessfulNonAUDetectionsOnThisPulse.Count > 0)
		{
			if (activeUnit.Sensory.SuccessfulNonAUDetectionsOnThisPulse == null)
			{
				activeUnit.Sensory.SuccessfulNonAUDetectionsOnThisPulse = new ConcurrentQueue<string>();
			}
			foreach (string item2 in SuccessfulNonAUDetectionsOnThisPulse)
			{
				if (item2 != null)
				{
					activeUnit.Sensory.SuccessfulNonAUDetectionsOnThisPulse.Enqueue(item2);
				}
			}
		}
		if (BDAChangeNotices != null && BDAChangeNotices.Count > 0)
		{
			if (activeUnit.Sensory.BDAChangeNotices == null)
			{
				activeUnit.Sensory.BDAChangeNotices = new TDictionary<long, LoggedMessage>();
			}
			foreach (KeyValuePair<long, LoggedMessage> bDAChangeNotice in BDAChangeNotices)
			{
				activeUnit.Sensory.BDAChangeNotices.Add(bDAChangeNotice.Key, bDAChangeNotice.Value);
			}
			BDAChangeNotices.Clear();
		}
		activeUnit.Sensory.HandleDetections_OffGrid();
	}

	static Weapon_Sensory()
	{
		Class72.smethod_20();
	}
}
