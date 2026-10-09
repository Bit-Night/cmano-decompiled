using System;

namespace Command_Core.SmartAssembly.Attributes;

[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Method | AttributeTargets.Field | AttributeTargets.Interface | AttributeTargets.Delegate)]
public sealed class DoNotObfuscateAttribute : Attribute
{
	static DoNotObfuscateAttribute()
	{
		Class72.smethod_20();
	}
}
