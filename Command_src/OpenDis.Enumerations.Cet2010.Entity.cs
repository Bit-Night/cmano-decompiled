using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Xml.Serialization;
using OpenDis.Enumerations.EntityState.Type;

namespace OpenDis.Enumerations.Cet2010;

[Serializable]
[DebuggerStepThrough]
public class Entity : GenericEntry
{
	private List<GenericEntryDescription> list_1;

	private Country country_0;

	private string string_3;

	private byte byte_0;

	private string string_4;

	private EntityKind entityKind_0;

	private string string_5;

	private ulong ulong_1;

	private string string_6;

	[XmlElement(/*Could not decode attribute arguments.*/)]
	[XmlElement(/*Could not decode attribute arguments.*/)]
	public List<GenericEntryDescription> Categories
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
				RaisePropertyChanged("Categories");
			}
		}
	}

	[XmlIgnore]
	public Country Country
	{
		get
		{
			return country_0;
		}
		set
		{
			if (country_0 != value)
			{
				int num = (int)value;
				RawCountry = num.ToString(CultureInfo.InvariantCulture);
				RaisePropertyChanged("Country");
			}
		}
	}

	[XmlIgnore]
	public byte Domain
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
				RawDomain = b.ToString(CultureInfo.InvariantCulture);
				RaisePropertyChanged("Domain");
			}
		}
	}

	[XmlIgnore]
	public EntityKind Kind
	{
		get
		{
			return entityKind_0;
		}
		set
		{
			if (entityKind_0 != value)
			{
				byte b = (byte)value;
				RawKind = b.ToString(CultureInfo.InvariantCulture);
				RaisePropertyChanged("Kind");
			}
		}
	}

	[XmlAttribute(AttributeName = "country", DataType = "nonNegativeInteger")]
	public string RawCountry
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
				int value2 = int.Parse(value, NumberStyles.Integer, CultureInfo.InvariantCulture);
				country_0 = (Country)Enum.ToObject(typeof(Country), value2);
				RaisePropertyChanged("RawCountry");
			}
		}
	}

	[XmlAttribute(AttributeName = "domain", DataType = "nonNegativeInteger")]
	public string RawDomain
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
				byte_0 = byte.Parse(value, NumberStyles.Integer, CultureInfo.InvariantCulture);
				RaisePropertyChanged("RawDomain");
			}
		}
	}

	[XmlAttribute(AttributeName = "kind", DataType = "nonNegativeInteger")]
	public string RawKind
	{
		get
		{
			return string_5;
		}
		set
		{
			if (string_5 != value)
			{
				string_5 = value;
				byte value2 = byte.Parse(value, CultureInfo.InvariantCulture);
				entityKind_0 = (EntityKind)Enum.ToObject(typeof(EntityKind), value2);
				RaisePropertyChanged("RawKind");
			}
		}
	}

	[XmlAttribute(AttributeName = "uid", DataType = "nonNegativeInteger")]
	public string RawUId
	{
		get
		{
			return string_6;
		}
		set
		{
			if (!(string_6 == value))
			{
				string_6 = value;
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

	static Entity()
	{
		Class72.smethod_20();
	}
}
