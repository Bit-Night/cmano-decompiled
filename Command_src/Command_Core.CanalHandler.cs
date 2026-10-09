using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class CanalHandler
{
	private static Canal_Panama canal_Panama_0;

	private static Canal_Suez canal_Suez_0;

	private static Canal_Dardanelles canal_Dardanelles_0;

	private static Canal_Bosphorus canal_Bosphorus_0;

	internal static Canal_Panama Canal_Panama()
	{
		if (canal_Panama_0 == null)
		{
			canal_Panama_0 = new Canal_Panama();
		}
		return canal_Panama_0;
	}

	internal static Canal_Suez Canal_Suez()
	{
		if (canal_Suez_0 == null)
		{
			canal_Suez_0 = new Canal_Suez();
		}
		return canal_Suez_0;
	}

	internal static Canal_Dardanelles Canal_Dardanelles()
	{
		if (canal_Dardanelles_0 == null)
		{
			canal_Dardanelles_0 = new Canal_Dardanelles();
		}
		return canal_Dardanelles_0;
	}

	internal static Canal_Bosphorus Canal_Bosphorus()
	{
		if (canal_Bosphorus_0 == null)
		{
			canal_Bosphorus_0 = new Canal_Bosphorus();
		}
		return canal_Bosphorus_0;
	}

	static CanalHandler()
	{
		Class72.smethod_20();
	}
}
