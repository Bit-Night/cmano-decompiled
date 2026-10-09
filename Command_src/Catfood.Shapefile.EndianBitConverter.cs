using System;

namespace Catfood.Shapefile;

public static class EndianBitConverter
{
	public static int ToInt32(byte[] value, int startIndex, ProvidedOrder order)
	{
		if (value != null)
		{
			if (startIndex + 4 <= value.Length)
			{
				if (BitConverter.IsLittleEndian && order == ProvidedOrder.Big)
				{
					byte[] array = new byte[4];
					Array.Copy(value, startIndex, array, 0, 4);
					Array.Reverse((Array)array);
					return BitConverter.ToInt32(array, 0);
				}
				return BitConverter.ToInt32(value, startIndex);
			}
			throw new ArgumentException("startIndex invalid (not enough space in value to extract an integer", "startIndex");
		}
		throw new ArgumentNullException("value");
	}

	public static double ToDouble(byte[] value, int startIndex, ProvidedOrder order)
	{
		if (value != null)
		{
			if (startIndex + 8 > value.Length)
			{
				throw new ArgumentException("startIndex invalid (not enough space in value to extract a double", "startIndex");
			}
			if (BitConverter.IsLittleEndian && order == ProvidedOrder.Big)
			{
				byte[] array = new byte[8];
				Array.Copy(value, startIndex, array, 0, 8);
				Array.Reverse((Array)array);
				return BitConverter.ToDouble(array, 0);
			}
			return BitConverter.ToDouble(value, startIndex);
		}
		throw new ArgumentNullException("value");
	}

	static EndianBitConverter()
	{
		Class72.smethod_20();
	}
}
