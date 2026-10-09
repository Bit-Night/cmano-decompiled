using System;

namespace SmartAssembly.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface)]
public sealed class DoNotPruneTypeAttribute : Attribute
{
	static DoNotPruneTypeAttribute()
	{
		Class72.smethod_20();
	}
}
