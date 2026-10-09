namespace DarkUI.Config;

public sealed class Consts
{
	public static int Padding;

	public static int ScrollBarSize;

	public static int ArrowButtonSize;

	public static int MinimumThumbSize;

	public static int CheckBoxSize;

	public static int RadioButtonSize;

	public const int ToolWindowHeaderSize = 25;

	public const int DocumentTabAreaSize = 24;

	public const int ToolWindowTabAreaSize = 21;

	static Consts()
	{
		Class72.smethod_20();
		Padding = 10;
		ScrollBarSize = 15;
		ArrowButtonSize = 15;
		MinimumThumbSize = 11;
		CheckBoxSize = 12;
		RadioButtonSize = 12;
	}
}
