namespace DotSpatial.Serialization;

public abstract class SerializationFormatter
{
	public abstract string ToString(object value);

	public abstract object FromString(string value);

	static SerializationFormatter()
	{
		Class72.smethod_20();
	}
}
