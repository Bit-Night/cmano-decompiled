using System;
using Nini.Util;

namespace Nini.Config;

public class ArgvConfigSource : ConfigSourceBase
{
	private ArgvParser argvParser_0;

	private string[] string_0;

	public ArgvConfigSource(string[] arguments)
	{
		argvParser_0 = new ArgvParser(arguments);
		string_0 = arguments;
	}

	public override void Save()
	{
		throw new ArgumentException("Source is read only");
	}

	public override void Reload()
	{
		throw new ArgumentException("Source cannot be reloaded");
	}

	public void AddSwitch(string configName, string longName)
	{
		AddSwitch(configName, longName, null);
	}

	public void AddSwitch(string configName, string longName, string shortName)
	{
		IConfig config = method_2(configName);
		if (shortName != null && (shortName.Length < 1 || shortName.Length > 2))
		{
			throw new ArgumentException("Short name may only be 1 or 2 characters");
		}
		if (argvParser_0[longName] == null)
		{
			if (shortName != null && argvParser_0[shortName] != null)
			{
				config.Set(longName, argvParser_0[shortName]);
			}
		}
		else
		{
			config.Set(longName, argvParser_0[longName]);
		}
	}

	public string[] GetArguments()
	{
		string[] array = new string[string_0.Length];
		Array.Copy(string_0, 0, array, 0, string_0.Length);
		return array;
	}

	private IConfig method_2(string string_1)
	{
		IConfig config = null;
		if (base.Configs[string_1] == null)
		{
			config = new ConfigBase(string_1, this);
			base.Configs.Add(config);
		}
		else
		{
			config = base.Configs[string_1];
		}
		return config;
	}

	static ArgvConfigSource()
	{
		Class72.smethod_20();
	}
}
