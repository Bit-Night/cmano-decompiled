using System;
using Command.SmartAssembly.Attributes;
using CommandNetcode.RT;

namespace Command;

[DoNotPruneType]
[DoNotPrune]
[DoNotObfuscate]
public interface IRTMPViewModel
{
	bool Loading { get; set; }

	bool IsDetached { get; set; }

	Guid Guid { get; set; }

	void imethod_0(UIMessage msg);

	void UITick();

	void UIResize();

	void UIDetach();
}
