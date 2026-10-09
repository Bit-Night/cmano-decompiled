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
internal class MessageBoxIcons
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
				resourceManager_0 = new ResourceManager("CSMaterial.DarkUI.Icons.MessageBoxIcons", typeof(MessageBoxIcons).Assembly);
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

	internal static Bitmap error => (Bitmap)ResourceManager.GetObject("error", cultureInfo_0);

	internal static Bitmap info => (Bitmap)ResourceManager.GetObject("info", cultureInfo_0);

	internal static Bitmap warning => (Bitmap)ResourceManager.GetObject("warning", cultureInfo_0);

	internal MessageBoxIcons()
	{
	}

	static MessageBoxIcons()
	{
		Class72.smethod_20();
		Class77.smethod_3();
	}
}
