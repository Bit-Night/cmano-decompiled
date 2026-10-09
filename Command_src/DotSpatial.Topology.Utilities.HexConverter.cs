using System;

namespace DotSpatial.Topology.Utilities;

public class HexConverter
{
	private HexConverter()
	{
	}

	public static string ConvertAny2Any(string valueIn, int baseIn, int baseOut)
	{
		string result = "Error";
		valueIn = valueIn.ToUpper();
		if (baseIn >= 2 && baseIn <= 36 && baseOut >= 2 && baseOut <= 36)
		{
			if (valueIn.Trim().Length == 0)
			{
				return result;
			}
			if (baseIn == baseOut)
			{
				return valueIn;
			}
			double num = 0.0;
			try
			{
				if (baseIn == 10)
				{
					num = double.Parse(valueIn);
				}
				else
				{
					char[] array = valueIn.ToCharArray();
					int num2 = array.Length;
					for (int i = 0; i < array.Length; i++)
					{
						int num3 = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(array[i]);
						if (num3 >= 0 && num3 <= baseIn - 1)
						{
							num2--;
							num += (double)num3 * Math.Pow(baseIn, num2);
							continue;
						}
						return result;
					}
				}
				if (baseOut == 10)
				{
					result = num.ToString();
				}
				else
				{
					result = string.Empty;
					while (num > 0.0)
					{
						int num4 = (int)(num % (double)baseOut);
						num = (num - (double)num4) / (double)baseOut;
						result = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".Substring(num4, 1) + result;
					}
				}
			}
			catch (Exception ex)
			{
				result = ex.Message;
			}
			return result;
		}
		return result;
	}

	static HexConverter()
	{
		Class72.smethod_20();
	}
}
