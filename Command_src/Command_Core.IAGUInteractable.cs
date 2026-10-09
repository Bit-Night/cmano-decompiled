namespace Command_Core;

public interface IAGUInteractable
{
	float CurrentCoverRating { get; set; }

	float Suppression { get; set; }

	void ResolveAGUDamages(float[] Damages, float CombatAgility, float DamageModifier, float AttackDirection_degrees = -1f, bool IgnoreArmorDeflection = false, bool IgnoreCoverDeflection = false, AggregateGroundUnit.DamageResolutioMethod TargetingType = AggregateGroundUnit.DamageResolutioMethod.Standard);

	Module_Unit.Unit GetUnit();

	float[] GetCombatProtection(float[] ArrayByRef);

	GlobalVariables.ArmorRating GetMostCommonArmorRating();

	float[] GetCombatPower(float[] ArrayByRef);

	float GetAntiAirPower();

	void SpecialAGUAction();
}
