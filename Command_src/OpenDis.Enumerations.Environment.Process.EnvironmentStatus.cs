using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Environment.Process;

[Serializable]
[Flags]
public enum EnvironmentStatus : byte
{
	[Description("Indicates that the current PDU shall be the last PDU for the specified process")]
	Last = 1,
	[Description("Indicates that the specified environmental process is active")]
	On = 2
}
