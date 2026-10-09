using System;

namespace Nini.Config;

public class ConfigEventArgs : EventArgs
{
	private IConfig iconfig_0;

	public IConfig Config => iconfig_0;

	public ConfigEventArgs(IConfig config)
	{
		iconfig_0 = config;
	}

	static ConfigEventArgs()
	{
		Class72.smethod_20();
	}
}
