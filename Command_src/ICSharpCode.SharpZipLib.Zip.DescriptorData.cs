using System.Runtime.CompilerServices;

namespace ICSharpCode.SharpZipLib.Zip;

public class DescriptorData
{
	private long long_0;

	[CompilerGenerated]
	private long long_1;

	[CompilerGenerated]
	private long long_2;

	public long CompressedSize
	{
		[CompilerGenerated]
		get
		{
			return long_1;
		}
		[CompilerGenerated]
		set
		{
			long_1 = value;
		}
	}

	public long Size
	{
		[CompilerGenerated]
		get
		{
			return long_2;
		}
		[CompilerGenerated]
		set
		{
			long_2 = value;
		}
	}

	public long Crc
	{
		get
		{
			return long_0;
		}
		set
		{
			long_0 = value & 0xFFFFFFFFL;
		}
	}

	static DescriptorData()
	{
		Class72.smethod_20();
	}
}
