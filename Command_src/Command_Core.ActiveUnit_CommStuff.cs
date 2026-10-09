using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using Collections.Pooled;
using ConcurrentObservableCollections.ConcurrentObservableDictionary;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ThreadSafeCollections;

namespace Command_Core;

public class ActiveUnit_CommStuff
{
	public enum ReasonForGoingOffGrid
	{
		None,
		ChangeOfInternalStatus,
		AllCommDevicesDisabled,
		DivingDeep
	}

	public enum CommConnectionChecklistEvaluation
	{
		Undefined,
		OK,
		UnavailableUnit,
		CommJamming,
		const_4,
		OtherNegative
	}

	private struct Struct12
	{
		public string string_0;

		public Transmission transmission_0;

		public ActiveUnit activeUnit_0;
	}

	public struct TransmissionContactData
	{
		public string ObjectID;

		public CommDevice.EnumCommQuality Bandwith;

		public CommDevice.EnumCommLatency Latency;

		public string TransmittedBy;

		public DateTime LastUpdate;

		public double Latitude;

		public double Longitude;

		public float Altitude;

		public float Heading;

		public float Speed;

		public bool IsFrozen;

		public DateTime LastRelayedAt;
	}

	[CompilerGenerated]
	internal sealed class _Closure$__47-0
	{
		public KeyValuePair<string, List<Transmission>> $VB$Local_kvpOuter;

		public _Closure$__47-0(_Closure$__47-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_kvpOuter = arg0.$VB$Local_kvpOuter;
			}
		}

		[SpecialName]
		internal Struct12 _Lambda$__1(Transmission transmission)
		{
			return new Struct12
			{
				string_0 = $VB$Local_kvpOuter.Key,
				transmission_0 = transmission,
				activeUnit_0 = ((transmission.SenderUnitList == null || transmission.SenderUnitList.Count <= 0) ? null : transmission.SenderUnitList.First())
			};
		}

		static _Closure$__47-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__47-1
	{
		public string $VB$Local_commDeviceObjectID;

		public CommDevice $VB$Local_theCommDeviceUsed;

		public ActiveUnit $VB$Local_senderUnit;

		public _Closure$__47-1(_Closure$__47-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_commDeviceObjectID = arg0.$VB$Local_commDeviceObjectID;
				$VB$Local_theCommDeviceUsed = arg0.$VB$Local_theCommDeviceUsed;
				$VB$Local_senderUnit = arg0.$VB$Local_senderUnit;
			}
		}

		[SpecialName]
		internal bool _Lambda$__4(CommDevice cd)
		{
			return Operators.CompareString(cd.ObjectID, $VB$Local_commDeviceObjectID, false) == 0;
		}

		static _Closure$__47-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__47-2
	{
		public TransmittedContactData $VB$Local_thedet;

		public _Closure$__47-1 $VB$NonLocal_$VB$Closure_2;

		public _Closure$__47-2(_Closure$__47-2 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_thedet = arg0.$VB$Local_thedet;
			}
		}

