using System;
using System.ComponentModel;

namespace OpenDis.Enumerations;

[Serializable]
public enum PduType : byte
{
	[Description("Other.")]
	Other,
	[Description("Entity State.")]
	EntityState,
	[Description("Fire.")]
	Fire,
	[Description("Detonation.")]
	Detonation,
	[Description("Collision.")]
	Collision,
	[Description("Service Request.")]
	ServiceRequest,
	[Description("Resupply Offer.")]
	ResupplyOffer,
	[Description("Resupply Received.")]
	ResupplyReceived,
	[Description("Resupply Cancel.")]
	ResupplyCancel,
	[Description("Repair Complete.")]
	RepairComplete,
	[Description("Repair Response.")]
	RepairResponse,
	[Description("Create Entity.")]
	CreateEntity,
	[Description("Remove Entity.")]
	RemoveEntity,
	[Description("Start/Resume.")]
	StartResume,
	[Description("Stop/Freeze.")]
	StopFreeze,
	[Description("Acknowledge.")]
	Acknowledge,
	[Description("Action Request.")]
	ActionRequest,
	[Description("Action Response.")]
	ActionResponse,
	[Description("Data Query.")]
	DataQuery,
	[Description("Set Data.")]
	SetData,
	[Description("Data.")]
	Data,
	[Description("Event Report.")]
	EventReport,
	[Description("Comment.")]
	Comment,
	[Description("Electromagnetic Emission.")]
	ElectromagneticEmission,
	[Description("Designator.")]
	Designator,
	[Description("Transmitter.")]
	Transmitter,
	[Description("Signal.")]
	Signal,
	[Description("Receiver.")]
	Receiver,
	[Description("IFF/ATC/NAVAIDS.")]
	IFF_ATC_NAVAIDS,
	[Description("Underwater Acoustic.")]
	UnderwaterAcoustic,
	[Description("Supplemental Emission / Entity State.")]
	SupplementalEmissionEntityState,
	[Description("Intercom Signal.")]
	IntercomSignal,
	[Description("Intercom Control.")]
	IntercomControl,
	[Description("Aggregate State.")]
	AggregateState,
	[Description("IsGroupOf.")]
	IsGroupOf,
	[Description("Transfer Control.")]
	TransferControl,
	[Description("IsPartOf.")]
	IsPartOf,
	[Description("Minefield State.")]
	MinefieldState,
	[Description("Minefield Query.")]
	MinefieldQuery,
	[Description("Minefield Data.")]
	MinefieldData,
	[Description("Minefield Response NAK.")]
	const_40,
	[Description("Environmental Process.")]
	EnvironmentalProcess,
	[Description("Gridded Data.")]
	GriddedData,
	[Description("Point Object State.")]
	PointObjectState,
	[Description("Linear Object State.")]
	LinearObjectState,
	[Description("Areal Object State.")]
	ArealObjectState,
	[Description("TSPI.")]
	TSPI,
	[Description("Appearance.")]
	Appearance,
	[Description("Articulated Parts.")]
	ArticulatedParts,
	[Description("LE Fire.")]
	LEFire,
	[Description("LE Detonation.")]
	LEDetonation,
	[Description("Create Entity-R.")]
	CreateEntityR,
	[Description("Remove Entity-R.")]
	RemoveEntityR,
	[Description("Start/Resume-R.")]
	StartResumeR,
	[Description("Stop/Freeze-R.")]
	StopFreezeR,
	[Description("Acknowledge-R.")]
	AcknowledgeR,
	[Description("Action Request-R.")]
	ActionRequestR,
	[Description("Action Response-R.")]
	ActionResponseR,
	[Description("Data Query-R.")]
	DataQueryR,
	[Description("Set Data-R.")]
	SetDataR,
	[Description("Data-R.")]
	DataR,
	[Description("Event Report-R.")]
	EventReportR,
	[Description("Comment-R.")]
	CommentR,
	[Description("Record-R.")]
	RecordR,
	[Description("Set Record-R.")]
	SetRecordR,
	[Description("Record Query-R.")]
	RecordQueryR,
	[Description("Collision-Elastic.")]
	CollisionElastic,
	[Description("Entity State Update.")]
	EntityStateUpdate
}
