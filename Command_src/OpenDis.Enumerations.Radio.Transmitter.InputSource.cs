using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Radio.Transmitter;

[Serializable]
public enum InputSource : byte
{
	[Description("Other.")]
	Other,
	[Description("Pilot.")]
	Pilot,
	[Description("Copilot.")]
	Copilot,
	[Description("First Officer.")]
	FirstOfficer,
	[Description("Driver.")]
	Driver,
	[Description("Loader.")]
	Loader,
	[Description("Gunner.")]
	Gunner,
	[Description("Commander.")]
	Commander,
	[Description("Digital Data Device.")]
	DigitalDataDevice,
	[Description("Intercom.")]
	Intercom
}
