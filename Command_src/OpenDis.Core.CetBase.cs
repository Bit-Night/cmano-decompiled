using System;

namespace OpenDis.Core;

public class CetBase
{
	protected void VerifyNumericString(string value, bool allowNullOrEmpty)
	{
		if (!allowNullOrEmpty && string.IsNullOrEmpty(value))
		{
			throw new ArgumentNullException("Value must be greater or equal to 0.");
		}
		if (value == null)
		{
			return;
		}
		for (int i = 0; i < value.Length; i++)
		{
			if (value[i] < '0' || value[i] > '9')
			{
				throw new ArgumentOutOfRangeException("Value must be greater or equal to 0.");
			}
		}
	}

	static CetBase()
	{
		Class72.smethod_20();
	}
}
