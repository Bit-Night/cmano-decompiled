using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace DarkUI;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
[CompilerGenerated]
[DebuggerNonUserCode]
public sealed class MenuIcons
{
	private static ResourceManager resourceManager_0;

	private static CultureInfo cultureInfo_0;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public static ResourceManager ResourceManager
	{
		get
		{
			if (resourceManager_0 == null)
			{
				resourceManager_0 = new ResourceManager("CSMaterial.DarkUI.Icons.MenuIcons", typeof(MenuIcons).Assembly);
			}
			return resourceManager_0;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public static CultureInfo Culture
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

	public static Bitmap grip => (Bitmap)ResourceManager.GetObject("grip", cultureInfo_0);

	public static Bitmap tick => (Bitmap)ResourceManager.GetObject("tick", cultureInfo_0);

	internal MenuIcons()
	{
	}

	static MenuIcons()
	{
		Class72.smethod_20();
		Class77.smethod_3();
	}
}
