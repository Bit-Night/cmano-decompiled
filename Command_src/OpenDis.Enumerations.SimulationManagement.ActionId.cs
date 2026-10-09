using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.SimulationManagement;

[Serializable]
public enum ActionId : uint
{
	[Description("Other.")]
	Other = 0u,
	[Description("Local storage of the requested information.")]
	LocalStorageOfTheRequestedInformation = 1u,
	[Description("Inform SM of event ran out of ammunition.")]
	InformSMOfEventRanOutOfAmmunition = 2u,
	[Description("Inform SM of event killed in action.")]
	InformSMOfEventKilledInAction = 3u,
	[Description("Inform SM of event damage.")]
	InformSMOfEventDamage = 4u,
	[Description("Inform SM of event mobility disabled.")]
	InformSMOfEventMobilityDisabled = 5u,
	[Description("Inform SM of event fire disabled.")]
	InformSMOfEventFireDisabled = 6u,
	[Description("Inform SM of event ran out of fuel.")]
	InformSMOfEventRanOutOfFuel = 7u,
	[Description("Recall checkpoint data.")]
	RecallCheckpointData = 8u,
	[Description("Recall initial parameters.")]
	RecallInitialParameters = 9u,
	[Description("Initiate tether-lead.")]
	InitiateTetherLead = 10u,
	[Description("Initiate tether-follow.")]
	InitiateTetherFollow = 11u,
	[Description("Unthether.")]
	Unthether = 12u,
	[Description("Initiate service station resupply.")]
	InitiateServiceStationResupply = 13u,
	[Description("Initiate tailgate resupply.")]
	InitiateTailgateResupply = 14u,
	[Description("Initiate hitch lead.")]
	InitiateHitchLead = 15u,
	[Description("Initiate hitch follow.")]
	InitiateHitchFollow = 16u,
	[Description("Unhitch.")]
	Unhitch = 17u,
	[Description("Mount.")]
	Mount = 18u,
	[Description("Dismount.")]
	Dismount = 19u,
	[Description("Start DRC (Daily Readiness Check).")]
	StartDRCDailyReadinessCheck = 20u,
	[Description("Stop DRC.")]
	StopDRC = 21u,
	[Description("Data Query.")]
	DataQuery = 22u,
	[Description("Status Request.")]
	StatusRequest = 23u,
	[Description("Send Object State Data.")]
	SendObjectStateData = 24u,
	[Description("Reconstitute.")]
	Reconstitute = 25u,
	[Description("Lock Site Configuration.")]
	LockSiteConfiguration = 26u,
	[Description("Unlock Site Configuration.")]
	UnlockSiteConfiguration = 27u,
	[Description("Update Site Configuration.")]
	UpdateSiteConfiguration = 28u,
	[Description("Query Site Configuration.")]
	QuerySiteConfiguration = 29u,
	[Description("Tethering Information.")]
	TetheringInformation = 30u,
	[Description("Mount Intent.")]
	MountIntent = 31u,
	[Description("Accept Subscription.")]
	AcceptSubscription = 33u,
	[Description("Unsubscribe.")]
	Unsubscribe = 34u,
	[Description("Teleport entity.")]
	TeleportEntity = 35u,
	[Description("Change aggregate state.")]
	ChangeAggregateState = 36u,
	[Description("Request Start PDU.")]
	RequestStartPDU = 37u,
	[Description("Wakeup get ready for initialization.")]
	WakeupGetReadyForInitialization = 38u,
	[Description("Initialize internal parameters.")]
	InitializeInternalParameters = 39u,
	[Description("Send plan data.")]
	SendPlanData = 40u,
	[Description("Synchronize internal clocks.")]
	SynchronizeInternalClocks = 41u,
	[Description("Run.")]
	Run = 42u,
	[Description("Save internal parameters.")]
	SaveInternalParameters = 43u,
	[Description("Simulate malfunction.")]
	SimulateMalfunction = 44u,
	[Description("Join exercise.")]
	JoinExercise = 45u,
	[Description("Resign exercise.")]
	ResignExercise = 46u,
	[Description("Time advance.")]
	TimeAdvance = 47u,
	[Description("TACCSF LOS Request-Type 1.")]
	TACCSFLOSRequestType1 = 100u,
	[Description("TACCSF LOS Request-Type 2.")]
	TACCSFLOSRequestType2 = 101u
}
