using System.Runtime.InteropServices;

namespace Imazen.WebP.Extern;

public struct WebPAuxStats
{
	public int coded_size;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5, ArraySubType = UnmanagedType.R4)]
	public float[] PSNR;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I4)]
	public int[] block_count;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I4)]
	public int[] header_bytes;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 12, ArraySubType = UnmanagedType.I4)]
	public int[] residual_bytes;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I4)]
	public int[] segment_size;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I4)]
	public int[] segment_quant;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I4)]
	public int[] segment_level;

	public int alpha_data_size;

	public int layer_data_size;

	public uint lossless_features;

	public int histogram_bits;

	public int transform_bits;

	public int cache_bits;

	public int palette_size;

	public int lossless_size;

	public int lossless_hdr_size;

	public int lossless_data_size;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.U4)]
	public uint[] pad;
}
