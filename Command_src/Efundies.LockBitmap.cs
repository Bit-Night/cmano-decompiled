using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSMaterial;

namespace Efundies;

public sealed class LockBitmap
{
	private readonly Bitmap bitmap_0;

	private IntPtr intptr_0 = IntPtr.Zero;

	private BitmapData bitmapData_0;

	[CompilerGenerated]
	private byte[] byte_0;

	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private int int_1;

	[CompilerGenerated]
	private int int_2;

	public byte[] Pixels
	{
		[CompilerGenerated]
		get
		{
			return byte_0;
		}
		[CompilerGenerated]
		set
		{
			byte_0 = value;
		}
	}

	public int Depth
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		private set
		{
			int_0 = value;
		}
	}

	public int Width
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		private set
		{
			int_1 = value;
		}
	}

	public int Height
	{
		[CompilerGenerated]
		get
		{
			return int_2;
		}
		[CompilerGenerated]
		private set
		{
			int_2 = value;
		}
	}

	public LockBitmap(Bitmap source)
	{
		bitmap_0 = source;
	}

	public void LockBits()
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Width = ((Image)bitmap_0).Width;
			Height = ((Image)bitmap_0).Height;
			int num = Width * Height;
			Rectangle rectangle = new Rectangle(0, 0, Width, Height);
			Depth = Image.GetPixelFormatSize(((Image)bitmap_0).PixelFormat);
			if (Depth != 8 && Depth != 24 && Depth != 32)
			{
				throw new ArgumentException("Only 8, 24 and 32 bpp images are supported.");
			}
			bitmapData_0 = bitmap_0.LockBits(rectangle, (ImageLockMode)3, ((Image)bitmap_0).PixelFormat);
			int num2 = Depth / 8;
			Pixels = new byte[num * num2];
			intptr_0 = bitmapData_0.Scan0;
			Marshal.Copy(intptr_0, Pixels, 0, Pixels.Length);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public void UnlockBits()
	{
		try
		{
			Marshal.Copy(Pixels, 0, intptr_0, Pixels.Length);
			bitmap_0.UnlockBits(bitmapData_0);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public Color GetPixel(int x, int y, int theDepth, byte[] PixelsArray)
	{
		Color result = Color.Empty;
		int num = theDepth / 8;
		int num2 = (y * Width + x) * num;
		if (num2 <= PixelsArray.Length - num)
		{
			if (theDepth == 32)
			{
				byte blue = PixelsArray[num2];
				byte green = PixelsArray[num2 + 1];
				byte red = PixelsArray[num2 + 2];
				result = Color.FromArgb(PixelsArray[num2 + 3], red, green, blue);
			}
			if (theDepth == 24)
			{
				byte blue2 = PixelsArray[num2];
				byte green2 = PixelsArray[num2 + 1];
				result = Color.FromArgb(PixelsArray[num2 + 2], green2, blue2);
			}
			if (theDepth == 8)
			{
				byte b = PixelsArray[num2];
				result = Color.FromArgb(b, b, b);
			}
			return result;
		}
		throw new IndexOutOfRangeException();
	}

	public UnsafeColor GetPixel_UnsafeColor(int x, int y, int theDepth, int theWidth, byte[] PixelsArray)
	{
		int num = theDepth / 8;
		int num2 = (y * theWidth + x) * num;
		if (num2 <= PixelsArray.Length - num)
		{
			switch (theDepth)
			{
			case 32:
			{
				byte b3 = PixelsArray[num2];
				byte g2 = PixelsArray[num2 + 1];
				byte r2 = PixelsArray[num2 + 2];
				byte a = PixelsArray[num2 + 3];
				return new UnsafeColor(a, r2, g2, b3);
			}
			case 24:
			{
				byte b2 = PixelsArray[num2];
				byte g = PixelsArray[num2 + 1];
				byte r = PixelsArray[num2 + 2];
				return new UnsafeColor(r, g, b2);
			}
			case 8:
			{
				byte b = PixelsArray[num2];
				return new UnsafeColor(b, b, b);
			}
			default:
				return default(UnsafeColor);
			}
		}
		throw new IndexOutOfRangeException();
	}

	public void SetPixel(int x, int y, Color color)
	{
		int num = Depth / 8;
		int num2 = (y * Width + x) * num;
		if (Depth == 32)
		{
			Pixels[num2] = color.B;
			Pixels[num2 + 1] = color.G;
			Pixels[num2 + 2] = color.R;
			Pixels[num2 + 3] = color.A;
		}
		if (Depth == 24)
		{
			Pixels[num2] = color.B;
			Pixels[num2 + 1] = color.G;
			Pixels[num2 + 2] = color.R;
		}
		if (Depth == 8)
		{
			Pixels[num2] = color.B;
		}
	}

	static LockBitmap()
	{
		Class72.smethod_20();
	}
}
