using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Group_AI : ActiveUnit_AI
{
	public SubmarineDepthPreset DepthPreset
	{
		get
		{
			Group obj = (Group)myUnit;
			if (Information.IsNothing((object)obj.GroupLead))
			{
				obj.DesignateGroupLead_Auto();
			}
			if (Information.IsNothing((object)obj.GroupLead))
			{
				return SubmarineDepthPreset.None;
			}
			return ((Submarine)obj.GroupLead).AI.DepthPreset;
		}
		set
		{
			Group obj = (Group)myUnit;
			if (Information.IsNothing((object)obj.GroupLead))
			{
				obj.DesignateGroupLead_Auto();
			}
			if (!Information.IsNothing((object)obj.GroupLead))
			{
				((Submarine)obj.GroupLead).AI.DepthPreset = value;
				if (value != SubmarineDepthPreset.None)
				{
					obj.Kinematics.DesiredAltitudeOverride = true;
				}
			}
		}
	}

	public AircraftAltitudePreset AltitudePreset
	{
		get
		{
			Group obj = (Group)myUnit;
			if (Information.IsNothing((object)obj.GroupLead))
			{
				obj.DesignateGroupLead_Auto();
			}
			if (Information.IsNothing((object)obj.GroupLead))
			{
				return AircraftAltitudePreset.None;
			}
			return ((Aircraft)obj.GroupLead).AI.AltitudePreset;
		}
		set
		{
			Group obj = (Group)myUnit;
			if (Information.IsNothing((object)obj.GroupLead))
			{
				obj.DesignateGroupLead_Auto();
			}
			if (!Information.IsNothing((object)obj.GroupLead))
			{
				((Aircraft)obj.GroupLead).AI.AltitudePreset = value;
				if (value != AircraftAltitudePreset.None)
				{
					obj.Kinematics.DesiredAltitudeOverride = true;
				}
			}
		}
	}

	public override Contact PrimaryTarget
	{
		get
		{
			if (!Information.IsNothing((object)((Group)myUnit).GroupLead))
			{
				return ((Group)myUnit).GroupLead.AI.PrimaryTarget;
			}
			return null;
		}
		set
		{
			if (Information.IsNothing((object)((Group)myUnit).GroupLead))
			{
				((Group)myUnit).DesignateGroupLead_Auto();
			}
			if (!Information.IsNothing((object)((Group)myUnit).GroupLead))
			{
				((Group)myUnit).GroupLead.AI.PrimaryTarget = value;
			}
		}
	}

	public static Group_AI FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Expected O, but got Unknown
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Expected O, but got Unknown
		Group_AI result;
		try
		{
			Group_AI group_AI = new Group_AI(ref theAU);
			group_AI.myUnit = theAU;
			if (Operators.CompareString(theNode.ChildNodes[0].Name, "ActiveUnit_AI", false) == 0)
			{
				theNode = theNode.ChildNodes[0];
			}
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "Threats":
					if (group_AI._Threats == null)
					{
						group_AI._Threats = new List<Contact>();
					}
					foreach (XmlNode childNode2 in val.ChildNodes)
					{
						XmlNode theNode3 = childNode2;
						Contact item = Contact.FromXML(ref theNode3, ref theDictionary);
						group_AI._Threats.Add(item);
					}
					break;
				case "PrimaryThreat":
					group_AI._PrimaryThreat = Contact.FromXML(val.InnerText, ref theDictionary);
					break;
				case "PrimaryTarget":
					group_AI._PrimaryTarget = Contact.FromXML(val.InnerText, ref theDictionary);
					break;
				case "IgnorePlottedCourse":
				case "IPC":
					if (!Information.IsNothing((object)theAU.Doctrine))
					{
						theAU.Doctrine.set_IgnorePlottedCourse(theAU.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._UseIgnorePlottedCourse?)(Doctrine._UseIgnorePlottedCourse)(0u - (Misc.ParseBool(val.InnerText) ? 1u : 0u)));
					}
					break;
				case "TargetList":
					group_AI._TargetList = new ObservableDictionary<string, TargetingEntry>();
					foreach (XmlNode childNode3 in val.ChildNodes)
					{
						XmlNode theNode2 = childNode3;
						TargetingEntry targetingEntry = TargetingEntry.FromXML(ref theNode2, ref theDictionary);
						if (targetingEntry.Target != null)
						{
							group_AI._TargetList.Add(targetingEntry.Target.ObjectID, targetingEntry);
						}
					}
					break;
				case "PrimaryTargetOverride":
					group_AI.PrimaryTargetOverrideExists = Misc.ParseBool(val.InnerText);
					break;
				case "MSF":
					uint.TryParse(val.InnerText, out group_AI._Mission_State_Flags);
					break;
				}
			}
			result = group_AI;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100603", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Group_AI(ref theAU);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
		try
		{
			if (!Information.IsNothing((object)PrimaryTarget))
			{
				theWriter.WriteElementString("PrimaryTarget", PrimaryTarget.ObjectID);
			}
			if (!Information.IsNothing((object)_PrimaryThreat))
			{
				theWriter.WriteElementString("PrimaryThreat", _PrimaryThreat.ObjectID);
			}
			theWriter.WriteElementString("TTNPTE", XmlConvert.ToString(TimeToNextTargetsEvaluation));
			theWriter.WriteElementString("PTOE", PrimaryTargetOverrideExists.ToString());
			if (IsEscort)
			{
				theWriter.WriteElementString("IE", IsEscort.ToString());
			}
			if (!Information.IsNothing((object)_LastKnownTargetLocation))
			{
				theWriter.WriteStartElement("LKTL");
				theWriter.WriteRaw(_LastKnownTargetLocation.ToXML(ObjectsAlreadySerialized));
				theWriter.WriteEndElement();
			}
			if (_TargetList != null && _TargetList.Count > 0)
			{
				theWriter.WriteStartElement("TargetList");
				foreach (TargetingEntry value in _TargetList.Values)
				{
					if (!Information.IsNothing((object)value.Target.ActualUnit))
					{
						theWriter.WriteRaw(value.ToXML(myUnit.get_UnitSide(SetSideOnly: false)));
					}
				}
				theWriter.WriteEndElement();
			}
			if (_Threats != null && _Threats.Count > 0)
			{
				theWriter.WriteStartElement("Threats");
				List<Contact> list = new List<Contact>(_Threats);
				foreach (Contact item in list)
				{
					if (item != null)
					{
						theWriter.WriteRaw(item.ToXML(ObjectsAlreadySerialized, myUnit.get_UnitSide(SetSideOnly: false)));
					}
				}
				theWriter.WriteEndElement();
			}
			if (!Information.IsNothing((object)SnakeAxis))
			{
				theWriter.WriteElementString("SnakeAxis", Conversions.ToString(SnakeAxis.Value));
			}
			if ((long)_Mission_State_Flags > 0L)
			{
				theWriter.WriteElementString("MSF", _Mission_State_Flags.ToString());
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100604", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void EvaluateTargets(float elapsedTime, bool IgnoreContacStance, bool Immediately)
	{
	}

	public Group_AI(ref ActiveUnit theUnit)
		: base(theUnit)
	{
	}

	public override void FollowAltitudePreset()
	{
		if (myUnit != null && myUnit.IsGroup)
		{
			((Group)myUnit).GroupLead.AI.FollowAltitudePreset();
		}
	}

	public static float OverLayerDepth(ActiveUnit myUnit)
	{
		return SonarModel.GetThermalLayerAtThisLocation(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)myUnit).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, myUnit.ParentScen), myUnit.ParentScen).Ceiling + 10;
	}

	public static float UnderLayerDepth(ActiveUnit myUnit)
	{
		return SonarModel.GetThermalLayerAtThisLocation(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)myUnit).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, myUnit.ParentScen), myUnit.ParentScen).Floor - 10;
	}

	public override void FollowDepthPreset(bool CheckThreats)
	{
		if (myUnit == null || !myUnit.IsGroup)
		{
			return;
		}
		switch (((Group)myUnit).GroupLead.UnitType)
		{
		case GlobalVariables.ActiveUnitType.Submarine:
			((Group)myUnit).GroupLead.AI.FollowDepthPreset(CheckThreats);
			return;
		case GlobalVariables.ActiveUnitType.Aircraft:
			((Group)myUnit).GroupLead.AI.FollowAltitudePreset();
			return;
		}
		if (!Debugger.IsAttached)
		{
			throw new NotImplementedException();
		}
		Debugger.Break();
	}

	public override void TargetThisContact(Contact theContact, bool AddedManually, bool PriorityTarget, TargetingEntry._TargetingBehavior TargetingBehavior)
	{
		try
		{
			if (theContact.Type == Contact_Base.ContactType.Sonobuoy)
			{
				return;
			}
			if (theContact.Type == Contact_Base.ContactType.Missile)
			{
				Weapon weapon = (Weapon)theContact.ActualUnit;
				if (weapon.ValidTargets.Aircraft || weapon.ValidTargets.Missile)
				{
					if (AddedManually)
					{
						myUnit.Message = "Cannot shoot at an AAW weapon!";
					}
					return;
				}
			}
			foreach (ActiveUnit value in ((Group)myUnit).Units.Values)
			{
				if (!value.CommStuff.IsConnectedToSideNetwork)
				{
					if (AddedManually)
					{
						value.AddMessage(value.Name + " cannot participate in attack (unable to issue orders to unit)", "Cannot issue orders to " + value.Name, LoggedMessage.MessageType.UnitAI, 0, new Geopoint_Struct(value.get_Longitude((GlobalVariables.BooleanObject)null), value.get_Latitude((GlobalVariables.BooleanObject)null)));
					}
					continue;
				}
				ActiveUnit_Weaponry weaponry = value.Weaponry;
				Doctrine doctrine = myUnit.Doctrine;
				string Feedback = string.Empty;
				int FeedbackSeverity = 0;
				if (!weaponry.HaveAvailableWeaponSuitableForThisTarget(theContact, CheckWRA: true, doctrine, ref Feedback, ref FeedbackSeverity, HumanFeedBackNeeded: false))
				{
					TargetingEntry._TargetingBehavior targetingBehavior = TargetingBehavior;
					if ((uint)(targetingBehavior - 1) <= 1u)
					{
						Notification_Bark.Create_UnitBehaviour(value, "Cannot engage: No suitable weapons available or allowed (Doctrine/WCS/WRA)", Color.Yellow);
					}
				}
				else
				{
					value.AI.TargetThisContact(theContact, AddedManually: true, PriorityTarget, TargetingBehavior);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100606", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void EvaluateUnitStatus(float elapsedTime, bool ForceFuelStateCheck, bool ForceWeaponStateCheck)
	{
	}

	public override void DropTarget(Contact theTarget, bool IgnoreTargetIllumination = true)
	{
		foreach (ActiveUnit value in ((Group)myUnit).Units.Values)
		{
			value.AI.DropTarget(theTarget);
		}
	}

	public override void DetermineDesiredAttitudeAndThrottle(float elapsedTime, bool RecalculatePlottedCourse = true)
	{
	}

	public override void DeterminePrimaryTarget(float elapsedTime, bool IgnoreTimeToNextEvaluation, bool CheckCombatRadius)
	{
	}

	internal override void DeterminePrimaryPickupTarget()
	{
		if (PickupTargets == null || PickupTargets.Count == 0)
		{
			return;
		}
		List<ActiveUnit> list = ((Group)myUnit).Units.Values.ToList();
		foreach (ActiveUnit item in list)
		{
			foreach (string pickupTarget in PickupTargets)
			{
				item.AI.AddPickupTarget(pickupTarget);
			}
		}
		PickupTargets = null;
	}

	static Group_AI()
	{
		Class72.smethod_20();
	}
}
