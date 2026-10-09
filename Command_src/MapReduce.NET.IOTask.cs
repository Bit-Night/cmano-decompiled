using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MapReduce.NET;

public class IOTask
{
	private IOPlugin ioplugin_0;

	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private string string_1;

	private IDictionary<string, string> idictionary_0;

	public string Location
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public string PluginType
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
		[CompilerGenerated]
		set
		{
			string_1 = value;
		}
	}

	public IDictionary<string, string> Parameters
	{
		get
		{
			return idictionary_0;
		}
		set
		{
			idictionary_0 = value;
		}
	}

	public IOPlugin GetPlugin()
	{
		Type type = TypeFinder.FindType(PluginType);
		if (type == null)
		{
			return null;
		}
		ioplugin_0 = Activator.CreateInstance(type, Location) as IOPlugin;
		TypeFinder.MapDictionary(ioplugin_0, idictionary_0);
		return ioplugin_0;
	}

	static IOTask()
	{
		Class72.smethod_20();
	}
}
