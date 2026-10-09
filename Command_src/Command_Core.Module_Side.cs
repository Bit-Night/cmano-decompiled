using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class Module_Side
{
	[CompilerGenerated]
	internal sealed class _Closure$__1-0
	{
		public Contact $VB$Local_MasterContact;

		public Contact $VB$Local_theOtherContact;

		public _Closure$__1-0(_Closure$__1-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_MasterContact = arg0.$VB$Local_MasterContact;
				$VB$Local_theOtherContact = arg0.$VB$Local_theOtherContact;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			$VB$Local_MasterContact.UncertaintyArea = ActiveUnit_Sensory.GetRefinedUncertaintyArea_Clipper($VB$Local_MasterContact.UncertaintyArea, $VB$Local_theOtherContact.UncertaintyArea);
		}

		static _Closure$__1-0()
		{
			Class72.smethod_20();
		}
	}

	public static bool IsAlliedWithThisSide(this Side mySide, Side Targetside)
	{
		if (mySide.get_ConsidersThisSideToBe(Targetside, (Scenario)null) != Misc.PostureStance.Friendly)
		{
			return false;
		}
		if (Targetside.get_ConsidersThisSideToBe(mySide, (Scenario)null) != Misc.PostureStance.Friendly)
		{
			return false;
		}
		return true;
	}

	public static void UpdateMasterContactDataFromOtherContact(this Side SideHoldingMasterContact, Contact MasterContact, Contact theOtherContact, ActiveUnit UnitProvidingUpdatedData, Scenario theScen, bool RefineAoU)
	{
		_Closure$__1-0 arg = default(_Closure$__1-0);
		_Closure$__1-0 CS$<>8__locals143 = new _Closure$__1-0(arg);
		CS$<>8__locals143.$VB$Local_MasterContact = MasterContact;
		CS$<>8__locals143.$VB$Local_theOtherContact = theOtherContact;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		bool flag5 = false;
		bool flag6 = false;
		if (CS$<>8__locals143.$VB$Local_MasterContact.Age > CS$<>8__locals143.$VB$Local_theOtherContact.Age)
		{
			if (!CS$<>8__locals143.$VB$Local_MasterContact.IsAutoDetection)
			{
				if (CS$<>8__locals143.$VB$Local_theOtherContact.SpeedIsKnown && !CS$<>8__locals143.$VB$Local_MasterContact.SpeedIsKnown)
				{
					CS$<>8__locals143.$VB$Local_MasterContact.SpeedIsKnown = true;
					flag = true;
				}
				if (CS$<>8__locals143.$VB$Local_theOtherContact.HeadingIsKnown && !CS$<>8__locals143.$VB$Local_MasterContact.HeadingIsKnown)
				{
					CS$<>8__locals143.$VB$Local_MasterContact.HeadingIsKnown = true;
					flag = true;
				}
				if (CS$<>8__locals143.$VB$Local_theOtherContact.AltitudeIsKnown && !CS$<>8__locals143.$VB$Local_MasterContact.AltitudeIsKnown)
				{
					CS$<>8__locals143.$VB$Local_MasterContact.AltitudeIsKnown = true;
					flag = true;
				}
				if (((Module_Unit.Unit)CS$<>8__locals143.$VB$Local_MasterContact).get_Longitude((GlobalVariables.BooleanObject)null) != ((Module_Unit.Unit)CS$<>8__locals143.$VB$Local_theOtherContact).get_Longitude((GlobalVariables.BooleanObject)null))
				{
					((Module_Unit.Unit)CS$<>8__locals143.$VB$Local_MasterContact).set_Longitude((GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)CS$<>8__locals143.$VB$Local_theOtherContact).get_Longitude((GlobalVariables.BooleanObject)null));
					flag = true;
				}
				if (((Module_Unit.Unit)CS$<>8__locals143.$VB$Local_MasterContact).get_Latitude((GlobalVariables.BooleanObject)null) != ((Module_Unit.Unit)CS$<>8__locals143.$VB$Local_theOtherContact).get_Latitude((GlobalVariables.BooleanObject)null))
				{
					((Module_Unit.Unit)CS$<>8__locals143.$VB$Local_MasterContact).set_Latitude((GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)CS$<>8__locals143.$VB$Local_theOtherContact).get_Latitude((GlobalVariables.BooleanObject)null));
					flag = true;
				}
				if (CS$<>8__locals143.$VB$Local_MasterContact.CurrentSpeed != CS$<>8__locals143.$VB$Local_theOtherContact.CurrentSpeed)
				{
					CS$<>8__locals143.$VB$Local_MasterContact.CurrentSpeed = CS$<>8__locals143.$VB$Local_theOtherContact.CurrentSpeed;
					flag = true;
				}
				if (((Module_Unit.Unit)CS$<>8__locals143.$VB$Local_MasterContact).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) != ((Module_Unit.Unit)CS$<>8__locals143.$VB$Local_theOtherContact).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))
				{
					((Module_Unit.Unit)CS$<>8__locals143.$VB$Local_MasterContact).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)CS$<>8__locals143.$VB$Local_theOtherContact).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
					flag = true;
				}
				if (CS$<>8__locals143.$VB$Local_MasterContact.CurrentHeading != CS$<>8__locals143.$VB$Local_theOtherContact.CurrentHeading)
				{
					CS$<>8__locals143.$VB$Local_MasterContact.CurrentHeading = CS$<>8__locals143.$VB$Local_theOtherContact.CurrentHeading;
					flag = true;
				}
				if (RefineAoU && (CS$<>8__locals143.$VB$Local_MasterContact.UncertaintyArea != null || CS$<>8__locals143.$VB$Local_theOtherContact.UncertaintyArea != null))
				{
					if (CS$<>8__locals143.$VB$Local_MasterContact.UncertaintyArea != null && CS$<>8__locals143.$VB$Local_theOtherContact.UncertaintyArea != null)
					{
						Task task = new Task([SpecialName] () =>
						{
							CS$<>8__locals143.$VB$Local_MasterContact.UncertaintyArea = ActiveUnit_Sensory.GetRefinedUncertaintyArea_Clipper(CS$<>8__locals143.$VB$Local_MasterContact.UncertaintyArea, CS$<>8__locals143.$VB$Local_theOtherContact.UncertaintyArea);
						});
						GameGeneral.TaskList_PostPulseHousekeeping_RefineAOU.Add(task);
						task.Start();
						flag = true;
					}
					else if ((CS$<>8__locals143.$VB$Local_MasterContact.UncertaintyArea != null || CS$<>8__locals143.$VB$Local_theOtherContact.UncertaintyArea == null) && CS$<>8__locals143.$VB$Local_MasterContact.UncertaintyArea != null && CS$<>8__locals143.$VB$Local_theOtherContact.UncertaintyArea == null)
					{
						CS$<>8__locals143.$VB$Local_MasterContact.UncertaintyArea = null;
						flag = true;
					}
				}
				CS$<>8__locals143.$VB$Local_MasterContact.Age = CS$<>8__locals143.$VB$Local_theOtherContact.Age;
				CS$<>8__locals143.$VB$Local_MasterContact.HeldFor = CS$<>8__locals143.$VB$Local_theOtherContact.HeldFor;
			}
			if ((!CS$<>8__locals143.$VB$Local_MasterContact.SideIsKnown || !CS$<>8__locals143.$VB$Local_theOtherContact.SideIsKnown) && (!CS$<>8__locals143.$VB$Local_MasterContact.SideIsKnown || CS$<>8__locals143.$VB$Local_theOtherContact.SideIsKnown) && !CS$<>8__locals143.$VB$Local_MasterContact.SideIsKnown && CS$<>8__locals143.$VB$Local_theOtherContact.SideIsKnown)
			{
				CS$<>8__locals143.$VB$Local_MasterContact.SideIsKnown = true;
				flag2 = true;
			}
			ActiveUnit_Sensory.MergeDetectedEmissions(CS$<>8__locals143.$VB$Local_MasterContact, CS$<>8__locals143.$VB$Local_theOtherContact.DetectedEmissions);
			if (CS$<>8__locals143.$VB$Local_MasterContact.ListOfESMMatches != null && CS$<>8__locals143.$VB$Local_theOtherContact.ListOfESMMatches != null)
			{
				CS$<>8__locals143.$VB$Local_MasterContact.ListOfESMMatches = CS$<>8__locals143.$VB$Local_MasterContact.ListOfESMMatches.Union(CS$<>8__locals143.$VB$Local_theOtherContact.ListOfESMMatches).ToList();
				flag3 = true;
			}
			if (!CS$<>8__locals143.$VB$Local_MasterContact.IsAutoDetection)
			{
				if (CS$<>8__locals143.$VB$Local_MasterContact.TimeSinceDetection_Radar != -1f)
				{
					if (CS$<>8__locals143.$VB$Local_theOtherContact.TimeSinceDetection_Radar != -1f)
					{
						CS$<>8__locals143.$VB$Local_MasterContact.TimeSinceDetection_Radar = Math.Min(CS$<>8__locals143.$VB$Local_MasterContact.TimeSinceDetection_Radar, CS$<>8__locals143.$VB$Local_theOtherContact.TimeSinceDetection_Radar);
					}
				}
				else if (CS$<>8__locals143.$VB$Local_theOtherContact.TimeSinceDetection_Radar != -1f)
				{
					CS$<>8__locals143.$VB$Local_MasterContact.TimeSinceDetection_Radar = CS$<>8__locals143.$VB$Local_theOtherContact.TimeSinceDetection_Radar;
				}
				if (CS$<>8__locals143.$VB$Local_MasterContact.TimeSinceDetection_ESM != -1f)
				{
					if (CS$<>8__locals143.$VB$Local_theOtherContact.TimeSinceDetection_ESM != -1f)
					{
						CS$<>8__locals143.$VB$Local_MasterContact.TimeSinceDetection_ESM = Math.Min(CS$<>8__locals143.$VB$Local_MasterContact.TimeSinceDetection_ESM, CS$<>8__locals143.$VB$Local_theOtherContact.TimeSinceDetection_ESM);
					}
				}
				else if (CS$<>8__locals143.$VB$Local_theOtherContact.TimeSinceDetection_ESM != -1f)
				{
					CS$<>8__locals143.$VB$Local_MasterContact.TimeSinceDetection_ESM = CS$<>8__locals143.$VB$Local_theOtherContact.TimeSinceDetection_ESM;
				}
				if (CS$<>8__locals143.$VB$Local_MasterContact.TimeSinceDetection_Visual != -1f)
				{
					if (CS$<>8__locals143.$VB$Local_theOtherContact.TimeSinceDetection_Visual != -1f)
					{
						CS$<>8__locals143.$VB$Local_MasterContact.TimeSinceDetection_Visual = Math.Min(CS$<>8__locals143.$VB$Local_MasterContact.TimeSinceDetection_Visual, CS$<>8__locals143.$VB$Local_theOtherContact.TimeSinceDetection_Visual);
					}
				}
				else if (CS$<>8__locals143.$VB$Local_theOtherContact.TimeSinceDetection_Visual != -1f)
				{
					CS$<>8__locals143.$VB$Local_MasterContact.TimeSinceDetection_Visual = CS$<>8__locals143.$VB$Local_theOtherContact.TimeSinceDetection_Visual;
				}
				if (CS$<>8__locals143.$VB$Local_MasterContact.TimeSinceDetection_Infrared != -1f)
				{
					if (CS$<>8__locals143.$VB$Local_theOtherContact.TimeSinceDetection_Infrared != -1f)
					{
						CS$<>8__locals143.$VB$Local_MasterContact.TimeSinceDetection_Infrared = Math.Min(CS$<>8__locals143.$VB$Local_MasterContact.TimeSinceDetection_Infrared, CS$<>8__locals143.$VB$Local_theOtherContact.TimeSinceDetection_Infrared);
					}
				}
				else if (CS$<>8__locals143.$VB$Local_theOtherContact.TimeSinceDetection_Infrared != -1f)
				{
					CS$<>8__locals143.$VB$Local_MasterContact.TimeSinceDetection_Infrared = CS$<>8__locals143.$VB$Local_theOtherContact.TimeSinceDetection_Infrared;
				}
				if (CS$<>8__locals143.$VB$Local_MasterContact.TimeSinceDetection_SonarActive != -1f)
				{
					if (CS$<>8__locals143.$VB$Local_theOtherContact.TimeSinceDetection_SonarActive != -1f)
					{
						CS$<>8__locals143.$VB$Local_MasterContact.TimeSinceDetection_SonarActive = Math.Min(CS$<>8__locals143.$VB$Local_MasterContact.TimeSinceDetection_SonarActive, CS$<>8__locals143.$VB$Local_theOtherContact.TimeSinceDetection_SonarActive);
					}
				}
				else if (CS$<>8__locals143.$VB$Local_theOtherContact.TimeSinceDetection_SonarActive != -1f)
				{
					CS$<>8__locals143.$VB$Local_MasterContact.TimeSinceDetection_SonarActive = CS$<>8__locals143.$VB$Local_theOtherContact.TimeSinceDetection_SonarActive;
				}
				if (CS$<>8__locals143.$VB$Local_MasterContact.TimeSinceDetection_SonarPassive != -1f)
				{
					if (CS$<>8__locals143.$VB$Local_theOtherContact.TimeSinceDetection_SonarPassive != -1f)
					{
						CS$<>8__locals143.$VB$Local_MasterContact.TimeSinceDetection_SonarPassive = Math.Min(CS$<>8__locals143.$VB$Local_MasterContact.TimeSinceDetection_SonarPassive, CS$<>8__locals143.$VB$Local_theOtherContact.TimeSinceDetection_SonarPassive);
					}
				}
				else if (CS$<>8__locals143.$VB$Local_theOtherContact.TimeSinceDetection_SonarPassive != -1f)
				{
					CS$<>8__locals143.$VB$Local_MasterContact.TimeSinceDetection_SonarPassive = CS$<>8__locals143.$VB$Local_theOtherContact.TimeSinceDetection_SonarPassive;
				}
			}
		}
		if (CS$<>8__locals143.$VB$Local_MasterContact.TimeSinceBDA > CS$<>8__locals143.$VB$Local_theOtherContact.TimeSinceBDA)
		{
			if (CS$<>8__locals143.$VB$Local_theOtherContact.BDA_StructuralIntegrity.HasValue)
			{
				CS$<>8__locals143.$VB$Local_MasterContact.BDA_StructuralIntegrity = CS$<>8__locals143.$VB$Local_theOtherContact.BDA_StructuralIntegrity;
			}
			if (CS$<>8__locals143.$VB$Local_theOtherContact.BDA_FireLevel.HasValue)
			{
				CS$<>8__locals143.$VB$Local_MasterContact.BDA_FireLevel = CS$<>8__locals143.$VB$Local_theOtherContact.BDA_FireLevel;
			}
			int num;
			if (!CS$<>8__locals143.$VB$Local_theOtherContact.BDA_FloodLevel.HasValue)
			{
				num = 1;
			}
			else
			{
				CS$<>8__locals143.$VB$Local_MasterContact.BDA_FloodLevel = CS$<>8__locals143.$VB$Local_theOtherContact.BDA_FloodLevel;
				num = 1;
			}
			flag4 = (byte)num != 0;
		}
		if (CS$<>8__locals143.$VB$Local_MasterContact.TimeSinceRecon > CS$<>8__locals143.$VB$Local_theOtherContact.TimeSinceRecon)
		{
			foreach (Contact.HostedUnitReconRecord item in CS$<>8__locals143.$VB$Local_theOtherContact.Recon_HostedUnits(SideHoldingMasterContact))
			{
				Contact.HostedUnitReconRecord hostedUnitReconRecord = item;
				bool flag7 = false;
				foreach (Contact.HostedUnitReconRecord item2 in CS$<>8__locals143.$VB$Local_MasterContact.Recon_HostedUnits(SideHoldingMasterContact))
				{
					if (Operators.CompareString(item2.UnitID, hostedUnitReconRecord.UnitID, false) == 0)
					{
						flag7 = true;
						if (item2.IDStatus > hostedUnitReconRecord.IDStatus)
						{
							hostedUnitReconRecord = item2;
							flag5 = true;
						}
					}
				}
				if (!flag7)
				{
					Contact.HostedUnitReconRecord hostedUnitReconRecord2 = new Contact.HostedUnitReconRecord();
					hostedUnitReconRecord2.UnitID = hostedUnitReconRecord.UnitID;
					hostedUnitReconRecord2.IDStatus = hostedUnitReconRecord.IDStatus;
					hostedUnitReconRecord2.ReconAge = hostedUnitReconRecord.ReconAge;
					CS$<>8__locals143.$VB$Local_MasterContact.Recon_HostedUnits(SideHoldingMasterContact).Add(hostedUnitReconRecord2);
					flag5 = true;
				}
			}
		}
		if (CS$<>8__locals143.$VB$Local_theOtherContact.IDStatus > CS$<>8__locals143.$VB$Local_MasterContact.IDStatus)
		{
			CS$<>8__locals143.$VB$Local_MasterContact.set_IDStatus(theScen, SideHoldingMasterContact, (Sensor)null, (float?)null, IsNCTRupdate: false, StatusUpdateIsOnCommsGrid: true, bool_5: false, GenerateMessage: true, CS$<>8__locals143.$VB$Local_theOtherContact.IDStatus);
			int num2;
			if (Operators.CompareString(CS$<>8__locals143.$VB$Local_MasterContact.Name, CS$<>8__locals143.$VB$Local_theOtherContact.Name, false) != 0)
			{
				theScen.AddMessage("Contact: " + CS$<>8__locals143.$VB$Local_MasterContact.Name + " is now known as: " + CS$<>8__locals143.$VB$Local_theOtherContact.Name, CS$<>8__locals143.$VB$Local_MasterContact.Name + " renamed", LoggedMessage.MessageType.ContactChange, 0, null, SideHoldingMasterContact, new Geopoint_Struct(((Module_Unit.Unit)CS$<>8__locals143.$VB$Local_MasterContact).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)CS$<>8__locals143.$VB$Local_MasterContact).get_Latitude((GlobalVariables.BooleanObject)null)));
				CS$<>8__locals143.$VB$Local_MasterContact.Name = CS$<>8__locals143.$VB$Local_theOtherContact.Name;
				num2 = 1;
			}
			else
			{
				num2 = 1;
			}
			flag6 = (byte)num2 != 0;
		}
		if ((flag || flag2 || flag3 || flag4 || flag5 || flag6) && UnitProvidingUpdatedData != null)
		{
			string text = "Updating data for contact: " + CS$<>8__locals143.$VB$Local_MasterContact.Name + ", based on new information by: " + UnitProvidingUpdatedData.Name + ". Updated info includes: ";
			List<string> list = new List<string>();
			if (flag)
			{
				list.Add("position data");
			}
			if (flag2)
			{
				list.Add("side info");
			}
			if (flag3)
			{
				list.Add("ESM data");
			}
			if (flag4)
			{
				list.Add("BDA data");
			}
			if (flag5)
			{
				list.Add("info on hosted units");
			}
			if (flag6)
			{
				list.Add("ID status");
			}
			text = text + string.Join(", ", list) + ".";
			UnitProvidingUpdatedData.AddMessage(text, "Contact updated", LoggedMessage.MessageType.ContactChange, 0, new Geopoint_Struct(UnitProvidingUpdatedData.get_Longitude((GlobalVariables.BooleanObject)null), UnitProvidingUpdatedData.get_Latitude((GlobalVariables.BooleanObject)null)));
		}
	}

	public static void ShareContactWithFriends(this Side mySide, Scenario theScen, Contact theC, HashSet<Side> FriendlySides)
	{
		if (mySide.Units.Count <= 0)
		{
			return;
		}
		foreach (Side FriendlySide in FriendlySides)
		{
			if (FriendlySide == mySide || FriendlySide.Units.Count <= 0 || theC.ActualUnit == null)
			{
				continue;
			}
			Contact value = null;
			if (FriendlySide.Contacts.TryGetValue(theC.ActualUnit.ObjectID, out value))
			{
				Contact.smethod_3(theC, value);
				bool flag = FriendlySide.get_ConsidersThisSideToBe(mySide, (Scenario)null) == Misc.PostureStance.Friendly;
				if (theC != value)
				{
					UpdateMasterContactDataFromOtherContact(FriendlySide, value, theC, null, theScen, RefineAoU: true);
					if (flag)
					{
						UpdateMasterContactDataFromOtherContact(mySide, theC, value, null, theScen, RefineAoU: true);
					}
					FriendlySide.ContactsJustSharedWithMe.Add(theC.ActualUnit.ObjectID);
				}
			}
			else if (!IsAlliedWithThisSide(theC.ActualUnit.get_UnitSide(SetSideOnly: false), FriendlySide) && theC.ActualUnit.get_UnitSide(SetSideOnly: false) != FriendlySide)
			{
				Contact contact = Contact.Instantiate(theC.ActualUnit, FriendlySide.ContactAutoIncrement);
				contact.set_IDStatus(theScen, FriendlySide, (Sensor)null, (float?)null, IsNCTRupdate: false, StatusUpdateIsOnCommsGrid: true, bool_5: false, GenerateMessage: false, theC.IDStatus);
				contact.Name = theC.Name;
				contact.Age = theC.Age + 1f;
				UpdateMasterContactDataFromOtherContact(mySide, contact, theC, null, theScen, RefineAoU: true);
				if (contact.LastDetections.Count == 0)
				{
					contact.AddDetectionRecord(new Contact.Detection_Struct(mySide.Name, null, 0f, ActiveUnit_Sensory.SpecialDetectionMode.ContactSharing, theScen.Time));
				}
				FriendlySide.AddContact(contact);
				FriendlySide.ContactsJustSharedWithMe.Add(contact.ActualUnit.ObjectID);
			}
		}
	}

	static Module_Side()
	{
		Class72.smethod_20();
	}
}
