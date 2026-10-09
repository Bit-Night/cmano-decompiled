using System;

namespace Microsoft.Collections.Extensions;

internal static class ThrowHelper
{
	internal static void ThrowInvalidOperationException_ConcurrentOperationsNotSupported()
	{
		throw new InvalidOperationException("Operations that change non-concurrent collections must have exclusive access. A concurrent update was performed on this collection and corrupted its state. The collection's state is no longer correct.");
	}

	internal static void ThrowKeyArgumentNullException()
	{
		throw new ArgumentNullException("key");
	}

	internal static void ThrowCapacityArgumentOutOfRangeException()
	{
		throw new ArgumentOutOfRangeException("capacity");
	}

	internal static bool ThrowNotSupportedException_ReadOnly_Modification()
	{
		throw new NotSupportedException("The collection is read-only");
	}

	internal static bool ThrowNotSupportedException()
	{
		throw new NotSupportedException();
	}

	static ThrowHelper()
	{
		Class72.smethod_20();
	}
}
