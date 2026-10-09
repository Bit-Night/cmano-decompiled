using System;

namespace Command;

public class WorkshopException : Exception
{
	public WorkshopException()
	{
	}

	public WorkshopException(string Message)
		: base(Message)
	{
	}

	static WorkshopException()
	{
		Class72.smethod_20();
	}
}
