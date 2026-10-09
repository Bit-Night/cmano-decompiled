namespace GodSharp.Sockets.Extensions;

public static class StringExtensions
{
	public static bool IsNullOrWhiteSpace(this string str)
	{
		if (str == null)
		{
			return true;
		}
		return string.IsNullOrWhiteSpace(str);
	}

	static StringExtensions()
	{
		Class72.smethod_20();
	}
}
