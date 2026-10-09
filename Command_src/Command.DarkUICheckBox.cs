using System.ComponentModel;
using DarkUI.Controls;

namespace Command;

[DefaultEvent("CheckedChanged")]
[DefaultProperty("Checked")]
public sealed class DarkUICheckBox : DarkCheckBox
{
	static DarkUICheckBox()
	{
		Class72.smethod_20();
	}
}
