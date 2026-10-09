using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using DarkUI.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class CustomEnvironmentZone : Zone
{
	public new bool IsLocked;

	public Weather.WeatherProfile Weather;

	[CompilerGenerated]
	private LandCover.LandCoverType landCoverType_0;

	[CompilerGenerated]
	private int int_1;

	[CompilerGenerated]
	private int int_2;

	[CompilerGenerated]
	private int int_3;

	[CompilerGenerated]
	private float float_0;

	[CompilerGenerated]
	private float float_1;

	protected int _CustomTerrainHeight;

	public LandCover.LandCoverType TerrainType
	{
		[CompilerGenerated]
		get
		{
			return landCoverType_0;
		}
		[CompilerGenerated]
		set
		{
			landCoverType_0 = value;
		}
	}

	public SonarModel.ThermoclineLayer ThermalLayer => new SonarModel.ThermoclineLayer
	{
		Ceiling = ThermalLayerCeiling,
		Floor = ThermalLayerFloor,
		Strength = LayerStrength
	};

	public int ThermalLayerFloor
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	public int ThermalLayerCeiling
	{
		[CompilerGenerated]
		get
		{
			return int_2;
		}
		[CompilerGenerated]
		set
		{
			int_2 = value;
		}
	}

	public int DayNightTemperatureModifier
	{
		[CompilerGenerated]
		get
		{
			return int_3;
		}
		[CompilerGenerated]
		set
		{
			int_3 = value;
		}
	}

	public float LayerStrength
	{
		[CompilerGenerated]
		get
		{
			return float_0;
		}
		[CompilerGenerated]
		set
		{
			float_0 = value;
		}
	}

	public float CZInterval
	{
		[CompilerGenerated]
		get
		{
			return float_1;
		}
		[CompilerGenerated]
		set
		{
			float_1 = value;
		}
	}

	public override ZoneType Type => ZoneType.CustomEnvironmentZone;

	public bool HasCustomTerrain => TerrainType != LandCover.LandCoverType.Use_Underlying_Values;

	public bool HasCustomTerrainHeight => _CustomTerrainHeight > int.MinValue;

	public int TerrainHeight
	{
		get
		{
			if (_CustomTerrainHeight > int.MinValue)
			{
				return _CustomTerrainHeight;
			}
			return LandCover.GetHeight_LandCoverType(TerrainType);
		}
		set
		{
			_CustomTerrainHeight = value;
		}
	}

	public void RemoveCustomTerrainHeight()
	{
		_CustomTerrainHeight = int.MinValue;
	}

	public CustomEnvironmentZone(string theDescription, List<ReferencePoint> theArea, Scenario theScen, Side theSide, Weather.WeatherProfile theWeather, List<GlobalVariables.ActiveUnitType> theAffectedUnitTypes = null)
	{
		TerrainType = LandCover.LandCoverType.Use_Underlying_Values;
		_CustomTerrainHeight = int.MinValue;
		theScen.CreateNatureSideIfNeeded();
		Description = theDescription;
		base.Area = new ObservableList<ReferencePoint>(theArea);
		Weather = theWeather;
		if (Information.IsNothing((object)theAffectedUnitTypes))
		{
			AffectedUnitTypes = new ObservableList<GlobalVariables.ActiveUnitType>
			{
				GlobalVariables.ActiveUnitType.Aircraft,
				GlobalVariables.ActiveUnitType.Ship,
				GlobalVariables.ActiveUnitType.Submarine,
				GlobalVariables.ActiveUnitType.Facility
			};
		}
		else
		{
			AffectedUnitTypes = new ObservableList<GlobalVariables.ActiveUnitType>();
			foreach (GlobalVariables.ActiveUnitType theAffectedUnitType in theAffectedUnitTypes)
			{
				AffectedUnitTypes.Add(theAffectedUnitType);
			}
		}
		foreach (ActiveUnit activeUnits_ in theScen.ActiveUnits_List)
		{
			activeUnits_.Navigator.TimeToNextPlottedCourseLeadsToMissionAreaEvaluation = 0.0;
		}
		Side natureSide = theScen.GetNatureSide();
		if (natureSide != theSide)
		{
			foreach (ReferencePoint item in base.Area)
			{
				if (!natureSide.RefPoints.Contains(item))
				{
					natureSide.RefPoints.Add(item);
				}
			}
			foreach (ReferencePoint refPoint in natureSide.RefPoints)
			{
				if (theSide.RefPoints.Contains(refPoint))
				{
					theSide.RefPoints.Remove(refPoint);
				}
			}
		}
		string UserFeedback = default(string);
		if (!ActiveUnit_Navigator.ValidateArea(theArea, ref UserFeedback, theScen.GetNatureSide(), theScen, "Custom Environmnet Zone '" + Description + "'"))
		{
			GameGeneral.SendMessageBoxToUI(UserFeedback, theSide);
		}
	}

	public new static void TransformTo(Zone SourceZone, Side TargetSide, Scenario Scen)
	{
		Scen.CreateNatureSideIfNeeded();
		if (SourceZone != null)
		{
			ArrayExtensions.Add(ref Scen.GetNatureSide().CustomEnvironmentZones, new CustomEnvironmentZone(SourceZone.Description, SourceZone.Area, Scen, TargetSide, Scen.GlobalWeather));
			TargetSide.StandardZones.Remove(SourceZone);
		}
	}

	public new static void TransformTo(ExclusionZone SourceZone, Side TargetSide, Scenario Scen)
	{
		Scen.CreateNatureSideIfNeeded();
		if (SourceZone != null)
		{
			ArrayExtensions.Add(ref Scen.GetNatureSide().CustomEnvironmentZones, new CustomEnvironmentZone(SourceZone.Description, SourceZone.Area, Scen, TargetSide, Scen.GlobalWeather));
			TargetSide.ExclusionZones.Remove(SourceZone);
		}
	}

	public new static void TransformTo(NoNavZone SourceZone, Side TargetSide, Scenario Scen)
	{
		Scen.CreateNatureSideIfNeeded();
		if (SourceZone != null)
		{
			ArrayExtensions.Add(ref Scen.GetNatureSide().CustomEnvironmentZones, new CustomEnvironmentZone(SourceZone.Description, SourceZone.Area, Scen, TargetSide, Scen.GlobalWeather));
			TargetSide.NoNavZones.Remove(SourceZone);
		}
	}

	internal CustomEnvironmentZone Clone()
	{
		CustomEnvironmentZone customEnvironmentZone = new CustomEnvironmentZone();
		customEnvironmentZone.Weather = new Weather.WeatherProfile();
		customEnvironmentZone.Description = Description;
		customEnvironmentZone.Weather.AverageTemp = Weather.AverageTemp;
		customEnvironmentZone.Weather.RainfallRate = Weather.RainfallRate;
		customEnvironmentZone.Weather.FractionUnderRain = Weather.FractionUnderRain;
		customEnvironmentZone.Weather.SeaState = Weather.SeaState;
		customEnvironmentZone.TerrainType = TerrainType;
		customEnvironmentZone.ThermalLayerCeiling = ThermalLayerCeiling;
		customEnvironmentZone.DayNightTemperatureModifier = DayNightTemperatureModifier;
		customEnvironmentZone.ThermalLayerFloor = ThermalLayerFloor;
		customEnvironmentZone.LayerStrength = LayerStrength;
		customEnvironmentZone.CZInterval = CZInterval;
		customEnvironmentZone.Area = base.Area;
		return customEnvironmentZone;
	}

	private CustomEnvironmentZone()
	{
		TerrainType = LandCover.LandCoverType.Use_Underlying_Values;
		_CustomTerrainHeight = int.MinValue;
	}

	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized, ref Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("CustomEnvironmentZone");
			theWriter.WriteElementString("ID", ObjectID);
			theWriter.WriteElementString("Description", Description);
			theWriter.WriteStartElement("Weather");
			Weather.ToXML(ref theWriter);
			theWriter.WriteEndElement();
			theWriter.WriteStartElement("Area");
			int num = base.Area.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				ReferencePoint referencePoint;
				try
				{
					referencePoint = base.Area[i];
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
					continue;
				}
				theWriter.WriteRaw(referencePoint.ToXML(ref ObjectsAlreadySerialized));
			}
			theWriter.WriteEndElement();
			if (AltitudeEnvelopeMin.HasValue)
			{
				theWriter.WriteElementString("AltitudeEnvelopeMin", AltitudeEnvelopeMin.ToString());
			}
			if (AltitudeEnvelopeMax.HasValue)
			{
				theWriter.WriteElementString("AltitudeEnvelopeMax", AltitudeEnvelopeMax.ToString());
			}
			if (!Information.IsNothing((object)AffectedUnitTypes))
			{
				theWriter.WriteElementString("AffectedUnitTypes", string.Join("_", AffectedUnitTypes.Select([SpecialName] (GlobalVariables.ActiveUnitType theType) =>
				{
					int num2 = (int)theType;
					return num2.ToString();
				})));
			}
			theWriter.WriteElementString("IsLocked", IsLocked.ToString());
			theWriter.WriteElementString("IsActive", base.IsActive.ToString());
			theWriter.WriteElementString("TerrainType", Convert.ToInt32((byte)TerrainType).ToString());
			theWriter.WriteElementString("DayNightTemperatureModifier", ThermalLayerCeiling.ToString());
			theWriter.WriteElementString("ThermalLayerCeiling", ThermalLayerCeiling.ToString());
			theWriter.WriteElementString("ThermalLayerFloor", ThermalLayerFloor.ToString());
			theWriter.WriteElementString("LayerStrength", LayerStrength.ToString());
			theWriter.WriteElementString("CZInterval", CZInterval.ToString());
			theWriter.WriteElementString("Color_A", AreaColor.A.ToString());
			theWriter.WriteElementString("Color_R", AreaColor.R.ToString());
			theWriter.WriteElementString("Color_G", AreaColor.G.ToString());
			theWriter.WriteElementString("Color_B", AreaColor.B.ToString());
			theWriter.WriteElementString("Layer", _Layer.ToString());
			if (_CustomTerrainHeight > int.MinValue)
			{
				theWriter.WriteElementString("TerrainHeight", _CustomTerrainHeight.ToString());
			}
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100993", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static CustomEnvironmentZone FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref Scenario theScen)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Expected O, but got Unknown
		CustomEnvironmentZone result3;
		try
		{
			CustomEnvironmentZone customEnvironmentZone = new CustomEnvironmentZone();
			byte? b2 = default(byte?);
			byte? b = default(byte?);
			byte? b4 = default(byte?);
			byte? b3 = default(byte?);
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode theNode2 = childNode;
				switch (theNode2.Name)
				{
				case "CZInterval":
					try
					{
						customEnvironmentZone.CZInterval = Conversions.ToInteger(theNode2.InnerText);
					}
					catch (Exception projectError4)
					{
						ProjectData.SetProjectError(projectError4);
						customEnvironmentZone.CZInterval = 0f;
						ProjectData.ClearProjectError();
					}
					break;
				case "TerrainType":
					customEnvironmentZone.TerrainType = (LandCover.LandCoverType)Enum.Parse(typeof(LandCover.LandCoverType), theNode2.InnerText);
					break;
				case "Color_A":
					b2 = XmlConvert.ToByte(theNode2.InnerText);
					break;
				case "Area":
					foreach (XmlNode childNode2 in theNode2.ChildNodes)
					{
						XmlNode theNode3 = childNode2;
						customEnvironmentZone.Area.Add(ReferencePoint.FromXML(ref theNode3, ref theDictionary, theScen));
					}
					break;
				case "Color_G":
					b = XmlConvert.ToByte(theNode2.InnerText);
					break;
				case "Color_R":
					b4 = XmlConvert.ToByte(theNode2.InnerText);
					break;
				case "Color_B":
					b3 = XmlConvert.ToByte(theNode2.InnerText);
					break;
				case "ThermalLayerFloor":
					try
					{
						customEnvironmentZone.ThermalLayerFloor = Conversions.ToInteger(theNode2.InnerText);
					}
					catch (Exception projectError6)
					{
						ProjectData.SetProjectError(projectError6);
						customEnvironmentZone.ThermalLayerFloor = 0;
						ProjectData.ClearProjectError();
					}
					break;
				case "TerrainHeight":
					try
					{
						customEnvironmentZone._CustomTerrainHeight = Conversions.ToInteger(theNode2.InnerText);
					}
					catch (Exception projectError5)
					{
						ProjectData.SetProjectError(projectError5);
						customEnvironmentZone._CustomTerrainHeight = int.MinValue;
						ProjectData.ClearProjectError();
					}
					break;
				case "AffectedUnitTypes":
				{
					customEnvironmentZone.AffectedUnitTypes = new ObservableList<GlobalVariables.ActiveUnitType>();
					string[] array = theNode2.InnerText.Split(new char[1] { '_' });
					foreach (string text in array)
					{
						if (Versioned.IsNumeric((object)text))
						{
							int num = Conversions.ToInteger(text);
							customEnvironmentZone.AffectedUnitTypes.Add((GlobalVariables.ActiveUnitType)num);
						}
					}
					break;
				}
				case "ID":
					if (!theDictionary.ContainsKey(theNode2.InnerText))
					{
						customEnvironmentZone.ObjectID_Set(theNode2.InnerText);
						theDictionary.TryAdd(customEnvironmentZone.ObjectID, customEnvironmentZone);
						break;
					}
					result3 = (CustomEnvironmentZone)theDictionary[theNode2.InnerText];
					goto end_IL_0001;
				case "IsLocked":
					customEnvironmentZone.IsLocked = Misc.ParseBool(theNode2.InnerText);
					break;
				case "IsActive":
					customEnvironmentZone.IsActive = Misc.ParseBool(theNode2.InnerText);
					break;
				case "Weather":
					customEnvironmentZone.Weather = Command_Core.Weather.WeatherProfile.FromXML(ref theNode2);
					break;
				case "Description":
					customEnvironmentZone.Description = theNode2.InnerText;
					break;
				case "AltitudeEnvelopeMax":
				{
					if (float.TryParse(theNode2.InnerText, out var result2))
					{
						customEnvironmentZone.AltitudeEnvelopeMax = result2;
					}
					break;
				}
				case "AltitudeEnvelopeMin":
				{
					if (float.TryParse(theNode2.InnerText, out var result))
					{
						customEnvironmentZone.AltitudeEnvelopeMin = result;
					}
					break;
				}
				case "ThermalLayerCeiling":
					try
					{
						customEnvironmentZone.ThermalLayerCeiling = Conversions.ToInteger(theNode2.InnerText);
					}
					catch (Exception projectError3)
					{
						ProjectData.SetProjectError(projectError3);
						customEnvironmentZone.ThermalLayerCeiling = 0;
						ProjectData.ClearProjectError();
					}
					break;
				case "LayerStrength":
					try
					{
						customEnvironmentZone.LayerStrength = Conversions.ToInteger(theNode2.InnerText);
					}
					catch (Exception projectError2)
					{
						ProjectData.SetProjectError(projectError2);
						customEnvironmentZone.LayerStrength = 0f;
						ProjectData.ClearProjectError();
					}
					break;
				case "DayNightTemperatureModifier":
					try
					{
						customEnvironmentZone.DayNightTemperatureModifier = Conversions.ToInteger(theNode2.InnerText);
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						customEnvironmentZone.DayNightTemperatureModifier = 10;
						ProjectData.ClearProjectError();
					}
					break;
				}
			}
			if (!Information.IsNothing((object)b4))
			{
				customEnvironmentZone.AreaColor = Color.FromArgb(b2.Value, b4.Value, b.Value, b3.Value);
			}
			else
			{
				customEnvironmentZone.AreaColor = Color.DarkViolet;
			}
			if (Information.IsNothing((object)customEnvironmentZone.AffectedUnitTypes))
			{
				customEnvironmentZone.AffectedUnitTypes = new ObservableList<GlobalVariables.ActiveUnitType>
				{
					GlobalVariables.ActiveUnitType.Aircraft,
					GlobalVariables.ActiveUnitType.Ship,
					GlobalVariables.ActiveUnitType.Submarine,
					GlobalVariables.ActiveUnitType.Facility
				};
			}
			result3 = customEnvironmentZone;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100994", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result3 = new CustomEnvironmentZone();
			ProjectData.ClearProjectError();
		}
		return result3;
	}

	public override string ToString()
	{
		return Description + " " + Weather.RainfallRate_Description + " " + Weather.CloudInfo_Description + " Sea: " + Weather.SeaState;
	}

	static CustomEnvironmentZone()
	{
		Class72.smethod_20();
	}
}
