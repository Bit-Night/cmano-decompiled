using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class FireMission : Mission
{
	public enum UnitPositionStatus
	{
		OffMission,
		NoViablePosition,
		InTransit,
		InPosition
	}

	[CompilerGenerated]
	internal sealed class _Closure$__22-0
	{
		public IUIListener $VB$Local_TheListener;

		public _Closure$__22-0(_Closure$__22-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_TheListener = arg0.$VB$Local_TheListener;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			$VB$Local_TheListener.updateListener();
		}

		static _Closure$__22-0()
		{
			Class72.smethod_20();
		}
	}

	public HashSet<IUIListener> hashSet_0;

	public List<ReferencePoint> PositionArea;

	public List<ReferencePoint> FireArea;

	public List<ReferencePoint> CounterBatteryArea;

	public FirePattern[] FirePatternPriority;

	public bool[] FirePatternActivation;

	private string string_2;

	public Contact _CurrentTarget;

	public HashSet<Contact> ContactsWithinFireArea;

	private string string_3;

	private List<string> list_0;

	public ActiveUnit UnitCallingForDirectSupport;

	public HashSet<ActiveUnit> UnitsCallingForGeneralSupport;

	private List<ActiveUnit> list_1;

	private List<Contact> list_2;

	private uint uint_0;

	public override List<ReferencePoint> MainArea => PositionArea;

	public Contact CurrentTarget
	{
		get
		{
			return _CurrentTarget;
		}
		set
		{
			if (_CurrentTarget == value)
			{
				return;
			}
			_CurrentTarget = value;
			PropagateToListeners();
			foreach (ActiveUnit item in UnitsCallingForGeneralSupport)
			{
				item.AI.PrimaryTarget = _CurrentTarget;
			}
		}
	}

	public List<ActiveUnit> AssignedUnits_Cached
	{
		get
		{
			if (list_1 == null)
			{
				list_1 = Module_Mission.UnitsAssignedToMissionOrPackage(this, theScen);
			}
			return list_1;
		}
	}

	public override string DescriptionString => "Fire Mission";

	public uint GenerateAllUnitStatusHash(Scenario Scen)
	{
		uint num = 17u;
		foreach (ActiveUnit item in this.get_AssignedUnits_Cached(Scen))
		{
			string objectID = item.ObjectID;
			if (objectID != null)
			{
				int num2 = objectID.Length - 1;
				for (int i = 0; i <= num2; i++)
				{
					uint num3 = objectID[i];
					num = ((num << 5) | (num >> 27)) ^ num3;
				}
			}
			num = ((num << 5) | (num >> 27)) ^ (item.IsOperating() ? 1u : 0u);
			num = ((num << 5) | (num >> 27)) ^ (item.IsMorituri ? 1u : 0u);
			num = ((num << 5) | (num >> 27)) ^ (uint)UnitIsInFiringPosition(item);
		}
		return num;
	}

	public void PropagateToListeners()
	{
		using HashSet<IUIListener>.Enumerator enumerator = hashSet_0.GetEnumerator();
		_Closure$__22-0 closure$__22- = default(_Closure$__22-0);
		while (enumerator.MoveNext())
		{
			closure$__22- = new _Closure$__22-0(closure$__22-);
			closure$__22-.$VB$Local_TheListener = enumerator.Current;
			IUIListener iUIListener = closure$__22-.$VB$Local_TheListener;
			Control val = (Control)((iUIListener is Control) ? iUIListener : null);
			if (val != null && val.InvokeRequired)
			{
				val.BeginInvoke((Delegate)new VB$AnonymousDelegate_0{A835D9A0-0EE4-445E-BC69-5FEB38C502A4}(closure$__22-._Lambda$__0));
			}
			else
			{
				closure$__22-.$VB$Local_TheListener.updateListener();
			}
		}
	}

	public override bool IsFulfilled()
	{
		return true;
	}

	public void Tick(Side Side)
	{
		if (FirePatternActivation[1])
		{
			method_2(Side);
		}
		EvaluateBestTarget(Side);
		uint num = GenerateAllUnitStatusHash(Side.ParentScen);
		if (uint_0 != num)
		{
			PropagateToListeners();
		}
		uint_0 = num;
	}

	private void method_2(Side side_0)
	{
		if (this.get_AssignedUnits_Cached(side_0.ParentScen).Count == 0)
		{
			return;
		}
		ActiveUnit activeUnit = this.get_AssignedUnits_Cached(side_0.ParentScen)[0];
		foreach (KeyValuePair<string, Contact> contact in side_0.Contacts)
		{
			if (!((Module_Unit.Unit)contact.Value).get_IsInsideThisArea(FireArea, side_0.ParentScen, UseCache: true))
			{
				continue;
			}
			ActiveUnit actualUnit = contact.Value.ActualUnit;
			if (actualUnit != null && contact.Value.get_Stance(side_0) == Misc.PostureStance.Hostile)
			{
				ActiveUnit.Str_TemporaryEmission str_TemporaryEmission = actualUnit.TemporaryEmissionEM[6001];
				if (str_TemporaryEmission != null && str_TemporaryEmission.SignatureAbsoluteIncrease > 0f && activeUnit.Weaponry.CanPhysicallyAttackThisTargetRightNow(contact.Value, IgnoreAircraftOrientation: true, IgnoreWeaponRecTimeToFire: true))
				{
					ContactsWithinFireArea.Add(contact.Value);
				}
			}
		}
	}

	public UnitPositionStatus UnitIsInFiringPosition(ActiveUnit Unit)
	{
		if (PositionArea.Count != 0)
		{
			if (Unit.Navigator.PlottedCourse.Length > 0)
			{
				return UnitPositionStatus.InTransit;
			}
			if (GeoPoint.IsInsideThisArea(Unit.get_Latitude((GlobalVariables.BooleanObject)null), Unit.get_Longitude((GlobalVariables.BooleanObject)null), PositionArea))
			{
				return UnitPositionStatus.InPosition;
			}
			return UnitPositionStatus.OffMission;
		}
		return UnitPositionStatus.NoViablePosition;
	}

	public void EvaluateBestTarget(Side Side, bool RemovePreviousTarget = false)
	{
		if (RemovePreviousTarget)
		{
			CurrentTarget = null;
		}
		if (CurrentTarget != null)
		{
			return;
		}
		list_2.Clear();
		int num = FirePatternActivation.Length - 1;
		for (int i = 0; i <= num; i++)
		{
			if (FirePatternActivation[i])
			{
				if (CurrentTarget != null)
				{
					break;
				}
				method_3(FirePatternPriority[i], Side);
			}
		}
	}

	private void method_3(FirePattern firePattern_0, Side side_0)
	{
		if (this.get_AssignedUnits_Cached(side_0.ParentScen).Count == 0)
		{
			return;
		}
		ActiveUnit activeUnit = this.get_AssignedUnits_Cached(side_0.ParentScen)[0];
		switch (firePattern_0)
		{
		case FirePattern.DirectSupport:
			if (UnitCallingForDirectSupport != null)
			{
				method_4(UnitCallingForDirectSupport, activeUnit);
			}
			break;
		case FirePattern.GeneralSupport:
			foreach (ActiveUnit item in UnitsCallingForGeneralSupport)
			{
				item.AI.EvaluateThreats(1f);
				foreach (Contact item2 in UnitCallingForDirectSupport.AI.Threats_ReadOnly)
				{
					if (ContactsWithinFireArea.Contains(item2) && activeUnit.Weaponry.CanPhysicallyAttackThisTargetRightNow(item2, IgnoreAircraftOrientation: true, IgnoreWeaponRecTimeToFire: true))
					{
						list_2.Add(item2);
					}
				}
			}
			break;
		case FirePattern.CounterBattery:
			foreach (KeyValuePair<string, Contact> contact in side_0.Contacts)
			{
				if (!((Module_Unit.Unit)contact.Value).get_IsInsideThisArea(CounterBatteryArea, side_0.ParentScen, UseCache: true))
				{
					continue;
				}
				ActiveUnit actualUnit = contact.Value.ActualUnit;
				if (actualUnit != null && contact.Value.get_Stance(side_0) == Misc.PostureStance.Hostile)
				{
					ActiveUnit.Str_TemporaryEmission str_TemporaryEmission = actualUnit.TemporaryEmissionEM[6001];
					if (str_TemporaryEmission != null && str_TemporaryEmission.SignatureAbsoluteIncrease > 0f && activeUnit.Weaponry.CanPhysicallyAttackThisTargetRightNow(contact.Value, IgnoreAircraftOrientation: true, IgnoreWeaponRecTimeToFire: true))
					{
						list_2.Add(contact.Value);
					}
				}
			}
			break;
		}
		if (list_2.Count <= 0)
		{
			CurrentTarget = null;
		}
		else
		{
			CurrentTarget = list_2[GameGeneral.GlobalRNG.Next(0, list_2.Count)];
		}
	}

	public void SendGeneralFireSupportRequest(ActiveUnit Caller)
	{
		if (FirePatternActivation[1] && UnitCanCallForFireSupport(Caller) && Caller.AI.Threats_ReadOnly.Count != 0)
		{
			UnitsCallingForGeneralSupport.Add(Caller);
		}
	}

	public static bool UnitCanCallForFireSupport(ActiveUnit Caller)
	{
		if (Caller.UnitType != GlobalVariables.ActiveUnitType.AggregateGroundUnit && Caller.UnitType != GlobalVariables.ActiveUnitType.Facility && Caller.UnitType != GlobalVariables.ActiveUnitType.Vehicle)
		{
			return Caller.UnitType == GlobalVariables.ActiveUnitType.Personnel;
		}
		return true;
	}

	private void method_4(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1)
	{
		activeUnit_0.AI.EvaluateThreats(1f);
		foreach (Contact item in UnitCallingForDirectSupport.AI.Threats_ReadOnly)
		{
			if (activeUnit_1.Weaponry.CanPhysicallyAttackThisTargetRightNow(item, IgnoreAircraftOrientation: true, IgnoreWeaponRecTimeToFire: true))
			{
				list_2.Add(item);
			}
		}
	}

	public bool UnitHasViableAmmo(ActiveUnit Unit)
	{
		return true;
	}

	private int method_5(FirePattern firePattern_0)
	{
		int num = FirePatternPriority.Length - 1;
		int num2 = 0;
		while (true)
		{
			if (num2 <= num)
			{
				if (FirePatternPriority[num2] == firePattern_0)
				{
					break;
				}
				num2++;
				continue;
			}
			return -1;
		}
		return num2;
	}

	public void ChangeFirePatternPriority(FirePattern firePattern, OrderedContainerItemAction action)
	{
		int num = method_5(firePattern);
		if (num == -1)
		{
			return;
		}
		switch (action)
		{
		case OrderedContainerItemAction.MoveUp:
			if (num > 0)
			{
				method_6(FirePatternPriority, num, num - 1);
			}
			break;
		case OrderedContainerItemAction.MoveDown:
			if (num < FirePatternPriority.Length - 1)
			{
				method_6(FirePatternPriority, num, num + 1);
			}
			break;
		case OrderedContainerItemAction.Remove:
			FirePatternActivation[(int)firePattern] = false;
			break;
		case OrderedContainerItemAction.Add:
			FirePatternActivation[(int)firePattern] = true;
			break;
		case OrderedContainerItemAction.MoveToTop:
			NtjLfsqcPom(FirePatternPriority, num, 0);
			break;
		case OrderedContainerItemAction.MoveToBottom:
			NtjLfsqcPom(FirePatternPriority, num, FirePatternPriority.Length - 1);
			break;
		}
	}

	private void method_6<T>(T[] gparam_0, int int_1, int int_2)
	{
		T val = gparam_0[int_1];
		gparam_0[int_1] = gparam_0[int_2];
		gparam_0[int_2] = val;
	}

	private void NtjLfsqcPom<T>(T[] gparam_0, int int_1, int int_2)
	{
		if (int_1 == int_2)
		{
			return;
		}
		T val = gparam_0[int_1];
		if (int_1 < int_2)
		{
			int num = int_2 - 1;
			for (int i = int_1; i <= num; i++)
			{
				gparam_0[i] = gparam_0[i + 1];
			}
		}
		else
		{
			int num2 = int_2 + 1;
			for (int j = int_1; j >= num2; j += -1)
			{
				gparam_0[j] = gparam_0[j - 1];
			}
		}
		gparam_0[int_2] = val;
	}

	public override void PrePulseHousekeeping(Scenario theScen)
	{
		base.PrePulseHousekeeping(theScen);
		list_1 = null;
	}

	public override void Printout(StringBuilder PrintoutStringBuilder)
	{
		throw new NotImplementedException();
	}

	public FireMission(Side theSide, Scenario thescen, string theName, MissionCategory theCategory)
		: base(theSide, thescen, theName)
	{
		hashSet_0 = new HashSet<IUIListener>();
		PositionArea = new List<ReferencePoint>();
		FireArea = new List<ReferencePoint>();
		CounterBatteryArea = new List<ReferencePoint>();
		FirePatternPriority = new FirePattern[3]
		{
			FirePattern.DirectSupport,
			FirePattern.GeneralSupport,
			FirePattern.CounterBattery
		};
		FirePatternActivation = new bool[Enum.GetValues(typeof(FirePattern)).Length - 1 + 1];
		_CurrentTarget = null;
		ContactsWithinFireArea = new HashSet<Contact>();
		list_0 = new List<string>();
		UnitCallingForDirectSupport = null;
		UnitsCallingForGeneralSupport = new HashSet<ActiveUnit>();
		list_2 = new List<Contact>();
		uint_0 = 465464u;
		MissionClass = _MissionClass.ArtyFireMission;
		Name = theName;
		Category = theCategory;
	}

	internal override void Reinitialize()
	{
		base.Reinitialize();
	}

	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized, ref Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("FireMission");
			theWriter.WriteElementString("ID", ObjectID);
			theWriter.WriteElementString("Name", Name);
			method_0(ref theWriter, ref ObjectsAlreadySerialized, ref theScen);
			if (_StartTime.HasValue)
			{
				theWriter.WriteElementString("START", _StartTime.Value.ToBinary().ToString());
			}
			if (_EndTime.HasValue)
			{
				theWriter.WriteElementString("END", _EndTime.Value.ToBinary().ToString());
			}
			if (_TakeOffTime.HasValue)
			{
				theWriter.WriteElementString("TakeOffTime", _TakeOffTime.Value.ToBinary().ToString());
			}
			if (_TimeOnTarget.HasValue)
			{
				theWriter.WriteElementString("TimeOnTarget", _TimeOnTarget.Value.ToBinary().ToString());
			}
			theWriter.WriteElementString("UseFlightplan", UseFlightplans.ToString());
			theWriter.WriteElementString("UseFlightplansOnly", UsePreGeneratedFlightplansOnly.ToString());
			if (SecondaryAirBase != null)
			{
				theWriter.WriteElementString("HomeAirbase", SecondaryAirBase.ObjectID.ToString());
			}
			if (SecondaryNavalBase != null)
			{
				theWriter.WriteElementString("HomeNavalbase", SecondaryNavalBase.ObjectID.ToString());
			}
			Doctrine.ToXML(ref theWriter, ref theScen);
			theWriter.WriteElementString("SISIH", ScrubIfSideIsHuman.ToString());
			if (base.get_Status(theScen) != MissionStatus.Active)
			{
				theWriter.WriteElementString("Status", ((byte)base.get_Status(theScen)).ToString());
			}
			if (PositionArea.Count > 0)
			{
				theWriter.WriteStartElement("PositionArea");
				foreach (ReferencePoint item in PositionArea)
				{
					theWriter.WriteRaw(item.ToXML(ref ObjectsAlreadySerialized));
				}
				theWriter.WriteEndElement();
			}
			if (FireArea.Count > 0)
			{
				theWriter.WriteStartElement("FireArea");
				foreach (ReferencePoint item2 in FireArea)
				{
					theWriter.WriteRaw(item2.ToXML(ref ObjectsAlreadySerialized));
				}
				theWriter.WriteEndElement();
			}
			if (CounterBatteryArea.Count > 0)
			{
				theWriter.WriteStartElement("CounterBatteryArea");
				foreach (ReferencePoint item3 in CounterBatteryArea)
				{
					theWriter.WriteRaw(item3.ToXML(ref ObjectsAlreadySerialized));
				}
				theWriter.WriteEndElement();
			}
			theWriter.WriteStartElement("FirePatternPriority");
			FirePattern[] firePatternPriority = FirePatternPriority;
			for (int i = 0; i < firePatternPriority.Length; i = checked(i + 1))
			{
				FirePattern firePattern = firePatternPriority[i];
				theWriter.WriteElementString("Pattern", firePattern.ToString());
			}
			theWriter.WriteEndElement();
			theWriter.WriteStartElement("FirePatternActivation");
			bool[] firePatternActivation = FirePatternActivation;
			foreach (bool flag in firePatternActivation)
			{
				theWriter.WriteElementString("Pattern", flag.ToString());
			}
			theWriter.WriteEndElement();
			if (CurrentTarget != null)
			{
				theWriter.WriteElementString("CurrentTarget", CurrentTarget.ObjectID.ToString());
			}
			if (UnitCallingForDirectSupport != null)
			{
				theWriter.WriteElementString("UnitCallingForDirectSupport", UnitCallingForDirectSupport.ObjectID.ToString());
			}
			if (list_0.Count > 0)
			{
				theWriter.WriteStartElement("UnitsCallingForGeneralSupport");
				foreach (ActiveUnit item4 in UnitsCallingForGeneralSupport)
				{
					theWriter.WriteElementString("ID", item4.ObjectID.ToString());
				}
				theWriter.WriteEndElement();
			}
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200654", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private FireMission(Side theSide, Scenario theScen, string theName)
		: base(theSide, theScen, theName)
	{
		hashSet_0 = new HashSet<IUIListener>();
		PositionArea = new List<ReferencePoint>();
		FireArea = new List<ReferencePoint>();
		CounterBatteryArea = new List<ReferencePoint>();
		FirePatternPriority = new FirePattern[3]
		{
			FirePattern.DirectSupport,
			FirePattern.GeneralSupport,
			FirePattern.CounterBattery
		};
		FirePatternActivation = new bool[Enum.GetValues(typeof(FirePattern)).Length - 1 + 1];
		_CurrentTarget = null;
		ContactsWithinFireArea = new HashSet<Contact>();
		list_0 = new List<string>();
		UnitCallingForDirectSupport = null;
		UnitsCallingForGeneralSupport = new HashSet<ActiveUnit>();
		list_2 = new List<Contact>();
		uint_0 = 465464u;
		MissionClass = _MissionClass.ArtyFireMission;
	}

	public new static FireMission FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref Scenario theScen, Mission existingObject = null)
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0866: Unknown result type (might be due to invalid IL or missing references)
		//IL_086d: Expected O, but got Unknown
		//IL_05e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e8: Expected O, but got Unknown
		//IL_056a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0571: Expected O, but got Unknown
		//IL_04a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ac: Expected O, but got Unknown
		//IL_07c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07cb: Expected O, but got Unknown
		//IL_071b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		FireMission result3 = default(FireMission);
		try
		{
			bool flag;
			FireMission fireMission;
			if (!(flag = existingObject != null))
			{
				fireMission = new FireMission(null, theScen, "");
			}
			else
			{
				fireMission = (FireMission)existingObject;
				fireMission.Reinitialize();
			}
			fireMission.list_0 = new List<string>();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode theNode2 = childNode;
				Mission.FromXMLCommon(fireMission, theNode2);
				switch (theNode2.Name)
				{
				case "Name":
					fireMission.Name = theNode2.InnerText;
					break;
				case "START":
				{
					DateTime value4 = DateTime.FromBinary(Conversions.ToLong(theNode2.InnerText));
					fireMission._StartTime = value4;
					break;
				}
				case "Status":
					((Mission)fireMission).set_Status(theScen, (MissionStatus)Conversions.ToByte(theNode2.InnerText));
					break;
				case "UseFlightplansOnly":
					fireMission.UsePreGeneratedFlightplansOnly = Misc.ParseBool(theNode2.InnerText);
					break;
				case "SISIH":
					fireMission.ScrubIfSideIsHuman = Misc.ParseBool(theNode2.InnerText);
					break;
				case "UseFlightplan":
					fireMission.UseFlightplans = Misc.ParseBool(theNode2.InnerText);
					break;
				case "FirePatternActivation":
				{
					List<bool> list2 = new List<bool>();
					foreach (XmlNode childNode2 in theNode2.ChildNodes)
					{
						if (bool.TryParse(childNode2.InnerText, out var result2))
						{
							list2.Add(result2);
						}
					}
					if (list2.Count == Enum.GetValues(typeof(FirePattern)).Length)
					{
						fireMission.FirePatternActivation = list2.ToArray();
					}
					break;
				}
				case "HomeNavalbase":
					fireMission._SecondaryNavalBaseID = theNode2.InnerText;
					break;
				case "TimeOnTarget":
				{
					DateTime value2 = DateTime.FromBinary(Conversions.ToLong(theNode2.InnerText));
					fireMission.TimeOnTarget = value2;
					break;
				}
				case "TakeOffTime":
				{
					DateTime value = DateTime.FromBinary(Conversions.ToLong(theNode2.InnerText));
					fireMission.TakeOffTime = value;
					break;
				}
				case "ID":
					if (!theDictionary.ContainsKey(theNode2.InnerText))
					{
						fireMission.ObjectID_Set(theNode2.InnerText);
						theDictionary.TryAdd(fireMission.ObjectID, fireMission);
						break;
					}
					result3 = (FireMission)theDictionary[theNode2.InnerText];
					return result3;
				case "Doctrine":
					if (flag)
					{
						fireMission.Doctrine = Doctrine.FromXML(theScen, ref theNode2, fireMission, fireMission.Doctrine);
					}
					else
					{
						fireMission.Doctrine = Doctrine.FromXML(theScen, ref theNode2, fireMission);
					}
					break;
				case "HomeAirbase":
					fireMission._SecondaryAirBaseID = theNode2.InnerText;
					break;
				case "UnitCallingForDirectSupport":
					fireMission.string_3 = theNode2.InnerText;
					break;
				case "FireArea":
					if (flag)
					{
						fireMission.FireArea.Clear();
					}
					foreach (XmlNode childNode3 in theNode2.ChildNodes)
					{
						XmlNode theNode5 = childNode3;
						fireMission.FireArea.Add(ReferencePoint.FromXML(ref theNode5, ref theDictionary, theScen));
					}
					break;
				case "END":
				{
					DateTime value3 = DateTime.FromBinary(Conversions.ToLong(theNode2.InnerText));
					fireMission._EndTime = value3;
					break;
				}
				case "UnitsCallingForGeneralSupport":
					foreach (XmlNode childNode4 in theNode2.ChildNodes)
					{
						XmlNode val2 = childNode4;
						fireMission.list_0.Add(val2.InnerText);
					}
					break;
				case "CounterBatteryArea":
					if (flag)
					{
						fireMission.CounterBatteryArea.Clear();
					}
					foreach (XmlNode childNode5 in theNode2.ChildNodes)
					{
						XmlNode theNode4 = childNode5;
						fireMission.CounterBatteryArea.Add(ReferencePoint.FromXML(ref theNode4, ref theDictionary, theScen));
					}
					break;
				case "CurrentTarget":
					fireMission.string_2 = theNode2.InnerText;
					break;
				case "_Phase":
					fireMission._Phase = (MissionPhase)Conversions.ToByte(theNode2.InnerText);
					break;
				case "PriorityWeight":
					fireMission.PriorityWeight = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "FirePatternPriority":
				{
					List<FirePattern> list = new List<FirePattern>();
					foreach (XmlNode childNode6 in theNode2.ChildNodes)
					{
						if (Enum.TryParse<FirePattern>(childNode6.InnerText, out var result))
						{
							list.Add(result);
						}
					}
					if (list.Count == Enum.GetValues(typeof(FirePattern)).Length)
					{
						fireMission.FirePatternPriority = list.ToArray();
					}
					break;
				}
				case "PositionArea":
					if (flag)
					{
						fireMission.PositionArea.Clear();
					}
					foreach (XmlNode childNode7 in theNode2.ChildNodes)
					{
						XmlNode theNode3 = childNode7;
						fireMission.PositionArea.Add(ReferencePoint.FromXML(ref theNode3, ref theDictionary, theScen));
					}
					break;
				case "Completion":
					fireMission.Completion = Conversions.ToSingle(theNode2.InnerText);
					break;
				case "AssignedUnitsList":
					foreach (XmlNode childNode8 in theNode2.ChildNodes)
					{
						XmlNode val = childNode8;
						fireMission.UnitsAssignedToMissionIDs.Add(val.InnerText);
					}
					break;
				}
			}
			result3 = fireMission;
			return result3;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200656", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result3;
	}

	public override void PostDeserializationHousekeeping(ref Scenario theScen, Side theSide, bool GameIsRunning, ref ConcurrentDictionary<string, ScenarioObject> ObjectsDictionary)
	{
		try
		{
			if (!string.IsNullOrEmpty(string_2))
			{
				theSide.Contacts.TryGetValue(string_2, out _CurrentTarget);
			}
			if (!string.IsNullOrEmpty(string_3))
			{
				foreach (ActiveUnit activeUnits_ in theScen.ActiveUnits_List)
				{
					if (activeUnits_ != null && Operators.CompareString(string_3, activeUnits_.ObjectID, false) == 0)
					{
						UnitCallingForDirectSupport = activeUnits_;
					}
				}
			}
			if (list_0.Count > 0)
			{
				foreach (ActiveUnit activeUnits_2 in theScen.ActiveUnits_List)
				{
					if (activeUnits_2 != null && list_0.Contains(activeUnits_2.ObjectID))
					{
						UnitsCallingForGeneralSupport.Add(activeUnits_2);
					}
				}
			}
			base.PostDeserializationHousekeeping(ref theScen, theSide, GameIsRunning, ref ObjectsDictionary);
			method_2(theSide);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200657", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override Mission Clone(bool DeepCloneRPs)
	{
		FireMission obj = (FireMission)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Name = "[CLONE] " + Name;
		return obj;
	}

	static FireMission()
	{
		Class72.smethod_20();
	}
}
