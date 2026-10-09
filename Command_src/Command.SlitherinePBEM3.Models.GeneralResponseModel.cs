namespace Command.SlitherinePBEM3.Models;

internal class GeneralResponseModel<T>
{
	public Message Message;

	public T Result;

	internal static object object_0;

	static GeneralResponseModel()
	{
		Class72.smethod_20();
	}

	internal static bool smethod_0()
	{
		return object_0 == null;
	}

	internal static object smethod_1()
	{
		return object_0;
	}
}
