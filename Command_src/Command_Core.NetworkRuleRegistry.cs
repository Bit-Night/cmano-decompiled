using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class NetworkRuleRegistry
{
	private List<NetworkRule> list_0;

	public IReadOnlyList<NetworkRule> Rules => list_0.AsReadOnly();

	public NetworkRuleRegistry()
	{
		list_0 = new List<NetworkRule>();
	}

	public void Add(NetworkRule rule)
	{
		list_0.Add(rule);
		list_0.Sort([SpecialName] (NetworkRule a, NetworkRule b) => a.Priority.CompareTo(b.Priority));
	}

	public void Remove(NetworkRule rule)
	{
		list_0.Remove(rule);
	}

	public void Clear()
	{
		list_0.Clear();
	}

	public void MoveUp(NetworkRule rule)
	{
		int num = list_0.IndexOf(rule);
		if (num > 0)
		{
			list_0.RemoveAt(num);
			list_0.Insert(num - 1, rule);
			method_0();
		}
	}

	public void MoveDown(NetworkRule rule)
	{
		int num = list_0.IndexOf(rule);
		if (num >= 0 && num < list_0.Count - 1)
		{
			list_0.RemoveAt(num);
			list_0.Insert(num + 1, rule);
			method_0();
		}
	}

	private void method_0()
	{
		int num = list_0.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			list_0[i].Priority = i;
		}
	}

	public int IndexOf(NetworkRule rule)
	{
		return list_0.IndexOf(rule);
	}

	public static NetworkRuleRegistry BuildDefaults()
	{
		NetworkRuleRegistry networkRuleRegistry = new NetworkRuleRegistry();
		networkRuleRegistry.Add(new SameUnitTypeRule
		{
			Name = "airbases network",
			Priority = 0,
			TargetType = "Facility",
			Reason = CommNetwork.NetworkCreationReason.AirBases,
			Description = "All airbase units grouped into a single network."
		});
		networkRuleRegistry.Add(new SameUnitTypeRule
		{
			Name = "AEW network",
			Priority = 1,
			TargetType = "AEW",
			Reason = CommNetwork.NetworkCreationReason.AEWComm,
			Description = "All AEW aircraft form their own surveillance network."
		});
		networkRuleRegistry.Add(new SameMissionRule
		{
			Name = "groups / missions network",
			Priority = 2,
			MinUnitsToNetwork = 2,
			Reason = CommNetwork.NetworkCreationReason.Mission,
			Description = "Units sharing a mission are networked together."
		});
		networkRuleRegistry.Add(new SameGroupRule
		{
			Name = "formation groups network",
			Priority = 3,
			Reason = CommNetwork.NetworkCreationReason.Group,
			Description = "Units belonging to the same formation group are networked together."
		});
		networkRuleRegistry.Add(new WithinDistanceRule
		{
			Name = "AEW proximity pull",
			Priority = 5,
			RadiusNM = 400.0,
			HUBtTypeFilter = "AEW",
			UnitTypeFilter = "",
			RequireCommCheck = true,
			CanClaimAlreadyNetworkedOverride = true,
			Reason = CommNetwork.NetworkCreationReason.AEWProximity,
			Description = "AEW hubs pull in group leaders within comm range."
		});
		return networkRuleRegistry;
	}

	public void ToXML(XmlWriter writer)
	{
		writer.WriteStartElement("NetworkRules");
		foreach (NetworkRule item in list_0)
		{
			item.ToXML(writer);
		}
		writer.WriteEndElement();
	}

	public void FromXML(XmlNode node)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		list_0.Clear();
		foreach (XmlNode childNode in node.ChildNodes)
		{
			XmlNode val = childNode;
			NetworkRule networkRule = null;
			if (Operators.CompareString(val.Name, "SameMissionRule", false) == 0)
			{
				networkRule = new SameMissionRule();
			}
			else if (Operators.CompareString(val.Name, "WithinDistanceRule", false) != 0)
			{
				if (Operators.CompareString(val.Name, "SameUnitTypeRule", false) == 0)
				{
					networkRule = new SameUnitTypeRule();
				}
				else if (Operators.CompareString(val.Name, "LuaPredicateRule", false) != 0)
				{
					if (Operators.CompareString(val.Name, "SameGroupRule", false) == 0)
					{
						networkRule = new SameGroupRule();
					}
					else if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
				}
				else
				{
					networkRule = new LuaPredicateRule();
				}
			}
			else
			{
				networkRule = new WithinDistanceRule();
			}
			if (networkRule != null)
			{
				networkRule.FromXML(val);
				list_0.Add(networkRule);
			}
		}
	}

	static NetworkRuleRegistry()
	{
		Class72.smethod_20();
	}
}
