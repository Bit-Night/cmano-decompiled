namespace Command_Core;

public class ErrorForm
{
	public static void Open(ExceptionEntry entry, string CustomContent = "")
	{
		GlobalSingleton.GetInstance().CrossThreadErrorDispatch_entry.Add((entry, CustomContent));
	}

	public static void Open(string entry)
	{
		GlobalSingleton.GetInstance().CrossThreadErrorDispatch_str.Add(entry);
	}

	static ErrorForm()
	{
		Class72.smethod_20();
	}
}
