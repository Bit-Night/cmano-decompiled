using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Xml.Serialization;

namespace OpenDis.Enumerations.Cet2006;

[Serializable]
[DebuggerStepThrough]
public class Category : GenericEntry
{
	private List<Subcategory> list_0;

	private byte byte_0;

	private string string_3;

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

	[XmlAttribute(AttributeName = "id", DataType = "nonNegativeInteger")]
	public string RawId
	{
		get
		{
			return string_3;
		}
		set
		{
			VerifyNumericString(value, allowNullOrEmpty: false);
			if (string_3 != value)
			{
				string_3 = value;
				byte_0 = byte.Parse(value, CultureInfo.InvariantCulture);
				RaisePropertyChanged("RawId");
			}
		}
	}

	[XmlElement(/*Could not decode attribute arguments.*/)]
	public List<Subcategory> Subcategories
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
				RaisePropertyChanged("Subcategories");
			}
		}
	}

	static Category()
	{
		Class72.smethod_20();
	}
}
