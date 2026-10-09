using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Xml.Serialization;

namespace OpenDis.Enumerations.Cet2010;

[Serializable]
[DebuggerStepThrough]
public class ExtraRange : GenericEntryRange, GInterface12, IGenericEntryDescription, IGenericEntry, INotifyPropertyChanged
{
	private ulong fluYqcXbxQM;

	private string string_4;

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
				fluYqcXbxQM = ulong.Parse(value, CultureInfo.InvariantCulture);
				RaisePropertyChanged("RawUId");
			}
		}
	}

	[XmlIgnore]
	public ulong UId
	{
		get
		{
			return fluYqcXbxQM;
		}
		set
		{
			if (fluYqcXbxQM != value)
			{
				ulong num = value;
				RawUId = num.ToString(CultureInfo.InvariantCulture);
				RaisePropertyChanged("UId");
			}
		}
	}

	static ExtraRange()
	{
		Class72.smethod_20();
	}
}
