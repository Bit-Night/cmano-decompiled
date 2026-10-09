namespace CSMaterial;

public struct BLENDFUNCTION
{
	private byte byte_0;

	private byte byte_1;

	private byte byte_2;

	private byte byte_3;

	public BLENDFUNCTION(byte op, byte flags, byte alpha, byte format)
	{
		byte_0 = op;
		byte_1 = flags;
		byte_2 = alpha;
		byte_3 = format;
	}

	static BLENDFUNCTION()
	{
		Class72.smethod_20();
	}
}
