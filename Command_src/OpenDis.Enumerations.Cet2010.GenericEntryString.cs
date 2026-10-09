using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace OpenDis.Enumerations.Cet2010;

[Serializable]
[DebuggerStepThrough]
public class GenericEntryString : GenericEntryDescription
{
	private string OnnYwlOxbmK;

	[XmlAttribute(AttributeName = "value")]
	public string Value
	{
		get
		{
			return OnnYwlOxbmK;
		}
		set
		{
			if (!(OnnYwlOxbmK == value))
			{
				OnnYwlOxbmK = value;
				RaisePropertyChanged("Value");
			}
		}
	}

	static GenericEntryString()
	{
		Class72.smethod_20();
	}
}
