using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Collections.Pooled;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ServiceStack.Text;
using ThreadSafeCollections;

namespace Command_Core;

public sealed class Explosion : Module_Unit.Unit
{
	[CompilerGenerated]
	internal sealed class _Closure$__75-0
	{
		public TList<AggregateGroundUnit> $VB$Local_AffectedUnits_AGU;

		public float $VB$Local_theCutOffRange_Frag;

		public TList<ActiveUnit> $VB$Local_AffectedUnits;

		public _Closure$__75-1 $VB$NonLocal_$VB$Closure_2;

		public _Closure$__75-0(_Closure$__75-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_AffectedUnits_AGU = arg0.$VB$Local_AffectedUnits_AGU;
				$VB$Local_theCutOffRange_Frag = arg0.$VB$Local_theCutOffRange_Frag;
				$VB$Local_AffectedUnits = arg0.$VB$Local_AffectedUnits;
			}
		}

		[SpecialName]
		internal void _Lambda$__0(ActiveUnit theAU)
		{
			if (theAU == null || !theAU.IsOperating())
			{
				return;
			}
			if (!theAU.IsAggregatedUnit)
			{
				if (Module_ActiveUnit.IsAimpointFacility(theAU))
				{
					if ((double)Module_Unit.RangeToPoint_Horiz($VB$NonLocal_$VB$Closure_2.$VB$Me, theAU.get_Latitude((GlobalVariables.BooleanObject)null), theAU.get_Longitude((GlobalVariables.BooleanObject)null)) - (double)((Facility)theAU).AimpointDispersalRadius * 0.000539957 <= (double)$VB$Local_theCutOffRange_Frag)
					{
						$VB$Local_AffectedUnits.Add(theAU);
					}
				}
				else if (!theAU.IsWeapon && !theAU.IsAircraft && !theAU.IsGroup && theAU != $VB$NonLocal_$VB$Closure_2.$VB$Me.activeUnit_0 && theAU != $VB$NonLocal_$VB$Closure_2.$VB$Me.activeUnit_1 && Module_Unit.RangeToUnit_Slant($VB$NonLocal_$VB$Closure_2.$VB$Me, theAU) <= $VB$Local_theCutOffRange_Frag && Operators.CompareString($VB$NonLocal_$VB$Closure_2.$VB$Local_ExcludedUnit_ObjectID, theAU.ObjectID, false) != 0 && (!Module_Unit.IsOverLand($VB$NonLocal_$VB$Closure_2.$VB$Me) || Module_Unit.Has_Visual_LOS_ToUnit($VB$NonLocal_$VB$Closure_2.$VB$Me, null, theAU, ref $VB$NonLocal_$VB$Closure_2.$VB$Local_theScen, ConsiderClouds: false, considerOverlappingCoordinatesAsValid: true) == LOSCheckResult.Success))
				{
					$VB$Local_AffectedUnits.Add(theAU);
				}
			}
			else
			{
				$VB$Local_AffectedUnits_AGU.Add((AggregateGroundUnit)theAU);
			}
		}

		static _Closure$__75-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__75-1
	{
		public string $VB$Local_ExcludedUnit_ObjectID;

		public Scenario $VB$Local_theScen;

		public Explosion $VB$Me;

		public _Closure$__75-1(_Closure$__75-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_ExcludedUnit_ObjectID = arg0.$VB$Local_ExcludedUnit_ObjectID;
				$VB$Local_theScen = arg0.$VB$Local_theScen;
			}
		}

		static _Closure$__75-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__77-0
	{
		public TList<AggregateGroundUnit> $VB$Local_AffectedUnits_AGU;

		public double $VB$Local_CloudRadius_meters;

		public TList<ActiveUnit> $VB$Local_AffectedUnits;

		public Explosion $VB$Me;

		public _Closure$__77-0(_Closure$__77-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_AffectedUnits_AGU = arg0.$VB$Local_AffectedUnits_AGU;
				$VB$Local_CloudRadius_meters = arg0.$VB$Local_CloudRadius_meters;
				$VB$Local_AffectedUnits = arg0.$VB$Local_AffectedUnits;
			}
		}

		[SpecialName]
		internal void _Lambda$__0(ActiveUnit theAU)
		{
			if (!theAU.IsOperating())
			{
				return;
			}
			if (!theAU.IsAggregatedUnit)
			{
				if (Module_ActiveUnit.IsAimpointFacility(theAU))
				{
					if ((double)Module_Unit.RangeToPoint_Horiz($VB$Me, theAU.get_Latitude((GlobalVariables.BooleanObject)null), theAU.get_Longitude((GlobalVariables.BooleanObject)null)) * 1852.0 - (double)((Facility)theAU).AimpointDispersalRadius <= $VB$Local_CloudRadius_meters)
					{
						$VB$Local_AffectedUnits.Add(theAU);
					}
				}
				else if (!theAU.IsWeapon && !theAU.IsAircraft && !theAU.IsGroup && theAU != $VB$Me.activeUnit_1 && (double)Module_Unit.RangeToUnit_Slant($VB$Me, theAU) * 1852.0 <= $VB$Local_CloudRadius_meters)
				{
					$VB$Local_AffectedUnits.Add(theAU);
				}
			}
			else
			{
				$VB$Local_AffectedUnits_AGU.Add((AggregateGroundUnit)theAU);
			}
		}

		static _Closure$__77-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__78-0
	{
		public TList<AggregateGroundUnit> $VB$Local_AffectedUnits_AGU;

		public float $VB$Local_CutOffRange_InCloud_meters;

		public TList<ActiveUnit> $VB$Local_AffectedUnits_InCloud;

		public float $VB$Local_CutOffRange_OutOfCloud_meters;

		public TList<ActiveUnit> $VB$Local_AffectedUnits_OutOfCloud;

		public string $VB$Local_ExcludedUnit_ObjectID;

		public Explosion $VB$Me;

		public _Closure$__78-0(_Closure$__78-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_AffectedUnits_AGU = arg0.$VB$Local_AffectedUnits_AGU;
				$VB$Local_CutOffRange_InCloud_meters = arg0.$VB$Local_CutOffRange_InCloud_meters;
				$VB$Local_AffectedUnits_InCloud = arg0.$VB$Local_AffectedUnits_InCloud;
				$VB$Local_CutOffRange_OutOfCloud_meters = arg0.$VB$Local_CutOffRange_OutOfCloud_meters;
				$VB$Local_AffectedUnits_OutOfCloud = arg0.$VB$Local_AffectedUnits_OutOfCloud;
				$VB$Local_ExcludedUnit_ObjectID = arg0.$VB$Local_ExcludedUnit_ObjectID;
			}
		}

		[SpecialName]
		internal void _Lambda$__0(ActiveUnit theAU)
		{
			if (!theAU.IsOperating())
			{
				return;
			}
			if (theAU.IsAggregatedUnit)
			{
				$VB$Local_AffectedUnits_AGU.Add((AggregateGroundUnit)theAU);
			}
			else if (!Module_ActiveUnit.IsAimpointFacility(theAU))
			{
				if (!theAU.IsWeapon && !theAU.IsAircraft && !theAU.IsGroup && theAU != $VB$Me.activeUnit_1 && Operators.CompareString($VB$Local_ExcludedUnit_ObjectID, theAU.ObjectID, false) != 0)
				{
					float num = Module_Unit.RangeToUnit_Slant($VB$Me, theAU);
					if ((double)num * 1852.0 <= (double)$VB$Local_CutOffRange_InCloud_meters)
					{
						$VB$Local_AffectedUnits_InCloud.Add(theAU);
					}
					else if ((double)num * 1852.0 <= (double)$VB$Local_CutOffRange_OutOfCloud_meters)
					{
						$VB$Local_AffectedUnits_OutOfCloud.Add(theAU);
					}
				}
			}
			else
			{
				float num2 = Module_Unit.RangeToPoint_Horiz($VB$Me, theAU.get_Latitude((GlobalVariables.BooleanObject)null), theAU.get_Longitude((GlobalVariables.BooleanObject)null));
				if ((double)num2 * 1852.0 - (double)((Facility)theAU).AimpointDispersalRadius <= (double)$VB$Local_CutOffRange_InCloud_meters)
				{
					$VB$Local_AffectedUnits_InCloud.Add(theAU);
				}
				if ((double)num2 * 1852.0 - (double)((Facility)theAU).AimpointDispersalRadius <= (double)$VB$Local_CutOffRange_OutOfCloud_meters)
				{
					$VB$Local_AffectedUnits_OutOfCloud.Add(theAU);
				}
			}
		}

		static _Closure$__78-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__79-0
	{
		public string $VB$Local_ExcludedUnit_ObjectID;

		public Weapon.DetonationMedium $VB$Local_BlastMedium;

		public Warhead.WarheadType $VB$Local_theWarheadType;

		public Scenario $VB$Local_theScen;

		public Explosion $VB$Me;

		public _Closure$__79-0(_Closure$__79-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_ExcludedUnit_ObjectID = arg0.$VB$Local_ExcludedUnit_ObjectID;
				$VB$Local_BlastMedium = arg0.$VB$Local_BlastMedium;
				$VB$Local_theWarheadType = arg0.$VB$Local_theWarheadType;
				$VB$Local_theScen = arg0.$VB$Local_theScen;
			}
		}

		static _Closure$__79-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__79-1
	{
		public TList<AggregateGroundUnit> $VB$Local_AffectedUnits_AGU;

		public double $VB$Local_BlastRing_OuterRim;

		public double $VB$Local_BlastRing_InnerRim;

		public TList<ActiveUnit> $VB$Local_AffectedUnits;

		public _Closure$__79-0 $VB$NonLocal_$VB$Closure_2;

		public _Closure$__79-1(_Closure$__79-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_AffectedUnits_AGU = arg0.$VB$Local_AffectedUnits_AGU;
				$VB$Local_BlastRing_OuterRim = arg0.$VB$Local_BlastRing_OuterRim;
				$VB$Local_BlastRing_InnerRim = arg0.$VB$Local_BlastRing_InnerRim;
				$VB$Local_AffectedUnits = arg0.$VB$Local_AffectedUnits;
			}
		}

