using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class GuidedProjectile : Weapon
{
	private GuidedProjectile_AI guidedProjectile_AI_0;

	private GuidedProjectile_Kinematics guidedProjectile_Kinematics_0;

	public override Weapon_AI AI => guidedProjectile_AI_0;

	public override Weapon_Kinematics Kinematics => guidedProjectile_Kinematics_0;

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

	public override float CurrentAltitude
	{
		get
		{
			return base.get_CurrentAltitude(DoSanityCheck, GlobalVariables.ObjectTrue);
		}
		set
		{
			if (DoSanityCheck && IsGuidedWeapon() && value < 6.0959997f)
			{
				value = 6.0959997f;
			}
			this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			base.set_CurrentAltitude(DoSanityCheck, (GlobalVariables.BooleanObject)null, value);
		}
	}

	public GuidedProjectile(ref Scenario theScen, string theGUID = null)
		: base(theScen, theGUID)
	{
		guidedProjectile_AI_0 = new GuidedProjectile_AI(this);
		ActiveUnit theUnit = this;
		guidedProjectile_Kinematics_0 = new GuidedProjectile_Kinematics(ref theUnit);
		IsWeapon = true;
		base.Type = _WeaponType.GuidedProjectile;
		IsGuidedProjectile = true;
		EvaluateIfDumb();
	}

	public new static GuidedProjectile FromXML_Private(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen, bool LoadStockComponents_Force)
	{
		GuidedProjectile result;
		try
		{
			GuidedProjectile guidedProjectile = new GuidedProjectile(ref theScen);
			guidedProjectile.ParentScen = theScen;
			string innerText = Misc.GetNodeByName(theNode.ChildNodes, "ID").InnerText;
			if (!theDictionary.ContainsKey(innerText))
			{
				guidedProjectile.ObjectID_Set(innerText);
				if (theNode.ChildNodes.Count == 1)
				{
					theScen.UnitsForLateInstantiation.Add(theNode);
					result = guidedProjectile;
				}
				else
				{
					theDictionary.TryAdd(guidedProjectile.ObjectID, guidedProjectile);
					int num = Conversions.ToInteger(Misc.GetNodeByName(theNode.ChildNodes, "DBID").InnerText);
					DBFunctions.GetWeapon(theScen.DBConnection, guidedProjectile, num, theScen, LoadStockComponents_Force);
					if (LoadStockComponents_Force)
					{
						guidedProjectile.method_3(ref theNode, ref theDictionary, ref theScen);
					}
					if (!LoadStockComponents_Force)
					{
						Weapon.LoadSavedComponents(guidedProjectile, theScen, theNode, theDictionary);
					}
					Weapon.LoadMutableProperties(guidedProjectile, theScen, theNode, theDictionary);
					result = guidedProjectile;
				}
			}
			else
			{
				result = (GuidedProjectile)theDictionary[innerText];
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
			result = new GuidedProjectile(ref theScen);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override bool AboutToImpact_ActualTarget(float elapsedTime)
	{
		bool result;
		if (!(result = base.AboutToImpact_ActualTarget(elapsedTime)))
		{
			if (Information.IsNothing((object)AI.PrimaryTarget))
			{
				return false;
			}
			float num = Module_Unit.BearingToUnit_Relative(this, AI.PrimaryTarget);
			if (num > 100f && num < 260f)
			{
				return true;
			}
		}
		return result;
	}

	public override void DoTypeSpecificActions(float elapsedTime, ref LockRandom theRNG)
	{
		if (!ImpactsOnThisPulse_ActualUnit)
		{
			if (IsUnderwater || IsUnderground)
			{
				if (Warheads.Any() && Warheads[0].IsExplosive)
				{
					double theLat = base.get_Latitude((GlobalVariables.BooleanObject)null);
					double theLon = base.get_Longitude((GlobalVariables.BooleanObject)null);
					float theAlt = this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
					LockRandom theRNG2 = GameGeneral.GlobalRNG;
					Detonate(theLat, theLon, theAlt, ref theRNG2, Detonation_AddMessage: true);
				}
				else
				{
					ParentScen.DestroyThisUnit(this, "Guided projectile impacted ground", "Impact / Detonation");
				}
				return;
			}
			if (AI.PrimaryTarget != null)
			{
				ActiveUnit actualUnit = AI.PrimaryTarget.ActualUnit;
				if (actualUnit != null && actualUnit.IsAerospaceUnit && Module_Unit.BearingToUnit_Relative(this, AI.PrimaryTarget) > 100f && Module_Unit.BearingToUnit_Relative(this, AI.PrimaryTarget) < 260f)
				{
					double theLat2 = base.get_Latitude((GlobalVariables.BooleanObject)null);
					double theLon2 = base.get_Longitude((GlobalVariables.BooleanObject)null);
					float theAlt2 = this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
					LockRandom theRNG2 = GameGeneral.GlobalRNG;
					Detonate(theLat2, theLon2, theAlt2, ref theRNG2, Detonation_AddMessage: true);
					return;
				}
			}
			if ((double)Module_Unit.RangeToPoint_Horiz(this, LaunchPoint) > (double)base.MaxRange_NoTargetType * 1.05)
			{
				ParentScen.DestroyThisUnit(this, "Guided projectile ran out of energy", "Out of Fuel");
				return;
			}
		}
		base.DoTypeSpecificActions(elapsedTime, ref theRNG);
	}

	static GuidedProjectile()
	{
		Class72.smethod_20();
	}
}
