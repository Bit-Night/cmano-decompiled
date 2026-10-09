using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Enumerations.Cet2006;

[Serializable]
[XmlInclude(typeof(Cet))]
[DebuggerStepThrough]
public class GenericTable : CetBase, INotifyPropertyChanged
{
	private string string_0;

	private ulong ulong_0;

	private string string_1;

	private ulong ulong_1;

	private string cUcYoiKehfQ;

	private string string_2;

	private string string_3;

	[CompilerGenerated]
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	[XmlAttribute(AttributeName = "cname")]
	public string CName
	{
		get
		{
			return string_0;
		}
		set
		{
			if (string_0 != value)
			{
				string_0 = value;
				RaisePropertyChanged("CName");
			}
		}
	}

	[XmlIgnore]
	public ulong Id
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
				RawId = num.ToString(CultureInfo.InvariantCulture);
				RaisePropertyChanged("Id");
			}
		}
	}

	[XmlIgnore]
	public ulong Length
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
				RawLength = num.ToString(CultureInfo.InvariantCulture);
				RaisePropertyChanged("Length");
			}
		}
	}

	[XmlAttribute(AttributeName = "name")]
	public string Name
	{
		get
		{
			return string_2;
		}
		set
		{
			if (string_2 != value)
			{
				string_2 = value;
				RaisePropertyChanged("Name");
			}
		}
	}

	[XmlAttribute(AttributeName = "id", DataType = "positiveInteger")]
	public string RawId
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
				ulong_0 = ulong.Parse(value, CultureInfo.InvariantCulture);
				RaisePropertyChanged("RawId");
			}
		}
	}

	[XmlAttribute(AttributeName = "length", DataType = "positiveInteger")]
	public string RawLength
	{
		get
		{
			return cUcYoiKehfQ;
		}
		set
		{
			if (cUcYoiKehfQ != value)
			{
				cUcYoiKehfQ = value;
				ulong_1 = ulong.Parse(value, CultureInfo.InvariantCulture);
				RaisePropertyChanged("RawLength");
			}
		}
	}

	[XmlAttribute(AttributeName = "source")]
	public string Source
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
				RaisePropertyChanged("Source");
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

	static GenericTable()
	{
		Class72.smethod_20();
	}
}
