using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace CommandNetcode.Merge;

public sealed class CompartmentMerge : IScenarioMerge
{
	private class Class5
	{
		public XDocument xdocument_0;

		public string string_0;

		public string string_1;

		public string string_2;

		static Class5()
		{
			Class72.smethod_20();
		}
	}

	public string MergeName()
	{
		return "Compartment Merge";
	}

	public ScenarioMergeOutput MergeScenarioXML(ScenarioMergeInput input)
	{
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Expected O, but got Unknown
		List<Class5> list = new List<Class5>();
		foreach (TeamMergeInput teamMergeInput in input.TeamMergeInputs)
		{
			if (teamMergeInput.PlayerMergeInputs.Count() != 0)
			{
				Class5 item = new Class5
				{
					string_1 = teamMergeInput.SideGuid,
					string_0 = teamMergeInput.SideName,
					string_2 = teamMergeInput.PlayerMergeInputs.First().PlayerName,
					xdocument_0 = XDocument.Parse(teamMergeInput.PlayerMergeInputs.First().ScenXML)
				};
				list.Add(item);
			}
		}
		XDocument val = XDocument.Parse(input.ScenXML);
		XElement val2 = ((XContainer)val.Root).Element(XName.op_Implicit("Sides"));
		XElement val3 = ((XContainer)val.Root).Element(XName.op_Implicit("ActiveUnits"));
		foreach (Class5 class5_0 in list)
		{
			XElement val4 = ((XContainer)((XContainer)class5_0.xdocument_0.Root).Element(XName.op_Implicit("Sides"))).Elements().First((XElement F) => ((XContainer)F).Element(XName.op_Implicit("Name")).Value == class5_0.string_0);
			((XNode)((XContainer)val2).Elements().FirstOrDefault((Func<XElement, bool>)((XElement F) => ((XContainer)F).Element(XName.op_Implicit("Name")).Value == class5_0.string_0))).ReplaceWith((object)val4);
			foreach (XElement item2 in ((XContainer)((XContainer)class5_0.xdocument_0.Root).Element(XName.op_Implicit("ActiveUnits"))).Elements().Where(delegate(XElement F)
			{
				XElement obj = ((XContainer)F).Element(XName.op_Implicit("Side"));
				return ((obj != null) ? obj.Value : null) == class5_0.string_0;
			}))
			{
				string string_0 = ((XContainer)item2).Element(XName.op_Implicit("ID")).Value;
				XElement val5 = ((XContainer)val3).Elements().FirstOrDefault((Func<XElement, bool>)((XElement F) => ((XContainer)F).Element(XName.op_Implicit("ID")).Value == string_0));
				if (val5 == null)
				{
					((XContainer)val3).Add((object)item2);
				}
				else
				{
					((XNode)val5).ReplaceWith((object)item2);
				}
			}
		}
		XElement val6 = ((XContainer)val.Root).Element(XName.op_Implicit("Groups"));
		foreach (XElement xelement_0 in from F in ((XContainer)val3).Elements()
			where F.Name == XName.op_Implicit("Group")
			select F)
		{
			if (!((XContainer)val6).Elements().Any((XElement F) => F.Value == ((XContainer)xelement_0).Element(XName.op_Implicit("ID")).Value))
			{
				XElement val7 = new XElement(XName.op_Implicit("ID"));
				val7.Value = ((XContainer)xelement_0).Element(XName.op_Implicit("ID")).Value;
				((XContainer)val6).Add((object)val7);
			}
		}
		return new ScenarioMergeOutput
		{
			ScenXML = ((object)val).ToString(),
			Messages = "Successful merge. Merged data from players " + string.Join(", ", list.Select((Class5 F) => F.string_2))
		};
	}

	static CompartmentMerge()
	{
		Class72.smethod_20();
	}
}
