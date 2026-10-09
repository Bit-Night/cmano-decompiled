using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;

namespace Command_Core;

public class SameUnitTypeRule : NetworkRule
{
	[CompilerGenerated]
	private string string_2;

	[CompilerGenerated]
	private bool bool_1;

	public string TargetType
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

	public bool SplitBySubtype
	{
		[CompilerGenerated]
		get
		{
			return bool_1;
		}
		[CompilerGenerated]
		set
		{
			bool_1 = value;
		}
	}

	public override string Summary => base.Name + "  [type: " + TargetType + (SplitBySubtype ? " (split by subtype)" : "") + "]";

	public SameUnitTypeRule()
	{
		TargetType = "Aircraft";
		SplitBySubtype = false;
	}

	internal override void Apply(NetworkRuleExecutionContext execCtx, HashSet<ActiveUnit> networkedUnits)
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		foreach (ActiveUnit unit in execCtx.Side.Units)
		{
			if (!unit.IsGroup && NetworkRule.HasWorkingComms(unit) && method_0(unit, execCtx) && (CanClaimAlreadyNetworked || !networkedUnits.Contains(unit)))
			{
				list.Add(unit);
			}
		}
		if (list.Count < 2)
		{
			return;
		}
		if (!SplitBySubtype)
		{
			execCtx.CreateNetwork(execCtx.Side, list.Cast<Module_Unit.Unit>(), base.Reason, execCtx.Log, "type network: " + TargetType, "");
			{
				foreach (ActiveUnit item in list)
				{
					networkedUnits.Add(item);
				}
				return;
			}
		}
		Dictionary<string, List<ActiveUnit>> dictionary = new Dictionary<string, List<ActiveUnit>>();
		foreach (ActiveUnit item2 in list)
		{
			string key = smethod_0(item2, execCtx);
			if (!dictionary.ContainsKey(key))
			{
				dictionary[key] = new List<ActiveUnit>();
			}
			dictionary[key].Add(item2);
		}
		foreach (KeyValuePair<string, List<ActiveUnit>> item3 in dictionary)
		{
			if (item3.Value.Count < 2)
			{
				continue;
			}
			execCtx.CreateNetwork(execCtx.Side, item3.Value.Cast<Module_Unit.Unit>(), base.Reason, execCtx.Log, "type network: " + TargetType + "/" + item3.Key, "");
			foreach (ActiveUnit item4 in item3.Value)
			{
				networkedUnits.Add(item4);
			}
		}
	}

	private bool method_0(ActiveUnit activeUnit_0, NetworkRuleExecutionContext networkRuleExecutionContext_0)
	{
		return TargetType.ToLower() switch
		{
			"ship" => activeUnit_0.IsShip, 
			"submarine" => activeUnit_0.IsSubmarine, 
			"facility" => activeUnit_0.IsFacility, 
			"tanker" => networkRuleExecutionContext_0.IsTanker(activeUnit_0), 
			"aew" => networkRuleExecutionContext_0.IsAEW(activeUnit_0), 
			"aircraft" => activeUnit_0.IsAircraft, 
			_ => false, 
		};
	}

	private static string smethod_0(ActiveUnit activeUnit_0, NetworkRuleExecutionContext networkRuleExecutionContext_0)
	{
		if (networkRuleExecutionContext_0.IsAEW(activeUnit_0))
		{
			return "AEW";
		}
		if (!networkRuleExecutionContext_0.IsTanker(activeUnit_0))
		{
			if (!activeUnit_0.IsAircraft)
			{
				if (activeUnit_0.IsSubmarine)
				{
					return "Submarine";
				}
				if (activeUnit_0.IsShip)
				{
					return "Ship";
				}
				return "Other";
			}
			return "Aircraft";
		}
		return "Tanker";
	}

	public override void ToXML(XmlWriter writer)
	{
		writer.WriteStartElement("SameUnitTypeRule");
		writer.WriteElementString("Name", base.Name);
		writer.WriteElementString("Priority", base.Priority.ToString());
		writer.WriteElementString("Enabled", base.Enabled.ToString());
		writer.WriteElementString("Description", base.Description);
		writer.WriteElementString("TargetType", TargetType);
		writer.WriteElementString("SplitBySubtype", SplitBySubtype.ToString());
		writer.WriteEndElement();
	}

	public override void FromXML(XmlNode node)
	{
		base.Name = NetworkRule.XmlText(node, "Name", base.Name);
		base.Priority = NetworkRule.XmlInt(node, "Priority", 99);
		base.Enabled = NetworkRule.XmlBool(node, "Enabled", defaultValue: true);
		base.Description = NetworkRule.XmlText(node, "Description", "");
		TargetType = NetworkRule.XmlText(node, "TargetType", "Aircraft");
		SplitBySubtype = NetworkRule.XmlBool(node, "SplitBySubtype", defaultValue: false);
	}

	static SameUnitTypeRule()
	{
		Class72.smethod_20();
	}
}
