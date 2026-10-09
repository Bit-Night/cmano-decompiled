using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using Imazen.WebP.Extern;

namespace Imazen.WebP;

public sealed class SimpleDecoder
{
	public static string GetDecoderVersion()
	{
		int num = NativeMethods.WebPGetDecoderVersion();
		uint num2 = (uint)num % 256u;
		uint num3 = (uint)(num >>> 8) % 256u;
		uint num4 = (uint)(num >>> 16) % 256u;
		return num4 + "." + num3 + "." + num2;
	}

	public unsafe Bitmap DecodeFromBytes(byte[] data, long length)
	{
		fixed (byte[] array = data)
		{
			int num;
			byte* ptr;
			if (data == null)
			{
				num = 0;
			}
			else
			{
				if (array.Length != 0)
				{
					ptr = (byte*)Unsafe.AsPointer(ref array[0]);
					goto IL_001b;
				}
				num = 0;
			}
			ptr = (byte*)(uint)num;
			goto IL_001b;
			IL_001b:
			return DecodeFromPointer((IntPtr)ptr, length);
		}
	}

	public Bitmap DecodeFromPointer(IntPtr data, long length)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		int width = 0;
		int height = 0;
		if (NativeMethods.WebPGetInfo(data, (UIntPtr)(ulong)length, ref width, ref height) != 0)
		{
			bool flag = false;
			Bitmap val = null;
			BitmapData val2 = null;
			try
			{
				val = new Bitmap(width, height, (PixelFormat)2498570);
				val2 = val.LockBits(new Rectangle(0, 0, width, height), (ImageLockMode)3, (PixelFormat)2498570);
				IntPtr intPtr = NativeMethods.WebPDecodeBGRAInto(data, (UIntPtr)(ulong)length, val2.Scan0, (UIntPtr)(ulong)(val2.Stride * val2.Height), val2.Stride);
				if (val2.Scan0 != intPtr)
				{
					throw new Exception("Failed to decode WebP image with error " + (long)intPtr);
				}
				flag = true;
			}
			finally
			{
				if (val2 != null && val != null)
				{
					val.UnlockBits(val2);
				}
				if (!flag && val != null)
				{
					((Image)val).Dispose();
				}
			}
			return val;
		}
		throw new Exception("Invalid WebP header detected");
	}

	static SimpleDecoder()
	{
		Class72.smethod_20();
	}
}
