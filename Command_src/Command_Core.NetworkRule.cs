using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;

namespace Command_Core;

public abstract class NetworkRule
{
	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private bool bool_0;

	[CompilerGenerated]
	private CommNetwork.NetworkCreationReason networkCreationReason_0;

	[CompilerGenerated]
	private string string_1;

	public string Name
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public int Priority
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public bool Enabled
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public CommNetwork.NetworkCreationReason Reason
	{
		[CompilerGenerated]
		get
		{
			return networkCreationReason_0;
		}
		[CompilerGenerated]
		set
		{
			networkCreationReason_0 = value;
		}
	}

	public string Description
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
		[CompilerGenerated]
		set
		{
			string_1 = value;
		}
	}

	public virtual bool CanClaimAlreadyNetworked => false;

	public virtual string Summary => Name;

	protected NetworkRule()
	{
		Name = "Unnamed rule";
		Priority = 99;
		Enabled = true;
		Reason = CommNetwork.NetworkCreationReason.Generic;
		Description = "";
	}

	internal abstract void Apply(NetworkRuleExecutionContext execCtx, HashSet<ActiveUnit> networkedUnits);

	public abstract void ToXML(XmlWriter writer);

	public abstract void FromXML(XmlNode node);

	protected static bool HasWorkingComms(ActiveUnit u)
	{
		if (u.Comms_ReadOnly == null)
		{
			return false;
		}
		return u.Comms_ReadOnly.Count() > 0;
	}

	protected static double DistanceNM(ActiveUnit a, ActiveUnit b)
	{
		return a.RangeToUnit_Horiz(b, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
	}

	protected static bool CanCommunicate(ActiveUnit sender, ActiveUnit receiver)
	{
		return ActiveUnit_CommStuff.CommDeviceToConnectToThisUnit(sender, sender.Comms_ReadOnly, receiver, IgnoreChannelCount: false, null, null, onlyOneRequired: true).EvaluationEnum == ActiveUnit_CommStuff.CommConnectionChecklistEvaluation.OK;
	}

	protected static string XmlText(XmlNode node, string elementName, string defaultValue)
	{
		XmlNode val = node.SelectSingleNode(elementName);
		if (val == null)
		{
			return defaultValue;
		}
		return val.InnerText;
	}

	protected static int XmlInt(XmlNode node, string elementName, int defaultValue)
	{
		if (int.TryParse(XmlText(node, elementName, defaultValue.ToString()), out var result))
		{
			return result;
		}
		return defaultValue;
	}

	protected static bool XmlBool(XmlNode node, string elementName, bool defaultValue)
	{
		if (bool.TryParse(XmlText(node, elementName, defaultValue.ToString()), out var result))
		{
			return result;
		}
		return defaultValue;
	}

	protected static double XmlDouble(XmlNode node, string elementName, double defaultValue)
	{
		if (!double.TryParse(XmlText(node, elementName, defaultValue.ToString()), out var result))
		{
			return defaultValue;
		}
		return result;
	}

	static NetworkRule()
	{
		Class72.smethod_20();
	}
}
