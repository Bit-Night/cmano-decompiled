using System;

namespace SmartAssembly.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Method | AttributeTargets.Field | AttributeTargets.Interface)]
public sealed class ObfuscateToAttribute : Attribute
{
	public ObfuscateToAttribute(string newName)
	{
	}

	static ObfuscateToAttribute()
	{
		Class72.smethod_20();
	}
}
