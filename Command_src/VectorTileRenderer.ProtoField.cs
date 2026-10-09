namespace VectorTileRenderer;

internal struct ProtoField
{
	public int FieldNumber;

	public WireType WireType;

	public ulong VarIntValue;

	public byte[] BytesValue;

	public uint Fixed32Value;

	public ulong Fixed64Value;
}
