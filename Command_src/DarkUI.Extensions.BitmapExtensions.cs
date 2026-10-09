using System.Drawing;

namespace DarkUI.Extensions;

internal static class BitmapExtensions
{
	internal static Bitmap SetColor(this Bitmap bitmap, Color color)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		Bitmap val = new Bitmap(((Image)bitmap).Width, ((Image)bitmap).Height);
		for (int i = 0; i < ((Image)bitmap).Width; i++)
		{
			for (int j = 0; j < ((Image)bitmap).Height; j++)
			{
				if (bitmap.GetPixel(i, j).A > 0)
				{
					val.SetPixel(i, j, color);
				}
			}
		}
		return val;
	}

	internal static Bitmap ChangeColor(this Bitmap bitmap, Color oldColor, Color newColor)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		Bitmap val = new Bitmap(((Image)bitmap).Width, ((Image)bitmap).Height);
		for (int i = 0; i < ((Image)bitmap).Width; i++)
		{
			for (int j = 0; j < ((Image)bitmap).Height; j++)
			{
				if (bitmap.GetPixel(i, j) == oldColor)
				{
					val.SetPixel(i, j, newColor);
				}
			}
		}
		return val;
	}

	static BitmapExtensions()
	{
		Class72.smethod_20();
	}
}
