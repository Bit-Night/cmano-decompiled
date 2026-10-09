namespace VectorTileRenderer;

public class TileValue
{
	public string StringValue;

	public float? FloatValue;

	public double? DoubleValue;

	public long? IntValue;

	public ulong? nullable_0;

	public long? nullable_1;

	public bool? BoolValue;

	public override string ToString()
	{
		if (StringValue == null)
		{
			if (!FloatValue.HasValue)
			{
				if (!DoubleValue.HasValue)
				{
					if (!IntValue.HasValue)
					{
						if (!nullable_0.HasValue)
						{
							if (!nullable_1.HasValue)
							{
								if (BoolValue.HasValue)
								{
									return BoolValue.ToString();
								}
								return "";
							}
							return nullable_1.ToString();
						}
						return nullable_0.ToString();
					}
					return IntValue.ToString();
				}
				return DoubleValue.ToString();
			}
			return FloatValue.ToString();
		}
		return StringValue;
	}

	static TileValue()
	{
		Class72.smethod_20();
	}
}
