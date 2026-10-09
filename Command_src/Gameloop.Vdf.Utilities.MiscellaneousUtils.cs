namespace Gameloop.Vdf.Utilities;

internal static class MiscellaneousUtils
{
	public static string ToString(object value)
	{
		if (value != null)
		{
			if (!(value is string))
			{
				return value.ToString();
			}
			return "\"" + value.ToString() + "\"";
		}
		return "{null}";
	}

	static MiscellaneousUtils()
	{
		Class72.smethod_20();
	}
}
