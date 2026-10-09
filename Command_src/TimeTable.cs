using System.Collections.Generic;
using System.Runtime.CompilerServices;

public static class TimeTable
{
	[CompilerGenerated]
	private static readonly List<TimeTableMasterItem> list_0;

	[CompilerGenerated]
	private static readonly List<TimeTableItem> list_1;

	public static List<TimeTableMasterItem> MasterItems
	{
		[CompilerGenerated]
		get
		{
			return list_0;
		}
	}

	public static List<TimeTableItem> Items
	{
		[CompilerGenerated]
		get
		{
			return list_1;
		}
	}

	static TimeTable()
	{
		Class72.smethod_20();
		list_0 = new List<TimeTableMasterItem>();
		list_1 = new List<TimeTableItem>();
		list_0.Add(new TimeTableMasterItem
		{
			Type = "TACTICAL",
			Warfare = "AAW",
			CodeName = "TAC-A1",
			DeltaT = 30.0,
			ReactSpeed_SLOW = 15.0,
			ReactSpeed_DEFAULT = 12.0,
			ReactSpeed_FAST = 9.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "SLOW",
			Warfare = "AAW",
			CodeName = "TAC-A1",
			DeltaT = 30.0,
			ReactSpeed = 15.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "MEDIUM",
			Warfare = "AAW",
			CodeName = "TAC-A1",
			DeltaT = 30.0,
			ReactSpeed = 12.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "FAST",
			Warfare = "AAW",
			CodeName = "TAC-A1",
			DeltaT = 30.0,
			ReactSpeed = 9.0,
			Remarks = ""
		});
		list_0.Add(new TimeTableMasterItem
		{
			Type = "TACTICAL",
			Warfare = "AAW",
			CodeName = "TAC-A2",
			DeltaT = 60.0,
			ReactSpeed_SLOW = 30.0,
			ReactSpeed_DEFAULT = 24.0,
			ReactSpeed_FAST = 18.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "SLOW",
			Warfare = "AAW",
			CodeName = "TAC-A2",
			DeltaT = 60.0,
			ReactSpeed = 30.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "MEDIUM",
			Warfare = "AAW",
			CodeName = "TAC-A2",
			DeltaT = 60.0,
			ReactSpeed = 24.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "FAST",
			Warfare = "AAW",
			CodeName = "TAC-A2",
			DeltaT = 60.0,
			ReactSpeed = 18.0,
			Remarks = ""
		});
		list_0.Add(new TimeTableMasterItem
		{
			Type = "TACTICAL",
			Warfare = "AAW",
			CodeName = "TAC-A2",
			DeltaT = 90.0,
			ReactSpeed_SLOW = 45.0,
			ReactSpeed_DEFAULT = 36.0,
			ReactSpeed_FAST = 27.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "SLOW",
			Warfare = "AAW",
			CodeName = "TAC-A2",
			DeltaT = 90.0,
			ReactSpeed = 45.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "MEDIUM",
			Warfare = "AAW",
			CodeName = "TAC-A2",
			DeltaT = 90.0,
			ReactSpeed = 36.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "FAST",
			Warfare = "AAW",
			CodeName = "TAC-A2",
			DeltaT = 90.0,
			ReactSpeed = 27.0,
			Remarks = ""
		});
		list_0.Add(new TimeTableMasterItem
		{
			Type = "TACTICAL",
			Warfare = "ALL",
			CodeName = "TAC-B1",
			DeltaT = 120.0,
			ReactSpeed_SLOW = 60.0,
			ReactSpeed_DEFAULT = 30.0,
			ReactSpeed_FAST = 48.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "SLOW",
			Warfare = "ALL",
			CodeName = "TAC-B1",
			DeltaT = 120.0,
			ReactSpeed = 60.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "MEDIUM",
			Warfare = "ALL",
			CodeName = "TAC-B1",
			DeltaT = 120.0,
			ReactSpeed = 30.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "FAST",
			Warfare = "ALL",
			CodeName = "TAC-B1",
			DeltaT = 120.0,
			ReactSpeed = 48.0,
			Remarks = ""
		});
		list_0.Add(new TimeTableMasterItem
		{
			Type = "TACTICAL",
			Warfare = "ALL",
			CodeName = "TAC-B2",
			DeltaT = 180.0,
			ReactSpeed_SLOW = 90.0,
			ReactSpeed_DEFAULT = 45.0,
			ReactSpeed_FAST = 64.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "SLOW",
			Warfare = "ALL",
			CodeName = "TAC-B2",
			DeltaT = 180.0,
			ReactSpeed = 90.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "MEDIUM",
			Warfare = "ALL",
			CodeName = "TAC-B2",
			DeltaT = 180.0,
			ReactSpeed = 45.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "FAST",
			Warfare = "ALL",
			CodeName = "TAC-B2",
			DeltaT = 180.0,
			ReactSpeed = 64.0,
			Remarks = ""
		});
		list_0.Add(new TimeTableMasterItem
		{
			Type = "TACTICAL",
			Warfare = "ALL",
			CodeName = "TAC-B3",
			DeltaT = 240.0,
			ReactSpeed_SLOW = 120.0,
			ReactSpeed_DEFAULT = 96.0,
			ReactSpeed_FAST = 72.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "SLOW",
			Warfare = "ALL",
			CodeName = "TAC-B3",
			DeltaT = 240.0,
			ReactSpeed = 120.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "MEDIUM",
			Warfare = "ALL",
			CodeName = "TAC-B3",
			DeltaT = 240.0,
			ReactSpeed = 96.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "FAST",
			Warfare = "ALL",
			CodeName = "TAC-B3",
			DeltaT = 240.0,
			ReactSpeed = 72.0,
			Remarks = ""
		});
		list_0.Add(new TimeTableMasterItem
		{
			Type = "TACTICAL",
			Warfare = "default",
			CodeName = "TAC-DFT",
			DeltaT = 300.0,
			ReactSpeed_SLOW = 150.0,
			ReactSpeed_DEFAULT = 120.0,
			ReactSpeed_FAST = 90.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "SLOW",
			Warfare = "default",
			CodeName = "TAC-DFT",
			DeltaT = 300.0,
			ReactSpeed = 150.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "MEDIUM",
			Warfare = "default",
			CodeName = "TAC-DFT",
			DeltaT = 300.0,
			ReactSpeed = 120.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "FAST",
			Warfare = "default",
			CodeName = "TAC-DFT",
			DeltaT = 300.0,
			ReactSpeed = 90.0,
			Remarks = ""
		});
		list_0.Add(new TimeTableMasterItem
		{
			Type = "TACTICAL",
			Warfare = "ASW/SUW",
			CodeName = "TAC-C1",
			DeltaT = 360.0,
			ReactSpeed_SLOW = 180.0,
			ReactSpeed_DEFAULT = 144.0,
			ReactSpeed_FAST = 108.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "SLOW",
			Warfare = "ASW/SUW",
			CodeName = "TAC-C1",
			DeltaT = 360.0,
			ReactSpeed = 180.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "MEDIUM",
			Warfare = "ASW/SUW",
			CodeName = "TAC-C1",
			DeltaT = 360.0,
			ReactSpeed = 144.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "FAST",
			Warfare = "ASW/SUW",
			CodeName = "TAC-C1",
			DeltaT = 360.0,
			ReactSpeed = 108.0,
			Remarks = ""
		});
		list_0.Add(new TimeTableMasterItem
		{
			Type = "TACTICAL",
			Warfare = "ASW/SUW",
			CodeName = "TAC-C2",
			DeltaT = 480.0,
			ReactSpeed_SLOW = 240.0,
			ReactSpeed_DEFAULT = 192.0,
			ReactSpeed_FAST = 144.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "SLOW",
			Warfare = "ASW/SUW",
			CodeName = "TAC-C2",
			DeltaT = 480.0,
			ReactSpeed = 240.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "MEDIUM",
			Warfare = "ASW/SUW",
			CodeName = "TAC-C2",
			DeltaT = 480.0,
			ReactSpeed = 192.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "FAST",
			Warfare = "ASW/SUW",
			CodeName = "TAC-C2",
			DeltaT = 480.0,
			ReactSpeed = 144.0,
			Remarks = ""
		});
		list_0.Add(new TimeTableMasterItem
		{
			Type = "TACTICAL",
			Warfare = "ASW/SUW",
			CodeName = "TAC-C3",
			DeltaT = 600.0,
			ReactSpeed_SLOW = 300.0,
			ReactSpeed_DEFAULT = 240.0,
			ReactSpeed_FAST = 180.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "SLOW",
			Warfare = "ASW/SUW",
			CodeName = "TAC-C3",
			DeltaT = 600.0,
			ReactSpeed = 300.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "MEDIUM",
			Warfare = "ASW/SUW",
			CodeName = "TAC-C3",
			DeltaT = 600.0,
			ReactSpeed = 240.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "FAST",
			Warfare = "ASW/SUW",
			CodeName = "TAC-C3",
			DeltaT = 600.0,
			ReactSpeed = 180.0,
			Remarks = ""
		});
		list_0.Add(new TimeTableMasterItem
		{
			Type = "OPERATIONAL",
			Warfare = "SMALL",
			CodeName = "OPS-D1",
			DeltaT = 900.0,
			ReactSpeed_SLOW = 450.0,
			ReactSpeed_DEFAULT = 360.0,
			ReactSpeed_FAST = 270.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "SLOW",
			Warfare = "SMALL",
			CodeName = "OPS-D1",
			DeltaT = 900.0,
			ReactSpeed = 450.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "MEDIUM",
			Warfare = "SMALL",
			CodeName = "OPS-D1",
			DeltaT = 900.0,
			ReactSpeed = 360.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "FAST",
			Warfare = "SMALL",
			CodeName = "OPS-D1",
			DeltaT = 900.0,
			ReactSpeed = 270.0,
			Remarks = ""
		});
		list_0.Add(new TimeTableMasterItem
		{
			Type = "OPERATIONAL",
			Warfare = "SMALL",
			CodeName = "OPS-D2",
			DeltaT = 1200.0,
			ReactSpeed_SLOW = 600.0,
			ReactSpeed_DEFAULT = 480.0,
			ReactSpeed_FAST = 360.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "SLOW",
			Warfare = "SMALL",
			CodeName = "OPS-D2",
			DeltaT = 1200.0,
			ReactSpeed = 600.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "MEDIUM",
			Warfare = "SMALL",
			CodeName = "OPS-D2",
			DeltaT = 1200.0,
			ReactSpeed = 480.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "FAST",
			Warfare = "SMALL",
			CodeName = "OPS-D2",
			DeltaT = 1200.0,
			ReactSpeed = 360.0,
			Remarks = ""
		});
		list_0.Add(new TimeTableMasterItem
		{
			Type = "OPERATIONAL",
			Warfare = "SMALL",
			CodeName = "OPS-D3",
			DeltaT = 1500.0,
			ReactSpeed_SLOW = 750.0,
			ReactSpeed_DEFAULT = 600.0,
			ReactSpeed_FAST = 450.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "SLOW",
			Warfare = "SMALL",
			CodeName = "OPS-D3",
			DeltaT = 1500.0,
			ReactSpeed = 750.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "MEDIUM",
			Warfare = "SMALL",
			CodeName = "OPS-D3",
			DeltaT = 1500.0,
			ReactSpeed = 600.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "FAST",
			Warfare = "SMALL",
			CodeName = "OPS-D3",
			DeltaT = 1500.0,
			ReactSpeed = 450.0,
			Remarks = ""
		});
		list_0.Add(new TimeTableMasterItem
		{
			Type = "OPERATIONAL",
			Warfare = "DEFAULT",
			CodeName = "OPS-DFT",
			DeltaT = 1800.0,
			ReactSpeed_SLOW = 900.0,
			ReactSpeed_DEFAULT = 720.0,
			ReactSpeed_FAST = 540.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "SLOW",
			Warfare = "DEFAULT",
			CodeName = "OPS-DFT",
			DeltaT = 1800.0,
			ReactSpeed = 900.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "MEDIUM",
			Warfare = "DEFAULT",
			CodeName = "OPS-DFT",
			DeltaT = 1800.0,
			ReactSpeed = 720.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "FAST",
			Warfare = "DEFAULT",
			CodeName = "OPS-DFT",
			DeltaT = 1800.0,
			ReactSpeed = 540.0,
			Remarks = ""
		});
		list_0.Add(new TimeTableMasterItem
		{
			Type = "OPERATIONAL",
			Warfare = "LARGE",
			CodeName = "OPS-E1",
			DeltaT = 2700.0,
			ReactSpeed_SLOW = 1350.0,
			ReactSpeed_DEFAULT = 1080.0,
			ReactSpeed_FAST = 810.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "SLOW",
			Warfare = "LARGE",
			CodeName = "OPS-E1",
			DeltaT = 2700.0,
			ReactSpeed = 1350.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "MEDIUM",
			Warfare = "LARGE",
			CodeName = "OPS-E1",
			DeltaT = 2700.0,
			ReactSpeed = 1080.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "FAST",
			Warfare = "LARGE",
			CodeName = "OPS-E1",
			DeltaT = 2700.0,
			ReactSpeed = 810.0,
			Remarks = ""
		});
		list_0.Add(new TimeTableMasterItem
		{
			Type = "OPERATIONAL",
			Warfare = "LARGE",
			CodeName = "OPS-E2",
			DeltaT = 3600.0,
			ReactSpeed_SLOW = 1800.0,
			ReactSpeed_DEFAULT = 1440.0,
			ReactSpeed_FAST = 1080.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "SLOW",
			Warfare = "LARGE",
			CodeName = "OPS-E2",
			DeltaT = 3600.0,
			ReactSpeed = 1800.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "MEDIUM",
			Warfare = "LARGE",
			CodeName = "OPS-E2",
			DeltaT = 3600.0,
			ReactSpeed = 1440.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "FAST",
			Warfare = "LARGE",
			CodeName = "OPS-E2",
			DeltaT = 3600.0,
			ReactSpeed = 1080.0,
			Remarks = ""
		});
		list_0.Add(new TimeTableMasterItem
		{
			Type = "OPERATIONAL",
			Warfare = "LARGE",
			CodeName = "OPS-E3",
			DeltaT = 5400.0,
			ReactSpeed_SLOW = 2700.0,
			ReactSpeed_DEFAULT = 2160.0,
			ReactSpeed_FAST = 1620.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "SLOW",
			Warfare = "LARGE",
			CodeName = "OPS-E3",
			DeltaT = 5400.0,
			ReactSpeed = 2700.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "MEDIUM",
			Warfare = "LARGE",
			CodeName = "OPS-E3",
			DeltaT = 5400.0,
			ReactSpeed = 2160.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "FAST",
			Warfare = "LARGE",
			CodeName = "OPS-E3",
			DeltaT = 5400.0,
			ReactSpeed = 1620.0,
			Remarks = ""
		});
		list_0.Add(new TimeTableMasterItem
		{
			Type = "STRATEGIC",
			Warfare = "ALL",
			CodeName = "STR-F1",
			DeltaT = 7200.0,
			ReactSpeed_SLOW = 3240.0,
			ReactSpeed_DEFAULT = 2700.0,
			ReactSpeed_FAST = 2160.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "SLOW",
			Warfare = "ALL",
			CodeName = "STR-F1",
			DeltaT = 7200.0,
			ReactSpeed = 3240.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "MEDIUM",
			Warfare = "ALL",
			CodeName = "STR-F1",
			DeltaT = 7200.0,
			ReactSpeed = 2700.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "FAST",
			Warfare = "ALL",
			CodeName = "STR-F1",
			DeltaT = 7200.0,
			ReactSpeed = 2160.0,
			Remarks = ""
		});
		list_0.Add(new TimeTableMasterItem
		{
			Type = "STRATEGIC",
			Warfare = "ALL",
			CodeName = "STR-F2",
			DeltaT = 10800.0,
			ReactSpeed_SLOW = 4320.0,
			ReactSpeed_DEFAULT = 3600.0,
			ReactSpeed_FAST = 2880.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "SLOW",
			Warfare = "ALL",
			CodeName = "STR-F2",
			DeltaT = 10800.0,
			ReactSpeed = 4320.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "MEDIUM",
			Warfare = "ALL",
			CodeName = "STR-F2",
			DeltaT = 10800.0,
			ReactSpeed = 3600.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "FAST",
			Warfare = "ALL",
			CodeName = "STR-F2",
			DeltaT = 10800.0,
			ReactSpeed = 2880.0,
			Remarks = ""
		});
		list_0.Add(new TimeTableMasterItem
		{
			Type = "STRATEGIC",
			Warfare = "ALL",
			CodeName = "STR-F3",
			DeltaT = 14400.0,
			ReactSpeed_SLOW = 6480.0,
			ReactSpeed_DEFAULT = 5400.0,
			ReactSpeed_FAST = 4320.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "SLOW",
			Warfare = "ALL",
			CodeName = "STR-F3",
			DeltaT = 14400.0,
			ReactSpeed = 6480.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "MEDIUM",
			Warfare = "ALL",
			CodeName = "STR-F3",
			DeltaT = 14400.0,
			ReactSpeed = 5400.0,
			Remarks = ""
		});
		list_1.Add(new TimeTableItem
		{
			Type = "FAST",
			Warfare = "ALL",
			CodeName = "STR-F3",
			DeltaT = 14400.0,
			ReactSpeed = 4320.0,
			Remarks = ""
		});
	}
}
