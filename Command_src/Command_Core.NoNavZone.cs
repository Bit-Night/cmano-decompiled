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

public sealed class NoNavZone : Zone
{
	public bool NoFireZone;

	public override ZoneType Type => ZoneType.NoNavZone;

	public NoNavZone(string theDescription, List<ReferencePoint> theArea, Scenario theScen, Side CurrentSide, List<GlobalVariables.ActiveUnitType> theAffectedUnitTypes = null)
	{
		NoFireZone = true;
		Description = theDescription;
		base.Area = new ObservableList<ReferencePoint>(theArea);
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
			if (activeUnits_.get_UnitSide(SetSideOnly: false) == CurrentSide)
			{
				activeUnits_.Navigator.TimeToNextPlottedCourseLeadsToMissionAreaEvaluation = 0.0;
			}
		}
		string UserFeedback = default(string);
		if (!ActiveUnit_Navigator.ValidateArea(theArea, ref UserFeedback, CurrentSide, theScen, "Exclusion Zone '" + Description + "'"))
		{
			GameGeneral.SendMessageBoxToUI(UserFeedback, CurrentSide);
		}
	}

	private NoNavZone()
	{
		NoFireZone = true;
	}

	public new static NoNavZone Create(Side side, List<ReferencePoint> area, string Name = "", Color Color = default(Color))
	{
		NoNavZone noNavZone = new NoNavZone();
		noNavZone.Area = new ObservableList<ReferencePoint>(area);
		noNavZone.AreaColor = Color.FromArgb(60, 100, 100, 100);
		side.NoNavZones.Add(noNavZone);
		return noNavZone;
	}

	public new static NoNavZone Create(Side side, List<string> area, string Name = "", Color Color = default(Color))
	{
		ObservableList<ReferencePoint> observableList = ReferencePoint.FetchReferencePointsFromID(side, area);
		if (observableList.Count > 0)
		{
			return Create(side, observableList, Name, Color);
		}
		return null;
	}

	public new static void TransformTo(Zone SourceZone, Side TargetSide, Scenario Scen)
	{
		if (SourceZone != null)
		{
			TargetSide.NoNavZones.Add(new NoNavZone(SourceZone.Description, SourceZone.Area, Scen, TargetSide));
			TargetSide.StandardZones.Remove(SourceZone);
		}
	}

	public new static void TransformTo(ExclusionZone SourceZone, Side TargetSide, Scenario Scen)
	{
		if (SourceZone != null)
		{
			TargetSide.NoNavZones.Add(new NoNavZone(SourceZone.Description, SourceZone.Area, Scen, TargetSide));
			TargetSide.ExclusionZones.Remove(SourceZone);
		}
	}

	public new static void TransformTo(CustomEnvironmentZone SourceZone, Side TargetSide, Scenario Scen)
	{
		Scen.CreateNatureSideIfNeeded();
		if (SourceZone != null)
		{
			ArrayExtensions.Add(ref Scen.GetNatureSide().CustomEnvironmentZones, new CustomEnvironmentZone(SourceZone.Description, SourceZone.Area, Scen, TargetSide, Scen.GlobalWeather));
			ArrayExtensions.Remove(ref TargetSide.CustomEnvironmentZones, SourceZone);
		}
	}

	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized, ref Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("NoNavZone");
			theWriter.WriteElementString("ID", ObjectID);
			theWriter.WriteElementString("Description", Description);
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
			theWriter.WriteElementString("AffectedUnitTypes", string.Join("_", AffectedUnitTypes.Select([SpecialName] (GlobalVariables.ActiveUnitType theType) =>
			{
				int num2 = (int)theType;
				return num2.ToString();
			})));
			theWriter.WriteElementString("IsLocked", IsLocked.ToString());
			theWriter.WriteElementString("IsActive", base.IsActive.ToString());
			theWriter.WriteElementString("NoFireZone", NoFireZone.ToString());
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

	public new static NoNavZone FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref Scenario theScen)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected O, but got Unknown
		NoNavZone result3;
		try
		{
			NoNavZone noNavZone = new NoNavZone();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "AffectedUnitTypes":
				{
					noNavZone.AffectedUnitTypes = new ObservableList<GlobalVariables.ActiveUnitType>();
					string[] array = val.InnerText.Split(new char[1] { '_' });
					foreach (string text in array)
					{
						if (Versioned.IsNumeric((object)text))
						{
							int num = Conversions.ToInteger(text);
							noNavZone.AffectedUnitTypes.Add((GlobalVariables.ActiveUnitType)num);
						}
					}
					break;
				}
				case "Area":
					foreach (XmlNode childNode2 in val.ChildNodes)
					{
						XmlNode theNode2 = childNode2;
						noNavZone.Area.Add(ReferencePoint.FromXML(ref theNode2, ref theDictionary, theScen));
					}
					break;
				case "ID":
					if (!theDictionary.ContainsKey(val.InnerText))
					{
						noNavZone.ObjectID_Set(val.InnerText);
						theDictionary.TryAdd(noNavZone.ObjectID, noNavZone);
						break;
					}
					result3 = (NoNavZone)theDictionary[val.InnerText];
					goto end_IL_0001;
				case "IsLocked":
					noNavZone.IsLocked = Misc.ParseBool(val.InnerText);
					break;
				case "IsActive":
					noNavZone.IsActive = Misc.ParseBool(val.InnerText);
					break;
				case "Description":
					noNavZone.Description = val.InnerText;
					break;
				case "NoFireZone":
					noNavZone.NoFireZone = Misc.ParseBool(val.InnerText);
					break;
				case "AltitudeEnvelopeMax":
				{
					if (float.TryParse(val.InnerText, out var result2))
					{
						noNavZone.AltitudeEnvelopeMax = result2;
					}
					break;
				}
				case "AltitudeEnvelopeMin":
				{
					if (float.TryParse(val.InnerText, out var result))
					{
						noNavZone.AltitudeEnvelopeMin = result;
					}
					break;
				}
				}
			}
			if (Information.IsNothing((object)noNavZone.AffectedUnitTypes))
			{
				noNavZone.AffectedUnitTypes = new ObservableList<GlobalVariables.ActiveUnitType>
				{
					GlobalVariables.ActiveUnitType.Aircraft,
					GlobalVariables.ActiveUnitType.Ship,
					GlobalVariables.ActiveUnitType.Submarine,
					GlobalVariables.ActiveUnitType.Facility
				};
			}
			result3 = noNavZone;
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
			result3 = new NoNavZone();
			ProjectData.ClearProjectError();
		}
		return result3;
	}

	static NoNavZone()
	{
		Class72.smethod_20();
	}
}
