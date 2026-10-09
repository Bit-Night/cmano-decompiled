using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class ActiveEmissionInterval
{
	public Dictionary<Alertlevels, ActiveEmissionInterval_Config> Configs;

	private ActiveUnit_Sensory activeUnit_Sensory_0;

	private ActiveUnit activeUnit_0;

	public float TargetInterval;

	public DateTime LastIntervalTimeStamp;

	public DateTime SleepModeTimeStamp;

	public bool IsInEmissionPhase;

	private bool bool_0;

	private bool bool_1;

	public bool InheritParentGroupConfig
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public bool UseCustomPresetOnly
	{
		get
		{
			if (!InheritParentGroupConfig)
			{
				return bool_0;
			}
			return false;
		}
		set
		{
			bool_0 = value;
		}
	}

	public ActiveEmissionInterval()
	{
		Configs = new Dictionary<Alertlevels, ActiveEmissionInterval_Config>();
	}

	public ActiveEmissionInterval(ActiveUnit_Sensory _ReferenceSensory)
	{
		Configs = new Dictionary<Alertlevels, ActiveEmissionInterval_Config>();
		Initialize(_ReferenceSensory);
	}

	public void Initialize(ActiveUnit_Sensory _ReferenceSensory, bool Reinitialise = false)
	{
		if (_ReferenceSensory != null)
		{
			activeUnit_Sensory_0 = _ReferenceSensory;
			activeUnit_0 = activeUnit_Sensory_0.GetParentUnit();
		}
		if (Reinitialise)
		{
			Configs.Clear();
		}
		if (!Configs.ContainsKey(Alertlevels.Green))
		{
			Configs.Add(Alertlevels.Green, new ActiveEmissionInterval_Config(Alertlevels.Green));
		}
		if (!Configs.ContainsKey(Alertlevels.Blue))
		{
			Configs.Add(Alertlevels.Blue, new ActiveEmissionInterval_Config(Alertlevels.Blue));
		}
		if (!Configs.ContainsKey(Alertlevels.Yellow))
		{
			Configs.Add(Alertlevels.Yellow, new ActiveEmissionInterval_Config(Alertlevels.Yellow));
		}
		if (!Configs.ContainsKey(Alertlevels.Orange))
		{
			Configs.Add(Alertlevels.Orange, new ActiveEmissionInterval_Config(Alertlevels.Orange));
		}
		if (!Configs.ContainsKey(Alertlevels.Red))
		{
			Configs.Add(Alertlevels.Red, new ActiveEmissionInterval_Config(Alertlevels.Red));
		}
		if (!Configs.ContainsKey(Alertlevels.Custom))
		{
			Configs.Add(Alertlevels.Custom, new ActiveEmissionInterval_Config(Alertlevels.Custom));
		}
	}

	public void PasteConfig(Alertlevels alert, ActiveEmissionInterval sourceConfig)
	{
		Configs[alert].EmissionDuration = sourceConfig.Configs[alert].EmissionDuration;
		Configs[alert].EmissionInterval = sourceConfig.Configs[alert].EmissionInterval;
		Configs[alert].EmissionIntervalVariation = sourceConfig.Configs[alert].EmissionIntervalVariation;
		Configs[alert].FollowWRAforWakeBehavior = sourceConfig.Configs[alert].FollowWRAforWakeBehavior;
		Configs[alert].SleepModeDelay = sourceConfig.Configs[alert].SleepModeDelay;
		Configs[alert].WakeWhenDetectingThreat = sourceConfig.Configs[alert].WakeWhenDetectingThreat;
		Configs[alert].UseEmissionInterval = sourceConfig.Configs[alert].UseEmissionInterval;
		Array values = Enum.GetValues(typeof(Misc.PostureStance));
		Array values2 = Enum.GetValues(typeof(Contact_Base.IdentificationStatus));
		foreach (object item in values2)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(item);
			Configs[alert].Wake_IncludesContactID[(Contact_Base.IdentificationStatus)Conversions.ToShort(objectValue)] = sourceConfig.Configs[alert].Wake_IncludesContactID[(Contact_Base.IdentificationStatus)Conversions.ToShort(objectValue)];
		}
		foreach (object item2 in values)
		{
			object objectValue2 = RuntimeHelpers.GetObjectValue(item2);
			Configs[alert].Wake_IncludesContactStance[(Misc.PostureStance)Conversions.ToByte(objectValue2)] = sourceConfig.Configs[alert].Wake_IncludesContactStance[(Misc.PostureStance)Conversions.ToByte(objectValue2)];
		}
	}

	public void Tick()
	{
		if (InheritParentGroupConfig && activeUnit_0.get_ParentGroup(UsingMissionPlanner: false) != null)
		{
			activeUnit_0.get_ParentGroup(UsingMissionPlanner: false).Sensory.GetIntermittentEmission().Tick();
			return;
		}
		ActiveEmissionInterval_Config currentlyAppliedConfig = GetCurrentlyAppliedConfig();
		if (method_0())
		{
			if (currentlyAppliedConfig.EmissionDuration == 0f)
			{
				IsInEmissionPhase = false;
			}
			else if (currentlyAppliedConfig.EmissionInterval + currentlyAppliedConfig.EmissionIntervalVariation == 0f)
			{
				IsInEmissionPhase = true;
			}
			else
			{
				CreateNewInterval(!IsInEmissionPhase);
			}
		}
	}

	internal bool IsAllowedToEmit()
	{
		if (GetCurrentlyAppliedConfig().UseEmissionInterval)
		{
			Tick();
			if (InheritParentGroupConfig && activeUnit_0.get_ParentGroup(UsingMissionPlanner: false) != null)
			{
				return activeUnit_0.get_ParentGroup(UsingMissionPlanner: false).Sensory.GetIntermittentEmission().IsInEmissionPhase;
			}
			if (!IsInEmissionPhase)
			{
				return false;
			}
			return true;
		}
		return true;
	}

	public void CreateNewInterval(bool MakeItToEmissionPhase)
	{
		LastIntervalTimeStamp = activeUnit_0.ParentScen.Time;
		IsInEmissionPhase = MakeItToEmissionPhase;
		TargetInterval = GetNewEmissionInterval();
	}

	internal float GetNewEmissionInterval()
	{
		if (!IsInEmissionPhase)
		{
			return GetCurrentlyAppliedConfig().EmissionInterval + Conversion.Int((GetCurrentlyAppliedConfig().EmissionIntervalVariation - 0f + 1f) * VBMath.Rnd() + 0f);
		}
		return GetCurrentlyAppliedConfig().EmissionDuration;
	}

	internal ActiveEmissionInterval_Config GetCurrentlyAppliedConfig()
	{
		if (!InheritParentGroupConfig || activeUnit_0.get_ParentGroup(UsingMissionPlanner: false) == null)
		{
			if (UseCustomPresetOnly)
			{
				return Configs[Alertlevels.Custom];
			}
			return Configs[method_1()];
		}
		Alertlevels key = ((!UseCustomPresetOnly) ? method_1() : Alertlevels.Custom);
		return activeUnit_0.get_ParentGroup(UsingMissionPlanner: false).Sensory.GetIntermittentEmission().Configs[key];
	}

	private bool method_0()
	{
		DateTime t = LastIntervalTimeStamp.AddSeconds(TargetInterval);
		if (DateTime.Compare(activeUnit_0.ParentScen.Time, t) > 0)
		{
			return true;
		}
		return false;
	}

	internal double GetTimeRemainingNextInterval(bool IgnoreParent = false)
	{
		if (InheritParentGroupConfig && !IgnoreParent && activeUnit_0.get_ParentGroup(UsingMissionPlanner: false) != null)
		{
			return activeUnit_0.get_ParentGroup(UsingMissionPlanner: false).Sensory.GetIntermittentEmission().GetTimeRemainingNextInterval(IgnoreParent: true);
		}
		return Math.Min((activeUnit_0.ParentScen.Time - LastIntervalTimeStamp.AddSeconds(TargetInterval)).TotalSeconds, 0.0);
	}

	private Alertlevels method_1()
	{
		return activeUnit_0.get_UnitSide(SetSideOnly: false).EmconAlertness.Level;
	}

	public void ToggleEmissionMode(ActiveEmissionInterval_Config ConfigToAffect = null)
	{
		if (ConfigToAffect == null)
		{
			ConfigToAffect = GetCurrentlyAppliedConfig();
		}
		if (!ConfigToAffect.UseEmissionInterval)
		{
			SwitchToIntermittent(ConfigToAffect);
		}
		else
		{
			SwitchToContinuous(ConfigToAffect);
		}
	}

	public void SwitchToContinuous(ActiveEmissionInterval_Config ConfigToAffect = null)
	{
		if (ConfigToAffect == null)
		{
			ConfigToAffect = GetCurrentlyAppliedConfig();
		}
		ConfigToAffect.UseEmissionInterval = false;
	}

	public void SwitchToIntermittent(ActiveEmissionInterval_Config ConfigToAffect = null)
	{
		if (ConfigToAffect == null)
		{
			ConfigToAffect = GetCurrentlyAppliedConfig();
		}
		ConfigToAffect.UseEmissionInterval = true;
		Wake();
	}

	public void ToggleSleep_Wake()
	{
		if (!IsInEmissionPhase)
		{
			CreateNewInterval(MakeItToEmissionPhase: true);
		}
		else
		{
			CreateNewInterval(MakeItToEmissionPhase: false);
		}
	}

	public void Wake(float Interval = 0f)
	{
		CreateNewInterval(MakeItToEmissionPhase: true);
		if (Interval != 0f)
		{
			TargetInterval = Interval;
		}
	}

	public void Sleep()
	{
		CreateNewInterval(MakeItToEmissionPhase: false);
	}

	internal bool ContactStanceAndIDWillWake(Contact DetectedContact)
	{
		int result;
		if (GetCurrentlyAppliedConfig().Wake_IncludesContactID[DetectedContact.IDStatus])
		{
			if (GetCurrentlyAppliedConfig().Wake_IncludesContactStance[DetectedContact.get_Stance(activeUnit_0.get_UnitSide(SetSideOnly: false))])
			{
				return true;
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public void AttemptToWake_WithDetection(Contact DetectedContact)
	{
		ActiveEmissionInterval_Config currentlyAppliedConfig = GetCurrentlyAppliedConfig();
		if (!currentlyAppliedConfig.WakeWhenDetectingThreat)
		{
			return;
		}
		if (IsInEmissionPhase)
		{
			if (ContactStanceAndIDWillWake(DetectedContact))
			{
				LastIntervalTimeStamp = activeUnit_0.ParentScen.Time;
			}
		}
		else
		{
			Wake(currentlyAppliedConfig.SleepModeDelay);
		}
	}

	public void AttemptToWake_WithDetection(List<Contact> DetectedContact)
	{
		if (!GetCurrentlyAppliedConfig().WakeWhenDetectingThreat || !IsInEmissionPhase)
		{
			return;
		}
		foreach (Contact item in DetectedContact)
		{
			if (item.get_Stance(activeUnit_0.get_UnitSide(SetSideOnly: false)) != Misc.PostureStance.Friendly && IsInEmissionPhase)
			{
				LastIntervalTimeStamp = activeUnit_0.ParentScen.Time;
			}
		}
	}

	public void ToXML(ref XmlWriter theWriter)
	{
		try
		{
			theWriter.WriteStartElement("EmissionInterval");
			if (TargetInterval != 0f)
			{
				theWriter.WriteElementString("TargetInterval", TargetInterval.ToString());
			}
			if (LastIntervalTimeStamp.Ticks != 0L)
			{
				theWriter.WriteElementString("LastIntervalTimeStamp", Conversions.ToString(LastIntervalTimeStamp.ToBinary()));
			}
			if (SleepModeTimeStamp.Ticks != 0L)
			{
				theWriter.WriteElementString("SleepModeTimeStamp", Conversions.ToString(SleepModeTimeStamp.ToBinary()));
			}
			if (IsInEmissionPhase)
			{
				theWriter.WriteElementString("IsInEmissionPhase", IsInEmissionPhase.ToString());
			}
			if (UseCustomPresetOnly)
			{
				theWriter.WriteElementString("UseCustomPresetOnly", UseCustomPresetOnly.ToString());
			}
			if (InheritParentGroupConfig)
			{
				theWriter.WriteElementString("InheritParentGroupConfig", InheritParentGroupConfig.ToString());
			}
			theWriter.WriteStartElement("DECON");
			foreach (ActiveEmissionInterval_Config value in Configs.Values)
			{
				theWriter.WriteStartElement("Defcon_" + value.Defcon);
				theWriter.WriteElementString("UseEmissionInterval", value.UseEmissionInterval.ToString());
				theWriter.WriteElementString("WakeWhenDetectingThreat", value.WakeWhenDetectingThreat.ToString());
				if (value.SleepModeDelay != 0f)
				{
					theWriter.WriteElementString("SleepModeDelay", XmlConvert.ToString(value.SleepModeDelay));
				}
				if (value.EmissionInterval != 0f)
				{
					theWriter.WriteElementString("EmissionInterval", XmlConvert.ToString(value.EmissionInterval));
				}
				if (value.UseEmissionInterval)
				{
					theWriter.WriteElementString("UseEmissionInterval", value.UseEmissionInterval.ToString());
				}
				if (value.EmissionDuration != 0f)
				{
					theWriter.WriteElementString("EmissionDuration", XmlConvert.ToString(value.EmissionDuration));
				}
				if (value.EmissionIntervalVariation != 0f)
				{
					theWriter.WriteElementString("EmissionIntervalVariation", XmlConvert.ToString(value.EmissionIntervalVariation));
				}
				string text = "";
				foreach (KeyValuePair<Misc.PostureStance, bool> item in value.Wake_IncludesContactStance)
				{
					if (item.Value)
					{
						text = text + item.Key.ToString() + ",";
					}
				}
				theWriter.WriteElementString("Wake_IncludesContactStance", text);
				text = "";
				foreach (KeyValuePair<Contact_Base.IdentificationStatus, bool> item2 in value.Wake_IncludesContactID)
				{
					if (item2.Value)
					{
						text = text + item2.Key.ToString() + ",";
					}
				}
				theWriter.WriteElementString("Wake_IncludesContactID", text);
				theWriter.WriteEndElement();
			}
			theWriter.WriteEndElement();
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101003b", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static ActiveEmissionInterval FromXML(ref XmlNode theNode)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Expected O, but got Unknown
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Expected O, but got Unknown
		checked
		{
			ActiveEmissionInterval result;
			try
			{
				ActiveEmissionInterval activeEmissionInterval = new ActiveEmissionInterval();
				foreach (XmlNode childNode in theNode.ChildNodes)
				{
					XmlNode val = childNode;
					switch (val.Name)
					{
					case "UseCustomPresetOnly":
						activeEmissionInterval.UseCustomPresetOnly = Misc.ParseBool(val.InnerText);
						break;
					case "SleepModeTimeStamp":
						try
						{
							activeEmissionInterval.SleepModeTimeStamp = DateTime.FromBinary(Conversions.ToLong(val.InnerText));
						}
						catch (Exception projectError2)
						{
							ProjectData.SetProjectError(projectError2);
							activeEmissionInterval.SleepModeTimeStamp = DateTime.Parse(val.InnerText);
							ProjectData.ClearProjectError();
						}
						break;
					case "LastIntervalTimeStamp":
						try
						{
							activeEmissionInterval.LastIntervalTimeStamp = DateTime.FromBinary(Conversions.ToLong(val.InnerText));
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							activeEmissionInterval.LastIntervalTimeStamp = DateTime.Parse(val.InnerText);
							ProjectData.ClearProjectError();
						}
						break;
					case "TargetInterval":
						activeEmissionInterval.TargetInterval = Conversions.ToSingle(val.InnerText);
						break;
					case "InheritParentGroupConfig":
						activeEmissionInterval.InheritParentGroupConfig = Misc.ParseBool(val.InnerText);
						break;
					case "IsInEmissionPhase":
						activeEmissionInterval.IsInEmissionPhase = Misc.ParseBool(val.InnerText);
						break;
					case "DECON":
						foreach (XmlNode childNode2 in val.ChildNodes)
						{
							XmlNode val2 = childNode2;
							Alertlevels alertEnumWithString = EmconLevel.GetAlertEnumWithString(val2.Name.Split(new char[1] { '_' })[1]);
							ActiveEmissionInterval_Config activeEmissionInterval_Config = new ActiveEmissionInterval_Config(alertEnumWithString, WithDefaultValues: false);
							foreach (XmlNode childNode3 in val2.ChildNodes)
							{
								XmlNode val3 = childNode3;
								switch (val3.Name)
								{
								case "SleepModeDelay":
									activeEmissionInterval_Config.SleepModeDelay = Conversions.ToSingle(val3.InnerText);
									break;
								case "WakeWhenDetectingThreat":
									activeEmissionInterval_Config.WakeWhenDetectingThreat = Conversions.ToBoolean(val3.InnerText);
									break;
								case "FollowWRAforWakeBehavior":
									activeEmissionInterval_Config.FollowWRAforWakeBehavior = Conversions.ToBoolean(val3.InnerText);
									break;
								case "Wake_IncludesContactID":
								{
									string[] array2 = val3.InnerText.Split(new char[1] { ',' });
									for (int j = 0; j < array2.Length; j++)
									{
										switch (array2[j])
										{
										case "Unknown":
											activeEmissionInterval_Config.Wake_IncludesContactID[Contact_Base.IdentificationStatus.Unknown] = true;
											break;
										case "KnownType":
											activeEmissionInterval_Config.Wake_IncludesContactID[Contact_Base.IdentificationStatus.KnownType] = true;
											break;
										case "KnownClass":
											activeEmissionInterval_Config.Wake_IncludesContactID[Contact_Base.IdentificationStatus.KnownClass] = true;
											break;
										case "PreciseID":
											activeEmissionInterval_Config.Wake_IncludesContactID[Contact_Base.IdentificationStatus.PreciseID] = true;
											break;
										case "KnownDomain":
											activeEmissionInterval_Config.Wake_IncludesContactID[Contact_Base.IdentificationStatus.KnownDomain] = true;
											break;
										}
									}
									break;
								}
								case "UseEmissionInterval":
									activeEmissionInterval_Config.UseEmissionInterval = Conversions.ToBoolean(val3.InnerText);
									break;
								case "EmissionInterval":
									activeEmissionInterval_Config.EmissionInterval = Conversions.ToSingle(val3.InnerText);
									break;
								case "EmissionIntervalVariation":
									activeEmissionInterval_Config.EmissionIntervalVariation = Conversions.ToSingle(val3.InnerText);
									break;
								case "Wake_IncludesContactStance":
								{
									string[] array = val3.InnerText.Split(new char[1] { ',' });
									for (int i = 0; i < array.Length; i++)
									{
										switch (array[i])
										{
										case "Neutral":
											activeEmissionInterval_Config.Wake_IncludesContactStance[Misc.PostureStance.Neutral] = true;
											break;
										case "Friendly":
											activeEmissionInterval_Config.Wake_IncludesContactStance[Misc.PostureStance.Friendly] = true;
											break;
										case "Unfriendly":
											activeEmissionInterval_Config.Wake_IncludesContactStance[Misc.PostureStance.Unfriendly] = true;
											break;
										case "Hostile":
											activeEmissionInterval_Config.Wake_IncludesContactStance[Misc.PostureStance.Hostile] = true;
											break;
										case "Unknown":
											activeEmissionInterval_Config.Wake_IncludesContactStance[Misc.PostureStance.Unknown] = true;
											break;
										}
									}
									break;
								}
								case "EmissionDuration":
									activeEmissionInterval_Config.EmissionDuration = Conversions.ToSingle(val3.InnerText);
									break;
								}
							}
							if (!activeEmissionInterval.Configs.ContainsKey(alertEnumWithString))
							{
								activeEmissionInterval.Configs.Add(alertEnumWithString, activeEmissionInterval_Config);
							}
						}
						activeEmissionInterval.Initialize(null);
						break;
					}
				}
				result = activeEmissionInterval;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101004b", "");
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

	static ActiveEmissionInterval()
	{
		Class72.smethod_20();
	}
}
