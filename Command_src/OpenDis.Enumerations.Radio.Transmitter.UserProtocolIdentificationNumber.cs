using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Radio.Transmitter;

[Serializable]
public enum UserProtocolIdentificationNumber : uint
{
	[Description("CCSIL.  poc: Marnie Salisbury.  email: MARNIE@MITRE.ORG.")]
	CCSIL = 1u,
	[Description("A2ATD SINCGARS ERF.  type: Binary data.  poc: Chuck Woodman.  email: WOODMAN@ORLANDO.LORAL.COM.")]
	A2ATDSINCGARSERF = 5u,
	[Description("A2ATD CAC2.  type: Binary Report/Overlay data.  poc: Wayne Beard.  email: WBEARD@ORLANDO.LORAL.COM.")]
	const_2 = 6u,
	[Description("Battle Command.  type: Abbreviated Command and Control.  poc: Gary Gagnon.  email: ggagnon@cas-inc.com.")]
	BattleCommand = 20u,
	[Description("AFIWC IADS Track Report.  type: Binary Data.  poc: Randy Schuetz.  email: randy.schuetz@lackland.af.mil.")]
	const_4 = 30u,
	[Description("AFIWC IADS Comm C2 Message.  type: Binary Data.  poc: Randy Schuetz.  email: randy.schuetz@lackland.af.mil.")]
	AFIWCIADSCommC2Message = 31u,
	[Description("AFIWC IADS Ground Control Interceptor (GCI) Command.  type: Binary Data.  poc: Randy Schuetz.  email: randy.schuetz@lackland.af.mil.")]
	AFIWCIADSGroundControlInterceptorGCICommand = 32u,
	[Description("AFIWC Voice Text Message.  type: Binary Data.  poc: Randy Schuetz.  email: randy.schuetz@lackland.af.mil.")]
	AFIWCVoiceTextMessage = 35u,
	[Description("ModSAF Text Radio.  type: Free Format ASCII Text.  poc: Richard Schaffer.  email: RSCHAFFER@CAMB-LADS.LORAL.COM.")]
	ModSAFTextRadio = 177u,
	[Description("CCTT SINCGARS ERF-LOCKOUT.  type: Binary Data.  poc: Jim Keenan.  email: jimk@greatwall.cctt.com.")]
	CCTTSINCGARSERFLOCKOUT = 200u,
	[Description("CCTT SINCGARS ERF-HOPSET.  type: Binary Data.  poc: Jim Keenan.  email: jimk@greatwall.cctt.com.")]
	CCTTSINCGARSERFHOPSET = 201u,
	[Description("CCTT SINCGARS OTAR.  type: Binary Data.  poc: Jim Keenan.  email: jimk@greatwall.cctt.com.")]
	CCTTSINCGARSOTAR = 202u,
	[Description("CCTT SINCGARS DATA.  type: Binary Data.  poc: Jim Keenan.  email: jimk@greatwall.cctt.com.")]
	CCTTSINCGARSDATA = 203u,
	[Description("ModSAF FWA Forward Air Controller.  type: Binary data.  poc: Dan Coffin.  email: dcoffin@camb-lads.loral.com.")]
	ModSAFFWAForwardAirController = 546u,
	[Description("ModSAF Threat ADA C3.  type: Binary data.  poc: Dan Coffin.  email: dcoffin@camb-lads.loral.com.")]
	ModSAFThreatADAC3 = 832u,
	[Description("F-16 MTC AFAPD Protocol.  type: Packed Binary AFAPD Message Format for F-16 Block 50/52.  poc: Albert Ludwig.  org: The Boeing Company.  email: albert.j.ludwig@boeing.com.")]
	const_15 = 1000u,
	[Description("F-16 MTC IDL Protocol.  type: Packed Binary IDL Message Format for F-16 Block 50/52.  poc: Albert Ludwig.  org: The Boeing Company.  email: albert.j.ludwig@boeing.com.")]
	F16MTCIDLProtocol = 1100u,
	[Description("ModSAF Artillery Fire Control.  type: Structured text followed by binary data.  poc: Richard Schaffer.  email: RSCHAFFER@CAMB-LADS.LORAL.COM.")]
	ModSAFArtilleryFireControl = 4570u,
	[Description("AGTS.  type: Binary Report/ Overlay data.  poc: Steve Gendreau.  email: GENDREAU@ESCMAIL.ORL.MMC.COM.")]
	AGTS = 5361u,
	[Description("GC3.  type: Binary data.  poc: Karl Shepherd.  email: karl.shepherd@gsc.gte.com.")]
	GC3 = 6000u,
	[Description("WNCP data.  type: Binary data.  poc: Karl Shepherd.  email: karl.shepherd@gsc.gte.com.")]
	WNCPData = 6010u,
	[Description("Spoken text message.  type: Data about speaker followed by free ASCII text.  poc: Brett Kaylor.  org: GTE Government Systems.  email: brett.kaylor@gsc.gte.com.")]
	SpokenTextMessage = 6020u,
	[Description("Longbow IDM message.  type: Simulated IDM message for Longbow Apache Aircraft.  poc: Peter Obear.  org: Carmel Applied Technologies, Inc.  email: obear@catinet.com.")]
	LongbowIDMMessage = 6661u,
	[Description("Comanche IDM message.  type: Simulated IDM message for Comanche Aircraft.  poc: Peter Obear.  org: Carmel Applied Technologies, Inc.  email: obear@catinet.com.")]
	const_23 = 6662u,
	[Description("Longbow Airborne TACFIRE Message.  type: Simulated TACFIRE IDM message for Longbow Apache Aircraft.  poc: Peter Obear.  org: Carmel Applied Technologies, Inc.  email: obear@catinet.com.")]
	LongbowAirborneTACFIREMessage = 6663u,
	[Description("Longbow Ground TACFIRE Message.  type: Simulated TACFIRE IDM message for Longbow Apache Aircraft.  poc: Peter Obear.  org: Carmel Applied Technologies, Inc.  email: obear@catinet.com.")]
	LongbowGroundTACFIREMessage = 6664u,
	[Description("Longbow AFAPD Message.  type: Simulated AFAPD IDM message for Longbow Apache Aircraft.  poc: Peter Obear.  org: Carmel Applied Technologies, Inc.  email: obear@catinet.com.")]
	const_26 = 6665u,
	[Description("Longbow ERF message.  type: Simulated ERF message for Longbow Apache Aircraft.  poc: Jeffery Day.  org: Boeing - St. Louis.  email: Jeffrey.Day@MW.Boeing.com.")]
	LongbowERFMessage = 6666u
}
