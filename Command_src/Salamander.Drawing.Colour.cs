using System;
using System.Drawing;

namespace Salamander.Drawing;

public sealed class Colour
{
	public const int HUEMAX = 360;

	public const float SATMAX = 1f;

	public const float BRIGHTMAX = 1f;

	public const int RGBMAX = 255;

	private Color color_0 = Color.Red;

	public Color CurrentColour
	{
		get
		{
			return color_0;
		}
		set
		{
			color_0 = value;
		}
	}

	public byte Red
	{
		get
		{
			return color_0.R;
		}
		set
		{
			color_0 = Color.FromArgb(value, Green, Blue);
		}
	}

	public byte Green
	{
		get
		{
			return color_0.G;
		}
		set
		{
			color_0 = Color.FromArgb(Red, value, Blue);
		}
	}

	public byte Blue
	{
		get
		{
			return color_0.B;
		}
		set
		{
			color_0 = Color.FromArgb(Red, Green, value);
		}
	}

	public int Hue
	{
		get
		{
			return (int)color_0.GetHue();
		}
		set
		{
			color_0 = HSBToRGB(value, color_0.GetSaturation(), color_0.GetBrightness());
		}
	}

	public float Saturation
	{
		get
		{
			if (0f == Brightness)
			{
				return 0f;
			}
			float num = (int)Math.Max(Red, Math.Max(Green, Blue));
			float num2 = (int)Math.Min(Red, Math.Min(Green, Blue));
			return (num - num2) / num;
		}
		set
		{
			color_0 = HSBToRGB((int)color_0.GetHue(), value, color_0.GetBrightness());
		}
	}

	public float Brightness
	{
		get
		{
			return (float)(int)Math.Max(Red, Math.Max(Green, Blue)) / 255f;
		}
		set
		{
			color_0 = HSBToRGB((int)color_0.GetHue(), color_0.GetSaturation(), value);
		}
	}

	public float GetHue()
	{
		float num = (float)(2 * Red - Green - Blue) / 510f;
		float num2 = (float)Math.Sqrt(((Red - Green) * (Red - Green) + (Red - Blue) * (Green - Blue)) / 255);
		return (float)Math.Acos(num / num2);
	}

	public float GetSaturation()
	{
		return (255f - (float)(Red + Green + Blue) / 3f * (float)(int)Math.Min(Red, Math.Min(Green, Blue))) / 255f;
	}

	public float GetBrightness()
	{
		return (float)(Red + Green + Blue) / 765f;
	}

	public static Color HSBToRGB(int Hue, float Saturation, float Brightness)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		if (Saturation == 0f)
		{
			num = (num2 = (num3 = (int)(Brightness * 255f)));
		}
		else
		{
			float num4 = 1f / 60f * (float)Hue;
			float num5 = (float)Math.Floor(num4);
			float num6 = num4 - num5;
			float num7 = Brightness * 255f;
			byte b = (byte)(0.5f + num7 * (1f - Saturation));
			byte b2 = (byte)(0.5f + num7 * (1f - Saturation * num6));
			byte b3 = (byte)(0.5f + num7 * (1f - Saturation * (1f - num6)));
			switch ((int)num5)
			{
			default:
				num = 0;
				num2 = 0;
				num3 = 0;
				break;
			case 0:
				num = (int)(Brightness * 255f);
				num2 = b3;
				num3 = b;
				break;
			case 1:
				num = b2;
				num2 = (int)(Brightness * 255f);
				num3 = b;
				break;
			case 2:
				num = b;
				num2 = (int)(Brightness * 255f);
				num3 = b3;
				break;
			case 3:
				num = b;
				num2 = b2;
				num3 = (int)(Brightness * 255f);
				break;
			case 4:
				num = b3;
				num2 = b;
				num3 = (int)(Brightness * 255f);
				break;
			case 5:
				num = (int)(Brightness * 255f);
				num2 = b;
				num3 = b2;
				break;
			}
		}
		return Color.FromArgb(num, num2, num3);
	}

	static Colour()
	{
		Class72.smethod_20();
	}
}
