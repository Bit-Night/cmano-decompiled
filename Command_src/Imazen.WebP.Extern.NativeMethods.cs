using System;
using System.Runtime.InteropServices;

namespace Imazen.WebP.Extern;

public class NativeMethods
{
	public const int WEBP_DECODER_ABI_VERSION = 520;

	public const int WEBP_ENCODER_ABI_VERSION = 521;

	public const int WEBP_MAX_DIMENSION = 16383;

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPGetDecoderVersion();

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPGetInfo([In] IntPtr data, UIntPtr data_size, ref int width, ref int height);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr WebPDecodeRGBA([In] IntPtr data, UIntPtr data_size, ref int width, ref int height);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr WebPDecodeARGB([In] IntPtr data, UIntPtr data_size, ref int width, ref int height);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr WebPDecodeBGRA([In] IntPtr data, UIntPtr data_size, ref int width, ref int height);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr WebPDecodeRGB([In] IntPtr data, UIntPtr data_size, ref int width, ref int height);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr WebPDecodeBGR([In] IntPtr data, UIntPtr data_size, ref int width, ref int height);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr WebPDecodeYUV([In] IntPtr data, UIntPtr data_size, ref int width, ref int height, ref IntPtr u, ref IntPtr v, ref int stride, ref int uv_stride);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr WebPDecodeRGBAInto([In] IntPtr data, UIntPtr data_size, IntPtr output_buffer, UIntPtr output_buffer_size, int output_stride);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr WebPDecodeARGBInto([In] IntPtr data, UIntPtr data_size, IntPtr output_buffer, UIntPtr output_buffer_size, int output_stride);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr WebPDecodeBGRAInto([In] IntPtr data, UIntPtr data_size, IntPtr output_buffer, UIntPtr output_buffer_size, int output_stride);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr WebPDecodeRGBInto([In] IntPtr data, UIntPtr data_size, IntPtr output_buffer, UIntPtr output_buffer_size, int output_stride);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr WebPDecodeBGRInto([In] IntPtr data, UIntPtr data_size, IntPtr output_buffer, UIntPtr output_buffer_size, int output_stride);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr WebPDecodeYUVInto([In] IntPtr data, UIntPtr data_size, IntPtr luma, UIntPtr luma_size, int luma_stride, IntPtr u, UIntPtr u_size, int u_stride, IntPtr v, UIntPtr v_size, int v_stride);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPInitDecBufferInternal(ref WebPDecBuffer param0, int param1);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern void WebPFreeDecBuffer(ref WebPDecBuffer buffer);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr WebPINewDecoder(ref WebPDecBuffer output_buffer);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr WebPINewRGB(WEBP_CSP_MODE csp, IntPtr output_buffer, UIntPtr output_buffer_size, int output_stride);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr WebPINewYUVA(IntPtr luma, UIntPtr luma_size, int luma_stride, IntPtr u, UIntPtr u_size, int u_stride, IntPtr v, UIntPtr v_size, int v_stride, IntPtr a, UIntPtr a_size, int a_stride);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr WebPINewYUV(IntPtr luma, UIntPtr luma_size, int luma_stride, IntPtr u, UIntPtr u_size, int u_stride, IntPtr v, UIntPtr v_size, int v_stride);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern void WebPIDelete(ref WebPIDecoder idec);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern VP8StatusCode WebPIAppend(ref WebPIDecoder idec, [In] IntPtr data, UIntPtr data_size);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern VP8StatusCode WebPIUpdate(ref WebPIDecoder idec, [In] IntPtr data, UIntPtr data_size);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr WebPIDecGetRGB(ref WebPIDecoder idec, ref int last_y, ref int width, ref int height, ref int stride);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr WebPIDecGetYUVA(ref WebPIDecoder idec, ref int last_y, ref IntPtr u, ref IntPtr v, ref IntPtr a, ref int width, ref int height, ref int stride, ref int uv_stride, ref int a_stride);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr WebPIDecodedArea(ref WebPIDecoder idec, ref int left, ref int top, ref int width, ref int height);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern VP8StatusCode WebPGetFeaturesInternal([In] IntPtr param0, UIntPtr param1, ref WebPBitstreamFeatures param2, int param3);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPInitDecoderConfigInternal(ref WebPDecoderConfig param0, int param1);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr WebPIDecode([In] IntPtr data, UIntPtr data_size, ref WebPDecoderConfig config);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern VP8StatusCode WebPDecode([In] IntPtr data, UIntPtr data_size, ref WebPDecoderConfig config);

	public static bool WebPIsPremultipliedMode(WEBP_CSP_MODE mode)
	{
		if (mode != WEBP_CSP_MODE.MODE_rgbA && mode != WEBP_CSP_MODE.MODE_bgrA && mode != WEBP_CSP_MODE.MODE_Argb)
		{
			return mode == WEBP_CSP_MODE.MODE_rgbA_4444;
		}
		return true;
	}

	public static bool WebPIsRGBMode(WEBP_CSP_MODE mode)
	{
		return true;
	}

