using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using Command_Core.DAL;
using CSMaterial;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class BallisticMissile : Weapon
{
	private BallisticMissile_AI ballisticMissile_AI_0;

	private BallisticMissile_Kinematics ballisticMissile_Kinematics_0;

	public bool IsPerformingTerminalManeuvers;

	private float? nullable_22;

	public override bool SupportsAttitude_Pitch => true;

	public override Weapon_AI AI => ballisticMissile_AI_0;

	public override Weapon_Kinematics Kinematics => ballisticMissile_Kinematics_0;

	public override float Attitude_Pitch
	{
		get
		{
			return _Attitude_Pitch;
		}
		set
		{
			_Attitude_Pitch = value;
		}
	}

	public override float DesiredPitch
	{
		get
		{
			return _DesiredPitch;
		}
		set
		{
			_DesiredPitch = value;
		}
	}

	public override float CurrentSpeed
	{
		get
		{
			return base.CurrentSpeed;
		}
		set
		{
			base.CurrentSpeed = value;
		}
	}

	public override float CurrentAltitude
	{
		get
		{
			return base.get_CurrentAltitude(DoSanityCheck, GlobalVariables.ObjectTrue);
		}
		set
		{
			this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			base.set_CurrentAltitude(DoSanityCheck, (GlobalVariables.BooleanObject)null, value);
		}
	}

	public override bool IsBallisticMissile => true;

	public BallisticMissile(Scenario theScen)
		: base(theScen)
	{
		ballisticMissile_AI_0 = new BallisticMissile_AI(this);
		ActiveUnit theUnit = this;
		ballisticMissile_Kinematics_0 = new BallisticMissile_Kinematics(ref theUnit);
		IsPerformingTerminalManeuvers = false;
		IsWeapon = true;
		base.Type = _WeaponType.BallisticMissile;
		ParentScen = theScen;
	}

	public float TotalFlyoutHorizontalRange()
	{
		if (!nullable_22.HasValue)
		{
			if (AI.PrimaryTarget == null)
			{
				if (base.Navigator.HasPlottedCourse())
				{
					nullable_22 = LaunchPoint.RangeToPoint_Horiz(base.Navigator.PlottedCourse[0].Longitude, base.Navigator.PlottedCourse[1].Longitude);
				}
				else if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
			}
			else
			{
				nullable_22 = LaunchPoint.RangeToUnit_Horiz(AI.PrimaryTarget);
			}
		}
		return nullable_22.Value;
	}

	internal void DeployRVsIfApplicable(float elapsedTime)
	{
		try
		{
			if (method_16() && (!Module_Unit.IsWithinAtmosphere(this) || (TimeSinceLaunch > 0f && Attitude_Pitch < 0f && DesiredPitch <= 0f)))
			{
				int num = Warheads.Length - 1;
				for (int i = 0; i <= num; i++)
				{
					Weapon theChildWeapon = Warheads[i].get_CarriedWeapon(ParentScen);
					DeployChildWeapon(this, theChildWeapon, AI.PrimaryTarget, elapsedTime, SwitchTarget: true);
				}
				ParentScen.DestroyThisUnit(this, "All child weapons are away!", "Sub-munitions Expended");
			}
			else
			{
				if (!((BallisticMissile_Kinematics)Kinematics).HasReachedRVReleasePoint())
				{
					return;
				}
				List<Warhead> list = new List<Warhead>();
				bool flag = false;
				int? ASL_atFiringUnit = default(int?);
				if (IsMIRVedMissile.Value)
				{
					if (ParentScen.FifthSecondIsChangingOnThisPulse)
					{
						ReleaseMIRVs(list, elapsedTime, ref ASL_atFiringUnit);
					}
				}
				else if (IsMRVedMissile.Value)
				{
					int num2 = Warheads.Length - 1;
					Contact contact = default(Contact);
					for (int j = 0; j <= num2; j++)
					{
						Warhead warhead = Warheads[j];
						Weapon weapon = warhead.get_CarriedWeapon(ParentScen);
						if (AI.PrimaryTarget != null)
						{
							if (!AI.PrimaryTarget.get_IsDestroyed(ParentScen))
							{
								contact = (weapon.IsReEntryVehicle ? new AimpointContact(((Module_Unit.Unit)AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null)) : AI.PrimaryTarget);
							}
							else if (base.Navigator.HasPlottedCourse())
							{
								contact = ((weapon.Sensors_Cached.Count() <= 0) ? ((Contact)new AimpointContact(base.Navigator.PlottedCourse.Last().Latitude, base.Navigator.PlottedCourse.Last().Longitude)) : ((Contact)new ActivationPointContact(base.Navigator.PlottedCourse.Last().Latitude, base.Navigator.PlottedCourse.Last().Longitude)));
							}
						}
						else if (base.Navigator.HasPlottedCourse())
						{
							contact = ((weapon.Sensors_Cached.Count() <= 0) ? ((Contact)new AimpointContact(base.Navigator.PlottedCourse.Last().Latitude, base.Navigator.PlottedCourse.Last().Longitude)) : ((Contact)new ActivationPointContact(base.Navigator.PlottedCourse.Last().Latitude, base.Navigator.PlottedCourse.Last().Longitude)));
						}
						ActiveUnit_Weaponry weaponry = Weaponry;
						Contact theTarget = contact;
						Sensor SuitableDirectorSensor = null;
						if (weaponry.CanThisWeaponEngageThisTarget(weapon, theTarget, ref ASL_atFiringUnit, ManualFire: false, IgnoreAircraftOrientation: false, HumanFeedBackNeeded: false, null, ref SuitableDirectorSensor).EvaluationEnum == ActiveUnit_Weaponry.WeaponPrefireChecklistEvaluation.OK)
						{
							DeployChildWeapon(this, weapon, contact, elapsedTime, j == 0);
							list.Add(warhead);
						}
					}
				}
				else
				{
					Warhead warhead2 = Warheads[0];
					Weapon weapon2 = warhead2.get_CarriedWeapon(ParentScen);
					if (weapon2 != null)
					{
						if (!weapon2.IsReEntryVehicle)
						{
							DeployChildWeapon(this, weapon2, AI.PrimaryTarget, elapsedTime, SwitchTarget: true);
							list.Add(warhead2);
						}
						else
						{
							float maximumAltitude = weapon2.Kinematics.GetMaximumAltitude();
							if (maximumAltitude == 0f || !(maximumAltitude <= this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)))
							{
								Contact contact2;
								if (AI.PrimaryTarget == null)
								{
									if (base.Navigator.HasPlottedCourse())
									{
										contact2 = ((weapon2.Sensors_Cached.Count() <= 0) ? ((Contact)new AimpointContact(base.Navigator.PlottedCourse.Last().Latitude, base.Navigator.PlottedCourse.Last().Longitude)) : ((Contact)new ActivationPointContact(base.Navigator.PlottedCourse.Last().Latitude, base.Navigator.PlottedCourse.Last().Longitude)));
									}
									else
									{
										contact2 = GetTargetAimpoint();
										flag = weapon2.Sensors_Cached.Count() > 0;
									}
								}
								else if (!AI.PrimaryTarget.get_IsDestroyed(ParentScen))
								{
									contact2 = ((!weapon2.IsReEntryVehicle || weapon2.Sensors_Cached.Length != 0) ? AI.PrimaryTarget : new AimpointContact(((Module_Unit.Unit)AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null)));
								}
								else if (base.Navigator.HasPlottedCourse())
								{
									contact2 = ((weapon2.Sensors_Cached.Count() <= 0) ? ((Contact)new AimpointContact(base.Navigator.PlottedCourse.Last().Latitude, base.Navigator.PlottedCourse.Last().Longitude)) : ((Contact)new ActivationPointContact(base.Navigator.PlottedCourse.Last().Latitude, base.Navigator.PlottedCourse.Last().Longitude)));
								}
								else
								{
									contact2 = GetTargetAimpoint();
									flag = weapon2.Sensors_Cached.Count() > 0;
								}
								ActiveUnit_Weaponry weaponry2 = Weaponry;
								Contact theTarget2 = contact2;
								Sensor SuitableDirectorSensor = null;
								if (weaponry2.CanThisWeaponEngageThisTarget(weapon2, theTarget2, ref ASL_atFiringUnit, ManualFire: false, IgnoreAircraftOrientation: false, HumanFeedBackNeeded: false, null, ref SuitableDirectorSensor).EvaluationEnum == ActiveUnit_Weaponry.WeaponPrefireChecklistEvaluation.OK)
								{
									List<Module_Unit.Unit> list2 = DeployChildWeapon(this, weapon2, contact2, elapsedTime, SwitchTarget: true);
									if (flag)
									{
										foreach (Weapon item in list2)
										{
											item.GoAutonomous(clearPrimaryTarget: true, clearDatalink: true, clearPlottedCourse: true);
										}
									}
									list.Add(warhead2);
								}
							}
						}
					}
				}
				foreach (Warhead item2 in list)
				{
					ArrayExtensions.Remove(ref Warheads, item2);
				}
				if (Warheads.Length == 0)
				{
					ParentScen.DestroyThisUnit(this, "All payloads are away!", "Sub-munitions Expended");
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100923", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static BallisticMissile FromXML_Private(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen, bool LoadStockComponents_Force)
	{
		BallisticMissile result;
		try
		{
			BallisticMissile ballisticMissile = new BallisticMissile(theScen);
			ballisticMissile.ParentScen = theScen;
			string innerText = Misc.GetNodeByName(theNode.ChildNodes, "ID").InnerText;
			if (theDictionary.ContainsKey(innerText))
			{
				result = (BallisticMissile)theDictionary[innerText];
			}
			else
			{
				ballisticMissile.ObjectID_Set(innerText);
				if (theNode.ChildNodes.Count == 1)
				{
					theScen.UnitsForLateInstantiation.Add(theNode);
					result = ballisticMissile;
				}
				else
				{
					theDictionary.TryAdd(ballisticMissile.ObjectID, ballisticMissile);
					int num = Conversions.ToInteger(Misc.GetNodeByName(theNode.ChildNodes, "DBID").InnerText);
					DBFunctions.GetWeapon(theScen.DBConnection, ballisticMissile, num, theScen, LoadStockComponents_Force);
					if (LoadStockComponents_Force)
					{
						ballisticMissile.method_3(ref theNode, ref theDictionary, ref theScen);
					}
					if (!LoadStockComponents_Force)
					{
						Weapon.LoadSavedComponents(ballisticMissile, theScen, theNode, theDictionary);
					}
					Weapon.LoadMutableProperties(ballisticMissile, theScen, theNode, theDictionary);
					result = ballisticMissile;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100882", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new BallisticMissile(theScen);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override void DoFuelConsumption(float elapsedTime)
	{
	}

	internal Contact GetTargetAimpoint()
	{
		Contact contact = null;
		if (Kinematics.BallisticTrajectory == null)
		{
			if (AI.PrimaryTarget == null)
			{
				if (AI.LastKnownTargetLocation != null)
				{
					contact = new AimpointContact(AI.LastKnownTargetLocation.Latitude, AI.LastKnownTargetLocation.Longitude);
					((Module_Unit.Unit)contact).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, AI.LastKnownTargetLocation.Altitude);
				}
			}
			else
			{
				contact = AI.PrimaryTarget;
			}
		}
		else
		{
			contact = new AimpointContact(Kinematics.BallisticTrajectory.Target.lat * CSMath.Const_180_dividedBy_PI, Kinematics.BallisticTrajectory.Target.lon * CSMath.Const_180_dividedBy_PI);
			((Module_Unit.Unit)contact).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)((Kinematics.BallisticTrajectory.Target.radius_km - 6371.0) * 1000.0));
		}
		if (contact == null && Debugger.IsAttached)
		{
			Debugger.Break();
		}
		return contact;
	}

	static BallisticMissile()
	{
		Class72.smethod_20();
	}
}
