using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace DarkUI;

[DebuggerNonUserCode]
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
[CompilerGenerated]
internal class TreeViewIcons
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
				resourceManager_0 = new ResourceManager("CSMaterial.DarkUI.Icons.TreeViewIcons", typeof(TreeViewIcons).Assembly);
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

	internal static Bitmap node_closed_empty => (Bitmap)ResourceManager.GetObject("node_closed_empty", cultureInfo_0);

	internal static Bitmap node_closed_full => (Bitmap)ResourceManager.GetObject("node_closed_full", cultureInfo_0);

	internal static Bitmap node_open => (Bitmap)ResourceManager.GetObject("node_open", cultureInfo_0);

	internal static Bitmap node_open_empty => (Bitmap)ResourceManager.GetObject("node_open_empty", cultureInfo_0);

	internal TreeViewIcons()
	{
	}

	static TreeViewIcons()
	{
		Class72.smethod_20();
		Class77.smethod_3();
	}
}
