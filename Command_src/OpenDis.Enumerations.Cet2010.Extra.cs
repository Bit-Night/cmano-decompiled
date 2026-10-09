using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Xml.Serialization;

namespace OpenDis.Enumerations.Cet2010;

[Serializable]
[DebuggerStepThrough]
public class Extra : GenericEntrySingle, GInterface12, IGenericEntryDescription, IGenericEntry, INotifyPropertyChanged
{
	private ulong ulong_1;

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
				ulong num = value;
				RawUId = num.ToString(CultureInfo.InvariantCulture);
				RaisePropertyChanged("UId");
			}
		}
	}

	static Extra()
	{
		Class72.smethod_20();
	}
}
