using System.Xml.Serialization;

namespace WorldWind;

public class PlaceListSettings
{
	public class MetaDataEntry
	{
		[XmlAttribute]
		public string name;

		[XmlAttribute]
		public string value;

		static MetaDataEntry()
		{
			Class72.smethod_20();
		}
	}

	public class PlaceData
	{
		[XmlAttribute]
		public string Name;

		[XmlAttribute]
		public float Lat;

		[XmlAttribute]
		public float Lon;

		public MetaDataEntry[] metadata;

		static PlaceData()
		{
			Class72.smethod_20();
		}
	}

	public PlaceData[] places;

	static PlaceListSettings()
	{
		Class72.smethod_20();
	}
}
