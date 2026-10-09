using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class ActiveUnit_Damage
{
	public delegate void DamageSustainedEventHandler(ActiveUnit myUnit);

	public enum ComponentHitType : byte
	{
		Mount,
		Sensor,
		Flooding,
		Fire,
		Engineering,
		CIC,
		Rudder,
		FlightDeck,
		Hangar,
		Cargo,
		PressureHull,
		Sonar,
		Magazine
	}

	public enum FireIntensityLevel : byte
	{
		NoFire,
		Minor,
		Major,
		Severe,
		Conflagration
	}

	public enum FloodingIntensityLevel : byte
	{
		NoFlooding,
		Minor,
		Major,
		Severe,
		Capsizing
	}

	protected ActiveUnit myUnit;

	[CompilerGenerated]
	private static DamageSustainedEventHandler damageSustainedEventHandler_0;

	protected FireIntensityLevel _FireIntensity;

	protected FloodingIntensityLevel _FloodIntensity;

	protected float _TimeToNextSecondaryDamageControl;

	public Weapon LastWeaponHit;

	protected double ExpectedAverageDamagePerComponentAtDestruction;

	public virtual FloodingIntensityLevel FloodIntensity
	{
		get
		{
			return _FloodIntensity;
		}
		set
		{
			try
			{
				if (value != _FloodIntensity)
				{
					_FloodIntensity = value;
					myUnit.Kinematics.ExportLocationEvent("FloodIntensityChanged");
					switch (_FloodIntensity)
					{
					case FloodingIntensityLevel.NoFlooding:
						myUnit.AddMessage(myUnit.Name + " has sealed all leaks.", myUnit.Name + " - All leaks sealed", LoggedMessage.MessageType.UnitDamage, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
						break;
					case FloodingIntensityLevel.Minor:
						myUnit.AddMessage(myUnit.Name + " has minor flooding.", myUnit.Name + " - Minor flooding", LoggedMessage.MessageType.UnitDamage, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
						break;
					case FloodingIntensityLevel.Major:
						myUnit.AddMessage(myUnit.Name + " has major flooding.", myUnit.Name + " - Major flooding", LoggedMessage.MessageType.UnitDamage, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
						break;
					case FloodingIntensityLevel.Severe:
						myUnit.AddMessage(myUnit.Name + " has severe flooding.", myUnit.Name + " - Severe flooding", LoggedMessage.MessageType.UnitDamage, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
						break;
					case FloodingIntensityLevel.Capsizing:
						myUnit.AddMessage("WARNING: " + myUnit.Name + " is in danger of capsizing!", myUnit.Name + " may capsize!", LoggedMessage.MessageType.UnitDamage, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
						break;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100111", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public virtual FireIntensityLevel FireIntensity
	{
		get
		{
			return _FireIntensity;
		}
		set
		{
			try
			{
				if (value != _FireIntensity)
				{
					_FireIntensity = value;
					myUnit.Kinematics.ExportLocationEvent("FireIntensityChanged");
					switch (_FireIntensity)
					{
					case FireIntensityLevel.NoFire:
						myUnit.AddMessage(myUnit.Name + " has extinguished all fires.", "Damage report", LoggedMessage.MessageType.UnitDamage, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
						break;
					case FireIntensityLevel.Minor:
						myUnit.AddMessage(myUnit.Name + " has a minor fire.", "Damage report", LoggedMessage.MessageType.UnitDamage, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
						break;
					case FireIntensityLevel.Major:
						myUnit.AddMessage(myUnit.Name + " has a major fire.", "Damage report", LoggedMessage.MessageType.UnitDamage, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
						break;
					case FireIntensityLevel.Severe:
						myUnit.AddMessage(myUnit.Name + " has a severe fire.", "Damage report", LoggedMessage.MessageType.UnitDamage, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
						break;
					case FireIntensityLevel.Conflagration:
						myUnit.AddMessage("WARNING: " + myUnit.Name + " is risking uncontrollable fires!", "Damage report", LoggedMessage.MessageType.UnitDamage, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
						break;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100112", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public float DamagePercent
	{
		get
		{
			float result;
			try
			{
				float num = 0f;
				if (myUnit.UnitType == GlobalVariables.ActiveUnitType.AggregateGroundUnit)
				{
					int num2 = 0;
					int num3 = 0;
					foreach (KeyValuePair<string, (ActiveUnit, int)> item in ((AggregateGroundUnit)myUnit).GetActualRoster_Readonly())
					{
						num2 += item.Value.Item2;
					}
					if (num2 != 0)
					{
						foreach (KeyValuePair<string, int> item2 in ((AggregateGroundUnit)myUnit).GetAssignedRoster_Readonly())
						{
							num3 += item2.Value;
						}
						result = ((num3 == 0) ? 0f : ((float)(1.0 - (double)num2 / (double)num3) * 100f));
					}
					else
					{
						result = 100f;
					}
				}
				else if (myUnit.IsFacility)
				{
					if (((Facility)myUnit).HasAimpoints)
					{
						int num4 = default(int);
						foreach (Mount mount in myUnit.Mounts)
						{
							if (mount.Status != PlatformComponent._ComponentStatus.Destroyed)
							{
								num4++;
							}
						}
						if (num4 != 0)
						{
							num = Math.Max(0f, Math.Min(100f, (float)(100.0 - (double)num4 / (double)myUnit.Mounts.Count * 100.0)));
							goto IL_0282;
						}
						result = 100f;
					}
					else
					{
						if (myUnit.get_DamagePts(ScenEditAction: false, (Weapon)null) != (float)myUnit.InitialDP)
						{
							num = Math.Max(0f, Math.Min(100f, (float)Math.Round(100f - myUnit.get_DamagePts(ScenEditAction: false, (Weapon)null) / (float)myUnit.InitialDP * 100f, 1)));
							goto IL_0282;
						}
						result = 0f;
					}
				}
				else
				{
					if (myUnit.get_DamagePts(ScenEditAction: false, (Weapon)null) != (float)myUnit.InitialDP)
					{
						num = Math.Max(0f, Math.Min(100f, (float)Math.Round(100f - myUnit.get_DamagePts(ScenEditAction: false, (Weapon)null) / (float)myUnit.InitialDP * 100f, 1)));
						goto IL_0282;
					}
					result = 0f;
				}
				goto end_IL_0001;
				IL_0282:
				result = num;
				end_IL_0001:;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100113", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = myUnit.get_DamagePts(ScenEditAction: false, (Weapon)null);
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public static event DamageSustainedEventHandler DamageSustained
	{
		[CompilerGenerated]
		add
		{
			DamageSustainedEventHandler damageSustainedEventHandler = damageSustainedEventHandler_0;
			DamageSustainedEventHandler damageSustainedEventHandler2;
			do
			{
				damageSustainedEventHandler2 = damageSustainedEventHandler;
				DamageSustainedEventHandler value2 = (DamageSustainedEventHandler)Delegate.Combine(damageSustainedEventHandler2, value);
				damageSustainedEventHandler = Interlocked.CompareExchange(ref damageSustainedEventHandler_0, value2, damageSustainedEventHandler2);
			}
			while ((object)damageSustainedEventHandler != damageSustainedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			DamageSustainedEventHandler damageSustainedEventHandler = damageSustainedEventHandler_0;
			DamageSustainedEventHandler damageSustainedEventHandler2;
			do
			{
				damageSustainedEventHandler2 = damageSustainedEventHandler;
				DamageSustainedEventHandler value2 = (DamageSustainedEventHandler)Delegate.Remove(damageSustainedEventHandler2, value);
				damageSustainedEventHandler = Interlocked.CompareExchange(ref damageSustainedEventHandler_0, value2, damageSustainedEventHandler2);
			}
			while ((object)damageSustainedEventHandler != damageSustainedEventHandler2);
		}
	}

	public virtual void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
		try
		{
			theWriter.WriteStartElement("ActiveUnit_Damage");
			if ((int)FireIntensity > 0)
			{
				XmlWriter obj = theWriter;
				byte fireIntensity = (byte)_FireIntensity;
				obj.WriteElementString("Fire", fireIntensity.ToString());
			}
			if ((int)FloodIntensity > 0)
			{
				XmlWriter obj2 = theWriter;
				byte fireIntensity = (byte)_FloodIntensity;
				obj2.WriteElementString("Flood", fireIntensity.ToString());
			}
			theWriter.WriteElementString("TTNSDC", XmlConvert.ToString(_TimeToNextSecondaryDamageControl));
			if (LastWeaponHit != null)
			{
				theWriter.WriteStartElement("LastWeaponHit");
				LastWeaponHit.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
				theWriter.WriteEndElement();
			}
			if (SBR.InProgress)
			{
				theWriter.WriteElementString("InitialDP2", XmlConvert.ToString(myUnit.InitialDP));
			}
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100109", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static ActiveUnit_Damage FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		ActiveUnit_Damage result;
		try
		{
			ActiveUnit_Damage activeUnit_Damage = new ActiveUnit_Damage();
			activeUnit_Damage.myUnit = theAU;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "Flood":
					activeUnit_Damage._FloodIntensity = (FloodingIntensityLevel)Conversions.ToByte(val.InnerText);
					break;
				case "TTNSDC":
					activeUnit_Damage._TimeToNextSecondaryDamageControl = Math.Abs(XmlConvert.ToSingle(val.InnerText.Replace(",", ".")));
					break;
				case "InitialDP2":
				{
					int num = Conversions.ToInteger(val.InnerText);
					if (activeUnit_Damage.myUnit.InitialDP != num)
					{
						int initialDP = activeUnit_Damage.myUnit.InitialDP;
						activeUnit_Damage.myUnit.InitialDP = num;
						float damagePercent = activeUnit_Damage.myUnit.Damage.DamagePercent;
						activeUnit_Damage.myUnit.InitialDP = initialDP;
						activeUnit_Damage.myUnit.set_DamagePts(ScenEditAction: false, (Weapon)null, (float)initialDP - (float)initialDP * damagePercent / 100f);
					}
					break;
				}
				case "LastWeaponHit":
				{
					string innerText = Misc.GetNodeByName(val.ChildNodes[0].ChildNodes, "ID").InnerText;
					if (theDictionary.ContainsKey(innerText))
					{
						activeUnit_Damage.LastWeaponHit = (Weapon)theDictionary[innerText];
						break;
					}
					XmlNode theNode2 = val.ChildNodes[0];
					activeUnit_Damage.LastWeaponHit = Weapon.FromXML(ref theNode2, ref theDictionary, ref theAU.ParentScen);
					break;
				}
				case "Fire":
					activeUnit_Damage._FireIntensity = (FireIntensityLevel)Conversions.ToByte(val.InnerText);
					break;
				}
			}
			result = activeUnit_Damage;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100110", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new ActiveUnit_Damage();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private ActiveUnit_Damage()
	{
		LastWeaponHit = null;
		ExpectedAverageDamagePerComponentAtDestruction = 1.5;
	}

	public ActiveUnit_Damage(ref ActiveUnit theUnit)
	{
		LastWeaponHit = null;
		ExpectedAverageDamagePerComponentAtDestruction = 1.5;
		myUnit = theUnit;
	}

	public virtual void ResolveDamageFromFrag(float DamageYield, float theCutOffRange_Frag, Warhead.WarheadType theWarheadType, int ARM_TargetedRadar = 0)
	{
		if (myUnit.RemoteSimEntityType != Module_Unit.Unit.RemoteSimEntityTypeEnum.Local)
		{
			return;
		}
		float targetDP_BeforeDamage = myUnit.get_DamagePts(ScenEditAction: false, (Weapon)null);
		try
		{
			if (DamageYield > 0f)
			{
				new WeaponImpact(ref myUnit.ParentScen, myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), WeaponImpact.ImpactType.Kinetic, 0);
				if ((int)Math.Round(DamageYield) == 0)
				{
					myUnit.AddMessage(myUnit.Name + " has suffered minor fragmentation damage", myUnit.Name + " damaged", LoggedMessage.MessageType.UnitDamage, 1, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				else
				{
					myUnit.AddMessage(myUnit.Name + " has suffered fragmentation damage: " + Conversions.ToString(Math.Round(DamageYield, 1)) + " DPs", myUnit.Name + " damaged", LoggedMessage.MessageType.UnitDamage, 1, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				myUnit.set_DamagePts(ScenEditAction: false, (Weapon)null, myUnit.get_DamagePts(ScenEditAction: false, (Weapon)null) - DamageYield);
				ResolveComponentHits(Warhead.WarheadType.Fragmentation, Warhead.WarheadExplosivesType.Fragmentation, DamageYield, targetDP_BeforeDamage, 0f, IsAreaEffect: true, ARM_TargetedRadar);
				ResolveProximityDamageToHostedUnits(IsAreaEffect: true);
				RaiseEvent_DamageSustained();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100114", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public float CalculateLaserImpactDamage_DP(Weapon theLaserWeapon, GeoPoint theLaunchPoint)
	{
		float result;
		try
		{
			float num = LaserWeapon.CalculateLaserPowerAtImpact_NoArbsorption(theLaserWeapon, theLaunchPoint, myUnit);
			if (num <= 0f)
			{
				result = 0f;
			}
			else
			{
				float num2 = LaserWeapon.ApplyLaserAtmosphericAbsorption(num, theLaserWeapon, theLaunchPoint, myUnit);
				if (num2 <= 0f)
				{
					result = 0f;
				}
				else
				{
					double item = LaserWeapon.CalculateLaserDamage(num2, 2.0, theLaserWeapon.Warheads[0].Type, GlobalVariables.ArmorRating.Undefined).DamagePoints;
					LastWeaponHit = theLaserWeapon;
					result = (float)item;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 10011205314", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = 0f;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public virtual void ResolveDamageFromBlast(float BlastYield, Warhead.WarheadType theWarheadType, Warhead.WarheadExplosivesType theWarheadExplosivesType, Weapon.DetonationMedium theMedium)
	{
		if (myUnit.RemoteSimEntityType != Module_Unit.Unit.RemoteSimEntityTypeEnum.Local)
		{
			return;
		}
		float targetDP_BeforeDamage = myUnit.get_DamagePts(ScenEditAction: false, (Weapon)null);
		try
		{
			if (myUnit.IsShip && ((Ship)myUnit).IsPurposeDesignedMCMPlatform() && theMedium == Weapon.DetonationMedium.Underwater)
			{
				BlastYield = (float)((double)BlastYield * 0.1);
			}
			AdjustBlastDamageForArmor(ref BlastYield);
			if (!(Math.Round(BlastYield, 1) > 0.0))
			{
				return;
			}
			new WeaponImpact(ref myUnit.ParentScen, myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), WeaponImpact.ImpactType.Kinetic, 0);
			bool flag = myUnit.AirFacilities_ReadOnly.Length > 0 && myUnit.AirFacilities_ReadOnly.Length == myUnit.AirFacilities_ReadOnly.Where([SpecialName] (AirFacility AF) => AF.IsOpenAirFacility).Count();
			if (myUnit.IsFixedFacility && flag)
			{
				BlastYield -= 10000f;
				if (BlastYield <= 0f)
				{
					return;
				}
				BlastYield *= 0.01f;
			}
			if (!myUnit.IsWeapon)
			{
				switch (theMedium)
				{
				case Weapon.DetonationMedium.Underground:
					myUnit.AddMessage(Misc.RemoveHiddenString(myUnit.Name) + " has suffered underground shock damage: " + Conversions.ToString(Math.Round(BlastYield, 1)) + " DPs", myUnit.Name + " damaged", LoggedMessage.MessageType.UnitDamage, 1, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
					break;
				default:
					myUnit.AddMessage(Misc.RemoveHiddenString(myUnit.Name) + " has suffered blast damage: " + Conversions.ToString(Math.Round(BlastYield, 1)) + " DPs", myUnit.Name + " damaged", LoggedMessage.MessageType.UnitDamage, 1, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
					break;
				case Weapon.DetonationMedium.Underwater:
					myUnit.AddMessage(Misc.RemoveHiddenString(myUnit.Name) + " has suffered underwater blast damage: " + Conversions.ToString(Math.Round(BlastYield, 1)) + " DPs", myUnit.Name + " damaged", LoggedMessage.MessageType.UnitDamage, 1, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
					break;
				}
			}
			myUnit.set_DamagePts(ScenEditAction: false, (Weapon)null, myUnit.get_DamagePts(ScenEditAction: false, (Weapon)null) - BlastYield);
			ResolveComponentHits(theWarheadType, theWarheadExplosivesType, BlastYield, targetDP_BeforeDamage, 0f, IsAreaEffect: true);
			ResolveProximityDamageToHostedUnits(IsAreaEffect: true);
			RaiseEvent_DamageSustained();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100115", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ResolveDamageFromBomblets(float BombletYield, Warhead.WarheadType theWarheadType, Warhead.WarheadExplosivesType theWarheadExplosivesType, float ClusterCoverageLength)
	{
		if (BombletYield == 0f || myUnit.RemoteSimEntityType != Module_Unit.Unit.RemoteSimEntityTypeEnum.Local)
		{
			return;
		}
		try
		{
			float targetDP_BeforeDamage = myUnit.get_DamagePts(ScenEditAction: false, (Weapon)null);
			AdjustBombletDamageForArmor(ref BombletYield, theWarheadType);
			if (Math.Round(BombletYield, 2) > 0.0)
			{
				new WeaponImpact(ref myUnit.ParentScen, myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), WeaponImpact.ImpactType.Kinetic, 0);
				myUnit.AddMessage(Misc.RemoveHiddenString(myUnit.Name) + " has suffered bomblet damage: " + Conversions.ToString(Math.Round(BombletYield, 1)) + " DPs", myUnit.Name + " damaged", LoggedMessage.MessageType.UnitDamage, 1, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				myUnit.set_DamagePts(ScenEditAction: false, (Weapon)null, myUnit.get_DamagePts(ScenEditAction: false, (Weapon)null) - BombletYield);
				ResolveComponentHits(theWarheadType, theWarheadExplosivesType, BombletYield, targetDP_BeforeDamage, 0f, IsAreaEffect: true);
				ResolveProximityDamageToHostedUnits(IsAreaEffect: true);
				RaiseEvent_DamageSustained();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100116", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual void AdjustBombletDamageForArmor(ref float BombletDamage, Warhead.WarheadType WarheadType)
	{
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		throw new NotImplementedException();
	}

	public virtual void AdjustBlastDamageForArmor(ref float BlastDamage)
	{
	}

	protected virtual void ResolveDamageFromDirectImpact(Weapon theWeapon, GeoPoint LaunchPoint, float DistanceFromImpact_meters, float BearingFromImpact, ref ActiveUnit ExcludedUnit, double? Expl_Latitude, double? Expl_Longitude, float? Expl_Altitude, UnguidedWeapon theUnguidedWeapon)
	{
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		throw new NotImplementedException();
	}

	public virtual void ResolveDamageFromWeapon(Weapon theWeapon, GeoPoint LaunchPoint, float DistanceFromImpact_meters, float BearingFromImpact, ActiveUnit ExcludedUnit, double? Expl_Latitude, double? Expl_Longitude, float? Expl_Altitude, ref string PreferredAimpoint, bool DirectHit, UnguidedWeapon theUnguidedWeapon)
	{
		if (Module_Unit.IsRemoteSimEntity(myUnit))
		{
			return;
		}
		try
		{
			if (theWeapon.Type == Weapon._WeaponType.Microwave)
			{
				float pulseStrengthRatio = (float)Math.Pow(1f - Module_Unit.RangeToUnit_Slant(myUnit, theWeapon.FiringParent) / theWeapon.MaxRange_NoTargetType, 2.0);
				method_5(pulseStrengthRatio);
			}
			else
			{
				if (theWeapon.Warheads.Length == 0)
				{
					return;
				}
				if (DirectHit)
				{
					if (myUnit.RemoteSimEntityType != Module_Unit.Unit.RemoteSimEntityTypeEnum.Local)
					{
						return;
					}
					ResolveDamageFromDirectImpact(theWeapon, LaunchPoint, DistanceFromImpact_meters, BearingFromImpact, ref ExcludedUnit, Expl_Latitude, Expl_Longitude, Expl_Altitude, theUnguidedWeapon);
				}
				else
				{
					float targetDP_BeforeDamage = myUnit.get_DamagePts(ScenEditAction: false, (Weapon)null);
					if (theWeapon.ValidTargets.Radar && !Information.IsNothing((object)theWeapon.ARM_SpecifiedEMission))
					{
						IEnumerable<Sensor> source = myUnit.Sensors_Cached.Where([SpecialName] (Sensor theS) => theS.IsActive() && (theS.DBID == theWeapon.ARM_SpecifiedEMission.Key || theS.MasqueradeAs == theWeapon.ARM_SpecifiedEMission.Key));
						if (source.Count() > 0)
						{
							int index = GameGeneral.GlobalRNG.Next(0, source.Count());
							DetermineComponentDamage(theWeapon.Warheads[0].Type, theWeapon.Warheads[0].ExplosivesType, source.ElementAtOrDefault(index), theWeapon.Warheads[0].DP, targetDP_BeforeDamage, theWeapon.ARM_SpecifiedEMission.Key, 0f);
						}
					}
					ResolveDamageFromWeapon_CreateExplosion(theWeapon, DistanceFromImpact_meters, BearingFromImpact, ExcludedUnit, Expl_Latitude, Expl_Longitude, Expl_Altitude, theUnguidedWeapon);
				}
				LastWeaponHit = theWeapon;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100117", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ResolveDamageFromWeapon_CreateExplosion(Weapon theWeapon, float DistanceFromImpact_meters, float BearingFromImpact, ActiveUnit ExcludedUnit, double? Expl_Latitude, double? Expl_Longitude, float? Expl_Altitude, UnguidedWeapon theUnguidedWeapon)
	{
		if (Debugger.IsAttached)
		{
			_ = Expl_Latitude.HasValue;
			_ = Expl_Longitude.HasValue;
		}
		Warhead warhead = theWeapon.Warheads[0];
		if (warhead.IsExplosive || warhead.IsIncendiary)
		{
			if (Information.IsNothing((object)Expl_Altitude))
			{
				Expl_Altitude = ((!theWeapon.Navigator.HasPlottedCourse() || !(theWeapon.Navigator.PlottedCourse[0].Altitude > 4000f)) ? new float?((int)Math.Round(theWeapon.ImpactAltitude)) : new float?((int)Math.Round(theWeapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))));
			}
			if (Information.IsNothing((object)Expl_Latitude) || Information.IsNothing((object)Expl_Longitude))
			{
				float num = Expl_Altitude.Value - (float)((Module_Unit.Unit)myUnit).get_LandElevation(AGL: true, RequestIsFromGUI: false, Force: false, myUnit.ParentScen);
				double out_lon = default(double);
				double out_lat = default(double);
				Geodesic_EdWilliams.CalcPoint_Williams(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, DistanceFromImpact_meters / 1852f, BearingFromImpact);
				Expl_Latitude = out_lat;
				Expl_Longitude = out_lon;
				Expl_Altitude = num + (float)Math.Max(0, (int)Terrain.GetElevation(Expl_Latitude.Value, Expl_Longitude.Value, RequestIsFromGUI: false, myUnit.ParentScen));
			}
			Module_Unit.Unit explodingUnit = ((theUnguidedWeapon != null) ? ((Module_Unit.Unit)theUnguidedWeapon) : ((Module_Unit.Unit)theWeapon));
			ref Scenario parentScen = ref myUnit.ParentScen;
			Weapon_AI aI;
			Contact thePrimaryTarget = (aI = theWeapon.AI).PrimaryTarget;
			new Explosion(ref parentScen, explodingUnit, ref thePrimaryTarget, Expl_Longitude.Value, Expl_Latitude.Value, Expl_Longitude.Value, Expl_Latitude.Value, theWeapon.CurrentHeading, Expl_Altitude.Value, theWeapon.Type, warhead.DP, warhead.DP, warhead.Type, warhead.ExplosivesType, null, null, ExcludedUnit, null, null, 0, 0);
			aI.PrimaryTarget = thePrimaryTarget;
			myUnit.Damage.LastWeaponHit = theWeapon;
		}
	}

	public virtual void DetermineSecondaryDamage(float theDamage, Warhead.WarheadType theWarheadType, float ArmorPenetration)
	{
	}

	public bool AimpointHasCompatibleEmitter(Mount theAimpoint, KeyValuePair<int, EmissionContainer> ARM_SpecifiedEmission)
	{
		bool result;
		try
		{
			result = (from theE in theAimpoint.Sensors_ReadOnly
				select (theE) into theE
				where theE.DBID == ARM_SpecifiedEmission.Key || theE.MasqueradeAs == ARM_SpecifiedEmission.Key
				select theE).Count() > 0;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100118", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num = 0;
			}
			else
			{
				num = 0;
			}
			result = (byte)num != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void method_0()
	{
	}

	private bool method_1(IEnumerable<ActiveUnit.UnitComponentGroups.ComponentDamageStatus> ienumerable_0)
	{
		foreach (ActiveUnit.UnitComponentGroups.ComponentDamageStatus item in ienumerable_0)
		{
			if (item.Component.StepsToDestruction > item.AllocatedDamage)
			{
				return false;
			}
		}
		return true;
	}

	private double method_2(ref List<ActiveUnit.UnitComponentGroups.ComponentDamageStatus> list_0)
	{
		double num = 0.0;
		foreach (ActiveUnit.UnitComponentGroups.ComponentDamageStatus item in list_0)
		{
			if (item.Component.StepsToDestruction > item.AllocatedDamage)
			{
				num += (double)item.Durability;
				item.AllocatedDamage++;
			}
		}
		return num;
	}

	private double method_3(IEnumerable<ActiveUnit.UnitComponentGroups.ComponentDamageStatus> ienumerable_0)
	{
		double num = 0.0;
		foreach (ActiveUnit.UnitComponentGroups.ComponentDamageStatus item in ienumerable_0)
		{
			if (item.Component.StepsToDestruction > item.AllocatedDamage)
			{
				num += (double)item.Durability;
			}
		}
		return num;
	}

	private void method_4(ref List<ActiveUnit.UnitComponentGroups.ComponentDamageStatus> list_0, double double_0)
	{
		double num = method_3(list_0);
		double num2 = double_0 / num;
		foreach (ActiveUnit.UnitComponentGroups.ComponentDamageStatus item in list_0)
		{
			if (item.AllocatedDamage < item.Component.StepsToDestruction && GameGeneral.GlobalRNG.NextDouble() < num2)
			{
				item.AllocatedDamage++;
			}
		}
	}

	protected void ResolveComponentHits(Warhead.WarheadType theWarheadType, Warhead.WarheadExplosivesType theWarheadExplosivesType, double theDamage, float TargetDP_BeforeDamage, float thePenetration, bool IsAreaEffect, int ARM_TargetedRadar = 0)
	{
		try
		{
			int initialDP = myUnit.InitialDP;
			double num = Math.Round(theDamage / (double)initialDP * (1.0 + ((double)(2f * ((float)initialDP - TargetDP_BeforeDamage)) + theDamage) / (double)(2 * initialDP)), 4) * (ExpectedAverageDamagePerComponentAtDestruction / 1.5);
			ActiveUnit.UnitComponentGroups myComponentGroups = myUnit.GetMyComponentGroups();
			double num2 = num * myComponentGroups.GetTotalVolume * 2.0 * (GameGeneral.GlobalRNG.NextDouble() + 0.5);
			ActiveUnit.UnitComponentGroups.ComponentDamageStatus targetedComponent = myComponentGroups.GetTargetedComponent(thePenetration, ARM_TargetedRadar);
			if (targetedComponent == null)
			{
				return;
			}
			ActiveUnit.UnitComponentGroups.UnitComponentGroupEvalState unitComponentGroupEvalState = new ActiveUnit.UnitComponentGroups.UnitComponentGroupEvalState(targetedComponent);
			List<ActiveUnit.UnitComponentGroups.ComponentDamageStatus> list_ = new List<ActiveUnit.UnitComponentGroups.ComponentDamageStatus>();
			ActiveUnit.UnitComponentGroups.ComponentDamageStatus componentDamageStatus = unitComponentGroupEvalState.Current();
			list_.Add(componentDamageStatus);
			if (unitComponentGroupEvalState.HasNextInQueue())
			{
				unitComponentGroupEvalState.MoveToNextInQueue();
			}
			if (!IsAreaEffect)
			{
				componentDamageStatus.DirectlyImpacted = true;
				float durability = componentDamageStatus.Durability;
				while (componentDamageStatus.AllocatedDamage < componentDamageStatus.Component.StepsToDestruction)
				{
					if (!(num2 <= 0.0))
					{
						if ((double)durability > num2)
						{
							method_4(ref list_, num2);
							num2 = 0.0;
						}
						else
						{
							num2 -= method_2(ref list_);
						}
						continue;
					}
					goto IL_0124;
				}
			}
			int num3 = 0;
			goto IL_0128;
			IL_0128:
			int num4 = num3;
			int num5 = 1;
			while (!(num2 <= 0.0) && (!method_1(list_) || unitComponentGroupEvalState.HasNextInQueue() || unitComponentGroupEvalState.HasComponentsRemaining()))
			{
				while (unitComponentGroupEvalState.HasNextInQueue() || (num2 > 0.0 && !method_1(list_)))
				{
					if (num2 >= method_3(list_))
					{
						num2 -= method_2(ref list_);
						if (unitComponentGroupEvalState.HasNextInQueue())
						{
							if (num4 == 0)
							{
								num4 = 2 * num5 + 1;
								num5++;
							}
							while (num4 > 0 && (unitComponentGroupEvalState.HasNextInQueue() || !unitComponentGroupEvalState.CurrentStale()))
							{
								list_.Add(unitComponentGroupEvalState.Current());
								unitComponentGroupEvalState.MoveToNextInQueue();
								num4--;
							}
						}
						continue;
					}
					method_4(ref list_, num2);
					num2 = 0.0;
					break;
				}
				if (num2 > 0.0)
				{
					unitComponentGroupEvalState.TryAddNextGroups();
					if (unitComponentGroupEvalState.CurrentStale() && unitComponentGroupEvalState.HasNextInQueue())
					{
						unitComponentGroupEvalState.MoveToNextInQueue();
					}
				}
			}
			foreach (ActiveUnit.UnitComponentGroups.ComponentDamageStatus item in list_)
			{
				ApplyComponentDamage(item.Component, item.AllocatedDamage, item.DirectlyImpacted, thePenetration, item.ContainingGroup.AsStoredAircraft);
			}
			DetermineSecondaryDamage((float)theDamage, theWarheadType, thePenetration);
			return;
			IL_0124:
			num3 = 0;
			goto IL_0128;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100119", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				new StackTrace(ex2, fNeedFileInfo: true);
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	protected void ResolveProximityDamageToHostedUnits(bool IsAreaEffect)
	{
		if (!IsAreaEffect)
		{
			return;
		}
		AirFacility[] airFacilities_ReadOnly = myUnit.AirFacilities_ReadOnly;
		foreach (AirFacility airFacility in airFacilities_ReadOnly)
		{
			if (airFacility.IsOpenAirFacility)
			{
				double num = GameGeneral.GlobalRNG.NextDouble();
				PlatformComponent._DamageSeverityFactor damageSeverityFactor = ((num > 0.7) ? PlatformComponent._DamageSeverityFactor.Heavy : ((num > 0.3) ? PlatformComponent._DamageSeverityFactor.Medium : PlatformComponent._DamageSeverityFactor.Light));
				if (myUnit.IsFacility && (((Facility)myUnit).Category == Facility._FacilityCategory.Building_Reveted || ((Facility)myUnit).Category == Facility._FacilityCategory.Structure_Reveted) && damageSeverityFactor != PlatformComponent._DamageSeverityFactor.Light)
				{
					damageSeverityFactor--;
				}
				airFacility.HandleDamageToHostedAircraft(damageSeverityFactor, 0f);
			}
		}
	}

	protected void RaiseEvent_DamageSustained()
	{
		damageSustainedEventHandler_0?.Invoke(myUnit);
	}

	protected virtual void DetermineDamageResult(ComponentHitType theHitType)
	{
	}

	public void ApplyComponentDamage(PlatformComponent theComp, int theIncrements, bool DirectlyImpacted, float PenetrationFactor, bool AsStoredAircraft)
	{
		if (theIncrements <= 0)
		{
			return;
		}
		PlatformComponent._DamageSeverityFactor damageSeverityFactor = theComp.DamageSeverity;
		bool flag = false;
		bool flag2 = false;
		string text = "";
		string theString = (((object)theComp.GetType() != typeof(Cargo)) ? theComp.Name : ("[Cargo] " + ((Cargo)theComp).CargoObjectName));
		if (theComp.Status == PlatformComponent._ComponentStatus.Operational)
		{
			damageSeverityFactor = PlatformComponent._DamageSeverityFactor.Light;
			theIncrements--;
			flag2 = true;
		}
		while (theIncrements > 0 && !flag)
		{
			switch (damageSeverityFactor)
			{
			case PlatformComponent._DamageSeverityFactor.Light:
				damageSeverityFactor = PlatformComponent._DamageSeverityFactor.Medium;
				break;
			case PlatformComponent._DamageSeverityFactor.Medium:
				damageSeverityFactor = PlatformComponent._DamageSeverityFactor.Heavy;
				break;
			case PlatformComponent._DamageSeverityFactor.Heavy:
				flag = true;
				break;
			}
			theIncrements--;
		}
		if (theComp.StructureVulnerableToBlast || (DirectlyImpacted && !AsStoredAircraft))
		{
			if (!flag)
			{
				if (flag2)
				{
					switch (damageSeverityFactor)
					{
					case PlatformComponent._DamageSeverityFactor.Light:
						text = "lightly";
						break;
					case PlatformComponent._DamageSeverityFactor.Medium:
						text = "moderately";
						break;
					case PlatformComponent._DamageSeverityFactor.Heavy:
						text = "heavily";
						break;
					}
					if (!myUnit.IsWeapon)
					{
						myUnit.ParentScen?.AddMessage(Misc.RemoveHiddenString(myUnit.Name) + " damage report: " + Misc.RemoveHiddenString(theString) + " has been " + text + " damaged.", myUnit.Name + " has component damage", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
					}
				}
				else
				{
					switch (damageSeverityFactor)
					{
					case PlatformComponent._DamageSeverityFactor.Light:
						text = "light";
						break;
					case PlatformComponent._DamageSeverityFactor.Medium:
						text = "moderate";
						break;
					case PlatformComponent._DamageSeverityFactor.Heavy:
						text = "heavy";
						break;
					}
					if (!myUnit.IsWeapon)
					{
						myUnit.ParentScen?.AddMessage(Misc.RemoveHiddenString(myUnit.Name) + " damage report: " + Misc.RemoveHiddenString(theString) + " has suffered additional " + text + " damage.", myUnit.Name + " has component damage", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
					}
				}
				theComp.Damage(damageSeverityFactor);
			}
			else if (flag)
			{
				if (!theComp.DestroyableByNonNuclear)
				{
					if (!flag2)
					{
						if (!myUnit.IsWeapon)
						{
							myUnit.ParentScen?.AddMessage_ToUnit(Misc.RemoveHiddenString(myUnit.Name) + " damage report: " + Misc.RemoveHiddenString(theString) + " has suffered additional heavy damage.", myUnit.Name + " has component damage", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.get_UnitSide(SetSideOnly: false), myUnit, theForceMapRecentre: false, null, AddBark: true);
						}
					}
					else if (!myUnit.IsWeapon)
					{
						myUnit.ParentScen?.AddMessage_ToUnit(Misc.RemoveHiddenString(myUnit.Name) + " damage report: " + Misc.RemoveHiddenString(theString) + " has been heavily damaged.", myUnit.Name + " has component damage", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.get_UnitSide(SetSideOnly: false), myUnit, theForceMapRecentre: false, null, AddBark: true);
					}
					theComp.Damage(PlatformComponent._DamageSeverityFactor.Heavy);
				}
				else
				{
					if (flag2)
					{
						if (!myUnit.IsWeapon)
						{
							myUnit.ParentScen?.AddMessage_ToUnit(Misc.RemoveHiddenString(myUnit.Name) + " damage report: " + Misc.RemoveHiddenString(theString) + " has been destroyed!", myUnit.Name + " lost a component", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.get_UnitSide(SetSideOnly: false), myUnit, theForceMapRecentre: false, null, AddBark: true);
						}
					}
					else if (!myUnit.IsWeapon)
					{
						myUnit.ParentScen?.AddMessage_ToUnit(Misc.RemoveHiddenString(myUnit.Name) + " damage report: " + Misc.RemoveHiddenString(theString) + " has suffered additional damage!", myUnit.Name + " lost a component", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.get_UnitSide(SetSideOnly: false), myUnit, theForceMapRecentre: false, null, AddBark: true);
					}
					theComp.Destroy(myUnit.get_UnitSide(SetSideOnly: false), ScenEditAction: false, IsAimpointFacility: false);
				}
			}
		}
		if (theComp.IsAirFacility && (AsStoredAircraft || theComp.StructureVulnerableToBlast))
		{
			((AirFacility)theComp).HandleDamageToHostedAircraft(damageSeverityFactor, PenetrationFactor);
		}
	}

	public void DetermineComponentDamage(Warhead.WarheadType theWarheadType, Warhead.WarheadExplosivesType theWarheadExplosivesType, PlatformComponent theComp, double theDamage, float TargetDP_BeforeDamage, int ARM_TargetedRadar, float PenetrationFactor)
	{
		int num = GameGeneral.GlobalRNG.Next(1, 101);
		try
		{
			int num2;
			if (num < 10 && theComp.IsSensor && ARM_TargetedRadar == theComp.DBID)
			{
				num = 10;
				num2 = 1001;
			}
			else
			{
				num2 = 1001;
			}
			GlobalVariables.ArmorRating armorRating = (GlobalVariables.ArmorRating)num2;
			if (theComp.IsMount)
			{
				armorRating = ((Mount)theComp).ArmorRating;
			}
			if (theComp.IsMagazine)
			{
				armorRating = ((Magazine)theComp).Armor;
			}
			if (armorRating != GlobalVariables.ArmorRating.None || !theComp.IsAirFacility)
			{
				goto IL_00db;
			}
			switch (theComp.ParentPlatform.UnitType)
			{
			case GlobalVariables.ActiveUnitType.Aircraft:
				armorRating = ((Aircraft)theComp.ParentPlatform).Armor_Fuselage;
				goto IL_00db;
			case GlobalVariables.ActiveUnitType.Ship:
				armorRating = ((Ship)theComp.ParentPlatform).Armor_Deck;
				goto IL_00db;
			case GlobalVariables.ActiveUnitType.Submarine:
				break;
			case GlobalVariables.ActiveUnitType.Facility:
				armorRating = ((Facility)theComp.ParentPlatform).Armor_General;
				goto IL_00db;
			default:
				goto IL_00db;
			}
			armorRating = GlobalVariables.ArmorRating.Heavy;
			goto IL_01fa;
			IL_00db:
			switch (armorRating)
			{
			case GlobalVariables.ArmorRating.Light:
				break;
			case GlobalVariables.ArmorRating.Medium:
				goto IL_0154;
			case GlobalVariables.ArmorRating.Heavy:
				goto IL_01fa;
			case GlobalVariables.ArmorRating.Special:
				goto IL_02e8;
			default:
				goto IL_03dd;
			}
			switch (theWarheadExplosivesType)
			{
			default:
				num -= 10;
				break;
			case Warhead.WarheadExplosivesType.Fragmentation:
			case Warhead.WarheadExplosivesType.Submunitions_AntiPersonnel_Fragmentation:
			case Warhead.WarheadExplosivesType.AntiElectrical_ConductiveFiber:
			case Warhead.WarheadExplosivesType.LaserEnergy:
			case Warhead.WarheadExplosivesType.KineticEnergy:
				num -= 90;
				break;
			}
			goto IL_03dd;
			IL_01f3:
			int num3;
			num = num3;
			goto IL_03dd;
			IL_0585:
			int num4;
			PlatformComponent._DamageSeverityFactor theSeverity = (PlatformComponent._DamageSeverityFactor)num4;
			if (theComp.Status == PlatformComponent._ComponentStatus.Operational)
			{
				theComp.Damage(PlatformComponent._DamageSeverityFactor.Light);
			}
			goto IL_0b6a;
			IL_02e8:
			int num5;
			switch (theWarheadExplosivesType)
			{
			case Warhead.WarheadExplosivesType.Incendiary_Napalm:
			case Warhead.WarheadExplosivesType.Incendiary_WP:
			case Warhead.WarheadExplosivesType.HEAT_LightArmor:
			case Warhead.WarheadExplosivesType.Submunitions_AntiTank_LightArmor:
			case Warhead.WarheadExplosivesType.Mine_AntiTank_LightArmor:
			case Warhead.WarheadExplosivesType.LongRodPenetrator_LightArmor:
				num = 0;
				break;
			case Warhead.WarheadExplosivesType.Incendiary_FAE:
			case Warhead.WarheadExplosivesType.HEAT_MediumArmor:
			case Warhead.WarheadExplosivesType.Submunitions_AntiTank_MediumArmor:
			case Warhead.WarheadExplosivesType.Mine_AntiTank_MediumArmor:
			case Warhead.WarheadExplosivesType.LongRodPenetrator_MediumArmor:
				num = 0;
				break;
			case Warhead.WarheadExplosivesType.HEAT_HeavyArmor:
			case Warhead.WarheadExplosivesType.Submunitions_AntiTank_HeavyArmor:
			case Warhead.WarheadExplosivesType.Mine_AntiTank_HeavyArmor:
			case Warhead.WarheadExplosivesType.LongRodPenetrator_HeavyArmor:
				num -= 90;
				break;
			case Warhead.WarheadExplosivesType.KineticEnergy:
				num5 = 0;
				goto IL_03db;
			default:
				num -= 70;
				break;
			case Warhead.WarheadExplosivesType.Fragmentation:
			case Warhead.WarheadExplosivesType.Submunitions_AntiPersonnel_Fragmentation:
			case Warhead.WarheadExplosivesType.AntiElectrical_ConductiveFiber:
			case Warhead.WarheadExplosivesType.LaserEnergy:
				{
					num5 = 0;
					goto IL_03db;
				}
				IL_03db:
				num = num5;
				break;
			}
			goto IL_03dd;
			IL_03dd:
			string theString = (((object)theComp.GetType() != typeof(Cargo)) ? theComp.Name : ("[Cargo] " + ((Cargo)theComp).CargoObjectName));
			int num6 = num;
			int num9;
			if (num6 >= 10)
			{
				if (num6 < 30)
				{
					if (theComp.Status != PlatformComponent._ComponentStatus.Operational)
					{
						if (myUnit.IsWeapon)
						{
							goto IL_0584;
						}
						Scenario parentScen = myUnit.ParentScen;
						if (parentScen == null)
						{
							num4 = 0;
						}
						else
						{
							parentScen.AddMessage(Misc.RemoveHiddenString(myUnit.Name) + " damage report: " + Misc.RemoveHiddenString(theString) + " has suffered additional light damage.", myUnit.Name + " has component damage", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
							num4 = 0;
						}
					}
					else
					{
						if (myUnit.IsWeapon)
						{
							goto IL_0584;
						}
						Scenario parentScen2 = myUnit.ParentScen;
						if (parentScen2 == null)
						{
							num4 = 0;
						}
						else
						{
							parentScen2.AddMessage(Misc.RemoveHiddenString(myUnit.Name) + " damage report: " + Misc.RemoveHiddenString(theString) + " has been lightly damaged.", myUnit.Name + " has component damage", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
							num4 = 0;
						}
					}
					goto IL_0585;
				}
				if (num6 < 40)
				{
					int num7;
					if (theComp.Status == PlatformComponent._ComponentStatus.Operational)
					{
						if (myUnit.IsWeapon)
						{
							num7 = 1;
						}
						else
						{
							Scenario parentScen3 = myUnit.ParentScen;
							if (parentScen3 == null)
							{
								num7 = 1;
							}
							else
							{
								parentScen3.AddMessage(Misc.RemoveHiddenString(myUnit.Name) + " damage report: " + Misc.RemoveHiddenString(theString) + " has been moderately damaged.", myUnit.Name + " has component damage", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
								num7 = 1;
							}
						}
					}
					else if (!myUnit.IsWeapon)
					{
						Scenario parentScen4 = myUnit.ParentScen;
						if (parentScen4 == null)
						{
							num7 = 1;
						}
						else
						{
							parentScen4.AddMessage(Misc.RemoveHiddenString(myUnit.Name) + " damage report: " + Misc.RemoveHiddenString(theString) + " has suffered additional moderate damage.", myUnit.Name + " has component damage", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
							num7 = 1;
						}
					}
					else
					{
						num7 = 1;
					}
					theSeverity = (PlatformComponent._DamageSeverityFactor)num7;
					if (theComp.Status == PlatformComponent._ComponentStatus.Operational || (theComp.Status == PlatformComponent._ComponentStatus.Damaged && theComp.DamageSeverity < PlatformComponent._DamageSeverityFactor.Medium))
					{
						theComp.Damage(PlatformComponent._DamageSeverityFactor.Medium);
					}
				}
				else if (num6 < 70)
				{
					int num8;
					if (theComp.Status != PlatformComponent._ComponentStatus.Operational)
					{
						if (myUnit.IsWeapon)
						{
							num8 = 2;
						}
						else
						{
							Scenario parentScen5 = myUnit.ParentScen;
							if (parentScen5 == null)
							{
								num8 = 2;
							}
							else
							{
								parentScen5.AddMessage(Misc.RemoveHiddenString(myUnit.Name) + " damage report: " + Misc.RemoveHiddenString(theString) + " has suffered additional heavy damage.", myUnit.Name + " has component damage", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
								num8 = 2;
							}
						}
					}
					else if (myUnit.IsWeapon)
					{
						num8 = 2;
					}
					else
					{
						Scenario parentScen6 = myUnit.ParentScen;
						if (parentScen6 == null)
						{
							num8 = 2;
						}
						else
						{
							parentScen6.AddMessage(Misc.RemoveHiddenString(myUnit.Name) + " damage report: " + Misc.RemoveHiddenString(theString) + " has been heavily damaged.", myUnit.Name + " has component damage", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
							num8 = 2;
						}
					}
					theSeverity = (PlatformComponent._DamageSeverityFactor)num8;
					if (theComp.Status == PlatformComponent._ComponentStatus.Operational || (theComp.Status == PlatformComponent._ComponentStatus.Damaged && theComp.DamageSeverity < PlatformComponent._DamageSeverityFactor.Heavy))
					{
						theComp.Damage(PlatformComponent._DamageSeverityFactor.Heavy);
					}
				}
				else
				{
					if (theComp.IsAirFacility && ((AirFacility)theComp).IsOpenAirFacility)
					{
						if (theComp.Status == PlatformComponent._ComponentStatus.Operational)
						{
							if (myUnit.IsWeapon)
							{
								goto IL_0a18;
							}
							Scenario parentScen7 = myUnit.ParentScen;
							if (parentScen7 == null)
							{
								num9 = 2;
							}
							else
							{
								parentScen7.AddMessage_ToUnit(Misc.RemoveHiddenString(myUnit.Name) + " damage report: " + Misc.RemoveHiddenString(theString) + " has been heavily damaged.", myUnit.Name + " has component damage", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.get_UnitSide(SetSideOnly: false), myUnit, theForceMapRecentre: false, null, AddBark: true);
								num9 = 2;
							}
						}
						else
						{
							if (myUnit.IsWeapon)
							{
								goto IL_0a18;
							}
							Scenario parentScen8 = myUnit.ParentScen;
							if (parentScen8 == null)
							{
								num9 = 2;
							}
							else
							{
								parentScen8.AddMessage_ToUnit(Misc.RemoveHiddenString(myUnit.Name) + " damage report: " + Misc.RemoveHiddenString(theString) + " has suffered additional heavy damage.", myUnit.Name + " has component damage", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.get_UnitSide(SetSideOnly: false), myUnit, theForceMapRecentre: false, null, AddBark: true);
								num9 = 2;
							}
						}
						goto IL_0a19;
					}
					if (theComp.Status == PlatformComponent._ComponentStatus.Operational)
					{
						if (!myUnit.IsWeapon)
						{
							myUnit.ParentScen?.AddMessage_ToUnit(Misc.RemoveHiddenString(myUnit.Name) + " damage report: " + Misc.RemoveHiddenString(theString) + " has been destroyed!", myUnit.Name + " lost a component", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.get_UnitSide(SetSideOnly: false), myUnit, theForceMapRecentre: false, null, AddBark: true);
						}
					}
					else if (!myUnit.IsWeapon)
					{
						myUnit.ParentScen?.AddMessage_ToUnit(Misc.RemoveHiddenString(myUnit.Name) + " damage report: " + Misc.RemoveHiddenString(theString) + " has suffered additional damage!", myUnit.Name + " lost a component", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.get_UnitSide(SetSideOnly: false), myUnit, theForceMapRecentre: false, null, AddBark: true);
					}
					if (theComp.Status < PlatformComponent._ComponentStatus.Destroyed)
					{
						theComp.Destroy(myUnit.get_UnitSide(SetSideOnly: false), ScenEditAction: false, IsAimpointFacility: false);
					}
				}
			}
			goto IL_0b6a;
			IL_0154:
			Warhead.WarheadExplosivesType warheadExplosivesType = theWarheadExplosivesType;
			if (warheadExplosivesType <= Warhead.WarheadExplosivesType.Submunitions_AntiTank_LightArmor)
			{
				if (warheadExplosivesType <= Warhead.WarheadExplosivesType.HEAT_LightArmor)
				{
					if ((uint)(warheadExplosivesType - 2101) <= 1u || warheadExplosivesType == Warhead.WarheadExplosivesType.HEAT_LightArmor)
					{
						goto IL_01bc;
					}
				}
				else
				{
					if (warheadExplosivesType == Warhead.WarheadExplosivesType.Fragmentation || warheadExplosivesType == Warhead.WarheadExplosivesType.Submunitions_AntiPersonnel_Fragmentation)
					{
						goto IL_01f2;
					}
					if (warheadExplosivesType == Warhead.WarheadExplosivesType.Submunitions_AntiTank_LightArmor)
					{
						goto IL_01bc;
					}
				}
			}
			else if (warheadExplosivesType <= Warhead.WarheadExplosivesType.LongRodPenetrator_LightArmor)
			{
				if (warheadExplosivesType == Warhead.WarheadExplosivesType.Mine_AntiTank_LightArmor || warheadExplosivesType == Warhead.WarheadExplosivesType.LongRodPenetrator_LightArmor)
				{
					goto IL_01bc;
				}
			}
			else
			{
				if (warheadExplosivesType == Warhead.WarheadExplosivesType.AntiElectrical_ConductiveFiber || warheadExplosivesType == Warhead.WarheadExplosivesType.LaserEnergy)
				{
					goto IL_01f2;
				}
				if (warheadExplosivesType == Warhead.WarheadExplosivesType.KineticEnergy)
				{
					num3 = 0;
					goto IL_01f3;
				}
			}
			num -= 30;
			goto IL_03dd;
			IL_0584:
			num4 = 0;
			goto IL_0585;
			IL_01bc:
			num -= 90;
			goto IL_03dd;
			IL_01f2:
			num3 = 0;
			goto IL_01f3;
			IL_01fa:
			int num10;
			switch (theWarheadExplosivesType)
			{
			case Warhead.WarheadExplosivesType.Incendiary_Napalm:
			case Warhead.WarheadExplosivesType.Incendiary_WP:
			case Warhead.WarheadExplosivesType.HEAT_LightArmor:
			case Warhead.WarheadExplosivesType.Submunitions_AntiTank_LightArmor:
			case Warhead.WarheadExplosivesType.Mine_AntiTank_LightArmor:
			case Warhead.WarheadExplosivesType.LongRodPenetrator_LightArmor:
				num = 0;
				break;
			case Warhead.WarheadExplosivesType.Incendiary_FAE:
			case Warhead.WarheadExplosivesType.HEAT_MediumArmor:
			case Warhead.WarheadExplosivesType.Submunitions_AntiTank_MediumArmor:
			case Warhead.WarheadExplosivesType.Mine_AntiTank_MediumArmor:
			case Warhead.WarheadExplosivesType.LongRodPenetrator_MediumArmor:
				num -= 90;
				break;
			case Warhead.WarheadExplosivesType.KineticEnergy:
				num10 = 0;
				goto IL_02e1;
			default:
				num -= 50;
				break;
			case Warhead.WarheadExplosivesType.Fragmentation:
			case Warhead.WarheadExplosivesType.Submunitions_AntiPersonnel_Fragmentation:
			case Warhead.WarheadExplosivesType.AntiElectrical_ConductiveFiber:
			case Warhead.WarheadExplosivesType.LaserEnergy:
				{
					num10 = 0;
					goto IL_02e1;
				}
				IL_02e1:
				num = num10;
				break;
			}
			goto IL_03dd;
			IL_0b6a:
			if (theComp.Status != PlatformComponent._ComponentStatus.Destroyed && theComp.IsAirFacility)
			{
				((AirFacility)theComp).HandleDamageToHostedAircraft(theSeverity, PenetrationFactor);
			}
			return;
			IL_0a18:
			num9 = 2;
			goto IL_0a19;
			IL_0a19:
			theSeverity = (PlatformComponent._DamageSeverityFactor)num9;
			theComp.Damage(PlatformComponent._DamageSeverityFactor.Heavy);
			goto IL_0b6a;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100120", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual void DoSecondaryDamage(float elapsedTime)
	{
		try
		{
			float num = default(float);
			switch (FireIntensity)
			{
			case FireIntensityLevel.Minor:
				num = (float)((double)myUnit.InitialDP * 0.04 * (double)(elapsedTime / 3600f));
				break;
			case FireIntensityLevel.Major:
				num = (float)((double)myUnit.InitialDP * 0.08 * (double)(elapsedTime / 3600f));
				break;
			case FireIntensityLevel.Severe:
				num = (float)((double)myUnit.InitialDP * 0.12 * (double)(elapsedTime / 3600f));
				break;
			case FireIntensityLevel.Conflagration:
			{
				num = (float)((double)myUnit.InitialDP * 0.24 * (double)(elapsedTime / 3600f));
				bool flag = myUnit.AirFacilities_ReadOnly.Where([SpecialName] (AirFacility AF) => AF.IsOpenAirFacility).Any();
				if ((!myUnit.IsFacility || !flag) && GameGeneral.GlobalRNG.Next(1, 101) <= 5)
				{
					myUnit.AddMessage(myUnit.Name + " has fires raging out of control and is disintegrating!!!", myUnit.Name + " is burning up!!!", LoggedMessage.MessageType.UnitDamage, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
					if (!myUnit.IsShip)
					{
						myUnit.ParentScen.DestroyThisUnit(myUnit, "Fire damage", "Fire / Flooding");
					}
					else if (((Ship)myUnit).IsSinking)
					{
						myUnit.ParentScen.DestroyThisUnit(myUnit, "Onboard fires raging out of control.", "Fire / Flooding");
					}
					else
					{
						myUnit.set_DamagePts(ScenEditAction: false, (Weapon)null, Math.Min(myUnit.get_DamagePts(ScenEditAction: false, (Weapon)null), -1f));
					}
					return;
				}
				break;
			}
			}
			float num2 = default(float);
			switch (FloodIntensity)
			{
			case FloodingIntensityLevel.Minor:
				num2 = (float)((double)myUnit.InitialDP * 0.04 * (double)(elapsedTime / 3600f));
				break;
			case FloodingIntensityLevel.Major:
				num2 = (float)((double)myUnit.InitialDP * 0.08 * (double)(elapsedTime / 3600f));
				break;
			case FloodingIntensityLevel.Severe:
				num2 = (float)((double)myUnit.InitialDP * 0.12 * (double)(elapsedTime / 3600f));
				break;
			case FloodingIntensityLevel.Capsizing:
				num2 = (float)((double)myUnit.InitialDP * 0.24 * (double)(elapsedTime / 3600f));
				if (myUnit.IsShip && GameGeneral.GlobalRNG.Next(1, 101) <= 5)
				{
					myUnit.AddMessage(myUnit.Name + " is capsizing - abandoning ship!!!", myUnit.Name + " is capsizing!!!", LoggedMessage.MessageType.UnitDamage, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
					if (((Ship)myUnit).IsSinking)
					{
						myUnit.ParentScen.DestroyThisUnit(myUnit, "Ship capsizing", "Fire / Flooding");
					}
					else
					{
						myUnit.set_DamagePts(ScenEditAction: false, (Weapon)null, Math.Min(myUnit.get_DamagePts(ScenEditAction: false, (Weapon)null), -1f));
					}
					return;
				}
				break;
			}
			if (num + num2 > 0f)
			{
				myUnit.set_DamagePts(ScenEditAction: false, (Weapon)null, myUnit.get_DamagePts(ScenEditAction: false, (Weapon)null) - (num + num2));
			}
			_TimeToNextSecondaryDamageControl -= elapsedTime;
			if (_TimeToNextSecondaryDamageControl > 0f || num + num2 == 0f)
			{
				return;
			}
			if (FireIntensity != FireIntensityLevel.NoFire)
			{
				byte b = (byte)GameGeneral.GlobalRNG.Next(1, 11);
				GlobalVariables.ProficiencyLevel? proficiency = myUnit.Proficiency;
				int? num3 = (int?)proficiency;
				if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3.GetValueOrDefault() == 0)) != true)
				{
					num3 = (int?)proficiency;
					if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 1)) == true)
					{
						b += 2;
					}
					else
					{
						num3 = (int?)proficiency;
						if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 2)) == true)
						{
							b++;
						}
						else
						{
							num3 = (int?)proficiency;
							if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 3)) != true)
							{
								num3 = (int?)proficiency;
								if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 4)) == true)
								{
									b = (byte)Math.Max(0, b - 2);
								}
							}
						}
					}
				}
				else
				{
					b += 3;
				}
				int val;
				if (!myUnit.IsSubmarine)
				{
					val = 0;
				}
				else if (!((Submarine)myUnit).Flags.UsesLiOnBattery)
				{
					val = 0;
				}
				else
				{
					b += 2;
					val = 0;
				}
				b = (byte)Math.Max(val, b);
				if (b > 10)
				{
					b = 10;
				}
				else
				{
					switch (b)
					{
					case 1:
					case 2:
					case 3:
					case 4:
						FireIntensity = (FireIntensityLevel)Math.Max(0, (int)(FireIntensity - 1));
						goto IL_068a;
					case 9:
					case 10:
						break;
					default:
						goto IL_068a;
					}
				}
				if (FireIntensity != FireIntensityLevel.Conflagration)
				{
					FireIntensity++;
				}
			}
			goto IL_068a;
			IL_068a:
			int val2;
			byte b2;
			if (FloodIntensity != FloodingIntensityLevel.NoFlooding)
			{
				b2 = (byte)GameGeneral.GlobalRNG.Next(1, 11);
				GlobalVariables.ProficiencyLevel? proficiency2 = myUnit.Proficiency;
				int? num3 = (int?)proficiency2;
				if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3.GetValueOrDefault() == 0)) == true)
				{
					b2 += 3;
					val2 = 0;
				}
				else
				{
					num3 = (int?)proficiency2;
					if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 1)) == true)
					{
						b2 += 2;
						val2 = 0;
					}
					else
					{
						num3 = (int?)proficiency2;
						if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 2)) == true)
						{
							b2++;
							val2 = 0;
						}
						else
						{
							num3 = (int?)proficiency2;
							if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 3)) != true)
							{
								num3 = (int?)proficiency2;
								if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 4)) == true)
								{
									b2 = (byte)Math.Max(0, b2 - 2);
									val2 = 0;
									goto IL_0885;
								}
							}
							val2 = 0;
						}
					}
				}
				goto IL_0885;
			}
			goto IL_08fe;
			IL_08fe:
			_TimeToNextSecondaryDamageControl = GameGeneral.GlobalRNG.Next(900, 1801);
			return;
			IL_0885:
			b2 = (byte)Math.Max(val2, b2);
			if (b2 > 10)
			{
				b2 = 10;
			}
			else
			{
				switch (b2)
				{
				case 1:
				case 2:
				case 3:
				case 4:
					FloodIntensity = (FloodingIntensityLevel)Math.Max(0, (int)(FloodIntensity - 1));
					goto IL_08fe;
				case 9:
				case 10:
					break;
				default:
					goto IL_08fe;
				}
			}
			if (FloodIntensity != FloodingIntensityLevel.Capsizing)
			{
				FloodIntensity++;
			}
			goto IL_08fe;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200283", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	protected void CauseFlooding(FloodingIntensityLevel FloodSize)
	{
		try
		{
			if (FloodSize > FloodIntensity)
			{
				FloodIntensity = FloodSize;
			}
			else if (FloodSize == FloodIntensity && FloodIntensity != FloodingIntensityLevel.Capsizing)
			{
				double num = default(double);
				switch (FloodSize)
				{
				case FloodingIntensityLevel.Minor:
					num = 0.5;
					break;
				case FloodingIntensityLevel.Major:
					num = 0.25;
					break;
				case FloodingIntensityLevel.Severe:
					num = 0.1;
					break;
				}
				if (GameGeneral.GlobalRNG.NextDouble() < num)
				{
					FloodIntensity++;
				}
			}
			_TimeToNextSecondaryDamageControl = GameGeneral.GlobalRNG.Next(120, 181);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100122", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void CauseFire(FireIntensityLevel FireSize)
	{
		try
		{
			if (FireSize > FireIntensity)
			{
				FireIntensity = FireSize;
			}
			else if (FireSize == FireIntensity && FireIntensity != FireIntensityLevel.Conflagration)
			{
				double num = default(double);
				switch (FireSize)
				{
				case FireIntensityLevel.Minor:
					num = 0.5;
					break;
				case FireIntensityLevel.Major:
					num = 0.25;
					break;
				case FireIntensityLevel.Severe:
					num = 0.1;
					break;
				}
				if (GameGeneral.GlobalRNG.NextDouble() < num)
				{
					FireIntensity++;
				}
			}
			_TimeToNextSecondaryDamageControl = GameGeneral.GlobalRNG.Next(120, 181);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100123", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	protected virtual PlatformComponent DetermineComponentThatIsHit(ComponentHitType theType)
	{
		List<PlatformComponent> list = new List<PlatformComponent>();
		PlatformComponent result;
		try
		{
			switch (theType)
			{
			case ComponentHitType.Mount:
			{
				Magazine[] magazines2 = ((Platform)myUnit).Magazines;
				foreach (Magazine item2 in magazines2)
				{
					list.Add(item2);
				}
				DockFacility[] dockFacilities_ReadOnly = myUnit.DockFacilities_ReadOnly;
				foreach (DockFacility item3 in dockFacilities_ReadOnly)
				{
					list.Add(item3);
				}
				AirFacility[] airFacilities_ReadOnly3 = myUnit.AirFacilities_ReadOnly;
				foreach (AirFacility item4 in airFacilities_ReadOnly3)
				{
					list.Add(item4);
				}
				foreach (Mount mount in myUnit.Mounts)
				{
					list.Add(mount);
				}
				if (list.Count == 0)
				{
					result = null;
					break;
				}
				int index = GameGeneral.GlobalRNG.Next(0, list.Count);
				result = list[index];
				break;
			}
			case ComponentHitType.Sensor:
			{
				Sensor[] sensors_Cached2 = myUnit.Sensors_Cached;
				foreach (Sensor item5 in sensors_Cached2)
				{
					list.Add(item5);
				}
				if (list.Count == 0)
				{
					result = null;
					break;
				}
				int index = GameGeneral.GlobalRNG.Next(0, list.Count);
				result = list[index];
				break;
			}
			case ComponentHitType.Engineering:
				foreach (Engine item6 in myUnit.Propulsion)
				{
					list.Add(item6);
				}
				if (list.Count != 0)
				{
					int index = GameGeneral.GlobalRNG.Next(0, list.Count);
					result = list[index];
				}
				else
				{
					result = null;
				}
				break;
			case ComponentHitType.CIC:
				result = ((Ship)myUnit).CIC;
				break;
			case ComponentHitType.Rudder:
				if ((object)myUnit.GetType() == typeof(Ship))
				{
					result = ((Ship)myUnit).Rudder;
					break;
				}
				if ((object)myUnit.GetType() == typeof(Submarine))
				{
					result = ((Submarine)myUnit).Rudder;
					break;
				}
				goto default;
			default:
				result = null;
				break;
			case ComponentHitType.FlightDeck:
			{
				AirFacility[] airFacilities_ReadOnly2 = myUnit.AirFacilities_ReadOnly;
				foreach (AirFacility airFacility2 in airFacilities_ReadOnly2)
				{
					switch (airFacility2.AirFacType)
					{
					case AirFacility._AirFacType.Runway:
					case AirFacility._AirFacType.RunwayWithArrest:
					case AirFacility._AirFacType.RunwayAccessPoint:
					case AirFacility._AirFacType.Catapult:
					case AirFacility._AirFacType.SkiJump:
					case AirFacility._AirFacType.CarrierArrestingGear:
					case AirFacility._AirFacType.Pad:
					case AirFacility._AirFacType.PadWithHaulDown:
					case AirFacility._AirFacType.OpenParking:
					case AirFacility._AirFacType.Elevator:
						list.Add(airFacility2);
						break;
					}
				}
				if (list.Count != 0)
				{
					int index = GameGeneral.GlobalRNG.Next(0, list.Count);
					result = list[index];
				}
				else
				{
					result = null;
				}
				break;
			}
			case ComponentHitType.Hangar:
			{
				AirFacility[] airFacilities_ReadOnly = myUnit.AirFacilities_ReadOnly;
				foreach (AirFacility airFacility in airFacilities_ReadOnly)
				{
					AirFacility._AirFacType airFacType = airFacility.AirFacType;
					if (airFacType == AirFacility._AirFacType.Hangar)
					{
						list.Add(airFacility);
					}
				}
				if (list.Count == 0)
				{
					result = null;
					break;
				}
				int index = GameGeneral.GlobalRNG.Next(0, list.Count);
				result = list[index];
				break;
			}
			case ComponentHitType.Cargo:
			{
				int index = GameGeneral.GlobalRNG.Next(0, myUnit.OnboardCargo.Count());
				result = myUnit.OnboardCargo[index];
				break;
			}
			case ComponentHitType.PressureHull:
				result = ((Submarine)myUnit).PressureHull;
				break;
			case ComponentHitType.Sonar:
			{
				Sensor[] sensors_Cached = myUnit.Sensors_Cached;
				foreach (Sensor sensor in sensors_Cached)
				{
					if (sensor.IsSonar)
					{
						list.Add(sensor);
					}
				}
				if (list.Count == 0)
				{
					result = null;
					break;
				}
				int index = GameGeneral.GlobalRNG.Next(0, list.Count);
				result = list[index];
				break;
			}
			case ComponentHitType.Magazine:
			{
				Magazine[] magazines = ((Platform)myUnit).Magazines;
				foreach (Magazine item in magazines)
				{
					list.Add(item);
				}
				if (list.Count != 0)
				{
					int index = GameGeneral.GlobalRNG.Next(0, list.Count);
					result = list[index];
				}
				else
				{
					result = null;
				}
				break;
			}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100127", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public float ArmorPenetrationPercent(Warhead theWarhead)
	{
		return 100f;
	}

	public virtual ComponentHitType ResolveComponentHitType(Warhead theWarhead)
	{
		return ComponentHitType.Mount;
	}

	public virtual void UnderwayRepairs(float ElapsedTime)
	{
		if (myUnit.ParentScen.HourIsChangingOnThisPulse)
		{
			PerformComponentRepairs(myUnit.Proficiency.Value);
			if (myUnit.IsFacility)
			{
				PerformStructuralRepairs(myUnit.Proficiency.Value);
			}
		}
	}

	public void PerformStructuralRepairs(GlobalVariables.ProficiencyLevel theRepairCrewProficiency)
	{
		try
		{
			if (FireIntensity > FireIntensityLevel.Minor || FloodIntensity > FloodingIntensityLevel.Minor || myUnit.get_DamagePts(ScenEditAction: false, (Weapon)null) >= (float)myUnit.InitialDP)
			{
				return;
			}
			float num = 100f - DamagePercent;
			switch (theRepairCrewProficiency)
			{
			case GlobalVariables.ProficiencyLevel.Novice:
				num = (float)((double)num * 0.3);
				break;
			case GlobalVariables.ProficiencyLevel.Cadet:
				num = (float)((double)num * 0.5);
				break;
			case GlobalVariables.ProficiencyLevel.Regular:
				num = (float)((double)num * 0.8);
				break;
			case GlobalVariables.ProficiencyLevel.Veteran:
				num = (float)((double)num * 1.0);
				break;
			case GlobalVariables.ProficiencyLevel.Ace:
				num = (float)((double)num * 1.5);
				break;
			}
			if (num < 1f && GameGeneral.GlobalRNG.Next(0, 100) < (int)Math.Round(num * 100f))
			{
				num = 1f;
			}
			if (!((double)num >= 1.0) || !((float)GameGeneral.GlobalRNG.Next(0, 101) < num))
			{
				return;
			}
			myUnit.get_DamagePts(ScenEditAction: false, (Weapon)null) += (float)((double)myUnit.InitialDP / 100.0);
			if (myUnit.get_DamagePts(ScenEditAction: false, (Weapon)null) >= (float)myUnit.InitialDP)
			{
				if (myUnit.get_DamagePts(ScenEditAction: false, (Weapon)null) > (float)myUnit.InitialDP)
				{
					myUnit.set_DamagePts(ScenEditAction: false, (Weapon)null, (float)myUnit.InitialDP);
				}
				myUnit.ParentScen.AddMessage(Misc.RemoveHiddenString(myUnit.Name) + ": structural integrity fully restored! ", myUnit.Name + " back to 100%", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			else
			{
				myUnit.ParentScen.AddMessage(Misc.RemoveHiddenString(myUnit.Name) + ": structural damage being repaired, now at " + Conversions.ToString(Math.Round(myUnit.Damage.DamagePercent, 1)) + "%. ", myUnit.Name + " under repairs", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100128", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void PerformComponentRepairs(GlobalVariables.ProficiencyLevel theRepairCrewProficiency)
	{
		try
		{
			float num = 100f - DamagePercent;
			switch (theRepairCrewProficiency)
			{
			case GlobalVariables.ProficiencyLevel.Novice:
				num = (float)((double)num * 0.3);
				break;
			case GlobalVariables.ProficiencyLevel.Cadet:
				num = (float)((double)num * 0.5);
				break;
			case GlobalVariables.ProficiencyLevel.Regular:
				num = (float)((double)num * 0.8);
				break;
			case GlobalVariables.ProficiencyLevel.Veteran:
				num = (float)((double)num * 1.0);
				break;
			case GlobalVariables.ProficiencyLevel.Ace:
				num = (float)((double)num * 1.5);
				break;
			}
			foreach (PlatformComponent item in myUnit.Components())
			{
				if (item.Status == PlatformComponent._ComponentStatus.Damaged)
				{
					PerformIndividualComponentRepair(num, item);
				}
			}
			if (!myUnit.IsShip)
			{
				if (myUnit.IsFacility)
				{
					PerformIndividualComponentRepair(num, ((Facility)myUnit).CIC);
				}
				else if (myUnit.IsSubmarine)
				{
					PerformIndividualComponentRepair(num, ((Submarine)myUnit).CIC);
					PerformIndividualComponentRepair(num, ((Submarine)myUnit).Rudder);
				}
			}
			else
			{
				PerformIndividualComponentRepair(num, ((Ship)myUnit).CIC);
				PerformIndividualComponentRepair(num, ((Ship)myUnit).Rudder);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100128", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void PerformIndividualComponentRepair(float PFix, PlatformComponent theComp)
	{
		if (theComp.Status != PlatformComponent._ComponentStatus.Damaged)
		{
			return;
		}
		switch (theComp.DamageSeverity)
		{
		case PlatformComponent._DamageSeverityFactor.Light:
			PFix -= 10f;
			if ((float)GameGeneral.GlobalRNG.Next(1, 101) < PFix)
			{
				theComp.MakeOperational(GiveUserFeedback: false);
				myUnit.ParentScen.AddMessage(Misc.RemoveHiddenString(myUnit.Name) + " damage report: " + Misc.RemoveHiddenString(theComp.Name) + " has been fully repaired.", myUnit.Name + " damaged component back online", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			break;
		case PlatformComponent._DamageSeverityFactor.Medium:
			if (!myUnit.IsOperating() || myUnit.IsFacility)
			{
				PFix -= 20f;
				if ((float)GameGeneral.GlobalRNG.Next(1, 101) < PFix)
				{
					theComp.DamageSeverity = PlatformComponent._DamageSeverityFactor.Light;
					myUnit.ParentScen.AddMessage(Misc.RemoveHiddenString(myUnit.Name) + " damage report: " + Misc.RemoveHiddenString(theComp.Name) + " is being repaired (light damage).", myUnit.Name + " damaged component being repaired", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
			}
			break;
		case PlatformComponent._DamageSeverityFactor.Heavy:
			if (!myUnit.IsOperating() || myUnit.IsFacility)
			{
				PFix -= 30f;
				if ((float)GameGeneral.GlobalRNG.Next(1, 101) < PFix)
				{
					theComp.DamageSeverity = PlatformComponent._DamageSeverityFactor.Medium;
					myUnit.ParentScen.AddMessage(Misc.RemoveHiddenString(myUnit.Name) + " damage report: " + Misc.RemoveHiddenString(theComp.Name) + " is being repaired (medium damage).", myUnit.Name + " damaged component being repaired", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
			}
			break;
		}
	}

	public void ReportEMPAttack()
	{
		if (myUnit.Sensors_Cached.Length > 0 || myUnit.Comms_ReadOnly.Length > 0)
		{
			myUnit.AddMessage(myUnit.Name + " is being hit by an EMP wave or beam!", myUnit.Name + " zapped!", LoggedMessage.MessageType.UnitDamage, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
		}
		new WeaponImpact(ref myUnit.ParentScen, myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), WeaponImpact.ImpactType.Electronic, 0);
	}

	public void method_5(float PulseStrengthRatio)
	{
		if (myUnit.RemoteSimEntityType != Module_Unit.Unit.RemoteSimEntityTypeEnum.Local || PulseStrengthRatio == 0f || myUnit.IsUnderground || myUnit.IsUnderwater)
		{
			return;
		}
		ReportEMPAttack();
		foreach (PlatformComponent item in myUnit.Components())
		{
			item.vmethod_0(PulseStrengthRatio);
		}
	}

	public void ResolveDamageFromDazzler(float DazzleStrengthRatio)
	{
		if (myUnit.RemoteSimEntityType != Module_Unit.Unit.RemoteSimEntityTypeEnum.Local || myUnit.IsUnderground || myUnit.IsUnderwater)
		{
			return;
		}
		if (myUnit.Sensors_Cached.Length > 0 || myUnit.Comms_ReadOnly.Length > 0)
		{
			myUnit.AddMessage(myUnit.Name + " is being hit by a laser dazzler!", myUnit.Name + " dazzled!", LoggedMessage.MessageType.UnitDamage, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
		}
		if (myUnit.IsPlatform)
		{
			((Platform)myUnit).ResolveDamageFromDazzler(DazzleStrengthRatio);
		}
		foreach (PlatformComponent item in myUnit.Components())
		{
			item.ResolveDamageFromDazzler(DazzleStrengthRatio);
		}
	}

	static ActiveUnit_Damage()
	{
		Class72.smethod_20();
	}
}
