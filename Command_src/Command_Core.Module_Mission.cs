using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class Module_Mission
{
	internal static List<ActiveUnit> UnitsAssignedToMissionOrPackage(this Mission theMission, Scenario theScen)
	{
		List<ActiveUnit> result;
		if (theMission != null && theScen != null)
		{
			List<ActiveUnit> list = new List<ActiveUnit>();
			try
			{
				ActiveUnit[] array;
				try
				{
					array = theScen.ActiveUnits_List.InternalArray();
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					array = theScen.ActiveUnits_List.InternalArray();
					ProjectData.ClearProjectError();
				}
				ActiveUnit[] array2 = array;
				foreach (ActiveUnit activeUnit in array2)
				{
					if (activeUnit != null)
					{
						if (activeUnit.ActiveMissionOrPackage() == theMission)
						{
							list.Add(activeUnit);
						}
						else if (activeUnit.AllowMultiMission && Enumerable.Contains(activeUnit.AssignedMissionsQueue.Keys, theMission))
						{
							list.Add(activeUnit);
						}
						else if (string.CompareOrdinal(activeUnit.PrivateSnapshotMission?.ObjectID, theMission.ObjectID) == 0)
						{
							list.Add(activeUnit);
						}
					}
				}
				result = list;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2.Data.Add("Error at 100642", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = new List<ActiveUnit>();
				ProjectData.ClearProjectError();
			}
		}
		else
		{
			result = new List<ActiveUnit>();
		}
		return result;
	}

	static Module_Mission()
	{
		Class72.smethod_20();
	}
}
