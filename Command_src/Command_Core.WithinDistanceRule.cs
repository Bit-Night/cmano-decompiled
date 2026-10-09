using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class WithinDistanceRule : NetworkRule
{
	private enum Enum7
	{

	}

	[CompilerGenerated]
	private double double_0;

	[CompilerGenerated]
	private string string_2;

	[CompilerGenerated]
	private string string_3;

	[CompilerGenerated]
	private string string_4;

	[CompilerGenerated]
	private bool bool_1;

	private bool rWeLrcoUhFP;

	public double RadiusNM
	{
		[CompilerGenerated]
		get
		{
			return double_0;
		}
		[CompilerGenerated]
		set
		{
			double_0 = value;
		}
	}

	public string HubUnitNameOrGuid
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

	public string HUBtTypeFilter
	{
		[CompilerGenerated]
		get
		{
			return string_3;
		}
		[CompilerGenerated]
		set
		{
			string_3 = value;
		}
	}

	public string UnitTypeFilter
	{
		[CompilerGenerated]
		get
		{
			return string_4;
		}
		[CompilerGenerated]
		set
		{
			string_4 = value;
		}
	}

	public bool RequireCommCheck
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

	public override bool CanClaimAlreadyNetworked => rWeLrcoUhFP;

	public bool CanClaimAlreadyNetworkedOverride
	{
		set
		{
			rWeLrcoUhFP = value;
		}
	}

	public override string Summary
	{
		get
		{
			string text = (string.IsNullOrEmpty(HubUnitNameOrGuid) ? "any hub" : HubUnitNameOrGuid);
			if (!string.IsNullOrEmpty(HUBtTypeFilter))
			{
				_ = HUBtTypeFilter;
			}
			string text2 = (string.IsNullOrEmpty(UnitTypeFilter) ? "none" : UnitTypeFilter);
			string text3 = ((!RequireCommCheck) ? "" : " + comm");
			return base.Name + "  [" + text2 + " within " + RadiusNM.ToString("0") + "nm of " + text + text3 + "]";
		}
	}

	public WithinDistanceRule()
	{
		RadiusNM = 100.0;
		HubUnitNameOrGuid = "";
		HUBtTypeFilter = "";
		UnitTypeFilter = "";
		RequireCommCheck = false;
		rWeLrcoUhFP = false;
	}

	internal override void Apply(NetworkRuleExecutionContext execCtx, HashSet<ActiveUnit> networkedUnits)
	{
		ActiveUnit activeUnit = null;
		if (string.IsNullOrEmpty(HubUnitNameOrGuid))
		{
			{
				foreach (ActiveUnit unit in execCtx.Side.Units)
				{
					if (!unit.IsGroup && NetworkRule.HasWorkingComms(unit) && method_0(unit, execCtx, (Enum7)0))
					{
						WithinDistanceRule withinDistanceRule = new WithinDistanceRule();
						withinDistanceRule.Name = unit.Name + " " + base.Name;
						withinDistanceRule.Priority = base.Priority;
						withinDistanceRule.RadiusNM = RadiusNM;
						withinDistanceRule.UnitTypeFilter = UnitTypeFilter;
						withinDistanceRule.RequireCommCheck = RequireCommCheck;
						withinDistanceRule.CanClaimAlreadyNetworkedOverride = CanClaimAlreadyNetworked;
						withinDistanceRule.Reason = base.Reason;
						withinDistanceRule.Description = unit.Name + " " + base.Description;
						withinDistanceRule.HubUnitNameOrGuid = unit.ObjectID;
						withinDistanceRule.Apply(execCtx, networkedUnits);
					}
				}
				return;
			}
		}
		foreach (ActiveUnit unit2 in execCtx.Side.Units)
		{
			if (Operators.CompareString(unit2.Name, HubUnitNameOrGuid, false) == 0 || Operators.CompareString(unit2.ObjectID, HubUnitNameOrGuid, false) == 0)
			{
				activeUnit = unit2;
				break;
			}
		}
		if (activeUnit == null)
		{
			execCtx.AddLog("[WithinDistanceRule] hub \"" + HubUnitNameOrGuid + "\" not found, skipping");
			return;
		}
		if (activeUnit == null)
		{
			List<ActiveUnit> list = new List<ActiveUnit>();
			foreach (ActiveUnit unit3 in execCtx.Side.Units)
			{
				if (!unit3.IsGroup && NetworkRule.HasWorkingComms(unit3) && method_0(unit3, execCtx, (Enum7)1) && (CanClaimAlreadyNetworked || !networkedUnits.Contains(unit3)))
				{
					list.Add(unit3);
				}
			}
			HashSet<string> hashSet = new HashSet<string>();
			{
				foreach (ActiveUnit item in list)
				{
					if (hashSet.Contains(item.ObjectID))
					{
						continue;
					}
					List<ActiveUnit> list2 = new List<ActiveUnit>();
					list2.Add(item);
					hashSet.Add(item.ObjectID);
					foreach (ActiveUnit item2 in list)
					{
						if (!hashSet.Contains(item2.ObjectID) && NetworkRule.DistanceNM(item, item2) <= RadiusNM && (!RequireCommCheck || NetworkRule.CanCommunicate(item, item2)))
						{
							list2.Add(item2);
							hashSet.Add(item2.ObjectID);
						}
					}
					if (list2.Count <= 1)
					{
						continue;
					}
					execCtx.CreateNetwork(execCtx.Side, list2.Cast<Module_Unit.Unit>(), base.Reason, execCtx.Log, "distance mesh " + RadiusNM.ToString("0") + "nm (" + Conversions.ToString(list2.Count) + " units)", "");
					foreach (ActiveUnit item3 in list2)
					{
						networkedUnits.Add(item3);
					}
				}
				return;
			}
		}
		List<ActiveUnit> list3 = new List<ActiveUnit>();
		list3.Add(activeUnit);
		foreach (ActiveUnit unit4 in execCtx.Side.Units)
		{
			if (unit4 != activeUnit && NetworkRule.HasWorkingComms(unit4) && !unit4.IsGroup && method_0(unit4, execCtx, (Enum7)1) && (CanClaimAlreadyNetworked || !networkedUnits.Contains(unit4)) && NetworkRule.DistanceNM(activeUnit, unit4) <= RadiusNM && (!RequireCommCheck || NetworkRule.CanCommunicate(activeUnit, unit4)))
			{
				list3.Add(unit4);
			}
		}
		if (list3.Count <= 1)
		{
			return;
		}
		execCtx.CreateNetwork(execCtx.Side, list3.Cast<Module_Unit.Unit>(), base.Reason, execCtx.Log, "distance " + RadiusNM.ToString("0") + "nm around " + activeUnit.Name, "");
		foreach (ActiveUnit item4 in list3)
		{
			networkedUnits.Add(item4);
		}
	}

	private bool method_0(ActiveUnit activeUnit_0, NetworkRuleExecutionContext networkRuleExecutionContext_0, Enum7 enum7_0)
	{
		string text = ((enum7_0 == (Enum7)0) ? HUBtTypeFilter : UnitTypeFilter);
		if (string.IsNullOrEmpty(text))
		{
			return true;
		}
		if (Operators.CompareString(text, "none", false) != 0)
		{
			return text.ToLower() switch
			{
				"aircraft" => activeUnit_0.IsAircraft, 
				"aew" => networkRuleExecutionContext_0.IsAEW(activeUnit_0), 
				"tanker" => networkRuleExecutionContext_0.IsTanker(activeUnit_0), 
				"facility" => activeUnit_0.IsFacility, 
				"submarine" => activeUnit_0.IsSubmarine, 
				"ship" => activeUnit_0.IsShip, 
				_ => true, 
			};
		}
		return false;
	}

	public override void ToXML(XmlWriter writer)
	{
		writer.WriteStartElement("WithinDistanceRule");
		writer.WriteElementString("Name", base.Name);
		writer.WriteElementString("Priority", base.Priority.ToString());
		writer.WriteElementString("Enabled", base.Enabled.ToString());
		writer.WriteElementString("Description", base.Description);
		writer.WriteElementString("RadiusNM", RadiusNM.ToString());
		writer.WriteElementString("HubUnitNameOrGuid", HubUnitNameOrGuid);
		writer.WriteElementString("HUBtTypeFilter", HUBtTypeFilter);
		writer.WriteElementString("UnitTypeFilter", UnitTypeFilter);
		writer.WriteElementString("RequireCommCheck", RequireCommCheck.ToString());
		writer.WriteElementString("CanClaimOverride", rWeLrcoUhFP.ToString());
		writer.WriteEndElement();
	}

	public override void FromXML(XmlNode node)
	{
		base.Name = NetworkRule.XmlText(node, "Name", base.Name);
		base.Priority = NetworkRule.XmlInt(node, "Priority", 99);
		base.Enabled = NetworkRule.XmlBool(node, "Enabled", defaultValue: true);
		base.Description = NetworkRule.XmlText(node, "Description", "");
		RadiusNM = NetworkRule.XmlDouble(node, "RadiusNM", 100.0);
		HubUnitNameOrGuid = NetworkRule.XmlText(node, "HubUnitNameOrGuid", "");
		HUBtTypeFilter = NetworkRule.XmlText(node, "HUBtTypeFilter", "");
		UnitTypeFilter = NetworkRule.XmlText(node, "UnitTypeFilter", "");
		RequireCommCheck = NetworkRule.XmlBool(node, "RequireCommCheck", defaultValue: false);
		rWeLrcoUhFP = NetworkRule.XmlBool(node, "CanClaimOverride", defaultValue: false);
	}

	static WithinDistanceRule()
	{
		Class72.smethod_20();
	}
}
