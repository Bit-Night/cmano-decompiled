using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[StandardModule]
internal sealed class WPF_Bitmap_Interop
{
	public static BitmapImage ConvertBitmapToBitmapImage(Bitmap bitmap)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		using MemoryStream memoryStream = RCMS.recyclableMemoryStreamManager_0.GetStream();
		((Image)bitmap).Save((Stream)memoryStream, ImageFormat.Png);
		memoryStream.Position = 0L;
		BitmapImage val = new BitmapImage();
		val.BeginInit();
		val.StreamSource = memoryStream;
		val.CacheOption = (BitmapCacheOption)1;
		val.EndInit();
		return val;
	}

	public static BitmapImage smethod_0(string base64String)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		BitmapImage val = new BitmapImage();
		val.BeginInit();
		val.StreamSource = new MemoryStream(Convert.FromBase64String(base64String));
		val.EndInit();
		return val;
	}

	static WPF_Bitmap_Interop()
	{
		Class72.smethod_20();
	}
}
