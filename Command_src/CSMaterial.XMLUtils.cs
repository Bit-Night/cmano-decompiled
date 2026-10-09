using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace CSMaterial;

public static class XMLUtils
{
	public static IEnumerable<XElement> StreamElement(string xmlString, string elementName)
	{
		XmlReader reader = XmlReader.Create((TextReader)new StringReader(xmlString));
		try
		{
			while (reader.Name == elementName || reader.ReadToFollowing(elementName))
			{
				yield return (XElement)XNode.ReadFrom(reader);
			}
		}
		finally
		{
			((IDisposable)reader)?.Dispose();
		}
	}

	static XMLUtils()
	{
		Class72.smethod_20();
	}
}
