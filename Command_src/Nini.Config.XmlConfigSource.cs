using System;
using System.Collections;
using System.IO;
using System.Xml;

namespace Nini.Config;

public class XmlConfigSource : ConfigSourceBase
{
	private XmlDocument xmlDocument_0;

	private string string_0;

	public string SavePath => string_0;

	public XmlConfigSource()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		xmlDocument_0 = new XmlDocument();
		xmlDocument_0.LoadXml("<Nini/>");
		method_5(xmlDocument_0);
	}

	public XmlConfigSource(string path)
	{
		Load(path);
	}

	public XmlConfigSource(XmlReader reader)
	{
		Load(reader);
	}

	public void Load(string path)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		string_0 = path;
		xmlDocument_0 = new XmlDocument();
		xmlDocument_0.Load(path);
		method_5(xmlDocument_0);
	}

	public void Load(XmlReader reader)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		xmlDocument_0 = new XmlDocument();
		xmlDocument_0.Load(reader);
		method_5(xmlDocument_0);
	}

	public override void Save()
	{
		if (!method_13())
		{
			throw new ArgumentException("Source cannot be saved in this state");
		}
		method_2();
		xmlDocument_0.Save(string_0);
		base.Save();
	}

	public void Save(string path)
	{
		string_0 = path;
		Save();
	}

	public void Save(TextWriter writer)
	{
		method_2();
		xmlDocument_0.Save(writer);
		string_0 = null;
		OnSaved(new EventArgs());
	}

	public void Save(Stream stream)
	{
		method_2();
		xmlDocument_0.Save(stream);
		string_0 = null;
		OnSaved(new EventArgs());
	}

	public override void Reload()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		if (string_0 == null)
		{
			throw new ArgumentException("Error reloading: You must have the loaded the source from a file");
		}
		xmlDocument_0 = new XmlDocument();
		xmlDocument_0.Load(string_0);
		pkDyAkqkGoA();
		base.Reload();
	}

	public override string ToString()
	{
		method_2();
		StringWriter stringWriter = new StringWriter();
		xmlDocument_0.Save((TextWriter)stringWriter);
		return stringWriter.ToString();
	}

	private void method_2()
	{
		method_3();
		foreach (IConfig config in base.Configs)
		{
			string[] keys = config.GetKeys();
			XmlNode val = method_11(config.Name);
			if (val == null)
			{
				val = method_10(config.Name);
				((XmlNode)xmlDocument_0.DocumentElement).AppendChild(val);
			}
			method_4(config.Name);
			for (int i = 0; i < keys.Length; i++)
			{
				method_8(val, keys[i], config.Get(keys[i]));
			}
		}
	}

	private void method_3()
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Invalid comparison between Unknown and I4
		XmlAttribute val = null;
		foreach (XmlNode childNode in ((XmlNode)xmlDocument_0.DocumentElement).ChildNodes)
		{
			XmlNode val2 = childNode;
			if ((int)val2.NodeType == 1 && val2.Name == "Section")
			{
				val = val2.Attributes["Name"];
				if (val == null)
				{
					throw new ArgumentException("Section name attribute not found");
				}
				if (base.Configs[((XmlNode)val).Value] == null)
				{
					((XmlNode)xmlDocument_0.DocumentElement).RemoveChild(val2);
				}
			}
		}
	}

	private void method_4(string string_1)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Invalid comparison between Unknown and I4
		XmlNode val = method_11(string_1);
		XmlAttribute val2 = null;
		if (val == null)
		{
			return;
		}
		foreach (XmlNode childNode in val.ChildNodes)
		{
			XmlNode val3 = childNode;
			if ((int)val3.NodeType == 1 && val3.Name == "Key")
			{
				val2 = val3.Attributes["Name"];
				if (val2 == null)
				{
					throw new ArgumentException("Name attribute not found in key");
				}
				if (base.Configs[string_1].Get(((XmlNode)val2).Value) == null)
				{
					val.RemoveChild(val3);
				}
			}
		}
	}

	private void method_5(XmlDocument xmlDocument_1)
	{
		base.Configs.Clear();
		Merge(this);
		if (((XmlNode)xmlDocument_1.DocumentElement).Name != "Nini")
		{
			throw new ArgumentException("Did not find Nini XML root node");
		}
		method_6((XmlNode)(object)xmlDocument_1.DocumentElement);
	}

	private void method_6(XmlNode xmlNode_0)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Invalid comparison between Unknown and I4
		ConfigBase configBase = null;
		foreach (XmlNode childNode in xmlNode_0.ChildNodes)
		{
			XmlNode val = childNode;
			if ((int)val.NodeType == 1 && val.Name == "Section")
			{
				configBase = new ConfigBase(((XmlNode)val.Attributes["Name"]).Value, this);
				base.Configs.Add(configBase);
				method_7(val, configBase);
			}
		}
	}

	private void method_7(XmlNode xmlNode_0, ConfigBase configBase_0)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Invalid comparison between Unknown and I4
		foreach (XmlNode childNode in xmlNode_0.ChildNodes)
		{
			XmlNode val = childNode;
			if ((int)val.NodeType == 1 && val.Name == "Key")
			{
				configBase_0.Add(((XmlNode)val.Attributes["Name"]).Value, ((XmlNode)val.Attributes["Value"]).Value);
			}
		}
	}

	private void method_8(XmlNode xmlNode_0, string string_1, string string_2)
	{
		XmlNode val = method_12(xmlNode_0, string_1);
		if (val != null)
		{
			((XmlNode)val.Attributes["Value"]).Value = string_2;
		}
		else
		{
			method_9(xmlNode_0, string_1, string_2);
		}
	}

	private void method_9(XmlNode xmlNode_0, string string_1, string string_2)
	{
		XmlNode val = (XmlNode)(object)xmlDocument_0.CreateElement("Key");
		XmlAttribute val2 = xmlDocument_0.CreateAttribute("Name");
		XmlAttribute val3 = xmlDocument_0.CreateAttribute("Value");
		((XmlNode)val2).Value = string_1;
		((XmlNode)val3).Value = string_2;
		val.Attributes.Append(val2);
		val.Attributes.Append(val3);
		xmlNode_0.AppendChild(val);
	}

	private XmlNode method_10(string string_1)
	{
		XmlElement obj = xmlDocument_0.CreateElement("Section");
		XmlAttribute val = xmlDocument_0.CreateAttribute("Name");
		((XmlNode)val).Value = string_1;
		((XmlNode)obj).Attributes.Append(val);
		return (XmlNode)(object)obj;
	}

	private XmlNode method_11(string string_1)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Invalid comparison between Unknown and I4
		XmlNode result = null;
		foreach (XmlNode childNode in ((XmlNode)xmlDocument_0.DocumentElement).ChildNodes)
		{
			XmlNode val = childNode;
			if ((int)val.NodeType == 1 && val.Name == "Section" && ((XmlNode)val.Attributes["Name"]).Value == string_1)
			{
				result = val;
				break;
			}
		}
		return result;
	}

	private XmlNode method_12(XmlNode xmlNode_0, string string_1)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Invalid comparison between Unknown and I4
		XmlNode result = null;
		IEnumerator enumerator = xmlNode_0.ChildNodes.GetEnumerator();
		while (enumerator.MoveNext())
		{
			XmlNode val = (XmlNode)enumerator.Current;
			if ((int)val.NodeType == 1 && val.Name == "Key" && ((XmlNode)val.Attributes["Name"]).Value == string_1)
			{
				result = val;
				break;
			}
		}
		return result;
	}

	private bool method_13()
	{
		if (string_0 == null)
		{
			return false;
		}
		return xmlDocument_0 != null;
	}

	private void pkDyAkqkGoA()
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Invalid comparison between Unknown and I4
		method_14();
		foreach (XmlNode childNode in ((XmlNode)xmlDocument_0.DocumentElement).ChildNodes)
		{
			XmlNode val = childNode;
			if ((int)val.NodeType == 1 && val.Name == "Section")
			{
				string value = ((XmlNode)val.Attributes["Name"]).Value;
				IConfig config = base.Configs[value];
				if (config == null)
				{
					config = new ConfigBase(value, this);
					base.Configs.Add(config);
				}
				method_15(config);
			}
		}
	}

	private void method_14()
	{
		IConfig config = null;
		for (int num = base.Configs.Count - 1; num > -1; num--)
		{
			config = base.Configs[num];
			if (method_11(config.Name) == null)
			{
				base.Configs.Remove(config);
			}
		}
	}

	private void method_15(IConfig iconfig_0)
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Invalid comparison between Unknown and I4
		XmlNode val = method_11(iconfig_0.Name);
		string[] keys = iconfig_0.GetKeys();
		foreach (string text in keys)
		{
			if (method_12(val, text) == null)
			{
				iconfig_0.Remove(text);
			}
		}
		foreach (XmlNode childNode in val.ChildNodes)
		{
			XmlNode val2 = childNode;
			if ((int)val2.NodeType == 1 && val2.Name == "Key")
			{
				iconfig_0.Set(((XmlNode)val2.Attributes["Name"]).Value, ((XmlNode)val2.Attributes["Value"]).Value);
			}
		}
	}

	static XmlConfigSource()
	{
		Class72.smethod_20();
	}
}
