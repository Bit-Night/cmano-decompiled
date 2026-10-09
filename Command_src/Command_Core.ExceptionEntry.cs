using System;
using System.Collections.Generic;

namespace Command_Core;

public class ExceptionEntry
{
	public List<DateTime> Occurrences;

	public int FuseOrder;

	public string Content;

	public bool Fused;

	public bool UI_Ignored;

	public double CurrentFuse => Math.Pow(20.0, FuseOrder);

	public ExceptionEntry(string _Content, DateTime _date)
	{
		Occurrences = new List<DateTime>();
		FuseOrder = 1;
		Content = _Content;
		AddOccurrences(_date);
	}

	public void AddOccurrences(DateTime thedate)
	{
		Occurrences.Add(thedate);
		if ((double)Occurrences.Count > CurrentFuse)
		{
			Fuse();
		}
	}

	public void Fuse()
	{
		GameGeneral.WriteExceptionsToLog(new Exception("!!!WARNING!!! EXCEPTION FUSE REACHED (x" + CurrentFuse + " exceptions) FOR : " + Content), RegisterThisException: true, OpenUI: true, NoFormating: true);
		Fused = true;
		FuseOrder++;
	}

	static ExceptionEntry()
	{
		Class72.smethod_20();
	}
}
