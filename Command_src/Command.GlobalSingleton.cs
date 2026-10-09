using System.Collections.Generic;

namespace Command;

public sealed class GlobalSingleton
{
	private static GlobalSingleton globalSingleton_0;

	private List<InternalDBViewer> list_0;

	public List<Notification> NotificationContainer;

	static GlobalSingleton()
	{
		Class72.smethod_20();
		globalSingleton_0 = null;
	}

	private GlobalSingleton()
	{
		list_0 = new List<InternalDBViewer>();
		NotificationContainer = new List<Notification>();
	}

	public void method_0(InternalDBViewer Item)
	{
		list_0.Add(Item);
	}

	public InternalDBViewer GetLastOpenedDBViewer()
	{
		for (int i = list_0.Count - 1; i >= 0; i += -1)
		{
			if (list_0[i] == null || list_0[i]._IsDisposed)
			{
				list_0.RemoveAt(i);
			}
		}
		if (list_0.Count == 0)
		{
			return null;
		}
		return list_0[list_0.Count - 1];
	}

	public static GlobalSingleton GetInstance()
	{
		if (globalSingleton_0 == null)
		{
			globalSingleton_0 = new GlobalSingleton();
		}
		return globalSingleton_0;
	}
}
