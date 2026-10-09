using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace DotSpatial.Serialization.Properties;

[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
[CompilerGenerated]
internal sealed class Settings : ApplicationSettingsBase
{
	private static Settings defaultInstance;

	public static Settings Default => defaultInstance;

	static Settings()
	{
		Class72.smethod_20();
		defaultInstance = (Settings)(object)SettingsBase.Synchronized((SettingsBase)(object)new Settings());
	}
}
