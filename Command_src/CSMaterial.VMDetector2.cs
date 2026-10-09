using System.Management;

namespace CSMaterial;

public static class VMDetector2
{
	public static bool RunningInVm()
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		return new ManagementObjectSearcher("SELECT * FROM Win32_PortConnector").Get().Count == 0;
	}

	static VMDetector2()
	{
		Class72.smethod_20();
	}
}
