using System;
using System.Collections.Generic;
using System.Reflection;

namespace Command_Core.SQLTableGenerator;

internal class Program
{
	private static void Main(object args)
	{
		List<TableClass> list = new List<TableClass>();
		Type[] types = Assembly.LoadFile((string)((object[])args)[0]).GetTypes();
		foreach (Type t in types)
		{
			TableClass item = new TableClass(t);
			list.Add(item);
		}
		foreach (TableClass item2 in list)
		{
			Console.WriteLine(item2.CreateTableScript());
			Console.WriteLine();
		}
	}

	static Program()
	{
		Class72.smethod_20();
	}
}
