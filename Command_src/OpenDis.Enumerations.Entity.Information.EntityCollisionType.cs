using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Entity.Information;

[Serializable]
public enum EntityCollisionType : byte
{
	[Description("Inelastic.")]
	Inelastic,
	[Description("Elastic.")]
	Elastic
}
