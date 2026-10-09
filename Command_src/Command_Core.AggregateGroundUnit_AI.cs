using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class AggregateGroundUnit_AI : ActiveUnit_AI
{
	public enum TacticalPosture
	{
		Withdrawal,
		Delay,
		Hold,
		Push,
		Breakthrough
	}

	private AggregateGroundUnit aggregateGroundUnit_0;

	public AggregateGroundUnit_AI(ref ActiveUnit theUnit)
		: base(theUnit)
	{
		aggregateGroundUnit_0 = (AggregateGroundUnit)theUnit;
	}

	public void Cycle()
	{
		TacticalPosture value = (TacticalPosture)aggregateGroundUnit_0.Doctrine.GetElementState(Doctrine.DoctrineItem_E.AGU_TacticalPosture).Value;
		bool flag = aggregateGroundUnit_0.HostileFrictionProportion.Count > 0;
		float desiredDistance = AGU_CONFIG.Instance.RoadUsageDistanceThreshold_Nm * 0.5f;
		_ = AGU_CONFIG.Instance.RoadUsageDistanceThreshold_Nm;
		switch (GetCombatEffectivness(value, GetBalanceOfPower()))
		{
		case AGU_CombatEffectivness.Effective:
			switch (value)
			{
			case TacticalPosture.Withdrawal:
				if (flag)
				{
					aggregateGroundUnit_0.Order_Fallback(desiredDistance);
				}
				break;
			case TacticalPosture.Push:
				if (flag)
				{
					aggregateGroundUnit_0.Order_Push(desiredDistance, 0.1f);
				}
				break;
			case TacticalPosture.Breakthrough:
				if (flag)
				{
					aggregateGroundUnit_0.Order_Breakthrough(desiredDistance, 0.1f);
				}
				break;
			case TacticalPosture.Delay:
			case TacticalPosture.Hold:
				break;
			}
			break;
		case AGU_CombatEffectivness.Routing:
			aggregateGroundUnit_0.Order_Fallback(desiredDistance);
			break;
		case AGU_CombatEffectivness.Ineffective:
			break;
		}
	}

	public float GetBalanceOfPower()
	{
		float[] array = new float[Enum.GetValues(typeof(CombatPowerType)).Length - 1 + 1];
		float num = 0f;
		float num2 = 0f;
		aggregateGroundUnit_0.GetCombatPower(array);
		int num3 = array.Length - 1;
		for (int i = 0; i <= num3; i++)
		{
			num += array[i] * (float)(i + 1);
		}
		foreach (KeyValuePair<AggregateGroundUnit, float> item in aggregateGroundUnit_0.HostileFrictionProportion)
		{
			aggregateGroundUnit_0.GetCombatPower(array);
			int num4 = array.Length - 1;
			for (int j = 0; j <= num4; j++)
			{
				num2 += array[j] * (float)(j + 1) * item.Value;
			}
		}
		return (num - num2) / num;
	}

	public AGU_CombatEffectivness GetCombatEffectivness(TacticalPosture Posture, float BalanceOfPower = -1f)
	{
		if (BalanceOfPower == -1f)
		{
			BalanceOfPower = GetBalanceOfPower();
		}
		AGU_CONFIG instance = AGU_CONFIG.Instance;
		float num = BalanceOfPower;
		if (instance.Morale_Enable)
		{
			num += aggregateGroundUnit_0.CurrentMorale - 0.5f;
		}
		if (num < instance.Morale_RetreatThreshold)
		{
			return AGU_CombatEffectivness.Routing;
		}
		int result;
		switch (Posture)
		{
		default:
			result = 0;
			break;
		case TacticalPosture.Delay:
			if ((double)num < -0.1)
			{
				return AGU_CombatEffectivness.Ineffective;
			}
			goto IL_00a5;
		case TacticalPosture.Hold:
			if ((double)num < -0.5)
			{
				return AGU_CombatEffectivness.Ineffective;
			}
			goto IL_00a5;
		case TacticalPosture.Push:
			if ((double)num < 0.5)
			{
				return AGU_CombatEffectivness.Ineffective;
			}
			goto IL_00a5;
		case TacticalPosture.Breakthrough:
			{
				if ((double)num < 0.2)
				{
					return AGU_CombatEffectivness.Ineffective;
				}
				goto IL_00a5;
			}
			IL_00a5:
			result = 0;
			break;
		}
		return (AGU_CombatEffectivness)result;
	}

	public override void DeterminePrimaryThreat(float elapsedTime)
	{
		try
		{
			if (myUnit == null)
			{
				return;
			}
			if (_Threats == null || _Threats.Count == 0)
			{
				EvaluateThreats(1f);
			}
			if (_Threats != null)
			{
				if (_Threats.Count != 0)
				{
					_PrimaryThreat = _Threats[0];
				}
				else
				{
					_PrimaryThreat = null;
				}
			}
			else
			{
				_PrimaryThreat = null;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at AGU_100044", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void EvaluateThreats(float elapsedTime)
	{
		Side side = ((ActiveUnit)aggregateGroundUnit_0).get_UnitSide(SetSideOnly: false);
		try
		{
			ClearAllThreats();
			if (theContactsVisibleToMe == null)
			{
				theContactsVisibleToMe = Module_ActiveUnit_Sensory.ContactsVisibleToMe(myUnit.Sensory);
			}
			int num = theContactsVisibleToMe.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				Contact contact = theContactsVisibleToMe[i];
				if (contact == null)
				{
					continue;
				}
				ActiveUnit actualUnit = contact.ActualUnit;
				if (actualUnit == null)
				{
					continue;
				}
				if (!actualUnit.IsVehicle && !actualUnit.IsFacility)
				{
					if (actualUnit.IsAggregatedUnit && aggregateGroundUnit_0.Frictions.ContainsKey((AggregateGroundUnit)actualUnit))
					{
						AddContactToThreatList(contact);
					}
				}
				else
				{
					if (contact.IDStatus < Contact_Base.IdentificationStatus.KnownType)
					{
						continue;
					}
					Misc.PostureStance value;
					if (ContactStanceCache[i].Item1 == null)
					{
						if (!side.Cache_ContactStancesOnThisPulse.TryGetValue(contact.ObjectID, out value))
						{
							value = contact.get_Stance(side);
							side.Cache_ContactStancesOnThisPulse.AddIfNotExists(contact.ObjectID, value);
						}
					}
					else
					{
						value = ContactStanceCache[i].Item2;
					}
					if (value == Misc.PostureStance.Hostile && (double)Module_Unit.RangeToUnit_Slant(myUnit, contact, 0f, GlobalVariables.ObjectTrue) < 5.0)
					{
						AddContactToThreatList(contact);
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at AGU_100548", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	static AggregateGroundUnit_AI()
	{
		Class72.smethod_20();
	}
}
