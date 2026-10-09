using System;
using OpenDis.Enumerations;
using OpenDis.Enumerations.EntityState.Type;

namespace OpenDis.Core;

public interface ICetItem : IComparable<ICetItem>, IComparable
{
	byte Category { get; set; }

	Country Country { get; set; }

	string Description { get; set; }

	byte Domain { get; set; }

	byte? Extra { get; set; }

	uint? Maximum { get; set; }

	EntityKind Kind { get; set; }

	byte? Specific { get; set; }

	byte? Subcategory { get; set; }
}
