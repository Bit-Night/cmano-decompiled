using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Group_Kinematics : ActiveUnit_Kinematics
{
	private bool bool_4;

	public bool LeadAllowedToSlowDown
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	public override float? DesiredSpeedOverride
	{
		get
		{
			if (!Information.IsNothing((object)((Group)myUnit).GroupLead))
			{
				return ((Group)myUnit).GroupLead.Kinematics.DesiredSpeedOverride;
			}
			return null;
		}
		set
		{
			try
			{
				if (!Information.IsNothing((object)((Group)myUnit).GroupLead))
				{
					((Group)myUnit).GroupLead.Kinematics.DesiredSpeedOverride = value;
				}
				foreach (ActiveUnit value2 in ((Group)myUnit).Units.Values)
				{
					if (!value2.IsGroupLead())
					{
						value2.Kinematics.DesiredSpeedOverride = null;
					}
				}
				if (!value.HasValue)
				{
					myUnit.Kinematics.ThrottlePreset = UnitThrottlePreset.None;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100614", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public override UnitThrottlePreset ThrottlePreset
	{
		get
		{
			if (Information.IsNothing((object)((Group)myUnit).GroupLead))
			{
				return UnitThrottlePreset.FullStop;
			}
			return ((Group)myUnit).GroupLead.Kinematics.ThrottlePreset;
		}
		set
		{
			try
			{
				if (!Information.IsNothing((object)((Group)myUnit).GroupLead))
				{
					((Group)myUnit).GroupLead.Kinematics.ThrottlePreset = value;
				}
				foreach (ActiveUnit value2 in ((Group)myUnit).Units.Values)
				{
					if (!value2.IsGroupLead())
					{
						value2.Kinematics.ThrottlePreset = UnitThrottlePreset.None;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100615", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public override bool DesiredAltitudeOverride
	{
		get
		{
			if (!Information.IsNothing((object)((Group)myUnit).GroupLead))
			{
				return ((Group)myUnit).GroupLead.Kinematics.DesiredAltitudeOverride;
			}
			return false;
		}
		set
		{
			try
			{
				if (!Information.IsNothing((object)((Group)myUnit).GroupLead))
				{
					((Group)myUnit).GroupLead.Kinematics.DesiredAltitudeOverride = value;
				}
				foreach (ActiveUnit value2 in ((Group)myUnit).Units.Values)
				{
					if (!value2.IsGroupLead())
					{
						value2.Kinematics.DesiredAltitudeOverride = false;
					}
				}
				if (!value)
				{
					if (myUnit.IsGroup && ((Group)myUnit).Type == Group.GroupType.SubGroup)
					{
						((Group_AI)myUnit.AI).DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.None;
					}
					if (myUnit.IsGroup && ((Group)myUnit).Type == Group.GroupType.AirGroup)
					{
						((Group_AI)myUnit.AI).AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.None;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100616", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public override void ToXML(ref XmlWriter theWriter)
	{
		try
		{
			theWriter.WriteElementString("AMV", XmlConvert.ToString(ActualMovementVector));
			if (DesiredSpeedOverride.HasValue)
			{
				theWriter.WriteElementString("DSO", XmlConvert.ToString(DesiredSpeedOverride.Value));
			}
			if (DesiredAltitudeOverride)
			{
				theWriter.WriteElementString("DAO", DesiredAltitudeOverride.ToString());
			}
			theWriter.WriteElementString("LATSD", bool_4.ToString());
			theWriter.WriteElementString("SP", ((byte)ThrottlePreset).ToString());
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100612", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static Group_Kinematics FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Group_Kinematics result;
		try
		{
			Group_Kinematics group_Kinematics = new Group_Kinematics(ref theAU);
			group_Kinematics.myUnit = theAU;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "DSO":
				case "DesiredSpeedOverride":
					if (Operators.CompareString(val.InnerText, true.ToString(), false) != 0 && Operators.CompareString(val.InnerText, false.ToString(), false) != 0)
					{
						group_Kinematics.DesiredSpeedOverride = XmlConvert.ToSingle(val.InnerText.Replace(",", "."));
					}
					else if (Operators.CompareString(val.InnerText, true.ToString(), false) == 0)
					{
						group_Kinematics.DesiredSpeedOverride = theAU.DesiredSpeed;
					}
					break;
				case "AMV":
				case "ActualMovementVector":
					group_Kinematics.ActualMovementVector = XmlConvert.ToSingle(val.InnerText);
					break;
				case "SP":
					group_Kinematics.ThrottlePreset = (UnitThrottlePreset)Conversions.ToByte(val.InnerText);
					break;
				case "ClimbRate":
					((ActiveUnit_Kinematics)group_Kinematics).set_ClimbRate_Nominal(LimitByTrueAirspeed: true, XmlConvert.ToSingle(val.InnerText));
					break;
				case "LATSD":
					group_Kinematics.bool_4 = Misc.ParseBool(val.InnerText);
					break;
				}
			}
			result = group_Kinematics;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100613", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Group_Kinematics(ref theAU);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public Group_Kinematics(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
		bool_4 = true;
	}

	public override float TurnRate()
	{
		return ((Group)myUnit).GroupLead.Kinematics.TurnRate();
	}

	public void UpdateGroupCenter()
	{
		if (!Information.IsNothing((object)((Group)myUnit).GroupLead))
		{
			myUnit.set_Longitude((GlobalVariables.BooleanObject)null, ((Group)myUnit).GroupLead.get_Longitude((GlobalVariables.BooleanObject)null));
			myUnit.set_Latitude((GlobalVariables.BooleanObject)null, ((Group)myUnit).GroupLead.get_Latitude((GlobalVariables.BooleanObject)null));
			myUnit.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, ((Group)myUnit).GroupLead.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
			myUnit.CurrentHeading = ((Group)myUnit).GroupLead.CurrentHeading;
			myUnit.CurrentSpeed = ((Group)myUnit).GroupLead.CurrentSpeed;
		}
	}

	public override void Move(float elapsedTime, bool CheckForMinimumSafeHeight, bool SimplifiedCalcs_DLZ, DateTime ExplicitDateTime, bool GhostMovement = false)
	{
	}

	public override float GetMaximumAltitude()
	{
		Group obj = (Group)myUnit;
		Group.GroupType type = obj.Type;
		if (type != Group.GroupType.SurfaceGroup && type - 3 > Group.GroupType.SubGroup)
		{
			if (obj.CompositionType != Group.E_CompositionType.Homogenous_DBIDandLoadout && obj.CompositionType != Group.E_CompositionType.Homogenous_DBID)
			{
				IEnumerable<ActiveUnit> source = ((Group)myUnit).Units.Values.OrderByDescending([SpecialName] (ActiveUnit AU) => AU.Kinematics.GetMaximumAltitude());
				if (source.Count() == 0)
				{
					return 0f;
				}
				return source.ElementAtOrDefault(0).Kinematics.GetMaximumAltitude();
			}
			if (obj.GroupLead == null)
			{
				return 0f;
			}
			return obj.GroupLead.Kinematics.GetMaximumAltitude();
		}
		return 0f;
	}

	public override float GetMinimumAltitude()
	{
		Group obj = (Group)myUnit;
		Group.GroupType type = obj.Type;
		if (type != Group.GroupType.SurfaceGroup && type - 3 > Group.GroupType.SubGroup)
		{
			if (obj.CompositionType != Group.E_CompositionType.Homogenous_DBIDandLoadout && obj.CompositionType != Group.E_CompositionType.Homogenous_DBID)
			{
				IEnumerable<ActiveUnit> source = ((Group)myUnit).Units.Values.OrderBy([SpecialName] (ActiveUnit AU) => AU.Kinematics.GetMinimumAltitude());
				if (source.Count() == 0)
				{
					return 0f;
				}
				return source.ElementAtOrDefault(0).Kinematics.GetMinimumAltitude();
			}
			if (obj.GroupLead != null)
			{
				return obj.GroupLead.Kinematics.GetMinimumAltitude();
			}
			return 0f;
		}
		return 0f;
	}

	public override float GetMinimumSpeed_Total(float Altitude, bool ValidateAndFixAltitude)
	{
		return ((Group)myUnit).GroupLead.Kinematics.GetMinimumSpeed_Total(Altitude, ValidateAndFixAltitude);
	}

	public override int GetMaximumSpeed(float Altitude, ActiveUnit.Throttle ThrottleSetting, bool ValidateAndFixAltitude, bool ConsiderDamage = true)
	{
		Group obj = (Group)myUnit;
		if (obj.CompositionType != Group.E_CompositionType.Homogenous_DBIDandLoadout && obj.CompositionType != Group.E_CompositionType.Homogenous_DBID)
		{
			return (int)Math.Round(obj.GetMaximumCohesiveSpeed(ThrottleSetting, Altitude, EvaluateDamages: true));
		}
		if (obj.GroupLead == null)
		{
			return 0;
		}
		return ((Group)myUnit).GroupLead.Kinematics.GetMaximumSpeed(Altitude, ThrottleSetting, ValidateAndFixAltitude);
	}

	public int GroupMaxSpeedForThisThrottleSetting(ActiveUnit.Throttle ThrottleSetting)
	{
		int num = 200000000;
		int result;
		try
		{
			foreach (ActiveUnit value in ((Group)myUnit).Units.Values)
			{
				int maximumSpeed = value.Kinematics.GetMaximumSpeed(value.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ThrottleSetting, ValidateAndFixAltitude: false);
				if (maximumSpeed < num)
				{
					num = maximumSpeed;
				}
			}
			result = num;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100617", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num2;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num2 = 0;
			}
			else
			{
				num2 = 0;
			}
			result = num2;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public int GroupMaxSpeedForThisSpeedSetting(int Speed)
	{
		int num = 200000000;
		int result;
		try
		{
			foreach (ActiveUnit value in ((Group)myUnit).Units.Values)
			{
				int maximumSpeed = value.Kinematics.GetMaximumSpeed();
				if (maximumSpeed < num)
				{
					num = maximumSpeed;
				}
			}
			result = num;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100618", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num2;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num2 = 0;
			}
			else
			{
				num2 = 0;
			}
			result = num2;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public float GroupMaxAltitude()
	{
		float num = 0f;
		float result;
		try
		{
			foreach (ActiveUnit value in ((Group)myUnit).Units.Values)
			{
				float maximumAltitude = value.Kinematics.GetMaximumAltitude();
				if (maximumAltitude > num)
				{
					num = maximumAltitude;
				}
			}
			result = num;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100619", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = 0f;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void SetDesiredAltitude(float theAltitude)
	{
		myUnit.DesiredAltitude = theAltitude;
		foreach (ActiveUnit value in ((Group)myUnit).Units.Values)
		{
			value.DesiredAltitude = theAltitude;
		}
	}

	static Group_Kinematics()
	{
		Class72.smethod_20();
	}
}
