using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.SimulationManagement;

[Serializable]
public enum DatumSpecificationRecord : uint
{
	[Description("Identification.")]
	Identification = 10000u,
	[Description("Entity Type.")]
	EntityType = 11000u,
	[Description("Concatenated.")]
	Concatenated = 11100u,
	[Description("Kind.  type: Unsigned Integer.  length: 8.")]
	Kind = 11110u,
	[Description("Domain.  type: Unsigned Integer.  length: 8.")]
	Domain = 11120u,
	[Description("Country.  type: Unsigned Integer.  length: 16.")]
	Country = 11130u,
	[Description("Category.  type: Unsigned Integer.  length: 8.")]
	Category = 11140u,
	[Description("Subcategory.  type: Unsigned Integer.  length: 8.")]
	Subcategory = 11150u,
	[Description("Specific.  type: Unsigned Integer.  length: 8.")]
	Specific = 11160u,
	[Description("Extra.  type: Unsigned Integer.  length: 8.")]
	Extra = 11170u,
	[Description("Force ID.  type: Unsigned Integer.  length: 8.")]
	ForceID = 11200u,
	[Description("Description.")]
	Description = 11300u,
	[Description("Alternative Entity Type.")]
	AlternativeEntityType = 12000u,
	[Description("Kind.  type: Unsigned Integer.  length: 8.")]
	Kind_12110 = 12110u,
	[Description("Domain.  type: Unsigned Integer.  length: 8.")]
	Domain_12120 = 12120u,
	[Description("Country.  type: Unsigned Integer.  length: 16.")]
	Country_12130 = 12130u,
	[Description("Category.  type: Unsigned Integer.  length: 8.")]
	Category_12140 = 12140u,
	[Description("Subcategory.  type: Unsigned Integer.  length: 8.")]
	Subcategory_12150 = 12150u,
	[Description("Specific.  type: Unsigned Integer.  length: 8.")]
	Specific_12160 = 12160u,
	[Description("Extra.  type: Unsigned Integer.  length: 8.")]
	Extra_12170 = 12170u,
	[Description("Description.")]
	Description_12300 = 12300u,
	[Description("Entity Marking.")]
	EntityMarking = 13000u,
	[Description("Entity Marking Characters.  type: String.  length: 80.")]
	EntityMarkingCharacters = 13100u,
	[Description("Crew ID.  type: String.  length: 80.")]
	CrewID = 13200u,
	[Description("Task Organization.")]
	TaskOrganization = 14000u,
	[Description("Regiment Name.  type: String.")]
	RegimentName = 14200u,
	[Description("Battalion Name.  type: String.")]
	BattalionName = 14300u,
	[Description("Company Name.  type: String.")]
	CompanyName = 14400u,
	[Description("Platoon Name.")]
	PlatoonName = 14500u,
	[Description("Squad Name.")]
	SquadName = 14520u,
	[Description("Team Name.")]
	TeamName = 14540u,
	[Description("Bumper Number.")]
	BumperNumber = 14600u,
	[Description("Vehicle Number.")]
	VehicleNumber = 14700u,
	[Description("Unit Number.")]
	UnitNumber = 14800u,
	[Description("DIS Identity.")]
	const_34 = 15000u,
	[Description("DIS Site ID.")]
	const_35 = 15100u,
	[Description("DIS Host ID.")]
	const_36 = 15200u,
	[Description("DIS Entity ID.")]
	const_37 = 15300u,
	[Description("Mount Intent.  type: Datum Specification Sub-record.  length: 544.")]
	MountIntent = 15400u,
	[Description("Tether-Unthether Command ID.  type: Unsigned Integer.  length: 32.")]
	TetherUnthetherCommandID = 15500u,
	[Description("Teleport Entity Data Record.  type: Variable record.")]
	TeleportEntityDataRecord = 15510u,
	[Description("DIS Aggregate ID (Set if communication to aggregate).  type: Unsigned Integer.  length: 32.  range: Integer Aggregate ID.")]
	DISAggregateIDSetIfCommunicationToAggregate = 15600u,
	[Description("Loads.")]
	Loads = 20000u,
	[Description("Crew Members.")]
	CrewMembers = 21000u,
	[Description("Crew Member ID.")]
	CrewMemberID = 21100u,
	[Description("Health.")]
	Health = 21200u,
	[Description("Job Assignment.  type: String.")]
	JobAssignment = 21300u,
	[Description("Fuel.")]
	Fuel = 23000u,
	[Description("Quantity.  units: Liters.")]
	Quantity = 23100u,
	[Description("Quantity.  units: Gallons.")]
	Quantity_23105 = 23105u,
	[Description("Ammunition.")]
	Ammunition = 24000u,
	[Description("120-mm HEAT, quantity.  units: Rounds.")]
	_120MmHEATQuantity = 24001u,
	[Description("120-mm SABOT, quantity.  units: Rounds.")]
	_120MmSABOTQuantity = 24002u,
	[Description("12.7-mm M8, quantity.  units: Rounds.")]
	_127MmM8Quantity = 24003u,
	[Description("12.7-mm M20, quantity.  units: Rounds.")]
	_127MmM20Quantity = 24004u,
	[Description("7.62-mm M62, quantity.  units: Rounds.")]
	_762MmM62Quantity = 24005u,
	[Description("M250 UKL8A1, quantity.  units: Grenades.")]
	const_56 = 24006u,
	[Description("M250 UKL8A3, quantity.  units: Grenades.")]
	const_57 = 24007u,
	[Description("7.62-mm M80, quantity.  units: Rounds.")]
	_762MmM80Quantity = 24008u,
	[Description("12.7-mm, quantity.  units: Rounds.")]
	_127MmQuantity = 24009u,
	[Description("7.62-mm, quantity.  units: Rounds.")]
	_762MmQuantity = 24010u,
	[Description("Mines, quantity.  units: Mines.")]
	MinesQuantity = 24060u,
	[Description("Type.")]
	Type = 24100u,
	[Description("Kind.")]
	Kind_24110 = 24110u,
	[Description("Domain.")]
	Domain_24120 = 24120u,
	[Description("Country.")]
	Country_24130 = 24130u,
	[Description("Category.")]
	Category_24140 = 24140u,
	[Description("Subcategory.")]
	Subcategory_24150 = 24150u,
	[Description("Extra.")]
	Extra_24160 = 24160u,
	[Description("Description.")]
	Description_24300 = 24300u,
	[Description("Cargo.")]
	Cargo = 25000u,
	[Description("Vehicle Mass.  type: Unsigned Integer.  length: 32.  units: Kilograms.")]
	VehicleMass = 26000u,
	[Description("Supply Quantity.")]
	SupplyQuantity = 27000u,
	[Description("Armament.  type: Boolean.")]
	Armament = 28000u,
	[Description("Status.")]
	Status = 30000u,
	[Description("Activate entity.  type: Integer.  length: 32.  range: 0 Unspecified, 1 Activate platform.")]
	ActivateEntity = 30010u,
	[Description("Subscription State.  type: Enumeration.  length: 8.")]
	SubscriptionState = 30100u,
	[Description("Round trip time delay.  type: Unsigned Integer.  length: 32 bits.  units: milliseconds.")]
	RoundTripTimeDelay = 30300u,
	[Description("TADIL J message count (label 0).  type: Unsigned Integer.  length: 32 bits.")]
	TADILJMessageCountLabel0 = 30400u,
	[Description("TADIL J message count (label 1).  type: Unsigned Integer.  length: 32 bits.")]
	TADILJMessageCountLabel1 = 30401u,
	[Description("TADIL J message count (label 2).  type: Unsigned Integer.  length: 32 bits.")]
	TADILJMessageCountLabel2 = 30402u,
	[Description("TADIL J message count (label 3).  type: Unsigned Integer.  length: 32 bits.")]
	TADILJMessageCountLabel3 = 30403u,
	[Description("TADIL J message count (label 4).  type: Unsigned Integer.  length: 32 bits.")]
	TADILJMessageCountLabel4 = 30404u,
	[Description("TADIL J message count (label 5).  type: Unsigned Integer.  length: 32 bits.")]
	TADILJMessageCountLabel5 = 30405u,
	[Description("TADIL J message count (label 6).  type: Unsigned Integer.  length: 32 bits.")]
	TADILJMessageCountLabel6 = 30406u,
	[Description("TADIL J message count (label 7).  type: Unsigned Integer.  length: 32 bits.")]
	TADILJMessageCountLabel7 = 30407u,
	[Description("TADIL J message count (label 8).  type: Unsigned Integer.  length: 32 bits.")]
	TADILJMessageCountLabel8 = 30408u,
	[Description("TADIL J message count (label 9).  type: Unsigned Integer.  length: 32 bits.")]
	TADILJMessageCountLabel9 = 30409u,
	[Description("TADIL J message count (label 10).  type: Unsigned Integer.  length: 32 bits.")]
	TADILJMessageCountLabel10 = 30410u,
	[Description("TADIL J message count (label 11).  type: Unsigned Integer.  length: 32 bits.")]
	TADILJMessageCountLabel11 = 30411u,
	[Description("TADIL J message count (label 12).  type: Unsigned Integer.  length: 32 bits.")]
	TADILJMessageCountLabel12 = 30412u,
	[Description("TADIL J message count (label 13).  type: Unsigned Integer.  length: 32 bits.")]
	TADILJMessageCountLabel13 = 30413u,
	[Description("TADIL J message count (label 14).  type: Unsigned Integer.  length: 32 bits.")]
	TADILJMessageCountLabel14 = 30414u,
	[Description("TADIL J message count (label 15).  type: Unsigned Integer.  length: 32 bits.")]
	TADILJMessageCountLabel15 = 30415u,
	[Description("TADIL J message count (label 16).  type: Unsigned Integer.  length: 32 bits.")]
	TADILJMessageCountLabel16 = 30416u,
	[Description("TADIL J message count (label 17).  type: Unsigned Integer.  length: 32 bits.")]
	TADILJMessageCountLabel17 = 30417u,
	[Description("TADIL J message count (label 18).  type: Unsigned Integer.  length: 32 bits.")]
	TADILJMessageCountLabel18 = 30418u,
	[Description("TADIL J message count (label 19).  type: Unsigned Integer.  length: 32 bits.")]
	TADILJMessageCountLabel19 = 30419u,
	[Description("TADIL J message count (label 20).  type: Unsigned Integer.  length: 32 bits.")]
	TADILJMessageCountLabel20 = 30420u,
	[Description("TADIL J message count (label 21).  type: Unsigned Integer.  length: 32 bits.")]
	TADILJMessageCountLabel21 = 30421u,
	[Description("TADIL J message count (label 22).  type: Unsigned Integer.  length: 32 bits.")]
	TADILJMessageCountLabel22 = 30422u,
	[Description("TADIL J message count (label 23).  type: Unsigned Integer.  length: 32 bits.")]
	TADILJMessageCountLabel23 = 30423u,
	[Description("TADIL J message count (label 24).  type: Unsigned Integer.  length: 32 bits.")]
	TADILJMessageCountLabel24 = 30424u,
	[Description("TADIL J message count (label 25).  type: Unsigned Integer.  length: 32 bits.")]
	TADILJMessageCountLabel25 = 30425u,
	[Description("TADIL J message count (label 26).  type: Unsigned Integer.  length: 32 bits.")]
	TADILJMessageCountLabel26 = 30426u,
	[Description("TADIL J message count (label 27).  type: Unsigned Integer.  length: 32 bits.")]
	TADILJMessageCountLabel27 = 30427u,
	[Description("TADIL J message count (label 28).  type: Unsigned Integer.  length: 32 bits.")]
	TADILJMessageCountLabel28 = 30428u,
	[Description("TADIL J message count (label 29).  type: Unsigned Integer.  length: 32 bits.")]
	TADILJMessageCountLabel29 = 30429u,
	[Description("TADIL J message count (label 30).  type: Unsigned Integer.  length: 32 bits.")]
	TADILJMessageCountLabel30 = 30430u,
	[Description("TADIL J message count (label 31).  type: Unsigned Integer.  length: 32 bits.")]
	TADILJMessageCountLabel31 = 30431u,
	[Description("Position.")]
	Position = 31000u,
	[Description("Route (Waypoint) type.  type: Integer.  length: 32.  range: 0 Default, 1 Orbit.")]
	RouteWaypointType = 31010u,
	[Description("MilGrid10.")]
	const_112 = 31100u,
	[Description("Geocentric Coordinates.")]
	GeocentricCoordinates = 31200u,
	[Description("X.  type: Unsigned Integer.  length: 32.  units: Meters.")]
	X = 31210u,
	[Description("Y.  type: Unsigned Integer.  length: 32.  units: Meters.")]
	Y = 31220u,
	[Description("Z.  type: Unsigned Integer.  length: 32.  units: Meters.")]
	Z = 31230u,
	[Description("Latitude.  type: Unsigned Integer.  length: 32.  units: Degrees.")]
	Latitude = 31300u,
	[Description("Longitude.  type: Unsigned Integer.  length: 32.  units: Degrees.")]
	Longitude = 31400u,
	[Description("Line of Sight.")]
	LineOfSight = 31500u,
	[Description("X.  type: Unsigned Integer.  length: 32.  units: meters.")]
	X_31510 = 31510u,
	[Description("Y.  type: Unsigned Integer.  length: 32.  units: Meters.")]
	Y_31520 = 31520u,
	[Description("Z.  type: Unsigned Integer.  length: 32.  units: Meters.")]
	Z_31530 = 31530u,
	[Description("Altitude.  type: Integer.  length: 32.  units: Meters.")]
	Altitude = 31600u,
	[Description("Destination Latitude.  type: Integer.  length: 32.  units: (10000th) Degrees.")]
	DestinationLatitude = 31700u,
	[Description("Destination Longitude.  type: Integer.  length: 32.  units: (10000th) Degrees.")]
	DestinationLongitude = 31800u,
	[Description("Destination Altitude.  type: Integer.  length: 32.  units: Meters.")]
	DestinationAltitude = 31900u,
	[Description("Orientation.  type: Variable Datum.  length: 96.  units: Radians.  range: 3-32bit Floating Point.")]
	Orientation = 32000u,
	[Description("Hull Heading Angle.  type: Unsigned Integer.  length: 32.  units: Degrees.")]
	HullHeadingAngle = 32100u,
	[Description("Hull Pitch Angle.  type: Unsigned Integer.  length: 32.  units: Degrees.")]
	HullPitchAngle = 32200u,
	[Description("Roll Angle.  type: Unsigned Integer.  length: 32.  units: Degrees.")]
	RollAngle = 32300u,
	[Description("X.  type: Unsigned Integer.  length: 32.  units: Degrees.")]
	X_32500 = 32500u,
	[Description("Y.  type: Unsigned Integer.  length: 32.  units: Degrees.")]
	Y_32600 = 32600u,
	[Description("Z.  type: Unsigned Integer.  length: 32.  units: Degrees.")]
	Z_32700 = 32700u,
	[Description("Appearance.")]
	Appearance = 33000u,
	[Description("Ambient Lighting.")]
	AmbientLighting = 33100u,
	[Description("Lights.")]
	Lights = 33101u,
	[Description("Paint Scheme.")]
	PaintScheme = 33200u,
	[Description("Smoke.")]
	Smoke = 33300u,
	[Description("Trailing Effects.")]
	TrailingEffects = 33400u,
	[Description("Flaming.")]
	Flaming = 33500u,
	[Description("Marking.")]
	Marking = 33600u,
	[Description("Mine Plows Attached.")]
	MinePlowsAttached = 33710u,
	[Description("Mine Rollers Attached.")]
	MineRollersAttached = 33720u,
	[Description("Tank Turret Azimuth.  units: Degrees Rel 2 lon.")]
	TankTurretAzimuth = 33730u,
	[Description("Failures and Malfunctions.")]
	FailuresAndMalfunctions = 34000u,
	[Description("Age.  units: Miles.")]
	Age = 34100u,
	[Description("Kilometers.")]
	Kilometers = 34110u,
	[Description("Damage.")]
	Damage = 35000u,
	[Description("Cause.")]
	Cause = 35050u,
	[Description("Mobility Kill.")]
	MobilityKill = 35100u,
	[Description("Fire-Power Kill.")]
	FirePowerKill = 35200u,
	[Description("Personnel Casualties.")]
	PersonnelCasualties = 35300u,
	[Description("Velocity.")]
	Velocity = 36000u,
	[Description("X-velocity.  units: Meters/second.")]
	const_154 = 36100u,
	[Description("Y-velocity.  units: Meters/second.")]
	const_155 = 36200u,
	[Description("Z-velocity.  units: Meters/second.")]
	const_156 = 36300u,
	[Description("Speed.  type: Floating Point.  length: 32.  units: Meters/second.")]
	Speed = 36400u,
	[Description("Acceleration.")]
	Acceleration = 37000u,
	[Description("X-acceleration.")]
	XAcceleration = 37100u,
	[Description("Y-acceleration.")]
	YAcceleration = 37200u,
	[Description("Z-acceleration.")]
	ZAcceleration = 37300u,
	[Description("Engine Status.")]
	EngineStatus = 38100u,
	[Description("Primary Target Line (PTL).  type: Unsigned Integer.  length: 32.  units: Degrees.")]
	const_163 = 39000u,
	[Description("Exercise.")]
	Exercise = 40000u,
	[Description("Exercise State.  type: Variable Record.  length: 64.")]
	ExerciseState = 40010u,
	[Description("Restart/Refresh.  type: Unsigned Integer.  length: 32.  range: 0 Undefined, 1 Restart.")]
	RestartRefresh = 40015u,
	[Description("AFATDS File Name.  type: Variable Record.  range: 1..40 ASCII Characters.")]
	AFATDSFileName = 40020u,
	[Description("Terrain Database.  type: Unsigned Integer.  length: 32.")]
	TerrainDatabase = 41000u,
	[Description("41001.  type: 41001.  length: 41001.  units: 41001.  range: 41001.")]
	_41001 = 41001u,
	[Description("Missions.")]
	Missions = 42000u,
	[Description("Mission ID.")]
	MissionID = 42100u,
	[Description("Mission Type.")]
	MissionType = 42200u,
	[Description("Mission Request Time Stamp.")]
	MissionRequestTimeStamp = 42300u,
	[Description("Exercise Description.  type: String.")]
	ExerciseDescription = 43000u,
	[Description("Name.  type: String.")]
	Name = 43100u,
	[Description("Entities.  type: Integer.")]
	Entities = 43200u,
	[Description("Version.")]
	Version = 43300u,
	[Description("Guise Mode.  type: Unsigned Integer.  length: 32.")]
	GuiseMode = 43410u,
	[Description("Simulation Application Active Status.  type: Unsigned Integer.  length: 16.  range: 0 Backup, 1 Primary.")]
	SimulationApplicationActiveStatus = 43420u,
	[Description("Simulation Application Role Record.  type: Variable Record.  length: 64.")]
	SimulationApplicationRoleRecord = 43430u,
	[Description("Simulation Application State.  type: Variable Record.  length: 64.")]
	SimulationApplicationState = 43440u,
	[Description("Visual Output Mode.")]
	VisualOutputMode = 44000u,
	[Description("Simulation Manager Role.  type: Variable Record.")]
	SimulationManagerRole = 44100u,
	[Description("Simulation Manager Site ID.  type: Unsigned Integer.  length: 16.")]
	SimulationManagerSiteID = 44110u,
	[Description("Simulation Manager Applic. ID.  type: Unsigned Integer.  length: 16.")]
	SimulationManagerApplicID = 44120u,
	[Description("Simulation Manager Entity ID.  type: Unsigned Integer.  length: 16.")]
	SimulationManagerEntityID = 44130u,
	[Description("Simulation Manager Active Status.  type: Unsigned Integer.  length: 16.  range: 0 Backup, 1 Primary.")]
	SimulationManagerActiveStatus = 44140u,
	[Description("After Active Review Role.  type: Variable Record.")]
	AfterActiveReviewRole = 44200u,
	[Description("After Active Review Site ID.  type: Unsigned Integer.  length: 16.")]
	AfterActiveReviewSiteID = 44210u,
	[Description("After Active Applic. ID.  type: Unsigned Integer.  length: 16.")]
	AfterActiveApplicID = 44220u,
	[Description("After Active Review Entity ID.  type: Unsigned Integer.  length: 16.")]
	AfterActiveReviewEntityID = 44230u,
	[Description("After Active Review Active Status.  type: Unsigned Integer.  length: 16.  range: 0 Backup, 1 Primary.")]
	AfterActiveReviewActiveStatus = 44240u,
	[Description("Exercise Logger Role.  type: Variable Record.")]
	ExerciseLoggerRole = 44300u,
	[Description("Exercise Logger Site ID.  type: Unsigned Integer.  length: 16.")]
	ExerciseLoggerSiteID = 44310u,
	[Description("Exercise Logger Applic. ID.  type: Unsigned Integer.  length: 16.")]
	ExerciseLoggerApplicID = 44320u,
	[Description("Exercise Entity ID.  type: Unsigned Integer.  length: 16.")]
	ExerciseEntityID = 44330u,
	[Description("Exercise Logger Active Status.  type: Unsigned Integer.  length: 16.  range: 0 Backup, 1 Primary.")]
	ExerciseLoggerActiveStatus = 44340u,
	[Description("Synthetic Environment Manager Role.  type: Variable Record.")]
	SyntheticEnvironmentManagerRole = 44400u,
	[Description("Synthetic Environment Manager Site ID.  type: Unsigned Integer.  length: 16.")]
	SyntheticEnvironmentManagerSiteID = 44410u,
	[Description("Synthetic Environment Manager Applic. ID.  type: Unsigned Integer.  length: 16.")]
	SyntheticEnvironmentManagerApplicID = 44420u,
	[Description("Synthetic Environment Manager Entity ID.  type: Unsigned Integer.  length: 16.")]
	SyntheticEnvironmentManagerEntityID = 44430u,
	[Description("Synthetic Environment Manager Active Status.  type: Unsigned Integer.  length: 16.  range: 0 Backup, 1 Primary.")]
	SyntheticEnvironmentManagerActiveStatus = 44440u,
	[Description("SIMNET-DIS Translator Role.  type: Variable Record.")]
	SIMNETDISTranslatorRole = 44500u,
	[Description("SIMNET-DIS Translator Site ID.  type: Unsigned Integer.  length: 16.")]
	SIMNETDISTranslatorSiteID = 44510u,
	[Description("SIMNET-DIS Translator Applic. ID.  type: Unsigned Integer.  length: 16.")]
	SIMNETDISTranslatorApplicID = 44520u,
	[Description("SIMNET-DIS Translator Entity ID.  type: Unsigned Integer.  length: 16.")]
	SIMNETDISTranslatorEntityID = 44530u,
	[Description("SIMNET-DIS Translator Active Status.  type: Unsigned Integer.  length: 16.  range: 0 Backup, 1 Primary.")]
	SIMNETDISTranslatorActiveStatus = 44540u,
	[Description("Application Rate.  type: Floating point.  length: 32.")]
	ApplicationRate = 45000u,
	[Description("Application Time.  type: Clock Time Record.  length: 64.  range: See IEEE Std1278.1-1995 section 5.2.8.")]
	ApplicationTime = 45005u,
	[Description("Application Timestep.  type: Timestamp.  length: 32.  range: See IEEE Std 1278.1-1995 section 5.2.31.")]
	ApplicationTimestep = 45010u,
	[Description("Feedback Time.  type: Timestamp.  length: 32.  range: See IEEE Std 1278.1-1995 section 5.2.31.")]
	FeedbackTime = 45020u,
	[Description("Simulation Rate.  type: Floating Point.  length: 32.")]
	SimulationRate = 45030u,
	[Description("Simulation Time.  type: Clock Time Record.  length: 64.  range: See IEEE Std 1278.1-1995 section 5.2.8.")]
	SimulationTime = 45040u,
	[Description("Simulation Timestep.  type: Timestamp.  length: 32.  range: See IEEE Std 1278.1-1995 section 5.2.31.")]
	SimulationTimestep = 45050u,
	[Description("Time Interval.  type: Timestamp.  length: 32.  range: See IEEE Std 1278.1-1995 section 5.2.31.")]
	TimeInterval = 45060u,
	[Description("Time Latency.  type: Timestamp.  length: 32.  range: See IEEE Std 1278.1-1995 section 5.2.31.")]
	TimeLatency = 45070u,
	[Description("Time Scheme.  type: Unsigned Integer.  length: 32.  range: 1 Real time, 2 Scaled time, 3 Scaled and stepped time.")]
	TimeScheme = 45080u,
	[Description("Exercise Elapsed Time.  type: Unsigned integer.  length: 32.  units: Seconds.  range: Time since exercise started (takes into account exercise pauses and scaled exercise time).")]
	ExerciseElapsedTime = 46000u,
	[Description("Elapsed Time.  type: Unsigned integer.  length: 32.  units: Seconds.  range: Time since exercise started (real time, does not take into account exercise pauses and scaled exercise time).")]
	ElapsedTime = 46010u,
	[Description("Environment.")]
	Environment = 50000u,
	[Description("Weather.")]
	Weather = 51000u,
	[Description("Weather Condition.  type: Unsigned Integer.  length: 32.  units: N/A.  range: 0 = Clear, 1 = Cloudy, 2 = Overcast, 3 = Foggy, 4 = Raining.")]
	WeatherCondition = 51010u,
	[Description("Thermal Condition.")]
	ThermalCondition = 51100u,
	[Description("Thermal Visibility.  type: Floating Point.  length: 32.  units: Meters.")]
	ThermalVisibility = 51110u,
	[Description("Thermal Visibility.  type: Unsigned integer.  length: 32.  units: Meters.")]
	ThermalVisibility_51111 = 51111u,
	[Description("Time.")]
	Time = 52000u,
	[Description("Time.  type: String.  length: 56.  range: Format HHMMSS.")]
	Time_52001 = 52001u,
	[Description("Time of Day, Discrete.")]
	TimeOfDayDiscrete = 52100u,
	[Description("Time of Day, Continuous.")]
	TimeOfDayContinuous = 52200u,
	[Description("Time Mode.")]
	TimeMode = 52300u,
	[Description("Time Scene.")]
	TimeScene = 52305u,
	[Description("Current Hour.")]
	CurrentHour = 52310u,
	[Description("Current Minute.")]
	CurrentMinute = 52320u,
	[Description("Current Second.")]
	CurrentSecond = 52330u,
	[Description("Azimuth.")]
	Azimuth = 52340u,
	[Description("Maximum Elevation.")]
	MaximumElevation = 52350u,
	[Description("Time Zone.")]
	TimeZone = 52360u,
	[Description("Time Rate.  type: Integer.  length: 32.  range: 1000 * Ratio (Simulation Time / Wall Clock Time).")]
	TimeRate = 52370u,
	[Description("The number of simulation seconds since the start of the exercise (simulation time).  type: Integer.  length: 32.  units: Seconds.")]
	TheNumberOfSimulationSecondsSinceTheStartOfTheExerciseSimulationTime = 52380u,
	[Description("Time Sunrise Enabled.")]
	TimeSunriseEnabled = 52400u,
	[Description("Sunrise Hour.")]
	SunriseHour = 52410u,
	[Description("Sunrise Minute.")]
	SunriseMinute = 52420u,
	[Description("Sunrise Second.")]
	SunriseSecond = 52430u,
	[Description("Sunrise Azimuth.")]
	SunriseAzimuth = 52440u,
	[Description("Time Sunset Enabled.")]
	TimeSunsetEnabled = 52500u,
	[Description("Sunset Hour.")]
	SunsetHour = 52510u,
	[Description("Sunset Hour.")]
	SunsetHour_52511 = 52511u,
	[Description("Sunset Minute.")]
	SunsetMinute = 52520u,
	[Description("Sunset Second.")]
	SunsetSecond = 52530u,
	[Description("52531.  type: 52531.  length: 52531.  units: 52531.  range: 52531.")]
	_52531 = 52531u,
	[Description("Date.")]
	Date = 52600u,
	[Description("Date (European).  type: String.  length: 72.  range: Format DDMMYYYY.")]
	DateEuropean = 52601u,
	[Description("Date (US).  type: String.  length: 72.  range: Format MMDDYYYY.")]
	DateUS = 52602u,
	[Description("Month.")]
	Month = 52610u,
	[Description("Day.")]
	Day = 52620u,
	[Description("Year.")]
	Year = 52630u,
	[Description("Clouds.")]
	Clouds = 53000u,
	[Description("Cloud Layer Enable.")]
	CloudLayerEnable = 53050u,
	[Description("Cloud Layer Selection.")]
	CloudLayerSelection = 53060u,
	[Description("Visibility.")]
	Visibility = 53100u,
	[Description("Base Altitude.  type: Unsigned Integer.  length: 32.  units: Meters.")]
	BaseAltitude = 53200u,
	[Description("Base Altitude.  units: Feet.")]
	BaseAltitude_53250 = 53250u,
	[Description("Ceiling.  type: Unsigned Integer.  length: 32.  units: Meters.")]
	Ceiling = 53300u,
	[Description("Ceiling.  units: Feet.")]
	Ceiling_53350 = 53350u,
	[Description("Characteristics.")]
	Characteristics = 53400u,
	[Description("Concentration Length.  type: Floating Point.  length: 32.  units: milligrams/meterCaret2.")]
	ConcentrationLength = 53410u,
	[Description("Transmittance.  type: Floating Point.  length: 32.")]
	Transmittance = 53420u,
	[Description("Radiance.  type: Floating Point.  length: 32.  units: microwatts/ centimeterCaret2/ steradian.")]
	Radiance = 53430u,
	[Description("Precipitation.  type: Boolean.  length: 32.")]
	Precipitation = 54000u,
	[Description("Rain.  type: Boolean.")]
	Rain = 54100u,
	[Description("Fog.  type: Boolean.")]
	Fog = 55000u,
	[Description("Visibility.  units: Meters.")]
	Visibility_55100 = 55100u,
	[Description("Visibility.  type: Unsigned integer.  length: 32.  units: Meters.")]
	Visibility_55101 = 55101u,
	[Description("Visibility.  units: Miles.")]
	Visibility_55105 = 55105u,
	[Description("Density.")]
	Density = 55200u,
	[Description("Base.")]
	Base = 55300u,
	[Description("View Layer from above.")]
	ViewLayerFromAbove = 55401u,
	[Description("Transition Range.")]
	TransitionRange = 55410u,
	[Description("Bottom.  units: Meters.")]
	Bottom = 55420u,
	[Description("Bottom.  units: Feet.")]
	Bottom_55425 = 55425u,
	[Description("Ceiling.  units: Meters.")]
	Ceiling_55430 = 55430u,
	[Description("Ceiling.  units: Feet.")]
	Ceiling_55435 = 55435u,
	[Description("Heavenly Bodies.")]
	HeavenlyBodies = 56000u,
	[Description("Sun.")]
	Sun = 56100u,
	[Description("Sun Visible.  type: Unsigned integer.  length: 32.  units: N/A.  range: 0 Not visible, 1 Visible.")]
	SunVisible = 56105u,
	[Description("Position.")]
	Position_56110 = 56110u,
	[Description("Sun Position Elevation, Degrees.  type: Floating Point.  length: 32.  units: Degrees.")]
	SunPositionElevationDegrees = 56111u,
	[Description("Position Azimuth.")]
	PositionAzimuth = 56120u,
	[Description("Sun Position Azimuth, Degrees.  type: Floating Point.  length: 32.  units: Degrees.  range: Relative to True North.")]
	SunPositionAzimuthDegrees = 56121u,
	[Description("Position Elevation.")]
	PositionElevation = 56130u,
	[Description("Position Intensity.")]
	PositionIntensity = 56140u,
	[Description("Moon.")]
	Moon = 56200u,
	[Description("Moon Visible.  type: Unsigned integer.  length: 32.  units: N/A.  range: 0 Not visible, 1 Visible.")]
	MoonVisible = 56205u,
	[Description("Position.")]
	Position_56210 = 56210u,
	[Description("Position Azimuth.")]
	PositionAzimuth_56220 = 56220u,
	[Description("Moon Position Azimuth, Degrees.  type: Floating Point.  length: 32.  units: Degrees.  range: Relative to True North.")]
	MoonPositionAzimuthDegrees = 56221u,
	[Description("Position Elevation.")]
	PositionElevation_56230 = 56230u,
	[Description("Moon Position Elevation, Degrees.  type: Floating Point.  length: 32.  units: Degrees.")]
	MoonPositionElevationDegrees = 56231u,
	[Description("Position Intensity.")]
	PositionIntensity_56240 = 56240u,
	[Description("Horizon.")]
	Horizon = 56310u,
	[Description("Horizon Azimuth.")]
	HorizonAzimuth = 56320u,
	[Description("Horizon Elevation.")]
	HorizonElevation = 56330u,
	[Description("Horizon Heading.")]
	HorizonHeading = 56340u,
	[Description("Horizon Intensity.")]
	HorizonIntensity = 56350u,
	[Description("Humidity.")]
	Humidity = 57200u,
	[Description("Visibility.")]
	Visibility_57300 = 57300u,
	[Description("Winds.")]
	Winds = 57400u,
	[Description("Speed.")]
	Speed_57410 = 57410u,
	[Description("Wind Speed, Knots.  type: Floating Point.  length: 32.  units: Knots.")]
	WindSpeedKnots = 57411u,
	[Description("Wind Direction.  type: Floating Point.  length: 32.  units: Radians.  range: Relative to True North.")]
	WindDirection = 57420u,
	[Description("Wind Direction, Degrees.  type: Floating Point.  length: 32.  units: Degrees.  range: Relative to True North.")]
	WindDirectionDegrees = 57421u,
	[Description("Rainsoak.")]
	Rainsoak = 57500u,
	[Description("Tide Speed.  type: Floating Point.  length: 32.  units: Meters/second.")]
	TideSpeed = 57610u,
	[Description("Tide Speed, Knots.  type: Floating Point.  length: 32.  units: Knots.")]
	TideSpeedKnots = 57611u,
	[Description("Tide Direction.  type: Floating Point.  length: 32.  units: Radians.  range: Relative to True North.")]
	TideDirection = 57620u,
	[Description("Tide Direction, Degrees.  type: Floating Point.  length: 32.  units: Degrees.  range: Relative to True North.")]
	TideDirectionDegrees = 57621u,
	[Description("Haze.  type: Boolean.")]
	Haze = 58000u,
	[Description("Visibility.  units: Meters.")]
	Visibility_58100 = 58100u,
	[Description("Visibility.  units: Miles.")]
	Visibility_58105 = 58105u,
	[Description("Density.")]
	Density_58200 = 58200u,
	[Description("Ceiling.  units: Meters.")]
	Ceiling_58430 = 58430u,
	[Description("Ceiling.  units: Feet.")]
	Ceiling_58435 = 58435u,
	[Description("Contaminants and Obscurants.")]
	ContaminantsAndObscurants = 59000u,
	[Description("Contaminant/Obscurant Type.  type: Unsigned Integer.  length: 32.")]
	ContaminantObscurantType = 59100u,
	[Description("Persistence.  type: Enumeration.  length: 8.  range: 0 Neat, 1 Dry, 2 Thickened.")]
	Persistence = 59110u,
	[Description("Chemical Dosage.  type: Floating Point.  length: 32.  units: milligrams/meter?/minute.")]
	ChemicalDosage = 59115u,
	[Description("Chemical Air Concentration.  type: Floating Point.  length: 32.  units: milligrams/meter?.")]
	ChemicalAirConcentration = 59120u,
	[Description("Chemical Ground Deposition.  type: Floating Point.  length: 32.  units: milligrams/meterCaret2.")]
	ChemicalGroundDeposition = 59125u,
	[Description("Chemical Maximum Ground Deposition.  type: Floating Point.  length: 32.  units: milligrams/meterCaret2.")]
	ChemicalMaximumGroundDeposition = 59130u,
	[Description("Chemical Dosage Threshold.  type: Floating Point.  length: 32.  units: milligram/meter?/minute.")]
	ChemicalDosageThreshold = 59135u,
	[Description("Biological Dosage.  type: Floating Point.  length: 32.  units: particles/liter of air/minute.")]
	BiologicalDosage = 59140u,
	[Description("Biological Air Concentration.  type: Floating Point.  length: 32.  units: particles/liter of air.")]
	BiologicalAirConcentration = 59145u,
	[Description("Biological Dosage Threshold.  type: Floating Point.  length: 32.  units: particles/liter of air/minute.")]
	BiologicalDosageThreshold = 59150u,
	[Description("Biological Binned Particle Count.  type: Enumeration.  length: 8.  range: 1 Low (.5-2), 2 Detection (2-.10), 3 High (10-15).")]
	BiologicalBinnedParticleCount = 59155u,
	[Description("Radiological Dosage.  type: Floating Point.  length: 32.")]
	RadiologicalDosage = 59160u,
	[Description("Communications.")]
	Communications = 60000u,
	[Description("Channel Type.")]
	ChannelType = 61100u,
	[Description("Channel Type.")]
	ChannelType_61101 = 61101u,
	[Description("Channel Identification.")]
	ChannelIdentification = 61200u,
	[Description("Alpha Identification.")]
	AlphaIdentification = 61300u,
	[Description("61301.  type: 61301.  length: 61301.  units: 61301.  range: 61301.")]
	_61301 = 61301u,
	[Description("Radio Identification.")]
	RadioIdentification = 61400u,
	[Description("61401.  type: 61401.  length: 61401.  units: 61401.  range: 61401.")]
	_61401 = 61401u,
	[Description("Land Line Identification.")]
	LandLineIdentification = 61500u,
	[Description("Intercom Identification.")]
	IntercomIdentification = 61600u,
	[Description("Group Network Channel Number.")]
	GroupNetworkChannelNumber = 61700u,
	[Description("Radio Communications Status.")]
	RadioCommunicationsStatus = 62100u,
	[Description("Stationary Radio Transmitters Default Time.  type: Unsigned Integer.")]
	StationaryRadioTransmittersDefaultTime = 62200u,
	[Description("Moving Radio Transmitters Default Time.  type: Unsigned Integer.")]
	MovingRadioTransmittersDefaultTime = 62300u,
	[Description("Stationary Radio Signals Default Time.")]
	StationaryRadioSignalsDefaultTime = 62400u,
	[Description("Moving Radio Signal Default Time.")]
	MovingRadioSignalDefaultTime = 62500u,
	[Description("Radio Initialization Transec Security Key.  type: Variable Record.")]
	RadioInitializationTransecSecurityKey = 63101u,
	[Description("Radio Initialization Internal Noise Level.  type: Variable Record.")]
	RadioInitializationInternalNoiseLevel = 63102u,
	[Description("Radio Initialization Squelch Threshold.  type: Variable Record.")]
	RadioInitializationSquelchThreshold = 63103u,
	[Description("Radio Initialization Antenna Location.  type: Variable Record.")]
	RadioInitializationAntennaLocation = 63104u,
	[Description("Radio Initialization Antenna Pattern Type.  type: Variable Record.")]
	RadioInitializationAntennaPatternType = 63105u,
	[Description("Radio Initialization Antenna Pattern Length.  type: Variable Record.")]
	RadioInitializationAntennaPatternLength = 63106u,
	[Description("Radio Initialization Beam Definition.  type: Variable Record.")]
	RadioInitializationBeamDefinition = 63107u,
	[Description("Radio Initialization Transmit Heartbeat Time.  type: Variable Record.")]
	RadioInitializationTransmitHeartbeatTime = 63108u,
	[Description("Radio Initialization Transmit Distance Threshold Variable Record.")]
	RadioInitializationTransmitDistanceThresholdVariableRecord = 63109u,
	[Description("Radio Channel Initialization Lockout ID.  type: Variable Record.")]
	RadioChannelInitializationLockoutID = 63110u,
	[Description("Radio Channel Initialization Hopset ID.  type: Variable Record.")]
	RadioChannelInitializationHopsetID = 63111u,
	[Description("Radio Channel Initialization Preset Frequency.  type: Variable Record.")]
	RadioChannelInitializationPresetFrequency = 63112u,
	[Description("Radio Channel Initialization Frequency Sync Time.  type: Variable Record.")]
	RadioChannelInitializationFrequencySyncTime = 63113u,
	[Description("Radio Channel Initialization Comsec Key.  type: Variable Record.")]
	RadioChannelInitializationComsecKey = 63114u,
	[Description("Radio Channel Initialization Alpha.  type: Variable Record.")]
	RadioChannelInitializationAlpha = 63115u,
	[Description("Algorithm Parameters.")]
	AlgorithmParameters = 70000u,
	[Description("Dead Reckoning Algorithm (DRA).")]
	DeadReckoningAlgorithmDRA = 71000u,
	[Description("DRA Location Threshold.  type: Unsigned Integer.  length: 32.")]
	const_369 = 71100u,
	[Description("DRA Orientation Threshold.")]
	DRAOrientationThreshold = 71200u,
	[Description("DRA Time Threshold.")]
	DRATimeThreshold = 71300u,
	[Description("Simulation Management Parameters.")]
	SimulationManagementParameters = 72000u,
	[Description("Checkpoint Interval.")]
	CheckpointInterval = 72100u,
	[Description("Transmitter Time Threshold.")]
	TransmitterTimeThreshold = 72600u,
	[Description("Receiver Time Threshold.")]
	ReceiverTimeThreshold = 72700u,
	[Description("Interoperability Mode.")]
	InteroperabilityMode = 73000u,
	[Description("SIMNET Data Collection.  type: Variable Record.")]
	const_377 = 74000u,
	[Description("Event ID.")]
	EventID = 75000u,
	[Description("Source Site ID.")]
	SourceSiteID = 75100u,
	[Description("Source Host ID.")]
	SourceHostID = 75200u,
	[Description("Articulated Parts.")]
	ArticulatedParts = 90000u,
	[Description("90001.  type: 90001.  length: 90001.  units: 90001.  range: 90001.")]
	_90001 = 90001u,
	[Description("Part ID.")]
	PartID = 90050u,
	[Description("Index.")]
	Index = 90070u,
	[Description("Position.")]
	Position_90100 = 90100u,
	[Description("Position Rate.")]
	PositionRate = 90200u,
	[Description("Extension.")]
	Extension = 90300u,
	[Description("Extension Rate.")]
	ExtensionRate = 90400u,
	[Description("X.")]
	X_90500 = 90500u,
	[Description("X-rate.")]
	XRate = 90600u,
	[Description("Y.")]
	Y_90700 = 90700u,
	[Description("Y-rate.")]
	YRate = 90800u,
	[Description("Z.")]
	Z_90900 = 90900u,
	[Description("Z-rate.")]
	ZRate = 91000u,
	[Description("Azimuth.")]
	Azimuth_91100 = 91100u,
	[Description("Azimuth Rate.")]
	AzimuthRate = 91200u,
	[Description("Elevation.")]
	Elevation = 91300u,
	[Description("Elevation Rate.")]
	ElevationRate = 91400u,
	[Description("Rotation.")]
	Rotation = 91500u,
	[Description("Rotation Rate.")]
	RotationRate = 91600u,
	[Description("DRA Angular X-Velocity.")]
	const_401 = 100001u,
	[Description("DRA Angular Y-Velocity.")]
	const_402 = 100002u,
	[Description("DRA Angular Z-Velocity.")]
	const_403 = 100003u,
	[Description("Appearance, Trailing Effects.")]
	AppearanceTrailingEffects = 100004u,
	[Description("Appearance, Hatch.")]
	AppearanceHatch = 100005u,
	[Description("Appearance, Character Set.")]
	AppearanceCharacterSet = 100008u,
	[Description("Capability, Ammunition Supplier.")]
	CapabilityAmmunitionSupplier = 100010u,
	[Description("Capability, Miscellaneous Supplier.")]
	CapabilityMiscellaneousSupplier = 100011u,
	[Description("Capability, Repair Provider.")]
	CapabilityRepairProvider = 100012u,
	[Description("Articulation Parameter.")]
	ArticulationParameter = 100014u,
	[Description("Articulation Parameter Type.")]
	ArticulationParameterType = 100047u,
	[Description("Articulation Parameter Value.")]
	ArticulationParameterValue = 100048u,
	[Description("Time of Day-Scene.")]
	TimeOfDayScene = 100058u,
	[Description("Latitude-North (Location of weather cell).  type: Unsigned Integer.")]
	LatitudeNorthLocationOfWeatherCell = 100061u,
	[Description("Longitude-East (Location of weather cell).  type: Unsigned integer.")]
	LongitudeEastLocationOfWeatherCell = 100063u,
	[Description("Tactical Driver Status.  type: Unsigned Integer.  range: 0 Operational, 1 Non-operational, 2 Unknown, 3 Not available.")]
	TacticalDriverStatus = 100068u,
	[Description("Sonar System Status.")]
	SonarSystemStatus = 100100u,
	[Description("Upper latitude.  type: float.  length: 32 bits.  units: radians.  range: -pi/2, +p1/2.")]
	UpperLatitude = 100161u,
	[Description("Latitude-South (Location of weather cell).  type: Unsigned Integer.")]
	LatitudeSouthLocationOfWeatherCell = 100162u,
	[Description("Western longitude.  type: float.  length: 32 bits.  units: radians.  range: -pi, +pi.")]
	WesternLongitude = 100163u,
	[Description("Longitude-West (location of weather cell).  type: Unsigned Integer.")]
	LongitudeWestLocationOfWeatherCell = 100164u,
	[Description("Accomplished accept.  type: Boolean.  range: 0 Accept, 1 Non-accept.")]
	AccomplishedAccept = 100165u,
	[Description("CD ROM Number (Disk ID for terrain).  type: Integer.")]
	CDROMNumberDiskIDForTerrain = 100165u,
	[Description("DTED disk ID.  type: Unsigned Integer.  length: 32 bits.")]
	const_424 = 100166u,
	[Description("Altitude.  type: Floating point.")]
	Altitude_100167 = 100167u,
	[Description("Tactical System Status.  type: Unsigned Integer.  range: 0 Operational, 1 Non-operational, 2 Unknown, 3 Not available.")]
	TacticalSystemStatus = 100169u,
	[Description("JTIDS Status.  type: Unsigned Integer.  range: 0 Operational, 1 Non-operational, 2 Unknown, 3 Not available.")]
	const_427 = 100170u,
	[Description("TADIL-J Status.  type: Unsigned Integer.  range: 0 Operational, 1 Non-operational, 2 Unknown, 3 Not available.")]
	TADILJStatus = 100171u,
	[Description("DSDD Status.  type: Unsigned Integer.  range: 0 Operational, 1 Non-operational, 2 Unknown, 3 Not available.")]
	const_429 = 100172u,
	[Description("Weapon System Status.")]
	WeaponSystemStatus = 100200u,
	[Description("Subsystem status.  type: Boolean.  length: 32 bits.")]
	SubsystemStatus = 100205u,
	[Description("Number of interceptors fired.  type: Unsigned Integer.  length: 32 bits.")]
	NumberOfInterceptorsFired = 100206u,
	[Description("Number of interceptor detonations.  type: Unsigned Integer.  length: 32 bits.")]
	NumberOfInterceptorDetonations = 100207u,
	[Description("Number of message buffers dropped.  type: Unsigned Integer.  length: 32 bits.")]
	NumberOfMessageBuffersDropped = 100208u,
	[Description("Satellite sensor background (year, day).  type: Unsigned Integer, Unsigned Integer.  length: 16 bits, 16 bits.  units: years, Julian days.  range: 1-366.")]
	SatelliteSensorBackgroundYearDay = 100213u,
	[Description("Satellite sensor background (hour, minute).  type: Unsigned Integer, Unsigned Integer.  length: 16 bits, 16 bits.  units: hours, minutes.  range: 0-23,0-59.")]
	SatelliteSensorBackgroundHourMinute = 100214u,
	[Description("Script Number.  type: Integer.  length: 32.")]
	ScriptNumber = 100218u,
	[Description("Entity/Track/Update Data.")]
	EntityTrackUpdateData = 100300u,
	[Description("Local/Force Training.")]
	LocalForceTraining = 100400u,
	[Description("Entity/Track Identity Data.")]
	EntityTrackIdentityData = 100500u,
	[Description("Entity for Track Event.  type: Variable.  length: 48.  range: Entity being tracked.")]
	EntityForTrackEvent = 100510u,
	[Description("IFF (Friend-Foe) status.  type: Unsigned Integer.  length: 32.  range: 0 Unidentified / Unknown, 1 Perceived Friendly, 2 Perceived Hostile.")]
	const_442 = 100520u,
	[Description("Engagement Data.")]
	EngagementData = 100600u,
	[Description("Target Latitude.  type: Integer.  length: 32.  units: (10000th) Degrees.")]
	TargetLatitude = 100610u,
	[Description("Target Longitude.  type: Integer.  length: 32.  units: (10000th) Degrees.")]
	TargetLongitude = 100620u,
	[Description("Area of Interest (Ground Impact Circle) Center Latitude.  type: Integer.  length: 32.  units: (10000th) Degrees.")]
	AreaOfInterestGroundImpactCircleCenterLatitude = 100631u,
	[Description("Area of Interest (Ground Impact Circle) Center Longitude.  type: Integer.  length: 32.  units: (10000th) Degrees.")]
	AreaOfInterestGroundImpactCircleCenterLongitude = 100632u,
	[Description("Area of Interest (Ground Impact Circle) Radius.  type: Unsigned Integer.  length: 32.  units: Meters.")]
	AreaOfInterestGroundImpactCircleRadius = 100633u,
	[Description("Area of Interest Type.  type: Unsigned Integer.  length: 32.  range: 0 Unspecified, 1 TBM Defense.")]
	AreaOfInterestType = 100634u,
	[Description("Target Aggregate ID.  type: Variable.  length: 48.")]
	TargetAggregateID = 100640u,
	[Description("GIC Identification Number.  type: Unsigned Integer.  length: 32.")]
	GICIdentificationNumber = 100650u,
	[Description("Estimated Time of Flight to TBM Impact.  type: Floating Point.  length: 32.  range: Seconds from time in PDU header.")]
	EstimatedTimeOfFlightToTBMImpact = 100660u,
	[Description("Estimated Intercept Time.  type: Floating Point.  length: 32.  range: Seconds from time in PDU header.")]
	EstimatedInterceptTime = 100661u,
	[Description("Estimated Time of Flight to Next Waypoint.  type: Floating Point.  length: 32.  range: Seconds from time in PDU header.")]
	EstimatedTimeOfFlightToNextWaypoint = 100662u,
	[Description("Entity/Track Equipment Data.")]
	EntityTrackEquipmentData = 100700u,
	[Description("Emission/EW Data.")]
	EmissionEWData = 100800u,
	[Description("Appearance Data.")]
	AppearanceData = 100900u,
	[Description("Command/Order Data.")]
	CommandOrderData = 101000u,
	[Description("Environmental Data.")]
	EnvironmentalData = 101100u,
	[Description("Significant Event Data.")]
	SignificantEventData = 101200u,
	[Description("Operator Action Data.")]
	OperatorActionData = 101300u,
	[Description("ADA Engagement Mode.  type: Unsigned Integer.  length: 32.  range: 0 Air, 1 ATBM.")]
	ADAEngagementMode = 101310u,
	[Description("ADA Shooting Status.  type: Unsigned Integer.  length: 32.  range: 0 Can not engage, 1 Can engage,.")]
	ADAShootingStatus = 101320u,
	[Description("ADA Mode.  type: Unsigned Integer.  length: 32.  range: 0 Shut down, 1 Active.")]
	ADAMode = 101321u,
	[Description("ADA Radar Status.  type: Unsigned Integer.  length: 32.  range: 0 Off, 1 On, 2 Momentary On.")]
	ADARadarStatus = 101330u,
	[Description("Shoot Command.  type: Unsigned Integer.  length: 32.  range: 0 Undefined, Greater than 0 Number of Shots to take.")]
	ShootCommand = 101340u,
	[Description("ADA Weapon Status.  type: Unsigned Integer.  length: 32.  range: 0 None, 1 Free, 2 Tight, 3 Hold.")]
	ADAWeaponStatus = 101350u,
	[Description("ADA Firing Disciple.  type: Unsigned Integer.  length: 32.  range: 0 SLS_ABT, 1 Shoot 2_ABT, 2 Lash Mode, 3 SLS_TM, 4 Shoot2_TM, 5 Default.")]
	ADAFiringDisciple = 101360u,
	[Description("Order Status.  type: Unsigned Integer.  length: 32.  range: 0 Cancel Engagement, 1 Engage Assignment.")]
	OrderStatus = 101370u,
	[Description("Time Synchronization.")]
	TimeSynchronization = 101400u,
	[Description("Tomahawk Data.")]
	TomahawkData = 101500u,
	[Description("Number of Detonations.  type: Unsigned Integer.")]
	NumberOfDetonations = 102100u,
	[Description("Number of Intercepts.  type: Unsigned Integer.")]
	NumberOfIntercepts = 102200u,
	[Description("OBT Control MT-201.  type: Variable Record.  length: 64.")]
	OBTControlMT201 = 200201u,
	[Description("Sensor Data MT-202.  type: Variable Record.  length: 64.")]
	SensorDataMT202 = 200202u,
	[Description("Environmental Data MT-203.  type: Variable Record.  length: 64.")]
	EnvironmentalDataMT203 = 200203u,
	[Description("Ownship Data MT-204.  type: Variable Record.  length: 128.")]
	OwnshipDataMT204 = 200204u,
	[Description("Acoustic Contact Data MT-205.  type: Variable Record.  length: 288.")]
	AcousticContactDataMT205 = 200205u,
	[Description("Sonobuoy Data MT-207.  type: Variable Record.  length: 64.")]
	SonobuoyDataMT207 = 200207u,
	[Description("Sonobuoy Contact Data MT-210.  type: Variable Record.  length: 64.")]
	SonobuoyContactDataMT210 = 200210u,
	[Description("Helo Control MT-211.  type: Variable Record.  length: 64.")]
	HeloControlMT211 = 200211u,
	[Description("ESM Control Data.  type: Variable Record.  length: 96.")]
	ESMControlData = 200213u,
	[Description("ESM Contact Data MT-214.  type: Variable Record.  length: 192.")]
	const_483 = 200214u,
	[Description("ESM Emitter Data MT-215.  type: Variable Record.  length: 64.")]
	const_484 = 200215u,
	[Description("Weapon Definition Data MT-217.  type: Variable Record.  length: 224.")]
	WeaponDefinitionDataMT217 = 200216u,
	[Description("Weapon Preset Data MT-217.  type: Variable Record.  length: 256.")]
	WeaponPresetDataMT217 = 200217u,
	[Description("OBT Control MT-301.  type: Variable Record.  length: 64.")]
	OBTControlMT301 = 200301u,
	[Description("Sensor Data MT-302.  type: Variable Record.  length: 64.")]
	SensorDataMT302 = 200302u,
	[Description("Environmental Data MT-303m.  type: Variable Record.  length: 64.")]
	EnvironmentalDataMT303m = 200303u,
	[Description("Ownship Data MT-304.  type: Variable Record.  length: 64.")]
	OwnshipDataMT304 = 200304u,
	[Description("Acoustic Contact Data MT-305.  type: Variable Record.  length: 288.")]
	AcousticContactDataMT305 = 200305u,
	[Description("Sonobuoy Data MT-307.  type: Variable Record.  length: 128.")]
	SonobuoyDataMT307 = 200307u,
	[Description("Sonobuoy Contact Data MT-310.  type: Variable Record.  length: 64.")]
	SonobuoyContactDataMT310 = 200310u,
	[Description("Helo Scenario / Equipment Status.  type: Variable Record.  length: 224.")]
	HeloScenarioEquipmentStatus = 200311u,
	[Description("ESM Control Data MT-313.  type: Variable Record.  length: 96.")]
	const_495 = 200313u,
	[Description("ESM Contact Data MT-314.  type: Variable Record.  length: 192.")]
	const_496 = 200314u,
	[Description("ESM Emitter Data MT-315.  type: Variable Record.  length: 64.")]
	const_497 = 200315u,
	[Description("Weapon Definition Data MT-316.  type: Variable Record.  length: 256.")]
	WeaponDefinitionDataMT316 = 200316u,
	[Description("Weapon Preset Data MT-317.  type: Variable Record.  length: 256.")]
	WeaponPresetDataMT317 = 200317u,
	[Description("Pairing/Association (eMT-56).  type: Variable Record.")]
	PairingAssociationEMT56 = 200400u,
	[Description("Pointer (eMT-57).  type: Variable Record.")]
	PointerEMT57 = 200401u,
	[Description("Reporting Responsibility (eMT-58).  type: Variable Record.")]
	ReportingResponsibilityEMT58 = 200402u,
	[Description("Track Number (eMT-59).  type: Variable Record.")]
	TrackNumberEMT59 = 200403u,
	[Description("ID for Link-11 Reporting (eMT-60).  type: Variable Record.")]
	IDForLink11ReportingEMT60 = 200404u,
	[Description("Remote Track (eMT-62).  type: Variable Record.")]
	RemoteTrackEMT62 = 200405u,
	[Description("Link-11 Error Rate (eMT-63).  type: Variable Record.")]
	const_506 = 200406u,
	[Description("Track Quality (eMT-64).  type: Variable Record.")]
	TrackQualityEMT64 = 200407u,
	[Description("Gridlock (eMT-65).  type: Variable Record.")]
	GridlockEMT65 = 200408u,
	[Description("Kill (eMT-66).  type: Variable Record.")]
	const_509 = 200409u,
	[Description("Track ID Change / Resolution (eMT-68).  type: Variable Record.")]
	TrackIDChangeResolutionEMT68 = 200410u,
	[Description("Weapons Status (eMT-69).  type: Variable Record.")]
	const_511 = 200411u,
	[Description("Link-11 Operator (eMT-70).  type: Variable Record.")]
	const_512 = 200412u,
	[Description("Force Training Transmit (eMT-71).  type: Variable Record.")]
	ForceTrainingTransmitEMT71 = 200413u,
	[Description("Force Training Receive (eMT-72).  type: Variable Record.")]
	ForceTrainingReceiveEMT72 = 200414u,
	[Description("Interceptor Amplification (eMT-75).  type: Variable Record.")]
	InterceptorAmplificationEMT75 = 200415u,
	[Description("Consumables (eMT-78).  type: Variable Record.")]
	ConsumablesEMT78 = 200416u,
	[Description("Link-11 Local Track Quality (eMT-95).  type: Variable Record.")]
	Link11LocalTrackQualityEMT95 = 200417u,
	[Description("DLRP (eMT-19).  type: Variable Record.")]
	const_518 = 200418u,
	[Description("Force Order (eMT-52).  type: Variable Record.")]
	ForceOrderEMT52 = 200419u,
	[Description("Wilco / Cantco (eMT-53).  type: Variable Record.")]
	WilcoCantcoEMT53 = 200420u,
	[Description("EMC Bearing (eMT-54).  type: Variable Record.")]
	EMCBearingEMT54 = 200421u,
	[Description("Change Track Eligibility (eMT-55).  type: Variable Record.")]
	ChangeTrackEligibilityEMT55 = 200422u,
	[Description("Land Mass Reference Point.  type: Variable Record.")]
	LandMassReferencePoint = 200423u,
	[Description("System Reference Point.  type: Variable Record.")]
	SystemReferencePoint = 200424u,
	[Description("PU Amplification.  type: Variable Record.")]
	PUAmplification = 200425u,
	[Description("Set/Drift.  type: Variable Record.")]
	SetDrift = 200426u,
	[Description("Begin Initialization (MT-1).  type: Variable Record.")]
	BeginInitializationMT1 = 200427u,
	[Description("Status and Control (MT-3).  type: Variable Record.")]
	const_528 = 200428u,
	[Description("Scintillation Change (MT-39).  type: Variable Record.")]
	ScintillationChangeMT39 = 200429u,
	[Description("Link 11 ID Control (MT-61).  type: Variable Record.")]
	const_530 = 200430u,
	[Description("PU Guard List.  type: Variable Record.")]
	const_531 = 200431u,
	[Description("Winds Aloft (MT-14).  type: Variable Record.")]
	WindsAloftMT14 = 200432u,
	[Description("Surface Winds (MT-15).  type: Variable Record.")]
	SurfaceWindsMT15 = 200433u,
	[Description("Sea State (MT-17).  type: Variable Record.")]
	SeaStateMT17 = 200434u,
	[Description("Magnetic Variation (MT-37).  type: Variable Record.")]
	MagneticVariationMT37 = 200435u,
	[Description("Track Eligibility (MT-29).  type: Variable Record.")]
	const_536 = 200436u,
	[Description("Training Track Notification.  type: Variable Record.")]
	TrainingTrackNotification = 200437u,
	[Description("Tacan Data (MT-32).  type: Variable Record.")]
	TacanDataMT32 = 200501u,
	[Description("Interceptor Amplification (MT-75).  type: Variable Record.")]
	InterceptorAmplificationMT75 = 200502u,
	[Description("Tacan Assignment (MT-76).  type: Variable Record.")]
	const_540 = 200503u,
	[Description("Autopilot Status (MT-77).  type: Variable Record.")]
	const_541 = 200504u,
	[Description("Consumables (MT-78).  type: Variable Record.")]
	ConsumablesMT78 = 200505u,
	[Description("Downlink (MT-79).  type: Variable Record.")]
	DownlinkMT79 = 200506u,
	[Description("TIN Report (MT-80).  type: Variable Record.")]
	TINReportMT80 = 200507u,
	[Description("Special Point Control (MT-81).  type: Variable Record.")]
	SpecialPointControlMT81 = 200508u,
	[Description("Control Discretes (MT-82).  type: Variable Record.")]
	const_546 = 200509u,
	[Description("Request Target Discretes(MT-83).  type: Variable Record.")]
	RequestTargetDiscretesMT83 = 200510u,
	[Description("Target Discretes (MT-84).  type: Variable Record.")]
	const_548 = 200511u,
	[Description("Reply Discretes (MT-85).  type: Variable Record.")]
	const_549 = 200512u,
	[Description("Command Maneuvers (MT-86).  type: Variable Record.")]
	const_550 = 200513u,
	[Description("Target Data (MT-87).  type: Variable Record.")]
	TargetDataMT87 = 200514u,
	[Description("Target Pointer (MT-88).  type: Variable Record.")]
	TargetPointerMT88 = 200515u,
	[Description("Intercept Data (MT-89).  type: Variable Record.")]
	InterceptDataMT89 = 200516u,
	[Description("Decrement Missile Inventory (MT-90).  type: Variable Record.")]
	DecrementMissileInventoryMT90 = 200517u,
	[Description("Link-4A Alert (MT-91).  type: Variable Record.")]
	Link4AAlertMT91 = 200518u,
	[Description("Strike Control (MT-92).  type: Variable Record.")]
	StrikeControlMT92 = 200519u,
	[Description("Speed Change (MT-25).  type: Variable Record.")]
	SpeedChangeMT25 = 200521u,
	[Description("Course Change (MT-26).  type: Variable Record.")]
	CourseChangeMT26 = 200522u,
	[Description("Altitude Change (MT-27).  type: Variable Record.")]
	const_559 = 200523u,
	[Description("ACLS AN/SPN-46 Status.  type: Variable Record.")]
	ACLSANSPN46Status = 200524u,
	[Description("ACLS Aircraft Report.  type: Variable Record.")]
	const_561 = 200525u,
	[Description("SPS-67 Radar Operator Functions.  type: Variable Record.")]
	SPS67RadarOperatorFunctions = 200600u,
	[Description("SPS-55 Radar Operator Functions.  type: Variable Record.")]
	SPS55RadarOperatorFunctions = 200601u,
	[Description("SPQ-9A Radar Operator Functions.  length: Variable Record.")]
	SPQ9ARadarOperatorFunctions = 200602u,
	[Description("SPS-49 Radar Operator Functions.  type: Variable Record.")]
	SPS49RadarOperatorFunctions = 200603u,
	[Description("MK-23 Radar Operator Functions.  type: Variable Record.")]
	MK23RadarOperatorFunctions = 200604u,
	[Description("SPS-48 Radar Operator Functions.  type: Variable Record.")]
	SPS48RadarOperatorFunctions = 200605u,
	[Description("SPS-40 Radar Operator Functions.  type: Variable Record.")]
	SPS40RadarOperatorFunctions = 200606u,
	[Description("MK-95 Radar Operator Functions.  type: Variable Record.")]
	MK95RadarOperatorFunctions = 200607u,
	[Description("Kill/No Kill.  type: Unsigned Integer.  length: 32.  range: 0 No kill, 1 Kill.")]
	KillNoKill = 200608u,
	[Description("CMT pc.  type: Unsigned Integer.  length: 32.")]
	CMTPc = 200609u,
	[Description("CMC4AirGlobalData.  type: Variable Recoed.")]
	CMC4AirGlobalData = 200610u,
	[Description("CMC4GlobalData.  type: Variable Record.")]
	CMC4GlobalData = 200611u,
	[Description("LINKSIM_COMMENT_PDU.  type: Integer.  length: 32.")]
	LINKSIMCOMMENTPDU = 200612u,
	[Description("NSST Ownship Control.  type: Integer.  length: 64.")]
	const_575 = 200613u,
	[Description("Other.  type: Integer.  length: 00.")]
	Other = 240000u,
	[Description("Mass Of The Vehicle.  type: real.  length: 32.")]
	MassOfTheVehicle = 240001u,
	[Description("Force ID.  type: Integer.  length: 8.")]
	ForceID_240002 = 240002u,
	[Description("Entity Type Kind.  type: Integer.  length: 8.")]
	EntityTypeKind = 240003u,
	[Description("Entity Type Domain.  type: Integer.  length: 8.")]
	EntityTypeDomain = 240004u,
	[Description("Entity Type Country.  type: Integer.  length: 16.")]
	EntityTypeCountry = 240005u,
	[Description("Entity Type Category.  type: Integer.  length: 8.")]
	EntityTypeCategory = 240006u,
	[Description("Entity Type Sub Category.  type: Integer.  length: 8.")]
	EntityTypeSubCategory = 240007u,
	[Description("Entity Type Specific.  type: Integer.  length: 8.")]
	EntityTypeSpecific = 240008u,
	[Description("Entity Type Extra.  type: Integer.  length: 8.")]
	EntityTypeExtra = 240009u,
	[Description("Alternative Entity Type Kind.  type: Integer.  length: 8.")]
	AlternativeEntityTypeKind = 240010u,
	[Description("Alternative Entity Type Domain.  type: Integer.  length: 8.")]
	AlternativeEntityTypeDomain = 240011u,
	[Description("Alternative Entity Type Country.  type: Integer.  length: 16.")]
	AlternativeEntityTypeCountry = 240012u,
	[Description("Alternative Entity Type Category.  type: integer.  length: 8.")]
	AlternativeEntityTypeCategory = 240013u,
	[Description("Alternative Entity Type Sub Category.  type: integer.  length: 8.")]
	AlternativeEntityTypeSubCategory = 240014u,
	[Description("Alternative Entity Type Specific.  type: integer.  length: 8.")]
	AlternativeEntityTypeSpecific = 240015u,
	[Description("Alternative Entity Type Extra.  type: integer.  length: 8.")]
	AlternativeEntityTypeExtra = 240016u,
	[Description("Entity Location X.  type: real.  length: 64.")]
	EntityLocationX = 240017u,
	[Description("Entity Location Y.  type: real.  length: 64.")]
	EntityLocationY = 240018u,
	[Description("Entity Location Z.  type: real.  length: 64.")]
	EntityLocationZ = 240019u,
	[Description("Entity Linear Velocity X.  type: real.  length: 32.")]
	EntityLinearVelocityX = 240020u,
	[Description("Entity Linear Velocity Y.  type: real.  length: 32.")]
	EntityLinearVelocityY = 240021u,
	[Description("Entity Linear Velocity Z.  type: real.  length: 32.")]
	EntityLinearVelocityZ = 240022u,
	[Description("Entity Orientation Psi.  type: real.  length: 32.")]
	EntityOrientationPsi = 240023u,
	[Description("Entity Orientation Theta.  type: real.  length: 32.")]
	EntityOrientationTheta = 240024u,
	[Description("Entity Orientation Phi.  type: real.  length: 32.")]
	EntityOrientationPhi = 240025u,
	[Description("Dead Reckoning Algorithm.  type: integer.  length: 8.")]
	DeadReckoningAlgorithm = 240026u,
	[Description("Dead Reckoning Linear Acceleration X.  type: real.  length: 32.")]
	DeadReckoningLinearAccelerationX = 240027u,
	[Description("Dead Reckoning Linear Acceleration Y.  type: real.  length: 32.")]
	DeadReckoningLinearAccelerationY = 240028u,
	[Description("Dead Reckoning Linear Acceleration Z.  type: real.  length: 32.")]
	DeadReckoningLinearAccelerationZ = 240029u,
	[Description("Dead Reckoning Angular Velocity X.  type: real.  length: 32.")]
	DeadReckoningAngularVelocityX = 240030u,
	[Description("Dead Reckoning Angular Velocity Y.  type: real.  length: 32.")]
	DeadReckoningAngularVelocityY = 240031u,
	[Description("Dead Reckoning Angular Velocity Z.  type: real.  length: 32.")]
	DeadReckoningAngularVelocityZ = 240032u,
	[Description("Entity Appearance.  type: integer.  length: 32.")]
	EntityAppearance = 240033u,
	[Description("Entity Marking Character Set.  type: integer.  length: 8.")]
	EntityMarkingCharacterSet = 240034u,
	[Description("Entity Marking 11 Bytes.  type: character.  length: 88.")]
	const_611 = 240035u,
	[Description("Capability.  type: integer.  length: 32.")]
	Capability = 240036u,
	[Description("Number Articulation Parameters.  type: integer.  length: 8.")]
	NumberArticulationParameters = 240037u,
	[Description("Articulation Parameter ID.  type: integer.  length: 32.")]
	ArticulationParameterID = 240038u,
	[Description("Articulation Parameter Type.  type: integer.  length: 32.")]
	ArticulationParameterType_240039 = 240039u,
	[Description("Articulation Parameter Value.  type: real.  length: 64.")]
	ArticulationParameterValue_240040 = 240040u,
	[Description("Type Of Stores.  type: integer.  length: 32.")]
	TypeOfStores = 240041u,
	[Description("Quantity Of Stores.  type: integer.  length: 32.")]
	QuantityOfStores = 240042u,
	[Description("Fuel Quantity.  type: real.  length: 32.")]
	FuelQuantity = 240043u,
	[Description("Radar System Status.  type: integer.  length: 32.")]
	RadarSystemStatus = 240044u,
	[Description("Radio Communication System Status.  type: integer.  length: 32.")]
	RadioCommunicationSystemStatus = 240045u,
	[Description("Default Time For Radio Transmission For Stationary Transmitters.  type: integer.  length: 32.")]
	DefaultTimeForRadioTransmissionForStationaryTransmitters = 240046u,
	[Description("Default Time For Radio Transmission For Moving Transmitters.  type: integer.  length: 32.")]
	DefaultTimeForRadioTransmissionForMovingTransmitters = 240047u,
	[Description("Body Part Damaged Ratio.  type: real.  length: 32.")]
	BodyPartDamagedRatio = 240048u,
	[Description("Name Of The Terrain Database File.  type: character.  length: 00.")]
	NameOfTheTerrainDatabaseFile = 240049u,
	[Description("Name Of Local File.  type: character.  length: 00.")]
	NameOfLocalFile = 240050u,
	[Description("Aimpoint Bearing.  type: real.  length: 32.")]
	AimpointBearing = 240051u,
	[Description("Aimpoint Elevation.  type: real.  length: 32.")]
	AimpointElevation = 240052u,
	[Description("Aimpoint Range.  type: real.  length: 32.")]
	AimpointRange = 240053u,
	[Description("Air Speed.  type: real.  length: 32.")]
	AirSpeed = 240054u,
	[Description("Altitude.  type: real.  length: 32.")]
	Altitude_240055 = 240055u,
	[Description("Application Status.  type: structure.  length: 32.")]
	ApplicationStatus = 240056u,
	[Description("Auto Iff.  type: integer.  length: 32.")]
	AutoIff = 240057u,
	[Description("Beacon Delay.  type: real.  length: 32.")]
	BeaconDelay = 240058u,
	[Description("Bingo Fuel Setting.  type: real.  length: 32.")]
	BingoFuelSetting = 240059u,
	[Description("Cloud Bottom.  type: real.  length: 32.")]
	CloudBottom = 240060u,
	[Description("Cloud Top.  type: real.  length: 32.")]
	CloudTop = 240061u,
	[Description("Direction.  type: real.  length: 32.")]
	Direction = 240062u,
	[Description("End Action.  type: integer.  length: 32.")]
	EndAction = 240063u,
	[Description("Frequency.  type: real.  length: 32.")]
	Frequency = 240064u,
	[Description("Freeze.  type: integer.  length: 32.")]
	Freeze = 240065u,
	[Description("Heading.  type: real.  length: 32.")]
	Heading = 240066u,
	[Description("Identification.  type: integer.  length: 32.")]
	Identification_240067 = 240067u,
	[Description("Initial Point Data.  type: integer.  length: 32.")]
	InitialPointData = 240068u,
	[Description("Latitude.  type: real.  length: 64.")]
	Latitude_240069 = 240069u,
	[Description("Lights.  type: integer.  length: 32.")]
	Lights_240070 = 240070u,
	[Description("Linear.  type: integer.  length: 32.")]
	Linear = 240071u,
	[Description("Longitude.  type: real.  length: 64.")]
	Longitude_240072 = 240072u,
	[Description("Low Altitude.  type: real.  length: 32.")]
	LowAltitude = 240073u,
	[Description("Mfd Formats.  type: integer.  length: 32.")]
	MfdFormats = 240074u,
	[Description("Nctr.  type: integer.  length: 32.")]
	Nctr = 240075u,
	[Description("Number Projectiles.  type: integer.  length: 32.")]
	NumberProjectiles = 240076u,
	[Description("Operation Code.  type: integer.  length: 32.")]
	OperationCode = 240077u,
	[Description("Pitch.  type: real.  length: 32.")]
	Pitch = 240078u,
	[Description("Profiles.  type: integer.  length: 32.")]
	Profiles = 240079u,
	[Description("Quantity.  type: integer.  length: 32.")]
	Quantity_240080 = 240080u,
	[Description("Radar Modes.  type: integer.  length: 32.")]
	RadarModes = 240081u,
	[Description("Radar Search Volume.  type: real.  length: 32.")]
	RadarSearchVolume = 240082u,
	[Description("Roll.  type: real.  length: 32.")]
	Roll = 240083u,
	[Description("Rotation.  type: real.  length: 32.")]
	Rotation_240084 = 240084u,
	[Description("Scale Factor X.  type: real.  length: 32.")]
	ScaleFactorX = 240085u,
	[Description("Scale Factor Y.  type: real.  length: 32.")]
	ScaleFactorY = 240086u,
	[Description("Shields.  type: integer.  length: 32.")]
	Shields = 240087u,
	[Description("Steerpoint.  type: structure.  length: 192.")]
	Steerpoint = 240088u,
	[Description("Spare1.  type: real.  length: 64.")]
	Spare1 = 240089u,
	[Description("Spare2.  type: real.  length: 64.")]
	Spare2 = 240090u,
	[Description("Team.  type: integer.  length: 32.")]
	Team = 240091u,
	[Description("Text.  type: character.  length: 00.")]
	Text = 240092u,
	[Description("Time Of Day.  type: integer.  length: 32.")]
	TimeOfDay = 240093u,
	[Description("Trail Flag.  type: integer.  length: 32.")]
	TrailFlag = 240094u,
	[Description("Trail Size.  type: real.  length: 32.")]
	TrailSize = 240095u,
	[Description("Type Of Projectile.  type: integer.  length: 32.")]
	TypeOfProjectile = 240096u,
	[Description("Type Of Target.  type: integer.  length: 32.")]
	TypeOfTarget = 240097u,
	[Description("Type Of Threat.  type: integer.  length: 32.")]
	TypeOfThreat = 240098u,
	[Description("Uhf Frequency.  type: real.  length: 32.")]
	UhfFrequency = 240099u,
	[Description("Utm Altitude.  type: real.  length: 32.")]
	UtmAltitude = 240100u,
	[Description("Utm Latitude.  type: real.  length: 64.")]
	UtmLatitude = 240101u,
	[Description("Utm Longitude.  type: real.  length: 64.")]
	UtmLongitude = 240102u,
	[Description("Vhf Frequency.  type: real.  length: 32.")]
	VhfFrequency = 240103u,
	[Description("Visibility Range.  type: real.  length: 32.")]
	VisibilityRange = 240104u,
	[Description("Void Aaa Hit.  type: integer.  length: 32.")]
	VoidAaaHit = 240105u,
	[Description("Void Collision.  type: integer.  length: 32.")]
	VoidCollision = 240106u,
	[Description("Void Earth Hit.  type: integer.  length: 32.")]
	VoidEarthHit = 240107u,
	[Description("Void Friendly.  type: integer.  length: 32.")]
	VoidFriendly = 240108u,
	[Description("Void Gun Hit.  type: integer.  length: 32.")]
	VoidGunHit = 240109u,
	[Description("Void Rocket Hit.  type: integer.  length: 32.")]
	VoidRocketHit = 240110u,
	[Description("Void Sam Hit.  type: integer.  length: 32.")]
	VoidSamHit = 240111u,
	[Description("Weapon Data.  type: integer.  length: 32.")]
	WeaponData = 240112u,
	[Description("Weapon Type.  type: integer.  length: 32.")]
	WeaponType = 240113u,
	[Description("Weather.  type: integer.  length: 32.")]
	Weather_240114 = 240114u,
	[Description("Wind Direction.  type: real.  length: 32.")]
	WindDirection_240115 = 240115u,
	[Description("Wind Speed.  type: real.  length: 32.")]
	WindSpeed = 240116u,
	[Description("Wing Station.  type: integer.  length: 32.")]
	WingStation = 240117u,
	[Description("Yaw.  type: real.  length: 32.")]
	Yaw = 240118u,
	[Description("Memory Offset.  type: integer.  length: 32.")]
	MemoryOffset = 240119u,
	[Description("Memory Data.  type: integer.  length: 00.")]
	MemoryData = 240120u,
	[Description("VASI.  type: integer.  length: 32.")]
	VASI = 240121u,
	[Description("Beacon.  type: integer.  length: 32.")]
	Beacon = 240122u,
	[Description("Strobe.  type: integer.  length: 32.")]
	Strobe = 240123u,
	[Description("Culture.  type: integer.  length: 32.")]
	Culture = 240124u,
	[Description("Approach.  type: integer.  length: 32.")]
	Approach = 240125u,
	[Description("Runway End.  type: integer.  length: 32.")]
	RunwayEnd = 240126u,
	[Description("Obstruction.  type: integer.  length: 32.")]
	Obstruction = 240127u,
	[Description("Runway Edge.  type: integer.  length: 32.")]
	RunwayEdge = 240128u,
	[Description("Ramp Taxiway.  type: integer.  length: 32.")]
	RampTaxiway = 240129u,
	[Description("Laser Bomb Code.  type: integer.  length: 32.")]
	LaserBombCode = 240130u,
	[Description("Rack Type.  type: integer.  length: 32.")]
	RackType = 240131u,
	[Description("HUD.  type: structure.  length: 00.")]
	HUD = 240132u,
	[Description("RoleFileName.  type: character.  length: 00.")]
	RoleFileName = 240133u,
	[Description("PilotName.  type: character.  length: 00.")]
	PilotName = 240134u,
	[Description("PilotDesignation.  type: integer.  length: 32.")]
	PilotDesignation = 240135u,
	[Description("Model Type.  type: integer.  length: 32.")]
	ModelType = 240136u,
	[Description("DIS Type.  type: integer.  length: 64.")]
	DISType = 240137u,
	[Description("Class.  type: integer.  length: 32.")]
	Class = 240138u,
	[Description("Channel.  type: integer.  length: 32.")]
	Channel = 240139u,
	[Description("Entity Type.  type: structure.  length: 64.")]
	EntityType_240140 = 240140u,
	[Description("Alternative Entity Type.  type: structure.  length: 64.")]
	AlternativeEntityType_240141 = 240141u,
	[Description("Entity Location.  type: structure.  length: 192.")]
	EntityLocation = 240142u,
	[Description("Entity Linear Velocity.  type: structure.  length: 96.")]
	EntityLinearVelocity = 240143u,
	[Description("Entity Orientation.  type: structure.  length: 96.")]
	EntityOrientation = 240144u,
	[Description("Dead Reckoning.  type: structure.  length: 320.")]
	DeadReckoning = 240145u,
	[Description("Failure Symptom.  type: integer.  length: 32.  range: 1=LimitSpeed, 2 =LimitGLoad, 3=Both.")]
	FailureSymptom = 240146u,
	[Description("Max Fuel.  type: real.  length: 32.")]
	MaxFuel = 240147u,
	[Description("Refueling Boom Connect.  type: integer.  length: 32.")]
	RefuelingBoomConnect = 240148u,
	[Description("Altitude AGL.  type: real.  length: 32.")]
	const_725 = 240149u,
	[Description("Calibrated Airspeed.  type: real.  length: 32.")]
	CalibratedAirspeed = 240150u,
	[Description("TACAN Channel.  type: integer.  length: 32.")]
	TACANChannel = 240151u,
	[Description("TACAN Band.  type: integer.  length: 32.  range: 0 = x, 1 = y.")]
	const_728 = 240152u,
	[Description("TACAN Mode.  type: integer.  length: 32.  range: 0 = off, 1 = rec, 2 = t/r, 3 = aa rec, 4 = aa t/r.")]
	const_729 = 240153u
}
