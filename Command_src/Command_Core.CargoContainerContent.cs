using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security;
using System.Text;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class CargoContainerContent : ScenarioObject, ICargoClient
{
	public enum CargoContainerContentType
	{
		Generic,
		Ammunition,
		LiquidFuel
	}

	public ICargoHost Parent;

	public CargoContainerContentType ContentType;

	public CargoType Size;

	public float Mass;

	public float Area;

	public float Height;

	public float Volume;

	public float Crew;

	public CargoContainerContent()
	{
	}

	public CargoContainerContent(CargoContainerContent CopyMe)
	{
		Name = CopyMe.Name;
		Parent = CopyMe.Parent;
		ContentType = CopyMe.ContentType;
		Size = CopyMe.Size;
		Mass = CopyMe.Mass;
		Area = CopyMe.Area;
		Height = CopyMe.Height;
		Volume = CopyMe.Volume;
		Crew = CopyMe.Crew;
	}

	public virtual bool TransferToUnit(ActiveUnit UnloadingUnit, ActiveUnit DestinationUnit, Cargo Cargo = null, float Quantity = 0f)
	{
		return false;
	}

	public virtual bool TransferFromUnit(CargoContainer theContainer, ActiveUnit FromUnit, Cargo Cargo = null, float Quantity = 0f)
	{
		return false;
	}

	public virtual void imethod_1()
	{
		ResetIDs();
	}

	public virtual void DestroyCargoObject(Side ComponentPlatformSide, bool ScenEditAction, bool IsFacilityAimpoint, bool DestroyUnitNow, string theReason, string WhatCausedIt = null, bool RegisterAsLosses = true)
	{
	}

	public virtual CargoType GetRequiredCargoType()
	{
		return Size;
	}

	public virtual float GetRequiredCrewSpace()
	{
		return Crew;
	}

	public virtual float GetRequiredArea()
	{
		return Area;
	}

	public virtual float GetRequiredAreaStacked(ICargoHost Host, int TotalQuantity)
	{
		return GetRequiredArea() * (float)TotalQuantity;
	}

	public virtual float GetRequiredMass()
	{
		return Mass;
	}

	public virtual bool GetParadropCapable()
	{
		return false;
	}

	public virtual string GetCargoName()
	{
		if (string.IsNullOrEmpty(Name) && ContentType == CargoContainerContentType.Generic)
		{
			int num = (int)Math.Round(Mass * 1000f);
			if (SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo)
			{
				return "Generic Cargo (" + (int)Math.Round(Cargo.DisplayValueSmallMass(num, USUnits: true)) + "lbs)";
			}
			return "Generic Cargo (" + num + "kg)";
		}
		return Name;
	}

	public virtual string GetCargoObjectID()
	{
		return ObjectID;
	}

	public virtual int imethod_0()
	{
		return 0;
	}

	public virtual PlatformComponent._ComponentStatus GetCargoObjectStatus()
	{
		return PlatformComponent._ComponentStatus.Operational;
	}

	public virtual PlatformComponent._DamageSeverityFactor GetCargoObjectDamageSeverity()
	{
		return PlatformComponent._DamageSeverityFactor.Light;
	}

	public virtual string GetCargoObjectReasonForInoperative()
	{
		return "None";
	}

	public virtual string GetCargoObjectLossString()
	{
		return null;
	}

	public virtual bool IsStackable()
	{
		return false;
	}

	public virtual float GetRequiredHeight()
	{
		return 0f;
	}

	public virtual int GetCargoQuantity()
	{
		return 1;
	}

	public virtual bool isMatch(Cargo c)
	{
		return false;
	}

	public virtual bool isMatch(CargoContainerContent c)
	{
		return false;
	}

	public virtual bool isExactMatch(CargoContainerContent c)
	{
		return false;
	}

	public virtual float GetQuantityDifference(CargoContainerContent c)
	{
		return 0f;
	}

	public virtual void SetQuantity(float theQuantity)
	{
	}

	public virtual CargoContainerContent CreateNewContentMatching(float NewQuantity)
	{
		CargoContainerContent cargoContainerContent = null;
		switch (ContentType)
		{
		case CargoContainerContentType.Generic:
			cargoContainerContent = new CargoContainerContent();
			break;
		case CargoContainerContentType.Ammunition:
			cargoContainerContent = new CargoAmmunition
			{
				int_1 = ((CargoAmmunition)this).int_1,
				WeaponQuantity = (int)Math.Round(NewQuantity)
			};
			break;
		case CargoContainerContentType.LiquidFuel:
			cargoContainerContent = new CargoLiquidFuel
			{
				FuelType = ((CargoLiquidFuel)this).FuelType,
				CurrentQuantity = NewQuantity
			};
			break;
		}
		if (cargoContainerContent != null)
		{
			cargoContainerContent.Name = Name;
			cargoContainerContent.Size = Size;
			cargoContainerContent.Mass = Mass;
			cargoContainerContent.Area = Area;
			cargoContainerContent.Volume = Volume;
			cargoContainerContent.Crew = Crew;
		}
		return cargoContainerContent;
	}

	public virtual string CargoObjectToXML(HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("<CargoContainerContent>");
			stringBuilder.Append("<ID>").Append(ObjectID).Append("</ID>");
			if (ObjectsAlreadySerialized != null)
			{
				if (ObjectsAlreadySerialized.Contains(ObjectID))
				{
					stringBuilder.Append("</CargoContainerContent>");
					return stringBuilder.ToString();
				}
				ObjectsAlreadySerialized.Add(ObjectID);
			}
			if (!string.IsNullOrEmpty(Name))
			{
				stringBuilder.Append("<Name>").Append(SecurityElement.Escape(Name)).Append("</Name>");
			}
			StringBuilder stringBuilder2 = stringBuilder.Append("<CCCT>");
			int contentType = (int)ContentType;
			stringBuilder2.Append(contentType.ToString()).Append("</CCCT>");
			if (Size != CargoType.NoCargo)
			{
				StringBuilder stringBuilder3 = stringBuilder.Append("<CT>");
				contentType = (int)Size;
				stringBuilder3.Append(contentType.ToString()).Append("</CT>");
			}
			if (Mass > 0f)
			{
				stringBuilder.Append("<CCCM>").Append(XmlConvert.ToString(Mass)).Append("</CCCM>");
			}
			if (Area > 0f)
			{
				stringBuilder.Append("<CCCA>").Append(XmlConvert.ToString(Area)).Append("</CCCA>");
			}
			if (Volume > 0f)
			{
				stringBuilder.Append("<CCCV>").Append(XmlConvert.ToString(Volume)).Append("</CCCV>");
			}
			if (Height > 0f)
			{
				stringBuilder.Append("<CCCH>").Append(XmlConvert.ToString(Height)).Append("</CCCH>");
			}
			if (Crew > 0f)
			{
				stringBuilder.Append("<CCCC>").Append(XmlConvert.ToString(Crew)).Append("</CCCC>");
			}
			switch (ContentType)
			{
			case CargoContainerContentType.LiquidFuel:
				stringBuilder.Append(((CargoLiquidFuel)this).SubclassToXML(ObjectsAlreadySerialized, theScen));
				break;
			case CargoContainerContentType.Ammunition:
				stringBuilder.Append(((CargoAmmunition)this).SubclassToXML(ObjectsAlreadySerialized, theScen));
				break;
			}
			stringBuilder.Append("</CargoContainerContent>");
			return stringBuilder.ToString();
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

	public virtual bool WantsToUnload()
	{
		return false;
	}

	public virtual bool IsTowable()
	{
		return false;
	}

	public static CargoContainerContent FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen, ActiveUnit theAU, ICargoHost theContainer = null)
	{
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		CargoContainerContent result;
		try
		{
			CargoContainerContent cargoContainerContent = null;
			CargoContainerContentType cargoContainerContentType = (CargoContainerContentType)Conversions.ToInteger(Misc.GetNodeByName(theNode.ChildNodes, "CCCT").InnerText);
			switch (cargoContainerContentType)
			{
			case CargoContainerContentType.Generic:
				cargoContainerContent = new CargoContainerContent();
				break;
			case CargoContainerContentType.Ammunition:
				cargoContainerContent = new CargoAmmunition();
				break;
			case CargoContainerContentType.LiquidFuel:
				cargoContainerContent = new CargoLiquidFuel();
				break;
			}
			cargoContainerContent.Parent = theContainer;
			string innerText = Misc.GetNodeByName(theNode.ChildNodes, "ID").InnerText;
			if (Information.IsNothing((object)theDictionary))
			{
				goto IL_00a9;
			}
			if (!theDictionary.ContainsKey(innerText))
			{
				cargoContainerContent.ObjectID_Set(innerText);
				theDictionary.TryAdd(cargoContainerContent.ObjectID, cargoContainerContent);
				goto IL_00a9;
			}
			result = (CargoContainerContent)theDictionary[innerText];
			goto end_IL_0001;
			IL_00a9:
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				try
				{
					switch (val.Name)
					{
					case "CCCM":
						cargoContainerContent.Mass = XmlConvert.ToSingle(val.InnerText);
						break;
					case "CCCH":
						cargoContainerContent.Height = XmlConvert.ToSingle(val.InnerText);
						break;
					case "CCCV":
						cargoContainerContent.Volume = XmlConvert.ToSingle(val.InnerText);
						break;
					case "CCCT":
						cargoContainerContent.ContentType = (CargoContainerContentType)Conversions.ToInteger(val.InnerText);
						break;
					case "CT":
						cargoContainerContent.Size = (CargoType)Conversions.ToInteger(val.InnerText);
						break;
					case "Name":
						cargoContainerContent.Name = val.InnerText;
						break;
					case "CCCC":
						cargoContainerContent.Crew = XmlConvert.ToSingle(val.InnerText);
						break;
					case "CCCA":
						cargoContainerContent.Area = XmlConvert.ToSingle(val.InnerText);
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
			switch (cargoContainerContentType)
			{
			case CargoContainerContentType.LiquidFuel:
				((CargoLiquidFuel)cargoContainerContent).SubclassFromXML(ref theNode, ref theDictionary);
				break;
			case CargoContainerContentType.Ammunition:
				((CargoAmmunition)cargoContainerContent).SubclassFromXML(ref theNode, ref theDictionary);
				break;
			}
			result = cargoContainerContent;
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

	static CargoContainerContent()
	{
		Class72.smethod_20();
	}
}
