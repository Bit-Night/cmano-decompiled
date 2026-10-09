using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.DistributedEmission.UnderwaterAcoustic;

[Serializable]
public enum SystemName : ushort
{
	[Description("Other.")]
	Other,
	[Description("AN/BQQ-5.")]
	ANBQQ5,
	[Description("AN/SSQ-62.")]
	ANSSQ62,
	[Description("AN/SQS-23.")]
	ANSQS23,
	[Description("AN/SQS-26.")]
	ANSQS26,
	[Description("AN/SQS-53.")]
	ANSQS53,
	[Description("ALFS.")]
	ALFS,
	[Description("LFA.")]
	LFA,
	[Description("AN/AQS-901.")]
	ANAQS901,
	[Description("AN/AQS-902.")]
	ANAQS902
}
