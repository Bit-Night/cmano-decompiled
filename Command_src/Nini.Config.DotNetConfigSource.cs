using System;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Xml;

namespace Nini.Config;

public class DotNetConfigSource : ConfigSourceBase
{
	private string[] string_0;

	private XmlDocument xmlDocument_0;

	private string string_1;

	public string SavePath => string_1;

	public DotNetConfigSource(string[] sections)
	{
		string_0 = sections;
		Load();
	}

	public DotNetConfigSource()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		xmlDocument_0 = new XmlDocument();
		xmlDocument_0.LoadXml("<configuration><configSections/></configuration>");
		method_3(xmlDocument_0);
	}

	public DotNetConfigSource(string path)
	{
		Load(path);
	}

	public DotNetConfigSource(XmlReader reader)
	{
		Load(reader);
	}

	public void Load(string path)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		string_1 = path;
		xmlDocument_0 = new XmlDocument();
		xmlDocument_0.Load(string_1);
		method_3(xmlDocument_0);
	}

	public void Load(XmlReader reader)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		xmlDocument_0 = new XmlDocument();
		xmlDocument_0.Load(reader);
		method_3(xmlDocument_0);
	}

	public override void Save()
	{
		if (!method_13())
		{
			throw new ArgumentException("Source cannot be saved in this state");
		}
		method_2();
		xmlDocument_0.Save(string_1);
		base.Save();
	}

	public void Save(string path)
	{
		if (!method_13())
		{
			throw new ArgumentException("Source cannot be saved in this state");
		}
		string_1 = path;
		Save();
	}

	public void Save(TextWriter writer)
	{
		if (!method_13())
		{
			throw new ArgumentException("Source cannot be saved in this state");
		}
		method_2();
		xmlDocument_0.Save(writer);
		string_1 = null;
		OnSaved(new EventArgs());
	}

	public void Save(Stream stream)
	{
		if (!method_13())
		{
			throw new ArgumentException("Source cannot be saved in this state");
		}
		method_2();
		xmlDocument_0.Save(stream);
		string_1 = null;
		OnSaved(new EventArgs());
	}

	public override void Reload()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		if (string_1 == null)
		{
			throw new ArgumentException("Error reloading: You must have the loaded the source from a file");
		}
		xmlDocument_0 = new XmlDocument();
		xmlDocument_0.Load(string_1);
		method_15();
		base.Reload();
	}

	public override string ToString()
	{
		method_2();
		StringWriter stringWriter = new StringWriter();
		xmlDocument_0.Save((TextWriter)stringWriter);
		return stringWriter.ToString();
	}

	public static string GetFullConfigPath()
	{
		return Assembly.GetCallingAssembly().Location + ".config";
	}

	private void method_2()
	{
		lJsyOhxcpVN();
		foreach (IConfig config in base.Configs)
		{
			string[] keys = config.GetKeys();
			method_7(config.Name);
			XmlNode val = method_14(config.Name);
			int num;
			if (val != null)
			{
				num = 0;
			}
			else
			{
				val = method_12(config.Name);
				num = 0;
			}
			for (int i = num; i < keys.Length; i++)
			{
				method_8(val, keys[i], config.Get(keys[i]));
			}
		}
	}

	private void Load()
	{
		Merge(this);
		for (int i = 0; i < string_0.Length; i++)
		{
			method_11(string_0[i], (NameValueCollection)ConfigurationSettings.GetConfig(string_0[i]));
		}
	}

	private void method_3(XmlDocument xmlDocument_1)
	{
		base.Configs.Clear();
		Merge(this);
		if (((XmlNode)xmlDocument_1.DocumentElement).Name != "configuration")
		{
			throw new ArgumentException("Did not find configuration node");
		}
		method_4((XmlNode)(object)xmlDocument_1.DocumentElement);
	}

	private void method_4(XmlNode xmlNode_0)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Invalid comparison between Unknown and I4
		method_5(xmlNode_0, "appSettings");
		XmlNode val = WsqyOfgcyGb(xmlNode_0, "configSections");
		if (val == null)
		{
			return;
		}
		ConfigBase configBase = null;
		foreach (XmlNode childNode in val.ChildNodes)
		{
			XmlNode val2 = childNode;
			if ((int)val2.NodeType == 1 && val2.Name == "section")
			{
				configBase = new ConfigBase(((XmlNode)val2.Attributes["name"]).Value, this);
				base.Configs.Add(configBase);
				method_6(xmlNode_0, configBase);
			}
		}
	}

	private void method_5(XmlNode xmlNode_0, string string_2)
	{
		XmlNode val = WsqyOfgcyGb(xmlNode_0, string_2);
		ConfigBase configBase = null;
		if (val != null)
		{
			configBase = new ConfigBase(val.Name, this);
			base.Configs.Add(configBase);
			method_6(xmlNode_0, configBase);
		}
	}

	private void method_6(XmlNode xmlNode_0, ConfigBase configBase_0)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Invalid comparison between Unknown and I4
		foreach (XmlNode childNode in WsqyOfgcyGb(xmlNode_0, configBase_0.Name).ChildNodes)
		{
			XmlNode val = childNode;
			if ((int)val.NodeType == 1 && val.Name == "add")
			{
				configBase_0.Add(((XmlNode)val.Attributes["key"]).Value, ((XmlNode)val.Attributes["value"]).Value);
			}
		}
	}

	private void lJsyOhxcpVN()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Invalid comparison between Unknown and I4
		XmlAttribute val = null;
		XmlNode val2 = method_14("configSections");
		if (val2 == null)
		{
			return;
		}
		foreach (XmlNode childNode in val2.ChildNodes)
		{
			XmlNode val3 = childNode;
			if ((int)val3.NodeType != 1 || !(val3.Name == "section"))
			{
				continue;
			}
			val = val3.Attributes["name"];
			if (val != null)
			{
				if (base.Configs[((XmlNode)val).Value] == null)
				{
					val3.ParentNode.RemoveChild(val3);
					XmlNode val4 = method_14(((XmlNode)val).Value);
					if (val4 != null)
					{
						((XmlNode)xmlDocument_0.DocumentElement).RemoveChild(val4);
					}
				}
				continue;
			}
			throw new ArgumentException("Section name attribute not found");
		}
	}

	private void method_7(string string_2)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Invalid comparison between Unknown and I4
		XmlNode val = method_14(string_2);
		XmlAttribute val2 = null;
		if (val == null)
		{
			return;
		}
		foreach (XmlNode childNode in val.ChildNodes)
		{
			XmlNode val3 = childNode;
			if ((int)val3.NodeType == 1 && val3.Name == "add")
			{
				val2 = val3.Attributes["key"];
				if (val2 == null)
				{
					throw new ArgumentException("Key attribute not found in node");
				}
				if (base.Configs[string_2].Get(((XmlNode)val2).Value) == null)
				{
					val.RemoveChild(val3);
				}
			}
		}
	}

	private void method_8(XmlNode xmlNode_0, string string_2, string string_3)
	{
		XmlNode val = method_9(xmlNode_0, string_2);
		if (val != null)
		{
			((XmlNode)val.Attributes["value"]).Value = string_3;
		}
		else
		{
			method_10(xmlNode_0, string_2, string_3);
		}
	}

	private XmlNode method_9(XmlNode xmlNode_0, string string_2)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Invalid comparison between Unknown and I4
		XmlNode result = null;
		foreach (XmlNode childNode in xmlNode_0.ChildNodes)
		{
			XmlNode val = childNode;
			if ((int)val.NodeType == 1 && val.Name == "add" && ((XmlNode)val.Attributes["key"]).Value == string_2)
			{
				result = val;
				break;
			}
		}
		return result;
	}

	private void method_10(XmlNode xmlNode_0, string string_2, string string_3)
	{
		XmlNode val = (XmlNode)(object)xmlDocument_0.CreateElement("add");
		XmlAttribute val2 = xmlDocument_0.CreateAttribute("key");
		XmlAttribute val3 = xmlDocument_0.CreateAttribute("value");
		((XmlNode)val2).Value = string_2;
		((XmlNode)val3).Value = string_3;
		val.Attributes.Append(val2);
		val.Attributes.Append(val3);
		xmlNode_0.AppendChild(val);
	}

	private void method_11(string string_2, NameValueCollection nameValueCollection_0)
	{
		ConfigBase configBase = new ConfigBase(string_2, this);
		if (nameValueCollection_0 == null)
		{
			throw new ArgumentException("Section was not found");
		}
		if (nameValueCollection_0 != null)
		{
			for (int i = 0; i < nameValueCollection_0.Count; i++)
			{
				configBase.Add(nameValueCollection_0.Keys[i], nameValueCollection_0[i]);
			}
			base.Configs.Add(configBase);
		}
	}

	private XmlNode method_12(string string_2)
	{
		XmlNode val = (XmlNode)(object)xmlDocument_0.CreateElement("section");
		XmlAttribute val2 = xmlDocument_0.CreateAttribute("name");
		((XmlNode)val2).Value = string_2;
		val.Attributes.Append(val2);
		val2 = xmlDocument_0.CreateAttribute("type");
		((XmlNode)val2).Value = "System.Configuration.NameValueSectionHandler";
		val.Attributes.Append(val2);
		method_14("configSections").AppendChild(val);
		XmlNode val3 = (XmlNode)(object)xmlDocument_0.CreateElement(string_2);
		((XmlNode)xmlDocument_0.DocumentElement).AppendChild(val3);
		return val3;
	}

	private bool method_13()
	{
		if (string_1 == null)
		{
			return xmlDocument_0 != null;
		}
		return true;
	}

	private XmlNode WsqyOfgcyGb(XmlNode xmlNode_0, string string_2)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Invalid comparison between Unknown and I4
		XmlNode result = null;
		foreach (XmlNode childNode in xmlNode_0.ChildNodes)
		{
			XmlNode val = childNode;
			if ((int)val.NodeType == 1 && val.Name == string_2)
			{
				result = val;
				break;
			}
		}
		return result;
	}

	private XmlNode method_14(string string_2)
	{
		return WsqyOfgcyGb((XmlNode)(object)xmlDocument_0.DocumentElement, string_2);
	}

	private void method_15()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Invalid comparison between Unknown and I4
		method_16();
		XmlNode val = method_14("configSections");
		if (val == null)
		{
			return;
		}
		foreach (XmlNode childNode in val.ChildNodes)
		{
			XmlNode val2 = childNode;
			if ((int)val2.NodeType == 1 && val2.Name == "section")
			{
				string value = ((XmlNode)val2.Attributes["name"]).Value;
				IConfig config = base.Configs[value];
				if (config == null)
				{
					config = new ConfigBase(value, this);
					base.Configs.Add(config);
				}
				method_17(config);
			}
		}
	}

	private void method_16()
	{
		IConfig config = null;
		for (int num = base.Configs.Count - 1; num > -1; num--)
		{
			config = base.Configs[num];
			if (method_14(config.Name) == null)
			{
				base.Configs.Remove(config);
			}
		}
	}

	private void method_17(IConfig iconfig_0)
	{
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Invalid comparison between Unknown and I4
		XmlNode val = method_14(iconfig_0.Name);
		string[] keys = iconfig_0.GetKeys();
		foreach (string text in keys)
		{
			if (method_9(val, text) == null)
			{
				iconfig_0.Remove(text);
			}
		}
		foreach (XmlNode childNode in val.ChildNodes)
		{
			XmlNode val2 = childNode;
			if ((int)val2.NodeType == 1 && val2.Name == "add")
			{
				iconfig_0.Set(((XmlNode)val2.Attributes["key"]).Value, ((XmlNode)val2.Attributes["value"]).Value);
			}
		}
	}

	static DotNetConfigSource()
	{
		Class72.smethod_20();
	}
}
