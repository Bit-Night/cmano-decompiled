using System.Text;

namespace ICSharpCode.SharpZipLib.Zip;

internal static class EncodingExtensions
{
	public static bool IsZipUnicode(this Encoding e)
	{
		return e.Equals(StringCodec.UnicodeZipEncoding);
	}

	static EncodingExtensions()
	{
		Class72.smethod_20();
	}
}
