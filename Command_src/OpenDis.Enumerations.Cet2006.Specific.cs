using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Xml.Serialization;

namespace OpenDis.Enumerations.Cet2006;

[Serializable]
[DebuggerStepThrough]
public class Specific : GenericEntry
{
	private List<Extra> list_0;

	private byte byte_0;

	private byte byte_1;

	private string string_3;

	private string string_4;

	[XmlElement(/*Could not decode attribute arguments.*/)]
	public List<Extra> Extras
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
				RaisePropertyChanged("Extra");
			}
		}
	}

	[XmlIgnore]
	public byte Id
	{
		get
		{
			return byte_0;
		}
		set
		{
			if (byte_0 != value)
			{
				byte b = value;
				RawId = b.ToString(CultureInfo.InvariantCulture);
				RaisePropertyChanged("Id");
			}
		}
	}

	[XmlIgnore]
	public byte Id2
	{
		get
		{
			return byte_1;
		}
		set
		{
			if (byte_1 != value)
			{
				byte b = value;
				RawId2 = b.ToString(CultureInfo.InvariantCulture);
				RaisePropertyChanged("Id2");
			}
		}
	}

	[XmlAttribute(AttributeName = "id", DataType = "nonNegativeInteger")]
	public string RawId
	{
		get
		{
			return string_4;
		}
		set
		{
			VerifyNumericString(value, allowNullOrEmpty: false);
			if (string_4 != value)
			{
				string_4 = value;
				byte_0 = byte.Parse(value, CultureInfo.InvariantCulture);
				RaisePropertyChanged("RawId");
			}
		}
	}

	[XmlAttribute(AttributeName = "id2", DataType = "nonNegativeInteger")]
	public string RawId2
	{
		get
		{
			return string_3;
		}
		set
		{
			if (string_3 != value)
			{
				string_3 = value;
				byte_1 = byte.Parse(value, CultureInfo.InvariantCulture);
				RaisePropertyChanged("Id2");
			}
		}
	}

	static Specific()
	{
		Class72.smethod_20();
	}
}
