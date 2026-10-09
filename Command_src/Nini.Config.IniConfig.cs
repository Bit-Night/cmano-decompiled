namespace Nini.Config;

public class IniConfig : ConfigBase
{
	private IniConfigSource iniConfigSource_0;

	public IniConfig(string name, IConfigSource source)
		: base(name, source)
	{
		iniConfigSource_0 = (IniConfigSource)source;
	}

	public override string Get(string key)
	{
		if (!iniConfigSource_0.CaseSensitive)
		{
			key = method_2(key);
		}
		return base.Get(key);
	}

	public override void Set(string key, object value)
	{
		if (!iniConfigSource_0.CaseSensitive)
		{
			key = method_2(key);
		}
		base.Set(key, value);
	}

	public override void Remove(string key)
	{
		if (!iniConfigSource_0.CaseSensitive)
		{
			key = method_2(key);
		}
		base.Remove(key);
	}

	private string method_2(string string_1)
	{
		string text = null;
		string text2 = string_1.ToLower();
		foreach (string key in keys.Keys)
		{
			if (key.ToLower() == text2)
			{
				text = key;
				break;
			}
		}
		if (text != null)
		{
			return text;
		}
		return string_1;
	}

	static IniConfig()
	{
		Class72.smethod_20();
	}
}
