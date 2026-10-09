using System;

namespace Command.SmartAssembly.Attributes;

[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Parameter | AttributeTargets.Delegate)]
public sealed class DoNotPruneAttribute : Attribute
{
	static DoNotPruneAttribute()
	{
		Class72.smethod_20();
	}
}
