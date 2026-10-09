using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class BallisticMissile_AI : Weapon_AI
{
	[CompilerGenerated]
	internal sealed class _Closure$__3-0
	{
		public Weapon $VB$Local_myWeapon;

		public BallisticMissile_AI $VB$Me;

		public _Closure$__3-0(_Closure$__3-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_myWeapon = arg0.$VB$Local_myWeapon;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(Contact theC)
		{
			if (theC.SideIsKnown && theC != $VB$Me.PrimaryTarget && !Information.IsNothing((object)theC.ActualUnit) && theC.get_UnitSide(SetSideOnly: false) == $VB$Me.PrimaryTarget.get_UnitSide(SetSideOnly: false) && theC.RangeToUnit_Horiz($VB$Me.PrimaryTarget) < 125f)
			{
				Weapon weapon = $VB$Local_myWeapon;
				ActiveUnit myUnit = $VB$Me.myUnit;
				GlobalVariables.BooleanObject TargetIsDestroyed = null;
				return weapon.IsNominallySuitableForThisTarget(myUnit, ref theC, ref TargetIsDestroyed);
			}
			return false;
		}

		static _Closure$__3-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__3-1
	{
		public List<Contact> $VB$Local_PrimaryTargets;

		public List<Contact> $VB$Local_SecondaryTargets;

		public _Closure$__3-0 $VB$NonLocal_$VB$Closure_2;

		public _Closure$__3-1(_Closure$__3-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_PrimaryTargets = arg0.$VB$Local_PrimaryTargets;
				$VB$Local_SecondaryTargets = arg0.$VB$Local_SecondaryTargets;
			}
		}

		[SpecialName]
		internal bool _Lambda$__5(Contact theC)
		{
			int result;
			if (theC.IDStatus >= Contact_Base.IdentificationStatus.KnownClass)
			{
				if ($VB$Local_PrimaryTargets.Contains(theC))
				{
					result = 0;
					goto IL_0057;
				}
				if (!$VB$Local_SecondaryTargets.Contains(theC))
				{
					BallisticMissile ballisticMissile = $VB$NonLocal_$VB$Closure_2.$VB$Me.method_18();
					ActiveUnit myUnit = $VB$NonLocal_$VB$Closure_2.$VB$Me.myUnit;
					Contact theTarget = theC;
					GlobalVariables.BooleanObject TargetIsDestroyed = null;
					return ballisticMissile.IsNominallySuitableForThisTarget(myUnit, ref theTarget, ref TargetIsDestroyed);
				}
			}
			result = 0;
			goto IL_0057;
			IL_0057:
			return (byte)result != 0;
		}

		static _Closure$__3-1()
		{
			Class72.smethod_20();
		}
	}

	private BallisticMissile ballisticMissile_0;

	public BallisticMissile_AI(Weapon theUnit)
		: base(theUnit)
	{
	}

	private BallisticMissile method_18()
	{
		if (ballisticMissile_0 == null)
		{
			ballisticMissile_0 = (BallisticMissile)myUnit;
		}
		return ballisticMissile_0;
	}

	public void method_19()
	{
		_Closure$__3-0 closure$__3- = new _Closure$__3-0(closure$__3-);
		closure$__3-.$VB$Me = this;
		if (!method_18().Flags.IsBallisticMissile || !method_18().Flags.Warhead_MIRV || method_18().Warheads.Length < 2 || PrimaryTarget == null || PrimaryTarget.ActualUnit == null)
		{
			return;
		}
		closure$__3-.$VB$Local_myWeapon = (Weapon)myUnit;
		try
		{
			_Closure$__3-1 arg = default(_Closure$__3-1);
			_Closure$__3-1 CS$<>8__locals17 = new _Closure$__3-1(arg);
			CS$<>8__locals17.$VB$NonLocal_$VB$Closure_2 = closure$__3-;
			_ = method_18().Warheads.Length;
			List<Contact> list = new List<Contact>();
			List<Contact> list2 = new List<Contact>();
			CS$<>8__locals17.$VB$Local_PrimaryTargets = new List<Contact>();
			CS$<>8__locals17.$VB$Local_SecondaryTargets = new List<Contact>();
			List<Contact> list3 = new List<Contact>();
			List<Contact> list4 = new List<Contact>();
			list2 = ((ActiveUnit)CS$<>8__locals17.$VB$NonLocal_$VB$Closure_2.$VB$Local_myWeapon).get_UnitSide(SetSideOnly: false).Contacts_List.Where([SpecialName] (Contact theC) =>
			{
				if (theC.SideIsKnown && theC != CS$<>8__locals17.$VB$NonLocal_$VB$Closure_2.$VB$Me.PrimaryTarget && !Information.IsNothing((object)theC.ActualUnit) && theC.get_UnitSide(SetSideOnly: false) == CS$<>8__locals17.$VB$NonLocal_$VB$Closure_2.$VB$Me.PrimaryTarget.get_UnitSide(SetSideOnly: false) && theC.RangeToUnit_Horiz(CS$<>8__locals17.$VB$NonLocal_$VB$Closure_2.$VB$Me.PrimaryTarget) < 125f)
				{
					Weapon weapon = CS$<>8__locals17.$VB$NonLocal_$VB$Closure_2.$VB$Local_myWeapon;
					ActiveUnit theAttackingUnit = CS$<>8__locals17.$VB$NonLocal_$VB$Closure_2.$VB$Me.myUnit;
					GlobalVariables.BooleanObject TargetIsDestroyed = null;
					return weapon.IsNominallySuitableForThisTarget(theAttackingUnit, ref theC, ref TargetIsDestroyed);
				}
				return false;
			}).ToList();
			CS$<>8__locals17.$VB$Local_PrimaryTargets = (from theC in list2
				where theC.IDStatus >= Contact_Base.IdentificationStatus.KnownClass && PrimaryTarget.ActualUnit.DBID == theC.ActualUnit.DBID
				orderby Module_Unit.RangeToUnit_Horiz_Angular(theC, PrimaryTarget)
				select theC).ToList();
			CS$<>8__locals17.$VB$Local_SecondaryTargets = (from theC in list2.Where([SpecialName] (Contact theC) =>
				{
					int result;
					if (theC.IDStatus < Contact_Base.IdentificationStatus.KnownClass)
					{
						result = 0;
					}
					else
					{
						if (PrimaryTarget.ActualUnit.DBID != theC.ActualUnit.DBID && Operators.CompareString(PrimaryTarget.ActualUnit.SubTypeDescription, theC.ActualUnit.SubTypeDescription, false) == 0)
						{
							BallisticMissile ballisticMissile = method_18();
							ActiveUnit theAttackingUnit = myUnit;
							Contact theTarget = theC;
							GlobalVariables.BooleanObject TargetIsDestroyed = null;
							return ballisticMissile.IsNominallySuitableForThisTarget(theAttackingUnit, ref theTarget, ref TargetIsDestroyed);
						}
						result = 0;
					}
					return (byte)result != 0;
				})
				orderby Module_Unit.RangeToUnit_Horiz_Angular(theC, PrimaryTarget)
				select theC).ToList();
			list3 = (from theC in list2.Where([SpecialName] (Contact theC) =>
				{
					int result;
					if (theC.IDStatus >= Contact_Base.IdentificationStatus.KnownClass)
					{
						if (CS$<>8__locals17.$VB$Local_PrimaryTargets.Contains(theC))
						{
							result = 0;
							goto IL_0057;
						}
						if (!CS$<>8__locals17.$VB$Local_SecondaryTargets.Contains(theC))
						{
							BallisticMissile ballisticMissile = CS$<>8__locals17.$VB$NonLocal_$VB$Closure_2.$VB$Me.method_18();
							ActiveUnit theAttackingUnit = CS$<>8__locals17.$VB$NonLocal_$VB$Closure_2.$VB$Me.myUnit;
							Contact theTarget = theC;
							GlobalVariables.BooleanObject TargetIsDestroyed = null;
							return ballisticMissile.IsNominallySuitableForThisTarget(theAttackingUnit, ref theTarget, ref TargetIsDestroyed);
						}
					}
					result = 0;
					goto IL_0057;
					IL_0057:
					return (byte)result != 0;
				})
				orderby Module_Unit.RangeToUnit_Horiz_Angular(theC, PrimaryTarget)
				select theC).ToList();
			list.AddRange(CS$<>8__locals17.$VB$Local_PrimaryTargets);
			list.AddRange(CS$<>8__locals17.$VB$Local_SecondaryTargets);
			list.AddRange(list3);
			int? num = null;
			Misc.ShuffleList(list);
			if (list.Count <= 0)
			{
				return;
			}
			int num2 = method_18().Warheads.Length - 1;
			for (int num3 = 1; num3 <= num2; num3++)
			{
				try
				{
					if (list4.Count == 0)
					{
						num = method_20(list);
						if (Information.IsNothing((object)num))
						{
							break;
						}
						foreach (Contact item in list)
						{
							int? num4 = num;
							int num5 = item.QuantityOfIncomingNukes();
							if (((!num4.HasValue) ? ((bool?)null) : new bool?(num4.GetValueOrDefault() == num5)) == true)
							{
								list4.Add(item);
							}
						}
						if (list.Count == 0)
						{
							break;
						}
					}
					for (int num6 = list4.Count - 1; num6 >= 0; num6 += -1)
					{
						TargetThisContact(list4[num6], AddedManually: false, PriorityTarget: false, TargetingEntry._TargetingBehavior.AutoTargeted);
						list4.RemoveAt(num6);
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 200050", ex2.Message);
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 100966", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private int? method_20(List<Contact> list_4)
	{
		int num = 9999;
		foreach (Contact item in list_4)
		{
			int num2 = item.QuantityOfIncomingNukes();
			if (num2 < num)
			{
				num = num2;
			}
		}
		return num;
	}

	public override void DetermineDesiredAttitudeAndThrottle(float elapsedTime, bool RecalculatePlottedCourse = true)
	{
		if (myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
		{
			ActiveUnit_Navigator navigator = myUnit.Navigator;
			bool ForceWaypointSwitch = false;
			bool ForceStationAbort = false;
			navigator.CheckIfReachedWaypoint_AND_Apply_WP_logic(elapsedTime, ref ForceWaypointSwitch, ref ForceStationAbort);
		}
		if (method_18().IsPerformingTerminalManeuvers)
		{
			base.DetermineDesiredAttitudeAndThrottle(elapsedTime, RecalculatePlottedCourse);
		}
	}

	public override void DetermineDesiredAltitude(float elapsedTime)
	{
		if (method_18().IsPerformingTerminalManeuvers)
		{
			base.DetermineDesiredAltitude(elapsedTime);
		}
	}

	protected override void Trajectory_LoftedFlight(float elapsedTime)
	{
		if (method_18().IsPerformingTerminalManeuvers)
		{
			base.Trajectory_LoftedFlight(elapsedTime);
		}
	}

	static BallisticMissile_AI()
	{
		Class72.smethod_20();
	}
}
