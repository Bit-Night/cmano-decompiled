using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Type;

[Serializable]
public enum RadioNomenclatureVersion : byte
{
	[Description("Other.")]
	Other,
	[Description("Joint Electronics Type Designation System (JETDS) Nomenclature (AN/ per Mil-STD-196).")]
	JointElectronicsTypeDesignationSystemJETDSNomenclatureANPerMilSTD196,
	[Description("Manufacturer Designation.")]
	ManufacturerDesignation,
	[Description("National Designation.")]
	NationalDesignation
}
