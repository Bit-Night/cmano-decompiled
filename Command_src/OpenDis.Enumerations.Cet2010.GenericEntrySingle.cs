using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace OpenDis.Enumerations.Cet2010;

[Serializable]
[XmlInclude(typeof(Extra))]
[DebuggerStepThrough]
[XmlInclude(typeof(Category))]
[XmlInclude(typeof(Subcategory))]
[XmlInclude(typeof(Specific))]
public class GenericEntrySingle : GenericEntryDescription
{
	private int int_1;

	[XmlAttribute(AttributeName = "value")]
	public int Value
	{
		get
		{
			return int_1;
		}
		set
		{
			if (int_1 != value)
			{
				int_1 = value;
				RaisePropertyChanged("Value");
			}
		}
	}

	static GenericEntrySingle()
	{
		Class72.smethod_20();
	}
}
