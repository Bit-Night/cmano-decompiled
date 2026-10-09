using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace OpenDis.Enumerations.Cet2010;

[Serializable]
[DebuggerStepThrough]
[XmlInclude(typeof(SpecificRange))]
[XmlInclude(typeof(SubcategoryRange))]
[XmlInclude(typeof(CategoryRange))]
[XmlInclude(typeof(ExtraRange))]
public abstract class GenericEntryRange : GenericEntryDescription
{
	private int int_1;

	private int int_2;

	[XmlAttribute(AttributeName = "value_max")]
	public int Max
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
				RaisePropertyChanged("Max");
			}
		}
	}

	[XmlAttribute(AttributeName = "value_min")]
	public int Min
	{
		get
		{
			return int_2;
		}
		set
		{
			if (int_2 != value)
			{
				int_2 = value;
				RaisePropertyChanged("Min");
			}
		}
	}

	static GenericEntryRange()
	{
		Class72.smethod_20();
	}
}
