using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Collections.Pooled;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EventExporter_TacviewPipe : EventExporter_Tacview2x
{
	public delegate void PipeTelemetryToTacviewEventHandler(List<(string, IEventExporter.EventExportNotification)> tupleList);

	public bool PipeClientsPresent;

	public bool InitializingScenario;

	private ConcurrentQueue<(string, IEventExporter.EventExportNotification)> concurrentQueue_1;

	private Thread thread_1;

	private Scenario scenario_0;

	public Dictionary<string, long> DeclaredUnits;

	[CompilerGenerated]
	private PipeTelemetryToTacviewEventHandler pipeTelemetryToTacviewEventHandler_0;

	private LockObject lockObject_1;

	private bool bool_18;

	public override bool IsOperating
	{
		get
		{
			return bool_18;
		}
		set
		{
			bool_18 = value;
		}
	}

	public override int QueueLength => concurrentQueue_1.Count;

	public override string Name => "TacviewPipe";

	public override IEventExporter.EventExporterType ExporterType => IEventExporter.EventExporterType.TacviewPipe;

	public event PipeTelemetryToTacviewEventHandler PipeTelemetryToTacview
	{
		[CompilerGenerated]
		add
		{
			PipeTelemetryToTacviewEventHandler pipeTelemetryToTacviewEventHandler = pipeTelemetryToTacviewEventHandler_0;
			PipeTelemetryToTacviewEventHandler pipeTelemetryToTacviewEventHandler2;
			do
			{
				pipeTelemetryToTacviewEventHandler2 = pipeTelemetryToTacviewEventHandler;
				PipeTelemetryToTacviewEventHandler value2 = (PipeTelemetryToTacviewEventHandler)Delegate.Combine(pipeTelemetryToTacviewEventHandler2, value);
				pipeTelemetryToTacviewEventHandler = Interlocked.CompareExchange(ref pipeTelemetryToTacviewEventHandler_0, value2, pipeTelemetryToTacviewEventHandler2);
			}
			while ((object)pipeTelemetryToTacviewEventHandler != pipeTelemetryToTacviewEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PipeTelemetryToTacviewEventHandler pipeTelemetryToTacviewEventHandler = pipeTelemetryToTacviewEventHandler_0;
			PipeTelemetryToTacviewEventHandler pipeTelemetryToTacviewEventHandler2;
			do
			{
				pipeTelemetryToTacviewEventHandler2 = pipeTelemetryToTacviewEventHandler;
				PipeTelemetryToTacviewEventHandler value2 = (PipeTelemetryToTacviewEventHandler)Delegate.Remove(pipeTelemetryToTacviewEventHandler2, value);
				pipeTelemetryToTacviewEventHandler = Interlocked.CompareExchange(ref pipeTelemetryToTacviewEventHandler_0, value2, pipeTelemetryToTacviewEventHandler2);
			}
			while ((object)pipeTelemetryToTacviewEventHandler != pipeTelemetryToTacviewEventHandler2);
		}
	}

	public void DestroyCache()
	{
		lock (lockObject_1)
		{
			concurrentQueue_1 = new ConcurrentQueue<(string, IEventExporter.EventExportNotification)>();
			DeclaredUnits = new Dictionary<string, long>();
		}
	}

	public EventExporter_TacviewPipe(IEventExporter.EventExporterRunMode theRunMode)
		: base(theRunMode, null)
	{
		InitializingScenario = false;
		concurrentQueue_1 = new ConcurrentQueue<(string, IEventExporter.EventExportNotification)>();
		DeclaredUnits = new Dictionary<string, long>();
		lockObject_1 = new LockObject();
		base.ExportEngagementCycle = false;
	}

	public override void Start()
	{
		lock (lockObject_1)
		{
			if (thread_1 == null)
			{
				thread_1 = new Thread(method_5);
				thread_1.Name = "EventExporter_TacviewPipe Thread";
				thread_1.Priority = ThreadPriority.Normal;
				thread_1.Start();
			}
		}
	}

	private void method_5()
	{
		while (true)
		{
			method_6();
			Thread.Sleep(50);
		}
	}

	public override void ExportEvent(IEventExporter.ExportedEventType theEventType, PooledDictionary<string, IEventExporter.EventNotificationParameter> EventParameters, Scenario theScen)
	{
		if (PipeClientsPresent && (InitializingScenario || (theEventType != IEventExporter.ExportedEventType.UnitPositions && theEventType != IEventExporter.ExportedEventType.ContactPositions) || theScen.Time.Second % theScen.TimeCompression_SimSeconds == 0))
		{
			IEventExporter.EventExportNotification eventExportNotification = new IEventExporter.EventExportNotification();
			eventExportNotification.EventType = theEventType;
			eventExportNotification.EventParameters = EventParameters;
			eventExportNotification.ParentScen = theScen;
			string eventString = EventExporter_Tacview2x.GetEventString(eventExportNotification, DeclaredUnits, ref LastPrintedTimeString, NewUnitCache);
			concurrentQueue_1.Enqueue((eventString, eventExportNotification));
		}
	}

	private void method_6()
	{
		try
		{
			List<(string, IEventExporter.EventExportNotification)> list = new List<(string, IEventExporter.EventExportNotification)>(concurrentQueue_1.Count * 2);
			while (concurrentQueue_1.Count > 0)
			{
				concurrentQueue_1.TryDequeue(out var result);
				list.Add(result);
			}
			if (list.Any())
			{
				pipeTelemetryToTacviewEventHandler_0?.Invoke(list);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void StopCleanUpAndReset()
	{
		lock (lockObject_1)
		{
			Debugger.Break();
		}
	}

	public override void SetScenario(Scenario theScen)
	{
		int num = theScen.ActiveUnits_List.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			if (!theScen.ActiveUnits_List.ElementAt(i).IsGroup)
			{
				theScen.ActiveUnits_List.ElementAt(i).Kinematics.ExportLocationEvent("SetScenario");
			}
		}
		scenario_0 = theScen;
	}

	static EventExporter_TacviewPipe()
	{
		Class72.smethod_20();
	}
}
