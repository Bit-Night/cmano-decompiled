using System;
using System.Collections.Generic;

namespace Command_Core;

public class AggregateGroundUnitEngagementLog
{
	public DateTime Time;

	public List<string> Logs;

	public ActiveUnit Opponent;

	public AggregateGroundUnitEngagementLog()
	{
		Logs = new List<string>();
	}

	public void AddLog(string Text)
	{
		Logs.Add(Text);
	}

	public void PrintLog()
	{
	}

	static AggregateGroundUnitEngagementLog()
	{
		Class72.smethod_20();
	}
}
