using System;
using System.Collections.Generic;

namespace Command;

[Serializable]
public class JsonCollection_RamDBConfigs
{
	public List<HashTableNodeConfig> ConfigCollection;

	static JsonCollection_RamDBConfigs()
	{
		Class72.smethod_20();
	}
}
