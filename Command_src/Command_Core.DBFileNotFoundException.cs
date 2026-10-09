using System;

namespace Command_Core;

public sealed class DBFileNotFoundException : Exception
{
	public DBFileNotFoundException(string MessageString)
		: base(MessageString)
	{
	}

	static DBFileNotFoundException()
	{
		Class72.smethod_20();
	}
}
