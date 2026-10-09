using System.ComponentModel;
using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotObfuscate]
[DoNotPrune]
[DoNotPruneType]
[TypeConverter(typeof(HoverInfoEnumConverter))]
public enum HoverInfoEnableEnum
{
	[Description("Show")]
	Show = 0,
	[Description("Hide")]
	Hide = 2
}
