using System.Runtime.CompilerServices;

namespace ICSharpCode.SharpZipLib.Zip;

internal struct EntryPatchData
{
	[CompilerGenerated]
	private long long_0;

	[CompilerGenerated]
	private long long_1;

	public long SizePatchOffset
	{
		[CompilerGenerated]
		readonly get
		{
			return long_0;
		}
		[CompilerGenerated]
		set
		{
			long_0 = value;
		}
	}

	public long CrcPatchOffset
	{
		[CompilerGenerated]
		readonly get
		{
			return long_1;
		}
		[CompilerGenerated]
		set
		{
			long_1 = value;
		}
	}

	static EntryPatchData()
	{
		Class72.smethod_20();
	}
}
