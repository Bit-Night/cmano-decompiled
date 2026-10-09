using System.Windows.Forms;
using Command_Core;

namespace Command;

public sealed class DBViewer
{
	private static LockObject lockObject_0;

	static DBViewer()
	{
		Class72.smethod_20();
		lockObject_0 = new LockObject();
	}

	public static void OpenNewDatabaseWindow()
	{
		OpenNewDatabaseWindow(null, 0);
	}

	public static void OpenNewDatabaseWindow(string SelectedObjectType, int selectedObjectID, string HighlightTarget = null)
	{
		lock (lockObject_0)
		{
			((Control)new InternalDBViewer
			{
				SelectedObjectType = SelectedObjectType,
				selectedSubType = -1,
				SelectedObjectID = selectedObjectID,
				HighlightTarget = HighlightTarget
			}).Show();
		}
	}

	private static void smethod_0()
	{
	}
}
