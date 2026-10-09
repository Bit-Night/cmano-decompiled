using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Radio.Intercom;

[Serializable]
public enum RecordType : ushort
{
	[Description("Entity Destination record.")]
	EntityDestinationRecord = 1,
	[Description("Group Destination record.")]
	GroupDestinationRecord,
	[Description("Group Assignment record.")]
	GroupAssignmentRecord
}
