using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Text;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ServiceStack.Text;

namespace Command_Core;

public class CargoContainer : PlatformComponent, ICargoHost, ICargoClient
{
	public enum CargoContainerType
	{
		None = 0,
		Standard = 1001,
		OpenTop = 1002,
		Tank = 2001,
		Pallet = 3001
	}

	public readonly CargoContainerType ContainerType;

	public readonly float Length;

	public readonly float Width;

	public readonly float Height;

	public readonly float Weight;

	public readonly float PayloadMass;

	public readonly float PayloadVolume;

	public readonly bool isHold;

	private CargoType cargoType_0;

	private float float_0;

	private float float_1;

	private float float_2;

	private bool bool_0;

	private CargoType cargoType_1;

	private float float_3;

	private float float_4;

	private float float_5;

	private bool bool_1;

	private float float_6;

	public Cargo[] OnboardCargo;

	public ICargoHost Parent;

	private float float_7;

	private float float_8;

	private float float_9;

	private float float_10;

	public Cargo[] CargoArray
	{
		get
		{
			return OnboardCargo;
		}
		set
		{
			OnboardCargo = value;
		}
	}

	public CargoContainer(CargoContainerType type, CargoType cargoSize, float len, float wid, float hgt, float wgt, float payloadCap, float payloadVol, bool hold, bool paradropCapacity, bool canbeParadropped)
	{
		OnboardCargo = new Cargo[0];
		ContainerType = type;
		Length = len;
		Width = wid;
		Height = hgt;
		Weight = wgt;
		PayloadMass = payloadCap;
		PayloadVolume = payloadVol;
		isHold = hold;
		cargoType_0 = cargoSize;
		float_0 = DBFunctions.GetCargoContainerArea(Length, Width);
		float_1 = PayloadMass / 1000f;
		float_2 = 0f;
		bool_0 = paradropCapacity;
		cargoType_1 = cargoType_0;
		float_3 = float_0;
		float_4 = Weight / 1000f;
		float_5 = 0f;
		float_6 = float_3 * Height;
		bool_1 = canbeParadropped;
	}

	public void RecalculateCurrentLoad()
	{
		float_7 = 0f;
		float_8 = 0f;
		float_9 = 0f;
		Cargo[] onboardCargo = OnboardCargo;
		foreach (Cargo cargo in onboardCargo)
		{
			float_7 += cargo.RequiredArea;
			float_8 += cargo.RequiredMass;
			float_9 += cargo.RequiredCrewSpace;
		}
	}

	internal float GetCargo_Crew()
	{
		return float_2;
	}

