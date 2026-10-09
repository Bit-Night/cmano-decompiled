using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.DistributedEmission.UnderwaterAcoustic;

[Serializable]
public enum AdditionalPassiveActivityParameterIndex : ushort
{
	[Description("Other.")]
	Other,
	[Description("Graham's MKV Coffee Maker.")]
	GrahamSMKVCoffeeMaker
}
