using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml.Serialization;
using OpenDis.Core;
using OpenDis.Enumerations.EntityState.Type;

namespace OpenDis.Enumerations.Cet2006;

[Serializable]
[DebuggerStepThrough]
public class Entity : CetBase, INotifyPropertyChanged
{
	private List<Category> list_0;

	private Country country_0;

	private string string_0;

	private string string_1;

	private byte byte_0;

	private string string_2;

	private string string_3;

	private EntityKind entityKind_0;

	private string string_4;

	private bool bool_0;

	private bool bool_1;

	private string string_5;

	[CompilerGenerated]
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	[XmlElement(/*Could not decode attribute arguments.*/)]
	public List<Category> Categories
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
				RaisePropertyChanged("Category");
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

	[XmlAttribute(AttributeName = "description")]
	public string Description
	{
		get
		{
			return string_1;
		}
		set
		{
			if (string_1 != value)
			{
				string_1 = value;
				RaisePropertyChanged("Description");
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

	[XmlAttribute(AttributeName = "footnote")]
	public string Footnote
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
				RaisePropertyChanged("Footnote");
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
			return string_0;
		}
		set
		{
			VerifyNumericString(value, allowNullOrEmpty: false);
			if (string_0 != value)
			{
				string_0 = value;
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
			return string_2;
		}
		set
		{
			VerifyNumericString(value, allowNullOrEmpty: false);
			if (string_2 != value)
			{
				string_2 = value;
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
			return string_4;
		}
		set
		{
			if (string_4 != value)
			{
				string_4 = value;
				byte value2 = byte.Parse(value, CultureInfo.InvariantCulture);
				entityKind_0 = (EntityKind)Enum.ToObject(typeof(EntityKind), value2);
				RaisePropertyChanged("RawKind");
			}
		}
	}

	[XmlAttribute(AttributeName = "unused")]
	public bool Unused
	{
		get
		{
			return bool_0;
		}
		set
		{
			if (bool_0 != value)
			{
				bool_0 = value;
				RaisePropertyChanged("Unused");
			}
		}
	}

	[XmlIgnore]
	public bool UnusedSpecified
	{
		get
		{
			return bool_1;
		}
		set
		{
			if (bool_1 != value)
			{
				bool_1 = value;
				RaisePropertyChanged("UnusedSpecified");
			}
		}
	}

	[XmlAttribute(AttributeName = "xref")]
	public string XRef
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
				RaisePropertyChanged("XRef");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		[CompilerGenerated]
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = propertyChangedEventHandler_0;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref propertyChangedEventHandler_0, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = propertyChangedEventHandler_0;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref propertyChangedEventHandler_0, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	protected void RaisePropertyChanged(string propertyName)
	{
		if (propertyChangedEventHandler_0 != null)
		{
			propertyChangedEventHandler_0(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	static Entity()
	{
		Class72.smethod_20();
	}
}
