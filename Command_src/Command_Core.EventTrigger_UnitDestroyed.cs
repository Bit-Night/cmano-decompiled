using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Command_Core.Lua;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EventTrigger_UnitDestroyed : EventTrigger
{
	public UnitFilterObject TargetFilter;

	public ActiveUnit DestroyedUnit;

	public ActiveUnit DamagingUnit;

	public bool IsFulfilled
	{
		get
		{
			bool num = TargetFilter.MatchesThisUnit(theDestroyedUnit);
			if (!num)
			{
				DestroyedUnit = null;
			}
			else
			{
				DamagingUnit = null;
				DestroyedUnit = theDestroyedUnit;
				theDestroyedUnit.ParentScen.Scenario_LuaSandbox.UnitX = theDestroyedUnit;
				if (theWeaponHitting != null)
				{
					DamagingUnit = theWeaponHitting;
					theDestroyedUnit.ParentScen.Scenario_LuaSandbox.UnitY = theWeaponHitting;
					return num;
				}
				if (theDestroyedUnit.Damage.LastWeaponHit != null)
				{
					DamagingUnit = theDestroyedUnit.Damage.LastWeaponHit;
					theDestroyedUnit.ParentScen.Scenario_LuaSandbox.UnitY = theDestroyedUnit.Damage.LastWeaponHit;
					return num;
				}
			}
			return num;
		}
	}

	public bool IsFulfilled
	{
		get
		{
			bool num = TargetFilter.MatchesThisUnit(theDestroyedUnit);
			if (!num)
			{
				DestroyedUnit = null;
			}
			else
			{
				DamagingUnit = null;
				DestroyedUnit = LuaSandBox.Singleton().MakeActiveUnitOfUnguidedWeapon(theDestroyedUnit);
				DestroyedUnit.ParentScen.Scenario_LuaSandbox.UnitX = theDestroyedUnit;
				if (theWeaponHitting != null)
				{
					DamagingUnit = theWeaponHitting;
					DestroyedUnit.ParentScen.Scenario_LuaSandbox.UnitY = theWeaponHitting;
					return num;
				}
			}
			return num;
		}
	}

	public EventTrigger_UnitDestroyed()
	{
		TargetFilter = new UnitFilterObject();
		Type = EventTriggerType.UnitDestroyed;
	}

	public override void ToXML(XmlWriter theWriter, HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("EventTrigger_UnitDestroyed");
			theWriter.WriteElementString("ID", ObjectID);
			theWriter.WriteElementString("Description", Description);
			theWriter.WriteStartElement("TargetFilter");
			TargetFilter.ToXML(theWriter, ObjectsAlreadySerialized, theScen);
			theWriter.WriteEndElement();
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100528", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static EventTrigger_UnitDestroyed FromXML(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		EventTrigger_UnitDestroyed result;
		try
		{
			EventTrigger_UnitDestroyed eventTrigger_UnitDestroyed = new EventTrigger_UnitDestroyed();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "ID":
					eventTrigger_UnitDestroyed.ObjectID_Set(val.InnerText);
					break;
				case "Description":
					eventTrigger_UnitDestroyed.Description = val.InnerText;
					break;
				case "TargetFilter":
					eventTrigger_UnitDestroyed.TargetFilter = UnitFilterObject.FromXML(val, theDictionary, theScen);
					break;
				}
			}
			result = eventTrigger_UnitDestroyed;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100529", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new EventTrigger_UnitDestroyed();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override EventTrigger Clone()
	{
		EventTrigger_UnitDestroyed obj = (EventTrigger_UnitDestroyed)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[CLONE] " + Description;
		obj.Name = "[CLONE] " + Name;
		obj.TargetFilter = TargetFilter.Clone();
		return obj;
	}

	static EventTrigger_UnitDestroyed()
	{
		Class72.smethod_20();
	}
}
