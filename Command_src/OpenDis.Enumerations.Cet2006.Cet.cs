using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Serialization;

namespace OpenDis.Enumerations.Cet2006;

[Serializable]
[DebuggerStepThrough]
[XmlRoot("cet", Namespace = "", IsNullable = false)]
public class Cet : GenericTable
{
	private List<Entity> list_0;

	[XmlElement(/*Could not decode attribute arguments.*/)]
	public List<Entity> Entities
	{
		get
		{
			return list_0;
		}
		set
		{
			if (list_0 != value)
			{
				list_0 = value;
				RaisePropertyChanged("Entities");
			}
		}
	}

	static Cet()
	{
		Class72.smethod_20();
	}
}
