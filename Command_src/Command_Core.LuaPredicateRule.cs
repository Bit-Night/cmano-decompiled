using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using Collections.Pooled;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class LuaPredicateRule : NetworkRule
{
	[CompilerGenerated]
	private string string_2;

	[CompilerGenerated]
	private int int_1;

	public string LuaBody
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

	public int MinUnitsPerGroup
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
			string[] array = LuaBody.Split(new char[1] { '\n' });
			string text = "";
			if (array.Length > 0)
			{
				text = array[0].Trim().Replace("--", "").Trim();
			}
			if (text.Length > 50)
			{
				text = text.Substring(0, 50) + "...";
			}
			return base.Name + "  [Lua: " + text + "]";
		}
	}

	public LuaPredicateRule()
	{
		LuaBody = "-- Return a string key to group units, or nil to skip\r\n-- 'unit'is the Command Lua unit wrapper (VP_GetUnit)\r\nreturn nil";
		MinUnitsPerGroup = 2;
	}

	internal override void Apply(NetworkRuleExecutionContext execCtx, HashSet<ActiveUnit> networkedUnits)
	{
		Dictionary<string, List<ActiveUnit>> dictionary = new Dictionary<string, List<ActiveUnit>>();
		PooledList<ActiveUnit>.Enumerator enumerator = execCtx.Side.Units.GetEnumerator();
		while (enumerator.MoveNext())
		{
			ActiveUnit current = enumerator.Current;
			if (!NetworkRule.HasWorkingComms(current) || current.IsGroup)
			{
				continue;
			}
			int num;
			if (!CanClaimAlreadyNetworked)
			{
				if (networkedUnits.Contains(current))
				{
					continue;
				}
				num = 5;
			}
			else
			{
				num = 5;
			}
			string[] array = new string[num];
			array[0] = "local unit = VP_GetUnit({guid='";
			array[1] = current.ObjectID;
			array[2] = "'})\r\nlocal function __predicate(unit)\r\n";
			array[3] = LuaBody;
			array[4] = "\r\nend\r\nreturn tostring(__predicate(unit))";
			string arg = string.Concat(array);
			string text = "";
			if (execCtx.ExecuteLua != null)
			{
				text = execCtx.ExecuteLua(arg);
			}
			if (!string.IsNullOrEmpty(text) && Operators.CompareString(text, "nil", false) != 0)
			{
				if (!dictionary.ContainsKey(text))
				{
					dictionary[text] = new List<ActiveUnit>();
				}
				dictionary[text].Add(current);
			}
		}
		Dictionary<string, List<ActiveUnit>>.Enumerator enumerator2 = dictionary.GetEnumerator();
		while (enumerator2.MoveNext())
		{
			KeyValuePair<string, List<ActiveUnit>> current2 = enumerator2.Current;
			if (current2.Value.Count >= MinUnitsPerGroup)
			{
				execCtx.AddLog("[LuaPredicateRule '" + base.Name + "'] creating network '" + current2.Key + "' with " + Conversions.ToString(current2.Value.Count) + " units");
				execCtx.CreateNetwork(execCtx.Side, current2.Value.Cast<Module_Unit.Unit>(), base.Reason, execCtx.Log, "lua rule '" + base.Name + "' key='" + current2.Key + "'", current2.Key);
				List<ActiveUnit>.Enumerator enumerator3 = current2.Value.GetEnumerator();
				while (enumerator3.MoveNext())
				{
					ActiveUnit current3 = enumerator3.Current;
					networkedUnits.Add(current3);
				}
			}
			else
			{
				execCtx.AddLog("[LuaPredicateRule '" + base.Name + "'] skipped key '" + current2.Key + "' — only " + Conversions.ToString(current2.Value.Count) + " units, minimum is " + Conversions.ToString(MinUnitsPerGroup));
			}
		}
	}

	public override void ToXML(XmlWriter writer)
	{
		writer.WriteStartElement("LuaPredicateRule");
		writer.WriteElementString("Name", base.Name);
		writer.WriteElementString("Priority", base.Priority.ToString());
		writer.WriteElementString("Enabled", base.Enabled.ToString());
		writer.WriteElementString("Description", base.Description);
		writer.WriteElementString("MinUnitsPerGroup", MinUnitsPerGroup.ToString());
		writer.WriteCData(LuaBody);
		writer.WriteEndElement();
	}

	public override void FromXML(XmlNode node)
	{
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Invalid comparison between Unknown and I4
		base.Name = NetworkRule.XmlText(node, "Name", base.Name);
		base.Priority = NetworkRule.XmlInt(node, "Priority", 99);
		base.Enabled = NetworkRule.XmlBool(node, "Enabled", defaultValue: true);
		base.Description = NetworkRule.XmlText(node, "Description", "");
		MinUnitsPerGroup = NetworkRule.XmlInt(node, "MinUnitsPerGroup", 2);
		IEnumerator enumerator = node.ChildNodes.GetEnumerator();
		try
		{
			XmlNode val;
			do
			{
				if (enumerator.MoveNext())
				{
					val = (XmlNode)enumerator.Current;
					continue;
				}
				return;
			}
			while ((int)val.NodeType != 4);
			LuaBody = val.Value;
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	static LuaPredicateRule()
	{
		Class72.smethod_20();
	}
}
