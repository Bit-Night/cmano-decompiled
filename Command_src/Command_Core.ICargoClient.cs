using System.Collections.Generic;

namespace Command_Core;

public interface ICargoClient
{
	CargoType GetRequiredCargoType();

	float GetRequiredCrewSpace();

	float GetRequiredArea();

	float GetRequiredMass();

	bool GetParadropCapable();

	string GetCargoName();

	string GetCargoObjectID();

	int imethod_0();

	PlatformComponent._ComponentStatus GetCargoObjectStatus();

	PlatformComponent._DamageSeverityFactor GetCargoObjectDamageSeverity();

	string GetCargoObjectReasonForInoperative();

	string GetCargoObjectLossString();

	string CargoObjectToXML(HashSet<string> ObjectsAlreadySerialized, Scenario theScen);

	void imethod_1();

	void DestroyCargoObject(Side ComponentPlatformSide, bool ScenEditAction, bool IsFacilityAimpoint, bool DestroyUnitNow, string theReason, string WhatCausedIt = null, bool RegisterAsLosses = true);

	bool WantsToUnload();

	bool IsTowable();

	bool IsStackable();

	float GetRequiredHeight();

	float GetRequiredAreaStacked(ICargoHost Host, int TotalQuantity);

	bool isMatch(Cargo c);

	int GetCargoQuantity();
}
