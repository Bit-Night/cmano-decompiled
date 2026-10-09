using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Xml.Serialization;

namespace OpenDis.Enumerations.Cet2010;

[Serializable]
[DebuggerStepThrough]
public class SpecificRange : GenericEntryRange, ISpecificOrSpecificRange, IGenericEntryDescription, IGenericEntry, INotifyPropertyChanged
{
	private List<GenericEntryDescription> fGwYwEmngup;

	private ulong ulong_1;

	private string string_4;

	[XmlElement(/*Could not decode attribute arguments.*/)]
	[XmlElement(/*Could not decode attribute arguments.*/)]
	public List<GenericEntryDescription> Extras
	{
		get
		{
			return fGwYwEmngup;
		}
		set
		{
			if (fGwYwEmngup != value)
			{
				fGwYwEmngup = value;
				RaisePropertyChanged("Extras");
			}
		}
	}

	[XmlAttribute(AttributeName = "uid", DataType = "nonNegativeInteger")]
	public string RawUId
	{
		get
		{
			return string_4;
		}
		set
		{
			if (!(string_4 == value))
			{
				string_4 = value;
				ulong_1 = ulong.Parse(value, CultureInfo.InvariantCulture);
				RaisePropertyChanged("RawUId");
			}
		}
	}

	[XmlIgnore]
	public ulong UId
	{
		get
		{
			return ulong_1;
		}
		set
		{
			if (ulong_1 != value)
			{
				RawUId = ((byte)value).ToString(CultureInfo.InvariantCulture);
				RaisePropertyChanged("UId");
			}
		}
	}

	static SpecificRange()
	{
		Class72.smethod_20();
	}
}
