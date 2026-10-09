using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class SameGroupRule : NetworkRule
{
	public override string Summary => base.Name + "  [by parent group]";

	internal override void Apply(NetworkRuleExecutionContext execCtx, HashSet<ActiveUnit> networkedUnits)
	{
		Dictionary<string, List<ActiveUnit>> dictionary = new Dictionary<string, List<ActiveUnit>>();
		foreach (ActiveUnit unit in execCtx.Side.Units)
		{
			if (!NetworkRule.HasWorkingComms(unit) || unit.IsGroup || !unit.IsGroupMember())
			{
				continue;
			}
			string text = smethod_0(unit);
			if (!string.IsNullOrEmpty(text))
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
			if (item.Value.Count < 2)
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
			if (list.Count < 2)
			{
				continue;
			}
			execCtx.CreateNetwork(execCtx.Side, list.Cast<Module_Unit.Unit>(), base.Reason, execCtx.Log, "group: " + item.Key + " (" + Conversions.ToString(list.Count) + " units)", "");
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
			if (activeUnit_0.get_ParentGroup(UsingMissionPlanner: false) != null)
			{
				return activeUnit_0.get_ParentGroup(UsingMissionPlanner: false).ObjectID;
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
		writer.WriteStartElement("SameGroupRule");
		writer.WriteElementString("Name", base.Name);
		writer.WriteElementString("Priority", base.Priority.ToString());
		writer.WriteElementString("Enabled", base.Enabled.ToString());
		writer.WriteElementString("Description", base.Description);
		writer.WriteEndElement();
	}

	public override void FromXML(XmlNode node)
	{
		base.Name = NetworkRule.XmlText(node, "Name", base.Name);
		base.Priority = NetworkRule.XmlInt(node, "Priority", 99);
		base.Enabled = NetworkRule.XmlBool(node, "Enabled", defaultValue: true);
		base.Description = NetworkRule.XmlText(node, "Description", "");
	}

	static SameGroupRule()
	{
		Class72.smethod_20();
	}
}
