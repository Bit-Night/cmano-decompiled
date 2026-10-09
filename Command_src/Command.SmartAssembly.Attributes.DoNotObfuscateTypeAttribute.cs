using System;

namespace Command.SmartAssembly.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface)]
public sealed class DoNotObfuscateTypeAttribute : Attribute
{
	static DoNotObfuscateTypeAttribute()
	{
		Class72.smethod_20();
	}
}