	float ICargoHost.GetCargo_Crew()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetCargo_Crew
		return this.GetCargo_Crew();
	}

	internal float GetCargo_Area()
	{
		return float_0;
	}

	float ICargoHost.GetCargo_Area()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetCargo_Area
		return this.GetCargo_Area();
	}

	internal CargoType GetCargo_Type()
	{
		return cargoType_0;
	}

	CargoType ICargoHost.GetCargo_Type()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetCargo_Type
		return this.GetCargo_Type();
	}

	internal float GetCargo_Mass()
	{
		return float_1;
	}

	float ICargoHost.GetCargo_Mass()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetCargo_Mass
		return this.GetCargo_Mass();
	}

	public float GetCargo_TowingCapacity()
	{
		return 0f;
	}

	public float GetCargo_MassAvailable()
	{
		return CargoHostHelper.GetAvailableMass(this, OnboardCargo);
	}

	internal bool GetCargo_ParadropCapable()
	{
		return bool_0;
	}

	bool ICargoHost.GetCargo_ParadropCapable()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetCargo_ParadropCapable
		return this.GetCargo_ParadropCapable();
	}

	internal bool CanStackCargo()
	{
		return Height > 0f;
	}

	bool ICargoHost.CanStackCargo()
	{
		//ILSpy generated this explicit interface implementation from .override directive in CanStackCargo
		return this.CanStackCargo();
	}

	public float GetCargo_Height()
	{
		return Height;
	}

	internal int GetLoadTime(List<Cargo> CargoItems)
	{
		return ActiveUnit_DockingOps.DEFAULT_CARGO_LOAD_TIME;
	}

	int ICargoHost.GetLoadTime(List<Cargo> CargoItems)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetLoadTime
		return this.GetLoadTime(CargoItems);
	}

	internal int GetUnloadTime(List<Cargo> CargoItems)
	{
		return ActiveUnit_DockingOps.DEFAULT_CARGO_UNLOAD_TIME;
	}

	int ICargoHost.GetUnloadTime(List<Cargo> CargoItems)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetUnloadTime
		return this.GetUnloadTime(CargoItems);
	}

	internal bool CanLoad(ICargoClient PotentialCargo)
	{
		bool flag = false;
		CargoContainerContent cargoContainerContent = null;
		if (Parent != null && PotentialCargo.GetRequiredMass() > Parent.GetCargo_MassAvailable())
		{
			return false;
		}
		if (PotentialCargo is CargoContainerContent)
		{
			cargoContainerContent = (CargoContainerContent)PotentialCargo;
			flag = cargoContainerContent.ContentType == CargoContainerContent.CargoContainerContentType.LiquidFuel;
		}
		if (ContainerType == CargoContainerType.Tank)
		{
			if (flag)
			{
				CargoLiquidFuel cargoLiquidFuel = (CargoLiquidFuel)cargoContainerContent;
				float num = PayloadVolume;
				if (OnboardCargo.Count() > 0)
				{
					if (OnboardCargo[0].CargoObjectContainerContents == null)
					{
						num = 0f;
					}
					else
					{
						CargoLiquidFuel cargoLiquidFuel2 = (CargoLiquidFuel)OnboardCargo[0].CargoObjectContainerContents;
						if (cargoLiquidFuel2 != null)
						{
							if (cargoLiquidFuel2.FuelType != cargoLiquidFuel.FuelType)
							{
								return false;
							}
							num -= cargoLiquidFuel2.Volume;
						}
						else
						{
							num = 0f;
						}
					}
				}
				if (cargoLiquidFuel.Volume <= num)
				{
					return true;
				}
			}
		}
		else if (!flag)
		{
			return CargoHostHelper.CanLoad(this, OnboardCargo, PotentialCargo);
		}
		return false;
	}

	bool ICargoHost.CanLoad(ICargoClient PotentialCargo)
	{
		//ILSpy generated this explicit interface implementation from .override directive in CanLoad
		return this.CanLoad(PotentialCargo);
	}

	public bool Add(Cargo c)
	{
		if (CanLoad(c.GetCargoClient))
		{
			if (ContainerType == CargoContainerType.Tank)
			{
				if (OnboardCargo.Count() > 0)
				{
					CargoLiquidFuel obj = (CargoLiquidFuel)OnboardCargo[0].GetCargoClient;
					CargoLiquidFuel cargoLiquidFuel = (CargoLiquidFuel)c.GetCargoClient;
					obj.CurrentQuantity += cargoLiquidFuel.CurrentQuantity;
					RecalculateCurrentLoad();
					return true;
				}
			}
			else if (c.CurrentType == Cargo.CargoObjectType.CargoContainerContent && c.CargoObjectContainerContents.ContentType == CargoContainerContent.CargoContainerContentType.Ammunition)
			{
				CargoAmmunition cargoAmmunition = (CargoAmmunition)c.CargoObjectContainerContents;
				Cargo[] onboardCargo = OnboardCargo;
				foreach (Cargo cargo in onboardCargo)
				{
					if (cargo.CurrentType == Cargo.CargoObjectType.CargoContainerContent && cargo.CargoObjectContainerContents.ContentType == CargoContainerContent.CargoContainerContentType.Ammunition)
					{
						CargoAmmunition cargoAmmunition2 = (CargoAmmunition)cargo.CargoObjectContainerContents;
						if (cargoAmmunition.int_1 == cargoAmmunition2.int_1)
						{
							cargoAmmunition2.WeaponQuantity += cargoAmmunition.WeaponQuantity;
							RecalculateCurrentLoad();
							return true;
						}
					}
				}
			}
			ArrayExtensions.Add(ref OnboardCargo, c);
			RecalculateCurrentLoad();
			return true;
		}
		return false;
	}

	public bool Remove(Cargo c)
	{
		if (!OnboardCargo.Contains(c))
		{
			return false;
		}
		ArrayExtensions.Remove(ref OnboardCargo, c);
		RecalculateCurrentLoad();
		return true;
	}

	public bool CanTow(ICargoClient PotentialCargo)
	{
		return false;
	}

	public void imethod_1()
	{
		Cargo[] onboardCargo = OnboardCargo;
		for (int i = 0; i < onboardCargo.Length; i = checked(i + 1))
		{
			onboardCargo[i].ResetIDs();
		}
		ResetIDs();
	}

	public void DestroyCargoObject(Side ComponentPlatformSide, bool ScenEditAction, bool IsFacilityAimpoint, bool DestroyUnitNow, string theReason, string WhatCausedIt = null, bool RegisterAsLosses = true)
	{
		Cargo[] onboardCargo = OnboardCargo;
		for (int i = 0; i < onboardCargo.Length; i = checked(i + 1))
		{
			onboardCargo[i].Destroy(ComponentPlatformSide, ScenEditAction, IsFacilityAimpoint);
		}
		Destroy(ComponentPlatformSide, ScenEditAction, IsFacilityAimpoint);
	}

	internal CargoType GetRequiredCargoType()
	{
		CargoContainerType containerType = ContainerType;
		if (containerType != CargoContainerType.OpenTop && containerType != CargoContainerType.Pallet)
		{
			return cargoType_1;
		}
		return cargoType_1;
	}

	CargoType ICargoClient.GetRequiredCargoType()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetRequiredCargoType
		return this.GetRequiredCargoType();
	}

	internal float GetRequiredCrewSpace()
	{
		return float_5;
	}

	float ICargoClient.GetRequiredCrewSpace()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetRequiredCrewSpace
		return this.GetRequiredCrewSpace();
	}

	internal float GetRequiredArea()
	{
		return float_3;
	}

	float ICargoClient.GetRequiredArea()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetRequiredArea
		return this.GetRequiredArea();
	}

	public float GetRequiredAreaStacked(ICargoHost Host, int TotalQuantity)
	{
		return GetRequiredArea() * (float)TotalQuantity;
	}

	internal float GetRequiredMass()
	{
		return float_4 + float_8;
	}

	float ICargoClient.GetRequiredMass()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetRequiredMass
		return this.GetRequiredMass();
	}

	internal bool GetParadropCapable()
	{
		return bool_1;
	}

	bool ICargoClient.GetParadropCapable()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetParadropCapable
		return this.GetParadropCapable();
	}

	internal string GetCargoName()
	{
		if (OnboardCargo.Count() > 0)
		{
			string text = Name + " (";
			ActiveUnit activeUnit = null;
			CargoContainerContent cargoContainerContent = null;
			int num = OnboardCargo.Count();
			int num2 = num - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (OnboardCargo[i].CargoObjectContainerContents == null)
				{
					if (OnboardCargo[i].CargoObjectActiveUnit != null)
					{
						activeUnit = OnboardCargo[i].CargoObjectActiveUnit;
						text += activeUnit.Name;
						if (i < num - 1)
						{
							text += ", ";
						}
					}
				}
				else
				{
					cargoContainerContent = OnboardCargo[i].CargoObjectContainerContents;
					text = text + cargoContainerContent.GetRequiredMass().ToString("N2") + "t " + cargoContainerContent.Name;
					if (i < num - 1)
					{
						text += ", ";
					}
				}
			}
			return text + ")";
		}
		return Name;
	}

	string ICargoClient.GetCargoName()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetCargoName
		return this.GetCargoName();
	}

	internal string GetCargoObjectID()
	{
		return ObjectID;
	}

	string ICargoClient.GetCargoObjectID()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetCargoObjectID
		return this.GetCargoObjectID();
	}

	internal int imethod_0()
	{
		return DBID;
	}

	int ICargoClient.imethod_0()
	{
		//ILSpy generated this explicit interface implementation from .override directive in imethod_0
		return this.imethod_0();
	}

	internal _ComponentStatus GetCargoObjectStatus()
	{
		return base.Status;
	}

	_ComponentStatus ICargoClient.GetCargoObjectStatus()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetCargoObjectStatus
		return this.GetCargoObjectStatus();
	}

	internal _DamageSeverityFactor GetCargoObjectDamageSeverity()
	{
		return base.DamageSeverity;
	}

	_DamageSeverityFactor ICargoClient.GetCargoObjectDamageSeverity()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetCargoObjectDamageSeverity
		return this.GetCargoObjectDamageSeverity();
	}

	internal string GetCargoObjectReasonForInoperative()
	{
		return ReasonForInoperative.ResponseString;
	}

	string ICargoClient.GetCargoObjectReasonForInoperative()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetCargoObjectReasonForInoperative
		return this.GetCargoObjectReasonForInoperative();
	}

	internal string GetCargoObjectLossString()
	{
		return "Container_" + DBID;
	}

	string ICargoClient.GetCargoObjectLossString()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetCargoObjectLossString
		return this.GetCargoObjectLossString();
	}

	internal string CargoObjectToXML(HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		return ToXML(ref ObjectsAlreadySerialized, theScen);
	}

	string ICargoClient.CargoObjectToXML(HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		//ILSpy generated this explicit interface implementation from .override directive in CargoObjectToXML
		return this.CargoObjectToXML(ObjectsAlreadySerialized, theScen);
	}

	internal bool WantsToUnload()
	{
		return false;
	}

	bool ICargoClient.WantsToUnload()
	{
		//ILSpy generated this explicit interface implementation from .override directive in WantsToUnload
		return this.WantsToUnload();
	}

	internal bool IsTowable()
	{
		return false;
	}

	bool ICargoClient.IsTowable()
	{
		//ILSpy generated this explicit interface implementation from .override directive in IsTowable
		return this.IsTowable();
	}

	internal bool IsStackable()
	{
		return false;
	}

	bool ICargoClient.IsStackable()
	{
		//ILSpy generated this explicit interface implementation from .override directive in IsStackable
		return this.IsStackable();
	}

	internal float GetRequiredHeight()
	{
		return 0f;
	}

	float ICargoClient.GetRequiredHeight()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetRequiredHeight
		return this.GetRequiredHeight();
	}

	internal int GetCargoQuantity()
	{
		return 1;
	}

	int ICargoClient.GetCargoQuantity()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetCargoQuantity
		return this.GetCargoQuantity();
	}

	internal bool isMatch(Cargo c)
	{
		int result;
		if (c != null)
		{
			if (c.CargoObjectContainer == null)
			{
				result = 0;
				goto IL_0021;
			}
			if (c.CargoObjectDBID == DBID)
			{
				return true;
			}
		}
		result = 0;
		goto IL_0021;
		IL_0021:
		return (byte)result != 0;
	}

	bool ICargoClient.isMatch(Cargo c)
	{
		//ILSpy generated this explicit interface implementation from .override directive in isMatch
		return this.isMatch(c);
	}

	public string ToXML(ref HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		try
		{
			StringBuilder stringBuilder = StringBuilderCache.Allocate();
			stringBuilder.Append("<CargoContainer>");
			stringBuilder.Append("<ID>").Append(ObjectID).Append("</ID>");
			if (ObjectsAlreadySerialized != null)
			{
				if (ObjectsAlreadySerialized.Contains(ObjectID))
				{
					stringBuilder.Append("</CargoContainer>");
					return stringBuilder.ToString();
				}
				ObjectsAlreadySerialized.Add(ObjectID);
			}
			stringBuilder.Append("<DBID>").Append(DBID.ToString()).Append("</DBID>");
			if (!string.IsNullOrEmpty(Name))
			{
				stringBuilder.Append("<Name>").Append(SecurityElement.Escape(Name)).Append("</Name>");
			}
			if (_Status != _ComponentStatus.Operational)
			{
				StringBuilder stringBuilder2 = stringBuilder.Append("<Status>");
				byte status = (byte)_Status;
				stringBuilder2.Append(status.ToString()).Append("</Status>");
			}
			if (base.DamageSeverity != _DamageSeverityFactor.Light)
			{
				stringBuilder.Append("<DamageSeverity>").Append(((byte)base.DamageSeverity).ToString()).Append("</DamageSeverity>");
			}
			if (OnboardCargo.Count() > 0)
			{
				stringBuilder.Append("<OnboardCargo>");
				Cargo[] onboardCargo = OnboardCargo;
				foreach (Cargo cargo in onboardCargo)
				{
					stringBuilder.Append(cargo.ToXML(ObjectsAlreadySerialized, theScen));
				}
				stringBuilder.Append("</OnboardCargo>");
			}
			stringBuilder.Append("</CargoContainer>");
			string result = stringBuilder.ToString();
			StringBuilderCache.Free(stringBuilder);
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100901", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return "";
	}

	public static CargoContainer FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen, ActiveUnit theAU, ICargoHost theHost = null)
	{
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Expected O, but got Unknown
		CargoContainer result;
		try
		{
			CargoContainer cargoContainer = DBFunctions.GetCargoContainer(Conversions.ToInteger(Misc.GetNodeByName(theNode.ChildNodes, "DBID").InnerText), ref theScen);
			cargoContainer.Parent = theHost;
			string innerText = Misc.GetNodeByName(theNode.ChildNodes, "ID").InnerText;
			if (Information.IsNothing((object)theDictionary))
			{
				goto IL_0088;
			}
			if (!theDictionary.ContainsKey(innerText))
			{
				cargoContainer.ObjectID_Set(innerText);
				theDictionary.TryAdd(cargoContainer.ObjectID, cargoContainer);
				goto IL_0088;
			}
			result = (CargoContainer)theDictionary[innerText];
			goto end_IL_0001;
			IL_0088:
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				try
				{
					switch (val.Name)
					{
					case "Status":
						switch (val.InnerText)
						{
						case "Operational":
							cargoContainer._Status = _ComponentStatus.Operational;
							break;
						default:
							cargoContainer._Status = (_ComponentStatus)Conversions.ToByte(val.InnerText);
							break;
						case "Destroyed":
							cargoContainer._Status = _ComponentStatus.Destroyed;
							break;
						case "Damaged":
							cargoContainer._Status = _ComponentStatus.Damaged;
							break;
						}
						break;
					case "OnboardCargo":
						foreach (XmlNode childNode2 in val.ChildNodes)
						{
							XmlNode theNode2 = childNode2;
							Cargo cargo = Cargo.FromXML(ref theNode2, ref theDictionary, theScen, theAU, cargoContainer);
							ArrayExtensions.Add(ref cargoContainer.OnboardCargo, cargo);
							cargo.ParentPlatform = theAU;
						}
						break;
					case "DamageSeverity":
						cargoContainer.DamageSeverity = (_DamageSeverityFactor)Conversions.ToByte(val.InnerText);
						break;
					case "Name":
						cargoContainer.Name = val.InnerText;
						break;
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			cargoContainer.RecalculateCurrentLoad();
			result = cargoContainer;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100902", "");
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

	static CargoContainer()
	{
		Class72.smethod_20();
	}
}
