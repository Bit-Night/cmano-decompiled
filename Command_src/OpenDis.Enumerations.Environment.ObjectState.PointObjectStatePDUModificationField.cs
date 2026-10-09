using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Environment.ObjectState;

[Serializable]
[Flags]
public enum PointObjectStatePDUModificationField : byte
{
	[Description("Set bit means 'Location has been modified', reset bit means 'Location has not been modified'.")]
	Location = 1,
	[Description("Set bit means 'Orientation has been modified', reset bit means 'Orientation has not been modified'.")]
	Orientation = 2
}