		[SpecialName]
		internal TransmissionContactData _Lambda$__5(string key, TransmissionContactData oldValue)
		{
			return new TransmissionContactData
			{
				ObjectID = key,
				Bandwith = (CommDevice.EnumCommQuality)$VB$NonLocal_$VB$Closure_2.$VB$Local_theCommDeviceUsed.QualityGradeinfo.ID,
				Latency = (CommDevice.EnumCommLatency)$VB$NonLocal_$VB$Closure_2.$VB$Local_theCommDeviceUsed.LatencyGradenfo.ID,
				TransmittedBy = $VB$NonLocal_$VB$Closure_2.$VB$Local_senderUnit.ObjectID,
				LastUpdate = $VB$NonLocal_$VB$Closure_2.$VB$Local_senderUnit.ParentScen.Time,
				Latitude = ((Module_Unit.Unit)$VB$Local_thedet.TheContact).get_Latitude((GlobalVariables.BooleanObject)null),
				Longitude = ((Module_Unit.Unit)$VB$Local_thedet.TheContact).get_Longitude((GlobalVariables.BooleanObject)null),
				Altitude = ((Module_Unit.Unit)$VB$Local_thedet.TheContact).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null),
				Heading = $VB$Local_thedet.TheContact.CurrentHeading,
				Speed = $VB$Local_thedet.TheContact.CurrentSpeed
			};
		}

		static _Closure$__47-2()
		{
			Class72.smethod_20();
		}
	}

	protected ActiveUnit myUnit;

	protected CommLink[] _CommLinksEstablished;

	public float CommsCheckCountdown;

	protected short _IsConnectedToSideNetwork;

	protected bool _InternalCommsStatus;

	protected bool _HasBeenSummonedToReestablishComms;

	internal float TimeOffComms;

	public ConcurrentDictionary<string, TransmissionContactData> ContactsInfoGrade;

	public ReasonForGoingOffGrid ReasonForBeingOffGrid
	{
		get
		{
			if (_InternalCommsStatus)
			{
				int result;
				if (!myUnit.IsSubmarine)
				{
					result = 2;
				}
				else if (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < (float)Submarine.CommsEstablishDepth)
				{
					if (CommsDeviceAvailable)
					{
						return ReasonForGoingOffGrid.DivingDeep;
					}
					result = 2;
				}
				else
				{
					result = 2;
				}
				return (ReasonForGoingOffGrid)result;
			}
			return ReasonForGoingOffGrid.ChangeOfInternalStatus;
		}
	}

	public virtual bool IsConnectedToSideNetwork
	{
		get
		{
			if (_IsConnectedToSideNetwork == -1)
			{
				_IsConnectedToSideNetwork = 1;
			}
			return _IsConnectedToSideNetwork != 0;
		}
	}

	public bool IsConnectedToSideNetwork
	{
		set
		{
			short num = (value ? ((short)1) : ((short)0));
			short isConnectedToSideNetwork = _IsConnectedToSideNetwork;
			bool flag;
			if ((flag = num != isConnectedToSideNetwork) && !value && myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DroneAutonomyLevels) && myUnit.IsDrone())
			{
				if (myUnit.IsGroupMember() && myUnit.AutonomyLevel < ActiveUnit.DroneAutonomyLevel.MultiVehicleCoordination)
				{
					myUnit.DetachUnit(NotifyPlayer: true, ClearPlottedCourse: false, UseFlightplan: true);
				}
				Mission mission = myUnit.ActiveMissionOrPackage();
				if (mission != null)
				{
					Mission mission2 = mission.Clone(DeepCloneRPs: true);
					mission2.Name = "[SNAPSHOT] " + mission.Name;
					if (myUnit.AutonomyLevel < ActiveUnit.DroneAutonomyLevel.FullyAutonomous)
					{
						mission2.Doctrine.set_ShootTourists(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._UseShootTourists?)Doctrine._UseShootTourists.No);
						myUnit.Doctrine.set_ShootTourists(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._UseShootTourists?)Doctrine._UseShootTourists.No);
						List<ReferencePoint> list = null;
						switch (mission2.MissionClass)
						{
						case Mission._MissionClass.Patrol:
							list = ((Patrol)mission2).PatrolArea;
							break;
						case Mission._MissionClass.Support:
							list = ((SupportMission)mission2).NavigationCourse;
							break;
						case Mission._MissionClass.Mining:
							list = ((MiningMission)mission2).Area;
							break;
						case Mission._MissionClass.MineClearing:
							list = ((MineClearingMission)mission2).Area;
							break;
						}
						if (list != null)
						{
							foreach (ReferencePoint item in list)
							{
								item.IsLocked = true;
							}
						}
					}
					myUnit.PrivateSnapshotMission = mission2;
				}
			}
			_IsConnectedToSideNetwork = num;
			if (!flag)
			{
				return;
			}
			if (!value)
			{
				if (theReason == ReasonForGoingOffGrid.ChangeOfInternalStatus)
				{
					_InternalCommsStatus = false;
				}
				myUnit.Sensory.ClearLocalContacts();
				myUnit.Sensory.MakeLocalCopiesOfSideAutodetectables();
				switch (theReason)
				{
				case ReasonForGoingOffGrid.ChangeOfInternalStatus:
					myUnit.AddMessage(myUnit.Name + " has dropped off the communications network! (Network attack or act of God)", myUnit.Name + " now off-grid", LoggedMessage.MessageType.UnitAI, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
					break;
				case ReasonForGoingOffGrid.AllCommDevicesDisabled:
					myUnit.AddMessage(myUnit.Name + " has dropped off the communications network! (All comm devices incapacitated)", myUnit.Name + " now off-grid", LoggedMessage.MessageType.UnitAI, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
					break;
				case ReasonForGoingOffGrid.DivingDeep:
					myUnit.AddMessage(myUnit.Name + " has dropped off the communications network (diving deep)", myUnit.Name + " now off-grid", LoggedMessage.MessageType.UnitAI, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
					break;
				}
				Contact theContact = null;
				ActiveUnit_Sensory.ProcessNewContact(ref theContact, ref myUnit.ParentScen, myUnit.get_UnitSide(SetSideOnly: false), myUnit, ActiveUnit_Sensory.SpecialDetectionMode.AutoDetection, myUnit, Contact_Base.IdentificationStatus.PreciseID);
				theContact.set_Stance(myUnit.get_UnitSide(SetSideOnly: false), MarkManually: false, Misc.PostureStance.Friendly);
				myUnit.get_UnitSide(SetSideOnly: false).AddContact(theContact);
				return;
			}
			_InternalCommsStatus = true;
			myUnit.Sensory.RejoinCommsGrid();
			if (!myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DroneAutonomyLevels) || !myUnit.IsDrone())
			{
				return;
			}
			if (myUnit.PrivateSnapshotMission != null)
			{
				List<ReferencePoint> list2 = null;
				switch (myUnit.PrivateSnapshotMission.MissionClass)
				{
				case Mission._MissionClass.Patrol:
					list2 = ((Patrol)myUnit.PrivateSnapshotMission).PatrolArea;
					break;
				case Mission._MissionClass.Support:
					list2 = ((SupportMission)myUnit.PrivateSnapshotMission).NavigationCourse;
					break;
				case Mission._MissionClass.Mining:
					list2 = ((MiningMission)myUnit.PrivateSnapshotMission).Area;
					break;
				case Mission._MissionClass.MineClearing:
					list2 = ((MineClearingMission)myUnit.PrivateSnapshotMission).Area;
					break;
				}
				list2?.Clear();
			}
			myUnit.PrivateSnapshotMission = null;
		}
	}

	public CommLink[] CommLinksEstablished_ReadOnly => _CommLinksEstablished;

	public bool HasBeenSummonedToReestablishComms
	{
		get
		{
			return _HasBeenSummonedToReestablishComms;
		}
		set
		{
			_HasBeenSummonedToReestablishComms = value;
		}
	}

	public bool CommsDeviceAvailable
	{
		get
		{
			CommDevice[] comms_ReadOnly = myUnit.Comms_ReadOnly;
			if (comms_ReadOnly.Count() != 0)
			{
				if (comms_ReadOnly.Where([SpecialName] (CommDevice theCD) => !theCD.IsWeaponDataLink()).Count() != 0)
				{
					CommDevice[] array = comms_ReadOnly;
					int num = 0;
					while (true)
					{
						if (num < array.Length)
						{
							CommDevice commDevice = array[num];
							if (!commDevice.IsWeaponDataLink() && commDevice.Status == PlatformComponent._ComponentStatus.Operational)
							{
								break;
							}
							num = checked(num + 1);
							continue;
						}
						return false;
					}
					return true;
				}
				return false;
			}
			return false;
		}
	}

	public bool CommJamUnitsAreAffectingMe
	{
		get
		{
			bool result;
			try
			{
				if (!myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.CommsJamming))
				{
					result = false;
				}
				else if (myUnit.IsWeapon && ((Weapon)myUnit).Flags.HomeOnJam)
				{
					result = false;
				}
				else
				{
					Side[] sides_ReadOnly = myUnit.ParentScen.Sides_ReadOnly;
					int num = 0;
					while (true)
					{
						if (num < sides_ReadOnly.Length)
						{
							Side side = sides_ReadOnly[num];
							if (side != null && myUnit.get_UnitSide(SetSideOnly: false) != null && side != myUnit.get_UnitSide(SetSideOnly: false) && !Module_Side.IsAlliedWithThisSide(myUnit.get_UnitSide(SetSideOnly: false), side))
							{
								for (int i = side.get_Item(Refresh: false).Count - 1; i >= 0; i += -1)
								{
									ActiveUnit activeUnit_ = side.get_Item(Refresh: false)[i];
									if (method_1(activeUnit_))
									{
										result = true;
										goto end_IL_00d7;
									}
								}
							}
							num = checked(num + 1);
							continue;
						}
						result = false;
						break;
						continue;
						end_IL_00d7:
						break;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100240", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				int num2;
				if (!Debugger.IsAttached)
				{
					num2 = 0;
				}
				else
				{
					Debugger.Break();
					num2 = 0;
				}
				result = (byte)num2 != 0;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public List<CommNetwork> Networks
	{
		get
		{
			if (myUnit.get_UnitSide(SetSideOnly: false).CommNetworks.Count > 0)
			{
				List<CommNetwork> list = new List<CommNetwork>();
				foreach (KeyValuePair<string, CommNetwork> commNetwork in myUnit.get_UnitSide(SetSideOnly: false).CommNetworks)
				{
					if (commNetwork.Value.Members.Contains(myUnit))
					{
						list.Add(commNetwork.Value);
					}
				}
				return list;
			}
			return null;
		}
	}

	public virtual void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
		try
		{
			if (_CommLinksEstablished.Count() > 0)
			{
				theWriter.WriteStartElement("CLE");
				CommLink[] array = _CommLinksEstablished.ToArray();
				for (int i = 0; i < array.Length; i = checked(i + 1))
				{
					array[i].ToXML(ref theWriter, ref ObjectsAlreadySerialized, myUnit.ParentScen);
				}
				theWriter.WriteEndElement();
			}
			if (_IsConnectedToSideNetwork == 0)
			{
				theWriter.WriteElementString("OOC", "True");
			}
			if (!_InternalCommsStatus)
			{
				theWriter.WriteElementString("ICS", "False");
			}
			if (_HasBeenSummonedToReestablishComms)
			{
				theWriter.WriteElementString("HBS", "True");
			}
			if (TimeOffComms > 0f)
			{
				theWriter.WriteElementString("TOC", XmlConvert.ToString(TimeOffComms));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100100", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static ActiveUnit_CommStuff FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		ActiveUnit_CommStuff result;
		try
		{
			ActiveUnit_CommStuff activeUnit_CommStuff = new ActiveUnit_CommStuff();
			activeUnit_CommStuff.myUnit = theAU;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "TOC":
					activeUnit_CommStuff.TimeOffComms = XmlConvert.ToSingle(val.InnerText);
					break;
				case "HBS":
					activeUnit_CommStuff._HasBeenSummonedToReestablishComms = Misc.ParseBool(val.InnerText);
					break;
				case "ICS":
					activeUnit_CommStuff._InternalCommsStatus = Misc.ParseBool(val.InnerText);
					break;
				case "OOC":
					if (Misc.ParseBool(val.InnerText))
					{
						activeUnit_CommStuff._IsConnectedToSideNetwork = 0;
					}
					else
					{
						activeUnit_CommStuff._IsConnectedToSideNetwork = 1;
					}
					break;
				case "CommLinksEstablished":
				case "CLE":
				{
					activeUnit_CommStuff._CommLinksEstablished = new CommLink[val.ChildNodes.Count - 1 + 1];
					int num = val.ChildNodes.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						XmlNode theNode2 = val.ChildNodes[i];
						CommLink commLink = CommLink.FromXML(ref theNode2, ref theDictionary, ref theAU);
						activeUnit_CommStuff._CommLinksEstablished[i] = commLink;
					}
					break;
				}
				}
			}
			result = activeUnit_CommStuff;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100101", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new ActiveUnit_CommStuff();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private ActiveUnit_CommStuff()
	{
		_CommLinksEstablished = new CommLink[0];
		_IsConnectedToSideNetwork = -1;
		_InternalCommsStatus = true;
		_HasBeenSummonedToReestablishComms = false;
		ContactsInfoGrade = new ConcurrentDictionary<string, TransmissionContactData>();
	}

	public ActiveUnit_CommStuff(ref ActiveUnit theUnit)
	{
		_CommLinksEstablished = new CommLink[0];
		_IsConnectedToSideNetwork = -1;
		_InternalCommsStatus = true;
		_HasBeenSummonedToReestablishComms = false;
		ContactsInfoGrade = new ConcurrentDictionary<string, TransmissionContactData>();
		myUnit = theUnit;
	}

	public void DropCommLink(CommLink theCL)
	{
		ArrayExtensions.Remove(ref _CommLinksEstablished, theCL);
	}

	public void CheckForCommsDisruption()
	{
		if (myUnit.IsSubmarine && myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < -40f && myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.RealisticSubComms))
		{
			return;
		}
		CommDevice[] comms_ReadOnly = myUnit.Comms_ReadOnly;
		if (comms_ReadOnly.Count() == 0 || comms_ReadOnly.Where([SpecialName] (CommDevice theCD) => !theCD.IsWeaponDataLink()).Count() == 0)
		{
			return;
		}
		bool flag = false;
		CommDevice[] array = comms_ReadOnly;
		foreach (CommDevice commDevice in array)
		{
			if (!commDevice.IsWeaponDataLink() && commDevice.Status == PlatformComponent._ComponentStatus.Operational)
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			if (_InternalCommsStatus)
			{
				this.set_IsConnectedToSideNetwork(ReasonForGoingOffGrid.AllCommDevicesDisabled, value: false);
			}
		}
		else if (_InternalCommsStatus)
		{
			this.set_IsConnectedToSideNetwork(ReasonForGoingOffGrid.None, value: true);
		}
	}

	public void CheckForCommsJamming()
	{
		CommDevice[] comms_ReadOnly = myUnit.Comms_ReadOnly;
		if (comms_ReadOnly.Count() == 0 || comms_ReadOnly.Where([SpecialName] (CommDevice theCD) => !theCD.IsWeaponDataLink()).Count() == 0)
		{
			return;
		}
		List<ActiveUnit> list = method_0();
		int num5;
		if (list.Count > 0)
		{
			HashSet<CommDevice> hashSet = new HashSet<CommDevice>();
			foreach (ActiveUnit item in list)
			{
				bool? flag = null;
				float? num = null;
				Sensor[] sensors_Cached = item.Sensors_Cached;
				foreach (Sensor sensor in sensors_Cached)
				{
					if (!sensor.IsActive() || !sensor.IsCommsJammer)
					{
						continue;
					}
					CommDevice[] array = comms_ReadOnly;
					foreach (CommDevice commDevice in array)
					{
						if (commDevice.Status != PlatformComponent._ComponentStatus.Operational || commDevice.Type == CommDevice.CommLinkType.Land_Line)
						{
							continue;
						}
						if (!num.HasValue)
						{
							num = Module_Unit.RangeToUnit_Slant(myUnit, item);
						}
						if (!CommsModel.CommsJammingEquation_Simple_SingleJammer(commDevice, sensor, num.Value))
						{
							if (!sensor.IsOTH && !flag.HasValue)
							{
								flag = Module_Unit.Has_Radar_LOS_ToUnit(myUnit, sensor, item, ref myUnit.ParentScen);
							}
							if (sensor.IsOTH || flag == true)
							{
								hashSet.Add(commDevice);
							}
						}
					}
				}
			}
			CommDevice[] array2 = comms_ReadOnly;
			foreach (CommDevice commDevice2 in array2)
			{
				if (commDevice2.Status == PlatformComponent._ComponentStatus.Operational && commDevice2.Type != CommDevice.CommLinkType.Land_Line)
				{
					if (hashSet.Contains(commDevice2))
					{
						commDevice2.IsJammed = true;
					}
					else
					{
						commDevice2.IsJammed = false;
					}
				}
			}
			num5 = 0;
		}
		else
		{
			CommDevice[] array3 = comms_ReadOnly;
			foreach (CommDevice commDevice3 in array3)
			{
				if (commDevice3.Status == PlatformComponent._ComponentStatus.Operational && commDevice3.Type != CommDevice.CommLinkType.Land_Line)
				{
					commDevice3.IsJammed = false;
				}
			}
			num5 = 0;
		}
		bool flag2 = (byte)num5 != 0;
		CommDevice[] array4 = comms_ReadOnly;
		foreach (CommDevice commDevice4 in array4)
		{
			if (!commDevice4.IsWeaponDataLink() && commDevice4.Status == PlatformComponent._ComponentStatus.Operational && !commDevice4.IsJammed)
			{
				flag2 = true;
				break;
			}
		}
		if (flag2)
		{
			if (!_InternalCommsStatus)
			{
				return;
			}
			if (!myUnit.IsSubmarine)
			{
				this.set_IsConnectedToSideNetwork(ReasonForGoingOffGrid.None, value: true);
				return;
			}
			ReasonForGoingOffGrid? reasonForGoingOffGrid = ((Submarine)myUnit).ReasonForGoingOffGridDueToDepth();
			if (!reasonForGoingOffGrid.HasValue || reasonForGoingOffGrid.Value == ReasonForGoingOffGrid.None)
			{
				this.set_IsConnectedToSideNetwork(ReasonForGoingOffGrid.None, value: true);
			}
		}
		else if (_InternalCommsStatus)
		{
			this.set_IsConnectedToSideNetwork(ReasonForGoingOffGrid.AllCommDevicesDisabled, value: false);
		}
	}

	[SpecialName]
	private List<ActiveUnit> method_0()
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		List<ActiveUnit> result;
		try
		{
			if (myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.CommsJamming))
			{
				if (myUnit.IsWeapon && ((Weapon)myUnit).Flags.HomeOnJam)
				{
					result = list;
				}
				else
				{
					Side[] sides_ReadOnly = myUnit.ParentScen.Sides_ReadOnly;
					foreach (Side side in sides_ReadOnly)
					{
						if (side == null || myUnit.get_UnitSide(SetSideOnly: false) == null || side == myUnit.get_UnitSide(SetSideOnly: false) || Module_Side.IsAlliedWithThisSide(myUnit.get_UnitSide(SetSideOnly: false), side))
						{
							continue;
						}
						for (int j = side.get_Item(Refresh: false).Count - 1; j >= 0; j += -1)
						{
							ActiveUnit activeUnit = side.get_Item(Refresh: false)[j];
							if (method_1(activeUnit))
							{
								list.Add(activeUnit);
							}
						}
					}
					result = list;
				}
			}
			else
			{
				result = list;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100240", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = list;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private bool method_1(ActiveUnit activeUnit_0)
	{
		bool result;
		if (activeUnit_0 == null)
		{
			result = false;
		}
		else
		{
			try
			{
				bool flag = false;
				Sensor[] sensors_Cached = activeUnit_0.Sensors_Cached;
				bool flag2 = false;
				if (sensors_Cached != null)
				{
					for (int i = sensors_Cached.Length - 1; i >= 0; i += -1)
					{
						Sensor sensor = sensors_Cached[i];
						if (!sensor.IsCommsJammer)
						{
							continue;
						}
						if (sensor.IsOTH)
						{
							flag2 = true;
						}
						if (!sensor.IsActive() || !sensor.TargetIsWithinCoverageArc(myUnit))
						{
							continue;
						}
						for (int j = myUnit.Comms_ReadOnly.Count() - 1; j >= 0; j += -1)
						{
							CommDevice targetCommDevice = myUnit.Comms_ReadOnly[j];
							if (sensor.get_CanJamThisCommDevice(targetCommDevice))
							{
								flag = true;
								break;
							}
						}
						if (flag)
						{
							break;
						}
					}
				}
				int num;
				if (!flag)
				{
					result = false;
				}
				else
				{
					if (flag2)
					{
						num = 1;
						goto IL_00fd;
					}
					if (Module_Unit.Has_Radar_LOS_ToUnit(myUnit, null, activeUnit_0, ref myUnit.ParentScen))
					{
						num = 1;
						goto IL_00fd;
					}
					result = false;
				}
				goto end_IL_000c;
				IL_00fd:
				result = (byte)num != 0;
				end_IL_000c:;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200352", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				int num2;
				if (!Debugger.IsAttached)
				{
					num2 = 0;
				}
				else
				{
					Debugger.Break();
					num2 = 0;
				}
				result = (byte)num2 != 0;
				ProjectData.ClearProjectError();
			}
		}
		return result;
	}

	public virtual void ClearAllCommLinks()
	{
		/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
	}

	private bool method_2(ActiveUnit activeUnit_0)
	{
		bool result;
		try
		{
			int num = CommLinksEstablished_ReadOnly.Length - 1;
			while (true)
			{
				if (num >= 0)
				{
					CommLink commLink = CommLinksEstablished_ReadOnly[num];
					if (Information.IsNothing((object)commLink) || commLink.CommPartner != activeUnit_0)
					{
						num += -1;
						continue;
					}
					result = true;
					break;
				}
				result = false;
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100104", "");
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
			result = (byte)num2 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private bool method_3(CommLink commLink_0)
	{
		bool result;
		try
		{
			int num;
			if ((double)myUnit.RangeToUnit_Horiz(commLink_0.CommPartner) > (double)commLink_0.DeviceUsed.Range)
			{
				num = 0;
				goto IL_004d;
			}
			if (!myUnit.ParentScen.ActiveUnits.ContainsKey(commLink_0.CommPartner.ObjectID))
			{
				num = 0;
				goto IL_004d;
			}
			result = true;
			goto end_IL_0001;
			IL_004d:
			result = (byte)num != 0;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100105", "");
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
			result = (byte)num2 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public virtual bool EstablishCommLinkToUnit(CommDevice theDevice, ActiveUnit theUnit, bool Is_CEC_Connection, bool MustCheckLOS = true)
	{
		if (theDevice == null)
		{
			theDevice = CommDeviceToConnectToThisUnit(myUnit, null, theUnit, IgnoreChannelCount: false, null, null, onlyOneRequired: false, MustCheckLOS).CommDevice;
		}
		bool result;
		if (theDevice == null)
		{
			result = false;
		}
		else
		{
			try
			{
				ArrayExtensions.Add(ref _CommLinksEstablished, new CommLink(ref theUnit, ref theDevice));
				ArrayExtensions.Add(ref theUnit.CommStuff._CommLinksEstablished, new CommLink(ref myUnit, ref theDevice));
				theDevice.OccupiedChannels++;
				CommDevice[] array = theUnit.Comms_ReadOnly;
				if (theUnit.get_ParentGroup(UsingMissionPlanner: false) != null && (theUnit.IsMobileGroundUnit || theUnit.IsFacility) && theUnit.SettledTime > 120f)
				{
					foreach (KeyValuePair<string, ActiveUnit> unit in theUnit.get_ParentGroup(UsingMissionPlanner: false).Units)
					{
						if (theUnit != unit.Value && (unit.Value.IsMobileGroundUnit || unit.Value.IsFacility) && Module_Unit.RangeToUnit_Slant(theUnit, unit.Value) < 5f && unit.Value.SettledTime > 120f)
						{
							array = array.Concat(unit.Value.Comms_ReadOnly).ToArray();
						}
					}
				}
				CommDevice[] array2 = array;
				int num = 0;
				while (true)
				{
					if (num < array2.Length)
					{
						CommDevice commDevice = array2[num];
						if ((Is_CEC_Connection && theDevice.ParentSpecific && myUnit.IsWeapon && theUnit != ((Weapon)myUnit).FiringParent && (!commDevice.IsDaisyChainCapable || !((Weapon)myUnit).CommStuff.CanSupportDaisyChainCommLink(theUnit, anyParent: false))) || commDevice.Type != theDevice.Type || (commDevice.MaxChannels != 0 && commDevice.MaxChannels <= commDevice.OccupiedChannels))
						{
							num = checked(num + 1);
							continue;
						}
						commDevice.OccupiedChannels++;
						result = true;
						break;
					}
					result = false;
					break;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100106", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				int num2;
				if (!Debugger.IsAttached)
				{
					num2 = 0;
				}
				else
				{
					Debugger.Break();
					num2 = 0;
				}
				result = (byte)num2 != 0;
				ProjectData.ClearProjectError();
			}
		}
		return result;
	}

	public static (CommDevice CommDevice, CommConnectionChecklistEvaluation EvaluationEnum) CommDeviceToConnectToThisUnit(ActiveUnit InitiatorUnit, CommDevice[] InitiatorComms, ActiveUnit TargetUnit, bool IgnoreChannelCount = false, CommDevice SpecificSenderDevice = null, CommDevice SpecificReceiverDevice = null, bool onlyOneRequired = false, bool MustCheckLOS = true)
	{
		PooledList<CommDevice> pooledList = null;
		PooledList<CommDevice> pooledList2 = null;
		CommDevice[] comms_ReadOnly = TargetUnit.Comms_ReadOnly;
		(CommDevice, CommConnectionChecklistEvaluation) result = default((CommDevice, CommConnectionChecklistEvaluation));
		try
		{
			if (TargetUnit != null && TargetUnit.IsOperating() && !TargetUnit.IsBeingDestroyed && comms_ReadOnly.Length != 0)
			{
				if (InitiatorComms == null && SpecificSenderDevice == null)
				{
					InitiatorComms = InitiatorUnit.Comms_ReadOnly;
				}
				if (SpecificSenderDevice != null)
				{
					InitiatorComms = new CommDevice[1] { SpecificSenderDevice };
				}
				double num = Module_Unit.RangeToUnit_Horiz_Angular(InitiatorUnit, TargetUnit, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
				if (double.IsNaN(num))
				{
					num = 0.0;
				}
				bool flag = InitiatorUnit.IsWeapon && TargetUnit.IsWeapon;
				pooledList2 = new PooledList<CommDevice>(comms_ReadOnly, Pools<CommDevice>.Local);
				if (!(GameGeneral.Beta_PlatformComms & InitiatorUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.PointToPointComm)) && TargetUnit.get_ParentGroup(UsingMissionPlanner: false) != null && (TargetUnit.IsMobileGroundUnit || TargetUnit.IsFacility) && TargetUnit.SettledTime > 120f)
				{
					foreach (KeyValuePair<string, ActiveUnit> unit in TargetUnit.get_ParentGroup(UsingMissionPlanner: false).Units)
					{
						if (TargetUnit != unit.Value && (unit.Value.IsMobileGroundUnit || unit.Value.IsFacility) && Module_Unit.RangeToUnit_Slant(TargetUnit, unit.Value, 0f, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue) < 5f && unit.Value.SettledTime > 120f)
						{
							CommDevice[] comms_ReadOnly2 = unit.Value.Comms_ReadOnly;
							pooledList2.AddRange(comms_ReadOnly2);
						}
					}
				}
				List<Sensor> list2 = default(List<Sensor>);
				if (TargetUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.PointToPointComm))
				{
					List<ActiveUnit> list = InitiatorUnit.CommStuff.method_0();
					if (list != null && list.Count > 0)
					{
						foreach (ActiveUnit item2 in list)
						{
							Sensor[] sensors_Cached = item2.Sensors_Cached;
							foreach (Sensor sensor in sensors_Cached)
							{
								if (sensor.IsCommsJammer && sensor.IsActive())
								{
									if (list2 == null)
									{
										list2 = new List<Sensor>();
									}
									list2.Add(sensor);
								}
							}
						}
					}
				}
				CommDevice[] array = InitiatorComms;
				int num2 = 0;
				while (true)
				{
					if (num2 < array.Length)
					{
						CommDevice commDevice = array[num2];
						bool flag2 = true;
						flag2 = (InitiatorUnit.IsPlatform ? (!TargetUnit.IsPlatform || (!commDevice.IsWeaponDataLink() && !commDevice.IsSonobuoyLink) || (commDevice.IsDaisyChainCapable ? true : false)) : (TargetUnit.IsPlatform || (commDevice.IsDaisyChainCapable ? true : false)));
						if (flag2 && commDevice.Status == PlatformComponent._ComponentStatus.Operational && commDevice.IsValidWeaponDataLinkParentSpecificCheck(InitiatorUnit, TargetUnit) && (IgnoreChannelCount || commDevice.MaxChannels <= 0 || commDevice.OccupiedChannels != commDevice.MaxChannels))
						{
							if (!TargetUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.PointToPointComm) && commDevice.IsJammed)
							{
								if (SpecificSenderDevice != null && Operators.CompareString(commDevice.ObjectID, SpecificSenderDevice.ObjectID, false) == 0)
								{
									break;
								}
							}
							else if (!commDevice.IsSatelliteLink() || TargetUnit.IsSatellite || InitiatorUnit.IsSatellite)
							{
								foreach (CommDevice item3 in pooledList2)
								{
									if (item3.Status != PlatformComponent._ComponentStatus.Operational || (SpecificReceiverDevice != null && Operators.CompareString(SpecificReceiverDevice.ObjectID, item3.ObjectID, false) != 0) || (flag && !item3.IsDaisyChainCapable))
									{
										continue;
									}
									if (TargetUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.CommsJamming) && item3.Type == commDevice.Type)
									{
										if (TargetUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.PointToPointComm))
										{
											if (!CommsModel.CommsJammingEquation_PointToPoint_MultiJammer(commDevice, item3, list2))
											{
												continue;
											}
										}
										else if (item3.IsJammed)
										{
											continue;
										}
									}
									if (item3.MaxChannels <= item3.OccupiedChannels && !IgnoreChannelCount && item3.MaxChannels != 0)
									{
										continue;
									}
									double num3 = Math2.Distance_To_AngularDegrees(commDevice.Range);
									if (!(num <= num3))
									{
										continue;
									}
									if (MustCheckLOS && commDevice.Flags.LOS_Limited && InitiatorUnit.IsTorpedo)
									{
										ref Scenario parentScen = ref InitiatorUnit.ParentScen;
										bool LandmassCheckIsNeeded = false;
										if (!Module_Unit.Has_Sonar_LOS_ToUnit(InitiatorUnit, TargetUnit, ref parentScen, ref LandmassCheckIsNeeded))
										{
											continue;
										}
									}
									if (item3.Type == commDevice.Type)
									{
										if (onlyOneRequired)
										{
											result = (commDevice, CommConnectionChecklistEvaluation.OK);
											return result;
										}
										if (pooledList == null)
										{
											pooledList = new PooledList<CommDevice>(Pools<CommDevice>.Local);
										}
										pooledList.Add(commDevice);
									}
								}
							}
						}
						num2 = checked(num2 + 1);
						continue;
					}
					if (pooledList != null)
					{
						int? num4 = pooledList?.Count;
						int? num5 = num4;
						if (((!num5.HasValue) ? ((bool?)null) : new bool?(num5.GetValueOrDefault() == 0)) != true)
						{
							num5 = num4;
							if (((!num5.HasValue) ? ((bool?)null) : new bool?(num5 == 1)) == true)
							{
								result = (pooledList[0], CommConnectionChecklistEvaluation.OK);
								return result;
							}
							double num6 = 20000.0;
							CommDevice item = null;
							foreach (CommDevice item4 in pooledList)
							{
								if ((double)item4.Range < num6)
								{
									num6 = item4.Range;
									item = item4;
								}
							}
							result = (item, CommConnectionChecklistEvaluation.OK);
							return result;
						}
						result = (null, CommConnectionChecklistEvaluation.OtherNegative);
						return result;
					}
					result = (null, CommConnectionChecklistEvaluation.OtherNegative);
					return result;
				}
				result = (null, CommConnectionChecklistEvaluation.CommJamming);
				return result;
			}
			result = (null, CommConnectionChecklistEvaluation.OtherNegative);
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100107", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		finally
		{
			pooledList?.Dispose();
			pooledList2?.Dispose();
		}
		return result;
	}

	internal static string GetCommConnectionChecklistEvaluationToHumanString(CommConnectionChecklistEvaluation theFeedback)
	{
		string text = default(string);
		return theFeedback switch
		{
			CommConnectionChecklistEvaluation.OK => "Succes", 
			CommConnectionChecklistEvaluation.UnavailableUnit => "Unavailable Unit", 
			CommConnectionChecklistEvaluation.CommJamming => "Comms jamming", 
			CommConnectionChecklistEvaluation.const_4 => "Missing LOS", 
			CommConnectionChecklistEvaluation.OtherNegative => "Not Suitable", 
			_ => text, 
		};
	}

	public CommDevice CommDevicePresentToConnectToThisUnit(CommDevice[] myComms, ActiveUnit theUnit)
	{
		List<CommDevice> list = new List<CommDevice>();
		CommDevice result;
		try
		{
			if (!theUnit.IsOperating())
			{
				result = null;
			}
			else if (!theUnit.IsBeingDestroyed)
			{
				if (myComms == null)
				{
					myComms = myUnit.Comms_ReadOnly;
				}
				if (myUnit.IsWeapon && theUnit.IsWeapon)
				{
					result = null;
				}
				else
				{
					CommDevice[] array = myComms;
					foreach (CommDevice commDevice in array)
					{
						if (commDevice.Status != PlatformComponent._ComponentStatus.Operational || (!theUnit.IsWeapon && !myUnit.IsWeapon && commDevice.IsWeaponDataLink()) || (!theUnit.IsSatellite && !myUnit.IsSatellite && commDevice.IsSatelliteLink()))
						{
							continue;
						}
						CommDevice[] comms_ReadOnly = theUnit.Comms_ReadOnly;
						foreach (CommDevice commDevice2 in comms_ReadOnly)
						{
							if (commDevice2.Type == commDevice.Type && commDevice2.Status == PlatformComponent._ComponentStatus.Operational)
							{
								list.Add(commDevice);
							}
						}
					}
					switch (list.Count)
					{
					case 0:
						result = null;
						break;
					default:
					{
						double num = 20000.0;
						CommDevice commDevice3 = null;
						foreach (CommDevice item in list)
						{
							if ((double)item.Range < num)
							{
								num = item.Range;
								commDevice3 = item;
							}
						}
						result = commDevice3;
						break;
					}
					case 1:
						result = list[0];
						break;
					}
				}
			}
			else
			{
				result = null;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100107", "");
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

	protected bool CommChannelsAvailable()
	{
		bool result;
		try
		{
			CommDevice[] comms_ReadOnly = myUnit.Comms_ReadOnly;
			int num = 0;
			while (true)
			{
				if (num < comms_ReadOnly.Length)
				{
					CommDevice commDevice = comms_ReadOnly[num];
					if (commDevice.OccupiedChannels >= commDevice.MaxChannels)
					{
						num = checked(num + 1);
						continue;
					}
					result = true;
					break;
				}
				result = false;
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100108", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num2;
			if (!Debugger.IsAttached)
			{
				num2 = 0;
			}
			else
			{
				Debugger.Break();
				num2 = 0;
			}
			result = (byte)num2 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	protected void DisconnectCommLinkToUnit(ActiveUnit theUnit, bool DisconnectPartner)
	{
		try
		{
			for (int i = CommLinksEstablished_ReadOnly.Length - 1; i >= 0; i += -1)
			{
				CommLink commLink = CommLinksEstablished_ReadOnly[i];
				if (!Information.IsNothing((object)commLink) && commLink.CommPartner == theUnit)
				{
					if (DisconnectPartner)
					{
						commLink.CommPartner.CommStuff.DisconnectCommLinkToUnit(myUnit, DisconnectPartner: false);
					}
					if (commLink.DeviceUsed != null && commLink.DeviceUsed.OccupiedChannels > 0)
					{
						commLink.DeviceUsed.OccupiedChannels--;
					}
					DropCommLink(commLink);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100109", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void PushContactsToSide()
	{
		try
		{
			if (!CanTransmitOrReceiveContactsData())
			{
				return;
			}
			TObservableDictionary<string, Contact> contacts_Local = myUnit.Sensory.Contacts_Local;
			if (contacts_Local == null || contacts_Local.Count == 0)
			{
				return;
			}
			ConcurrentObservableDictionary<string, ActiveUnit> activeUnits = myUnit.ParentScen.ActiveUnits;
			Dictionary<string, Sensor> dictionary = myUnit.Sensors_Cached.Where([SpecialName] (Sensor s) => s != null).ToDictionary([SpecialName] (Sensor s) => s.ObjectID);
			foreach (Contact value4 in contacts_Local.Values)
			{
				if (value4 == null || value4.IsAutoDetection)
				{
					continue;
				}
				Queue<Contact.Detection_Struct> lastDetections = value4.LastDetections;
				Contact.Detection_Struct detection_Struct = lastDetections.ElementAtOrDefault(lastDetections.Count - 1);
				if (Operators.CompareString(detection_Struct.DetectorUnitID, myUnit.ObjectID, false) != 0)
				{
					TransmissionContactData value = default(TransmissionContactData);
					if (ContactsInfoGrade.TryGetValue(value4.ObjectID, out value))
					{
						if (value.IsFrozen)
						{
							continue;
						}
						string transmittedBy = value.TransmittedBy;
						bool flag = false;
						foreach (KeyValuePair<string, CommNetwork> commNetwork in myUnit.get_UnitSide(SetSideOnly: false).CommNetworks)
						{
							CommNetwork value2 = commNetwork.Value;
							if (value2 == null || !value2.Members.Contains(myUnit))
							{
								continue;
							}
							bool flag2 = false;
							foreach (Module_Unit.Unit member in value2.Members)
							{
								if (member != null && Operators.CompareString(member.ObjectID, transmittedBy, false) == 0)
								{
									flag2 = true;
									break;
								}
							}
							if (!flag2)
							{
								foreach (Module_Unit.Unit member2 in value2.Members)
								{
									if (member2 != null && Operators.CompareString(member2.ObjectID, myUnit.ObjectID, false) != 0 && Operators.CompareString(member2.ObjectID, value4.OriginalDetectorUnitID, false) != 0)
									{
										flag = true;
										break;
									}
								}
							}
							if (flag)
							{
								break;
							}
						}
						if (!flag)
						{
							continue;
						}
						double num = Math.Max(2.0, CommDevice.GetLatencyInSeconds((int)value.Latency));
						if ((myUnit.ParentScen.Time - value.LastRelayedAt).TotalSeconds < num)
						{
							continue;
						}
						value.LastRelayedAt = myUnit.ParentScen.Time;
						ContactsInfoGrade[value4.ObjectID] = value;
					}
				}
				Sensor value3 = detection_Struct.DetectingSensor;
				if (value3 == null)
				{
					string detectorUnitID = detection_Struct.DetectorUnitID;
					string detectingSensorID = detection_Struct.DetectingSensorID;
					if (detectorUnitID == null || detectingSensorID == null)
					{
						continue;
					}
					if (!dictionary.TryGetValue(detectingSensorID, out value3) && activeUnits.ContainsKey(detectorUnitID))
					{
						ActiveUnit activeUnit = activeUnits[detectorUnitID];
						if (activeUnit != null)
						{
							Sensor[] sensors_Cached = activeUnit.Sensors_Cached;
							int num2 = sensors_Cached.Count() - 1;
							for (int num3 = 0; num3 <= num2; num3++)
							{
								if (Operators.CompareString(sensors_Cached[num3].ObjectID, detectingSensorID, false) == 0)
								{
									value3 = sensors_Cached[num3];
									break;
								}
							}
						}
					}
				}
				if (!value4.IsAutoDetection)
				{
					TransmittedContactData contactInfo = new TransmittedContactData(value3, value4, myUnit);
					myUnit.get_UnitSide(SetSideOnly: false).ReceiveContactDataFromUnit(contactInfo);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 9653231111215", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool CanTransmitOrReceiveContactsData()
	{
		if (_InternalCommsStatus)
		{
			CommDevice[] comms_ReadOnly = myUnit.Comms_ReadOnly;
			int result;
			if (comms_ReadOnly == null)
			{
				result = 0;
			}
			else
			{
				if (comms_ReadOnly.Length != 0)
				{
					CommDevice[] array = comms_ReadOnly;
					foreach (CommDevice commDevice in array)
					{
						if (commDevice != null && commDevice.Status == PlatformComponent._ComponentStatus.Operational)
						{
							return true;
						}
					}
					return false;
				}
				result = 0;
			}
			return (byte)result != 0;
		}
		return false;
	}

	public void ReceiveAndProcessTransmissions(float elapsedTime)
	{
		TObservableDictionary<string, Contact> contacts_Local = myUnit.Sensory.Contacts_Local;
		try
		{
			if (!CanTransmitOrReceiveContactsData())
			{
				{
					foreach (KeyValuePair<string, TransmissionContactData> item in ContactsInfoGrade)
					{
						if (!string.IsNullOrEmpty(item.Value.TransmittedBy))
						{
							TransmissionContactData value = item.Value;
							value.IsFrozen = true;
							ContactsInfoGrade[item.Key] = value;
						}
					}
					return;
				}
			}
			ConcurrentDictionary<string, float> concurrentDictionary = new ConcurrentDictionary<string, float>();
			HashSet<string> hashSet = new HashSet<string>();
			foreach (KeyValuePair<string, CommNetwork> commNetwork in myUnit.get_UnitSide(SetSideOnly: false).CommNetworks)
			{
				if (commNetwork.Value != null && commNetwork.Value.Members.Contains(myUnit))
				{
					hashSet.Add(commNetwork.Key);
				}
			}
			ConcurrentDictionary<string, bool> concurrentDictionary2 = new ConcurrentDictionary<string, bool>();
			ConcurrentDictionary<string, bool> concurrentDictionary3 = new ConcurrentDictionary<string, bool>();
			IEnumerable<Struct12> enumerable = from x in myUnit.get_UnitSide(SetSideOnly: false).TransmissionQueue.SelectMany([SpecialName] (KeyValuePair<string, List<Transmission>> kvpOuter) =>
				{
					_Closure$__47-0 arg = default(_Closure$__47-0);
					_Closure$__47-0 CS$<>8__locals3 = new _Closure$__47-0(arg);
					CS$<>8__locals3.$VB$Local_kvpOuter = kvpOuter;
					return CS$<>8__locals3.$VB$Local_kvpOuter.Value.Select([SpecialName] (Transmission transmission) => new Struct12
					{
						string_0 = CS$<>8__locals3.$VB$Local_kvpOuter.Key,
						transmission_0 = transmission,
						activeUnit_0 = ((transmission.SenderUnitList == null || transmission.SenderUnitList.Count <= 0) ? null : transmission.SenderUnitList.First())
					});
				}).Where([SpecialName] (Struct12 item) =>
				{
					if (Operators.CompareString(item.transmission_0.OriginalDetector.ObjectID, myUnit.ObjectID, false) == 0)
					{
						return false;
					}
					if (item.activeUnit_0 == null)
					{
						return false;
					}
					return (Operators.CompareString(item.activeUnit_0.ObjectID, myUnit.ObjectID, false) != 0) ? true : false;
				})
				orderby x.transmission_0.TheCommDevice.QualityGrade descending
				select x;
			_Closure$__47-1 closure$__47- = default(_Closure$__47-1);
			_Closure$__47-2 closure$__47-2 = default(_Closure$__47-2);
			foreach (Struct12 item2 in enumerable)
			{
				closure$__47- = new _Closure$__47-1(closure$__47-);
				closure$__47-.$VB$Local_commDeviceObjectID = item2.string_0;
				Transmission transmission_ = item2.transmission_0;
				closure$__47-.$VB$Local_senderUnit = item2.activeUnit_0;
				bool value2 = false;
				if (!concurrentDictionary3.TryGetValue(closure$__47-.$VB$Local_senderUnit.ObjectID, out value2))
				{
					if (NetworkedWith(closure$__47-.$VB$Local_senderUnit) == null)
					{
						concurrentDictionary3.TryAdd(closure$__47-.$VB$Local_senderUnit.ObjectID, value: false);
					}
					else
					{
						value2 = true;
						concurrentDictionary3.TryAdd(closure$__47-.$VB$Local_senderUnit.ObjectID, value: true);
					}
				}
				else
				{
					value2 = value2;
				}
				if (!value2)
				{
					continue;
				}
				bool value3 = false;
				closure$__47-.$VB$Local_theCommDeviceUsed = null;
				string key = closure$__47-.$VB$Local_commDeviceObjectID + ":" + closure$__47-.$VB$Local_senderUnit.ObjectID;
				if (!concurrentDictionary2.TryGetValue(key, out value3))
				{
					closure$__47-.$VB$Local_theCommDeviceUsed = CommDeviceToConnectToThisUnit(closure$__47-.$VB$Local_senderUnit, closure$__47-.$VB$Local_senderUnit.Comms_ReadOnly, myUnit, IgnoreChannelCount: false, transmission_.TheCommDevice, null, onlyOneRequired: true).CommDevice;
					if (closure$__47-.$VB$Local_theCommDeviceUsed != null)
					{
						value3 = true;
						concurrentDictionary2.TryAdd(key, value: true);
					}
					else
					{
						value3 = false;
					}
				}
				else
				{
					value3 = true;
					closure$__47-.$VB$Local_theCommDeviceUsed = closure$__47-.$VB$Local_senderUnit.Comms_ReadOnly.Where(closure$__47-._Lambda$__4).FirstOrDefault();
					if (closure$__47-.$VB$Local_theCommDeviceUsed == null)
					{
						value3 = false;
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
					}
				}
				if (transmission_.ContactsData == null)
				{
					continue;
				}
				using List<TransmittedContactData>.Enumerator enumerator4 = transmission_.ContactsData.GetEnumerator();
				while (enumerator4.MoveNext())
				{
					closure$__47-2 = new _Closure$__47-2(closure$__47-2);
					closure$__47-2.$VB$NonLocal_$VB$Closure_2 = closure$__47-;
					closure$__47-2.$VB$Local_thedet = enumerator4.Current;
					if (closure$__47-2.$VB$Local_thedet.TheContact == null || Operators.CompareString(closure$__47-2.$VB$Local_thedet.TheContact.OriginalDetectorUnitID, myUnit.ObjectID, false) == 0)
					{
						continue;
					}
					if (!value3)
					{
						TransmissionWithFeedback value4 = new TransmissionWithFeedback(closure$__47-2.$VB$Local_thedet.TheContact, transmission_.SenderUnitList, transmission_, myUnit, TransmissionFeedbacResult.Invalid);
						myUnit.Sensory.AddTransmissionToMergeBuffer(value4);
						continue;
					}
					TransmissionContactData value5 = default(TransmissionContactData);
					ContactsInfoGrade.TryGetValue(closure$__47-2.$VB$Local_thedet.TheContact.ObjectID, out value5);
					if (!((myUnit.ParentScen.Time - value5.LastUpdate).TotalSeconds <= CommDevice.GetLatencyInSeconds((int)closure$__47-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theCommDeviceUsed.LatencyGrade)) || value5.Bandwith <= closure$__47-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theCommDeviceUsed.QualityGrade)
					{
						if (value5.Bandwith > CommDevice.EnumCommQuality.None)
						{
							concurrentDictionary[closure$__47-2.$VB$Local_thedet.TheContact.ObjectID] = (float)closure$__47-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theCommDeviceUsed.QualityGrade;
						}
						else
						{
							concurrentDictionary.TryAdd(closure$__47-2.$VB$Local_thedet.TheContact.ObjectID, (float)closure$__47-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theCommDeviceUsed.QualityGrade);
						}
						closure$__47-2.$VB$Local_thedet.TheContact.Age = 0f;
						ContactsInfoGrade.AddOrUpdate(closure$__47-2.$VB$Local_thedet.TheContact.ObjectID, new TransmissionContactData
						{
							ObjectID = closure$__47-2.$VB$Local_thedet.TheContact.ObjectID,
							Bandwith = (CommDevice.EnumCommQuality)closure$__47-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theCommDeviceUsed.QualityGradeinfo.ID,
							Latency = (CommDevice.EnumCommLatency)closure$__47-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theCommDeviceUsed.LatencyGradenfo.ID,
							TransmittedBy = closure$__47-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_senderUnit.ObjectID,
							LastUpdate = closure$__47-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_senderUnit.ParentScen.Time,
							Latitude = ((Module_Unit.Unit)closure$__47-2.$VB$Local_thedet.TheContact).get_Latitude((GlobalVariables.BooleanObject)null),
							Longitude = ((Module_Unit.Unit)closure$__47-2.$VB$Local_thedet.TheContact).get_Longitude((GlobalVariables.BooleanObject)null),
							Altitude = ((Module_Unit.Unit)closure$__47-2.$VB$Local_thedet.TheContact).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null),
							Heading = closure$__47-2.$VB$Local_thedet.TheContact.CurrentHeading,
							Speed = closure$__47-2.$VB$Local_thedet.TheContact.CurrentSpeed
						}, closure$__47-2._Lambda$__5);
						TransmissionContactData value6 = default(TransmissionContactData);
						if (ContactsInfoGrade.TryGetValue(closure$__47-2.$VB$Local_thedet.TheContact.ObjectID, out value6) && value6.IsFrozen)
						{
							value6.IsFrozen = false;
							ContactsInfoGrade[closure$__47-2.$VB$Local_thedet.TheContact.ObjectID] = value6;
						}
						TransmissionWithFeedback value7 = new TransmissionWithFeedback(closure$__47-2.$VB$Local_thedet.TheContact, transmission_.SenderUnitList, transmission_, myUnit, TransmissionFeedbacResult.None);
						myUnit.Sensory.AddTransmissionToMergeBuffer(value7);
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 9653231111215_1", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		myUnit.Sensory.ProcessQueuedTransmission(elapsedTime);
		try
		{
			if (contacts_Local == null)
			{
				return;
			}
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, Contact> item3 in contacts_Local)
			{
				Contact value8 = item3.Value;
				if (value8 == null)
				{
					continue;
				}
				TransmissionContactData value9 = default(TransmissionContactData);
				if (ContactsInfoGrade.TryGetValue(value8.ObjectID, out value9) && value9.IsFrozen)
				{
					continue;
				}
				string text = string.Empty;
				if (value8.LastDetections != null && value8.LastDetections.Count > 0)
				{
					text = value8.LastDetections.Last().DetectorUnitID;
				}
				if (Operators.CompareString(text, myUnit.ObjectID, false) == 0)
				{
					continue;
				}
				TransmissionContactData value10 = default(TransmissionContactData);
				if (ContactsInfoGrade.TryGetValue(value8.ObjectID, out value10) && !string.IsNullOrEmpty(value10.TransmittedBy))
				{
					double num = Math.Max(2.0, CommDevice.GetLatencyInSeconds((int)value10.Latency));
					if ((myUnit.ParentScen.Time - value10.LastUpdate).TotalSeconds > num)
					{
						list.Add(item3.Key);
					}
				}
				else
				{
					list.Add(item3.Key);
				}
			}
			foreach (string item4 in list)
			{
				Contact value11 = null;
				if (myUnit.Sensory.Contacts_Local.TryGetValue(item4, out value11) && value11 != null)
				{
					TransmissionContactData value12 = default(TransmissionContactData);
					ContactsInfoGrade.TryGetValue(value11.ObjectID, out value12);
					if (string.IsNullOrEmpty(value12.TransmittedBy))
					{
						value12.ObjectID = value11.ObjectID;
						value12.TransmittedBy = "frozen_no_grade";
						value12.LastUpdate = myUnit.ParentScen.Time;
						value12.Latitude = ((Module_Unit.Unit)value11).get_Latitude((GlobalVariables.BooleanObject)null);
						value12.Longitude = ((Module_Unit.Unit)value11).get_Longitude((GlobalVariables.BooleanObject)null);
						value12.Altitude = ((Module_Unit.Unit)value11).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
						value12.Heading = value11.CurrentHeading;
						value12.Speed = value11.CurrentSpeed;
						value12.Bandwith = CommDevice.EnumCommQuality.None;
						value12.Latency = CommDevice.EnumCommLatency.None;
					}
					value12.IsFrozen = true;
					ContactsInfoGrade[value11.ObjectID] = value12;
				}
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 321654165165416511000", ex4.Message);
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public TransmissionContactData GetContactGradeInfo(string contactID)
	{
		ContactsInfoGrade.TryGetValue(contactID, out var value);
		return value;
	}

	public void PushTransmissionFeedbackToSide(TransmissionWithFeedback theTF)
	{
		myUnit.get_UnitSide(SetSideOnly: false).FeedbackList.Add(theTF);
		myUnit.get_UnitSide(SetSideOnly: false).MinuteFeedbackList.Add(theTF);
	}

	internal void UpdateNetworkLasttransmission(Transmission theTransmission)
	{
		if (myUnit.get_UnitSide(SetSideOnly: false).CommNetworks.Count <= 0)
		{
			return;
		}
		using IEnumerator<KeyValuePair<string, CommNetwork>> enumerator = myUnit.get_UnitSide(SetSideOnly: false).CommNetworks.GetEnumerator();
		KeyValuePair<string, CommNetwork> current;
		do
		{
			if (enumerator.MoveNext())
			{
				current = enumerator.Current;
				continue;
			}
			return;
		}
		while (!current.Value.Members.Contains(myUnit));
		current.Value.LastTransmission = theTransmission;
	}

	public bool CheckIfUnitIsInContactWithHQ(Side theSide, Module_Unit.Unit theUnit)
	{
		if (theUnit.IsActiveUnit)
		{
			if (theSide.HQ_ID != null && Operators.CompareString(theSide.HQ_ID, "", false) != 0)
			{
				if (theSide.HasCommPath(theSide.HQ_ID, theUnit.ObjectID))
				{
					if (!CanCommTravelBetweenPath(theSide.HQ_ID, (ActiveUnit)theUnit))
					{
						return false;
					}
					return true;
				}
				return false;
			}
			return false;
		}
		bool result = default(bool);
		return result;
	}

	public bool CanCommTravelBetweenPath(string hQ_ID, ActiveUnit TheUnit)
	{
		ActiveUnit activeUnit = TheUnit.get_UnitSide(SetSideOnly: false).Units.Where([SpecialName] (ActiveUnit theU) => Operators.CompareString(theU.ObjectID, hQ_ID, false) == 0).FirstOrDefault();
		if (activeUnit == null)
		{
			return false;
		}
		bool value = false;
		if (!TheUnit.get_UnitSide(SetSideOnly: false).IsUnitInContactWithTheLeaderInthisPulse.TryGetValue(TheUnit.ObjectID, out value))
		{
			if (CommDeviceToConnectToThisUnit(TheUnit, TheUnit.Comms_ReadOnly, activeUnit, IgnoreChannelCount: false, null, null, onlyOneRequired: true).CommDevice == null)
			{
				value = false;
				TheUnit.get_UnitSide(SetSideOnly: false).IsUnitInContactWithTheLeaderInthisPulse.TryAdd(TheUnit.ObjectID, value: false);
				return false;
			}
			value = true;
			TheUnit.get_UnitSide(SetSideOnly: false).IsUnitInContactWithTheLeaderInthisPulse.TryAdd(TheUnit.ObjectID, value: true);
			return true;
		}
		if (value)
		{
			return true;
		}
		bool result = default(bool);
		return result;
	}

	internal CommDevice GetLongestRangeCommDevice()
	{
		if (myUnit.Comms_ReadOnly != null && myUnit.Comms_ReadOnly.Length > 0)
		{
			CommDevice[] comms_ReadOnly = myUnit.Comms_ReadOnly;
			CommDevice commDevice2 = default(CommDevice);
			foreach (CommDevice commDevice in comms_ReadOnly)
			{
				if (commDevice2 == null)
				{
					commDevice2 = commDevice;
				}
				else if (commDevice.Range > commDevice2.Range)
				{
					commDevice2 = commDevice;
				}
			}
			return commDevice2;
		}
		CommDevice result = default(CommDevice);
		return result;
	}

	public CommNetwork NetworkedWith(ActiveUnit theOtherUnit)
	{
		try
		{
			if (theOtherUnit.IsSatellite)
			{
				return new CommNetwork();
			}
			if (myUnit.get_UnitSide(SetSideOnly: false).CommNetworks.Count > 0)
			{
				foreach (CommNetwork network in Networks)
				{
					if (network.Members.Contains(myUnit) && network.Members.Contains(theOtherUnit))
					{
						return network;
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 75272572687171", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return null;
	}

	static ActiveUnit_CommStuff()
	{
		Class72.smethod_20();
	}
}
