using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Enumerations.Cet2006;

[Serializable]
[XmlInclude(typeof(Category))]
[XmlInclude(typeof(Subcategory))]
[XmlInclude(typeof(Specific))]
[XmlInclude(typeof(Extra))]
[DebuggerStepThrough]
public class GenericEntry : CetBase, INotifyPropertyChanged
{
	private bool bool_0;

	private bool bool_1;

	private string string_0;

	private string string_1;

	private bool bool_2;

	private bool bool_3;

	private string string_2;

	[CompilerGenerated]
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	[XmlAttribute(AttributeName = "deleted")]
	public bool Deleted
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
				RaisePropertyChanged("Deleted");
			}
		}
	}

	[XmlIgnore]
	public bool DeletedSpecified
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
				RaisePropertyChanged("DeletedSpecified");
			}
		}
	}

	[XmlAttribute(AttributeName = "description")]
	public string Description
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
				RaisePropertyChanged("Description");
			}
		}
	}

	[XmlAttribute(AttributeName = "footnote")]
	public string Footnote
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
				RaisePropertyChanged("Footnote");
			}
		}
	}

	[XmlAttribute(AttributeName = "unused")]
	public bool Unused
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
				RaisePropertyChanged("Unused");
			}
		}
	}

	[XmlIgnore]
	public bool UnusedSpecified
	{
		get
		{
			return bool_3;
		}
		set
		{
			if (bool_3)
			{
				bool_3 = value;
				RaisePropertyChanged("UnusedSpecified");
			}
		}
	}

	[XmlAttribute(AttributeName = "xref")]
	public string XRef
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
	}
}
