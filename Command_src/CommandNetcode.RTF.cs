namespace CommandNetcode;

public static class RTF
{
	public static string Newline;

	public static string ToBold(string s)
	{
		return $"\\b {s}\\b0 ";
	}

	public static string ToRTF(string s)
	{
		return "{\\rtf1 \\ansi " + s + " }";
	}

	static RTF()
	{
		Class72.smethod_20();
		Newline = "\\line ";
	}
}
