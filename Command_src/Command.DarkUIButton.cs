using System.ComponentModel;
using DarkUI.Controls;

namespace Command;

public sealed class DarkUIButton : DarkButton
{
	[Description("Gets or sets a value indicating whether the control can Rounded in corners.")]
	[Category("Custom")]
	public int RoundRadius
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	static DarkUIButton()
	{
		Class72.smethod_20();
	}
}