		[SpecialName]
		internal void _Lambda$__0(ActiveUnit theAU)
		{
			if (theAU == null || Operators.CompareString($VB$NonLocal_$VB$Closure_2.$VB$Local_ExcludedUnit_ObjectID, theAU.ObjectID, false) == 0)
			{
				return;
			}
			if (theAU.IsAggregatedUnit)
			{
				$VB$Local_AffectedUnits_AGU.Add((AggregateGroundUnit)theAU);
			}
			else if (!Module_ActiveUnit.IsAimpointFacility(theAU))
			{
				if (theAU.IsOperating() && !theAU.IsGroup && (!theAU.IsWeapon || (($VB$NonLocal_$VB$Closure_2.$VB$Local_theWarheadType == Warhead.WarheadType.Nuclear || ($VB$NonLocal_$VB$Closure_2.$VB$Local_BlastMedium == Weapon.DetonationMedium.Underwater && $VB$NonLocal_$VB$Closure_2.$VB$Me.ExplosiveType == Warhead.WarheadExplosivesType.Nuclear)) && ((Weapon)theAU).CanBeDestroyedByNuke)) && (!theAU.IsAircraft || $VB$NonLocal_$VB$Closure_2.$VB$Me.WarheadType != Warhead.WarheadType.HE_BlastFrag) && (!theAU.IsFacility || (((Facility)theAU).Category != Facility._FacilityCategory.Building_Underground && ((Facility)theAU).Category != Facility._FacilityCategory.SurfaceAndUnderground)) && theAU != $VB$NonLocal_$VB$Closure_2.$VB$Me.activeUnit_1 && $VB$NonLocal_$VB$Closure_2.$VB$Me.method_4(theAU, $VB$NonLocal_$VB$Closure_2.$VB$Local_BlastMedium))
				{
					double num = Module_Unit.RangeToUnit_Slant($VB$NonLocal_$VB$Closure_2.$VB$Me, theAU);
					if ($VB$Local_BlastRing_InnerRim <= num && num <= $VB$Local_BlastRing_OuterRim && (!Module_Unit.IsOverLand($VB$NonLocal_$VB$Closure_2.$VB$Me) || Module_Unit.Has_Visual_LOS_ToUnit($VB$NonLocal_$VB$Closure_2.$VB$Me, null, theAU, ref $VB$NonLocal_$VB$Closure_2.$VB$Local_theScen, ConsiderClouds: false, considerOverlappingCoordinatesAsValid: true) == LOSCheckResult.Success))
					{
						$VB$Local_AffectedUnits.Add(theAU);
					}
				}
			}
			else if ($VB$NonLocal_$VB$Closure_2.$VB$Me.method_4(theAU, $VB$NonLocal_$VB$Closure_2.$VB$Local_BlastMedium))
			{
				float num2 = Module_Unit.RangeToPoint_Slant($VB$NonLocal_$VB$Closure_2.$VB$Me, theAU.get_Latitude((GlobalVariables.BooleanObject)null), theAU.get_Longitude((GlobalVariables.BooleanObject)null), theAU.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
				double num3 = (double)((Facility)theAU).AimpointDispersalRadius * 0.000539957;
				double num4 = (double)num2 - num3;
				double num5 = (double)num2 + num3;
				if (!($VB$Local_BlastRing_OuterRim < num4) && !($VB$Local_BlastRing_InnerRim > num5))
				{
					$VB$Local_AffectedUnits.Add(theAU);
				}
			}
		}

		static _Closure$__79-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__87-0
	{
		public TList<AggregateGroundUnit> $VB$Local_AffectedUnits_AGU;

		public double $VB$Local_CraterRadius;

		public TList<ActiveUnit> $VB$Local_InstaKillUnits;

		public _Closure$__87-1 $VB$NonLocal_$VB$Closure_2;

		public _Closure$__87-0(_Closure$__87-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_AffectedUnits_AGU = arg0.$VB$Local_AffectedUnits_AGU;
				$VB$Local_CraterRadius = arg0.$VB$Local_CraterRadius;
				$VB$Local_InstaKillUnits = arg0.$VB$Local_InstaKillUnits;
			}
		}

		[SpecialName]
		internal void _Lambda$__0(ActiveUnit theAU)
		{
			if (theAU == null || !theAU.IsOperating())
			{
				return;
			}
			if (theAU.IsAggregatedUnit)
			{
				$VB$Local_AffectedUnits_AGU.Add((AggregateGroundUnit)theAU);
			}
			else if (theAU.IsFacility && Module_ActiveUnit.IsAimpointFacility(theAU))
			{
				if ((double)Module_Unit.RangeToPoint_Horiz($VB$NonLocal_$VB$Closure_2.$VB$Me, theAU.get_Latitude((GlobalVariables.BooleanObject)null), theAU.get_Longitude((GlobalVariables.BooleanObject)null)) - (double)((Facility)theAU).AimpointDispersalRadius * 0.000539957 <= $VB$Local_CraterRadius)
				{
					$VB$Local_InstaKillUnits.Add(theAU);
				}
			}
			else
			{
				if (theAU.IsGroup)
				{
					return;
				}
				if ((double)Module_Unit.RangeToPoint_Slant($VB$NonLocal_$VB$Closure_2.$VB$Me, new GeoPoint(theAU.get_Longitude((GlobalVariables.BooleanObject)null), theAU.get_Latitude((GlobalVariables.BooleanObject)null), theAU.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))) > $VB$Local_CraterRadius)
				{
					if (((Module_Unit.Unit)$VB$NonLocal_$VB$Closure_2.$VB$Me).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < 0f && theAU.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > ((Module_Unit.Unit)$VB$NonLocal_$VB$Closure_2.$VB$Me).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) && theAU.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < 2000f && (double)Module_Unit.RangeToPoint_Horiz($VB$NonLocal_$VB$Closure_2.$VB$Me, theAU.get_Latitude((GlobalVariables.BooleanObject)null), theAU.get_Longitude((GlobalVariables.BooleanObject)null)) <= $VB$Local_CraterRadius * 2.0 && Operators.CompareString($VB$NonLocal_$VB$Closure_2.$VB$Local_ExcludedUnit_ObjectID, theAU.ObjectID, false) != 0)
					{
						$VB$Local_InstaKillUnits.Add(theAU);
					}
				}
				else if (Operators.CompareString($VB$NonLocal_$VB$Closure_2.$VB$Local_ExcludedUnit_ObjectID, theAU.ObjectID, false) != 0)
				{
					$VB$Local_InstaKillUnits.Add(theAU);
				}
			}
		}

		static _Closure$__87-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__87-1
	{
		public string $VB$Local_ExcludedUnit_ObjectID;

		public Explosion $VB$Me;

		public _Closure$__87-1(_Closure$__87-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_ExcludedUnit_ObjectID = arg0.$VB$Local_ExcludedUnit_ObjectID;
			}
		}

		static _Closure$__87-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__88-0
	{
		public double $VB$Local_EffectRadius;

		public TList<ActiveUnit> $VB$Local_InstaKillUnits;

		public _Closure$__88-1 $VB$NonLocal_$VB$Closure_2;

		public _Closure$__88-0(_Closure$__88-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_EffectRadius = arg0.$VB$Local_EffectRadius;
				$VB$Local_InstaKillUnits = arg0.$VB$Local_InstaKillUnits;
			}
		}

		[SpecialName]
		internal void _Lambda$__0(ActiveUnit theAU)
		{
			if (theAU == null || !theAU.IsOperating() || theAU.IsGroup || theAU.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < 0f || theAU.CurrentAltitude_AGL < 0f)
			{
				return;
			}
			if (!Module_ActiveUnit.IsAimpointFacility(theAU))
			{
				if ((double)Module_Unit.RangeToPoint_Slant($VB$NonLocal_$VB$Closure_2.$VB$Me, new GeoPoint(theAU.get_Longitude((GlobalVariables.BooleanObject)null), theAU.get_Latitude((GlobalVariables.BooleanObject)null), theAU.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))) <= $VB$Local_EffectRadius && Operators.CompareString($VB$NonLocal_$VB$Closure_2.$VB$Local_ExcludedUnit_ObjectID, theAU.ObjectID, false) != 0)
				{
					$VB$Local_InstaKillUnits.Add(theAU);
				}
			}
			else if ((double)Module_Unit.RangeToPoint_Horiz($VB$NonLocal_$VB$Closure_2.$VB$Me, theAU.get_Latitude((GlobalVariables.BooleanObject)null), theAU.get_Longitude((GlobalVariables.BooleanObject)null)) - (double)((Facility)theAU).AimpointDispersalRadius * 0.000539957 <= $VB$Local_EffectRadius)
			{
				$VB$Local_InstaKillUnits.Add(theAU);
			}
		}

		static _Closure$__88-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__88-1
	{
		public string $VB$Local_ExcludedUnit_ObjectID;

		public Explosion $VB$Me;

		public _Closure$__88-1(_Closure$__88-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_ExcludedUnit_ObjectID = arg0.$VB$Local_ExcludedUnit_ObjectID;
			}
		}

		static _Closure$__88-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__93-0
	{
		public TList<AggregateGroundUnit> $VB$Local_AffectedUnits_AGU;

		public double $VB$Local_ClusterFallboxEncirclingRadius;

		public TList<ActiveUnit> $VB$Local_AffectedUnits;

		public Geopoint_Struct[] $VB$Local_theArea;

		public _Closure$__93-1 $VB$NonLocal_$VB$Closure_2;

		public _Closure$__93-0(_Closure$__93-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_AffectedUnits_AGU = arg0.$VB$Local_AffectedUnits_AGU;
				$VB$Local_ClusterFallboxEncirclingRadius = arg0.$VB$Local_ClusterFallboxEncirclingRadius;
				$VB$Local_AffectedUnits = arg0.$VB$Local_AffectedUnits;
				$VB$Local_theArea = arg0.$VB$Local_theArea;
			}
		}

		[SpecialName]
		internal void _Lambda$__0(ActiveUnit theAU)
		{
			if (!theAU.IsAggregatedUnit)
			{
				if (!Module_ActiveUnit.IsAimpointFacility(theAU))
				{
					if (!theAU.IsWeapon && !theAU.IsAircraft && !theAU.IsGroup && theAU.IsOperating() && ((Module_Unit.Unit)theAU).get_IsInsideThisArea($VB$Local_theArea, $VB$NonLocal_$VB$Closure_2.$VB$Local_thescen, UseCache: false) && Operators.CompareString($VB$NonLocal_$VB$Closure_2.$VB$Local_ExcludedUnit_ObjectID, theAU.ObjectID, false) != 0)
					{
						$VB$Local_AffectedUnits.Add(theAU);
					}
				}
				else if ((double)Module_Unit.RangeToPoint_Horiz($VB$NonLocal_$VB$Closure_2.$VB$Me, theAU.get_Latitude((GlobalVariables.BooleanObject)null), theAU.get_Longitude((GlobalVariables.BooleanObject)null)) * 1852.0 - (double)((Facility)theAU).AimpointDispersalRadius <= $VB$Local_ClusterFallboxEncirclingRadius)
				{
					$VB$Local_AffectedUnits.Add(theAU);
				}
			}
			else
			{
				$VB$Local_AffectedUnits_AGU.Add((AggregateGroundUnit)theAU);
			}
		}

		static _Closure$__93-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__93-1
	{
		public Scenario $VB$Local_thescen;

		public string $VB$Local_ExcludedUnit_ObjectID;

		public Explosion $VB$Me;

		public _Closure$__93-1(_Closure$__93-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_thescen = arg0.$VB$Local_thescen;
				$VB$Local_ExcludedUnit_ObjectID = arg0.$VB$Local_ExcludedUnit_ObjectID;
			}
		}

		static _Closure$__93-1()
		{
			Class72.smethod_20();
		}
	}

	public double ExpYield;

	public double ExpYield_Graphics;

	private double double_0;

	public Warhead.WarheadType WarheadType;

	public Weapon._WeaponType WeaponType;

	public Warhead.WarheadExplosivesType ExplosiveType;

	public int ClusterCoverageLength;

	public int ClusterCoverageWidth;

	public int ClusterSubmunitionQty;

	public float ClusterSubmunitionYield;

	private ActiveUnit activeUnit_0;

	private Mount mount_0;

	private ActiveUnit activeUnit_1;

	private Mount mount_1;

	private string string_1;

	private string string_2;

	private string string_3;

	private string string_4;

	private float? nullable_9;

	private bool? nullable_10;

	private bool? nullable_11;

	private double double_1;

	private double double_2;

	private Module_Unit.Unit unit_0;

	private Contact contact_0;

	private Dictionary<string, string> dictionary_0;

	private Explosion explosion_0;

	private List<Explosion> list_2;

	private bool bool_0;

	public bool CleanedUp => bool_0;

	public List<Explosion> SubExplosions
	{
		get
		{
			return list_2;
		}
		set
		{
			list_2 = value;
		}
	}

	public Module_Unit.Unit ExplodingUnit
	{
		get
		{
			return unit_0;
		}
		set
		{
			unit_0 = value;
		}
	}

	public Explosion TopParentExplosion
	{
		get
		{
			return explosion_0;
		}
		set
		{
			explosion_0 = value;
		}
	}

	public double Longitude_Graphics
	{
		get
		{
			return double_2;
		}
		set
		{
			if (value > 180.0 || value < -180.0)
			{
				value = Math2.NormalizeLongitude(value);
			}
			if (!double.IsNaN(value))
			{
				double_2 = value;
			}
			else if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
	}

	public double Latitude_Graphics
	{
		get
		{
			return double_1;
		}
		set
		{
			if (value > 90.0 || value < -90.0)
			{
				value = Math2.NormalizeLatitude(value);
			}
			if (double.IsNaN(value))
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
			}
			else
			{
				double_1 = value;
			}
		}
	}

	public float MaxDuration
	{
		get
		{
			if (!nullable_9.HasValue)
			{
				double num = CurrentAltitude_AGL;
				switch (WarheadType)
				{
				case Warhead.WarheadType.Torpedo:
				case Warhead.WarheadType.DepthCharge:
				case Warhead.WarheadType.Torpedo_ASWOptimized:
				{
					double num6 = GetCutoffRange_Blast_nm(ExpYield, Weapon.DetonationMedium.Underwater);
					return (float)Math.Max(2.0, num6 / 2916.0 * 3600.0);
				}
				default:
					return 0f;
				case Warhead.WarheadType.SuperFrag:
				case Warhead.WarheadType.Cluster_AP:
				case Warhead.WarheadType.Cluster_AT:
				case Warhead.WarheadType.Cluster_Penetrator:
				case Warhead.WarheadType.Cluster_SmartSubs:
					return Math.Max(2f, ((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) / 300f);
				case Warhead.WarheadType.HE_BlastFrag:
				case Warhead.WarheadType.SemiAP:
				case Warhead.WarheadType.HESH:
				case Warhead.WarheadType.HardTargetPenetrator:
				case Warhead.WarheadType.Nuclear:
				{
					double num2 = num;
					double num3 = default(double);
					if (num2 >= 0.0)
					{
						num3 = GetCutoffRange_Blast_nm(ExpYield, Weapon.DetonationMedium.Air);
					}
					else if (num2 < 0.0)
					{
						if (Module_Unit.IsOverLand(this))
						{
							double num4 = GetCutoffRange_Blast_nm(ExpYield, Weapon.DetonationMedium.Underground);
							return (float)Math.Max(2.0, num4 / 5832.0 * 3600.0);
						}
						double num5 = GetCutoffRange_Blast_nm(ExpYield, Weapon.DetonationMedium.Underwater);
						return (float)Math.Max(2.0, num5 / 2916.0 * 3600.0);
					}
					return (float)Math.Max(2.0, num3 / 661.0 * 3600.0);
				}
				}
			}
			return nullable_9.Value;
		}
	}

	public override bool IsUnderground
	{
		get
		{
			if (!nullable_10.HasValue)
			{
				nullable_10 = base.IsUnderground;
			}
			return nullable_10.Value;
		}
	}

	public override bool IsUnderwater
	{
		get
		{
			if (!nullable_11.HasValue)
			{
				nullable_11 = base.IsUnderwater;
			}
			return nullable_11.Value;
		}
	}

	public double Age => double_0;

	public bool HasExpired => double_0 == (double)MaxDuration;

	public bool IsCluster
	{
		get
		{
			int result;
			switch (WarheadType)
			{
			case Warhead.WarheadType.Cluster_SmartSubs:
				result = 1;
				break;
			default:
				return false;
			case Warhead.WarheadType.SuperFrag:
			case Warhead.WarheadType.Cluster_AP:
			case Warhead.WarheadType.Cluster_AT:
			case Warhead.WarheadType.Cluster_Penetrator:
				result = 1;
				break;
			}
			return (byte)result != 0;
		}
	}

	public bool IsAirburst
	{
		get
		{
			if (CurrentAltitude_AGL > 0f)
			{
				return ((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > 0f;
			}
			return false;
		}
	}

	public double ClusterFallboxEncirclingRadius
	{
		get
		{
			float num = (float)ClusterCoverageLength * PercentGrown;
			float num2 = (float)ClusterCoverageWidth * PercentGrown;
			return Math.Sqrt(Math.Pow(num, 2.0) + Math.Pow(num2, 2.0)) / 2.0;
		}
	}

	public Geopoint_Struct[] ClusterFallBox
	{
		get
		{
			Geopoint_Struct[] result;
			try
			{
				float theLength_m = (float)ClusterCoverageLength * PercentGrown;
				float theWidth_m = (float)ClusterCoverageWidth * PercentGrown;
				result = Math2.GetRectangularArea(((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), theLength_m, theWidth_m, CurrentHeading);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100850", "");
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
	}

	public void MarkAsCleanedUp()
	{
		bool_0 = true;
	}

	public bool isWaitingSubExplosionEvaluation()
	{
		if (SubExplosions.Count == 0)
		{
			return false;
		}
		foreach (Explosion subExplosion in SubExplosions)
		{
			if (!subExplosion.HasExpired)
			{
				return true;
			}
		}
		return false;
	}

	public bool isWaitingSubExplosionCleanUp()
	{
		if (SubExplosions.Count == 0)
		{
			return false;
		}
		foreach (Explosion subExplosion in SubExplosions)
		{
			if (!subExplosion.CleanedUp)
			{
				return true;
			}
		}
		return false;
	}

	public bool otherSubExplosionStillBeingEvaluated()
	{
		if (TopParentExplosion != null)
		{
			return TopParentExplosion.isWaitingSubExplosionEvaluation();
		}
		return false;
	}

	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
		try
		{
			theWriter.WriteStartElement("Explosion");
			theWriter.WriteElementString("ID", ObjectID);
			if (ObjectsAlreadySerialized.Contains(ObjectID))
			{
				theWriter.WriteEndElement();
				return;
			}
			ObjectsAlreadySerialized.Add(ObjectID);
			theWriter.WriteElementString("Name", Name);
			theWriter.WriteElementString("CH", XmlConvert.ToString(CurrentHeading));
			theWriter.WriteElementString("CA", XmlConvert.ToString(((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)));
			theWriter.WriteElementString("Lon", XmlConvert.ToString(((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null)));
			theWriter.WriteElementString("Lat", XmlConvert.ToString(((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null)));
			theWriter.WriteElementString("Lon_Graphics", XmlConvert.ToString(Longitude_Graphics));
			theWriter.WriteElementString("Lat_Graphics", XmlConvert.ToString(Latitude_Graphics));
			if (!string.IsNullOrEmpty(Message))
			{
				theWriter.WriteElementString("Message", Message);
			}
			theWriter.WriteElementString("Yield", XmlConvert.ToString(ExpYield));
			theWriter.WriteElementString("Yield_Graphics", XmlConvert.ToString(ExpYield_Graphics));
			theWriter.WriteElementString("TTL", XmlConvert.ToString(double_0));
			if (!Information.IsNothing((object)nullable_9))
			{
				theWriter.WriteElementString("MaxD", XmlConvert.ToString(nullable_9.Value));
			}
			XmlWriter obj = theWriter;
			int warheadType = (int)WarheadType;
			obj.WriteElementString("WarheadType", warheadType.ToString());
			XmlWriter obj2 = theWriter;
			warheadType = (int)WeaponType;
			obj2.WriteElementString("WeaponType", warheadType.ToString());
			XmlWriter obj3 = theWriter;
			short explosiveType = (short)ExplosiveType;
			obj3.WriteElementString("ExpType", explosiveType.ToString());
			if (!Information.IsNothing((object)activeUnit_0))
			{
				theWriter.WriteElementString("_DirectImpactUnit", activeUnit_0.ObjectID);
			}
			if (!Information.IsNothing((object)mount_0))
			{
				theWriter.WriteElementString("_DirectImpactAimpoint", mount_0.ObjectID);
			}
			if (!Information.IsNothing((object)activeUnit_1))
			{
				theWriter.WriteElementString("_ExcludedUnit", activeUnit_1.ObjectID);
			}
			theWriter.WriteElementString("_ExcludedAimPointID", string_4);
			if (!Information.IsNothing((object)mount_1))
			{
				theWriter.WriteElementString("_ExcludedAimpoint", mount_1.ObjectID);
			}
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100842", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static Explosion FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		Explosion result = default(Explosion);
		try
		{
			Explosion explosion = new Explosion();
			explosion.WarheadType = Warhead.WarheadType.HE_BlastFrag;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "Name":
					explosion.Name = val.InnerText;
					break;
				case "_ExcludedAimPoint":
					explosion.string_4 = val.InnerText;
					break;
				case "Yield":
					explosion.ExpYield = XmlConvert.ToDouble(val.InnerText);
					break;
				case "TTL":
					explosion.double_0 = XmlConvert.ToDouble(val.InnerText);
					break;
				case "Latitude_Graphics":
					explosion.Latitude_Graphics = XmlConvert.ToDouble(val.InnerText);
					break;
				case "ID":
					if (!theDictionary.ContainsKey(val.InnerText))
					{
						explosion.ObjectID_Set(val.InnerText);
						break;
					}
					result = (Explosion)theDictionary[val.InnerText];
					return result;
				case "ExpType":
					explosion.ExplosiveType = (Warhead.WarheadExplosivesType)Conversions.ToShort(val.InnerText);
					break;
				case "WeaponType":
					explosion.WeaponType = (Weapon._WeaponType)Conversions.ToShort(val.InnerText);
					break;
				case "CurrentAltitude":
				case "CH":
					explosion.CurrentHeading = XmlConvert.ToSingle(val.InnerText);
					break;
				case "MaxD":
					explosion.nullable_9 = XmlConvert.ToSingle(val.InnerText);
					break;
				case "CA":
					((Module_Unit.Unit)explosion).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, XmlConvert.ToSingle(val.InnerText));
					break;
				case "Latitude":
				case "Lat":
					((Module_Unit.Unit)explosion).set_Latitude((GlobalVariables.BooleanObject)null, XmlConvert.ToDouble(val.InnerText));
					break;
				case "Message":
					explosion.Message = val.InnerText;
					break;
				case "Longitude":
				case "Lon":
					((Module_Unit.Unit)explosion).set_Longitude((GlobalVariables.BooleanObject)null, XmlConvert.ToDouble(val.InnerText));
					break;
				case "Yield_Graphics":
					explosion.ExpYield_Graphics = XmlConvert.ToDouble(val.InnerText);
					break;
				case "Longitude_Graphics":
					explosion.Longitude_Graphics = XmlConvert.ToDouble(val.InnerText);
					break;
				case "_DirectImpactUnit":
					explosion.string_1 = val.InnerText;
					break;
				case "Duration":
					explosion.double_0 = XmlConvert.ToDouble(val.InnerText);
					break;
				case "WarheadType":
				case "Type":
					explosion.WarheadType = (Warhead.WarheadType)Conversions.ToInteger(val.InnerText);
					if (Versioned.IsNumeric((object)val.InnerText))
					{
						explosion.WarheadType = (Warhead.WarheadType)Conversions.ToInteger(val.InnerText);
					}
					else
					{
						explosion.WarheadType = (Warhead.WarheadType)Enum.Parse(typeof(Warhead.WarheadType), val.InnerText, ignoreCase: true);
					}
					break;
				case "_ExcludedUnit":
					explosion.string_3 = val.InnerText;
					break;
				case "_DirectImpactAimpoint":
					explosion.string_2 = val.InnerText;
					break;
				}
			}
			theDictionary.TryAdd(explosion.ObjectID, explosion);
			result = explosion;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100843", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void PostDeserializationHousekeeping(ref ConcurrentDictionary<string, ScenarioObject> theDictionary)
	{
		try
		{
			if (!Information.IsNothing((object)string_1))
			{
				activeUnit_0 = (ActiveUnit)theDictionary[string_1];
				mount_0 = (Mount)theDictionary[string_2];
				activeUnit_1 = (ActiveUnit)theDictionary[string_3];
				mount_1 = (Mount)theDictionary[string_4];
			}
			if (!string.IsNullOrEmpty(string_3) && theDictionary.ContainsKey(string_3))
			{
				activeUnit_1 = (ActiveUnit)theDictionary[string_3];
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200040", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private Explosion()
	{
		ExplosiveType = Warhead.WarheadExplosivesType.None;
		dictionary_0 = new Dictionary<string, string>();
		explosion_0 = null;
		list_2 = new List<Explosion>();
		bool_0 = false;
	}

	public void Progress(ref Scenario theScen, float elapsedTime)
	{
		double_0 += elapsedTime;
		double num = MaxDuration;
		if (double_0 > num)
		{
			double_0 = num;
		}
		string string_ = ((activeUnit_1 != null) ? activeUnit_1.ObjectID : string_3);
		if (double_0 == num && IsCluster)
		{
			method_11(theScen, string_);
		}
		if (!(double_0 < num))
		{
			return;
		}
		switch (WarheadType)
		{
		case Warhead.WarheadType.HE_BlastFrag:
		case Warhead.WarheadType.SemiAP:
		case Warhead.WarheadType.HESH:
		case Warhead.WarheadType.HardTargetPenetrator:
		case Warhead.WarheadType.Torpedo:
		case Warhead.WarheadType.DepthCharge:
		case Warhead.WarheadType.Torpedo_ASWOptimized:
		case Warhead.WarheadType.Nuclear:
		{
			bool bool_ = theScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LandTypeEffects);
			if (IsUnderwater)
			{
				method_7(theScen, string_, Weapon.DetonationMedium.Underwater, WarheadType, elapsedTime, bool_);
			}
			else if (!IsUnderground)
			{
				method_7(theScen, string_, Weapon.DetonationMedium.Air, WarheadType, elapsedTime, bool_);
			}
			else
			{
				method_7(theScen, string_, Weapon.DetonationMedium.Underground, WarheadType, elapsedTime, bool_);
			}
			break;
		}
		}
	}

	public Explosion(ref Scenario theScen, Module_Unit.Unit explodingUnit, ref Contact thePrimaryTarget, double theLongitude, double theLatitude, double theLongitude_Graphics, double theLatitude_Graphics, float theHeading, float theAltitude, Weapon._WeaponType theWeaponType, float theExpYield, float theExpYield_Graphics, Warhead.WarheadType theWarheadType, Warhead.WarheadExplosivesType theExplosiveType, ActiveUnit DirectImpactUnit = null, Mount DirectImpactAimpoint = null, ActiveUnit ExcludedUnit = null, Mount ExcludedAimPoint = null, float? ExplosionDuration = null, short theClusterCoverageLength = 0, short theClusterCoverageWidth = 0, int theClusterSubmunitionQty = 0, float theClusterSubmunitionYield = 0f, int ARM_TargetedRadar = 0)
	{
		ExplosiveType = Warhead.WarheadExplosivesType.None;
		dictionary_0 = new Dictionary<string, string>();
		explosion_0 = null;
		list_2 = new List<Explosion>();
		bool_0 = false;
		try
		{
			((Module_Unit.Unit)this).set_Longitude((GlobalVariables.BooleanObject)null, theLongitude);
			((Module_Unit.Unit)this).set_Latitude((GlobalVariables.BooleanObject)null, theLatitude);
			Longitude_Graphics = theLongitude_Graphics;
			Latitude_Graphics = theLatitude_Graphics;
			((Module_Unit.Unit)this).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, theAltitude);
			ExpYield = theExpYield;
			ExpYield_Graphics = theExpYield_Graphics;
			WarheadType = theWarheadType;
			WeaponType = theWeaponType;
			ExplosiveType = theExplosiveType;
			activeUnit_0 = DirectImpactUnit;
			mount_0 = DirectImpactAimpoint;
			activeUnit_1 = ExcludedUnit;
			mount_1 = ExcludedAimPoint;
			double_0 = 0.0;
			contact_0 = thePrimaryTarget;
			unit_0 = explodingUnit;
			ClearElevationAndAltitudeAGL();
			ClusterCoverageLength = theClusterCoverageLength;
			ClusterCoverageWidth = theClusterCoverageWidth;
			ClusterSubmunitionQty = theClusterSubmunitionQty;
			ClusterSubmunitionYield = (float)(ExpYield / (double)theClusterSubmunitionQty);
			if (explodingUnit != null)
			{
				unit_0.GeneratedParentExplosions.Add(this);
				unit_0.EndgameReport.WeaponScenario = theScen;
				DeleteExplodingUnit(theScen);
			}
			if (activeUnit_1 != null)
			{
				string_3 = activeUnit_1.ObjectID;
			}
			if (WarheadType == Warhead.WarheadType.HardTargetPenetrator && method_1())
			{
				((Module_Unit.Unit)this).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)Terrain.GetElevation(((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, theScen) - 10f);
			}
			if (theWarheadType == Warhead.WarheadType.Nuclear)
			{
				method_9(ref theScen, string_3);
				method_10(ref theScen, string_3);
			}
			if (IsAirburst)
			{
				if (ExpYield > 0.0)
				{
					Explosion explosion = new Explosion(ref theScen, this, theLongitude, theLatitude, Longitude_Graphics, Latitude_Graphics, theHeading, theAltitude, theWeaponType, theExpYield, theExpYield_Graphics, theWarheadType, theExplosiveType, Weapon.DetonationMedium.Air, DirectImpactUnit, DirectImpactAimpoint, ExcludedUnit, ExcludedAimPoint, ExplosionDuration, ARM_TargetedRadar)
					{
						ClusterCoverageLength = ClusterCoverageLength,
						ClusterCoverageWidth = ClusterCoverageWidth,
						ClusterSubmunitionQty = ClusterSubmunitionQty,
						ClusterSubmunitionYield = ClusterSubmunitionYield
					};
					if (!Information.IsNothing((object)ExplosionDuration))
					{
						explosion.nullable_9 = ExplosionDuration;
					}
					if (method_13(theExpYield / 1000000f, CurrentAltitude_AGL))
					{
						method_8(ref theScen, string_3, Weapon.DetonationMedium.Air);
					}
				}
				if (WarheadType == Warhead.WarheadType.Nuclear)
				{
					if (ExpYield > 0.0)
					{
						method_15(theScen);
					}
				}
				else if (WarheadType == Warhead.WarheadType.Fragmentation || WarheadType == Warhead.WarheadType.HardTargetPenetrator || WarheadType == Warhead.WarheadType.HE_BlastFrag || WarheadType == Warhead.WarheadType.HEAT || WarheadType == Warhead.WarheadType.HESH || WarheadType == Warhead.WarheadType.Landmine_AP || WarheadType == Warhead.WarheadType.Landmine_AT || WarheadType == Warhead.WarheadType.SemiAP || WarheadType == Warhead.WarheadType.FAE || WarheadType == Warhead.WarheadType.SuperFrag || WarheadType == Warhead.WarheadType.Cluster_AT)
				{
					if (!Module_Unit.IsOverLand(this) && WarheadType != Warhead.WarheadType.Incendiary)
					{
						if (Information.IsNothing((object)ExcludedUnit))
						{
							new WaterSplash(ref theScen, Longitude_Graphics, Latitude_Graphics, GetCutoffRange_Blast_nm(ExpYield_Graphics, Weapon.DetonationMedium.Surface));
						}
					}
					else
					{
						new GroundImpact(ref theScen, Longitude_Graphics, Latitude_Graphics, GetCutoffRange_Blast_nm(ExpYield_Graphics, Weapon.DetonationMedium.Air), WarheadType == Warhead.WarheadType.Incendiary);
					}
				}
				if (WarheadType == Warhead.WarheadType.EMP_Omni)
				{
					ExpYield = 42999999.0;
					method_15(theScen);
				}
				return;
			}
			if (!method_1())
			{
				if (method_2())
				{
					if (ExpYield > 0.0)
					{
						Explosion explosion2 = new Explosion(ref theScen, this, theLongitude, theLatitude, Longitude_Graphics, Latitude_Graphics, theHeading, 1f, theWeaponType, (float)((double)theExpYield * 0.9), theExpYield_Graphics, theWarheadType, theExplosiveType, Weapon.DetonationMedium.Air, DirectImpactUnit, DirectImpactAimpoint, ExcludedUnit, ExcludedAimPoint, ExplosionDuration)
						{
							ClusterCoverageLength = ClusterCoverageLength,
							ClusterCoverageWidth = ClusterCoverageWidth,
							ClusterSubmunitionQty = ClusterSubmunitionQty,
							ClusterSubmunitionYield = ClusterSubmunitionYield
						};
						if (!Information.IsNothing((object)ExplosionDuration))
						{
							explosion2.nullable_9 = ExplosionDuration;
						}
						if (WarheadType == Warhead.WarheadType.Nuclear)
						{
							Explosion explosion3 = new Explosion(ref theScen, this, theLongitude, theLatitude, Longitude_Graphics, Latitude_Graphics, theHeading, -1f, theWeaponType, (float)((double)theExpYield * 0.1), theExpYield_Graphics, Warhead.WarheadType.HE_BlastFrag, theExplosiveType, Weapon.DetonationMedium.Underwater, DirectImpactUnit, DirectImpactAimpoint, ExcludedUnit, ExcludedAimPoint, ExplosionDuration)
							{
								ClusterCoverageLength = ClusterCoverageLength,
								ClusterCoverageWidth = ClusterCoverageWidth
							};
							if (!Information.IsNothing((object)ExplosionDuration))
							{
								explosion3.nullable_9 = ExplosionDuration;
							}
						}
					}
					if (WarheadType == Warhead.WarheadType.Nuclear)
					{
						if (ExpYield > 0.0)
						{
							method_15(theScen);
						}
					}
					else if (WarheadType == Warhead.WarheadType.Incendiary)
					{
						new GroundImpact(ref theScen, Longitude_Graphics, Latitude_Graphics, 0.01349892f, WarheadType == Warhead.WarheadType.Incendiary);
					}
					else if (!IsCluster)
					{
						new WaterSplash(ref theScen, Longitude_Graphics, Latitude_Graphics, GetCutoffRange_Blast_nm(ExpYield_Graphics, Weapon.DetonationMedium.Air));
					}
					return;
				}
				if (!IsUnderwater)
				{
					if (IsUnderground)
					{
						if (ExpYield > 0.0)
						{
							method_8(ref theScen, string_3, Weapon.DetonationMedium.Underground);
							new GroundImpact(ref theScen, Longitude_Graphics, Latitude_Graphics, GetCutoffRange_Blast_nm(ExpYield_Graphics, Weapon.DetonationMedium.Air), WarheadType == Warhead.WarheadType.Incendiary);
						}
						return;
					}
					throw new NotImplementedException("Unforeseen set of circumstances for Explosion. Explosion altitude: " + Conversions.ToString(((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) + ". Local terrain elevation: " + Conversions.ToString((int)Terrain.GetElevation(((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, ((Module_Unit.Unit)this).get_UnitSide(SetSideOnly: false).ParentScen)));
				}
				if (ExpYield > 0.0)
				{
					int num = 1;
					if (WarheadType == Warhead.WarheadType.Nuclear)
					{
						num = 600;
					}
					if (((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < (float)(-num))
					{
						Explosion explosion4 = new Explosion(ref theScen, this, theLongitude, theLatitude, Longitude_Graphics, Latitude_Graphics, theHeading, theAltitude, theWeaponType, theExpYield, theExpYield_Graphics, theWarheadType, theExplosiveType, Weapon.DetonationMedium.Underwater, DirectImpactUnit, DirectImpactAimpoint, ExcludedUnit, ExcludedAimPoint, ExplosionDuration)
						{
							ClusterCoverageLength = ClusterCoverageLength,
							ClusterCoverageWidth = ClusterCoverageWidth,
							ClusterSubmunitionQty = ClusterSubmunitionQty,
							ClusterSubmunitionYield = ClusterSubmunitionYield
						};
						if (ExplosionDuration.HasValue)
						{
							explosion4.nullable_9 = ExplosionDuration;
						}
					}
					else
					{
						double x = Math.Sqrt(Math.Pow(num, 2.0) - Math.Pow(((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), 2.0));
						double num2 = Math.PI / 6.0 * (double)Math.Abs(((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) * (3.0 * Math.Pow(num, 2.0) + 3.0 * Math.Pow(x, 2.0) + Math.Pow(((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), 2.0));
						double num3 = 4.1887902047863905 * Math.Pow(num, 3.0);
						double num4 = num3 / 2.0 + num2;
						double num5 = (double)theExpYield * (num4 / num3);
						double num6 = (double)theExpYield - num5;
						Explosion explosion5 = new Explosion(ref theScen, this, theLongitude, theLatitude, Longitude_Graphics, Latitude_Graphics, theHeading, theAltitude, theWeaponType, (float)num5, theExpYield_Graphics, theWarheadType, theExplosiveType, Weapon.DetonationMedium.Underwater, DirectImpactUnit, DirectImpactAimpoint, ExcludedUnit, ExcludedAimPoint, ExplosionDuration)
						{
							ClusterCoverageLength = ClusterCoverageLength,
							ClusterCoverageWidth = ClusterCoverageWidth,
							ClusterSubmunitionQty = ClusterSubmunitionQty,
							ClusterSubmunitionYield = ClusterSubmunitionYield
						};
						if (ExplosionDuration.HasValue)
						{
							explosion5.nullable_9 = ExplosionDuration;
						}
						Explosion explosion6 = new Explosion(ref theScen, this, theLongitude, theLatitude, Longitude_Graphics, Latitude_Graphics, theHeading, 0f, theWeaponType, (float)num6, theExpYield_Graphics, theWarheadType, theExplosiveType, Weapon.DetonationMedium.Underwater, DirectImpactUnit, DirectImpactAimpoint, ExcludedUnit, ExcludedAimPoint, ExplosionDuration)
						{
							ClusterCoverageLength = ClusterCoverageLength,
							ClusterCoverageWidth = ClusterCoverageWidth,
							ClusterSubmunitionQty = ClusterSubmunitionQty,
							ClusterSubmunitionYield = ClusterSubmunitionYield
						};
						if (ExplosionDuration.HasValue)
						{
							explosion6.nullable_9 = ExplosionDuration;
						}
					}
				}
				if (!IsCluster)
				{
					new WaterSplash(ref theScen, Longitude_Graphics, Latitude_Graphics, GetCutoffRange_Blast_nm(ExpYield_Graphics, Weapon.DetonationMedium.Underwater));
				}
				return;
			}
			if (ExpYield > 0.0)
			{
				Explosion explosion7 = new Explosion(ref theScen, this, theLongitude, theLatitude, Longitude_Graphics, Latitude_Graphics, theHeading, Terrain.GetElevation(theLatitude, theLongitude, RequestIsFromGUI: false, theScen) + 1, theWeaponType, (float)((double)theExpYield * 0.95), theExpYield_Graphics, theWarheadType, theExplosiveType, Weapon.DetonationMedium.Air, DirectImpactUnit, DirectImpactAimpoint, ExcludedUnit, ExcludedAimPoint, ExplosionDuration)
				{
					ClusterCoverageLength = ClusterCoverageLength,
					ClusterCoverageWidth = ClusterCoverageWidth,
					ClusterSubmunitionQty = ClusterSubmunitionQty,
					ClusterSubmunitionYield = ClusterSubmunitionYield
				};
				if (!Information.IsNothing((object)ExplosionDuration))
				{
					explosion7.nullable_9 = ExplosionDuration;
				}
				method_8(ref theScen, string_3, Weapon.DetonationMedium.Surface);
			}
			if (WarheadType == Warhead.WarheadType.Nuclear)
			{
				if (ExpYield > 0.0)
				{
					method_15(theScen);
				}
			}
			else if (WarheadType == Warhead.WarheadType.Incendiary || WarheadType == Warhead.WarheadType.Fragmentation || WarheadType == Warhead.WarheadType.HardTargetPenetrator || WarheadType == Warhead.WarheadType.HE_BlastFrag || WarheadType == Warhead.WarheadType.HEAT || WarheadType == Warhead.WarheadType.HESH || WarheadType == Warhead.WarheadType.Landmine_AP || WarheadType == Warhead.WarheadType.Landmine_AT || WarheadType == Warhead.WarheadType.SemiAP || WarheadType == Warhead.WarheadType.FAE)
			{
				new GroundImpact(ref theScen, Longitude_Graphics, Latitude_Graphics, GetCutoffRange_Blast_nm(ExpYield_Graphics, Weapon.DetonationMedium.Air), WarheadType == Warhead.WarheadType.Incendiary);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100844", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private Explosion(ref Scenario theScen, Explosion parentExplosion, double theLongitude, double theLatitude, double theLongitude_Graphics, double theLatitude_Graphics, float theHeading, float theAltitude, Weapon._WeaponType theWeaponType, float theExpYield, float theExpYield_Graphics, Warhead.WarheadType theWarheadType, Warhead.WarheadExplosivesType theExplosiveType, Weapon.DetonationMedium DetMedium, ActiveUnit DirectImpactUnit = null, Mount DirectImpactAimpoint = null, ActiveUnit ExcludedUnit = null, Mount ExcludedAimPoint = null, float? ExplosionDuration = null, int ARM_TargetedRadar = 0)
	{
		ExplosiveType = Warhead.WarheadExplosivesType.None;
		dictionary_0 = new Dictionary<string, string>();
		explosion_0 = null;
		list_2 = new List<Explosion>();
		bool_0 = false;
		try
		{
			((Module_Unit.Unit)this).set_Longitude((GlobalVariables.BooleanObject)null, theLongitude);
			((Module_Unit.Unit)this).set_Latitude((GlobalVariables.BooleanObject)null, theLatitude);
			Longitude_Graphics = theLongitude_Graphics;
			Latitude_Graphics = theLatitude_Graphics;
			((Module_Unit.Unit)this).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, theAltitude);
			CurrentHeading = theHeading;
			ExpYield = theExpYield;
			ExpYield_Graphics = theExpYield_Graphics;
			WarheadType = theWarheadType;
			WeaponType = theWeaponType;
			ExplosiveType = theExplosiveType;
			activeUnit_0 = DirectImpactUnit;
			mount_0 = DirectImpactAimpoint;
			activeUnit_1 = ExcludedUnit;
			mount_1 = ExcludedAimPoint;
			double_0 = 0.0;
			if (parentExplosion.TopParentExplosion != null)
			{
				TopParentExplosion = parentExplosion.TopParentExplosion;
			}
			else
			{
				TopParentExplosion = parentExplosion;
			}
			TopParentExplosion.SubExplosions.Add(this);
			if (!Information.IsNothing((object)ExplosionDuration))
			{
				nullable_9 = ExplosionDuration;
			}
			if (Information.IsNothing((object)activeUnit_1))
			{
				string_3 = "";
			}
			else
			{
				string_3 = activeUnit_1.ObjectID;
			}
			Interlocked.Increment(ref theScen.UnitsAutoIncrement);
			theScen.Explosions.Add(this);
			bool bool_ = theScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LandTypeEffects);
			switch (WarheadType)
			{
			case Warhead.WarheadType.Incendiary:
				method_5(theScen, null, WarheadType, theScen.GameResolution);
				break;
			case Warhead.WarheadType.HE_BlastFrag:
			case Warhead.WarheadType.SemiAP:
			case Warhead.WarheadType.HardTargetPenetrator:
			case Warhead.WarheadType.Torpedo:
			case Warhead.WarheadType.DepthCharge:
				if (CurrentAltitude_AGL >= 0f && Module_Unit.IsOverLand(this))
				{
					method_3(theScen, string_3, bool_, WarheadType, ARM_TargetedRadar);
				}
				if (!(MaxDuration <= theScen.GameResolution))
				{
					break;
				}
				double_0 = theScen.GameResolution;
				if (!IsUnderwater)
				{
					if (!IsUnderground)
					{
						method_7(theScen, string_3, Weapon.DetonationMedium.Air, theWarheadType, theScen.GameResolution, bool_);
					}
					else
					{
						method_7(theScen, string_3, Weapon.DetonationMedium.Underground, theWarheadType, theScen.GameResolution, bool_);
					}
				}
				else
				{
					method_7(theScen, string_3, Weapon.DetonationMedium.Underwater, theWarheadType, theScen.GameResolution, bool_);
				}
				break;
			case Warhead.WarheadType.FAE:
				method_6(theScen, string_3, Warhead.WarheadType.FAE, theScen.GameResolution, theScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LandTypeEffects));
				break;
			case Warhead.WarheadType.Fragmentation:
			case Warhead.WarheadType.SuperFrag:
				if (((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) >= 0f)
				{
					method_3(theScen, string_3, bool_, WarheadType, ARM_TargetedRadar);
				}
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100845", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	[SpecialName]
	private bool method_1()
	{
		if (CurrentAltitude_AGL == 0f)
		{
			return Module_Unit.IsOverLand(this);
		}
		return false;
	}

	[SpecialName]
	private bool method_2()
	{
		if (((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) == 0f)
		{
			return !Module_Unit.IsOverLand(this);
		}
		return false;
	}

	private void method_3(Scenario scenario_0, string string_5, bool bool_1, Warhead.WarheadType warheadType_0, int int_1 = 0)
	{
		_Closure$__75-1 closure$__75- = new _Closure$__75-1(closure$__75-);
		closure$__75-.$VB$Me = this;
		closure$__75-.$VB$Local_theScen = scenario_0;
		closure$__75-.$VB$Local_ExcludedUnit_ObjectID = string_5;
		try
		{
			_Closure$__75-0 arg = default(_Closure$__75-0);
			_Closure$__75-0 CS$<>8__locals25 = new _Closure$__75-0(arg);
			CS$<>8__locals25.$VB$NonLocal_$VB$Closure_2 = closure$__75-;
			CS$<>8__locals25.$VB$Local_theCutOffRange_Frag = GetCutoffRange_Frag_nm(ExpYield, Weapon.DetonationMedium.Air, warheadType_0);
			if (mount_0 != null)
			{
				mount_0.ResolveDamageFromFrag(ExpYield, CS$<>8__locals25.$VB$Local_theCutOffRange_Frag, int_1);
			}
			CS$<>8__locals25.$VB$Local_AffectedUnits = new TList<ActiveUnit>();
			List<ActiveUnit> source = new List<ActiveUnit>(CS$<>8__locals25.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.ActiveUnits_List);
			CS$<>8__locals25.$VB$Local_AffectedUnits_AGU = new TList<AggregateGroundUnit>();
			Parallel.ForEach(source, [SpecialName] (ActiveUnit theAU) =>
			{
				if (theAU != null && theAU.IsOperating())
				{
					if (!theAU.IsAggregatedUnit)
					{
						if (Module_ActiveUnit.IsAimpointFacility(theAU))
						{
							if ((double)Module_Unit.RangeToPoint_Horiz(CS$<>8__locals25.$VB$NonLocal_$VB$Closure_2.$VB$Me, theAU.get_Latitude((GlobalVariables.BooleanObject)null), theAU.get_Longitude((GlobalVariables.BooleanObject)null)) - (double)((Facility)theAU).AimpointDispersalRadius * 0.000539957 <= (double)CS$<>8__locals25.$VB$Local_theCutOffRange_Frag)
							{
								CS$<>8__locals25.$VB$Local_AffectedUnits.Add(theAU);
							}
						}
						else if (!theAU.IsWeapon && !theAU.IsAircraft && !theAU.IsGroup && theAU != CS$<>8__locals25.$VB$NonLocal_$VB$Closure_2.$VB$Me.activeUnit_0 && theAU != CS$<>8__locals25.$VB$NonLocal_$VB$Closure_2.$VB$Me.activeUnit_1 && Module_Unit.RangeToUnit_Slant(CS$<>8__locals25.$VB$NonLocal_$VB$Closure_2.$VB$Me, theAU) <= CS$<>8__locals25.$VB$Local_theCutOffRange_Frag && Operators.CompareString(CS$<>8__locals25.$VB$NonLocal_$VB$Closure_2.$VB$Local_ExcludedUnit_ObjectID, theAU.ObjectID, false) != 0 && (!Module_Unit.IsOverLand(CS$<>8__locals25.$VB$NonLocal_$VB$Closure_2.$VB$Me) || Module_Unit.Has_Visual_LOS_ToUnit(CS$<>8__locals25.$VB$NonLocal_$VB$Closure_2.$VB$Me, null, theAU, ref CS$<>8__locals25.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen, ConsiderClouds: false, considerOverlappingCoordinatesAsValid: true) == LOSCheckResult.Success))
						{
							CS$<>8__locals25.$VB$Local_AffectedUnits.Add(theAU);
						}
					}
					else
					{
						CS$<>8__locals25.$VB$Local_AffectedUnits_AGU.Add((AggregateGroundUnit)theAU);
					}
				}
			});
			double out_lon = default(double);
			double out_lat = default(double);
			foreach (ActiveUnit item in CS$<>8__locals25.$VB$Local_AffectedUnits)
			{
				float num = MathFunctions.SlantRange_NM_SR(Math2.CalcDist(((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), item.get_Latitude((GlobalVariables.BooleanObject)null), item.get_Longitude((GlobalVariables.BooleanObject)null)), Math.Abs(((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - item.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)));
				if (Module_ActiveUnit.IsAimpointFacility(item))
				{
					IEnumerable<Mount> enumerable = item.Mounts.Where([SpecialName] (Mount theM) => theM.Status != PlatformComponent._ComponentStatus.Destroyed && theM != mount_0 && theM != mount_1);
					foreach (Mount item2 in enumerable)
					{
						Geodesic_EdWilliams.CalcPoint_Williams(item.get_Longitude((GlobalVariables.BooleanObject)null), item.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, item2.AimpointOffset_Distance / 1852f, item2.AimpointOffset_Bearing);
						float num2 = Math2.CalcDist(((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), out_lat, out_lon);
						if (num2 < 0f)
						{
							num2 = 0f - num2;
						}
						double distanceFromTarget_nm = MathFunctions.SlantRange_NM_SR(num2, Math.Abs(((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - item.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)));
						double num3 = Warhead.FragDamageAtThisDistance(out_lat, out_lon, distanceFromTarget_nm, WarheadType, ExpYield, Weapon.DetonationMedium.Air, bool_1, item.ParentScen);
						if (num3 > 0.0)
						{
							MarkAffectedUnit(item);
							item2.ResolveDamageFromFrag(num3, CS$<>8__locals25.$VB$Local_theCutOffRange_Frag, int_1);
						}
					}
				}
				else
				{
					float num4 = Warhead.FragDamageAtThisDistance(item.get_Latitude((GlobalVariables.BooleanObject)null), item.get_Longitude((GlobalVariables.BooleanObject)null), num, WarheadType, ExpYield, Weapon.DetonationMedium.Air, bool_1, CS$<>8__locals25.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen);
					if (num4 > 0f)
					{
						MarkAffectedUnit(item);
						item.Damage.ResolveDamageFromFrag(num4, CS$<>8__locals25.$VB$Local_theCutOffRange_Frag, WarheadType, int_1);
					}
				}
			}
			foreach (AggregateGroundUnit item3 in CS$<>8__locals25.$VB$Local_AffectedUnits_AGU)
			{
				float num5 = Module_Unit.RangeToUnit_Slant(this, item3);
				double num6 = item3.InfluenceInterectionArea_Nm2(num5, item3.GetInfluenceRadius(), CS$<>8__locals25.$VB$Local_theCutOffRange_Frag);
				double num7 = num6 / (double)item3.GetInfluenceArea_Nm2();
				if (num6 > 0.0)
				{
					item3.ResolveAGUDamages(AggregateGroundUnit.CreateDamageMatrix((float)(num7 * ExpYield), AggregateGroundUnit.DamageMatrixType.Standard), 0.1f, 10f);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100846", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private bool method_4(ActiveUnit activeUnit_2, Weapon.DetonationMedium detonationMedium_0)
	{
		switch (detonationMedium_0)
		{
		case Weapon.DetonationMedium.Air:
			return !activeUnit_2.IsUnderground && !activeUnit_2.IsUnderwater;
		default:
			throw new NotImplementedException();
		case Weapon.DetonationMedium.Underwater:
			if (activeUnit_2.IsShip && WeaponType == Weapon._WeaponType.DepthCharge)
			{
				return false;
			}
			return activeUnit_2.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= 0f && !Module_Unit.IsOverLand(activeUnit_2);
		case Weapon.DetonationMedium.Underground:
			return activeUnit_2.IsFixedFacility || activeUnit_2.IsUnderground;
		}
	}

	private void method_5(Scenario scenario_0, string string_5, Warhead.WarheadType warheadType_0, float float_6)
	{
		_Closure$__77-0 arg = default(_Closure$__77-0);
		_Closure$__77-0 CS$<>8__locals16 = new _Closure$__77-0(arg);
		CS$<>8__locals16.$VB$Me = this;
		if (mount_0 != null)
		{
			mount_0.Destroy(mount_0.ParentPlatform.get_UnitSide(SetSideOnly: false), ScenEditAction: false, IsAimpointFacility: true);
		}
		CS$<>8__locals16.$VB$Local_CloudRadius_meters = Math.Sqrt(2100.0 / Math.PI);
		CS$<>8__locals16.$VB$Local_AffectedUnits = new TList<ActiveUnit>();
		List<ActiveUnit> source = new List<ActiveUnit>(scenario_0.ActiveUnits_List);
		CS$<>8__locals16.$VB$Local_AffectedUnits_AGU = new TList<AggregateGroundUnit>();
		Parallel.ForEach(source, [SpecialName] (ActiveUnit theAU) =>
		{
			if (theAU.IsOperating())
			{
				if (!theAU.IsAggregatedUnit)
				{
					if (Module_ActiveUnit.IsAimpointFacility(theAU))
					{
						if ((double)Module_Unit.RangeToPoint_Horiz(CS$<>8__locals16.$VB$Me, theAU.get_Latitude((GlobalVariables.BooleanObject)null), theAU.get_Longitude((GlobalVariables.BooleanObject)null)) * 1852.0 - (double)((Facility)theAU).AimpointDispersalRadius <= CS$<>8__locals16.$VB$Local_CloudRadius_meters)
						{
							CS$<>8__locals16.$VB$Local_AffectedUnits.Add(theAU);
						}
					}
					else if (!theAU.IsWeapon && !theAU.IsAircraft && !theAU.IsGroup && theAU != CS$<>8__locals16.$VB$Me.activeUnit_1 && (double)Module_Unit.RangeToUnit_Slant(CS$<>8__locals16.$VB$Me, theAU) * 1852.0 <= CS$<>8__locals16.$VB$Local_CloudRadius_meters)
					{
						CS$<>8__locals16.$VB$Local_AffectedUnits.Add(theAU);
					}
				}
				else
				{
					CS$<>8__locals16.$VB$Local_AffectedUnits_AGU.Add((AggregateGroundUnit)theAU);
				}
			}
		});
		double out_lon = default(double);
		double out_lat = default(double);
		GlobalVariables.ArmorRating armorRating = default(GlobalVariables.ArmorRating);
		int num4 = default(int);
		foreach (ActiveUnit item in CS$<>8__locals16.$VB$Local_AffectedUnits)
		{
			if (Module_ActiveUnit.IsAimpointFacility(item))
			{
				IEnumerable<Mount> enumerable = item.Mounts.Where([SpecialName] (Mount theM) => theM.Status != PlatformComponent._ComponentStatus.Destroyed && theM != mount_0 && theM != mount_1);
				foreach (Mount item2 in enumerable)
				{
					Geodesic_EdWilliams.CalcPoint_Williams(item.get_Longitude((GlobalVariables.BooleanObject)null), item.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, item2.AimpointOffset_Distance / 1852f, item2.AimpointOffset_Bearing);
					double num = Math2.CalcDist(((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), out_lat, out_lon);
					double num2 = ((Math.Abs(((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - item.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) != 0f) ? ((double)MathFunctions.SlantRange_NM_SR((float)num, Math.Abs(((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - item.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)))) : num);
					if (!(num2 * 1852.0 > CS$<>8__locals16.$VB$Local_CloudRadius_meters))
					{
						int num3;
						switch (item2.ArmorRating)
						{
						default:
							num3 = 8;
							break;
						case GlobalVariables.ArmorRating.Light:
							num3 = 6;
							break;
						case GlobalVariables.ArmorRating.Medium:
							num3 = 4;
							break;
						case GlobalVariables.ArmorRating.Heavy:
						case GlobalVariables.ArmorRating.Special:
							num3 = 2;
							break;
						}
						if (GameGeneral.GlobalRNG.Next(1, 11) < num3)
						{
							MarkAffectedUnit(item);
							item.AddMessage(Misc.RemoveHiddenString(item.Name) + " damage report: " + Misc.RemoveHiddenString(item2.Name) + " has been destroyed!", "Damage report", LoggedMessage.MessageType.UnitDamage, 0, new Geopoint_Struct(item.get_Longitude((GlobalVariables.BooleanObject)null), item.get_Latitude((GlobalVariables.BooleanObject)null)));
							item2.Destroy(item.get_UnitSide(SetSideOnly: false), ScenEditAction: false, IsAimpointFacility: true);
						}
					}
				}
				continue;
			}
			switch (item.UnitType)
			{
			case GlobalVariables.ActiveUnitType.Ship:
				armorRating = ((Ship)item).Armor_Deck;
				break;
			case GlobalVariables.ActiveUnitType.Facility:
				armorRating = ((Facility)item).Armor_General;
				break;
			case GlobalVariables.ActiveUnitType.Submarine:
				continue;
			}
			switch (item.VisualSizeClass)
			{
			case GlobalVariables.TargetVisualSizeClass.Stealthy:
			case GlobalVariables.TargetVisualSizeClass.VSmall:
				num4 += 4;
				break;
			case GlobalVariables.TargetVisualSizeClass.Small:
				num4 += 3;
				break;
			case GlobalVariables.TargetVisualSizeClass.Medium:
				num4 += 2;
				break;
			case GlobalVariables.TargetVisualSizeClass.Large:
			case GlobalVariables.TargetVisualSizeClass.VLarge:
				num4++;
				break;
			}
			int val;
			switch (armorRating)
			{
			default:
				num4 += 4;
				val = 4;
				break;
			case GlobalVariables.ArmorRating.Light:
				num4 += 3;
				val = 4;
				break;
			case GlobalVariables.ArmorRating.Medium:
				num4 += 2;
				val = 4;
				break;
			case GlobalVariables.ArmorRating.Heavy:
			case GlobalVariables.ArmorRating.Special:
				num4++;
				val = 4;
				break;
			}
			num4 = Math.Min(val, (int)Math.Round((double)num4 / 2.0));
			MarkAffectedUnit(item);
			item.Damage.CauseFire((ActiveUnit_Damage.FireIntensityLevel)Math.Max((int)item.Damage.FireIntensity, num4));
		}
		foreach (AggregateGroundUnit item3 in CS$<>8__locals16.$VB$Local_AffectedUnits_AGU)
		{
			float num5 = Module_Unit.RangeToUnit_Slant(this, item3);
			double num6 = item3.InfluenceInterectionArea_Nm2(num5, item3.GetInfluenceRadius(), CS$<>8__locals16.$VB$Local_CloudRadius_meters);
			double num7 = num6 / (double)item3.GetInfluenceArea_Nm2();
			if (num6 > 0.0)
			{
				item3.ResolveAGUDamages(AggregateGroundUnit.CreateDamageMatrix((float)(num7 * ExpYield), AggregateGroundUnit.DamageMatrixType.Standard), 0.1f, 10f);
			}
		}
	}

	private void method_6(Scenario scenario_0, string string_5, Warhead.WarheadType warheadType_0, float float_6, bool bool_1)
	{
		_Closure$__78-0 arg = default(_Closure$__78-0);
		_Closure$__78-0 CS$<>8__locals30 = new _Closure$__78-0(arg);
		CS$<>8__locals30.$VB$Me = this;
		CS$<>8__locals30.$VB$Local_ExcludedUnit_ObjectID = string_5;
		double num = ExpYield;
		Weather.WeatherProfile weatherProfile = Weather.get_WeatherAtThisTimeAndPlace(scenario_0, ((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), (int)Math.Round(((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)));
		if (mount_0 != null)
		{
			mount_0.ResolveDamageFromBlast(ExpYield, WarheadType);
		}
		float rainfallRate = weatherProfile.RainfallRate;
		if (!(rainfallRate < 5f))
		{
			num = ((rainfallRate < 10f) ? (num * 0.9) : ((rainfallRate < 20f) ? (num * 0.7) : ((rainfallRate < 30f) ? (num * 0.5) : ((!(rainfallRate < 40f)) ? (num * 0.2) : (num * 0.35)))));
		}
		float num2 = ((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
		if (!(num2 < 1000f))
		{
			num = ((num2 < 2000f) ? (num * 0.9) : ((num2 < 3000f) ? (num * 0.75) : ((num2 < 4000f) ? (num * 0.6) : ((num2 < 5000f) ? (num * 0.45) : ((!(num2 < 6000f)) ? (num * 0.2) : (num * 0.3))))));
		}
		CS$<>8__locals30.$VB$Local_CutOffRange_InCloud_meters = (float)(ExpYield / 5.0);
		CS$<>8__locals30.$VB$Local_CutOffRange_OutOfCloud_meters = CS$<>8__locals30.$VB$Local_CutOffRange_InCloud_meters + GetCutoffRange_Blast_nm(num, Weapon.DetonationMedium.Air) * 1852f;
		CS$<>8__locals30.$VB$Local_AffectedUnits_InCloud = new TList<ActiveUnit>();
		CS$<>8__locals30.$VB$Local_AffectedUnits_OutOfCloud = new TList<ActiveUnit>();
		List<ActiveUnit> source = new List<ActiveUnit>(scenario_0.ActiveUnits_List);
		CS$<>8__locals30.$VB$Local_AffectedUnits_AGU = new TList<AggregateGroundUnit>();
		Parallel.ForEach(source, [SpecialName] (ActiveUnit theAU) =>
		{
			if (theAU.IsOperating())
			{
				if (theAU.IsAggregatedUnit)
				{
					CS$<>8__locals30.$VB$Local_AffectedUnits_AGU.Add((AggregateGroundUnit)theAU);
				}
				else if (!Module_ActiveUnit.IsAimpointFacility(theAU))
				{
					if (!theAU.IsWeapon && !theAU.IsAircraft && !theAU.IsGroup && theAU != CS$<>8__locals30.$VB$Me.activeUnit_1 && Operators.CompareString(CS$<>8__locals30.$VB$Local_ExcludedUnit_ObjectID, theAU.ObjectID, false) != 0)
					{
						float num14 = Module_Unit.RangeToUnit_Slant(CS$<>8__locals30.$VB$Me, theAU);
						if ((double)num14 * 1852.0 <= (double)CS$<>8__locals30.$VB$Local_CutOffRange_InCloud_meters)
						{
							CS$<>8__locals30.$VB$Local_AffectedUnits_InCloud.Add(theAU);
						}
						else if ((double)num14 * 1852.0 <= (double)CS$<>8__locals30.$VB$Local_CutOffRange_OutOfCloud_meters)
						{
							CS$<>8__locals30.$VB$Local_AffectedUnits_OutOfCloud.Add(theAU);
						}
					}
				}
				else
				{
					float num15 = Module_Unit.RangeToPoint_Horiz(CS$<>8__locals30.$VB$Me, theAU.get_Latitude((GlobalVariables.BooleanObject)null), theAU.get_Longitude((GlobalVariables.BooleanObject)null));
					if ((double)num15 * 1852.0 - (double)((Facility)theAU).AimpointDispersalRadius <= (double)CS$<>8__locals30.$VB$Local_CutOffRange_InCloud_meters)
					{
						CS$<>8__locals30.$VB$Local_AffectedUnits_InCloud.Add(theAU);
					}
					if ((double)num15 * 1852.0 - (double)((Facility)theAU).AimpointDispersalRadius <= (double)CS$<>8__locals30.$VB$Local_CutOffRange_OutOfCloud_meters)
					{
						CS$<>8__locals30.$VB$Local_AffectedUnits_OutOfCloud.Add(theAU);
					}
				}
			}
		});
		double out_lon = default(double);
		double out_lat = default(double);
		foreach (ActiveUnit item in CS$<>8__locals30.$VB$Local_AffectedUnits_InCloud)
		{
			if (!Module_ActiveUnit.IsAimpointFacility(item))
			{
				if (num > 0.0)
				{
					item.Damage.CauseFire(ActiveUnit_Damage.FireIntensityLevel.Major);
					item.Damage.ResolveDamageFromBlast((float)num, warheadType_0, ExplosiveType, Weapon.DetonationMedium.Air);
					MarkAffectedUnit(item);
				}
				continue;
			}
			IEnumerable<Mount> enumerable = item.Mounts.Where([SpecialName] (Mount theM) => theM.Status != PlatformComponent._ComponentStatus.Destroyed && theM != mount_0 && theM != mount_1);
			foreach (Mount item2 in enumerable)
			{
				Geodesic_EdWilliams.CalcPoint_Williams(item.get_Longitude((GlobalVariables.BooleanObject)null), item.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, item2.AimpointOffset_Distance / 1852f, item2.AimpointOffset_Bearing);
				double num3 = Math2.CalcDist(((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), out_lat, out_lon);
				double num4 = ((Math.Abs(((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - item.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) != 0f) ? ((double)MathFunctions.SlantRange_NM_SR((float)num3, Math.Abs(((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - item.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)))) : num3);
				if (!(num4 * 1852.0 > (double)CS$<>8__locals30.$VB$Local_CutOffRange_InCloud_meters) && num > 0.0)
				{
					item2.ResolveDamageFromBlast(num, warheadType_0);
					MarkAffectedUnit(item);
				}
			}
		}
		double out_lon2 = default(double);
		double out_lat2 = default(double);
		foreach (ActiveUnit item3 in CS$<>8__locals30.$VB$Local_AffectedUnits_OutOfCloud)
		{
			if (!Module_ActiveUnit.IsAimpointFacility(item3))
			{
				float num5 = Module_Unit.RangeToPoint_Horiz(this, item3.get_Latitude((GlobalVariables.BooleanObject)null), item3.get_Longitude((GlobalVariables.BooleanObject)null)) - CS$<>8__locals30.$VB$Local_CutOffRange_InCloud_meters / 1852f;
				float num6 = Warhead.BlastDamageAtThisDistance(item3.get_Latitude((GlobalVariables.BooleanObject)null), item3.get_Longitude((GlobalVariables.BooleanObject)null), num5, item3.InitialDP, WarheadType, num, Weapon.DetonationMedium.Air, bool_1, scenario_0);
				if (num6 > 0f)
				{
					MarkAffectedUnit(item3);
					item3.Damage.CauseFire(ActiveUnit_Damage.FireIntensityLevel.Major);
					item3.Damage.ResolveDamageFromBlast(num6, warheadType_0, ExplosiveType, Weapon.DetonationMedium.Air);
				}
				continue;
			}
			IEnumerable<Mount> enumerable2 = item3.Mounts.Where([SpecialName] (Mount theM) => theM.Status != PlatformComponent._ComponentStatus.Destroyed && theM != mount_0 && theM != mount_1);
			foreach (Mount item4 in enumerable2)
			{
				Geodesic_EdWilliams.CalcPoint_Williams(item3.get_Longitude((GlobalVariables.BooleanObject)null), item3.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon2, ref out_lat2, item4.AimpointOffset_Distance / 1852f, item4.AimpointOffset_Bearing);
				float num7 = Math2.CalcDist(((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), out_lat2, out_lon2);
				double num8 = ((Math.Abs(((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - item3.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) != 0f) ? ((double)MathFunctions.SlantRange_NM_SR(num7, Math.Abs(((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - item3.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)))) : ((double)num7));
				if (!(num8 * 1852.0 > (double)CS$<>8__locals30.$VB$Local_CutOffRange_OutOfCloud_meters) && !(num8 * 1852.0 <= (double)CS$<>8__locals30.$VB$Local_CutOffRange_InCloud_meters))
				{
					float num9 = num7 - CS$<>8__locals30.$VB$Local_CutOffRange_InCloud_meters / 1852f;
					float num10 = Warhead.BlastDamageAtThisDistance(out_lat2, out_lon2, num9, item4.DP, WarheadType, num, Weapon.DetonationMedium.Air, bool_1, scenario_0);
					if (num10 > 0f)
					{
						MarkAffectedUnit(item3);
						item4.ResolveDamageFromBlast(num10, warheadType_0);
					}
				}
			}
		}
		foreach (AggregateGroundUnit item5 in CS$<>8__locals30.$VB$Local_AffectedUnits_AGU)
		{
			float num11 = Module_Unit.RangeToUnit_Slant(this, item5);
			double num12 = item5.InfluenceInterectionArea_Nm2(num11, item5.GetInfluenceRadius(), CS$<>8__locals30.$VB$Local_CutOffRange_InCloud_meters / 1852f);
			double num13 = num12 / (double)item5.GetInfluenceArea_Nm2();
			if (num12 > 0.0)
			{
				item5.ResolveAGUDamages(AggregateGroundUnit.CreateDamageMatrix((float)(num13 * num), AggregateGroundUnit.DamageMatrixType.Standard), 0.1f, 10f);
			}
		}
	}

	private void method_7(Scenario scenario_0, string string_5, Weapon.DetonationMedium detonationMedium_0, Warhead.WarheadType warheadType_0, float float_6, bool bool_1)
	{
		_Closure$__79-0 closure$__79- = new _Closure$__79-0(closure$__79-);
		closure$__79-.$VB$Me = this;
		closure$__79-.$VB$Local_theScen = scenario_0;
		closure$__79-.$VB$Local_ExcludedUnit_ObjectID = string_5;
		closure$__79-.$VB$Local_BlastMedium = detonationMedium_0;
		closure$__79-.$VB$Local_theWarheadType = warheadType_0;
		try
		{
			_Closure$__79-1 arg = default(_Closure$__79-1);
			_Closure$__79-1 CS$<>8__locals49 = new _Closure$__79-1(arg);
			CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2 = closure$__79-;
			if (mount_0 != null)
			{
				mount_0.ResolveDamageFromBlast(ExpYield, WarheadType);
			}
			int num = default(int);
			switch (CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_BlastMedium)
			{
			case Weapon.DetonationMedium.Air:
				num = 661;
				break;
			case Weapon.DetonationMedium.Underwater:
				num = 2916;
				break;
			case Weapon.DetonationMedium.Underground:
				num = 5832;
				break;
			}
			CS$<>8__locals49.$VB$Local_BlastRing_OuterRim = double_0 / 3600.0 * (double)num;
			CS$<>8__locals49.$VB$Local_BlastRing_InnerRim = (double_0 - (double)float_6) / 3600.0 * (double)num;
			float cutoffRange_Blast_nm = GetCutoffRange_Blast_nm(ExpYield, CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_BlastMedium);
			if (CS$<>8__locals49.$VB$Local_BlastRing_OuterRim > (double)cutoffRange_Blast_nm)
			{
				CS$<>8__locals49.$VB$Local_BlastRing_OuterRim = cutoffRange_Blast_nm;
			}
			CS$<>8__locals49.$VB$Local_AffectedUnits = new TList<ActiveUnit>();
			CS$<>8__locals49.$VB$Local_AffectedUnits_AGU = new TList<AggregateGroundUnit>();
			Parallel.ForEach(new List<ActiveUnit>(CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen.ActiveUnits_List), [SpecialName] (ActiveUnit theAU) =>
			{
				if (theAU != null && Operators.CompareString(CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_ExcludedUnit_ObjectID, theAU.ObjectID, false) != 0)
				{
					if (theAU.IsAggregatedUnit)
					{
						CS$<>8__locals49.$VB$Local_AffectedUnits_AGU.Add((AggregateGroundUnit)theAU);
					}
					else if (!Module_ActiveUnit.IsAimpointFacility(theAU))
					{
						if (theAU.IsOperating() && !theAU.IsGroup && (!theAU.IsWeapon || ((CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_theWarheadType == Warhead.WarheadType.Nuclear || (CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_BlastMedium == Weapon.DetonationMedium.Underwater && CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Me.ExplosiveType == Warhead.WarheadExplosivesType.Nuclear)) && ((Weapon)theAU).CanBeDestroyedByNuke)) && (!theAU.IsAircraft || CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Me.WarheadType != Warhead.WarheadType.HE_BlastFrag) && (!theAU.IsFacility || (((Facility)theAU).Category != Facility._FacilityCategory.Building_Underground && ((Facility)theAU).Category != Facility._FacilityCategory.SurfaceAndUnderground)) && theAU != CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Me.activeUnit_1 && CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Me.method_4(theAU, CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_BlastMedium))
						{
							double num16 = Module_Unit.RangeToUnit_Slant(CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Me, theAU);
							if (CS$<>8__locals49.$VB$Local_BlastRing_InnerRim <= num16 && num16 <= CS$<>8__locals49.$VB$Local_BlastRing_OuterRim && (!Module_Unit.IsOverLand(CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Me) || Module_Unit.Has_Visual_LOS_ToUnit(CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Me, null, theAU, ref CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen, ConsiderClouds: false, considerOverlappingCoordinatesAsValid: true) == LOSCheckResult.Success))
							{
								CS$<>8__locals49.$VB$Local_AffectedUnits.Add(theAU);
							}
						}
					}
					else if (CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Me.method_4(theAU, CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_BlastMedium))
					{
						float num17 = Module_Unit.RangeToPoint_Slant(CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Me, theAU.get_Latitude((GlobalVariables.BooleanObject)null), theAU.get_Longitude((GlobalVariables.BooleanObject)null), theAU.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
						double num18 = (double)((Facility)theAU).AimpointDispersalRadius * 0.000539957;
						double num19 = (double)num17 - num18;
						double num20 = (double)num17 + num18;
						if (!(CS$<>8__locals49.$VB$Local_BlastRing_OuterRim < num19) && !(CS$<>8__locals49.$VB$Local_BlastRing_InnerRim > num20))
						{
							CS$<>8__locals49.$VB$Local_AffectedUnits.Add(theAU);
						}
					}
				}
			});
			double out_lon = default(double);
			double out_lat = default(double);
			foreach (ActiveUnit item in CS$<>8__locals49.$VB$Local_AffectedUnits)
			{
				float num2 = Math2.CalcDist(((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), item.get_Latitude((GlobalVariables.BooleanObject)null), item.get_Longitude((GlobalVariables.BooleanObject)null));
				float num3 = ((Math.Abs(((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - item.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) != 0f) ? MathFunctions.SlantRange_NM_SR(num2, Math.Abs(((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - item.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))) : num2);
				if (item.IsFacility)
				{
					if (!((Facility)item).HasAimpoints)
					{
						float num4 = Warhead.BlastDamageAtThisDistance(item.get_Latitude((GlobalVariables.BooleanObject)null), item.get_Longitude((GlobalVariables.BooleanObject)null), num3, item.InitialDP, WarheadType, ExpYield, CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_BlastMedium, bool_1, CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen);
						if (num4 > 0f)
						{
							MarkAffectedUnit(item);
							item.Damage.ResolveDamageFromBlast(num4, WarheadType, ExplosiveType, CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_BlastMedium);
						}
						continue;
					}
					IEnumerable<Mount> enumerable = item.Mounts.Where([SpecialName] (Mount theM) => theM.Status != PlatformComponent._ComponentStatus.Destroyed && theM != mount_0 && theM != mount_1);
					foreach (Mount item2 in enumerable)
					{
						Geodesic_EdWilliams.CalcPoint_Williams(item.get_Longitude((GlobalVariables.BooleanObject)null), item.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, item2.AimpointOffset_Distance / 1852f, item2.AimpointOffset_Bearing);
						double num5 = Math2.CalcDist(((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), out_lat, out_lon);
						double num6 = ((Math.Abs(((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - item.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) != 0f) ? ((double)MathFunctions.SlantRange_NM_SR((float)num5, Math.Abs(((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - item.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)))) : num5);
						if (!(num6 > (double)cutoffRange_Blast_nm) && CS$<>8__locals49.$VB$Local_BlastRing_InnerRim <= num6 && num6 <= CS$<>8__locals49.$VB$Local_BlastRing_OuterRim && (!Module_Unit.IsOverLand(this) || Module_Unit.Has_Visual_LOS_ToUnit(this, null, item, ref CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen, ConsiderClouds: false, considerOverlappingCoordinatesAsValid: true) == LOSCheckResult.Success))
						{
							double num7 = Warhead.BlastDamageAtThisDistance(out_lat, out_lon, num6, item2.DP, WarheadType, ExpYield, CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_BlastMedium, bool_1, CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen);
							if (num7 > 0.0)
							{
								MarkAffectedUnit(item);
								item2.ResolveDamageFromBlast(num7, WarheadType);
							}
						}
					}
				}
				else if (!item.IsWeapon)
				{
					Weapon.DetonationMedium detonationMedium = CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_BlastMedium;
					if (detonationMedium == Weapon.DetonationMedium.Underwater)
					{
						if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
						{
							item.AddMessage(item.Name + " is being hit by an underwater explosion at " + Conversions.ToString((int)Math.Round((double)num3 * 1852.0 * 3.2808399200439453)) + " ft!", "Damage report", LoggedMessage.MessageType.UnitDamage, 0, new Geopoint_Struct(item.get_Longitude((GlobalVariables.BooleanObject)null), item.get_Latitude((GlobalVariables.BooleanObject)null)));
						}
						else
						{
							item.AddMessage(item.Name + " is being hit by an underwater explosion at " + Conversions.ToString((int)Math.Round((double)num3 * 1852.0)) + " m!", "Damage report", LoggedMessage.MessageType.UnitDamage, 0, new Geopoint_Struct(item.get_Longitude((GlobalVariables.BooleanObject)null), item.get_Latitude((GlobalVariables.BooleanObject)null)));
						}
					}
					float num11;
					if (CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_BlastMedium == Weapon.DetonationMedium.Underwater)
					{
						double val = Math2.Sind(Module_Unit.BearingToPoint_Relative(item, ((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null)));
						double val2 = Math2.Sind(Module_Unit.GrazingAngleToPoint(item, ((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)));
						double num8 = Math.Max(val, val2);
						double d = ExpYield * 2.20462;
						double num9 = (double)num3 * 1852.0 * 3.2808399200439453;
						double num10 = Math.Sqrt(d) * (1.0 + num8) / (num9 * 2.0) * GetShockScalingFactor(item.VisualSizeClass);
						num11 = ((num10 < 0.1) ? ((float)((double)item.InitialDP * ((double)GameGeneral.GlobalRNG.Next(5, 16) / 100.0))) : ((num10 < 0.15) ? ((float)((double)item.InitialDP * ((double)GameGeneral.GlobalRNG.Next(15, 36) / 100.0))) : ((num10 < 0.2) ? ((float)((double)item.InitialDP * ((double)GameGeneral.GlobalRNG.Next(35, 56) / 100.0))) : ((num10 < 0.5) ? ((float)((double)item.InitialDP * ((double)GameGeneral.GlobalRNG.Next(55, 76) / 100.0))) : ((num10 < 0.6) ? ((float)((double)item.InitialDP * ((double)GameGeneral.GlobalRNG.Next(75, 96) / 100.0))) : ((!(num10 < 0.7)) ? ((float)((double)item.InitialDP * ((double)GameGeneral.GlobalRNG.Next(115, 136) / 100.0))) : ((float)((double)item.InitialDP * ((double)GameGeneral.GlobalRNG.Next(95, 116) / 100.0)))))))));
					}
					else
					{
						num11 = Warhead.BlastDamageAtThisDistance(item.get_Latitude((GlobalVariables.BooleanObject)null), item.get_Longitude((GlobalVariables.BooleanObject)null), num3, item.InitialDP, WarheadType, ExpYield, CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_BlastMedium, bool_1, CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_theScen);
					}
					if (CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_BlastMedium == Weapon.DetonationMedium.Underground)
					{
						float num12 = Math.Abs((float)Math2.Sind(Module_Unit.BearingToPoint_Relative(item, ((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null))));
						num11 = (float)((double)num11 * (0.2 + 0.8 * (double)num12));
					}
					if (num11 > 0f)
					{
						MarkAffectedUnit(item);
						item.Damage.ResolveDamageFromBlast(num11, WarheadType, ExplosiveType, CS$<>8__locals49.$VB$NonLocal_$VB$Closure_2.$VB$Local_BlastMedium);
					}
				}
				else
				{
					item.AddMessage(item.Name + " has been destroyed by blast!", "Damage report", LoggedMessage.MessageType.UnitDamage, 0, new Geopoint_Struct(item.get_Longitude((GlobalVariables.BooleanObject)null), item.get_Latitude((GlobalVariables.BooleanObject)null)));
					item.ParentScen.DestroyThisUnit(item, "destroyed by blast!", "Weapon Interaction");
				}
			}
			foreach (AggregateGroundUnit item3 in CS$<>8__locals49.$VB$Local_AffectedUnits_AGU)
			{
				float num13 = Module_Unit.RangeToUnit_Slant(this, item3);
				double num14 = item3.InfluenceInterectionArea_Nm2(num13, item3.GetInfluenceRadius(), CS$<>8__locals49.$VB$Local_BlastRing_OuterRim);
				double num15 = num14 / (double)item3.GetInfluenceArea_Nm2();
				if (num14 > 0.0)
				{
					item3.ResolveAGUDamages(AggregateGroundUnit.CreateDamageMatrix((float)(num15 * ExpYield), AggregateGroundUnit.DamageMatrixType.Standard), 0.1f, 10f);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100847", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static double GetShockScalingFactor(GlobalVariables.TargetVisualSizeClass dispClass)
	{
		switch (dispClass)
		{
		default:
			return 1.0;
		case GlobalVariables.TargetVisualSizeClass.Stealthy:
		case GlobalVariables.TargetVisualSizeClass.VSmall:
			return 2.5;
		case GlobalVariables.TargetVisualSizeClass.Small:
			return 1.6;
		case GlobalVariables.TargetVisualSizeClass.Medium:
			return 1.0;
		case GlobalVariables.TargetVisualSizeClass.Large:
			return 0.65;
		case GlobalVariables.TargetVisualSizeClass.VLarge:
			return 0.4;
		}
	}

	public void DeleteExplodingUnit(Scenario theScen)
	{
		if (TopParentExplosion == null)
		{
			if (unit_0.IsActiveUnit && !((ActiveUnit)unit_0).IsMorituri)
			{
				theScen.DestroyThisUnit((ActiveUnit)unit_0, "Weapon Hit");
			}
			else if (unit_0 is UnguidedWeapon)
			{
				theScen.DestroyThisUnguidedWeapon((UnguidedWeapon)unit_0, "Weapon Hit");
			}
		}
		else
		{
			TopParentExplosion.DeleteExplodingUnit(theScen);
		}
	}

	public void MarkAffectedUnit(Module_Unit.Unit affectedUnit)
	{
		if (TopParentExplosion != null)
		{
			TopParentExplosion.MarkAffectedUnit(affectedUnit);
		}
		else if (affectedUnit != null && !dictionary_0.ContainsKey(affectedUnit.ObjectID))
		{
			dictionary_0.Add(affectedUnit.ObjectID, affectedUnit.Name);
		}
	}

	public void ExportExplosionResults(Scenario theScen)
	{
		string text = "Explosion";
		string empty = string.Empty;
		bool flag = false;
		StringBuilder stringBuilder = StringBuilderCache.Allocate();
		if (unit_0 != null)
		{
			text = unit_0.Name + "'s explosion";
		}
		string text2 = "";
		string text3 = "";
		Module_Unit.Unit unit = unit_0;
		if (unit != null)
		{
			EndgameReport endgameReport = unit.EndgameReport;
			if (endgameReport != null && endgameReport.AnyMessageReportedAsHit)
			{
				text2 = "other ";
				text3 = "also ";
			}
		}
		if (dictionary_0.Count == 1)
		{
			string text4 = dictionary_0.Values.First();
			empty = "The explosion " + text3 + "affected " + text4;
			_ = text + " Hit";
			flag = true;
		}
		else if (dictionary_0.Count <= 0)
		{
			empty = "No " + text2 + "units affected by explosion";
			_ = text + " Miss";
			flag = false;
		}
		else
		{
			empty = "The explosion affected " + Conversions.ToString(dictionary_0.Count) + " " + text2 + "units";
			_ = text + " Hit";
			flag = true;
		}
		stringBuilder.Append(empty);
		if (unit_0 != null)
		{
			unit_0.EndgameReport.AddEndGameMessage(flag, empty);
			unit_0.EndgameReport.AttemptEndgameReport(theScen);
			ExportExplosionResultAsWeaponEndgame(theScen, unit_0, contact_0, flag, HitResultsInKill: false, stringBuilder);
		}
		StringBuilderCache.Free(stringBuilder);
	}

	internal float ProximityBlastArmorPenetrationPercent(GlobalVariables.ArmorRating theArmor, float theBlastYield)
	{
		short num = default(short);
		switch (theArmor)
		{
		case GlobalVariables.ArmorRating.None:
			return 100f;
		case GlobalVariables.ArmorRating.Light:
			return 90f;
		case GlobalVariables.ArmorRating.Medium:
			return 80f;
		case GlobalVariables.ArmorRating.Heavy:
			num = 60;
			break;
		case GlobalVariables.ArmorRating.Special:
			num = 30;
			break;
		}
		int num2 = GameGeneral.GlobalRNG.Next(num - 15, num + 16);
		if (num2 > 100)
		{
			return 100f;
		}
		if (num2 < 0)
		{
			return 0f;
		}
		return num2;
	}

	private void method_8(ref Scenario scenario_0, string string_5, Weapon.DetonationMedium detonationMedium_0)
	{
		float num = 1.5f;
		float num2 = 1.1f;
		try
		{
			float num3 = ((WarheadType != Warhead.WarheadType.Nuclear) ? ((float)(1.0 * ExpYield) / 1000f) : ((float)(1.0 * ExpYield) / 1000f));
			switch (detonationMedium_0)
			{
			case Weapon.DetonationMedium.Air:
				num3 = (float)((double)num3 * 0.01);
				break;
			case Weapon.DetonationMedium.Surface:
				num3 = (float)((double)num3 * 0.05);
				break;
			}
			double double_3 = default(double);
			double double_ = default(double);
			double double_2 = default(double);
			method_14(num3, ref double_, ref double_2, ref double_3, CurrentAltitude_AGL * 0.5f);
			double_ /= 1852.0;
			double_2 /= 1852.0;
			if (CurrentAltitude_AGL > 0f)
			{
				double_2 *= 0.5;
			}
			float num4 = (float)(3.0 * double_2);
			float num5 = (float)(2.0 * double_2);
			float num6 = (float)(1.5 * double_2);
			float num7 = (float)(2.5 * double_2);
			float num8 = (float)(2.0 * double_2);
			float num9 = (float)(1.25 * double_2);
			List<ActiveUnit> list = new List<ActiveUnit>(scenario_0.ActiveUnits_List);
			foreach (ActiveUnit item in list)
			{
				if (item == null || !item.IsOperating() || item.IsGroup || !item.IsFacility || Operators.CompareString(string_5, item.ObjectID, false) == 0)
				{
					continue;
				}
				float num10 = Module_Unit.RangeToUnit_Slant(this, item);
				Facility facility = (Facility)item;
				Facility._FacilityCategory category = ((Facility)item).Category;
				float float_;
				if (category != Facility._FacilityCategory.Building_Underground && category != Facility._FacilityCategory.SurfaceAndUnderground)
				{
					if (facility.Armor_General < GlobalVariables.ArmorRating.Medium)
					{
						float num11 = num10 / num;
						if (num11 > num4)
						{
							continue;
						}
						float_ = ((num4 > num11 && num11 > num5) ? ((float)(GameGeneral.GlobalRNG.NextDouble() * 0.3)) : ((!(num5 > num11) || !(num11 > num6)) ? ((float)(GameGeneral.GlobalRNG.NextDouble() * 0.8)) : ((float)(GameGeneral.GlobalRNG.NextDouble() * 0.5))));
						float_ = smethod_1(float_, facility, num11);
					}
					else
					{
						float num12 = num10 / num2;
						if (num12 > num7)
						{
							continue;
						}
						float_ = ((num7 > num12 && num12 > num8) ? ((float)(GameGeneral.GlobalRNG.NextDouble() * 0.3)) : ((!(num8 > num12) || !(num12 > num9)) ? ((float)(GameGeneral.GlobalRNG.NextDouble() * 0.8)) : ((float)(GameGeneral.GlobalRNG.NextDouble() * 0.5))));
						float_ = smethod_1(float_, facility, num12);
					}
					item.Damage.ResolveDamageFromBlast((float)item.InitialDP * float_, WarheadType, ExplosiveType, Weapon.DetonationMedium.Underground);
					MarkAffectedUnit(item);
					continue;
				}
				if (facility.Armor_General < GlobalVariables.ArmorRating.Medium)
				{
					if (num10 > num4)
					{
						continue;
					}
					float_ = ((num4 > num10 && num10 > num5) ? ((float)(GameGeneral.GlobalRNG.NextDouble() * 0.3)) : ((!(num5 > num10) || !(num10 > num6)) ? ((float)(GameGeneral.GlobalRNG.NextDouble() * 0.8)) : ((float)(GameGeneral.GlobalRNG.NextDouble() * 0.5))));
				}
				else
				{
					if (num10 > num7)
					{
						continue;
					}
					float_ = ((num7 > num10 && num10 > num8) ? ((float)(GameGeneral.GlobalRNG.NextDouble() * 0.3)) : ((!(num8 > num10) || !(num10 > num9)) ? ((float)(GameGeneral.GlobalRNG.NextDouble() * 0.8)) : ((float)(GameGeneral.GlobalRNG.NextDouble() * 0.5))));
				}
				item.Damage.ResolveDamageFromBlast((float)item.InitialDP * float_, WarheadType, ExplosiveType, Weapon.DetonationMedium.Underground);
				MarkAffectedUnit(item);
			}
			foreach (RoadSystem.Node node in scenario_0.RoadSystem.Nodes)
			{
				float num13 = Module_Unit.RangeToPoint_Horiz(this, node.Coordinates);
				if (num7 > num13)
				{
					node.ResolveDamage((float)(GameGeneral.GlobalRNG.NextDouble() * 0.6));
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100848", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static float smethod_1(float float_6, object object_0, float float_7)
	{
		double num = Math.PI * Math.Pow(float_7, 2.0);
		if (num < ((Facility)object_0).Area)
		{
			double num2 = num / ((Facility)object_0).Area;
			float_6 *= (float)num2;
		}
		return float_6;
	}

	private void method_9(ref Scenario scenario_0, string string_5)
	{
		_Closure$__87-1 closure$__87- = new _Closure$__87-1(closure$__87-);
		closure$__87-.$VB$Me = this;
		closure$__87-.$VB$Local_ExcludedUnit_ObjectID = string_5;
		try
		{
			_Closure$__87-0 arg = default(_Closure$__87-0);
			_Closure$__87-0 CS$<>8__locals26 = new _Closure$__87-0(arg);
			CS$<>8__locals26.$VB$NonLocal_$VB$Closure_2 = closure$__87-;
			if (mount_0 != null)
			{
				mount_0.Destroy(mount_0.ParentPlatform.get_UnitSide(SetSideOnly: false), ScenEditAction: false, IsAimpointFacility: true);
			}
			double double_ = default(double);
			double double_2 = default(double);
			if (Module_Unit.IsOverLand(this))
			{
				method_14(1.0 * ExpYield / 1000000.0, ref CS$<>8__locals26.$VB$Local_CraterRadius, ref double_, ref double_2, CurrentAltitude_AGL);
			}
			else
			{
				method_14(1.0 * ExpYield / 1000000.0, ref CS$<>8__locals26.$VB$Local_CraterRadius, ref double_, ref double_2, ((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
			}
			if (CS$<>8__locals26.$VB$Local_CraterRadius == 0.0)
			{
				return;
			}
			CS$<>8__locals26.$VB$Local_CraterRadius /= 1852.0;
			CS$<>8__locals26.$VB$Local_InstaKillUnits = new TList<ActiveUnit>();
			List<ActiveUnit> source = new List<ActiveUnit>(scenario_0.ActiveUnits_List);
			CS$<>8__locals26.$VB$Local_AffectedUnits_AGU = new TList<AggregateGroundUnit>();
			Parallel.ForEach(source, [SpecialName] (ActiveUnit theAU) =>
			{
				if (theAU != null && theAU.IsOperating())
				{
					if (theAU.IsAggregatedUnit)
					{
						CS$<>8__locals26.$VB$Local_AffectedUnits_AGU.Add((AggregateGroundUnit)theAU);
					}
					else if (theAU.IsFacility && Module_ActiveUnit.IsAimpointFacility(theAU))
					{
						if ((double)Module_Unit.RangeToPoint_Horiz(CS$<>8__locals26.$VB$NonLocal_$VB$Closure_2.$VB$Me, theAU.get_Latitude((GlobalVariables.BooleanObject)null), theAU.get_Longitude((GlobalVariables.BooleanObject)null)) - (double)((Facility)theAU).AimpointDispersalRadius * 0.000539957 <= CS$<>8__locals26.$VB$Local_CraterRadius)
						{
							CS$<>8__locals26.$VB$Local_InstaKillUnits.Add(theAU);
						}
					}
					else if (!theAU.IsGroup)
					{
						if ((double)Module_Unit.RangeToPoint_Slant(CS$<>8__locals26.$VB$NonLocal_$VB$Closure_2.$VB$Me, new GeoPoint(theAU.get_Longitude((GlobalVariables.BooleanObject)null), theAU.get_Latitude((GlobalVariables.BooleanObject)null), theAU.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))) > CS$<>8__locals26.$VB$Local_CraterRadius)
						{
							if (((Module_Unit.Unit)CS$<>8__locals26.$VB$NonLocal_$VB$Closure_2.$VB$Me).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < 0f && theAU.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > ((Module_Unit.Unit)CS$<>8__locals26.$VB$NonLocal_$VB$Closure_2.$VB$Me).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) && theAU.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < 2000f && (double)Module_Unit.RangeToPoint_Horiz(CS$<>8__locals26.$VB$NonLocal_$VB$Closure_2.$VB$Me, theAU.get_Latitude((GlobalVariables.BooleanObject)null), theAU.get_Longitude((GlobalVariables.BooleanObject)null)) <= CS$<>8__locals26.$VB$Local_CraterRadius * 2.0 && Operators.CompareString(CS$<>8__locals26.$VB$NonLocal_$VB$Closure_2.$VB$Local_ExcludedUnit_ObjectID, theAU.ObjectID, false) != 0)
							{
								CS$<>8__locals26.$VB$Local_InstaKillUnits.Add(theAU);
							}
						}
						else if (Operators.CompareString(CS$<>8__locals26.$VB$NonLocal_$VB$Closure_2.$VB$Local_ExcludedUnit_ObjectID, theAU.ObjectID, false) != 0)
						{
							CS$<>8__locals26.$VB$Local_InstaKillUnits.Add(theAU);
						}
					}
				}
			});
			double out_lon = default(double);
			double out_lat = default(double);
			foreach (ActiveUnit item in CS$<>8__locals26.$VB$Local_InstaKillUnits)
			{
				if (Module_ActiveUnit.IsAimpointFacility(item))
				{
					IEnumerable<Mount> enumerable = item.Mounts.Where([SpecialName] (Mount theM) => theM.Status != PlatformComponent._ComponentStatus.Destroyed && theM != mount_0 && theM != mount_1);
					foreach (Mount item2 in enumerable)
					{
						Geodesic_EdWilliams.CalcPoint_Williams(item.get_Longitude((GlobalVariables.BooleanObject)null), item.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, item2.AimpointOffset_Distance / 1852f, item2.AimpointOffset_Bearing);
						double num = Math2.CalcDist(((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), out_lat, out_lon);
						double num2 = ((Math.Abs(((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - item.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) != 0f) ? ((double)MathFunctions.SlantRange_NM_SR((float)num, Math.Abs(((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - item.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)))) : num);
						if (!(num2 > CS$<>8__locals26.$VB$Local_CraterRadius))
						{
							MarkAffectedUnit(item);
							item2.Destroy(item.get_UnitSide(SetSideOnly: false), ScenEditAction: false, IsAimpointFacility: true);
						}
					}
				}
				else
				{
					MarkAffectedUnit(item);
					scenario_0.DestroyThisUnit(item, "Engulfed in nuclear fireball.", "Weapon Interaction");
				}
			}
			foreach (AggregateGroundUnit item3 in CS$<>8__locals26.$VB$Local_AffectedUnits_AGU)
			{
				float num3 = Module_Unit.RangeToUnit_Slant(this, item3);
				double num4 = item3.InfluenceInterectionArea_Nm2(num3, item3.GetInfluenceRadius(), CS$<>8__locals26.$VB$Local_CraterRadius);
				_ = num4 / (double)item3.GetInfluenceArea_Nm2();
				if (num4 > 0.0)
				{
					item3.ResolveDamages_Proportion(AggregateGroundUnit.CreateDamageMatrix((float)CS$<>8__locals26.$VB$Local_CraterRadius, AggregateGroundUnit.DamageMatrixType.Universal), Log: true, IgnoreArmorDeflection: true);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100849", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_10(ref Scenario scenario_0, string string_5)
	{
		_Closure$__88-1 closure$__88- = new _Closure$__88-1(closure$__88-);
		closure$__88-.$VB$Me = this;
		closure$__88-.$VB$Local_ExcludedUnit_ObjectID = string_5;
		try
		{
			_Closure$__88-0 arg = default(_Closure$__88-0);
			_Closure$__88-0 CS$<>8__locals12 = new _Closure$__88-0(arg);
			CS$<>8__locals12.$VB$NonLocal_$VB$Closure_2 = closure$__88-;
			if (mount_0 != null)
			{
				mount_0.Destroy(mount_0.ParentPlatform.get_UnitSide(SetSideOnly: false), ScenEditAction: false, IsAimpointFacility: true);
			}
			if (((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < 0f || !(CurrentAltitude_AGL >= 0f))
			{
				return;
			}
			CS$<>8__locals12.$VB$Local_EffectRadius = 1.0;
			CS$<>8__locals12.$VB$Local_InstaKillUnits = new TList<ActiveUnit>();
			Parallel.ForEach(new List<ActiveUnit>(scenario_0.ActiveUnits_List), [SpecialName] (ActiveUnit theAU) =>
			{
				if (theAU != null && theAU.IsOperating() && !theAU.IsGroup && !(theAU.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < 0f) && !(theAU.CurrentAltitude_AGL < 0f))
				{
					if (!Module_ActiveUnit.IsAimpointFacility(theAU))
					{
						if ((double)Module_Unit.RangeToPoint_Slant(CS$<>8__locals12.$VB$NonLocal_$VB$Closure_2.$VB$Me, new GeoPoint(theAU.get_Longitude((GlobalVariables.BooleanObject)null), theAU.get_Latitude((GlobalVariables.BooleanObject)null), theAU.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))) <= CS$<>8__locals12.$VB$Local_EffectRadius && Operators.CompareString(CS$<>8__locals12.$VB$NonLocal_$VB$Closure_2.$VB$Local_ExcludedUnit_ObjectID, theAU.ObjectID, false) != 0)
						{
							CS$<>8__locals12.$VB$Local_InstaKillUnits.Add(theAU);
						}
					}
					else if ((double)Module_Unit.RangeToPoint_Horiz(CS$<>8__locals12.$VB$NonLocal_$VB$Closure_2.$VB$Me, theAU.get_Latitude((GlobalVariables.BooleanObject)null), theAU.get_Longitude((GlobalVariables.BooleanObject)null)) - (double)((Facility)theAU).AimpointDispersalRadius * 0.000539957 <= CS$<>8__locals12.$VB$Local_EffectRadius)
					{
						CS$<>8__locals12.$VB$Local_InstaKillUnits.Add(theAU);
					}
				}
			});
			double out_lon = default(double);
			double out_lat = default(double);
			foreach (ActiveUnit item in CS$<>8__locals12.$VB$Local_InstaKillUnits)
			{
				if (Module_ActiveUnit.IsAimpointFacility(item))
				{
					IEnumerable<Mount> enumerable = item.Mounts.Where([SpecialName] (Mount theM) => theM.Status != PlatformComponent._ComponentStatus.Destroyed && theM != mount_0 && theM != mount_1);
					foreach (Mount item2 in enumerable)
					{
						Geodesic_EdWilliams.CalcPoint_Williams(item.get_Longitude((GlobalVariables.BooleanObject)null), item.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, item2.AimpointOffset_Distance / 1852f, item2.AimpointOffset_Bearing);
						double num = Math2.CalcDist(((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), out_lat, out_lon);
						double num2 = ((Math.Abs(((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - item.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) != 0f) ? ((double)MathFunctions.SlantRange_NM_SR((float)num, Math.Abs(((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - item.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)))) : num);
						if (!(num2 > CS$<>8__locals12.$VB$Local_EffectRadius))
						{
							MarkAffectedUnit(item);
							item2.Destroy(item.get_UnitSide(SetSideOnly: false), ScenEditAction: false, IsAimpointFacility: true);
						}
					}
				}
				else
				{
					MarkAffectedUnit(item);
					scenario_0.DestroyThisUnit(item, "Utterly disabled by short-range neutron wave.", "Weapon Interaction");
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100849", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_11(Scenario scenario_0, string string_5)
	{
		_Closure$__93-1 closure$__93- = new _Closure$__93-1(closure$__93-);
		closure$__93-.$VB$Me = this;
		closure$__93-.$VB$Local_thescen = scenario_0;
		closure$__93-.$VB$Local_ExcludedUnit_ObjectID = string_5;
		try
		{
			_Closure$__93-0 arg = default(_Closure$__93-0);
			_Closure$__93-0 CS$<>8__locals17 = new _Closure$__93-0(arg);
			CS$<>8__locals17.$VB$NonLocal_$VB$Closure_2 = closure$__93-;
			CS$<>8__locals17.$VB$Local_theArea = this.get_ClusterFallBox(1f);
			CS$<>8__locals17.$VB$Local_ClusterFallboxEncirclingRadius = this.get_ClusterFallboxEncirclingRadius(1f);
			int num = ClusterCoverageLength * ClusterCoverageWidth;
			CS$<>8__locals17.$VB$Local_AffectedUnits = new TList<ActiveUnit>();
			List<ActiveUnit> source = new List<ActiveUnit>(CS$<>8__locals17.$VB$NonLocal_$VB$Closure_2.$VB$Local_thescen.ActiveUnits_List);
			CS$<>8__locals17.$VB$Local_AffectedUnits_AGU = new TList<AggregateGroundUnit>();
			Parallel.ForEach(source, [SpecialName] (ActiveUnit theAU) =>
			{
				if (!theAU.IsAggregatedUnit)
				{
					if (!Module_ActiveUnit.IsAimpointFacility(theAU))
					{
						if (!theAU.IsWeapon && !theAU.IsAircraft && !theAU.IsGroup && theAU.IsOperating() && ((Module_Unit.Unit)theAU).get_IsInsideThisArea(CS$<>8__locals17.$VB$Local_theArea, CS$<>8__locals17.$VB$NonLocal_$VB$Closure_2.$VB$Local_thescen, UseCache: false) && Operators.CompareString(CS$<>8__locals17.$VB$NonLocal_$VB$Closure_2.$VB$Local_ExcludedUnit_ObjectID, theAU.ObjectID, false) != 0)
						{
							CS$<>8__locals17.$VB$Local_AffectedUnits.Add(theAU);
						}
					}
					else if ((double)Module_Unit.RangeToPoint_Horiz(CS$<>8__locals17.$VB$NonLocal_$VB$Closure_2.$VB$Me, theAU.get_Latitude((GlobalVariables.BooleanObject)null), theAU.get_Longitude((GlobalVariables.BooleanObject)null)) * 1852.0 - (double)((Facility)theAU).AimpointDispersalRadius <= CS$<>8__locals17.$VB$Local_ClusterFallboxEncirclingRadius)
					{
						CS$<>8__locals17.$VB$Local_AffectedUnits.Add(theAU);
					}
				}
				else
				{
					CS$<>8__locals17.$VB$Local_AffectedUnits_AGU.Add((AggregateGroundUnit)theAU);
				}
			});
			double out_lon = default(double);
			double out_lat = default(double);
			foreach (ActiveUnit item in CS$<>8__locals17.$VB$Local_AffectedUnits)
			{
				if (!Module_ActiveUnit.IsAimpointFacility(item))
				{
					double num2 = Warhead.BombletDamageAtThisTarget((Platform)item, ExpYield, num, CurrentHeading);
					if (num2 > 0.0)
					{
						MarkAffectedUnit(item);
						item.Damage.ResolveDamageFromBomblets((float)num2, WarheadType, ExplosiveType, ClusterCoverageLength);
					}
					continue;
				}
				List<Mount> list = new List<Mount>();
				IEnumerable<Mount> enumerable = item.Mounts.Where([SpecialName] (Mount theM) => theM.Status != PlatformComponent._ComponentStatus.Destroyed);
				foreach (Mount item2 in enumerable)
				{
					Geodesic_EdWilliams.CalcPoint_Williams(item.get_Longitude((GlobalVariables.BooleanObject)null), item.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, (double)item2.AimpointOffset_Distance * 0.000539957, item2.AimpointOffset_Bearing);
					if (GeoPoint.IsInsideThisArea(out_lat, out_lon, CS$<>8__locals17.$VB$Local_theArea))
					{
						list.Add(item2);
					}
				}
				foreach (Mount item3 in list)
				{
					double num3 = Warhead.BombletDamageAtThisAimpoint(item3, ExpYield, ClusterSubmunitionQty, ClusterSubmunitionYield, num, WarheadType, ExplosiveType);
					if (num3 > 0.0)
					{
						MarkAffectedUnit(item);
						item3.ResolveDamageFromBomblets(num3, WarheadType, ClusterCoverageLength);
					}
				}
			}
			foreach (AggregateGroundUnit item4 in CS$<>8__locals17.$VB$Local_AffectedUnits_AGU)
			{
				float num4 = Module_Unit.RangeToUnit_Slant(this, item4);
				float num5 = (float)Math.Sqrt((double)(float)(ClusterCoverageLength * ClusterCoverageWidth) * 2.9155333398513564E-07 / Math.PI);
				double num6 = item4.InfluenceInterectionArea_Nm2(num4, item4.GetInfluenceRadius(), num5);
				double num7 = num6 / (double)item4.GetInfluenceArea_Nm2();
				if (num6 > 0.0)
				{
					item4.ResolveAGUDamages(AggregateGroundUnit.CreateDamageMatrix((float)(num7 * ExpYield), AggregateGroundUnit.DamageMatrixType.Standard), 0.1f, 10f);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100851", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static float GetCutoffRange_Blast_nm(double GroundZeroExpYield, Weapon.DetonationMedium theMedium)
	{
		double d = GroundZeroExpYield * 1.0;
		double num = Math.Exp(0.3315 * Math.Log(d) + 2.9034);
		switch (theMedium)
		{
		default:
			throw new NotImplementedException();
		case Weapon.DetonationMedium.Air:
		case Weapon.DetonationMedium.Surface:
			return (float)(num / 1852.0);
		case Weapon.DetonationMedium.Underwater:
			return (float)(num * 4.4114977307110435 / 1852.0);
		case Weapon.DetonationMedium.Underground:
			return (float)(num * 8.822995461422087 / 1852.0);
		case Weapon.DetonationMedium.Space:
			return 0f;
		}
	}

	public static float GetCutoffRange_Frag_nm(double GroundZeroExpYield, Weapon.DetonationMedium theMedium, Warhead.WarheadType theWarheadType)
	{
		switch (theMedium)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return 0f;
		case Weapon.DetonationMedium.Space:
			return (float)(10.0 * GroundZeroExpYield);
		case Weapon.DetonationMedium.Air:
		{
			if (theWarheadType != Warhead.WarheadType.Fragmentation && (uint)(theWarheadType - 2011) > 1u)
			{
				return (float)((double)(float)(10.0 * Math.Pow(GroundZeroExpYield, 1.0 / 3.0)) * 0.000539957);
			}
			double num = GroundZeroExpYield * 3.0;
			double num2 = 2.5;
			return (float)((double)(float)(num * num2) * 0.000539957);
		}
		}
	}

	private double method_12(double double_3, double double_4)
	{
		if (double_4 < 5.0 && double_4 > -3.0)
		{
			double num;
			double num2;
			double num3;
			double num4;
			double num5;
			double num6;
			if (double_4 >= 0.0)
			{
				if (double_3 <= 1.0)
				{
					num = -1.05;
					num2 = -0.105;
					num3 = 0.0573;
					num4 = -0.5;
					num5 = 16989.0;
					num6 = 5.0;
				}
				else
				{
					if (!(double_3 >= 20.0))
					{
						goto IL_0201;
					}
					num = -2.0;
					num2 = -0.3044;
					num3 = 0.0707;
					num4 = -0.9059;
					num5 = 5663.0;
					num6 = 5.0;
				}
			}
			else if (double_3 <= 1.0)
			{
				num = 0.258;
				num2 = 0.01;
				num3 = 0.1;
				num4 = 1.9;
				num5 = 16989.0;
				num6 = 5.0;
			}
			else
			{
				if (!(double_3 >= 20.0))
				{
					goto IL_0201;
				}
				num = 0.53;
				num2 = 0.028;
				num3 = -1.0 / 46.0;
				num4 = 1.74;
				num5 = 5663.0;
				num6 = 5.0;
			}
			return num5 / num6 * Math.Pow(10.0, num4 * (Math.Exp(num * double_4 + num2 * double_4 * double_4) - 1.0) + num3 * double_4);
		}
		if (double_4 >= 5.0 && double_4 <= 40.0)
		{
			double num7 = 0.131;
			double num8 = -0.00231;
			double num9 = 0.0;
			return Math.Exp(9.34 + num7 * double_4 + num8 * double_4 * double_4) - num9;
		}
		goto IL_0201;
		IL_0201:
		double result = default(double);
		return result;
	}

	private bool method_13(double double_3, double double_4)
	{
		double num = Math.Pow(double_3, 1.0 / 3.0);
		return double_4 < 3.0 * num;
	}

	private void method_14(double double_3, ref double double_4, ref double double_5, ref double double_6, double double_7 = 0.0)
	{
		try
		{
			double num = 1.0 / 3.0;
			double num2 = 0.29411764705882354;
			if (double_3 < 0.1 || !(double_3 <= 30000.0))
			{
				return;
			}
			double num3 = Math.Pow(double_3, 1.0 / 3.0);
			if (!(double_7 < -40.0 * num3) && double_7 <= 3.0 * num3)
			{
				double num4 = (0.0 - double_7) / num3;
				num = ((num4 < 0.15) ? (1.0 / 3.0) : ((!(num4 < 5.0)) ? 0.29411764705882354 : (0.2946 * Math.Exp((0.0 - num4) * Math.Log10(583.0)) / Math.Sqrt(305.0))));
				double x;
				if (double_3 < 1.0)
				{
					double num5 = num;
					double double_8 = (0.0 - double_7) / Math.Pow(double_3, num5);
					double num6 = method_12(double_3, double_8);
					x = num6 * Math.Pow(double_3, 3.0 * num5);
				}
				else if (double_3 > 20.0)
				{
					double num5 = num2;
					double double_8 = (0.0 - double_7) / Math.Pow(double_3, num5);
					double num7 = method_12(double_3, double_8);
					x = num7 * Math.Pow(double_3, 3.0 * num5);
				}
				else
				{
					double num8 = 1.0 - Math.Min(1.0, Math.Max(0.0, Math.Log(double_3) / Math.Log(20.0)));
					double num5 = 3.0 * (num2 + num8 * (num - num2));
					double num6 = method_12(1.0, 0.0 - double_7);
					double num7 = method_12(20.0, (0.0 - double_7) / Math.Pow(20.0, num5));
					x = ((num7 == 0.0) ? 0.0 : (num7 * Math.Pow(num6 / num7, num8) * Math.Pow(double_3, num5)));
				}
				double_5 = 1.2 * Math.Pow(x, 1.0 / 3.0);
				double num9 = 1.8 * double_5;
				double_4 = num9;
				double_6 = 0.5 * Math.Pow(x, 1.0 / 3.0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			double_4 = 0.0;
			double_6 = 0.0;
			ex2?.Data.Add("Error at 200041", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	~Explosion()
	{
		base.Finalize();
	}

	internal float GetCutoffRange_EMP_nm(double ExpYield)
	{
		if (((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > 12000f)
		{
			return GetCutoffRange_Blast_nm(ExpYield, Weapon.DetonationMedium.Air) * ((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) / 12000f;
		}
		return GetCutoffRange_Blast_nm(ExpYield, Weapon.DetonationMedium.Air);
	}

	private void method_15(Scenario scenario_0)
	{
		try
		{
			if (mount_0 != null)
			{
				mount_0.vmethod_0(1f);
			}
			float cutoffRange_EMP_nm = GetCutoffRange_EMP_nm(ExpYield);
			TList<ActiveUnit> tList = new TList<ActiveUnit>();
			List<ActiveUnit> list = new List<ActiveUnit>(scenario_0.ActiveUnits_List);
			foreach (ActiveUnit item in list)
			{
				if (item == null || (!item.IsOperating() && (!item.HasSystemsRunning || !item.IsHostedInExposedSpace())))
				{
					continue;
				}
				if (!Module_ActiveUnit.IsAimpointFacility(item))
				{
					if (!item.IsGroup && !item.IsWeapon && (!item.IsFacility || (((Facility)item).Category != Facility._FacilityCategory.Building_Underground && ((Facility)item).Category != Facility._FacilityCategory.SurfaceAndUnderground)) && !(item.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < 0f) && Module_Unit.RangeToUnit_Slant(this, item) < cutoffRange_EMP_nm)
					{
						tList.Add(item);
					}
				}
				else if ((double)Module_Unit.RangeToPoint_Horiz(this, item.get_Latitude((GlobalVariables.BooleanObject)null), item.get_Longitude((GlobalVariables.BooleanObject)null)) - (double)((Facility)item).AimpointDispersalRadius * 0.000539957 <= (double)cutoffRange_EMP_nm)
				{
					tList.Add(item);
				}
			}
			double out_lon = default(double);
			double out_lat = default(double);
			foreach (ActiveUnit item2 in tList)
			{
				if (Module_ActiveUnit.IsAimpointFacility(item2))
				{
					bool flag = false;
					IEnumerable<Mount> enumerable = item2.Mounts.Where([SpecialName] (Mount theM) => theM.Status != PlatformComponent._ComponentStatus.Destroyed && theM != mount_0 && theM != mount_1);
					foreach (Mount item3 in enumerable)
					{
						Geodesic_EdWilliams.CalcPoint_Williams(item2.get_Longitude((GlobalVariables.BooleanObject)null), item2.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, item3.AimpointOffset_Distance / 1852f, item3.AimpointOffset_Bearing);
						double num = Math2.CalcDist(((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), out_lat, out_lon);
						double num2 = ((Math.Abs(((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - item2.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) != 0f) ? ((double)MathFunctions.SlantRange_NM_SR((float)num, Math.Abs(((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - item2.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)))) : num);
						if (num2 > (double)cutoffRange_EMP_nm)
						{
							continue;
						}
						float num3 = (float)Math.Pow(1f - Module_Unit.RangeToUnit_Slant(this, item2) / cutoffRange_EMP_nm, 2.0);
						if (num3 > 0f)
						{
							if (!flag && (item3.Sensors_ReadOnly.Count() > 0 || item3.CommDevices.Count() > 0))
							{
								item2.Damage.ReportEMPAttack();
								flag = true;
							}
							item3.vmethod_0(num3);
							MarkAffectedUnit(item2);
						}
					}
				}
				else
				{
					float horizDistance_NM = Math2.CalcDist(((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), item2.get_Latitude((GlobalVariables.BooleanObject)null), item2.get_Longitude((GlobalVariables.BooleanObject)null));
					if (Math.Abs(((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - item2.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) != 0f)
					{
						MathFunctions.SlantRange_NM_SR(horizDistance_NM, Math.Abs(((Module_Unit.Unit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - item2.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)));
					}
					if (Module_Unit.Has_Radar_LOS_ToUnit(this, null, item2, ref scenario_0))
					{
						float pulseStrengthRatio = (float)Math.Pow(1f - Module_Unit.RangeToUnit_Slant(this, item2) / cutoffRange_EMP_nm, 2.0);
						item2.Damage.method_5(pulseStrengthRatio);
						MarkAffectedUnit(item2);
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 192758436", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void ExportExplosionEvent(Explosion theExpl, Scenario theScen)
	{
		IEventExporter[] applicableEventExporters = theScen.ApplicableEventExporters;
		foreach (IEventExporter eventExporter in applicableEventExporters)
		{
			if (eventExporter.IsOperating && eventExporter.ExportExplosions)
			{
				PooledDictionary<string, IEventExporter.EventNotificationParameter> pooledDictionary = new PooledDictionary<string, IEventExporter.EventNotificationParameter>(30, ClearMode.Always);
				if (theScen.MonteCarloIteration > 0)
				{
					pooledDictionary.Add("Scenario", new IEventExporter.EventNotificationParameter(theScen.Title, typeof(string), 500));
					pooledDictionary.Add("MC_Run", new IEventExporter.EventNotificationParameter(theScen.MonteCarloIteration, typeof(int)));
				}
				pooledDictionary.Add("TimelineID", new IEventExporter.EventNotificationParameter(theScen.TimelineID, typeof(string), 40));
				if (!eventExporter.UseZeroHour)
				{
					pooledDictionary.Add("Time", new IEventExporter.EventNotificationParameter(theScen.Time.ToString("MM/dd/yyyy HH:mm:ss") + "." + theScen.Time.Millisecond.ToString("D3"), typeof(DateTime)));
				}
				else
				{
					pooledDictionary.Add("Time", new IEventExporter.EventNotificationParameter(theScen.Time.Subtract(theScen.ZeroHour).ToString("c"), typeof(TimeSpan), 30));
				}
				pooledDictionary.Add("ExplosionID", new IEventExporter.EventNotificationParameter(theExpl.ObjectID, typeof(string), 40));
				pooledDictionary.Add("ExplosionType", new IEventExporter.EventNotificationParameter((int)theExpl.WarheadType, typeof(int)));
				pooledDictionary.Add("Longitude", new IEventExporter.EventNotificationParameter(Conversions.ToString(((Module_Unit.Unit)theExpl).get_Longitude((GlobalVariables.BooleanObject)null)), typeof(double)));
				pooledDictionary.Add("Latitude", new IEventExporter.EventNotificationParameter(Conversions.ToString(((Module_Unit.Unit)theExpl).get_Latitude((GlobalVariables.BooleanObject)null)), typeof(double)));
				pooledDictionary.Add("Altitude", new IEventExporter.EventNotificationParameter(Conversions.ToString(((Module_Unit.Unit)theExpl).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)), typeof(float)));
				pooledDictionary.Add("EventType", new IEventExporter.EventNotificationParameter("Explosion", typeof(string), 40));
				eventExporter.ExportEvent(IEventExporter.ExportedEventType.Explosion, pooledDictionary, theScen);
			}
		}
		ISimConnector[] activeSimConnectors = SimConnect_General.ActiveSimConnectors;
		for (int j = 0; j < activeSimConnectors.Length; j = checked(j + 1))
		{
			_ = activeSimConnectors[j].ExportWeaponImpactOrDetonation;
		}
	}

	public void ExportExplosionResultAsWeaponEndgame(Scenario theScen, Module_Unit.Unit explodingUnit, Module_Unit.Unit thePrimaryTarget, bool ImpactWillOccur, bool HitResultsInKill, StringBuilder AttackMessage)
	{
		try
		{
			if (theScen == null)
			{
				return;
			}
			IEventExporter[] array = theScen?.ApplicableEventExporters;
			foreach (IEventExporter eventExporter in array)
			{
				if (!eventExporter.IsOperating || !eventExporter.ExportWeaponEndgame)
				{
					continue;
				}
				PooledDictionary<string, IEventExporter.EventNotificationParameter> pooledDictionary = new PooledDictionary<string, IEventExporter.EventNotificationParameter>(30, ClearMode.Always);
				if (theScen.MonteCarloIteration > 0)
				{
					pooledDictionary.Add("Scenario", new IEventExporter.EventNotificationParameter(theScen.Title, typeof(string), 500));
					pooledDictionary.Add("MC_Run", new IEventExporter.EventNotificationParameter(theScen.MonteCarloIteration, typeof(int)));
				}
				pooledDictionary.Add("TimelineID", new IEventExporter.EventNotificationParameter(theScen.TimelineID, typeof(string), 40));
				if (!eventExporter.UseZeroHour)
				{
					pooledDictionary.Add("Time", new IEventExporter.EventNotificationParameter(theScen.Time.ToString("MM/dd/yyyy HH:mm:ss") + "." + theScen.Time.Millisecond.ToString("D3"), typeof(DateTime)));
				}
				else
				{
					pooledDictionary.Add("Time", new IEventExporter.EventNotificationParameter(theScen.Time.Subtract(theScen.ZeroHour).ToString("c"), typeof(TimeSpan), 30));
				}
				pooledDictionary.Add("WeaponID", new IEventExporter.EventNotificationParameter(explodingUnit.ObjectID, typeof(string), 40));
				pooledDictionary.Add("WeaponName", new IEventExporter.EventNotificationParameter(explodingUnit.Name, typeof(string), 500));
				pooledDictionary.Add("WeaponSide", new IEventExporter.EventNotificationParameter(explodingUnit.get_UnitSide(SetSideOnly: false).Name, typeof(string), 500));
				if (explodingUnit == null)
				{
					pooledDictionary.Add("ParentFiringUnitID", new IEventExporter.EventNotificationParameter("-", typeof(string), 40));
					pooledDictionary.Add("ParentFiringUnitName", new IEventExporter.EventNotificationParameter("-", typeof(string), 500));
				}
				else
				{
					pooledDictionary.Add("ParentFiringUnitID", new IEventExporter.EventNotificationParameter(explodingUnit.ObjectID, typeof(string), 40));
					pooledDictionary.Add("ParentFiringUnitName", new IEventExporter.EventNotificationParameter(explodingUnit.Name, typeof(string), 500));
				}
				if (thePrimaryTarget != null)
				{
					pooledDictionary.Add("TargetID", new IEventExporter.EventNotificationParameter(thePrimaryTarget.ObjectID, typeof(string), 40));
					pooledDictionary.Add("TargetName", new IEventExporter.EventNotificationParameter(thePrimaryTarget.Name, typeof(string), 500));
					if (!Information.IsNothing((object)thePrimaryTarget.get_UnitSide(SetSideOnly: false)))
					{
						pooledDictionary.Add("TargetSide", new IEventExporter.EventNotificationParameter(thePrimaryTarget.get_UnitSide(SetSideOnly: false).Name, typeof(string), 500));
					}
					else
					{
						pooledDictionary.Add("TargetSide", new IEventExporter.EventNotificationParameter("-", typeof(string), 500));
					}
					pooledDictionary.Add("TargetLongitude", new IEventExporter.EventNotificationParameter(thePrimaryTarget.get_Longitude((GlobalVariables.BooleanObject)null), typeof(double)));
					pooledDictionary.Add("TargetLatitude", new IEventExporter.EventNotificationParameter(thePrimaryTarget.get_Latitude((GlobalVariables.BooleanObject)null), typeof(double)));
					pooledDictionary.Add("TargetAltitude_ASL_m", new IEventExporter.EventNotificationParameter(thePrimaryTarget.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), typeof(float)));
					pooledDictionary.Add("TargetAltitude_AGL_m", new IEventExporter.EventNotificationParameter(thePrimaryTarget.CurrentAltitude_AGL, typeof(float)));
				}
				else
				{
					pooledDictionary.Add("TargetID", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string)));
					pooledDictionary.Add("TargetName", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string)));
					pooledDictionary.Add("TargetSide", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string)));
					pooledDictionary.Add("TargetLongitude", new IEventExporter.EventNotificationParameter(string.Empty, typeof(double)));
					pooledDictionary.Add("TargetLatitude", new IEventExporter.EventNotificationParameter(string.Empty, typeof(double)));
					pooledDictionary.Add("TargetAltitude_ASL_m", new IEventExporter.EventNotificationParameter(string.Empty, typeof(float)));
					pooledDictionary.Add("TargetAltitude_AGL_m", new IEventExporter.EventNotificationParameter(string.Empty, typeof(float)));
				}
				pooledDictionary.Add("DistanceFromFiringUnit_Horiz", new IEventExporter.EventNotificationParameter(Conversions.ToString(Interaction.IIf(explodingUnit != null, (object)RangeToUnit_Horiz(explodingUnit), (object)"")), typeof(float)));
				if (ImpactWillOccur)
				{
					if (!HitResultsInKill)
					{
						pooledDictionary.Add("Result", new IEventExporter.EventNotificationParameter("HIT", typeof(string), 10));
					}
					else
					{
						pooledDictionary.Add("Result", new IEventExporter.EventNotificationParameter("KILL", typeof(string), 10));
					}
				}
				else
				{
					pooledDictionary.Add("Result", new IEventExporter.EventNotificationParameter("MISS", typeof(string), 10));
				}
				if (Information.IsNothing((object)AttackMessage))
				{
					pooledDictionary.Add("EndgameMessage", new IEventExporter.EventNotificationParameter("-", typeof(string)));
				}
				else
				{
					pooledDictionary.Add("EndgameMessage", new IEventExporter.EventNotificationParameter(Strings.Trim(AttackMessage.ToString()), typeof(string)));
				}
				eventExporter.ExportEvent(IEventExporter.ExportedEventType.WeaponEndgame, pooledDictionary, theScen);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101329", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ProgressTime(float elapsedTime)
	{
		double_0 += elapsedTime;
		if (double_0 > (double)MaxDuration)
		{
			double_0 = MaxDuration;
		}
	}

	static Explosion()
	{
		Class72.smethod_20();
	}
}
