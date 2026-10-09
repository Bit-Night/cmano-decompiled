using System;

namespace SmartAssembly.Attributes;

[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method)]
public sealed class DoNotEncodeStringsAttribute : Attribute
{
	static DoNotEncodeStringsAttribute()
	{
		Class72.smethod_20();
	}
}
