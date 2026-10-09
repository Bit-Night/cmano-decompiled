using System.Xml;

namespace Command_Core;

public sealed class ActivationPointContact : Contact
{
	public ActivationPointContact(double Lat, double Lon)
		: base(null)
	{
		Type = ContactType.ActivationPoint;
		((Module_Unit.Unit)this).set_Latitude((GlobalVariables.BooleanObject)null, Lat);
		((Module_Unit.Unit)this).set_Longitude((GlobalVariables.BooleanObject)null, Lon);
		base.Name = "BOL Activation Point: " + Misc.CoordsToEnglish(((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null));
		ObjectID_Set("ActivationPoint_" + XmlConvert.ToString(((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null)) + "_" + XmlConvert.ToString(((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null)));
	}

	public static ActivationPointContact FromString(string theString)
	{
		string[] array = theString.Split(new char[1] { '_' });
		double lat = XmlConvert.ToDouble(array[1]);
		double lon = XmlConvert.ToDouble(array[2]);
		return new ActivationPointContact(lat, lon);
	}

	static ActivationPointContact()
	{
		Class72.smethod_20();
	}
}
