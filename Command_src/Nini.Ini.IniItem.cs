namespace Nini.Ini;

public class IniItem
{
	private IniType iniType_0 = IniType.Empty;

	private string string_0 = "";

	private string string_1 = "";

	private string string_2;

	public IniType Type
	{
		get
		{
			return iniType_0;
		}
		set
		{
			iniType_0 = value;
		}
	}

	public string Value
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public string Name => string_0;

	public string Comment
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	protected internal IniItem(string name, string value, IniType type, string comment)
	{
		string_0 = name;
		string_1 = value;
		iniType_0 = type;
		string_2 = comment;
	}

	static IniItem()
	{
		Class72.smethod_20();
	}
}
