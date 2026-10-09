using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Environment.ObjectState;

[Serializable]
[Flags]
public enum ArealObjectStatePDUModificationField : byte
{
	[Description("Set bit means 'Locations have been modified', reset bit means 'No locations have been modified'.")]
	Location = 1
}
