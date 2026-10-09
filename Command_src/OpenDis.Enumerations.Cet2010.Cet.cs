using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Serialization;

namespace OpenDis.Enumerations.Cet2010;

[Serializable]
[XmlRoot("cet", IsNullable = false)]
[DebuggerStepThrough]
public class Cet : GenericTable
{
	private List<Entity> list_1;

	[XmlElement(/*Could not decode attribute arguments.*/)]
	public List<Entity> Entities
	{
		get
		{
			return list_1;
		}
		set
		{
			if (list_1 != value)
			{
				list_1 = value;
				RaisePropertyChanged("Entities");
			}
		}
	}

	static Cet()
	{
		Class72.smethod_20();
	}
}
