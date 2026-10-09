namespace DotSpatial.Topology.Utilities;

public class Assert
{
	private Assert()
	{
	}

	public static void IsTrue(bool assertion)
	{
		IsTrue(assertion, null);
	}

	public static void IsTrue(bool assertion, string message)
	{
		if (!assertion)
		{
			if (message == null)
			{
				throw new AssertionFailedException();
			}
			throw new AssertionFailedException(message);
		}
	}

	public static void IsEquals(object expectedValue, object actualValue)
	{
		IsEquals(expectedValue, actualValue, null);
	}

	public static void IsEquals(object expectedValue, object actualValue, string message)
	{
		if (!actualValue.Equals(expectedValue))
		{
			throw new AssertionFailedException("Expected " + expectedValue?.ToString() + " but encountered " + actualValue?.ToString() + ((message != null) ? (": " + message) : string.Empty));
		}
	}

	static Assert()
	{
		Class72.smethod_20();
	}
}
