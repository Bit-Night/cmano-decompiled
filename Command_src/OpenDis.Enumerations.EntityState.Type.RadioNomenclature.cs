using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Type;

[Serializable]
public enum RadioNomenclature : ushort
{
	[Description("Other.")]
	Other,
	[Description("AN/ARN-118.")]
	ANARN118,
	[Description("AN/ARN-139.")]
	ANARN139,
	[Description("Generic Ground Fixed Transmitter.")]
	GenericGroundFixedTransmitter,
	[Description("Generic Ground Mobile Transmitter.")]
	GenericGroundMobileTransmitter
}
