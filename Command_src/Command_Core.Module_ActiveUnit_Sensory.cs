using System;
using System.Collections.Generic;
using System.Linq;
using Collections.Pooled;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class Module_ActiveUnit_Sensory
{
	internal static PooledList<Contact> ContactsVisibleToMe(this ActiveUnit_Sensory theSensory)
	{
		PooledList<Contact> pooledList = new PooledList<Contact>();
		if (!GameGeneral.Beta_PlatformComms || !theSensory.myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.PointToPointComm))
		{
			pooledList = ((!theSensory.myUnit.CommStuff.IsConnectedToSideNetwork) ? theSensory.PrivateContactList() : theSensory.myUnit.get_UnitSide(SetSideOnly: false).Contacts_List);
		}
		else
		{
			pooledList.AddRange(theSensory.PrivateContactList());
			if (theSensory.Contacts_Local != null)
			{
				List<Contact> list;
				try
				{
					list = theSensory.Contacts_Local.Values.ToList();
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					list = new List<Contact>();
					ProjectData.ClearProjectError();
				}
				foreach (Contact item in list)
				{
					if (item != null)
					{
						pooledList.Add(item);
					}
				}
				pooledList.Distinct();
			}
		}
		return pooledList;
	}

	static Module_ActiveUnit_Sensory()
	{
		Class72.smethod_20();
	}
}
