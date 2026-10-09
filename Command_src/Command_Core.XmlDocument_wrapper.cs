using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace Command_Core;

public class XmlDocument_wrapper
{
	private XmlDocument xmlDocument_0;

	private Dictionary<string, XmlNode> dictionary_0;

	private StringBuilder stringBuilder_0;

	public XmlDocument_wrapper()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		xmlDocument_0 = new XmlDocument();
		dictionary_0 = new Dictionary<string, XmlNode>(StringComparer.OrdinalIgnoreCase);
		stringBuilder_0 = new StringBuilder();
	}

	internal void LoadXml(string string_0)
	{
		string_0 = Regex.Replace(string_0, "(<DET>.*?</DET>)", [SpecialName] (Match m) => m.Value.Replace("&", "&amp;"), RegexOptions.Singleline);
		xmlDocument_0.LoadXml(string_0);
		method_0();
	}

	private void method_0()
	{
		dictionary_0.Clear();
		method_1((XmlNode)(object)xmlDocument_0.DocumentElement, "/" + xmlDocument_0.DocumentElement.Name);
	}

	private void method_1(XmlNode xmlNode_0, string string_0)
	{
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Invalid comparison between Unknown and I4
		if (!dictionary_0.ContainsKey(string_0))
		{
			dictionary_0[string_0] = xmlNode_0;
		}
		stringBuilder_0.Clear();
		stringBuilder_0.Append("/").Append(xmlNode_0.Name);
		string key = stringBuilder_0.ToString();
		if (!dictionary_0.ContainsKey(key))
		{
			dictionary_0[key] = xmlNode_0;
		}
		for (XmlNode val = xmlNode_0.FirstChild; val != null; val = val.NextSibling)
		{
			if ((int)val.NodeType == 1)
			{
				stringBuilder_0.Clear();
				stringBuilder_0.Append(string_0).Append("/").Append(val.Name);
				method_1(val, stringBuilder_0.ToString());
			}
		}
	}

	internal XmlNode SelectSingleNode(Scenario theScen, string Path, string Node)
	{
		string key = Path + Node;
		XmlNode value = null;
		if (dictionary_0.TryGetValue(key, out value))
		{
			return value;
		}
		int num = Node.LastIndexOf('/');
		string key2 = ((num <= 0) ? Node : Node.Substring(num));
		dictionary_0.TryGetValue(key2, out value);
		return value;
	}

	static XmlDocument_wrapper()
	{
		Class72.smethod_20();
	}
}
