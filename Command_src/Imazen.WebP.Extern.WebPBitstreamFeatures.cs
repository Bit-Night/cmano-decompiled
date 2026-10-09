using System.Runtime.InteropServices;

namespace Imazen.WebP.Extern;

public struct WebPBitstreamFeatures
{
	public int width;

	public int height;

	public int has_alpha;

	public int has_animation;

	public int format;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5, ArraySubType = UnmanagedType.U4)]
	public uint[] pad;
}
