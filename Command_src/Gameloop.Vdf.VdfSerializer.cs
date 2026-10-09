using System.IO;
using Gameloop.Vdf.Linq;

namespace Gameloop.Vdf;

public sealed class VdfSerializer
{
	private readonly VdfSerializerSettings vdfSerializerSettings_0;

	public VdfSerializer()
		: this(VdfSerializerSettings.Default)
	{
	}

	public VdfSerializer(VdfSerializerSettings settings)
	{
		vdfSerializerSettings_0 = settings;
	}

	public void Serialize(TextWriter textWriter, VToken value)
	{
		using VdfWriter writer = new VdfTextWriter(textWriter, vdfSerializerSettings_0);
		value.WriteTo(writer);
	}

	public VProperty Deserialize(TextReader textReader)
	{
		using VdfReader vdfReader = new VdfTextReader(textReader, vdfSerializerSettings_0);
		if (!vdfReader.ReadToken())
		{
			throw new VdfException("Incomplete VDF data.");
		}
		return method_0(vdfReader);
	}

	private VProperty method_0(VdfReader vdfReader_0)
	{
		VProperty vProperty = new VProperty();
		vProperty.Key = vdfReader_0.Value;
		if (vdfReader_0.ReadToken())
		{
			if (vdfReader_0.CurrentState == VdfReader.State.Property)
			{
				vProperty.Value = new VValue(vdfReader_0.Value);
			}
			else
			{
				vProperty.Value = method_1(vdfReader_0);
			}
			return vProperty;
		}
		throw new VdfException("Incomplete VDF data.");
	}

	private VObject method_1(VdfReader vdfReader_0)
	{
		VObject vObject = new VObject();
		if (!vdfReader_0.ReadToken())
		{
			throw new VdfException("Incomplete VDF data.");
		}
		while (vdfReader_0.CurrentState != VdfReader.State.Object || vdfReader_0.Value != '}'.ToString())
		{
			vObject.Add(method_0(vdfReader_0));
			if (vdfReader_0.ReadToken())
			{
				continue;
			}
			throw new VdfException("Incomplete VDF data.");
		}
		return vObject;
	}

	static VdfSerializer()
	{
		Class72.smethod_20();
	}
}
