using System.Runtime.CompilerServices;
using System.Text;

namespace ICSharpCode.SharpZipLib.Zip;

public class StringCodec
{
	[CompilerGenerated]
	private bool bool_0;

	[CompilerGenerated]
	private Encoding encoding_0;

	public static readonly Encoding UnicodeZipEncoding;

	public const int ZipSpecCodePage = 437;

	[CompilerGenerated]
	private Encoding encoding_1;

	[CompilerGenerated]
	private Encoding encoding_2;

	public static StringCodec Default => new StringCodec(forceLegacyEncoding: false, SystemDefaultEncoding);

	public bool ForceZipLegacyEncoding
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		internal set
		{
			bool_0 = value;
		}
	}

	public static Encoding DefaultZipCryptoEncoding => SystemDefaultEncoding;

	public Encoding ZipOutputEncoding => ZipEncoding(!ForceZipLegacyEncoding);

	public Encoding LegacyEncoding
	{
		[CompilerGenerated]
		get
		{
			return encoding_0;
		}
		[CompilerGenerated]
		internal set
		{
			encoding_0 = value;
		}
	}

	public int CodePage => LegacyEncoding.CodePage;

	public static int SystemDefaultCodePage => SystemDefaultEncoding.CodePage;

	public static Encoding SystemDefaultEncoding => Encoding.GetEncoding(0);

	public Encoding ZipArchiveCommentEncoding
	{
		[CompilerGenerated]
		get
		{
			return encoding_1;
		}
		[CompilerGenerated]
		internal set
		{
			encoding_1 = value;
		}
	}

	public Encoding ZipCryptoEncoding
	{
		[CompilerGenerated]
		get
		{
			return encoding_2;
		}
		[CompilerGenerated]
		internal set
		{
			encoding_2 = value;
		}
	}

	internal StringCodec(bool forceLegacyEncoding, Encoding legacyEncoding)
	{
		LegacyEncoding = legacyEncoding;
		ForceZipLegacyEncoding = forceLegacyEncoding;
		ZipArchiveCommentEncoding = legacyEncoding;
		ZipCryptoEncoding = legacyEncoding;
	}

	public static StringCodec FromCodePage(int codePage)
	{
		return new StringCodec(forceLegacyEncoding: false, Encoding.GetEncoding(codePage));
	}

	public static StringCodec FromEncoding(Encoding encoding)
	{
		return new StringCodec(forceLegacyEncoding: false, encoding);
	}

	public static StringCodec WithStrictSpecEncoding()
	{
		return new StringCodec(forceLegacyEncoding: false, Encoding.GetEncoding(437));
	}

	public Encoding ZipEncoding(bool unicode)
	{
		if (!unicode)
		{
			return LegacyEncoding;
		}
		return UnicodeZipEncoding;
	}

	public Encoding ZipInputEncoding(GeneralBitFlags flags)
	{
		return ZipEncoding(!ForceZipLegacyEncoding && flags.HasAny(GeneralBitFlags.UnicodeText));
	}

	public Encoding ZipInputEncoding(int flags)
	{
		return ZipInputEncoding((GeneralBitFlags)flags);
	}

	public StringCodec WithZipArchiveCommentEncoding(Encoding commentEncoding)
	{
		return new StringCodec(ForceZipLegacyEncoding, LegacyEncoding)
		{
			ZipArchiveCommentEncoding = commentEncoding,
			ZipCryptoEncoding = ZipCryptoEncoding
		};
	}

	public StringCodec WithZipCryptoEncoding(Encoding cryptoEncoding)
	{
		return new StringCodec(ForceZipLegacyEncoding, LegacyEncoding)
		{
			ZipArchiveCommentEncoding = ZipArchiveCommentEncoding,
			ZipCryptoEncoding = cryptoEncoding
		};
	}

	public StringCodec WithForcedLegacyEncoding()
	{
		return new StringCodec(forceLegacyEncoding: true, LegacyEncoding)
		{
			ZipArchiveCommentEncoding = ZipArchiveCommentEncoding,
			ZipCryptoEncoding = ZipCryptoEncoding
		};
	}

	static StringCodec()
	{
		Class72.smethod_20();
		UnicodeZipEncoding = Encoding.UTF8;
	}
}
