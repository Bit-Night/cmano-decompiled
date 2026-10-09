using System;
using System.Text;
using ICSharpCode.SharpZipLib.Core;

namespace ICSharpCode.SharpZipLib.Zip;

public static class ZipStrings
{
	private static StringCodec stringCodec_0;

	private static bool bool_0;

	[Obsolete("Use ZipFile/Zip*Stream StringCodec instead")]
	public static int CodePage
	{
		get
		{
			return stringCodec_0.CodePage;
		}
		set
		{
			stringCodec_0 = new StringCodec(stringCodec_0.ForceZipLegacyEncoding, Encoding.GetEncoding(value))
			{
				ZipArchiveCommentEncoding = stringCodec_0.ZipArchiveCommentEncoding,
				ZipCryptoEncoding = stringCodec_0.ZipCryptoEncoding
			};
			bool_0 = true;
		}
	}

	[Obsolete("Use ZipFile/Zip*Stream StringCodec instead")]
	public static int SystemDefaultCodePage => StringCodec.SystemDefaultCodePage;

	[Obsolete("Use ZipFile/Zip*Stream StringCodec instead")]
	public static bool UseUnicode
	{
		get
		{
			return !stringCodec_0.ForceZipLegacyEncoding;
		}
		set
		{
			stringCodec_0 = new StringCodec(!value, stringCodec_0.LegacyEncoding)
			{
				ZipArchiveCommentEncoding = stringCodec_0.ZipArchiveCommentEncoding,
				ZipCryptoEncoding = stringCodec_0.ZipCryptoEncoding
			};
			bool_0 = true;
		}
	}

	public static StringCodec GetStringCodec()
	{
		if (!bool_0)
		{
			return StringCodec.Default;
		}
		return stringCodec_0;
	}

	[Obsolete("Use ZipFile/Zip*Stream StringCodec instead")]
	private static bool smethod_0(int int_0)
	{
		return ((GeneralBitFlags)int_0).HasFlag(GeneralBitFlags.UnicodeText);
	}

	[Obsolete("Use ZipFile/Zip*Stream StringCodec instead")]
	public static string ConvertToString(byte[] data, int count)
	{
		return stringCodec_0.ZipOutputEncoding.GetString(data, 0, count);
	}

	[Obsolete("Use ZipFile/Zip*Stream StringCodec instead")]
	public static string ConvertToString(byte[] data)
	{
		return stringCodec_0.ZipOutputEncoding.GetString(data);
	}

	[Obsolete("Use ZipFile/Zip*Stream StringCodec instead")]
	public static string ConvertToStringExt(int flags, byte[] data, int count)
	{
		return stringCodec_0.ZipEncoding(smethod_0(flags)).GetString(data, 0, count);
	}

	[Obsolete("Use ZipFile/Zip*Stream StringCodec instead")]
	public static string ConvertToStringExt(int flags, byte[] data)
	{
		return stringCodec_0.ZipEncoding(smethod_0(flags)).GetString(data);
	}

	[Obsolete("Use ZipFile/Zip*Stream StringCodec instead")]
	public static byte[] ConvertToArray(string str)
	{
		return ConvertToArray(0, str);
	}

	[Obsolete("Use ZipFile/Zip*Stream StringCodec instead")]
	public static byte[] ConvertToArray(int flags, string str)
	{
		if (string.IsNullOrEmpty(str))
		{
			return Empty.Array<byte>();
		}
		return stringCodec_0.ZipEncoding(smethod_0(flags)).GetBytes(str);
	}

	static ZipStrings()
	{
		Class72.smethod_20();
		stringCodec_0 = StringCodec.Default;
	}
}
