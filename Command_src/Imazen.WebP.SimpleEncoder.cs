using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using Imazen.WebP.Extern;

namespace Imazen.WebP;

public sealed class SimpleEncoder
{
	public static string GetEncoderVersion()
	{
		int num = NativeMethods.WebPGetEncoderVersion();
		uint num2 = (uint)num % 256u;
		uint num3 = (uint)(num >>> 8) % 256u;
		uint num4 = (uint)(num >>> 16) % 256u;
		return num4 + "." + num3 + "." + num2;
	}

	[Obsolete]
	public void Encode(Bitmap from, Stream to, float quality, bool noAlpha)
	{
		Encode(from, to, quality);
	}

	public void Encode(Bitmap from, Stream to, float quality)
	{
		Encode(from, quality, out var result, out var length);
		try
		{
			byte[] array = new byte[4096];
			for (int i = 0; i < length; i += array.Length)
			{
				int num = (int)Math.Min(array.Length, length - i);
				Marshal.Copy((IntPtr)((long)result + i), array, 0, num);
				to.Write(array, 0, num);
			}
		}
		finally
		{
			NativeMethods.WebPSafeFree(result);
		}
	}

	[Obsolete]
	public void Encode(Bitmap b, float quality, bool noAlpha, out IntPtr result, out long length)
	{
		Encode(b, quality, out result, out length);
	}

	public void Encode(Bitmap b, float quality, out IntPtr result, out long length)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Invalid comparison between Unknown and I4
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Invalid comparison between Unknown and I4
		if (quality < -1f)
		{
			quality = -1f;
		}
		if (quality > 100f)
		{
			quality = 100f;
		}
		int width = ((Image)b).Width;
		int height = ((Image)b).Height;
		BitmapData val = b.LockBits(new Rectangle(0, 0, width, height), (ImageLockMode)1, ((Image)b).PixelFormat);
		try
		{
			result = IntPtr.Zero;
			if ((int)((Image)b).PixelFormat == 2498570)
			{
				if (quality == -1f)
				{
					length = (long)(ulong)NativeMethods.WebPEncodeLosslessBGRA(val.Scan0, width, height, val.Stride, ref result);
				}
				else
				{
					length = (long)NativeMethods.WebPEncodeBGRA(val.Scan0, width, height, val.Stride, quality, ref result);
				}
			}
			else if ((int)((Image)b).PixelFormat == 137224)
			{
				if (quality == -1f)
				{
					length = (long)(ulong)NativeMethods.WebPEncodeLosslessBGR(val.Scan0, width, height, val.Stride, ref result);
				}
				else
				{
					length = (long)(ulong)NativeMethods.WebPEncodeBGR(val.Scan0, width, height, val.Stride, quality, ref result);
				}
			}
			else
			{
				Bitmap val2 = b.Clone(new Rectangle(0, 0, ((Image)b).Width, ((Image)b).Height), (PixelFormat)2498570);
				try
				{
					Encode(val2, quality, out result, out length);
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
			}
			if (length == 0L)
			{
				throw new Exception("WebP encode failed!");
			}
		}
		finally
		{
			b.UnlockBits(val);
		}
	}

	static SimpleEncoder()
	{
		Class72.smethod_20();
	}
}
