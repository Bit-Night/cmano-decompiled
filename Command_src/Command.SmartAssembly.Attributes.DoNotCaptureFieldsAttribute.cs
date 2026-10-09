using System;

namespace Command.SmartAssembly.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = true)]
public sealed class DoNotCaptureFieldsAttribute : Attribute
{
	static DoNotCaptureFieldsAttribute()
	{
		Class72.smethod_20();
	}
}
