using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using DarkUI.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class ExclusionZone : Zone
{
	public Dictionary<string, Misc.PostureStance> ViolatorsStance;

	public Misc.PostureStance MarkViolatorAs;

	[ThreadStatic]
	private static StringBuilder stringBuilder_0;

	public override ZoneType Type => ZoneType.ExclusionZone;

	public void AddUnknownViolatorStanceIfNotContained()
	{
		if (!ViolatorsStance.ContainsKey("UnknownContactSide"))
		{
			ViolatorsStance.Add("UnknownContactSide", MarkViolatorAs);
		}
	}

	public ExclusionZone(string theDescription, Scenario theScen, Side theSide, List<ReferencePoint> theArea, Misc.PostureStance theMarkViolatorAs, List<GlobalVariables.ActiveUnitType> theAffectedUnitTypes = null, float? theAltitudeEnvelopeMin = null, float? theAltitudeEnvelopeMax = null)
	{
		ViolatorsStance = new Dictionary<string, Misc.PostureStance>();
		Description = theDescription;
		base.Area = new ObservableList<ReferencePoint>(theArea);
		MarkViolatorAs = theMarkViolatorAs;
		AltitudeEnvelopeMin = theAltitudeEnvelopeMin;
		AltitudeEnvelopeMax = theAltitudeEnvelopeMax;
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
		string UserFeedback = default(string);
		if (!ActiveUnit_Navigator.ValidateArea(theArea, ref UserFeedback, theSide, theScen, "Exclusion Zone '" + Description + "'"))
		{
			GameGeneral.SendMessageBoxToUI(UserFeedback, theSide);
		}
	}

	public new static void TransformTo(Zone SourceZone, Side TargetSide, Scenario Scen)
	{
		if (SourceZone != null)
		{
			TargetSide.ExclusionZones.Add(new ExclusionZone(SourceZone.Description, Scen, TargetSide, SourceZone.Area, Misc.PostureStance.Hostile));
			TargetSide.StandardZones.Remove(SourceZone);
		}
	}

	public new static void TransformTo(NoNavZone SourceZone, Side TargetSide, Scenario Scen)
	{
		if (SourceZone != null)
		{
			TargetSide.ExclusionZones.Add(new ExclusionZone(SourceZone.Description, Scen, TargetSide, SourceZone.Area, Misc.PostureStance.Hostile));
			TargetSide.NoNavZones.Remove(SourceZone);
		}
	}

	public new static void TransformTo(CustomEnvironmentZone SourceZone, Side TargetSide, Scenario Scen)
	{
		if (SourceZone != null)
		{
			TargetSide.ExclusionZones.Add(new ExclusionZone(SourceZone.Description, Scen, TargetSide, SourceZone.Area, Misc.PostureStance.Hostile));
			ArrayExtensions.Remove(ref Scen.GetNatureSide().CustomEnvironmentZones, SourceZone);
		}
	}

	public new static ExclusionZone Create(Side side, List<ReferencePoint> area, string Name = "", Color Color = default(Color))
	{
		ExclusionZone exclusionZone = new ExclusionZone();
		exclusionZone.Area = new ObservableList<ReferencePoint>(area);
		exclusionZone.AreaColor = Color.FromArgb(60, 100, 100, 100);
		side.ExclusionZones.Add(exclusionZone);
		return exclusionZone;
	}

	public new static ExclusionZone Create(Side side, List<string> area, string Name = "", Color Color = default(Color))
	{
		ObservableList<ReferencePoint> observableList = ReferencePoint.FetchReferencePointsFromID(side, area);
		if (observableList.Count <= 0)
		{
			return null;
		}
		return Create(side, observableList, Name, Color);
	}

	private ExclusionZone()
	{
		ViolatorsStance = new Dictionary<string, Misc.PostureStance>();
	}

	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized, ref Scenario theScen)
	{
		try
		{
			if (stringBuilder_0 != null)
			{
				stringBuilder_0.Clear();
			}
			else
			{
				stringBuilder_0 = new StringBuilder();
			}
			theWriter.WriteStartElement("ExclusionZone");
			theWriter.WriteElementString("ID", ObjectID);
			theWriter.WriteElementString("Description", Description);
			theWriter.WriteStartElement("Area");
			foreach (ReferencePoint item in base.Area)
			{
				theWriter.WriteRaw(item.ToXML(ref ObjectsAlreadySerialized));
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
			theWriter.WriteStartElement("ViolatorsStance");
			foreach (KeyValuePair<string, Misc.PostureStance> item2 in ViolatorsStance)
			{
				stringBuilder_0.Append("<VStance>");
				stringBuilder_0.Append("<ID>").Append(item2.Key).Append("</ID>");
				stringBuilder_0.Append("<Stance>").Append(((int)item2.Value).ToString()).Append("</Stance>");
				stringBuilder_0.Append("</VStance>");
			}
			theWriter.WriteRaw(stringBuilder_0.ToString());
			theWriter.WriteEndElement();
			theWriter.WriteElementString("AffectedUnitTypes", string.Join("_", AffectedUnitTypes.Select([SpecialName] (GlobalVariables.ActiveUnitType theType) =>
			{
				int num = (int)theType;
				return num.ToString();
			})));
			XmlWriter obj = theWriter;
			byte markViolatorAs = (byte)MarkViolatorAs;
			obj.WriteElementString("MarkViolatorAs", markViolatorAs.ToString());
			theWriter.WriteElementString("IsActive", base.IsActive.ToString());
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100991", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static ExclusionZone FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref Scenario theScen)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Expected O, but got Unknown
		//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Expected O, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected O, but got Unknown
		ExclusionZone result2;
		try
		{
			ExclusionZone exclusionZone = new ExclusionZone();
			string innerText = default(string);
			Misc.PostureStance value = default(Misc.PostureStance);
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "MarkViolatorAs":
					exclusionZone.MarkViolatorAs = (Misc.PostureStance)Conversions.ToByte(val.InnerText);
					break;
				case "Area":
					foreach (XmlNode childNode2 in val.ChildNodes)
					{
						XmlNode theNode2 = childNode2;
						exclusionZone.Area.Add(ReferencePoint.FromXML(ref theNode2, ref theDictionary, theScen));
					}
					break;
				case "ID":
					if (!theDictionary.ContainsKey(val.InnerText))
					{
						exclusionZone.ObjectID_Set(val.InnerText);
						theDictionary.TryAdd(exclusionZone.ObjectID, exclusionZone);
						break;
					}
					result2 = (ExclusionZone)theDictionary[val.InnerText];
					goto end_IL_0001;
				case "AffectedUnitTypes":
				{
					exclusionZone.AffectedUnitTypes = new ObservableList<GlobalVariables.ActiveUnitType>();
					string[] array = val.InnerText.Split(new char[1] { '_' });
					foreach (string text in array)
					{
						if (Versioned.IsNumeric((object)text))
						{
							int num = Conversions.ToInteger(text);
							exclusionZone.AffectedUnitTypes.Add((GlobalVariables.ActiveUnitType)num);
						}
					}
					break;
				}
				case "IsActive":
					exclusionZone.IsActive = Misc.ParseBool(val.InnerText);
					break;
				case "Description":
					exclusionZone.Description = val.InnerText;
					break;
				case "ViolatorsStance":
					foreach (XmlNode childNode3 in val.ChildNodes)
					{
						XmlNode val2 = childNode3;
						string name = val2.Name;
						if (Operators.CompareString(name, "VStance", false) == 0)
						{
							foreach (XmlNode childNode4 in val2.ChildNodes)
							{
								XmlNode val3 = childNode4;
								string name2 = val3.Name;
								if (Operators.CompareString(name2, "ID", false) == 0)
								{
									innerText = val3.InnerText;
								}
								else if (Operators.CompareString(name2, "Stance", false) == 0)
								{
									value = (Misc.PostureStance)Conversions.ToByte(val3.InnerText);
								}
							}
						}
						try
						{
							exclusionZone.ViolatorsStance.Add(innerText, value);
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception ex2 = ex;
							ex2?.Data.Add("Error at 10200992", "");
							GameGeneral.WriteExceptionsToLog(ex2);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					break;
				case "AltitudeEnvelopeMax":
				{
					if (float.TryParse(val.InnerText, out var result3))
					{
						exclusionZone.AltitudeEnvelopeMax = result3;
					}
					break;
				}
				case "AltitudeEnvelopeMin":
				{
					if (float.TryParse(val.InnerText, out var result))
					{
						exclusionZone.AltitudeEnvelopeMin = result;
					}
					break;
				}
				}
			}
			if (Information.IsNothing((object)exclusionZone.AffectedUnitTypes))
			{
				exclusionZone.AffectedUnitTypes = new ObservableList<GlobalVariables.ActiveUnitType>
				{
					GlobalVariables.ActiveUnitType.Aircraft,
					GlobalVariables.ActiveUnitType.Ship,
					GlobalVariables.ActiveUnitType.Submarine,
					GlobalVariables.ActiveUnitType.Facility
				};
			}
			result2 = exclusionZone;
			end_IL_0001:;
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 100992", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result2 = new ExclusionZone();
			ProjectData.ClearProjectError();
		}
		return result2;
	}

	static ExclusionZone()
	{
		Class72.smethod_20();
	}
}
