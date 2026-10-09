using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.ServiceProcess;
using SmartAssembly.Attributes;

[DoNotPruneTypeAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
[DoNotObfuscateTypeAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
[DoNotPruneAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
public sealed class VirtualMachineDetector
{
	private static Interface1[] interface1_0;

	private static ComputerSystem computerSystem_0;

	private static BIOS bios_0;

	private static MotherboardDevice motherboardDevice_0;

	private static IEnumerable<DiskDrive> ienumerable_0;

	private static IEnumerable<PnPEntity> ienumerable_1;

	private static IEnumerable<WindowsService> ienumerable_2;

	[DoNotPruneAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
	static VirtualMachineDetector()
	{
		Class72.smethod_20();
		interface1_0 = new Interface1[4]
		{
			new VmWarePlayer(),
			new HyperVMachine(),
			new QEmuMachine(),
			new VirtualBoxMachine()
		};
		computerSystem_0 = Create<ComputerSystem>("Win32_ComputerSystem");
		bios_0 = Create<BIOS>("Win32_BIOS");
		motherboardDevice_0 = Create<MotherboardDevice>("Win32_MotherboardDevice");
		ienumerable_1 = smethod_1<PnPEntity>("Win32_PnPEntity");
		ienumerable_0 = smethod_1<DiskDrive>("Win32_DiskDrive");
		ienumerable_2 = smethod_0();
	}

	public static bool Assert(out string name)
	{
		string[] string_0 = (from p in Process.GetProcesses()
			select p.ProcessName.ToLower() into p
			orderby p
			select p).ToArray();
		Interface1 @interface = interface1_0.FirstOrDefault((Interface1 c) => c.Assert(computerSystem_0, bios_0, ienumerable_0, ienumerable_1, string_0, ienumerable_2));
		bool flag = @interface != null;
		name = (flag ? @interface.Name : null);
		return flag;
	}

	public static bool Assert()
	{
		string name;
		return Assert(out name);
	}

	private static IEnumerable<WindowsService> smethod_0()
	{
		return (from s in ServiceController.GetServices()
			select new WindowsService(s) into s
			orderby s.Name
			select s).ToArray();
	}

	private static T Create<T>(string key)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		ManagementObjectEnumerator enumerator = new ManagementClass(key).GetInstances().GetEnumerator();
		try
		{
			if (enumerator.MoveNext())
			{
				ManagementBaseObject current = enumerator.Current;
				return (T)Activator.CreateInstance(typeof(T), current);
			}
		}
		finally
		{
			((IDisposable)enumerator)?.Dispose();
		}
		return default(T);
	}

	private static List<T> smethod_1<T>(string string_0)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		ManagementClass val = new ManagementClass(string_0);
		List<T> list = new List<T>();
		ManagementObjectEnumerator enumerator = val.GetInstances().GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				ManagementBaseObject current = enumerator.Current;
				list.Add((T)Activator.CreateInstance(typeof(T), current));
			}
			return list;
		}
		finally
		{
			((IDisposable)enumerator)?.Dispose();
		}
	}
}
