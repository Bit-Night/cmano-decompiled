using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Xml;
using Command_Core.DAL;
using Command_Core.Mercator_OSM;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class AggregateGroundUnit : ActiveUnit, IAGUInteractable, IMobileGroundUnit
{
	public struct Corridor
	{
		public int StartAngle;

		public int EndAngle;

		public float MeanThreat;

		public int Width;

		public Corridor(int startA, int endA, float meanT, int w)
		{
			this = default(Corridor);
			StartAngle = startA;
			EndAngle = endA;
			MeanThreat = meanT;
			Width = w;
		}

		static Corridor()
		{
			Class72.smethod_20();
		}
	}

	public class AGU_Round
	{
		public struct AGUValueDelta
		{
			public float HP;

			public float Suppression;

			public float Morale;

			public AGUValueDelta(float _HP, float _Suppression, float _Morale)
			{
				this = default(AGUValueDelta);
				HP = _HP;
				Suppression = _Suppression;
				Morale = _Morale;
			}

			public AGUValueDelta(AggregateGroundUnit AGU)
				: this(AGU.GetHitPoints(), AGU.Suppression, AGU.CurrentMorale)
			{
			}

			static AGUValueDelta()
			{
				Class72.smethod_20();
			}
		}

		public DateTime Time;

		public AggregateGroundUnit Defender;

		public float[] DamageDealt;

		public float[] Defense;

		public float DamageModifier;

		public bool IgnoreArmorDeflection;

		public bool IgnoreCoverDeflection;

		public float CombatAgility;

		public float DefenderCover;

		public float AttackDirection_FacingRatio;

		public AGUValueDelta InitialDefenderState;

		public AGUValueDelta AfterCombatDefenderState;

		public DamageResolutioMethod TargetingType;

		public List<AGU_Round_Combat> Combatrounds;

		public float DefenderEffectiveCover;

		private int int_0;

		private Random random_0;

		private StringBuilder stringBuilder_0;

		public Random random
		{
			get
			{
				if (random_0 == null)
				{
					random_0 = new Random(int_0);
				}
				return random_0;
			}
		}

		public void ResetValues()
		{
			Time = DateTime.MinValue;
			Defender = null;
			DamageDealt = new float[0];
			Defense = new float[0];
			DamageModifier = 0f;
			IgnoreArmorDeflection = false;
			IgnoreCoverDeflection = false;
			CombatAgility = 0f;
			DefenderCover = 0f;
			AttackDirection_FacingRatio = 0f;
			InitialDefenderState = default(AGUValueDelta);
			AfterCombatDefenderState = default(AGUValueDelta);
			TargetingType = DamageResolutioMethod.Standard;
			Combatrounds.Clear();
			random_0 = null;
			int_0 = 0;
		}

		public AGU_Round(Scenario Scen, AggregateGroundUnit _defender, float[] _damageDealt, float[] _defense, float _damageModifier, bool _ignoreArmorDeflection, bool _ignoreCoverDeflection, float _combatAgility, float _DefenderCover, float _attackDirection_FacingRatio, DamageResolutioMethod _TargetingType, int _randomSeed = -1)
		{
			InitialDefenderState = default(AGUValueDelta);
			AfterCombatDefenderState = default(AGUValueDelta);
			Combatrounds = new List<AGU_Round_Combat>();
			random_0 = null;
			stringBuilder_0 = new StringBuilder();
			Initialise(Scen, _defender, _damageDealt, _defense, _damageModifier, _ignoreArmorDeflection, _ignoreCoverDeflection, _combatAgility, _DefenderCover, _attackDirection_FacingRatio, _TargetingType, _randomSeed);
		}

		public void Initialise(Scenario Scen, AggregateGroundUnit _defender, float[] _damageDealt, float[] _defense, float _damageModifier, bool _ignoreArmorDeflection, bool _ignoreCoverDeflection, float _combatAgility, float _DefenderCover, float _attackDirection_FacingRatio, DamageResolutioMethod _TargetingType, int _randomSeed = -1)
		{
			random_0 = null;
			Time = Scen.Time;
			Defender = _defender;
			DamageDealt = _damageDealt;
			Defense = _defense;
			DamageModifier = _damageModifier;
			IgnoreArmorDeflection = _ignoreArmorDeflection;
			IgnoreCoverDeflection = _ignoreCoverDeflection;
			CombatAgility = _combatAgility;
			DefenderCover = _DefenderCover;
			AttackDirection_FacingRatio = _attackDirection_FacingRatio;
			InitialDefenderState = new AGUValueDelta(Defender);
			AfterCombatDefenderState = default(AGUValueDelta);
			TargetingType = _TargetingType;
			if (Combatrounds == null)
			{
				Combatrounds = new List<AGU_Round_Combat>();
			}
			else
			{
				Combatrounds.Clear();
			}
			if (_randomSeed == -1)
			{
				int_0 = Guid.NewGuid().GetHashCode();
			}
			else
			{
				int_0 = _randomSeed;
			}
		}

		public void Resolve()
		{
			Dictionary<string, int>[] array = new Dictionary<string, int>[Defense.Length - 1 + 1];
			int num = array.Length - 1;
			for (int i = 0; i <= num; i++)
			{
				array[i] = new Dictionary<string, int>();
			}
			float[] array2 = new float[Enum.GetValues(typeof(CombatPowerType)).Length - 1 + 1];
			if (TargetingType == DamageResolutioMethod.Standard)
			{
				foreach (KeyValuePair<string, (ActiveUnit, int)> item in Defender.dictionary_2)
				{
					Defender.method_27(item.Value.Item1, array2);
					int num2 = array2.Length - 1;
					for (int j = 0; j <= num2; j++)
					{
						if (item.Value.Item2 > 0 && array2[j] > 0f)
						{
							array[j].Add(item.Key, (int)Math.Round(array2[j] * 1000f * (float)item.Value.Item2));
						}
					}
				}
			}
			else if (TargetingType == DamageResolutioMethod.FixedArmorType)
			{
				float[] float_ = new float[Enum.GetValues(typeof(CombatPowerType)).Length - 1 + 1];
				foreach (KeyValuePair<string, (ActiveUnit, int)> item2 in Defender.dictionary_2)
				{
					array[(int)Defender.method_28(item2.Value.Item1, float_)].Add(item2.Key, 100);
				}
			}
			DefenderEffectiveCover = DefenderCover * (1f - AGU_CONFIG.Instance.DirectionalModifier_Defense + AttackDirection_FacingRatio * AGU_CONFIG.Instance.DirectionalModifier_Defense);
			if (IgnoreCoverDeflection)
			{
				DefenderEffectiveCover = 0f;
			}
			int num3 = DamageDealt.Length - 1;
			for (int k = 0; k <= num3; k++)
			{
				float damage = GetDamage((CombatPowerType)k);
				Dictionary<string, int> dictionary = array[k];
				if (!(damage > 0f))
				{
					continue;
				}
				float num4 = damage;
				while (dictionary.Count > 0 && !(num4 <= 0f))
				{
					string text = Helper.PickRandomElement(dictionary);
					if (text == null)
					{
						break;
					}
					float damageToDeal = Math.Min(num4, damage * 0.1f);
					AGU_Round_Combat aGU_Round_Combat = new AGU_Round_Combat(text, Defender, this, damageToDeal);
					num4 -= aGU_Round_Combat.Resolve();
					Combatrounds.Add(aGU_Round_Combat);
					if (Defender.dictionary_2[text].Item2 <= 0)
					{
						dictionary.Remove(text);
					}
				}
			}
			if (AGU_CONFIG.Instance.Logging)
			{
				Defender.ComputeMorale();
				AfterCombatDefenderState = new AGUValueDelta(Defender.GetHitPoints(), Defender.Suppression, Defender.CurrentMorale);
			}
		}

		public float GetDamage(CombatPowerType CombatPowerType)
		{
			float num = DamageDealt[(int)CombatPowerType] * DamageModifier;
			if (!IgnoreArmorDeflection)
			{
				num *= 1f - Defense[(int)CombatPowerType];
			}
			return num;
		}

		public override string ToString()
		{
			stringBuilder_0.Clear();
			stringBuilder_0.AppendLine("=== COMBAT RESOLUTION ===");
			stringBuilder_0.AppendLine("Combat resolved in " + Combatrounds.Count + " rounds");
			float num = 0f;
			if (InitialDefenderState.HP > 0f)
			{
				num = (InitialDefenderState.HP - AfterCombatDefenderState.HP) / InitialDefenderState.HP * 100f;
			}
			stringBuilder_0.AppendLine("Defender has suffered " + num.ToString("0.0") + "% in attrition");
			stringBuilder_0.AppendLine("Which is a total of " + (InitialDefenderState.HP - AfterCombatDefenderState.HP) + " hitpoints");
			float num2 = 0f;
			if (InitialDefenderState.Suppression > 0f)
			{
				num2 = (InitialDefenderState.Suppression - AfterCombatDefenderState.Suppression) / InitialDefenderState.Suppression * 100f;
			}
			stringBuilder_0.AppendLine("Defender suffered " + num2.ToString("0.0") + "% in suppression");
			float num3 = 0f;
			if (InitialDefenderState.Morale > 0f)
			{
				num3 = (InitialDefenderState.Morale - AfterCombatDefenderState.Morale) / InitialDefenderState.Morale * 100f;
			}
			stringBuilder_0.AppendLine("Defender suffered " + num3.ToString("0.0") + "% in morale reduction");
			stringBuilder_0.AppendLine("");
			if (Combatrounds.Count > 0)
			{
				int num4 = Combatrounds.Count - 1;
				for (int i = 0; i <= num4; i++)
				{
					stringBuilder_0.Append(Combatrounds[i].ToString());
				}
			}
			return stringBuilder_0.ToString();
		}

		static AGU_Round()
		{
			Class72.smethod_20();
		}
	}

	public class AGU_Round_Combat
	{
		public int Index;

		public AGU_Round ParentRound;

		public AggregateGroundUnit Target;

		public string TargetUnit;

		public float TargetHP;

		private float float_0;

		private float float_1;

		private float float_2;

		private float float_3;

		private float float_4;

		private ActiveUnit activeUnit_0;

		private bool bool_0;

		private StringBuilder stringBuilder_0;

		public AGU_Round_Combat(string _TargetUnit, AggregateGroundUnit _Target, AGU_Round _ParentRound, float _DamageToDeal)
		{
			stringBuilder_0 = new StringBuilder();
			Index = _ParentRound.Combatrounds.Count + 1;
			Target = _Target;
			float_4 = _DamageToDeal;
			TargetUnit = _TargetUnit;
			TargetHP = Target.GetUnitHitPoint(TargetUnit);
			ParentRound = _ParentRound;
			activeUnit_0 = _Target.dictionary_2[TargetUnit].Item1;
			float_2 = ParentRound.CombatAgility * float_4;
			float_3 = float_4 - float_2;
			float_0 = Math.Min(TargetHP * ParentRound.DefenderEffectiveCover, float_2 * ParentRound.DefenderEffectiveCover + float_3 * AGU_CONFIG.Instance.SuppressionFactor_IndirectFire);
			float_1 = float_2 * (1f - ParentRound.DefenderEffectiveCover);
		}

		public float Resolve()
		{
			ParentRound.Defender.Suppression += float_0 / ParentRound.InitialDefenderState.HP * AGU_CONFIG.Instance.SuppressionFactor;
			if (TargetHP > float_1)
			{
				if (ParentRound.random.NextDouble() < (double)(float_1 / TargetHP))
				{
					ParentRound.Defender.AddOrRemoveActualRoster(TargetUnit, -1, AutomaticallyAlignAssignedRoster: false, AllowDestructionWhenDepleted: true, UI_Bark: true, LogAsAARLoss: true);
					bool_0 = true;
				}
			}
			else
			{
				ParentRound.Defender.AddOrRemoveActualRoster(TargetUnit, -1, AutomaticallyAlignAssignedRoster: false, AllowDestructionWhenDepleted: true, UI_Bark: true, LogAsAARLoss: true);
				bool_0 = true;
			}
			return TargetHP;
		}

		public override string ToString()
		{
			stringBuilder_0.Clear();
			stringBuilder_0.AppendLine("=== COMBAT ROUND #" + Index + "===");
			stringBuilder_0.AppendLine("Target picked: " + DBFunctions.GetActiveUnitName(activeUnit_0.UnitType, activeUnit_0.DBID, ParentRound.Defender.ParentScen.DBConnection) + " (HP: " + TargetHP + ")");
			stringBuilder_0.AppendLine("The target was randomly chosen (weighted) based on its armor rating and firepower correlation.");
			stringBuilder_0.AppendLine();
			stringBuilder_0.AppendLine("--- Firepower Calculation ---");
			stringBuilder_0.AppendLine("Direct Firepower: " + float_2.ToString("0.00") + " (from agility rating: " + (ParentRound.CombatAgility * 100f).ToString("0.00") + "%, modified by remaining damage: " + float_4.ToString("0.00") + ")");
			stringBuilder_0.AppendLine("Indirect Firepower: " + float_3.ToString("0.00") + " (firepower not contributing directly to target damage)");
			stringBuilder_0.AppendLine();
			stringBuilder_0.AppendLine("--- Cover & Suppression ---");
			stringBuilder_0.AppendLine("Effective Cover: " + ParentRound.DefenderEffectiveCover.ToString("0.00"));
			stringBuilder_0.AppendLine("Deflected by Cover: " + float_0.ToString("0.00") + " (direct firepower adjusted by cover) + (indirect fire modified by suppression factor)");
			float num = float_0 / ParentRound.InitialDefenderState.HP * AGU_CONFIG.Instance.SuppressionFactor;
			stringBuilder_0.AppendLine("Suppression increased by: " + num.ToString("0.00"));
			stringBuilder_0.AppendLine();
			stringBuilder_0.AppendLine("--- Damage Resolution ---");
			stringBuilder_0.AppendLine("Roster unit took " + float_1.ToString("0.00") + " virtual damage (direct firepower adjusted by cover)");
			if (TargetHP <= float_1)
			{
				stringBuilder_0.AppendLine("Unit HP was lower than the damage: It was destroyed outright.");
			}
			else
			{
				float num2 = float_1 / TargetHP * 100f;
				stringBuilder_0.AppendLine("Target HP is greater than incoming damage. Probability to destroy: " + num2.ToString("0.00") + "%");
				if (bool_0)
				{
					stringBuilder_0.AppendLine("Probability check succeeded: Unit was destroyed.");
				}
				else
				{
					stringBuilder_0.AppendLine("Probability check failed: Unit survived.");
				}
			}
			return stringBuilder_0.ToString();
		}

		static AGU_Round_Combat()
		{
			Class72.smethod_20();
		}
	}

	public enum DamageResolutioMethod
	{
		Standard,
		FixedArmorType
	}

	public enum DamageMatrixType
	{
		Standard,
		Universal,
		Penetrating_Light,
		Penetrating_Heavy
	}

	public enum GroundEchelonLevel : short
	{
		Undefined = 0,
		Squad = 5,
		Section = 10,
		Platoon = 15,
		Company = 20,
		Battalion = 25,
		Regiment = 30,
		Brigade = 35,
		Division = 40,
		Corps = 45,
		Army = 50,
		ArmyGroup = 55
	}

	public enum ProfileType
	{
		Human,
		Vehicle
	}

	private AggregateGroundUnit_AI aggregateGroundUnit_AI_0;

	public int DataID;

	private GroundEchelonLevel groundEchelonLevel_0;

	private Dictionary<string, int> dictionary_0;

	private Dictionary<string, int> dictionary_1;

	private Dictionary<string, (ActiveUnit, int)> dictionary_2;

	public float _FrictionModifier;

	private AGU_Tactic agu_Tactic_0;

	public Dictionary<string, int> Losses;

	public bool ComputeCachedValues_Dirty;

	private AggregateGroundUnit_Kinematics aggregateGroundUnit_Kinematics_0;

	public float _Suppression;

	public float _Encirclement;

	private string string_4;

	public float[] AngleMask_HostileFriction;

	public float[] AngleMask_FrontLine;

	public float[] AngleMask_Mobility;

	public Dictionary<AggregateGroundUnit, float> Frictions;

	private float float_8;

	public Dictionary<AggregateGroundUnit, float> HostileFrictionProportion;

	public HashSet<IAGUInteractable> EntityUnitEngagments;

	public HashSet<IAGUInteractable> EntityUnitFriction_NonHostile;

	public HashSet<IAGUInteractable> EntityUnitEngagments_Air;

	public AggregateTerrain CurrentTerrain;

	public float _CurrentCoverRating;

	public float CurrentAgilityRating;

	private float float_9;

	public Random random;

	public float CurrentMorale;

	public float InfluenceRadius;

	public float AntiAirRadius;

	private AggregateGroundUnit_Navigator aggregateGroundUnit_Navigator_0;

	private AggregateGroundUnit_Damage aggregateGroundUnit_Damage_0;

	public readonly LockObject _frictionsLock;

	private List<(float, float, float)> list_2;

	public AGU_Round GC_LastCombatRound;

	private float[] float_10;

	private float[] float_11;

	[ThreadStatic]
	private static StringBuilder stringBuilder_0;

	public new virtual AggregateGroundUnit_AI AI => aggregateGroundUnit_AI_0;

	public GroundEchelonLevel Echelon
	{
		get
		{
			return groundEchelonLevel_0;
		}
		set
		{
			groundEchelonLevel_0 = value;
			ComputeCachedValues_Dirty = true;
		}
	}

	public AGU_Tactic CurrentTactic
	{
		get
		{
			if (agu_Tactic_0 == null)
			{
				agu_Tactic_0 = new AGU_Tactic(AGU_Tactic.DefaultTactic);
			}
			return agu_Tactic_0;
		}
		set
		{
			if (agu_Tactic_0 != null)
			{
				float currentAreaOfInfluence = agu_Tactic_0.CurrentAreaOfInfluence;
				agu_Tactic_0 = value;
				agu_Tactic_0.CurrentAreaOfInfluence = currentAreaOfInfluence;
			}
			else
			{
				agu_Tactic_0 = value;
			}
			ComputeCachedValues_Dirty = true;
		}
	}

	public new AggregateGroundUnit_Damage Damage
	{
		get
		{
			if (aggregateGroundUnit_Damage_0 == null)
			{
				ActiveUnit theUnit = this;
				aggregateGroundUnit_Damage_0 = new AggregateGroundUnit_Damage(ref theUnit);
			}
			return aggregateGroundUnit_Damage_0;
		}
	}

	public float FrictionModifier
	{
		get
		{
			float frictionModifier = _FrictionModifier;
			frictionModifier *= CurrentTactic.FrictionModifier;
			AGU_Integrity integrity = CurrentTactic.Integrity;
			if (integrity == AGU_Integrity.OccupySpace)
			{
				frictionModifier *= 1f - Damage.DamagePercent * 0.01f * 0.8f;
			}
			return frictionModifier;
		}
		set
		{
			_FrictionModifier = value;
		}
	}

	public new AggregateGroundUnit_Navigator Navigator => aggregateGroundUnit_Navigator_0;

	public AggregateGroundUnit HQ
	{
		get
		{
			if (!string.IsNullOrEmpty(string_4))
			{
				if (ParentScen.ActiveUnits.ContainsKey(string_4))
				{
					return (AggregateGroundUnit)ParentScen.ActiveUnits[string_4];
				}
				return null;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				string_4 = null;
			}
			else
			{
				string_4 = value.ObjectID;
			}
		}
	}

	public IMobileGroundUnit._MobileUnitCategory MobileUnitCategory { get; set; }

	public float TotalFriction
	{
		get
		{
			return float_8;
		}
		set
		{
			float_8 = Math.Min(Math.Max(value, 0f), 1f);
		}
	}

	public float CurrentCoverRating
	{
		get
		{
			return _CurrentCoverRating;
		}
		set
		{
			_CurrentCoverRating = Math.Min(Math.Max(value, 0f), 1f);
		}
	}

	public float Suppression
	{
		get
		{
			return _Suppression;
		}
		set
		{
			_Suppression = Math.Min(Math.Max(value, 0f), 1f);
		}
	}

	public new AggregateGroundUnit_Kinematics Kinematics
	{
		get
		{
			if (Information.IsNothing((object)aggregateGroundUnit_Kinematics_0))
			{
				ActiveUnit theUnit = this;
				aggregateGroundUnit_Kinematics_0 = new AggregateGroundUnit_Kinematics(ref theUnit);
			}
			return aggregateGroundUnit_Kinematics_0;
		}
	}

	public override Throttle MaxPossibleThrottleSetting
	{
		get
		{
			if (base.IsFixedFacility)
			{
				return Throttle.FullStop;
			}
			return Throttle.Flank;
		}
	}

	public GlobalVariables.ArmorRating Armor_General
	{
		get
		{
			return GetMostCommonArmorRating();
		}
		set
		{
		}
	}

	public AggregateGroundUnit(Scenario Scen)
		: base(Scen)
	{
		ActiveUnit theUnit = this;
		aggregateGroundUnit_AI_0 = new AggregateGroundUnit_AI(ref theUnit);
		dictionary_0 = new Dictionary<string, int>();
		dictionary_1 = new Dictionary<string, int>();
		dictionary_2 = new Dictionary<string, (ActiveUnit, int)>();
		_FrictionModifier = 1f;
		Losses = new Dictionary<string, int>();
		ComputeCachedValues_Dirty = true;
		AngleMask_HostileFriction = new float[361];
		AngleMask_FrontLine = new float[361];
		AngleMask_Mobility = new float[361];
		Frictions = new Dictionary<AggregateGroundUnit, float>();
		HostileFrictionProportion = new Dictionary<AggregateGroundUnit, float>();
		EntityUnitEngagments = new HashSet<IAGUInteractable>();
		EntityUnitFriction_NonHostile = new HashSet<IAGUInteractable>();
		EntityUnitEngagments_Air = new HashSet<IAGUInteractable>();
		CurrentTerrain = new AggregateTerrain();
		float_9 = 0f;
		theUnit = this;
		aggregateGroundUnit_Navigator_0 = new AggregateGroundUnit_Navigator(ref theUnit);
		_frictionsLock = new LockObject();
		list_2 = new List<(float, float, float)>();
		ParentScen = Scen;
		IsMobileGroundUnit = true;
		IsAggregatedUnit = true;
		UnitType = GlobalVariables.ActiveUnitType.AggregateGroundUnit;
		EvaluateIfDumb();
		base.set_IsAutoDetectable(((ActiveUnit)this).get_UnitSide(SetSideOnly: false), value: true);
		int length = Enum.GetValues(typeof(CombatPowerType)).Length;
		float_10 = new float[length - 1 + 1];
		float_11 = new float[length - 1 + 1];
	}

	public void ComputeAllFrictions()
	{
		lock (_frictionsLock)
		{
			Frictions.Clear();
			HostileFrictionProportion.Clear();
			EntityUnitEngagments_Air.Clear();
			EntityUnitEngagments.Clear();
			EntityUnitFriction_NonHostile.Clear();
			float_8 = 0f;
			float influenceRadius = GetInfluenceRadius();
			float num = influenceRadius + 3f;
			bool flag = GetAntiAirPower() > 0f;
			float num4 = default(float);
			foreach (KeyValuePair<string, ActiveUnit> activeUnit in ParentScen.ActiveUnits)
			{
				if (activeUnit.Value == this)
				{
					continue;
				}
				if (!activeUnit.Value.IsAggregatedUnit)
				{
					if (!(activeUnit.Value is IAGUInteractable))
					{
						continue;
					}
					double num2 = Geodesic_Haversine.Distance_Horiz_Approx_nm(((ActiveUnit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)this).get_Longitude((GlobalVariables.BooleanObject)null), activeUnit.Value.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit.Value.get_Longitude((GlobalVariables.BooleanObject)null));
					ActiveUnit value = activeUnit.Value;
					bool flag2 = ((ActiveUnit)this).get_UnitSide(SetSideOnly: false).get_ConsidersThisSideToBe(activeUnit.Value.get_UnitSide(SetSideOnly: false), (Scenario)null) == Misc.PostureStance.Hostile;
					if (!activeUnit.Value.IsAircraft)
					{
						if (num2 <= (double)influenceRadius)
						{
							if (((ActiveUnit)this).get_UnitSide(SetSideOnly: false).Contacts.ContainsKey(value.ObjectID))
							{
								Contact myContact = ((ActiveUnit)this).get_UnitSide(SetSideOnly: false).Contacts[value.ObjectID];
								myContact.UncertaintyArea = null;
								ActiveUnit TheDetectingUnit = this;
								ActiveUnit_Sensory.UpdateContactData(ref TheDetectingUnit, ref myContact, value, ContactIsNew: false);
							}
							else
							{
								Contact theContact = null;
								ActiveUnit_Sensory.ProcessNewContact(ref theContact, ref ParentScen, ((ActiveUnit)this).get_UnitSide(SetSideOnly: false), value, ActiveUnit_Sensory.SpecialDetectionMode.None, this, Contact_Base.IdentificationStatus.KnownClass);
							}
							if (!flag2)
							{
								EntityUnitFriction_NonHostile.Add((IAGUInteractable)activeUnit.Value);
							}
							else
							{
								EntityUnitEngagments.Add((IAGUInteractable)activeUnit.Value);
							}
						}
						continue;
					}
					float antiAirTargetAcquisition = GetAntiAirTargetAcquisition(activeUnit.Value);
					if (antiAirTargetAcquisition > 0.5f && flag && num2 <= (double)num && flag2)
					{
						EntityUnitEngagments_Air.Add((IAGUInteractable)activeUnit.Value);
					}
					if (antiAirTargetAcquisition > 0.05f)
					{
						if (!((ActiveUnit)this).get_UnitSide(SetSideOnly: false).Contacts.ContainsKey(value.ObjectID))
						{
							Contact theContact2 = null;
							ActiveUnit_Sensory.ProcessNewContact(ref theContact2, ref ParentScen, ((ActiveUnit)this).get_UnitSide(SetSideOnly: false), value, ActiveUnit_Sensory.SpecialDetectionMode.None, this, Contact_Base.IdentificationStatus.KnownType);
							continue;
						}
						Contact myContact2 = ((ActiveUnit)this).get_UnitSide(SetSideOnly: false).Contacts[value.ObjectID];
						myContact2.UncertaintyArea = null;
						ActiveUnit TheDetectingUnit = this;
						ActiveUnit_Sensory.UpdateContactData(ref TheDetectingUnit, ref myContact2, value, ContactIsNew: false);
					}
					else if (num2 <= (double)influenceRadius)
					{
						if (!((ActiveUnit)this).get_UnitSide(SetSideOnly: false).Contacts.ContainsKey(value.ObjectID))
						{
							Contact theContact3 = null;
							ActiveUnit_Sensory.ProcessNewContact(ref theContact3, ref ParentScen, ((ActiveUnit)this).get_UnitSide(SetSideOnly: false), value, ActiveUnit_Sensory.SpecialDetectionMode.None, this, Contact_Base.IdentificationStatus.KnownClass);
						}
						else
						{
							Contact myContact3 = ((ActiveUnit)this).get_UnitSide(SetSideOnly: false).Contacts[value.ObjectID];
							myContact3.UncertaintyArea = null;
							ActiveUnit TheDetectingUnit = this;
							ActiveUnit_Sensory.UpdateContactData(ref TheDetectingUnit, ref myContact3, value, ContactIsNew: false);
						}
						if (flag2)
						{
							EntityUnitEngagments.Add((IAGUInteractable)activeUnit.Value);
						}
						else
						{
							EntityUnitFriction_NonHostile.Add((IAGUInteractable)activeUnit.Value);
						}
					}
					continue;
				}
				AggregateGroundUnit aggregateGroundUnit = (AggregateGroundUnit)activeUnit.Value;
				_ = activeUnit.Value;
				float num3 = ComputeFriction(aggregateGroundUnit);
				if (num3 <= 0f)
				{
					if (activeUnit.Value is IAGUInteractable)
					{
					}
					continue;
				}
				Frictions.Add(aggregateGroundUnit, num3);
				float_8 += num3;
				if (((ActiveUnit)this).get_UnitSide(SetSideOnly: false).get_ConsidersThisSideToBe(activeUnit.Value.get_UnitSide(SetSideOnly: false), (Scenario)null) == Misc.PostureStance.Hostile)
				{
					num4 += num3;
					HostileFrictionProportion.Add(aggregateGroundUnit, num3);
				}
			}
			foreach (KeyValuePair<AggregateGroundUnit, float> item in HostileFrictionProportion.ToList())
			{
				HostileFrictionProportion[item.Key] = HostileFrictionProportion[item.Key] / num4;
			}
			TotalFriction = float_8;
		}
	}

	public float ComputeMorale()
	{
		float num = 0f;
		if (HQ != null)
		{
			num = 1f;
			if (!Frictions.ContainsKey(HQ))
			{
				num *= 1f - AGU_CONFIG.Instance.Morale_HQ_DirectProximity;
			}
			num *= 1f - AGU_CONFIG.Instance.Morale_HQ_Suppression * HQ.Suppression;
			num *= 1f - AGU_CONFIG.Instance.Morale_HQ_Losses * (HQ.Damage.DamagePercent * 0.01f);
			num *= 1f - AGU_CONFIG.Instance.Morale_HQ_EchelonDiscrepency * ((float)Math.Abs((int)(HQ.Echelon - Echelon)) * 0.2f);
			float num2 = (float)Geodesic_Haversine.Distance_Horiz_Approx_nm(((ActiveUnit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)this).get_Longitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)HQ).get_Latitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)HQ).get_Longitude((GlobalVariables.BooleanObject)null)) - GetInfluenceRadius() - HQ.GetInfluenceRadius();
			if (num2 > 0f)
			{
				num *= 1f - Math.Min(num2 * AGU_CONFIG.Instance.Morale_HQ_Distance_IncrementPerNm, AGU_CONFIG.Instance.Morale_HQ_Distance);
			}
			float num3 = (float)HQ.Proficiency.Value * 0.25f;
			num *= 1f - AGU_CONFIG.Instance.Morale_HQ_Proficiency * (1f - num3);
		}
		return 1f * (1f - (1f - num) * AGU_CONFIG.Instance.Morale_HQ);
	}

	public void ComputeCachedValues()
	{
		GetInfluenceRadius();
		GetAntiAirRadius();
		CurrentTerrain.SampleTerrain(((ActiveUnit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)this).get_Longitude((GlobalVariables.BooleanObject)null), GetInfluenceRadius(), 6, ParentScen);
		ComputeAllFrictions();
		CurrentMorale = ComputeMorale();
		CurrentCoverRating = GetCoverValue() * CurrentTactic.CoverModifier;
		CurrentAgilityRating = GetAgilityValue() * CurrentTactic.AgilityModifier;
		ComputeAllAngleMasks();
		method_22(0.2f);
		BestEscapeRoute(0.2f);
		_Encirclement = ComputeEncirclementFactor();
		ComputeCachedValues_Dirty = false;
	}

	public override void DoTypeSpecificActions(float elapsedTime, ref LockRandom theRNG)
	{
		if (ComputeCachedValues_Dirty || ParentScen.ThirtiethSecondIsChangingOnThisPulse)
		{
			ComputeCachedValues();
		}
		random = GlobalSingleton.GetInstance().Random;
		CurrentTactic.Cycle(elapsedTime, this);
		float_9 += elapsedTime;
		if (!(float_9 > AGU_CONFIG.Instance.TurnLength_Sec))
		{
			return;
		}
		CurrentTactic.FindDefensivePosition(this);
		float[] arrayByRef = new float[Enum.GetValues(typeof(CombatPowerType)).Length - 1 + 1];
		float num = 0f;
		if (HostileFrictionProportion.Count == 0)
		{
			num = 1f;
		}
		else if (EntityUnitEngagments.Count > 0)
		{
			num = (float)((double)(EntityUnitEngagments.Count + HostileFrictionProportion.Count) / (double)EntityUnitEngagments.Count);
		}
		float num2 = 1f - num;
		foreach (KeyValuePair<AggregateGroundUnit, float> item in HostileFrictionProportion)
		{
			float EngagedUnitBearing = 0f;
			float num3 = FacingTargetModifier(this, item.Key, ref EngagedUnitBearing);
			item.Key.ResolveAGUDamages(GetCombatPower(arrayByRef), num3 * CurrentAgilityRating * (1f - Suppression * 0.9f), AGU_CONFIG.Instance.BaseCombatIntensity * item.Value * num2, GetInverseBearing(EngagedUnitBearing));
		}
		if (EntityUnitEngagments.Count > 0)
		{
			float num4 = 1f / (float)EntityUnitEngagments.Count * num;
			foreach (IAGUInteractable entityUnitEngagment in EntityUnitEngagments)
			{
				float EngagedUnitBearing2 = 0f;
				float num5 = FacingTargetModifier(this, entityUnitEngagment.GetUnit(), ref EngagedUnitBearing2);
				entityUnitEngagment.ResolveAGUDamages(GetCombatPower(arrayByRef), num5 * CurrentAgilityRating * (1f - Suppression * 0.9f), AGU_CONFIG.Instance.BaseCombatIntensity * num4, GetInverseBearing(EngagedUnitBearing2));
				method_16(entityUnitEngagment);
			}
		}
		foreach (IAGUInteractable item2 in EntityUnitFriction_NonHostile)
		{
			method_16(item2);
		}
		if (GetAntiAirPower() > 0f && EntityUnitEngagments_Air.Count > 0)
		{
			float[] array = new float[Enum.GetValues(typeof(CombatPowerType)).Length - 1 + 1];
			int num6 = array.Length - 1;
			for (int i = 0; i <= num6; i++)
			{
				array[i] = 1f;
			}
			float num7 = 1f / (float)EntityUnitEngagments_Air.Count * (1f - Suppression);
			num7 *= 0.1f * elapsedTime;
			if (num7 > 0f)
			{
				foreach (IAGUInteractable item3 in EntityUnitEngagments_Air)
				{
					if (Helper.RollDice(num7))
					{
						item3.ResolveAGUDamages(array, 1f, 1f);
					}
				}
			}
		}
		float num8 = Math.Max(AGU_CONFIG.Instance.SuppressionRecoverySpeed * Suppression, 0.005f);
		Suppression -= num8;
		float_9 -= AGU_CONFIG.Instance.TurnLength_Sec;
		AI.Cycle();
	}

	private void method_16(IAGUInteractable iaguinteractable_0)
	{
		float facility_Control_RatePerTurn = AGU_CONFIG.Instance.Facility_Control_RatePerTurn;
		if (!(facility_Control_RatePerTurn > 0f) || !(iaguinteractable_0 is Facility))
		{
			return;
		}
		Facility facility = (Facility)iaguinteractable_0;
		facility_Control_RatePerTurn *= (float)Echelon / 5f;
		facility_Control_RatePerTurn = Math.Min(Math.Max(facility_Control_RatePerTurn, 0f), 0.05f);
		switch (((ActiveUnit)this).get_UnitSide(SetSideOnly: false).get_ConsidersThisSideToBe(((ActiveUnit)facility).get_UnitSide(SetSideOnly: false), (Scenario)null))
		{
		case Misc.PostureStance.Hostile:
			facility.Control -= facility_Control_RatePerTurn;
			if (facility.Control <= 0f)
			{
				((ActiveUnit)facility).set_UnitSide(SetSideOnly: false, ((ActiveUnit)this).get_UnitSide(SetSideOnly: false));
				facility.Control = 0.1f;
				ParentScen.AddMessage(Name + " has taken control of facility " + facility.Name, "AGU Engagement", LoggedMessage.MessageType.UnitLost, 0, ObjectID);
			}
			break;
		case Misc.PostureStance.Friendly:
			facility.Control += facility_Control_RatePerTurn;
			break;
		}
	}

	public float GetAntiAirTargetAcquisition(ActiveUnit target)
	{
		float num = (float)Geodesic_Haversine.Distance_Horiz_Approx_nm(((ActiveUnit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)this).get_Longitude((GlobalVariables.BooleanObject)null), target.get_Latitude((GlobalVariables.BooleanObject)null), target.get_Longitude((GlobalVariables.BooleanObject)null));
		float num2 = (1f - Suppression) * (1f - target.CurrentSpeed / 1000f);
		float num3 = Math.Max(1f - num / InfluenceRadius, 0f);
		num2 *= num3;
		float currentAltitude_AGL = target.CurrentAltitude_AGL;
		if (currentAltitude_AGL <= 8000f)
		{
			if (currentAltitude_AGL > 5000f)
			{
				return 0.75f * num2;
			}
			if (currentAltitude_AGL > 2000f)
			{
				return 1f * num2;
			}
			if (currentAltitude_AGL > 500f)
			{
				return 0.5f * num2;
			}
			if (currentAltitude_AGL > 100f)
			{
				return 0.25f * num2;
			}
			return 0f;
		}
		return 0f;
	}

	public float GetAntiAirPower()
	{
		float num = 0f;
		foreach (KeyValuePair<string, (ActiveUnit, int)> item in dictionary_2)
		{
			num += ((IAGUInteractable)item.Value.Item1).GetAntiAirPower() * (float)item.Value.Item2;
		}
		return num;
	}

	public static float FacingTargetModifier(Module_Unit.Unit OffensiveUnit, Module_Unit.Unit DefensiveUnit, ref float EngagedUnitBearing, float? OffsetInDegrees = null)
	{
		if (!OffsetInDegrees.HasValue)
		{
			OffsetInDegrees = AGU_CONFIG.Instance.DirectionalOffset_Degrees;
		}
		OffensiveUnit.UnitRelativeBearing(DefensiveUnit, ref EngagedUnitBearing);
		float num = Math.Max(Math.Abs(MathFunctions.AngularDifference(OffensiveUnit.CurrentHeading, EngagedUnitBearing)) - OffsetInDegrees.Value, 0f);
		float num2 = 1f - num * 0.00555f;
		return 1f - AGU_CONFIG.Instance.DirectionalModifier_Offense + num2 * AGU_CONFIG.Instance.DirectionalModifier_Offense;
	}

	public float ComputeEncirclementFactor()
	{
		if (AngleMask_HostileFriction != null && AngleMask_HostileFriction.Length != 0)
		{
			float num = 0f;
			int num2 = 0;
			do
			{
				num += AngleMask_HostileFriction[num2];
				num2++;
			}
			while (num2 <= 360);
			if (num == 0f)
			{
				return 0f;
			}
			return num / 360f;
		}
		return 0f;
	}

	public void DEBUG_DISPLAYMASK(string type)
	{
		float[] array = AngleMask_HostileFriction;
		if (Operators.CompareString(type, "frontline", false) == 0)
		{
			array = AngleMask_FrontLine;
		}
		else if (Operators.CompareString(type, "mobility", false) == 0)
		{
			array = AngleMask_Mobility;
		}
		try
		{
			int bearing = 0;
			float[] array2 = array;
			double out_lon = default(double);
			double out_lat = default(double);
			foreach (float num in array2)
			{
				double Lon = ((ActiveUnit)this).get_Longitude((GlobalVariables.BooleanObject)null);
				double Lat = ((ActiveUnit)this).get_Latitude((GlobalVariables.BooleanObject)null);
				int distance_NM = 20;
				Geodesic_EdWilliams.CalcPoint_Williams(ref Lon, ref Lat, ref out_lon, ref out_lat, ref distance_NM, ref bearing);
				((ActiveUnit)this).set_Latitude((GlobalVariables.BooleanObject)null, Lat);
				((ActiveUnit)this).set_Longitude((GlobalVariables.BooleanObject)null, Lon);
				int red = (int)Math.Round(num * 255f);
				int green = (int)Math.Round((1f - num) * 255f);
				Color color = Color.FromArgb(255, red, green, 128);
				ReferencePoint.CreateNew(ParentScen, "", out_lon, out_lat, ((ActiveUnit)this).get_UnitSide(SetSideOnly: false), null, color);
				bearing++;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public void ComputeAllAngleMasks()
	{
		ComputeAngleMask_Hostile();
		ComputeAngleMask_Frontline();
		ComputeAngleMask_EscapeRoute();
	}

	public void ComputeAngleMask_Hostile()
	{
		AngleMask_HostileFriction = new float[361];
		foreach (KeyValuePair<AggregateGroundUnit, float> friction in Frictions)
		{
			if (((ActiveUnit)friction.Key).get_UnitSide(SetSideOnly: false).get_ConsidersThisSideToBe(((ActiveUnit)this).get_UnitSide(SetSideOnly: false), (Scenario)null) == Misc.PostureStance.Hostile)
			{
				ref float[] angleMask_HostileFriction = ref AngleMask_HostileFriction;
				AggregateGroundUnit key = friction.Key;
				float EngagedUnitBearing = 0f;
				method_17(ref angleMask_HostileFriction, UnitRelativeBearing(key, ref EngagedUnitBearing), AGU_CONFIG.Instance.HostileAngleMaskPerContactPoint, bool_3: true, friction.Value);
			}
		}
	}

	public void ComputeAngleMask_Frontline()
	{
		AngleMask_HostileFriction.CopyTo(AngleMask_FrontLine, 0);
		foreach (KeyValuePair<AggregateGroundUnit, float> friction in Frictions)
		{
			if (((ActiveUnit)friction.Key).get_UnitSide(SetSideOnly: false).get_ConsidersThisSideToBe(((ActiveUnit)this).get_UnitSide(SetSideOnly: false), (Scenario)null) == Misc.PostureStance.Friendly)
			{
				ref float[] angleMask_FrontLine = ref AngleMask_FrontLine;
				AggregateGroundUnit key = friction.Key;
				float EngagedUnitBearing = 0f;
				method_17(ref angleMask_FrontLine, UnitRelativeBearing(key, ref EngagedUnitBearing), AGU_CONFIG.Instance.HostileAngleMaskPerContactPoint, bool_3: false, 0.55f);
			}
		}
	}

	public void ComputeAngleMask_EscapeRoute()
	{
		AngleMask_FrontLine.CopyTo(AngleMask_Mobility, 0);
		float num = 360f / (float)(CurrentTerrain.Samples.Count - 1);
		int num2 = CurrentTerrain.Samples.Count - 1;
		for (int i = 1; i <= num2; i++)
		{
			if (CurrentTerrain.Samples[i].Item1 == LandCover.LandCoverType.Water)
			{
				method_17(ref AngleMask_Mobility, num * (float)(i - 1), num, bool_3: true, 1f, bool_4: false);
			}
		}
	}

	private void method_17(ref float[] float_12, float float_13, float float_14, bool bool_3 = true, float float_15 = 1f, bool bool_4 = true)
	{
		int num = (int)Math.Round(float_13 - float_14);
		int num2 = (int)Math.Round(float_13 + float_14);
		if (num < 0)
		{
			num = 360 + num;
		}
		if (num2 > 360)
		{
			num2 -= 360;
		}
		int num3 = num;
		int num4 = num + (int)Math.Round(float_14 * 2f);
		for (int i = num3; i <= num4; i++)
		{
			int num5 = i % 360;
			float num6 = Math.Min(Math.Abs((float)num5 - float_13), 360f - Math.Abs((float)num5 - float_13));
			float num7 = 1f;
			if (bool_4)
			{
				num7 = (0.5f + (1f - num6 / float_14) * 1f) * float_15;
			}
			if (num7 < 0f)
			{
				num7 = 0f;
			}
			if (bool_3)
			{
				float_12[num5] = Math.Min(float_12[num5] + num7, 1f);
			}
			else
			{
				float_12[num5] = Math.Max(float_12[num5] - num7, 0f);
			}
		}
	}

	private float[] method_18(int int_5 = 1)
	{
		float[] array = new float[360];
		int num = 0;
		do
		{
			array[num] = AngleMask_HostileFriction[num];
			num++;
		}
		while (num <= 359);
		if (int_5 > 1)
		{
			return method_19(array, int_5);
		}
		return array;
	}

	private float[] method_19(float[] float_12, int int_5)
	{
		if (float_12 != null && float_12.Length != 0)
		{
			int num = float_12.Length;
			float[] array = new float[num - 1 + 1];
			if (int_5 <= 1)
			{
				Array.Copy(float_12, array, num);
				return array;
			}
			int num2 = int_5 / 2;
			int num3 = num - 1;
			for (int i = 0; i <= num3; i++)
			{
				double num4 = 0.0;
				int num5 = -num2;
				int num6 = num2;
				for (int j = num5; j <= num6; j++)
				{
					int num7 = (i + j) % num;
					if (num7 < 0)
					{
						num7 += num;
					}
					num4 += (double)float_12[num7];
				}
				array[i] = (float)(num4 / (double)int_5);
			}
			return array;
		}
		return float_12;
	}

	private List<Corridor> method_20(float[] float_12, Func<float, bool> func_0)
	{
		int num = float_12.Length;
		List<Corridor> list = new List<Corridor>();
		bool flag = false;
		int startA = -1;
		double num2 = 0.0;
		int num3 = 0;
		int num4 = num;
		for (int i = 0; i <= num4; i++)
		{
			if (i < num && func_0(float_12[i]))
			{
				if (!flag)
				{
					flag = true;
					startA = i;
					num2 = 0.0;
					num3 = 0;
				}
				num2 += (double)float_12[i];
				num3++;
			}
			else if (flag)
			{
				flag = false;
				int endA = i - 1;
				float meanT = ((num3 > 0) ? ((float)(num2 / (double)num3)) : 0f);
				list.Add(new Corridor(startA, endA, meanT, num3));
			}
		}
		if (list.Count >= 2)
		{
			Corridor corridor = list[0];
			Corridor corridor2 = list[list.Count - 1];
			if (corridor.StartAngle == 0 && corridor2.EndAngle == num - 1)
			{
				int num5 = corridor2.Width + corridor.Width;
				float meanT2 = (corridor2.MeanThreat * (float)corridor2.Width + corridor.MeanThreat * (float)corridor.Width) / (float)num5;
				Corridor value = new Corridor(corridor2.StartAngle, corridor.EndAngle, meanT2, num5);
				list.RemoveAt(list.Count - 1);
				list[0] = value;
			}
		}
		return list;
	}

	public List<Corridor> AttackDirections(float threshold, int smoothingWindow = 1)
	{
		float[] float_ = method_18(smoothingWindow);
		return method_20(float_, [SpecialName] (float v) => v >= threshold);
	}

	public List<Corridor> EscapeDirections(float confidence, int smoothingWindow = 1)
	{
		float[] float_ = method_18(smoothingWindow);
		return method_20(float_, [SpecialName] (float v) => v <= confidence);
	}

	private float method_21(Corridor corridor_0)
	{
		int startAngle = corridor_0.StartAngle;
		int endAngle = corridor_0.EndAngle;
		int num = 360;
		if (endAngle >= startAngle)
		{
			return (float)(startAngle + endAngle) / 2f;
		}
		float num2 = (float)(startAngle + endAngle + num) / 2f;
		if (num2 >= (float)num)
		{
			num2 -= (float)num;
		}
		return num2;
	}

	public float? BestAttackRoute(float threshold, int smoothingWindow = 1, bool preferPureIntensity = false)
	{
		List<Corridor> list = AttackDirections(threshold, smoothingWindow);
		if (list != null && list.Count != 0)
		{
			Corridor? corridor = null;
			double num = double.MinValue;
			foreach (Corridor item in list)
			{
				double num2 = ((!preferPureIntensity) ? (item.MeanThreat * (float)item.Width) : item.MeanThreat);
				if (!corridor.HasValue || num2 > num || (num2 == num && item.Width > corridor.Value.Width))
				{
					corridor = item;
					num = num2;
				}
			}
			return corridor.HasValue ? new float?(method_21(corridor.Value)) : ((float?)null);
		}
		return null;
	}

	public float? BestPushRoute(float confidence, int smoothingWindow = 1)
	{
		List<Corridor> list = AttackDirections(confidence, smoothingWindow);
		if (list != null && list.Count != 0)
		{
			Corridor? corridor = null;
			double num = double.MaxValue;
			foreach (Corridor item in list)
			{
				if (!corridor.HasValue || (double)item.MeanThreat < num || ((double)item.MeanThreat == num && item.Width > corridor.Value.Width))
				{
					corridor = item;
					num = item.MeanThreat;
				}
			}
			return corridor.HasValue ? new float?(method_21(corridor.Value)) : ((float?)null);
		}
		return null;
	}

	private List<(float, float, float)> method_22(float float_12)
	{
		list_2.Clear();
		bool flag = false;
		float item = -1f;
		float num = 0f;
		int num2 = 0;
		int num3 = 0;
		do
		{
			if (num3 > 359 || !(AngleMask_HostileFriction[num3] <= float_12))
			{
				if (flag)
				{
					flag = false;
					float item2 = num3 - 1;
					float item3 = ((num2 > 0) ? (num / (float)num2) : 0f);
					list_2.Add((item, item2, item3));
				}
			}
			else
			{
				if (!flag)
				{
					flag = true;
					item = num3;
					num = 0f;
					num2 = 0;
				}
				num += AngleMask_HostileFriction[num3];
				num2++;
			}
			num3++;
		}
		while (num3 <= 360);
		if (flag)
		{
			float item4 = 359f;
			if (list_2.Any() && list_2[0].Item1 == 0f)
			{
				float item5 = num + list_2[0].Item3;
				list_2[0] = (item, list_2[0].Item2, item5);
			}
			else
			{
				list_2.Add((item, item4, num));
			}
		}
		return list_2;
	}

	public float? BestEscapeRoute(float Confidence, float widthWeight = 0.6f, float opposeWeight = 0.8f)
	{
		List<(float, float, float, int)> list = method_24(Confidence);
		float? result;
		if (list.Count == 0)
		{
			result = null;
		}
		else
		{
			float? num = method_23();
			int num2 = 0;
			foreach (var item3 in list)
			{
				num2 += item3.Item4;
			}
			if (num2 >= 358)
			{
				result = (num.HasValue ? new float?(method_25(num.Value + 180f)) : new float?(0f));
			}
			else
			{
				(float, float, float, int)? tuple = null;
				float num3 = float.MaxValue;
				foreach (var item4 in list)
				{
					var (num4, num5, num6, num7) = item4;
					float float_;
					if (num5 >= num4)
					{
						float_ = (num4 + num5) / 2f;
					}
					else
					{
						float float_2 = (num4 + (num5 + 360f)) / 2f;
						float_ = method_25(float_2);
					}
					float num8 = (num.HasValue ? method_26(float_, num.Value) : 90f);
					float num9 = (float)num7 / 360f;
					float num10 = num8 / 180f;
					float num11 = num6 - widthWeight * num9 - opposeWeight * num10;
					if (num7 <= 2)
					{
						num11 += 0.25f;
					}
					if (num11 < num3)
					{
						num3 = num11;
						tuple = item4;
					}
				}
				if (!tuple.HasValue)
				{
					result = (num.HasValue ? new float?(method_25(num.Value + 180f)) : ((float?)null));
				}
				else
				{
					float item = tuple.Value.Item1;
					float item2 = tuple.Value.Item2;
					float value = ((!(item2 >= item)) ? method_25((item + item2 + 360f) / 2f) : ((item + item2) / 2f));
					result = value;
				}
			}
		}
		return result;
	}

	private float? method_23()
	{
		double num = 0.0;
		double num2 = 0.0;
		int num3 = 0;
		do
		{
			double num4 = AngleMask_HostileFriction[num3];
			if (num4 > 0.0)
			{
				double num5 = (double)num3 * Math.PI / 180.0;
				num += Math.Cos(num5) * num4;
				num2 += Math.Sin(num5) * num4;
			}
			num3++;
		}
		while (num3 <= 359);
		float? result;
		if (num == 0.0 && num2 == 0.0)
		{
			result = null;
		}
		else
		{
			double num6 = Math.Atan2(num2, num) * 180.0 / Math.PI;
			float value = method_25((float)num6);
			result = value;
		}
		return result;
	}

	private List<(float, float, float, int)> method_24(float float_12)
	{
		List<(float, float, float, int)> list = new List<(float, float, float, int)>();
		bool flag = false;
		float item = -1f;
		float num = 0f;
		int num2 = 0;
		int num3 = 0;
		do
		{
			if (!(AngleMask_HostileFriction[num3] <= float_12))
			{
				if (flag)
				{
					flag = false;
					float item2 = num3 - 1;
					float item3 = ((num2 > 0) ? (num / (float)num2) : 0f);
					list.Add((item, item2, item3, num2));
				}
			}
			else
			{
				if (!flag)
				{
					flag = true;
					item = num3;
					num = 0f;
					num2 = 0;
				}
				num += AngleMask_HostileFriction[num3];
				num2++;
			}
			num3++;
		}
		while (num3 <= 359);
		if (flag)
		{
			float item4 = 359f;
			float num4 = ((num2 > 0) ? (num / (float)num2) : 0f);
			if (list.Count > 0 && list[0].Item1 == 0f)
			{
				int num5 = num2 + list[0].Item4;
				float num6 = num4 * (float)num2 + list[0].Item3 * (float)list[0].Item4;
				float item5 = ((num5 > 0) ? (num6 / (float)num5) : 0f);
				list[0] = (item, list[0].Item2, item5, num5);
			}
			else
			{
				list.Add((item, item4, num4, num2));
			}
		}
		return list;
	}

	private float method_25(float float_12)
	{
		float num = float_12 % 360f;
		if (num < 0f)
		{
			num += 360f;
		}
		return num;
	}

	private float method_26(float float_12, float float_13)
	{
		float num = Math.Abs(method_25(float_12) - method_25(float_13));
		if (num > 180f)
		{
			num = 360f - num;
		}
		return num;
	}

	public float? BestPushingRoute()
	{
		(float, float, float)? tuple = null;
		float num = float.MaxValue;
		foreach (var item3 in list_2)
		{
			if (item3.Item3 < num)
			{
				tuple = item3;
				num = item3.Item3;
			}
		}
		float? result;
		if (tuple.HasValue)
		{
			float item = tuple.Value.Item1;
			float item2 = tuple.Value.Item2;
			float value = ((item2 >= item) ? ((item + item2) / 2f) : ((item + item2 + 360f) / 2f % 360f));
			result = value;
		}
		else
		{
			result = null;
		}
		return result;
	}

	public static HashSet<AggregateGroundUnit> CheckAGUContacts(IAGUInteractable UnitA, HashSet<AggregateGroundUnit> ToCheck)
	{
		Module_Unit.Unit unit = UnitA.GetUnit();
		HashSet<AggregateGroundUnit> hashSet = new HashSet<AggregateGroundUnit>();
		foreach (AggregateGroundUnit item in ToCheck)
		{
			float num = (float)Geodesic_Haversine.Distance_Horiz_Approx_nm(unit.get_Latitude((GlobalVariables.BooleanObject)null), unit.get_Longitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)item).get_Latitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)item).get_Longitude((GlobalVariables.BooleanObject)null));
			float influenceRadius = item.GetInfluenceRadius();
			float num2 = 2f;
			if (num < num2 + influenceRadius)
			{
				hashSet.Add(item);
			}
		}
		return hashSet;
	}

	public static float GetInverseBearing(float bearing)
	{
		float num = bearing + 180f;
		if (num > 360f)
		{
			num -= 360f;
		}
		if (num == 90f || num == 270f)
		{
			num += 180f;
		}
		return num;
	}

	public void ResolveDamages(float DP, float CombatIntensity, DamageMatrixType type = DamageMatrixType.Universal, bool Log = false)
	{
		ResolveAGUDamages(CreateDamageMatrix(DP, type), CombatIntensity, 1f, -1f, Log);
	}

	public void ResolveDamages_Proportion(float[] Proportion, bool Log = false, bool IgnoreArmorDeflection = false, bool IgnoreCoverDeflection = false, float CombatIntensity = -1f)
	{
		Array.Clear(Proportion, 0, Proportion.Length);
		ResolveAGUDamages(Proportion, 1f, AGU_CONFIG.Instance.BaseCombatIntensity, -1f, IgnoreArmorDeflection, IgnoreCoverDeflection, DamageResolutioMethod.FixedArmorType);
	}

	public void ResolveAGUDamages(float[] Damages, float CombatAgility, float DamageModifier, float AttackDirection_degrees = -1f, bool IgnoreArmorDeflection = false, bool IgnoreCoverDeflection = false, DamageResolutioMethod TargetingType = DamageResolutioMethod.Standard)
	{
		float[] array = new float[Enum.GetValues(typeof(CombatPowerType)).Length - 1 + 1];
		GetCombatProtection(array);
		GetHitPoints();
		float attackDirection_FacingRatio = 1f;
		if (AttackDirection_degrees != -1f)
		{
			float num = Math.Max(Math.Abs(MathFunctions.AngularDifference(CurrentHeading, AttackDirection_degrees)) - AGU_CONFIG.Instance.DirectionalOffset_Degrees, 0f);
			attackDirection_FacingRatio = 1f - num * 0.002777f;
		}
		if (GC_LastCombatRound != null)
		{
			GC_LastCombatRound.Initialise(ParentScen, this, Damages, array, DamageModifier, IgnoreArmorDeflection, IgnoreCoverDeflection, CombatAgility, CurrentCoverRating, attackDirection_FacingRatio, TargetingType);
		}
		else
		{
			GC_LastCombatRound = new AGU_Round(ParentScen, this, Damages, array, DamageModifier, IgnoreArmorDeflection, IgnoreCoverDeflection, CombatAgility, CurrentCoverRating, attackDirection_FacingRatio, TargetingType);
		}
		GC_LastCombatRound.Resolve();
		_ = AGU_CONFIG.Instance.Logging;
	}

	public float GetHitPoints()
	{
		float num = 0f;
		foreach (KeyValuePair<string, (ActiveUnit, int)> item in dictionary_2)
		{
			num += GetUnitHitPoint(item.Value.Item1) * (float)item.Value.Item2;
		}
		return num;
	}

	public float GetHitPoints(CombatPowerType ArmorType)
	{
		float num = 0f;
		float[] float_ = new float[Enum.GetValues(typeof(CombatPowerType)).Length - 1 + 1];
		foreach (KeyValuePair<string, (ActiveUnit, int)> item in dictionary_2)
		{
			if (method_28(item.Value.Item1, float_) == ArmorType)
			{
				num += GetUnitHitPoint(item.Value.Item1) * (float)item.Value.Item2;
			}
		}
		return num;
	}

	public static float GetUnitHitPoint(ActiveUnit TheAU)
	{
		float num = 0f;
		num += Math.Max(TheAU.InitialDP, 1f);
		foreach (Mount mount in TheAU.Mounts)
		{
			num += mount.DP;
		}
		return num;
	}

	public float GetUnitHitPoint(string RosterKey)
	{
		if (!dictionary_2.ContainsKey(RosterKey))
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return 0f;
		}
		return GetUnitHitPoint(dictionary_2[RosterKey].Item1);
	}

	public float[] GetCombatPower(float[] ArrayByRef)
	{
		int num = ArrayByRef.Length;
		Array.Clear(ArrayByRef, 0, ArrayByRef.Length);
		float[] array = new float[num + 1];
		foreach (KeyValuePair<string, (ActiveUnit, int)> item in dictionary_2)
		{
			((IAGUInteractable)item.Value.Item1).GetCombatPower(array);
			int num2 = num - 1;
			for (int i = 0; i <= num2; i++)
			{
				ArrayByRef[i] += array[i] * (float)item.Value.Item2;
			}
		}
		return ArrayByRef;
	}

	public void Order_Fallback(float DesiredDistance)
	{
		float? num = BestEscapeRoute(0.2f);
		if (num.HasValue)
		{
			Navigator.ClearPlottedCourse();
			((ActiveUnit)this).set_DesiredHeading(TurnRate.Max, num.Value);
			CurrentHeading = ((ActiveUnit)this).DesiredHeading;
			double Lon = ((ActiveUnit)this).get_Longitude((GlobalVariables.BooleanObject)null);
			double Lat = ((ActiveUnit)this).get_Latitude((GlobalVariables.BooleanObject)null);
			double bearing = num.Value;
			double out_lon = default(double);
			double out_lat = default(double);
			Geodesic_EdWilliams.CalcPoint_Williams(ref Lon, ref Lat, ref out_lon, ref out_lat, ref DesiredDistance, ref bearing);
			((ActiveUnit)this).set_Latitude((GlobalVariables.BooleanObject)null, Lat);
			((ActiveUnit)this).set_Longitude((GlobalVariables.BooleanObject)null, Lon);
			Navigator.AddWaypoint(out_lat, out_lon, 0f, Waypoint.WaypointType.ManualPlottedCourseWaypoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse, _Overshoot: false);
			SetThrottle(Throttle.MaxPossibleThrottle);
		}
	}

	public void Order_Push(float DesiredDistance, float Confidence = 0.3f, int smoothingWindow = 1)
	{
		float? num = BestPushRoute(Confidence, smoothingWindow);
		if (!num.HasValue)
		{
			num = BestAttackRoute(0.5f, smoothingWindow);
		}
		if (num.HasValue)
		{
			Navigator.ClearPlottedCourse();
			((ActiveUnit)this).set_DesiredHeading(TurnRate.Max, num.Value);
			CurrentHeading = ((ActiveUnit)this).DesiredHeading;
			double Lon = ((ActiveUnit)this).get_Longitude((GlobalVariables.BooleanObject)null);
			double Lat = ((ActiveUnit)this).get_Latitude((GlobalVariables.BooleanObject)null);
			double bearing = num.Value;
			double out_lon = default(double);
			double out_lat = default(double);
			Geodesic_EdWilliams.CalcPoint_Williams(ref Lon, ref Lat, ref out_lon, ref out_lat, ref DesiredDistance, ref bearing);
			((ActiveUnit)this).set_Latitude((GlobalVariables.BooleanObject)null, Lat);
			((ActiveUnit)this).set_Longitude((GlobalVariables.BooleanObject)null, Lon);
			Navigator.AddWaypoint(out_lat, out_lon, 0f, Waypoint.WaypointType.ManualPlottedCourseWaypoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse, _Overshoot: false);
			SetThrottle(Throttle.MaxPossibleThrottle);
		}
	}

	public void Order_Breakthrough(float DesiredDistance, float Threshold = 0.6f, int smoothingWindow = 1)
	{
		float? num = BestAttackRoute(Threshold, smoothingWindow);
		if (!num.HasValue)
		{
			num = BestPushRoute(0.4f, smoothingWindow);
		}
		if (num.HasValue)
		{
			Navigator.ClearPlottedCourse();
			((ActiveUnit)this).set_DesiredHeading(TurnRate.Max, num.Value);
			CurrentHeading = ((ActiveUnit)this).DesiredHeading;
			double Lon = ((ActiveUnit)this).get_Longitude((GlobalVariables.BooleanObject)null);
			double Lat = ((ActiveUnit)this).get_Latitude((GlobalVariables.BooleanObject)null);
			double bearing = num.Value;
			double out_lon = default(double);
			double out_lat = default(double);
			Geodesic_EdWilliams.CalcPoint_Williams(ref Lon, ref Lat, ref out_lon, ref out_lat, ref DesiredDistance, ref bearing);
			((ActiveUnit)this).set_Latitude((GlobalVariables.BooleanObject)null, Lat);
			((ActiveUnit)this).set_Longitude((GlobalVariables.BooleanObject)null, Lon);
			Navigator.AddWaypoint(out_lat, out_lon, 0f, Waypoint.WaypointType.ManualPlottedCourseWaypoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse, _Overshoot: false);
			SetThrottle(Throttle.MaxPossibleThrottle);
		}
	}

	public void Order_Entrench()
	{
		Order_FaceEnemy();
	}

	public void Order_FaceEnemy()
	{
	}

	public float[] GetCombatProtection(float[] ArrayByRef)
	{
		Array.Clear(ArrayByRef, 0, ArrayByRef.Length);
		int num = default(int);
		foreach (KeyValuePair<string, (ActiveUnit, int)> item in dictionary_2)
		{
			if (item.Value.Item1 is IAGUInteractable)
			{
				_PopulateArmorRatingCollection_Unit((IAGUInteractable)item.Value.Item1, ref ArrayByRef, item.Value.Item2);
				num += item.Value.Item2;
			}
		}
		if (dictionary_2.Count > 0)
		{
			int num2 = ArrayByRef.Length - 1;
			for (int i = 0; i <= num2; i++)
			{
				ArrayByRef[i] /= num;
			}
		}
		return ArrayByRef;
	}

	public GlobalVariables.ArmorRating GetMostCommonArmorRating()
	{
		Dictionary<GlobalVariables.ArmorRating, int> dictionary = new Dictionary<GlobalVariables.ArmorRating, int>();
		foreach (KeyValuePair<string, (ActiveUnit, int)> item in dictionary_2)
		{
			if (item.Value.Item1 is IAGUInteractable)
			{
				GlobalVariables.ArmorRating mostCommonArmorRating = ((IAGUInteractable)item.Value.Item1).GetMostCommonArmorRating();
				if (dictionary.ContainsKey(mostCommonArmorRating))
				{
					dictionary[mostCommonArmorRating] += item.Value.Item2;
				}
				else
				{
					dictionary.Add(mostCommonArmorRating, item.Value.Item2);
				}
			}
		}
		GlobalVariables.ArmorRating result = GlobalVariables.ArmorRating.None;
		int num = 0;
		foreach (KeyValuePair<GlobalVariables.ArmorRating, int> item2 in dictionary)
		{
			if (item2.Value > num)
			{
				result = item2.Key;
				num = item2.Value;
			}
		}
		return result;
	}

	private float[] method_27(ActiveUnit activeUnit_0, float[] float_12)
	{
		Array.Clear(float_12, 0, float_12.Length);
		int num = 0;
		foreach (KeyValuePair<string, (ActiveUnit, int)> item in dictionary_2)
		{
			if (item.Value.Item1 is IAGUInteractable)
			{
				_PopulateArmorRatingCollection_Unit((IAGUInteractable)item.Value.Item1, ref float_12, item.Value.Item2);
				num += item.Value.Item2;
			}
		}
		float num2 = 0f;
		foreach (object value in Enum.GetValues(typeof(CombatPowerType)))
		{
			CombatPowerType combatPowerType = (CombatPowerType)Conversions.ToInteger(value);
			num2 += float_12[(int)combatPowerType];
		}
		if (num2 > 0f)
		{
			foreach (object value2 in Enum.GetValues(typeof(CombatPowerType)))
			{
				CombatPowerType combatPowerType2 = (CombatPowerType)Conversions.ToInteger(value2);
				float_12[(int)combatPowerType2] /= num2;
			}
		}
		else
		{
			float_12[2] = 1f;
		}
		return float_12;
	}

	private CombatPowerType method_28(ActiveUnit activeUnit_0, float[] float_12)
	{
		Array.Clear(float_12, 0, float_12.Length);
		method_27(activeUnit_0, float_12);
		if (float_12[0] <= 0.35f)
		{
			if (float_12[1] > 0.35f)
			{
				return CombatPowerType.LightArmor;
			}
			return CombatPowerType.NoArmor;
		}
		return CombatPowerType.HeavyArmor;
	}

	public static void _PopulateArmorRatingCollection(GlobalVariables.ArmorRating Armor, ref float[] Protection, float Multiplier = 1f)
	{
		float[] array = new float[Enum.GetValues(typeof(CombatPowerType)).Length - 1 + 1];
		GetProtectionByArmorRating(array, Armor, Multiplier);
		int num = array.Length - 1;
		for (int i = 0; i <= num; i++)
		{
			Protection[i] += array[i] * Multiplier;
		}
	}

	public static void _PopulateArmorRatingCollection_Unit(IAGUInteractable Unit, ref float[] Protection, float Multiplier = 1f)
	{
		float[] array = new float[Enum.GetValues(typeof(CombatPowerType)).Length - 1 + 1];
		Unit.GetCombatProtection(array);
		int num = array.Length - 1;
		for (int i = 0; i <= num; i++)
		{
			Protection[i] += array[i] * Multiplier;
		}
	}

	public static float[] GetProtectionByArmorRating(float[] Protection, GlobalVariables.ArmorRating Armor, float Multiplier = 1f)
	{
		Array.Clear(Protection, 0, Protection.Length);
		AGU_CONFIG instance = AGU_CONFIG.Instance;
		float[,] combatMatrix_Defence = instance.CombatMatrix_Defence;
		int num = Enum.GetValues(typeof(CombatPowerType)).Length - 1;
		for (int i = 0; i <= num; i++)
		{
			Protection[i] = Multiplier * combatMatrix_Defence[instance.ArmorRating_IndexMapping[Armor], i];
		}
		return Protection;
	}

	public List<string> GetTooltip(bool TerrainAndSlope)
	{
		List<string> list = new List<string>();
		if (TerrainAndSlope)
		{
			list.Add("");
			if (AGU_CONFIG.Instance.UI_TooltipDisplay_Terrain)
			{
				list.Add("Slope " + (CurrentTerrain.Slope * 100f).ToString("0.0") + "%");
				list.Add("-----------");
				foreach (KeyValuePair<LandCover.LandCoverType, float> item in CurrentTerrain.TerrainProportion.OrderByDescending([SpecialName] (KeyValuePair<LandCover.LandCoverType, float> pair) => pair.Value))
				{
					list.Add(item.Key.ToString() + " " + (item.Value * 100f).ToString("0.0") + "%");
				}
				list.Add("-----------");
			}
			if (AGU_CONFIG.Instance.UI_TooltipDisplay_Effects)
			{
				list.Add("Combat Stance: " + (AggregateGroundUnit_AI.TacticalPosture)Doctrine.GetElementState(Doctrine.DoctrineItem_E.AGU_TacticalPosture).Value/*cast due to .constrained prefix*/);
				list.Add("-----------");
				list.Add("Cover " + (CurrentCoverRating * 100f).ToString("0.0") + "%");
				list.Add("Agility " + (CurrentAgilityRating * 100f).ToString("0.0") + "%");
				list.Add("Entrenchment " + (Entrenchment() * 100f).ToString("0.0") + "%");
				list.Add("-----------");
				list.Add("Morale " + (CurrentMorale * 100f).ToString("0.0") + "%");
				list.Add("Suppressed " + (Suppression * 100f).ToString("0.0") + "%");
				list.Add("Encirclement factor " + (_Encirclement * 100f).ToString("0.0") + "%");
				list.Add("-----------");
			}
			if (AGU_CONFIG.Instance.UI_TooltipDisplay_CombatMatrix)
			{
				list.Add("Offense");
				list.Add("-----------");
				float[] array = new float[Enum.GetValues(typeof(CombatPowerType)).Length - 1 + 1];
				GetCombatPower(array);
				int num = array.Length - 1;
				for (int num2 = 0; num2 <= num; num2++)
				{
					CombatPowerType combatPowerType = (CombatPowerType)num2;
					list.Add(combatPowerType.ToString() + " " + array[num2].ToString("0.0"));
				}
				list.Add("-----------");
				list.Add("Defense");
				list.Add("-----------");
				GetCombatProtection(array);
				int num3 = array.Length - 1;
				for (int num4 = 0; num4 <= num3; num4++)
				{
					CombatPowerType combatPowerType = (CombatPowerType)num4;
					list.Add(combatPowerType.ToString() + " " + array[num4].ToString("0.0"));
				}
			}
		}
		return list;
	}

	public float Entrenchment()
	{
		float num = 0f;
		if (SettledTime > AGU_CONFIG.Instance.Entrenchment_Minimal_Sec)
		{
			num = Math.Max(Math.Min(AGU_CONFIG.Instance.Entrenchment_Minimal_Efficiency + (SettledTime - AGU_CONFIG.Instance.Entrenchment_Minimal_Sec) / AGU_CONFIG.Instance.Entrenchment_Full_Sec, 1f), 0f);
		}
		if (base.IsAttachedToDefensiveSystem)
		{
			num += 0.5f;
		}
		return num;
	}

	public float GetCoverValue()
	{
		GClass7 terrainModifier = CurrentTerrain.TerrainModifier;
		ProfileType profile = GetProfile();
		float num = aggregateGroundUnit_Kinematics_0.ThrottlePreset switch
		{
			ActiveUnit_Kinematics.UnitThrottlePreset.Loiter => 0.8f, 
			ActiveUnit_Kinematics.UnitThrottlePreset.Cruise => 0.6f, 
			ActiveUnit_Kinematics.UnitThrottlePreset.Full => 0.4f, 
			ActiveUnit_Kinematics.UnitThrottlePreset.Flank => 0.2f, 
			_ => 1f, 
		};
		float num2 = default(float);
		return profile switch
		{
			ProfileType.Human => Math.Min(terrainModifier.Cover_Personel * num + Entrenchment() * AGU_CONFIG.Instance.Entrenchment_BaseCoverModifier, 0.95f), 
			ProfileType.Vehicle => Math.Min(terrainModifier.Cover_Vehicle * num + Entrenchment() * AGU_CONFIG.Instance.Entrenchment_BaseCoverModifier, 0.95f), 
			_ => num2, 
		};
	}

	public float GetAgilityValue()
	{
		GClass7 terrainModifier = CurrentTerrain.TerrainModifier;
		float num = default(float);
		return GetProfile() switch
		{
			ProfileType.Vehicle => terrainModifier.Agility_Vehicle, 
			ProfileType.Human => terrainModifier.Agility_Personel, 
			_ => num, 
		};
	}

	public float GetSpeedModifier()
	{
		ProfileType profile = GetProfile();
		GClass7 terrainModifier = CurrentTerrain.TerrainModifier;
		if (!base.IsAttachedToRoadSystem)
		{
			switch (profile)
			{
			case ProfileType.Vehicle:
				return terrainModifier.Speed_Vehicle;
			case ProfileType.Human:
				return terrainModifier.Speed_Personel;
			}
		}
		else
		{
			switch (profile)
			{
			case ProfileType.Vehicle:
				return Math.Max(terrainModifier.Speed_Vehicle, 10f);
			case ProfileType.Human:
				return Math.Max(terrainModifier.Speed_Personel, 3f);
			}
		}
		return 1f;
	}

	public float ComputeFriction(AggregateGroundUnit Unit)
	{
		if (Unit.IsAggregatedUnit)
		{
			float num = (float)InfluenceInterectionArea_Nm2(Unit);
			float num2 = 0f;
			if (num > 0f)
			{
				num2 = num / GetInfluenceArea_Nm2() * GetFrictionModifierAgainstTarget(Unit);
			}
			return num2;
		}
		return 0f;
	}

	public float GetInfluenceArea_Nm2()
	{
		float influenceRadius = GetInfluenceRadius();
		return (float)(Math.PI * (double)influenceRadius * (double)influenceRadius);
	}

	public float GetFrictionAgainstTarget(AggregateGroundUnit Target)
	{
		if (Frictions.ContainsKey(Target))
		{
			return Frictions[Target];
		}
		return 0f;
	}

	public float GetFrictionModifierAgainstTarget(ActiveUnit Target)
	{
		float num = 0f;
		switch (((ActiveUnit)this).get_UnitSide(SetSideOnly: false).get_ConsidersThisSideToBe(Target.get_UnitSide(SetSideOnly: false), (Scenario)null))
		{
		case Misc.PostureStance.Neutral:
		case Misc.PostureStance.Friendly:
			num = AGU_CONFIG.Instance.FriendlyBaseFriction;
			break;
		case Misc.PostureStance.Hostile:
			num = AGU_CONFIG.Instance.HostileBaseFriction;
			break;
		case Misc.PostureStance.Unfriendly:
		case Misc.PostureStance.Unknown:
			num = AGU_CONFIG.Instance.UnknownBaseFriction;
			break;
		}
		if (Target.IsAggregatedUnit)
		{
			return FrictionModifier * ((AggregateGroundUnit)Target).FrictionModifier * num;
		}
		return FrictionModifier * 0.5f * num;
	}

	public void DEBUG_ComputeAndPrintFrictions()
	{
		ComputeAllFrictions();
		if (Frictions.Count <= 0)
		{
			return;
		}
		foreach (KeyValuePair<AggregateGroundUnit, float> friction in Frictions)
		{
			_ = friction;
		}
	}

	public double InfluenceInterectionArea_Nm2(AggregateGroundUnit Unit)
	{
		return InfluenceInterectionArea_Nm2(Geodesic_Haversine.Distance_Horiz_Approx_nm(((ActiveUnit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)this).get_Longitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)Unit).get_Latitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)Unit).get_Longitude((GlobalVariables.BooleanObject)null)), GetInfluenceRadius(), Unit.GetInfluenceRadius());
	}

	public double InfluenceInterectionArea_Nm2(double Distance, double R1, double R2)
	{
		if (R1 >= Distance + R2)
		{
			return Math.Min(Math.PI * R2 * R2, Math.PI * R1 * R1);
		}
		if (R1 + Distance <= R2)
		{
			return Math.Min(Math.PI * R2 * R2, Math.PI * R1 * R1);
		}
		if (Distance > R2 + R1)
		{
			return 0.0;
		}
		double num = Math.Acos((R1 * R1 + Distance * Distance - R2 * R2) / (2.0 * R1 * Distance)) * 2.0;
		double num2 = Math.Acos((R2 * R2 + Distance * Distance - R1 * R1) / (2.0 * R2 * Distance)) * 2.0;
		double num3 = 0.5 * num2 * R2 * R2 - 0.5 * R2 * R2 * Math.Sin(num2);
		double num4 = 0.5 * num * R1 * R1 - 0.5 * R1 * R1 * Math.Sin(num);
		return num3 + num4;
	}

	public double InfluenceInterectionArea_Box_Nm2(double rectangleWidth, double rectangleHeight, double RectangleLatitude, double RectangleLongitude)
	{
		double[] array = Command_Core.Mercator_OSM.Mercator_OSM.toPixel(((ActiveUnit)this).get_Longitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)this).get_Latitude((GlobalVariables.BooleanObject)null));
		double[] array2 = Command_Core.Mercator_OSM.Mercator_OSM.toPixel(RectangleLongitude, RectangleLatitude);
		float influenceRadius = GetInfluenceRadius();
		double num = Math.Max(array2[0] - rectangleWidth / 2.0, Math.Min(array[0], array2[0] + rectangleWidth / 2.0));
		double num2 = Math.Max(array2[1] - rectangleHeight / 2.0, Math.Min(array[1], array2[1] + rectangleHeight / 2.0));
		double num3 = num;
		double num4 = num2;
		if (array[0] < array2[0] - rectangleWidth / 2.0)
		{
			num = array2[0] - rectangleWidth / 2.0;
		}
		else if (array[0] > array2[0] + rectangleWidth / 2.0)
		{
			num3 = array2[0] + rectangleWidth / 2.0;
		}
		if (array[1] < array2[1] - rectangleHeight / 2.0)
		{
			num2 = array2[1] - rectangleHeight / 2.0;
		}
		else if (array[1] > array2[1] + rectangleHeight / 2.0)
		{
			num4 = array2[1] + rectangleHeight / 2.0;
		}
		double num5 = num3 - num;
		double num6 = num4 - num2;
		double num7 = Math.PI * (double)influenceRadius * (double)influenceRadius;
		if (num5 > 0.0 && num6 > 0.0)
		{
			num7 -= (double)(influenceRadius * influenceRadius) * Math.Acos(num5 / (double)influenceRadius) - num5 * Math.Sqrt((double)(influenceRadius * influenceRadius) - num5 * num5);
			num7 += num6 * (num3 - num);
		}
		return num7;
	}

	public void ClearActualRoster()
	{
		ComputeCachedValues_Dirty = true;
		dictionary_2.Clear();
	}

	public void AddOrRemoveAssignedRoster(string AnnexAndDBID, int amount, bool DetachedUnit = false)
	{
		ComputeCachedValues_Dirty = true;
		Facility Facility = null;
		Vehicle Vehicle = null;
		GetUnit(ParentScen, AnnexAndDBID, ref Facility, ref Vehicle);
		if (Facility == null && Vehicle == null)
		{
			return;
		}
		if (DetachedUnit)
		{
			if (dictionary_1.ContainsKey(AnnexAndDBID))
			{
				dictionary_1[AnnexAndDBID] = amount;
			}
			else
			{
				dictionary_1.Add(AnnexAndDBID, amount);
			}
			if (dictionary_1[AnnexAndDBID] <= 0)
			{
				dictionary_1.Remove(AnnexAndDBID);
			}
		}
		else
		{
			if (dictionary_0.ContainsKey(AnnexAndDBID))
			{
				dictionary_0[AnnexAndDBID] = amount;
			}
			else
			{
				dictionary_0.Add(AnnexAndDBID, amount);
			}
			if (dictionary_0[AnnexAndDBID] <= 0)
			{
				dictionary_0.Remove(AnnexAndDBID);
			}
		}
	}

	public List<ActiveUnit> GetDetachedUnits()
	{
		if (((ActiveUnit)this).get_ParentGroup(UsingMissionPlanner: false) == null)
		{
			return null;
		}
		List<ActiveUnit> list = new List<ActiveUnit>();
		foreach (KeyValuePair<string, ActiveUnit> unit in ((ActiveUnit)this).get_ParentGroup(UsingMissionPlanner: false).Units)
		{
			if (unit.Value != this && unit.Value is IAGUInteractable)
			{
				list.Add(unit.Value);
			}
		}
		return list;
	}

	public Dictionary<string, int> GetActualDetachedRoster()
	{
		if (((ActiveUnit)this).get_ParentGroup(UsingMissionPlanner: false) == null)
		{
			return null;
		}
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		foreach (KeyValuePair<string, ActiveUnit> unit in ((ActiveUnit)this).get_ParentGroup(UsingMissionPlanner: false).Units)
		{
			if (unit.Value != this && unit.Value is IAGUInteractable)
			{
				if (dictionary.ContainsKey(unit.Value.AnnexAndDBID))
				{
					dictionary[unit.Value.AnnexAndDBID]++;
				}
				else
				{
					dictionary.Add(unit.Value.AnnexAndDBID, 1);
				}
			}
		}
		return dictionary;
	}

	public void AddActualDetachedRoster(string AnnexAndDBID, int amount, bool DoNotExceedAmountAsActual = true)
	{
		if (amount < 0)
		{
			return;
		}
		if (DoNotExceedAmountAsActual)
		{
			Dictionary<string, int> actualDetachedRoster = GetActualDetachedRoster();
			if (actualDetachedRoster != null)
			{
				int value = 0;
				if (actualDetachedRoster.TryGetValue(AnnexAndDBID, out value) && amount > value)
				{
					amount = value;
				}
			}
		}
		if (amount == 0)
		{
			return;
		}
		int num = amount - 1;
		for (int i = 0; i <= num; i++)
		{
			ActiveUnit activeUnit = method_29(AnnexAndDBID);
			if (activeUnit != null)
			{
				if (((ActiveUnit)this).get_ParentGroup(UsingMissionPlanner: false) == null)
				{
					ref Scenario parentScen = ref ParentScen;
					Side theSide = ((ActiveUnit)this).get_UnitSide(SetSideOnly: false);
					Group obj = new Group(ref parentScen, ref theSide, new List<ActiveUnit> { this, activeUnit });
					((ActiveUnit)this).set_UnitSide(SetSideOnly: false, theSide);
					obj.Name = Name;
				}
				else
				{
					activeUnit.set_ParentGroup(UsingMissionPlanner: false, ((ActiveUnit)this).get_ParentGroup(UsingMissionPlanner: false));
				}
			}
		}
	}

	private ActiveUnit method_29(string string_5)
	{
		Geopoint_Struct? geopoint_Struct = method_31();
		if (geopoint_Struct.HasValue)
		{
			string[] array = string_5.Split(new char[1] { '_' });
			ActiveUnit result = null;
			switch (array[0])
			{
			case "Vehicle":
			case "GroundUnit":
				result = ParentScen.AddNewVehicle(((ActiveUnit)this).get_UnitSide(SetSideOnly: false), Conversions.ToInteger(array[1]), "", geopoint_Struct.Value.Longitude, geopoint_Struct.Value.Latitude);
				break;
			case "Facility":
				result = ParentScen.AddNewFacility(((ActiveUnit)this).get_UnitSide(SetSideOnly: false), Conversions.ToInteger(array[1]), "", geopoint_Struct.Value.Longitude, geopoint_Struct.Value.Latitude);
				break;
			}
			return result;
		}
		return null;
	}

	private Geopoint_Struct? method_30(float float_12 = 1f, bool bool_3 = false)
	{
		int num = 0;
		float num2 = Math.Max(1f, GetInfluenceRadius() * float_12);
		double latitude = ((ActiveUnit)this).get_Latitude((GlobalVariables.BooleanObject)null);
		double longitude = ((ActiveUnit)this).get_Longitude((GlobalVariables.BooleanObject)null);
		Geopoint_Struct? result;
		while (true)
		{
			if (num < 20)
			{
				Geopoint_Struct geopoint_Struct = Math2.RandomPointWithinDistance(latitude, longitude, num2);
				if (!bool_3 && Terrain.GetElevation(geopoint_Struct, RequestIsFromGUI: false, ParentScen) < 0)
				{
					num++;
					continue;
				}
				result = geopoint_Struct;
				break;
			}
			result = ((Terrain.GetElevation(((ActiveUnit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)this).get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, ParentScen) < 0) ? ((Geopoint_Struct?)null) : new Geopoint_Struct?(new Geopoint_Struct(((ActiveUnit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)this).get_Longitude((GlobalVariables.BooleanObject)null))));
			break;
		}
		return result;
	}

	private Geopoint_Struct? method_31()
	{
		return method_30(0.75f, bool_3: true);
	}

	public void AddOrRemoveActualRoster(string AnnexAndDBID, int amount, bool AutomaticallyAlignAssignedRoster = false, bool AllowDestructionWhenDepleted = false, bool UI_Bark = false, bool LogAsAARLoss = false)
	{
		if (amount == 0)
		{
			return;
		}
		ComputeCachedValues_Dirty = true;
		Facility Facility = null;
		Vehicle Vehicle = null;
		if (!dictionary_2.ContainsKey(AnnexAndDBID))
		{
			if (amount > 0)
			{
				dictionary_2.Add(AnnexAndDBID, (GetUnit(AnnexAndDBID, ref Facility, ref Vehicle), amount));
			}
		}
		else
		{
			(ActiveUnit, int) tuple = dictionary_2[AnnexAndDBID];
			if (amount < 0 && -amount > tuple.Item2)
			{
				amount = -tuple.Item2;
			}
			if (amount == 0)
			{
				return;
			}
			if (LogAsAARLoss)
			{
				((ActiveUnit)this).get_UnitSide(SetSideOnly: false).AAR.AddToLosses(AnnexAndDBID, ObjectID, -amount, TreatAsAimpoint: false, this);
				if (Losses.ContainsKey(AnnexAndDBID))
				{
					Losses[AnnexAndDBID] -= amount;
				}
				else
				{
					Losses.Add(AnnexAndDBID, -amount);
				}
			}
			if (UI_Bark)
			{
				int num = 0;
				if (amount > 0)
				{
					num = amount;
					Notification_Bark.Create(this, num + " " + dictionary_2[AnnexAndDBID].Item1.UnitClass + " added", Color.Green, MoveUpward: true, Fades: true, 3f);
				}
				else if (amount < 0)
				{
					num = Math.Min(-amount, dictionary_2[AnnexAndDBID].Item2);
					Geopoint_Struct value = method_30().Value;
					if (AGU_CONFIG.Instance.UI_AGULossBark)
					{
						Notification_Bark.Create(value, num + " " + dictionary_2[AnnexAndDBID].Item1.UnitClass + " destroyed", Color.Red, MoveUpward: true, Fades: true, 3f);
					}
					if (AGU_CONFIG.Instance.UI_AGULossExplosion)
					{
						new GroundImpact(ref ParentScen, value, Math.Min(Math.Max(amount, 1f), 10f), theIsIncendiary: false, 0.1f);
					}
				}
			}
			tuple = (tuple.Item1, tuple.Item2 + amount);
			dictionary_2[AnnexAndDBID] = tuple;
			if (tuple.Item2 <= 0 && !dictionary_0.ContainsKey(AnnexAndDBID))
			{
				dictionary_2.Remove(AnnexAndDBID);
			}
		}
		if (AutomaticallyAlignAssignedRoster && dictionary_2.ContainsKey(AnnexAndDBID))
		{
			int item = dictionary_2[AnnexAndDBID].Item2;
			if (item > 0)
			{
				if (!dictionary_0.ContainsKey(AnnexAndDBID))
				{
					dictionary_0.Add(AnnexAndDBID, item);
				}
				else
				{
					dictionary_0[AnnexAndDBID] = item;
				}
			}
		}
		if (AllowDestructionWhenDepleted)
		{
			IntegrityCheck();
		}
	}

	public static float[] CreateDamageMatrix(float YieldInDP, DamageMatrixType Type)
	{
		float[] array = new float[Enum.GetValues(typeof(CombatPowerType)).Length - 1 + 1];
		switch (Type)
		{
		case DamageMatrixType.Standard:
			array[2] = YieldInDP;
			array[1] = YieldInDP * 0.5f;
			array[0] = YieldInDP * 0.15f;
			break;
		case DamageMatrixType.Universal:
			array[2] = YieldInDP;
			array[1] = YieldInDP;
			array[0] = YieldInDP;
			break;
		case DamageMatrixType.Penetrating_Light:
			array[2] = YieldInDP * 0.8f;
			array[1] = YieldInDP;
			array[0] = YieldInDP * 0.15f;
			break;
		case DamageMatrixType.Penetrating_Heavy:
			array[2] = YieldInDP * 0.6f;
			array[1] = YieldInDP * 0.75f;
			array[0] = YieldInDP;
			break;
		}
		return array;
	}

	public void IntegrityCheck()
	{
		if (dictionary_2.Count == 0 || GetActualUnitCount() == 0)
		{
			Destroy(ScenEditAction: false, IsFacilityAimpoint: false, DestroyUnitNow: true, "Formation depleted");
		}
	}

	public int GetActualUnitCount()
	{
		int num = default(int);
		foreach (KeyValuePair<string, (ActiveUnit, int)> item in dictionary_2)
		{
			num += item.Value.Item2;
		}
		return num;
	}

	public void SetActualRoster(string AnnexAndDBID, int amount, bool AllowDestructionWhenDepleted = false)
	{
		Facility Facility = null;
		Vehicle Vehicle = null;
		if (!dictionary_2.ContainsKey(AnnexAndDBID))
		{
			if (amount > 0)
			{
				dictionary_2.Add(AnnexAndDBID, (GetUnit(AnnexAndDBID, ref Facility, ref Vehicle), amount));
			}
		}
		else
		{
			(ActiveUnit, int) value = (dictionary_2[AnnexAndDBID].Item1, amount);
			dictionary_2[AnnexAndDBID] = value;
			if (value.Item2 <= 0 && !dictionary_0.ContainsKey(AnnexAndDBID))
			{
				dictionary_2.Remove(AnnexAndDBID);
			}
		}
		if (AllowDestructionWhenDepleted)
		{
			IntegrityCheck();
		}
	}

	public Dictionary<string, (ActiveUnit, int)> GetActualRoster_Readonly()
	{
		return dictionary_2;
	}

	public Dictionary<string, int> GetAssignedRoster_Readonly()
	{
		return dictionary_0;
	}

	public Dictionary<string, int> GetAssignedDetachedRoster_Readonly()
	{
		return dictionary_1;
	}

	public float GetInfluenceRadius(bool ConsiderDoctrine = true)
	{
		InfluenceRadius = 1f;
		float num = AGU_CONFIG.Instance.RadiusOfInfluence;
		if (ConsiderDoctrine)
		{
			num *= CurrentTactic.CurrentAreaOfInfluence;
			if (CurrentTactic.Integrity == AGU_Integrity.Consolidate)
			{
				num *= Math.Max(1f - Damage.DamagePercent * 0.01f, 0.01f);
			}
		}
		switch (Echelon)
		{
		case GroundEchelonLevel.Section:
			InfluenceRadius = 0.6f * num;
			break;
		case GroundEchelonLevel.Squad:
			InfluenceRadius = 0.9f * num;
			break;
		case GroundEchelonLevel.Battalion:
			InfluenceRadius = 3f * num;
			break;
		case GroundEchelonLevel.Company:
			InfluenceRadius = 2f * num;
			break;
		case GroundEchelonLevel.Platoon:
			InfluenceRadius = 1.33f * num;
			break;
		case GroundEchelonLevel.Division:
			InfluenceRadius = 10.125f * num;
			break;
		case GroundEchelonLevel.Brigade:
			InfluenceRadius = 6.75f * num;
			break;
		case GroundEchelonLevel.Regiment:
			InfluenceRadius = 4.5f * num;
			break;
		case GroundEchelonLevel.ArmyGroup:
			InfluenceRadius = 34.17f * num;
			break;
		case GroundEchelonLevel.Army:
			InfluenceRadius = 22.78f * num;
			break;
		case GroundEchelonLevel.Corps:
			InfluenceRadius = 15.18f * num;
			break;
		}
		return InfluenceRadius;
	}

	public float GetAntiAirRadius(bool ConsiderDoctrine = true)
	{
		AntiAirRadius = GetInfluenceRadius(ConsiderDoctrine) + 3f;
		return AntiAirRadius;
	}

	public static float GetHQLeashWidth(GroundEchelonLevel echelon)
	{
		return echelon switch
		{
			GroundEchelonLevel.Section => 1f, 
			GroundEchelonLevel.Squad => 1f, 
			GroundEchelonLevel.Battalion => 2f, 
			GroundEchelonLevel.Company => 2f, 
			GroundEchelonLevel.Platoon => 1f, 
			GroundEchelonLevel.Division => 5f, 
			GroundEchelonLevel.Brigade => 4f, 
			GroundEchelonLevel.Regiment => 3f, 
			GroundEchelonLevel.ArmyGroup => 8f, 
			GroundEchelonLevel.Army => 7f, 
			GroundEchelonLevel.Corps => 6f, 
			_ => 1f, 
		};
	}

	public string EchelonSign(GroundEchelonLevel theLevel)
	{
		switch (theLevel)
		{
		case GroundEchelonLevel.ArmyGroup:
			return "XXXXX";
		case GroundEchelonLevel.Army:
			return "XXXX";
		case GroundEchelonLevel.Corps:
			return "XXX";
		case GroundEchelonLevel.Division:
			return "XX";
		case GroundEchelonLevel.Brigade:
			return "X";
		case GroundEchelonLevel.Regiment:
			return "III";
		case GroundEchelonLevel.Battalion:
			return "II";
		case GroundEchelonLevel.Company:
			return "I";
		case GroundEchelonLevel.Platoon:
			return "●●●";
		default:
			_ = Debugger.IsAttached;
			return "";
		case GroundEchelonLevel.Section:
			return "●●";
		case GroundEchelonLevel.Squad:
			return "●";
		}
	}

	public AggregateGroundUnit Clone()
	{
		AggregateGroundUnit aggregateGroundUnit = new AggregateGroundUnit(ParentScen);
		aggregateGroundUnit.Name = Name;
		aggregateGroundUnit._FrictionModifier = _FrictionModifier;
		aggregateGroundUnit.Echelon = Echelon;
		aggregateGroundUnit.MobileUnitCategory = MobileUnitCategory;
		foreach (KeyValuePair<string, int> item in dictionary_0)
		{
			aggregateGroundUnit.dictionary_0.Add(item.Key, item.Value);
		}
		foreach (KeyValuePair<string, (ActiveUnit, int)> item2 in GetActualRoster_Readonly())
		{
			aggregateGroundUnit.AddOrRemoveActualRoster(item2.Key, item2.Value.Item2);
		}
		return aggregateGroundUnit;
	}

	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
		try
		{
			theWriter.WriteStartElement("AggregateGroundUnit");
			theWriter.WriteElementString("ID", ObjectID);
			if (!ObjectsAlreadySerialized.Contains(ObjectID))
			{
				ObjectsAlreadySerialized.Add(ObjectID);
				method_2(ref theWriter);
				if (!string.IsNullOrEmpty(Name))
				{
					theWriter.WriteElementString("Name", Name.Replace("\0", "").Replace("\u0010", ""));
				}
				theWriter.WriteElementString("Side", SecurityElement.Escape(((ActiveUnit)this).get_UnitSide(SetSideOnly: false).Name));
				theWriter.WriteElementString("Category", ((int)MobileUnitCategory).ToString());
				theWriter.WriteElementString("Echelon", ((int)Echelon).ToString());
				theWriter.WriteElementString("Suppression", XmlConvert.ToString(_Suppression));
				theWriter.WriteElementString("HQ", string_4);
				theWriter.WriteElementString("Friction", XmlConvert.ToString(_FrictionModifier));
				theWriter.WriteElementString("CH", XmlConvert.ToString(CurrentHeading));
				theWriter.WriteElementString("CS", XmlConvert.ToString(CurrentSpeed));
				theWriter.WriteElementString("Lon", XmlConvert.ToString(((ActiveUnit)this).get_Longitude((GlobalVariables.BooleanObject)null)));
				theWriter.WriteElementString("Lat", XmlConvert.ToString(((ActiveUnit)this).get_Latitude((GlobalVariables.BooleanObject)null)));
				LastReportedInfoToXML(ref theWriter);
				if (_Status != _ActiveUnitStatus.Unassigned)
				{
					XmlWriter obj = theWriter;
					byte status = (byte)_Status;
					obj.WriteElementString("Status", status.ToString());
				}
				if (dictionary_0.Count > 0)
				{
					theWriter.WriteStartElement("AssignedRoster");
					foreach (KeyValuePair<string, int> item in dictionary_0)
					{
						theWriter.WriteElementString("i", item.Key + "_" + Conversions.ToString(item.Value));
					}
					theWriter.WriteEndElement();
				}
				if (dictionary_2.Count > 0)
				{
					theWriter.WriteStartElement("ActualRoster");
					foreach (KeyValuePair<string, (ActiveUnit, int)> item2 in dictionary_2)
					{
						theWriter.WriteElementString("i", item2.Key + "_" + Conversions.ToString(item2.Value.Item2));
					}
					theWriter.WriteEndElement();
				}
				Doctrine.ToXML(ref theWriter, ref ParentScen);
				Navigator.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
				CurrentTactic.ToXML(ref theWriter);
				theWriter.WriteEndElement();
			}
			else
			{
				theWriter.WriteEndElement();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100456903409798", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private static AggregateGroundUnit smethod_1(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0, bool bool_3, AggregateGroundUnit aggregateGroundUnit_1 = null)
	{
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		AggregateGroundUnit result;
		try
		{
			AggregateGroundUnit aggregateGroundUnit = new AggregateGroundUnit(scenario_0);
			string text = Misc.GetNodeByName(xmlNode_0.ChildNodes, "ID").InnerText;
			if (Misc.ContainsChar(text, ' '))
			{
				text = text.Replace(" ", "-");
			}
			aggregateGroundUnit.ObjectID = text;
			concurrentDictionary_0.TryAdd(aggregateGroundUnit.ObjectID, aggregateGroundUnit);
			foreach (XmlNode childNode in xmlNode_0.ChildNodes)
			{
				XmlNode theNode = childNode;
				aggregateGroundUnit.CommonFromXML(theNode);
				if (!aggregateGroundUnit.isLastReportedInfoXMLField(theNode.Name))
				{
					switch (theNode.Name)
					{
					case "AssignedRoster":
						foreach (XmlNode childNode2 in theNode.ChildNodes)
						{
							string[] array2 = childNode2.InnerText.Split(new char[1] { '_' });
							string key = array2[0] + "_" + array2[1];
							int value = Conversions.ToInteger(array2[2]);
							aggregateGroundUnit.dictionary_0.Add(key, value);
						}
						break;
					case "Name":
						aggregateGroundUnit.Name = theNode.InnerText;
						break;
					case "Doctrine":
						aggregateGroundUnit.Doctrine = Doctrine.FromXML(scenario_0, ref theNode, aggregateGroundUnit);
						break;
					case "ActualRoster":
						foreach (XmlNode childNode3 in theNode.ChildNodes)
						{
							string[] array = childNode3.InnerText.Split(new char[1] { '_' });
							string annexAndDBID = array[0] + "_" + array[1];
							int amount = Conversions.ToInteger(array[2]);
							aggregateGroundUnit.AddOrRemoveActualRoster(annexAndDBID, amount);
						}
						break;
					case "CS":
						aggregateGroundUnit.CurrentSpeed = XmlConvert.ToSingle(theNode.InnerText);
						break;
					case "CH":
						aggregateGroundUnit.CurrentHeading = XmlConvert.ToSingle(theNode.InnerText);
						break;
					case "HQ":
						aggregateGroundUnit.string_4 = theNode.InnerText;
						break;
					case "Longitude":
					case "Lon":
						aggregateGroundUnit._Longitude = XmlConvert.ToDouble(theNode.InnerText.Replace(",", "."));
						break;
					case "Suppression":
						aggregateGroundUnit.Suppression = XmlConvert.ToSingle(theNode.InnerText.Replace(",", "."));
						break;
					case "Category":
						aggregateGroundUnit.MobileUnitCategory = (IMobileGroundUnit._MobileUnitCategory)Conversions.ToInteger(theNode.InnerText);
						break;
					case "Side":
						aggregateGroundUnit._SideName = theNode.InnerText;
						break;
					case "Echelon":
						aggregateGroundUnit.Echelon = (GroundEchelonLevel)Conversions.ToShort(theNode.InnerText);
						break;
					case "Latitude":
					case "Lat":
						aggregateGroundUnit._Latitude = XmlConvert.ToDouble(theNode.InnerText.Replace(",", "."));
						break;
					case "Friction":
						aggregateGroundUnit._FrictionModifier = XmlConvert.ToSingle(theNode.InnerText.Replace(",", "."));
						break;
					case "Navigator":
					{
						ActiveUnit theAU = aggregateGroundUnit;
						aggregateGroundUnit.aggregateGroundUnit_Navigator_0 = AggregateGroundUnit_Navigator.FromXML(ref theNode, ref concurrentDictionary_0, ref theAU);
						break;
					}
					case "Tactic":
						aggregateGroundUnit.agu_Tactic_0 = AGU_Tactic.FromXML(ref theNode);
						break;
					}
				}
				else
				{
					aggregateGroundUnit.LastReportedInfoFromXMLField(theNode.Name, theNode.InnerText);
				}
			}
			((ActiveUnit)aggregateGroundUnit).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)Terrain.GetElevation(((ActiveUnit)aggregateGroundUnit).get_Latitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)aggregateGroundUnit).get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, scenario_0));
			result = aggregateGroundUnit;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 10054451", "");
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

	public static AggregateGroundUnit FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref Scenario theScen)
	{
		AggregateGroundUnit aggregateGroundUnit;
		AggregateGroundUnit result;
		try
		{
			aggregateGroundUnit = smethod_1(ref theNode, ref theDictionary, ref theScen, theScen.LoadStockUnits);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 1007574", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = null;
			ProjectData.ClearProjectError();
			goto IL_0055;
		}
		result = aggregateGroundUnit;
		goto IL_0055;
		IL_0055:
		return result;
	}

	public static float GetMaximumCohesiveSpeed(Scenario ParentScen, List<string> Units)
	{
		HashSet<string> hashSet = new HashSet<string>();
		foreach (string Unit in Units)
		{
			Facility Facility = null;
			Vehicle Vehicle = null;
			if (!hashSet.Contains(Unit))
			{
				GetUnit(ParentScen, Unit, ref Facility, ref Vehicle);
				if (Facility != null)
				{
				}
				hashSet.Add(Unit);
			}
		}
		float result = default(float);
		return result;
	}

	public XSection[] GetXSections()
	{
		Dictionary<XSection._SignatureType, (float, float, float, float)> dictionary = new Dictionary<XSection._SignatureType, (float, float, float, float)>();
		float num = Math.Max((100f - Damage.DamagePercent) * 0.01f, 0.1f);
		foreach (KeyValuePair<string, (ActiveUnit, int)> item in dictionary_2)
		{
			XSection[] xSections = DBFunctions.GetXSections(item.Value.Item1);
			foreach (XSection xSection in xSections)
			{
				(float, float, float, float) rawValues = xSection.GetRawValues((float)item.Value.Item2 * num);
				if (dictionary.ContainsKey(xSection.SignatureType))
				{
					(float, float, float, float) tuple = dictionary[xSection.SignatureType];
					dictionary[xSection.SignatureType] = (tuple.Item1 + rawValues.Item1, tuple.Item2 + rawValues.Item2, tuple.Item3 + rawValues.Item3, tuple.Item4 + rawValues.Item4);
				}
				else
				{
					dictionary.Add(xSection.SignatureType, (rawValues.Item1, rawValues.Item2, rawValues.Item3, rawValues.Item4));
				}
			}
		}
		XSection[] array = new XSection[dictionary.Count - 1 + 1];
		int num2 = array.Length - 1;
		for (int j = 0; j <= num2; j++)
		{
			KeyValuePair<XSection._SignatureType, (float, float, float, float)> keyValuePair = dictionary.ElementAt(j);
			array[j] = new XSection(keyValuePair.Key, keyValuePair.Value.Item1, keyValuePair.Value.Item2, keyValuePair.Value.Item3, keyValuePair.Value.Item4);
		}
		return array;
	}

	public void BreakdownToIndividualUnits()
	{
		foreach (KeyValuePair<string, (ActiveUnit, int)> item in dictionary_2)
		{
			int num = item.Value.Item2 - 1;
			for (int i = 0; i <= num; i++)
			{
				method_29(item.Key);
			}
		}
		Destroy(ScenEditAction: true, IsFacilityAimpoint: false, DestroyUnitNow: true, "AGU Breakdown", null, RegisterAsLosses: false);
	}

	[SpecialName]
	IMobileGroundUnit._MobileUnitCategory IMobileGroundUnit.get_MobileUnitCategory()
	{
		return MobileUnitCategory;
	}

	[SpecialName]
	void IMobileGroundUnit.set_MobileUnitCategory(IMobileGroundUnit._MobileUnitCategory value)
	{
		MobileUnitCategory = value;
	}

	public List<ActiveUnit> FetchAllActualActiveUnits(bool IncludeDepletedRoster = false)
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		foreach (KeyValuePair<string, (ActiveUnit, int)> item in dictionary_2)
		{
			if (IncludeDepletedRoster || item.Value.Item2 > 0)
			{
				list.Add(item.Value.Item1);
			}
		}
		return list;
	}

	public DataRow GetActualRoster(int Index)
	{
		if (Index <= dictionary_2.Count - 1)
		{
			return GetUnitData(ParentScen, dictionary_2.ElementAt(Index).Key);
		}
		return null;
	}

	public DataRow GetActualRosterData(int Index)
	{
		if (Index > dictionary_2.Count - 1)
		{
			return null;
		}
		return GetUnitData(ParentScen, dictionary_2.ElementAt(Index).Key);
	}

	public DataRow GetAssignedRosterData(int Index)
	{
		if (Index > dictionary_0.Count - 1)
		{
			return null;
		}
		return GetUnitData(ParentScen, dictionary_0.ElementAt(Index).Key);
	}

	public static string GetAnnexAndDBID(int SDBID, GlobalVariables.ActiveUnitType UnitType)
	{
		return UnitType switch
		{
			GlobalVariables.ActiveUnitType.Vehicle => "Vehicle_" + Conversions.ToString(SDBID), 
			GlobalVariables.ActiveUnitType.Facility => "Facility_" + Conversions.ToString(SDBID), 
			_ => string.Empty, 
		};
	}

	public static DataRow GetUnitData(Scenario ParentScen, string RosterKey)
	{
		string[] array = RosterKey.Split(new char[1] { '_' });
		switch (array[0])
		{
		case "Facility":
			return DBFunctions.GetUnitData_RAW(ref ParentScen, GlobalVariables.ActiveUnitType.Facility, Conversions.ToInteger(array[1]));
		default:
			return null;
		case "Vehicle":
		case "GroundUnit":
			return DBFunctions.GetUnitData_RAW(ref ParentScen, GlobalVariables.ActiveUnitType.Vehicle, Conversions.ToInteger(array[1]));
		}
	}

	public static ActiveUnit GetUnit(Scenario ParentScen, string RosterKey, ref Facility Facility, ref Vehicle Vehicle)
	{
		string[] array = RosterKey.Split(new char[1] { '_' });
		switch (array[0])
		{
		default:
			return null;
		case "Vehicle":
		case "GroundUnit":
			Vehicle = new Vehicle(ref ParentScen, "");
			DBFunctions.GetVehicle(ref ParentScen, ref Vehicle, Conversions.ToInteger(array[1]));
			return Vehicle;
		case "Facility":
			Facility = new Facility(ref ParentScen, "");
			DBFunctions.GetFacility(ref ParentScen, ref Facility, Conversions.ToInteger(array[1]));
			return Facility;
		}
	}

	public ActiveUnit GetUnit(string RosterKey, ref Facility Facility, ref Vehicle Vehicle)
	{
		string[] array = RosterKey.Split(new char[1] { '_' });
		switch (array[0])
		{
		default:
			return null;
		case "Vehicle":
		case "GroundUnit":
			Vehicle = new Vehicle(ref ParentScen, "");
			Vehicle.aggregateGroundUnit_0 = this;
			DBFunctions.GetVehicle(ref ParentScen, ref Vehicle, Conversions.ToInteger(array[1]));
			return Vehicle;
		case "Facility":
			Facility = new Facility(ref ParentScen, "");
			Facility.aggregateGroundUnit_0 = this;
			DBFunctions.GetFacility(ref ParentScen, ref Facility, Conversions.ToInteger(array[1]));
			return Facility;
		}
	}

	public ProfileType GetProfile()
	{
		return GetProfile(MobileUnitCategory);
	}

	public static ProfileType GetProfile(IMobileGroundUnit._MobileUnitCategory cat)
	{
		int result;
		int result2;
		if (cat <= IMobileGroundUnit._MobileUnitCategory.Mountain)
		{
			if ((uint)(cat - 1000) > 1u && cat != IMobileGroundUnit._MobileUnitCategory.Marines && cat != IMobileGroundUnit._MobileUnitCategory.Mountain)
			{
				result = 1;
				goto IL_0056;
			}
		}
		else if (cat <= IMobileGroundUnit._MobileUnitCategory.Special_Forces)
		{
			if (cat != IMobileGroundUnit._MobileUnitCategory.Airborne && cat != IMobileGroundUnit._MobileUnitCategory.Special_Forces)
			{
				result = 1;
				goto IL_0056;
			}
		}
		else if (cat != IMobileGroundUnit._MobileUnitCategory.Surveillance)
		{
			if (cat == IMobileGroundUnit._MobileUnitCategory.Recon)
			{
				result2 = 0;
				goto IL_005a;
			}
			result = 1;
			goto IL_0056;
		}
		result2 = 0;
		goto IL_005a;
		IL_005a:
		return (ProfileType)result2;
		IL_0056:
		return (ProfileType)result;
	}

	public Module_Unit.Unit GetUnit()
	{
		return this;
	}

	public void SpecialAGUAction()
	{
	}

	public bool IsArtillery()
	{
		return false;
	}

	static AggregateGroundUnit()
	{
		Class72.smethod_20();
	}
}
