using System.IO;
using Command_Core.My;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.Devices;

namespace Command_Core;

public sealed class OnStartForcedLocalChange
{
	private static OnStartForcedLocalChange onStartForcedLocalChange_0;

	private string string_0;

	static OnStartForcedLocalChange()
	{
		Class72.smethod_20();
		onStartForcedLocalChange_0 = null;
	}

	private void method_0(string string_1)
	{
		ref string reference = ref string_0;
		reference = reference + string_1 + "\r\n";
	}

	private void method_1()
	{
		StreamWriter streamWriter = ((ServerComputer)MyProject.Computer).FileSystem.OpenTextFileWriter(GameGeneral.TopLevelWritablePath + Conversions.ToString(Path.DirectorySeparatorChar) + "VersionForcedChanges.txt", false);
		streamWriter.WriteLine(string_0);
		streamWriter.Close();
	}

	private OnStartForcedLocalChange()
	{
	}

	public static OnStartForcedLocalChange GetInstance()
	{
		if (onStartForcedLocalChange_0 == null)
		{
			onStartForcedLocalChange_0 = new OnStartForcedLocalChange();
		}
		return onStartForcedLocalChange_0;
	}
}
