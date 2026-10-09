using System.Xml;

namespace Command_Core;

public sealed class AimpointContact : Contact
{
	public AimpointContact(double Lat, double Lon)
		: base(null)
	{
		Type = ContactType.Aimpoint;
		((Module_Unit.Unit)this).set_Latitude((GlobalVariables.BooleanObject)null, Lat);
		((Module_Unit.Unit)this).set_Longitude((GlobalVariables.BooleanObject)null, Lon);
		((Module_Unit.Unit)this).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)Terrain.GetElevation(((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, (ActualUnit != null) ? ActualUnit.ParentScen : null));
		base.Name = "Aimpoint: " + Misc.CoordsToEnglish(((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null));
		ObjectID_Set("Aimpoint_" + XmlConvert.ToString(((Module_Unit.Unit)this).get_Latitude((GlobalVariables.BooleanObject)null)) + "_" + XmlConvert.ToString(((Module_Unit.Unit)this).get_Longitude((GlobalVariables.BooleanObject)null)));
	}

	public static AimpointContact FromString(string theString)
	{
		string[] array = theString.Split(new char[1] { '_' });
		double lat = XmlConvert.ToDouble(array[1]);
		double lon = XmlConvert.ToDouble(array[2]);
		return new AimpointContact(lat, lon);
	}

	static AimpointContact()
	{
		Class72.smethod_20();
	}
}
