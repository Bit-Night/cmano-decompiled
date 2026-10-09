using System.ComponentModel.Design;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core.My;

[StandardModule]
[HideModuleName]
[CompilerGenerated]
[DebuggerNonUserCode]
internal sealed class MySettingsProperty
{
	[HelpKeyword("My.Settings")]
	internal static MySettings Settings => MySettings.Default;

	static MySettingsProperty()
	{
		Class72.smethod_20();
	}
}
