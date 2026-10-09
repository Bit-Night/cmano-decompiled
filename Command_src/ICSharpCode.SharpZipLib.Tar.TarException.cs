using System;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib.Tar;

[Serializable]
public class TarException : SharpZipBaseException
{
	public TarException()
	{
	}

	public TarException(string message)
		: base(message)
	{
	}

	public TarException(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	protected TarException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	static TarException()
	{
		Class72.smethod_20();
	}
}
