using System;
using System.IO;
using Nini.Ini;

namespace Nini.Config;

public class IniConfigSource : ConfigSourceBase
{
	private IniDocument iniDocument_0;

	private string string_0;

	private bool hRayOzTwdrZ = true;

	public bool CaseSensitive
	{
		get
		{
			return hRayOzTwdrZ;
		}
		set
		{
			hRayOzTwdrZ = value;
		}
	}

	public string SavePath => string_0;

	public IniConfigSource()
	{
		iniDocument_0 = new IniDocument();
	}

	public IniConfigSource(string filePath)
	{
		Load(filePath);
	}

	public IniConfigSource(TextReader reader)
	{
		Load(reader);
	}

	public IniConfigSource(IniDocument document)
	{
		Load(document);
	}

	public IniConfigSource(Stream stream)
	{
		Load(stream);
	}

	public void Load(string filePath)
	{
		Load(new StreamReader(filePath));
		string_0 = filePath;
	}

	public void Load(TextReader reader)
	{
		Load(new IniDocument(reader));
	}

	public void Load(IniDocument document)
	{
		base.Configs.Clear();
		Merge(this);
		iniDocument_0 = document;
		Load();
	}

	public void Load(Stream stream)
	{
		Load(new StreamReader(stream));
	}

	public override void Save()
	{
		if (!method_7())
		{
			throw new ArgumentException("Source cannot be saved in this state");
		}
		method_2();
		iniDocument_0.Save(string_0);
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
		iniDocument_0.Save(writer);
		string_0 = null;
		OnSaved(new EventArgs());
	}

	public void Save(Stream stream)
	{
		method_2();
		iniDocument_0.Save(stream);
		string_0 = null;
		OnSaved(new EventArgs());
	}

	public override void Reload()
	{
		if (string_0 == null)
		{
			throw new ArgumentException("Error reloading: You must have the loaded the source from a file");
		}
		iniDocument_0 = new IniDocument(string_0);
		method_4();
		base.Reload();
	}

	public override string ToString()
	{
		method_2();
		StringWriter stringWriter = new StringWriter();
		iniDocument_0.Save(stringWriter);
		return stringWriter.ToString();
	}

	private void method_2()
	{
		method_3();
		foreach (IConfig config in base.Configs)
		{
			string[] keys = config.GetKeys();
			if (iniDocument_0.Sections[config.Name] == null)
			{
				IniSection section = new IniSection(config.Name);
				iniDocument_0.Sections.Add(section);
			}
			wndyOxPtnTA(config.Name);
			for (int i = 0; i < keys.Length; i++)
			{
				iniDocument_0.Sections[config.Name].Set(keys[i], config.Get(keys[i]));
			}
		}
	}

	private void method_3()
	{
		IniSection iniSection = null;
		for (int i = 0; i < iniDocument_0.Sections.Count; i++)
		{
			iniSection = iniDocument_0.Sections[i];
			if (base.Configs[iniSection.Name] == null)
			{
				iniDocument_0.Sections.Remove(iniSection.Name);
			}
		}
	}

	private void wndyOxPtnTA(string string_1)
	{
		IniSection iniSection = iniDocument_0.Sections[string_1];
		if (iniSection == null)
		{
			return;
		}
		string[] keys = iniSection.GetKeys();
		foreach (string key in keys)
		{
			if (base.Configs[string_1].Get(key) == null)
			{
				iniSection.Remove(key);
			}
		}
	}

	private void Load()
	{
		IniConfig iniConfig = null;
		IniSection iniSection = null;
		IniItem iniItem = null;
		for (int i = 0; i < iniDocument_0.Sections.Count; i++)
		{
			iniSection = iniDocument_0.Sections[i];
			iniConfig = new IniConfig(iniSection.Name, this);
			for (int j = 0; j < iniSection.ItemCount; j++)
			{
				iniItem = iniSection.GetItem(j);
				if (iniItem.Type == IniType.Key)
				{
					iniConfig.Add(iniItem.Name, iniItem.Value);
				}
			}
			base.Configs.Add(iniConfig);
		}
	}

	private void method_4()
	{
		method_5();
		IniSection iniSection = null;
		for (int i = 0; i < iniDocument_0.Sections.Count; i++)
		{
			iniSection = iniDocument_0.Sections[i];
			IConfig config = base.Configs[iniSection.Name];
			if (config == null)
			{
				config = new ConfigBase(iniSection.Name, this);
				base.Configs.Add(config);
			}
			method_6(config);
		}
	}

	private void method_5()
	{
		IConfig config = null;
		for (int num = base.Configs.Count - 1; num > -1; num--)
		{
			config = base.Configs[num];
			if (iniDocument_0.Sections[config.Name] == null)
			{
				base.Configs.Remove(config);
			}
		}
	}

	private void method_6(IConfig iconfig_0)
	{
		IniSection iniSection = iniDocument_0.Sections[iconfig_0.Name];
		string[] keys = iconfig_0.GetKeys();
		foreach (string key in keys)
		{
			if (!iniSection.Contains(key))
			{
				iconfig_0.Remove(key);
			}
		}
		string[] keys2 = iniSection.GetKeys();
		for (int j = 0; j < keys2.Length; j++)
		{
			string key2 = keys2[j];
			iconfig_0.Set(key2, iniSection.GetItem(j).Value);
		}
	}

	private bool method_7()
	{
		return string_0 != null;
	}

	static IniConfigSource()
	{
		Class72.smethod_20();
	}
}
