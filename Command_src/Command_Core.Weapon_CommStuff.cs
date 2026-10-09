using System;
using System.Buffers;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using Collections.Pooled;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Weapon_CommStuff : ActiveUnit_CommStuff
{
	[CompilerGenerated]
	internal sealed class _Closure$__13-0
	{
		public double $VB$Local_MyLat;

		public double $VB$Local_myLon;

		public _Closure$__13-0(_Closure$__13-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_MyLat = arg0.$VB$Local_MyLat;
				$VB$Local_myLon = arg0.$VB$Local_myLon;
			}
		}

		[SpecialName]
		internal int _Lambda$__3(ActiveUnit u1, ActiveUnit u2)
		{
			if (u1 == null)
			{
				return 1;
			}
			if (u2 != null)
			{
				double num = Geodesic_Haversine.Distance_Horiz_Angular_Approx_Rad($VB$Local_MyLat, $VB$Local_myLon, u1.get_Latitude((GlobalVariables.BooleanObject)null), u1.get_Longitude((GlobalVariables.BooleanObject)null));
				double value = Geodesic_Haversine.Distance_Horiz_Angular_Approx_Rad($VB$Local_MyLat, $VB$Local_myLon, u2.get_Latitude((GlobalVariables.BooleanObject)null), u2.get_Longitude((GlobalVariables.BooleanObject)null));
				return num.CompareTo(value);
			}
			return -1;
		}

		static _Closure$__13-0()
		{
			Class72.smethod_20();
		}
	}

	private Weapon weapon_0;

	public bool CanSendDataToParent
	{
		get
		{
			if (method_4().DataLinkParent == null)
			{
				return false;
			}
			if (CommLinkToParent != null)
			{
				return !CommLinkToParent.DeviceUsed.IsReceiveOnly();
			}
			return false;
		}
	}

	public CommLink CommLinkToParent
	{
		get
		{
			CommLink[] commLinksEstablished_ReadOnly = base.CommLinksEstablished_ReadOnly;
			foreach (CommLink commLink in commLinksEstablished_ReadOnly)
			{
				if (commLink.CommPartner == method_4().DataLinkParent)
				{
					return commLink;
				}
			}
			return null;
		}
	}

	[SpecialName]
	private Weapon method_4()
	{
		if (Information.IsNothing((object)weapon_0))
		{
			weapon_0 = (Weapon)myUnit;
		}
		return weapon_0;
	}

	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
		checked
		{
			try
			{
				theWriter.WriteStartElement("Weapon_CommStuff");
				CommDevice[] comms_ReadOnly = myUnit.Comms_ReadOnly;
				for (int i = 0; i < comms_ReadOnly.Length; i++)
				{
					comms_ReadOnly[i].ParentPlatform = myUnit;
				}
				theWriter.WriteStartElement("CLE");
				CommLink[] commLinksEstablished_ReadOnly = base.CommLinksEstablished_ReadOnly;
				for (int j = 0; j < commLinksEstablished_ReadOnly.Length; j++)
				{
					commLinksEstablished_ReadOnly[j].ToXML(ref theWriter, ref ObjectsAlreadySerialized, myUnit.ParentScen);
				}
				theWriter.WriteEndElement();
				theWriter.WriteEndElement();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100973", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public new static Weapon_CommStuff FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		Weapon_CommStuff result;
		try
		{
			Weapon_CommStuff weapon_CommStuff = new Weapon_CommStuff(ref theAU);
			weapon_CommStuff.myUnit = theAU;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				string name = val.Name;
				if (Operators.CompareString(name, "CommLinksEstablished", false) == 0 || Operators.CompareString(name, "CLE", false) == 0)
				{
					weapon_CommStuff._CommLinksEstablished = new CommLink[val.ChildNodes.Count - 1 + 1];
					int num = val.ChildNodes.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						XmlNode theNode2 = val.ChildNodes[i];
						CommLink commLink = CommLink.FromXML(ref theNode2, ref theDictionary, ref theAU);
						weapon_CommStuff._CommLinksEstablished[i] = commLink;
					}
				}
			}
			result = weapon_CommStuff;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100974", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Weapon_CommStuff(ref theAU);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public Weapon_CommStuff(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
	}

	public override void ClearAllCommLinks()
	{
		if (CommsCheckCountdown > 0f)
		{
			return;
		}
		try
		{
			CommLink[] commLinksEstablished = _CommLinksEstablished;
			List<CommLink> list = default(List<CommLink>);
			foreach (CommLink commLink in commLinksEstablished)
			{
				ActiveUnit commPartner = commLink.CommPartner;
				if (!commLink.DeviceUsed.IsWireLink() || commPartner.IsBeingDestroyed)
				{
					if (list == null)
					{
						list = new List<CommLink>();
					}
					list.Add(commLink);
				}
			}
			if (list == null)
			{
				return;
			}
			foreach (CommLink item in list)
			{
				DropCommLink(item);
				item.DeviceUsed.OccupiedChannels--;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 10", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override bool EstablishCommLinkToUnit(CommDevice theCommDevice, ActiveUnit theUnit, bool Is_CEC_Connection, bool MustCheckLOS = true)
	{
		bool num = base.EstablishCommLinkToUnit(theCommDevice, theUnit, Is_CEC_Connection, MustCheckLOS);
		if (num)
		{
			method_4().DataLinkParent = theUnit;
		}
		return num;
	}

	internal bool CanSupportDaisyChainCommLink(ActiveUnit otherAU, bool anyParent)
	{
		if (otherAU.IsWeapon && otherAU.DBID == method_4().DBID)
		{
			Weapon weapon = (Weapon)otherAU;
			if (weapon.DataLinkParent != null)
			{
				ActiveUnit dataLinkParent = weapon.DataLinkParent;
				while (dataLinkParent != null && dataLinkParent.IsWeapon)
				{
					dataLinkParent = ((Weapon)dataLinkParent).DataLinkParent;
				}
				if (dataLinkParent != null)
				{
					return anyParent || dataLinkParent == method_4().FiringParent;
				}
			}
		}
		return false;
	}

	public void CheckCommsAndDataLinks(float elapsedTime, List<ActiveUnit> FriendlyOperatingUnits)
	{
		try
		{
			Weapon weapon = method_4();
			ActiveUnit activeUnit = weapon.DataLinkParent;
			if (activeUnit == null)
			{
				base.ClearAllCommLinks();
			}
			else
			{
				bool flag = false;
				if (activeUnit.IsMorituri)
				{
					flag = true;
				}
				else if (activeUnit.IsOperating())
				{
					if (activeUnit.IsWeapon && ((Weapon)activeUnit).DataLinkParent == null)
					{
						flag = true;
					}
				}
				else
				{
					flag = true;
				}
				if (flag)
				{
					DisconnectCommLinkToUnit(activeUnit, DisconnectPartner: true);
					weapon.DataLinkParent = null;
					activeUnit = null;
				}
			}
			CommsCheckCountdown -= elapsedTime;
			if (!weapon.IsAAWCapable & (weapon.MaxRange_NoTargetType > 20f))
			{
				if (CommsCheckCountdown > 0f)
				{
					return;
				}
				CommsCheckCountdown = GameGeneral.GlobalRNG.Next(1, 16);
			}
			if (CommsCheckCountdown < 0f)
			{
				CommsCheckCountdown = 0f;
			}
			CommDevice[] comms_ReadOnly = myUnit.Comms_ReadOnly;
			if (comms_ReadOnly.Length == 0 || !CommChannelsAvailable())
			{
				return;
			}
			if (activeUnit != null)
			{
				bool flag2 = CommLinkToParent != null;
				CommDevice item = ActiveUnit_CommStuff.CommDeviceToConnectToThisUnit(myUnit, comms_ReadOnly, activeUnit, IgnoreChannelCount: true).CommDevice;
				if (item == null)
				{
					DisconnectCommLinkToUnit(activeUnit, DisconnectPartner: true);
					weapon.DataLinkParent = null;
					activeUnit = null;
				}
				else if (!flag2)
				{
					EstablishCommLinkToUnit(item, activeUnit, method_4().FiringParent != activeUnit);
				}
			}
			else if (weapon.FiringParent != null)
			{
				CommDevice item2 = ActiveUnit_CommStuff.CommDeviceToConnectToThisUnit(myUnit, comms_ReadOnly, weapon.FiringParent).CommDevice;
				if (item2 != null)
				{
					EstablishCommLinkToUnit(item2, weapon.FiringParent, method_4().FiringParent != activeUnit);
				}
			}
			if (activeUnit != null)
			{
				return;
			}
			bool flag3 = comms_ReadOnly.Where([SpecialName] (CommDevice theCD) => theCD.IsDaisyChainCapable).Any();
			bool flag4 = comms_ReadOnly.Where([SpecialName] (CommDevice theCD) => !theCD.ParentSpecific).Any();
			if (!flag3 && !flag4)
			{
				return;
			}
			_Closure$__13-0 arg = default(_Closure$__13-0);
			_Closure$__13-0 CS$<>8__locals8 = new _Closure$__13-0(arg);
			double num = comms_ReadOnly.Select([SpecialName] (CommDevice theCD) => theCD.Range).Max();
			Math2.Distance_To_AngularDegrees(num);
			CS$<>8__locals8.$VB$Local_MyLat = weapon.get_Latitude((GlobalVariables.BooleanObject)null);
			CS$<>8__locals8.$VB$Local_myLon = weapon.get_Longitude((GlobalVariables.BooleanObject)null);
			if (FriendlyOperatingUnits == null)
			{
				FriendlyOperatingUnits = myUnit.get_UnitSide(SetSideOnly: false).get_FriendlyUnits_OperativeOnly(myUnit.ParentScen, IncludeWeapons: false);
			}
			PooledList<ActiveUnit> pooledList = new PooledList<ActiveUnit>(FriendlyOperatingUnits.Count);
			foreach (ActiveUnit FriendlyOperatingUnit in FriendlyOperatingUnits)
			{
				if (FriendlyOperatingUnit != myUnit)
				{
					if (flag3 && CanSupportDaisyChainCommLink(FriendlyOperatingUnit, flag4))
					{
						pooledList.Add(FriendlyOperatingUnit);
					}
					else if (!FriendlyOperatingUnit.IsWeapon && (flag4 || FriendlyOperatingUnit == weapon.FiringParent) && (weapon.Type != Weapon._WeaponType.Sonobuoy || !FriendlyOperatingUnit.IsFacility))
					{
						pooledList.Add(FriendlyOperatingUnit);
					}
				}
			}
			ActiveUnit[] array = Geodesic_Haversine.UnitsWithinDistanceFromPoint(pooledList, AssumeAllUnitsAreOperating: true, CS$<>8__locals8.$VB$Local_MyLat, CS$<>8__locals8.$VB$Local_myLon, num);
			pooledList.Dispose();
			if (array != null && array.Length > 1)
			{
				Array.Sort(array, 0, array.Length, Comparer<ActiveUnit>.Create([SpecialName] (ActiveUnit u1, ActiveUnit u2) =>
				{
					if (u1 == null)
					{
						return 1;
					}
					if (u2 != null)
					{
						double num3 = Geodesic_Haversine.Distance_Horiz_Angular_Approx_Rad(CS$<>8__locals8.$VB$Local_MyLat, CS$<>8__locals8.$VB$Local_myLon, u1.get_Latitude((GlobalVariables.BooleanObject)null), u1.get_Longitude((GlobalVariables.BooleanObject)null));
						double value = Geodesic_Haversine.Distance_Horiz_Angular_Approx_Rad(CS$<>8__locals8.$VB$Local_MyLat, CS$<>8__locals8.$VB$Local_myLon, u2.get_Latitude((GlobalVariables.BooleanObject)null), u2.get_Longitude((GlobalVariables.BooleanObject)null));
						return num3.CompareTo(value);
					}
					return -1;
				}));
			}
			if (array != null)
			{
				ActiveUnit[] array2 = array;
				foreach (ActiveUnit activeUnit2 in array2)
				{
					if (activeUnit2 == null)
					{
						continue;
					}
					CommDevice item3 = ActiveUnit_CommStuff.CommDeviceToConnectToThisUnit(method_4(), comms_ReadOnly, activeUnit2).CommDevice;
					if (item3 != null)
					{
						base.ClearAllCommLinks();
						if (weapon.Type == Weapon._WeaponType.Sonobuoy)
						{
							EstablishCommLinkToUnit(item3, activeUnit2, Is_CEC_Connection: false);
						}
						else
						{
							EstablishCommLinkToUnit(item3, activeUnit2, Is_CEC_Connection: true);
						}
						break;
					}
				}
				ArrayPool<ActiveUnit>.Shared.Return(array, clearArray: true);
			}
			array = null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100975", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	static Weapon_CommStuff()
	{
		Class72.smethod_20();
	}
}
