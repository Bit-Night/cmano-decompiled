using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EventTrigger_UnitDamaged : EventTrigger
{
	public UnitFilterObject TargetFilter;

	public byte DamagePercent;

	public ActiveUnit DamagedUnit;

	public ActiveUnit DamagingUnit;

	public bool IsFulfilled
	{
		get
		{
			bool flag = false;
			DamagedUnit = null;
			if (TargetFilter.MatchesThisUnit(theDamagedUnit))
			{
				if (OldDamagePercent == NewDamagePercent)
				{
					return false;
				}
				if (theDamagedUnit.IsBeingDestroyed)
				{
					flag = true;
				}
				if (NewDamagePercent >= 100f && OldDamagePercent < (float)(int)DamagePercent)
				{
					flag = true;
				}
				if (OldDamagePercent < NewDamagePercent && (!(OldDamagePercent > 0f) || !(OldDamagePercent >= (float)(int)DamagePercent)) && NewDamagePercent >= (float)(int)DamagePercent)
				{
					flag = true;
				}
				if (!flag)
				{
					DamagedUnit = null;
				}
				else
				{
					DamagedUnit = theDamagedUnit;
					theDamagedUnit.ParentScen.Scenario_LuaSandbox.UnitX = theDamagedUnit;
					if (theWeaponHitting != null)
					{
						DamagingUnit = theWeaponHitting;
						theDamagedUnit.ParentScen.Scenario_LuaSandbox.UnitY = theWeaponHitting;
					}
					else if (theDamagedUnit.Damage.LastWeaponHit != null)
					{
						DamagingUnit = theDamagedUnit.Damage.LastWeaponHit;
						theDamagedUnit.ParentScen.Scenario_LuaSandbox.UnitY = theDamagedUnit.Damage.LastWeaponHit;
					}
				}
				return flag;
			}
			return false;
		}
	}

	public EventTrigger_UnitDamaged()
	{
		TargetFilter = new UnitFilterObject();
		Type = EventTriggerType.UnitDamaged;
	}

	public override void ToXML(XmlWriter theWriter, HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("EventTrigger_UnitDamaged");
			theWriter.WriteElementString("ID", ObjectID);
			theWriter.WriteElementString("Description", Description);
			theWriter.WriteElementString("DamagePercent", DamagePercent.ToString());
			theWriter.WriteStartElement("TargetFilter");
			TargetFilter.ToXML(theWriter, ObjectsAlreadySerialized, theScen);
			theWriter.WriteEndElement();
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100526", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static EventTrigger_UnitDamaged FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		EventTrigger_UnitDamaged result = default(EventTrigger_UnitDamaged);
		try
		{
			EventTrigger_UnitDamaged eventTrigger_UnitDamaged = new EventTrigger_UnitDamaged();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "Description":
					eventTrigger_UnitDamaged.Description = val.InnerText;
					break;
				case "TargetFilter":
					eventTrigger_UnitDamaged.TargetFilter = UnitFilterObject.FromXML(val, theDictionary, theScen);
					break;
				case "DamagePercent":
					eventTrigger_UnitDamaged.DamagePercent = Conversions.ToByte(val.InnerText);
					break;
				case "ID":
					eventTrigger_UnitDamaged.ObjectID_Set(val.InnerText);
					break;
				}
			}
			result = eventTrigger_UnitDamaged;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100527", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override EventTrigger Clone()
	{
		EventTrigger_UnitDamaged obj = (EventTrigger_UnitDamaged)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[CLONE] " + Description;
		obj.Name = "[CLONE] " + Name;
		obj.TargetFilter = TargetFilter.Clone();
		return obj;
	}

	static EventTrigger_UnitDamaged()
	{
		Class72.smethod_20();
	}
}
