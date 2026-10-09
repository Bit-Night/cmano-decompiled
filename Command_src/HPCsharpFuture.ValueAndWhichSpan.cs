namespace HPCsharpFuture;

public struct ValueAndWhichSpan<T>
{
	private T Value;

	private int int_0;

	public ValueAndWhichSpan(T value, int whichSpan)
	{
		Value = value;
		int_0 = whichSpan;
	}

	static ValueAndWhichSpan()
	{
		Class72.smethod_20();
	}
}
