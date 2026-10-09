using System;

namespace Nini.Config;

public class ConfigKeyEventArgs : EventArgs
{
	private string string_0;

	private string string_1;

	public string KeyName => string_0;

	public string KeyValue => string_1;

	public ConfigKeyEventArgs(string keyName, string keyValue)
	{
		string_0 = keyName;
		string_1 = keyValue;
	}

	static ConfigKeyEventArgs()
	{
		Class72.smethod_20();
	}
}
