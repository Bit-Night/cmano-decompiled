using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class WeaponAssignment : ScenarioObject
{
	public Weapon Weapon;

	public int Quantity;

	public Contact Target;

	public DateTime ScheduledFireTime;

	public List<Waypoint> PlottedCourse;

	public bool ManualFire;

	public void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
		try
		{
			theWriter.WriteStartElement("WeaponAssignment");
			theWriter.WriteElementString("ID", ObjectID);
			if (!ObjectsAlreadySerialized.Contains(ObjectID))
			{
				ObjectsAlreadySerialized.Add(ObjectID);
				theWriter.WriteElementString("Weapon", Weapon.DBID.ToString());
				theWriter.WriteElementString("Quantity", Quantity.ToString());
				theWriter.WriteElementString("Target", Target.ObjectID);
				theWriter.WriteElementString("ScheduledFireTime", ScheduledFireTime.ToBinary().ToString());
				theWriter.WriteStartElement("PlottedCourse");
				foreach (Waypoint item in PlottedCourse)
				{
					item.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
				}
				theWriter.WriteEndElement();
				theWriter.WriteElementString("ManualFire", ManualFire.ToString());
				theWriter.WriteEndElement();
			}
			else
			{
				theWriter.WriteEndElement();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101072", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static WeaponAssignment FromXML(ref XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, ref Scenario theScen)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		WeaponAssignment result;
		try
		{
			WeaponAssignment weaponAssignment = new WeaponAssignment();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "ID":
					weaponAssignment.ObjectID_Set(val.InnerText);
					break;
				case "ManualFire":
					weaponAssignment.ManualFire = Misc.ParseBool(val.InnerText);
					break;
				case "Quantity":
					weaponAssignment.Quantity = Conversions.ToInteger(val.InnerText);
					break;
				case "ScheduledFireTime":
					weaponAssignment.ScheduledFireTime = DateTime.FromBinary(Conversions.ToLong(val.InnerText));
					break;
				case "PlottedCourse":
					foreach (XmlNode childNode2 in val.ChildNodes)
					{
						XmlNode theNode2 = childNode2;
						Waypoint item = Waypoint.FromXML(ref theNode2, ref theDictionary, theScen);
						weaponAssignment.PlottedCourse.Add(item);
					}
					break;
				case "Weapon":
					weaponAssignment.Weapon = theScen.Cache_GetWeapon(Conversions.ToInteger(val.InnerText));
					break;
				case "Target":
					if (val.InnerText.StartsWith("Aimpoint_"))
					{
						weaponAssignment.Target = AimpointContact.FromString(val.InnerText);
					}
					else
					{
						weaponAssignment.Target = Contact.FromXML(val.InnerText, ref theDictionary);
					}
					break;
				}
			}
			result = weaponAssignment;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101073", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new WeaponAssignment();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private WeaponAssignment()
	{
		PlottedCourse = new List<Waypoint>();
	}

	public WeaponAssignment(ref Weapon theWeapon, int theQuantity, ref Contact theTarget, ref bool theManualFire, [Optional][DateTimeConstant(0L)] DateTime theScheduledTime, List<Waypoint> thePlottedCourse = null)
	{
		PlottedCourse = new List<Waypoint>();
		try
		{
			Weapon = theWeapon;
			Quantity = theQuantity;
			Target = theTarget;
			ManualFire = theManualFire;
			if (!Information.IsNothing((object)theScheduledTime))
			{
				ScheduledFireTime = theScheduledTime;
			}
			if (!Information.IsNothing((object)thePlottedCourse))
			{
				PlottedCourse = thePlottedCourse;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101074", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool IsIdenticalToThisWA(WeaponAssignment theWA)
	{
		if (Weapon.DBID != theWA.Weapon.DBID)
		{
			return false;
		}
		if (Target != theWA.Target)
		{
			return false;
		}
		if (Information.IsNothing((object)ScheduledFireTime) && !Information.IsNothing((object)theWA.ScheduledFireTime))
		{
			return false;
		}
		if (!Information.IsNothing((object)ScheduledFireTime) && Information.IsNothing((object)theWA.ScheduledFireTime))
		{
			return false;
		}
		if (DateTime.Compare(ScheduledFireTime, theWA.ScheduledFireTime) != 0)
		{
			return false;
		}
		if (ManualFire != theWA.ManualFire)
		{
			return false;
		}
		if (Information.IsNothing((object)PlottedCourse) && !Information.IsNothing((object)theWA.PlottedCourse))
		{
			return false;
		}
		if (!Information.IsNothing((object)PlottedCourse) && Information.IsNothing((object)theWA.PlottedCourse))
		{
			return false;
		}
		int result;
		if (Information.IsNothing((object)PlottedCourse))
		{
			result = 1;
		}
		else
		{
			if ((PlottedCourse.Count != 0 || theWA.PlottedCourse.Count != 0) && PlottedCourse != theWA.PlottedCourse)
			{
				return false;
			}
			result = 1;
		}
		return (byte)result != 0;
	}

	static WeaponAssignment()
	{
		Class72.smethod_20();
	}
}
