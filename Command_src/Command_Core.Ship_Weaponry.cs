using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Ship_Weaponry : ActiveUnit_Weaponry
{
	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
		try
		{
			theWriter.WriteStartElement("Ship_Weaponry");
			List<WeaponAssignment> weaponAssignments = WeaponAssignments;
			if (weaponAssignments != null && weaponAssignments.Count > 0)
			{
				theWriter.WriteStartElement("WeaponAssignments");
				foreach (WeaponAssignment weaponAssignment in WeaponAssignments)
				{
					weaponAssignment.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
				}
				theWriter.WriteEndElement();
			}
			if (bool_3)
			{
				theWriter.WriteElementString("IDLZ", "True");
			}
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100797", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static Ship_Weaponry FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		Ship_Weaponry result;
		try
		{
			Ship_Weaponry ship_Weaponry = new Ship_Weaponry(ref theAU);
			ship_Weaponry.myUnit = theAU;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "WeaponAssignments":
					foreach (XmlNode childNode2 in val.ChildNodes)
					{
						XmlNode theNode2 = childNode2;
						WeaponAssignment weaponAssignment = WeaponAssignment.FromXML(ref theNode2, theDictionary, ref theAU.ParentScen);
						if (weaponAssignment.Target != null)
						{
							if (ship_Weaponry.WeaponAssignments == null)
							{
								ship_Weaponry.WeaponAssignments = new List<WeaponAssignment>();
							}
							ship_Weaponry.WeaponAssignments.Add(weaponAssignment);
						}
					}
					break;
				case "IDLZ":
					ship_Weaponry.bool_3 = true;
					break;
				case "HF":
					if (theAU.Doctrine != null && Misc.ParseBool(val.InnerText))
					{
						theAU.Doctrine.set_WeaponControlStatus_Air(theAU.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._WCS?)Doctrine._WCS.Hold);
					}
					break;
				}
			}
			result = ship_Weaponry;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100798", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Ship_Weaponry(ref theAU);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public Ship_Weaponry(ref ActiveUnit theUnit)
		: base(theUnit)
	{
	}

	static Ship_Weaponry()
	{
		Class72.smethod_20();
	}
}
