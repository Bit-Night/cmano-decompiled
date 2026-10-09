using System;
using System.Collections.Generic;

namespace Command;

[Serializable]
public class HashTableNodeConfig
{
	public string Type;

	public string PrimaryElevation;

	public List<string> SecondaryTable;

	public List<string> ComponentsTable;

	public string DisplayName;

	public List<Ram_Database.TableComponentWrapper> ComponentsLiaisons;

	public HashTableNodeConfig()
	{
		SecondaryTable = new List<string>();
		ComponentsTable = new List<string>();
	}

	static HashTableNodeConfig()
	{
		Class72.smethod_20();
	}
}
