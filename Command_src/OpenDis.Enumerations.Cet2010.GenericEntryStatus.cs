using System;
using System.Xml.Serialization;

namespace OpenDis.Enumerations.Cet2010;

[Serializable]
[XmlType(AnonymousType = true)]
public enum GenericEntryStatus
{
	pending,
	@new
}
