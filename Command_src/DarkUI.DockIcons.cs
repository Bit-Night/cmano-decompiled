using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace DarkUI;

[DebuggerNonUserCode]
[CompilerGenerated]
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
internal class DockIcons
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
				resourceManager_0 = new ResourceManager("CSMaterial.DarkUI.Icons.DockIcons", typeof(DockIcons).Assembly);
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

	internal static Bitmap active_inactive_close => (Bitmap)ResourceManager.GetObject("active_inactive_close", cultureInfo_0);

	internal static Bitmap arrow => (Bitmap)ResourceManager.GetObject("arrow", cultureInfo_0);

	internal static Bitmap close => (Bitmap)ResourceManager.GetObject("close", cultureInfo_0);

	internal static Bitmap close_selected => (Bitmap)ResourceManager.GetObject("close_selected", cultureInfo_0);

	internal static Bitmap inactive_close => (Bitmap)ResourceManager.GetObject("inactive_close", cultureInfo_0);

	internal static Bitmap inactive_close_selected => (Bitmap)ResourceManager.GetObject("inactive_close_selected", cultureInfo_0);

	internal static Bitmap tw_active_close => (Bitmap)ResourceManager.GetObject("tw_active_close", cultureInfo_0);

	internal static Bitmap tw_active_close_selected => (Bitmap)ResourceManager.GetObject("tw_active_close_selected", cultureInfo_0);

	internal static Bitmap tw_close => (Bitmap)ResourceManager.GetObject("tw_close", cultureInfo_0);

	internal static Bitmap tw_close_selected => (Bitmap)ResourceManager.GetObject("tw_close_selected", cultureInfo_0);

	internal DockIcons()
	{
	}

	static DockIcons()
	{
		Class72.smethod_20();
		Class77.smethod_3();
	}
}
