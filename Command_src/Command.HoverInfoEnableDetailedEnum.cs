using System.ComponentModel;
using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotObfuscate]
[DoNotPruneType]
[TypeConverter(typeof(HoverInfoEnumConverter))]
[DoNotPrune]
public enum HoverInfoEnableDetailedEnum
{
	[Description("Show Detailed")]
	ShowDetailed,
	[Description("Show Summary")]
	ShowSummary,
	[Description("Hide")]
	Hide
}
