using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Type;

[Serializable]
public enum EntityKind : byte
{
	[Description("Other.")]
	Other,
	[Description("Platform.")]
	Platform,
	[Description("Munition.")]
	Munition,
	[Description("Life form.")]
	LifeForm,
	[Description("Environmental.")]
	Environmental,
	[Description("Cultural feature.")]
	CulturalFeature,
	[Description("Supply.")]
	Supply,
	[Description("Radio.")]
	Radio,
	[Description("Expendable.")]
	Expendable,
	[Description("Sensor/Emitter.")]
	SensorEmitter
}
