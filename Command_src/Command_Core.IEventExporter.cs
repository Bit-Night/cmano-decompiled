using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using Collections.Pooled;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public interface IEventExporter
{
	[Serializable]
	public struct EventNotificationParameter
	{
		public object Value;

		public Type DataType;

		public int MaxStringLength;

		public EventNotificationParameter(object theValue, Type theDataType, int theMaxStringLength = 0)
		{
			this = default(EventNotificationParameter);
			Value = RuntimeHelpers.GetObjectValue(theValue);
			DataType = theDataType;
			MaxStringLength = theMaxStringLength;
		}

		static EventNotificationParameter()
		{
			Class72.smethod_20();
		}
	}

	public enum ExportedEventType
	{
		None = 0,
		WeaponFired = 1,
		WeaponEndgame = 2,
		FuelConsumed = 3,
		UnitDestroyed = 4,
		SensorDetectionAttempt = 5,
		const_6 = 6,
		UnitPositions = 7,
		EngagementCycle = 8,
		FuelTransfer = 9,
		WeaponImpact = 10,
		Explosion = 11,
		AirOps = 12,
		DockingOps = 13,
		WaterSplash = 14,
		ContactPositions = 15,
		SimExecution = 16,
		UnitPositions_Destruction = 17,
		UnitDamaged = 17,
		CargoTransfer = 18,
		ContactTransmission = 19,
		Max = 20
	}

	public enum EventExportOutputRate
	{
		Unknown = -1,
		Continuous,
		Secondx1,
		Secondx2,
		Secondx5,
		const_5,
		const_6,
		Minutex1,
		Minutex5,
		const_9,
		const_10,
		Hourx1,
		Hourx6,
		Hourx12,
		Hourx24,
		SimSpeed
	}

	public enum EventExporterRunMode
	{
		Interactive,
		NonInteractive
	}

	[Serializable]
	public sealed class EventExportNotification
	{
		public ExportedEventType EventType;

		public PooledDictionary<string, EventNotificationParameter> EventParameters;

		public string FileExportFolder;

		public Scenario ParentScen;

		internal byte[] ToByteArray()
		{
			if (this != null)
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				byte[] result;
				using (MemoryStream memoryStream = RCMS.recyclableMemoryStreamManager_0.GetStream())
				{
					binaryFormatter.Serialize(memoryStream, this);
					result = memoryStream.ToArray();
				}
				return result;
			}
			return null;
		}

		public static EventExportNotification FromByteArray(byte[] arrBytes)
		{
			EventExportNotification result;
			try
			{
				EventExportNotification eventExportNotification;
				using (MemoryStream memoryStream = RCMS.recyclableMemoryStreamManager_0.GetStream())
				{
					BinaryFormatter binaryFormatter = new BinaryFormatter();
					memoryStream.Write(arrBytes, 0, arrBytes.Length);
					memoryStream.Seek(0L, SeekOrigin.Begin);
					eventExportNotification = (EventExportNotification)binaryFormatter.Deserialize(memoryStream);
				}
				result = eventExportNotification;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = null;
				ProjectData.ClearProjectError();
			}
			return result;
		}

		static EventExportNotification()
		{
			Class72.smethod_20();
		}
	}

	public enum EventExporterType
	{
		None,
		XMLFile,
		CSVFile,
		MSAccess,
		const_4,
		const_5,
		TacviewRealtime,
		const_7,
		SQLite,
		TacviewPipe,
		SIMDIS
	}

	string Name { get; }

	int QueueLength { get; }

	string FileExportFolder { get; set; }

	EventExporterType ExporterType { get; }

	bool RequiresHeartbeatForStaticUnits { get; }

	bool UsesUnitMissionAndStatus { get; }

	bool UsesUnitDamage { get; }

	EventExporterRunMode RunMode { get; set; }

	bool IsOperating { get; set; }

	bool UsesRAMQueue { get; }

	bool UseZeroHour { get; set; }

	bool ExportSensorDetectionSuccess { get; set; }

	bool ExportSensorDetectionFailure { get; set; }

	bool ExportWeaponFired { get; set; }

	bool ExportWeaponEndgame { get; set; }

	bool ExportUnitPositions { get; set; }

	bool ExportEngagementCycle { get; set; }

	bool ExportUnitDestroyed { get; set; }

	bool ExportFuelConsumed { get; set; }

	bool ExportFuelTransfer { get; set; }

	bool ExportCargoTransfer { get; set; }

	bool ExportExplosions { get; set; }

	bool ExportWeaponImpacts { get; set; }

	bool ExportAirOps { get; set; }

	bool ExportDockingOps { get; set; }

	bool ExportUnitDamaged { get; set; }

	EventExporter_Common Common { get; set; }

	void ExportEvent(ExportedEventType theEventType, PooledDictionary<string, EventNotificationParameter> EventParameters, Scenario theScen);

	void Start();

	void SetScenario(Scenario theScen);

	void StopCleanUpAndReset();

	void Shutdown();

	void SetOutputRate(ExportedEventType theEventType, EventExportOutputRate theRate);

	bool ShouldOutputNow(ExportedEventType theEventType, Scenario theScen);
}
