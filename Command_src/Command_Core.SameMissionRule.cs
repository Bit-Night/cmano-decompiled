using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class SameMissionRule : NetworkRule
{
	[CompilerGenerated]
	private string string_2;

	[CompilerGenerated]
	private int int_1;

	public string MissionNameFilter
	{
		[CompilerGenerated]
		get
		{
			return string_2;
		}
		[CompilerGenerated]
		set
		{
			string_2 = value;
		}
	}

	public int MinUnitsToNetwork
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	public override string Summary
	{
		get
		{
			if (!string.IsNullOrEmpty(MissionNameFilter))
			{
				return base.Name + "  [missions matching \"" + MissionNameFilter + "\", min " + Conversions.ToString(MinUnitsToNetwork) + " units]";
			}
			return base.Name + "  [all missions, min " + Conversions.ToString(MinUnitsToNetwork) + " units]";
		}
	}

	public SameMissionRule()
	{
		MissionNameFilter = "";
		MinUnitsToNetwork = 2;
	}

	internal override void Apply(NetworkRuleExecutionContext execCtx, HashSet<ActiveUnit> networkedUnits)
	{
		Dictionary<string, List<ActiveUnit>> dictionary = new Dictionary<string, List<ActiveUnit>>();
		foreach (ActiveUnit unit in execCtx.Side.Units)
		{
			if (!NetworkRule.HasWorkingComms(unit) || unit.IsGroup)
			{
				continue;
			}
			string text = smethod_0(unit);
			if (!string.IsNullOrEmpty(text) && (string.IsNullOrEmpty(MissionNameFilter) || text.ToLower().IndexOf(MissionNameFilter.ToLower()) >= 0))
			{
				if (!dictionary.ContainsKey(text))
				{
					dictionary[text] = new List<ActiveUnit>();
				}
				dictionary[text].Add(unit);
			}
		}
		foreach (KeyValuePair<string, List<ActiveUnit>> item in dictionary)
		{
			if (item.Value.Count < MinUnitsToNetwork)
			{
				continue;
			}
			List<ActiveUnit> list = new List<ActiveUnit>();
			foreach (ActiveUnit item2 in item.Value)
			{
				if (CanClaimAlreadyNetworked || !networkedUnits.Contains(item2))
				{
					list.Add(item2);
				}
			}
			if (list.Count < MinUnitsToNetwork)
			{
				continue;
			}
			execCtx.CreateNetwork(execCtx.Side, list.Cast<Module_Unit.Unit>(), base.Reason, execCtx.Log, "mission: " + item.Key + " (" + Conversions.ToString(list.Count) + " units)", "");
			foreach (ActiveUnit item3 in list)
			{
				networkedUnits.Add(item3);
			}
		}
	}

	private static string smethod_0(ActiveUnit activeUnit_0)
	{
		try
		{
			if (activeUnit_0.AI != null)
			{
				Mission mission = activeUnit_0.ActiveMissionOrPackage();
				if (mission != null)
				{
					return mission.Name;
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		return string.Empty;
	}

	public override void ToXML(XmlWriter writer)
	{
		writer.WriteStartElement("SameMissionRule");
		writer.WriteElementString("Name", base.Name);
		writer.WriteElementString("Priority", base.Priority.ToString());
		writer.WriteElementString("Enabled", base.Enabled.ToString());
		writer.WriteElementString("Description", base.Description);
		writer.WriteElementString("MissionNameFilter", MissionNameFilter);
		writer.WriteElementString("MinUnitsToNetwork", MinUnitsToNetwork.ToString());
		writer.WriteEndElement();
	}

	public override void FromXML(XmlNode node)
	{
		base.Name = NetworkRule.XmlText(node, "Name", base.Name);
		base.Priority = NetworkRule.XmlInt(node, "Priority", 99);
		base.Enabled = NetworkRule.XmlBool(node, "Enabled", defaultValue: true);
		base.Description = NetworkRule.XmlText(node, "Description", "");
		MissionNameFilter = NetworkRule.XmlText(node, "MissionNameFilter", "");
		MinUnitsToNetwork = NetworkRule.XmlInt(node, "MinUnitsToNetwork", 2);
	}

	static SameMissionRule()
	{
		Class72.smethod_20();
	}
}
