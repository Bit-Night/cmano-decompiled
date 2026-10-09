using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;

namespace DiskQueue.Implementation;

[Serializable]
public sealed class PendingWriteException : Exception
{
	private readonly Exception[] exception_0;

	public Exception[] PendingWritesExceptions => exception_0;

	public override string Message
	{
		get
		{
			StringBuilder stringBuilder = new StringBuilder(base.Message).Append(":");
			Exception[] array = exception_0;
			foreach (Exception ex in array)
			{
				stringBuilder.AppendLine().Append(" - ").Append(ex.Message);
			}
			return stringBuilder.ToString();
		}
	}

	public PendingWriteException(Exception[] pendingWritesExceptions)
		: base("Error during pending writes")
	{
		exception_0 = pendingWritesExceptions;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder(base.Message).Append(":");
		Exception[] array = exception_0;
		foreach (Exception value in array)
		{
			stringBuilder.AppendLine().Append(" - ").Append(value);
		}
		return stringBuilder.ToString();
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("PendingWritesExceptions", PendingWritesExceptions);
	}

	static PendingWriteException()
	{
		Class72.smethod_20();
	}
}
