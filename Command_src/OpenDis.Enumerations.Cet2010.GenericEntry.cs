using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Enumerations.Cet2010;

[Serializable]
[DebuggerStepThrough]
[XmlInclude(typeof(GenericEntryDescription))]
[XmlInclude(typeof(ExtraRange))]
[XmlInclude(typeof(SpecificRange))]
[XmlInclude(typeof(SubcategoryRange))]
[XmlInclude(typeof(Entity))]
[XmlInclude(typeof(CategoryRange))]
[XmlInclude(typeof(GenericEntrySingle))]
[XmlInclude(typeof(Extra))]
[XmlInclude(typeof(Specific))]
[XmlInclude(typeof(Subcategory))]
[XmlInclude(typeof(Category))]
[XmlInclude(typeof(GenericEntryString))]
[XmlInclude(typeof(GenericEntryRange))]
public abstract class GenericEntry : CetBase, INotifyPropertyChanged, IGenericEntry
{
	private static Regex regex_0;

	private List<object> list_0;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private string string_0;

	private GenericEntryStatus genericEntryStatus_0;

	private bool bool_6;

	private string string_1;

	private ulong ulong_0;

	private string string_2;

	[CompilerGenerated]
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	[XmlAttribute(AttributeName = "baseuuid")]
	public bool BaseUuid
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
				RaisePropertyChanged("BaseUuid");
			}
		}
	}

	[XmlIgnore]
	public bool BaseUuidSpecified
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
				RaisePropertyChanged("BaseUuidSpecified");
			}
		}
	}

	[XmlElement(/*Could not decode attribute arguments.*/)]
	[XmlElement(/*Could not decode attribute arguments.*/)]
	public List<object> ChangeRequests
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
				RaisePropertyChanged("ChangeRequests");
			}
		}
	}

	[XmlAttribute(AttributeName = "deprecated")]
	public bool Deprecated
	{
		get
		{
			return bool_2;
		}
		set
		{
			if (bool_2 != value)
			{
				bool_2 = value;
				RaisePropertyChanged("Deprecated");
			}
		}
	}

	[XmlIgnore]
	public bool DeprecatedSpecified
	{
		get
		{
			return bool_3;
		}
		set
		{
			if (bool_3 != value)
			{
				bool_3 = value;
				RaisePropertyChanged("DeprecatedSpecified");
			}
		}
	}

	[XmlAttribute(AttributeName = "draft1278")]
	public bool Draft1278
	{
		get
		{
			return bool_4;
		}
		set
		{
			if (bool_4 != value)
			{
				bool_4 = value;
				RaisePropertyChanged("Draft1278");
			}
		}
	}

	[XmlIgnore]
	public bool Draft1278Specified
	{
		get
		{
			return bool_5;
		}
		set
		{
			if (bool_5 != value)
			{
				bool_5 = value;
				RaisePropertyChanged("Draft1278Specified");
			}
		}
	}

	[XmlAttribute(AttributeName = "footnote")]
	public string Footnote
	{
		get
		{
			return string_0;
		}
		set
		{
			if (!(string_0 == value))
			{
				string_0 = value;
				RaisePropertyChanged("Footnote");
			}
		}
	}

	[XmlAttribute(AttributeName = "xref", DataType = "positiveInteger")]
	public string RawXRef
	{
		get
		{
			return string_2;
		}
		set
		{
			if (!(string_2 == value))
			{
				string_2 = value;
				ulong_0 = ulong.Parse(value, CultureInfo.InvariantCulture);
				RaisePropertyChanged("RawXRref");
			}
		}
	}

	[XmlAttribute(AttributeName = "status")]
	public GenericEntryStatus Status
	{
		get
		{
			return genericEntryStatus_0;
		}
		set
		{
			if (genericEntryStatus_0 != value)
			{
				genericEntryStatus_0 = value;
				RaisePropertyChanged("Status");
			}
		}
	}

	[XmlIgnore]
	public bool StatusSpecified
	{
		get
		{
			return bool_6;
		}
		set
		{
			if (bool_6 != value)
			{
				bool_6 = value;
				RaisePropertyChanged("StatusSpecified");
			}
		}
	}

	[XmlAttribute(AttributeName = "uuid")]
	public string Uuid
	{
		get
		{
			return string_1;
		}
		set
		{
			if (!(string_1 == value))
			{
				if (!regex_0.IsMatch(value, 0))
				{
					throw new ArgumentException("Invalid value! Value must be conformant with RFC-4122.");
				}
				string_1 = value;
				RaisePropertyChanged("Uuid");
			}
		}
	}

	[XmlIgnore]
	public ulong XRef
	{
		get
		{
			return ulong_0;
		}
		set
		{
			if (ulong_0 != value)
			{
				ulong num = value;
				RawXRef = num.ToString(CultureInfo.InvariantCulture);
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

	static GenericEntry()
	{
		Class72.smethod_20();
		regex_0 = new Regex("[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}");
	}
}