	public static bool WebPIsAlphaMode(WEBP_CSP_MODE mode)
	{
		if (mode != WEBP_CSP_MODE.MODE_RGBA && mode != WEBP_CSP_MODE.MODE_BGRA && mode != WEBP_CSP_MODE.MODE_ARGB && mode != WEBP_CSP_MODE.MODE_RGBA_4444 && mode != WEBP_CSP_MODE.MODE_YUVA)
		{
			return WebPIsPremultipliedMode(mode);
		}
		return true;
	}

	public static VP8StatusCode WebPGetFeatures(IntPtr data, UIntPtr data_size, ref WebPBitstreamFeatures features)
	{
		return WebPGetFeaturesInternal(data, data_size, ref features, 520);
	}

	public static int WebPInitDecoderConfig(ref WebPDecoderConfig config)
	{
		return WebPInitDecoderConfigInternal(ref config, 520);
	}

	public static int WebPInitDecBuffer(ref WebPDecBuffer buffer)
	{
		return WebPInitDecBufferInternal(ref buffer, 520);
	}

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPGetEncoderVersion();

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern UIntPtr WebPEncodeRGB([In] IntPtr rgb, int width, int height, int stride, float quality_factor, ref IntPtr output);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern UIntPtr WebPEncodeBGR([In] IntPtr bgr, int width, int height, int stride, float quality_factor, ref IntPtr output);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern UIntPtr WebPEncodeRGBA([In] IntPtr rgba, int width, int height, int stride, float quality_factor, ref IntPtr output);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr WebPEncodeBGRA([In] IntPtr bgra, int width, int height, int stride, float quality_factor, ref IntPtr output);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern UIntPtr WebPEncodeLosslessRGB([In] IntPtr rgb, int width, int height, int stride, ref IntPtr output);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern UIntPtr WebPEncodeLosslessBGR([In] IntPtr bgr, int width, int height, int stride, ref IntPtr output);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern UIntPtr WebPEncodeLosslessRGBA([In] IntPtr rgba, int width, int height, int stride, ref IntPtr output);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern UIntPtr WebPEncodeLosslessBGRA([In] IntPtr bgra, int width, int height, int stride, ref IntPtr output);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPConfigInitInternal(ref WebPConfig param0, WebPPreset param1, float param2, int param3);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPConfigLosslessPreset(ref WebPConfig config);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPValidateConfig(ref WebPConfig config);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern void WebPMemoryWriterInit(ref WebPMemoryWriter writer);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern void WebPMemoryWriterClear(ref WebPMemoryWriter writer);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPMemoryWrite([In] IntPtr data, UIntPtr data_size, ref WebPPicture picture);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPPictureInitInternal(ref WebPPicture param0, int param1);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPPictureAlloc(ref WebPPicture picture);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern void WebPPictureFree(ref WebPPicture picture);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPPictureCopy(ref WebPPicture src, ref WebPPicture dst);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPPictureDistortion(ref WebPPicture src, ref WebPPicture reference, int metric_type, ref float result);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPPictureCrop(ref WebPPicture picture, int left, int top, int width, int height);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPPictureView(ref WebPPicture src, int left, int top, int width, int height, ref WebPPicture dst);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPPictureIsView(ref WebPPicture picture);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPPictureRescale(ref WebPPicture pic, int width, int height);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPPictureImportRGB(ref WebPPicture picture, [In] IntPtr rgb, int rgb_stride);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPPictureImportRGBA(ref WebPPicture picture, [In] IntPtr rgba, int rgba_stride);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPPictureSmartARGBToYUVA(ref WebPPicture picture);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPPictureImportRGBX(ref WebPPicture picture, [In] IntPtr rgbx, int rgbx_stride);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPPictureImportBGR(ref WebPPicture picture, [In] IntPtr bgr, int bgr_stride);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPPictureImportBGRA(ref WebPPicture picture, [In] IntPtr bgra, int bgra_stride);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPPictureImportBGRX(ref WebPPicture picture, [In] IntPtr bgrx, int bgrx_stride);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPPictureARGBToYUVA(ref WebPPicture picture, WebPEncCSP colorspace);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPPictureYUVAToARGB(ref WebPPicture picture);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern void WebPCleanupTransparentArea(ref WebPPicture picture);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPPictureHasTransparency(ref WebPPicture picture);

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern int WebPEncode(ref WebPConfig config, ref WebPPicture picture);

	public static int WebPConfigInit(ref WebPConfig config)
	{
		return WebPConfigInitInternal(ref config, WebPPreset.WEBP_PRESET_DEFAULT, 75f, 521);
	}

	public static int WebPConfigPreset(ref WebPConfig config, WebPPreset preset, float quality)
	{
		return WebPConfigInitInternal(ref config, preset, quality, 521);
	}

	public static int WebPPictureInit(ref WebPPicture picture)
	{
		return WebPPictureInitInternal(ref picture, 521);
	}

	public static void WebPSafeFree(IntPtr toDeallocate)
	{
		WebPFree(toDeallocate);
	}

	[DllImport("libwebp", CallingConvention = CallingConvention.Cdecl)]
	public static extern void WebPFree(IntPtr toDeallocate);

	static NativeMethods()
	{
		Class72.smethod_20();
	}
}
