using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace DarkUI;

[CompilerGenerated]
[DebuggerNonUserCode]
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
internal class ScrollIcons
{
	private static ResourceManager resourceManager_0;

	private static CultureInfo cultureInfo_0;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager
	{
		get
		{
			if (resourceManager_0 == null)
			{
				resourceManager_0 = new ResourceManager("CSMaterial.DarkUI.Icons.ScrollIcons", typeof(ScrollIcons).Assembly);
			}
			return resourceManager_0;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo Culture
	{
		get
		{
			return cultureInfo_0;
		}
		set
		{
			cultureInfo_0 = value;
		}
	}

	internal static Bitmap scrollbar_arrow => (Bitmap)ResourceManager.GetObject("scrollbar_arrow", cultureInfo_0);

	internal static Bitmap scrollbar_arrow_clicked => (Bitmap)ResourceManager.GetObject("scrollbar_arrow_clicked", cultureInfo_0);

	internal static Bitmap scrollbar_arrow_disabled => (Bitmap)ResourceManager.GetObject("scrollbar_arrow_disabled", cultureInfo_0);

	internal static Bitmap scrollbar_arrow_hot => (Bitmap)ResourceManager.GetObject("scrollbar_arrow_hot", cultureInfo_0);

	internal static Bitmap scrollbar_arrow_standard => (Bitmap)ResourceManager.GetObject("scrollbar_arrow_standard", cultureInfo_0);

	internal ScrollIcons()
	{
	}

	static ScrollIcons()
	{
		Class72.smethod_20();
		Class77.smethod_3();
	}
}
