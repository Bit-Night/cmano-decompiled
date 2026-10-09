using System.Runtime.CompilerServices;

namespace Command;

public sealed class GClass0
{
	public string Text;

	public object Value;

	public GClass0(string theText, object theValue)
	{
		Text = theText;
		Value = RuntimeHelpers.GetObjectValue(theValue);
	}

	public override string ToString()
	{
		return Text;
	}

	static GClass0()
	{
		Class72.smethod_20();
	}
}
