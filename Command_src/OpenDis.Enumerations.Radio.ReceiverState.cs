using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Radio;

[Serializable]
public enum ReceiverState : ushort
{
	[Description("Off.")]
	Off,
	[Description("On but not receiving.")]
	OnButNotReceiving,
	[Description("On and receiving.")]
	OnAndReceiving
}
