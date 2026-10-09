using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Command.My.Resources;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
internal class FormationEditor
{
	private static ResourceManager xgakhPfh5;

	private static CultureInfo cultureInfo_0;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager
	{
		get
		{
			if (object.ReferenceEquals(xgakhPfh5, null))
			{
				xgakhPfh5 = new ResourceManager("Command.FormationEditor", typeof(FormationEditor).Assembly);
			}
			return xgakhPfh5;
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

	internal static Point CMenu_Unit_TrayLocation
	{
		get
		{
			object? objectValue = RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("CMenu_Unit.TrayLocation", cultureInfo_0));
			if (objectValue != null)
			{
				return (Point)objectValue;
			}
			return default(Point);
		}
	}

	internal static Point Timer1_TrayLocation
	{
		get
		{
			object? objectValue = RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("Timer1.TrayLocation", cultureInfo_0));
			if (objectValue != null)
			{
				return (Point)objectValue;
			}
			return default(Point);
		}
	}

	internal FormationEditor()
	{
	}

	static FormationEditor()
	{
		Class72.smethod_20();
		Class77.smethod_3();
	}
}
